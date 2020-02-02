using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

public class ResourcesAssetLoader : IAssetService
{
	private readonly DiContainer _diContainer;
	public Dictionary<string, GameObject> _preloadedObjects = new Dictionary<string, GameObject>();
	
	public ResourcesAssetLoader(DiContainer diContainer)
	{
		_diContainer = diContainer;
	}
	
	public IEnumerator LoadAsset(string assetId)
	{
		if (!_preloadedObjects.ContainsKey(assetId))
		{
			var loader = Resources.LoadAsync<GameObject>(assetId);
			yield return loader;
			_preloadedObjects.Add(assetId, loader.asset as GameObject);
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