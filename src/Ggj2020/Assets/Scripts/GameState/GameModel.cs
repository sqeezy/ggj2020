using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameModel
{
	private readonly SignalBus _signalBus;
	private readonly IPlayerBuilder _playerBuilder;
	private Dictionary<int, PlayerModel> _registeredPlayers = new Dictionary<int, PlayerModel>();

	public GameModel(SignalBus signalBus, IPlayerBuilder playerBuilder)
	{
		_signalBus = signalBus;
		_playerBuilder = playerBuilder;
		
	}

	public void Activate()
	{
		_signalBus.Subscribe<GameSignals.PlayerActionTriggered>(m => UpdatePlayerList(m.PlayerId));
	}

	public void UpdatePlayerList(int playerId)
	{
		if (!_registeredPlayers.ContainsKey(playerId))
		{
			var player = _playerBuilder.CreatePlayer(playerId).Configure().Build();
			_registeredPlayers.Add(playerId, player);
		}
	}
}