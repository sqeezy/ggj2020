using GenericProvider;
using UnityEngine;
using Zenject;

public class StartMenuPresenter : MonoBehaviour
{
    private SignalBus _signalBus;
    private URLReader _urlReader;
    private PlayerId _playerId;

    [Inject]
    public void Init(SignalBus signalBus, URLReader urlReader, PlayerId playerId)
    {
        _signalBus = signalBus;
        _urlReader = urlReader;
        _playerId = playerId;
    }

    public void GotoCoreGame()
    {
        if (_urlReader.AmIMaster())
        {
            _playerId.MakeMeMaster();
            // dummy event to inform comm server that we are master
            _signalBus.Fire((new InputSignal.IAmMaster(_playerId.Get()).ToNetwork()));
            _signalBus.Fire(new GameSignals.GotoStateSignal(typeof(CoreGameState)));
        }
        else
        {
            _signalBus.Fire(new GameSignals.GotoStateSignal(typeof(DriverUIState)));
        }
    }
}
