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

public sealed class EventTrigger_UnitEntersArea : EventTrigger
{
	public UnitFilterObject TargetFilter;

	public List<ReferencePoint> Area;

	public DateTime dateTime_0;

	public DateTime dateTime_1;

	public bool Modifier_NOT;

	public bool Modifier_EXIT;

	public bool Modifer_ExcludeCargo;

	public ActiveUnit CulpritUnit;

	public bool LeavesArea;

	public bool NotInArea;

	public bool JustEnteredArea;

	[SpecialName]
	public bool GetIsFulfilled(Scenario scenario_0)
	{
		try
		{
			bool flag = false;
			LeavesArea = false;
			JustEnteredArea = false;
			NotInArea = true;
			if (scenario_0.Time.CompareTo(dateTime_0) < 0)
			{
				return false;
			}
			if (scenario_0.Time.CompareTo(dateTime_1) <= 0)
			{
				ActiveUnit activeUnit = null;
				foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
				{
					if (activeUnits_ == null || !TargetFilter.MatchesThisUnit(activeUnits_))
					{
						continue;
					}
					if (activeUnits_.GetIsInsideThisArea(Area, scenario_0, bool_0: false))
					{
						NotInArea = false;
						bool flag2 = false;
						foreach (string activeEnterAreaTrigger in activeUnits_.ActiveEnterAreaTriggers)
						{
							if (string.CompareOrdinal(activeEnterAreaTrigger, ObjectID) == 0)
							{
								flag2 = true;
								break;
							}
						}
						if (!flag2 && activeUnits_.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
						{
							continue;
						}
						if (flag2)
						{
							if (activeUnits_.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
							{
								activeUnits_.Longitude__UnitEntersAreaCheck = null;
								activeUnits_.Latitude__UnitEntersAreaCheck = null;
								if (activeUnits_.ActiveEnterAreaTriggers.FirstOrDefault((string string_0) => Operators.CompareString(string_0, ObjectID, TextCompare: false) == 0) != null)
								{
									if (Modifier_EXIT)
									{
										activeUnit = activeUnits_;
										LeavesArea = true;
										break;
									}
									activeUnits_.ActiveEnterAreaTriggers.Remove(ObjectID);
								}
								continue;
							}
							string[] array = activeUnits_.ActiveEnterAreaTriggers.ToArray();
							if (array.Count() <= 1)
							{
								continue;
							}
							string[] array2 = array;
							string[] array3 = array2;
							foreach (string text in array3)
							{
								if (!scenario_0.EventTriggers.ContainsKey(text))
								{
									activeUnits_.ActiveEnterAreaTriggers.Remove(text);
								}
							}
							continue;
						}
						JustEnteredArea = true;
						if (!activeUnits_.Longitude__UnitEntersAreaCheck.HasValue && !activeUnits_.Latitude__UnitEntersAreaCheck.HasValue)
						{
							activeUnit = activeUnits_;
							break;
						}
						activeUnits_.Longitude__UnitEntersAreaCheck = null;
						activeUnits_.Latitude__UnitEntersAreaCheck = null;
						break;
					}
					activeUnits_.Longitude__UnitEntersAreaCheck = null;
					activeUnits_.Latitude__UnitEntersAreaCheck = null;
					if (activeUnits_.ActiveEnterAreaTriggers.FirstOrDefault((string string_0) => Operators.CompareString(string_0, ObjectID, TextCompare: false) == 0) != null)
					{
						if (Modifier_EXIT)
						{
							activeUnit = activeUnits_;
							LeavesArea = true;
							break;
						}
						activeUnits_.ActiveEnterAreaTriggers.Remove(ObjectID);
					}
				}
				if (activeUnit == null)
				{
					if (NotInArea && Modifier_NOT)
					{
						flag = true;
					}
				}
				else
				{
					flag = (Modifier_EXIT & LeavesArea) || (!Modifier_EXIT & JustEnteredArea) || ((Modifier_EXIT & JustEnteredArea) ? true : false);
				}
				if (flag && activeUnit != null)
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
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100532", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return false;
	}

	public EventTrigger_UnitEntersArea()
	{
		TargetFilter = new UnitFilterObject();
		Area = new List<ReferencePoint>();
		Modifer_ExcludeCargo = true;
		LeavesArea = false;
		NotInArea = false;
		JustEnteredArea = false;
		Type = EventTriggerType.UnitEntersArea;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("EventTrigger_UnitEntersArea");
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
			xmlWriter_0.WriteElementString("ETOA", dateTime_0.ToBinary().ToString());
			xmlWriter_0.WriteElementString("LTOA", dateTime_1.ToBinary().ToString());
			if (Modifier_NOT)
			{
				xmlWriter_0.WriteElementString("NOT", 1.ToString());
			}
			if (Modifier_EXIT)
			{
				xmlWriter_0.WriteElementString("ExitArea", 1.ToString());
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100533", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static EventTrigger_UnitEntersArea FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		EventTrigger_UnitEntersArea result = null;
		try
		{
			EventTrigger_UnitEntersArea eventTrigger_UnitEntersArea = new EventTrigger_UnitEntersArea();
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
					case "Area":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
								eventTrigger_UnitEntersArea.Area.Add(ReferencePoint.FromXML(ref xmlNode_, ref concurrentDictionary_0));
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
					case "ExitArea":
						eventTrigger_UnitEntersArea.Modifier_EXIT = true;
						break;
					case "ID":
						eventTrigger_UnitEntersArea.ObjectID_Set(xmlNode.InnerText);
						break;
					case "LTOA":
						eventTrigger_UnitEntersArea.dateTime_1 = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
						break;
					case "NOT":
						eventTrigger_UnitEntersArea.Modifier_NOT = true;
						break;
					case "Description":
						eventTrigger_UnitEntersArea.Description = xmlNode.InnerText;
						break;
					case "TargetFilter":
						eventTrigger_UnitEntersArea.TargetFilter = UnitFilterObject.FromXML(xmlNode, concurrentDictionary_0, scenario_0);
						break;
					case "ETOA":
						eventTrigger_UnitEntersArea.dateTime_0 = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
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
			result = eventTrigger_UnitEntersArea;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100534", "");
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
		EventTrigger_UnitEntersArea obj = (EventTrigger_UnitEntersArea)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		obj.TargetFilter = TargetFilter.Clone();
		obj.Area = Area.GetRange(0, Area.Count);
		return obj;
	}

	[CompilerGenerated]
	private bool OrderRepository(string string_0)
	{
		return Operators.CompareString(string_0, ObjectID, TextCompare: false) == 0;
	}

	[CompilerGenerated]
	private bool RegisterRepository(string string_0)
	{
		return Operators.CompareString(string_0, ObjectID, TextCompare: false) == 0;
	}
}
