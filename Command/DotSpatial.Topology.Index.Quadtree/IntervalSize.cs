using System;

namespace DotSpatial.Topology.Index.Quadtree;

public static class IntervalSize
{
	public const int MIN_BINARY_EXPONENT = -50;

	public static bool IsZeroWidth(double double_0, double double_1)
	{
		double num = double_1 - double_0;
		if (num == 0.0)
		{
			return true;
		}
		double num2 = Math.Max(Math.Abs(double_0), Math.Abs(double_1));
		return DoubleBits.GetExponent(num / num2) <= -50;
	}
}
