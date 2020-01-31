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
		DeclareSignals();
	}

	private void DeclareSignals()
	{
		Container.DeclareSignal<InputSignals.LeftArrowUp>();
		Container.DeclareSignal<InputSignals.LeftArrowDown>();

		Container.DeclareSignal<InputSignals.RightArrowUp>();
		Container.DeclareSignal<InputSignals.RightArrowDown>();

		Container.DeclareSignal<InputSignals.ForwardArrowUp>();
		Container.DeclareSignal<InputSignals.ForwardArrowDown>();

		Container.DeclareSignal<InputSignals.DownArrowUp>();
		Container.DeclareSignal<InputSignals.DownArrowDown>();
	}
}