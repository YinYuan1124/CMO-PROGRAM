using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventAction_EndScenario : EventAction
{
	public EventAction_EndScenario()
	{
		Type = EventActionType.EndScenario;
		Description = "结束想定";
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("EventAction_EndScenario");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100505", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventAction_EndScenario FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			EventAction_EndScenario eventAction_EndScenario = new EventAction_EndScenario();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					if (Operators.CompareString(xmlNode.Name, "ID", TextCompare: false) == 0)
					{
						eventAction_EndScenario.ObjectID_Set(xmlNode.InnerText);
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
			return eventAction_EndScenario;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100506", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			EventAction_EndScenario result = new EventAction_EndScenario();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override void Execute(Scenario scenario_0, SimEvent simEvent_0)
	{
		scenario_0.EndScenario();
	}

	public override EventAction Clone()
	{
		EventAction_EndScenario obj = (EventAction_EndScenario)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		return obj;
	}
}
