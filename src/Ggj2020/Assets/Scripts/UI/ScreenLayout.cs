using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenLayout : MonoBehaviour
{
	public int NumberOfPlayers;
	public List<RawImage> PlayerArea;

	public void Disable()
	{
		gameObject.SetActive(false);
	}
}