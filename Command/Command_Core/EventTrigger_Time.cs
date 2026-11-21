using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_Time : EventTrigger
{
	public DateTime Time;

	protected internal bool Fired;

	[SpecialName]
	public bool GetIsFulfilled(DateTime dateTime_0)
	{
		if (Fired)
		{
			return true;
		}
		bool result = false;
		if (!Fired && Time.CompareTo(dateTime_0) <= 0)
		{
			result = true;
			Fired = true;
		}
		return result;
	}

	public EventTrigger_Time(DateTime dateTime_0)
	{
		Type = EventTriggerType.Time;
		Time = dateTime_0;
		Fired = false;
	}

	private EventTrigger_Time()
	{
		Type = EventTriggerType.Time;
		Fired = false;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("EventTrigger_Time");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteElementString("Time", Time.ToBinary().ToString());
			if (Fired)
			{
				xmlWriter_0.WriteElementString("Fired", 1.ToString());
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100524", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_Time FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			EventTrigger_Time eventTrigger_Time = new EventTrigger_Time();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "Time":
						eventTrigger_Time.Time = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
						break;
					case "ID":
						eventTrigger_Time.ObjectID_Set(xmlNode.InnerText);
						break;
					case "Fired":
						eventTrigger_Time.Fired = true;
						break;
					case "Description":
						eventTrigger_Time.Description = xmlNode.InnerText;
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
			return eventTrigger_Time;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100525", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			EventTrigger_Time result = new EventTrigger_Time();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override EventTrigger Clone()
	{
		EventTrigger_Time obj = (EventTrigger_Time)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		return obj;
	}
}
