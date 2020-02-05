using System;
using System.Collections;
using System.Collections.Generic;
using DriverInterface;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Object = UnityEngine.Object;

public class SplitScreenUI : MonoBehaviour
{
	private List<PlayerSplitCam> _activeCameras = new List<PlayerSplitCam>();
	private List<RawImage> _createdElements = new List<RawImage>();
	private int _activeNumberOfPlayers;
	private RectTransform _canvas;

	[Inject]
	public void Inject(SignalBus bus)
	{
		bus.Subscribe<GameSignals.AddPlayerCam>(AddNewPlayerCam);
		_canvas = GetComponent<RectTransform>();
	}

	private void AddNewPlayerCam(GameSignals.AddPlayerCam signal)
	{
		_activeNumberOfPlayers++;
		_activeCameras.Add(signal.PlayerSplitCam);
		UpdateScreenLayout();
	}

	private void UpdateScreenLayout()
	{
		var splits = _activeNumberOfPlayers / 2;
		var rest = _activeNumberOfPlayers % 2;
		int leadSide = splits + rest;
		int supportSide = splits;
		
		var screenWidth = _canvas.sizeDelta.x;
		var screenHeight = _canvas.sizeDelta.y;
		var mainSplitNumber = _activeNumberOfPlayers > 1 ? 2 : 1;
		var sideSize = screenWidth / mainSplitNumber ;
		float leadSidePanelSize = ( screenHeight / leadSide ) ;

		float supportSidePanelSize = 0;
		if (supportSide > 0)
		{
			supportSidePanelSize = screenHeight / supportSide;
		}

		int currentPlayerId = 0;
		int currentPanelId = 0;
		foreach (var activeCamera in _activeCameras)
		{
			activeCamera.TargetCamera.targetTexture = null;

		}

		for (int i = _createdElements.Count-1; i >=0 ; i--)
		{
			Destroy(_createdElements[i].gameObject);
		}
		_createdElements.Clear();
		float offset = 0;
		var slotSize = leadSidePanelSize;
		foreach (var activeCamera in _activeCameras)
		{
			if (currentPlayerId == leadSide)
			{
				slotSize = supportSidePanelSize;
				offset = sideSize;
				currentPanelId = 0;
			}
			var image = new GameObject($"RenderPanelPlayer_{currentPlayerId}").AddComponent<RawImage>();
			_createdElements.Add(image);
			image.transform.SetParent(transform);
			var rectTransform = image.rectTransform;
			rectTransform.pivot = new Vector2(0, 1);
			rectTransform.localScale = Vector3.one;
			rectTransform.sizeDelta = new Vector2(sideSize, slotSize);
			rectTransform.anchorMin = rectTransform.anchorMax = new Vector2(0, 1);
			rectTransform.anchoredPosition = new Vector2(offset, -slotSize*currentPanelId);
			var rt = new RenderTexture((int)rectTransform.sizeDelta.x, (int)rectTransform.sizeDelta.y, 16, RenderTextureFormat.ARGB32);
			rt.Create();
			activeCamera.TargetCamera.targetTexture = rt;
			image.texture = rt;
			currentPlayerId++;
			currentPanelId++;
		}
	}

	
}
