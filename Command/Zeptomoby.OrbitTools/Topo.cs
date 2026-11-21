using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public class Topo
{
	[CompilerGenerated]
	private double singletonMerchant;

	[CompilerGenerated]
	private double m_RecordMerchant;

	[CompilerGenerated]
	private double exceptionMerchant;

	[CompilerGenerated]
	private double m_AttrMerchant;

	public double AzimuthRad
	{
		[CompilerGenerated]
		get
		{
			return singletonMerchant;
		}
		[CompilerGenerated]
		set
		{
			singletonMerchant = value;
		}
	}

	public double ElevationRad
	{
		[CompilerGenerated]
		get
		{
			return m_RecordMerchant;
		}
		[CompilerGenerated]
		set
		{
			m_RecordMerchant = value;
		}
	}

	public double AzimuthDeg => Globals.ToDegrees(AzimuthRad);

	public double ElevationDeg => Globals.ToDegrees(ElevationRad);

	public double Range
	{
		[CompilerGenerated]
		get
		{
			return exceptionMerchant;
		}
		[CompilerGenerated]
		set
		{
			exceptionMerchant = value;
		}
	}

	public double RangeRate
	{
		[CompilerGenerated]
		get
		{
			return m_AttrMerchant;
		}
		[CompilerGenerated]
		set
		{
			m_AttrMerchant = value;
		}
	}

	public Topo(double double_0, double double_1, double double_2, double double_3)
	{
		AzimuthRad = double_0;
		ElevationRad = double_1;
		Range = double_2;
		RangeRate = double_3;
	}
}
