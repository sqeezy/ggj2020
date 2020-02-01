public class PlayerData
{
	public readonly string PlayerId;
	public CarData CarData;
	public int Coins;

	public PlayerData(string playerId)
	{
		PlayerId = playerId;
	}

	public void SetCoins(int amount)
	{
		Coins -= amount;
	}
}