using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[StandardModule]
public sealed class LuaMission
{
	public const string Doctrine_UseReplenishment = "use_refuel_unrep";

	public static readonly string[] Mission_Tanker;

	public static readonly string[] Mission_Support;

	public static readonly string[] Mission_Strike;

	public static readonly string[] Mission_Cargo;

	public static readonly string[] Mission_Mining;

	public static readonly string[] Mission_MineClearing;

	public static readonly string[] Mission_Patrol;

	public static readonly string[] Mission_Ferry;

	static LuaMission()
	{
		Mission_Tanker = new string[10] { "TankerUsage", "TankerMissionList", "LaunchMissionWithoutTankersInPlace", "TankerMinNumber_Total", "TankerMinNumber_Airborne", "TankerMinNumber_Station", "MaxReceiversInQueuePerTanker_Airborne", "FuelQtyToStartLookingForTanker_Airborne", "TankerMaxDistance_Airborne", "TankerFollowsReceivers" };
		Mission_Support = new string[45]
		{
			"OneThirdRule", "OnStation", "TransitThrottleAircraft", "TransitAltitudeAircraft", "TransitTerrainFollowingAircraft", "StationThrottleAircraft", "StationAltitudeAircraft", "StationTerrainFollowingAircraft", "TransitThrottleSubmarine", "TransitDepthSubmarine",
			"StationThrottleSubmarine", "StationDepthSubmarine", "TransitThrottleShip", "StationThrottleShip", "FlightSize", "MinAircraftReq", "UseFlightSize", "GroupSize", "UseGroupSize", "Zone",
			"LoopType", "OnStation", "OneTimeOnly", "ActiveEMCON", "TankerOneTime", "TankerMaxReceivers", "UseFlightplan", "UseFlightplansOnly", "IncludeInATO", "Course",
			"TransitThrottleFacility", "StationThrottleShipFacility", "CCEnable", "CCAllowQRA", "CCFlightGenMethod", "CCStationTime", "CCOverlap", "StationDepthSubmarinePreset", "TransitDepthSubmarinePreset", "UseStationDepthSubmarinePreset",
			"UseTransitDepthSubmarinePreset", "StationAltitudePreset", "TransitAltitudePreset", "UseStationAltitudePreset", "UseTransitAltitudePreset"
		};
		Mission_Strike = new string[45]
		{
			"Type", "EscortFlightSizeShooter", "EscortMinShooter", "EscortMaxShooter", "EscortResponseRadius", "EscortResponseRadiusSead", "EscortUseFlightSize", "EscortFlightSizeNonShooter", "EscortMinNonShooter", "EscortMaxNonShooter",
			"EscortGroupSize", "EscortUs<ContinousCoverage_NumberOfFlightsNeededToAllowQRA>eGroupSize", "StrikeOneTimeOnly", "StrikeMinimumTrigger", "StrikeMax", "StrikeFlightSize", "StrikeMinAircraftReq", "StrikeUseFlightSize", "StrikeGroupSize", "StrikeUseGroupSize",
			"StrikeAutoPlanner", "StrikePrePlan", "StrikeRadarUsage", "StrikeMinDist", "StrikeMaxDist", "UseFlightplan", "UseFlightplansOnly", "IncludeInATO", "EscortFormationCruise", "EscortFormationAttack",
			"EscortTransitThrottle", "EscortTransitAltitude", "EscortTransitTerrainFollowing", "StrikeFormationCruise", "StrikeFormationAttack", "StrikeMinDistAircraft", "StrikeMaxDistAircraft", "StrikeMinDistShip", "StrikeMaxDistShip", "FlightsToInvestigate",
			"FlightsToEngage", "WingmanEngageDistance", "BoatsToInvestigate", "BoatsToEngage", "GroupMemberEngageDistance"
		};
		Mission_Cargo = new string[21]
		{
			"OneThirdRule", "Type", "TransitThrottleAircraft", "TransitAltitudeAircraft", "StationThrottleAircraft", "StationAltitudeAircraft", "TransitThrottleSubmarine", "TransitDepthSubmarine", "StationThrottleSubmarine", "StationDepthSubmarine",
			"TransitThrottleShip", "StationThrottleShip", "UseFlightSize", "UseGroupSize", "Zone", "IsFulfilled", "DestinationUnitID", "MoveAllCargo", "AllowGroundUnitSelfDeliveryFromCargo", "AllGroundUnitAttemptSelfDelivery",
			"AutomaticallyUnpackContainersAtDestination"
		};
		Mission_Mining = new string[32]
		{
			"OneThirdRule", "TransitThrottleAircraft", "TransitAltitudeAircraft", "TransitTerrainFollowingAircraft", "StationThrottleAircraft", "StationAltitudeAircraft", "StationTerrainFollowingAircraft", "TransitThrottleSubmarine", "TransitDepthSubmarine", "StationThrottleSubmarine",
			"StationDepthSubmarine", "TransitThrottleShip", "StationThrottleShip", "FlightSize", "MinAircraftReq", "UseFlightSize", "GroupSize", "UseGroupSize", "Zone", "ArmingDelay",
			"StationDepthSubmarinePreset", "TransitDepthSubmarinePreset", "UseStationDepthSubmarinePreset", "UseTransitDepthSubmarinePreset", "StationAltitudePreset", "TransitAltitudePreset", "UseStationAltitudePreset", "UseTransitAltitudePreset", "MinesLaidInSet", "MinesLaidInterval",
			"MinesLaidMethod", "MinesLaidSetInterval"
		};
		Mission_MineClearing = new string[28]
		{
			"OneThirdRule", "LoopType", "TransitThrottleAircraft", "TransitAltitudeAircraft", "TransitTerrainFollowingAircraft", "StationThrottleAircraft", "StationAltitudeAircraft", "StationTerrainFollowingAircraft", "TransitThrottleSubmarine", "TransitDepthSubmarine",
			"StationThrottleSubmarine", "StationDepthSubmarine", "TransitThrottleShip", "StationThrottleShip", "FlightSize", "MinAircraftReq", "UseFlightSize", "GroupSize", "UseGroupSize", "Zone",
			"StationDepthSubmarinePreset", "TransitDepthSubmarinePreset", "UseStationDepthSubmarinePreset", "UseTransitDepthSubmarinePreset", "StationAltitudePreset", "TransitAltitudePreset", "UseStationAltitudePreset", "UseTransitAltitudePreset"
		};
		Mission_Patrol = new string[65]
		{
			"Type", "OneThirdRule", "CheckOPA", "CheckWWR", "ActiveEMCON", "OnStation", "LoopType", "TransitThrottleAircraft", "TransitAltitudeAircraft", "TransitTerrainFollowingAircraft",
			"StationThrottleAircraft", "StationAltitudeAircraft", "StationTerrainFollowingAircraft", "AttackThrottleAircraft", "AttackAltitudeAircraft", "AttackTerrainFollowingAircraft", "AttackDistanceAircraft", "TransitThrottleSubmarine", "TransitDepthSubmarine", "StationThrottleSubmarine",
			"StationDepthSubmarine", "AttackThrottleSubmarine", "AttackDepthSubmarine", "AttackDistanceSubmarine", "TransitDepthSubmarine_Preset", "AttackDepthSubmarine_Preset", "StationDepthSubmarine_Preset", "TransitThrottleShip", "StationThrottleShip", "AttackThrottleShip",
			"AttackDistanceShip", "SprintDrift", "AvoidCavitation", "FlightSize", "MinAircraftReq", "UseFlightSize", "GroupSize", "UseGroupSize", "ProsecutionZone", "PatrolZone",
			"TransitThrottleFacility", "StationThrottleFacility", "UseFlightplan", "UseFlightplansOnly", "IncludeInATO", "FormationCruise", "FormationAttack", "FlightsToInvestigate", "FlightsToEngage", "WingmanEngageDistance",
			"BoatsToInvestigate", "BoatsToEngage", "GroupMemberEngageDistance", "StationDepthSubmarinePreset", "TransitDepthSubmarinePreset", "AttackDepthSubmarine_Preset", "UseStationDepthSubmarinePreset", "UseTransitDepthSubmarinePreset", "UseAttackDepthSubmarinePreset", "StationAltitudePreset",
			"TransitAltitudePreset", "AttackAltitudePreset", "UseStationAltitudePreset", "UseTransitAltitudePreset", "UseAttackAltitudePreset"
		};
		Mission_Ferry = new string[7] { "FerryBehavior", "FerryThrottleAircraft", "FerryAltitudeAircraft", "FerryTerrainFollowingAircraft", "FlightSize", "MinAircraftReq", "UseFlightSize" };
	}

