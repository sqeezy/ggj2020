using Zenject;

public class InputDispatcher : IInputDispatcher
{
	private readonly SignalBus _signalBus;

	public InputDispatcher(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}
	public void LeftArrowDown()
	{
		_signalBus.Fire<InputSignals.LeftArrowDownSignal>();
	}

	public void LeftArrowUp()
	{
		_signalBus.Fire<InputSignals.LeftArrowUpSignal>();
	}

	public void RightArrowDown()
	{
		_signalBus.Fire<InputSignals.RightArrowDownSignal>();
	}

	public void RightArrowUp()
	{
		_signalBus.Fire<InputSignals.RightArrowUpSignal>();
	}
}

public interface IInputDispatcher
{
	void LeftArrowDown();
	void LeftArrowUp();
	void RightArrowDown();
	void RightArrowUp();
	
}

public class InputSignals
{
	public class LeftArrowDownSignal
	{
	}

	public class LeftArrowUpSignal
	{
	}

	public class RightArrowDownSignal
	{
		
	}

	public class RightArrowUpSignal
	{
		
	}

}