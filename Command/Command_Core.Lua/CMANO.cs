using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

public sealed class CMANO
{
	public sealed class LuaFunctionArg
	{
		internal string name;

		internal LuaFunction func;

		internal List<object> args;

		public LuaFunctionArg(string string_0, LuaFunction luaFunction_0, List<object> list_0)
		{
			args = new List<object>();
			func = luaFunction_0;
			args = list_0;
			name = string_0;
		}
	}

	public sealed class LuaTriggers
	{
		internal LuaTriggers()
		{
		}

		public static void ClearOldLuaFunction(string string_0)
		{
			LuaFunction val = null;
			LuaTable val2 = null;
			try
			{
				object objectValue = RuntimeHelpers.GetObjectValue(LuaSandBox.Singleton().SB_Lua()[string_0]);
				if (objectValue is LuaFunction)
				{
					try
					{
						val = LuaSandBox.Singleton().SB_Lua().GetFunction(string_0);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
				else if (objectValue is LuaTable)
				{
					try
					{
						val2 = LuaSandBox.Singleton().SB_Lua().GetTable(string_0);
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						_ = Debugger.IsAttached;
						ProjectData.ClearProjectError();
					}
				}
				if (val != null)
				{
					LuaSandBox.Singleton().SB_Lua().DoString(string_0 + "=nil");
				}
				if (val2 != null)
				{
					LuaSandBox.Singleton().SB_Lua().DoString(string_0 + "={}");
				}
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				ProjectData.ClearProjectError();
			}
		}

		public static void AddOpsHandler()
		{
			Aircraft_AirOps.AirOpsStatusChange -= OnStatusChangeEvent;
			ActiveUnit_DockingOps.DockingOpsStatusChange -= OnStatusChangeEvent;
			Aircraft_AirOps.AirOpsStatusChange += OnStatusChangeEvent;
			ActiveUnit_DockingOps.DockingOpsStatusChange += OnStatusChangeEvent;
		}

		public static void OnStatusChangeEvent(ActiveUnit activeUnit_0, object object_0)
		{
			if (scenario_0 == null)
			{
				scenario_0 = activeUnit_0.ParentScen;
			}
			List<EventTrigger> list = new List<EventTrigger>();
			foreach (EventTrigger value in scenario_0.EventTriggers.Values)
			{
				if (value.Type == EventTrigger.EventTriggerType.UnitBaseStatus && ((EventTrigger_UnitBaseStatus)value).GetIsFulfilled(activeUnit_0, RuntimeHelpers.GetObjectValue(object_0)))
				{
					list.Add(value);
				}
			}
			if (list.Count > 0)
			{
				scenario_0.FireEvents(list);
			}
		}
	}

	private static Scenario scenario_0;

	internal static List<LuaFunctionArg> LuaFunctionList;

	private string string_0;

	private static List<Tuple<ActiveUnit, object>> list_1;

	public static LuaTriggers triggers;

	private static object object_0;

	public string test
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	static CMANO()
	{
		LuaFunctionList = new List<LuaFunctionArg>();
		list_1 = new List<Tuple<ActiveUnit, object>>();
		triggers = new LuaTriggers();
		object_0 = RuntimeHelpers.GetObjectValue(new object());
	}

	public static void StatusChanged(ActiveUnit activeUnit_0, object object_1)
	{
		list_1.Add(new Tuple<ActiveUnit, object>(activeUnit_0, RuntimeHelpers.GetObjectValue(object_1)));
	}

	public static void HandleScenarioChanging()
	{
		LuaFunctionList.Clear();
	}

	public static object[] CallFunctionSynchronously(LuaFunction luaFunction_0, object[] object_1)
	{
		try
		{
			object obj = object_0;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				return luaFunction_0.Call(object_1);
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_ = Debugger.IsAttached;
			throw;
		}
	}

	internal CMANO(Scenario scenario_1)
	{
		scenario_0 = scenario_1;
	}

	public void AddLuaFuction(string string_1, LuaTable luaTable_0)
	{
		LuaFunction function = LuaSandBox.Singleton().SB_Lua().GetFunction(string_1);
		List<object> list_ = LuaUtility.ToArray(luaTable_0.GetEnumerator());
		if (function == null)
		{
			return;
		}
		LuaFunctionArg luaFunctionArg = new LuaFunctionArg(string_1, function, list_);
		foreach (LuaFunctionArg luaFunction in LuaFunctionList)
		{
			if (Operators.CompareString(luaFunction.name, luaFunctionArg.name, TextCompare: false) == 0 && !luaFunction.args.Except(luaFunctionArg.args).Union(luaFunction.args.Except(luaFunctionArg.args)).Any())
			{
				LuaFunctionList.Remove(luaFunction);
				break;
			}
		}
		if (luaFunctionArg != null)
		{
			LuaFunctionList.Add(luaFunctionArg);
		}
	}

	public void RemoveLuaFuction(string string_1, LuaTable luaTable_0 = null)
	{
		if ((string_1 == null) | (Operators.CompareString(string_1, "", TextCompare: false) == 0))
		{
			LuaFunctionList.Clear();
			return;
		}
		LuaFunction function = LuaSandBox.Singleton().SB_Lua().GetFunction(string_1);
		if (function == null)
		{
			return;
		}
		List<object> list_ = LuaUtility.ToArray(luaTable_0.GetEnumerator());
		LuaFunctionArg luaFunctionArg = new LuaFunctionArg(string_1, function, list_);
		foreach (LuaFunctionArg luaFunction in LuaFunctionList)
		{
			if (Operators.CompareString(luaFunction.name, luaFunctionArg.name, TextCompare: false) == 0 && !luaFunction.args.Except(luaFunctionArg.args).Union(luaFunction.args.Except(luaFunctionArg.args)).Any())
			{
				LuaFunctionList.Remove(luaFunction);
				luaFunctionArg = null;
				break;
			}
		}
		if (luaFunctionArg == null)
		{
			return;
		}
		foreach (LuaFunctionArg luaFunction2 in LuaFunctionList)
		{
			if (Operators.CompareString(luaFunction2.name, luaFunctionArg.name, TextCompare: false) == 0)
			{
				LuaFunctionList.Remove(luaFunction2);
			}
		}
	}

	internal string NewTest()
	{
		test = "abcdf";
		return test;
	}

	private static UnitFilterObject smethod_0(ref Dictionary<string, object> dictionary_0, Scenario scenario_1)
	{
		try
		{
			ActiveUnit activeUnit = null;
			Side side = null;
			UnitFilterObject unitFilterObject = new UnitFilterObject();
			foreach (string key in dictionary_0.Keys)
			{
				string text = dictionary_0[key].ToString();
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
						throw new LuaError("TargetFilter.Type出错！", "CMANO.CreateTargetTrigger");
					}
					break;
				}
				case "TARGETSUBTYPE":
					unitFilterObject.TargetSubType = Conversions.ToInteger(text);
					break;
				case "TARGETSIDE":
					side = PrivateMethods.ValidateSide(text, scenario_1);
					if (side == null)
					{
						if (Operators.CompareString(text.ToUpper(), "ANY", TextCompare: false) == 0)
						{
							unitFilterObject.TargetSide = "";
							break;
						}
						if (Operators.CompareString(text.ToUpper(), "PLAYERSIDE", TextCompare: false) != 0)
						{
							throw new LuaError("TargetFilter.Side出错！", "CMANO.CreateTargetTrigger");
						}
						unitFilterObject.TargetSide = scenario_1.GetCurrentSide().ObjectID;
					}
					else
					{
						unitFilterObject.TargetSide = side.ObjectID;
					}
					break;
				case "SPECIFICUNITCLASS":
					unitFilterObject.SpecificUnitClass = Conversions.ToInteger(text);
					break;
				case "SPECIFICUNIT":
					activeUnit = PrivateMethods.smethod_0(text, scenario_1);
					if (activeUnit != null)
					{
						unitFilterObject.SpecificUnitID = activeUnit.ObjectID;
						break;
					}
					throw new LuaError("TargetFilter.Unit出错！", "CMANO.CreateTargetTrigger");
				}
			}
			if (string.IsNullOrEmpty(unitFilterObject.SpecificUnitID))
			{
				if (unitFilterObject.TargetSide == null)
				{
					throw new LuaError("TargetFilter.TargetSide出错！", "CMANO.CreateTargetTrigger");
				}
				if (unitFilterObject.SpecificUnitClass == 0)
				{
					if (unitFilterObject.TargetSubType != 0 && unitFilterObject.TargetType == GlobalVariables.ActiveUnitType.None)
					{
						throw new LuaError("TargetFilter.SubType出错！", "CMANO.CreateTargetTrigger");
					}
				}
				else
				{
					switch (unitFilterObject.TargetType)
					{
					case GlobalVariables.ActiveUnitType.Aircraft:
						unitFilterObject.TargetSubType = DBFunctions.GetAircraftType_Int(ref scenario_1, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Ship:
						unitFilterObject.TargetSubType = DBFunctions.GetShipType_Int(ref scenario_1, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Submarine:
						unitFilterObject.TargetSubType = DBFunctions.GetSubmarineType_Int(ref scenario_1, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Facility:
						unitFilterObject.TargetSubType = DBFunctions.GetFacilityType_Int(ref scenario_1, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Weapon:
						unitFilterObject.TargetSubType = DBFunctions.GetWeaponType_Int(ref scenario_1, unitFilterObject.SpecificUnitClass);
						break;
					case GlobalVariables.ActiveUnitType.Satellite:
						unitFilterObject.TargetSubType = DBFunctions.GetSatelliteType_Int(ref scenario_1, unitFilterObject.SpecificUnitClass);
						break;
					}
					if (unitFilterObject.TargetSubType == 0 || unitFilterObject.TargetType == GlobalVariables.ActiveUnitType.None)
					{
						throw new LuaError("TargetFilter.Class中的错误！", "CMANO.CreateTargetTrigger");
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return null;
	}
}
