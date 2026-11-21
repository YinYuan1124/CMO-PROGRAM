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

public sealed class EventTrigger_UnitDestroyed : EventTrigger
{
	public UnitFilterObject TargetFilter;

	public ActiveUnit DestroyedUnit;

	public ActiveUnit DamagingUnit;

	[SpecialName]
	public bool GetIsFulfilled(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1 = null)
	{
		bool result;
		if (result = TargetFilter.MatchesThisUnit(activeUnit_0))
		{
			DamagingUnit = null;
			DestroyedUnit = activeUnit_0;
			activeUnit_0.ParentScen.Scenario_LuaSandbox.UnitX = activeUnit_0;
			if (activeUnit_1 != null)
			{
				DamagingUnit = activeUnit_1;
				activeUnit_0.ParentScen.Scenario_LuaSandbox.UnitY = activeUnit_1;
				return result;
			}
			if (activeUnit_0.Damage.LastWeaponHit != null)
			{
				DamagingUnit = activeUnit_0.Damage.LastWeaponHit;
				activeUnit_0.ParentScen.Scenario_LuaSandbox.UnitY = activeUnit_0.Damage.LastWeaponHit;
				return result;
			}
		}
		else
		{
			DestroyedUnit = null;
		}
		return result;
	}

	[SpecialName]
	public bool GetIsFulfilled(UnguidedWeapon unguidedWeapon_0, ActiveUnit activeUnit_0 = null)
	{
		bool result;
		if (result = TargetFilter.MatchesThisUnit(unguidedWeapon_0))
		{
			DamagingUnit = null;
			DestroyedUnit = LuaSandBox.Singleton().MakeActiveUnitOfUnguidedWeapon(unguidedWeapon_0);
			DestroyedUnit.ParentScen.Scenario_LuaSandbox.UnitX = unguidedWeapon_0;
			if (activeUnit_0 != null)
			{
				DamagingUnit = activeUnit_0;
				DestroyedUnit.ParentScen.Scenario_LuaSandbox.UnitY = activeUnit_0;
				return result;
			}
		}
		else
		{
			DestroyedUnit = null;
		}
		return result;
	}

	public EventTrigger_UnitDestroyed()
	{
		TargetFilter = new UnitFilterObject();
		Type = EventTriggerType.UnitDestroyed;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("EventTrigger_UnitDestroyed");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteStartElement("TargetFilter");
			TargetFilter.ToXML(xmlWriter_0, hashSet_0, scenario_0);
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100528", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_UnitDestroyed FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			EventTrigger_UnitDestroyed eventTrigger_UnitDestroyed = new EventTrigger_UnitDestroyed();
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
						eventTrigger_UnitDestroyed.TargetFilter = UnitFilterObject.FromXML(xmlNode, concurrentDictionary_0, scenario_0);
						break;
					case "ID":
						eventTrigger_UnitDestroyed.ObjectID_Set(xmlNode.InnerText);
						break;
					case "Description":
						eventTrigger_UnitDestroyed.Description = xmlNode.InnerText;
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
			return eventTrigger_UnitDestroyed;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100529", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			EventTrigger_UnitDestroyed result = new EventTrigger_UnitDestroyed();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override EventTrigger Clone()
	{
		EventTrigger_UnitDestroyed obj = (EventTrigger_UnitDestroyed)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		obj.TargetFilter = TargetFilter.Clone();
		return obj;
	}
}
