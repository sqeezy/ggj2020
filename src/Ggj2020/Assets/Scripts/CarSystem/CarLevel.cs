using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class CarLevel
{
	public List<GameObject> ActiveObjects;
	public List<GameObject> DeActiveObjects;

	public void ActivateLevel()
	{
		foreach (var connectedObject in ActiveObjects)
		{
			connectedObject.SetActive(true);
		}
		foreach (var connectedObject in DeActiveObjects)
		{
			connectedObject.SetActive(false);
		}
	}
	
	public void DeActivateLevel()
	{
		foreach (var connectedObject in ActiveObjects)
		{
			connectedObject.SetActive(false);
		}
	}
}