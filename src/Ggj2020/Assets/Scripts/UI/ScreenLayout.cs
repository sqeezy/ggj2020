using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenLayout : MonoBehaviour
{
	public int NumberOfPlayers;
	public List<RawImage> PlayerArea;
	public CanvasScaler _parentScaling; 
	
	public void Disable()
	{
		gameObject.SetActive(false);
	}

	public void Enable(List<PlayerSplitCam> activeCameras)
	{
		for (int i = 0; i < activeCameras.Count; i++)
		{
			var rt = new RenderTexture((int)PlayerArea[i].rectTransform.sizeDelta.x, (int)PlayerArea[i].rectTransform.sizeDelta.y, 16, RenderTextureFormat.ARGB32);
			rt.Create();
			activeCameras[i].TargetCamera.targetTexture = rt;
			PlayerArea[i].texture = rt;
			PlayerArea[i].color = Color.white;
		}
		gameObject.SetActive(true);
		
	}
}