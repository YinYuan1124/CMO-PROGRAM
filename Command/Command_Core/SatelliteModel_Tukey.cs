using System;
using System.ComponentModel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class SatelliteModel_Tukey
{
	public sealed class TSatellite
	{
		public SxPxConstants.sgp_data SatData;

		[Category("Classical ephemeris")]
		public double Eccentricity
		{
			get
			{
				return SatData.Eccentricity;
			}
			set
			{
				SatData.Eccentricity = value;
				SatData.method_0();
			}
		}

		[Category("Classical ephemeris")]
		public double SemiMajorAxis
		{
			get
			{
				return SatData.Ideal_SemiMajorAxis_km;
			}
			set
			{
				SatData.Ideal_SemiMajorAxis_km = value;
				SatData.method_0();
			}
		}

		[Category("Decay parameters")]
		public double BSTAR
		{
			get
			{
				return SatData.RadiationPressureCoeff_BSTAR;
			}
			set
			{
				SatData.RadiationPressureCoeff_BSTAR = value;
			}
		}

		[Category("Classical ephemeris")]
		public double MeanAnomaly
		{
			get
			{
				return SatData.MeanAnomaly;
			}
			set
			{
				SatData.MeanAnomaly = value;
			}
		}

		[Category("Derived parameters")]
		public double ApogeeAltitude_km => SatData.ApA;

		[Category("Derived parameters")]
		public double PerigeeAltitude_km => SatData.PeA;

		[Category("Derived parameters")]
		public double OrbitalPeriod_s
		{
			get
			{
				return SatData.OrbitalPeriod_s;
			}
			set
			{
				SatData.OrbitalPeriod_s = value;
				SatData.method_0();
			}
		}

		[Category("Classical ephemeris")]
		public DateTime EphemerisDate
		{
			get
			{
				int num = RadarModel.PrintStub(SatData.epoch * 0.001);
				num = ((num < 57) ? (num + 2000) : (num + 1900));
				double num2 = SatData.epoch - (double)RadarModel.PrintStub(SatData.epoch * 0.001) * 1000.0;
				return new DateTime(num, 1, 1, 0, 0, 0).AddDays(num2 - 1.0);
			}
			set
			{
				int num = ((value.Year < 2000) ? (value.Year - 1900) : (value.Year - 2000));
				SatData.epoch = (double)num * 1000.0 + (double)value.DayOfYear + value.TimeOfDay.TotalSeconds / 86400.0;
				SatData.julian_epoch = SxPxTime.ComputeWatcher(ref SatData.epoch);
			}
		}

		[Category("Classical ephemeris")]
		public double Inclination
		{
			get
			{
				return SatData.Inclination;
			}
			set
			{
				SatData.Inclination = value;
			}
		}

		[Category("Classical ephemeris")]
		public double RAAscendingNode
		{
			get
			{
				return SatData.MeanRightAscensionAscendingNode;
			}
			set
			{
				SatData.MeanRightAscensionAscendingNode = value;
			}
		}

		[Category("Classical ephemeris")]
		public double ArgPerigee
		{
			get
			{
				return SatData.AgP;
			}
			set
			{
				SatData.AgP = value;
			}
		}

		[Category("Identification")]
		public string ObjectName
		{
			get
			{
				return SatData.ObjectName;
			}
			set
			{
				SatData.ObjectName = value;
			}
		}

		[Category("Identification")]
		public string String_0
		{
			get
			{
				return SatData.catnr;
			}
			set
			{
				SatData.catnr = value;
			}
		}

		[Category("Identification")]
		public string ElementSetNumber
		{
			get
			{
				return new string(SatData.elset);
			}
			set
			{
				SatData.elset = value.ToCharArray();
			}
		}

		[Category("Identification")]
		public int OrbitNumberAtEpoch
		{
			get
			{
				return SatData.OrbitNumberAtEpoch;
			}
			set
			{
				SatData.OrbitNumberAtEpoch = value;
			}
		}

		[Category("Decay parameters")]
		public double FirstDerivativeOfMeanMotion
		{
			get
			{
				return SatData.xndt2o;
			}
			set
			{
				SatData.xndt2o = value;
			}
		}

		[Category("Decay parameters")]
		public double SecondDerivativeOfMeanMotion
		{
			get
			{
				return SatData.xndd6o;
			}
			set
			{
				SatData.xndd6o = value;
			}
		}

		public TSatellite(SxPxConstants.tle_ascii tle_ascii_0)
		{
			SatData = new SxPxConstants.sgp_data();
			Sgp_conv.Convert_Satellite_Data(ref tle_ascii_0, ref SatData);
		}

		public TSatellite()
		{
			SatData = new SxPxConstants.sgp_data();
			SatData.bstar = 0.0;
			String_0 = "XXXXX";
			SatData.xmo = 0.0;
			SatData.xndd6o = 0.0;
			SatData.xndt2o = 0.0;
			ArgPerigee = 0.0;
			RAAscendingNode = 0.0;
			EphemerisDate = DateAndTime.Now;
			Inclination = 63.4;
			SetApogeeAndPerigee(300.0, 300.0);
		}

		public void ReInit(double double_0, double double_1, double double_2)
		{
			Inclination = double_0;
			SetApogeeAndPerigee(double_1, double_2);
			EphemerisDate = new DateTime(1900, 1, 1);
		}

		public void ReInit(double double_0, double double_1, double double_2, double double_3)
		{
			Inclination = double_0;
			SetApogeeAndPerigee(double_1, double_2);
			ArgPerigee = double_3;
		}

		public void method_0(string[] string_0)
		{
			if (string_0.Length < 2)
			{
				throw new Exception("Two-line elements must include at least *three* lines: name of the sat comes first.");
			}
			SxPxConstants.tle_ascii tle_ascii_ = default(SxPxConstants.tle_ascii);
			tle_ascii_.string_0 = new string[3];
			tle_ascii_.string_0[0] = string_0[0];
			tle_ascii_.string_0[1] = string_0[1];
			tle_ascii_.string_0[2] = string_0[2];
			Sgp_conv.Convert_Satellite_Data(ref tle_ascii_, ref SatData);
		}

		public TSatellite(string[] string_0)
		{
			SatData = new SxPxConstants.sgp_data();
			method_0(string_0);
		}

		internal double ConcatInterruptibleReg()
		{
			double num = Math.Pow(SemiMajorAxis * 1000.0, 3.5);
			double eccentricity = Eccentricity;
			double num2 = eccentricity * eccentricity;
			double num3 = 1.0 - num2;
			double num4 = num3 * num3;
			double num5 = Math.Sqrt(398600441800000.0);
			double num6 = num * num4 * (2.0 / 3.0) * 0.01720279125572669 / (-11954461775405058.0 / Math.PI * num5);
			if (Math.Abs(num6) <= 1.0)
			{
				return Math.Acos(num6) * 57.2957795130823;
			}
			return 0.0;
		}

		internal double InterruptInterruptibleReg()
		{
			double eccentricity = Eccentricity;
			double num = 1.0 - eccentricity * eccentricity;
			double num2 = num * num;
			double num3 = Math.Pow(SemiMajorAxis * 1000.0, 3.5);
			double num4 = Math.Sqrt(398600441800000.0);
			double num5 = -66062905679.126045 * num4 * Math.Cos(Inclination * 0.0174532925199433) / (num3 * num2);
			return 57.2957795130823 * num5 * 86400.0;
		}

		public void Predict_Position(DateTime dateTime_0, bool bool_0, ref double double_0, ref double double_1, ref double double_2, ref double double_3)
		{
			SxPxConstants.vector vector_ = default(SxPxConstants.vector);
			vector_.v = new double[4];
			SxPxConstants.vector vector_2 = default(SxPxConstants.vector);
			vector_2.v = new double[4];
			int hours = 8;
			TimeZone currentTimeZone = TimeZone.CurrentTimeZone;
			DateTime dateTime;
			if (bool_0)
			{
				dateTime = dateTime_0;
			}
			else
			{
				currentTimeZone.GetUtcOffset(dateTime_0);
				if (currentTimeZone.IsDaylightSavingTime(dateTime_0))
				{
					hours = 7;
				}
				dateTime = currentTimeZone.ToUniversalTime(dateTime_0);
			}
			dateTime = dateTime.Subtract(new TimeSpan(0, hours, 0, 0));
			double num = SxPxTime.SelectWatcher(ref dateTime);
			Sgp4Sdp4.sgp4call(num, ref vector_, ref vector_2, SatData);
			Sgp_conv.Convert_Sat_State(ref vector_, ref vector_2);
			SxPxConstants.geodetic_t geodetic_t_ = default(SxPxConstants.geodetic_t);
			SxPxMath.Calculate_LatLonAlt(num - SatData.julian_epoch, ref vector_, ref geodetic_t_);
			double_0 = SxPxMath.AddWatcher(geodetic_t_.lat);
			double_1 = SxPxMath.CustomizeWatcher(SxPxMath.AddWatcher(geodetic_t_.lon), 360.0);
			double_2 = geodetic_t_.alt;
			double_3 = vector_2.v[3];
			double_1 = Math2.VisitClass(double_1);
		}

		public void SetApogeeAndPerigee(double double_0, double double_1)
		{
			SatData.SetApogeeAndPerigee(double_0, double_1);
			SatData.method_0();
		}
	}

	public const double Earth_J2_notide = 0.00108262668;

	public const double Earth_J2_tide = 0.0010826359;

	public const double EquatorialRadius = 6378165.0;

	public const double ProgradeCriticalInclination = 63.434948822922;

	public const double RetrogradeCriticalInclination = 116.565051177078;

	public static void gettestdata(ref SxPxConstants.tle_ascii tle_ascii_0)
	{
		tle_ascii_0.string_0 = new string[3];
		tle_ascii_0.string_0[0] = "INTELSAT 603 (IS-603)";
		tle_ascii_0.string_0[1] = "1 20523U 90021A   07349.98446615 -.00000136  00000-0  10000-3 0  1975";
		tle_ascii_0.string_0[2] = "2 20523   5.0107  74.6594 0004309 254.3507  89.6748  1.00271715 57967";
	}

	internal static double RemoveWriter(double double_0, double double_1, double double_2)
	{
		double num = FillWriter(double_0, double_1);
		double num2 = 1.0 - num * num;
		double num3 = num2 * num2;
		double x = (double_0 + double_1) / 2.0;
		double num4 = -66062905679.126045 * Math.Sqrt(398600441800000.0) * Math.Cos(double_2 * 0.0174532925199433) / (Math.Pow(x, 3.5) * num3);
		return 57.2957795130823 * num4 * 86400.0;
	}

	internal static double FindWriter(double double_0, double double_1)
	{
		double num = FillWriter(double_0, double_1);
		double num2 = 1.0 - num * num;
		double num3 = num2 * num2;
		double num4 = Math.Pow((double_0 + double_1) / 2.0, 3.5);
		double num5 = -1.3273758684974296E-07 * (num4 * num3) / (44041937119.417366 * Math.Sqrt(398600441800000.0));
		if (Math.Abs(num5) <= 1.0)
		{
			return Math.Acos(num5) * 57.2957795130823;
		}
		return 0.0;
	}

	public static void SSO_Inclination_And_Apogee(double double_0, int int_0, int int_1, ref double double_1, ref double double_2)
	{
		double num = Math.Pow((double)(int_0 * 86400) / (double)int_1 * Math.Sqrt(398600441800000.0) / 6.28318530717959, 2.0 / 3.0);
		double_1 = 2.0 * num - double_0;
		double num2 = FillWriter(double_1, double_0);
		double num3 = 1.0 - num2 * num2;
		double num4 = num3 * num3;
		double num5 = Math.Pow(num, 3.5);
		double num6 = -1.3273758684974296E-07 * (num5 * num4) / (44041937119.417366 * Math.Sqrt(398600441800000.0));
		if (Math.Abs(num6) <= 1.0)
		{
			double_2 = Math.Acos(num6) * 57.2957795130823;
		}
		else
		{
			double_2 = 0.0;
		}
	}

	internal static double SetWriter(double double_0, double double_1)
	{
		return (double_0 + double_1) / 2.0;
	}

	internal static double FillWriter(double double_0, double double_1)
	{
		return (double_0 - double_1) / (double_0 + double_1);
	}

	internal static double CalculateWriter(double double_0, double double_1)
	{
		double num = (double_0 + double_1) / 2.0;
		return 6.28318530717959 * Math.Sqrt(num * num * num / 398600441800000.0);
	}

	public static void Main__()
	{
		Console.WriteLine(FindWriter(6948165.0, 6648165.0));
		double double_ = 0.0;
		double double_2 = 0.0;
		SSO_Inclination_And_Apogee(6648165.0, 3, 33, ref double_, ref double_2);
		Console.WriteLine((double_ - 6378165.0) / 1000.0);
		Console.WriteLine(double_2);
	}
}
