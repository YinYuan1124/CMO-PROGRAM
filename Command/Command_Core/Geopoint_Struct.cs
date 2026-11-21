using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public struct Geopoint_Struct : IEquatable<Geopoint_Struct>
{
	public double Longitude;

	public double Latitude;

	public float Altitude;

	[ThreadStatic]
	private static StringBuilder importerDic;

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

	public Geopoint_Struct(double double_0, double double_1)
	{
		this = default(Geopoint_Struct);
		Longitude = double_0;
		Latitude = double_1;
	}

	public Geopoint_Struct(double double_0, double double_1, float float_0)
	{
		this = default(Geopoint_Struct);
		Longitude = double_0;
		Latitude = double_1;
		Altitude = float_0;
	}

	internal GeoPoint DisableInvocation()
	{
		return new GeoPoint(Longitude, Latitude, Altitude);
	}

	public ReferencePoint ToReferencePoint()
	{
		return new ReferencePoint(Longitude, Latitude);
	}

	public float RangeToPoint_Horiz(double double_0, double double_1)
	{
		return Math2.VerifyClass(Latitude, Longitude, double_1, double_0);
	}

	public float RangeToPoint_Slant(Geopoint_Struct geopoint_Struct_0)
	{
		float num = Math2.VerifyClass(Latitude, Longitude, geopoint_Struct_0.Latitude, geopoint_Struct_0.Longitude);
		float num2 = (float)((double)Math.Abs(Altitude - geopoint_Struct_0.Altitude) / 1852.0);
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	internal float UpdateInvocation(Module_Unit.Unit unit_0)
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

	internal static Geopoint_Struct InsertInvocation(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		Geopoint_Struct result = default(Geopoint_Struct);
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
					case "Lon":
					case "Longitude":
						result.Longitude = XmlConvert.ToDouble(xmlNode.InnerText.Replace(",", "."));
						break;
					case "Lat":
					case "Latitude":
						result.Latitude = XmlConvert.ToDouble(xmlNode.InnerText.Replace(",", "."));
						break;
					case "Alt":
					case "Altitude":
						result.Altitude = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
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
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1032453245345634563456092839482347235847", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return default(Geopoint_Struct);
		}
	}

	public string ToXML(HashSet<string> hashSet_0)
	{
		try
		{
			if (importerDic == null)
			{
				importerDic = new StringBuilder();
			}
			else
			{
				importerDic.Clear();
			}
			importerDic.Append("<GPointStruct>");
			if (Longitude != 0.0)
			{
				importerDic.Append("<Lon>").Append(XmlConvert.ToString(Longitude)).Append("</Lon>");
			}
			if (Latitude != 0.0)
			{
				importerDic.Append("<Lat>").Append(XmlConvert.ToString(Latitude)).Append("</Lat>");
			}
			if (Altitude != 0f)
			{
				importerDic.Append("<Alt>").Append(XmlConvert.ToString(Altitude)).Append("</Alt>");
			}
			importerDic.Append("</GPointStruct>");
			return importerDic.ToString();
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

	internal bool PrepareInvocation(Scenario scenario_0)
	{
		return Terrain.GetElevation(Latitude, Longitude, bool_0: false, scenario_0) >= 0;
	}

	internal bool ReflectInvocation(Scenario scenario_0)
	{
		return Terrain.GetElevation(Latitude, Longitude, bool_0: false, scenario_0) < 0;
	}

	public bool Equals(Geopoint_Struct other)
	{
		if (Longitude == other.Longitude && Latitude == other.Latitude)
		{
			return Altitude == other.Altitude;
		}
		return false;
	}

	public static bool operator ==(Geopoint_Struct geopoint_Struct_0, Geopoint_Struct geopoint_Struct_1)
	{
		return geopoint_Struct_0.Equals(geopoint_Struct_1);
	}

	public static bool operator !=(Geopoint_Struct geopoint_Struct_0, Geopoint_Struct geopoint_Struct_1)
	{
		return !geopoint_Struct_0.Equals(geopoint_Struct_1);
	}
}
