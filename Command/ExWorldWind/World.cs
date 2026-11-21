using System;

namespace ExWorldWind;

public class World
{
	public static Angle ApproxAngularDistance(Angle angle_0, Angle angle_1, Angle angle_2, Angle angle_3)
	{
		Angle angle = angle_3 - angle_1;
		double num = Math.Sin((angle_2 - angle_0).Radians * 0.5);
		double num2 = Math.Sin(angle.Radians * 0.5);
		double d = num * num + Math.Cos(angle_0.Radians) * Math.Cos(angle_2.Radians) * num2 * num2;
		return Angle.FromRadians(2.0 * Math.Asin(Math.Min(1.0, Math.Sqrt(d))));
	}

	public static void smethod_0(float float_0, Angle angle_0, Angle angle_1, Angle angle_2, Angle angle_3, Angle angle_4, out Angle angle_5, out Angle angle_6)
	{
		double num = Math.Sin(angle_4.Radians);
		double num2 = Math.Cos(angle_0.Radians);
		double num3 = Math.Cos(angle_2.Radians);
		double num4 = Math.Sin((double)(1f - float_0) * angle_4.Radians) / num;
		double num5 = Math.Sin((double)float_0 * angle_4.Radians) / num;
		double num6 = num4 * num2 * Math.Cos(angle_1.Radians) + num5 * num3 * Math.Cos(angle_3.Radians);
		double num7 = num4 * num2 * Math.Sin(angle_1.Radians) + num5 * num3 * Math.Sin(angle_3.Radians);
		double y = num4 * Math.Sin(angle_0.Radians) + num5 * Math.Sin(angle_2.Radians);
		angle_5 = Angle.FromRadians(Math.Atan2(y, Math.Sqrt(num6 * num6 + num7 * num7)));
		angle_6 = Angle.FromRadians(Math.Atan2(num7, num6));
	}
}
