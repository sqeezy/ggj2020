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
			var source = View.WorldGun1Out;
			var sourceTransform = source.transform;
			var projectile = _assetService.GetAssetInstance(AssetCatalogue.Projectile);
			var view = projectile.GetComponentInChildren<ProjectileView>();
			view.Owner = transform;
			var start = sourceTransform.position;
			var direction = -sourceTransform.right;
			view.StartFly(sourceTransform);
		}
	}

	private void UpdateView()
	{
		View.SetWeaponType(_observedData.Type);
	}
}