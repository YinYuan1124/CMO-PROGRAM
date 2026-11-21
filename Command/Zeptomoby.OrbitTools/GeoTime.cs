namespace Zeptomoby.OrbitTools;

public sealed class GeoTime : Geo
{
	public Julian Date { get; private set; }

	public GeoTime(double double_0, double double_1, double double_2, Julian julian_0)
		: base(double_0, double_1, double_2)
	{
		Date = julian_0;
	}

	public GeoTime(Geo geo_0, Julian julian_0)
		: base(geo_0)
	{
		Date = julian_0;
	}

	public GeoTime(EciTime eciTime_0)
		: base(eciTime_0, eciTime_0.Date)
	{
		Date = eciTime_0.Date;
	}

	public GeoTime(Eci eci_0, Julian julian_0)
		: base(eci_0, julian_0)
	{
		Date = julian_0;
	}
}
