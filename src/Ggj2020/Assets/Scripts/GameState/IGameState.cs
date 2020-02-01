using System.Collections;

public interface IGameState
{
	IEnumerator Load();
	IEnumerator Enter();
	IEnumerator Exit();
	IEnumerator Unload();
}