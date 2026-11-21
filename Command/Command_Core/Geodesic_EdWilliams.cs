using System;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Geodesic_EdWilliams
{
	public static void CircleFromPoint(double double_0, double double_1, double double_2, int int_0, ref Geodesic_Vincenty.Point3D[] point3D_0)
	{
		if (int_0 < 3)
		{
			throw new Exception("点数量不足");
		}
		double double_3 = Geodesic_Vincenty.SetupInvocation(double_1);
		point3D_0 = new Geodesic_Vincenty.Point3D[int_0 - 1 + 1];
		double double_4 = 0.0;
		double num = 360.0 / (double)int_0;
		int num2 = int_0 - 1;
		for (int i = 0; i <= num2; i++)
		{
			point3D_0[i].Z = 0.0;
			CalcPoint_Williams(ref double_3, ref double_0, ref point3D_0[i].X, ref point3D_0[i].Y, ref double_2, ref double_4);
			double_4 += num;
		}
	}

	public static void CalcPoint_Williams(ref double double_0, ref double double_1, ref double double_2, ref double double_3, ref double double_4, ref double double_5)
	{
		double num = double_4 / 3441.6865234375;
		double num6 = double_5 * 0.0174532925199433;
		double num7 = double_1 * 0.0174532925199433;
		double num8 = double_0 * 0.0174532925199433;
		double num9 = Math.Sin(num7);
		double num10 = Math.Cos(num7);
		double num11 = Math.Sin(num);
		double num12 = Math.Cos(num);
		try
		{
			double num13 = Math.Asin(num9 * num12 + num10 * num11 * Math.Cos(num6));
			double num2 = Math.Atan2(Math.Sin(num6) * num11 * num10, num12 - num9 * Math.Sin(num13));
			double num3 = num8 + num2 + Math.PI;
			double num4 = 6.28318530717959;
			double num5 = num3 - num4 * (double)(int)Math.Round(num3 / num4);
			if (num5 < 0.0)
			{
				num5 += num4;
			}
			num5 -= Math.PI;
			double_2 = num5 * 57.2957795130823;
			double_3 = num13 * 57.2957795130823;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void CalcPoint_Williams(ref double double_0, ref double double_1, ref double double_2, ref double double_3, ref float float_0, ref double double_4)
	{
		try
		{
			double num = float_0 / 3441.6865f;
			double num6 = double_4 * 0.0174532925199433;
			double num7 = double_1 * 0.0174532925199433;
			double num8 = double_0 * 0.0174532925199433;
			double num9 = Math.Sin(num7);
			double num10 = Math.Cos(num7);
			double num11 = Math.Sin(num);
			double num12 = Math.Cos(num);
			double num13 = Math.Asin(num9 * num12 + num10 * num11 * Math.Cos(num6));
			double num2 = Math.Atan2(Math.Sin(num6) * num11 * num10, num12 - num9 * Math.Sin(num13));
			double num3 = num8 + num2 + Math.PI;
			double num4 = 6.28318530717959;
			double num5 = num3 - num4 * (double)(int)Math.Round(num3 / num4);
			if (num5 < 0.0)
			{
				num5 += num4;
			}
			num5 -= Math.PI;
			double_2 = num5 * 57.2957795130823;
			double_3 = num13 * 57.2957795130823;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_ = Debugger.IsAttached;
			Math2.CalcPoint_Vincenty(double_0, double_1, ref double_2, ref double_3, float_0, double_4);
			ProjectData.ClearProjectError();
		}
	}

	public static void CalcPoint_Williams(ref double double_0, ref double double_1, ref double double_2, ref double double_3, ref int int_0, ref int int_1)
	{
		try
		{
			double num = (float)int_0 / 3441.6865f;
			double num6 = (double)int_1 * 0.0174532925199433;
			double num7 = double_1 * 0.0174532925199433;
			double num8 = double_0 * 0.0174532925199433;
			double num9 = Math.Sin(num7);
			double num10 = Math.Cos(num7);
			double num11 = Math.Sin(num);
			double num12 = Math.Cos(num);
			double num13 = Math.Asin(num9 * num12 + num10 * num11 * Math.Cos(num6));
			double num2 = Math.Atan2(Math.Sin(num6) * num11 * num10, num12 - num9 * Math.Sin(num13));
			double num3 = num8 + num2 + Math.PI;
			double num4 = 6.28318530717959;
			double num5 = num3 - num4 * (double)(int)Math.Round(num3 / num4);
			if (num5 < 0.0)
			{
				num5 += num4;
			}
			num5 -= Math.PI;
			double_2 = num5 * 57.2957795130823;
			double_3 = num13 * 57.2957795130823;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_ = Debugger.IsAttached;
			Math2.CalcPoint_Vincenty(double_0, double_1, ref double_2, ref double_3, int_0, int_1);
			ProjectData.ClearProjectError();
		}
	}

	public static void CalcPoint_Williams(ref double double_0, ref double double_1, ref double double_2, ref double double_3, ref double double_4, ref float float_0)
	{
		try
		{
			double num = double_4 / 3441.6865234375;
			double num6 = (double)float_0 * 0.0174532925199433;
			double num7 = double_1 * 0.0174532925199433;
			double num8 = double_0 * 0.0174532925199433;
			double num9 = Math.Sin(num7);
			double num10 = Math.Cos(num7);
			double num11 = Math.Sin(num);
			double num12 = Math.Cos(num);
			double num13 = Math.Asin(num9 * num12 + num10 * num11 * Math.Cos(num6));
			double num2 = Math.Atan2(Math.Sin(num6) * num11 * num10, num12 - num9 * Math.Sin(num13));
			double num3 = num8 + num2 + Math.PI;
			double num4 = 6.28318530717959;
			double num5 = num3 - num4 * (double)(int)Math.Round(num3 / num4);
			if (num5 < 0.0)
			{
				num5 += num4;
			}
			num5 -= Math.PI;
			double_2 = num5 * 57.2957795130823;
			double_3 = num13 * 57.2957795130823;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_ = Debugger.IsAttached;
			Math2.CalcPoint_Vincenty(double_0, double_1, ref double_2, ref double_3, double_4, float_0);
			ProjectData.ClearProjectError();
		}
	}

	public static void CalcPoint_Williams_NoRef(double double_0, double double_1, ref double double_2, ref double double_3, ref double double_4, ref float float_0)
	{
		try
		{
			double num = double_4 / 3441.6865234375;
			double num6 = (double)float_0 * 0.0174532925199433;
			double num7 = double_1 * 0.0174532925199433;
			double num8 = double_0 * 0.0174532925199433;
			double num9 = Math.Sin(num7);
			double num10 = Math.Cos(num7);
			double num11 = Math.Sin(num);
			double num12 = Math.Cos(num);
			double num13 = Math.Asin(num9 * num12 + num10 * num11 * Math.Cos(num6));
			double num2 = Math.Atan2(Math.Sin(num6) * num11 * num10, num12 - num9 * Math.Sin(num13));
			double num3 = num8 + num2 + Math.PI;
			double num4 = 6.28318530717959;
			double num5 = num3 - num4 * (double)(int)Math.Round(num3 / num4);
			if (num5 < 0.0)
			{
				num5 += num4;
			}
			num5 -= Math.PI;
			double_2 = num5 * 57.2957795130823;
			double_3 = num13 * 57.2957795130823;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_ = Debugger.IsAttached;
			Math2.CalcPoint_Vincenty(double_0, double_1, ref double_2, ref double_3, double_4, float_0);
			ProjectData.ClearProjectError();
		}
	}

	public static void CalcPoint_Williams(double double_0, double double_1, ref double double_2, ref double double_3, float float_0, float float_1)
	{
		try
		{
			double num = float_0 / 3441.6865f;
			double num6 = (double)float_1 * 0.0174532925199433;
			double num7 = double_1 * 0.0174532925199433;
			double num8 = double_0 * 0.0174532925199433;
			double num9 = Math.Sin(num7);
			double num10 = Math.Cos(num7);
			double num11 = Math.Sin(num);
			double num12 = Math.Cos(num);
			double num13 = Math.Asin(num9 * num12 + num10 * num11 * Math.Cos(num6));
			double num2 = Math.Atan2(Math.Sin(num6) * num11 * num10, num12 - num9 * Math.Sin(num13));
			double num3 = num8 + num2 + Math.PI;
			double num4 = 6.28318530717959;
			if (double.IsNaN(num2))
			{
				Math2.CalcPoint_Vincenty(double_0, double_1, ref double_2, ref double_3, float_0, float_1);
				return;
			}
			double num5 = num3 - num4 * (double)(int)Math.Round(num3 / num4);
			if (num5 < 0.0)
			{
				num5 += num4;
			}
			num5 -= Math.PI;
			double_2 = num5 * 57.2957795130823;
			double_3 = num13 * 57.2957795130823;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Math2.CalcPoint_Vincenty(double_0, double_1, ref double_2, ref double_3, float_0, float_1);
			ProjectData.ClearProjectError();
		}
	}

	public static void CalcPoint_Williams(double double_0, double double_1, ref double double_2, ref double double_3, float float_0, int int_0)
	{
		double num = float_0 / 3441.6865f;
		double num6 = (double)int_0 * 0.0174532925199433;
		double num7 = double_1 * 0.0174532925199433;
		double num8 = double_0 * 0.0174532925199433;
		double num9 = Math.Sin(num7);
		double num10 = Math.Cos(num7);
		double num11 = Math.Sin(num);
		double num12 = Math.Cos(num);
		try
		{
			double num13 = Math.Asin(num9 * num12 + num10 * num11 * Math.Cos(num6));
			double num2 = Math.Atan2(Math.Sin(num6) * num11 * num10, num12 - num9 * Math.Sin(num13));
			double num3 = num8 + num2 + Math.PI;
			double num4 = 6.28318530717959;
			double num5 = num3 - num4 * (double)(int)Math.Round(num3 / num4);
			if (num5 < 0.0)
			{
				num5 += num4;
			}
			num5 -= Math.PI;
			double_2 = num5 * 57.2957795130823;
			double_3 = num13 * 57.2957795130823;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_ = Debugger.IsAttached;
			Math2.CalcPoint_Vincenty(double_0, double_1, ref double_2, ref double_3, float_0, int_0);
			ProjectData.ClearProjectError();
		}
	}
}
