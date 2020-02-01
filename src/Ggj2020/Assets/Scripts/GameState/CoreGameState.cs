using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CoreGameState : IGameState
{
	private readonly IAssetService _assetService;
	private GameModel _model;

	public CoreGameState(IAssetService assetService, GameModel model)
	{
		_assetService = assetService;
		_model = model;
	}
	public IEnumerator Load()
	{
		yield return _assetService.LoadAsset(AssetCatalogue.Car01);
	}

	public IEnumerator Enter()
	{
		_model.Activate();
		yield return null;
	}

	public IEnumerator Exit()
	{
		yield return null;
	}

	public IEnumerator Unload()
	{
		yield return null;
	}
}