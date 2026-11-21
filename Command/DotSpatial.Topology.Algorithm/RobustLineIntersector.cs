#define TRACE
using System.Diagnostics;

namespace DotSpatial.Topology.Algorithm;

public class RobustLineIntersector : LineIntersector
{
	public override void ComputeIntersection(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2)
	{
		IsProper = false;
		if (Envelope.Intersects(coordinate_1, coordinate_2, coordinate_0) && CgAlgorithms.OrientationIndex(coordinate_1, coordinate_2, coordinate_0) == 0 && CgAlgorithms.OrientationIndex(coordinate_2, coordinate_1, coordinate_0) == 0)
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

	public override IntersectionType ComputeIntersect(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2, Coordinate coordinate_3)
	{
		IsProper = false;
		if (Envelope.Intersects(coordinate_0, coordinate_1, coordinate_2, coordinate_3))
		{
			int num = CgAlgorithms.OrientationIndex(coordinate_0, coordinate_1, coordinate_2);
			int num2 = CgAlgorithms.OrientationIndex(coordinate_0, coordinate_1, coordinate_3);
			if ((num > 0 && num2 > 0) || (num < 0 && num2 < 0))
			{
				return IntersectionType.NoIntersection;
			}
			int num3 = CgAlgorithms.OrientationIndex(coordinate_2, coordinate_3, coordinate_0);
			int num4 = CgAlgorithms.OrientationIndex(coordinate_2, coordinate_3, coordinate_1);
			if ((num3 > 0 && num4 > 0) || (num3 < 0 && num4 < 0))
			{
				return IntersectionType.NoIntersection;
			}
			if (num == 0 && num2 == 0 && num3 == 0 && num4 == 0)
			{
				return CreateExpression(coordinate_0, coordinate_1, coordinate_2, coordinate_3);
			}
			if (num != 0 && num2 != 0 && num3 != 0 && num4 != 0)
			{
				IsProper = true;
				base.IntersectionPoints[0] = CompareExpression(coordinate_0, coordinate_1, coordinate_2, coordinate_3);
			}
			else
			{
				IsProper = false;
				if (num == 0)
				{
					base.IntersectionPoints[0] = new Coordinate(coordinate_2);
				}
				if (num2 == 0)
				{
					base.IntersectionPoints[0] = new Coordinate(coordinate_3);
				}
				if (num3 == 0)
				{
					base.IntersectionPoints[0] = new Coordinate(coordinate_0);
				}
				if (num4 == 0)
				{
					base.IntersectionPoints[0] = new Coordinate(coordinate_1);
				}
			}
			return IntersectionType.PointIntersection;
		}
		return IntersectionType.NoIntersection;
	}

	private IntersectionType CreateExpression(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2, Coordinate coordinate_3)
	{
		bool flag = Envelope.Intersects(coordinate_0, coordinate_1, coordinate_2);
		bool flag2 = Envelope.Intersects(coordinate_0, coordinate_1, coordinate_3);
		bool flag3 = Envelope.Intersects(coordinate_2, coordinate_3, coordinate_0);
		bool flag4 = Envelope.Intersects(coordinate_2, coordinate_3, coordinate_1);
		if (flag && flag2)
		{
			base.IntersectionPoints[0] = coordinate_2;
			base.IntersectionPoints[1] = coordinate_3;
			return IntersectionType.Collinear;
		}
		if (flag3 && flag4)
		{
			base.IntersectionPoints[0] = coordinate_0;
			base.IntersectionPoints[1] = coordinate_1;
			return IntersectionType.Collinear;
		}
		if (flag && flag3)
		{
			base.IntersectionPoints[0] = coordinate_2;
			base.IntersectionPoints[1] = coordinate_0;
			if (coordinate_2.Equals(coordinate_0))
			{
				return IntersectionType.PointIntersection;
			}
			return IntersectionType.Collinear;
		}
		if (flag && flag4)
		{
			base.IntersectionPoints[0] = coordinate_2;
			base.IntersectionPoints[1] = coordinate_1;
			if (coordinate_2.Equals(coordinate_1))
			{
				return IntersectionType.PointIntersection;
			}
			return IntersectionType.Collinear;
		}
		if (flag2 && flag3)
		{
			base.IntersectionPoints[0] = coordinate_3;
			base.IntersectionPoints[1] = coordinate_0;
			if (coordinate_3.Equals(coordinate_0))
			{
				return IntersectionType.PointIntersection;
			}
			return IntersectionType.Collinear;
		}
		if (flag2 && flag4)
		{
			base.IntersectionPoints[0] = coordinate_3;
			base.IntersectionPoints[1] = coordinate_1;
			if (coordinate_3.Equals(coordinate_1))
			{
				return IntersectionType.PointIntersection;
			}
			return IntersectionType.Collinear;
		}
		return IntersectionType.NoIntersection;
	}

	private Coordinate CompareExpression(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2, Coordinate coordinate_3)
	{
		Coordinate coordinate_4 = new Coordinate(coordinate_0);
		Coordinate coordinate_5 = new Coordinate(coordinate_1);
		Coordinate coordinate_6 = new Coordinate(coordinate_2);
		Coordinate coordinate_7 = new Coordinate(coordinate_3);
		Coordinate coordinate = new Coordinate();
		ReadExpression(coordinate_4, coordinate_5, coordinate_6, coordinate_7, coordinate);
		Coordinate coordinate2 = HCoordinate.Intersection(coordinate_4, coordinate_5, coordinate_6, coordinate_7);
		coordinate2.X += coordinate.X;
		coordinate2.Y += coordinate.Y;
		if (!DisableExpression(coordinate2))
		{
			Trace.WriteLine("Intersection outside segment envelopes: " + (object)coordinate2);
		}
		if (PrecisionModel != null)
		{
			PrecisionModel.MakePrecise(coordinate2);
		}
		return coordinate2;
	}

	private static void ReadExpression(Coordinate coordinate_0, Coordinate coordinate_1, Coordinate coordinate_2, Coordinate coordinate_3, Coordinate coordinate_4)
	{
		double num = ((coordinate_0.X < coordinate_1.X) ? coordinate_0.X : coordinate_1.X);
		double num5 = ((coordinate_0.Y < coordinate_1.Y) ? coordinate_0.Y : coordinate_1.Y);
		double num6 = ((coordinate_0.X <= coordinate_1.X) ? coordinate_1.X : coordinate_0.X);
		double num7 = ((coordinate_0.Y <= coordinate_1.Y) ? coordinate_1.Y : coordinate_0.Y);
		double num8 = ((coordinate_2.X < coordinate_3.X) ? coordinate_2.X : coordinate_3.X);
		double num9 = ((coordinate_2.Y < coordinate_3.Y) ? coordinate_2.Y : coordinate_3.Y);
		double num10 = ((coordinate_2.X <= coordinate_3.X) ? coordinate_3.X : coordinate_2.X);
		double num11 = ((coordinate_2.Y <= coordinate_3.Y) ? coordinate_3.Y : coordinate_2.Y);
		double num12 = ((num <= num8) ? num8 : num);
		double num2 = ((num6 < num10) ? num6 : num10);
		double num3 = ((num5 <= num9) ? num9 : num5);
		double num4 = ((num7 < num11) ? num7 : num11);
		double x = (num12 + num2) / 2.0;
		double y = (num3 + num4) / 2.0;
		coordinate_4.X = x;
		coordinate_4.Y = y;
		coordinate_0.X -= coordinate_4.X;
		coordinate_0.Y -= coordinate_4.Y;
		coordinate_1.X -= coordinate_4.X;
		coordinate_1.Y -= coordinate_4.Y;
		coordinate_2.X -= coordinate_4.X;
		coordinate_2.Y -= coordinate_4.Y;
		coordinate_3.X -= coordinate_4.X;
		coordinate_3.Y -= coordinate_4.Y;
	}

	private bool DisableExpression(Coordinate coordinate_0)
	{
		Envelope ienvelope_ = new Envelope(base.InputLines[0, 0], base.InputLines[0, 1]);
		Envelope ienvelope_2 = new Envelope(base.InputLines[1, 0], base.InputLines[1, 1]);
		if (ienvelope_.Contains(coordinate_0))
		{
			return ienvelope_2.Contains(coordinate_0);
		}
		return false;
	}
}
