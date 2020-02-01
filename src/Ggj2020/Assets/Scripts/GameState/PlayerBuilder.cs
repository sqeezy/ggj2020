﻿using System.Collections;
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
		_data = _diContainer.Instantiate<PlayerData>(new List<object>{playerId});
	}

	public PlayerConfiguration Configure()
	{
		_data.CarData = DefaultCarData();
		_carModel = new CarModel(_data.CarData);
		var carPresenter = _assetService.GetAssetInstance(AssetCatalogue.Car01).GetComponent<CarPresenter>();
		carPresenter.Init(_data.CarData);

		var pos = carPresenter.transform.position;
		var carView = carPresenter.gameObject.GetComponent<CarView>();
		carView.MainColor = _data.PlayerId == "0" ? Color.red : Color.green;

		carPresenter.transform.position = pos;
		_carModel.UpdatePosition(_data.CarData.Position);
		return this;
	}

	private static CarData DefaultCarData()
	{
		return new CarData {Weapon = Weapon.Projectile(), ArmorLevel = 0};
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