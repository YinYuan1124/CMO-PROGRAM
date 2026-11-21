using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventCondition_ScenHasStarted : EventCondition
{
	public bool Modifier_NOT;

	public EventCondition_ScenHasStarted()
	{
		Type = EventConditionType.ScenHasStarted;
	}

	[SpecialName]
	public override bool GetIsTrue(Scenario scenario_0, SimEvent simEvent_0)
	{
		try
		{
			if (Modifier_NOT)
			{
				return !scenario_0.HasStarted;
			}
			return scenario_0.HasStarted;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101321", "");
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
			xmlWriter_0.WriteStartElement("EventCondition_ScenHasStarted");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
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
			exception_?.Data.Add("Error at 101322", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventCondition_ScenHasStarted FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			EventCondition_ScenHasStarted eventCondition_ScenHasStarted = new EventCondition_ScenHasStarted();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "NOT":
						eventCondition_ScenHasStarted.Modifier_NOT = true;
						break;
					case "ID":
						eventCondition_ScenHasStarted.ObjectID_Set(xmlNode.InnerText);
						break;
					case "Description":
						eventCondition_ScenHasStarted.Description = xmlNode.InnerText;
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
			return eventCondition_ScenHasStarted;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101323", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			EventCondition_ScenHasStarted result = new EventCondition_ScenHasStarted();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override EventCondition Clone()
	{
		EventCondition_ScenHasStarted obj = (EventCondition_ScenHasStarted)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		return obj;
	}
}
