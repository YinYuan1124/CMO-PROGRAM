using System;
using System.Collections.Generic;
using System.Linq;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace OpenDis.Common;

[StandardModule]
internal sealed class TemplateDic
{
	public static Dictionary<int, int> _MappingDic;

	public static Dictionary<int, float> mockDic;

	static TemplateDic()
	{
		_MappingDic = new Dictionary<int, int>();
		mockDic = new Dictionary<int, float>();
	}

	public static void IncludeClass()
	{
		_MappingDic.Add(500, 2100);
		_MappingDic.Add(1000, 2800);
		_MappingDic.Add(2000, 4000);
		_MappingDic.Add(3000, 4750);
		_MappingDic.Add(4000, 5300);
		_MappingDic.Add(5000, 5750);
		_MappingDic.Add(6000, 6125);
		_MappingDic.Add(7000, 6400);
		_MappingDic.Add(8000, 6700);
		_MappingDic.Add(9000, 6800);
		_MappingDic.Add(10000, 7020);
		_MappingDic.Add(11000, 7200);
		_MappingDic.Add(12000, 7300);
		mockDic.Add(500, 42f);
		mockDic.Add(1000, 41f);
		mockDic.Add(2000, 39f);
		mockDic.Add(3000, 37.5f);
		mockDic.Add(4000, 36f);
		mockDic.Add(5000, 33f);
		mockDic.Add(6000, 31.75f);
		mockDic.Add(7000, 28.25f);
		mockDic.Add(8000, 26f);
		mockDic.Add(9000, 24f);
		mockDic.Add(10000, 22.5f);
		mockDic.Add(11000, 20f);
		mockDic.Add(12000, 16f);
		mockDic.Add(13000, 14f);
		mockDic.Add(14000, 12f);
		mockDic.Add(15000, 10f);
	}

	public static float SearchClass(float float_0)
	{
		float num = (float)((double)float_0 * 1852.0 / 1000.0);
		if (num <= 500f)
		{
			return (float)((double)(float)Math.Sqrt((double)float_0 * 1852.0 * 9.81) * 1.94384);
		}
		int num2 = _MappingDic.Count - 1;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		for (int i = 0; i <= num2; i++)
		{
			int num7 = _MappingDic.Keys.ElementAtOrDefault(i);
			if (!((float)num7 <= num))
			{
				num3 = _MappingDic.Keys.ElementAtOrDefault(i - 1);
				num4 = _MappingDic.Values.ElementAtOrDefault(i - 1);
				num5 = num7;
				num6 = _MappingDic.Values.ElementAtOrDefault(i);
				break;
			}
		}
		float num8 = (num - (float)num3) / (float)(num5 - num3);
		return (float)((double)((float)num4 + (float)(num6 - num4) * num8) * 1.94384);
	}

	public static float EnableClass(float float_0)
	{
		float num = (float)((double)float_0 * 1852.0 / 1000.0);
		if (num <= 500f)
		{
			return 45f;
		}
		int num2 = mockDic.Count - 1;
		int num3 = 0;
		float num4 = 0f;
		int num5 = 0;
		float num6 = 0f;
		for (int i = 0; i <= num2; i++)
		{
			int num7 = mockDic.Keys.ElementAtOrDefault(i);
			if (!((float)num7 <= num))
			{
				num3 = mockDic.Keys.ElementAtOrDefault(i - 1);
				num4 = mockDic.Values.ElementAtOrDefault(i - 1);
				num5 = num7;
				num6 = mockDic.Values.ElementAtOrDefault(i);
				break;
			}
		}
		float num8 = (num - (float)num3) / (float)(num5 - num3);
		return (float)(double)(num4 + (num6 - num4) * num8);
	}

	public static double ChangeClass(double double_0, double double_1)
	{
		if (double_0 <= 500.0)
		{
			return 100000.0 * (double_0 / 500.0) / 1000.0;
		}
		double num = MathFunctions.DestroyRequest(45.0);
		double num2 = (6371.0 * Math.Pow(double_1, 2.0) * (-2.0 * Math.Sin(num) + Math.Sin(0.0 - double_0 / 6371.0 + num)) + Math.Sqrt(6371.0 * Math.Pow(double_1, 2.0) * (-1594738.67649728 * (-1.0 + Math.Cos(double_0 / 6371.0)) + 6371.0 * Math.Pow(double_1, 2.0) * Math.Pow(Math.Sin(0.0 - double_0 / 6371.0 + num), 2.0)))) / (2.0 * Math.Pow(double_1, 2.0) * Math.Sin(num));
		if (double.IsNaN(num2))
		{
			num2 = ((!(double_0 <= 12000.0)) ? 300.0 : ((!(double_0 <= 10000.0)) ? 250.0 : ((!(double_0 <= 8000.0)) ? 200.0 : ((!(double_0 <= 6000.0)) ? 150.0 : ((!(double_0 <= 4000.0)) ? 120.0 : ((!(double_0 <= 2000.0)) ? 100.0 : ((!(double_0 <= 1500.0)) ? 80.0 : ((double_0 <= 1000.0) ? 40.0 : 60.0))))))));
		}
		return num2;
	}
}
