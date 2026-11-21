using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;
using DarkUI.Collections;
using DotSpatial.Topology;
using DotSpatial.Topology.Operation.Distance;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class Zone : ScenarioObject
{
	public enum ZoneType
	{
		Zone,
		NoNavZone,
		ExclusionZone,
		CustomEnvironmentZone
	}

	[CompilerGenerated]
	private sealed class ProcessSetter
	{
		public Side side;

		internal int RemoveInterruptibleParam(CustomEnvironmentZone x)
		{
			return x.GetLayer(side);
		}

		internal int FindInterruptibleParam(Zone x)
		{
			return x.GetLayer(side);
		}
	}

	public string Description;

	internal int _PredicateReader;

	private object _SingletonReader;

	public List<ReferencePoint> Area;

	public List<ReferencePoint> Area_RefPoints_020deg_ChangeCheck;

	public List<ReferencePoint> Area_RefPoints_015deg_ChangeCheck;

	public List<Geopoint_Struct> Area_GeoPoints_020deg_Buffered;

	public List<Geopoint_Struct> Area_GeoPoints_015deg_Buffered;

	public Color AreaColor;

	[AccessedThroughProperty("AffectedUnitTypes")]
	[CompilerGenerated]
	private ObservableList<GlobalVariables.ActiveUnitType> _RecordReader;

	public bool IsActive;

	private bool? exceptionReader;

	private bool? _AttrReader;

	private bool? m_VisitorReader;

	private bool? _ExporterReader;

	private bool? prototypeReader;

	private bool? comparatorReader;

	private bool? _ItemReader;

	public virtual ZoneType Type => ZoneType.Zone;

	public virtual ObservableList<GlobalVariables.ActiveUnitType> AffectedUnitTypes
	{
		[CompilerGenerated]
		get
		{
			return _RecordReader;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<GlobalVariables.ActiveUnitType>> value2 = ForgotDescriptor;
			EventHandler<ObservableListModified<GlobalVariables.ActiveUnitType>> value3 = CollectDescriptor;
			ObservableList<GlobalVariables.ActiveUnitType> recordReader = _RecordReader;
			if (recordReader != null)
			{
				recordReader.ItemsAdded -= value2;
				recordReader.ItemsRemoved -= value3;
			}
			_RecordReader = value;
			recordReader = _RecordReader;
			if (recordReader != null)
			{
				recordReader.ItemsAdded += value2;
				recordReader.ItemsRemoved += value3;
			}
		}
	}

	[SpecialName]
	public int GetLayer(Side side_0)
	{
		return _PredicateReader;
	}

	[SpecialName]
	public void SetLayer(Side side_0, int int_0)
	{
		if (int_0 != _PredicateReader)
		{
			_PredicateReader = Math.Max(int_0, 0);
			ReorderAccordingTolayer(side_0, Type);
		}
	}

	public void ReorderAccordingTolayer(Side side_0, ZoneType zoneType_0)
	{
		object singletonReader = _SingletonReader;
		ObjectFlowControl.CheckForSyncLockOnValueType(singletonReader);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(singletonReader, ref lockTaken);
			switch (zoneType_0)
			{
			case ZoneType.CustomEnvironmentZone:
				side_0.CustomEnvironmentZones = side_0.CustomEnvironmentZones.OrderBy((CustomEnvironmentZone x) => x.GetLayer(side_0)).ToList();
				break;
			default:
				throw new NotImplementedException();
			case ZoneType.Zone:
				side_0.StandardZones = side_0.StandardZones.OrderBy((Zone x) => x.GetLayer(side_0)).ToList();
				break;
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(singletonReader);
			}
		}
	}

	public Zone(string string_0, List<ReferencePoint> list_0)
	{
		_SingletonReader = RuntimeHelpers.GetObjectValue(new object());
		Area = new List<ReferencePoint>();
		Area_RefPoints_020deg_ChangeCheck = new List<ReferencePoint>();
		Area_RefPoints_015deg_ChangeCheck = new List<ReferencePoint>();
		Area_GeoPoints_020deg_Buffered = new List<Geopoint_Struct>();
		Area_GeoPoints_015deg_Buffered = new List<Geopoint_Struct>();
		IsActive = true;
		Description = string_0;
		Area = list_0;
	}

	public Zone()
	{
		_SingletonReader = RuntimeHelpers.GetObjectValue(new object());
		Area = new List<ReferencePoint>();
		Area_RefPoints_020deg_ChangeCheck = new List<ReferencePoint>();
		Area_RefPoints_015deg_ChangeCheck = new List<ReferencePoint>();
		Area_GeoPoints_020deg_Buffered = new List<Geopoint_Struct>();
		Area_GeoPoints_015deg_Buffered = new List<Geopoint_Struct>();
		IsActive = true;
	}

	internal bool QueryDescriptor(double double_0, double double_1)
	{
		return GeoPoint.IsInsideThisArea(double_0, double_1, Area);
	}

	internal bool ResetDescriptor(ActiveUnit activeUnit_0)
	{
		return activeUnit_0.GetIsInsideThisArea(Area, activeUnit_0.ParentScen, bool_0: false);
	}

	public static void TransformTo(Zone zone_0, Side side_0, Scenario scenario_0)
	{
		scenario_0.CreateNatureSideIfNeeded();
		if (zone_0 != null)
		{
			scenario_0.GetNatureSide().CustomEnvironmentZones.Add(new CustomEnvironmentZone(zone_0.Description, zone_0.Area, scenario_0, side_0, scenario_0.GlobalWeather));
			side_0.StandardZones.Remove(zone_0);
		}
	}

	public static void TransformTo(ExclusionZone exclusionZone_0, Side side_0, Scenario scenario_0)
	{
		if (exclusionZone_0 != null)
		{
			side_0.StandardZones.Add(new Zone(exclusionZone_0.Description, exclusionZone_0.Area));
			side_0.ExclusionZones.Remove(exclusionZone_0);
		}
	}

	public static void TransformTo(NoNavZone noNavZone_0, Side side_0, Scenario scenario_0)
	{
		if (noNavZone_0 != null)
		{
			side_0.StandardZones.Add(new Zone(noNavZone_0.Description, noNavZone_0.Area));
			side_0.NoNavZones.Remove(noNavZone_0);
		}
	}

	public static void TransformTo(CustomEnvironmentZone customEnvironmentZone_0, Side side_0, Scenario scenario_0)
	{
		scenario_0.CreateNatureSideIfNeeded();
		if (customEnvironmentZone_0 != null)
		{
			scenario_0.GetNatureSide().CustomEnvironmentZones.Add(new CustomEnvironmentZone(customEnvironmentZone_0.Description, customEnvironmentZone_0.Area, scenario_0, side_0, scenario_0.GlobalWeather));
			side_0.CustomEnvironmentZones.Remove(customEnvironmentZone_0);
		}
	}

	internal List<ReferencePoint> MapDescriptor(Scenario scenario_0, Side side_0, int int_0 = 1)
	{
		if (Area.Count < 2)
		{
			return null;
		}
		if (int_0 < 1)
		{
			return null;
		}
		Dictionary<int, List<ReferencePoint>> dictionary = new Dictionary<int, List<ReferencePoint>>();
		int num = Area.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			ReferencePoint referencePoint = Area.ElementAt(i);
			ReferencePoint referencePoint2 = ((i == Area.Count - 1) ? Area.ElementAt(0) : Area.ElementAt(i + 1));
			float float_ = Math2.PublishClass(referencePoint.Latitude, referencePoint.Longitude, referencePoint2.Latitude, referencePoint2.Longitude);
			double num2 = Math2.VerifyClass(referencePoint.Latitude, referencePoint.Longitude, referencePoint2.Latitude, referencePoint2.Longitude) / (float)(int_0 + 1);
			dictionary.Add(i, new List<ReferencePoint>());
			int num3 = int_0 - 1;
			for (int j = 0; j <= num3; j++)
			{
				ReferencePoint referencePoint3 = ReferencePoint.CreateNew(scenario_0, "", referencePoint.Longitude, referencePoint.Latitude, side_0, null, Color.White);
				double double_ = referencePoint.Longitude;
				double double_2 = referencePoint.Latitude;
				double double_3 = referencePoint3.Longitude;
				double double_4 = referencePoint3.Latitude;
				double double_5 = num2 * (double)(j + 1);
				Geodesic_EdWilliams.CalcPoint_Williams(ref double_, ref double_2, ref double_3, ref double_4, ref double_5, ref float_);
				referencePoint3.Latitude = double_4;
				referencePoint3.Longitude = double_3;
				referencePoint.Latitude = double_2;
				referencePoint.Longitude = double_;
				dictionary[i].Add(referencePoint3);
			}
		}
		List<ReferencePoint> list = new List<ReferencePoint>();
		int num4 = Area.Count - 1;
		for (int k = 0; k <= num4; k++)
		{
			list.Add(Area[k]);
			if (!dictionary.ContainsKey(k))
			{
				continue;
			}
			foreach (ReferencePoint item in dictionary[k])
			{
				list.Add(item);
			}
		}
		Area = list;
		return list;
	}

	public static bool ValidateArea(ref List<GeoPoint> list_0)
	{
		if (list_0 == null)
		{
			return false;
		}
		try
		{
			if (list_0.Count < 3)
			{
				return false;
			}
			if (list_0.Count == 3)
			{
				return true;
			}
			int count = list_0.Count;
			Coordinate[] array = new Coordinate[count + 1];
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(list_0[i].Longitude, list_0[i].Latitude);
				array[i] = new Coordinate(mercatorPixel.x, mercatorPixel.y);
			}
			array[count] = array[0];
			return new Polygon(new LinearRing(array)).IsValid;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public static bool ValidateArea(ref List<Geopoint_Struct> list_0)
	{
		if (list_0.Count < 3)
		{
			return false;
		}
		if (list_0.Count == 3)
		{
			return true;
		}
		int count = list_0.Count;
		Coordinate[] array = new Coordinate[count + 1];
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(list_0[i].Longitude, list_0[i].Latitude);
			array[i] = new Coordinate(mercatorPixel.x, mercatorPixel.y);
		}
		array[count] = array[0];
		return new Polygon(new LinearRing(array)).IsValid;
	}

	public static bool ValidateArea(List<ReferencePoint> list_0)
	{
		List<Geopoint_Struct> list_ = new List<Geopoint_Struct>();
		foreach (ReferencePoint item in list_0)
		{
			list_.Add(new Geopoint_Struct(item.Longitude, item.Latitude));
		}
		return ValidateArea(ref list_);
	}

	public static double ComputeArea(List<GeoPoint> list_0, bool bool_0 = true, float float_0 = 6371f)
	{
		if (bool_0 && !ValidateArea(ref list_0))
		{
			return 0.0;
		}
		int count = list_0.Count;
		if (count < 3)
		{
			return 0.0;
		}
		double num = 0.0;
		GeoPoint geoPoint = list_0[count - 1];
		double double_ = Math.Tan(Math.PI / 2.0 - geoPoint.Latitude / 180.0 * Math.PI / 2.0);
		double double_2 = geoPoint.Longitude / 180.0 * Math.PI;
		foreach (GeoPoint item in list_0)
		{
			double num2 = Math.Tan(Math.PI / 2.0 - item.Latitude / 180.0 * Math.PI / 2.0);
			double num3 = item.Longitude / 180.0 * Math.PI;
			num += PolarTriangleArea(num2, num3, double_, double_2);
			double_ = num2;
			double_2 = num3;
		}
		return num * (double)(float_0 * float_0);
	}

	public static double ComputeArea(List<Geopoint_Struct> list_0, bool bool_0 = true, float float_0 = 6371f)
	{
		if (bool_0 && !ValidateArea(ref list_0))
		{
			return 0.0;
		}
		int count = list_0.Count;
		if (count < 3)
		{
			return 0.0;
		}
		double num = 0.0;
		Geopoint_Struct geopoint_Struct = list_0[count - 1];
		double double_ = Math.Tan(Math.PI / 2.0 - geopoint_Struct.Latitude / 180.0 * Math.PI / 2.0);
		double double_2 = geopoint_Struct.Longitude / 180.0 * Math.PI;
		foreach (Geopoint_Struct item in list_0)
		{
			double num2 = Math.Tan(Math.PI / 2.0 - item.Latitude / 180.0 * Math.PI / 2.0);
			double num3 = item.Longitude / 180.0 * Math.PI;
			num += PolarTriangleArea(num2, num3, double_, double_2);
			double_ = num2;
			double_2 = num3;
		}
		return num * (double)(float_0 * float_0);
	}

	public static double PolarTriangleArea(double double_0, double double_1, double double_2, double double_3)
	{
		double num = double_1 - double_3;
		double num2 = double_0 * double_2;
		return 2.0 * Math.Atan2(num2 * Math.Sin(num), 1.0 + num2 * Math.Cos(num));
	}

	[SpecialName]
	public bool GetAffectsThisUnit(ActiveUnit activeUnit_0)
	{
		if (IsActive)
		{
			try
			{
				if (activeUnit_0.IsGroup)
				{
					if (Information.IsNothing(((Group)activeUnit_0).GroupLead))
					{
						return false;
					}
					return GetAffectsThisUnit(((Group)activeUnit_0).GroupLead);
				}
				bool? flag;
				switch (activeUnit_0.UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					if (!exceptionReader.HasValue)
					{
						RateDescriptor();
					}
					flag = exceptionReader;
					break;
				case GlobalVariables.ActiveUnitType.Ship:
					if (!_AttrReader.HasValue)
					{
						RateDescriptor();
					}
					flag = _AttrReader;
					break;
				case GlobalVariables.ActiveUnitType.Submarine:
					if (!m_VisitorReader.HasValue)
					{
						RateDescriptor();
					}
					flag = m_VisitorReader;
					break;
				case GlobalVariables.ActiveUnitType.Facility:
					if (!_ExporterReader.HasValue)
					{
						RateDescriptor();
					}
					flag = _ExporterReader;
					break;
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new NotImplementedException();
				case GlobalVariables.ActiveUnitType.Weapon:
					if (((Weapon)activeUnit_0).Type == Weapon._WeaponType.Decoy_Vehicle || ((Weapon)activeUnit_0).Type == Weapon._WeaponType.UAV_Expendable)
					{
						return true;
					}
					if (!comparatorReader.HasValue)
					{
						RateDescriptor();
					}
					flag = comparatorReader;
					break;
				case GlobalVariables.ActiveUnitType.Satellite:
					if (!_ItemReader.HasValue)
					{
						RateDescriptor();
					}
					flag = _ItemReader;
					break;
				case GlobalVariables.ActiveUnitType.Vehicle:
					if (!prototypeReader.HasValue)
					{
						RateDescriptor();
					}
					flag = prototypeReader;
					break;
				}
				return flag.Value;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100995", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
		}
		return false;
	}

	public void CalculateAreaWithThresholdAdded(float float_0, ref List<Geopoint_Struct> list_0, ref List<ReferencePoint> list_1)
	{
		new List<GeoPoint>();
		try
		{
			list_1.Clear();
			list_0.Clear();
			int count = Area.Count;
			if (count == 0)
			{
				return;
			}
			Coordinate[] array = new Coordinate[((count <= 2) ? (count - 1) : count) + 1];
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				array[i] = new Coordinate(Area[i].Longitude, Area[i].Latitude);
				List<ReferencePoint> obj = list_1;
				List<ReferencePoint> area = Area;
				int index;
				ReferencePoint referencePoint_ = area[index = i];
				ReferencePoint item = ReferencePoint.CopyRefPoint(ref referencePoint_);
				area[index] = referencePoint_;
				obj.Add(item);
			}
			if (count > 2)
			{
				array[count] = array[0];
			}
			IGeometry geometry = null;
			if (count <= 2)
			{
				switch (count)
				{
				case 2:
				{
					LineString lineString = new LineString(array);
					try
					{
						geometry = lineString.Buffer(float_0, 3);
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at 200315", exception_2.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return;
					}
					break;
				}
				case 1:
				{
					DotSpatial.Topology.Point point = new DotSpatial.Topology.Point(array[0]);
					try
					{
						geometry = point.Buffer(float_0, 3);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 200652", exception_.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return;
					}
					break;
				}
				}
			}
			else
			{
				Polygon polygon = new Polygon(new LinearRing(array));
				try
				{
					geometry = polygon.Buffer(float_0, 2);
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception exception_3 = ex3;
					exception_3?.Data.Add("Error at 200278", exception_3.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (Debugger.IsAttached && (Information.IsNothing(geometry) || geometry.Coordinates.Count == 0))
			{
				Debugger.Break();
			}
			if (Information.IsNothing(geometry))
			{
				return;
			}
			if ((object)geometry.GetType() == typeof(MultiPolygon))
			{
				IGeometry[] geometries = ((MultiPolygon)geometry).Geometries;
				for (int j = 0; j < geometries.Length; j = checked(j + 1))
				{
					IPolygon ibasicGeometry_ = (IPolygon)geometries[j];
					SortDescriptor(list_0, ibasicGeometry_);
				}
			}
			else
			{
				IPolygon ibasicGeometry_2 = (IPolygon)geometry;
				SortDescriptor(list_0, ibasicGeometry_2);
			}
		}
		catch (Exception ex4)
		{
			ProjectData.SetProjectError(ex4);
			Exception exception_4 = ex4;
			exception_4?.Data.Add("Error at 200277", exception_4.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void SortDescriptor(List<Geopoint_Struct> list_0, IBasicGeometry ibasicGeometry_0)
	{
		int num = ibasicGeometry_0.Coordinates.Count - 2;
		for (int i = 0; i <= num; i++)
		{
			if (ibasicGeometry_0.Coordinates[i].X <= 180.0)
			{
				if (ibasicGeometry_0.Coordinates[i].X < -180.0)
				{
					ibasicGeometry_0.Coordinates[i].X = -180.0;
				}
			}
			else
			{
				ibasicGeometry_0.Coordinates[i].X = 180.0;
			}
			if (ibasicGeometry_0.Coordinates[i].Y <= 90.0)
			{
				if (ibasicGeometry_0.Coordinates[i].Y < -90.0)
				{
					ibasicGeometry_0.Coordinates[i].Y = -90.0;
				}
			}
			else
			{
				ibasicGeometry_0.Coordinates[i].Y = 90.0;
			}
			list_0.Add(new Geopoint_Struct(ibasicGeometry_0.Coordinates[i].X, ibasicGeometry_0.Coordinates[i].Y));
		}
	}

	internal float CalcDescriptor(double double_0, double double_1, Scenario scenario_0)
	{
		try
		{
			int count = Area.Count;
			if (count == 0)
			{
				return float.MaxValue;
			}
			Coordinate[] array = new Coordinate[((count <= 2) ? (count - 1) : count) + 1];
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				array[i] = new Coordinate(Area[i].Longitude, Area[i].Latitude);
			}
			if (count > 2)
			{
				array[count] = array[0];
			}
			if (count > 2)
			{
				Polygon igeometry_ = new Polygon(new LinearRing(array));
				try
				{
					DotSpatial.Topology.Point igeometry_2 = new DotSpatial.Topology.Point(double_1, double_0);
					Coordinate[] array2 = DistanceOp.ClosestPoints(igeometry_, igeometry_2);
					return Math2.VerifyClass(array2[0].Y, array2[0].X, array2[1].Y, array2[1].X);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200339", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return float.MaxValue;
				}
			}
			switch (count)
			{
			case 2:
			{
				LineString igeometry_3 = new LineString(array);
				try
				{
					DotSpatial.Topology.Point igeometry_4 = new DotSpatial.Topology.Point(double_1, double_0);
					Coordinate[] array3 = DistanceOp.ClosestPoints(igeometry_3, igeometry_4);
					return Math2.VerifyClass(array3[0].Y, array3[0].X, array3[1].Y, array3[1].X);
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at 200338", exception_2.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return float.MaxValue;
				}
			}
			case 1:
				return float.MaxValue;
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 200336", exception_3.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return float.MaxValue;
	}

	private void RateDescriptor()
	{
		exceptionReader = AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Aircraft);
		_AttrReader = AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Ship);
		m_VisitorReader = AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Submarine);
		_ExporterReader = AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Facility) | AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Vehicle);
		prototypeReader = AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Vehicle) | AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Facility);
		comparatorReader = AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Weapon);
		_ItemReader = AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Satellite);
	}

	internal bool FlushDescriptor(List<ReferencePoint> list_0)
	{
		if (Area.Count == list_0.Count)
		{
			int num = Area.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (Area[i].Latitude != list_0[i].Latitude || Area[i].Longitude != list_0[i].Longitude)
				{
					return true;
				}
			}
			return false;
		}
		return true;
	}

	public virtual void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, ref Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Zone");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteElementString("Color_A", AreaColor.A.ToString());
			xmlWriter_0.WriteElementString("Color_R", AreaColor.R.ToString());
			xmlWriter_0.WriteElementString("Color_G", AreaColor.G.ToString());
			xmlWriter_0.WriteElementString("Color_B", AreaColor.B.ToString());
			xmlWriter_0.WriteElementString("Layer", _PredicateReader.ToString());
			xmlWriter_0.WriteStartElement("Area");
			int num = Area.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				ReferencePoint referencePoint;
				try
				{
					referencePoint = Area[i];
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
					continue;
				}
				xmlWriter_0.WriteRaw(referencePoint.ToXML(ref hashSet_0));
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100993", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Zone FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		try
		{
			Zone zone = new Zone();
			byte alpha = 110;
			IEnumerator enumerator = null;
			byte? b = null;
			byte? b2 = null;
			byte? b3 = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "Area":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
								zone.Area.Add(ReferencePoint.FromXML(ref xmlNode_, ref concurrentDictionary_0));
							}
						}
						finally
						{
							if (enumerator2 is IDisposable)
							{
								(enumerator2 as IDisposable).Dispose();
							}
						}
						break;
					case "Color_G":
						b2 = XmlConvert.ToByte(xmlNode.InnerText);
						break;
					case "Color_B":
						b = XmlConvert.ToByte(xmlNode.InnerText);
						break;
					case "Color_A":
						alpha = XmlConvert.ToByte(xmlNode.InnerText);
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							zone.ObjectID_Set(xmlNode.InnerText);
							concurrentDictionary_0.TryAdd(zone.ObjectID, zone);
							break;
						}
						return (NoNavZone)concurrentDictionary_0[xmlNode.InnerText];
					case "Color_R":
						b3 = XmlConvert.ToByte(xmlNode.InnerText);
						break;
					case "Layer":
						zone._PredicateReader = XmlConvert.ToInt32(xmlNode.InnerText);
						break;
					case "Description":
						zone.Description = xmlNode.InnerText;
						break;
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			if (Information.IsNothing(b3))
			{
				zone.AreaColor = Color.Beige;
			}
			else
			{
				zone.AreaColor = Color.FromArgb(alpha, b3.Value, b2.Value, b.Value);
			}
			if (Information.IsNothing(zone.AffectedUnitTypes))
			{
				zone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>
				{
					GlobalVariables.ActiveUnitType.Aircraft,
					GlobalVariables.ActiveUnitType.Ship,
					GlobalVariables.ActiveUnitType.Submarine,
					GlobalVariables.ActiveUnitType.Facility
				};
			}
			return zone;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100994", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Zone result = new Zone();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private void ForgotDescriptor(object object_0, ObservableListModified<GlobalVariables.ActiveUnitType> observableListModified_0)
	{
		RateDescriptor();
	}

	private void CollectDescriptor(object object_0, ObservableListModified<GlobalVariables.ActiveUnitType> observableListModified_0)
	{
		RateDescriptor();
	}
}
