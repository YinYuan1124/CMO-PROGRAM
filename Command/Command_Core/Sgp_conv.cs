using System;

namespace Command_Core;

public sealed class Sgp_conv
{
	public static double double_value(char[] char_0, int int_0, int int_1)
	{
		double num = 0.0;
		int i = 0;
		int num2 = 0;
		for (; i < int_1; i++)
		{
			switch (char_0[i + int_0])
			{
			case '.':
				num2 = int_1 - i - 1;
				break;
			case '0':
				num *= 10.0;
				break;
			case '1':
				num *= 10.0;
				num += 1.0;
				break;
			case '2':
				num *= 10.0;
				num += 2.0;
				break;
			case '3':
				num *= 10.0;
				num += 3.0;
				break;
			case '4':
				num *= 10.0;
				num += 4.0;
				break;
			case '5':
				num *= 10.0;
				num += 5.0;
				break;
			case '6':
				num *= 10.0;
				num += 6.0;
				break;
			case '7':
				num *= 10.0;
				num += 7.0;
				break;
			case '8':
				num *= 10.0;
				num += 8.0;
				break;
			case '9':
				num *= 10.0;
				num += 9.0;
				break;
			}
		}
		return num / Math.Pow(10.0, num2);
	}

	public static int integer_value(char[] char_0, int int_0, int int_1)
	{
		int num = 0;
		for (int i = 0; i < int_1; i++)
		{
			switch (char_0[i + int_0])
			{
			case '0':
				num *= 10;
				break;
			case '1':
				num *= 10;
				num++;
				break;
			case '2':
				num *= 10;
				num += 2;
				break;
			case '3':
				num *= 10;
				num += 3;
				break;
			case '4':
				num *= 10;
				num += 4;
				break;
			case '5':
				num *= 10;
				num += 5;
				break;
			case '6':
				num *= 10;
				num += 6;
				break;
			case '7':
				num *= 10;
				num += 7;
				break;
			case '8':
				num *= 10;
				num += 8;
				break;
			case '9':
				num *= 10;
				num += 9;
				break;
			}
		}
		return num;
	}

