using System.Collections.Generic;
using InputSystem;
using UnityEditor;
using UnityEngine;

public class KeyboardInputPlugin : IInputPlugin
{
	private List<PlayerKeyboardInputMapper> _registeredPlayers = new List<PlayerKeyboardInputMapper>();
	
	private IInputDispatcher _inputDispatcher;

	public KeyboardInputPlugin(IInputDispatcher inputDispatcher)
	{
		_inputDispatcher = inputDispatcher;
		_registeredPlayers.Add(new PlayerKeyboardInputMapper("0", KeyCode.LeftArrow,
			KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.RightShift, KeyCode.Return,
			inputDispatcher));

		_registeredPlayers.Add(new PlayerKeyboardInputMapper("1", KeyCode.A,
			KeyCode.D, KeyCode.W, KeyCode.S, KeyCode.F, KeyCode.G, inputDispatcher));
	}


	public void CheckInput()
	{
		foreach (var player in _registeredPlayers)
		{
			player.CheckInput();
		}
		if (Input.GetKey(KeyCode.P))
		{
			int playerNumber = 5;
			for (int i = 2; i < playerNumber; i++)
			{
				_registeredPlayers.Add(new PlayerKeyboardInputMapper(i.ToString(), KeyCode.LeftArrow,
					KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.RightShift, KeyCode.Return,
					_inputDispatcher));
			}
		}
	}
}