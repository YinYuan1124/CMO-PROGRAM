using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Sharp3D.Math.Core;

namespace Command_Core;

[StandardModule]
public sealed class VisualModel
{
	public enum TVisibilityType
	{
		vt_Cannot_See,
		vt_Can_Detect,
		vt_Can_Identify
	}

	public enum TVisionMode
	{
		vm_Scanning,
		vm_Tracking
	}

	public const string ModuleVersion = "Version 0.5";

	public const string ModuleCredits = "Sources: \r\n\t-> Karasik V.E., Orlov V.M. Lazernyye sistemy videniya. M, 2001.\r\n\t-> CIE DS 011.2/E:2002, CIE Central Bureau, Wien. \r\n ('Spatial distribution of daylight - CIE standard general sky') ";

	public const double Standard_VisibilityNM = 15.0;

	internal static double ViewReponse(double double_0)
	{
		if (double_0 < 0.0)
		{
			return 0.0;
		}
		return Math.Sqrt(double_0 * double_0 + 2.0 * double_0 * 6371.0 * 1000.0);
	}

	internal static bool ValidateReponse(ref ActiveUnit activeUnit_0, ref ActiveUnit activeUnit_1, DateTime dateTime_0)
	{
		QuaternionD quaternionD = default(QuaternionD);
		new Contact(activeUnit_1);
		Geodesic_Vincenty.TCoord tcoord_ = default(Geodesic_Vincenty.TCoord);
		tcoord_.Lat = activeUnit_0.GetLatitude();
		tcoord_.Lon = activeUnit_0.GetLongitude();
		Geodesic_Vincenty.TCoord tCoord = default(Geodesic_Vincenty.TCoord);
		tCoord.Lat = activeUnit_1.GetLatitude();
		tCoord.Lon = activeUnit_1.GetLongitude();
		Geodesic_Vincenty.ExcludeInvocation(tCoord, activeUnit_1.GetCurrentAltitude());
		quaternionD.Inverse();
		double num = Geodesic_Vincenty.IncludeInvocation(tcoord_, tCoord, activeUnit_0.GetCurrentAltitude(), activeUnit_1.GetCurrentAltitude());
		if (ViewReponse(activeUnit_0.GetCurrentAltitude()) + ViewReponse(activeUnit_1.GetCurrentAltitude()) < num)
		{
			return false;
		}
		double x = 0.0;
		double num2 = Math.Atan2(num * 1852.0, x) * 57.2957795130823 * 60.0;
		double num3 = 27.78 / (0.0 - Math.Log(0.02));
		double d;
		switch (Weather.VerifyDescriptor(dateTime_0, ref tcoord_, activeUnit_0.GetCurrentAltitude()))
		{
		default:
		{
			Exception ex = new Exception("Wrong time of day type");
			ex?.Data.Add("Error at 101161", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw ex;
		}
		case Weather.TTimeOfDayType.tod_Day:
			if (num2 < 20.0)
			{
				if (num2 < 1.0)
				{
					return false;
				}
				d = 0.02 * (num2 - 1.0) / 19.0;
			}
			else
			{
				d = 0.02;
			}
			break;
		case Weather.TTimeOfDayType.tod_Twilight:
			if (num2 < 20.0)
			{
				if (num2 < 1.0)
				{
					return false;
				}
				d = 0.035 * (num2 - 1.0) / 19.0;
			}
			else
			{
				d = 0.035;
			}
			break;
		case Weather.TTimeOfDayType.tod_Night:
			return false;
		}
		double num4 = (0.0 - Math.Log(d)) / num3;
		if (num > num4)
		{
			return false;
		}
		return true;
	}

	internal static double LoginReponse(double double_0, float float_0, float float_1)
	{
		return 2.1 * Math.Sqrt(float_0) - 1.2 * double_0 + Math.Sqrt(Math.Pow(2.1 + Math.Sqrt(float_0) - 1.2 * double_0, 2.0) + 4.41 * (double)(float_1 - float_0));
	}

	internal static int GetReponse(float float_0, ref Weather.WeatherProfile weatherProfile_0)
	{
		if (weatherProfile_0.CloudInfo.LowCloudCoverThickness > 0)
		{
			if (float_0 < (float)weatherProfile_0.CloudInfo.LowCloudBase_m)
			{
				return -1;
			}
			if (float_0 < (float)weatherProfile_0.CloudInfo.LowCloudTop_m)
			{
				if (!((double)VBMath.Rnd() < Math.Pow(1.0 - (double)weatherProfile_0.CloudInfo.LowCloudCoverThickness / 8.0, 2.0)))
				{
					return -1;
				}
				switch (weatherProfile_0.CloudInfo.LowCloudType)
				{
				case Weather.TLowCloudType.Cb_Cumulonimbus:
					return (int)Math.Round(21f * VBMath.Rnd() + 0f);
				case Weather.TLowCloudType.Sc_Stratocumulus:
					return (int)Math.Round(51f * VBMath.Rnd() + 50f);
				case Weather.TLowCloudType.St_Stratus:
					return (int)Math.Round(201f * VBMath.Rnd() + 100f);
				case Weather.TLowCloudType.Cu_Cumulus:
					return (int)Math.Round(11f * VBMath.Rnd() + 30f);
				}
			}
		}
		if (weatherProfile_0.CloudInfo.MiddleCloudCoverThickness > 0)
		{
			if (float_0 < (float)weatherProfile_0.CloudInfo.MiddleCloudBase_m)
			{
				return -1;
			}
			if (float_0 < (float)weatherProfile_0.CloudInfo.MiddleCloudTop_m)
			{
				if (!((double)VBMath.Rnd() < Math.Pow(1.0 - (double)weatherProfile_0.CloudInfo.MiddleCloudCoverThickness / 8.0, 2.0)))
				{
					return -1;
				}
				switch (weatherProfile_0.CloudInfo.MiddleCloudType)
				{
				case Weather.TMiddleCloudType.Ac_Altocumulus:
					return (int)Math.Round(21f * VBMath.Rnd() + 80f);
				case Weather.TMiddleCloudType.As_Altostratus:
					return (int)Math.Round(451f * VBMath.Rnd() + 50f);
				case Weather.TMiddleCloudType.Ns_Nimbostratus:
					return (int)Math.Round(41f * VBMath.Rnd() + 10f);
				}
			}
		}
		if (weatherProfile_0.CloudInfo.HighCloudCoverThickness > 0)
		{
			if (float_0 < (float)weatherProfile_0.CloudInfo.HighCloudBase_m)
			{
				return -1;
			}
			if (float_0 < (float)weatherProfile_0.CloudInfo.HighCloudTop_m)
			{
				if ((double)VBMath.Rnd() < Math.Pow(1.0 - (double)weatherProfile_0.CloudInfo.HighCloudCoverThickness / 8.0, 2.0))
				{
					return (int)Math.Round(301f * VBMath.Rnd() + 200f);
				}
				return -1;
			}
		}
		return -1;
	}

	internal static double WriteReponse(double double_0, double double_1, double double_2, double double_3, int int_0)
	{
		double num = 1.5707963267949 - double_0 * 0.0174532925199433;
		double num6 = 1.5707963267949 - double_1 * 0.0174532925199433;
		double num7 = Math.Acos(Math.Cos(num) * Math.Cos(num6) + Math.Sin(num) * Math.Sin(num6) * Math.Cos(Math.Abs(double_3 - double_2) * 0.0174532925199433));
		double num8 = Math.Sqrt(double.Epsilon);
		double num9;
		double num10;
		double num11;
		double num12;
		double num13;
		switch (int_0)
		{
		default:
		{
			Exception ex = new Exception("Invalid sky type");
			ex?.Data.Add("Error at 101162", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw ex;
		}
		case 1:
			num9 = 4.0;
			num10 = -0.7;
			num11 = 0.0;
			num12 = -1.0;
			num13 = 0.0;
			break;
		case 2:
			num9 = 4.0;
			num10 = -0.7;
			num11 = 2.0;
			num12 = -1.5;
			num13 = 0.15;
			break;
		case 3:
			num9 = 1.1;
			num10 = -0.8;
			num11 = 0.0;
			num12 = -1.0;
			num13 = 0.0;
			break;
		case 4:
			num9 = 1.1;
			num10 = -0.8;
			num11 = 2.0;
			num12 = -1.5;
			num13 = 0.15;
			break;
		case 5:
			num9 = 0.0;
			num10 = -1.0;
			num11 = 0.0;
			num12 = -1.0;
			num13 = 0.0;
			break;
		case 6:
			num9 = 0.0;
			num10 = -1.0;
			num11 = 2.0;
			num12 = -1.5;
			num13 = 0.15;
			break;
		case 7:
			num9 = 0.0;
			num10 = -1.0;
			num11 = 5.0;
			num12 = -2.5;
			num13 = 0.3;
			break;
		case 8:
			num9 = 0.0;
			num10 = -1.0;
			num11 = 10.0;
			num12 = -3.0;
			num13 = 0.45;
			break;
		case 9:
			num9 = -1.0;
			num10 = -0.55;
			num11 = 2.0;
			num12 = -1.5;
			num13 = 0.15;
			break;
		case 10:
			num9 = -1.0;
			num10 = -0.55;
			num11 = 5.0;
			num12 = -2.5;
			num13 = 0.3;
			break;
		case 11:
			num9 = -1.0;
			num10 = -0.55;
			num11 = 10.0;
			num12 = -3.0;
			num13 = 0.45;
			break;
		case 12:
			num9 = -1.0;
			num10 = -0.32;
			num11 = 10.0;
			num12 = -3.0;
			num13 = 0.45;
			break;
		case 13:
			num9 = -1.0;
			num10 = -0.32;
			num11 = 16.0;
			num12 = -3.0;
			num13 = 0.3;
			break;
		case 14:
			num9 = -1.0;
			num10 = -0.15;
			num11 = 16.0;
			num12 = -3.0;
			num13 = 0.3;
			break;
		case 15:
			num9 = -1.0;
			num10 = -0.15;
			num11 = 24.0;
			num12 = -2.8;
			num13 = 0.15;
			break;
		}
		double num2 = ((Math.Abs(num6 - 1.5707963267949) < num8) ? 1.0 : (1.0 + num9 * Math.Exp(num10 * Math.Cos(num6))));
		double num3 = 1.0 + num9 * Math.Exp(num10);
		double num4 = 1.0 + num11 * (Math.Exp(num12 * num7) - Math.Exp(num12 * 1.5707963267949)) + num13 * Math.Pow(Math.Cos(num7), 2.0);
		double num5 = 1.0 + num11 * (Math.Exp(num12 * num) - Math.Exp(num12 * 1.5707963267949)) + num13 * Math.Pow(Math.Cos(num), 2.0);
		return num4 * num2 / (num5 * num3);
	}

	internal static TVisibilityType NewReponse(float float_0, double double_0, float float_1, double double_1, TVisibilityType tvisibilityType_0, Weather.TTimeOfDayType ttimeOfDayType_0, ref Weather.WeatherProfile weatherProfile_0)
	{
		double num = double_1 * 1852.0 / 1000.0;
		Math.Atan2(num * 1000.0, double_0);
		double num6 = 0.0;
		double num7 = 0.0;
		_ = Math.Abs(0.0) / 0.0;
		double num8 = 0.0;
		double num9 = num6 * Math.Exp(0.0 * num) + num8 * (1.0 - Math.Exp(0.0 * num));
		double num10 = num7 * Math.Exp(0.0 * num) + num8 * (1.0 - Math.Exp(0.0 * num));
		_ = Math.Abs(num9 - num10) / (num9 + num10);
		if (double_1 <= LoginReponse(1.0, float_0, float_1))
		{
			double d = 0.0;
			double d2 = 0.0;
			double d3 = 0.0;
			switch (ttimeOfDayType_0)
			{
			case Weather.TTimeOfDayType.tod_Day:
				d = 0.02;
				d2 = 0.05;
				d3 = 0.07;
				break;
			case Weather.TTimeOfDayType.tod_Twilight:
				d = 0.3;
				d2 = 0.35;
				d3 = 0.4;
				break;
			case Weather.TTimeOfDayType.tod_Night:
				d = 0.6;
				d2 = 0.65;
				d3 = 0.7;
				break;
			}
			double num11 = 0.0;
			if (Math.Max(float_0, float_1) < (float)weatherProfile_0.CloudInfo.LowCloudBase_m)
			{
				num11 = weatherProfile_0.SurfaceVisibilityKM;
			}
			else
			{
				double num12 = 0.0;
				if ((double)GetReponse(float_0, ref weatherProfile_0) == -1.0)
				{
					num12 = GetReponse(float_1, ref weatherProfile_0);
				}
				if (num12 == -1.0)
				{
					num11 = 0.0;
				}
			}
			_ = (0.0 - Math.Log(0.02)) / num11;
			double num13 = (0.0 - Math.Log(0.02)) / (double)weatherProfile_0.SurfaceVisibilityKM;
			double d4 = 1.0;
			if (tvisibilityType_0 == TVisibilityType.vt_Cannot_See)
			{
				double num2 = (Math.Log(d4) - Math.Log(d2)) / num13;
				if (num < num2)
				{
					double num3 = (Math.Log(d4) - Math.Log(d3)) / num13;
					if (num < num3)
					{
						return TVisibilityType.vt_Can_Identify;
					}
					return TVisibilityType.vt_Can_Detect;
				}
				return TVisibilityType.vt_Cannot_See;
			}
			double num4 = (Math.Log(d4) - Math.Log(d)) / num13;
			if (num <= num4)
			{
				double num5 = (Math.Log(d4) - Math.Log(d3)) / num13;
				if (num < num5)
				{
					return TVisibilityType.vt_Can_Identify;
				}
				return tvisibilityType_0;
			}
			return TVisibilityType.vt_Cannot_See;
		}
		return TVisibilityType.vt_Cannot_See;
	}
}
