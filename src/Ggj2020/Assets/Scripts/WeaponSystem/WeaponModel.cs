namespace CarSystem
{
	public class WeaponModel
	{
		private readonly WeaponData _observedData;
		public const float MaxVelocity = CarModel.MaxVelocity + 7.5f;

		public WeaponModel(WeaponData observedData)
		{
			_observedData = observedData;
		}

		private bool NoAmmo => false;// _observedData.Ammo == 0;

		public void Fire()
		{
			if (NoAmmo)
			{
				return;
			}

			_observedData.SetAmmo(_observedData.Ammo - 1);
			_observedData.RequestFire();
		}
	}
}