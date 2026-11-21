using System;

namespace OpenDis.Core;

public class CoordinateConversions
{
	public static readonly double RADIANS_TO_DEGREES;

	public static readonly double DEGREES_TO_RADIANS;

	private CoordinateConversions()
	{
	}

	public static double[] xyzToLatLonRadians(double[] double_0)
	{
		double num = double_0[0];
		double num4 = double_0[1];
		double num5 = double_0[2];
		double[] array = new double[3];
		double num6 = 6378137.0;
		double num7 = 6356752.3142;
		double num8 = Math.Sqrt(num * num + num4 * num4);
		double num9 = 0.006694380004260827;
		double num10 = 0.006739496756586903;
		if (num < 0.0)
		{
			if (num < 0.0 && num4 >= 0.0)
			{
				array[1] = Math.Atan(num4 / num) + Math.PI;
			}
			else
			{
				array[1] = Math.Atan(num4 / num) - Math.PI;
			}
		}
		else
		{
			array[1] = Math.Atan(num4 / num);
		}
		double num11 = Math.Atan(num6 * num5 / (num7 * num8));
		double num2 = (array[0] = Math.Atan((num5 + num10 * num7 * Math.Pow(Math.Sin(num11), 3.0)) / (num8 - num6 * num9 * Math.Pow(Math.Cos(num11), 3.0))));
		double num3 = num6 * num6 / Math.Sqrt(num6 * num6 * (Math.Cos(num2) * Math.Cos(num2)) + num7 * num7 * (Math.Sin(num2) * Math.Sin(num2)));
		array[2] = num8 / Math.Cos(num2) - num3;
		return array;
	}

	public static double[] xyzToLatLonDegrees(double[] double_0)
	{
		double[] array = xyzToLatLonRadians(double_0);
		array[0] = array[0] * 180.0 / Math.PI;
		array[1] = array[1] * 180.0 / Math.PI;
		return array;
	}

	public static double[] getXYZfromLatLonRadians(double double_0, double double_1, double double_2)
	{
		double num = Math.Cos(double_0);
		double num2 = Math.Sin(double_0);
		double num3 = 40680631590769.0 / Math.Sqrt(40680631590769.0 * (num * num) + 40408299984087.055 * (num2 * num2));
		double num4 = (num3 + double_2) * num * Math.Cos(double_1);
		double num5 = (num3 + double_2) * num * Math.Sin(double_1);
		double num6 = (0.9933056199957392 * num3 + double_2) * num2;
		return new double[3] { num4, num5, num6 };
	}

	public static double[] getXYZfromLatLonDegrees(double double_0, double double_1, double double_2)
	{
		return getXYZfromLatLonRadians(double_0 * DEGREES_TO_RADIANS, double_1 * DEGREES_TO_RADIANS, double_2);
	}

	static CoordinateConversions()
	{
		RADIANS_TO_DEGREES = 180.0 / Math.PI;
		DEGREES_TO_RADIANS = Math.PI / 180.0;
	}
}
