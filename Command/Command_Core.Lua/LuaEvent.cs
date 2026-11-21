using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[StandardModule]
public sealed class LuaEvent
{
	public static readonly string[] Keyword_Triggers_Points;

	public static readonly string[] Keyword_Triggers_RandomTime;

	public static readonly string[] Keyword_Triggers_RegularTime;

	public static readonly string[] Keyword_Triggers_ScenEnded;

	public static readonly string[] Keyword_Triggers_ScenLoaded;

	public static readonly string[] Keyword_Triggers_Time;

	public static readonly string[] Keyword_Triggers_UnitDamaged;

	public static readonly string[] Keyword_Triggers_UnitDestroyed;

	public static readonly string[] Keyword_Triggers_UnitDetected;

	public static readonly string[] Keyword_Triggers_UnitEmissions;

	public static readonly string[] Keyword_Triggers_UnitEntersArea;

	public static readonly string[] Keyword_Triggers_UnitRemainsInArea;

	public static readonly string[] Keyword_Triggers_UnitBaseStatus;

	public static readonly string[] Keyword_Triggers_UnitCargoMoved;

	public static readonly string[] Keyword_Conditions_LuaScript;

	public static readonly string[] Keyword_Conditions_ScenHasStarted;

	public static readonly string[] Keyword_Conditions_SidePosture;

	public static readonly string[] Keyword_Actions_ChangeMissionStatus;

	public static readonly string[] Keyword_Actions_EndScenario;

	public static readonly string[] Keyword_Actions_LuaScript;

	public static readonly string[] Keyword_Actions_Message;

	public static readonly string[] Keyword_Actions_Points;

	public static readonly string[] Keyword_Actions_TeleportInArea;

	static LuaEvent()
	{
		Keyword_Triggers_Points = new string[7] { "Points", "EventTrigger_Points", "ID", "Description", "SideID", "PointValue", "ReachDirection" };
		Keyword_Triggers_RandomTime = new string[6] { "RandomTime", "EventTrigger_RandomTime", "ID", "Description", "EarliestTime", "LatestTime" };
		Keyword_Triggers_RegularTime = new string[5] { "RegularTime", "EventTrigger_RegularTime", "ID", "Description", "Interval" };
		Keyword_Triggers_ScenEnded = new string[4] { "ScenEnded", "EventTrigger_ScenEnded", "ID", "Description" };
		Keyword_Triggers_ScenLoaded = new string[4] { "ScenLoaded", "EventTrigger_ScenLoaded", "ID", "Description" };
		Keyword_Triggers_Time = new string[5] { "Time", "EventTrigger_Time", "ID", "Description", "Time" };
		Keyword_Triggers_UnitDamaged = new string[6] { "UnitDamaged", "EventTrigger_UnitDamaged", "ID", "Description", "DamagePercent", "TargetFilter" };
		Keyword_Triggers_UnitDestroyed = new string[5] { "UnitDestroyed", "EventTrigger_UnitDestroyed", "ID", "Description", "TargetFilter" };
		Keyword_Triggers_UnitDetected = new string[8] { "UnitDetected", "EventTrigger_UnitDetected", "ID", "Description", "Area", "TargetFilter", "DetectorSideID", "MCL" };
		Keyword_Triggers_UnitEmissions = new string[8] { "UnitEmissions", "EventTrigger_UnitEmissions", "ID", "Description", "Area", "TargetFilter", "DetectorSideID", "MCL" };
		Keyword_Triggers_UnitEntersArea = new string[10] { "UnitEntersArea", "EventTrigger_UnitEntersArea", "ID", "Description", "TargetFilter", "Area", "ETOA", "LTOA", "NOT", "ExitArea" };
		Keyword_Triggers_UnitRemainsInArea = new string[7] { "UnitRemainsInArea", "EventTrigger_UnitRemainsInArea", "ID", "Description", "TargetFilter", "Area", "TD" };
		Keyword_Triggers_UnitBaseStatus = new string[7] { "UnitBaseStatus", "EventTrigger_UnitBaseStatus", "ID", "Description", "TargetFilter", "TargetCondition", "TargetBase" };
		Keyword_Triggers_UnitCargoMoved = new string[6] { "UnitCargoMoved", "EventTrigger_UnitCargoMoved", "BaseUnit", "ID", "Description", "CargoFilter" };
		Keyword_Conditions_LuaScript = new string[5] { "LuaScript", "EventCondition_LuaScript", "ID", "Description", "ScriptText" };
		Keyword_Conditions_ScenHasStarted = new string[5] { "ScenHasStarted", "EventCondition_ScenHasStarted", "ID", "Description", "NOT" };
		Keyword_Conditions_SidePosture = new string[8] { "SidePosture", "EventCondition_SidePosture", "ID", "Description", "ObserverSideID", "TargetSideID", "TargetPosture", "NOT" };
		Keyword_Actions_ChangeMissionStatus = new string[6] { "ChangeMissionStatus", "EventAction_ChangeMissionStatus", "ID", "Description", "MissionID", "NewStatus" };
		Keyword_Actions_EndScenario = new string[3] { "EndScenario", "EventAction_EndScenario", "ID" };
		Keyword_Actions_LuaScript = new string[5] { "LuaScript", "EventAction_LuaScript", "ID", "Description", "ScriptText" };
		Keyword_Actions_Message = new string[6] { "Message", "EventAction_Message", "ID", "Description", "SideID", "Text" };
		Keyword_Actions_Points = new string[6] { "Points", "EventAction_Points", "ID", "Description", "SideID", "PointChange" };
		Keyword_Actions_TeleportInArea = new string[6] { "TeleportInArea", "EventAction_TeleportInArea", "ID", "Description", "UnitIDs", "Area" };
	}

	public static string ScenEdit_ExecuteEventAction(string string_0, Scenario scenario_0)
	{
		EventAction eventAction = null;
		string b = string_0.ToLower();
		foreach (EventAction value in scenario_0.EventActions.Values)
		{
			if (value.Type == EventAction.EventActionType.LuaScript && (string.Equals(value.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value.ObjectID, b, StringComparison.OrdinalIgnoreCase)))
			{
				eventAction = value;
				break;
			}
		}
		if (eventAction == null)
		{
			return null;
		}
		return ((EventAction_LuaScript)eventAction).ScriptText;
	}

