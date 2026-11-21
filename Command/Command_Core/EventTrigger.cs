using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public abstract class EventTrigger : ScenarioObject
{
	public enum EventTriggerType : byte
	{
		UnitDestroyed,
		Points,
		Time,
		UnitDamaged,
		UnitRemainsInArea,
		UnitEntersArea,
		RandomTime,
		UnitDetected,
		ScenLoaded,
		RegularTime,
		ScenEnded,
		UnitBaseStatus,
		UnitEmissions,
		UnitCargoMoved
	}

	public string Description;

	public EventTriggerType Type;

	public EventTrigger()
	{
	}

	public virtual void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		throw new NotImplementedException();
	}

	public static EventTrigger FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		try
		{
			switch (xmlNode_0.Name)
			{
			case "EventTrigger_UnitDamaged":
				return EventTrigger_UnitDamaged.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
			case "EventTrigger_UnitDetected":
				return EventTrigger_UnitDetected.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
			case "EventTrigger_UnitEmissions":
				return EventTrigger_UnitEmissions.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
			case "EventTrigger_RegularTime":
				return EventTrigger_RegularTime.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
			case "EventTrigger_ScenLoaded":
				return EventTrigger_ScenLoaded.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
			case "EventTrigger_UnitDestroyed":
				return EventTrigger_UnitDestroyed.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
			case "EventTrigger_Points":
				return EventTrigger_Points.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
			case "EventTrigger_UnitEntersArea":
				return EventTrigger_UnitEntersArea.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
			case "EventTrigger_UnitBaseStatus":
				return EventTrigger_UnitBaseStatus.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
			case "EventTrigger_ScenEnded":
				return EventTrigger_ScenEnded.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
			case "EventTrigger_UnitInArea":
			case "EventTrigger_UnitRemainsInArea":
				return EventTrigger_UnitRemainsInArea.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
			case "EventTrigger_RandomTime":
				return EventTrigger_RandomTime.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
			case "EventTrigger_Time":
				return EventTrigger_Time.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
			default:
				throw new NotImplementedException();
			case "EventTrigger_UnitCargoMoved":
				return EventTrigger_UnitCargoMoved.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100519", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public virtual EventTrigger Clone()
	{
		throw new NotImplementedException();
	}
}
