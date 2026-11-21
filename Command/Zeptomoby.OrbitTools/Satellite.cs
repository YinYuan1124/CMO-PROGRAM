using System;
using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public sealed class Satellite
{
	[CompilerGenerated]
	private string m_StrategyMerchant;

	[CompilerGenerated]
	private Orbit configurationMerchant;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return m_StrategyMerchant;
		}
		[CompilerGenerated]
		private set
		{
			m_StrategyMerchant = value;
		}
	}

	public Orbit Orbit
	{
		[CompilerGenerated]
		get
		{
			return configurationMerchant;
		}
		[CompilerGenerated]
		private set
		{
			configurationMerchant = value;
		}
	}

	public Satellite(Tle tle_0, string string_0 = "")
	{
		Orbit = new Orbit(tle_0);
		if (string_0 == "")
		{
			Name = Orbit.SatName;
		}
		else
		{
			Name = string_0;
		}
	}

	public EciTime PositionEci(DateTime dateTime_0)
	{
		return Orbit.PositionEci(dateTime_0);
	}

	public EciTime PositionEci(double double_0)
	{
		return Orbit.PositionEci(double_0);
	}
}
