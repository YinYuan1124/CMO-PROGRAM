using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventTrigger_UnitRemainsInArea : EventTrigger
{
	public UnitFilterObject TargetFilter;

	public List<ReferencePoint> Area;

	public long TimeDuration;

	private double _SchemaClient;

	public ActiveUnit CulpritUnit;

	public DateTime? URIA_StartTime;

	[SpecialName]
	public bool GetIsFulfilled(Scenario scenario_0, float float_0)
	{
		try
		{
			bool flag = false;
			ActiveUnit activeUnit = null;
			List<ActiveUnit> list = new List<ActiveUnit>();
			foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
			{
				if (activeUnits_ != null)
				{
					if (activeUnits_.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo && TargetFilter.MatchesThisUnit(activeUnits_) && activeUnits_.GetIsInsideThisArea(Area, scenario_0, bool_0: false))
					{
						activeUnit = activeUnits_;
						list.Add(activeUnits_);
					}
					if ((activeUnit == null || Operators.CompareString(activeUnit.ObjectID, activeUnits_.ObjectID, TextCompare: false) != 0) && activeUnits_.ActiveRemainAreaTriggers.ContainsKey(ObjectID))
					{
						activeUnits_.ActiveRemainAreaTriggers.Remove(ObjectID);
					}
				}
			}
			if (list.Count > 1)
			{
				Misc.Shuffle(list);
				activeUnit = list[0];
			}
			if (activeUnit == null)
			{
				_SchemaClient = 0.0;
				URIA_StartTime = null;
				flag = false;
			}
			else
			{
				if (activeUnit.ActiveRemainAreaTriggers.ContainsKey_NoLock(ObjectID))
				{
					URIA_StartTime = activeUnit.ActiveRemainAreaTriggers[ObjectID];
				}
				else
				{
					URIA_StartTime = null;
				}
				if (!URIA_StartTime.HasValue)
				{
					if (_SchemaClient <= 0.0)
					{
						URIA_StartTime = scenario_0.Time;
					}
					else
					{
						URIA_StartTime = new DateTime(scenario_0.Time.Year, scenario_0.Time.Month, scenario_0.Time.Day, scenario_0.Time.Hour, scenario_0.Time.Minute, scenario_0.Time.Second).AddSeconds(-1.0 * _SchemaClient);
					}
					activeUnit.ActiveRemainAreaTriggers.AddIfNotExistsElseUpdate(ObjectID, URIA_StartTime.Value);
				}
				_SchemaClient = (scenario_0.Time - URIA_StartTime.Value).TotalSeconds;
				if (_SchemaClient < (double)TimeDuration)
				{
					_SchemaClient = 0.0;
					flag = false;
				}
				else
				{
					_SchemaClient = 0.0;
					activeUnit.ActiveRemainAreaTriggers.Remove(ObjectID);
					URIA_StartTime = null;
					flag = true;
				}
			}
			if (flag & !Information.IsNothing(activeUnit))
			{
				CulpritUnit = activeUnit;
				activeUnit.ParentScen.Scenario_LuaSandbox.UnitX = activeUnit;
			}
			else
			{
				CulpritUnit = null;
			}
			return flag;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100535", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public EventTrigger_UnitRemainsInArea()
	{
		TargetFilter = new UnitFilterObject();
		Area = new List<ReferencePoint>();
		URIA_StartTime = null;
		Type = EventTriggerType.UnitRemainsInArea;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("EventTrigger_UnitRemainsInArea");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteStartElement("TargetFilter");
			TargetFilter.ToXML(xmlWriter_0, hashSet_0, scenario_0);
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Area");
			foreach (ReferencePoint item in Area)
			{
				xmlWriter_0.WriteRaw(item.ToXML(ref hashSet_0));
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteElementString("TD", TimeDuration.ToString());
			xmlWriter_0.WriteElementString("TA", _SchemaClient.ToString());
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100536", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_UnitRemainsInArea FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			EventTrigger_UnitRemainsInArea eventTrigger_UnitRemainsInArea = new EventTrigger_UnitRemainsInArea();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "TD":
						eventTrigger_UnitRemainsInArea.TimeDuration = XmlConvert.ToInt64(xmlNode.InnerText);
						break;
					case "TargetFilter":
						eventTrigger_UnitRemainsInArea.TargetFilter = UnitFilterObject.FromXML(xmlNode, concurrentDictionary_0, scenario_0);
						break;
					case "TA":
						eventTrigger_UnitRemainsInArea._SchemaClient = XmlConvert.ToDouble(xmlNode.InnerText.Replace(",", "."));
						break;
					case "ID":
						eventTrigger_UnitRemainsInArea.ObjectID_Set(xmlNode.InnerText);
						break;
					case "Description":
						eventTrigger_UnitRemainsInArea.Description = xmlNode.InnerText;
						break;
					case "Area":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
								eventTrigger_UnitRemainsInArea.Area.Add(ReferencePoint.FromXML(ref xmlNode_, ref concurrentDictionary_0));
							}
						}
						finally
						{
							if (enumerator2 is IDisposable)
							{
								(enumerator2 as IDisposable).Dispose();
							}
						}
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
			return eventTrigger_UnitRemainsInArea;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100537", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			EventTrigger_UnitRemainsInArea result = new EventTrigger_UnitRemainsInArea();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override EventTrigger Clone()
	{
		EventTrigger_UnitRemainsInArea obj = (EventTrigger_UnitRemainsInArea)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		obj.TargetFilter = TargetFilter.Clone();
		obj.Area = Area.GetRange(0, Area.Count);
		return obj;
	}
}
