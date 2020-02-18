using System;
using System.Runtime.CompilerServices;
using TMPro;
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
		_signalBus.Fire(new PlayerSignal.LeftArrowDown(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void LeftArrowUp(string playerId)
	{
		_signalBus.Fire(new PlayerSignal.LeftArrowUp(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void RightArrowDown(string playerId)
	{
		_signalBus.Fire(new PlayerSignal.RightArrowDown(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void RightArrowUp(string playerId)
	{
		_signalBus.Fire(new PlayerSignal.RightArrowUp(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void ForwardArrowUp(string playerId)
	{
		_signalBus.Fire(new PlayerSignal.ForwardArrowUp(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void ForwardArrowDown(string playerId)
	{
		_signalBus.Fire(new PlayerSignal.ForwardArrowDown(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void DownArrowUp(string playerId)
	{
		_signalBus.Fire(new PlayerSignal.DownArrowUp(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void DownArrowDown(string playerId)
	{
		_signalBus.Fire(new PlayerSignal.DownArrowDown(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void FireDown(string playerId)
	{
		_signalBus.Fire(new PlayerSignal.FireDown(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void FireUp(string playerId)
	{
		_signalBus.Fire(new PlayerSignal.FireUp(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void UpgradeArmor(string playerId)
	{
		_signalBus.Fire(new PlayerSignal.UpgradeArmor(playerId));
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
	void UpgradeArmor(string playerId);
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

	public class ChangeResourceSignal : PlayerSignal
	{
		public readonly int Resources;

		public ChangeResourceSignal(string playerId, int resources) : base(playerId)
		{
			Resources = resources;
		}
	}

	public class GotoStateSignal 
	{
		public readonly Type TargetType;

		public GotoStateSignal(Type targetType)
		{
			TargetType = targetType;
		}
	}

	public class AddPlayerCam : PlayerSignal
	{
		public readonly PlayerSplitCam PlayerSplitCam;

		public AddPlayerCam(string playerId, PlayerSplitCam playerSplitCam) : base(playerId)
		{
			PlayerSplitCam = playerSplitCam;
		}
	}
}

public class PlayerSignal
{
	public readonly string PlayerId;

	public PlayerSignal(string playerId)
	{
		PlayerId = playerId;
	}

	public NetworkEvent ToNetwork()
	{
		return new NetworkEvent(PlayerId, this.GetType().ToString());
	}

	public static PlayerSignal FromJson(string input)
	{
		var networkEvent = JsonUtility.FromJson<NetworkEvent>(input);
		var t = Type.GetType(networkEvent.EventType);
		return (PlayerSignal) Activator.CreateInstance(t, networkEvent.PlayerId);
	}

	public class IAmMaster : PlayerSignal
	{
		public IAmMaster(string playerId) : base(playerId)
		{
		}
	}

	public class LeftArrowDown : PlayerSignal
	{
		public LeftArrowDown(string playerId) : base(playerId)
		{
		}
	}

	public class LeftArrowUp : PlayerSignal
	{
		public LeftArrowUp(string playerId) : base(playerId)
		{
		}
	}

	public class RightArrowDown : PlayerSignal
	{
		public RightArrowDown(string playerId) : base(playerId)
		{
		}
	}

	public class RightArrowUp : PlayerSignal
	{
		public RightArrowUp(string playerId) : base(playerId)
		{
		}
	}

	public class ForwardArrowUp : PlayerSignal
	{
		public ForwardArrowUp(string playerId) : base(playerId)
		{
		}
	}

	public class ForwardArrowDown : PlayerSignal
	{
		public ForwardArrowDown(string playerId) : base(playerId)
		{
		}
	}

	public class DownArrowDown : PlayerSignal
	{
		public DownArrowDown(string playerId) : base(playerId)
		{
		}
	}

	public class DownArrowUp : PlayerSignal
	{
		public DownArrowUp(string playerId) : base(playerId)
		{
		}
	}

	public class FireDown : PlayerSignal
	{
		public FireDown(string playerId) : base(playerId)
		{
		}
	}

	public class FireUp : PlayerSignal
	{
		public FireUp(string playerId) : base(playerId)
		{
		}
	}

	public class UpgradeArmor : PlayerSignal
	{
		public UpgradeArmor(string playerId) : base(playerId)
		{
		}
	}
}