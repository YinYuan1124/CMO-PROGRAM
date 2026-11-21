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

public sealed class EventCondition_SidePosture : EventCondition
{
	public string ObserverSide_ID;

	public string TargetSide_ID;

	public Misc.PostureStance TargetPosture;

	public bool Modifier_NOT;

	public EventCondition_SidePosture()
	{
		Type = EventConditionType.SidePosture;
	}

	[SpecialName]
	public override bool GetIsTrue(Scenario scenario_0, SimEvent simEvent_0)
	{
		try
		{
			Side side = null;
			Side side2 = null;
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side3 in array)
			{
				if (Operators.CompareString(side3.ObjectID, ObserverSide_ID, TextCompare: false) == 0)
				{
					side = side3;
				}
				if (Operators.CompareString(side3.ObjectID, TargetSide_ID, TextCompare: false) == 0)
				{
					side2 = side3;
				}
			}
			if (!Information.IsNothing(side) && !Information.IsNothing(side2))
			{
				bool? flag = side.GetConsidersThisSideToBe(side2) == TargetPosture;
				if (Information.IsNothing(flag))
				{
					return false;
				}
				if (Modifier_NOT)
				{
					return !flag.Value;
				}
				return flag.Value;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100516", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("EventCondition_SidePosture");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteElementString("ObserverSideID", ObserverSide_ID);
			xmlWriter_0.WriteElementString("TargetSideID", TargetSide_ID);
			if (!Information.IsNothing(TargetPosture))
			{
				xmlWriter_0.WriteElementString("TargetPosture", Conversions.ToString((int)TargetPosture));
			}
			if (Modifier_NOT)
			{
				xmlWriter_0.WriteElementString("NOT", 1.ToString());
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100517", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventCondition_SidePosture FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			EventCondition_SidePosture eventCondition_SidePosture = new EventCondition_SidePosture();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "TargetSideID":
						eventCondition_SidePosture.TargetSide_ID = xmlNode.InnerText;
						break;
					case "TargetPosture":
						eventCondition_SidePosture.TargetPosture = (Misc.PostureStance)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "ObserverSideID":
						eventCondition_SidePosture.ObserverSide_ID = xmlNode.InnerText;
						break;
					case "NOT":
						eventCondition_SidePosture.Modifier_NOT = true;
						break;
					case "ID":
						eventCondition_SidePosture.ObjectID_Set(xmlNode.InnerText);
						break;
					case "Description":
						eventCondition_SidePosture.Description = xmlNode.InnerText;
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
			return eventCondition_SidePosture;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100518", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			EventCondition_SidePosture result = new EventCondition_SidePosture();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override EventCondition Clone()
	{
		EventCondition_SidePosture obj = (EventCondition_SidePosture)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		return obj;
	}
}
