using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_Points : EventTrigger
{
	public enum PointReachDirection : byte
	{
		GoOver,
		MatchExactly,
		GoUnder
	}

	public string SideID;

	public int PointValue;

	public PointReachDirection ReachDirection;

	[SpecialName]
	public bool GetIsFulfilled(Side side_0, int int_0, int int_1)
	{
		if (Operators.CompareString(side_0.ObjectID, SideID, TextCompare: false) == 0)
		{
			PointReachDirection reachDirection = ReachDirection;
			if (1 == 0)
			{
			}
			bool result = reachDirection switch
			{
				PointReachDirection.GoOver => (int_0 < PointValue) & (PointValue <= int_1), 
				PointReachDirection.MatchExactly => int_1 == PointValue, 
				PointReachDirection.GoUnder => (int_0 > PointValue) & (PointValue >= int_1), 
				_ => false, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		return false;
	}

	public EventTrigger_Points()
	{
		Type = EventTriggerType.Points;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("EventTrigger_Points");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteElementString("SideID", SideID);
			xmlWriter_0.WriteElementString("PointValue", PointValue.ToString());
			byte reachDirection = (byte)ReachDirection;
			xmlWriter_0.WriteElementString("ReachDirection", reachDirection.ToString());
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100520", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_Points FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		EventTrigger_Points result = null;
		try
		{
			EventTrigger_Points eventTrigger_Points = new EventTrigger_Points();
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
						eventTrigger_Points.SideID = xmlNode.InnerText;
						break;
					case "ReachDirection":
						eventTrigger_Points.ReachDirection = (PointReachDirection)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "PointValue":
						eventTrigger_Points.PointValue = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "ID":
						eventTrigger_Points.ObjectID_Set(xmlNode.InnerText);
						break;
					case "Description":
						eventTrigger_Points.Description = xmlNode.InnerText;
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
			result = eventTrigger_Points;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100521", "");
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
		EventTrigger_Points obj = (EventTrigger_Points)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		return obj;
	}
}
