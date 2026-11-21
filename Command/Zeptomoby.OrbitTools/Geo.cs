using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public class Geo
{
	[CompilerGenerated]
	private double m_Record;

	[CompilerGenerated]
	private double m_Exception;

	public double LatitudeRad { get; set; }

	public double LongitudeRad
	{
		[CompilerGenerated]
		get
		{
			return m_Record;
		}
		[CompilerGenerated]
		set
		{
			m_Record = value;
		}
	}

	public double LatitudeDeg => Globals.ToDegrees(LatitudeRad);

	public double LongitudeDeg => Globals.ToDegrees(LongitudeRad);

	public double Altitude
	{
		[CompilerGenerated]
		get
		{
			return m_Exception;
		}
		[CompilerGenerated]
		set
		{
			m_Exception = value;
		}
	}

	public Geo(Geo geo_0)
	{
		LatitudeRad = geo_0.LatitudeRad;
		LongitudeRad = geo_0.LongitudeRad;
		Altitude = geo_0.Altitude;
	}

	public Geo(double double_0, double double_1, double double_2)
	{
		LatitudeRad = double_0;
		LongitudeRad = double_1;
		Altitude = double_2;
	}

	public Geo(Eci eci_0, Julian julian_0)
		: this(eci_0.Position, (Globals.AcTan(eci_0.Position.Y, eci_0.Position.X) - julian_0.ToGmst()) % (Math.PI * 2.0))
	{
	}

	private Geo(Vector vector_0, double double_0)
	{
		double_0 %= Math.PI * 2.0;
		if (double_0 < 0.0)
		{
			double_0 += Math.PI * 2.0;
		}
		double num = Math.Sqrt(Globals.Sqr(vector_0.X) + Globals.Sqr(vector_0.Y));
		double num2 = 0.006694317778266723;
		double num3 = Globals.AcTan(vector_0.Z, num);
		double num4;
		double num5;
		do
		{
			num4 = num3;
			num5 = 1.0 / Math.Sqrt(1.0 - num2 * Globals.Sqr(Math.Sin(num4)));
			num3 = Globals.AcTan(vector_0.Z + 6378.135 * num5 * num2 * Math.Sin(num4), num);
		}
		while (Math.Abs(num3 - num4) > 1E-07);
		LatitudeRad = num3;
		LongitudeRad = double_0;
		Altitude = num / Math.Cos(num3) - 6378.135 * num5;
	}

	public override string ToString()
	{
		bool flag = LatitudeRad >= 0.0;
		bool flag2 = LongitudeRad >= 0.0;
		return string.Concat(string.Format(CultureInfo.CurrentCulture, "{0:00.0}{1} ", Math.Abs(LatitudeDeg), flag ? 'N' : 'S') + string.Format(CultureInfo.CurrentCulture, "{0:000.0}{1} ", Math.Abs(LongitudeDeg), flag2 ? 'E' : 'W'), string.Format(CultureInfo.CurrentCulture, "{0:F0}m", Altitude * 1000.0));
	}
}
