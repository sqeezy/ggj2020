using System;
using System.Data.Common;
using ModestTree.Util;
using UnityEngine;
using Random = System.Random;

public class CarData
{
	public event Action DataChanged = () => { };
	private static readonly Random Rng = new Random();
	public Vector3 Position;
	public float Velocity;
	public CarAcceleration _acceleration;
	public CarStearing _stearing;
	public float _rotationVelocity;
	public int PlayerId { get; } = Rng.Next();

	public void SetPosition(Vector3 newPosition)
	{
		Position = newPosition;
		DataChanged();
	}

	public float RotationVelocity
	{
		get => _rotationVelocity;
		set
		{
			_rotationVelocity = value;
			DataChanged();
		}
	}

	public void SetVelocity(float newVelocity)
	{
		Velocity = newVelocity;
		DataChanged();
	}

	public CarAcceleration Acceleration
	{
		get => _acceleration;
		set
		{
			_acceleration = value;
			DataChanged();
		}
	}

	public CarStearing Stearing
	{
		get => _stearing;
		set
		{
			_stearing = value;
			DataChanged();
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