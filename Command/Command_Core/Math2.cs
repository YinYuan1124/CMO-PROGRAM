using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CSMaterial.ClipperLib;
using DotSpatial.Topology;
using DotSpatial.Topology.Voronoi;
using ExWorldWind;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Simplifynet;
using ThreadSafeCollections;

namespace Command_Core;

[StandardModule]
public sealed class Math2
{
	public class GeopointComparer_SortyByLatitudeAscending : IComparer<GeoPoint>
	{
		internal int WriteInterruptibleQueue(GeoPoint geoPoint_0, GeoPoint geoPoint_1)
		{
			return geoPoint_0.Latitude.CompareTo(geoPoint_1.Latitude);
		}

		int IComparer<GeoPoint>.Compare(GeoPoint x, GeoPoint y)
		{
			return WriteInterruptibleQueue(x, y);
		}
	}

	public class GeopointComparer_SortyByLongitudeAscending : IComparer<GeoPoint>
	{
		internal int NewInterruptibleQueue(GeoPoint geoPoint_0, GeoPoint geoPoint_1)
		{
			return geoPoint_0.Longitude.CompareTo(geoPoint_1.Longitude);
		}

		int IComparer<GeoPoint>.Compare(GeoPoint x, GeoPoint y)
		{
			return NewInterruptibleQueue(x, y);
		}
	}

	[CompilerGenerated]
	private sealed class ProxyItem
	{
		public double CurrentLoc_Lon;

		public double CurrentLoc_Lat;

		internal float PushInterruptibleQueue(GeoPoint theGP)
		{
			return theGP.RangeToPoint_Horiz(CurrentLoc_Lon, CurrentLoc_Lat);
		}
	}

	[CompilerGenerated]
	private sealed class ReaderItem
	{
		public double CurrentLoc_Lon;

		public double CurrentLoc_Lat;

		internal float InvokeInterruptibleQueue(Geopoint_Struct theGP)
		{
			Geopoint_Struct geopoint_Struct = theGP;
			return geopoint_Struct.RangeToPoint_Horiz(CurrentLoc_Lon, CurrentLoc_Lat);
		}
	}

	[CompilerGenerated]
	private sealed class BaseConfigObject
	{
		public TList<List<Geopoint_Struct[]>> Local_theBag;

		internal void SetupInterruptibleQueue(List<Geopoint_Struct[]> theChunk)
		{
			Local_theBag.Add(FlushClass(theChunk));
		}
	}

	public const double MAX_DOUBLE = 1.79769313486231E+308;

	public const double Math_PI = Math.PI;

	internal static double RemoveClass(double double_0)
	{
		return Math.Tan(0.0174532925199433 * double_0);
	}

	internal static double FindClass(float float_0)
	{
		return Math.Tan(0.0174532925199433 * (double)float_0);
	}

	internal static double SetClass(double double_0)
	{
		return Math.Sin(0.0174532925199433 * double_0);
	}

	internal static double FillClass(float float_0)
	{
		return Math.Sin(0.0174532925199433 * (double)float_0);
	}

	internal static double CalculateClass(double double_0)
	{
		return Math.Cos(0.0174532925199433 * double_0);
	}

	internal static double PopClass(float float_0)
	{
		return Math.Cos(0.0174532925199433 * (double)float_0);
	}

	internal static double InstantiateClass(double double_0)
	{
		if (double_0 == 1.0)
		{
			return 0.0;
		}
		if (double_0 == -1.0)
		{
			return 180.0;
		}
		return 57.2957795130823 * Math.Atan2(0.0 - double_0, Math.Sqrt(1.0 - double_0 * double_0)) + 90.0;
	}

	internal static double CreateClass(double double_0)
	{
		if (double_0 == 1.0)
		{
			return 90.0;
		}
		if (double_0 == -1.0)
		{
			return 270.0;
		}
		return 57.2957795130823 * Math.Atan2(double_0, Math.Sqrt((0.0 - double_0) * double_0 + 1.0));
	}

	internal static double CompareClass(double double_0)
	{
		if (double_0 == 1.0)
		{
			return 45.0;
		}
		if (double_0 == -1.0)
		{
			return -45.0;
		}
		return 57.2957795130823 * Math.Atan(double_0);
	}

	internal static double ReadClass(double double_0, double double_1)
	{
		double_0 %= 360.0;
		double_1 %= 360.0;
		if (Math.Abs(double_0 - double_1) > 180.0)
		{
			double num = double_0;
			double_0 = double_1;
			double_1 = num;
			if (double_0 < double_1)
			{
				double_0 += 360.0;
			}
			else
			{
				double_1 += 360.0;
			}
		}
		return (double_0 + double_1) / 2.0 % 360.0;
	}

	internal static double DisableClass(double double_0)
	{
		double result = double_0;
		if (double_0 < 0.0)
		{
			result = double_0 + 360.0;
		}
		if (double_0 > 360.0)
		{
			result = double_0 - 360.0;
		}
		if (double_0 == 360.0)
		{
			result = 0.0;
		}
		return result;
	}

	internal static float UpdateClass(float float_0)
	{
		float result = float_0;
		if (float_0 < 0f)
		{
			result = float_0 + 360f;
		}
		if (float_0 > 360f)
		{
			result = float_0 - 360f;
		}
		if (float_0 == 360f)
		{
			result = 0f;
		}
		return result;
	}

	internal static int InsertClass(int int_0)
	{
		int result = int_0;
		if (int_0 < 0)
		{
			result = int_0 + 360;
		}
		if (int_0 > 360)
		{
			result = int_0 - 360;
		}
		if (int_0 == 360)
		{
			result = 0;
		}
		return result;
	}

	internal static float PrepareClass(float float_0)
	{
		if (float_0 <= 90f)
		{
			if (float_0 < -90f)
			{
				return -90f - float_0;
			}
			return float_0;
		}
		return 90f - float_0;
	}

	internal static double ReflectClass(double double_0)
	{
		if (double_0 <= 90.0)
		{
			if (double_0 < -90.0)
			{
				return -180.0 - double_0;
			}
			return double_0;
		}
		return 180.0 - double_0;
	}

	internal static double VisitClass(double double_0)
	{
		if (double_0 <= 180.0)
		{
			if (double_0 <= -180.0)
			{
				return double_0 + 360.0;
			}
			return double_0;
		}
		return double_0 - 360.0;
	}

	internal static float RestartClass(float float_0)
	{
		if (float_0 <= 180f)
		{
			if (float_0 <= -180f)
			{
				return float_0 + 360f;
			}
			return float_0;
		}
		return float_0 - 360f;
	}

	internal static double TestClass(double double_0)
	{
		return ExWorldWind.Angle.FromRadians(double_0 / 3441.6865234375).Degrees;
	}

	internal static double StopClass(double double_0)
	{
		return ExWorldWind.Angle.FromDegrees(double_0).Radians * 3441.6865234375;
	}

