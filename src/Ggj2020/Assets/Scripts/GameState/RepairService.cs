using System.Collections.Generic;

public class RepairService
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

	public bool CanUpgrade(PlayerModel player)
	{
		return player.ArmorLevel < ArmorMax && player.Coins >= RepairCost;
	}

	public void Repair(PlayerModel player)
	{
		if (player.Coins < RepairCost)
		{
			return;
		}

		player.Pay(RepairCost);

		player.UpgradeArmor(_upgradePaths[player.ArmorLevel]);
	}
}