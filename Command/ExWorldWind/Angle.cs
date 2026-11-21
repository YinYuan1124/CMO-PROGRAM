using System;

namespace ExWorldWind;

public struct Angle
{
	public static readonly Angle NaN;

	[NonSerialized]
	public double Radians;

	public double Degrees
	{
		get
		{
			return MathEngine.RadiansToDegrees(Radians);
		}
		set
		{
			Radians = MathEngine.DegreesToRadians(value);
		}
	}

	public static Angle FromRadians(double double_0)
	{
		Angle result = default(Angle);
		result.Radians = double_0;
		return result;
	}

	public static Angle FromDegrees(double double_0)
	{
		Angle result = default(Angle);
		result.Radians = Math.PI * double_0 / 180.0;
		return result;
	}

	public static bool IsNaN(Angle angle_0)
	{
		return double.IsNaN(angle_0.Radians);
	}

	public static Angle operator +(Angle angle_0, Angle angle_1)
	{
		return FromRadians(angle_0.Radians + angle_1.Radians);
	}

	public static Angle operator -(Angle angle_0, Angle angle_1)
	{
		return FromRadians(angle_0.Radians - angle_1.Radians);
	}

	public static Angle operator *(Angle angle_0, double double_0)
	{
		return FromRadians(angle_0.Radians * double_0);
	}

	static Angle()
	{
		NaN = FromRadians(double.NaN);
	}
}
