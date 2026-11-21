using System;

namespace OpenDIS.Utilities;

public class EulerConversions
{
	private static double m_StatusCallback;

	private static double _ProccesorCallback;

	public static double getOrientationFromEuler(double double_0, double double_1, double double_2, double double_3)
	{
		double num = Math.Sin(double_0);
		double num5 = Math.Sin(double_1);
		double num6 = Math.Cos(double_1);
		double num7 = Math.Cos(double_0);
		double num8 = num * num5;
		double num9 = Math.Cos(double_3);
		double num10 = Math.Cos(double_2);
		double num11 = Math.Sin(double_2);
		double num12 = Math.Sin(double_3);
		double num2 = num9 * num10;
		double num3 = num9 * num11;
		double num4 = num * num6;
		double y = (0.0 - num5) * num2 + num6 * num3;
		double x = (0.0 - num4) * num2 - num8 * num3 - num7 * num12;
		return Math.Atan2(y, x) * m_StatusCallback;
	}

	public static double getPitchFromEuler(double double_0, double double_1, double double_2, double double_3)
	{
		double num = Math.Sin(double_0);
		double num3 = Math.Sin(double_1);
		double num4 = Math.Cos(double_1);
		double num5 = Math.Cos(double_0);
		double num6 = num5 * num4;
		double num7 = num5 * num3;
		double num8 = Math.Cos(double_3);
		double num9 = Math.Cos(double_2);
		double num10 = Math.Sin(double_2);
		double num2 = Math.Sin(double_3);
		return Math.Asin(num6 * num8 * num9 + num7 * num8 * num10 - num * num2) * m_StatusCallback;
	}

	public static double getRollFromEuler(double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		double num = Math.Sin(double_0);
		double num9 = Math.Sin(double_1);
		double num10 = Math.Cos(double_1);
		double num11 = Math.Cos(double_0);
		double num12 = num11 * num10;
		double num13 = num11 * num9;
		double num14 = Math.Cos(double_3);
		double num15 = Math.Sin(double_3);
		double num16 = Math.Cos(double_2);
		double num2 = Math.Sin(double_2);
		double num3 = Math.Sin(double_4);
		double num4 = Math.Cos(double_4);
		double num5 = num3 * num15;
		double num6 = num4 * num15;
		double num7 = num12 * ((0.0 - num4) * num2 + num5 * num16) + num13 * (num4 * num16 + num5 * num2) + num * (num3 * num14);
		double num8 = num12 * (num3 * num2 + num6 * num16) + num13 * ((0.0 - num3) * num16 + num6 * num2) + num * (num4 * num14);
		return Math.Atan2(0.0 - num7, 0.0 - num8) * m_StatusCallback;
	}

	public static double getThetaFromTaitBryanAngles(double double_0, double double_1, double double_2, double double_3)
	{
		double num = Math.Sin(double_0);
		double num2 = Math.Cos(double_0);
		double num3 = Math.Cos(double_3 * _ProccesorCallback);
		double num4 = Math.Sin(double_3 * _ProccesorCallback);
		double num5 = Math.Cos(double_2 * _ProccesorCallback);
		return Math.Asin((0.0 - num2) * num5 * num3 - num * num4);
	}

	public static double getPsiFromTaitBryanAngles(double double_0, double double_1, double double_2, double double_3)
	{
		double num = Math.Sin(double_0);
		double num5 = Math.Sin(double_1);
		double num6 = Math.Cos(double_1);
		double num7 = Math.Cos(double_0);
		double num8 = num7 * num6;
		double num9 = num7 * num5;
		double num10 = num * num6;
		double num11 = num * num5;
		double num12 = Math.Cos(double_3 * _ProccesorCallback);
		double num2 = Math.Sin(double_3 * _ProccesorCallback);
		double num3 = Math.Sin(double_2 * _ProccesorCallback);
		double num4 = Math.Cos(double_2 * _ProccesorCallback);
		double x = (0.0 - num5) * num3 * num12 - num10 * num4 * num12 + num8 * num2;
		return Math.Atan2(num6 * num3 * num12 - num11 * num4 * num12 + num9 * num2, x);
	}

	public static double getPhiFromTaitBryanAngles(double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		double num = Math.Sin(double_0);
		double num2 = Math.Cos(double_0);
		double num3 = Math.Cos(double_4 * _ProccesorCallback);
		double num4 = Math.Sin(double_4 * _ProccesorCallback);
		double num5 = Math.Cos(double_3 * _ProccesorCallback);
		double num6 = Math.Sin(double_3 * _ProccesorCallback);
		double num7 = Math.Sin(double_2 * _ProccesorCallback);
		double num8 = Math.Cos(double_2 * _ProccesorCallback);
		double y = num2 * ((0.0 - num7) * num3 + num8 * num6 * num4) - num * num5 * num4;
		double x = num2 * (num7 * num4 + num8 * num6 * num3) - num * num5 * num3;
		return Math.Atan2(y, x);
	}

	static EulerConversions()
	{
		m_StatusCallback = 57.2957795131;
		_ProccesorCallback = 0.01745329252;
	}
}
