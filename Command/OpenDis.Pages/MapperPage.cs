using System;
using System.Text;
using CSMaterial;

namespace OpenDis.Pages;

internal static class MapperPage
{
	private static double Clip(double double_0, double double_1, double double_2)
	{
		return Math.Min(Math.Max(double_0, double_1), double_2);
	}

	public static uint ConcatProcess(int int_0)
	{
		return (uint)(256 << int_0);
	}

	public static double InterruptProcess(double double_0, int int_0)
	{
		double_0 = Clip(double_0, -85.05112878, 85.05112878);
		return Math.Cos(double_0 * CSMath.PI_dividedBy_180) * 2.0 * Math.PI * 6378137.0 / (double)ConcatProcess(int_0);
	}

	public static double RemoveProcess(double double_0, int int_0, int int_1)
	{
		return InterruptProcess(double_0, int_0) * (double)int_1 / 0.0254;
	}

	public static void FindProcess(double double_0, double double_1, int int_0, out int int_1, out int int_2)
	{
		double_0 = Clip(double_0, -85.05112878, 85.05112878);
		double_1 = Clip(double_1, -180.0, 180.0);
		double num = (double_1 + 180.0) / 360.0;
		double num2 = Math.Sin(double_0 * CSMath.PI_dividedBy_180);
		double num3 = 0.5 - Math.Log((1.0 + num2) / (1.0 - num2)) / (Math.PI * 4.0);
		uint num4 = ConcatProcess(int_0);
		int_1 = (int)Clip(num * (double)num4 + 0.5, 0.0, num4 - 1);
		int_2 = (int)Clip(num3 * (double)num4 + 0.5, 0.0, num4 - 1);
	}

	public static void SetProcess(int int_0, int int_1, int int_2, out double double_0, out double double_1)
	{
		double num = ConcatProcess(int_2);
		double num2 = Clip(int_0, 0.0, num - 1.0) / num - 0.5;
		double num3 = 0.5 - Clip(int_1, 0.0, num - 1.0) / num;
		double_0 = 90.0 - 360.0 * Math.Atan(Math.Exp((0.0 - num3) * 2.0 * Math.PI)) / Math.PI;
		double_1 = 360.0 * num2;
	}

	public static void FillProcess(int int_0, int int_1, out int int_2, out int int_3)
	{
		int_2 = int_0 / 256;
		int_3 = int_1 / 256;
	}

	public static void CalculateProcess(int int_0, int int_1, out int int_2, out int int_3)
	{
		int_2 = int_0 * 256;
		int_3 = int_1 * 256;
	}

	public static string PopProcess(int int_0, int int_1, int int_2)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int num = int_2; num > 0; num--)
		{
			char c = '0';
			int num2 = 1 << num - 1;
			if ((int_0 & num2) != 0)
			{
				c = (char)(c + 1);
			}
			if ((int_1 & num2) != 0)
			{
				c = (char)(c + 1);
				c = (char)(c + 1);
			}
			stringBuilder.Append(c);
		}
		return stringBuilder.ToString();
	}

	public static void InstantiateProcess(string string_0, out int int_0, out int int_1, out int int_2)
	{
		int_1 = 0;
		int_0 = 0;
		int_2 = string_0.Length;
		for (int num = int_2; num > 0; num--)
		{
			int num2 = 1 << num - 1;
			switch (string_0[int_2 - num])
			{
			case '1':
				int_0 |= num2;
				break;
			case '2':
				int_1 |= num2;
				break;
			case '3':
				int_0 |= num2;
				int_1 |= num2;
				break;
			default:
				throw new ArgumentException("Invalid QuadKey digit sequence.");
			case '0':
				break;
			}
		}
	}
}
