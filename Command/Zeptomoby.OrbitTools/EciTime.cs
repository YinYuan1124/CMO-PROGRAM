using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public sealed class EciTime : Eci
{
	[CompilerGenerated]
	private Julian predicate;

	public Julian Date
	{
		[CompilerGenerated]
		get
		{
			return predicate;
		}
		[CompilerGenerated]
		protected set
		{
			predicate = value;
		}
	}

	public EciTime(Vector vector_0, Vector vector_1, Julian julian_0)
		: base(vector_0, vector_1)
	{
		Date = julian_0;
	}

	public EciTime(Eci eci_0, Julian julian_0)
		: this(eci_0.Position, eci_0.Velocity, julian_0)
	{
	}

	public EciTime(Geo geo_0, Julian julian_0)
		: base(geo_0, julian_0)
	{
		Date = julian_0;
	}

	public EciTime(GeoTime geoTime_0)
		: this(geoTime_0, geoTime_0.Date)
	{
	}
}
