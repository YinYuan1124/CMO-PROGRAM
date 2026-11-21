using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_UnitDamaged : EventTrigger
{
	public UnitFilterObject TargetFilter;

	public byte DamagePercent;

	public ActiveUnit DamagedUnit;

	public ActiveUnit DamagingUnit;

	[SpecialName]
	public bool GetIsFulfilled(ActiveUnit activeUnit_0, float float_0, float float_1, ActiveUnit activeUnit_1 = null)
	{
		bool flag = false;
		DamagedUnit = null;
		if (TargetFilter.MatchesThisUnit(activeUnit_0))
		{
			if (float_0 == float_1)
			{
				return false;
			}
			if (activeUnit_0.IsBeingDestroyed)
			{
				flag = true;
			}
			if (float_1 >= 100f && float_0 < (float)(int)DamagePercent)
			{
				flag = true;
			}
			if (float_0 < float_1 && (float_0 <= 0f || float_0 < (float)(int)DamagePercent) && float_1 >= (float)(int)DamagePercent)
			{
				flag = true;
			}
			if (flag)
			{
				DamagedUnit = activeUnit_0;
				activeUnit_0.ParentScen.Scenario_LuaSandbox.UnitX = activeUnit_0;
				if (activeUnit_1 == null)
				{
					DamagingUnit = null;
					activeUnit_0.ParentScen.Scenario_LuaSandbox.UnitY = null;
				}
				else
				{
					DamagingUnit = activeUnit_1;
					activeUnit_0.ParentScen.Scenario_LuaSandbox.UnitY = activeUnit_1;
				}
			}
			else
			{
				DamagedUnit = null;
			}
			return flag;
		}
		return false;
	}

	public EventTrigger_UnitDamaged()
	{
		TargetFilter = new UnitFilterObject();
		Type = EventTriggerType.UnitDamaged;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("EventTrigger_UnitDamaged");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteElementString("DamagePercent", DamagePercent.ToString());
			xmlWriter_0.WriteStartElement("TargetFilter");
			TargetFilter.ToXML(xmlWriter_0, hashSet_0, scenario_0);
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100526", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_UnitDamaged FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		EventTrigger_UnitDamaged result = null;
		try
		{
			EventTrigger_UnitDamaged eventTrigger_UnitDamaged = new EventTrigger_UnitDamaged();
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
						eventTrigger_UnitDamaged.TargetFilter = UnitFilterObject.FromXML(xmlNode, concurrentDictionary_0, scenario_0);
						break;
					case "ID":
						eventTrigger_UnitDamaged.ObjectID_Set(xmlNode.InnerText);
						break;
					case "Description":
						eventTrigger_UnitDamaged.Description = xmlNode.InnerText;
						break;
					case "DamagePercent":
						eventTrigger_UnitDamaged.DamagePercent = Conversions.ToByte(xmlNode.InnerText);
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
			result = eventTrigger_UnitDamaged;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100527", "");
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
		EventTrigger_UnitDamaged obj = (EventTrigger_UnitDamaged)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		obj.TargetFilter = TargetFilter.Clone();
		return obj;
	}
}
