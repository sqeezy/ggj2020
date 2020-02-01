using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TestInputReceiver : MonoBehaviour
{
	[SerializeField] private Text TextToShow;
	[Inject]
	public void Init(SignalBus bus)
	{
		bus.Subscribe<InputSignal.LeftArrowUp>(m => UpdateText(m.PlayerId,"LeftArrowUp"));
		bus.Subscribe<InputSignal.LeftArrowDown>(m => UpdateText(m.PlayerId, "LeftArrowDown"));
		bus.Subscribe<InputSignal.RightArrowUp>(m => UpdateText(m.PlayerId,"RightArrowUp"));
		bus.Subscribe<InputSignal.RightArrowDown>(m => UpdateText(m.PlayerId,"RightArrowDown"));
		bus.Subscribe<InputSignal.ForwardArrowDown>(m => UpdateText(m.PlayerId,"ForwardArrowDown"));
		bus.Subscribe<InputSignal.ForwardArrowUp>(m => UpdateText(m.PlayerId,"ForwardArrowUp"));
		
	}

	private void UpdateText(int playerId, string text)
	{
		TextToShow.text = string.Format("Key: {0}, Player: {1}", text, playerId) ;
	}
}