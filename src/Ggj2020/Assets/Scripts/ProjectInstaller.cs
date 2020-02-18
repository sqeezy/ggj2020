using GenericProvider;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		SignalBusInstaller.Install(Container);
		Container.Bind<IInputDispatcher>().To<InputDispatcher>().AsSingle();
		Container.Bind<IInputPlugin>().To<KeyboardInputPlugin>().AsSingle();
		Container.Bind<ITickable>().To<InputService>().AsSingle();
		//Container.Bind<IAssetService>().To<AssetService>().AsSingle();
		Container.Bind<IAssetService>().To<ResourcesAssetLoader>().AsSingle();
		Container.Bind<CoroutineProvider>().FromNewComponentOnNewGameObject().AsSingle();
		Container.Bind<IGameStateFactory>().To<GameStateFactory>().AsSingle();
		Container.Bind<ITimeProvider>().To<TimeProvider>().AsSingle();
		Container.Bind<WebSocketService>().AsSingle();
		Container.BindInterfacesAndSelfTo<MainThreadQueue>().AsSingle();
		Container.Bind<PlayerId>().AsSingle();
		Container.Bind<URLReader>().AsSingle();
		Container.Bind<ArmorSystem>().AsSingle();
		Container.Bind<ITickable>().To<ResourceSystem>().AsSingle();
		Container.BindInterfacesAndSelfTo<GameModel>().AsSingle();
		Container.Bind<IPlayerBuilder>().To<PlayerBuilder>().AsSingle();
		DeclareSignals();
	}

	private void DeclareSignals()
	{
		Container.DeclareSignal<PlayerSignal.LeftArrowUp>().OptionalSubscriber();
		Container.DeclareSignal<PlayerSignal.LeftArrowDown>().OptionalSubscriber();

		Container.DeclareSignal<PlayerSignal.RightArrowUp>().OptionalSubscriber();
		Container.DeclareSignal<PlayerSignal.RightArrowDown>().OptionalSubscriber();

		Container.DeclareSignal<PlayerSignal.ForwardArrowUp>().OptionalSubscriber();
		Container.DeclareSignal<PlayerSignal.ForwardArrowDown>().OptionalSubscriber();

		Container.DeclareSignal<PlayerSignal.DownArrowUp>().OptionalSubscriber();
		Container.DeclareSignal<PlayerSignal.DownArrowDown>().OptionalSubscriber();

		Container.DeclareSignal<PlayerSignal.IAmMaster>().OptionalSubscriber();
		Container.DeclareSignal<PlayerSignal.UpgradeArmor>().OptionalSubscriber();
		Container.DeclareSignal<PlayerSignal.FireDown>().OptionalSubscriber();
		Container.DeclareSignal<PlayerSignal.FireUp>().OptionalSubscriber();
		
		Container.DeclareSignal<GameSignals.AddPlayerCam>().OptionalSubscriber();
		Container.DeclareSignal<GameSignals.PlayerActionTriggered>().OptionalSubscriber();
		Container.DeclareSignal<GameSignals.ChangeResourceSignal>().OptionalSubscriber();
		Container.DeclareSignal<GameSignals.GotoStateSignal>().OptionalSubscriber();

		Container.DeclareSignal<NetworkEvent>().OptionalSubscriber();
	}
}