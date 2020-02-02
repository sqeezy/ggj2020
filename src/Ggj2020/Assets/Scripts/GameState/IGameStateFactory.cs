using System;

public interface IGameStateFactory
{
	IGameState Create<T>() where T : IGameState;
	IGameState Create(Type t);
}