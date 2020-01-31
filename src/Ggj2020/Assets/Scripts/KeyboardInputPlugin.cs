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
		CheckPlayerZero();
		CheckPlayerOne();
	}

	private void CheckPlayerZero()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			_inputDispatcher.LeftArrowDown(0);
		}

		if (Input.GetKeyUp(KeyCode.LeftArrow))
		{
			_inputDispatcher.LeftArrowUp(0);
		}

		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			_inputDispatcher.RightArrowDown(0);
		}

		if (Input.GetKeyUp(KeyCode.RightArrow))
		{
			_inputDispatcher.RightArrowUp(0);
		}
		
		if (Input.GetKeyUp(KeyCode.UpArrow))
		{
			_inputDispatcher.RightArrowUp(0);
		}
		
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			_inputDispatcher.RightArrowUp(0);
		}
	}
	
	private void CheckPlayerOne()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			_inputDispatcher.LeftArrowDown(1);
		}

		if (Input.GetKeyUp(KeyCode.A))
		{
			_inputDispatcher.LeftArrowUp(1);
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			_inputDispatcher.RightArrowDown(1);
		}

		if (Input.GetKeyUp(KeyCode.D))
		{
			_inputDispatcher.RightArrowUp(1);
		}
		
		if (Input.GetKeyUp(KeyCode.W))
		{
			_inputDispatcher.RightArrowUp(1);
		}
		
		if (Input.GetKeyDown(KeyCode.W))
		{
			_inputDispatcher.RightArrowUp(1);
		}
	}
}