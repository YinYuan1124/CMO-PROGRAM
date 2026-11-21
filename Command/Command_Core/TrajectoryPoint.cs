using System;

namespace Command_Core;

public struct TrajectoryPoint
{
	public double Longitude;

	public double Latitude;

	public float Altitude;

	public DateTime TimeZulu;

	private long setterProxy;

	public bool HasZeroCoords
	{
		get
		{
			if (Longitude == 0.0)
			{
				return Latitude == 0.0;
			}
			return false;
		}
	}

	public TrajectoryPoint(double double_0, double double_1, float float_0, DateTime dateTime_0)
	{
		this = default(TrajectoryPoint);
		Longitude = double_0;
		Latitude = double_1;
		Altitude = float_0;
		TimeZulu = dateTime_0;
		setterProxy = TimeZulu.Ticks;
	}

	internal GeoPoint SetWatcher()
	{
		return new GeoPoint(Longitude, Latitude, Altitude);
	}

	internal Geopoint_Struct FillWatcher()
	{
		return new Geopoint_Struct(Longitude, Latitude, Altitude);
	}

	public ReferencePoint ToReferencePoint()
	{
		return new ReferencePoint(Longitude, Latitude);
	}

	public float RangeToPoint_Horiz(double double_0, double double_1)
	{
		return Math2.VerifyClass(Latitude, Longitude, double_1, double_0);
	}

	public static TrajectoryPoint Interpolate(TrajectoryPoint trajectoryPoint_0, TrajectoryPoint trajectoryPoint_1, DateTime dateTime_0)
	{
		TrajectoryPoint result = trajectoryPoint_1;
		double totalMilliseconds = (trajectoryPoint_1.TimeZulu - dateTime_0).TotalMilliseconds;
		if (totalMilliseconds < 1.0)
		{
			return trajectoryPoint_1;
		}
		double totalMilliseconds2 = (trajectoryPoint_1.TimeZulu - trajectoryPoint_0.TimeZulu).TotalMilliseconds;
		if (totalMilliseconds2 < totalMilliseconds)
		{
			return trajectoryPoint_1;
		}
		double num = 1.0 - totalMilliseconds / totalMilliseconds2;
		float float_ = Math2.PublishClass(trajectoryPoint_0.Latitude, trajectoryPoint_0.Longitude, trajectoryPoint_1.Latitude, trajectoryPoint_1.Longitude);
		double double_ = num * (double)trajectoryPoint_0.RangeToPoint_Horiz(trajectoryPoint_1.Longitude, trajectoryPoint_1.Latitude);
		Geodesic_EdWilliams.CalcPoint_Williams(ref trajectoryPoint_0.Longitude, ref trajectoryPoint_0.Latitude, ref result.Longitude, ref result.Latitude, ref double_, ref float_);
		result.Altitude = trajectoryPoint_0.Altitude + (float)(num * (double)(trajectoryPoint_1.Altitude - trajectoryPoint_0.Altitude));
		return result;
	}

	public static TrajectoryPoint? GetExactPointAtTime(TrajectoryPoint[] trajectoryPoint_0, TrajectoryPoint trajectoryPoint_1, DateTime dateTime_0)
	{
		TrajectoryPoint trajectoryPoint_2 = trajectoryPoint_1;
		long ticks = dateTime_0.Ticks;
		int num = trajectoryPoint_0.Length - 1;
		TrajectoryPoint? result = null;
		for (int i = 0; i <= num; i++)
		{
			TrajectoryPoint trajectoryPoint = trajectoryPoint_0[i];
			if (trajectoryPoint.setterProxy < ticks)
			{
				trajectoryPoint_2 = trajectoryPoint;
				continue;
			}
			result = Interpolate(trajectoryPoint_2, trajectoryPoint, dateTime_0);
			break;
		}
		return result;
	}
}
