using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<IInitializable>().To<Main>().AsSingle();
	}
}