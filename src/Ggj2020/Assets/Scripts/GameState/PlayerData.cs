using Zenject;

public class PlayerData
{
	private readonly SignalBus _signalBus;
	public readonly string PlayerId;
	public CarData CarData;
	public int Coins;

	public PlayerData(SignalBus signalBus, string playerId)
	{
		_signalBus = signalBus;
		PlayerId = playerId;
	}

	public void SetCoins(int amount)
	{
		Coins -= amount;
		_signalBus.Fire(new GameSignals.ChangeResourceSignal(PlayerId, -amount));
	}
}