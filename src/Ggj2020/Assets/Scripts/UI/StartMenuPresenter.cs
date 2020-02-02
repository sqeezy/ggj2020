using UnityEngine;
using Zenject;

public class StartMenuPresenter : MonoBehaviour
{
    private SignalBus _signalBus;

    [Inject]
    public void Init(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    public void GotoCoreGame()
    {
        _signalBus.Fire(new GameSignals.GotoStateSignal(typeof(CoreGameState)));
    }
}
