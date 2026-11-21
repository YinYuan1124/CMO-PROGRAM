using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class SxPxTime
{
	internal static double DestroyWatcher(ref double double_0)
	{
		double_0 -= 1.0;
		double num = RadarModel.PrintStub(double_0 / 100.0);
		double num2 = 2.0 - num + (double)RadarModel.PrintStub(num / 4.0);
		return (double)(RadarModel.PrintStub(365.25 * double_0) + RadarModel.PrintStub(428.4014)) + 1720994.5 + num2;
	}

	internal static double ComputeWatcher(ref double double_0)
	{
		double num = RadarModel.PrintStub(double_0 * 0.001);
		num = ((num < 57.0) ? (num + 2000.0) : (num + 1900.0));
		double num2 = double_0 - (double)RadarModel.PrintStub(double_0 * 0.001) * 1000.0;
		return DestroyWatcher(ref num) + num2;
	}

	internal static double PatchWatcher(ref double double_0, ref double double_1)
	{
		double num = RadarModel.PrintStub(double_0 * 0.001);
		num = ((num < 57.0) ? (num + 2000.0) : (num + 1900.0));
		double num2 = double_0 - (double)RadarModel.PrintStub(double_0 * 0.001) * 1000.0;
		double num3 = num2 - (double)RadarModel.PrintStub(num2);
		num2 = RadarModel.PrintStub(num2);
		double num4 = DestroyWatcher(ref num) + num2;
		double num5 = (num4 - 2451545.0) / 36525.0;
		double num6 = 24110.54841 + num5 * (8640184.812866 + num5 * (0.093104 - num5 * 6.2E-06));
		num6 = SxPxMath.CustomizeWatcher(num6 + 86636.555366976 * num3, 86400.0);
		double result = 6.28318530717958 * num6 / 86400.0;
		double_1 = num4 - 2433281.5 + num3;
		return result;
	}

	internal static double SelectWatcher(ref DateTime dateTime_0)
	{
		double double_ = dateTime_0.Year;
		return DestroyWatcher(ref double_) + (double)LogoutWatcher(dateTime_0.Year, dateTime_0.Month, dateTime_0.Day) + CallWatcher(dateTime_0.Hour, dateTime_0.Minute, dateTime_0.Second) + 5.787037E-06;
	}

	internal static double CallWatcher(int int_0, int int_1, double double_0)
	{
		double num = int_0;
		double num2 = int_1;
		return (num + (num2 + double_0 / 60.0) / 60.0) / 24.0;
	}

	internal static int LogoutWatcher(int int_0, int int_1, int int_2)
	{
		int[] array = new int[12]
		{
			31, 28, 31, 30, 31, 30, 31, 31, 30, 31,
			30, 31
		};
		int num = 0;
		for (int i = 0; i < int_1 - 1; i++)
		{
			num += array[i];
		}
		num += int_2;
		if (((int_0 % 4 == 0) & ((int_0 % 100 != 0) | (int_0 % 400 == 0))) && int_1 > 2)
		{
			num++;
		}
		return num;
	}

	internal static double ViewWatcher(double double_0)
	{
		double num = SxPxMath.DeleteWatcher(double_0 + 0.5);
		double_0 -= num;
		double num2 = (double_0 - 2451545.0) / 36525.0;
		double num3 = 24110.54841 + num2 * (8640184.812866 + num2 * (0.093104 - num2 * 6.2E-06));
		num3 = SxPxMath.CustomizeWatcher(num3 + 86636.555366976 * num, 86400.0);
		return 6.28318530717958 * num3 / 86400.0;
	}

	internal static double ValidateWatcher(double double_0)
	{
		double num = (double_0 + 0.5) % 1.0;
		double num2 = (double_0 - 2451545.0 - num) / 36525.0;
		double num3 = 24110.54841 + num2 * (8640184.812866 + num2 * (0.093104 - num2 * 6.2E-06));
		num3 = (num3 + 86636.555366976 * num) % 86400.0;
		if (num3 < 0.0)
		{
			num3 += 86400.0;
		}
		return 6.28318530717958 * (num3 / 86400.0);
	}
}
