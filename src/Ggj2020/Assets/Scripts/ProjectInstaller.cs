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
		Container.DeclareSignal<InputSignal.LeftArrowUp>().OptionalSubscriber();
		Container.DeclareSignal<InputSignal.LeftArrowDown>().OptionalSubscriber();

		Container.DeclareSignal<InputSignal.RightArrowUp>().OptionalSubscriber();
		Container.DeclareSignal<InputSignal.RightArrowDown>().OptionalSubscriber();

		Container.DeclareSignal<InputSignal.ForwardArrowUp>().OptionalSubscriber();
		Container.DeclareSignal<InputSignal.ForwardArrowDown>().OptionalSubscriber();

		Container.DeclareSignal<InputSignal.DownArrowUp>().OptionalSubscriber();
		Container.DeclareSignal<InputSignal.DownArrowDown>().OptionalSubscriber();

		Container.DeclareSignal<InputSignal.IAmMaster>().OptionalSubscriber();
		Container.DeclareSignal<InputSignal.UpgradeArmor>().OptionalSubscriber();
		Container.DeclareSignal<InputSignal.FireDown>().OptionalSubscriber();
		Container.DeclareSignal<InputSignal.FireUp>().OptionalSubscriber();

		Container.DeclareSignal<GameSignals.PlayerActionTriggered>().OptionalSubscriber();
		Container.DeclareSignal<GameSignals.ChangeResourceSignal>().OptionalSubscriber();
		Container.DeclareSignal<GameSignals.GotoStateSignal>().OptionalSubscriber();

		Container.DeclareSignal<NetworkEvent>().OptionalSubscriber();
	}
}