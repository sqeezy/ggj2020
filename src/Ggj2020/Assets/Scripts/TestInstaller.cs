using System.Collections;
using System.Collections.Generic;
using Zenject;

public class TestInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.BindInterfacesAndSelfTo<DummyStarter>().AsSingle();
	}
}

class DummyStarter : IInitializable
{
	private readonly GameModel _gameModel;
	private readonly CoroutineProvider _coroutineProvider;
	private readonly IAssetService _assetService;

	public DummyStarter(GameModel gameModel, CoroutineProvider coroutineProvider, IAssetService assetService)
	{
		_gameModel = gameModel;
		_coroutineProvider = coroutineProvider;
		_assetService = assetService;
	}
	public void Initialize()
	{
		_coroutineProvider.StartCoroutine(StartGame());
		_gameModel.Activate();
	}

	private IEnumerator StartGame()
	{
		yield return _assetService.LoadAsset(AssetCatalogue.Car01);
		yield return _assetService.LoadAsset(AssetCatalogue.Projectile);
	}
}