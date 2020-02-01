using System.Text;
using UnityEngine;
using HybridWebSocket;
using Zenject;

/// <summary>
/// The websocket service will attempt to always have an open connection with the server.
/// </summary>
public class WebSocketService
{
	private const string SERVER_ADDRESS = "ws://localhost:8080/socket";
	private readonly SignalBus _signalBus;
	private readonly WebSocket _webSocket;

	public WebSocketService(SignalBus signalBus)
	{
		Debug.Log("WebSocketService ahoy!");
		_signalBus = signalBus;

		_webSocket = WebSocketFactory.CreateInstance(SERVER_ADDRESS);

		_webSocket.OnOpen += OnOpen;
		_webSocket.OnMessage += OnMessage;
		_webSocket.OnError += OnError;
		_webSocket.OnClose += OnClose;

		Connect();
	}

	private void Connect()
	{
		Debug.Log("WebSocketService connecting");
		_webSocket.Connect();
	}


	private void OnOpen()
	{
		Debug.Log("WS connected!");
		Debug.Log("WS state: " + _webSocket.GetState());

		_webSocket.Send(Encoding.UTF8.GetBytes("Hello from Unity 3D!"));
	}

	private void OnMessage(byte[] msg)
	{
		Debug.Log("WS received message: " + Encoding.UTF8.GetString(msg));
	}

	private static void OnError(string errMsg)
	{
		Debug.Log("WS error: " + errMsg);
	}

	private void OnClose(WebSocketCloseCode code)
	{
		Debug.Log("WS closed with code: " + code.ToString());
		//always reconnect
		Connect();
	}
}