using System.Collections;
using System.Collections.Generic;
using CarSystem;
using UnityEngine;
using Zenject;

public class PlayerBuilder : IPlayerBuilder
{
	private readonly DiContainer _diContainer;

	public PlayerBuilder(DiContainer diContainer)
	{
		_diContainer = diContainer;
	}

	public PlayerConfiguration CreatePlayer(string playerId)
	{
		return _diContainer.Instantiate<PlayerConfiguration>(new List<object> {playerId});
	}
}

public class PlayerConfiguration
{
	private readonly DiContainer _diContainer;
	private readonly IAssetService _assetService;
	private PlayerData _data;
	private CarModel _carModel;


	public PlayerConfiguration(DiContainer diContainer, IAssetService assetService, string playerId)
	{
		_diContainer = diContainer;
		_assetService = assetService;
		_data = new PlayerData(playerId);
	}

	public PlayerConfiguration Configure()
	{
		_data.CarData = DefaultCarData();
		_carModel = new CarModel(_data.CarData);
		var carPresenter = _assetService.GetAssetInstance(AssetCatalogue.Car01).GetComponent<CarPresenter>();
		carPresenter.Init(_data.CarData);

		var pos = carPresenter.transform.position;

		carPresenter.transform.position = pos;
		_carModel.UpdatePosition(_data.CarData.Position);
		return this;
	}

	private static CarData DefaultCarData()
	{
		return new CarData {Weapon = Weapon.Projectile(), ArmorState = Armor.All};
	}

	public PlayerModel Build()
	{
		return _diContainer.Instantiate<PlayerModel>(new List<object> {_data});
	}
}

public interface IPlayerBuilder
{
	PlayerConfiguration CreatePlayer(string playerId);
}