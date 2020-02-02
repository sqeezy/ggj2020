using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class AssetService : IAssetService
{
	private readonly DiContainer _diContainer;

	public AssetService(DiContainer diContainer)
	{
		_diContainer = diContainer;
	}
	public Dictionary<string, GameObject> _preloadedObjects = new Dictionary<string, GameObject>();
	public IEnumerator LoadAsset(string assetId)
	{
		if (!_preloadedObjects.ContainsKey(assetId))
		{
			var loader = Addressables.LoadAssetAsync<GameObject>(assetId);
			yield return loader;
			_preloadedObjects.Add(assetId, loader.Result);
		}
	}

	public GameObject GetAssetInstance(string assetId)
	{
		return _diContainer.InstantiatePrefab(_preloadedObjects[assetId]);
	}

	public IEnumerator UnloadAsset(string assetId)
	{
		if (_preloadedObjects.ContainsKey(assetId))
		{
			_preloadedObjects.Remove(assetId);
			//TODO unload from addressables
		}
		yield return null;
	}
}