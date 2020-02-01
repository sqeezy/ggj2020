using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputService : ITickable
{
	private readonly IInputPlugin _activeInputPlugin;

	public InputService(IInputPlugin activeInputPlugin)
	{
		_activeInputPlugin = activeInputPlugin;
	}
	public void Tick()
	{
		_activeInputPlugin.CheckInput();
	}
}