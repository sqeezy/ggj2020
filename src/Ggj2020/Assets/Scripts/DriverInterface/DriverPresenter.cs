using System;
using System.Collections;
using System.Collections.Generic;
using GenericProvider;
using UnityEngine;
using Zenject;

public class DriverPresenter : MonoBehaviour
{
	private WebSocketService _webSocketService;
	private PlayerId _playerId;

	[Inject]
	public void Init(WebSocketService webSocketService, PlayerId playerId)
	{
		_webSocketService = webSocketService;
		_playerId = playerId;
	}

	public void OnButtonDown()
	{
		InputSignal signal = new InputSignal.ForwardArrowDown(_playerId.Get());
		_webSocketService.Send(signal.ToJson());
	}

	public void MakeMeMaster()
	{
		_playerId.MakeMeMaster();
		// to inform comm server that we are master
		_webSocketService.Send(new InputSignal.ServerEvent(_playerId.Get()).ToJson());
	}

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
	}
}