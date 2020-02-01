using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class InitGameState : IGameState
{
	
	public IEnumerator Load()
	{
		yield return Addressables.InitializeAsync();
	}

	public IEnumerator Enter()
	{
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