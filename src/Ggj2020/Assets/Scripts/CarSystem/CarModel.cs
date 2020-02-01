using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditor;
using UnityEngine;

public class CarModel
{
	private readonly CarData _data;

	private const float StearingFactor = 180f;
	private const float VelocityChange = 10f;
	public static  readonly Vector3 Forward = Vector3.up;

	public int PlayerId => _data.PlayerId;
	public Vector3 Position => _data.Position;

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

	private void UpdateRotationVelocity(float stearingDelta)
	{
		_data.RotationVelocity = (_data.RotationVelocity + stearingDelta) % 360;
	}

	public void UpdatePosition(Vector3 newPosition)
	{
		_data.Position = newPosition;
	}

	public void Tick()
	{
		ApplyStearing();
		UpdateVelocity();
		ApplyAcceleration();
	}

	private void ApplyAcceleration()
	{
		var rotation = Quaternion.Euler(0, 0, _data.RotationVelocity);
		_data.Position += _data.Velocity * (rotation * Forward);
	}

	private void UpdateVelocity()
	{
		switch (_data.Acceleration)
		{
			case CarAcceleration.None:
				_data.Velocity *= 0.99f;
				break;
			case CarAcceleration.Forward:
				_data.Velocity += VelocityChange;
				break;
			case CarAcceleration.Backward:
				_data.Velocity -= VelocityChange;
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	private void ApplyStearing()
	{
		switch (_data.Stearing)
		{
			case CarStearing.None:
				UpdateRotationVelocity(-_data.RotationVelocity * 0.999f);
				break;
			case CarStearing.Left:
				UpdateRotationVelocity(-StearingFactor);
				break;
			case CarStearing.Right:
				UpdateRotationVelocity(StearingFactor);
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}
}