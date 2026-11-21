using System;

namespace Command_Core;

public sealed class AltBand
{
	public float MaxAlt;

	public float MinAlt;

	public int Speed_Loiter;

	public int Speed_Cruise;

	public long? Speed_Full;

	public long? Speed_Flank;

	public float Consumption_Loiter;

	public float Consumption_Cruise;

	public float? Consumption_Full;

	public float? Consumption_Flank;

	public Lazy<int> MaxSpeed;

	private int MapReader()
	{
		if (Speed_Flank.HasValue)
		{
			return (int)Speed_Flank.Value;
		}
		if (Speed_Full.HasValue)
		{
			return (int)Speed_Full.Value;
		}
		return Speed_Cruise;
	}

	private AltBand()
	{
		MaxSpeed = new Lazy<int>(MapReader);
	}

	public AltBand(float float_0, float float_1)
	{
		MaxSpeed = new Lazy<int>(MapReader);
		MaxAlt = float_0;
		MinAlt = float_1;
	}
}
