using System;

namespace CarSystem
{
	public enum WeaponType
	{
		Single,
		Triple
	}

	public class WeaponData
	{
		public WeaponType Type;
		public uint Ammo;
		public uint MaxAmmo;
		public event Action DataChanged = () => { };
		public event Action<WeaponType> FireRequested = wt => { };

		public static WeaponData Single()
		{
			return new WeaponData {Type = WeaponType.Single, Ammo = 3, MaxAmmo = 3};
		}

		public static WeaponData Triple()
		{
			return new WeaponData {Type = WeaponType.Triple, Ammo = 3, MaxAmmo = 5};
		}

		public void SetAmmo(uint newAmmo)
		{
			Ammo = newAmmo;
			DataChanged();
		}

		public void RequestFire()
		{
			FireRequested(Type);
		}
	}
}