using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using Zenject;

public class PlayerModel : ITickable
{
	private readonly SignalBus _signalBus;
	private readonly ArmorSystem _armorSystem;

	public readonly PlayerData PlayerData;
	private readonly CarModel _carModel;

	public PlayerModel(SignalBus signalBus, PlayerData data, ArmorSystem armorSystem)
	{
		_signalBus = signalBus;
		PlayerData = data;
		_armorSystem = armorSystem;
		_carModel = new CarModel(PlayerData.CarData);

		_signalBus.Subscribe<InputSignal.LeftArrowUp>(m => CheckPlayerAction(m, _carModel.StopStearLeft));
		_signalBus.Subscribe<InputSignal.LeftArrowDown>(m => CheckPlayerAction(m, _carModel.StartStearLeft));
		_signalBus.Subscribe<InputSignal.RightArrowUp>(m => CheckPlayerAction(m, _carModel.StopStearRight));
		_signalBus.Subscribe<InputSignal.RightArrowDown>(m => CheckPlayerAction(m, _carModel.StartStearRight));
		_signalBus.Subscribe<InputSignal.ForwardArrowDown>(m => CheckPlayerAction(m, _carModel.StartAccelerate));
		_signalBus.Subscribe<InputSignal.ForwardArrowUp>(m => CheckPlayerAction(m, _carModel.StopAccelerate));
		_signalBus.Subscribe<InputSignal.DownArrowDown>(m => CheckPlayerAction(m, _carModel.StartBreak));
		_signalBus.Subscribe<InputSignal.DownArrowUp>(m => CheckPlayerAction(m, _carModel.StopBreak));
		_signalBus.Subscribe<InputSignal.UpgradeArmor>(m => CheckPlayerAction(m, HandleUpgradeArmor));
	}

	private void HandleUpgradeArmor()
	{
		if (_armorSystem.CanUpgrade(PlayerData))
		{
			_armorSystem.Upgrade(PlayerData);
		}
	}

	public int Coins => PlayerData.Coins;
	public uint ArmorLevel => PlayerData.CarData.ArmorLevel;

	private void CheckPlayerAction(InputSignal signal, Action triggerAction)
	{
		if (PlayerData.PlayerId == signal.PlayerId)
		{
			triggerAction();
		}
	}

	public void Tick()
	{
		_carModel.Tick();
	}

	public void Pay(int amount)
	{
		PlayerData.SetCoins(PlayerData.Coins - amount);
	}

	public void UpgradeArmor(uint newArmorLevel)
	{
		PlayerData.CarData.SetArmorLevel(newArmorLevel);
	}
}