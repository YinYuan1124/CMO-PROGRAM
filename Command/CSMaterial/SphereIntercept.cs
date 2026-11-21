using System;

namespace CSMaterial;

public static class SphereIntercept
{
	private static void PrepareDefinition(double double_0, double double_1, out double double_2, out double double_3, double double_4, double double_5)
	{
		double num = double_4 / 3441.686541;
		double num2 = Math.Sin(double_1);
		double num3 = Math.Cos(double_1);
		double num4 = Math.Sin(num);
		double num5 = Math.Cos(num);
		double_3 = Math.Asin(num2 * num5 + num3 * num4 * Math.Cos(double_5));
		double num6 = Math.Atan2(Math.Sin(double_5) * num4 * num3, num5 - num2 * Math.Sin(double_3));
		double num7 = double_0 + num6 + Math.PI;
		double num8 = Math.PI * 2.0;
		double_2 = (num7 - num8 * Math.Floor(num7 / num8) - Math.PI) % (Math.PI * 2.0);
		if (double_2 < -Math.PI)
		{
			double_2 += Math.PI * 2.0;
		}
	}

	private static double ReflectDefinition(double double_0, double double_1, double double_2, double double_3)
	{
		double y = Math.Sin(double_2 - double_0) * Math.Cos(double_3);
		double x = Math.Cos(double_1) * Math.Sin(double_3) - Math.Sin(double_1) * Math.Cos(double_3) * Math.Cos(double_2 - double_0);
		return Math.Atan2(y, x);
	}

	private static double VisitDefinition(double double_0, double double_1, double double_2, double double_3)
	{
		return 3441.686541 * Math.Acos(Math.Sin(double_1) * Math.Sin(double_3) + Math.Cos(double_1) * Math.Cos(double_3) * Math.Cos(Math.Abs(double_1 - double_3)));
	}

	public static double? InterceptHeading_deg(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7)
	{
		double double_11 = double_0 * CSMath.PI_dividedBy_180;
		double double_12 = double_1 * CSMath.PI_dividedBy_180;
		double double_8 = double_3 * CSMath.PI_dividedBy_180;
		double num = double_5 * CSMath.PI_dividedBy_180;
		double num3 = double_6 * CSMath.PI_dividedBy_180;
		double_2 *= 1.5;
		double num4 = double_2 / 100.0;
		double num5 = 3.4028234663852886E+38;
		double num6 = 1.7014117331926443E+38;
		int num7 = 1;
		while (num6 < num5)
		{
			num5 = num6;
			double num8 = num4 * (double)num7;
			PrepareDefinition(double_12, double_11, out var double_9, out var double_10, num8, double_8);
			double num9 = num8 / double_4;
			double num10 = VisitDefinition(double_9, double_10, num3, num);
			double num2 = num9 * double_7;
			num6 = num10 - num2;
			if (num6 >= 0.0)
			{
				num7++;
				if (num7 > 1000)
				{
					return double.MaxValue;
				}
				continue;
			}
			return ReflectDefinition(num3, num, double_9, double_10) * 180.0 / Math.PI;
		}
		return null;
	}
}
