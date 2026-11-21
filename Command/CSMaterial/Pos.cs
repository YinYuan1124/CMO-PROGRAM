using System;
using System.Runtime.CompilerServices;

namespace CSMaterial;

public struct Pos : IEquatable<Pos>
{
	[CompilerGenerated]
	private int _SpecificationDispatcher;

	[CompilerGenerated]
	private int _WatcherDispatcher;

	public int X { get; private set; }

	public int Y { get; private set; }

	public Pos(int int_0, int int_1)
	{
		_SpecificationDispatcher = 0;
		_WatcherDispatcher = 0;
		X = int_0;
		Y = int_1;
	}

	public bool Equals(Pos other)
	{
		return X == other.X && Y == other.Y;
	}

	public override bool Equals(object obj)
	{
		return obj != null && obj is Pos && Equals((Pos)obj);
	}

	public override int GetHashCode()
	{
		return (X * 397) ^ Y;
	}

	public static bool operator ==(Pos pos_0, Pos pos_1)
	{
		return pos_0.Equals(pos_1);
	}

	public static bool operator !=(Pos pos_0, Pos pos_1)
	{
		return !pos_0.Equals(pos_1);
	}
}
