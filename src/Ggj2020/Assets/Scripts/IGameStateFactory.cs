public interface IGameStateFactory
{
	IGameState Create<T>() where T : IGameState;
}