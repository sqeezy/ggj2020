using UnityEngine;
using Random = System.Random;

public class CarData
{
	private static readonly Random Rng = new Random();
	public int PlayerId { get; } = Rng.Next();
	public Vector3 Position { get; set; }
	public Vector3 Rotation { get; set; }
	public float Velocity { get; set; }
	public CarAcceleration Acceleration { get; set; }
	public CarStearing Stearing { get; set; }
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
