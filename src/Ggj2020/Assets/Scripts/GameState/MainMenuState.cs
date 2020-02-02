using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : IGameState
{
	private readonly IAssetService _assetService;
	private GameObject _menu;

	public MainMenuState(IAssetService assetService)
	{
		_assetService = assetService;
	}
	public IEnumerator Load()
	{
		yield return _assetService.LoadAsset(AssetCatalogue.StartMenu);
	}

	public IEnumerator Enter()
	{
		_menu = _assetService.GetAssetInstance(AssetCatalogue.StartMenu);
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
		yield return _assetService.UnloadAsset(AssetCatalogue.StartMenu);
	}
}