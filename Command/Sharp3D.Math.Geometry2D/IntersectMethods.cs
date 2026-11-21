using System;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

public sealed class IntersectMethods
{
	public static bool IntersectLines(Segment segment_0, Segment segment_1, out Intersection2D intersection2D_0)
	{
		double num = (segment_0.P1.X - segment_0.P0.X) * (segment_1.P1.Y - segment_1.P0.Y) - (segment_0.P1.Y - segment_0.P0.Y) * (segment_1.P1.X - segment_1.P0.X);
		double num2 = (segment_0.P0.Y - segment_1.P0.Y) * (segment_1.P1.X - segment_1.P0.X) - (segment_0.P0.X - segment_1.P0.X) * (segment_1.P1.Y - segment_1.P0.Y);
		double num3 = (segment_0.P0.Y - segment_1.P0.Y) * (segment_0.P1.X - segment_0.P0.X) - (segment_0.P0.X - segment_1.P0.X) * (segment_0.P1.Y - segment_0.P0.Y);
		if (System.Math.Abs(num) <= 4.76837158203125E-07)
		{
			System.Math.Abs(num2);
			intersection2D_0 = new Intersection2D();
			return false;
		}
		num2 /= num;
		num3 /= num;
		intersection2D_0 = new Intersection2D(new Vector2D(segment_0.P0 + num2 * (segment_0.P1 - segment_0.P0)));
		return true;
	}

	public static bool Intersect(Segment segment_0, Segment segment_1, out Intersection2D intersection2D_0)
	{
		double num = (segment_0.P1.X - segment_0.P0.X) * (segment_1.P1.Y - segment_1.P0.Y) - (segment_0.P1.Y - segment_0.P0.Y) * (segment_1.P1.X - segment_1.P0.X);
		double num2 = (segment_0.P0.Y - segment_1.P0.Y) * (segment_1.P1.X - segment_1.P0.X) - (segment_0.P0.X - segment_1.P0.X) * (segment_1.P1.Y - segment_1.P0.Y);
		double num3 = (segment_0.P0.Y - segment_1.P0.Y) * (segment_0.P1.X - segment_0.P0.X) - (segment_0.P0.X - segment_1.P0.X) * (segment_0.P1.Y - segment_0.P0.Y);
		if (System.Math.Abs(num) < 4.76837158203125E-07)
		{
			if (System.Math.Abs(num2) < 4.76837158203125E-07)
			{
				Interval interval = new Interval(Interval.Type.Closed, System.Math.Min(segment_0.P0.X, segment_0.P1.X), System.Math.Max(segment_0.P0.X, segment_0.P1.X));
				Interval interval2 = new Interval(Interval.Type.Closed, System.Math.Min(segment_1.P0.X, segment_1.P1.X), System.Math.Max(segment_1.P0.X, segment_1.P1.X));
				if (!(interval.Max < interval2.Min) && interval2.Max >= interval.Min)
				{
					new Interval(Interval.Type.Closed, System.Math.Max(interval.Min, interval2.Min), System.Math.Min(interval.Max, interval2.Max));
					intersection2D_0 = new Intersection2D(default(Segment));
					return true;
				}
				intersection2D_0 = new Intersection2D();
				return false;
			}
			intersection2D_0 = new Intersection2D();
			return false;
		}
		num2 /= num;
		num3 /= num;
		if (0.0 <= num2 && num2 <= 1.0 && 0.0 <= num3 && num3 <= 1.0)
		{
			intersection2D_0 = new Intersection2D(new Vector2D(segment_0.P0 + num2 * (segment_0.P1 - segment_0.P0)));
			return true;
		}
		intersection2D_0 = new Intersection2D();
		return false;
	}

	public static bool Intersect(Segment segment_0, Ray ray_0, out Intersection2D intersection2D_0)
	{
		double num = (segment_0.P1.X - segment_0.P0.X) * ray_0.Direction.Y - (segment_0.P1.Y - segment_0.P0.Y) * ray_0.Direction.X;
		double num2 = (segment_0.P0.Y - ray_0.Origin.Y) * ((ray_0.Origin + ray_0.Direction).X - ray_0.Origin.X) - (segment_0.P0.X - ray_0.Origin.X) * ((ray_0.Origin + ray_0.Direction).Y - ray_0.Origin.Y);
		if (System.Math.Abs(num) < 4.76837158203125E-07)
		{
			if (System.Math.Abs(num2) < 4.76837158203125E-07)
			{
				intersection2D_0 = new Intersection2D(new Segment(segment_0));
				return true;
			}
			intersection2D_0 = new Intersection2D();
			return false;
		}
		num2 /= num;
		if (0.0 <= num2 && num2 <= 1.0)
		{
			intersection2D_0 = new Intersection2D(new Vector2D(segment_0.P0 + num2 * (segment_0.P1 - segment_0.P0)));
			return true;
		}
		intersection2D_0 = new Intersection2D();
		return false;
	}
}
