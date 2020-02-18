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
	public void Inject(SignalBus signalBus)
	{
		signalBus.Subscribe<GameSignals.AddPlayerCam>(AddNewPlayerCam);
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
		ClearExistingScreens();
		CreateNewScreen();
	}
	
	
	private void ClearExistingScreens()
	{
		foreach (var activeCamera in _activeCameras)
		{
			activeCamera.TargetCamera.targetTexture = null;
		}

		for (int i = _createdElements.Count - 1; i >= 0; i--)
		{
			Destroy(_createdElements[i].gameObject);
		}

		_createdElements.Clear();
	}
	
	private void CreateNewScreen()
	{
		var screenLayout = 
			new ScreenLayout(_canvas, _activeNumberOfPlayers)
				.ConfigurePanelNumber()
				.ConfigurePanelSize();
		
		
		int currentPlayerId = 0;
		int currentPanelId = 0;
		float offset = 0;
		var slotHeight = screenLayout.LeftSidePanelHeight;

		foreach (var activeCamera in _activeCameras)
		{
			if (currentPlayerId == screenLayout.LeftSidePanels)
			{
				slotHeight = screenLayout.RightSidePanelHeight;
				offset = screenLayout.SideWidth;
				currentPanelId = 0;
			}

			var image = CreateRawImage(currentPlayerId, screenLayout, slotHeight, offset, currentPanelId);
			var rt = CreateRenderTexture(image.rectTransform, activeCamera);
			image.texture = rt;

			currentPlayerId++;
			currentPanelId++;
		}
	}

	private RawImage CreateRawImage(int currentPlayerId, ScreenLayout layout, float slotHeight, float offset,
		int currentPanelId)
	{
		var image = new GameObject($"RenderPanelPlayer_{currentPlayerId}").AddComponent<RawImage>();
		var rectTransform = image.rectTransform;
		_createdElements.Add(image);
		image.transform.SetParent(transform);
		rectTransform.pivot = new Vector2(0, 1);
		rectTransform.localScale = Vector3.one;
		rectTransform.sizeDelta = new Vector2(layout.SideWidth, slotHeight);
		rectTransform.anchorMin = rectTransform.anchorMax = new Vector2(0, 1);
		rectTransform.anchoredPosition = new Vector2(offset, -slotHeight * currentPanelId);
		return image;
	}
	
	private RenderTexture CreateRenderTexture(RectTransform rectTransform, PlayerSplitCam activeCamera)
	{
		var rt = new RenderTexture((int) rectTransform.sizeDelta.x, (int) rectTransform.sizeDelta.y, 16,
			RenderTextureFormat.ARGB32);
		rt.Create();
		activeCamera.TargetCamera.targetTexture = rt;
		return rt;
	}

	private struct ScreenLayout
	{
		private readonly RectTransform _canvas;
		private readonly int _activeNumberOfPlayers;
		public int LeftSidePanels;
		public int RightSidePanels;
		public float LeftSidePanelHeight;
		public float RightSidePanelHeight;
		public float SideWidth;

		public ScreenLayout(RectTransform canvas, int activeNumberOfPlayers)
		{
			_canvas = canvas;
			_activeNumberOfPlayers = activeNumberOfPlayers;
			LeftSidePanels = RightSidePanels = 0;
			LeftSidePanelHeight = RightSidePanelHeight = SideWidth = 0;
		}

		public ScreenLayout ConfigurePanelNumber()
		{
			var splits = _activeNumberOfPlayers / 2;
			var rest = _activeNumberOfPlayers % 2;
			LeftSidePanels = splits + rest;
			RightSidePanels = splits;
			return this;
		}

		public ScreenLayout ConfigurePanelSize()
		{
			var sizeDelta = _canvas.sizeDelta;
			var mainSplitNumber = _activeNumberOfPlayers > 1 ? 2 : 1;
			SideWidth = sizeDelta.x / mainSplitNumber;
			LeftSidePanelHeight = (sizeDelta.y / LeftSidePanels);

			RightSidePanelHeight = 0;
			if (RightSidePanels > 0)
			{
				RightSidePanelHeight = sizeDelta.y / RightSidePanels;
			}

			return this;
		}
	}
}
