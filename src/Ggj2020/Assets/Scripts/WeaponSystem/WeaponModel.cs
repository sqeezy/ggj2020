namespace CarSystem
{
	public class WeaponModel
	{
		private readonly WeaponData _observedData;
		public const float MaxVelocity = CarModel.MaxVelocity + 5;

		public WeaponModel(WeaponData observedData)
		{
			_observedData = observedData;
		}

		private bool NoAmmo => _observedData.Ammo == 0;

		public void Fire()
		{
			if (NoAmmo)
			{
				return;
			}

			// create objects here????

			_observedData.SetAmmo(_observedData.Ammo - 1);
		}
	}
}