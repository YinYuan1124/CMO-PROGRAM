using System;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry2D;

public sealed class SegmentMethods
{
	public static bool AreSegmentsColinear(Segment segment_0, Segment segment_1, double double_0)
	{
		if (IsPointCollinear(segment_0, segment_1.P0, double_0))
		{
			return IsPointCollinear(segment_0, segment_1.P1, double_0);
		}
		return false;
	}

	public static bool IsPointCollinear(Segment segment_0, Vector2D vector2D_0, double double_0)
	{
		return System.Math.Abs(GetSignedTriangleArea2(segment_0, vector2D_0, double_0)) <= double_0;
	}

	public static double GetSignedTriangleArea2(Segment segment_0, Vector2D vector2D_0, double double_0)
	{
		Vector2D vector2D = vector2D_0 - segment_0.P0;
		double length = vector2D.GetLength();
		if (length < double_0)
		{
			return 0.0;
		}
		vector2D *= 1.0 / length;
		Vector2D vector2D2 = segment_0.P1 - segment_0.P0;
		double length2 = vector2D2.GetLength();
		if (length2 < double_0)
		{
			return 0.0;
		}
		vector2D2 *= 1.0 / length2;
		return vector2D.X * vector2D2.Y - vector2D.Y * vector2D2.X;
	}
}
