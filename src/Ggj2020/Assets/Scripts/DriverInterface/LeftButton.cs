using GenericProvider;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace DriverInterface
{
	public class LeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		private SignalBus _signalBus;
		private PlayerId _playerId;
		
		[Inject]
		public void Init(SignalBus signalBus, PlayerId playerId)
		{
			_signalBus = signalBus;
			_playerId = playerId;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			_signalBus.Fire(new InputSignal.LeftArrowDown(_playerId.Get()).ToNetwork());
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			_signalBus.Fire(new InputSignal.LeftArrowUp(_playerId.Get()).ToNetwork());
		}
	}
}