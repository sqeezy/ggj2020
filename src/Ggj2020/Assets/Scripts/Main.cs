using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Main : IInitializable
{
	private readonly CoroutineProvider _coroutineProvider;
	private readonly IGameStateFactory _gameStateFactory;
	private IGameState _mainState;
	private IGameState _initGameState;
	private IGameState _activeState;

	public Main(CoroutineProvider coroutineProvider, IGameStateFactory gameStateFactory)
	{
		_coroutineProvider = coroutineProvider;
		_gameStateFactory = gameStateFactory;
		_initGameState = _gameStateFactory.Create<InitGameState>();
		_mainState = _gameStateFactory.Create<CoreGameState>();
	}
	public void Initialize()
	{
		_coroutineProvider.StartCoroutine(InitGame());
	}

	public IEnumerator InitGame()
	{

		yield return GotoState(_initGameState);
		yield return GotoState(_mainState);
	}

	private IEnumerator GotoState(IGameState targetState)
	{
		if (_activeState != null)
		{
			yield return _activeState.Exit();
			yield return _activeState.Unload();
		}

		yield return targetState.Load();
		yield return targetState.Enter();
		_activeState = targetState;
	}

}
