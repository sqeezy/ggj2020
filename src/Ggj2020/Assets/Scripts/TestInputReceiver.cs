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
		bus.Subscribe<InputSignals.LeftArrowUpSignal>(m => UpdateText(m.PlayerId,"LeftArrowUp"));
		bus.Subscribe<InputSignals.LeftArrowDownSignal>(m => UpdateText(m.PlayerId, "LeftArrowDown"));
		bus.Subscribe<InputSignals.RightArrowUpSignal>(m => UpdateText(m.PlayerId,"RightArrowUp"));
		bus.Subscribe<InputSignals.RightArrowDownSignal>(m => UpdateText(m.PlayerId,"RightArrowDown"));
		bus.Subscribe<InputSignals.ForwardArrowDown>(m => UpdateText(m.PlayerId,"ForwardArrowDown"));
		bus.Subscribe<InputSignals.ForwardArrowUp>(m => UpdateText(m.PlayerId,"ForwardArrowUp"));
		
	}

	private void UpdateText(int playerId, string text)
	{
		TextToShow.text = string.Format("Key: {0}, Player: {1}", text, playerId) ;
	}
}