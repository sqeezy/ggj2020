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

	public List<PlayerSplitCam> ActiveCameras;
	[Inject]
	public void Inject(SignalBus bus)
	{
		bus.Subscribe<GameSignals.AddPlayerCam>(AddNewPlayerCam);
	}

	private void AddNewPlayerCam(GameSignals.AddPlayerCam signal)
	{
		ActiveCameras.Add(signal.PlayerSplitCam);
		foreach (var layout in AvailableLayouts)
		{
			layout.Disable();
		}
	}
}
