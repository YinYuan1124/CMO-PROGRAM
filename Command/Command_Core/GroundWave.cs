using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class GroundWave
{
	internal static double RunInvocation(double double_0, double double_1, double double_2, int int_0)
	{
		double num = 2.094395E-08 * double_2;
		double num2 = 1.0;
		double num3 = 2.0 * num * double_0;
		if (int_0 == 2)
		{
			int num4 = 1;
			do
			{
				if (!(num3 < 0.1))
				{
					num2 *= 1.0 + 1.5 * ((1.0 - num3 * num3) * Math.Sin(num3) - num3 * Math.Cos(num3)) / num3 / num3 / num3;
				}
				else
				{
					double num5 = num3 * num3;
					num2 *= num5 * (0.2 - num5 * (0.001071429 + num5 * 0.0002645503));
				}
				num3 = 2.0 * num * double_1;
				num4++;
			}
			while (num4 <= 2);
		}
		else
		{
			int num6 = 1;
			do
			{
				if (!(num3 < 0.1))
				{
					num2 *= 1.0 + 3.0 * (Math.Sin(num3) - num3 * Math.Cos(num3)) / num3 / num3 / num3;
				}
				else
				{
					double num7 = num3 * num3;
					num2 *= 2.0 - num7 * (0.1 + num7 * 0.003571429);
				}
				num3 = 2.0 * num * double_1;
				num6++;
			}
			while (num6 <= 2);
		}
		double num8 = num * num * num2;
		if (num8 < 1E-70)
		{
			return 1000.0;
		}
		return 169.542 + 10.0 * Math.Log10(num8);
	}

	public static void Main_0()
	{
		Console.WriteLine(RunInvocation(10.0, 10.0, 6000000.0, 1));
	}
}
