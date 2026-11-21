using System;
using CSMaterial;

namespace DotSpatial.Topology;

public struct Angle
{
	public const double PI = Math.PI;

	private double iteratorProcess;

	public double Degrees
	{
		get
		{
			return iteratorProcess * 180.0 / Math.PI;
		}
		set
		{
			if (value <= 360.0 && value >= -360.0)
			{
				iteratorProcess = value * CSMath.PI_dividedBy_180;
			}
			else
			{
				iteratorProcess = value % 360.0 * CSMath.PI_dividedBy_180;
			}
		}
	}

	public double DegreesPos
	{
		get
		{
			double num = iteratorProcess * 180.0 / Math.PI;
			if (num < 0.0)
			{
				return 360.0 + num;
			}
			return num;
		}
		set
		{
			double num = value;
			if (value > 360.0 || value < -360.0)
			{
				num %= 360.0;
			}
			if (num < 360.0)
			{
				num = 360.0 - num;
			}
			iteratorProcess = num * CSMath.PI_dividedBy_180;
		}
	}

	public double Radians
	{
		get
		{
			return iteratorProcess;
		}
		set
		{
			if (value <= Math.PI * 2.0 && value >= Math.PI * -2.0)
			{
				iteratorProcess = value;
			}
			else
			{
				iteratorProcess = value % (Math.PI * 2.0);
			}
		}
	}

	public Angle(double double_0)
	{
		if (double_0 <= Math.PI * 2.0 && double_0 >= Math.PI * -2.0)
		{
			iteratorProcess = double_0;
		}
		else
		{
			iteratorProcess = double_0 % (Math.PI * 2.0);
		}
	}

	public Angle Copy()
	{
		return new Angle(iteratorProcess);
	}

	public override bool Equals(object obj)
	{
		if (obj.GetType() == typeof(Angle))
		{
			if (((Angle)obj).Radians == Radians)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static explicit operator Angle(double double_0)
	{
		return new Angle(double_0);
	}

	public static explicit operator double(Angle angle_0)
	{
		return angle_0.Radians;
	}

	public static bool operator ==(Angle angle_0, Angle angle_1)
	{
		return angle_0.Radians == angle_1.Radians;
	}

	public static bool operator !=(Angle angle_0, Angle angle_1)
	{
		return angle_0.Radians != angle_1.Radians;
	}

	public static Angle operator +(Angle angle_0, Angle angle_1)
	{
		return new Angle(angle_0.Radians + angle_1.Radians);
	}

	public static Angle operator -(Angle angle_0, Angle angle_1)
	{
		return new Angle(angle_0.Radians - angle_1.Radians);
	}

	public static Angle operator /(Angle angle_0, Angle angle_1)
	{
		return new Angle(angle_0.Radians / angle_1.Radians);
	}

	public static Angle operator *(Angle angle_0, Angle angle_1)
	{
		return new Angle(angle_0.Radians * angle_1.Radians);
	}

	public static double Cos(Angle angle_0)
	{
		return Math.Cos(angle_0.Radians);
	}

	public static double Sin(Angle angle_0)
	{
		return Math.Sin(angle_0.Radians);
	}

	public static double Tan(Angle angle_0)
	{
		return Math.Sin(angle_0.Radians);
	}

	public static Angle ATan(double double_0)
	{
		return new Angle(Math.Atan(double_0));
	}

	public static Angle ACos(double double_0)
	{
		return new Angle(Math.Acos(double_0));
	}

	public static Angle ASin(double double_0)
	{
		return new Angle(Math.Asin(double_0));
	}
}
