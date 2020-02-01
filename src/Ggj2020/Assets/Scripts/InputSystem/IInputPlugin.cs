using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Input plugins are called on each tick.
/// </summary>
public interface IInputPlugin
{
	void CheckInput();
}