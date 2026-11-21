using System;
using CSMaterial;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class SxPxMath
{
	internal static double RevertSpecification(double double_0)
	{
		double_0 = Math.Pow(double_0, 3.0);
		return double_0;
	}

	internal static double CountWatcher(double double_0)
	{
		double_0 *= double_0;
		return double_0;
	}

	internal static double CustomizeWatcher(double double_0, double double_1)
	{
		double num = double_0 - Math.Floor(double_0 / double_1) * double_1;
		if (num < 0.0)
		{
			return num + double_1;
		}
		return num;
	}

	internal static double CloneWatcher(ref double double_0)
	{
		double num = double_0 % 6.28318530717958;
		if (num < 0.0)
		{
			num += 6.28318530717958;
		}
		return num;
	}

	internal static double ConnectWatcher(ref double double_0)
	{
		double_0 *= CSMath.PI_dividedBy_180;
		return double_0;
	}

	public static void Magnitude(ref SxPxConstants.vector vector_0)
	{
		vector_0.v[3] = Math.Sqrt(CountWatcher(vector_0.v[0]) + CountWatcher(vector_0.v[1]) + CountWatcher(vector_0.v[2]));
	}

	internal static double MoveWatcher(ref double double_0, ref double double_1)
	{
		if (double_1 == 0.0)
		{
			if (double_0 <= 0.0)
			{
				return 4.712388980384685;
			}
			return 1.570796326794895;
		}
		if (double_1 <= 0.0)
		{
			return 3.14159265358979 + Math.Atan(double_0 / double_1);
		}
		return Math.Atan(double_0 / double_1);
	}

	public static void Calculate_LatLonAlt(double double_0, ref SxPxConstants.vector vector_0, ref SxPxConstants.geodetic_t geodetic_t_0)
	{
		geodetic_t_0.theta = MoveWatcher(ref vector_0.v[1], ref vector_0.v[0]);
		double double_ = geodetic_t_0.theta - SxPxTime.ViewWatcher(double_0);
		geodetic_t_0.lon = CloneWatcher(ref double_);
		double double_2 = Math.Sqrt(CountWatcher(vector_0.v[0]) + CountWatcher(vector_0.v[1]));
		double num = 0.006694317778266723;
		geodetic_t_0.lat = MoveWatcher(ref vector_0.v[2], ref double_2);
		double lat;
		double num2;
		do
		{
			lat = geodetic_t_0.lat;
			num2 = 1.0 / Math.Sqrt(1.0 - num * CountWatcher(Math.Sin(lat)));
			double_ = vector_0.v[2] + 6378.135 * num2 * num * Math.Sin(lat);
			geodetic_t_0.lat = MoveWatcher(ref double_, ref double_2);
		}
		while (Math.Abs(geodetic_t_0.lat - lat) >= 1E-10);
		geodetic_t_0.alt = double_2 / Math.Cos(geodetic_t_0.lat) - 6378.135 * num2;
		if (geodetic_t_0.lat > 1.570796326794895)
		{
			geodetic_t_0.lat -= 6.28318530717958;
		}
	}

	internal static double DeleteWatcher(double double_0)
	{
		return double_0 - (double)RadarModel.PrintStub(double_0);
	}

	internal static double AddWatcher(double double_0)
	{
		return double_0 / 0.0174532925199433;
	}
}
