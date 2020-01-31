using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using Random = System.Random;

public class Car
{
	private readonly Vector3 _stearingVector = new Vector3(0, 1.5f, 0);
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
		}
	}
}

public enum CarStearing
{
	None,
	Left,
	Right
}

public enum CarAcceleration
{
	None,
	Forward,
	Backward
}

public class CarData
{
	private static readonly Random _rng = new Random();
	public int PlayerId { get; } = _rng.Next();
	public Vector3 Position { get; set; }
	public Vector3 Rotation { get; set; }
	public CarAcceleration Acceleration { get; set; }
	public CarStearing Stearing { get; set; }
}