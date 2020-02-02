using GenericProvider;
using UnityEngine;
using Zenject;

namespace DriverInterface
{
	public class Actions : MonoBehaviour
	{
		private SignalBus _signalBus;
		private PlayerId _playerId;

		[Inject]
		public void Init(SignalBus signalBus, PlayerId playerId)
		{
			_signalBus = signalBus;
			_playerId = playerId;
		}

		public void Shoot()
		{
			_signalBus.Fire(new InputSignal.FireDown(_playerId.Get()).ToNetwork());
		}

		public void Repair()
		{
			_signalBus.Fire(new InputSignal.UpgradeArmor(_playerId.Get()).ToNetwork());
		}
	}
}