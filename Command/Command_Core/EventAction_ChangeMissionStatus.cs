using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventAction_ChangeMissionStatus : EventAction
{
	public string MissionID;

	public Mission.MissionStatus NewStatus;

	public EventAction_ChangeMissionStatus()
	{
		Type = EventActionType.ChangeMissionStatus;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("EventAction_ChangeMissionStatus");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteElementString("MissionID", MissionID);
			byte newStatus = (byte)NewStatus;
			xmlWriter_0.WriteElementString("NewStatus", newStatus.ToString());
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100502", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventAction_ChangeMissionStatus FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		EventAction_ChangeMissionStatus eventAction_ChangeMissionStatus = new EventAction_ChangeMissionStatus();
		try
		{
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "NewStatus":
						eventAction_ChangeMissionStatus.NewStatus = (Mission.MissionStatus)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "MissionID":
						eventAction_ChangeMissionStatus.MissionID = xmlNode.InnerText;
						break;
					case "ID":
						eventAction_ChangeMissionStatus.ObjectID_Set(xmlNode.InnerText);
						break;
					case "Description":
						eventAction_ChangeMissionStatus.Description = xmlNode.InnerText;
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
			return eventAction_ChangeMissionStatus;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100503", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			EventAction_ChangeMissionStatus result = new EventAction_ChangeMissionStatus();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override void Execute(Scenario scenario_0, SimEvent simEvent_0)
	{
		try
		{
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i++)
			{
				foreach (Mission mission in sides_ReadOnly[i].Missions)
				{
					if (string.CompareOrdinal(mission.ObjectID, MissionID) == 0)
					{
						mission.SetStatus(scenario_0, NewStatus);
						break;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100504", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override EventAction Clone()
	{
		EventAction_ChangeMissionStatus obj = (EventAction_ChangeMissionStatus)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		return obj;
	}
}
