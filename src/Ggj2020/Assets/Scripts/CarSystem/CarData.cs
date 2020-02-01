using System;
using System.Data.Common;
using ModestTree.Util;
using UnityEngine;
using Random = System.Random;

public class CarData
{
	public event Action DataChanged = () => { };
	private static readonly Random Rng = new Random();
	private Vector3 _position;
	private Vector3 _rotationVelocity;
	private float _velocity;
	private CarAcceleration _acceleration;
	private CarStearing _stearing;
	private float _rotVelo;
	private Vector3 _rotation;
	public int PlayerId { get; } = Rng.Next();

	public Vector3 Position
	{
		get => _position;
		set
		{
			_position = value;
			DataChanged();
		}
	}

	public Vector3 Rotation
	{
		get => _rotation;
		set
		{
			_rotation = value;
			DataChanged();
		}
	}

	public Vector3 RotationVelocity
	{
		get => _rotationVelocity;
		set
		{
			_rotationVelocity = value;
			DataChanged();
		}
	}

	public float RotVelo
	{
		get => _rotVelo;
		set
		{
			_rotationVelocity.z = value;
			_rotationVelocity.x = 0;
			_rotationVelocity.y = 0;
			_rotVelo = value;
		}
	}

	public float Velocity
	{
		get => _velocity;
		set
		{
			_velocity = value;
			DataChanged();
		}
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