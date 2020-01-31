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
		Container.DeclareSignal<InputSignals.LeftArrowUpSignal>();
		Container.DeclareSignal<InputSignals.LeftArrowDownSignal>();
		Container.DeclareSignal<InputSignals.RightArrowUpSignal>();
		Container.DeclareSignal<InputSignals.RightArrowDownSignal>();
		Container.DeclareSignal<InputSignals.ForwardArrowUp>();
		Container.DeclareSignal<InputSignals.ForwardArrowDown>();
	}
}