using UnityEngine;
using Zenject;

public interface ITimeProvider
{
	float DeltaTime { get; }
}

class TimeProvider : ITimeProvider
{
	public float DeltaTime => Time.deltaTime;
}