using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DriverPresenter : MonoBehaviour
{
	private WebSocketService _webSocketService;
	private readonly string _playerUUID = "totally_random"; //TODO

	[Inject]
	public void Init(WebSocketService webSocketService)
	{
		_webSocketService = webSocketService;
	}

	public void OnButtonDown()
	{
		InputSignal signal = new InputSignal.ForwardArrowDown(_playerUUID);
		_webSocketService.Send(signal.ToJson());
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