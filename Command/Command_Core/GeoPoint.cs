using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Xml;
using CSMaterial;
using Easy.Common;
using ExWorldWind;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class GeoPoint : ScenarioObject, IGeopoint
{
	private double _FacadeDic;

	private double proxyDic;

	private float m_ReaderDic;

	[ThreadStatic]
	private static StringBuilder propertyDic;

	public double Longitude
	{
		get
		{
			return _FacadeDic;
		}
		set
		{
			if (value > 180.0 || value < -180.0)
			{
				value = Math2.VisitClass(value);
			}
			if (double.IsNaN(value))
			{
				_ = Debugger.IsAttached;
				value = 0.0;
			}
			_FacadeDic = value;
		}
	}

	public double Latitude
	{
		get
		{
			return proxyDic;
		}
		set
		{
			if (value > 90.0 || value < -90.0)
			{
				value = Math2.ReflectClass(value);
			}
			if (double.IsNaN(value))
			{
				_ = Debugger.IsAttached;
				value = 0.0;
			}
			proxyDic = value;
		}
	}

	public float Altitude
	{
		get
		{
			return m_ReaderDic;
		}
		set
		{
			m_ReaderDic = value;
		}
	}

	public string ToXML(HashSet<string> hashSet_0)
	{
		try
		{
			if (propertyDic == null)
			{
				propertyDic = new StringBuilder();
			}
			else
			{
				propertyDic.Clear();
			}
			propertyDic.Append("<GPoint>");
			if (string.IsNullOrEmpty(ObjectID))
			{
				ObjectID = IDGenerator.Instance.Next;
			}
			propertyDic.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (hashSet_0 != null)
			{
				if (hashSet_0.Contains(ObjectID))
				{
					propertyDic.Append("</GPoint>");
					return propertyDic.ToString();
				}
				hashSet_0.Add(ObjectID);
			}
			if (_FacadeDic != 0.0)
			{
				propertyDic.Append("<Lon>").Append(XmlConvert.ToString(_FacadeDic)).Append("</Lon>");
			}
			if (proxyDic != 0.0)
			{
				propertyDic.Append("<Lat>").Append(XmlConvert.ToString(proxyDic)).Append("</Lat>");
			}
			if (m_ReaderDic != 0f)
			{
				propertyDic.Append("<Alt>").Append(XmlConvert.ToString(m_ReaderDic)).Append("</Alt>");
			}
			if (!string.IsNullOrEmpty(Name))
			{
				propertyDic.Append("<Name>").Append(SecurityElement.Escape(Name)).Append("</Name>");
			}
			propertyDic.Append("</GPoint>");
			return propertyDic.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100572", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static GeoPoint FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		GeoPoint geoPoint = new GeoPoint();
		try
		{
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							geoPoint.ObjectID_Set(xmlNode.InnerText);
							concurrentDictionary_0.TryAdd(geoPoint.ObjectID, geoPoint);
							break;
						}
						return (GeoPoint)concurrentDictionary_0[xmlNode.InnerText];
					case "Name":
						geoPoint.Name = xmlNode.InnerText;
						break;
					case "Alt":
					case "Altitude":
						geoPoint.m_ReaderDic = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
						break;
					case "Latitude":
					case "Lat":
						FastDoubleParse.FastTryParseDouble(xmlNode.InnerText.Replace(",", "."), out geoPoint.proxyDic);
						break;
					case "Longitude":
					case "Lon":
						FastDoubleParse.FastTryParseDouble(xmlNode.InnerText.Replace(",", "."), out geoPoint._FacadeDic);
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
			return geoPoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100573", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[SpecialName]
	public float GetAltitude_AGL(Scenario scenario_0)
	{
		return Altitude - (float)Terrain.GetElevation(Latitude, Longitude, bool_0: false, scenario_0);
	}

	public GeoPoint(bool bool_0 = true)
		: base(bool_0)
	{
		Name = "";
	}

	public GeoPoint(double double_0, double double_1, bool bool_0 = true)
		: base(bool_0)
	{
		_FacadeDic = double_0;
		proxyDic = double_1;
		Name = "";
	}

	public GeoPoint(double double_0, double double_1, float float_0, bool bool_0 = true)
		: base(bool_0)
	{
		_FacadeDic = double_0;
		proxyDic = double_1;
		m_ReaderDic = float_0;
		Name = "";
	}

	[SpecialName]
	public bool GetIsOverLand(Scenario scenario_0)
	{
		return Terrain.GetElevation(proxyDic, _FacadeDic, bool_0: false, scenario_0) >= 0;
	}

	[SpecialName]
	public bool GetIsAtSea(Scenario scenario_0)
	{
		return Terrain.GetElevation(proxyDic, _FacadeDic, bool_0: false, scenario_0) < 0;
	}

	public float RangeToPoint_Horiz(double double_0, double double_1)
	{
		return Math2.VerifyClass(proxyDic, _FacadeDic, double_1, double_0);
	}

	public float RangeToUnit_Horiz(Module_Unit.Unit unit_0)
	{
		return Math2.VerifyClass(proxyDic, _FacadeDic, unit_0.GetLatitude(), unit_0.GetLongitude());
	}

	public float RangeToPoint_Slant(Geopoint_Struct geopoint_Struct_0)
	{
		float num = Math2.VerifyClass(Latitude, Longitude, geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude);
		float num2 = (float)((double)Math.Abs(Altitude - geopoint_Struct_0.Altitude) / 1852.0);
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public float RangeToPoint_Slant(GeoPoint geoPoint_0)
	{
		float num = Math2.VerifyClass(Latitude, Longitude, geoPoint_0.Latitude, geoPoint_0.Longitude);
		float num2 = (float)((double)Math.Abs(Altitude - geoPoint_0.Altitude) / 1852.0);
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static double RangeToPoint_Horiz_Angular(double double_0, double double_1, double double_2, double double_3)
	{
		try
		{
			Angle angle_ = default(Angle);
			Angle angle_2 = default(Angle);
			Angle angle_3 = default(Angle);
			Angle angle_4 = default(Angle);
			angle_.Degrees = double_1;
			angle_2.Degrees = double_0;
			angle_3.Degrees = double_3;
			angle_4.Degrees = double_2;
			return World.ApproxAngularDistance(angle_, angle_2, angle_3, angle_4).Degrees;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10032453245234", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0.0;
		}
	}

	public double RangeToPoint_Horiz_Angular(double double_0, double double_1)
	{
		try
		{
			Angle angle_ = default(Angle);
			Angle angle_2 = default(Angle);
			Angle angle_3 = default(Angle);
			Angle angle_4 = default(Angle);
			angle_.Degrees = Latitude;
			angle_2.Degrees = Longitude;
			angle_3.Degrees = double_1;
			angle_4.Degrees = double_0;
			return World.ApproxAngularDistance(angle_, angle_2, angle_3, angle_4).Degrees;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100574", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return 0.0;
	}

	public ReferencePoint ToReferencePoint()
	{
		return new ReferencePoint(Longitude, Latitude);
	}

	public static bool AreaHasChanged(List<GeoPoint> list_0, List<GeoPoint> list_1)
	{
		try
		{
			if (Information.IsNothing(list_1))
			{
				return true;
			}
			if (list_0.Count == list_1.Count)
			{
				int num = list_0.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (list_0[i].Latitude != list_1[i].Latitude || list_0[i].Longitude != list_1[i].Longitude)
					{
						return true;
					}
				}
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200565", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal float InstantiateInvocation(Module_Unit.Unit unit_0)
	{
		float result = 0f;
		try
		{
			float currentHeading = unit_0.CurrentHeading;
			float num = Math2.PublishClass(unit_0.GetLatitude(), unit_0.GetLongitude(), Latitude, Longitude);
			num = Math2.UpdateClass(num - currentHeading);
			currentHeading = 0f;
			if (num <= 180f)
			{
				result = num;
				return result;
			}
			result = 0f - (360f - num);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100575", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static bool IsInsideThisArea(double double_0, double double_1, List<GeoPoint> list_0, List<GeoPoint> list_1, float float_0)
	{
		if (list_0 == null)
		{
			return false;
		}
		if (list_0.Count == 0)
		{
			return false;
		}
		bool result = false;
		try
		{
			if (float_0 == 0f)
			{
				return result = IsInsideThisArea(double_0, double_1, list_0);
			}
			ActiveUnit_Navigator.CalculateAreaWithThresholdAdded_NM(float_0, ref list_0, ref list_1);
			return result = IsInsideThisArea(double_0, double_1, list_1);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101261", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static bool IsInsideThisArea(double double_0, double double_1, GeoPoint[] geoPoint_0, bool bool_0 = true)
	{
		try
		{
			if (geoPoint_0 == null)
			{
				return false;
			}
			if (geoPoint_0.Length < 3)
			{
				return false;
			}
			if (bool_0)
			{
				if (Math2.PolygonCrossesAntimeridian(geoPoint_0))
				{
					Geopoint_Struct geopoint_Struct = new Geopoint_Struct(Math2.VisitClass(double_1 + 180.0), double_0);
					Geopoint_Struct[] array = new Geopoint_Struct[geoPoint_0.Count() - 1 + 1];
					int num = geoPoint_0.Count() - 1;
					for (int i = 0; i <= num; i++)
					{
						array[i] = new Geopoint_Struct(Math2.VisitClass(geoPoint_0[i].Longitude + 180.0), geoPoint_0[i].Latitude);
					}
					return PointInPolygon(geopoint_Struct.Latitude, geopoint_Struct.Longitude, array);
				}
				return PointInPolygon(double_0, double_1, geoPoint_0);
			}
			return PointInPolygon(double_0, double_1, geoPoint_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1005761234902349534757", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public static bool IsInsideThisArea(double double_0, double double_1, Geopoint_Struct[] geopoint_Struct_0, bool bool_0 = true)
	{
		try
		{
			if (Information.IsNothing(geopoint_Struct_0))
			{
				return false;
			}
			if (geopoint_Struct_0.Length < 3)
			{
				return false;
			}
			if (bool_0)
			{
				if (Math2.PolygonCrossesAntimeridian(geopoint_Struct_0))
				{
					Geopoint_Struct geopoint_Struct = new Geopoint_Struct(Math2.VisitClass(double_1 + 180.0), double_0);
					Geopoint_Struct[] array = new Geopoint_Struct[geopoint_Struct_0.Length - 1 + 1];
					int num = geopoint_Struct_0.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						array[i] = new Geopoint_Struct(Math2.VisitClass(geopoint_Struct_0[i].Longitude + 180.0), geopoint_Struct_0[i].Latitude);
					}
					return PointInPolygon(geopoint_Struct.Latitude, geopoint_Struct.Longitude, array);
				}
				return PointInPolygon(double_0, double_1, geopoint_Struct_0);
			}
			return PointInPolygon(double_0, double_1, geopoint_Struct_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10057342098690566", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public static bool IsInsideThisArea(double double_0, double double_1, List<Geopoint_Struct> list_0, bool bool_0 = true)
	{
		try
		{
			if (Information.IsNothing(list_0))
			{
				return false;
			}
			if (list_0.Count < 3)
			{
				return false;
			}
			if (bool_0)
			{
				if (Math2.PolygonCrossesAntimeridian(list_0))
				{
					Geopoint_Struct geopoint_Struct = new Geopoint_Struct(Math2.VisitClass(double_1 + 180.0), double_0);
					Geopoint_Struct[] array = new Geopoint_Struct[list_0.Count - 1 + 1];
					int num = list_0.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						array[i] = new Geopoint_Struct(Math2.VisitClass(list_0[i].Longitude + 180.0), list_0[i].Latitude);
					}
					return PointInPolygon(geopoint_Struct.Latitude, geopoint_Struct.Longitude, array);
				}
				return PointInPolygon(double_0, double_1, list_0);
			}
			return PointInPolygon(double_0, double_1, list_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100576", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public static bool IsInsideThisArea(double double_0, double double_1, List<GeoPoint> list_0, bool bool_0 = true)
	{
		try
		{
			if (Information.IsNothing(list_0))
			{
				return false;
			}
			if (list_0.Count < 3)
			{
				return false;
			}
			if (bool_0)
			{
				if (Math2.PolygonCrossesAntimeridian(list_0))
				{
					Geopoint_Struct geopoint_Struct = new Geopoint_Struct(Math2.VisitClass(double_1 + 180.0), double_0);
					Geopoint_Struct[] array = new Geopoint_Struct[list_0.Count - 1 + 1];
					int num = list_0.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						array[i] = new Geopoint_Struct(Math2.VisitClass(list_0[i].Longitude + 180.0), list_0[i].Latitude);
					}
					return PointInPolygon(geopoint_Struct.Latitude, geopoint_Struct.Longitude, array);
				}
				return PointInPolygon(double_0, double_1, list_0);
			}
			return PointInPolygon(double_0, double_1, list_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100576", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public static bool IsInsideThisArea(double double_0, double double_1, List<ReferencePoint> list_0, bool bool_0 = true)
	{
		bool result = false;
		try
		{
			if (Information.IsNothing(list_0))
			{
				result = false;
				return false;
			}
			if (list_0.Count < 3)
			{
				result = false;
				return false;
			}
			if (bool_0)
			{
				if (Math2.PolygonCrossesAntimeridian(ref list_0))
				{
					Geopoint_Struct geopoint_Struct = new Geopoint_Struct(Math2.VisitClass(double_1 + 180.0), double_0);
					Geopoint_Struct[] array = new Geopoint_Struct[list_0.Count - 1 + 1];
					int num = list_0.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						array[i] = new Geopoint_Struct(Math2.VisitClass(list_0[i].Longitude + 180.0), list_0[i].Latitude);
					}
					return result = PointInPolygon(geopoint_Struct.Latitude, geopoint_Struct.Longitude, array);
				}
				return result = PointInPolygon(double_0, double_1, list_0);
			}
			return result = PointInPolygon(double_0, double_1, list_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100577", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static bool PointInPolygon(double double_0, double double_1, List<ReferencePoint> list_0)
	{
		if (list_0.Count < 3)
		{
			return false;
		}
		Geodesic_Vincenty.PointD[] array = new Geodesic_Vincenty.PointD[list_0.Count - 1 + 1];
		double num = -90.0;
		double num2 = 90.0;
		double num3 = 180.0;
		double num4 = -180.0;
		int count = list_0.Count;
		int num5 = count - 1;
		for (int i = 0; i <= num5; i++)
		{
			ReferencePoint referencePoint = list_0[i];
			if (referencePoint != null)
			{
				double latitude = referencePoint.Latitude;
				double longitude = referencePoint.Longitude;
				if (latitude > num)
				{
					num = latitude;
				}
				if (latitude < num2)
				{
					num2 = latitude;
				}
				if (longitude > num4)
				{
					num4 = longitude;
				}
				if (longitude < num3)
				{
					num3 = longitude;
				}
			}
		}
		if (double_0 <= num)
		{
			if (double_0 < num2)
			{
				return false;
			}
			if (double_1 <= num4)
			{
				if (double_1 < num3)
				{
					return false;
				}
				int num6 = 0;
				MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(double_1, double_0);
				double y = mercatorPixel.y;
				double x = mercatorPixel.x;
				int num7 = count - 1;
				for (int j = 0; j <= num7; j++)
				{
					ReferencePoint referencePoint2 = list_0[j];
					MercatorProjection.MercatorPixel mercatorPixel2 = new MercatorProjection.MercatorPixel(referencePoint2.Longitude, referencePoint2.Latitude);
					array[j] = new Geodesic_Vincenty.PointD(mercatorPixel2.x, mercatorPixel2.y);
				}
				int num8 = count - 1;
				for (int k = 0; k <= num8; k++)
				{
					Geodesic_Vincenty.PointD pointD = array[k];
					double y2 = pointD.Y;
					double x2 = pointD.X;
					Geodesic_Vincenty.PointD obj = ((k == count - 1) ? array[0] : array[k + 1]);
					double y3 = obj.Y;
					double x3 = obj.X;
					if (y2 <= y)
					{
						if (y3 > y && CreateInvocation(x2, y2, x3, y3, x, y) > 0)
						{
							num6++;
						}
					}
					else if (y3 <= y && CreateInvocation(x2, y2, x3, y3, x, y) < 0)
					{
						num6--;
					}
				}
				if (num6 == 0)
				{
					return false;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public static bool PointInPolygon_Vincenty(double double_0, double double_1, List<ReferencePoint> list_0)
	{
		if (list_0.Count < 3)
		{
			return false;
		}
		Geodesic_Vincenty.PointD[] array = new Geodesic_Vincenty.PointD[list_0.Count - 1 + 1];
		bool result = false;
		try
		{
			double num = -90.0;
			double num2 = 90.0;
			double num3 = 180.0;
			double num4 = -180.0;
			int num5 = list_0.Count - 1;
			for (int i = 0; i <= num5; i++)
			{
				ReferencePoint referencePoint = list_0[i];
				double latitude = referencePoint.Latitude;
				double longitude = referencePoint.Longitude;
				if (latitude > num)
				{
					num = latitude;
				}
				if (latitude < num2)
				{
					num2 = latitude;
				}
				if (longitude > num4)
				{
					num4 = longitude;
				}
				if (longitude < num3)
				{
					num3 = longitude;
				}
			}
			if (double_0 <= num)
			{
				if (double_0 < num2)
				{
					result = false;
					return false;
				}
				if (double_1 <= num4)
				{
					if (double_1 < num3)
					{
						result = false;
						return false;
					}
					int num6 = 0;
					Geodesic_Vincenty.TLocalTM tLocalTM = new Geodesic_Vincenty.TLocalTM(double_0, double_1);
					Geodesic_Vincenty.PointD pointD_ = new Geodesic_Vincenty.PointD(double_1, double_0);
					Geodesic_Vincenty.PointD pointD = tLocalTM.DestroyInterruptibleQueue(ref pointD_);
					double y = pointD.Y;
					double x = pointD.X;
					int num7 = list_0.Count - 1;
					for (int j = 0; j <= num7; j++)
					{
						ReferencePoint referencePoint2 = list_0[j];
						pointD_ = new Geodesic_Vincenty.PointD(referencePoint2.Longitude, referencePoint2.Latitude);
						array[j] = tLocalTM.DestroyInterruptibleQueue(ref pointD_, bool_0: true);
					}
					int num8 = array.Length;
					int num9 = list_0.Count - 1;
					for (int k = 0; k <= num9; k++)
					{
						Geodesic_Vincenty.PointD pointD2 = array[k];
						double y2 = pointD2.Y;
						double x2 = pointD2.X;
						Geodesic_Vincenty.PointD obj = ((k == num8 - 1) ? array[0] : array[k + 1]);
						double y3 = obj.Y;
						double x3 = obj.X;
						if (y2 <= y)
						{
							if (y3 > y && CreateInvocation(x2, y2, x3, y3, x, y) > 0)
							{
								num6++;
							}
						}
						else if (y3 <= y && CreateInvocation(x2, y2, x3, y3, x, y) < 0)
						{
							num6--;
						}
					}
					if (num6 == 0)
					{
						result = false;
						return false;
					}
					result = true;
					return true;
				}
				result = false;
				return false;
			}
			result = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100578", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static bool PointInPolygon(double double_0, double double_1, GeoPoint[] geoPoint_0)
	{
		bool result = false;
		try
		{
			int num = geoPoint_0.Length;
			int num2 = num - 1;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			for (int i = 0; i <= num2; i++)
			{
				GeoPoint obj = geoPoint_0[i];
				double latitude = obj.Latitude;
				double longitude = obj.Longitude;
				if (latitude > num3)
				{
					num3 = latitude;
				}
				if (latitude < num4)
				{
					num4 = latitude;
				}
				if (longitude > num5)
				{
					num5 = longitude;
				}
				if (longitude < num6)
				{
					num6 = longitude;
				}
			}
			if (double_0 <= num3)
			{
				if (double_0 < num4)
				{
					result = false;
					return false;
				}
				if (double_1 <= num5)
				{
					if (double_1 < num6)
					{
						result = false;
						return false;
					}
					GeoPoint geoPoint = geoPoint_0[num - 1];
					int num7 = 0;
					int num8 = num - 1;
					for (int j = 0; j <= num8; j++)
					{
						GeoPoint geoPoint2 = geoPoint_0[j];
						GeoPoint obj2 = ((geoPoint2 == geoPoint) ? geoPoint_0[0] : geoPoint_0[j + 1]);
						double latitude2 = geoPoint2.Latitude;
						double longitude2 = geoPoint2.Longitude;
						double latitude3 = obj2.Latitude;
						double longitude3 = obj2.Longitude;
						if (latitude2 <= double_0)
						{
							if (latitude3 > double_0 && CreateInvocation(longitude2, latitude2, longitude3, latitude3, double_1, double_0) > 0)
							{
								num7++;
							}
						}
						else if (latitude3 <= double_0 && CreateInvocation(longitude2, latitude2, longitude3, latitude3, double_1, double_0) < 0)
						{
							num7--;
						}
					}
					if (num7 == 0)
					{
						result = false;
						return false;
					}
					result = true;
					return true;
				}
				result = false;
				return false;
			}
			result = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100579324598439688822", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static bool PointInPolygon(double double_0, double double_1, List<Geopoint_Struct> list_0)
	{
		bool result = false;
		try
		{
			int count = list_0.Count;
			int num = count - 1;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			for (int i = 0; i <= num; i++)
			{
				Geopoint_Struct geopoint_Struct = list_0[i];
				double latitude = geopoint_Struct.Latitude;
				double longitude = geopoint_Struct.Longitude;
				if (latitude > num2)
				{
					num2 = latitude;
				}
				if (latitude < num3)
				{
					num3 = latitude;
				}
				if (longitude > num4)
				{
					num4 = longitude;
				}
				if (longitude < num5)
				{
					num5 = longitude;
				}
			}
			if (double_0 <= num2)
			{
				if (double_0 < num3)
				{
					result = false;
					return false;
				}
				if (double_1 <= num4)
				{
					if (double_1 < num5)
					{
						result = false;
						return false;
					}
					_ = list_0[count - 1];
					int num6 = 0;
					int num7 = count - 1;
					for (int j = 0; j <= num7; j++)
					{
						Geopoint_Struct geopoint_Struct2 = list_0[j];
						Geopoint_Struct obj = ((j == count - 1) ? list_0[0] : list_0[j + 1]);
						double latitude2 = geopoint_Struct2.Latitude;
						double longitude2 = geopoint_Struct2.Longitude;
						double latitude3 = obj.Latitude;
						double longitude3 = obj.Longitude;
						if (latitude2 <= double_0)
						{
							if (latitude3 > double_0 && CreateInvocation(longitude2, latitude2, longitude3, latitude3, double_1, double_0) > 0)
							{
								num6++;
							}
						}
						else if (latitude3 <= double_0 && CreateInvocation(longitude2, latitude2, longitude3, latitude3, double_1, double_0) < 0)
						{
							num6--;
						}
					}
					if (num6 == 0)
					{
						result = false;
						return false;
					}
					result = true;
					return true;
				}
				result = false;
				return false;
			}
			result = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1324905734958712934518357", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static bool PointInPolygon(double double_0, double double_1, Geopoint_Struct[] geopoint_Struct_0)
	{
		bool result = false;
		try
		{
			int num = geopoint_Struct_0.Length;
			int num2 = num - 1;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			for (int i = 0; i <= num2; i++)
			{
				Geopoint_Struct geopoint_Struct = geopoint_Struct_0[i];
				double latitude = geopoint_Struct.Latitude;
				double longitude = geopoint_Struct.Longitude;
				if (latitude > num3)
				{
					num3 = latitude;
				}
				if (latitude < num4)
				{
					num4 = latitude;
				}
				if (longitude > num5)
				{
					num5 = longitude;
				}
				if (longitude < num6)
				{
					num6 = longitude;
				}
			}
			if (double_0 <= num3)
			{
				if (double_0 < num4)
				{
					result = false;
					return false;
				}
				if (double_1 <= num5)
				{
					if (double_1 < num6)
					{
						result = false;
						return false;
					}
					int num7 = 0;
					int num8 = num - 1;
					for (int j = 0; j <= num8; j++)
					{
						Geopoint_Struct geopoint_Struct2 = geopoint_Struct_0[j];
						Geopoint_Struct obj = ((j == num - 1) ? geopoint_Struct_0[0] : geopoint_Struct_0[j + 1]);
						double latitude2 = geopoint_Struct2.Latitude;
						double longitude2 = geopoint_Struct2.Longitude;
						double latitude3 = obj.Latitude;
						double longitude3 = obj.Longitude;
						if (latitude2 <= double_0)
						{
							if (latitude3 > double_0 && CreateInvocation(longitude2, latitude2, longitude3, latitude3, double_1, double_0) > 0)
							{
								num7++;
							}
						}
						else if (latitude3 <= double_0 && CreateInvocation(longitude2, latitude2, longitude3, latitude3, double_1, double_0) < 0)
						{
							num7--;
						}
					}
					if (num7 == 0)
					{
						result = false;
						return false;
					}
					result = true;
					return true;
				}
				result = false;
				return false;
			}
			result = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100579324598421345103249502349591", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static bool PointInPolygon(double double_0, double double_1, List<GeoPoint> list_0)
	{
		bool result = false;
		try
		{
			int count = list_0.Count;
			int num = count - 1;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			for (int i = 0; i <= num; i++)
			{
				GeoPoint geoPoint = list_0[i];
				if (geoPoint != null)
				{
					double latitude = geoPoint.Latitude;
					double longitude = geoPoint.Longitude;
					if (latitude > num2)
					{
						num2 = latitude;
					}
					if (latitude < num3)
					{
						num3 = latitude;
					}
					if (longitude > num4)
					{
						num4 = longitude;
					}
					if (longitude < num5)
					{
						num5 = longitude;
					}
				}
			}
			if (double_0 <= num2)
			{
				if (double_0 < num3)
				{
					result = false;
					return false;
				}
				if (double_1 <= num4)
				{
					if (double_1 < num5)
					{
						result = false;
						return false;
					}
					GeoPoint geoPoint2 = list_0[count - 1];
					int num6 = 0;
					int num7 = count - 1;
					for (int j = 0; j <= num7; j++)
					{
						GeoPoint geoPoint3 = list_0[j];
						if (geoPoint3 == null)
						{
							continue;
						}
						GeoPoint geoPoint4;
						if (geoPoint3 == geoPoint2)
						{
							geoPoint4 = list_0[0];
							if (geoPoint4 == null)
							{
								geoPoint4 = list_0[1];
							}
						}
						else
						{
							geoPoint4 = list_0[j + 1];
							if (geoPoint4 == null)
							{
								geoPoint4 = list_0[j + 2];
							}
						}
						if (geoPoint4 != null)
						{
							double latitude2 = geoPoint3.Latitude;
							double longitude2 = geoPoint3.Longitude;
							double latitude3 = geoPoint4.Latitude;
							double longitude3 = geoPoint4.Longitude;
							if (latitude2 <= double_0)
							{
								if (latitude3 > double_0 && CreateInvocation(longitude2, latitude2, longitude3, latitude3, double_1, double_0) > 0)
								{
									num6++;
								}
							}
							else if (latitude3 <= double_0 && CreateInvocation(longitude2, latitude2, longitude3, latitude3, double_1, double_0) < 0)
							{
								num6--;
							}
							continue;
						}
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						result = false;
						return false;
					}
					if (num6 == 0)
					{
						result = false;
						return false;
					}
					result = true;
					return true;
				}
				result = false;
				return false;
			}
			result = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100579", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static bool PointInPolygon(ref double double_0, ref double double_1, ref double[] double_2, ref double[] double_3)
	{
		bool result = false;
		try
		{
			int num = double_2.Length;
			double num2 = double_0;
			double double_4 = double_1;
			int num3 = 0;
			int num4 = num - 1;
			for (int i = 0; i <= num4; i++)
			{
				double num5 = double_3[i];
				double double_5 = double_2[i];
				double num6;
				double double_6;
				if (i == num - 1)
				{
					num6 = double_3[0];
					double_6 = double_2[0];
				}
				else
				{
					num6 = double_3[i + 1];
					double_6 = double_2[i + 1];
				}
				if (num5 <= num2)
				{
					if (num6 > num2 && CreateInvocation(double_5, num5, double_6, num6, double_4, num2) > 0)
					{
						num3++;
					}
				}
				else if (num6 <= num2 && CreateInvocation(double_5, num5, double_6, num6, double_4, num2) < 0)
				{
					num3--;
				}
			}
			if (num3 == 0)
			{
				result = false;
				return false;
			}
			result = true;
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100580", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private static int CreateInvocation(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5)
	{
		int result = 0;
		try
		{
			double num = (double_2 - double_0) * (double_5 - double_1) - (double_4 - double_0) * (double_3 - double_1);
			if (num <= 0.0)
			{
				if (num < 0.0)
				{
					result = -1;
					return -1;
				}
				result = 0;
				return 0;
			}
			result = 1;
			return 1;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100581", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private static int CompareInvocation(GeoPoint geoPoint_0, GeoPoint geoPoint_1, GeoPoint geoPoint_2)
	{
		int result = 0;
		try
		{
			double longitude = geoPoint_0.Longitude;
			double latitude = geoPoint_0.Latitude;
			double longitude2 = geoPoint_1.Longitude;
			double latitude2 = geoPoint_1.Latitude;
			double longitude3 = geoPoint_2.Longitude;
			double latitude3 = geoPoint_2.Latitude;
			double num = (longitude2 - longitude) * (latitude3 - latitude) - (longitude3 - longitude) * (latitude2 - latitude);
			if (num <= 0.0)
			{
				if (num < 0.0)
				{
					result = -1;
					return -1;
				}
				result = 0;
				return 0;
			}
			result = 1;
			return 1;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100582", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static bool IsInPierLane(double double_0, double double_1, Scenario scenario_0)
	{
		if (scenario_0.Cache_FacilitiesWithPiers.Count == 0)
		{
			return false;
		}
		try
		{
			int num = scenario_0.Cache_FacilitiesWithPiers.Count - 1;
			while (true)
			{
				if (num >= 0)
				{
					ActiveUnit activeUnit = scenario_0.Cache_FacilitiesWithPiers[num];
					double num2 = Math2.TestClass(activeUnit.DockingOps.PierLaneLength);
					if (double_0 <= activeUnit.GetLatitude() + num2 && double_0 >= activeUnit.GetLatitude() - num2 && Module_Unit.RangeToPoint_Horiz(activeUnit, double_0, double_1) <= activeUnit.DockingOps.PierLaneLength && IsInsideThisArea(double_0, double_1, activeUnit.DockingOps.PierEntranceLane, bool_0: false))
					{
						break;
					}
					num += -1;
					continue;
				}
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200462", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[SpecialName]
	public static bool GetIsInCanal(double double_0, double double_1)
	{
		bool result = false;
		try
		{
			if (CanalHandler.PrepareProperty().GetPointIsInArea(double_0, double_1, bool_0: false))
			{
				result = true;
				return true;
			}
			if (CanalHandler.InsertProperty().GetPointIsInArea(double_0, double_1, bool_0: false))
			{
				result = true;
				return true;
			}
			if (CanalHandler.ReflectProperty().GetPointIsInArea(double_0, double_1, bool_0: false))
			{
				result = true;
				return true;
			}
			if (CanalHandler.VisitProperty().GetPointIsInArea(double_0, double_1, bool_0: false))
			{
				result = true;
				return true;
			}
			result = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100583", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static GeoPoint GetNewPoint(GeoPoint geoPoint_0, float float_0, float float_1)
	{
		GeoPoint geoPoint = new GeoPoint();
		double longitude = geoPoint_0.Longitude;
		double latitude = geoPoint_0.Latitude;
		GeoPoint geoPoint2;
		double double_ = (geoPoint2 = geoPoint).Longitude;
		double double_2 = geoPoint.Latitude;
		Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_, ref double_2, float_1, float_0);
		geoPoint.Latitude = double_2;
		geoPoint2.Longitude = double_;
		return geoPoint;
	}

	public static GeoPoint GetNewPoint(double double_0, double double_1, float float_0, float float_1)
	{
		GeoPoint geoPoint = new GeoPoint();
		GeoPoint geoPoint2;
		double double_2 = (geoPoint2 = geoPoint).Longitude;
		double double_3 = geoPoint.Latitude;
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_2, ref double_3, float_1, float_0);
		geoPoint.Latitude = double_3;
		geoPoint2.Longitude = double_2;
		return geoPoint;
	}

	public static Geopoint_Struct GetNewPoint_Struct(double double_0, double double_1, float float_0, float float_1)
	{
		Geopoint_Struct result = default(Geopoint_Struct);
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref result.Longitude, ref result.Latitude, float_1, float_0);
		return result;
	}

	internal Geopoint_Struct ReadInvocation()
	{
		return new Geopoint_Struct(Longitude, Latitude, Altitude);
	}
}
