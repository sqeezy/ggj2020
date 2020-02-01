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
		Container.DeclareSignal<InputSignal.LeftArrowUp>();
		Container.DeclareSignal<InputSignal.LeftArrowDown>();

		Container.DeclareSignal<InputSignal.RightArrowUp>();
		Container.DeclareSignal<InputSignal.RightArrowDown>();

		Container.DeclareSignal<InputSignal.ForwardArrowUp>();
		Container.DeclareSignal<InputSignal.ForwardArrowDown>();

		Container.DeclareSignal<InputSignal.DownArrowUp>();
		Container.DeclareSignal<InputSignal.DownArrowDown>();
	}
}