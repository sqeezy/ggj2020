using System;
using System.Text;
using GenericProvider;
using UnityEngine;
using HybridWebSocket;
using Zenject;

/// <summary>
/// The websocket service will attempt to always have an open connection with the server.
/// </summary>
public class WebSocketService
{
	private const string WEBSOCKET_PROTOCOL = "ws";
	private const string WEBSOCKET_URL_PATH = "socket";
	private readonly SignalBus _signalBus;
	private readonly MainThreadQueue _mainThreadQueue;
	private readonly WebSocket _webSocket;

	public WebSocketService(SignalBus signalBus, MainThreadQueue mainThreadQueue, URLReader urlReader)
	{
		Debug.Log("WebSocketService ahoy!");
		_signalBus = signalBus;
		_mainThreadQueue = mainThreadQueue;

		var browerUri = new UriBuilder(urlReader.ReadURL());
		var baseUri = new UriBuilder(WEBSOCKET_PROTOCOL, browerUri.Host, browerUri.Port, browerUri.Path).Uri;
		var fullUri = new Uri(baseUri, WEBSOCKET_URL_PATH);
		Debug.Log("Trying to connect to " + fullUri);

		var url = fullUri.ToString();
		//uncomment following line to connect to the deployed server
		//url = "ws://ggj.sqeezy.tech/socket";
		
		_webSocket = WebSocketFactory.CreateInstance(url);

		_webSocket.OnOpen += OnOpen;
		_webSocket.OnMessage += OnMessage;
		_webSocket.OnError += OnError;
		_webSocket.OnClose += OnClose;
		
		_signalBus.Subscribe<NetworkEvent>(m => Send(m.ToJson()));

		Connect();
	}

	public void Send(string message)
	{
		try
		{
			_webSocket.Send(ToBytes(message));
		}
		catch (Exception e)
		{
			Debug.Log("Failed to send " + message + " " + e.Message);
		}
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
	}

	private void OnMessage(byte[] msg)
	{
		var message = ToString(msg);
		Debug.Log("WS received message: " + message);

		_mainThreadQueue.enqueueAction(() =>
			{
				try
				{
					var inputSignal = InputSignal.FromJson(message);
					_signalBus.Fire(inputSignal);
					_signalBus.Fire(new GameSignals.PlayerActionTriggered(inputSignal.PlayerId));
				}
				catch (Exception e)
				{
					Debug.Log("Failed to process " + message + " " + e.Message);
				}
			});
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

	private static byte[] ToBytes(string input)
	{
		return Encoding.UTF8.GetBytes(input);
	}


	private static string ToString(byte[] input)
	{
		return Encoding.UTF8.GetString(input);
	}
}