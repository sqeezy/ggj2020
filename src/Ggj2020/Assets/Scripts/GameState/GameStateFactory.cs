using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStateFactory : IGameStateFactory
{
	private readonly DiContainer _container;

	public GameStateFactory(DiContainer container)
	{
		_container = container;
	}

	public IGameState Create<T>() where T : IGameState
	{
		return _container.Instantiate<T>();
	}
	
	public IGameState Create(Type t)
	{
		return _container.Instantiate(t) as IGameState;
	}
}