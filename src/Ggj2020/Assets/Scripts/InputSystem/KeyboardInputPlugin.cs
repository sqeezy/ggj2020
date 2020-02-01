using System.Collections;
using System.Collections.Generic;
using InputSystem;
using UnityEngine;
using Zenject;

public class KeyboardInputPlugin : IInputPlugin
{
	private readonly PlayerKeyboardInputMapper _playerZero;
	private readonly PlayerKeyboardInputMapper _playerOne;

	public KeyboardInputPlugin(IInputDispatcher inputDispatcher)
	{
		_playerZero = new PlayerKeyboardInputMapper("0", KeyCode.LeftArrow,
			KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.RightShift, inputDispatcher);

		_playerOne = new PlayerKeyboardInputMapper("1", KeyCode.A,
			KeyCode.D, KeyCode.W, KeyCode.S, KeyCode.F, inputDispatcher);
	}


	public void CheckInput()
	{
		_playerZero.CheckInput();
		_playerOne.CheckInput();
	}
}