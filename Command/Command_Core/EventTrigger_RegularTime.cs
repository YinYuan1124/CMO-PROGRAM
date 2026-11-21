using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_RegularTime : EventTrigger
{
	public enum RegularTimeInterval
	{
		OneSecond,
		FiveSeconds,
		FifteenSeconds,
		ThirtySeconds,
		OneMinute,
		FiveMinutes,
		FifteenMinutes,
		ThirtyMinutes,
		OneHour,
		SixHours,
		TwelveHours,
		TwentyFourHours,
		EveryPulse
	}

	public RegularTimeInterval Interval;

	[SpecialName]
	public bool GetIsFulfilled(Scenario scenario_0)
	{
		RegularTimeInterval interval = Interval;
		if (1 == 0)
		{
		}
		bool result = interval switch
		{
			RegularTimeInterval.OneSecond => scenario_0.SecondIsChangingOnThisPulse, 
			RegularTimeInterval.FiveSeconds => scenario_0.FifthSecondIsChangingOnThisPulse, 
			RegularTimeInterval.FifteenSeconds => scenario_0.FifteenthSecondIsChangingOnThisPulse, 
			RegularTimeInterval.ThirtySeconds => scenario_0.ThirtiethSecondIsChangingOnThisPulse, 
			RegularTimeInterval.OneMinute => scenario_0.MinuteIsChangingOnThisPulse, 
			RegularTimeInterval.FiveMinutes => scenario_0.FifthMinuteIsChangingOnThisPulse, 
			RegularTimeInterval.FifteenMinutes => scenario_0.FifteenthMinuteIsChangingOnThisPulse, 
			RegularTimeInterval.ThirtyMinutes => scenario_0.ThirtiethMinuteIsChangingOnThisPulse, 
			RegularTimeInterval.OneHour => scenario_0.HourIsChangingOnThisPulse, 
			RegularTimeInterval.SixHours => scenario_0.SixHourIsChangingOnThisPulse, 
			RegularTimeInterval.TwelveHours => scenario_0.TwelveHourIsChangingOnThisPulse, 
			RegularTimeInterval.TwentyFourHours => scenario_0.TwentyFourHourIsChangingOnThisPulse, 
			RegularTimeInterval.EveryPulse => true, 
			_ => false, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public EventTrigger_RegularTime(RegularTimeInterval regularTimeInterval_0)
	{
		Type = EventTriggerType.RegularTime;
		Interval = regularTimeInterval_0;
	}

	public EventTrigger_RegularTime()
	{
		Type = EventTriggerType.RegularTime;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("EventTrigger_RegularTime");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			int interval = (int)Interval;
			xmlWriter_0.WriteElementString("Interval", interval.ToString());
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100320968409868", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_RegularTime FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		EventTrigger_RegularTime result = null;
		try
		{
			EventTrigger_RegularTime eventTrigger_RegularTime = new EventTrigger_RegularTime();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "Interval":
						eventTrigger_RegularTime.Interval = (RegularTimeInterval)Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "ID":
						eventTrigger_RegularTime.ObjectID_Set(xmlNode.InnerText);
						break;
					case "Description":
						eventTrigger_RegularTime.Description = xmlNode.InnerText;
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
			result = eventTrigger_RegularTime;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10004356945678578882", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override EventTrigger Clone()
	{
		EventTrigger_RegularTime obj = (EventTrigger_RegularTime)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		return obj;
	}
}
