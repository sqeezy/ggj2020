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
		bus.Subscribe<InputSignals.LeftArrowUp>(m => UpdateText(m.PlayerId,"LeftArrowUp"));
		bus.Subscribe<InputSignals.LeftArrowDown>(m => UpdateText(m.PlayerId, "LeftArrowDown"));
		bus.Subscribe<InputSignals.RightArrowUp>(m => UpdateText(m.PlayerId,"RightArrowUp"));
		bus.Subscribe<InputSignals.RightArrowDown>(m => UpdateText(m.PlayerId,"RightArrowDown"));
		bus.Subscribe<InputSignals.ForwardArrowDown>(m => UpdateText(m.PlayerId,"ForwardArrowDown"));
		bus.Subscribe<InputSignals.ForwardArrowUp>(m => UpdateText(m.PlayerId,"ForwardArrowUp"));
		
	}

	private void UpdateText(int playerId, string text)
	{
		TextToShow.text = string.Format("Key: {0}, Player: {1}", text, playerId) ;
	}
}