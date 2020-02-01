package com.innogames.jam2020.commserver;

import org.json.JSONObject;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.web.socket.BinaryMessage;
import org.springframework.web.socket.CloseStatus;
import org.springframework.web.socket.WebSocketMessage;
import org.springframework.web.socket.WebSocketSession;
import org.springframework.web.socket.handler.AbstractWebSocketHandler;

import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.util.List;
import java.util.Map;
import java.util.Optional;
import java.util.concurrent.ConcurrentHashMap;
import java.util.stream.Collectors;

public class WebSocketHandler extends AbstractWebSocketHandler {

	private static final Logger log = LoggerFactory.getLogger(WebSocketHandler.class);
	private static final String MASTER = "master";
	private static final String JSON_PLAYER_ID = "PlayerId";

	// String = playerId
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
	protected void handleBinaryMessage(WebSocketSession session, BinaryMessage message) throws IOException {
		String payload = new String(message.getPayload().array(), StandardCharsets.UTF_8);
		log.debug("Binary Message received: {}", payload);

		JSONObject json = new JSONObject(payload);
		String playerId = json.getString(JSON_PLAYER_ID);
		sessions.put(session, playerId);

		//TODO: deal with multiple masters (kick out other masters) when detecting

		if (MASTER.equals(playerId)) {
			forwardToPlayers(message);
		} else {
			forwardToMaster(message);
		}
	}

	private void forwardToPlayers(WebSocketMessage message) throws IOException {
		List<WebSocketSession> playerSessions = sessions.entrySet().stream()
				.filter(entry -> !entry.getValue().equals(MASTER))
				.map(Map.Entry::getKey)
				.collect(Collectors.toList());
		for (WebSocketSession playerSession : playerSessions) {
			playerSession.sendMessage(message);
		}
	}

	private void forwardToMaster(WebSocketMessage message) throws IOException {
		Optional<WebSocketSession> masterSession = sessions.entrySet().stream()
				.filter(entry -> entry.getValue().equals(MASTER))
				.findAny()
				.map(Map.Entry::getKey);
		if (masterSession.isPresent()) {
			masterSession.get().sendMessage(message);
		}
	}
}
