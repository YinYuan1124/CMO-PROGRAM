using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Command_Core.Lua;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_UnitBaseStatus : EventTrigger
{
	public UnitFilterObject TargetFilter;

	public object TargetCondition;

	public ActiveUnit CulpritUnit;

	public string TargetBase;

	[SpecialName]
	public bool GetIsFulfilled(ActiveUnit activeUnit_0, object object_0)
	{
		bool flag = false;
		GlobalVariables.ActiveUnitType unitType = activeUnit_0.UnitType;
		if (TargetBase != null && TargetBase.Length > 0)
		{
			string text = null;
			switch (unitType)
			{
			case GlobalVariables.ActiveUnitType.Ship:
			case GlobalVariables.ActiveUnitType.Submarine:
				if (activeUnit_0.DockingOps.CurrentHostUnit == null)
				{
					if (activeUnit_0.DockingOps.GetAssignedHostUnit() != null)
					{
					}
				}
				else
				{
					text = activeUnit_0.DockingOps.CurrentHostUnit.ObjectID;
				}
				break;
			case GlobalVariables.ActiveUnitType.Aircraft:
				if (((Aircraft_AirOps)activeUnit_0.AirOps).CurrentHostUnit == null)
				{
					((Aircraft_AirOps)activeUnit_0.AirOps).GetAssignedHostUnit();
				}
				else
				{
					text = ((Aircraft_AirOps)activeUnit_0.AirOps).CurrentHostUnit.ObjectID;
				}
				break;
			}
			if (text != null)
			{
				ActiveUnit activeUnit = PrivateMethods.smethod_0(TargetBase, activeUnit_0.ParentScen);
				if (Operators.CompareString(text, activeUnit.ObjectID, TextCompare: false) != 0)
				{
					return false;
				}
			}
		}
		if (TargetFilter.MatchesThisUnit(activeUnit_0))
		{
			if (TargetCondition == null)
			{
				flag = false;
			}
			else
			{
				switch (activeUnit_0.UnitType)
				{
				case GlobalVariables.ActiveUnitType.Ship:
				case GlobalVariables.ActiveUnitType.Submarine:
					if ((uint)activeUnit_0.DockingOps.Condition == Conversions.ToByte(TargetCondition))
					{
						flag = true;
					}
					break;
				case GlobalVariables.ActiveUnitType.Aircraft:
					if ((uint)((Aircraft_AirOps)activeUnit_0.AirOps).Condition == Conversions.ToByte(TargetCondition))
					{
						flag = true;
					}
					break;
				}
			}
		}
		else
		{
			flag = false;
		}
		if (flag)
		{
			CulpritUnit = activeUnit_0;
		}
		return flag;
	}

	public EventTrigger_UnitBaseStatus()
	{
		TargetFilter = new UnitFilterObject();
		TargetBase = null;
		Type = EventTriggerType.UnitBaseStatus;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("EventTrigger_UnitBaseStatus");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteStartElement("TargetFilter");
			TargetFilter.ToXML(xmlWriter_0, hashSet_0, scenario_0);
			xmlWriter_0.WriteEndElement();
			if (TargetCondition != null)
			{
				xmlWriter_0.WriteElementString("TargetCondition", Conversions.ToByte(TargetCondition).ToString());
			}
			if (TargetBase != null)
			{
				xmlWriter_0.WriteElementString("TargetBase", TargetBase);
			}
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

	public static EventTrigger_UnitBaseStatus FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			EventTrigger_UnitBaseStatus eventTrigger_UnitBaseStatus = new EventTrigger_UnitBaseStatus();
			object obj = null;
			eventTrigger_UnitBaseStatus.TargetCondition = null;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "TargetFilter":
						eventTrigger_UnitBaseStatus.TargetFilter = UnitFilterObject.FromXML(xmlNode, concurrentDictionary_0, scenario_0);
						break;
					case "TargetCondition":
						obj = xmlNode.InnerText;
						break;
					case "TargetBase":
						eventTrigger_UnitBaseStatus.TargetBase = xmlNode.InnerText;
						break;
					case "ID":
						eventTrigger_UnitBaseStatus.ObjectID_Set(xmlNode.InnerText);
						break;
					case "Description":
						eventTrigger_UnitBaseStatus.Description = xmlNode.InnerText;
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
			if (obj != null)
			{
				switch (eventTrigger_UnitBaseStatus.TargetFilter.TargetType)
				{
				case GlobalVariables.ActiveUnitType.Ship:
				case GlobalVariables.ActiveUnitType.Submarine:
				{
					if (Enum.TryParse<ActiveUnit_DockingOps._DockingOpsCondition>(Conversions.ToString(obj), out var result2) & Enum.IsDefined(typeof(ActiveUnit_DockingOps._DockingOpsCondition), result2))
					{
						eventTrigger_UnitBaseStatus.TargetCondition = (byte)result2;
					}
					break;
				}
				case GlobalVariables.ActiveUnitType.Aircraft:
				{
					if (Enum.TryParse<Aircraft_AirOps._AirOpsCondition>(Conversions.ToString(obj), out var result) & Enum.IsDefined(typeof(Aircraft_AirOps._AirOpsCondition), result))
					{
						eventTrigger_UnitBaseStatus.TargetCondition = (byte)result;
					}
					break;
				}
				}
			}
			CMANO.LuaTriggers.AddOpsHandler();
			return eventTrigger_UnitBaseStatus;
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
			EventTrigger_UnitBaseStatus result3 = new EventTrigger_UnitBaseStatus();
			ProjectData.ClearProjectError();
			return result3;
		}
	}

	public override EventTrigger Clone()
	{
		EventTrigger_UnitBaseStatus obj = (EventTrigger_UnitBaseStatus)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		obj.TargetFilter = TargetFilter.Clone();
		obj.TargetBase = TargetBase;
		return obj;
	}
}