	public static void Convert_Satellite_Data(ref SxPxConstants.tle_ascii tle_ascii_0, ref SxPxConstants.sgp_data sgp_data_0)
	{
		sgp_data_0.ObjectName = tle_ascii_0.string_0[0];
		sgp_data_0.epoch = double_value(tle_ascii_0.string_0[1].ToCharArray(), 18, 14);
		sgp_data_0.julian_epoch = SxPxTime.ComputeWatcher(ref sgp_data_0.epoch);
		sgp_data_0.xndt2o = double_value(tle_ascii_0.string_0[1].ToCharArray(), 33, 10);
		sgp_data_0.xndd6o = double_value(tle_ascii_0.string_0[1].ToCharArray(), 44, 6) * 1E-05;
		int num = integer_value(tle_ascii_0.string_0[1].ToCharArray(), 50, 2);
		sgp_data_0.bstar = double_value(tle_ascii_0.string_0[1].ToCharArray(), 53, 6) * 1E-05;
		int num2 = integer_value(tle_ascii_0.string_0[1].ToCharArray(), 59, 2);
		Array.Copy(tle_ascii_0.string_0[1].ToCharArray(), 65, sgp_data_0.elset, 0, 3);
		sgp_data_0.xincl = double_value(tle_ascii_0.string_0[2].ToCharArray(), 8, 8);
		sgp_data_0.xnodeo = double_value(tle_ascii_0.string_0[2].ToCharArray(), 17, 8);
		sgp_data_0.eo = double_value(tle_ascii_0.string_0[2].ToCharArray(), 26, 7) * 1E-07;
		sgp_data_0.omegao = double_value(tle_ascii_0.string_0[2].ToCharArray(), 34, 8);
		sgp_data_0.xmo = double_value(tle_ascii_0.string_0[2].ToCharArray(), 43, 8);
		sgp_data_0.xno = double_value(tle_ascii_0.string_0[2].ToCharArray(), 52, 11);
		sgp_data_0.catnr = tle_ascii_0.string_0[2].ToString().Substring(2, 5);
		sgp_data_0.revnum = integer_value(tle_ascii_0.string_0[2].ToCharArray(), 63, 5);
		sgp_data_0.xndd6o *= Math.Pow(10.0, -num);
		sgp_data_0.bstar = sgp_data_0.bstar * Math.Pow(10.0, -num2) / 1.0;
		sgp_data_0.xnodeo = SxPxMath.ConnectWatcher(ref sgp_data_0.xnodeo);
		sgp_data_0.omegao = SxPxMath.ConnectWatcher(ref sgp_data_0.omegao);
		sgp_data_0.xmo = SxPxMath.ConnectWatcher(ref sgp_data_0.xmo);
		sgp_data_0.xincl = SxPxMath.ConnectWatcher(ref sgp_data_0.xincl);
		sgp_data_0.xno = sgp_data_0.xno * 2.0 * 3.14159265358979 / 1440.0;
		sgp_data_0.xndt2o = sgp_data_0.xndt2o * 2.0 * 3.14159265358979 / SxPxMath.CountWatcher(1440.0);
		sgp_data_0.xndd6o = sgp_data_0.xndd6o * 2.0 * 3.14159265358979 / SxPxMath.RevertSpecification(1440.0);
		double num3 = Math.Pow(Math.Sqrt(1434962880.0 / SxPxMath.RevertSpecification(6378.135)) / sgp_data_0.xno, 2.0 / 3.0);
		double num4 = 0.00081196185 * (3.0 * SxPxMath.CountWatcher(Math.Cos(sgp_data_0.xincl)) - 1.0) / Math.Pow(1.0 - SxPxMath.CountWatcher(sgp_data_0.eo), 1.5);
		double num5 = num4 / SxPxMath.CountWatcher(num3);
		double double_ = num3 * (1.0 - num5 * (1.0 / 3.0 + num5 * (1.0 + 1.654320987654321 * num5)));
		double num6 = num4 / SxPxMath.CountWatcher(double_);
		double num7 = sgp_data_0.xno / (1.0 + num6);
		if (6.28318530717958 / num7 < 225.0)
		{
			sgp_data_0.ideep = 0;
		}
		else
		{
			sgp_data_0.ideep = 1;
		}
	}

	public static void Convert_Sat_State(ref SxPxConstants.vector vector_0, ref SxPxConstants.vector vector_1)
	{
		for (int i = 0; i < 3; i++)
		{
			vector_0.v[i] = vector_0.v[i] * 6378.135;
			vector_1.v[i] = vector_1.v[i] * 6378.135 / 60.0;
		}
		SxPxMath.Magnitude(ref vector_0);
		SxPxMath.Magnitude(ref vector_1);
	}

	public static int sgp(int int_0, double double_0, SxPxConstants.tle_ascii tle_ascii_0, SxPxConstants.vector vector_0, SxPxConstants.vector vector_1)
	{
		SxPxConstants.sgp_data sgp_data_ = new SxPxConstants.sgp_data();
		Convert_Satellite_Data(ref tle_ascii_0, ref sgp_data_);
		switch (int_0)
		{
		default:
			return -1;
		case 0:
			Sgp.sgp0call(double_0, ref vector_0, ref vector_1, sgp_data_);
			break;
		case 1:
		case 2:
			Sgp4Sdp4.sgp4call(double_0, ref vector_0, ref vector_1, sgp_data_);
			break;
		case 3:
		case 4:
			Sgp8Sdp8.sgp8call(ref double_0, ref vector_0, ref vector_1, ref sgp_data_);
			break;
		}
		Convert_Sat_State(ref vector_0, ref vector_1);
		return 0;
	}
}
