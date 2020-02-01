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
		Container.Bind<IAssetService>().To<AssetService>().AsSingle();
		Container.Bind<CoroutineProvider>().FromNewComponentOnNewGameObject().AsSingle();
		Container.Bind<IGameStateFactory>().To<GameStateFactory>().AsSingle();
		Container.Bind<IInitializable>().To<Main>().AsSingle();
		Container.BindInterfacesAndSelfTo<GameModel>().AsSingle();
		Container.Bind<IPlayerBuilder>().To<PlayerBuilder>().AsSingle();
		Container.Bind<ITimeProvider>().To<TimeProvider>().AsSingle();
		Container.Bind<WebSocketService>().AsSingle();
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

		Container.DeclareSignal<GameSignals.PlayerActionTriggered>().OptionalSubscriber();
	}
}