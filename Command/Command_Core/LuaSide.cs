using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Command_Core.Lua;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core;

[StandardModule]
internal sealed class LuaSide
{
	public static LuaWrapper_Side ScenEdit_AddSide(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		string text = null;
		Side side = null;
		LuaUtility.ParseSideDict(ref dictionary_);
		if (dictionary_.ContainsKey("SIDE"))
		{
			try
			{
				text = Conversions.ToString(dictionary_["SIDE"]);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("分方必须是一个字符串");
			}
			try
			{
				side = LuaUtility.QuerySide(dictionary_, scenario_0);
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
		}
		if (side == null)
		{
			if (dictionary_.ContainsKey("NAME"))
			{
				try
				{
					text = Conversions.ToString(dictionary_["NAME"]);
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					throw new LuaError("分方必须是一个字符串");
				}
			}
			Side side_ = new Side(text, ref scenario_0);
			scenario_0.AddSide(side_);
			return new LuaWrapper_Side(side_, scenario_0);
		}
		throw new LuaError("分方" + text + "已经存在");
	}

	public static LuaWrapper_Side ScenEdit_RemoveSide(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		ActiveUnit activeUnit = null;
		Side side = null;
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("SIDE"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dictionary_["SIDE"]);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("分方必须是一个字符串");
			}
			try
			{
				side = LuaUtility.QuerySide(dictionary_, scenario_0);
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				throw new LuaError("找不到分方'" + text + "'");
			}
		}
		LuaWrapper_Side result = new LuaWrapper_Side(side, scenario_0);
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
		{
			if (activeUnits_ != null && activeUnits_.GetUnitSide().Equals(side))
			{
				activeUnit = activeUnits_;
				if (activeUnit.IsGroup)
				{
					list.Add(activeUnit);
				}
				else if (scenario_0.ExecutionInProgress)
				{
					scenario_0.DeleteThisUnit(activeUnit);
				}
				else
				{
					scenario_0.DeleteUnitImmediately(activeUnit.ObjectID, bool_0: true, "Script action (remove side)");
				}
			}
		}
		if (list.Count > 0)
		{
			foreach (ActiveUnit item in list)
			{
				if (item != null)
				{
					activeUnit = item;
					if (scenario_0.ExecutionInProgress)
					{
						scenario_0.DeleteThisUnit(activeUnit);
					}
					else
					{
						scenario_0.DeleteUnitImmediately(activeUnit.ObjectID, bool_0: true, "Script action (remove side)");
					}
				}
			}
		}
		scenario_0.RemoveSide(side);
		return result;
	}

	public static LuaTable ScenEdit_SetSideOptions(LuaTable luaTable_0, Scenario scenario_0)
	{
		try
		{
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			Side side = null;
			if (dictionary.ContainsKey("SIDE"))
			{
				string text = null;
				try
				{
					text = Conversions.ToString(dictionary["SIDE"]);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					throw new LuaError("分方必须是一个字符串");
				}
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					throw new LuaError("找不到分方'" + text + "'");
				}
			}
			if (dictionary.ContainsKey("AWARENESS"))
			{
				Side.AwarenessLevel_Enum awarenessLevel;
				switch (Conversions.ToString(dictionary["AWARENESS"]).ToUpper())
				{
				case "2":
				case "AUTOUNIT":
					awarenessLevel = Side.AwarenessLevel_Enum.AutoSideAndUnitID;
					break;
				case "0":
				case "NORMAL":
					awarenessLevel = Side.AwarenessLevel_Enum.Normal;
					break;
				case "-1":
				case "BLIND":
					awarenessLevel = Side.AwarenessLevel_Enum.Blind;
					break;
				case "3":
				case "OMNI":
					awarenessLevel = Side.AwarenessLevel_Enum.Omniscient;
					break;
				default:
					throw new LuaError("感知代码无效！ （有效代码：-1 ... 3）");
				case "1":
				case "AUTOSIDE":
					awarenessLevel = Side.AwarenessLevel_Enum.AutoSideID;
					break;
				}
				side.AwarenessLevel = awarenessLevel;
			}
			if (dictionary.ContainsKey("PROFICIENCY"))
			{
				GlobalVariables.ProficiencyLevel proficiency;
				switch (Conversions.ToString(dictionary["PROFICIENCY"]).ToUpper())
				{
				case "NOVICE":
				case "0":
					proficiency = GlobalVariables.ProficiencyLevel.Novice;
					break;
				case "CADET":
				case "1":
					proficiency = GlobalVariables.ProficiencyLevel.Cadet;
					break;
				case "4":
				case "ACE":
					proficiency = GlobalVariables.ProficiencyLevel.Ace;
					break;
				case "3":
				case "VETERAN":
					proficiency = GlobalVariables.ProficiencyLevel.Veteran;
					break;
				default:
					throw new LuaError("能力代码无效！ （有效代码：0 ... 4）");
				case "2":
				case "REGULAR":
					proficiency = GlobalVariables.ProficiencyLevel.Regular;
					break;
				}
				side.Proficiency = proficiency;
			}
			if (dictionary.ContainsKey("SWITCHTO"))
			{
				bool? flag = LuaUtility.ParseBoolean(dictionary["SWITCHTO"].ToString());
				if (flag.HasValue)
				{
					bool? flag2 = flag;
					flag2 = flag2;
					if (flag2.GetValueOrDefault())
					{
						scenario_0.SetCurrentSide(side);
					}
				}
			}
			LuaUtility.FromDict(dictionary, luaTable_0);
			return PrivateMethods.ScenEdit_GetSideOptions(luaTable_0, scenario_0);
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

	public static bool ScenEdit_GetSideIsHuman(string string_0, Scenario scenario_0)
	{
		try
		{
			Side side = null;
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
			{
				side = sides_ReadOnly[i];
				if (string.Equals(side.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(side.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
				{
					side = side;
					break;
				}
			}
			if (Information.IsNothing(side))
			{
				throw new LuaError("无法识别分方！");
			}
			return side.IsHumanControlled;
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

	public static Side ValidateSide(string string_0, Scenario scenario_0)
	{
		Side result = null;
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			if (string.Equals(side.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(side.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
			{
				result = side;
				break;
			}
		}
		return result;
	}

	public static LuaWrapper_Side VP_GetSide(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		Side side = null;
		LuaUtility.ParseSideDict(ref dictionary_);
		if (dictionary_.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dictionary_["GUID"]);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("guid必须是一个字符串");
			}
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side2 in array)
			{
				if (string.Equals(side2.ObjectID, text, StringComparison.OrdinalIgnoreCase))
				{
					side = side2;
					break;
				}
			}
			if (Information.IsNothing(side))
			{
				throw new LuaError("无法找到分方匹配guid：" + text);
			}
		}
		else if (dictionary_.ContainsKey("SIDE"))
		{
			string text2;
			try
			{
				text2 = Conversions.ToString(dictionary_["SIDE"]);
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				throw new LuaError("名称必须是一个字符串");
			}
			side = LuaUtility.QuerySide(dictionary_, scenario_0);
			if (Information.IsNothing(side))
			{
				throw new LuaError("无法找到分方匹配名称：" + text2);
			}
		}
		if (Information.IsNothing(side))
		{
			throw new LuaError("无法找到分方");
		}
		return new LuaWrapper_Side(side, scenario_0);
	}

	public static bool ScenEdit_SetSidePosture(string string_0, string string_1, string string_2, Scenario scenario_0)
	{
		try
		{
			Side side = null;
			Side side2 = null;
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side3 in array)
			{
				if (string.Equals(side3.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(side3.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
				{
					side = side3;
				}
				if (string.Equals(side3.Name, string_1, StringComparison.OrdinalIgnoreCase) || string.Equals(side3.ObjectID, string_1, StringComparison.OrdinalIgnoreCase))
				{
					side2 = side3;
				}
			}
			if (Information.IsNothing(side))
			{
				throw new LuaError("无法识别Side-A！");
			}
			if (Information.IsNothing(side2))
			{
				throw new LuaError("无法识别Side-B！");
			}
			Side side4 = side;
			Side side_ = side2;
			if (1 == 0)
			{
			}
			Misc.PostureStance postureStance_ = string_2 switch
			{
				"U" => Misc.PostureStance.Unfriendly, 
				"N" => Misc.PostureStance.Neutral, 
				"H" => Misc.PostureStance.Hostile, 
				"F" => Misc.PostureStance.Friendly, 
				_ => throw new LuaError("无效的交战关系代码！ （有效代码：F，H，N，U）"), 
			};
			if (1 == 0)
			{
			}
			side4.SetConsidersThisSideToBe(side_, postureStance_);
			return true;
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

	public static LuaWrapper_Contact AddOrUpdateContact(Side side_0, Scenario scenario_0, LuaTable luaTable_0)
	{
		if (side_0.Units.Count == 0)
		{
			throw new LuaError("Target side must have at least one active unit!");
		}
		ActiveUnit activeUnit = null;
		ActiveUnit activeUnit2 = null;
		Contact item = null;
		Sensor sensor = null;
		DateTime minValue = DateTime.MinValue;
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		if (dictionary.ContainsKey("DATE"))
		{
			(int, int, int) tuple = LuaUtility.ParseDate_DDMMYYYY(Conversions.ToString(dictionary["DATE"]));
			if (dictionary.ContainsKey("TIME"))
			{
				(int, int, int) tuple2 = LuaUtility.ParseTime_HHMMSS(Conversions.ToString(dictionary["TIME"]));
				minValue = new DateTime(tuple.Item3, tuple.Item2, tuple.Item1, tuple2.Item1, tuple2.Item2, tuple2.Item3);
				if (dictionary.ContainsKey("RANGE"))
				{
					float item2 = Convert.ToSingle(Conversions.ToString(dictionary["RANGE"]), CultureInfo.InvariantCulture);
					if (dictionary.ContainsKey("SENSORPARENTID"))
					{
						string text = Conversions.ToString(dictionary["SENSORPARENTID"]);
						if (scenario_0.ActiveUnits.TryGetValue(text, ref activeUnit))
						{
							if (dictionary.ContainsKey("SENSORID"))
							{
								string b = Conversions.ToString(dictionary["SENSORID"]);
								Sensor[] array = activeUnit.Sensors_ReadOnly();
								Sensor[] array3 = array;
								foreach (Sensor sensor2 in array3)
								{
									if (string.Equals(sensor2.ObjectID, b, StringComparison.OrdinalIgnoreCase))
									{
										sensor = sensor2;
										break;
									}
								}
								if (sensor == null)
								{
									throw new LuaError("Value SensorID does not match the ID of any sensor in the specified sensor parent!");
								}
								List<Geopoint_Struct> list = new List<Geopoint_Struct>();
								if (dictionary.ContainsKey("UNCERTAINITYAREA"))
								{
									string[] array2 = dictionary["UNCERTAINITYAREA"].ToString().Split('|');
									for (int i = 0; i < array2.Length; i = checked(i + 1))
									{
										string[] source = array2[i].Split(';');
										if (source.Count() == 2)
										{
											double double_ = Conversions.ToDouble(source.ElementAt(0));
											double double_2 = Conversions.ToDouble(source.ElementAt(1));
											list.Add(new Geopoint_Struct(double_, double_2));
										}
									}
								}
								if (list.Count < 3)
								{
									list.Clear();
								}
								if (dictionary.ContainsKey("TARGETID"))
								{
									string text2 = Conversions.ToString(dictionary["TARGETID"]);
									if (scenario_0.ActiveUnits.TryGetValue(text2, ref activeUnit2))
									{
										if (!activeUnit.GetUnitSide().Contacts.TryGetValue(activeUnit2.ObjectID, ref item))
										{
											item = new Contact(activeUnit2);
										}
										Tuple<Contact, ActiveUnit, List<Sensor>, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime, List<Geopoint_Struct>> tuple_ = new Tuple<Contact, ActiveUnit, List<Sensor>, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime, List<Geopoint_Struct>>(item, activeUnit2, new List<Sensor>(new Sensor[1] { sensor }), item2, ActiveUnit_Sensory.SpecialDetectionMode.None, minValue, list);
										side_0.Units[0].Sensory.HandleDetectedContact_OnGrid(activeUnit, side_0, tuple_, bool_0: true);
										side_0.ProcessContactListChanges(scenario_0);
										side_0.ProcessBaseContactListChanges(scenario_0);
										Contact contact = null;
										if (side_0.Contacts.TryGetValue(activeUnit2.ObjectID, ref contact))
										{
											if (dictionary.ContainsKey("NAME"))
											{
												contact.Name = Conversions.ToString(dictionary["NAME"]);
											}
											if (dictionary.ContainsKey("POSTURE"))
											{
												switch (Conversions.ToString(dictionary["POSTURE"]).ToUpperInvariant())
												{
												case "X":
													contact.SetStance(side_0, bool_0: false, Misc.PostureStance.Unknown);
													break;
												case "U":
													contact.SetStance(side_0, bool_0: false, Misc.PostureStance.Unfriendly);
													break;
												case "N":
													contact.SetStance(side_0, bool_0: false, Misc.PostureStance.Neutral);
													break;
												case "H":
													contact.SetStance(side_0, bool_0: false, Misc.PostureStance.Hostile);
													break;
												case "F":
													contact.SetStance(side_0, bool_0: false, Misc.PostureStance.Friendly);
													break;
												}
											}
											return new LuaWrapper_Contact(contact, scenario_0, side_0);
										}
										throw new LuaError("An unknwon error has occured! No contact matching the provided Target-unit ID can be located on the target side of the operation.");
									}
									throw new LuaError("Value TargetID does not match the ID of any active unit in this scenario!");
								}
								throw new LuaError("Mandatory value TargetID is missing!");
							}
							throw new LuaError("Mandatory value SensorID is missing!");
						}
						throw new LuaError("Value SensorParentID does not match the ID of any active unit in this scenario!");
					}
					throw new LuaError("Mandatory value SensorParentID is missing!");
				}
				throw new LuaError("Mandatory value Range is missing!");
			}
			throw new LuaError("Mandatory value Time is missing!");
		}
		throw new LuaError("Mandatory value Date is missing!");
	}
}
