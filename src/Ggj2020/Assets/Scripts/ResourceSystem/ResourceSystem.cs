using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ResourceSystem : ITickable
{
	private readonly ITimeProvider _timeProvider;
	private readonly GameModel _model;
	private const float ResourceAddTime = 2;
	private const int ResourcesPerStep = 200;

	private float _currentTime;

	public ResourceSystem(ITimeProvider timeProvider, GameModel model)
	{
		_timeProvider = timeProvider;
		_model = model;
		_currentTime = ResourceAddTime;
	}
	public void Tick()
	{
		_currentTime -= _timeProvider.DeltaTime;
		if (_currentTime <= 0)
		{
			_currentTime = ResourceAddTime + _currentTime;
			_model.AddResourceForAllPlayers(ResourcesPerStep);

		}

	}
}