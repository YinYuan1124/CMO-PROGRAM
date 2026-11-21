using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Command_Core;

public class EventCondition : ScenarioObject
{
	public enum EventConditionType : byte
	{
		SidePosture,
		ScenHasStarted,
		LuaScript
	}

	public string Description;

	public EventConditionType Type;

	[SpecialName]
	public virtual bool GetIsTrue(Scenario scenario_0, SimEvent simEvent_0)
	{
		throw new NotImplementedException();
	}

	public virtual void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		throw new NotImplementedException();
	}

	public static EventCondition FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		string name = xmlNode_0.Name;
		if (1 == 0)
		{
		}
		EventCondition result = name switch
		{
			"EventCondition_SidePosture" => EventCondition_SidePosture.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0), 
			"EventCondition_ScenHasStarted" => EventCondition_ScenHasStarted.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0), 
			"EventCondition_LuaScript" => EventCondition_LuaScript.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0), 
			_ => throw new NotImplementedException(), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public virtual EventCondition Clone()
	{
		throw new NotImplementedException();
	}
}
