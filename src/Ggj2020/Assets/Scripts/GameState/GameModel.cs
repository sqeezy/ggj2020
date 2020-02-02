using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;
using Zenject;

public class GameModel : ITickable
{
	private readonly SignalBus _signalBus;
	private readonly IPlayerBuilder _playerBuilder;
	private Dictionary<string, PlayerModel> _registeredPlayers = new Dictionary<string, PlayerModel>();

	public GameModel(SignalBus signalBus, IPlayerBuilder playerBuilder)
	{
		_signalBus = signalBus;
		_playerBuilder = playerBuilder;
		
	}

	public static Vector3 CameraPosition { get; set; }

	public void Activate()
	{
		_signalBus.Subscribe<GameSignals.PlayerActionTriggered>(m => UpdatePlayerList(m.PlayerId));
	}

	public void UpdatePlayerList(string playerId)
	{
		if (!_registeredPlayers.ContainsKey(playerId))
		{
			var player = _playerBuilder.CreatePlayer(playerId).Configure().Build();
			_registeredPlayers.Add(playerId, player);
		}
	}

	public void Tick()
	{
		foreach (PlayerModel model in _registeredPlayers.Values)
		{
			model.Tick();
		}
	}

	public IEnumerable<PlayerModel> GetOrderedPlayers() =>
		_registeredPlayers.Values.OrderByDescending(l => l.PlayerData.CarData.Position.y);

	public void AddResourceForAllPlayers(int resources)
	{
		foreach (var registeredPlayer in _registeredPlayers)
		{
			_signalBus.Fire(new GameSignals.ChangeResourceSignal(registeredPlayer.Value.PlayerData.PlayerId, resources) );
		}
	}
}