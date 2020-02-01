using InputSystem;
using UnityEngine;

public class KeyboardInputPlugin : IInputPlugin
{
	private readonly PlayerKeyboardInputMapper _playerZero;
	private readonly PlayerKeyboardInputMapper _playerOne;

	public KeyboardInputPlugin(IInputDispatcher inputDispatcher)
	{
		_playerZero = new PlayerKeyboardInputMapper("0", KeyCode.LeftArrow,
			KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.RightShift, KeyCode.Return,
			inputDispatcher);

		_playerOne = new PlayerKeyboardInputMapper("1", KeyCode.A,
			KeyCode.D, KeyCode.W, KeyCode.S, KeyCode.F, KeyCode.G, inputDispatcher);
	}


	public void CheckInput()
	{
		_playerZero.CheckInput();
		_playerOne.CheckInput();
	}
}