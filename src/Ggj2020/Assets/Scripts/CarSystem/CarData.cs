using System;
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
	public Armor ArmorState;
	public Weapon Weapon;

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

	public void SetArmorState(Armor all)
	{
		ArmorState = Armor.All;
		DataChanged();
	}
}