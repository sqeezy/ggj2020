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
	public CarAcceleration Acceleration;
	public CarStearing Stearing;
	public float RotationVelocity;
	public int PlayerId { get; } = Rng.Next();

	public void SetPosition(Vector3 newPosition)
	{
		Position = newPosition;
		DataChanged();
	}

	public void SetRotationVelocity(float newRotVelo)
	{
		RotationVelocity = newRotVelo;
		DataChanged();
	}

	public void SetVelocity(float newVelocity)
	{
		Velocity = newVelocity;
		DataChanged();
	}

	public void SetAcceleration(CarAcceleration newAcceleration)
	{
		Acceleration = newAcceleration;
		DataChanged();
	}

	public void SetStearing(CarStearing newStearing)
	{
		Stearing = newStearing;
		DataChanged();
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