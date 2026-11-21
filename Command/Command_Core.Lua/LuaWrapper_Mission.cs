using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPruneType]
[DoNotObfuscateType]
[DoNotPrune]
public sealed class LuaWrapper_Mission
{
	private Mission myMission;

	private Scenario ScenarioContext;

	private Side mySide;

	[DoNotPrune]
	public int PriorityWeight
	{
		get
		{
			return myMission.PriorityWeight;
		}
		set
		{
			myMission.PriorityWeight = value;
		}
	}

	[DoNotPrune]
	public string OperationName
	{
		get
		{
			return myMission.OperationName;
		}
		set
		{
			myMission.OperationName = value;
		}
	}

	[DoNotPrune]
	public float Completion
	{
		get
		{
			return myMission.Completion;
		}
		set
		{
			myMission.Completion = value;
		}
	}

	[DoNotPrune]
	public MissionPhase _Phase
	{
		get
		{
			return myMission.GetPhase(ScenarioContext, mySide);
		}
		set
		{
			myMission.SetPhase(ScenarioContext, mySide, value);
		}
	}

	[DoNotPrune]
	public int MissionStartTrigger_Time
	{
		get
		{
			return myMission.MissionStartTrigger_Time;
		}
		set
		{
			myMission.MissionStartTrigger_Time = value;
		}
	}

	[DoNotPrune]
	public bool MissionStartTrigger_Time_Enabled
	{
		get
		{
			return myMission.MissionStartTrigger_Time_Enabled;
		}
		set
		{
			myMission.MissionStartTrigger_Time_Enabled = value;
		}
	}

	[DoNotPrune]
	public bool MissionStartTrigger_Time_LastResult => myMission.MissionStartTrigger_Time_LastResult;

	[DoNotPrune]
	public bool MissionStartTrigger_Time_Operator
	{
		get
		{
			return myMission.MissionStartTrigger_Time_Operator;
		}
		set
		{
			myMission.MissionStartTrigger_Time_Operator = value;
		}
	}

