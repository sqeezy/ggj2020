using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using Random = System.Random;

public class Car
{
    private readonly Vector3 _stearingVector = new Vector3(0, 5, 0);
    public CarData Data { get; } = new CarData();
    public int PlayerId => Data.PlayerId;
    public Vector3 Position => Data.Position;
    public Quaternion Rotation => Data.Rotation;

    public void StearLeft()
    {
        Data.Rotation.SetFromToRotation(new Vector3(0, 0, 0), _stearingVector);
    }

    public void StearRight()
    {
        Data.Rotation.SetFromToRotation(new Vector3(0, 0, 0), -_stearingVector);
    }

    public void UpdatePosition(Vector3 newPosition)
    {
        Data.Position = newPosition;
    }
}

public class CarData
{
    private static readonly Random _rng = new Random();
    public int PlayerId { get; } = _rng.Next();
    public Vector3 Position { get; set; } = new Vector3();
    public Quaternion Rotation { get; } = new Quaternion();
}