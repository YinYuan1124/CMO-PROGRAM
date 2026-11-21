using System;

namespace DotSpatial.Topology.Algorithm;

public class NonRobustLineIntersector : LineIntersector
{
	public static bool IsSameSignAndNonZero(double double_0, double double_1)
	{
		if (double_0 != 0.0 && double_1 != 0.0)
		{
			if (double_0 < 0.0 && double_1 < 0.0)
			{
				return true;
			}
			if (double_0 <= 0.0)
			{
				return false;
			}
			return double_1 > 0.0;
		}
		return false;
	}

	public override void ComputeIntersection(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2)
	{
		IsProper = false;
		double num = coordinate_2.Y - coordinate_1.Y;
		double num2 = coordinate_1.X - coordinate_2.X;
		double num3 = coordinate_2.X * coordinate_1.Y - coordinate_1.X * coordinate_2.Y;
		if (num * coordinate_0.X + num2 * coordinate_0.Y + num3 == 0.0)
		{
			double num4 = FindExpression(coordinate_1, coordinate_2, coordinate_0);
			if (num4 >= 0.0 && num4 <= 1.0)
			{
				IsProper = true;
				if (coordinate_0.Equals(coordinate_1) || coordinate_0.Equals(coordinate_2))
				{
					IsProper = false;
				}
				base.Result = IntersectionType.PointIntersection;
			}
			else
			{
				base.Result = IntersectionType.NoIntersection;
			}
		}
		else
		{
			base.Result = IntersectionType.NoIntersection;
		}
	}

	public override IntersectionType ComputeIntersect(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2, Coordinate coordinate_3)
	{
		IsProper = false;
		double num = coordinate_1.Y - coordinate_0.Y;
		double num4 = coordinate_0.X - coordinate_1.X;
		double num5 = coordinate_1.X * coordinate_0.Y - coordinate_0.X * coordinate_1.Y;
		double num6 = num * coordinate_2.X + num4 * coordinate_2.Y + num5;
		double num7 = num * coordinate_3.X + num4 * coordinate_3.Y + num5;
		if (num6 != 0.0 && num7 != 0.0 && IsSameSignAndNonZero(num6, num7))
		{
			return IntersectionType.NoIntersection;
		}
		double num8 = coordinate_3.Y - coordinate_2.Y;
		double num9 = coordinate_2.X - coordinate_3.X;
		double num10 = coordinate_3.X * coordinate_2.Y - coordinate_2.X * coordinate_3.Y;
		double num11 = num8 * coordinate_0.X + num9 * coordinate_0.Y + num10;
		double num2 = num8 * coordinate_1.X + num9 * coordinate_1.Y + num10;
		if (num11 != 0.0 && num2 != 0.0 && IsSameSignAndNonZero(num11, num2))
		{
			return IntersectionType.NoIntersection;
		}
		double num3 = num * num9 - num8 * num4;
		if (num3 == 0.0)
		{
			return RemoveExpression(coordinate_0, coordinate_1, coordinate_2, coordinate_3);
		}
		double double_ = (num4 * num10 - num9 * num5) / num3;
		double double_2 = (num8 * num5 - num * num10) / num3;
		base.PointA = new Coordinate(double_, double_2);
		IsProper = true;
		if (base.PointA.Equals(coordinate_0) || base.PointA.Equals(coordinate_1) || base.PointA.Equals(coordinate_2) || base.PointA.Equals(coordinate_3))
		{
			IsProper = false;
		}
		if (PrecisionModel != null)
		{
			PrecisionModel.MakePrecise(base.PointA);
		}
		return IntersectionType.PointIntersection;
	}

	private IntersectionType RemoveExpression(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2, Coordinate coordinate_3)
	{
		double num = FindExpression(coordinate_0, coordinate_1, coordinate_2);
		double num2 = FindExpression(coordinate_0, coordinate_1, coordinate_3);
		Coordinate coordinate;
		double num3;
		Coordinate coordinate2;
		double num4;
		if (num < num2)
		{
			coordinate = new Coordinate(coordinate_2);
			num3 = num;
			coordinate2 = new Coordinate(coordinate_3);
			num4 = num2;
		}
		else
		{
			coordinate = new Coordinate(coordinate_3);
			num3 = num2;
			coordinate2 = new Coordinate(coordinate_2);
			num4 = num;
		}
		if (num3 <= 1.0 && num4 >= 0.0)
		{
			if (coordinate2 == coordinate_0)
			{
				base.PointA = coordinate_0;
				return IntersectionType.PointIntersection;
			}
			if (coordinate == coordinate_1)
			{
				base.PointA = coordinate_1;
				return IntersectionType.PointIntersection;
			}
			base.PointA = coordinate_0;
			if (num3 > 0.0)
			{
				base.PointA = coordinate;
			}
			base.PointB = coordinate_1;
			if (num4 < 1.0)
			{
				base.PointB = coordinate2;
			}
			return IntersectionType.Collinear;
		}
		return IntersectionType.NoIntersection;
	}

	private static double FindExpression(object object_0, object object_1, object object_2)
	{
		double num = Math.Abs(((Coordinate)object_1).X - ((Coordinate)object_0).X);
		double num2 = Math.Abs(((Coordinate)object_1).Y - ((Coordinate)object_0).Y);
		if (num <= num2)
		{
			return (((Coordinate)object_2).Y - ((Coordinate)object_0).Y) / (((Coordinate)object_1).Y - ((Coordinate)object_0).Y);
		}
		return (((Coordinate)object_2).X - ((Coordinate)object_0).X) / (((Coordinate)object_1).X - ((Coordinate)object_0).X);
	}
}
