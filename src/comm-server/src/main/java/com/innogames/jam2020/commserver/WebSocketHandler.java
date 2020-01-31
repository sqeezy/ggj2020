package com.innogames.jam2020.commserver;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.web.socket.BinaryMessage;
import org.springframework.web.socket.TextMessage;
import org.springframework.web.socket.WebSocketSession;
import org.springframework.web.socket.handler.AbstractWebSocketHandler;

public class WebSocketHandler extends AbstractWebSocketHandler {

	private static final Logger log = LoggerFactory.getLogger(WebSocketHandler.class);


	@Override
	protected void handleTextMessage(WebSocketSession session, TextMessage message) throws Exception {
		log.debug("Text Message received {}", message.getPayload());
		session.sendMessage(message);
	}

	@Override
	protected void handleBinaryMessage(WebSocketSession session, BinaryMessage message) throws Exception {
		log.debug("Binary Message received");
		session.sendMessage(message);
	}
}
