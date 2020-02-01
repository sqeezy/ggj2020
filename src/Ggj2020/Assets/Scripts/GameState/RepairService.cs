public class RepairService
{
	private const int RepairCost = 200;

	public bool CanRepair(PlayerModel player)
	{
		return player.ArmorState != Armor.All && player.Coins >= RepairCost;
	}

	public void Repair(PlayerModel player)
	{
		if (player.Coins < RepairCost)
		{
			return;
		}

		player.Pay(RepairCost);
		player.RepairArmor();
	}
}