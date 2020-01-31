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
		_signalBus.Fire(new InputSignals.LeftArrowDown(playerId));
	}

	public void LeftArrowUp(int playerId)
	{
		_signalBus.Fire(new InputSignals.LeftArrowUp(playerId));
	}

	public void RightArrowDown(int playerId)
	{
		_signalBus.Fire(new InputSignals.RightArrowDown(playerId));
	}

	public void RightArrowUp(int playerId)
	{
		_signalBus.Fire(new InputSignals.RightArrowUp(playerId));
	}

	public void ForwardArrowUp(int playerId)
	{
		_signalBus.Fire(new InputSignals.ForwardArrowUp(playerId));
	}

	public void ForwardArrowDown(int playerId)
	{
		_signalBus.Fire(new InputSignals.ForwardArrowDown(playerId));
	}

	public void DownArrowUp(int playerId)
	{
		_signalBus.Fire(new InputSignals.DownArrowUp(playerId));
	}

	public void DownArrowDown(int playerId)
	{
		_signalBus.Fire(new InputSignals.DownArrowDown(playerId));
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

public class InputSignals
{
	public class LeftArrowDown
	{
		public readonly int PlayerId;

		public LeftArrowDown(int playerId)
		{
			PlayerId = playerId;
		}
	}

	public class LeftArrowUp
	{
		public readonly int PlayerId;

		public LeftArrowUp(int playerId)
		{
			PlayerId = playerId;
		}
	}

	public class RightArrowDown
	{
		public readonly int PlayerId;

		public RightArrowDown(int playerId)
		{
			PlayerId = playerId;
		}
	}

	public class RightArrowUp
	{
		public readonly int PlayerId;

		public RightArrowUp(int playerId)
		{
			PlayerId = playerId;
		}
	}

	public class ForwardArrowUp
	{
		public readonly int PlayerId;

		public ForwardArrowUp(int playerId)
		{
			PlayerId = playerId;
		}
	}
	
	public class ForwardArrowDown
	{
		public readonly int PlayerId;

		public ForwardArrowDown(int playerId)
		{
			PlayerId = playerId;
		}
	}

	public class DownArrowDown
	{
		public readonly int PlayerId;

		public DownArrowDown(int playerId)
		{
			PlayerId = playerId;
		}
	}

	public class DownArrowUp
	{
		public readonly int PlayerId;

		public DownArrowUp(int playerId)
		{
			PlayerId = playerId;
		}
	}
}