	public static LuaTable ScenEdit_GetMissions(string string_0, Scenario scenario_0)
	{
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		Side side = null;
		try
		{
			side = LuaUtility.QuerySideObject(string_0, scenario_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			if (ex is LuaError)
			{
				throw;
			}
			throw new LuaError("Side not found");
		}
		if (side == null)
		{
			return val;
		}
		foreach (Mission mission in side.Missions)
		{
			val[val.Keys.Count + 1] = new LuaWrapper_Mission(mission, scenario_0);
		}
		return val;
	}

	public static LuaWrapper_Mission ScenEdit_GetMission(string string_0, string string_1, Scenario scenario_0)
	{
		Side side = null;
		new List<ReferencePoint>();
		side = PrivateMethods.ValidateSide(string_0, scenario_0);
		if (side == null)
		{
			throw new LuaError("缺少分方：" + string_0);
		}
		return new LuaWrapper_Mission(ValidateMissionBySide(string_1, side) ?? throw new LuaError("缺少任务" + string_1), scenario_0);
	}

	public static LuaWrapper_Mission ScenEdit_AddMission(string string_0, string string_1, string string_2, LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		LuaSandBox.Singleton().CreateTable();
		Scenario scenario_ = scenario_0;
		ActiveUnit activeUnit = null;
		Mission mission = null;
		Side side = null;
		List<ReferencePoint> list_ = new List<ReferencePoint>();
		try
		{
			side = PrivateMethods.ValidateSide(string_0, scenario_);
			if (side == null)
			{
				throw new LuaError("缺少分方" + string_0);
			}
			mission = ValidateMissionBySide(string_1, side);
			if (Information.IsNothing(mission))
			{
				string text = null;
				if (dictionary.ContainsKey("TYPE"))
				{
					text = Conversions.ToString(dictionary["TYPE"]);
				}
				if (dictionary.ContainsKey("DESTINATION"))
				{
					activeUnit = PrivateMethods.smethod_0(Conversions.ToString(dictionary["DESTINATION"]), scenario_);
				}
				if (dictionary.ContainsKey("ZONE"))
				{
					foreach (object item in LuaUtility.ToArray(((LuaTable)dictionary["ZONE"]).GetEnumerator()))
					{
						object Local_o = RuntimeHelpers.GetObjectValue(item);
						ReferencePoint referencePoint = null;
						if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => Operators.CompareString(s.Name, Local_o.ToString(), TextCompare: false) == 0)))
						{
							if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o.ToString(), StringComparison.OrdinalIgnoreCase))))
							{
								if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase))))
								{
									if (!Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase))))
									{
										referencePoint = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase));
									}
								}
								else
								{
									referencePoint = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase));
								}
							}
							else
							{
								referencePoint = side.RefPoints.First((ReferencePoint s) => string.Equals(s.Name, Local_o.ToString(), StringComparison.OrdinalIgnoreCase));
							}
						}
						else
						{
							referencePoint = side.RefPoints.First((ReferencePoint s) => Operators.CompareString(s.Name, Local_o.ToString(), TextCompare: false) == 0);
						}
						if (!Information.IsNothing(referencePoint))
						{
							list_.Add(referencePoint);
						}
					}
				}
				if (text == null && (string.Equals(string_2, "STRIKE", StringComparison.OrdinalIgnoreCase) || string.Equals(string_2, "PATROL", StringComparison.OrdinalIgnoreCase)))
				{
					throw new LuaError("攻击/巡逻任务类型");
				}
				switch (string_2.ToUpper())
				{
				case "PATROL":
					switch (text.ToUpper())
					{
					case "SeaControl":
					case "SEA":
						mission = new Patrol(side, scenario_, string_1, Mission.MissionCategory.Mission, list_, GlobalVariables.PatrolType.SeaControl, bool_0: false);
						break;
					case "SUB":
					case "ASW":
						mission = new Patrol(side, scenario_, string_1, Mission.MissionCategory.Mission, list_, GlobalVariables.PatrolType.ASW, bool_0: false);
						break;
					case "SEAD":
						mission = new Patrol(side, scenario_, string_1, Mission.MissionCategory.Mission, list_, GlobalVariables.PatrolType.SEAD, bool_0: false);
						break;
					case "AIR":
					case "AAW":
						mission = new Patrol(side, scenario_, string_1, Mission.MissionCategory.Mission, list_, GlobalVariables.PatrolType.AAW, bool_0: false);
						break;
					case "SUR_MIXED":
					case "MIXED":
					case "ASuW_Mixed":
						mission = new Patrol(side, scenario_, string_1, Mission.MissionCategory.Mission, list_, GlobalVariables.PatrolType.ASuW_Mixed, bool_0: false);
						break;
					case "ASuW_Land":
					case "LAND":
					case "SUR_LAND":
						mission = new Patrol(side, scenario_, string_1, Mission.MissionCategory.Mission, list_, GlobalVariables.PatrolType.ASuW_Land, bool_0: false);
						break;
					default:
						throw new LuaError("缺少任务子类型");
					case "NAVAL":
					case "SUR_SEA":
					case "ASuW_Naval":
						mission = new Patrol(side, scenario_, string_1, Mission.MissionCategory.Mission, list_, GlobalVariables.PatrolType.ASuW_Naval, bool_0: false);
						break;
					}
					break;
				case "CARGO":
					mission = new CargoMission(side, scenario_, string_1, Mission.MissionCategory.Mission, list_, bool_0: false, activeUnit);
					break;
				case "MINING":
					mission = new MiningMission(side, scenario_, string_1, Mission.MissionCategory.Mission, list_, bool_0: false);
					break;
				case "STRIKE":
					switch (text.ToUpper())
					{
					case "SUB":
					case "ASW":
					case "Sub_Strike":
						mission = new Strike(side, scenario_, string_1, Mission.MissionCategory.Mission, Strike.StrikeType.Sub_Strike);
						mission.Name = string_1;
						break;
					case "AIR":
					case "Air_Intercept":
					case "AAW":
						mission = new Strike(side, scenario_, string_1, Mission.MissionCategory.Mission, Strike.StrikeType.Air_Intercept);
						mission.Name = string_1;
						break;
					case "SEA":
					case "Maritime_Strike":
					case "NAVAL":
					case "SUR_SEA":
						mission = new Strike(side, scenario_, string_1, Mission.MissionCategory.Mission, Strike.StrikeType.Maritime_Strike);
						mission.Name = string_1;
						break;
					default:
						throw new LuaError("缺少任务子类型");
					case "Land_Strike":
					case "LAND":
					case "SUR_LAND":
						mission = new Strike(side, scenario_, string_1, Mission.MissionCategory.Mission, Strike.StrikeType.Land_Strike);
						mission.Name = string_1;
						break;
					}
					break;
				case "SUPPORT":
					mission = new SupportMission(ref side, ref scenario_, string_1, Mission.MissionCategory.Mission, ref list_, bool_0: false);
					break;
				case "FERRY":
					if (activeUnit == null)
					{
						throw new LuaError("缺少目的地");
					}
					mission = new FerryMission(side, scenario_, string_1, Mission.MissionCategory.Mission, activeUnit);
					break;
				default:
					throw new LuaError("缺少任务类型");
				case "MINECLEARING":
					mission = new MineClearingMission(side, scenario_, string_1, Mission.MissionCategory.Mission, list_, bool_0: false);
					break;
				}
				side.Missions_Add(mission);
				return new LuaWrapper_Mission(mission, scenario_0);
			}
			throw new LuaError("现有的任务" + string_1);
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

	public static bool ScenEdit_DeleteMission(string string_0, string string_1, Scenario scenario_0)
	{
		Mission mission = null;
		Side side = null;
		new List<ReferencePoint>();
		side = PrivateMethods.ValidateSide(string_0, scenario_0);
		if (side == null)
		{
			throw new LuaError("缺少分方" + string_0);
		}
		mission = ValidateMissionBySide(string_1, side);
		if (mission == null)
		{
			throw new LuaError("缺少任务" + string_1);
		}
		foreach (ActiveUnit unit in side.Units)
		{
			if (!Information.IsNothing(unit.AssignedMissionOrPackage()) && Operators.CompareString(unit.AssignedMissionOrPackage().ObjectID, mission.ObjectID, TextCompare: false) == 0)
			{
				Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
				unit.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
			}
		}
		side.Missions_Remove(mission);
		return true;
	}

	public static LuaTable ScenEdit_ExportMission(string string_0, string string_1, Scenario scenario_0)
	{
		Mission mission = null;
		Side side = null;
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		int num = 1;
		side = PrivateMethods.ValidateSide(string_0, scenario_0);
		if (side == null)
		{
			throw new LuaError("缺少分方" + string_0);
		}
		mission = ValidateMissionBySide(string_1, side);
		if (Information.IsNothing(mission))
		{
			throw new LuaError("任务" + string_1 + "未找到！");
		}
		if (!Directory.Exists(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Defaults"))
		{
			Directory.CreateDirectory(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Defaults");
		}
		FileStream fileStream = File.Create(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Defaults" + Conversions.ToString(Path.DirectorySeparatorChar) + string_1 + ".xml");
		XmlWriterSettings settings = new XmlWriterSettings();
		using (MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream())
		{
			using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, settings))
			{
				Mission mission2 = mission;
				XmlWriter xmlWriter_ = xmlWriter;
				HashSet<string> hashSet_ = null;
				mission2.ToXML(ref xmlWriter_, ref hashSet_, ref scenario_0);
			}
			fileStream.Write(memoryStream.ToArray(), 0, (int)memoryStream.Position);
			fileStream.Close();
		}
		val[num] = mission.ObjectID;
		num++;
		return val;
	}

	public static LuaTable ScenEdit_ImportMission(string string_0, string string_1, Scenario scenario_0)
	{
		Side side = null;
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		int num = 1;
		side = PrivateMethods.ValidateSide(string_0, scenario_0);
		if (side == null)
		{
			throw new LuaError("缺少分方" + string_0);
		}
		try
		{
			FileStream fileStream = new FileStream(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Defaults" + Conversions.ToString(Path.DirectorySeparatorChar) + string_1 + ".xml", FileMode.Open, FileAccess.Read);
			XmlDocument xmlDocument = new XmlDocument();
			ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_ = new ConcurrentDictionary<string, ScenarioObject>();
			using (fileStream)
			{
				try
				{
					xmlDocument.Load(fileStream);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					GameGeneral.ResolveBridge("文件格式不正确，读取失败！", side);
					ProjectData.ClearProjectError();
				}
			}
			fileStream.Close();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlDocument.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode_ = (XmlNode)enumerator.Current;
					Mission mission = Mission.FromXML(ref xmlNode_, ref concurrentDictionary_, ref scenario_0);
					if (!Information.IsNothing(mission))
					{
						side.Missions_Add(mission);
						val[num] = mission.ObjectID;
						num++;
					}
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
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			GameGeneral.ResolveBridge("无法找到目录或文件！", side);
			ProjectData.ClearProjectError();
			return val;
		}
	}

	public static LuaWrapper_Mission ScenEdit_SetMission(string string_0, string string_1, LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		LuaSandBox.Singleton().CreateTable();
		Mission mission = null;
		Side side = null;
		side = PrivateMethods.ValidateSide(string_0, scenario_0);
		if (side == null)
		{
			throw new LuaError("缺少分方：" + string_0);
		}
		mission = ValidateMissionBySide(string_1, side);
		if (mission == null)
		{
			throw new LuaError("缺少任务：" + string_1);
		}
		if (dictionary.ContainsKey("NEWNAME"))
		{
			string name;
			try
			{
				name = dictionary["NEWNAME"].ToString();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("无法将值NewName解析为字符串！");
			}
			mission.Name = name;
		}
		if (dictionary.ContainsKey("STARTTIME"))
		{
			DateTime? nullable_ = null;
			try
			{
				string text = dictionary["STARTTIME"].ToString();
				if (text.Length > 0)
				{
					nullable_ = Conversions.ToDate(text);
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				throw new LuaError("无法解析值StartTime！");
			}
			mission.StartTime_Set(nullable_, scenario_0);
		}
		if (dictionary.ContainsKey("ENDTIME"))
		{
			DateTime? nullable_2 = null;
			try
			{
				string text6 = dictionary["ENDTIME"].ToString();
				if (text6.Length > 0)
				{
					nullable_2 = Conversions.ToDate(text6);
				}
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				throw new LuaError("无法解析值EndTime！");
			}
			mission.EndTime_Set(nullable_2, scenario_0);
		}
		if (dictionary.ContainsKey("ISACTIVE"))
		{
			bool? flag = null;
			Mission.MissionStatus missionStatus_ = mission.GetStatus(scenario_0);
			try
			{
				flag = LuaUtility.ParseBoolean(dictionary["ISACTIVE"].ToString());
				if (flag.HasValue)
				{
					bool? flag2 = flag;
					flag2 = flag2;
					missionStatus_ = ((!flag2.GetValueOrDefault()) ? Mission.MissionStatus.Inactive : Mission.MissionStatus.Active);
				}
			}
			catch (Exception projectError4)
			{
				ProjectData.SetProjectError(projectError4);
				throw new LuaError("无法解析值IsActive！");
			}
			if (flag.HasValue)
			{
				mission.SetStatus(scenario_0, missionStatus_);
			}
		}
		if (dictionary.ContainsKey("SISH"))
		{
			bool? flag3 = null;
			try
			{
				flag3 = LuaUtility.ParseBoolean(dictionary["SISH"].ToString());
			}
			catch (Exception projectError5)
			{
				ProjectData.SetProjectError(projectError5);
				throw new LuaError("无法解析值SISH！");
			}
			if (flag3.HasValue)
			{
				mission.ScrubIfSideIsHuman = flag3.Value;
			}
		}
		if (dictionary.ContainsKey("SUBTYPE"))
		{
			try
			{
				string text7 = dictionary["SUBTYPE"].ToString();
				switch (mission.MissionClass)
				{
				case Mission._MissionClass.Cargo:
				{
					string left = text7.ToUpper();
					if (Operators.CompareString(left, "DELIVERY", TextCompare: false) == 0)
					{
						((CargoMission)mission).Type = CargoMission.CargoMissionType.Delivery;
						break;
					}
					if (Operators.CompareString(left, "TRANSFER", TextCompare: false) == 0)
					{
						((CargoMission)mission).Type = CargoMission.CargoMissionType.Transfer;
						break;
					}
					throw new LuaError("缺少任务子类型");
				}
				default:
					throw new LuaError("不能改变任务子类型");
				case Mission._MissionClass.Patrol:
					switch (text7.ToUpper())
					{
					case "SeaControl":
					case "SEA":
						((Patrol)mission).Type = GlobalVariables.PatrolType.SeaControl;
						break;
					case "SUB":
					case "ASW":
						((Patrol)mission).Type = GlobalVariables.PatrolType.ASW;
						break;
					case "SEAD":
						((Patrol)mission).Type = GlobalVariables.PatrolType.SEAD;
						break;
					case "AIR":
					case "AAW":
						((Patrol)mission).Type = GlobalVariables.PatrolType.AAW;
						break;
					case "SUR_MIXED":
					case "MIXED":
					case "ASuW_Mixed":
						((Patrol)mission).Type = GlobalVariables.PatrolType.ASuW_Mixed;
						break;
					case "ASuW_Land":
					case "LAND":
					case "SUR_LAND":
						((Patrol)mission).Type = GlobalVariables.PatrolType.ASuW_Land;
						break;
					default:
						throw new LuaError("缺少任务子类型");
					case "NAVAL":
					case "SUR_SEA":
					case "ASuW_Naval":
						((Patrol)mission).Type = GlobalVariables.PatrolType.ASuW_Naval;
						break;
					}
					break;
				case Mission._MissionClass.Strike:
					switch (text7.ToUpper())
					{
					case "Maritime_Strike":
					case "SEA":
						((Strike)mission).Type = Strike.StrikeType.Maritime_Strike;
						break;
					case "Air_Intercept":
					case "AIR":
						((Strike)mission).Type = Strike.StrikeType.Air_Intercept;
						break;
					case "Land_Strike":
					case "LAND":
						((Strike)mission).Type = Strike.StrikeType.Land_Strike;
						break;
					default:
						throw new LuaError("缺少任务子类型");
					case "SUB":
					case "Sub_Strike":
						((Strike)mission).Type = Strike.StrikeType.Sub_Strike;
						break;
					}
					break;
				}
			}
			catch (Exception projectError6)
			{
				ProjectData.SetProjectError(projectError6);
				throw new LuaError("无法解析任务子类型！");
			}
		}
		if (dictionary.ContainsKey("use_refuel_unrep".ToUpper()))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["use_refuel_unrep".ToUpper()]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				mission.Doctrine.SetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, null);
			}
			else
			{
				if (!Enum.TryParse<Doctrine._UseUnderwayRefuelAndReplenishment>(Conversions.ToString(dictionary["use_refuel_unrep".ToUpper()]), ignoreCase: true, out var result) || !Enum.IsDefined(typeof(Doctrine._UseUnderwayRefuelAndReplenishment), result))
				{
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["use_refuel_unrep"]) + "'as use_refuel_unrep允许值为：'0'，'1'，'2', 对应Always Excl Tankers，Never，Always Incl Tankers");
				}
				mission.Doctrine.SetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, result);
			}
		}
		string[] mission_Tanker = Mission_Tanker;
		checked
		{
			for (int i = 0; i < mission_Tanker.Length; i++)
			{
				string text8 = mission_Tanker[i];
				text8 = text8.ToUpper();
				string left2 = text8;
				if (Operators.CompareString(left2, "TankerUsage".ToUpper(), TextCompare: false) == 0)
				{
					if (dictionary.ContainsKey(text8))
					{
						Mission.TankerMethod result12 = Mission.TankerMethod.Automatic;
						if (Enum.TryParse<Mission.TankerMethod>(Conversions.ToString(dictionary[text8]), ignoreCase: true, out result12) && Enum.IsDefined(typeof(Mission.TankerMethod), result12))
						{
							mission.TankerUsage = result12;
						}
					}
				}
				else if (Operators.CompareString(left2, "LaunchMissionWithoutTankersInPlace".ToUpper(), TextCompare: false) == 0)
				{
					if (dictionary.ContainsKey(text8) && mission.TankerUsage == Mission.TankerMethod.Mission)
					{
						bool? flag4 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary[text8]));
						if (!Information.IsNothing(flag4))
						{
							mission.LaunchMissionWithoutTankersInPlace = flag4.Value;
						}
					}
				}
				else if (Operators.CompareString(left2, "TankerMissionList".ToUpper(), TextCompare: false) == 0)
				{
					if (!dictionary.ContainsKey(text8) || mission.TankerUsage != Mission.TankerMethod.Mission)
					{
						continue;
					}
					List<object> list = LuaUtility.ToArray(((LuaTable)dictionary[text8]).GetEnumerator());
					mission.TankerMissions.Clear();
					foreach (object item in list)
					{
						Mission mission2 = ValidateMissionBySceanrio(Conversions.ToString(RuntimeHelpers.GetObjectValue(item)), scenario_0);
						if (mission2 != null && mission2.MissionClass == Mission._MissionClass.Support)
						{
							mission.TankerMissions.Add(mission2);
						}
					}
				}
				else if (Operators.CompareString(left2, "TankerMinNumber_Total".ToUpper(), TextCompare: false) == 0)
				{
					if (dictionary.ContainsKey(text8) && mission.TankerUsage == Mission.TankerMethod.Mission)
					{
						mission.TankerMinNumber_Total = Conversions.ToInteger(dictionary[text8]);
					}
				}
				else if (Operators.CompareString(left2, "TankerMinNumber_Airborne".ToUpper(), TextCompare: false) == 0)
				{
					if (dictionary.ContainsKey(text8) && mission.TankerUsage == Mission.TankerMethod.Mission)
					{
						mission.TankerMinNumber_Airborne = Conversions.ToInteger(dictionary[text8]);
					}
				}
				else if (Operators.CompareString(left2, "TankerMinNumber_Station".ToUpper(), TextCompare: false) == 0)
				{
					if (dictionary.ContainsKey(text8) && mission.TankerUsage == Mission.TankerMethod.Mission)
					{
						mission.TankerMinNumber_Station = Conversions.ToInteger(dictionary[text8]);
					}
				}
				else if (Operators.CompareString(left2, "MaxReceiversInQueuePerTanker_Airborne".ToUpper(), TextCompare: false) == 0)
				{
					if (dictionary.ContainsKey(text8))
					{
						mission.MaxReceiversInQueuePerTanker_Airborne = Conversions.ToInteger(dictionary[text8]);
					}
				}
				else if (Operators.CompareString(left2, "FuelQtyToStartLookingForTanker_Airborne".ToUpper(), TextCompare: false) == 0)
				{
					if (dictionary.ContainsKey(text8))
					{
						int num = Conversions.ToInteger(dictionary[text8]);
						if (num > 0 && num < 100)
						{
							mission.FuelQtyToStartLookingForTanker_Airborne = num;
						}
					}
				}
				else if (Operators.CompareString(left2, "TankerMaxDistance_Airborne".ToUpper(), TextCompare: false) == 0)
				{
					if (dictionary.ContainsKey(text8))
					{
						int num2 = ((Operators.CompareString(Conversions.ToString(dictionary[text8]).ToLower(), "internal", TextCompare: false) == 0) ? int.MaxValue : Conversions.ToInteger(dictionary[text8]));
						int num3 = num2;
						if (num3 < 100)
						{
							num2 = 50;
						}
						else if (num3 < 250)
						{
							num2 = 100;
						}
						else if (num3 < 500)
						{
							num2 = 250;
						}
						else if (num3 < 1000)
						{
							num2 = 500;
						}
						mission.TankerMaxDistance_Airborne = num2;
					}
				}
				else if (Operators.CompareString(left2, "TankerFollowsReceivers".ToUpper(), TextCompare: false) == 0 && dictionary.ContainsKey(text8))
				{
					mission.TankerFollowsReceivers = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary[text8])).Value;
				}
			}
			switch (mission.MissionClass)
			{
			case Mission._MissionClass.Strike:
			{
				Strike strike = (Strike)mission;
				string[] mission_Strike = Mission_Strike;
				for (int num4 = 0; num4 < mission_Strike.Length; num4++)
				{
					string text4 = mission_Strike[num4];
					text4 = text4.ToUpper();
					if (!dictionary.ContainsKey(text4))
					{
						continue;
					}
					object objectValue6 = RuntimeHelpers.GetObjectValue(dictionary[text4]);
					string left7 = text4;
					if (Operators.CompareString(left7, "EscortFlightSizeShooter".ToUpper(), TextCompare: false) == 0)
					{
						string string_7 = Conversions.ToString(objectValue6);
						strike.Escort_FlightSize_Shooter = setFlightSize(ref string_7);
					}
					else if (Operators.CompareString(left7, "EscortFlightSizeNonShooter".ToUpper(), TextCompare: false) == 0)
					{
						string string_8 = Conversions.ToString(objectValue6);
						strike.Escort_FlightSize_NonShooter = setFlightSize(ref string_8);
					}
					else if (Operators.CompareString(left7, "EscortMaxNonShooter".ToUpper(), TextCompare: false) == 0)
					{
						string string_9 = Conversions.ToString(objectValue6);
						strike.MaximumNumberOfAircraft_Escorts_NonShooter = setFlightQty(ref string_9);
					}
					else if (Operators.CompareString(left7, "EscortMaxShooter".ToUpper(), TextCompare: false) == 0)
					{
						string string_10 = Conversions.ToString(objectValue6);
						strike.MaximumNumberOfAircraft_Escorts_Shooter = setFlightQty(ref string_10);
					}
					else if (Operators.CompareString(left7, "EscortMinShooter".ToUpper(), TextCompare: false) == 0)
					{
						string string_11 = Conversions.ToString(objectValue6);
						strike.MinimumNumberOfAircraft_Escorts_Shooter = setFlightQty(ref string_11);
					}
					else if (Operators.CompareString(left7, "EscortMinNonShooter".ToUpper(), TextCompare: false) == 0)
					{
						string string_13 = Conversions.ToString(objectValue6);
						strike.MinimumNumberOfAircraft_Escorts_NonShooter = setFlightQty(ref string_13);
					}
					else if (Operators.CompareString(left7, "EscortResponseRadius".ToUpper(), TextCompare: false) == 0)
					{
						strike.Escort_ResponseRadius = Conversions.ToInteger(objectValue6);
					}
					else if (Operators.CompareString(left7, "EscortResponseRadiusSead".ToUpper(), TextCompare: false) == 0)
					{
						strike.Escort_ResponseRadius_SEAD = Conversions.ToInteger(objectValue6);
					}
					else if (Operators.CompareString(left7, "EscortUseFlightSize".ToUpper(), TextCompare: false) == 0)
					{
						strike.UseFlightSizeHardLimit_Escort = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
					}
					else if (Operators.CompareString(left7, "EscortGroupSize".ToUpper(), TextCompare: false) == 0)
					{
						string string_14 = Conversions.ToString(objectValue6);
						strike.Escort_GroupSize = setGroupSize(ref string_14);
					}
					else if (Operators.CompareString(left7, "EscortUseGroupSize".ToUpper(), TextCompare: false) == 0)
					{
						strike.UseGroupSizeHardLimit_Escort = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
					}
					else if (Operators.CompareString(left7, "EscortResponseRadiusSead".ToUpper(), TextCompare: false) == 0)
					{
						strike.Escort_ResponseRadius_SEAD = Conversions.ToInteger(objectValue6);
					}
					else if (Operators.CompareString(left7, "StrikeOneTimeOnly".ToUpper(), TextCompare: false) == 0)
					{
						strike.OneTimeOnly = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
					}
					else if (Operators.CompareString(left7, "StrikeMinimumTrigger".ToUpper(), TextCompare: false) == 0)
					{
						string string_15 = Conversions.ToString(objectValue6);
						strike.MinimumContactStanceToTrigger = setStance(ref string_15);
					}
					else if (Operators.CompareString(left7, "StrikeMax".ToUpper(), TextCompare: false) == 0)
					{
						string string_16 = Conversions.ToString(objectValue6);
						strike.MaxFlightNumber_Strike = setFlightQty(ref string_16);
					}
					else if (Operators.CompareString(left7, "StrikeMinAircraftReq".ToUpper(), TextCompare: false) == 0)
					{
						string string_17 = Conversions.ToString(objectValue6);
						strike.MinimumNumberOfAircraft = setFlightQty(ref string_17);
					}
					else if (Operators.CompareString(left7, "StrikeFlightSize".ToUpper(), TextCompare: false) == 0)
					{
						string string_18 = Conversions.ToString(objectValue6);
						strike.FlightSize = setFlightSize(ref string_18);
					}
					else if (Operators.CompareString(left7, "StrikeUseFlightSize".ToUpper(), TextCompare: false) == 0)
					{
						strike.UseFlightSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
					}
					else if (Operators.CompareString(left7, "StrikeGroupSize".ToUpper(), TextCompare: false) == 0)
					{
						string string_19 = Conversions.ToString(objectValue6);
						strike.GroupSize = setGroupSize(ref string_19);
					}
					else if (Operators.CompareString(left7, "StrikeUseGroupSize".ToUpper(), TextCompare: false) == 0)
					{
						strike.UseGroupSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
					}
					else if (Operators.CompareString(left7, "StrikeAutoPlanner".ToUpper(), TextCompare: false) == 0)
					{
						strike.UsePlanner = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
					}
					else if (Operators.CompareString(left7, "StrikePrePlan".ToUpper(), TextCompare: false) == 0)
					{
						strike.RTB_When_Target_Destroyed = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
					}
					else if (Operators.CompareString(left7, "StrikeRadarUsage".ToUpper(), TextCompare: false) == 0)
					{
						string string_20 = Conversions.ToString(objectValue6);
						strike.RadarBehaviour = setRadarUse(ref string_20);
					}
					else if (Operators.CompareString(left7, "strikeMinDist".ToUpper(), TextCompare: false) != 0 && Operators.CompareString(left7, "strikeMinDistAircraft".ToUpper(), TextCompare: false) != 0)
					{
						if (Operators.CompareString(left7, "strikeMaxDist".ToUpper(), TextCompare: false) != 0 && Operators.CompareString(left7, "strikeMaxDistAircraft".ToUpper(), TextCompare: false) != 0)
						{
							if (Operators.CompareString(left7, "strikeMinDistShip".ToUpper(), TextCompare: false) == 0)
							{
								strike.MinResponseRadius_Ship = Conversions.ToInteger(objectValue6);
							}
							else if (Operators.CompareString(left7, "strikeMaxDistShip".ToUpper(), TextCompare: false) == 0)
							{
								strike.MaxResponseRadius_Ship = Conversions.ToInteger(objectValue6);
							}
							else if (Operators.CompareString(left7, "strikeformationcruise".ToUpper(), TextCompare: false) == 0)
							{
								if (Enum.TryParse<Mission._AircraftFormationType>(Conversions.ToString(objectValue6), ignoreCase: true, out var result10) && Enum.IsDefined(typeof(Mission._AircraftFormationType), result10))
								{
									strike.Formation_Cruise = result10;
								}
							}
							else if (Operators.CompareString(left7, "strikeformationattack".ToUpper(), TextCompare: false) == 0)
							{
								if (Enum.TryParse<Mission._AircraftFormationType>(Conversions.ToString(objectValue6), ignoreCase: true, out var result11) && Enum.IsDefined(typeof(Mission._AircraftFormationType), result11))
								{
									strike.Formation_Attack = result11;
								}
							}
							else if (Operators.CompareString(left7, "escortformationcruise".ToUpper(), TextCompare: false) == 0)
							{
								if (Enum.TryParse<Mission._AircraftFormationType>(Conversions.ToString(objectValue6), ignoreCase: true, out var result13) && Enum.IsDefined(typeof(Mission._AircraftFormationType), result13))
								{
									strike.Escort_Formation_Cruise = result13;
								}
							}
							else if (Operators.CompareString(left7, "escortformationattack".ToUpper(), TextCompare: false) == 0)
							{
								if (Enum.TryParse<Mission._AircraftFormationType>(Conversions.ToString(objectValue6), ignoreCase: true, out var result14) && Enum.IsDefined(typeof(Mission._AircraftFormationType), result14))
								{
									strike.Escort_Formation_Attack = result14;
								}
							}
							else if (Operators.CompareString(left7, "flightstoinvestigate".ToUpper(), TextCompare: false) == 0)
							{
								string string_21 = Conversions.ToString(objectValue6);
								strike.Escort_NumberOfFlights_Investigate = setFlightQty(ref string_21);
							}
							else if (Operators.CompareString(left7, "flightstoengage".ToUpper(), TextCompare: false) == 0)
							{
								string string_22 = Conversions.ToString(objectValue6);
								strike.Escort_NumberOfFlights_Engage = setFlightQty(ref string_22);
							}
							else if (Operators.CompareString(left7, "wingmanengagedistance".ToUpper(), TextCompare: false) == 0)
							{
								int result15 = 0;
								int.TryParse(Conversions.ToString(objectValue6), out result15);
								strike.Escort_WingmanEngageDistance = result15;
							}
							else if (Operators.CompareString(left7, "boatstoinvestigate".ToUpper(), TextCompare: false) == 0)
							{
								if (Enum.TryParse<Mission._GroupQty>(Conversions.ToString(objectValue6), ignoreCase: true, out var result16) && Enum.IsDefined(typeof(Mission._GroupQty), result16))
								{
									strike.Escort_NumberOfBoats_Investigate = result16;
								}
							}
							else if (Operators.CompareString(left7, "boatstoengage".ToUpper(), TextCompare: false) == 0)
							{
								if (Enum.TryParse<Mission._GroupQty>(Conversions.ToString(objectValue6), ignoreCase: true, out var result17) && Enum.IsDefined(typeof(Mission._GroupQty), result17))
								{
									strike.Escort_NumberOfBoats_Engage = result17;
								}
							}
							else if (Operators.CompareString(left7, "groupmemberengagedistance".ToUpper(), TextCompare: false) == 0)
							{
								int result18 = 0;
								int.TryParse(Conversions.ToString(objectValue6), out result18);
								strike.Escort_GroupMemberEngageDistance = result18;
							}
							else if (Operators.CompareString(left7, "EscortTransitThrottle".ToUpper(), TextCompare: false) == 0)
							{
								strike.Escort_TransitThrottle = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue6));
							}
							else if (Operators.CompareString(left7, "EscortTransitAltitude".ToUpper(), TextCompare: false) == 0)
							{
								strike.Escort_TransitAltitude = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue6));
							}
							else if (Operators.CompareString(left7, "EscortTransitTerrainFollowing".ToUpper(), TextCompare: false) == 0)
							{
								strike.Escort_TransitTerrainFollowing = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue6)).Value;
							}
						}
						else
						{
							strike.MaxResponseRadius_Aircraft = Conversions.ToInteger(objectValue6);
						}
					}
					else
					{
						strike.MinResponseRadius_Aircraft = Conversions.ToInteger(objectValue6);
					}
				}
				break;
			}
			case Mission._MissionClass.Patrol:
			{
				Patrol patrol = (Patrol)mission;
				string[] mission_Patrol = Mission_Patrol;
				for (int k = 0; k < mission_Patrol.Length; k++)
				{
					string text11 = mission_Patrol[k];
					text11 = text11.ToUpper();
					if (!dictionary.ContainsKey(text11))
					{
						continue;
					}
					object objectValue2 = RuntimeHelpers.GetObjectValue(dictionary[text11]);
					string left4 = text11;
					if (Operators.CompareString(left4, "OneThirdRule".ToUpper(), TextCompare: false) == 0)
					{
						patrol.OneThirdRule = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "OnStation".ToUpper(), TextCompare: false) == 0)
					{
						patrol.MinimumNumberOnStation = Conversions.ToInteger(objectValue2);
					}
					else if (Operators.CompareString(left4, "CheckOPA".ToUpper(), TextCompare: false) == 0)
					{
						patrol.SetInvestigateOutsidePatrolArea(scenario_0, LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue2)).Value);
					}
					else if (Operators.CompareString(left4, "CheckWWR".ToUpper(), TextCompare: false) == 0)
					{
						patrol.SetInvestigateWithinWeaponRange(scenario_0, LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue2)).Value);
					}
					else if (Operators.CompareString(left4, "ActiveEMCON".ToUpper(), TextCompare: false) == 0)
					{
						patrol.ActiveEMCONOnlyInPatrolOrProsecutionArea = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "LoopType".ToUpper(), TextCompare: false) == 0)
					{
						if (Enum.TryParse<Patrol.PatrolMovementStyle>(Conversions.ToString(objectValue2), ignoreCase: true, out var result20) && Enum.IsDefined(typeof(Patrol.PatrolMovementStyle), result20))
						{
							patrol.MovementStyle = result20;
						}
					}
					else if (Operators.CompareString(left4, "TransitThrottleAircraft".ToUpper(), TextCompare: false) == 0)
					{
						patrol.TransitThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue2));
					}
					else if (Operators.CompareString(left4, "TransitAltitudeAircraft".ToUpper(), TextCompare: false) == 0)
					{
						patrol.TransitAltitude_Aircraft = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue2));
						patrol.UseTransitAltitude_Preset = false;
						patrol.TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
					}
					else if (Operators.CompareString(left4, "TransitTerrainFollowingAircraft".ToUpper(), TextCompare: false) == 0)
					{
						patrol.TransitTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "StationThrottleAircraft".ToUpper(), TextCompare: false) == 0)
					{
						patrol.StationThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue2));
					}
					else if (Operators.CompareString(left4, "StationAltitudeAircraft".ToUpper(), TextCompare: false) == 0)
					{
						patrol.StationAltitude_Aircraft = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue2));
						patrol.UseStationAltitude_Preset = false;
						patrol.StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
					}
					else if (Operators.CompareString(left4, "StationTerrainFollowingAircraft".ToUpper(), TextCompare: false) == 0)
					{
						patrol.StationTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "AttackThrottleAircraft".ToUpper(), TextCompare: false) == 0)
					{
						patrol.AttackThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue2));
					}
					else if (Operators.CompareString(left4, "AttackAltitudeAircraft".ToUpper(), TextCompare: false) == 0)
					{
						patrol.AttackAltitude_Aircraft = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue2));
						patrol.UseAttackAltitude_Preset = false;
						patrol.AttackAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
					}
					else if (Operators.CompareString(left4, "AttackTerrainFollowingAircraft".ToUpper(), TextCompare: false) == 0)
					{
						patrol.AttackTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "useattackaltitudepreset".ToUpper(), TextCompare: false) == 0)
					{
						patrol.UseAttackAltitude_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "usetransitaltitudepreset".ToUpper(), TextCompare: false) == 0)
					{
						patrol.UseTransitAltitude_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "usestationaltitudepreset".ToUpper(), TextCompare: false) == 0)
					{
						patrol.UseStationAltitude_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "AttackDistanceAircraft".ToUpper(), TextCompare: false) == 0)
					{
						int result21 = 0;
						int.TryParse(Conversions.ToString(objectValue2), out result21);
						patrol.AttackDistance_Aircraft = result21;
					}
					else if (Operators.CompareString(left4, "TransitThrottleSubmarine".ToUpper(), TextCompare: false) == 0)
					{
						patrol.TransitThrottle_Submarine = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "TransitDepthSubmarine".ToUpper(), TextCompare: false) == 0)
					{
						patrol.TransitDepth_Submarine = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue2));
						patrol.UseTransitDepth_Submarine_Preset = false;
						patrol.TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
					}
					else if (Operators.CompareString(left4, "StationThrottleSubmarine".ToUpper(), TextCompare: false) == 0)
					{
						patrol.StationThrottle_Submarine = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "StationDepthSubmarine".ToUpper(), TextCompare: false) == 0)
					{
						patrol.StationDepth_Submarine = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue2));
						patrol.UseStationDepth_Submarine_Preset = false;
						patrol.StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
					}
					else if (Operators.CompareString(left4, "AttackThrottleSubmarine".ToUpper(), TextCompare: false) == 0)
					{
						patrol.AttackThrottle_Submarine = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue2));
					}
					else if (Operators.CompareString(left4, "AttackDepthSubmarine".ToUpper(), TextCompare: false) == 0)
					{
						patrol.AttackDepth_Submarine = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue2));
						patrol.UseAttackDepth_Submarine_Preset = false;
						patrol.AttackDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
					}
					else if (Operators.CompareString(left4, "StationDepthSubmarinePreset".ToUpper(), TextCompare: false) == 0)
					{
						patrol.StationDepth_Submarine_Preset = LuaUtility.QueryDepthPresetObject(Conversions.ToString(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "AttackDepthSubmarinePreset".ToUpper(), TextCompare: false) == 0)
					{
						patrol.AttackDepth_Submarine_Preset = LuaUtility.QueryDepthPresetObject(Conversions.ToString(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "TransitDepthSubmarinePreset".ToUpper(), TextCompare: false) == 0)
					{
						patrol.TransitDepth_Submarine_Preset = LuaUtility.QueryDepthPresetObject(Conversions.ToString(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "useAttackDepthSubmarinePreset".ToUpper(), TextCompare: false) == 0)
					{
						patrol.UseAttackDepth_Submarine_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "useTransitDepthSubmarinePreset".ToUpper(), TextCompare: false) == 0)
					{
						patrol.UseTransitDepth_Submarine_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "useStationDepthSubmarinePreset".ToUpper(), TextCompare: false) == 0)
					{
						patrol.UseStationDepth_Submarine_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "AttackDistanceSubmarine".ToUpper(), TextCompare: false) == 0)
					{
						int result22 = 0;
						int.TryParse(Conversions.ToString(objectValue2), out result22);
						patrol.AttackDistance_Submarine = result22;
					}
					else if (Operators.CompareString(left4, "TransitThrottleShip".ToUpper(), TextCompare: false) == 0)
					{
						patrol.TransitThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "StationThrottleShip".ToUpper(), TextCompare: false) == 0)
					{
						patrol.StationThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "AttackThrottleShip".ToUpper(), TextCompare: false) == 0)
					{
						patrol.AttackThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue2));
					}
					else if (Operators.CompareString(left4, "AttackDistanceShip".ToUpper(), TextCompare: false) == 0)
					{
						int result23 = 0;
						int.TryParse(Conversions.ToString(objectValue2), out result23);
						patrol.AttackDistance_Ship = result23;
					}
					else if (Operators.CompareString(left4, "GroupSize".ToUpper(), TextCompare: false) == 0)
					{
						string string_12 = Conversions.ToString(objectValue2);
						patrol.GroupSize = setGroupSize(ref string_12);
					}
					else if (Operators.CompareString(left4, "FlightSize".ToUpper(), TextCompare: false) == 0)
					{
						string string_23 = Conversions.ToString(objectValue2);
						patrol.FlightSize = setFlightSize(ref string_23);
					}
					else if (Operators.CompareString(left4, "MinAircraftReq".ToUpper(), TextCompare: false) == 0)
					{
						string string_26 = Conversions.ToString(objectValue2);
						patrol.MinimumNumberOfAircraft = setFlightQty(ref string_26);
					}
					else if (Operators.CompareString(left4, "UseFlightSize".ToUpper(), TextCompare: false) == 0)
					{
						patrol.UseFlightSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "UseGroupSize".ToUpper(), TextCompare: false) == 0)
					{
						patrol.UseGroupSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "PatrolZone".ToUpper(), TextCompare: false) == 0)
					{
						List<ReferencePoint> list3 = new List<ReferencePoint>();
						foreach (object item2 in LuaUtility.ToArray(((LuaTable)dictionary["PATROLZONE"]).GetEnumerator()))
						{
							object Local_o5 = RuntimeHelpers.GetObjectValue(item2);
							ReferencePoint referencePoint2 = null;
							if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => Operators.CompareString(s.Name, Local_o5.ToString(), TextCompare: false) == 0)))
							{
								if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o5.ToString(), StringComparison.OrdinalIgnoreCase))))
								{
									if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o5.ToString(), StringComparison.OrdinalIgnoreCase))))
									{
										if (!Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o5.ToString(), StringComparison.OrdinalIgnoreCase))))
										{
											referencePoint2 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o5.ToString(), StringComparison.OrdinalIgnoreCase));
										}
									}
									else
									{
										referencePoint2 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o5.ToString(), StringComparison.OrdinalIgnoreCase));
									}
								}
								else
								{
									referencePoint2 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.Name, Local_o5.ToString(), StringComparison.OrdinalIgnoreCase));
								}
							}
							else
							{
								referencePoint2 = side.RefPoints.First((ReferencePoint s) => Operators.CompareString(s.Name, Local_o5.ToString(), TextCompare: false) == 0);
							}
							if (!Information.IsNothing(referencePoint2))
							{
								list3.Add(referencePoint2);
							}
						}
						patrol.PatrolArea = list3;
					}
					else if (Operators.CompareString(left4, "ProsecutionZone".ToUpper(), TextCompare: false) == 0)
					{
						List<ReferencePoint> list4 = new List<ReferencePoint>();
						foreach (object item3 in LuaUtility.ToArray(((LuaTable)dictionary["ProsecutionZone".ToUpper()]).GetEnumerator()))
						{
							object Local_o4 = RuntimeHelpers.GetObjectValue(item3);
							ReferencePoint referencePoint3 = null;
							if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => Operators.CompareString(s.Name, Local_o4.ToString(), TextCompare: false) == 0)))
							{
								if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o4.ToString(), StringComparison.OrdinalIgnoreCase))))
								{
									if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o4.ToString(), StringComparison.OrdinalIgnoreCase))))
									{
										if (!Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o4.ToString(), StringComparison.OrdinalIgnoreCase))))
										{
											referencePoint3 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o4.ToString(), StringComparison.OrdinalIgnoreCase));
										}
									}
									else
									{
										referencePoint3 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o4.ToString(), StringComparison.OrdinalIgnoreCase));
									}
								}
								else
								{
									referencePoint3 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.Name, Local_o4.ToString(), StringComparison.OrdinalIgnoreCase));
								}
							}
							else
							{
								referencePoint3 = side.RefPoints.First((ReferencePoint s) => Operators.CompareString(s.Name, Local_o4.ToString(), TextCompare: false) == 0);
							}
							if (!Information.IsNothing(referencePoint3))
							{
								list4.Add(referencePoint3);
							}
						}
						patrol.ProsecutionArea = list4;
					}
					else if (Operators.CompareString(left4, "transitthrottlefacility".ToUpper(), TextCompare: false) == 0)
					{
						patrol.TransitThrottle_Facility = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "stationthrottlefacility".ToUpper(), TextCompare: false) == 0)
					{
						patrol.StationThrottle_Facility = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "formationcruise".ToUpper(), TextCompare: false) == 0)
					{
						if (Enum.TryParse<Mission._AircraftFormationType>(Conversions.ToString(objectValue2), ignoreCase: true, out var result24) && Enum.IsDefined(typeof(Mission._AircraftFormationType), result24))
						{
							patrol.Formation_Cruise = result24;
						}
					}
					else if (Operators.CompareString(left4, "formationattack".ToUpper(), TextCompare: false) == 0)
					{
						if (Enum.TryParse<Mission._AircraftFormationType>(Conversions.ToString(objectValue2), ignoreCase: true, out var result25) && Enum.IsDefined(typeof(Mission._AircraftFormationType), result25))
						{
							patrol.Formation_Attack = result25;
						}
					}
					else if (Operators.CompareString(left4, "flightstoinvestigate".ToUpper(), TextCompare: false) == 0)
					{
						string string_27 = Conversions.ToString(objectValue2);
						patrol.NumberOfFlights_Investigate = setFlightQty(ref string_27);
					}
					else if (Operators.CompareString(left4, "flightstoengage".ToUpper(), TextCompare: false) == 0)
					{
						string string_28 = Conversions.ToString(objectValue2);
						patrol.NumberOfFlights_Engage = setFlightQty(ref string_28);
					}
					else if (Operators.CompareString(left4, "wingmanengagedistance".ToUpper(), TextCompare: false) == 0)
					{
						int result26 = 0;
						int.TryParse(Conversions.ToString(objectValue2), out result26);
						patrol.WingmanEngageDistance = result26;
					}
					else if (Operators.CompareString(left4, "boatstoinvestigate".ToUpper(), TextCompare: false) == 0)
					{
						if (Enum.TryParse<Mission._GroupQty>(Conversions.ToString(objectValue2), ignoreCase: true, out var result2) && Enum.IsDefined(typeof(Mission._GroupQty), result2))
						{
							patrol.NumberOfBoats_Investigate = result2;
						}
					}
					else if (Operators.CompareString(left4, "boatstoengage".ToUpper(), TextCompare: false) == 0)
					{
						if (Enum.TryParse<Mission._GroupQty>(Conversions.ToString(objectValue2), ignoreCase: true, out var result3) && Enum.IsDefined(typeof(Mission._GroupQty), result3))
						{
							patrol.NumberOfBoats_Engage = result3;
						}
					}
					else if (Operators.CompareString(left4, "groupmemberengagedistance".ToUpper(), TextCompare: false) == 0)
					{
						int result4 = 0;
						int.TryParse(Conversions.ToString(objectValue2), out result4);
						patrol.GroupMemberEngageDistance = result4;
					}
					else if (Operators.CompareString(left4, "SprintDrift".ToUpper(), TextCompare: false) == 0)
					{
						patrol.SprintAndDrift = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue2)).Value;
					}
					else if (Operators.CompareString(left4, "AvoidCavitation".ToUpper(), TextCompare: false) == 0)
					{
						patrol.AvoidCavitation = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue2)).Value;
					}
				}
				break;
			}
			case Mission._MissionClass.Support:
			{
				SupportMission supportMission = (SupportMission)mission;
				string[] mission_Support = Mission_Support;
				for (int m = 0; m < mission_Support.Length; m++)
				{
					string text13 = mission_Support[m];
					text13 = text13.ToUpper();
					if (!dictionary.ContainsKey(text13))
					{
						continue;
					}
					object objectValue4 = RuntimeHelpers.GetObjectValue(dictionary[text13]);
					string text2 = text13;
					if (Operators.CompareString(text2, "LoopType".ToUpper(), TextCompare: false) == 0)
					{
						SupportMission.SupportMissionNavigationLoopType result6 = SupportMission.SupportMissionNavigationLoopType.ContinousLoop;
						if (Enum.TryParse<SupportMission.SupportMissionNavigationLoopType>(Conversions.ToString(objectValue4), ignoreCase: true, out result6) && Enum.IsDefined(typeof(SupportMission.SupportMissionNavigationLoopType), result6))
						{
							supportMission.NavigationLoopType = result6;
						}
						continue;
					}
					if (Operators.CompareString(text2, "OneTimeOnly".ToUpper(), TextCompare: false) == 0)
					{
						supportMission.OneTimeOnly = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
						continue;
					}
					if (Operators.CompareString(text2, "OneThirdRule".ToUpper(), TextCompare: false) == 0)
					{
						supportMission.OneThirdRule = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
						continue;
					}
					if (Operators.CompareString(text2, "ActiveEMCON".ToUpper(), TextCompare: false) == 0)
					{
						supportMission.ActiveEMCONOnlyOnStation = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
						continue;
					}
					if (Operators.CompareString(text2, "TankerOneTime".ToUpper(), TextCompare: false) == 0)
					{
						supportMission.A2AR_OneTankingCycleOnly = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
						continue;
					}
					if (Operators.CompareString(text2, "TankerMaxReceivers".ToUpper(), TextCompare: false) == 0)
					{
						supportMission.A2AR_MaxNumberOfReceiversPerTanker = Conversions.ToInteger(objectValue4);
						continue;
					}
					if (Operators.CompareString(text2, "OnStation".ToUpper(), TextCompare: false) == 0)
					{
						supportMission.MinimumNumberOnStation = Conversions.ToInteger(objectValue4);
						continue;
					}
					if (Operators.CompareString(text2, "TransitThrottleAircraft".ToUpper(), TextCompare: false) == 0)
					{
						supportMission.TransitThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4));
						continue;
					}
					if (Operators.CompareString(text2, "TransitAltitudeAircraft".ToUpper(), TextCompare: false) == 0)
					{
						supportMission.TransitAltitude_Aircraft = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue4));
						supportMission.UseTransitAltitude_Preset = false;
						supportMission.TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
						continue;
					}
					if (Operators.CompareString(text2, "TransitTerrainFollowingAircraft".ToUpper(), TextCompare: false) == 0)
					{
						supportMission.TransitTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
						continue;
					}
					if (Operators.CompareString(text2, "StationThrottleAircraft".ToUpper(), TextCompare: false) == 0)
					{
						supportMission.StationThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4));
						continue;
					}
					if (Operators.CompareString(text2, "StationAltitudeAircraft".ToUpper(), TextCompare: false) == 0)
					{
						supportMission.StationAltitude_Aircraft = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue4));
						supportMission.UseStationAltitude_Preset = false;
						supportMission.StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
						continue;
					}
					if (Operators.CompareString(text2, "StationTerrainFollowingAircraft".ToUpper(), TextCompare: false) == 0)
					{
						supportMission.StationTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
						continue;
					}
					unchecked
					{
						if (Operators.CompareString(text2, "TransitAltitudePreset".ToUpper(), TextCompare: false) == 0)
						{
							supportMission.TransitAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4)).Value;
							continue;
						}
						if (Operators.CompareString(text2, "StationAltitudePreset".ToUpper(), TextCompare: false) == 0)
						{
							supportMission.StationAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4)).Value;
							continue;
						}
						if (Operators.CompareString(text2, "UseStationAltitudePreset".ToUpper(), TextCompare: false) == 0)
						{
							supportMission.UseStationAltitude_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
							continue;
						}
						if (Operators.CompareString(text2, "UseTransitAltitudePreset".ToUpper(), TextCompare: false) == 0)
						{
							supportMission.UseTransitAltitude_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
							continue;
						}
						if (Operators.CompareString(text2, "TransitThrottleSubmarine".ToUpper(), TextCompare: false) == 0)
						{
							supportMission.TransitThrottle_Submarine = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4)).Value;
							continue;
						}
						if (Operators.CompareString(text2, "TransitDepthSubmarine".ToUpper(), TextCompare: false) == 0)
						{
							supportMission.TransitDepth_Submarine = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue4));
							supportMission.UseTransitDepth_Submarine_Preset = false;
							supportMission.TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
							continue;
						}
						if (Operators.CompareString(text2, "StationThrottleSubmarine".ToUpper(), TextCompare: false) == 0)
						{
							supportMission.StationThrottle_Submarine = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4)).Value;
							continue;
						}
						if (Operators.CompareString(text2, "StationDepthSubmarine".ToUpper(), TextCompare: false) == 0)
						{
							supportMission.StationDepth_Submarine = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue4));
							supportMission.UseStationDepth_Submarine_Preset = false;
							supportMission.StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
							continue;
						}
						if (Operators.CompareString(text2, "StationDepthSubmarinePreset".ToUpper(), TextCompare: false) == 0)
						{
							supportMission.StationDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4)).Value;
							continue;
						}
						if (Operators.CompareString(text2, "TransitDepthSubmarinePreset".ToUpper(), TextCompare: false) == 0)
						{
							supportMission.TransitDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4)).Value;
							continue;
						}
						if (Operators.CompareString(text2, "UseStationDepthSubmarinePreset".ToUpper(), TextCompare: false) == 0)
						{
							supportMission.UseStationDepth_Submarine_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
							continue;
						}
						if (Operators.CompareString(text2, "UseTransitDepthSubmarinePreset".ToUpper(), TextCompare: false) == 0)
						{
							supportMission.UseTransitDepth_Submarine_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
							continue;
						}
						if (Operators.CompareString(text2, "TransitThrottleShip".ToUpper(), TextCompare: false) == 0)
						{
							supportMission.TransitThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4)).Value;
							continue;
						}
						if (Operators.CompareString(text2, "StationThrottleShip".ToUpper(), TextCompare: false) == 0)
						{
							supportMission.StationThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4)).Value;
							continue;
						}
						if (Operators.CompareString(text2, "GroupSize".ToUpper(), TextCompare: false) == 0)
						{
							string string_31 = Conversions.ToString(objectValue4);
							supportMission.GroupSize = setGroupSize(ref string_31);
							continue;
						}
						if (Operators.CompareString(text2, "FlightSize".ToUpper(), TextCompare: false) == 0)
						{
							string string_2 = Conversions.ToString(objectValue4);
							supportMission.FlightSize = setFlightSize(ref string_2);
							continue;
						}
						if (Operators.CompareString(text2, "MinAircraftReq".ToUpper(), TextCompare: false) == 0)
						{
							string string_3 = Conversions.ToString(objectValue4);
							supportMission.MinimumNumberOfAircraft = setFlightQty(ref string_3);
							continue;
						}
						if (Operators.CompareString(text2, "UseFlightSize".ToUpper(), TextCompare: false) == 0)
						{
							supportMission.UseFlightSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
							continue;
						}
						if (Operators.CompareString(text2, "UseGroupSize".ToUpper(), TextCompare: false) == 0)
						{
							supportMission.UseGroupSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
							continue;
						}
						if (Operators.CompareString(text2, "Zone".ToUpper(), TextCompare: false) != 0 && Operators.CompareString(text2, "Course".ToUpper(), TextCompare: false) != 0)
						{
							switch (text2)
							{
							case "transitthrottlefacility":
								supportMission.TransitThrottle_Facility = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4)).Value;
								break;
							case "ccenable":
								supportMission.ContinousCoverage_Enable = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
								break;
							case "ccstationtime":
							{
								Mission._ContinousCoverageStationTime result8 = Mission._ContinousCoverageStationTime.min_15;
								if (Enum.TryParse<Mission._ContinousCoverageStationTime>(Conversions.ToString(objectValue4), ignoreCase: true, out result8) && Enum.IsDefined(typeof(Mission._ContinousCoverageStationTime), result8))
								{
									supportMission.ContinousCoverage_StationTime = result8;
								}
								break;
							}
							case "ccflightgenmethod":
							{
								Mission._ContinousCoverageMethod result9 = Mission._ContinousCoverageMethod.Dynamic;
								if (Enum.TryParse<Mission._ContinousCoverageMethod>(Conversions.ToString(objectValue4), ignoreCase: true, out result9) && Enum.IsDefined(typeof(Mission._ContinousCoverageMethod), result9))
								{
									supportMission.ContinousCoverage_QRAFlightGenerationMethod = result9;
								}
								break;
							}
							case "ccallowqra":
								supportMission.ContinousCoverage_QRAEnable = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue4)).Value;
								break;
							case "ccoverlap":
							{
								Mission._ContinousCoverageOverlap result7 = Mission._ContinousCoverageOverlap.None;
								if (Enum.TryParse<Mission._ContinousCoverageOverlap>(Conversions.ToString(objectValue4), ignoreCase: true, out result7) && Enum.IsDefined(typeof(Mission._ContinousCoverageOverlap), result7))
								{
									supportMission.ContinousCoverage_Overlap = result7;
								}
								break;
							}
							case "stationthrottleshipfacility":
								supportMission.StationThrottle_Facility = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue4)).Value;
								break;
							}
							continue;
						}
						List<ReferencePoint> list6 = new List<ReferencePoint>();
						foreach (object item4 in LuaUtility.ToArray(((LuaTable)dictionary["ZONE"]).GetEnumerator()))
						{
							object Local_o6 = RuntimeHelpers.GetObjectValue(item4);
							ReferencePoint referencePoint5 = null;
							if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => Operators.CompareString(s.Name, Local_o6.ToString(), TextCompare: false) == 0)))
							{
								if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o6.ToString(), StringComparison.OrdinalIgnoreCase))))
								{
									if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o6.ToString(), StringComparison.OrdinalIgnoreCase))))
									{
										if (!Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o6.ToString(), StringComparison.OrdinalIgnoreCase))))
										{
											referencePoint5 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o6.ToString(), StringComparison.OrdinalIgnoreCase));
										}
									}
									else
									{
										referencePoint5 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o6.ToString(), StringComparison.OrdinalIgnoreCase));
									}
								}
								else
								{
									referencePoint5 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.Name, Local_o6.ToString(), StringComparison.OrdinalIgnoreCase));
								}
							}
							else
							{
								referencePoint5 = side.RefPoints.First((ReferencePoint s) => Operators.CompareString(s.Name, Local_o6.ToString(), TextCompare: false) == 0);
							}
							if (!Information.IsNothing(referencePoint5))
							{
								list6.Add(referencePoint5);
							}
						}
						supportMission.NavigationCourse = list6;
					}
				}
				break;
			}
			case Mission._MissionClass.Ferry:
			{
				FerryMission ferryMission = (FerryMission)mission;
				string[] mission_Ferry = Mission_Ferry;
				for (int num5 = 0; num5 < mission_Ferry.Length; num5++)
				{
					string text5 = mission_Ferry[num5];
					text5 = text5.ToUpper();
					if (!dictionary.ContainsKey(text5))
					{
						continue;
					}
					object objectValue7 = RuntimeHelpers.GetObjectValue(dictionary[text5]);
					string left8 = text5;
					if (Operators.CompareString(left8, "FerryBehavior".ToUpper(), TextCompare: false) == 0)
					{
						FerryMission.FerryMissionBehavior result19 = FerryMission.FerryMissionBehavior.OneWay;
						if (Enum.TryParse<FerryMission.FerryMissionBehavior>(Conversions.ToString(objectValue7), ignoreCase: true, out result19) && Enum.IsDefined(typeof(FerryMission.FerryMissionBehavior), result19))
						{
							ferryMission.Behavior = result19;
						}
					}
					else if (Operators.CompareString(left8, "FerryThrottleAircraft".ToUpper(), TextCompare: false) == 0)
					{
						ferryMission.FerryThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue7));
					}
					else if (Operators.CompareString(left8, "FerryAltitudeAircraft".ToUpper(), TextCompare: false) == 0)
					{
						ferryMission.FerryAltitude_Aircraft = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue7));
					}
					else if (Operators.CompareString(left8, "FerryTerrainFollowingAircraft".ToUpper(), TextCompare: false) == 0)
					{
						ferryMission.FerryTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue7)).Value;
					}
					else if (Operators.CompareString(left8, "FlightSize".ToUpper(), TextCompare: false) == 0)
					{
						string string_24 = Conversions.ToString(objectValue7);
						ferryMission.FlightSize = setFlightSize(ref string_24);
					}
					else if (Operators.CompareString(left8, "MinAircraftReq".ToUpper(), TextCompare: false) == 0)
					{
						string string_25 = Conversions.ToString(objectValue7);
						ferryMission.MinimumNumberOfAircraft = setFlightQty(ref string_25);
					}
					else if (Operators.CompareString(left8, "UseFlightSize".ToUpper(), TextCompare: false) == 0)
					{
						ferryMission.UseFlightSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue7)).Value;
					}
				}
				break;
			}
			case Mission._MissionClass.Mining:
			{
				MiningMission miningMission = (MiningMission)mission;
				string[] mission_Mining = Mission_Mining;
				for (int n = 0; n < mission_Mining.Length; n++)
				{
					string text3 = mission_Mining[n];
					text3 = text3.ToUpper();
					if (!dictionary.ContainsKey(text3))
					{
						continue;
					}
					object objectValue5 = RuntimeHelpers.GetObjectValue(dictionary[text3]);
					string left6 = text3;
					unchecked
					{
						if (Operators.CompareString(left6, "OneThirdRule".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.OneThirdRule = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue5)).Value;
						}
						else if (Operators.CompareString(left6, "ArmingDelay".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.ArmDelay = LuaUtility.ParseDateAsSeconds(Conversions.ToString(objectValue5));
						}
						else if (Operators.CompareString(left6, "TransitThrottleAircraft".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.TransitThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue5));
						}
						else if (Operators.CompareString(left6, "TransitAltitudeAircraft".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.TransitAltitude_Aircraft = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue5));
							miningMission.UseTransitAltitude_Preset = false;
							miningMission.TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
						}
						else if (Operators.CompareString(left6, "TransitTerrainFollowingAircraft".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.TransitTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue5)).Value;
						}
						else if (Operators.CompareString(left6, "StationThrottleAircraft".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.StationThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue5));
						}
						else if (Operators.CompareString(left6, "StationAltitudeAircraft".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.StationAltitude_Aircraft = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue5));
							miningMission.UseStationAltitude_Preset = false;
							miningMission.StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
						}
						else if (Operators.CompareString(left6, "StationTerrainFollowingAircraft".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.StationTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue5)).Value;
						}
						else if (Operators.CompareString(left6, "TransitAltitudePreset".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.TransitAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue5)).Value;
						}
						else if (Operators.CompareString(left6, "StationAltitudePreset".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.StationAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue5)).Value;
						}
						else if (Operators.CompareString(left6, "UseStationAltitudePreset".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.UseStationAltitude_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue5)).Value;
						}
						else if (Operators.CompareString(left6, "UseTransitAltitudePreset".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.UseTransitAltitude_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue5)).Value;
						}
						else if (Operators.CompareString(left6, "TransitThrottleSubmarine".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.TransitThrottle_Submarine = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue5)).Value;
						}
						else if (Operators.CompareString(left6, "TransitDepthSubmarine".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.TransitDepth_Submarine = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue5));
							miningMission.UseTransitDepth_Submarine_Preset = false;
							miningMission.TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
						}
						else if (Operators.CompareString(left6, "StationThrottleSubmarine".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.StationThrottle_Submarine = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue5)).Value;
						}
						else if (Operators.CompareString(left6, "StationDepthSubmarine".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.StationDepth_Submarine = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue5));
							miningMission.UseStationDepth_Submarine_Preset = false;
							miningMission.StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
						}
						else if (Operators.CompareString(left6, "StationDepthSubmarinePreset".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.StationDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue5)).Value;
						}
						else if (Operators.CompareString(left6, "TransitDepthSubmarinePreset".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.TransitDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue5)).Value;
						}
						else if (Operators.CompareString(left6, "UseStationDepthSubmarinePreset".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.UseStationDepth_Submarine_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue5)).Value;
						}
						else if (Operators.CompareString(left6, "UseTransitDepthSubmarinePreset".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.UseTransitDepth_Submarine_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue5)).Value;
						}
						else if (Operators.CompareString(left6, "TransitThrottleShip".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.TransitThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue5)).Value;
						}
						else if (Operators.CompareString(left6, "StationThrottleShip".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.StationThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue5)).Value;
						}
						else if (Operators.CompareString(left6, "GroupSize".ToUpper(), TextCompare: false) == 0)
						{
							string string_4 = Conversions.ToString(objectValue5);
							miningMission.GroupSize = setGroupSize(ref string_4);
						}
						else if (Operators.CompareString(left6, "FlightSize".ToUpper(), TextCompare: false) == 0)
						{
							string string_5 = Conversions.ToString(objectValue5);
							miningMission.FlightSize = setFlightSize(ref string_5);
						}
						else if (Operators.CompareString(left6, "MinAircraftReq".ToUpper(), TextCompare: false) == 0)
						{
							string string_6 = Conversions.ToString(objectValue5);
							miningMission.MinimumNumberOfAircraft = setFlightQty(ref string_6);
						}
						else if (Operators.CompareString(left6, "UseFlightSize".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.UseFlightSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue5)).Value;
						}
						else if (Operators.CompareString(left6, "UseGroupSize".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.UseGroupSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue5)).Value;
						}
						else if (Operators.CompareString(left6, "Zone".ToUpper(), TextCompare: false) == 0)
						{
							List<ReferencePoint> list7 = new List<ReferencePoint>();
							foreach (object item5 in LuaUtility.ToArray(((LuaTable)dictionary["ZONE"]).GetEnumerator()))
							{
								object Local_o3 = RuntimeHelpers.GetObjectValue(item5);
								ReferencePoint referencePoint6 = null;
								if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => Operators.CompareString(s.Name, Local_o3.ToString(), TextCompare: false) == 0)))
								{
									if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o3.ToString(), StringComparison.OrdinalIgnoreCase))))
									{
										if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o3.ToString(), StringComparison.OrdinalIgnoreCase))))
										{
											if (!Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o3.ToString(), StringComparison.OrdinalIgnoreCase))))
											{
												referencePoint6 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o3.ToString(), StringComparison.OrdinalIgnoreCase));
											}
										}
										else
										{
											referencePoint6 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o3.ToString(), StringComparison.OrdinalIgnoreCase));
										}
									}
									else
									{
										referencePoint6 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.Name, Local_o3.ToString(), StringComparison.OrdinalIgnoreCase));
									}
								}
								else
								{
									referencePoint6 = side.RefPoints.First((ReferencePoint s) => Operators.CompareString(s.Name, Local_o3.ToString(), TextCompare: false) == 0);
								}
								if (!Information.IsNothing(referencePoint6))
								{
									list7.Add(referencePoint6);
								}
							}
							miningMission.Area = list7;
						}
						else if (Operators.CompareString(left6, "MinesLaidInSet".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.MinesLaidInSets = Conversions.ToInteger(objectValue5);
						}
						else if (Operators.CompareString(left6, "MinesLaidInterval".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.MinesLaidInterval = Conversions.ToInteger(objectValue5);
						}
						else if (Operators.CompareString(left6, "MinesLaidSetInterval".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.MinesLaidSetInterval = Conversions.ToInteger(objectValue5);
						}
						else if (Operators.CompareString(left6, "MinesLaidMethod".ToUpper(), TextCompare: false) == 0)
						{
							miningMission.MinesLaidMethod = Conversions.ToByte(objectValue5);
						}
					}
				}
				break;
			}
			case Mission._MissionClass.MineClearing:
			{
				MineClearingMission mineClearingMission = (MineClearingMission)mission;
				string[] mission_MineClearing = Mission_MineClearing;
				for (int l = 0; l < mission_MineClearing.Length; l++)
				{
					string text12 = mission_MineClearing[l];
					text12 = text12.ToUpper();
					if (!dictionary.ContainsKey(text12))
					{
						continue;
					}
					object objectValue3 = RuntimeHelpers.GetObjectValue(dictionary[text12]);
					string left5 = text12;
					unchecked
					{
						if (Operators.CompareString(left5, "OneThirdRule".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.OneThirdRule = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue3)).Value;
						}
						else if (Operators.CompareString(left5, "LoopType".ToUpper(), TextCompare: false) == 0)
						{
							if (Enum.TryParse<Mission.MissionMovementStyle>(Conversions.ToString(objectValue3), ignoreCase: true, out var result5) && Enum.IsDefined(typeof(Mission.MissionMovementStyle), result5))
							{
								mineClearingMission.MovementStyle = result5;
							}
						}
						else if (Operators.CompareString(left5, "TransitThrottleAircraft".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.TransitThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue3));
						}
						else if (Operators.CompareString(left5, "TransitAltitudeAircraft".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.TransitAltitude_Aircraft = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue3));
							mineClearingMission.UseTransitAltitude_Preset = false;
							mineClearingMission.TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
						}
						else if (Operators.CompareString(left5, "TransitTerrainFollowingAircraft".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.TransitTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue3)).Value;
						}
						else if (Operators.CompareString(left5, "StationThrottleAircraft".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.StationThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue3));
						}
						else if (Operators.CompareString(left5, "StationAltitudeAircraft".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.StationAltitude_Aircraft = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue3));
							mineClearingMission.UseStationAltitude_Preset = false;
							mineClearingMission.StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
						}
						else if (Operators.CompareString(left5, "StationTerrainFollowingAircraft".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.StationTerrainFollowing_Aircraft = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue3)).Value;
						}
						else if (Operators.CompareString(left5, "TransitAltitudePreset".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.TransitAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue3)).Value;
						}
						else if (Operators.CompareString(left5, "StationAltitudePreset".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.StationAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue3)).Value;
						}
						else if (Operators.CompareString(left5, "UseStationAltitudePreset".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.UseStationAltitude_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue3)).Value;
						}
						else if (Operators.CompareString(left5, "UseTransitAltitudePreset".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.UseTransitAltitude_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue3)).Value;
						}
						else if (Operators.CompareString(left5, "TransitThrottleSubmarine".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.TransitThrottle_Submarine = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue3)).Value;
						}
						else if (Operators.CompareString(left5, "TransitDepthSubmarine".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.TransitDepth_Submarine = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue3));
							mineClearingMission.UseTransitDepth_Submarine_Preset = false;
							mineClearingMission.TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
						}
						else if (Operators.CompareString(left5, "StationThrottleSubmarine".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.StationThrottle_Submarine = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue3)).Value;
						}
						else if (Operators.CompareString(left5, "StationDepthSubmarine".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.StationDepth_Submarine = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue3));
							mineClearingMission.UseStationDepth_Submarine_Preset = false;
							mineClearingMission.StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
						}
						else if (Operators.CompareString(left5, "StationDepthSubmarinePreset".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.StationDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue3)).Value;
						}
						else if (Operators.CompareString(left5, "TransitDepthSubmarinePreset".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.TransitDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue3)).Value;
						}
						else if (Operators.CompareString(left5, "UseStationDepthSubmarinePreset".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.UseStationDepth_Submarine_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue3)).Value;
						}
						else if (Operators.CompareString(left5, "UseTransitDepthSubmarinePreset".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.UseTransitDepth_Submarine_Preset = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue3)).Value;
						}
						else if (Operators.CompareString(left5, "TransitThrottleShip".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.TransitThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue3)).Value;
						}
						else if (Operators.CompareString(left5, "StationThrottleShip".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.StationThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue3)).Value;
						}
						else if (Operators.CompareString(left5, "FlightSize".ToUpper(), TextCompare: false) == 0)
						{
							string string_29 = Conversions.ToString(objectValue3);
							mineClearingMission.FlightSize = setFlightSize(ref string_29);
						}
						else if (Operators.CompareString(left5, "MinAircraftReq".ToUpper(), TextCompare: false) == 0)
						{
							string string_30 = Conversions.ToString(objectValue3);
							mineClearingMission.MinimumNumberOfAircraft = setFlightQty(ref string_30);
						}
						else if (Operators.CompareString(left5, "UseFlightSize".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.UseFlightSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue3)).Value;
						}
						else if (Operators.CompareString(left5, "UseGroupSize".ToUpper(), TextCompare: false) == 0)
						{
							mineClearingMission.UseGroupSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue3)).Value;
						}
						else
						{
							if (Operators.CompareString(left5, "Zone".ToUpper(), TextCompare: false) != 0)
							{
								continue;
							}
							List<ReferencePoint> list5 = new List<ReferencePoint>();
							foreach (object item6 in LuaUtility.ToArray(((LuaTable)dictionary["ZONE"]).GetEnumerator()))
							{
								object Local_o2 = RuntimeHelpers.GetObjectValue(item6);
								ReferencePoint referencePoint4 = null;
								if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => Operators.CompareString(s.Name, Local_o2.ToString(), TextCompare: false) == 0)))
								{
									if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase))))
									{
										if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase))))
										{
											if (!Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase))))
											{
												referencePoint4 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase));
											}
										}
										else
										{
											referencePoint4 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase));
										}
									}
									else
									{
										referencePoint4 = side.RefPoints.First((ReferencePoint s) => string.Equals(s.Name, Local_o2.ToString(), StringComparison.OrdinalIgnoreCase));
									}
								}
								else
								{
									referencePoint4 = side.RefPoints.First((ReferencePoint s) => Operators.CompareString(s.Name, Local_o2.ToString(), TextCompare: false) == 0);
								}
								if (!Information.IsNothing(referencePoint4))
								{
									list5.Add(referencePoint4);
								}
							}
							mineClearingMission.Area = list5;
						}
					}
				}
				break;
			}
			case Mission._MissionClass.Cargo:
			{
				CargoMission cargoMission = (CargoMission)mission;
				string[] mission_Cargo = Mission_Cargo;
				for (int j = 0; j < mission_Cargo.Length; j++)
				{
					string text9 = mission_Cargo[j];
					text9 = text9.ToUpper();
					if (!dictionary.ContainsKey(text9))
					{
						continue;
					}
					object objectValue = RuntimeHelpers.GetObjectValue(dictionary[text9]);
					string left3 = text9;
					if (Operators.CompareString(left3, "TransitThrottleAircraft".ToUpper(), TextCompare: false) == 0)
					{
						cargoMission.TransitThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue)).Value;
					}
					else if (Operators.CompareString(left3, "TransitAltitudeAircraft".ToUpper(), TextCompare: false) == 0)
					{
						cargoMission.TransitAltitude_Aircraft = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue)).Value;
					}
					else if (Operators.CompareString(left3, "StationThrottleAircraft".ToUpper(), TextCompare: false) == 0)
					{
						cargoMission.StationThrottle_Aircraft = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue)).Value;
					}
					else if (Operators.CompareString(left3, "StationAltitudeAircraft".ToUpper(), TextCompare: false) == 0)
					{
						cargoMission.StationAltitude_Aircraft = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(objectValue)).Value;
					}
					else if (Operators.CompareString(left3, "UseFlightSize".ToUpper(), TextCompare: false) == 0)
					{
						cargoMission.UseFlightSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue)).Value;
					}
					else if (Operators.CompareString(left3, "TransitThrottleShip".ToUpper(), TextCompare: false) == 0)
					{
						cargoMission.TransitThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue)).Value;
					}
					else if (Operators.CompareString(left3, "StationThrottleShip".ToUpper(), TextCompare: false) == 0)
					{
						cargoMission.StationThrottle_Ship = LuaUtility.QueryThrottleObject(Conversions.ToString(objectValue)).Value;
					}
					else if (Operators.CompareString(left3, "UseGroupSize".ToUpper(), TextCompare: false) == 0)
					{
						cargoMission.UseGroupSizeHardLimit = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue)).Value;
					}
					else if (Operators.CompareString(left3, "Zone".ToUpper(), TextCompare: false) == 0)
					{
						List<ReferencePoint> list2 = new List<ReferencePoint>();
						foreach (object item7 in LuaUtility.ToArray(((LuaTable)dictionary["ZONE"]).GetEnumerator()))
						{
							object Local_o = RuntimeHelpers.GetObjectValue(item7);
							ReferencePoint referencePoint = null;
							if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => Operators.CompareString(s.Name, Local_o.ToString(), TextCompare: false) == 0)))
							{
								if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o.ToString(), StringComparison.OrdinalIgnoreCase))))
								{
									if (Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase))))
									{
										if (!Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase))))
										{
											referencePoint = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase));
										}
									}
									else
									{
										referencePoint = side.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase));
									}
								}
								else
								{
									referencePoint = side.RefPoints.First((ReferencePoint s) => string.Equals(s.Name, Local_o.ToString(), StringComparison.OrdinalIgnoreCase));
								}
							}
							else
							{
								referencePoint = side.RefPoints.First((ReferencePoint s) => Operators.CompareString(s.Name, Local_o.ToString(), TextCompare: false) == 0);
							}
							if (!Information.IsNothing(referencePoint))
							{
								list2.Add(referencePoint);
							}
						}
						cargoMission.Area = list2;
					}
					else if (Operators.CompareString(left3, "DestinationUnitID".ToUpper(), TextCompare: false) == 0)
					{
						string text10 = Conversions.ToString(objectValue);
						ActiveUnit destinationUnit = null;
						if (scenario_0.ActiveUnits.TryGetValue(text10, ref destinationUnit))
						{
							cargoMission.DestinationUnit = destinationUnit;
						}
					}
					else if (Operators.CompareString(left3, "MoveAllCargo".ToUpper(), TextCompare: false) == 0)
					{
						cargoMission.MoveAllCargo = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue)).Value;
					}
					else if (Operators.CompareString(left3, "AllowGroundUnitSelfDeliveryFromCargo".ToUpper(), TextCompare: false) == 0)
					{
						cargoMission.AllowSelfDeliveryFromCargo = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue)).Value;
						if (!cargoMission.AllowSelfDeliveryFromCargo)
						{
							cargoMission.AllowAllSelfDelivery = false;
						}
					}
					else if (Operators.CompareString(left3, "AllGroundUnitAttemptSelfDelivery".ToUpper(), TextCompare: false) == 0)
					{
						cargoMission.AllowAllSelfDelivery = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue)).Value;
						if (cargoMission.AllowAllSelfDelivery)
						{
							cargoMission.AllowSelfDeliveryFromCargo = true;
						}
					}
					else if (Operators.CompareString(left3, "AutomaticallyUnpackContainersAtDestination".ToUpper(), TextCompare: false) == 0 && cargoMission.Type == CargoMission.CargoMissionType.Transfer)
					{
						cargoMission.UnpackAllContainers = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(objectValue)).Value;
					}
				}
				break;
			}
			}
			return new LuaWrapper_Mission(mission, scenario_0);
		}
	}

	public static LuaTable ScenEdit_AssignUnitAsTarget(LuaTable luaTable_0, string string_0, Scenario scenario_0, ActiveUnit activeUnit_0)
	{
		Module_Unit.Unit unit = null;
		Mission mission = null;
		Side side = null;
		string text = null;
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		LuaTable val2 = LuaSandBox.Singleton().CreateTable();
		int num = 1;
		if (false)
		{
			text = Conversions.ToString(luaTable_0);
		}
		else
		{
			if (luaTable_0 == null)
			{
				return val2;
			}
			val = luaTable_0;
		}
		if (Operators.CompareString(text, "UnitX", TextCompare: false) == 0)
		{
			if (!Information.IsNothing(activeUnit_0))
			{
				unit = activeUnit_0;
			}
		}
		else if (!Information.IsNothing(text))
		{
			unit = PrivateMethods.smethod_0(text, scenario_0);
			if (unit == null)
			{
				unit = PrivateMethods.ValidateContactBySceanrio(text, scenario_0);
				if (unit == null)
				{
					return val2;
				}
			}
		}
		mission = ValidateMissionBySceanrio(string_0, scenario_0);
		if (mission == null)
		{
			return val2;
		}
		if (mission.MissionClass == Mission._MissionClass.Strike)
		{
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side2 in array)
			{
				foreach (Mission mission2 in side2.Missions)
				{
					if (Operators.CompareString(mission2.ObjectID, mission.ObjectID, TextCompare: false) == 0)
					{
						side = side2;
						break;
					}
				}
			}
			if (!Information.IsNothing(text))
			{
				val[num] = unit.ObjectID;
			}
			foreach (object item in LuaUtility.ToArray(val.GetEnumerator()))
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				if (!(objectValue is string))
				{
					continue;
				}
				string string_ = Conversions.ToString(objectValue);
				unit = PrivateMethods.smethod_0(string_, scenario_0);
				if (unit == null)
				{
					unit = PrivateMethods.ValidateContactBySceanrio(string_, scenario_0);
					if (unit == null)
					{
						continue;
					}
				}
				if (mission.MissionClass != Mission._MissionClass.Strike || unit.GetUnitSide() == side || Module_Side.IsAlliedWithThisSide(side, unit.GetUnitSide()))
				{
					continue;
				}
				if (unit.IsGroup)
				{
					bool flag = false;
					foreach (ActiveUnit value in ((Group)unit).Units.Values)
					{
						if (((Strike)mission).SpecificTargets.Add(value))
						{
							val2[num] = value.ObjectID;
							num++;
							flag = true;
						}
					}
					if (!flag)
					{
					}
					continue;
				}
				if (unit.IsActiveUnit)
				{
					if (((Strike)mission).SpecificTargets.Add(unit))
					{
						val2[num] = unit.ObjectID;
						num++;
					}
					continue;
				}
				Contact contact = (Contact)unit;
				if (!Information.IsNothing(contact.ActualUnit) && side.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID))
				{
					foreach (ActiveUnit value2 in ((Group)contact.ActualUnit).Units.Values)
					{
						if (((Strike)mission).SpecificTargets.Add(value2))
						{
							val2[num] = value2.ObjectID;
							num++;
						}
					}
				}
				else if (!side.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID) && ((Strike)mission).SpecificTargets.Add(contact))
				{
					val2[num] = unit.ObjectID;
					num++;
				}
			}
			return val2;
		}
		return val2;
	}

	public static LuaTable ScenEdit_RemoveUnitAsTarget(LuaTable luaTable_0, string string_0, Scenario scenario_0, ActiveUnit activeUnit_0)
	{
		Module_Unit.Unit unit = null;
		Mission mission = null;
		Side side = null;
		string text = null;
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		LuaTable val2 = LuaSandBox.Singleton().CreateTable();
		int num = 1;
		if (false)
		{
			text = Conversions.ToString(luaTable_0);
		}
		else
		{
			if (luaTable_0 == null)
			{
				return val2;
			}
			val = luaTable_0;
		}
		if (Operators.CompareString(text, "UnitX", TextCompare: false) == 0)
		{
			if (!Information.IsNothing(activeUnit_0))
			{
				unit = activeUnit_0;
			}
		}
		else if (!Information.IsNothing(text))
		{
			unit = PrivateMethods.smethod_0(text, scenario_0);
			if (unit == null)
			{
				unit = PrivateMethods.ValidateContactBySceanrio(text, scenario_0);
				if (unit == null)
				{
					return val2;
				}
			}
		}
		mission = ValidateMissionBySceanrio(string_0, scenario_0);
		if (mission == null)
		{
			return val2;
		}
		if (mission.MissionClass == Mission._MissionClass.Strike)
		{
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side2 in array)
			{
				foreach (Mission mission2 in side2.Missions)
				{
					if (Operators.CompareString(mission2.ObjectID, mission.ObjectID, TextCompare: false) == 0)
					{
						side = side2;
						break;
					}
				}
			}
			if (!Information.IsNothing(text))
			{
				val[num] = unit.ObjectID;
				if (side.BaseContacts.ContainsKey(unit.ObjectID))
				{
					foreach (Contact baseContacts_ in side.BaseContacts_List)
					{
						if (Operators.CompareString(baseContacts_.ActualUnit.ObjectID, unit.ObjectID, TextCompare: false) == 0)
						{
							num++;
							val[num] = baseContacts_.ObjectID;
						}
					}
					foreach (ActiveUnit value in ((Group)unit).Units.Values)
					{
						if (!side.Contacts.ContainsKey(value.ObjectID))
						{
							continue;
						}
						foreach (Contact contacts_ in side.Contacts_List)
						{
							if (Operators.CompareString(contacts_.ActualUnit.ObjectID, value.ObjectID, TextCompare: false) == 0)
							{
								num++;
								val[num] = contacts_.ObjectID;
							}
						}
					}
				}
				else if (side.Contacts.ContainsKey(unit.ObjectID))
				{
					foreach (Contact contacts_2 in side.Contacts_List)
					{
						if (Operators.CompareString(contacts_2.ActualUnit.ObjectID, unit.ObjectID, TextCompare: false) == 0)
						{
							num++;
							val[num] = contacts_2.ObjectID;
						}
					}
				}
			}
			foreach (object item in LuaUtility.ToArray(val.GetEnumerator()))
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				if (!(objectValue is string))
				{
					continue;
				}
				string string_ = Conversions.ToString(objectValue);
				unit = PrivateMethods.smethod_0(string_, scenario_0);
				if (unit == null)
				{
					unit = PrivateMethods.ValidateContactBySceanrio(string_, scenario_0);
					if (unit == null)
					{
						continue;
					}
				}
				if (mission.MissionClass != Mission._MissionClass.Strike || unit.GetUnitSide() == side || Module_Side.IsAlliedWithThisSide(side, unit.GetUnitSide()))
				{
					continue;
				}
				if (unit.IsGroup)
				{
					foreach (ActiveUnit value2 in ((Group)unit).Units.Values)
					{
						if (((Strike)mission).SpecificTargets.Remove(value2))
						{
							val2[num] = value2.ObjectID;
							num++;
						}
					}
					continue;
				}
				if (unit.IsActiveUnit)
				{
					if (((Strike)mission).SpecificTargets.Remove(unit))
					{
						val2[num] = unit.ObjectID;
						num++;
					}
					continue;
				}
				Contact contact = (Contact)unit;
				if (!Information.IsNothing(contact.ActualUnit) && side.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID))
				{
					foreach (ActiveUnit value3 in ((Group)contact.ActualUnit).Units.Values)
					{
						if (((Strike)mission).SpecificTargets.Remove(value3))
						{
							val2[num] = value3.ObjectID;
							num++;
						}
					}
				}
				else if (!side.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID) && ((Strike)mission).SpecificTargets.Remove(contact))
				{
					val2[num] = unit.ObjectID;
					num++;
				}
			}
			return val2;
		}
		return val2;
	}

	public static Mission ValidateMissionBySceanrio(string string_0, Scenario scenario_0)
	{
		Mission result = null;
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		for (int i = 0; i < sides_ReadOnly.Length; i++)
		{
			foreach (Mission mission in sides_ReadOnly[i].Missions)
			{
				if (Operators.CompareString(mission.Name, string_0, TextCompare: false) != 0 && Operators.CompareString(mission.ObjectID, string_0, TextCompare: false) != 0)
				{
					if (string.Equals(mission.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(mission.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
					{
						result = mission;
						return result;
					}
					continue;
				}
				result = mission;
				return result;
			}
		}
		return result;
	}

	public static Mission ValidateMissionBySide(string string_0, Side side_0)
	{
		Mission result = null;
		foreach (Mission mission in side_0.Missions)
		{
			if (string.Equals(mission.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(mission.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
			{
				return mission;
			}
		}
		return result;
	}

	public static Mission._FlightSize setFlightSize(ref string string_0)
	{
		int result = 0;
		int.TryParse(string_0, out result);
		_ = (Mission._FlightSize)0;
		int num = result;
		if (num < 2)
		{
			return 1;
		}
		if (num < 3)
		{
			return 2;
		}
		if (num < 4)
		{
			return 3;
		}
		if (num < 5)
		{
			return 4;
		}
		if (num < 7)
		{
			return 6;
		}
		return 1;
	}

	public static Mission._FlightQty setFlightQty(ref string string_0)
	{
		if (Operators.CompareString(string_0.ToLower(), "all", TextCompare: false) == 0)
		{
			return Mission._FlightQty.All;
		}
		int result = 0;
		int.TryParse(string_0, out result);
		int num = result;
		if (num != 0)
		{
			if (num >= 2)
			{
				if (num >= 3)
				{
					if (num >= 4)
					{
						if (num >= 5)
						{
							if (num >= 7)
							{
								if (num >= 9)
								{
									if (num >= 13)
									{
										return Mission._FlightQty.All;
									}
									return Mission._FlightQty.Flight_x12;
								}
								return Mission._FlightQty.Flight_x8;
							}
							return Mission._FlightQty.Flight_x6;
						}
						return Mission._FlightQty.Flight_x4;
					}
					return Mission._FlightQty.Flight_x3;
				}
				return Mission._FlightQty.Flight_x2;
			}
			return Mission._FlightQty.Flight_x1;
		}
		return Mission._FlightQty.NoPreferences;
	}

	public static Mission._GroupSize setGroupSize(ref string string_0)
	{
		if (Operators.CompareString(string_0.ToLower(), "all", TextCompare: false) == 0)
		{
			return 0;
		}
		int result = 0;
		int.TryParse(string_0, out result);
		_ = (Mission._GroupSize)0;
		int num = result;
		if (num >= 2)
		{
			if (num >= 3)
			{
				if (num >= 4)
				{
					if (num >= 5)
					{
						if (num >= 7)
						{
							return 1;
						}
						return 6;
					}
					return 4;
				}
				return 3;
			}
			return 2;
		}
		return 1;
	}

	public static Misc.PostureStance setStance(ref string string_0)
	{
		switch (string_0.ToLower())
		{
		case "hostile":
		case "3":
			return Misc.PostureStance.Hostile;
		case "unfriendly":
		case "2":
			return Misc.PostureStance.Unfriendly;
		case "1":
		case "friendly":
			return Misc.PostureStance.Friendly;
		case "4":
		case "unknown":
			return Misc.PostureStance.Unknown;
		default:
			return Misc.PostureStance.Unknown;
		case "0":
		case "neutral":
			return Misc.PostureStance.Neutral;
		}
	}

	public static Mission._RadarBehaviour setRadarUse(ref string string_0)
	{
		string left = string_0.ToLower();
		if (Operators.CompareString(left, "None".ToLower(), TextCompare: false) != 0 && Operators.CompareString(left, "0", TextCompare: false) != 0)
		{
			if (Operators.CompareString(left, "UseMissionEMCON".ToLower(), TextCompare: false) != 0 && Operators.CompareString(left, "1", TextCompare: false) != 0)
			{
				if (Operators.CompareString(left, "ActiveOnIP".ToLower(), TextCompare: false) != 0 && Operators.CompareString(left, "2", TextCompare: false) != 0)
				{
					if (Operators.CompareString(left, "ActiveOnAttackIngressAndIP".ToLower(), TextCompare: false) != 0 && Operators.CompareString(left, "3", TextCompare: false) != 0)
					{
						return Mission._RadarBehaviour.None;
					}
					return Mission._RadarBehaviour.ActiveOnAttackIngressAndIP;
				}
				return Mission._RadarBehaviour.ActiveOnIP;
			}
			return Mission._RadarBehaviour.UseMissionEMCON;
		}
		return Mission._RadarBehaviour.None;
	}
}
