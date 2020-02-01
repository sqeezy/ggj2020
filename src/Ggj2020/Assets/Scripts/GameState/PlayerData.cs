public class PlayerData
{
	public readonly int PlayerId;
	public CarData CarData;
	public int Coins;

	public PlayerData(int playerId)
	{
		PlayerId = playerId;
	}

	public void SetCoins(int amount)
	{
		Coins -= amount;
	}
}