using System;

namespace Zeptomoby.OrbitTools;

public static class Globals
{
	public const double Pi = Math.PI;

	public const double TwoPi = Math.PI * 2.0;

	public const double RadsPerDegree = Math.PI / 180.0;

	public const double DegreesPerRad = 180.0 / Math.PI;

	public const double Gm = 398601.2;

	public const double GeoSyncAlt = 42241.892;

	public const double EarthDiam = 12800.0;

	public const double DaySidereal = 86164.09;

	public const double DaySolar = 86400.0;

	public const double Ae = 1.0;

	public const double Au = 149597870.0;

	public const double Sr = 696000.0;

	public const double Xkmper = 6378.135;

	public const double F = 0.003352779454167505;

	public const double Ge = 398600.8;

	public const double J2 = 0.0010826158;

	public const double J3 = -2.53881E-06;

	public const double J4 = -1.65597E-06;

	public const double Ck2 = 0.0005413079;

	public const double Ck4 = 6.209887499999999E-07;

	public const double Xj3 = -2.53881E-06;

	public const double Qo = 1.018814277214264;

	public const double S = 1.0122292801892716;

	public const double HoursPerDay = 24.0;

	public const double MinPerDay = 1440.0;

	public const double SecPerDay = 86400.0;

	public const double OmegaE = 1.00273790934;

	public static double Xke;

	public static double Qoms2t;

	public static double Sqr(double double_0)
	{
		return double_0 * double_0;
	}

	public static double Fmod2p(double double_0)
	{
		double num = double_0 % (Math.PI * 2.0);
		if (num < 0.0)
		{
			num += Math.PI * 2.0;
		}
		return num;
	}

	public static double AcTan(double double_0, double double_1)
	{
		if (double_1 == 0.0)
		{
			if (double_0 <= 0.0)
			{
				return 4.71238898038469;
			}
			return Math.PI / 2.0;
		}
		if (double_1 <= 0.0)
		{
			return Math.PI + Math.Atan(double_0 / double_1);
		}
		return Math.Atan(double_0 / double_1);
	}

	public static double ToDegrees(double double_0)
	{
		return double_0 * (180.0 / Math.PI);
	}

	public static double ToRadians(double double_0)
	{
		return double_0 * (Math.PI / 180.0);
	}

	static Globals()
	{
		Xke = Math.Sqrt(0.005530438215158448);
		Qoms2t = Math.Pow(0.006584997024992489, 4.0);
	}
}
