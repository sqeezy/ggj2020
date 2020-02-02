package com.innogames.jam2020.commserver;

import org.json.JSONObject;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.web.socket.BinaryMessage;
import org.springframework.web.socket.CloseStatus;
import org.springframework.web.socket.WebSocketMessage;
import org.springframework.web.socket.WebSocketSession;
import org.springframework.web.socket.handler.AbstractWebSocketHandler;

import java.nio.charset.StandardCharsets;
import java.util.List;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;
import java.util.stream.Collectors;

/**
 * This class wires together the communication between the master client and player clients.
 * <p>
 * The protocol is fairly simple:
 * - Messages from player clients are sent to the master client
 * - Messages from the master client are sent to every player client
 * - The format of the message is JSON objects via the binary websocket message (binary due to limitations of the Unity client)
 * - The only required field of the JSON object is the player ID of the sending client, as the comm-server requires it
 * for routing, so it looks like this:
 * <p>
 * {
 * "PlayerId": "..."
 * "...": "..."
 * ...
 * }
 * <p>
 * Everything else can be freely defined by the clients.
 * <p>
 * - A master is identified by sending an event with the player id "master".
 * - If multiple servers identify as "master", anything might happen ¯\_(ツ)_/¯
 */
public class WebSocketHandler extends AbstractWebSocketHandler {

	private static final Logger log = LoggerFactory.getLogger(WebSocketHandler.class);
	private static final String MASTER = "master";
	private static final String JSON_PLAYER_ID = "PlayerId";

	// This maps the websocket session to the playerId playing on it
	private final Map<WebSocketSession, String> sessions = new ConcurrentHashMap<>();


	@Override
	public void afterConnectionEstablished(WebSocketSession session) {
		log.debug("Client connected, session id {} from {}", session.getId(), session.getRemoteAddress());
	}

	@Override
	public void afterConnectionClosed(WebSocketSession session, CloseStatus status) {
		log.debug("Client disconnected, session id {} from {} with status {}",
				session.getId(), session.getRemoteAddress(), status);
		sessions.remove(session);
	}

	@Override
	protected void handleBinaryMessage(WebSocketSession session, BinaryMessage message) {
		String payload = new String(message.getPayload().array(), StandardCharsets.UTF_8);
		log.debug("Binary Message received: {}", payload);

		JSONObject json = new JSONObject(payload);
		String playerId = json.getString(JSON_PLAYER_ID);
		String oldPlayerId = sessions.put(session, playerId);
		if (MASTER.equals(playerId) && !playerId.equals(oldPlayerId)) {
			log.debug("Session {} promoted itself to master!", session.getId());
		}

		//TODO: deal with multiple masters (kick out other masters) when detecting

		if (MASTER.equals(playerId)) {
			forwardToPlayers(message);
		} else {
			forwardToMaster(message);
		}
	}

	private void forwardToPlayers(WebSocketMessage message) {
		List<WebSocketSession> playerSessions = sessions.entrySet().stream()
				.filter(entry -> !entry.getValue().equals(MASTER))
				.map(Map.Entry::getKey)
				.collect(Collectors.toList());

		forwardToClients(playerSessions, message);
	}

	private void forwardToMaster(WebSocketMessage message) {
		List<WebSocketSession> masterSessions = sessions.entrySet().stream()
				.filter(entry -> entry.getValue().equals(MASTER))
				.map(Map.Entry::getKey)
				.collect(Collectors.toList());

		forwardToClients(masterSessions, message);
	}

	private void forwardToClients(List<WebSocketSession> sessions, WebSocketMessage message) {
		for (WebSocketSession session : sessions) {
			if (session.isOpen()) {
				try {
					synchronized (session) { //underlying Websocket API is not thread-safe, this is the simplest fix
						session.sendMessage(message);
					}
				} catch (Exception e) {
					log.error("Woops!", e);
				}
			}
		}
	}
}
