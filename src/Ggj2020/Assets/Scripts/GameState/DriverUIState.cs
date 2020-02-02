using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverUIState : IGameState
{
	private readonly IAssetService _assetService;
	private GameObject _menu;

	public DriverUIState(IAssetService assetService)
	{
		_assetService = assetService;
	}
	public IEnumerator Load()
	{
		yield return _assetService.LoadAsset(AssetCatalogue.DriverUI);
	}

	public IEnumerator Enter()
	{
		_menu = _assetService.GetAssetInstance(AssetCatalogue.DriverUI);
		_menu.SetActive(true);
		yield return null;
	}

	public IEnumerator Exit()
	{
		Object.Destroy(_menu);
		yield return null; 
	}

	public IEnumerator Unload()
	{
		yield return _assetService.UnloadAsset(AssetCatalogue.DriverUI);
	}
}