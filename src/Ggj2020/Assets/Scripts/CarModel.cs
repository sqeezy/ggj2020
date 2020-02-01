using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditor;
using UnityEngine;

public class CarModel
{
	private readonly CarData _data;

	private readonly Vector3 _stearingVector = new Vector3(0, 0, 5f);
	private float _velocityChange = 0.01f;
	private readonly Vector3 _forward = new Vector3(1, 0, 0);

	public int PlayerId => _data.PlayerId;
	public Vector3 Position => _data.Position;
	public Vector3 Rotation => _data.Rotation;

	public CarModel(CarData data)
	{
		_data = data;
	}

	public void StartStearLeft()
	{
		_data.Stearing = CarStearing.Left;
	}

	public void StartStearRight()
	{
		_data.Stearing = CarStearing.Right;
	}

	public void StopStearLeft()
	{
		InvalidateStearing(CarStearing.Left);
	}

	public void StopStearRight()
	{
		InvalidateStearing(CarStearing.Right);
	}

	public void StartAccelerate()
	{
		_data.Acceleration = CarAcceleration.Forward;
	}

	public void StopAccelerate()
	{
		InvalidateAcceleration(CarAcceleration.Forward);
	}

	public void StartBreak()
	{
		_data.Acceleration = CarAcceleration.Backward;
	}

	public void StopBreak()
	{
		InvalidateAcceleration(CarAcceleration.Backward);
	}

	private void InvalidateAcceleration(CarAcceleration carAcceleration)
	{
		if (_data.Acceleration == carAcceleration)
		{
			_data.Acceleration = CarAcceleration.None;
		}
	}

	private void InvalidateStearing(CarStearing carStearing)
	{
		if (_data.Stearing == carStearing)
		{
			_data.Stearing = CarStearing.None;
		}
	}

	private void Rotate(Vector3 stearingVector)
	{
		var angles = _data.Rotation;
		var newAngles = angles + stearingVector;
		_data.Rotation = newAngles;
	}


	public void UpdatePosition(Vector3 newPosition)
	{
		_data.Position = newPosition;
	}

	public void UpdateRotation(Quaternion transformRotation)
	{
		_data.Rotation = transformRotation.eulerAngles;
	}

	public void Tick()
	{
		ApplyStearing();
		UpdateAcceleration();
		ApplyAcceleration();
	}

	private void ApplyAcceleration()
	{
		var rotation = Quaternion.Euler(0, 0, _data.Rotation.z);
		_data.Position += _data.Velocity  * (rotation * _forward);
	}

	private void UpdateAcceleration()
	{
		switch (_data.Acceleration)
		{
			case CarAcceleration.None:
				_data.Velocity *= 0.99f;
				break;
			case CarAcceleration.Forward:
				_data.Velocity += _velocityChange;
				break;
			case CarAcceleration.Backward:
				_data.Velocity -= _velocityChange;
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	private void ApplyStearing()
	{
		switch (_data.Stearing)
		{
			case CarStearing.Left:
				Rotate(-_stearingVector);
				break;
			case CarStearing.Right:
				Rotate(_stearingVector);
				break;
			case CarStearing.None:
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}
}