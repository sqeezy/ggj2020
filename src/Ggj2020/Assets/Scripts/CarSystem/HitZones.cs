using System;

[Flags]
public enum HitZones
{
	LeftFront,
	RightFront,
	LeftBack,
	RightBack,
	All = int.MaxValue
}