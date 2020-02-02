using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Main : IInitializable
{
	private readonly CoroutineProvider _coroutineProvider;
	private readonly IGameStateFactory _gameStateFactory;
	private readonly SignalBus _signalBus;
	private IGameState _mainState;
	private IGameState _initGameState;
	private IGameState _activeState;

	public Main(CoroutineProvider coroutineProvider, IGameStateFactory gameStateFactory, SignalBus signalBus)
	{
		_coroutineProvider = coroutineProvider;
		_gameStateFactory = gameStateFactory;
		_signalBus = signalBus;
		_initGameState = _gameStateFactory.Create<InitGameState>();
		_signalBus.Subscribe<GameSignals.GotoStateSignal>(m => TriggerStateSwitch(m));
	}

	private void TriggerStateSwitch(GameSignals.GotoStateSignal gotoStateSignal)
	{
		var targetState = _gameStateFactory.Create(gotoStateSignal.TargetType);
		_coroutineProvider.StartCoroutine(GotoState(targetState));
	}

	public void Initialize()
	{
		_coroutineProvider.StartCoroutine(InitGame());
	}

	public IEnumerator InitGame()
	{
		yield return GotoState(_initGameState);
		yield return GotoState(_gameStateFactory.Create<MainMenuState>());
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
