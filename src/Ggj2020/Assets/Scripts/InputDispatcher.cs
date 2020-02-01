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

	public void LeftArrowDown(int playerId)
	{
		_signalBus.Fire(new InputSignal.LeftArrowDown(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void LeftArrowUp(int playerId)
	{
		_signalBus.Fire(new InputSignal.LeftArrowUp(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void RightArrowDown(int playerId)
	{
		_signalBus.Fire(new InputSignal.RightArrowDown(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void RightArrowUp(int playerId)
	{
		_signalBus.Fire(new InputSignal.RightArrowUp(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void ForwardArrowUp(int playerId)
	{
		_signalBus.Fire(new InputSignal.ForwardArrowUp(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void ForwardArrowDown(int playerId)
	{
		_signalBus.Fire(new InputSignal.ForwardArrowDown(playerId));
	}

	public void DownArrowUp(int playerId)
	{
		_signalBus.Fire(new InputSignal.DownArrowUp(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}

	public void DownArrowDown(int playerId)
	{
		_signalBus.Fire(new InputSignal.DownArrowDown(playerId));
		_signalBus.Fire(new GameSignals.PlayerActionTriggered(playerId));
	}
}

public interface IInputDispatcher
{
	void LeftArrowDown(int playerId);
	void LeftArrowUp(int playerId);
	void RightArrowDown(int playerId);
	void RightArrowUp(int playerId);
	void ForwardArrowUp(int playerId);
	void ForwardArrowDown(int playerId);
	void DownArrowUp(int playerId);
	void DownArrowDown(int playerId);
}

public class GameSignals
{
	public class PlayerActionTriggered
	{
		public readonly int PlayerId;

		public PlayerActionTriggered(int playerId)
		{
			PlayerId = playerId;
		}
	}
}

public class InputSignal
{
	public readonly int PlayerId;

	public InputSignal(int playerId)
	{
		PlayerId = playerId;
	}

	public class LeftArrowDown : InputSignal
	{
		public LeftArrowDown(int playerId) : base(playerId)
		{
		}
	}

	public class LeftArrowUp : InputSignal
	{
		public LeftArrowUp(int playerId) : base(playerId)
		{
		}
	}

	public class RightArrowDown : InputSignal
	{
		public RightArrowDown(int playerId) : base(playerId)
		{
		}
	}

	public class RightArrowUp : InputSignal
	{
		public RightArrowUp(int playerId) : base(playerId)
		{
		}
	}

	public class ForwardArrowUp : InputSignal
	{
		public ForwardArrowUp(int playerId) : base(playerId)
		{
		}
	}

	public class ForwardArrowDown : InputSignal
	{
		public ForwardArrowDown(int playerId) : base(playerId)
		{
		}
	}

	public class DownArrowDown : InputSignal
	{
		public DownArrowDown(int playerId) : base(playerId)
		{
		}
	}

	public class DownArrowUp : InputSignal
	{
		public DownArrowUp(int playerId) : base(playerId)
		{
		}
	}
}