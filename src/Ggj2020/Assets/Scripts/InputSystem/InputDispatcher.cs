﻿using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

public class InputDispatcher : IInputDispatcher
{
	private readonly SignalBus _signalBus;

	public InputDispatcher(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	public void LeftArrowDown(string playerId)
	{
		_signalBus.Fire(new InputSignal.LeftArrowDown(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void LeftArrowUp(string playerId)
	{
		_signalBus.Fire(new InputSignal.LeftArrowUp(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void RightArrowDown(string playerId)
	{
		_signalBus.Fire(new InputSignal.RightArrowDown(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void RightArrowUp(string playerId)
	{
		_signalBus.Fire(new InputSignal.RightArrowUp(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void ForwardArrowUp(string playerId)
	{
		_signalBus.Fire(new InputSignal.ForwardArrowUp(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void ForwardArrowDown(string playerId)
	{
		_signalBus.Fire(new InputSignal.ForwardArrowDown(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void DownArrowUp(string playerId)
	{
		_signalBus.Fire(new InputSignal.DownArrowUp(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void DownArrowDown(string playerId)
	{
		_signalBus.Fire(new InputSignal.DownArrowDown(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void FireDown(string playerId)
	{
		_signalBus.Fire(new InputSignal.FireDown(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void FireUp(string playerId)
	{
		_signalBus.Fire(new InputSignal.FireUp(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}
}

public interface IInputDispatcher
{
	void LeftArrowDown(string playerId);
	void LeftArrowUp(string playerId);
	void RightArrowDown(string playerId);
	void RightArrowUp(string playerId);
	void ForwardArrowUp(string playerId);
	void ForwardArrowDown(string playerId);
	void DownArrowUp(string playerId);
	void DownArrowDown(string playerId);
	void FireDown(string playerId);
	void FireUp(string playerId);
}

public class GameSignals
{
	public class PlayerActionTriggered
	{
		public readonly string PlayerId;

		public PlayerActionTriggered(string playerId)
		{
			PlayerId = playerId;
		}
	}
}

[Serializable]
public class NetworkEvent
{
	public string PlayerId;
	public string EventType;

	public NetworkEvent(string playerId, string eventType)
	{
		PlayerId = playerId;
		EventType = eventType;
	}
}

public class InputSignal
{
	public readonly string PlayerId;

	public InputSignal(string playerId)
	{
		PlayerId = playerId;
	}

	public string ToJson()
	{
		var networkEvent = new NetworkEvent(PlayerId, this.GetType().ToString());
		return JsonUtility.ToJson(networkEvent);
	}

	public static InputSignal FromJson(string input)
	{
		var networkEvent = JsonUtility.FromJson<NetworkEvent>(input);
		var t = Type.GetType(networkEvent.EventType);
		return (InputSignal) Activator.CreateInstance(t, networkEvent.PlayerId);
	}

	public class ServerEvent : InputSignal
	{
		public ServerEvent(string playerId) : base(playerId)
		{
		}
	}

	public class LeftArrowDown : InputSignal
	{
		public LeftArrowDown(string playerId) : base(playerId)
		{
		}
	}

	public class LeftArrowUp : InputSignal
	{
		public LeftArrowUp(string playerId) : base(playerId)
		{
		}
	}

	public class RightArrowDown : InputSignal
	{
		public RightArrowDown(string playerId) : base(playerId)
		{
		}
	}

	public class RightArrowUp : InputSignal
	{
		public RightArrowUp(string playerId) : base(playerId)
		{
		}
	}

	public class ForwardArrowUp : InputSignal
	{
		public ForwardArrowUp(string playerId) : base(playerId)
		{
		}
	}

	public class ForwardArrowDown : InputSignal
	{
		public ForwardArrowDown(string playerId) : base(playerId)
		{
		}
	}

	public class DownArrowDown : InputSignal
	{
		public DownArrowDown(string playerId) : base(playerId)
		{
		}
	}

	public class DownArrowUp : InputSignal
	{
		public DownArrowUp(string playerId) : base(playerId)
		{
		}
	}

	public class FireDown : InputSignal
	{
		public FireDown(string playerId) : base(playerId)
		{
		}
	}

	public class FireUp : InputSignal
	{
		public FireUp(string playerId) : base(playerId)
		{
		}
	}
}