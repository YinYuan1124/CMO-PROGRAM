using System;
using System.Collections.Generic;

namespace DotSpatial.Topology.Algorithm;

public static class CgAlgorithms
{
	public const int CLOCKWISE = -1;

	public const int RIGHT = -1;

	public const int COUNTER_CLOCKWISE = 1;

	public const int LEFT = 1;

	public const int COLLINEAR = 0;

	public const int STRAIGHT = 0;

	public static int OrientationIndex(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2)
	{
		double double_ = coordinate_1.X - coordinate_0.X;
		double double_2 = coordinate_1.Y - coordinate_0.Y;
		double double_3 = coordinate_2.X - coordinate_1.X;
		double double_4 = coordinate_2.Y - coordinate_1.Y;
		return RobustDeterminant.SignOfDet2X2(double_, double_2, double_3, double_4);
	}

	public static bool IsPointInRing(Coordinate coordinate_0, IList<Coordinate> ilist_0)
	{
		int num = 0;
		int count = ilist_0.Count;
		for (int i = 1; i < count; i++)
		{
			int index = i - 1;
			Coordinate coordinate = ilist_0[i];
			Coordinate coordinate2 = ilist_0[index];
			double double_ = coordinate.X - coordinate_0.X;
			double num2 = coordinate.Y - coordinate_0.Y;
			double double_2 = coordinate2.X - coordinate_0.X;
			double num3 = coordinate2.Y - coordinate_0.Y;
			if ((num2 > 0.0 && num3 <= 0.0) || (num3 > 0.0 && num2 <= 0.0))
			{
				double num4 = (double)RobustDeterminant.SignOfDet2X2(double_, num2, double_2, num3) / (num3 - num2);
				if (0.0 < num4)
				{
					num++;
				}
			}
		}
		if (num % 2 == 1)
		{
			return true;
		}
		return false;
	}

