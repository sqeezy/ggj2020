using System;
using System.Data.Common;
using CarSystem;
using UnityEngine;
using Random = System.Random;

public class CarData
{
	public Vector3 Position;
	public float Velocity;
	public float RotationVelocity;
	public CarAcceleration Acceleration;
	public CarStearing Stearing;
	public int ArmorLevel;
	public WeaponData WeaponData;

	public event Action DataChanged = () => { };
	private static readonly Random Rng = new Random();
	public int PlayerId { get; } = Rng.Next();

	public void SetPosition(Vector3 newPosition)
	{
		Position = newPosition;
		DataChanged();
	}

	public void SetRotationVelocity(float newRotationVelocity)
	{
		RotationVelocity = newRotationVelocity;
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

	public void SetArmorLevel(int armor)
	{
		ArmorLevel = armor;
		DataChanged();
	}

	public void Reset()
	{
	}
}