	public static object ScenEdit_UpdateEvent(string string_0, LuaTable luaTable_0, Scenario scenario_0)
	{
		bool flag = false;
		try
		{
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			string text = string_0.ToLower();
			SimEvent simEvent = null;
			foreach (SimEvent value in scenario_0.SimEvents.Values)
			{
				if (string.Equals(value.Description, text, StringComparison.OrdinalIgnoreCase) || Operators.CompareString(value.ObjectID, text, TextCompare: false) == 0)
				{
					simEvent = value;
					break;
				}
			}
			if (Information.IsNothing(simEvent))
			{
				throw new LuaError("无法识别所需的事件！");
			}
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			string text2 = null;
			string text3 = null;
			if (dictionary.ContainsKey("Type".ToUpper()))
			{
				string text4 = null;
				try
				{
					text2 = dictionary["Type".ToUpper()].ToString();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					throw new LuaError("无法解析事件类型！");
				}
				switch (text2.ToUpper())
				{
				case "ADD_CONDITION":
				case "REMOVE_CONDITION":
				case "REPLACE_CONDITION":
				{
					EventCondition_LuaScript eventCondition_LuaScript = new EventCondition_LuaScript();
					switch (text2.ToUpper())
					{
					case "REPLACE_CONDITION":
					{
						EventCondition eventCondition = null;
						if (!dictionary.ContainsKey("Description".ToUpper()))
						{
							break;
						}
						try
						{
							text4 = dictionary["Description".ToUpper()].ToString();
						}
						catch (Exception projectError12)
						{
							ProjectData.SetProjectError(projectError12);
							throw new LuaError("无法解析事件描述！");
						}
						foreach (EventCondition value2 in scenario_0.EventConditions.Values)
						{
							if ((string.Equals(value2.Description, text4, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.ObjectID, text4, StringComparison.OrdinalIgnoreCase)) && value2 is EventCondition_LuaScript)
							{
								eventCondition = value2;
								break;
							}
						}
						if (eventCondition == null)
						{
							throw new LuaError("找不到事件条件！");
						}
						if (dictionary.ContainsKey("Script".ToUpper()))
						{
							try
							{
								text4 = dictionary["Script".ToUpper()].ToString();
							}
							catch (Exception projectError2)
							{
								ProjectData.SetProjectError(projectError2);
								throw new LuaError("无法解析事件脚本！");
							}
							eventCondition_LuaScript = (EventCondition_LuaScript)eventCondition;
							text3 = ((EventCondition_LuaScript)eventCondition).ScriptText;
							((EventCondition_LuaScript)eventCondition).ScriptText = text4;
							flag = true;
						}
						break;
					}
					case "REMOVE_CONDITION":
					{
						if (!dictionary.ContainsKey("Description".ToUpper()))
						{
							break;
						}
						EventCondition eventCondition2 = null;
						try
						{
							text4 = dictionary["Description".ToUpper()].ToString();
						}
						catch (Exception projectError3)
						{
							ProjectData.SetProjectError(projectError3);
							throw new LuaError("无法解析事件描述！");
						}
						foreach (EventCondition value3 in scenario_0.EventConditions.Values)
						{
							if ((string.Equals(value3.Description, text4, StringComparison.OrdinalIgnoreCase) || string.Equals(value3.ObjectID, text4, StringComparison.OrdinalIgnoreCase)) && value3 is EventCondition_LuaScript)
							{
								eventCondition2 = value3;
								break;
							}
						}
						if (eventCondition2 == null)
						{
							throw new LuaError("找不到事件条件！");
						}
						simEvent.Conditions.Remove(eventCondition2);
						scenario_0.EventConditions.Remove(eventCondition2.ObjectID);
						eventCondition_LuaScript = (EventCondition_LuaScript)eventCondition2;
						flag = true;
						break;
					}
					case "ADD_CONDITION":
						if (dictionary.ContainsKey("Description".ToUpper()))
						{
							try
							{
								text4 = dictionary["Description".ToUpper()].ToString();
							}
							catch (Exception projectError10)
							{
								ProjectData.SetProjectError(projectError10);
								throw new LuaError("无法解析事件描述！");
							}
							eventCondition_LuaScript.Description = text4;
						}
						if (dictionary.ContainsKey("Script".ToUpper()))
						{
							try
							{
								text4 = dictionary["Script".ToUpper()].ToString();
							}
							catch (Exception projectError11)
							{
								ProjectData.SetProjectError(projectError11);
								throw new LuaError("无法解析事件脚本！");
							}
							eventCondition_LuaScript.ScriptText = text4;
						}
						if (eventCondition_LuaScript.ScriptText != null)
						{
							simEvent.Conditions.Add(eventCondition_LuaScript);
							scenario_0.EventConditions.Add(eventCondition_LuaScript.ObjectID, eventCondition_LuaScript);
							flag = true;
						}
						break;
					}
					val["type"] = "CONDITION";
					val["description"] = eventCondition_LuaScript.Description;
					val["guid"] = eventCondition_LuaScript.ObjectID;
					if (text3 == null)
					{
						val["script"] = eventCondition_LuaScript.ScriptText;
					}
					else
					{
						val["script"] = text3;
					}
					break;
				}
				case "ADD_ACTION":
				case "REMOVE_ACTION":
				case "REPLACE_ACTION":
				{
					EventAction_LuaScript eventAction_LuaScript = new EventAction_LuaScript();
					switch (text2.ToUpper())
					{
					case "REPLACE_ACTION":
					{
						EventAction eventAction = null;
						if (!dictionary.ContainsKey("Description".ToUpper()))
						{
							break;
						}
						try
						{
							text4 = dictionary["Description".ToUpper()].ToString();
						}
						catch (Exception projectError7)
						{
							ProjectData.SetProjectError(projectError7);
							throw new LuaError("无法解析事件描述！");
						}
						foreach (EventAction value4 in scenario_0.EventActions.Values)
						{
							if ((string.Equals(value4.Description, text4, StringComparison.OrdinalIgnoreCase) || string.Equals(value4.ObjectID, text4, StringComparison.OrdinalIgnoreCase)) && value4 is EventAction_LuaScript)
							{
								eventAction = value4;
								break;
							}
						}
						if (eventAction == null)
						{
							throw new LuaError("找不到事件动作！");
						}
						if (dictionary.ContainsKey("Script".ToUpper()))
						{
							try
							{
								text4 = dictionary["Script".ToUpper()].ToString();
							}
							catch (Exception projectError8)
							{
								ProjectData.SetProjectError(projectError8);
								throw new LuaError("无法解析事件脚本！");
							}
							eventAction_LuaScript = (EventAction_LuaScript)eventAction;
							text3 = ((EventAction_LuaScript)eventAction).ScriptText;
							((EventAction_LuaScript)eventAction).ScriptText = text4;
							flag = true;
						}
						break;
					}
					case "REMOVE_ACTION":
					{
						EventAction eventAction2 = null;
						if (!dictionary.ContainsKey("Description".ToUpper()))
						{
							break;
						}
						try
						{
							text4 = dictionary["Description".ToUpper()].ToString();
						}
						catch (Exception projectError9)
						{
							ProjectData.SetProjectError(projectError9);
							throw new LuaError("无法解析事件描述！");
						}
						foreach (EventAction value5 in scenario_0.EventActions.Values)
						{
							if ((string.Equals(value5.Description, text4, StringComparison.OrdinalIgnoreCase) || string.Equals(value5.ObjectID, text4, StringComparison.OrdinalIgnoreCase)) && value5 is EventAction_LuaScript)
							{
								eventAction2 = value5;
								break;
							}
						}
						if (eventAction2 == null)
						{
							throw new LuaError("找不到事件动作！");
						}
						simEvent.Actions.Remove(eventAction2);
						scenario_0.EventActions.Remove(eventAction2.ObjectID);
						eventAction_LuaScript = (EventAction_LuaScript)eventAction2;
						flag = true;
						break;
					}
					case "ADD_ACTION":
						if (dictionary.ContainsKey("Description".ToUpper()))
						{
							try
							{
								text4 = dictionary["Description".ToUpper()].ToString();
							}
							catch (Exception projectError5)
							{
								ProjectData.SetProjectError(projectError5);
								throw new LuaError("无法解析事件描述！");
							}
							eventAction_LuaScript.Description = text4;
						}
						if (dictionary.ContainsKey("Script".ToUpper()))
						{
							try
							{
								text4 = dictionary["Script".ToUpper()].ToString();
							}
							catch (Exception projectError6)
							{
								ProjectData.SetProjectError(projectError6);
								throw new LuaError("无法解析事件脚本！");
							}
							eventAction_LuaScript.ScriptText = text4;
						}
						if (eventAction_LuaScript.ScriptText != null)
						{
							simEvent.Actions.Add(eventAction_LuaScript);
							scenario_0.EventActions.Add(eventAction_LuaScript.ObjectID, eventAction_LuaScript);
							flag = true;
						}
						break;
					}
					val["type"] = "ACTION";
					val["description"] = eventAction_LuaScript.Description;
					val["guid"] = eventAction_LuaScript.ObjectID;
					if (text3 == null)
					{
						val["script"] = eventAction_LuaScript.ScriptText;
					}
					else
					{
						val["script"] = text3;
					}
					break;
				}
				}
			}
			if (val.Keys.Count == 0)
			{
				return flag;
			}
			return val;
		}
		catch (Exception projectError4)
		{
			ProjectData.SetProjectError(projectError4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static LuaWrapper_Event ScenEdit_GetEvent(string string_0, int int_0, Scenario scenario_0)
	{
		try
		{
			new HashSet<string>();
			string b = string_0.ToLower();
			LuaSandBox.Singleton().CreateTable();
			bool bool_ = false;
			if (int_0 > 9)
			{
				bool_ = true;
				int_0 -= 10;
			}
			SimEvent simEvent = null;
			foreach (SimEvent value in scenario_0.SimEvents.Values)
			{
				if (string.Equals(value.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value.ObjectID, b, StringComparison.OrdinalIgnoreCase))
				{
					simEvent = value;
				}
			}
			if (simEvent == null)
			{
				return null;
			}
			return new LuaWrapper_Event(simEvent, int_0, bool_, scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static LuaTable ScenEdit_GetEvents(int int_0, Scenario scenario_0)
	{
		try
		{
			new HashSet<string>();
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			bool bool_ = false;
			if (int_0 > 9)
			{
				bool_ = true;
				int_0 -= 10;
			}
			foreach (SimEvent value in scenario_0.SimEvents.Values)
			{
				LuaWrapper_Event luaWrapper_Event = new LuaWrapper_Event(value, int_0, bool_, scenario_0);
				val[val.Keys.Count + 1] = luaWrapper_Event;
			}
			return val;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static bool ScenEdit_SetSpecialAction(LuaTable luaTable_0, Scenario scenario_0)
	{
		try
		{
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			if (dictionary.ContainsKey("ActionNameOrID".ToUpper()))
			{
				string b = dictionary["ActionNameOrID".ToUpper()].ToString();
				Side side = null;
				if (dictionary.ContainsKey("SIDE"))
				{
					string text = Conversions.ToString(dictionary["SIDE"]);
					try
					{
						side = LuaUtility.QuerySide(dictionary, scenario_0);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						throw new LuaError("找不到分方'" + text + "'");
					}
				}
				SpecialAction specialAction = null;
				if (side == null)
				{
					Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
					Side[] array = sides_ReadOnly;
					foreach (Side side2 in array)
					{
						foreach (SpecialAction value in side2.SpecialActions.Values)
						{
							if (string.Equals(value.Name, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value.ObjectID, b, StringComparison.OrdinalIgnoreCase))
							{
								specialAction = value;
								side = side2;
								break;
							}
						}
					}
				}
				else
				{
					foreach (SpecialAction value2 in side.SpecialActions.Values)
					{
						if (string.Equals(value2.Name, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.ObjectID, b, StringComparison.OrdinalIgnoreCase))
						{
							specialAction = value2;
							break;
						}
					}
				}
				if (Information.IsNothing(specialAction))
				{
					throw new LuaError("无法确定所需的特殊行动！");
				}
				if (dictionary.ContainsKey("NewName".ToUpper()))
				{
					string name;
					try
					{
						name = dictionary["NewName".ToUpper()].ToString();
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						throw new LuaError("无法将值NewName解析为字符串！");
					}
					specialAction.Name = name;
				}
				if (dictionary.ContainsKey("Description".ToUpper()))
				{
					string description;
					try
					{
						description = dictionary["Description".ToUpper()].ToString();
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						throw new LuaError("无法将值描述解析为字符串！");
					}
					specialAction.Description = description;
				}
				if (dictionary.ContainsKey("IsActive".ToUpper()))
				{
					bool isActive;
					try
					{
						isActive = Conversions.ToBoolean(dictionary["IsActive".ToUpper()].ToString());
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						throw new LuaError("Unable to parse value IsActive to true/false!");
					}
					specialAction.IsActive = isActive;
				}
				if (dictionary.ContainsKey("IsRepeatable".ToUpper()))
				{
					bool isRepeatable;
					try
					{
						isRepeatable = Conversions.ToBoolean(dictionary["IsRepeatable".ToUpper()].ToString());
					}
					catch (Exception projectError5)
					{
						ProjectData.SetProjectError(projectError5);
						throw new LuaError("Unable to parse IsRepeatable to true/false!");
					}
					specialAction.IsRepeatable = isRepeatable;
				}
				if (dictionary.ContainsKey("ScriptText".ToUpper()))
				{
					string scriptText;
					try
					{
						scriptText = dictionary["ScriptText".ToUpper()].ToString();
					}
					catch (Exception projectError6)
					{
						ProjectData.SetProjectError(projectError6);
						throw new LuaError("Unable to parse value Script to string!");
					}
					specialAction.ScriptText = scriptText;
				}
				if (dictionary.ContainsKey("Mode".ToUpper()))
				{
					string a;
					try
					{
						a = dictionary["Mode".ToUpper()].ToString();
					}
					catch (Exception projectError7)
					{
						ProjectData.SetProjectError(projectError7);
						throw new LuaError("Unable to parse value Mode to string!");
					}
					if (string.Equals(a, "remove", StringComparison.OrdinalIgnoreCase))
					{
						side.SpecialActions.Remove(specialAction.ObjectID);
					}
				}
				return true;
			}
			throw new LuaError("缺少必需变量'ActionNameOrID'");
		}
		catch (Exception projectError8)
		{
			ProjectData.SetProjectError(projectError8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static bool ScenEdit_AddSpecialAction(LuaTable luaTable_0, Scenario scenario_0)
	{
		try
		{
			Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			LuaUtility.ParseUnitDict(ref dictionary_);
			if (dictionary_.ContainsKey("SIDE"))
			{
				Side side = null;
				if (dictionary_.ContainsKey("SIDE"))
				{
					string text = Conversions.ToString(dictionary_["SIDE"]);
					try
					{
						side = LuaUtility.QuerySide(dictionary_, scenario_0);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						throw new LuaError("找不到分方'" + text + "'");
					}
				}
				if (dictionary_.ContainsKey("ActionNameOrID".ToUpper()))
				{
					string text2 = dictionary_["ActionNameOrID".ToUpper()].ToString();
					SpecialAction specialAction = null;
					foreach (SpecialAction value in side.SpecialActions.Values)
					{
						if (string.Equals(value.Name, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
						{
							specialAction = value;
						}
					}
					if (specialAction == null)
					{
						specialAction = new SpecialAction();
						specialAction.Name = text2;
						if (dictionary_.ContainsKey("Description".ToUpper()))
						{
							string description;
							try
							{
								description = dictionary_["Description".ToUpper()].ToString();
							}
							catch (Exception projectError2)
							{
								ProjectData.SetProjectError(projectError2);
								throw new LuaError("无法将值描述解析为字符串！");
							}
							specialAction.Description = description;
						}
						if (dictionary_.ContainsKey("IsActive".ToUpper()))
						{
							bool isActive;
							try
							{
								isActive = Conversions.ToBoolean(dictionary_["IsActive".ToUpper()].ToString());
							}
							catch (Exception projectError3)
							{
								ProjectData.SetProjectError(projectError3);
								throw new LuaError("Unable to parse value IsActive to true/false!");
							}
							specialAction.IsActive = isActive;
						}
						if (dictionary_.ContainsKey("IsRepeatable".ToUpper()))
						{
							bool isRepeatable;
							try
							{
								isRepeatable = Conversions.ToBoolean(dictionary_["IsRepeatable".ToUpper()].ToString());
							}
							catch (Exception projectError4)
							{
								ProjectData.SetProjectError(projectError4);
								throw new LuaError("Unable to parse IsRepeatable to true/false!");
							}
							specialAction.IsRepeatable = isRepeatable;
						}
						if (dictionary_.ContainsKey("ScriptText".ToUpper()))
						{
							string scriptText;
							try
							{
								scriptText = dictionary_["ScriptText".ToUpper()].ToString();
							}
							catch (Exception projectError5)
							{
								ProjectData.SetProjectError(projectError5);
								throw new LuaError("Unable to parse value Script to string!");
							}
							specialAction.ScriptText = scriptText;
						}
						side.SpecialActions.Add(specialAction.ObjectID, specialAction);
						return true;
					}
					throw new LuaError("Special Action exists (" + text2 + ")!");
				}
				throw new LuaError("缺少必需变量'ActionNameOrID'");
			}
			throw new LuaError("Missing mandatory variable 'Side'");
		}
		catch (Exception projectError6)
		{
			ProjectData.SetProjectError(projectError6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static LuaTable ScenEdit_GetSpecialAction(LuaTable luaTable_0, Scenario scenario_0)
	{
		try
		{
			Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			LuaUtility.ParseUnitDict(ref dictionary_);
			Side side = null;
			if (dictionary_.ContainsKey("SIDE"))
			{
				string text = Conversions.ToString(dictionary_["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary_, scenario_0);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					throw new LuaError("找不到分方'" + text + "'");
				}
			}
			SpecialAction specialAction = null;
			if (dictionary_.ContainsKey("Mode".ToUpper()))
			{
				string a;
				try
				{
					a = dictionary_["Mode".ToUpper()].ToString();
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					throw new LuaError("Unable to parse value Mode to string!");
				}
				if (string.Equals(a, "list", StringComparison.OrdinalIgnoreCase))
				{
					LuaTable val = LuaSandBox.Singleton().CreateTable();
					Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
					Side[] array = sides_ReadOnly;
					foreach (Side side2 in array)
					{
						if (side != null && Operators.CompareString(side.ObjectID, side2.ObjectID, TextCompare: false) != 0)
						{
							continue;
						}
						foreach (SpecialAction value in side2.SpecialActions.Values)
						{
							LuaTable val2 = LuaSandBox.Singleton().CreateTable();
							val2["guid"] = value.ObjectID;
							val2["name"] = value.Name;
							val2["description"] = value.Description;
							val2["isActive"] = value.IsActive;
							val2["IsRepeatable"] = value.IsRepeatable;
							val2["ScriptText"] = value.ScriptText;
							val2["side"] = side2.ObjectID;
							val[val.Keys.Count + 1] = val2;
						}
					}
					return val;
				}
			}
			if (dictionary_.ContainsKey("ActionNameOrID".ToUpper()))
			{
				string b = dictionary_["ActionNameOrID".ToUpper()].ToString().ToUpper();
				if (side == null)
				{
					Side[] sides_ReadOnly2 = scenario_0.Sides_ReadOnly;
					Side[] array2 = sides_ReadOnly2;
					foreach (Side side3 in array2)
					{
						foreach (SpecialAction value2 in side3.SpecialActions.Values)
						{
							if (string.Equals(value2.Name, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.ObjectID, b, StringComparison.OrdinalIgnoreCase))
							{
								specialAction = value2;
								side = side3;
								break;
							}
						}
					}
				}
				else
				{
					foreach (SpecialAction value3 in side.SpecialActions.Values)
					{
						if (string.Equals(value3.Name, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value3.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value3.ObjectID, b, StringComparison.OrdinalIgnoreCase))
						{
							specialAction = value3;
							break;
						}
					}
				}
				if (Information.IsNothing(specialAction))
				{
					throw new LuaError("无法确定所需的特殊行动！");
				}
				LuaTable obj = LuaSandBox.Singleton().CreateTable();
				obj["guid"] = specialAction.ObjectID;
				obj["name"] = specialAction.Name;
				obj["description"] = specialAction.Description;
				obj["isActive"] = specialAction.IsActive;
				obj["IsRepeatable"] = specialAction.IsRepeatable;
				obj["ScriptText"] = specialAction.ScriptText;
				obj["side"] = side.ObjectID;
				return obj;
			}
			throw new LuaError("缺少必需变量'ActionNameOrID'");
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static string ScenEdit_ExecuteSpecialAction(string string_0, Scenario scenario_0)
	{
		string text = string_0.ToLower();
		SpecialAction specialAction = null;
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		for (int i = 0; i < sides_ReadOnly.Length; i++)
		{
			foreach (SpecialAction value in sides_ReadOnly[i].SpecialActions.Values)
			{
				if (string.Equals(value.Name, text, StringComparison.OrdinalIgnoreCase) || string.Equals(value.Description, text, StringComparison.OrdinalIgnoreCase) || Operators.CompareString(value.ObjectID, text, TextCompare: false) == 0)
				{
					specialAction = value;
				}
			}
		}
		return specialAction?.ScriptText;
	}

	public static object ScenEdit_SetEvent(string string_0, LuaTable luaTable_0, Scenario scenario_0)
	{
		try
		{
			new HashSet<string>();
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			string b = string_0.ToLower();
			string text = "update";
			SimEvent simEvent = null;
			foreach (SimEvent value in scenario_0.SimEvents.Values)
			{
				if (string.Equals(value.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value.ObjectID, b, StringComparison.OrdinalIgnoreCase))
				{
					simEvent = value;
				}
			}
			if (dictionary.ContainsKey("mode".ToUpper()))
			{
				text = dictionary["mode".ToUpper()].ToString().ToLower();
			}
			switch (text)
			{
			default:
				throw new LuaError("未知的操作！");
			case "add":
			case "remove":
			case "update":
				if (Information.IsNothing(simEvent) && Operators.CompareString(text, "add", TextCompare: false) != 0)
				{
					throw new LuaError("无法识别所需的事件！");
				}
				if (Operators.CompareString(text, "add", TextCompare: false) == 0)
				{
					simEvent = new SimEvent();
					simEvent.Description = string_0;
				}
				if (dictionary.ContainsKey("NewName".ToUpper()))
				{
					string name;
					try
					{
						name = dictionary["NewName".ToUpper()].ToString();
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						throw new LuaError("无法将值NewName解析为字符串！");
					}
					simEvent.Name = name;
				}
				if (dictionary.ContainsKey("Description".ToUpper()))
				{
					string description;
					try
					{
						description = dictionary["Description".ToUpper()].ToString();
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						throw new LuaError("无法将值描述解析为字符串！");
					}
					simEvent.Description = description;
				}
				if (dictionary.ContainsKey("IsActive".ToUpper()))
				{
					bool isActive;
					try
					{
						isActive = Conversions.ToBoolean(dictionary["IsActive".ToUpper()].ToString());
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						throw new LuaError("Unable to parse value IsActive to true/false!");
					}
					simEvent.IsActive = isActive;
				}
				if (dictionary.ContainsKey("IsShown".ToUpper()))
				{
					bool isShown;
					try
					{
						isShown = Conversions.ToBoolean(dictionary["IsShown".ToUpper()].ToString());
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						throw new LuaError("Unable to parse value IsShown to true/false!");
					}
					simEvent.IsShown = isShown;
				}
				if (dictionary.ContainsKey("IsRepeatable".ToUpper()))
				{
					bool isRepeatable;
					try
					{
						isRepeatable = Conversions.ToBoolean(dictionary["IsRepeatable".ToUpper()].ToString());
					}
					catch (Exception projectError5)
					{
						ProjectData.SetProjectError(projectError5);
						throw new LuaError("Unable to parse IsRepeatable to true/false!");
					}
					simEvent.IsRepeatable = isRepeatable;
				}
				if (dictionary.ContainsKey("Probability".ToUpper()))
				{
					short result = 0;
					short.TryParse(dictionary["Probability".ToUpper()].ToString(), out result);
					if (result >= 0 && result <= 100)
					{
						simEvent.Probability = result;
					}
				}
				if (Operators.CompareString(text, "add", TextCompare: false) == 0)
				{
					scenario_0.SimEvents.Add(simEvent.ObjectID, simEvent);
				}
				else if (Operators.CompareString(text, "remove", TextCompare: false) == 0)
				{
					LuaWrapper_Event result2 = new LuaWrapper_Event(simEvent, 1, bool_1: true, scenario_0);
					scenario_0.SimEvents.Remove(simEvent.ObjectID);
					return result2;
				}
				return ScenEdit_GetEvent(string_0, 4, scenario_0);
			}
		}
		catch (Exception projectError6)
		{
			ProjectData.SetProjectError(projectError6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static object ScenEdit_SetTrigger(LuaTable luaTable_0, Scenario scenario_0)
	{
		List<ReferencePoint> list_ = new List<ReferencePoint>();
		try
		{
			HashSet<string> hashSet_ = new HashSet<string>();
			Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			dictionary_.Add("TYPEOF", "Trigger");
			if (!dictionary_.ContainsKey("Description".ToUpper()))
			{
				if (!dictionary_.ContainsKey("NAME"))
				{
					throw new LuaError("缺少触发器描述值！");
				}
				dictionary_["Description".ToUpper()] = RuntimeHelpers.GetObjectValue(dictionary_["NAME"]);
			}
			string text = "update";
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			string text2 = null;
			if (dictionary_.ContainsKey("mode".ToUpper()))
			{
				text = dictionary_["mode".ToUpper()].ToString().ToLower();
			}
			switch (text)
			{
			default:
				throw new LuaError("未知的操作！");
			case "add":
			case "list":
			case "remove":
			case "update":
			{
				XmlDocument xmlDocument_ = new XmlDocument();
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				EventTrigger eventTrigger_ = null;
				switch (text)
				{
				default:
					throw new LuaError("未知的操作！");
				case "update":
				{
					if (dictionary_.ContainsKey("Description".ToUpper()))
					{
						try
						{
							text2 = dictionary_["Description".ToUpper()].ToString();
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							throw new LuaError("无法解析事件描述！");
						}
						foreach (EventTrigger value2 in scenario_0.EventTriggers.Values)
						{
							if (string.Equals(value2.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventTrigger_ = value2;
								break;
							}
						}
					}
					if (eventTrigger_ == null)
					{
						throw new LuaError("Trigger not found (" + text2 + ")!");
					}
					Side side = null;
					List<ReferencePoint> list = new List<ReferencePoint>();
					new HashSet<string>();
					foreach (string key in dictionary_.Keys)
					{
						string string_ = key;
						switch (string_.ToUpper())
						{
						case "RENAME":
							eventTrigger_.Description = dictionary_["RENAME"].ToString();
							continue;
						case "DESCRIPTION":
						case "MODE":
						case "NAME":
						case "TYPE":
						case "TYPEOF":
							continue;
						}
						string string_2 = "Trigger";
						string string_3 = eventTrigger_.Type.ToString();
						string text3 = ValidateTriggerOrConditionOrActionPropertyName(ref string_, ref string_2, ref string_3);
						if (text3 != null)
						{
							switch (eventTrigger_.Type)
							{
							case EventTrigger.EventTriggerType.UnitDestroyed:
							{
								EventTrigger_UnitDestroyed eventTrigger_UnitDestroyed = (EventTrigger_UnitDestroyed)eventTrigger_;
								dictionary_[string_].ToString();
								if (Operators.CompareString(text3, "TargetFilter", TextCompare: false) == 0)
								{
									UnitFilterObject unitFilterObject5 = smethod_1(ref dictionary_, scenario_0);
									eventTrigger_UnitDestroyed.TargetFilter.TargetSide = unitFilterObject5.TargetSide;
									eventTrigger_UnitDestroyed.TargetFilter.TargetType = unitFilterObject5.TargetType;
									eventTrigger_UnitDestroyed.TargetFilter.TargetSubType = unitFilterObject5.TargetSubType;
									eventTrigger_UnitDestroyed.TargetFilter.SpecificUnitClass = unitFilterObject5.SpecificUnitClass;
									eventTrigger_UnitDestroyed.TargetFilter.SpecificUnitID = unitFilterObject5.SpecificUnitID;
								}
								break;
							}
							case EventTrigger.EventTriggerType.Points:
							{
								EventTrigger_Points eventTrigger_Points = (EventTrigger_Points)eventTrigger_;
								string text8 = dictionary_[string_].ToString();
								switch (text3)
								{
								case "SideID":
									side = PrivateMethods.ValidateSide(text8, scenario_0);
									if (side != null)
									{
										eventTrigger_Points.SideID = side.ObjectID;
										break;
									}
									throw new LuaError("Action.Points中出错！");
								case "ReachDirection":
									eventTrigger_Points.ReachDirection = (EventTrigger_Points.PointReachDirection)Conversions.ToByte(text8);
									break;
								case "PointValue":
									eventTrigger_Points.PointValue = Conversions.ToInteger(text8);
									break;
								}
								break;
							}
							case EventTrigger.EventTriggerType.Time:
							{
								EventTrigger_Time eventTrigger_Time = (EventTrigger_Time)eventTrigger_;
								string s3 = dictionary_[string_].ToString();
								if (Operators.CompareString(text3, "Time", TextCompare: false) != 0)
								{
									break;
								}
								long result6 = 0L;
								DateTime result7 = DateTime.MinValue;
								if (!long.TryParse(s3, out result6))
								{
									if (!DateTime.TryParse(s3, out result7))
									{
										throw new LuaError("Trigger.Time出错！");
									}
									result6 = result7.ToBinary();
								}
								eventTrigger_Time.Time = result7;
								eventTrigger_Time.Fired = false;
								break;
							}
							case EventTrigger.EventTriggerType.UnitDamaged:
							{
								EventTrigger_UnitDamaged eventTrigger_UnitDamaged = (EventTrigger_UnitDamaged)eventTrigger_;
								string value = dictionary_[string_].ToString();
								if (Operators.CompareString(text3, "DamagePercent", TextCompare: false) == 0)
								{
									byte b = Conversions.ToByte(value);
									if (b > 0 && b <= 100)
									{
										eventTrigger_UnitDamaged.DamagePercent = b;
									}
								}
								else if (Operators.CompareString(text3, "TargetFilter", TextCompare: false) == 0)
								{
									UnitFilterObject unitFilterObject4 = smethod_1(ref dictionary_, scenario_0);
									eventTrigger_UnitDamaged.TargetFilter.TargetSide = unitFilterObject4.TargetSide;
									eventTrigger_UnitDamaged.TargetFilter.TargetType = unitFilterObject4.TargetType;
									eventTrigger_UnitDamaged.TargetFilter.TargetSubType = unitFilterObject4.TargetSubType;
									eventTrigger_UnitDamaged.TargetFilter.SpecificUnitClass = unitFilterObject4.SpecificUnitClass;
									eventTrigger_UnitDamaged.TargetFilter.SpecificUnitID = unitFilterObject4.SpecificUnitID;
								}
								break;
							}
							case EventTrigger.EventTriggerType.UnitRemainsInArea:
							{
								EventTrigger_UnitRemainsInArea eventTrigger_UnitRemainsInArea = (EventTrigger_UnitRemainsInArea)eventTrigger_;
								string text4 = dictionary_[string_].ToString();
								switch (text3)
								{
								case "TD":
								{
									long result = 0L;
									if (long.TryParse(text4, out result))
									{
										eventTrigger_UnitRemainsInArea.TimeDuration = Conversions.ToLong(text4);
										break;
									}
									if (Strings.Split(text4, ":").Count() == 4)
									{
										eventTrigger_UnitRemainsInArea.TimeDuration = LuaUtility.ParseDateAsSeconds(text4);
										break;
									}
									throw new LuaError("Trigger.RemainsIn TDA中的错误");
								}
								case "TargetFilter":
								{
									UnitFilterObject unitFilterObject = smethod_1(ref dictionary_, scenario_0);
									eventTrigger_UnitRemainsInArea.TargetFilter.TargetSide = unitFilterObject.TargetSide;
									eventTrigger_UnitRemainsInArea.TargetFilter.TargetType = unitFilterObject.TargetType;
									eventTrigger_UnitRemainsInArea.TargetFilter.TargetSubType = unitFilterObject.TargetSubType;
									eventTrigger_UnitRemainsInArea.TargetFilter.SpecificUnitClass = unitFilterObject.SpecificUnitClass;
									eventTrigger_UnitRemainsInArea.TargetFilter.SpecificUnitID = unitFilterObject.SpecificUnitID;
									break;
								}
								case "Area":
								{
									list.Clear();
									side = null;
									List<object> list2 = LuaUtility.ToArray(((LuaTable)dictionary_["AREA"]).GetEnumerator());
									Side[] sides_ReadOnly4 = scenario_0.Sides_ReadOnly;
									Side[] array5 = sides_ReadOnly4;
									foreach (Side side2 in array5)
									{
										foreach (object item in list2)
										{
											object Local_o7 = RuntimeHelpers.GetObjectValue(item);
											if (!Information.IsNothing(side2.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o7.ToString(), StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_o7.ToString(), StringComparison.OrdinalIgnoreCase))))
											{
												side = side2;
												break;
											}
										}
										if (side != null)
										{
											break;
										}
									}
									foreach (object item2 in list2)
									{
										object Local_o8 = RuntimeHelpers.GetObjectValue(item2);
										ReferencePoint referencePoint = null;
										if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => Operators.CompareString(s.Name, Local_o8.ToString(), TextCompare: false) == 0)))
										{
											if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o8.ToString(), StringComparison.OrdinalIgnoreCase))))
											{
												if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o8.ToString(), StringComparison.OrdinalIgnoreCase))))
												{
													if (!Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o8.ToString(), StringComparison.OrdinalIgnoreCase))))
													{
														referencePoint = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o8.ToString(), StringComparison.OrdinalIgnoreCase));
													}
												}
												else
												{
													referencePoint = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o8.ToString(), StringComparison.OrdinalIgnoreCase));
												}
											}
											else
											{
												referencePoint = side.RefPoints.First((ReferencePoint s) => string.Equals(s.Name, Local_o8.ToString(), StringComparison.OrdinalIgnoreCase));
											}
										}
										else
										{
											referencePoint = side.RefPoints.First((ReferencePoint s) => Operators.CompareString(s.Name, Local_o8.ToString(), TextCompare: false) == 0);
										}
										if (!Information.IsNothing(referencePoint))
										{
											list.Add(referencePoint);
											continue;
										}
										throw new LuaError("Trigger.RemainsIn RP中出错！");
									}
									eventTrigger_UnitRemainsInArea.Area = list;
									break;
								}
								}
								break;
							}
							case EventTrigger.EventTriggerType.UnitEntersArea:
							{
								EventTrigger_UnitEntersArea eventTrigger_UnitEntersArea = (EventTrigger_UnitEntersArea)eventTrigger_;
								string text9 = dictionary_[string_].ToString();
								switch (text3)
								{
								case "TargetFilter":
								{
									UnitFilterObject unitFilterObject7 = smethod_1(ref dictionary_, scenario_0);
									eventTrigger_UnitEntersArea.TargetFilter.TargetSide = unitFilterObject7.TargetSide;
									eventTrigger_UnitEntersArea.TargetFilter.TargetType = unitFilterObject7.TargetType;
									eventTrigger_UnitEntersArea.TargetFilter.TargetSubType = unitFilterObject7.TargetSubType;
									eventTrigger_UnitEntersArea.TargetFilter.SpecificUnitClass = unitFilterObject7.SpecificUnitClass;
									eventTrigger_UnitEntersArea.TargetFilter.SpecificUnitID = unitFilterObject7.SpecificUnitID;
									break;
								}
								case "NOT":
									eventTrigger_UnitEntersArea.Modifier_NOT = Conversions.ToBoolean(text9);
									break;
								case "ExitArea":
									eventTrigger_UnitEntersArea.Modifier_EXIT = Conversions.ToBoolean(text9);
									break;
								case "ETOA":
								case "LTOA":
								{
									long result8 = 0L;
									DateTime result9 = DateTime.MinValue;
									if (!long.TryParse(text9, out result8))
									{
										if (!DateTime.TryParse(text9, out result9))
										{
											throw new LuaError("Trigger.EntersArea TOA出错！");
										}
										result8 = result9.ToBinary();
									}
									if (Operators.CompareString(text3, "EarliestTime", TextCompare: false) == 0)
									{
										eventTrigger_UnitEntersArea.dateTime_0 = result9;
									}
									else
									{
										eventTrigger_UnitEntersArea.dateTime_1 = result9;
									}
									break;
								}
								case "Area":
								{
									list.Clear();
									side = null;
									List<object> list5 = LuaUtility.ToArray(((LuaTable)dictionary_["AREA"]).GetEnumerator());
									Side[] sides_ReadOnly3 = scenario_0.Sides_ReadOnly;
									Side[] array8 = sides_ReadOnly3;
									foreach (Side side5 in array8)
									{
										foreach (object item3 in list5)
										{
											object Local_o5 = RuntimeHelpers.GetObjectValue(item3);
											if (!Information.IsNothing(side5.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o5.ToString(), StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_o5.ToString(), StringComparison.OrdinalIgnoreCase))))
											{
												side = side5;
												break;
											}
										}
										if (side != null)
										{
											break;
										}
									}
									foreach (object item4 in list5)
									{
										object Local_o6 = RuntimeHelpers.GetObjectValue(item4);
										ReferencePoint referencePoint4 = null;
										if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => Operators.CompareString(s.Name, Local_o6.ToString(), TextCompare: false) == 0)))
										{
											if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o6.ToString(), StringComparison.OrdinalIgnoreCase))))
											{
												if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o6.ToString(), StringComparison.OrdinalIgnoreCase))))
												{
													if (!Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o6.ToString(), StringComparison.OrdinalIgnoreCase))))
													{
														referencePoint4 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o6.ToString(), StringComparison.OrdinalIgnoreCase));
													}
												}
												else
												{
													referencePoint4 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o6.ToString(), StringComparison.OrdinalIgnoreCase));
												}
											}
											else
											{
												referencePoint4 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.Name, Local_o6.ToString(), StringComparison.OrdinalIgnoreCase));
											}
										}
										else
										{
											referencePoint4 = side.RefPoints.First((ReferencePoint s) => Operators.CompareString(s.Name, Local_o6.ToString(), TextCompare: false) == 0);
										}
										if (!Information.IsNothing(referencePoint4))
										{
											list.Add(referencePoint4);
											continue;
										}
										throw new LuaError("Trigger.EntersArea RP出错！");
									}
									eventTrigger_UnitEntersArea.Area = list;
									break;
								}
								}
								break;
							}
							case EventTrigger.EventTriggerType.RandomTime:
							{
								EventTrigger_RandomTime eventTrigger_RandomTime = (EventTrigger_RandomTime)eventTrigger_;
								string s2 = dictionary_[string_].ToString();
								if (Operators.CompareString(text3, "EarliestTime", TextCompare: false) != 0 && Operators.CompareString(text3, "LatestTime", TextCompare: false) != 0)
								{
									break;
								}
								long result4 = 0L;
								DateTime result5 = DateTime.MinValue;
								if (!long.TryParse(s2, out result4))
								{
									if (!DateTime.TryParse(s2, out result5))
									{
										throw new LuaError("Trigger.RandomTime出错！");
									}
									result4 = result5.ToBinary();
								}
								if (Operators.CompareString(text3, "EarliestTime", TextCompare: false) == 0)
								{
									eventTrigger_RandomTime.EarliestTime = result5;
								}
								else
								{
									eventTrigger_RandomTime.LatestTime = result5;
								}
								eventTrigger_RandomTime.Fired = false;
								break;
							}
							case EventTrigger.EventTriggerType.UnitDetected:
							{
								EventTrigger_UnitDetected eventTrigger_UnitDetected = (EventTrigger_UnitDetected)eventTrigger_;
								string text7 = dictionary_[string_].ToString();
								switch (text3)
								{
								case "TargetFilter":
								{
									UnitFilterObject unitFilterObject6 = smethod_1(ref dictionary_, scenario_0);
									eventTrigger_UnitDetected.TargetFilter.TargetSide = unitFilterObject6.TargetSide;
									eventTrigger_UnitDetected.TargetFilter.TargetType = unitFilterObject6.TargetType;
									eventTrigger_UnitDetected.TargetFilter.TargetSubType = unitFilterObject6.TargetSubType;
									eventTrigger_UnitDetected.TargetFilter.SpecificUnitClass = unitFilterObject6.SpecificUnitClass;
									eventTrigger_UnitDetected.TargetFilter.SpecificUnitID = unitFilterObject6.SpecificUnitID;
									break;
								}
								case "MCL":
								{
									short[] array4 = (short[])Enum.GetValues(typeof(Contact_Base.IdentificationStatus));
									int num5 = 0;
									while (num5 < array4.Length)
									{
										short num6 = array4[num5];
										if (!string.Equals(text7, num6.ToString(), StringComparison.OrdinalIgnoreCase))
										{
											Contact_Base.IdentificationStatus identificationStatus2 = (Contact_Base.IdentificationStatus)num6;
											if (!string.Equals(text7, identificationStatus2.ToString(), StringComparison.OrdinalIgnoreCase))
											{
												num5 = checked(num5 + 1);
												continue;
											}
										}
										eventTrigger_UnitDetected.MinimumClassificationLevel = (Contact_Base.IdentificationStatus)num6;
										break;
									}
									break;
								}
								case "DetectorSideID":
									side = PrivateMethods.ValidateSide(text7, scenario_0);
									if (side != null)
									{
										eventTrigger_UnitDetected.DetectorSideID = side.ObjectID;
										break;
									}
									throw new LuaError("Trigger.UnitDetected Side出错！");
								case "Area":
								{
									list.Clear();
									side = null;
									List<object> list4 = LuaUtility.ToArray(((LuaTable)dictionary_["AREA"]).GetEnumerator());
									Side[] sides_ReadOnly2 = scenario_0.Sides_ReadOnly;
									Side[] array7 = sides_ReadOnly2;
									foreach (Side side4 in array7)
									{
										foreach (object item5 in list4)
										{
											object Local_o = RuntimeHelpers.GetObjectValue(item5);
											if (!Information.IsNothing(side4.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o.ToString(), StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase))))
											{
												side = side4;
												break;
											}
										}
										if (side != null)
										{
											break;
										}
									}
									foreach (object item6 in list4)
									{
										object Local_o2 = RuntimeHelpers.GetObjectValue(item6);
										ReferencePoint referencePoint3 = null;
										if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => Operators.CompareString(s.Name, Local_o2.ToString(), TextCompare: false) == 0)))
										{
											if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase))))
											{
												if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase))))
												{
													if (!Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase))))
													{
														referencePoint3 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase));
													}
												}
												else
												{
													referencePoint3 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase));
												}
											}
											else
											{
												referencePoint3 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.Name, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase));
											}
										}
										else
										{
											referencePoint3 = side.RefPoints.First((ReferencePoint s) => Operators.CompareString(s.Name, Local_o2.ToString(), TextCompare: false) == 0);
										}
										if (!Information.IsNothing(referencePoint3))
										{
											list.Add(referencePoint3);
											continue;
										}
										throw new LuaError("Trigger.UnitDetected RP出错！");
									}
									eventTrigger_UnitDetected.Area = list;
									break;
								}
								}
								break;
							}
							case EventTrigger.EventTriggerType.ScenLoaded:
								dictionary_[string_].ToString();
								break;
							case EventTrigger.EventTriggerType.RegularTime:
							{
								EventTrigger_RegularTime eventTrigger_RegularTime = (EventTrigger_RegularTime)eventTrigger_;
								string a = dictionary_[string_].ToString();
								int[] array2 = (int[])Enum.GetValues(typeof(EventTrigger_RegularTime.RegularTimeInterval));
								if (Operators.CompareString(text3, "Interval", TextCompare: false) != 0)
								{
									break;
								}
								int[] array3 = array2;
								int num3 = 0;
								while (num3 < array3.Length)
								{
									int num4 = array3[num3];
									if (!string.Equals(a, num4.ToString(), StringComparison.OrdinalIgnoreCase))
									{
										EventTrigger_RegularTime.RegularTimeInterval regularTimeInterval = (EventTrigger_RegularTime.RegularTimeInterval)num4;
										if (!string.Equals(a, regularTimeInterval.ToString(), StringComparison.OrdinalIgnoreCase))
										{
											num3 = checked(num3 + 1);
											continue;
										}
									}
									eventTrigger_RegularTime.Interval = (EventTrigger_RegularTime.RegularTimeInterval)num4;
									break;
								}
								break;
							}
							case EventTrigger.EventTriggerType.ScenEnded:
								dictionary_[string_].ToString();
								break;
							case EventTrigger.EventTriggerType.UnitBaseStatus:
							{
								EventTrigger_UnitBaseStatus eventTrigger_UnitBaseStatus = (EventTrigger_UnitBaseStatus)eventTrigger_;
								string text6 = dictionary_[string_].ToString();
								switch (text3)
								{
								case "TargetFilter":
								{
									UnitFilterObject unitFilterObject3 = smethod_1(ref dictionary_, scenario_0);
									eventTrigger_UnitBaseStatus.TargetFilter.TargetSide = unitFilterObject3.TargetSide;
									eventTrigger_UnitBaseStatus.TargetFilter.TargetType = unitFilterObject3.TargetType;
									eventTrigger_UnitBaseStatus.TargetFilter.TargetSubType = unitFilterObject3.TargetSubType;
									eventTrigger_UnitBaseStatus.TargetFilter.SpecificUnitClass = unitFilterObject3.SpecificUnitClass;
									eventTrigger_UnitBaseStatus.TargetFilter.SpecificUnitID = unitFilterObject3.SpecificUnitID;
									break;
								}
								case "TargetCondition":
									switch (eventTrigger_UnitBaseStatus.TargetFilter.TargetType)
									{
									case GlobalVariables.ActiveUnitType.Ship:
									case GlobalVariables.ActiveUnitType.Submarine:
									{
										if (Enum.TryParse<ActiveUnit_DockingOps._DockingOpsCondition>(text6, out var result3) & Enum.IsDefined(typeof(ActiveUnit_DockingOps._DockingOpsCondition), result3))
										{
											eventTrigger_UnitBaseStatus.TargetCondition = (int)result3;
										}
										break;
									}
									case GlobalVariables.ActiveUnitType.Aircraft:
									{
										if (Enum.TryParse<Aircraft_AirOps._AirOpsCondition>(text6, out var result2) & Enum.IsDefined(typeof(Aircraft_AirOps._AirOpsCondition), result2))
										{
											eventTrigger_UnitBaseStatus.TargetCondition = (int)result2;
										}
										break;
									}
									}
									CMANO.LuaTriggers.AddOpsHandler();
									break;
								case "TargetBase":
									if (PrivateMethods.smethod_0(text6, scenario_0) != null)
									{
										eventTrigger_UnitBaseStatus.TargetBase = text6;
									}
									break;
								}
								break;
							}
							case EventTrigger.EventTriggerType.UnitEmissions:
							{
								EventTrigger_UnitEmissions eventTrigger_UnitEmissions = (EventTrigger_UnitEmissions)eventTrigger_;
								string text5 = dictionary_[string_].ToString();
								switch (text3)
								{
								case "TargetFilter":
								{
									UnitFilterObject unitFilterObject2 = smethod_1(ref dictionary_, scenario_0);
									eventTrigger_UnitEmissions.TargetFilter.TargetSide = unitFilterObject2.TargetSide;
									eventTrigger_UnitEmissions.TargetFilter.TargetType = unitFilterObject2.TargetType;
									eventTrigger_UnitEmissions.TargetFilter.TargetSubType = unitFilterObject2.TargetSubType;
									eventTrigger_UnitEmissions.TargetFilter.SpecificUnitClass = unitFilterObject2.SpecificUnitClass;
									eventTrigger_UnitEmissions.TargetFilter.SpecificUnitID = unitFilterObject2.SpecificUnitID;
									break;
								}
								case "MCL":
								{
									short[] array = (short[])Enum.GetValues(typeof(Contact_Base.IdentificationStatus));
									int num = 0;
									while (num < array.Length)
									{
										short num2 = array[num];
										if (!string.Equals(text5, num2.ToString(), StringComparison.OrdinalIgnoreCase))
										{
											Contact_Base.IdentificationStatus identificationStatus = (Contact_Base.IdentificationStatus)num2;
											if (!string.Equals(text5, identificationStatus.ToString(), StringComparison.OrdinalIgnoreCase))
											{
												num = checked(num + 1);
												continue;
											}
										}
										eventTrigger_UnitEmissions.MinimumClassificationLevel = (Contact_Base.IdentificationStatus)num2;
										break;
									}
									break;
								}
								case "DetectorSideID":
									side = PrivateMethods.ValidateSide(text5, scenario_0);
									if (side != null)
									{
										eventTrigger_UnitEmissions.DetectorSideID = side.ObjectID;
										break;
									}
									throw new LuaError("Trigger.Unitmissions端错误！");
								case "Area":
								{
									list.Clear();
									side = null;
									List<object> list3 = LuaUtility.ToArray(((LuaTable)dictionary_["AREA"]).GetEnumerator());
									Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
									Side[] array6 = sides_ReadOnly;
									foreach (Side side3 in array6)
									{
										foreach (object item7 in list3)
										{
											object Local_o3 = RuntimeHelpers.GetObjectValue(item7);
											if (!Information.IsNothing(side3.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o3.ToString(), StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_o3.ToString(), StringComparison.OrdinalIgnoreCase))))
											{
												side = side3;
												break;
											}
										}
										if (side != null)
										{
											break;
										}
									}
									foreach (object item8 in list3)
									{
										object Local_o4 = RuntimeHelpers.GetObjectValue(item8);
										ReferencePoint referencePoint2 = null;
										if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => Operators.CompareString(s.Name, Local_o4.ToString(), TextCompare: false) == 0)))
										{
											if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o4.ToString(), StringComparison.OrdinalIgnoreCase))))
											{
												if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o4.ToString(), StringComparison.OrdinalIgnoreCase))))
												{
													if (!Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o4.ToString(), StringComparison.OrdinalIgnoreCase))))
													{
														referencePoint2 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o4.ToString(), StringComparison.OrdinalIgnoreCase));
													}
												}
												else
												{
													referencePoint2 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o4.ToString(), StringComparison.OrdinalIgnoreCase));
												}
											}
											else
											{
												referencePoint2 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.Name, Local_o4.ToString(), StringComparison.OrdinalIgnoreCase));
											}
										}
										else
										{
											referencePoint2 = side.RefPoints.First((ReferencePoint s) => Operators.CompareString(s.Name, Local_o4.ToString(), TextCompare: false) == 0);
										}
										if (!Information.IsNothing(referencePoint2))
										{
											list.Add(referencePoint2);
											continue;
										}
										throw new LuaError("Trigger.UnitEmissions RP出错！");
									}
									eventTrigger_UnitEmissions.Area = list;
									break;
								}
								}
								break;
							}
							case EventTrigger.EventTriggerType.UnitCargoMoved:
							{
								EventTrigger_UnitCargoMoved eventTrigger_UnitCargoMoved = (EventTrigger_UnitCargoMoved)eventTrigger_;
								dictionary_[string_].ToString();
								if (Operators.CompareString(text3, "CargoFilter", TextCompare: false) == 0)
								{
									CargoFilterObject cargoFilterObject = smethod_2(ref dictionary_, scenario_0);
									eventTrigger_UnitCargoMoved.TargetFilter.cargoType = cargoFilterObject.cargoType;
									eventTrigger_UnitCargoMoved.TargetFilter.SpecificCargoDBID = cargoFilterObject.SpecificCargoDBID;
									eventTrigger_UnitCargoMoved.TargetFilter.SpecificCargoObjID = cargoFilterObject.SpecificCargoObjID;
									eventTrigger_UnitCargoMoved.TargetFilter.ThresholdReceived = cargoFilterObject.ThresholdReceived;
									eventTrigger_UnitCargoMoved.TargetFilter.ThresholdSent = cargoFilterObject.ThresholdSent;
									eventTrigger_UnitCargoMoved.TargetFilter.Received = cargoFilterObject.Received;
									eventTrigger_UnitCargoMoved.TargetFilter.Sent = cargoFilterObject.Sent;
								}
								break;
							}
							default:
								throw new LuaError("还没有实现！");
							}
							continue;
						}
						throw new LuaError("未找到触发键");
					}
					StringWriter stringWriter3 = new StringWriter(new StringBuilder());
					AddUnitToSerialized(ref eventTrigger_, hashSet_);
					using (XmlWriter xmlWriter3 = new XmlTextWriter(stringWriter3))
					{
						eventTrigger_.ToXML(xmlWriter3, hashSet_, scenario_0);
						xmlWriter3.Flush();
					}
					xmlDocument_.LoadXml(stringWriter3.ToString());
					break;
				}
				case "remove":
				{
					bool flag = false;
					if (dictionary_.ContainsKey("Description".ToUpper()))
					{
						text2 = dictionary_["Description".ToUpper()].ToString();
						foreach (EventTrigger value3 in scenario_0.EventTriggers.Values)
						{
							if (!string.Equals(value3.Description, text2, StringComparison.OrdinalIgnoreCase) && !string.Equals(value3.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								continue;
							}
							foreach (SimEvent value4 in scenario_0.SimEvents.Values)
							{
								foreach (EventTrigger trigger in value4.Triggers)
								{
									if (Operators.CompareString(trigger.ObjectID, value3.ObjectID, TextCompare: false) == 0)
									{
										flag = true;
										break;
									}
								}
							}
							if (!flag)
							{
								eventTrigger_ = value3;
								break;
							}
						}
					}
					if (eventTrigger_ == null)
					{
						if (flag)
						{
							throw new LuaError("Event trigger in use (" + text2 + ")!");
						}
						throw new LuaError("Event trigger not found (" + text2 + ")!");
					}
					StringWriter stringWriter2 = new StringWriter(new StringBuilder());
					AddUnitToSerialized(ref eventTrigger_, hashSet_);
					using (XmlWriter xmlWriter2 = new XmlTextWriter(stringWriter2))
					{
						eventTrigger_.ToXML(xmlWriter2, hashSet_, scenario_0);
						xmlWriter2.Flush();
					}
					xmlDocument_.LoadXml(stringWriter2.ToString());
					scenario_0.EventTriggers.Remove(eventTrigger_.ObjectID);
					break;
				}
				case "list":
				{
					if (dictionary_.ContainsKey("Description".ToUpper()))
					{
						text2 = dictionary_["Description".ToUpper()].ToString();
						foreach (EventTrigger value5 in scenario_0.EventTriggers.Values)
						{
							if (string.Equals(value5.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value5.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventTrigger_ = value5;
								break;
							}
						}
					}
					LuaTable val3 = LuaSandBox.Singleton().CreateTable();
					if (eventTrigger_ == null)
					{
						foreach (EventTrigger value6 in scenario_0.EventTriggers.Values)
						{
							eventTrigger_ = value6;
							LuaTable val4 = LuaSandBox.Singleton().CreateTable();
							StringWriter stringWriter4 = new StringWriter(new StringBuilder());
							AddUnitToSerialized(ref eventTrigger_, hashSet_);
							using (XmlWriter xmlWriter4 = new XmlTextWriter(stringWriter4))
							{
								eventTrigger_.ToXML(xmlWriter4, hashSet_, scenario_0);
								xmlWriter4.Flush();
							}
							xmlDocument_.LoadXml(stringWriter4.ToString());
							val4["xml"] = xmlDocument_.InnerXml;
							val4[eventTrigger_.Type.ToString()] = ParseXMLtoTable(ref xmlDocument_);
							val3[val3.Keys.Count + 1] = val4;
						}
					}
					else
					{
						LuaTable val5 = LuaSandBox.Singleton().CreateTable();
						StringWriter stringWriter5 = new StringWriter(new StringBuilder());
						AddUnitToSerialized(ref eventTrigger_, hashSet_);
						using (XmlWriter xmlWriter5 = new XmlTextWriter(stringWriter5))
						{
							eventTrigger_.ToXML(xmlWriter5, hashSet_, scenario_0);
							xmlWriter5.Flush();
						}
						xmlDocument_.LoadXml(stringWriter5.ToString());
						val5["xml"] = xmlDocument_.InnerXml;
						val5[eventTrigger_.Type.ToString()] = ParseXMLtoTable(ref xmlDocument_);
						val3[val3.Keys.Count + 1] = val5;
					}
					val["triggers"] = val3;
					return val;
				}
				case "add":
					if (dictionary_.ContainsKey("Description".ToUpper()))
					{
						text2 = dictionary_["Description".ToUpper()].ToString();
						foreach (EventTrigger value7 in scenario_0.EventTriggers.Values)
						{
							if (string.Equals(value7.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value7.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								throw new LuaError("Existing event trigger (" + text2 + ")!");
							}
						}
					}
					if (!dictionary_.ContainsKey("XML".ToUpper()))
					{
						dictionary_.Add("XML", ParseDictToXML(ref dictionary_, scenario_0, ref list_).OuterXml);
					}
					if (dictionary_.ContainsKey("XML".ToUpper()))
					{
						try
						{
							text2 = dictionary_["XML"].ToString();
							ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_ = new ConcurrentDictionary<string, ScenarioObject>();
							xmlDocument_ = new XmlDocument();
							xmlDocument_.LoadXml(text2);
							XmlNode xmlNode_ = xmlDocument_.DocumentElement;
							eventTrigger_ = EventTrigger.FromXML(ref xmlNode_, ref concurrentDictionary_, ref scenario_0);
							smethod_0(scenario_0, ref eventTrigger_, list_);
							scenario_0.EventTriggers.Add(eventTrigger_.ObjectID, eventTrigger_);
							StringWriter stringWriter = new StringWriter(new StringBuilder());
							AddUnitToSerialized(ref eventTrigger_, hashSet_);
							using (XmlWriter xmlWriter = new XmlTextWriter(stringWriter))
							{
								eventTrigger_.ToXML(xmlWriter, hashSet_, scenario_0);
								xmlWriter.Flush();
							}
							xmlDocument_.LoadXml(stringWriter.ToString());
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							throw new LuaError("无法解析事件XML！");
						}
						break;
					}
					throw new LuaError("Unable to add trigger (" + text2 + ")!");
				}
				val2["xml"] = xmlDocument_.InnerXml;
				val2[eventTrigger_.Type.ToString()] = ParseXMLtoTable(ref xmlDocument_);
				val2["mode"] = text.ToUpper();
				val["triggers"] = val2;
				return val;
			}
			}
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static object ScenEdit_SetCondition(LuaTable luaTable_0, Scenario scenario_0)
	{
		try
		{
			HashSet<string> hashSet_ = new HashSet<string>();
			Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			dictionary_.Add("TYPEOF", "Condition");
			if (!dictionary_.ContainsKey("Description".ToUpper()))
			{
				if (!dictionary_.ContainsKey("NAME"))
				{
					throw new LuaError("缺少条件描述值！");
				}
				dictionary_["Description".ToUpper()] = RuntimeHelpers.GetObjectValue(dictionary_["NAME"]);
			}
			string text = "update";
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			string text2 = null;
			if (dictionary_.ContainsKey("mode".ToUpper()))
			{
				text = dictionary_["mode".ToUpper()].ToString().ToLower();
			}
			switch (text)
			{
			default:
				throw new LuaError("未知的操作！");
			case "add":
			case "list":
			case "remove":
			case "update":
			{
				XmlDocument xmlDocument_ = new XmlDocument();
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				EventCondition eventCondition = null;
				switch (text)
				{
				default:
					throw new LuaError("未知的操作！");
				case "update":
				{
					if (dictionary_.ContainsKey("Description".ToUpper()))
					{
						try
						{
							text2 = dictionary_["Description".ToUpper()].ToString();
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							throw new LuaError("无法解析事件描述！");
						}
						foreach (EventCondition value2 in scenario_0.EventConditions.Values)
						{
							if (string.Equals(value2.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventCondition = value2;
								break;
							}
						}
					}
					if (eventCondition == null)
					{
						throw new LuaError("找不到条件");
					}
					Side side = null;
					new List<ReferencePoint>();
					new HashSet<string>();
					foreach (string key in dictionary_.Keys)
					{
						string string_ = key;
						switch (string_.ToUpper())
						{
						case "RENAME":
							eventCondition.Description = dictionary_["RENAME"].ToString();
							break;
						case "DESCRIPTION":
						case "MODE":
						case "NAME":
						case "TYPE":
						case "TYPEOF":
							continue;
						}
						string string_2 = "Condition";
						string string_3 = eventCondition.Type.ToString();
						string text3 = ValidateTriggerOrConditionOrActionPropertyName(ref string_, ref string_2, ref string_3);
						if (text3 != null)
						{
							switch (eventCondition.Type)
							{
							case EventCondition.EventConditionType.SidePosture:
							{
								EventCondition_SidePosture eventCondition_SidePosture = (EventCondition_SidePosture)eventCondition;
								string text4 = dictionary_[string_].ToString();
								switch (text3)
								{
								case "TargetSideID":
									side = PrivateMethods.ValidateSide(text4, scenario_0);
									if (side != null)
									{
										eventCondition_SidePosture.TargetSide_ID = side.ObjectID;
										break;
									}
									throw new LuaError("Action.Message出错！");
								case "TargetPosture":
									eventCondition_SidePosture.TargetPosture = (Misc.PostureStance)Conversions.ToByte(text4);
									break;
								case "ObserverSideID":
									side = PrivateMethods.ValidateSide(text4, scenario_0);
									if (side != null)
									{
										eventCondition_SidePosture.ObserverSide_ID = side.ObjectID;
										break;
									}
									throw new LuaError("Action.Message出错！");
								case "NOT":
									eventCondition_SidePosture.Modifier_NOT = Conversions.ToBoolean(text4);
									break;
								}
								break;
							}
							case EventCondition.EventConditionType.ScenHasStarted:
							{
								EventCondition_ScenHasStarted eventCondition_ScenHasStarted = (EventCondition_ScenHasStarted)eventCondition;
								string value = dictionary_[string_].ToString();
								if (Operators.CompareString(text3, "NOT", TextCompare: false) == 0)
								{
									eventCondition_ScenHasStarted.Modifier_NOT = Conversions.ToBoolean(value);
								}
								break;
							}
							case EventCondition.EventConditionType.LuaScript:
							{
								EventCondition_LuaScript eventCondition_LuaScript = (EventCondition_LuaScript)eventCondition;
								dictionary_[string_].ToString();
								if (Operators.CompareString(text3, "ScriptText", TextCompare: false) == 0)
								{
									eventCondition_LuaScript.ScriptText = dictionary_[string_].ToString();
								}
								break;
							}
							default:
								throw new LuaError("还没有实现！");
							}
							continue;
						}
						throw new LuaError("未找到条件密钥");
					}
					StringWriter stringWriter4 = new StringWriter(new StringBuilder());
					using (XmlWriter xmlWriter4 = new XmlTextWriter(stringWriter4))
					{
						eventCondition.ToXML(xmlWriter4, hashSet_, scenario_0);
						xmlWriter4.Flush();
					}
					xmlDocument_.LoadXml(stringWriter4.ToString());
					break;
				}
				case "remove":
				{
					bool flag = false;
					if (dictionary_.ContainsKey("Description".ToUpper()))
					{
						text2 = dictionary_["Description".ToUpper()].ToString();
						foreach (EventCondition value3 in scenario_0.EventConditions.Values)
						{
							if (!string.Equals(value3.Description, text2, StringComparison.OrdinalIgnoreCase) && !string.Equals(value3.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								continue;
							}
							foreach (SimEvent value4 in scenario_0.SimEvents.Values)
							{
								foreach (EventCondition condition in value4.Conditions)
								{
									if (Operators.CompareString(condition.ObjectID, value3.ObjectID, TextCompare: false) == 0)
									{
										flag = true;
										break;
									}
								}
							}
							if (!flag)
							{
								eventCondition = value3;
								break;
							}
						}
					}
					if (eventCondition == null)
					{
						if (flag)
						{
							throw new LuaError("使用中的事件条件！");
						}
						throw new LuaError("找不到事件条件！");
					}
					StringWriter stringWriter5 = new StringWriter(new StringBuilder());
					using (XmlWriter xmlWriter5 = new XmlTextWriter(stringWriter5))
					{
						eventCondition.ToXML(xmlWriter5, hashSet_, scenario_0);
						xmlWriter5.Flush();
					}
					xmlDocument_.LoadXml(stringWriter5.ToString());
					scenario_0.EventConditions.Remove(eventCondition.ObjectID);
					break;
				}
				case "list":
				{
					if (dictionary_.ContainsKey("Description".ToUpper()))
					{
						text2 = dictionary_["Description".ToUpper()].ToString();
						foreach (EventCondition value5 in scenario_0.EventConditions.Values)
						{
							if (string.Equals(value5.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value5.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventCondition = value5;
								break;
							}
						}
					}
					LuaTable val3 = LuaSandBox.Singleton().CreateTable();
					if (eventCondition == null)
					{
						foreach (EventCondition value6 in scenario_0.EventConditions.Values)
						{
							LuaTable val4 = LuaSandBox.Singleton().CreateTable();
							StringWriter stringWriter2 = new StringWriter(new StringBuilder());
							using (XmlWriter xmlWriter2 = new XmlTextWriter(stringWriter2))
							{
								value6.ToXML(xmlWriter2, hashSet_, scenario_0);
								xmlWriter2.Flush();
							}
							xmlDocument_.LoadXml(stringWriter2.ToString());
							val4["xml"] = xmlDocument_.InnerXml;
							val4[value6.Type.ToString()] = ParseXMLtoTable(ref xmlDocument_);
							val3[val3.Keys.Count + 1] = val4;
						}
					}
					else
					{
						LuaTable val5 = LuaSandBox.Singleton().CreateTable();
						StringWriter stringWriter3 = new StringWriter(new StringBuilder());
						using (XmlWriter xmlWriter3 = new XmlTextWriter(stringWriter3))
						{
							eventCondition.ToXML(xmlWriter3, hashSet_, scenario_0);
							xmlWriter3.Flush();
						}
						xmlDocument_.LoadXml(stringWriter3.ToString());
						val5["xml"] = xmlDocument_.InnerXml;
						val5[eventCondition.Type.ToString()] = ParseXMLtoTable(ref xmlDocument_);
						val3[val3.Keys.Count + 1] = val5;
					}
					val["conditions"] = val3;
					return val;
				}
				case "add":
					if (dictionary_.ContainsKey("Description".ToUpper()))
					{
						text2 = dictionary_["Description".ToUpper()].ToString();
						foreach (EventCondition value7 in scenario_0.EventConditions.Values)
						{
							if (string.Equals(value7.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value7.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								throw new LuaError("已存在事件条件！");
							}
						}
						Dictionary<string, object> dictionary = dictionary_;
						Scenario scenario_ = scenario_0;
						List<ReferencePoint> list_ = null;
						dictionary.Add("XML", ParseDictToXML(ref dictionary_, scenario_, ref list_).OuterXml);
					}
					if (dictionary_.ContainsKey("XML".ToUpper()))
					{
						try
						{
							text2 = dictionary_["XML".ToUpper()].ToString();
							xmlDocument_ = new XmlDocument();
							xmlDocument_.LoadXml(text2);
							XmlNode xmlNode_ = xmlDocument_.DocumentElement;
							ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_ = null;
							eventCondition = EventCondition.FromXML(ref xmlNode_, ref concurrentDictionary_, ref scenario_0);
							scenario_0.EventConditions.Add(eventCondition.ObjectID, eventCondition);
							StringWriter stringWriter = new StringWriter(new StringBuilder());
							using (XmlWriter xmlWriter = new XmlTextWriter(stringWriter))
							{
								eventCondition.ToXML(xmlWriter, hashSet_, scenario_0);
								xmlWriter.Flush();
							}
							xmlDocument_.LoadXml(stringWriter.ToString());
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							throw new LuaError("无法解析事件XML！");
						}
						break;
					}
					throw new LuaError("无法添加条件！");
				}
				val2["xml"] = xmlDocument_.InnerXml;
				val2[eventCondition.Type.ToString()] = ParseXMLtoTable(ref xmlDocument_);
				val2["mode"] = text.ToUpper();
				val["conditions"] = val2;
				return val;
			}
			}
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static object ScenEdit_SetAction(LuaTable luaTable_0, Scenario scenario_0)
	{
		try
		{
			HashSet<string> hashSet_ = new HashSet<string>();
			Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			dictionary_.Add("TYPEOF", "Action");
			if (!dictionary_.ContainsKey("Description".ToUpper()))
			{
				if (!dictionary_.ContainsKey("NAME"))
				{
					throw new LuaError("缺少动作描述值！");
				}
				dictionary_["Description".ToUpper()] = RuntimeHelpers.GetObjectValue(dictionary_["NAME"]);
			}
			string text = "update";
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			string text2 = null;
			if (dictionary_.ContainsKey("mode".ToUpper()))
			{
				text = dictionary_["mode".ToUpper()].ToString().ToLower();
			}
			switch (text)
			{
			default:
				throw new LuaError("未知的操作！");
			case "add":
			case "list":
			case "remove":
			case "update":
			{
				XmlDocument xmlDocument_ = new XmlDocument();
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				EventAction eventAction = null;
				switch (text)
				{
				default:
					throw new LuaError("未知的操作！");
				case "update":
				{
					if (dictionary_.ContainsKey("Description".ToUpper()))
					{
						try
						{
							text2 = dictionary_["Description".ToUpper()].ToString();
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							throw new LuaError("无法解析事件描述！");
						}
						foreach (EventAction value in scenario_0.EventActions.Values)
						{
							if (string.Equals(value.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventAction = value;
								break;
							}
						}
					}
					if (eventAction == null)
					{
						throw new LuaError("Action not found (" + text2 + ")!");
					}
					ActiveUnit activeUnit = null;
					Mission mission = null;
					Side side = null;
					List<ReferencePoint> list = new List<ReferencePoint>();
					HashSet<string> hashSet = new HashSet<string>();
					foreach (string key in dictionary_.Keys)
					{
						string string_ = key;
						switch (string_.ToUpper())
						{
						case "RENAME":
							eventAction.Description = dictionary_["RENAME"].ToString();
							break;
						case "DESCRIPTION":
						case "MODE":
						case "NAME":
						case "TYPE":
						case "TYPEOF":
							continue;
						}
						string string_2 = "Action";
						string string_3 = eventAction.Type.ToString();
						string text3 = ValidateTriggerOrConditionOrActionPropertyName(ref string_, ref string_2, ref string_3);
						if (text3 != null)
						{
							switch (eventAction.Type)
							{
							case EventAction.EventActionType.Points:
							{
								EventAction_Points eventAction_Points = (EventAction_Points)eventAction;
								string text4 = dictionary_[string_].ToString();
								if (Operators.CompareString(text3, "SideID", TextCompare: false) == 0)
								{
									side = PrivateMethods.ValidateSide(text4, scenario_0);
									if (side == null)
									{
										throw new LuaError("Action.Points中出错！");
									}
									eventAction_Points.SideID = side.ObjectID;
								}
								else if (Operators.CompareString(text3, "PointChange", TextCompare: false) == 0)
								{
									eventAction_Points.PointChange = Conversions.ToInteger(text4);
								}
								break;
							}
							case EventAction.EventActionType.TeleportInArea:
							{
								EventAction_TeleportInArea eventAction_TeleportInArea = (EventAction_TeleportInArea)eventAction;
								if (Operators.CompareString(text3, "UnitIDs", TextCompare: false) == 0)
								{
									hashSet.Clear();
									side = null;
									foreach (object item in LuaUtility.ToArray(((LuaTable)dictionary_["UNITIDS"]).GetEnumerator()))
									{
										activeUnit = PrivateMethods.smethod_0(RuntimeHelpers.GetObjectValue(item).ToString(), scenario_0);
										if (activeUnit != null)
										{
											hashSet.Add(activeUnit.ObjectID);
											continue;
										}
										throw new LuaError("行动单元ID无效！");
									}
									eventAction_TeleportInArea.UnitIDs = hashSet;
								}
								else
								{
									if (Operators.CompareString(text3, "Area", TextCompare: false) != 0)
									{
										break;
									}
									list.Clear();
									side = null;
									List<object> list2 = LuaUtility.ToArray(((LuaTable)dictionary_["AREA"]).GetEnumerator());
									Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
									Side[] array = sides_ReadOnly;
									foreach (Side side2 in array)
									{
										foreach (object item2 in list2)
										{
											object Local_o = RuntimeHelpers.GetObjectValue(item2);
											if (!Information.IsNothing(side2.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o.ToString(), StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase))))
											{
												side = side2;
												break;
											}
										}
										if (side != null)
										{
											break;
										}
									}
									foreach (object item3 in list2)
									{
										object Local_o2 = RuntimeHelpers.GetObjectValue(item3);
										ReferencePoint referencePoint = null;
										if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => Operators.CompareString(s.Name, Local_o2.ToString(), TextCompare: false) == 0)))
										{
											if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase))))
											{
												if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase))))
												{
													if (!Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase))))
													{
														referencePoint = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase));
													}
												}
												else
												{
													referencePoint = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase));
												}
											}
											else
											{
												referencePoint = side.RefPoints.First((ReferencePoint s) => string.Equals(s.Name, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase));
											}
										}
										else
										{
											referencePoint = side.RefPoints.First((ReferencePoint s) => Operators.CompareString(s.Name, Local_o2.ToString(), TextCompare: false) == 0);
										}
										if (!Information.IsNothing(referencePoint))
										{
											list.Add(referencePoint);
											continue;
										}
										throw new LuaError("动作RP无效！");
									}
									eventAction_TeleportInArea.Area = list;
								}
								break;
							}
							case EventAction.EventActionType.Message:
							{
								EventAction_Message eventAction_Message = (EventAction_Message)eventAction;
								string string_4 = dictionary_[string_].ToString();
								if (Operators.CompareString(text3, "SideID", TextCompare: false) == 0)
								{
									side = PrivateMethods.ValidateSide(string_4, scenario_0);
									if (side == null)
									{
										throw new LuaError("Action.Message出错！");
									}
									eventAction_Message.SideID = side.ObjectID;
								}
								else if (Operators.CompareString(text3, "Text", TextCompare: false) == 0)
								{
									eventAction_Message.Text = dictionary_[string_].ToString();
								}
								break;
							}
							case EventAction.EventActionType.ChangeMissionStatus:
							{
								EventAction_ChangeMissionStatus eventAction_ChangeMissionStatus = (EventAction_ChangeMissionStatus)eventAction;
								string text5 = dictionary_[string_].ToString();
								if (Operators.CompareString(text3, "MissionID", TextCompare: false) == 0)
								{
									mission = LuaMission.ValidateMissionBySceanrio(text5, scenario_0);
									eventAction_ChangeMissionStatus.MissionID = mission.ObjectID;
								}
								else if (Operators.CompareString(text3, "NewStatus", TextCompare: false) == 0)
								{
									eventAction_ChangeMissionStatus.NewStatus = (Mission.MissionStatus)Conversions.ToByte(text5);
								}
								break;
							}
							case EventAction.EventActionType.LuaScript:
							{
								EventAction_LuaScript eventAction_LuaScript = (EventAction_LuaScript)eventAction;
								if (Operators.CompareString(text3, "ScriptText", TextCompare: false) == 0)
								{
									eventAction_LuaScript.ScriptText = dictionary_[string_].ToString();
								}
								break;
							}
							default:
								throw new LuaError("还没有实现！");
							case EventAction.EventActionType.EndScenario:
								break;
							}
							continue;
						}
						throw new LuaError("未找到操作键");
					}
					StringWriter stringWriter4 = new StringWriter(new StringBuilder());
					using (XmlWriter xmlWriter4 = new XmlTextWriter(stringWriter4))
					{
						eventAction.ToXML(xmlWriter4, hashSet_, scenario_0);
						xmlWriter4.Flush();
					}
					xmlDocument_.LoadXml(stringWriter4.ToString());
					break;
				}
				case "remove":
				{
					bool flag = false;
					if (dictionary_.ContainsKey("Description".ToUpper()))
					{
						text2 = dictionary_["Description".ToUpper()].ToString();
						foreach (EventAction value2 in scenario_0.EventActions.Values)
						{
							if (!string.Equals(value2.Description, text2, StringComparison.OrdinalIgnoreCase) && !string.Equals(value2.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								continue;
							}
							foreach (SimEvent value3 in scenario_0.SimEvents.Values)
							{
								foreach (EventAction action in value3.Actions)
								{
									if (Operators.CompareString(action.ObjectID, value2.ObjectID, TextCompare: false) == 0)
									{
										flag = true;
										break;
									}
								}
							}
							if (!flag)
							{
								eventAction = value2;
								break;
							}
						}
					}
					if (eventAction == null)
					{
						if (flag)
						{
							throw new LuaError("Event action in use (" + text2 + ")!");
						}
						throw new LuaError("Event action not found (" + text2 + ")!");
					}
					StringWriter stringWriter5 = new StringWriter(new StringBuilder());
					using (XmlWriter xmlWriter5 = new XmlTextWriter(stringWriter5))
					{
						eventAction.ToXML(xmlWriter5, hashSet_, scenario_0);
						xmlWriter5.Flush();
					}
					xmlDocument_.LoadXml(stringWriter5.ToString());
					scenario_0.EventActions.Remove(eventAction.ObjectID);
					break;
				}
				case "list":
				{
					if (dictionary_.ContainsKey("Description".ToUpper()))
					{
						text2 = dictionary_["Description".ToUpper()].ToString();
						foreach (EventAction value4 in scenario_0.EventActions.Values)
						{
							if (string.Equals(value4.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value4.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventAction = value4;
								break;
							}
						}
					}
					LuaTable val3 = LuaSandBox.Singleton().CreateTable();
					if (eventAction == null)
					{
						foreach (EventAction value5 in scenario_0.EventActions.Values)
						{
							LuaTable val4 = LuaSandBox.Singleton().CreateTable();
							StringWriter stringWriter2 = new StringWriter(new StringBuilder());
							using (XmlWriter xmlWriter2 = new XmlTextWriter(stringWriter2))
							{
								value5.ToXML(xmlWriter2, hashSet_, scenario_0);
								xmlWriter2.Flush();
							}
							xmlDocument_.LoadXml(stringWriter2.ToString());
							val4["xml"] = xmlDocument_.InnerXml;
							val4[value5.Type.ToString()] = ParseXMLtoTable(ref xmlDocument_);
							val3[val3.Keys.Count + 1] = val4;
						}
					}
					else
					{
						LuaTable val5 = LuaSandBox.Singleton().CreateTable();
						StringWriter stringWriter3 = new StringWriter(new StringBuilder());
						using (XmlWriter xmlWriter3 = new XmlTextWriter(stringWriter3))
						{
							eventAction.ToXML(xmlWriter3, hashSet_, scenario_0);
							xmlWriter3.Flush();
						}
						xmlDocument_.LoadXml(stringWriter3.ToString());
						val5["xml"] = xmlDocument_.InnerXml;
						val5[eventAction.Type.ToString()] = ParseXMLtoTable(ref xmlDocument_);
						val3[val3.Keys.Count + 1] = val5;
					}
					val["actions"] = val3;
					return val;
				}
				case "add":
					if (dictionary_.ContainsKey("Description".ToUpper()))
					{
						text2 = dictionary_["Description".ToUpper()].ToString();
						foreach (EventAction value6 in scenario_0.EventActions.Values)
						{
							if (string.Equals(value6.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value6.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								throw new LuaError("Existing event action (" + text2 + ")!");
							}
						}
						Dictionary<string, object> dictionary = dictionary_;
						Scenario scenario_ = scenario_0;
						List<ReferencePoint> list_ = null;
						dictionary.Add("XML", ParseDictToXML(ref dictionary_, scenario_, ref list_).OuterXml);
					}
					if (dictionary_.ContainsKey("XML".ToUpper()))
					{
						try
						{
							text2 = dictionary_["XML".ToUpper()].ToString();
							xmlDocument_ = new XmlDocument();
							xmlDocument_.LoadXml(text2);
							XmlNode xmlNode_ = xmlDocument_.DocumentElement;
							ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_ = null;
							eventAction = EventAction.FromXML(ref xmlNode_, ref concurrentDictionary_, ref scenario_0);
							scenario_0.EventActions.Add(eventAction.ObjectID, eventAction);
							StringWriter stringWriter = new StringWriter(new StringBuilder());
							using (XmlWriter xmlWriter = new XmlTextWriter(stringWriter))
							{
								eventAction.ToXML(xmlWriter, hashSet_, scenario_0);
								xmlWriter.Flush();
							}
							xmlDocument_.LoadXml(stringWriter.ToString());
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							throw new LuaError("无法解析事件XML！");
						}
						break;
					}
					throw new LuaError("Unable to add action (" + text2 + ")!");
				}
				val2["xml"] = xmlDocument_.InnerXml;
				val2[eventAction.Type.ToString()] = ParseXMLtoTable(ref xmlDocument_);
				val2["mode"] = text.ToUpper();
				val["actions"] = val2;
				return val;
			}
			}
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static object ScenEdit_SetEventTrigger(string string_0, LuaTable luaTable_0, Scenario scenario_0)
	{
		try
		{
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			HashSet<string> hashSet_ = new HashSet<string>();
			string b = string_0.ToLower();
			string text = "update";
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			string text2 = null;
			SimEvent simEvent = null;
			foreach (SimEvent value in scenario_0.SimEvents.Values)
			{
				if (string.Equals(value.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value.ObjectID, b, StringComparison.OrdinalIgnoreCase))
				{
					simEvent = value;
					break;
				}
			}
			if (!Information.IsNothing(simEvent))
			{
				if (dictionary.ContainsKey("mode".ToUpper()))
				{
					text = dictionary["mode".ToUpper()].ToString().ToLower();
				}
				switch (text)
				{
				default:
					throw new LuaError("未知的操作！");
				case "add":
				case "remove":
				case "replace":
				{
					XmlDocument xmlDocument_ = new XmlDocument();
					LuaTable val2 = LuaSandBox.Singleton().CreateTable();
					EventTrigger eventTrigger = null;
					if (!dictionary.ContainsKey("Description".ToUpper()))
					{
						if (!dictionary.ContainsKey("NAME"))
						{
							throw new LuaError("缺少触发器描述值！");
						}
						dictionary["Description".ToUpper()] = RuntimeHelpers.GetObjectValue(dictionary["NAME"]);
					}
					switch (text)
					{
					default:
						throw new LuaError("未知的操作！");
					case "update":
					{
						if (dictionary.ContainsKey("Description".ToUpper()))
						{
							try
							{
								text2 = dictionary["Description".ToUpper()].ToString();
							}
							catch (Exception projectError3)
							{
								ProjectData.SetProjectError(projectError3);
								throw new LuaError("无法解析事件描述！");
							}
							foreach (EventTrigger value2 in scenario_0.EventTriggers.Values)
							{
								if (string.Equals(value2.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
								{
									eventTrigger = value2;
									break;
								}
							}
						}
						if (eventTrigger == null)
						{
							throw new LuaError("Trigger not found (" + text2 + ")!");
						}
						StringWriter stringWriter4 = new StringWriter(new StringBuilder());
						using (XmlWriter xmlWriter4 = new XmlTextWriter(stringWriter4))
						{
							eventTrigger.ToXML(xmlWriter4, hashSet_, scenario_0);
							xmlWriter4.Flush();
						}
						xmlDocument_.LoadXml(stringWriter4.ToString());
						break;
					}
					case "replace":
					{
						if (dictionary.ContainsKey("Description".ToUpper()))
						{
							try
							{
								text2 = dictionary["Description".ToUpper()].ToString();
							}
							catch (Exception projectError)
							{
								ProjectData.SetProjectError(projectError);
								throw new LuaError("无法解析事件描述！");
							}
							foreach (EventTrigger value3 in scenario_0.EventTriggers.Values)
							{
								if (string.Equals(value3.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value3.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
								{
									eventTrigger = value3;
									break;
								}
							}
						}
						EventTrigger eventTrigger2 = null;
						if (dictionary.ContainsKey("ReplacedBy".ToUpper()))
						{
							try
							{
								text2 = dictionary["ReplacedBy".ToUpper()].ToString();
							}
							catch (Exception projectError2)
							{
								ProjectData.SetProjectError(projectError2);
								throw new LuaError("Unable to parse event ReplacedBy (" + text2 + ")!");
							}
							foreach (EventTrigger value4 in scenario_0.EventTriggers.Values)
							{
								if (string.Equals(value4.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value4.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
								{
									eventTrigger2 = value4;
									break;
								}
							}
						}
						if (eventTrigger != null && eventTrigger2 != null)
						{
							StringWriter stringWriter3 = new StringWriter(new StringBuilder());
							using (XmlWriter xmlWriter3 = new XmlTextWriter(stringWriter3))
							{
								eventTrigger.ToXML(xmlWriter3, hashSet_, scenario_0);
								xmlWriter3.Flush();
							}
							xmlDocument_.LoadXml(stringWriter3.ToString());
							simEvent.Triggers.Remove(eventTrigger);
							simEvent.Triggers.Add(eventTrigger2);
							break;
						}
						throw new LuaError("Trigger not found (" + text2 + ")!");
					}
					case "remove":
					{
						if (dictionary.ContainsKey("Description".ToUpper()))
						{
							text2 = dictionary["Description".ToUpper()].ToString();
							foreach (EventTrigger value5 in scenario_0.EventTriggers.Values)
							{
								if (string.Equals(value5.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value5.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
								{
									eventTrigger = value5;
									break;
								}
							}
						}
						if (eventTrigger == null)
						{
							throw new LuaError("Event trigger not found (" + text2 + ")!");
						}
						StringWriter stringWriter2 = new StringWriter(new StringBuilder());
						using (XmlWriter xmlWriter2 = new XmlTextWriter(stringWriter2))
						{
							eventTrigger.ToXML(xmlWriter2, hashSet_, scenario_0);
							xmlWriter2.Flush();
						}
						xmlDocument_.LoadXml(stringWriter2.ToString());
						simEvent.Triggers.Remove(eventTrigger);
						break;
					}
					case "add":
					{
						if (dictionary.ContainsKey("Description".ToUpper()))
						{
							text2 = dictionary["Description".ToUpper()].ToString();
							foreach (EventTrigger value6 in scenario_0.EventTriggers.Values)
							{
								if (string.Equals(value6.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value6.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
								{
									eventTrigger = value6;
									break;
								}
							}
						}
						if (eventTrigger == null)
						{
							throw new LuaError("Event trigger not found (" + text2 + ")!");
						}
						simEvent.Triggers.Add(eventTrigger);
						StringWriter stringWriter = new StringWriter(new StringBuilder());
						using (XmlWriter xmlWriter = new XmlTextWriter(stringWriter))
						{
							eventTrigger.ToXML(xmlWriter, hashSet_, scenario_0);
							xmlWriter.Flush();
						}
						xmlDocument_.LoadXml(stringWriter.ToString());
						break;
					}
					}
					val2["xml"] = xmlDocument_.InnerXml;
					val2[eventTrigger.Type.ToString()] = ParseXMLtoTable(ref xmlDocument_);
					val2["mode"] = text.ToUpper();
					val["triggers"] = val2;
					return val;
				}
				}
			}
			throw new LuaError("无法识别所需的事件！");
		}
		catch (Exception projectError4)
		{
			ProjectData.SetProjectError(projectError4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static object ScenEdit_SetEventCondition(string string_0, LuaTable luaTable_0, Scenario scenario_0)
	{
		try
		{
			HashSet<string> hashSet_ = new HashSet<string>();
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			string b = string_0.ToLower();
			string text = "update";
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			string text2 = null;
			SimEvent simEvent = null;
			foreach (SimEvent value in scenario_0.SimEvents.Values)
			{
				if (string.Equals(value.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value.ObjectID, b, StringComparison.OrdinalIgnoreCase))
				{
					simEvent = value;
				}
			}
			if (Information.IsNothing(simEvent))
			{
				throw new LuaError("无法识别所需的事件！");
			}
			if (dictionary.ContainsKey("mode".ToUpper()))
			{
				text = dictionary["mode".ToUpper()].ToString().ToLower();
			}
			switch (text)
			{
			default:
				throw new LuaError("未知的操作！");
			case "add":
			case "remove":
			case "replace":
			{
				XmlDocument xmlDocument_ = new XmlDocument();
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				EventCondition eventCondition = null;
				if (!dictionary.ContainsKey("Description".ToUpper()))
				{
					if (!dictionary.ContainsKey("NAME"))
					{
						throw new LuaError("缺少条件描述值！");
					}
					dictionary["Description".ToUpper()] = RuntimeHelpers.GetObjectValue(dictionary["NAME"]);
				}
				switch (text)
				{
				default:
					throw new LuaError("未知的操作！");
				case "update":
				{
					if (dictionary.ContainsKey("Description".ToUpper()))
					{
						try
						{
							text2 = dictionary["Description".ToUpper()].ToString();
						}
						catch (Exception projectError3)
						{
							ProjectData.SetProjectError(projectError3);
							throw new LuaError("无法解析事件描述！");
						}
						foreach (EventCondition value2 in scenario_0.EventConditions.Values)
						{
							if (string.Equals(value2.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventCondition = value2;
								break;
							}
						}
					}
					if (eventCondition == null)
					{
						throw new LuaError("Trigger not found (" + text2 + ")!");
					}
					StringWriter stringWriter4 = new StringWriter(new StringBuilder());
					using (XmlWriter xmlWriter4 = new XmlTextWriter(stringWriter4))
					{
						eventCondition.ToXML(xmlWriter4, hashSet_, scenario_0);
						xmlWriter4.Flush();
					}
					xmlDocument_.LoadXml(stringWriter4.ToString());
					break;
				}
				case "replace":
				{
					if (dictionary.ContainsKey("Description".ToUpper()))
					{
						try
						{
							text2 = dictionary["Description".ToUpper()].ToString();
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							throw new LuaError("无法解析事件描述！");
						}
						foreach (EventCondition value3 in scenario_0.EventConditions.Values)
						{
							if (string.Equals(value3.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value3.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventCondition = value3;
								break;
							}
						}
					}
					EventCondition eventCondition2 = null;
					if (dictionary.ContainsKey("ReplacedBy".ToUpper()))
					{
						try
						{
							text2 = dictionary["ReplacedBy".ToUpper()].ToString();
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							throw new LuaError("Unable to parse event ReplacedBy (" + text2 + ")!");
						}
						foreach (EventCondition value4 in scenario_0.EventConditions.Values)
						{
							if (string.Equals(value4.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value4.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventCondition2 = value4;
								break;
							}
						}
					}
					if (eventCondition != null && eventCondition2 != null)
					{
						StringWriter stringWriter3 = new StringWriter(new StringBuilder());
						using (XmlWriter xmlWriter3 = new XmlTextWriter(stringWriter3))
						{
							eventCondition.ToXML(xmlWriter3, hashSet_, scenario_0);
							xmlWriter3.Flush();
						}
						xmlDocument_.LoadXml(stringWriter3.ToString());
						simEvent.Conditions.Remove(eventCondition);
						simEvent.Conditions.Add(eventCondition2);
						break;
					}
					throw new LuaError("Trigger not found (" + text2 + ")!");
				}
				case "remove":
				{
					if (dictionary.ContainsKey("Description".ToUpper()))
					{
						text2 = dictionary["Description".ToUpper()].ToString();
						foreach (EventCondition value5 in scenario_0.EventConditions.Values)
						{
							if (string.Equals(value5.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value5.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventCondition = value5;
								break;
							}
						}
					}
					if (eventCondition == null)
					{
						throw new LuaError("Event trigger not found (" + text2 + ")!");
					}
					StringWriter stringWriter2 = new StringWriter(new StringBuilder());
					using (XmlWriter xmlWriter2 = new XmlTextWriter(stringWriter2))
					{
						eventCondition.ToXML(xmlWriter2, hashSet_, scenario_0);
						xmlWriter2.Flush();
					}
					xmlDocument_.LoadXml(stringWriter2.ToString());
					simEvent.Conditions.Remove(eventCondition);
					break;
				}
				case "add":
				{
					if (dictionary.ContainsKey("Description".ToUpper()))
					{
						text2 = dictionary["Description".ToUpper()].ToString();
						foreach (EventCondition value6 in scenario_0.EventConditions.Values)
						{
							if (string.Equals(value6.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value6.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventCondition = value6;
								break;
							}
						}
					}
					if (eventCondition == null)
					{
						throw new LuaError("Event trigger not found (" + text2 + ")!");
					}
					simEvent.Conditions.Add(eventCondition);
					StringWriter stringWriter = new StringWriter(new StringBuilder());
					using (XmlWriter xmlWriter = new XmlTextWriter(stringWriter))
					{
						eventCondition.ToXML(xmlWriter, hashSet_, scenario_0);
						xmlWriter.Flush();
					}
					xmlDocument_.LoadXml(stringWriter.ToString());
					break;
				}
				}
				val2["xml"] = xmlDocument_.InnerXml;
				val2[eventCondition.Type.ToString()] = ParseXMLtoTable(ref xmlDocument_);
				val2["mode"] = text.ToUpper();
				val["conditions"] = val2;
				return val;
			}
			}
		}
		catch (Exception projectError4)
		{
			ProjectData.SetProjectError(projectError4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static object ScenEdit_SetEventAction(string string_0, LuaTable luaTable_0, Scenario scenario_0)
	{
		try
		{
			HashSet<string> hashSet_ = new HashSet<string>();
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			string b = string_0.ToLower();
			string text = "update";
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			string text2 = null;
			SimEvent simEvent = null;
			foreach (SimEvent value in scenario_0.SimEvents.Values)
			{
				if (string.Equals(value.Description, b, StringComparison.OrdinalIgnoreCase) || string.Equals(value.ObjectID, b, StringComparison.OrdinalIgnoreCase))
				{
					simEvent = value;
				}
			}
			if (Information.IsNothing(simEvent))
			{
				throw new LuaError("无法识别所需的事件！");
			}
			if (dictionary.ContainsKey("mode".ToUpper()))
			{
				text = dictionary["mode".ToUpper()].ToString().ToLower();
			}
			switch (text)
			{
			default:
				throw new LuaError("未知的操作！");
			case "add":
			case "remove":
			case "replace":
			{
				XmlDocument xmlDocument_ = new XmlDocument();
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				EventAction eventAction = null;
				if (!dictionary.ContainsKey("Description".ToUpper()))
				{
					if (!dictionary.ContainsKey("NAME"))
					{
						throw new LuaError("缺少动作描述值！");
					}
					dictionary["Description".ToUpper()] = RuntimeHelpers.GetObjectValue(dictionary["NAME"]);
				}
				switch (text)
				{
				default:
					throw new LuaError("未知的操作！");
				case "update":
				{
					if (dictionary.ContainsKey("Description".ToUpper()))
					{
						try
						{
							text2 = dictionary["Description".ToUpper()].ToString();
						}
						catch (Exception projectError3)
						{
							ProjectData.SetProjectError(projectError3);
							throw new LuaError("无法解析事件描述！");
						}
						foreach (EventAction value2 in scenario_0.EventActions.Values)
						{
							if (string.Equals(value2.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value2.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventAction = value2;
								break;
							}
						}
					}
					if (eventAction == null)
					{
						throw new LuaError("Trigger not found (" + text2 + ")!");
					}
					StringWriter stringWriter4 = new StringWriter(new StringBuilder());
					using (XmlWriter xmlWriter4 = new XmlTextWriter(stringWriter4))
					{
						eventAction.ToXML(xmlWriter4, hashSet_, scenario_0);
						xmlWriter4.Flush();
					}
					xmlDocument_.LoadXml(stringWriter4.ToString());
					break;
				}
				case "replace":
				{
					if (dictionary.ContainsKey("Description".ToUpper()))
					{
						try
						{
							text2 = dictionary["Description".ToUpper()].ToString();
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							throw new LuaError("无法解析事件描述！");
						}
						foreach (EventAction value3 in scenario_0.EventActions.Values)
						{
							if (string.Equals(value3.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value3.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventAction = value3;
								break;
							}
						}
					}
					EventAction eventAction2 = null;
					if (dictionary.ContainsKey("ReplacedBy".ToUpper()))
					{
						try
						{
							text2 = dictionary["ReplacedBy".ToUpper()].ToString();
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							throw new LuaError("Unable to parse event ReplacedBy (" + text2 + ")!");
						}
						foreach (EventAction value4 in scenario_0.EventActions.Values)
						{
							if (string.Equals(value4.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value4.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventAction2 = value4;
								break;
							}
						}
					}
					if (eventAction != null && eventAction2 != null)
					{
						StringWriter stringWriter3 = new StringWriter(new StringBuilder());
						using (XmlWriter xmlWriter3 = new XmlTextWriter(stringWriter3))
						{
							eventAction.ToXML(xmlWriter3, hashSet_, scenario_0);
							xmlWriter3.Flush();
						}
						xmlDocument_.LoadXml(stringWriter3.ToString());
						simEvent.Actions.Remove(eventAction);
						simEvent.Actions.Add(eventAction2);
						break;
					}
					throw new LuaError("Trigger not found (" + text2 + ")!");
				}
				case "remove":
				{
					if (dictionary.ContainsKey("Description".ToUpper()))
					{
						text2 = dictionary["Description".ToUpper()].ToString();
						foreach (EventAction value5 in scenario_0.EventActions.Values)
						{
							if (string.Equals(value5.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value5.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventAction = value5;
								break;
							}
						}
					}
					if (eventAction == null)
					{
						throw new LuaError("Event trigger not found (" + text2 + ")!");
					}
					StringWriter stringWriter2 = new StringWriter(new StringBuilder());
					using (XmlWriter xmlWriter2 = new XmlTextWriter(stringWriter2))
					{
						eventAction.ToXML(xmlWriter2, hashSet_, scenario_0);
						xmlWriter2.Flush();
					}
					xmlDocument_.LoadXml(stringWriter2.ToString());
					simEvent.Actions.Remove(eventAction);
					break;
				}
				case "add":
				{
					if (dictionary.ContainsKey("Description".ToUpper()))
					{
						text2 = dictionary["Description".ToUpper()].ToString();
						foreach (EventAction value6 in scenario_0.EventActions.Values)
						{
							if (string.Equals(value6.Description, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(value6.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
							{
								eventAction = value6;
								break;
							}
						}
					}
					if (eventAction == null)
					{
						throw new LuaError("Event trigger not found (" + text2 + ")!");
					}
					simEvent.Actions.Add(eventAction);
					StringWriter stringWriter = new StringWriter(new StringBuilder());
					using (XmlWriter xmlWriter = new XmlTextWriter(stringWriter))
					{
						eventAction.ToXML(xmlWriter, hashSet_, scenario_0);
						xmlWriter.Flush();
					}
					xmlDocument_.LoadXml(stringWriter.ToString());
					break;
				}
				}
				val2["xml"] = xmlDocument_.InnerXml;
				val2[eventAction.Type.ToString()] = ParseXMLtoTable(ref xmlDocument_);
				val2["mode"] = text.ToUpper();
				val["actions"] = val2;
				return val;
			}
			}
		}
		catch (Exception projectError4)
		{
			ProjectData.SetProjectError(projectError4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static string ToXML_ViaStringBuilder(bool bool_0, Scenario scenario_0)
	{
		StringWriter stringWriter = new StringWriter(new StringBuilder());
		XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
		if (!bool_0)
		{
			xmlTextWriter.Formatting = Formatting.Indented;
			xmlTextWriter.Indentation = 4;
		}
		try
		{
			HashSet<string> hashSet_ = new HashSet<string>();
			using (xmlTextWriter)
			{
				xmlTextWriter.WriteStartElement("EventTriggers");
				foreach (EventTrigger value in scenario_0.EventTriggers.Values)
				{
					value.ToXML(xmlTextWriter, hashSet_, scenario_0);
				}
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.WriteStartElement("EventConditions");
				foreach (EventCondition value2 in scenario_0.EventConditions.Values)
				{
					value2.ToXML(xmlTextWriter, hashSet_, scenario_0);
				}
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.WriteStartElement("EventActions");
				foreach (EventAction value3 in scenario_0.EventActions.Values)
				{
					value3.ToXML(xmlTextWriter, hashSet_, scenario_0);
				}
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.WriteStartElement("SimEvents");
				foreach (SimEvent value4 in scenario_0.SimEvents.Values)
				{
					value4.ToXML(xmlTextWriter, hashSet_, scenario_0);
				}
				xmlTextWriter.WriteEndElement();
				Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
				Side[] array = sides_ReadOnly;
				foreach (Side side in array)
				{
					if (!side.SpecialActions.Any())
					{
						continue;
					}
					xmlTextWriter.WriteStartElement("SpecialActions");
					foreach (SpecialAction value5 in side.SpecialActions.Values)
					{
						value5.ToXML(xmlTextWriter, hashSet_, scenario_0);
					}
					xmlTextWriter.WriteEndElement();
				}
			}
			hashSet_ = null;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return stringWriter.ToString();
	}

	public static LuaTable ParseXMLtoTable(ref XmlDocument xmlDocument_0)
	{
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		IEnumerator enumerator = null;
		try
		{
			enumerator = xmlDocument_0.DocumentElement.ChildNodes.GetEnumerator();
			IEnumerator enumerator2 = null;
			IEnumerator enumerator3 = null;
			IEnumerator enumerator4 = null;
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (xmlNode.NodeType != XmlNodeType.Element)
				{
					continue;
				}
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				if (xmlNode.ChildNodes.Count <= 1)
				{
					string name = xmlNode.Name;
					val[name] = xmlNode.InnerXml;
					continue;
				}
				LuaTable val3 = LuaSandBox.Singleton().CreateTable();
				string name2;
				try
				{
					enumerator2 = xmlNode.ChildNodes.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
						if (xmlNode2.ChildNodes.Count <= 1)
						{
							name2 = xmlNode2.Name;
							val2[name2] = xmlNode2.InnerXml;
							Information.IsNothing(xmlNode2.NextSibling);
							continue;
						}
						LuaTable val4 = LuaSandBox.Singleton().CreateTable();
						try
						{
							enumerator3 = xmlNode2.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode3 = (XmlNode)enumerator3.Current;
								name2 = xmlNode3.Name;
								val4[xmlNode3.Name] = xmlNode3.InnerXml;
								Information.IsNothing(xmlNode3.NextSibling);
							}
						}
						finally
						{
							if (enumerator3 is IDisposable)
							{
								(enumerator3 as IDisposable).Dispose();
							}
						}
						name2 = xmlNode2.Name;
						try
						{
							enumerator4 = val3.Keys.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								if (RuntimeHelpers.GetObjectValue(enumerator4.Current).Equals(name2))
								{
									name2 += val3.Keys.Count;
									break;
								}
							}
						}
						finally
						{
							if (enumerator4 is IDisposable)
							{
								(enumerator4 as IDisposable).Dispose();
							}
						}
						val3[name2] = val4;
						val2 = val3;
					}
				}
				finally
				{
					if (enumerator2 is IDisposable)
					{
						(enumerator2 as IDisposable).Dispose();
					}
				}
				name2 = xmlNode.Name;
				val[name2] = val2;
			}
			return val;
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
	}

	public static XmlDocument ParseDictToXML(ref Dictionary<string, object> dictionary_0, Scenario scenario_0, ref List<ReferencePoint> list_0)
	{
		Side side = null;
		StringWriter stringWriter = new StringWriter(new StringBuilder());
		XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
		HashSet<string> hashSet_ = new HashSet<string>();
		string left = "update";
		string string_ = null;
		string string_2 = null;
		if (dictionary_0.ContainsKey("TYPEOF"))
		{
			string_ = Conversions.ToString(dictionary_0["TYPEOF"]);
			switch (string_)
			{
			default:
				throw new LuaError("未知类型的事件！");
			case "Action":
			case "Condition":
			case "Trigger":
				break;
			}
		}
		if (dictionary_0.ContainsKey("MODE"))
		{
			left = Conversions.ToString(dictionary_0["MODE"]);
		}
		if (dictionary_0.ContainsKey("TYPE"))
		{
			string_2 = Conversions.ToString(dictionary_0["TYPE"]);
		}
		if (string_2 == null)
		{
			throw new LuaError("未知的子类型" + string_);
		}
		if (Operators.CompareString(left, "add", TextCompare: false) == 0)
		{
			if (!dictionary_0.ContainsKey("EarliestTime".ToUpper()))
			{
				dictionary_0["EarliestTime".ToUpper()] = scenario_0.StartTime;
			}
			if (!dictionary_0.ContainsKey("ETOA".ToUpper()))
			{
				dictionary_0["ETOA".ToUpper()] = scenario_0.StartTime;
			}
			if (!dictionary_0.ContainsKey("LatestTime".ToUpper()))
			{
				dictionary_0["LatestTime".ToUpper()] = scenario_0.StartTime + scenario_0.Duration;
			}
			if (!dictionary_0.ContainsKey("LTOA".ToUpper()))
			{
				dictionary_0["LTOA".ToUpper()] = scenario_0.StartTime + scenario_0.Duration;
			}
			if (!dictionary_0.ContainsKey("Interval".ToUpper()))
			{
				dictionary_0["Interval".ToUpper()] = EventTrigger_RegularTime.RegularTimeInterval.OneMinute.ToString();
			}
			if (dictionary_0.ContainsKey("ExitArea".ToUpper()) && string.Equals(Conversions.ToString(dictionary_0["ExitArea".ToUpper()]), "False", StringComparison.OrdinalIgnoreCase))
			{
				dictionary_0.Remove("ExitArea".ToUpper());
			}
			if (dictionary_0.ContainsKey("NOT".ToUpper()) && string.Equals(Conversions.ToString(dictionary_0["NOT".ToUpper()]), "False", StringComparison.OrdinalIgnoreCase))
			{
				dictionary_0.Remove("NOT".ToUpper());
			}
		}
		using (xmlTextWriter)
		{
			List<ReferencePoint> list = new List<ReferencePoint>();
			List<ActiveUnit> list2 = new List<ActiveUnit>();
			string string_3 = "Event" + string_ + "_" + string_2;
			string localName = ValidateTriggerOrConditionOrActionPropertyName(ref string_3, ref string_, ref string_2);
			xmlTextWriter.WriteStartElement(localName);
			foreach (string key in dictionary_0.Keys)
			{
				string string_4 = key;
				switch (string_4.ToLower())
				{
				case "mode":
				case "type":
				case "typeof":
					continue;
				}
				string text = ValidateTriggerOrConditionOrActionPropertyName(ref string_4, ref string_, ref string_2);
				string text2 = null;
				string text3 = text;
				switch (text3)
				{
				case "TD":
				{
					text2 = Conversions.ToString(dictionary_0[string_4]);
					long result3 = 0L;
					text2 = (long.TryParse(text2, out result3) ? result3.ToString() : LuaUtility.ParseDateAsSeconds(text2).ToString());
					break;
				}
				case "MCL":
				{
					string text6 = null;
					text2 = Conversions.ToString(dictionary_0[string_4]);
					short[] array3 = (short[])Enum.GetValues(typeof(Contact_Base.IdentificationStatus));
					int num4 = 0;
					while (num4 < array3.Length)
					{
						short num5 = array3[num4];
						if (!string.Equals(text2, num5.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							string a3 = text2;
							Contact_Base.IdentificationStatus identificationStatus = (Contact_Base.IdentificationStatus)num5;
							if (!string.Equals(a3, identificationStatus.ToString(), StringComparison.OrdinalIgnoreCase))
							{
								num4 = checked(num4 + 1);
								continue;
							}
						}
						text6 = Conversions.ToString((int)num5);
						break;
					}
					text2 = ((text6 == null) ? Conversions.ToString(0) : text6);
					break;
				}
				case "Area":
				{
					list.Clear();
					side = null;
					List<object> list3 = LuaUtility.ToArray(((LuaTable)dictionary_0["AREA"]).GetEnumerator());
					Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
					Side[] array4 = sides_ReadOnly;
					foreach (Side side2 in array4)
					{
						foreach (object item in list3)
						{
							object Local_o = RuntimeHelpers.GetObjectValue(item);
							if (!Information.IsNothing(side2.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o.ToString(), StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase))))
							{
								side = side2;
								break;
							}
						}
						if (side != null)
						{
							break;
						}
					}
					if (side != null)
					{
						foreach (object item2 in list3)
						{
							object Local_o2 = RuntimeHelpers.GetObjectValue(item2);
							ReferencePoint referencePoint = null;
							if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => Operators.CompareString(s.Name, Local_o2.ToString(), TextCompare: false) == 0)))
							{
								if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase))))
								{
									if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase))))
									{
										if (!Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase))))
										{
											referencePoint = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase));
										}
									}
									else
									{
										referencePoint = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase));
									}
								}
								else
								{
									referencePoint = side.RefPoints.First((ReferencePoint s) => string.Equals(s.Name, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase));
								}
							}
							else
							{
								referencePoint = side.RefPoints.First((ReferencePoint s) => Operators.CompareString(s.Name, Local_o2.ToString(), TextCompare: false) == 0);
							}
							if (Information.IsNothing(referencePoint))
							{
								text = null;
							}
							else
							{
								list.Add(referencePoint);
							}
						}
						if (text == null)
						{
							break;
						}
						xmlTextWriter.WriteStartElement(text);
						foreach (ReferencePoint item3 in list)
						{
							xmlTextWriter.WriteRaw(item3.ToXML(ref hashSet_));
						}
						xmlTextWriter.WriteEndElement();
						if (list_0 != null)
						{
							list_0 = list;
						}
						break;
					}
					throw new LuaError("无法确定RP的一面！");
				}
				case "MissionID":
				{
					text2 = Conversions.ToString(dictionary_0[string_4]);
					Mission mission = LuaMission.ValidateMissionBySceanrio(text2, scenario_0);
					if (mission != null)
					{
						text2 = mission.ObjectID;
						break;
					}
					text = null;
					throw new LuaError("无法确定任务！");
				}
				case "UnitIDs":
					list2.Clear();
					foreach (object item4 in LuaUtility.ToArray(((LuaTable)dictionary_0["UNITIDS"]).GetEnumerator()))
					{
						ActiveUnit activeUnit = PrivateMethods.smethod_0(RuntimeHelpers.GetObjectValue(item4).ToString(), scenario_0);
						if (!Information.IsNothing(activeUnit))
						{
							list2.Add(activeUnit);
							hashSet_.Add(activeUnit.ObjectID);
							continue;
						}
						text = null;
						break;
					}
					if (text == null)
					{
						break;
					}
					xmlTextWriter.WriteStartElement(text);
					foreach (ActiveUnit item5 in list2)
					{
						XmlWriter xmlWriter_ = xmlTextWriter;
						item5.ToXML(ref xmlWriter_, ref hashSet_);
					}
					xmlTextWriter.WriteEndElement();
					break;
				case "SideID":
				case "TargetSideID":
				case "DetectorSideID":
				case "ObserverSideID":
					text2 = Conversions.ToString(dictionary_0[string_4]);
					side = PrivateMethods.ValidateSide(text2, scenario_0);
					if (side != null)
					{
						text2 = side.ObjectID;
						break;
					}
					text = null;
					throw new LuaError("无法确定分方！");
				case "TargetFilter":
				{
					UnitFilterObject unitFilterObject = smethod_1(ref dictionary_0, scenario_0);
					xmlTextWriter.WriteStartElement(text);
					unitFilterObject.ToXML(xmlTextWriter, hashSet_, scenario_0);
					xmlTextWriter.WriteEndElement();
					text = null;
					break;
				}
				case "Interval":
				{
					text2 = Conversions.ToString(dictionary_0[string_4]);
					string text4 = null;
					int[] array = (int[])Enum.GetValues(typeof(EventTrigger_RegularTime.RegularTimeInterval));
					int num = 0;
					while (num < array.Length)
					{
						int num2 = array[num];
						if (!string.Equals(text2, num2.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							string a = text2;
							EventTrigger_RegularTime.RegularTimeInterval regularTimeInterval = (EventTrigger_RegularTime.RegularTimeInterval)num2;
							if (!string.Equals(a, regularTimeInterval.ToString(), StringComparison.OrdinalIgnoreCase))
							{
								num = checked(num + 1);
								continue;
							}
						}
						text4 = Conversions.ToString(num2);
						break;
					}
					if (text4 != null)
					{
						text2 = text4;
						break;
					}
					text = null;
					throw new LuaError("无法解析Interval！");
				}
				case "TargetPosture":
				{
					text2 = Conversions.ToString(dictionary_0[string_4]);
					string text5 = null;
					byte[] array2 = (byte[])Enum.GetValues(typeof(Misc.PostureStance));
					int num3 = 0;
					while (num3 < array2.Length)
					{
						byte b = array2[num3];
						if (!string.Equals(text2, b.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							string a2 = text2;
							Misc.PostureStance postureStance = (Misc.PostureStance)b;
							if (!string.Equals(a2, postureStance.ToString(), StringComparison.OrdinalIgnoreCase))
							{
								num3 = checked(num3 + 1);
								continue;
							}
						}
						text5 = Conversions.ToString(b);
						break;
					}
					text2 = ((text5 == null) ? Conversions.ToString((byte)4) : text5);
					break;
				}
				case "CargoFilter":
				{
					CargoFilterObject cargoFilterObject = smethod_2(ref dictionary_0, scenario_0);
					xmlTextWriter.WriteStartElement(text);
					cargoFilterObject.ToXML(xmlTextWriter, hashSet_, scenario_0);
					xmlTextWriter.WriteEndElement();
					text = null;
					break;
				}
				default:
					if (Operators.CompareString(text3, null, TextCompare: false) != 0)
					{
						text2 = Conversions.ToString(dictionary_0[string_4]);
					}
					break;
				case "LTOA":
				case "EarliestTime":
				case "ETOA":
				case "LatestTime":
				case "Time":
				{
					text2 = Conversions.ToString(dictionary_0[string_4]);
					long result = 0L;
					DateTime result2 = DateTime.MinValue;
					if (!long.TryParse(text2, out result))
					{
						if (DateTime.TryParse(text2, out result2))
						{
							text2 = result2.ToBinary().ToString();
						}
						else
						{
							text = null;
						}
					}
					break;
				}
				}
				if (text == null)
				{
					if (Operators.CompareString(string_4, "XML".ToUpper(), TextCompare: false) == 0)
					{
						xmlTextWriter.WriteElementString(string_4, text2);
					}
				}
				else
				{
					xmlTextWriter.WriteElementString(text, text2);
				}
			}
			xmlTextWriter.WriteEndElement();
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(stringWriter.ToString());
		return xmlDocument;
	}

	private static void smethod_0(Scenario scenario_0, ref EventTrigger eventTrigger_0, List<ReferencePoint> list_0)
	{
		List<ReferencePoint> list = null;
		switch (eventTrigger_0.Type)
		{
		default:
			return;
		case EventTrigger.EventTriggerType.UnitEmissions:
			list = ((EventTrigger_UnitEmissions)eventTrigger_0).Area;
			break;
		case EventTrigger.EventTriggerType.UnitEntersArea:
			list = ((EventTrigger_UnitEntersArea)eventTrigger_0).Area;
			break;
		case EventTrigger.EventTriggerType.UnitRemainsInArea:
			list = ((EventTrigger_UnitRemainsInArea)eventTrigger_0).Area;
			break;
		}
		if (list_0 != null)
		{
			list = list_0;
		}
		if (list == null || list.Count == 0)
		{
			return;
		}
		foreach (ReferencePoint item in list)
		{
			if (Operators.CompareString(item._MerchantFacade, "", TextCompare: false) == 0)
			{
				continue;
			}
			if (item.IsRelativeTo == null || Operators.CompareString(item.IsRelativeTo.ObjectID, item._MerchantFacade, TextCompare: false) != 0)
			{
				ActiveUnit activeUnit = PrivateMethods.smethod_0(item._MerchantFacade, scenario_0);
				if (activeUnit != null)
				{
					item.IsRelativeTo = activeUnit;
					item.AdjustForRelativeHooking();
				}
				if (item.IsRelativeTo == null)
				{
					Contact contact = PrivateMethods.ValidateContactBySceanrio(item._MerchantFacade, scenario_0);
					if (contact != null)
					{
						item.IsRelativeTo = contact;
						item.AdjustForRelativeHooking();
					}
				}
				if (item.IsRelativeTo == null)
				{
					Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
					for (int i = 0; i < sides_ReadOnly.Length; i++)
					{
						foreach (ReferencePoint refPoint in sides_ReadOnly[i].RefPoints)
						{
							if (Operators.CompareString(refPoint.ObjectID, item._MerchantFacade, TextCompare: false) == 0)
							{
								item.IsRelativeTo = refPoint;
								item.AdjustForRelativeHooking();
							}
						}
					}
				}
			}
			item._MerchantFacade = "";
		}
		switch (eventTrigger_0.Type)
		{
		case EventTrigger.EventTriggerType.UnitEmissions:
			((EventTrigger_UnitEmissions)eventTrigger_0).Area = list;
			break;
		case EventTrigger.EventTriggerType.UnitEntersArea:
			((EventTrigger_UnitEntersArea)eventTrigger_0).Area = list;
			break;
		case EventTrigger.EventTriggerType.UnitRemainsInArea:
			((EventTrigger_UnitRemainsInArea)eventTrigger_0).Area = list;
			break;
		}
	}

	private static UnitFilterObject smethod_1(ref Dictionary<string, object> dictionary_0, Scenario scenario_0)
	{
		ActiveUnit activeUnit = null;
		Side side = null;
		UnitFilterObject unitFilterObject = new UnitFilterObject();
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)dictionary_0["TARGETFILTER"]).GetEnumerator());
		foreach (string key in dictionary.Keys)
		{
			string text = dictionary[key].ToString();
			switch (key.ToUpper())
			{
			case "TARGETTYPE":
			{
				byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.ActiveUnitType));
				int num = 0;
				while (num < array.Length)
				{
					byte b = array[num];
					if (!string.Equals(text, b.ToString(), StringComparison.OrdinalIgnoreCase))
					{
						GlobalVariables.ActiveUnitType activeUnitType = (GlobalVariables.ActiveUnitType)b;
						if (!string.Equals(text, activeUnitType.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							num = checked(num + 1);
							continue;
						}
					}
					unitFilterObject.TargetType = (GlobalVariables.ActiveUnitType)b;
					break;
				}
				if (unitFilterObject.TargetType == GlobalVariables.ActiveUnitType.None)
				{
					throw new LuaError("TargetFilter.Type出错！");
				}
				break;
			}
			case "TARGETSUBTYPE":
				unitFilterObject.TargetSubType = Conversions.ToInteger(text);
				break;
			case "TARGETSIDE":
				side = PrivateMethods.ValidateSide(text, scenario_0);
				if (side != null)
				{
					unitFilterObject.TargetSide = side.ObjectID;
					break;
				}
				throw new LuaError("TargetFilter.Side出错！");
			case "SPECIFICUNITID":
				activeUnit = PrivateMethods.smethod_0(text, scenario_0);
				if (activeUnit != null)
				{
					unitFilterObject.SpecificUnitID = activeUnit.ObjectID;
					break;
				}
				throw new LuaError("TargetFilter.Unit出错！");
			case "SPECIFICUNITCLASS":
				unitFilterObject.SpecificUnitClass = Conversions.ToInteger(text);
				break;
			}
		}
		if (unitFilterObject.SpecificUnitID == null)
		{
			if (unitFilterObject.TargetSide != null)
			{
				if (unitFilterObject.SpecificUnitClass == 0)
				{
					if (unitFilterObject.TargetSubType != 0 && unitFilterObject.TargetType == GlobalVariables.ActiveUnitType.None)
					{
						throw new LuaError("TargetFilter.SubType出错！");
					}
				}
				else
				{
					switch (unitFilterObject.TargetType)
					{
					case GlobalVariables.ActiveUnitType.Aircraft:
						unitFilterObject.TargetSubType = DBFunctions.GetAircraftType_Int(ref scenario_0, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Ship:
						unitFilterObject.TargetSubType = DBFunctions.GetShipType_Int(ref scenario_0, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Submarine:
						unitFilterObject.TargetSubType = DBFunctions.GetSubmarineType_Int(ref scenario_0, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Facility:
						unitFilterObject.TargetSubType = DBFunctions.GetFacilityType_Int(ref scenario_0, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Weapon:
						unitFilterObject.TargetSubType = DBFunctions.GetWeaponType_Int(ref scenario_0, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Satellite:
						unitFilterObject.TargetSubType = DBFunctions.GetSatelliteType_Int(ref scenario_0, unitFilterObject.SpecificUnitClass);
						break;
					}
					if (unitFilterObject.TargetSubType == 0 || unitFilterObject.TargetType == GlobalVariables.ActiveUnitType.None)
					{
						throw new LuaError("TargetFilter.Class中的错误！");
					}
				}
			}
		}
		else
		{
			unitFilterObject.SpecificUnitClass = activeUnit.DBID;
			unitFilterObject.TargetSubType = activeUnit.SubType;
			unitFilterObject.TargetType = activeUnit.UnitType;
			unitFilterObject.TargetSide = activeUnit.GetUnitSide().ObjectID;
		}
		return unitFilterObject;
	}

	private static CargoFilterObject smethod_2(ref Dictionary<string, object> dictionary_0, object object_0)
	{
		ActiveUnit activeUnit = null;
		CargoFilterObject cargoFilterObject = new CargoFilterObject();
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)dictionary_0["CARGOFILTER"]).GetEnumerator());
		foreach (string key in dictionary.Keys)
		{
			string text = dictionary[key].ToString();
			switch (key.ToUpper())
			{
			case "TARGETLIMITRECEIVED":
				cargoFilterObject.ThresholdReceived = Conversions.ToInteger(text);
				break;
			case "TARGETTYPE":
			{
				int[] array = (int[])Enum.GetValues(typeof(CargoType));
				int num = 0;
				while (num < array.Length)
				{
					int num2 = array[num];
					if (!string.Equals(text, num2.ToString(), StringComparison.OrdinalIgnoreCase))
					{
						CargoType cargoType = (CargoType)num2;
						if (!string.Equals(text, cargoType.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							num = checked(num + 1);
							continue;
						}
					}
					cargoFilterObject.cargoType = (CargoType)num2;
					break;
				}
				if (cargoFilterObject.cargoType == CargoType.NoCargo)
				{
					throw new LuaError("CargoFilter.Type出错！");
				}
				break;
			}
			case "SPECIFICUNITCLASS":
				cargoFilterObject.SpecificCargoDBID = Conversions.ToInteger(text);
				break;
			case "SPECIFICUNITID":
				cargoFilterObject.SpecificCargoObjID = activeUnit.ObjectID;
				break;
			case "TARGETLIMITSENT":
				cargoFilterObject.ThresholdSent = Conversions.ToInteger(text);
				break;
			case "TARGETRECEIVED":
				cargoFilterObject.Received = Conversions.ToInteger(text);
				break;
			case "TARGETSENT":
				cargoFilterObject.Sent = Conversions.ToInteger(text);
				break;
			}
		}
		if (cargoFilterObject.SpecificCargoObjID == null && cargoFilterObject.SpecificCargoDBID == 0 && cargoFilterObject.cargoType == CargoType.NoCargo)
		{
			throw new LuaError("CargoFilter.cargoType出错！");
		}
		return cargoFilterObject;
	}

	public static void AddUnitToSerialized(ref EventTrigger eventTrigger_0, HashSet<string> hashSet_0)
	{
		UnitFilterObject unitFilterObject = new UnitFilterObject();
		CargoFilterObject cargoFilterObject = new CargoFilterObject();
		switch (eventTrigger_0.Type)
		{
		case EventTrigger.EventTriggerType.UnitDestroyed:
			unitFilterObject = ((EventTrigger_UnitDestroyed)eventTrigger_0).TargetFilter;
			if (unitFilterObject.SpecificUnitID != null)
			{
				hashSet_0.Add(unitFilterObject.SpecificUnitID);
			}
			break;
		case EventTrigger.EventTriggerType.UnitDamaged:
			unitFilterObject = ((EventTrigger_UnitDamaged)eventTrigger_0).TargetFilter;
			if (unitFilterObject.SpecificUnitID != null)
			{
				hashSet_0.Add(unitFilterObject.SpecificUnitID);
			}
			break;
		case EventTrigger.EventTriggerType.UnitRemainsInArea:
			unitFilterObject = ((EventTrigger_UnitRemainsInArea)eventTrigger_0).TargetFilter;
			if (unitFilterObject.SpecificUnitID != null)
			{
				hashSet_0.Add(unitFilterObject.SpecificUnitID);
			}
			break;
		case EventTrigger.EventTriggerType.UnitEntersArea:
			unitFilterObject = ((EventTrigger_UnitEntersArea)eventTrigger_0).TargetFilter;
			if (unitFilterObject.SpecificUnitID != null)
			{
				hashSet_0.Add(unitFilterObject.SpecificUnitID);
			}
			break;
		case EventTrigger.EventTriggerType.UnitDetected:
			unitFilterObject = ((EventTrigger_UnitDetected)eventTrigger_0).TargetFilter;
			if (unitFilterObject.SpecificUnitID != null)
			{
				hashSet_0.Add(unitFilterObject.SpecificUnitID);
			}
			break;
		case EventTrigger.EventTriggerType.UnitBaseStatus:
			unitFilterObject = ((EventTrigger_UnitBaseStatus)eventTrigger_0).TargetFilter;
			if (unitFilterObject.SpecificUnitID != null)
			{
				hashSet_0.Add(unitFilterObject.SpecificUnitID);
			}
			break;
		case EventTrigger.EventTriggerType.UnitEmissions:
			unitFilterObject = ((EventTrigger_UnitEmissions)eventTrigger_0).TargetFilter;
			if (unitFilterObject.SpecificUnitID != null)
			{
				hashSet_0.Add(unitFilterObject.SpecificUnitID);
			}
			break;
		case EventTrigger.EventTriggerType.UnitCargoMoved:
			cargoFilterObject = ((EventTrigger_UnitCargoMoved)eventTrigger_0).TargetFilter;
			if (cargoFilterObject.SpecificCargoObjID != null)
			{
				hashSet_0.Add(cargoFilterObject.SpecificCargoObjID);
			}
			break;
		case EventTrigger.EventTriggerType.Points:
		case EventTrigger.EventTriggerType.Time:
		case EventTrigger.EventTriggerType.RandomTime:
		case EventTrigger.EventTriggerType.ScenLoaded:
		case EventTrigger.EventTriggerType.RegularTime:
		case EventTrigger.EventTriggerType.ScenEnded:
			break;
		}
	}

	private static string ValidateTriggerOrConditionOrActionPropertyName(ref string string_0, ref string string_1, ref string string_2)
	{
		string result = null;
		switch (string_1)
		{
		case "Trigger":
		{
			string[] array6 = null;
			switch (string_2.ToLower())
			{
			case "unitdestroyed":
				array6 = Keyword_Triggers_UnitDestroyed;
				break;
			case "unitdetected":
				array6 = Keyword_Triggers_UnitDetected;
				break;
			case "unitemissions":
				array6 = Keyword_Triggers_UnitEmissions;
				break;
			case "time":
				array6 = Keyword_Triggers_Time;
				break;
			case "unitentersarea":
				array6 = Keyword_Triggers_UnitEntersArea;
				break;
			case "unitcargomoved":
				array6 = Keyword_Triggers_UnitCargoMoved;
				break;
			case "regulartime":
				array6 = Keyword_Triggers_RegularTime;
				break;
			case "scenended":
				array6 = Keyword_Triggers_ScenEnded;
				break;
			case "unitdamaged":
				array6 = Keyword_Triggers_UnitDamaged;
				break;
			case "scenloaded":
				array6 = Keyword_Triggers_ScenLoaded;
				break;
			case "unitbasestatus":
				array6 = Keyword_Triggers_UnitBaseStatus;
				break;
			case "points":
				array6 = Keyword_Triggers_Points;
				break;
			case "unitremainsinarea":
				array6 = Keyword_Triggers_UnitRemainsInArea;
				break;
			case "randomtime":
				array6 = Keyword_Triggers_RandomTime;
				break;
			}
			string[] array4 = array6;
			string[] array9 = array4;
			foreach (string text3 in array9)
			{
				if (Operators.CompareString(text3.ToUpper(), string_0.ToUpper(), TextCompare: false) == 0)
				{
					result = text3;
					break;
				}
			}
			break;
		}
		case "Condition":
		{
			string[] array5 = null;
			switch (string_2.ToLower())
			{
			case "sideposture":
				array5 = Keyword_Conditions_SidePosture;
				break;
			case "scenhasstarted":
				array5 = Keyword_Conditions_ScenHasStarted;
				break;
			case "luascript":
				array5 = Keyword_Conditions_LuaScript;
				break;
			}
			string[] array3 = array5;
			string[] array8 = array3;
			foreach (string text2 in array8)
			{
				if (Operators.CompareString(text2.ToUpper(), string_0.ToUpper(), TextCompare: false) == 0)
				{
					result = text2;
					break;
				}
			}
			break;
		}
		case "Action":
		{
			string[] array = null;
			switch (string_2.ToLower())
			{
			case "teleportinarea":
				array = Keyword_Actions_TeleportInArea;
				break;
			case "points":
				array = Keyword_Actions_Points;
				break;
			case "message":
				array = Keyword_Actions_Message;
				break;
			case "luascript":
				array = Keyword_Actions_LuaScript;
				break;
			case "endscenario":
				array = Keyword_Actions_EndScenario;
				break;
			case "changemissionstatus":
				array = Keyword_Actions_ChangeMissionStatus;
				break;
			}
			string[] array2 = array;
			string[] array7 = array2;
			foreach (string text in array7)
			{
				if (Operators.CompareString(text.ToUpper(), string_0.ToUpper(), TextCompare: false) == 0)
				{
					result = text;
					break;
				}
			}
			break;
		}
		}
		return result;
	}
}
