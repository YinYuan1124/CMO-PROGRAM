using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class EventAction : ScenarioObject
{
	public enum EventActionType : byte
	{
		Points,
		EndScenario,
		TeleportInArea,
		Message,
		ChangeMissionStatus,
		LuaScript
	}

	public string Description;

	public EventActionType Type;

	public virtual void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		throw new NotImplementedException();
	}

	public static EventAction FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		EventAction result = null;
		try
		{
			switch (xmlNode_0.Name)
			{
			default:
				throw new NotImplementedException();
			case "EventAction_TeleportInArea":
				result = EventAction_TeleportInArea.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
				return result;
			case "EventAction_Points":
				result = EventAction_Points.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
				return result;
			case "EventAction_Message":
				result = EventAction_Message.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
				return result;
			case "EventAction_LuaScript":
				result = EventAction_LuaScript.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
				return result;
			case "EventAction_EndScenario":
				result = EventAction_EndScenario.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
				return result;
			case "EventAction_ChangeMissionStatus":
				result = EventAction_ChangeMissionStatus.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0);
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100501", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public virtual void Execute(Scenario scenario_0, SimEvent simEvent_0)
	{
		throw new NotImplementedException();
	}

	public virtual EventAction Clone()
	{
		throw new NotImplementedException();
	}
}
