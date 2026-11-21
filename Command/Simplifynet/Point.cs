using System;

namespace Simplifynet;

public sealed class Point : IEquatable<Point>
{
	public double X;

	public double Y;

	public double Z;

	public bool IsValid
	{
		get
		{
			if (X <= 90.0 && Y >= -90.0 && Y <= 180.0)
			{
				return X >= -180.0;
			}
			return false;
		}
	}

	public Point(double double_0, double double_1, double double_2 = 0.0)
	{
		X = double_0;
		Y = double_1;
		Z = double_2;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		if (!(obj.GetType() == typeof(Point)) && !(obj.GetType() == typeof(Point)))
		{
			return false;
		}
		return Equals(obj as Point);
	}

	public bool Equals(Point other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (other.X.Equals(X) && other.Y.Equals(Y))
		{
			return other.Z.Equals(Z);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (X.GetHashCode() * 397) ^ Y.GetHashCode() ^ Z.GetHashCode();
	}

	public override string ToString()
	{
		return $"{X} {Y} {Z}";
	}
}
