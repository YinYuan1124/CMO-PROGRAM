using System;
using CSMaterial;

public static class MercatorProjection
{
	public struct MercatorPixel
	{
		public double x;

		public double y;

		public MercatorPixel(double double_0, double double_1)
		{
			x = FindStruct(double_0);
			y = SetStruct(double_1);
		}
	}

	public struct TCoord
	{
		public double Lat;

		public double Lon;

		public TCoord(double double_0, double double_1)
		{
			Lat = double_0;
			Lon = double_1;
		}
	}

	public struct Point3D
	{
		public double X;

		public double Y;

		public double Z;

		public static Point3D operator -(Point3D point3D_0, Point3D point3D_1)
		{
			Point3D result = default(Point3D);
			result.X = point3D_0.X - point3D_1.X;
			result.Y = point3D_0.Y - point3D_1.Y;
			result.Z = point3D_0.Z - point3D_1.Z;
			return result;
		}

		public static Point3D operator +(Point3D point3D_0, Point3D point3D_1)
		{
			Point3D result = default(Point3D);
			result.X = point3D_0.X + point3D_1.X;
			result.Y = point3D_0.Y + point3D_1.Y;
			result.Z = point3D_0.Z + point3D_1.Z;
			return result;
		}

		public static double operator *(Point3D point3D_0, Point3D point3D_1)
		{
			return point3D_0.X * point3D_1.X + point3D_0.Y * point3D_1.Y + point3D_0.Z * point3D_1.Z;
		}

		public static Point3D operator *(double double_0, Point3D point3D_0)
		{
			Point3D result = default(Point3D);
			result.X = double_0 * point3D_0.X;
			result.Y = double_0 * point3D_0.Y;
			result.Z = double_0 * point3D_0.Z;
			return result;
		}

		public static double Dot(Point3D point3D_0, Point3D point3D_1)
		{
			return point3D_0.X * point3D_1.X + point3D_0.Y * point3D_1.Y + point3D_0.Z * point3D_1.Z;
		}

		public double Length()
		{
			return Math.Sqrt(X * X + Y * Y + Z * Z);
		}
	}

	private static readonly double _Bridge;

	private static readonly double invocation;

	private static readonly double m_Class;

	private static readonly double m_Request;

	private static readonly double value;

	private static readonly double _Tokenizer;

	private static readonly double stub;

	private static readonly double m_Writer;

	private static readonly double _Order;

	public static MercatorPixel toPixel(TCoord tcoord_0)
	{
		MercatorPixel result = default(MercatorPixel);
		result.x = FindStruct(tcoord_0.Lon);
		result.y = SetStruct(tcoord_0.Lat);
		return result;
	}

	public static TCoord toGeoCoord(double double_0, double double_1)
	{
		TCoord result = default(TCoord);
		result.Lon = FillStruct(double_0);
		result.Lat = yToLat(double_1);
		return result;
	}

	private static double FindStruct(double double_0)
	{
		return _Bridge * PopStruct(double_0);
	}

	private static double SetStruct(double double_0)
	{
		double_0 = Math.Min(89.9999999999, Math.Max(double_0, -89.9999999999));
		double num = PopStruct(double_0);
		double num2 = Math.Sin(num);
		double num3 = m_Request * num2;
		num3 = Math.Pow((1.0 - num3) / (1.0 + num3), value);
		double d = Math.Tan(0.5 * (Math.PI / 2.0 - num)) / num3;
		return 0.0 - _Bridge * Math.Log(d);
	}

	private static double FillStruct(double double_0)
	{
		return CalculateStruct(double_0) / _Bridge;
	}

	public static bool CheckGeoCoordinate(ref TCoord tcoord_0)
	{
		if (tcoord_0.Lat <= 90.0 && tcoord_0.Lat >= -90.0 && tcoord_0.Lon <= 180.0)
		{
			return tcoord_0.Lon >= -180.0;
		}
		return false;
	}

	public static double yToLat(double double_0)
	{
		double num = Math.Exp((0.0 - double_0) / _Bridge);
		double num2 = m_Writer - 2.0 * Math.Atan(num);
		double num3 = 1.0;
		int num4 = 0;
		while (Math.Abs(num3) > 1E-09 && num4 < 15)
		{
			double num5 = m_Request * Math.Sin(num2);
			num3 = m_Writer - 2.0 * Math.Atan(num * Math.Pow((1.0 - num5) / (1.0 + num5), value)) - num2;
			num2 += num3;
			num4++;
		}
		return CalculateStruct(num2);
	}

	private static double CalculateStruct(double double_0)
	{
		return double_0 * stub;
	}

	private static double PopStruct(double double_0)
	{
		return double_0 * _Tokenizer;
	}

	public static double SlantRangeNM(TCoord tcoord_0, TCoord tcoord_1)
	{
		MercatorPixel mercatorPixel = toPixel(tcoord_0);
		MercatorPixel mercatorPixel2 = toPixel(tcoord_1);
		return Math.Sqrt(Math.Pow(mercatorPixel.x - mercatorPixel2.x, 2.0) + Math.Pow(mercatorPixel.y - mercatorPixel2.y, 2.0)) / _Order;
	}

	public static double ClosureRate_Geocentric(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7)
	{
		MercatorPixel mercatorPixel = new MercatorPixel(double_1, double_0);
		MercatorPixel mercatorPixel2 = new MercatorPixel(double_5, double_4);
		VelToVector(double_2, double_3, out var double_8, out var double_9);
		VelToVector(double_6, double_7, out var double_10, out var double_11);
		double num = double_10 - double_8;
		double num2 = double_11 - double_9;
		double num3 = mercatorPixel2.x - mercatorPixel.x;
		double num4 = mercatorPixel2.y - mercatorPixel.y;
		double num5 = num3 * num + num4 * num2;
		double num6 = Math.Sqrt(num3 * num3 + num4 * num4);
		return 0.0 - num5 / num6;
	}

	public static double ClosureRate_EarthSurface(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7)
	{
		VelToVector(double_2, double_3, out var double_8, out var double_9);
		VelToVector(double_6, double_7, out var double_10, out var double_11);
		double x = double_10 - double_8;
		double x2 = double_11 - double_9;
		return Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(x2, 2.0)) * 3600.0 / _Order;
	}

	public static void VelToVector(double double_0, double double_1, out double double_2, out double double_3)
	{
		double num = double_1 * Math.PI / 180.0;
		double_2 = double_0 * Math.Sin(num);
		double_3 = double_0 * Math.Cos(num);
	}

	static MercatorProjection()
	{
		_Bridge = 6378137.0;
		invocation = 6356752.3142;
		m_Class = invocation / _Bridge;
		m_Request = Math.Sqrt(1.0 - m_Class * m_Class);
		value = 0.5 * m_Request;
		_Tokenizer = CSMath.PI_dividedBy_180;
		stub = 180.0 / Math.PI;
		m_Writer = Math.PI / 2.0;
		_Order = 1852.0;
	}
}
