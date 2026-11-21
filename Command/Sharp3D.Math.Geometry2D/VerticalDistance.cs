using System;
using System.Collections.Generic;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

public sealed class VerticalDistance
{
	public static bool PointToAboveSegment(Vector2D vector2D_0, Segment segment_0, ref double double_0)
	{
		double num = System.Math.Min(segment_0.P0.X, segment_0.P1.X);
		double num2 = System.Math.Max(segment_0.P0.X, segment_0.P1.X);
		if (vector2D_0.X >= num - 4.76837158203125E-07 && vector2D_0.X <= num2 + 4.76837158203125E-07)
		{
			double num3 = System.Math.Min(segment_0.P0.Y, segment_0.P1.Y);
			double num4 = System.Math.Max(segment_0.P0.Y, segment_0.P1.Y);
			if (System.Math.Abs(segment_0.P1.X - segment_0.P0.X) < 4.76837158203125E-07)
			{
				if (vector2D_0.Y < num3)
				{
					double_0 = num3 - vector2D_0.Y;
				}
				else if (vector2D_0.Y <= num4)
				{
					double_0 = 0.0;
				}
				else
				{
					double_0 = num4 - vector2D_0.Y;
				}
			}
			else
			{
				double_0 = segment_0.P0.Y + (vector2D_0.X - segment_0.P0.X) * (segment_0.P1.Y - segment_0.P0.Y) / (segment_0.P1.X - segment_0.P0.X) - vector2D_0.Y;
			}
			return true;
		}
		return false;
	}

	public static bool PointToAboveArc(Vector2D vector2D_0, Arc arc_0, ref double double_0)
	{
		bool result = false;
		double_0 = double.MaxValue;
		foreach (Segment item in (IEnumerable<Segment>)arc_0.Explode(20))
		{
			double double_ = 0.0;
			if (PointToAboveSegment(vector2D_0, item, ref double_) && double_ > 0.0)
			{
				double_0 = System.Math.Min(double_, double_0);
				result = true;
			}
		}
		return result;
	}

	public static bool SegmentToAboveSegment(Segment segment_0, Segment segment_1, ref double double_0)
	{
		bool result = false;
		double_0 = double.MaxValue;
		double double_ = 0.0;
		if (PointToAboveSegment(segment_0.P0, segment_1, ref double_) && double_ >= 0.0)
		{
			double_0 = System.Math.Min(double_0, double_);
			result = true;
		}
		if (PointToAboveSegment(segment_0.P1, segment_1, ref double_) && double_ >= 0.0)
		{
			double_0 = System.Math.Min(double_0, double_);
			result = true;
		}
		if (PointToAboveSegment(segment_1.P0, segment_0, ref double_) && double_ <= 0.0)
		{
			double_0 = System.Math.Min(double_0, 0.0 - double_);
			result = true;
		}
		if (PointToAboveSegment(segment_1.P1, segment_0, ref double_) && double_ <= 0.0)
		{
			double_0 = System.Math.Min(double_0, 0.0 - double_);
			result = true;
		}
		return result;
	}

	public static bool SegmentToAboveArc(Segment segment_0, Arc arc_0, ref double double_0)
	{
		bool result = false;
		double_0 = double.MaxValue;
		foreach (Segment item in arc_0.Explode(20))
		{
			double double_ = 0.0;
			if (PointToAboveSegment(segment_0.P0, item, ref double_) && double_ > 0.0)
			{
				double_0 = System.Math.Min(double_0, double_);
				result = true;
			}
			if (PointToAboveSegment(segment_0.P1, item, ref double_) && double_ > 0.0)
			{
				double_0 = System.Math.Min(double_0, double_);
				result = true;
			}
			if (PointToAboveSegment(item.P0, segment_0, ref double_) && double_ < 0.0)
			{
				double_0 = System.Math.Min(double_0, 0.0 - double_);
				result = true;
			}
			if (PointToAboveSegment(item.P1, segment_0, ref double_) && double_ < 0.0)
			{
				double_0 = System.Math.Min(double_0, 0.0 - double_);
				result = true;
			}
		}
		return result;
	}

	public static bool ArcToAboveSegment(Arc arc_0, Segment segment_0, ref double double_0)
	{
		bool result = false;
		double_0 = double.MaxValue;
		foreach (Segment item in arc_0.Explode(20))
		{
			double double_ = double.MaxValue;
			if (PointToAboveSegment(item.P0, segment_0, ref double_) && double_ > 0.0)
			{
				double_0 = System.Math.Min(double_0, double_);
				result = true;
			}
			if (PointToAboveSegment(item.P1, segment_0, ref double_) && double_ > 0.0)
			{
				double_0 = System.Math.Min(double_0, double_);
				result = true;
			}
			if (PointToAboveSegment(segment_0.P0, item, ref double_) && double_ < 0.0)
			{
				double_0 = System.Math.Min(double_0, 0.0 - double_);
				result = true;
			}
			if (PointToAboveSegment(segment_0.P1, item, ref double_) && double_ < 0.0)
			{
				double_0 = System.Math.Min(double_0, 0.0 - double_);
				result = true;
			}
		}
		return result;
	}

	public static bool ArcToAboveArc(Arc arc_0, Arc arc_1, ref double double_0)
	{
		bool result = false;
		double_0 = double.MaxValue;
		List<Segment> list = arc_0.Explode(20);
		List<Segment> list2 = arc_1.Explode(20);
		foreach (Segment item in list)
		{
			foreach (Segment item2 in list2)
			{
				double double_ = double.MaxValue;
				if (SegmentToAboveSegment(item, item2, ref double_) && double_ > 0.0)
				{
					double_0 = System.Math.Min(double_0, double_);
					result = true;
				}
			}
		}
		return result;
	}
}
