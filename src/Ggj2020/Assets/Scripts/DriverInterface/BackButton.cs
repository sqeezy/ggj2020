using System.Collections.Generic;
using GenericProvider;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace DriverInterface
{
	public class BackButton : TouchyButton
	{
		private SignalBus _signalBus;
		private PlayerId _playerId;

		[Inject]
		public void Init(SignalBus signalBus, PlayerId playerId)
		{
			_signalBus = signalBus;
			_playerId = playerId;
		}

		protected override void down()
		{
			_signalBus.Fire(new InputSignal.DownArrowDown(_playerId.Get()).ToNetwork());
		}

		protected override void up()
		{
			_signalBus.Fire(new InputSignal.DownArrowUp(_playerId.Get()).ToNetwork());
		}
	}
}