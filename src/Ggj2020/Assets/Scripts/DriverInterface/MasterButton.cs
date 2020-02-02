using GenericProvider;
using UnityEngine;
using Zenject;

namespace DriverInterface
{
	public class MasterButton : MonoBehaviour
	{
		private SignalBus _signalBus;
		private PlayerId _playerId;

		[Inject]
		public void Init(SignalBus signalBus, PlayerId playerId)
		{
			_signalBus = signalBus;
			_playerId = playerId;
		}

		public void MakeMeMaster()
		{
			_playerId.MakeMeMaster();
			// dummy event to inform comm server that we are master
			_signalBus.Fire((new InputSignal.IAmMaster(_playerId.Get()).ToNetwork()));
		}
	}
}