	public static bool IsOnLine(Coordinate coordinate_0, IList<Coordinate> ilist_0)
	{
		LineIntersector lineIntersector = new RobustLineIntersector();
		for (int i = 1; i < ilist_0.Count; i++)
		{
			Coordinate coordinate_ = ilist_0[i - 1];
			Coordinate coordinate_2 = ilist_0[i];
			lineIntersector.ComputeIntersection(coordinate_0, coordinate_, coordinate_2);
			if (lineIntersector.HasIntersection)
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsCounterClockwise(IList<Coordinate> ilist_0)
	{
		int num = ilist_0.Count - 1;
		Coordinate coordinate = ilist_0[0];
		int num2 = 0;
		for (int i = 1; i <= num; i++)
		{
			Coordinate coordinate2 = ilist_0[i];
			if (coordinate2.Y > coordinate.Y)
			{
				coordinate = coordinate2;
				num2 = i;
			}
		}
		int num3 = num2;
		do
		{
			num3--;
			if (num3 < 0)
			{
				num3 = num;
			}
		}
		while (ilist_0[num3].Equals2D(coordinate) && num3 != num2);
		int num4 = num2;
		do
		{
			num4 = (num4 + 1) % num;
		}
		while (ilist_0[num4].Equals2D(coordinate) && num4 != num2);
		Coordinate coordinate3 = new Coordinate(ilist_0[num3]);
		Coordinate coordinate4 = new Coordinate(ilist_0[num4]);
		if (!coordinate3.Equals2D(coordinate) && !coordinate4.Equals2D(coordinate) && !coordinate3.Equals2D(coordinate4))
		{
			int num5 = OrientationIndex(coordinate3, new Coordinate(coordinate), coordinate4);
			if (num5 == 0)
			{
				return coordinate3.X > coordinate4.X;
			}
			return num5 > 0;
		}
		return false;
	}

	public static int ComputeOrientation(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2)
	{
		return OrientationIndex(coordinate_0, coordinate_1, coordinate_2);
	}

	public static double DistancePointLine(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2)
	{
		if (coordinate_1.Equals(coordinate_2))
		{
			return coordinate_0.Distance(coordinate_1);
		}
		double num = ((coordinate_0.X - coordinate_1.X) * (coordinate_2.X - coordinate_1.X) + (coordinate_0.Y - coordinate_1.Y) * (coordinate_2.Y - coordinate_1.Y)) / ((coordinate_2.X - coordinate_1.X) * (coordinate_2.X - coordinate_1.X) + (coordinate_2.Y - coordinate_1.Y) * (coordinate_2.Y - coordinate_1.Y));
		if (num <= 0.0)
		{
			return coordinate_0.Distance(coordinate_1);
		}
		if (num < 1.0)
		{
			return Math.Abs(((coordinate_1.Y - coordinate_0.Y) * (coordinate_2.X - coordinate_1.X) - (coordinate_1.X - coordinate_0.X) * (coordinate_2.Y - coordinate_1.Y)) / ((coordinate_2.X - coordinate_1.X) * (coordinate_2.X - coordinate_1.X) + (coordinate_2.Y - coordinate_1.Y) * (coordinate_2.Y - coordinate_1.Y))) * Math.Sqrt((coordinate_2.X - coordinate_1.X) * (coordinate_2.X - coordinate_1.X) + (coordinate_2.Y - coordinate_1.Y) * (coordinate_2.Y - coordinate_1.Y));
		}
		return coordinate_0.Distance(coordinate_2);
	}

	public static double DistancePointLinePerpendicular(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2)
	{
		return Math.Abs(((coordinate_1.Y - coordinate_0.Y) * (coordinate_2.X - coordinate_1.X) - (coordinate_1.X - coordinate_0.X) * (coordinate_2.Y - coordinate_1.Y)) / ((coordinate_2.X - coordinate_1.X) * (coordinate_2.X - coordinate_1.X) + (coordinate_2.Y - coordinate_1.Y) * (coordinate_2.Y - coordinate_1.Y))) * Math.Sqrt((coordinate_2.X - coordinate_1.X) * (coordinate_2.X - coordinate_1.X) + (coordinate_2.Y - coordinate_1.Y) * (coordinate_2.Y - coordinate_1.Y));
	}

	public static double DistanceLineLine(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2, Coordinate coordinate_3)
	{
		if (coordinate_0.Equals(coordinate_1))
		{
			return DistancePointLine(coordinate_0, coordinate_2, coordinate_3);
		}
		if (coordinate_2.Equals(coordinate_3))
		{
			return DistancePointLine(coordinate_3, coordinate_0, coordinate_1);
		}
		double num = (coordinate_0.Y - coordinate_2.Y) * (coordinate_3.X - coordinate_2.X) - (coordinate_0.X - coordinate_2.X) * (coordinate_3.Y - coordinate_2.Y);
		double num2 = (coordinate_1.X - coordinate_0.X) * (coordinate_3.Y - coordinate_2.Y) - (coordinate_1.Y - coordinate_0.Y) * (coordinate_3.X - coordinate_2.X);
		double num3 = (coordinate_0.Y - coordinate_2.Y) * (coordinate_1.X - coordinate_0.X) - (coordinate_0.X - coordinate_2.X) * (coordinate_1.Y - coordinate_0.Y);
		double num4 = (coordinate_1.X - coordinate_0.X) * (coordinate_3.Y - coordinate_2.Y) - (coordinate_1.Y - coordinate_0.Y) * (coordinate_3.X - coordinate_2.X);
		if (num2 != 0.0 && num4 != 0.0)
		{
			double num5 = num3 / num4;
			double num6 = num / num2;
			if (num6 >= 0.0 && num6 <= 1.0 && num5 >= 0.0 && num5 <= 1.0)
			{
				return 0.0;
			}
			return Math.Min(DistancePointLine(coordinate_0, coordinate_2, coordinate_3), Math.Min(DistancePointLine(coordinate_1, coordinate_2, coordinate_3), Math.Min(DistancePointLine(coordinate_2, coordinate_0, coordinate_1), DistancePointLine(coordinate_3, coordinate_0, coordinate_1))));
		}
		return Math.Min(DistancePointLine(coordinate_0, coordinate_2, coordinate_3), Math.Min(DistancePointLine(coordinate_1, coordinate_2, coordinate_3), Math.Min(DistancePointLine(coordinate_2, coordinate_0, coordinate_1), DistancePointLine(coordinate_3, coordinate_0, coordinate_1))));
	}

	public static double SignedArea(IList<Coordinate> ilist_0)
	{
		if (ilist_0.Count < 3)
		{
			return 0.0;
		}
		double num = 0.0;
		for (int i = 0; i < ilist_0.Count - 1; i++)
		{
			double x = ilist_0[i].X;
			double y = ilist_0[i].Y;
			double x2 = ilist_0[i + 1].X;
			double y2 = ilist_0[i + 1].Y;
			num += (x + x2) * (y2 - y);
		}
		Coordinate coordinate = ilist_0[ilist_0.Count - 1];
		Coordinate coordinate2 = ilist_0[0];
		if (coordinate2.X != coordinate.X && coordinate2.Y != coordinate.Y)
		{
			num += (coordinate.X + coordinate2.X) * (coordinate2.Y - coordinate.Y);
		}
		return (0.0 - num) / 2.0;
	}

	public static double Length(IList<Coordinate> ilist_0)
	{
		if (ilist_0.Count < 1)
		{
			return 0.0;
		}
		double num = 0.0;
		for (int i = 1; i < ilist_0.Count; i++)
		{
			num += ilist_0[i].Distance(ilist_0[i - 1]);
		}
		return num;
	}
}
