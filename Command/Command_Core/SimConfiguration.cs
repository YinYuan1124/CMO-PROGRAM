using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using CoordinateSharp;
using Microsoft.VisualBasic.CompilerServices;
using Nini.Config;

namespace Command_Core;

[StandardModule]
public sealed class SimConfiguration
{
	public enum WindowPauseBehaviour
	{
		Pause,
		SlowToRealTime,
		CurrentTimeCompression
	}

	public static string DefaultDB_Hash;

	public static Game.GamePreferences DefaultGamePreferences;

	[SpecialName]
	private static string GetCommandConfigFilePath()
	{
		return Path.Combine(GameGeneral.ConfigFolderPath, "Command.ini");
	}

	[SpecialName]
	private static string smethod_0()
	{
		return Path.Combine(GameGeneral.ConfigFolderPath, "CPE.ini");
	}

	[SpecialName]
	private static string GetBetaConfigFilePath()
	{
		return Path.Combine(GameGeneral.ConfigFolderPath, "Beta.ini");
	}

	[SpecialName]
	private static string GetExternalUrlsConfigFilePath()
	{
		return Path.Combine(GameGeneral.ConfigFolderPath, "ExternalURLs.ini");
	}

	public static void LoadSettings(ref Dictionary<string, Tuple<int, int, int, int>> dictionary_0, ref List<string> list_0)
	{
		try
		{
			if (!FileExistsNative.FileExistsFast(GetCommandConfigFilePath()))
			{
				CreateDefaultSettings();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 00000000000001", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		IniConfigSource iniConfigSource = new IniConfigSource(GetCommandConfigFilePath());
		try
		{
			DefaultDB_Hash = iniConfigSource.Configs["General"].Get("DefaultDB");
		}
		catch (Exception ex12)
		{
			ProjectData.SetProjectError(ex12);
			Exception exception_12 = ex12;
			exception_12?.Data.Add("Error at 00000000000002", "");
			GameGeneral.WriteExceptionsToLog(ref exception_12);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		DefaultGamePreferences = new Game.GamePreferences();
		try
		{
			DefaultGamePreferences.UseAutosave = Conversions.ToBoolean(iniConfigSource.Configs["Game Preferences"].Get("UseAutosave"));
		}
		catch (Exception ex23)
		{
			ProjectData.SetProjectError(ex23);
			Exception exception_23 = ex23;
			exception_23?.Data.Add("Error at 00000000000003", "");
			GameGeneral.WriteExceptionsToLog(ref exception_23);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			DefaultGamePreferences.RunCoreMultithreaded = Conversions.ToBoolean(iniConfigSource.Configs["Game Preferences"].Get("RunCoreMultithreaded"));
		}
		catch (Exception ex34)
		{
			ProjectData.SetProjectError(ex34);
			Exception exception_34 = ex34;
			exception_34?.Data.Add("Error at 00000000000004", "");
			GameGeneral.WriteExceptionsToLog(ref exception_34);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			DefaultGamePreferences.ShowDiagnostics = Conversions.ToBoolean(iniConfigSource.Configs["Game Preferences"].Get("ShowDiagnostics"));
		}
		catch (Exception ex45)
		{
			ProjectData.SetProjectError(ex45);
			Exception exception_45 = ex45;
			exception_45?.Data.Add("Error at 00000000000005", "");
			GameGeneral.WriteExceptionsToLog(ref exception_45);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		string text = iniConfigSource.Configs["Game Preferences"].Get("MessageLogInWindow");
		try
		{
			if (text == null)
			{
				DefaultGamePreferences.MessageLogInWindow = false;
			}
			else
			{
				DefaultGamePreferences.MessageLogInWindow = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex56)
		{
			ProjectData.SetProjectError(ex56);
			Exception exception_56 = ex56;
			exception_56?.Data.Add("Error at 00000000000006", "");
			GameGeneral.WriteExceptionsToLog(ref exception_56);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("GameSounds");
			if (text == null)
			{
				DefaultGamePreferences.GameSounds = true;
			}
			else
			{
				DefaultGamePreferences.GameSounds = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex59)
		{
			ProjectData.SetProjectError(ex59);
			Exception exception_59 = ex59;
			exception_59?.Data.Add("Error at 00000000000007", "");
			GameGeneral.WriteExceptionsToLog(ref exception_59);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("SFXVolume");
			if (text == null)
			{
				DefaultGamePreferences.Int32_0 = 75;
			}
			else
			{
				DefaultGamePreferences.Int32_0 = Conversions.ToInteger(text);
			}
		}
		catch (Exception ex60)
		{
			ProjectData.SetProjectError(ex60);
			Exception exception_60 = ex60;
			exception_60?.Data.Add("Error at 00000000000008", "");
			GameGeneral.WriteExceptionsToLog(ref exception_60);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("GameMusic");
			if (text == null)
			{
				DefaultGamePreferences.GameMusic = true;
			}
			else
			{
				DefaultGamePreferences.GameMusic = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex61)
		{
			ProjectData.SetProjectError(ex61);
			Exception exception_61 = ex61;
			exception_61?.Data.Add("Error at 00000000000009", "");
			GameGeneral.WriteExceptionsToLog(ref exception_61);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("MusicVolume");
			if (text == null)
			{
				DefaultGamePreferences.MusicVolume = 75;
			}
			else
			{
				DefaultGamePreferences.MusicVolume = Conversions.ToInteger(text);
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 00000000000010", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("ShowAltitudeInFeet");
			if (text == null)
			{
				DefaultGamePreferences.ShowAltitudeInFeet = false;
			}
			else
			{
				DefaultGamePreferences.ShowAltitudeInFeet = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 00000000000011", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("ShowUSUnitsInEditCargo");
			if (text == null)
			{
				DefaultGamePreferences.ShowUSUnitsForEditCargo = false;
			}
			else
			{
				DefaultGamePreferences.ShowUSUnitsForEditCargo = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex4)
		{
			ProjectData.SetProjectError(ex4);
			Exception exception_4 = ex4;
			exception_4?.Data.Add("Error at 00000000000012", "");
			GameGeneral.WriteExceptionsToLog(ref exception_4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("GroundUnitsSpeedUnit");
			if (text == null)
			{
				DefaultGamePreferences.GroundUnitsSpeedUnit = Game.GamePreferences.SpeedUnitSetting.Knots;
			}
			else
			{
				DefaultGamePreferences.GroundUnitsSpeedUnit = (Game.GamePreferences.SpeedUnitSetting)Conversions.ToByte(text);
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception exception_5 = ex5;
			exception_5?.Data.Add("Error at 00000000000013", "");
			GameGeneral.WriteExceptionsToLog(ref exception_5);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("GeoCoordinateType");
			if (text == null)
			{
				DefaultGamePreferences.GeoCoordinateType = Parse_Format_Type.Degree_Minute_Second;
			}
			else
			{
				DefaultGamePreferences.GeoCoordinateType = (Parse_Format_Type)Conversions.ToInteger(text);
			}
		}
		catch (Exception ex6)
		{
			ProjectData.SetProjectError(ex6);
			Exception exception_6 = ex6;
			exception_6?.Data.Add("Error at 00000000000014", "");
			GameGeneral.WriteExceptionsToLog(ref exception_6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("ZoomOnCursor");
			if (text == null)
			{
				DefaultGamePreferences.ZoomOnCursor = false;
			}
			else
			{
				DefaultGamePreferences.ZoomOnCursor = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception exception_7 = ex7;
			exception_7?.Data.Add("Error at 00000000000015", "");
			GameGeneral.WriteExceptionsToLog(ref exception_7);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("SonobuoyVisibility");
			if (text == null)
			{
				DefaultGamePreferences.SonobuoyVisibility = Game.GamePreferences.SonobuoyVisibilitySetting.Normal;
			}
			else
			{
				DefaultGamePreferences.SonobuoyVisibility = (Game.GamePreferences.SonobuoyVisibilitySetting)Conversions.ToByte(text);
			}
		}
		catch (Exception ex8)
		{
			ProjectData.SetProjectError(ex8);
			Exception exception_8 = ex8;
			exception_8?.Data.Add("Error at 00000000000016", "");
			GameGeneral.WriteExceptionsToLog(ref exception_8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("RefPointVisibility");
			if (text == null)
			{
				DefaultGamePreferences.RefPointVisibility = Game.GamePreferences.RefPointVisibilitySetting.Normal;
			}
			else
			{
				DefaultGamePreferences.RefPointVisibility = (Game.GamePreferences.RefPointVisibilitySetting)Conversions.ToByte(text);
			}
		}
		catch (Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			Exception exception_9 = ex9;
			exception_9?.Data.Add("Error at 00000000000017", "");
			GameGeneral.WriteExceptionsToLog(ref exception_9);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("MapSymbolsSet");
			if (text == null)
			{
				DefaultGamePreferences.MapSymbolsSet = Game.GamePreferences.MapSymbolsSetting.Directional;
			}
			else
			{
				DefaultGamePreferences.MapSymbolsSet = (Game.GamePreferences.MapSymbolsSetting)Conversions.ToByte(text);
			}
		}
		catch (Exception ex10)
		{
			ProjectData.SetProjectError(ex10);
			Exception exception_10 = ex10;
			exception_10?.Data.Add("Error at 00000000000018", "");
			GameGeneral.WriteExceptionsToLog(ref exception_10);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("MapCursorBox");
			if (text == null)
			{
				DefaultGamePreferences.MapCursorBox = Game.GamePreferences.MapCursorBoxVisibilitySetting.Bottom;
			}
			else
			{
				DefaultGamePreferences.MapCursorBox = (Game.GamePreferences.MapCursorBoxVisibilitySetting)Conversions.ToByte(text);
			}
		}
		catch (Exception ex11)
		{
			ProjectData.SetProjectError(ex11);
			Exception exception_11 = ex11;
			exception_11?.Data.Add("Error at 00000000000019", "");
			GameGeneral.WriteExceptionsToLog(ref exception_11);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("ShowGhostedGroupMembers");
			if (text == null)
			{
				DefaultGamePreferences.ShowGhostedGroupMembers = Game.GamePreferences.GhostedGroupMembersVisibilitySetting.DontShow;
			}
			else
			{
				DefaultGamePreferences.ShowGhostedGroupMembers = (Game.GamePreferences.GhostedGroupMembersVisibilitySetting)Conversions.ToByte(text);
			}
		}
		catch (Exception ex13)
		{
			ProjectData.SetProjectError(ex13);
			Exception exception_13 = ex13;
			exception_13?.Data.Add("Error at 00000000000020", "");
			GameGeneral.WriteExceptionsToLog(ref exception_13);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("ShowPlottedPaths");
			if (text == null)
			{
				DefaultGamePreferences.ShowPlottedPaths = Game.GamePreferences.PlottedPathsVisibilitySetting.All;
			}
			else
			{
				DefaultGamePreferences.ShowPlottedPaths = (Game.GamePreferences.PlottedPathsVisibilitySetting)Conversions.ToByte(text);
			}
		}
		catch (Exception ex14)
		{
			ProjectData.SetProjectError(ex14);
			Exception exception_14 = ex14;
			exception_14?.Data.Add("Error at 00000000000021", "");
			GameGeneral.WriteExceptionsToLog(ref exception_14);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("ShowFlightPlans_Airborne");
			if (text == null)
			{
				DefaultGamePreferences.ShowFlightPlans_Airborne = Game.GamePreferences.FlightPlansVisibilitySetting_Airborne.All;
			}
			else
			{
				DefaultGamePreferences.ShowFlightPlans_Airborne = (Game.GamePreferences.FlightPlansVisibilitySetting_Airborne)Conversions.ToByte(text);
			}
		}
		catch (Exception ex15)
		{
			ProjectData.SetProjectError(ex15);
			Exception exception_15 = ex15;
			exception_15?.Data.Add("Error at 00000000000022", "");
			GameGeneral.WriteExceptionsToLog(ref exception_15);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("ShowFlightPlans_Planned");
			if (text == null)
			{
				DefaultGamePreferences.ShowFlightPlans_Planned = Game.GamePreferences.FlightPlansVisibilitySetting_Planned.All;
			}
			else
			{
				DefaultGamePreferences.ShowFlightPlans_Planned = (Game.GamePreferences.FlightPlansVisibilitySetting_Planned)Conversions.ToByte(text);
			}
		}
		catch (Exception ex16)
		{
			ProjectData.SetProjectError(ex16);
			Exception exception_16 = ex16;
			exception_16?.Data.Add("Error at 00000000000023", "");
			GameGeneral.WriteExceptionsToLog(ref exception_16);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("ShowAU_Behaviour_Bark");
			if (text == null)
			{
				DefaultGamePreferences.ShowAU_Behaviour_Bark = Game.GamePreferences.Unit_Behaviour_Bark.SelectedUnit;
			}
			else
			{
				DefaultGamePreferences.ShowAU_Behaviour_Bark = (Game.GamePreferences.Unit_Behaviour_Bark)Conversions.ToByte(text);
			}
		}
		catch (Exception ex17)
		{
			ProjectData.SetProjectError(ex17);
			Exception exception_17 = ex17;
			exception_17?.Data.Add("Error at 00000000000024", "");
			GameGeneral.WriteExceptionsToLog(ref exception_17);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("ShowMissionArea");
			if (text == null)
			{
				DefaultGamePreferences.ShowMissionArea = Game.GamePreferences.ObjectVisibilitySetting.Selected;
			}
			else
			{
				DefaultGamePreferences.ShowMissionArea = (Game.GamePreferences.ObjectVisibilitySetting)Conversions.ToShort(text);
			}
		}
		catch (Exception ex18)
		{
			ProjectData.SetProjectError(ex18);
			Exception exception_18 = ex18;
			exception_18?.Data.Add("Error at 00000000000025", "");
			GameGeneral.WriteExceptionsToLog(ref exception_18);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("OnlyShowAvailableLoadouts");
			if (text == null)
			{
				DefaultGamePreferences.OnlyShowAvailableLoadouts = false;
			}
			else
			{
				DefaultGamePreferences.OnlyShowAvailableLoadouts = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex19)
		{
			ProjectData.SetProjectError(ex19);
			Exception exception_19 = ex19;
			exception_19?.Data.Add("Error at 00000000000026", "");
			GameGeneral.WriteExceptionsToLog(ref exception_19);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("UnitStatusImage");
			if (text == null)
			{
				DefaultGamePreferences.UnitStatusImage = true;
			}
			else
			{
				DefaultGamePreferences.UnitStatusImage = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex20)
		{
			ProjectData.SetProjectError(ex20);
			Exception exception_20 = ex20;
			exception_20?.Data.Add("Error at 00000000000027", "");
			GameGeneral.WriteExceptionsToLog(ref exception_20);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("SalvoTimeout");
			if (text == null)
			{
				DefaultGamePreferences.SalvoTimeout = true;
			}
			else
			{
				DefaultGamePreferences.SalvoTimeout = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex21)
		{
			ProjectData.SetProjectError(ex21);
			Exception exception_21 = ex21;
			exception_21?.Data.Add("Error at 00000000000028", "");
			GameGeneral.WriteExceptionsToLog(ref exception_21);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("ShowAutomaticFireInfo");
			if (text == null)
			{
				DefaultGamePreferences.ShowAutomaticFireInfo = true;
			}
			else
			{
				DefaultGamePreferences.ShowAutomaticFireInfo = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex22)
		{
			ProjectData.SetProjectError(ex22);
			Exception exception_22 = ex22;
			exception_22?.Data.Add("Error at 00000000000029", "");
			GameGeneral.WriteExceptionsToLog(ref exception_22);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("ShowGameSpeedButton");
			if (text == null)
			{
				DefaultGamePreferences.ShowGameSpeedButton = false;
			}
			else
			{
				DefaultGamePreferences.ShowGameSpeedButton = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex24)
		{
			ProjectData.SetProjectError(ex24);
			Exception exception_24 = ex24;
			exception_24?.Data.Add("Error at 00000000000030", "");
			GameGeneral.WriteExceptionsToLog(ref exception_24);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("LogDebugInfoToFile");
			if (text == null)
			{
				DefaultGamePreferences.LogDebugInfoToFile = false;
			}
			else
			{
				DefaultGamePreferences.LogDebugInfoToFile = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex25)
		{
			ProjectData.SetProjectError(ex25);
			Exception exception_25 = ex25;
			exception_25?.Data.Add("Error at 00000000000031", "");
			GameGeneral.WriteExceptionsToLog(ref exception_25);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("DrawOutlines");
			if (text == null)
			{
				DefaultGamePreferences.PlacenameVisibility = true;
			}
			else
			{
				DefaultGamePreferences.PlacenameVisibility = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex26)
		{
			ProjectData.SetProjectError(ex26);
			Exception exception_26 = ex26;
			exception_26?.Data.Add("Error at 00000000000032", "");
			GameGeneral.WriteExceptionsToLog(ref exception_26);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("MessageLogCanvas");
			if (text == null)
			{
				DefaultGamePreferences.MessageLogCanvas = true;
			}
			else
			{
				DefaultGamePreferences.MessageLogCanvas = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex27)
		{
			ProjectData.SetProjectError(ex27);
			Exception exception_27 = ex27;
			exception_27?.Data.Add("Error at 00000000000033", "");
			GameGeneral.WriteExceptionsToLog(ref exception_27);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("NavigationMaxDistanceNMSetting");
			if (text == null)
			{
				DefaultGamePreferences.NavigationMaxDistanceNMSetting = 8f;
			}
			else
			{
				DefaultGamePreferences.NavigationMaxDistanceNMSetting = Convert.ToSingle(text, CultureInfo.InvariantCulture);
			}
		}
		catch (Exception ex28)
		{
			ProjectData.SetProjectError(ex28);
			Exception exception_28 = ex28;
			exception_28?.Data.Add("Error at 00000000000034", "");
			GameGeneral.WriteExceptionsToLog(ref exception_28);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("RMB_MoveOrder_Sensivity");
			if (text == null)
			{
				DefaultGamePreferences.RMB_MoveOrder_Enabled = true;
			}
			else
			{
				DefaultGamePreferences.RMB_MoveOrder_Enabled = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex29)
		{
			ProjectData.SetProjectError(ex29);
			Exception exception_29 = ex29;
			exception_29?.Data.Add("Error at 00000000000035", "");
			GameGeneral.WriteExceptionsToLog(ref exception_29);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("NavigationThresholdDistanceDegSetting");
			if (text == null)
			{
				DefaultGamePreferences.NavigationThresholdDistanceDegSetting = 0.5f;
			}
			else
			{
				DefaultGamePreferences.NavigationThresholdDistanceDegSetting = Convert.ToSingle(text, CultureInfo.InvariantCulture);
			}
		}
		catch (Exception ex30)
		{
			ProjectData.SetProjectError(ex30);
			Exception exception_30 = ex30;
			exception_30?.Data.Add("Error at 00000000000036", "");
			GameGeneral.WriteExceptionsToLog(ref exception_30);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("AllowPowerPlanSwitch");
			if (text == null)
			{
				DefaultGamePreferences.AllowPowerPlanSwitch = true;
			}
			else
			{
				DefaultGamePreferences.AllowPowerPlanSwitch = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex31)
		{
			ProjectData.SetProjectError(ex31);
			Exception exception_31 = ex31;
			exception_31?.Data.Add("Error at 00000000000037", "");
			GameGeneral.WriteExceptionsToLog(ref exception_31);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("TacviewExePath");
			if (text != null)
			{
				DefaultGamePreferences.TacviewExePath = text;
			}
		}
		catch (Exception ex32)
		{
			ProjectData.SetProjectError(ex32);
			Exception exception_32 = ex32;
			exception_32?.Data.Add("Error at 00000000000038", "");
			GameGeneral.WriteExceptionsToLog(ref exception_32);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("ColorDataBlocks");
			if (text == null)
			{
				DefaultGamePreferences.ColorDataBlocks = false;
			}
			else
			{
				DefaultGamePreferences.ColorDataBlocks = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex33)
		{
			ProjectData.SetProjectError(ex33);
			Exception exception_33 = ex33;
			exception_33?.Data.Add("Error at 00000000000039", "");
			GameGeneral.WriteExceptionsToLog(ref exception_33);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("DedupAlliedMessages");
			if (text == null)
			{
				GameGeneral.DedupAlliedMessages = true;
			}
			else
			{
				GameGeneral.DedupAlliedMessages = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex35)
		{
			ProjectData.SetProjectError(ex35);
			Exception exception_35 = ex35;
			exception_35?.Data.Add("Error at 00000000000040", "");
			GameGeneral.WriteExceptionsToLog(ref exception_35);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("UsePersonalMapProfile");
			if (text == null)
			{
				DefaultGamePreferences.UsePersonalMapProfile = true;
			}
			else
			{
				DefaultGamePreferences.UsePersonalMapProfile = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex36)
		{
			ProjectData.SetProjectError(ex36);
			Exception exception_36 = ex36;
			exception_36?.Data.Add("Error at 00000000000041", "");
			GameGeneral.WriteExceptionsToLog(ref exception_36);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("StartFullScreen");
			if (text == null)
			{
				DefaultGamePreferences.StartFullScreen = false;
			}
			else
			{
				DefaultGamePreferences.StartFullScreen = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex37)
		{
			ProjectData.SetProjectError(ex37);
			Exception exception_37 = ex37;
			exception_37?.Data.Add("Error at 00000000000042", "");
			GameGeneral.WriteExceptionsToLog(ref exception_37);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("PersonalMapProfile");
			if (text != null)
			{
				try
				{
					DefaultGamePreferences.PersonalMapProfile = MapProfile.FromXML(Crypto.ListImporter(text, "HermanDingleberry"));
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
			}
		}
		catch (Exception ex38)
		{
			ProjectData.SetProjectError(ex38);
			Exception exception_38 = ex38;
			exception_38?.Data.Add("Error at 00000000000043", "");
			GameGeneral.WriteExceptionsToLog(ref exception_38);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("RecentlyOpened");
			if (text != null)
			{
				list_0 = text.Split(Conversions.ToCharArrayRankOne("|")).ToList();
			}
			string[] keys = iniConfigSource.Configs["MessageLog Preferences"].GetKeys();
			string[] array3 = keys;
			foreach (string text2 in array3)
			{
				string[] array = iniConfigSource.Configs["MessageLog Preferences"].Get(text2).Split('|');
				LoggedMessage.MessageType key;
				if (Operators.CompareString(text2, "ScenarioGoalFulfil", TextCompare: false) == 0)
				{
					key = LoggedMessage.MessageType.EventEngine;
				}
				else
				{
					if (Operators.CompareString(text2, "OECM_Activity", TextCompare: false) == 0)
					{
						continue;
					}
					try
					{
						key = (LoggedMessage.MessageType)Enum.Parse(typeof(LoggedMessage.MessageType), text2, ignoreCase: true);
					}
					catch (Exception ex39)
					{
						ProjectData.SetProjectError(ex39);
						Exception exception_39 = ex39;
						exception_39?.Data.Add("Error at 200499", exception_39.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_39);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						continue;
					}
				}
				bool bool_ = false;
				if (array.Length > 2)
				{
					bool_ = Conversions.ToBoolean(array[2]);
				}
				bool bool_2 = false;
				if (array.Length > 3)
				{
					bool_2 = Conversions.ToBoolean(array[3]);
				}
				DefaultGamePreferences.MessageLogSettings[key] = new LoggedMessage.MessageSettings(Conversions.ToBoolean(array[0]), Conversions.ToBoolean(array[1]), bool_, bool_2);
			}
			if (dictionary_0 != null && iniConfigSource.Configs["Secondary Window Settings"] != null)
			{
				dictionary_0.Clear();
				keys = iniConfigSource.Configs["Secondary Window Settings"].GetKeys();
				string[] array4 = keys;
				foreach (string text3 in array4)
				{
					string[] array2 = iniConfigSource.Configs["Secondary Window Settings"].Get(text3).Split('|');
					dictionary_0.Add(text3, new Tuple<int, int, int, int>(Conversions.ToInteger(array2[0]), Conversions.ToInteger(array2[1]), Conversions.ToInteger(array2[2]), Conversions.ToInteger(array2[3])));
				}
			}
		}
		catch (Exception ex40)
		{
			ProjectData.SetProjectError(ex40);
			Exception exception_40 = ex40;
			exception_40?.Data.Add("Error at 00000000000044", "");
			GameGeneral.WriteExceptionsToLog(ref exception_40);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("PauseOnDBView");
			bool result;
			if (text == null)
			{
				DefaultGamePreferences.PauseOnDBView = WindowPauseBehaviour.Pause;
			}
			else if (bool.TryParse(text, out result))
			{
				if (!result)
				{
					DefaultGamePreferences.PauseOnDBView = WindowPauseBehaviour.CurrentTimeCompression;
				}
				else
				{
					DefaultGamePreferences.PauseOnDBView = WindowPauseBehaviour.Pause;
				}
			}
			else
			{
				DefaultGamePreferences.PauseOnDBView = (WindowPauseBehaviour)Conversions.ToInteger(text);
			}
		}
		catch (Exception ex41)
		{
			ProjectData.SetProjectError(ex41);
			Exception exception_41 = ex41;
			exception_41?.Data.Add("Error at 00000000000045", "");
			GameGeneral.WriteExceptionsToLog(ref exception_41);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("PauseOnAirDockOps");
			if (text == null)
			{
				DefaultGamePreferences.PauseOnAirDockOps = WindowPauseBehaviour.Pause;
			}
			else
			{
				DefaultGamePreferences.PauseOnAirDockOps = (WindowPauseBehaviour)Conversions.ToInteger(text);
			}
		}
		catch (Exception ex42)
		{
			ProjectData.SetProjectError(ex42);
			Exception exception_42 = ex42;
			exception_42?.Data.Add("Error at 00000000000045", "");
			GameGeneral.WriteExceptionsToLog(ref exception_42);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("AllowInGameDownloads");
			if (text == null)
			{
				DefaultGamePreferences.AllowInGameDownloads = true;
			}
			else
			{
				DefaultGamePreferences.AllowInGameDownloads = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex43)
		{
			ProjectData.SetProjectError(ex43);
			Exception exception_43 = ex43;
			exception_43?.Data.Add("Error at 00000000000046", "");
			GameGeneral.WriteExceptionsToLog(ref exception_43);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("SlugTrailTimeFrequency");
			if (text == null)
			{
				DefaultGamePreferences.SlugTrailTimeFrequency = SlugTrailTimeFrequency.FithSecond;
			}
			else
			{
				DefaultGamePreferences.SlugTrailTimeFrequency = (SlugTrailTimeFrequency)Conversions.ToInteger(text);
			}
		}
		catch (Exception ex44)
		{
			ProjectData.SetProjectError(ex44);
			Exception exception_44 = ex44;
			exception_44?.Data.Add("Error at 00000000000047", "");
			GameGeneral.WriteExceptionsToLog(ref exception_44);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("SlugTrail_Use");
			if (text == null)
			{
				DefaultGamePreferences.SlugTrail_Use = false;
			}
			else
			{
				DefaultGamePreferences.SlugTrail_Use = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex46)
		{
			ProjectData.SetProjectError(ex46);
			Exception exception_46 = ex46;
			exception_46?.Data.Add("Error at 00000000000048", "");
			GameGeneral.WriteExceptionsToLog(ref exception_46);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("SlugTrail_OwnAndAllied");
			if (text == null)
			{
				DefaultGamePreferences.SlugTrail_OwnAndAllied = false;
			}
			else
			{
				DefaultGamePreferences.SlugTrail_OwnAndAllied = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex47)
		{
			ProjectData.SetProjectError(ex47);
			Exception exception_47 = ex47;
			exception_47?.Data.Add("Error at 00000000000049", "");
			GameGeneral.WriteExceptionsToLog(ref exception_47);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("SlugTrail_Neutral");
			if (text == null)
			{
				DefaultGamePreferences.SlugTrail_Neutral = false;
			}
			else
			{
				DefaultGamePreferences.SlugTrail_Neutral = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex48)
		{
			ProjectData.SetProjectError(ex48);
			Exception exception_48 = ex48;
			exception_48?.Data.Add("Error at 00000000000050", "");
			GameGeneral.WriteExceptionsToLog(ref exception_48);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("SlugTrail_Hostile");
			if (text == null)
			{
				DefaultGamePreferences.SlugTrail_Hostile = false;
			}
			else
			{
				DefaultGamePreferences.SlugTrail_Hostile = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex49)
		{
			ProjectData.SetProjectError(ex49);
			Exception exception_49 = ex49;
			exception_49?.Data.Add("Error at 00000000000051", "");
			GameGeneral.WriteExceptionsToLog(ref exception_49);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("SlugTrail_Friendly");
			if (text == null)
			{
				DefaultGamePreferences.SlugTrail_Friendly = false;
			}
			else
			{
				DefaultGamePreferences.SlugTrail_Friendly = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex50)
		{
			ProjectData.SetProjectError(ex50);
			Exception exception_50 = ex50;
			exception_50?.Data.Add("Error at 00000000000052", "");
			GameGeneral.WriteExceptionsToLog(ref exception_50);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("SlugTrail_Unfriendly");
			if (text == null)
			{
				DefaultGamePreferences.SlugTrail_Unfriendly = false;
			}
			else
			{
				DefaultGamePreferences.SlugTrail_Unfriendly = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex51)
		{
			ProjectData.SetProjectError(ex51);
			Exception exception_51 = ex51;
			exception_51?.Data.Add("Error at 00000000000053", "");
			GameGeneral.WriteExceptionsToLog(ref exception_51);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("SlugTrail_UnKnown");
			if (text == null)
			{
				DefaultGamePreferences.SlugTrail_UnKnown = false;
			}
			else
			{
				DefaultGamePreferences.SlugTrail_UnKnown = Conversions.ToBoolean(text);
			}
		}
		catch (Exception ex52)
		{
			ProjectData.SetProjectError(ex52);
			Exception exception_52 = ex52;
			exception_52?.Data.Add("Error at 00000000000054", "");
			GameGeneral.WriteExceptionsToLog(ref exception_52);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("SlugTrail_LifeTime");
			if (text == null)
			{
				DefaultGamePreferences.SlugTrail_LifeTime = 180;
			}
			else
			{
				DefaultGamePreferences.SlugTrail_LifeTime = Conversions.ToInteger(text);
			}
		}
		catch (Exception ex53)
		{
			ProjectData.SetProjectError(ex53);
			Exception exception_53 = ex53;
			exception_53?.Data.Add("Error at 00000000000050", "");
			GameGeneral.WriteExceptionsToLog(ref exception_53);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("GroundUnitZoom");
			if (text == null)
			{
				DefaultGamePreferences.GroundUnitZoom = 20;
			}
			else
			{
				DefaultGamePreferences.GroundUnitZoom = Conversions.ToInteger(text);
			}
		}
		catch (Exception ex54)
		{
			ProjectData.SetProjectError(ex54);
			Exception exception_54 = ex54;
			exception_54?.Data.Add("Error at 00000000000950", "");
			GameGeneral.WriteExceptionsToLog(ref exception_54);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("DiamondZoom");
			if (text == null)
			{
				DefaultGamePreferences.DiamondZoom = 30;
			}
			else
			{
				DefaultGamePreferences.DiamondZoom = Conversions.ToInteger(text);
			}
		}
		catch (Exception ex55)
		{
			ProjectData.SetProjectError(ex55);
			Exception exception_55 = ex55;
			exception_55?.Data.Add("Error at 00000000000951", "");
			GameGeneral.WriteExceptionsToLog(ref exception_55);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("RectangleZoom");
			if (text == null)
			{
				DefaultGamePreferences.RectangleZoom = 30;
			}
			else
			{
				DefaultGamePreferences.RectangleZoom = Conversions.ToInteger(text);
			}
		}
		catch (Exception ex57)
		{
			ProjectData.SetProjectError(ex57);
			Exception exception_57 = ex57;
			exception_57?.Data.Add("Error at 00000000000952", "");
			GameGeneral.WriteExceptionsToLog(ref exception_57);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			text = iniConfigSource.Configs["Game Preferences"].Get("FlowerZoom");
			if (text == null)
			{
				DefaultGamePreferences.FlowerZoom = 30;
			}
			else
			{
				DefaultGamePreferences.FlowerZoom = Conversions.ToInteger(text);
			}
		}
		catch (Exception ex58)
		{
			ProjectData.SetProjectError(ex58);
			Exception exception_58 = ex58;
			exception_58?.Data.Add("Error at 00000000000953", "");
			GameGeneral.WriteExceptionsToLog(ref exception_58);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void CreateDefaultSettings()
	{
		IniConfigSource iniConfigSource = new IniConfigSource();
		try
		{
			iniConfigSource.AddConfig("General").Set("DefaultDB", 1);
			IConfig config = iniConfigSource.AddConfig("Realism Settings");
			config.Set("DetailedGunFireControl", "True");
			config.Set("UnlimitedAirWeapons", "False");
			config.Set("CommsJamming", "False");
			config.Set("AircraftDamage", "False");
			IConfig config2 = iniConfigSource.AddConfig("Game Preferences");
			config2.Set("UseAutosave", "True");
			config2.Set("RunCoreMultithreaded", "False");
			config2.Set("ShowDiagnostics", "False");
			config2.Set("MessageLogInWindow", "False");
			config2.Set("GameSounds", "True");
			config2.Set("SFXVolume", "75");
			config2.Set("GameMusic", "True");
			config2.Set("MusicVolume", "75");
			config2.Set("ShowAltitudeInFeet", "True");
			config2.Set("ShowUSUnitsInEditCargo", "False");
			config2.Set("SonobuoyVisibility", "1");
			config2.Set("ZoomOnCursor", "False");
			config2.Set("RefPointVisibility", "0");
			config2.Set("MapSymbolsSet", "2");
			config2.Set("MapCursorBox", "0");
			config2.Set("HighFidelityMode", "True");
			config2.Set("NoPulseMapUpdate", "True");
			config2.Set("ShowGhostedGroupMembers", "1");
			config2.Set("NavigationMaxDistanceNMSetting", "8");
			config2.Set("NavigationThresholdDistanceDegSetting", "0.5");
			config2.Set("ShowPlottedPaths", "1");
			config2.Set("ShowFlightPlans", "0");
			config2.Set("ShowMissionArea", "1");
			config2.Set("OnlyShowAvailableLoadouts", "False");
			config2.Set("UnitStatusImage", "True");
			config2.Set("SalvoTimeout", "True");
			config2.Set("DrawOutlines", "True");
			config2.Set("MessageLogCanvas", "True");
			config2.Set("AllowPowerPlanSwitch", "True");
			config2.Set("ShowGameSpeedButton", "False");
			config2.Set("LogDebugInfoToFile", "True");
			config2.Set("DPIScalingMethod", "0");
			IConfig config3 = iniConfigSource.AddConfig("MessageLog Preferences");
			config3.Set("NewContact", "1|0|0|1");
			config3.Set("CommsIsolatedMessage", "1|0|0");
			config3.Set("ContactChange", "1|0|0");
			config3.Set("WeaponEndgame", "1|0|0");
			config3.Set("WeaponDamage", "1|0|0");
			config3.Set("AirOps", "0|0|0");
			config3.Set("UnitLost", "1|1|1|1");
			config3.Set("UnitDamage", "1|0|1|1");
			config3.Set("PointDefence", "0|0|0");
			config3.Set("UI", "1|0|0");
			config3.Set("WeaponLogic", "0|0|0");
			config3.Set("UnitAI", "0|0|0");
			config3.Set("EventEngine", "0|0|0");
			config3.Set("NewWeaponContact", "1|1|1|1");
			config3.Set("DockingOps", "0|0|0");
			config3.Set("SpecialMessage", "1|1|1|1");
			config3.Set("NewMineContact", "1|0|0|1");
			config3.Set("NewAirContact", "1|0|0|1");
			config3.Set("NewSurfaceContact", "1|0|0|1");
			config3.Set("NewUnderwaterContact", "1|0|0|1");
			config3.Set("NewGroundContact", "1|0|0|1");
			config3.Set("UnguidedWeaponModifiers", "0|0|0");
			iniConfigSource.AddConfig("Secondary Window Settings");
			iniConfigSource.Save(GetCommandConfigFilePath());
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101128", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void ManageOrder()
	{
		IniConfigSource iniConfigSource = new IniConfigSource();
		try
		{
			IConfig config = iniConfigSource.AddConfig("General");
			config.Set("UsePitchForWeapons", 1);
			config.Set("CompleteSensorFailureReport", 0);
			config.Set("CustomFolder_GIS", "");
			config.Set("CustomFolder_DB", "");
			config.Set("CustomFolder_WW", "");
			IConfig config2 = iniConfigSource.AddConfig("Lua");
			config2.Set("EnableSocket", 0);
			config2.Set("SocketPort", 7777);
			config2.Set("AllowIO", 0);
			iniConfigSource.Save(smethod_0());
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 102134523456661184325762356", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void RevertOrder()
	{
		IniConfigSource iniConfigSource = new IniConfigSource();
		try
		{
			IConfig config = iniConfigSource.AddConfig("General");
			config.Set("UseV1SaveFormat", 0);
			config.Set("UIGridLines", 0);
			iniConfigSource.Save(GetBetaConfigFilePath());
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 102134523456632452312312412345", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void SaveSettings(Dictionary<string, Tuple<int, int, int, int>> dictionary_0, List<string> list_0)
	{
		if (string.IsNullOrEmpty(DefaultDB_Hash))
		{
			return;
		}
		IniConfigSource iniConfigSource = new IniConfigSource();
		try
		{
			IConfig config = iniConfigSource.AddConfig("General");
			if (!string.IsNullOrEmpty(DefaultDB_Hash))
			{
				config.Set("DefaultDB", DefaultDB_Hash);
			}
			config = iniConfigSource.AddConfig("Game Preferences");
			config.Set("UseAutosave", DefaultGamePreferences.UseAutosave.ToString());
			config.Set("RunCoreMultithreaded", DefaultGamePreferences.RunCoreMultithreaded.ToString());
			config.Set("ShowDiagnostics", DefaultGamePreferences.ShowDiagnostics.ToString());
			config.Set("MessageLogInWindow", DefaultGamePreferences.MessageLogInWindow.ToString());
			config.Set("GameSounds", DefaultGamePreferences.GameSounds.ToString());
			config.Set("SFXVolume", DefaultGamePreferences.Int32_0.ToString());
			config.Set("GameMusic", DefaultGamePreferences.GameMusic.ToString());
			config.Set("MusicVolume", DefaultGamePreferences.MusicVolume.ToString());
			config.Set("ShowAltitudeInFeet", DefaultGamePreferences.ShowAltitudeInFeet.ToString());
			config.Set("ShowUSUnitsInEditCargo", DefaultGamePreferences.ShowUSUnitsForEditCargo.ToString());
			config.Set("GroundUnitsSpeedUnit", ((byte)DefaultGamePreferences.GroundUnitsSpeedUnit).ToString());
			config.Set("GeoCoordinateType", ((byte)DefaultGamePreferences.GeoCoordinateType).ToString());
			config.Set("ZoomOnCursor", DefaultGamePreferences.ZoomOnCursor.ToString());
			config.Set("SonobuoyVisibility", ((int)DefaultGamePreferences.SonobuoyVisibility).ToString());
			config.Set("RefPointVisibility", ((int)DefaultGamePreferences.RefPointVisibility).ToString());
			config.Set("MapSymbolsSet", ((byte)DefaultGamePreferences.MapSymbolsSet).ToString());
			config.Set("MapCursorBox", ((int)DefaultGamePreferences.MapCursorBox).ToString());
			config.Set("OnlyShowAvailableLoadouts", DefaultGamePreferences.OnlyShowAvailableLoadouts.ToString());
			config.Set("ShowAU_Behaviour_Bark", ((byte)DefaultGamePreferences.ShowAU_Behaviour_Bark).ToString());
			config.Set("ShowGhostedGroupMembers", ((byte)DefaultGamePreferences.ShowGhostedGroupMembers).ToString());
			config.Set("NavigationMaxDistanceNMSetting", DefaultGamePreferences.NavigationMaxDistanceNMSetting.ToString());
			config.Set("RMB_MoveOrder_Sensivity", DefaultGamePreferences.RMB_MoveOrder_Enabled.ToString());
			config.Set("NavigationThresholdDistanceDegSetting", DefaultGamePreferences.NavigationThresholdDistanceDegSetting.ToString());
			config.Set("ShowPlottedPaths", ((byte)DefaultGamePreferences.ShowPlottedPaths).ToString());
			config.Set("ShowFlightPlans_Airborne", ((byte)DefaultGamePreferences.ShowFlightPlans_Airborne).ToString());
			config.Set("ShowFlightPlans_Planned", ((byte)DefaultGamePreferences.ShowFlightPlans_Planned).ToString());
			config.Set("ShowMissionArea", ((byte)DefaultGamePreferences.ShowMissionArea).ToString());
			config.Set("UnitStatusImage", DefaultGamePreferences.UnitStatusImage.ToString());
			config.Set("SalvoTimeout", DefaultGamePreferences.SalvoTimeout.ToString());
			config.Set("ShowAutomaticFireInfo", DefaultGamePreferences.ShowAutomaticFireInfo.ToString());
			config.Set("DrawOutlines", DefaultGamePreferences.PlacenameVisibility.ToString());
			config.Set("MessageLogCanvas", DefaultGamePreferences.MessageLogCanvas.ToString());
			config.Set("AllowPowerPlanSwitch", DefaultGamePreferences.AllowPowerPlanSwitch.ToString());
			config.Set("StartFullScreen", DefaultGamePreferences.StartFullScreen.ToString());
			if (!string.IsNullOrEmpty(DefaultGamePreferences.TacviewExePath))
			{
				config.Set("TacviewExePath", DefaultGamePreferences.TacviewExePath);
			}
			config.Set("ShowGameSpeedButton", DefaultGamePreferences.ShowGameSpeedButton.ToString());
			config.Set("LogDebugInfoToFile", DefaultGamePreferences.LogDebugInfoToFile.ToString());
			config.Set("UseAutosave", DefaultGamePreferences.UseAutosave.ToString());
			config.Set("ColorDataBlocks", DefaultGamePreferences.ColorDataBlocks.ToString());
			config.Set("DedupAlliedMessages", GameGeneral.DedupAlliedMessages.ToString());
			config.Set("UsePersonalMapProfile", DefaultGamePreferences.UsePersonalMapProfile.ToString());
			config.Set("PersonalMapProfile", Crypto.VerifyImporter(DefaultGamePreferences.PersonalMapProfile.ToXML(), "HermanDingleberry"));
			config.Set("RecentlyOpened", string.Join("|", list_0));
			config.Set("PauseOnDBView", ((int)DefaultGamePreferences.PauseOnDBView).ToString());
			config.Set("PauseOnAirDockOps", ((int)DefaultGamePreferences.PauseOnAirDockOps).ToString());
			config.Set("AllowInGameDownloads", DefaultGamePreferences.AllowInGameDownloads.ToString());
			config.Set("SlugTrailTimeFrequency", ((int)DefaultGamePreferences.SlugTrailTimeFrequency).ToString());
			config.Set("SlugTrail_Friendly", DefaultGamePreferences.SlugTrail_Friendly.ToString());
			config.Set("SlugTrail_Hostile", DefaultGamePreferences.SlugTrail_Hostile.ToString());
			config.Set("SlugTrail_Neutral", DefaultGamePreferences.SlugTrail_Neutral.ToString());
			config.Set("SlugTrail_OwnAndAllied", DefaultGamePreferences.SlugTrail_OwnAndAllied.ToString());
			config.Set("SlugTrail_Use", DefaultGamePreferences.SlugTrail_Use.ToString());
			config.Set("SlugTrail_Unfriendly", DefaultGamePreferences.SlugTrail_Unfriendly.ToString());
			config.Set("SlugTrail_UnKnown", DefaultGamePreferences.SlugTrail_UnKnown.ToString());
			config.Set("SlugTrail_LifeTime", DefaultGamePreferences.SlugTrail_LifeTime.ToString());
			config.Set("GroundUnitZoom", DefaultGamePreferences.GroundUnitZoom.ToString());
			config.Set("DiamondZoom", DefaultGamePreferences.DiamondZoom.ToString());
			config.Set("FlowerZoom", DefaultGamePreferences.FlowerZoom.ToString());
			config.Set("RectangleZoom", DefaultGamePreferences.RectangleZoom.ToString());
			config = iniConfigSource.AddConfig("MessageLog Preferences");
			foreach (LoggedMessage.MessageType key in DefaultGamePreferences.MessageLogSettings.Keys)
			{
				config.Set(key.ToString(), Conversions.ToString(-(DefaultGamePreferences.MessageLogSettings[key].ShowOnMessageLog ? 1 : 0)) + "|" + Conversions.ToString(-(DefaultGamePreferences.MessageLogSettings[key].PopUp ? 1 : 0)) + "|" + Conversions.ToString(-(DefaultGamePreferences.MessageLogSettings[key].ShowBaloon ? 1 : 0)) + "|" + Conversions.ToString(-(DefaultGamePreferences.MessageLogSettings[key].bool_0 ? 1 : 0)));
			}
			try
			{
				config = iniConfigSource.AddConfig("Secondary Window Settings");
				foreach (KeyValuePair<string, Tuple<int, int, int, int>> item in dictionary_0)
				{
					config.Set(item.Key, Conversions.ToString(item.Value.Item1) + "|" + Conversions.ToString(item.Value.Item2) + "|" + Conversions.ToString(item.Value.Item3) + "|" + Conversions.ToString(item.Value.Item4));
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101160", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			iniConfigSource.Save(GetCommandConfigFilePath());
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 101129", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static string GetExternalURL(string string_0, string string_1)
	{
		try
		{
			return new IniConfigSource(GetExternalUrlsConfigFilePath()).Configs[string_0].Get(string_1);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200500", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public static string[] GetRemoteImageServers()
	{
		try
		{
			return new IniConfigSource(GetExternalUrlsConfigFilePath()).Configs["RemoteImages"].GetValues();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 2032459872349067834596348957", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}
}
