using System;
using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public sealed class Site
{
	[CompilerGenerated]
	private string m_TokenMerchant;

	[CompilerGenerated]
	private Geo indexerMerchant;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return m_TokenMerchant;
		}
		[CompilerGenerated]
		private set
		{
			m_TokenMerchant = value;
		}
	}

	public double LatitudeRad => Geo.LatitudeRad;

	public double LongitudeRad => Geo.LongitudeRad;

	public double LatitudeDeg => Geo.LatitudeDeg;

	public double LongitudeDeg => Geo.LongitudeDeg;

	public double Altitude => Geo.Altitude;

	public Geo Geo
	{
		[CompilerGenerated]
		get
		{
			return indexerMerchant;
		}
		[CompilerGenerated]
		private set
		{
			indexerMerchant = value;
		}
	}

	public Site(double double_0, double double_1, double double_2, string string_0 = "")
	{
		Geo = new Geo(Globals.ToRadians(double_0), Globals.ToRadians(double_1), double_2);
		Name = string_0;
	}

	public Site(Geo geo_0)
	{
		Geo = new Geo(geo_0);
	}

	[Obsolete("Use PositionEci()")]
	public EciTime GetPosition(Julian julian_0)
	{
		return new EciTime(Geo, julian_0);
	}

	public EciTime PositionEci(Julian julian_0)
	{
		return new EciTime(Geo, julian_0);
	}

	public EciTime PositionEci(DateTime dateTime_0)
	{
		return new EciTime(Geo, new Julian(dateTime_0));
	}

	public TopoTime GetLookAngle(EciTime eciTime_0)
	{
		Julian date = eciTime_0.Date;
		EciTime eciTime = PositionEci(date);
		Vector vector = new Vector(eciTime_0.Velocity.X - eciTime.Velocity.X, eciTime_0.Velocity.Y - eciTime.Velocity.Y, eciTime_0.Velocity.Z - eciTime.Velocity.Z);
		double double_ = eciTime_0.Position.X - eciTime.Position.X;
		double num = eciTime_0.Position.Y - eciTime.Position.Y;
		double num4 = eciTime_0.Position.Z - eciTime.Position.Z;
		double double_2 = Math.Sqrt(Globals.Sqr(double_) + Globals.Sqr(num) + Globals.Sqr(num4));
		Vector vector2 = new Vector(double_, num, num4, double_2);
		double num5 = date.ToLmst(LongitudeRad);
		double num6 = Math.Sin(LatitudeRad);
		double num7 = Math.Cos(LatitudeRad);
		double num8 = Math.Sin(num5);
		double num9 = Math.Cos(num5);
		double num10 = num6 * num9 * vector2.X + num6 * num8 * vector2.Y - num7 * vector2.Z;
		double num11 = (0.0 - num8) * vector2.X + num9 * vector2.Y;
		double num2 = num7 * num9 * vector2.X + num7 * num8 * vector2.Y + num6 * vector2.Z;
		double num3 = Math.Atan((0.0 - num11) / num10);
		if (num10 > 0.0)
		{
			num3 += Math.PI;
		}
		if (num3 < 0.0)
		{
			num3 += Math.PI * 2.0;
		}
		double double_3 = Math.Asin(num2 / vector2.W);
		double double_4 = (vector2.X * vector.X + vector2.Y * vector.Y + vector2.Z * vector.Z) / vector2.W;
		return new TopoTime(num3, double_3, vector2.W, double_4, eciTime_0.Date);
	}

	public override string ToString()
	{
		return Geo.ToString();
	}
}
