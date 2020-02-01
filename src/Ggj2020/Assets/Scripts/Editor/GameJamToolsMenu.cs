using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameJamToolsMenu
{
	[MenuItem("GameJameTools/RunGame _F5")]
	public static void RunGame()
	{
		EditorApplication.EnterPlaymode();
	}

	[MenuItem("GameJameTools/ExitGame #_F5")]
	public static void QuitGame()
	{
		EditorApplication.ExitPlaymode();
	}
}