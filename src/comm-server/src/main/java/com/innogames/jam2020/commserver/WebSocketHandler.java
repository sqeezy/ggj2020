package com.innogames.jam2020.commserver;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.web.socket.BinaryMessage;
import org.springframework.web.socket.TextMessage;
import org.springframework.web.socket.WebSocketSession;
import org.springframework.web.socket.handler.AbstractWebSocketHandler;

import java.nio.charset.StandardCharsets;

public class WebSocketHandler extends AbstractWebSocketHandler {

	private static final Logger log = LoggerFactory.getLogger(WebSocketHandler.class);


	@Override
	protected void handleTextMessage(WebSocketSession session, TextMessage message) throws Exception {
		log.debug("Text Message received: {}", message.getPayload());
		session.sendMessage(message);
	}

	@Override
	protected void handleBinaryMessage(WebSocketSession session, BinaryMessage message) throws Exception {
		String payload = new String(message.getPayload().array(), StandardCharsets.UTF_8);
		log.debug("Binary Message received: {}", payload);
		session.sendMessage(message);
	}
}
