using CarSystem;
using UnityEngine;
using Zenject;

public class WeaponPresenter : MonoBehaviour
{
	private WeaponData _observedData;
	public WeaponView View;
	private IAssetService _assetService;

	[Inject]
	public void Inject(IAssetService assetService)
	{
		_assetService = assetService;
	}

	public void Init(WeaponData observedData)
	{
		_observedData = observedData;
		_observedData.DataChanged += UpdateView;
		_observedData.FireRequested += Fire;

		UpdateView();
	}

	private void Fire(WeaponType weapon)
	{
		if (weapon == WeaponType.Single)
		{
			var sourcePosition = View.WorldGun1Out;
			var projectile = _assetService.GetAssetInstance(AssetCatalogue.Projectile);
			var view = projectile.GetComponent<ProjectileView>();
			view.StartFly(sourcePosition.transform.position, Quaternion.Euler(View.transform.TransformVector(CarModel.Forward)));
		}
	}

	private void UpdateView()
	{
		View.SetWeaponType(_observedData.Type);
	}
}