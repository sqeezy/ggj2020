using System;

[Flags]
public enum Armor
{
	LeftFront,
	RightFront,
	LeftBack,
	RightBack,
	All = int.MaxValue
}