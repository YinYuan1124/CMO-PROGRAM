using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_UnitDetected : EventTrigger
{
	public UnitFilterObject TargetFilter;

	public string DetectorSideID;

	public Contact_Base.IdentificationStatus MinimumClassificationLevel;

	public ActiveUnit DetectedUnit;

	public ActiveUnit DetectingUnit;

	public Contact DetectedAsContact;

	public List<ReferencePoint> Area;

	public List<Sensor> SensorsThatMadeDetection;

	public bool? DetectedInArea;

	[SpecialName]
	public bool GetIsFulfilled(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, bool bool_0, Contact_Base.IdentificationStatus identificationStatus_0, Contact_Base.IdentificationStatus? nullable_0, List<Sensor> list_0)
	{
		DetectedAsContact = null;
		DetectedUnit = null;
		DetectingUnit = null;
		SensorsThatMadeDetection = null;
		DetectedInArea = null;
		if (identificationStatus_0 < MinimumClassificationLevel)
		{
			return false;
		}
		bool flag = false;
		bool? flag2 = null;
		Contact contact = activeUnit_1.GetUnitSide().Contacts[activeUnit_0.ObjectID];
		if (contact == null)
		{
			contact = activeUnit_1.GetUnitSide().m_InfoFacade[activeUnit_0.ObjectID];
		}
		if (Area.Count > 0)
		{
			if (contact == null)
			{
				return false;
			}
			if (Information.IsNothing(contact.GetLatitude()) || Information.IsNothing(contact.GetLongitude()) || contact.GetLatitude() == 0.0 || contact.GetLongitude() == 0.0)
			{
				if (contact.ActualUnit.Latitude_LastReported.HasValue)
				{
					contact.SetLatitude(null, contact.ActualUnit.Latitude_LastReported.Value);
				}
				if (contact.ActualUnit.Longitude_LastReported.HasValue)
				{
					contact.SetLongitude(null, contact.ActualUnit.Longitude_LastReported.Value);
				}
			}
			if (contact.GetIsInsideThisArea(Area, activeUnit_0.ParentScen, bool_0: false))
			{
				flag2 = true;
			}
			else
			{
				flag2 = false;
				if (contact.ActiveEnterAreaTriggers.Count > 0)
				{
					contact.ActiveEnterAreaTriggers.Remove(ObjectID);
				}
			}
		}
		Side unitSide = activeUnit_1.GetUnitSide();
		if (Operators.CompareString(DetectorSideID, unitSide.ObjectID, TextCompare: false) == 0)
		{
			if (TargetFilter.MatchesThisUnit(activeUnit_0))
			{
				if (!Information.IsNothing(flag2) && (!flag2).GetValueOrDefault())
				{
					flag = false;
				}
				else if (Area.Count == 0)
				{
					if (bool_0)
					{
						flag = true;
					}
					else
					{
						if (nullable_0.HasValue)
						{
							short? num = (short?)nullable_0;
							short num2 = (short)identificationStatus_0;
							if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == num2) : null).GetValueOrDefault())
							{
								num = (short?)nullable_0;
								num2 = (short)MinimumClassificationLevel;
								bool? flag3 = (num.HasValue ? new bool?(num.GetValueOrDefault() == num2) : null);
								if (flag3.GetValueOrDefault(true) && MinimumClassificationLevel == Contact_Base.IdentificationStatus.Unknown && flag3.HasValue)
								{
									flag = true;
								}
								else
								{
									num = (short?)nullable_0;
									num2 = (short)MinimumClassificationLevel;
									flag = !(num.HasValue ? new bool?(num.GetValueOrDefault() >= num2) : null).GetValueOrDefault();
								}
								goto IL_0464;
							}
						}
						flag = false;
					}
				}
				else if (!Information.IsNothing(contact) && contact.ActiveEnterAreaTriggers.FirstOrDefault((string string_0) => Operators.CompareString(string_0, ObjectID, TextCompare: false) == 0) == null)
				{
					flag = true;
				}
			}
			else
			{
				flag = false;
			}
		}
		else
		{
			flag = false;
		}
		goto IL_0464;
		IL_0464:
		if (flag)
		{
			DetectedUnit = activeUnit_0;
			activeUnit_0.ParentScen.Scenario_LuaSandbox.UnitX = activeUnit_0;
			DetectingUnit = activeUnit_1;
			activeUnit_0.ParentScen.Scenario_LuaSandbox.UnitY = activeUnit_1;
			SensorsThatMadeDetection = list_0;
			if (!Information.IsNothing(flag2))
			{
				bool? flag4 = flag2;
				flag4 = flag4;
				if (flag4.GetValueOrDefault())
				{
					DetectedInArea = true;
				}
			}
			DetectedAsContact = contact;
			if (!Information.IsNothing(contact))
			{
				activeUnit_0.ParentScen.Scenario_LuaSandbox.UnitC = contact;
			}
		}
		else
		{
			DetectedAsContact = null;
			DetectedUnit = null;
			DetectingUnit = null;
			SensorsThatMadeDetection = null;
		}
		return flag;
	}

	[SpecialName]
	public bool GetIsFulfilled(UnguidedWeapon unguidedWeapon_0, ActiveUnit activeUnit_0, bool bool_0, Contact_Base.IdentificationStatus identificationStatus_0, Contact_Base.IdentificationStatus? nullable_0, List<Sensor> list_0)
	{
		DetectedAsContact = null;
		DetectedUnit = null;
		DetectingUnit = null;
		SensorsThatMadeDetection = null;
		DetectedInArea = null;
		if (identificationStatus_0 < MinimumClassificationLevel)
		{
			return false;
		}
		bool flag = false;
		bool? flag2 = null;
		if (Area.Count > 0)
		{
			if (unguidedWeapon_0.GetIsInsideThisArea(Area, activeUnit_0.ParentScen, bool_0: false))
			{
				flag2 = true;
			}
			else
			{
				flag2 = false;
				if (unguidedWeapon_0.ActiveEnterAreaTriggers.Count > 0)
				{
					unguidedWeapon_0.ActiveEnterAreaTriggers.Remove(ObjectID);
				}
			}
		}
		Side unitSide = activeUnit_0.GetUnitSide();
		if (Operators.CompareString(DetectorSideID, unitSide.ObjectID, TextCompare: false) == 0)
		{
			if (TargetFilter.MatchesThisUnit(unguidedWeapon_0))
			{
				if (!Information.IsNothing(flag2) && (!flag2).GetValueOrDefault())
				{
					flag = false;
				}
				else if (Area.Count == 0)
				{
					if (bool_0)
					{
						flag = true;
					}
					else
					{
						if (!Information.IsNothing(nullable_0))
						{
							short? num = (short?)nullable_0;
							short num2 = (short)identificationStatus_0;
							if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == num2) : null).GetValueOrDefault())
							{
								num = (short?)nullable_0;
								num2 = (short)MinimumClassificationLevel;
								bool? flag3 = (num.HasValue ? new bool?(num.GetValueOrDefault() == num2) : null);
								if (flag3.GetValueOrDefault(true) && MinimumClassificationLevel == Contact_Base.IdentificationStatus.Unknown && flag3.HasValue)
								{
									flag = true;
								}
								else
								{
									num = (short?)nullable_0;
									num2 = (short)MinimumClassificationLevel;
									flag = !(num.HasValue ? new bool?(num.GetValueOrDefault() >= num2) : null).GetValueOrDefault();
								}
								goto IL_031a;
							}
						}
						flag = false;
					}
				}
				else if (!Information.IsNothing(unguidedWeapon_0) && unguidedWeapon_0.ActiveEnterAreaTriggers.FirstOrDefault((string string_0) => Operators.CompareString(string_0, ObjectID, TextCompare: false) == 0) == null)
				{
					flag = true;
				}
			}
			else
			{
				flag = false;
			}
		}
		else
		{
			flag = false;
		}
		goto IL_031a;
		IL_031a:
		if (flag)
		{
			activeUnit_0.ParentScen.Scenario_LuaSandbox.UnitX = unguidedWeapon_0;
			DetectingUnit = activeUnit_0;
			activeUnit_0.ParentScen.Scenario_LuaSandbox.UnitY = activeUnit_0;
			SensorsThatMadeDetection = list_0;
			if (!Information.IsNothing(flag2))
			{
				bool? flag4 = flag2;
				flag4 = flag4;
				if (flag4.GetValueOrDefault())
				{
					DetectedInArea = true;
				}
			}
		}
		else
		{
			DetectedAsContact = null;
			DetectedUnit = null;
			DetectingUnit = null;
			SensorsThatMadeDetection = null;
		}
		return flag;
	}

	public EventTrigger_UnitDetected()
	{
		TargetFilter = new UnitFilterObject();
		MinimumClassificationLevel = Contact_Base.IdentificationStatus.Unknown;
		Area = new List<ReferencePoint>();
		DetectedInArea = null;
		Type = EventTriggerType.UnitDetected;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("EventTrigger_UnitDetected");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteStartElement("TargetFilter");
			TargetFilter.ToXML(xmlWriter_0, hashSet_0, scenario_0);
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Area");
			foreach (ReferencePoint item in Area)
			{
				xmlWriter_0.WriteRaw(item.ToXML(ref hashSet_0));
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteElementString("DetectorSideID", DetectorSideID);
			short minimumClassificationLevel = (short)MinimumClassificationLevel;
			xmlWriter_0.WriteElementString("MCL", minimumClassificationLevel.ToString());
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100530", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_UnitDetected FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			EventTrigger_UnitDetected eventTrigger_UnitDetected = new EventTrigger_UnitDetected();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "TargetFilter":
						eventTrigger_UnitDetected.TargetFilter = UnitFilterObject.FromXML(xmlNode, concurrentDictionary_0, scenario_0);
						break;
					case "MCL":
						eventTrigger_UnitDetected.MinimumClassificationLevel = (Contact_Base.IdentificationStatus)Conversions.ToShort(xmlNode.InnerText);
						break;
					case "ID":
						eventTrigger_UnitDetected.ObjectID_Set(xmlNode.InnerText);
						break;
					case "DetectorSideID":
						eventTrigger_UnitDetected.DetectorSideID = xmlNode.InnerText;
						break;
					case "Description":
						eventTrigger_UnitDetected.Description = xmlNode.InnerText;
						break;
					case "Area":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
								eventTrigger_UnitDetected.Area.Add(ReferencePoint.FromXML(ref xmlNode_, ref concurrentDictionary_0));
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
			return eventTrigger_UnitDetected;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100531", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			EventTrigger_UnitDetected result = new EventTrigger_UnitDetected();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override EventTrigger Clone()
	{
		EventTrigger_UnitDetected obj = (EventTrigger_UnitDetected)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		obj.TargetFilter = TargetFilter.Clone();
		obj.Area = Area.GetRange(0, Area.Count);
		return obj;
	}

	[CompilerGenerated]
	private bool ForgotRepository(string string_0)
	{
		return Operators.CompareString(string_0, ObjectID, TextCompare: false) == 0;
	}

	[CompilerGenerated]
	private bool CollectRepository(string string_0)
	{
		return Operators.CompareString(string_0, ObjectID, TextCompare: false) == 0;
	}
}
