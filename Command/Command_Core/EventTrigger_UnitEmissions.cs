using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_UnitEmissions : EventTrigger
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
		Contact contact = activeUnit_1.GetUnitSide().Contacts[activeUnit_0.ObjectID];
		if (Information.IsNothing(contact))
		{
			contact = activeUnit_1.GetUnitSide().m_InfoFacade[activeUnit_0.ObjectID];
		}
		if (!Information.IsNothing(contact.DetectedEmissions) && !contact.DetectedEmissions.Equals(contact._DetectedEmissionsPrevious))
		{
			if (contact.DetectedEmissions.Count == 0)
			{
				return false;
			}
			Side unitSide = activeUnit_1.GetUnitSide();
			int result;
			if (Operators.CompareString(DetectorSideID, unitSide.ObjectID, TextCompare: false) == 0)
			{
				if (TargetFilter.MatchesThisUnit(activeUnit_0))
				{
					DetectedUnit = activeUnit_0;
					activeUnit_0.ParentScen.Scenario_LuaSandbox.UnitX = activeUnit_0;
					DetectingUnit = activeUnit_1;
					activeUnit_0.ParentScen.Scenario_LuaSandbox.UnitY = activeUnit_1;
					SensorsThatMadeDetection = list_0;
					DetectedAsContact = contact;
					if (!Information.IsNothing(contact))
					{
						activeUnit_0.ParentScen.Scenario_LuaSandbox.UnitC = contact;
					}
					contact._DetectedEmissionsPrevious = contact.DetectedEmissions;
					return true;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			DetectedAsContact = null;
			DetectedUnit = null;
			DetectingUnit = null;
			SensorsThatMadeDetection = null;
			return (byte)result != 0;
		}
		return false;
	}

	public EventTrigger_UnitEmissions()
	{
		TargetFilter = new UnitFilterObject();
		MinimumClassificationLevel = Contact_Base.IdentificationStatus.Unknown;
		Area = new List<ReferencePoint>();
		DetectedInArea = null;
		Type = EventTriggerType.UnitEmissions;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("EventTrigger_UnitEmissions");
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

	public static EventTrigger_UnitEmissions FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			EventTrigger_UnitEmissions eventTrigger_UnitEmissions = new EventTrigger_UnitEmissions();
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
						eventTrigger_UnitEmissions.TargetFilter = UnitFilterObject.FromXML(xmlNode, concurrentDictionary_0, scenario_0);
						break;
					case "MCL":
						eventTrigger_UnitEmissions.MinimumClassificationLevel = (Contact_Base.IdentificationStatus)Conversions.ToShort(xmlNode.InnerText);
						break;
					case "ID":
						eventTrigger_UnitEmissions.ObjectID_Set(xmlNode.InnerText);
						break;
					case "DetectorSideID":
						eventTrigger_UnitEmissions.DetectorSideID = xmlNode.InnerText;
						break;
					case "Description":
						eventTrigger_UnitEmissions.Description = xmlNode.InnerText;
						break;
					case "Area":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
								eventTrigger_UnitEmissions.Area.Add(ReferencePoint.FromXML(ref xmlNode_, ref concurrentDictionary_0));
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
			return eventTrigger_UnitEmissions;
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
			EventTrigger_UnitEmissions result = new EventTrigger_UnitEmissions();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override EventTrigger Clone()
	{
		EventTrigger_UnitEmissions obj = (EventTrigger_UnitEmissions)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		obj.TargetFilter = TargetFilter.Clone();
		obj.Area = Area.GetRange(0, Area.Count);
		return obj;
	}
}
