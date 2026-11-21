using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_RandomTime : EventTrigger
{
	public DateTime EarliestTime;

	public DateTime LatestTime;

	protected internal bool Fired;

	private DateTime? adapterClient;

	public bool isActualTimeSet => adapterClient.HasValue;

	public DateTime ActualTime
	{
		get
		{
			if (!adapterClient.HasValue)
			{
				if (LatestTime.Ticks < EarliestTime.Ticks)
				{
					double totalSeconds = new TimeSpan(EarliestTime.Ticks - LatestTime.Ticks).TotalSeconds;
					adapterClient = LatestTime.AddSeconds(GameGeneral.LockRandom_0.Next(0, (int)Math.Round(totalSeconds)));
				}
				else
				{
					double totalSeconds2 = new TimeSpan(LatestTime.Ticks - EarliestTime.Ticks).TotalSeconds;
					adapterClient = EarliestTime.AddSeconds(GameGeneral.LockRandom_0.Next(0, (int)Math.Round(totalSeconds2)));
				}
			}
			return adapterClient.Value;
		}
	}

	[SpecialName]
	public bool GetIsFulfilled(DateTime dateTime_0)
	{
		bool result = false;
		if (!Fired && ActualTime.CompareTo(dateTime_0) <= 0)
		{
			result = true;
			Fired = true;
		}
		return result;
	}

	public EventTrigger_RandomTime(DateTime dateTime_0, DateTime dateTime_1)
	{
		Type = EventTriggerType.RandomTime;
		EarliestTime = dateTime_0;
		LatestTime = dateTime_1;
		Fired = false;
	}

	private EventTrigger_RandomTime()
	{
		Type = EventTriggerType.RandomTime;
		Fired = false;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("EventTrigger_RandomTime");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteElementString("EarliestTime", EarliestTime.ToBinary().ToString());
			xmlWriter_0.WriteElementString("LatestTime", LatestTime.ToBinary().ToString());
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
			exception_?.Data.Add("Error at 100522", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_RandomTime FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			EventTrigger_RandomTime eventTrigger_RandomTime = new EventTrigger_RandomTime();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "LatestTime":
						eventTrigger_RandomTime.LatestTime = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
						break;
					case "ID":
						eventTrigger_RandomTime.ObjectID_Set(xmlNode.InnerText);
						break;
					case "Fired":
						eventTrigger_RandomTime.Fired = true;
						break;
					case "EarliestTime":
						eventTrigger_RandomTime.EarliestTime = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
						break;
					case "Description":
						eventTrigger_RandomTime.Description = xmlNode.InnerText;
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
			return eventTrigger_RandomTime;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100523", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			EventTrigger_RandomTime result = new EventTrigger_RandomTime();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override EventTrigger Clone()
	{
		EventTrigger_RandomTime obj = (EventTrigger_RandomTime)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		return obj;
	}
}
