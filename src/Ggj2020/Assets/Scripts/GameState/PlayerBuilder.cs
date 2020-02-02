using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
	private static readonly Color[] ColorCycle =
	{
		Color.blue, Color.magenta, Color.red, Color.green, Color.cyan, Color.yellow, Color.black, Color.white,
		Color.gray,
	};

	private static IEnumerable<T> RepeatTimes<T>(IEnumerable<T> input, int n)
	{
		return Enumerable.Range(0, n).Select(_ => input).SelectMany(l => l);
	}

	private static readonly Queue<Color> _colors = new Queue<Color>(RepeatTimes(ColorCycle, 100));
	private readonly DiContainer _diContainer;
	private readonly IAssetService _assetService;
	private PlayerData _data;
	private CarModel _carModel;


	public PlayerConfiguration(DiContainer diContainer, IAssetService assetService, string playerId)
	{
		_diContainer = diContainer;
		_assetService = assetService;
		_data = _diContainer.Instantiate<PlayerData>(new List<object> {playerId});
	}

	public PlayerConfiguration Configure()
	{
		_data.CarData = DefaultCarData();
		_carModel = new CarModel(_data.CarData);
		var carInstance = _assetService.GetAssetInstance(AssetCatalogue.Car01);
		var carPresenter = carInstance.GetComponent<CarPresenter>();
		carPresenter.Init(_data.CarData);

		var weaponPresenter = carInstance.GetComponent<WeaponPresenter>();
		weaponPresenter.Init(_data.CarData.WeaponData);
		var pos = carPresenter.transform.position;
		var carView = carPresenter.gameObject.GetComponent<CarView>();
		carView.MainColor = _colors.Dequeue();

		carPresenter.transform.position = pos;
		_carModel.UpdatePosition(_data.CarData.Position);
		return this;
	}

	private static CarData DefaultCarData()
	{
		return new CarData {WeaponData = WeaponData.Single(), ArmorLevel = 0};
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