	internal static double CancelClass(double double_0, double double_1, double double_2, double double_3)
	{
		ExWorldWind.Angle angle_ = default(ExWorldWind.Angle);
		ExWorldWind.Angle angle_2 = default(ExWorldWind.Angle);
		ExWorldWind.Angle angle_3 = default(ExWorldWind.Angle);
		ExWorldWind.Angle angle_4 = default(ExWorldWind.Angle);
		angle_.Degrees = double_0;
		angle_2.Degrees = double_1;
		angle_3.Degrees = double_2;
		angle_4.Degrees = double_3;
		return World.ApproxAngularDistance(angle_, angle_2, angle_3, angle_4).Degrees;
	}

	internal static float VerifyClass(double double_0, double double_1, double double_2, double double_3)
	{
		float num = (float)Math.Abs(InstantiateClass(SetClass(double_0) * SetClass(double_2) + CalculateClass(double_0) * CalculateClass(double_2) * CalculateClass(double_3 - double_1)) * 60.0);
		if (float.IsNaN(num))
		{
			num = 0f;
		}
		if (num == 0f && double_0 != double_2 && double_1 != double_3)
		{
			num = (float)MercatorProjection.SlantRangeNM(new MercatorProjection.TCoord(double_0, double_1), new MercatorProjection.TCoord(double_2, double_3));
		}
		return num;
	}

	internal static float ListClass(double double_0, double double_1, double double_2, double double_3)
	{
		float num = (float)Math.Abs(InstantiateClass(SetClass(double_0) * SetClass(double_2) + CalculateClass(double_0) * CalculateClass(double_2) * CalculateClass(double_3 - double_1)) * 60.0);
		if (float.IsNaN(num))
		{
			num = 0f;
		}
		if (num == 0f && double_0 != double_2 && double_1 != double_3)
		{
			num = (float)Geodesic_Vincenty.IncludeInvocation(new Geodesic_Vincenty.TCoord(double_0, double_1), new Geodesic_Vincenty.TCoord(double_2, double_3), 0.0, 0.0);
		}
		return num;
	}

	internal static float ResolveClass(Module_Unit.Unit unit_0, GeoPoint geoPoint_0)
	{
		return VerifyClass(unit_0.GetLatitude(), unit_0.GetLongitude(), geoPoint_0.Latitude, geoPoint_0.Longitude);
	}

	internal static float PostClass(Module_Unit.Unit unit_0, Module_Unit.Unit unit_1)
	{
		return VerifyClass(unit_0.GetLatitude(), unit_0.GetLongitude(), unit_1.GetLatitude(), unit_1.GetLongitude());
	}

	internal static float RunClass(GeoPoint geoPoint_0, GeoPoint geoPoint_1)
	{
		return VerifyClass(geoPoint_0.Latitude, geoPoint_0.Longitude, geoPoint_1.Latitude, geoPoint_1.Longitude);
	}

	internal static float StartClass(ref Geopoint_Struct geopoint_Struct_0, ref Geopoint_Struct geopoint_Struct_1)
	{
		return VerifyClass(geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude, geopoint_Struct_1.Latitude, geopoint_Struct_1.Longitude);
	}

	internal static float AssetClass(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5)
	{
		double double_8 = 0.0;
		double double_9 = 0.0;
		double double_10 = 0.0;
		Geodesic_Vincenty.ApproxSphericalToCartesian(double_0, double_1, double_2, ref double_8, ref double_9, ref double_10);
		double double_11 = 0.0;
		double double_6 = 0.0;
		double double_7 = 0.0;
		Geodesic_Vincenty.ApproxSphericalToCartesian(double_3, double_4, double_5, ref double_11, ref double_6, ref double_7);
		double num = double_11 - double_8;
		double num2 = double_6 - double_9;
		double num3 = double_7 - double_10;
		return (float)(Math.Sqrt(num * num + num2 * num2 + num3 * num3) / 1852.0);
	}

	internal static double PrintClass(Module_Unit.Unit unit_0, Module_Unit.Unit unit_1)
	{
		return DefineClass(unit_0.GetLatitude(), unit_0.GetLongitude(), unit_0.GetCurrentAltitude(), unit_1.GetLatitude(), unit_1.GetLongitude(), unit_1.GetCurrentAltitude());
	}

	internal static double DefineClass(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5)
	{
		double double_8 = 0.0;
		double double_9 = 0.0;
		double double_10 = 0.0;
		Geodesic_Vincenty.ApproxSphericalToCartesian(double_0, double_1, double_2, ref double_8, ref double_9, ref double_10);
		double double_11 = 0.0;
		double double_6 = 0.0;
		double double_7 = 0.0;
		Geodesic_Vincenty.ApproxSphericalToCartesian(double_3, double_4, double_5, ref double_11, ref double_6, ref double_7);
		double num = double_11 - double_8;
		double num2 = double_6 - double_9;
		double num3 = double_7 - double_10;
		return Math.Sqrt(num * num + num2 * num2 + num3 * num3) / 1852.0;
	}

	internal static float PublishClass(double double_0, double double_1, double double_2, double double_3)
	{
		return (float)DisableClass(57.2957795130823 * Math.Atan2(SetClass(double_3 - double_1), RemoveClass(double_2) * CalculateClass(double_0) - SetClass(double_0) * CalculateClass(double_3 - double_1)));
	}

	public static void CalcPoint_Vincenty(double double_0, double double_1, ref double double_2, ref double double_3, double double_4, double double_5)
	{
		Geodesic_Vincenty.fw_vincenty_wgs84_2(double_1, double_0, ref double_3, ref double_2, double_5, double_4);
	}

	internal static bool AwakeClass(double double_0)
	{
		if (double_0 < -180.0)
		{
			return false;
		}
		return double_0 <= 180.0;
	}

	internal static bool QueryClass(double double_0)
	{
		if (double_0 < -90.0)
		{
			return false;
		}
		return double_0 <= 90.0;
	}

	public static GeoPoint RandomCornerWithinThisArea(IEnumerable<GeoPoint> ienumerable_0, double double_0, double double_1, bool bool_0)
	{
		int num = ienumerable_0.Count();
		if (bool_0)
		{
			IEnumerable<GeoPoint> source = from theGP in ienumerable_0
				select (theGP) into theGP
				orderby theGP.RangeToPoint_Horiz(double_1, double_0)
				select theGP;
			if (GameGeneral.LockRandom_0.Next(0, 1001) <= 250)
			{
				int num2 = (int)Math.Ceiling((double)ienumerable_0.Count() / 2.0);
				return source.Take(num2).ElementAtOrDefault(GameGeneral.LockRandom_0.Next(0, num2));
			}
			int num3 = (int)Math.Ceiling((double)ienumerable_0.Count() / 2.0);
			return source.Skip(num - num3).ElementAtOrDefault(GameGeneral.LockRandom_0.Next(0, num3));
		}
		return ienumerable_0.ElementAtOrDefault(GameGeneral.LockRandom_0.Next(0, num));
	}

