using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Geodesic_Vincenty
{
	public struct TEllipsoid
	{
		public string Name;

		public double a;

		public double RFLAT;
	}

	public struct TCoord
	{
		public double Lat;

		public double Lon;

		public TCoord(double double_0, double double_1)
		{
			this = default(TCoord);
			Lat = double_0;
			Lon = double_1;
		}
	}

	public struct PointD
	{
		public double X;

		public double Y;

		public PointD(double double_0, double double_1)
		{
			this = default(PointD);
			X = double_0;
			Y = double_1;
		}
	}

	public sealed class TLocalTM
	{
		protected double OriginLatR;

		protected double OriginLongR;

		protected double _OriginLat;

		protected double _OriginLong;

		protected double _FalseNorthing;

		protected double _FalseEasting;

		protected double _DeltaEasting;

		protected double _DeltaNorthing;

		protected double _ScaleFactor;

		protected double _ap;

		protected double _bp;

		protected double _cp;

		protected double _dp;

		protected double _ep;

		protected double _Es;

		protected double _Ebs;

		protected double _a;

		protected double _f;

		protected double _b;

		public TCoord Origin
		{
			get
			{
				TCoord result = default(TCoord);
				result.Lat = _OriginLat;
				result.Lon = _OriginLong;
				return result;
			}
			set
			{
			}
		}

		public double OriginLat => _OriginLat;

		public double OriginLong => _OriginLong;

		protected void Init(double double_0, double double_1)
		{
			_b = _a * (1.0 - _f);
			double double_2 = 0.0;
			if (CountInterruptibleQueue(5156.620156177406, 90.0, ref _DeltaEasting, ref _DeltaNorthing, bool_0: false) && CountInterruptibleQueue(0.0, 90.0, ref _DeltaEasting, ref double_2, bool_0: false))
			{
				_OriginLat = double_0;
				OriginLatR = double_0 * 0.0174532925199433;
				double num = SetupInvocation(double_1);
				OriginLongR = num * 0.0174532925199433;
				_OriginLong = num;
			}
		}

		public TLocalTM()
		{
			OriginLatR = 0.0;
			OriginLongR = 0.0;
			_OriginLat = 0.0;
			_OriginLong = 0.0;
			_FalseNorthing = 0.0;
			_FalseEasting = 0.0;
			_ScaleFactor = 1.0;
			_ap = 6367449.1458008;
			_bp = 16038.508696861;
			_cp = 16.832613334334;
			_dp = 0.021984404273757;
			_ep = 3.1148371319283E-05;
			_Es = 0.00669437999014138;
			_Ebs = 0.0067394967565869;
			_a = 6378137.0;
			_f = 0.0033528106647474805;
			Init(0.0, 0.0);
		}

		public TLocalTM(double double_0, double double_1)
		{
			OriginLatR = 0.0;
			OriginLongR = 0.0;
			_OriginLat = 0.0;
			_OriginLong = 0.0;
			_FalseNorthing = 0.0;
			_FalseEasting = 0.0;
			_ScaleFactor = 1.0;
			_ap = 6367449.1458008;
			_bp = 16038.508696861;
			_cp = 16.832613334334;
			_dp = 0.021984404273757;
			_ep = 3.1148371319283E-05;
			_Es = 0.00669437999014138;
			_Ebs = 0.0067394967565869;
			_a = 6378137.0;
			_f = 0.0033528106647474805;
			Init(double_0, double_1);
		}

		public TLocalTM(TCoord tcoord_0)
		{
			OriginLatR = 0.0;
			OriginLongR = 0.0;
			_OriginLat = 0.0;
			_OriginLong = 0.0;
			_FalseNorthing = 0.0;
			_FalseEasting = 0.0;
			_ScaleFactor = 1.0;
			_ap = 6367449.1458008;
			_bp = 16038.508696861;
			_cp = 16.832613334334;
			_dp = 0.021984404273757;
			_ep = 3.1148371319283E-05;
			_Es = 0.00669437999014138;
			_Ebs = 0.0067394967565869;
			_a = 6378137.0;
			_f = 0.0033528106647474805;
			Init(tcoord_0.Lat, tcoord_0.Lon);
		}

		public TLocalTM(PointF pointF_0)
		{
			OriginLatR = 0.0;
			OriginLongR = 0.0;
			_OriginLat = 0.0;
			_OriginLong = 0.0;
			_FalseNorthing = 0.0;
			_FalseEasting = 0.0;
			_ScaleFactor = 1.0;
			_ap = 6367449.1458008;
			_bp = 16038.508696861;
			_cp = 16.832613334334;
			_dp = 0.021984404273757;
			_ep = 3.1148371319283E-05;
			_Es = 0.00669437999014138;
			_Ebs = 0.0067394967565869;
			_a = 6378137.0;
			_f = 0.0033528106647474805;
			Init(pointF_0.Y, pointF_0.X);
		}

		public TLocalTM(ref PointD pointD_0)
		{
			OriginLatR = 0.0;
			OriginLongR = 0.0;
			_OriginLat = 0.0;
			_OriginLong = 0.0;
			_FalseNorthing = 0.0;
			_FalseEasting = 0.0;
			_ScaleFactor = 1.0;
			_ap = 6367449.1458008;
			_bp = 16038.508696861;
			_cp = 16.832613334334;
			_dp = 0.021984404273757;
			_ep = 3.1148371319283E-05;
			_Es = 0.00669437999014138;
			_Ebs = 0.0067394967565869;
			_a = 6378137.0;
			_f = 0.0033528106647474805;
			Init(pointD_0.Y, pointD_0.X);
		}

		internal bool CountInterruptibleQueue(double double_0, double double_1, ref double double_2, ref double double_3, bool bool_0)
		{
			int num = 0;
			double num12 = double_0;
			if (Math.Abs(num12) > 89.99999999999999)
			{
				num12 = ((num12 <= 0.0) ? (-89.99999999999999) : 89.99999999999999);
			}
			double num23 = num12 * 0.0174532925199433;
			if (num12 < -89.99999999999999 || num12 > 89.99999999999999)
			{
				num++;
			}
			while (double_1 > 180.0 || double_1 < -180.0)
			{
				double_1 = Math2.VisitClass(double_1);
			}
			double num34 = double_1 * 0.0174532925199433;
			if (num34 > 3.14159265358979)
			{
				num34 -= 6.28318530717958;
			}
			if (num34 < OriginLongR - 1.570796326794897 || num34 > OriginLongR + 1.570796326794897)
			{
				double num37 = ((num34 < 0.0) ? (num34 + 6.28318530717958) : num34);
				double num38 = ((OriginLongR < 0.0) ? (OriginLongR + 6.28318530717958) : OriginLongR);
				if (bool_0)
				{
					double num39 = 3.141592653589794;
					if (num37 < num38 - num39 || num37 > num38 + num39)
					{
						num += 2;
					}
				}
				else if (num37 < num38 - 1.570796326794897 || num37 > num38 + 1.570796326794897)
				{
					num += 2;
				}
			}
			if (num == 0)
			{
				double num40 = num34 - OriginLongR;
				if (Math.Abs(num40) > 0.15707963267948968)
				{
					num += 512;
				}
				if (num40 > 3.14159265358979)
				{
					num40 -= 6.28318530717958;
				}
				if (num40 < -3.14159265358979)
				{
					num40 += 6.28318530717958;
				}
				if (Math.Abs(num40) < 1E-60)
				{
					num40 = 0.0;
				}
				double num41 = Math.Sin(num23);
				double num2 = Math.Cos(num23);
				double num3 = num2 * num2;
				double num4 = num3 * num2;
				double num5 = num4 * num3;
				double num6 = num5 * num3;
				double num7 = Math.Tan(num23);
				double num8 = num7 * num7;
				double num9 = num8 * num7 * num7;
				double num10 = num9 * num7 * num7;
				double num11 = _Ebs * num3;
				double num13 = num11 * num11;
				double num14 = num13 * num11;
				double num15 = num14 * num11;
				double num16 = SPHSN(num23);
				double num17 = SPHTMD(num23);
				double num18 = SPHTMD(OriginLatR);
				double num19 = (num17 - num18) * _ScaleFactor;
				double num20 = num16 * num41 * num2 * _ScaleFactor / 2.0;
				double num21 = num16 * num41 * num4 * _ScaleFactor * (5.0 - num8 + 9.0 * num11 + 4.0 * num13) / 24.0;
				double num22 = num16 * num41 * num5 * _ScaleFactor * (61.0 - 58.0 * num8 + num9 + 270.0 * num11 - 330.0 * num8 * num11 + 445.0 * num13 + 324.0 * num14 - 680.0 * num8 * num13 + 88.0 * num15 - 600.0 * num8 * num14 - 192.0 * num8 * num15) / 720.0;
				double num24 = num16 * num41 * num6 * _ScaleFactor * (1385.0 - 3111.0 * num8 + 543.0 * num9 - num10) / 40320.0;
				double num25 = num40 * num40;
				double num26 = num25 * num40;
				double num27 = num25 * num25;
				double num28 = num27 * num40;
				double num29 = num27 * num25;
				double num30 = num29 * num40;
				double num31 = num27 * num27;
				double_3 = _FalseNorthing + num19 + num25 * num20 + num27 * num21 + num29 * num22 + num31 * num24;
				double num32 = num16 * num2 * _ScaleFactor;
				double num33 = num16 * num4 * _ScaleFactor * (1.0 - num8 + num11) / 6.0;
				double num35 = num16 * num5 * _ScaleFactor * (5.0 - 18.0 * num8 + num9 + 14.0 * num11 - 58.0 * num8 * num11 + 13.0 * num13 + 4.0 * num14 - 64.0 * num8 * num13 - 24.0 * num8 * num14) / 120.0;
				double num36 = num16 * num6 * _ScaleFactor * (61.0 - 479.0 * num8 + 179.0 * num9 - num10) / 5040.0;
				double_2 = _FalseEasting + num40 * num32 + num26 * num33 + num28 * num35 + num30 * num36;
				return true;
			}
			return false;
		}

		protected double SPHSR(double double_0)
		{
			double num = DENOM(double_0);
			return _a * (1.0 - _Es) / (num * num * num);
		}

		protected double DENOM(double double_0)
		{
			double num = Math.Sin(double_0);
			return Math.Sqrt(1.0 - _Es * (num * num));
		}

		protected double SPHSN(double double_0)
		{
			double num = Math.Sin(double_0);
			return _a / Math.Sqrt(1.0 - _Es * (num * num));
		}

		protected double SPHTMD(double double_0)
		{
			return _ap * double_0 - _bp * Math.Sin(2.0 * double_0) + _cp * Math.Sin(4.0 * double_0) - _dp * Math.Sin(6.0 * double_0) + _ep * Math.Sin(8.0 * double_0);
		}

		internal bool CustomizeInterruptibleQueue(double double_0, double double_1, ref double double_2, ref double double_3)
		{
			int num = 0;
			if ((double_0 < _FalseEasting - _DeltaEasting) | (double_0 > _FalseEasting + _DeltaEasting))
			{
				num += 4;
			}
			if ((double_1 < _FalseNorthing - _DeltaNorthing) | (double_1 > _FalseNorthing + _DeltaNorthing))
			{
				num += 8;
			}
			if (num == 0)
			{
				double num12 = _ap * OriginLatR - _bp * Math.Sin(2.0 * OriginLatR) + _cp * Math.Sin(4.0 * OriginLatR) - _dp * Math.Sin(6.0 * OriginLatR) + _ep * Math.Sin(8.0 * OriginLatR) + (double_1 - _FalseNorthing) / _ScaleFactor;
				double num23 = SPHSR(0.0);
				double num34 = num12 / num23;
				int num40 = 0;
				double num41;
				do
				{
					num41 = SPHTMD(num34);
					num23 = SPHSR(num34);
					num34 += (num12 - num41) / num23;
					num40++;
				}
				while (num40 <= 4);
				num23 = SPHSR(num34);
				double num42 = SPHSN(num34);
				Math.Sin(num34);
				double num43 = Math.Cos(num34);
				double num44 = Math.Tan(num34);
				double num2 = num44 * num44;
				double num3 = num2 * num2;
				double num4 = num3 * num2;
				double num5 = _Ebs * (num43 * num43);
				double num6 = num5 * num5;
				double num7 = num6 * num5;
				double num8 = num7 * num5;
				double num9 = double_0 - _FalseEasting;
				if (Math.Abs(num9) < 0.0001)
				{
					num9 = 0.0;
				}
				double num10 = _ScaleFactor * _ScaleFactor;
				double num11 = num10 * _ScaleFactor;
				double num13 = num10 * num10;
				double num14 = num13 * _ScaleFactor;
				double num15 = num13 * num10;
				double num16 = num15 * _ScaleFactor;
				double num17 = num13 * num13;
				double num18 = num42 * num42;
				double num19 = num18 * num42;
				double num20 = num19 * num18;
				double num21 = num20 * num18;
				double num22 = num9 * num9;
				double num24 = num22 * num9;
				double num25 = num22 * num22;
				double num26 = num25 * num9;
				double num27 = num25 * num22;
				double num28 = num27 * num9;
				double num29 = num25 * num25;
				num41 = num44 / (2.0 * num23 * num42 * num10);
				double num30 = num44 * (5.0 + 3.0 * num2 + num5 - 4.0 * num6 - 9.0 * num2 * num5) / (24.0 * num23 * num19 * num13);
				double num31 = num44 * (61.0 + 90.0 * num2 + 46.0 * num5 + 45.0 * num3 - 252.0 * num2 * num5 - 3.0 * num6 + 100.0 * num7 - 66.0 * num2 * num6 - 90.0 * num3 * num5 + 88.0 * num8 + 225.0 * num3 * num6 + 84.0 * num2 * num7 - 192.0 * num2 * num8) / (720.0 * num23 * num20 * num15);
				double num32 = num44 * (1385.0 + 3633.0 * num2 + 4095.0 * num3 + 1575.0 * num4) / (40320.0 * num23 * num21 * num17);
				double num33 = num34 - num22 * num41 + num25 * num30 - num27 * num31 + num29 * num32;
				double num35 = 1.0 / (num42 * num43 * _ScaleFactor);
				double num36 = (1.0 + 2.0 * num2 + num5) / (6.0 * num19 * num43 * num11);
				double num37 = (5.0 + 6.0 * num5 + 28.0 * num2 - 3.0 * num6 + 8.0 * num2 * num5 + 24.0 * num3 - 4.0 * num7 + 4.0 * num2 * num6 + 24.0 * num2 * num7) / (120.0 * num20 * num43 * num14);
				double num38 = (61.0 + 662.0 * num2 + 1320.0 * num3 + 720.0 * num4) / (5040.0 * num21 * num43 * num16);
				double num39 = num9 * num35 - num24 * num36 + num26 * num37 - num28 * num38;
				double double_4 = OriginLongR + num39;
				if (Math.Abs(num33) > 1.570796326794897)
				{
					num += 8;
				}
				if (Math.Abs(num39) > 0.15707963267948968 * Math.Cos(num33 * 0.0174532925199433))
				{
					num += 512;
				}
				if (num33 > 10000000000.0)
				{
					num += 512;
				}
				double_2 = num33 * 57.2957795130823;
				double_3 = SetupInvocation(double_4) * 57.2957795130823;
				return true;
			}
			return false;
		}

		public void ReprojectToTargetTM(ref TLocalTM tlocalTM_0, double double_0, double double_1, ref double double_2, ref double double_3)
		{
			double double_4 = 0.0;
			double double_5 = 0.0;
			if (CustomizeInterruptibleQueue(double_0, double_1, ref double_4, ref double_5))
			{
				tlocalTM_0.CountInterruptibleQueue(double_4, double_5, ref double_2, ref double_3, bool_0: false);
			}
		}

		internal PointD CloneInterruptibleQueue(ref TLocalTM tlocalTM_0, ref PointD pointD_0)
		{
			PointD pointD_ = MoveInterruptibleQueue(ref pointD_0);
			return tlocalTM_0.DestroyInterruptibleQueue(ref pointD_);
		}

		internal PointF ConnectInterruptibleQueue(PointF pointF_0)
		{
			double double_ = 0.0;
			double double_2 = 0.0;
			if (!CustomizeInterruptibleQueue(pointF_0.X, pointF_0.Y, ref double_, ref double_2))
			{
				return default(PointF);
			}
			return new PointF((float)double_2, (float)double_);
		}

		internal PointD MoveInterruptibleQueue(ref PointD pointD_0)
		{
			double double_ = 0.0;
			double double_2 = 0.0;
			if (!CustomizeInterruptibleQueue(pointD_0.X, pointD_0.Y, ref double_, ref double_2))
			{
				return default(PointD);
			}
			return new PointD(double_2, double_);
		}

		internal TCoord DeleteInterruptibleQueue(ref PointD pointD_0)
		{
			double double_ = 0.0;
			double double_2 = 0.0;
			if (CustomizeInterruptibleQueue(pointD_0.X, pointD_0.Y, ref double_, ref double_2))
			{
				TCoord result = default(TCoord);
				result.Lat = double_;
				result.Lon = double_2;
				return result;
			}
			return default(TCoord);
		}

		internal PointF AddInterruptibleQueue(PointF pointF_0)
		{
			double double_ = 0.0;
			double double_2 = 0.0;
			if (!CountInterruptibleQueue(pointF_0.Y, pointF_0.X, ref double_, ref double_2, bool_0: false))
			{
				return default(PointF);
			}
			return new PointF((float)double_, (float)double_2);
		}

		internal PointD DestroyInterruptibleQueue(ref PointD pointD_0, bool bool_0 = false)
		{
			double double_ = 0.0;
			double double_2 = 0.0;
			if (!CountInterruptibleQueue(pointD_0.Y, pointD_0.X, ref double_, ref double_2, bool_0))
			{
				return default(PointD);
			}
			return new PointD(double_, double_2);
		}

		internal PointD ComputeInterruptibleQueue(TCoord tcoord_0)
		{
			double double_ = 0.0;
			double double_2 = 0.0;
			if (!CountInterruptibleQueue(tcoord_0.Lat, tcoord_0.Lon, ref double_, ref double_2, bool_0: false))
			{
				return default(PointD);
			}
			return new PointD(double_, double_2);
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

		internal double PatchInterruptibleQueue()
		{
			return Math.Sqrt(X * X + Y * Y + Z * Z);
		}
	}

	public struct TAzElRange
	{
		public double Elevation;

		public double Azimouth;

		public double RangeKM;

		public double RangeNM
		{
			get
			{
				return RangeKM * 1000.0 / 1852.0;
			}
			set
			{
				RangeKM = value * 1852.0 / 1000.0;
			}
		}
	}

	public delegate void ForwardGeoSolution(double Coord1_A, double Coord2_A, ref double Coord1_B, ref double Coord2_B, double AzimouthAB_Degrees, double DistanceAB);

	public delegate void InverseGeoSolution(double Coord1_A, double Coord2_A, double Coord1_B, double Coord2_B, ref double AzimouthAB_Degrees, ref double AzimouthBA_Degrees, ref double DistanceAB);

	private delegate double StateParameterMock(double x, double[] @params);

	public const double DTOL = 1E-12;

	public const double NEW_DTOL = 1E-10;

	public const double WGS84_A = 6378137.0;

	public const double WGS84_RFLAT = 298.257223563;

	public const string ModuleVersion = "Version 3.22";

	public const string ModuleCredits = "Credits: T.Vincenty, \r\n'Direct and inverse solutions of geodesics of nested equations'. \r\nSurvey Review XXII, 176, April 1975. Pp.88-93.\r\nP.S.Zakatov. Kurs vysshei geodezii. 4th ed. M., 1976.\r\nU.S. Army Topographic Engineering Center, Geospatial Information Division 7701 Telegraph Road Alexandria, VA  22310-3864 - for TransMerc code\r\nGerald Evenden (proj code) and Frank Warmerdam (proj copyright holder)\r\nParts of code: (C) Dimitris V. Dranidis, 2009\r\nBrent minimization routine: AlgLib, (C) Bochkanov Sergey 09.04.2007";

	public const int TRANMERC_NO_ERROR = 0;

	public const int TRANMERC_LAT_ERROR = 1;

	public const int TRANMERC_LON_ERROR = 2;

	public const int TRANMERC_EASTING_ERROR = 4;

	public const int TRANMERC_NORTHING_ERROR = 8;

	public const int TRANMERC_ORIGIN_LAT_ERROR = 16;

	public const int TRANMERC_CENT_MER_ERROR = 32;

	public const int TRANMERC_A_ERROR = 64;

	public const int TRANMERC_INV_F_ERROR = 128;

	public const int TRANMERC_SCALE_FACTOR_ERROR = 256;

	public const int TRANMERC_LON_WARNING = 512;

	public const int STEREO_NO_ERROR = 0;

	public const int STEREO_LAT_ERROR = 1;

	public const int STEREO_LON_ERROR = 2;

	public const int STEREO_ORIGIN_LAT_ERROR = 4;

	public const int STEREO_CENT_MER_ERROR = 8;

	public const int STEREO_EASTING_ERROR = 16;

	public const int STEREO_NORTHING_ERROR = 32;

	public const int STEREO_A_ERROR = 64;

	public const int STEREO_INV_F_ERROR = 128;

	internal static PointF ValidateInvocation(ref PointD pointD_0)
	{
		return new PointF((float)pointD_0.X, (float)pointD_0.Y);
	}

	internal static PointD LoginInvocation(PointF pointF_0)
	{
		return new PointD(pointF_0.X, pointF_0.Y);
	}

	public static void VelToVector(double double_0, double double_1, ref double double_2, ref double double_3)
	{
		double_2 = double_0 * (463.0 / 900.0) * Math.Sin(double_1 * 0.0174532925199433);
		double_3 = double_0 * (463.0 / 900.0) * Math.Cos(double_1 * 0.0174532925199433);
	}

	internal static double GetInvocation(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7)
	{
		TLocalTM tLocalTM = new TLocalTM(double_0, double_1);
		double num = 0.0;
		double num2 = 0.0;
		double double_12 = 0.0;
		double double_13 = 0.0;
		if (tLocalTM.CountInterruptibleQueue(double_4, double_5, ref double_12, ref double_13, bool_0: false))
		{
			double num3 = num - double_12;
			double num4 = num2 - double_13;
			double double_8 = 0.0;
			double double_9 = 0.0;
			VelToVector(double_2, double_3, ref double_8, ref double_9);
			double double_10 = 0.0;
			double double_11 = 0.0;
			VelToVector(double_6, double_7, ref double_10, ref double_11);
			double num5 = double_8 - double_10;
			double num6 = double_9 - double_11;
			return ((num3 != 0.0 || num4 != 0.0) ? ((0.0 - (num3 * num5 + num4 * num6)) / Math.Sqrt(num3 * num3 + num4 * num4)) : (0.0 - Math.Sqrt(num5 * num5 + num6 * num6))) * 3600.0 / 1852.0;
		}
		return 0.0;
	}

	public static double arccos2(double double_0, double double_1)
	{
		if (double_0 != 0.0 && double_1 != 0.0)
		{
			if (!(double_1 <= 0.0))
			{
				return Math.Acos(double_0 / double_1);
			}
			if (double_1 < 0.0)
			{
				return 3.14159265358979 + Math.Acos(double_0 / double_1);
			}
		}
		return 0.0;
	}

	internal static Point3D WriteInvocation(double double_0, double double_1, double double_2)
	{
		Point3D result = default(Point3D);
		double num = double_2 + 6371000.0;
		double num2 = num * Math.Cos(double_0 * 0.0174532925199433);
		result.X = num2 * Math.Cos(double_1 * 0.0174532925199433);
		result.Y = num2 * Math.Sin(double_1 * 0.0174532925199433);
		result.Z = num * Math.Sin(double_0 * 0.0174532925199433);
		return result;
	}

	public static void ApproxSphericalToCartesian(double double_0, double double_1, double double_2, ref double double_3, ref double double_4, ref double double_5)
	{
		double num = double_2 + 6371000.0;
		double num2 = num * Math.Cos(double_0 * 0.0174532925199433);
		double_3 = num2 * Math.Cos(double_1 * 0.0174532925199433);
		double_4 = num2 * Math.Sin(double_1 * 0.0174532925199433);
		double_5 = num * Math.Sin(double_0 * 0.0174532925199433);
	}

	public static void ApproxCartesianToSpherical(double double_0, double double_1, double double_2, ref double double_3, ref double double_4, ref double double_5)
	{
		double num = Math.Sqrt(double_0 * double_0 + double_1 * double_1 + double_2 * double_2);
		double_4 = Math.Atan2(double_1, double_0) * 57.2957795130823;
		double_3 = Math.Asin(double_2 / num) * 57.2957795130823;
		double_5 = num - 6371000.0;
	}

	public static void PartitionArc(double double_0, double double_1, double double_2, double double_3, double double_4, int int_0, ref Point3D[] point3D_0)
	{
		double num = SetupInvocation(double_3) - double_4 / 2.0;
		double num4 = double_0 * 0.0174532925199433;
		double num5 = double_1 * 0.0174532925199433;
		double num6 = double_2 * 1852.0 / 1000.0 / 6371.0;
		point3D_0 = new Point3D[int_0 - 1 + 1];
		double num7 = double_4 / (double)(int_0 - 1);
		int num8 = int_0 - 1;
		for (int i = 0; i <= num8; i++)
		{
			double num9 = num + (double)i * num7;
			double d = num9 * 0.0174532925199433;
			double num10 = Math.Asin(Math.Sin(num4) * Math.Cos(num6) + Math.Cos(d) * Math.Sin(num6) * Math.Cos(num4));
			double num11 = Math.Cos(num6) - Math.Sin(num4) * Math.Sin(num10);
			double num2 = Math.Cos(num4) * Math.Cos(num10);
			double num3;
			for (num3 = ((Math.Abs(num9) < 0.001 && !(num6 <= 1.5707963267949 - num4)) ? (num5 + 3.14159265358979) : ((Math.Abs(num9 - 180.0) < 0.001 && !(num6 <= 1.5707963267949 + num4)) ? (num5 + 3.14159265358979) : ((!(Math.Abs(num11 / num2) <= 1.0)) ? num5 : ((180.0 - num9 < 0.0) ? (num5 + arccos2(num11, num2)) : (num5 - arccos2(num11, num2)))))); num3 < -3.14159265358979; num3 += 6.28318530717959)
			{
			}
			while (num3 > 3.14159265358979)
			{
				num3 -= 6.28318530717959;
			}
			point3D_0[i].Y = (float)(num10 * 57.2957795130823);
			point3D_0[i].X = (float)(num3 * 57.2957795130823);
		}
	}

	public static void PartitionCircle(double double_0, double double_1, double double_2, int int_0, ref Point3D[] point3D_0)
	{
		double num = double_0 * 0.0174532925199433;
		double num3 = double_1 * 0.0174532925199433;
		double num4 = double_2 * 1852.0 / 1000.0 / 6371.0;
		point3D_0 = new Point3D[int_0 + 1];
		double num5 = 360.0 / (double)int_0;
		int num6 = int_0 - 1;
		for (int i = 0; i <= num6; i++)
		{
			double num7 = (double)i * num5;
			double d = num7 * 0.0174532925199433;
			double num8 = Math.Asin(Math.Sin(num) * Math.Cos(num4) + Math.Cos(d) * Math.Sin(num4) * Math.Cos(num));
			double num9 = Math.Cos(num4) - Math.Sin(num) * Math.Sin(num8);
			double num10 = Math.Cos(num) * Math.Cos(num8);
			double num2;
			for (num2 = ((num7 == 0.0 && !(num4 <= 1.5707963267949 - num)) ? (num3 + 3.14159265358979) : ((num7 == 180.0 && !(num4 <= 1.5707963267949 + num)) ? (num3 + 3.14159265358979) : ((!(Math.Abs(num9 / num10) <= 1.0)) ? num3 : ((180.0 - num7 < 0.0) ? (num3 + arccos2(num9, num10)) : (num3 - arccos2(num9, num10)))))); num2 < -3.14159265358979; num2 += 6.28318530717959)
			{
			}
			while (num2 > 3.14159265358979)
			{
				num2 -= 6.28318530717959;
			}
			point3D_0[i].Y = (float)(num8 * 57.2957795130823);
			point3D_0[i].X = (float)(num2 * 57.2957795130823);
		}
		point3D_0[int_0] = point3D_0[0];
	}

	internal static GraphicsPath NewInvocation(double double_0, double double_1, double double_2, int int_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		double num = double_0 * 0.0174532925199433;
		double num3 = double_1 * 0.0174532925199433;
		double num4 = double_2 * 1852.0 / 1000.0 / 6371.0;
		PointF[] array = new PointF[int_0 + 1];
		double num5 = 360.0 / (double)int_0;
		int num6 = int_0 - 1;
		for (int i = 0; i <= num6; i++)
		{
			double num7 = (double)i * num5;
			double d = num7 * 0.0174532925199433;
			double num8 = Math.Asin(Math.Sin(num) * Math.Cos(num4) + Math.Cos(d) * Math.Sin(num4) * Math.Cos(num));
			double num9 = Math.Cos(num4) - Math.Sin(num) * Math.Sin(num8);
			double num10 = Math.Cos(num) * Math.Cos(num8);
			double num2;
			for (num2 = ((num7 == 0.0 && !(num4 <= 1.5707963267949 - num)) ? (num3 + 3.14159265358979) : ((num7 == 180.0 && !(num4 <= 1.5707963267949 + num)) ? (num3 + 3.14159265358979) : ((!(Math.Abs(num9 / num10) <= 1.0)) ? num3 : ((180.0 - num7 < 0.0) ? (num3 + arccos2(num9, num10)) : (num3 - arccos2(num9, num10)))))); num2 < -3.14159265358979; num2 += 6.28318530717959)
			{
			}
			while (num2 > 3.14159265358979)
			{
				num2 -= 6.28318530717959;
			}
			array[i].Y = (float)(num8 * 57.2957795130823);
			array[i].X = (float)(num2 * 57.2957795130823);
		}
		array[int_0] = array[0];
		graphicsPath.AddLines(array);
		return graphicsPath;
	}

	public static void GenericCoverageZone(double double_0, double double_1, double double_2, int int_0, ref Point3D[] point3D_0)
	{
		double num = double_0 * 0.0174532925199433;
		double num4 = double_1 * 0.0174532925199433;
		double num5 = 12742.0 * Math.Acos(6371.0 / (6371.0 + double_2));
		double num6 = 0.5 * num5 / 6371.0;
		point3D_0 = new Point3D[int_0 - 1 + 1];
		double num7 = 360.0 / (double)int_0;
		int num8 = int_0 - 1;
		for (int i = 0; i <= num8; i++)
		{
			double num9 = (double)i * num7;
			double d = num9 * 0.0174532925199433;
			double num10 = Math.Asin(Math.Sin(num) * Math.Cos(num6) + Math.Cos(d) * Math.Sin(num6) * Math.Cos(num));
			double num11 = Math.Cos(num6) - Math.Sin(num) * Math.Sin(num10);
			double num2 = Math.Cos(num) * Math.Cos(num10);
			double num3;
			for (num3 = ((num9 == 0.0 && !(num6 <= 1.5707963267949 - num)) ? (num4 + 3.14159265358979) : ((num9 == 180.0 && !(num6 <= 1.5707963267949 + num)) ? (num4 + 3.14159265358979) : ((!(Math.Abs(num11 / num2) <= 1.0)) ? num4 : ((180.0 - num9 < 0.0) ? (num4 + arccos2(num11, num2)) : (num4 - arccos2(num11, num2)))))); num3 < -3.14159265358979; num3 += 6.28318530717959)
			{
			}
			while (num3 > 3.14159265358979)
			{
				num3 -= 6.28318530717959;
			}
			point3D_0[i].Y = num10 * 57.2957795130823;
			point3D_0[i].X = num3 * 57.2957795130823;
		}
	}

	internal static double PushInvocation(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5)
	{
		double num = 6371000.0;
		Point3D point3D = WriteInvocation(double_3, double_4, double_5);
		Point3D point3D2 = WriteInvocation(double_0, double_1, double_2);
		Point3D point3D_ = point3D - point3D2;
		double d = Point3D.Dot(point3D, point3D2) / ((double_5 + num) * (double_2 + num));
		double d2 = Point3D.Dot(point3D, point3D_) / ((double_5 + num) * point3D_.PatchInterruptibleQueue());
		return 90.0 - (Math.Acos(d) + Math.Acos(d2)) * 57.2957795130823;
	}

	public static void ApproxElevationRange(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, ref double double_6, ref double double_7)
	{
		double num = 6371000.0;
		Point3D point3D = WriteInvocation(double_3, double_4, double_5);
		Point3D point3D2 = WriteInvocation(double_0, double_1, double_2);
		Point3D point3D_ = point3D - point3D2;
		double d = Point3D.Dot(point3D, point3D2) / ((double_5 + num) * (double_2 + num));
		double num2 = point3D_.PatchInterruptibleQueue();
		double d2 = Point3D.Dot(point3D, point3D_) / ((double_5 + num) * num2);
		double_7 = num2 / 1000.0;
		double_6 = 90.0 - (Math.Acos(d) + Math.Acos(d2)) * 57.2957795130823;
	}

	internal static double InvokeInvocation(double double_0)
	{
		if (Math.Abs(double_0) <= 3.14159265359)
		{
			return double_0;
		}
		double_0 += 3.14159265358979;
		double_0 -= 6.28318530717959 * Math.Floor(double_0 / 6.28318530717959);
		double_0 -= 3.14159265358979;
		return double_0;
	}

	internal static double SetupInvocation(double double_0)
	{
		double num = double_0;
		if (Math.Abs(double_0) <= 180.0)
		{
			return double_0;
		}
		num += 180.0;
		num -= 360.0 * Math.Floor(num / 360.0);
		return num - 180.0;
	}

	public static void fw_geod_wgs84_2(double double_0, double double_1, ref double double_2, ref double double_3, double double_4, double double_5)
	{
		TCoord tcoord_ = default(TCoord);
		tcoord_.Lat = double_0;
		tcoord_.Lon = double_1;
		TCoord tcoord_2 = default(TCoord);
		fw_geod_wgs84(ref tcoord_, ref tcoord_2, double_4, double_5);
		double_2 = tcoord_2.Lat;
		double_3 = tcoord_2.Lon;
	}

	public static void fw_vincenty_wgs84_2(double double_0, double double_1, ref double double_2, ref double double_3, double double_4, double double_5)
	{
		fw_vincenty_wgs84(double_0, double_1, ref double_2, ref double_3, double_4, double_5);
	}

	public static void smethod_0(ref double double_0, ref double double_1, ref double double_2, ref double double_3, ref double double_4)
	{
		double num = Math.Cos(double_0 * 0.0174532925199433);
		double num2 = Math.Sin(double_0 * 0.0174532925199433);
		double num3 = 40680631590769.0;
		double num4 = 40408299984661.445;
		double num5 = Math.Sqrt(num3 * num * num + num4 * num2 * num2);
		double_2 = num3 * num * Math.Cos(double_1 * 0.0174532925199433) / num5;
		double_3 = num3 * num * Math.Sin(double_1 * 0.0174532925199433) / num5;
		double_4 = num4 * num2 / num5;
	}

	internal static Point3D ExcludeInvocation(TCoord tcoord_0, double double_0 = 0.0)
	{
		double num = Math.Cos(tcoord_0.Lat * 0.0174532925199433);
		double num2 = Math.Sin(tcoord_0.Lat * 0.0174532925199433);
		double num3 = 40680631590769.0;
		double num4 = 40408299984661.445;
		double num5 = Math.Sqrt(num3 * num * num + num4 * num2 * num2);
		Point3D result = default(Point3D);
		result.X = num3 * num * Math.Cos(tcoord_0.Lon * 0.0174532925199433) / num5;
		result.Y = num3 * num * Math.Sin(tcoord_0.Lon * 0.0174532925199433) / num5;
		result.Z = num4 * num2 / num5;
		return result;
	}

	internal static double IncludeInvocation(TCoord tcoord_0, TCoord tcoord_1, double double_0, double double_1)
	{
		Point3D point3D = ExcludeInvocation(tcoord_0, double_0);
		Point3D point3D2 = ExcludeInvocation(tcoord_1, double_1);
		return Math.Sqrt((point3D.X - point3D2.X) * (point3D.X - point3D2.X) + (point3D.Y - point3D2.Y) * (point3D.Y - point3D2.Y) + (point3D.Z - point3D2.Z) * (point3D.Z - point3D2.Z)) / 1852.0;
	}

	internal static double SearchInvocation(ref double double_0, ref double double_1, ref double double_2, ref double double_3)
	{
		double double_4 = 0.0;
		double double_5 = 0.0;
		double double_6 = 0.0;
		smethod_0(ref double_0, ref double_1, ref double_4, ref double_5, ref double_6);
		double double_7 = 0.0;
		double double_8 = 0.0;
		double double_9 = 0.0;
		smethod_0(ref double_2, ref double_3, ref double_7, ref double_8, ref double_9);
		return Math.Sqrt((double_4 - double_7) * (double_4 - double_7) + (double_5 - double_8) * (double_5 - double_8) + (double_6 - double_9) * (double_6 - double_9)) / 1852.0;
	}

	internal static double EnableInvocation(double double_0, double double_1, double double_2)
	{
		double d = double_0 * 1852.0 / 6371000.0;
		double num = 6371000.0 + double_2;
		double num2 = 6371000.0 + double_1;
		double num3 = num * num;
		double num4 = num2 * num2;
		double num5 = Math.Sqrt(num3 + num4 - 2.0 * num * num2 * Math.Cos(d));
		return Math.Acos((num5 * num5 + num3 - num4) / (2.0 * num5 * num)) * 57.2957795130823 - 90.0;
	}

	public static void PartitionGeodesic(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, int int_0, ref Point3D[] point3D_0)
	{
		if (int_0 == 0)
		{
			throw new Exception("zero numsegments");
		}
		if (double_0 == double_3 && double_1 == double_4 && double_2 == double_5)
		{
			point3D_0 = new Point3D[1];
			point3D_0[0].X = double_1;
			point3D_0[0].Y = double_0;
			point3D_0[0].Z = double_2;
			return;
		}
		double num = (double_5 - double_2) / (double)int_0;
		if (double_0 == double_3 && double_1 == double_4)
		{
			point3D_0 = new Point3D[int_0 + 1];
			point3D_0[0].X = double_1;
			point3D_0[0].Y = double_0;
			point3D_0[0].Z = double_2;
			for (int i = 1; i <= int_0; i++)
			{
				point3D_0[i].X = double_1;
				point3D_0[i].Y = double_0;
				point3D_0[i].Z = num * (double)i + double_2;
			}
			return;
		}
		double double_8 = 0.0;
		double double_9 = 0.0;
		double double_10 = 0.0;
		inv_vincenty_wgs84_2(double_0, double_1, double_3, double_4, ref double_8, ref double_9, ref double_10);
		double double_11 = double_10 / (double)int_0;
		point3D_0 = new Point3D[int_0 + 1];
		point3D_0[0].X = double_1;
		point3D_0[0].Y = double_0;
		point3D_0[0].Z = double_2;
		int num2 = int_0 - 1;
		double double_6 = 0.0;
		double double_7 = 0.0;
		for (int j = 1; j <= num2; j++)
		{
			fw_vincenty_wgs84(double_0, double_1, ref double_6, ref double_7, double_8, double_11);
			point3D_0[j].X = double_7;
			point3D_0[j].Y = double_6;
			point3D_0[j].Z = num * (double)j + double_2;
			inv_vincenty_wgs84_2(double_6, double_7, double_3, double_4, ref double_8, ref double_9, ref double_10);
			double_11 = double_10 / (double)(int_0 - j);
		}
		point3D_0[int_0].X = double_4;
		point3D_0[int_0].Y = double_3;
		point3D_0[int_0].Z = double_5;
	}

	internal static double ChangeInvocation(double double_0, double double_1, double double_2, double double_3)
	{
		double num = double_0 * 0.0174532925199433;
		double num2 = double_2 * 0.0174532925199433;
		double num3 = double_1 * 0.0174532925199433;
		double num4 = double_3 * 0.0174532925199433;
		return Math.Acos(Math.Cos(num) * Math.Cos(num2) * Math.Cos(num3 - num4) + Math.Sin(num) * Math.Sin(num2)) * 57.2957795130823;
	}

	internal static double InitInvocation(double double_0)
	{
		return 1.0 / Math.Sin(double_0);
	}

	internal static double CheckInvocation(double double_0)
	{
		return 1.0 / Math.Cos(double_0);
	}

	public static void CircleFromPoint(double double_0, double double_1, double double_2, int int_0, ref Point3D[] point3D_0)
	{
		if (int_0 < 3)
		{
			throw new Exception("点数量不足");
		}
		double double_3 = SetupInvocation(double_1);
		point3D_0 = new Point3D[int_0 - 1 + 1];
		double num = 0.0;
		double num2 = 360.0 / (double)int_0;
		int num3 = int_0 - 1;
		for (int i = 0; i <= num3; i++)
		{
			point3D_0[i].Z = 0.0;
			fw_vincenty_wgs84(double_0, double_3, ref point3D_0[i].Y, ref point3D_0[i].X, num, double_2);
			num += num2;
		}
	}

	public static void PartitionGreatCircle(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, int int_0, ref Point3D[] point3D_0)
	{
		if (int_0 == 0)
		{
			throw new Exception("zero numsegments");
		}
		if (double_0 == double_3 && double_1 == double_4 && double_2 == double_5)
		{
			point3D_0 = new Point3D[1];
			point3D_0[0].X = double_1;
			point3D_0[0].Y = double_0;
			point3D_0[0].Z = double_2;
			return;
		}
		double num = (double_5 - double_2) / (double)int_0;
		if (double_0 == double_3 && double_1 == double_4)
		{
			point3D_0 = new Point3D[int_0 + 1];
			point3D_0[0].X = double_1;
			point3D_0[0].Y = double_0;
			point3D_0[0].Z = double_2;
			for (int i = 1; i <= int_0; i++)
			{
				point3D_0[i].X = double_1;
				point3D_0[i].Y = double_0;
				point3D_0[i].Z = num * (double)i + double_2;
			}
			return;
		}
		double num10 = ChangeInvocation(double_0, double_1, double_3, double_4) * 0.0174532925199433;
		double num11 = double_1 * 0.0174532925199433;
		double num12 = double_4 * 0.0174532925199433;
		double num13 = double_0 * 0.0174532925199433;
		double num14 = double_3 * 0.0174532925199433;
		point3D_0 = new Point3D[int_0 + 1];
		point3D_0[0].X = double_1;
		point3D_0[0].Y = double_0;
		point3D_0[0].Z = double_2;
		if (num11 == num12)
		{
			double num15 = (num14 - num13) / (double)int_0;
			int num16 = int_0 - 1;
			for (int j = 1; j <= num16; j++)
			{
				point3D_0[j].X = double_1;
				point3D_0[j].Y = (num13 + num15 * (double)j) * 57.2957795130823;
				point3D_0[j].Z = num * (double)j + double_2;
			}
		}
		else
		{
			double num17 = Math.Sin(num10);
			double num2 = Math.Cos(num13);
			double num3 = Math.Cos(num14);
			int num4 = int_0 - 1;
			for (int k = 1; k <= num4; k++)
			{
				double num5 = (double)k / (double)int_0;
				double num6 = Math.Sin((1.0 - num5) * num10) / num17;
				double num7 = Math.Sin(num5 * num10) / num17;
				double num8 = num6 * num2 * Math.Cos(num11) + num7 * num3 * Math.Cos(num12);
				double num9 = num6 * num2 * Math.Sin(num11) + num7 * num3 * Math.Sin(num12);
				double y = Math.Atan2(num6 * Math.Sin(num13) + num7 * Math.Sin(num14), Math.Sqrt(num8 * num8 + num9 * num9)) * 57.2957795130823;
				double x = Math.Atan2(num9, num8) * 57.2957795130823;
				point3D_0[k].X = x;
				point3D_0[k].Y = y;
				point3D_0[k].Z = num * (double)k + double_2;
			}
		}
		point3D_0[int_0].X = double_4;
		point3D_0[int_0].Y = double_3;
		point3D_0[int_0].Z = double_5;
	}

	public static void PartitionGreatCircle(double double_0, double double_1, double double_2, double double_3, int int_0, ref double[] double_4, ref double[] double_5)
	{
		if (int_0 == 0)
		{
			throw new Exception("zero numsegments");
		}
		if (double_0 == double_2 && double_1 == double_3)
		{
			double_4 = new double[1];
			double_5 = new double[1];
			double_5[0] = double_1;
			double_4[0] = double_0;
			return;
		}
		double num = ChangeInvocation(double_0, double_1, double_2, double_3) * 0.0174532925199433;
		double num11 = double_1 * 0.0174532925199433;
		double num12 = double_3 * 0.0174532925199433;
		double num13 = double_0 * 0.0174532925199433;
		double num14 = double_2 * 0.0174532925199433;
		double_4 = new double[int_0 + 1];
		double_5 = new double[int_0 + 1];
		double_5[0] = double_1;
		double_4[0] = double_0;
		if (num11 == num12)
		{
			double num15 = (num14 - num13) / (double)int_0;
			int num16 = int_0 - 1;
			for (int i = 1; i <= num16; i++)
			{
				double_5[i] = double_1;
				double_4[i] = (num13 + num15 * (double)i) * 57.2957795130823;
			}
		}
		else
		{
			double num17 = Math.Sin(num);
			double num18 = Math.Cos(num13);
			double num2 = Math.Cos(num14);
			int num3 = int_0 - 1;
			for (int j = 1; j <= num3; j++)
			{
				double num4 = (double)j / (double)int_0;
				double num5 = Math.Sin((1.0 - num4) * num) / num17;
				double num6 = Math.Sin(num4 * num) / num17;
				double num7 = num5 * num18 * Math.Cos(num11) + num6 * num2 * Math.Cos(num12);
				double num8 = num5 * num18 * Math.Sin(num11) + num6 * num2 * Math.Sin(num12);
				double num9 = Math.Atan2(num5 * Math.Sin(num13) + num6 * Math.Sin(num14), Math.Sqrt(num7 * num7 + num8 * num8)) * 57.2957795130823;
				double num10 = Math.Atan2(num8, num7) * 57.2957795130823;
				double_5[j] = num10;
				double_4[j] = num9;
			}
		}
		double_5[int_0] = double_3;
		double_4[int_0] = double_2;
	}

	internal static double ConcatInvocation(double double_0, double double_1, double double_2)
	{
		double d = double_0 * 1852.0 / 6371000.0;
		double num = 6371000.0 + double_1;
		double num2 = 6371000.0 + double_2;
		return Math.Sqrt(num * num + num2 * num2 - 2.0 * num * num2 * Math.Cos(d)) / 1852.0;
	}

	public static void fw_geod_wgs84(ref TCoord tcoord_0, ref TCoord tcoord_1, double double_0, double double_1)
	{
		double num = 6378137.0;
		double num12 = 0.0033528106647474805;
		double num23 = 0.0008382026661868701;
		double num25 = 1852.0;
		double num26 = double_1 * num25;
		double a = tcoord_0.Lat * 0.0174532925199433;
		double num27 = tcoord_0.Lon * 0.0174532925199433;
		double double_2 = double_0 * 0.0174532925199433;
		double_2 = InvokeInvocation(double_2);
		bool flag = Math.Abs(double_2) > 1.5707963267949;
		double num28 = 1.0033528106647476;
		double num29 = Math.Atan(num28 * Math.Tan(a));
		double num30 = Math.Cos(num29);
		double num2 = Math.Sin(num29);
		double num3 = Math.Sin(double_2);
		bool flag2;
		double num4;
		double num5;
		if (Math.Abs(num3) < 1E-09)
		{
			flag2 = true;
			num3 = 0.0;
			num4 = ((Math.Abs(double_2) < 1.5707963267949) ? 1.0 : (-1.0));
			num5 = 0.0;
		}
		else
		{
			flag2 = false;
			num4 = Math.Cos(double_2);
			num5 = num30 * num3;
		}
		double num6 = num30 * num4;
		double num7;
		double num8;
		double num9;
		double num10;
		if (flag2)
		{
			num7 = 0.0;
			num8 = num23;
			num9 = 1.0 - num8;
			num9 *= num9;
			num10 = num8 / num9;
		}
		else
		{
			num7 = num12 * num5;
			num8 = num23 * (1.0 - num5 * num5);
			num9 = (1.0 - num8) * (1.0 - num8 - num7 * num5);
			num10 = (1.0 + 0.5 * num7 * num5) * num8 / num9;
		}
		double num11;
		if (flag2)
		{
			num11 = 1.5707963267949 - num29;
		}
		else
		{
			num11 = ((Math.Abs(num5) <= 1.0) ? Math.Acos(num5) : 0.0);
			num11 = ((Math.Sin(num11) == 0.0) ? 0.0 : (num2 / Math.Sin(num11)));
			num11 = ((Math.Abs(num11) <= 1.0) ? Math.Acos(num11) : 0.0);
		}
		double num13 = num26 / (num9 * num);
		if (flag)
		{
			num13 = 0.0 - num13;
		}
		double num14 = 2.0 * (num11 - num13);
		double num15 = Math.Cos(num14 + num13);
		double num16 = Math.Sin(num13);
		double num17 = num8 * num8 * num16 * Math.Cos(num13) * (2.0 * num15 * num15 - 1.0);
		double num18 = num13 + num17 - 2.0 * num10 * num15 * (1.0 - 2.0 * num10 * Math.Cos(num14)) * num16;
		double d = num11 + num11 - num18;
		double num19 = Math.Cos(num18);
		double num20 = Math.Sin(num18);
		if (flag)
		{
			num20 = 0.0 - num20;
		}
		double num21 = num6 * num19 - num2 * num20;
		double num22;
		double num24;
		if (flag2)
		{
			num22 = Math.Atan(Math.Tan(1.5707963267949 + num11 - num18) / num28);
			if (num21 <= 0.0)
			{
				num21 = 0.0;
				if (flag)
				{
					num22 = 0.0 - num22;
					num24 = 0.0;
				}
				else
				{
					num24 = 3.14159265358979;
				}
			}
			else
			{
				num21 = 3.14159265358979;
				if (flag)
				{
					num24 = 3.14159265358979;
				}
				else
				{
					num22 = 0.0 - num22;
					num24 = 0.0;
				}
			}
		}
		else
		{
			num21 = Math.Atan(num5 / num21);
			if (num21 > 0.0)
			{
				num21 += 3.14159265358979;
			}
			if (double_2 < 0.0)
			{
				num21 -= 3.14159265358979;
			}
			num21 = InvokeInvocation(num21);
			num22 = Math.Atan((0.0 - (num2 * num19 + num6 * num20)) * Math.Sin(num21) / (num28 * num5));
			num24 = Math.Atan2(num20 * num3, num30 * num19 - num2 * num20 * num4);
			num24 = (flag ? (num24 + num7 * ((1.0 - num8) * num18 + num8 * num20 * Math.Cos(d))) : (num24 - num7 * ((1.0 - num8) * num18 - num8 * num20 * Math.Cos(d))));
		}
		double double_3 = num27 + num24;
		double_3 = InvokeInvocation(double_3);
		tcoord_1.Lat = num22 * 57.2957795130823;
		tcoord_1.Lon = double_3 * 57.2957795130823;
	}

	public static void fw_vincenty_wgs84(ref TCoord tcoord_0, ref TCoord tcoord_1, double double_0, double double_1)
	{
		fw_vincenty_wgs84(tcoord_0.Lat, tcoord_0.Lon, ref tcoord_1.Lat, ref tcoord_1.Lon, double_0, double_1);
	}

	public static void fw_vincenty_wgs84(double double_0, double double_1, ref double double_2, ref double double_3, double double_4, double double_5)
	{
		if (double_5 == 0.0)
		{
			double_2 = double_0;
			double_3 = double_1;
			return;
		}
		double num = 6378137.0;
		double num12 = 0.0033528106647474805;
		double num22 = 6356752.314245179;
		double num23 = 1852.0;
		double num24 = double_5 * num23;
		double a = double_0 * 0.0174532925199433;
		double num25 = double_1 * 0.0174532925199433;
		double double_6 = double_4 * 0.0174532925199433;
		double_6 = InvokeInvocation(double_6);
		double num26 = Math.Atan(0.9966471893352525 * Math.Tan(a));
		double num27 = Math.Cos(num26);
		double num28 = Math.Sin(num26);
		double num2 = ((Math.Cos(double_6) == 0.0) ? 0.0 : Math.Atan2(Math.Tan(num26), Math.Cos(double_6)));
		double num3 = num27 * Math.Sin(double_6);
		double num4 = 1.0 - num3 * num3;
		double num5 = num4 * (num * num - num22 * num22) / (num22 * num22);
		double num6 = 1.0 + num5 / 16384.0 * (4096.0 + num5 * (-768.0 + num5 * (320.0 - 175.0 * num5)));
		double num7 = num5 / 1024.0 * (256.0 + num5 * (-128.0 + num5 * (74.0 - 47.0 * num5)));
		double num8 = num24 / (num22 * num6);
		double num9 = Math.Cos(num8);
		double num10 = Math.Sin(num8);
		int num11 = 1;
		double num13;
		do
		{
			num13 = Math.Cos(2.0 * num2 + num8);
			double num14 = num7 * num10 * (num13 + 0.25 * num7 * (num9 * (-1.0 + 2.0 * num13 * num13) - 0.166666666666666 * num7 * num13 * (-3.0 + 4.0 * num10 * num10) * (-3.0 + 4.0 * num13 * num13)));
			num8 = num24 / (num22 * num6) + num14;
			num9 = Math.Cos(num8);
			num10 = Math.Sin(num8);
			if (!(Math.Abs(num14) >= 1E-10))
			{
				break;
			}
			num11++;
		}
		while (num11 <= 5);
		double num15 = num28 * num10 - num27 * num9 * Math.Cos(double_6);
		double num16 = Math.Atan2(num28 * num9 + num27 * num10 * Math.Cos(double_6), (1.0 - num12) * Math.Sqrt(num3 * num3 + num15 * num15));
		double num17 = Math.Atan2(num10 * Math.Sin(double_6), num27 * num9 - num28 * num10 * Math.Cos(double_6));
		double num18 = num12 / 16.0 * (1.0 - num3 * num3) * (4.0 + num12 * (4.0 - 3.0 * num4));
		double num19 = num17 - (1.0 - num18) * num12 * num3 * (num8 + num18 * num10 * (num13 + num18 * num9 * (-1.0 + 2.0 * num13 * num13)));
		double num20 = num25 + num19;
		double_2 = num16 * 57.2957795130823;
		double_3 = num20 * 57.2957795130823;
		if (double_3 == 360.0)
		{
			double_3 = 0.0;
		}
		double num21 = Math.Atan2(num3, (0.0 - num28) * num10 + num27 * num9 * Math.Cos(double_6));
		if (num21 < 0.0)
		{
			num21 += 6.28318530717959;
		}
		if ((double_0 == 90.0 || double_0 == -90.0) && double_1 != -180.0 && double_1 != 180.0)
		{
			double_2 = 0.0 - double_2;
		}
	}

	public static void inv_vincenty_wgs84_2(double double_0, double double_1, double double_2, double double_3, ref double double_4, ref double double_5, ref double double_6)
	{
		TCoord tcoord_ = default(TCoord);
		tcoord_.Lat = double_0;
		tcoord_.Lon = double_1;
		TCoord tcoord_2 = default(TCoord);
		tcoord_2.Lat = double_2;
		tcoord_2.Lon = double_3;
		inv_vincenty_wgs84(tcoord_, tcoord_2, ref double_4, ref double_5, ref double_6);
	}

	internal static double InterruptInvocation(double double_0, double double_1)
	{
		if (Math.Abs(double_1) == 90.0)
		{
			return 0.0;
		}
		double num = double_0 * 0.0174532925199433;
		double num2 = double_1 * 0.0174532925199433;
		double num3 = 0.006694379990141316;
		double num4 = Math.Sin(num2);
		return 6378137.0 * Math.Cos(num2) / Math.Sqrt(1.0 - num3 * (num4 * num4)) * num;
	}

	public static void offsets_wgs84(double double_0, double double_1, double double_2, double double_3, ref double double_4, ref double double_5)
	{
		double double_6 = 0.0;
		double double_7 = 0.0;
		double double_8 = 0.0;
		inv_vincenty_wgs84_2(double_0, double_1, double_2, double_1, ref double_6, ref double_7, ref double_8);
		double_5 = double_8 * 1852.0;
		double_4 = InterruptInvocation(double_3 - double_1, double_0);
	}

	public static void inv_geod_wgs84_2(double double_0, double double_1, double double_2, double double_3, ref double double_4, ref double double_5, ref double double_6)
	{
		TCoord tcoord_ = default(TCoord);
		tcoord_.Lat = double_0;
		tcoord_.Lon = double_1;
		TCoord tcoord_2 = default(TCoord);
		tcoord_2.Lat = double_2;
		tcoord_2.Lon = double_3;
		inv_geod_wgs84(tcoord_, tcoord_2, ref double_4, ref double_5, ref double_6);
	}

	public static void inv_geod_wgs84(TCoord tcoord_0, TCoord tcoord_1, ref double double_0, ref double double_1, ref double double_2)
	{
		double num = 6378137.0;
		double num12 = 1852.0;
		double num23 = tcoord_0.Lat * 0.0174532925199433;
		double num29 = tcoord_1.Lat * 0.0174532925199433;
		double a = tcoord_0.Lon * 0.0174532925199433;
		double a2 = tcoord_1.Lon * 0.0174532925199433;
		double num30 = 0.0016764053323737402;
		double num31 = 0.0008382026661868701;
		double num32 = 1.756459274006944E-07;
		double num33 = Math.Atan(1.0033528106647476 * Math.Tan(a));
		double num34 = Math.Atan(1.0033528106647476 * Math.Tan(a2));
		double num2 = 0.5 * (num33 + num34);
		double num3 = 0.5 * (num34 - num33);
		double num4 = InvokeInvocation(num29 - num23);
		double a3 = 0.5 * num4;
		if ((Math.Abs(num4) < 1E-12) & (Math.Abs(num3) < 1E-12))
		{
			double_0 = 0.0;
			double_1 = 0.0;
			double_2 = 0.0;
			return;
		}
		double num5 = Math.Sin(a3);
		double num6 = Math.Cos(num2);
		double num7 = Math.Sin(num2);
		double num8 = Math.Cos(num3);
		double num9 = Math.Sin(num3);
		double num10 = num9 * num9 + (num8 * num8 - num7 * num7) * num5 * num5;
		double num11 = 1.0 - num10 - num10;
		double num13 = Math.Acos(num11);
		double num14 = num11 + num11;
		double num15 = Math.Sin(num13);
		double num16 = num7 * num8;
		num16 *= (num16 + num16) / (1.0 - num10);
		double num17 = num9 * num6;
		num17 *= (num17 + num17) / num10;
		double num18 = num16 + num17;
		num16 -= num17;
		num17 = num13 / num15;
		double num19 = 4.0 * num17 * num17;
		double num20 = num19 * num14;
		double num21 = num19 + num19;
		double num22 = num * num15 * (num17 - num31 * (num17 * num18 - num16) + num32 * (num18 * (num20 + (num17 - 0.5 * (num20 - num14)) * num18) - num16 * (num21 + num14 * num16) + num19 * num18 * num16));
		double num24 = Math.Tan(0.5 * (num4 - 0.25 * (num16 + num16 - num14 * (4.0 - num18)) * (num30 * num17 + num32 * (32.0 * num17 - (20.0 * num17 - num20) * num18 - (num21 + 4.0) * num16)) * Math.Tan(num4)));
		double num25 = Math.Atan2(num9, num24 * num6);
		double num26 = Math.Atan2(num8, num24 * num7);
		double num27 = InvokeInvocation(6.28318530717959 + num26 - num25);
		double num28 = InvokeInvocation(6.28318530717959 - num26 - num25);
		double_2 = num22 / num12;
		double_0 = num27 * 57.2957795130823;
		double_1 = num28 * 57.2957795130823;
	}

	public static void inv_vincenty_wgs84(TCoord tcoord_0, TCoord tcoord_1, ref double double_0, ref double double_1, ref double double_2)
	{
		inv_vincenty_wgs84(tcoord_0.Lat, tcoord_0.Lon, tcoord_1.Lat, tcoord_1.Lon, ref double_0, ref double_1, ref double_2);
	}

	public static void inv_vincenty_wgs84(double double_0, double double_1, double double_2, double double_3, ref double double_4, ref double double_5, ref double double_6)
	{
		double num = 6378137.0;
		double num12 = 0.0033528106647474805;
		double num23 = 6356752.314245179;
		double a = double_0 * 0.0174532925199433;
		double num29 = double_1 * 0.0174532925199433;
		double a2 = double_2 * 0.0174532925199433;
		double num30 = double_3 * 0.0174532925199433 - num29;
		double num5;
		double num6;
		double num31;
		double num4;
		if (Math.Abs(Math.Abs(double_0) - 90.0) < 1E-12)
		{
			if (Math.Abs(Math.Abs(double_2) - 90.0) < 1E-12)
			{
				if (Math.Abs(double_0 - double_2) < 2E-12)
				{
					double_4 = 0.0;
					double_5 = 180.0;
					double_6 = 0.0;
					return;
				}
				if (double_0 <= 0.0)
				{
					double_4 = 0.0;
					double_5 = 180.0;
				}
				else
				{
					double_4 = 180.0;
					double_5 = 0.0;
				}
				num31 = (num - num23) / (num + num23);
				double num32 = num31 * num31;
				double num33 = 1.0 + num32 / 4.0;
				double num34 = num32 * num32;
				num33 += num34 / 64.0;
				double num2 = num34 * num32;
				num33 += num2 / 256.0;
				double num3 = num34 * num34;
				num33 += num3 * 25.0 / 16384.0;
				num4 = 3.14159265358979 * (num + num23) * num33 / 2.0;
				double_6 = num4 / 1852.0;
				return;
			}
			num5 = Math.Atan((1.0 - num12) * Math.Tan(a2));
			num6 = 1.5707963267949 * (double)MathFunctions.Sign(double_0);
		}
		else
		{
			num5 = ((Math.Abs(Math.Abs(double_2) - 90.0) < 1E-12) ? (1.5707963267949 * (double)MathFunctions.Sign(double_2)) : Math.Atan((1.0 - num12) * Math.Tan(a2)));
			num6 = Math.Atan((1.0 - num12) * Math.Tan(a));
		}
		double num7 = Math.Cos(num6);
		double num8 = Math.Cos(num5);
		double num9 = Math.Sin(num6);
		double num10 = Math.Sin(num5);
		num31 = num30;
		int num11 = 1;
		double num13 = 0.0;
		double num16;
		double num17;
		double d2;
		double num19;
		double num20;
		do
		{
			double num14 = num8 * Math.Sin(num31);
			double num15 = num7 * num10 - num9 * num8 * Math.Cos(num31);
			double d = num14 * num14 + num15 * num15;
			num16 = num9 * num10 + num7 * num8 * Math.Cos(num31);
			num17 = Math.Sqrt(d);
			d2 = num17 / num16;
			double num18 = num7 * num8 * Math.Sin(num31) / num17;
			num19 = 1.0 - num18 * num18;
			num20 = ((!(Math.Abs(num19) < double.Epsilon)) ? (num16 - 2.0 * num9 * num10 / num19) : num16);
			double num21 = num12 / 16.0 * (1.0 - num18 * num18) * (4.0 + num12 * (4.0 - 3.0 * num19));
			double num22 = num30 + (1.0 - num21) * num12 * num18 * (num13 + num21 * num17 * (num20 + num21 * num16 * (-1.0 + 2.0 * num20 * num20)));
			if (Math.Abs(num22 - num31) < 1E-12)
			{
				break;
			}
			num31 = num22;
			num11++;
		}
		while (num11 <= 5);
		double num24 = num19 * (num * num - num23 * num23) / (num23 * num23);
		double num25 = 1.0 + num24 / 16384.0 * (4096.0 + num24 * (-768.0 + num24 * (320.0 - 175.0 * num24)));
		double num26 = num24 / 1024.0 * (256.0 + num24 * (-128.0 + num24 * (74.0 - 47.0 * num24)));
		num13 = Math.Atan(d2);
		double num27 = num26 * num17 * (num20 + 0.25 * num26 * (num16 * (-1.0 + 2.0 * num20 * num20) - 1.0 / 6.0 * num26 * num20 * (-3.0 + 4.0 * num17 * num17) * (-3.0 + 4.0 * num20 * num20)));
		num4 = num23 * num25 * (num13 - num27);
		if (num4 < 0.0)
		{
			num4 = 0.0 - num4;
		}
		double_6 = num4 / 1852.0;
		double double_7 = Math.Atan(num8 * Math.Sin(num31) / (num7 * num10 - num9 * num8 * Math.Cos(num31)));
		double_7 = InvokeInvocation(double_7);
		double num28 = Math.Atan(num7 * Math.Sin(num31) / ((0.0 - num9) * num8 + num7 * num10 * Math.Cos(num31)));
		num28 = InvokeInvocation(num28 - 3.14159265358979);
		double_4 = 57.2957795130823 * double_7;
		double_5 = 57.2957795130823 * num28;
		if (double_6 < 0.0 || double.IsNaN(double_6))
		{
			double_6 = RemoveInvocation(double_0, double_1, double_2, double_3);
		}
	}

	internal static double RemoveInvocation(double double_0, double double_1, double double_2, double double_3)
	{
		return Math.Acos(Math.Cos(double_0 * 0.0174532925199433) * Math.Cos(double_2 * 0.0174532925199433) * Math.Cos((double_1 - double_3) * 0.0174532925199433) + Math.Sin(double_0 * 0.0174532925199433) * Math.Sin(double_2 * 0.0174532925199433)) * 6371.0 * 1000.0 / 1852.0;
	}

	internal static double FindInvocation(double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		double num = double_4 * 1852.0 / 6371000.0;
		double num2 = double_2 - double_0;
		double num3 = double_3 - double_1;
		if (Math.Abs(num3) < double.Epsilon)
		{
			if (Math.Abs(num2) < double.Epsilon)
			{
				try
				{
					throw new Exception("this distance is beyond the boundaries of the line segment");
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200265", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
			}
			return num * 57.2957795130823 / num2;
		}
		if (Math.Abs(num2) < double.Epsilon)
		{
			return num * 57.2957795130823 / num3;
		}
		double num4 = num2 / num3;
		double num5 = double_0 * 0.0174532925199433;
		double num6 = Math.Cos(num5);
		double num7 = Math.Sin(num5);
		double double_5 = num3 * 0.0174532925199433;
		double num8 = Math.Cos(num);
		double[] double_6 = new double[5] { num8, num6, num5, num4, num7 };
		return CalculateInvocation(SetInvocation, 0.0, double_5, 1E-06, double_6) * 57.2957795130823 / num3;
	}

	private static double SetInvocation(double double_0, double[] double_1)
	{
		double num = double_1[0];
		double num2 = double_1[1] * Math.Cos(double_1[2] + double_1[3] * double_0) * Math.Cos(double_0) + double_1[4] * Math.Sin(double_1[2] + double_1[3] * double_0);
		double num3 = num - num2;
		return num3 * num3;
	}

	private static double FillInvocation(double double_0, double double_1)
	{
		if (double_1 <= 0.0)
		{
			return 0.0 - Math.Abs(double_0);
		}
		return Math.Abs(double_0);
	}

	private static double CalculateInvocation(StateParameterMock stateParameterMock_0, double double_0, double double_1, double double_2, double[] double_3)
	{
		int num = 0;
		double num12 = 0.381966;
		double num14 = 0.5 * (double_0 + double_1);
		double num15 = ((double_0 < double_1) ? double_0 : double_1);
		double num16 = ((double_0 <= double_1) ? double_1 : double_0);
		double num17 = num14;
		double num18 = num17;
		double num19 = num17;
		double num20 = 0.0;
		double num2 = stateParameterMock_0(num19, double_3);
		double num3 = num2;
		double num4 = num2;
		num = 1;
		double num5 = 0.0;
		do
		{
			double num6 = 0.5 * (num15 + num16);
			if (!(Math.Abs(num19 - num6) > double_2 * 2.0 - 0.5 * (num16 - num15)))
			{
				break;
			}
			double num11;
			if (Math.Abs(num20) <= double_2)
			{
				num20 = ((num19 < num6) ? (num16 - num19) : (num15 - num19));
				num5 = num12 * num20;
			}
			else
			{
				double num7 = (num19 - num18) * (num2 - num3);
				double num8 = (num19 - num17) * (num2 - num4);
				double num9 = (num19 - num17) * num8 - (num19 - num18) * num7;
				num8 = 2.0 * (num8 - num7);
				if (num8 > 0.0)
				{
					num9 = 0.0 - num9;
				}
				num8 = Math.Abs(num8);
				double num10 = num20;
				num20 = num5;
				if (Math.Abs(num9) < Math.Abs(0.5 * num8 * num10) && num9 > num8 * (num15 - num19) && num9 < num8 * (num16 - num19))
				{
					num5 = num9 / num8;
					num11 = num19 + num5;
					if (num11 - num15 < double_2 * 2.0 || num16 - num11 < double_2 * 2.0)
					{
						num5 = FillInvocation(double_2, num6 - num19);
					}
				}
				else
				{
					num20 = ((num19 < num6) ? (num16 - num19) : (num15 - num19));
					num5 = num12 * num20;
				}
			}
			num11 = ((Math.Abs(num5) < double_2) ? (num19 + FillInvocation(double_2, num5)) : (num19 + num5));
			double num13 = stateParameterMock_0(num11, double_3);
			if (num13 <= num2)
			{
				if (num11 < num19)
				{
					num16 = num19;
				}
				else
				{
					num15 = num19;
				}
				num17 = num18;
				num3 = num4;
				num18 = num19;
				num4 = num2;
				num19 = num11;
				num2 = num13;
			}
			else
			{
				if (num11 < num19)
				{
					num15 = num11;
				}
				else
				{
					num16 = num11;
				}
				if (!(num13 <= num4) && num18 != num19)
				{
					if (num13 <= num3 || num17 == num19 || num17 == 2.0)
					{
						num17 = num11;
						num3 = num13;
					}
				}
				else
				{
					num17 = num18;
					num3 = num4;
					num18 = num11;
					num4 = num13;
				}
			}
			num++;
		}
		while (num <= 100);
		return num19;
	}

	internal static double PopInvocation(double double_0, double double_1, double double_2, double double_3)
	{
		return Math.Acos(Math.Cos(double_0 * 0.0174532925199433) * Math.Cos(double_2 * 0.0174532925199433) * Math.Cos((double_1 - double_3) * 0.0174532925199433) + Math.Sin(double_0 * 0.0174532925199433) * Math.Sin(double_2 * 0.0174532925199433));
	}

	public static void fw_greatcircle(double double_0, double double_1, ref double double_2, ref double double_3, double double_4, double double_5)
	{
		double num = 6371000.0;
		double num12 = 1852.0;
		double num16 = double_5 * num12;
		double a = ((!(Math.Abs(Math.Abs(double_0) - 90.0) < 1E-09)) ? (double_0 * 0.0174532925199433) : ((double_0 <= 0.0) ? ((double_0 + 1E-09) * 0.0174532925199433) : ((double_0 - 1E-09) * 0.0174532925199433)));
		double num17 = double_1 * 0.0174532925199433;
		double double_6 = double_4 * 0.0174532925199433;
		double_6 = InvokeInvocation(double_6);
		bool flag = Math.Abs(double_6) > 1.5707963267949;
		double num18 = 1.0;
		double num19 = Math.Atan(num18 * Math.Tan(a));
		double num20 = Math.Cos(num19);
		double num21 = Math.Sin(num19);
		double num22 = Math.Sin(double_6);
		bool flag2;
		double num2;
		double num3;
		if (Math.Abs(num22) < 1E-09)
		{
			flag2 = true;
			num22 = 0.0;
			num2 = ((Math.Abs(double_6) < 1.5707963267949) ? 1.0 : (-1.0));
			num3 = 0.0;
		}
		else
		{
			flag2 = false;
			num2 = Math.Cos(double_6);
			num3 = num20 * num22;
		}
		double num4 = num20 * num2;
		double num5;
		double num6;
		if (flag2)
		{
			num5 = 0.0;
			num6 = 0.0;
		}
		else
		{
			num5 = 0.0;
			num6 = 0.0;
		}
		double num7;
		if (flag2)
		{
			num7 = 1.5707963267949 - num19;
		}
		else
		{
			num7 = ((Math.Abs(num3) <= 1.0) ? Math.Acos(num3) : 0.0);
			num7 = ((Math.Sin(num7) == 0.0) ? 0.0 : (num21 / Math.Sin(num7)));
			num7 = ((Math.Abs(num7) <= 1.0) ? Math.Acos(num7) : 0.0);
		}
		double num8 = num16 / num;
		if (flag)
		{
			num8 = 0.0 - num8;
		}
		Math.Cos(2.0 * (num7 - num8) + num8);
		Math.Sin(num8);
		double num9 = num8;
		double d = num7 + num7 - num9;
		double num10 = Math.Cos(num9);
		double num11 = Math.Sin(num9);
		if (flag)
		{
			num11 = 0.0 - num11;
		}
		double num13 = num4 * num10 - num21 * num11;
		double num14;
		double num15;
		if (flag2)
		{
			num14 = Math.Atan(Math.Tan(1.5707963267949 + num7 - num9) / num18);
			if (num13 <= 0.0)
			{
				num13 = 0.0;
				if (flag)
				{
					num14 = 0.0 - num14;
					num15 = 0.0;
				}
				else
				{
					num15 = 3.14159265358979;
				}
			}
			else
			{
				num13 = 3.14159265358979;
				if (flag)
				{
					num15 = 3.14159265358979;
				}
				else
				{
					num14 = 0.0 - num14;
					num15 = 0.0;
				}
			}
		}
		else
		{
			num13 = Math.Atan(num3 / num13);
			if (num13 > 0.0)
			{
				num13 += 3.14159265358979;
			}
			if (double_6 < 0.0)
			{
				num13 -= 3.14159265358979;
			}
			num13 = InvokeInvocation(num13);
			num14 = Math.Atan((0.0 - (num21 * num10 + num4 * num11)) * Math.Sin(num13) / (num18 * num3));
			num15 = Math.Atan2(num11 * num22, num20 * num10 - num21 * num11 * num2);
			num15 = (flag ? (num15 + num5 * ((1.0 - num6) * num9 + num6 * num11 * Math.Cos(d))) : (num15 - num5 * ((1.0 - num6) * num9 - num6 * num11 * Math.Cos(d))));
		}
		double double_7 = num17 + num15;
		double_7 = InvokeInvocation(double_7);
		double_2 = num14 * 57.2957795130823;
		double_3 = double_7 * 57.2957795130823;
	}

	public static void SolveSphericalTriangleSummit(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, ref double double_6, ref double double_7)
	{
		double num = double_4 * 1852.0 / 6371000.0;
		double num2 = PopInvocation(double_0, double_1, double_2, double_3);
		double num3 = double_5 * 0.0174532925199433;
		double double_9 = 0.0;
		double double_10 = 0.0;
		double double_8 = 0.0;
		inv_vincenty_wgs84_2(double_0, double_1, double_2, double_3, ref double_9, ref double_10, ref double_8);
		double num4 = Math.Abs(num3 - double_9 * 0.0174532925199433);
		double num5 = (num2 + num) / 2.0;
		Math.Sin(num5);
		Math.Sin(num5 - num2);
		Math.Cos(num4 / 2.0);
		Math.Sin(num4 / 2.0);
	}

	private static void Main_1()
	{
		LockRandom lockRandom = new LockRandom();
		int num = 1;
		double double_ = 0.0;
		double double_2 = 0.0;
		double double_3 = 0.0;
		double double_4 = 0.0;
		do
		{
			double num2 = lockRandom.NextDouble() * 180.0 - 90.0;
			double num3 = lockRandom.NextDouble() * 360.0 - 180.0;
			double num4 = -90.0;
			double num5 = num3 + lockRandom.NextDouble() * 18.0 - 9.0;
			TLocalTM tLocalTM = new TLocalTM(num2, num3);
			if (tLocalTM.CountInterruptibleQueue(num4, num5, ref double_, ref double_2, bool_0: false))
			{
				Console.WriteLine(Conversions.ToString(double_) + " " + Conversions.ToString(double_2));
				if (tLocalTM.CustomizeInterruptibleQueue(double_, double_2, ref double_3, ref double_4))
				{
					Console.WriteLine(Conversions.ToString(num2) + " " + Conversions.ToString(num3) + " " + Conversions.ToString(num4) + " " + Conversions.ToString(num5) + " " + Conversions.ToString(double_3) + " " + Conversions.ToString(double_4));
					num++;
					continue;
				}
				break;
			}
			break;
		}
		while (num <= 100000);
	}
}
