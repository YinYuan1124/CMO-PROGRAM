using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public sealed class TopoTime : Topo
{
	[CompilerGenerated]
	private Julian visitorMerchant;

	public Julian Date
	{
		[CompilerGenerated]
		get
		{
			return visitorMerchant;
		}
		[CompilerGenerated]
		private set
		{
			visitorMerchant = value;
		}
	}

	public TopoTime(Topo topo_0, Julian julian_0)
		: base(topo_0.AzimuthRad, topo_0.ElevationRad, topo_0.Range, topo_0.RangeRate)
	{
		Date = julian_0;
	}

	public TopoTime(double double_0, double double_1, double double_2, double double_3, Julian julian_0)
		: base(double_0, double_1, double_2, double_3)
	{
		Date = julian_0;
	}
}
