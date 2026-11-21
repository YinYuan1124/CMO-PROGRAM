using System;
using System.Drawing;
using CSMaterial;
using MathNet.Spatial.Euclidean;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class MathFunctions
{
	public struct Vector
	{
		public readonly double X;

		public readonly double Y;

		public readonly double Z;

		public double Mag => Math.Sqrt(X * X + Y * Y + Z * Z);

		public Vector(double double_0, double double_1, double double_2)
		{
			this = default(Vector);
			X = double_0;
			Y = double_1;
			Z = double_2;
		}

		public static Vector FromSpherical(double double_0, double double_1, double double_2)
		{
			double double_3 = double_0 * Math.Cos(double_2) * Math.Cos(double_1);
			double double_4 = double_0 * Math.Cos(double_2) * Math.Sin(double_1);
			double double_5 = double_0 * Math.Sin(double_2);
			return new Vector(double_3, double_4, double_5);
		}

		internal double ExcludeInterruptibleQueue(Vector vector_0)
		{
			return Dot(this, vector_0);
		}

		public static double Dot(Vector vector_0, Vector vector_1)
		{
			return vector_0.X * vector_1.X + vector_0.Y * vector_1.Y + vector_0.Z * vector_1.Z;
		}

		internal Vector IncludeInterruptibleQueue(Vector vector_0)
		{
			return Cross(this, vector_0);
		}

		public static Vector Cross(Vector vector_0, Vector vector_1)
		{
			return new Vector(vector_0.Y * vector_1.Z - vector_0.Z * vector_1.Y, vector_0.Z * vector_1.X - vector_0.X * vector_1.Z, vector_0.X * vector_1.Y - vector_0.Y * vector_1.X);
		}

		internal Vector SearchInterruptibleQueue()
		{
			double mag = Mag;
			return this * (1.0 / mag);
		}

		public static Vector operator +(Vector vector_0, Vector vector_1)
		{
			return new Vector(vector_0.X + vector_1.X, vector_0.Y + vector_1.Y, vector_0.Z + vector_1.Z);
		}

		public static Vector operator -(Vector vector_0, Vector vector_1)
		{
			return new Vector(vector_0.X - vector_1.X, vector_0.Y - vector_1.Y, vector_0.Z - vector_1.Z);
		}

		public static Vector operator -(Vector vector_0)
		{
			return new Vector(0.0 - vector_0.X, 0.0 - vector_0.Y, 0.0 - vector_0.Z);
		}

		public static Vector operator *(double double_0, Vector vector_0)
		{
			return new Vector(vector_0.X * double_0, vector_0.Y * double_0, vector_0.Z * double_0);
		}

		public static Vector operator *(Vector vector_0, double double_0)
		{
			return double_0 * vector_0;
		}
	}

	internal static double CountRequest(PointF pointF_0, PointF pointF_1, PointF pointF_2, ref PointF pointF_3)
	{
		float num = pointF_2.X - pointF_1.X;
		float num2 = pointF_2.Y - pointF_1.Y;
		if (num == 0f && num2 == 0f)
		{
			pointF_3 = pointF_1;
			num = pointF_0.X - pointF_1.X;
			num2 = pointF_0.Y - pointF_1.Y;
			return Math.Sqrt(num * num + num2 * num2);
		}
		float num3 = ((pointF_0.X - pointF_1.X) * num + (pointF_0.Y - pointF_1.Y) * num2) / (num * num + num2 * num2);
		if (num3 < 0f)
		{
			pointF_3 = new PointF(pointF_1.X, pointF_1.Y);
			num = pointF_0.X - pointF_1.X;
			num2 = pointF_0.Y - pointF_1.Y;
		}
		else if (num3 <= 1f)
		{
			pointF_3 = new PointF(pointF_1.X + num3 * num, pointF_1.Y + num3 * num2);
			num = pointF_0.X - pointF_3.X;
			num2 = pointF_0.Y - pointF_3.Y;
		}
		else
		{
			pointF_3 = new PointF(pointF_2.X, pointF_2.Y);
			num = pointF_0.X - pointF_2.X;
			num2 = pointF_0.Y - pointF_2.Y;
		}
		return Math.Sqrt(num * num + num2 * num2);
	}

	internal static Geopoint_Struct CustomizeRequest(GeoPoint geoPoint_0, GeoPoint geoPoint_1)
	{
		return CloneRequest(geoPoint_0.Latitude, geoPoint_0.Longitude, geoPoint_1.Latitude, geoPoint_1.Longitude);
	}

	internal static Geopoint_Struct CloneRequest(double double_0, double double_1, double double_2, double double_3)
	{
		float float_ = Math2.PublishClass(double_0, double_1, double_2, double_3);
		float num = Math2.VerifyClass(double_0, double_1, double_2, double_3);
		Geopoint_Struct result = default(Geopoint_Struct);
		Geodesic_EdWilliams.CalcPoint_Williams(double_0, double_1, ref result.Latitude, ref result.Longitude, num / 2f, float_);
		return result;
	}

	internal static Geopoint_Struct ConnectRequest(GeoPoint geoPoint_0, GeoPoint geoPoint_1, double double_0)
	{
		return MoveRequest(geoPoint_0.Latitude, geoPoint_0.Longitude, geoPoint_0.Altitude, geoPoint_1.Latitude, geoPoint_1.Longitude, geoPoint_1.Altitude, double_0);
	}

	internal static Geopoint_Struct MoveRequest(double double_0, double double_1, float float_0, double double_2, double double_3, float float_1, double double_4)
	{
		Geopoint_Struct result = default(Geopoint_Struct);
		GetIntermediate3DPoint(double_0, double_1, float_0, double_2, double_3, float_1, ref result.Latitude, ref result.Longitude, ref result.Altitude, double_4);
		return result;
	}

	public static void GetIntermediate3DPoint(double double_0, double double_1, float float_0, double double_2, double double_3, float float_1, ref double double_4, ref double double_5, ref float float_2, double double_6)
	{
		double num = Math2.VerifyClass(double_0, double_1, double_2, double_3);
		Geodesic_Vincenty.fw_vincenty_wgs84_2(double_0, double_1, ref double_4, ref double_5, Math2.PublishClass(double_0, double_1, double_2, double_3), num);
		float_2 = (float)((double)float_0 + double_6 * (double)(float_1 - float_0) / num);
	}

	internal static float DeleteRequest(float float_0, float float_1)
	{
		float_1 = Math2.UpdateClass(float_1 - float_0);
		float_0 = 0f;
		if (float_1 < 180f)
		{
			return float_1;
		}
		return 0f - (360f - float_1);
	}

	public static float SlantRange_NM_SR(float float_0, float float_1)
	{
		float num = float_1 / 1852f;
		return (float)Math.Sqrt(float_0 * float_0 + num * num);
	}

	internal static bool AddRequest(int int_0, int int_1)
	{
		int_1 = Math2.InsertClass(int_1 - int_0);
		int_0 = 0;
		if (int_1 != 90 && int_1 != 270)
		{
			return false;
		}
		return true;
	}

	public static double Arccos(double double_0)
	{
		if (double_0 == 1.0)
		{
			return 0.0;
		}
		return Math.Atan((0.0 - double_0) / Math.Sqrt((0.0 - double_0) * double_0 + 1.0)) + 2.0 * Math.Atan(1.0);
	}

	internal static double DestroyRequest(double double_0)
	{
		return double_0 * CSMath.PI_dividedBy_180;
	}

	internal static double ComputeRequest(double double_0)
	{
		return double_0 * 180.0 / 3.14159265358979;
	}

	internal static double PatchRequest(double double_0)
	{
		return 1852.0 * (double_0 * 10800.0 / 3.14159265358979);
	}

	internal static double SelectRequest(double double_0)
	{
		return double_0 * 60.0 * 180.0 / 3.14159265358979;
	}

	internal static double CallRequest(double double_0)
	{
		return double_0 * 3.14159265358979 / 10800.0;
	}

	internal static double LogoutRequest(double double_0, double double_1, double double_2, double double_3)
	{
		if (double_0 == double_2 && double_1 == double_3)
		{
			return 0.0;
		}
		double_0 = Math.Max(-90.0, Math.Min(90.0, double_0));
		double_2 = Math.Max(-90.0, Math.Min(90.0, double_2));
		double_1 = ((double_1 + 180.0) % 360.0 + 360.0) % 360.0 - 180.0;
		double_3 = ((double_3 + 180.0) % 360.0 + 360.0) % 360.0 - 180.0;
		if (double_1 == double_3)
		{
			if (double_0 < double_2)
			{
				return 0.0;
			}
			return 180.0;
		}
		double num = ViewRequest(double_0, 0.0 - double_1, double_2, 0.0 - double_3);
		double num2 = Math.Acos(Math.Min(1.0, (Math.Sin(DestroyRequest(double_2)) - Math.Sin(DestroyRequest(double_0)) * Math.Cos(DestroyRequest(num / 60.0))) / (Math.Sin(DestroyRequest(num / 60.0)) * Math.Cos(DestroyRequest(double_0))))) * 180.0 / Math.PI;
		if (Math.Sin(DestroyRequest(double_3 - double_1)) < 0.0)
		{
			return (360.0 - num2) % 360.0;
		}
		return num2;
	}

	internal static double ViewRequest(double double_0, double double_1, double double_2, double double_3)
	{
		if (double_0 == double_2 && double_1 == double_3)
		{
			return 0.0;
		}
		double num = DestroyRequest(double_0);
		double num2 = DestroyRequest(double_2);
		double d = DestroyRequest(double_3 - double_1);
		return 3437.746770784943 * Arccos(Math.Sin(num) * Math.Sin(num2) + Math.Cos(num) * Math.Cos(num2) * Math.Cos(d));
	}

	internal static double ValidateRequest(double double_0, double double_1, double double_2, double double_3)
	{
		if (double_2 == 0.0)
		{
			double_2 = 360.0;
		}
		double num = DestroyRequest(90.0 - double_0);
		DestroyRequest(double_1);
		double num2 = 3.14159265358979 * double_3 / 10800.0;
		double num3 = DestroyRequest(double_2);
		double num4 = 2.0 * Math.Atan(Math.Cos((num - num2) / 2.0) / (Math.Cos((num + num2) / 2.0) * Math.Tan(num3 / 2.0)));
		double num5 = 2.0 * Math.Atan(Math.Sin((num - num2) / 2.0) / (Math.Sin((num + num2) / 2.0) * Math.Tan(num3 / 2.0)));
		double num6 = (num4 - num5) / 2.0;
		double num7 = double_1 + num6 * 180.0 / 3.14159265358979;
		if (num7 <= 180.0)
		{
			if (num7 < -180.0)
			{
				num7 += 360.0;
			}
		}
		else
		{
			num7 -= 360.0;
		}
		return num7;
	}

	internal static double LoginRequest(double double_0)
	{
		double num = Math.Abs(double_0);
		return (double)Sign(double_0) * (Conversion.Int(num) + Conversion.Int((num - Conversion.Int(num)) * 100.0 + 1E-05) / 60.0 + 100.0 * (num * 100.0 - Conversion.Int(num * 100.0 + 1E-05)) / 3600.0);
	}

	internal static double GetRequest(double double_0)
	{
		double num = Math.Abs(double_0);
		double num2 = Conversion.Int(num);
		double num3 = num - num2;
		double num4 = Conversion.Int(num3 * 60.0);
		double num5 = Conversion.Int((num3 * 60.0 - num4) * 60.0 + 0.5);
		if (num5 == 60.0)
		{
			num4 += 1.0;
			num5 = 0.0;
		}
		return (double)Sign(double_0) * (num2 + num4 / 100.0 + num5 / 10000.0);
	}

	internal static string WriteRequest(double double_0)
	{
		string text = "";
		if (Strings.InStr(Conversions.ToString(double_0), ",") > 0)
		{
			text = ",";
		}
		if (Strings.InStr(Conversions.ToString(double_0), ".") > 0)
		{
			text = ".";
		}
		if (Operators.CompareString(text, "", TextCompare: false) != 0 && Strings.InStr(Conversions.ToString(double_0), text) != 0)
		{
			string text2 = Strings.Left(Conversions.ToString(double_0), Strings.InStr(Conversions.ToString(double_0), text) - 1);
			string text3 = Conversions.ToString(double_0).Substring(Strings.InStr(Conversions.ToString(double_0), text)) + "0000";
			string text4 = text3.Substring(0, 2);
			string text5 = text3.Substring(2, 2);
			return text2 + "°" + text4 + "'" + text5 + "\"";
		}
		return Conversions.ToString(double_0) + "°";
	}

	internal static double NewRequest(double double_0)
	{
		double num = Math.Abs(double_0);
		double num2 = Conversion.Int(num);
		double num3 = (num - num2) * 0.6;
		return (double)Sign(double_0) * (num2 + num3);
	}

	internal static double PushRequest(double double_0)
	{
		double num = Math.Abs(double_0);
		return (double)Sign(double_0) * (Conversion.Int(num) + Conversion.Int((num - Conversion.Int(num)) * 100.0) / 60.0 + 100.0 * (num * 100.0 - Conversion.Int(num * 100.0)) / 6000.0);
	}

	public static double ClosestDistance(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5)
	{
		double num = (double_3 - double_1) / (double_2 - double_0);
		double num2 = double_1 - double_0 * num;
		double num3 = double_5 + double_4 / num;
		double num4 = (num3 - num2) * num / (Math.Pow(num, 2.0) + 1.0);
		double num5 = num3 - num4 / num;
		if (double_1 == double_3)
		{
			if ((num4 - double_0) * (double)Sign(double_2 - double_0) < 0.0)
			{
				return Math.Pow(Math.Pow(double_5 - double_1, 2.0) + Math.Pow(double_4 - double_0, 2.0), 0.5);
			}
			if ((num4 - double_2) * (double)Sign(double_2 - double_0) <= 0.0)
			{
				return Math.Pow(Math.Pow(double_5 - num5, 2.0) + Math.Pow(double_4 - num4, 2.0), 0.5);
			}
			return Math.Pow(Math.Pow(double_5 - double_3, 2.0) + Math.Pow(double_4 - double_2, 2.0), 0.5);
		}
		if ((num5 - double_1) * (double)Sign(double_3 - double_1) < 0.0)
		{
			return Math.Pow(Math.Pow(double_5 - double_1, 2.0) + Math.Pow(double_4 - double_0, 2.0), 0.5);
		}
		if ((num5 - double_3) * (double)Sign(double_3 - double_1) <= 0.0)
		{
			return Math.Pow(Math.Pow(double_5 - num5, 2.0) + Math.Pow(double_4 - num4, 2.0), 0.5);
		}
		return Math.Pow(Math.Pow(double_5 - double_3, 2.0) + Math.Pow(double_4 - double_2, 2.0), 0.5);
	}

	public static int Sign(double double_0)
	{
		if (double_0 < 0.0)
		{
			return -1;
		}
		return 1;
	}

	public static float GetRelativeBearing(float float_0, float float_1)
	{
		float num = float_0;
		float result = Math2.UpdateClass(float_1 - num);
		num = 0f;
		return result;
	}

	public static Geopoint_Struct Intersection(Geopoint_Struct geopoint_Struct_0, double double_0, Geopoint_Struct geopoint_Struct_1, double double_1)
	{
		return Intersection(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, double_0, geopoint_Struct_1.Latitude, geopoint_Struct_1.Longitude, double_1);
	}

	public static Geopoint_Struct Intersection(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5)
	{
		double num = double_0 * 0.0174532925199433;
		double num11 = double_1 * 0.0174532925199433;
		double num12 = double_3 * 0.0174532925199433;
		double num13 = double_4 * 0.0174532925199433;
		double num14 = double_2 * 0.0174532925199433;
		double num15 = double_5 * 0.0174532925199433;
		double num16 = num12 - num;
		double num17 = num13 - num11;
		double num18 = 2.0 * Math.Asin(Math.Sqrt(Math.Sin(num16 / 2.0) * Math.Sin(num16 / 2.0) + Math.Cos(num) * Math.Cos(num12) * Math.Sin(num17 / 2.0) * Math.Sin(num17 / 2.0)));
		Geopoint_Struct result;
		if (num18 == 0.0)
		{
			result = default(Geopoint_Struct);
		}
		else
		{
			double num2 = Math.Acos((Math.Sin(num12) - Math.Sin(num) * Math.Cos(num18)) / (Math.Sin(num18) * Math.Cos(num)));
			if (double.IsNaN(num2))
			{
				num2 = 0.0;
			}
			double num3 = Math.Acos((Math.Sin(num) - Math.Sin(num12) * Math.Cos(num18)) / (Math.Sin(num18) * Math.Cos(num12)));
			double num4;
			double num5;
			if (Math.Sin(num13 - num11) <= 0.0)
			{
				num4 = Math.PI * 2.0 - num2;
				num5 = num3;
			}
			else
			{
				num4 = num2;
				num5 = Math.PI * 2.0 - num3;
			}
			double num6 = (num14 - num4 + Math.PI) % (Math.PI * 2.0) - Math.PI;
			double num7 = (num5 - num15 + Math.PI) % (Math.PI * 2.0) - Math.PI;
			if ((Math.Sin(num6) == 0.0) & (Math.Sin(num7) == 0.0))
			{
				result = default(Geopoint_Struct);
			}
			else
			{
				if (!(Math.Sin(num6) * Math.Sin(num7) < 0.0))
				{
					double d = Math.Acos((0.0 - Math.Cos(num6)) * Math.Cos(num7) + Math.Sin(num6) * Math.Sin(num7) * Math.Cos(num18));
					double num8 = Math.Atan2(Math.Sin(num18) * Math.Sin(num6) * Math.Sin(num7), Math.Cos(num7) + Math.Cos(num6) * Math.Cos(d));
					double num9 = Math.Asin(Math.Sin(num) * Math.Cos(num8) + Math.Cos(num) * Math.Sin(num8) * Math.Cos(num14));
					double num10 = Math.Atan2(Math.Sin(num14) * Math.Sin(num8) * Math.Cos(num), Math.Cos(num8) - Math.Sin(num) * Math.Sin(num9));
					return new Geopoint_Struct(((num11 + num10 + Math.PI) % (Math.PI * 2.0) - Math.PI) * 57.2957795130823, num9 * 57.2957795130823);
				}
				result = default(Geopoint_Struct);
			}
		}
		return result;
	}

	public static float ClosestDistance_Geographic(Geopoint_Struct geopoint_Struct_0, Geopoint_Struct geopoint_Struct_1, Geopoint_Struct geopoint_Struct_2)
	{
		double double_ = geopoint_Struct_2.Latitude * CSMath.PI_dividedBy_180;
		double double_2 = geopoint_Struct_2.Longitude * CSMath.PI_dividedBy_180;
		double double_3 = geopoint_Struct_0.Latitude * CSMath.PI_dividedBy_180;
		double double_4 = geopoint_Struct_0.Longitude * CSMath.PI_dividedBy_180;
		double double_5 = geopoint_Struct_1.Latitude * CSMath.PI_dividedBy_180;
		double double_6 = geopoint_Struct_1.Longitude * CSMath.PI_dividedBy_180;
		Vector vector = Vector.FromSpherical(1.0, double_2, double_);
		Vector vector2 = Vector.FromSpherical(1.0, double_4, double_3);
		Vector vector_ = Vector.FromSpherical(1.0, double_6, double_5);
		Vector vector_2 = vector2.IncludeInterruptibleQueue(vector_);
		Vector vector_3 = vector_2.IncludeInterruptibleQueue(vector.IncludeInterruptibleQueue(vector_2)).SearchInterruptibleQueue();
		double num = Math.Acos(vector.ExcludeInterruptibleQueue(vector_3));
		return (float)(3441.6865234375 * num);
	}

	public static bool NumberIsOdd(int int_0)
	{
		return int_0 % 2 != 0;
	}

	public static GeoPoint Vector_To_GeoPoint(Vector3D vector3D_0)
	{
		double double_ = 0.0;
		double double_2 = 0.0;
		double double_3 = 0.0;
		Geodesic_Vincenty.ApproxCartesianToSpherical(vector3D_0.X, vector3D_0.Y, vector3D_0.Z, ref double_, ref double_2, ref double_3);
		return new GeoPoint(double_2, double_, (float)double_3);
	}

	public static Geopoint_Struct Vector_To_Geopoint_Struct(Vector3D vector3D_0)
	{
		double double_ = 0.0;
		double double_2 = 0.0;
		double double_3 = 0.0;
		Geodesic_Vincenty.ApproxCartesianToSpherical(vector3D_0.X, vector3D_0.Y, vector3D_0.Z, ref double_, ref double_2, ref double_3);
		return new Geopoint_Struct(double_2, double_, (float)double_3);
	}

	public static Vector3D GeoPoint_To_UnitVector(GeoPoint geoPoint_0)
	{
		Geodesic_Vincenty.Point3D point3D = Geodesic_Vincenty.WriteInvocation(geoPoint_0.Latitude, geoPoint_0.Longitude, 1.0);
		return new Vector3D(point3D.X, point3D.Y, point3D.Z);
	}

	public static Vector3D Geopoint_Struct_To_UnitVector(Geopoint_Struct geopoint_Struct_0)
	{
		Geodesic_Vincenty.Point3D point3D = Geodesic_Vincenty.WriteInvocation(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, 1.0);
		return new Vector3D(point3D.X, point3D.Y, point3D.Z);
	}

	public static double Plus(double double_0, double double_1)
	{
		return double_0 + double_1;
	}

	public static double Times(double double_0, double double_1)
	{
		return double_0 * double_1;
	}

	public static double Times(double double_0, double double_1, double double_2)
	{
		return double_0 * double_1 * double_2;
	}

	public static double Times(double double_0, double double_1, double double_2, double double_3)
	{
		return double_0 * double_1 * double_2 * double_3;
	}
}
