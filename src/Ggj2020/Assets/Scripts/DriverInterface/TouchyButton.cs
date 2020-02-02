using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DriverInterface
{
	public abstract class
		TouchyButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
	{
		protected abstract void down();

		protected abstract void up();

		public void OnPointerEnter(PointerEventData eventData)
		{
			down();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			up();
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			down();
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			up();
		}
	}
}