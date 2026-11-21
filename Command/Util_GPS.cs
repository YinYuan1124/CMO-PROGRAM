using System;

public class Util_GPS
{
	private static double m_Serializer;

	private static double m_Ref;

	private static double m_Error;

	public static void GeocentricToGeodetic(double double_0, double double_1, double double_2, out double double_3, out double double_4, out double double_5)
	{
		double @ref = m_Ref;
		double error = m_Error;
		double num = 1.0 - error * error / (@ref * @ref);
		double num2 = @ref * @ref / (error * error) - 1.0;
		double num3 = @ref * @ref;
		double num4 = error * error;
		double num5 = double_2 * double_2;
		double num6 = num * num;
		double num7 = double_0 * double_0 + double_1 * double_1;
		double num8 = Math.Sqrt(num7);
		double num9 = num3 - num4;
		double num10 = 54.0 * num4 * num5;
		double num11 = num7 + (1.0 - num) * num5 - num * num9;
		double num12 = num6 * num10 * num7 / (num11 * num11 * num11);
		double num13 = Math.Pow(1.0 + num12 + Math.Sqrt(num12 * num12 + 2.0 * num12), 1.0 / 3.0);
		double num14 = num13 + 1.0 / num13 + 1.0;
		double num15 = num10 / (3.0 * num14 * num14 * num11 * num11);
		double num16 = Math.Sqrt(1.0 + 2.0 * num6 * num15);
		double num17 = (0.0 - num15 * num * num8) / (1.0 + num16) + Math.Sqrt(0.5 * num3 * (1.0 + 1.0 / num16) - num15 * (1.0 - num) * num5 / (num16 * (1.0 + num16)) - 0.5 * num15 * num7);
		num14 = num8 - num * num17;
		double num18 = Math.Sqrt(num14 * num14 + num5);
		double num19 = Math.Sqrt(num14 * num14 + (1.0 - num) * num5);
		num14 = num4 / (@ref * num19);
		double_5 = num18 * (1.0 - num14);
		double_3 = Math.Atan2(double_2 + num2 * num14 * double_2, num8);
		double_4 = Math.Atan2(double_1, double_0);
		double_3 = m_Serializer * double_3;
		double_4 = m_Serializer * double_4;
	}

	static Util_GPS()
	{
		m_Serializer = 180.0 / Math.PI;
		m_Ref = 6378137.0;
		m_Error = 6356752.314245;
	}
}
