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
		bus.Subscribe<PlayerSignal.LeftArrowUp>(m => UpdateText(m.PlayerId,"LeftArrowUp"));
		bus.Subscribe<PlayerSignal.LeftArrowDown>(m => UpdateText(m.PlayerId, "LeftArrowDown"));
		bus.Subscribe<PlayerSignal.RightArrowUp>(m => UpdateText(m.PlayerId,"RightArrowUp"));
		bus.Subscribe<PlayerSignal.RightArrowDown>(m => UpdateText(m.PlayerId,"RightArrowDown"));
		bus.Subscribe<PlayerSignal.ForwardArrowDown>(m => UpdateText(m.PlayerId,"ForwardArrowDown"));
		bus.Subscribe<PlayerSignal.ForwardArrowUp>(m => UpdateText(m.PlayerId,"ForwardArrowUp"));
		
	}

	private void UpdateText(string playerId, string text)
	{
		TextToShow.text = string.Format("Key: {0}, Player: {1}", text, playerId) ;
	}
}