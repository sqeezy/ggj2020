using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditor;
using UnityEngine;

public class Car
{
	private readonly Vector3 _stearingVector = new Vector3(0, 1.5f, 0);
	private float _velocityChange = 0.01f;
	private readonly Vector3 _forward = new Vector3(0, 0, 1);
	private CarData Data { get; } = new CarData();
	public int PlayerId => Data.PlayerId;
	public Vector3 Position => Data.Position;
	public Vector3 Rotation => Data.Rotation;

	public void StartStearLeft()
	{
		Data.Stearing = CarStearing.Left;
	}

	public void StartStearRight()
	{
		Data.Stearing = CarStearing.Right;
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
		Data.Acceleration = CarAcceleration.Forward;
	}

	public void StopAccelerate()
	{
		InvalidateAcceleration(CarAcceleration.Forward);
	}

	public void StartBreak()
	{
		Data.Acceleration = CarAcceleration.Backward;
	}

	public void StopBreak()
	{
		InvalidateAcceleration(CarAcceleration.Backward);
	}

	private void InvalidateAcceleration(CarAcceleration carAcceleration)
	{
		if (Data.Acceleration == carAcceleration)
		{
			Data.Acceleration = CarAcceleration.None;
		}
	}

	private void InvalidateStearing(CarStearing carStearing)
	{
		if (Data.Stearing == carStearing)
		{
			Data.Stearing = CarStearing.None;
		}
	}

	private void Rotate(Vector3 stearingVector)
	{
		var angles = Data.Rotation;
		var newAngles = angles + stearingVector;
		Data.Rotation = newAngles;
	}


	public void UpdatePosition(Vector3 newPosition)
	{
		Data.Position = newPosition;
	}

	public void UpdateRotation(Quaternion transformRotation)
	{
		Data.Rotation = transformRotation.eulerAngles;
	}

	public void Tick()
	{
		ApplyStearing();
		UpdateAccelaration();
		ApplyAcceleration();
	}

	private void ApplyAcceleration()
	{
		var rotation = Quaternion.Euler(0, Data.Rotation.y, 0);
		Data.Position += Data.Velocity * (rotation * _forward);
	}

	private void UpdateAccelaration()
	{
		switch (Data.Acceleration)
		{
			case CarAcceleration.None:
				Data.Velocity *= 0.99f;
				break;
			case CarAcceleration.Forward:
				Data.Velocity += _velocityChange;
				break;
			case CarAcceleration.Backward:
				Data.Velocity -= _velocityChange;
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	private void ApplyStearing()
	{
		switch (Data.Stearing)
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
