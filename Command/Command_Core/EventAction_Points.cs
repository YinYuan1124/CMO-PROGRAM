using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventAction_Points : EventAction
{
	public string SideID;

	public int PointChange;

	public EventAction_Points()
	{
		Type = EventActionType.Points;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("EventAction_Points");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteElementString("SideID", SideID);
			xmlWriter_0.WriteElementString("PointChange", PointChange.ToString());
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100510", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventAction_Points FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		EventAction_Points result = null;
		try
		{
			EventAction_Points eventAction_Points = new EventAction_Points();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "SideID":
						eventAction_Points.SideID = xmlNode.InnerText;
						break;
					case "PointChange":
						eventAction_Points.PointChange = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "ID":
						eventAction_Points.ObjectID_Set(xmlNode.InnerText);
						break;
					case "Description":
						eventAction_Points.Description = xmlNode.InnerText;
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
			result = eventAction_Points;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100511", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override void Execute(Scenario scenario_0, SimEvent simEvent_0)
	{
		try
		{
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				if (Operators.CompareString(side.ObjectID, SideID, TextCompare: false) == 0)
				{
					string string_ = "";
					side.SetTotalScore(int_0: side.GetTotalScore(scenario_0, string_) + PointChange, scenario_0: scenario_0, string_0: string_ = "事件动作：'" + Description + "'已触发（事件描述：'" + simEvent_0.Description + "')");
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ex?.Data.Add("Error at 100512", "");
			GameGeneral.WriteExceptionsToLog(ref ex);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	public override EventAction Clone()
	{
		EventAction_Points obj = (EventAction_Points)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		return obj;
	}
}
