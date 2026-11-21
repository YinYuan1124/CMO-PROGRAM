using System;

namespace DotSpatial.Topology.Algorithm;

public static class NonRobustCgAlgorithms
{
	public static bool IsPointInRing(Coordinate coordinate_0, Coordinate[] coordinate_1)
	{
		int num = 0;
		int num2 = coordinate_1.Length;
		for (int i = 1; i < num2; i++)
		{
			int num3 = i - 1;
			Coordinate obj = coordinate_1[i];
			Coordinate coordinate = coordinate_1[num3];
			double num4 = obj.X - coordinate_0.X;
			double num5 = obj.Y - coordinate_0.Y;
			double num6 = coordinate.X - coordinate_0.X;
			double num7 = coordinate.Y - coordinate_0.Y;
			if ((num5 > 0.0 && num7 <= 0.0) || (num7 > 0.0 && num5 <= 0.0))
			{
				double num8 = (num4 * num7 - num6 * num5) / (num7 - num5);
				if (0.0 < num8)
				{
					num++;
				}
			}
		}
		return num % 2 == 1;
	}

	public static bool IsCcw(Coordinate[] coordinate_0)
	{
		int num = coordinate_0.Length - 1;
		if (num < 4)
		{
			return false;
		}
		Coordinate coordinate = coordinate_0[0];
		int num2 = 0;
		for (int i = 1; i <= num; i++)
		{
			Coordinate coordinate2 = coordinate_0[i];
			if (coordinate2.Y > coordinate.Y)
			{
				coordinate = coordinate2;
				num2 = i;
			}
		}
		int num3 = num2;
		do
		{
			num3 = (num3 - 1) % num;
		}
		while (coordinate_0[num3].Equals(coordinate) && num3 != num2);
		int num4 = num2;
		do
		{
			num4 = (num4 + 1) % num;
		}
		while (coordinate_0[num4].Equals(coordinate) && num4 != num2);
		Coordinate coordinate3 = coordinate_0[num3];
		Coordinate coordinate4 = coordinate_0[num4];
		if (!coordinate3.Equals(coordinate) && !coordinate4.Equals(coordinate) && !coordinate3.Equals(coordinate4))
		{
			double num5 = coordinate3.X - coordinate.X;
			double num6 = coordinate3.Y - coordinate.Y;
			double num7 = coordinate4.X - coordinate.X;
			double num8 = coordinate4.Y - coordinate.Y;
			double num9 = num7 * num6 - num8 * num5;
			if (num9 == 0.0)
			{
				return coordinate3.X > coordinate4.X;
			}
			return num9 > 0.0;
		}
		throw new ArgumentException("degenerate ring (does not contain 3 different points)");
	}

	public static int ComputeOrientation(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2)
	{
		double num = coordinate_1.X - coordinate_0.X;
		double num2 = coordinate_1.Y - coordinate_0.Y;
		double num3 = coordinate_2.X - coordinate_1.X;
		double num4 = coordinate_2.Y - coordinate_1.Y;
		double num5 = num * num4 - num3 * num2;
		if (num5 <= 0.0)
		{
			if (num5 < 0.0)
			{
				return -1;
			}
			return 0;
		}
		return 1;
	}
}
