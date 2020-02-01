namespace CarSystem
{
	public enum WeaponType
	{
		Projectile
	}

	public class Weapon
	{
		public WeaponType Type;
		public int Ammo;
		public int MaxAmmo;

		public static Weapon Projectile()
		{
			return new Weapon {Type = WeaponType.Projectile, Ammo = 2, MaxAmmo = 2};
		}
	}
}