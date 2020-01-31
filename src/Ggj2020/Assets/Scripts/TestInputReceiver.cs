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
		bus.Subscribe<InputSignals.LeftArrowUpSignal>(() => UpdateText("LeftArrowUp"));
		bus.Subscribe<InputSignals.LeftArrowDownSignal>(() => UpdateText("LeftArrowDown"));
		bus.Subscribe<InputSignals.RightArrowUpSignal>(() => UpdateText("RightArrowUp"));
		bus.Subscribe<InputSignals.RightArrowDownSignal>(() => UpdateText("RightArrowDown"));
		
	}

	private void UpdateText(string text)
	{
		TextToShow.text = text;
	}
}