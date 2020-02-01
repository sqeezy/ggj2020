using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerBuilder : IPlayerBuilder
{
	private readonly DiContainer _diContainer;

	public PlayerBuilder(DiContainer diContainer)
	{
		_diContainer = diContainer;
	}
	public PlayerConfiguration CreatePlayer(int playerId)
	{
		return new PlayerConfiguration(playerId, _diContainer);
	}
}

public class PlayerConfiguration
{
	private readonly DiContainer _diContainer;
	private PlayerData _data;
	private CarModel _carModel;

	public PlayerConfiguration(int playerId, DiContainer diContainer)
	{
		_diContainer = diContainer;
		_data = new PlayerData(playerId);
	}
	public PlayerConfiguration Configure()
	{
		_data.CarData = new CarData();
		_carModel = new CarModel(_data.CarData);
		
		return this;
	}

	public PlayerModel Build()
	{
		return _diContainer.Instantiate<PlayerModel>(new List<object>{_data});
	}
}

public interface IPlayerBuilder
{
	PlayerConfiguration CreatePlayer(int playerId);

}

