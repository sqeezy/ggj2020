using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerSplitCam : MonoBehaviour
{
	public Camera TargetCamera;
	private string _playerId;
	private SignalBus _signalBus;

	public void Init(string playerId)
	{
		_playerId = playerId;
		_signalBus.Fire(new GameSignals.AddPlayerCam(_playerId, this));
	}

	[Inject]
	public void Inject(SignalBus bus)
	{
		var rt = new RenderTexture(1024, 1024, 16, RenderTextureFormat.ARGB32);
		rt.Create();
		TargetCamera.targetTexture = rt;
		_signalBus = bus;

	}
}