using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RunByF5
{
	[MenuItem("GameJameTools/RunGame _F5")]
	public static void  RunGame()
	{
		EditorApplication.EnterPlaymode();
	}
}