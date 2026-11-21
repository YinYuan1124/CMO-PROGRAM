using System;
using System.Numerics;
using CSMaterial;

namespace ExWorldWind;

public sealed class MathEngine
{
	private MathEngine()
	{
	}

	public static Vector3 SphericalToCartesian(double double_0, double double_1, double double_2)
	{
		double_0 *= CSMath.PI_dividedBy_180;
		double_1 *= CSMath.PI_dividedBy_180;
		double num = double_2 * Math.Cos(double_0);
		return new Vector3((float)(num * Math.Cos(double_1)), (float)(num * Math.Sin(double_1)), (float)(double_2 * Math.Sin(double_0)));
	}

	public static Vector3 SphericalToCartesian(Angle angle_0, Angle angle_1, double double_0)
	{
		double radians = angle_0.Radians;
		double radians2 = angle_1.Radians;
		double num = double_0 * Math.Cos(radians);
		return new Vector3((float)(num * Math.Cos(radians2)), (float)(num * Math.Sin(radians2)), (float)(double_0 * Math.Sin(radians)));
	}

	internal static Point3d FlushThread(double double_0, double double_1, double double_2)
	{
		double num = Math.Sqrt(double_0 * double_0 + double_1 * double_1 + double_2 * double_2);
		double double_3 = Math.Atan2(double_1, double_0);
		double double_4 = Math.Asin(double_2 / num);
		return new Point3d(num, double_4, double_3);
	}

	public static double DegreesToRadians(double double_0)
	{
		return Math.PI * double_0 / 180.0;
	}

	public static double RadiansToDegrees(double double_0)
	{
		return double_0 * 180.0 / Math.PI;
	}
}
