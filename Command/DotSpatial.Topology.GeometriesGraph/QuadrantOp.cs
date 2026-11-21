using System;

namespace DotSpatial.Topology.GeometriesGraph;

public class QuadrantOp
{
	private QuadrantOp()
	{
	}

	public static int Quadrant(double double_0, double double_1)
	{
		if (double_0 == 0.0 && double_1 == 0.0)
		{
			throw new ArgumentException("Cannot compute the quadrant for point ( " + double_0 + ", " + double_1 + " )");
		}
		if (double_0 < 0.0)
		{
			if (double_1 < 0.0)
			{
				return 2;
			}
			return 1;
		}
		if (double_1 < 0.0)
		{
			return 3;
		}
		return 0;
	}

	public static int Quadrant(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		double num = coordinate_1.X - coordinate_0.X;
		double num2 = coordinate_1.Y - coordinate_0.Y;
		if (num == 0.0 && num2 == 0.0)
		{
			throw new ArgumentException("Cannot compute the quadrant for two identical points " + (object)coordinate_0);
		}
		return Quadrant(num, num2);
	}

	public static bool IsOpposite(int int_0, int int_1)
	{
		if (int_0 == int_1)
		{
			return false;
		}
		if ((int_0 - int_1 + 4) % 4 == 2)
		{
			return true;
		}
		return false;
	}

	public static int CommonHalfPlane(int int_0, int int_1)
	{
		if (int_0 == int_1)
		{
			return int_0;
		}
		if ((int_0 - int_1 + 4) % 4 == 2)
		{
			return -1;
		}
		int num = ((int_0 < int_1) ? int_0 : int_1);
		int num2 = ((int_0 <= int_1) ? int_1 : int_0);
		if (num == 0 && num2 == 3)
		{
			return 3;
		}
		return num;
	}

	public static bool IsInHalfPlane(int int_0, int int_1)
	{
		if (int_1 == 3)
		{
			if (int_0 == 3)
			{
				return true;
			}
			return int_0 == 0;
		}
		if (int_0 == int_1)
		{
			return true;
		}
		return int_0 == int_1 + 1;
	}

	public static bool IsNorthern(int int_0)
	{
		if (int_0 == 0)
		{
			return true;
		}
		return int_0 == 1;
	}
}
