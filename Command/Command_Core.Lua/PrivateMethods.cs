using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;
using Command_Core.DAL;
using Command_Core.LoadSave;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;
using Nini.Config;
using OpenDis.Pages;

namespace Command_Core.Lua;

[StandardModule]
public sealed class PrivateMethods
{
	public delegate void LuaMessageBoxEventHandler(string theMsg, int theStyle, bool RunningHeadless, ref string pressed);

	public delegate void LuaInputBoxEventHandler(string theMsg, bool RunningHeadless, ref string pressed);

	public delegate void LuaLocalVideoEventHandler(string theFileName, bool RunningHeadless, bool FullScreen, int Delay);

	public delegate void LuaLocalSoundEventHandler(string theFileName, int Delay);

	public delegate void LuaGameEventHandler(ref byte status, ref byte mode);

	public delegate void LuaSelectUnitsPrompt_OwnSideEventHandler(ref LuaTable result, bool MultipleSelect);

	public delegate void LuaSelectUnitsPrompt_FromSidesEventHandler(ref LuaTable result, LuaTable SidesNameOrID, bool MultipleSelect);

	public delegate void LuaCallAdvancedDialogEventHandler(string Title, string Description, LuaTable Interactions, ref string returnValue);

	public delegate void LuaCallAdvancedHTMLDialogEventHandler(string Title, string Description, LuaTable Interactions, ref object returnValue);

	public delegate void LuaNewBlankScenarioEventHandler(string dbHashed);

	[CompilerGenerated]
	private static LuaSelectUnitsPrompt_OwnSideEventHandler luaSelectUnitsPrompt_OwnSideEventHandler_0;

	[CompilerGenerated]
	private static LuaSelectUnitsPrompt_FromSidesEventHandler luaSelectUnitsPrompt_FromSidesEventHandler_0;

	[CompilerGenerated]
	private static LuaCallAdvancedDialogEventHandler luaCallAdvancedDialogEventHandler_0;

	[CompilerGenerated]
	private static LuaCallAdvancedHTMLDialogEventHandler luaCallAdvancedHTMLDialogEventHandler_0;

	[CompilerGenerated]
	private static LuaNewBlankScenarioEventHandler luaNewBlankScenarioEventHandler_0;

	public static Dictionary<string, string> ReturnTable;

	public static event LuaMessageBoxEventHandler LuaMessageBox;

	public static event LuaInputBoxEventHandler LuaInputBox;

	public static event LuaLocalVideoEventHandler LuaLocalVideo;

	public static event LuaLocalSoundEventHandler LuaLocalSound;

	public static event LuaGameEventHandler LuaGame;

	public static event LuaSelectUnitsPrompt_OwnSideEventHandler LuaSelectUnitsPrompt_OwnSide
	{
		[CompilerGenerated]
		add
		{
			LuaSelectUnitsPrompt_OwnSideEventHandler luaSelectUnitsPrompt_OwnSideEventHandler = luaSelectUnitsPrompt_OwnSideEventHandler_0;
			LuaSelectUnitsPrompt_OwnSideEventHandler luaSelectUnitsPrompt_OwnSideEventHandler2;
			do
			{
				luaSelectUnitsPrompt_OwnSideEventHandler2 = luaSelectUnitsPrompt_OwnSideEventHandler;
				LuaSelectUnitsPrompt_OwnSideEventHandler value2 = (LuaSelectUnitsPrompt_OwnSideEventHandler)Delegate.Combine(luaSelectUnitsPrompt_OwnSideEventHandler2, value);
				luaSelectUnitsPrompt_OwnSideEventHandler = Interlocked.CompareExchange(ref luaSelectUnitsPrompt_OwnSideEventHandler_0, value2, luaSelectUnitsPrompt_OwnSideEventHandler2);
			}
			while ((object)luaSelectUnitsPrompt_OwnSideEventHandler != luaSelectUnitsPrompt_OwnSideEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaSelectUnitsPrompt_OwnSideEventHandler luaSelectUnitsPrompt_OwnSideEventHandler = luaSelectUnitsPrompt_OwnSideEventHandler_0;
			LuaSelectUnitsPrompt_OwnSideEventHandler luaSelectUnitsPrompt_OwnSideEventHandler2;
			do
			{
				luaSelectUnitsPrompt_OwnSideEventHandler2 = luaSelectUnitsPrompt_OwnSideEventHandler;
				LuaSelectUnitsPrompt_OwnSideEventHandler value2 = (LuaSelectUnitsPrompt_OwnSideEventHandler)Delegate.Remove(luaSelectUnitsPrompt_OwnSideEventHandler2, value);
				luaSelectUnitsPrompt_OwnSideEventHandler = Interlocked.CompareExchange(ref luaSelectUnitsPrompt_OwnSideEventHandler_0, value2, luaSelectUnitsPrompt_OwnSideEventHandler2);
			}
			while ((object)luaSelectUnitsPrompt_OwnSideEventHandler != luaSelectUnitsPrompt_OwnSideEventHandler2);
		}
	}

	public static event LuaSelectUnitsPrompt_FromSidesEventHandler LuaSelectUnitsPrompt_FromSides
	{
		[CompilerGenerated]
		add
		{
			LuaSelectUnitsPrompt_FromSidesEventHandler luaSelectUnitsPrompt_FromSidesEventHandler = luaSelectUnitsPrompt_FromSidesEventHandler_0;
			LuaSelectUnitsPrompt_FromSidesEventHandler luaSelectUnitsPrompt_FromSidesEventHandler2;
			do
			{
				luaSelectUnitsPrompt_FromSidesEventHandler2 = luaSelectUnitsPrompt_FromSidesEventHandler;
				LuaSelectUnitsPrompt_FromSidesEventHandler value2 = (LuaSelectUnitsPrompt_FromSidesEventHandler)Delegate.Combine(luaSelectUnitsPrompt_FromSidesEventHandler2, value);
				luaSelectUnitsPrompt_FromSidesEventHandler = Interlocked.CompareExchange(ref luaSelectUnitsPrompt_FromSidesEventHandler_0, value2, luaSelectUnitsPrompt_FromSidesEventHandler2);
			}
			while ((object)luaSelectUnitsPrompt_FromSidesEventHandler != luaSelectUnitsPrompt_FromSidesEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaSelectUnitsPrompt_FromSidesEventHandler luaSelectUnitsPrompt_FromSidesEventHandler = luaSelectUnitsPrompt_FromSidesEventHandler_0;
			LuaSelectUnitsPrompt_FromSidesEventHandler luaSelectUnitsPrompt_FromSidesEventHandler2;
			do
			{
				luaSelectUnitsPrompt_FromSidesEventHandler2 = luaSelectUnitsPrompt_FromSidesEventHandler;
				LuaSelectUnitsPrompt_FromSidesEventHandler value2 = (LuaSelectUnitsPrompt_FromSidesEventHandler)Delegate.Remove(luaSelectUnitsPrompt_FromSidesEventHandler2, value);
				luaSelectUnitsPrompt_FromSidesEventHandler = Interlocked.CompareExchange(ref luaSelectUnitsPrompt_FromSidesEventHandler_0, value2, luaSelectUnitsPrompt_FromSidesEventHandler2);
			}
			while ((object)luaSelectUnitsPrompt_FromSidesEventHandler != luaSelectUnitsPrompt_FromSidesEventHandler2);
		}
	}

	public static event LuaCallAdvancedDialogEventHandler LuaCallAdvancedDialog
	{
		[CompilerGenerated]
		add
		{
			LuaCallAdvancedDialogEventHandler luaCallAdvancedDialogEventHandler = luaCallAdvancedDialogEventHandler_0;
			LuaCallAdvancedDialogEventHandler luaCallAdvancedDialogEventHandler2;
			do
			{
				luaCallAdvancedDialogEventHandler2 = luaCallAdvancedDialogEventHandler;
				LuaCallAdvancedDialogEventHandler value2 = (LuaCallAdvancedDialogEventHandler)Delegate.Combine(luaCallAdvancedDialogEventHandler2, value);
				luaCallAdvancedDialogEventHandler = Interlocked.CompareExchange(ref luaCallAdvancedDialogEventHandler_0, value2, luaCallAdvancedDialogEventHandler2);
			}
			while ((object)luaCallAdvancedDialogEventHandler != luaCallAdvancedDialogEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaCallAdvancedDialogEventHandler luaCallAdvancedDialogEventHandler = luaCallAdvancedDialogEventHandler_0;
			LuaCallAdvancedDialogEventHandler luaCallAdvancedDialogEventHandler2;
			do
			{
				luaCallAdvancedDialogEventHandler2 = luaCallAdvancedDialogEventHandler;
				LuaCallAdvancedDialogEventHandler value2 = (LuaCallAdvancedDialogEventHandler)Delegate.Remove(luaCallAdvancedDialogEventHandler2, value);
				luaCallAdvancedDialogEventHandler = Interlocked.CompareExchange(ref luaCallAdvancedDialogEventHandler_0, value2, luaCallAdvancedDialogEventHandler2);
			}
			while ((object)luaCallAdvancedDialogEventHandler != luaCallAdvancedDialogEventHandler2);
		}
	}

	public static event LuaCallAdvancedHTMLDialogEventHandler LuaCallAdvancedHTMLDialog
	{
		[CompilerGenerated]
		add
		{
			LuaCallAdvancedHTMLDialogEventHandler luaCallAdvancedHTMLDialogEventHandler = luaCallAdvancedHTMLDialogEventHandler_0;
			LuaCallAdvancedHTMLDialogEventHandler luaCallAdvancedHTMLDialogEventHandler2;
			do
			{
				luaCallAdvancedHTMLDialogEventHandler2 = luaCallAdvancedHTMLDialogEventHandler;
				LuaCallAdvancedHTMLDialogEventHandler value2 = (LuaCallAdvancedHTMLDialogEventHandler)Delegate.Combine(luaCallAdvancedHTMLDialogEventHandler2, value);
				luaCallAdvancedHTMLDialogEventHandler = Interlocked.CompareExchange(ref luaCallAdvancedHTMLDialogEventHandler_0, value2, luaCallAdvancedHTMLDialogEventHandler2);
			}
			while ((object)luaCallAdvancedHTMLDialogEventHandler != luaCallAdvancedHTMLDialogEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaCallAdvancedHTMLDialogEventHandler luaCallAdvancedHTMLDialogEventHandler = luaCallAdvancedHTMLDialogEventHandler_0;
			LuaCallAdvancedHTMLDialogEventHandler luaCallAdvancedHTMLDialogEventHandler2;
			do
			{
				luaCallAdvancedHTMLDialogEventHandler2 = luaCallAdvancedHTMLDialogEventHandler;
				LuaCallAdvancedHTMLDialogEventHandler value2 = (LuaCallAdvancedHTMLDialogEventHandler)Delegate.Remove(luaCallAdvancedHTMLDialogEventHandler2, value);
				luaCallAdvancedHTMLDialogEventHandler = Interlocked.CompareExchange(ref luaCallAdvancedHTMLDialogEventHandler_0, value2, luaCallAdvancedHTMLDialogEventHandler2);
			}
			while ((object)luaCallAdvancedHTMLDialogEventHandler != luaCallAdvancedHTMLDialogEventHandler2);
		}
	}

	public static event LuaNewBlankScenarioEventHandler LuaNewBlankScenario
	{
		[CompilerGenerated]
		add
		{
			LuaNewBlankScenarioEventHandler luaNewBlankScenarioEventHandler = luaNewBlankScenarioEventHandler_0;
			LuaNewBlankScenarioEventHandler luaNewBlankScenarioEventHandler2;
			do
			{
				luaNewBlankScenarioEventHandler2 = luaNewBlankScenarioEventHandler;
				LuaNewBlankScenarioEventHandler value2 = (LuaNewBlankScenarioEventHandler)Delegate.Combine(luaNewBlankScenarioEventHandler2, value);
				luaNewBlankScenarioEventHandler = Interlocked.CompareExchange(ref luaNewBlankScenarioEventHandler_0, value2, luaNewBlankScenarioEventHandler2);
			}
			while ((object)luaNewBlankScenarioEventHandler != luaNewBlankScenarioEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaNewBlankScenarioEventHandler luaNewBlankScenarioEventHandler = luaNewBlankScenarioEventHandler_0;
			LuaNewBlankScenarioEventHandler luaNewBlankScenarioEventHandler2;
			do
			{
				luaNewBlankScenarioEventHandler2 = luaNewBlankScenarioEventHandler;
				LuaNewBlankScenarioEventHandler value2 = (LuaNewBlankScenarioEventHandler)Delegate.Remove(luaNewBlankScenarioEventHandler2, value);
				luaNewBlankScenarioEventHandler = Interlocked.CompareExchange(ref luaNewBlankScenarioEventHandler_0, value2, luaNewBlankScenarioEventHandler2);
			}
			while ((object)luaNewBlankScenarioEventHandler != luaNewBlankScenarioEventHandler2);
		}
	}

	static PrivateMethods()
	{
		ReturnTable = null;
	}

	public static object UI_CallAdvancedHTMLDialog(string string_0, string string_1, LuaTable luaTable_0)
	{
		object returnValue = "";
		luaCallAdvancedHTMLDialogEventHandler_0?.Invoke(string_0, string_1, luaTable_0, ref returnValue);
		return returnValue;
	}

	public static string UI_CallAdvancedDialog(string string_0, string string_1, LuaTable luaTable_0)
	{
		string returnValue = "";
		luaCallAdvancedDialogEventHandler_0?.Invoke(string_0, string_1, luaTable_0, ref returnValue);
		return returnValue;
	}

	public static LuaTable UI_SelectUnitsPrompt_OwnSide(ref LuaTable luaTable_0, bool bool_0)
	{
		luaSelectUnitsPrompt_OwnSideEventHandler_0?.Invoke(ref luaTable_0, bool_0);
		return luaTable_0;
	}

	public static LuaTable UI_SelectUnitsPrompt_FromSides(ref LuaTable luaTable_0, LuaTable luaTable_1, bool bool_0)
	{
		luaSelectUnitsPrompt_FromSidesEventHandler_0?.Invoke(ref luaTable_0, luaTable_1, bool_0);
		return luaTable_0;
	}

	public static string ScenEdit_TransformZone(string string_0, string string_1, string string_2, Scenario scenario_0)
	{
		Side side = (from s in scenario_0.Sides_ReadOnly
			where string.Equals(s.ObjectID, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, string_0, StringComparison.OrdinalIgnoreCase)
			select (s)).First();
		if (side == null)
		{
			return "Side not found.";
		}
		Zone zone = (from s in side.StandardZones
			where string.Equals(s.ObjectID, string_1, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Description, string_1, StringComparison.OrdinalIgnoreCase)
			select (s)).FirstOrDefault();
		ExclusionZone exclusionZone = (from s in side.ExclusionZones
			where string.Equals(s.ObjectID, string_1, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Description, string_1, StringComparison.OrdinalIgnoreCase)
			select (s)).FirstOrDefault();
		NoNavZone noNavZone = (from s in side.NoNavZones
			where string.Equals(s.ObjectID, string_1, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Description, string_1, StringComparison.OrdinalIgnoreCase)
			select (s)).FirstOrDefault();
		CustomEnvironmentZone customEnvironmentZone = null;
		if (zone == null && exclusionZone == null && noNavZone == null && side == scenario_0.GetNatureSide())
		{
			customEnvironmentZone = (from s in side.CustomEnvironmentZones
				where string.Equals(s.ObjectID, string_1, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Description, string_1, StringComparison.OrdinalIgnoreCase)
				select (s)).FirstOrDefault();
		}
		string_2 = string_2.ToLowerInvariant();
		switch (string_2)
		{
		default:
			return "Zone type does not exist.";
		case "standard":
			if (Information.IsNothing(noNavZone))
			{
				if (Information.IsNothing(exclusionZone))
				{
					if (customEnvironmentZone != null)
					{
						Zone.TransformTo(customEnvironmentZone, side, scenario_0);
					}
				}
				else
				{
					Zone.TransformTo(exclusionZone, side, scenario_0);
				}
			}
			else
			{
				Zone.TransformTo(noNavZone, side, scenario_0);
			}
			break;
		case "nonav":
			if (Information.IsNothing(zone))
			{
				if (Information.IsNothing(exclusionZone))
				{
					if (customEnvironmentZone != null)
					{
						NoNavZone.TransformTo(customEnvironmentZone, side, scenario_0);
					}
				}
				else
				{
					NoNavZone.TransformTo(exclusionZone, side, scenario_0);
				}
			}
			else
			{
				NoNavZone.TransformTo(zone, side, scenario_0);
			}
			break;
		case "exclusion":
			if (Information.IsNothing(zone))
			{
				if (Information.IsNothing(noNavZone))
				{
					if (customEnvironmentZone != null)
					{
						ExclusionZone.TransformTo(customEnvironmentZone, side, scenario_0);
					}
				}
				else
				{
					ExclusionZone.TransformTo(noNavZone, side, scenario_0);
				}
			}
			else
			{
				ExclusionZone.TransformTo(zone, side, scenario_0);
			}
			break;
		case "customenvironment":
			if (Information.IsNothing(zone))
			{
				if (Information.IsNothing(noNavZone))
				{
					if (!Information.IsNothing(exclusionZone))
					{
						CustomEnvironmentZone.TransformTo(exclusionZone, side, scenario_0);
					}
				}
				else
				{
					CustomEnvironmentZone.TransformTo(noNavZone, side, scenario_0);
				}
			}
			else
			{
				CustomEnvironmentZone.TransformTo(zone, side, scenario_0);
			}
			break;
		}
		return "";
	}

	public static string ScenEdit_SetSimulationFidelity(float float_0, Scenario scenario_0)
	{
		if (scenario_0.SetSimulationFidelity(float_0, bool_0: true))
		{
			return null;
		}
		return "Fidelity argument must either be 0.1, 1 or 5";
	}

	public static void ScenEdit_LockSimulationFidelity(bool bool_0, Scenario scenario_0)
	{
		scenario_0.LockFidelityResolution = bool_0;
	}

	public static void Command_SaveScen(string string_0, Scenario scenario_0)
	{
		Command_Core.LoadSave.LoadSave.SaveScenario(scenario_0, scenario_0.GetCurrentSide(), string_0, bool_0: false);
	}

	public static LuaTable ScenEdit_GetUnitIntermittentEmissionConfig(string string_0, string string_1, Scenario scenario_0)
	{
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		ActiveUnit activeUnitByNameOrID = Misc.GetActiveUnitByNameOrID(string_1, scenario_0);
		if (Information.IsNothing(activeUnitByNameOrID))
		{
			return null;
		}
		if (activeUnitByNameOrID.Sensory.m_UtilsWrapper == null)
		{
			return null;
		}
		ActiveEmissionInterval activeEmissionInterval = activeUnitByNameOrID.Sensory.InterruptConsumer();
		Alertlevels selectedIntermittentEmissionConfig_ByString = Misc.GetSelectedIntermittentEmissionConfig_ByString(string_0);
		if (selectedIntermittentEmissionConfig_ByString == Alertlevels.Unknown)
		{
			return null;
		}
		val["EMISSIONDURATION"] = activeEmissionInterval.Configs[selectedIntermittentEmissionConfig_ByString].EmissionDuration;
		val["EMISSIONINTERVAL"] = activeEmissionInterval.Configs[selectedIntermittentEmissionConfig_ByString].EmissionInterval;
		val["EMISSIONINTERVALVARIATION"] = activeEmissionInterval.Configs[selectedIntermittentEmissionConfig_ByString].EmissionIntervalVariation;
		val["SLEEPMODEDELAY"] = activeEmissionInterval.Configs[selectedIntermittentEmissionConfig_ByString].SleepModeDelay;
		val["USEEMISSIONINTERVAL"] = activeEmissionInterval.Configs[selectedIntermittentEmissionConfig_ByString].UseEmissionInterval;
		val["FOLLOWWRAFORWAKEBEHAVIOR"] = activeEmissionInterval.Configs[selectedIntermittentEmissionConfig_ByString].FollowWRAforWakeBehavior;
		val["WAKEWHENDETECTINGTHREAT"] = activeEmissionInterval.Configs[selectedIntermittentEmissionConfig_ByString].WakeWhenDetectingThreat;
		val["WAKEID_UNKNOWN"] = activeEmissionInterval.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactID[Contact_Base.IdentificationStatus.Unknown];
		val["WAKEID_PRECISEID"] = activeEmissionInterval.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactID[Contact_Base.IdentificationStatus.PreciseID];
		val["WAKEID_KNWONTYPE"] = activeEmissionInterval.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownType];
		val["WAKEIDKNOWNDOMAIN"] = activeEmissionInterval.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownDomain];
		val["WAKEIDKNOWNCLASS"] = activeEmissionInterval.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownClass];
		val["WAKESTANCE_FRIENDLY"] = activeEmissionInterval.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactStance[Misc.PostureStance.Friendly];
		val["WAKESTANCE_HOSTILE"] = activeEmissionInterval.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactStance[Misc.PostureStance.Hostile];
		val["WAKESTANCE_NEUTRAL"] = activeEmissionInterval.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactStance[Misc.PostureStance.Neutral];
		val["WAKESTANCE_UNFRIENDLY"] = activeEmissionInterval.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactStance[Misc.PostureStance.Unfriendly];
		val["WAKESTANCE_UNKNOWN"] = activeEmissionInterval.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactStance[Misc.PostureStance.Unknown];
		return val;
	}

	public static bool ScenEdit_SetUnitIntermittentEmissionConfig(string string_0, string string_1, LuaTable luaTable_0, Scenario scenario_0)
	{
		ActiveUnit activeUnitByNameOrID = Misc.GetActiveUnitByNameOrID(string_0, scenario_0);
		if (Information.IsNothing(activeUnitByNameOrID))
		{
			return false;
		}
		if (Information.IsNothing(luaTable_0))
		{
			return false;
		}
		if (activeUnitByNameOrID.Sensors_ReadOnly().Length == 0)
		{
			return false;
		}
		ActiveEmissionInterval activeEmissionInterval = activeUnitByNameOrID.Sensory.InterruptConsumer();
		Alertlevels key = Alertlevels.Green;
		switch (string_1.ToUpper())
		{
		case "CUSTOM":
			key = Alertlevels.Custom;
			break;
		case "ALL":
			ScenEdit_SetUnitIntermittentEmissionConfig(string_0, "Green", luaTable_0, scenario_0);
			ScenEdit_SetUnitIntermittentEmissionConfig(string_0, "Blue", luaTable_0, scenario_0);
			ScenEdit_SetUnitIntermittentEmissionConfig(string_0, "Yellow", luaTable_0, scenario_0);
			ScenEdit_SetUnitIntermittentEmissionConfig(string_0, "Orange", luaTable_0, scenario_0);
			ScenEdit_SetUnitIntermittentEmissionConfig(string_0, "Red", luaTable_0, scenario_0);
			ScenEdit_SetUnitIntermittentEmissionConfig(string_0, "Custom", luaTable_0, scenario_0);
			return true;
		case "BLUE":
			key = Alertlevels.Blue;
			break;
		case "ORANGE":
			key = Alertlevels.Orange;
			break;
		case "RED":
			key = Alertlevels.Red;
			break;
		case "YELLOW":
			key = Alertlevels.Yellow;
			break;
		case "GREEN":
			key = Alertlevels.Green;
			break;
		}
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		if (dictionary.ContainsKey("USEEMISSIONINTERVAL"))
		{
			activeEmissionInterval.Configs[key].UseEmissionInterval = Conversions.ToBoolean(dictionary["USEEMISSIONINTERVAL"]);
		}
		if (dictionary.ContainsKey("EMISSIONDURATION"))
		{
			activeEmissionInterval.Configs[key].EmissionDuration = Conversions.ToSingle(dictionary["EMISSIONDURATION"]);
		}
		if (dictionary.ContainsKey("EMISSIONINTERVALVARIATION"))
		{
			activeEmissionInterval.Configs[key].EmissionIntervalVariation = Conversions.ToSingle(dictionary["EMISSIONINTERVALVARIATION"]);
		}
		if (dictionary.ContainsKey("SLEEPMODEDELAY"))
		{
			activeEmissionInterval.Configs[key].SleepModeDelay = Conversions.ToSingle(dictionary["SLEEPMODEDELAY"]);
		}
		if (dictionary.ContainsKey("EMISSIONINTERVAL"))
		{
			activeEmissionInterval.Configs[key].EmissionInterval = Conversions.ToSingle(dictionary["EMISSIONINTERVAL"]);
		}
		if (dictionary.ContainsKey("FOLLOWWRAFORWAKEBEHAVIOR"))
		{
			activeEmissionInterval.Configs[key].FollowWRAforWakeBehavior = Conversions.ToBoolean(dictionary["FOLLOWWRAFORWAKEBEHAVIOR"]);
		}
		if (dictionary.ContainsKey("WAKEWHENDETECTINGTHREAT"))
		{
			activeEmissionInterval.Configs[key].WakeWhenDetectingThreat = Conversions.ToBoolean(dictionary["WAKEWHENDETECTINGTHREAT"]);
		}
		if (dictionary.ContainsKey("WAKEID_UNKNOWN"))
		{
			activeEmissionInterval.Configs[key].Wake_IncludesContactID[Contact_Base.IdentificationStatus.Unknown] = Conversions.ToBoolean(dictionary["WAKEID_UNKNOWN"]);
		}
		if (dictionary.ContainsKey("WAKEID_PRECISEID"))
		{
			activeEmissionInterval.Configs[key].Wake_IncludesContactID[Contact_Base.IdentificationStatus.PreciseID] = Conversions.ToBoolean(dictionary["WAKEID_PRECISEID"]);
		}
		if (dictionary.ContainsKey("WAKEID_KNWONTYPE"))
		{
			activeEmissionInterval.Configs[key].Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownType] = Conversions.ToBoolean(dictionary["WAKEID_KNWONTYPE"]);
		}
		if (dictionary.ContainsKey("WAKEIDKNOWNDOMAIN"))
		{
			activeEmissionInterval.Configs[key].Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownDomain] = Conversions.ToBoolean(dictionary["WAKEIDKNOWNDOMAIN"]);
		}
		if (dictionary.ContainsKey("WAKEIDKNOWNCLASS"))
		{
			activeEmissionInterval.Configs[key].Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownClass] = Conversions.ToBoolean(dictionary["WAKEIDKNOWNCLASS"]);
		}
		if (dictionary.ContainsKey("WAKESTANCE_FRIENDLY"))
		{
			activeEmissionInterval.Configs[key].Wake_IncludesContactStance[Misc.PostureStance.Friendly] = Conversions.ToBoolean(dictionary["WAKESTANCE_FRIENDLY"]);
		}
		if (dictionary.ContainsKey("WAKESTANCE_HOSTILE"))
		{
			activeEmissionInterval.Configs[key].Wake_IncludesContactStance[Misc.PostureStance.Hostile] = Conversions.ToBoolean(dictionary["WAKESTANCE_HOSTILE"]);
		}
		if (dictionary.ContainsKey("WAKESTANCE_NEUTRAL"))
		{
			activeEmissionInterval.Configs[key].Wake_IncludesContactStance[Misc.PostureStance.Neutral] = Conversions.ToBoolean(dictionary["WAKESTANCE_NEUTRAL"]);
		}
		if (dictionary.ContainsKey("WAKESTANCE_UNFRIENDLY"))
		{
			activeEmissionInterval.Configs[key].Wake_IncludesContactStance[Misc.PostureStance.Unfriendly] = Conversions.ToBoolean(dictionary["WAKESTANCE_UNFRIENDLY"]);
		}
		if (dictionary.ContainsKey("WAKESTANCE_UNKNOWN"))
		{
			activeEmissionInterval.Configs[key].Wake_IncludesContactStance[Misc.PostureStance.Unknown] = Conversions.ToBoolean(dictionary["WAKESTANCE_UNKNOWN"]);
		}
		return true;
	}

	public static bool ScenEdit_DuplicateEmconConfigToUnit(string string_0, string string_1, string string_2, Scenario scenario_0)
	{
		ActiveUnit activeUnitByNameOrID = Misc.GetActiveUnitByNameOrID(string_1, scenario_0);
		ActiveUnit activeUnitByNameOrID2 = Misc.GetActiveUnitByNameOrID(string_2, scenario_0);
		if (activeUnitByNameOrID != null && activeUnitByNameOrID2 != null)
		{
			if (activeUnitByNameOrID.Sensors_ReadOnly().Length != 0 && activeUnitByNameOrID2.Sensors_ReadOnly().Length != 0)
			{
				ActiveEmissionInterval activeEmissionInterval_ = activeUnitByNameOrID.Sensory.InterruptConsumer();
				ActiveEmissionInterval activeEmissionInterval = activeUnitByNameOrID2.Sensory.InterruptConsumer();
				Alertlevels alertlevels_;
				switch (string_0.ToUpper())
				{
				case "CUSTOM":
					alertlevels_ = Alertlevels.Custom;
					break;
				case "ALL":
					ScenEdit_DuplicateEmconConfigToUnit("Green", string_1, string_2, scenario_0);
					ScenEdit_DuplicateEmconConfigToUnit("Blue", string_1, string_2, scenario_0);
					ScenEdit_DuplicateEmconConfigToUnit("Yellow", string_1, string_2, scenario_0);
					ScenEdit_DuplicateEmconConfigToUnit("Orange", string_1, string_2, scenario_0);
					ScenEdit_DuplicateEmconConfigToUnit("Red", string_1, string_2, scenario_0);
					ScenEdit_DuplicateEmconConfigToUnit("Custom", string_1, string_2, scenario_0);
					return true;
				case "BLUE":
					alertlevels_ = Alertlevels.Blue;
					break;
				case "ORANGE":
					alertlevels_ = Alertlevels.Orange;
					break;
				case "RED":
					alertlevels_ = Alertlevels.Red;
					break;
				case "YELLOW":
					alertlevels_ = Alertlevels.Yellow;
					break;
				default:
					return false;
				case "GREEN":
					alertlevels_ = Alertlevels.Green;
					break;
				}
				activeEmissionInterval.PasteConfig(alertlevels_, activeEmissionInterval_);
				return true;
			}
			return false;
		}
		return false;
	}

	public static bool ScenEdit_DuplicateEmconConfigToSide(string string_0, string string_1, string string_2, Scenario scenario_0)
	{
		ActiveUnit activeUnitByNameOrID = Misc.GetActiveUnitByNameOrID(string_1, scenario_0);
		if (Information.IsNothing(activeUnitByNameOrID))
		{
			return false;
		}
		if (activeUnitByNameOrID.Sensors_ReadOnly().Length == 0)
		{
			return false;
		}
		ActiveEmissionInterval activeEmissionInterval_ = activeUnitByNameOrID.Sensory.InterruptConsumer();
		Side side = (from s in scenario_0.Sides_ReadOnly
			where string.Equals(s.ObjectID, string_2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, string_2, StringComparison.OrdinalIgnoreCase)
			select (s)).First();
		if (Information.IsNothing(side))
		{
			return false;
		}
		Alertlevels alertlevels_;
		switch (string_0.ToUpper())
		{
		case "CUSTOM":
			alertlevels_ = Alertlevels.Custom;
			break;
		case "ALL":
			ScenEdit_DuplicateEmconConfigToSide("Green", string_1, string_2, scenario_0);
			ScenEdit_DuplicateEmconConfigToSide("Blue", string_1, string_2, scenario_0);
			ScenEdit_DuplicateEmconConfigToSide("Yellow", string_1, string_2, scenario_0);
			ScenEdit_DuplicateEmconConfigToSide("Orange", string_1, string_2, scenario_0);
			ScenEdit_DuplicateEmconConfigToSide("Red", string_1, string_2, scenario_0);
			ScenEdit_DuplicateEmconConfigToSide("Custom", string_1, string_2, scenario_0);
			return true;
		case "BLUE":
			alertlevels_ = Alertlevels.Blue;
			break;
		case "ORANGE":
			alertlevels_ = Alertlevels.Orange;
			break;
		case "RED":
			alertlevels_ = Alertlevels.Red;
			break;
		case "YELLOW":
			alertlevels_ = Alertlevels.Yellow;
			break;
		default:
			return false;
		case "GREEN":
			alertlevels_ = Alertlevels.Green;
			break;
		}
		side.PasteIntermittentConfig(alertlevels_, activeEmissionInterval_);
		return true;
	}

	public static bool ScenEdit_SwitchUnitIntermittentEmission(string string_0, string string_1, float float_0, Scenario scenario_0)
	{
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		val["USEEMISSIONINTERVAL"] = float_0;
		return ScenEdit_SetUnitIntermittentEmissionConfig(string_0, string_1, val, scenario_0);
	}

	public static bool ScenEdit_CreateBarkNotification_Unit(string string_0, string string_1, int int_0, int int_1, int int_2, bool bool_0, bool bool_1, float float_0, float float_1, Scenario scenario_0)
	{
		ActiveUnit activeUnitByNameOrID = Misc.GetActiveUnitByNameOrID(string_0, scenario_0);
		Color color_ = Color.FromArgb(int_0, int_1, int_2);
		if (activeUnitByNameOrID == null)
		{
			return false;
		}
		Notification_Bark.Create(activeUnitByNameOrID, string_1, color_, bool_0, bool_1, float_0, float_1);
		return true;
	}

	public static bool ScenEdit_CreateBarkNotification_Geo(float float_0, float float_1, string string_0, int int_0, int int_1, int int_2, bool bool_0, bool bool_1, float float_2, float float_3, Scenario scenario_0)
	{
		Color color_ = Color.FromArgb(int_0, int_1, int_2);
		Notification_Bark.Create(float_0, float_1, string_0, color_, bool_0, bool_1, float_2, float_3);
		return true;
	}

	public static bool ScenEdit_CreateBarkNotification_Unit_Bulk(string string_0, LuaTable luaTable_0, int int_0, int int_1, int int_2, bool bool_0, bool bool_1, float float_0, float float_1, Scenario scenario_0)
	{
		ActiveUnit activeUnitByNameOrID = Misc.GetActiveUnitByNameOrID(string_0, scenario_0);
		Color color_ = Color.FromArgb(int_0, int_1, int_2);
		new List<object>();
		if (Information.IsNothing(luaTable_0))
		{
			return false;
		}
		List<object> list = LuaUtility.ToArray(luaTable_0.GetEnumerator());
		List<string> list2 = new List<string>();
		foreach (object item in list)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(item);
			list2.Add(objectValue.ToString());
		}
		if (activeUnitByNameOrID == null)
		{
			return false;
		}
		Notification_Bark.Create(activeUnitByNameOrID, list2, color_, bool_0, bool_1, float_0, float_1);
		return true;
	}

	public static bool ScenEdit_CreateBarkNotification_Geo_Bulk(float float_0, float float_1, LuaTable luaTable_0, int int_0, int int_1, int int_2, bool bool_0, bool bool_1, float float_2, float float_3, Scenario scenario_0)
	{
		Color color_ = Color.FromArgb(int_0, int_1, int_2);
		new List<object>();
		if (Information.IsNothing(luaTable_0))
		{
			return false;
		}
		List<object> list = LuaUtility.ToArray(luaTable_0.GetEnumerator());
		List<string> list2 = new List<string>();
		foreach (object item in list)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(item);
			list2.Add(objectValue.ToString());
		}
		Notification_Bark.Create(float_0, float_1, list2, color_, bool_0, bool_1, float_2, float_3);
		return true;
	}

	public static bool ScenEdit_SetSideEmconAlertness(string string_0, string string_1, Scenario scenario_0)
	{
		Side side = (from s in scenario_0.Sides_ReadOnly
			where string.Equals(s.ObjectID, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, string_0, StringComparison.OrdinalIgnoreCase)
			select (s)).First();
		if (Information.IsNothing(side))
		{
			return false;
		}
		switch (string_1)
		{
		default:
			return false;
		case "Yellow":
			side.EmconAlertness.Level = Alertlevels.Yellow;
			break;
		case "Red":
			side.EmconAlertness.Level = Alertlevels.Red;
			break;
		case "Orange":
			side.EmconAlertness.Level = Alertlevels.Orange;
			break;
		case "Green":
			side.EmconAlertness.Level = Alertlevels.Green;
			break;
		case "Custom":
			side.EmconAlertness.Level = Alertlevels.Custom;
			break;
		case "Blue":
			side.EmconAlertness.Level = Alertlevels.Blue;
			break;
		}
		return true;
	}

	public static bool ScenEdit_ClearAllSideUnitsEmconConfigs(string string_0, Scenario scenario_0)
	{
		Side side = (from s in scenario_0.Sides_ReadOnly
			where string.Equals(s.ObjectID, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, string_0, StringComparison.OrdinalIgnoreCase)
			select (s)).First();
		if (Information.IsNothing(side))
		{
			return false;
		}
		foreach (ActiveUnit unit in side.Units)
		{
			if (unit.IsActiveUnit)
			{
				ActiveUnit activeUnit = unit;
				if (activeUnit.Sensory.m_UtilsWrapper != null)
				{
					unit.Sensory.InterruptConsumer().Initialize(activeUnit.Sensory, bool_0: true);
				}
			}
		}
		return false;
	}

	public static bool ScenEdit_ClearUnitEmconConfigs(string string_0, Scenario scenario_0)
	{
		ActiveUnit activeUnitByNameOrID = Misc.GetActiveUnitByNameOrID(string_0, scenario_0);
		if (Information.IsNothing(activeUnitByNameOrID))
		{
			return false;
		}
		if (activeUnitByNameOrID.Sensors_ReadOnly().Length == 0)
		{
			return false;
		}
		if (activeUnitByNameOrID.Sensory.m_UtilsWrapper == null)
		{
			return false;
		}
		activeUnitByNameOrID.Sensory.InterruptConsumer().Initialize(activeUnitByNameOrID.Sensory, bool_0: true);
		return true;
	}

	public static void Exporter_SetSetting(string string_0, string string_1, string string_2, Scenario scenario_0)
	{
		if (!FileExistsNative.FileExistsFast(Exporter_General.EventExporter_ConfigFileName))
		{
			return;
		}
		IniConfigSource iniConfigSource = new IniConfigSource(Exporter_General.EventExporter_ConfigFileName);
		switch (string_0)
		{
		case "General":
		{
			if (Operators.CompareString(string_1, "ActiveExporter", TextCompare: false) != 0)
			{
				break;
			}
			string[] array = string_2.Split(Conversions.ToCharArrayRankOne(","));
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (!string.IsNullOrEmpty(text))
				{
					switch (text)
					{
					default:
						return;
					case "Tacview2x":
					case "SIMDIS":
					case "XML":
					case "Tacview1x":
					case "MSAccess":
					case "SQLite":
					case "SQLServer":
					case "CSV":
						break;
					}
				}
			}
			iniConfigSource.Configs[string_0].Set(string_1, string_2);
			break;
		}
		case "CSV Settings":
			switch (string_1)
			{
			case "SpeedBandFrequencyOver2560":
			case "SpeedBandFrequency1280To2560":
			case "SpeedBandFrequency80To160":
			case "SpeedBandFrequency160To320":
			case "SpeedBandFrequency40To80":
			case "SpeedBandFrequency640To1280":
			case "SpeedBandFrequencyDynamic":
			case "SpeedBandFrequency320To640":
			case "SpeedBandFrequency0To20":
			case "SpeedBandFrequency20To40":
			{
				if (int.TryParse(string_2, out var result3))
				{
					iniConfigSource.Configs[string_0].Set(string_1, result3);
				}
				break;
			}
			case "ExportWeaponFired":
			case "UseCustomUnitExportFrequency":
			case "ExportWeaponEndgame":
			case "SplitFilesBySide":
			case "ExportFuelConsumed":
			case "UseZeroHour":
			case "ExportSensorDetectionFailure":
			case "ExportDockingOps":
			case "ExportAirOps":
			case "ConsolidateCSV":
			case "ExportUnitPositions":
			case "ExportEngagementCycle":
			case "ExportFuelTransfer":
			case "ExportSensorDetectionSuccess":
			case "ExportUnitDestroyed":
			{
				if (bool.TryParse(string_2, out var result))
				{
					iniConfigSource.Configs[string_0].Set(string_1, result);
				}
				break;
			}
			}
			break;
		case "XML Settings":
			switch (string_1)
			{
			case "SpeedBandFrequencyOver2560":
			case "SpeedBandFrequency1280To2560":
			case "SpeedBandFrequency80To160":
			case "SpeedBandFrequency640To1280":
			case "SpeedBandFrequency160To320":
			case "SpeedBandFrequencyDynamic":
			case "SpeedBandFrequency40To80":
			case "SpeedBandFrequency320To640":
			case "SpeedBandFrequency20To40":
			case "SpeedBandFrequency0To20":
			{
				if (int.TryParse(string_2, out var result5))
				{
					iniConfigSource.Configs[string_0].Set(string_1, result5);
				}
				break;
			}
			case "ExportWeaponFired":
			case "UseCustomUnitExportFrequency":
			case "ExportWeaponEndgame":
			case "ExportFuelConsumed":
			case "UseZeroHour":
			case "ConsolidateCSV":
			case "ExportSensorDetectionFailure":
			case "ExportDockingOps":
			case "ExportEngagementCycle":
			case "ExportAirOps":
			case "ExportUnitPositions":
			case "ExportSensorDetectionSuccess":
			case "ExportUnitDestroyed":
			case "ExportFuelTransfer":
			{
				if (bool.TryParse(string_2, out var result4))
				{
					iniConfigSource.Configs[string_0].Set(string_1, result4);
				}
				break;
			}
			}
			break;
		default:
			switch (string_0)
			{
			case "Tacview Settings":
				switch (string_1)
				{
				case "UseCustomUnitExportFrequency":
				{
					if (bool.TryParse(string_2, out var result2))
					{
						iniConfigSource.Configs[string_0].Set(string_1, result2);
					}
					break;
				}
				case "SpeedBandFrequencyOver2560":
				case "SpeedBandFrequency160To320":
				case "SpeedBandFrequency1280To2560":
				case "SpeedBandFrequency80To160":
				case "SpeedBandFrequencyDynamic":
				case "SpeedBandFrequency40To80":
				case "SpeedBandFrequency640To1280":
				case "SpeedBandFrequency20To40":
				case "SpeedBandFrequency0To20":
				case "SpeedBandFrequency320To640":
				{
					if (int.TryParse(string_2, out var result10))
					{
						iniConfigSource.Configs[string_0].Set(string_1, result10);
					}
					break;
				}
				}
				break;
			case "SQLite Settings":
			case "SQLServer Settings":
				switch (string_1)
				{
				case "SpeedBandFrequencyOver2560":
				case "SpeedBandFrequency1280To2560":
				case "SpeedBandFrequency80To160":
				case "SpeedBandFrequency640To1280":
				case "SpeedBandFrequency160To320":
				case "SpeedBandFrequencyDynamic":
				case "SpeedBandFrequency40To80":
				case "BatchSize":
				case "SpeedBandFrequency320To640":
				case "SpeedBandFrequency0To20":
				case "SpeedBandFrequency20To40":
				{
					if (int.TryParse(string_2, out var result9))
					{
						iniConfigSource.Configs[string_0].Set(string_1, result9);
					}
					break;
				}
				case "ExportWeaponFired":
				case "UseCustomUnitExportFrequency":
				case "ExportWeaponEndgame":
				case "ExportFuelConsumed":
				case "UseZeroHour":
				case "ExportSensorDetectionFailure":
				case "ExportDockingOps":
				case "ExportAirOps":
				case "ConsolidateCSV":
				case "ExportUnitPositions":
				case "ExportEngagementCycle":
				case "ExportFuelTransfer":
				case "ExportSensorDetectionSuccess":
				case "ExportUnitDestroyed":
				{
					if (bool.TryParse(string_2, out var result8))
					{
						iniConfigSource.Configs[string_0].Set(string_1, result8);
					}
					break;
				}
				}
				break;
			case "MSAccess Settings":
			case "XML Settings":
				switch (string_1)
				{
				case "SpeedBandFrequencyOver2560":
				case "SpeedBandFrequency1280To2560":
				case "SpeedBandFrequency80To160":
				case "SpeedBandFrequency640To1280":
				case "SpeedBandFrequency160To320":
				case "SpeedBandFrequencyDynamic":
				case "SpeedBandFrequency40To80":
				case "SpeedBandFrequency320To640":
				case "SpeedBandFrequency20To40":
				case "SpeedBandFrequency0To20":
				{
					if (int.TryParse(string_2, out var result7))
					{
						iniConfigSource.Configs[string_0].Set(string_1, result7);
					}
					break;
				}
				case "ExportWeaponFired":
				case "UseCustomUnitExportFrequency":
				case "ExportWeaponEndgame":
				case "ExportFuelConsumed":
				case "UseZeroHour":
				case "ConsolidateCSV":
				case "ExportSensorDetectionFailure":
				case "ExportDockingOps":
				case "ExportEngagementCycle":
				case "ExportAirOps":
				case "ExportUnitPositions":
				case "ExportSensorDetectionSuccess":
				case "ExportUnitDestroyed":
				case "ExportFuelTransfer":
				{
					if (bool.TryParse(string_2, out var result6))
					{
						iniConfigSource.Configs[string_0].Set(string_1, result6);
					}
					break;
				}
				}
				break;
			}
			break;
		}
		iniConfigSource.Save();
		Exporter_General.StartEventExporters_Interactive(scenario_0, bool_0: true);
		foreach (IEventExporter item in Exporter_General.EventExporters_Interactive)
		{
			item.Common.GetCommonConfig(item.Common.RunRepository());
		}
		foreach (IEventExporter item2 in Exporter_General.EventExporters_MonteCarlo)
		{
			item2.Common.GetCommonConfig(item2.Common.RunRepository());
		}
	}

	public static void Exporter_AddUnitPositionFrequency(string string_0, string string_1, string string_2)
	{
	}

	public static void Exporter_RemoveUnitPositionFrequency(string string_0, string string_1, string string_2)
	{
	}

	public static void Exporter_GetUnitPositionFrequency(string string_0, string string_1, string string_2)
	{
	}

	public static string ScenEdit_AddAircraft(string string_0, string string_1, int int_0, int int_1, string string_2, string string_3, string string_4, Scenario scenario_0)
	{
		Side side_ = (from s in scenario_0.Sides_ReadOnly
			where string.Equals(s.ObjectID, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, string_0, StringComparison.OrdinalIgnoreCase)
			select (s)).First();
		double double_ = 0.0;
		double double_2 = 0.0;
		if (Operators.CompareString(string_2, "DEC", TextCompare: false) == 0)
		{
			string_4 = string_4.Replace(",", ".");
			string_3 = string_3.Replace(",", ".");
			double_ = XmlConvert.ToDouble(string_4);
			double_2 = XmlConvert.ToDouble(string_3);
		}
		else if (Operators.CompareString(string_2, "DEG", TextCompare: false) == 0)
		{
			double_ = LuaUtility.ParseLongitudeString(string_4);
			double_2 = LuaUtility.ParseLatitudeString(string_3);
		}
		return scenario_0.AddNewAircraft(side_, string_1, double_, double_2, int_0, int_1, 1000f).ObjectID;
	}

	public static string ScenEdit_AddShip(string string_0, string string_1, int int_0, string string_2, string string_3, string string_4, Scenario scenario_0)
	{
		Side side_ = (from s in scenario_0.Sides_ReadOnly
			where string.Equals(s.ObjectID, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, string_0, StringComparison.OrdinalIgnoreCase)
			select (s)).First();
		double double_ = 0.0;
		double double_2 = 0.0;
		if (Operators.CompareString(string_2, "DEC", TextCompare: false) == 0)
		{
			string_4 = string_4.Replace(",", ".");
			string_3 = string_3.Replace(",", ".");
			double_ = XmlConvert.ToDouble(string_4);
			double_2 = XmlConvert.ToDouble(string_3);
		}
		else if (Operators.CompareString(string_2, "DEG", TextCompare: false) == 0)
		{
			double_ = LuaUtility.ParseLongitudeString(string_4);
			double_2 = LuaUtility.ParseLatitudeString(string_3);
		}
		return scenario_0.AddNewShip(side_, int_0, string_1, double_, double_2).ObjectID;
	}

	public static string ScenEdit_AddSubmarine(string string_0, string string_1, int int_0, string string_2, string string_3, string string_4, Scenario scenario_0)
	{
		Side side_ = (from s in scenario_0.Sides_ReadOnly
			where string.Equals(s.ObjectID, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, string_0, StringComparison.OrdinalIgnoreCase)
			select (s)).First();
		double double_ = 0.0;
		double double_2 = 0.0;
		if (Operators.CompareString(string_2, "DEC", TextCompare: false) == 0)
		{
			string_4 = string_4.Replace(",", ".");
			string_3 = string_3.Replace(",", ".");
			double_ = XmlConvert.ToDouble(string_4);
			double_2 = XmlConvert.ToDouble(string_3);
		}
		else if (Operators.CompareString(string_2, "DEG", TextCompare: false) == 0)
		{
			double_ = LuaUtility.ParseLongitudeString(string_4);
			double_2 = LuaUtility.ParseLatitudeString(string_3);
		}
		return scenario_0.AddNewSubmarine(side_, int_0, string_1, double_, double_2).ObjectID;
	}

	public static bool ScenEdit_AddExplosion(LuaTable luaTable_0, Scenario scenario_0)
	{
		Weapon._WeaponType weaponType_ = Weapon._WeaponType.IronBomb;
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		if (dictionary.ContainsKey("WARHEADID"))
		{
			int int_ = Conversions.ToInteger(dictionary["WARHEADID"]);
			if (dictionary.ContainsKey("WEAPONTYPE") && (Enum.TryParse<Weapon._WeaponType>(Conversions.ToString(dictionary["WEAPONTYPE"]), ignoreCase: true, out var result) & Enum.IsDefined(typeof(Weapon._WeaponType), result)))
			{
				weaponType_ = result;
			}
			double? num = LuaUtility.QueryLatitude(dictionary);
			if (num.HasValue)
			{
				double? num2 = LuaUtility.QueryLongitude(dictionary);
				if (num2.HasValue)
				{
					int num3 = 0;
					if (dictionary.ContainsKey("ALTITUDE") && Operators.CompareString(dictionary["ALTITUDE"].ToString().ToUpper(), "SURFACE", TextCompare: false) != 0)
					{
						float? num4 = LuaUtility.QueryAltitude(dictionary);
						if (Information.IsNothing(num4))
						{
							short elevation = Terrain.GetElevation(num.Value, num2.Value, bool_0: false, scenario_0);
							num3 = ((elevation >= 0) ? elevation : 0);
						}
						else
						{
							num3 = (int)Math.Round(num4.Value);
						}
					}
					else
					{
						short elevation2 = Terrain.GetElevation(num.Value, num2.Value, bool_0: false, scenario_0);
						num3 = ((elevation2 >= 0) ? elevation2 : 0);
					}
					Warhead warhead = DBFunctions.GetWarhead(scenario_0, int_);
					new Explosion(ref scenario_0, num2.Value, num.Value, num2.Value, num.Value, 0f, num3, weaponType_, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, null, null, warhead.ClusterBombDispersionAreaLength, warhead.ClusterBombDispersionAreaWidth, warhead.NumberOfWarheads);
					return true;
				}
				throw new LuaError("缺少'经度'");
			}
			throw new LuaError("缺少'纬度'");
		}
		throw new LuaError("缺少必需变量'WarheadID'");
	}

	public static string ScenEdit_AddFacility(string string_0, string string_1, int int_0, int int_1, string string_2, string string_3, string string_4, Scenario scenario_0)
	{
		Side side_ = (from s in scenario_0.Sides_ReadOnly
			where string.Equals(s.ObjectID, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, string_0, StringComparison.OrdinalIgnoreCase)
			select (s)).First();
		double double_ = 0.0;
		double double_2 = 0.0;
		if (Operators.CompareString(string_2, "DEC", TextCompare: false) == 0)
		{
			string_4 = string_4.Replace(",", ".");
			string_3 = string_3.Replace(",", ".");
			double_ = XmlConvert.ToDouble(string_4);
			double_2 = XmlConvert.ToDouble(string_3);
		}
		else if (Operators.CompareString(string_2, "DEG", TextCompare: false) == 0)
		{
			double_ = LuaUtility.ParseLongitudeString(string_4);
			double_2 = LuaUtility.ParseLatitudeString(string_3);
		}
		Facility facility = scenario_0.AddNewFacility(side_, int_0, string_1, double_, double_2);
		facility.CurrentHeading = int_1;
		return facility.ObjectID;
	}

	public static object ScenEdit_HostUnitToParent(LuaTable luaTable_0, Scenario scenario_0, ActiveUnit activeUnit_0)
	{
		try
		{
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			ActiveUnit activeUnit = null;
			ActiveUnit activeUnit2 = null;
			ActiveUnit activeUnit3 = null;
			bool flag = false;
			bool flag2 = false;
			List<object> list = new List<object>();
			string text;
			if (dictionary.ContainsKey("HostedUnitNameOrID".ToUpper()))
			{
				text = Conversions.ToString(dictionary["HostedUnitNameOrID".ToUpper()]);
			}
			else if (dictionary.ContainsKey("UnitName".ToUpper()))
			{
				text = Conversions.ToString(dictionary["UnitName".ToUpper()]);
			}
			else
			{
				if (!dictionary.ContainsKey("GUID".ToUpper()))
				{
					throw new LuaError("HostedUnitNameOrID/Unit has not been defined!");
				}
				text = Conversions.ToString(dictionary["GUID".ToUpper()]);
			}
			if (Operators.CompareString(text, "UnitX", TextCompare: false) == 0)
			{
				if (activeUnit_0 == null)
				{
					throw new LuaError("单元：UnitX尚未定义！");
				}
				activeUnit = activeUnit_0;
			}
			else
			{
				activeUnit = smethod_0(text, scenario_0);
			}
			string text2 = null;
			if (dictionary.ContainsKey("SelectedHostNameOrID".ToUpper()))
			{
				text2 = Conversions.ToString(dictionary["SelectedHostNameOrID".ToUpper()]);
			}
			else if (dictionary.ContainsKey("HostBaseNameOrID".ToUpper()))
			{
				text2 = Conversions.ToString(dictionary["HostBaseNameOrID".ToUpper()]);
			}
			if (Operators.CompareString(text2, "UnitX", TextCompare: false) == 0)
			{
				if (Information.IsNothing(activeUnit_0))
				{
					throw new LuaError("Host Base:UnitX has not been defined!");
				}
				activeUnit2 = activeUnit_0;
			}
			else
			{
				activeUnit2 = smethod_0(text2, scenario_0);
			}
			string text3 = null;
			if (dictionary.ContainsKey("SelectedBaseNameOrID".ToUpper()))
			{
				text3 = Conversions.ToString(dictionary["SelectedBaseNameOrID".ToUpper()]);
			}
			else if (dictionary.ContainsKey("AssignedBaseNameOrID".ToUpper()))
			{
				text3 = Conversions.ToString(dictionary["AssignedBaseNameOrID".ToUpper()]);
			}
			if (Operators.CompareString(text3, "UnitX", TextCompare: false) == 0)
			{
				if (Information.IsNothing(activeUnit_0))
				{
					throw new LuaError("Assigned Base:UnitX has not been defined!");
				}
				activeUnit3 = activeUnit_0;
			}
			else
			{
				activeUnit3 = smethod_0(text3, scenario_0);
			}
			if (Information.IsNothing(activeUnit))
			{
				throw new LuaError("找不到托管单元" + text);
			}
			if (Information.IsNothing(activeUnit2) && Information.IsNothing(activeUnit3))
			{
				throw new LuaError("Couldn't find any host/assigned base ");
			}
			if (activeUnit.IsAircraft)
			{
				if (!Information.IsNothing(activeUnit2) && activeUnit2.AirOps != null)
				{
					if (activeUnit2.AirOps.CanHostThisAircraft((Aircraft)activeUnit) == AirOpsAttemptResult.Success)
					{
						((Aircraft)activeUnit).AirOps.HostAirFacility = null;
						activeUnit2.AirOps.AddThisAircraft((Aircraft)activeUnit, bool_0: false);
						activeUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
						flag = true;
					}
					else
					{
						flag = false;
					}
				}
				if (!Information.IsNothing(activeUnit3) && activeUnit.AirOps != null)
				{
					Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)activeUnit.AirOps;
					if (Operators.CompareString(aircraft_AirOps.ThisUnitCanHostMe(activeUnit3), "OK", TextCompare: false) == 0)
					{
						aircraft_AirOps.SetAssignedHostUnit(bool_0: false, activeUnit3);
						flag2 = true;
					}
					else
					{
						flag2 = false;
					}
				}
			}
			else
			{
				if (!Information.IsNothing(activeUnit2) && activeUnit2.DockingOps != null)
				{
					ActiveUnit_DockingOps dockingOps = activeUnit2.DockingOps;
					ActiveUnit activeUnit_ = activeUnit;
					DockFacility dockFacility_ = null;
					if (dockingOps.CanHostThisBoat(activeUnit_, ref dockFacility_))
					{
						activeUnit.DockingOps.HostDockFacility = null;
						activeUnit2.DockingOps.AddThisBoat(activeUnit);
						activeUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
						flag = true;
					}
					else
					{
						flag = false;
					}
				}
				if (!Information.IsNothing(activeUnit3) && activeUnit.DockingOps != null)
				{
					ActiveUnit_DockingOps dockingOps2 = activeUnit.DockingOps;
					if (Operators.CompareString(dockingOps2.ThisUnitCanHostMe(activeUnit3), "OK", TextCompare: false) == 0)
					{
						dockingOps2.SetAssignedHostUnit(bool_0: false, activeUnit3);
						flag2 = true;
					}
					else
					{
						flag2 = false;
					}
				}
			}
			if (activeUnit2 == null)
			{
				return flag2;
			}
			if (activeUnit3 == null)
			{
				return flag;
			}
			list.Add(flag);
			list.Add(flag2);
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at PM1", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static string ScenEdit_ExportScenarioToXML(Scenario scenario_0)
	{
		return Misc.AssetRequest(GameGeneral.PostBridge(scenario_0));
	}

	public static bool ScenEdit_ImportScenarioFromXML(ref Scenario scenario_0, LuaTable luaTable_0)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		if (dictionary.ContainsKey("XML".ToUpper()))
		{
			string string_ = Conversions.ToString(dictionary["XML".ToUpper()]);
			try
			{
				string string_2 = null;
				Scenario.ChangeCurrentScenarioOnClient(scenario_0 = Scenario.FromXmlText(string_, ref string_2, null));
				return true;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM207", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("XML解析期间出错：" + exception_.Message);
			}
		}
		if (dictionary.ContainsKey("FILENAME".ToUpper()))
		{
			if (GameGeneral.PE_Lua_AllowIO)
			{
				string path = Conversions.ToString(dictionary["FILENAME".ToUpper()]);
				string string_3 = "";
				try
				{
					Scenario.ChangeCurrentScenarioOnClient(scenario_0 = Scenario.smethod_0(Path.Combine(GameGeneral.TopLevelWritablePath, path), ref string_3, null));
					return true;
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at PM2", "");
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Error during File parse: " + exception_2.Message);
				}
			}
			throw new LuaError("I/O Operations are not allowed");
		}
		throw new LuaError("XML字符串不存在！");
	}

	public static bool ScenEdit_AssignUnitToMission(string string_0, string string_1, Scenario scenario_0, ActiveUnit activeUnit_0, bool bool_0, bool bool_1)
	{
		try
		{
			ActiveUnit activeUnit_ = null;
			Mission mission_ = null;
			Side side = null;
			bool bool_2 = bool_0;
			bool flag = bool_1;
			if (Operators.CompareString(string_0, "UnitX", TextCompare: false) == 0)
			{
				if (activeUnit_0 == null)
				{
					throw new LuaError("UnitX尚未定义！");
				}
				activeUnit_ = activeUnit_0;
				side = activeUnit_0.GetUnitSide();
			}
			else
			{
				scenario_0.ActiveUnits.TryGetValue(string_0, ref activeUnit_);
				if (activeUnit_ == null)
				{
					foreach (ActiveUnit value in scenario_0.ActiveUnits.Values)
					{
						if (value != null && string.Equals(value.Name, string_0, StringComparison.OrdinalIgnoreCase))
						{
							activeUnit_ = value;
							side = activeUnit_.GetUnitSide();
							break;
						}
					}
				}
				else
				{
					side = activeUnit_.GetUnitSide();
				}
			}
			if (side == null)
			{
				throw new LuaError("在想定单元列表中找不到UnitX！");
			}
			foreach (Mission mission in side.Missions)
			{
				if (string.Equals(mission.Name, string_1, StringComparison.OrdinalIgnoreCase) || string.Equals(mission.ObjectID, string_1, StringComparison.OrdinalIgnoreCase))
				{
					mission_ = mission;
					break;
				}
			}
			if (activeUnit_ == null)
			{
				throw new LuaError("找不到单元" + string_0);
			}
			if (!string.IsNullOrEmpty(string_1) && !string.Equals(string_1, "NONE", StringComparison.OrdinalIgnoreCase))
			{
				if (mission_ == null)
				{
					throw new LuaError("找不到任务" + string_1);
				}
				if (bool_2 & activeUnit_.IsGroup)
				{
					activeUnit_.CollectIssuer(ref activeUnit_.ParentScen, ref activeUnit_, ref mission_, ref bool_2);
					foreach (ActiveUnit value2 in ((Group)activeUnit_).Units.Values)
					{
						ActiveUnit activeUnit_2 = value2;
						activeUnit_.CollectIssuer(ref activeUnit_.ParentScen, ref activeUnit_2, ref mission_, ref bool_2);
					}
				}
				else
				{
					activeUnit_.CollectIssuer(ref activeUnit_.ParentScen, ref activeUnit_, ref mission_, ref bool_2);
				}
				if (flag && activeUnit_.IsAircraft && activeUnit_.IsOperating())
				{
					List<ActiveUnit> list_ = new List<ActiveUnit>();
					list_.Add(activeUnit_);
					MissionPlanner.GenerateFlightPlan_Strike_AirborneAircraft(activeUnit_.ParentScen, mission_, ref list_, bool_0: false);
				}
				mission_.TimeSincePlayerNotification = 0;
				return true;
			}
			ActiveUnit activeUnit = activeUnit_;
			Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
			activeUnit.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at PM3", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static bool ScenEdit_SetLoadout(LuaTable luaTable_0, Scenario scenario_0, ActiveUnit activeUnit_0)
	{
		try
		{
			Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			Aircraft aircraft_ = null;
			LuaUtility.ParseUnitDict(ref dictionary_);
			if (dictionary_.ContainsKey("UnitName".ToUpper()))
			{
				string text = Conversions.ToString(dictionary_["UnitName".ToUpper()]);
				if (Operators.CompareString(text, "UnitX", TextCompare: false) == 0)
				{
					if (Information.IsNothing(activeUnit_0))
					{
						throw new LuaError("UnitX尚未定义！");
					}
					if (!activeUnit_0.IsAircraft)
					{
						throw new LuaError("UnitX不是飞机！");
					}
					aircraft_ = (Aircraft)activeUnit_0;
				}
				else
				{
					if (scenario_0.ActiveUnits.ContainsKey(text))
					{
						aircraft_ = (Aircraft)scenario_0.ActiveUnits[text];
					}
					if (aircraft_ == null)
					{
						foreach (ActiveUnit value in scenario_0.ActiveUnits.Values)
						{
							if (value != null && string.Equals(value.Name, text, StringComparison.OrdinalIgnoreCase))
							{
								aircraft_ = (Aircraft)value;
								break;
							}
						}
					}
				}
				if (aircraft_ == null)
				{
					throw new LuaError("飞机尚未被发现！");
				}
				int num = 0;
				if (dictionary_.ContainsKey("LOADOUTID"))
				{
					num = Conversions.ToInteger(dictionary_["LOADOUTID"]);
				}
				Loadout loadout;
				if (num == 0)
				{
					num = aircraft_.Loadout.DBID;
					loadout = aircraft_.Loadout;
				}
				else
				{
					try
					{
						loadout = DBFunctions.GetLoadout(ref scenario_0, num, bool_0: true, bool_1: true);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at PM4", "");
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError(exception_.Message);
					}
				}
				if (loadout.DBID != num && !(aircraft_.NewFacade() | (aircraft_.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying)))
				{
					throw new LuaError("飞机没有停放，不能改变挂载！");
				}
				if (aircraft_.NewFacade() | (aircraft_.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying))
				{
					int num2 = loadout.ReadyTime;
					if (dictionary_.ContainsKey("TIMETOREADY_MINUTES"))
					{
						num2 = Conversions.ToInteger(dictionary_["TIMETOREADY_MINUTES"]);
					}
					bool flag = false;
					if (dictionary_.ContainsKey("IGNOREMAGAZINES"))
					{
						try
						{
							flag = Conversions.ToBoolean(dictionary_["IGNOREMAGAZINES"]);
						}
						catch (Exception ex2)
						{
							ProjectData.SetProjectError(ex2);
							Exception exception_2 = ex2;
							exception_2?.Data.Add("Error at PM5", "");
							GameGeneral.WriteExceptionsToLog(ref exception_2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							throw new LuaError("Unable to parse IgnoreMagazines to true/false!");
						}
					}
					bool bool_ = false;
					if (dictionary_.ContainsKey("EXCLUDEOPTIONALWEAPONS"))
					{
						try
						{
							bool_ = Conversions.ToBoolean(dictionary_["EXCLUDEOPTIONALWEAPONS"]);
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception exception_3 = ex3;
							exception_3?.Data.Add("Error at PM6", "");
							GameGeneral.WriteExceptionsToLog(ref exception_3);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							throw new LuaError("Unable to parse ExcludeOptionalWeapons to true/false!");
						}
					}
					if (scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
					{
						flag = true;
					}
					if (!flag)
					{
						aircraft_.AirOps.UnloadStores();
					}
					ActiveUnit currentHostUnit = aircraft_.AirOps.CurrentHostUnit;
					currentHostUnit.AirOps.OutfitAC(ref aircraft_, num, 0, bool_0: false, bool_, !flag, bool_3: false, bool_4: true);
					aircraft_.AirOps.ConditionTimer = num2 * 60;
					currentHostUnit.AirOps.RefuelAC_Simple(ref aircraft_);
					currentHostUnit.AirOps.RepairAC(ref aircraft_);
					if (num == 4 && !aircraft_.NewFacade())
					{
						aircraft_.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Parked;
					}
					return true;
				}
				int num3 = 0;
				bool flag2 = false;
				int num4 = 0;
				string text2 = null;
				if (dictionary_.ContainsKey("WPN_DBID"))
				{
					num4 = Conversions.ToInteger(dictionary_["WPN_DBID"]);
				}
				if (dictionary_.ContainsKey("WPN_GUID"))
				{
					text2 = Conversions.ToString(dictionary_["WPN_GUID"]);
				}
				if (text2 == null && num4 == 0)
				{
					throw new LuaError("没有定义武器。");
				}
				if (dictionary_.ContainsKey("NUMBER"))
				{
					num3 = Math.Abs(Conversions.ToInteger(dictionary_["NUMBER"]));
				}
				if (dictionary_.ContainsKey("REMOVE"))
				{
					flag2 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_["REMOVE"])).Value;
				}
				WeaponRec[] weapons = loadout.Weapons;
				WeaponRec[] array = weapons;
				foreach (WeaponRec weaponRec in array)
				{
					if (num3 <= 0)
					{
						break;
					}
					if (text2 != null && !string.Equals(weaponRec.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
					{
						continue;
					}
					if (num4 == 0)
					{
						num4 = weaponRec.int_0;
					}
					if (num4 != weaponRec.int_0)
					{
						continue;
					}
					if (flag2)
					{
						if (weaponRec.CurrentLoad > 0)
						{
							int num5 = Math.Min(num3, weaponRec.CurrentLoad);
							weaponRec.CurrentLoad -= num5;
							num3 -= num5;
						}
					}
					else if (weaponRec.CurrentLoad < weaponRec.MaxLoad)
					{
						int num6 = Math.Min(num3, weaponRec.MaxLoad - weaponRec.CurrentLoad);
						weaponRec.CurrentLoad += num6;
						num3 -= num6;
					}
				}
				return true;
			}
			throw new LuaError("UnitName尚未定义！");
		}
		catch (Exception ex4)
		{
			ProjectData.SetProjectError(ex4);
			Exception exception_4 = ex4;
			if (Debugger.IsAttached)
			{
				exception_4?.Data.Add("Error at PM7", "");
				GameGeneral.WriteExceptionsToLog(ref exception_4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				Debugger.Break();
			}
			throw;
		}
	}

	public static LuaWrapper_Loadout ScenEdit_GetLoadout(LuaTable luaTable_0, Scenario scenario_0, ActiveUnit activeUnit_0)
	{
		try
		{
			Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			Aircraft aircraft = null;
			LuaUtility.ParseUnitDict(ref dictionary_);
			if (dictionary_.ContainsKey("UnitName".ToUpper()))
			{
				string text = Conversions.ToString(dictionary_["UnitName".ToUpper()]);
				if (Operators.CompareString(text, "UnitX", TextCompare: false) == 0)
				{
					if (Information.IsNothing(activeUnit_0))
					{
						throw new LuaError("UnitX尚未定义！");
					}
					if (!activeUnit_0.IsAircraft)
					{
						throw new LuaError("UnitX不是飞机！");
					}
					aircraft = (Aircraft)activeUnit_0;
				}
				else
				{
					foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
					{
						if (!Information.IsNothing(activeUnits_) && (object)activeUnits_.GetType() == typeof(Aircraft) && (string.Equals(activeUnits_.Name, text, StringComparison.OrdinalIgnoreCase) || string.Equals(activeUnits_.ObjectID, text, StringComparison.OrdinalIgnoreCase)))
						{
							aircraft = (Aircraft)activeUnits_;
							break;
						}
					}
				}
				if (Information.IsNothing(aircraft))
				{
					throw new LuaError("飞机尚未被发现！");
				}
				int num = 0;
				if (dictionary_.ContainsKey("LOADOUTID"))
				{
					num = Conversions.ToInteger(dictionary_["LOADOUTID"]);
				}
				Loadout loadout_;
				try
				{
					loadout_ = ((num == 0) ? aircraft.Loadout : DBFunctions.GetLoadout(ref scenario_0, num, bool_0: true, bool_1: true));
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at PM8", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError(exception_.Message);
				}
				return new LuaWrapper_Loadout(loadout_, scenario_0);
			}
			throw new LuaError("UnitName尚未定义！");
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			if (Debugger.IsAttached)
			{
				exception_2?.Data.Add("Error at PM9", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			throw;
		}
	}

	public static bool ScenEdit_SetWeather(int int_0, int int_1, float float_0, int int_2, Scenario scenario_0)
	{
		try
		{
			if (int_1 >= 0 && int_1 <= 50)
			{
				if (float_0 >= 0f && float_0 <= 1f)
				{
					if (int_2 < 0 || int_2 > 9)
					{
						throw new LuaError("无效的SeaState（0  -  9）");
					}
					scenario_0.GlobalWeather.AverageTemp = int_0;
					scenario_0.GlobalWeather.RainfallRate = int_1;
					scenario_0.GlobalWeather.FractionUnderRain = float_0;
					scenario_0.GlobalWeather.SeaState = int_2;
					return true;
				}
				throw new LuaError("无效的云量分数（0.0  -  1.0）");
			}
			throw new LuaError("降雨量无效（0  -  50）");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at PM10", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static LuaTable ScenEdit_GetWeather(Scenario scenario_0)
	{
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		try
		{
			val["temp"] = scenario_0.GlobalWeather.AverageTemp;
			val["rainfall"] = scenario_0.GlobalWeather.RainfallRate;
			val["undercloud"] = scenario_0.GlobalWeather.FractionUnderRain;
			val["seastate"] = scenario_0.GlobalWeather.SeaState;
			return val;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at PM11", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
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
				if (string.Equals(side3.ObjectID, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(side3.Name, string_0, StringComparison.OrdinalIgnoreCase))
				{
					side = side3;
				}
				if (string.Equals(side3.ObjectID, string_1, StringComparison.OrdinalIgnoreCase) || string.Equals(side3.Name, string_1, StringComparison.OrdinalIgnoreCase))
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
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at PM12", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
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
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at PM13", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					throw new LuaError("分方必须是一个字符串");
				}
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at PM14", "");
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到分方'" + text + "'");
				}
			}
			if (dictionary.ContainsKey("AWARENESS"))
			{
				Side.AwarenessLevel_Enum awarenessLevel;
				switch (Conversions.ToString(dictionary["AWARENESS"]).ToUpper())
				{
				case "0":
				case "NORMAL":
					awarenessLevel = Side.AwarenessLevel_Enum.Normal;
					break;
				case "2":
				case "AUTOUNIT":
				case "AUTOSIDEANDUNITID":
					awarenessLevel = Side.AwarenessLevel_Enum.AutoSideAndUnitID;
					break;
				case "1":
				case "AUTOSIDEID":
				case "AUTOSIDE":
					awarenessLevel = Side.AwarenessLevel_Enum.AutoSideID;
					break;
				case "-1":
				case "BLIND":
					awarenessLevel = Side.AwarenessLevel_Enum.Blind;
					break;
				default:
					throw new LuaError("感知代码无效！ （有效代码：-1 ... 3）");
				case "3":
				case "OMNISCIENT":
				case "OMNI":
					awarenessLevel = Side.AwarenessLevel_Enum.Omniscient;
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
			return ScenEdit_GetSideOptions(luaTable_0, scenario_0);
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at PM15", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static LuaTable ScenEdit_FillMagsForLoadout(LuaTable luaTable_0, Scenario scenario_0)
	{
		try
		{
			Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			ActiveUnit activeUnit = null;
			LuaSandBox.Singleton().CreateTable();
			LuaUtility.ParseUnitDict(ref dictionary_);
			string text = LuaUtility.QueryUnit(dictionary_, scenario_0);
			if (text.Length == 0)
			{
				if (dictionary_.ContainsKey("GUID"))
				{
					string text2;
					try
					{
						text2 = Conversions.ToString(dictionary_["GUID"]);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at PM16", "");
						GameGeneral.WriteExceptionsToLog(ref exception_);
						throw new LuaError("guid必须是一个字符串");
					}
					try
					{
						activeUnit = scenario_0.ActiveUnits[text2];
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
				if (activeUnit == null)
				{
					throw new LuaError("需要定义名称或Guid来标识单元。最好是Guid或Side＆Name。");
				}
				if (dictionary_.ContainsKey("LOADOUTID"))
				{
					int num = Conversions.ToInteger(dictionary_["LOADOUTID"]);
					Loadout loadout;
					try
					{
						loadout = DBFunctions.GetLoadout(ref scenario_0, num, bool_0: false, bool_1: true);
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at PM17", "");
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("必须提供有效的挂载ID");
					}
					if (dictionary_.ContainsKey("QUANTITY") && Conversions.ToInteger(dictionary_["QUANTITY"]) > 0)
					{
						int num2 = Conversions.ToInteger(dictionary_["QUANTITY"]);
						LuaTable val = LuaSandBox.Singleton().CreateTable();
						val[1] = "试图添加" + Conversions.ToString(num2) + "x挂载：#" + Conversions.ToString(num) + " - " + loadout.Name + "到单元的弹药库：" + activeUnit.Name;
						int num3 = 1;
						WeaponRec[] weapons = loadout.Weapons;
						WeaponRec[] array = weapons;
						foreach (WeaponRec weaponRec in array)
						{
							weaponRec.MaxLoad *= num2;
							weaponRec.CurrentLoad *= num2;
							int num4 = 0;
							int num5 = 0;
							if (weaponRec.CurrentLoad <= 0)
							{
								continue;
							}
							int currentLoad = weaponRec.CurrentLoad;
							for (int i = 1; i <= currentLoad; i++)
							{
								if (Operators.CompareString(activeUnit.Weaponry.AddWeaponToMagazines(weaponRec.int_0, bool_1: true, bool_2: true), "OK", TextCompare: false) == 0)
								{
									num4++;
								}
								else
								{
									num5++;
								}
							}
							if (num4 > 0)
							{
								num3++;
								val[num3] = "成功添加" + Conversions.ToString(num4) + "x类型的弹药储备：" + weaponRec.GetReferenceWeapon(scenario_0).Name;
							}
							if (num5 > 0)
							{
								num3++;
								val[num3] = "无法添加" + Conversions.ToString(num5) + "x类型的弹药储备：" + weaponRec.GetReferenceWeapon(scenario_0).Name;
							}
						}
						return val;
					}
					throw new LuaError("必须提供有效（> 0）的数量编号");
				}
				throw new LuaError("必须提供有效的挂载ID");
			}
			throw new LuaError(text);
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at PM18", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static LuaTable ScenEdit_SetUnitDamage(LuaTable luaTable_0, Scenario scenario_0)
	{
		try
		{
			Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			ActiveUnit activeUnit = null;
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			LuaUtility.ParseUnitDict(ref dictionary_);
			string text = LuaUtility.QueryUnit(dictionary_, scenario_0);
			if (text.Length == 0)
			{
				if (dictionary_.ContainsKey("GUID"))
				{
					string text2;
					try
					{
						text2 = Conversions.ToString(dictionary_["GUID"]);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at PM19", "");
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("guid必须是一个字符串");
					}
					activeUnit = scenario_0.ActiveUnits[text2];
				}
				if (activeUnit == null)
				{
					return null;
				}
				ActiveUnit_Damage damage = activeUnit.Damage;
				ActiveUnit_Damage.FireIntensityLevel result = ActiveUnit_Damage.FireIntensityLevel.NoFire;
				ActiveUnit_Damage.FloodingIntensityLevel result2 = ActiveUnit_Damage.FloodingIntensityLevel.NoFlooding;
				float num = 0f;
				if (dictionary_.ContainsKey("FIRES"))
				{
					try
					{
						if (Enum.TryParse<ActiveUnit_Damage.FireIntensityLevel>(Conversions.ToString(dictionary_["FIRES"]), ignoreCase: true, out result) && Enum.IsDefined(typeof(ActiveUnit_Damage.FireIntensityLevel), result))
						{
							damage.FireIntensity = result;
						}
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at PM20", "");
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				if (dictionary_.ContainsKey("FLOOD"))
				{
					try
					{
						if (Enum.TryParse<ActiveUnit_Damage.FloodingIntensityLevel>(Conversions.ToString(dictionary_["FLOOD"]), ignoreCase: true, out result2) && Enum.IsDefined(typeof(ActiveUnit_Damage.FloodingIntensityLevel), result2))
						{
							damage.FloodIntensity = result2;
						}
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception exception_3 = ex3;
						exception_3?.Data.Add("Error at PM21", "");
						GameGeneral.WriteExceptionsToLog(ref exception_3);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				if (dictionary_.ContainsKey("DP"))
				{
					try
					{
						num = Conversions.ToSingle(dictionary_["DP"]);
					}
					catch (Exception ex4)
					{
						ProjectData.SetProjectError(ex4);
						Exception exception_4 = ex4;
						exception_4?.Data.Add("Error at PM22", "");
						GameGeneral.WriteExceptionsToLog(ref exception_4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					ActiveUnit activeUnit2;
					(activeUnit2 = activeUnit).SetDamagePts(bool_0: false, null, activeUnit2.GetDamagePts() - num);
				}
				if (dictionary_.ContainsKey("COMPONENTS"))
				{
					foreach (object item in LuaUtility.ToArray(((LuaTable)dictionary_["COMPONENTS"]).GetEnumerator()))
					{
						object objectValue = RuntimeHelpers.GetObjectValue(item);
						if (objectValue is LuaTable)
						{
							Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator());
							if (dictionary.Count <= 0)
							{
								continue;
							}
							PlatformComponent platformComponent = null;
							int num2 = 0;
							bool flag = false;
							bool flag2 = false;
							string text3 = Conversions.ToString(dictionary["1"]);
							PlatformComponent._DamageSeverityFactor result3 = PlatformComponent._DamageSeverityFactor.Light;
							if (Operators.CompareString(Conversions.ToString(dictionary["2"]).ToLower(), "none", TextCompare: false) == 0)
							{
								flag = true;
							}
							else if (Operators.CompareString(Conversions.ToString(dictionary["2"]).ToLower(), "destroyed", TextCompare: false) == 0)
							{
								flag2 = true;
								result3 = PlatformComponent._DamageSeverityFactor.Heavy;
							}
							else
							{
								if (!(Enum.TryParse<PlatformComponent._DamageSeverityFactor>(Conversions.ToString(dictionary["2"]), ignoreCase: true, out result3) & Enum.IsDefined(typeof(PlatformComponent._DamageSeverityFactor), result3)))
								{
									throw new LuaError("'的毁伤等级错误" + text3 + "'在ScenEdit_SetUnitDamage中。");
								}
								if ((int)result3 <= 2)
								{
									if ((int)result3 < 0)
									{
										result3 = PlatformComponent._DamageSeverityFactor.Light;
									}
								}
								else
								{
									result3 = PlatformComponent._DamageSeverityFactor.Heavy;
								}
							}
							string text4 = null;
							num2 = activeUnit.OrderIssuer().Count;
							int index = GameGeneral.LockRandom_0.Next(0, num2);
							if (Operators.CompareString(text3.ToUpper(), "TYPE", TextCompare: false) == 0)
							{
								if (dictionary.ContainsKey("TYPE"))
								{
									text4 = Conversions.ToString(dictionary["TYPE"]);
									if (num2 <= 0)
									{
										continue;
									}
									PlatformComponent[] array = new PlatformComponent[num2 + 1];
									int num3 = 0;
									foreach (PlatformComponent item2 in activeUnit.OrderIssuer())
									{
										platformComponent = item2;
										if (Operators.CompareString(platformComponent.GetType().Name.ToUpper(), text4.ToUpper(), TextCompare: false) == 0)
										{
											array[num3] = platformComponent;
											num3++;
										}
									}
									if (num3 > 0)
									{
										index = GameGeneral.LockRandom_0.Next(0, num3);
										_ = array[index].DamageSeverity;
										if (flag)
										{
											array[index].Damage(PlatformComponent._DamageSeverityFactor.Light);
											array[index].Repair();
										}
										else if (flag2)
										{
											array[index].Damage(PlatformComponent._DamageSeverityFactor.Heavy);
											array[index].Destroy(activeUnit.GetUnitSide(), bool_0: true, bool_1: false);
										}
										else
										{
											array[index].Damage(result3);
										}
										LuaTable val2 = LuaSandBox.Singleton().CreateTable();
										val2["guid"] = array[index].ObjectID;
										val2["dbid"] = array[index].DBID;
										val2["name"] = array[index].Name;
										val2["type"] = array[index].GetType().Name;
										val2["status"] = array[index].Status.ToString();
										if (platformComponent.Status != 0)
										{
											val2["damage"] = array[index].DamageSeverity.ToString();
										}
										val[val.Keys.Count + 1] = val2;
									}
								}
								else
								{
									PlatformComponent._DamageSeverityFactor damageSeverity = activeUnit.OrderIssuer()[index].DamageSeverity;
									activeUnit.OrderIssuer()[index].Damage(result3);
									if (result3 == PlatformComponent._DamageSeverityFactor.Light && (flag || damageSeverity != 0))
									{
										activeUnit.OrderIssuer()[index].Repair();
									}
								}
								continue;
							}
							LuaTable val3 = LuaSandBox.Singleton().CreateTable();
							bool flag3 = false;
							switch (activeUnit.GetType().ToString())
							{
							case "Command_Core.Submarine":
							{
								Submarine submarine = (Submarine)activeUnit;
								if (Operators.CompareString(text3.ToUpper(), "RUDDER", TextCompare: false) == 0)
								{
									if (flag)
									{
										submarine.Rudder.Damage(PlatformComponent._DamageSeverityFactor.Light);
										submarine.Rudder.Repair();
									}
									else if (flag2)
									{
										submarine.Rudder.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
										submarine.Rudder.Destroy(activeUnit.GetUnitSide(), bool_0: true, bool_1: false);
									}
									else
									{
										submarine.Rudder.Damage(result3);
									}
									val3["name"] = text3.ToUpper();
									val3["status"] = ((Submarine)activeUnit).Rudder.Status.ToString();
									if (((Submarine)activeUnit).Rudder.Status != 0)
									{
										val3["damage"] = ((Submarine)activeUnit).Rudder.DamageSeverity.ToString();
									}
									val[val.Keys.Count + 1] = val3;
									flag3 = true;
								}
								else if (Operators.CompareString(text3.ToUpper(), "CARGO", TextCompare: false) == 0)
								{
									if (flag)
									{
										submarine.Cargo.Damage(PlatformComponent._DamageSeverityFactor.Light);
										submarine.Cargo.Repair();
									}
									else if (flag2)
									{
										submarine.Cargo.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
										submarine.Cargo.Destroy(activeUnit.GetUnitSide(), bool_0: true, bool_1: false);
									}
									else
									{
										submarine.Cargo.Damage(result3);
									}
									val3["name"] = text3.ToUpper();
									val3["status"] = ((Submarine)activeUnit).Cargo.Status.ToString();
									if (((Submarine)activeUnit).Cargo.Status != 0)
									{
										val3["damage"] = ((Submarine)activeUnit).Cargo.DamageSeverity.ToString();
									}
									val[val.Keys.Count + 1] = val3;
									flag3 = true;
								}
								else if (Operators.CompareString(text3.ToUpper(), "PRESSUREHULL", TextCompare: false) == 0)
								{
									if (flag)
									{
										submarine.PressureHull.Damage(PlatformComponent._DamageSeverityFactor.Light);
										submarine.PressureHull.Repair();
									}
									else if (flag2)
									{
										submarine.PressureHull.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
										submarine.PressureHull.Destroy(activeUnit.GetUnitSide(), bool_0: true, bool_1: false);
									}
									else
									{
										submarine.PressureHull.Damage(result3);
									}
									val3["name"] = text3.ToUpper();
									val3["status"] = ((Submarine)activeUnit).PressureHull.Status.ToString();
									if (((Submarine)activeUnit).PressureHull.Status != 0)
									{
										val3["damage"] = ((Submarine)activeUnit).PressureHull.DamageSeverity.ToString();
									}
									val[val.Keys.Count + 1] = val3;
									flag3 = true;
								}
								else if (Operators.CompareString(text3.ToUpper(), "CIC", TextCompare: false) == 0)
								{
									if (flag)
									{
										submarine.CIC.Damage(PlatformComponent._DamageSeverityFactor.Light);
										submarine.CIC.Repair();
									}
									else if (flag2)
									{
										submarine.CIC.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
										submarine.CIC.Destroy(activeUnit.GetUnitSide(), bool_0: true, bool_1: false);
									}
									else
									{
										submarine.CIC.Damage(result3);
									}
									val3["name"] = text3.ToUpper();
									val3["status"] = ((Submarine)activeUnit).CIC.Status.ToString();
									if (((Submarine)activeUnit).CIC.Status != 0)
									{
										val3["damage"] = ((Submarine)activeUnit).CIC.DamageSeverity.ToString();
									}
									val[val.Keys.Count + 1] = val3;
									flag3 = true;
								}
								break;
							}
							case "Command_Core.Ship":
							{
								Ship ship = (Ship)activeUnit;
								if (Operators.CompareString(text3.ToUpper(), "RUDDER", TextCompare: false) == 0)
								{
									if (flag)
									{
										ship.Rudder.Damage(PlatformComponent._DamageSeverityFactor.Light);
										ship.Rudder.Repair();
									}
									else if (flag2)
									{
										ship.Rudder.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
										ship.Rudder.Destroy(activeUnit.GetUnitSide(), bool_0: true, bool_1: false);
									}
									else
									{
										ship.Rudder.Damage(result3);
									}
									val3["name"] = text3.ToUpper();
									val3["status"] = ((Ship)activeUnit).Rudder.Status.ToString();
									if (((Ship)activeUnit).Rudder.Status != 0)
									{
										val3["damage"] = ((Ship)activeUnit).Rudder.DamageSeverity.ToString();
									}
									val[val.Keys.Count + 1] = val3;
									flag3 = true;
								}
								else if (Operators.CompareString(text3.ToUpper(), "CARGO", TextCompare: false) != 0 && Operators.CompareString(text3.ToUpper(), "PRESSUREHULL", TextCompare: false) != 0 && Operators.CompareString(text3.ToUpper(), "CIC", TextCompare: false) == 0)
								{
									if (flag)
									{
										ship.CIC.Damage(PlatformComponent._DamageSeverityFactor.Light);
										ship.CIC.Repair();
									}
									else if (flag2)
									{
										ship.CIC.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
										ship.CIC.Destroy(activeUnit.GetUnitSide(), bool_0: true, bool_1: false);
									}
									else
									{
										ship.CIC.Damage(result3);
									}
									val3["name"] = text3.ToUpper();
									val3["status"] = ((Ship)activeUnit).CIC.Status.ToString();
									if (((Ship)activeUnit).CIC.Status != 0)
									{
										val3["damage"] = ((Ship)activeUnit).CIC.DamageSeverity.ToString();
									}
									val[val.Keys.Count + 1] = val3;
									flag3 = true;
								}
								break;
							}
							case "Command_Core.Facility":
							{
								Facility facility = (Facility)activeUnit;
								if (Operators.CompareString(text3.ToUpper(), "RUDDER", TextCompare: false) == 0)
								{
									break;
								}
								if (Operators.CompareString(text3.ToUpper(), "CARGO", TextCompare: false) == 0)
								{
									if (flag)
									{
										facility.Cargo.Damage(PlatformComponent._DamageSeverityFactor.Light);
										facility.Cargo.Repair();
									}
									else if (flag2)
									{
										facility.Cargo.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
										facility.Cargo.Destroy(activeUnit.GetUnitSide(), bool_0: true, bool_1: false);
									}
									else
									{
										facility.Cargo.Damage(result3);
									}
									val3["name"] = text3.ToUpper();
									val3["status"] = ((Facility)activeUnit).Cargo.Status.ToString();
									if (((Facility)activeUnit).Cargo.Status != 0)
									{
										val3["damage"] = ((Facility)activeUnit).Cargo.DamageSeverity.ToString();
									}
									val[val.Keys.Count + 1] = val3;
									flag3 = true;
								}
								else if (Operators.CompareString(text3.ToUpper(), "PRESSUREHULL", TextCompare: false) != 0 && Operators.CompareString(text3.ToUpper(), "CIC", TextCompare: false) == 0)
								{
									if (flag)
									{
										facility.CIC.Damage(PlatformComponent._DamageSeverityFactor.Light);
										facility.CIC.Repair();
									}
									else if (flag2)
									{
										facility.CIC.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
										facility.CIC.Destroy(activeUnit.GetUnitSide(), bool_0: true, bool_1: false);
									}
									else
									{
										facility.CIC.Damage(result3);
									}
									val3["name"] = text3.ToUpper();
									val3["status"] = ((Facility)activeUnit).CIC.Status.ToString();
									if (((Facility)activeUnit).CIC.Status != 0)
									{
										val3["damage"] = ((Facility)activeUnit).CIC.DamageSeverity.ToString();
									}
									val[val.Keys.Count + 1] = val3;
									flag3 = true;
								}
								break;
							}
							}
							if (num2 <= 0 || flag3)
							{
								continue;
							}
							foreach (PlatformComponent item3 in activeUnit.OrderIssuer())
							{
								if (string.Equals(item3.Name, text3, StringComparison.OrdinalIgnoreCase) || string.Equals(item3.ObjectID, text3, StringComparison.OrdinalIgnoreCase))
								{
									_ = item3.DamageSeverity;
									if (flag)
									{
										item3.Damage(PlatformComponent._DamageSeverityFactor.Light);
										item3.Repair();
									}
									else if (flag2)
									{
										item3.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
										item3.Destroy(activeUnit.GetUnitSide(), bool_0: true, bool_1: false);
									}
									else
									{
										item3.Damage(result3);
									}
									LuaTable val4 = LuaSandBox.Singleton().CreateTable();
									val4["guid"] = item3.ObjectID;
									val4["dbid"] = item3.DBID;
									val4["name"] = item3.Name;
									val4["type"] = item3.GetType().Name;
									val4["status"] = item3.Status.ToString();
									if (item3.Status != 0)
									{
										val4["damage"] = item3.DamageSeverity.ToString();
									}
									val[val.Keys.Count + 1] = val4;
									break;
								}
							}
							continue;
						}
						throw new LuaError("Error at " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue)) + "在ScenEdit_SetUnitDamage中。");
					}
				}
				return val;
			}
			throw new LuaError(text);
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception exception_5 = ex5;
			exception_5?.Data.Add("Error at PM23", "");
			GameGeneral.WriteExceptionsToLog(ref exception_5);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static bool ScenEdit_SetExportOutputRate(string string_0, string string_1)
	{
		if (string.Compare(string_0, "UNITPOSITIONS", ignoreCase: true) == 0)
		{
			IEventExporter.EventExportOutputRate bridge = Exporter_General.GetBridge(string_1);
			if (bridge == IEventExporter.EventExportOutputRate.Unknown)
			{
				throw new LuaError("Unrecognized event export output rate. Valid values are: 'MatchSimSpeed', 'Continuous', '1Second', '2Seconds', '5Seconds', '15Seconds', '30Seconds', '1Minute', '5Minutes', '15Minutes', '30Minutes', '1Hour', '6Hours', '12Hours', or '24Hours'");
			}
			Exporter_General.SetEventOutputRate(IEventExporter.ExportedEventType.UnitPositions, bridge);
			return true;
		}
		throw new LuaError("Only the 'UnitPositions' export type is currently supported.");
	}

	public static bool ScenEdit_SetEMCON(string string_0, string string_1, string string_2, Scenario scenario_0)
	{
		Doctrine doctrine = null;
		string_0 = Strings.Trim(string_0);
		string_1 = Strings.Trim(string_1);
		string_2 = Strings.Trim(string_2);
		try
		{
			ActiveUnit activeUnit = null;
			switch (string_0.ToUpper())
			{
			default:
				throw new LuaError("Unable to identify EMCON subject type! Valid inputs are: Side / Mission /Group / Unit");
			case "UNIT":
				foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
				{
					if (activeUnits_ != null && (string.Equals(activeUnits_.Name, string_1, StringComparison.OrdinalIgnoreCase) || string.Equals(activeUnits_.ObjectID, string_1, StringComparison.OrdinalIgnoreCase)))
					{
						doctrine = activeUnits_.Doctrine;
						activeUnit = activeUnits_;
						break;
					}
				}
				break;
			case "SIDE":
			{
				Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
				Side[] array2 = sides_ReadOnly;
				foreach (Side side in array2)
				{
					if (string.Equals(side.Name, string_1, StringComparison.OrdinalIgnoreCase) || string.Equals(side.ObjectID, string_1, StringComparison.OrdinalIgnoreCase))
					{
						doctrine = side.Doctrine;
						break;
					}
				}
				break;
			}
			case "MISSION":
			{
				Side[] sides_ReadOnly2 = scenario_0.Sides_ReadOnly;
				for (int i = 0; i < sides_ReadOnly2.Length; i++)
				{
					foreach (Mission mission in sides_ReadOnly2[i].Missions)
					{
						if (string.Equals(mission.Name, string_1, StringComparison.OrdinalIgnoreCase) || string.Equals(mission.ObjectID, string_1, StringComparison.OrdinalIgnoreCase))
						{
							doctrine = mission.Doctrine;
							break;
						}
					}
				}
				break;
			}
			case "GROUP":
				foreach (ActiveUnit activeUnits_2 in scenario_0.ActiveUnits_List)
				{
					if (activeUnits_2 != null && activeUnits_2.IsGroup && (string.Equals(activeUnits_2.Name, string_1, StringComparison.OrdinalIgnoreCase) || string.Equals(activeUnits_2.ObjectID, string_1, StringComparison.OrdinalIgnoreCase)))
					{
						doctrine = activeUnits_2.Doctrine;
						activeUnit = activeUnits_2;
						break;
					}
				}
				break;
			}
			if (doctrine == null)
			{
				throw new LuaError("Unable to identify subject of EMCON change! Please verify the subject-type and subject-name/ID strings.");
			}
			string[] array = string_2.Split(';');
			string[] array3 = array;
			foreach (string text in array3)
			{
				if (Operators.CompareString(text.ToUpper(), "INHERIT", TextCompare: false) == 0)
				{
					doctrine.EMCON_Inherits = true;
					continue;
				}
				KeyValuePair<string, string> keyValuePair = new KeyValuePair<string, string>(text.Split('=')[0], text.Split('=')[1]);
				switch (keyValuePair.Key.ToUpper())
				{
				case "SONAR":
					if (Operators.CompareString(keyValuePair.Value.ToUpper(), "ACTIVE", TextCompare: false) == 0)
					{
						if (doctrine.EMCON_Inherits)
						{
							doctrine.EMCON_Inherits = false;
						}
						doctrine.SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Active, scenario_0);
						break;
					}
					if (Operators.CompareString(keyValuePair.Value.ToUpper(), "PASSIVE", TextCompare: false) == 0)
					{
						if (doctrine.EMCON_Inherits)
						{
							doctrine.EMCON_Inherits = false;
						}
						doctrine.SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Passive, scenario_0);
						break;
					}
					throw new LuaError("Invalid value for sonar EMCON setting (Valid values: Active / Passive).");
				case "RADAR":
					if (Operators.CompareString(keyValuePair.Value.ToUpper(), "ACTIVE", TextCompare: false) == 0)
					{
						if (doctrine.EMCON_Inherits)
						{
							doctrine.EMCON_Inherits = false;
						}
						doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Active, scenario_0);
						break;
					}
					if (Operators.CompareString(keyValuePair.Value.ToUpper(), "PASSIVE", TextCompare: false) == 0)
					{
						if (doctrine.EMCON_Inherits)
						{
							doctrine.EMCON_Inherits = false;
						}
						doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Passive, scenario_0);
						break;
					}
					throw new LuaError("Invalid value for radar EMCON setting (Valid values: Active / Passive).");
				case "OECM":
					if (Operators.CompareString(keyValuePair.Value.ToUpper(), "ACTIVE", TextCompare: false) == 0)
					{
						if (doctrine.EMCON_Inherits)
						{
							doctrine.EMCON_Inherits = false;
						}
						doctrine.SetEMCON_OECM(Doctrine.EMCONSettings._EMCONSetting.Active, scenario_0);
						break;
					}
					if (Operators.CompareString(keyValuePair.Value.ToUpper(), "PASSIVE", TextCompare: false) == 0)
					{
						if (doctrine.EMCON_Inherits)
						{
							doctrine.EMCON_Inherits = false;
						}
						doctrine.SetEMCON_OECM(Doctrine.EMCONSettings._EMCONSetting.Passive, scenario_0);
						break;
					}
					throw new LuaError("Invalid value for OECM EMCON setting (Valid values: Active / Passive).");
				}
			}
			if (activeUnit != null)
			{
				activeUnit.Sensory.Boolean_0 = true;
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at PM24", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static string ScenEdit_MsgBox(string string_0, int int_0, Scenario scenario_0)
	{
		string pressed = "";
		PrivateMethods.LuaMessageBox?.Invoke(string_0, int_0, scenario_0.RunningHeadless, ref pressed);
		return pressed;
	}

	public static string ScenEdit_InputBox(string string_0, Scenario scenario_0)
	{
		string pressed = "";
		PrivateMethods.LuaInputBox?.Invoke(string_0, scenario_0.RunningHeadless, ref pressed);
		return pressed;
	}

	public static string ScenEdit_LocalVideo(string string_0, Scenario scenario_0, bool bool_0, int int_0)
	{
		if (!FileExistsNative.FileExistsFast(string_0))
		{
			if (!FileExistsNative.FileExistsFast(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Video" + Conversions.ToString(Path.DirectorySeparatorChar) + string_0))
			{
				return "N";
			}
			string_0 = GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Video" + Conversions.ToString(Path.DirectorySeparatorChar) + string_0;
		}
		PrivateMethods.LuaLocalVideo?.Invoke(string_0, scenario_0?.RunningHeadless ?? false, bool_0, int_0);
		return "";
	}

	public static bool ScenEdit_LocalSound(string string_0, int int_0)
	{
		if (FileExistsNative.FileExistsFast(string_0))
		{
			if (!string_0.Contains(":"))
			{
				string_0 = FileSystem.CurDir() + "\\" + string_0;
			}
		}
		else
		{
			if (!FileExistsNative.FileExistsFast(MerchantMerchantPage.LogoutList.Info.DirectoryPath + "\\Sound\\Effects\\" + string_0))
			{
				return false;
			}
			string_0 = MerchantMerchantPage.LogoutList.Info.DirectoryPath + "\\Sound\\Effects\\" + string_0;
		}
		PrivateMethods.LuaLocalSound?.Invoke(string_0, int_0);
		return true;
	}

	public static int ScenEdit_GetScore(string string_0, Scenario scenario_0)
	{
		Side side = LuaUtility.QuerySideObject(string_0, scenario_0);
		if (Information.IsNothing(side))
		{
			throw new LuaError("无法识别分方！");
		}
		return side.GetTotalScore(scenario_0);
	}

	public static string ScenEdit_GetSidePosture(string string_0, string string_1, Scenario scenario_0)
	{
		try
		{
			Side side = null;
			Side side2 = null;
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side3 in array)
			{
				if (string.Equals(side3.ObjectID, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(side3.Name, string_0, StringComparison.OrdinalIgnoreCase))
				{
					side = side3;
				}
				if (string.Equals(side3.ObjectID, string_1, StringComparison.OrdinalIgnoreCase) || string.Equals(side3.Name, string_1, StringComparison.OrdinalIgnoreCase))
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
			switch (side.GetConsidersThisSideToBe(side2))
			{
			case Misc.PostureStance.Neutral:
				return "N";
			case Misc.PostureStance.Friendly:
				return "F";
			case Misc.PostureStance.Unfriendly:
				return "U";
			case Misc.PostureStance.Hostile:
				return "H";
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at PM25", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
		return "";
	}

	public static LuaTable ScenEdit_GetSideOptions(LuaTable luaTable_0, Scenario scenario_0)
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
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at PM26", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("分方必须是一个字符串");
				}
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at PM27", "");
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到分方'" + text + "'");
				}
			}
			dictionary["SIDE"] = side.Name;
			dictionary["GUID"] = side.ObjectID;
			dictionary["AWARENESS"] = side.AwarenessLevel.ToString();
			dictionary["PROFICIENCY"] = side.Proficiency.ToString();
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			LuaUtility.FromDict(dictionary, val);
			return val;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at PM28", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static string ScenEdit_RunToTimeAndHalt(LuaTable luaTable_0, Scenario scenario_0)
	{
		string text = "DDMMYYYY";
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		string right = "DDMMYYYY";
		string right2 = "MMDDYYYY";
		string right3 = "YYYYMMDD";
		try
		{
			if (dictionary.ContainsKey("DATEFORMAT"))
			{
				string text2 = Conversions.ToString(dictionary["DATEFORMAT"]);
				if (Operators.CompareString(text2, right, TextCompare: false) != 0 && Operators.CompareString(text2, right2, TextCompare: false) != 0 && Operators.CompareString(text2, right3, TextCompare: false) != 0)
				{
					throw new LuaError("Invalid date format '" + text2 + "'");
				}
				text = text2;
			}
			if (dictionary.ContainsKey("DATE"))
			{
				string string_ = Conversions.ToString(dictionary["DATE"]);
				string left = text;
				(int, int, int) tuple = default((int, int, int));
				if (Operators.CompareString(left, right, TextCompare: false) == 0)
				{
					tuple = LuaUtility.ParseDate_DDMMYYYY(string_);
				}
				else if (Operators.CompareString(left, right2, TextCompare: false) == 0)
				{
					tuple = LuaUtility.ParseDate_MMDDYYYY(string_);
				}
				else if (Operators.CompareString(left, right3, TextCompare: false) == 0)
				{
					tuple = LuaUtility.ParseDate_YYYYMMDD(string_);
				}
				scenario_0.TimeToHalt = new DateTime(tuple.Item3, tuple.Item2, tuple.Item1, scenario_0.Time.Hour, scenario_0.Time.Minute, scenario_0.Time.Second);
			}
			if (dictionary.ContainsKey("TIME"))
			{
				(int, int, int) tuple2 = LuaUtility.ParseTime_HHMMSS(Conversions.ToString(dictionary["TIME"]));
				scenario_0.TimeToHalt = new DateTime(scenario_0.Time.Year, scenario_0.Time.Month, scenario_0.Time.Day, tuple2.Item1, tuple2.Item2, tuple2.Item3);
			}
			return "OK - Scenario will run to " + scenario_0.TimeToHalt.Value.ToShortDateString() + " - " + scenario_0.TimeToHalt.Value.ToLongTimeString() + " and then halt.";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at PM29", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			if (exception_ is LuaError)
			{
				throw new LuaError("Error in VP_RunToTimeAndHalt: " + ((LuaError)exception_).sMessage);
			}
			throw new LuaError("Error in VP_RunToTimeAndHalt: " + exception_.Message);
		}
	}

	public static string ScenEdit_RunForTimeAndHalt(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		try
		{
			if (dictionary.ContainsKey("TIME"))
			{
				string text = Conversions.ToString(dictionary["TIME"]);
				(int, int, int) tuple = LuaUtility.ParseTime_HHMMSS(text);
				TimeSpan value = new TimeSpan(tuple.Item1, tuple.Item2, tuple.Item3);
				if (value.TotalSeconds <= 0.0)
				{
					throw new LuaError("Error in VP_RunForTimeAndHalt: Unable to parse provided time figure '" + text + "'");
				}
				scenario_0.TimeToHalt = scenario_0.Time.Add(value);
				return "OK - Scenario will run to " + scenario_0.TimeToHalt.Value.ToShortDateString() + " - " + scenario_0.TimeToHalt.Value.ToLongTimeString() + " and then halt.";
			}
			throw new LuaError("Error in VP_RunForTimeAndHalt: No 'Time' value provided");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at PM30", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			if (exception_ is LuaError)
			{
				throw new LuaError("Error in VP_RunForTimeAndHalt: " + ((LuaError)exception_).sMessage);
			}
			throw new LuaError("Error in VP_RunForTimeAndHalt: " + exception_.Message);
		}
	}

	public static string EpochToUTC_Date(int int_0)
	{
		return Conversions.ToDate("1.1.1970 00:00:00").AddSeconds(int_0).ToString("dd:MM:yyyy");
	}

	public static string EpochToUTC_Time(int int_0)
	{
		return Conversions.ToDate("1.1.1970 00:00:00").AddSeconds(int_0).ToString("HH:mm:ss");
	}

	public static double ScenEdit_SetTime(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		bool flag = false;
		string right = "DDMMYYYY";
		string right2 = "MMDDYYYY";
		string right3 = "YYYYMMDD";
		string text = "DDMMYYYY";
		if (!dictionary.ContainsKey("DATEFORMAT"))
		{
			text = "MMDDYYYY";
			dictionary.Add("DATEFORMAT", text);
		}
		if (dictionary.ContainsKey("DATEFORMAT"))
		{
			string text2 = Conversions.ToString(dictionary["DATEFORMAT"]);
			if (Operators.CompareString(text2, right, TextCompare: false) != 0 && Operators.CompareString(text2, right2, TextCompare: false) != 0 && Operators.CompareString(text2, right3, TextCompare: false) != 0)
			{
				throw new LuaError("Invalid date format '" + text2 + "'");
			}
			text = text2;
		}
		string left = text;
		if (Operators.CompareString(left, right, TextCompare: false) == 0)
		{
			if (dictionary.ContainsKey("STARTDATE"))
			{
				(int, int, int) tuple = LuaUtility.ParseDate_DDMMYYYY(Conversions.ToString(dictionary["STARTDATE"]));
				scenario_0.StartTime = new DateTime(tuple.Item3, tuple.Item2, tuple.Item1, scenario_0.StartTime.Hour, scenario_0.StartTime.Minute, scenario_0.StartTime.Second);
				flag = true;
			}
			if (dictionary.ContainsKey("DATE"))
			{
				(int, int, int) tuple2 = LuaUtility.ParseDate_DDMMYYYY(Conversions.ToString(dictionary["DATE"]));
				scenario_0.SetTime(bool_0: true, new DateTime(tuple2.Item3, tuple2.Item2, tuple2.Item1, scenario_0.Time.Hour, scenario_0.Time.Minute, scenario_0.Time.Second));
				flag = false;
			}
		}
		else if (Operators.CompareString(left, right2, TextCompare: false) == 0)
		{
			if (dictionary.ContainsKey("STARTDATE"))
			{
				(int, int, int) tuple3 = LuaUtility.ParseDate_MMDDYYYY(Conversions.ToString(dictionary["STARTDATE"]));
				scenario_0.StartTime = new DateTime(tuple3.Item3, tuple3.Item2, tuple3.Item1, scenario_0.StartTime.Hour, scenario_0.StartTime.Minute, scenario_0.StartTime.Second);
				flag = true;
			}
			if (dictionary.ContainsKey("DATE"))
			{
				(int, int, int) tuple4 = LuaUtility.ParseDate_MMDDYYYY(Conversions.ToString(dictionary["DATE"]));
				scenario_0.SetTime(bool_0: true, new DateTime(tuple4.Item3, tuple4.Item2, tuple4.Item1, scenario_0.Time.Hour, scenario_0.Time.Minute, scenario_0.Time.Second));
				flag = false;
			}
		}
		else if (Operators.CompareString(left, right3, TextCompare: false) == 0)
		{
			if (dictionary.ContainsKey("STARTDATE"))
			{
				(int, int, int) tuple5 = LuaUtility.ParseDate_YYYYMMDD(Conversions.ToString(dictionary["STARTDATE"]));
				scenario_0.StartTime = new DateTime(tuple5.Item3, tuple5.Item2, tuple5.Item1, scenario_0.StartTime.Hour, scenario_0.StartTime.Minute, scenario_0.StartTime.Second);
				flag = true;
			}
			if (dictionary.ContainsKey("DATE"))
			{
				(int, int, int) tuple6 = LuaUtility.ParseDate_YYYYMMDD(Conversions.ToString(dictionary["DATE"]));
				scenario_0.SetTime(bool_0: true, new DateTime(tuple6.Item3, tuple6.Item2, tuple6.Item1, scenario_0.Time.Hour, scenario_0.Time.Minute, scenario_0.Time.Second));
				flag = false;
			}
		}
		if (dictionary.ContainsKey("STARTTIME"))
		{
			(int, int, int) tuple7 = LuaUtility.ParseTime_HHMMSS(Conversions.ToString(dictionary["STARTTIME"]));
			scenario_0.StartTime = new DateTime(scenario_0.StartTime.Year, scenario_0.StartTime.Month, scenario_0.StartTime.Day, tuple7.Item1, tuple7.Item2, tuple7.Item3);
			flag = true;
		}
		if (dictionary.ContainsKey("DURATION"))
		{
			(int, int, int) tuple8 = LuaUtility.ParseTime_Duration(Conversions.ToString(dictionary["DURATION"]));
			scenario_0.Duration = new TimeSpan(tuple8.Item1, tuple8.Item2, tuple8.Item3);
			flag = true;
		}
		if (dictionary.ContainsKey("TIME"))
		{
			(int, int, int) tuple9 = LuaUtility.ParseTime_HHMMSS(Conversions.ToString(dictionary["TIME"]));
			scenario_0.SetTime(bool_0: true, new DateTime(scenario_0.Time.Year, scenario_0.Time.Month, scenario_0.Time.Day, tuple9.Item1, tuple9.Item2, tuple9.Item3));
			flag = false;
		}
		if (flag)
		{
			scenario_0.SetTime(bool_0: true, scenario_0.Time);
		}
		return (scenario_0.Time - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
	}

	public static double ScenEdit_SetStartTime(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		string right = "DDMMYYYY";
		string text = "MMDDYYYY";
		string right2 = "YYYYMMDD";
		string text2 = text;
		if (dictionary.ContainsKey("DATEFORMAT"))
		{
			string text3 = Conversions.ToString(dictionary["DATEFORMAT"]);
			if (Operators.CompareString(text3, right, TextCompare: false) != 0 && Operators.CompareString(text3, text, TextCompare: false) != 0 && Operators.CompareString(text3, right2, TextCompare: false) != 0)
			{
				throw new LuaError("Invalid date format '" + text3 + "'");
			}
			text2 = text3;
		}
		if (dictionary.ContainsKey("DATE"))
		{
			string string_ = Conversions.ToString(dictionary["DATE"]);
			string left = text2;
			(int, int, int) tuple = default((int, int, int));
			if (Operators.CompareString(left, right, TextCompare: false) == 0)
			{
				tuple = LuaUtility.ParseDate_DDMMYYYY(string_);
			}
			else if (Operators.CompareString(left, text, TextCompare: false) == 0)
			{
				tuple = LuaUtility.ParseDate_MMDDYYYY(string_);
			}
			else if (Operators.CompareString(left, right2, TextCompare: false) == 0)
			{
				tuple = LuaUtility.ParseDate_YYYYMMDD(string_);
			}
			scenario_0.StartTime = new DateTime(tuple.Item3, tuple.Item2, tuple.Item1, scenario_0.StartTime.Hour, scenario_0.StartTime.Minute, scenario_0.StartTime.Second);
		}
		if (dictionary.ContainsKey("TIME"))
		{
			(int, int, int) tuple2 = LuaUtility.ParseTime_HHMMSS(Conversions.ToString(dictionary["TIME"]));
			scenario_0.StartTime = new DateTime(scenario_0.StartTime.Year, scenario_0.StartTime.Month, scenario_0.StartTime.Day, tuple2.Item1, tuple2.Item2, tuple2.Item3);
		}
		if (dictionary.ContainsKey("DURATION"))
		{
			(int, int, int) tuple3 = LuaUtility.ParseTime_Duration(Conversions.ToString(dictionary["DURATION"]));
			scenario_0.Duration = new TimeSpan(tuple3.Item1, tuple3.Item2, tuple3.Item3);
		}
		scenario_0.SetTime(bool_0: true, scenario_0.Time);
		return (scenario_0.StartTime - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
	}

	public static int ScenEdit_SetScore(string string_0, int int_0, Scenario scenario_0, string string_1)
	{
		Side side = LuaUtility.QuerySideObject(string_0, scenario_0);
		if (Information.IsNothing(side))
		{
			throw new LuaError("无法识别分方！");
		}
		side.SetTotalScore(scenario_0, string_1, int_0);
		return side.GetTotalScore(scenario_0);
	}

	public static int ScenEdit_SpecialMessage(string string_0, string string_1, Scenario scenario_0, LuaTable luaTable_0, bool bool_0)
	{
		Side side = LuaUtility.QuerySideObject(string_0, scenario_0);
		if (Information.IsNothing(side))
		{
			throw new LuaError("无法识别Side-A！");
		}
		Geopoint_Struct? geopoint_Struct = null;
		if (Information.IsNothing(luaTable_0))
		{
			if (Information.IsNothing(geopoint_Struct) && bool_0)
			{
				throw new LuaError("No valid location identified. A valid location is required if setting forceMapRecentre to true.");
			}
		}
		else
		{
			Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			double? num = LuaUtility.QueryLatitude(dictionary_);
			if (!num.HasValue)
			{
				throw new LuaError("缺少'纬度'");
			}
			double? num2 = LuaUtility.QueryLongitude(dictionary_);
			if (!num2.HasValue)
			{
				throw new LuaError("缺少'经度'");
			}
			geopoint_Struct = new Geopoint_Struct(num2.Value, num.Value);
		}
		scenario_0.AddMessage(string_1, string_1, LoggedMessage.MessageType.SpecialMessage, 0, null, side, geopoint_Struct.GetValueOrDefault(), bool_0);
		return 1;
	}

	public static LuaWrapper_ActiveUnit_SE ScenEdit_AddUnit(LuaTable luaTable_0, Scenario scenario_0)
	{
		ActiveUnit activeUnit = null;
		int int_ = 0;
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("TYPE"))
		{
			string text = Conversions.ToString(dictionary_["TYPE"]).ToUpper();
			Side side = null;
			try
			{
				side = LuaUtility.QuerySideOrFail(dictionary_, scenario_0);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM31", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				if (exception_ is LuaError)
				{
					throw;
				}
				throw new LuaError("Side not found");
			}
			if (dictionary_.ContainsKey("DBID"))
			{
				int int_2 = Conversions.ToInteger(dictionary_["DBID"]);
				if (dictionary_.ContainsKey("UNITNAME"))
				{
					string string_ = Conversions.ToString(dictionary_["UNITNAME"]);
					double? num = LuaUtility.QueryLatitude(dictionary_);
					double? num2 = LuaUtility.QueryLongitude(dictionary_);
					string text2 = null;
					string text3 = null;
					bool bool_ = false;
					if (dictionary_.ContainsKey("BASE"))
					{
						text2 = Conversions.ToString(dictionary_["BASE"]);
						if (!LuaUtility.QueryBaseUnit(dictionary_, scenario_0))
						{
							throw new LuaError("基地单元无效");
						}
						text3 = Conversions.ToString(dictionary_["BASE"]);
						ActiveUnit activeUnit2 = smethod_0(Conversions.ToString(dictionary_["BASE"]), scenario_0);
						string string_2 = text3;
						int num3 = 0;
						Platform platform = null;
						switch (text)
						{
						default:
							if (!((Operators.CompareString(text, "SUB", TextCompare: false) == 0) | (Operators.CompareString(text, "SUBMARINE", TextCompare: false) == 0)))
							{
								num3 = 1000;
								break;
							}
							goto case "SHIP";
						case "SHIP":
						{
							platform = new Ship(ref scenario_0);
							Ship ship_ = (Ship)platform;
							DBFunctions.GetShip(ref scenario_0, ref ship_, int_2);
							break;
						}
						case "AIR":
						case "AIRCRAFT":
						{
							platform = new Aircraft(ref scenario_0);
							Aircraft aircraft_ = (Aircraft)platform;
							DBFunctions.GetAircraft(ref scenario_0, ref aircraft_, int_2);
							break;
						}
						}
						while (num3 < 100)
						{
							switch (text)
							{
							default:
								if (!((Operators.CompareString(text, "SUB", TextCompare: false) == 0) | (Operators.CompareString(text, "SUBMARINE", TextCompare: false) == 0)))
								{
									continue;
								}
								goto case "SHIP";
							case "SHIP":
							{
								ActiveUnit_DockingOps dockingOps = activeUnit2.DockingOps;
								Platform activeUnit_ = platform;
								DockFacility dockFacility_ = null;
								if (!dockingOps.CanHostThisBoat(activeUnit_, ref dockFacility_))
								{
									num3++;
									activeUnit2 = NextAUBySceanrio(string_2, text2, scenario_0);
									if (activeUnit2 != null)
									{
										string_2 = activeUnit2.ObjectID;
										continue;
									}
									if (text3 != null)
									{
										dictionary_["BASE"] = text3;
									}
								}
								else if (!num2.HasValue | !num.HasValue)
								{
									dictionary_["LONGITUDE"] = activeUnit2.GetLongitude();
									dictionary_["LATITUDE"] = activeUnit2.GetLatitude();
									num2 = activeUnit2.GetLongitude();
									num = activeUnit2.GetLatitude();
									dictionary_["BASE"] = activeUnit2.ObjectID;
									bool_ = true;
								}
								break;
							}
							case "AIR":
							case "AIRCRAFT":
								if (activeUnit2.AirOps.CanHostThisAircraft((Aircraft)platform) != 0)
								{
									num3++;
									activeUnit2 = NextAUBySceanrio(string_2, text2, scenario_0);
									if (activeUnit2 != null)
									{
										string_2 = activeUnit2.ObjectID;
										continue;
									}
									if (text3 != null)
									{
										dictionary_["BASE"] = text3;
									}
								}
								else if (!num2.HasValue | !num.HasValue)
								{
									dictionary_["ALTITUDE"] = activeUnit2.GetCurrentAltitude();
									dictionary_["LONGITUDE"] = activeUnit2.GetLongitude();
									dictionary_["LATITUDE"] = activeUnit2.GetLatitude();
									num2 = activeUnit2.GetLongitude();
									num = activeUnit2.GetLatitude();
									dictionary_["BASE"] = activeUnit2.ObjectID;
								}
								break;
							}
							break;
						}
					}
					else
					{
						if (!num.HasValue)
						{
							throw new LuaError("缺少'纬度'");
						}
						if (!num2.HasValue)
						{
							throw new LuaError("缺少'经度'");
						}
					}
					string string_3 = null;
					if (dictionary_.ContainsKey("GUID"))
					{
						string_3 = Conversions.ToString(dictionary_["GUID"]);
					}
					try
					{
						switch (text)
						{
						case "WEAPON":
						{
							float? num5 = LuaUtility.QueryAltitude(dictionary_);
							activeUnit = scenario_0.AddNewWeapon(side, string_, num2.Value, num.Value, int_2, (short)Math.Round(num5.Value), Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string_3);
							((Weapon)activeUnit).LaunchPoint = new GeoPoint(activeUnit.GetLongitude(), activeUnit.GetLatitude());
							dictionary_["TYPE"] = "WEAPON";
							break;
						}
						case "SATELLITE":
							if (dictionary_.ContainsKey("ORBIT"))
							{
								int_ = Conversions.ToInteger(dictionary_["ORBIT"]);
							}
							activeUnit = scenario_0.AddNewSatellite(side, string_, int_2, int_, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string_3);
							dictionary_["TYPE"] = "SATELLITE";
							break;
						case "FACILITY":
						case "LAND":
							activeUnit = scenario_0.AddNewFacility(side, int_2, string_, num2.Value, num.Value, bool_, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string_3);
							dictionary_["TYPE"] = "FACILITY";
							break;
						case "SUB":
						case "SUBMARINE":
							activeUnit = scenario_0.AddNewSubmarine(side, int_2, string_, num2.Value, num.Value, bool_, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string_3);
							dictionary_["TYPE"] = "SUBMARINE";
							break;
						case "SHIP":
							activeUnit = scenario_0.AddNewShip(side, int_2, string_, num2.Value, num.Value, bool_, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string_3);
							dictionary_["TYPE"] = "SHIP";
							break;
						case "GROUND UNIT":
						case "VEHICLE":
							activeUnit = scenario_0.AddNewVehicle(side, int_2, string_, num2.Value, num.Value, bool_, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string_3);
							dictionary_["TYPE"] = "GROUND UNIT";
							break;
						default:
							throw new LuaError("类型不能" + text + " please choose one of the following: SHIP, SUB, AIRCRAFT, FACILITY, GROUND UNIT, SATELLITE, WEAPON");
						case "AIR":
						case "AIRCRAFT":
							if (dictionary_.ContainsKey("LOADOUTID"))
							{
								int int_3 = Conversions.ToInteger(dictionary_["LOADOUTID"]);
								float? num4 = LuaUtility.QueryAltitude(dictionary_);
								if (num4.HasValue)
								{
									activeUnit = scenario_0.AddNewAircraft(side, string_, num2.Value, num.Value, int_2, int_3, (short)Math.Round(num4.Value), Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string_3);
									dictionary_["TYPE"] = "AIRCRAFT";
									break;
								}
								throw new LuaError("缺少'海拔高度'");
							}
							throw new LuaError("缺少'LoadoutID'");
						}
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at PM32", "");
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						if (exception_2 is LuaError)
						{
							throw;
						}
						throw new LuaError(exception_2.Message);
					}
					if (activeUnit == null)
					{
						throw new LuaError("无法创建新单元");
					}
					object obj3 = (dictionary_["GUID"] = activeUnit.ObjectID);
					object obj = obj3;
					string_3 = (string)obj;
					if (dictionary_.ContainsKey("BASE"))
					{
						LuaTable obj2 = LuaSandBox.Singleton().CreateTable();
						obj2["HostedUnitNameOrID"] = activeUnit.ObjectID;
						obj2["SelectedHostNameOrID"] = Conversions.ToString(dictionary_["BASE"]);
						if (!Conversions.ToBoolean(ScenEdit_HostUnitToParent(obj2, scenario_0, null)))
						{
							throw new LuaError("无法停靠单元");
						}
						activeUnit.CurrentSpeed = 0f;
						activeUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
					}
					if (dictionary_.ContainsKey("HEADING") && !dictionary_.ContainsKey("DESIREDHEADING"))
					{
						dictionary_["DESIREDHEADING"] = RuntimeHelpers.GetObjectValue(dictionary_["HEADING"]);
					}
					LuaTable luaTable_ = LuaSandBox.Singleton().CreateTable();
					LuaUtility.FromDict(dictionary_, luaTable_);
					return ScenEdit_SetUnit(luaTable_, scenario_0);
				}
				throw new LuaError("缺少'名称'");
			}
			throw new LuaError("缺少'DBID'");
		}
		throw new LuaError("Missing 'Type' please choose one of SHIP, SUB, AIRCRAFT, FACILITY, GROUND UNIT, SATELLITE, WEAPON");
	}

	public static LuaWrapper_ActiveUnit_SE ScenEdit_UpdateUnit(LuaTable luaTable_0, Scenario scenario_0)
	{
		FuelRec._FuelType Local_e = (FuelRec._FuelType)0;
		ActiveUnit activeUnit_ = null;
		string text = null;
		int num = 0;
		PlatformComponent._Coverage coverage = null;
		PlatformComponent._Coverage coverage2 = null;
		PlatformComponent._Coverage coverage3 = null;
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("GUID"))
		{
			string text7 = null;
			try
			{
				text7 = Conversions.ToString(dictionary_["GUID"]);
				activeUnit_ = scenario_0.ActiveUnits[text7];
				if (activeUnit_ == null)
				{
					throw new LuaError("Can't find unit guid " + text7);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM33", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				if (exception_ is LuaError)
				{
					throw;
				}
				throw new LuaError("Can't find unit guid " + text7);
			}
		}
		if (dictionary_.ContainsKey("MODE"))
		{
			try
			{
				text = Conversions.ToString(dictionary_["MODE"]).ToUpper();
				switch (text)
				{
				default:
					throw new LuaError("function should be 'add_sensor', 'remove_sensor', 'add_mount', 'remove_mount', 'add_weapon', 'remove_weapon','add_comms', 'remove_comms', 'add_magazine', 'add_magazine_only', 'remove_magazine','add_fuel', 'remove_fuel', 'delta'");
				case "ADD_MOUNT":
					break;
				case "ADD_SENSOR":
					break;
				case "DELTA":
					break;
				case "ADD_FUEL":
					break;
				case "UPDATE_SENSOR_ARC":
					break;
				case "REMOVE_MOUNT":
					break;
				case "ADD_MAGAZINE_ONLY":
					break;
				case "REMOVE_SENSOR":
					break;
				case "REMOVE_MAGAZINE":
					break;
				case "REMOVE_COMMS":
					break;
				case "UPDATE_MOUNT_ARC":
					break;
				case "REMOVE_WEAPON":
					break;
				case "REMOVE_FUEL":
					break;
				case "ADD_COMMS":
					break;
				case "ADD_WEAPON":
					break;
				case "ADD_MAGAZINE":
					break;
				}
			}
			catch (Exception ex12)
			{
				ProjectData.SetProjectError(ex12);
				Exception exception_12 = ex12;
				exception_12?.Data.Add("Error at PM35", "");
				GameGeneral.WriteExceptionsToLog(ref exception_12);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		if (dictionary_.ContainsKey("DBID"))
		{
			try
			{
				num = Conversions.ToInteger(dictionary_["DBID"]);
			}
			catch (Exception ex23)
			{
				ProjectData.SetProjectError(ex23);
				Exception exception_23 = ex23;
				exception_23?.Data.Add("Error at PM36", "");
				GameGeneral.WriteExceptionsToLog(ref exception_23);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("缺少dbid");
			}
		}
		if (dictionary_.ContainsKey("ARC_DETECT"))
		{
			LuaTable val = (LuaTable)dictionary_["ARC_DETECT"];
			PlatformComponent._Coverage coverage4 = new PlatformComponent._Coverage();
			Conversions.ToString(LuaUtility.ToDictUpper(val.GetEnumerator())["1"]);
			List<object> list = LuaUtility.ToArray(val.GetEnumerator());
			try
			{
				foreach (object item in list)
				{
					string text8 = Conversions.ToString(item);
					switch (text8.ToUpper())
					{
					case "PMF1":
						coverage4.PMF1 = true;
						continue;
					case "PS2":
						coverage4.PS2 = true;
						continue;
					case "PMA1":
						coverage4.PMA1 = true;
						continue;
					case "PMF2":
						coverage4.PMF2 = true;
						continue;
					case "SS2":
						coverage4.SS2 = true;
						continue;
					case "PMA2":
						coverage4.PMA2 = true;
						continue;
					case "PB2":
						coverage4.PB2 = true;
						continue;
					case "SS1":
						coverage4.SS1 = true;
						continue;
					case "SMF1":
						coverage4.SMF1 = true;
						continue;
					case "PB1":
						coverage4.PB1 = true;
						continue;
					case "SMA1":
						coverage4.SMA1 = true;
						continue;
					case "SMF2":
						coverage4.SMF2 = true;
						continue;
					case "SMA2":
						coverage4.SMA2 = true;
						continue;
					case "PS1":
						coverage4.PS1 = true;
						continue;
					case "SB2":
						coverage4.SB2 = true;
						continue;
					case "SB1":
						coverage4.SB1 = true;
						continue;
					case "360":
						coverage4.PB1 = true;
						coverage4.PMA1 = true;
						coverage4.PMF1 = true;
						coverage4.PS1 = true;
						coverage4.SB1 = true;
						coverage4.SMA1 = true;
						coverage4.SMF1 = true;
						coverage4.SS1 = true;
						coverage4.PB2 = true;
						coverage4.PMA2 = true;
						coverage4.PMF2 = true;
						coverage4.PS2 = true;
						coverage4.SB2 = true;
						coverage4.SMA2 = true;
						coverage4.SMF2 = true;
						coverage4.SS2 = true;
						break;
					default:
						throw new LuaError("arc_detect中的弧度无效" + text8);
					}
					break;
				}
				coverage = coverage4;
			}
			catch (Exception ex24)
			{
				ProjectData.SetProjectError(ex24);
				Exception exception_24 = ex24;
				exception_24?.Data.Add("Error at PM37", "");
				GameGeneral.WriteExceptionsToLog(ref exception_24);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		if (dictionary_.ContainsKey("ARC_TRACK"))
		{
			LuaTable val2 = (LuaTable)dictionary_["ARC_TRACK"];
			PlatformComponent._Coverage coverage5 = new PlatformComponent._Coverage();
			Conversions.ToString(LuaUtility.ToDictUpper(val2.GetEnumerator())["1"]);
			List<object> list2 = LuaUtility.ToArray(val2.GetEnumerator());
			try
			{
				foreach (object item2 in list2)
				{
					string text9 = Conversions.ToString(item2);
					switch (text9.ToUpper())
					{
					case "PMF1":
						coverage5.PMF1 = true;
						continue;
					case "PS2":
						coverage5.PS2 = true;
						continue;
					case "PMA1":
						coverage5.PMA1 = true;
						continue;
					case "PMF2":
						coverage5.PMF2 = true;
						continue;
					case "SS2":
						coverage5.SS2 = true;
						continue;
					case "PMA2":
						coverage5.PMA2 = true;
						continue;
					case "PB2":
						coverage5.PB2 = true;
						continue;
					case "SS1":
						coverage5.SS1 = true;
						continue;
					case "SMF1":
						coverage5.SMF1 = true;
						continue;
					case "PB1":
						coverage5.PB1 = true;
						continue;
					case "SMA1":
						coverage5.SMA1 = true;
						continue;
					case "SMF2":
						coverage5.SMF2 = true;
						continue;
					case "SMA2":
						coverage5.SMA2 = true;
						continue;
					case "PS1":
						coverage5.PS1 = true;
						continue;
					case "SB2":
						coverage5.SB2 = true;
						continue;
					case "SB1":
						coverage5.SB1 = true;
						continue;
					case "360":
						coverage5.PB1 = true;
						coverage5.PMA1 = true;
						coverage5.PMF1 = true;
						coverage5.PS1 = true;
						coverage5.SB1 = true;
						coverage5.SMA1 = true;
						coverage5.SMF1 = true;
						coverage5.SS1 = true;
						coverage5.PB2 = true;
						coverage5.PMA2 = true;
						coverage5.PMF2 = true;
						coverage5.PS2 = true;
						coverage5.SB2 = true;
						coverage5.SMA2 = true;
						coverage5.SMF2 = true;
						coverage5.SS2 = true;
						break;
					default:
						throw new LuaError("arc_track中的弧度无效" + text9);
					}
					break;
				}
				coverage2 = coverage5;
			}
			catch (Exception ex25)
			{
				ProjectData.SetProjectError(ex25);
				Exception exception_25 = ex25;
				exception_25?.Data.Add("Error at PM38", "");
				GameGeneral.WriteExceptionsToLog(ref exception_25);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		if (dictionary_.ContainsKey("ARC_MOUNT"))
		{
			LuaTable val3 = (LuaTable)dictionary_["ARC_MOUNT"];
			PlatformComponent._Coverage coverage6 = new PlatformComponent._Coverage();
			Conversions.ToString(LuaUtility.ToDictUpper(val3.GetEnumerator())["1"]);
			List<object> list3 = LuaUtility.ToArray(val3.GetEnumerator());
			try
			{
				foreach (object item3 in list3)
				{
					string text10 = Conversions.ToString(item3);
					switch (text10.ToUpper())
					{
					case "PMF1":
						coverage6.PMF1 = true;
						continue;
					case "PS2":
						coverage6.PS2 = true;
						continue;
					case "PMA1":
						coverage6.PMA1 = true;
						continue;
					case "PMF2":
						coverage6.PMF2 = true;
						continue;
					case "SS2":
						coverage6.SS2 = true;
						continue;
					case "PMA2":
						coverage6.PMA2 = true;
						continue;
					case "PB2":
						coverage6.PB2 = true;
						continue;
					case "SS1":
						coverage6.SS1 = true;
						continue;
					case "SMF1":
						coverage6.SMF1 = true;
						continue;
					case "PB1":
						coverage6.PB1 = true;
						continue;
					case "SMA1":
						coverage6.SMA1 = true;
						continue;
					case "SMF2":
						coverage6.SMF2 = true;
						continue;
					case "SMA2":
						coverage6.SMA2 = true;
						continue;
					case "PS1":
						coverage6.PS1 = true;
						continue;
					case "SB2":
						coverage6.SB2 = true;
						continue;
					case "SB1":
						coverage6.SB1 = true;
						continue;
					case "360":
						coverage6.PB1 = true;
						coverage6.PMA1 = true;
						coverage6.PMF1 = true;
						coverage6.PS1 = true;
						coverage6.SB1 = true;
						coverage6.SMA1 = true;
						coverage6.SMF1 = true;
						coverage6.SS1 = true;
						coverage6.PB2 = true;
						coverage6.PMA2 = true;
						coverage6.PMF2 = true;
						coverage6.PS2 = true;
						coverage6.SB2 = true;
						coverage6.SMA2 = true;
						coverage6.SMF2 = true;
						coverage6.SS2 = true;
						break;
					default:
						throw new LuaError("arc_mount中的弧度无效" + text10);
					}
					break;
				}
				coverage3 = coverage6;
			}
			catch (Exception ex26)
			{
				ProjectData.SetProjectError(ex26);
				Exception exception_26 = ex26;
				exception_26?.Data.Add("Error at PM39", "");
				GameGeneral.WriteExceptionsToLog(ref exception_26);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		switch (text)
		{
		case "DELTA":
			if (dictionary_.ContainsKey("FILE"))
			{
				int int_2 = 0;
				FileStream fileStream = new FileStream(GameGeneral.ScenariosRootPath + "\\" + Conversions.ToString(dictionary_["FILE"]), FileMode.Open, FileAccess.Read);
				XmlDocument xmlDocument = new XmlDocument();
				new Dictionary<string, ScenarioObject>();
				string string_;
				using (fileStream)
				{
					try
					{
						xmlDocument.Load(fileStream);
					}
					catch (Exception ex14)
					{
						ProjectData.SetProjectError(ex14);
						Exception exception_14 = ex14;
						exception_14?.Data.Add("Error at PM40", "");
						GameGeneral.WriteExceptionsToLog(ref exception_14);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						string_ = "文件格式不正确，读取失败！";
						throw new LuaError(string_);
					}
					fileStream.Close();
				}
				XmlNode xmlNode = xmlDocument.SelectSingleNode("/ScenarioUnits");
				if (xmlNode == null)
				{
					break;
				}
				XmlNodeList childNodes = xmlNode.ChildNodes;
				string_ = "\r\n" + DateAndTime.Now.ToString() + "Lua更新到" + scenario_0.Title + " Platform list: \r\n  DBID -- Unit name  ----  Class Info  ----  ObjectID";
				StreamWriter streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR log file.txt");
				streamWriter.Write(string_);
				streamWriter.Close();
				IEnumerator enumerator4 = null;
				try
				{
					enumerator4 = childNodes.GetEnumerator();
					while (enumerator4.MoveNext())
					{
						XmlNode xmlNode2 = (XmlNode)enumerator4.Current;
						string text3 = xmlNode2.Name.Split('_')[1];
						string innerText = Misc.StartRequest(xmlNode2.ChildNodes, "#comment").InnerText;
						ActiveUnit activeUnit = scenario_0.ActiveUnits[text3];
						if (activeUnit == null)
						{
							if (innerText.StartsWith(activeUnit_.Name))
							{
								SBR.ApplyDeltaToThisUnit(xmlNode2, activeUnit_, scenario_0, null, null, bool_0: false, ref int_2);
								break;
							}
						}
						else
						{
							if (Operators.CompareString(activeUnit.ObjectID, activeUnit_.ObjectID, TextCompare: false) == 0)
							{
								SBR.ApplyDeltaToThisUnit(xmlNode2, activeUnit_, scenario_0, null, null, bool_0: false, ref int_2);
								break;
							}
							if (innerText.StartsWith(activeUnit_.Name))
							{
								SBR.ApplyDeltaToThisUnit(xmlNode2, activeUnit_, scenario_0, null, null, bool_0: false, ref int_2);
								break;
							}
						}
						if (activeUnit == null)
						{
							string_ = "错误：单元#" + text3 + "在想定中不存在！";
							throw new LuaError(string_);
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
				break;
			}
			throw new LuaError("应用delta时缺少文件");
		case "ADD_SENSOR":
		case "UPDATE_SENSOR_ARC":
		case "REMOVE_SENSOR":
			switch (text)
			{
			case "UPDATE_SENSOR_ARC":
				if (dictionary_.ContainsKey("SENSORID"))
				{
					string text2 = null;
					Sensor sensor5 = null;
					try
					{
						text2 = Conversions.ToString(dictionary_["SENSORID"]);
						Sensor[] array4 = activeUnit_.Sensors_ReadOnly();
						Sensor[] array12 = array4;
						foreach (Sensor sensor6 in array12)
						{
							if (Operators.CompareString(sensor6.ObjectID, text2, TextCompare: false) == 0)
							{
								sensor5 = sensor6;
								break;
							}
						}
						if (sensor5 == null)
						{
							throw new LuaError("找不到传感器" + text2);
						}
					}
					catch (Exception ex10)
					{
						ProjectData.SetProjectError(ex10);
						Exception exception_10 = ex10;
						exception_10?.Data.Add("Error at PM44", "");
						GameGeneral.WriteExceptionsToLog(ref exception_10);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("找不到传感器" + text2);
					}
					try
					{
						if (coverage.HasDefinedArcs && !coverage.Equals(sensor5.Coverage))
						{
							sensor5.Coverage = coverage;
						}
						if (coverage2.HasDefinedArcs && !coverage2.Equals(sensor5.Coverage_Illuminate))
						{
							sensor5.Coverage_Illuminate = coverage2;
						}
					}
					catch (Exception ex11)
					{
						ProjectData.SetProjectError(ex11);
						Exception exception_11 = ex11;
						exception_11?.Data.Add("Error at PM43", "");
						GameGeneral.WriteExceptionsToLog(ref exception_11);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("无法更新" + sensor5.Name);
					}
					break;
				}
				throw new LuaError("未定义要更新的传感器");
			case "REMOVE_SENSOR":
				if (!dictionary_.ContainsKey("SENSORID") && num > 0)
				{
					Sensor[] array3 = activeUnit_.Sensors_ReadOnly();
					Sensor[] array10 = array3;
					foreach (Sensor sensor2 in array10)
					{
						if (sensor2.DBID == num)
						{
							dictionary_["SENSORID"] = sensor2.ObjectID;
							break;
						}
					}
				}
				if (dictionary_.ContainsKey("SENSORID"))
				{
					string text14 = null;
					Sensor sensor3 = null;
					try
					{
						text14 = Conversions.ToString(dictionary_["SENSORID"]);
						Sensor[] array2 = activeUnit_.Sensors_ReadOnly();
						Sensor[] array11 = array2;
						foreach (Sensor sensor4 in array11)
						{
							if (Operators.CompareString(sensor4.ObjectID, text14, TextCompare: false) == 0)
							{
								sensor3 = sensor4;
								break;
							}
						}
						if (sensor3 == null)
						{
							throw new LuaError("找不到传感器" + text14);
						}
					}
					catch (Exception ex8)
					{
						ProjectData.SetProjectError(ex8);
						Exception exception_8 = ex8;
						exception_8?.Data.Add("Error at PM42", "");
						GameGeneral.WriteExceptionsToLog(ref exception_8);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("找不到传感器" + text14);
					}
					try
					{
						activeUnit_.RemoveSensor(sensor3);
					}
					catch (Exception ex9)
					{
						ProjectData.SetProjectError(ex9);
						Exception exception_9 = ex9;
						exception_9?.Data.Add("Error at PM43", "");
						GameGeneral.WriteExceptionsToLog(ref exception_9);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("无法删除" + sensor3.Name);
					}
					break;
				}
				throw new LuaError("未定义要移除的传感器");
			case "ADD_SENSOR":
				try
				{
					int int_ = num;
					SQLiteConnection sqliteConnection_ = activeUnit_.ParentScen.DBConnection;
					Sensor sensor = DBFunctions.GetSensor(int_, ref sqliteConnection_);
					if (sensor != null && coverage != null && coverage2 != null)
					{
						if (coverage.HasDefinedArcs && !coverage.Equals(sensor.Coverage))
						{
							sensor.Coverage = coverage;
						}
						if (coverage2.HasDefinedArcs && !coverage2.Equals(sensor.Coverage_Illuminate))
						{
							sensor.Coverage_Illuminate = coverage2;
						}
						sensor.ParentPlatform = activeUnit_;
						activeUnit_.AddSensor(sensor);
						break;
					}
					if (sensor == null)
					{
						throw new LuaError("传感器未知" + Conversions.ToString(num));
					}
					if (coverage == null)
					{
						throw new LuaError("No detection arcs supplied for sensor " + sensor.Name);
					}
					if (coverage2 == null)
					{
						throw new LuaError("No illumination arcs supplied for sensor " + sensor.Name);
					}
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception exception_7 = ex7;
					exception_7?.Data.Add("Error at PM41", "");
					GameGeneral.WriteExceptionsToLog(ref exception_7);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
				break;
			}
			break;
		case "ADD_MOUNT":
		case "REMOVE_MOUNT":
		case "UPDATE_MOUNT_ARC":
			switch (text)
			{
			case "UPDATE_MOUNT_ARC":
				if (dictionary_.ContainsKey("MOUNTID"))
				{
					string text6 = null;
					Mount mount4 = null;
					try
					{
						text6 = Conversions.ToString(dictionary_["MOUNTID"]);
						foreach (Mount mount5 in activeUnit_.Mounts)
						{
							if (Operators.CompareString(mount5.ObjectID, text6, TextCompare: false) == 0)
							{
								mount4 = mount5;
								break;
							}
						}
						if (mount4 == null)
						{
							throw new LuaError("找不到挂架" + text6);
						}
					}
					catch (Exception ex21)
					{
						ProjectData.SetProjectError(ex21);
						Exception exception_21 = ex21;
						exception_21?.Data.Add("Error at PM48", "");
						GameGeneral.WriteExceptionsToLog(ref exception_21);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("找不到挂架" + text6);
					}
					try
					{
						if (coverage3.HasDefinedArcs && !coverage3.Equals(mount4.Coverage))
						{
							mount4.Coverage = coverage3;
						}
					}
					catch (Exception ex22)
					{
						ProjectData.SetProjectError(ex22);
						Exception exception_22 = ex22;
						exception_22?.Data.Add("Error at PM49", "");
						GameGeneral.WriteExceptionsToLog(ref exception_22);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("无法更新" + mount4.Name);
					}
					break;
				}
				throw new LuaError("未定义要更新的传感器");
			case "REMOVE_MOUNT":
				if (!dictionary_.ContainsKey("MOUNTID") && num > 0)
				{
					foreach (Mount mount6 in activeUnit_.Mounts)
					{
						if (mount6.DBID == num)
						{
							dictionary_["MOUNTID"] = mount6.ObjectID;
							break;
						}
					}
				}
				if (dictionary_.ContainsKey("MOUNTID"))
				{
					string text5 = null;
					Mount mount3 = null;
					try
					{
						text5 = Conversions.ToString(dictionary_["MOUNTID"]);
						foreach (Mount mount7 in activeUnit_.Mounts)
						{
							if (Operators.CompareString(mount7.ObjectID, text5, TextCompare: false) == 0)
							{
								mount3 = mount7;
								break;
							}
						}
						if (mount3 == null)
						{
							throw new LuaError("找不到挂架" + text5);
						}
					}
					catch (Exception ex19)
					{
						ProjectData.SetProjectError(ex19);
						Exception exception_19 = ex19;
						exception_19?.Data.Add("Error at PM46", "");
						GameGeneral.WriteExceptionsToLog(ref exception_19);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("找不到挂架" + text5);
					}
					try
					{
						activeUnit_.Mounts.Remove(mount3);
					}
					catch (Exception ex20)
					{
						ProjectData.SetProjectError(ex20);
						Exception exception_20 = ex20;
						exception_20?.Data.Add("Error at PM47", "");
						GameGeneral.WriteExceptionsToLog(ref exception_20);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("无法删除" + mount3.Name);
					}
					break;
				}
				throw new LuaError("未指定挂架");
			case "ADD_MOUNT":
				try
				{
					Mount mount2 = DBFunctions.GetMount(num, ref scenario_0);
					if (mount2 != null && coverage3 != null)
					{
						if (coverage3.HasDefinedArcs && !coverage3.Equals(mount2.Coverage))
						{
							mount2.Coverage = coverage3;
						}
						mount2.ParentPlatform = activeUnit_;
						if (mount2.Sensors_ReadOnly.Count() > 0)
						{
							Sensor[] array = mount2.Sensors_ReadOnly;
							Sensor[] array7 = array;
							foreach (Sensor sensor7 in array7)
							{
								if (coverage2 != null && coverage2.HasDefinedArcs)
								{
									sensor7.Coverage_Illuminate = coverage2;
								}
								else
								{
									sensor7.Coverage_Illuminate = coverage3;
								}
								sensor7.ParentPlatform = activeUnit_;
							}
						}
						activeUnit_.Mounts.Add(mount2);
					}
					else
					{
						if (mount2 == null)
						{
							throw new LuaError("未知的挂架" + Conversions.ToString(num));
						}
						if (coverage3 == null)
						{
							throw new LuaError("No targeting arcs supplied for mount " + mount2.Name);
						}
					}
				}
				catch (Exception ex18)
				{
					ProjectData.SetProjectError(ex18);
					Exception exception_18 = ex18;
					exception_18?.Data.Add("Error at PM 45", "");
					GameGeneral.WriteExceptionsToLog(ref exception_18);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
				break;
			}
			break;
		case "ADD_FUEL":
		case "REMOVE_FUEL":
		{
			if (!dictionary_.ContainsKey("FUEL"))
			{
				break;
			}
			List<object> list4 = LuaUtility.ToArray(((LuaTable)dictionary_["FUEL"]).GetEnumerator());
			if (activeUnit_.IsFixedFacility)
			{
				try
				{
					foreach (object item4 in list4)
					{
						object objectValue = RuntimeHelpers.GetObjectValue(item4);
						if (!(objectValue is LuaTable))
						{
							continue;
						}
						Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator());
						if (dictionary.ContainsKey("1") & dictionary.ContainsKey("2"))
						{
							string value = Conversions.ToString(dictionary["1"]);
							int result = int.MaxValue;
							if (int.TryParse(Conversions.ToString(dictionary["2"]), out result))
							{
								if (Enum.TryParse<FuelRec._FuelType>(value, ignoreCase: true, out Local_e) & Enum.IsDefined(typeof(FuelRec._FuelType), Local_e))
								{
									FuelRec fuelRec = activeUnit_.Fuel_ReadOnly.FirstOrDefault((FuelRec F) => F.FuelType == Local_e);
									if (Operators.CompareString(text, "ADD_FUEL", TextCompare: false) == 0 && fuelRec == null)
									{
										FuelRec fuelRec2 = new FuelRec(result, (short)Local_e);
										fuelRec2.CurrentQuantity = fuelRec2.MaxQuantity;
										activeUnit_.AddFuelRec(fuelRec2);
										continue;
									}
									if (Operators.CompareString(text, "REMOVE_FUEL", TextCompare: false) == 0 && fuelRec != null)
									{
										activeUnit_.RemoveFuelRec(fuelRec);
										continue;
									}
									throw new LuaError("Fuel type " + Local_e.ToString() + ((Operators.CompareString(text, "ADD_FUEL", TextCompare: false) == 0) ? " exists" : " does not exist") + " on unit.");
								}
								throw new LuaError("燃油类型错误" + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue)));
							}
							throw new LuaError("金额错误" + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue)));
						}
						throw new LuaError("Error in table " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue)));
					}
				}
				catch (Exception ex13)
				{
					ProjectData.SetProjectError(ex13);
					Exception exception_13 = ex13;
					exception_13?.Data.Add("Error at PM60", "");
					GameGeneral.WriteExceptionsToLog(ref exception_13);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
				break;
			}
			throw new LuaError("Can't modify Fuel source on this type of unit.");
		}
		case "REMOVE_COMMS":
		case "ADD_COMMS":
			if (Operators.CompareString(text, "ADD_COMMS", TextCompare: false) == 0)
			{
				try
				{
					CommDevice commDevice = DBFunctions.GetCommDevice(num, ref activeUnit_);
					if (commDevice == null)
					{
						throw new LuaError("未知的通讯" + Conversions.ToString(num));
					}
					commDevice.ParentPlatform = activeUnit_;
					activeUnit_.AddCommDevice(commDevice);
				}
				catch (Exception ex15)
				{
					ProjectData.SetProjectError(ex15);
					Exception exception_15 = ex15;
					exception_15?.Data.Add("Error at PM55", "");
					GameGeneral.WriteExceptionsToLog(ref exception_15);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("未知的通讯" + Conversions.ToString(num));
				}
			}
			else
			{
				if (Operators.CompareString(text, "REMOVE_COMMS", TextCompare: false) != 0)
				{
					break;
				}
				if (!dictionary_.ContainsKey("COMMSID") && num > 0)
				{
					CommDevice[] comms_ReadOnly2 = activeUnit_.Comms_ReadOnly;
					CommDevice[] array8 = comms_ReadOnly2;
					foreach (CommDevice commDevice2 in array8)
					{
						if (commDevice2.DBID == num)
						{
							dictionary_["COMMSID"] = commDevice2.ObjectID;
							break;
						}
					}
				}
				if (!dictionary_.ContainsKey("COMMSID"))
				{
					throw new LuaError("未定义要移除的通讯设备");
				}
				string text4 = null;
				CommDevice commDevice3 = null;
				try
				{
					text4 = Conversions.ToString(dictionary_["COMMSID"]);
					CommDevice[] comms_ReadOnly = activeUnit_.Comms_ReadOnly;
					CommDevice[] array9 = comms_ReadOnly;
					foreach (CommDevice commDevice4 in array9)
					{
						if (Operators.CompareString(commDevice4.ObjectID, text4, TextCompare: false) == 0)
						{
							commDevice3 = commDevice4;
							break;
						}
					}
					if (commDevice3 == null)
					{
						throw new LuaError("找不到通讯设备" + text4);
					}
				}
				catch (Exception ex16)
				{
					ProjectData.SetProjectError(ex16);
					Exception exception_16 = ex16;
					exception_16?.Data.Add("Error at PM55", "");
					GameGeneral.WriteExceptionsToLog(ref exception_16);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到通讯设备" + text4);
				}
				try
				{
					activeUnit_.RemoveCommDevice(commDevice3);
				}
				catch (Exception ex17)
				{
					ProjectData.SetProjectError(ex17);
					Exception exception_17 = ex17;
					exception_17?.Data.Add("Error at PM56", "");
					GameGeneral.WriteExceptionsToLog(ref exception_17);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("无法删除" + commDevice3.Name);
				}
			}
			break;
		case "REMOVE_WEAPON":
		case "ADD_WEAPON":
		{
			Mount mount = null;
			if (dictionary_.ContainsKey("MOUNTID"))
			{
				string text12 = null;
				try
				{
					text12 = Conversions.ToString(dictionary_["MOUNTID"]);
					foreach (Mount mount8 in activeUnit_.Mounts)
					{
						if (Operators.CompareString(mount8.ObjectID, text12, TextCompare: false) == 0)
						{
							mount = mount8;
							break;
						}
					}
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at PM50", "");
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到要移除的武器挂架" + text12);
				}
				if (mount == null)
				{
					throw new LuaError("找不到要移除的武器挂架" + text12);
				}
			}
			if (Operators.CompareString(text, "ADD_WEAPON", TextCompare: false) == 0)
			{
				try
				{
					WeaponRec weaponRec = DBFunctions.GetWeaponRec(num, scenario_0);
					if (weaponRec == null)
					{
						throw new LuaError("未知的武器记录" + Conversions.ToString(num));
					}
					mount.MountWeapons.Add(weaponRec);
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception exception_3 = ex3;
					exception_3?.Data.Add("Error at PM51", "");
					GameGeneral.WriteExceptionsToLog(ref exception_3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("未知的武器记录" + Conversions.ToString(num));
				}
			}
			else
			{
				if (Operators.CompareString(text, "REMOVE_WEAPON", TextCompare: false) != 0)
				{
					break;
				}
				if (!dictionary_.ContainsKey("WEAPONID"))
				{
					throw new LuaError("未指定挂架");
				}
				string text13 = null;
				WeaponRec weaponRec2 = null;
				try
				{
					text13 = Conversions.ToString(dictionary_["WEAPONID"]);
					foreach (WeaponRec mountWeapon in mount.MountWeapons)
					{
						if (Operators.CompareString(mountWeapon.ObjectID, text13, TextCompare: false) == 0)
						{
							weaponRec2 = mountWeapon;
							break;
						}
					}
					if (weaponRec2 == null)
					{
						throw new LuaError("找不到武器" + text13 + "在挂架" + mount.ObjectID);
					}
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception exception_4 = ex4;
					exception_4?.Data.Add("Error at PM52", "");
					GameGeneral.WriteExceptionsToLog(ref exception_4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到武器" + text13 + "在挂架" + mount.ObjectID);
				}
				try
				{
					try
					{
						mount.MountWeapons.Remove(weaponRec2);
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception exception_5 = ex5;
						exception_5?.Data.Add("Error at PM53", "");
						GameGeneral.WriteExceptionsToLog(ref exception_5);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("无法删除" + weaponRec2.Name);
					}
				}
				catch (Exception ex6)
				{
					ProjectData.SetProjectError(ex6);
					Exception exception_6 = ex6;
					exception_6?.Data.Add("Error at PM54", "");
					GameGeneral.WriteExceptionsToLog(ref exception_6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("无法删除" + weaponRec2.Name);
				}
			}
			break;
		}
		case "ADD_MAGAZINE_ONLY":
		case "REMOVE_MAGAZINE":
		case "ADD_MAGAZINE":
			switch (text)
			{
			case "REMOVE_MAGAZINE":
				if (!dictionary_.ContainsKey("MAGID") && num > 0)
				{
					Magazine[] sharedMagazines2 = activeUnit_.SharedMagazines;
					Magazine[] array5 = sharedMagazines2;
					foreach (Magazine magazine2 in array5)
					{
						if (magazine2.DBID == num)
						{
							dictionary_["MAGID"] = magazine2.ObjectID;
							break;
						}
					}
				}
				if (dictionary_.ContainsKey("MAGID"))
				{
					string text11 = null;
					Magazine magazine3 = null;
					try
					{
						text11 = Conversions.ToString(dictionary_["MAGID"]);
						Magazine[] sharedMagazines = activeUnit_.SharedMagazines;
						Magazine[] array6 = sharedMagazines;
						foreach (Magazine magazine4 in array6)
						{
							if (Operators.CompareString(magazine4.ObjectID, text11, TextCompare: false) == 0)
							{
								magazine3 = magazine4;
								break;
							}
						}
						if (magazine3 == null)
						{
							throw new LuaError("Can't find magazine " + text11);
						}
					}
					catch (Exception ex28)
					{
						ProjectData.SetProjectError(ex28);
						Exception exception_28 = ex28;
						exception_28?.Data.Add("Error at PM58", "");
						GameGeneral.WriteExceptionsToLog(ref exception_28);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("Can't find magazine " + text11);
					}
					try
					{
						((Platform)activeUnit_).RemoveSharedMagazine(magazine3);
					}
					catch (Exception ex29)
					{
						ProjectData.SetProjectError(ex29);
						Exception exception_29 = ex29;
						exception_29?.Data.Add("Error at PM59", "");
						GameGeneral.WriteExceptionsToLog(ref exception_29);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("无法删除" + magazine3.Name);
					}
					break;
				}
				throw new LuaError("Magazine to remove not defined");
			case "ADD_MAGAZINE":
			case "ADD_MAGAZINE_ONLY":
				try
				{
					bool bool_ = true;
					if (Operators.CompareString(text, "ADD_MAGAZINE_ONLY", TextCompare: false) == 0)
					{
						bool_ = false;
					}
					Magazine magazine = DBFunctions.GetMagazine(num, ref scenario_0, bool_);
					if (magazine == null)
					{
						throw new LuaError("Unknown magazine " + Conversions.ToString(num));
					}
					magazine.ParentPlatform = activeUnit_;
					((Platform)activeUnit_).AddSharedMagazine(magazine);
				}
				catch (Exception ex27)
				{
					ProjectData.SetProjectError(ex27);
					Exception exception_27 = ex27;
					exception_27?.Data.Add("Error at PM57", "");
					GameGeneral.WriteExceptionsToLog(ref exception_27);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Unknown magazine " + Conversions.ToString(num));
				}
				break;
			}
			break;
		}
		if (dictionary_.ContainsKey("FUEL"))
		{
			dictionary_.Remove("FUEL");
		}
		LuaTable luaTable_ = LuaSandBox.Singleton().CreateTable();
		LuaUtility.FromDict(dictionary_, luaTable_);
		return ScenEdit_SetUnit(luaTable_, scenario_0);
	}

	public static LuaWrapper_ActiveUnit_SE ScenEdit_UpdateUnitCargo(LuaTable luaTable_0, Scenario scenario_0)
	{
		ActiveUnit activeUnit = null;
		string left = null;
		ICargoHost icargoHost_ = (ICargoHost)activeUnit;
		Cargo cargo = null;
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		List<Cargo> list = new List<Cargo>();
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("GUID"))
		{
			string text = null;
			try
			{
				text = Conversions.ToString(dictionary_["GUID"]);
				activeUnit = scenario_0.ActiveUnits[text];
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM61", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("找不到guid" + text);
			}
		}
		if (dictionary_.ContainsKey("MODE"))
		{
			try
			{
				left = Conversions.ToString(dictionary_["MODE"]).ToUpper();
				if (Operators.CompareString(left, "ADD_CARGO", TextCompare: false) != 0 && Operators.CompareString(left, "REMOVE_CARGO", TextCompare: false) != 0)
				{
					throw new LuaError("功能应该是'add_cargo'，'remove_cargo'");
				}
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM62", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		if (dictionary_.ContainsKey("DBID"))
		{
			try
			{
				Conversions.ToInteger(dictionary_["DBID"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at PM63", "");
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("缺少dbid");
			}
		}
		if (dictionary_.ContainsKey("CARGO"))
		{
			try
			{
				val = (LuaTable)dictionary_["CARGO"];
			}
			catch (Exception ex4)
			{
				ProjectData.SetProjectError(ex4);
				Exception exception_4 = ex4;
				exception_4?.Data.Add("Error at PM64", "");
				GameGeneral.WriteExceptionsToLog(ref exception_4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("货物清单出错");
			}
		}
		if (activeUnit.IsGroup)
		{
			throw new LuaError("Group can't host cargo");
		}
		new List<object>();
		if (Information.IsNothing(val))
		{
			throw new LuaError("缺少货物清单");
		}
		List<object> list2 = LuaUtility.ToArray(val.GetEnumerator());
		if (list2.Count == 0)
		{
			throw new LuaError("缺少货物清单");
		}
		foreach (object item in list2)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(item);
			int num = 0;
			int Local_moveDBID = 0;
			string Local_moveGUID = null;
			int Local_moveCargoType = 1;
			if (objectValue is LuaTable)
			{
				List<object> list3 = LuaUtility.ToArray(((LuaTable)objectValue).GetEnumerator());
				if (list3.Count == 1)
				{
					Local_moveDBID = Conversions.ToInteger(list3[0]);
					num = 1;
				}
				else if (list3.Count == 3)
				{
					Local_moveCargoType = Conversions.ToInteger(list3[2]);
					Local_moveDBID = Conversions.ToInteger(list3[1]);
					num = Conversions.ToInteger(list3[0]);
				}
				else
				{
					Local_moveDBID = Conversions.ToInteger(list3[1]);
					num = Conversions.ToInteger(list3[0]);
				}
			}
			else
			{
				Local_moveGUID = Conversions.ToString(objectValue);
				num = 1;
			}
			if (num < 1 || (Local_moveDBID < 1 && Information.IsNothing(Local_moveGUID)))
			{
				continue;
			}
			IEnumerator<Cargo> enumerator2;
			if (Information.IsNothing(Local_moveGUID))
			{
				enumerator2 = (from C in activeUnit.OnboardCargo
					where C.CurrentType == (Cargo.CargoObjectType)Local_moveCargoType
					where C.CargoObjectDBID == Local_moveDBID
					select (C)).GetEnumerator();
			}
			else
			{
				enumerator2 = (from C in activeUnit.OnboardCargo
					where Operators.CompareString(C.CargoObjectID, Local_moveGUID, TextCompare: false) == 0
					select (C)).GetEnumerator();
				enumerator2.MoveNext();
			}
			for (int num2 = num; num2 > 0; num2--)
			{
				if (Information.IsNothing(Local_moveGUID))
				{
					if (enumerator2.MoveNext() & (Operators.CompareString(left, "REMOVE_CARGO", TextCompare: false) == 0))
					{
						list.Add(enumerator2.Current);
					}
					else if (Local_moveCargoType == 4)
					{
						CargoContainer cargoContainer = DBFunctions.GetCargoContainer(Local_moveDBID, ref scenario_0);
						cargo = new Cargo(activeUnit, cargoContainer, icargoHost_);
						list.Add(cargo);
					}
					else
					{
						cargo = Cargo.CreateNewCargo((Cargo.CargoObjectType)Local_moveCargoType, Local_moveDBID, activeUnit, activeUnit.ParentScen);
						list.Add(cargo);
					}
				}
				else
				{
					if (Operators.CompareString(left, "REMOVE_CARGO", TextCompare: false) == 0)
					{
						list.Add(enumerator2.Current);
					}
					num2 = 1;
				}
			}
		}
		if (list.Count == 0)
		{
			throw new LuaError("没有货物清单行动");
		}
		if (Operators.CompareString(left, "ADD_CARGO", TextCompare: false) == 0)
		{
			try
			{
				ICargoHost obj = (ICargoHost)activeUnit;
				double num3 = 0.0;
				double num4 = 0.0;
				double num5 = 0.0;
				CargoType cargoType = CargoType.NoCargo;
				num3 = CargoHostHelper.GetAvailableMass(obj, activeUnit.OnboardCargo);
				num4 = CargoHostHelper.GetAvailableArea(obj, activeUnit.OnboardCargo);
				num5 = CargoHostHelper.GetAvailableCrewSpace(obj, activeUnit.OnboardCargo);
				cargoType = obj.GetCargo_Type();
				foreach (Cargo item2 in list)
				{
					if (item2.RequiredCargoType <= cargoType && num3 >= (double)item2.RequiredMass && num4 >= (double)item2.RequiredArea && num5 >= (double)item2.RequiredCrewSpace)
					{
						num3 -= (double)item2.RequiredMass;
						num4 -= (double)item2.RequiredArea;
						num5 -= (double)item2.RequiredCrewSpace;
						ArrayExtensions.Add(ref activeUnit.OnboardCargo, item2);
						if (item2.CargoObjectActiveUnit != null)
						{
							item2.CargoObjectActiveUnit.DockingOps.LoadIntoCargo(activeUnit);
						}
					}
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception exception_5 = ex5;
				exception_5?.Data.Add("Error at PM65", "");
				GameGeneral.WriteExceptionsToLog(ref exception_5);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Error adding cargo.");
			}
		}
		else if (Operators.CompareString(left, "REMOVE_CARGO", TextCompare: false) == 0)
		{
			try
			{
				foreach (Cargo item3 in list)
				{
					if (activeUnit.OnboardCargo.Contains(item3))
					{
						ArrayExtensions.Remove(ref activeUnit.OnboardCargo, item3);
						if (item3.CargoObjectActiveUnit != null)
						{
							item3.CargoObjectActiveUnit.DockingOps.UnloadFromCargo();
						}
					}
				}
			}
			catch (Exception ex6)
			{
				ProjectData.SetProjectError(ex6);
				Exception exception_6 = ex6;
				exception_6?.Data.Add("Error at PM66", "");
				GameGeneral.WriteExceptionsToLog(ref exception_6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Error removing cargo.");
			}
		}
		LuaTable luaTable_ = LuaSandBox.Singleton().CreateTable();
		LuaUtility.FromDict(dictionary_, luaTable_);
		return ScenEdit_SetUnit(luaTable_, scenario_0);
	}

	public static LuaWrapper_ActiveUnit_SE ScenEdit_GetUnit(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		ActiveUnit activeUnit = null;
		Side side = null;
		string text3 = null;
		string text2 = null;
		string text4 = null;
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("GUID"))
		{
			try
			{
				text4 = Conversions.ToString(dictionary_["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM67", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid必须是一个字符串");
			}
			try
			{
				activeUnit = scenario_0.ActiveUnits[text4];
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM68", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				text3 = "找不到guid" + text4;
				ProjectData.ClearProjectError();
			}
		}
		else if (dictionary_.ContainsKey("UNITNAME"))
		{
			try
			{
				text2 = Conversions.ToString(dictionary_["UNITNAME"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at PM69", "");
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("名称必须是一个字符串");
			}
			if (dictionary_.ContainsKey("SIDE"))
			{
				string text5;
				try
				{
					text5 = Conversions.ToString(dictionary_["SIDE"]);
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception exception_4 = ex4;
					exception_4?.Data.Add("Error at PM70", "");
					GameGeneral.WriteExceptionsToLog(ref exception_4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("分方必须是一个字符串");
				}
				try
				{
					side = LuaUtility.QuerySide(dictionary_, scenario_0);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception exception_5 = ex5;
					exception_5?.Data.Add("Error at PM71", "");
					GameGeneral.WriteExceptionsToLog(ref exception_5);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					text3 = "找不到分方'" + text5 + "'";
					ProjectData.ClearProjectError();
				}
				try
				{
					activeUnit = side.Units.First((ActiveUnit s) => string.Equals(s.Name, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text2, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex6)
				{
					ProjectData.SetProjectError(ex6);
					Exception exception_6 = ex6;
					exception_6?.Data.Add("Error at PM72", "");
					GameGeneral.WriteExceptionsToLog(ref exception_6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					text3 = "找不到单元'" + text2 + "' 分方 '" + text5 + "'";
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				try
				{
					activeUnit = scenario_0.ActiveUnits_List.First((ActiveUnit s) => string.Equals(s.Name, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text2, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception exception_7 = ex7;
					exception_7?.Data.Add("Error at PM73", "");
					GameGeneral.WriteExceptionsToLog(ref exception_7);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					text3 = "找不到单元'" + text2 + "'";
					ProjectData.ClearProjectError();
				}
			}
		}
		if (activeUnit == null)
		{
			if (LuaSandBox.Singleton().RunInteractive && text3 != null)
			{
				throw new LuaError(text3);
			}
			if (text4 == null && text2 == null)
			{
				throw new LuaError("需要定义名称或Guid来标识单元。最好是Guid或Side＆Name。");
			}
			return null;
		}
		return new LuaWrapper_ActiveUnit_SE(activeUnit, scenario_0);
	}

	public static string ScenEdit_GetDBFileHash(LuaTable luaTable_0)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		if (dictionary.ContainsKey("FILENAME"))
		{
			string text = Conversions.ToString(dictionary["FILENAME"]);
			if (!FileExistsNative.FileExistsFast(text))
			{
				throw new LuaError("File: " + text + " does not exist");
			}
			return Crypto.GetFileHashFromFilename(text);
		}
		throw new LuaError("Mandatory paramater 'Filename' is not provided");
	}

	public static LuaTable ScenEdit_GetSensorData(int int_0, Scenario scenario_0)
	{
		throw new LuaError("ERROR - This scenario or script uses ScenEdit_GetSensorData which is a PRO edition feature.");
	}

	public static void ScenEdit_ClearAllMagazines(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		ActiveUnit activeUnit = null;
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dictionary_["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM75", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid必须是一个字符串");
			}
			try
			{
				activeUnit = scenario_0.ActiveUnits[text];
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM76", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("找不到guid" + text);
			}
		}
		else if (dictionary_.ContainsKey("UNITNAME"))
		{
			string Local_Name = null;
			try
			{
				Local_Name = Conversions.ToString(dictionary_["UNITNAME"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at PM77", "");
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("名称必须是一个字符串");
			}
			if (dictionary_.ContainsKey("SIDE"))
			{
				string text2;
				try
				{
					text2 = Conversions.ToString(dictionary_["SIDE"]);
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception exception_4 = ex4;
					exception_4?.Data.Add("Error at PM78", "");
					GameGeneral.WriteExceptionsToLog(ref exception_4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("分方必须是一个字符串");
				}
				Side side;
				try
				{
					side = LuaUtility.QuerySide(dictionary_, scenario_0);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception exception_5 = ex5;
					exception_5?.Data.Add("Error at PM79", "");
					GameGeneral.WriteExceptionsToLog(ref exception_5);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到分方'" + text2 + "'");
				}
				try
				{
					activeUnit = side.Units.First((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex6)
				{
					ProjectData.SetProjectError(ex6);
					Exception exception_6 = ex6;
					exception_6?.Data.Add("Error at PM80", "");
					GameGeneral.WriteExceptionsToLog(ref exception_6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + Local_Name + "' 分方 '" + text2 + "'");
				}
			}
			else
			{
				try
				{
					activeUnit = scenario_0.ActiveUnits_List.First((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception exception_7 = ex7;
					exception_7?.Data.Add("Error at PM81", "");
					GameGeneral.WriteExceptionsToLog(ref exception_7);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + Local_Name + "'");
				}
			}
		}
		if (activeUnit == null)
		{
			throw new LuaError("需要定义名称或Guid来标识单元。最好是Guid或Side＆Name。");
		}
		List<ActiveUnit> list = new List<ActiveUnit>();
		list.Add(activeUnit);
		if (activeUnit is Group)
		{
			foreach (KeyValuePair<string, ActiveUnit> unit in ((Group)activeUnit).Units)
			{
				list.Add(unit.Value);
			}
		}
		foreach (ActiveUnit item in list)
		{
			Magazine[] totalMagazines = item.TotalMagazines;
			for (int i = 0; i < totalMagazines.Length; i++)
			{
				foreach (WeaponRec weapon in totalMagazines[i].Weapons)
				{
					weapon.CurrentLoad = 0;
				}
			}
		}
	}

	public static void ScenEdit_ClearAllAircraft(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		ActiveUnit activeUnit = null;
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dictionary_["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM82", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid必须是一个字符串");
			}
			try
			{
				activeUnit = scenario_0.ActiveUnits[text];
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM83", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("找不到guid" + text);
			}
		}
		else if (dictionary_.ContainsKey("UNITNAME"))
		{
			string Local_Name = null;
			try
			{
				Local_Name = Conversions.ToString(dictionary_["UNITNAME"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at PM84", "");
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("名称必须是一个字符串");
			}
			if (dictionary_.ContainsKey("SIDE"))
			{
				string text2;
				try
				{
					text2 = Conversions.ToString(dictionary_["SIDE"]);
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception exception_4 = ex4;
					exception_4?.Data.Add("Error at PM85", "");
					GameGeneral.WriteExceptionsToLog(ref exception_4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("分方必须是一个字符串");
				}
				Side side;
				try
				{
					side = LuaUtility.QuerySide(dictionary_, scenario_0);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception exception_5 = ex5;
					exception_5?.Data.Add("Error at PM86", "");
					GameGeneral.WriteExceptionsToLog(ref exception_5);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到分方'" + text2 + "'");
				}
				try
				{
					activeUnit = side.Units.First((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex6)
				{
					ProjectData.SetProjectError(ex6);
					Exception exception_6 = ex6;
					exception_6?.Data.Add("Error at PM87", "");
					GameGeneral.WriteExceptionsToLog(ref exception_6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + Local_Name + "' 分方 '" + text2 + "'");
				}
			}
			else
			{
				try
				{
					activeUnit = scenario_0.ActiveUnits_List.First((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception exception_7 = ex7;
					exception_7?.Data.Add("Error at PM88", "");
					GameGeneral.WriteExceptionsToLog(ref exception_7);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + Local_Name + "'");
				}
			}
		}
		if (activeUnit == null)
		{
			throw new LuaError("需要定义名称或Guid来标识单元。最好是Guid或Side＆Name。");
		}
		List<ActiveUnit> list = new List<ActiveUnit>();
		list.Add(activeUnit);
		if (activeUnit is Group)
		{
			foreach (KeyValuePair<string, ActiveUnit> unit in ((Group)activeUnit).Units)
			{
				list.Add(unit.Value);
			}
		}
		foreach (ActiveUnit item in list)
		{
			foreach (Aircraft item2 in item.AirOps.EmbarkedAircraft_ReadOnly.ToList())
			{
				scenario_0.DeleteUnitImmediately(item2.ObjectID, bool_0: true, "Script action (clear all aircraft)");
			}
		}
	}

	public static LuaWrapper_Contact ScenEdit_GetContact(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		Contact contact = null;
		Side side = null;
		string text = null;
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("GUID"))
		{
			try
			{
				text = Conversions.ToString(dictionary_["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM89", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid必须是一个字符串");
			}
		}
		else if (dictionary_.ContainsKey("UNITNAME"))
		{
			try
			{
				text = Conversions.ToString(dictionary_["UNITNAME"]);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM90", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("名称必须是一个字符串");
			}
		}
		if (dictionary_.ContainsKey("SIDE"))
		{
			string text2;
			try
			{
				text2 = Conversions.ToString(dictionary_["SIDE"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at PM91", "");
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("分方必须是一个字符串");
			}
			try
			{
				side = LuaUtility.QuerySide(dictionary_, scenario_0);
			}
			catch (Exception ex4)
			{
				ProjectData.SetProjectError(ex4);
				Exception exception_4 = ex4;
				exception_4?.Data.Add("Error at PM92", "");
				GameGeneral.WriteExceptionsToLog(ref exception_4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("找不到分方'" + text2 + "'");
			}
		}
		contact = ValidateContactBySide(text, side);
		if (contact == null)
		{
			foreach (string key in side.m_InfoFacade.Keys)
			{
				Contact contact2 = side.m_InfoFacade[key];
				if (string.Equals(contact2.Name, text, StringComparison.OrdinalIgnoreCase) || string.Equals(contact2.ObjectID, text, StringComparison.OrdinalIgnoreCase))
				{
					contact = contact2;
					break;
				}
			}
			if (contact == null)
			{
				foreach (string key2 in side.m_HelperFacade.Keys)
				{
					Contact contact3 = side.m_HelperFacade[key2];
					if (string.Equals(contact3.Name, text, StringComparison.OrdinalIgnoreCase) || string.Equals(contact3.ObjectID, text, StringComparison.OrdinalIgnoreCase))
					{
						contact = contact3;
						break;
					}
				}
			}
		}
		if (contact == null)
		{
			throw new LuaError("需要定义分方和Guid来识别目标。");
		}
		return new LuaWrapper_Contact(contact, scenario_0, side);
	}

	public static LuaWrapper_ActiveUnit_SE ScenEdit_SetUnit(LuaTable luaTable_0, Scenario scenario_0)
	{
		FuelRec._FuelType Local_e = (FuelRec._FuelType)0;
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		ActiveUnit activeUnit_ = null;
		Side side = null;
		string string_ = null;
		bool flag = false;
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dictionary_["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM93", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid必须是一个字符串");
			}
			try
			{
				activeUnit_ = scenario_0.ActiveUnits[text];
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at PM94", "");
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return null;
			}
			if (activeUnit_ == null)
			{
				return null;
			}
			dictionary_["SIDE"] = activeUnit_.GetUnitSide().Name;
			dictionary_["UNITNAME"] = activeUnit_.Name;
		}
		else if (dictionary_.ContainsKey("UNITNAME"))
		{
			string Local_Name = null;
			try
			{
				Local_Name = Conversions.ToString(dictionary_["UNITNAME"]);
			}
			catch (Exception ex4)
			{
				ProjectData.SetProjectError(ex4);
				Exception exception_4 = ex4;
				exception_4?.Data.Add("Error at PM95", "");
				GameGeneral.WriteExceptionsToLog(ref exception_4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("名称必须是一个字符串");
			}
			if (dictionary_.ContainsKey("SIDE"))
			{
				string text2;
				try
				{
					text2 = Conversions.ToString(dictionary_["SIDE"]);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception exception_5 = ex5;
					exception_5?.Data.Add("Error at PM96", "");
					GameGeneral.WriteExceptionsToLog(ref exception_5);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("分方必须是一个字符串");
				}
				try
				{
					side = LuaUtility.QuerySide(dictionary_, scenario_0);
				}
				catch (Exception ex6)
				{
					ProjectData.SetProjectError(ex6);
					Exception exception_6 = ex6;
					exception_6?.Data.Add("Error at PM97", "");
					GameGeneral.WriteExceptionsToLog(ref exception_6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到分方'" + text2 + "'");
				}
				try
				{
					activeUnit_ = side.Units.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_Name, StringComparison.OrdinalIgnoreCase));
					if (activeUnit_ == null)
					{
						throw new Exception();
					}
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception exception_7 = ex7;
					exception_7?.Data.Add("Error at PM98", "");
					GameGeneral.WriteExceptionsToLog(ref exception_7);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + Local_Name + "' 分方 '" + text2 + "'");
				}
				dictionary_["GUID"] = activeUnit_.ObjectID;
			}
			else
			{
				try
				{
					activeUnit_ = scenario_0.ActiveUnits_List.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex8)
				{
					ProjectData.SetProjectError(ex8);
					Exception exception_8 = ex8;
					exception_8?.Data.Add("Error at PM99", "");
					GameGeneral.WriteExceptionsToLog(ref exception_8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + Local_Name + "'");
				}
				dictionary_["GUID"] = activeUnit_.ObjectID;
				dictionary_["SIDE"] = activeUnit_.GetUnitSide().Name;
			}
		}
		if (activeUnit_ == null)
		{
			throw new LuaError("需要定义名称或Guid来标识单元。最好是Guid或Side＆Name。");
		}
		if (side == null)
		{
			side = LuaUtility.QuerySide(dictionary_, scenario_0);
		}
		dictionary_["TYPE"] = activeUnit_.UnitType.ToString();
		if (dictionary_.ContainsKey("NEWNAME"))
		{
			string text3 = Conversions.ToString(dictionary_["NEWNAME"]);
			if (Operators.CompareString(activeUnit_.Name, text3, TextCompare: false) != 0)
			{
				activeUnit_.Name = text3;
			}
		}
		if (!activeUnit_.IsGroup)
		{
			if (dictionary_.ContainsKey("GROUP"))
			{
				Group group = LuaUtility.QueryGroup(dictionary_, side, scenario_0);
				if (group == null)
				{
					List<ActiveUnit> list = new List<ActiveUnit>();
					list.Add(activeUnit_);
					ActiveUnit activeUnit;
					Side side_ = (activeUnit = activeUnit_).GetUnitSide();
					Group group2 = new Group(ref scenario_0, ref side_, list);
					activeUnit.SetUnitSide(bool_0: false, side_);
					group = group2;
					group.Name = Conversions.ToString(dictionary_["GROUP"]);
					activeUnit_.SetParentGroup(bool_0: false, group);
				}
				else if (group != activeUnit_.GetParentGroup())
				{
					activeUnit_.SetParentGroup(bool_0: false, group);
				}
			}
			else if (activeUnit_.GetParentGroup() != null)
			{
				dictionary_["GROUP"] = activeUnit_.GetParentGroup().Name;
			}
		}
		if (dictionary_.ContainsKey("MISSION"))
		{
			object objectValue = RuntimeHelpers.GetObjectValue(dictionary_["MISSION"]);
			if (objectValue is string)
			{
				try
				{
					ScenEdit_AssignUnitToMission(activeUnit_.ObjectID, Conversions.ToString(objectValue), scenario_0, null, bool_0: false, bool_1: false);
				}
				catch (Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					Exception exception_9 = ex9;
					exception_9?.Data.Add("Error at PM100", "");
					GameGeneral.WriteExceptionsToLog(ref exception_9);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError(exception_9.GetType().Name + " " + exception_9.Message);
				}
			}
		}
		else if (activeUnit_.AssignedMissionOrPackage() != null)
		{
			dictionary_["MISSION"] = activeUnit_.AssignedMissionOrPackage().Name;
		}
		if (dictionary_.ContainsKey("COURSE"))
		{
			LuaTable val = (LuaTable)dictionary_["COURSE"];
			activeUnit_.Navigator.ClearPlottedCourse();
			foreach (object item in LuaUtility.ToArray(val.GetEnumerator()))
			{
				object objectValue2 = RuntimeHelpers.GetObjectValue(item);
				if (objectValue2 is LuaTable)
				{
					Dictionary<string, object> dictionary_2 = LuaUtility.ToDictUpper(((LuaTable)objectValue2).GetEnumerator());
					double? num = LuaUtility.QueryLongitude(dictionary_2);
					double? num12 = LuaUtility.QueryLatitude(dictionary_2);
					if (!(!num.HasValue | !num.HasValue))
					{
						double? num19 = num;
						bool? flag4 = (num19.HasValue ? new bool?(num19.GetValueOrDefault() == 0.0) : null);
						num19 = num;
						bool? flag5 = (num19.HasValue ? new bool?(num19.GetValueOrDefault() == 0.0) : null);
						(flag4.GetValueOrDefault() ? new bool?(true) : (flag5.HasValue ? (flag5.GetValueOrDefault() | flag4) : null)).GetValueOrDefault();
						activeUnit_.Navigator.AddWaypoint(num12.Value, num.Value, 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
						continue;
					}
					throw new LuaError("路径对象" + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue2)) + "需要纬度或经度。");
				}
				throw new LuaError("Error at " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue2)) + "在ScenEdit_SetUnit中。");
			}
		}
		if (dictionary_.ContainsKey("SPEED") & dictionary_.ContainsKey("THROTTLE"))
		{
			throw new LuaError("使用SPEED或THROTTLE。");
		}
		if (dictionary_.ContainsKey("FORCESPEED"))
		{
			flag = Conversions.ToBoolean(dictionary_["FORCESPEED"]);
		}
		if (dictionary_.ContainsKey("SPEED"))
		{
			float num20 = Conversions.ToSingle(dictionary_["SPEED"]);
			if (num20 <= activeUnit_.MaxSpeed || flag)
			{
				if (num20 < 0f)
				{
					num20 = 0f;
				}
				else if (flag)
				{
					activeUnit_.SetThrottle(ActiveUnit.Throttle.External);
				}
			}
			else
			{
				num20 = activeUnit_.MaxSpeed;
			}
			activeUnit_.CurrentSpeed = num20;
		}
		else
		{
			dictionary_["SPEED"] = activeUnit_.CurrentSpeed;
		}
		if (dictionary_.ContainsKey("THROTTLE"))
		{
			ActiveUnit.Throttle? throttle = LuaUtility.QueryThrottle(dictionary_);
			byte? b = (byte?)throttle;
			byte maxPossibleThrottleSetting = (byte)activeUnit_.MaxPossibleThrottleSetting;
			if ((b.HasValue ? new bool?((uint)b.GetValueOrDefault() > (uint)maxPossibleThrottleSetting) : null).GetValueOrDefault())
			{
				throttle = activeUnit_.MaxPossibleThrottleSetting;
			}
			else
			{
				b = (byte?)throttle;
				maxPossibleThrottleSetting = (byte)activeUnit_.MinPossibleThrottleSetting;
				if ((b.HasValue ? new bool?((uint)b.GetValueOrDefault() < (uint)maxPossibleThrottleSetting) : null).GetValueOrDefault())
				{
					throttle = activeUnit_.MinPossibleThrottleSetting;
				}
			}
			activeUnit_.SetThrottle(throttle.Value);
		}
		else
		{
			dictionary_["THROTTLE"] = activeUnit_.ThrottleSetting;
		}
		if (dictionary_.ContainsKey("LAUNCH"))
		{
			if (LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_["LAUNCH"])).GetValueOrDefault())
			{
				if (activeUnit_.IsAircraft)
				{
					Aircraft aircraft = (Aircraft)activeUnit_;
					if (activeUnit_.AirOps != null && aircraft.PushFacade())
					{
						aircraft.AirOps.AttemptToMoveToRunway(bool_0: true);
					}
				}
				else if (activeUnit_.DockingOps != null && activeUnit_.IsParkedAndReady())
				{
					activeUnit_.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.DeployingUnderway;
				}
			}
			else if (activeUnit_.IsAircraft)
			{
				if (activeUnit_.AirOps != null)
				{
					Aircraft aircraft2 = (Aircraft)activeUnit_;
					if (aircraft2.AirOps.IsTakingOff)
					{
						aircraft2.AirOps.AttemptToPark(bool_0: true, bool_1: false, bool_2: true);
						if (aircraft2.Navigator.HasFlight)
						{
							aircraft2.Navigator.GetFlight().SetStatus(scenario_0, Mission._FlightStatus.None);
						}
					}
				}
			}
			else if (activeUnit_.DockingOps != null && activeUnit_.DockingOps.IsDeploying)
			{
				activeUnit_.DockingOps.AttemptToStartDocking(activeUnit_.DockingOps.CurrentHostUnit, bool_0: true);
			}
		}
		if (dictionary_.ContainsKey("RTB"))
		{
			if (LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_["RTB"])).GetValueOrDefault())
			{
				if (activeUnit_.IsAircraft)
				{
					((Aircraft)activeUnit_).AirOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
				}
				else
				{
					activeUnit_.DockingOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
				}
			}
			else
			{
				activeUnit_.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
			}
		}
		if (dictionary_.ContainsKey("JETTISON"))
		{
			if (!activeUnit_.IsAircraft)
			{
				throw new LuaError("Unit is not an aircraft and cannot jettison ordnance.");
			}
			Aircraft aircraft3 = (Aircraft)activeUnit_;
			string text4 = dictionary_["JETTISON"].ToString().ToUpper();
			if (Strings.Len(text4) > 6 && Operators.CompareString(Strings.Left(text4, 6), "STORE_", TextCompare: false) == 0)
			{
				int int_ = Conversions.ToInteger(Strings.Mid(text4, 7));
				aircraft3.Weaponry.JettisonSpecificOrdnance(bool_1: true, int_);
			}
			else
			{
				switch (text4)
				{
				default:
					throw new LuaError("Unrecognized value for 'jettison.' Valid values are \"HeavyOnly\", \"WeaponsOnly\", \"AllExternal\", \"All\", or  \"store_<dbid>\"");
				case "WEAPONSONLY":
					aircraft3.Weaponry.JettisonOrdnance(bool_1: true, bool_2: false, bool_3: true, bool_4: true, bool_5: true, bool_6: false, bool_7: false);
					break;
				case "HEAVYONLY":
					aircraft3.Weaponry.JettisonOrdnance(bool_1: true, bool_2: true, bool_3: true, bool_4: true, bool_5: false, bool_6: false, bool_7: false);
					break;
				case "ALLEXTERNAL":
					aircraft3.Weaponry.JettisonOrdnance(bool_1: true, bool_2: true, bool_3: true, bool_4: true, bool_5: true, bool_6: true, bool_7: false);
					break;
				case "ALL":
					aircraft3.Weaponry.JettisonOrdnance(bool_1: true, bool_2: true, bool_3: true, bool_4: true, bool_5: true, bool_6: true, bool_7: true);
					break;
				}
			}
		}
		if (dictionary_.ContainsKey("REFUEL") && LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_["REFUEL"])).GetValueOrDefault() && activeUnit_ != null && activeUnit_.IsActiveUnit && (activeUnit_.GetUnitSide() == side || Module_Side.IsAlliedWithThisSide(activeUnit_.GetUnitSide(), side)) && (object)activeUnit_.GetType() != typeof(Weapon))
		{
			ActiveUnit activeUnit_2 = activeUnit_;
			Scenario scenario_ = scenario_0;
			ActiveUnit activeUnit_3 = null;
			List<Mission> list_ = null;
			RefuelIfPossible(activeUnit_2, scenario_, ref string_, ref activeUnit_3, ref list_);
		}
		if (dictionary_.ContainsKey("UNASSIGN") && LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_["UNASSIGN"])).GetValueOrDefault() && !Information.IsNothing(activeUnit_) && activeUnit_.IsActiveUnit)
		{
			activeUnit_.ComputeClient(ref activeUnit_);
		}
		dictionary_["DBID"] = activeUnit_.DBID;
		bool? flag6 = false;
		if (dictionary_.ContainsKey("MOVETO"))
		{
			flag6 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_["MOVETO"]));
		}
		switch (activeUnit_.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Submarine:
		{
			float? num25 = LuaUtility.QueryDepth(dictionary_);
			if (num25.HasValue)
			{
				float num2 = (int)Math.Round(num25.Value);
				if (num2 > 0f && num2 <= 6f)
				{
					float num3 = num2;
					float num4 = 0f;
					if (num3 == 6f)
					{
						num4 = 0f;
					}
					else if (num3 == 1f)
					{
						num4 = -20f;
					}
					else if (num3 == 2f)
					{
						num4 = -40f;
					}
					else if (num3 == 3f)
					{
						num4 = Submarine_AI.OverLayerDepth(activeUnit_);
					}
					else if (num3 == 4f)
					{
						num4 = Submarine_AI.UnderLayerDepth(activeUnit_);
					}
					else if (num3 == 5f)
					{
						num4 = activeUnit_.Kinematics.GetMinimumAltitude();
					}
					num2 = num4;
				}
				if (num2 < activeUnit_.Kinematics.GetMinimumAltitude())
				{
					num2 = activeUnit_.Kinematics.GetMinimumAltitude();
				}
				if (num2 > 0f)
				{
					num2 = 0f;
				}
				if (flag6.GetValueOrDefault())
				{
					activeUnit_.DesiredAltitude = (short)Math.Round(num2);
				}
				else
				{
					activeUnit_.SetCurrentAltitude(bool_0: true, (short)Math.Round(num2));
				}
			}
			else
			{
				dictionary_["DEPTH"] = activeUnit_.GetCurrentAltitude(bool_0: true);
			}
			break;
		}
		case GlobalVariables.ActiveUnitType.Aircraft:
		{
			dictionary_["LOADOUTID"] = ((Aircraft)activeUnit_).Int32_0;
			dictionary_["LOADOUTNAME"] = ((Aircraft)activeUnit_).LoadoutName;
			float? num21 = LuaUtility.QueryAltitude(dictionary_);
			if (num21.HasValue)
			{
				float num22 = (int)Math.Round(num21.Value);
				if (num22 > 0f && num22 <= 7f)
				{
					_ = ((Aircraft)activeUnit_).AI;
					float num23 = num22;
					float num24 = 0f;
					if (num23 == 1f)
					{
						num24 = activeUnit_.Kinematics.GetMinimumAltitude();
					}
					else if (num23 == 2f)
					{
						num24 = 304.8f;
					}
					else if (num23 == 3f)
					{
						num24 = 609.6f;
					}
					else if (num23 == 4f)
					{
						num24 = 3657.6f;
					}
					else if (num23 == 5f)
					{
						num24 = 7620f;
					}
					else if (num23 == 6f)
					{
						num24 = 10972.8f;
					}
					else if (num23 == 7f)
					{
						num24 = activeUnit_.Kinematics.GetMaximumAltitude();
					}
					num22 = num24;
				}
				if (num22 < activeUnit_.Kinematics.GetMinimumAltitude())
				{
					num22 = activeUnit_.Kinematics.GetMinimumAltitude();
				}
				if (num22 > activeUnit_.Kinematics.GetMaximumAltitude())
				{
					num22 = activeUnit_.Kinematics.GetMaximumAltitude();
				}
				if (flag6.GetValueOrDefault())
				{
					activeUnit_.DesiredAltitude = (short)Math.Round(num22);
				}
				else
				{
					activeUnit_.SetCurrentAltitude(bool_0: true, (short)Math.Round(num22));
				}
			}
			else
			{
				dictionary_["ALTITUDE"] = activeUnit_.GetCurrentAltitude(bool_0: true);
			}
			break;
		}
		}
		if (dictionary_.ContainsKey("HEADING"))
		{
			activeUnit_.CurrentHeading = Conversions.ToSingle(dictionary_["HEADING"]);
			activeUnit_.SetDesiredHeading(activeUnit_.DesiredTurnRate, activeUnit_.CurrentHeading);
		}
		else
		{
			dictionary_["HEADING"] = activeUnit_.CurrentHeading;
		}
		if (dictionary_.ContainsKey("DESIREDHEADING"))
		{
			float float_ = Conversions.ToSingle(dictionary_["DESIREDHEADING"]);
			activeUnit_.SetDesiredHeading(ActiveUnit.TurnRate.Max, float_);
		}
		else
		{
			dictionary_["DESIREDHEADING"] = activeUnit_.DesiredHeading;
		}
		double? num5 = LuaUtility.QueryLatitude(dictionary_);
		if (num5.HasValue)
		{
			activeUnit_.SetLatitude(null, num5.Value);
		}
		else
		{
			dictionary_["LONGITUDE"] = activeUnit_.GetLongitude();
		}
		double? num6 = LuaUtility.QueryLongitude(dictionary_);
		if (num6.HasValue)
		{
			activeUnit_.SetLongitude(null, num6.Value);
		}
		else
		{
			dictionary_["LONGITUDE"] = activeUnit_.GetLongitude();
		}
		if (dictionary_.ContainsKey("AUTODETECTABLE"))
		{
			bool? flag7 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_["AUTODETECTABLE"]));
			if (flag7.HasValue)
			{
				if (flag7.Value)
				{
					if (!activeUnit_.GetIsAutoDetectable(null))
					{
						activeUnit_.SetIsAutoDetectable(null, bool_0: true);
						activeUnit_.GetUnitSide().ProcessAutoDetectableUnits(scenario_0, scenario_0.GameResolution);
					}
				}
				else
				{
					activeUnit_.SetIsAutoDetectable(null, bool_0: false);
				}
			}
		}
		if (scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.CommsDisruption) && dictionary_.ContainsKey("OUTOFCOMMS"))
		{
			bool? flag8 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_["OUTOFCOMMS"]));
			if (flag8.HasValue)
			{
				if (flag8.Value)
				{
					activeUnit_.CommStuff.SetIsConnectedToSideNetwork(ActiveUnit_CommStuff.ReasonForGoingOffGrid.ChangeOfInternalStatus, bool_0: false);
				}
				else
				{
					activeUnit_.CommStuff.SetIsConnectedToSideNetwork(ActiveUnit_CommStuff.ReasonForGoingOffGrid.None, bool_0: true);
				}
			}
		}
		if (dictionary_.ContainsKey("HOLDPOSITION"))
		{
			bool? flag9 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_["HOLDPOSITION"]));
			if (flag9.HasValue)
			{
				activeUnit_.AI.HoldPosition = flag9.Value;
			}
		}
		if (dictionary_.ContainsKey("HOLDFIRE"))
		{
			bool? flag10 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_["HOLDFIRE"]));
			if (flag10.HasValue)
			{
				if (flag10.GetValueOrDefault())
				{
					activeUnit_.Doctrine.SetWeaponControlStatus_Air(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, Doctrine._WCS.Hold);
					activeUnit_.Doctrine.SetWeaponControlStatus_Surface(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, Doctrine._WCS.Hold);
					activeUnit_.Doctrine.SetWeaponControlStatus_Submarine(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, Doctrine._WCS.Hold);
					activeUnit_.Doctrine.SetWeaponControlStatus_Land(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, Doctrine._WCS.Hold);
				}
				else
				{
					activeUnit_.Doctrine.SetWeaponControlStatus_Air(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, Doctrine._WCS.Tight);
					activeUnit_.Doctrine.SetWeaponControlStatus_Surface(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, Doctrine._WCS.Tight);
					activeUnit_.Doctrine.SetWeaponControlStatus_Submarine(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, Doctrine._WCS.Tight);
					activeUnit_.Doctrine.SetWeaponControlStatus_Land(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, Doctrine._WCS.Tight);
				}
			}
		}
		if (dictionary_.ContainsKey("PROFICIENCY"))
		{
			string text5 = Conversions.ToString(dictionary_["PROFICIENCY"]);
			if (Enum.TryParse<GlobalVariables.ProficiencyLevel>(text5, ignoreCase: true, out var result) & Enum.IsDefined(typeof(GlobalVariables.ProficiencyLevel), result))
			{
				activeUnit_.Proficiency = result;
			}
			else
			{
				text5 = text5.ToUpper();
				switch (text5)
				{
				default:
					throw new LuaError("无法理解'" + text5 + "'作为熟练程度");
				case "VETERAN":
					activeUnit_.Proficiency = GlobalVariables.ProficiencyLevel.Veteran;
					break;
				case "REGULAR":
					activeUnit_.Proficiency = GlobalVariables.ProficiencyLevel.Regular;
					break;
				case "NOVICE":
					activeUnit_.Proficiency = GlobalVariables.ProficiencyLevel.Novice;
					break;
				case "CADET":
					activeUnit_.Proficiency = GlobalVariables.ProficiencyLevel.Cadet;
					break;
				case "ACE":
					activeUnit_.Proficiency = GlobalVariables.ProficiencyLevel.Ace;
					break;
				}
			}
		}
		if (dictionary_.ContainsKey("MANUALTHROTTLE"))
		{
			float num7 = 0f;
			switch (Conversions.ToString(dictionary_["MANUALTHROTTLE"]).ToUpper())
			{
			default:
			{
				if (Enum.TryParse<ActiveUnit_Kinematics.UnitThrottlePreset>(Conversions.ToString(dictionary_["MANUALTHROTTLE"]), ignoreCase: true, out var result2) && Enum.IsDefined(typeof(ActiveUnit_Kinematics.UnitThrottlePreset), result2))
				{
					activeUnit_.Kinematics.ThrottlePreset = result2;
					activeUnit_.Kinematics.DesiredSpeedOverride = activeUnit_.Kinematics.GetMaximumSpeed(activeUnit_.GetCurrentAltitude(), (ActiveUnit.Throttle)activeUnit_.Kinematics.ThrottlePreset, bool_0: false);
				}
				break;
			}
			case "OFF":
				activeUnit_.Kinematics.DesiredSpeedOverride = null;
				break;
			case "DESIRED":
				num7 = activeUnit_.DesiredSpeed;
				activeUnit_.Kinematics.DesiredSpeedOverride = num7;
				break;
			case "CURRENT":
				num7 = activeUnit_.CurrentSpeed;
				activeUnit_.Kinematics.DesiredSpeedOverride = num7;
				break;
			}
		}
		if (dictionary_.ContainsKey("MANUALSPEED"))
		{
			float num8 = 0f;
			switch (Conversions.ToString(dictionary_["MANUALSPEED"]).ToUpper())
			{
			default:
			{
				float? num9 = null;
				try
				{
					num9 = float.Parse(Conversions.ToString(dictionary_["MANUALSPEED"]));
				}
				catch (Exception ex10)
				{
					ProjectData.SetProjectError(ex10);
					Exception exception_10 = ex10;
					exception_10?.Data.Add("Error at PM101", "");
					GameGeneral.WriteExceptionsToLog(ref exception_10);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				if (num9.HasValue)
				{
					activeUnit_.Kinematics.DesiredSpeedOverride = num9.Value;
					activeUnit_.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				}
				break;
			}
			case "OFF":
				activeUnit_.Kinematics.DesiredSpeedOverride = null;
				break;
			case "DESIRED":
				num8 = activeUnit_.DesiredSpeed;
				activeUnit_.Kinematics.DesiredSpeedOverride = num8;
				break;
			case "CURRENT":
				num8 = activeUnit_.CurrentSpeed;
				activeUnit_.Kinematics.DesiredSpeedOverride = num8;
				break;
			}
			float? desiredSpeedOverride = activeUnit_.Kinematics.DesiredSpeedOverride;
			if (desiredSpeedOverride.HasValue)
			{
				if (activeUnit_.IsGroup && ((Group)activeUnit_).GroupLead != null)
				{
					ActiveUnit groupLead = ((Group)activeUnit_).GroupLead;
					groupLead.SetThrottle(groupLead.Kinematics.GetThrottleSuitableForThisSpeed(activeUnit_.GetCurrentAltitude(), desiredSpeedOverride.Value));
					activeUnit_.ThrottleSetting = groupLead.ThrottleSetting;
					float? num10 = desiredSpeedOverride;
					float num11 = groupLead.Kinematics.GetMaximumSpeed(groupLead.GetCurrentAltitude(), groupLead.ThrottleSetting, bool_0: false);
					if ((num10.HasValue ? new bool?(num10.GetValueOrDefault() > num11) : null).GetValueOrDefault())
					{
						activeUnit_.Kinematics.DesiredSpeedOverride = groupLead.Kinematics.GetMaximumSpeed(groupLead.GetCurrentAltitude(), groupLead.ThrottleSetting, bool_0: false);
					}
				}
				else
				{
					activeUnit_.SetThrottle(activeUnit_.Kinematics.GetThrottleSuitableForThisSpeed(activeUnit_.GetCurrentAltitude(), desiredSpeedOverride.Value));
					float? num13 = desiredSpeedOverride;
					float num14 = activeUnit_.Kinematics.GetMaximumSpeed(activeUnit_.GetCurrentAltitude(), activeUnit_.ThrottleSetting, bool_0: false);
					if ((num13.HasValue ? new bool?(num13.GetValueOrDefault() > num14) : null).GetValueOrDefault())
					{
						activeUnit_.Kinematics.DesiredSpeedOverride = activeUnit_.Kinematics.GetMaximumSpeed(activeUnit_.GetCurrentAltitude(), activeUnit_.ThrottleSetting, bool_0: false);
					}
				}
			}
		}
		if (dictionary_.ContainsKey("MANUALALTITUDE"))
		{
			switch (Conversions.ToString(dictionary_["MANUALALTITUDE"]).ToUpper())
			{
			default:
			{
				if (activeUnit_.IsSubmarine)
				{
					ActiveUnit_AI.SubmarineDepthPreset? submarineDepthPreset = LuaUtility.QueryDepthPresetObject(Conversions.ToString(dictionary_["MANUALALTITUDE"]));
					if (submarineDepthPreset.HasValue)
					{
						((Submarine)activeUnit_).AI.DepthPreset = submarineDepthPreset.Value;
						((Submarine)activeUnit_).AI.FollowDepthPreset(bool_0: false);
						activeUnit_.Kinematics.DesiredAltitudeOverride = true;
					}
					else
					{
						float? num15 = LuaUtility.QueryDepthObject(Conversions.ToString(dictionary_["MANUALALTITUDE"]));
						activeUnit_.DesiredAltitude = num15.Value;
						((Submarine)activeUnit_).AI.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
						activeUnit_.Kinematics.DesiredAltitudeOverride = true;
					}
					break;
				}
				if (activeUnit_.IsAircraft)
				{
					ActiveUnit_AI.AircraftAltitudePreset? aircraftAltitudePreset = LuaUtility.QueryAltitudePresetObject(Conversions.ToString(dictionary_["MANUALALTITUDE"]));
					if (aircraftAltitudePreset.HasValue)
					{
						((Aircraft)activeUnit_).AI.AltitudePreset = aircraftAltitudePreset.Value;
						((Aircraft)activeUnit_).AI.FollowAltitudePreset();
						activeUnit_.Kinematics.DesiredAltitudeOverride = true;
					}
					else
					{
						float? num16 = LuaUtility.QueryAltitudeObject(Conversions.ToString(dictionary_["MANUALALTITUDE"]));
						activeUnit_.DesiredAltitude = num16.Value;
						((Aircraft)activeUnit_).AI.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
						activeUnit_.Kinematics.DesiredAltitudeOverride = true;
					}
					break;
				}
				float result3 = 0f;
				if (float.TryParse(Conversions.ToString(dictionary_["MANUALALTITUDE"]), out result3))
				{
					activeUnit_.DesiredAltitude = result3;
					activeUnit_.Kinematics.DesiredAltitudeOverride = true;
					if (activeUnit_.IsSubmarine)
					{
						((Submarine)activeUnit_).AI.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
					}
					else if (activeUnit_.IsAircraft)
					{
						((Aircraft)activeUnit_).AI.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
					}
				}
				break;
			}
			case "OFF":
				activeUnit_.Kinematics.DesiredAltitudeOverride = false;
				break;
			case "DESIRED":
				_ = activeUnit_.DesiredAltitude;
				activeUnit_.Kinematics.DesiredAltitudeOverride = true;
				break;
			case "CURRENT":
				activeUnit_.GetCurrentAltitude();
				activeUnit_.Kinematics.DesiredAltitudeOverride = true;
				break;
			}
		}
		if (dictionary_.ContainsKey("FUEL"))
		{
			List<object> list2 = LuaUtility.ToArray(((LuaTable)dictionary_["FUEL"]).GetEnumerator());
			try
			{
				foreach (object item2 in list2)
				{
					object objectValue3 = RuntimeHelpers.GetObjectValue(item2);
					if (!(objectValue3 is LuaTable))
					{
						continue;
					}
					Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)objectValue3).GetEnumerator());
					if (dictionary.ContainsKey("1") & dictionary.ContainsKey("2"))
					{
						string value = Conversions.ToString(dictionary["1"]);
						int result4 = int.MaxValue;
						if (int.TryParse(Conversions.ToString(dictionary["2"]), out result4))
						{
							if (Enum.TryParse<FuelRec._FuelType>(value, ignoreCase: true, out Local_e) & Enum.IsDefined(typeof(FuelRec._FuelType), Local_e))
							{
								if (activeUnit_.Fuel_ReadOnly.FirstOrDefault((FuelRec F) => F.FuelType == Local_e) != null)
								{
									int num17 = result4;
									if (activeUnit_.IsAircraft)
									{
										((Aircraft)activeUnit_).FuelCapacitySet(num17);
										continue;
									}
									foreach (FuelRec item3 in activeUnit_.Fuel_ReadOnly)
									{
										if (item3.FuelType == Local_e)
										{
											int val2 = Math.Min(item3.MaxQuantity, num17);
											val2 = Math.Max(0, val2);
											item3.CurrentQuantity = val2;
											num17 -= val2;
										}
									}
									continue;
								}
								throw new LuaError("缺少燃料类型" + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue3)) + "在ScenEdit_SetUnit中。");
							}
							throw new LuaError("燃油类型错误" + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue3)) + "在ScenEdit_SetUnit中。");
						}
						throw new LuaError("金额错误" + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue3)) + "在ScenEdit_SetUnit中。");
					}
					throw new LuaError("Error at " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue3)) + "在ScenEdit_SetUnit中。");
				}
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM102", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		if (dictionary_.ContainsKey("BASE"))
		{
			string text6 = Conversions.ToString(dictionary_["BASE"]);
			ActiveUnit activeUnit2 = null;
			if (Operators.CompareString(text6, "", TextCompare: false) != 0)
			{
				activeUnit2 = smethod_0(text6, scenario_0);
			}
			if (Information.IsNothing(activeUnit2))
			{
				if (Information.IsNothing(activeUnit2) && Operators.CompareString(text6, "", TextCompare: false) == 0)
				{
					if (activeUnit_.IsAircraft)
					{
						if (activeUnit_.AirOps != null)
						{
							((Aircraft_AirOps)activeUnit_.AirOps).PickNewAssignedHost_Nearest();
						}
					}
					else if (activeUnit_.DockingOps != null)
					{
						activeUnit_.DockingOps.PickNewAssignedHost_Nearest();
					}
				}
			}
			else if (activeUnit_.IsAircraft)
			{
				if (activeUnit_.AirOps != null)
				{
					Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)activeUnit_.AirOps;
					if (Operators.CompareString(aircraft_AirOps.ThisUnitCanHostMe(activeUnit2), "OK", TextCompare: false) == 0)
					{
						aircraft_AirOps.SetAssignedHostUnit(bool_0: false, activeUnit2);
					}
				}
			}
			else if (activeUnit_.DockingOps != null)
			{
				ActiveUnit_DockingOps dockingOps = activeUnit_.DockingOps;
				if (Operators.CompareString(dockingOps.ThisUnitCanHostMe(activeUnit2), "OK", TextCompare: false) == 0)
				{
					dockingOps.SetAssignedHostUnit(bool_0: false, activeUnit2);
				}
			}
		}
		if (dictionary_.ContainsKey("SPRINTDRIFT"))
		{
			bool? flag11 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_["SPRINTDRIFT"]));
			if (flag11.HasValue)
			{
				activeUnit_.Navigator.SprintDrift = flag11.Value;
			}
			else
			{
				dictionary_.Remove("SPRINTDRIFT");
			}
		}
		if (dictionary_.ContainsKey("AVOIDCAVITATION"))
		{
			bool? flag2 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_["AVOIDCAVITATION"]));
			if (flag2.HasValue)
			{
				if (activeUnit_.IsGroup && ((Group)activeUnit_).Units.Count > 0)
				{
					foreach (ActiveUnit value2 in ((Group)activeUnit_).Units.Values)
					{
						value2.Navigator.AvoidCavitation = flag2.Value;
					}
				}
				activeUnit_.Navigator.AvoidCavitation = flag2.Value;
			}
			else
			{
				dictionary_.Remove("AVOIDCAVITATION");
			}
		}
		if (dictionary_.ContainsKey("CSAR"))
		{
			bool? flag3 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_["CSAR"]));
			if (flag3.HasValue)
			{
				activeUnit_.EligibleForSAR = flag3.Value;
			}
			else
			{
				dictionary_.Remove("CSAR");
			}
		}
		if (dictionary_.ContainsKey("TIMETOREADY_MINUTES"))
		{
			int num18 = 0;
			num18 = int.Parse(Conversions.ToString(dictionary_["TIMETOREADY_MINUTES"]));
			if ((object)activeUnit_.GetType() == typeof(Aircraft))
			{
				if (((Aircraft)activeUnit_).NewFacade() | (((Aircraft)activeUnit_).AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying))
				{
					((Aircraft)activeUnit_).AirOps.ConditionTimer = num18 * 60;
					if (((Aircraft)activeUnit_).AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying)
					{
						((Aircraft)activeUnit_).AirOps._ValueObserver = num18 * 60;
					}
				}
			}
			else if (activeUnit_.DockingOps != null)
			{
				activeUnit_.DockingOps.ConditionTimer = num18 * 60;
			}
		}
		if (activeUnit_.CommStuff.IsConnectedToSideNetwork)
		{
			activeUnit_.Longitude_LastReported = activeUnit_.GetLongitude();
			activeUnit_.Latitude_LastReported = activeUnit_.GetLatitude();
		}
		else
		{
			if (!activeUnit_.Longitude_LastReported.HasValue)
			{
				activeUnit_.Longitude_LastReported = activeUnit_.GetLongitude();
			}
			if (!activeUnit_.Latitude_LastReported.HasValue)
			{
				activeUnit_.Latitude_LastReported = activeUnit_.GetLatitude();
			}
		}
		return new LuaWrapper_ActiveUnit_SE(activeUnit_, scenario_0);
	}

	public static bool ScenEdit_DeleteUnit(LuaTable luaTable_0, bool bool_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		ActiveUnit activeUnit = null;
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dictionary_["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM103", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid必须是一个字符串");
			}
			try
			{
				activeUnit = scenario_0.ActiveUnits[text];
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM104", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("找不到guid" + text);
			}
			dictionary_["SIDE"] = activeUnit.GetUnitSide().Name;
			dictionary_["UNITNAME"] = activeUnit.Name;
		}
		else if (dictionary_.ContainsKey("UNITNAME"))
		{
			string Local_Name = null;
			try
			{
				Local_Name = Conversions.ToString(dictionary_["UNITNAME"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at PM105", "");
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("名称必须是一个字符串");
			}
			if (dictionary_.ContainsKey("SIDE"))
			{
				string text2;
				try
				{
					text2 = Conversions.ToString(dictionary_["SIDE"]);
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception exception_4 = ex4;
					exception_4?.Data.Add("Error at PM106", "");
					GameGeneral.WriteExceptionsToLog(ref exception_4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("分方必须是一个字符串");
				}
				Side side;
				try
				{
					side = LuaUtility.QuerySide(dictionary_, scenario_0);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception exception_5 = ex5;
					exception_5?.Data.Add("Error at PM107", "");
					GameGeneral.WriteExceptionsToLog(ref exception_5);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到分方'" + text2 + "'");
				}
				try
				{
					activeUnit = side.Units.First((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex6)
				{
					ProjectData.SetProjectError(ex6);
					Exception exception_6 = ex6;
					exception_6?.Data.Add("Error at PM108", "");
					GameGeneral.WriteExceptionsToLog(ref exception_6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + Local_Name + "' 分方 '" + text2 + "'");
				}
				dictionary_["GUID"] = activeUnit.ObjectID;
			}
			else
			{
				try
				{
					activeUnit = scenario_0.ActiveUnits_List.First((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception exception_7 = ex7;
					exception_7?.Data.Add("Error at PM109", "");
					GameGeneral.WriteExceptionsToLog(ref exception_7);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + Local_Name + "'");
				}
				dictionary_["GUID"] = activeUnit.ObjectID;
				dictionary_["SIDE"] = activeUnit.GetUnitSide().Name;
			}
		}
		if (activeUnit == null)
		{
			throw new LuaError("需要定义名称或Guid来标识单元。最好是Guid或Side＆Name。");
		}
		if (scenario_0.ExecutionInProgress)
		{
			if (activeUnit.IsGroup && bool_0)
			{
				List<ActiveUnit> list = new List<ActiveUnit>();
				list.AddRange(((Group)activeUnit).Units.Values);
				foreach (ActiveUnit item in list)
				{
					scenario_0.DeleteThisUnit(item);
				}
			}
			scenario_0.DeleteThisUnit(activeUnit);
		}
		else
		{
			if (activeUnit.IsGroup && bool_0)
			{
				List<ActiveUnit> list2 = new List<ActiveUnit>();
				list2.AddRange(((Group)activeUnit).Units.Values);
				foreach (ActiveUnit item2 in list2)
				{
					scenario_0.DeleteUnitImmediately(item2.ObjectID, bool_0: true, "Deleted via Lua command.");
				}
			}
			scenario_0.DeleteUnitImmediately(activeUnit.ObjectID, bool_0: true, "Deleted via Lua command.");
		}
		return true;
	}

	public static bool ScenEdit_KillUnit(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		ActiveUnit activeUnit = null;
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("GUID"))
		{
			string text3;
			try
			{
				text3 = Conversions.ToString(dictionary_["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM110", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid必须是一个字符串");
			}
			try
			{
				activeUnit = scenario_0.ActiveUnits[text3];
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM111", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("找不到guid" + text3);
			}
			dictionary_["SIDE"] = activeUnit.GetUnitSide().Name;
			dictionary_["UNITNAME"] = activeUnit.Name;
		}
		else if (dictionary_.ContainsKey("UNITNAME"))
		{
			string text2;
			try
			{
				text2 = Conversions.ToString(dictionary_["UNITNAME"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at PM112", "");
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("名称必须是一个字符串");
			}
			if (dictionary_.ContainsKey("SIDE"))
			{
				string text4;
				try
				{
					text4 = Conversions.ToString(dictionary_["SIDE"]);
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception exception_4 = ex4;
					exception_4?.Data.Add("Error at PM113", "");
					GameGeneral.WriteExceptionsToLog(ref exception_4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("分方必须是一个字符串");
				}
				Side side;
				try
				{
					side = LuaUtility.QuerySide(dictionary_, scenario_0);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception exception_5 = ex5;
					exception_5?.Data.Add("Error at PM114", "");
					GameGeneral.WriteExceptionsToLog(ref exception_5);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到分方'" + text4 + "'");
				}
				try
				{
					activeUnit = side.Units.First((ActiveUnit s) => string.Equals(s.Name, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text2, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex6)
				{
					ProjectData.SetProjectError(ex6);
					Exception exception_6 = ex6;
					exception_6?.Data.Add("Error at PM115", "");
					GameGeneral.WriteExceptionsToLog(ref exception_6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + text2 + "' 分方 '" + text4 + "'");
				}
				dictionary_["GUID"] = activeUnit.ObjectID;
			}
			else
			{
				try
				{
					activeUnit = scenario_0.ActiveUnits_List.First((ActiveUnit s) => string.Equals(s.Name, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text2, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception exception_7 = ex7;
					exception_7?.Data.Add("Error at PM116", "");
					GameGeneral.WriteExceptionsToLog(ref exception_7);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + text2 + "'");
				}
				dictionary_["GUID"] = activeUnit.ObjectID;
				dictionary_["SIDE"] = activeUnit.GetUnitSide().Name;
			}
		}
		if (activeUnit == null)
		{
			throw new LuaError("需要定义名称或Guid来标识单元。最好是Guid或Side＆Name。");
		}
		scenario_0.DestroyThisUnit(activeUnit, "Unit destroyed by Lua script", "Script");
		return true;
	}

	public static bool ScenEdit_SetUnitSide(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		ActiveUnit activeUnit = null;
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dictionary_["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM117", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid必须是一个字符串");
			}
			try
			{
				activeUnit = scenario_0.ActiveUnits[text];
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM118", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("找不到guid" + text);
			}
			dictionary_["SIDE"] = activeUnit.GetUnitSide().Name;
			dictionary_["UNITNAME"] = activeUnit.Name;
		}
		else if (dictionary_.ContainsKey("UNITNAME"))
		{
			string Local_Name = null;
			try
			{
				Local_Name = Conversions.ToString(dictionary_["UNITNAME"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at PM119", "");
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("名称必须是一个字符串");
			}
			if (dictionary_.ContainsKey("SIDE"))
			{
				string text2;
				try
				{
					text2 = Conversions.ToString(dictionary_["SIDE"]);
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception exception_4 = ex4;
					exception_4?.Data.Add("Error at PM120", "");
					GameGeneral.WriteExceptionsToLog(ref exception_4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("分方必须是一个字符串");
				}
				Side side;
				try
				{
					side = LuaUtility.QuerySide(dictionary_, scenario_0);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception exception_5 = ex5;
					exception_5?.Data.Add("Error at PM121", "");
					GameGeneral.WriteExceptionsToLog(ref exception_5);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到分方'" + text2 + "'");
				}
				try
				{
					activeUnit = side.Units.First((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex6)
				{
					ProjectData.SetProjectError(ex6);
					Exception exception_6 = ex6;
					exception_6?.Data.Add("Error at PM122", "");
					GameGeneral.WriteExceptionsToLog(ref exception_6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + Local_Name + "' 分方 '" + text2 + "'");
				}
				dictionary_["GUID"] = activeUnit.ObjectID;
			}
			else
			{
				try
				{
					activeUnit = scenario_0.ActiveUnits_List.First((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception exception_7 = ex7;
					exception_7?.Data.Add("Error at PM123", "");
					GameGeneral.WriteExceptionsToLog(ref exception_7);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + Local_Name + "'");
				}
				dictionary_["GUID"] = activeUnit.ObjectID;
				dictionary_["SIDE"] = activeUnit.GetUnitSide().Name;
			}
		}
		if (activeUnit == null)
		{
			throw new LuaError("需要定义名称或Guid来标识单元。最好是Guid或Side＆Name。");
		}
		Side side_ = null;
		try
		{
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side2 in array)
			{
				if (Operators.CompareString(side2.Name.ToUpper(), dictionary_["NEWSIDE"].ToString().ToUpper(), TextCompare: false) == 0)
				{
					side_ = side2;
					break;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw new LuaError("新分方名称无效！");
		}
		return activeUnit.CancelInterruptibleQueue(side_, scenario_0);
	}

	public static bool ScenEdit_SetLoadoutAvailable(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("LOADOUTDBID"))
		{
			int item;
			try
			{
				item = Conversions.ToInteger(dictionary_["LOADOUTDBID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM124", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("'LoadoutDBID' must be an integer");
			}
			if (dictionary_.ContainsKey("AVAILABLE"))
			{
				bool flag;
				try
				{
					flag = Conversions.ToBoolean(dictionary_["AVAILABLE"]);
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at PM125", "");
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("'Available' must be a boolean value (0 or 1,'True' or 'False')");
				}
				if (flag)
				{
					try
					{
						scenario_0.Cache_DisabledLoadouts.Remove(item);
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception exception_3 = ex3;
						exception_3?.Data.Add("Error at PM126", "");
						GameGeneral.WriteExceptionsToLog(ref exception_3);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					scenario_0.Cache_DisabledLoadouts.Add(item);
				}
				return true;
			}
			throw new LuaError("Mandatory value 'Available' not provided");
		}
		throw new LuaError("Mandatory value 'LoadoutDBID' not provided");
	}

	public static int ScenEdit_AddReloadsToUnit(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		ActiveUnit activeUnit = null;
		Side side = null;
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dictionary_["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM127", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid必须是一个字符串");
			}
			try
			{
				activeUnit = scenario_0.ActiveUnits[text];
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM128", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return 0;
			}
			if (activeUnit == null)
			{
				return 0;
			}
			dictionary_["SIDE"] = activeUnit.GetUnitSide().Name;
			dictionary_["UNITNAME"] = activeUnit.Name;
		}
		else if (dictionary_.ContainsKey("UNITNAME"))
		{
			string Local_Name = null;
			try
			{
				Local_Name = Conversions.ToString(dictionary_["UNITNAME"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at PM129", "");
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("名称必须是一个字符串");
			}
			if (dictionary_.ContainsKey("SIDE"))
			{
				string text2;
				try
				{
					text2 = Conversions.ToString(dictionary_["SIDE"]);
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception exception_4 = ex4;
					exception_4?.Data.Add("Error at PM130", "");
					GameGeneral.WriteExceptionsToLog(ref exception_4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("分方必须是一个字符串");
				}
				try
				{
					side = LuaUtility.QuerySide(dictionary_, scenario_0);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception exception_5 = ex5;
					exception_5?.Data.Add("Error at PM131", "");
					GameGeneral.WriteExceptionsToLog(ref exception_5);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到分方'" + text2 + "'");
				}
				try
				{
					activeUnit = side.Units.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex6)
				{
					ProjectData.SetProjectError(ex6);
					Exception exception_6 = ex6;
					exception_6?.Data.Add("Error at PM132", "");
					GameGeneral.WriteExceptionsToLog(ref exception_6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + Local_Name + "' 分方 '" + text2 + "'");
				}
				dictionary_["GUID"] = activeUnit.ObjectID;
			}
			else
			{
				try
				{
					activeUnit = scenario_0.ActiveUnits_List.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception exception_7 = ex7;
					exception_7?.Data.Add("Error at PM133", "");
					GameGeneral.WriteExceptionsToLog(ref exception_7);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + Local_Name + "'");
				}
				dictionary_["GUID"] = activeUnit.ObjectID;
				dictionary_["SIDE"] = activeUnit.GetUnitSide().Name;
			}
		}
		if (activeUnit == null)
		{
			throw new LuaError("需要定义名称或Guid来标识单元。最好是Guid或Side＆Name。");
		}
		if (side == null)
		{
			side = LuaUtility.QuerySide(dictionary_, scenario_0);
		}
		if (dictionary_.ContainsKey("WPN_DBID"))
		{
			int num = Conversions.ToInteger(dictionary_["WPN_DBID"]);
			Mount mount = null;
			if (dictionary_.ContainsKey("MOUNT_GUID"))
			{
				if (activeUnit.Mounts.Count == 0)
				{
					throw new LuaError("单元中没有挂架。");
				}
				foreach (Mount mount2 in activeUnit.Mounts)
				{
					if (Operators.CompareString(mount2.ObjectID, Conversions.ToString(dictionary_["MOUNT_GUID"]), TextCompare: false) == 0)
					{
						mount = mount2;
					}
				}
			}
			if ((mount == null) & (activeUnit.Mounts.Count == 0))
			{
				throw new LuaError("单元中没有挂架。");
			}
			string text3 = null;
			if (dictionary_.ContainsKey("WPN_GUID"))
			{
				text3 = Conversions.ToString(dictionary_["WPN_GUID"]);
			}
			int num2 = 0;
			bool flag = false;
			bool flag2 = true;
			bool flag3 = false;
			int num3 = 0;
			if (dictionary_.ContainsKey("NUMBER"))
			{
				num2 = Conversions.ToInteger(dictionary_["NUMBER"]);
			}
			if (dictionary_.ContainsKey("REMOVE"))
			{
				flag = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_["REMOVE"])).Value;
			}
			if (dictionary_.ContainsKey("FILLOUT"))
			{
				flag3 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_["FILLOUT"])).Value;
			}
			if (flag3)
			{
				flag2 = false;
				flag = false;
				num2 = 9999999;
			}
			if (num2 > 0)
			{
				if (Information.IsNothing(mount))
				{
					foreach (Mount mount3 in activeUnit.Mounts)
					{
						foreach (WeaponRec mountWeapon in mount3.MountWeapons)
						{
							int num4 = mountWeapon.Multiple;
							if (num4 < 1)
							{
								num4 = 1;
							}
							int num5 = num4 * num2;
							if ((text3 != null && Operators.CompareString(text3, mountWeapon.ObjectID, TextCompare: false) != 0) || mountWeapon.int_0 != num)
							{
								continue;
							}
							if (flag)
							{
								if (mountWeapon.CurrentLoad < num5)
								{
									if (mountWeapon.CurrentLoad > 0)
									{
										while (mountWeapon.CurrentLoad >= num4 && num5 > 0)
										{
											num5 -= num4;
											num2--;
											mountWeapon.CurrentLoad -= num4;
											num3++;
										}
										mountWeapon.CurrentLoad = 0;
									}
									continue;
								}
								mountWeapon.CurrentLoad -= num5;
								num3 += num2;
								num2 = 0;
								break;
							}
							if (mountWeapon.CurrentLoad + num5 > mountWeapon.MaxLoad)
							{
								if (mountWeapon.CurrentLoad != mountWeapon.MaxLoad)
								{
									while (mountWeapon.CurrentLoad < mountWeapon.MaxLoad && num5 > 0)
									{
										num5 -= num4;
										num2--;
										mountWeapon.CurrentLoad += num4;
										num3++;
									}
									mountWeapon.CurrentLoad = mountWeapon.MaxLoad;
								}
								continue;
							}
							mountWeapon.CurrentLoad += num5;
							num3 += num2;
							num2 = 0;
							break;
						}
						if (num2 <= 0)
						{
							break;
						}
					}
				}
				else
				{
					foreach (WeaponRec mountWeapon2 in mount.MountWeapons)
					{
						int num6 = mountWeapon2.Multiple;
						if (num6 < 1)
						{
							num6 = 1;
						}
						int num7 = num6 * num2;
						if ((text3 != null && Operators.CompareString(text3, mountWeapon2.ObjectID, TextCompare: false) != 0) || mountWeapon2.int_0 != num)
						{
							continue;
						}
						if (flag)
						{
							if (mountWeapon2.CurrentLoad < num7)
							{
								if (mountWeapon2.CurrentLoad > 0)
								{
									while (mountWeapon2.CurrentLoad >= num6 && num7 > 0)
									{
										num7 -= num6;
										num2--;
										mountWeapon2.CurrentLoad -= num6;
										num3++;
									}
									mountWeapon2.CurrentLoad = 0;
								}
								continue;
							}
							mountWeapon2.CurrentLoad -= num7;
							num3 += num2;
							num2 = 0;
							break;
						}
						if (mountWeapon2.CurrentLoad + num7 > mountWeapon2.MaxLoad)
						{
							if (mountWeapon2.CurrentLoad != mountWeapon2.MaxLoad)
							{
								while (mountWeapon2.CurrentLoad < mountWeapon2.MaxLoad && num7 > 0)
								{
									num7 -= num6;
									num2--;
									mountWeapon2.CurrentLoad += num6;
									num3++;
								}
								mountWeapon2.CurrentLoad = mountWeapon2.MaxLoad;
							}
							continue;
						}
						mountWeapon2.CurrentLoad += num7;
						num3 += num2;
						num2 = 0;
						break;
					}
				}
			}
			if (!(num2 <= 0 || flag || flag3) && flag2)
			{
				Information.IsNothing(mount);
			}
			return num3;
		}
		throw new LuaError("没有定义武器。");
	}

	public static int ScenEdit_AddWeaponToUnitMagazine(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		ActiveUnit activeUnit_ = null;
		Side side = null;
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dictionary_["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM134", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid必须是一个字符串");
			}
			try
			{
				activeUnit_ = scenario_0.ActiveUnits[text];
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM135", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return 0;
			}
			if (activeUnit_ == null)
			{
				return 0;
			}
			dictionary_["SIDE"] = activeUnit_.GetUnitSide().Name;
			dictionary_["UNITNAME"] = activeUnit_.Name;
		}
		else if (dictionary_.ContainsKey("UNITNAME"))
		{
			string Local_Name = null;
			try
			{
				Local_Name = Conversions.ToString(dictionary_["UNITNAME"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at PM136", "");
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("名称必须是一个字符串");
			}
			if (dictionary_.ContainsKey("SIDE"))
			{
				string text2 = null;
				try
				{
					text2 = Conversions.ToString(dictionary_["SIDE"]);
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception exception_4 = ex4;
					exception_4?.Data.Add("Error at PM137", "");
					GameGeneral.WriteExceptionsToLog(ref exception_4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("分方必须是一个字符串");
				}
				try
				{
					side = LuaUtility.QuerySide(dictionary_, scenario_0);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception exception_5 = ex5;
					exception_5?.Data.Add("Error at PM138", "");
					GameGeneral.WriteExceptionsToLog(ref exception_5);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到分方'" + text2 + "'");
				}
				try
				{
					activeUnit_ = side.Units.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex6)
				{
					ProjectData.SetProjectError(ex6);
					Exception exception_6 = ex6;
					exception_6?.Data.Add("Error at PM139", "");
					GameGeneral.WriteExceptionsToLog(ref exception_6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + Local_Name + "' 分方 '" + text2 + "'");
				}
				dictionary_["GUID"] = activeUnit_.ObjectID;
			}
			else
			{
				try
				{
					activeUnit_ = scenario_0.ActiveUnits_List.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception exception_7 = ex7;
					exception_7?.Data.Add("Error at PM140", "");
					GameGeneral.WriteExceptionsToLog(ref exception_7);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + Local_Name + "'");
				}
				dictionary_["GUID"] = activeUnit_.ObjectID;
				dictionary_["SIDE"] = activeUnit_.GetUnitSide().Name;
			}
		}
		if (activeUnit_ == null)
		{
			throw new LuaError("需要定义名称或Guid来标识单元。最好是Guid或Side＆Name。");
		}
		if (side == null)
		{
			side = LuaUtility.QuerySide(dictionary_, scenario_0);
		}
		Magazine magazine_ = null;
		if (dictionary_.ContainsKey("MAG_GUID"))
		{
			if (activeUnit_.TotalMagazines.Count() == 0)
			{
				throw new LuaError("单元中没有弹药库。");
			}
			Magazine[] totalMagazines2 = activeUnit_.TotalMagazines;
			Magazine[] array = totalMagazines2;
			foreach (Magazine magazine in array)
			{
				if (string.Equals(Conversions.ToString(dictionary_["MAG_GUID"]), magazine.ObjectID, StringComparison.OrdinalIgnoreCase))
				{
					magazine_ = magazine;
					break;
				}
			}
		}
		if ((magazine_ == null) & (activeUnit_.TotalMagazines.Count() == 0))
		{
			throw new LuaError("单元中没有弹药库。");
		}
		if (dictionary_.ContainsKey("WPN_DBID"))
		{
			int num = Conversions.ToInteger(dictionary_["WPN_DBID"]);
			int num2 = 0;
			int int_ = 0;
			bool flag = false;
			bool bool_ = true;
			bool flag2 = false;
			int num3 = 0;
			if (dictionary_.ContainsKey("NUMBER"))
			{
				num2 = Conversions.ToInteger(dictionary_["NUMBER"]);
			}
			if (dictionary_.ContainsKey("MAXCAP"))
			{
				int_ = Conversions.ToInteger(dictionary_["MAXCAP"]);
			}
			if (dictionary_.ContainsKey("REMOVE"))
			{
				flag = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_["REMOVE"])).Value;
			}
			if (dictionary_.ContainsKey("NEW"))
			{
				bool_ = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_["NEW"])).Value;
			}
			if (dictionary_.ContainsKey("FILLOUT"))
			{
				flag2 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_["FILLOUT"])).Value;
			}
			if (flag2)
			{
				bool_ = false;
				flag = false;
				num2 = 9999999;
			}
			if (num2 > 0)
			{
				if (magazine_ == null)
				{
					Magazine[] totalMagazines = activeUnit_.TotalMagazines;
					for (int i = 0; i < totalMagazines.Length; i++)
					{
						foreach (WeaponRec weapon in totalMagazines[i].Weapons)
						{
							if (weapon.int_0 != num)
							{
								continue;
							}
							if (flag)
							{
								if (weapon.CurrentLoad >= num2)
								{
									weapon.CurrentLoad -= num2;
									num3 += num2;
									num2 = 0;
									break;
								}
								if (weapon.CurrentLoad > 0)
								{
									num2 -= weapon.CurrentLoad;
									num3 += weapon.CurrentLoad;
									weapon.CurrentLoad = 0;
								}
							}
							else
							{
								if (weapon.CurrentLoad + num2 <= weapon.MaxLoad)
								{
									weapon.CurrentLoad += num2;
									num3 += num2;
									num2 = 0;
									break;
								}
								if (weapon.CurrentLoad != weapon.MaxLoad)
								{
									num2 -= weapon.MaxLoad - weapon.CurrentLoad;
									num3 += weapon.MaxLoad - weapon.CurrentLoad;
									weapon.CurrentLoad = weapon.MaxLoad;
								}
							}
						}
						if (num2 <= 0)
						{
							break;
						}
					}
				}
				else
				{
					foreach (WeaponRec weapon2 in magazine_.Weapons)
					{
						if (weapon2.int_0 != num)
						{
							continue;
						}
						if (flag)
						{
							if (weapon2.CurrentLoad >= num2)
							{
								weapon2.CurrentLoad -= num2;
								num3 += num2;
								num2 = 0;
								break;
							}
							if (weapon2.CurrentLoad > 0)
							{
								num2 -= weapon2.CurrentLoad;
								num3 += weapon2.CurrentLoad;
								weapon2.CurrentLoad = 0;
							}
						}
						else
						{
							if (weapon2.CurrentLoad + num2 <= weapon2.MaxLoad)
							{
								weapon2.CurrentLoad += num2;
								num3 += num2;
								num2 = 0;
								break;
							}
							if (weapon2.CurrentLoad != weapon2.MaxLoad)
							{
								num2 -= weapon2.MaxLoad - weapon2.CurrentLoad;
								num3 += weapon2.MaxLoad - weapon2.CurrentLoad;
								weapon2.CurrentLoad = weapon2.MaxLoad;
							}
						}
					}
				}
			}
			while (num2 > 0 && !flag && !flag2)
			{
				if (magazine_ == null)
				{
					Magazine magazine2 = null;
					Magazine magazine_2 = null;
					magazine2 = AddWeaponToMagazines(ref activeUnit_, num, ref magazine_2, bool_0: false, bool_, int_);
					if (magazine2 == null)
					{
						break;
					}
					num2--;
					num3++;
					foreach (WeaponRec weapon3 in magazine2.Weapons)
					{
						if (weapon3.int_0 == num)
						{
							if (weapon3.CurrentLoad + num2 <= weapon3.MaxLoad)
							{
								weapon3.CurrentLoad += num2;
								num3 += num2;
								num2 = 0;
								break;
							}
							if (weapon3.CurrentLoad != weapon3.MaxLoad)
							{
								num2 -= weapon3.MaxLoad - weapon3.CurrentLoad;
								num3 += weapon3.MaxLoad - weapon3.CurrentLoad;
								weapon3.CurrentLoad = weapon3.MaxLoad;
							}
						}
					}
					magazine2.RaiseEventStatusChanged();
					continue;
				}
				if (AddWeaponToMagazines(ref activeUnit_, num, ref magazine_, bool_0: false, bool_, int_) == null)
				{
					break;
				}
				num2--;
				num3++;
				foreach (WeaponRec weapon4 in magazine_.Weapons)
				{
					if (weapon4.int_0 == num)
					{
						if (weapon4.CurrentLoad + num2 <= weapon4.MaxLoad)
						{
							weapon4.CurrentLoad += num2;
							num3 += num2;
							num2 = 0;
							break;
						}
						if (weapon4.CurrentLoad != weapon4.MaxLoad)
						{
							num2 -= weapon4.MaxLoad - weapon4.CurrentLoad;
							num3 += weapon4.MaxLoad - weapon4.CurrentLoad;
							weapon4.CurrentLoad = weapon4.MaxLoad;
						}
					}
				}
				magazine_.RaiseEventStatusChanged();
				break;
			}
			return num3;
		}
		throw new LuaError("没有定义武器。");
	}

	public static Magazine AddWeaponToMagazines(ref ActiveUnit activeUnit_0, int int_0, ref Magazine magazine_0, bool bool_0, bool bool_1, int int_1)
	{
		Magazine[] totalMagazines = activeUnit_0.TotalMagazines;
		if (bool_1)
		{
			if (magazine_0 == null)
			{
				if (activeUnit_0.SharedMagazines.Length != 0)
				{
					totalMagazines = activeUnit_0.SharedMagazines;
					if (bool_0)
					{
						totalMagazines = totalMagazines.OrderByDescending((Magazine theMaga) => theMaga.IsAviationMag.ToString()).ToArray();
					}
					Magazine[] array = totalMagazines;
					Magazine[] array2 = array;
					foreach (Magazine magazine in array2)
					{
						int int_2 = 0;
						int int_3 = 0;
						if (magazine.InitClass(ref int_2, ref int_3) <= magazine.Capacity)
						{
							int int_4 = int_1;
							if (int_1 == 0)
							{
								int_4 = magazine.Capacity;
							}
							magazine.Weapons.Add(new WeaponRec(ref activeUnit_0.ParentScen, int_0, 0, int_4, 1, 1, bool_0: false, bool_1: false));
							if (string.CompareOrdinal(magazine.AddWeapon(int_0), "OK") == 0)
							{
								return magazine;
							}
						}
					}
				}
			}
			else
			{
				Magazine obj = magazine_0;
				int int_5 = 0;
				int int_6 = 0;
				if (obj.InitClass(ref int_5, ref int_6) <= magazine_0.Capacity)
				{
					int int_7 = int_1;
					if (int_1 == 0)
					{
						int_7 = magazine_0.Capacity;
					}
					magazine_0.Weapons.Add(new WeaponRec(ref activeUnit_0.ParentScen, int_0, 0, int_7, 1, 1, bool_0: false, bool_1: false));
					if (string.CompareOrdinal(magazine_0.AddWeapon(int_0), "OK") == 0)
					{
						return magazine_0;
					}
				}
			}
		}
		return null;
	}

	public static void ScenEdit_DistributeWeaponAtAirbase(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		ActiveUnit activeUnit = null;
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dictionary_["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM141", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid必须是一个字符串");
			}
			try
			{
				activeUnit = scenario_0.ActiveUnits[text];
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM142", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("找不到guid" + text);
			}
		}
		else if (dictionary_.ContainsKey("UNITNAME"))
		{
			string Local_Name = null;
			try
			{
				Local_Name = Conversions.ToString(dictionary_["UNITNAME"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at PM143", "");
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("名称必须是一个字符串");
			}
			if (dictionary_.ContainsKey("SIDE"))
			{
				string text2;
				try
				{
					text2 = Conversions.ToString(dictionary_["SIDE"]);
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception exception_4 = ex4;
					exception_4?.Data.Add("Error at PM144", "");
					GameGeneral.WriteExceptionsToLog(ref exception_4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("分方必须是一个字符串");
				}
				Side side;
				try
				{
					side = LuaUtility.QuerySide(dictionary_, scenario_0);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception exception_5 = ex5;
					exception_5?.Data.Add("Error at PM145", "");
					GameGeneral.WriteExceptionsToLog(ref exception_5);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到分方'" + text2 + "'");
				}
				try
				{
					activeUnit = side.Units.First((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex6)
				{
					ProjectData.SetProjectError(ex6);
					Exception exception_6 = ex6;
					exception_6?.Data.Add("Error at PM146", "");
					GameGeneral.WriteExceptionsToLog(ref exception_6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + Local_Name + "' 分方 '" + text2 + "'");
				}
			}
			else
			{
				try
				{
					activeUnit = scenario_0.ActiveUnits_List.First((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception exception_7 = ex7;
					exception_7?.Data.Add("Error at PM147", "");
					GameGeneral.WriteExceptionsToLog(ref exception_7);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + Local_Name + "'");
				}
			}
		}
		if (activeUnit == null)
		{
			throw new LuaError("需要定义名称或Guid来标识单元。最好是Guid或Side＆Name。");
		}
		if (activeUnit is Group)
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			list.Add(activeUnit);
			if (activeUnit is Group)
			{
				foreach (KeyValuePair<string, ActiveUnit> unit in ((Group)activeUnit).Units)
				{
					if (unit.Value.TotalMagazines.Any())
					{
						list.Add(unit.Value);
					}
				}
			}
			if (list.Any())
			{
				if (dictionary_.ContainsKey("WPN_DBID"))
				{
					int Local_dbid = Conversions.ToInteger(dictionary_["WPN_DBID"]);
					if (dictionary_.ContainsKey("NUMBER"))
					{
						int num = Conversions.ToInteger(dictionary_["NUMBER"]);
						if (num <= 0)
						{
							throw new LuaError("NUMBER must be positive.");
						}
						LockRandom Local_rng = GameGeneral.LockRandom_0;
						list = list.OrderBy((ActiveUnit F) => Local_rng.Next()).ToList();
						int num2 = (int)Math.Round((double)num / (double)list.Count);
						if (num2 <= 0)
						{
							num2 = 1;
						}
						{
							foreach (ActiveUnit item in list)
							{
								if (num > 0)
								{
									Magazine magazine = item.TotalMagazines.First();
									WeaponRec weaponRec = magazine.Weapons.FirstOrDefault((WeaponRec F) => F.int_0 == Local_dbid);
									if (weaponRec == null)
									{
										weaponRec = new WeaponRec(ref scenario_0, Local_dbid, 0, 10000, 15, 1, bool_0: false, bool_1: false);
										magazine.Weapons.Add(weaponRec);
									}
									weaponRec.MaxLoad = 10000;
									num2 = Math.Min(num, num2);
									weaponRec.CurrentLoad += num2;
									num -= num2;
									if (num <= 0)
									{
										break;
									}
									continue;
								}
								break;
							}
							return;
						}
					}
					throw new LuaError("No NUMBER defined.");
				}
				throw new LuaError("No WPN_DBID defined.");
			}
			throw new LuaError("No magazines in group!");
		}
		throw new LuaError("This function needs to be run on a non-single-unit airbase, one with more than a single seperate magazine.");
	}

	public static string ScenEdit_RefuelUnit(LuaTable luaTable_0, Scenario scenario_0)
	{
		LuaSandBox.Singleton().CreateTable();
		ActiveUnit activeUnit = null;
		Side side = null;
		string string_ = "";
		ActiveUnit activeUnit_ = null;
		List<Mission> list_ = null;
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("SIDE"))
		{
			side = LuaUtility.QuerySide(dictionary_, scenario_0);
		}
		string text = LuaUtility.QueryUnit(dictionary_, scenario_0);
		if (text.Length == 0)
		{
			if (dictionary_.ContainsKey("GUID"))
			{
				activeUnit = smethod_0(Conversions.ToString(dictionary_["GUID"]), scenario_0);
				if (side == null)
				{
					side = activeUnit.GetUnitSide();
				}
				if (dictionary_.ContainsKey("TANKER"))
				{
					activeUnit_ = ValidateAUBySide(Conversions.ToString(dictionary_["TANKER"]), side);
				}
				if (dictionary_.ContainsKey("MISSIONS"))
				{
					list_ = new List<Mission>();
					foreach (object item in LuaUtility.ToArray(((LuaTable)dictionary_["MISSIONS"]).GetEnumerator()))
					{
						Mission mission = LuaMission.ValidateMissionBySide(Conversions.ToString(RuntimeHelpers.GetObjectValue(item)), side);
						if (mission != null)
						{
							list_.Add(mission);
						}
					}
				}
				if (activeUnit != null && activeUnit.IsActiveUnit)
				{
					if (!activeUnit.IsOperating())
					{
						throw new LuaError("The specified unit is not operative.");
					}
					if ((activeUnit.GetUnitSide() == side || Module_Side.IsAlliedWithThisSide(activeUnit.GetUnitSide(), side)) && (object)activeUnit.GetType() != typeof(Weapon))
					{
						RefuelIfPossible(activeUnit, scenario_0, ref string_, ref activeUnit_, ref list_);
					}
				}
			}
			if (activeUnit == null)
			{
				return null;
			}
			return string_;
		}
		throw new LuaError(text);
	}

	public static LuaTable ScenEdit_GetContacts(string string_0, Scenario scenario_0)
	{
		Side side = null;
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side2 in array)
		{
			if (string.Equals(side2.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(side2.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
			{
				side = side2;
				break;
			}
		}
		if (side == null)
		{
			return null;
		}
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		foreach (Contact contacts_ in side.Contacts_List)
		{
			LuaWrapper_Contact luaWrapper_Contact = new LuaWrapper_Contact(contacts_, scenario_0, side);
			val[val.Keys.Count + 1] = luaWrapper_Contact;
		}
		foreach (Contact baseContacts_ in side.BaseContacts_List)
		{
			LuaWrapper_Contact luaWrapper_Contact2 = new LuaWrapper_Contact(baseContacts_, scenario_0, side);
			val[val.Keys.Count + 1] = luaWrapper_Contact2;
		}
		foreach (string key in side.m_InfoFacade.Keys)
		{
			LuaWrapper_Contact luaWrapper_Contact3 = new LuaWrapper_Contact(side.m_InfoFacade[key], scenario_0, side);
			val[val.Keys.Count + 1] = luaWrapper_Contact3;
		}
		foreach (string key2 in side.m_HelperFacade.Keys)
		{
			LuaWrapper_Contact luaWrapper_Contact4 = new LuaWrapper_Contact(side.m_HelperFacade[key2], scenario_0, side);
			val[val.Keys.Count + 1] = luaWrapper_Contact4;
		}
		return val;
	}

	public static bool ScenEdit_AttackContact(string string_0, string string_1, LuaTable luaTable_0, Scenario scenario_0)
	{
		ActiveUnit activeUnit = null;
		Contact contact = null;
		ActiveUnit_AI.TargetingEntry._TargetingBehavior targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted;
		string text = null;
		double num = 0.0;
		List<Waypoint> list = new List<Waypoint>();
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		activeUnit = smethod_0(string_0, scenario_0);
		if (activeUnit != null)
		{
			contact = ValidateContactBySceanrio(string_1, scenario_0);
			if (contact == null)
			{
				if (Operators.CompareString(string_1.ToUpper(), "BOL", TextCompare: false) != 0)
				{
					return false;
				}
				string string_2 = null;
				if (dictionary.ContainsKey("LATITUDE"))
				{
					string_2 = Conversions.ToString(dictionary["LATITUDE"]);
				}
				double double_ = LuaUtility.ParseLatitudeString(string_2);
				string_2 = "";
				if (dictionary.ContainsKey("LONGITUDE"))
				{
					string_2 = Conversions.ToString(dictionary["LONGITUDE"]);
				}
				num = LuaUtility.ParseLongitudeString(string_2);
				contact = new ActivationPointContact(double_, num);
			}
			if (dictionary.ContainsKey("COURSE"))
			{
				foreach (object item2 in LuaUtility.ToArray(((LuaTable)dictionary["COURSE"]).GetEnumerator()))
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item2);
					if (objectValue is LuaTable)
					{
						Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator());
						double? num2 = LuaUtility.QueryLongitude(dictionary_);
						double? num3 = LuaUtility.QueryLatitude(dictionary_);
						if (!(!num2.HasValue | !num2.HasValue))
						{
							Waypoint item = new Waypoint(num2.Value, num3.Value, 0f, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.Manual, Waypoint.WaypointCategory.PlottedCourse);
							list.Add(item);
							continue;
						}
						throw new LuaError("路径对象" + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue)) + "需要纬度或经度。");
					}
					throw new LuaError("BOL航点错误");
				}
			}
			if (dictionary.ContainsKey("MODE"))
			{
				text = Conversions.ToString(dictionary["MODE"]);
			}
			switch (text)
			{
			default:
				throw new LuaError("定位行为无效");
			case "2":
			case "ManualTargeted":
				targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted;
				activeUnit.AI.TargetThisContact(contact, bool_0: true, bool_1: true, ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted);
				break;
			case "1":
			case "ManualWeaponAlloc":
			{
				targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc;
				Weapon weapon_ = null;
				Mount mount = null;
				WeaponRec weaponRec = null;
				Loadout loadout = null;
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				int? nullable_ = 1;
				int num7 = 0;
				if (dictionary.ContainsKey("MOUNT"))
				{
					num4 = Conversions.ToInteger(dictionary["MOUNT"]);
				}
				if (dictionary.ContainsKey("WEAPON"))
				{
					num5 = Conversions.ToInteger(dictionary["WEAPON"]);
				}
				if (dictionary.ContainsKey("QTY"))
				{
					num6 = Conversions.ToInteger(dictionary["QTY"]);
				}
				if (activeUnit.IsAircraft)
				{
					loadout = ((Aircraft)activeUnit).Loadout;
				}
				else if (num4 == 0)
				{
					foreach (Mount mount2 in activeUnit.Mounts)
					{
						if (num4 == mount2.DBID)
						{
							break;
						}
						if (mount2.Status == PlatformComponent._ComponentStatus.Destroyed)
						{
							continue;
						}
						foreach (WeaponRec mountWeapon in mount2.MountWeapons)
						{
							if (mountWeapon.int_0 == num5 && mountWeapon.CurrentLoad > 0)
							{
								num4 = mount2.DBID;
								break;
							}
						}
					}
				}
				if ((num4 != 0 || loadout != null) && num5 != 0 && num6 != 0)
				{
					bool flag = false;
					if (num4 <= 0)
					{
						if (loadout != null)
						{
							WeaponRec[] weapons = loadout.Weapons;
							WeaponRec[] array = weapons;
							foreach (WeaponRec weaponRec2 in array)
							{
								if (weaponRec2.int_0 == num5 && weaponRec2.CurrentLoad > 0)
								{
									if (weapon_ == null)
									{
										weapon_ = weaponRec2.GetReferenceWeapon(scenario_0);
										weaponRec = weaponRec2;
									}
									num7 += weaponRec2.CurrentLoad;
								}
							}
						}
					}
					else
					{
						foreach (Mount mount3 in activeUnit.Mounts)
						{
							if (!((mount3.DBID == num4) & (mount3.Status != PlatformComponent._ComponentStatus.Destroyed)))
							{
								continue;
							}
							foreach (WeaponRec mountWeapon2 in mount3.MountWeapons)
							{
								if (mountWeapon2.int_0 != num5)
								{
									continue;
								}
								if (mountWeapon2.CurrentLoad <= 0)
								{
									_ = activeUnit.Weaponry;
									if (mount3.MountMagazine.Weapons.Count > 0 && mount3.MountMagazine.Weapons.Count > 1 && !mountWeapon2.GetHasManualReloadPriority(mount3) && !mountWeapon2.GetReferenceWeapon(activeUnit.ParentScen).IsDecoy && activeUnit.Weaponry.HowManyOfThisWeaponOnMountMagazine(mount3, mountWeapon2.int_0) != 0 && weapon_ == null && !mount3.ReloadPriority.Contains(mountWeapon2.int_0))
									{
										mount3.ReloadPriority.Add(mountWeapon2.int_0);
										weapon_ = mountWeapon2.GetReferenceWeapon(scenario_0);
										weaponRec = mountWeapon2;
										mount = mount3;
										flag = true;
										break;
									}
								}
								else
								{
									if (weapon_ == null)
									{
										weapon_ = mountWeapon2.GetReferenceWeapon(scenario_0);
										weaponRec = mountWeapon2;
										mount = mount3;
									}
									num7 += mountWeapon2.CurrentLoad;
									if (mount3.ReloadPriority.Contains(mountWeapon2.int_0))
									{
										mount3.ReloadPriority.Remove(mountWeapon2.int_0);
									}
								}
							}
							if (weapon_ == null)
							{
								continue;
							}
							break;
						}
					}
					if (weapon_ != null && num6 != 0 && (num7 != 0 || flag))
					{
						foreach (WeaponSalvo item3 in activeUnit.GetUnitSide().WeaponSalvosForThisTarget(contact))
						{
							if (item3.Target != contact || num5 != item3.int_0)
							{
								continue;
							}
							foreach (WeaponSalvo.Shooter item4 in item3.ShootersList.ToList())
							{
								if (Operators.CompareString(item4.ShooterObjectID, activeUnit.ObjectID, TextCompare: false) == 0)
								{
									if (item3.WpnQuantityAssigned - item3.WpnQuantityFired + num6 <= num7)
									{
										break;
									}
									return true;
								}
							}
						}
						activeUnit.AI.TargetThisContact(contact, bool_0: true, bool_1: true, targetingBehavior);
						if (Operators.CompareString(string_1.ToUpper(), "BOL", TextCompare: false) == 0)
						{
							WeaponSalvo weaponSalvo = activeUnit.GetUnitSide().AssignSalvoToTarget(activeUnit.ParentScen, ref weapon_, ref contact, num6, 0, num6, bool_0: true, ref activeUnit.ObjectID, ref nullable_, DateTime.MinValue, DateTime.MinValue);
							if (list.Count > 0)
							{
								foreach (Waypoint item5 in list)
								{
									ArrayExtensions.Add(ref weaponSalvo.PlottedCourse, item5);
								}
							}
						}
						else
						{
							WeaponSalvo weaponSalvo2 = activeUnit.GetUnitSide().AssignSalvoToTarget(activeUnit.ParentScen, ref weapon_, ref contact, num6, 0, num6, bool_0: true, ref activeUnit.ObjectID, ref nullable_, DateTime.MinValue, DateTime.MinValue);
							if (list.Count <= 0)
							{
								activeUnit.AI.ManouverTowardsTarget(0f);
							}
							else
							{
								foreach (Waypoint item6 in list)
								{
									ArrayExtensions.Add(ref weaponSalvo2.PlottedCourse, item6);
								}
							}
						}
						if (flag)
						{
							mount.ReloadPriority.Remove(weaponRec.int_0);
						}
						break;
					}
					return false;
				}
				return false;
			}
			case "0":
			case "AutoTargeted":
				targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted;
				activeUnit.AI.TargetThisContact(contact, bool_0: true, bool_1: true, ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted);
				break;
			}
			return true;
		}
		return false;
	}

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
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM148", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("分方必须是一个字符串");
			}
			try
			{
				side = LuaUtility.QuerySide(dictionary_, scenario_0);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM149", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
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
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception exception_3 = ex3;
					exception_3?.Data.Add("Error at PM150", "");
					GameGeneral.WriteExceptionsToLog(ref exception_3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("分方必须是一个字符串");
				}
			}
			if (Information.IsNothing(text))
			{
				throw new LuaError("side or name must be declared");
			}
			try
			{
				side = LuaUtility.QuerySide(dictionary_, scenario_0);
			}
			catch (Exception ex4)
			{
				ProjectData.SetProjectError(ex4);
				Exception exception_4 = ex4;
				exception_4?.Data.Add("Error at PM151", "");
				GameGeneral.WriteExceptionsToLog(ref exception_4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			if (side != null)
			{
				throw new LuaError("分方" + text + "已经存在");
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
		LuaUtility.ParseSideDict(ref dictionary_);
		if (dictionary_.ContainsKey("SIDE"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dictionary_["SIDE"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM152", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("分方必须是一个字符串");
			}
			try
			{
				side = LuaUtility.QuerySide(dictionary_, scenario_0);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM153", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
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
					scenario_0.DeleteUnitImmediately(activeUnit.ObjectID, bool_0: true, "Deleted via Lua command.");
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
						scenario_0.DeleteUnitImmediately(activeUnit.ObjectID, bool_0: true, "Deleted via Lua command.");
					}
				}
			}
		}
		List<string> list2 = new List<string>();
		foreach (KeyValuePair<string, UnguidedWeapon> unguidedWeapon in scenario_0.UnguidedWeapons)
		{
			if (unguidedWeapon.Value.GetUnitSide() == side)
			{
				list2.Add(unguidedWeapon.Key);
			}
		}
		foreach (string item2 in list2)
		{
			string string_ = item2;
			scenario_0.UnguidedWeapons.Remove(string_);
			side.RemoveWeaponFromSalvos(ref scenario_0, ref string_);
		}
		scenario_0.RemoveSide(side);
		return result;
	}

	public static LuaWrapper_Zone ScenEdit_AddZone(string string_0, int int_0, LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		string text = null;
		Side side = null;
		Zone zone = new Zone();
		List<ReferencePoint> list = new List<ReferencePoint>();
		List<GlobalVariables.ActiveUnitType> list2 = new List<GlobalVariables.ActiveUnitType>();
		bool isLocked = false;
		bool flag = false;
		Module_Unit.Unit unit = null;
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (int_0 != 2)
		{
			side = ValidateSide(string_0, scenario_0);
			if (side == null)
			{
				throw new LuaError("分方" + text + "失踪");
			}
		}
		if (dictionary_.ContainsKey("DESCRIPTION"))
		{
			text = (zone.Description = Conversions.ToString(dictionary_["DESCRIPTION"]));
		}
		if (dictionary_.ContainsKey("ISACTIVE"))
		{
			text = Conversions.ToString(dictionary_["ISACTIVE"]);
			zone.IsActive = Conversions.ToBoolean(text);
		}
		if (dictionary_.ContainsKey("LOCKED"))
		{
			text = Conversions.ToString(dictionary_["LOCKED"]);
			isLocked = Conversions.ToBoolean(text);
		}
		if (dictionary_.ContainsKey("AFFECTS"))
		{
			list2.Clear();
			foreach (object item in LuaUtility.ToArray(((LuaTable)dictionary_["AFFECTS"]).GetEnumerator()))
			{
				string a = RuntimeHelpers.GetObjectValue(item).ToString();
				GlobalVariables.ActiveUnitType activeUnitType = GlobalVariables.ActiveUnitType.None;
				byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.ActiveUnitType));
				int num = 0;
				while (num < array.Length)
				{
					byte b = array[num];
					if (!string.Equals(a, b.ToString(), StringComparison.OrdinalIgnoreCase))
					{
						GlobalVariables.ActiveUnitType activeUnitType2 = (GlobalVariables.ActiveUnitType)b;
						if (!string.Equals(a, activeUnitType2.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							num = checked(num + 1);
							continue;
						}
					}
					activeUnitType = (GlobalVariables.ActiveUnitType)b;
					break;
				}
				if (activeUnitType != 0)
				{
					list2.Add(activeUnitType);
					continue;
				}
				throw new LuaError("受影响的UnitTypes出错！");
			}
		}
		if (dictionary_.ContainsKey("RELATIVETO"))
		{
			string text2 = Conversions.ToString(dictionary_["RELATIVETO"]);
			unit = ValidateAUBySide(text2, side);
			if (unit == null)
			{
				throw new LuaError("缺少单元" + text2 + "从相对方位");
			}
		}
		if (dictionary_.ContainsKey("AREA"))
		{
			ReferencePoint referencePoint = null;
			list.Clear();
			foreach (object item2 in LuaUtility.ToArray(((LuaTable)dictionary_["AREA"]).GetEnumerator()))
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item2);
				if (objectValue.GetType() == typeof(LuaTable))
				{
					LuaSandBox.Singleton().CreateTable();
					referencePoint = LuaReferencePoint.ParseReferencePoint(LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator()), dictionary_, scenario_0, unit);
				}
				if (!Information.IsNothing(referencePoint))
				{
					list.Add(referencePoint);
					continue;
				}
				throw new LuaError("无法创建参考点");
			}
			if (list == null)
			{
				throw new LuaError("参考点错误！");
			}
		}
		Misc.PostureStance postureStance_ = Misc.PostureStance.Neutral;
		if (dictionary_.ContainsKey("MARKAS"))
		{
			text = Conversions.ToString(dictionary_["MARKAS"]);
			Misc.PostureStance result = Misc.PostureStance.Unknown;
			switch (text.ToUpper())
			{
			case "U":
				text = "unfriendly";
				break;
			case "N":
				text = "neutral";
				break;
			case "H":
				text = "hostile";
				break;
			case "F":
				text = "friendly";
				break;
			}
			if (Enum.TryParse<Misc.PostureStance>(text, ignoreCase: true, out result) & Enum.IsDefined(typeof(Misc.PostureStance), result))
			{
				postureStance_ = result;
			}
			else
			{
				byte[] array2 = (byte[])Enum.GetValues(typeof(Misc.PostureStance));
				int num2 = 0;
				while (num2 < array2.Length)
				{
					byte b2 = array2[num2];
					if (!string.Equals(text, b2.ToString(), StringComparison.OrdinalIgnoreCase))
					{
						string a2 = text;
						GlobalVariables.ActiveUnitType activeUnitType3 = (GlobalVariables.ActiveUnitType)b2;
						if (!string.Equals(a2, activeUnitType3.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							num2 = checked(num2 + 1);
							continue;
						}
					}
					postureStance_ = (Misc.PostureStance)b2;
					break;
				}
			}
		}
		if (dictionary_.ContainsKey("HIDDEN") && LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_["HIDDEN"])).GetValueOrDefault())
		{
			flag = true;
		}
		if (dictionary_.ContainsKey("AREACOLOR"))
		{
			text = Conversions.ToString(dictionary_["AREACOLOR"]);
			Color areaColor = Color.FromName(text);
			if (areaColor.IsKnownColor)
			{
				zone.AreaColor = areaColor;
			}
			else
			{
				try
				{
					zone.AreaColor = ColorTranslator.FromHtml("#" + text);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at PM154", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		switch (int_0)
		{
		default:
		{
			ExclusionZone exclusionZone = new ExclusionZone(zone.Description, side, list, postureStance_, list2);
			exclusionZone.IsActive = zone.IsActive;
			exclusionZone.AreaColor = zone.AreaColor;
			side.ExclusionZones.Add(exclusionZone);
			foreach (ReferencePoint item3 in list)
			{
				if (flag)
				{
					if (side.RefPoints.Contains(item3))
					{
						side.RefPoints.Remove(item3);
					}
				}
				else if (!side.RefPoints.Contains(item3))
				{
					side.RefPoints.Add(item3);
				}
			}
			return new LuaWrapper_Zone(exclusionZone, scenario_0, side);
		}
		case 2:
		{
			scenario_0.CreateNatureSideIfNeeded();
			Side natureSide = scenario_0.GetNatureSide();
			if (natureSide != null)
			{
				CustomEnvironmentZone customEnvironmentZone = new CustomEnvironmentZone(zone.Description, list, scenario_0, natureSide, new Weather.WeatherProfile());
				if (customEnvironmentZone != null)
				{
					customEnvironmentZone.AreaColor = zone.AreaColor;
					natureSide.CustomEnvironmentZones.Add(customEnvironmentZone);
					foreach (ReferencePoint item4 in list)
					{
						if (flag)
						{
							if (natureSide.RefPoints.Contains(item4))
							{
								natureSide.RefPoints.Remove(item4);
							}
						}
						else if (!natureSide.RefPoints.Contains(item4))
						{
							natureSide.RefPoints.Add(item4);
						}
					}
					return new LuaWrapper_Zone(customEnvironmentZone, scenario_0, natureSide);
				}
			}
			return null;
		}
		case 0:
		{
			NoNavZone noNavZone = new NoNavZone(zone.Description, list, scenario_0, side, list2);
			noNavZone.IsActive = zone.IsActive;
			noNavZone.IsLocked = isLocked;
			noNavZone.AreaColor = zone.AreaColor;
			side.NoNavZones.Add(noNavZone);
			foreach (ReferencePoint item5 in list)
			{
				if (flag)
				{
					if (side.RefPoints.Contains(item5))
					{
						side.RefPoints.Remove(item5);
					}
				}
				else if (!side.RefPoints.Contains(item5))
				{
					side.RefPoints.Add(item5);
				}
			}
			return new LuaWrapper_Zone(noNavZone, scenario_0, side);
		}
		case -925:
		{
			Zone zone2 = new Zone(zone.Description, list);
			zone2.IsActive = zone.IsActive;
			zone2.AreaColor = zone.AreaColor;
			side.StandardZones.Add(zone2);
			foreach (ReferencePoint item6 in list)
			{
				if (flag)
				{
					if (side.RefPoints.Contains(item6))
					{
						side.RefPoints.Remove(item6);
					}
				}
				else if (!side.RefPoints.Contains(item6))
				{
					side.RefPoints.Add(item6);
				}
			}
			return new LuaWrapper_Zone(zone2, scenario_0, side);
		}
		}
	}

	public static LuaWrapper_Zone ScenEdit_SetZone(string string_0, int int_0, LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		string text = null;
		Side side = null;
		Zone zone = new Zone();
		List<ReferencePoint> list = new List<ReferencePoint>();
		List<GlobalVariables.ActiveUnitType> list2 = new List<GlobalVariables.ActiveUnitType>();
		bool isLocked = false;
		bool flag = false;
		LuaUtility.ParseUnitDict(ref dictionary_);
		side = ValidateSide(string_0, scenario_0);
		if (side != null)
		{
			if (dictionary_.ContainsKey("LAYER"))
			{
				zone.SetLayer(side, Conversions.ToInteger(dictionary_["LAYER"]));
			}
			if (dictionary_.ContainsKey("DESCRIPTION"))
			{
				text = (zone.Description = Conversions.ToString(dictionary_["DESCRIPTION"]));
			}
			if (dictionary_.ContainsKey("AREACOLOR"))
			{
				text = Conversions.ToString(dictionary_["AREACOLOR"]);
				Color areaColor = Color.FromName(text);
				if (areaColor.IsKnownColor)
				{
					zone.AreaColor = areaColor;
				}
				else
				{
					try
					{
						zone.AreaColor = ColorTranslator.FromHtml("#" + text);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at PM155", "");
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
			if (dictionary_.ContainsKey("ISACTIVE"))
			{
				text = Conversions.ToString(dictionary_["ISACTIVE"]);
				zone.IsActive = Conversions.ToBoolean(text);
			}
			if (dictionary_.ContainsKey("LOCKED"))
			{
				text = Conversions.ToString(dictionary_["LOCKED"]);
				isLocked = Conversions.ToBoolean(text);
			}
			if (dictionary_.ContainsKey("RENAME"))
			{
				string text5 = (zone.Name = Conversions.ToString(dictionary_["RENAME"]));
				string text2 = text5;
				text = text2;
			}
			if (dictionary_.ContainsKey("AFFECTS"))
			{
				list2.Clear();
				foreach (object item in LuaUtility.ToArray(((LuaTable)dictionary_["AFFECTS"]).GetEnumerator()))
				{
					string a = RuntimeHelpers.GetObjectValue(item).ToString().ToLower();
					GlobalVariables.ActiveUnitType activeUnitType = GlobalVariables.ActiveUnitType.None;
					byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.ActiveUnitType));
					int num = 0;
					while (num < array.Length)
					{
						byte b = array[num];
						if (!string.Equals(a, b.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							GlobalVariables.ActiveUnitType activeUnitType2 = (GlobalVariables.ActiveUnitType)b;
							if (!string.Equals(a, activeUnitType2.ToString(), StringComparison.OrdinalIgnoreCase))
							{
								num = checked(num + 1);
								continue;
							}
						}
						activeUnitType = (GlobalVariables.ActiveUnitType)b;
						break;
					}
					if (activeUnitType != 0)
					{
						list2.Add(activeUnitType);
						continue;
					}
					throw new LuaError("受影响的UnitTypes出错！");
				}
			}
			if (dictionary_.ContainsKey("AREA"))
			{
				list.Clear();
				foreach (object item2 in LuaUtility.ToArray(((LuaTable)dictionary_["AREA"]).GetEnumerator()))
				{
					object Local_o = RuntimeHelpers.GetObjectValue(item2);
					ReferencePoint referencePoint = null;
					if (Local_o is LuaTable)
					{
						string text3 = "";
						double? num2 = null;
						double? num3 = null;
						Module_Unit.Unit unit = null;
						double? num4 = null;
						double? num5 = null;
						Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)Local_o).GetEnumerator());
						if (dictionary.ContainsKey("HIDDEN"))
						{
							flag = true;
						}
						if (dictionary.ContainsKey("NAME"))
						{
							text3 = Conversions.ToString(dictionary["NAME"]);
						}
						else
						{
							scenario_0.UnitsAutoIncrement++;
							object obj2 = (dictionary["NAME"] = "RP-" + Conversions.ToString(scenario_0.UnitsAutoIncrement));
							object obj = obj2;
							text3 = (string)obj;
						}
						if (dictionary.ContainsKey("BEARING") && dictionary.ContainsKey("DISTANCE"))
						{
							if (Information.IsNothing(unit))
							{
								throw new LuaError("没有为相对方位定义单元");
							}
							num4 = Conversions.ToDouble(dictionary["BEARING"]);
							num5 = Conversions.ToDouble(dictionary["DISTANCE"]);
							Geodesic_Vincenty.TCoord tcoord_ = new Geodesic_Vincenty.TCoord(unit.GetLatitude(), unit.GetLongitude());
							Geodesic_Vincenty.TCoord tcoord_2 = default(Geodesic_Vincenty.TCoord);
							Geodesic_Vincenty.fw_vincenty_wgs84(ref tcoord_, ref tcoord_2, num4.Value, num5.Value);
							num2 = tcoord_2.Lat;
							num3 = tcoord_2.Lon;
						}
						else
						{
							num2 = LuaUtility.QueryLatitude(dictionary);
							if (!num2.HasValue)
							{
								throw new LuaError("缺少'纬度'");
							}
							num3 = LuaUtility.QueryLongitude(dictionary);
							if (!num3.HasValue)
							{
								throw new LuaError("缺少'经度'");
							}
						}
						referencePoint = new ReferencePoint();
						referencePoint.Longitude = num3.Value;
						referencePoint.Latitude = num2.Value;
						referencePoint.Name = text3;
						list.Add(referencePoint);
						continue;
					}
					if (!Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o.ToString(), StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase))))
					{
						referencePoint = side.RefPoints.First((ReferencePoint s) => string.Equals(s.Name, Local_o.ToString(), StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase));
					}
					if (Information.IsNothing(referencePoint))
					{
						referencePoint = new ReferencePoint();
						referencePoint.Name = Local_o.ToString();
						referencePoint.Longitude = 1.79769313486231E+308;
						referencePoint.Latitude = 1.79769313486231E+308;
						list.Add(referencePoint);
					}
					else
					{
						list.Add(referencePoint);
					}
				}
				if (list == null)
				{
					throw new LuaError("参考点错误！");
				}
				if (!flag)
				{
					foreach (ReferencePoint item3 in list)
					{
						if (item3.Longitude != 1.79769313486231E+308 && !side.RefPoints.Contains(item3))
						{
							side.RefPoints.Add(item3);
						}
					}
				}
			}
			Misc.PostureStance markViolatorAs = Misc.PostureStance.Neutral;
			if (dictionary_.ContainsKey("MARKAS"))
			{
				text = Conversions.ToString(dictionary_["MARKAS"]);
				Misc.PostureStance result = Misc.PostureStance.Unknown;
				if (Enum.TryParse<Misc.PostureStance>(text, ignoreCase: true, out result) & Enum.IsDefined(typeof(Misc.PostureStance), result))
				{
					markViolatorAs = result;
				}
				else
				{
					byte[] array2 = (byte[])Enum.GetValues(typeof(Misc.PostureStance));
					int num6 = 0;
					while (num6 < array2.Length)
					{
						byte b2 = array2[num6];
						if (!string.Equals(text, b2.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							string a2 = text;
							GlobalVariables.ActiveUnitType activeUnitType3 = (GlobalVariables.ActiveUnitType)b2;
							if (!string.Equals(a2, activeUnitType3.ToString(), StringComparison.OrdinalIgnoreCase))
							{
								num6 = checked(num6 + 1);
								continue;
							}
						}
						markViolatorAs = (Misc.PostureStance)b2;
						break;
					}
				}
			}
			switch (int_0)
			{
			default:
			{
				ExclusionZone exclusionZone = null;
				foreach (ExclusionZone exclusionZone2 in side.ExclusionZones)
				{
					if (Operators.CompareString(exclusionZone2.ObjectID, zone.Description, TextCompare: false) == 0 || Operators.CompareString(exclusionZone2.Name, zone.Description, TextCompare: false) == 0 || Operators.CompareString(exclusionZone2.Description, zone.Description, TextCompare: false) == 0)
					{
						exclusionZone = exclusionZone2;
						break;
					}
				}
				if (Information.IsNothing(exclusionZone))
				{
					throw new LuaError("不存在具有此名称或ID的封锁区。");
				}
				if (dictionary_.ContainsKey("DESCRIPTION"))
				{
					exclusionZone.Description = zone.Description;
				}
				if (dictionary_.ContainsKey("AREACOLOR"))
				{
					exclusionZone.AreaColor = zone.AreaColor;
				}
				if (dictionary_.ContainsKey("ISACTIVE"))
				{
					exclusionZone.IsActive = zone.IsActive;
				}
				if (dictionary_.ContainsKey("RENAME"))
				{
					exclusionZone.Description = zone.Name;
				}
				if (dictionary_.ContainsKey("AFFECTS"))
				{
					exclusionZone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
					foreach (GlobalVariables.ActiveUnitType item4 in list2)
					{
						exclusionZone.AffectedUnitTypes.Add(item4);
					}
				}
				if (dictionary_.ContainsKey("MARKAS"))
				{
					exclusionZone.MarkViolatorAs = markViolatorAs;
				}
				if (dictionary_.ContainsKey("AREA"))
				{
					foreach (ReferencePoint Local_z3 in exclusionZone.Area)
					{
						list.First((ReferencePoint s) => s.Longitude == 1.79769313486231E+308 && (string.Equals(s.Name, Local_z3.Name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_z3.Name, StringComparison.OrdinalIgnoreCase)));
					}
					exclusionZone.Area = list;
				}
				return new LuaWrapper_Zone(exclusionZone, scenario_0, side);
			}
			case 2:
				throw new LuaError("Use scenario side object function side:getcustomenvironmentzone() to change values on CustomEnvironmentZones.");
			case 0:
			{
				NoNavZone noNavZone = null;
				foreach (NoNavZone noNavZone2 in side.NoNavZones)
				{
					if (Operators.CompareString(noNavZone2.ObjectID, zone.Description, TextCompare: false) == 0 || Operators.CompareString(noNavZone2.Name, zone.Description, TextCompare: false) == 0 || Operators.CompareString(noNavZone2.Description, zone.Description, TextCompare: false) == 0)
					{
						noNavZone = noNavZone2;
						break;
					}
				}
				if (Information.IsNothing(noNavZone))
				{
					throw new LuaError("没有此名称或ID的禁航区域。");
				}
				if (dictionary_.ContainsKey("DESCRIPTION"))
				{
					noNavZone.Description = zone.Description;
				}
				if (dictionary_.ContainsKey("AREACOLOR"))
				{
					noNavZone.AreaColor = zone.AreaColor;
				}
				if (dictionary_.ContainsKey("ISACTIVE"))
				{
					noNavZone.IsActive = zone.IsActive;
				}
				if (dictionary_.ContainsKey("LOCKED"))
				{
					noNavZone.IsLocked = isLocked;
				}
				if (dictionary_.ContainsKey("RENAME"))
				{
					noNavZone.Description = zone.Name;
				}
				if (dictionary_.ContainsKey("AFFECTS"))
				{
					noNavZone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
					foreach (GlobalVariables.ActiveUnitType item5 in list2)
					{
						noNavZone.AffectedUnitTypes.Add(item5);
					}
				}
				if (dictionary_.ContainsKey("AREA"))
				{
					foreach (ReferencePoint Local_z in noNavZone.Area)
					{
						list.First((ReferencePoint s) => s.Longitude == 1.79769313486231E+308 && (string.Equals(s.Name, Local_z.Name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_z.Name, StringComparison.OrdinalIgnoreCase)));
					}
					noNavZone.Area = list;
				}
				return new LuaWrapper_Zone(noNavZone, scenario_0, side);
			}
			case -925:
			{
				Zone zone2 = null;
				foreach (Zone standardZone in side.StandardZones)
				{
					if (Operators.CompareString(standardZone.ObjectID, zone.Description, TextCompare: false) == 0 || Operators.CompareString(standardZone.Name, zone.Description, TextCompare: false) == 0 || Operators.CompareString(standardZone.Description, zone.Description, TextCompare: false) == 0)
					{
						zone2 = standardZone;
						break;
					}
				}
				if (Information.IsNothing(zone2))
				{
					throw new LuaError("没有此名称或ID的禁航区域。");
				}
				if (dictionary_.ContainsKey("DESCRIPTION"))
				{
					zone2.Description = zone.Description;
				}
				if (dictionary_.ContainsKey("AREACOLOR"))
				{
					zone2.AreaColor = zone.AreaColor;
				}
				if (dictionary_.ContainsKey("ISACTIVE"))
				{
					zone2.IsActive = zone.IsActive;
				}
				if (dictionary_.ContainsKey("RENAME"))
				{
					zone2.Description = zone.Name;
				}
				if (dictionary_.ContainsKey("AFFECTS"))
				{
					zone2.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
					foreach (GlobalVariables.ActiveUnitType item6 in list2)
					{
						zone2.AffectedUnitTypes.Add(item6);
					}
				}
				if (dictionary_.ContainsKey("AREA"))
				{
					foreach (ReferencePoint Local_z2 in zone2.Area)
					{
						list.First((ReferencePoint s) => s.Longitude == 1.79769313486231E+308 && (string.Equals(s.Name, Local_z2.Name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_z2.Name, StringComparison.OrdinalIgnoreCase)));
					}
					zone2.Area = list;
				}
				return new LuaWrapper_Zone(zone2, scenario_0, side);
			}
			}
		}
		throw new LuaError("分方" + text + "失踪");
	}

	public static LuaWrapper_Zone ScenEdit_RemoveZone(string string_0, int int_0, LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		string text = null;
		Side side = null;
		Zone zone = new Zone();
		new List<ReferencePoint>();
		new List<GlobalVariables.ActiveUnitType>();
		LuaUtility.ParseUnitDict(ref dictionary_);
		side = ValidateSide(string_0, scenario_0);
		if (side == null)
		{
			throw new LuaError("分方" + text + "失踪");
		}
		if (dictionary_.ContainsKey("DESCRIPTION"))
		{
			text = (zone.Description = Conversions.ToString(dictionary_["DESCRIPTION"]));
		}
		switch (int_0)
		{
		default:
		{
			ExclusionZone exclusionZone = null;
			foreach (ExclusionZone exclusionZone2 in side.ExclusionZones)
			{
				if (Operators.CompareString(exclusionZone2.ObjectID, zone.Description, TextCompare: false) == 0 || Operators.CompareString(exclusionZone2.Name, zone.Description, TextCompare: false) == 0 || Operators.CompareString(exclusionZone2.Description, zone.Description, TextCompare: false) == 0)
				{
					exclusionZone = exclusionZone2;
					break;
				}
			}
			if (Information.IsNothing(zone))
			{
				throw new LuaError("不存在具有此名称或ID的封锁区。");
			}
			side.ExclusionZones.Remove(exclusionZone);
			return new LuaWrapper_Zone(exclusionZone, scenario_0, side);
		}
		case 2:
			if (side == scenario_0.GetNatureSide())
			{
				CustomEnvironmentZone customEnvironmentZone = null;
				foreach (CustomEnvironmentZone customEnvironmentZone2 in side.CustomEnvironmentZones)
				{
					if (Operators.CompareString(customEnvironmentZone2.ObjectID, zone.Description, TextCompare: false) == 0 || Operators.CompareString(customEnvironmentZone2.Name, zone.Description, TextCompare: false) == 0 || Operators.CompareString(customEnvironmentZone2.Description, zone.Description, TextCompare: false) == 0)
					{
						customEnvironmentZone = customEnvironmentZone2;
					}
				}
				if (customEnvironmentZone == null)
				{
					throw new LuaError("No Custom Environment Zone exists with this name or ID.");
				}
				side.CustomEnvironmentZones.Remove(customEnvironmentZone);
				return null;
			}
			throw new LuaError("Custom Environment Zones side must be scenario 'nature' side.");
		case 0:
		{
			NoNavZone noNavZone = null;
			foreach (NoNavZone noNavZone2 in side.NoNavZones)
			{
				if (Operators.CompareString(noNavZone2.ObjectID, zone.Description, TextCompare: false) == 0 || Operators.CompareString(noNavZone2.Name, zone.Description, TextCompare: false) == 0 || Operators.CompareString(noNavZone2.Description, zone.Description, TextCompare: false) == 0)
				{
					noNavZone = noNavZone2;
					break;
				}
			}
			if (Information.IsNothing(zone))
			{
				throw new LuaError("没有此名称或ID的禁航区域。");
			}
			side.NoNavZones.Remove(noNavZone);
			return new LuaWrapper_Zone(noNavZone, scenario_0, side);
		}
		case -925:
		{
			Zone zone2 = null;
			foreach (Zone standardZone in side.StandardZones)
			{
				if (Operators.CompareString(standardZone.ObjectID, zone.Description, TextCompare: false) == 0 || Operators.CompareString(standardZone.Name, zone.Description, TextCompare: false) == 0 || Operators.CompareString(standardZone.Description, zone.Description, TextCompare: false) == 0)
				{
					zone2 = standardZone;
					break;
				}
			}
			if (Information.IsNothing(zone))
			{
				throw new LuaError("No standard zone exists with this name or ID.");
			}
			side.StandardZones.Remove(zone2);
			return new LuaWrapper_Zone(zone2, scenario_0, side);
		}
		}
	}

	public static bool ScenEdit_IsUnitInZone(string string_0, string string_1, string string_2, Scenario scenario_0)
	{
		ActiveUnit activeUnit_ = smethod_0(string_0, scenario_0);
		Side side = LuaUtility.QuerySideObject(string_2, scenario_0);
		Zone zone = null;
		foreach (Zone standardZone in side.StandardZones)
		{
			if (Operators.CompareString(string_1, standardZone.Description, TextCompare: false) == 0 || Operators.CompareString(string_1, standardZone.ObjectID, TextCompare: false) == 0)
			{
				zone = standardZone;
				break;
			}
		}
		if (Information.IsNothing(zone))
		{
			return false;
		}
		return zone.ResetDescriptor(activeUnit_);
	}

	public static bool ScenEdit_TransferCargo(string string_0, string string_1, LuaTable luaTable_0, Scenario scenario_0)
	{
		bool result = false;
		List<Cargo> list = new List<Cargo>();
		new List<ActiveUnit>();
		ActiveUnit activeUnit = null;
		ActiveUnit activeUnit2 = null;
		try
		{
			activeUnit = smethod_0(string_0, scenario_0);
			activeUnit2 = smethod_0(string_1, scenario_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at PM156", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (Information.IsNothing(activeUnit))
		{
			throw new LuaError("从单元找不到！");
		}
		if (Information.IsNothing(activeUnit2))
		{
			throw new LuaError("找不到单元！");
		}
		ActiveUnit activeUnit3 = null;
		ActiveUnit activeUnit4 = null;
		switch (activeUnit.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			if (((Aircraft_AirOps)activeUnit.AirOps).CanBeRearmedRightNow())
			{
				activeUnit3 = ((Aircraft)activeUnit).AirOps.CurrentHostUnit;
				break;
			}
			throw new LuaError("From unit not available: not parked!");
		case GlobalVariables.ActiveUnitType.Ship:
		case GlobalVariables.ActiveUnitType.Submarine:
			if (activeUnit.DockingOps.CurrentHostUnit == null)
			{
				throw new LuaError("From unit not available: Not docked!");
			}
			activeUnit3 = activeUnit.DockingOps.CurrentHostUnit;
			break;
		default:
			throw new LuaError("From unit is not cargo capable.");
		case GlobalVariables.ActiveUnitType.Facility:
		case GlobalVariables.ActiveUnitType.Vehicle:
			if (activeUnit.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
			{
				throw new LuaError("From unit not available: it is in cargo!");
			}
			if (activeUnit.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Docked)
			{
				activeUnit3 = activeUnit.DockingOps.CurrentHostUnit;
			}
			break;
		}
		if (activeUnit3 != null && activeUnit3.IsFixedFacility && activeUnit3.IsGroupMember())
		{
			activeUnit3 = activeUnit3.GetParentGroup();
		}
		switch (activeUnit2.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			if (((Aircraft_AirOps)activeUnit2.AirOps).CanBeRearmedRightNow())
			{
				activeUnit4 = ((Aircraft)activeUnit2).AirOps.CurrentHostUnit;
				break;
			}
			throw new LuaError("To unit not available: not parked!");
		case GlobalVariables.ActiveUnitType.Ship:
		case GlobalVariables.ActiveUnitType.Submarine:
			if (activeUnit2.DockingOps.CurrentHostUnit == null)
			{
				throw new LuaError("To unit not available: Not docked!");
			}
			activeUnit4 = activeUnit2.DockingOps.CurrentHostUnit;
			break;
		default:
			throw new LuaError("To unit is not cargo capable.");
		case GlobalVariables.ActiveUnitType.Facility:
		case GlobalVariables.ActiveUnitType.Vehicle:
			if (activeUnit2.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
			{
				throw new LuaError("To unit not available: it is in cargo!");
			}
			if (activeUnit.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Docked)
			{
				activeUnit4 = activeUnit2.DockingOps.CurrentHostUnit;
			}
			break;
		}
		if (activeUnit4 != null && activeUnit4.IsFixedFacility && activeUnit4.IsGroupMember())
		{
			activeUnit4 = activeUnit4.GetParentGroup();
		}
		if (activeUnit4 != null && activeUnit3 != null)
		{
			if (activeUnit4 != activeUnit3)
			{
				throw new LuaError("From unit and To unit are at different host facilities!");
			}
		}
		else if (Module_Unit.RangeToUnit_Horiz(activeUnit, activeUnit2) > 2f)
		{
			throw new LuaError("From unit and To unit are beyond 2nm cargo transfer range!");
		}
		try
		{
			List<object> list2 = LuaUtility.ToArray(luaTable_0.GetEnumerator());
			ICargoHost obj = (ICargoHost)activeUnit2;
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			CargoType cargoType = CargoType.NoCargo;
			num = CargoHostHelper.GetAvailableMass(obj, obj.CargoArray);
			num2 = CargoHostHelper.GetAvailableArea(obj, obj.CargoArray);
			num3 = CargoHostHelper.GetAvailableCrewSpace(obj, obj.CargoArray);
			cargoType = obj.GetCargo_Type();
			foreach (object item in list2)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				int num4 = 0;
				int num5 = 0;
				string text = null;
				if (objectValue is LuaTable)
				{
					List<object> list3 = LuaUtility.ToArray(((LuaTable)objectValue).GetEnumerator());
					if (list3.Count == 1)
					{
						num5 = Conversions.ToInteger(list3[0]);
						num4 = 1;
					}
					else
					{
						num5 = Conversions.ToInteger(list3[1]);
						num4 = Conversions.ToInteger(list3[0]);
					}
				}
				else
				{
					text = Conversions.ToString(objectValue);
					num4 = 1;
				}
				if (num4 < 1 || (num5 < 1 && Information.IsNothing(text)))
				{
					continue;
				}
				Cargo[] onboardCargo = activeUnit.OnboardCargo;
				Cargo[] array = onboardCargo;
				foreach (Cargo cargo in array)
				{
					if (cargo.RequiredCargoType <= cargoType && (num5 <= 0 || cargo.CargoObjectDBID == num5) && (Information.IsNothing(text) || Operators.CompareString(text, cargo.CargoObjectID, TextCompare: false) == 0))
					{
						if (num4 > 0 && ((num >= (double)cargo.RequiredMass) & (num2 >= (double)cargo.RequiredArea) & (num3 >= (double)cargo.RequiredCrewSpace)))
						{
							list.Add(cargo);
							num -= (double)cargo.RequiredMass;
							num2 -= (double)cargo.RequiredArea;
							num3 -= (double)cargo.RequiredCrewSpace;
							num4--;
						}
						if (num4 < 1)
						{
							break;
						}
					}
				}
			}
			int num6 = activeUnit.OnboardCargo.Count();
			if (list.Count <= 0)
			{
				return result;
			}
			ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(activeUnit, activeUnit2, list);
			if (activeUnit2 is Ship)
			{
				activeUnit2.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Readying;
				activeUnit2.DockingOps.ConditionTimer = Math.Max(activeUnit2.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(activeUnit2, list));
			}
			else if (activeUnit2 is Aircraft)
			{
				((Aircraft)activeUnit2).AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
				((Aircraft)activeUnit2).AirOps.ConditionTimer = Math.Max(((Aircraft)activeUnit2).AirOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(activeUnit2, list));
			}
			else if (activeUnit2 is Vehicle)
			{
				if (activeUnit2.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Docked)
				{
					activeUnit2.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Readying;
				}
				else
				{
					activeUnit2.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.TransferringCargo;
				}
				activeUnit2.DockingOps.ConditionTimer = Math.Max(activeUnit2.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(activeUnit2, list));
			}
			if (num6 <= activeUnit.OnboardCargo.Count())
			{
				return result;
			}
			return true;
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at PM157", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static bool ScenEdit_UnloadCargo(string string_0, LuaTable luaTable_0, Scenario scenario_0)
	{
		List<Cargo> list = new List<Cargo>();
		ActiveUnit activeUnit = null;
		try
		{
			activeUnit = smethod_0(string_0, scenario_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at PM158", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (Information.IsNothing(activeUnit))
		{
			throw new LuaError("从单元找不到！");
		}
		if (activeUnit.HasCargo)
		{
			List<object> list2 = new List<object>();
			if (!Information.IsNothing(luaTable_0))
			{
				list2 = LuaUtility.ToArray(luaTable_0.GetEnumerator());
			}
			try
			{
				if (list2.Count > 0)
				{
					foreach (object item in list2)
					{
						object objectValue = RuntimeHelpers.GetObjectValue(item);
						int num = 0;
						int num2 = 0;
						string text = null;
						if (objectValue is LuaTable)
						{
							List<object> list3 = LuaUtility.ToArray(((LuaTable)objectValue).GetEnumerator());
							if (list3.Count == 1)
							{
								num2 = Conversions.ToInteger(list3[0]);
								num = 1;
							}
							else
							{
								num2 = Conversions.ToInteger(list3[1]);
								num = Conversions.ToInteger(list3[0]);
							}
						}
						else
						{
							text = Conversions.ToString(objectValue);
							num = 1;
						}
						if (num < 1 || (num2 < 1 && Information.IsNothing(text)))
						{
							continue;
						}
						Cargo[] onboardCargo = activeUnit.OnboardCargo;
						Cargo[] array = onboardCargo;
						foreach (Cargo cargo in array)
						{
							if ((num2 <= 0 || cargo.CargoObjectDBID == num2) && (Information.IsNothing(text) || Operators.CompareString(text, cargo.CargoObjectID, TextCompare: false) == 0))
							{
								if (num > 0)
								{
									list.Add(cargo);
									num--;
								}
								if (num < 1)
								{
									break;
								}
							}
						}
					}
				}
				if (activeUnit.IsActiveUnit)
				{
					if (activeUnit is Aircraft)
					{
						Aircraft aircraft = (Aircraft)activeUnit;
						if (((Aircraft_AirOps)activeUnit.AirOps).CanBeRearmedRightNow())
						{
							aircraft.AirOps.UnloadCargo();
						}
						else
						{
							if (aircraft.Loadout.Cargo_ParadropCapable)
							{
								aircraft.AirOps.UnloadCargoParadrop();
							}
							if (aircraft.OnboardCargo.Count() > 0 && aircraft.IsHelicopter)
							{
								aircraft.AirOps.SettleForCargoTransfer();
							}
						}
					}
					else if (list.Count <= 0)
					{
						if (activeUnit.DockingOps.CurrentHostUnit == null)
						{
							if (activeUnit is Ship)
							{
								if (activeUnit.DockingOps.RegisterClient())
								{
									activeUnit.DockingOps.SettleForCargoTransfer();
								}
							}
							else if ((activeUnit is Vehicle || activeUnit is Facility) && Module_Unit.ResetTokenizer(activeUnit))
							{
								activeUnit.DockingOps.SettleForCargoTransfer();
							}
						}
						else if (activeUnit.DockingOps.CurrentHostUnit.IsFixedFacility)
						{
							Cargo.UnloadCargoAtLocation(activeUnit, ref activeUnit.OnboardCargo, null, activeUnit.GetLatitude(), activeUnit.GetLongitude(), activeUnit.ParentScen, activeUnit.GetUnitSide(), bool_0: false);
						}
					}
					else
					{
						Cargo.UnloadCargoAtLocation(activeUnit, ref activeUnit.OnboardCargo, list, activeUnit.GetLatitude(), activeUnit.GetLongitude(), activeUnit.ParentScen, activeUnit.GetUnitSide(), bool_0: false);
					}
				}
				return true;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM159", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		throw new LuaError(activeUnit.Name + "没有船上货物！");
	}

	public static LuaTable ScenEdit_GetFormation(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		ActiveUnit activeUnit = null;
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dictionary_["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM160", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid必须是一个字符串");
			}
			try
			{
				activeUnit = scenario_0.ActiveUnits[text];
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM161", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("找不到guid" + text);
			}
		}
		else if (dictionary_.ContainsKey("UNITNAME"))
		{
			string Local_Name = null;
			try
			{
				Local_Name = Conversions.ToString(dictionary_["UNITNAME"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at PM162", "");
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("名称必须是一个字符串");
			}
			if (dictionary_.ContainsKey("SIDE"))
			{
				string text2;
				try
				{
					text2 = Conversions.ToString(dictionary_["SIDE"]);
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception exception_4 = ex4;
					exception_4?.Data.Add("Error at PM163", "");
					GameGeneral.WriteExceptionsToLog(ref exception_4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("分方必须是一个字符串");
				}
				Side side;
				try
				{
					side = LuaUtility.QuerySide(dictionary_, scenario_0);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception exception_5 = ex5;
					exception_5?.Data.Add("Error at PM164", "");
					GameGeneral.WriteExceptionsToLog(ref exception_5);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到分方'" + text2 + "'");
				}
				try
				{
					activeUnit = side.Units.First((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex6)
				{
					ProjectData.SetProjectError(ex6);
					Exception exception_6 = ex6;
					exception_6?.Data.Add("Error at PM165", "");
					GameGeneral.WriteExceptionsToLog(ref exception_6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + Local_Name + "' 分方 '" + text2 + "'");
				}
			}
			else
			{
				try
				{
					activeUnit = scenario_0.ActiveUnits_List.First((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception exception_7 = ex7;
					exception_7?.Data.Add("Error at PM166", "");
					GameGeneral.WriteExceptionsToLog(ref exception_7);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到单元'" + Local_Name + "'");
				}
			}
		}
		if (activeUnit == null)
		{
			throw new LuaError("需要定义名称或Guid来标识单元。最好是Guid或Side＆Name。");
		}
		if (activeUnit.IsGroup)
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			Group group = (Group)activeUnit;
			ActiveUnit groupLead = group.GroupLead;
			foreach (ActiveUnit value in group.Units.Values)
			{
				if (value.IsGroupLead())
				{
					val["lead"] = value.ObjectID;
					continue;
				}
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				ActiveUnit_Navigator.FormationStation unitFormationStation = value.Navigator.UnitFormationStation;
				val2["guid"] = value.ObjectID;
				val2["bearing"] = unitFormationStation.Bearing;
				val2["type"] = unitFormationStation.BearingType.ToString();
				val2["distance"] = unitFormationStation.Distance;
				val2["sprint"] = value.Navigator.SprintDrift.ToString();
				Tuple<double, double> latitudeAndLongitude = unitFormationStation.GetLatitudeAndLongitude(value, groupLead);
				val2["latitude"] = latitudeAndLongitude.Item1;
				val2["longitude"] = latitudeAndLongitude.Item2;
				val[val.Keys.Count.ToString()] = val2;
			}
			val["name"] = group.LastFormationSet;
			val["spacing"] = group.LastFormationSpacing;
			val["spacing_unit"] = group.LastFormationSpacingUnits;
			return val;
		}
		throw new LuaError("单元需要是一个编队。");
	}

	public static LuaTable ScenEdit_SelectedUnits(Scenario scenario_0)
	{
		Side currentSide = scenario_0.GetCurrentSide();
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		LuaTable val2 = LuaSandBox.Singleton().CreateTable();
		LuaTable val3 = LuaSandBox.Singleton().CreateTable();
		if (currentSide.SelectedUnits.Count > 0)
		{
			foreach (Module_Unit.Unit selectedUnit in currentSide.SelectedUnits)
			{
				LuaTable val4 = LuaSandBox.Singleton().CreateTable();
				val4["name"] = selectedUnit.Name;
				val4["guid"] = selectedUnit.ObjectID;
				if (selectedUnit.DisableWriter())
				{
					val3[val3.Keys.Count + 1] = val4;
				}
				else if (selectedUnit.IsActiveUnit)
				{
					val2[val2.Keys.Count + 1] = val4;
				}
			}
		}
		if (val2.Keys.Count > 0)
		{
			val["units"] = val2;
		}
		if (val3.Keys.Count > 0)
		{
			val["contacts"] = val3;
		}
		return val;
	}

	public static LuaTable ScenEdit_GetTimeOfDay(LuaTable luaTable_0, Scenario scenario_0)
	{
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		try
		{
			Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			ActiveUnit activeUnit = null;
			Side side = null;
			DateTime dateTime_ = scenario_0.Time;
			LuaUtility.ParseUnitDict(ref dictionary_);
			string right = "DDMMYYYY";
			string text13 = "MMDDYYYY";
			string right2 = "YYYYMMDD";
			string text14 = text13;
			if (dictionary_.ContainsKey("DATEFORMAT"))
			{
				string text15 = Conversions.ToString(dictionary_["DATEFORMAT"]);
				if (Operators.CompareString(text15, right, TextCompare: false) != 0 && Operators.CompareString(text15, text13, TextCompare: false) != 0 && Operators.CompareString(text15, right2, TextCompare: false) != 0)
				{
					throw new LuaError("Invalid date format '" + text15 + "'");
				}
				text14 = text15;
			}
			if (dictionary_.ContainsKey("DATE"))
			{
				string string_ = Conversions.ToString(dictionary_["DATE"]);
				string left = text14;
				(int, int, int) tuple = default((int, int, int));
				if (Operators.CompareString(left, right, TextCompare: false) == 0)
				{
					tuple = LuaUtility.ParseDate_DDMMYYYY(string_);
				}
				else if (Operators.CompareString(left, text13, TextCompare: false) == 0)
				{
					tuple = LuaUtility.ParseDate_MMDDYYYY(string_);
				}
				else if (Operators.CompareString(left, right2, TextCompare: false) == 0)
				{
					tuple = LuaUtility.ParseDate_YYYYMMDD(string_);
				}
				dateTime_ = new DateTime(tuple.Item3, tuple.Item2, tuple.Item1, dateTime_.Hour, dateTime_.Minute, dateTime_.Second);
			}
			if (dictionary_.ContainsKey("TIME"))
			{
				(int, int, int) tuple2 = LuaUtility.ParseTime_HHMMSS(Conversions.ToString(dictionary_["TIME"]));
				dateTime_ = new DateTime(dateTime_.Year, dateTime_.Month, dateTime_.Day, tuple2.Item1, tuple2.Item2, tuple2.Item3);
			}
			if (dictionary_.ContainsKey("GUID"))
			{
				string text16;
				try
				{
					text16 = Conversions.ToString(dictionary_["GUID"]);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at PM167", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("guid必须是一个字符串");
				}
				try
				{
					activeUnit = scenario_0.ActiveUnits[text16];
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at PM168", "");
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("找不到guid" + text16);
				}
			}
			else if (dictionary_.ContainsKey("UNITNAME"))
			{
				string text12;
				try
				{
					text12 = Conversions.ToString(dictionary_["UNITNAME"]);
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception exception_3 = ex3;
					exception_3?.Data.Add("Error at PM169", "");
					GameGeneral.WriteExceptionsToLog(ref exception_3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("名称必须是一个字符串");
				}
				if (dictionary_.ContainsKey("SIDE"))
				{
					string text10;
					try
					{
						text10 = Conversions.ToString(dictionary_["SIDE"]);
					}
					catch (Exception ex4)
					{
						ProjectData.SetProjectError(ex4);
						Exception exception_4 = ex4;
						exception_4?.Data.Add("Error at PM170", "");
						GameGeneral.WriteExceptionsToLog(ref exception_4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("分方必须是一个字符串");
					}
					try
					{
						side = LuaUtility.QuerySide(dictionary_, scenario_0);
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception exception_5 = ex5;
						exception_5?.Data.Add("Error at PM171", "");
						GameGeneral.WriteExceptionsToLog(ref exception_5);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("找不到分方'" + text10 + "'");
					}
					try
					{
						activeUnit = side.Units.First((ActiveUnit s) => string.Equals(s.Name, text12, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text12, StringComparison.Ordinal));
					}
					catch (Exception ex6)
					{
						ProjectData.SetProjectError(ex6);
						Exception exception_6 = ex6;
						exception_6?.Data.Add("Error at PM172", "");
						GameGeneral.WriteExceptionsToLog(ref exception_6);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("找不到单元'" + text12 + "' 分方 '" + text10 + "'");
					}
					dictionary_["GUID"] = activeUnit.ObjectID;
				}
			}
			if (activeUnit != null)
			{
				dictionary_["LATITUDE"] = activeUnit.GetLatitude();
				dictionary_["LONGITUDE"] = activeUnit.GetLongitude();
			}
			double? num = LuaUtility.QueryLatitude(dictionary_);
			if (num.HasValue)
			{
				double? num2 = LuaUtility.QueryLongitude(dictionary_);
				if (num2.HasValue)
				{
					bool use_DST = scenario_0.Use_DST;
					string dST_Start = scenario_0.DST_Start;
					string dST_End = scenario_0.DST_End;
					string text11 = Misc.DisableRequest(dateTime_, num2.Value, use_DST, dST_Start, dST_End).ToShortTimeString();
					Weather.TTimeOfDayType tTimeOfDayType = SunModule.CollectSpecification(scenario_0, dateTime_.Year, dateTime_.Month, dateTime_.Day, dateTime_.Hour, dateTime_.Minute, dateTime_.Second, bool_0: false, num.Value, num2.Value, 0.0);
					switch (tTimeOfDayType)
					{
					case Weather.TTimeOfDayType.tod_Day:
						val["tod"] = (int)tTimeOfDayType;
						val["TOD"] = "day";
						break;
					case Weather.TTimeOfDayType.tod_Twilight:
						if (Misc.DisableRequest(dateTime_, num2.Value, use_DST, dST_Start, dST_End).Hour < 12)
						{
							val["tod"] = 3;
							val["TOD"] = "dawn";
						}
						else
						{
							val["tod"] = 4;
							val["TOD"] = "dusk";
						}
						break;
					case Weather.TTimeOfDayType.tod_Night:
						val["tod"] = (int)tTimeOfDayType;
						val["TOD"] = "night";
						break;
					}
					val["localtime"] = text11;
					val["zulutime"] = dateTime_.Hour.ToString("D2") + ":" + dateTime_.Minute.ToString("D2") + ":" + dateTime_.Second.ToString("D2");
					return val;
				}
				throw new LuaError("缺少'经度'");
			}
			throw new LuaError("缺少'纬度'");
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception exception_7 = ex7;
			exception_7?.Data.Add("Error at PM173", "");
			GameGeneral.WriteExceptionsToLog(ref exception_7);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static int ScenEdit_AddMinefield(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		Side side = null;
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("SIDE"))
		{
			string text = Conversions.ToString(dictionary_["SIDE"]);
			try
			{
				side = LuaUtility.QuerySide(dictionary_, scenario_0);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM174", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("找不到分方'" + text + "'");
			}
		}
		List<ReferencePoint> list = new List<ReferencePoint>();
		if (dictionary_.ContainsKey("AREA"))
		{
			list.Clear();
			try
			{
				foreach (object item in LuaUtility.ToArray(((LuaTable)dictionary_["AREA"]).GetEnumerator()))
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item);
					string Local_o_name = null;
					ReferencePoint referencePoint = null;
					if (objectValue.GetType() == typeof(LuaTable))
					{
						Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator());
						if (dictionary.ContainsKey("GUID"))
						{
							Local_o_name = Conversions.ToString(dictionary["GUID"]).ToUpper();
						}
						else if (dictionary_.ContainsKey("NAME"))
						{
							Local_o_name = Conversions.ToString(dictionary["NAME"]).ToUpper();
						}
						referencePoint = side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
						if (Information.IsNothing(referencePoint))
						{
							foreach (NoNavZone noNavZone in side.NoNavZones)
							{
								referencePoint = noNavZone.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
								if (!Information.IsNothing(referencePoint))
								{
									break;
								}
							}
						}
						if (Information.IsNothing(referencePoint))
						{
							foreach (ExclusionZone exclusionZone in side.ExclusionZones)
							{
								referencePoint = exclusionZone.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
								if (!Information.IsNothing(referencePoint))
								{
									break;
								}
							}
						}
					}
					else
					{
						Local_o_name = objectValue.ToString().ToUpper();
						referencePoint = side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
						if (Information.IsNothing(referencePoint))
						{
							foreach (NoNavZone noNavZone2 in side.NoNavZones)
							{
								referencePoint = noNavZone2.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
								if (!Information.IsNothing(referencePoint))
								{
									break;
								}
							}
						}
						if (Information.IsNothing(referencePoint))
						{
							foreach (ExclusionZone exclusionZone2 in side.ExclusionZones)
							{
								referencePoint = exclusionZone2.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
								if (!Information.IsNothing(referencePoint))
								{
									break;
								}
							}
						}
					}
					if (!Information.IsNothing(referencePoint))
					{
						list.Add(referencePoint);
					}
				}
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM175", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		if (list.Count == 0)
		{
			throw new LuaError("No valid area defined");
		}
		if (dictionary_.ContainsKey("DBID"))
		{
			int int_ = Conversions.ToInteger(dictionary_["DBID"]);
			if (dictionary_.ContainsKey("NUMBER"))
			{
				int num = Conversions.ToInteger(dictionary_["NUMBER"]);
				float num2 = 0f;
				if (dictionary_.ContainsKey("DELAY"))
				{
					num2 = Conversions.ToSingle(dictionary_["DELAY"]);
				}
				int num3 = 0;
				int num4 = num;
				int num5;
				for (num5 = 0; num5 <= num4; num5++)
				{
					num5++;
					Side side_ = side;
					string string_ = null;
					UnguidedWeapon unguidedWeapon = scenario_0.AddNewMine(side_, int_, list, ref string_);
					if (!Information.IsNothing(unguidedWeapon))
					{
						if (num2 > 0f)
						{
							unguidedWeapon.TimeToDetonate = num2;
						}
						num3++;
					}
				}
				return num3;
			}
			throw new LuaError("No number of mines defined.");
		}
		throw new LuaError("No mine DB type defined.");
	}

	public static LuaTable ScenEdit_GetMinefield(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		Side Local_SideObject = null;
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("SIDE"))
		{
			string text = Conversions.ToString(dictionary_["SIDE"]);
			try
			{
				Local_SideObject = LuaUtility.QuerySide(dictionary_, scenario_0);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM176", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("找不到分方'" + text + "'");
			}
		}
		List<UnguidedWeapon> list = scenario_0.UnguidedWeapons.Values.Where((UnguidedWeapon theUW) => theUW.IsMine && theUW.GetUnitSide() == Local_SideObject).ToList();
		if (list.Count < 1)
		{
			return LuaSandBox.Singleton().CreateTable();
		}
		List<ReferencePoint> list2 = new List<ReferencePoint>();
		if (dictionary_.ContainsKey("AREA"))
		{
			list2.Clear();
			try
			{
				foreach (object item in LuaUtility.ToArray(((LuaTable)dictionary_["AREA"]).GetEnumerator()))
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item);
					string Local_o_name = null;
					ReferencePoint referencePoint = null;
					if (objectValue.GetType() == typeof(LuaTable))
					{
						Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator());
						if (dictionary.ContainsKey("GUID"))
						{
							Local_o_name = Conversions.ToString(dictionary["GUID"]).ToUpper();
						}
						else if (dictionary_.ContainsKey("NAME"))
						{
							Local_o_name = Conversions.ToString(dictionary["NAME"]).ToUpper();
						}
						referencePoint = Local_SideObject.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
						if (Information.IsNothing(referencePoint))
						{
							foreach (NoNavZone noNavZone in Local_SideObject.NoNavZones)
							{
								referencePoint = noNavZone.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
								if (!Information.IsNothing(referencePoint))
								{
									break;
								}
							}
						}
						if (Information.IsNothing(referencePoint))
						{
							foreach (ExclusionZone exclusionZone in Local_SideObject.ExclusionZones)
							{
								referencePoint = exclusionZone.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
								if (!Information.IsNothing(referencePoint))
								{
									break;
								}
							}
						}
					}
					else
					{
						Local_o_name = objectValue.ToString().ToUpper();
						referencePoint = Local_SideObject.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
						if (Information.IsNothing(referencePoint))
						{
							foreach (NoNavZone noNavZone2 in Local_SideObject.NoNavZones)
							{
								referencePoint = noNavZone2.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
								if (!Information.IsNothing(referencePoint))
								{
									break;
								}
							}
						}
						if (Information.IsNothing(referencePoint))
						{
							foreach (ExclusionZone exclusionZone2 in Local_SideObject.ExclusionZones)
							{
								referencePoint = exclusionZone2.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
								if (!Information.IsNothing(referencePoint))
								{
									break;
								}
							}
						}
					}
					if (!Information.IsNothing(referencePoint))
					{
						list2.Add(referencePoint);
					}
				}
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM177", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		if (list2.Count == 0)
		{
			throw new LuaError("No valid area defined");
		}
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		int num = 1;
		foreach (UnguidedWeapon item2 in list)
		{
			if ((item2.GetUnitSide() == Local_SideObject) & item2.GetIsInsideThisArea(list2, scenario_0, bool_0: false))
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["guid"] = item2.ObjectID;
				val2["type"] = item2.AnnexAndDBID;
				val2["delay"] = item2.TimeToDetonate;
				val2["longitude"] = item2.GetLongitude();
				val2["latitude"] = item2.GetLatitude();
				val2["depth"] = item2.GetCurrentAltitude();
				val[num] = val2;
				num++;
			}
		}
		return val;
	}

	public static int ScenEdit_DeleteMinefield(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		Side Local_SideObject = null;
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("SIDE"))
		{
			string text = Conversions.ToString(dictionary_["SIDE"]);
			try
			{
				Local_SideObject = LuaUtility.QuerySide(dictionary_, scenario_0);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM178", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("找不到分方'" + text + "'");
			}
		}
		List<UnguidedWeapon> list = scenario_0.UnguidedWeapons.Values.Where((UnguidedWeapon theUW) => theUW.IsMine && theUW.GetUnitSide() == Local_SideObject).ToList();
		if (list.Count < 1)
		{
			return 0;
		}
		List<ReferencePoint> list2 = new List<ReferencePoint>();
		if (dictionary_.ContainsKey("AREA"))
		{
			list2.Clear();
			try
			{
				foreach (object item in LuaUtility.ToArray(((LuaTable)dictionary_["AREA"]).GetEnumerator()))
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item);
					string Local_o_name = null;
					ReferencePoint referencePoint = null;
					if (objectValue.GetType() == typeof(LuaTable))
					{
						Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator());
						if (dictionary.ContainsKey("GUID"))
						{
							Local_o_name = Conversions.ToString(dictionary["GUID"]).ToUpper();
						}
						else if (dictionary_.ContainsKey("NAME"))
						{
							Local_o_name = Conversions.ToString(dictionary["NAME"]).ToUpper();
						}
						referencePoint = Local_SideObject.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
						if (Information.IsNothing(referencePoint))
						{
							foreach (NoNavZone noNavZone in Local_SideObject.NoNavZones)
							{
								referencePoint = noNavZone.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
								if (!Information.IsNothing(referencePoint))
								{
									break;
								}
							}
						}
						if (Information.IsNothing(referencePoint))
						{
							foreach (ExclusionZone exclusionZone in Local_SideObject.ExclusionZones)
							{
								referencePoint = exclusionZone.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
								if (!Information.IsNothing(referencePoint))
								{
									break;
								}
							}
						}
					}
					else
					{
						Local_o_name = objectValue.ToString().ToUpper();
						referencePoint = Local_SideObject.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
						if (Information.IsNothing(referencePoint))
						{
							foreach (NoNavZone noNavZone2 in Local_SideObject.NoNavZones)
							{
								referencePoint = noNavZone2.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
								if (!Information.IsNothing(referencePoint))
								{
									break;
								}
							}
						}
						if (Information.IsNothing(referencePoint))
						{
							foreach (ExclusionZone exclusionZone2 in Local_SideObject.ExclusionZones)
							{
								referencePoint = exclusionZone2.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
								if (!Information.IsNothing(referencePoint))
								{
									break;
								}
							}
						}
					}
					if (!Information.IsNothing(referencePoint))
					{
						list2.Add(referencePoint);
					}
				}
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM179", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		if (list2.Count == 0)
		{
			throw new LuaError("No valid area defined");
		}
		int num = 0;
		List<UnguidedWeapon> list3 = new List<UnguidedWeapon>();
		foreach (UnguidedWeapon item2 in list)
		{
			if ((item2.GetUnitSide() == Local_SideObject) & item2.GetIsInsideThisArea(list2, scenario_0, bool_0: false))
			{
				list3.Add(item2);
			}
		}
		foreach (UnguidedWeapon item3 in list3)
		{
			item3.DestroyMe(ref scenario_0, "Deleted minefield");
			num++;
		}
		return num;
	}

	public static bool ScenEdit_SetMine(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("SIDE"))
		{
			string text = Conversions.ToString(dictionary_["SIDE"]);
			try
			{
				LuaUtility.QuerySide(dictionary_, scenario_0);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM180", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("找不到分方'" + text + "'");
			}
		}
		string text2 = null;
		if (dictionary_.ContainsKey("GUID"))
		{
			text2 = Conversions.ToString(dictionary_["GUID"]);
		}
		float? num = null;
		if (dictionary_.ContainsKey("DELAY"))
		{
			num = Conversions.ToSingle(dictionary_["DELAY"]);
		}
		if (text2 != null && num.HasValue)
		{
			bool result = false;
			scenario_0.UnguidedWeapons.Values.Where((UnguidedWeapon theUW) => theUW.IsMine).ToList();
			if (scenario_0.UnguidedWeapons.ContainsKey(text2))
			{
				UnguidedWeapon unguidedWeapon = scenario_0.UnguidedWeapons[text2];
				if (unguidedWeapon.IsMine)
				{
					unguidedWeapon.TimeToDetonate = num.Value;
					result = true;
				}
			}
			return result;
		}
		return false;
	}

	public static bool ScenEdit_DeleteMine(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("SIDE"))
		{
			string text = Conversions.ToString(dictionary_["SIDE"]);
			try
			{
				LuaUtility.QuerySide(dictionary_, scenario_0);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM181", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("找不到分方'" + text + "'");
			}
		}
		string text2 = null;
		if (dictionary_.ContainsKey("GUID"))
		{
			text2 = Conversions.ToString(dictionary_["GUID"]);
		}
		if (text2 == null)
		{
			return false;
		}
		bool result = false;
		scenario_0.UnguidedWeapons.Values.Where((UnguidedWeapon theUW) => theUW.IsMine).ToList();
		if (scenario_0.UnguidedWeapons.ContainsKey(text2))
		{
			UnguidedWeapon unguidedWeapon = scenario_0.UnguidedWeapons[text2];
			if (unguidedWeapon.IsMine)
			{
				unguidedWeapon.DestroyMe(ref scenario_0, "Deleted mine");
				result = true;
			}
		}
		return result;
	}

	public static string ScenEdit_GetDateTimeTicks(Scenario scenario_0)
	{
		return scenario_0.Time.Ticks.ToString();
	}

	public static object ScenEdit_QueryDB(string string_0, int int_0, Scenario scenario_0)
	{
		try
		{
			switch (string_0.ToLower())
			{
			case "mount":
				return new LuaWrapper_Device_Mount(DBFunctions.GetMount(int_0, ref scenario_0, bool_0: false), scenario_0);
			case "facility":
			{
				Facility facility_ = new Facility(ref scenario_0, "");
				DBFunctions.GetFacility(ref scenario_0, ref facility_, int_0);
				break;
			}
			case "submarine":
			{
				Submarine submarine_ = new Submarine(ref scenario_0, "");
				DBFunctions.GetSubmarine(ref scenario_0, ref submarine_, int_0);
				break;
			}
			case "weapon":
			{
				Weapon newWeapon = Weapon.GetNewWeapon(ref scenario_0, int_0, bool_0: false);
				DBFunctions.GetWeapon(scenario_0.DBConnection, newWeapon, int_0, scenario_0, bool_0: false);
				return new LuaWrapper_Device_Weapon(newWeapon, scenario_0);
			}
			case "ship":
			{
				Ship ship_ = new Ship(ref scenario_0, "");
				DBFunctions.GetShip(ref scenario_0, ref ship_, int_0);
				break;
			}
			case "sensor":
			{
				SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
				return new LuaWrapper_Device_Sensor(DBFunctions.GetSensor(int_0, ref sqliteConnection_), scenario_0);
			}
			case "aircraft":
			{
				Aircraft aircraft_ = new Aircraft(ref scenario_0, "");
				DBFunctions.GetAircraft(ref scenario_0, ref aircraft_, int_0);
				break;
			}
			case "satellite":
			{
				Satellite satellite_ = new Satellite(ref scenario_0);
				DBFunctions.GetSatellite(ref scenario_0, ref satellite_, int_0);
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at PM182", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
		return null;
	}

	public static bool ScenEdit_AddCustomLoss(string string_0, LuaTable luaTable_0, Scenario scenario_0)
	{
		bool result = false;
		LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		Side side = null;
		try
		{
			side = LuaUtility.QuerySideObject(string_0, scenario_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at PM183", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new LuaError("找不到分方'" + string_0 + "'");
		}
		foreach (object item in LuaUtility.ToArray(luaTable_0.GetEnumerator()))
		{
			object objectValue = RuntimeHelpers.GetObjectValue(item);
			string text = null;
			int num = 1;
			if (objectValue.GetType() == typeof(LuaTable))
			{
				if (objectValue is LuaTable)
				{
					List<object> list = LuaUtility.ToArray(((LuaTable)objectValue).GetEnumerator());
					if (list.Count == 2)
					{
						num = Conversions.ToInteger(list[1]);
					}
					text = list[0].ToString();
				}
				else
				{
					text = Conversions.ToString(objectValue);
					num = 1;
				}
			}
			else
			{
				text = Conversions.ToString(objectValue);
				num = 1;
			}
			if (Information.IsNothing(side.AAR.Losses))
			{
				side.AAR.Losses = new Dictionary<string, HashSet<string>>();
			}
			Dictionary<string, HashSet<string>> losses = side.AAR.Losses;
			string key = "Custom_" + text;
			if (losses.ContainsKey(key))
			{
				losses[key].Clear();
				if (num > 0)
				{
					losses[key].Add(Conversions.ToString(num));
				}
			}
			else if (num > 0)
			{
				HashSet<string> value = new HashSet<string> { Conversions.ToString(num) };
				losses.Add(key, value);
			}
			result = true;
		}
		return result;
	}

	public static LuaWrapper_ActiveUnit VP_GetUnit(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		ActiveUnit activeUnit = null;
		string text = null;
		string text2 = null;
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("GUID"))
		{
			try
			{
				text2 = Conversions.ToString(dictionary_["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM184", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid必须是一个字符串");
			}
			try
			{
				activeUnit = scenario_0.ActiveUnits[text2];
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM185", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("找不到guid" + text2);
			}
		}
		else if (dictionary_.ContainsKey("UNITNAME"))
		{
			try
			{
				text = Conversions.ToString(dictionary_["UNITNAME"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at PM186", "");
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("名称必须是一个字符串");
			}
			foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
			{
				if (string.Equals(activeUnits_.Name, text, StringComparison.OrdinalIgnoreCase) || string.Equals(activeUnits_.ObjectID, text, StringComparison.OrdinalIgnoreCase))
				{
					activeUnit = activeUnits_;
					break;
				}
			}
			if (Information.IsNothing(activeUnit))
			{
				throw new LuaError("无法找到单元匹配名称：" + text);
			}
		}
		if (activeUnit == null)
		{
			Contact contact = null;
			if (text2 == null)
			{
				if (text != null)
				{
					string string_ = text;
					Side side_ = null;
					contact = LuaUtility.ValidAsContact(string_, scenario_0, ref side_);
				}
			}
			else
			{
				string string_2 = text2;
				Side side_2 = null;
				contact = LuaUtility.ValidAsContact(string_2, scenario_0, ref side_2);
			}
			if (contact != null)
			{
				activeUnit = contact.ActualUnit;
			}
		}
		if (Information.IsNothing(activeUnit))
		{
			throw new LuaError("无法找到单元");
		}
		return new LuaWrapper_ActiveUnit(activeUnit, scenario_0);
	}

	public static LuaWrapper_Contact VP_GetContact(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		Contact contact = null;
		Side side_ = null;
		if (dictionary.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dictionary["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM187", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid必须是一个字符串");
			}
			try
			{
				Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
				Side[] array = sides_ReadOnly;
				foreach (Side side in array)
				{
					side_ = side;
					contact = ValidateContactBySide(text, side);
					if (contact != null)
					{
						break;
					}
					foreach (string key in side.m_InfoFacade.Keys)
					{
						Contact contact2 = side.m_InfoFacade[key];
						if (string.Equals(contact2.ObjectID, text, StringComparison.OrdinalIgnoreCase))
						{
							side_ = side;
							contact = contact2;
							break;
						}
					}
					if (contact != null)
					{
						break;
					}
					foreach (string key2 in side.m_HelperFacade.Keys)
					{
						Contact contact3 = side.m_HelperFacade[key2];
						if (string.Equals(contact3.ObjectID, text, StringComparison.OrdinalIgnoreCase))
						{
							side_ = side;
							contact = contact3;
							break;
						}
					}
				}
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM188", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("找不到guid" + text);
			}
		}
		if (Information.IsNothing(contact))
		{
			throw new LuaError("无法找到目标");
		}
		return new LuaWrapper_Contact(contact, scenario_0, side_);
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
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM189", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
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
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM190", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
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

	public static LuaTable VP_GetSides(Scenario scenario_0)
	{
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side_ in array)
		{
			val[val.Keys.Count + 1] = new LuaWrapper_Side(side_, scenario_0);
		}
		return val;
	}

	public static LuaWrapper_Scenario VP_GetScenario(Scenario scenario_0)
	{
		byte status = 0;
		byte mode = 0;
		PrivateMethods.LuaGame?.Invoke(ref status, ref mode);
		return new LuaWrapper_Scenario(scenario_0)
		{
			GameMode = mode,
			GameStatus = status
		};
	}

	public static LuaTable ScenEdit_SplitUnit(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		ActiveUnit activeUnit = null;
		Side side = null;
		string text = null;
		string Local_Name = null;
		string text2 = null;
		new Dictionary<Mount, Mount>();
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("GUID"))
		{
			try
			{
				text2 = Conversions.ToString(dictionary_["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM191", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid必须是一个字符串");
			}
			try
			{
				activeUnit = scenario_0.ActiveUnits[text2];
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM192", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				text = "找不到guid" + text2;
				ProjectData.ClearProjectError();
			}
		}
		else if (dictionary_.ContainsKey("UNITNAME"))
		{
			try
			{
				Local_Name = Conversions.ToString(dictionary_["UNITNAME"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at PM193", "");
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("名称必须是一个字符串");
			}
			if (dictionary_.ContainsKey("SIDE"))
			{
				string text3;
				try
				{
					text3 = Conversions.ToString(dictionary_["SIDE"]);
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception exception_4 = ex4;
					exception_4?.Data.Add("Error at PM194", "");
					GameGeneral.WriteExceptionsToLog(ref exception_4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("分方必须是一个字符串");
				}
				try
				{
					side = LuaUtility.QuerySide(dictionary_, scenario_0);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception exception_5 = ex5;
					exception_5?.Data.Add("Error at PM195", "");
					GameGeneral.WriteExceptionsToLog(ref exception_5);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					text = "找不到分方'" + text3 + "'";
					ProjectData.ClearProjectError();
				}
				try
				{
					activeUnit = side.Units.First((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex6)
				{
					ProjectData.SetProjectError(ex6);
					Exception exception_6 = ex6;
					exception_6?.Data.Add("Error at PM196", "");
					GameGeneral.WriteExceptionsToLog(ref exception_6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					text = "找不到单元'" + Local_Name + "' 分方 '" + text3 + "'";
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				try
				{
					activeUnit = scenario_0.ActiveUnits_List.First((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception exception_7 = ex7;
					exception_7?.Data.Add("Error at PM197", "");
					GameGeneral.WriteExceptionsToLog(ref exception_7);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					text = "找不到单元'" + Local_Name + "'";
					ProjectData.ClearProjectError();
				}
			}
		}
		if (activeUnit == null)
		{
			if (LuaSandBox.Singleton().RunInteractive && text != null)
			{
				throw new LuaError(text);
			}
			if (text2 == null && Local_Name == null)
			{
				throw new LuaError("需要定义名称或Guid来标识单元。最好是Guid或Side＆Name。");
			}
			return null;
		}
		if (activeUnit.AddClient() && activeUnit.Mounts.Count >= 2)
		{
			Cargo[] gparam_ = new Cargo[0];
			for (int i = activeUnit.Mounts.Count - 1; i >= 1; i += -1)
			{
				ArrayExtensions.Add(ref gparam_, new Cargo(activeUnit, activeUnit.Mounts.ElementAt(i)));
				activeUnit.Mounts.RemoveAt(i);
				List<ActiveUnit> list = Cargo.UnloadCargoAtLocation(activeUnit, ref gparam_, null, activeUnit.GetLatitude(), activeUnit.GetLongitude(), activeUnit.ParentScen, activeUnit.GetUnitSide(), bool_0: false, bool_1: true);
				if (list.Count > 0)
				{
					list.ElementAt(0).Name = "New Detachment";
				}
				val[val.Keys.Count + 1] = list.ElementAt(0);
			}
			return val;
		}
		return null;
	}

	public static LuaWrapper_ActiveUnit_SE ScenEdit_MergeUnits(Scenario scenario_0)
	{
		ActiveUnit activeUnit_ = null;
		Side currentSide = scenario_0.GetCurrentSide();
		if (currentSide.SelectedUnits.Count <= 1)
		{
			return null;
		}
		foreach (Module_Unit.Unit selectedUnit in currentSide.SelectedUnits)
		{
			ActiveUnit activeUnit = (ActiveUnit)selectedUnit;
			if (selectedUnit.GetUnitSide() == currentSide && activeUnit.AddClient())
			{
				if (Module_Unit.RangeToUnit_Horiz(currentSide.SelectedUnits.ElementAt(0), selectedUnit) > 0.05f)
				{
					return null;
				}
				continue;
			}
			return null;
		}
		if (currentSide.SelectedUnits.Count > 1)
		{
			foreach (Module_Unit.Unit selectedUnit2 in currentSide.SelectedUnits)
			{
				ActiveUnit activeUnit2 = (ActiveUnit)selectedUnit2;
				if (selectedUnit2.GetUnitSide() != currentSide || !activeUnit2.AddClient() || !(Module_Unit.RangeToUnit_Horiz(currentSide.SelectedUnits.ElementAt(0), selectedUnit2) <= 0.2f))
				{
					return null;
				}
			}
			ActiveUnit activeUnit3 = (ActiveUnit)currentSide.SelectedUnits.ElementAt(0);
			activeUnit_ = activeUnit3;
			for (int i = currentSide.SelectedUnits.Count - 1; i >= 1; i += -1)
			{
				foreach (Mount item in ((ActiveUnit)currentSide.SelectedUnits.ElementAt(i)).Mounts.ToList())
				{
					activeUnit3.Mounts.Add(item);
					((ActiveUnit)currentSide.SelectedUnits.ElementAt(i)).Mounts.Remove(item);
				}
				((ActiveUnit)currentSide.SelectedUnits.ElementAt(i)).Destroy(bool_0: true, bool_1: true, bool_2: true, "Unit Merged");
			}
		}
		return new LuaWrapper_ActiveUnit_SE(activeUnit_, scenario_0);
	}

	public static float Tool_QueryRCS(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		LuaUtility.ParseUnitDict(ref dictionary_);
		ActiveUnit activeUnit = null;
		if (dictionary_.ContainsKey("SENSORUNITNAME"))
		{
			string b = Conversions.ToString(dictionary_["SENSORUNITNAME"]);
			activeUnit = (dictionary_.ContainsKey("SENSORSIDE") ? LuaUtility.QuerySensorSide(dictionary_, scenario_0).Units.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, b, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, b, StringComparison.OrdinalIgnoreCase)) : scenario_0.ActiveUnits_List.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, b, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, b, StringComparison.OrdinalIgnoreCase)));
		}
		ActiveUnit activeUnit2 = null;
		if (dictionary_.ContainsKey("TARGETUNITNAME"))
		{
			string b2 = Conversions.ToString(dictionary_["TARGETUNITNAME"]);
			activeUnit2 = (dictionary_.ContainsKey("TARGETSIDE") ? LuaUtility.QueryTargetSide(dictionary_, scenario_0).Units.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, b2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, b2, StringComparison.OrdinalIgnoreCase)) : scenario_0.ActiveUnits_List.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, b2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, b2, StringComparison.OrdinalIgnoreCase)));
		}
		if (activeUnit != null && activeUnit2 != null)
		{
			ActiveUnit unit_ = activeUnit;
			ActiveUnit unit_2 = activeUnit2;
			string string_ = "";
			float float_ = Math2.UpdateClass(Module_Unit.PrintTokenizer(unit_, unit_2, bool_0: false, ref string_));
			XSection._SignatureType signatureType_ = (XSection._SignatureType)0;
			if (dictionary_.ContainsKey("SIGNATURETYPE"))
			{
				signatureType_ = (XSection._SignatureType)Enum.Parse(typeof(XSection._SignatureType), Conversions.ToString(dictionary_["SIGNATURETYPE"]));
			}
			XSection xSection = Sensor.smethod_0(activeUnit, signatureType_);
			float result = RadarModel.LoginWriter(xSection, activeUnit2, float_);
			if (xSection.isDBInvisible(activeUnit2))
			{
				return 0f;
			}
			return result;
		}
		throw new Exception("auSensor Is Nothing Or auTarget Is Nothing");
	}

	public static bool ScenEdit_TransferMount(string string_0, string string_1, LuaTable luaTable_0, Scenario scenario_0)
	{
		bool flag = false;
		new List<Mount>();
		new List<ActiveUnit>();
		ActiveUnit activeUnit = null;
		ActiveUnit activeUnit2 = null;
		try
		{
			activeUnit = smethod_0(string_0, scenario_0);
			activeUnit2 = smethod_0(string_1, scenario_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at PM198", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (Information.IsNothing(activeUnit))
		{
			throw new LuaError("从单元找不到！");
		}
		if (Information.IsNothing(activeUnit2))
		{
			throw new LuaError("找不到单元！");
		}
		if ((object)activeUnit.GetUnitSide().ObjectID == activeUnit2.GetUnitSide().ObjectID && activeUnit2.AddClient() && activeUnit.AddClient() && Module_Unit.RangeToUnit_Horiz(activeUnit, activeUnit2) < 0.2f)
		{
			try
			{
				foreach (object item in LuaUtility.ToArray(luaTable_0.GetEnumerator()))
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item);
					string text = null;
					text = Conversions.ToString(objectValue);
					foreach (Mount item2 in activeUnit.Mounts.ToList())
					{
						if (Operators.CompareString(item2.ObjectID, text, TextCompare: false) == 0)
						{
							activeUnit2.Mounts.Add(item2);
							activeUnit.Mounts.Remove(item2);
						}
					}
				}
				if (activeUnit.Mounts.Count == 0)
				{
					activeUnit.Destroy(bool_0: true, bool_1: true, bool_2: true, "Unit Merged");
				}
				return true;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at PM199", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		return false;
	}

	public static bool VP_ExportUnits(LuaTable luaTable_0, string string_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		Side side = null;
		new HashSet<string>();
		List<GlobalVariables.ActiveUnitType> list = new List<GlobalVariables.ActiveUnitType>();
		List<int> list2 = new List<int>();
		List<int> list3 = new List<int>();
		List<string> list4 = new List<string>();
		string text = null;
		LuaUtility.ParseUnitDict(ref dictionary_);
		if (dictionary_.ContainsKey("TARGETSIDE"))
		{
			try
			{
				text = Conversions.ToString(dictionary_["TARGETSIDE"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at PM200", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("名称必须是一个字符串");
			}
			side = ValidateSide(text, scenario_0);
			if (Information.IsNothing(side))
			{
				throw new LuaError("无法找到分方匹配名称：" + text);
			}
		}
		if (dictionary_.ContainsKey("TARGETTYPE"))
		{
			foreach (object item in LuaUtility.ToArray(((LuaTable)dictionary_["TARGETTYPE"]).GetEnumerator()))
			{
				string a = Conversions.ToString(RuntimeHelpers.GetObjectValue(item));
				byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.ActiveUnitType));
				int num = 0;
				while (num < array.Length)
				{
					byte b = array[num];
					if (!string.Equals(a, b.ToString(), StringComparison.OrdinalIgnoreCase))
					{
						GlobalVariables.ActiveUnitType activeUnitType = (GlobalVariables.ActiveUnitType)b;
						if (!string.Equals(a, activeUnitType.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							num = checked(num + 1);
							continue;
						}
					}
					list.Add((GlobalVariables.ActiveUnitType)b);
					break;
				}
			}
		}
		if (dictionary_.ContainsKey("TARGETSUBTYPE"))
		{
			foreach (object item7 in LuaUtility.ToArray(((LuaTable)dictionary_["TARGETSUBTYPE"]).GetEnumerator()))
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item7);
				list2.Add(Conversions.ToInteger(objectValue));
			}
		}
		if (dictionary_.ContainsKey("SPECIFICUNITCLASS"))
		{
			foreach (object item8 in LuaUtility.ToArray(((LuaTable)dictionary_["SPECIFICUNITCLASS"]).GetEnumerator()))
			{
				object objectValue2 = RuntimeHelpers.GetObjectValue(item8);
				list3.Add(Conversions.ToInteger(objectValue2));
			}
		}
		if (dictionary_.ContainsKey("SPECIFICUNIT"))
		{
			foreach (object item9 in LuaUtility.ToArray(((LuaTable)dictionary_["SPECIFICUNIT"]).GetEnumerator()))
			{
				object objectValue3 = RuntimeHelpers.GetObjectValue(item9);
				list4.Add(Conversions.ToString(objectValue3));
			}
		}
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Indent = true;
		xmlWriterSettings.IndentChars = "    ";
		xmlWriterSettings.ConformanceLevel = ConformanceLevel.Auto;
		string text2 = GameGeneral.ScenariosRootPath;
		string text3 = text2 + "\\" + string_0;
		if (scenario_0.IsRunningInCampaignMode)
		{
			List<string> list5 = new List<string>();
			Campaign.GetCampaignsInFolder(GameGeneral.ScenariosRootPath, list5);
			foreach (string item10 in list5)
			{
				if (Operators.CompareString(Campaign.ReadFromFile(item10).ID, scenario_0.CampaignID, TextCompare: false) == 0)
				{
					text3 = Path.Combine(text2 = Path.GetDirectoryName(item10), scenario_0.CampaignSessionID) + scenario_0.ObjectID;
					break;
				}
			}
		}
		using (MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream())
		{
			XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
			string text4 = "想定：" + scenario_0.Title + "\r\nScenario file: " + text2 + "\\" + scenario_0.FileName + ".scen";
			StreamWriter streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "LuaExport.txt");
			streamWriter.Write("\r\n\r\n" + text4);
			DBOps.DBFileCheckResult dbfileCheckResult_ = DBOps.DBFileCheckResult.Undefined;
			DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(scenario_0.DBUsed, ref dbfileCheckResult_);
			xmlWriter.WriteStartElement("ContentScenario");
			xmlWriter.WriteElementString("CampaignID", scenario_0.CampaignID);
			xmlWriter.WriteElementString("CampaignSessionID", scenario_0.CampaignSessionID);
			xmlWriter.WriteElementString("CampaignScore", scenario_0.CampaignScore.ToString());
			xmlWriter.WriteElementString("DBused", scenario_0.DBUsed);
			xmlWriter.WriteElementString("DBfilename", dBRecordByHash.FileName);
			xmlWriter.WriteElementString("ScenarioID", scenario_0.ObjectID);
			xmlWriter.WriteElementString("Title", scenario_0.Title);
			xmlWriter.WriteElementString("Description", scenario_0.Description);
			xmlWriter.WriteElementString("FileName", scenario_0.FileName);
			xmlWriter.WriteElementString("FileNamePath", scenario_0.FileNamePath);
			xmlWriter.WriteStartElement("ActiveUnits");
			using (List<ActiveUnit>.Enumerator enumerator3 = scenario_0.ActiveUnits_List.GetEnumerator())
			{
				int int_ = 0;
				for (; enumerator3.MoveNext(); streamWriter.Flush())
				{
					ActiveUnit current2 = enumerator3.Current;
					ActiveUnit activeUnit = null;
					if (current2.IsGroup)
					{
						continue;
					}
					bool flag = false;
					bool? flag2 = null;
					if (!Information.IsNothing(side))
					{
						flag2 = (current2.GetUnitSide().Equals(side) ? new bool?(true) : new bool?(false));
					}
					if (list.Count > 0)
					{
						foreach (GlobalVariables.ActiveUnitType item11 in list)
						{
							if (item11 == current2.UnitType)
							{
								flag = true;
								break;
							}
						}
					}
					if (list2.Count > 0)
					{
						foreach (int item12 in list2)
						{
							if (item12 == current2.SubType)
							{
								flag = true;
								break;
							}
						}
					}
					if (list3.Count > 0)
					{
						foreach (int item13 in list3)
						{
							if (item13 == current2.DBID)
							{
								flag = true;
								break;
							}
						}
					}
					if (list4.Count > 0)
					{
						foreach (string item14 in list4)
						{
							if (Operators.CompareString(item14, current2.ObjectID, TextCompare: false) == 0)
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						if (current2.IsAircraft)
						{
							Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)current2.AirOps;
							if (aircraft_AirOps.CurrentHostUnit == null)
							{
								if (aircraft_AirOps.ActualDestinationHost != null)
								{
									activeUnit = aircraft_AirOps.ActualDestinationHost;
								}
							}
							else
							{
								activeUnit = aircraft_AirOps.CurrentHostUnit;
							}
						}
						if (current2.IsShip || current2.IsSubmarine)
						{
							ActiveUnit_DockingOps dockingOps = current2.DockingOps;
							if (dockingOps.CurrentHostUnit != null && Operators.CompareString(dockingOps.CurrentHostUnit.ObjectID, current2.ObjectID, TextCompare: false) == 0)
							{
								activeUnit = dockingOps.CurrentHostUnit;
							}
							else if (dockingOps.ActualDestinationHost != null && Operators.CompareString(dockingOps.ActualDestinationHost.ObjectID, current2.ObjectID, TextCompare: false) == 0)
							{
								activeUnit = dockingOps.ActualDestinationHost;
							}
						}
						if (activeUnit != null)
						{
							if (list.Count > 0)
							{
								foreach (GlobalVariables.ActiveUnitType item2 in list)
								{
									if (item2 == activeUnit.UnitType)
									{
										flag = true;
										break;
									}
								}
							}
							if (list2.Count > 0)
							{
								foreach (int item3 in list2)
								{
									if (item3 == activeUnit.SubType)
									{
										flag = true;
										break;
									}
								}
							}
							if (list3.Count > 0)
							{
								foreach (int item4 in list3)
								{
									if (item4 == activeUnit.DBID)
									{
										flag = true;
										break;
									}
								}
							}
							if (list4.Count > 0)
							{
								foreach (string item5 in list4)
								{
									if (Operators.CompareString(item5, activeUnit.ObjectID, TextCompare: false) == 0)
									{
										flag = true;
										break;
									}
								}
							}
						}
					}
					if (!flag)
					{
						continue;
					}
					if (!Information.IsNothing(flag2))
					{
						bool? flag3 = flag2;
						flag3 = flag3;
						if (!flag3.GetValueOrDefault())
						{
							continue;
						}
					}
					xmlWriter.WriteStartElement("ActiveUnit");
					xmlWriter.WriteElementString("ID", current2.ObjectID);
					xmlWriter.WriteElementString("Name", current2.Name);
					xmlWriter.WriteComment(current2.Name + " (" + current2.UnitClass + " [" + Conversions.ToString(current2.DBID) + "])");
					xmlWriter.WriteElementString("DBID", current2.DBID.ToString());
					xmlWriter.WriteElementString("UnitSubtype", current2.SubType.ToString());
					xmlWriter.WriteElementString("UnitType", current2.UnitType.ToString());
					xmlWriter.WriteElementString("SideName", current2.GetUnitSide().Name);
					if (activeUnit != null)
					{
						xmlWriter.WriteElementString("Hosted", activeUnit.ObjectID);
					}
					SBR.GenerateDeltaFragmentForThisUnit(current2, current2.ParentScen, xmlWriter, streamWriter, ref int_);
					xmlWriter.WriteStartElement("Damage");
					if (current2.GetDamagePts() != (float)current2.InitialDP)
					{
						xmlWriter.WriteElementString("DamagePts", XmlConvert.ToString(current2.GetDamagePts()));
					}
					if ((int)current2.Damage.FireIntensity > 0)
					{
						xmlWriter.WriteElementString("Fire", ((byte)current2.Damage.FireIntensity).ToString());
					}
					if ((int)current2.Damage.FloodIntensity > 0)
					{
						xmlWriter.WriteElementString("Flood", ((byte)current2.Damage.FloodIntensity).ToString());
					}
					switch (current2.UnitType)
					{
					case GlobalVariables.ActiveUnitType.Ship:
					{
						Ship ship = (Ship)current2;
						if (ship.CIC.Status != 0)
						{
							xmlWriter.WriteElementString("CIC_St", ((byte)ship.CIC.Status).ToString());
						}
						if (ship.CIC.DamageSeverity != 0)
						{
							xmlWriter.WriteElementString("CIC_DamageSeverity", ((byte)ship.CIC.DamageSeverity).ToString());
						}
						if (ship.Rudder.Status != 0)
						{
							xmlWriter.WriteElementString("Rudder_St", ((byte)ship.Rudder.Status).ToString());
						}
						if (ship.Rudder.DamageSeverity != 0)
						{
							xmlWriter.WriteElementString("Rudder_DamageSeverity", ((byte)ship.Rudder.DamageSeverity).ToString());
						}
						break;
					}
					case GlobalVariables.ActiveUnitType.Submarine:
					{
						Submarine submarine = (Submarine)current2;
						if (submarine.CIC.Status != 0)
						{
							xmlWriter.WriteElementString("CIC_St", ((byte)submarine.CIC.Status).ToString());
						}
						if (submarine.CIC.DamageSeverity != 0)
						{
							xmlWriter.WriteElementString("CIC_DamageSeverity", ((byte)submarine.CIC.DamageSeverity).ToString());
						}
						if (submarine.Rudder.Status != 0)
						{
							xmlWriter.WriteElementString("Rudder_St", ((byte)submarine.Rudder.Status).ToString());
						}
						if (submarine.Rudder.DamageSeverity != 0)
						{
							xmlWriter.WriteElementString("Rudder_DamageSeverity", ((byte)submarine.Rudder.DamageSeverity).ToString());
						}
						if (submarine.PressureHull.Status != 0)
						{
							xmlWriter.WriteElementString("PressureHull_St", ((byte)submarine.PressureHull.Status).ToString());
						}
						if (submarine.PressureHull.DamageSeverity != 0)
						{
							xmlWriter.WriteElementString("PressureHull_DamageSeverity", ((byte)submarine.PressureHull.DamageSeverity).ToString());
						}
						if (submarine.Cargo.Status != 0)
						{
							xmlWriter.WriteElementString("Cargo_St", ((byte)submarine.Cargo.Status).ToString());
						}
						if (submarine.Cargo.DamageSeverity != 0)
						{
							xmlWriter.WriteElementString("Cargo_DamageSeverity", ((byte)submarine.Cargo.DamageSeverity).ToString());
						}
						break;
					}
					case GlobalVariables.ActiveUnitType.Facility:
					{
						Facility facility = (Facility)current2;
						if (facility.CIC.Status != 0)
						{
							xmlWriter.WriteElementString("CIC_St", ((byte)facility.CIC.Status).ToString());
						}
						if (facility.CIC.DamageSeverity != 0)
						{
							xmlWriter.WriteElementString("CIC_DamageSeverity", ((byte)facility.CIC.DamageSeverity).ToString());
						}
						if (facility.Cargo.Status != 0)
						{
							xmlWriter.WriteElementString("Cargo_St", ((byte)facility.Cargo.Status).ToString());
						}
						if (facility.Cargo.DamageSeverity != 0)
						{
							xmlWriter.WriteElementString("Cargo_DamageSeverity", ((byte)facility.Cargo.DamageSeverity).ToString());
						}
						break;
					}
					}
					xmlWriter.WriteStartElement("Sensors");
					Sensor[] array2 = current2.Sensors_ReadOnly();
					Sensor[] array3 = array2;
					foreach (Sensor sensor in array3)
					{
						if (sensor.Status != 0 || sensor.DamageSeverity != 0)
						{
							xmlWriter.WriteStartElement("Sensor");
							xmlWriter.WriteElementString("ID", sensor.ObjectID);
							xmlWriter.WriteElementString("Name", sensor.Name);
							xmlWriter.WriteElementString("DBID", sensor.DBID.ToString());
							if (sensor.Status != 0)
							{
								xmlWriter.WriteElementString("St", ((byte)sensor.Status).ToString());
							}
							if (sensor.DamageSeverity != 0)
							{
								xmlWriter.WriteElementString("DamageSeverity", ((byte)sensor.DamageSeverity).ToString());
							}
							xmlWriter.WriteEndElement();
						}
					}
					xmlWriter.WriteEndElement();
					xmlWriter.WriteStartElement("Comms");
					CommDevice[] comms_ReadOnly = current2.Comms_ReadOnly;
					CommDevice[] array4 = comms_ReadOnly;
					foreach (CommDevice commDevice in array4)
					{
						if (commDevice.Status != 0 || commDevice.DamageSeverity != 0)
						{
							xmlWriter.WriteStartElement("CD");
							xmlWriter.WriteElementString("ID", commDevice.ObjectID);
							xmlWriter.WriteElementString("Name", commDevice.Name);
							xmlWriter.WriteElementString("DBID", commDevice.DBID.ToString());
							if (commDevice.Status != 0)
							{
								xmlWriter.WriteElementString("St", ((byte)commDevice.Status).ToString());
							}
							if (commDevice.DamageSeverity != 0)
							{
								xmlWriter.WriteElementString("DamageSeverity", ((byte)commDevice.DamageSeverity).ToString());
							}
							xmlWriter.WriteEndElement();
						}
					}
					xmlWriter.WriteEndElement();
					xmlWriter.WriteStartElement("Propulsion");
					foreach (Engine item6 in current2.Propulsion)
					{
						if (item6.Status != 0 || item6.DamageSeverity != 0)
						{
							xmlWriter.WriteStartElement("Engine");
							xmlWriter.WriteElementString("ID", item6.ObjectID);
							xmlWriter.WriteElementString("Name", item6.Name);
							xmlWriter.WriteElementString("DBID", item6.DBID.ToString());
							if (item6.Status != 0)
							{
								xmlWriter.WriteElementString("Status", ((byte)item6.Status).ToString());
							}
							if (item6.DamageSeverity != 0)
							{
								xmlWriter.WriteElementString("DamageSeverity", ((byte)item6.DamageSeverity).ToString());
							}
							xmlWriter.WriteEndElement();
						}
					}
					xmlWriter.WriteEndElement();
					xmlWriter.WriteStartElement("Mounts");
					foreach (Mount mount in current2.Mounts)
					{
						if (mount.Status != 0 || mount.DamageSeverity != 0)
						{
							xmlWriter.WriteStartElement("Mount");
							xmlWriter.WriteElementString("ID", mount.ObjectID);
							xmlWriter.WriteElementString("Name", mount.Name);
							xmlWriter.WriteElementString("DBID", mount.DBID.ToString());
							if (mount.Status != 0)
							{
								xmlWriter.WriteElementString("St", ((byte)mount.Status).ToString());
							}
							if (mount.DamageSeverity != 0)
							{
								xmlWriter.WriteElementString("DamageSeverity", ((byte)mount.DamageSeverity).ToString());
							}
							xmlWriter.WriteEndElement();
						}
					}
					xmlWriter.WriteEndElement();
					xmlWriter.WriteStartElement("Magazines");
					Magazine[] sharedMagazines = current2.SharedMagazines;
					Magazine[] array5 = sharedMagazines;
					foreach (Magazine magazine in array5)
					{
						if (magazine.Status != 0 || magazine.DamageSeverity != 0)
						{
							xmlWriter.WriteStartElement("Mag");
							xmlWriter.WriteElementString("ID", magazine.ObjectID);
							xmlWriter.WriteElementString("Name", magazine.Name);
							xmlWriter.WriteElementString("DBID", magazine.DBID.ToString());
							if (magazine.Status != 0)
							{
								xmlWriter.WriteElementString("St", ((byte)magazine.Status).ToString());
							}
							if (magazine.DamageSeverity != 0)
							{
								xmlWriter.WriteElementString("DamageSeverity", ((byte)magazine.DamageSeverity).ToString());
							}
							xmlWriter.WriteEndElement();
						}
					}
					xmlWriter.WriteEndElement();
					xmlWriter.WriteStartElement("OnboardCargo");
					Cargo[] onboardCargo = current2.OnboardCargo;
					Cargo[] array6 = onboardCargo;
					foreach (Cargo cargo in array6)
					{
						if (cargo.Status != 0 || cargo.DamageSeverity != 0)
						{
							xmlWriter.WriteStartElement("Cargo");
							xmlWriter.WriteElementString("ID", cargo.ObjectID);
							xmlWriter.WriteElementString("Name", cargo.Name);
							xmlWriter.WriteElementString("DBID", cargo.DBID.ToString());
							if (cargo.Status != 0)
							{
								xmlWriter.WriteElementString("St", ((byte)cargo.Status).ToString());
							}
							if (cargo.DamageSeverity != 0)
							{
								xmlWriter.WriteElementString("DamageSeverity", ((byte)cargo.DamageSeverity).ToString());
							}
							xmlWriter.WriteEndElement();
						}
					}
					xmlWriter.WriteEndElement();
					xmlWriter.WriteEndElement();
					xmlWriter.WriteEndElement();
				}
			}
			streamWriter.Close();
			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndElement();
			xmlWriter.Flush();
			xmlWriter.Close();
			StreamWriter streamWriter2 = new StreamWriter(text3 + ".exu");
			using (streamWriter2)
			{
				streamWriter2.Write(Misc.AssetRequest(memoryStream));
				streamWriter2.Flush();
				streamWriter2.Close();
			}
		}
		return true;
	}

	public static int World_GetElevation(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		double? num = LuaUtility.QueryLatitude(dictionary_);
		if (num.HasValue)
		{
			double? num2 = LuaUtility.QueryLongitude(dictionary_);
			if (!num2.HasValue)
			{
				throw new LuaError("缺少'经度'");
			}
			num = Math2.ReflectClass(num.Value);
			double value = new double?(Math2.VisitClass(num2.Value)).Value;
			return Terrain.GetElevation(num.Value, value, bool_0: false, scenario_0);
		}
		throw new LuaError("缺少'纬度'");
	}

	public static LuaTable GetLocationLuaTable(double double_0, double double_1, Scenario scenario_0)
	{
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
		geopoint_Struct.Latitude = double_0;
		geopoint_Struct.Longitude = double_1;
		geopoint_Struct.Altitude = Terrain.GetElevation(double_0, double_1, bool_0: false, scenario_0);
		if (geopoint_Struct.Latitude <= 90.0 && geopoint_Struct.Latitude >= -90.0 && geopoint_Struct.Longitude <= 180.0 && geopoint_Struct.Longitude >= -180.0)
		{
			val["altitude"] = geopoint_Struct.Altitude;
			if (geopoint_Struct.Altitude < 0f)
			{
				int int_ = 0;
				int int_2 = 0;
				float float_ = 0f;
				SonarModel.GetThermalLayerAtThisLocation(geopoint_Struct.Latitude, geopoint_Struct.Longitude, (int)Math.Round(geopoint_Struct.Altitude), ref int_, ref int_2, ref float_, bool_0: true, scenario_0);
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["ceiling"] = int_;
				val2["floor"] = int_2;
				val2["strength"] = Math.Round(float_, 2);
				val["layer"] = val2;
				if (geopoint_Struct.Altitude < (float)SonarModel.ConnectSpecification(geopoint_Struct.Latitude))
				{
					int num = (int)Math.Round(SonarModel.smethod_0(geopoint_Struct.Latitude, geopoint_Struct.Longitude, null, scenario_0));
					val2 = LuaSandBox.Singleton().CreateTable();
					val2["1"] = num;
					val2["2"] = 2 * num;
					val2["3"] = 3 * num;
					val2["4"] = 4 * num;
					val["cz"] = val2;
				}
			}
			else
			{
				val["slope"] = (int)Math.Round(100f * Terrain.InvokeWatcher(geopoint_Struct.Latitude, geopoint_Struct.Longitude, bool_0: true, scenario_0));
				string text = "";
				LandCover.LandCoverType landCoverType = LandCover.DestroyClass(geopoint_Struct.Latitude, geopoint_Struct.Longitude, scenario_0);
				text = LandCover.LogoutClass(landCoverType);
				LuaTable val3 = LuaSandBox.Singleton().CreateTable();
				val3["text"] = text;
				val3["value"] = (int)landCoverType;
				val["cover"] = val3;
			}
		}
		return val;
	}

	public static LuaTable World_GetLocation(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		double? num = LuaUtility.QueryLatitude(dictionary_);
		if (num.HasValue)
		{
			double? num2 = LuaUtility.QueryLongitude(dictionary_);
			if (!num2.HasValue)
			{
				throw new LuaError("缺少'经度'");
			}
			return GetLocationLuaTable(num.Value, num2.Value, scenario_0);
		}
		throw new LuaError("缺少'纬度'");
	}

	public static LuaTable World_GetCircleFromPoint(LuaTable luaTable_0)
	{
		try
		{
			int num = 45;
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			double? num2 = LuaUtility.QueryLatitude(dictionary);
			if (num2.HasValue)
			{
				double? num3 = LuaUtility.QueryLongitude(dictionary);
				if (num3.HasValue)
				{
					if (dictionary.ContainsKey("NUMPOINTS"))
					{
						try
						{
							num = Conversions.ToInteger(dictionary["NUMPOINTS"]);
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception exception_ = ex;
							exception_?.Data.Add("Error at PM201", "");
							GameGeneral.WriteExceptionsToLog(ref exception_);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							throw new LuaError("Numpoints必须是整数");
						}
					}
					if (dictionary.ContainsKey("RADIUS"))
					{
						float num4;
						try
						{
							num4 = Conversions.ToSingle(dictionary["RADIUS"]);
						}
						catch (Exception ex2)
						{
							ProjectData.SetProjectError(ex2);
							Exception exception_2 = ex2;
							exception_2?.Data.Add("Error at PM202", "");
							GameGeneral.WriteExceptionsToLog(ref exception_2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							throw new LuaError("半径必须是数字");
						}
						Geodesic_Vincenty.Point3D[] point3D_ = new Geodesic_Vincenty.Point3D[num + 1];
						Geodesic_Vincenty.CircleFromPoint(num2.Value, num3.Value, num4, num, ref point3D_);
						LuaTable val = LuaSandBox.Singleton().CreateTable();
						int num5 = 1;
						Geodesic_Vincenty.Point3D[] array = point3D_;
						for (int i = 0; i < array.Length; i = checked(i + 1))
						{
							Geodesic_Vincenty.Point3D point3D = array[i];
							LuaTable val2 = LuaSandBox.Singleton().CreateTable();
							val2["latitude"] = point3D.Y;
							val2["longitude"] = point3D.X;
							val2["Latitude"] = point3D.Y;
							val2["Longitude"] = point3D.X;
							val[num5] = val2;
							num5++;
						}
						return val;
					}
					throw new LuaError("未指定半径");
				}
				throw new LuaError("缺少'经度'");
			}
			throw new LuaError("缺少'纬度'");
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at PM203", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static LuaTable World_GetPointFromBearing(LuaTable luaTable_0)
	{
		double? num = null;
		double? num2 = null;
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		double? num3 = LuaUtility.QueryLatitude(dictionary);
		if (num3.HasValue)
		{
			double? num4 = LuaUtility.QueryLongitude(dictionary);
			if (num4.HasValue)
			{
				if (dictionary.ContainsKey("BEARING"))
				{
					try
					{
						num2 = Conversions.ToDouble(dictionary["BEARING"]);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at PM204", "");
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("方向必须是数字");
					}
				}
				if (dictionary.ContainsKey("DISTANCE"))
				{
					try
					{
						num = Conversions.ToDouble(dictionary["DISTANCE"]);
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at PM205", "");
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("距离必须是数字");
					}
				}
				if (Information.IsNothing(num2) || Information.IsNothing(num))
				{
					throw new LuaError("方向和距离未定义");
				}
				Geodesic_Vincenty.TCoord tcoord_ = new Geodesic_Vincenty.TCoord(num3.Value, num4.Value);
				Geodesic_Vincenty.TCoord tcoord_2 = default(Geodesic_Vincenty.TCoord);
				Geodesic_Vincenty.fw_vincenty_wgs84(ref tcoord_, ref tcoord_2, num2.Value, num.Value);
				LuaTable obj = LuaSandBox.Singleton().CreateTable();
				obj["Latitude"] = tcoord_2.Lat;
				obj["Longitude"] = tcoord_2.Lon;
				obj["latitude"] = tcoord_2.Lat;
				obj["longitude"] = tcoord_2.Lon;
				return obj;
			}
			throw new LuaError("缺少'经度'");
		}
		throw new LuaError("缺少'纬度'");
	}

	public static bool? ScenEdit_UpdateRSetting(object object_0, bool? nullable_0, Scenario scenario_0)
	{
		try
		{
			Scenario.ScenarioFeatureOption scenarioFeatureOption = (Scenario.ScenarioFeatureOption)Enum.Parse(typeof(Scenario.ScenarioFeatureOption), Conversions.ToString(object_0));
			bool? flag = LuaUtility.ParseBoolean(nullable_0);
			bool flag2 = false;
			if ((object)scenarioFeatureOption != null)
			{
				if (!flag.HasValue)
				{
					return scenario_0.DeclaredFeatures.Contains(scenarioFeatureOption);
				}
				switch (scenarioFeatureOption)
				{
				case Scenario.ScenarioFeatureOption.DetailedGunFireControl:
					flag2 = true;
					break;
				case Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines:
					flag2 = true;
					break;
				case Scenario.ScenarioFeatureOption.AircraftDamage:
					flag2 = true;
					break;
				case Scenario.ScenarioFeatureOption.CommsDisruption:
					flag2 = true;
					break;
				case Scenario.ScenarioFeatureOption.RealisticSubComms:
					flag2 = true;
					break;
				case Scenario.ScenarioFeatureOption.LandTypeEffects:
					flag2 = true;
					break;
				case Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed:
					flag2 = true;
					break;
				case Scenario.ScenarioFeatureOption.AllowLandingPlannerInstantLoading:
					flag2 = true;
					break;
				case Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced:
					flag2 = true;
					break;
				case Scenario.ScenarioFeatureOption.ACS_NAW_Limitations:
					flag2 = true;
					break;
				}
				if (scenario_0.GameContext.IsScenEditGameMode && flag2)
				{
					if (nullable_0.GetValueOrDefault())
					{
						scenario_0.DeclaredFeatures.Add(scenarioFeatureOption);
					}
					else
					{
						scenario_0.DeclaredFeatures.Remove(scenarioFeatureOption);
					}
					return true;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at PM206", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
		return null;
	}

	public static bool Tool_BuildBlankScenario(string string_0)
	{
		try
		{
			luaNewBlankScenarioEventHandler_0?.Invoke(string_0);
			return true;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
			return false;
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

	public static ActiveUnit smethod_0(string string_0, Scenario scenario_0)
	{
		ActiveUnit result = null;
		foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
		{
			if (string.Equals(activeUnits_.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(activeUnits_.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
			{
				return activeUnits_;
			}
		}
		return result;
	}

	public static ActiveUnit ValidateAUBySide(string string_0, Side side_0)
	{
		ActiveUnit result = null;
		foreach (ActiveUnit unit in side_0.Units)
		{
			if (string.Equals(unit.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(unit.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
			{
				return unit;
			}
		}
		return result;
	}

	public static Contact ValidateContactBySceanrio(string string_0, Scenario scenario_0)
	{
		Contact result = null;
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			foreach (Contact contacts_ in side.Contacts_List)
			{
				if (string.Equals(contacts_.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(contacts_.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
				{
					result = contacts_;
					return result;
				}
			}
			foreach (Contact baseContacts_ in side.BaseContacts_List)
			{
				if (string.Equals(baseContacts_.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(baseContacts_.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
				{
					result = baseContacts_;
					return result;
				}
			}
			foreach (string key in side.m_InfoFacade.Keys)
			{
				Contact contact = side.m_InfoFacade[key];
				if (string.Equals(contact.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(contact.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
				{
					result = contact;
					return result;
				}
			}
			foreach (string key2 in side.m_HelperFacade.Keys)
			{
				Contact contact2 = side.m_HelperFacade[key2];
				if (string.Equals(contact2.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(contact2.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
				{
					result = contact2;
					return result;
				}
			}
		}
		return result;
	}

	public static Contact ValidateContactBySide(string string_0, Side side_0)
	{
		Contact result = null;
		foreach (Contact contacts_ in side_0.Contacts_List)
		{
			if (string.Equals(contacts_.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(contacts_.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
			{
				result = contacts_;
				break;
			}
		}
		foreach (Contact baseContacts_ in side_0.BaseContacts_List)
		{
			if (string.Equals(baseContacts_.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(baseContacts_.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
			{
				return baseContacts_;
			}
		}
		return result;
	}

	public static ActiveUnit NextAUBySceanrio(string string_0, string string_1, Scenario scenario_0, bool bool_0 = true)
	{
		ActiveUnit result = null;
		bool flag = false;
		Group group = null;
		foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
		{
			if (Information.IsNothing(activeUnits_))
			{
				continue;
			}
			if (string.Equals(activeUnits_.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
			{
				flag = true;
				if (bool_0)
				{
					group = activeUnits_.GetParentGroup();
				}
			}
			else if (flag && string.Equals(activeUnits_.Name, string_1, StringComparison.OrdinalIgnoreCase) && (group == null || Operators.CompareString(group.ObjectID, activeUnits_.GetParentGroup().ObjectID, TextCompare: false) == 0))
			{
				return activeUnits_;
			}
		}
		return result;
	}

	public static bool RefuelIfPossible(ActiveUnit activeUnit_0, Scenario scenario_0, ref string string_0, ref ActiveUnit activeUnit_1, ref List<Mission> list_0)
	{
		string string_ = "";
		if (activeUnit_0.IsAircraft)
		{
			Aircraft aircraft = (Aircraft)activeUnit_0;
			bool bool_ = false;
			Aircraft_AirOps airOps = aircraft.AirOps;
			GeoPoint geoPoint_ = aircraft.AI.LoginClient();
			bool bool_2 = true;
			bool bool_3 = aircraft.IsRTB;
			if (!airOps.AssetProxy(geoPoint_, Doctrine._UnderwayRefuelAndReplenishmentSelection.PickNearest, ref bool_2, bool_1: false, ref activeUnit_1, ref list_0, ref string_, ref bool_3, ref bool_) && Operators.CompareString(string_, "", TextCompare: false) != 0)
			{
				string text = "";
				if (Operators.CompareString(aircraft.Name, aircraft.UnitClass, TextCompare: false) != 0)
				{
					text = " (" + aircraft.UnitClass + ")";
				}
				string_0 = "飞机" + aircraft.Name + text + "无法加油。原因：" + string_;
			}
			aircraft.AI.EvaluateUnitStatus(0f, bool_0: false, bool_1: false);
		}
		else if (activeUnit_0.IsGroup)
		{
			Group group = (Group)activeUnit_0;
			if (group.Type == Group.GroupType.AirGroup && !Information.IsNothing(((Group)activeUnit_0).GroupLead))
			{
				Aircraft aircraft2 = (Aircraft)((Group)activeUnit_0).GroupLead;
				bool bool_4 = false;
				Aircraft_AirOps airOps2 = aircraft2.AirOps;
				GeoPoint geoPoint_2 = aircraft2.AI.LoginClient();
				bool bool_5 = true;
				bool bool_6 = true;
				if (airOps2.AssetProxy(geoPoint_2, Doctrine._UnderwayRefuelAndReplenishmentSelection.PickNearest, ref bool_5, bool_1: false, ref activeUnit_1, ref list_0, ref string_, ref bool_6, ref bool_4))
				{
					Aircraft a2AR_Destination = aircraft2.AirOps.A2AR_Destination;
					if (!Information.IsNothing(a2AR_Destination))
					{
						foreach (ActiveUnit value in group.Units.Values)
						{
							if (value != aircraft2 && value.Status != ActiveUnit._ActiveUnitStatus.Refuelling && value.IsOperating() && value != a2AR_Destination)
							{
								Aircraft_AirOps obj = (Aircraft_AirOps)value.AirOps;
								value.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
								obj.Condition = Aircraft_AirOps._AirOpsCondition.ManoeuveringToRefuel;
								obj.A2AR_Destination = a2AR_Destination;
							}
						}
					}
				}
				else if (Operators.CompareString(string_, "", TextCompare: false) != 0)
				{
					string_0 = "飞机编队" + group.Name + "无法加油。原因：" + string_;
				}
			}
			group.AI.EvaluateUnitStatus(0f, bool_0: false, bool_1: false);
		}
		Ship ship = null;
		if (activeUnit_0.IsShip)
		{
			ship = (Ship)activeUnit_0;
			if (ship != null)
			{
				(ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP, string) tuple = ship.DockingOps.IncludeDic(ship.AI.LoginClient(), activeUnit_1, list_0, bool_0: false, 100);
				if (tuple.Item1 != ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success && !string.IsNullOrEmpty(tuple.Item2))
				{
					string_0 = "舰艇" + ship.Name + "不能补给。原因：" + tuple.Item2;
				}
				ship.AI.EvaluateUnitStatus(0f, bool_0: false, bool_1: false);
			}
		}
		if (activeUnit_0.IsGroup)
		{
			Group group2 = (Group)activeUnit_0;
			if (group2.Type == Group.GroupType.SurfaceGroup || group2.Type == Group.GroupType.SubGroup)
			{
				foreach (ActiveUnit value2 in group2.Units.Values)
				{
					string_ = "";
					if (value2.IsShip || value2.IsSubmarine)
					{
						(ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP, string) tuple2 = value2.DockingOps.IncludeDic(value2.AI.LoginClient(), activeUnit_1, list_0, bool_0: false, 100);
						if (tuple2.Item1 != ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success && !string.IsNullOrEmpty(tuple2.Item2))
						{
							string_0 = "单元" + value2.Name + "不能补给。原因：" + tuple2.Item2;
						}
					}
				}
				group2.AI.EvaluateUnitStatus(0f, bool_0: false, bool_1: false);
			}
		}
		return true;
	}
}
