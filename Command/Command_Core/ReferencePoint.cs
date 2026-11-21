using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Security;
using System.Text;
using System.Xml;
using Easy.Common;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class ReferencePoint : GeoPoint
{
	public enum OrientationType : byte
	{
		Fixed,
		Rotating
	}

	private bool m_ProcConsumer;

	private ScenarioObject _StructFacade;

	internal string _MerchantFacade;

	public float RelativeBearing;

	private float _CallbackFacade;

	public OrientationType BearingType;

	public bool IsLocked;

	public Dictionary<ReferencePointFlag, ReferencePointFlag> Tags;

	public Dictionary<string, string> TagsByGuid_Raw;

	public Color color;

	public ReferencePoint_Group RenderGroup;

	public DateTime? CreationDate;

	public DateTime? Expiration;

	public bool Fades;

	public bool ForceMinimize;

	[ThreadStatic]
	private static StringBuilder decoratorFacade;

	public ScenarioObject IsRelativeTo
	{
		get
		{
			return _StructFacade;
		}
		set
		{
			_StructFacade = value;
		}
	}

	public float RelativeDistance
	{
		get
		{
			return _CallbackFacade;
		}
		set
		{
			_CallbackFacade = value;
		}
	}

	public bool IsHighlighted
	{
		get
		{
			return m_ProcConsumer;
		}
		set
		{
			m_ProcConsumer = value;
		}
	}

	public string ToXML(ref HashSet<string> hashSet_0)
	{
		string result = null;
		try
		{
			if (decoratorFacade == null)
			{
				decoratorFacade = new StringBuilder();
			}
			else
			{
				decoratorFacade.Clear();
			}
			decoratorFacade.Append("<RPoint>");
			if (string.IsNullOrEmpty(ObjectID))
			{
				ObjectID = IDGenerator.Instance.Next;
			}
			decoratorFacade.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (hashSet_0 != null)
			{
				if (hashSet_0.Contains(ObjectID))
				{
					decoratorFacade.Append("</RPoint>");
					result = decoratorFacade.ToString();
					return result;
				}
				hashSet_0.Add(ObjectID);
			}
			decoratorFacade.Append("<Lon>").Append(XmlConvert.ToString(base.Longitude)).Append("</Lon>");
			decoratorFacade.Append("<Lat>").Append(XmlConvert.ToString(base.Latitude)).Append("</Lat>");
			if (base.Altitude != 0f)
			{
				decoratorFacade.Append("<Alt>").Append(XmlConvert.ToString(base.Altitude)).Append("</Alt>");
			}
			decoratorFacade.Append("<Name>").Append(SecurityElement.Escape(Name)).Append("</Name>");
			if (m_ProcConsumer)
			{
				decoratorFacade.Append("<IH>True</IH>");
			}
			if (!Information.IsNothing(IsRelativeTo))
			{
				decoratorFacade.Append("<IRT>").Append(IsRelativeTo.ObjectID).Append("</IRT>");
				decoratorFacade.Append("<RB>").Append(XmlConvert.ToString(RelativeBearing)).Append("</RB>");
				decoratorFacade.Append("<RD>").Append(XmlConvert.ToString(RelativeDistance)).Append("</RD>");
			}
			if (BearingType != 0)
			{
				StringBuilder stringBuilder = decoratorFacade.Append("<BT>");
				byte bearingType = (byte)BearingType;
				stringBuilder.Append(bearingType.ToString()).Append("</BT>");
			}
			decoratorFacade.Append("<ColorR>").Append(XmlConvert.ToString(color.R)).Append("</ColorR>");
			decoratorFacade.Append("<ColorG>").Append(XmlConvert.ToString(color.G)).Append("</ColorG>");
			decoratorFacade.Append("<ColorB>").Append(XmlConvert.ToString(color.B)).Append("</ColorB>");
			if (Tags.Count > 0)
			{
				foreach (ReferencePointFlag key in Tags.Keys)
				{
					decoratorFacade.Append("<Tag>").Append(key.ObjectID).Append("</Tag>");
				}
			}
			if (IsLocked)
			{
				decoratorFacade.Append("<IsLocked>True</IsLocked>");
			}
			if (CreationDate.HasValue)
			{
				decoratorFacade.Append("<CreationDate>" + CreationDate.Value.ToBinary() + "</CreationDate>");
			}
			if (Expiration.HasValue)
			{
				decoratorFacade.Append("<Expiration>" + Expiration.Value.ToBinary() + "</Expiration>");
			}
			if (Fades)
			{
				decoratorFacade.Append("<Fades>True</Fades>");
			}
			if (ForceMinimize)
			{
				decoratorFacade.Append("<ForceMinimize>True</ForceMinimize>");
			}
			decoratorFacade.Append("<RGroup>").Append(((byte)RenderGroup).ToString()).Append("</RGroup>");
			decoratorFacade.Append("</RPoint>");
			result = decoratorFacade.ToString();
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100584", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public new static ReferencePoint FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		try
		{
			ReferencePoint referencePoint = new ReferencePoint();
			byte red = byte.MaxValue;
			byte green = byte.MaxValue;
			byte blue = byte.MaxValue;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "Expiration":
						referencePoint.Expiration = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
						break;
					case "BT":
						referencePoint.BearingType = (OrientationType)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "Name":
						referencePoint.Name = xmlNode.InnerText;
						break;
					case "IsLocked":
						referencePoint.IsLocked = true;
						break;
					case "ColorR":
						red = XmlConvert.ToByte(xmlNode.InnerText);
						break;
					case "ColorG":
						green = XmlConvert.ToByte(xmlNode.InnerText);
						break;
					case "ID":
						if (Information.IsNothing(concurrentDictionary_0) || !concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							referencePoint.ObjectID_Set(xmlNode.InnerText);
							if (!Information.IsNothing(concurrentDictionary_0))
							{
								concurrentDictionary_0.TryAdd(referencePoint.ObjectID, referencePoint);
							}
							break;
						}
						return (ReferencePoint)concurrentDictionary_0[xmlNode.InnerText];
					case "ColorB":
						blue = XmlConvert.ToByte(xmlNode.InnerText);
						break;
					case "RelativeDistance":
					case "RD":
						referencePoint.RelativeDistance = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
						break;
					case "Alt":
					case "Altitude":
						referencePoint.Altitude = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "RelativeBearing":
					case "RB":
						referencePoint.RelativeBearing = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
						break;
					case "CreationDate":
						referencePoint.CreationDate = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
						break;
					case "Longitude":
					case "Lon":
						referencePoint.Longitude = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "IH":
					case "IsSelected":
						referencePoint.m_ProcConsumer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "IsRelativeTo":
					case "IRT":
						referencePoint._MerchantFacade = xmlNode.InnerText;
						break;
					case "Latitude":
					case "Lat":
						referencePoint.Latitude = XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "Tag":
						if (!referencePoint.TagsByGuid_Raw.ContainsKey(xmlNode.InnerText))
						{
							referencePoint.TagsByGuid_Raw.Add(xmlNode.InnerText, xmlNode.InnerText);
						}
						break;
					case "ForceMinimize":
						referencePoint.ForceMinimize = true;
						break;
					case "Fades":
						referencePoint.Fades = true;
						break;
					case "RGroup":
						referencePoint.RenderGroup = (ReferencePoint_Group)Conversions.ToInteger(xmlNode.InnerText);
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
			referencePoint.color = Color.FromArgb(red, green, blue);
			return referencePoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100585", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ReferencePoint result = new ReferencePoint();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public void PostDeserializationHousekeeping(ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		if (Operators.CompareString(_MerchantFacade, "", TextCompare: false) != 0 && concurrentDictionary_0.ContainsKey(_MerchantFacade))
		{
			if (concurrentDictionary_0[_MerchantFacade].IsActiveUnit)
			{
				IsRelativeTo = (Module_Unit.Unit)concurrentDictionary_0[_MerchantFacade];
			}
			else if (concurrentDictionary_0[_MerchantFacade].DisableWriter())
			{
				IsRelativeTo = (Contact)concurrentDictionary_0[_MerchantFacade];
			}
			else if (concurrentDictionary_0[_MerchantFacade].ReadWriter())
			{
				IsRelativeTo = (ReferencePoint)concurrentDictionary_0[_MerchantFacade];
			}
		}
	}

	public void Cycle_1sec(Side side_0, Scenario scenario_0)
	{
		if (!Expiration.HasValue)
		{
			return;
		}
		DateTime time = scenario_0.Time;
		DateTime? expiration = Expiration;
		if ((expiration.HasValue ? new bool?(DateTime.Compare(time, expiration.GetValueOrDefault()) > 0) : null).GetValueOrDefault())
		{
			if (RenderGroup == ReferencePoint_Group.Generic)
			{
				side_0.RefPoints.Remove(this);
			}
			else if (RenderGroup == ReferencePoint_Group.Slugtrail)
			{
				side_0.RefPoints_Slugtrail.Remove(this);
			}
		}
		else if (Fades)
		{
			TimeSpan? timeSpan = Expiration - CreationDate;
			time = scenario_0.Time;
			DateTime? creationDate = CreationDate;
			double num = (time - creationDate).Value.TotalSeconds / timeSpan.Value.TotalSeconds;
			double num2 = 255.0 * (1.0 - num);
			if (Math.Min(num2, 0.0) == num2)
			{
				num2 = 0.0;
			}
			if (Math.Max(num2, 255.0) == num2)
			{
				num2 = 255.0;
			}
			color = Color.FromArgb((int)Math.Round(num2), color.R, color.G, color.B);
		}
	}

	public static ReferencePoint CreateNew(Scenario scenario_0, string string_0, double double_0, double double_1, Side side_0, DateTime? nullable_0, Color color_0, bool bool_0 = false, bool bool_1 = false)
	{
		ReferencePoint referencePoint = new ReferencePoint(string_0, double_0, double_1);
		referencePoint.Expiration = nullable_0;
		referencePoint.color = color_0;
		referencePoint.Fades = bool_0;
		referencePoint.ForceMinimize = bool_1;
		referencePoint.CreationDate = scenario_0.Time;
		referencePoint.RenderGroup = ReferencePoint_Group.Generic;
		side_0.RefPoints.Add(referencePoint);
		return referencePoint;
	}

	public static void CreateNewSlugTrailPoint(Scenario scenario_0, string string_0, double double_0, double double_1, Side side_0, DateTime? nullable_0, Color color_0, bool bool_0 = false, bool bool_1 = false)
	{
		ReferencePoint referencePoint = new ReferencePoint(string_0, double_0, double_1);
		referencePoint.Expiration = nullable_0;
		referencePoint.color = color_0;
		referencePoint.Fades = bool_0;
		referencePoint.ForceMinimize = bool_1;
		referencePoint.CreationDate = scenario_0.Time;
		referencePoint.RenderGroup = ReferencePoint_Group.Slugtrail;
		side_0.RefPoints_Slugtrail.Add(referencePoint);
	}

	public void AdjustForRelativeHooking()
	{
		if (Information.IsNothing(IsRelativeTo))
		{
			return;
		}
		if (IsRelativeTo.CompareWriter() | IsRelativeTo.IsActiveUnit)
		{
			try
			{
				Module_Unit.Unit unit = (Module_Unit.Unit)IsRelativeTo;
				switch (BearingType)
				{
				case OrientationType.Rotating:
					RelativeBearing = MathFunctions.DeleteRequest(unit.CurrentHeading, Math2.PublishClass(unit.GetLatitude(), unit.GetLongitude(), base.Latitude, base.Longitude));
					break;
				case OrientationType.Fixed:
					RelativeBearing = Math2.PublishClass(unit.GetLatitude(), unit.GetLongitude(), base.Latitude, base.Longitude);
					break;
				}
				RelativeDistance = Math2.VerifyClass(unit.GetLatitude(), unit.GetLongitude(), base.Latitude, base.Longitude);
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100586", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return;
			}
		}
		if (IsRelativeTo.DisableWriter())
		{
			try
			{
				Contact contact = (Contact)IsRelativeTo;
				switch (BearingType)
				{
				case OrientationType.Rotating:
					RelativeBearing = MathFunctions.DeleteRequest(contact.CurrentHeading, Math2.PublishClass(contact.GetLatitude(), contact.GetLongitude(), base.Latitude, base.Longitude));
					break;
				case OrientationType.Fixed:
					RelativeBearing = Math2.PublishClass(contact.GetLatitude(), contact.GetLongitude(), base.Latitude, base.Longitude);
					break;
				}
				RelativeDistance = Math2.VerifyClass(contact.GetLatitude(), contact.GetLongitude(), base.Latitude, base.Longitude);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 100586", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		if (!IsRelativeTo.ReadWriter())
		{
			return;
		}
		try
		{
			GeoPoint geoPoint = (GeoPoint)IsRelativeTo;
			switch (BearingType)
			{
			case OrientationType.Rotating:
				BearingType = OrientationType.Fixed;
				RelativeBearing = Math2.PublishClass(geoPoint.Latitude, geoPoint.Longitude, base.Latitude, base.Longitude);
				break;
			case OrientationType.Fixed:
				RelativeBearing = Math2.PublishClass(geoPoint.Latitude, geoPoint.Longitude, base.Latitude, base.Longitude);
				break;
			}
			RelativeDistance = Math2.VerifyClass(geoPoint.Latitude, geoPoint.Longitude, base.Latitude, base.Longitude);
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 100586", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public ReferencePoint(double double_0, double double_1, bool bool_0 = true)
		: base(bool_0)
	{
		Tags = new Dictionary<ReferencePointFlag, ReferencePointFlag>();
		TagsByGuid_Raw = new Dictionary<string, string>();
		color = default(Color);
		color = Color.White;
		base.Longitude = double_0;
		base.Latitude = double_1;
	}

	public ReferencePoint(string string_0, double double_0, double double_1, bool bool_0 = true)
		: base(bool_0)
	{
		Tags = new Dictionary<ReferencePointFlag, ReferencePointFlag>();
		TagsByGuid_Raw = new Dictionary<string, string>();
		color = default(Color);
		base.Longitude = double_0;
		base.Latitude = double_1;
		Name = string_0;
	}

	public ReferencePoint(bool bool_0 = true)
		: base(bool_0)
	{
		Tags = new Dictionary<ReferencePointFlag, ReferencePointFlag>();
		TagsByGuid_Raw = new Dictionary<string, string>();
		color = default(Color);
	}

	public static ReferencePoint CopyRefPoint(ref ReferencePoint referencePoint_0)
	{
		return new ReferencePoint(bool_0: false)
		{
			Name = referencePoint_0.Name,
			ObjectID = referencePoint_0.ObjectID,
			Latitude = referencePoint_0.Latitude,
			Longitude = referencePoint_0.Longitude,
			Altitude = referencePoint_0.Altitude,
			m_ProcConsumer = referencePoint_0.m_ProcConsumer,
			_MerchantFacade = referencePoint_0._MerchantFacade,
			RelativeBearing = referencePoint_0.RelativeBearing,
			RelativeDistance = referencePoint_0.RelativeDistance,
			BearingType = referencePoint_0.BearingType,
			IsLocked = referencePoint_0.IsLocked
		};
	}

	internal List<ReferencePoint> ExcludeWriter(ref List<ReferencePoint> list_0)
	{
		List<ReferencePoint> list = new List<ReferencePoint>();
		if (list_0.Count <= 0)
		{
			return list;
		}
		foreach (ReferencePoint item in list_0)
		{
			list.Add(item);
		}
		return list;
	}

	public ReferencePoint(string string_0, string string_1, double double_0, double double_1, float float_0, bool bool_0, string string_2, float float_1, float float_2, OrientationType orientationType_0, bool bool_1)
	{
		Tags = new Dictionary<ReferencePointFlag, ReferencePointFlag>();
		TagsByGuid_Raw = new Dictionary<string, string>();
		color = default(Color);
		Name = string_0;
		ObjectID_Set(string_1);
		base.Latitude = double_0;
		base.Longitude = double_1;
		base.Altitude = float_0;
		m_ProcConsumer = bool_0;
		_MerchantFacade = string_2;
		RelativeBearing = float_1;
		RelativeDistance = float_2;
		BearingType = orientationType_0;
		IsLocked = bool_1;
	}
}
