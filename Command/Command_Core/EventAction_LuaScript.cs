using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventAction_LuaScript : EventAction
{
	public string ScriptText;

	public EventAction_LuaScript()
	{
		Type = EventActionType.LuaScript;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("EventAction_LuaScript");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteElementString("ScriptText", ScriptText);
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101317", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventAction_LuaScript FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			EventAction_LuaScript eventAction_LuaScript = new EventAction_LuaScript();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "ScriptText":
						eventAction_LuaScript.ScriptText = xmlNode.InnerText;
						break;
					case "ID":
						eventAction_LuaScript.ObjectID_Set(xmlNode.InnerText);
						break;
					case "Description":
						eventAction_LuaScript.Description = xmlNode.InnerText;
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
			return eventAction_LuaScript;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101315", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			EventAction_LuaScript result = new EventAction_LuaScript();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override void Execute(Scenario scenario_0, SimEvent simEvent_0)
	{
		try
		{
			scenario_0.Scenario_LuaSandbox.RunScript(ScriptText, bool_0: false, simEvent_0.Description);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			scenario_0.AddMessage("Lua脚本执行错误：" + exception_.Source + " " + exception_.Message, "Lua脚本错误！", LoggedMessage.MessageType.EventEngine, 0, null);
			exception_?.Data.Add("Error at 101316", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			_ = Debugger.IsAttached;
			ProjectData.ClearProjectError();
		}
	}

	public override EventAction Clone()
	{
		EventAction_LuaScript obj = (EventAction_LuaScript)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		return obj;
	}
}