	public static Geopoint_Struct RandomCornerWithinThisArea(List<Geopoint_Struct> list_0, double double_0, double double_1, bool bool_0)
	{
		int count = list_0.Count;
		if (bool_0)
		{
			IEnumerable<Geopoint_Struct> source = list_0.Select((Geopoint_Struct theGP) => theGP).OrderBy(delegate(Geopoint_Struct theGP)
			{
				Geopoint_Struct geopoint_Struct = theGP;
				return geopoint_Struct.RangeToPoint_Horiz(double_1, double_0);
			});
			if (GameGeneral.LockRandom_0.Next(0, 1001) <= 250)
			{
				int num = (int)Math.Ceiling((double)list_0.Count / 2.0);
				return source.Take(num).ElementAtOrDefault(GameGeneral.LockRandom_0.Next(0, num));
			}
			int num2 = (int)Math.Ceiling((double)list_0.Count / 2.0);
			return source.Skip(count - num2).ElementAtOrDefault(GameGeneral.LockRandom_0.Next(0, num2));
		}
		return list_0[GameGeneral.LockRandom_0.Next(0, count)];
	}

	public static List<Geopoint_Struct> SimplifyArea(List<Geopoint_Struct> list_0)
	{
		Geopoint_Struct geopoint_Struct = Misc.Center(list_0);
		new Geodesic_Vincenty.TLocalTM(geopoint_Struct.Latitude, geopoint_Struct.Longitude);
		int count = list_0.Count;
		Simplifynet.Point[] array = new Simplifynet.Point[count + 1];
		bool flag = false;
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			try
			{
				MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(list_0[i].Longitude, list_0[i].Latitude);
				array[i] = new Simplifynet.Point(mercatorPixel.x, mercatorPixel.y);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200088", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				flag = true;
				ProjectData.ClearProjectError();
			}
		}
		if (array.Length == 0)
		{
			return new List<Geopoint_Struct>();
		}
		if (flag)
		{
			array = array.Where((Simplifynet.Point p) => p != null).ToArray();
			array = (Simplifynet.Point[])Microsoft.VisualBasic.CompilerServices.Utils.CopyArray(array, new Simplifynet.Point[array.Count() + 1]);
		}
		array[array.Count() - 1] = array[0];
		List<Simplifynet.Point> list = SimplifyGeometry(array);
		int count2 = list.Count;
		List<Geopoint_Struct> list2 = new List<Geopoint_Struct>(count2);
		int num2 = count2 - 1;
		for (int j = 0; j <= num2; j++)
		{
			MercatorProjection.TCoord tcoord_ = MercatorProjection.toGeoCoord(list[j].X, list[j].Y);
			if (MercatorProjection.CheckGeoCoordinate(ref tcoord_))
			{
				list2.Add(new Geopoint_Struct(tcoord_.Lon, tcoord_.Lat));
			}
		}
		return list2;
	}

	public static List<GeoPoint> SimplifyArea(List<GeoPoint> list_0)
	{
		Geopoint_Struct geopoint_Struct = Misc.Center(list_0);
		new Geodesic_Vincenty.TLocalTM(geopoint_Struct.Latitude, geopoint_Struct.Longitude);
		int count = list_0.Count;
		Simplifynet.Point[] array = new Simplifynet.Point[count + 1];
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			try
			{
				MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(list_0[i].Longitude, list_0[i].Latitude);
				array[i] = new Simplifynet.Point(mercatorPixel.x, mercatorPixel.y);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200088", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		if (array.Length == 0)
		{
			return new List<GeoPoint>();
		}
		array[array.Count() - 1] = array[0];
		List<Simplifynet.Point> list = SimplifyGeometry(array);
		int count2 = list.Count;
		List<GeoPoint> list2 = new List<GeoPoint>(count2);
		int num2 = count2 - 1;
		for (int j = 0; j <= num2; j++)
		{
			MercatorProjection.TCoord tcoord_ = MercatorProjection.toGeoCoord(list[j].X, list[j].Y);
			if (MercatorProjection.CheckGeoCoordinate(ref tcoord_))
			{
				list2.Add(new GeoPoint(tcoord_.Lon, tcoord_.Lat));
			}
		}
		return list2;
	}

	public static List<ReferencePoint> SimplifyArea(List<ReferencePoint> list_0)
	{
		Misc.Center(list_0);
		int count = list_0.Count;
		Simplifynet.Point[] array = new Simplifynet.Point[count + 1];
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			try
			{
				MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(list_0[i].Longitude, list_0[i].Latitude);
				array[i] = new Simplifynet.Point(mercatorPixel.x, mercatorPixel.y);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200088", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		if (array.Length == 0)
		{
			return new List<ReferencePoint>();
		}
		array[array.Count() - 1] = array[0];
		List<Simplifynet.Point> list = SimplifyGeometry(array);
		int count2 = list.Count;
		List<ReferencePoint> list2 = new List<ReferencePoint>(count2);
		int num2 = count2 - 1;
		for (int j = 0; j <= num2; j++)
		{
			MercatorProjection.TCoord tcoord_ = MercatorProjection.toGeoCoord(list[j].X, list[j].Y);
			if (MercatorProjection.CheckGeoCoordinate(ref tcoord_))
			{
				list2.Add(new ReferencePoint(tcoord_.Lon, tcoord_.Lat));
			}
		}
		return list2;
	}

	public static List<Simplifynet.Point> SimplifyGeometry(Simplifynet.Point[] point_0)
	{
		return SimplifyUtility.SimplifyArray(point_0, 50.0);
	}

	public static Geopoint_Struct RandomPointWithinThisArea(List<ReferencePoint> list_0)
	{
		if (list_0.Count < 3)
		{
			return default(Geopoint_Struct);
		}
		LockRandom lockRandom = GameGeneral.LockRandom_0;
		if (lockRandom == null)
		{
			lockRandom = new LockRandom();
		}
		try
		{
			List<ReferencePoint> list = Misc.EnableRequest(list_0);
			list.Sort(new GeopointComparer_SortyByLatitudeAscending());
			double latitude = list[list.Count - 1].Latitude;
			double latitude2 = list[0].Latitude;
			list.Sort(new GeopointComparer_SortyByLongitudeAscending());
			bool flag = false;
			double num = 0.0;
			double num2 = 0.0;
			if (PolygonCrossesAntimeridian(ref list_0))
			{
				double longitude = list[0].Longitude;
				double longitude2 = list[list.Count - 1].Longitude;
				double num3 = 180.0 - Math.Abs(longitude2) + (180.0 - Math.Abs(longitude));
				short num4 = 0;
				while (!flag)
				{
					if (num4 != short.MaxValue)
					{
						num4++;
						double num5 = GameGeneral.LockRandom_0.NextDouble();
						double num6 = GameGeneral.LockRandom_0.NextDouble();
						if (num5 != 0.0 && num6 != 0.0)
						{
							num = VisitClass(longitude2 + num5 * num3);
							num2 = latitude2 + num6 * (latitude - latitude2);
							flag = GeoPoint.IsInsideThisArea(num2, num, list_0);
							continue;
						}
						return default(Geopoint_Struct);
					}
					return default(Geopoint_Struct);
				}
			}
			else
			{
				double longitude3 = list[list.Count - 1].Longitude;
				double longitude4 = list[0].Longitude;
				short num7 = 0;
				while (!flag)
				{
					if (num7 != short.MaxValue)
					{
						num7++;
						double num8 = lockRandom.NextDouble();
						double num9 = lockRandom.NextDouble();
						if (num8 != 0.0 && num9 != 0.0)
						{
							num = longitude4 + num8 * (longitude3 - longitude4);
							num2 = latitude2 + num9 * (latitude - latitude2);
							flag = GeoPoint.IsInsideThisArea(num2, num, list_0);
							continue;
						}
						return default(Geopoint_Struct);
					}
					return default(Geopoint_Struct);
				}
			}
			return new Geopoint_Struct(num, num2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 2193857394687489", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Geopoint_Struct result = RandomPointWithinThisArea(list_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static Geopoint_Struct FindClosestPoint(double double_0, double double_1, List<ReferencePoint> list_0)
	{
		double num = double.MaxValue;
		Geopoint_Struct result = default(Geopoint_Struct);
		double num7 = 0.01;
		double num8 = list_0.Min((ReferencePoint wp) => wp.Latitude);
		double num9 = list_0.Min((ReferencePoint wp) => wp.Longitude);
		double num10 = list_0.Max((ReferencePoint wp) => wp.Latitude);
		double num11 = list_0.Max((ReferencePoint wp) => wp.Longitude);
		num7 = Math.Min(Math.Abs(num10 - num8), Math.Abs(num11 - num9));
		num7 /= 10.0;
		double num12 = num8;
		double num13 = num10;
		double num14 = num7;
		bool flag = num14 >= 0.0;
		for (double num2 = num12; (!flag) ? (num2 >= num13) : (num2 <= num13); num2 += num14)
		{
			double num3 = num11;
			double num4 = num7;
			bool flag2 = num4 >= 0.0;
			for (double num5 = num9; (!flag2) ? (num5 >= num3) : (num5 <= num3); num5 += num4)
			{
				if (GeoPoint.IsInsideThisArea(num2, num5, list_0))
				{
					double num6 = VerifyClass(num2, num5, double_0, double_1);
					if (num6 < num)
					{
						num = num6;
						result = new Geopoint_Struct(num5, num2);
					}
				}
			}
		}
		return result;
	}

	public static Geopoint_Struct RandomPointWithinThisArea(List<GeoPoint> list_0)
	{
		if (list_0.Count < 3)
		{
			return default(Geopoint_Struct);
		}
		LockRandom lockRandom = GameGeneral.LockRandom_0;
		if (lockRandom == null)
		{
			lockRandom = new LockRandom();
		}
		try
		{
			List<GeoPoint> list = Misc.EnableRequest(list_0);
			list.Sort(new GeopointComparer_SortyByLatitudeAscending());
			double latitude = list[list.Count - 1].Latitude;
			double latitude2 = list[0].Latitude;
			list.Sort(new GeopointComparer_SortyByLongitudeAscending());
			bool flag = false;
			double num = 0.0;
			double num2 = 0.0;
			if (PolygonCrossesAntimeridian(list_0))
			{
				double longitude = list[0].Longitude;
				double longitude2 = list[list.Count - 1].Longitude;
				double num3 = 180.0 - Math.Abs(longitude2) + (180.0 - Math.Abs(longitude));
				short num4 = 0;
				while (!flag)
				{
					if (num4 != short.MaxValue)
					{
						num4++;
						double num5 = GameGeneral.LockRandom_0.NextDouble();
						double num6 = GameGeneral.LockRandom_0.NextDouble();
						if (num5 != 0.0 && num6 != 0.0)
						{
							num = VisitClass(longitude2 + num5 * num3);
							num2 = latitude2 + num6 * (latitude - latitude2);
							flag = GeoPoint.IsInsideThisArea(num2, num, list_0);
							continue;
						}
						return default(Geopoint_Struct);
					}
					return default(Geopoint_Struct);
				}
			}
			else
			{
				double longitude3 = list[list.Count - 1].Longitude;
				double longitude4 = list[0].Longitude;
				short num7 = 0;
				while (!flag)
				{
					if (num7 != short.MaxValue)
					{
						num7++;
						double num8 = lockRandom.NextDouble();
						double num9 = lockRandom.NextDouble();
						if (num8 != 0.0 && num9 != 0.0)
						{
							num = longitude4 + num8 * (longitude3 - longitude4);
							num2 = latitude2 + num9 * (latitude - latitude2);
							flag = GeoPoint.IsInsideThisArea(num2, num, list_0);
							continue;
						}
						return default(Geopoint_Struct);
					}
					return default(Geopoint_Struct);
				}
			}
			return new Geopoint_Struct(num, num2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 3429856782", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Geopoint_Struct result = RandomPointWithinThisArea(list_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static bool AreaContainsPole(IEnumerable<GeoPoint> ienumerable_0)
	{
		if (PolygonCrossesAntimeridian(ienumerable_0.ToList()))
		{
			List<GeoPoint> list = new List<GeoPoint>();
			foreach (GeoPoint item in ienumerable_0)
			{
				list.Add(new GeoPoint(VisitClass(item.Longitude + 180.0), item.Latitude));
			}
			return PolygonCrossesAntimeridian(list);
		}
		return false;
	}

	public static bool LineIntersectsArea_DotSpatial(double double_0, double double_1, double double_2, double double_3, IEnumerable<GeoPoint> ienumerable_0, bool bool_0 = true)
	{
		if (bool_0 && PolygonCrossesAntimeridian(ienumerable_0.ToList()))
		{
			double double_4 = VisitClass(double_1 + 180.0);
			double double_5 = VisitClass(double_3 + 180.0);
			List<GeoPoint> list = new List<GeoPoint>();
			foreach (GeoPoint item in ienumerable_0)
			{
				list.Add(new GeoPoint(VisitClass(item.Longitude + 180.0), item.Latitude));
			}
			return LineIntersectsArea_DotSpatial(double_0, double_4, double_2, double_5, list, bool_0: false);
		}
		LineString igeometry_ = new LineString(new Coordinate[2]
		{
			new Coordinate(double_1, double_0),
			new Coordinate(double_3, double_2)
		});
		int num = ienumerable_0.Count();
		Coordinate[] array = new Coordinate[num - 1 + 1];
		int num2 = num - 1;
		for (int i = 0; i <= num2; i++)
		{
			GeoPoint geoPoint = ienumerable_0.ElementAtOrDefault(i);
			array[i] = new Coordinate(geoPoint.Longitude, geoPoint.Latitude);
		}
		return new Polygon(new LinearRing(array)).Intersects(igeometry_);
	}

	public static Geopoint_Struct[] GetRectangularArea(double double_0, double double_1, float float_0, float float_1, float float_2)
	{
		Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
		Geopoint_Struct geopoint_Struct2 = default(Geopoint_Struct);
		Geopoint_Struct geopoint_Struct3 = default(Geopoint_Struct);
		Geopoint_Struct geopoint_Struct4 = default(Geopoint_Struct);
		Geopoint_Struct geopoint_Struct5 = default(Geopoint_Struct);
		Geopoint_Struct geopoint_Struct6 = default(Geopoint_Struct);
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref geopoint_Struct6.Longitude, ref geopoint_Struct6.Latitude, (float)((double)(float_0 / 2f) * 0.000539957), UpdateClass(float_2 + 180f));
		ref double longitude = ref geopoint_Struct6.Longitude;
		ref double latitude = ref geopoint_Struct6.Latitude;
		ref double longitude3 = ref geopoint_Struct3.Longitude;
		ref double latitude3 = ref geopoint_Struct3.Latitude;
		double double_2 = (double)float_0 * 0.000539957;
		Geodesic_EdWilliams.CalcPoint_Williams(ref longitude, ref latitude, ref longitude3, ref latitude3, ref double_2, ref float_2);
		ref double longitude4 = ref geopoint_Struct3.Longitude;
		ref double latitude4 = ref geopoint_Struct3.Latitude;
		ref double longitude5 = ref geopoint_Struct.Longitude;
		ref double latitude5 = ref geopoint_Struct.Latitude;
		double_2 = (double)(float_1 / 2f) * 0.000539957;
		float float_3 = UpdateClass(float_2 - 90f);
		Geodesic_EdWilliams.CalcPoint_Williams(ref longitude4, ref latitude4, ref longitude5, ref latitude5, ref double_2, ref float_3);
		ref double longitude6 = ref geopoint_Struct3.Longitude;
		ref double latitude6 = ref geopoint_Struct3.Latitude;
		ref double longitude7 = ref geopoint_Struct2.Longitude;
		ref double latitude7 = ref geopoint_Struct2.Latitude;
		double_2 = (double)(float_1 / 2f) * 0.000539957;
		float_3 = UpdateClass(float_2 + 90f);
		Geodesic_EdWilliams.CalcPoint_Williams(ref longitude6, ref latitude6, ref longitude7, ref latitude7, ref double_2, ref float_3);
		ref double longitude8 = ref geopoint_Struct6.Longitude;
		ref double latitude8 = ref geopoint_Struct6.Latitude;
		ref double longitude9 = ref geopoint_Struct4.Longitude;
		ref double latitude9 = ref geopoint_Struct4.Latitude;
		double_2 = (double)(float_1 / 2f) * 0.000539957;
		float_3 = UpdateClass(float_2 - 90f);
		Geodesic_EdWilliams.CalcPoint_Williams(ref longitude8, ref latitude8, ref longitude9, ref latitude9, ref double_2, ref float_3);
		ref double longitude10 = ref geopoint_Struct6.Longitude;
		ref double latitude10 = ref geopoint_Struct6.Latitude;
		ref double longitude2 = ref geopoint_Struct5.Longitude;
		ref double latitude2 = ref geopoint_Struct5.Latitude;
		double_2 = (double)(float_1 / 2f) * 0.000539957;
		float_3 = UpdateClass(float_2 + 90f);
		Geodesic_EdWilliams.CalcPoint_Williams(ref longitude10, ref latitude10, ref longitude2, ref latitude2, ref double_2, ref float_3);
		return new Geopoint_Struct[4] { geopoint_Struct, geopoint_Struct2, geopoint_Struct5, geopoint_Struct4 };
	}

	public static bool LineIntersectsArea_Clipper(double double_0, double double_1, double double_2, double double_3, IEnumerable<GeoPoint> ienumerable_0, bool bool_0 = true)
	{
		if (bool_0 && PolygonCrossesAntimeridian(ienumerable_0.ToList()))
		{
			double double_4 = VisitClass(double_1 + 180.0);
			double double_5 = VisitClass(double_3 + 180.0);
			List<GeoPoint> list = new List<GeoPoint>();
			foreach (GeoPoint item in ienumerable_0)
			{
				list.Add(new GeoPoint(VisitClass(item.Longitude + 180.0), item.Latitude));
			}
			return LineIntersectsArea_Clipper(double_0, double_4, double_2, double_5, list, bool_0: false);
		}
		List<IntPoint> list2 = new List<IntPoint>();
		foreach (GeoPoint item2 in ienumerable_0)
		{
			list2.Add(new IntPoint(new IntPoint(item2.Longitude * 100000000000000.0, item2.Latitude * 100000000000000.0)));
		}
		List<IntPoint> list3 = new List<IntPoint>();
		list3.Add(new IntPoint(double_1 * 100000000000000.0, double_0 * 100000000000000.0));
		list3.Add(new IntPoint(double_3 * 100000000000000.0, double_2 * 100000000000000.0));
		Clipper clipper = new Clipper();
		clipper.AddPath(list2, PolyType.ptSubject, bool_0: true);
		clipper.AddPath(list3, PolyType.ptClip, bool_0: true);
		List<List<IntPoint>> list4 = new List<List<IntPoint>>();
		clipper.Execute(ClipType.ctIntersection, list4, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd);
		return list4.Count > 0;
	}

	public static bool LineIntersectsArea_Clipper(double double_0, double double_1, double double_2, double double_3, List<Geopoint_Struct> list_0, bool bool_0 = true)
	{
		if (bool_0 && PolygonCrossesAntimeridian(list_0.ToList()))
		{
			double double_4 = VisitClass(double_1 + 180.0);
			double double_5 = VisitClass(double_3 + 180.0);
			List<Geopoint_Struct> list = new List<Geopoint_Struct>(list_0.Count);
			foreach (Geopoint_Struct item in list_0)
			{
				list.Add(new Geopoint_Struct(VisitClass(item.Longitude + 180.0), item.Latitude));
			}
			return LineIntersectsArea_Clipper(double_0, double_4, double_2, double_5, list, bool_0: false);
		}
		List<IntPoint> list2 = new List<IntPoint>();
		foreach (Geopoint_Struct item2 in list_0)
		{
			list2.Add(new IntPoint(new IntPoint(item2.Longitude * 100000000000000.0, item2.Latitude * 100000000000000.0)));
		}
		List<IntPoint> list3 = new List<IntPoint>();
		list3.Add(new IntPoint(double_1 * 100000000000000.0, double_0 * 100000000000000.0));
		list3.Add(new IntPoint(double_3 * 100000000000000.0, double_2 * 100000000000000.0));
		Clipper clipper = new Clipper();
		clipper.AddPath(list2, PolyType.ptSubject, bool_0: true);
		clipper.AddPath(list3, PolyType.ptClip, bool_0: true);
		List<List<IntPoint>> list4 = new List<List<IntPoint>>();
		clipper.Execute(ClipType.ctIntersection, list4, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd);
		return list4.Count > 0;
	}

	public static bool LineCrossesAntimeridian(double double_0, double double_1, double double_2, double double_3)
	{
		if (!(double_1 < 0.0) && double_3 >= 0.0)
		{
			return false;
		}
		if (double_1 < 0.0 && double_3 < 0.0)
		{
			return false;
		}
		double value = Math.Min(double_1, double_3);
		if (Math.Abs(Math.Max(double_1, double_3)) + Math.Abs(value) <= 180.0)
		{
			return false;
		}
		return true;
	}

	public static List<ReferencePoint> GrowGeopolygon(float float_0, List<ReferencePoint> list_0)
	{
		try
		{
			if (float_0 == 0f)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return list_0;
			}
			if (!Information.IsNothing(list_0) && Misc.PublishRequest(list_0))
			{
				return list_0;
			}
			Misc.Center(list_0);
			List<IntPoint> list = new List<IntPoint>();
			foreach (ReferencePoint item in list_0)
			{
				double num = item.Latitude;
				double num2 = item.Longitude;
				while (num2 > 180.0 || num2 < -180.0)
				{
					num2 = VisitClass(num2);
				}
				if (num > 90.0)
				{
					num = 90.0;
				}
				if (num < -90.0)
				{
					num = -90.0;
				}
				try
				{
					MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(num2, num);
					Coordinate coordinate = new Coordinate(mercatorPixel.x, mercatorPixel.y);
					list.Add(new IntPoint((long)Math.Round(coordinate[0]), (long)Math.Round(coordinate[1])));
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 20324532409530495090909", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			List<List<IntPoint>> list2 = new List<List<IntPoint>>();
			list2.Add(list);
			ClipperOffset clipperOffset = new ClipperOffset();
			clipperOffset.AddPaths(list2, JoinType.jtSquare, EndType.etClosedPolygon);
			List<List<IntPoint>> list_ = new List<List<IntPoint>>();
			clipperOffset.Execute(ref list_, float_0);
			List<List<IntPoint>> list3 = list_;
			List<ReferencePoint> list4 = new List<ReferencePoint>();
			if (list3.Count == 0)
			{
				return new List<ReferencePoint>();
			}
			foreach (IntPoint item2 in list3[0])
			{
				try
				{
					MercatorProjection.TCoord tCoord = MercatorProjection.toGeoCoord(item2.X, item2.Y);
					list4.Add(new ReferencePoint(tCoord.Lon, tCoord.Lat));
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at 200002", "");
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (list4.Count > 100)
			{
				list4 = SimplifyArea(list4);
			}
			return list4;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 1004935353245325", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static bool PolygonCrossesAntimeridian(IEnumerable<Geopoint_Struct> ienumerable_0)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		double num = 0.0;
		double num2 = 0.0;
		foreach (Geopoint_Struct item in ienumerable_0)
		{
			double longitude = item.Longitude;
			if (longitude < num)
			{
				num = longitude;
			}
			if (longitude > num2)
			{
				num2 = longitude;
			}
			if (longitude > 0.0)
			{
				flag2 = true;
				if (flag3)
				{
					flag = true;
				}
			}
			if (longitude < 0.0)
			{
				flag3 = true;
				if (flag2)
				{
					flag = true;
				}
			}
		}
		if (flag)
		{
			if (Math.Abs(num2) + Math.Abs(num) <= 180.0)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool PolygonCrossesAntimeridian(GeoPoint[] geoPoint_0)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		double num = 0.0;
		double num2 = 0.0;
		for (int i = 0; i < geoPoint_0.Length; i = checked(i + 1))
		{
			double longitude = geoPoint_0[i].Longitude;
			if (longitude < num)
			{
				num = longitude;
			}
			if (longitude > num2)
			{
				num2 = longitude;
			}
			if (longitude > 0.0)
			{
				flag2 = true;
				if (flag3)
				{
					flag = true;
				}
			}
			if (longitude < 0.0)
			{
				flag3 = true;
				if (flag2)
				{
					flag = true;
				}
			}
		}
		if (flag)
		{
			if (Math.Abs(num2) + Math.Abs(num) <= 180.0)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool PolygonCrossesAntimeridian(List<GeoPoint> list_0)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		int num = list_0.Count - 1;
		double num2 = 0.0;
		double num3 = 0.0;
		for (int i = 0; i <= num; i++)
		{
			GeoPoint geoPoint = list_0[i];
			if (geoPoint == null)
			{
				continue;
			}
			double longitude = geoPoint.Longitude;
			if (longitude < num2)
			{
				num2 = longitude;
			}
			if (longitude > num3)
			{
				num3 = longitude;
			}
			if (longitude > 0.0)
			{
				flag2 = true;
				if (flag3)
				{
					flag = true;
				}
			}
			if (longitude < 0.0)
			{
				flag3 = true;
				if (flag2)
				{
					flag = true;
				}
			}
		}
		if (flag)
		{
			if (Math.Abs(num3) + Math.Abs(num2) <= 180.0)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool PolygonCrossesAntimeridian(ref List<ReferencePoint> list_0)
	{
		try
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			int count = list_0.Count;
			ReferencePoint[] gparam_ = Misc.ChangeRequest(list_0);
			double num = 0.0;
			double num2 = 0.0;
			for (int i = count - 1; i >= 0; i += -1)
			{
				ReferencePoint referencePoint;
				try
				{
					if (gparam_[i] == null)
					{
						ArrayExtensions.Remove(ref gparam_, gparam_[i]);
						continue;
					}
					referencePoint = gparam_[i];
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200485", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					continue;
				}
				double longitude = referencePoint.Longitude;
				if (longitude < num)
				{
					num = longitude;
				}
				if (longitude > num2)
				{
					num2 = longitude;
				}
				if (longitude > 0.0)
				{
					flag2 = true;
					if (flag3)
					{
						flag = true;
					}
				}
				if (longitude < 0.0)
				{
					flag3 = true;
					if (flag2)
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				if (Math.Abs(num2) + Math.Abs(num) <= 180.0)
				{
					return false;
				}
				return true;
			}
			return false;
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 200486", exception_2.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal static bool ResetClass(object object_0)
	{
		int num = ((Array)object_0).Length - 3;
		for (int i = 0; i <= num; i++)
		{
			int num2 = i + ((Array)object_0).Length - 2;
			if (i >= 2)
			{
				num2 -= i - 1;
			}
			int num3 = i + 2;
			int num4 = num2;
			for (int j = num3; j <= num4; j++)
			{
				if (MapClass(((Vector2[])object_0)[i], ((Vector2[])object_0)[i + 1], ((Vector2[])object_0)[j % ((Array)object_0).Length], ((Vector2[])object_0)[(j + 1) % ((Array)object_0).Length]))
				{
					return true;
				}
			}
		}
		return false;
	}

	private static bool MapClass(Vector2 vector2_0, Vector2 vector2_1, Vector2 vector2_2, Vector2 vector2_3)
	{
		Vector2 vector = vector2_1 - vector2_0;
		Vector2 vector2 = vector2_2 - vector2_3;
		Vector2 vector3 = vector2_0 - vector2_2;
		float num = (float)(vector2.Y * vector3.X - vector2.X * vector3.Y);
		float num2 = (float)(vector.Y * vector2.X - vector.X * vector2.Y);
		float num3 = (float)(vector.X * vector3.Y - vector.Y * vector3.X);
		float num4 = num2;
		bool flag = true;
		if (num2 != 0f && num4 != 0f)
		{
			if (num2 <= 0f)
			{
				if (num > 0f || num < num2)
				{
					flag = false;
				}
			}
			else if (num < 0f || num > num2)
			{
				flag = false;
			}
			if (flag && num4 > 0f)
			{
				if (num3 < 0f || num3 > num4)
				{
					flag = false;
				}
			}
			else if (num3 > 0f || num3 < num4)
			{
				flag = false;
			}
		}
		else
		{
			flag = false;
		}
		return flag;
	}

	internal static double SortClass(double double_0)
	{
		double x = 100.0;
		return Math.Atan2(100.0 * double_0, x) * 57.2957795130823;
	}

	public static void SlowFunction()
	{
		CalcClass(1000);
	}

	private static long CalcClass(int int_0)
	{
		int num = 0;
		long num2 = 2L;
		while (num < int_0)
		{
			long num3 = 2L;
			int num4 = 1;
			for (; num3 * num3 <= num2; num3++)
			{
				if (num2 % num3 == 0)
				{
					num4 = 0;
					break;
				}
			}
			if (num4 > 0)
			{
				num++;
			}
			num2++;
		}
		return num2 - 1;
	}

	internal static List<Geopoint_Struct> RateClass(ref List<Geopoint_Struct> list_0, ref List<Geopoint_Struct> list_1)
	{
		try
		{
			List<Geopoint_Struct> list = new List<Geopoint_Struct>(list_0.Count);
			List<Geopoint_Struct> list2 = new List<Geopoint_Struct>(list_1.Count);
			foreach (Geopoint_Struct item4 in list_0)
			{
				Geopoint_Struct item = new Geopoint_Struct(item4.Longitude * 100000000000000.0, item4.Latitude * 100000000000000.0);
				list.Add(item);
			}
			foreach (Geopoint_Struct item5 in list_1)
			{
				Geopoint_Struct item2 = new Geopoint_Struct(item5.Longitude * 100000000000000.0, item5.Latitude * 100000000000000.0);
				list2.Add(item2);
			}
			List<IntPoint> list3 = new List<IntPoint>(list.Count);
			foreach (Geopoint_Struct item6 in list)
			{
				if (!double.IsNaN(item6.Latitude) && !double.IsNaN(item6.Longitude) && item6.Longitude <= 9.223372036854776E+18 && item6.Latitude <= 9.223372036854776E+18)
				{
					list3.Add(new IntPoint((long)Math.Round(item6.Longitude), (long)Math.Round(item6.Latitude)));
				}
			}
			List<IntPoint> list4 = new List<IntPoint>(list2.Count);
			foreach (Geopoint_Struct item7 in list2)
			{
				if (!double.IsNaN(item7.Latitude) && !double.IsNaN(item7.Longitude) && item7.Longitude <= 9.223372036854776E+18 && item7.Latitude <= 9.223372036854776E+18)
				{
					list4.Add(new IntPoint((long)Math.Round(item7.Longitude), (long)Math.Round(item7.Latitude)));
				}
			}
			Clipper clipper = new Clipper();
			clipper.AddPath(list3, PolyType.ptSubject, bool_0: true);
			clipper.AddPath(list4, PolyType.ptClip, bool_0: true);
			List<List<IntPoint>> list5 = new List<List<IntPoint>>();
			if (clipper.Execute(ClipType.ctIntersection, list5, PolyFillType.pftNonZero, PolyFillType.pftNonZero))
			{
				List<Geopoint_Struct> list6 = new List<Geopoint_Struct>();
				if (list5.Count <= 0)
				{
					return new List<Geopoint_Struct>();
				}
				foreach (IntPoint item8 in list5[0])
				{
					Geopoint_Struct item3 = default(Geopoint_Struct);
					item3.Latitude = (double)item8.Y / 100000000000000.0;
					item3.Longitude = (double)item8.X / 100000000000000.0;
					list6.Add(item3);
				}
				return list6;
			}
			return new List<Geopoint_Struct>();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200016", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<Geopoint_Struct> result = list_1;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private static List<Geopoint_Struct[]> FlushClass(List<Geopoint_Struct[]> list_0)
	{
		try
		{
			Clipper clipper = new Clipper();
			foreach (Geopoint_Struct[] item in list_0)
			{
				List<IntPoint> list = new List<IntPoint>();
				Geopoint_Struct[] array = item;
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					Geopoint_Struct geopoint_Struct = array[i];
					Geopoint_Struct geopoint_Struct2 = new Geopoint_Struct(geopoint_Struct.Longitude * 100000000000000.0, geopoint_Struct.Latitude * 100000000000000.0);
					if (!double.IsNaN(geopoint_Struct2.Latitude) && !double.IsNaN(geopoint_Struct2.Longitude) && geopoint_Struct2.Longitude <= 9.223372036854776E+18 && geopoint_Struct2.Latitude <= 9.223372036854776E+18)
					{
						list.Add(new IntPoint((long)Math.Round(geopoint_Struct2.Longitude), (long)Math.Round(geopoint_Struct2.Latitude)));
					}
				}
				clipper.AddPath(list, PolyType.ptSubject, bool_0: true);
			}
			List<List<IntPoint>> list2 = new List<List<IntPoint>>();
			if (clipper.Execute(ClipType.ctUnion, list2, PolyFillType.pftNonZero, PolyFillType.pftNonZero))
			{
				List<Geopoint_Struct[]> list3 = new List<Geopoint_Struct[]>();
				if (list2.Count <= 0)
				{
					return new List<Geopoint_Struct[]>();
				}
				foreach (List<IntPoint> item2 in list2)
				{
					Geopoint_Struct[] array2 = new Geopoint_Struct[item2.Count - 1 + 1];
					int num = item2.Count - 1;
					for (int j = 0; j <= num; j++)
					{
						Geopoint_Struct geopoint_Struct3 = default(Geopoint_Struct);
						geopoint_Struct3.Latitude = (double)item2[j].Y / 100000000000000.0;
						geopoint_Struct3.Longitude = (double)item2[j].X / 100000000000000.0;
						array2[j] = geopoint_Struct3;
					}
					list3.Add(array2);
				}
				return list3;
			}
			return new List<Geopoint_Struct[]>();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<Geopoint_Struct[]> result = new List<Geopoint_Struct[]>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal static List<Geopoint_Struct[]> ForgotClass(List<Geopoint_Struct[]> list_0, int int_0 = 0)
	{
		if (list_0.Count == 0)
		{
			return new List<Geopoint_Struct[]>();
		}
		if (int_0 == 0)
		{
			int_0 = GameGeneral._CallbackDic - 1;
		}
		List<Geopoint_Struct[]>[] source = Misc.AddValue(list_0, Math.Max(1, int_0));
		TList<List<Geopoint_Struct[]>> Local_theBag = new TList<List<Geopoint_Struct[]>>();
		try
		{
			Parallel.ForEach(source, delegate(List<Geopoint_Struct[]> theChunk)
			{
				Local_theBag.Add(FlushClass(theChunk));
			});
			List<List<Geopoint_Struct[]>> list = Local_theBag.ToList();
			List<Geopoint_Struct[]> list2 = new List<Geopoint_Struct[]>();
			foreach (List<Geopoint_Struct[]> item in list)
			{
				list2.AddRange(item);
			}
			return FlushClass(list2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 20023452465666621347826346", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<Geopoint_Struct[]> result = new List<Geopoint_Struct[]>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal static List<List<GeoPoint>> CollectClass(List<List<GeoPoint>> list_0)
	{
		try
		{
			Clipper clipper = new Clipper();
			foreach (List<GeoPoint> item in list_0)
			{
				List<IntPoint> list = new List<IntPoint>();
				foreach (GeoPoint item2 in item)
				{
					GeoPoint geoPoint = new GeoPoint(item2.Longitude * 100000000000000.0, item2.Latitude * 100000000000000.0);
					if (!double.IsNaN(geoPoint.Latitude) && !double.IsNaN(geoPoint.Longitude) && geoPoint.Longitude <= 9.223372036854776E+18 && geoPoint.Latitude <= 9.223372036854776E+18)
					{
						list.Add(new IntPoint((long)Math.Round(geoPoint.Longitude), (long)Math.Round(geoPoint.Latitude)));
					}
				}
				clipper.AddPath(list, PolyType.ptSubject, bool_0: true);
			}
			List<List<IntPoint>> list2 = new List<List<IntPoint>>();
			if (clipper.Execute(ClipType.ctUnion, list2, PolyFillType.pftNonZero, PolyFillType.pftNonZero))
			{
				List<List<GeoPoint>> list3 = new List<List<GeoPoint>>();
				if (list2.Count <= 0)
				{
					return new List<List<GeoPoint>>();
				}
				foreach (List<IntPoint> item3 in list2)
				{
					List<GeoPoint> list4 = new List<GeoPoint>();
					foreach (IntPoint item4 in item3)
					{
						GeoPoint geoPoint2 = new GeoPoint();
						geoPoint2.Latitude = (double)item4.Y / 100000000000000.0;
						geoPoint2.Longitude = (double)item4.X / 100000000000000.0;
						list4.Add(geoPoint2);
					}
					list3.Add(list4);
				}
				return list3;
			}
			return new List<List<GeoPoint>>();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200234524656666", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<List<GeoPoint>> result = new List<List<GeoPoint>>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal static double OrderClass(string string_0)
	{
		string numberGroupSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
		if (string_0.LastIndexOf(numberGroupSeparator) + 4 == string_0.Count())
		{
			if (!double.TryParse(string_0, NumberStyles.Any, CultureInfo.CurrentCulture, out var result))
			{
				return 0.0;
			}
			return result;
		}
		string text = string_0.Trim().Replace(" ", string.Empty).Replace(",", ".");
		string[] source = text.Split('.');
		if (source.Count() > 1)
		{
			text = string.Join(string.Empty, source.Take(source.Count() - 1).ToArray());
			text = text + "." + source.Last();
		}
		return double.Parse(text, CultureInfo.InvariantCulture);
	}

	internal static double RegisterClass(Tuple<double, double> tuple_0, Tuple<double, double> tuple_1)
	{
		double item = tuple_0.Item1;
		double item2 = tuple_1.Item1;
		double num = tuple_1.Item2 - tuple_0.Item2;
		double y = Math.Sin(num) * Math.Cos(item2);
		double x = Math.Cos(item) * Math.Sin(item2) - Math.Sin(item) * Math.Cos(item2) * Math.Cos(num);
		return Math.Atan2(y, x);
	}

	internal static Tuple<double, double> ManageClass(Tuple<double, double> tuple_0, Tuple<double, double> tuple_1, Tuple<double, double> tuple_2, Tuple<double, double> tuple_3)
	{
		double item = tuple_0.Item1;
		double item2 = tuple_0.Item2;
		double item3 = tuple_2.Item1;
		double item4 = tuple_2.Item2;
		double num = RegisterClass(tuple_0, tuple_1);
		double num8 = RegisterClass(tuple_2, tuple_3);
		double num9 = item3 - item;
		double num10 = item4 - item2;
		double num11 = 2.0 * Math.Asin(Math.Sqrt(Math.Sin(num9 / 2.0) * Math.Sin(num9 / 2.0) + Math.Cos(item) * Math.Cos(item3) * Math.Sin(num10 / 2.0) * Math.Sin(num10 / 2.0)));
		if (num11 == 0.0)
		{
			return null;
		}
		double num12 = Math.Acos((Math.Sin(item3) - Math.Sin(item) * Math.Cos(num11)) / (Math.Sin(num11) * Math.Cos(item)));
		if (double.IsNaN(num12))
		{
			num12 = 0.0;
		}
		double num13 = Math.Acos((Math.Sin(item) - Math.Sin(item3) * Math.Cos(num11)) / (Math.Sin(num11) * Math.Cos(item3)));
		double num14;
		double num15;
		if (Math.Sin(item4 - item2) <= 0.0)
		{
			num14 = Math.PI * 2.0 - num12;
			num15 = num13;
		}
		else
		{
			num14 = num12;
			num15 = Math.PI * 2.0 - num13;
		}
		double num2 = (num - num14 + Math.PI) % (Math.PI * 2.0) - Math.PI;
		double num3 = (num15 - num8 + Math.PI) % (Math.PI * 2.0) - Math.PI;
		if (Math.Sin(num2) == 0.0 && Math.Sin(num3) == 0.0)
		{
			return null;
		}
		if (Math.Sin(num2) * Math.Sin(num3) < 0.0)
		{
			return null;
		}
		double d = Math.Acos((0.0 - Math.Cos(num2)) * Math.Cos(num3) + Math.Sin(num2) * Math.Sin(num3) * Math.Cos(num11));
		double num4 = Math.Atan2(Math.Sin(num11) * Math.Sin(num2) * Math.Sin(num3), Math.Cos(num3) + Math.Cos(num2) * Math.Cos(d));
		double num5 = Math.Asin(Math.Sin(item) * Math.Cos(num4) + Math.Cos(item) * Math.Sin(num4) * Math.Cos(num));
		double num6 = Math.Atan2(Math.Sin(num) * Math.Sin(num4) * Math.Cos(item), Math.Cos(num4) - Math.Sin(item) * Math.Sin(num5));
		double num7 = item2 + num6;
		num7 = (num7 + Math.PI * 3.0) % (Math.PI * 2.0) - Math.PI;
		return new Tuple<double, double>(num5, num7);
	}

	internal static double RevertClass(double double_0, double double_1, double double_2)
	{
		double num = double_0 * 0.0174532925199433;
		double num2 = double_1 * 0.0174532925199433;
		double num3 = Math.Cos(num);
		double num4 = Math.Sin(num);
		double num5 = Math.Cos(num2) * double_2;
		double num6 = Math.Sin(num2) * double_2;
		return num3 * num5 + num4 * num6;
	}

	public static float SpecularReflectionAzimuth(float float_0, float float_1)
	{
		float num = MathFunctions.DeleteRequest(float_0, float_1);
		float num2 = num;
		if (num2 != 90f && num2 != 270f)
		{
			if (num2 != 0f && num2 != 180f)
			{
				if (num2 <= 0f)
				{
					if (num2 < 0f)
					{
						return UpdateClass(float_0 - 180f + num);
					}
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return 0f;
				}
				return UpdateClass(float_0 + 180f - num);
			}
			return UpdateClass(float_1 + 180f);
		}
		return float_1;
	}
}
