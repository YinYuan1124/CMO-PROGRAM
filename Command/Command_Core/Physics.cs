using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Physics
{
	internal static double CreateStub(double double_0, double double_1)
	{
		double x = double_0 * 2.204622915;
		double num = Math.Log(double_1 * 3.280839895 / Math.Pow(x, 1.0 / 3.0)) / Math.Log(10.0);
		double num2 = -0.756579301809 + 1.3503424993 * num;
		double y = 1.9422502013 - 1.695898874 * num2 - 0.154159376846 * Math.Pow(num2, 2.0) + 0.5140607305 * Math.Pow(num2, 3.0) + 0.0988534365274 * Math.Pow(num2, 4.0) - 0.293912623038 * Math.Pow(num2, 5.0) - 0.0268112345019 * Math.Pow(num2, 6.0) + 0.10909749642 * Math.Pow(num2, 7.0) + 0.0016284676311 * Math.Pow(num2, 8.0) - 0.0214631030242 * Math.Pow(num2, 9.0) + 0.0001456723382 * Math.Pow(num2, 10.0) + 0.00167847752266 * Math.Pow(num2, 11.0);
		return Math.Pow(10.0, y);
	}

	internal static float CompareStub(double double_0, double double_1)
	{
		double num = 1718.0;
		double num2 = double_0 / 0.3048;
		double num3 = ((num2 <= 36152.0) ? (518.6 - 3.56 * num2 / 1000.0) : ((num2 >= 36152.0 && !(num2 > 82345.0)) ? 389.98 : ((num2 >= 82345.0 && !(num2 > 155348.0)) ? (389.98 + 1.645 * (num2 - 82345.0) / 1000.0) : ((num2 >= 155348.0 && !(num2 > 175346.0)) ? 508.788 : ((!(num2 >= 175346.0) || num2 > 262448.0) ? 508.788 : (508.788 - 2.46888 * (num2 - 175346.0) / 1000.0))))));
		double num4 = Math.Sqrt(1.4 * num * num3);
		num4 = num4 * 60.0 / 88.0;
		num4 *= 0.8689755962687;
		return (float)(double_1 / num4);
	}

	public static double ConvertMachToMetersPerSecond(double double_0, double double_1)
	{
		double num = CalculateSpeedOfSound(double_1);
		return double_0 * num;
	}

	public static double CalculateSpeedOfSound(double double_0)
	{
		double num = 288.15 + -0.0065 * double_0;
		return Math.Sqrt(401.87 * num);
	}

	internal static double ReadStub(int int_0, double double_0)
	{
		double num = CalculateAirDensity(int_0);
		return 0.5 * num * Math.Pow(double_0, 2.0);
	}

	internal static double DisableStub(double double_0)
	{
		return double_0 * 0.0208854342;
	}

	public static double CalculateAirDensity(int int_0)
	{
		Weather.TAtmosphere tAtmosphere = Weather.VisitDescriptor(Weather.TAtmosphereType.atm_ITU_R_Ref_Std, int_0);
		return tAtmosphere.Pressure * 100.0 / (287.058 * tAtmosphere.Temperature) + tAtmosphere.Rho / 1000.0;
	}
}
