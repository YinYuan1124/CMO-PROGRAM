using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Terrain
{
	public struct TerrainGridCell
	{
		public double Center_Lat;

		public double Center_Lon;

		public double Width_degrees;

		public double Height_degrees;

		public Geopoint_Struct NorthWesternCorner => new Geopoint_Struct(Center_Lon - Width_degrees * 0.5, Center_Lat + Height_degrees * 0.5);

		public Geopoint_Struct NorthEasternCorner => new Geopoint_Struct(Center_Lon + Width_degrees * 0.5, Center_Lat + Height_degrees * 0.5);

		public Geopoint_Struct SouthWesternCorner => new Geopoint_Struct(Center_Lon - Width_degrees * 0.5, Center_Lat - Height_degrees * 0.5);

		public Geopoint_Struct SouthEasternCorner => new Geopoint_Struct(Center_Lon + Width_degrees * 0.5, Center_Lat - Height_degrees * 0.5);

		public TerrainGridCell(double double_0, double double_1, double double_2, double double_3)
		{
			this = default(TerrainGridCell);
			Center_Lat = double_0;
			Center_Lon = double_1;
			Width_degrees = double_2;
			Height_degrees = double_3;
		}
	}

	public struct TerrainRasterCell
	{
		public string UniqueKey;

		public double CenterLatitude;

		public double CenterLongitude;

		public short ElevationValue;

		public double Width_degrees;

		public double Height_degrees;

		public Geopoint_Struct NorthWesternCorner => new Geopoint_Struct(CenterLongitude - Width_degrees * 0.5, CenterLatitude + Height_degrees * 0.5);

		public Geopoint_Struct NorthEasternCorner => new Geopoint_Struct(CenterLongitude + Width_degrees * 0.5, CenterLatitude + Height_degrees * 0.5);

		public Geopoint_Struct SouthWesternCorner => new Geopoint_Struct(CenterLongitude - Width_degrees * 0.5, CenterLatitude - Height_degrees * 0.5);

		public Geopoint_Struct SouthEasternCorner => new Geopoint_Struct(CenterLongitude + Width_degrees * 0.5, CenterLatitude - Height_degrees * 0.5);
	}

	public struct MaxMinRecord
	{
		public short Max;

		public short Min;

		public MaxMinRecord(short short_0, short short_1)
		{
			this = default(MaxMinRecord);
			Max = short_0;
			Min = short_1;
		}
	}

	[CompilerGenerated]
	private sealed class HelperItem
	{
		public Scenario CurrentScen;

		public float TargetAlt_AGL;

		public double ObserverLat;

		public double ObserverLon;

		public float ObserverAlt;

		public ConcurrentQueue<TerrainGridCell> concurrentQueue;

		internal void ViewInterruptibleParam(TerrainGridCell theCell)
		{
			short elevation = GetElevation(theCell.Center_Lat, theCell.Center_Lon, bool_0: false, CurrentScen);
			float float_ = (float)Math.Max(0, (int)elevation) + TargetAlt_AGL;
			if (Scenario.DetermineLOS(ObserverLat, ObserverLon, ObserverAlt, theCell.Center_Lat, theCell.Center_Lon, float_, bool_0: false, CurrentScen))
			{
				concurrentQueue.Enqueue(theCell);
			}
		}
	}

	[CompilerGenerated]
	private sealed class IdentifierConfigObject
	{
		public ITerrainProvider authoritativeProvider;

		public double theLat;

		public double theLon;

		public int location;

		internal void ValidateInterruptibleParam(TerrainGridCell _003Cp0_003E)
		{
			if (authoritativeProvider.PointIsOverland(theLat, theLon).IsOverland)
			{
				Interlocked.Increment(ref location);
			}
		}
	}

	public static short GlobalMaxTerrainElevation;

	public static bool TerrainHasLoaded;

	public static Dictionary<string, List<BinGridModule.TBinGrid>> TerrainGrids;

	private static List<ITerrainProvider> _ExceptionProxy;

	[ThreadStatic]
	private static List<TerrainGridCell> m_AttrProxy;

	static Terrain()
	{
		GlobalMaxTerrainElevation = 8850;
		TerrainHasLoaded = false;
		TerrainGrids = new Dictionary<string, List<BinGridModule.TBinGrid>>();
		_ExceptionProxy = new List<ITerrainProvider>();
	}

	[SpecialName]
	public static ITerrainProvider GetAuthoritativeProvider(double double_0, double double_1)
	{
		if (_ExceptionProxy.Count != 1)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new NotImplementedException();
		}
		return _ExceptionProxy[0];
	}

	public static void InitializeTerrain()
	{
		BinaryGridProvider binaryGridProvider = new BinaryGridProvider();
		binaryGridProvider.PushProperty();
		_ExceptionProxy.Add(binaryGridProvider);
		if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
		{
			GameGeneral.WriteLogDebugInfoToFile("Loaded terrain grids (BGD).");
		}
	}

	public static void CleanUp()
	{
		foreach (ITerrainProvider item in _ExceptionProxy)
		{
			item.DisposeResources();
		}
	}

	public static short GetElevation(double double_0, double double_1, bool bool_0, Scenario scenario_0)
	{
		if (scenario_0 != null && scenario_0.NatureSideExists())
		{
			foreach (CustomEnvironmentZone customEnvironmentZone in scenario_0.GetNatureSide().CustomEnvironmentZones)
			{
				if (customEnvironmentZone.TerrainType != LandCover.LandCoverType.Use_Underlying_Values && GeoPoint.IsInsideThisArea(double_0, double_1, customEnvironmentZone.Area) && customEnvironmentZone.HasCustomTerrainHeight)
				{
					return Convert.ToInt16(customEnvironmentZone.TerrainHeight);
				}
			}
		}
		return GetAuthoritativeProvider(double_0, double_1).GetElevation(double_0, double_1, bool_0);
	}

	internal static bool LoginWatcher(double double_0, double double_1, double double_2, double double_3)
	{
		ITerrainProvider authoritativeProvider = GetAuthoritativeProvider(double_0, double_1);
		ITerrainProvider authoritativeProvider2 = GetAuthoritativeProvider(double_2, double_3);
		if (authoritativeProvider == authoritativeProvider2)
		{
			return authoritativeProvider.GeopointsAreOnSameOrAdjacentCell(double_0, double_1, double_2, double_3);
		}
		return false;
	}

	internal static short GetWatcher(double double_0, double double_1)
	{
		return GetAuthoritativeProvider(double_0, double_1).GetMaxForThisDegCell(double_0, double_1);
	}

	internal static ConcurrentQueue<TerrainGridCell> WriteWatcher(double double_0, double double_1, float float_0, float float_1, float float_2, Scenario scenario_0)
	{
		if (m_AttrProxy == null)
		{
			m_AttrProxy = new List<TerrainGridCell>();
		}
		else
		{
			m_AttrProxy.Clear();
		}
		m_AttrProxy = NewWatcher(double_0, double_1, float_2, ref m_AttrProxy);
		ConcurrentQueue<TerrainGridCell> concurrentQueue = new ConcurrentQueue<TerrainGridCell>();
		Parallel.ForEach(m_AttrProxy, delegate(TerrainGridCell theCell)
		{
			short elevation = GetElevation(theCell.Center_Lat, theCell.Center_Lon, bool_0: false, scenario_0);
			float float_3 = (float)Math.Max(0, (int)elevation) + float_1;
			if (Scenario.DetermineLOS(double_0, double_1, float_0, theCell.Center_Lat, theCell.Center_Lon, float_3, bool_0: false, scenario_0))
			{
				concurrentQueue.Enqueue(theCell);
			}
		});
		return concurrentQueue;
	}

	private static List<TerrainGridCell> NewWatcher(double double_0, double double_1, float float_0, ref List<TerrainGridCell> list_0)
	{
		double double_2 = 0.0;
		double double_3 = 0.0;
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_3, ref double_2, float_0, 270);
		double_2 = 0.0;
		double double_4 = 0.0;
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_4, ref double_2, float_0, 90);
		double_2 = 0.0;
		double double_5 = 0.0;
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_2, ref double_5, float_0, 0);
		double_2 = 0.0;
		double double_6 = 0.0;
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_2, ref double_6, float_0, 180);
		int num = (int)Math.Round(Math.Pow((int)Math.Round(Math2.TestClass(float_0) * 2.0 / (1.0 / 120.0)), 2.0));
		if (list_0 == null)
		{
			list_0 = new List<TerrainGridCell>(num);
		}
		else
		{
			list_0.Clear();
			if (list_0.Capacity < num)
			{
				list_0.Capacity = num;
			}
		}
		double num2 = double_3;
		double_2 = double_4;
		TerrainGridCell item = default(TerrainGridCell);
		for (double num3 = num2; num3 <= double_2; num3 += 1.0 / 120.0)
		{
			double num4 = double_5;
			double num5 = double_6;
			for (double num6 = num4; num6 >= num5; num6 += -1.0 / 120.0)
			{
				item.Center_Lon = num3 + 1.0 / 240.0;
				item.Center_Lat = num6 - 1.0 / 240.0;
				if (Math2.VerifyClass(item.Center_Lat, item.Center_Lon, double_0, double_1) <= float_0)
				{
					item.Height_degrees = 0.008611111111111111;
					item.Width_degrees = 0.008611111111111111;
					list_0.Add(item);
				}
			}
		}
		return list_0;
	}

	internal static bool PushWatcher(double double_0, double double_1, double double_2, double double_3, int int_0, Scenario scenario_0)
	{
		double num = (double)int_0 * 0.000539957;
		double num2 = Math2.VerifyClass(double_0, double_1, double_2, double_3);
		double double_4 = Math2.PublishClass(double_0, double_1, double_2, double_3);
		if (GetElevation(double_0, double_1, bool_0: false, scenario_0) < 0)
		{
			double double_5 = 0.0;
			double double_6 = 0.0;
			double double_7 = 0.0;
			while (true)
			{
				double_5 += num;
				if (!(double_5 <= num2))
				{
					break;
				}
				Geodesic_EdWilliams.CalcPoint_Williams(ref double_1, ref double_0, ref double_6, ref double_7, ref double_5, ref double_4);
				if (GetElevation(double_7, double_6, bool_0: false, scenario_0) >= 0)
				{
					return true;
				}
			}
			if (GetElevation(double_2, double_3, bool_0: false, scenario_0) < 0)
			{
				return false;
			}
			return true;
		}
		return true;
	}

	internal static float InvokeWatcher(double double_0, double double_1, bool bool_0, Scenario scenario_0)
	{
		try
		{
			double_0 = Math2.ReflectClass(double_0);
			double_1 = Math2.VisitClass(double_1);
			Geopoint_Struct newPoint_Struct = GeoPoint.GetNewPoint_Struct(double_0, double_1, 315f, 0.12142472f);
			Geopoint_Struct newPoint_Struct2 = GeoPoint.GetNewPoint_Struct(double_0, double_1, 0f, 0.12142472f);
			Geopoint_Struct newPoint_Struct3 = GeoPoint.GetNewPoint_Struct(double_0, double_1, 45f, 0.12142472f);
			Geopoint_Struct newPoint_Struct4 = GeoPoint.GetNewPoint_Struct(double_0, double_1, 90f, 0.12142472f);
			Geopoint_Struct newPoint_Struct5 = GeoPoint.GetNewPoint_Struct(double_0, double_1, 135f, 0.12142472f);
			Geopoint_Struct newPoint_Struct6 = GeoPoint.GetNewPoint_Struct(double_0, double_1, 180f, 0.12142472f);
			Geopoint_Struct newPoint_Struct7 = GeoPoint.GetNewPoint_Struct(double_0, double_1, 225f, 0.12142472f);
			Geopoint_Struct newPoint_Struct8 = GeoPoint.GetNewPoint_Struct(double_0, double_1, 270f, 0.12142472f);
			float value = (float)((double)(short)(GetElevation(newPoint_Struct2.Latitude, newPoint_Struct2.Longitude, bool_0, scenario_0) - GetElevation(newPoint_Struct6.Latitude, newPoint_Struct6.Longitude, bool_0, scenario_0)) / 450.0);
			float value2 = (float)((double)(short)(GetElevation(newPoint_Struct4.Latitude, newPoint_Struct4.Longitude, bool_0, scenario_0) - GetElevation(newPoint_Struct8.Latitude, newPoint_Struct8.Longitude, bool_0, scenario_0)) / 450.0);
			float value3 = (float)((double)(short)(GetElevation(newPoint_Struct3.Latitude, newPoint_Struct3.Longitude, bool_0, scenario_0) - GetElevation(newPoint_Struct7.Latitude, newPoint_Struct7.Longitude, bool_0, scenario_0)) / 450.0);
			float value4 = (float)((double)(short)(GetElevation(newPoint_Struct.Latitude, newPoint_Struct.Longitude, bool_0, scenario_0) - GetElevation(newPoint_Struct5.Latitude, newPoint_Struct5.Longitude, bool_0, scenario_0)) / 450.0);
			List<float> obj = new List<float>(4)
			{
				Math.Abs(value2),
				Math.Abs(value),
				Math.Abs(value3),
				Math.Abs(value4)
			};
			float num = 0f;
			foreach (float item in obj)
			{
				num = Math.Max(item, num);
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200094", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	internal static TerrainRasterCell SetupWatcher(double double_0, double double_1)
	{
		return GetAuthoritativeProvider(double_0, double_1).GetSingleRasterCell(double_0, double_1);
	}

	internal static (bool IsOverland, short? RetrievedElevation) ExcludeWatcher(double double_0, double double_1)
	{
		return GetAuthoritativeProvider(double_0, double_1).PointIsOverland(double_0, double_1);
	}

	internal static float IncludeWatcher(double double_0, double double_1, float float_0)
	{
		if (m_AttrProxy == null)
		{
			m_AttrProxy = new List<TerrainGridCell>();
		}
		else
		{
			m_AttrProxy.Clear();
		}
		m_AttrProxy = NewWatcher(double_0, double_1, float_0, ref m_AttrProxy);
		int location = 0;
		ITerrainProvider authoritativeProvider = GetAuthoritativeProvider(double_0, double_1);
		Parallel.ForEach((IEnumerable<TerrainGridCell>)m_AttrProxy, (Action<TerrainGridCell>)delegate
		{
			if (authoritativeProvider.PointIsOverland(double_0, double_1).IsOverland)
			{
				Interlocked.Increment(ref location);
			}
		});
		return (float)((double)location / (double)m_AttrProxy.Count);
	}

	internal static float SearchWatcher(List<ReferencePoint> list_0)
	{
		list_0 = (from thePoint in list_0
			orderby Math.Atan2(thePoint.Longitude, thePoint.Latitude)
			select (thePoint)).ToList();
		GeoPoint geoPoint = new GeoPoint();
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		int num8 = list_0.Count - 1;
		for (int i = 0; i <= num8; i++)
		{
			num2 = list_0[i].Longitude;
			num3 = list_0[i].Latitude;
			num4 = list_0[i + 1].Longitude;
			num5 = list_0[i + 1].Latitude;
			num6 = num2 * num5 - num4 * num3;
			num += num6;
			geoPoint.Longitude += (num2 + num4) * num6;
			geoPoint.Latitude += (num3 + num5) * num6;
			if (num4 - num2 > num7)
			{
				num7 = num4 - num2;
			}
			if (num5 - num3 > num7)
			{
				num7 = num5 - num3;
			}
		}
		num2 = list_0[list_0.Count - 1].Longitude;
		num3 = list_0[list_0.Count - 1].Latitude;
		num4 = list_0[0].Longitude;
		num5 = list_0[0].Latitude;
		num6 = num2 * num5 - num4 * num3;
		num += num6;
		geoPoint.Longitude += (num2 + num4) * num6;
		geoPoint.Latitude += (num3 + num5) * num6;
		num *= 0.5;
		geoPoint.Longitude /= 6.0 * num;
		geoPoint.Latitude /= 6.0 * num;
		return IncludeWatcher(geoPoint.Latitude, geoPoint.Longitude, Convert.ToSingle(num7));
	}
}
