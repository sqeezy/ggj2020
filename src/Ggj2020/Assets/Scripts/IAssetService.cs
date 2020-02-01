using System.Collections;
using UnityEngine;

public interface IAssetService
{
	IEnumerator LoadAsset(string assetId);
	GameObject GetAssetInstance(string assetId);
}