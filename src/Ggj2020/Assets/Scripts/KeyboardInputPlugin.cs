using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class KeyboardInputPlugin : IInputPlugin
{
	private readonly IInputDispatcher _inputDispatcher;

	public KeyboardInputPlugin(IInputDispatcher inputDispatcher)
	{
		_inputDispatcher = inputDispatcher;
	}
	
	
	public void CheckInput()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			_inputDispatcher.LeftArrowDown();
		}
		
		if (Input.GetKeyUp(KeyCode.LeftArrow))
		{
			_inputDispatcher.LeftArrowUp();
		}
		
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			_inputDispatcher.RightArrowDown();
		}
		
		if (Input.GetKeyUp(KeyCode.RightArrow))
		{
			_inputDispatcher.RightArrowUp();
		}
	}
}