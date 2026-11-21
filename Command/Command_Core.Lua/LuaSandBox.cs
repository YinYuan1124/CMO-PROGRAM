using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using Command_Core.SmartAssembly.Attributes;
using DarkUI.Collections;
using KeraLua;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;
using NLua.Event;
using NLua.Exceptions;

namespace Command_Core.Lua;

[DoNotObfuscateType]
public sealed class LuaSandBox
{
	public delegate void LuaPrintEventHandler(object obj);

	public delegate void actionUIwindowEventHandler(string window, bool mode);

	private bool initalLoad;

	[AccessedThroughProperty("LuaMethods")]
	[CompilerGenerated]
	private static ObservableList<string> LuaMethods_value;

	[CompilerGenerated]
	private actionUIwindowEventHandler actionUIwindowEventHandler_0;

	private NLua.Lua lua;

	private StringBuilder SecurityString;

	private StringBuilder AliasString;

	private Scenario ScenarioContext;

	public object UnitX;

	public ActiveUnit UnitY;

	public Contact UnitC;

	public List<Sensor> SensorsThatMadeDetection;

	public SimEvent EventX;

	public LuaEnuNames enumTable;

	public static bool _lua_event;

	public static bool _lua_console;

	public string currentFunction;

	public int currentLine;

	public string lastError;

	public bool RunInteractive;

	public CMANO luaDynamicFunctions;

	private static LuaSandBox _LuaSandbox;

	private object object_0;

	public object ScriptLockObj;

	public static ObservableList<string> LuaMethods
	{
		[CompilerGenerated]
		get
		{
			return LuaMethods_value;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LuaMethods_value = value;
		}
	}

	public event LuaPrintEventHandler LuaPrint;

