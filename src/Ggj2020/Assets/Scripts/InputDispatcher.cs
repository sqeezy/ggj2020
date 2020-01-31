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
		_signalBus.Fire(new InputSignals.LeftArrowDownSignal(playerId));
	}

	public void LeftArrowUp(int playerId)
	{
		_signalBus.Fire(new InputSignals.LeftArrowUpSignal(playerId));
	}

	public void RightArrowDown(int playerId)
	{
		_signalBus.Fire(new InputSignals.RightArrowDownSignal(playerId));
	}

	public void RightArrowUp(int playerId)
	{
		_signalBus.Fire(new InputSignals.RightArrowUpSignal(playerId));
	}

	public void ForwardArrowUp(int playerId)
	{
		_signalBus.Fire(new InputSignals.ForwardArrowUp(playerId));
	}

	public void ForwardArrowDown(int playerId)
	{
		_signalBus.Fire(new InputSignals.ForwardArrowDown(playerId));
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

}

public class InputSignals
{
	public class LeftArrowDownSignal
	{
		public readonly int PlayerId;

		public LeftArrowDownSignal(int playerId)
		{
			PlayerId = playerId;
		}
	}

	public class LeftArrowUpSignal
	{
		public readonly int PlayerId;

		public LeftArrowUpSignal(int playerId)
		{
			PlayerId = playerId;
		}
	}

	public class RightArrowDownSignal
	{
		public readonly int PlayerId;

		public RightArrowDownSignal(int playerId)
		{
			PlayerId = playerId;
		}
	}

	public class RightArrowUpSignal
	{
		public readonly int PlayerId;

		public RightArrowUpSignal(int playerId)
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
}