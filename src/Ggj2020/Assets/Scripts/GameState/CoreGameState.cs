using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGameState : IGameState
{
	private readonly IAssetService _assetService;
	private GameModel _model;
	private GameObject _map;
	private GameObject _splitScreenUI;

	public CoreGameState(IAssetService assetService, GameModel model)
	{
		_assetService = assetService;
		_model = model;
	}
	public IEnumerator Load()
	{
		yield return _assetService.LoadAsset(AssetCatalogue.Car01);
		yield return _assetService.LoadAsset(AssetCatalogue.Map02);
		yield return _assetService.LoadAsset(AssetCatalogue.Projectile);
		yield return _assetService.LoadAsset(AssetCatalogue.SplitScreenUI);
	}

	public IEnumerator Enter()
	{
		_map = _assetService.GetAssetInstance(AssetCatalogue.Map02);
		_splitScreenUI = _assetService.GetAssetInstance(AssetCatalogue.SplitScreenUI);
		_model.Activate();
		yield return null;
	}

	public IEnumerator Exit()
	{
		Object.Destroy(_map);
		Object.Destroy(_splitScreenUI);
		yield return null;
	}

	public IEnumerator Unload()
	{
		yield return _assetService.UnloadAsset(AssetCatalogue.Map02);
		yield return _assetService.UnloadAsset(AssetCatalogue.SplitScreenUI);
	}
}