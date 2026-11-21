using System;
using System.Runtime.InteropServices;
using CSMaterial;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class SatelliteLinkModel
{
	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_Agaz_004032(double double_0, double double_1, double double_2, double double_3);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_Anuages_004024(double double_0, double double_1, double double_2);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_Apluie_004064(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_Scintillation_004056(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_coindice_refraction_004016(double double_0, double double_1);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_contenu_eau_liquide_004024(double double_0, double double_1, double double_2);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_hauteur_pluie_004016(double double_0, double double_1);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_intensite_pluie_004024(double double_0, double double_1, double double_2);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_temperature_004016(double double_0, double double_1);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_vapeur_d_eau_004016(double double_0, double double_1);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_contenu_vapeur_eau_004024(double double_0, double double_1, double double_2);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern double _Calcule_Agaz_depassee_004040(double double_0, double double_1, double double_2, double double_3, double double_4);

	[DllImport("propa", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern long _version_00400();

	internal static double ChangeWriter(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7, double double_8)
	{
		if (double_7 >= 0.0 && double_7 <= 100.0)
		{
			if (double_2 <= 99.0 && double_2 >= 50.0)
			{
				if (double_3 < 1.0)
				{
					return double.MaxValue;
				}
				double num = _Calcule_Agaz_004032(double_0, double_3 * 0.0174532925199433, _Calcule_temperature_004016(double_4, double_5), _Calcule_vapeur_d_eau_004016(double_4, double_5));
				double num2 = 100.0 - double_2;
				double num3 = _Calcule_Apluie_004064(double_4, double_0, double_3 * 0.0174532925199433, num2, double_1 / 1000.0, _Calcule_hauteur_pluie_004016(double_4, double_5), _Calcule_intensite_pluie_004024(double_4, double_5, num2), double_6);
				double num4 = _Calcule_Anuages_004024(double_0, double_3 * 0.0174532925199433, _Calcule_contenu_eau_liquide_004024(double_4, double_5, num2));
				double x = _Calcule_Scintillation_004056(_Calcule_coindice_refraction_004016(double_4, double_5), double_0, double_3 * 0.0174532925199433, num2, double_1 / 1000.0, double_7 / 100.0, double_8);
				return num + Math.Sqrt(Math.Pow(num3 + num4, 2.0) + Math.Pow(x, 2.0));
			}
			throw new Exception("Reliability must be in [50.0;99.9]");
		}
		throw new Exception("Antenna efficiency must be in [0;100]");
	}

	internal static double InitWriter(double double_0, double double_1)
	{
		return 92.4477832218834 + 20.0 * Math.Log10(double_0) + 20.0 * Math.Log10(double_1);
	}

	internal static double CheckWriter(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7, double double_8, double double_9, double double_10)
	{
		double double_11 = 0.0;
		double double_12 = 0.0;
		Geodesic_Vincenty.ApproxElevationRange(double_0, double_1, double_2, double_3, double_4, double_5, ref double_11, ref double_12);
		return ChangeWriter(double_6, double_2, double_7, double_11, double_0, double_1, double_8, double_9, double_10) + InitWriter(double_6, double_12);
	}

	internal static double ConcatWriter(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7, double double_8, double double_9)
	{
		double num = Math.Pow(10.0, double_9 / 10.0);
		double double_10 = 299792458.0 / (double_6 * 1000000000.0) / Math.Sqrt(Math.Pow(3.14159265358979, 2.0) / num);
		double double_11 = 0.0;
		double double_12 = 0.0;
		Geodesic_Vincenty.ApproxElevationRange(double_0, double_1, double_2, double_3, double_4, double_5, ref double_11, ref double_12);
		return ChangeWriter(double_6, double_2, double_7, double_11, double_0, double_1, double_8, 100.0, double_10) + InitWriter(double_6, double_12);
	}

	internal static double InterruptWriter(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7, double double_8, double double_9)
	{
		return ChangeWriter(double_0, double_2, double_3, double_4, double_5, double_6, double_7, double_8, double_9) + InitWriter(double_0, double_1);
	}

	public static void Main__()
	{
		Console.WriteLine(_Calcule_Agaz_004032(30.0, 38.4 * CSMath.PI_dividedBy_180, _Calcule_temperature_004016(43.4, 1.4), _Calcule_vapeur_d_eau_004016(43.4, 1.4)));
		Console.WriteLine(InterruptWriter(21.0, 37901.8, 300.0, 99.0, 30.0, 43.4, 1.4, 45.0, 70.0, 2.4));
		double double_ = 30.0;
		double num = 0.009993081933333333;
		double num2 = 2.0;
		do
		{
			double num3 = Math.Pow(3.14159265358979, 2.0) / Math.Pow(num / num2, 2.0) / 0.7;
			double double_2 = num / Math.Sqrt(Math.Pow(3.14159265358979, 2.0) / num3);
			Console.WriteLine(num2 + " " + ConcatWriter(21.0, 5.0, 300.0, 25.0, 5.0, 300000.0, double_, 99.0, 45.0, num2) + " " + Conversions.ToString(CheckWriter(21.0, 5.0, 300.0, 25.0, 5.0, 300000.0, double_, 99.0, 45.0, 70.0, double_2)));
			num2 += 0.1;
		}
		while (num2 <= 10.0);
		double num4 = -180.0;
		do
		{
			num2 = -90.0;
			do
			{
				Console.WriteLine(num2 + " " + num4 + " " + _Calcule_hauteur_pluie_004016(num2, num4));
				num2 += 1.0;
			}
			while (num2 <= 90.0);
			num4 += 1.0;
		}
		while (num4 <= 180.0);
	}
}
