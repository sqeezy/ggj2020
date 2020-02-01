using UnityEngine;

namespace InputSystem
{
	/// <summary>
	/// Map player id and input to the input dispatcher.
	/// </summary>
	public class PlayerKeyboardInputMapper : IInputPlugin
	{
		private readonly string _playerId;
		private readonly KeyCode _left;
		private readonly KeyCode _right;
		private readonly KeyCode _forward;
		private readonly KeyCode _down;
		private readonly KeyCode _fire;
		private readonly IInputDispatcher _inputDispatcher;

		public PlayerKeyboardInputMapper(string playerId, KeyCode left, KeyCode right, KeyCode forward, KeyCode down,
			KeyCode fire,
			IInputDispatcher inputDispatcher)
		{
			_playerId = playerId;
			_left = left;
			_right = right;
			_forward = forward;
			_down = down;
			_fire = fire;
			_inputDispatcher = inputDispatcher;
		}

		public void CheckInput()
		{
			if (Input.GetKeyDown(_left))
			{
				_inputDispatcher.LeftArrowDown(_playerId);
			}

			if (Input.GetKeyUp(_left))
			{
				_inputDispatcher.LeftArrowUp(_playerId);
			}

			if (Input.GetKeyDown(_right))
			{
				_inputDispatcher.RightArrowDown(_playerId);
			}

			if (Input.GetKeyUp(_right))
			{
				_inputDispatcher.RightArrowUp(_playerId);
			}

			if (Input.GetKeyDown(_forward))
			{
				_inputDispatcher.ForwardArrowDown(_playerId);
			}

			if (Input.GetKeyUp(_forward))
			{
				_inputDispatcher.ForwardArrowUp(_playerId);
			}

			if (Input.GetKeyDown(_down))
			{
				_inputDispatcher.DownArrowDown(_playerId);
			}

			if (Input.GetKeyUp(_down))
			{
				_inputDispatcher.DownArrowUp(_playerId);
			}

			if (Input.GetKeyDown(_fire))
			{
				_inputDispatcher.FireDown(_playerId);
			}

			if (Input.GetKeyDown(_fire))
			{
				_inputDispatcher.FireUp(_playerId);
			}
		}
	}
}