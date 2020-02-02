using GenericProvider;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace DriverInterface
{
	public class LeftButton : TouchyButton
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
			_signalBus.Fire(new InputSignal.LeftArrowDown(_playerId.Get()).ToNetwork());
		}

		protected override void up()
		{
			_signalBus.Fire(new InputSignal.LeftArrowUp(_playerId.Get()).ToNetwork());
		}
	}
}