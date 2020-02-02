using System;
using UnityEngine;

/// <summary>
/// This is an event that is bound for the network, just throw it into the signalBus.
/// </summary>
[Serializable]
public class NetworkEvent
{
	//the PlayerId is required by the comm-server protocol, and the outer thing needs to be a JSON object.
	//everything else can be freely defined by the clients
	public string PlayerId;
	public string EventType;

	public NetworkEvent(string playerId, string eventType)
	{
		PlayerId = playerId;
		EventType = eventType;
	}
	
	public string ToJson()
	{
		return JsonUtility.ToJson(this);
	}
}