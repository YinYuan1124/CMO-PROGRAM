using System;

namespace DotSpatial.Topology.Voronoi;

public abstract class MathTools
{
	public static double Dist(double double_0, double double_1, double double_2, double double_3)
	{
		return Math.Sqrt((double_2 - double_0) * (double_2 - double_0) + (double_3 - double_1) * (double_3 - double_1));
	}

	public static int Ccw(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, bool bool_0)
	{
		double num = double_2 - double_0;
		double num2 = double_3 - double_1;
		double num3 = double_4 - double_0;
		double num4 = double_5 - double_1;
		if (num * num4 <= num2 * num3)
		{
			if (num * num4 < num2 * num3)
			{
				return -1;
			}
			if (!(num * num3 < 0.0) && num2 * num4 >= 0.0)
			{
				if (num * num + num2 * num2 < num3 * num3 + num4 * num4 && bool_0)
				{
					return 1;
				}
				return 0;
			}
			return -1;
		}
		return 1;
	}
}
