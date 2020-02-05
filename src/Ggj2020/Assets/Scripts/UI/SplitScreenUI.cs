using System;
using System.Collections;
using System.Collections.Generic;
using DriverInterface;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SplitScreenUI : MonoBehaviour
{
	public List<ScreenLayout> AvailableLayouts;

	private List<PlayerSplitCam> _activeCameras = new List<PlayerSplitCam>();
	private int _activeNumberOfPlayers;

	[Inject]
	public void Inject(SignalBus bus)
	{
		bus.Subscribe<GameSignals.AddPlayerCam>(AddNewPlayerCam);
	}

	private void AddNewPlayerCam(GameSignals.AddPlayerCam signal)
	{
		_activeNumberOfPlayers++;
		_activeCameras.Add(signal.PlayerSplitCam);
		UpdateScreenLayout();
	}

	private void UpdateScreenLayout()
	{
		foreach (var layout in AvailableLayouts)
		{
			if (layout.NumberOfPlayers != _activeNumberOfPlayers)
			{
				layout.Disable();
			}
			else
			{
				layout.Enable(_activeCameras);
			}
		}
	}
}
