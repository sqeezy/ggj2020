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
		DeclareSignals();
	}

	private void DeclareSignals()
	{
		Container.DeclareSignal<InputSignal.LeftArrowUp>();
		Container.DeclareSignal<InputSignal.LeftArrowDown>();

		Container.DeclareSignal<InputSignal.RightArrowUp>();
		Container.DeclareSignal<InputSignal.RightArrowDown>();

		Container.DeclareSignal<InputSignal.ForwardArrowUp>();
		Container.DeclareSignal<InputSignal.ForwardArrowDown>();

		Container.DeclareSignal<InputSignal.DownArrowUp>();
		Container.DeclareSignal<InputSignal.DownArrowDown>();

		Container.DeclareSignal<GameSignals.PlayerActionTriggered>();
	}
}