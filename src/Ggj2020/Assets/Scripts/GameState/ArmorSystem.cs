using System.Collections.Generic;

public class ArmorSystem
{
	private const int RepairCost = 200;
	private const ulong ArmorMax = 7;

	private static readonly Dictionary<uint, uint> _upgradePaths = new Dictionary<uint, uint>
	{
		{1, 2},
		{2, 4},
		{3, 4},
		{4, 5},
		{5, 7},
		{6, 7}
	};

	public bool CanUpgrade(PlayerData player)
	{
		return player.CarData.ArmorLevel < ArmorMax && player.Coins >= RepairCost;
	}

	public void Upgrade(PlayerData player)
	{
		if (player.Coins < RepairCost)
		{
			return;
		}

		player.SetCoins(player.Coins - RepairCost);
		player.CarData.SetArmorLevel(_upgradePaths[player.CarData.ArmorLevel]);
	}
}