	[DoNotPrune]
	public LuaTable MissionStartTrigger_MissionCompleted
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			new List<Mission>();
			List<Mission> list = myMission.MissionStartTrigger_MissionCompleted.Values.ToList();
			int num = 1;
			foreach (Mission item in list)
			{
				val[num] = item.ObjectID;
				num++;
			}
			return val;
		}
		set
		{
			List<object> list = LuaUtility.ToArray(value.GetEnumerator());
			myMission.MissionStartTrigger_MissionCompleted.Clear();
			foreach (object item in list)
			{
				string text = Conversions.ToString(RuntimeHelpers.GetObjectValue(item));
				Mission mission = LuaMission.ValidateMissionBySceanrio(text, ScenarioContext);
				if (mission != null && Operators.CompareString(mission.ObjectID, text, TextCompare: false) == 0 && !myMission.MissionStartTrigger_MissionCompleted.ContainsKey(mission))
				{
					myMission.MissionStartTrigger_MissionCompleted.Add(mission, mission);
				}
			}
		}
	}

	[DoNotPrune]
	public bool MissionStartTrigger_MissionCompleted_Enabled
	{
		get
		{
			return myMission.MissionStartTrigger_MissionCompleted_Enabled;
		}
		set
		{
			myMission.MissionStartTrigger_MissionCompleted_Enabled = value;
		}
	}

	[DoNotPrune]
	public bool MissionStartTrigger_MissionCompleted_LastResult => myMission.MissionStartTrigger_MissionCompleted_LastResult;

	[DoNotPrune]
	public bool MissionStartTrigger_MissionCompleted_Operator
	{
		get
		{
			return myMission.MissionStartTrigger_MissionCompleted_Operator;
		}
		set
		{
			myMission.MissionStartTrigger_MissionCompleted_Operator = value;
		}
	}

	[DoNotPrune]
	public string MissionStartTrigger_LUADescription
	{
		get
		{
			return myMission.MissionStartTrigger_LUADescription;
		}
		set
		{
			myMission.MissionStartTrigger_LUADescription = value;
		}
	}

	[DoNotPrune]
	public string MissionStartTrigger_LUA
	{
		get
		{
			return myMission.MissionStartTrigger_LUA;
		}
		set
		{
			myMission.MissionStartTrigger_LUA = value;
		}
	}

	[DoNotPrune]
	public bool MissionStartTrigger_LUA_Enabled
	{
		get
		{
			return myMission.MissionStartTrigger_LUA_Enabled;
		}
		set
		{
			myMission.MissionStartTrigger_LUA_Enabled = value;
		}
	}

	[DoNotPrune]
	public bool MissionStartTrigger_LUA_LastResult => myMission.MissionStartTrigger_LUA_LastResult;

	[DoNotPrune]
	public bool MissionStartTrigger_LUA_Operator
	{
		get
		{
			return myMission.MissionStartTrigger_LUA_Operator;
		}
		set
		{
			myMission.MissionStartTrigger_LUA_Operator = value;
		}
	}

	[DoNotPrune]
	public int MissionCompletedTrigger_ElapsedTime
	{
		get
		{
			return (int)Math.Round(myMission.MissionCompletedTrigger_ElapsedTime);
		}
		set
		{
			myMission.MissionCompletedTrigger_ElapsedTime = value;
		}
	}

	[DoNotPrune]
	public int MissionCompletedTrigger_ElapsedTime_Current
	{
		get
		{
			return (int)Math.Round(myMission.MissionCompletedTrigger_ElapsedTime_Current);
		}
		set
		{
			myMission.MissionCompletedTrigger_ElapsedTime_Current = value;
		}
	}

	[DoNotPrune]
	public bool MissionCompletedTrigger_ElapsedTime_Enabled
	{
		get
		{
			return myMission.MissionCompletedTrigger_ElapsedTime_Enabled;
		}
		set
		{
			myMission.MissionCompletedTrigger_ElapsedTime_Enabled = value;
		}
	}

	[DoNotPrune]
	public bool MissionCompletedTrigger_ElapsedTime_LastResult => myMission.MissionCompletedTrigger_ElapsedTime_LastResult;

	[DoNotPrune]
	public bool MissionCompletedTrigger_ElapsedTime_Operator
	{
		get
		{
			return myMission.MissionCompletedTrigger_ElapsedTime_Operator;
		}
		set
		{
			myMission.MissionCompletedTrigger_ElapsedTime_Operator = value;
		}
	}

	[DoNotPrune]
	public string MissionCompletedTrigger_LUADescription
	{
		get
		{
			return myMission.MissionCompletedTrigger_LUADescription;
		}
		set
		{
			myMission.MissionCompletedTrigger_LUADescription = value;
		}
	}

	[DoNotPrune]
	public string MissionCompletedTrigger_LUA
	{
		get
		{
			return myMission.MissionCompletedTrigger_LUA;
		}
		set
		{
			myMission.MissionCompletedTrigger_LUA = value;
		}
	}

	[DoNotPrune]
	public bool MissionCompletedTrigger_LUA_Enabled
	{
		get
		{
			return myMission.MissionCompletedTrigger_LUA_Enabled;
		}
		set
		{
			myMission.MissionCompletedTrigger_LUA_Enabled = value;
		}
	}

	[DoNotPrune]
	public bool MissionCompletedTrigger_LUA_LastResult => myMission.MissionCompletedTrigger_LUA_LastResult;

	[DoNotPrune]
	public bool MissionCompletedTrigger_LUA_Operator
	{
		get
		{
			return myMission.MissionCompletedTrigger_LUA_Operator;
		}
		set
		{
			myMission.MissionCompletedTrigger_LUA_Operator = value;
		}
	}

	[DoNotPrune]
	public int EstimatedExecutionTime => myMission.EstimatedExecutionTime;

	public object fields
	{
		get
		{
			Type obj = GetType();
			int num = 0;
			PropertyInfo[] properties = obj.GetProperties();
			MethodInfo[] methods = obj.GetMethods();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			PropertyInfo[] array = properties;
			PropertyInfo[] array3 = array;
			MethodInfo[] array2;
			foreach (PropertyInfo propertyInfo in array3)
			{
				if (propertyInfo.Name.StartsWith("__") || propertyInfo.Name.StartsWith("fields"))
				{
					continue;
				}
				string text = "";
				bool flag = false;
				if (propertyInfo.MemberType == MemberTypes.Method)
				{
					text = ":";
				}
				else if (propertyInfo.MemberType == MemberTypes.Property)
				{
					text = ".";
				}
				array2 = methods;
				MethodInfo[] array4 = array2;
				foreach (MethodInfo obj2 in array4)
				{
					string right = "set_" + propertyInfo.Name;
					if (Operators.CompareString(obj2.Name, right, TextCompare: false) == 0)
					{
						flag = true;
					}
				}
				num++;
				dictionary.Add("property_" + num, text + propertyInfo.Name + " , " + propertyInfo.PropertyType.Name + " , " + flag + " , " + propertyInfo.CanRead);
			}
			num = 0;
			array2 = methods;
			MethodInfo[] array5 = array2;
			foreach (MethodInfo methodInfo in array5)
			{
				if (!methodInfo.Name.StartsWith("get_") && !methodInfo.Name.StartsWith("set_") && !methodInfo.Name.StartsWith("ToString") && !methodInfo.IsHideBySig)
				{
					string text2 = "";
					if (methodInfo.MemberType == MemberTypes.Method)
					{
						text2 = ":";
					}
					else if (methodInfo.MemberType == MemberTypes.Property)
					{
						text2 = ".";
					}
					num++;
					dictionary.Add("method_" + num, text2 + methodInfo.Name + " , " + methodInfo.ReturnType.ToString());
				}
			}
			if (dictionary.Count == 0)
			{
				return null;
			}
			LuaUtility.FromDict(dictionary, val);
			return val;
		}
	}

	[DoNotPrune]
	public LuaWrapper_Doctrine doctrine
	{
		get
		{
			if (myMission.Doctrine == null)
			{
				return null;
			}
			return new LuaWrapper_Doctrine(myMission.Doctrine, ScenarioContext);
		}
	}

	[DoNotPrune]
	public object __obj => myMission;

	[DoNotPrune]
	public string guid => myMission.ObjectID;

	[DoNotPrune]
	public string name
	{
		get
		{
			return myMission.Name;
		}
		set
		{
			myMission.Name = value;
		}
	}

	[DoNotPrune]
	public object isactive
	{
		get
		{
			return myMission.GetStatus(ScenarioContext) == Mission.MissionStatus.Active;
		}
		set
		{
			try
			{
				bool? flag = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value));
				if (flag.HasValue)
				{
					bool? flag2 = flag;
					flag2 = flag2;
					if (flag2.GetValueOrDefault())
					{
						myMission.SetStatus(ScenarioContext, Mission.MissionStatus.Active);
					}
					else
					{
						myMission.SetStatus(ScenarioContext, Mission.MissionStatus.Inactive);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				throw new LuaError(ex.Message);
			}
		}
	}

	[DoNotPrune]
	public string side => mySide.Name;

	[DoNotPrune]
	public string endtime
	{
		get
		{
			return myMission.EndTime.ToString();
		}
		set
		{
			try
			{
				if (value.Length <= 0)
				{
					myMission.EndTime_Set(null, ScenarioContext);
				}
				else
				{
					myMission.EndTime_Set(Conversions.ToDate(value), ScenarioContext);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public string starttime
	{
		get
		{
			return myMission.StartTime.ToString();
		}
		set
		{
			try
			{
				if (value.Length <= 0)
				{
					myMission.StartTime_Set(null, ScenarioContext);
				}
				else
				{
					myMission.StartTime_Set(Conversions.ToDate(value), ScenarioContext);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public Mission._MissionClass type => myMission.MissionClass;

	[DoNotPrune]
	public object subtype
	{
		get
		{
			return myMission.GetDescriptionString(ScenarioContext);
		}
		set
		{
			throw new LuaError("无法设置此属性。请使用ScenEdit_Set。");
		}
	}

	[DoNotPrune]
	public object SISH
	{
		get
		{
			return myMission.ScrubIfSideIsHuman;
		}
		set
		{
			myMission.ScrubIfSideIsHuman = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value)).Value;
		}
	}

	[DoNotPrune]
	public object __mission => myMission;

	[DoNotPrune]
	public LuaTable unitlist
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			new List<ActiveUnit>();
			List<ActiveUnit> list = Module_Mission.AssetTokenizer(myMission, ScenarioContext);
			int num = 1;
			foreach (ActiveUnit item in list)
			{
				val[num] = item.ObjectID;
				num++;
			}
			return val;
		}
		set
		{
			throw new LuaError("无法设置此属性。请使用ScenEdit_Set。");
		}
	}

	[DoNotPrune]
	public LuaTable targetlist
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			new HashSet<Module_Unit.Unit>();
			if (myMission.MissionClass == Mission._MissionClass.Strike)
			{
				HashSet<Module_Unit.Unit> specificTargets = ((Strike)myMission).SpecificTargets;
				int num = 1;
				foreach (Module_Unit.Unit item in specificTargets)
				{
					val[num] = item.ObjectID;
					num++;
				}
				return val;
			}
			return val;
		}
		set
		{
			throw new LuaError("无法设置此属性。请使用ScenEdit_Set。");
		}
	}

	[DoNotPrune]
	public LuaTable aar
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment = null;
			useUnderwayRefuelAndReplenishment = myMission.Doctrine.GetUseReplenishment(ScenarioContext, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			if (useUnderwayRefuelAndReplenishment.HasValue)
			{
				val["Doctrine_UseReplenishment"] = useUnderwayRefuelAndReplenishment.ToString();
			}
			string[] mission_Tanker = LuaMission.Mission_Tanker;
			string[] array = mission_Tanker;
			foreach (string text in array)
			{
				switch (text)
				{
				case "TankerMaxDistance_Airborne":
					if (myMission.TankerMaxDistance_Airborne < 1000)
					{
						val[text] = myMission.TankerMaxDistance_Airborne;
					}
					else
					{
						val[text] = "internal";
					}
					break;
				case "TankerMinNumber_Airborne":
					if (myMission.TankerUsage == Mission.TankerMethod.Mission)
					{
						val[text] = myMission.TankerMinNumber_Airborne;
					}
					break;
				case "TankerMinNumber_Station":
					if (myMission.TankerUsage == Mission.TankerMethod.Mission)
					{
						val[text] = myMission.TankerMinNumber_Station;
					}
					break;
				case "TankerMinNumber_Total":
					if (myMission.TankerUsage == Mission.TankerMethod.Mission)
					{
						val[text] = myMission.TankerMinNumber_Total;
					}
					break;
				case "LaunchMissionWithoutTankersInPlace":
					if (myMission.TankerUsage == Mission.TankerMethod.Mission)
					{
						val[text] = myMission.LaunchMissionWithoutTankersInPlace;
					}
					break;
				case "TankerMissionList":
				{
					if (myMission.TankerUsage != Mission.TankerMethod.Mission)
					{
						break;
					}
					LuaTable val2 = LuaSandBox.Singleton().CreateTable();
					foreach (Mission tankerMission in myMission.TankerMissions)
					{
						val2[1] = tankerMission.Name;
					}
					val[text] = val2;
					break;
				}
				case "FuelQtyToStartLookingForTanker_Airborne":
					val[text] = myMission.FuelQtyToStartLookingForTanker_Airborne;
					break;
				case "MaxReceiversInQueuePerTanker_Airborne":
					val[text] = myMission.MaxReceiversInQueuePerTanker_Airborne;
					break;
				case "TankerFollowsReceivers":
					val[text] = myMission.TankerFollowsReceivers;
					break;
				case "TankerUsage":
					val[text] = myMission.TankerUsage.ToString();
					break;
				}
			}
			return val;
		}
		set
		{
			throw new LuaError("无法设置此属性。请使用ScenEdit_SetMission（）。");
		}
	}

	[DoNotPrune]
	public LuaTable ferrymission
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (myMission.MissionClass == Mission._MissionClass.Ferry)
			{
				FerryMission ferryMission = (FerryMission)myMission;
				string[] mission_Ferry = LuaMission.Mission_Ferry;
				string[] array = mission_Ferry;
				foreach (string text in array)
				{
					switch (text)
					{
					case "FerryTerrainFollowingAircraft":
						ferryMission.FerryTerrainFollowing_Aircraft.ToString();
						break;
					case "FerryBehavior":
						val[text] = ferryMission.Behavior.ToString();
						break;
					case "UseFlightSize":
						val[text] = ferryMission.UseFlightSizeHardLimit.ToString();
						break;
					case "FerryThrottleAircraft":
						val[text] = ferryMission.FerryThrottle_Aircraft.ToString();
						break;
					case "FlightSize":
						val[text] = ferryMission.FlightSize.ToString();
						break;
					case "FerryAltitudeAircraft":
						val[text] = ferryMission.FerryAltitude_Aircraft.ToString();
						break;
					case "MinAircraftReq":
						val[text] = ferryMission.MinimumNumberOfAircraft.ToString();
						break;
					}
				}
			}
			return val;
		}
		set
		{
			throw new LuaError("无法设置此属性。请使用ScenEdit_SetMission（）。");
		}
	}

	[DoNotPrune]
	public LuaTable mineclearmission
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (myMission.MissionClass == Mission._MissionClass.MineClearing)
			{
				MineClearingMission mineClearingMission = (MineClearingMission)myMission;
				string[] mission_MineClearing = LuaMission.Mission_MineClearing;
				string[] array = mission_MineClearing;
				foreach (string text in array)
				{
					switch (text)
					{
					case "StationDepthSubmarine":
						val[text] = mineClearingMission.StationDepth_Submarine;
						break;
					case "UseFlightSize":
						val[text] = mineClearingMission.UseFlightSizeHardLimit;
						break;
					case "stationaltitudepreset":
						val[text] = mineClearingMission.StationAltitude_Preset;
						break;
					case "LoopType":
						val[text] = mineClearingMission.MovementStyle;
						break;
					case "TransitThrottleSubmarine":
						val[text] = mineClearingMission.TransitThrottle_Submarine;
						break;
					case "usetransitaltitudepreset":
						val[text] = mineClearingMission.UseTransitAltitude_Preset;
						break;
					case "OneThirdRule":
						val[text] = mineClearingMission.OneThirdRule;
						break;
					case "UseGroupSize":
						val[text] = mineClearingMission.UseGroupSizeHardLimit;
						break;
					case "StationAltitudeAircraft":
						val[text] = mineClearingMission.StationAltitude_Aircraft;
						break;
					case "stationdepthsubmarinepreset":
						val[text] = mineClearingMission.StationDepth_Submarine_Preset;
						break;
					case "TransitAltitudeAircraft":
						val[text] = mineClearingMission.TransitAltitude_Aircraft;
						break;
					case "StationTerrainFollowingAircraft":
						val[text] = mineClearingMission.StationTerrainFollowing_Aircraft;
						break;
					case "StationThrottleShip":
						val[text] = mineClearingMission.StationThrottle_Ship;
						break;
					case "stationdepthsubmarinepresetuse":
						val[text] = mineClearingMission.UseStationDepth_Submarine_Preset;
						break;
					case "Zone":
					{
						LuaTable val2 = LuaSandBox.Singleton().CreateTable();
						int num = 1;
						foreach (ReferencePoint item in mineClearingMission.Area)
						{
							LuaTable val3 = LuaSandBox.Singleton().CreateTable();
							val3["name"] = item.Name;
							val2[num] = val3;
							num++;
						}
						val[text] = val2;
						break;
					}
					case "transitaltitudepreset":
						val[text] = mineClearingMission.TransitAltitude_Preset;
						break;
					case "StationThrottleSubmarine":
						val[text] = mineClearingMission.StationThrottle_Submarine;
						break;
					case "transitdepthsubmarinepresetuse":
						val[text] = mineClearingMission.UseTransitDepth_Submarine_Preset;
						break;
					case "FlightSize":
						val[text] = mineClearingMission.FlightSize.ToString();
						break;
					case "transitdepthsubmarinepreset":
						val[text] = mineClearingMission.TransitDepth_Submarine_Preset;
						break;
					case "TransitThrottleShip":
						val[text] = mineClearingMission.TransitThrottle_Ship;
						break;
					case "usestationaltitudepreset":
						val[text] = mineClearingMission.UseStationAltitude_Preset;
						break;
					case "StationThrottleAircraft":
						val[text] = mineClearingMission.StationThrottle_Aircraft;
						break;
					case "TransitDepthSubmarine":
						val[text] = mineClearingMission.TransitDepth_Submarine;
						break;
					case "TransitThrottleAircraft":
						val[text] = mineClearingMission.TransitThrottle_Aircraft;
						break;
					case "TransitTerrainFollowingAircraft":
						val[text] = mineClearingMission.TransitTerrainFollowing_Aircraft;
						break;
					case "GroupSize":
						val[text] = mineClearingMission.GroupSize.ToString();
						break;
					case "MinAircraftReq":
						val[text] = mineClearingMission.MinimumNumberOfAircraft.ToString();
						break;
					}
				}
			}
			return val;
		}
		set
		{
			throw new LuaError("无法设置此属性。请使用ScenEdit_SetMission（）。");
		}
	}

	[DoNotPrune]
	public LuaTable minemission
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (myMission.MissionClass == Mission._MissionClass.Mining)
			{
				MiningMission miningMission = (MiningMission)myMission;
				string[] mission_Mining = LuaMission.Mission_Mining;
				string[] array = mission_Mining;
				foreach (string text in array)
				{
					switch (text)
					{
					case "StationDepthSubmarine":
						val[text] = miningMission.StationDepth_Submarine;
						break;
					case "UseFlightSize":
						val[text] = miningMission.UseFlightSizeHardLimit;
						break;
					case "stationaltitudepreset":
						val[text] = miningMission.StationAltitude_Preset;
						break;
					case "OneThirdRule":
						val[text] = miningMission.OneThirdRule;
						break;
					case "TransitThrottleSubmarine":
						val[text] = miningMission.TransitThrottle_Submarine;
						break;
					case "stationdepthsubmarinepreset":
						val[text] = miningMission.StationDepth_Submarine_Preset;
						break;
					case "usetransitaltitudepreset":
						val[text] = miningMission.UseTransitAltitude_Preset;
						break;
					case "StationTerrainFollowingAircraft":
						val[text] = miningMission.StationTerrainFollowing_Aircraft;
						break;
					case "UseGroupSize":
						val[text] = miningMission.UseGroupSizeHardLimit;
						break;
					case "StationAltitudeAircraft":
						val[text] = miningMission.StationAltitude_Aircraft;
						break;
					case "stationdepthsubmarinepresetuse":
						val[text] = miningMission.UseStationDepth_Submarine_Preset;
						break;
					case "TransitAltitudeAircraft":
						val[text] = miningMission.TransitAltitude_Aircraft;
						break;
					case "StationThrottleSubmarine":
						val[text] = miningMission.StationThrottle_Submarine;
						break;
					case "StationThrottleShip":
						val[text] = miningMission.StationThrottle_Ship;
						break;
					case "ArmingDelay":
					{
						TimeSpan timeSpan = TimeSpan.FromSeconds(miningMission.ArmDelay);
						val[text] = $"{timeSpan.Days:D2}d:{timeSpan.Hours:D2}h:{timeSpan.Minutes:D2}m:{timeSpan.Seconds:D2}s";
						break;
					}
					case "Zone":
					{
						LuaTable val2 = LuaSandBox.Singleton().CreateTable();
						int num = 1;
						foreach (ReferencePoint item in miningMission.Area)
						{
							LuaTable val3 = LuaSandBox.Singleton().CreateTable();
							val3["name"] = item.Name;
							val2[num] = val3;
							num++;
						}
						val[text] = val2;
						break;
					}
					case "transitaltitudepreset":
						val[text] = miningMission.TransitAltitude_Preset;
						break;
					case "transitdepthsubmarinepresetuse":
						val[text] = miningMission.UseTransitDepth_Submarine_Preset;
						break;
					case "FlightSize":
						val[text] = miningMission.FlightSize.ToString();
						break;
					case "transitdepthsubmarinepreset":
						val[text] = miningMission.TransitDepth_Submarine_Preset;
						break;
					case "TransitThrottleShip":
						val[text] = miningMission.TransitThrottle_Ship;
						break;
					case "usestationaltitudepreset":
						val[text] = miningMission.UseStationAltitude_Preset;
						break;
					case "StationThrottleAircraft":
						val[text] = miningMission.StationThrottle_Aircraft;
						break;
					case "TransitDepthSubmarine":
						val[text] = miningMission.TransitDepth_Submarine;
						break;
					case "TransitThrottleAircraft":
						val[text] = miningMission.TransitThrottle_Aircraft;
						break;
					case "TransitTerrainFollowingAircraft":
						val[text] = miningMission.TransitTerrainFollowing_Aircraft;
						break;
					case "GroupSize":
						val[text] = miningMission.GroupSize.ToString();
						break;
					case "MinAircraftReq":
						val[text] = miningMission.MinimumNumberOfAircraft.ToString();
						break;
					}
				}
			}
			return val;
		}
		set
		{
			throw new LuaError("无法设置此属性。请使用ScenEdit_SetMission（）。");
		}
	}

	[DoNotPrune]
	public LuaTable supportmission
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (myMission.MissionClass == Mission._MissionClass.Support)
			{
				SupportMission supportMission = (SupportMission)myMission;
				string[] mission_Support = LuaMission.Mission_Support;
				string[] array = mission_Support;
				foreach (string text in array)
				{
					switch (text.ToLower())
					{
					case "transitaltitudeaircraft":
						val[text] = supportMission.TransitAltitude_Aircraft;
						break;
					case "zone":
					{
						LuaTable val2 = LuaSandBox.Singleton().CreateTable();
						int num = 1;
						foreach (ReferencePoint item in supportMission.NavigationCourse)
						{
							LuaTable val3 = LuaSandBox.Singleton().CreateTable();
							val3["name"] = item.Name;
							val2[num] = val3;
							num++;
						}
						val[text] = val2;
						break;
					}
					case "onethirdrule":
						val[text] = supportMission.OneThirdRule;
						break;
					case "usegroupsize":
						val[text] = supportMission.UseGroupSizeHardLimit;
						break;
					case "stationaltitudepreset":
						val[text] = supportMission.StationAltitude_Preset;
						break;
					case "useflightsize":
						val[text] = supportMission.UseFlightSizeHardLimit;
						break;
					case "transitthrottleaircraft":
						val[text] = supportMission.TransitThrottle_Aircraft;
						break;
					case "stationterrainfollowingaircraft":
						val[text] = supportMission.StationTerrainFollowing_Aircraft;
						break;
					case "stationdepthsubmarinepreset":
						val[text] = supportMission.StationDepth_Submarine_Preset;
						break;
					case "usetransitaltitudepreset":
						val[text] = supportMission.UseTransitAltitude_Preset;
						break;
					case "transitterrainfollowingaircraft":
						val[text] = supportMission.TransitTerrainFollowing_Aircraft;
						break;
					case "groupsize":
						val[text] = supportMission.GroupSize.ToString();
						break;
					case "stationthrottlesubmarine":
						val[text] = supportMission.StationThrottle_Submarine;
						break;
					case "stationdepthsubmarinepresetuse":
						val[text] = supportMission.UseStationDepth_Submarine_Preset;
						break;
					case "looptype":
						val[text] = supportMission.NavigationLoopType;
						break;
					case "stationaltitudeaircraft":
						val[text] = supportMission.StationAltitude_Aircraft;
						break;
					case "stationdepthsubmarine":
						val[text] = supportMission.StationDepth_Submarine;
						break;
					case "transitaltitudepreset":
						val[text] = supportMission.TransitAltitude_Preset;
						break;
					case "flightsize":
						val[text] = supportMission.FlightSize.ToString();
						break;
					case "ccstationtime":
						val[text] = supportMission.ContinousCoverage_StationTime;
						break;
					case "ccenable":
						val[text] = supportMission.ContinousCoverage_Enable;
						break;
					case "stationthrottleaircraft":
						val[text] = supportMission.StationThrottle_Aircraft;
						break;
					case "onetimeonly":
						val[text] = supportMission.OneTimeOnly;
						break;
					case "transitthrottlesubmarine":
						val[text] = supportMission.TransitThrottle_Submarine;
						break;
					case "tankeronetime":
						val[text] = supportMission.A2AR_OneTankingCycleOnly;
						break;
					case "transitdepthsubmarinepreset":
						val[text] = supportMission.TransitDepth_Submarine_Preset;
						break;
					case "transitdepthsubmarinepresetuse":
						val[text] = supportMission.UseTransitDepth_Submarine_Preset;
						break;
					case "ccallowqra":
						val[text] = supportMission.ContinousCoverage_QRAEnable;
						break;
					case "transitthrottlefacility":
						val[text] = supportMission.TransitThrottle_Facility;
						break;
					case "usestationaltitudepreset":
						val[text] = supportMission.UseStationAltitude_Preset;
						break;
					case "ccflightgenmethod":
						val[text] = supportMission.ContinousCoverage_QRAFlightGenerationMethod;
						break;
					case "onstation":
						val[text] = supportMission.MinimumNumberOnStation;
						break;
					case "activeemcon":
						val[text] = supportMission.ActiveEMCONOnlyOnStation;
						break;
					case "stationthrottleshipfacility":
						val[text] = supportMission.StationThrottle_Facility;
						break;
					case "tankermaxreceivers":
						val[text] = supportMission.A2AR_MaxNumberOfReceiversPerTanker;
						break;
					case "transitthrottleship":
						val[text] = supportMission.TransitThrottle_Ship;
						break;
					case "ccoverlap":
						val[text] = supportMission.ContinousCoverage_Overlap;
						break;
					case "stationthrottleship":
						val[text] = supportMission.StationThrottle_Ship;
						break;
					case "transitdepthsubmarine":
						val[text] = supportMission.TransitDepth_Submarine;
						break;
					case "minaircraftreq":
						val[text] = supportMission.MinimumNumberOfAircraft.ToString();
						break;
					}
				}
			}
			return val;
		}
		set
		{
			throw new LuaError("无法设置此属性。请使用ScenEdit_SetMission（）。");
		}
	}

	[DoNotPrune]
	public LuaTable patrolmission
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (myMission.MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol patrol = (Patrol)myMission;
				string[] mission_Patrol = LuaMission.Mission_Patrol;
				string[] array = mission_Patrol;
				foreach (string text in array)
				{
					switch (text.ToLower())
					{
					case "wingmanengagedistance":
						val[text] = patrol.WingmanEngageDistance;
						break;
					case "transitaltitudeaircraft":
						val[text] = patrol.TransitAltitude_Aircraft;
						break;
					case "attackthrottleaircraft":
						val[text] = patrol.AttackThrottle_Aircraft;
						break;
					case "flightstoinvestigate":
						val[text] = patrol.NumberOfFlights_Investigate;
						break;
					case "attackdistanceship":
						val[text] = patrol.AttackDistance_Ship;
						break;
					case "attackdepthsubmarinepreset":
						val[text] = patrol.AttackDepth_Submarine_Preset;
						break;
					case "avoidcavitation":
						if (patrol.AvoidCavitation)
						{
							val[text] = patrol.AvoidCavitation;
						}
						break;
					case "stationaltitudepreset":
						val[text] = patrol.StationAltitude_Preset;
						break;
					case "attackthrottleship":
						val[text] = patrol.AttackThrottle_Ship;
						break;
					case "onethirdrule":
						val[text] = patrol.OneThirdRule;
						break;
					case "usegroupsize":
						val[text] = patrol.UseGroupSizeHardLimit;
						break;
					case "prosecutionzone":
					{
						LuaTable val4 = LuaSandBox.Singleton().CreateTable();
						int num2 = 1;
						foreach (ReferencePoint item in patrol.ProsecutionArea)
						{
							LuaTable val5 = LuaSandBox.Singleton().CreateTable();
							val5["name"] = item.Name;
							val4[num2] = val5;
							num2++;
						}
						val[text] = val4;
						break;
					}
					case "useattackaltitudepreset":
						val[text] = patrol.UseAttackAltitude_Preset;
						break;
					case "useflightsize":
						val[text] = patrol.UseFlightSizeHardLimit;
						break;
					case "transitthrottleaircraft":
						val[text] = patrol.TransitThrottle_Aircraft;
						break;
					case "sprintdrift":
						if (patrol.SprintAndDrift)
						{
							val[text] = patrol.SprintAndDrift;
						}
						break;
					case "stationdepthsubmarinepreset":
						val[text] = patrol.StationDepth_Submarine_Preset;
						break;
					case "usetransitaltitudepreset":
						val[text] = patrol.UseTransitAltitude_Preset;
						break;
					case "stationterrainfollowingaircraft":
						val[text] = patrol.StationTerrainFollowing_Aircraft;
						break;
					case "groupmemberengagedistance":
						val[text] = patrol.GroupMemberEngageDistance;
						break;
					case "attackthrottlesubmarine":
						val[text] = patrol.AttackThrottle_Submarine;
						break;
					case "transitterrainfollowingaircraft":
						val[text] = patrol.TransitTerrainFollowing_Aircraft;
						break;
					case "groupsize":
						val[text] = patrol.GroupSize.ToString();
						break;
					case "type":
						val[text] = patrol.Type;
						break;
					case "looptype":
						val[text] = patrol.MovementStyle;
						break;
					case "stationthrottlesubmarine":
						val[text] = patrol.StationThrottle_Submarine;
						break;
					case "stationdepthsubmarinepresetuse":
						val[text] = patrol.UseStationDepth_Submarine_Preset;
						break;
					case "stationaltitudeaircraft":
						val[text] = patrol.StationAltitude_Aircraft;
						break;
					case "stationdepthsubmarine":
						val[text] = patrol.StationDepth_Submarine;
						break;
					case "attackaltitudepreset":
						val[text] = patrol.AttackAltitude_Preset;
						break;
					case "attackterrainfollowingaircraft":
						val[text] = patrol.AttackTerrainFollowing_Aircraft;
						break;
					case "checkopa":
						val[text] = patrol.GetInvestigateOutsidePatrolArea(ScenarioContext);
						break;
					case "flightsize":
						val[text] = patrol.FlightSize.ToString();
						break;
					case "flightstoengage":
						val[text] = patrol.NumberOfFlights_Engage;
						break;
					case "boatstoengage":
						val[text] = patrol.NumberOfBoats_Engage;
						break;
					case "patrolzone":
					{
						LuaTable val2 = LuaSandBox.Singleton().CreateTable();
						int num = 1;
						foreach (ReferencePoint item2 in patrol.PatrolArea)
						{
							LuaTable val3 = LuaSandBox.Singleton().CreateTable();
							val3["name"] = item2.Name;
							val2[num] = val3;
							num++;
						}
						val[text] = val2;
						break;
					}
					case "transitaltitudepreset":
						val[text] = patrol.TransitAltitude_Preset;
						break;
					case "transitthrottlesubmarine":
						val[text] = patrol.TransitThrottle_Submarine;
						break;
					case "stationthrottleaircraft":
						val[text] = patrol.StationThrottle_Aircraft;
						break;
					case "transitdepthsubmarinepresetuse":
						val[text] = patrol.UseTransitDepth_Submarine_Preset;
						break;
					case "attackdepthsubmarine":
						val[text] = patrol.AttackDepth_Submarine;
						break;
					case "usestationaltitudepreset":
						val[text] = patrol.UseStationAltitude_Preset;
						break;
					case "checkwwr":
						val[text] = patrol.GetInvestigateWithinWeaponRange(ScenarioContext);
						break;
					case "transitdepthsubmarinepreset":
						val[text] = patrol.TransitDepth_Submarine_Preset;
						break;
					case "onstation":
						val[text] = patrol.MinimumNumberOnStation;
						break;
					case "attackdistanceaircraft":
						val[text] = patrol.AttackDistance_Aircraft;
						break;
					case "boatstoinvestigate":
						val[text] = patrol.NumberOfBoats_Investigate;
						break;
					case "attackaltitudeaircraft":
						val[text] = patrol.AttackAltitude_Aircraft;
						break;
					case "attackdistancesubmarine":
						val[text] = patrol.AttackDistance_Submarine;
						break;
					case "transitthrottleship":
						val[text] = patrol.TransitThrottle_Ship;
						break;
					case "activeemcon":
						val[text] = patrol.ActiveEMCONOnlyInPatrolOrProsecutionArea;
						break;
					case "transitdepthsubmarine":
						val[text] = patrol.TransitDepth_Submarine;
						break;
					case "minaircraftreq":
						val[text] = patrol.MinimumNumberOfAircraft.ToString();
						break;
					case "stationthrottleship":
						val[text] = patrol.StationThrottle_Ship;
						break;
					case "attackdepthsubmarinepresetuse":
						val[text] = patrol.UseAttackDepth_Submarine_Preset;
						break;
					}
				}
			}
			return val;
		}
		set
		{
			throw new LuaError("无法设置此属性。请使用ScenEdit_SetMission（）。");
		}
	}

	[DoNotPrune]
	public LuaTable strikemission
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			LuaTable val2 = LuaSandBox.Singleton().CreateTable();
			if (myMission.MissionClass == Mission._MissionClass.Strike)
			{
				Strike strike = (Strike)myMission;
				string[] mission_Strike = LuaMission.Mission_Strike;
				string[] array = mission_Strike;
				foreach (string text in array)
				{
					switch (text.ToLower())
					{
					case "escortminshooter":
						val2[text] = strike.MinimumNumberOfAircraft_Escorts_Shooter.ToString();
						break;
					case "wingmanengagedistance":
						val2[text] = strike.Escort_WingmanEngageDistance;
						break;
					case "escortmaxnonshooter":
						val2[text] = strike.MaximumNumberOfAircraft_Escorts_NonShooter.ToString();
						break;
					case "flightstoinvestigate":
						val2[text] = strike.Escort_NumberOfFlights_Investigate;
						break;
					case "escortusegroupsize":
						val2[text] = strike.UseGroupSizeHardLimit_Escort;
						break;
					case "escortresponseradius":
						val2[text] = strike.Escort_ResponseRadius;
						break;
					case "escortuseflightsize":
						val2[text] = strike.UseFlightSizeHardLimit_Escort;
						break;
					case "groupmemberengagedistance":
						val2[text] = strike.Escort_GroupMemberEngageDistance;
						break;
					case "escortminnonshooter":
						val2[text] = strike.MinimumNumberOfAircraft_Escorts_NonShooter.ToString();
						break;
					case "escortflightsizenonshooter":
						val2[text] = (int)strike.Escort_FlightSize_NonShooter;
						break;
					case "type":
						val2[text] = strike.Type;
						break;
					case "escortgroupsize":
						val2[text] = (int)strike.Escort_GroupSize;
						break;
					case "escortresponseradiussead":
						val2[text] = strike.Escort_ResponseRadius_SEAD;
						break;
					case "boatstoengage":
						val2[text] = strike.Escort_NumberOfBoats_Engage;
						break;
					case "flightstoengage":
						val2[text] = strike.Escort_NumberOfFlights_Engage;
						break;
					case "escortflightsizeshooter":
						val2[text] = (int)strike.Escort_FlightSize_Shooter;
						break;
					case "boatstoinvestigate":
						val2[text] = strike.Escort_NumberOfBoats_Investigate;
						break;
					case "escortmaxshooter":
						val2[text] = strike.MaximumNumberOfAircraft_Escorts_Shooter.ToString();
						break;
					}
				}
				val["Escort"] = val2;
				val2 = LuaSandBox.Singleton().CreateTable();
				mission_Strike = LuaMission.Mission_Strike;
				string[] array2 = mission_Strike;
				foreach (string text2 in array2)
				{
					switch (text2.ToLower())
					{
					case "strikegroupsize":
						val2[text2] = (int)strike.GroupSize;
						break;
					case "strikeflightsize":
						val2[text2] = (int)strike.FlightSize;
						break;
					case "strikeautoplanner":
						val2[text2] = strike.UsePlanner;
						break;
					case "strikeonetimeonly":
						val2[text2] = strike.OneTimeOnly;
						break;
					case "strikepreplan":
						val2[text2] = strike.RTB_When_Target_Destroyed;
						break;
					case "strikemaxdistship":
						val2[text2] = strike.MaxResponseRadius_Ship;
						break;
					case "strikemindistship":
						val2[text2] = strike.MinResponseRadius_Ship;
						break;
					case "strikeminaircraftreq":
						val2[text2] = strike.MinimumNumberOfAircraft.ToString();
						break;
					case "strikeminimumtrigger":
						val2[text2] = strike.MinimumContactStanceToTrigger;
						break;
					case "strikemax":
						val2[text2] = strike.MaxFlightNumber_Strike.ToString();
						break;
					case "strikeusegroupsize":
						val2[text2] = strike.UseGroupSizeHardLimit;
						break;
					case "strikemaxdistaircraft":
						val2[text2] = strike.MaxResponseRadius_Aircraft;
						break;
					case "strikemindistaircraft":
						val2[text2] = strike.MinResponseRadius_Aircraft;
						break;
					case "strikeuseflightsize":
						val2[text2] = strike.UseFlightSizeHardLimit;
						break;
					}
				}
				val["Strike"] = val2;
			}
			return val;
		}
		set
		{
			throw new LuaError("无法设置此属性。请使用ScenEdit_SetMission（）。");
		}
	}

	[DoNotPrune]
	public LuaTable cargomission
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (myMission.MissionClass == Mission._MissionClass.Cargo)
			{
				CargoMission cargoMission = (CargoMission)myMission;
				string[] mission_Cargo = LuaMission.Mission_Cargo;
				string[] array = mission_Cargo;
				foreach (string text in array)
				{
					switch (text)
					{
					case "UseFlightSize":
						val[text] = cargoMission.UseFlightSizeHardLimit;
						break;
					case "IsFulfilled":
						val[text] = cargoMission.IsFulfilled();
						break;
					case "UseGroupSize":
						val[text] = cargoMission.UseGroupSizeHardLimit;
						break;
					case "StationAltitudeAircraft":
						val[text] = cargoMission.StationAltitude_Aircraft;
						break;
					case "AutomaticallyUnpackContainersAtDestination":
						val[text] = cargoMission.UnpackAllContainers;
						break;
					case "TransitAltitudeAircraft":
						val[text] = cargoMission.TransitAltitude_Aircraft;
						break;
					case "StationThrottleShip":
						val[text] = cargoMission.StationThrottle_Ship;
						break;
					case "MoveAllCargo":
						val[text] = cargoMission.MoveAllCargo;
						break;
					case "Zone":
					{
						if (cargoMission.Area.Count == 0)
						{
							val[text] = "(NONE)";
							break;
						}
						LuaTable val2 = LuaSandBox.Singleton().CreateTable();
						int num = 1;
						foreach (ReferencePoint item in cargoMission.Area)
						{
							LuaTable val3 = LuaSandBox.Singleton().CreateTable();
							val3["name"] = item.Name;
							val2[num] = val3;
							num++;
						}
						val[text] = val2;
						break;
					}
					case "AllGroundUnitAttemptSelfDelivery":
						val[text] = cargoMission.AllowAllSelfDelivery;
						break;
					case "StationThrottleAircraft":
						val[text] = cargoMission.StationThrottle_Aircraft;
						break;
					case "TransitThrottleShip":
						val[text] = cargoMission.TransitThrottle_Ship;
						break;
					case "Type":
						val[text] = cargoMission.Type;
						break;
					case "AllowGroundUnitSelfDeliveryFromCargo":
						val[text] = cargoMission.AllowSelfDeliveryFromCargo;
						break;
					case "DestinationUnitID":
						if (cargoMission.DestinationUnit == null)
						{
							val[text] = "(NONE)";
						}
						else
						{
							val[text] = cargoMission.DestinationUnit.ObjectID;
						}
						break;
					case "TransitThrottleAircraft":
						val[text] = cargoMission.TransitThrottle_Aircraft;
						break;
					}
				}
			}
			return val;
		}
		set
		{
			throw new LuaError("无法设置此属性。请使用ScenEdit_SetMission（）。");
		}
	}

	[DoNotPrune]
	public LuaTable flightlist
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			foreach (Mission.Flight flight in myMission.FlightList)
			{
				val[val.Keys.Count + 1] = new LuaWrapper_Flight(flight, ScenarioContext);
			}
			return val;
		}
		set
		{
			throw new LuaError("无法设置此属性。请使用ScenEdit_Set。");
		}
	}

	[DoNotPrune]
	public string TimeOnTargetStation
	{
		get
		{
			return myMission.TimeOnTarget.ToString();
		}
		set
		{
			try
			{
				myMission.TimeOnTarget = Conversions.ToDate(value);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public string TakeOffTime
	{
		get
		{
			return myMission.TakeOffTime.ToString();
		}
		set
		{
			try
			{
				myMission.TakeOffTime = Conversions.ToDate(value);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public LuaWrapper_Mission(Mission mission_0, Scenario scenario_0)
	{
		myMission = mission_0;
		ScenarioContext = scenario_0;
		Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			foreach (Mission mission in side.Missions)
			{
				if (Operators.CompareString(mission.ObjectID, myMission.ObjectID, TextCompare: false) == 0)
				{
					mySide = side;
					break;
				}
			}
		}
	}

	[DoNotPrune]
	public override string ToString()
	{
		return string.Concat("mission {\r\n guid = '" + guid + "', \r\n name = '" + name + "', \r\n side = '" + side + "', \r\n type = '" + type.ToString() + "', \r\n subtype = '" + subtype.ToString() + "', \r\n isactive = '" + isactive.ToString() + "', \r\n starttime = '" + starttime + "', \r\n endtime = '" + endtime + "', \r\n SISH = '" + SISH.ToString() + "', \r\n aar = '" + aar.ToString() + "',\r\n unitlist = '" + unitlist.ToString() + "',\r\n", "}");
	}
}