	public event actionUIwindowEventHandler actionUIwindow
	{
		[CompilerGenerated]
		add
		{
			actionUIwindowEventHandler actionUIwindowEventHandler = actionUIwindowEventHandler_0;
			actionUIwindowEventHandler actionUIwindowEventHandler2;
			do
			{
				actionUIwindowEventHandler2 = actionUIwindowEventHandler;
				actionUIwindowEventHandler value2 = (actionUIwindowEventHandler)Delegate.Combine(actionUIwindowEventHandler2, value);
				actionUIwindowEventHandler = Interlocked.CompareExchange(ref actionUIwindowEventHandler_0, value2, actionUIwindowEventHandler2);
			}
			while ((object)actionUIwindowEventHandler != actionUIwindowEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			actionUIwindowEventHandler actionUIwindowEventHandler = actionUIwindowEventHandler_0;
			actionUIwindowEventHandler actionUIwindowEventHandler2;
			do
			{
				actionUIwindowEventHandler2 = actionUIwindowEventHandler;
				actionUIwindowEventHandler value2 = (actionUIwindowEventHandler)Delegate.Remove(actionUIwindowEventHandler2, value);
				actionUIwindowEventHandler = Interlocked.CompareExchange(ref actionUIwindowEventHandler_0, value2, actionUIwindowEventHandler2);
			}
			while ((object)actionUIwindowEventHandler != actionUIwindowEventHandler2);
		}
	}

	static LuaSandBox()
	{
		LuaMethods = new ObservableList<string>();
		_lua_event = false;
		_lua_console = true;
	}

	public static LuaSandBox Singleton()
	{
		return _LuaSandbox;
	}

	public LuaTable CreateTable()
	{
		object obj = object_0;
		ObjectFlowControl.CheckForSyncLockOnValueType(obj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(obj, ref lockTaken);
			return (LuaTable)lua.DoString("return {}").First();
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj);
			}
		}
	}

	public int SB_Getinfo(string string_0, ref LuaDebug luaDebug_0)
	{
		luaDebug_0 = default(LuaDebug);
		return 0;
	}

	public NLua.Lua SB_Lua()
	{
		return lua;
	}

	public LuaSandBox()
	{
		initalLoad = true;
		SecurityString = new StringBuilder();
		AliasString = new StringBuilder();
		UnitX = null;
		UnitY = null;
		UnitC = null;
		SensorsThatMadeDetection = null;
		EventX = null;
		enumTable = null;
		currentFunction = "";
		currentLine = 0;
		lastError = "";
		luaDynamicFunctions = null;
		object_0 = RuntimeHelpers.GetObjectValue(new object());
		ScriptLockObj = RuntimeHelpers.GetObjectValue(new object());
		InitializeStats();
	}

	public void InitializeStats()
	{
		try
		{
			_LuaSandbox = this;
			lua = new NLua.Lua();
			lua.State.Encoding = Encoding.UTF8;
			lua.LoadCLRPackage();
			LuaPrint += HandleLuaPrint;
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

	public void RefreshStats(Scenario scenario_0)
	{
		ScriptLockObj = RuntimeHelpers.GetObjectValue(new object());
		ScenarioContext = scenario_0;
		luaDynamicFunctions = new CMANO(ScenarioContext);
		AliasString.Clear();
		SecurityString.Clear();
		SecurityString.Append("dofile=nil").Append("\r\n");
		if (!GameGeneral.PE_Lua_AllowIO)
		{
			SecurityString.Append("io=nil").Append("\r\n");
		}
		if (!GameGeneral.PE_Lua_AllowCLRPackage)
		{
			SecurityString.Append("rawget=nil").Append("\r\n");
		}
		SecurityString.Append("load=nil\r\nloadfile=nil\r\nloadstring=nil\r\nrawequal=nil\r\nrawset=nil\r\nmodule=nil\r\nrequire=nil\r\npackage.loaded=nil\r\npackage.loaders=nil\r\npackage.loadlib=nil\r\npackage.path=nil\r\npackage.cpath=nil\r\npackage.preload=nil\r\npackage.seeall=nil\r\nstring.dump=nil\r\nos.execute=nil\r\nos.exit=nil\r\nos.getenv=nil\r\nos.remove=nil\r\nos.rename=nil\r\nos.tmpname=nil\r\nnewproxy=nil\r\n");
		if (initalLoad)
		{
			initalLoad = false;
			SecurityString.Append("os.default_date = os.date;\r\n");
			SecurityString.Append("local function date_override(format, x)\r\n");
			SecurityString.Append("  local now = os.time()\r\n");
			SecurityString.Append("  if format == nil or format == '' then\r\n");
			SecurityString.Append("    format = '!%a %b %d %X %Y UTC';\r\n");
			SecurityString.Append("  elseif string.sub(format,1,1) ~= '!' then\r\n");
			SecurityString.Append("      format = '!' .. format;\r\n");
			SecurityString.Append("  end\r\n");
			SecurityString.Append("  if x ~= nil then\r\n");
			SecurityString.Append("    return os.default_date(format,math.tointeger(x));\r\n");
			SecurityString.Append("  else\r\n");
			SecurityString.Append("    return os.default_date(format,math.tointeger(now));\r\n");
			SecurityString.Append("  end\r\n");
			SecurityString.Append("end\r\n");
			SecurityString.Append("os.date = date_override;\r\n");
			SecurityString.Append("math.default_random = math.random;\r\n");
			SecurityString.Append("local function random_override(m,n)\r\n");
			SecurityString.Append(" if m == nil and n == nil then\r\n");
			SecurityString.Append("    return math.default_random();\r\n");
			SecurityString.Append(" elseif n == nil then\r\n");
			SecurityString.Append("    return math.default_random(math.floor(m));\r\n");
			SecurityString.Append(" else \r\n");
			SecurityString.Append("    return math.default_random(math.floor(m), math.floor(n));\r\n");
			SecurityString.Append(" end\r\n");
			SecurityString.Append("end;\r\n");
			SecurityString.Append("math.random = random_override;\r\n");
			MethodInfo method = GetType().GetMethod("LUA_Echo");
			lua.RegisterFunction("Echo", this, method);
			LuaMethods_value.Clear();
			RegisterFunction("UI_SelectUnitsPrompt_FromSides", GetType().GetMethod("LUA_UI_SelectUnitsPrompt_FromSides"));
			LuaMethods_value.Add("UI_SelectUnitsPrompt_FromSides(result,Sides ,MultipleSelect)");
			RegisterFunction("UI_SelectUnitsPrompt_OwnSide", GetType().GetMethod("LUA_UI_SelectUnitsPrompt_OwnSide"));
			LuaMethods_value.Add("UI_SelectUnitsPrompt_OwnSide(result, MultipleSelect)");
			RegisterFunction("UI_CallAdvancedDialog", GetType().GetMethod("LUA_UI_CallAdvancedDialog"));
			LuaMethods_value.Add("UI_CallAdvancedDialog(Title, Description, Interactions)");
			RegisterFunction("UI_CallAdvancedHTMLDialog", GetType().GetMethod("LUA_UI_CallAdvancedHTMLDialog"));
			LuaMethods_value.Add("UI_CallAdvancedHTMLDialog(Title, Description, Interactions)");
			RegisterFunction("GetScenarioTitle", GetType().GetMethod("LUA_GetScenarioTitle"));
			LuaMethods_value.Add("GetScenarioTitle()");
			RegisterFunction("GetBuildNumber", GetType().GetMethod("LUA_GetBuildNumber"));
			LuaMethods_value.Add("GetBuildNumber()");
			RegisterFunction("VP_SetTimeCompression", GetType().GetMethod("LUA_VP_SetTimeCompression"));
			LuaMethods_value.Add("VP_SetTimeCompression(value)");
			RegisterFunction("VP_GetSides", GetType().GetMethod("LUA_VP_GetSides"));
			LuaMethods_value.Add("VP_GetSides()");
			RegisterFunction("VP_GetSide", GetType().GetMethod("LUA_VP_GetSide"));
			LuaMethods_value.Add("VP_GetSide(table)");
			RegisterFunction("VP_GetUnit", GetType().GetMethod("LUA_VP_GetUnit"));
			LuaMethods_value.Add("VP_GetUnit(table)");
			RegisterFunction("VP_GetContact", GetType().GetMethod("LUA_VP_GetContact"));
			LuaMethods_value.Add("VP_GetContact(table)");
			RegisterFunction("VP_ExportUnits", GetType().GetMethod("LUA_VP_ExportUnits"));
			RegisterFunction("ScenEdit_AddAircraft", GetType().GetMethod("LUA_ScenEdit_AddAircraft"));
			RegisterFunction("ScenEdit_AddShip", GetType().GetMethod("LUA_ScenEdit_AddShip"));
			RegisterFunction("ScenEdit_AddSubmarine", GetType().GetMethod("LUA_ScenEdit_AddSubmarine"));
			RegisterFunction("ScenEdit_AddFacility", GetType().GetMethod("LUA_ScenEdit_AddFacility"));
			RegisterFunction("ScenEdit_AssignUnitToMission", GetType().GetMethod("LUA_ScenEdit_AssignUnitToMission"));
			LuaMethods_value.Add("ScenEdit_AssignUnitToMission('AUNameOrID', 'MissionNameOrID',[asEscort])");
			RegisterFunction("ScenEdit_SetWeather", GetType().GetMethod("LUA_ScenEdit_SetWeather"));
			LuaMethods_value.Add("ScenEdit_SetWeather(AvgTemp, RainfallRate, FractionUnderRain, SeaState)");
			RegisterFunction("ScenEdit_GetWeather", GetType().GetMethod("LUA_ScenEdit_GetWeather"));
			LuaMethods_value.Add("ScenEdit_GetWeather()");
			RegisterFunction("ScenEdit_TransformZone", GetType().GetMethod("LUA_ScenEdit_TransformZone"));
			LuaMethods_value.Add("ScenEdit_TransformZone(SideNameOrID As String, ZoneNameOrID As String, TargetType As String)");
			RegisterFunction("ScenEdit_SetSidePosture", GetType().GetMethod("LUA_ScenEdit_SetSidePosture"));
			LuaMethods_value.Add("ScenEdit_SetSidePosture('SideANameOrID', 'SideBNameOrID', 'PostureCode')");
			RegisterFunction("ScenEdit_GetSidePosture", GetType().GetMethod("LUA_ScenEdit_GetSidePosture"));
			LuaMethods_value.Add("ScenEdit_GetSidePosture('SideANameOrID', 'SideBNameOrID')");
			RegisterFunction("ScenEdit_GetSideIsHuman", GetType().GetMethod("LUA_ScenEdit_GetSideIsHuman"));
			LuaMethods_value.Add("ScenEdit_GetSideIsHuman('SideANameOrID')");
			RegisterFunction("ScenEdit_GetScenHasStarted", GetType().GetMethod("LUA_ScenEdit_GetScenHasStarted"));
			LuaMethods_value.Add("ScenEdit_GetScenHasStarted()");
			RegisterFunction("ScenEdit_SetEMCON", GetType().GetMethod("LUA_ScenEdit_SetEMCON"));
			LuaMethods_value.Add("ScenEdit_SetEMCON('EMCONSubjectType', 'EMCONSubjectNameOrID', 'EMCONSettings')");
			RegisterFunction("ScenEdit_MsgBox", GetType().GetMethod("LUA_ScenEdit_MsgBox"));
			LuaMethods_value.Add("ScenEdit_MsgBox('str', style)");
			RegisterFunction("ScenEdit_RunScript", GetType().GetMethod("LUA_ScenEdit_RunScript"));
			LuaMethods_value.Add("ScenEdit_RunScript('str', [useCustomPath: false/true])");
			RegisterFunction("ScenEdit_AddUnit", GetType().GetMethod("LUA_ScenEdit_AddUnit"));
			LuaMethods_value.Add("ScenEdit_AddUnit(table)");
			RegisterFunction("ScenEdit_UpdateUnit", GetType().GetMethod("LUA_ScenEdit_UpdateUnit"));
			LuaMethods_value.Add("ScenEdit_UpdateUnit(table)");
			RegisterFunction("ScenEdit_SetUnit", GetType().GetMethod("LUA_ScenEdit_SetUnit"));
			LuaMethods_value.Add("ScenEdit_SetUnit(table)");
			RegisterFunction("ScenEdit_GetUnit", GetType().GetMethod("LUA_ScenEdit_GetUnit"));
			LuaMethods_value.Add("ScenEdit_GetUnit(table)");
			RegisterFunction("ScenEdit_SetKeyValue", GetType().GetMethod("LUA_ScenEdit_SetKeyValue"));
			LuaMethods_value.Add("ScenEdit_SetKeyValue('key', 'value' [, false/true])");
			RegisterFunction("ScenEdit_GetKeyValue", GetType().GetMethod("LUA_ScenEdit_GetKeyValue"));
			LuaMethods_value.Add("ScenEdit_GetKeyValue('key' [,false/true])");
			RegisterFunction("ScenEdit_ClearKeyValue", GetType().GetMethod("LUA_ScenEdit_ClearKeyValue"));
			LuaMethods_value.Add("ScenEdit_ClearKeyValue('key' [,false/true])");
			RegisterFunction("ScenEdit_GetKeyStore", GetType().GetMethod("LUA_ScenEdit_GetKeyStore"));
			LuaMethods_value.Add("ScenEdit_GetKeyStore( [,false/true])");
			RegisterFunction("ScenEdit_DeleteUnit", GetType().GetMethod("LUA_ScenEdit_DeleteUnit"));
			LuaMethods_value.Add("ScenEdit_DeleteUnit(table[, false/true])");
			RegisterFunction("ScenEdit_KillUnit", GetType().GetMethod("LUA_ScenEdit_KillUnit"));
			LuaMethods_value.Add("ScenEdit_KillUnit(table)");
			RegisterFunction("ScenEdit_SetSpecialAction", GetType().GetMethod("LUA_ScenEdit_SetSpecialAction"));
			LuaMethods_value.Add("ScenEdit_SetSpecialAction(table)");
			RegisterFunction("ScenEdit_AddSpecialAction", GetType().GetMethod("LUA_ScenEdit_AddSpecialAction"));
			LuaMethods_value.Add("ScenEdit_AddSpecialAction(table)");
			RegisterFunction("ScenEdit_SetUnitSide", GetType().GetMethod("LUA_ScenEdit_SetUnitSide"));
			LuaMethods_value.Add("ScenEdit_SetUnitSide(table)");
			RegisterFunction("ScenEdit_SetTime", GetType().GetMethod("LUA_ScenEdit_SetTime"));
			LuaMethods_value.Add("ScenEdit_SetTime(table)");
			RegisterFunction("ScenEdit_SetStartTime", GetType().GetMethod("LUA_ScenEdit_SetStartTime"));
			LuaMethods_value.Add("ScenEdit_SetStartTime(table)");
			RegisterFunction("ScenEdit_AddReferencePoint", GetType().GetMethod("LUA_ScenEdit_AddReferencePoint"));
			LuaMethods_value.Add("ScenEdit_AddReferencePoint(table)");
			RegisterFunction("ScenEdit_AddExplosion", GetType().GetMethod("LUA_ScenEdit_AddExplosion"));
			LuaMethods_value.Add("ScenEdit_AddExplosion(table)");
			RegisterFunction("ScenEdit_SetLoadoutAvailable", GetType().GetMethod("LUA_ScenEdit_SetLoadoutAvailable"));
			LuaMethods_value.Add("ScenEdit_SetLoadoutAvailable(table)");
			RegisterFunction("ScenEdit_SetReferencePoint", GetType().GetMethod("LUA_ScenEdit_SetReferencePoint"));
			LuaMethods_value.Add("ScenEdit_SetReferencePoint(table)");
			RegisterFunction("ScenEdit_GetReferencePoint", GetType().GetMethod("LUA_ScenEdit_GetReferencePoint"));
			LuaMethods_value.Add("ScenEdit_GetReferencePoint(table)");
			RegisterFunction("ScenEdit_GetReferencePoints", GetType().GetMethod("LUA_ScenEdit_GetReferencePoints"));
			LuaMethods_value.Add("ScenEdit_GetReferencePoints(table)");
			RegisterFunction("ScenEdit_DeleteReferencePoint", GetType().GetMethod("LUA_ScenEdit_DeleteReferencePoint"));
			LuaMethods_value.Add("ScenEdit_DeleteReferencePoint(table)");
			RegisterFunction("print", GetType().GetMethod("LUA_ScenEdit_Print"));
			LuaMethods_value.Add("print(obj)");
			RegisterFunction("print_escaped", GetType().GetMethod("LUA_ScenEdit_PrintEscaped"));
			LuaMethods_value.Add("print_escaped(obj)");
			RegisterFunction("ScenEdit_SetDoctrine", GetType().GetMethod("LUA_ScenEdit_SetDoctrine"));
			LuaMethods_value.Add("ScenEdit_SetDoctrine(table,doctrine)");
			RegisterFunction("ScenEdit_SetDoctrineWRA", GetType().GetMethod("LUA_ScenEdit_SetDoctrineWRA"));
			LuaMethods_value.Add("ScenEdit_SetDoctrineWRA(table)");
			RegisterFunction("ScenEdit_GetDoctrine", GetType().GetMethod("LUA_ScenEdit_GetDoctrine"));
			LuaMethods_value.Add("ScenEdit_GetDoctrine(table)");
			RegisterFunction("ScenEdit_GetDoctrineWRA", GetType().GetMethod("LUA_ScenEdit_GetDoctrineWRA"));
			LuaMethods_value.Add("ScenEdit_GetDoctrineWRA(table)");
			RegisterFunction("ScenEdit_HostUnitToParent", GetType().GetMethod("LUA_ScenEdit_HostUnitToParent"));
			LuaMethods_value.Add("ScenEdit_HostUnitToParent(table)");
			RegisterFunction("ScenEdit_CurrentTime", GetType().GetMethod("LUA_ScenEdit_CurrentTime"));
			LuaMethods_value.Add("ScenEdit_CurrentTime()");
			RegisterFunction("EpochToUTC_Date", GetType().GetMethod("LUA_EpochToUTC_Date"));
			LuaMethods_value.Add("EpochToUTC_Date()");
			RegisterFunction("EpochToUTC_Time", GetType().GetMethod("LUA_EpochToUTC_Time"));
			LuaMethods_value.Add("EpochToUTC_Time()");
			RegisterFunction("ScenEdit_CurrentLocalTime", GetType().GetMethod("LUA_ScenEdit_CurrentLocalTime"));
			LuaMethods_value.Add("ScenEdit_CurrentLocalTime()");
			RegisterFunction("Exporter_SetSetting", GetType().GetMethod("LUA_Exporter_SetSetting"));
			LuaMethods_value.Add("Exporter_SetSetting(Category As String, Setting As String, Value As String)");
			RegisterFunction("ScenEdit_UnitX", GetType().GetMethod("LUA_ScenEdit_UnitX"));
			LuaMethods_value.Add("ScenEdit_UnitX()");
			RunScript("UnitX = ScenEdit_UnitX", bool_0: false, "Initializing");
			RegisterFunction("ScenEdit_UnitY", GetType().GetMethod("LUA_ScenEdit_UnitY"));
			LuaMethods_value.Add("ScenEdit_UnitY()");
			RunScript("UnitY = ScenEdit_UnitY", bool_0: false, "Initializing");
			RegisterFunction("ScenEdit_UnitC", GetType().GetMethod("LUA_ScenEdit_UnitC"));
			LuaMethods_value.Add("ScenEdit_UnitC()");
			RunScript("UnitC = ScenEdit_UnitC", bool_0: false, "Initializing");
			RegisterFunction("ScenEdit_UseAttachment", GetType().GetMethod("LUA_ScenEdit_UseAttachment"));
			LuaMethods_value.Add("ScenEdit_UseAttachment('AttachmentNameOrID')");
			RegisterFunction("ScenEdit_UseAttachmentOnSide", GetType().GetMethod("LUA_ScenEdit_UseAttachmentOnSide"));
			LuaMethods_value.Add("ScenEdit_UseAttachmentOnSide('AttachmentNameOrID', 'SideNameOrID')");
			RegisterFunction("ScenEdit_GetScore", GetType().GetMethod("LUA_ScenEdit_GetScore"));
			LuaMethods_value.Add("ScenEdit_GetScore('SideNameOrID')");
			RegisterFunction("ScenEdit_SetLoadout", GetType().GetMethod("LUA_ScenEdit_SetLoadout"));
			LuaMethods_value.Add("ScenEdit_SetLoadout(table)");
			RegisterFunction("ScenEdit_SetScore", GetType().GetMethod("LUA_ScenEdit_SetScore"));
			LuaMethods_value.Add("ScenEdit_SetScore('SideNameOrID',Score,'ReasonForChange')");
			RegisterFunction("ScenEdit_SpecialMessage", GetType().GetMethod("LUA_ScenEdit_SpecialMessage"));
			LuaMethods_value.Add("ScenEdit_SpecialMessage('SideNameOrID','Text' [,{lat=,lon=}, forceMapRecenter])");
			RegisterFunction("ScenEdit_PlayerSide", GetType().GetMethod("LUA_ScenEdit_PlayerSide"));
			LuaMethods_value.Add("ScenEdit_PlayerSide()");
			RegisterFunction("ScenEdit_EndScenario", GetType().GetMethod("LUA_ScenEdit_EndScenario"));
			LuaMethods_value.Add("ScenEdit_EndScenario()");
			RegisterFunction("ScenEdit_ImportInst", GetType().GetMethod("LUA_ScenEdit_ImportInst"));
			LuaMethods_value.Add("ScenEdit_ImportInst('SideNameOrID', 'InstFile')");
			RegisterFunction("ScenEdit_ExportInst", GetType().GetMethod("LUA_ScenEdit_ExportInst"));
			LuaMethods_value.Add("ScenEdit_ExportInst('SideNameOrID', 'units', 'fileData')");
			RegisterFunction("ScenEdit_AddWeaponToUnitMagazine", GetType().GetMethod("LUA_ScenEdit_AddWeaponToUnitMagazine"));
			LuaMethods_value.Add("ScenEdit_AddWeaponToUnitMagazine(table)");
			RegisterFunction("ScenEdit_AddReloadsToUnit", GetType().GetMethod("LUA_ScenEdit_AddReloadsToUnit"));
			LuaMethods_value.Add("ScenEdit_AddReloadsToUnit(table)");
			RegisterFunction("ScenEdit_GetSideOptions", GetType().GetMethod("LUA_ScenEdit_GetSideOptions"));
			LuaMethods_value.Add("ScenEdit_GetSideOptions(table)");
			RegisterFunction("ScenEdit_SetSideOptions", GetType().GetMethod("LUA_ScenEdit_SetSideOptions"));
			LuaMethods_value.Add("ScenEdit_SetSideOptions(table)");
			RegisterFunction("ScenEdit_SetUnitDamage", GetType().GetMethod("LUA_ScenEdit_SetUnitDamage"));
			LuaMethods_value.Add("ScenEdit_SetUnitDamage(table)");
			RegisterFunction("ScenEdit_GetMissions", GetType().GetMethod("LUA_ScenEdit_GetMissions"));
			LuaMethods_value.Add("ScenEdit_GetMissions('SideNameOrID')");
			RegisterFunction("ScenEdit_GetMission", GetType().GetMethod("LUA_ScenEdit_GetMission"));
			LuaMethods_value.Add("ScenEdit_GetMission('SideNameOrID', 'MissionNameOrID')");
			RegisterFunction("ScenEdit_SetMission", GetType().GetMethod("LUA_ScenEdit_SetMission"));
			LuaMethods_value.Add("ScenEdit_SetMission('SideNameOrID', 'MissionNameOrID',table)");
			RegisterFunction("ScenEdit_AddMission", GetType().GetMethod("LUA_ScenEdit_AddMission"));
			LuaMethods_value.Add("ScenEdit_AddMission('SideNameOrID', 'MissionNameOrID', 'MissionType', table)");
			RegisterFunction("ScenEdit_DeleteMission", GetType().GetMethod("LUA_ScenEdit_DeleteMission"));
			LuaMethods_value.Add("ScenEdit_DeleteMission('SideNameOrID', 'MissionNameOrID')");
			RegisterFunction("ScenEdit_ImportMission", GetType().GetMethod("LUA_ScenEdit_ImportMission"));
			LuaMethods_value.Add("ScenEdit_ImportMission('SideNameOrID', 'MissionNameOrID')");
			RegisterFunction("ScenEdit_ExportMission", GetType().GetMethod("LUA_ScenEdit_ExportMission"));
			LuaMethods_value.Add("ScenEdit_ExportMission('SideNameOrID', 'MissionNameOrID')");
			RegisterFunction("ScenEdit_AssignUnitAsTarget", GetType().GetMethod("LUA_ScenEdit_AssignUnitAsTarget"));
			LuaMethods_value.Add("ScenEdit_AssignUnitAsTarget('AUNameOrID', 'MissionNameOrID')");
			RegisterFunction("ScenEdit_RemoveUnitAsTarget", GetType().GetMethod("LUA_ScenEdit_RemoveUnitAsTarget"));
			LuaMethods_value.Add("ScenEdit_RemoveUnitAsTarget('AUNameOrID', 'MissionNameOrID')");
			RegisterFunction("ScenEdit_RefuelUnit", GetType().GetMethod("LUA_ScenEdit_RefuelUnit"));
			LuaMethods_value.Add("ScenEdit_RefuelUnit(table)");
			RegisterFunction("ScenEdit_ExecuteEventAction", GetType().GetMethod("LUA_ScenEdit_ExecuteEventAction"));
			LuaMethods_value.Add("ScenEdit_ExecuteEventAction('EventNameOrId')");
			RegisterFunction("ScenEdit_SetEvent", GetType().GetMethod("LUA_ScenEdit_SetEvent"));
			LuaMethods_value.Add("ScenEdit_SetEvent('EventNameOrId', table)");
			RegisterFunction("ScenEdit_SetTrigger", GetType().GetMethod("LUA_ScenEdit_SetTrigger"));
			LuaMethods_value.Add("ScenEdit_SetTrigger( table)");
			RegisterFunction("ScenEdit_SetCondition", GetType().GetMethod("LUA_ScenEdit_SetCondition"));
			LuaMethods_value.Add("ScenEdit_SetCondition( table)");
			RegisterFunction("ScenEdit_SetAction", GetType().GetMethod("LUA_ScenEdit_SetAction"));
			LuaMethods_value.Add("ScenEdit_SetAction( table)");
			RegisterFunction("ScenEdit_GetUnitIntermittentEmissionConfig", GetType().GetMethod("LUA_ScenEdit_GetUnitIntermittentEmissionConfig"));
			LuaMethods_value.Add("ScenEdit_GetUnitIntermittentEmissionConfig(PresetAlertID, AUNameOrID)");
			RegisterFunction("ScenEdit_SetUnitIntermittentEmissionConfig", GetType().GetMethod("LUA_ScenEdit_SetUnitIntermittentEmissionConfig"));
			LuaMethods_value.Add("ScenEdit_SetUnitIntermittentEmissionConfig(AUNameOrID, PresetAlertID, ConfigurationTable)");
			RegisterFunction("ScenEdit_DuplicateEmconConfigToUnit", GetType().GetMethod("LUA_ScenEdit_DuplicateEmconConfigToUnit"));
			LuaMethods_value.Add("ScenEdit_DuplicateEmconConfigToUnit(PresetAlertID, SourceAUNameOrID, TargetAUNameOrID)");
			RegisterFunction("ScenEdit_CreateBarkNotification_Geo_Bulk", GetType().GetMethod("LUA_ScenEdit_CreateBarkNotification_Geo_Bulk"));
			LuaMethods_value.Add("ScenEdit_CreateBarkNotification_Geo_Bulk(Longitude, Latitude, text, R, G, B [, MoveUpward, Fades, Lifetime, FontSize])");
			RegisterFunction("ScenEdit_CreateBarkNotification_Unit_Bulk", GetType().GetMethod("LUA_ScenEdit_CreateBarkNotification_Unit_Bulk"));
			LuaMethods_value.Add("ScenEdit_CreateBarkNotification_Unit_Bulk(AUNameOrID, text, R, G, B [, MoveUpward, Fades, Lifetime, FontSize])");
			RegisterFunction("ScenEdit_CreateBarkNotification_Geo", GetType().GetMethod("LUA_ScenEdit_CreateBarkNotification_Geo"));
			LuaMethods_value.Add("ScenEdit_CreateBarkNotification_Geo(Longitude, Latitude, text, R, G, B [, MoveUpward, Fades, Lifetime, FontSize])");
			RegisterFunction("ScenEdit_CreateBarkNotification_Unit", GetType().GetMethod("LUA_ScenEdit_CreateBarkNotification_Unit"));
			LuaMethods_value.Add("ScenEdit_CreateBarkNotification_Unit(AUNameOrID, text, R, G, B [, MoveUpward, Fades, Lifetime, FontSize])");
			RegisterFunction("ScenEdit_SwitchUnitIntermittentEmission", GetType().GetMethod("LUA_ScenEdit_SwitchUnitIntermittentEmission"));
			LuaMethods_value.Add("ScenEdit_SwitchUnitIntermittentEmission(AUNameOrID, PresetAlertID, Switch)");
			RegisterFunction("ScenEdit_SetSideEmconAlertness", GetType().GetMethod("LUA_ScenEdit_SetSideEmconAlertness"));
			LuaMethods_value.Add("ScenEdit_SetSideEmconAlertness(SideNameOrID, AlertID)");
			RegisterFunction("ScenEdit_ClearAllSideUnitsEmconConfigs", GetType().GetMethod("LUA_ScenEdit_ClearAllSideUnitsEmconConfigs"));
			LuaMethods_value.Add("ScenEdit_ClearAllSideUnitsEmconConfigs(SideNameOrID)");
			RegisterFunction("ScenEdit_ClearUnitEmconConfigs", GetType().GetMethod("LUA_ScenEdit_ClearUnitEmconConfigs"));
			LuaMethods_value.Add("ScenEdit_ClearUnitEmconConfigs(UnitNameorID)");
			RegisterFunction("ScenEdit_DuplicateEmconConfigToSide", GetType().GetMethod("LUA_ScenEdit_DuplicateEmconConfigToSide"));
			LuaMethods_value.Add("ScenEdit_DuplicateEmconConfigToSide(PresetAlertID, SourceAUNameOrID, TargetSideNameOrID)");
			RegisterFunction("ScenEdit_SetEventTrigger", GetType().GetMethod("LUA_ScenEdit_SetEventTrigger"));
			LuaMethods_value.Add("ScenEdit_SetEventTrigger('EventNameOrId', table)");
			RegisterFunction("ScenEdit_SetEventCondition", GetType().GetMethod("LUA_ScenEdit_SetEventCondition"));
			LuaMethods_value.Add("ScenEdit_SetEventCondition('EventNameOrId', table)");
			RegisterFunction("ScenEdit_SetEventAction", GetType().GetMethod("LUA_ScenEdit_SetEventAction"));
			LuaMethods_value.Add("ScenEdit_SetEventAction('EventNameOrId', table)");
			RegisterFunction("ScenEdit_GetEvent", GetType().GetMethod("LUA_ScenEdit_GetEvent"));
			LuaMethods_value.Add("ScenEdit_GetEvent('EventNameOrId',[level])");
			RegisterFunction("ScenEdit_GetEvents", GetType().GetMethod("LUA_ScenEdit_GetEvents"));
			LuaMethods_value.Add("ScenEdit_GetEvents(level)");
			RegisterFunction("ScenEdit_UpdateEvent", GetType().GetMethod("LUA_ScenEdit_UpdateEvent"));
			RegisterFunction("ScenEdit_GetSpecialAction", GetType().GetMethod("LUA_ScenEdit_GetSpecialAction"));
			LuaMethods_value.Add("ScenEdit_GetSpecialAction(table)");
			RegisterFunction("ScenEdit_ExecuteSpecialAction", GetType().GetMethod("LUA_ScenEdit_ExecuteSpecialAction"));
			LuaMethods_value.Add("ScenEdit_ExecuteSpecialAction('EventNameOrId')");
			RegisterFunction("ScenEdit_GetContacts", GetType().GetMethod("LUA_ScenEdit_GetContacts"));
			LuaMethods_value.Add("ScenEdit_GetContacts('SideName')");
			RegisterFunction("ScenEdit_FillMagsForLoadout", GetType().GetMethod("LUA_ScenEdit_FillMagsForLoadout"));
			LuaMethods_value.Add("ScenEdit_FillMagsForLoadout(table)");
			RegisterFunction("ScenEdit_GetContact", GetType().GetMethod("LUA_ScenEdit_GetContact"));
			LuaMethods_value.Add("ScenEdit_GetContact(table)");
			RegisterFunction("ScenEdit_AttackContact", GetType().GetMethod("LUA_ScenEdit_AttackContact"));
			LuaMethods_value.Add("ScenEdit_AttackContact('AttackerNameOrId','ContactNameOrId', table)");
			RegisterFunction("ScenEdit_InputBox", GetType().GetMethod("LUA_ScenEdit_InputBox"));
			LuaMethods_value.Add("ScenEdit_InputBox('str')");
			RegisterFunction("ScenEdit_AddSide", GetType().GetMethod("LUA_ScenEdit_AddSide"));
			LuaMethods_value.Add("ScenEdit_AddSide(table)");
			RegisterFunction("ScenEdit_RemoveSide", GetType().GetMethod("LUA_ScenEdit_RemoveSide"));
			LuaMethods_value.Add("ScenEdit_RemoveSide(table)");
			RegisterFunction("ScenEdit_AddZone", GetType().GetMethod("LUA_ScenEdit_AddZone"));
			LuaMethods_value.Add("ScenEdit_AddZone(sideName, zoneType, table)");
			RegisterFunction("ScenEdit_SetZone", GetType().GetMethod("LUA_ScenEdit_SetZone"));
			LuaMethods_value.Add("ScenEdit_SetZone(sideName, zoneType, table)");
			RegisterFunction("ScenEdit_RemoveZone", GetType().GetMethod("LUA_ScenEdit_RemoveZone"));
			LuaMethods_value.Add("ScenEdit_RemoveZone(sideName, zoneType, table)");
			RegisterFunction("ScenEdit_TransferCargo", GetType().GetMethod("LUA_ScenEdit_TransferCargo"));
			LuaMethods_value.Add("ScenEdit_TransferCargo(from, to, table)");
			RegisterFunction("ScenEdit_UnloadCargo", GetType().GetMethod("LUA_ScenEdit_UnloadCargo"));
			LuaMethods_value.Add("ScenEdit_UnloadCargo(from, [table])");
			RegisterFunction("ScenEdit_SelectedUnits", GetType().GetMethod("LUA_ScenEdit_SelectedUnits"));
			LuaMethods_value.Add("ScenEdit_SelectedUnits()");
			RegisterFunction("ScenEdit_EventX", GetType().GetMethod("LUA_ScenEdit_EventX"));
			LuaMethods_value.Add("ScenEdit_EventX()");
			RunScript("EventX = ScenEdit_EventX", bool_0: false, "Initializing");
			RegisterFunction("ScenEdit_GetFormation", GetType().GetMethod("LUA_ScenEdit_GetFormation"));
			LuaMethods_value.Add("ScenEdit_GetFormation(table)");
			RegisterFunction("ScenEdit_GetLoadout", GetType().GetMethod("LUA_ScenEdit_GetLoadout"));
			LuaMethods_value.Add("ScenEdit_GetLoadout(table)");
			RegisterFunction("ScenEdit_UpdateUnitCargo", GetType().GetMethod("LUA_ScenEdit_UpdateUnitCargo"));
			LuaMethods_value.Add("ScenEdit_UpdateUnitCargo(table)");
			RegisterFunction("ScenEdit_GetTimeOfDay", GetType().GetMethod("LUA_ScenEdit_GetTimeOfDay"));
			LuaMethods_value.Add("ScenEdit_GetTimeOfDay(table)");
			RegisterFunction("ScenEdit_QueryDB", GetType().GetMethod("LUA_ScenEdit_QueryDB"));
			LuaMethods_value.Add("ScenEdit_QueryDB(type, DBID)");
			RegisterFunction("ScenEdit_PlaySound", GetType().GetMethod("LUA_ScenEdit_PlaySound"));
			LuaMethods_value.Add("ScenEdit_PlaySound(file, delay)");
			RegisterFunction("ScenEdit_PlayVideo", GetType().GetMethod("LUA_ScenEdit_PlayVideo"));
			LuaMethods_value.Add("ScenEdit_PlayVideo(file, fullscreen, delay)");
			RegisterFunction("ScenEdit_ClearAllAircraft", GetType().GetMethod("LUA_ScenEdit_ClearAllAircraft"));
			LuaMethods_value.Add("ScenEdit_ClearAllAircraft(table)");
			RegisterFunction("ScenEdit_AddMinefield", GetType().GetMethod("LUA_ScenEdit_AddMinefield"));
			LuaMethods_value.Add("ScenEdit_AddMinefield(table)");
			RegisterFunction("ScenEdit_GetMinefield", GetType().GetMethod("LUA_ScenEdit_GetMinefield"));
			LuaMethods_value.Add("ScenEdit_GetMinefield(table)");
			RegisterFunction("ScenEdit_DeleteMinefield", GetType().GetMethod("LUA_ScenEdit_DeleteMinefield"));
			LuaMethods_value.Add("ScenEdit_DeleteMinefield(table)");
			RegisterFunction("ScenEdit_DistributeWeaponAtAirbase", GetType().GetMethod("LUA_ScenEdit_DistributeWeaponAtAirbase"));
			LuaMethods_value.Add("ScenEdit_DistributeWeaponAtAirbase(table)");
			RegisterFunction("ScenEdit_SetMine", GetType().GetMethod("LUA_ScenEdit_SetMine"));
			LuaMethods_value.Add("ScenEdit_SetMine(table)");
			RegisterFunction("ScenEdit_DeleteMine", GetType().GetMethod("LUA_ScenEdit_DeleteMine"));
			LuaMethods_value.Add("ScenEdit_DeleteMine(table)");
			RegisterFunction("ScenEdit_ClearAllMagazines", GetType().GetMethod("LUA_ScenEdit_ClearAllMagazines"));
			LuaMethods_value.Add("ScenEdit_ClearAllMagazines(table)");
			RegisterFunction("ScenEdit_AddCustomLoss", GetType().GetMethod("LUA_ScenEdit_AddCustomLoss"));
			LuaMethods_value.Add("ScenEdit_AddCustomLoss(side, table)");
			RegisterFunction("ScenEdit_ClearAllAircraft", GetType().GetMethod("LUA_ScenEdit_ClearAllAircraft"));
			LuaMethods_value.Add("ScenEdit_ClearAllAircraft(table)");
			RegisterFunction("ScenEdit_GetDateTimeTicks", GetType().GetMethod("LUA_ScenEdit_GetDateTimeTicks"));
			LuaMethods_value.Add("ScenEdit_GetDateTimeTicks()");
			RegisterFunction("World_GetElevation", GetType().GetMethod("LUA_World_GetElevation"));
			LuaMethods_value.Add("World_GetElevation(table)");
			RegisterFunction("World_GetLocation", GetType().GetMethod("LUA_World_GetLocation"));
			LuaMethods_value.Add("World_GetLocation(table)");
			RegisterFunction("World_GetCircleFromPoint", GetType().GetMethod("LUA_World_GetCircleFromPoint"));
			LuaMethods_value.Add("World_GetCircleFromPoint(table)");
			RegisterFunction("World_GetPointFromBearing", GetType().GetMethod("LUA_World_GetPointFromBearing"));
			LuaMethods_value.Add("World_GetPointFromBearing(table)");
			RegisterFunction("Tool_DumpEvents", GetType().GetMethod("Tool_DumpEvents"));
			LuaMethods_value.Add("Tool_DumpEvents()");
			RegisterFunction("Tool_EmulateNoConsole", GetType().GetMethod("Tool_EmulateNoConsole"));
			LuaMethods_value.Add("Tool_EmulateNoConsole()");
			RegisterFunction("Tool_Range", GetType().GetMethod("Tool_Range"));
			LuaMethods_value.Add("Tool_Range(from, To [, slantRange])");
			RegisterFunction("Tool_Bearing", GetType().GetMethod("Tool_Bearing"));
			LuaMethods_value.Add("Tool_Bearing(from, To)");
			RegisterFunction("Tool_UIwindow", GetType().GetMethod("Tool_UIwindow"));
			LuaMethods_value.Add("Tool_UIwindow(name [,mode])");
			RegisterFunction("Tool_LOS", GetType().GetMethod("Tool_LOS"));
			LuaMethods_value.Add("Tool_LOS(table)");
			RegisterFunction("Tool_LOS_Points", GetType().GetMethod("Tool_LOS_Points"));
			LuaMethods_value.Add("Tool_LOS_Points(table, table, HorizonType)");
			RegisterFunction("VP_GetScenario", GetType().GetMethod("LUA_VP_GetScenario"));
			LuaMethods_value.Add("VP_GetScenario()");
			RegisterFunction("Command_SaveScen", GetType().GetMethod("LUA_Command_SaveScen"));
			LuaMethods_value.Add("Command_SaveScen(FullPath)");
			RegisterFunction("ScenEdit_IsUnitInZone", GetType().GetMethod("LUA_ScenEdit_IsUnitInZone"));
			LuaMethods_value.Add("ScenEdit_IsUnitInZone(TheUnit_NameOrID, TheZone_NameOrID, Side_NameOrID, ScenarioContext)");
			RegisterFunction("ScenEdit_SplitUnit", GetType().GetMethod("LUA_ScenEdit_SplitUnit"));
			LuaMethods_value.Add("ScenEdit_SplitUnit(table)");
			RegisterFunction("ScenEdit_MergeUnits", GetType().GetMethod("LUA_ScenEdit_MergeUnits"));
			LuaMethods_value.Add("ScenEdit_MergeUnits()");
			RegisterFunction("ScenEdit_TransferMount", GetType().GetMethod("LUA_ScenEdit_TransferMount"));
			LuaMethods_value.Add("ScenEdit_TransferMount(from, to, table)");
			RegisterFunction("Tool_QueryRCS", GetType().GetMethod("LUA_Tool_QueryRCS"));
			LuaMethods_value.Add("Tool_QueryRCS(table)");
			RegisterFunction("ScenEdit_UpdateRSetting", GetType().GetMethod("LUA_ScenEdit_UpdateRSetting"));
			RegisterFunction("Tool_BuildBlankScenario", GetType().GetMethod("LUA_Tool_BuildBlankScenario"));
			LuaMethods_value.Add("Tool_BuildBlankScenario( [dbFilename])");
		}
		lua.DoString("math.randomseed( os.time() )");
		lua["_errmsg_"] = "none";
		lua["_errfnc_"] = "none";
		lua["_scriptfolder_"] = "";
		lua["_scenariofolder_"] = "";
		lua["_outputfolder_"] = "";
		SetLuaPathGlobals("");
		enumTable = new LuaEnuNames();
		lua["_enumTable_"] = enumTable;
		lua["CMANO"] = luaDynamicFunctions;
		SetUpAliases();
		if (AliasString.Length > 0)
		{
			lua.DoString(AliasString.ToString());
		}
		lua.DoString(SecurityString.ToString());
		string text = Path.Combine(GameGeneral.TopLevelWritablePath, "Defaults", ".startup.lua");
		if (FileExistsNative.FileExistsFast(text))
		{
			string string_ = File.ReadAllText(text);
			RunScript(string_, bool_0: false, "Initializing", text);
		}
	}

	public void ClearStats()
	{
		luaDynamicFunctions = null;
		enumTable = null;
		ScenarioContext = null;
		UnitX = null;
		UnitY = null;
		UnitC = null;
		SensorsThatMadeDetection = null;
		EventX = null;
		CMANO.HandleScenarioChanging();
	}

	private void HandleLuaPrint(object object_1)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(object_1)));
		string string_ = "";
		object obj = stringBuilder.ToString();
		LuaUtility.AddToLuaHistoryFile(ref string_, ref obj);
	}

	public void SetLuaPathGlobals(string string_0)
	{
		if (lua != null)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				lua["_scriptfolder_"] = "";
			}
			else
			{
				lua["_scriptfolder_"] = Path.GetDirectoryName(string_0);
			}
			if (ScenarioContext != null && !string.IsNullOrEmpty(ScenarioContext.FileNamePath))
			{
				lua["_scenariofolder_"] = ScenarioContext.FileNamePath;
			}
			else
			{
				lua["_scenariofolder_"] = "";
			}
			if (Exporter_General.ViewBridge())
			{
				lua["_outputfolder_"] = Exporter_General.ValidateBridge();
			}
			else
			{
				lua["_outputfolder_"] = "";
			}
		}
	}

	public void myDebugHook(object sender, DebugHookEventArgs e)
	{
		LuaDebug luaDebug = e.LuaDebug;
		string string_ = sender.ToString();
		object obj = luaDebug.ToString();
		LuaUtility.AddToLuaHistoryFile(ref string_, ref obj);
	}

	public void myExceptionHook(object sender, HookExceptionEventArgs e)
	{
		_ = e.Exception;
		string string_ = sender.ToString();
		object obj = e.ToString();
		LuaUtility.AddToLuaHistoryFile(ref string_, ref obj);
	}

	public void UnitTests()
	{
	}

	private void ClearLuaErrorCondition(string string_0)
	{
		currentFunction = string_0;
		if (Operators.CompareString(lua["_errmsg_"].ToString(), "", TextCompare: false) != 0)
		{
			lua["_errmsg_"] = "";
			lua["_errfnc_"] = "";
			lua["_errnum_"] = 0;
		}
	}

	public void RegisterFunction(string string_0, MethodInfo methodInfo_0)
	{
		try
		{
			if (lua.Globals.Contains(string_0 + ".Method.Attributes"))
			{
				return;
			}
			lua.RegisterFunction(string_0, this, methodInfo_0);
			List<string> list = new List<string>();
			ParameterInfo[] parameters = methodInfo_0.GetParameters();
			ParameterInfo[] array = parameters;
			foreach (ParameterInfo parameterInfo in array)
			{
				if (Operators.CompareString(parameterInfo.Name, "CoordsFormat", TextCompare: false) == 0)
				{
					list.Add("'DEC'/'DEG'");
				}
				else if (parameterInfo.ParameterType == typeof(string))
				{
					list.Add("'" + parameterInfo.Name + "'");
				}
				else
				{
					list.Add(parameterInfo.Name);
				}
			}
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

	[DoNotObfuscate]
	[DoNotPrune]
	public object LUA_UI_CallAdvancedHTMLDialog(string string_0, string string_1, LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("UI_CallAdvancedHTMLDialog");
		try
		{
			return PrivateMethods.UI_CallAdvancedHTMLDialog(string_0, string_1, luaTable_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_UI_CallAdvancedDialog(string string_0, string string_1, LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("UI_CallAdvancedDialog");
		try
		{
			return PrivateMethods.UI_CallAdvancedDialog(string_0, string_1, luaTable_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_UI_SelectUnitsPrompt_OwnSide(ref LuaTable luaTable_0, bool bool_0)
	{
		ClearLuaErrorCondition("UI_SelectUnitsPrompt_OwnSide");
		try
		{
			return PrivateMethods.UI_SelectUnitsPrompt_OwnSide(ref luaTable_0, bool_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_UI_SelectUnitsPrompt_FromSides(ref LuaTable luaTable_0, LuaTable luaTable_1, bool bool_0, LuaTable luaTable_2)
	{
		ClearLuaErrorCondition("UI_SelectUnitsPrompt_FromSides");
		try
		{
			return PrivateMethods.UI_SelectUnitsPrompt_FromSides(ref luaTable_0, luaTable_1, bool_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[ObfuscateControlFlow]
	[DoNotPrune]
	public void LUA_ScenEdit_Print(object object_1)
	{
		this.LuaPrint?.Invoke(RuntimeHelpers.GetObjectValue(object_1));
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public void LUA_Command_SaveScen(string string_0)
	{
		try
		{
			PrivateMethods.Command_SaveScen(string_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public void LUA_ScenEdit_LockSimulationFidelity(bool bool_0)
	{
		try
		{
			PrivateMethods.ScenEdit_LockSimulationFidelity(bool_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_ScenEdit_SetSimulationFidelity(float float_0)
	{
		try
		{
			return PrivateMethods.ScenEdit_SetSimulationFidelity(float_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
		}
		return "";
	}

	[ObfuscateControlFlow]
	[DoNotPrune]
	public void LUA_ScenEdit_PrintEscaped(object object_1)
	{
		string text = Conversions.ToString(object_1);
		text = text.Replace("\"", "\\\"").Replace("'", "\\'");
		LUA_ScenEdit_Print(text);
	}

	public object[] RunScript(string string_0, bool bool_0, string string_1 = null, string string_2 = null)
	{
		object scriptLockObj = ScriptLockObj;
		ObjectFlowControl.CheckForSyncLockOnValueType(scriptLockObj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(scriptLockObj, ref lockTaken);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Clear();
			_ = string_0.Split('(')[0];
			string_0 = string_0.Replace("\ufffd", "");
			RunInteractive = bool_0;
			if ((_LuaSandbox != null) & !RunInteractive)
			{
				stringBuilder.Append(string_0);
				if (lua != null)
				{
					string text = null;
					try
					{
						text = lua.GetString("_lua_event");
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					if (text != null)
					{
						bool? flag = LuaUtility.ParseBoolean(text);
						flag = flag;
						if (flag.GetValueOrDefault())
						{
							_lua_event = true;
						}
						else
						{
							_lua_event = false;
						}
					}
				}
				if (_lua_event)
				{
					string string_3 = "脚本：" + string_1;
					object obj = stringBuilder.ToString();
					LuaUtility.AddToLuaHistoryFile(ref string_3, ref obj, bool_0: true);
				}
			}
			currentLine = 0;
			try
			{
				if (Operators.CompareString(string_0, "_VERSION", TextCompare: false) != 0)
				{
					SetLuaPathGlobals(string_2);
					try
					{
						if (RunInteractive)
						{
							return lua.DoString(string_0, "Console");
						}
						return lua.DoString(string_0, string_1);
					}
					catch (LuaScriptException val)
					{
						ProjectData.SetProjectError(val);
						LuaScriptException val2 = val;
						if (((Exception)val2).InnerException is LuaError)
						{
							if (RunInteractive)
							{
								if (((LuaError)((Exception)val2).InnerException).sFunctionName == null)
								{
									GameGeneral.ResolveBridge(((LuaError)((Exception)val2).InnerException).sMessage, null);
								}
								else
								{
									GameGeneral.ResolveBridge(((LuaError)((Exception)val2).InnerException).sFunctionName + " " + ((LuaError)((Exception)val2).InnerException).sLine + " : " + ((LuaError)((Exception)val2).InnerException).sMessage, null);
								}
							}
							object[] result = new object[2]
							{
								null,
								((LuaError)((Exception)val2).InnerException).sMessage
							};
							ProjectData.ClearProjectError();
							return result;
						}
						throw;
					}
				}
				return lua.DoString("return _VERSION");
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				if (!(RunInteractive & !ex2.Message.Contains("unfinished string near")))
				{
					if (!ex2.Message.Contains("unfinished string near"))
					{
						string string_4 = "";
						object obj2 = ex2;
						LuaUtility.AddToLuaHistoryFile(ref string_4, ref obj2);
					}
					throw;
				}
				object[] result2 = new object[2] { ex2, null };
				ProjectData.ClearProjectError();
				return result2;
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(scriptLockObj);
			}
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_ActiveUnit_SE LUA_ScenEdit_UnitX()
	{
		ClearLuaErrorCondition("ScenEdit_UnitX");
		if (UnitX == null)
		{
			return null;
		}
		try
		{
			if (UnitX.GetType().Equals(typeof(UnguidedWeapon)))
			{
				return new LuaWrapper_ActiveUnit_SE((UnguidedWeapon)UnitX, ScenarioContext);
			}
			return new LuaWrapper_ActiveUnit_SE((ActiveUnit)UnitX, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_UnitY()
	{
		ClearLuaErrorCondition("ScenEdit_UnitY");
		if (UnitY == null)
		{
			return null;
		}
		try
		{
			LuaTable val = _LuaSandbox.CreateTable();
			val["unit"] = new LuaWrapper_ActiveUnit_SE(UnitY, ScenarioContext);
			LuaTable val2 = _LuaSandbox.CreateTable();
			if (SensorsThatMadeDetection == null)
			{
				return val;
			}
			foreach (Sensor item in SensorsThatMadeDetection)
			{
				LuaTable val3 = _LuaSandbox.CreateTable();
				val3["name"] = item.Name;
				val3["type"] = item.Type.ToString();
				val2[val2.Keys.Count + 1] = val3;
			}
			val["sensor"] = val2;
			return val;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_Contact LUA_ScenEdit_UnitC()
	{
		ClearLuaErrorCondition("ScenEdit_UnitC");
		if (UnitC == null)
		{
			return null;
		}
		try
		{
			return new LuaWrapper_Contact(UnitC, ScenarioContext, UnitY.GetUnitSide());
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_Event LUA_ScenEdit_EventX()
	{
		ClearLuaErrorCondition("ScenEdit_EventX");
		if (EventX == null)
		{
			return null;
		}
		try
		{
			return new LuaWrapper_Event(EventX, 0, bool_1: false, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public int LUA_ScenEdit_CurrentTime()
	{
		ClearLuaErrorCondition("ScenEdit_CurrentTime");
		try
		{
			return (int)Math.Round((ScenarioContext.Time - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_TransformZone(string string_0, string string_1, string string_2)
	{
		ClearLuaErrorCondition("ScenEdit_TransformZone");
		try
		{
			return PrivateMethods.ScenEdit_TransformZone(string_0, string_1, string_2, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_GetUnitIntermittentEmissionConfig(string string_0, string string_1)
	{
		ClearLuaErrorCondition("ScenEdit_GetUnitIntermittentEmissionConfig");
		try
		{
			return PrivateMethods.ScenEdit_GetUnitIntermittentEmissionConfig(string_0, string_1, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_SetUnitIntermittentEmissionConfig(string string_0, string string_1, LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetUnitIntermittentEmissionConfig");
		try
		{
			return PrivateMethods.ScenEdit_SetUnitIntermittentEmissionConfig(string_0, string_1, luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_DuplicateEmconConfigToUnit(string string_0, string string_1, string string_2)
	{
		ClearLuaErrorCondition("ScenEdit_DuplicateEmconConfigToUnit");
		try
		{
			return PrivateMethods.ScenEdit_DuplicateEmconConfigToUnit(string_0, string_1, string_2, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_CreateBarkNotification_Geo_Bulk(float float_0, float float_1, LuaTable luaTable_0, int int_0, int int_1, int int_2, bool bool_0 = true, bool bool_1 = true, float float_2 = 1f, float float_3 = 18f)
	{
		ClearLuaErrorCondition("LUA_ScenEdit_CreateBarkNotification_Geo_Bulk");
		try
		{
			return PrivateMethods.ScenEdit_CreateBarkNotification_Geo_Bulk(float_0, float_1, luaTable_0, int_0, int_1, int_2, bool_0, bool_1, float_2, float_3, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_CreateBarkNotification_Geo(float float_0, float float_1, string string_0, int int_0, int int_1, int int_2, bool bool_0 = true, bool bool_1 = true, float float_2 = 1f, float float_3 = 18f)
	{
		ClearLuaErrorCondition("ScenEdit_CreateBarkNotification_Geo");
		try
		{
			return PrivateMethods.ScenEdit_CreateBarkNotification_Geo(float_0, float_1, string_0, int_0, int_1, int_2, bool_0, bool_1, float_2, float_3, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_CreateBarkNotification_Unit(string string_0, string string_1, int int_0, int int_1, int int_2, bool bool_0 = true, bool bool_1 = true, float float_0 = 1f, float float_1 = 18f)
	{
		ClearLuaErrorCondition("ScenEdit_CreateBarkNotification_Unit");
		try
		{
			return PrivateMethods.ScenEdit_CreateBarkNotification_Unit(string_0, string_1, int_0, int_1, int_2, bool_0, bool_1, float_0, float_1, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_CreateBarkNotification_Unit_Bulk(string string_0, LuaTable luaTable_0, int int_0, int int_1, int int_2, bool bool_0 = true, bool bool_1 = true, float float_0 = 1f, float float_1 = 18f)
	{
		ClearLuaErrorCondition("LUA_ScenEdit_CreateBarkNotification_Unit_Bulk");
		try
		{
			return PrivateMethods.ScenEdit_CreateBarkNotification_Unit_Bulk(string_0, luaTable_0, int_0, int_1, int_2, bool_0, bool_1, float_0, float_1, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_SwitchUnitIntermittentEmission(string string_0, string string_1, float float_0)
	{
		ClearLuaErrorCondition("ScenEdit_SwitchUnitIntermittentEmission");
		try
		{
			return PrivateMethods.ScenEdit_SwitchUnitIntermittentEmission(string_0, string_1, float_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_SetSideEmconAlertness(string string_0, string string_1)
	{
		ClearLuaErrorCondition("ScenEdit_SetSideEmconAlertness");
		try
		{
			return PrivateMethods.ScenEdit_SetSideEmconAlertness(string_0, string_1, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_ClearAllSideUnitsEmconConfigs(string string_0)
	{
		ClearLuaErrorCondition("ScenEdit_ClearAllSideUnitsEmconConfigs");
		try
		{
			return PrivateMethods.ScenEdit_ClearAllSideUnitsEmconConfigs(string_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_DuplicateEmconConfigToSide(string string_0, string string_1, string string_2)
	{
		ClearLuaErrorCondition("ScenEdit_DuplicateEmconConfigToSide");
		try
		{
			return PrivateMethods.ScenEdit_DuplicateEmconConfigToSide(string_0, string_1, string_2, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_ClearUnitEmconConfigs(string string_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetSideEmconAlertness");
		try
		{
			return PrivateMethods.ScenEdit_ClearUnitEmconConfigs(string_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public void LUA_Exporter_SetSetting(string string_0, string string_1, string string_2)
	{
		ClearLuaErrorCondition("Exporter_SetSetting");
		try
		{
			PrivateMethods.Exporter_SetSetting(string_0, string_1, string_2, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_CurrentLocalTime()
	{
		ClearLuaErrorCondition("ScenEdit_CurrentLocalTime");
		try
		{
			Side currentSide = ScenarioContext.GetCurrentSide();
			double longitude = ((currentSide == null) ? new GeoPoint(0.0, 0.0) : currentSide.MapCenter).Longitude;
			DateTime dateTime = Misc.DisableRequest(ScenarioContext.Time, longitude, ScenarioContext.Use_DST, ScenarioContext.DST_Start, ScenarioContext.DST_End);
			return dateTime.Hour.ToString("D2") + ":" + dateTime.Minute.ToString("D2") + ":" + dateTime.Second.ToString("D2");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_Echo(string string_0)
	{
		return string_0;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_GetBuildNumber()
	{
		ClearLuaErrorCondition("GetBuildNumber");
		return "1328.18";
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public void LUA_VP_SetTimeCompression(int int_0)
	{
		ClearLuaErrorCondition("VP_SetTimeCompression");
		ScenarioContext.TimeCompression_Set((Scenario.enumTimeCompression)int_0);
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public void LUA_VP_PauseSimulation()
	{
		ClearLuaErrorCondition("VP_PauseSimulation");
		ScenarioContext.GameContext.Pause();
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public void LUA_VP_RunSimulation()
	{
		ClearLuaErrorCondition("VP_RunSimulation");
		ScenarioContext.GameContext.Run();
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_VP_RunToTimeAndHalt(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("VP_RunToTimeAndHalt");
		string result = PrivateMethods.ScenEdit_RunToTimeAndHalt(luaTable_0, ScenarioContext);
		ScenarioContext.GameContext.Run();
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_VP_RunForTimeAndHalt(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("VP_RunForTimeAndHalt");
		string result = PrivateMethods.ScenEdit_RunForTimeAndHalt(luaTable_0, ScenarioContext);
		ScenarioContext.GameContext.Run();
		return result;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_GetScenarioTitle()
	{
		ClearLuaErrorCondition("GetScenarioTitle");
		return ScenarioContext.Title;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public void LUA_ScenEdit_ClearAllMagazines(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_ClearAllMagazines");
		try
		{
			PrivateMethods.ScenEdit_ClearAllMagazines(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public void LUA_ScenEdit_ClearAllAircraft(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_ClearAllAircraft");
		try
		{
			PrivateMethods.ScenEdit_ClearAllAircraft(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_VP_GetSides()
	{
		ClearLuaErrorCondition("VP_GetSides");
		try
		{
			return PrivateMethods.VP_GetSides(ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_Side LUA_VP_GetSide(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("VP_GetSide");
		try
		{
			return PrivateMethods.VP_GetSide(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_ActiveUnit LUA_VP_GetUnit(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("VP_GetUnit");
		try
		{
			return PrivateMethods.VP_GetUnit(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_Contact LUA_VP_GetContact(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("VP_GetContact");
		try
		{
			return PrivateMethods.VP_GetContact(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_Scenario LUA_VP_GetScenario()
	{
		ClearLuaErrorCondition("VP_GetScenario");
		try
		{
			return PrivateMethods.VP_GetScenario(ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_AddAircraft(string string_0, string string_1, int int_0, int int_1, string string_2, string string_3, string string_4)
	{
		ClearLuaErrorCondition("ScenEdit_AddAircraft");
		return PrivateMethods.ScenEdit_AddAircraft(string_0, string_1, int_0, int_1, string_2, string_3, string_4, ScenarioContext);
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_ScenEdit_AddShip(string string_0, string string_1, int int_0, string string_2, string string_3, string string_4)
	{
		ClearLuaErrorCondition("ScenEdit_AddShip");
		return PrivateMethods.ScenEdit_AddShip(string_0, string_1, int_0, string_2, string_3, string_4, ScenarioContext);
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_ScenEdit_AddSubmarine(string string_0, string string_1, int int_0, string string_2, string string_3, string string_4)
	{
		ClearLuaErrorCondition("ScenEdit_AddSubmarine");
		return PrivateMethods.ScenEdit_AddSubmarine(string_0, string_1, int_0, string_2, string_3, string_4, ScenarioContext);
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_ScenEdit_AddFacility(string string_0, string string_1, int int_0, int int_1, string string_2, string string_3, string string_4)
	{
		ClearLuaErrorCondition("ScenEdit_AddFacility");
		return PrivateMethods.ScenEdit_AddFacility(string_0, string_1, int_0, int_1, string_2, string_3, string_4, ScenarioContext);
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_AssignUnitToMission(string string_0, string string_1, bool bool_0 = false, bool bool_1 = false)
	{
		ClearLuaErrorCondition("ScenEdit_AssignUnitToMission");
		bool value = LuaUtility.ParseBoolean(bool_0).Value;
		bool value2 = LuaUtility.ParseBoolean(bool_1).Value;
		try
		{
			return PrivateMethods.ScenEdit_AssignUnitToMission(string_0, string_1, ScenarioContext, (ActiveUnit)UnitX, value, value2);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_EpochToUTC_Date(int int_0)
	{
		ClearLuaErrorCondition("EpochToUTC_Date");
		try
		{
			return PrivateMethods.EpochToUTC_Date(int_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_EpochToUTC_Time(int int_0)
	{
		ClearLuaErrorCondition("EpochToUTC_Time");
		try
		{
			return PrivateMethods.EpochToUTC_Time(int_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public double LUA_ScenEdit_SetTime(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetTime");
		try
		{
			return PrivateMethods.ScenEdit_SetTime(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return 0.0;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public double LUA_ScenEdit_SetStartTime(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetStartTime");
		try
		{
			return PrivateMethods.ScenEdit_SetStartTime(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return 0.0;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_SetWeather(int int_0, int int_1, float float_0, int int_2)
	{
		ClearLuaErrorCondition("ScenEdit_SetWeather");
		try
		{
			return PrivateMethods.ScenEdit_SetWeather(int_0, int_1, float_0, int_2, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_GetWeather()
	{
		ClearLuaErrorCondition("ScenEdit_GetWeather");
		try
		{
			return PrivateMethods.ScenEdit_GetWeather(ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_SetSidePosture(string string_0, string string_1, string string_2)
	{
		ClearLuaErrorCondition("ScenEdit_SetSidePosture");
		try
		{
			return PrivateMethods.ScenEdit_SetSidePosture(string_0, string_1, string_2, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_SetSideOptions(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetSideOptions");
		try
		{
			return PrivateMethods.ScenEdit_SetSideOptions(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_SetUnitDamage(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetUnitDamage");
		try
		{
			return PrivateMethods.ScenEdit_SetUnitDamage(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_SetSpecialAction(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetSpecialAction");
		try
		{
			return LuaEvent.ScenEdit_SetSpecialAction(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_AddSpecialAction(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_AddSpecialAction");
		try
		{
			return LuaEvent.ScenEdit_AddSpecialAction(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_SetExportOutputRate(string string_0, string string_1)
	{
		ClearLuaErrorCondition("ScenEdit_SetExportOutputRate");
		try
		{
			return PrivateMethods.ScenEdit_SetExportOutputRate(string_0, string_1);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_SetEMCON(string string_0, string string_1, string string_2)
	{
		ClearLuaErrorCondition("ScenEdit_SetEMCON");
		try
		{
			return PrivateMethods.ScenEdit_SetEMCON(string_0, string_1, string_2, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_MsgBox(string string_0, int int_0)
	{
		ClearLuaErrorCondition("ScenEdit_MsgBox");
		return PrivateMethods.ScenEdit_MsgBox(string_0, int_0, ScenarioContext);
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_InputBox(string string_0)
	{
		ClearLuaErrorCondition("ScenEdit_InputBox");
		return PrivateMethods.ScenEdit_InputBox(string_0, ScenarioContext);
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_RunScript(string string_0, bool bool_0 = false)
	{
		ClearLuaErrorCondition("ScenEdit_RunScript");
		string text = null;
		string text2 = Path.Combine(GameGeneral.TopLevelWritablePath, "Lua");
		string text3 = (bool_0 ? string_0 : (text2 + "\\" + string_0));
		try
		{
			if (FileExistsNative.FileExistsFast(text3))
			{
				text = File.ReadAllText(text3);
				SetLuaPathGlobals(text3);
				string string_ = "Script";
				object obj = currentFunction + " executing Lua\\" + string_0;
				LuaUtility.AddToLuaHistoryFile(ref string_, ref obj, bool_0: true);
			}
			else
			{
				if (!string_0.Contains(GameGeneral.AttachmentRepoPath))
				{
					throw new LuaError("文件路径 '" + string_0 + "' 未找到");
				}
				text = File.ReadAllText(string_0);
				SetLuaPathGlobals(string_0);
				string string_2 = "Script";
				object obj2 = currentFunction + " executing " + string_0;
				LuaUtility.AddToLuaHistoryFile(ref string_2, ref obj2, bool_0: true);
			}
			lua.DoString(text, string_0);
			return "";
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_ScenEdit_SetKeyValue(string string_0, object object_1, bool bool_0 = false)
	{
		ClearLuaErrorCondition("ScenEdit_SetKeyValue");
		if (ScenarioContext.IsRunningInCampaignMode && bool_0)
		{
			if (string.IsNullOrWhiteSpace(ScenarioContext.LuaXmlPassed))
			{
				ScenarioContext.LuaXmlPassed = "<KeyValueDatastore></KeyValueDatastore>";
			}
			XElement xElement = XElement.Parse(ScenarioContext.LuaXmlPassed);
			XElement xElement2 = xElement.Element(string_0);
			if (xElement2 == null)
			{
				xElement2 = new XElement(string_0, RuntimeHelpers.GetObjectValue(object_1));
				xElement.Add(xElement2);
			}
			else
			{
				xElement2.Value = object_1.ToString();
			}
			ScenarioContext.LuaXmlPassed = xElement.ToString();
		}
		else
		{
			if (bool_0)
			{
				return "不在战役模式下";
			}
			if (string.IsNullOrWhiteSpace(ScenarioContext.LuaXml))
			{
				ScenarioContext.LuaXml = "<KeyValueDatastore></KeyValueDatastore>";
			}
			XElement xElement3 = XElement.Parse(ScenarioContext.LuaXml);
			XElement xElement4 = xElement3.Element(string_0);
			if (xElement4 == null)
			{
				xElement4 = new XElement(string_0, RuntimeHelpers.GetObjectValue(object_1));
				xElement3.Add(xElement4);
			}
			else
			{
				xElement4.Value = object_1.ToString();
			}
			ScenarioContext.LuaXml = xElement3.ToString();
		}
		return "Saved";
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_GetKeyValue(string string_0, bool bool_0 = false)
	{
		ClearLuaErrorCondition("ScenEdit_GetKeyValue");
		XElement xElement;
		if (ScenarioContext.IsRunningInCampaignMode && bool_0)
		{
			if (string.IsNullOrWhiteSpace(ScenarioContext.LuaXmlPassed))
			{
				ScenarioContext.LuaXmlPassed = "<KeyValueDatastore></KeyValueDatastore>";
			}
			xElement = XElement.Parse(ScenarioContext.LuaXmlPassed);
		}
		else
		{
			if (string.IsNullOrWhiteSpace(ScenarioContext.LuaXml))
			{
				ScenarioContext.LuaXml = "<KeyValueDatastore></KeyValueDatastore>";
			}
			xElement = XElement.Parse(ScenarioContext.LuaXml);
		}
		XElement xElement2 = xElement.Element(string_0);
		if (xElement2 == null)
		{
			return "";
		}
		return xElement2.Value;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_GetKeyStore(bool bool_0 = false)
	{
		ClearLuaErrorCondition("ScenEdit_GetKeyStore");
		XElement xElement;
		if (ScenarioContext.IsRunningInCampaignMode && bool_0)
		{
			if (string.IsNullOrWhiteSpace(ScenarioContext.LuaXmlPassed))
			{
				ScenarioContext.LuaXmlPassed = "<KeyValueDatastore></KeyValueDatastore>";
			}
			xElement = XElement.Parse(ScenarioContext.LuaXmlPassed);
		}
		else
		{
			if (string.IsNullOrWhiteSpace(ScenarioContext.LuaXml))
			{
				ScenarioContext.LuaXml = "<KeyValueDatastore></KeyValueDatastore>";
			}
			xElement = XElement.Parse(ScenarioContext.LuaXml);
		}
		LuaTable val = _LuaSandbox.CreateTable();
		foreach (XElement item in xElement.Elements())
		{
			val[item.Name.ToString()] = item.Value;
		}
		return val;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_ClearKeyValue(string string_0, bool bool_0 = false)
	{
		ClearLuaErrorCondition("ScenEdit_ClearKeyValue");
		XElement xElement = null;
		if (ScenarioContext.IsRunningInCampaignMode && bool_0)
		{
			if (Operators.CompareString(string_0, "", TextCompare: false) == 0)
			{
				ScenarioContext.LuaXmlPassed = null;
				return true;
			}
			if (string.IsNullOrWhiteSpace(ScenarioContext.LuaXmlPassed))
			{
				ScenarioContext.LuaXmlPassed = "<KeyValueDatastore></KeyValueDatastore>";
			}
			xElement = XElement.Parse(ScenarioContext.LuaXmlPassed);
		}
		else
		{
			if (bool_0)
			{
				return false;
			}
			if (Operators.CompareString(string_0, "", TextCompare: false) == 0)
			{
				ScenarioContext.LuaXml = null;
				return true;
			}
			if (string.IsNullOrWhiteSpace(ScenarioContext.LuaXml))
			{
				ScenarioContext.LuaXml = "<KeyValueDatastore></KeyValueDatastore>";
			}
			xElement = XElement.Parse(ScenarioContext.LuaXml);
		}
		XElement xElement2 = xElement.Element(string_0);
		if (xElement2 == null)
		{
			return false;
		}
		xElement2.Remove();
		if (bool_0)
		{
			ScenarioContext.LuaXmlPassed = xElement.ToString();
		}
		else
		{
			ScenarioContext.LuaXml = xElement.ToString();
		}
		return true;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_ActiveUnit_SE LUA_ScenEdit_AddUnit(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_AddUnit");
		try
		{
			return PrivateMethods.ScenEdit_AddUnit(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_ActiveUnit_SE LUA_ScenEdit_UpdateUnit(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_UpdateUnit");
		try
		{
			return PrivateMethods.ScenEdit_UpdateUnit(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_ActiveUnit_SE LUA_ScenEdit_UpdateUnitCargo(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_UpdateUnitCargo");
		try
		{
			return PrivateMethods.ScenEdit_UpdateUnitCargo(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_AddExplosion(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_AddExplosion");
		try
		{
			return PrivateMethods.ScenEdit_AddExplosion(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_ActiveUnit_SE LUA_ScenEdit_SetUnit(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetUnit");
		try
		{
			return PrivateMethods.ScenEdit_SetUnit(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_GetTimeOfDay(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_GetTimeOfDay");
		try
		{
			return PrivateMethods.ScenEdit_GetTimeOfDay(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_ActiveUnit_SE LUA_ScenEdit_GetUnit(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_GetUnit");
		try
		{
			return PrivateMethods.ScenEdit_GetUnit(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_DeleteUnit(LuaTable luaTable_0, bool bool_0 = false)
	{
		ClearLuaErrorCondition("ScenEdit_DeleteUnit");
		try
		{
			return PrivateMethods.ScenEdit_DeleteUnit(luaTable_0, bool_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_KillUnit(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_KillUnit");
		try
		{
			return PrivateMethods.ScenEdit_KillUnit(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_SetUnitSide(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetUnitSide");
		try
		{
			return PrivateMethods.ScenEdit_SetUnitSide(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_ReferencePoint LUA_ScenEdit_AddReferencePoint(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_AddReferencePoint");
		try
		{
			return LuaReferencePoint.ScenEdit_AddReferencePoint(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_SetLoadoutAvailable(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetLoadoutAvailable");
		try
		{
			return PrivateMethods.ScenEdit_SetLoadoutAvailable(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_ReferencePoint LUA_ScenEdit_SetReferencePoint(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetReferencePoint");
		try
		{
			return LuaReferencePoint.ScenEdit_SetReferencePoint(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_ReferencePoint LUA_ScenEdit_GetReferencePoint(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_GetReferencePoint");
		try
		{
			return LuaReferencePoint.ScenEdit_GetReferencePoint(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_GetReferencePoints(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_GetReferencePoints");
		try
		{
			return LuaReferencePoint.ScenEdit_GetReferencePoints(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_DeleteReferencePoint(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_DeleteReferencePoint");
		try
		{
			return LuaReferencePoint.ScenEdit_DeleteReferencePoint(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_SetDoctrine(LuaTable luaTable_0, LuaTable luaTable_1)
	{
		ClearLuaErrorCondition("ScenEdit_SetDoctrine");
		try
		{
			return LuaDoctrine.ScenEdit_SetDoctrine(luaTable_0, luaTable_1, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_SetDoctrineWRA(LuaTable luaTable_0, LuaTable luaTable_1)
	{
		ClearLuaErrorCondition("ScenEdit_SetDoctrineWRA");
		try
		{
			return LuaDoctrine.ScenEdit_SetDoctrineWRA(luaTable_0, luaTable_1, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_GetDoctrine(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_GetDoctrine");
		try
		{
			return LuaDoctrine.ScenEdit_GetDoctrine(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_GetDBFileHash(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_GetDBFileHash");
		try
		{
			return PrivateMethods.ScenEdit_GetDBFileHash(luaTable_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_GetSensorData(int int_0)
	{
		ClearLuaErrorCondition("ScenEdit_GetSensorData");
		try
		{
			return PrivateMethods.ScenEdit_GetSensorData(int_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_GetDoctrineWRA(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_GetDoctrineWRA");
		try
		{
			return LuaDoctrine.ScenEdit_GetDoctrineWRA(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public object LUA_ScenEdit_HostUnitToParent(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_HostUnitToParent");
		try
		{
			return PrivateMethods.ScenEdit_HostUnitToParent(luaTable_0, ScenarioContext, (ActiveUnit)UnitX);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_GetSideOptions(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_GetSideOptions");
		try
		{
			return PrivateMethods.ScenEdit_GetSideOptions(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_GetSidePosture(string string_0, string string_1)
	{
		ClearLuaErrorCondition("ScenEdit_GetSidePosture");
		try
		{
			return PrivateMethods.ScenEdit_GetSidePosture(string_0, string_1, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_GetSideIsHuman(string string_0)
	{
		ClearLuaErrorCondition("ScenEdit_GetSideIsHuman");
		try
		{
			return LuaSide.ScenEdit_GetSideIsHuman(string_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[ObfuscateControlFlow]
	[DoNotPrune]
	public bool LUA_ScenEdit_UseAttachment(string string_0)
	{
		ClearLuaErrorCondition("ScenEdit_UseAttachment");
		try
		{
			return LuaSAO.ScenEdit_UseAttachment(string_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[ObfuscateControlFlow]
	[DoNotPrune]
	public bool LUA_ScenEdit_UseAttachmentOnSide(string string_0, string string_1)
	{
		ClearLuaErrorCondition("ScenEdit_UseAttachmentOnSide");
		try
		{
			return LuaSAO.ScenEdit_UseAttachmentOnSide(string_0, string_1, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[ObfuscateControlFlow]
	[DoNotPrune]
	public bool LUA_ScenEdit_PlaySound(string string_0, int int_0 = 0)
	{
		ClearLuaErrorCondition("ScenEdit_PlaySound");
		try
		{
			return PrivateMethods.ScenEdit_LocalSound(string_0, int_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[ObfuscateControlFlow]
	public string LUA_ScenEdit_PlayVideo(string string_0, bool bool_0 = true, int int_0 = 0)
	{
		ClearLuaErrorCondition("ScenEdit_PlayVideo");
		try
		{
			return PrivateMethods.ScenEdit_LocalVideo(string_0, ScenarioContext, bool_0, int_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public int LUA_ScenEdit_GetScore(string string_0)
	{
		ClearLuaErrorCondition("ScenEdit_GetScore");
		try
		{
			return PrivateMethods.ScenEdit_GetScore(string_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public int LUA_ScenEdit_SetScore(string string_0, int int_0, string string_1 = "No reason given")
	{
		ClearLuaErrorCondition("ScenEdit_SetScore");
		try
		{
			return PrivateMethods.ScenEdit_SetScore(string_0, int_0, ScenarioContext, string_1);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_GetScenHasStarted()
	{
		ClearLuaErrorCondition("ScenEdit_GetScenHasStarted");
		return ScenarioContext.HasStarted;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_SetLoadout(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetLoadout");
		try
		{
			return PrivateMethods.ScenEdit_SetLoadout(luaTable_0, ScenarioContext, (ActiveUnit)UnitX);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public int LUA_ScenEdit_SpecialMessage(string string_0, string string_1, LuaTable luaTable_0 = null, bool bool_0 = false)
	{
		ClearLuaErrorCondition("ScenEdit_SpecialMessage");
		try
		{
			return PrivateMethods.ScenEdit_SpecialMessage(string_0, string_1, ScenarioContext, luaTable_0, bool_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_PlayerSide()
	{
		ClearLuaErrorCondition("ScenEdit_PlayerSide");
		return ScenarioContext.GetCurrentSide().Name;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public int LUA_ScenEdit_EndScenario()
	{
		ClearLuaErrorCondition("ScenEdit_EndScenario");
		ScenarioContext.EndScenario();
		return 1;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public int LUA_ScenEdit_ExportInst(string string_0, LuaTable luaTable_0, LuaTable luaTable_1)
	{
		ClearLuaErrorCondition("ScenEdit_ExportInst");
		try
		{
			return LuaImportExport.ScenEdit_ExportInst(string_0, luaTable_0, luaTable_1, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public int LUA_ScenEdit_ImportInst(string string_0, string string_1)
	{
		ClearLuaErrorCondition("ScenEdit_ImportInst");
		try
		{
			return LuaImportExport.ScenEdit_ImportInst(string_0, string_1, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_Side LUA_ScenEdit_AddSide(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_AddSide");
		try
		{
			return PrivateMethods.ScenEdit_AddSide(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_Side LUA_ScenEdit_RemoveSide(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_RemoveSide");
		try
		{
			return PrivateMethods.ScenEdit_RemoveSide(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public int LUA_World_GetElevation(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("World_GetElevation");
		try
		{
			return PrivateMethods.World_GetElevation(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_World_GetLocation(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("World_GetLocation");
		try
		{
			return PrivateMethods.World_GetLocation(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_World_GetCircleFromPoint(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("World_GetCircleFromPoint");
		try
		{
			return PrivateMethods.World_GetCircleFromPoint(luaTable_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_World_GetPointFromBearing(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("World_GetPointFromBearing");
		try
		{
			return PrivateMethods.World_GetPointFromBearing(luaTable_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public int LUA_ScenEdit_AddReloadsToUnit(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_AddReloadsToUnit");
		try
		{
			return PrivateMethods.ScenEdit_AddReloadsToUnit(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public int LUA_ScenEdit_AddWeaponToUnitMagazine(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_AddWeaponToUnitMagazine");
		try
		{
			return PrivateMethods.ScenEdit_AddWeaponToUnitMagazine(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public void LUA_ScenEdit_DistributeWeaponAtAirbase(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_DistributeWeaponAtAirbase");
		try
		{
			PrivateMethods.ScenEdit_DistributeWeaponAtAirbase(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_RefuelUnit(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_RefuelUnit");
		try
		{
			return PrivateMethods.ScenEdit_RefuelUnit(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_Mission LUA_ScenEdit_AddMission(string string_0, string string_1, string string_2, LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_AddMission");
		try
		{
			return LuaMission.ScenEdit_AddMission(string_0, string_1, string_2, luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_GetMissions(string string_0)
	{
		ClearLuaErrorCondition("ScenEdit_GetMissions");
		try
		{
			return LuaMission.ScenEdit_GetMissions(string_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_Mission LUA_ScenEdit_GetMission(string string_0, string string_1)
	{
		ClearLuaErrorCondition("ScenEdit_GetMission");
		try
		{
			return LuaMission.ScenEdit_GetMission(string_0, string_1, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_DeleteMission(string string_0, string string_1)
	{
		ClearLuaErrorCondition("ScenEdit_DeleteMission");
		try
		{
			return LuaMission.ScenEdit_DeleteMission(string_0, string_1, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_Mission LUA_ScenEdit_SetMission(string string_0, string string_1, LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetMission");
		try
		{
			return LuaMission.ScenEdit_SetMission(string_0, string_1, luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_ImportMission(string string_0, string string_1)
	{
		ClearLuaErrorCondition("ScenEdit_ImportMission");
		try
		{
			return LuaMission.ScenEdit_ImportMission(string_0, string_1, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_FillMagsForLoadout(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_FillMagsForLoadout");
		try
		{
			return PrivateMethods.ScenEdit_FillMagsForLoadout(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_ExportMission(string string_0, string string_1)
	{
		ClearLuaErrorCondition("ScenEdit_ExportMission");
		try
		{
			return LuaMission.ScenEdit_ExportMission(string_0, string_1, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_ImportScenarioFromXML(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_ImportScenarioFromXML");
		try
		{
			throw new LuaError("此方法仅在CommandPE中可用。");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_ExportScenarioToXML()
	{
		ClearLuaErrorCondition("ScenEdit_ExportScenarioToXML");
		try
		{
			throw new LuaError("此方法仅在CommandPE中可用。");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_AssignUnitAsTarget(object object_1, string string_0)
	{
		ClearLuaErrorCondition("ScenEdit_AssignUnitAsTarget");
		try
		{
			return LuaMission.ScenEdit_AssignUnitAsTarget((LuaTable)RuntimeHelpers.GetObjectValue(object_1), string_0, ScenarioContext, (ActiveUnit)UnitX);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_RemoveUnitAsTarget(object object_1, string string_0)
	{
		ClearLuaErrorCondition("ScenEdit_RemoveUnitAsTarget");
		try
		{
			return LuaMission.ScenEdit_RemoveUnitAsTarget((LuaTable)RuntimeHelpers.GetObjectValue(object_1), string_0, ScenarioContext, (ActiveUnit)UnitX);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_GetContacts(string string_0)
	{
		ClearLuaErrorCondition("ScenEdit_GetContacts");
		try
		{
			return PrivateMethods.ScenEdit_GetContacts(string_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_Contact LUA_ScenEdit_GetContact(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_Contact");
		try
		{
			return PrivateMethods.ScenEdit_GetContact(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_ExecuteEventAction(string string_0)
	{
		string text = null;
		ClearLuaErrorCondition("ScenEdit_ExecuteEventAction");
		try
		{
			text = LuaEvent.ScenEdit_ExecuteEventAction(string_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
		if (text != null && Operators.CompareString(text, "", TextCompare: false) != 0)
		{
			try
			{
				SetLuaPathGlobals("");
				lua.DoString(text, string_0);
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				if (RunInteractive)
				{
					throw;
				}
				ProjectData.ClearProjectError();
				return null;
			}
			return "OK";
		}
		return "";
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_ScenEdit_ExecuteSpecialAction(string string_0)
	{
		string text = null;
		ClearLuaErrorCondition("ScenEdit_ExecuteSpecialAction");
		try
		{
			text = LuaEvent.ScenEdit_ExecuteSpecialAction(string_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
		if (text != null && Operators.CompareString(text, "", TextCompare: false) != 0)
		{
			try
			{
				SetLuaPathGlobals("");
				lua.DoString(text, string_0);
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				if (RunInteractive)
				{
					throw;
				}
				ProjectData.ClearProjectError();
				return null;
			}
			return "OK";
		}
		return "";
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_Zone LUA_ScenEdit_AddZone(string string_0, int int_0, LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_AddZone");
		try
		{
			return PrivateMethods.ScenEdit_AddZone(string_0, int_0, luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaWrapper_Zone LUA_ScenEdit_RemoveZone(string string_0, int int_0, LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_RemoveZone");
		try
		{
			return PrivateMethods.ScenEdit_RemoveZone(string_0, int_0, luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_Zone LUA_ScenEdit_SetZone(string string_0, int int_0, LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetZone");
		try
		{
			return PrivateMethods.ScenEdit_SetZone(string_0, int_0, luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public object LUA_ScenEdit_SetEvent(string string_0, LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetEvent");
		try
		{
			return LuaEvent.ScenEdit_SetEvent(string_0, luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public object LUA_ScenEdit_SetTrigger(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetTrigger");
		try
		{
			return LuaEvent.ScenEdit_SetTrigger(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public object LUA_ScenEdit_SetCondition(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetCondition");
		try
		{
			return LuaEvent.ScenEdit_SetCondition(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public object LUA_ScenEdit_SetAction(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetAction");
		try
		{
			return LuaEvent.ScenEdit_SetAction(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public object LUA_ScenEdit_SetEventTrigger(string string_0, LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetEventTrigger");
		try
		{
			return LuaEvent.ScenEdit_SetEventTrigger(string_0, luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public object LUA_ScenEdit_SetEventCondition(string string_0, LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetEventCondition");
		try
		{
			return LuaEvent.ScenEdit_SetEventCondition(string_0, luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public object LUA_ScenEdit_SetEventAction(string string_0, LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetEventAction");
		try
		{
			return LuaEvent.ScenEdit_SetEventAction(string_0, luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_Event LUA_ScenEdit_GetEvent(string string_0, int int_0 = 0)
	{
		ClearLuaErrorCondition("ScenEdit_GetEvent");
		try
		{
			return LuaEvent.ScenEdit_GetEvent(string_0, int_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_GetEvents(int int_0 = 0)
	{
		ClearLuaErrorCondition("ScenEdit_GetEvents");
		try
		{
			return LuaEvent.ScenEdit_GetEvents(int_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_GetSpecialAction(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_GetSpecialAction");
		try
		{
			return LuaEvent.ScenEdit_GetSpecialAction(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public object LUA_ScenEdit_UpdateEvent(string string_0, LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit__UpdateEvent");
		try
		{
			return LuaEvent.ScenEdit_UpdateEvent(string_0, luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_AttackContact(string string_0, string string_1, LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_AttackContact");
		try
		{
			return PrivateMethods.ScenEdit_AttackContact(string_0, string_1, luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_IsUnitInZone(string string_0, string string_1, string string_2)
	{
		ClearLuaErrorCondition("IsUnitInZone");
		try
		{
			return PrivateMethods.ScenEdit_IsUnitInZone(string_0, string_1, string_2, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_TransferCargo(string string_0, string string_1, LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_TransferCargo");
		try
		{
			return PrivateMethods.ScenEdit_TransferCargo(string_0, string_1, luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_UnloadCargo(string string_0, LuaTable luaTable_0 = null)
	{
		ClearLuaErrorCondition("ScenEdit_UnloadCargo");
		try
		{
			return PrivateMethods.ScenEdit_UnloadCargo(string_0, luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_GetFormation(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_GetFormation");
		try
		{
			return PrivateMethods.ScenEdit_GetFormation(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_Loadout LUA_ScenEdit_GetLoadout(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_GetLoadout");
		try
		{
			return PrivateMethods.ScenEdit_GetLoadout(luaTable_0, ScenarioContext, (ActiveUnit)UnitX);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public object LUA_ScenEdit_QueryDB(string string_0, int int_0)
	{
		ClearLuaErrorCondition("ScenEdit_QueryDB");
		try
		{
			return PrivateMethods.ScenEdit_QueryDB(string_0, int_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_SelectedUnits()
	{
		ClearLuaErrorCondition("ScenEdit_SelectedUnits");
		try
		{
			return PrivateMethods.ScenEdit_SelectedUnits(ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public int LUA_ScenEdit_AddMinefield(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_AddMinefield");
		try
		{
			return PrivateMethods.ScenEdit_AddMinefield(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public LuaTable LUA_ScenEdit_GetMinefield(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_GetMinefield");
		try
		{
			return PrivateMethods.ScenEdit_GetMinefield(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public int LUA_ScenEdit_DeleteMinefield(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_DeleteMinefield");
		try
		{
			return PrivateMethods.ScenEdit_DeleteMinefield(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_SetMine(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SetMine");
		try
		{
			return PrivateMethods.ScenEdit_SetMine(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_DeleteMine(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_DeleteMine");
		try
		{
			return PrivateMethods.ScenEdit_DeleteMine(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_GetDateTimeTicks()
	{
		ClearLuaErrorCondition("ScenEdit_GetDateTimeTicks");
		try
		{
			return PrivateMethods.ScenEdit_GetDateTimeTicks(ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_ScenEdit_AddCustomLoss(string string_0, LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_AddCustomLoss");
		try
		{
			return PrivateMethods.ScenEdit_AddCustomLoss(string_0, luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string LUA_ScenEdit_ExportDoctrineToXML(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("LUA_ScenEdit_ExportDoctrineToXML");
		try
		{
			return LuaDoctrine.ScenEdit_ExportDoctrineToXML(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string LUA_ScenEdit_ImportDoctrineFromXML(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("LUA_ScenEdit_ImportDoctrineFromXML");
		try
		{
			return LuaDoctrine.ScenEdit_ImportDoctrineFromXML(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_VP_ExportUnits(LuaTable luaTable_0, string string_0)
	{
		ClearLuaErrorCondition("VP_ExportUnits");
		try
		{
			return PrivateMethods.VP_ExportUnits(luaTable_0, string_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaTable LUA_ScenEdit_SplitUnit(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_SplitUnit");
		try
		{
			return PrivateMethods.ScenEdit_SplitUnit(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public LuaWrapper_ActiveUnit_SE LUA_ScenEdit_MergeUnits()
	{
		ClearLuaErrorCondition("ScenEdit_MergeUnits");
		try
		{
			return PrivateMethods.ScenEdit_MergeUnits(ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool LUA_ScenEdit_TransferMount(string string_0, string string_1, LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("ScenEdit_TransferMount");
		try
		{
			return PrivateMethods.ScenEdit_TransferMount(string_0, string_1, luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool? LUA_ScenEdit_UpdateRSetting(object object_1, bool? nullable_0 = null)
	{
		ClearLuaErrorCondition("ScenEdit_UpdateRSetting");
		try
		{
			return PrivateMethods.ScenEdit_UpdateRSetting(RuntimeHelpers.GetObjectValue(object_1), nullable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public float LUA_Tool_QueryRCS(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("LUA_Tool_QueryRCS");
		try
		{
			return PrivateMethods.Tool_QueryRCS(luaTable_0, ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool LUA_Tool_BuildBlankScenario(string string_0 = null)
	{
		ClearLuaErrorCondition("LUA_Tool_BuildBlankScenario");
		string string_ = null;
		try
		{
			if (string_0 != null)
			{
				string_ = ((from theDBR in DBOps.RegisteredDBs()
					where Operators.CompareString(theDBR.FileName, string_0, TextCompare: false) == 0 && theDBR.LocalCopyExists
					select theDBR).FirstOrDefault() ?? throw new Exception("Error in finding DB  (" + string_0 + ")")).Hash;
			}
			return PrivateMethods.Tool_BuildBlankScenario(string_);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (RunInteractive)
			{
				throw;
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public string Tool_DumpEvents()
	{
		ClearLuaErrorCondition("Tool_DumpEvents");
		string text = LuaEvent.ToXML_ViaStringBuilder(bool_0: true, ScenarioContext);
		if (!Directory.Exists(GameGeneral.ScenariosRootPath))
		{
			Directory.CreateDirectory(GameGeneral.ScenariosRootPath);
		}
		StreamWriter streamWriter = new StreamWriter(GameGeneral.ScenariosRootPath + "\\" + ScenarioContext.FileName + " events.xml");
		using (streamWriter)
		{
			streamWriter.Write(text);
			return text;
		}
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public bool Tool_EmulateNoConsole(bool bool_0 = true)
	{
		ClearLuaErrorCondition("Tool_EmulateNoConsole");
		RunInteractive = !bool_0;
		return RunInteractive;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public double Tool_Range(object object_1, object object_2, bool bool_0 = false)
	{
		ClearLuaErrorCondition("Tool_Range");
		double num = 0.0;
		Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
		Geopoint_Struct geopoint_Struct2 = default(Geopoint_Struct);
		geopoint_Struct.Latitude = 9999.0;
		geopoint_Struct2.Latitude = 9999.0;
		if (object_1 is LuaTable)
		{
			LuaTable val = (LuaTable)object_1;
			Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(val.GetEnumerator());
			double? num2 = LuaUtility.QueryLongitude(dictionary_);
			double? num3 = LuaUtility.QueryLatitude(dictionary_);
			float? num4 = LuaUtility.QueryAltitude(dictionary_);
			if (!num2.HasValue || !num2.HasValue)
			{
				throw new LuaError("From table object " + LuaUtility.LuaInterpret(val) + "需要经纬度。");
			}
			geopoint_Struct = (num4.HasValue ? new Geopoint_Struct(num2.Value, num3.Value, num4.Value) : new Geopoint_Struct(num2.Value, num3.Value));
		}
		if (object_2 is LuaTable)
		{
			LuaTable val2 = (LuaTable)object_2;
			Dictionary<string, object> dictionary_2 = LuaUtility.ToDictUpper(val2.GetEnumerator());
			double? num5 = LuaUtility.QueryLongitude(dictionary_2);
			double? num6 = LuaUtility.QueryLatitude(dictionary_2);
			float? num7 = LuaUtility.QueryAltitude(dictionary_2);
			if (!num5.HasValue | !num5.HasValue)
			{
				throw new LuaError("To table object " + LuaUtility.LuaInterpret(val2) + "需要经纬度。");
			}
			geopoint_Struct2 = (num7.HasValue ? new Geopoint_Struct(num5.Value, num6.Value, num7.Value) : new Geopoint_Struct(num5.Value, num6.Value));
		}
		if (object_1 is string)
		{
			string text = Conversions.ToString(object_1);
			ActiveUnit activeUnit = null;
			Contact contact = null;
			try
			{
				activeUnit = ScenarioContext.ActiveUnits[text];
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			if (activeUnit == null)
			{
				try
				{
					contact = PrivateMethods.ValidateContactBySceanrio(text, ScenarioContext);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
			}
			if (activeUnit == null && contact == null)
			{
				throw new LuaError("找不到guid" + text);
			}
			if (activeUnit == null)
			{
				if (contact != null)
				{
					double longitude = contact.GetLongitude();
					double latitude = contact.GetLatitude();
					float currentAltitude = contact.GetCurrentAltitude();
					geopoint_Struct = new Geopoint_Struct(longitude, latitude, currentAltitude);
				}
			}
			else
			{
				double longitude2 = activeUnit.GetLongitude();
				double latitude2 = activeUnit.GetLatitude();
				float currentAltitude2 = activeUnit.GetCurrentAltitude();
				geopoint_Struct = new Geopoint_Struct(longitude2, latitude2, currentAltitude2);
			}
		}
		if (object_2 is string)
		{
			string text2 = Conversions.ToString(object_2);
			ActiveUnit activeUnit2 = null;
			Contact contact2 = null;
			try
			{
				activeUnit2 = ScenarioContext.ActiveUnits[text2];
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				ProjectData.ClearProjectError();
			}
			if (activeUnit2 == null)
			{
				try
				{
					contact2 = PrivateMethods.ValidateContactBySceanrio(text2, ScenarioContext);
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					ProjectData.ClearProjectError();
				}
			}
			if (activeUnit2 == null && contact2 == null)
			{
				throw new LuaError("找不到guid" + text2);
			}
			if (activeUnit2 == null)
			{
				if (contact2 != null)
				{
					double longitude3 = contact2.GetLongitude();
					double latitude3 = contact2.GetLatitude();
					float currentAltitude3 = contact2.GetCurrentAltitude();
					geopoint_Struct2 = new Geopoint_Struct(longitude3, latitude3, currentAltitude3);
				}
			}
			else
			{
				double longitude4 = activeUnit2.GetLongitude();
				double latitude4 = activeUnit2.GetLatitude();
				float currentAltitude4 = activeUnit2.GetCurrentAltitude();
				geopoint_Struct2 = new Geopoint_Struct(longitude4, latitude4, currentAltitude4);
			}
		}
		if (geopoint_Struct.Latitude != 9999.0 && geopoint_Struct2.Latitude != 9999.0)
		{
			num = Geodesic_Haversine.Distance_Horiz_Approx_nm(geopoint_Struct.Latitude, geopoint_Struct.Longitude, geopoint_Struct2.Latitude, geopoint_Struct2.Longitude);
			if (bool_0)
			{
				float num8 = (float)((double)Math.Abs(geopoint_Struct.Altitude - geopoint_Struct2.Altitude) * 0.000539957);
				if (num8 == 0f)
				{
					return num;
				}
				return (float)Math.Sqrt(num * num + (double)(num8 * num8));
			}
			return num;
		}
		throw new LuaError("没有设置任何积分");
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public double Tool_Bearing(object object_1, object object_2)
	{
		ClearLuaErrorCondition("Tool_Bearing");
		GeoPoint geoPoint = null;
		GeoPoint geoPoint2 = null;
		if (object_1 is LuaTable)
		{
			LuaTable val = (LuaTable)object_1;
			Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(val.GetEnumerator());
			double? num = LuaUtility.QueryLongitude(dictionary_);
			double? num2 = LuaUtility.QueryLatitude(dictionary_);
			if (!num.HasValue | !num.HasValue)
			{
				throw new LuaError("From table object " + LuaUtility.LuaInterpret(val) + "需要经纬度。");
			}
			geoPoint = new GeoPoint(num.Value, num2.Value);
		}
		if (object_2 is LuaTable)
		{
			LuaTable val2 = (LuaTable)object_2;
			Dictionary<string, object> dictionary_2 = LuaUtility.ToDictUpper(val2.GetEnumerator());
			double? num3 = LuaUtility.QueryLongitude(dictionary_2);
			double? num4 = LuaUtility.QueryLatitude(dictionary_2);
			if (!num3.HasValue | !num3.HasValue)
			{
				throw new LuaError("To table object " + LuaUtility.LuaInterpret(val2) + "需要经纬度。");
			}
			geoPoint2 = new GeoPoint(num3.Value, num4.Value);
		}
		if (object_1 is string)
		{
			string text = Conversions.ToString(object_1);
			ActiveUnit activeUnit = null;
			Contact contact = null;
			try
			{
				activeUnit = ScenarioContext.ActiveUnits[text];
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			if (activeUnit == null)
			{
				try
				{
					contact = PrivateMethods.ValidateContactBySceanrio(text, ScenarioContext);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
			}
			if (activeUnit == null && contact == null)
			{
				throw new LuaError("找不到guid" + text);
			}
			if (activeUnit == null)
			{
				if (contact != null)
				{
					double longitude = contact.GetLongitude();
					double latitude = contact.GetLatitude();
					geoPoint = new GeoPoint(longitude, latitude);
				}
			}
			else
			{
				double longitude2 = activeUnit.GetLongitude();
				double latitude2 = activeUnit.GetLatitude();
				geoPoint = new GeoPoint(longitude2, latitude2);
			}
		}
		if (object_2 is string)
		{
			string text2 = Conversions.ToString(object_2);
			ActiveUnit activeUnit2 = null;
			Contact contact2 = null;
			try
			{
				activeUnit2 = ScenarioContext.ActiveUnits[text2];
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				ProjectData.ClearProjectError();
			}
			if (activeUnit2 == null)
			{
				try
				{
					contact2 = PrivateMethods.ValidateContactBySceanrio(text2, ScenarioContext);
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					ProjectData.ClearProjectError();
				}
			}
			if (activeUnit2 == null && contact2 == null)
			{
				throw new LuaError("找不到guid" + text2);
			}
			if (activeUnit2 == null)
			{
				if (contact2 != null)
				{
					double longitude3 = contact2.GetLongitude();
					double latitude3 = contact2.GetLatitude();
					geoPoint2 = new GeoPoint(longitude3, latitude3);
				}
			}
			else
			{
				double longitude4 = activeUnit2.GetLongitude();
				double latitude4 = activeUnit2.GetLatitude();
				geoPoint2 = new GeoPoint(longitude4, latitude4);
			}
		}
		if (geoPoint == null || geoPoint2 == null)
		{
			throw new LuaError("没有设置任何积分");
		}
		double result = Math2.PublishClass(geoPoint.Latitude, geoPoint.Longitude, geoPoint2.Latitude, geoPoint2.Longitude);
		Math2.VerifyClass(geoPoint.Latitude, geoPoint.Longitude, geoPoint2.Latitude, geoPoint2.Longitude);
		return result;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public bool Tool_UIwindow(string string_0, bool bool_0 = true)
	{
		ClearLuaErrorCondition("Tool_UIwindow");
		try
		{
			if ((string_0 == null) | (Operators.CompareString(string_0, "", TextCompare: false) == 0))
			{
				return false;
			}
			actionUIwindowEventHandler_0?.Invoke(string_0, bool_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
			return false;
		}
		return true;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public object Tool_LOS(LuaTable luaTable_0)
	{
		ClearLuaErrorCondition("Tool_LOS");
		float num = -1f;
		float num12 = -1f;
		object obj = 0;
		object obj2 = 0;
		byte b = 0;
		byte b2 = 0;
		ActiveUnit activeUnit = null;
		ActiveUnit activeUnit2 = null;
		bool flag = true;
		double? num13 = null;
		double? num14 = null;
		double? num15 = null;
		double? num16 = null;
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		try
		{
			if (dictionary.ContainsKey("MODE"))
			{
				b = Conversions.ToByte(dictionary["MODE"]);
			}
			if (dictionary.ContainsKey("HORIZON"))
			{
				b2 = Conversions.ToByte(dictionary["HORIZON"]);
			}
			if (dictionary.ContainsKey("USERANGELIMITS"))
			{
				flag = Conversions.ToBoolean(dictionary["USERANGELIMITS"]);
			}
			if (dictionary.ContainsKey("OBSERVER"))
			{
				obj = RuntimeHelpers.GetObjectValue(dictionary["OBSERVER"]);
			}
			if (dictionary.ContainsKey("TARGET"))
			{
				obj2 = RuntimeHelpers.GetObjectValue(dictionary["TARGET"]);
			}
			float? num17 = null;
			float? num18 = null;
			if (obj is float)
			{
				num = Conversions.ToSingle(obj);
			}
			else if (obj is long)
			{
				num = Conversions.ToSingle(obj);
			}
			else if (obj is double)
			{
				num = Conversions.ToSingle(obj);
			}
			else if (obj is LuaTable)
			{
				Dictionary<string, object> dictionary2 = LuaUtility.ToDictUpper(((LuaTable)obj).GetEnumerator());
				if (dictionary2.ContainsKey("ALTITUDE"))
				{
					string text = Conversions.ToString(dictionary2["ALTITUDE"]).ToUpper();
					num = (text.Contains("FT") ? (float.Parse(text.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture) * 0.3048f) : (text.Contains("M") ? float.Parse(text.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture) : float.Parse(text.Trim(), CultureInfo.InvariantCulture)));
				}
				else if (dictionary2.ContainsKey("GUID"))
				{
					string text2 = Conversions.ToString(dictionary2["GUID"]);
					activeUnit = ScenarioContext.ActiveUnits[text2];
					if (activeUnit != null)
					{
						switch (b2)
						{
						case 1:
							num = activeUnit.GetCurrentAltitude() + (float)activeUnit.GetMastHeight_Visual();
							break;
						case 0:
							num = activeUnit.GetCurrentAltitude() + (float)activeUnit.GetMastHeight_Radar();
							break;
						}
						num13 = activeUnit.GetLongitude();
						num14 = activeUnit.GetLatitude();
						if (flag && activeUnit.Sensors_Cached.Length != 0)
						{
							Sensor[] sensors_Cached = activeUnit.Sensors_Cached;
							Sensor[] array = sensors_Cached;
							foreach (Sensor sensor in array)
							{
								num17 = (num17.HasValue ? Math.Max(num17.Value, sensor.maxRange) : Math.Max(0f, sensor.maxRange));
								num18 = (num18.HasValue ? Math.Max(num18.Value, sensor.minRange) : Math.Max(0f, sensor.minRange));
							}
						}
					}
				}
				else if (dictionary2.ContainsKey("LOCATION"))
				{
					LuaTable val = (LuaTable)dictionary2["LOCATION"];
					Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(val.GetEnumerator());
					num13 = LuaUtility.QueryLongitude(dictionary_);
					num14 = LuaUtility.QueryLatitude(dictionary_);
					if (!num13.HasValue || !num13.HasValue)
					{
						throw new LuaError("Observer table object " + LuaUtility.LuaInterpret(val) + "需要经纬度。");
					}
				}
			}
			else if (obj is string)
			{
				string text3 = Conversions.ToString(obj).ToUpper();
				if (text3.Contains("FT"))
				{
					num = float.Parse(text3.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture) * 0.3048f;
				}
				else if (text3.Contains("M"))
				{
					num = float.Parse(text3.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture);
				}
			}
			if (obj2 is float)
			{
				num12 = Conversions.ToSingle(obj2);
			}
			else if (obj2 is long)
			{
				num12 = Conversions.ToSingle(obj2);
			}
			else if (obj2 is double)
			{
				num12 = Conversions.ToSingle(obj2);
			}
			else if (obj2 is LuaTable)
			{
				Dictionary<string, object> dictionary3 = LuaUtility.ToDictUpper(((LuaTable)obj2).GetEnumerator());
				if (dictionary3.ContainsKey("ALTITUDE"))
				{
					string text4 = Conversions.ToString(dictionary3["ALTITUDE"]).ToUpper();
					num12 = (text4.Contains("FT") ? (float.Parse(text4.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture) * 0.3048f) : (text4.Contains("M") ? float.Parse(text4.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture) : float.Parse(text4.Trim(), CultureInfo.InvariantCulture)));
				}
				else if (dictionary3.ContainsKey("GUID"))
				{
					string text5 = Conversions.ToString(dictionary3["GUID"]);
					if (ScenarioContext.ActiveUnits.ContainsKey(text5))
					{
						activeUnit2 = ScenarioContext.ActiveUnits[text5];
						num12 = activeUnit2.CurrentAltitude_AGL;
						num16 = activeUnit2.GetLatitude();
						num15 = activeUnit2.GetLongitude();
					}
					else if (activeUnit != null)
					{
						Contact contact = PrivateMethods.ValidateContactBySide(text5, activeUnit.GetUnitSide());
						if (contact != null)
						{
							activeUnit2 = ScenarioContext.ActiveUnits[contact.ActualUnit.ObjectID];
							num12 = contact.CurrentAltitude_AGL;
							num16 = contact.GetLatitude();
							num15 = contact.GetLongitude();
						}
					}
				}
				else if (dictionary3.ContainsKey("LOCATION"))
				{
					LuaTable val2 = (LuaTable)dictionary3["LOCATION"];
					Dictionary<string, object> dictionary_2 = LuaUtility.ToDictUpper(val2.GetEnumerator());
					num15 = LuaUtility.QueryLongitude(dictionary_2);
					num16 = LuaUtility.QueryLatitude(dictionary_2);
					if (!num15.HasValue || !num15.HasValue)
					{
						throw new LuaError("Observer table object " + LuaUtility.LuaInterpret(val2) + "需要经纬度。");
					}
				}
			}
			else if (obj2 is string)
			{
				string text6 = Conversions.ToString(obj2).ToUpper();
				if (text6.Contains("FT"))
				{
					num12 = float.Parse(text6.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture) * 0.3048f;
				}
				else if (text6.Contains("M"))
				{
					num12 = float.Parse(text6.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture);
				}
			}
			if (!(num < 0f) && num12 >= 0f)
			{
				double num19 = 0.0;
				switch (b2)
				{
				case 0:
					switch (b)
					{
					case 1:
						return Scenario.DetermineLOS(num14.Value, num13.Value, num, num16.Value, num15.Value, num12, bool_0: false, activeUnit.ParentScen);
					case 0:
						num19 = Horizon.CountClass(num, num12);
						if (num17.HasValue)
						{
							double num8 = num19;
							double? num9 = num17;
							if ((num9.HasValue ? new bool?(num8 > num9.GetValueOrDefault()) : null).GetValueOrDefault())
							{
								num19 = num17.Value;
							}
						}
						if (num18.HasValue)
						{
							double num10 = num19;
							double? num11 = num18;
							if ((num11.HasValue ? new bool?(num10 < num11.GetValueOrDefault()) : null).GetValueOrDefault())
							{
								num19 = 0.0;
							}
						}
						break;
					}
					break;
				case 1:
					num19 = Horizon.RevertInvocation(num, num12);
					if (num17.HasValue)
					{
						double num6 = num19;
						double? num7 = num17;
						if ((num7.HasValue ? new bool?(num6 > num7.GetValueOrDefault()) : null).GetValueOrDefault())
						{
							num19 = num17.Value;
						}
					}
					break;
				case 2:
					switch (b)
					{
					case 1:
						return Scenario.DetermineLOS(num14.Value, num13.Value, num, num16.Value, num15.Value, num12, bool_0: false, activeUnit.ParentScen);
					case 0:
						num19 = Horizon.CustomizeClass(num, num12);
						if (num17.HasValue)
						{
							double num2 = num19;
							double? num3 = num17;
							if ((num3.HasValue ? new bool?(num2 > num3.GetValueOrDefault()) : null).GetValueOrDefault())
							{
								num19 = num17.Value;
							}
						}
						if (num18.HasValue)
						{
							double num4 = num19;
							double? num5 = num18;
							if ((num5.HasValue ? new bool?(num4 < num5.GetValueOrDefault()) : null).GetValueOrDefault())
							{
								num19 = 0.0;
							}
						}
						break;
					}
					break;
				}
				return num19;
			}
			return null;
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
		return null;
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public string Tool_LOS_Points(LuaTable luaTable_0, LuaTable luaTable_1, byte byte_0)
	{
		ClearLuaErrorCondition("Tool_LOS_Points");
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		double? num = LuaUtility.QueryLongitude(dictionary_);
		if (num.HasValue)
		{
			double? num2 = LuaUtility.QueryLatitude(dictionary_);
			if (num2.HasValue)
			{
				float? num3 = LuaUtility.QueryAltitude(dictionary_);
				if (num3.HasValue)
				{
					Dictionary<string, object> dictionary_2 = LuaUtility.ToDictUpper(luaTable_1.GetEnumerator());
					double? num4 = LuaUtility.QueryLongitude(dictionary_2);
					if (num4.HasValue)
					{
						double? num5 = LuaUtility.QueryLatitude(dictionary_2);
						if (num5.HasValue)
						{
							float? num6 = LuaUtility.QueryAltitude(dictionary_2);
							if (num6.HasValue)
							{
								float num7 = Math2.VerifyClass(num2.Value, num.Value, num5.Value, num4.Value);
								try
								{
									float num8 = 0f;
									switch (byte_0)
									{
									case 0:
										num8 = Horizon.CountClass(num3.Value, num6.Value);
										break;
									case 1:
										num8 = Horizon.RevertInvocation(num3.Value, num6.Value);
										break;
									case 2:
										num8 = Horizon.CustomizeClass(num3.Value, num6.Value);
										break;
									}
									if (num8 < num7)
									{
										return "FAIL_BEYONDHORIZON";
									}
									if (Scenario.DetermineLOS(num2.Value, num.Value, num3.Value, num5.Value, num4.Value, num6.Value, bool_0: false, ScenarioContext))
									{
										return "SUCCESS";
									}
									return "FAIL_TERRAINBLOCK";
								}
								catch (Exception ex)
								{
									ProjectData.SetProjectError(ex);
									Exception ex2 = ex;
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									throw new LuaError("错误：" + ex2.Message);
								}
							}
							throw new LuaError("Error in determining the target altitude!");
						}
						throw new LuaError("Error in determining the target latitude!");
					}
					throw new LuaError("Error in determining the target longitude!");
				}
				throw new LuaError("Error in determining the source altitude!");
			}
			throw new LuaError("Error in determining the source latitude!");
		}
		throw new LuaError("Error in determining the source longitude!");
	}

	private void SetUpAliases()
	{
		AliasString.Append("SE_GetUnit=ScenEdit_GetUnit\r\nSE_SetUnit=ScenEdit_SetUnit");
	}

	public ActiveUnit MakeActiveUnitOfUnguidedWeapon(UnguidedWeapon unguidedWeapon_0)
	{
		Weapon weapon = new Weapon(ref ScenarioContext);
		weapon.ObjectID = unguidedWeapon_0.ObjectID;
		weapon.UnitClass = unguidedWeapon_0.UnitClass;
		weapon.SetUnitSide(bool_0: false, unguidedWeapon_0.GetUnitSide());
		weapon.Type = unguidedWeapon_0.Type;
		weapon.DBID = Conversions.ToInteger(Strings.Split(unguidedWeapon_0.AnnexAndDBID, "_")[1]);
		weapon.Name = unguidedWeapon_0.Name;
		weapon.SetLatitude(null, unguidedWeapon_0.GetLatitude());
		weapon.SetLongitude(null, unguidedWeapon_0.GetLongitude());
		weapon.SetCurrentAltitude(bool_0: false, unguidedWeapon_0.GetCurrentAltitude());
		return weapon;
	}
}
