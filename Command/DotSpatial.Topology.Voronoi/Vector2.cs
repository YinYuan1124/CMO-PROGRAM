using System;

namespace DotSpatial.Topology.Voronoi;

public struct Vector2
{
	public static double Tolerance;

	public readonly double X;

	public readonly double Y;

	public double SquaredLength => this * this;

	public Vector2(double[] double_0, int int_0)
	{
		X = double_0[int_0];
		Y = double_0[int_0 + 1];
	}

	public Vector2(params double[] x)
	{
		X = x[0];
		Y = x[1];
	}

	public Coordinate ToCoordinate()
	{
		return new Coordinate(X, Y);
	}

	public bool ContainsNan()
	{
		if (double.IsNaN(X))
		{
			return true;
		}
		if (double.IsNaN(Y))
		{
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		return "(" + X + "," + Y + ")";
	}

	public override bool Equals(object obj)
	{
		Vector2 vector = (Vector2)obj;
		if (InvokeRule(X, vector.X))
		{
			return InvokeRule(Y, vector.Y);
		}
		return false;
	}

	public double Distance(Vector2 vector2_0)
	{
		double num = X - vector2_0.X;
		double num2 = Y - vector2_0.Y;
		return Math.Sqrt(num * num + num2 * num2);
	}

	private static bool InvokeRule(double double_0, double double_1)
	{
		if (double.IsNaN(double_0) && double.IsNaN(double_1))
		{
			return true;
		}
		if (!double.IsNaN(double_0) && !double.IsNaN(double_1))
		{
			if (Tolerance == 0.0)
			{
				return double_0 == double_1;
			}
			return Math.Abs(double_0 - double_1) <= Tolerance;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return X.GetHashCode() * Y.GetHashCode();
	}

	public static double operator *(Vector2 vector2_0, Vector2 vector2_1)
	{
		return vector2_0.X * vector2_1.X + vector2_0.Y * vector2_1.Y;
	}

	public static bool operator ==(Vector2 vector2_0, Vector2 vector2_1)
	{
		return vector2_0.Equals(vector2_1);
	}

	public static bool operator !=(Vector2 vector2_0, Vector2 vector2_1)
	{
		return !vector2_0.Equals(vector2_1);
	}

	public static Vector2 operator +(Vector2 vector2_0, Vector2 vector2_1)
	{
		return new Vector2(vector2_0.X + vector2_1.X, vector2_0.Y + vector2_1.Y);
	}

	public static Vector2 operator -(Vector2 vector2_0, Vector2 vector2_1)
	{
		return new Vector2(vector2_0.X - vector2_1.X, vector2_0.Y - vector2_1.Y);
	}

	public static Vector2 operator *(Vector2 vector2_0, double double_0)
	{
		return new Vector2(vector2_0.X * double_0, vector2_0.Y * double_0);
	}

	public static Vector2 operator *(double double_0, Vector2 vector2_0)
	{
		return new Vector2(vector2_0.X * double_0, vector2_0.Y * double_0);
	}
}
