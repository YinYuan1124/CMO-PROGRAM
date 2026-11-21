using System;
using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public sealed class Julian
{
	[CompilerGenerated]
	private double m_Visitor;

	public double Date
	{
		[CompilerGenerated]
		get
		{
			return m_Visitor;
		}
		[CompilerGenerated]
		private set
		{
			m_Visitor = value;
		}
	}

	public double FromJan0_12h_1900()
	{
		return Date - 2415020.0;
	}

	public double FromJan1_00h_1900()
	{
		return Date - 2415020.5;
	}

	public double FromJan1_12h_1900()
	{
		return Date - 2415021.0;
	}

	public double FromJan1_12h_2000()
	{
		return Date - 2451545.0;
	}

	public Julian(DateTime dateTime_0)
	{
		double double_ = (double)dateTime_0.DayOfYear + ((double)dateTime_0.Hour + ((double)dateTime_0.Minute + ((double)dateTime_0.Second + (double)dateTime_0.Millisecond / 1000.0) / 60.0) / 60.0) / 24.0;
		Initialize(dateTime_0.Year, double_);
	}

	public Julian(Julian julian_0)
	{
		Date = julian_0.Date;
	}

	public Julian(int int_0, double double_0)
	{
		Initialize(int_0, double_0);
	}

	public void AddDay(double double_0)
	{
		Date += double_0;
	}

	public void AddHour(double double_0)
	{
		Date += double_0 / 24.0;
	}

	public void AddMin(double double_0)
	{
		Date += double_0 / 1440.0;
	}

	public void AddSec(double double_0)
	{
		Date += double_0 / 86400.0;
	}

	public TimeSpan Diff(Julian julian_0)
	{
		return new TimeSpan((long)((Date - julian_0.Date) * 864000000000.0));
	}

	protected void Initialize(int int_0, double double_0)
	{
		if (int_0 >= 1900 && int_0 <= 2100)
		{
			if (!(double_0 >= 1.0) || double_0 >= 367.0)
			{
				throw new ArgumentOutOfRangeException("doy");
			}
			int_0--;
			int num = int_0 / 100;
			int num2 = 2 - num + num / 4;
			double num3 = (double)((int)(365.25 * (double)int_0) + 428) + 1720994.5 + (double)num2;
			Date = num3 + double_0;
			return;
		}
		throw new ArgumentOutOfRangeException("year");
	}

	public double ToGmst()
	{
		double num = (Date + 0.5) % 1.0;
		double num2 = (FromJan1_12h_2000() - num) / 36525.0;
		double num3 = 24110.54841 + num2 * (8640184.812866 + num2 * (0.093104 - num2 * 6.2E-06));
		num3 = (num3 + 86636.555366976 * num) % 86400.0;
		if (num3 < 0.0)
		{
			num3 += 86400.0;
		}
		return Math.PI * 2.0 * (num3 / 86400.0);
	}

	public double ToLmst(double double_0)
	{
		return (ToGmst() + double_0) % (Math.PI * 2.0);
	}

	public DateTime ToTime()
	{
		int num = (int)(Date + 0.5);
		int num2 = (int)(((double)num - 1867216.25) / 36524.25);
		int num3 = num + 1 + num2 - num2 / 4 + 1524;
		int num4 = (int)(((double)num3 - 122.1) / 365.25);
		int num5 = (int)(365.25 * (double)num4);
		int num6 = (int)((double)(num3 - num5) / 30.6001);
		int num7 = ((((num6 <= 13) ? (num6 - 1) : (num6 - 13)) < 3) ? (num4 - 4715) : (num4 - 4716));
		Julian julian = new Julian(num7, 1.0);
		double value = Date - julian.Date;
		return new DateTime(num7, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddDays(value);
	}
}
