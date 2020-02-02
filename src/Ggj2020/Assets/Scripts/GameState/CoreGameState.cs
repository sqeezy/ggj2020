using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CoreGameState : IGameState
{
	private readonly IAssetService _assetService;
	private GameModel _model;
	private GameObject _map;

	public CoreGameState(IAssetService assetService, GameModel model)
	{
		_assetService = assetService;
		_model = model;
	}
	public IEnumerator Load()
	{
		yield return _assetService.LoadAsset(AssetCatalogue.Car01);
		yield return _assetService.LoadAsset(AssetCatalogue.Map01);
	}

	public IEnumerator Enter()
	{
		_map = _assetService.GetAssetInstance(AssetCatalogue.Map01);
		_model.Activate();
		yield return null;
	}

	public IEnumerator Exit()
	{
		Object.Destroy(_map);
		yield return null;
	}

	public IEnumerator Unload()
	{
		yield return null;
	}
}