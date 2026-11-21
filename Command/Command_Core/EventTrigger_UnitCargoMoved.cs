using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_UnitCargoMoved : EventTrigger
{
	public CargoFilterObject TargetFilter;

	public CargoTracker cargotrk;

	public ActiveUnit BaseUnit;

	public bool ClearValues;

	public bool IsFulfilled
	{
		get
		{
			bool result = false;
			if (TargetFilter.ThresholdReceived > 0 && TargetFilter.Received >= TargetFilter.ThresholdReceived)
			{
				result = true;
			}
			else if (TargetFilter.ThresholdSent > 0 && TargetFilter.Sent >= TargetFilter.ThresholdSent)
			{
				result = true;
			}
			return result;
		}
	}

	public bool postEvent
	{
		get
		{
			if (BaseUnit.OnboardCargo.Count() > 0)
			{
				if (TargetFilter.Received >= TargetFilter.ThresholdReceived)
				{
					TargetFilter.Received -= TargetFilter.ThresholdReceived;
				}
				if (TargetFilter.Sent >= TargetFilter.ThresholdSent)
				{
					TargetFilter.Sent -= TargetFilter.ThresholdSent;
				}
			}
			return true;
		}
	}

	public void updateTrigger()
	{
		int num = 0;
		int num2 = 0;
		while (num < Scenario.CargoMovement.Count)
		{
			num2 = Scenario.CargoMovement.FindIndex(num, Scenario.CargoMovement.Count - num, (Tuple<string, CargoTracker> tuple_0) => Operators.CompareString(tuple_0.Item1, BaseUnit.ObjectID, TextCompare: false) == 0);
			if (num2 != -1)
			{
				cargotrk = Scenario.CargoMovement.ElementAt(num2).Item2;
				if (TargetFilter.MatchesThisCargo(cargotrk._cargo))
				{
					TargetFilter.Received += cargotrk._loaded;
					TargetFilter.Sent += cargotrk._unloaded;
				}
				num = num2 + 1;
				continue;
			}
			break;
		}
	}

	public EventTrigger_UnitCargoMoved()
	{
		TargetFilter = new CargoFilterObject();
		Type = EventTriggerType.UnitCargoMoved;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("EventTrigger_UnitCargoMoved");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteStartElement("CargoFilter");
			TargetFilter.ToXML(xmlWriter_0, hashSet_0, scenario_0);
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteElementString("BaseUnit", BaseUnit.ObjectID);
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100530", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_UnitCargoMoved FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			EventTrigger_UnitCargoMoved eventTrigger_UnitCargoMoved = new EventTrigger_UnitCargoMoved();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "ID":
						eventTrigger_UnitCargoMoved.ObjectID_Set(xmlNode.InnerText);
						break;
					case "Description":
						eventTrigger_UnitCargoMoved.Description = xmlNode.InnerText;
						break;
					case "CargoFilter":
						eventTrigger_UnitCargoMoved.TargetFilter = CargoFilterObject.FromXML(xmlNode, concurrentDictionary_0, scenario_0);
						break;
					case "BaseUnit":
						eventTrigger_UnitCargoMoved.BaseUnit = scenario_0.ActiveUnits[xmlNode.InnerText];
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
			return eventTrigger_UnitCargoMoved;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100531", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			EventTrigger_UnitCargoMoved result = new EventTrigger_UnitCargoMoved();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override EventTrigger Clone()
	{
		EventTrigger_UnitCargoMoved obj = (EventTrigger_UnitCargoMoved)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		obj.TargetFilter = TargetFilter.Clone();
		return obj;
	}

	[CompilerGenerated]
	private bool FlushRepository(Tuple<string, CargoTracker> tuple_0)
	{
		return Operators.CompareString(tuple_0.Item1, BaseUnit.ObjectID, TextCompare: false) == 0;
	}
}
