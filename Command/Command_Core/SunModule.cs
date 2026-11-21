using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class SunModule
{
	public sealed class posdata
	{
		public int day;

		public int daynum;

		public int func;

		public int hour;

		public int interval;

		public int minute;

		public int month;

		public int second;

		public int year;

		public double amass;

		public double ampress;

		public double aspect;

		public double azim;

		public double cosinc;

		public double coszen;

		public double dayang;

		public double declin;

		public double eclong;

		public double ecobli;

		public double ectime;

		public double elevetr;

		public double elevref;

		public double eqntim;

		public double erv;

		public double etr;

		public double etrn;

		public double etrtilt;

		public double gmst;

		public double hrang;

		public double julday;

		public double latitude;

		public double longitude;

		public double lmst;

		public double mnanom;

		public double mnlong;

		public double rascen;

		public double press;

		public double prime;

		public double sbcf;

		public double sbwid;

		public double sbrad;

		public double sbsky;

		public double solcon;

		public double ssha;

		public double sretr;

		public double ssetr;

		public double temp;

		public double tilt;

		public double timezone;

		public double tst;

		public double tstfix;

		public double unprime;

		public double utime;

		public double zenetr;

		public double zenref;

		public posdata()
		{
			day = -99;
			daynum = -999;
			hour = -99;
			minute = -99;
			month = -99;
			second = -99;
			year = -99;
			interval = 0;
			aspect = 180.0;
			latitude = -99.0;
			longitude = -999.0;
			press = 1013.0;
			solcon = 1367.0;
			temp = 15.0;
			tilt = 0.0;
			timezone = -99.0;
			sbwid = 7.6;
			sbrad = 31.7;
			sbsky = 0.04;
			func = 65535;
		}

		public void dom2doy()
		{
			daynum = day + month_days[0][month];
			if ((year / 4 == 0) & ((year / 100 != 0) | (year / 400 == 0)) & (month > 2))
			{
				daynum++;
			}
		}

		public void zen_no_ref(ref trigdata trigdata_0)
		{
			localtrig(ref trigdata_0);
			double num = trigdata_0.sd * trigdata_0.sl + trigdata_0.cd * trigdata_0.cl * trigdata_0.ch;
			if (Math.Abs(num) > 1.0)
			{
				num = ((num < 0.0) ? (-1.0) : 1.0);
			}
			zenetr = Math.Acos(num) * 57.2957795130823;
			if (zenetr > 104.0)
			{
				zenetr = 104.0;
			}
			elevetr = 90.0 - zenetr;
		}

		public void ssha_(ref trigdata trigdata_0)
		{
			localtrig(ref trigdata_0);
			double num = trigdata_0.cd * trigdata_0.cl;
			if (Math.Abs(num) < 0.001)
			{
				if ((!(declin < 0.0) && !(latitude <= 0.0)) || (!(declin >= 0.0) && latitude < 0.0))
				{
					ssha = 180.0;
				}
				else
				{
					ssha = 0.0;
				}
				return;
			}
			double num2 = (0.0 - trigdata_0.sl) * trigdata_0.sd / num;
			if (num2 < -1.0)
			{
				ssha = 180.0;
			}
			else if (num2 <= 1.0)
			{
				ssha = 57.2957795130823 * Math.Acos(num2);
			}
			else
			{
				ssha = 0.0;
			}
		}

		public void etr_()
		{
			if (coszen <= 0.0)
			{
				etrn = 0.0;
				etr = 0.0;
			}
			else
			{
				etrn = solcon * erv;
				etr = etrn * coszen;
			}
		}

		public void sazm(ref trigdata trigdata_0)
		{
			localtrig(ref trigdata_0);
			double num = Math.Cos(0.0174532925199433 * elevetr);
			double num2 = Math.Sin(0.0174532925199433 * elevetr);
			azim = 180.0;
			double num3 = num * trigdata_0.cl;
			if (!(Math.Abs(num3) >= 0.001))
			{
				return;
			}
			double num4 = (num2 * trigdata_0.sl - trigdata_0.sd) / num3;
			if (num4 <= 1.0)
			{
				if (num4 < -1.0)
				{
					num4 = -1.0;
				}
			}
			else
			{
				num4 = 1.0;
			}
			azim = 180.0 - Math.Acos(num4) * 57.2957795130823;
			if (hrang > 0.0)
			{
				azim = 360.0 - azim;
			}
		}

		public void prime_()
		{
			unprime = 1.031 * Math.Exp(-1.4 / (0.9 + 9.4 / amass)) + 0.1;
			prime = 1.0 / unprime;
		}

		public void sbcf_(ref trigdata trigdata_0)
		{
			localtrig(ref trigdata_0);
			double num = 0.6366198 * sbwid / sbrad * Math.Pow(trigdata_0.cd, 3.0);
			double num2 = trigdata_0.sl * trigdata_0.sd * ssha * 0.0174532925199433;
			double num3 = trigdata_0.cl * trigdata_0.cd * Math.Sin(ssha * 0.0174532925199433);
			sbcf = sbsky + 1.0 / (1.0 - num * (num2 + num3));
		}

		public void amass_()
		{
			if (zenref <= 93.0)
			{
				amass = 1.0 / (Math.Cos(0.0174532925199433 * zenref) + 0.50572 * Math.Pow(96.07995 - zenref, -1.6364));
				ampress = amass * press / 1013.0;
			}
			else
			{
				amass = -1.0;
				ampress = -1.0;
			}
		}

		public void refrac()
		{
			double num2;
			if (elevetr <= 85.0)
			{
				double num = Math.Tan(0.0174532925199433 * elevetr);
				num2 = ((!(elevetr < 5.0)) ? (58.1 / num - 0.07 / Math.Pow(num, 3.0) + 8.6E-05 / Math.Pow(num, 5.0)) : ((elevetr < -0.575) ? (-20.774 / num) : (1735.0 + elevetr * (-518.2 + elevetr * (103.4 + elevetr * (-12.79 + elevetr * 0.711))))));
				double num3 = press * 283.0 / (1013.0 * (273.0 + temp));
				num2 *= num3 / 3600.0;
			}
			else
			{
				num2 = 0.0;
			}
			elevref = elevetr + num2;
			if (elevref < -12.0)
			{
				elevref = -12.0;
			}
			zenref = 90.0 - elevref;
			coszen = Math.Cos(0.0174532925199433 * zenref);
		}

		public void doy2dom()
		{
			int num = ((year / 4 == 0 && (year / 100 != 0 || year / 400 == 0)) ? 1 : 0);
			int num2 = 12;
			while (daynum <= month_days[num][num2])
			{
				num2--;
			}
			month = num2;
			day = daynum - month_days[num][num2];
		}

		public void localtrig(ref trigdata trigdata_0)
		{
			if (trigdata_0.sd < -900.0)
			{
				trigdata_0.sd = 1.0;
				trigdata_0.cd = Math.Cos(0.0174532925199433 * declin);
				trigdata_0.ch = Math.Cos(0.0174532925199433 * hrang);
				trigdata_0.cl = Math.Cos(0.0174532925199433 * latitude);
				trigdata_0.sd = Math.Sin(0.0174532925199433 * declin);
				trigdata_0.sl = Math.Sin(0.0174532925199433 * latitude);
			}
		}

		public void tilt_()
		{
			double num = Math.Cos(0.0174532925199433 * azim);
			double num2 = Math.Cos(0.0174532925199433 * aspect);
			double num3 = Math.Cos(0.0174532925199433 * tilt);
			double num4 = Math.Sin(0.0174532925199433 * azim);
			double num5 = Math.Sin(0.0174532925199433 * aspect);
			double num6 = Math.Sin(0.0174532925199433 * tilt);
			double num7 = Math.Sin(0.0174532925199433 * zenref);
			cosinc = coszen * num3 + num7 * num6 * (num * num2 + num4 * num5);
			if (cosinc <= 0.0)
			{
				etrtilt = 0.0;
			}
			else
			{
				etrtilt = etrn * cosinc;
			}
		}

		public void srss()
		{
			if (ssha <= 1.0)
			{
				sretr = 2999.0;
				ssetr = -2999.0;
			}
			else if (ssha < 179.0)
			{
				sretr = 720.0 - 4.0 * ssha - tstfix;
				ssetr = 720.0 + 4.0 * ssha - tstfix;
			}
			else
			{
				sretr = -2999.0;
				ssetr = 2999.0;
			}
		}

		public void geometry()
		{
			dayang = 360.0 * (double)(daynum - 1) / 365.0;
			double num = Math.Sin(0.0174532925199433 * dayang);
			double num2 = Math.Cos(0.0174532925199433 * dayang);
			double num3 = 2.0 * dayang;
			double num4 = Math.Cos(0.0174532925199433 * num3);
			double num5 = Math.Sin(0.0174532925199433 * num3);
			erv = 1.00011 + 0.034221 * num2 + 0.00128 * num;
			erv += 0.000719 * num4 + 7.7E-05 * num5;
			utime = (double)hour * 3600.0 + (double)minute * 60.0 + (double)second - (double)interval / 2.0;
			utime = utime / 3600.0 - timezone;
			double num6 = year - 1949;
			int num7 = (int)(num6 / 4.0);
			julday = 32916.5 + num6 * 365.0 + (double)num7 + (double)daynum + utime / 24.0;
			ectime = julday - 51545.0;
			mnlong = 280.46 + 0.9856474 * ectime;
			mnlong -= 360.0 * (double)(int)(mnlong / 360.0);
			if (mnlong < 0.0)
			{
				mnlong += 360.0;
			}
			mnanom = 357.528 + 0.9856003 * ectime;
			mnanom -= 360.0 * (double)(int)(mnanom / 360.0);
			if (mnanom < 0.0)
			{
				mnanom += 360.0;
			}
			eclong = mnlong + 1.915 * Math.Sin(mnanom * 0.0174532925199433) + 0.02 * Math.Sin(2.0 * mnanom * 0.0174532925199433);
			eclong -= 360.0 * (double)(int)(eclong / 360.0);
			if (eclong < 0.0)
			{
				eclong += 360.0;
			}
			ecobli = 23.439 - 4E-07 * ectime;
			declin = 57.2957795130823 * Math.Asin(Math.Sin(ecobli * 0.0174532925199433) * Math.Sin(eclong * 0.0174532925199433));
			double y = Math.Cos(0.0174532925199433 * ecobli) * Math.Sin(0.0174532925199433 * eclong);
			double x = Math.Cos(0.0174532925199433 * eclong);
			rascen = 57.2957795130823 * Math.Atan2(y, x);
			if (rascen < 0.0)
			{
				rascen += 360.0;
			}
			gmst = 6.697375 + 0.0657098242 * ectime + utime;
			gmst -= 24.0 * (double)(int)(gmst / 24.0);
			if (gmst < 0.0)
			{
				gmst += 24.0;
			}
			lmst = gmst * 15.0 + longitude;
			lmst -= 360.0 * (double)(int)(lmst / 360.0);
			if (lmst < 0.0)
			{
				lmst += 360.0;
			}
			hrang = lmst - rascen;
			if (hrang < -180.0)
			{
				hrang += 360.0;
			}
			else if (hrang > 180.0)
			{
				hrang -= 360.0;
			}
		}

		public void tst_()
		{
			tst = (180.0 + hrang) * 4.0;
			for (tstfix = tst - (double)hour * 60.0 - (double)minute - (double)second / 60.0 + (double)interval / 120.0; tstfix > 720.0; tstfix -= 1440.0)
			{
			}
			while (tstfix < -720.0)
			{
				tstfix += 1440.0;
			}
			eqntim = tstfix + 60.0 * timezone - 4.0 * longitude;
		}

		internal long CallInterruptibleParam()
		{
			trigdata trigdata_ = default(trigdata);
			trigdata_.sd = -999.0;
			trigdata_.cd = 1.0;
			trigdata_.ch = 1.0;
			trigdata_.cl = 1.0;
			trigdata_.sl = 1.0;
			long num = LogoutInterruptibleParam();
			if (num == 0)
			{
				if ((func & 1) == 0)
				{
					dom2doy();
				}
				else
				{
					doy2dom();
				}
				if (((uint)func & 2u) != 0)
				{
					geometry();
				}
				if (((uint)func & 4u) != 0)
				{
					zen_no_ref(ref trigdata_);
				}
				if (((uint)func & 8u) != 0)
				{
					ssha_(ref trigdata_);
				}
				if (((uint)func & 0x10u) != 0)
				{
					sbcf_(ref trigdata_);
				}
				if (((uint)func & 0x20u) != 0)
				{
					tst_();
				}
				if (((uint)func & 0x40u) != 0)
				{
					srss();
				}
				if (((uint)func & 0x80u) != 0)
				{
					sazm(ref trigdata_);
				}
				if (((uint)func & 0x100u) != 0)
				{
					refrac();
				}
				if (((uint)func & 0x200u) != 0)
				{
					amass_();
				}
				if (((uint)func & 0x400u) != 0)
				{
					prime_();
				}
				if (((uint)func & 0x1000u) != 0)
				{
					etr_();
				}
				if (((uint)func & 0x800u) != 0)
				{
					tilt_();
				}
				return 0L;
			}
			return num;
		}

		internal long LogoutInterruptibleParam()
		{
			long num = 0L;
			if (((uint)func & 2u) != 0)
			{
				if (year < 1950 || year > 2050)
				{
					num |= 1;
				}
				if ((func & 1) == 0 && (month < 1 || month > 12))
				{
					num |= 2;
				}
				if ((func & 1) == 0 && (day < 1 || day > 31))
				{
					num |= 4;
				}
				if (((uint)func & (true ? 1u : 0u)) != 0 && (daynum < 1 || daynum > 366))
				{
					num |= 8;
				}
				if (hour < 0 || hour > 24)
				{
					num |= 0x10;
				}
				if (minute < 0 || minute > 59)
				{
					num |= 0x20;
				}
				if (second < 0 || second > 59)
				{
					num |= 0x40;
				}
				if (hour == 24 && minute > 0)
				{
					num |= 0x30;
				}
				if (hour == 24 && second > 0)
				{
					num |= 0x50;
				}
				if (Math.Abs(timezone) > 12.0)
				{
					num |= 0x80;
				}
				if (interval < 0 || interval > 28800)
				{
					num |= 0x100;
				}
				if (Math.Abs(longitude) > 180.0)
				{
					num |= 0x400;
				}
				if (Math.Abs(latitude) > 90.0)
				{
					num |= 0x200;
				}
			}
			if (((uint)func & 0x100u) != 0 && Math.Abs(temp) > 100.0)
			{
				num |= 0x800;
			}
			if ((((uint)func & 0x100u) != 0 && press < 0.0) || press > 2000.0)
			{
				num |= 0x1000;
			}
			if (((uint)func & 0x800u) != 0 && Math.Abs(tilt) > 180.0)
			{
				num |= 0x2000;
			}
			if (((uint)func & 0x800u) != 0 && Math.Abs(aspect) > 360.0)
			{
				num |= 0x4000;
			}
			if ((((uint)func & 0x10u) != 0 && sbwid < 1.0) || sbwid > 100.0)
			{
				num |= 0x8000;
			}
			if ((((uint)func & 0x10u) != 0 && sbrad < 1.0) || sbrad > 100.0)
			{
				num |= 0x10000;
			}
			if (((uint)func & 0x10u) != 0 && Math.Abs(sbsky) > 1.0)
			{
				num |= 0x20000;
			}
			return num;
		}
	}

	public struct trigdata
	{
		public double cd;

		public double ch;

		public double cl;

		public double sd;

		public double sl;
	}

	public enum ErrType
	{
		S_YEAR_ERROR,
		S_MONTH_ERROR,
		S_DAY_ERROR,
		S_DOY_ERROR,
		S_HOUR_ERROR,
		S_MINUTE_ERROR,
		S_SECOND_ERROR,
		S_TZONE_ERROR,
		S_INTRVL_ERROR,
		S_LAT_ERROR,
		S_LON_ERROR,
		S_TEMP_ERROR,
		S_PRESS_ERROR,
		S_TILT_ERROR,
		S_ASPECT_ERROR,
		S_SBWID_ERROR,
		S_SBRAD_ERROR,
		S_SBSKY_ERROR
	}

	public const double TwilightDegrees = -12.0;

	public static int[][] month_days;

	public const int L_DOY = 1;

	public const int L_GEOM = 2;

	public const int L_ZENETR = 4;

	public const int L_SSHA = 8;

	public const int L_SBCF = 16;

	public const int L_TST = 32;

	public const int L_SRSS = 64;

	public const int L_SOLAZM = 128;

	public const int L_REFRAC = 256;

	public const int L_AMASS = 512;

	public const int L_PRIME = 1024;

	public const int L_TILT = 2048;

	public const int L_ETR = 4096;

	public const int L_ALL = 65535;

	public const int S_DOY = 1;

	public const int S_GEOM = 3;

	public const int S_ZENETR = 7;

	public const int S_SSHA = 11;

	public const int S_SBCF = 27;

	public const int S_TST = 35;

	public const int S_SRSS = 107;

	public const int S_SOLAZM = 135;

	public const int S_REFRAC = 263;

	public const int S_AMASS = 775;

	public const int S_PRIME = 1799;

	public const int S_TILT = 2439;

	public const int S_ETR = 4359;

	public const int S_ALL = 65535;

	static SunModule()
	{
		month_days = new int[2][]
		{
			new int[13]
			{
				0, 0, 31, 59, 90, 120, 151, 181, 212, 243,
				273, 304, 334
			},
			new int[13]
			{
				0, 0, 31, 60, 91, 121, 152, 182, 213, 244,
				274, 305, 335
			}
		};
	}

	internal static Weather.TTimeOfDayType RateSpecification(DateTime dateTime_0, ref Geodesic_Vincenty.TCoord tcoord_0, double double_0 = 0.0)
	{
		return CollectSpecification(null, dateTime_0.Year, dateTime_0.Month, dateTime_0.Day, dateTime_0.Hour, dateTime_0.Minute, dateTime_0.Second, bool_0: false, tcoord_0.Lat, tcoord_0.Lon, double_0);
	}

	internal static Weather.TTimeOfDayType FlushSpecification(DateTime dateTime_0, double double_0, double double_1, double double_2)
	{
		double num = (double_1 + 7.5) / 15.0 - 0.5;
		DateTime dateTime = new DateTime(dateTime_0.Year, dateTime_0.Month, dateTime_0.Day, dateTime_0.Hour, dateTime_0.Minute, dateTime_0.Second, dateTime_0.Millisecond);
		DateTime dateTime2 = default(DateTime);
		dateTime2 = dateTime.AddHours(0.0 - num);
		return CollectSpecification(null, dateTime2.Year, dateTime2.Month, dateTime2.Day, dateTime2.Hour, dateTime2.Minute, dateTime2.Second, bool_0: false, double_0, double_1, double_2);
	}

	internal static string ForgotSpecification(Weather.TTimeOfDayType ttimeOfDayType_0, DateTime dateTime_0, double double_0, bool bool_0, string string_0, string string_1)
	{
		switch (ttimeOfDayType_0)
		{
		default:
			return "-";
		case Weather.TTimeOfDayType.tod_Day:
			return "Day";
		case Weather.TTimeOfDayType.tod_Twilight:
			if (Misc.DisableRequest(dateTime_0, double_0, bool_0, string_0, string_1).Hour < 12)
			{
				return "Dawn";
			}
			return "Dusk";
		case Weather.TTimeOfDayType.tod_Night:
			return "Night";
		}
	}

	internal static Weather.TTimeOfDayType CollectSpecification(object object_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, bool bool_0, double double_0, double double_1, double double_2)
	{
		if (int_0 < 1950)
		{
			int_0 = 1950;
		}
		if (int_0 > 2050)
		{
			int_0 = 2050;
		}
		int int_6 = 0;
		int int_7 = 0;
		if (bool_0 && !Information.IsNothing(object_0))
		{
			int_6 = Math.Max((int)Math.Floor(double_0 + 90.0), 0);
			int_7 = Math.Max((int)Math.Floor(double_1 + 180.0), 0);
			Weather.TTimeOfDayType? tTimeOfDayType = RegisterSpecification(ref ((Scenario)object_0).Cache_TimeOfDay, ref int_7, ref int_6);
			if (tTimeOfDayType.HasValue)
			{
				return tTimeOfDayType.Value;
			}
		}
		posdata posdata = new posdata();
		posdata.year = int_0;
		posdata.month = int_1;
		posdata.day = int_2;
		posdata.hour = int_3;
		posdata.minute = int_4;
		posdata.second = int_5;
		posdata.interval = 0;
		posdata.latitude = double_0;
		posdata.longitude = double_1;
		posdata.timezone = 0.0;
		posdata.func = 391;
		posdata.func &= -2;
		if (posdata.CallInterruptibleParam() == 0)
		{
			double elevref = posdata.elevref;
			posdata = null;
			Weather.TTimeOfDayType? tTimeOfDayType2 = ((!(elevref < -5.0 / 6.0)) ? new Weather.TTimeOfDayType?(Weather.TTimeOfDayType.tod_Day) : ((elevref <= -12.0) ? new Weather.TTimeOfDayType?(Weather.TTimeOfDayType.tod_Night) : new Weather.TTimeOfDayType?(Weather.TTimeOfDayType.tod_Twilight)));
			if (bool_0 && !Information.IsNothing(object_0))
			{
				ManageSpecification(ref ((Scenario)object_0).Cache_TimeOfDay, ref int_7, ref int_6, tTimeOfDayType2.Value);
			}
			return tTimeOfDayType2.Value;
		}
		throw new ArgumentOutOfRangeException("Error in solpos " + posdata.CallInterruptibleParam());
	}

	internal static Weather.TTimeOfDayType OrderSpecification(DateTime dateTime_0)
	{
		TimeSpan timeSpan = TimeSpan.FromHours(6.0);
		TimeSpan timeSpan2 = TimeSpan.FromHours(18.0);
		TimeSpan timeSpan3 = TimeSpan.FromHours(20.0);
		TimeSpan timeSpan4 = TimeSpan.FromHours(22.0);
		TimeSpan timeOfDay = dateTime_0.TimeOfDay;
		if (timeOfDay >= timeSpan && timeOfDay < timeSpan2)
		{
			return Weather.TTimeOfDayType.tod_Day;
		}
		if (timeOfDay >= timeSpan2 && timeOfDay < timeSpan3)
		{
			return Weather.TTimeOfDayType.tod_Twilight;
		}
		if ((timeOfDay >= timeSpan3 && timeOfDay < timeSpan4) || timeOfDay < timeSpan)
		{
			return Weather.TTimeOfDayType.tod_Night;
		}
		return Weather.TTimeOfDayType.tod_Twilight;
	}

	private static Weather.TTimeOfDayType? RegisterSpecification(ref Weather.TTimeOfDayType?[][] nullable_0, ref int int_0, ref int int_1)
	{
		try
		{
			if (nullable_0[int_0] == null)
			{
				return null;
			}
			Weather.TTimeOfDayType?[] array = nullable_0[int_0];
			if (array == null)
			{
				return null;
			}
			return array[int_1];
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 20043634777111223", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static void ManageSpecification(ref Weather.TTimeOfDayType?[][] nullable_0, ref int int_0, ref int int_1, Weather.TTimeOfDayType ttimeOfDayType_0)
	{
		try
		{
			if (nullable_0[int_0] == null)
			{
				Weather.TTimeOfDayType?[] array = new Weather.TTimeOfDayType?[180];
				array[int_1] = ttimeOfDayType_0;
				nullable_0[int_0] = array;
			}
			else
			{
				nullable_0[int_0][int_1] = ttimeOfDayType_0;
			}
		}
		catch (OutOfMemoryException projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 2021349699118", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
