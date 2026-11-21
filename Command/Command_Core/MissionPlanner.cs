using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class MissionPlanner
{
	[CompilerGenerated]
	private sealed class StateProcessResolver
	{
		public Mission Local_theMission;

		public Doctrine._UseShootTourists? Local_Doctrine_ShootTourists;

		public Aircraft Local_theAC;

		internal bool PrepareInterruptibleQueue(Contact theC)
		{
			Aircraft_AI aI = Local_theAC.AI;
			Mission local_theMission = Local_theMission;
			string string_ = "";
			int int_ = 0;
			return aI.ContactIsRelevantToMission(theC, local_theMission, Local_Doctrine_ShootTourists, bool_0: false, bool_1: false, bool_2: true, null, ref string_, ref int_);
		}
	}

	[CompilerGenerated]
	private sealed class TestsRuleWatcher
	{
		public Mission Local_theMission;

		public Aircraft Local_theAC;

		public Doctrine._UseShootTourists? Local_Doctrine_ShootTourists;

		internal bool ReflectInterruptibleQueue(Contact theC)
		{
			Aircraft_AI aI = Local_theAC.AI;
			string string_ = "";
			int int_ = 0;
			return aI.ContactIsRelevantToMission(theC, Local_theMission, Local_Doctrine_ShootTourists, bool_0: false, bool_1: false, bool_2: true, null, ref string_, ref int_);
		}
	}

	private static bool? _ProxyConsumer;

	private static List<string> _ReaderConsumer;

	private static bool propertyConsumer;

	private static float _ImporterConsumer;

	static MissionPlanner()
	{
		_ReaderConsumer = new List<string>();
		_ImporterConsumer = 1f;
	}

	public static void GenerateFlightPlan_Strike_AirborneAircraft(Scenario scenario_0, Mission mission_0, ref List<ActiveUnit> list_0, bool bool_0)
	{
		try
		{
			_ProxyConsumer = null;
			Mission._FlightSize flightSize = 1;
			List<Aircraft> list = new List<Aircraft>();
			Mission.Flight flight_ = null;
			foreach (ActiveUnit item in list_0)
			{
				if (item == null || (!item.IsAircraft && !item.IsGroup))
				{
					continue;
				}
				item.Kinematics.DetermineReserveFuelQty();
				string string_ = "";
				Aircraft aircraft = null;
				Group group_ = null;
				if (item.IsGroup)
				{
					Group group = (Group)item;
					if (Information.IsNothing(group.GroupLead) || !group.GroupLead.IsAircraft)
					{
						continue;
					}
					aircraft = (Aircraft)group.GroupLead;
					group_ = group;
					foreach (ActiveUnit value in group.Units.Values)
					{
						if (value.IsOperating())
						{
							list.Add((Aircraft)value);
						}
					}
					flightSize = group.Units.Values.Count;
					string_ = (aircraft.Navigator.HasFlight ? aircraft.Navigator.GetFlight().Callsign : group_.Name);
				}
				else if (item.IsGroupMember())
				{
					if (!item.IsGroupLead())
					{
						continue;
					}
					aircraft = (Aircraft)item;
					group_ = item.GetParentGroup();
					list.Add(aircraft);
					flightSize = item.GetParentGroup().Units.Values.Count;
					string_ = (aircraft.Navigator.HasFlight ? aircraft.Navigator.GetFlight().Callsign : group_.Name);
				}
				else
				{
					aircraft = (Aircraft)item;
					list.Add(aircraft);
					flightSize = 1;
					if (aircraft.Navigator.HasFlight)
					{
						string_ = aircraft.Navigator.GetFlight().Callsign;
					}
				}
				if (Information.IsNothing(aircraft))
				{
					continue;
				}
				bool flag = false;
				Mission mission = null;
				if (aircraft.Navigator.HasFlight)
				{
					flag = true;
					mission = aircraft.AssignedMissionOrPackage();
				}
				if (!aircraft.AI.IsEscort && Information.IsNothing(aircraft.AirOps.GetAssignedHostUnit()))
				{
					aircraft.AirOps.PickNewAssignedHost_Nearest();
					if (Information.IsNothing(aircraft.AirOps.GetAssignedHostUnit()))
					{
						if (bool_0)
						{
							GameGeneral.ResolveBridge("无法找到合适的停靠机场或船只对于" + aircraft.Name + "因此不能制定攻击任务的飞行计划。", item.GetUnitSide());
						}
						continue;
					}
				}
				Doctrine._UseShootTourists? shootTourists = aircraft.Doctrine.GetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false);
				ActiveUnit activeUnit;
				Side side_ = (activeUnit = list_0[0]).GetUnitSide();
				bool num = GenerateFlightPlan_ExistingFlight(ref scenario_0, ref side_, mission_0, bool_0, bool_1: true, ref flight_, string_, flightSize, ref aircraft, ref group_, flag, shootTourists);
				activeUnit.SetUnitSide(bool_0: false, side_);
				if (!num)
				{
					continue;
				}
				if (Information.IsNothing(flight_))
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					continue;
				}
				mission_0.AddFlight(ref flight_);
				flight_.ParentMissionOrPackageName = mission_0.Name;
				flight_.ParentMissionOrPackageObjectID = mission_0.ObjectID;
				if (flag && !Information.IsNothing(mission) && mission_0 != mission)
				{
					mission.FlightList.Remove(flight_);
				}
				int num2 = 2;
				if (aircraft.IsGroupMember())
				{
					foreach (ActiveUnit value2 in aircraft.GetParentGroup().Units.Values)
					{
						if (value2.IsGroupLead())
						{
							value2.SetFlight(flight_, 1);
							continue;
						}
						value2.SetFlight(flight_, num2);
						num2++;
					}
				}
				else
				{
					aircraft.Navigator.SetFlight(bool_1: true, flight_);
				}
				aircraft.AirOps.TakeOff_SetFlight_Flightplan_Doctrine(bool_0: false);
			}
			foreach (Aircraft item2 in list)
			{
				if (item2.IsGroupLead())
				{
					item2.Status = ActiveUnit._ActiveUnitStatus.Tasked;
					if (item2.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar)
					{
						item2.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
					}
					item2.AI.EvaluateUnitStatus(0f, bool_0: false, bool_1: false);
					break;
				}
			}
			foreach (Aircraft item3 in list)
			{
				if (item3.GetParentGroup() != null && !item3.IsGroupLead())
				{
					item3.Status = ActiveUnit._ActiveUnitStatus.Tasked;
					if (item3.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar)
					{
						item3.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
					}
					item3.AI.EvaluateUnitStatus(0f, bool_0: false, bool_1: false);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200628", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static bool GenerateFlightPlan_ExistingFlight(ref Scenario scenario_0, ref Side side_0, Mission mission_0, bool bool_0, bool bool_1, ref Mission.Flight flight_0, string string_0, Mission._FlightSize _FlightSize_0, ref Aircraft aircraft_0, ref Group group_0, bool bool_2, Doctrine._UseShootTourists? nullable_0)
	{
		checked
		{
			try
			{
				Doctrine._UseUnderwayRefuelAndReplenishment? useReplenishment = mission_0.Doctrine.GetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
				float float_ = 0f;
				bool flag = true;
				bool flag2 = false;
				List<Contact> list = new List<Contact>();
				float float_3 = 0f;
				string string_ = null;
				if (mission_0.MissionClass == Mission._MissionClass.Strike)
				{
					Strike strike_ = (Strike)mission_0;
					if (strike_.Type == Strike.StrikeType.Air_Intercept)
					{
						try
						{
							if (bool_2)
							{
								flight_0 = aircraft_0.Navigator.GetFlight();
							}
							else
							{
								if (string.IsNullOrEmpty(string_0) || !string_0.Contains("Flight"))
								{
									string_0 = Callsigns.ReadProperty(ref mission_0);
								}
								Mission.Flight flight_ = null;
								flight_0 = new Mission.Flight(ref scenario_0, ref mission_0, ref flight_, string_0, null, aircraft_0, _FlightSize_0, aircraft_0.AI.IsEscort);
							}
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception exception_ = ex;
							exception_?.Data.Add("Error at 200628o", "");
							GameGeneral.WriteExceptionsToLog(ref exception_);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						if (!aircraft_0.AI.IsEscort)
						{
							try
							{
								list.AddRange(aircraft_0.GetUnitSide().Contacts.Values);
								if (strike_.RTB_When_Target_Destroyed && strike_.TargetCount == 0)
								{
									if (bool_0)
									{
										GameGeneral.ResolveBridge("飞机" + aircraft_0.Name + "没有被添加到任务中。原因：任务只允许攻击预先计划好的目标，并且不会留下任何目标。要解决此问题，请删除“预先计划的目标”标记，或将目标添加到任务的目标列表中。", side_0);
									}
									return false;
								}
								if (strike_.RTB_When_Target_Destroyed)
								{
									Contact[] array = strike_.SpecificTargets.OfType<Contact>().ToArray();
									Contact[] array3 = array;
									foreach (Contact contact in array3)
									{
										if (!Information.IsNothing(contact.ActualUnit) && side_0.Contacts.ContainsKey(contact.ActualUnit.ObjectID))
										{
											flag2 = true;
											break;
										}
									}
									if (!flag2)
									{
										ActiveUnit[] array2 = strike_.SpecificTargets.OfType<ActiveUnit>().ToArray();
										ActiveUnit[] array4 = array2;
										foreach (ActiveUnit activeUnit in array4)
										{
											if (side_0.Contacts.ContainsKey(activeUnit.ObjectID))
											{
												flag2 = true;
												break;
											}
										}
									}
									if (unchecked(!flag2 && bool_0))
									{
										GameGeneral.ResolveBridge("该任务只允许攻击预先计划好的目标，但目前没有任何目标可见，因此Flightplan Generator无法为攻击任务制定飞行计划。", side_0);
										return false;
									}
								}
							}
							catch (Exception ex8)
							{
								ProjectData.SetProjectError(ex8);
								Exception exception_8 = ex8;
								exception_8?.Data.Add("Error at 200628n", "");
								GameGeneral.WriteExceptionsToLog(ref exception_8);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						if (aircraft_0.AI.IsEscort)
						{
							try
							{
								if (bool_2)
								{
									flight_0 = aircraft_0.Navigator.GetFlight();
								}
								else
								{
									if (string.IsNullOrEmpty(string_0) || !string_0.Contains("Flight"))
									{
										string_0 = Callsigns.ReadProperty(ref mission_0);
									}
									ref Mission mission_ = ref mission_0;
									Mission.Flight flight_2 = null;
									flight_0 = new Mission.Flight(ref scenario_0, ref mission_, ref flight_2, string_0, null, aircraft_0, _FlightSize_0, aircraft_0.AI.IsEscort);
								}
							}
							catch (Exception ex9)
							{
								ProjectData.SetProjectError(ex9);
								Exception exception_9 = ex9;
								exception_9?.Data.Add("Error at 200628l", "");
								GameGeneral.WriteExceptionsToLog(ref exception_9);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						else if (strike_.TargetCount <= 0)
						{
							Aircraft Local_theAC = aircraft_0;
							foreach (Contact item in list.Where(delegate(Contact theC)
							{
								Aircraft_AI aI5 = Local_theAC.AI;
								Mission mission_9 = mission_0;
								string string_2 = "";
								int int_ = 0;
								return aI5.ContactIsRelevantToMission(theC, mission_9, nullable_0, bool_0: false, bool_1: false, bool_2: true, null, ref string_2, ref int_);
							}).ToList())
							{
								Contact contact_ = item;
								try
								{
									if (!aircraft_0.AI.IncludeClient(ref strike_, contact_.GetStance(side_0)))
									{
										continue;
									}
									if (bool_2)
									{
										flight_0 = aircraft_0.Navigator.GetFlight();
									}
									else
									{
										if (string.IsNullOrEmpty(string_0) || !string_0.Contains("Flight"))
										{
											string_0 = Callsigns.ReadProperty(ref mission_0);
										}
										ref Mission mission_2 = ref mission_0;
										Mission.Flight flight_3 = null;
										flight_0 = new Mission.Flight(ref scenario_0, ref mission_2, ref flight_3, string_0, contact_, aircraft_0, _FlightSize_0, bool_0: false);
									}
									Aircraft_AI aI = aircraft_0.AI;
									ref Mission mission_3 = ref mission_0;
									int minResponseRadius_Aircraft = strike_.MinResponseRadius_Aircraft;
									int maxResponseRadius_Aircraft = strike_.MaxResponseRadius_Aircraft;
									bool launchMissionWithoutTankersInPlace = mission_0.LaunchMissionWithoutTankersInPlace;
									Mission._RadarBehaviour radarBehaviour = strike_.RadarBehaviour;
									bool usePlanner = strike_.UsePlanner;
									bool bool_3 = true;
									float float_4 = 0f;
									float float_5 = 0f;
									if (aI.SetupClient(ref scenario_0, ref side_0, ref mission_3, ref flight_0, ref contact_, minResponseRadius_Aircraft, maxResponseRadius_Aircraft, useReplenishment, launchMissionWithoutTankersInPlace, radarBehaviour, bool_1: true, bool_2: true, bool_1, usePlanner, ref float_3, ref string_, bool_5: true, ref bool_3, bool_7: false, ref float_4, ref float_5, bool_8: true, null, bool_9: true, mission_0.TakeOffTime, mission_0.TimeOnTarget, bool_10: false, bool_11: false))
									{
										flag = false;
									}
									if (flag)
									{
										continue;
									}
									break;
								}
								catch (Exception ex10)
								{
									ProjectData.SetProjectError(ex10);
									Exception exception_10 = ex10;
									exception_10?.Data.Add("Error at 200628l", "");
									GameGeneral.WriteExceptionsToLog(ref exception_10);
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									ProjectData.ClearProjectError();
								}
							}
						}
						else
						{
							foreach (Contact item2 in list)
							{
								Contact contact_2 = item2;
								try
								{
									if (!contact_2.GetIsSpecificTargetForThisStrike(strike_) || !aircraft_0.AI.IncludeClient(ref strike_, contact_2.GetStance(side_0)))
									{
										continue;
									}
									if (bool_2)
									{
										flight_0 = aircraft_0.Navigator.GetFlight();
									}
									else
									{
										_ = aircraft_0.AirOps;
										if (string.IsNullOrEmpty(string_0) || !string_0.Contains("Flight"))
										{
											string_0 = Callsigns.ReadProperty(ref mission_0);
										}
										ref Mission mission_4 = ref mission_0;
										Mission.Flight flight_4 = null;
										flight_0 = new Mission.Flight(ref scenario_0, ref mission_4, ref flight_4, string_0, contact_2, aircraft_0, _FlightSize_0, bool_0: false);
									}
									flight_0.PrimaryTarget = contact_2;
									Aircraft_AI aI2 = aircraft_0.AI;
									ref Mission mission_5 = ref mission_0;
									int minResponseRadius_Aircraft2 = strike_.MinResponseRadius_Aircraft;
									int maxResponseRadius_Aircraft2 = strike_.MaxResponseRadius_Aircraft;
									bool launchMissionWithoutTankersInPlace2 = mission_0.LaunchMissionWithoutTankersInPlace;
									Mission._RadarBehaviour radarBehaviour2 = strike_.RadarBehaviour;
									bool usePlanner2 = strike_.UsePlanner;
									bool bool_4 = true;
									float float_6 = 0f;
									float float_7 = 0f;
									if (aI2.SetupClient(ref scenario_0, ref side_0, ref mission_5, ref flight_0, ref contact_2, minResponseRadius_Aircraft2, maxResponseRadius_Aircraft2, useReplenishment, launchMissionWithoutTankersInPlace2, radarBehaviour2, bool_1: true, bool_2: true, bool_1, usePlanner2, ref float_, ref string_, bool_5: true, ref bool_4, bool_7: false, ref float_6, ref float_7, bool_8: true, null, bool_9: true, mission_0.TakeOffTime, mission_0.TimeOnTarget, bool_10: false, bool_11: false))
									{
										flag = false;
										flight_0.PrimaryTarget = null;
									}
									if (flag)
									{
										continue;
									}
									break;
								}
								catch (Exception ex11)
								{
									ProjectData.SetProjectError(ex11);
									Exception exception_11 = ex11;
									exception_11?.Data.Add("Error at 200628m", "");
									GameGeneral.WriteExceptionsToLog(ref exception_11);
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									ProjectData.ClearProjectError();
								}
							}
						}
						if (!aircraft_0.AI.IsEscort)
						{
							if (flag || Information.IsNothing(flight_0))
							{
								try
								{
									if (bool_0)
									{
										Aircraft obj = aircraft_0;
										Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
										obj.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
										if (flag)
										{
											GameGeneral.ResolveBridge("飞机" + aircraft_0.Name + "没有被添加到任务中。原因：目标超出范围。" + string_, side_0);
										}
										else
										{
											GameGeneral.ResolveBridge("飞机" + aircraft_0.Name + "没有被添加到任务中。原因：" + string_ + "检查没有禁航区域太靠近目标或着陆集结点。", side_0);
										}
										return false;
									}
									aircraft_0.Navigator.ClearPlottedCourse();
								}
								catch (Exception ex12)
								{
									ProjectData.SetProjectError(ex12);
									Exception exception_12 = ex12;
									exception_12?.Data.Add("Error at 200628i", "");
									GameGeneral.WriteExceptionsToLog(ref exception_12);
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									ProjectData.ClearProjectError();
								}
							}
							if (flight_0.FlightPlan.Count() == 0 && flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
							{
								try
								{
									if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() == 0)
									{
										if (bool_0)
										{
											Aircraft obj2 = aircraft_0;
											Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_2 = Mission.MissionAssignmentAttemptResult.None;
											obj2.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_2);
											GameGeneral.ResolveBridge("尝试在禁航区域周围创建飞行计划" + aircraft_0.Name + "失败。", side_0);
										}
										aircraft_0.Navigator.ClearPlottedCourse();
										return false;
									}
								}
								catch (Exception ex13)
								{
									ProjectData.SetProjectError(ex13);
									Exception exception_13 = ex13;
									exception_13?.Data.Add("Error at 200628h", "");
									GameGeneral.WriteExceptionsToLog(ref exception_13);
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									ProjectData.ClearProjectError();
								}
							}
							if (!Information.IsNothing(group_0))
							{
								bool flag3 = true;
								float num = 0f;
								foreach (ActiveUnit value in group_0.Units.Values)
								{
									try
									{
										if (value == aircraft_0)
										{
											continue;
										}
										foreach (FuelRec item3 in value.Fuel_ReadOnly)
										{
											num += item3.CurrentQuantity;
										}
										float reserveFuel = value.Kinematics.ReserveFuel;
										if (!(num - reserveFuel < float_) || Interaction.MsgBox("并非所有编队成员" + group_0.Name + "有足够的燃料用于飞行计划。这些单元已被添加到任务中，但可能会在达到目标之前损失。您想为编队制定飞行计划吗？警告！只有在飞机具备空中加油功能并且您有足够的加油机可用时才能执行此操作！", MsgBoxStyle.YesNo) != MsgBoxResult.No)
										{
											continue;
										}
										flag3 = false;
										break;
									}
									catch (Exception ex14)
									{
										ProjectData.SetProjectError(ex14);
										Exception exception_14 = ex14;
										exception_14?.Data.Add("Error at 200628g", "");
										GameGeneral.WriteExceptionsToLog(ref exception_14);
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										ProjectData.ClearProjectError();
									}
								}
								if (!flag3)
								{
									return false;
								}
							}
						}
						if (!aircraft_0.AI.IsEscort)
						{
							try
							{
								if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0 && flight_0.FlightPlan.Count() == 0)
								{
									Waypoint[] flightPlan_Pathfinder_Ingress_ = flight_0.FlightPlan_Pathfinder_Ingress_1;
									Waypoint[] gparam_;
									for (int i = 0; i < flightPlan_Pathfinder_Ingress_.Length; i++)
									{
										Waypoint waypoint_ = flightPlan_Pathfinder_Ingress_[i];
										Mission.Flight obj3 = flight_0;
										gparam_ = obj3.FlightPlan;
										Doctrine doctrine_ = null;
										ArrayExtensions.Add(ref gparam_, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_, bool_0: true, bool_1: true, ref doctrine_));
										obj3.FlightPlan = gparam_;
									}
									Mission.Flight obj4 = flight_0;
									gparam_ = obj4.FlightPlan_Pathfinder_Ingress_1;
									ArrayExtensions.Clear(ref gparam_);
									obj4.FlightPlan_Pathfinder_Ingress_1 = gparam_;
								}
								if (flight_0.FlightPlan.Count() > 0)
								{
									aircraft_0.Navigator.ClearPlottedCourse();
									Waypoint[] flightPlan = flight_0.FlightPlan;
									Waypoint[] array5 = flightPlan;
									foreach (Waypoint waypoint in array5)
									{
										if (waypoint.Type != Waypoint.WaypointType.TakeOff && waypoint.Type != Waypoint.WaypointType.Assemble && waypoint.Type != Waypoint.WaypointType.HoldStart && waypoint.Type != Waypoint.WaypointType.HoldEnd)
										{
											Aircraft_Navigator navigator = aircraft_0.Navigator;
											Waypoint[] gparam_2 = navigator.PlottedCourse;
											ArrayExtensions.Add(ref gparam_2, waypoint);
											navigator.PlottedCourse = gparam_2;
										}
									}
								}
							}
							catch (Exception ex15)
							{
								ProjectData.SetProjectError(ex15);
								Exception exception_15 = ex15;
								exception_15?.Data.Add("Error at 200628f", "");
								GameGeneral.WriteExceptionsToLog(ref exception_15);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
					}
				}
				else if (mission_0.UseFlightplans && mission_0.MissionClass == Mission._MissionClass.Patrol)
				{
					try
					{
						if (bool_2)
						{
							flight_0 = aircraft_0.Navigator.GetFlight();
						}
						else
						{
							if (string.IsNullOrEmpty(string_0) || !string_0.Contains("Flight"))
							{
								string_0 = Callsigns.ReadProperty(ref mission_0);
							}
							ref Mission mission_6 = ref mission_0;
							Mission.Flight flight_5 = null;
							flight_0 = new Mission.Flight(ref scenario_0, ref mission_6, ref flight_5, string_0, null, aircraft_0, _FlightSize_0, aircraft_0.AI.IsEscort);
						}
						float float_8 = 50f;
						double double_ = 0.0;
						double double_2 = 0.0;
						double double_3 = 0.0;
						double double_4 = 0.0;
						if (!aircraft_0.Navigator.UpdateDic(ref double_, ref double_2, ref double_3, ref double_4, ref float_8))
						{
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							return false;
						}
						Aircraft_AI aI3 = aircraft_0.AI;
						bool launchMissionWithoutTankersInPlace3 = mission_0.LaunchMissionWithoutTankersInPlace;
						float float_9 = 0f;
						aI3.ExcludeClient(ref flight_0, useReplenishment, launchMissionWithoutTankersInPlace3, bool_1: true, bool_2: true, bool_1, ref float_9, ref string_, bool_4: true, bool_5: true, double_, double_2, double_3, double_4, Waypoint.WaypointType.StationStart_Racetrack, Waypoint.TurnRateCategory.HalfStandardRateTurn, bool_6: true, null, null, bool_7: false, bool_8: false);
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at 200628e", "");
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					if (!aircraft_0.AI.IsEscort)
					{
						try
						{
							if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0 && flight_0.FlightPlan.Count() == 0)
							{
								Waypoint[] flightPlan_Pathfinder_Ingress_2 = flight_0.FlightPlan_Pathfinder_Ingress_1;
								Waypoint[] gparam_3;
								for (int j = 0; j < flightPlan_Pathfinder_Ingress_2.Length; j++)
								{
									Waypoint waypoint_2 = flightPlan_Pathfinder_Ingress_2[j];
									Mission.Flight obj5 = flight_0;
									gparam_3 = obj5.FlightPlan;
									Doctrine doctrine_2 = null;
									ArrayExtensions.Add(ref gparam_3, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_2, bool_0: true, bool_1: true, ref doctrine_2));
									obj5.FlightPlan = gparam_3;
								}
								Mission.Flight obj6 = flight_0;
								gparam_3 = obj6.FlightPlan_Pathfinder_Ingress_1;
								ArrayExtensions.Clear(ref gparam_3);
								obj6.FlightPlan_Pathfinder_Ingress_1 = gparam_3;
							}
							if (flight_0.FlightPlan.Count() > 0)
							{
								aircraft_0.Navigator.ClearPlottedCourse();
								Waypoint[] flightPlan3 = flight_0.FlightPlan;
								Waypoint[] array6 = flightPlan3;
								foreach (Waypoint waypoint2 in array6)
								{
									if (waypoint2.Type != Waypoint.WaypointType.TakeOff && waypoint2.Type != Waypoint.WaypointType.Assemble && waypoint2.Type != Waypoint.WaypointType.HoldStart && waypoint2.Type != Waypoint.WaypointType.HoldEnd)
									{
										Aircraft_Navigator navigator2 = aircraft_0.Navigator;
										Waypoint[] gparam_4 = navigator2.PlottedCourse;
										ArrayExtensions.Add(ref gparam_4, waypoint2);
										navigator2.PlottedCourse = gparam_4;
									}
								}
							}
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception exception_3 = ex3;
							exception_3?.Data.Add("Error at 200628d", "");
							GameGeneral.WriteExceptionsToLog(ref exception_3);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
				}
				else if (mission_0.UseFlightplans && mission_0.MissionClass == Mission._MissionClass.Support)
				{
					try
					{
						if (bool_2)
						{
							flight_0 = aircraft_0.Navigator.GetFlight();
						}
						else
						{
							if (string.IsNullOrEmpty(string_0) || !string_0.Contains("Flight"))
							{
								string_0 = Callsigns.ReadProperty(ref mission_0);
							}
							ref Mission mission_7 = ref mission_0;
							Mission.Flight flight_6 = null;
							flight_0 = new Mission.Flight(ref scenario_0, ref mission_7, ref flight_6, string_0, null, aircraft_0, _FlightSize_0, aircraft_0.AI.IsEscort);
						}
						float float_10 = 50f;
						double double_5 = 0.0;
						double double_6 = 0.0;
						double double_7 = 0.0;
						double double_8 = 0.0;
						if (!aircraft_0.Navigator.UpdateDic(ref double_5, ref double_6, ref double_7, ref double_8, ref float_10))
						{
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							return false;
						}
						Waypoint.WaypointType waypointType_ = (aircraft_0.IsTanker ? Waypoint.WaypointType.StationStart_Area : Waypoint.WaypointType.StationStart_FigureEight);
						Aircraft_AI aI4 = aircraft_0.AI;
						bool launchMissionWithoutTankersInPlace4 = mission_0.LaunchMissionWithoutTankersInPlace;
						float float_2 = 0f;
						aI4.ExcludeClient(ref flight_0, useReplenishment, launchMissionWithoutTankersInPlace4, bool_1: true, bool_2: true, bool_1, ref float_2, ref string_, bool_4: true, bool_5: true, double_5, double_6, double_7, double_8, waypointType_, Waypoint.TurnRateCategory.FlatTurn, bool_6: true, null, null, bool_7: false, bool_8: false);
					}
					catch (Exception ex4)
					{
						ProjectData.SetProjectError(ex4);
						Exception exception_4 = ex4;
						exception_4?.Data.Add("Error at 200628c", "");
						GameGeneral.WriteExceptionsToLog(ref exception_4);
						_ = Debugger.IsAttached;
						ProjectData.ClearProjectError();
						return false;
					}
					if (!aircraft_0.AI.IsEscort)
					{
						try
						{
							if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0 && flight_0.FlightPlan.Count() == 0)
							{
								Waypoint[] flightPlan_Pathfinder_Ingress_3 = flight_0.FlightPlan_Pathfinder_Ingress_1;
								Waypoint[] gparam_5;
								for (int k = 0; k < flightPlan_Pathfinder_Ingress_3.Length; k++)
								{
									Waypoint waypoint_3 = flightPlan_Pathfinder_Ingress_3[k];
									Mission.Flight obj7 = flight_0;
									gparam_5 = obj7.FlightPlan;
									Doctrine doctrine_3 = null;
									ArrayExtensions.Add(ref gparam_5, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_3, bool_0: true, bool_1: true, ref doctrine_3));
									obj7.FlightPlan = gparam_5;
								}
								Mission.Flight obj8 = flight_0;
								gparam_5 = obj8.FlightPlan_Pathfinder_Ingress_1;
								ArrayExtensions.Clear(ref gparam_5);
								obj8.FlightPlan_Pathfinder_Ingress_1 = gparam_5;
							}
							if (flight_0.FlightPlan.Count() > 0)
							{
								aircraft_0.Navigator.ClearPlottedCourse();
								Waypoint[] flightPlan2 = flight_0.FlightPlan;
								Waypoint[] array7 = flightPlan2;
								foreach (Waypoint waypoint3 in array7)
								{
									if (waypoint3.Type != Waypoint.WaypointType.TakeOff && waypoint3.Type != Waypoint.WaypointType.Assemble && waypoint3.Type != Waypoint.WaypointType.HoldStart && waypoint3.Type != Waypoint.WaypointType.HoldEnd)
									{
										Aircraft_Navigator navigator3 = aircraft_0.Navigator;
										Waypoint[] gparam_6 = navigator3.PlottedCourse;
										ArrayExtensions.Add(ref gparam_6, waypoint3);
										navigator3.PlottedCourse = gparam_6;
									}
								}
							}
						}
						catch (Exception ex5)
						{
							ProjectData.SetProjectError(ex5);
							Exception exception_5 = ex5;
							exception_5?.Data.Add("Error at 200628b", "");
							GameGeneral.WriteExceptionsToLog(ref exception_5);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
				}
				else
				{
					try
					{
						if (bool_2)
						{
							flight_0 = aircraft_0.Navigator.GetFlight();
						}
						else
						{
							_ = aircraft_0.AirOps;
							if (string.IsNullOrEmpty(string_0) || !string_0.Contains("Flight"))
							{
								string_0 = Callsigns.ReadProperty(ref mission_0);
							}
							ref Mission mission_8 = ref mission_0;
							Mission.Flight flight_7 = null;
							flight_0 = new Mission.Flight(ref scenario_0, ref mission_8, ref flight_7, string_0, null, aircraft_0, _FlightSize_0, aircraft_0.AI.IsEscort);
						}
					}
					catch (Exception ex6)
					{
						ProjectData.SetProjectError(ex6);
						Exception exception_6 = ex6;
						exception_6?.Data.Add("Error at 200628a", "");
						GameGeneral.WriteExceptionsToLog(ref exception_6);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				return true;
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception exception_7 = ex7;
				exception_7?.Data.Add("Error at 200628", "");
				GameGeneral.WriteExceptionsToLog(ref exception_7);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
		}
	}

	private static void VerifyValue(ref Strike strike_0, ref float float_0, ref float float_1, ref float float_2)
	{
		switch (strike_0.AttackMethod)
		{
		default:
			float_0 = 0f;
			float_1 = 0f;
			float_2 = 0f;
			break;
		case Mission._AttackMethod.SplitAtActionPoint:
		case Mission._AttackMethod.EchelonAtActionPoint:
			float_0 = 0f;
			float_1 = 0f;
			float_2 = 20f;
			break;
		case Mission._AttackMethod.MultiAxisSimultaneousToT:
		case Mission._AttackMethod.MultiAxisStackedToT_Echelon_20Sec:
		case Mission._AttackMethod.MultiAxisStackedToT_Echelon_30Sec:
		case Mission._AttackMethod.MultiAxisStackedToT_Echelon_40Sec:
		case Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec:
		case Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec:
		case Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec:
		case Mission._AttackMethod.SingleAxisStackedToT_20Sec:
		case Mission._AttackMethod.SingleAxisStackedToT_30Sec:
		case Mission._AttackMethod.SingleAxisStackedToT_40Sec:
			switch (strike_0.SplitDistance)
			{
			case Mission._SplitDistance.Close_10nm:
				float_0 = 10f;
				float_1 = 5f;
				break;
			case Mission._SplitDistance.Typical_20nm:
				float_0 = 20f;
				float_1 = 10f;
				break;
			case Mission._SplitDistance.Long_50nm:
				float_0 = 50f;
				float_1 = 20f;
				break;
			}
			float_2 = TestTokenizer(strike_0.AttackMethod);
			break;
		case Mission._AttackMethod.BananaSplit:
			float_0 = 15f;
			float_1 = 8f;
			float_2 = TestTokenizer(strike_0.AttackMethod);
			break;
		}
	}

	public static bool GenerateFlightPlan_Strike(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Aircraft aircraft_0, bool? nullable_0, Contact contact_0, Mission._RadarBehaviour _RadarBehaviour_0, ref bool bool_0, bool bool_1, bool bool_2, bool bool_3, ref float float_0, ref string string_0, bool bool_4, ref bool bool_5, bool bool_6, ref float float_1, ref float float_2, bool bool_7, float float_3, ref Weapon weapon_0, float float_4, bool bool_8, DateTime? nullable_1, DateTime? nullable_2, bool bool_9)
	{
		if (!side_0.IsHumanControlled)
		{
			_ProxyConsumer = true;
		}
		if (Information.IsNothing(mission_0))
		{
			string_0 = "飞机的指定任务不存在。没有创建飞行计划。";
			return false;
		}
		if (mission_0.MissionClass == Mission._MissionClass.Strike)
		{
			try
			{
				if (!Information.IsNothing(aircraft_0.Loadout) && !Information.IsNothing(aircraft_0.Loadout.GetMissionProfile(scenario_0)))
				{
					Strike strike_ = (Strike)mission_0;
					if (strike_.Type == Strike.StrikeType.Sub_Strike)
					{
						return true;
					}
					float float_8 = 0.2f;
					AircraftMissionProfile aircraftMissionProfile_ = aircraft_0.Loadout.GetMissionProfile(scenario_0);
					float float_9 = Math.Max(5f, float_4);
					float float_10 = GameGeneral.LockRandom_0.Next(-45, 45);
					float float_11 = float_3 - Math.Max(float_4, 5f);
					Waypoint.Formation formation_ = Waypoint.Formation.Spread;
					bool bool_10 = false;
					float float_12 = 0f;
					float float_5 = 0f;
					float float_6 = 0f;
					VerifyValue(ref strike_, ref float_12, ref float_5, ref float_6);
					Misc.TurnDirection turnDirection_ = (Misc.TurnDirection)0;
					float float_7 = 0f;
					bool bool_11 = false;
					if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() == 0)
					{
						GeoPoint geoPoint_ = DefineValue(ref scenario_0, ref flight_0, ref aircraft_0);
						GeoPoint geoPoint_2 = PublishValue(ref scenario_0, ref flight_0, ref aircraft_0);
						GeoPoint geoPoint_3 = AwakeValue(ref scenario_0, ref flight_0, ref aircraft_0);
						if (!bool_6)
						{
							QueryValue(ref float_1, ref float_2, float_3, float_4, bool_3);
						}
						if (float_11 < (float)(aircraftMissionProfile_.AttackDistanceIngress + 15))
						{
							RunValue(ref scenario_0, ref side_0, ref mission_0, ref flight_0, ref aircraft_0, ref strike_, ref formation_, contact_0, ref geoPoint_2, ref geoPoint_, ref geoPoint_3, float_12, float_5, float_6, ref turnDirection_, ref float_7, ref float_8, ref aircraftMissionProfile_, ref bool_11, ref float_9, ref float_10, ref float_11, ref bool_2, float_3, ref weapon_0, float_4, ref float_2, ref float_1, _RadarBehaviour_0, ref bool_5, bool_3, ref string_0, nullable_0, bool_7, ref float_0, bool_8, ref bool_10, nullable_1, nullable_2, bool_9);
						}
						else
						{
							StartValue(ref scenario_0, ref side_0, ref mission_0, ref flight_0, ref aircraft_0, ref strike_, ref formation_, contact_0, ref geoPoint_2, ref geoPoint_, ref geoPoint_3, float_12, float_5, float_6, ref turnDirection_, ref float_7, ref float_8, ref aircraftMissionProfile_, ref bool_11, ref float_9, ref float_10, ref float_11, ref bool_2, float_3, ref weapon_0, float_4, ref float_2, ref float_1, _RadarBehaviour_0, ref bool_5, bool_3, ref string_0, nullable_0, bool_7, ref float_0, bool_8, ref bool_10, nullable_1, nullable_2, bool_9);
						}
					}
					if (!bool_0)
					{
						if (bool_11)
						{
							Mission.Flight flight;
							Waypoint[] waypoint_ = (flight = flight_0).FlightPlan;
							bool num = ResolveValue(ref scenario_0, ref waypoint_, bool_8);
							flight.FlightPlan = waypoint_;
							if (num)
							{
								waypoint_ = (flight = flight_0).FlightPlan;
								bool num2 = SortValue(ref scenario_0, ref side_0, ref mission_0, ref aircraft_0, ref waypoint_, float_8, bool_0: false);
								flight.FlightPlan = waypoint_;
								if (num2)
								{
									return false;
								}
								Scenario scenario_ = scenario_0;
								Mission strike_2 = mission_0;
								Aircraft object_ = aircraft_0;
								Mission.Flight flight_ = flight_0;
								waypoint_ = (flight = flight_0).FlightPlan;
								ConnectTokenizer(scenario_, strike_2, object_, flight_, ref waypoint_, ref float_0, ref float_7, bool_0: false, !bool_2, bool_2: false, bool_3: false, bool_4: true, bool_5: false, bool_6: true, float_12, float_5, turnDirection_, bool_3, bool_2, bool_5, nullable_1, nullable_2, bool_9);
								flight.FlightPlan = waypoint_;
								if (bool_10)
								{
									if (Information.IsNothing(flight_0.NotificationList))
									{
										flight_0.NotificationList = new List<string>();
									}
									flight_0.NotificationList.Add(aircraft_0.UnitClass + "与挂载" + aircraft_0.Loadout.Name + "在任务上" + mission_0.Name + "有一个允许空对空加油（AAR）的条令设置。但是，在给定武器挂载和飞行剖面的情况下，到目标的距离短于飞机的最大作战半径。因此，此编队计划中的所有航路点都禁用AAR。");
								}
								return true;
							}
							flight_0.ClearFlightPlan();
							flight_0.FlightCannotLaunch = true;
							string_0 = "起飞时间将在过去。没有生成飞行计划。";
							return false;
						}
						string_0 = "等待路径查找器在禁航区域周围创建飞行计划。";
						return false;
					}
					if ((bool_11 || flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0) && side_0.NoNavZones.Count > 0)
					{
						Waypoint[] waypoint_2;
						Mission.Flight flight2;
						if (bool_11)
						{
							waypoint_2 = (flight2 = flight_0).FlightPlan;
							bool num3 = ResolveValue(ref scenario_0, ref waypoint_2, bool_8);
							flight2.FlightPlan = waypoint_2;
							if (!num3)
							{
								flight_0.ClearFlightPlan();
								flight_0.FlightCannotLaunch = true;
								string_0 = "起飞时间将在过去。没有生成飞行计划。";
								return false;
							}
						}
						waypoint_2 = (flight2 = flight_0).FlightPlan;
						SortValue(ref scenario_0, ref side_0, ref mission_0, ref aircraft_0, ref waypoint_2, float_8, bool_0: true);
						flight2.FlightPlan = waypoint_2;
						if (flight_0.FlightPlan.Count() == 0 || flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
						{
							ActiveUnit activeUnit_ = flight_0.GetReferenceUnit(scenario_0);
							Aircraft aircraft_ = null;
							if (flight_0.GetReferenceUnit(scenario_0).IsAircraft)
							{
								aircraft_ = (Aircraft)flight_0.GetReferenceUnit(scenario_0);
							}
							GeoPoint geoPoint_4 = DefineValue(ref scenario_0, ref flight_0, ref aircraft_0);
							GeoPoint geoPoint_5 = PublishValue(ref scenario_0, ref flight_0, ref aircraft_0);
							GeoPoint geoPoint_6 = AwakeValue(ref scenario_0, ref flight_0, ref aircraft_0);
							if (!side_0.IsHumanControlled)
							{
								_ProxyConsumer = true;
							}
							if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() == 0)
							{
								if (!(bool_2 || bool_4))
								{
									Mission.Flight obj = flight_0;
									waypoint_2 = obj.FlightPlan_Pathfinder_Ingress_1;
									ArrayExtensions.Clear(ref waypoint_2);
									obj.FlightPlan_Pathfinder_Ingress_1 = waypoint_2;
									Mission.Flight obj2 = flight_0;
									waypoint_2 = obj2.FlightPlan_Pathfinder_Egress_1;
									ArrayExtensions.Clear(ref waypoint_2);
									obj2.FlightPlan_Pathfinder_Egress_1 = waypoint_2;
									flight_0.Pathfinder_Ingress_RequestBeingProcessed = true;
									flight_0.PathfinderRequestBeingProcessed_OnThisPulse = true;
									aircraft_0.Navigator.TriggerPathfinderThread(null, null, flight_0, bool_1: true, float_8, contact_0.GetLatitude(), contact_0.GetLongitude(), scenario_0, bool_2: false);
									if (bool_1 && !Information.IsNothing(flight_0.PrimaryTarget))
									{
										flight_0.Pathfinder_Egress_RequestBeingProcessed = true;
										aircraft_0.Navigator.TriggerPathfinderThread(null, null, flight_0, bool_1: false, float_8, geoPoint_4.Latitude, geoPoint_4.Longitude, scenario_0, bool_2: false);
									}
									return true;
								}
								if (Information.IsNothing(_ProxyConsumer))
								{
									if (Interaction.MsgBox("攻击计划者无法为其制定直达航线计划" + aircraft_.Name + "由于导航区域的存在。您是否希望寻路算法尝试寻找路线？这可能会需要几分钟。请注意，寻路算法不允许飞机在任何禁航区域内飞行超过0.2度（赤道12海里）。", MsgBoxStyle.YesNo, "尝试在禁航区域周围寻路？") == MsgBoxResult.Yes)
									{
										_ProxyConsumer = true;
									}
									else
									{
										_ProxyConsumer = false;
									}
								}
								if (!_ProxyConsumer.GetValueOrDefault())
								{
									string_0 = "探路者不允许为飞行计划创建出口航段。没有创建飞行计划。请注意，探路者不允许飞机在任何禁航区域内飞行超过0.2度（赤道12海里）。";
									return false;
								}
								flight_0.GetReferenceUnit(scenario_0).Navigator.StartPathfinding(null, null, flight_0, bool_1: true, float_8, contact_0.GetLatitude(), contact_0.GetLongitude(), scenario_0, bool_2: false);
								if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() <= 0)
								{
									string_0 = "无法为飞行计划创建入口航段。请注意，探路者不允许飞机在任何禁航区域内飞行超过0.2度（赤道12海里）。";
									return false;
								}
								if (bool_2)
								{
									flight_0.GetReferenceUnit(scenario_0).Navigator.StartPathfinding(null, null, flight_0, bool_1: false, float_8, geoPoint_4.Latitude, geoPoint_4.Longitude, scenario_0, bool_2: false);
									if (flight_0.FlightPlan_Pathfinder_Egress_1.Count() == 0)
									{
										string_0 = "无法为飞行计划创建出口航段。请注意，探路者不允许飞机在任何禁航区域内飞行超过0.2度（赤道12海里）。";
										return false;
									}
								}
							}
							if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
							{
								return ListValue(ref scenario_0, ref side_0, ref mission_0, ref strike_, ref flight_0, ref aircraft_0, ref nullable_0, ref contact_0, ref string_0, ref _RadarBehaviour_0, bool_2, ref float_0, ref activeUnit_, ref aircraft_, ref float_9, ref geoPoint_5, ref geoPoint_4, ref geoPoint_6, ref aircraftMissionProfile_, ref formation_, ref float_11, ref float_10, ref turnDirection_, float_12, float_5, float_6, ref float_4, ref float_8, ref float_7, ref float_3, ref weapon_0, float_4, ref bool_5, bool_7, bool_8, nullable_1, nullable_2, bool_9);
							}
							if (bool_11)
							{
								waypoint_2 = (flight2 = flight_0).FlightPlan;
								bool num4 = ResolveValue(ref scenario_0, ref waypoint_2, bool_8);
								flight2.FlightPlan = waypoint_2;
								if (num4)
								{
									Scenario scenario_2 = scenario_0;
									Mission strike_3 = mission_0;
									Aircraft object_2 = aircraft_0;
									Mission.Flight flight_2 = flight_0;
									waypoint_2 = (flight2 = flight_0).FlightPlan;
									ConnectTokenizer(scenario_2, strike_3, object_2, flight_2, ref waypoint_2, ref float_0, ref float_7, bool_0: false, !bool_2, bool_2: false, bool_3: false, bool_4: true, bool_5: false, bool_6: true, float_12, float_5, turnDirection_, bool_3, bool_2, bool_5, null, null, bool_9);
									flight2.FlightPlan = waypoint_2;
									if (bool_10)
									{
										if (Information.IsNothing(flight_0.NotificationList))
										{
											flight_0.NotificationList = new List<string>();
										}
										flight_0.NotificationList.Add(aircraft_0.UnitClass + "与挂载" + aircraft_0.Loadout.Name + "在任务上" + mission_0.Name + "有一个允许空对空加油（AAR）的条令设置。但是，在给定武器挂载和飞行剖面的情况下，到目标的距离短于飞机的最大作战半径。因此，此编队计划中的所有航路点都禁用AAR。");
									}
									return true;
								}
								flight_0.ClearFlightPlan();
								flight_0.FlightCannotLaunch = true;
								string_0 = "起飞时间将在过去。没有生成飞行计划。";
								return false;
							}
						}
					}
					if (bool_11)
					{
						Mission.Flight flight3;
						Waypoint[] waypoint_3 = (flight3 = flight_0).FlightPlan;
						bool num5 = ResolveValue(ref scenario_0, ref waypoint_3, bool_8);
						flight3.FlightPlan = waypoint_3;
						if (num5)
						{
							Scenario scenario_3 = scenario_0;
							Mission strike_4 = mission_0;
							Aircraft object_3 = aircraft_0;
							Mission.Flight flight_3 = flight_0;
							waypoint_3 = (flight3 = flight_0).FlightPlan;
							ConnectTokenizer(scenario_3, strike_4, object_3, flight_3, ref waypoint_3, ref float_0, ref float_7, bool_0: false, !bool_2, bool_2: false, bool_3: false, bool_4: true, bool_5: false, bool_6: true, float_12, float_5, turnDirection_, bool_3, bool_2, bool_5, null, null, bool_9);
							flight3.FlightPlan = waypoint_3;
							if (bool_10)
							{
								if (Information.IsNothing(flight_0.NotificationList))
								{
									flight_0.NotificationList = new List<string>();
								}
								flight_0.NotificationList.Add(aircraft_0.UnitClass + "与挂载" + aircraft_0.Loadout.Name + "在任务上" + mission_0.Name + "有一个允许空对空加油（AAR）的条令设置。但是，在给定武器挂载和飞行剖面的情况下，到目标的距离短于飞机的最大作战半径。因此，此编队计划中的所有航路点都禁用AAR。");
							}
							return true;
						}
						flight_0.ClearFlightPlan();
						flight_0.FlightCannotLaunch = true;
						string_0 = "起飞时间将在过去。没有生成飞行计划。";
						return false;
					}
				}
				if (string.IsNullOrEmpty(string_0))
				{
					string_0 = "不能生成飞行计划。原因未知。";
				}
				return false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101108", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
		}
		string_0 = "任务不是攻击任务。没有创建飞行计划。";
		return false;
	}

	private static bool ListValue(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Strike strike_0, ref Mission.Flight flight_0, ref Aircraft aircraft_0, ref bool? nullable_0, ref Contact contact_0, ref string string_0, ref Mission._RadarBehaviour _RadarBehaviour_0, bool bool_0, ref float float_0, ref ActiveUnit activeUnit_0, ref Aircraft aircraft_1, ref float float_1, ref GeoPoint geoPoint_0, ref GeoPoint geoPoint_1, ref GeoPoint geoPoint_2, ref AircraftMissionProfile aircraftMissionProfile_0, ref Waypoint.Formation formation_0, ref float float_2, ref float float_3, ref Misc.TurnDirection turnDirection_0, float float_4, float float_5, float float_6, ref float float_7, ref float float_8, ref float float_9, ref float float_10, ref Weapon weapon_0, float float_11, ref bool bool_1, bool bool_2, bool bool_3, DateTime? nullable_1, DateTime? nullable_2, bool bool_4)
	{
		try
		{
			if (Information.IsNothing(flight_0.GetReferenceUnit(scenario_0)))
			{
				string_0 = "找不到飞行计划的参考单元。";
				return false;
			}
			if (Information.IsNothing(flight_0.PrimaryTarget))
			{
				string_0 = "无法找到飞行计划的主要目标。";
				return false;
			}
			flight_0.HasCriticalError = false;
			int num = 1;
			if (strike_0.AttackMethod == Mission._AttackMethod.BananaSplit)
			{
				num++;
				checked
				{
					if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
					{
						flight_0.FlightPlan_Pathfinder_Ingress_2 = new Waypoint[0];
						Waypoint[] flightPlan_Pathfinder_Ingress_ = flight_0.FlightPlan_Pathfinder_Ingress_1;
						for (int i = 0; i < flightPlan_Pathfinder_Ingress_.Length; i++)
						{
							Waypoint waypoint_ = flightPlan_Pathfinder_Ingress_[i];
							Mission.Flight obj = flight_0;
							Waypoint[] gparam_ = obj.FlightPlan_Pathfinder_Ingress_2;
							Doctrine doctrine_ = null;
							ArrayExtensions.Add(ref gparam_, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_, bool_0: true, bool_1: true, ref doctrine_));
							obj.FlightPlan_Pathfinder_Ingress_2 = gparam_;
						}
					}
					if (flight_0.FlightPlan_Pathfinder_Egress_1.Count() > 0)
					{
						flight_0.FlightPlan_Pathfinder_Egress_2 = new Waypoint[0];
						Waypoint[] flightPlan_Pathfinder_Egress_ = flight_0.FlightPlan_Pathfinder_Egress_1;
						for (int j = 0; j < flightPlan_Pathfinder_Egress_.Length; j++)
						{
							Waypoint waypoint_12 = flightPlan_Pathfinder_Egress_[j];
							Mission.Flight obj2 = flight_0;
							Waypoint[] gparam_2 = obj2.FlightPlan_Pathfinder_Egress_2;
							Doctrine doctrine_2 = null;
							ArrayExtensions.Add(ref gparam_2, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_12, bool_0: true, bool_1: true, ref doctrine_2));
							obj2.FlightPlan_Pathfinder_Egress_2 = gparam_2;
						}
					}
				}
			}
			bool flag = true;
			bool bool_6 = false;
			int num12 = num;
			double double_ = 0.0;
			double double_12 = 0.0;
			float float_12 = 0f;
			float float_13 = 0f;
			bool bool_7 = false;
			ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_ = ActiveUnit_Kinematics.UnitThrottlePreset.FullStop;
			float float_14 = 0f;
			double double_23 = 0.0;
			double double_25 = 0.0;
			Waypoint waypoint = null;
			float float_15 = 0f;
			Waypoint waypoint_14 = null;
			Waypoint waypoint_15 = null;
			Waypoint object_ = null;
			float float_16 = 0f;
			float value = 0f;
			float float_17 = 0f;
			double double_26 = 0.0;
			double double_27 = 0.0;
			for (int k = 1; k <= num12; k++)
			{
				Waypoint[] gparam_3;
				Waypoint[] gparam_4;
				if (k == 1)
				{
					gparam_3 = flight_0.FlightPlan_Pathfinder_Ingress_1;
					gparam_4 = flight_0.FlightPlan_Pathfinder_Egress_1;
				}
				else
				{
					if (k != 2)
					{
						flag = false;
						break;
					}
					gparam_3 = flight_0.FlightPlan_Pathfinder_Ingress_2;
					gparam_4 = flight_0.FlightPlan_Pathfinder_Egress_2;
				}
				bool flag2 = false;
				double double_28 = 1.0;
				double double_29 = 1.0;
				bool flag3 = false;
				if (!Information.IsNothing(gparam_3))
				{
					if (gparam_3.Count() != 0)
					{
						int num23 = gparam_3.Count();
						if (gparam_3[num23 - 1].Latitude != contact_0.GetLatitude() || gparam_3[num23 - 1].Longitude != contact_0.GetLongitude())
						{
							if (Math2.VerifyClass(gparam_3[num23 - 1].Latitude, gparam_3[num23 - 1].Longitude, contact_0.GetLatitude(), contact_0.GetLongitude()) > 5f)
							{
								ref Waypoint waypoint_16 = ref gparam_3[num23 - 1];
								Doctrine doctrine_3 = null;
								ArrayExtensions.Add(ref gparam_3, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_16, bool_0: false, bool_1: false, ref doctrine_3));
								num23 = gparam_3.Count();
							}
							gparam_3[num23 - 1].Latitude = contact_0.GetLatitude();
							gparam_3[num23 - 1].Longitude = contact_0.GetLongitude();
						}
						float num34 = 0f;
						Waypoint waypoint11 = gparam_3[num23 - 1];
						bool flag4 = false;
						bool flag5 = false;
						float num37 = float_1 + float_4 + 20f;
						Waypoint waypoint12;
						if (num23 - 1 == 0)
						{
							float num38 = Math2.VerifyClass(gparam_3[num23 - 1].Latitude, gparam_3[num23 - 1].Longitude, activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude());
							if (float_1 <= num38)
							{
								float float_18 = Math2.PublishClass(gparam_3[num23 - 1].Latitude, gparam_3[num23 - 1].Longitude, aircraft_1.GetLatitude(), aircraft_1.GetLongitude());
								Geodesic_EdWilliams.CalcPoint_Williams(gparam_3[num23 - 1].Longitude, gparam_3[num23 - 1].Latitude, ref double_, ref double_12, float_1, Math2.UpdateClass(float_18));
								waypoint12 = new Waypoint(double_, double_12, 0f, Waypoint.WaypointType.InitialPoint, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
								ActiveUnit_Navigator.AddWaypoint(ref gparam_3, num23 - 1, waypoint12);
								if (num37 < num38)
								{
									flag5 = true;
								}
							}
							else
							{
								Math2.PublishClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), gparam_3[num23 - 1].Latitude, gparam_3[num23 - 1].Longitude);
								waypoint12 = new Waypoint(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude(), 0f, Waypoint.WaypointType.InitialPoint, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
							}
						}
						else
						{
							float num39 = Math2.VerifyClass(gparam_3[num23 - 1].Latitude, gparam_3[num23 - 1].Longitude, gparam_3[num23 - 2].Latitude, gparam_3[num23 - 2].Longitude);
							if (num39 <= float_1 + 5f)
							{
								waypoint12 = gparam_3[num23 - 2];
								waypoint12.Type = Waypoint.WaypointType.InitialPoint;
								flag3 = true;
							}
							else
							{
								float float_19 = Math2.PublishClass(gparam_3[num23 - 1].Latitude, gparam_3[num23 - 1].Longitude, gparam_3[num23 - 2].Latitude, gparam_3[num23 - 2].Longitude);
								Geodesic_EdWilliams.CalcPoint_Williams(gparam_3[num23 - 1].Longitude, gparam_3[num23 - 1].Latitude, ref double_, ref double_12, float_1, Math2.UpdateClass(float_19));
								waypoint12 = new Waypoint(double_, double_12, 0f, Waypoint.WaypointType.InitialPoint, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
								ActiveUnit_Navigator.AddWaypoint(ref gparam_3, num23 - 1, waypoint12);
								if (num37 < num39)
								{
									flag5 = true;
								}
							}
						}
						if (!Information.IsNothing(waypoint12))
						{
							if (!flag5 && flight_0.DesiredAircraftQty > 1 && strike_0.AttackMethod >= Mission._AttackMethod.MultiAxisSimultaneousToT)
							{
								scenario_0.AddMessage(aircraft_0.UnitClass + "与挂载" + aircraft_0.Loadout.Name + "在任务上" + strike_0.Name + "由于存在禁航区域，无法创建多方位攻击飞行计划。创建具有编队攻击的飞行计划。", strike_0.Name + " cannot do multi-axis", LoggedMessage.MessageType.AirOps, 0, aircraft_0.ObjectID, aircraft_0.GetUnitSide(), new Geopoint_Struct(aircraft_0.GetLongitude(), aircraft_0.GetLatitude()));
							}
							float num40 = (bool_0 ? Math2.PublishClass(aircraft_0.GetLatitude(), aircraft_0.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude()) : Math2.PublishClass(geoPoint_0.Latitude, geoPoint_0.Longitude, contact_0.GetLatitude(), contact_0.GetLongitude()));
							int num41 = 0;
							float float_20;
							if (aircraft_0.IsHelicopter)
							{
								if (aircraftMissionProfile_0.FormUpTime < 2)
								{
									if (float_2 < 20f && float_2 > 0f)
									{
										if (float_2 < 10f)
										{
											float_20 = 5f;
											flag4 = true;
										}
										else
										{
											float_20 = float_2 / 2f;
											flag4 = true;
										}
									}
									else
									{
										float_20 = 10f;
									}
								}
								else
								{
									if (float_2 < 10f)
									{
										flag4 = true;
									}
									float num2 = aircraft_0.Kinematics.GetMaximumSpeed(aircraftMissionProfile_0.FormUpAltitude * 0.3048f, ActiveUnit.Throttle.Loiter, bool_0: false);
									num41 = 2;
									float_20 = num2 * 2f / 60f;
								}
							}
							else if (aircraftMissionProfile_0.FormUpTime < 2)
							{
								if (float_2 < 30f)
								{
									flag4 = true;
								}
								float_20 = 10f;
							}
							else
							{
								if (float_2 < 30f)
								{
									flag4 = true;
								}
								float num3 = aircraft_0.Kinematics.GetMaximumSpeed(aircraftMissionProfile_0.FormUpAltitude * 0.3048f, ActiveUnit.Throttle.Loiter, bool_0: false);
								num41 = 2;
								float_20 = num3 * 2f / 60f;
							}
							int num4 = aircraftMissionProfile_0.FormUpTime - num41;
							ConcatTokenizer(null, aircraft_1, ref gparam_3, geoPoint_0.Latitude, geoPoint_0.Longitude, aircraftMissionProfile_0, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_0, Waypoint.TurnRateCategory.StandardRateTurn);
							Waypoint waypoint13;
							if (aircraft_0.IsHelicopter)
							{
								if (float_2 <= 0f)
								{
									Geodesic_EdWilliams.CalcPoint_Williams(geoPoint_0.Longitude, geoPoint_0.Latitude, ref double_23, ref double_25, float_20, Math2.UpdateClass(num40 + 180f + float_3));
								}
								else
								{
									Geodesic_EdWilliams.CalcPoint_Williams(geoPoint_0.Longitude, geoPoint_0.Latitude, ref double_23, ref double_25, float_20, Math2.UpdateClass(num40 + float_3));
								}
								waypoint13 = new Waypoint(double_23, double_25, 0f, Waypoint.WaypointType.Assemble, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
								ActiveUnit_Navigator.AddWaypoint(ref gparam_3, 1, waypoint13);
								WriteTokenizer(waypoint13, aircraft_1, ref gparam_3, double_25, double_23, aircraftMissionProfile_0, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
								waypoint13 = gparam_3[1];
							}
							else
							{
								if (flag4)
								{
									Geodesic_EdWilliams.CalcPoint_Williams(geoPoint_0.Longitude, geoPoint_0.Latitude, ref double_23, ref double_25, float_20, Math2.UpdateClass(num40 + 180f + float_3));
								}
								else
								{
									Geodesic_EdWilliams.CalcPoint_Williams(geoPoint_0.Longitude, geoPoint_0.Latitude, ref double_23, ref double_25, float_20, Math2.UpdateClass(num40 + float_3));
								}
								if (num4 <= 0)
								{
									waypoint13 = new Waypoint(double_23, double_25, 0f, Waypoint.WaypointType.Assemble, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
									ActiveUnit_Navigator.AddWaypoint(ref gparam_3, 1, waypoint13);
									WriteTokenizer(waypoint13, aircraft_1, ref gparam_3, double_25, double_23, aircraftMissionProfile_0, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
									waypoint13 = gparam_3[1];
								}
								else
								{
									waypoint13 = new Waypoint(double_23, double_25, 0f, Waypoint.WaypointType.HoldStart, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
									ActiveUnit_Navigator.AddWaypoint(ref gparam_3, 1, waypoint13);
									NewTokenizer(waypoint13, aircraft_1, ref gparam_3, double_25, double_23, aircraftMissionProfile_0, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_0, Waypoint.TurnRateCategory.StandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
									waypoint13 = gparam_3[1];
									waypoint = new Waypoint(double_23, double_25, 0f, Waypoint.WaypointType.HoldEnd, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
									ActiveUnit_Navigator.AddWaypoint(ref gparam_3, 2, waypoint);
									Waypoint waypoint_17 = waypoint;
									Aircraft aircraft_2 = aircraft_0;
									double double_30 = double_25;
									double double_2 = double_23;
									AircraftMissionProfile aircraftMissionProfile_ = aircraftMissionProfile_0;
									bool bool_8 = true;
									waypoint = PushTokenizer(waypoint_17, aircraft_2, ref gparam_3, double_30, double_2, aircraftMissionProfile_, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, ref mission_0, ref bool_8, num4);
								}
							}
							float num5;
							if (bool_0)
							{
								Math2.PublishClass(aircraft_0.GetLatitude(), aircraft_0.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude());
								num5 = Math2.PublishClass(contact_0.GetLatitude(), contact_0.GetLongitude(), aircraft_0.GetLatitude(), aircraft_0.GetLongitude());
							}
							else
							{
								Math2.PublishClass(double_25, double_23, contact_0.GetLatitude(), contact_0.GetLongitude());
								num5 = Math2.PublishClass(contact_0.GetLatitude(), contact_0.GetLongitude(), double_25, double_23);
							}
							if (bool_0)
							{
								Waypoint waypoint14 = new Waypoint(aircraft_1.GetLongitude(), aircraft_1.GetLatitude(), 0f, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
								if (!aircraft_0.IsHelicopter && num4 > 0)
								{
									ActiveUnit_Navigator.AddWaypoint(ref gparam_3, 3, waypoint14);
								}
								else
								{
									ActiveUnit_Navigator.AddWaypoint(ref gparam_3, 2, waypoint14);
								}
								RemoveTokenizer(waypoint14, aircraft_1, ref gparam_3, aircraft_1.GetLatitude(), aircraft_1.GetLongitude(), aircraftMissionProfile_0, Mission._RadarBehaviour.None, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
							}
							float num7;
							if (aircraftMissionProfile_0.AttackDistanceIngress <= 0)
							{
								float num6 = (bool_0 ? Math2.VerifyClass(aircraft_0.GetLatitude(), aircraft_0.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude()) : Math2.VerifyClass(double_25, double_23, contact_0.GetLatitude(), contact_0.GetLongitude())) - float_1;
								if (num6 <= 50f)
								{
									num7 = num6 / 2f;
									if ((double)num7 < (double)float_4 * 1.5)
									{
										if ((double)float_4 * 1.5 <= (double)(num6 - 5f))
										{
											num7 = (float)((double)float_4 * 1.5);
										}
										else
										{
											num7 = (float)(((double)float_4 * 1.5 + (double)(num6 - 5f)) / 2.0);
											if (float_4 < num7 - 5f)
											{
												if (num6 < num7 + 5f)
												{
													num7 = Math.Max(num6 - 5f, 5f);
												}
												if (float_4 + 5f > num7)
												{
													num7 = float_4 + 5f;
												}
											}
											else
											{
												float_4 = 0f;
												float_5 = 0f;
											}
										}
									}
								}
								else
								{
									num7 = 50f;
								}
							}
							else
							{
								num7 = aircraftMissionProfile_0.AttackDistanceIngress;
							}
							num23 = gparam_3.Count();
							int num8 = -1;
							while (true)
							{
								num8++;
								if (num8 > gparam_3.Count() - 1)
								{
									break;
								}
								if (flag2)
								{
									gparam_3[num8].FlightFormation = Waypoint.Formation.Split;
								}
								if (gparam_3[num8] == waypoint11 || gparam_3[num8] == waypoint13 || gparam_3[num8].Type == Waypoint.WaypointType.TakeOff)
								{
									continue;
								}
								if (num7 <= 0f)
								{
									if (gparam_3[num8].Type == Waypoint.WaypointType.PathfindingPoint)
									{
										Waypoint waypoint_18 = gparam_3[num8];
										Waypoint.Formation formation_ = Waypoint.Formation.Spread;
										SetTokenizer(waypoint_18, ref gparam_3, 0.0, 0.0, ref formation_, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.FlightPlan);
									}
									continue;
								}
								if (gparam_3[num8].Type != Waypoint.WaypointType.InitialPoint && gparam_3[num8].Type != Waypoint.WaypointType.WeaponLaunch)
								{
									if (gparam_3[num8].Type == Waypoint.WaypointType.PathfindingPoint)
									{
										Waypoint waypoint_19 = gparam_3[num8];
										Waypoint.Formation formation_6 = Waypoint.Formation.Spread;
										SetTokenizer(waypoint_19, ref gparam_3, 0.0, 0.0, ref formation_6, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.FlightPlan);
									}
									continue;
								}
								if (num8 == 0)
								{
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									float num9 = Math2.VerifyClass(gparam_3[num8].Latitude, gparam_3[num8].Longitude, aircraft_1.GetLatitude(), aircraft_1.GetLongitude());
									if (num7 <= num9)
									{
										Math2.PublishClass(gparam_3[num8].Latitude, gparam_3[num8].Longitude, aircraft_1.GetLatitude(), aircraft_1.GetLongitude());
										Waypoint.Formation formation_7;
										if (!flag2 && flag5 && float_4 > 0f && float_4 < num7)
										{
											float float_21 = float_4;
											float float_22 = float_5;
											float float_23 = num5;
											float float_24 = float_1;
											formation_7 = Waypoint.Formation.Spread;
											Mission._RadarBehaviour radarBehaviour_ = _RadarBehaviour_0;
											AircraftMissionProfile aircraftMissionProfile_2 = aircraftMissionProfile_0;
											float float_25 = float_7;
											bool bool_9 = float_4 >= num7;
											Waypoint waypoint_20 = null;
											Waypoint waypoint_2 = null;
											if (flag2 = CalcValue(ref scenario_0, ref strike_0, ref flight_0, ref gparam_3, ref aircraft_0, ref contact_0, ref float_2, float_21, float_22, float_23, float_24, ref formation_7, ref float_14, radarBehaviour_, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, 0f, ref float_15, aircraftMissionProfile_2, float_25, bool_0, bool_2: false, bool_9, ref waypoint_20, ref waypoint_2, ref bool_1, ref waypoint_14, ref waypoint_15, object_, bool_5: false))
											{
												num8 += 2;
											}
										}
										if (float_7 < 6f)
										{
											Geodesic_EdWilliams.CalcPoint_Williams(gparam_3[num8 + 1].Longitude, gparam_3[num8 + 1].Latitude, ref double_29, ref double_28, num7, num5);
										}
										else
										{
											Geodesic_EdWilliams.CalcPoint_Williams(gparam_3[num8].Longitude, gparam_3[num8].Latitude, ref double_29, ref double_28, num7, num5);
										}
										Waypoint waypoint15 = new Waypoint(double_29, double_28, 0f, Waypoint.WaypointType.StrikeIngress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
										ActiveUnit_Navigator.AddWaypoint(ref gparam_3, num8, waypoint15);
										Aircraft aircraft_3 = aircraft_1;
										double double_3 = double_28;
										double double_4 = double_29;
										AircraftMissionProfile aircraftMissionProfile_3 = aircraftMissionProfile_0;
										Mission._RadarBehaviour radarBehaviour_2 = _RadarBehaviour_0;
										formation_7 = Waypoint.Formation.Spread;
										InvokeTokenizer(waypoint15, aircraft_3, ref gparam_3, double_3, double_4, aircraftMissionProfile_3, radarBehaviour_2, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_7, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
										num8++;
									}
									else
									{
										Math2.PublishClass(aircraft_1.GetLatitude(), aircraft_1.GetLongitude(), gparam_3[num8].Latitude, gparam_3[num8].Longitude);
										Waypoint waypoint16 = new Waypoint(aircraft_1.GetLongitude(), aircraft_1.GetLatitude(), 0f, Waypoint.WaypointType.StrikeIngress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
										ActiveUnit_Navigator.AddWaypoint(ref gparam_3, num8, waypoint16);
										Aircraft aircraft_4 = aircraft_1;
										double latitude = aircraft_1.GetLatitude();
										double longitude = aircraft_1.GetLongitude();
										AircraftMissionProfile aircraftMissionProfile_4 = aircraftMissionProfile_0;
										Mission._RadarBehaviour radarBehaviour_3 = _RadarBehaviour_0;
										Waypoint.Formation formation_8 = Waypoint.Formation.Spread;
										InvokeTokenizer(waypoint16, aircraft_4, ref gparam_3, latitude, longitude, aircraftMissionProfile_4, radarBehaviour_3, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_8, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
										num8++;
									}
								}
								else
								{
									float num10 = ((!(float_7 < 6f) || num8 >= gparam_3.Count() - 1) ? Math2.VerifyClass(gparam_3[num8].Latitude, gparam_3[num8].Longitude, gparam_3[num8 - 1].Latitude, gparam_3[num8 - 1].Longitude) : Math2.VerifyClass(gparam_3[num8 + 1].Latitude, gparam_3[num8 + 1].Longitude, gparam_3[num8 - 1].Latitude, gparam_3[num8 - 1].Longitude));
									float_16 = Math2.PublishClass(gparam_3[num8].Latitude, gparam_3[num8].Longitude, gparam_3[num8 - 1].Latitude, gparam_3[num8 - 1].Longitude);
									if (!flag2 && flag5 && float_4 > 0f && float_4 < num7 && float_4 < num10 && flight_0.DesiredAircraftQty != 1)
									{
										Waypoint waypoint_3 = new Waypoint(double_29, double_28, 0f, Waypoint.WaypointType.StrikeIngress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
										Waypoint waypoint_4;
										if (num7 > 0f && num7 <= float_4)
										{
											waypoint_4 = gparam_3[num8 - 1];
											ActiveUnit_Navigator.AddWaypoint(ref gparam_3, num8, waypoint_3);
										}
										else
										{
											waypoint_4 = new Waypoint(double_29, double_28, 0f, Waypoint.WaypointType.StrikeIngress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
											ActiveUnit_Navigator.AddWaypoint(ref gparam_3, num8, waypoint_4);
											ActiveUnit_Navigator.AddWaypoint(ref gparam_3, num8 + 1, waypoint_3);
										}
										if (flag2 = CalcValue(ref scenario_0, ref strike_0, ref flight_0, ref gparam_3, ref aircraft_0, ref contact_0, ref float_2, float_4, float_5, float_16, float_1, ref formation_0, ref float_14, _RadarBehaviour_0, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, 0f, ref float_15, aircraftMissionProfile_0, float_7, bool_0, bool_2: false, float_4 >= num7, ref waypoint_4, ref waypoint_3, ref bool_1, ref waypoint_14, ref waypoint_15, object_, bool_5: false))
										{
											num8 = ((!(num7 > 0f) || num7 > float_4) ? (num8 + 2) : (num8 + 1));
										}
									}
									if (num10 <= num7)
									{
										num34 = num10;
									}
									else
									{
										if (num10 - num7 < 5f)
										{
											num7 -= 5f;
										}
										if (float_7 < 6f)
										{
											Geodesic_EdWilliams.CalcPoint_Williams(gparam_3[num8 + 1].Longitude, gparam_3[num8 + 1].Latitude, ref double_29, ref double_28, num7, Math2.UpdateClass(float_16));
										}
										else
										{
											Geodesic_EdWilliams.CalcPoint_Williams(gparam_3[num8].Longitude, gparam_3[num8].Latitude, ref double_29, ref double_28, num7, Math2.UpdateClass(float_16));
										}
										Waypoint waypoint17 = new Waypoint(double_29, double_28, 0f, Waypoint.WaypointType.StrikeIngress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
										if (flag2)
										{
											ActiveUnit_Navigator.AddWaypoint(ref gparam_3, num8 - 2, waypoint17);
										}
										else
										{
											ActiveUnit_Navigator.AddWaypoint(ref gparam_3, num8, waypoint17);
										}
										Aircraft aircraft_5 = aircraft_1;
										double double_5 = double_28;
										double double_6 = double_29;
										AircraftMissionProfile aircraftMissionProfile_5 = aircraftMissionProfile_0;
										Mission._RadarBehaviour radarBehaviour_4 = _RadarBehaviour_0;
										Waypoint.Formation formation_9 = Waypoint.Formation.Spread;
										InvokeTokenizer(waypoint17, aircraft_5, ref gparam_3, double_5, double_6, aircraftMissionProfile_5, radarBehaviour_4, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_9, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
										num8++;
										if (!flag2 && flag5 && flight_0.DesiredAircraftQty != 1 && float_4 > 0f)
										{
											Waypoint waypoint_5 = new Waypoint(double_29, double_28, 0f, Waypoint.WaypointType.StrikeIngress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
											Waypoint waypoint_6;
											if (num7 > 0f && num7 <= float_4)
											{
												waypoint_6 = gparam_3[num8 - 1];
												ActiveUnit_Navigator.AddWaypoint(ref gparam_3, num8, waypoint_5);
											}
											else
											{
												waypoint_6 = new Waypoint(double_29, double_28, 0f, Waypoint.WaypointType.StrikeIngress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
												ActiveUnit_Navigator.AddWaypoint(ref gparam_3, num8, waypoint_6);
												ActiveUnit_Navigator.AddWaypoint(ref gparam_3, num8 + 1, waypoint_5);
											}
											if (flag2 = CalcValue(ref scenario_0, ref strike_0, ref flight_0, ref gparam_3, ref aircraft_0, ref contact_0, ref float_2, float_4, float_5, float_16, float_1, ref formation_0, ref float_14, _RadarBehaviour_0, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, 0f, ref float_15, aircraftMissionProfile_0, float_7, bool_0, bool_2: false, float_4 >= num7, ref waypoint_6, ref waypoint_5, ref bool_1, ref waypoint_14, ref waypoint_15, object_, bool_5: false))
											{
												num8 = ((!(num7 > 0f) || num7 > float_4) ? (num8 + 2) : (num8 + 1));
											}
										}
										num34 = num7;
									}
								}
								if (!(num34 < num7))
								{
									continue;
								}
								for (int l = num8 - 1; l >= 0; l += -1)
								{
									if (gparam_3[l].Type == Waypoint.WaypointType.StrikeIngress || gparam_3[l].Type == Waypoint.WaypointType.TakeOff)
									{
										continue;
									}
									float num11 = num7 - num34;
									float num13 = Math2.PublishClass(gparam_3[l - 1].Latitude, gparam_3[l - 1].Longitude, gparam_3[l].Latitude, gparam_3[l].Longitude);
									float num14 = Math2.PublishClass(gparam_3[l].Latitude, gparam_3[l].Longitude, gparam_3[l + 1].Latitude, gparam_3[l + 1].Longitude);
									float num15 = Math.Abs(MathFunctions.DeleteRequest(num13, num14));
									num15 = Math2.UpdateClass(num15 * 2f);
									switch (Misc.CountValue(num13, num14))
									{
									case Misc.TurnDirection.TurnRight:
										value = 9f;
										break;
									case Misc.TurnDirection.TurnLeft:
										value = -9f;
										break;
									}
									float num16 = ActiveUnit_Kinematics.TurnRateCategoryToActualTurnRate(gparam_3[l - 1].TurnRate_Navigation, float_14);
									float num17 = Math.Abs(value) / num16;
									float num18 = float_14 / 3600f * num17;
									float num19 = (float)((double)float_14 / ((double)num16 * 3.14159265358979 * 20.0));
									float num20 = (float)((double)(2f * num19) * Math.Sin(0.5 * MathFunctions.DestroyRequest(num15))) + num18 * 2f;
									if (num11 < num20 + 2f)
									{
										num11 = num20 + 2f;
									}
									if (l != 0 && gparam_3[l].Type != Waypoint.WaypointType.HoldStart)
									{
										float num21 = Math2.VerifyClass(gparam_3[l].Latitude, gparam_3[l].Longitude, gparam_3[l - 1].Latitude, gparam_3[l - 1].Longitude);
										if (num21 <= num11)
										{
											num34 += num21;
										}
										else
										{
											float float_26 = Math2.PublishClass(gparam_3[l].Latitude, gparam_3[l].Longitude, gparam_3[l - 1].Latitude, gparam_3[l - 1].Longitude);
											Geodesic_EdWilliams.CalcPoint_Williams(gparam_3[l].Longitude, gparam_3[l].Latitude, ref double_29, ref double_28, num11, Math2.UpdateClass(float_26));
											Waypoint waypoint18 = new Waypoint(double_29, double_28, 0f, Waypoint.WaypointType.StrikeIngress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
											ActiveUnit_Navigator.AddWaypoint(ref gparam_3, l, waypoint18);
											Aircraft aircraft_6 = aircraft_1;
											double double_7 = double_28;
											double double_8 = double_29;
											AircraftMissionProfile aircraftMissionProfile_6 = aircraftMissionProfile_0;
											Mission._RadarBehaviour radarBehaviour_5 = _RadarBehaviour_0;
											Waypoint.Formation formation_10 = Waypoint.Formation.Spread;
											InvokeTokenizer(waypoint18, aircraft_6, ref gparam_3, double_7, double_8, aircraftMissionProfile_6, radarBehaviour_5, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_10, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
											num8++;
											num34 = num7;
										}
									}
									else
									{
										float num22 = Math2.VerifyClass(gparam_3[l].Latitude, gparam_3[l].Longitude, aircraft_1.GetLatitude(), aircraft_1.GetLongitude());
										if (num11 <= num22)
										{
											float float_27 = Math2.PublishClass(gparam_3[l].Latitude, gparam_3[l].Longitude, aircraft_1.GetLatitude(), aircraft_1.GetLongitude());
											Geodesic_EdWilliams.CalcPoint_Williams(gparam_3[l].Longitude, gparam_3[l].Latitude, ref double_29, ref double_28, num11, Math2.UpdateClass(float_27));
											Waypoint waypoint2 = new Waypoint(double_29, double_28, 0f, Waypoint.WaypointType.StrikeIngress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
											ActiveUnit_Navigator.AddWaypoint(ref gparam_3, l, waypoint2);
											Aircraft aircraft_7 = aircraft_1;
											double double_9 = double_28;
											double double_10 = double_29;
											AircraftMissionProfile aircraftMissionProfile_7 = aircraftMissionProfile_0;
											Mission._RadarBehaviour radarBehaviour_6 = _RadarBehaviour_0;
											Waypoint.Formation formation_11 = Waypoint.Formation.Spread;
											InvokeTokenizer(waypoint2, aircraft_7, ref gparam_3, double_9, double_10, aircraftMissionProfile_7, radarBehaviour_6, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_11, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
											num8++;
										}
										else
										{
											float float_28 = Math2.PublishClass(aircraft_1.GetLatitude(), aircraft_1.GetLongitude(), gparam_3[l].Latitude, gparam_3[l].Longitude);
											float float_29 = 5f;
											Geodesic_EdWilliams.CalcPoint_Williams(gparam_3[l].Longitude, gparam_3[l].Latitude, ref double_29, ref double_28, float_29, Math2.UpdateClass(float_28));
											Waypoint waypoint3 = new Waypoint(double_29, double_28, 0f, Waypoint.WaypointType.StrikeIngress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
											ActiveUnit_Navigator.AddWaypoint(ref gparam_3, l + 1, waypoint3);
											Aircraft aircraft_8 = aircraft_1;
											double latitude2 = aircraft_1.GetLatitude();
											double longitude2 = aircraft_1.GetLongitude();
											AircraftMissionProfile aircraftMissionProfile_8 = aircraftMissionProfile_0;
											Mission._RadarBehaviour radarBehaviour_7 = _RadarBehaviour_0;
											Waypoint.Formation formation_12 = Waypoint.Formation.Spread;
											InvokeTokenizer(waypoint3, aircraft_8, ref gparam_3, latitude2, longitude2, aircraftMissionProfile_8, radarBehaviour_7, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_12, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
											num8++;
										}
										num34 += num7;
									}
									if (num34 >= num7)
									{
										break;
									}
								}
							}
							if (!aircraft_0.IsHelicopter && !Information.IsNothing(waypoint))
							{
								float num24 = Math2.VerifyClass(double_25, double_23, gparam_3[3].Latitude, gparam_3[3].Longitude);
								float num25 = Math2.PublishClass(double_25, double_23, gparam_3[3].Latitude, gparam_3[3].Longitude);
								float num26 = 0f;
								float float_30;
								if (flag4)
								{
									float_30 = 15f;
								}
								else if (num24 < 20f)
								{
									num26 = 90f;
									float_30 = 15f;
								}
								else
								{
									float_30 = ((num24 < 30f) ? (num24 / 2f) : 15f);
								}
								if (flag4)
								{
									double double_11 = double_23;
									double double_13 = double_25;
									Waypoint waypoint4 = waypoint;
									double double_14 = waypoint4.Longitude;
									Waypoint waypoint5 = waypoint;
									double double_15 = waypoint5.Latitude;
									Geodesic_EdWilliams.CalcPoint_Williams(double_11, double_13, ref double_14, ref double_15, float_30, Math2.UpdateClass(num25 + 180f + num26));
									waypoint5.Latitude = double_15;
									waypoint4.Longitude = double_14;
								}
								else
								{
									double double_16 = double_23;
									double double_17 = double_25;
									Waypoint waypoint6 = waypoint;
									double double_18 = waypoint6.Longitude;
									Waypoint waypoint7 = waypoint;
									double double_19 = waypoint7.Latitude;
									Geodesic_EdWilliams.CalcPoint_Williams(double_16, double_17, ref double_18, ref double_19, float_30, Math2.UpdateClass(num25 + num26));
									waypoint7.Latitude = double_19;
									waypoint6.Longitude = double_18;
								}
							}
							object_ = IncludeTokenizer(waypoint12, aircraft_1, ref gparam_3, waypoint12.Latitude, waypoint12.Longitude, aircraftMissionProfile_0, _RadarBehaviour_0, float_7, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref strike_0.AttackMethod, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military, weapon_0, contact_0);
							SearchTokenizer(waypoint11, aircraft_0, ref gparam_3, waypoint11.Latitude, waypoint11.Longitude, aircraftMissionProfile_0, _RadarBehaviour_0, float_7, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref strike_0.AttackMethod, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, strike_0.Doctrine, Waypoint.SpeedToT.No, float_6, weapon_0, contact_0);
							if (flag5 && strike_0.AttackMethod >= Mission._AttackMethod.MultiAxisSimultaneousToT)
							{
								if (Information.IsNothing(waypoint_15))
								{
									ResetValue(ref strike_0, bool_1, ref turnDirection_0, ref float_17, double_28, double_29, double_26, double_27, ref geoPoint_0, bool_1: false);
								}
								else
								{
									ResetValue(ref strike_0, bool_1, ref turnDirection_0, ref float_17, waypoint_15.Latitude, waypoint_15.Longitude, double_26, double_27, ref geoPoint_0, bool_1: false);
								}
								MapValue(ref strike_0, ref contact_0, ref turnDirection_0, ref float_15, ref waypoint_14, ref waypoint_15, object_, ref float_11, ref float_5, ref float_16, ref float_1, 0f, waypoint12.Latitude, waypoint12.Longitude);
							}
							float num28;
							if (aircraftMissionProfile_0.AttackDistanceEgress <= 0)
							{
								float num27 = Math2.VerifyClass(contact_0.GetLatitude(), contact_0.GetLongitude(), geoPoint_1.Latitude, geoPoint_1.Longitude) - float_1;
								if (num27 <= 50f)
								{
									num28 = num27 / 2f;
									if ((double)num28 < (double)float_4 * 1.5)
									{
										if ((double)float_4 * 1.5 <= (double)(num27 - 5f))
										{
											num28 = (float)((double)float_4 * 1.5);
										}
										else
										{
											num28 = (float)(((double)float_4 * 1.5 + (double)(num27 - 5f)) / 2.0);
											if (num27 < num28 + 5f)
											{
												num28 = num27 - 5f;
											}
											if (float_4 + 5f > num28)
											{
												num28 = float_4 + 5f;
											}
										}
									}
								}
								else
								{
									num28 = 50f;
								}
							}
							else
							{
								num28 = aircraftMissionProfile_0.AttackDistanceEgress;
							}
							if (gparam_4.Count() == 0 && !bool_0)
							{
								num23 = gparam_3.Count();
								for (int m = num23 - 1; m >= 0; m += -1)
								{
									if ((gparam_3[m].Type == Waypoint.WaypointType.InitialPoint && !flag3) || gparam_3[m].Type == Waypoint.WaypointType.WeaponLaunch || gparam_3[m].Type == Waypoint.WaypointType.Assemble || gparam_3[m].Type == Waypoint.WaypointType.HoldStart || gparam_3[m].Type == Waypoint.WaypointType.HoldEnd || gparam_3[m].Type == Waypoint.WaypointType.TakeOff || gparam_3[m].Type == Waypoint.WaypointType.Target || gparam_3[m].Type == Waypoint.WaypointType.WeaponTarget)
									{
										continue;
									}
									_ = gparam_3[m].Latitude;
									_ = gparam_3[m].Longitude;
									if (m < num23 - 1 && (gparam_3[m + 1].Type == Waypoint.WaypointType.InitialPoint || gparam_3[m + 1].Type == Waypoint.WaypointType.WeaponLaunch) && flag2 && m > 0)
									{
										float_16 = Math2.PublishClass(waypoint11.Latitude, waypoint11.Longitude, waypoint12.Latitude, waypoint12.Longitude);
										double latitude3 = waypoint12.Latitude;
										double longitude3 = waypoint12.Longitude;
										float float_31 = num28;
										float float_32 = float_7;
										float float_33 = float_16;
										float float_34 = float_2;
										float float_35 = float_4;
										float float_36 = float_5;
										float float_37 = float_17;
										AircraftMissionProfile aircraftMissionProfile_9 = aircraftMissionProfile_0;
										bool bool_10 = float_4 >= num28;
										Waypoint waypoint_7 = null;
										Waypoint waypoint_8 = null;
										if (OrderValue(ref strike_0, ref flight_0, ref gparam_3, ref aircraft_0, ref contact_0, latitude3, longitude3, float_31, float_32, float_33, float_34, float_35, float_36, ref formation_0, ref float_14, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, float_37, 0f, aircraftMissionProfile_9, bool_0, bool_10, ref waypoint_7, ref waypoint_8, ref bool_1, ref waypoint_14, ref waypoint_15, object_, bool_4: false))
										{
											m--;
										}
									}
									else if (gparam_3[m].Type == Waypoint.WaypointType.StrikeIngress && gparam_3[m].Creator == Waypoint.WaypointCreator.Pathfinder)
									{
										double latitude4 = gparam_3[m].Latitude;
										double longitude4 = gparam_3[m].Longitude;
										Waypoint.Formation formation_13 = Waypoint.Formation.Spread;
										SetTokenizer(null, ref gparam_4, latitude4, longitude4, ref formation_13, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.FlightPlan);
									}
									else if (gparam_3[m].Type == Waypoint.WaypointType.StrikeIngress && gparam_3[m].Creator == Waypoint.WaypointCreator.MissionPlanner)
									{
										FindTokenizer(null, aircraft_1, ref gparam_4, gparam_3[m].Latitude, gparam_3[m].Longitude, aircraftMissionProfile_0, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref gparam_3[m].FlightFormation, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
									}
									else if (gparam_3[m].Type == Waypoint.WaypointType.TurningPoint)
									{
										double latitude5 = gparam_3[m].Latitude;
										double longitude5 = gparam_3[m].Longitude;
										Waypoint.Formation formation_2 = Waypoint.Formation.Spread;
										SetTokenizer(null, ref gparam_4, latitude5, longitude5, ref formation_2, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.FlightPlan);
									}
									else if (flag3 && gparam_3[m].Type == Waypoint.WaypointType.InitialPoint)
									{
										FindTokenizer(null, aircraft_1, ref gparam_4, gparam_3[m].Latitude, gparam_3[m].Longitude, aircraftMissionProfile_0, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref gparam_3[m].FlightFormation, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
									}
								}
								if (aircraft_0.IsHelicopter)
								{
									if (flag4)
									{
										double latitude6 = geoPoint_1.Latitude;
										double longitude6 = geoPoint_1.Longitude;
										GeoPoint obj3 = geoPoint_1;
										double double_20 = obj3.Latitude;
										GeoPoint obj4 = geoPoint_1;
										double double_21 = obj4.Longitude;
										Geodesic_EdWilliams.CalcPoint_Williams(latitude6, longitude6, ref double_20, ref double_21, 10f, Math2.UpdateClass(num40 + 180f));
										obj4.Longitude = double_21;
										obj3.Latitude = double_20;
										Aircraft object_2 = aircraft_0;
										double latitude7 = geoPoint_1.Latitude;
										double longitude7 = geoPoint_1.Longitude;
										AircraftMissionProfile object_3 = aircraftMissionProfile_0;
										Waypoint.Formation formation_3 = Waypoint.Formation.Spread;
										FillTokenizer(null, object_2, ref gparam_4, latitude7, longitude7, object_3, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_3, Waypoint.TurnRateCategory.DoubleStandardRateTurn, null, Waypoint.SpeedToT.Yes_UpOrDown_Military);
									}
								}
								else
								{
									CheckTokenizer(null, aircraft_1, ref gparam_4, geoPoint_1.Latitude, geoPoint_1.Longitude, aircraftMissionProfile_0, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
								}
							}
							else
							{
								gparam_4 = gparam_4;
								num23 = gparam_4.Count();
								formation_0 = Waypoint.Formation.Spread;
								for (int n = num23 - 1; n >= 0; n += -1)
								{
									if (n == num23 - 1)
									{
										if (aircraft_0.IsHelicopter)
										{
											double latitude8 = geoPoint_1.Latitude;
											double longitude8 = geoPoint_1.Longitude;
											GeoPoint obj5 = geoPoint_1;
											double double_22 = obj5.Latitude;
											GeoPoint obj6 = geoPoint_1;
											double double_24 = obj6.Longitude;
											Geodesic_EdWilliams.CalcPoint_Williams(latitude8, longitude8, ref double_22, ref double_24, 10f, Math2.UpdateClass(num40 + 180f));
											obj6.Longitude = double_24;
											obj5.Latitude = double_22;
											Waypoint object_4 = gparam_4[n];
											Aircraft object_5 = aircraft_0;
											double latitude9 = geoPoint_1.Latitude;
											double longitude9 = geoPoint_1.Longitude;
											AircraftMissionProfile object_6 = aircraftMissionProfile_0;
											Waypoint.Formation formation_4 = Waypoint.Formation.Spread;
											FillTokenizer(object_4, object_5, ref gparam_4, latitude9, longitude9, object_6, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_4, Waypoint.TurnRateCategory.DoubleStandardRateTurn, null, Waypoint.SpeedToT.Yes_UpOrDown_Military);
										}
										else
										{
											CheckTokenizer(gparam_4[n], aircraft_1, ref gparam_4, geoPoint_1.Latitude, geoPoint_1.Longitude, aircraftMissionProfile_0, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
										}
									}
									else if (gparam_4[n].Type == Waypoint.WaypointType.PathfindingPoint)
									{
										Waypoint waypoint_9 = gparam_4[n];
										Waypoint.Formation formation_5 = Waypoint.Formation.Spread;
										SetTokenizer(waypoint_9, ref gparam_3, 0.0, 0.0, ref formation_5, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.FlightPlan);
									}
								}
							}
							if (gparam_4.Count() > 0)
							{
								Waypoint[] array = gparam_4;
								for (int num29 = 0; num29 < array.Length; num29 = checked(num29 + 1))
								{
									Waypoint waypoint_10 = array[num29];
									Doctrine doctrine_4 = null;
									ArrayExtensions.Add(ref gparam_3, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_10, bool_0: true, bool_1: true, ref doctrine_4));
								}
								ArrayExtensions.Clear(ref gparam_4);
							}
							InterruptTokenizer(null, aircraft_1, ref gparam_3, geoPoint_2.Latitude, geoPoint_2.Longitude, aircraftMissionProfile_0, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_0, Waypoint.TurnRateCategory.StandardRateTurn);
							if (bool_0 && num28 > 0f)
							{
								num34 = 0f;
								num23 = gparam_3.Count();
								int num30 = num23 - 2;
								for (int num31 = 0; num31 <= num30; num31++)
								{
									if (gparam_3[num31].Type != Waypoint.WaypointType.Target && gparam_3[num31].Type != Waypoint.WaypointType.WeaponTarget)
									{
										if (num34 > 0f)
										{
											float num32 = Math2.VerifyClass(gparam_3[num31].Latitude, gparam_3[num31].Longitude, gparam_3[num31 + 1].Latitude, gparam_3[num31 + 1].Longitude);
											num34 += num32;
											if (num34 > num28 + float_1)
											{
												float num33 = num34 - num32;
												float float_38 = ((float_7 < 6f) ? (num28 - num33) : (num28 + float_1 - num33));
												float float_39 = Math2.PublishClass(gparam_3[num31].Latitude, gparam_3[num31].Longitude, gparam_3[num31 + 1].Latitude, gparam_3[num31 + 1].Longitude);
												Geodesic_EdWilliams.CalcPoint_Williams(gparam_3[num31].Longitude, gparam_3[num31].Latitude, ref double_27, ref double_26, float_38, Math2.UpdateClass(float_39));
												Waypoint waypoint8 = new Waypoint(double_27, double_26, 0f, Waypoint.WaypointType.StrikeEgress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
												ActiveUnit_Navigator.AddWaypoint(ref gparam_3, num31 + 1, waypoint8);
												FindTokenizer(waypoint8, aircraft_1, ref gparam_3, double_26, double_27, aircraftMissionProfile_0, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
												break;
											}
										}
										continue;
									}
									float num35 = Math2.VerifyClass(gparam_3[num31].Latitude, gparam_3[num31].Longitude, gparam_3[num31 + 1].Latitude, gparam_3[num31 + 1].Longitude);
									if (num35 <= num28 + float_1)
									{
										num34 = num35;
										continue;
									}
									float float_40 = Math2.PublishClass(gparam_3[num31].Latitude, gparam_3[num31].Longitude, gparam_3[num31 + 1].Latitude, gparam_3[num31 + 1].Longitude);
									if (float_7 < 6f)
									{
										Geodesic_EdWilliams.CalcPoint_Williams(gparam_3[num31].Longitude, gparam_3[num31].Latitude, ref double_27, ref double_26, num28, Math2.UpdateClass(float_40));
									}
									else
									{
										Geodesic_EdWilliams.CalcPoint_Williams(gparam_3[num31].Longitude, gparam_3[num31].Latitude, ref double_27, ref double_26, num28 + float_1, Math2.UpdateClass(float_40));
									}
									Waypoint waypoint9 = new Waypoint(double_27, double_26, 0f, Waypoint.WaypointType.StrikeEgress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
									ActiveUnit_Navigator.AddWaypoint(ref gparam_3, num31 + 1, waypoint9);
									FindTokenizer(waypoint9, aircraft_1, ref gparam_3, double_26, double_27, aircraftMissionProfile_0, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
									if (!(flag2 && flag5) || !(flight_0.DesiredAircraftQty != 1) || !(float_4 > 0f))
									{
										break;
									}
									float float_41 = Math2.PublishClass(gparam_3[num31].Latitude, gparam_3[num31].Longitude, gparam_3[num31 + 1].Latitude, gparam_3[num31 + 1].Longitude);
									Waypoint waypoint_11 = new Waypoint(double_27, double_26, 0f, Waypoint.WaypointType.StrikeEgress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
									formation_0 = Waypoint.Formation.Split;
									Waypoint waypoint_13;
									if (num28 > 0f && num28 <= float_4)
									{
										ActiveUnit_Navigator.AddWaypoint(ref gparam_3, num31 + 1, waypoint_11);
										waypoint_13 = gparam_3[num31 + 2];
									}
									else
									{
										waypoint_13 = new Waypoint(double_27, double_26, 0f, Waypoint.WaypointType.StrikeEgress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
										ActiveUnit_Navigator.AddWaypoint(ref gparam_3, num31 + 1, waypoint_11);
										ActiveUnit_Navigator.AddWaypoint(ref gparam_3, num31 + 2, waypoint_13);
									}
									bool num36 = OrderValue(ref strike_0, ref flight_0, ref gparam_3, ref aircraft_0, ref contact_0, waypoint12.Latitude, waypoint12.Longitude, num28, float_11, float_41, float_2, float_4, float_5, ref formation_0, ref float_14, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, float_17, 0f, aircraftMissionProfile_0, bool_0, float_4 >= num28, ref waypoint_11, ref waypoint_13, ref bool_1, ref waypoint_14, ref waypoint_15, object_, bool_4: false);
									formation_0 = Waypoint.Formation.Spread;
									if (num36)
									{
										if (num28 > 0f && num28 <= float_4)
										{
											num31++;
										}
										else
										{
											num31 += 2;
										}
									}
									break;
								}
							}
							if (Information.IsNothing(nullable_0))
							{
								Aircraft_Navigator navigator = aircraft_1.Navigator;
								bool bool_5 = false;
								float value2 = navigator.OrderProxy(ref bool_5);
								nullable_0 = aircraft_1.AI.WriteClient(contact_0.GetLatitude(), contact_0.GetLongitude(), aircraft_1.Loadout.CombatRadius, value2);
							}
							bool value3 = true;
							Waypoint[] array2 = gparam_3;
							Waypoint[] array3 = array2;
							foreach (Waypoint waypoint10 in array3)
							{
								if (waypoint10.Type != Waypoint.WaypointType.TurningPoint && waypoint10.Type != Waypoint.WaypointType.TakeOff)
								{
									float_12 = (Information.IsNothing(waypoint10.DesiredAltitude) ? 0f : waypoint10.DesiredAltitude.Value);
									float_13 = (Information.IsNothing(waypoint10.DesiredAltitude_TerrainFollowing) ? 0f : waypoint10.DesiredAltitude_TerrainFollowing.Value);
									bool_7 = waypoint10.TerrainFollowing;
									unitThrottlePreset_ = waypoint10.ThrottlePreset;
									if (!Information.IsNothing(waypoint10.DesiredSpeed))
									{
										float_14 = waypoint10.DesiredSpeed.Value;
									}
									formation_0 = waypoint10.FlightFormation;
									if (waypoint10.Type == Waypoint.WaypointType.StrikeIngress || waypoint10.Type == Waypoint.WaypointType.StrikeEgress)
									{
										waypoint10.TurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
									}
								}
								else if (waypoint10.Type == Waypoint.WaypointType.TurningPoint)
								{
									FillTokenizer(waypoint10, aircraft_1, ref gparam_3, waypoint10.Latitude, waypoint10.Longitude, aircraftMissionProfile_0, ref float_12, ref float_13, ref bool_7, ref unitThrottlePreset_, ref float_14, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, value3, Waypoint.SpeedToT.Yes_UpOrDown_Military);
								}
								if (waypoint10.Type == Waypoint.WaypointType.Target || waypoint10.Type == Waypoint.WaypointType.WeaponTarget)
								{
									value3 = false;
								}
							}
							CloneTokenizer(ref scenario_0, ref mission_0, gparam_3, bool_2, ref bool_6);
							if (!ConnectTokenizer(scenario_0, strike_0, aircraft_1, flight_0, ref gparam_3, ref float_0, ref float_9, bool_0: true, bool_1: false, bool_2: true, bool_3: true, bool_4: true, bool_5: true, bool_6: false, 0f, 0f, turnDirection_0, false, bool_0, bool_1, nullable_1, nullable_2, bool_4))
							{
								bool? flag6 = nullable_0;
								flag6 = flag6;
								if (!flag6.GetValueOrDefault())
								{
									ArrayExtensions.Clear(ref gparam_3);
									flag6 = nullable_0;
									if (((!flag6) ?? flag6).GetValueOrDefault())
									{
										if (!aircraft_1.BoomRefuelling && !aircraft_1.ProbeRefuelling)
										{
											string_0 = "飞行计划没有足够的燃料。没有生成飞行计划。所需的任务燃料：" + Conversions.ToString((int)Math.Round(float_0)) + "千克。飞机上可用的任务燃料（减去储备燃料）：" + Conversions.ToString((int)Math.Round(float_9)) + "千克。";
										}
										else
										{
											string_0 = "没有发现空中加油机，也没有足够的燃料用于飞行计划。目标无法到达，也没有生成飞行计划。所需的任务燃料：" + Conversions.ToString((int)Math.Round(float_0)) + "千克。飞机上可用的任务燃料（减去储备燃料）：" + Conversions.ToString((int)Math.Round(float_9)) + "千克。";
										}
									}
									else
									{
										string_0 = "空中加油机发现但与它们的距离太长。目标遥不可及，并且没有生成飞行计划。所需的任务燃料：" + Conversions.ToString((int)Math.Round(float_0)) + "千克。飞机上可用的任务燃料（减去储备燃料）：" + Conversions.ToString((int)Math.Round(float_9)) + "千克。";
									}
									flag = false;
									break;
								}
							}
							if (ResolveValue(ref scenario_0, ref gparam_3, bool_3))
							{
								ConnectTokenizer(scenario_0, strike_0, aircraft_0, flight_0, ref gparam_3, ref float_0, ref float_9, bool_0: false, !bool_0, bool_2: false, bool_3: false, bool_4: true, bool_5: false, bool_6: true, float_4, float_5, turnDirection_0, false, bool_0, bool_1, null, null, bool_4);
								if (k == 1)
								{
									flight_0.FlightPlan_Pathfinder_Ingress_1 = gparam_3;
									flight_0.FlightPlan_Pathfinder_Egress_1 = gparam_4;
								}
								else
								{
									if (k != 2)
									{
										flag = false;
										break;
									}
									flight_0.FlightPlan_Pathfinder_Ingress_2 = gparam_3;
									flight_0.FlightPlan_Pathfinder_Egress_2 = gparam_4;
								}
								if (!flag)
								{
									break;
								}
								continue;
							}
							ArrayExtensions.Clear(ref gparam_3);
							flight_0.FlightCannotLaunch = true;
							string_0 = "起飞必须在过去。没有生成飞行计划。";
							flag = false;
							break;
						}
						string_0 = "找不到flightplan的IP航点。";
						flag = false;
						break;
					}
					flag = false;
					break;
				}
				flag = false;
				break;
			}
			if (bool_6)
			{
				if (Information.IsNothing(flight_0.NotificationList))
				{
					flight_0.NotificationList = new List<string>();
				}
				flight_0.NotificationList.Add(aircraft_0.UnitClass + "与挂载" + aircraft_0.Loadout.Name + "在任务上" + strike_0.Name + "有一个允许空对空加油（AAR）的条令设置。但是，在给定武器挂载和飞行剖面的情况下，到目标的距离短于飞机的最大作战半径。因此，此编队计划中的所有航路点都禁用AAR。");
			}
			return flag;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200655", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal static bool ResolveValue(ref Scenario scenario_0, ref Waypoint[] waypoint_0, bool bool_0)
	{
		if (!bool_0 && waypoint_0.Count() > 0)
		{
			Waypoint waypoint = waypoint_0[0];
			if (!Information.IsNothing(waypoint.Time_Zulu) && (waypoint.Time_Zulu.Value - scenario_0.Time).TotalSeconds < -180.0)
			{
				return false;
			}
		}
		return true;
	}

	private static bool PostValue(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Aircraft aircraft_0, ref bool? nullable_0, ref string string_0, ref Mission._RadarBehaviour _RadarBehaviour_0, bool bool_0, ref float float_0, ref ActiveUnit activeUnit_0, ref Aircraft aircraft_1, ref GeoPoint geoPoint_0, ref GeoPoint geoPoint_1, ref GeoPoint geoPoint_2, ref AircraftMissionProfile aircraftMissionProfile_0, ref Waypoint.Formation formation_0, ref float float_1, ref Misc.TurnDirection turnDirection_0, ref float float_2, ref float float_3, bool bool_1, double double_0, double double_1, double double_2, double double_3, Waypoint.WaypointType waypointType_0, Waypoint.TurnRateCategory turnRateCategory_0, bool bool_2, DateTime? nullable_1, DateTime? nullable_2, bool bool_3)
	{
		try
		{
			if (Information.IsNothing(flight_0.GetReferenceUnit(scenario_0)))
			{
				string_0 = "找不到飞行计划的参考单元。";
				return false;
			}
			flight_0.HasCriticalError = false;
			bool flag = true;
			bool bool_4 = false;
			Waypoint[] waypoint_ = flight_0.FlightPlan_Pathfinder_Ingress_1;
			Waypoint[] gparam_ = flight_0.FlightPlan_Pathfinder_Egress_1;
			if (Information.IsNothing(waypoint_))
			{
				flag = false;
				return false;
			}
			if (waypoint_.Count() == 0)
			{
				flag = false;
				return false;
			}
			int num = waypoint_.Count();
			Waypoint waypoint = waypoint_[num - 1];
			float float_7 = 0f;
			float float_8 = 0f;
			bool bool_5 = false;
			ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_ = ActiveUnit_Kinematics.UnitThrottlePreset.FullStop;
			float float_9 = 0f;
			ConcatTokenizer(null, aircraft_1, ref waypoint_, geoPoint_0.Latitude, geoPoint_0.Longitude, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_0, Waypoint.TurnRateCategory.StandardRateTurn);
			float num5 = (bool_0 ? Math2.PublishClass(aircraft_0.GetLatitude(), aircraft_0.GetLongitude(), double_0, double_1) : Math2.PublishClass(geoPoint_0.Latitude, geoPoint_0.Longitude, double_0, double_1));
			int num6 = 0;
			float float_10;
			if (aircraftMissionProfile_0.FormUpTime < 2)
			{
				float_10 = 10f;
			}
			else
			{
				float num7 = aircraft_0.Kinematics.GetMaximumSpeed(aircraftMissionProfile_0.FormUpAltitude * 0.3048f, ActiveUnit.Throttle.Loiter, bool_0: false);
				num6 = 2;
				float_10 = num7 * 2f / 60f;
			}
			int num8 = aircraftMissionProfile_0.FormUpTime - num6;
			double double_12 = 0.0;
			double double_13 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(geoPoint_0.Longitude, geoPoint_0.Latitude, ref double_12, ref double_13, float_10, Math2.UpdateClass(num5 + float_1));
			Waypoint waypoint2 = null;
			Waypoint waypoint3;
			if (aircraft_0.IsHelicopter)
			{
				waypoint3 = new Waypoint(double_12, double_13, 0f, Waypoint.WaypointType.Assemble, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
				ActiveUnit_Navigator.AddWaypoint(ref waypoint_, 1, waypoint3);
				WriteTokenizer(waypoint3, aircraft_1, ref waypoint_, double_13, double_12, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_0, Waypoint.TurnRateCategory.StandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
				waypoint3 = waypoint_[1];
			}
			else if (num8 <= 0)
			{
				waypoint3 = new Waypoint(double_12, double_13, 0f, Waypoint.WaypointType.Assemble, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
				ActiveUnit_Navigator.AddWaypoint(ref waypoint_, 1, waypoint3);
				WriteTokenizer(waypoint3, aircraft_1, ref waypoint_, double_13, double_12, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_0, Waypoint.TurnRateCategory.StandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
				waypoint3 = waypoint_[1];
			}
			else
			{
				waypoint3 = new Waypoint(double_12, double_13, 0f, Waypoint.WaypointType.HoldStart, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
				ActiveUnit_Navigator.AddWaypoint(ref waypoint_, 1, waypoint3);
				NewTokenizer(waypoint3, aircraft_1, ref waypoint_, double_13, double_12, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
				waypoint3 = waypoint_[1];
				waypoint2 = new Waypoint(double_12, double_13, 0f, Waypoint.WaypointType.HoldEnd, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
				ActiveUnit_Navigator.AddWaypoint(ref waypoint_, 2, waypoint2);
				Waypoint waypoint_2 = waypoint2;
				Aircraft aircraft_2 = aircraft_0;
				double double_14 = double_13;
				double double_15 = double_12;
				AircraftMissionProfile aircraftMissionProfile_ = aircraftMissionProfile_0;
				bool bool_6 = true;
				waypoint2 = PushTokenizer(waypoint_2, aircraft_2, ref waypoint_, double_14, double_15, aircraftMissionProfile_, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, ref mission_0, ref bool_6, num8);
			}
			if (bool_0)
			{
				Math2.PublishClass(aircraft_0.GetLatitude(), aircraft_0.GetLongitude(), double_0, double_1);
				Math2.PublishClass(double_0, double_1, aircraft_0.GetLatitude(), aircraft_0.GetLongitude());
			}
			else
			{
				Math2.PublishClass(double_13, double_12, double_0, double_1);
				Math2.PublishClass(double_0, double_1, double_13, double_12);
			}
			if (bool_0)
			{
				Waypoint waypoint4 = new Waypoint(aircraft_1.GetLongitude(), aircraft_1.GetLatitude(), 0f, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
				if (!aircraft_0.IsHelicopter && num8 > 0)
				{
					ActiveUnit_Navigator.AddWaypoint(ref waypoint_, 3, waypoint4);
				}
				else
				{
					ActiveUnit_Navigator.AddWaypoint(ref waypoint_, 2, waypoint4);
				}
				FillTokenizer(waypoint4, aircraft_1, ref waypoint_, aircraft_1.GetLatitude(), aircraft_1.GetLongitude(), aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, null, Waypoint.SpeedToT.Yes_DownOnly);
			}
			num = waypoint_.Count();
			int num9 = -1;
			Waypoint.Formation formation_;
			while (true)
			{
				num9++;
				if (num9 > waypoint_.Count() - 1)
				{
					break;
				}
				if (waypoint_[num9] != waypoint && waypoint_[num9] != waypoint3 && waypoint_[num9].Type != Waypoint.WaypointType.TakeOff && waypoint_[num9].Type == Waypoint.WaypointType.PathfindingPoint)
				{
					Waypoint waypoint_3 = waypoint_[num9];
					formation_ = Waypoint.Formation.Spread;
					SetTokenizer(waypoint_3, ref waypoint_, 0.0, 0.0, ref formation_, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.FlightPlan);
				}
			}
			Aircraft aircraft_3 = aircraft_0;
			AircraftMissionProfile aircraftMissionProfile_2 = aircraftMissionProfile_0;
			Mission._RadarBehaviour radarBehaviour_ = _RadarBehaviour_0;
			formation_ = Waypoint.Formation.Spread;
			CalculateTokenizer(waypoint, aircraft_3, ref waypoint_, 0.0, 0.0, aircraftMissionProfile_2, radarBehaviour_, waypointType_0, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_, turnRateCategory_0, Waypoint.SpeedToT.Yes_DownOnly, flight_0);
			if (!aircraft_0.IsHelicopter && !Information.IsNothing(waypoint2))
			{
				float num10 = Math2.VerifyClass(double_13, double_12, waypoint_[3].Latitude, waypoint_[3].Longitude);
				float num11 = Math2.PublishClass(double_13, double_12, waypoint_[3].Latitude, waypoint_[3].Longitude);
				float num12 = 0f;
				float float_11;
				if (num10 < 20f)
				{
					num12 = 90f;
					float_11 = 15f;
				}
				else
				{
					float_11 = ((num10 < 30f) ? (num10 / 2f) : 15f);
				}
				double double_16 = double_12;
				double double_17 = double_13;
				Waypoint waypoint5 = waypoint2;
				double double_4 = waypoint5.Longitude;
				Waypoint waypoint6 = waypoint2;
				double double_5 = waypoint6.Latitude;
				Geodesic_EdWilliams.CalcPoint_Williams(double_16, double_17, ref double_4, ref double_5, float_11, Math2.UpdateClass(num11 + num12));
				waypoint6.Latitude = double_5;
				waypoint5.Longitude = double_4;
			}
			float num2 = Math2.VerifyClass(waypoint.Latitude, waypoint.Longitude, double_2, double_3);
			float num3 = 50f;
			if (num2 <= num3)
			{
				if (num2 < num3)
				{
					float float_12 = Math2.PublishClass(waypoint.Latitude, waypoint.Longitude, double_2, double_3);
					float float_4 = num3 - num2;
					Geodesic_EdWilliams.CalcPoint_Williams(double_3, double_2, ref double_3, ref double_2, float_4, float_12);
				}
			}
			else
			{
				float num4 = Math2.PublishClass(waypoint.Latitude, waypoint.Longitude, double_2, double_3);
				float float_5 = num2 - num3;
				Geodesic_EdWilliams.CalcPoint_Williams(double_3, double_2, ref double_3, ref double_2, float_5, Math2.UpdateClass(num4 + 180f));
			}
			Aircraft aircraft_4 = aircraft_0;
			double double_6 = double_2;
			double double_7 = double_3;
			AircraftMissionProfile aircraftMissionProfile_3 = aircraftMissionProfile_0;
			Mission._RadarBehaviour radarBehaviour_2 = _RadarBehaviour_0;
			formation_ = Waypoint.Formation.Spread;
			PopTokenizer(null, aircraft_4, ref waypoint_, double_6, double_7, aircraftMissionProfile_3, radarBehaviour_2, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn);
			if (gparam_.Count() == 0 && !bool_0)
			{
				num = waypoint_.Count();
				double double_8 = 0.0;
				double double_9 = 0.0;
				for (int i = num - 1; i >= 0; i += -1)
				{
					if (waypoint_[i].Type == Waypoint.WaypointType.StationEnd || waypoint_[i].Type == Waypoint.WaypointType.Assemble || waypoint_[i].Type == Waypoint.WaypointType.HoldStart || waypoint_[i].Type == Waypoint.WaypointType.HoldEnd || waypoint_[i].Type == Waypoint.WaypointType.TakeOff)
					{
						continue;
					}
					_ = waypoint_[i].Latitude;
					_ = waypoint_[i].Longitude;
					if (waypoint_[i].SearchReponse() && i > 0)
					{
						if (Math2.VerifyClass(waypoint_[i].Latitude, waypoint_[i].Longitude, waypoint_[i - 1].Latitude, waypoint_[i - 1].Longitude) <= 20f)
						{
							double latitude = waypoint_[i].Latitude;
							double longitude = waypoint_[i].Longitude;
							formation_ = Waypoint.Formation.Spread;
							SetTokenizer(null, ref gparam_, latitude, longitude, ref formation_, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.FlightPlan);
						}
						else
						{
							float float_6 = Math2.PublishClass(waypoint_[i].Latitude, waypoint_[i].Longitude, waypoint_[i - 1].Latitude, waypoint_[i - 1].Longitude);
							Geodesic_EdWilliams.CalcPoint_Williams(waypoint_[i].Longitude, waypoint_[i].Latitude, ref double_8, ref double_9, 15f, float_6);
							double double_10 = double_9;
							double double_11 = double_8;
							formation_ = Waypoint.Formation.Spread;
							SetTokenizer(null, ref gparam_, double_10, double_11, ref formation_, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.FlightPlan);
						}
					}
					else
					{
						double latitude2 = waypoint_[i].Latitude;
						double longitude2 = waypoint_[i].Longitude;
						formation_ = Waypoint.Formation.Spread;
						SetTokenizer(null, ref gparam_, latitude2, longitude2, ref formation_, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.FlightPlan);
					}
				}
				if (!aircraft_0.IsHelicopter)
				{
					CheckTokenizer(null, aircraft_1, ref gparam_, geoPoint_1.Latitude, geoPoint_1.Longitude, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_DownOnly);
				}
			}
			else
			{
				gparam_ = gparam_;
				num = gparam_.Count();
				formation_0 = Waypoint.Formation.Spread;
				for (int j = num - 1; j >= 0; j += -1)
				{
					if (j == num - 1 && !aircraft_0.IsHelicopter)
					{
						CheckTokenizer(gparam_[j], aircraft_1, ref gparam_, geoPoint_1.Latitude, geoPoint_1.Longitude, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_DownOnly);
					}
					else if (gparam_[j].Type == Waypoint.WaypointType.PathfindingPoint)
					{
						Waypoint waypoint_4 = gparam_[j];
						formation_ = Waypoint.Formation.Spread;
						SetTokenizer(waypoint_4, ref waypoint_, 0.0, 0.0, ref formation_, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.FlightPlan);
					}
				}
			}
			if (gparam_.Count() > 0)
			{
				Waypoint[] array = gparam_;
				for (int k = 0; k < array.Length; k = checked(k + 1))
				{
					Waypoint waypoint_5 = array[k];
					Doctrine doctrine_ = null;
					ArrayExtensions.Add(ref waypoint_, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_5, bool_0: true, bool_1: true, ref doctrine_));
				}
				ArrayExtensions.Clear(ref gparam_);
			}
			InterruptTokenizer(null, aircraft_1, ref waypoint_, geoPoint_2.Latitude, geoPoint_2.Longitude, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_0, Waypoint.TurnRateCategory.StandardRateTurn);
			if (Information.IsNothing(nullable_0))
			{
				Aircraft_Navigator navigator = aircraft_1.Navigator;
				bool bool_7 = false;
				float value = navigator.OrderProxy(ref bool_7);
				nullable_0 = aircraft_1.AI.WriteClient(double_0, double_1, aircraft_1.Loadout.CombatRadius, value);
			}
			Waypoint[] array2 = waypoint_;
			Waypoint[] array3 = array2;
			foreach (Waypoint waypoint7 in array3)
			{
				if (waypoint7.Type != Waypoint.WaypointType.TurningPoint && waypoint7.Type != Waypoint.WaypointType.TakeOff)
				{
					float_7 = (Information.IsNothing(waypoint7.DesiredAltitude) ? 0f : waypoint7.DesiredAltitude.Value);
					float_8 = (Information.IsNothing(waypoint7.DesiredAltitude_TerrainFollowing) ? 0f : waypoint7.DesiredAltitude_TerrainFollowing.Value);
					bool_5 = waypoint7.TerrainFollowing;
					unitThrottlePreset_ = waypoint7.ThrottlePreset;
					if (!Information.IsNothing(waypoint7.DesiredSpeed))
					{
						float_9 = waypoint7.DesiredSpeed.Value;
					}
					formation_0 = waypoint7.FlightFormation;
					if (waypoint7.Type == Waypoint.WaypointType.TurningPoint)
					{
						waypoint7.TurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
					}
				}
				else if (waypoint7.Type == Waypoint.WaypointType.TurningPoint)
				{
					FillTokenizer(waypoint7, aircraft_1, ref waypoint_, waypoint7.Latitude, waypoint7.Longitude, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, null, Waypoint.SpeedToT.Yes_DownOnly);
				}
			}
			CloneTokenizer(ref scenario_0, ref mission_0, waypoint_, bool_1, ref bool_4);
			if (!ConnectTokenizer(scenario_0, mission_0, aircraft_1, flight_0, ref waypoint_, ref float_0, ref float_3, bool_0: true, bool_1: false, bool_2: true, bool_3: true, bool_4: true, bool_5: true, bool_6: false, 0f, 0f, turnDirection_0, false, bool_0, bool_8: false, nullable_1, nullable_2, bool_3))
			{
				bool? flag2 = nullable_0;
				flag2 = flag2;
				if (!flag2.GetValueOrDefault())
				{
					ArrayExtensions.Clear(ref waypoint_);
					flag2 = nullable_0;
					if (((!flag2) ?? flag2).GetValueOrDefault())
					{
						if (!aircraft_1.BoomRefuelling && !aircraft_1.ProbeRefuelling)
						{
							string_0 = "飞行计划没有足够的燃料。没有生成飞行计划。所需的任务燃料：" + Conversions.ToString((int)Math.Round(float_0)) + "千克。飞机上可用的任务燃料（减去储备燃料）：" + Conversions.ToString((int)Math.Round(float_3)) + "千克。";
						}
						else
						{
							string_0 = "没有发现空中加油机，也没有足够的燃料用于飞行计划。目标无法到达，也没有生成飞行计划。所需的任务燃料：" + Conversions.ToString((int)Math.Round(float_0)) + "千克。飞机上可用的任务燃料（减去储备燃料）：" + Conversions.ToString((int)Math.Round(float_3)) + "千克。";
						}
					}
					else
					{
						string_0 = "空中加油机发现但与它们的距离太长。目标遥不可及，并且没有生成飞行计划。所需的任务燃料：" + Conversions.ToString((int)Math.Round(float_0)) + "千克。飞机上可用的任务燃料（减去储备燃料）：" + Conversions.ToString((int)Math.Round(float_3)) + "千克。";
					}
					flag = false;
					return false;
				}
			}
			if (ResolveValue(ref scenario_0, ref waypoint_, bool_2))
			{
				ConnectTokenizer(scenario_0, mission_0, aircraft_0, flight_0, ref waypoint_, ref float_0, ref float_3, bool_0: false, !bool_0, bool_2: false, bool_3: false, bool_4: true, bool_5: false, bool_6: true, 0f, 0f, turnDirection_0, false, bool_0, bool_8: false, null, null, bool_3);
			}
			else
			{
				ArrayExtensions.Clear(ref waypoint_);
				flight_0.FlightCannotLaunch = true;
				string_0 = "起飞时间将在过去。没有生成飞行计划。";
				flag = false;
			}
			flight_0.FlightPlan_Pathfinder_Ingress_1 = waypoint_;
			flight_0.FlightPlan_Pathfinder_Egress_1 = gparam_;
			if (flag)
			{
				if (bool_4)
				{
					if (Information.IsNothing(flight_0.NotificationList))
					{
						flight_0.NotificationList = new List<string>();
					}
					flight_0.NotificationList.Add(aircraft_0.UnitClass + "与挂载" + aircraft_0.Loadout.Name + "在任务上" + mission_0.Name + "有一个允许空对空加油（AAR）的条令设置。但是，在给定武器挂载和飞行剖面的情况下，到目标的距离短于飞机的最大作战半径。因此，此编队计划中的所有航路点都禁用AAR。");
				}
				return flag;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private unsafe static void RunValue(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Aircraft aircraft_0, ref Strike strike_0, ref Waypoint.Formation formation_0, Module_Unit.Unit unit_0, ref GeoPoint geoPoint_0, ref GeoPoint geoPoint_1, ref GeoPoint geoPoint_2, float float_0, float float_1, float float_2, ref Misc.TurnDirection turnDirection_0, ref float float_3, ref float float_4, ref AircraftMissionProfile aircraftMissionProfile_0, ref bool bool_0, ref float float_5, ref float float_6, ref float float_7, ref bool bool_1, float float_8, ref Weapon weapon_0, float float_9, ref float float_10, ref float float_11, Mission._RadarBehaviour _RadarBehaviour_0, ref bool bool_2, bool bool_3, ref string string_0, bool? nullable_0, bool bool_4, ref float float_12, bool bool_5, ref bool bool_6, DateTime? nullable_1, DateTime? nullable_2, bool bool_7)
	{
		try
		{
			flight_0.HasCriticalError = false;
			bool flag = false;
			float float_13 = 0f;
			float float_14 = 0f;
			bool bool_19 = false;
			ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_ = ActiveUnit_Kinematics.UnitThrottlePreset.FullStop;
			float float_15 = 0f;
			double double_ = 0.0;
			double double_12 = 0.0;
			Waypoint waypoint = null;
			double double_18 = 0.0;
			double double_19 = 0.0;
			float float_16 = 0f;
			Waypoint waypoint_ = null;
			Waypoint waypoint_4 = null;
			Waypoint object_ = null;
			double double_20 = 0.0;
			double double_21 = 0.0;
			double double_22 = 0.0;
			double double_23 = 0.0;
			float float_17 = 0f;
			while (true)
			{
				if (bool_0)
				{
					return;
				}
				flight_0.ClearFlightPlan();
				float num = (bool_1 ? Math2.PublishClass(aircraft_0.GetLatitude(), aircraft_0.GetLongitude(), unit_0.GetLatitude(), unit_0.GetLongitude()) : Math2.PublishClass(geoPoint_0.Latitude, geoPoint_0.Longitude, unit_0.GetLatitude(), unit_0.GetLongitude()));
				int num10 = 0;
				float float_18;
				if (aircraft_0.IsHelicopter)
				{
					if (aircraftMissionProfile_0.FormUpTime < 2)
					{
						if (float_7 < 20f)
						{
							flag = true;
							float_18 = 20f;
						}
						else if (float_0 < float_7 + 20f)
						{
							flag = true;
							float_18 = 10f;
						}
						else
						{
							float_18 = 10f;
						}
					}
					else
					{
						if (float_7 < 10f)
						{
							flag = true;
						}
						float num11 = aircraft_0.Kinematics.GetMaximumSpeed(aircraftMissionProfile_0.FormUpAltitude * 0.3048f, ActiveUnit.Throttle.Loiter, bool_0: false);
						num10 = 2;
						float_18 = num11 * 2f / 60f;
					}
				}
				else if (aircraftMissionProfile_0.FormUpTime < 2)
				{
					if (float_7 < 30f)
					{
						flag = true;
					}
					float_18 = 10f;
				}
				else
				{
					if (float_7 < 30f)
					{
						flag = true;
					}
					float num12 = aircraft_0.Kinematics.GetMaximumSpeed(aircraftMissionProfile_0.FormUpAltitude * 0.3048f, ActiveUnit.Throttle.Loiter, bool_0: false);
					num10 = 2;
					float_18 = num12 * 2f / 60f;
				}
				int num13 = aircraftMissionProfile_0.FormUpTime - num10;
				Aircraft object_2 = aircraft_0;
				Mission.Flight flight;
				Waypoint[] waypoint_5 = (flight = flight_0).FlightPlan;
				ConcatTokenizer(null, object_2, ref waypoint_5, geoPoint_0.Latitude, geoPoint_0.Longitude, aircraftMissionProfile_0, ref float_13, ref float_14, ref bool_19, ref unitThrottlePreset_, ref float_15, ref formation_0, Waypoint.TurnRateCategory.StandardRateTurn);
				flight.FlightPlan = waypoint_5;
				if (aircraft_0.IsHelicopter)
				{
					if (flag)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(geoPoint_0.Longitude, geoPoint_0.Latitude, ref double_, ref double_12, float_18, Math2.UpdateClass(num + float_6));
					}
					else
					{
						Geodesic_EdWilliams.CalcPoint_Williams(geoPoint_0.Longitude, geoPoint_0.Latitude, ref double_, ref double_12, float_18, Math2.UpdateClass(num + 180f + float_6));
					}
					Aircraft aircraft_ = aircraft_0;
					waypoint_5 = (flight = flight_0).FlightPlan;
					WriteTokenizer(null, aircraft_, ref waypoint_5, double_12, double_, aircraftMissionProfile_0, ref float_13, ref float_14, ref bool_19, ref unitThrottlePreset_, ref float_15, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
					flight.FlightPlan = waypoint_5;
				}
				else
				{
					if (flag)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(geoPoint_0.Longitude, geoPoint_0.Latitude, ref double_, ref double_12, float_18, Math2.UpdateClass(num + 180f + float_6));
					}
					else
					{
						Geodesic_EdWilliams.CalcPoint_Williams(geoPoint_0.Longitude, geoPoint_0.Latitude, ref double_, ref double_12, float_18, Math2.UpdateClass(num + float_6));
					}
					if (num13 <= 0)
					{
						Aircraft aircraft_2 = aircraft_0;
						waypoint_5 = (flight = flight_0).FlightPlan;
						WriteTokenizer(null, aircraft_2, ref waypoint_5, double_12, double_, aircraftMissionProfile_0, ref float_13, ref float_14, ref bool_19, ref unitThrottlePreset_, ref float_15, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
						flight.FlightPlan = waypoint_5;
					}
					else
					{
						Aircraft object_3 = aircraft_0;
						waypoint_5 = (flight = flight_0).FlightPlan;
						NewTokenizer(null, object_3, ref waypoint_5, double_12, double_, aircraftMissionProfile_0, ref float_13, ref float_14, ref bool_19, ref unitThrottlePreset_, ref float_15, ref formation_0, Waypoint.TurnRateCategory.StandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
						flight.FlightPlan = waypoint_5;
						Aircraft aircraft_3 = aircraft_0;
						waypoint_5 = (flight = flight_0).FlightPlan;
						double double_24 = double_12;
						double double_2 = double_;
						AircraftMissionProfile aircraftMissionProfile_ = aircraftMissionProfile_0;
						bool bool_20 = true;
						Waypoint waypoint2 = PushTokenizer(null, aircraft_3, ref waypoint_5, double_24, double_2, aircraftMissionProfile_, ref float_13, ref float_14, ref bool_19, ref unitThrottlePreset_, ref float_15, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, ref mission_0, ref bool_20, num13);
						flight.FlightPlan = waypoint_5;
						waypoint = waypoint2;
					}
				}
				if (bool_3 && float_7 < 0f)
				{
					bool_3 = false;
				}
				float num14 = Math2.VerifyClass(unit_0.GetLatitude(), unit_0.GetLongitude(), geoPoint_1.Latitude, geoPoint_1.Longitude);
				float float_19;
				if (bool_1)
				{
					Math2.PublishClass(aircraft_0.GetLatitude(), aircraft_0.GetLongitude(), unit_0.GetLatitude(), unit_0.GetLongitude());
					float_19 = Math2.PublishClass(unit_0.GetLatitude(), unit_0.GetLongitude(), aircraft_0.GetLatitude(), aircraft_0.GetLongitude());
				}
				else
				{
					Math2.PublishClass(double_12, double_, unit_0.GetLatitude(), unit_0.GetLongitude());
					float_19 = Math2.PublishClass(unit_0.GetLatitude(), unit_0.GetLongitude(), double_12, double_);
				}
				float num15 = (bool_1 ? Math2.VerifyClass(aircraft_0.GetLatitude(), aircraft_0.GetLongitude(), unit_0.GetLatitude(), unit_0.GetLongitude()) : Math2.VerifyClass(double_12, double_, unit_0.GetLatitude(), unit_0.GetLongitude()));
				if (float_5 > 5f)
				{
					if (float_7 <= 0f)
					{
						if (num15 < 10f)
						{
							float_5 = 5f;
						}
						else if (num15 < 20f)
						{
							float_5 = num15 / 2f;
						}
						else
						{
							float_5 = num15 - 10f;
						}
					}
					else if (num15 < float_5)
					{
						if (num15 < 10f)
						{
							float_5 = 5f;
						}
						else if (num15 < 20f)
						{
							float_5 = num15 / 2f;
						}
						else
						{
							float_5 = 10f;
						}
					}
				}
				if (!bool_3 && num15 < 20f)
				{
					Geodesic_EdWilliams.CalcPoint_Williams(unit_0.GetLongitude(), unit_0.GetLatitude(), ref double_18, ref double_19, float_5, Math2.UpdateClass(float_19 + 180f + float_11));
				}
				else
				{
					Geodesic_EdWilliams.CalcPoint_Williams(unit_0.GetLongitude(), unit_0.GetLatitude(), ref double_18, ref double_19, float_5, Math2.UpdateClass(float_19 + float_11));
				}
				float num16 = num15 - float_5;
				float num17 = ((num16 < 20f) ? 20f : ((num16 < 40f) ? (num16 / 2f) : (num16 - 20f)));
				if (num16 < num17 + 5f)
				{
					if (num16 <= 10f)
					{
						num17 /= 2f;
					}
					else
					{
						num17 = num16 - 5f;
					}
				}
				num17 = num16 / 2f;
				if ((double)num17 < (double)float_0 * 1.5)
				{
					if ((double)float_0 * 1.5 <= (double)(num16 - 5f))
					{
						num17 = (float)((double)float_0 * 1.5);
					}
					else
					{
						num17 = (float)(((double)float_0 * 1.5 + (double)(num16 - 5f)) / 2.0);
						if (float_0 < num17 - 5f)
						{
							if (num16 < num17 + 5f)
							{
								num17 = Math.Max(num16 - 5f, 5f);
							}
							if (float_0 + 5f > num17)
							{
								num17 = float_0 + 5f;
							}
						}
						else
						{
							float_0 = 0f;
							float_1 = 0f;
						}
					}
				}
				bool flag2;
				if (!(float_0 <= 0f) && float_0 >= num17 - 5f)
				{
					waypoint_5 = (flight = flight_0).FlightPlan;
					float float_20 = float_0;
					float float_21 = float_1;
					float float_22 = float_19;
					float float_23 = float_5;
					float float_24 = float_11;
					AircraftMissionProfile aircraftMissionProfile_2 = aircraftMissionProfile_0;
					float float_25 = float_9;
					bool bool_8 = bool_1;
					bool bool_9 = bool_1;
					bool bool_10 = float_0 >= num17 - 5f;
					Waypoint waypoint_6 = null;
					Waypoint waypoint_7 = null;
					bool num2 = CalcValue(ref scenario_0, ref strike_0, ref flight_0, ref waypoint_5, ref aircraft_0, ref *(Contact*)(&unit_0), ref float_7, float_20, float_21, float_22, float_23, ref formation_0, ref float_15, _RadarBehaviour_0, ref float_13, ref float_14, ref bool_19, ref unitThrottlePreset_, float_24, ref float_16, aircraftMissionProfile_2, float_25, bool_8, bool_9, bool_10, ref waypoint_6, ref waypoint_7, ref bool_2, ref waypoint_, ref waypoint_4, object_, bool_3);
					flight.FlightPlan = waypoint_5;
					flag2 = num2;
				}
				else
				{
					flag2 = false;
				}
				if (!flag2)
				{
					if (bool_1)
					{
						double_20 = aircraft_0.GetLatitude();
						double_21 = aircraft_0.GetLongitude();
					}
					else if (bool_3)
					{
						if (float_9 < 6f)
						{
							Geodesic_EdWilliams.CalcPoint_Williams(unit_0.GetLongitude(), unit_0.GetLatitude(), ref double_21, ref double_20, float_5 + num17, Math2.UpdateClass(float_19 + float_11));
						}
						else
						{
							Geodesic_EdWilliams.CalcPoint_Williams(unit_0.GetLongitude(), unit_0.GetLatitude(), ref double_21, ref double_20, float_5 + num17, Math2.UpdateClass(float_19 + float_11));
						}
					}
					else
					{
						Geodesic_EdWilliams.CalcPoint_Williams(unit_0.GetLongitude(), unit_0.GetLatitude(), ref double_21, ref double_20, float_5 + num17, Math2.UpdateClass(float_19 + float_11));
					}
					Aircraft aircraft_4 = aircraft_0;
					waypoint_5 = (flight = flight_0).FlightPlan;
					InvokeTokenizer(null, aircraft_4, ref waypoint_5, double_20, double_21, aircraftMissionProfile_0, _RadarBehaviour_0, ref float_13, ref float_14, ref bool_19, ref unitThrottlePreset_, ref float_15, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
					flight.FlightPlan = waypoint_5;
					waypoint_5 = (flight = flight_0).FlightPlan;
					float float_26 = float_0;
					float float_27 = float_1;
					float float_28 = float_19;
					float float_29 = float_5;
					float float_30 = float_11;
					AircraftMissionProfile aircraftMissionProfile_3 = aircraftMissionProfile_0;
					float float_31 = float_9;
					bool bool_11 = bool_1;
					bool bool_12 = bool_1;
					bool bool_13 = float_0 >= num17 - 5f;
					Waypoint waypoint_8 = null;
					Waypoint waypoint_9 = null;
					bool num3 = CalcValue(ref scenario_0, ref strike_0, ref flight_0, ref waypoint_5, ref aircraft_0, ref *(Contact*)(&unit_0), ref float_7, float_26, float_27, float_28, float_29, ref formation_0, ref float_15, _RadarBehaviour_0, ref float_13, ref float_14, ref bool_19, ref unitThrottlePreset_, float_30, ref float_16, aircraftMissionProfile_3, float_31, bool_11, bool_12, bool_13, ref waypoint_8, ref waypoint_9, ref bool_2, ref waypoint_, ref waypoint_4, object_, bool_3);
					flight.FlightPlan = waypoint_5;
					flag2 = num3;
				}
				if (!aircraft_0.IsHelicopter && !Information.IsNothing(waypoint))
				{
					float num4 = Math2.VerifyClass(double_12, double_, flight_0.FlightPlan[3].Latitude, flight_0.FlightPlan[3].Longitude);
					float num5 = 0f;
					float float_32;
					if (flag)
					{
						float_32 = 15f;
					}
					else if (num4 < 20f)
					{
						num5 = 90f;
						float_32 = 15f;
					}
					else
					{
						float_32 = ((num4 < 30f) ? (num4 / 2f) : 15f);
					}
					if (flag)
					{
						double double_3 = double_;
						double double_4 = double_12;
						Waypoint waypoint3;
						double double_5 = (waypoint3 = waypoint).Longitude;
						Waypoint waypoint4 = waypoint;
						double double_6 = waypoint4.Latitude;
						Geodesic_EdWilliams.CalcPoint_Williams(double_3, double_4, ref double_5, ref double_6, float_32, Math2.UpdateClass(num + 180f + num5));
						waypoint4.Latitude = double_6;
						waypoint3.Longitude = double_5;
					}
					else
					{
						double double_7 = double_;
						double double_8 = double_12;
						Waypoint waypoint5;
						double double_9 = (waypoint5 = waypoint).Longitude;
						Waypoint waypoint6 = waypoint;
						double double_10 = waypoint6.Latitude;
						Geodesic_EdWilliams.CalcPoint_Williams(double_7, double_8, ref double_9, ref double_10, float_32, Math2.UpdateClass(num + num5));
						waypoint6.Latitude = double_10;
						waypoint5.Longitude = double_9;
					}
				}
				Aircraft aircraft_5 = aircraft_0;
				waypoint_5 = (flight = flight_0).FlightPlan;
				Waypoint waypoint7 = IncludeTokenizer(null, aircraft_5, ref waypoint_5, double_19, double_18, aircraftMissionProfile_0, _RadarBehaviour_0, float_9, ref float_13, ref float_14, ref bool_19, ref unitThrottlePreset_, ref float_15, ref strike_0.AttackMethod, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military, weapon_0, unit_0);
				flight.FlightPlan = waypoint_5;
				object_ = waypoint7;
				Aircraft aircraft_6 = aircraft_0;
				waypoint_5 = (flight = flight_0).FlightPlan;
				SearchTokenizer(null, aircraft_6, ref waypoint_5, unit_0.GetLatitude(), unit_0.GetLongitude(), aircraftMissionProfile_0, _RadarBehaviour_0, float_9, ref float_13, ref float_14, ref bool_19, ref unitThrottlePreset_, ref float_15, ref strike_0.AttackMethod, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, strike_0.Doctrine, Waypoint.SpeedToT.No, float_2, weapon_0, unit_0);
				flight.FlightPlan = waypoint_5;
				float num6 = Math2.PublishClass(unit_0.GetLatitude(), unit_0.GetLongitude(), geoPoint_1.Latitude, geoPoint_1.Longitude);
				Math2.PublishClass(geoPoint_1.Latitude, geoPoint_1.Longitude, unit_0.GetLatitude(), unit_0.GetLongitude());
				float num7 = ((!(num17 <= 0f) && !(num14 <= num17)) ? num17 : ((num14 < 10f) ? 20f : ((num14 < 20f) ? 30f : ((num14 < 40f) ? (num14 / 2f) : (num14 - 20f)))));
				if (bool_1)
				{
					if (float_9 < 6f)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(unit_0.GetLongitude(), unit_0.GetLatitude(), ref double_22, ref double_23, num7, Math2.UpdateClass(num6 + float_10));
					}
					else
					{
						Geodesic_EdWilliams.CalcPoint_Williams(double_18, double_19, ref double_22, ref double_23, num7, Math2.UpdateClass(num6 + float_10));
					}
				}
				else if (float_9 < 6f)
				{
					Geodesic_EdWilliams.CalcPoint_Williams(unit_0.GetLongitude(), unit_0.GetLatitude(), ref double_22, ref double_23, num7, Math2.UpdateClass(num6 + float_10));
				}
				else
				{
					Geodesic_EdWilliams.CalcPoint_Williams(double_18, double_19, ref double_22, ref double_23, num7, Math2.UpdateClass(num6 + float_10));
				}
				if (strike_0.AttackMethod >= Mission._AttackMethod.MultiAxisSimultaneousToT)
				{
					if (Information.IsNothing(waypoint_4))
					{
						ResetValue(ref strike_0, bool_2, ref turnDirection_0, ref float_17, double_20, double_21, double_23, double_22, ref geoPoint_0, bool_3);
					}
					else
					{
						ResetValue(ref strike_0, bool_2, ref turnDirection_0, ref float_17, waypoint_4.Latitude, waypoint_4.Longitude, double_23, double_22, ref geoPoint_0, bool_3);
					}
					MapValue(ref strike_0, ref *(Contact*)(&unit_0), ref turnDirection_0, ref float_16, ref waypoint_, ref waypoint_4, object_, ref float_9, ref float_1, ref float_19, ref float_5, float_11, double_19, double_18);
				}
				bool flag3;
				if (float_0 > 0f && float_0 < num7 - 5f && flag2)
				{
					waypoint_5 = (flight = flight_0).FlightPlan;
					double double_11 = double_19;
					double double_13 = double_18;
					float float_33 = float_9;
					float float_34 = float_7;
					float float_35 = float_0;
					float float_36 = float_1;
					float float_37 = float_17;
					float float_38 = float_10;
					AircraftMissionProfile aircraftMissionProfile_4 = aircraftMissionProfile_0;
					bool bool_14 = bool_1;
					bool bool_15 = float_0 >= num7 - 5f;
					Waypoint waypoint_10 = null;
					Waypoint waypoint_11 = null;
					bool num8 = OrderValue(ref strike_0, ref flight_0, ref waypoint_5, ref aircraft_0, ref *(Contact*)(&unit_0), double_11, double_13, num7, float_33, num6, float_34, float_35, float_36, ref formation_0, ref float_15, ref float_13, ref float_14, ref bool_19, ref unitThrottlePreset_, float_37, float_38, aircraftMissionProfile_4, bool_14, bool_15, ref waypoint_10, ref waypoint_11, ref bool_2, ref waypoint_, ref waypoint_4, object_, bool_3);
					flight.FlightPlan = waypoint_5;
					flag3 = num8;
				}
				else
				{
					flag3 = false;
				}
				if (float_0 == 0f || float_0 < num7 - 5f)
				{
					Aircraft aircraft_7 = aircraft_0;
					waypoint_5 = (flight = flight_0).FlightPlan;
					FindTokenizer(null, aircraft_7, ref waypoint_5, double_23, double_22, aircraftMissionProfile_0, ref float_13, ref float_14, ref bool_19, ref unitThrottlePreset_, ref float_15, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
					flight.FlightPlan = waypoint_5;
				}
				if (!flag3 && flag2)
				{
					waypoint_5 = (flight = flight_0).FlightPlan;
					double double_14 = double_19;
					double double_15 = double_18;
					float float_39 = float_9;
					float float_40 = float_7;
					float float_41 = float_0;
					float float_42 = float_1;
					float float_43 = float_17;
					float float_44 = float_10;
					AircraftMissionProfile aircraftMissionProfile_5 = aircraftMissionProfile_0;
					bool bool_16 = bool_1;
					bool bool_17 = float_0 >= num7 - 5f;
					Waypoint waypoint_2 = null;
					Waypoint waypoint_3 = null;
					OrderValue(ref strike_0, ref flight_0, ref waypoint_5, ref aircraft_0, ref *(Contact*)(&unit_0), double_14, double_15, num7, float_39, num6, float_40, float_41, float_42, ref formation_0, ref float_15, ref float_13, ref float_14, ref bool_19, ref unitThrottlePreset_, float_43, float_44, aircraftMissionProfile_5, bool_16, bool_17, ref waypoint_2, ref waypoint_3, ref bool_2, ref waypoint_, ref waypoint_4, object_, bool_3);
					flight.FlightPlan = waypoint_5;
				}
				if (aircraft_0.IsHelicopter)
				{
					if (flag)
					{
						double latitude = geoPoint_1.Latitude;
						double longitude = geoPoint_1.Longitude;
						GeoPoint obj = geoPoint_1;
						double double_16 = obj.Latitude;
						GeoPoint obj2 = geoPoint_1;
						double double_17 = obj2.Longitude;
						Geodesic_EdWilliams.CalcPoint_Williams(latitude, longitude, ref double_16, ref double_17, 10f, Math2.UpdateClass(num + 180f));
						obj2.Longitude = double_17;
						obj.Latitude = double_16;
						Aircraft object_4 = aircraft_0;
						waypoint_5 = (flight = flight_0).FlightPlan;
						double latitude2 = geoPoint_1.Latitude;
						double longitude2 = geoPoint_1.Longitude;
						AircraftMissionProfile object_5 = aircraftMissionProfile_0;
						Waypoint.Formation formation_ = Waypoint.Formation.Spread;
						FillTokenizer(null, object_4, ref waypoint_5, latitude2, longitude2, object_5, ref float_13, ref float_14, ref bool_19, ref unitThrottlePreset_, ref float_15, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, null, Waypoint.SpeedToT.Yes_UpOrDown_Military);
						flight.FlightPlan = waypoint_5;
					}
				}
				else
				{
					Aircraft object_6 = aircraft_0;
					waypoint_5 = (flight = flight_0).FlightPlan;
					CheckTokenizer(null, object_6, ref waypoint_5, geoPoint_1.Latitude, geoPoint_1.Longitude, aircraftMissionProfile_0, ref float_13, ref float_14, ref bool_19, ref unitThrottlePreset_, ref float_15, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
					flight.FlightPlan = waypoint_5;
				}
				Aircraft object_7 = aircraft_0;
				waypoint_5 = (flight = flight_0).FlightPlan;
				InterruptTokenizer(null, object_7, ref waypoint_5, geoPoint_2.Latitude, geoPoint_2.Longitude, aircraftMissionProfile_0, ref float_13, ref float_14, ref bool_19, ref unitThrottlePreset_, ref float_15, ref formation_0, Waypoint.TurnRateCategory.StandardRateTurn);
				flight.FlightPlan = waypoint_5;
				CloneTokenizer(ref scenario_0, ref mission_0, flight_0.FlightPlan, bool_4, ref bool_6);
				Scenario scenario_ = scenario_0;
				Mission strike_ = mission_0;
				Aircraft object_8 = aircraft_0;
				Mission.Flight flight_ = flight_0;
				waypoint_5 = (flight = flight_0).FlightPlan;
				bool num9 = ConnectTokenizer(scenario_, strike_, object_8, flight_, ref waypoint_5, ref float_12, ref float_3, bool_0: true, bool_1: false, bool_2: true, bool_3: true, bool_4: true, bool_5: true, bool_6: false, 0f, 0f, turnDirection_0, bool_3, bool_1, bool_2, nullable_1, nullable_2, bool_7);
				flight.FlightPlan = waypoint_5;
				if (num9)
				{
					break;
				}
				bool? flag4 = nullable_0;
				flag4 = flag4;
				if (flag4.GetValueOrDefault())
				{
					break;
				}
				string_0 = "目标在最大探测半径范围内，但是当前选择的飞行剖面需要太多燃料。";
				if (Information.IsNothing(nullable_0))
				{
					Aircraft_Navigator navigator = aircraft_0.Navigator;
					bool bool_18 = false;
					float value = navigator.OrderProxy(ref bool_18);
					nullable_0 = aircraft_0.AI.WriteClient(unit_0.GetLatitude(), unit_0.GetLongitude(), aircraft_0.Loadout.CombatRadius, value);
				}
				if (!Information.IsNothing(nullable_0) && !((!nullable_0) ?? nullable_0).GetValueOrDefault())
				{
					continue;
				}
				if (float_11 != 0f || float_10 != 0f)
				{
					if (float_11 != 0f)
					{
						if (float_11 <= 0f)
						{
							if (float_11 < -5f)
							{
								float_11 += 5f;
							}
							else
							{
								float_11 = 0f;
							}
						}
						else if (float_11 <= 5f)
						{
							float_11 = 0f;
						}
						else
						{
							float_11 -= 5f;
						}
					}
					if (float_10 == 0f)
					{
						continue;
					}
					if (float_10 <= 0f)
					{
						if (float_10 < -5f)
						{
							float_10 += 5f;
						}
						else
						{
							float_10 = 0f;
						}
					}
					else if (float_10 <= 5f)
					{
						float_10 = 0f;
					}
					else
					{
						float_10 -= 5f;
					}
					continue;
				}
				flight_0.ClearFlightPlan();
				return;
			}
			bool_0 = true;
			string_0 = "";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private unsafe static void StartValue(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Aircraft aircraft_0, ref Strike strike_0, ref Waypoint.Formation formation_0, Module_Unit.Unit unit_0, ref GeoPoint geoPoint_0, ref GeoPoint geoPoint_1, ref GeoPoint geoPoint_2, float float_0, float float_1, float float_2, ref Misc.TurnDirection turnDirection_0, ref float float_3, ref float float_4, ref AircraftMissionProfile aircraftMissionProfile_0, ref bool bool_0, ref float float_5, ref float float_6, ref float float_7, ref bool bool_1, float float_8, ref Weapon weapon_0, float float_9, ref float float_10, ref float float_11, Mission._RadarBehaviour _RadarBehaviour_0, ref bool bool_2, bool bool_3, ref string string_0, bool? nullable_0, bool bool_4, ref float float_12, bool bool_5, ref bool bool_6, DateTime? nullable_1, DateTime? nullable_2, bool bool_7)
	{
		try
		{
			flight_0.HasCriticalError = false;
			bool flag = false;
			side_0.Units.ToList();
			float float_13 = 0f;
			float float_14 = 0f;
			bool bool_17 = false;
			ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_ = ActiveUnit_Kinematics.UnitThrottlePreset.FullStop;
			float float_15 = 0f;
			double double_ = 0.0;
			double double_12 = 0.0;
			double double_18 = 0.0;
			double double_19 = 0.0;
			Waypoint waypoint = null;
			Waypoint waypoint2 = null;
			double double_20 = 0.0;
			double double_21 = 0.0;
			float float_16 = 0f;
			Waypoint waypoint_ = null;
			Waypoint waypoint_5 = null;
			Waypoint object_ = null;
			bool flag2 = false;
			double double_22 = 0.0;
			double double_23 = 0.0;
			double double_24 = 0.0;
			double double_2 = 0.0;
			float float_17 = 0f;
			while (true)
			{
				if (bool_0)
				{
					return;
				}
				flight_0.ClearFlightPlan();
				float num = (bool_1 ? Math2.PublishClass(aircraft_0.GetLatitude(), aircraft_0.GetLongitude(), unit_0.GetLatitude(), unit_0.GetLongitude()) : Math2.PublishClass(geoPoint_0.Latitude, geoPoint_0.Longitude, unit_0.GetLatitude(), unit_0.GetLongitude()));
				int num10 = 0;
				float float_18;
				if (aircraft_0.IsHelicopter)
				{
					if (aircraftMissionProfile_0.FormUpTime < 2)
					{
						if (float_7 < 20f && float_7 > 0f)
						{
							if (float_7 < 10f)
							{
								float_18 = 5f;
								flag = true;
							}
							else
							{
								float_18 = float_7 / 2f;
								flag = true;
							}
						}
						else
						{
							float_18 = 10f;
						}
					}
					else
					{
						if (float_7 < 10f)
						{
							flag = true;
						}
						float num11 = aircraft_0.Kinematics.GetMaximumSpeed(aircraftMissionProfile_0.FormUpAltitude * 0.3048f, ActiveUnit.Throttle.Loiter, bool_0: false);
						num10 = 2;
						float_18 = num11 * 2f / 60f;
					}
				}
				else if (aircraftMissionProfile_0.FormUpTime < 2)
				{
					if (float_7 < 30f)
					{
						flag = true;
					}
					float_18 = 10f;
				}
				else
				{
					if (float_7 < 30f)
					{
						flag = true;
					}
					float num12 = aircraft_0.Kinematics.GetMaximumSpeed(aircraftMissionProfile_0.FormUpAltitude * 0.3048f, ActiveUnit.Throttle.Loiter, bool_0: false);
					num10 = 2;
					float_18 = num12 * 2f / 60f;
				}
				int num13 = aircraftMissionProfile_0.FormUpTime - num10;
				Aircraft object_2 = aircraft_0;
				Mission.Flight flight;
				Waypoint[] waypoint_6 = (flight = flight_0).FlightPlan;
				ConcatTokenizer(null, object_2, ref waypoint_6, geoPoint_0.Latitude, geoPoint_0.Longitude, aircraftMissionProfile_0, ref float_13, ref float_14, ref bool_17, ref unitThrottlePreset_, ref float_15, ref formation_0, Waypoint.TurnRateCategory.StandardRateTurn);
				flight.FlightPlan = waypoint_6;
				if (aircraft_0.IsHelicopter)
				{
					if (float_7 <= 0f)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(geoPoint_0.Longitude, geoPoint_0.Latitude, ref double_, ref double_12, float_18, Math2.UpdateClass(num + 180f + float_6));
					}
					else
					{
						Geodesic_EdWilliams.CalcPoint_Williams(geoPoint_0.Longitude, geoPoint_0.Latitude, ref double_, ref double_12, float_18, Math2.UpdateClass(num + float_6));
					}
					Aircraft aircraft_ = aircraft_0;
					waypoint_6 = (flight = flight_0).FlightPlan;
					WriteTokenizer(null, aircraft_, ref waypoint_6, double_12, double_, aircraftMissionProfile_0, ref float_13, ref float_14, ref bool_17, ref unitThrottlePreset_, ref float_15, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
					flight.FlightPlan = waypoint_6;
				}
				else
				{
					if (flag)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(geoPoint_0.Longitude, geoPoint_0.Latitude, ref double_, ref double_12, float_18, Math2.UpdateClass(num + 180f + float_6));
					}
					else
					{
						Geodesic_EdWilliams.CalcPoint_Williams(geoPoint_0.Longitude, geoPoint_0.Latitude, ref double_, ref double_12, float_18, Math2.UpdateClass(num + float_6));
					}
					if (num13 <= 0)
					{
						Aircraft aircraft_2 = aircraft_0;
						waypoint_6 = (flight = flight_0).FlightPlan;
						WriteTokenizer(null, aircraft_2, ref waypoint_6, double_12, double_, aircraftMissionProfile_0, ref float_13, ref float_14, ref bool_17, ref unitThrottlePreset_, ref float_15, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
						flight.FlightPlan = waypoint_6;
					}
					else
					{
						Aircraft object_3 = aircraft_0;
						waypoint_6 = (flight = flight_0).FlightPlan;
						NewTokenizer(null, object_3, ref waypoint_6, double_12, double_, aircraftMissionProfile_0, ref float_13, ref float_14, ref bool_17, ref unitThrottlePreset_, ref float_15, ref formation_0, Waypoint.TurnRateCategory.StandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
						flight.FlightPlan = waypoint_6;
						Aircraft aircraft_3 = aircraft_0;
						waypoint_6 = (flight = flight_0).FlightPlan;
						AircraftMissionProfile aircraftMissionProfile_ = aircraftMissionProfile_0;
						bool bool_18 = true;
						Waypoint waypoint3 = PushTokenizer(null, aircraft_3, ref waypoint_6, double_18, double_19, aircraftMissionProfile_, ref float_13, ref float_14, ref bool_17, ref unitThrottlePreset_, ref float_15, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, ref mission_0, ref bool_18, num13);
						flight.FlightPlan = waypoint_6;
						waypoint = waypoint3;
					}
				}
				if (bool_3 && float_7 < 0f)
				{
					bool_3 = false;
				}
				if (bool_1)
				{
					waypoint2 = new Waypoint(aircraft_0.GetLongitude(), aircraft_0.GetLatitude(), 0f, Waypoint.WaypointType.StrikeIngress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
					Mission.Flight obj = flight_0;
					waypoint_6 = obj.FlightPlan;
					ArrayExtensions.Add(ref waypoint_6, waypoint2);
					obj.FlightPlan = waypoint_6;
					Waypoint waypoint_7 = waypoint2;
					Aircraft aircraft_4 = aircraft_0;
					waypoint_6 = (flight = flight_0).FlightPlan;
					RemoveTokenizer(waypoint_7, aircraft_4, ref waypoint_6, aircraft_0.GetLatitude(), aircraft_0.GetLongitude(), aircraftMissionProfile_0, Mission._RadarBehaviour.None, ref float_13, ref float_14, ref bool_17, ref unitThrottlePreset_, ref float_15, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
					flight.FlightPlan = waypoint_6;
				}
				float float_19;
				if (bool_1)
				{
					Math2.PublishClass(aircraft_0.GetLatitude(), aircraft_0.GetLongitude(), unit_0.GetLatitude(), unit_0.GetLongitude());
					float_19 = Math2.PublishClass(unit_0.GetLatitude(), unit_0.GetLongitude(), aircraft_0.GetLatitude(), aircraft_0.GetLongitude());
				}
				else
				{
					Math2.PublishClass(double_12, double_, unit_0.GetLatitude(), unit_0.GetLongitude());
					float_19 = Math2.PublishClass(unit_0.GetLatitude(), unit_0.GetLongitude(), double_12, double_);
				}
				float num14 = Math2.PublishClass(unit_0.GetLatitude(), unit_0.GetLongitude(), geoPoint_1.Latitude, geoPoint_1.Longitude);
				Math2.PublishClass(geoPoint_1.Latitude, geoPoint_1.Longitude, unit_0.GetLatitude(), unit_0.GetLongitude());
				Geodesic_EdWilliams.CalcPoint_Williams(unit_0.GetLongitude(), unit_0.GetLatitude(), ref double_20, ref double_21, float_5, Math2.UpdateClass(num14 + float_11));
				float num16;
				if (aircraftMissionProfile_0.AttackDistanceIngress <= 0)
				{
					float num15 = (bool_1 ? Math2.VerifyClass(aircraft_0.GetLatitude(), aircraft_0.GetLongitude(), unit_0.GetLatitude(), unit_0.GetLongitude()) : Math2.VerifyClass(double_12, double_, unit_0.GetLatitude(), unit_0.GetLongitude())) - float_5;
					if (num15 <= 50f)
					{
						num16 = num15 / 2f;
						if ((double)num16 < (double)float_0 * 1.5)
						{
							if ((double)float_0 * 1.5 <= (double)(num15 - 5f))
							{
								num16 = (float)((double)float_0 * 1.5);
							}
							else
							{
								num16 = (float)(((double)float_0 * 1.5 + (double)(num15 - 5f)) / 2.0);
								if (float_0 < num16 - 5f)
								{
									if (num15 < num16 + 5f)
									{
										num16 = Math.Max(num15 - 5f, 5f);
									}
									if (float_0 + 5f > num16)
									{
										num16 = float_0 + 5f;
									}
								}
								else
								{
									float_0 = 0f;
									float_1 = 0f;
								}
							}
						}
					}
					else
					{
						num16 = 50f;
					}
				}
				else if (bool_1 && !Information.IsNothing(waypoint2))
				{
					float num17 = Math2.VerifyClass(waypoint2.Latitude, waypoint2.Longitude, unit_0.GetLatitude(), unit_0.GetLongitude());
					num16 = (((float)aircraftMissionProfile_0.AttackDistanceIngress <= num17 - 20f) ? ((float)aircraftMissionProfile_0.AttackDistanceIngress) : (num17 - 20f));
				}
				else
				{
					num16 = aircraftMissionProfile_0.AttackDistanceIngress;
				}
				if (num16 <= 0f)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				else
				{
					if (!(float_0 <= 0f) && float_0 >= num16 - 5f)
					{
						waypoint_6 = (flight = flight_0).FlightPlan;
						float float_20 = float_0;
						float float_21 = float_1;
						float float_22 = float_19;
						float float_23 = float_5;
						float float_24 = float_11;
						AircraftMissionProfile aircraftMissionProfile_2 = aircraftMissionProfile_0;
						float float_25 = float_9;
						bool bool_8 = bool_1;
						bool bool_9 = float_0 >= num16 - 5f;
						Waypoint waypoint_8 = null;
						Waypoint waypoint_9 = null;
						bool num2 = CalcValue(ref scenario_0, ref strike_0, ref flight_0, ref waypoint_6, ref aircraft_0, ref *(Contact*)(&unit_0), ref float_7, float_20, float_21, float_22, float_23, ref formation_0, ref float_15, _RadarBehaviour_0, ref float_13, ref float_14, ref bool_17, ref unitThrottlePreset_, float_24, ref float_16, aircraftMissionProfile_2, float_25, bool_8, bool_2: false, bool_9, ref waypoint_8, ref waypoint_9, ref bool_2, ref waypoint_, ref waypoint_5, object_, bool_3);
						flight.FlightPlan = waypoint_6;
						flag2 = num2;
					}
					else
					{
						flag2 = false;
					}
					if (float_9 < 6f)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(unit_0.GetLongitude(), unit_0.GetLatitude(), ref double_22, ref double_23, num16, Math2.UpdateClass(float_19 + float_11));
					}
					else
					{
						Geodesic_EdWilliams.CalcPoint_Williams(unit_0.GetLongitude(), unit_0.GetLatitude(), ref double_22, ref double_23, num16 + float_5, Math2.UpdateClass(float_19 + float_11));
					}
					if (!flag2)
					{
						Aircraft aircraft_5 = aircraft_0;
						waypoint_6 = (flight = flight_0).FlightPlan;
						InvokeTokenizer(null, aircraft_5, ref waypoint_6, double_23, double_22, aircraftMissionProfile_0, _RadarBehaviour_0, ref float_13, ref float_14, ref bool_17, ref unitThrottlePreset_, ref float_15, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
						flight.FlightPlan = waypoint_6;
						waypoint_6 = (flight = flight_0).FlightPlan;
						float float_26 = float_0;
						float float_27 = float_1;
						float float_28 = float_19;
						float float_29 = float_5;
						float float_30 = float_11;
						AircraftMissionProfile aircraftMissionProfile_3 = aircraftMissionProfile_0;
						float float_31 = float_9;
						bool bool_10 = bool_1;
						bool bool_11 = float_0 >= num16 - 5f;
						Waypoint waypoint_10 = null;
						Waypoint waypoint_11 = null;
						bool num3 = CalcValue(ref scenario_0, ref strike_0, ref flight_0, ref waypoint_6, ref aircraft_0, ref *(Contact*)(&unit_0), ref float_7, float_26, float_27, float_28, float_29, ref formation_0, ref float_15, _RadarBehaviour_0, ref float_13, ref float_14, ref bool_17, ref unitThrottlePreset_, float_30, ref float_16, aircraftMissionProfile_3, float_31, bool_10, bool_2: false, bool_11, ref waypoint_10, ref waypoint_11, ref bool_2, ref waypoint_, ref waypoint_5, object_, bool_3);
						flight.FlightPlan = waypoint_6;
						flag2 = num3;
					}
					Aircraft aircraft_6 = aircraft_0;
					waypoint_6 = (flight = flight_0).FlightPlan;
					Waypoint waypoint4 = IncludeTokenizer(null, aircraft_6, ref waypoint_6, double_21, double_20, aircraftMissionProfile_0, _RadarBehaviour_0, float_9, ref float_13, ref float_14, ref bool_17, ref unitThrottlePreset_, ref float_15, ref strike_0.AttackMethod, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military, weapon_0, unit_0);
					flight.FlightPlan = waypoint_6;
					object_ = waypoint4;
				}
				if (!aircraft_0.IsHelicopter && !Information.IsNothing(waypoint))
				{
					float num4 = Math2.VerifyClass(double_12, double_, flight_0.FlightPlan[3].Latitude, flight_0.FlightPlan[3].Longitude);
					float num5 = 0f;
					float float_32;
					if (flag)
					{
						float_32 = 15f;
					}
					else if (num4 < 20f)
					{
						num5 = 90f;
						float_32 = 15f;
					}
					else
					{
						float_32 = ((num4 < 30f) ? (num4 / 2f) : 15f);
					}
					if (flag)
					{
						double double_3 = double_;
						double double_4 = double_12;
						Waypoint waypoint5;
						double double_5 = (waypoint5 = waypoint).Longitude;
						Waypoint waypoint6 = waypoint;
						double double_6 = waypoint6.Latitude;
						Geodesic_EdWilliams.CalcPoint_Williams(double_3, double_4, ref double_5, ref double_6, float_32, Math2.UpdateClass(num + 180f + num5));
						waypoint6.Latitude = double_6;
						waypoint5.Longitude = double_5;
					}
					else
					{
						double double_7 = double_;
						double double_8 = double_12;
						Waypoint waypoint7;
						double double_9 = (waypoint7 = waypoint).Longitude;
						Waypoint waypoint8 = waypoint;
						double double_10 = waypoint8.Latitude;
						Geodesic_EdWilliams.CalcPoint_Williams(double_7, double_8, ref double_9, ref double_10, float_32, Math2.UpdateClass(num + num5));
						waypoint8.Latitude = double_10;
						waypoint7.Longitude = double_9;
					}
				}
				Aircraft aircraft_7 = aircraft_0;
				waypoint_6 = (flight = flight_0).FlightPlan;
				SearchTokenizer(null, aircraft_7, ref waypoint_6, unit_0.GetLatitude(), unit_0.GetLongitude(), aircraftMissionProfile_0, _RadarBehaviour_0, float_9, ref float_13, ref float_14, ref bool_17, ref unitThrottlePreset_, ref float_15, ref strike_0.AttackMethod, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, strike_0.Doctrine, Waypoint.SpeedToT.No, float_2, weapon_0, unit_0);
				flight.FlightPlan = waypoint_6;
				float num7;
				if (aircraftMissionProfile_0.AttackDistanceEgress <= 0)
				{
					float num6 = Math2.VerifyClass(unit_0.GetLatitude(), unit_0.GetLongitude(), geoPoint_1.Latitude, geoPoint_1.Longitude) - float_5;
					if (num6 <= 50f)
					{
						num7 = num6 / 2f;
						if ((double)num7 < (double)float_0 * 1.5)
						{
							if ((double)float_0 * 1.5 <= (double)(num6 - 5f))
							{
								num7 = (float)((double)float_0 * 1.5);
							}
							else
							{
								num7 = (float)(((double)float_0 * 1.5 + (double)(num6 - 5f)) / 2.0);
								if (num6 < num7 + 5f)
								{
									num7 = num6 - 5f;
								}
								if (float_0 + 5f > num7)
								{
									num7 = float_0 + 5f;
								}
							}
						}
					}
					else
					{
						num7 = 50f;
					}
				}
				else
				{
					num7 = aircraftMissionProfile_0.AttackDistanceEgress;
				}
				if (num7 <= 0f)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				else
				{
					if (float_9 < 6f)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(unit_0.GetLongitude(), unit_0.GetLatitude(), ref double_24, ref double_2, num7, Math2.UpdateClass(num14 + float_10));
					}
					else
					{
						Geodesic_EdWilliams.CalcPoint_Williams(unit_0.GetLongitude(), unit_0.GetLatitude(), ref double_24, ref double_2, num7 + float_5, Math2.UpdateClass(num14 + float_10));
					}
					if (strike_0.AttackMethod >= Mission._AttackMethod.MultiAxisSimultaneousToT)
					{
						if (Information.IsNothing(waypoint_5))
						{
							ResetValue(ref strike_0, bool_2, ref turnDirection_0, ref float_17, double_23, double_22, double_2, double_24, ref geoPoint_0, bool_3);
						}
						else
						{
							ResetValue(ref strike_0, bool_2, ref turnDirection_0, ref float_17, waypoint_5.Latitude, waypoint_5.Longitude, double_2, double_24, ref geoPoint_0, bool_3);
						}
						MapValue(ref strike_0, ref *(Contact*)(&unit_0), ref turnDirection_0, ref float_16, ref waypoint_, ref waypoint_5, object_, ref float_9, ref float_1, ref float_19, ref float_5, float_11, double_21, double_20);
					}
					bool flag3;
					if (float_0 > 0f && float_0 < num7 - 5f && flag2)
					{
						waypoint_6 = (flight = flight_0).FlightPlan;
						double double_11 = double_21;
						double double_13 = double_20;
						float float_33 = num7;
						float float_34 = float_9;
						float float_35 = float_7;
						float float_36 = float_0;
						float float_37 = float_1;
						float float_38 = float_17;
						float float_39 = float_10;
						AircraftMissionProfile aircraftMissionProfile_4 = aircraftMissionProfile_0;
						bool bool_12 = bool_1;
						bool bool_13 = float_0 >= num7 - 5f;
						Waypoint waypoint_12 = null;
						Waypoint waypoint_2 = null;
						bool num8 = OrderValue(ref strike_0, ref flight_0, ref waypoint_6, ref aircraft_0, ref *(Contact*)(&unit_0), double_11, double_13, float_33, float_34, num14, float_35, float_36, float_37, ref formation_0, ref float_15, ref float_13, ref float_14, ref bool_17, ref unitThrottlePreset_, float_38, float_39, aircraftMissionProfile_4, bool_12, bool_13, ref waypoint_12, ref waypoint_2, ref bool_2, ref waypoint_, ref waypoint_5, object_, bool_3);
						flight.FlightPlan = waypoint_6;
						flag3 = num8;
					}
					else
					{
						flag3 = false;
					}
					if (float_0 == 0f || float_0 < num7 - 5f)
					{
						Aircraft aircraft_8 = aircraft_0;
						waypoint_6 = (flight = flight_0).FlightPlan;
						FindTokenizer(null, aircraft_8, ref waypoint_6, double_2, double_24, aircraftMissionProfile_0, ref float_13, ref float_14, ref bool_17, ref unitThrottlePreset_, ref float_15, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
						flight.FlightPlan = waypoint_6;
					}
					if (!flag3 && flag2)
					{
						waypoint_6 = (flight = flight_0).FlightPlan;
						double double_14 = double_21;
						double double_15 = double_20;
						float float_40 = num7;
						float float_41 = float_9;
						float float_42 = float_7;
						float float_43 = float_0;
						float float_44 = float_1;
						float float_45 = float_17;
						float float_46 = float_10;
						AircraftMissionProfile aircraftMissionProfile_5 = aircraftMissionProfile_0;
						bool bool_14 = bool_1;
						bool bool_15 = float_0 >= num7 - 5f;
						Waypoint waypoint_3 = null;
						Waypoint waypoint_4 = null;
						OrderValue(ref strike_0, ref flight_0, ref waypoint_6, ref aircraft_0, ref *(Contact*)(&unit_0), double_14, double_15, float_40, float_41, num14, float_42, float_43, float_44, ref formation_0, ref float_15, ref float_13, ref float_14, ref bool_17, ref unitThrottlePreset_, float_45, float_46, aircraftMissionProfile_5, bool_14, bool_15, ref waypoint_3, ref waypoint_4, ref bool_2, ref waypoint_, ref waypoint_5, object_, bool_3);
						flight.FlightPlan = waypoint_6;
					}
				}
				if (aircraft_0.IsHelicopter)
				{
					if (flag)
					{
						double latitude = geoPoint_1.Latitude;
						double longitude = geoPoint_1.Longitude;
						GeoPoint obj2 = geoPoint_1;
						double double_16 = obj2.Latitude;
						GeoPoint obj3 = geoPoint_1;
						double double_17 = obj3.Longitude;
						Geodesic_EdWilliams.CalcPoint_Williams(latitude, longitude, ref double_16, ref double_17, 10f, Math2.UpdateClass(num + 180f));
						obj3.Longitude = double_17;
						obj2.Latitude = double_16;
						Aircraft object_4 = aircraft_0;
						waypoint_6 = (flight = flight_0).FlightPlan;
						double latitude2 = geoPoint_1.Latitude;
						double longitude2 = geoPoint_1.Longitude;
						AircraftMissionProfile object_5 = aircraftMissionProfile_0;
						Waypoint.Formation formation_ = Waypoint.Formation.Spread;
						FillTokenizer(null, object_4, ref waypoint_6, latitude2, longitude2, object_5, ref float_13, ref float_14, ref bool_17, ref unitThrottlePreset_, ref float_15, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, null, Waypoint.SpeedToT.Yes_UpOrDown_Military);
						flight.FlightPlan = waypoint_6;
					}
				}
				else
				{
					Aircraft object_6 = aircraft_0;
					waypoint_6 = (flight = flight_0).FlightPlan;
					CheckTokenizer(null, object_6, ref waypoint_6, geoPoint_1.Latitude, geoPoint_1.Longitude, aircraftMissionProfile_0, ref float_13, ref float_14, ref bool_17, ref unitThrottlePreset_, ref float_15, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
					flight.FlightPlan = waypoint_6;
				}
				Aircraft object_7 = aircraft_0;
				waypoint_6 = (flight = flight_0).FlightPlan;
				InterruptTokenizer(null, object_7, ref waypoint_6, geoPoint_2.Latitude, geoPoint_2.Longitude, aircraftMissionProfile_0, ref float_13, ref float_14, ref bool_17, ref unitThrottlePreset_, ref float_15, ref formation_0, Waypoint.TurnRateCategory.StandardRateTurn);
				flight.FlightPlan = waypoint_6;
				CloneTokenizer(ref scenario_0, ref mission_0, flight_0.FlightPlan, bool_4, ref bool_6);
				Scenario scenario_ = scenario_0;
				Mission strike_ = mission_0;
				Aircraft object_8 = aircraft_0;
				Mission.Flight flight_ = flight_0;
				waypoint_6 = (flight = flight_0).FlightPlan;
				bool num9 = ConnectTokenizer(scenario_, strike_, object_8, flight_, ref waypoint_6, ref float_12, ref float_3, bool_0: true, bool_1: false, bool_2: true, bool_3: true, bool_4: true, bool_5: true, bool_6: false, 0f, 0f, turnDirection_0, bool_3, bool_1, bool_2, nullable_1, nullable_2, bool_7);
				flight.FlightPlan = waypoint_6;
				if (num9)
				{
					break;
				}
				bool? flag4 = nullable_0;
				flag4 = flag4;
				if (flag4.GetValueOrDefault())
				{
					break;
				}
				string_0 = "目标在最大探测半径范围内，但是当前选择的飞行剖面需要太多燃料。";
				if (Information.IsNothing(nullable_0))
				{
					Aircraft_Navigator navigator = aircraft_0.Navigator;
					bool bool_16 = false;
					float value = navigator.OrderProxy(ref bool_16);
					nullable_0 = aircraft_0.AI.WriteClient(unit_0.GetLatitude(), unit_0.GetLongitude(), aircraft_0.Loadout.CombatRadius, value);
				}
				if (!Information.IsNothing(nullable_0) && !((!nullable_0) ?? nullable_0).GetValueOrDefault())
				{
					continue;
				}
				if (float_11 != 0f || float_10 != 0f)
				{
					if (float_11 != 0f)
					{
						if (float_11 <= 0f)
						{
							if (float_11 < -5f)
							{
								float_11 += 5f;
							}
							else
							{
								float_11 = 0f;
							}
						}
						else if (float_11 <= 5f)
						{
							float_11 = 0f;
						}
						else
						{
							float_11 -= 5f;
						}
					}
					if (float_10 == 0f)
					{
						continue;
					}
					if (float_10 <= 0f)
					{
						if (float_10 < -5f)
						{
							float_10 += 5f;
						}
						else
						{
							float_10 = 0f;
						}
					}
					else if (float_10 <= 5f)
					{
						float_10 = 0f;
					}
					else
					{
						float_10 -= 5f;
					}
					continue;
				}
				flight_0.ClearFlightPlan();
				return;
			}
			bool_0 = true;
			string_0 = "";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static bool GenerateFlightPlan_Skeleton(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Aircraft aircraft_0, bool? nullable_0, ref bool bool_0, bool bool_1, bool bool_2, ref float float_0, ref string string_0, bool bool_3, float float_1, Waypoint.TurnRateCategory turnRateCategory_0, bool bool_4, DateTime? nullable_1, DateTime? nullable_2, bool bool_5)
	{
		try
		{
			if (!Information.IsNothing(aircraft_0) && Information.IsNothing(mission_0))
			{
				string_0 = "飞机的指定任务不存在。没有创建飞行计划。";
				return false;
			}
			flight_0.HasCriticalError = false;
			AircraftMissionProfile aircraftMissionProfile;
			if (!Information.IsNothing(aircraft_0) && !Information.IsNothing(aircraft_0.Loadout) && !Information.IsNothing(aircraft_0.Loadout.GetMissionProfile(scenario_0)))
			{
				aircraftMissionProfile = aircraft_0.Loadout.GetMissionProfile(scenario_0);
			}
			else
			{
				aircraftMissionProfile = new AircraftMissionProfile();
				aircraftMissionProfile.CruiseAltitudeIngress = 609.60004f;
				aircraftMissionProfile.CruiseThrottleSettingIngress = ActiveUnit.Throttle.Cruise;
				aircraftMissionProfile.CruiseAltitudeEgress = 609.60004f;
				aircraftMissionProfile.CruiseThrottleSettingEgress = ActiveUnit.Throttle.Cruise;
				aircraftMissionProfile.FormUpAltitude = 609.60004f;
				aircraftMissionProfile.FormUpTime = 10;
			}
			GeoPoint geoPoint = DefineValue(ref scenario_0, ref flight_0, ref aircraft_0);
			GeoPoint geoPoint2 = PublishValue(ref scenario_0, ref flight_0, ref aircraft_0);
			GeoPoint geoPoint3 = AwakeValue(ref scenario_0, ref flight_0, ref aircraft_0);
			float float_3 = 45f;
			float float_4 = 0f;
			float float_5 = 50f;
			side_0.Units.ToList();
			bool bool_6 = false;
			flight_0.ClearFlightPlan();
			int num = 0;
			float float_6;
			if (aircraftMissionProfile.FormUpTime < 2)
			{
				float_6 = 10f;
			}
			else
			{
				float num2 = aircraft_0.Kinematics.GetMaximumSpeed(aircraftMissionProfile.FormUpAltitude * 0.3048f, ActiveUnit.Throttle.Loiter, bool_0: false);
				num = 2;
				float_6 = num2 * 2f / 60f;
			}
			int num3 = aircraftMissionProfile.FormUpTime - num;
			Aircraft object_ = aircraft_0;
			Mission.Flight flight;
			Waypoint[] waypoint_ = (flight = flight_0).FlightPlan;
			double latitude = geoPoint2.Latitude;
			double longitude = geoPoint2.Longitude;
			AircraftMissionProfile aircraftMissionProfile_ = aircraftMissionProfile;
			Waypoint.Formation formation_ = Waypoint.Formation.Spread;
			float float_7 = 0f;
			float float_8 = 0f;
			bool bool_7 = false;
			ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_ = ActiveUnit_Kinematics.UnitThrottlePreset.FullStop;
			float float_9 = 0f;
			ConcatTokenizer(null, object_, ref waypoint_, latitude, longitude, aircraftMissionProfile_, ref float_7, ref float_8, ref bool_7, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.StandardRateTurn);
			flight.FlightPlan = waypoint_;
			double double_ = 0.0;
			double double_11 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(geoPoint2.Longitude, geoPoint2.Latitude, ref double_, ref double_11, float_6, Math2.UpdateClass(float_3));
			Waypoint waypoint = null;
			if (!Information.IsNothing(aircraft_0) && aircraft_0.IsHelicopter)
			{
				Aircraft aircraft_ = aircraft_0;
				waypoint_ = (flight = flight_0).FlightPlan;
				double double_12 = double_11;
				double double_13 = double_;
				AircraftMissionProfile aircraftMissionProfile_2 = aircraftMissionProfile;
				formation_ = Waypoint.Formation.Spread;
				WriteTokenizer(null, aircraft_, ref waypoint_, double_12, double_13, aircraftMissionProfile_2, ref float_7, ref float_8, ref bool_7, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
				flight.FlightPlan = waypoint_;
			}
			else if (num3 <= 0)
			{
				Aircraft aircraft_2 = aircraft_0;
				waypoint_ = (flight = flight_0).FlightPlan;
				double double_14 = double_11;
				double double_15 = double_;
				AircraftMissionProfile aircraftMissionProfile_3 = aircraftMissionProfile;
				formation_ = Waypoint.Formation.Spread;
				WriteTokenizer(null, aircraft_2, ref waypoint_, double_14, double_15, aircraftMissionProfile_3, ref float_7, ref float_8, ref bool_7, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
				flight.FlightPlan = waypoint_;
			}
			else
			{
				Aircraft object_2 = aircraft_0;
				waypoint_ = (flight = flight_0).FlightPlan;
				double double_16 = double_11;
				double double_17 = double_;
				AircraftMissionProfile aircraftMissionProfile_4 = aircraftMissionProfile;
				formation_ = Waypoint.Formation.Spread;
				NewTokenizer(null, object_2, ref waypoint_, double_16, double_17, aircraftMissionProfile_4, ref float_7, ref float_8, ref bool_7, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.StandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
				flight.FlightPlan = waypoint_;
				Aircraft aircraft_3 = aircraft_0;
				waypoint_ = (flight = flight_0).FlightPlan;
				double double_18 = double_11;
				double double_2 = double_;
				AircraftMissionProfile aircraftMissionProfile_5 = aircraftMissionProfile;
				formation_ = Waypoint.Formation.Spread;
				bool bool_8 = false;
				Waypoint waypoint2 = PushTokenizer(null, aircraft_3, ref waypoint_, double_18, double_2, aircraftMissionProfile_5, ref float_7, ref float_8, ref bool_7, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, ref mission_0, ref bool_8, num3);
				flight.FlightPlan = waypoint_;
				waypoint = waypoint2;
			}
			double double_3 = 0.0;
			double double_4 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(geoPoint2.Longitude, geoPoint2.Latitude, ref double_3, ref double_4, float_5, float_4);
			Aircraft object_3 = aircraft_0;
			waypoint_ = (flight = flight_0).FlightPlan;
			double double_5 = double_4;
			double double_6 = double_3;
			AircraftMissionProfile object_4 = aircraftMissionProfile;
			formation_ = Waypoint.Formation.Spread;
			FillTokenizer(null, object_3, ref waypoint_, double_5, double_6, object_4, ref float_7, ref float_8, ref bool_7, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, null, Waypoint.SpeedToT.Yes_DownOnly);
			flight.FlightPlan = waypoint_;
			float num4 = Math2.PublishClass(double_11, double_, double_4, double_3);
			if (Information.IsNothing(aircraft_0) || (!aircraft_0.IsHelicopter && !Information.IsNothing(waypoint)))
			{
				float num5 = Math2.VerifyClass(double_11, double_, flight_0.FlightPlan[3].Latitude, flight_0.FlightPlan[3].Longitude);
				float num6 = 0f;
				float float_10;
				if (num5 < 20f)
				{
					num6 = 90f;
					float_10 = 15f;
				}
				else
				{
					float_10 = ((num5 < 30f) ? (num5 / 2f) : 15f);
				}
				double double_7 = double_;
				double double_8 = double_11;
				Waypoint waypoint3;
				double double_9 = (waypoint3 = waypoint).Longitude;
				Waypoint waypoint4 = waypoint;
				double double_10 = waypoint4.Latitude;
				Geodesic_EdWilliams.CalcPoint_Williams(double_7, double_8, ref double_9, ref double_10, float_10, Math2.UpdateClass(num4 + num6));
				waypoint4.Latitude = double_10;
				waypoint3.Longitude = double_9;
			}
			if (Information.IsNothing(aircraft_0) || !aircraft_0.IsHelicopter)
			{
				Aircraft object_5 = aircraft_0;
				waypoint_ = (flight = flight_0).FlightPlan;
				double latitude2 = geoPoint.Latitude;
				double longitude2 = geoPoint.Longitude;
				AircraftMissionProfile aircraftMissionProfile_6 = aircraftMissionProfile;
				formation_ = Waypoint.Formation.Spread;
				CheckTokenizer(null, object_5, ref waypoint_, latitude2, longitude2, aircraftMissionProfile_6, ref float_7, ref float_8, ref bool_7, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_DownOnly);
				flight.FlightPlan = waypoint_;
			}
			Aircraft object_6 = aircraft_0;
			waypoint_ = (flight = flight_0).FlightPlan;
			double latitude3 = geoPoint3.Latitude;
			double longitude3 = geoPoint3.Longitude;
			AircraftMissionProfile object_7 = aircraftMissionProfile;
			formation_ = Waypoint.Formation.Spread;
			InterruptTokenizer(null, object_6, ref waypoint_, latitude3, longitude3, object_7, ref float_7, ref float_8, ref bool_7, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.StandardRateTurn);
			flight.FlightPlan = waypoint_;
			CloneTokenizer(ref scenario_0, ref mission_0, flight_0.FlightPlan, bool_3, ref bool_6);
			if (bool_6)
			{
				if (Information.IsNothing(aircraft_0))
				{
					if (Information.IsNothing(flight_0.NotificationList))
					{
						flight_0.NotificationList = new List<string>();
					}
					flight_0.NotificationList.Add("任务" + mission_0.Name + "有一个允许空对空加油（AAR）的条令设置。但是，在给定武器挂载和飞行剖面的情况下，到目标的距离短于飞机的最大作战半径。因此，此编队计划中的所有航路点都禁用AAR。");
				}
				else if (Information.IsNothing(aircraft_0.Loadout))
				{
					if (Information.IsNothing(flight_0.NotificationList))
					{
						flight_0.NotificationList = new List<string>();
					}
					flight_0.NotificationList.Add(aircraft_0.UnitClass + "在任务中没有指定挂载" + mission_0.Name + "有一个允许空对空加油（AAR）的条令设置。但是，在给定武器挂载和飞行剖面的情况下，到目标的距离短于飞机的最大作战半径。因此，此编队计划中的所有航路点都禁用AAR。");
				}
				else
				{
					if (Information.IsNothing(flight_0.NotificationList))
					{
						flight_0.NotificationList = new List<string>();
					}
					flight_0.NotificationList.Add(aircraft_0.UnitClass + "与挂载" + aircraft_0.Loadout.Name + "在任务上" + mission_0.Name + "有一个允许空对空加油（AAR）的条令设置。但是，在给定武器挂载和飞行剖面的情况下，到目标的距离短于飞机的最大作战半径。因此，此编队计划中的所有航路点都禁用AAR。");
				}
			}
			Scenario scenario_ = scenario_0;
			Mission strike_ = mission_0;
			Aircraft object_8 = aircraft_0;
			Mission.Flight flight_ = flight_0;
			waypoint_ = (flight = flight_0).FlightPlan;
			float float_2 = 0f;
			ConnectTokenizer(scenario_, strike_, object_8, flight_, ref waypoint_, ref float_0, ref float_2, bool_0: true, bool_1: true, bool_2: true, bool_3: true, bool_4: true, bool_5: true, bool_6: false, 0f, 0f, (Misc.TurnDirection)0, false, bool_2, bool_8: false, nullable_1, nullable_2, bool_5);
			flight.FlightPlan = waypoint_;
			string_0 = "";
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal static float AssetValue(ActiveUnit_AI.AircraftAltitudePreset aircraftAltitudePreset_0)
	{
		if (1 == 0)
		{
		}
		float result = aircraftAltitudePreset_0 switch
		{
			ActiveUnit_AI.AircraftAltitudePreset.MinAltitude => 6.096f, 
			ActiveUnit_AI.AircraftAltitudePreset.Low1000 => 304.8f, 
			ActiveUnit_AI.AircraftAltitudePreset.Low2000 => 609.6f, 
			ActiveUnit_AI.AircraftAltitudePreset.const_4 => 3657.6f, 
			ActiveUnit_AI.AircraftAltitudePreset.const_5 => 7620f, 
			ActiveUnit_AI.AircraftAltitudePreset.const_6 => 10972.8f, 
			ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude => 200000f, 
			_ => 0f, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static bool GenerateFlightPlan_Station(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Aircraft aircraft_0, bool? nullable_0, ref bool bool_0, bool bool_1, bool bool_2, ref float float_0, ref string string_0, bool bool_3, bool bool_4, float float_1, double double_0, double double_1, double double_2, double double_3, Waypoint.WaypointType waypointType_0, Waypoint.TurnRateCategory turnRateCategory_0, bool bool_5, DateTime? nullable_1, DateTime? nullable_2, bool bool_6)
	{
		if (Information.IsNothing(mission_0))
		{
			string_0 = "飞机的指定任务不存在。没有创建飞行计划。";
			return false;
		}
		try
		{
			if (!Information.IsNothing(aircraft_0.Loadout) && !Information.IsNothing(aircraft_0.Loadout.GetMissionProfile(scenario_0)))
			{
				float float_2 = 0.2f;
				AircraftMissionProfile aircraftMissionProfile_ = aircraft_0.Loadout.GetMissionProfile(scenario_0);
				float float_3 = GameGeneral.LockRandom_0.Next(-45, 45);
				bool bool_7 = false;
				float float_4 = 0f;
				bool bool_8 = false;
				if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() == 0)
				{
					if (mission_0.GetType() == typeof(SupportMission))
					{
						aircraftMissionProfile_.StationAltitude = AssetValue(((SupportMission)mission_0).StationAltitude_Preset.Value);
						if (((SupportMission)mission_0).TransitAltitude_Preset.HasValue)
						{
							aircraftMissionProfile_.CruiseAtOptimumAltitude = false;
							aircraftMissionProfile_.CruiseAltitudeIngress = AssetValue(((SupportMission)mission_0).TransitAltitude_Preset.Value);
							aircraftMissionProfile_.CruiseAltitudeEgress = AssetValue(((SupportMission)mission_0).TransitAltitude_Preset.Value);
						}
					}
					else if (mission_0.GetType() == typeof(EscortMission))
					{
						if (((EscortMission)mission_0).TransitAltitude_Aircraft.HasValue)
						{
							aircraftMissionProfile_.CruiseAtOptimumAltitude = false;
							aircraftMissionProfile_.CruiseAltitudeIngress = ((EscortMission)mission_0).TransitAltitude_Aircraft.Value;
							aircraftMissionProfile_.CruiseAltitudeEgress = ((EscortMission)mission_0).TransitAltitude_Aircraft.Value;
						}
					}
					else if (mission_0.GetType() == typeof(Patrol))
					{
						aircraftMissionProfile_.StationAltitude = AssetValue(((Patrol)mission_0).StationAltitude_Preset.Value);
						if (((Patrol)mission_0).TransitAltitude_Preset.HasValue)
						{
							aircraftMissionProfile_.CruiseAtOptimumAltitude = false;
							aircraftMissionProfile_.CruiseAltitudeIngress = AssetValue(((Patrol)mission_0).TransitAltitude_Preset.Value);
							aircraftMissionProfile_.CruiseAltitudeEgress = AssetValue(((Patrol)mission_0).TransitAltitude_Preset.Value);
						}
					}
					else if (mission_0.GetType() == typeof(FerryMission))
					{
						aircraftMissionProfile_.StationAltitude = ((FerryMission)mission_0).FerryAltitude_Aircraft.Value;
						if (((FerryMission)mission_0).FerryAltitude_Aircraft.HasValue)
						{
							aircraftMissionProfile_.CruiseAtOptimumAltitude = false;
							aircraftMissionProfile_.CruiseAltitudeIngress = ((FerryMission)mission_0).FerryAltitude_Aircraft.Value;
							aircraftMissionProfile_.CruiseAltitudeEgress = ((FerryMission)mission_0).FerryAltitude_Aircraft.Value;
						}
					}
					GeoPoint geoPoint_ = DefineValue(ref scenario_0, ref flight_0, ref aircraft_0);
					GeoPoint geoPoint_2 = PublishValue(ref scenario_0, ref flight_0, ref aircraft_0);
					GeoPoint geoPoint_3 = AwakeValue(ref scenario_0, ref flight_0, ref aircraft_0);
					PrintValue(ref scenario_0, ref side_0, ref mission_0, ref flight_0, ref aircraft_0, double_0, double_1, double_2, double_3, ref geoPoint_2, ref geoPoint_, ref geoPoint_3, ref float_4, ref float_2, ref aircraftMissionProfile_, ref bool_8, ref bool_2, float_1, ref string_0, nullable_0, bool_4, ref float_0, ref float_3, waypointType_0, turnRateCategory_0, ref bool_7, nullable_1, nullable_2, bool_6);
				}
				if (!bool_0)
				{
					if (bool_8)
					{
						Mission.Flight flight;
						Waypoint[] waypoint_ = (flight = flight_0).FlightPlan;
						bool num = ResolveValue(ref scenario_0, ref waypoint_, bool_5);
						flight.FlightPlan = waypoint_;
						if (num)
						{
							waypoint_ = (flight = flight_0).FlightPlan;
							bool num2 = SortValue(ref scenario_0, ref side_0, ref mission_0, ref aircraft_0, ref waypoint_, float_2, bool_0: false);
							flight.FlightPlan = waypoint_;
							if (num2)
							{
								return false;
							}
							Scenario scenario_ = scenario_0;
							Mission strike_ = mission_0;
							Aircraft object_ = aircraft_0;
							Mission.Flight flight_ = flight_0;
							waypoint_ = (flight = flight_0).FlightPlan;
							ConnectTokenizer(scenario_, strike_, object_, flight_, ref waypoint_, ref float_0, ref float_4, bool_0: false, !bool_2, bool_2: false, bool_3: false, bool_4: true, bool_5: false, bool_6: true, 0f, 0f, (Misc.TurnDirection)0, false, bool_2, bool_8: false, nullable_1, nullable_2, bool_6);
							flight.FlightPlan = waypoint_;
							if (bool_7)
							{
								if (Information.IsNothing(flight_0.NotificationList))
								{
									flight_0.NotificationList = new List<string>();
								}
								flight_0.NotificationList.Add(aircraft_0.UnitClass + "与挂载" + aircraft_0.Loadout.Name + "在任务上" + mission_0.Name + "有一个允许空对空加油（AAR）的条令设置。但是，在给定武器挂载和飞行剖面的情况下，到目标的距离短于飞机的最大作战半径。因此，此编队计划中的所有航路点都禁用AAR。");
							}
							return true;
						}
						flight_0.ClearFlightPlan();
						flight_0.FlightCannotLaunch = true;
						string_0 = "起飞时间将在过去。没有生成飞行计划。";
						return false;
					}
					string_0 = "等待路径查找器在禁航区域周围创建飞行计划。";
					return false;
				}
				if ((bool_8 || flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0) && side_0.NoNavZones.Count > 0)
				{
					Waypoint[] waypoint_2;
					Mission.Flight flight2;
					if (bool_8)
					{
						waypoint_2 = (flight2 = flight_0).FlightPlan;
						bool num3 = ResolveValue(ref scenario_0, ref waypoint_2, bool_5);
						flight2.FlightPlan = waypoint_2;
						if (!num3)
						{
							flight_0.ClearFlightPlan();
							flight_0.FlightCannotLaunch = true;
							string_0 = "起飞时间将在过去。没有生成飞行计划。";
							return false;
						}
					}
					waypoint_2 = (flight2 = flight_0).FlightPlan;
					SortValue(ref scenario_0, ref side_0, ref mission_0, ref aircraft_0, ref waypoint_2, float_2, bool_0: true);
					flight2.FlightPlan = waypoint_2;
					if (flight_0.FlightPlan.Count() == 0 || flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
					{
						ActiveUnit activeUnit_ = flight_0.GetReferenceUnit(scenario_0);
						Aircraft aircraft_ = null;
						if (flight_0.GetReferenceUnit(scenario_0).IsAircraft)
						{
							aircraft_ = (Aircraft)flight_0.GetReferenceUnit(scenario_0);
						}
						GeoPoint geoPoint_4 = DefineValue(ref scenario_0, ref flight_0, ref aircraft_0);
						GeoPoint geoPoint_5 = PublishValue(ref scenario_0, ref flight_0, ref aircraft_0);
						GeoPoint geoPoint_6 = AwakeValue(ref scenario_0, ref flight_0, ref aircraft_0);
						if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() == 0)
						{
							if (!(bool_2 || bool_3))
							{
								Mission.Flight obj = flight_0;
								waypoint_2 = obj.FlightPlan_Pathfinder_Ingress_1;
								ArrayExtensions.Clear(ref waypoint_2);
								obj.FlightPlan_Pathfinder_Ingress_1 = waypoint_2;
								Mission.Flight obj2 = flight_0;
								waypoint_2 = obj2.FlightPlan_Pathfinder_Egress_1;
								ArrayExtensions.Clear(ref waypoint_2);
								obj2.FlightPlan_Pathfinder_Egress_1 = waypoint_2;
								flight_0.Pathfinder_Ingress_RequestBeingProcessed = true;
								flight_0.PathfinderRequestBeingProcessed_OnThisPulse = true;
								aircraft_0.Navigator.TriggerPathfinderThread(null, null, flight_0, bool_1: true, float_2, double_0, double_1, scenario_0, bool_2: false);
								if (bool_1 && !Information.IsNothing(flight_0.PrimaryTarget))
								{
									flight_0.Pathfinder_Egress_RequestBeingProcessed = true;
									aircraft_0.Navigator.TriggerPathfinderThread(null, null, flight_0, bool_1: false, float_2, geoPoint_4.Latitude, geoPoint_4.Longitude, scenario_0, bool_2: false);
								}
								return true;
							}
							if (Information.IsNothing(_ProxyConsumer))
							{
								if (Interaction.MsgBox("攻击计划者无法为其制定直达航线计划" + aircraft_.Name + "由于导航区域的存在。您是否希望寻路算法尝试寻找路线？这可能会需要几分钟。请注意，寻路算法不允许飞机在任何禁航区域内飞行超过0.2度（赤道12海里）。", MsgBoxStyle.YesNo, "尝试在禁航区域周围寻路？") == MsgBoxResult.Yes)
								{
									_ProxyConsumer = true;
								}
								else
								{
									_ProxyConsumer = false;
								}
							}
							if (!_ProxyConsumer.GetValueOrDefault())
							{
								string_0 = "探路者不允许为飞行计划创建出口航段。没有创建飞行计划。请注意，探路者不允许飞机在任何禁航区域内飞行超过0.2度（赤道12海里）。";
								return false;
							}
							flight_0.GetReferenceUnit(scenario_0).Navigator.StartPathfinding(null, null, flight_0, bool_1: true, float_2, double_0, double_1, scenario_0, bool_2: false);
							if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() <= 0)
							{
								string_0 = "无法为飞行计划创建入口航段。请注意，探路者不允许飞机在任何禁航区域内飞行超过0.2度（赤道12海里）。";
								return false;
							}
							if (bool_2)
							{
								flight_0.GetReferenceUnit(scenario_0).Navigator.StartPathfinding(flight_0.FlightPlan_Pathfinder_Ingress_1[flight_0.FlightPlan_Pathfinder_Ingress_1.Count() - 1], null, flight_0, bool_1: false, float_2, geoPoint_4.Latitude, geoPoint_4.Longitude, scenario_0, bool_2: false);
								if (flight_0.FlightPlan_Pathfinder_Egress_1.Count() == 0)
								{
									string_0 = "无法为飞行计划创建出口航段。请注意，探路者不允许飞机在任何禁航区域内飞行超过0.2度（赤道12海里）。";
									return false;
								}
							}
						}
						if (flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
						{
							Mission._RadarBehaviour _RadarBehaviour_ = Mission._RadarBehaviour.None;
							Waypoint.Formation formation_ = Waypoint.Formation.Spread;
							Misc.TurnDirection turnDirection_ = (Misc.TurnDirection)0;
							return PostValue(ref scenario_0, ref side_0, ref mission_0, ref flight_0, ref aircraft_0, ref nullable_0, ref string_0, ref _RadarBehaviour_, bool_2, ref float_0, ref activeUnit_, ref aircraft_, ref geoPoint_5, ref geoPoint_4, ref geoPoint_6, ref aircraftMissionProfile_, ref formation_, ref float_3, ref turnDirection_, ref float_2, ref float_4, bool_4, double_0, double_1, double_2, double_3, waypointType_0, turnRateCategory_0, bool_5, nullable_1, nullable_2, bool_6);
						}
						if (bool_8)
						{
							waypoint_2 = (flight2 = flight_0).FlightPlan;
							bool num4 = ResolveValue(ref scenario_0, ref waypoint_2, bool_5);
							flight2.FlightPlan = waypoint_2;
							if (num4)
							{
								Scenario scenario_2 = scenario_0;
								Mission strike_2 = mission_0;
								Aircraft object_2 = aircraft_0;
								Mission.Flight flight_2 = flight_0;
								waypoint_2 = (flight2 = flight_0).FlightPlan;
								ConnectTokenizer(scenario_2, strike_2, object_2, flight_2, ref waypoint_2, ref float_0, ref float_4, bool_0: false, !bool_2, bool_2: false, bool_3: false, bool_4: true, bool_5: false, bool_6: true, 0f, 0f, (Misc.TurnDirection)0, false, bool_2, bool_8: false, null, null, bool_9: true);
								flight2.FlightPlan = waypoint_2;
								if (bool_7)
								{
									if (Information.IsNothing(flight_0.NotificationList))
									{
										flight_0.NotificationList = new List<string>();
									}
									flight_0.NotificationList.Add(aircraft_0.UnitClass + "与挂载" + aircraft_0.Loadout.Name + "在任务上" + mission_0.Name + "有一个允许空对空加油（AAR）的条令设置。但是，在给定武器挂载和飞行剖面的情况下，到目标的距离短于飞机的最大作战半径。因此，此编队计划中的所有航路点都禁用AAR。");
								}
								return true;
							}
							flight_0.ClearFlightPlan();
							flight_0.FlightCannotLaunch = true;
							string_0 = "起飞时间将在过去。没有生成飞行计划。";
							return false;
						}
					}
				}
				if (bool_8)
				{
					Mission.Flight flight3;
					Waypoint[] waypoint_3 = (flight3 = flight_0).FlightPlan;
					bool num5 = ResolveValue(ref scenario_0, ref waypoint_3, bool_5);
					flight3.FlightPlan = waypoint_3;
					if (num5)
					{
						Scenario scenario_3 = scenario_0;
						Mission strike_3 = mission_0;
						Aircraft object_3 = aircraft_0;
						Mission.Flight flight_3 = flight_0;
						waypoint_3 = (flight3 = flight_0).FlightPlan;
						ConnectTokenizer(scenario_3, strike_3, object_3, flight_3, ref waypoint_3, ref float_0, ref float_4, bool_0: false, !bool_2, bool_2: false, bool_3: false, bool_4: true, bool_5: false, bool_6: true, 0f, 0f, (Misc.TurnDirection)0, false, bool_2, bool_8: false, null, null, bool_6);
						flight3.FlightPlan = waypoint_3;
						if (bool_7)
						{
							if (Information.IsNothing(flight_0.NotificationList))
							{
								flight_0.NotificationList = new List<string>();
							}
							flight_0.NotificationList.Add(aircraft_0.UnitClass + "与挂载" + aircraft_0.Loadout.Name + "在任务上" + mission_0.Name + "有一个允许空对空加油（AAR）的条令设置。但是，在给定武器挂载和飞行剖面的情况下，到目标的距离短于飞机的最大作战半径。因此，此编队计划中的所有航路点都禁用AAR。");
						}
						return true;
					}
					flight_0.ClearFlightPlan();
					flight_0.FlightCannotLaunch = true;
					string_0 = "起飞时间将在过去。没有生成飞行计划。";
					return false;
				}
			}
			if (string.IsNullOrEmpty(string_0))
			{
				string_0 = "不能生成飞行计划。原因未知。";
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static void PrintValue(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Aircraft aircraft_0, double double_0, double double_1, double double_2, double double_3, ref GeoPoint geoPoint_0, ref GeoPoint geoPoint_1, ref GeoPoint geoPoint_2, ref float float_0, ref float float_1, ref AircraftMissionProfile aircraftMissionProfile_0, ref bool bool_0, ref bool bool_1, float float_2, ref string string_0, bool? nullable_0, bool bool_2, ref float float_3, ref float float_4, Waypoint.WaypointType waypointType_0, Waypoint.TurnRateCategory turnRateCategory_0, ref bool bool_3, DateTime? nullable_1, DateTime? nullable_2, bool bool_4)
	{
		try
		{
			flight_0.HasCriticalError = false;
			side_0.Units.ToList();
			flight_0.ClearFlightPlan();
			float num = (bool_1 ? Math2.PublishClass(aircraft_0.GetLatitude(), aircraft_0.GetLongitude(), double_0, double_1) : Math2.PublishClass(geoPoint_0.Latitude, geoPoint_0.Longitude, double_0, double_1));
			int num3 = 0;
			float float_6;
			if (aircraftMissionProfile_0.FormUpTime < 2)
			{
				float_6 = 10f;
			}
			else
			{
				float num4 = aircraft_0.Kinematics.GetMaximumSpeed(aircraftMissionProfile_0.FormUpAltitude * 0.3048f, ActiveUnit.Throttle.Loiter, bool_0: false);
				num3 = 2;
				float_6 = num4 * 2f / 60f;
			}
			int num5 = aircraftMissionProfile_0.FormUpTime - num3;
			Aircraft object_ = aircraft_0;
			Mission.Flight flight;
			Waypoint[] waypoint_ = (flight = flight_0).FlightPlan;
			double latitude = geoPoint_0.Latitude;
			double longitude = geoPoint_0.Longitude;
			AircraftMissionProfile aircraftMissionProfile_ = aircraftMissionProfile_0;
			Waypoint.Formation formation_ = Waypoint.Formation.Spread;
			float float_7 = 0f;
			float float_8 = 0f;
			bool bool_5 = false;
			ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_ = ActiveUnit_Kinematics.UnitThrottlePreset.FullStop;
			float float_9 = 0f;
			ConcatTokenizer(null, object_, ref waypoint_, latitude, longitude, aircraftMissionProfile_, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.StandardRateTurn);
			flight.FlightPlan = waypoint_;
			double double_18 = 0.0;
			double double_19 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(geoPoint_0.Longitude, geoPoint_0.Latitude, ref double_18, ref double_19, float_6, Math2.UpdateClass(num + float_4));
			Waypoint waypoint = null;
			if (aircraft_0.IsHelicopter)
			{
				Aircraft aircraft_ = aircraft_0;
				waypoint_ = (flight = flight_0).FlightPlan;
				double double_20 = double_19;
				double double_21 = double_18;
				AircraftMissionProfile aircraftMissionProfile_2 = aircraftMissionProfile_0;
				formation_ = Waypoint.Formation.Spread;
				WriteTokenizer(null, aircraft_, ref waypoint_, double_20, double_21, aircraftMissionProfile_2, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
				flight.FlightPlan = waypoint_;
			}
			else if (num5 <= 0)
			{
				Aircraft aircraft_2 = aircraft_0;
				waypoint_ = (flight = flight_0).FlightPlan;
				double double_22 = double_19;
				double double_23 = double_18;
				AircraftMissionProfile aircraftMissionProfile_3 = aircraftMissionProfile_0;
				formation_ = Waypoint.Formation.Spread;
				WriteTokenizer(null, aircraft_2, ref waypoint_, double_22, double_23, aircraftMissionProfile_3, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
				flight.FlightPlan = waypoint_;
			}
			else
			{
				Aircraft object_5 = aircraft_0;
				waypoint_ = (flight = flight_0).FlightPlan;
				double double_4 = double_19;
				double double_5 = double_18;
				AircraftMissionProfile aircraftMissionProfile_4 = aircraftMissionProfile_0;
				formation_ = Waypoint.Formation.Spread;
				NewTokenizer(null, object_5, ref waypoint_, double_4, double_5, aircraftMissionProfile_4, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.StandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
				flight.FlightPlan = waypoint_;
				Aircraft aircraft_3 = aircraft_0;
				waypoint_ = (flight = flight_0).FlightPlan;
				double double_6 = double_19;
				double double_7 = double_18;
				AircraftMissionProfile aircraftMissionProfile_5 = aircraftMissionProfile_0;
				formation_ = Waypoint.Formation.Spread;
				bool bool_6 = true;
				Waypoint waypoint2 = PushTokenizer(null, aircraft_3, ref waypoint_, double_6, double_7, aircraftMissionProfile_5, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, ref mission_0, ref bool_6, num5);
				flight.FlightPlan = waypoint_;
				waypoint = waypoint2;
			}
			double double_8 = 0.0;
			double double_9 = 0.0;
			float num6;
			if (bool_1)
			{
				Waypoint waypoint3 = new Waypoint(aircraft_0.GetLongitude(), aircraft_0.GetLatitude(), 0f, Waypoint.WaypointType.StrikeIngress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
				Mission.Flight obj = flight_0;
				waypoint_ = obj.FlightPlan;
				ArrayExtensions.Add(ref waypoint_, waypoint3);
				obj.FlightPlan = waypoint_;
				Aircraft object_6 = aircraft_0;
				waypoint_ = (flight = flight_0).FlightPlan;
				double latitude2 = aircraft_0.GetLatitude();
				double longitude2 = aircraft_0.GetLongitude();
				AircraftMissionProfile object_7 = aircraftMissionProfile_0;
				formation_ = Waypoint.Formation.Spread;
				FillTokenizer(waypoint3, object_6, ref waypoint_, latitude2, longitude2, object_7, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, null, Waypoint.SpeedToT.Yes_DownOnly);
				flight.FlightPlan = waypoint_;
				num6 = Math2.PublishClass(aircraft_0.GetLatitude(), aircraft_0.GetLongitude(), double_0, double_1);
				Math2.PublishClass(double_0, double_1, aircraft_0.GetLatitude(), aircraft_0.GetLongitude());
			}
			else
			{
				num6 = Math2.PublishClass(double_19, double_18, double_0, double_1);
				Math2.PublishClass(double_0, double_1, double_19, double_18);
				float num7 = Math2.VerifyClass(double_19, double_18, double_0, double_1);
				Geodesic_EdWilliams.CalcPoint_Williams(double_18, double_19, ref double_8, ref double_9, num7 / 2f, num6);
				Aircraft object_8 = aircraft_0;
				waypoint_ = (flight = flight_0).FlightPlan;
				double double_10 = double_9;
				double double_11 = double_8;
				AircraftMissionProfile object_9 = aircraftMissionProfile_0;
				formation_ = Waypoint.Formation.Spread;
				FillTokenizer(null, object_8, ref waypoint_, double_10, double_11, object_9, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, null, Waypoint.SpeedToT.Yes_DownOnly);
				flight.FlightPlan = waypoint_;
			}
			if (!aircraft_0.IsHelicopter && !Information.IsNothing(waypoint))
			{
				float num8 = Math2.VerifyClass(double_19, double_18, flight_0.FlightPlan[3].Latitude, flight_0.FlightPlan[3].Longitude);
				float num9 = 0f;
				float float_10;
				if (num8 < 20f)
				{
					num9 = 90f;
					float_10 = 15f;
				}
				else
				{
					float_10 = ((num8 < 30f) ? (num8 / 2f) : 15f);
				}
				double double_12 = double_18;
				double double_13 = double_19;
				Waypoint waypoint4;
				double double_14 = (waypoint4 = waypoint).Longitude;
				Waypoint waypoint5 = waypoint;
				double double_15 = waypoint5.Latitude;
				Geodesic_EdWilliams.CalcPoint_Williams(double_12, double_13, ref double_14, ref double_15, float_10, Math2.UpdateClass(num6 + num9));
				waypoint5.Latitude = double_15;
				waypoint4.Longitude = double_14;
			}
			Aircraft aircraft_4 = aircraft_0;
			waypoint_ = (flight = flight_0).FlightPlan;
			AircraftMissionProfile aircraftMissionProfile_6 = aircraftMissionProfile_0;
			formation_ = Waypoint.Formation.Spread;
			CalculateTokenizer(null, aircraft_4, ref waypoint_, double_0, double_1, aircraftMissionProfile_6, Mission._RadarBehaviour.None, waypointType_0, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_, turnRateCategory_0, Waypoint.SpeedToT.Yes_DownOnly, flight_0);
			flight.FlightPlan = waypoint_;
			Aircraft aircraft_5 = aircraft_0;
			waypoint_ = (flight = flight_0).FlightPlan;
			AircraftMissionProfile aircraftMissionProfile_7 = aircraftMissionProfile_0;
			formation_ = Waypoint.Formation.Spread;
			PopTokenizer(null, aircraft_5, ref waypoint_, double_2, double_3, aircraftMissionProfile_7, Mission._RadarBehaviour.None, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn);
			flight.FlightPlan = waypoint_;
			Math2.PublishClass(double_0, double_1, geoPoint_1.Latitude, geoPoint_1.Longitude);
			float float_5 = Math2.PublishClass(geoPoint_1.Latitude, geoPoint_1.Longitude, double_0, double_1);
			float num10 = Math2.VerifyClass(geoPoint_1.Latitude, geoPoint_1.Longitude, double_2, double_3);
			Geodesic_EdWilliams.CalcPoint_Williams(geoPoint_1.Longitude, geoPoint_1.Latitude, ref double_8, ref double_9, num10 / 2f, float_5);
			Aircraft object_10 = aircraft_0;
			waypoint_ = (flight = flight_0).FlightPlan;
			double double_16 = double_9;
			double double_17 = double_8;
			AircraftMissionProfile object_11 = aircraftMissionProfile_0;
			formation_ = Waypoint.Formation.Spread;
			FillTokenizer(null, object_10, ref waypoint_, double_16, double_17, object_11, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, null, Waypoint.SpeedToT.Yes_DownOnly);
			flight.FlightPlan = waypoint_;
			if (!aircraft_0.IsHelicopter)
			{
				Aircraft object_12 = aircraft_0;
				waypoint_ = (flight = flight_0).FlightPlan;
				double latitude3 = geoPoint_1.Latitude;
				double longitude3 = geoPoint_1.Longitude;
				AircraftMissionProfile aircraftMissionProfile_8 = aircraftMissionProfile_0;
				formation_ = Waypoint.Formation.Spread;
				CheckTokenizer(null, object_12, ref waypoint_, latitude3, longitude3, aircraftMissionProfile_8, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_DownOnly);
				flight.FlightPlan = waypoint_;
			}
			Aircraft object_2 = aircraft_0;
			waypoint_ = (flight = flight_0).FlightPlan;
			double latitude4 = geoPoint_2.Latitude;
			double longitude4 = geoPoint_2.Longitude;
			AircraftMissionProfile object_3 = aircraftMissionProfile_0;
			formation_ = Waypoint.Formation.Spread;
			InterruptTokenizer(null, object_2, ref waypoint_, latitude4, longitude4, object_3, ref float_7, ref float_8, ref bool_5, ref unitThrottlePreset_, ref float_9, ref formation_, Waypoint.TurnRateCategory.StandardRateTurn);
			flight.FlightPlan = waypoint_;
			CloneTokenizer(ref scenario_0, ref mission_0, flight_0.FlightPlan, bool_2, ref bool_3);
			Scenario scenario_ = scenario_0;
			Mission strike_ = mission_0;
			Aircraft object_4 = aircraft_0;
			Mission.Flight flight_ = flight_0;
			waypoint_ = (flight = flight_0).FlightPlan;
			bool num2 = ConnectTokenizer(scenario_, strike_, object_4, flight_, ref waypoint_, ref float_3, ref float_0, bool_0: true, bool_1: false, bool_2: true, bool_3: true, bool_4: true, bool_5: true, bool_6: false, 0f, 0f, (Misc.TurnDirection)0, false, bool_1, bool_8: false, nullable_1, nullable_2, bool_4);
			flight.FlightPlan = waypoint_;
			if (!num2)
			{
				bool? flag = nullable_0;
				flag = flag;
				if (!flag.GetValueOrDefault())
				{
					string_0 = "Station is within maximum strike radius, however the currently selected flight profile requires too much fuel.";
					if (Information.IsNothing(nullable_0))
					{
						Aircraft_Navigator navigator = aircraft_0.Navigator;
						bool bool_7 = false;
						float value = navigator.OrderProxy(ref bool_7);
						nullable_0 = aircraft_0.AI.WriteClient(double_0, double_1, aircraft_0.Loadout.CombatRadius, value);
					}
					if (Information.IsNothing(nullable_0) || ((!nullable_0) ?? nullable_0).GetValueOrDefault())
					{
						flight_0.ClearFlightPlan();
					}
					return;
				}
			}
			bool_0 = true;
			string_0 = "";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static GeoPoint DefineValue(ref Scenario scenario_0, ref Mission.Flight flight_0, ref Aircraft aircraft_0)
	{
		try
		{
			if (!Information.IsNothing(flight_0) && !Information.IsNothing(aircraft_0))
			{
				string landingLocation_HostUnitObjectID = flight_0.LandingLocation_HostUnitObjectID;
				if (!string.IsNullOrEmpty(landingLocation_HostUnitObjectID))
				{
					Aircraft_AirOps airOps = aircraft_0.AirOps;
					if (!Information.IsNothing(airOps.ActualDestinationHost) && Operators.CompareString(airOps.ActualDestinationHost.ObjectID, landingLocation_HostUnitObjectID, TextCompare: false) != 0 && scenario_0.ActiveUnits.ContainsKey(landingLocation_HostUnitObjectID))
					{
						ActiveUnit activeUnit = scenario_0.ActiveUnits[landingLocation_HostUnitObjectID];
						return new GeoPoint(activeUnit.AirOps.LandingQueueAssemblyPoint.Longitude, activeUnit.AirOps.LandingQueueAssemblyPoint.Latitude);
					}
				}
			}
			if (Information.IsNothing(aircraft_0))
			{
				if (Information.IsNothing(flight_0))
				{
					GameGeneral.ResolveBridge("未设置飞机类型并且不存在飞行编队，因此无法找到飞行编队的着陆集结点！", aircraft_0.GetUnitSide());
				}
				else
				{
					string landingLocation_HostUnitObjectID2 = flight_0.LandingLocation_HostUnitObjectID;
					if (!string.IsNullOrEmpty(landingLocation_HostUnitObjectID2) && scenario_0.ActiveUnits.ContainsKey(landingLocation_HostUnitObjectID2))
					{
						ActiveUnit activeUnit2 = scenario_0.ActiveUnits[landingLocation_HostUnitObjectID2];
						return new GeoPoint(activeUnit2.AirOps.LandingQueueAssemblyPoint.Longitude, activeUnit2.AirOps.LandingQueueAssemblyPoint.Latitude);
					}
					GameGeneral.ResolveBridge("无法找到飞行编队的着陆集结点" + flight_0.Callsign + ".", aircraft_0.GetUnitSide());
				}
				return null;
			}
			Aircraft_AirOps airOps2 = aircraft_0.AirOps;
			if (aircraft_0.IsHelicopter)
			{
				if (Information.IsNothing(airOps2.ActualDestinationHost))
				{
					return new GeoPoint(aircraft_0.GetLongitude(), aircraft_0.GetLatitude());
				}
				return new GeoPoint(airOps2.ActualDestinationHost.GetLongitude(), airOps2.ActualDestinationHost.GetLatitude());
			}
			if (Information.IsNothing(airOps2.ActualDestinationHost))
			{
				return new GeoPoint(aircraft_0.GetLongitude(), aircraft_0.GetLatitude());
			}
			return airOps2.ActualDestinationHost.AirOps.LandingQueueAssemblyPoint.DisableInvocation();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static GeoPoint PublishValue(ref Scenario scenario_0, ref Mission.Flight flight_0, ref Aircraft aircraft_0)
	{
		try
		{
			if (Information.IsNothing(aircraft_0))
			{
				if (Information.IsNothing(flight_0))
				{
					GameGeneral.ResolveBridge("未设置飞机类型并且不存在飞行编队，因此无法找到飞行编队的起飞位置！", aircraft_0.GetUnitSide());
				}
				else
				{
					string takeOffLocation_HostUnitObjectID = flight_0.TakeOffLocation_HostUnitObjectID;
					if (!string.IsNullOrEmpty(takeOffLocation_HostUnitObjectID) && scenario_0.ActiveUnits.ContainsKey(takeOffLocation_HostUnitObjectID))
					{
						ActiveUnit activeUnit = scenario_0.ActiveUnits[takeOffLocation_HostUnitObjectID];
						return new GeoPoint(activeUnit.GetLongitude(), activeUnit.GetLatitude());
					}
					GameGeneral.ResolveBridge("找不到起飞的起飞地点" + flight_0.Callsign + ".", aircraft_0.GetUnitSide());
				}
			}
			else
			{
				Aircraft_AirOps airOps = aircraft_0.AirOps;
				if (!Information.IsNothing(aircraft_0.AirOps.GetAssignedHostUnit()))
				{
					return new GeoPoint(aircraft_0.AirOps.GetAssignedHostUnit().GetLongitude(), aircraft_0.AirOps.GetAssignedHostUnit().GetLatitude());
				}
				if (!Information.IsNothing(airOps.ActualDestinationHost))
				{
					return new GeoPoint(airOps.ActualDestinationHost.GetLongitude(), airOps.ActualDestinationHost.GetLatitude());
				}
			}
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static GeoPoint AwakeValue(ref Scenario scenario_0, ref Mission.Flight flight_0, ref Aircraft aircraft_0)
	{
		try
		{
			if (!Information.IsNothing(flight_0) && !Information.IsNothing(aircraft_0))
			{
				string landingLocation_HostUnitObjectID = flight_0.LandingLocation_HostUnitObjectID;
				if (!string.IsNullOrEmpty(landingLocation_HostUnitObjectID))
				{
					Aircraft_AirOps airOps = aircraft_0.AirOps;
					if (!Information.IsNothing(airOps.ActualDestinationHost) && Operators.CompareString(airOps.ActualDestinationHost.ObjectID, landingLocation_HostUnitObjectID, TextCompare: false) != 0 && scenario_0.ActiveUnits.ContainsKey(landingLocation_HostUnitObjectID))
					{
						ActiveUnit activeUnit = scenario_0.ActiveUnits[landingLocation_HostUnitObjectID];
						return new GeoPoint(activeUnit.GetLongitude(), activeUnit.GetLatitude());
					}
				}
			}
			if (Information.IsNothing(aircraft_0))
			{
				if (Information.IsNothing(flight_0))
				{
					GameGeneral.ResolveBridge("飞机类型未设置且编队不存在，因此无法找到编队的着陆位置！", aircraft_0?.GetUnitSide());
				}
				else
				{
					string landingLocation_HostUnitObjectID2 = flight_0.LandingLocation_HostUnitObjectID;
					if (!string.IsNullOrEmpty(landingLocation_HostUnitObjectID2) && scenario_0.ActiveUnits.ContainsKey(landingLocation_HostUnitObjectID2))
					{
						ActiveUnit activeUnit2 = scenario_0.ActiveUnits[landingLocation_HostUnitObjectID2];
						return new GeoPoint(activeUnit2.GetLongitude(), activeUnit2.GetLatitude());
					}
					GameGeneral.ResolveBridge("无法找到编队的着陆位置" + flight_0.Callsign + ".", aircraft_0?.GetUnitSide());
				}
				return null;
			}
			Aircraft_AirOps airOps2 = aircraft_0.AirOps;
			if (Information.IsNothing(airOps2.ActualDestinationHost))
			{
				return new GeoPoint(aircraft_0.GetLongitude(), aircraft_0.GetLatitude());
			}
			return new GeoPoint(airOps2.ActualDestinationHost.GetLongitude(), airOps2.ActualDestinationHost.GetLatitude());
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static void QueryValue(ref float float_0, ref float float_1, float float_2, float float_3, bool bool_0)
	{
		try
		{
			if (bool_0)
			{
				if (float_3 < 6f)
				{
					float_0 = GameGeneral.LockRandom_0.Next(-85, 85);
				}
				else if (float_3 < 15f)
				{
					float_0 = GameGeneral.LockRandom_0.Next(-65, 65);
				}
				else if (float_3 < 80f)
				{
					float_0 = GameGeneral.LockRandom_0.Next(-45, 45);
				}
				else if (float_3 < 150f)
				{
					float_0 = GameGeneral.LockRandom_0.Next(-30, 30);
				}
				else
				{
					float_0 = GameGeneral.LockRandom_0.Next(-20, 20);
				}
				if (float_0 <= 0f)
				{
					if (float_0 > -2f)
					{
						float_0 = -2f;
					}
				}
				else if (float_0 < 2f)
				{
					float_0 = 2f;
				}
				if (float_3 < 6f)
				{
					float_1 = GameGeneral.LockRandom_0.Next(-85, 85);
				}
				else if (float_3 < 15f)
				{
					if (float_0 <= 0f)
					{
						float_1 = float_0 + 5f;
					}
					else
					{
						float_1 = float_0 - 5f;
					}
				}
				else if (float_3 < 30f)
				{
					if (float_0 <= 0f)
					{
						float_1 = float_0 + 2f;
					}
					else
					{
						float_1 = float_0 - 2f;
					}
				}
				else if (float_3 < 85f)
				{
					if (float_0 <= 0f)
					{
						float_1 = float_0 + 1f;
					}
					else
					{
						float_1 = float_0 - 1f;
					}
				}
				else if (float_0 <= 0f)
				{
					float_1 = (float)((double)float_0 + 0.1);
				}
				else
				{
					float_1 = (float)((double)float_0 - 0.1);
				}
				if (float_3 < 6f)
				{
					if (float_0 * float_1 > 0f)
					{
						float_1 = 0f - float_1;
					}
				}
				else if (float_0 * float_1 <= 0f)
				{
					float_1 = 0f - float_1;
				}
			}
			else if (GameGeneral.LockRandom_0.Next(1, 2) == 1)
			{
				if (float_3 < 15f && float_2 < 500f)
				{
					float_0 = -2f;
					float_1 = 2f;
				}
				else if (float_3 < 30f && float_2 < 500f)
				{
					float_0 = -1f;
					float_1 = 1f;
				}
				else
				{
					float_0 = 0f;
					float_1 = 0f;
				}
			}
			else if (float_3 < 15f && float_2 < 500f)
			{
				float_0 = 2f;
				float_1 = -2f;
			}
			else if (float_3 < 30f && float_2 < 500f)
			{
				float_0 = 1f;
				float_1 = -1f;
			}
			else
			{
				float_0 = 0f;
				float_1 = 0f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			float_0 = 0.1f;
			float_1 = -0.1f;
			ProjectData.ClearProjectError();
		}
	}

	private static void ResetValue(ref Strike strike_0, bool bool_0, ref Misc.TurnDirection turnDirection_0, ref float float_0, double double_0, double double_1, double double_2, double double_3, ref GeoPoint geoPoint_0, bool bool_1)
	{
		if (!bool_1 && strike_0.AttackMethod == Mission._AttackMethod.BananaSplit)
		{
			if (bool_0)
			{
				turnDirection_0 = Misc.TurnDirection.TurnRight;
			}
			else
			{
				turnDirection_0 = Misc.TurnDirection.TurnLeft;
			}
		}
		else
		{
			float float_ = Math2.PublishClass(geoPoint_0.Latitude, geoPoint_0.Longitude, double_0, double_1);
			float float_2 = Math2.PublishClass(double_0, double_1, double_2, double_3);
			turnDirection_0 = Misc.CountValue(float_, float_2);
		}
		if (bool_1)
		{
			switch (turnDirection_0)
			{
			case Misc.TurnDirection.TurnRight:
				float_0 = 270f;
				break;
			case Misc.TurnDirection.TurnLeft:
				float_0 = 90f;
				break;
			}
		}
		else
		{
			switch (turnDirection_0)
			{
			case Misc.TurnDirection.TurnRight:
				float_0 = 90f;
				break;
			case Misc.TurnDirection.TurnLeft:
				float_0 = 270f;
				break;
			}
		}
	}

	private static void MapValue(ref Strike strike_0, ref Contact contact_0, ref Misc.TurnDirection turnDirection_0, ref float float_0, ref Waypoint waypoint_0, ref Waypoint waypoint_1, object object_0, ref float float_1, ref float float_2, ref float float_3, ref float float_4, float float_5, double double_0, double double_1)
	{
		if ((uint)(strike_0.AttackMethod - 5) > 5u)
		{
			return;
		}
		Waypoint waypoint;
		if (float_0 > 0f && turnDirection_0 == Misc.TurnDirection.TurnLeft)
		{
			float float_12 = Math2.VerifyClass(contact_0.GetLatitude(), contact_0.GetLongitude(), waypoint_1.Latitude, waypoint_1.Longitude);
			if (float_1 < 6f)
			{
				double longitude = contact_0.GetLongitude();
				double latitude = contact_0.GetLatitude();
				double double_2 = (waypoint = waypoint_1).Longitude;
				Waypoint obj = waypoint_1;
				double double_3 = obj.Latitude;
				Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_2, ref double_3, float_12, Math2.UpdateClass(float_3 + float_5 + float_0));
				obj.Latitude = double_3;
				waypoint.Longitude = double_2;
			}
			else
			{
				double longitude2 = contact_0.GetLongitude();
				double latitude2 = contact_0.GetLatitude();
				Waypoint waypoint2;
				double double_4 = (waypoint2 = waypoint_1).Longitude;
				double double_5 = (waypoint = waypoint_1).Latitude;
				Geodesic_EdWilliams.CalcPoint_Williams(longitude2, latitude2, ref double_4, ref double_5, float_12, Math2.UpdateClass(float_3 + float_5 + float_0));
				waypoint.Latitude = double_5;
				waypoint2.Longitude = double_4;
			}
		}
		if (Information.IsNothing(object_0) || Information.IsNothing(waypoint_1))
		{
			return;
		}
		float float_13 = Math2.PublishClass(waypoint_0.Latitude, waypoint_0.Longitude, waypoint_1.Latitude, waypoint_1.Longitude);
		List<Waypoint.FlightPlanSegment> list_ = new List<Waypoint.FlightPlanSegment>();
		bool bool_ = false;
		Waypoint waypoint_2 = new Waypoint();
		waypoint_2.Latitude = waypoint_1.Latitude;
		waypoint_2.Longitude = waypoint_1.Longitude;
		waypoint_2.TurnRate_Navigation = waypoint_1.TurnRate_Navigation;
		Waypoint waypoint_3 = new Waypoint();
		waypoint_3.Latitude = contact_0.GetLatitude();
		waypoint_3.Longitude = contact_0.GetLongitude();
		waypoint_3.TurnRate_Navigation = waypoint_1.TurnRate_Navigation;
		float num = Math2.PublishClass(waypoint_2.Latitude, waypoint_2.Longitude, waypoint_3.Latitude, waypoint_3.Longitude);
		Misc.TurnDirection turnDirection = Misc.CountValue(float_13, num);
		float float_14 = 0f;
		switch (turnDirection)
		{
		case Misc.TurnDirection.TurnRight:
			float_14 = 9f;
			break;
		case Misc.TurnDirection.TurnLeft:
			float_14 = -9f;
			break;
		}
		waypoint = null;
		float float_15 = waypoint_1.DesiredSpeed.Value;
		float value = waypoint_0.DesiredSpeed.Value;
		Mission.Flight flight_ = null;
		CreateFlightPlanCurve(ref float_13, ref list_, ref waypoint_3, ref waypoint_2, ref waypoint, ref float_15, value, ref flight_, float_14, turnDirection, num, ref bool_, bool_1: true, "", null);
		if (bool_)
		{
			float float_6 = Math2.VerifyClass(contact_0.GetLatitude(), contact_0.GetLongitude(), double_0, double_1);
			float float_7 = Math2.PublishClass(contact_0.GetLatitude(), contact_0.GetLongitude(), waypoint_1.Latitude, waypoint_1.Longitude);
			Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_1, ref double_0, float_6, float_7);
			((GeoPoint)object_0).Latitude = double_0;
			((GeoPoint)object_0).Longitude = double_1;
			return;
		}
		double startLatitude = list_[list_.Count - 1].StartLatitude;
		double startLongitude = list_[list_.Count - 1].StartLongitude;
		float num2 = Math2.VerifyClass(contact_0.GetLatitude(), contact_0.GetLongitude(), startLatitude, startLongitude);
		float float_8 = Math2.PublishClass(contact_0.GetLatitude(), contact_0.GetLongitude(), startLatitude, startLongitude);
		float float_9 = Math2.VerifyClass(contact_0.GetLatitude(), contact_0.GetLongitude(), ((GeoPoint)object_0).Latitude, ((GeoPoint)object_0).Longitude);
		if (num2 <= float_1)
		{
			float float_10 = Math2.VerifyClass(contact_0.GetLatitude(), contact_0.GetLongitude(), double_0, double_1);
			float float_11 = Math2.PublishClass(contact_0.GetLatitude(), contact_0.GetLongitude(), waypoint_1.Latitude, waypoint_1.Longitude);
			Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_1, ref double_0, float_10, float_11);
			((GeoPoint)object_0).Latitude = double_0;
			((GeoPoint)object_0).Longitude = double_1;
		}
		else if (float_1 < 6f)
		{
			double longitude3 = contact_0.GetLongitude();
			double latitude3 = contact_0.GetLatitude();
			double double_6 = (waypoint = (Waypoint)object_0).Longitude;
			Waypoint obj2 = (Waypoint)object_0;
			double double_7 = obj2.Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(longitude3, latitude3, ref double_6, ref double_7, float_9, float_8);
			obj2.Latitude = double_7;
			waypoint.Longitude = double_6;
		}
		else
		{
			double longitude4 = contact_0.GetLongitude();
			double latitude4 = contact_0.GetLatitude();
			Waypoint waypoint3;
			double double_8 = (waypoint3 = (Waypoint)object_0).Longitude;
			double double_9 = (waypoint = (Waypoint)object_0).Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(longitude4, latitude4, ref double_8, ref double_9, float_9, float_8);
			waypoint.Latitude = double_9;
			waypoint3.Longitude = double_8;
		}
	}

	internal static bool SortValue(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Aircraft aircraft_0, ref Waypoint[] waypoint_0, float float_0, bool bool_0)
	{
		try
		{
			if (side_0.NoNavZones.Count > 0 && waypoint_0.Count() > 0)
			{
				int num = waypoint_0.Count() - 2;
				for (int i = 0; i <= num; i++)
				{
					if (waypoint_0[i].Type == Waypoint.WaypointType.Target || waypoint_0[i].Type == Waypoint.WaypointType.WeaponTarget)
					{
						continue;
					}
					double latitude = waypoint_0[i].Latitude;
					double longitude = waypoint_0[i].Longitude;
					double latitude2;
					double longitude2;
					if (waypoint_0[i].Type != Waypoint.WaypointType.InitialPoint && waypoint_0[i].Type != Waypoint.WaypointType.WeaponLaunch)
					{
						latitude2 = waypoint_0[i + 1].Latitude;
						longitude2 = waypoint_0[i + 1].Longitude;
					}
					else
					{
						latitude2 = waypoint_0[i + 2].Latitude;
						longitude2 = waypoint_0[i + 2].Longitude;
					}
					if (latitude == latitude2 && longitude == longitude2)
					{
						continue;
					}
					Aircraft_Navigator navigator = aircraft_0.Navigator;
					double double_ = latitude2;
					double double_2 = longitude2;
					int int_ = 0;
					GeoPoint geoPoint_ = null;
					if (navigator.PathLineIsInterrupted(latitude, longitude, double_, double_2, bool_1: true, float_0, bool_2: false, null, bool_3: true, bool_4: false, bool_5: false, null, ref int_, ref geoPoint_))
					{
						ArrayExtensions.Clear(ref waypoint_0);
						if (!Information.IsNothing(_ReaderConsumer))
						{
							_ReaderConsumer.Clear();
						}
						propertyConsumer = false;
						if (bool_0)
						{
							scenario_0.AddMessage(aircraft_0.UnitClass + "与挂载" + aircraft_0.Loadout.Name + "在任务上" + mission_0.Name + "由于没有导航区域，无法规划多航段攻击路径。试图寻找替代路线", aircraft_0.UnitClass + " cannot do multi-leg", LoggedMessage.MessageType.AirOps, 0, aircraft_0.ObjectID, aircraft_0.GetUnitSide(), new Geopoint_Struct(aircraft_0.GetLongitude(), aircraft_0.GetLatitude()));
						}
						return true;
					}
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200607", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static bool CalcValue(ref Scenario scenario_0, ref Strike strike_0, ref Mission.Flight flight_0, ref Waypoint[] waypoint_0, ref Aircraft aircraft_0, ref Contact contact_0, ref float float_0, float float_1, float float_2, float float_3, float float_4, ref Waypoint.Formation formation_0, ref float float_5, Mission._RadarBehaviour _RadarBehaviour_0, ref float float_6, ref float float_7, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, float float_8, ref float float_9, AircraftMissionProfile aircraftMissionProfile_0, float float_10, bool bool_1, bool bool_2, bool bool_3, ref Waypoint waypoint_1, ref Waypoint waypoint_2, ref bool bool_4, ref Waypoint waypoint_3, ref Waypoint waypoint_4, object object_0, bool bool_5)
	{
		try
		{
			if (float_1 == 0f && float_2 == 0f)
			{
				return false;
			}
			if (bool_1)
			{
				if (!aircraft_0.IsGroupMember())
				{
					return false;
				}
			}
			else if (flight_0.DesiredAircraftQty == 1)
			{
				return false;
			}
			Mission._FlightSize _FlightSize_ = default(Mission._FlightSize);
			if (bool_1)
			{
				if (!Information.IsNothing(aircraft_0.GetParentGroup()))
				{
					_FlightSize_ = aircraft_0.GetParentGroup().Units.Count;
				}
			}
			else
			{
				_FlightSize_ = flight_0.DesiredAircraftQty;
			}
			switch (strike_0.AttackMethod)
			{
			default:
				return false;
			case Mission._AttackMethod.MultiAxisSimultaneousToT:
				return ForgotValue(ref scenario_0, ref strike_0, ref flight_0, ref waypoint_0, ref _FlightSize_, ref aircraft_0, ref contact_0, ref float_0, float_1, float_2, float_3, float_4, ref formation_0, ref float_5, _RadarBehaviour_0, ref float_6, ref float_7, ref bool_0, ref unitThrottlePreset_0, float_8, ref float_9, aircraftMissionProfile_0, float_10, bool_1, bool_2, bool_3, ref waypoint_1, ref waypoint_2, ref waypoint_3, ref waypoint_4, object_0);
			case Mission._AttackMethod.MultiAxisStackedToT_Echelon_20Sec:
			case Mission._AttackMethod.MultiAxisStackedToT_Echelon_30Sec:
			case Mission._AttackMethod.MultiAxisStackedToT_Echelon_40Sec:
			case Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec:
			case Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec:
			case Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec:
				return RateValue(ref scenario_0, ref strike_0, ref flight_0, ref waypoint_0, ref _FlightSize_, ref aircraft_0, ref contact_0, ref float_0, float_1, float_2, float_3, float_4, ref formation_0, ref float_5, _RadarBehaviour_0, ref float_6, ref float_7, ref bool_0, ref unitThrottlePreset_0, float_8, ref float_9, aircraftMissionProfile_0, float_10, bool_1, bool_2, bool_3, ref waypoint_1, ref waypoint_2, ref waypoint_3, ref waypoint_4, object_0, bool_5);
			case Mission._AttackMethod.SingleAxisStackedToT_20Sec:
			case Mission._AttackMethod.SingleAxisStackedToT_30Sec:
			case Mission._AttackMethod.SingleAxisStackedToT_40Sec:
				return FlushValue(ref scenario_0, ref strike_0, ref flight_0, ref waypoint_0, ref _FlightSize_, ref aircraft_0, ref contact_0, ref float_0, float_1, float_2, float_3, float_4, ref formation_0, ref float_5, _RadarBehaviour_0, ref float_6, ref float_7, ref bool_0, ref unitThrottlePreset_0, float_8, ref float_9, aircraftMissionProfile_0, float_10, bool_1, bool_2, bool_3, ref waypoint_1, ref waypoint_2, ref waypoint_3, ref waypoint_4, object_0, bool_5);
			case Mission._AttackMethod.BananaSplit:
				return CollectValue(ref scenario_0, ref strike_0, ref flight_0, ref waypoint_0, ref _FlightSize_, ref aircraft_0, ref contact_0, ref float_0, float_1, float_2, float_3, float_4, ref formation_0, ref float_5, _RadarBehaviour_0, ref float_6, ref float_7, ref bool_0, ref unitThrottlePreset_0, float_8, aircraftMissionProfile_0, float_10, bool_1, bool_2, bool_3, ref waypoint_1, ref waypoint_2, ref bool_4);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101386", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static bool RateValue(ref Scenario scenario_0, ref Strike strike_0, ref Mission.Flight flight_0, ref Waypoint[] waypoint_0, ref Mission._FlightSize _FlightSize_0, ref Aircraft aircraft_0, ref Contact contact_0, ref float float_0, float float_1, float float_2, float float_3, float float_4, ref Waypoint.Formation formation_0, ref float float_5, Mission._RadarBehaviour _RadarBehaviour_0, ref float float_6, ref float float_7, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, float float_8, ref float float_9, AircraftMissionProfile aircraftMissionProfile_0, float float_10, bool bool_1, bool bool_2, bool bool_3, ref Waypoint waypoint_1, ref Waypoint waypoint_2, ref Waypoint waypoint_3, ref Waypoint waypoint_4, object object_0, bool bool_4)
	{
		try
		{
			if (_FlightSize_0 > 1 && strike_0.AttackMethod >= Mission._AttackMethod.MultiAxisSimultaneousToT)
			{
				if (!(float_0 <= float_1))
				{
					double double_ = 0.0;
					double double_2 = 0.0;
					if (bool_2)
					{
						double_ = aircraft_0.GetLatitude();
						double_2 = aircraft_0.GetLongitude();
					}
					else if (float_10 < 6f)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_2, ref double_, float_1, Math2.UpdateClass(float_3 + float_8));
					}
					else
					{
						Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_2, ref double_, float_4 + float_1, Math2.UpdateClass(float_3 + float_8));
					}
					waypoint_3 = SetupTokenizer(waypoint_1, aircraft_0, ref waypoint_0, double_, double_2, aircraftMissionProfile_0, _RadarBehaviour_0, ref float_6, ref float_7, ref bool_0, ref unitThrottlePreset_0, ref float_5, ref strike_0.AttackMethod, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
					if (!Information.IsNothing(waypoint_1))
					{
						waypoint_1.Latitude = double_;
						waypoint_1.Longitude = double_2;
					}
					if (bool_3)
					{
						Waypoint waypoint_5 = (Information.IsNothing(waypoint_1) ? waypoint_0[waypoint_0.Count() - 1] : waypoint_1);
						Aircraft aircraft_ = aircraft_0;
						double double_3 = double_;
						double double_4 = double_2;
						Waypoint.Formation formation_ = Waypoint.Formation.Spread;
						InvokeTokenizer(waypoint_5, aircraft_, ref waypoint_0, double_3, double_4, aircraftMissionProfile_0, _RadarBehaviour_0, ref float_6, ref float_7, ref bool_0, ref unitThrottlePreset_0, ref float_5, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
					}
					if (float_10 < 6f)
					{
						if ((double)float_1 < (double)(float_2 + float_4) + (double)float_2 * 0.5)
						{
							float_2 = (float)((double)float_4 + (double)float_2 * 0.5);
						}
					}
					else if ((double)(float_4 + float_2) < (double)(float_2 + float_4) + (double)float_2 * 0.5)
					{
						float_2 = (float)((double)float_2 * 0.5);
					}
					double double_5 = 0.0;
					double double_6 = 0.0;
					if (float_10 < 6f)
					{
						if (float_1 <= 10f)
						{
							if (bool_4)
							{
								float_9 = 0f;
							}
							else
							{
								float_9 = GameGeneral.LockRandom_0.Next(5, 10);
							}
						}
						else
						{
							float_9 = GameGeneral.LockRandom_0.Next(15, 30);
						}
						Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_5, ref double_6, float_2, Math2.UpdateClass(float_3 + float_8 - float_9));
					}
					else
					{
						if (float_10 < 15f)
						{
							float_9 = GameGeneral.LockRandom_0.Next(5, 10);
						}
						else
						{
							float_9 = 0f;
						}
						Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_5, ref double_6, float_4 + float_2, Math2.UpdateClass(float_3 + float_8 - float_9));
					}
					Waypoint waypoint_6 = waypoint_2;
					Aircraft aircraft_2 = aircraft_0;
					double double_7 = double_6;
					double double_8 = double_5;
					ref Mission._AttackMethod attackMethod = ref strike_0.AttackMethod;
					float float_11 = 0f;
					waypoint_4 = ExcludeTokenizer(waypoint_6, aircraft_2, ref waypoint_0, double_7, double_8, aircraftMissionProfile_0, _RadarBehaviour_0, ref float_6, ref float_7, ref bool_0, ref unitThrottlePreset_0, ref float_5, ref attackMethod, ref formation_0, ref float_11, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
					if (!Information.IsNothing(waypoint_2))
					{
						waypoint_2.Latitude = double_6;
						waypoint_2.Longitude = double_5;
					}
					return true;
				}
				if (bool_1)
				{
					string text = "";
					if (Operators.CompareString(aircraft_0.Name, aircraft_0.UnitClass, TextCompare: false) != 0)
					{
						text = " (" + aircraft_0.UnitClass + ")";
					}
					string text2 = ((strike_0.Category == Mission.MissionCategory.Package) ? "" : "任务");
					scenario_0.AddMessage(text2 + strike_0.Name + "飞机类型" + text + "太靠近目标，任务计划员无法生成多轴堆叠ToT飞行计划。而是使用单轴形成攻击。", strike_0.Name + " cannot multi-axis", LoggedMessage.MessageType.AirOps, 15, aircraft_0.ObjectID, aircraft_0.GetUnitSide(), new Geopoint_Struct(aircraft_0.GetLongitude(), aircraft_0.GetLatitude()));
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101387", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static bool FlushValue(ref Scenario scenario_0, ref Strike strike_0, ref Mission.Flight flight_0, ref Waypoint[] waypoint_0, ref Mission._FlightSize _FlightSize_0, ref Aircraft aircraft_0, ref Contact contact_0, ref float float_0, float float_1, float float_2, float float_3, float float_4, ref Waypoint.Formation formation_0, ref float float_5, Mission._RadarBehaviour _RadarBehaviour_0, ref float float_6, ref float float_7, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, float float_8, ref float float_9, AircraftMissionProfile aircraftMissionProfile_0, float float_10, bool bool_1, bool bool_2, bool bool_3, ref Waypoint waypoint_1, ref Waypoint waypoint_2, ref Waypoint waypoint_3, ref Waypoint waypoint_4, object object_0, bool bool_4)
	{
		try
		{
			float float_11 = 0f;
			return RateValue(ref scenario_0, ref strike_0, ref flight_0, ref waypoint_0, ref _FlightSize_0, ref aircraft_0, ref contact_0, ref float_0, float_1, float_2, float_3, float_4, ref formation_0, ref float_5, _RadarBehaviour_0, ref float_6, ref float_7, ref bool_0, ref unitThrottlePreset_0, float_8, ref float_11, aircraftMissionProfile_0, float_10, bool_1, bool_2, bool_3, ref waypoint_1, ref waypoint_2, ref waypoint_3, ref waypoint_4, object_0, bool_4);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101388", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static bool ForgotValue(ref Scenario scenario_0, ref Strike strike_0, ref Mission.Flight flight_0, ref Waypoint[] waypoint_0, ref Mission._FlightSize _FlightSize_0, ref Aircraft aircraft_0, ref Contact contact_0, ref float float_0, float float_1, float float_2, float float_3, float float_4, ref Waypoint.Formation formation_0, ref float float_5, Mission._RadarBehaviour _RadarBehaviour_0, ref float float_6, ref float float_7, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, float float_8, ref float float_9, AircraftMissionProfile aircraftMissionProfile_0, float float_10, bool bool_1, bool bool_2, bool bool_3, ref Waypoint waypoint_1, ref Waypoint waypoint_2, ref Waypoint waypoint_3, ref Waypoint waypoint_4, object object_0)
	{
		try
		{
			if (_FlightSize_0 > 1 && strike_0.AttackMethod >= Mission._AttackMethod.MultiAxisSimultaneousToT)
			{
				if (!(float_0 <= float_1))
				{
					double double_ = 0.0;
					double double_2 = 0.0;
					if (bool_2)
					{
						double_ = aircraft_0.GetLatitude();
						double_2 = aircraft_0.GetLongitude();
					}
					else if (float_10 < 6f)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_2, ref double_, float_1, Math2.UpdateClass(float_3 + float_8));
					}
					else
					{
						Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_2, ref double_, float_4 + float_1, Math2.UpdateClass(float_3 + float_8));
					}
					waypoint_3 = SetupTokenizer(waypoint_1, aircraft_0, ref waypoint_0, double_, double_2, aircraftMissionProfile_0, _RadarBehaviour_0, ref float_6, ref float_7, ref bool_0, ref unitThrottlePreset_0, ref float_5, ref strike_0.AttackMethod, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
					if (!Information.IsNothing(waypoint_1))
					{
						waypoint_1.Latitude = double_;
						waypoint_1.Longitude = double_2;
					}
					if (bool_3)
					{
						Waypoint waypoint_5 = (Information.IsNothing(waypoint_1) ? waypoint_0[waypoint_0.Count() - 1] : waypoint_1);
						Aircraft aircraft_ = aircraft_0;
						double double_3 = double_;
						double double_4 = double_2;
						Waypoint.Formation formation_ = Waypoint.Formation.Spread;
						InvokeTokenizer(waypoint_5, aircraft_, ref waypoint_0, double_3, double_4, aircraftMissionProfile_0, _RadarBehaviour_0, ref float_6, ref float_7, ref bool_0, ref unitThrottlePreset_0, ref float_5, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
					}
					double double_5 = 0.0;
					double double_6 = 0.0;
					Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_5, ref double_6, float_10 + 5f, Math2.UpdateClass(float_3 + float_8));
					Waypoint waypoint_6 = waypoint_2;
					Aircraft aircraft_2 = aircraft_0;
					double double_7 = double_6;
					double double_8 = double_5;
					ref Mission._AttackMethod attackMethod = ref strike_0.AttackMethod;
					float float_11 = 0f;
					waypoint_4 = ExcludeTokenizer(waypoint_6, aircraft_2, ref waypoint_0, double_7, double_8, aircraftMissionProfile_0, _RadarBehaviour_0, ref float_6, ref float_7, ref bool_0, ref unitThrottlePreset_0, ref float_5, ref attackMethod, ref formation_0, ref float_11, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
					if (!Information.IsNothing(waypoint_2))
					{
						waypoint_2.Latitude = double_6;
						waypoint_2.Longitude = double_5;
					}
					return true;
				}
				if (bool_1)
				{
					string text = "";
					if (Operators.CompareString(aircraft_0.Name, aircraft_0.UnitClass, TextCompare: false) != 0)
					{
						text = " (" + aircraft_0.UnitClass + ")";
					}
					string text2 = ((strike_0.Category == Mission.MissionCategory.Package) ? "" : "任务");
					scenario_0.AddMessage(text2 + strike_0.Name + "飞机类型" + text + "太靠近目标，任务规划者无法生成多轴同时ToT飞行计划。而是使用单轴形成攻击。", strike_0.Name + " cannot multi-axis", LoggedMessage.MessageType.AirOps, 15, aircraft_0.ObjectID, aircraft_0.GetUnitSide(), new Geopoint_Struct(aircraft_0.GetLongitude(), aircraft_0.GetLatitude()));
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101389", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static bool CollectValue(ref Scenario scenario_0, ref Strike strike_0, ref Mission.Flight flight_0, ref Waypoint[] waypoint_0, ref Mission._FlightSize _FlightSize_0, ref Aircraft aircraft_0, ref Contact contact_0, ref float float_0, float float_1, float float_2, float float_3, float float_4, ref Waypoint.Formation formation_0, ref float float_5, Mission._RadarBehaviour _RadarBehaviour_0, ref float float_6, ref float float_7, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, float float_8, AircraftMissionProfile aircraftMissionProfile_0, float float_9, bool bool_1, bool bool_2, bool bool_3, ref Waypoint waypoint_1, ref Waypoint waypoint_2, ref bool bool_4)
	{
		try
		{
			bool_4 = !bool_4;
			if (_FlightSize_0 > 1 && strike_0.AttackMethod >= Mission._AttackMethod.BananaSplit)
			{
				if (bool_4)
				{
					float_1 = 15f;
					if (!(float_0 <= float_1))
					{
						double double_ = 0.0;
						double double_11 = 0.0;
						if (bool_2)
						{
							double_ = aircraft_0.GetLatitude();
							double_11 = aircraft_0.GetLongitude();
						}
						else if (float_9 < 6f)
						{
							Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_11, ref double_, float_1, Math2.UpdateClass(float_3 + float_8));
						}
						else
						{
							Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_11, ref double_, float_4 + float_1, Math2.UpdateClass(float_3 + float_8));
						}
						SetupTokenizer(waypoint_1, aircraft_0, ref waypoint_0, double_, double_11, aircraftMissionProfile_0, _RadarBehaviour_0, ref float_6, ref float_7, ref bool_0, ref unitThrottlePreset_0, ref float_5, ref strike_0.AttackMethod, ref formation_0, Waypoint.TurnRateCategory.const_6, Waypoint.SpeedToT.Yes_UpOrDown_Military);
						if (!Information.IsNothing(waypoint_1))
						{
							waypoint_1.Latitude = double_;
							waypoint_1.Longitude = double_11;
						}
						if (bool_3)
						{
							Waypoint waypoint_3 = (Information.IsNothing(waypoint_1) ? waypoint_0[waypoint_0.Count() - 1] : waypoint_1);
							Aircraft aircraft_ = aircraft_0;
							double double_12 = double_;
							double double_13 = double_11;
							Waypoint.Formation formation_ = Waypoint.Formation.Spread;
							InvokeTokenizer(waypoint_3, aircraft_, ref waypoint_0, double_12, double_13, aircraftMissionProfile_0, _RadarBehaviour_0, ref float_6, ref float_7, ref bool_0, ref unitThrottlePreset_0, ref float_5, ref formation_, Waypoint.TurnRateCategory.const_6, Waypoint.SpeedToT.Yes_UpOrDown_Military);
						}
						float num = 10f;
						float_2 = 7f;
						float float_10 = (float)(7.0 / Math.Cos(0.17453292519943298));
						double double_14 = 0.0;
						double double_15 = 0.0;
						Geodesic_EdWilliams.CalcPoint_Williams(double_11, double_, ref double_14, ref double_15, float_10, Math2.UpdateClass(float_3 + 180f + float_8 - num));
						Waypoint waypoint_4 = waypoint_2;
						Aircraft aircraft_2 = aircraft_0;
						double double_16 = double_15;
						double double_17 = double_14;
						ref Mission._AttackMethod attackMethod = ref strike_0.AttackMethod;
						float float_11 = 0f;
						ExcludeTokenizer(waypoint_4, aircraft_2, ref waypoint_0, double_16, double_17, aircraftMissionProfile_0, _RadarBehaviour_0, ref float_6, ref float_7, ref bool_0, ref unitThrottlePreset_0, ref float_5, ref attackMethod, ref formation_0, ref float_11, Waypoint.TurnRateCategory.const_6, Waypoint.SpeedToT.Yes_UpOrDown_Military);
						if (!Information.IsNothing(waypoint_2))
						{
							waypoint_2.Latitude = double_15;
							waypoint_2.Longitude = double_14;
						}
						return true;
					}
					if (bool_1)
					{
						string text = "";
						if (Operators.CompareString(aircraft_0.Name, aircraft_0.UnitClass, TextCompare: false) != 0)
						{
							text = " (" + aircraft_0.UnitClass + ")";
						}
						string text2 = ((strike_0.Category == Mission.MissionCategory.Package) ? "" : "任务");
						scenario_0.AddMessage(text2 + strike_0.Name + "飞机类型" + text + "太靠近目标，任务规划者无法生成香蕉剖分飞行计划。而是使用单轴形成攻击。", strike_0.Name + " cannot do banana split", LoggedMessage.MessageType.AirOps, 15, aircraft_0.ObjectID, aircraft_0.GetUnitSide(), new Geopoint_Struct(aircraft_0.GetLongitude(), aircraft_0.GetLatitude()));
					}
				}
				else
				{
					float_1 = 8f;
					if (!(float_0 <= float_1))
					{
						float num2 = ActiveUnit_Kinematics.TurnRateCategoryToActualTurnRate(Waypoint.TurnRateCategory.const_6, float_5);
						float num3 = 9f;
						float num4 = Math.Abs(num3) / num2;
						float num5 = float_5 / 3600f * num4;
						float num6 = (float)((double)float_5 / ((double)num2 * 3.14159265358979 * 20.0));
						float num7 = float_1 + num6 / 2f + num5;
						float_2 = num6 / 2f + num5;
						double double_18 = 0.0;
						double double_2 = 0.0;
						if (bool_2)
						{
							double_2 = aircraft_0.GetLatitude();
							double_18 = aircraft_0.GetLongitude();
						}
						else if (float_9 < 6f)
						{
							Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_18, ref double_2, num7, Math2.UpdateClass(float_3 + float_8));
						}
						else
						{
							Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_18, ref double_2, float_4 + num7, Math2.UpdateClass(float_3 + float_8));
						}
						Waypoint waypoint = SetupTokenizer(waypoint_1, aircraft_0, ref waypoint_0, double_2, double_18, aircraftMissionProfile_0, _RadarBehaviour_0, ref float_6, ref float_7, ref bool_0, ref unitThrottlePreset_0, ref float_5, ref strike_0.AttackMethod, ref formation_0, Waypoint.TurnRateCategory.const_6, Waypoint.SpeedToT.Yes_UpOrDown_Military);
						if (!Information.IsNothing(waypoint_1))
						{
							waypoint_1.Latitude = double_2;
							waypoint_1.Longitude = double_18;
						}
						if (bool_3)
						{
							Waypoint waypoint_5 = (Information.IsNothing(waypoint_1) ? waypoint_0[waypoint_0.Count() - 1] : waypoint_1);
							Aircraft aircraft_3 = aircraft_0;
							double double_3 = double_2;
							double double_4 = double_18;
							Waypoint.Formation formation_2 = Waypoint.Formation.Spread;
							InvokeTokenizer(waypoint_5, aircraft_3, ref waypoint_0, double_3, double_4, aircraftMissionProfile_0, _RadarBehaviour_0, ref float_6, ref float_7, ref bool_0, ref unitThrottlePreset_0, ref float_5, ref formation_2, Waypoint.TurnRateCategory.const_6, Waypoint.SpeedToT.Yes_UpOrDown_Military);
						}
						Misc.TurnDirection turnDirection = Misc.CountValue(Math2.UpdateClass(float_3 + 180f + float_8), Math2.UpdateClass(float_3 + 180f + float_8 + 90f));
						switch (turnDirection)
						{
						case Misc.TurnDirection.TurnRight:
							num3 = 9f;
							break;
						case Misc.TurnDirection.TurnLeft:
							num3 = -9f;
							break;
						}
						float float_12 = 0f;
						GeoPoint geoPoint = PatchTokenizer(double_2, double_18, Math2.UpdateClass(float_3 + 180f + float_8), Math2.UpdateClass(float_3 + 180f + float_8 + 90f), Waypoint.TurnRateCategory.const_6, waypoint.DesiredSpeed.Value, num3, turnDirection, ref float_12);
						double double_5 = 0.0;
						double double_6 = 0.0;
						if (Information.IsNothing(geoPoint))
						{
							float_12 = 90f / num2;
							Geodesic_EdWilliams.CalcPoint_Williams(double_18, double_2, ref double_5, ref double_6, float_2, Math2.UpdateClass(float_3 + 180f + 90f + float_8));
						}
						else
						{
							double_5 = geoPoint.Longitude;
							double_6 = geoPoint.Latitude;
						}
						float num8 = 30f;
						float float_13 = num6 + float_5 / 3600f * (num8 - float_12);
						double double_7 = 0.0;
						double double_8 = 0.0;
						Geodesic_EdWilliams.CalcPoint_Williams(double_5, double_6, ref double_7, ref double_8, float_13, Math2.UpdateClass(float_3 + float_8 - 90f));
						Waypoint waypoint_6 = waypoint_2;
						Aircraft aircraft_4 = aircraft_0;
						double double_9 = double_8;
						double double_10 = double_7;
						ref Mission._AttackMethod attackMethod2 = ref strike_0.AttackMethod;
						float float_14 = 0f;
						ExcludeTokenizer(waypoint_6, aircraft_4, ref waypoint_0, double_9, double_10, aircraftMissionProfile_0, _RadarBehaviour_0, ref float_6, ref float_7, ref bool_0, ref unitThrottlePreset_0, ref float_5, ref attackMethod2, ref formation_0, ref float_14, Waypoint.TurnRateCategory.const_6, Waypoint.SpeedToT.Yes_UpOrDown_Military);
						if (!Information.IsNothing(waypoint_2))
						{
							waypoint_2.Latitude = double_8;
							waypoint_2.Longitude = double_7;
						}
						return true;
					}
					if (bool_1)
					{
						string text3 = "";
						if (Operators.CompareString(aircraft_0.Name, aircraft_0.UnitClass, TextCompare: false) != 0)
						{
							text3 = " (" + aircraft_0.UnitClass + ")";
						}
						string text4 = ((strike_0.Category == Mission.MissionCategory.Package) ? "" : "任务");
						scenario_0.AddMessage(text4 + strike_0.Name + "飞机类型" + text3 + "太靠近目标，任务规划者无法生成香蕉剖分飞行计划。而是使用单轴形成攻击。", strike_0.Name + " cannot do banana split", LoggedMessage.MessageType.AirOps, 15, aircraft_0.ObjectID, aircraft_0.GetUnitSide(), new Geopoint_Struct(aircraft_0.GetLongitude(), aircraft_0.GetLatitude()));
					}
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101390", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private unsafe static bool OrderValue(ref Strike strike_0, ref Mission.Flight flight_0, ref Waypoint[] waypoint_0, ref Aircraft aircraft_0, ref Contact contact_0, double double_0, double double_1, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, ref Waypoint.Formation formation_0, ref float float_6, ref float float_7, ref float float_8, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, float float_9, float float_10, AircraftMissionProfile aircraftMissionProfile_0, bool bool_1, bool bool_2, ref Waypoint waypoint_1, ref Waypoint waypoint_2, ref bool bool_3, ref Waypoint waypoint_3, ref Waypoint waypoint_4, object object_0, bool bool_4)
	{
		try
		{
			if (float_4 == 0f && float_5 == 0f)
			{
				return false;
			}
			if (bool_1)
			{
				if (!aircraft_0.IsGroupMember())
				{
					return false;
				}
			}
			else if (flight_0.DesiredAircraftQty == 1)
			{
				return false;
			}
			Mission._FlightSize _FlightSize_ = default(Mission._FlightSize);
			if (bool_1)
			{
				if (!Information.IsNothing(aircraft_0.GetParentGroup()))
				{
					_FlightSize_ = aircraft_0.GetParentGroup().Units.Count;
				}
			}
			else
			{
				_FlightSize_ = flight_0.DesiredAircraftQty;
			}
			switch (strike_0.AttackMethod)
			{
			default:
				return false;
			case Mission._AttackMethod.MultiAxisSimultaneousToT:
				return ManageValue(ref strike_0, ref flight_0, ref waypoint_0, ref _FlightSize_, ref aircraft_0, ref contact_0, double_0, double_1, float_0, float_1, float_2, float_3, float_4, float_5, ref formation_0, ref float_6, ref float_7, ref float_8, ref bool_0, ref unitThrottlePreset_0, float_9, float_10, aircraftMissionProfile_0, bool_1, bool_2, ref waypoint_1, ref waypoint_2, ref waypoint_3, ref waypoint_4, ref *(Waypoint*)(&object_0), bool_4);
			case Mission._AttackMethod.MultiAxisStackedToT_Echelon_20Sec:
			case Mission._AttackMethod.MultiAxisStackedToT_Echelon_30Sec:
			case Mission._AttackMethod.MultiAxisStackedToT_Echelon_40Sec:
			case Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec:
			case Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec:
			case Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec:
				return RegisterValue(ref strike_0, ref flight_0, ref waypoint_0, ref _FlightSize_, ref aircraft_0, ref contact_0, double_0, double_1, float_0, float_1, float_2, float_3, float_4, float_5, ref formation_0, ref float_6, ref float_7, ref float_8, ref bool_0, ref unitThrottlePreset_0, float_9, float_10, aircraftMissionProfile_0, bool_1, bool_2, ref waypoint_1, ref waypoint_2);
			case Mission._AttackMethod.SingleAxisStackedToT_20Sec:
			case Mission._AttackMethod.SingleAxisStackedToT_30Sec:
			case Mission._AttackMethod.SingleAxisStackedToT_40Sec:
				return RevertValue(ref strike_0, ref flight_0, ref waypoint_0, ref _FlightSize_, ref aircraft_0, ref contact_0, double_0, double_1, float_0, float_1, float_2, float_3, float_4, float_5, ref formation_0, ref float_6, ref float_7, ref float_8, ref bool_0, ref unitThrottlePreset_0, float_9, float_10, aircraftMissionProfile_0, bool_1, bool_2, ref waypoint_1, ref waypoint_2);
			case Mission._AttackMethod.BananaSplit:
				return CountTokenizer(ref strike_0, ref flight_0, ref waypoint_0, ref _FlightSize_, ref aircraft_0, ref contact_0, double_0, double_1, float_0, float_1, float_2, float_3, float_4, float_5, ref formation_0, ref float_6, ref float_7, ref float_8, ref bool_0, ref unitThrottlePreset_0, float_9, float_10, aircraftMissionProfile_0, bool_1, bool_2, ref waypoint_1, ref waypoint_2, ref bool_3, bool_4);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101391", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static bool RegisterValue(ref Strike strike_0, ref Mission.Flight flight_0, ref Waypoint[] waypoint_0, ref Mission._FlightSize _FlightSize_0, ref Aircraft aircraft_0, ref Contact contact_0, double double_0, double double_1, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, ref Waypoint.Formation formation_0, ref float float_6, ref float float_7, ref float float_8, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, float float_9, float float_10, AircraftMissionProfile aircraftMissionProfile_0, bool bool_1, bool bool_2, ref Waypoint waypoint_1, ref Waypoint waypoint_2)
	{
		try
		{
			if (!(_FlightSize_0 <= 1) && strike_0.AttackMethod >= Mission._AttackMethod.MultiAxisSimultaneousToT && float_3 > float_5)
			{
				float num;
				if (float_1 < 6f)
				{
					switch (strike_0.AttackMethod)
					{
					default:
						num = 15f;
						break;
					case Mission._AttackMethod.MultiAxisStackedToT_Echelon_20Sec:
					case Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec:
						num = ((int)_FlightSize_0 - 1) * 20;
						break;
					case Mission._AttackMethod.MultiAxisStackedToT_Echelon_30Sec:
					case Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec:
						num = ((int)_FlightSize_0 - 1) * 30;
						break;
					case Mission._AttackMethod.MultiAxisStackedToT_Echelon_40Sec:
					case Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec:
						num = ((int)_FlightSize_0 - 1) * 40;
						break;
					}
				}
				else if (float_1 < 30f)
				{
					switch (strike_0.AttackMethod)
					{
					default:
						num = 15f;
						break;
					case Mission._AttackMethod.MultiAxisStackedToT_Echelon_20Sec:
					case Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec:
						num = ((int)_FlightSize_0 - 1) * 25;
						break;
					case Mission._AttackMethod.MultiAxisStackedToT_Echelon_30Sec:
					case Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec:
						num = ((int)_FlightSize_0 - 1) * 35;
						break;
					case Mission._AttackMethod.MultiAxisStackedToT_Echelon_40Sec:
					case Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec:
						num = ((int)_FlightSize_0 - 1) * 45;
						break;
					}
				}
				else if (float_1 < 85f)
				{
					switch (strike_0.AttackMethod)
					{
					default:
						num = 15f;
						break;
					case Mission._AttackMethod.MultiAxisStackedToT_Echelon_20Sec:
					case Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec:
						num = ((int)_FlightSize_0 - 1) * 30;
						break;
					case Mission._AttackMethod.MultiAxisStackedToT_Echelon_30Sec:
					case Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec:
						num = ((int)_FlightSize_0 - 1) * 40;
						break;
					case Mission._AttackMethod.MultiAxisStackedToT_Echelon_40Sec:
					case Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec:
						num = ((int)_FlightSize_0 - 1) * 50;
						break;
					}
				}
				else
				{
					switch (strike_0.AttackMethod)
					{
					default:
						num = 15f;
						break;
					case Mission._AttackMethod.MultiAxisStackedToT_Echelon_20Sec:
					case Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec:
						num = ((int)_FlightSize_0 - 1) * 35;
						break;
					case Mission._AttackMethod.MultiAxisStackedToT_Echelon_30Sec:
					case Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec:
						num = ((int)_FlightSize_0 - 1) * 45;
						break;
					case Mission._AttackMethod.MultiAxisStackedToT_Echelon_40Sec:
					case Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec:
						num = ((int)_FlightSize_0 - 1) * 55;
						break;
					}
				}
				float num2 = num * float_6 / 3600f;
				num2 = (float)Math.Sqrt(Math.Pow(float_4 + num2 / 2f, 2.0) - Math.Pow(float_4, 2.0));
				double double_2 = 0.0;
				double double_3 = 0.0;
				if (float_1 < 6f)
				{
					Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_2, ref double_3, float_4 / 2f, float_2 + float_10);
				}
				else
				{
					Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_2, ref double_3, float_4 / 2f + float_1, float_2 + float_10);
				}
				Geodesic_EdWilliams.CalcPoint_Williams(double_2, double_3, ref double_2, ref double_3, num2, Math2.UpdateClass(float_2 + float_10 + float_9));
				ChangeTokenizer(waypoint_1, aircraft_0, ref waypoint_0, double_3, double_2, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_0, ref unitThrottlePreset_0, ref float_6, ref strike_0.AttackMethod, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
				if (!Information.IsNothing(waypoint_1))
				{
					waypoint_1.Latitude = double_3;
					waypoint_1.Longitude = double_2;
				}
				double double_4 = 0.0;
				double double_5 = 0.0;
				if (float_1 < 6f)
				{
					Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_4, ref double_5, float_4, Math2.UpdateClass(float_2 + float_10));
				}
				else
				{
					Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_4, ref double_5, float_4 + float_1, Math2.UpdateClass(float_2 + float_10));
				}
				Waypoint waypoint_3 = waypoint_2;
				Aircraft aircraft_ = aircraft_0;
				double double_6 = double_5;
				double double_7 = double_4;
				ref Mission._AttackMethod attackMethod = ref strike_0.AttackMethod;
				float float_11 = 0f;
				EnableTokenizer(waypoint_3, aircraft_, ref waypoint_0, double_6, double_7, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_0, ref unitThrottlePreset_0, ref float_6, ref attackMethod, ref formation_0, ref float_11, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
				if (!Information.IsNothing(waypoint_2))
				{
					waypoint_2.Latitude = double_5;
					waypoint_2.Longitude = double_4;
				}
				if (bool_2)
				{
					Waypoint waypoint_4 = (Information.IsNothing(waypoint_2) ? waypoint_0[waypoint_0.Count() - 1] : waypoint_2);
					Aircraft aircraft_2 = aircraft_0;
					double double_8 = double_5;
					double double_9 = double_4;
					Waypoint.Formation formation_ = Waypoint.Formation.Spread;
					FindTokenizer(waypoint_4, aircraft_2, ref waypoint_0, double_8, double_9, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_0, ref unitThrottlePreset_0, ref float_6, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
				}
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101392", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static bool ManageValue(ref Strike strike_0, ref Mission.Flight flight_0, ref Waypoint[] waypoint_0, ref Mission._FlightSize _FlightSize_0, ref Aircraft aircraft_0, ref Contact contact_0, double double_0, double double_1, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, ref Waypoint.Formation formation_0, ref float float_6, ref float float_7, ref float float_8, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, float float_9, float float_10, AircraftMissionProfile aircraftMissionProfile_0, bool bool_1, bool bool_2, ref Waypoint waypoint_1, ref Waypoint waypoint_2, ref Waypoint waypoint_3, ref Waypoint waypoint_4, ref Waypoint waypoint_5, bool bool_3)
	{
		try
		{
			if (!(_FlightSize_0 <= 1) && strike_0.AttackMethod >= Mission._AttackMethod.MultiAxisSimultaneousToT && float_3 > float_5)
			{
				float float_11;
				float num;
				if (float_1 < 6f)
				{
					if (((double)float_4 - Math.Max(float_1, 3.5)) / 2.0 < 5.0)
					{
						float_11 = (float)((double)float_4 - Math.Max(float_1, 3.5)) / 2f;
						num = (float)(((double)float_4 - Math.Max(float_1, 3.5)) / 2.0) + 1f;
					}
					else
					{
						float_11 = 5f;
						num = float_1;
					}
				}
				else
				{
					float_11 = 5f;
					num = 6f;
				}
				double double_5 = 0.0;
				double double_6 = 0.0;
				if (float_1 < 6f)
				{
					Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_5, ref double_6, float_4, Math2.UpdateClass(float_2 + float_10));
				}
				else
				{
					Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_5, ref double_6, float_1 + float_4, Math2.UpdateClass(float_2 + float_10));
				}
				Waypoint.Formation formation_ = formation_0;
				if (Information.IsNothing(waypoint_1))
				{
					waypoint_1 = new Waypoint(aircraft_0.GetLongitude(), aircraft_0.GetLatitude(), 0f, Waypoint.WaypointType.StrikeIngress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
					ArrayExtensions.Add(ref waypoint_0, waypoint_1);
				}
				Waypoint waypoint_6 = waypoint_2;
				Aircraft aircraft_ = aircraft_0;
				double double_7 = double_6;
				double double_8 = double_5;
				ref Mission._AttackMethod attackMethod = ref strike_0.AttackMethod;
				float float_12 = 0f;
				EnableTokenizer(waypoint_6, aircraft_, ref waypoint_0, double_7, double_8, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_0, ref unitThrottlePreset_0, ref float_6, ref attackMethod, ref formation_0, ref float_12, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
				if (!Information.IsNothing(waypoint_2))
				{
					waypoint_2.Latitude = double_6;
					waypoint_2.Longitude = double_5;
				}
				float float_13 = Math2.PublishClass(contact_0.GetLatitude(), contact_0.GetLongitude(), double_6, double_5);
				float num2 = Math2.PublishClass(contact_0.GetLatitude(), contact_0.GetLongitude(), waypoint_3.Latitude, waypoint_3.Longitude);
				if (!Information.IsNothing(waypoint_5) && !Information.IsNothing(waypoint_4) && !Information.IsNothing(waypoint_3))
				{
					float num3 = MathFunctions.DeleteRequest(num2, float_13);
					float num4 = 0f;
					switch (strike_0.SplitDistance)
					{
					case Mission._SplitDistance.Close_10nm:
						num4 = 10f;
						break;
					case Mission._SplitDistance.Typical_20nm:
						num4 = 20f;
						break;
					case Mission._SplitDistance.Long_50nm:
						num4 = 40f;
						break;
					}
					if ((double)num4 > Math.Max(float_1, 3.5) * 1.5)
					{
						num4 = (float)(Math.Max(float_1, 3.5) * 1.5);
					}
					float num5 = (float)(Math.Asin((double)(num4 / 2f) / Math.Max(float_1, 3.5)) * 57.2957795130823);
					float num6 = ((float_1 < 6f) ? 10f : ((float_1 < 20f) ? 7f : ((float_1 < 50f) ? 5f : ((float_1 < 100f) ? 2f : 1f))));
					float float_14 = ((num3 > 0f) ? Math2.UpdateClass(num2 - num5 - num6) : Math2.UpdateClass(num2 + num5 + num6));
					Contact obj = contact_0;
					bool? nullable_ = null;
					double double_9 = obj.GetLongitude(nullable_);
					Contact obj2 = contact_0;
					bool? nullable_2 = null;
					double double_10 = obj2.GetLatitude(nullable_2);
					double double_11 = Math.Max(float_1, 3.5);
					Geodesic_EdWilliams.CalcPoint_Williams(ref double_9, ref double_10, ref double_1, ref double_0, ref double_11, ref float_14);
					obj2.SetLatitude(nullable_2, double_10);
					obj.SetLongitude(nullable_, double_9);
					waypoint_5.Latitude = double_0;
					waypoint_5.Longitude = double_1;
				}
				double double_12 = 0.0;
				double double_2 = 0.0;
				if (num < 6f)
				{
					float num7;
					if (bool_3 && float_1 < 6f)
					{
						Mission._FlightSize flightSize = _FlightSize_0;
						num7 = ((flightSize == 1 || flightSize == 2) ? ((float)(((int)_FlightSize_0 - 1) * 20)) : ((flightSize == 3) ? ((float)(((int)_FlightSize_0 - 1) * 10)) : ((flightSize == 4) ? ((float_4 <= 10f) ? ((float)(((int)_FlightSize_0 - 1) * 9)) : ((float)(((int)_FlightSize_0 - 1) * 6))) : ((float_4 <= 10f) ? ((float)(((int)_FlightSize_0 - 1) * 8)) : ((float)(((int)_FlightSize_0 - 1) * 4))))));
					}
					else
					{
						num7 = ((int)_FlightSize_0 - 1) * 6;
					}
					float num8 = num7 * float_6 / 3600f;
					num8 = (float)Math.Sqrt(Math.Pow(float_4 + num8 / 2f, 2.0) - Math.Pow(float_4, 2.0));
					if (float_1 < 6f)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_12, ref double_2, float_4 / 2f, float_2 + float_10);
					}
					else
					{
						Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_12, ref double_2, float_4 / 2f, float_2 + float_10);
					}
					if (bool_3)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(double_12, double_2, ref double_12, ref double_2, num8, Math2.UpdateClass(float_2 + float_10 + float_9));
					}
					else
					{
						Geodesic_EdWilliams.CalcPoint_Williams(double_12, double_2, ref double_12, ref double_2, num8, Math2.UpdateClass(float_2 + float_10 + float_9 + 180f));
					}
				}
				else
				{
					Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_12, ref double_2, num, float_13);
				}
				ChangeTokenizer(waypoint_1, aircraft_0, ref waypoint_0, double_2, double_12, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_0, ref unitThrottlePreset_0, ref float_6, ref strike_0.AttackMethod, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
				if (!Information.IsNothing(waypoint_1))
				{
					waypoint_1.Latitude = double_2;
					waypoint_1.Longitude = double_12;
				}
				if (bool_2)
				{
					Waypoint waypoint_7 = (Information.IsNothing(waypoint_2) ? waypoint_0[waypoint_0.Count() - 1] : waypoint_2);
					Aircraft aircraft_2 = aircraft_0;
					double double_3 = double_6;
					double double_4 = double_5;
					Waypoint.Formation formation_2 = Waypoint.Formation.Spread;
					FindTokenizer(waypoint_7, aircraft_2, ref waypoint_0, double_3, double_4, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_0, ref unitThrottlePreset_0, ref float_6, ref formation_2, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
				}
				Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_12, ref double_2, float_11, num2);
				waypoint_4.Latitude = double_2;
				waypoint_4.Longitude = double_12;
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101393", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static bool RevertValue(ref Strike strike_0, ref Mission.Flight flight_0, ref Waypoint[] waypoint_0, ref Mission._FlightSize _FlightSize_0, ref Aircraft aircraft_0, ref Contact contact_0, double double_0, double double_1, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, ref Waypoint.Formation formation_0, ref float float_6, ref float float_7, ref float float_8, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, float float_9, float float_10, AircraftMissionProfile aircraftMissionProfile_0, bool bool_1, bool bool_2, ref Waypoint waypoint_1, ref Waypoint waypoint_2)
	{
		try
		{
			if (!(_FlightSize_0 <= 1) && strike_0.AttackMethod >= Mission._AttackMethod.MultiAxisSimultaneousToT && float_3 > float_5)
			{
				double double_2 = 0.0;
				double double_3 = 0.0;
				if (float_1 < 6f)
				{
					Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_2, ref double_3, float_4 / 2f, float_2 + float_10);
				}
				else
				{
					Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_2, ref double_3, float_4 / 2f, float_2 + float_10);
				}
				ChangeTokenizer(waypoint_1, aircraft_0, ref waypoint_0, double_3, double_2, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_0, ref unitThrottlePreset_0, ref float_6, ref strike_0.AttackMethod, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
				if (!Information.IsNothing(waypoint_1))
				{
					waypoint_1.Latitude = double_3;
					waypoint_1.Longitude = double_2;
				}
				double double_4 = 0.0;
				double double_5 = 0.0;
				if (float_1 < 6f)
				{
					Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_4, ref double_5, float_4, Math2.UpdateClass(float_2 + float_10));
				}
				else
				{
					Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_4, ref double_5, float_4, Math2.UpdateClass(float_2 + float_10));
				}
				Mission._AttackMethod attackMethod = strike_0.AttackMethod;
				if (1 == 0)
				{
				}
				float num = attackMethod switch
				{
					Mission._AttackMethod.SingleAxisStackedToT_20Sec => ((int)_FlightSize_0 - 1) * 20, 
					Mission._AttackMethod.SingleAxisStackedToT_30Sec => ((int)_FlightSize_0 - 1) * 30, 
					Mission._AttackMethod.SingleAxisStackedToT_40Sec => ((int)_FlightSize_0 - 1) * 40, 
					_ => 0f, 
				};
				if (1 == 0)
				{
				}
				float float_11 = num;
				EnableTokenizer(waypoint_2, aircraft_0, ref waypoint_0, double_5, double_4, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_0, ref unitThrottlePreset_0, ref float_6, ref strike_0.AttackMethod, ref formation_0, ref float_11, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
				if (!Information.IsNothing(waypoint_2))
				{
					waypoint_2.Latitude = double_3;
					waypoint_2.Longitude = double_2;
				}
				if (bool_2)
				{
					Waypoint waypoint_3 = (Information.IsNothing(waypoint_2) ? waypoint_0[waypoint_0.Count() - 1] : waypoint_2);
					Aircraft aircraft_ = aircraft_0;
					double double_6 = double_5;
					double double_7 = double_4;
					Waypoint.Formation formation_ = Waypoint.Formation.Spread;
					FindTokenizer(waypoint_3, aircraft_, ref waypoint_0, double_6, double_7, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_0, ref unitThrottlePreset_0, ref float_6, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
				}
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101395", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static bool CountTokenizer(ref Strike strike_0, ref Mission.Flight flight_0, ref Waypoint[] waypoint_0, ref Mission._FlightSize _FlightSize_0, ref Aircraft aircraft_0, ref Contact contact_0, double double_0, double double_1, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, ref Waypoint.Formation formation_0, ref float float_6, ref float float_7, ref float float_8, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, float float_9, float float_10, AircraftMissionProfile aircraftMissionProfile_0, bool bool_1, bool bool_2, ref Waypoint waypoint_1, ref Waypoint waypoint_2, ref bool bool_3, bool bool_4)
	{
		try
		{
			float_4 = 15f;
			if (_FlightSize_0 > 1 && strike_0.AttackMethod == Mission._AttackMethod.BananaSplit)
			{
				Waypoint waypoint = null;
				Waypoint waypoint2 = null;
				Waypoint waypoint3 = null;
				for (int i = waypoint_0.Count() - 1; i >= 0; i += -1)
				{
					Waypoint waypoint4 = waypoint_0[i];
					if (waypoint4.Type == Waypoint.WaypointType.InitialPoint || waypoint4.Type == Waypoint.WaypointType.WeaponLaunch)
					{
						waypoint = waypoint_0[i];
						if (i > 0)
						{
							waypoint2 = waypoint_0[i - 1];
						}
						if (i > 1)
						{
							waypoint3 = waypoint_0[i - 2];
						}
						break;
					}
				}
				if (!Information.IsNothing(waypoint) && !Information.IsNothing(waypoint2) && !Information.IsNothing(waypoint3))
				{
					float num = Math2.PublishClass(contact_0.GetLatitude(), contact_0.GetLongitude(), waypoint3.Latitude, waypoint3.Longitude);
					Waypoint waypoint_3 = new Waypoint();
					waypoint_3.Latitude = waypoint2.Latitude;
					waypoint_3.Longitude = waypoint2.Longitude;
					waypoint_3.TurnRate_Navigation = Waypoint.TurnRateCategory.const_6;
					Waypoint waypoint_4 = new Waypoint();
					waypoint_4.Latitude = contact_0.GetLatitude();
					waypoint_4.Longitude = contact_0.GetLongitude();
					waypoint_4.TurnRate_Navigation = Waypoint.TurnRateCategory.const_6;
					float float_11 = (bool_3 ? Math2.UpdateClass(num + 180f - 10f) : Math2.UpdateClass(num + 180f + 90f));
					List<Waypoint.FlightPlanSegment> list_ = new List<Waypoint.FlightPlanSegment>();
					float num2 = Math2.PublishClass(waypoint_3.Latitude, waypoint_3.Longitude, waypoint_4.Latitude, waypoint_4.Longitude);
					Misc.TurnDirection turnDirection = Misc.CountValue(float_11, num2);
					float float_12 = 0f;
					switch (turnDirection)
					{
					case Misc.TurnDirection.TurnRight:
						float_12 = 9f;
						break;
					case Misc.TurnDirection.TurnLeft:
						float_12 = -9f;
						break;
					}
					bool bool_5 = false;
					Waypoint waypoint_5 = null;
					CreateFlightPlanCurve(ref float_11, ref list_, ref waypoint_4, ref waypoint_3, ref waypoint_5, ref float_6, float_6, ref flight_0, float_12, turnDirection, num2, ref bool_5, bool_1: true, "", waypoint_0);
					if (!bool_5)
					{
						double startLatitude = list_[list_.Count - 1].StartLatitude;
						double startLongitude = list_[list_.Count - 1].StartLongitude;
						float num3 = Math2.VerifyClass(contact_0.GetLatitude(), contact_0.GetLongitude(), startLatitude, startLongitude);
						float float_13 = Math2.PublishClass(contact_0.GetLatitude(), contact_0.GetLongitude(), startLatitude, startLongitude);
						if (num3 <= float_1)
						{
							if (num3 > 1f)
							{
								num3 -= 1f;
							}
							double longitude = contact_0.GetLongitude();
							double latitude = contact_0.GetLatitude();
							double double_8 = (waypoint_5 = waypoint).Longitude;
							Waypoint waypoint5 = waypoint;
							double double_9 = waypoint5.Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_8, ref double_9, num3, float_13);
							waypoint5.Latitude = double_9;
							waypoint_5.Longitude = double_8;
						}
						else if (float_1 < 6f)
						{
							double longitude2 = contact_0.GetLongitude();
							double latitude2 = contact_0.GetLatitude();
							double double_10 = (waypoint_5 = waypoint).Longitude;
							Waypoint waypoint6 = waypoint;
							double double_11 = waypoint6.Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(longitude2, latitude2, ref double_10, ref double_11, 5f, float_13);
							waypoint6.Latitude = double_11;
							waypoint_5.Longitude = double_10;
						}
						else
						{
							double longitude3 = contact_0.GetLongitude();
							double latitude3 = contact_0.GetLatitude();
							Waypoint waypoint7;
							double double_12 = (waypoint7 = waypoint).Longitude;
							double double_13 = (waypoint_5 = waypoint).Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(longitude3, latitude3, ref double_12, ref double_13, 5f + float_1, float_13);
							waypoint_5.Latitude = double_13;
							waypoint7.Longitude = double_12;
						}
					}
				}
				double_0 = waypoint.Latitude;
				double_1 = waypoint.Longitude;
				if (float_3 > float_5)
				{
					float num4 = (bool_3 ? ((float)(((int)_FlightSize_0 - 1) * 20)) : ((float)(((int)_FlightSize_0 - 1) * 40))) * float_6 / 3600f;
					num4 = (float)Math.Sqrt(Math.Pow(float_4 + num4 / 2f, 2.0) - Math.Pow(float_4, 2.0));
					double double_14 = 0.0;
					double double_15 = 0.0;
					if (float_1 < 6f)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_14, ref double_15, float_4 / 2f, float_2 + float_10);
					}
					else
					{
						Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_14, ref double_15, float_4 / 2f, float_2 + float_10);
					}
					if (bool_4)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(double_14, double_15, ref double_14, ref double_15, num4, Math2.UpdateClass(float_2 + float_10 + float_9));
					}
					else
					{
						Geodesic_EdWilliams.CalcPoint_Williams(double_14, double_15, ref double_14, ref double_15, num4, Math2.UpdateClass(float_2 + float_10 + float_9 + 180f));
					}
					ChangeTokenizer(waypoint_1, aircraft_0, ref waypoint_0, double_15, double_14, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_0, ref unitThrottlePreset_0, ref float_6, ref strike_0.AttackMethod, ref formation_0, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
					if (!Information.IsNothing(waypoint_1))
					{
						waypoint_1.Latitude = double_15;
						waypoint_1.Longitude = double_14;
					}
					double double_2 = 0.0;
					double double_3 = 0.0;
					if (float_1 < 6f)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_2, ref double_3, float_4, Math2.UpdateClass(float_2 + float_10));
					}
					else
					{
						Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_2, ref double_3, float_4, Math2.UpdateClass(float_2 + float_10));
					}
					Waypoint waypoint_6 = waypoint_2;
					Aircraft aircraft_ = aircraft_0;
					double double_4 = double_3;
					double double_5 = double_2;
					ref Mission._AttackMethod attackMethod = ref strike_0.AttackMethod;
					float float_14 = 0f;
					EnableTokenizer(waypoint_6, aircraft_, ref waypoint_0, double_4, double_5, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_0, ref unitThrottlePreset_0, ref float_6, ref attackMethod, ref formation_0, ref float_14, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
					if (!Information.IsNothing(waypoint_2))
					{
						waypoint_2.Latitude = double_3;
						waypoint_2.Longitude = double_2;
					}
					if (bool_2)
					{
						Waypoint waypoint_7 = (Information.IsNothing(waypoint_2) ? waypoint_0[waypoint_0.Count() - 1] : waypoint_2);
						Aircraft aircraft_2 = aircraft_0;
						double double_6 = double_3;
						double double_7 = double_2;
						Waypoint.Formation formation_ = Waypoint.Formation.Spread;
						FindTokenizer(waypoint_7, aircraft_2, ref waypoint_0, double_6, double_7, aircraftMissionProfile_0, ref float_7, ref float_8, ref bool_0, ref unitThrottlePreset_0, ref float_6, ref formation_, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military);
					}
					return true;
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101396", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal static float CustomizeTokenizer(ref Scenario scenario_0, ref Aircraft aircraft_0)
	{
		try
		{
			if (Information.IsNothing(aircraft_0.Loadout))
			{
				return 0f;
			}
			float formUpAltitude = aircraft_0.Loadout.GetMissionProfile(scenario_0).FormUpAltitude;
			int num = aircraft_0.Loadout.GetMissionProfile(scenario_0).FormUpTime * 60;
			if (num > 0 && formUpAltitude > 0f)
			{
				return aircraft_0.Kinematics.FindDic(num, ActiveUnit.Throttle.Cruise, formUpAltitude, aircraft_0.Kinematics.GetMaximumSpeed(formUpAltitude, ActiveUnit.Throttle.Cruise, bool_0: false), bool_0: false);
			}
			return 0f;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200608", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	private static void CloneTokenizer(ref Scenario scenario_0, ref Mission mission_0, object object_0, bool bool_0, ref bool bool_1)
	{
		try
		{
			int num = ((IEnumerable<Waypoint>)object_0).Count();
			Doctrine._UseUnderwayRefuelAndReplenishment? useReplenishment = mission_0.Doctrine.GetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			Doctrine._UnderwayRefuelAndReplenishmentSelection? replenishmentSelection = mission_0.Doctrine.GetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			if (bool_0)
			{
				int num2 = num - 1;
				for (int i = 0; i <= num2; i++)
				{
					Waypoint waypoint = (Waypoint)((object[])object_0)[i];
					switch (waypoint.Type)
					{
					case Waypoint.WaypointType.Split:
					case Waypoint.WaypointType.StrikeIngress:
						if (waypoint.Creator == Waypoint.WaypointCreator.Pathfinder)
						{
							if (i + 1 <= num && ((Waypoint)((object[])object_0)[i + 1]).Type != Waypoint.WaypointType.StrikeIngress)
							{
								waypoint.Doctrine.SetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Doctrine._UseUnderwayRefuelAndReplenishment.Never);
								waypoint.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, replenishmentSelection);
							}
							else if (i + 1 <= num && ((Waypoint)((object[])object_0)[i + 1]).FlightFormation == Waypoint.Formation.Split)
							{
								waypoint.Doctrine.SetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Doctrine._UseUnderwayRefuelAndReplenishment.Never);
								waypoint.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, replenishmentSelection);
							}
							else
							{
								waypoint.Doctrine.SetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, useReplenishment);
								waypoint.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, replenishmentSelection);
							}
						}
						else
						{
							waypoint.Doctrine.SetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Doctrine._UseUnderwayRefuelAndReplenishment.Never);
							waypoint.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, replenishmentSelection);
						}
						break;
					case Waypoint.WaypointType.StrikeEgress:
						if (i > 0 && ((Waypoint)((object[])object_0)[i - 1]).FlightFormation == Waypoint.Formation.Split)
						{
							waypoint.Doctrine.SetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Doctrine._UseUnderwayRefuelAndReplenishment.Never);
							waypoint.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, replenishmentSelection);
						}
						else
						{
							waypoint.Doctrine.SetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, useReplenishment);
							waypoint.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, replenishmentSelection);
						}
						break;
					case Waypoint.WaypointType.TakeOff:
						if (i + 1 <= num && (((Waypoint)((object[])object_0)[i + 1]).Type == Waypoint.WaypointType.Assemble || ((Waypoint)((object[])object_0)[i + 1]).Type == Waypoint.WaypointType.HoldStart || ((Waypoint)((object[])object_0)[i + 1]).Type == Waypoint.WaypointType.HoldEnd))
						{
							waypoint.Doctrine.SetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Doctrine._UseUnderwayRefuelAndReplenishment.Never);
							waypoint.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, replenishmentSelection);
						}
						else
						{
							waypoint.Doctrine.SetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, useReplenishment);
							waypoint.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, replenishmentSelection);
						}
						break;
					default:
						waypoint.Doctrine.SetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, useReplenishment);
						waypoint.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, replenishmentSelection);
						break;
					case Waypoint.WaypointType.Land:
						waypoint.Doctrine.SetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, useReplenishment);
						waypoint.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, replenishmentSelection);
						break;
					case Waypoint.WaypointType.InitialPoint:
					case Waypoint.WaypointType.Target:
					case Waypoint.WaypointType.WeaponLaunch:
					case Waypoint.WaypointType.WeaponTarget:
						waypoint.Doctrine.SetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Doctrine._UseUnderwayRefuelAndReplenishment.Never);
						waypoint.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, replenishmentSelection);
						break;
					}
				}
			}
			else
			{
				byte? b = (byte?)useReplenishment;
				bool? flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
				if (((!flag) ?? flag).GetValueOrDefault())
				{
					bool_1 = true;
				}
				int num3 = num - 1;
				for (int j = 0; j <= num3; j++)
				{
					Waypoint obj = (Waypoint)((object[])object_0)[j];
					obj.Doctrine.SetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, useReplenishment);
					obj.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, replenishmentSelection);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200609", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal unsafe static bool ConnectTokenizer(Scenario scenario_0, Mission mission, object object_0, Mission.Flight flight_0, ref Waypoint[] waypoint_0, ref float float_0, ref float float_1, bool bool_0, bool bool_1, bool bool_2, bool bool_3, bool bool_4, bool bool_5, bool bool_6, float float_2, float float_3, Misc.TurnDirection turnDirection_0, bool? nullable_0, bool bool_7, bool bool_8, DateTime? nullable_1, DateTime? nullable_2, bool bool_9)
	{
		try
		{
			if (mission.LaunchMissionWithoutTankersInPlace)
			{
				bool_0 = false;
			}
			if (waypoint_0 != null && waypoint_0.Count() != 0)
			{
				if (object_0 == null)
				{
					float_1 = float.MaxValue;
				}
				else if (float_1 <= 0f)
				{
					float num = 0f;
					foreach (FuelRec item in ((ActiveUnit)object_0).Fuel_ReadOnly)
					{
						num += (float)item.MaxQuantity;
					}
					float_1 = num - ((ActiveUnit)object_0).Kinematics.ReserveFuel;
				}
				float float_4 = 0f;
				if (bool_5)
				{
					if (mission.MissionClass == Mission._MissionClass.Strike && mission is Strike strike)
					{
						if (Information.IsNothing(nullable_0))
						{
							nullable_0 = ((Information.IsNothing(mission) || mission.MissionClass != Mission._MissionClass.Strike || !strike.UsePlanner) ? new bool?(false) : new bool?(true));
						}
					}
					else if (Information.IsNothing(nullable_0))
					{
						nullable_0 = false;
					}
					try
					{
						ResetWaypointBoundTimes(ref waypoint_0, ref *(ActiveUnit*)(&object_0), bool_0: false);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 200610", "");
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					if (bool_1)
					{
						flight_0.HasCriticalError = false;
						propertyConsumer = false;
						if (!Information.IsNothing(_ReaderConsumer))
						{
							_ReaderConsumer.Clear();
						}
					}
					DetermineDistanceFlown(waypoint_0, null, ref flight_0, ref float_4, bool_0: false, "");
					Waypoint[] waypoint_;
					if (bool_2)
					{
						waypoint_ = null;
						if (ComputeTokenizer(ref *(ActiveUnit*)(&object_0), ref waypoint_0, ref waypoint_, bool_0: false, ref flight_0, ""))
						{
							for (int i = 0; i <= 10; i++)
							{
								DetermineDistanceFlown(waypoint_0, null, ref flight_0, ref float_4, bool_0: false, "");
								waypoint_ = null;
								if (!ComputeTokenizer(ref *(ActiveUnit*)(&object_0), ref waypoint_0, ref waypoint_, bool_0: false, ref flight_0, ""))
								{
									break;
								}
							}
						}
					}
					ActiveUnit activeUnit_;
					if (((ScenarioObject)object_0).IsGroup)
					{
						activeUnit_ = ((Group)object_0).Units.Values.ElementAtOrDefault(0);
						bool bool_10 = true;
						DetermineTimesAndFuelQty(ref scenario_0, ref mission, ref flight_0, ref waypoint_0, ref activeUnit_, ref float_0, ref float_1, ref bool_10, bool_1: false, bool_4, "", bool_3: false);
					}
					else
					{
						bool bool_11 = true;
						DetermineTimesAndFuelQty(ref scenario_0, ref mission, ref flight_0, ref waypoint_0, ref *(ActiveUnit*)(&object_0), ref float_0, ref float_1, ref bool_11, bool_1: false, bool_4, "", bool_3: false);
					}
					if (bool_0 && float_0 > float_1)
					{
						return false;
					}
					Side side_ = (activeUnit_ = (ActiveUnit)object_0).GetUnitSide();
					CalculateFuelQtyAndTimesForWeaponRoutes(ref scenario_0, ref side_, bool_3, bool_1, ref flight_0, "", ref *(ActiveUnit*)(&object_0), Mission.Flight.FlightElement.LeadElement);
					activeUnit_.SetUnitSide(bool_0: false, side_);
					if (bool_3)
					{
						DetermineWaypointZuluTimes(ref scenario_0, ref mission, ref flight_0, ref waypoint_0, ref *(ActiveUnit*)(&object_0), bool_0: false, bool_4, bool_8, nullable_1, nullable_2, Mission.Flight.FlightElement.LeadElement);
					}
					DetermineBoundSpeedsAndTimes(ref waypoint_0, bool_0: false);
					DetermineLocalTimeForWaypoints(ref scenario_0, ref waypoint_0, bool_0: false);
					waypoint_ = waypoint_0;
					Waypoint[] array = waypoint_;
					Waypoint[] array2 = array;
					foreach (Waypoint obj in array2)
					{
						obj.Leg_FuelRemaining_LeadElementWingman = 0f;
						obj.Leg_FuelRemaining_SecondElement = 0f;
						obj.Leg_FuelRemaining_SecondElementWingman = 0f;
						obj.Leg_FuelRemaining_ThirdElement = 0f;
						obj.Leg_FuelRemaining_ThirdElementWingman = 0f;
					}
				}
				if (bool_6)
				{
					SelectTokenizer(scenario_0, object_0, mission, flight_0, ref waypoint_0, bool_4, float_4, float_1, float_2, float_3, turnDirection_0, nullable_0.Value, bool_7, ref bool_8);
				}
				if (bool_0)
				{
					Waypoint waypoint = waypoint_0[waypoint_0.Count() - 1];
					if (waypoint.Leg_FuelRemaining_LeadElementWingman < 0f)
					{
						return false;
					}
					if (waypoint.Leg_FuelRemaining_SecondElement < 0f)
					{
						return false;
					}
					if (waypoint.Leg_FuelRemaining_SecondElementWingman < 0f)
					{
						return false;
					}
					if (waypoint.Leg_FuelRemaining_ThirdElement < 0f)
					{
						return false;
					}
					if (waypoint.Leg_FuelRemaining_ThirdElementWingman < 0f)
					{
						return false;
					}
				}
				MoveTokenizer(ref waypoint_0);
				if (bool_1)
				{
					RestartTokenizer(ref scenario_0, ref mission, ref flight_0, ref waypoint_0, bool_9);
				}
				return true;
			}
			return false;
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 101304", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static void MoveTokenizer(ref Waypoint[] waypoint_0)
	{
		int num = 1;
		int num2 = waypoint_0.Count() - 1;
		for (int i = 0; i <= num2; i++)
		{
			Waypoint waypoint = waypoint_0[i];
			if (waypoint.Type == Waypoint.WaypointType.WeaponTarget)
			{
				waypoint.Description = "-";
				if (!Information.IsNothing(waypoint.Waypoint_LeadElementWingman))
				{
					waypoint.Waypoint_LeadElementWingman.Description = "-";
				}
				if (!Information.IsNothing(waypoint.Waypoint_SecondElement))
				{
					waypoint.Waypoint_SecondElement.Description = "-";
				}
				if (!Information.IsNothing(waypoint.Waypoint_SecondElementWingman))
				{
					waypoint.Waypoint_SecondElementWingman.Description = "-";
				}
				if (!Information.IsNothing(waypoint.Waypoint_ThirdElement))
				{
					waypoint.Waypoint_ThirdElement.Description = "-";
				}
				if (!Information.IsNothing(waypoint.Waypoint_ThirdElementWingman))
				{
					waypoint.Waypoint_ThirdElementWingman.Description = "-";
				}
				continue;
			}
			waypoint.Description = Conversions.ToString(num);
			if (!Information.IsNothing(waypoint.Waypoint_LeadElementWingman))
			{
				waypoint.Waypoint_LeadElementWingman.Description = Conversions.ToString(num);
			}
			if (!Information.IsNothing(waypoint.Waypoint_SecondElement))
			{
				waypoint.Waypoint_SecondElement.Description = Conversions.ToString(num);
			}
			if (!Information.IsNothing(waypoint.Waypoint_SecondElementWingman))
			{
				waypoint.Waypoint_SecondElementWingman.Description = Conversions.ToString(num);
			}
			if (!Information.IsNothing(waypoint.Waypoint_ThirdElement))
			{
				waypoint.Waypoint_ThirdElement.Description = Conversions.ToString(num);
			}
			if (!Information.IsNothing(waypoint.Waypoint_ThirdElementWingman))
			{
				waypoint.Waypoint_ThirdElementWingman.Description = Conversions.ToString(num);
			}
			num++;
		}
	}

	public static void ResetWaypointBoundTimes(ref Waypoint[] waypoint_0, ref ActiveUnit activeUnit_0, bool bool_0)
	{
		try
		{
			int num = waypoint_0.Count();
			bool flag = false;
			int num2 = num - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (bool_0 && (i == 0 || i == 1 || i == num - 1))
				{
					continue;
				}
				Waypoint waypoint = waypoint_0[i];
				if (Information.IsNothing(waypoint))
				{
					continue;
				}
				if (waypoint.Type == Waypoint.WaypointType.StationEnd && waypoint.Station_Time == 0f)
				{
					flag = true;
				}
				if (flag)
				{
					waypoint.TimeFixed = Waypoint.FixedFree.Free;
				}
				if (waypoint.SpeedFixed == Waypoint.FixedFree.Bound || waypoint.SpeedFixed == Waypoint.FixedFree.None)
				{
					waypoint.SpeedFixed = Waypoint.FixedFree.Free;
				}
				if (waypoint.TimeFixed == Waypoint.FixedFree.Bound || waypoint.TimeFixed == Waypoint.FixedFree.None)
				{
					waypoint.TimeFixed = Waypoint.FixedFree.Free;
				}
				if (waypoint.SpeedFixed == Waypoint.FixedFree.Free)
				{
					if (waypoint.Type != Waypoint.WaypointType.TakeOff && waypoint.Type != Waypoint.WaypointType.Land)
					{
						if (!bool_0)
						{
							waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
							waypoint.DesiredSpeed = null;
							waypoint.DesiredSpeedOverride = null;
						}
					}
					else
					{
						waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Loiter;
						waypoint.DesiredSpeed = null;
						waypoint.DesiredSpeedOverride = null;
					}
				}
				if (Information.IsNothing(waypoint.ThrottlePreset) || waypoint.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.FullStop)
				{
					waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
				}
				if (activeUnit_0 == null || !Information.IsNothing(waypoint.DesiredSpeed) || waypoint.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
				{
					continue;
				}
				if (Information.IsNothing(waypoint.DesiredAltitude))
				{
					if (!Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing) && waypoint.TerrainFollowing)
					{
						waypoint.DesiredSpeed = activeUnit_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
					}
					else
					{
						waypoint.DesiredSpeed = activeUnit_0.Kinematics.GetMaximumSpeed(0f, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
					}
				}
				else
				{
					waypoint.DesiredSpeed = activeUnit_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200611", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void DeleteTokenizer(ref Scenario scenario_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Waypoint[] waypoint_0, ref ActiveUnit activeUnit_0, Mission.Flight.FlightElement flightElement_0)
	{
		int num = waypoint_0.Count();
		try
		{
			if (mission_0.MissionClass != Mission._MissionClass.Strike)
			{
				return;
			}
			int num2 = num - 1;
			for (int i = 0; i <= num2; i++)
			{
				Waypoint waypoint = waypoint_0[i];
				if (Information.IsNothing(waypoint))
				{
					continue;
				}
				waypoint.Leg_Time_Weapon = 0f;
				if (i <= 0)
				{
					continue;
				}
				if (waypoint.Type != Waypoint.WaypointType.Target && waypoint.Type != Waypoint.WaypointType.WeaponTarget)
				{
					waypoint.Leg_Time_Weapon = 0f;
					continue;
				}
				if (waypoint.TargeteeringMethod == Mission._TargeteeringMethod.Individual)
				{
					continue;
				}
				waypoint.Leg_Time_Weapon = 0f;
				if (Information.IsNothing(activeUnit_0) && waypoint.PreferredWeaponID <= 0)
				{
					break;
				}
				Weapon weapon = null;
				if (waypoint.PreferredWeaponID == 0)
				{
					if (!Information.IsNothing(((Aircraft)activeUnit_0).Loadout) && !Information.IsNothing(flight_0) && !Information.IsNothing(flight_0.PrimaryTarget))
					{
						weapon = activeUnit_0.Weaponry.MostSuitableWeaponForThisTarget(flight_0.PrimaryTarget, bool_1: false, bool_2: false, bool_3: true, activeUnit_0.Doctrine);
						if (weapon != null)
						{
							waypoint.PreferredWeaponID = weapon.DBID;
						}
					}
				}
				else
				{
					weapon = Weapon.GetNewWeapon(ref scenario_0, waypoint.PreferredWeaponID, bool_0: false);
				}
				float float_;
				if (weapon != null && Weapon.IsStandOff(weapon.MaxRange_NoTargetType))
				{
					if (weapon.CruiseAltitude_AGL <= 0f)
					{
						if (weapon.CruiseAltitude_ASL <= 0f)
						{
							if (!Information.IsNothing(waypoint.DesiredAltitude))
							{
								float? desiredAltitude = waypoint.DesiredAltitude;
								if ((desiredAltitude.HasValue ? new bool?(desiredAltitude.GetValueOrDefault() > 0f) : null).GetValueOrDefault())
								{
									float_ = waypoint.DesiredAltitude.Value;
									goto IL_032c;
								}
							}
							bool? flag;
							if (Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
							{
								flag = false;
							}
							else
							{
								float? desiredAltitude_TerrainFollowing = waypoint.DesiredAltitude_TerrainFollowing;
								flag = (desiredAltitude_TerrainFollowing.HasValue ? new bool?(desiredAltitude_TerrainFollowing.GetValueOrDefault() > 0f) : null);
							}
							bool? flag2 = flag;
							float_ = (((!flag2).GetValueOrDefault() || !waypoint.TerrainFollowing || !flag2.HasValue) ? 0f : waypoint.DesiredAltitude_TerrainFollowing.Value);
						}
						else
						{
							float_ = weapon.CruiseAltitude_AGL;
						}
					}
					else
					{
						float_ = weapon.CruiseAltitude_AGL;
					}
					goto IL_032c;
				}
				waypoint.Leg_Time_Weapon = 0f;
				break;
				IL_032c:
				double endLatitude = waypoint.FlightplanPointsList[waypoint.FlightplanPointsList.Count - 1].EndLatitude;
				double endLongitude = waypoint.FlightplanPointsList[waypoint.FlightplanPointsList.Count - 1].EndLongitude;
				float num3 = ((!Information.IsNothing(waypoint_0[i - 1].DesiredAltitude)) ? waypoint_0[i - 1].DesiredAltitude.Value : ((Information.IsNothing(waypoint_0[i - 1].DesiredAltitude_TerrainFollowing) || !waypoint_0[i - 1].TerrainFollowing) ? 0f : waypoint_0[i - 1].DesiredAltitude_TerrainFollowing.Value));
				float num4 = (Information.IsNothing(waypoint_0[i - 1].DesiredSpeed) ? 0f : waypoint_0[i - 1].DesiredSpeed.Value);
				float float_2 = Math2.PublishClass(endLatitude, endLongitude, waypoint.Latitude, waypoint.Longitude);
				float float_3 = 0f;
				DLZCAche dLZCAche = new DLZCAche(activeUnit_0.ObjectID, weapon.DBID, activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), waypoint.Latitude, waypoint.Longitude, 0f, ActiveUnit_Weaponry.DLZResultEnum.None);
				ActiveUnit_Weaponry.DLZResultEnum dLZResultEnum = ActiveUnit_Weaponry.DLZResultEnum.None;
				bool flag3 = false;
				foreach (DLZCAche item2 in Misc.EnableRequest(ActiveUnit_Weaponry.DLZCacheList))
				{
					if (item2 != null && dLZCAche.Equals(item2))
					{
						dLZResultEnum = item2.ResultValue;
						waypoint.Leg_Time_Weapon = item2.Time;
						flag3 = true;
						break;
					}
				}
				if (!flag3)
				{
					Scenario scenario_ = scenario_0;
					int dBID = weapon.DBID;
					ActiveUnit activeUnit_ = activeUnit_0;
					float float_4 = (int)Math.Round(num3);
					int int_ = (int)Math.Round(num4);
					double longitude = waypoint.Longitude;
					double latitude = waypoint.Latitude;
					GeoPoint geoPoint_ = null;
					string string_ = null;
					dLZResultEnum = ActiveUnit_Weaponry.TargetIsWithinDLZ(scenario_, dBID, activeUnit_, endLongitude, endLatitude, float_4, int_, longitude, latitude, 0f, bool_1: false, 0, bool_2: false, 0f, bool_3: false, 0f, Contact_Base.ContactType.Aimpoint, ref geoPoint_, ref string_, bool_4: false, float_2, ActiveUnit.Throttle.Cruise, weapon.Fuel_ReadOnly[0].MaxQuantity, null, null, ref float_3).Item1;
					DLZCAche item = new DLZCAche(activeUnit_0.ObjectID, weapon.DBID, activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), waypoint.Latitude, waypoint.Longitude, float_3, dLZResultEnum);
					ActiveUnit_Weaponry.DLZCacheList.Add(item);
				}
				if (dLZResultEnum == ActiveUnit_Weaponry.DLZResultEnum.Success)
				{
					if (!flag3)
					{
						waypoint.Leg_Time_Weapon = float_3;
					}
				}
				else
				{
					float num5 = Math2.VerifyClass(waypoint.Latitude, waypoint.Longitude, endLatitude, endLongitude);
					Math2.VerifyClass(waypoint.Latitude, waypoint.Longitude, waypoint_0[i - 1].Latitude, waypoint_0[i - 1].Longitude);
					if (!Information.IsNothing(flight_0) && !Information.IsNothing(flight_0.PrimaryTarget))
					{
						float maxRangeForThisTarget = weapon.GetMaxRangeForThisTarget(activeUnit_0, flight_0.PrimaryTarget, bool_0: true, activeUnit_0.Doctrine, bool_1: false);
						if (num5 > maxRangeForThisTarget)
						{
							num5 = maxRangeForThisTarget;
						}
					}
					else
					{
						float maxRange_NoTargetType = weapon.MaxRange_NoTargetType;
						if (num5 > maxRange_NoTargetType)
						{
							num5 = maxRange_NoTargetType;
						}
					}
					float num6 = weapon.Kinematics.GetMaximumSpeed(float_, ActiveUnit.Throttle.Cruise, bool_0: false);
					waypoint.Leg_Time_Weapon = num5 / num6 * 3600f;
				}
				if (float.IsNaN(waypoint.Leg_Time_Weapon) || float.IsInfinity(waypoint.Leg_Time_Weapon))
				{
					waypoint.Leg_Time_Weapon = 0f;
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101397", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void AddTokenizer(ref Scenario scenario_0, ref ActiveUnit activeUnit_0, ref Weapon weapon_0, ref Waypoint[] waypoint_0, ref Waypoint waypoint_1, ref Waypoint waypoint_2, ref Contact contact_0, ref Mission.Flight flight_0, ref string string_0)
	{
		try
		{
			int num = waypoint_0.Count();
			float num6 = 0f;
			float float_;
			float float_2;
			if (Information.IsNothing(activeUnit_0))
			{
				float_ = 0f;
				float_2 = 0f;
			}
			else
			{
				float_ = (float)((double)activeUnit_0.Kinematics.ClimbRate_Max() * 0.4);
				float_2 = activeUnit_0.Kinematics.DiveRate_Max();
			}
			float num7 = 0f;
			float num8 = weapon_0.Fuel_ReadOnly[0].MaxQuantity;
			ActiveUnit.Throttle throttle = ActiveUnit.Throttle.FullStop;
			float num9 = 0f;
			ActiveUnit.Throttle throttle_ = ActiveUnit.Throttle.FullStop;
			float float_3 = 0f;
			int num10 = num - 1;
			Waypoint waypoint_3 = null;
			float num11 = 0f;
			float float_4 = 0f;
			for (int i = 0; i <= num10; i++)
			{
				Waypoint waypoint = waypoint_3;
				waypoint_3 = waypoint_0[i];
				float float_5 = 0f;
				float num12 = 0f;
				if (Information.IsNothing(waypoint_3))
				{
					continue;
				}
				if (i <= 0)
				{
					waypoint_3.Leg_FuelRemaining = num8;
					if (Information.IsNothing(waypoint_3.DesiredAltitude))
					{
						if (!Information.IsNothing(waypoint_3.DesiredAltitude_TerrainFollowing) && waypoint_3.TerrainFollowing)
						{
							num9 = waypoint_3.DesiredAltitude_TerrainFollowing.Value;
						}
					}
					else
					{
						num9 = waypoint_3.DesiredAltitude.Value;
					}
				}
				else
				{
					if (i > 1 && waypoint_0[i].Type == Waypoint.WaypointType.WeaponTarget && !Information.IsNothing(waypoint_0[i - 1]) && waypoint_0[i - 1].Type == Waypoint.WaypointType.WeaponTarget)
					{
						continue;
					}
					float num13;
					if (waypoint_3.Type == Waypoint.WaypointType.HoldEnd)
					{
						num13 = 0f;
					}
					else if (!Information.IsNothing(waypoint_3.Leg_Speed_Straight) && !(waypoint_3.Leg_Speed_Straight <= 0f) && waypoint_3.Leg_Distance_Straight > 0f)
					{
						if (!Information.IsNothing(flight_0) && num11 != num9)
						{
							float num2 = 0f;
							float num3 = 0f;
							num2 = activeUnit_0.Kinematics.RemoveDic(num11, num9, float_, float_2, waypoint.ThrottlePreset, waypoint_3.Leg_Speed_Straight, bool_0: false, bool_1: true, bool_2: true, ref float_4, ref float_5);
							if (waypoint.Type != Waypoint.WaypointType.TakeOff && waypoint.Type != Waypoint.WaypointType.HoldEnd && waypoint.Type != Waypoint.WaypointType.StationEnd)
							{
								if (float_4 <= waypoint_3.Leg_Distance_Straight)
								{
									num12 = waypoint_3.Leg_Distance_Straight - float_4;
									num3 = activeUnit_0.Kinematics.InterruptDic(num12, throttle, num9, waypoint_3.Leg_Speed_Straight, bool_0: false, bool_1: true, bool_2: true);
								}
								else if (waypoint_3.Type != Waypoint.WaypointType.TakeOff && waypoint_3.Type != Waypoint.WaypointType.LandingMarshal && waypoint_3.Type != Waypoint.WaypointType.Land)
								{
									if (Information.IsNothing(waypoint.Description) || Information.IsNothing(waypoint_3.Description))
									{
										MoveTokenizer(ref waypoint_0);
									}
									DestroyTokenizer(ref flight_0, ref waypoint_3, "警告！任务" + flight_0.ParentMissionOrPackageName + "，飞行编队" + flight_0.Callsign + string_0 + "： 航点" + waypoint.Description + "离航点太近了" + waypoint_3.Description + "。高度变化的距离太短（" + Conversions.ToString(Math.Round(float_4, 1)) + "海里 vs " + Conversions.ToString(Math.Round(waypoint_3.Leg_Distance_Straight, 1)) + "海里）。由于下一航段需要继续攀升，估计增加了额外的燃料。注意：由于速度与高度问题，这可能会导致航点时间偏差。", bool_0: false);
								}
							}
							else
							{
								num12 = 0f;
								num3 = 0f;
							}
							num13 = num2 + num3;
						}
						else
						{
							num13 = activeUnit_0.Kinematics.InterruptDic(waypoint_3.Leg_Distance_Straight, throttle, num9, waypoint_3.Leg_Speed_Straight, bool_0: false, bool_1: true, bool_2: true);
						}
					}
					else
					{
						num13 = 0f;
					}
					if (waypoint_3.Type == Waypoint.WaypointType.HoldEnd)
					{
						num13 += 0f;
					}
					else if (!Information.IsNothing(waypoint_3.Leg_Speed_Turn) && waypoint_3.Leg_Speed_Turn > 0f && waypoint_3.Leg_Distance_Turn > 0f)
					{
						num13 += activeUnit_0.Kinematics.InterruptDic(waypoint_3.Leg_Distance_Turn, throttle_, float_3, waypoint_3.Leg_Speed_Turn, bool_0: false, bool_1: true, bool_2: true);
					}
					if (!Information.IsNothing(waypoint_3.Time_Zulu) && waypoint_3.Hold_Time > 0f)
					{
						if (!Information.IsNothing(waypoint_3.Leg_Speed_Straight) && waypoint_3.Leg_Speed_Straight > 0f)
						{
							float float_6 = waypoint_3.Leg_Speed_Straight * (waypoint_3.Hold_Time / 3600f);
							num13 += activeUnit_0.Kinematics.InterruptDic(float_6, throttle, num9, waypoint_3.Leg_Speed_Straight, bool_0: false, bool_1: true, bool_2: true);
						}
						else
						{
							num13 = 0f;
						}
					}
					if (waypoint_3.SpacingManeuver_Time > 0f)
					{
						float float_7 = waypoint_3.Leg_Speed_Straight * (waypoint_3.SpacingManeuver_Time / 3600f);
						num13 += activeUnit_0.Kinematics.InterruptDic(float_7, ActiveUnit.Throttle.Loiter, float_3, waypoint_3.Leg_Speed_Straight, bool_0: false, bool_1: true, bool_2: true);
					}
					if (!Information.IsNothing(waypoint_3.Time_Zulu) && waypoint_3.Type == Waypoint.WaypointType.StationEnd && waypoint_3.Station_Time > 0f)
					{
						float float_8 = waypoint_3.Leg_Speed_Straight * (waypoint_3.Station_Time / 3600f);
						num13 += activeUnit_0.Kinematics.InterruptDic(float_8, throttle, num9, waypoint_3.Leg_Speed_Straight, bool_0: false, bool_1: true, bool_2: true);
					}
					waypoint_3.Leg_FuelRequired = num13;
					num7 += num13;
					waypoint_3.Leg_FuelRemaining = num8 - num7;
					if (waypoint_3.Type == Waypoint.WaypointType.HoldEnd)
					{
						waypoint_3.Leg_Time_Straight = 0f;
					}
					else if (!Information.IsNothing(waypoint_3.Leg_Speed_Straight) && !(waypoint_3.Leg_Speed_Straight <= 0f) && waypoint_3.Leg_Distance_Straight > 0f)
					{
						if (!(float_5 <= 0f) && num12 > 0f)
						{
							waypoint_3.Leg_Time_Straight = float_5 + num12 / waypoint_3.Leg_Speed_Straight * 3600f;
						}
						else
						{
							waypoint_3.Leg_Time_Straight = waypoint_3.Leg_Distance_Straight / waypoint_3.Leg_Speed_Straight * 3600f;
						}
					}
					else
					{
						waypoint_3.Leg_Time_Straight = 0f;
					}
					if (waypoint_3.Type == Waypoint.WaypointType.StationEnd)
					{
						waypoint_3.Leg_Time_Turn = 0f;
					}
					else if (waypoint_3.Type == Waypoint.WaypointType.HoldEnd)
					{
						waypoint_3.Leg_Time_Turn = 0f;
					}
					else if (!Information.IsNothing(waypoint_3.Leg_Speed_Turn) && !(waypoint_3.Leg_Speed_Turn <= 0f) && waypoint_3.Leg_Distance_Turn > 0f)
					{
						waypoint_3.Leg_Time_Turn = waypoint_3.Leg_Distance_Turn / waypoint_3.Leg_Speed_Turn * 3600f;
					}
					else
					{
						waypoint_3.Leg_Time_Turn = 0f;
					}
					float num4;
					float num5;
					if (Information.IsNothing(waypoint_3.Time_Zulu))
					{
						num4 = 0f;
						num5 = 0f;
					}
					else
					{
						num4 = waypoint_3.Hold_Time;
						num5 = waypoint_3.Station_Time;
					}
					num6 = (waypoint_3.Leg_TotalTime = num6 + (waypoint_3.Leg_Time_Straight + waypoint_3.Leg_Time_Turn + num4 + num5 + waypoint_3.SpacingManeuver_Time));
				}
				num11 = num9;
				if (i > 0 && waypoint_3.Type != Waypoint.WaypointType.TakeOff)
				{
					throttle_ = throttle;
					float_3 = num9;
				}
				if (Information.IsNothing(waypoint_3.DesiredAltitude))
				{
					if (!Information.IsNothing(waypoint_3.DesiredAltitude_TerrainFollowing) && waypoint_3.TerrainFollowing)
					{
						num9 = waypoint_3.DesiredAltitude_TerrainFollowing.Value;
					}
				}
				else
				{
					num9 = waypoint_3.DesiredAltitude.Value;
				}
				if (waypoint_3.Type == Waypoint.WaypointType.TakeOff)
				{
					throttle_ = throttle;
					float_3 = num9;
					num11 = Math.Max((int)Terrain.GetElevation(waypoint_3.Latitude, waypoint_3.Longitude, bool_0: false, scenario_0), 0);
				}
			}
			waypoint_1.Leg_Time_Weapon = 88f;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101397", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void DetermineWaypointZuluTimes(ref Scenario scenario_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Waypoint[] waypoint_0, ref ActiveUnit activeUnit_0, bool bool_0, bool bool_1, bool bool_2, DateTime? nullable_0, DateTime? nullable_1, Mission.Flight.FlightElement flightElement_0)
	{
		int num = -1;
		int num2 = waypoint_0.Count();
		try
		{
			DeleteTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref activeUnit_0, flightElement_0);
			if (bool_1 && !bool_0)
			{
				Mission.Flight.SetInitialFlightPlanTimes(ref scenario_0, ref mission_0, waypoint_0, bool_2, nullable_0, nullable_1);
			}
			int num3 = num2 - 1;
			for (int i = 0; i <= num3; i++)
			{
				Waypoint waypoint = waypoint_0[i];
				if (Information.IsNothing(waypoint) || (bool_0 && (waypoint.FlightFormation != Waypoint.Formation.Split || i == waypoint_0.Count() - 1)))
				{
					continue;
				}
				if ((waypoint.Type != Waypoint.WaypointType.Target && waypoint.Type != Waypoint.WaypointType.WeaponTarget) || (Information.IsNothing(nullable_1) && (bool_0 || ((Information.IsNothing(waypoint.Time_Zulu) || waypoint.Leg_Time_Weapon != 0f) && (Information.IsNothing(waypoint.Time_Zulu_Weapon) || !(waypoint.Leg_Time_Weapon > 0f))) || (waypoint.TimeFixed != Waypoint.FixedFree.Fixed && waypoint.TimeFixed != Waypoint.FixedFree.Relative))))
				{
					if (waypoint.TimeFixed == Waypoint.FixedFree.Fixed || waypoint.TimeFixed == Waypoint.FixedFree.Relative)
					{
						num = i;
						if (Information.IsNothing(nullable_1))
						{
							break;
						}
					}
					continue;
				}
				if (waypoint.Leg_Time_Weapon <= 0f)
				{
					if (Information.IsNothing(nullable_1))
					{
						nullable_1 = waypoint.Time_Zulu;
					}
					waypoint.Time_Zulu = nullable_1;
					waypoint.Time_Zulu_Weapon = null;
				}
				else
				{
					if (Information.IsNothing(nullable_1))
					{
						nullable_1 = waypoint.Time_Zulu_Weapon;
					}
					waypoint.Time_Zulu = nullable_1.Value.AddSeconds(0f - waypoint.Leg_Time_Weapon);
					waypoint.Time_Zulu_Weapon = nullable_1;
				}
				waypoint.TimeFixed = Waypoint.FixedFree.Fixed;
				num = i;
				waypoint.DesiredSpeedOverride = waypoint.DesiredSpeed;
				if (waypoint.FlightFormation == Waypoint.Formation.Split)
				{
					break;
				}
				if (!Information.IsNothing(waypoint.Waypoint_LeadElementWingman))
				{
					if (waypoint.Waypoint_LeadElementWingman.Leg_Time_Weapon <= 0f)
					{
						waypoint.Waypoint_LeadElementWingman.Time_Zulu = nullable_1;
						waypoint.Waypoint_LeadElementWingman.Time_Zulu_Weapon = null;
					}
					else
					{
						waypoint.Waypoint_LeadElementWingman.Time_Zulu = nullable_1.Value.AddSeconds(0f - waypoint.Waypoint_LeadElementWingman.Leg_Time_Weapon);
						waypoint.Waypoint_LeadElementWingman.Time_Zulu_Weapon = nullable_1;
					}
					waypoint.Waypoint_LeadElementWingman.TimeFixed = Waypoint.FixedFree.Fixed;
				}
				if (!Information.IsNothing(waypoint.Waypoint_SecondElement))
				{
					if (waypoint.Waypoint_SecondElement.Leg_Time_Weapon <= 0f)
					{
						waypoint.Waypoint_SecondElement.Time_Zulu = nullable_1;
						waypoint.Waypoint_SecondElement.Time_Zulu_Weapon = null;
					}
					else
					{
						waypoint.Waypoint_SecondElement.Time_Zulu = nullable_1.Value.AddSeconds(0f - waypoint.Waypoint_SecondElement.Leg_Time_Weapon);
						waypoint.Waypoint_SecondElement.Time_Zulu_Weapon = nullable_1;
					}
					waypoint.Waypoint_SecondElement.TimeFixed = Waypoint.FixedFree.Fixed;
				}
				if (!Information.IsNothing(waypoint.Waypoint_SecondElementWingman))
				{
					if (waypoint.Waypoint_SecondElementWingman.Leg_Time_Weapon <= 0f)
					{
						waypoint.Waypoint_SecondElementWingman.Time_Zulu = nullable_1;
						waypoint.Waypoint_SecondElementWingman.Time_Zulu_Weapon = null;
					}
					else
					{
						waypoint.Waypoint_SecondElementWingman.Time_Zulu = nullable_1.Value.AddSeconds(0f - waypoint.Waypoint_SecondElementWingman.Leg_Time_Weapon);
						waypoint.Waypoint_SecondElementWingman.Time_Zulu_Weapon = nullable_1;
					}
					waypoint.Waypoint_SecondElementWingman.TimeFixed = Waypoint.FixedFree.Fixed;
				}
				if (!Information.IsNothing(waypoint.Waypoint_ThirdElement))
				{
					if (waypoint.Waypoint_ThirdElement.Leg_Time_Weapon <= 0f)
					{
						waypoint.Waypoint_ThirdElement.Time_Zulu = nullable_1;
						waypoint.Waypoint_ThirdElement.Time_Zulu_Weapon = null;
					}
					else
					{
						waypoint.Waypoint_ThirdElement.Time_Zulu = nullable_1.Value.AddSeconds(0f - waypoint.Waypoint_ThirdElement.Leg_Time_Weapon);
						waypoint.Waypoint_ThirdElement.Time_Zulu_Weapon = nullable_1;
					}
					waypoint.Waypoint_ThirdElement.TimeFixed = Waypoint.FixedFree.Fixed;
				}
				if (!Information.IsNothing(waypoint.Waypoint_ThirdElementWingman))
				{
					if (waypoint.Waypoint_ThirdElementWingman.Leg_Time_Weapon <= 0f)
					{
						waypoint.Waypoint_ThirdElementWingman.Time_Zulu = nullable_1;
						waypoint.Waypoint_ThirdElementWingman.Time_Zulu_Weapon = null;
					}
					else
					{
						waypoint.Waypoint_ThirdElementWingman.Time_Zulu = nullable_1.Value.AddSeconds(0f - waypoint.Waypoint_ThirdElementWingman.Leg_Time_Weapon);
						waypoint.Waypoint_ThirdElementWingman.Time_Zulu_Weapon = nullable_1;
					}
					waypoint.Waypoint_ThirdElementWingman.TimeFixed = Waypoint.FixedFree.Fixed;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200612", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (num2 > 0 && num < 0 && !Information.IsNothing(waypoint_0[0].Time_Zulu))
		{
			num = 0;
		}
		try
		{
			if (num >= 0)
			{
				double value = 0.0;
				for (int j = num - 1; j >= 0; j += -1)
				{
					Waypoint waypoint2 = waypoint_0[j];
					try
					{
						if (bool_0 && (waypoint2.FlightFormation != Waypoint.Formation.Split || (waypoint2.TimeFixed == Waypoint.FixedFree.Relative && !Information.IsNothing(waypoint2.Time_Zulu))))
						{
							continue;
						}
					}
					catch (Exception ex12)
					{
						ProjectData.SetProjectError(ex12);
						Exception exception_12 = ex12;
						exception_12?.Data.Add("Error at 20061361", "");
						GameGeneral.WriteExceptionsToLog(ref exception_12);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					if (!((j < num || !Information.IsNothing(nullable_1)) & waypoint_0[j + 1].Time_Zulu.HasValue))
					{
						continue;
					}
					DateTime dateTime = waypoint_0[j + 1].Time_Zulu.Value.AddSeconds(_ImporterConsumer * (0f - (waypoint_0[j + 1].Leg_Time_Straight + waypoint_0[j + 1].Leg_Time_Turn + waypoint_0[j + 1].Hold_Time + waypoint_0[j + 1].Station_Time + waypoint_0[j + 1].SpacingManeuver_Time)));
					try
					{
						if (!Information.IsNothing(waypoint2.Time_Zulu))
						{
							value = (dateTime - waypoint2.Time_Zulu.Value).TotalSeconds;
						}
						if (waypoint2.Leg_Time_Weapon <= 0f)
						{
							waypoint2.Time_Zulu = dateTime;
							waypoint2.Time_Zulu_Weapon = null;
						}
						else
						{
							waypoint2.Time_Zulu = dateTime.AddSeconds(0f - waypoint2.Leg_Time_Weapon);
							waypoint2.Time_Zulu_Weapon = dateTime;
						}
					}
					catch (Exception ex21)
					{
						ProjectData.SetProjectError(ex21);
						Exception exception_21 = ex21;
						exception_21?.Data.Add("Error at 20061360", "");
						GameGeneral.WriteExceptionsToLog(ref exception_21);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					if (bool_0)
					{
						continue;
					}
					if (waypoint2.FlightFormation == Waypoint.Formation.Split)
					{
						if (!Information.IsNothing(waypoint2.Waypoint_LeadElementWingman) && waypoint2.Waypoint_LeadElementWingman.TimeFixed == Waypoint.FixedFree.Relative)
						{
							try
							{
								if (waypoint2.Waypoint_LeadElementWingman.Leg_Time_Weapon <= 0f)
								{
									if (!Information.IsNothing(waypoint2.Waypoint_LeadElementWingman.Time_Zulu))
									{
										waypoint2.Waypoint_LeadElementWingman.Time_Zulu = waypoint2.Waypoint_LeadElementWingman.Time_Zulu.Value.AddSeconds(value);
									}
									waypoint2.Waypoint_LeadElementWingman.Time_Zulu_Weapon = null;
								}
								else
								{
									if (!Information.IsNothing(waypoint2.Waypoint_LeadElementWingman.Time_Zulu))
									{
										waypoint2.Waypoint_LeadElementWingman.Time_Zulu = waypoint2.Waypoint_LeadElementWingman.Time_Zulu.Value.AddSeconds(value);
									}
									if (!Information.IsNothing(waypoint2.Waypoint_LeadElementWingman.Time_Zulu_Weapon))
									{
										waypoint2.Waypoint_LeadElementWingman.Time_Zulu_Weapon = waypoint2.Waypoint_LeadElementWingman.Time_Zulu_Weapon.Value.AddSeconds(value);
									}
								}
							}
							catch (Exception ex22)
							{
								ProjectData.SetProjectError(ex22);
								Exception exception_22 = ex22;
								exception_22?.Data.Add("Error at 20061354", "");
								GameGeneral.WriteExceptionsToLog(ref exception_22);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						try
						{
							if (!Information.IsNothing(waypoint2.Waypoint_SecondElement) && waypoint2.Waypoint_SecondElement.TimeFixed == Waypoint.FixedFree.Relative)
							{
								if (waypoint2.Waypoint_SecondElement.Leg_Time_Weapon <= 0f)
								{
									if (!Information.IsNothing(waypoint2.Waypoint_SecondElement.Time_Zulu))
									{
										waypoint2.Waypoint_SecondElement.Time_Zulu = waypoint2.Waypoint_SecondElement.Time_Zulu.Value.AddSeconds(value);
									}
									waypoint2.Waypoint_SecondElement.Time_Zulu_Weapon = null;
								}
								else
								{
									if (!Information.IsNothing(waypoint2.Waypoint_SecondElement.Time_Zulu))
									{
										waypoint2.Waypoint_SecondElement.Time_Zulu = waypoint2.Waypoint_SecondElement.Time_Zulu.Value.AddSeconds(value);
									}
									if (!Information.IsNothing(waypoint2.Waypoint_SecondElement.Time_Zulu_Weapon))
									{
										waypoint2.Waypoint_SecondElement.Time_Zulu_Weapon = waypoint2.Waypoint_SecondElement.Time_Zulu_Weapon.Value.AddSeconds(value);
									}
								}
							}
						}
						catch (Exception ex23)
						{
							ProjectData.SetProjectError(ex23);
							Exception exception_23 = ex23;
							exception_23?.Data.Add("Error at 20061353", "");
							GameGeneral.WriteExceptionsToLog(ref exception_23);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						try
						{
							if (!Information.IsNothing(waypoint2.Waypoint_SecondElementWingman) && waypoint2.Waypoint_SecondElementWingman.TimeFixed == Waypoint.FixedFree.Relative)
							{
								if (waypoint2.Waypoint_SecondElementWingman.Leg_Time_Weapon <= 0f)
								{
									if (!Information.IsNothing(waypoint2.Waypoint_SecondElementWingman.Time_Zulu))
									{
										waypoint2.Waypoint_SecondElementWingman.Time_Zulu = waypoint2.Waypoint_SecondElementWingman.Time_Zulu.Value.AddSeconds(value);
									}
									waypoint2.Waypoint_SecondElementWingman.Time_Zulu_Weapon = null;
								}
								else
								{
									if (!Information.IsNothing(waypoint2.Waypoint_SecondElementWingman.Time_Zulu))
									{
										waypoint2.Waypoint_SecondElementWingman.Time_Zulu = waypoint2.Waypoint_SecondElementWingman.Time_Zulu.Value.AddSeconds(value);
									}
									if (!Information.IsNothing(waypoint2.Waypoint_SecondElementWingman.Time_Zulu_Weapon))
									{
										waypoint2.Waypoint_SecondElementWingman.Time_Zulu_Weapon = waypoint2.Waypoint_SecondElementWingman.Time_Zulu_Weapon.Value.AddSeconds(value);
									}
								}
							}
						}
						catch (Exception ex24)
						{
							ProjectData.SetProjectError(ex24);
							Exception exception_24 = ex24;
							exception_24?.Data.Add("Error at 20061352", "");
							GameGeneral.WriteExceptionsToLog(ref exception_24);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						try
						{
							if (!Information.IsNothing(waypoint2.Waypoint_ThirdElement) && waypoint2.Waypoint_ThirdElement.TimeFixed == Waypoint.FixedFree.Relative)
							{
								if (waypoint2.Waypoint_ThirdElement.Leg_Time_Weapon <= 0f)
								{
									if (!Information.IsNothing(waypoint2.Waypoint_ThirdElement.Time_Zulu))
									{
										waypoint2.Waypoint_ThirdElement.Time_Zulu = waypoint2.Waypoint_ThirdElement.Time_Zulu.Value.AddSeconds(value);
									}
									waypoint2.Waypoint_ThirdElement.Time_Zulu_Weapon = null;
								}
								else
								{
									if (!Information.IsNothing(waypoint2.Waypoint_ThirdElement.Time_Zulu))
									{
										waypoint2.Waypoint_ThirdElement.Time_Zulu = waypoint2.Waypoint_ThirdElement.Time_Zulu.Value.AddSeconds(value);
									}
									if (!Information.IsNothing(waypoint2.Waypoint_ThirdElement.Time_Zulu_Weapon))
									{
										waypoint2.Waypoint_ThirdElement.Time_Zulu_Weapon = waypoint2.Waypoint_ThirdElement.Time_Zulu_Weapon.Value.AddSeconds(value);
									}
								}
							}
						}
						catch (Exception ex25)
						{
							ProjectData.SetProjectError(ex25);
							Exception exception_25 = ex25;
							exception_25?.Data.Add("Error at 20061351", "");
							GameGeneral.WriteExceptionsToLog(ref exception_25);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						try
						{
							if (Information.IsNothing(waypoint2.Waypoint_ThirdElementWingman) || waypoint2.Waypoint_ThirdElementWingman.TimeFixed != Waypoint.FixedFree.Relative)
							{
								continue;
							}
							if (waypoint2.Waypoint_ThirdElementWingman.Leg_Time_Weapon <= 0f)
							{
								if (!Information.IsNothing(waypoint2.Waypoint_ThirdElementWingman.Time_Zulu))
								{
									waypoint2.Waypoint_ThirdElementWingman.Time_Zulu = waypoint2.Waypoint_ThirdElementWingman.Time_Zulu.Value.AddSeconds(value);
								}
								waypoint2.Waypoint_ThirdElementWingman.Time_Zulu_Weapon = null;
								continue;
							}
							if (!Information.IsNothing(waypoint2.Waypoint_ThirdElementWingman.Time_Zulu))
							{
								waypoint2.Waypoint_ThirdElementWingman.Time_Zulu = waypoint2.Waypoint_ThirdElementWingman.Time_Zulu.Value.AddSeconds(value);
							}
							if (!Information.IsNothing(waypoint2.Waypoint_ThirdElementWingman.Time_Zulu_Weapon))
							{
								waypoint2.Waypoint_ThirdElementWingman.Time_Zulu_Weapon = waypoint2.Waypoint_ThirdElementWingman.Time_Zulu_Weapon.Value.AddSeconds(value);
							}
						}
						catch (Exception ex26)
						{
							ProjectData.SetProjectError(ex26);
							Exception exception_26 = ex26;
							exception_26?.Data.Add("Error at 20061350", "");
							GameGeneral.WriteExceptionsToLog(ref exception_26);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						continue;
					}
					try
					{
						if (!Information.IsNothing(waypoint2.Waypoint_LeadElementWingman))
						{
							if (waypoint2.Waypoint_LeadElementWingman.Leg_Time_Weapon <= 0f)
							{
								waypoint2.Waypoint_LeadElementWingman.Time_Zulu = dateTime;
								waypoint2.Waypoint_LeadElementWingman.Time_Zulu_Weapon = null;
							}
							else
							{
								waypoint2.Waypoint_LeadElementWingman.Time_Zulu = dateTime.AddSeconds(0f - waypoint2.Waypoint_LeadElementWingman.Leg_Time_Weapon);
								waypoint2.Waypoint_LeadElementWingman.Time_Zulu_Weapon = dateTime;
							}
							waypoint2.Waypoint_LeadElementWingman.Time_Zulu_Weapon = null;
						}
					}
					catch (Exception ex27)
					{
						ProjectData.SetProjectError(ex27);
						Exception exception_27 = ex27;
						exception_27?.Data.Add("Error at 20061359", "");
						GameGeneral.WriteExceptionsToLog(ref exception_27);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					if (!Information.IsNothing(waypoint2.Waypoint_SecondElement))
					{
						try
						{
							if (waypoint2.Waypoint_SecondElement.Leg_Time_Weapon <= 0f)
							{
								waypoint2.Waypoint_SecondElement.Time_Zulu = dateTime;
								waypoint2.Waypoint_SecondElement.Time_Zulu_Weapon = null;
							}
							else
							{
								waypoint2.Waypoint_SecondElement.Time_Zulu = dateTime.AddSeconds(0f - waypoint2.Waypoint_SecondElement.Leg_Time_Weapon);
								waypoint2.Waypoint_SecondElement.Time_Zulu_Weapon = dateTime;
							}
						}
						catch (Exception ex2)
						{
							ProjectData.SetProjectError(ex2);
							Exception exception_2 = ex2;
							exception_2?.Data.Add("Error at 20061358", "");
							GameGeneral.WriteExceptionsToLog(ref exception_2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (!Information.IsNothing(waypoint2.Waypoint_SecondElementWingman))
					{
						try
						{
							if (waypoint2.Waypoint_SecondElementWingman.Leg_Time_Weapon <= 0f)
							{
								waypoint2.Waypoint_SecondElementWingman.Time_Zulu = dateTime;
								waypoint2.Waypoint_SecondElementWingman.Time_Zulu_Weapon = null;
							}
							else
							{
								waypoint2.Waypoint_SecondElementWingman.Time_Zulu = dateTime.AddSeconds(0f - waypoint2.Waypoint_SecondElementWingman.Leg_Time_Weapon);
								waypoint2.Waypoint_SecondElementWingman.Time_Zulu_Weapon = dateTime;
							}
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception exception_3 = ex3;
							exception_3?.Data.Add("Error at 20061357", "");
							GameGeneral.WriteExceptionsToLog(ref exception_3);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (!Information.IsNothing(waypoint2.Waypoint_ThirdElement))
					{
						try
						{
							if (waypoint2.Waypoint_ThirdElement.Leg_Time_Weapon <= 0f)
							{
								waypoint2.Waypoint_ThirdElement.Time_Zulu = dateTime;
								waypoint2.Waypoint_ThirdElement.Time_Zulu_Weapon = null;
							}
							else
							{
								waypoint2.Waypoint_ThirdElement.Time_Zulu = dateTime.AddSeconds(0f - waypoint2.Waypoint_ThirdElement.Leg_Time_Weapon);
								waypoint2.Waypoint_ThirdElement.Time_Zulu_Weapon = dateTime;
							}
						}
						catch (Exception ex4)
						{
							ProjectData.SetProjectError(ex4);
							Exception exception_4 = ex4;
							exception_4?.Data.Add("Error at 20061356", "");
							GameGeneral.WriteExceptionsToLog(ref exception_4);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (Information.IsNothing(waypoint2.Waypoint_ThirdElementWingman))
					{
						continue;
					}
					try
					{
						if (waypoint2.Waypoint_ThirdElementWingman.Leg_Time_Weapon <= 0f)
						{
							waypoint2.Waypoint_ThirdElementWingman.Time_Zulu = dateTime;
							waypoint2.Waypoint_ThirdElementWingman.Time_Zulu_Weapon = null;
						}
						else
						{
							waypoint2.Waypoint_ThirdElementWingman.Time_Zulu = dateTime.AddSeconds(0f - waypoint2.Waypoint_ThirdElementWingman.Leg_Time_Weapon);
							waypoint2.Waypoint_ThirdElementWingman.Time_Zulu_Weapon = dateTime;
						}
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception exception_5 = ex5;
						exception_5?.Data.Add("Error at 20061355", "");
						GameGeneral.WriteExceptionsToLog(ref exception_5);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				if (num > num2 - 1)
				{
					return;
				}
				int num4 = num + 1;
				int num5 = num2 - 1;
				double value2 = 0.0;
				for (int k = num4; k <= num5; k++)
				{
					Waypoint waypoint3 = waypoint_0[k];
					try
					{
						if ((bool_0 && (waypoint3.FlightFormation != Waypoint.Formation.Split || (waypoint3.TimeFixed == Waypoint.FixedFree.Relative && !Information.IsNothing(waypoint3.Time_Zulu)))) || (waypoint3.TimeFixed == Waypoint.FixedFree.Fixed && !Information.IsNothing(waypoint3.Time_Zulu)))
						{
							continue;
						}
						goto IL_1714;
					}
					catch (Exception ex6)
					{
						ProjectData.SetProjectError(ex6);
						Exception exception_6 = ex6;
						exception_6?.Data.Add("Error at 20061362", "");
						GameGeneral.WriteExceptionsToLog(ref exception_6);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						goto IL_1714;
					}
					IL_1714:
					if (!((k > num || !Information.IsNothing(nullable_1)) & !Information.IsNothing(waypoint_0[k - 1].Time_Zulu)))
					{
						continue;
					}
					DateTime dateTime2 = waypoint_0[k - 1].Time_Zulu.Value.AddSeconds(waypoint3.Leg_Time_Straight + waypoint3.Leg_Time_Turn + waypoint3.Hold_Time + waypoint3.Station_Time + waypoint3.SpacingManeuver_Time);
					try
					{
						if (!bool_0 && !Information.IsNothing(waypoint3.Time_Zulu))
						{
							value2 = (dateTime2 - waypoint3.Time_Zulu.Value).TotalSeconds;
						}
						waypoint3.Time_Zulu = dateTime2;
						if (waypoint3.Leg_Time_Weapon <= 0f)
						{
							waypoint3.Time_Zulu_Weapon = null;
						}
						else
						{
							waypoint3.Time_Zulu_Weapon = dateTime2.AddSeconds(waypoint3.Leg_Time_Weapon);
						}
					}
					catch (Exception ex7)
					{
						ProjectData.SetProjectError(ex7);
						Exception exception_7 = ex7;
						exception_7?.Data.Add("Error at 20061363", "");
						GameGeneral.WriteExceptionsToLog(ref exception_7);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					if (bool_0)
					{
						continue;
					}
					if (waypoint3.FlightFormation != Waypoint.Formation.Split)
					{
						if (!Information.IsNothing(waypoint3.Waypoint_LeadElementWingman))
						{
							try
							{
								if (waypoint3.Waypoint_LeadElementWingman.Leg_Time_Weapon <= 0f)
								{
									waypoint3.Waypoint_LeadElementWingman.Time_Zulu = dateTime2;
									waypoint3.Waypoint_LeadElementWingman.Time_Zulu_Weapon = null;
								}
								else
								{
									waypoint3.Waypoint_LeadElementWingman.Time_Zulu = dateTime2.AddSeconds(0f - waypoint3.Waypoint_LeadElementWingman.Leg_Time_Weapon);
									waypoint3.Waypoint_LeadElementWingman.Time_Zulu_Weapon = dateTime2;
								}
								waypoint3.Waypoint_LeadElementWingman.Time_Zulu_Weapon = null;
							}
							catch (Exception ex8)
							{
								ProjectData.SetProjectError(ex8);
								Exception exception_8 = ex8;
								exception_8?.Data.Add("Error at 2006139865", "");
								GameGeneral.WriteExceptionsToLog(ref exception_8);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						if (!Information.IsNothing(waypoint3.Waypoint_SecondElement))
						{
							try
							{
								if (waypoint3.Waypoint_SecondElement.Leg_Time_Weapon <= 0f)
								{
									waypoint3.Waypoint_SecondElement.Time_Zulu = dateTime2;
									waypoint3.Waypoint_SecondElement.Time_Zulu_Weapon = null;
								}
								else
								{
									waypoint3.Waypoint_SecondElement.Time_Zulu = dateTime2.AddSeconds(0f - waypoint3.Waypoint_SecondElement.Leg_Time_Weapon);
									waypoint3.Waypoint_SecondElement.Time_Zulu_Weapon = dateTime2;
								}
							}
							catch (Exception ex9)
							{
								ProjectData.SetProjectError(ex9);
								Exception exception_9 = ex9;
								exception_9?.Data.Add("Error at 2006139864", "");
								GameGeneral.WriteExceptionsToLog(ref exception_9);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						if (!Information.IsNothing(waypoint3.Waypoint_SecondElementWingman))
						{
							try
							{
								if (waypoint3.Waypoint_SecondElementWingman.Leg_Time_Weapon <= 0f)
								{
									waypoint3.Waypoint_SecondElementWingman.Time_Zulu = dateTime2;
									waypoint3.Waypoint_SecondElementWingman.Time_Zulu_Weapon = null;
								}
								else
								{
									waypoint3.Waypoint_SecondElementWingman.Time_Zulu = dateTime2.AddSeconds(0f - waypoint3.Waypoint_SecondElementWingman.Leg_Time_Weapon);
									waypoint3.Waypoint_SecondElementWingman.Time_Zulu_Weapon = dateTime2;
								}
							}
							catch (Exception ex10)
							{
								ProjectData.SetProjectError(ex10);
								Exception exception_10 = ex10;
								exception_10?.Data.Add("Error at 2006139866", "");
								GameGeneral.WriteExceptionsToLog(ref exception_10);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						if (!Information.IsNothing(waypoint3.Waypoint_ThirdElement))
						{
							try
							{
								if (waypoint3.Waypoint_ThirdElement.Leg_Time_Weapon <= 0f)
								{
									waypoint3.Waypoint_ThirdElement.Time_Zulu = dateTime2;
									waypoint3.Waypoint_ThirdElement.Time_Zulu_Weapon = null;
								}
								else
								{
									waypoint3.Waypoint_ThirdElement.Time_Zulu = dateTime2.AddSeconds(0f - waypoint3.Waypoint_ThirdElement.Leg_Time_Weapon);
									waypoint3.Waypoint_ThirdElement.Time_Zulu_Weapon = dateTime2;
								}
							}
							catch (Exception ex11)
							{
								ProjectData.SetProjectError(ex11);
								Exception exception_11 = ex11;
								exception_11?.Data.Add("Error at 2006139867", "");
								GameGeneral.WriteExceptionsToLog(ref exception_11);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						if (Information.IsNothing(waypoint3.Waypoint_ThirdElementWingman))
						{
							continue;
						}
						try
						{
							if (waypoint3.Waypoint_ThirdElementWingman.Leg_Time_Weapon <= 0f)
							{
								waypoint3.Waypoint_ThirdElementWingman.Time_Zulu = dateTime2;
								waypoint3.Waypoint_ThirdElementWingman.Time_Zulu_Weapon = null;
							}
							else
							{
								waypoint3.Waypoint_ThirdElementWingman.Time_Zulu = dateTime2.AddSeconds(0f - waypoint3.Waypoint_ThirdElementWingman.Leg_Time_Weapon);
								waypoint3.Waypoint_ThirdElementWingman.Time_Zulu_Weapon = dateTime2;
							}
						}
						catch (Exception ex13)
						{
							ProjectData.SetProjectError(ex13);
							Exception exception_13 = ex13;
							exception_13?.Data.Add("Error at 2006139868", "");
							GameGeneral.WriteExceptionsToLog(ref exception_13);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						continue;
					}
					if (!Information.IsNothing(waypoint3.Waypoint_LeadElementWingman) && waypoint3.Waypoint_LeadElementWingman.TimeFixed == Waypoint.FixedFree.Relative)
					{
						try
						{
							if (waypoint3.Waypoint_LeadElementWingman.Leg_Time_Weapon <= 0f)
							{
								if (!Information.IsNothing(waypoint3.Waypoint_LeadElementWingman.Time_Zulu))
								{
									waypoint3.Waypoint_LeadElementWingman.Time_Zulu = waypoint3.Waypoint_LeadElementWingman.Time_Zulu.Value.AddSeconds(value2);
								}
								waypoint3.Waypoint_LeadElementWingman.Time_Zulu_Weapon = null;
							}
							else
							{
								if (!Information.IsNothing(waypoint3.Waypoint_LeadElementWingman.Time_Zulu))
								{
									waypoint3.Waypoint_LeadElementWingman.Time_Zulu = waypoint3.Waypoint_LeadElementWingman.Time_Zulu.Value.AddSeconds(value2);
								}
								if (!Information.IsNothing(waypoint3.Waypoint_LeadElementWingman.Time_Zulu_Weapon))
								{
									waypoint3.Waypoint_LeadElementWingman.Time_Zulu_Weapon = waypoint3.Waypoint_LeadElementWingman.Time_Zulu_Weapon.Value.AddSeconds(value2);
								}
							}
						}
						catch (Exception ex14)
						{
							ProjectData.SetProjectError(ex14);
							Exception exception_14 = ex14;
							exception_14?.Data.Add("Error at 2006139868", "");
							GameGeneral.WriteExceptionsToLog(ref exception_14);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (!Information.IsNothing(waypoint3.Waypoint_SecondElement) && waypoint3.Waypoint_SecondElement.TimeFixed == Waypoint.FixedFree.Relative)
					{
						try
						{
							if (waypoint3.Waypoint_SecondElement.Leg_Time_Weapon <= 0f)
							{
								if (!Information.IsNothing(waypoint3.Waypoint_SecondElement.Time_Zulu))
								{
									waypoint3.Waypoint_SecondElement.Time_Zulu = waypoint3.Waypoint_SecondElement.Time_Zulu.Value.AddSeconds(value2);
								}
								waypoint3.Waypoint_SecondElement.Time_Zulu_Weapon = null;
							}
							else
							{
								if (!Information.IsNothing(waypoint3.Waypoint_SecondElement.Time_Zulu))
								{
									waypoint3.Waypoint_SecondElement.Time_Zulu = waypoint3.Waypoint_SecondElement.Time_Zulu.Value.AddSeconds(value2);
								}
								if (!Information.IsNothing(waypoint3.Waypoint_SecondElement.Time_Zulu_Weapon))
								{
									waypoint3.Waypoint_SecondElement.Time_Zulu_Weapon = waypoint3.Waypoint_SecondElement.Time_Zulu_Weapon.Value.AddSeconds(value2);
								}
							}
						}
						catch (Exception ex15)
						{
							ProjectData.SetProjectError(ex15);
							Exception exception_15 = ex15;
							exception_15?.Data.Add("Error at 2006139869", "");
							GameGeneral.WriteExceptionsToLog(ref exception_15);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (!Information.IsNothing(waypoint3.Waypoint_SecondElementWingman) && waypoint3.Waypoint_SecondElementWingman.TimeFixed == Waypoint.FixedFree.Relative)
					{
						try
						{
							if (waypoint3.Waypoint_SecondElementWingman.Leg_Time_Weapon <= 0f)
							{
								if (!Information.IsNothing(waypoint3.Waypoint_SecondElementWingman.Time_Zulu))
								{
									waypoint3.Waypoint_SecondElementWingman.Time_Zulu = waypoint3.Waypoint_SecondElementWingman.Time_Zulu.Value.AddSeconds(value2);
								}
								waypoint3.Waypoint_SecondElementWingman.Time_Zulu_Weapon = null;
							}
							else
							{
								if (!Information.IsNothing(waypoint3.Waypoint_SecondElementWingman.Time_Zulu))
								{
									waypoint3.Waypoint_SecondElementWingman.Time_Zulu = waypoint3.Waypoint_SecondElementWingman.Time_Zulu.Value.AddSeconds(value2);
								}
								if (!Information.IsNothing(waypoint3.Waypoint_SecondElementWingman.Time_Zulu_Weapon))
								{
									waypoint3.Waypoint_SecondElementWingman.Time_Zulu_Weapon = waypoint3.Waypoint_SecondElementWingman.Time_Zulu_Weapon.Value.AddSeconds(value2);
								}
							}
						}
						catch (Exception ex16)
						{
							ProjectData.SetProjectError(ex16);
							Exception exception_16 = ex16;
							exception_16?.Data.Add("Error at 2006139870", "");
							GameGeneral.WriteExceptionsToLog(ref exception_16);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (!Information.IsNothing(waypoint3.Waypoint_ThirdElement) && waypoint3.Waypoint_ThirdElement.TimeFixed == Waypoint.FixedFree.Relative)
					{
						try
						{
							if (waypoint3.Waypoint_ThirdElement.Leg_Time_Weapon <= 0f)
							{
								if (!Information.IsNothing(waypoint3.Waypoint_ThirdElement.Time_Zulu))
								{
									waypoint3.Waypoint_ThirdElement.Time_Zulu = waypoint3.Waypoint_ThirdElement.Time_Zulu.Value.AddSeconds(value2);
								}
								waypoint3.Waypoint_ThirdElement.Time_Zulu_Weapon = null;
							}
							else
							{
								if (!Information.IsNothing(waypoint3.Waypoint_ThirdElement.Time_Zulu))
								{
									waypoint3.Waypoint_ThirdElement.Time_Zulu = waypoint3.Waypoint_ThirdElement.Time_Zulu.Value.AddSeconds(value2);
								}
								if (!Information.IsNothing(waypoint3.Waypoint_ThirdElement.Time_Zulu_Weapon))
								{
									waypoint3.Waypoint_ThirdElement.Time_Zulu_Weapon = waypoint3.Waypoint_ThirdElement.Time_Zulu_Weapon.Value.AddSeconds(value2);
								}
							}
						}
						catch (Exception ex17)
						{
							ProjectData.SetProjectError(ex17);
							Exception exception_17 = ex17;
							exception_17?.Data.Add("Error at 2006139871", "");
							GameGeneral.WriteExceptionsToLog(ref exception_17);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					try
					{
						if (Information.IsNothing(waypoint3.Waypoint_ThirdElementWingman) || waypoint3.Waypoint_ThirdElementWingman.TimeFixed != Waypoint.FixedFree.Relative)
						{
							continue;
						}
						if (waypoint3.Waypoint_ThirdElementWingman.Leg_Time_Weapon <= 0f)
						{
							if (!Information.IsNothing(waypoint3.Waypoint_ThirdElementWingman.Time_Zulu))
							{
								waypoint3.Waypoint_ThirdElementWingman.Time_Zulu = waypoint3.Waypoint_ThirdElementWingman.Time_Zulu.Value.AddSeconds(value2);
							}
							waypoint3.Waypoint_ThirdElementWingman.Time_Zulu_Weapon = null;
							continue;
						}
						if (!Information.IsNothing(waypoint3.Waypoint_ThirdElementWingman.Time_Zulu))
						{
							waypoint3.Waypoint_ThirdElementWingman.Time_Zulu = waypoint3.Waypoint_ThirdElementWingman.Time_Zulu.Value.AddSeconds(value2);
						}
						if (!Information.IsNothing(waypoint3.Waypoint_ThirdElementWingman.Time_Zulu_Weapon))
						{
							waypoint3.Waypoint_ThirdElementWingman.Time_Zulu_Weapon = waypoint3.Waypoint_ThirdElementWingman.Time_Zulu_Weapon.Value.AddSeconds(value2);
						}
					}
					catch (Exception ex18)
					{
						ProjectData.SetProjectError(ex18);
						Exception exception_18 = ex18;
						exception_18?.Data.Add("Error at 2006139872", "");
						GameGeneral.WriteExceptionsToLog(ref exception_18);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				return;
			}
			try
			{
				if (!bool_0)
				{
					return;
				}
				int num6 = num2 - 1;
				for (int l = 0; l <= num6; l++)
				{
					Waypoint waypoint4 = waypoint_0[l];
					if (!Information.IsNothing(waypoint4) && waypoint4.FlightFormation == Waypoint.Formation.Split && l > 0 && !Information.IsNothing(waypoint_0[l - 1].Time_Zulu) && waypoint4.TimeFixed != Waypoint.FixedFree.Fixed && waypoint4.TimeFixed != Waypoint.FixedFree.Relative)
					{
						DateTime value3 = waypoint_0[l - 1].Time_Zulu.Value.AddSeconds(waypoint4.Leg_Time_Straight + waypoint4.Leg_Time_Turn + waypoint4.Hold_Time + waypoint4.Station_Time + waypoint4.SpacingManeuver_Time);
						waypoint4.Time_Zulu = value3;
						if (waypoint4.Leg_Time_Weapon <= 0f)
						{
							waypoint4.Time_Zulu_Weapon = null;
						}
						else
						{
							waypoint4.Time_Zulu_Weapon = value3.AddSeconds(waypoint4.Leg_Time_Weapon);
						}
					}
				}
			}
			catch (Exception ex19)
			{
				ProjectData.SetProjectError(ex19);
				Exception exception_19 = ex19;
				exception_19?.Data.Add("Error at 2006139873", "");
				GameGeneral.WriteExceptionsToLog(ref exception_19);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex20)
		{
			ProjectData.SetProjectError(ex20);
			Exception exception_20 = ex20;
			exception_20?.Data.Add("Error at 200613", "");
			GameGeneral.WriteExceptionsToLog(ref exception_20);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void DetermineLocalTimeForWaypoints(ref Scenario scenario_0, ref Waypoint[] waypoint_0, bool bool_0)
	{
		int num = waypoint_0.Count() - 1;
		for (int i = 0; i <= num; i++)
		{
			Waypoint waypoint = waypoint_0[i];
			if (Information.IsNothing(waypoint.Time_Zulu))
			{
				waypoint.Time_Local = null;
				waypoint.Time_Local_Weapon = null;
				continue;
			}
			bool use_DST = scenario_0.Use_DST;
			string dST_Start = scenario_0.DST_Start;
			string dST_End = scenario_0.DST_End;
			waypoint.Time_Local = Misc.DisableRequest(waypoint.Time_Zulu.Value, waypoint.Longitude, use_DST, dST_Start, dST_End);
			if (Information.IsNothing(waypoint.Time_Zulu_Weapon))
			{
				waypoint.Time_Local_Weapon = null;
			}
			else
			{
				waypoint.Time_Local_Weapon = Misc.DisableRequest(waypoint.Time_Zulu_Weapon.Value, waypoint.Longitude, use_DST, dST_Start, dST_End);
			}
		}
	}

	public static void DetermineTimesAndFuelQty(ref Scenario scenario_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Waypoint[] waypoint_0, ref ActiveUnit activeUnit_0, ref float float_0, ref float float_1, ref bool bool_0, bool bool_1, bool bool_2, string string_0, bool bool_3)
	{
		try
		{
			int num = waypoint_0.Count();
			float num5 = 0f;
			bool? flag = activeUnit_0?.IsAircraft;
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				return;
			}
			Aircraft aircraft_ = (Aircraft)activeUnit_0;
			float float_2;
			float float_3;
			if (activeUnit_0 == null)
			{
				float_2 = 0f;
				float_3 = 0f;
			}
			else
			{
				float_2 = (float)((double)activeUnit_0.Kinematics.ClimbRate_Max() * 0.4);
				float_3 = activeUnit_0.Kinematics.DiveRate_Max();
			}
			float_0 = 0f;
			ActiveUnit.Throttle throttle = ActiveUnit.Throttle.FullStop;
			float num6 = 0f;
			ActiveUnit.Throttle throttle_ = ActiveUnit.Throttle.FullStop;
			float float_4 = 0f;
			Waypoint waypoint_ = null;
			if (!bool_1 && !bool_3 && !Information.IsNothing(mission_0) && mission_0.MissionClass == Mission._MissionClass.Strike)
			{
				Strike strike = (Strike)mission_0;
				Mission._FlightSize flightSize = ((activeUnit_0 == null || !activeUnit_0.Navigator.HasFlight) ? strike.FlightSize : activeUnit_0.Navigator.GetFlight().DesiredAircraftQty);
				int num7 = num - 1;
				for (int i = 0; i <= num7; i++)
				{
					waypoint_ = waypoint_0[i];
					if (Information.IsNothing(waypoint_) || (waypoint_.Type != Waypoint.WaypointType.Target && waypoint_.Type != Waypoint.WaypointType.WeaponTarget))
					{
						continue;
					}
					if (waypoint_.AttackMethod != Mission._AttackMethod.EchelonAtActionPoint && waypoint_.AttackMethod != Mission._AttackMethod.SplitAtActionPoint)
					{
						if (waypoint_.Separation_Time > 0f && !waypoint_.InvokeReponse() && !bool_2)
						{
							waypoint_.SpacingManeuver_Time = 0f;
							waypoint_.Separation_Time = 0f;
							if (i < num - 1)
							{
								waypoint_0[i + 1].SpacingManeuver_Time = 0f;
							}
						}
						break;
					}
					float spacingManeuver_Time = 6f;
					float separation_Time = 20f;
					if (waypoint_.SpacingManeuver_Time == 0f)
					{
						waypoint_.SpacingManeuver_Time = spacingManeuver_Time;
					}
					if (waypoint_.Separation_Time == 0f)
					{
						waypoint_.Separation_Time = separation_Time;
					}
					if (i < num - 1)
					{
						waypoint_0[i + 1].SpacingManeuver_Time = (float)(flightSize - 1) * waypoint_.Separation_Time + waypoint_.SpacingManeuver_Time;
					}
					break;
				}
			}
			int num8 = num - 1;
			float num9 = 0f;
			float float_5 = 0f;
			Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment = null;
			Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment2 = null;
			for (int j = 0; j <= num8; j++)
			{
				Waypoint waypoint = waypoint_;
				waypoint_ = waypoint_0[j];
				float float_6 = 0f;
				float num10 = 0f;
				if (Information.IsNothing(waypoint_))
				{
					continue;
				}
				if (bool_1 && j != waypoint_0.Count() - 1 && waypoint_0[j].FlightFormation != Waypoint.Formation.Split)
				{
					num9 = num6;
					if (j > 0 && waypoint_.Type != Waypoint.WaypointType.TakeOff)
					{
						throttle_ = throttle;
						float_4 = num6;
					}
					if (waypoint_.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
					{
						if (Information.IsNothing(waypoint_.DesiredSpeed))
						{
							throttle = ActiveUnit.Throttle.Cruise;
						}
						else if (activeUnit_0 != null)
						{
							throttle = activeUnit_0.Kinematics.GetThrottleSuitableForThisSpeed(num6, waypoint_.DesiredSpeed.Value);
						}
					}
					else
					{
						throttle = (ActiveUnit.Throttle)waypoint_.ThrottlePreset;
					}
					if (Information.IsNothing(waypoint_.DesiredAltitude))
					{
						if (!Information.IsNothing(waypoint_.DesiredAltitude_TerrainFollowing) && waypoint_.TerrainFollowing)
						{
							num6 = waypoint_.DesiredAltitude_TerrainFollowing.Value;
						}
					}
					else
					{
						num6 = waypoint_.DesiredAltitude.Value;
					}
					if (num6 == 0f)
					{
						bool bool_4 = false;
						num6 = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_, ActiveUnit.Throttle.Cruise, ref bool_4);
					}
					num5 = waypoint_.Leg_TotalTime;
					if (!Information.IsNothing(aircraft_))
					{
						float_0 = float_1 - waypoint_.Leg_FuelRemaining;
					}
					continue;
				}
				byte? b;
				if (j <= 0)
				{
					if (waypoint_.Type == Waypoint.WaypointType.TakeOff)
					{
						if (Information.IsNothing(aircraft_))
						{
							waypoint_.Leg_FuelRemaining = float.MaxValue;
						}
						else
						{
							waypoint_.Leg_FuelRemaining = float_1;
						}
					}
					else if (waypoint_.Type == Waypoint.WaypointType.Target || waypoint_.Type == Waypoint.WaypointType.WeaponTarget)
					{
						if (Information.IsNothing(waypoint_.DesiredAltitude))
						{
							if (!Information.IsNothing(waypoint_.DesiredAltitude_TerrainFollowing) && waypoint_.TerrainFollowing)
							{
								num6 = waypoint_.DesiredAltitude_TerrainFollowing.Value;
							}
						}
						else
						{
							num6 = waypoint_.DesiredAltitude.Value;
						}
						if (num6 == 0f)
						{
							bool bool_5 = false;
							num6 = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_, ActiveUnit.Throttle.Cruise, ref bool_5);
						}
					}
				}
				else
				{
					if (j > 1 && waypoint_0[j].Type == Waypoint.WaypointType.WeaponTarget && !Information.IsNothing(waypoint_0[j - 1]) && waypoint_0[j - 1].Type == Waypoint.WaypointType.WeaponTarget)
					{
						continue;
					}
					if (Information.IsNothing(aircraft_))
					{
						waypoint_.Leg_FuelRequired = float.MinValue;
						waypoint_.Leg_FuelRemaining = float.MaxValue;
					}
					else
					{
						float num2;
						if (!Information.IsNothing(waypoint_.Leg_Speed_Straight) && !(waypoint_.Leg_Speed_Straight <= 0f) && waypoint_.Leg_Distance_Straight > 0f)
						{
							if (!Information.IsNothing(flight_0) && num9 != num6)
							{
								float num11 = 0f;
								float num12 = 0f;
								num11 = activeUnit_0.Kinematics.RemoveDic(num9, num6, float_2, float_3, waypoint.ThrottlePreset, waypoint_.Leg_Speed_Straight, !bool_0, bool_1: true, bool_2: true, ref float_5, ref float_6);
								if (waypoint.Type != Waypoint.WaypointType.TakeOff && waypoint.Type != Waypoint.WaypointType.HoldEnd && waypoint.Type != Waypoint.WaypointType.StationEnd)
								{
									if (float_5 <= waypoint_.Leg_Distance_Straight)
									{
										num10 = waypoint_.Leg_Distance_Straight - float_5;
										num12 = activeUnit_0.Kinematics.InterruptDic(num10, throttle, num6, waypoint_.Leg_Speed_Straight, !bool_0, bool_1: true, bool_2: true);
									}
									else if (waypoint_.Type != Waypoint.WaypointType.TakeOff && waypoint_.Type != Waypoint.WaypointType.LandingMarshal && waypoint_.Type != Waypoint.WaypointType.Land)
									{
										if (Information.IsNothing(waypoint.Description) || Information.IsNothing(waypoint_.Description))
										{
											MoveTokenizer(ref waypoint_0);
										}
										DestroyTokenizer(ref flight_0, ref waypoint_, "警告！任务" + flight_0.ParentMissionOrPackageName + "，飞行编队" + flight_0.Callsign + string_0 + "： 航点" + waypoint.Description + "离航点太近了" + waypoint_.Description + "。高度变化的距离太短（" + Conversions.ToString(Math.Round(float_5, 1)) + "海里 vs " + Conversions.ToString(Math.Round(waypoint_.Leg_Distance_Straight, 1)) + "海里）。由于下一航段需要继续攀升，估计增加了额外的燃料。注意：由于速度与高度问题，这可能会导致航点时间偏差。", bool_0: false);
									}
								}
								else
								{
									num10 = 0f;
									num12 = 0f;
								}
								num2 = num11 + num12;
							}
							else
							{
								num2 = activeUnit_0.Kinematics.InterruptDic(waypoint_.Leg_Distance_Straight, throttle, num6, waypoint_.Leg_Speed_Straight, !bool_0, bool_1: true, bool_2: true);
							}
						}
						else
						{
							num2 = 0f;
						}
						if (waypoint_.Type == Waypoint.WaypointType.StationEnd)
						{
							num2 += 0f;
						}
						else if (waypoint_.Type == Waypoint.WaypointType.HoldEnd)
						{
							num2 += 0f;
						}
						else if (!Information.IsNothing(waypoint_.Leg_Speed_Turn) && waypoint_.Leg_Speed_Turn > 0f && waypoint_.Leg_Distance_Turn > 0f)
						{
							num2 += activeUnit_0.Kinematics.InterruptDic(waypoint_.Leg_Distance_Turn, throttle_, float_4, waypoint_.Leg_Speed_Turn, !bool_0, bool_1: true, bool_2: true);
						}
						if (!Information.IsNothing(waypoint_.Time_Zulu) && waypoint_.Hold_Time > 0f)
						{
							if (!Information.IsNothing(waypoint_.Leg_Speed_Straight) && waypoint_.Leg_Speed_Straight > 0f)
							{
								float float_7 = waypoint_.Leg_Speed_Straight * (waypoint_.Hold_Time / 3600f);
								num2 += activeUnit_0.Kinematics.InterruptDic(float_7, throttle, num6, waypoint_.Leg_Speed_Straight, !bool_0, bool_1: true, bool_2: true);
							}
							else
							{
								num2 = 0f;
							}
						}
						if (waypoint_.SpacingManeuver_Time > 0f)
						{
							float float_8 = waypoint_.Leg_Speed_Straight * (waypoint_.SpacingManeuver_Time / 3600f);
							num2 += activeUnit_0.Kinematics.InterruptDic(float_8, ActiveUnit.Throttle.Loiter, float_4, waypoint_.Leg_Speed_Straight, !bool_0, bool_1: true, bool_2: true);
						}
						if (!Information.IsNothing(waypoint_.Time_Zulu) && waypoint_.Type == Waypoint.WaypointType.StationEnd && waypoint_.Station_Time > 0f)
						{
							float float_9 = waypoint_.Leg_Speed_Straight * (waypoint_.Station_Time / 3600f);
							num2 += activeUnit_0.Kinematics.InterruptDic(float_9, throttle, num6, waypoint_.Leg_Speed_Straight, !bool_0, bool_1: true, bool_2: true);
						}
						waypoint_.Leg_FuelRequired = num2;
						float_0 += num2;
						b = (byte?)useUnderwayRefuelAndReplenishment;
						bool? flag2 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
						flag = (!flag2) ?? flag2;
						if (flag.GetValueOrDefault(true))
						{
							b = (byte?)useUnderwayRefuelAndReplenishment;
							bool? flag3;
							bool? flag4 = (flag3 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null));
							bool? flag5;
							flag3 = (flag5 = ((flag4.HasValue && !flag3.GetValueOrDefault()) ? new bool?(false) : (Information.IsNothing(useUnderwayRefuelAndReplenishment2) ? new bool?(false) : flag3)));
							bool? flag6;
							if (flag3.HasValue && !flag5.GetValueOrDefault())
							{
								flag6 = false;
							}
							else
							{
								b = (byte?)useUnderwayRefuelAndReplenishment2;
								bool? flag7;
								flag3 = (flag7 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null));
								flag6 = ((!flag3.HasValue) ? null : (flag7.GetValueOrDefault() & flag5));
							}
							flag2 = flag6;
							if (((!flag2) ?? flag2).GetValueOrDefault() && flag.HasValue)
							{
								float_0 = 0f;
							}
						}
						waypoint_.Leg_FuelRemaining = float_1 - float_0;
					}
					if (waypoint_.Type == Waypoint.WaypointType.StationEnd)
					{
						waypoint_.Leg_Time_Straight = 0f;
					}
					else if (waypoint_.Type == Waypoint.WaypointType.HoldEnd)
					{
						waypoint_.Leg_Time_Straight = 0f;
					}
					else if (!Information.IsNothing(waypoint_.Leg_Speed_Straight) && !(waypoint_.Leg_Speed_Straight <= 0f) && waypoint_.Leg_Distance_Straight > 0f)
					{
						if (!(float_6 <= 0f) && num10 > 0f)
						{
							waypoint_.Leg_Time_Straight = float_6 + num10 / waypoint_.Leg_Speed_Straight * 3600f;
						}
						else
						{
							waypoint_.Leg_Time_Straight = float_6 + waypoint_.Leg_Distance_Straight / waypoint_.Leg_Speed_Straight * 3600f;
						}
					}
					else
					{
						waypoint_.Leg_Time_Straight = 0f;
					}
					if (waypoint_.Type == Waypoint.WaypointType.StationEnd)
					{
						waypoint_.Leg_Time_Turn = 0f;
					}
					else if (waypoint_.Type == Waypoint.WaypointType.HoldEnd)
					{
						waypoint_.Leg_Time_Turn = 0f;
					}
					else if (!Information.IsNothing(waypoint_.Leg_Speed_Turn) && !(waypoint_.Leg_Speed_Turn <= 0f) && waypoint_.Leg_Distance_Turn > 0f)
					{
						waypoint_.Leg_Time_Turn = waypoint_.Leg_Distance_Turn / waypoint_.Leg_Speed_Turn * 3600f;
					}
					else
					{
						waypoint_.Leg_Time_Turn = 0f;
					}
					float num3;
					float num4;
					if (Information.IsNothing(waypoint_.Time_Zulu))
					{
						num3 = 0f;
						num4 = 0f;
					}
					else
					{
						num3 = waypoint_.Hold_Time;
						num4 = waypoint_.Station_Time;
					}
					num5 = (waypoint_.Leg_TotalTime = num5 + (waypoint_.Leg_Time_Straight + waypoint_.Leg_Time_Turn + num3 + num4 + waypoint_.SpacingManeuver_Time));
				}
				if (waypoint_.Type == Waypoint.WaypointType.Target || waypoint_.Type == Waypoint.WaypointType.WeaponTarget)
				{
					bool_0 = false;
				}
				if (activeUnit_0 == null)
				{
					continue;
				}
				num9 = num6;
				if (j > 0 && waypoint_.Type != Waypoint.WaypointType.TakeOff)
				{
					throttle_ = throttle;
					float_4 = num6;
				}
				throttle = ((waypoint_.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None) ? ((ActiveUnit.Throttle)waypoint_.ThrottlePreset) : (Information.IsNothing(waypoint_.DesiredSpeed) ? ActiveUnit.Throttle.Cruise : activeUnit_0.Kinematics.GetThrottleSuitableForThisSpeed(num6, waypoint_.DesiredSpeed.Value)));
				b = (byte?)useUnderwayRefuelAndReplenishment;
				flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null);
				if (((!flag) ?? flag).GetValueOrDefault())
				{
					useUnderwayRefuelAndReplenishment2 = useUnderwayRefuelAndReplenishment;
				}
				useUnderwayRefuelAndReplenishment = waypoint_.Doctrine.GetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
				if (Information.IsNothing(waypoint_.DesiredAltitude))
				{
					if (!Information.IsNothing(waypoint_.DesiredAltitude_TerrainFollowing) && waypoint_.TerrainFollowing)
					{
						num6 = waypoint_.DesiredAltitude_TerrainFollowing.Value;
					}
				}
				else
				{
					num6 = waypoint_.DesiredAltitude.Value;
				}
				if (num6 == 0f && !waypoint_.TerrainFollowing)
				{
					bool bool_6 = false;
					num6 = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_, ActiveUnit.Throttle.Cruise, ref bool_6);
				}
				if (waypoint_.Type == Waypoint.WaypointType.TakeOff)
				{
					throttle_ = throttle;
					float_4 = num6;
					num9 = Math.Max((int)Terrain.GetElevation(waypoint_.Latitude, waypoint_.Longitude, bool_0: false, activeUnit_0.ParentScen), 0);
				}
			}
			Waypoint[] array = waypoint_0;
			for (int k = 0; k < array.Length; k = checked(k + 1))
			{
				waypoint_ = array[k];
				float_0 = Convert.ToSingle((double)float_0 + (double)waypoint_.Leg_FuelRequired * 1.1);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200614", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void DetermineBoundSpeedsAndTimes(ref Waypoint[] waypoint_0, bool bool_0)
	{
		int num = waypoint_0.Count();
		try
		{
			int num2 = num - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (bool_0 && i == 0)
				{
					continue;
				}
				Waypoint waypoint = waypoint_0[i];
				if (Information.IsNothing(waypoint) || i + 1 > num - 1)
				{
					continue;
				}
				Waypoint waypoint2 = waypoint_0[i + 1];
				if (Information.IsNothing(waypoint2))
				{
					continue;
				}
				if (waypoint2.TimeFixed != Waypoint.FixedFree.Fixed && waypoint2.TimeFixed != Waypoint.FixedFree.Relative)
				{
					if ((waypoint.TimeFixed == Waypoint.FixedFree.Fixed || waypoint.TimeFixed == Waypoint.FixedFree.Relative || waypoint.TimeFixed == Waypoint.FixedFree.Bound) && (waypoint.SpeedFixed == Waypoint.FixedFree.Fixed || waypoint.SpeedFixed == Waypoint.FixedFree.Relative))
					{
						waypoint2.TimeFixed = Waypoint.FixedFree.Bound;
					}
				}
				else if ((waypoint.TimeFixed == Waypoint.FixedFree.Fixed || waypoint.TimeFixed == Waypoint.FixedFree.Relative) && waypoint.SpeedFixed == Waypoint.FixedFree.Free)
				{
					waypoint.SpeedFixed = Waypoint.FixedFree.Bound;
				}
				else if (waypoint.TimeFixed == Waypoint.FixedFree.Free && (waypoint.SpeedFixed == Waypoint.FixedFree.Fixed || waypoint.SpeedFixed == Waypoint.FixedFree.Relative))
				{
					waypoint.TimeFixed = Waypoint.FixedFree.Bound;
				}
			}
			for (int j = num - 1; j >= 0; j += -1)
			{
				if (bool_0 && (j == 0 || j == 1 || j == 2))
				{
					continue;
				}
				Waypoint waypoint3 = waypoint_0[j];
				if (Information.IsNothing(waypoint3) || j - 1 < 0 || (waypoint3.TimeFixed != Waypoint.FixedFree.Fixed && waypoint3.TimeFixed != Waypoint.FixedFree.Relative && waypoint3.TimeFixed != Waypoint.FixedFree.Bound))
				{
					continue;
				}
				Waypoint waypoint4 = waypoint_0[j - 1];
				if (!Information.IsNothing(waypoint4))
				{
					if ((waypoint4.TimeFixed == Waypoint.FixedFree.Fixed || waypoint4.TimeFixed == Waypoint.FixedFree.Relative || waypoint4.TimeFixed == Waypoint.FixedFree.Bound) && waypoint4.SpeedFixed == Waypoint.FixedFree.Free)
					{
						waypoint4.SpeedFixed = Waypoint.FixedFree.Bound;
					}
					else if (waypoint4.TimeFixed == Waypoint.FixedFree.Free && (waypoint4.SpeedFixed == Waypoint.FixedFree.Fixed || waypoint4.SpeedFixed == Waypoint.FixedFree.Relative || waypoint4.TimeFixed == Waypoint.FixedFree.Bound))
					{
						waypoint4.TimeFixed = Waypoint.FixedFree.Bound;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200615", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void DetermineDistanceFlown(Waypoint[] waypoint_0, Waypoint[] waypoint_1, ref Mission.Flight flight_0, ref float float_0, bool bool_0, string string_0)
	{
		float float_ = 0f;
		float num = 0f;
		float float_12 = 0f;
		if (Information.IsNothing(waypoint_0) || waypoint_0.Count() == 0)
		{
			return;
		}
		float num9 = waypoint_0[0].Leg_TotalDistance;
		try
		{
			int num10 = waypoint_0.Count() - 1;
			Waypoint waypoint_2 = null;
			Waypoint waypoint_3 = null;
			Misc.TurnDirection turnDirection = (Misc.TurnDirection)0;
			GeoPoint geoPoint_ = null;
			GeoPoint geoPoint_2 = null;
			double double_ = 0.0;
			double double_2 = 0.0;
			for (int i = 0; i <= num10; i++)
			{
				if (Information.IsNothing(waypoint_0[i]))
				{
					continue;
				}
				if (bool_0 && i != waypoint_0.Count() - 1 && waypoint_0[i].FlightFormation != Waypoint.Formation.Split)
				{
					num = float_;
					if (!Information.IsNothing(waypoint_0[i].DesiredSpeed))
					{
						float_ = waypoint_0[i].DesiredSpeed.Value;
					}
					num9 = waypoint_0[i].Leg_TotalDistance;
					if (i < waypoint_0.Count() - 1 && !Information.IsNothing(waypoint_0[i + 1]) && waypoint_0[i + 1].FlightFormation == Waypoint.Formation.Split && !Information.IsNothing(waypoint_0[i].FlightplanPointsList) && waypoint_0[i].FlightplanPointsList.Count > 0)
					{
						Waypoint.FlightPlanSegment flightPlanSegment = waypoint_0[i].FlightplanPointsList[waypoint_0[i].FlightplanPointsList.Count - 1];
						float_12 = Math2.PublishClass(flightPlanSegment.StartLatitude, flightPlanSegment.StartLongitude, flightPlanSegment.EndLatitude, flightPlanSegment.EndLongitude);
					}
					continue;
				}
				List<Waypoint.FlightPlanSegment> list_ = new List<Waypoint.FlightPlanSegment>();
				if (i > 0 || waypoint_0[i].Type == Waypoint.WaypointType.TakeOff)
				{
					waypoint_0[i].Leg_Distance_Straight = 0f;
					waypoint_0[i].Leg_Distance_Turn = 0f;
					waypoint_0[i].Leg_Speed_Straight = 0f;
					waypoint_0[i].Leg_Speed_Turn = 0f;
				}
				if (bool_0 && i == 2)
				{
					waypoint_0[i].Leg_PreviousWaypointIsFixedSpeed = true;
					waypoint_0[i].Leg_TwoWaypointsAgoIsFixedSpeed = true;
				}
				else if (bool_0 && i == 3)
				{
					waypoint_0[i].Leg_PreviousWaypointIsFixedSpeed = waypoint_0[Math.Max(i - 1, 0)].SpeedFixed == Waypoint.FixedFree.Fixed || waypoint_0[Math.Max(i - 1, 0)].SpeedFixed == Waypoint.FixedFree.Relative;
					waypoint_0[i].Leg_TwoWaypointsAgoIsFixedSpeed = true;
				}
				else if (!bool_0 || i > 0)
				{
					waypoint_0[i].Leg_PreviousWaypointIsFixedSpeed = waypoint_0[Math.Max(i - 1, 0)].SpeedFixed == Waypoint.FixedFree.Fixed || waypoint_0[Math.Max(i - 1, 0)].SpeedFixed == Waypoint.FixedFree.Relative;
					waypoint_0[i].Leg_TwoWaypointsAgoIsFixedSpeed = waypoint_0[Math.Max(i - 2, 0)].SpeedFixed == Waypoint.FixedFree.Fixed || waypoint_0[Math.Max(i - 2, 0)].SpeedFixed == Waypoint.FixedFree.Relative;
				}
				if (i == 0)
				{
					if (!Information.IsNothing(waypoint_0[i].DesiredSpeed))
					{
						float_ = waypoint_0[i].DesiredSpeed.Value;
						num = float_;
					}
					if (!Information.IsNothing(waypoint_0[i].FlightplanPointsList) && waypoint_0[i].FlightplanPointsList.Count > 0)
					{
						Waypoint.FlightPlanSegment flightPlanSegment2 = waypoint_0[i].FlightplanPointsList[waypoint_0[i].FlightplanPointsList.Count - 1];
						float_12 = Math2.PublishClass(flightPlanSegment2.StartLatitude, flightPlanSegment2.StartLongitude, flightPlanSegment2.EndLatitude, flightPlanSegment2.EndLongitude);
					}
				}
				if (i != 0)
				{
					if (i > 0 && waypoint_0[i].Type == Waypoint.WaypointType.WeaponTarget && waypoint_0[i - 1].Type == Waypoint.WaypointType.WeaponTarget)
					{
						waypoint_0[i].Leg_Distance_Straight = 0f;
						waypoint_0[i].Leg_Distance_Turn = 0f;
						waypoint_0[i].Leg_Speed_Straight = 0f;
						waypoint_0[i].Leg_Speed_Turn = 0f;
						if (!Information.IsNothing(waypoint_2))
						{
							Waypoint waypoint;
							double double_3 = (waypoint = waypoint_2).Latitude;
							Waypoint.FlightPlanSegment flightPlanSegment3 = new Waypoint.FlightPlanSegment(ref double_3, waypoint_2.Longitude, waypoint_0[i].Latitude, waypoint_0[i].Longitude);
							waypoint.Latitude = double_3;
							Waypoint.FlightPlanSegment item = flightPlanSegment3;
							list_.Add(item);
						}
					}
					else if (!(float_ <= 0f) && num > 0f)
					{
						Waypoint waypoint_4 = waypoint_0[i];
						waypoint_2 = waypoint_0[i - 1];
						if (!Information.IsNothing(waypoint_1))
						{
							waypoint_3 = waypoint_1[i];
						}
						if (waypoint_4.Type == Waypoint.WaypointType.StationEnd)
						{
							if (waypoint_2.Type != Waypoint.WaypointType.StationStart_Racetrack && waypoint_2.Type != Waypoint.WaypointType.StationStart_RaceTrackRandom)
							{
								if (waypoint_2.Type == Waypoint.WaypointType.StationStart_FigureEight)
								{
									num = float_;
									float num11 = ActiveUnit_Kinematics.TurnRateCategoryToActualTurnRate(waypoint_2.TurnRate_Navigation, num);
									float float_23 = (float)((double)num / ((double)num11 * 3.14159265358979 * 20.0));
									float num12 = Math2.PublishClass(waypoint_2.Latitude, waypoint_2.Longitude, waypoint_4.Latitude, waypoint_4.Longitude);
									GeoPoint geoPoint = new GeoPoint();
									double longitude = waypoint_4.Longitude;
									double latitude = waypoint_4.Latitude;
									double double_4 = geoPoint.Longitude;
									double double_5 = geoPoint.Latitude;
									Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_4, ref double_5, float_23, Math2.UpdateClass(num12 - 90f));
									geoPoint.Latitude = double_5;
									geoPoint.Longitude = double_4;
									float num13 = Math2.PublishClass(geoPoint.Latitude, geoPoint.Longitude, waypoint_2.Latitude, waypoint_2.Longitude);
									turnDirection = Misc.TurnDirection.TurnRight;
									float_0 = 9f;
									float_12 = num13;
									float num14 = Math2.PublishClass(waypoint_2.Latitude, waypoint_2.Longitude, waypoint_4.Latitude, waypoint_4.Longitude);
									float float_25 = num;
									float float_26 = float_0;
									float float_27 = num14;
									bool bool_ = false;
									CreateFlightPlanCurve(ref float_12, ref list_, ref waypoint_4, ref waypoint_2, ref waypoint_3, ref float_, float_25, ref flight_0, float_26, Misc.TurnDirection.TurnRight, float_27, ref bool_, bool_1: false, string_0, waypoint_0);
									turnDirection = Misc.TurnDirection.TurnLeft;
									float_0 = -9f;
									float_12 = num13;
									double longitude2 = waypoint_2.Longitude;
									double latitude2 = waypoint_2.Latitude;
									double_5 = geoPoint.Longitude;
									double_4 = geoPoint.Latitude;
									Geodesic_EdWilliams.CalcPoint_Williams(longitude2, latitude2, ref double_5, ref double_4, float_23, Math2.UpdateClass(num12 - 90f));
									geoPoint.Latitude = double_4;
									geoPoint.Longitude = double_5;
									float_12 = Math2.PublishClass(geoPoint.Latitude, geoPoint.Longitude, waypoint_4.Latitude, waypoint_4.Longitude);
									float float_28 = num;
									float float_29 = float_0;
									float float_30 = Math2.UpdateClass(num14 + 180f);
									bool_ = false;
									CreateFlightPlanCurve(ref float_12, ref list_, ref waypoint_2, ref waypoint_4, ref waypoint_3, ref float_, float_28, ref flight_0, float_29, Misc.TurnDirection.TurnLeft, float_30, ref bool_, bool_1: false, string_0, waypoint_0);
								}
								else
								{
									float num15 = Math2.PublishClass(waypoint_2.Latitude, waypoint_2.Longitude, waypoint_4.Latitude, waypoint_4.Longitude);
									float_12 = num15;
									num = float_;
									if (turnDirection == (Misc.TurnDirection)0)
									{
										turnDirection = Misc.CountValue(float_12, num15);
										switch (turnDirection)
										{
										case Misc.TurnDirection.TurnRight:
											float_0 = 9f;
											break;
										case Misc.TurnDirection.TurnLeft:
											float_0 = -9f;
											break;
										}
									}
									float float_2 = num;
									float float_3 = float_0;
									Misc.TurnDirection turnDirection_ = turnDirection;
									float float_4 = num15;
									bool bool_2 = false;
									CreateFlightPlanCurve(ref float_12, ref list_, ref waypoint_4, ref waypoint_2, ref waypoint_3, ref float_, float_2, ref flight_0, float_3, turnDirection_, float_4, ref bool_2, bool_1: false, string_0, waypoint_0);
								}
							}
							else
							{
								num = float_;
								float num16 = ActiveUnit_Kinematics.TurnRateCategoryToActualTurnRate(waypoint_2.TurnRate_Navigation, num);
								float float_5 = (float)((double)num / ((double)num16 * 3.14159265358979 * 20.0));
								float num2 = Math2.VerifyClass(waypoint_2.Latitude, waypoint_2.Longitude, waypoint_4.Latitude, waypoint_4.Longitude);
								float num3 = Math2.PublishClass(waypoint_2.Latitude, waypoint_2.Longitude, waypoint_4.Latitude, waypoint_4.Longitude);
								float float_6 = num2 / 2f;
								GeoPoint geoPoint2 = new GeoPoint();
								double longitude3 = waypoint_4.Longitude;
								double latitude3 = waypoint_4.Latitude;
								GeoPoint geoPoint3;
								double double_6 = (geoPoint3 = geoPoint2).Longitude;
								double double_7 = geoPoint2.Latitude;
								Geodesic_EdWilliams.CalcPoint_Williams(longitude3, latitude3, ref double_6, ref double_7, float_6, num3);
								geoPoint2.Latitude = double_7;
								geoPoint3.Longitude = double_6;
								GeoPoint geoPoint4 = new GeoPoint();
								double longitude4 = geoPoint2.Longitude;
								double latitude4 = geoPoint2.Latitude;
								double_7 = geoPoint4.Longitude;
								double_6 = (geoPoint3 = geoPoint4).Latitude;
								Geodesic_EdWilliams.CalcPoint_Williams(longitude4, latitude4, ref double_7, ref double_6, float_5, Math2.UpdateClass(num3 + 180f));
								geoPoint3.Latitude = double_6;
								geoPoint4.Longitude = double_7;
								Misc.ManageRequest(geoPoint2, geoPoint4, waypoint_4, ref geoPoint_, ref geoPoint_2);
								turnDirection = Misc.TurnDirection.TurnRight;
								float_0 = 9f;
								if (!Information.IsNothing(geoPoint_) && !Information.IsNothing(geoPoint_2))
								{
									float_12 = Math2.PublishClass(geoPoint_2.Latitude, geoPoint_2.Longitude, waypoint_4.Latitude, waypoint_4.Longitude);
									float num4 = Math2.PublishClass(waypoint_2.Latitude, waypoint_2.Longitude, waypoint_4.Latitude, waypoint_4.Longitude);
									float float_7 = num;
									float float_8 = float_0;
									Misc.TurnDirection turnDirection_2 = turnDirection;
									float float_9 = num4;
									bool bool_3 = false;
									CreateFlightPlanCurve(ref float_12, ref list_, ref waypoint_4, ref waypoint_2, ref waypoint_3, ref float_, float_7, ref flight_0, float_8, turnDirection_2, float_9, ref bool_3, bool_1: false, string_0, waypoint_0);
									if (waypoint_2.Type == Waypoint.WaypointType.StationStart_FigureEight)
									{
										turnDirection = Misc.TurnDirection.TurnLeft;
										float_0 = -9f;
									}
									float float_10 = num;
									float float_11 = float_0;
									Misc.TurnDirection turnDirection_3 = turnDirection;
									float float_13 = Math2.UpdateClass(num4 + 180f);
									bool_3 = false;
									CreateFlightPlanCurve(ref float_12, ref list_, ref waypoint_2, ref waypoint_4, ref waypoint_3, ref float_, float_10, ref flight_0, float_11, turnDirection_3, float_13, ref bool_3, bool_1: false, string_0, waypoint_0);
								}
								else
								{
									float num5 = (float_12 = Math2.PublishClass(waypoint_2.Latitude, waypoint_2.Longitude, waypoint_4.Latitude, waypoint_4.Longitude));
									float float_14 = num;
									float float_15 = float_0;
									Misc.TurnDirection turnDirection_4 = turnDirection;
									float float_16 = num5;
									bool bool_4 = false;
									CreateFlightPlanCurve(ref float_12, ref list_, ref waypoint_4, ref waypoint_2, ref waypoint_3, ref float_, float_14, ref flight_0, float_15, turnDirection_4, float_16, ref bool_4, bool_1: false, string_0, waypoint_0);
									DestroyTokenizer(ref flight_0, ref waypoint_4, "错误！任务" + flight_0.ParentMissionOrPackageName + "，飞行编队" + flight_0.Callsign + string_0 + "：开始巡逻航点" + waypoint_2.Description + "太靠近结束巡逻航点" + waypoint_4.Description + ".");
								}
							}
							waypoint_0[i].Leg_Distance_Straight = 0f;
							waypoint_0[i].Leg_Distance_Turn = 0f;
						}
						else if (!Information.IsNothing(waypoint_4.Time_Zulu) && waypoint_4.InitReponse())
						{
							num = float_;
							float num6 = Math2.PublishClass(waypoint_2.Latitude, waypoint_2.Longitude, waypoint_4.Latitude, waypoint_4.Longitude);
							float_12 = num6;
							num = float_;
							if (turnDirection == (Misc.TurnDirection)0)
							{
								turnDirection = Misc.CountValue(float_12, num6);
								switch (turnDirection)
								{
								case Misc.TurnDirection.TurnRight:
									float_0 = 9f;
									break;
								case Misc.TurnDirection.TurnLeft:
									float_0 = -9f;
									break;
								}
							}
							float float_17 = num;
							float float_18 = float_0;
							Misc.TurnDirection turnDirection_5 = turnDirection;
							float float_19 = num6;
							bool bool_5 = false;
							CreateFlightPlanCurve(ref float_12, ref list_, ref waypoint_4, ref waypoint_2, ref waypoint_3, ref float_, float_17, ref flight_0, float_18, turnDirection_5, float_19, ref bool_5, bool_1: false, string_0, waypoint_0);
						}
						else
						{
							float num7 = Math2.PublishClass(waypoint_2.Latitude, waypoint_2.Longitude, waypoint_4.Latitude, waypoint_4.Longitude);
							turnDirection = Misc.CountValue(float_12, num7);
							if (!waypoint_2.EnableReponse() && (Information.IsNothing(waypoint_2.Time_Zulu) || !waypoint_2.InitReponse()))
							{
								if (waypoint_2.Type == Waypoint.WaypointType.TakeOff && (waypoint_4.Hold_Time > 0f || (waypoint_0.Count() - 1 > i && waypoint_0[i + 1].Hold_Time > 0f)))
								{
									float_12 = num7;
								}
							}
							else
							{
								float_12 = num7;
							}
							switch (turnDirection)
							{
							case Misc.TurnDirection.TurnRight:
								float_0 = 9f;
								break;
							case Misc.TurnDirection.TurnLeft:
								float_0 = -9f;
								break;
							}
							float float_20 = num;
							float float_21 = float_0;
							Misc.TurnDirection turnDirection_6 = turnDirection;
							float float_22 = num7;
							bool bool_6 = false;
							CreateFlightPlanCurve(ref float_12, ref list_, ref waypoint_4, ref waypoint_2, ref waypoint_3, ref float_, float_20, ref flight_0, float_21, turnDirection_6, float_22, ref bool_6, bool_1: false, string_0, waypoint_0);
							if (waypoint_2.EnableReponse() || waypoint_2.InitReponse())
							{
								waypoint_0[i].Leg_Distance_Straight = Math2.VerifyClass(waypoint_0[i].Latitude, waypoint_0[i].Longitude, waypoint_0[i - 2].Latitude, waypoint_0[i - 2].Longitude);
								waypoint_0[i].Leg_Distance_Turn = 0f;
								waypoint_4.Leg_Time_Turn = 0f;
								waypoint_4.Leg_Time_Straight = waypoint_4.Leg_Distance_Straight / float_ * 3600f;
							}
						}
					}
					else
					{
						Waypoint waypoint2 = waypoint_0[i];
						if (waypoint2.Type == Waypoint.WaypointType.WeaponTarget)
						{
							float float_24 = Math2.PublishClass(waypoint_0[i - 1].Latitude, waypoint_0[i - 1].Longitude, waypoint2.Latitude, waypoint2.Longitude);
							Geodesic_EdWilliams.CalcPoint_Williams(waypoint_0[i - 1].Longitude, waypoint_0[i - 1].Latitude, ref double_, ref double_2, 5f, float_24);
							Waypoint waypoint3;
							double double_8 = (waypoint3 = waypoint_0[i - 1]).Latitude;
							Waypoint.FlightPlanSegment flightPlanSegment4 = new Waypoint.FlightPlanSegment(ref double_8, waypoint_0[i - 1].Longitude, double_2, double_);
							waypoint3.Latitude = double_8;
							Waypoint.FlightPlanSegment item2 = flightPlanSegment4;
							list_.Add(item2);
							waypoint2.Leg_Distance_Straight += 5f;
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
						}
						else
						{
							Waypoint waypoint4;
							double double_9 = (waypoint4 = waypoint_0[i - 1]).Latitude;
							Waypoint.FlightPlanSegment flightPlanSegment5 = new Waypoint.FlightPlanSegment(ref double_9, waypoint_0[i - 1].Longitude, waypoint2.Latitude, waypoint2.Longitude);
							waypoint4.Latitude = double_9;
							Waypoint.FlightPlanSegment item3 = flightPlanSegment5;
							list_.Add(item3);
							waypoint2.Leg_Distance_Straight += Math2.VerifyClass(waypoint_0[i - 1].Latitude, waypoint_0[i - 1].Longitude, waypoint2.Latitude, waypoint2.Longitude);
						}
					}
				}
				num = float_;
				float? desiredSpeed = waypoint_0[i].DesiredSpeed;
				if (!Information.IsNothing(desiredSpeed))
				{
					float? num8 = desiredSpeed;
					if ((num8.HasValue ? new bool?(num8.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
					{
						if (bool_0)
						{
							if (!Information.IsNothing(waypoint_1[i].DesiredSpeed))
							{
								num8 = waypoint_1[i].DesiredSpeed;
								if ((num8.HasValue ? new bool?(num8.GetValueOrDefault() > 0f) : null).GetValueOrDefault())
								{
									waypoint_0[i].DesiredSpeed = waypoint_1[i].DesiredSpeed;
									goto IL_0fa5;
								}
							}
							waypoint_0[i].DesiredSpeed = null;
						}
						else
						{
							waypoint_0[i].DesiredSpeed = null;
						}
					}
					else
					{
						float_ = desiredSpeed.Value;
					}
				}
				goto IL_0fa5;
				IL_0fa5:
				num9 += waypoint_0[i].Leg_Distance_Straight + waypoint_0[i].Leg_Distance_Turn;
				if (i > 0)
				{
					waypoint_0[i].Leg_TotalDistance = num9;
					waypoint_0[i].ActualSpeed = float_;
				}
				if (i > 0)
				{
					waypoint_0[i].FlightplanPointsList = list_;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200616", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void DestroyTokenizer(ref Mission.Flight flight_0, ref Waypoint waypoint_0, string string_0, bool bool_0 = true)
	{
		if (Information.IsNothing(_ReaderConsumer) || Information.IsNothing(flight_0) || flight_0.GetIsActive(null))
		{
			return;
		}
		if (Information.IsNothing(waypoint_0) || string.IsNullOrEmpty(waypoint_0.Description))
		{
			Mission.Flight obj = flight_0;
			Waypoint[] waypoint_ = obj.FlightPlan;
			MoveTokenizer(ref waypoint_);
			obj.FlightPlan = waypoint_;
		}
		if (!_ReaderConsumer.Contains(string_0))
		{
			_ReaderConsumer.Add(string_0);
			if (bool_0)
			{
				propertyConsumer = true;
			}
		}
	}

	internal static bool ComputeTokenizer(ref ActiveUnit activeUnit_0, ref Waypoint[] waypoint_0, ref Waypoint[] waypoint_1, bool bool_0, ref Mission.Flight flight_0, object object_0)
	{
		try
		{
			int num = waypoint_0.Count();
			DateTime? dateTime = null;
			int num10 = 0;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			float? num11 = null;
			int num12 = 0;
			double num13 = 0.0;
			int num14 = num - 1;
			Waypoint waypoint = null;
			for (int i = 0; i <= num14; i++)
			{
				Waypoint waypoint2 = waypoint_0[i];
				if (Information.IsNothing(waypoint2))
				{
					continue;
				}
				DateTime? dateTime2 = null;
				float num15 = 0f;
				float num16 = 0f;
				float num17 = 0f;
				float num2 = 0f;
				float num3 = 0f;
				float num4 = 0f;
				float num5 = 0f;
				if (i > 0 && waypoint_0[i].Type == Waypoint.WaypointType.WeaponTarget && waypoint_0[i - 1].Type == Waypoint.WaypointType.WeaponTarget)
				{
					continue;
				}
				if (waypoint2.Type == Waypoint.WaypointType.TakeOff)
				{
					if (!Information.IsNothing(waypoint2.Time_Zulu) && (waypoint2.TimeFixed == Waypoint.FixedFree.Fixed || waypoint2.TimeFixed == Waypoint.FixedFree.Relative))
					{
						if (Information.IsNothing(waypoint2.Time_Zulu))
						{
							if (Information.IsNothing(waypoint.Time_Zulu))
							{
								num11 = 0f;
							}
						}
						else
						{
							dateTime = waypoint2.Time_Zulu.Value;
						}
						flag = true;
						num10 = 0;
					}
				}
				else
				{
					int num6 = i;
					int num7 = num - 1;
					for (int j = num6; j <= num7; j++)
					{
						waypoint = waypoint_0[j];
						if (Information.IsNothing(waypoint))
						{
							continue;
						}
						if (bool_0)
						{
							switch (j)
							{
							case 1:
								if (Information.IsNothing(waypoint.Time_Zulu))
								{
									num11 = 0f;
								}
								else
								{
									dateTime = waypoint.Time_Zulu.Value;
								}
								flag = true;
								num10 = j;
								continue;
							case 0:
								continue;
							}
						}
						if (j > 0 && waypoint_0[i].Type == Waypoint.WaypointType.WeaponTarget && waypoint_0[i - 1].Type == Waypoint.WaypointType.WeaponTarget)
						{
							continue;
						}
						if (flag)
						{
							if (waypoint.Leg_PreviousWaypointIsFixedSpeed)
							{
								if (!Information.IsNothing(waypoint.Leg_Speed_Straight) && waypoint.Leg_Speed_Straight > 0f && !Information.IsNothing(waypoint.Leg_Distance_Straight) && waypoint.Leg_Distance_Straight > 0f)
								{
									num16 += waypoint.Leg_Distance_Straight / waypoint.Leg_Speed_Straight * 3600f;
								}
								if (!Information.IsNothing(waypoint.Leg_Speed_Turn) && waypoint.Leg_Speed_Turn > 0f && !Information.IsNothing(waypoint.Leg_Distance_Turn) && waypoint.Leg_Distance_Turn > 0f)
								{
									if (!waypoint.Leg_TwoWaypointsAgoIsFixedSpeed && waypoint != waypoint_0[num10 + 1])
									{
										num17 += waypoint.Leg_Distance_Turn / waypoint.Leg_Speed_Turn * 3600f;
										num15 += waypoint.Leg_Distance_Turn;
									}
									else
									{
										num16 += waypoint.Leg_Distance_Turn / waypoint.Leg_Speed_Turn * 3600f;
									}
								}
							}
							else
							{
								if (!Information.IsNothing(waypoint.Leg_Speed_Straight) && waypoint.Leg_Speed_Straight > 0f && !Information.IsNothing(waypoint.Leg_Distance_Straight) && waypoint.Leg_Distance_Straight > 0f)
								{
									num15 += waypoint.Leg_Distance_Straight;
									num17 += waypoint.Leg_Distance_Straight / waypoint.Leg_Speed_Straight * 3600f;
									num12++;
								}
								if (!Information.IsNothing(waypoint.Leg_Speed_Turn) && waypoint.Leg_Speed_Turn > 0f && !Information.IsNothing(waypoint.Leg_Distance_Turn) && waypoint.Leg_Distance_Turn > 0f)
								{
									if (!waypoint.Leg_TwoWaypointsAgoIsFixedSpeed && waypoint != waypoint_0[num10 + 1])
									{
										num17 += waypoint.Leg_Distance_Turn / waypoint.Leg_Speed_Turn * 3600f;
										num15 += waypoint.Leg_Distance_Turn;
									}
									else
									{
										num16 += waypoint.Leg_Distance_Turn / waypoint.Leg_Speed_Turn * 3600f;
									}
								}
							}
							num2 += waypoint.Hold_Time;
							num3 += waypoint.Station_Time;
							num4 += waypoint.SpacingManeuver_Time;
							num5 += waypoint.Leg_Time_Turn + waypoint.Leg_Time_Straight;
							if (!Information.IsNothing(num11) && !Information.IsNothing(waypoint_1))
							{
								num11 = num11 + waypoint_1[j].Hold_Time + waypoint_1[j].Station_Time + waypoint_1[j].SpacingManeuver_Time + waypoint_1[j].Leg_Time_Turn + waypoint_1[j].Leg_Time_Straight;
							}
						}
						if (flag)
						{
							if ((!Information.IsNothing(waypoint.Time_Zulu) && (waypoint.TimeFixed == Waypoint.FixedFree.Fixed || waypoint.TimeFixed == Waypoint.FixedFree.Relative)) || (bool_0 && j == num - 1))
							{
								if (Information.IsNothing(waypoint.Time_Zulu))
								{
									if (bool_0 && !Information.IsNothing(waypoint_1) && !Information.IsNothing(waypoint_1[j].Time_Zulu))
									{
										dateTime2 = waypoint_1[j].Time_Zulu.Value;
									}
								}
								else
								{
									dateTime2 = waypoint.Time_Zulu.Value;
								}
								if (num12 == 0 && !Information.IsNothing(num11) && bool_0)
								{
									Waypoint waypoint_2 = null;
									DestroyTokenizer(ref flight_0, ref waypoint_2, "错误！任务" + flight_0.ParentMissionOrPackageName + "，飞行编队" + flight_0.Callsign + (string)object_0 + "：拆分航段没有自由速度航点！");
								}
								if (num17 > 0f)
								{
									num13 = ((!Information.IsNothing(dateTime2) && !Information.IsNothing(dateTime)) ? (dateTime2.Value - dateTime.Value).TotalSeconds : (Information.IsNothing(num11) ? 0.0 : ((double)num11.Value)));
									if (Math.Abs((double)num5 - num13) < 1.0)
									{
										num13 = num5;
									}
									num13 = num13 - (double)num16 - (double)num2 - (double)num4 - (double)num3;
									if (num13 <= 0.0)
									{
										if (!bool_0)
										{
											if (waypoint.Station_Time <= 0f)
											{
												if (waypoint.Hold_Time > 0f)
												{
													Waypoint waypoint_3 = null;
													DestroyTokenizer(ref flight_0, ref waypoint_3, "错误！任务" + flight_0.ParentMissionOrPackageName + "，飞行编队" + flight_0.Callsign + (string)object_0 + "：  航点" + Conversions.ToString(j + 1) + "是一个结束警戒航点。航点时间和持续时间有问题。保持时间是否超过在两个锁定的航点之间飞行所需的时间？");
												}
											}
											else
											{
												Waypoint waypoint_4 = null;
												DestroyTokenizer(ref flight_0, ref waypoint_4, "错误！任务" + flight_0.ParentMissionOrPackageName + "，飞行编队" + flight_0.Callsign + (string)object_0 + "：  航点" + Conversions.ToString(j + 1) + "是一个结束巡逻航点。航点时间和巡逻时间有问题。巡逻时间是否超过在两个锁定航路点之间飞行所需的时间？");
											}
										}
									}
									else
									{
										int num8 = num10 + 1;
										int num9 = j;
										for (int k = num8; k <= num9; k++)
										{
											Waypoint waypoint3 = waypoint_0[k];
											if (k > 0 && waypoint_0[k].Type == Waypoint.WaypointType.WeaponTarget && waypoint_0[k - 1].Type == Waypoint.WaypointType.WeaponTarget)
											{
												continue;
											}
											float float_;
											float float_2;
											if (!waypoint3.Leg_PreviousWaypointIsFixedSpeed)
											{
												float_ = (float)((double)num15 / (num13 / 3600.0));
												float_ = ActiveUnit_Kinematics.RoundAircraftSpeed(float_);
												int minimumSpeed = activeUnit_0.Kinematics.GetMinimumSpeed(waypoint3.Altitude, ActiveUnit.Throttle.Loiter, bool_0: false);
												if (float_ < (float)minimumSpeed)
												{
													float_ = minimumSpeed;
												}
												if (bool_0 && waypoint_1[k].DesiredSpeed.Value != 0f && Math.Abs(float_ - waypoint_1[k].DesiredSpeed.Value) < 20f)
												{
													float_ = waypoint_1[k].DesiredSpeed.Value;
												}
												else if (bool_0 && waypoint_1[k].Leg_Time_ErrorMargin != 0f && waypoint_1[k].DesiredSpeed.Value < (float)((double)num15 / ((num13 - (double)Math.Abs(waypoint_1[k].Leg_Time_ErrorMargin)) / 3600.0)) && waypoint_1[k].DesiredSpeed.Value > (float)((double)num15 / ((num13 + (double)Math.Abs(waypoint_1[k].Leg_Time_ErrorMargin)) / 3600.0)))
												{
													float_ = waypoint_1[k].DesiredSpeed.Value;
												}
												else if (float_ > 500f && k > 0 && float_ - waypoint_0[k - 1].DesiredSpeed.Value != 0f && Math.Abs(float_ - waypoint_0[k - 1].DesiredSpeed.Value) < 20f && k > 1 && Math.Abs(float_ - waypoint_0[k - 2].DesiredSpeed.Value) > 0f)
												{
													float_ = waypoint_0[k - 1].DesiredSpeed.Value;
												}
												if (num13 <= 0.0)
												{
													float_ = 10000f;
												}
												else
												{
													if (!waypoint3.Leg_TwoWaypointsAgoIsFixedSpeed && waypoint3 != waypoint_0[num10 + 1] && waypoint3.Leg_Distance_Turn > 0f)
													{
														num15 -= Math.Max(waypoint3.Leg_Distance_Turn, 0f);
														num13 -= (double)(waypoint3.Leg_Distance_Turn / float_ * 3600f);
													}
													num15 -= Math.Max(waypoint3.Leg_Distance_Straight, 0f);
													num13 -= (double)(waypoint3.Leg_Distance_Straight / float_ * 3600f);
												}
												if (!flag2 && float_ != waypoint_0[k - 1].DesiredSpeed.Value)
												{
													flag2 = true;
												}
												waypoint_0[k - 1].DesiredSpeed = float_;
												if (!Information.IsNothing(waypoint_0[k - 1].DesiredAltitude))
												{
													float? desiredAltitude = waypoint_0[k - 1].DesiredAltitude;
													if ((desiredAltitude.HasValue ? new bool?(desiredAltitude.GetValueOrDefault() > 0f) : null).GetValueOrDefault())
													{
														float_2 = waypoint_0[k - 1].DesiredAltitude.Value;
														goto IL_0dbd;
													}
												}
												bool? flag4;
												if (Information.IsNothing(waypoint_0[k - 1].DesiredAltitude_TerrainFollowing))
												{
													flag4 = false;
												}
												else
												{
													float? desiredAltitude_TerrainFollowing = waypoint_0[k - 1].DesiredAltitude_TerrainFollowing;
													flag4 = (desiredAltitude_TerrainFollowing.HasValue ? new bool?(desiredAltitude_TerrainFollowing.GetValueOrDefault() > 0f) : null);
												}
												bool? flag5 = flag4;
												float_2 = (((!flag5).GetValueOrDefault() || !waypoint_0[k - 1].TerrainFollowing || !flag5.HasValue) ? 0f : waypoint_0[k - 1].DesiredAltitude_TerrainFollowing.Value);
												goto IL_0dbd;
											}
											goto IL_0da1;
											IL_0da1:
											if (!bool_0)
											{
												waypoint3.Leg_Time_ErrorMargin = (float)num13;
											}
											continue;
											IL_0dbd:
											if (activeUnit_0 != null && float_ == (float)activeUnit_0.Kinematics.GetMaximumSpeed(float_2, activeUnit_0.Kinematics.GetThrottleSuitableForThisSpeed(float_2, float_), bool_0: false))
											{
												waypoint_0[k - 1].ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)activeUnit_0.Kinematics.GetThrottleSuitableForThisSpeed(float_2, float_);
												waypoint_0[k - 1].DesiredSpeedOverride = null;
											}
											else
											{
												waypoint_0[k - 1].ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
												waypoint_0[k - 1].DesiredSpeedOverride = float_;
											}
											if (waypoint_0.Count() - 1 >= k + 1)
											{
												waypoint_0[k + 1].Leg_Speed_Turn = float_;
											}
											if (waypoint_0.Count() - 1 >= k)
											{
												waypoint_0[k].Leg_Speed_Straight = float_;
											}
											goto IL_0da1;
										}
									}
									dateTime = dateTime2;
									num10 = j;
									if (Information.IsNothing(waypoint.Time_Zulu))
									{
										num11 = 0f;
									}
									num12 = 0;
								}
								i = j;
								if (Information.IsNothing(waypoint.Time_Zulu))
								{
									if (Information.IsNothing(waypoint.Time_Zulu))
									{
										num11 = 0f;
									}
								}
								else
								{
									dateTime = waypoint.Time_Zulu.Value;
								}
								flag = true;
								num10 = j;
								break;
							}
							if (!bool_0)
							{
								waypoint.Leg_Time_ErrorMargin = (float)num13;
							}
						}
						else if (waypoint.TimeFixed == Waypoint.FixedFree.Fixed || waypoint.TimeFixed == Waypoint.FixedFree.Relative)
						{
							if (Information.IsNothing(waypoint.Time_Zulu))
							{
								num11 = 0f;
							}
							else
							{
								dateTime = waypoint.Time_Zulu.Value;
							}
							flag = true;
							num10 = j;
						}
						if (j + 1 >= waypoint_0.Count())
						{
							flag3 = true;
						}
					}
				}
				if (flag3)
				{
					break;
				}
			}
			return flag2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200617", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public static void CreateFlightPlanCurve(ref float float_0, ref List<Waypoint.FlightPlanSegment> list_0, ref Waypoint waypoint_0, ref Waypoint waypoint_1, ref Waypoint waypoint_2, ref float float_1, float float_2, ref Mission.Flight flight_0, float float_3, Misc.TurnDirection turnDirection_0, float float_4, ref bool bool_0, bool bool_1, string string_0, Waypoint[] waypoint_3)
	{
		try
		{
			if (Information.IsNothing(waypoint_0) || Information.IsNothing(waypoint_1))
			{
				return;
			}
			float num = float_0;
			float num12 = ((waypoint_1.EnableReponse() && waypoint_0.SearchReponse()) ? ActiveUnit_Kinematics.TurnRateCategoryToActualTurnRate(waypoint_0.TurnRate_Navigation, float_2) : ((!waypoint_1.InitReponse() || !waypoint_0.ChangeReponse()) ? ActiveUnit_Kinematics.TurnRateCategoryToActualTurnRate(waypoint_1.TurnRate_Navigation, float_2) : ActiveUnit_Kinematics.TurnRateCategoryToActualTurnRate(waypoint_0.TurnRate_Navigation, float_2)));
			if (waypoint_1.Type == Waypoint.WaypointType.WeaponTarget && !Information.IsNothing(waypoint_1.FlightplanPointsList) && waypoint_1.FlightplanPointsList.Count > 0)
			{
				double endLatitude = waypoint_1.FlightplanPointsList[waypoint_1.FlightplanPointsList.Count - 1].EndLatitude;
				double endLongitude = waypoint_1.FlightplanPointsList[waypoint_1.FlightplanPointsList.Count - 1].EndLongitude;
				waypoint_1 = new Waypoint(endLongitude, endLatitude, 0f, Waypoint.WaypointType.WeaponTarget, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
				float_4 = Math2.PublishClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_0.Latitude, waypoint_0.Longitude);
			}
			float num19 = Math.Abs(MathFunctions.DeleteRequest(float_0, float_4));
			float num20 = Math.Abs(float_3) / num12;
			float num21 = float_2 / 3600f * num20;
			float num22 = (float)((double)float_2 / ((double)num12 * 3.14159265358979 * 20.0));
			float num23 = Math2.VerifyClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_0.Latitude, waypoint_0.Longitude);
			float num24 = (float)((double)(2f * num22) * Math.Sin(0.5 * MathFunctions.DestroyRequest(num19))) + num21 * 2f;
			bool_0 = false;
			if (num23 < num24)
			{
				bool_0 = true;
				if (bool_1)
				{
					waypoint_0.Leg_Time_Turn = 0f;
					waypoint_0.Leg_Time_Straight = 0f;
					return;
				}
			}
			if (bool_0)
			{
				if (Information.IsNothing(waypoint_3))
				{
					DestroyTokenizer(ref flight_0, ref waypoint_0, "错误！任务" + flight_0.ParentMissionOrPackageName + "，飞行编队" + flight_0.Callsign + string_0 + "：两个航点太近了。");
				}
				else
				{
					if (Information.IsNothing(waypoint_1.Description) || Information.IsNothing(waypoint_0.Description))
					{
						Mission.Flight obj = flight_0;
						Waypoint[] waypoint_4 = obj.FlightPlan;
						MoveTokenizer(ref waypoint_4);
						obj.FlightPlan = waypoint_4;
					}
					DestroyTokenizer(ref flight_0, ref waypoint_0, "错误！任务" + flight_0.ParentMissionOrPackageName + "，飞行编队" + flight_0.Callsign + string_0 + "： 航点" + waypoint_1.Description + "离航点太近了" + waypoint_0.Description + ".");
				}
			}
			float num25 = 0f;
			if (!bool_0)
			{
				if (waypoint_0.EnableReponse() && waypoint_1.Type == Waypoint.WaypointType.StationStart_Area)
				{
					float float_5 = Math2.VerifyClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_0.Latitude, waypoint_0.Longitude);
					Waypoint waypoint;
					double double_ = (waypoint = waypoint_1).Latitude;
					Waypoint.FlightPlanSegment flightPlanSegment = new Waypoint.FlightPlanSegment(ref double_, waypoint_1.Longitude, waypoint_0.Latitude, waypoint_0.Longitude);
					waypoint.Latitude = double_;
					Waypoint.FlightPlanSegment item = flightPlanSegment;
					list_0.Add(item);
					double double_12 = waypoint_0.Latitude;
					double longitude = waypoint_0.Longitude;
					double double_14 = 0.0;
					double double_15 = 0.0;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude, double_12, ref double_14, ref double_15, 8f, Math2.UpdateClass(float_4 - 20f));
					item = new Waypoint.FlightPlanSegment(ref double_12, longitude, double_15, double_14);
					list_0.Add(item);
					double_12 = double_15;
					longitude = double_14;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude, double_12, ref double_14, ref double_15, 10f, Math2.UpdateClass(float_4 - 90f));
					item = new Waypoint.FlightPlanSegment(ref double_12, longitude, double_15, double_14);
					list_0.Add(item);
					double_12 = double_15;
					longitude = double_14;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude, double_12, ref double_14, ref double_15, 8f, Math2.UpdateClass(float_4 - 160f));
					item = new Waypoint.FlightPlanSegment(ref double_12, longitude, double_15, double_14);
					list_0.Add(item);
					double_12 = double_15;
					longitude = double_14;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude, double_12, ref double_14, ref double_15, float_5, Math2.UpdateClass(float_4 - 180f));
					item = new Waypoint.FlightPlanSegment(ref double_12, longitude, double_15, double_14);
					list_0.Add(item);
					double_12 = double_15;
					longitude = double_14;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude, double_12, ref double_14, ref double_15, 8f, Math2.UpdateClass(float_4 - 200f));
					item = new Waypoint.FlightPlanSegment(ref double_12, longitude, double_15, double_14);
					list_0.Add(item);
					double_12 = double_15;
					longitude = double_14;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude, double_12, ref double_14, ref double_15, 10f, Math2.UpdateClass(float_4 - 270f));
					item = new Waypoint.FlightPlanSegment(ref double_12, longitude, double_15, double_14);
					list_0.Add(item);
					item = new Waypoint.FlightPlanSegment(ref double_15, double_14, waypoint_1.Latitude, waypoint_1.Longitude);
					list_0.Add(item);
					waypoint_0.Leg_Distance_Straight = 0f;
					waypoint_0.Leg_Speed_Turn = 0f;
					waypoint_0.Leg_Distance_Turn = 0f;
					waypoint_0.Leg_Speed_Straight = float_1;
					float_0 = 0f;
					waypoint_0.Leg_Time_Turn = 0f;
					waypoint_0.Leg_Time_Straight = 0f;
					return;
				}
				if (!Information.IsNothing(waypoint_0.Time_Zulu) && waypoint_0.InitReponse() && waypoint_1.ChangeReponse())
				{
					float float_6 = Math2.VerifyClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_0.Latitude, waypoint_0.Longitude);
					Waypoint waypoint2;
					double double_16 = (waypoint2 = waypoint_1).Latitude;
					Waypoint.FlightPlanSegment flightPlanSegment2 = new Waypoint.FlightPlanSegment(ref double_16, waypoint_1.Longitude, waypoint_0.Latitude, waypoint_0.Longitude);
					waypoint2.Latitude = double_16;
					Waypoint.FlightPlanSegment item12 = flightPlanSegment2;
					list_0.Add(item12);
					float num2 = Math.Abs(float_3);
					float num3 = Math2.UpdateClass(num + num2);
					double double_17 = waypoint_0.Latitude;
					double num4 = waypoint_0.Longitude;
					int i = 0;
					int num5 = (int)Math.Round(180f / num2) - 1;
					float num6 = num3;
					Math2.UpdateClass(float_4 + 180f);
					double double_18 = 0.0;
					double double_19 = 0.0;
					for (; i <= num5; i++)
					{
						try
						{
							Geodesic_EdWilliams.CalcPoint_Williams(num4, double_17, ref double_18, ref double_19, num21, num6);
							item12 = new Waypoint.FlightPlanSegment(ref double_17, num4, double_19, double_18);
							list_0.Add(item12);
							num25 += num20;
							double_17 = double_19;
							num4 = double_18;
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
						num6 = Math2.UpdateClass(num6 + num2);
					}
					double double_20 = 0.0;
					double double_2 = 0.0;
					Geodesic_EdWilliams.CalcPoint_Williams(num4, double_17, ref double_20, ref double_2, float_6, Math2.UpdateClass(float_4 + 180f));
					item12 = new Waypoint.FlightPlanSegment(ref double_17, num4, double_2, double_20);
					list_0.Add(item12);
					double_17 = double_2;
					num4 = double_20;
					waypoint_0.RaceTrackHelperPoint = new GeoPoint(double_20, double_2);
					Math2.UpdateClass(float_4 + 180f + num2);
					for (i = 0; i <= num5 - 1; i++)
					{
						try
						{
							Geodesic_EdWilliams.CalcPoint_Williams(num4, double_17, ref double_18, ref double_19, num21, num6);
							item12 = new Waypoint.FlightPlanSegment(ref double_17, num4, double_19, double_18);
							list_0.Add(item12);
							num25 += num20;
							double_17 = double_19;
							num4 = double_18;
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							ProjectData.ClearProjectError();
						}
						num6 = Math2.UpdateClass(num6 + num2);
					}
					item12 = new Waypoint.FlightPlanSegment(ref double_17, num4, waypoint_1.Latitude, waypoint_1.Longitude);
					list_0.Add(item12);
					waypoint_0.Leg_Distance_Straight = 0f;
					waypoint_0.Leg_Speed_Turn = 0f;
					waypoint_0.Leg_Distance_Turn = 0f;
					waypoint_0.Leg_Speed_Straight = float_1;
					float_0 = 0f;
					waypoint_0.Leg_Time_Turn = 0f;
					waypoint_0.Leg_Time_Straight = 0f;
					return;
				}
			}
			if (!bool_0 && num19 > Math.Abs(float_3 * 2f))
			{
				float num7 = Math2.UpdateClass(num + float_3);
				double double_3 = waypoint_1.Latitude;
				double num8 = waypoint_1.Longitude;
				int num9 = 0;
				int num10 = (int)Math.Round(360f / Math.Abs(float_3));
				float num11 = num7;
				float num13 = Math2.UpdateClass(float_4);
				float num14 = num13;
				double double_4 = 0.0;
				double double_5 = 0.0;
				do
				{
					switch (turnDirection_0)
					{
					case Misc.TurnDirection.TurnRight:
						if (num7 <= num13)
						{
							if (num11 >= num14 && num11 > num7)
							{
								num7 = num11;
								num13 = num14;
							}
						}
						else if (num11 >= num14 && num11 < num7)
						{
							num7 = num11;
							num13 = num14;
						}
						break;
					case Misc.TurnDirection.TurnLeft:
						if (num7 <= num13)
						{
							if (num11 <= num14 && num11 > num7)
							{
								num7 = num11;
								num13 = num14;
							}
						}
						else if (num11 <= num14 && num11 < num7)
						{
							num7 = num11;
							num13 = num14;
						}
						break;
					}
					num9++;
					if ((int)Math.Round(num11) == (int)Math.Round(num14))
					{
						try
						{
							Geodesic_EdWilliams.CalcPoint_Williams(num8, double_3, ref double_4, ref double_5, num21, num11);
							Waypoint.FlightPlanSegment item16 = new Waypoint.FlightPlanSegment(ref double_3, num8, double_5, double_4);
							list_0.Add(item16);
							num25 += num20;
							double_3 = double_5;
							num8 = double_4;
						}
						catch (Exception projectError3)
						{
							ProjectData.SetProjectError(projectError3);
							ProjectData.ClearProjectError();
							goto IL_0aa6;
						}
						break;
					}
					try
					{
						Geodesic_EdWilliams.CalcPoint_Williams(num8, double_3, ref double_4, ref double_5, num21, num11);
						Waypoint.FlightPlanSegment item17 = new Waypoint.FlightPlanSegment(ref double_3, num8, double_5, double_4);
						list_0.Add(item17);
						num25 += num20;
						double_3 = double_5;
						num8 = double_4;
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						ProjectData.ClearProjectError();
					}
					goto IL_0aa6;
					IL_0aa6:
					num14 = Math2.PublishClass(double_3, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					num11 = Math2.UpdateClass(num11 + float_3);
					if (num9 >= num10)
					{
						bool_0 = true;
						waypoint_0.Leg_Time_Turn = 0f;
						waypoint_0.Leg_Time_Straight = 0f;
						return;
					}
				}
				while (!(Math.Abs(MathFunctions.DeleteRequest(num11, num14)) <= 9f));
				if (waypoint_0.Type == Waypoint.WaypointType.WeaponTarget)
				{
					bool flag = true;
					if (Information.IsNothing(waypoint_2))
					{
						if (waypoint_0.TargeteeringMethod == Mission._TargeteeringMethod.Individual && !Information.IsNothing(waypoint_0.WeaponeeringList))
						{
							foreach (Mission.WeaponeeringEntry weaponeering in waypoint_0.WeaponeeringList)
							{
								if (!Information.IsNothing(weaponeering.Route) && weaponeering.Route.Count() > 0)
								{
									flag = false;
									break;
								}
							}
						}
					}
					else if (waypoint_2.TargeteeringMethod == Mission._TargeteeringMethod.Individual)
					{
						if (flag && waypoint_2.Waypoint_LeadElementWingman == waypoint_0 && !Information.IsNothing(waypoint_2.WeaponeeringList_LeadElementWingman))
						{
							foreach (Mission.WeaponeeringEntry item5 in waypoint_2.WeaponeeringList_LeadElementWingman)
							{
								if (!Information.IsNothing(item5.Route) && item5.Route.Count() > 0)
								{
									flag = false;
									break;
								}
							}
						}
						if (flag && waypoint_2.Waypoint_SecondElement == waypoint_0 && !Information.IsNothing(waypoint_2.WeaponeeringList_SecondElement))
						{
							foreach (Mission.WeaponeeringEntry item6 in waypoint_2.WeaponeeringList_SecondElement)
							{
								if (!Information.IsNothing(item6.Route) && item6.Route.Count() > 0)
								{
									flag = false;
									break;
								}
							}
						}
						if (flag && waypoint_2.Waypoint_SecondElementWingman == waypoint_0 && !Information.IsNothing(waypoint_2.WeaponeeringList_SecondElementWingman))
						{
							foreach (Mission.WeaponeeringEntry item7 in waypoint_2.WeaponeeringList_SecondElementWingman)
							{
								if (!Information.IsNothing(item7.Route) && item7.Route.Count() > 0)
								{
									flag = false;
									break;
								}
							}
						}
						if (flag && waypoint_2.Waypoint_ThirdElement == waypoint_0 && !Information.IsNothing(waypoint_2.WeaponeeringList_ThirdElement))
						{
							foreach (Mission.WeaponeeringEntry item8 in waypoint_2.WeaponeeringList_ThirdElement)
							{
								if (!Information.IsNothing(item8.Route) && item8.Route.Count() > 0)
								{
									flag = false;
									break;
								}
							}
						}
						if (flag && waypoint_2.Waypoint_ThirdElementWingman == waypoint_0 && !Information.IsNothing(waypoint_2.WeaponeeringList_ThirdElementWingman))
						{
							foreach (Mission.WeaponeeringEntry item9 in waypoint_2.WeaponeeringList_ThirdElementWingman)
							{
								if (!Information.IsNothing(item9.Route) && item9.Route.Count() > 0)
								{
									flag = false;
									break;
								}
							}
						}
					}
					Waypoint.FlightPlanSegment item18;
					if (flag)
					{
						Waypoint waypoint3;
						double double_6 = (waypoint3 = waypoint_0).Latitude;
						Waypoint.FlightPlanSegment flightPlanSegment3 = new Waypoint.FlightPlanSegment(ref double_6, waypoint_0.Longitude, double_3, num8);
						waypoint3.Latitude = double_6;
						item18 = flightPlanSegment3;
						list_0.Add(item18);
					}
					float float_7 = Math2.PublishClass(double_3, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					float num15 = Math2.VerifyClass(double_3, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					float num16 = Math.Min(5f, num15 - 1f);
					double double_7 = 0.0;
					double double_8 = 0.0;
					if (num16 <= 0f)
					{
						waypoint_0.Leg_Distance_Straight = 0f;
						double_7 = num8;
						double_8 = double_3;
					}
					else
					{
						waypoint_0.Leg_Distance_Straight = num16;
						Geodesic_EdWilliams.CalcPoint_Williams(num8, double_3, ref double_7, ref double_8, num16, float_7);
					}
					item18 = new Waypoint.FlightPlanSegment(ref double_3, num8, double_8, double_7);
					list_0.Add(item18);
					waypoint_0.Leg_Distance_Turn = float_2 * num25 / 3600f;
					waypoint_0.Leg_Speed_Straight = float_1;
					waypoint_0.Leg_Speed_Turn = float_2;
					float_0 = Math2.UpdateClass(Math2.PublishClass(waypoint_0.Latitude, waypoint_0.Longitude, list_0[list_0.Count - 1].StartLatitude, list_0[list_0.Count - 1].StartLongitude) + 180f);
					waypoint_0.Leg_Time_Turn = num25;
					waypoint_0.Leg_Time_Straight = waypoint_0.Leg_Distance_Straight / float_1 * 3600f;
				}
				else if (waypoint_0.EnableReponse() && waypoint_1.SearchReponse())
				{
					Waypoint.FlightPlanSegment item19 = new Waypoint.FlightPlanSegment(ref double_3, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					list_0.Add(item19);
					waypoint_0.Leg_Distance_Straight = Math2.VerifyClass(double_3, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					waypoint_0.Leg_Speed_Turn = float_2;
					waypoint_0.Leg_Distance_Turn = float_2 * num25 / 3600f;
					waypoint_0.Leg_Speed_Straight = float_1;
					float_0 = Math2.UpdateClass(Math2.PublishClass(waypoint_0.Latitude, waypoint_0.Longitude, list_0[list_0.Count - 1].StartLatitude, list_0[list_0.Count - 1].StartLongitude) + 180f);
					waypoint_0.Leg_Time_Turn = num25;
					waypoint_0.Leg_Time_Straight = waypoint_0.Leg_Distance_Straight / float_1 * 3600f;
				}
				else if (waypoint_0.SearchReponse() && waypoint_1.EnableReponse())
				{
					Waypoint.FlightPlanSegment item20 = new Waypoint.FlightPlanSegment(ref double_3, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					list_0.Add(item20);
					waypoint_1.Leg_Distance_Straight += Math2.VerifyClass(double_3, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					waypoint_1.Leg_Time_Straight = waypoint_0.Leg_Distance_Straight / waypoint_1.Leg_Speed_Straight * 3600f;
					waypoint_1.Leg_Time_Turn += num25;
					waypoint_1.Leg_Distance_Turn = waypoint_1.Leg_Speed_Turn * waypoint_1.Leg_Time_Turn / 3600f;
				}
				else if (!Information.IsNothing(waypoint_0.Time_Zulu) && waypoint_0.InitReponse() && waypoint_1.ChangeReponse())
				{
					Waypoint.FlightPlanSegment item21 = new Waypoint.FlightPlanSegment(ref double_3, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					list_0.Add(item21);
					waypoint_0.Leg_Distance_Straight = Math2.VerifyClass(double_3, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					waypoint_0.Leg_Speed_Turn = float_2;
					waypoint_0.Leg_Distance_Turn = float_2 * num25 / 3600f;
					waypoint_0.Leg_Speed_Straight = float_1;
					float_0 = Math2.UpdateClass(Math2.PublishClass(waypoint_0.Latitude, waypoint_0.Longitude, list_0[list_0.Count - 1].StartLatitude, list_0[list_0.Count - 1].StartLongitude) + 180f);
					waypoint_0.Leg_Time_Turn = num25;
					waypoint_0.Leg_Time_Straight = waypoint_0.Leg_Distance_Straight / float_1 * 3600f;
				}
				else if (!Information.IsNothing(waypoint_0.Time_Zulu) && waypoint_0.ChangeReponse() && waypoint_1.InitReponse())
				{
					Waypoint.FlightPlanSegment item22 = new Waypoint.FlightPlanSegment(ref double_3, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					list_0.Add(item22);
					waypoint_1.Leg_Distance_Straight += Math2.VerifyClass(double_3, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					waypoint_1.Leg_Time_Straight = waypoint_0.Leg_Distance_Straight / waypoint_1.Leg_Speed_Straight * 3600f;
					waypoint_1.Leg_Time_Turn += num25;
					waypoint_1.Leg_Distance_Turn = waypoint_1.Leg_Speed_Turn * waypoint_1.Leg_Time_Turn / 3600f;
				}
				else
				{
					Waypoint.FlightPlanSegment item2 = new Waypoint.FlightPlanSegment(ref double_3, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					list_0.Add(item2);
					waypoint_0.Leg_Distance_Straight = Math2.VerifyClass(double_3, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					waypoint_0.Leg_Speed_Turn = float_2;
					waypoint_0.Leg_Distance_Turn = float_2 * num25 / 3600f;
					waypoint_0.Leg_Speed_Straight = float_1;
					float_0 = Math2.UpdateClass(Math2.PublishClass(waypoint_0.Latitude, waypoint_0.Longitude, list_0[list_0.Count - 1].StartLatitude, list_0[list_0.Count - 1].StartLongitude) + 180f);
					waypoint_0.Leg_Time_Turn = num25;
					waypoint_0.Leg_Time_Straight = waypoint_0.Leg_Distance_Straight / float_1 * 3600f;
				}
			}
			else if (waypoint_0.Type == Waypoint.WaypointType.WeaponTarget)
			{
				bool flag2 = true;
				if (Information.IsNothing(waypoint_2))
				{
					if (waypoint_0.TargeteeringMethod == Mission._TargeteeringMethod.Individual && !Information.IsNothing(waypoint_0.WeaponeeringList))
					{
						foreach (Mission.WeaponeeringEntry weaponeering2 in waypoint_0.WeaponeeringList)
						{
							if (!Information.IsNothing(weaponeering2.Route) && weaponeering2.Route.Count() > 0)
							{
								flag2 = false;
								break;
							}
						}
					}
				}
				else if (waypoint_2.TargeteeringMethod == Mission._TargeteeringMethod.Individual)
				{
					if (flag2 && waypoint_2.Waypoint_LeadElementWingman == waypoint_0 && !Information.IsNothing(waypoint_2.WeaponeeringList_LeadElementWingman))
					{
						foreach (Mission.WeaponeeringEntry item10 in waypoint_2.WeaponeeringList_LeadElementWingman)
						{
							if (!Information.IsNothing(item10.Route) && item10.Route.Count() > 0)
							{
								flag2 = false;
								break;
							}
						}
					}
					if (flag2 && waypoint_2.Waypoint_SecondElement == waypoint_0 && !Information.IsNothing(waypoint_2.WeaponeeringList_SecondElement))
					{
						foreach (Mission.WeaponeeringEntry item11 in waypoint_2.WeaponeeringList_SecondElement)
						{
							if (!Information.IsNothing(item11.Route) && item11.Route.Count() > 0)
							{
								flag2 = false;
								break;
							}
						}
					}
					if (flag2 && waypoint_2.Waypoint_SecondElementWingman == waypoint_0 && !Information.IsNothing(waypoint_2.WeaponeeringList_SecondElementWingman))
					{
						foreach (Mission.WeaponeeringEntry item13 in waypoint_2.WeaponeeringList_SecondElementWingman)
						{
							if (!Information.IsNothing(item13.Route) && item13.Route.Count() > 0)
							{
								flag2 = false;
								break;
							}
						}
					}
					if (flag2 && waypoint_2.Waypoint_ThirdElement == waypoint_0 && !Information.IsNothing(waypoint_2.WeaponeeringList_ThirdElement))
					{
						foreach (Mission.WeaponeeringEntry item14 in waypoint_2.WeaponeeringList_ThirdElement)
						{
							if (!Information.IsNothing(item14.Route) && item14.Route.Count() > 0)
							{
								flag2 = false;
								break;
							}
						}
					}
					if (flag2 && waypoint_2.Waypoint_ThirdElementWingman == waypoint_0 && !Information.IsNothing(waypoint_2.WeaponeeringList_ThirdElementWingman))
					{
						foreach (Mission.WeaponeeringEntry item15 in waypoint_2.WeaponeeringList_ThirdElementWingman)
						{
							if (!Information.IsNothing(item15.Route) && item15.Route.Count() > 0)
							{
								flag2 = false;
								break;
							}
						}
					}
				}
				double double_9;
				Waypoint waypoint4;
				Waypoint.FlightPlanSegment item3;
				if (flag2)
				{
					double_9 = (waypoint4 = waypoint_0).Latitude;
					Waypoint.FlightPlanSegment flightPlanSegment4 = new Waypoint.FlightPlanSegment(ref double_9, waypoint_0.Longitude, waypoint_1.Latitude, waypoint_1.Longitude);
					waypoint4.Latitude = double_9;
					item3 = flightPlanSegment4;
					list_0.Add(item3);
				}
				float float_8 = Math2.PublishClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_0.Latitude, waypoint_0.Longitude);
				float num17 = Math2.VerifyClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_0.Latitude, waypoint_0.Longitude);
				float num18 = Math.Min(5f, num17 - 1f);
				double double_10 = 0.0;
				double double_11 = 0.0;
				if (num18 <= 0f)
				{
					waypoint_0.Leg_Distance_Straight = 0f;
					double_10 = waypoint_1.Longitude;
					double_11 = waypoint_1.Latitude;
				}
				else
				{
					waypoint_0.Leg_Distance_Straight = num18;
					Geodesic_EdWilliams.CalcPoint_Williams(waypoint_1.Longitude, waypoint_1.Latitude, ref double_10, ref double_11, num18, float_8);
				}
				double_9 = (waypoint4 = waypoint_1).Latitude;
				Waypoint.FlightPlanSegment flightPlanSegment5 = new Waypoint.FlightPlanSegment(ref double_9, waypoint_1.Longitude, double_11, double_10);
				waypoint4.Latitude = double_9;
				item3 = flightPlanSegment5;
				list_0.Add(item3);
				waypoint_0.Leg_Distance_Turn = 0f;
				waypoint_0.Leg_Speed_Straight = float_1;
				float_0 = Math2.UpdateClass(Math2.PublishClass(waypoint_0.Latitude, waypoint_0.Longitude, list_0[list_0.Count - 1].StartLatitude, list_0[list_0.Count - 1].StartLongitude) + 180f);
				waypoint_0.Leg_Time_Turn = num25;
				waypoint_0.Leg_Time_Straight = waypoint_0.Leg_Distance_Straight / float_1 * 3600f;
			}
			else
			{
				Waypoint waypoint5;
				double double_13 = (waypoint5 = waypoint_1).Latitude;
				Waypoint.FlightPlanSegment flightPlanSegment6 = new Waypoint.FlightPlanSegment(ref double_13, waypoint_1.Longitude, waypoint_0.Latitude, waypoint_0.Longitude);
				waypoint5.Latitude = double_13;
				Waypoint.FlightPlanSegment item4 = flightPlanSegment6;
				list_0.Add(item4);
				waypoint_0.Leg_Distance_Straight = Math2.VerifyClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_0.Latitude, waypoint_0.Longitude);
				waypoint_0.Leg_Distance_Turn = 0f;
				waypoint_0.Leg_Speed_Straight = float_1;
				float_0 = Math2.UpdateClass(Math2.PublishClass(waypoint_0.Latitude, waypoint_0.Longitude, list_0[list_0.Count - 1].StartLatitude, list_0[list_0.Count - 1].StartLongitude) + 180f);
				waypoint_0.Leg_Time_Turn = num25;
				waypoint_0.Leg_Time_Straight = waypoint_0.Leg_Distance_Straight / float_1 * 3600f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200627", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal static GeoPoint PatchTokenizer(double double_0, double double_1, float float_0, float float_1, Waypoint.TurnRateCategory turnRateCategory_0, float float_2, float float_3, Misc.TurnDirection turnDirection_0, ref float float_4)
	{
		try
		{
			float num = ActiveUnit_Kinematics.TurnRateCategoryToActualTurnRate(turnRateCategory_0, float_2);
			if (Math.Abs(MathFunctions.DeleteRequest(float_0, float_1)) <= float_3 * 2f)
			{
				return new GeoPoint(double_1, double_0);
			}
			float num2 = Math.Abs(float_3) / num;
			float float_5 = float_2 / 3600f * num2;
			float num3 = Math2.UpdateClass(float_0 + float_3);
			int num4 = 0;
			int num5 = (int)Math.Round(360f / Math.Abs(float_3));
			float num6 = num3;
			float num7 = float_1;
			double double_2 = 0.0;
			double double_3 = 0.0;
			do
			{
				switch (turnDirection_0)
				{
				case Misc.TurnDirection.TurnRight:
					if (num3 <= float_1)
					{
						if (num6 >= num7 && num6 > num3)
						{
							num3 = num6;
							float_1 = num7;
						}
					}
					else if (num6 >= num7 && num6 < num3)
					{
						num3 = num6;
						float_1 = num7;
					}
					break;
				case Misc.TurnDirection.TurnLeft:
					if (num3 <= float_1)
					{
						if (num6 <= num7 && num6 > num3)
						{
							num3 = num6;
							float_1 = num7;
						}
					}
					else if (num6 <= num7 && num6 < num3)
					{
						num3 = num6;
						float_1 = num7;
					}
					break;
				}
				num4++;
				if ((int)Math.Round(num6) == (int)Math.Round(num7))
				{
					try
					{
						Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_2, ref double_3, float_5, num6);
						float_4 += num2;
						double_0 = double_3;
						double_1 = double_2;
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
						goto IL_01d8;
					}
					break;
				}
				try
				{
					Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_2, ref double_3, float_5, num6);
					float_4 += num2;
					double_0 = double_3;
					double_1 = double_2;
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
				goto IL_01d8;
				IL_01d8:
				num6 = Math2.UpdateClass(num6 + float_3);
				if (num4 >= num5)
				{
					return null;
				}
			}
			while (!(Math.Abs(MathFunctions.DeleteRequest(num6, float_1)) <= 9f));
			return new GeoPoint(double_2, double_3);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private unsafe static void SelectTokenizer(Scenario scenario_0, object object_0, Mission mission, Mission.Flight flight, ref Waypoint[] waypoint_0, bool bool_0, float float_0, float float_1, float float_2, float float_3, Misc.TurnDirection turnDirection_0, bool bool_1, bool bool_2, ref bool bool_3)
	{
		try
		{
			if (Information.IsNothing(mission) || mission.MissionClass != Mission._MissionClass.Strike)
			{
				return;
			}
			Mission._FlightSize flightSize = ((!(flight.DesiredAircraftQty <= 0) || object_0 == null) ? flight.DesiredAircraftQty : ((ActiveUnit)object_0).AssignedMissionOrPackage().FlightSize);
			if (flightSize == 0 || flightSize == 1)
			{
				return;
			}
			if (bool_0 && mission is Strike strike)
			{
				if (bool_2)
				{
					if (!((ActiveUnit)object_0).IsGroupMember())
					{
						return;
					}
				}
				else if (flight.DesiredAircraftQty == 1)
				{
					return;
				}
				if (strike.AttackMethod <= Mission._AttackMethod.EchelonAtActionPoint)
				{
					return;
				}
				if (bool_2 && !Information.IsNothing(((ActiveUnit)object_0).GetParentGroup()))
				{
					flightSize = ((ActiveUnit)object_0).GetParentGroup().Units.Count;
					if (flightSize == 5 || flightSize > 6)
					{
						scenario_0.AddMessage(flight.Callsign + "在空中但编队大小非标准。不会生成多方位飞行计划。", flight.Callsign + " cannot multi-axis", LoggedMessage.MessageType.UnitAI, 0, ((ScenarioObject)object_0).ObjectID, ((Module_Unit.Unit)object_0).GetUnitSide(), new Geopoint_Struct(((Module_Unit.Unit)object_0).GetLongitude(), ((Module_Unit.Unit)object_0).GetLatitude()));
						return;
					}
				}
				int num = waypoint_0.Count() - 1;
				Waypoint waypoint_ = null;
				Waypoint waypoint_9 = null;
				Waypoint waypoint_10 = null;
				Waypoint waypoint_11 = null;
				Waypoint waypoint = null;
				Waypoint waypoint_12 = null;
				Waypoint waypoint_13 = null;
				Waypoint waypoint_14 = null;
				for (int i = 0; i <= num; i++)
				{
					Waypoint waypoint12 = waypoint_0[i];
					if (Information.IsNothing(waypoint12) || waypoint12.FlightFormation != Waypoint.Formation.Split)
					{
						continue;
					}
					int num12 = i;
					int num23 = waypoint_0.Count() - 1;
					for (int j = num12; j <= num23; j++)
					{
						try
						{
							Waypoint waypoint_15 = waypoint_0[j];
							if (Information.IsNothing(waypoint_15))
							{
								continue;
							}
							if (waypoint12.FlightFormation == Waypoint.Formation.Split)
							{
								if (waypoint_15.Type != Waypoint.WaypointType.Target && waypoint_15.Type != Waypoint.WaypointType.WeaponTarget)
								{
									continue;
								}
								float num34 = waypoint_15.Leg_Distance_Straight + waypoint_15.Leg_Distance_Turn;
								float num45 = waypoint_15.Leg_Distance_Straight + waypoint_15.Leg_Distance_Turn;
								Mission._FlightSize flightSize2 = flightSize;
								if (flightSize2 == 2)
								{
									waypoint_15.Waypoint_LeadElementWingman = new Waypoint();
									Waypoint waypoint23 = waypoint_15;
									Doctrine doctrine_ = waypoint_15.Doctrine;
									waypoint23.Waypoint_LeadElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_15, bool_0: false, bool_1: false, ref doctrine_);
									waypoint_15.Waypoint_LeadElementWingman.SpeedFixed = Waypoint.FixedFree.Relative;
									if (strike.AttackMethod == Mission._AttackMethod.BananaSplit)
									{
										waypoint_15.Waypoint_LeadElementWingman.TimeFixed = Waypoint.FixedFree.Free;
									}
									else
									{
										waypoint_15.Waypoint_LeadElementWingman.TimeFixed = Waypoint.FixedFree.Relative;
									}
									if (strike.AttackMethod != Mission._AttackMethod.BananaSplit && !Information.IsNothing(waypoint_15.Waypoint_LeadElementWingman.Time_Zulu))
									{
										waypoint_15.Waypoint_LeadElementWingman.Time_Zulu = waypoint_15.Waypoint_LeadElementWingman.Time_Zulu.Value.AddSeconds(waypoint_15.Separation_Time);
									}
								}
								else if (flightSize2 == 3)
								{
									waypoint_15.Waypoint_LeadElementWingman = new Waypoint();
									waypoint_15.Waypoint_SecondElement = new Waypoint();
									Waypoint waypoint34 = waypoint_15;
									Doctrine doctrine_10 = waypoint_15.Doctrine;
									waypoint34.Waypoint_LeadElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_15, bool_0: false, bool_1: false, ref doctrine_10);
									Waypoint waypoint39 = waypoint_15;
									doctrine_10 = waypoint_15.Doctrine;
									waypoint39.Waypoint_SecondElement = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_15, bool_0: false, bool_1: false, ref doctrine_10);
									waypoint_15.Waypoint_LeadElementWingman.SpeedFixed = Waypoint.FixedFree.Relative;
									waypoint_15.Waypoint_SecondElement.SpeedFixed = Waypoint.FixedFree.Relative;
									if (strike.AttackMethod == Mission._AttackMethod.BananaSplit)
									{
										waypoint_15.Waypoint_LeadElementWingman.TimeFixed = Waypoint.FixedFree.Free;
										waypoint_15.Waypoint_SecondElement.TimeFixed = Waypoint.FixedFree.Free;
									}
									else
									{
										waypoint_15.Waypoint_LeadElementWingman.TimeFixed = Waypoint.FixedFree.Relative;
										waypoint_15.Waypoint_SecondElement.TimeFixed = Waypoint.FixedFree.Relative;
									}
									if (strike.AttackMethod != Mission._AttackMethod.BananaSplit)
									{
										if (!Information.IsNothing(waypoint_15.Waypoint_LeadElementWingman.Time_Zulu))
										{
											waypoint_15.Waypoint_LeadElementWingman.Time_Zulu = waypoint_15.Waypoint_LeadElementWingman.Time_Zulu.Value.AddSeconds(waypoint_15.Separation_Time);
										}
										if (!Information.IsNothing(waypoint_15.Waypoint_SecondElement.Time_Zulu))
										{
											waypoint_15.Waypoint_SecondElement.Time_Zulu = waypoint_15.Waypoint_SecondElement.Time_Zulu.Value.AddSeconds(waypoint_15.Separation_Time * 2f);
										}
									}
								}
								else if (flightSize2 == 4)
								{
									waypoint_15.Waypoint_LeadElementWingman = new Waypoint();
									waypoint_15.Waypoint_SecondElement = new Waypoint();
									waypoint_15.Waypoint_SecondElementWingman = new Waypoint();
									Waypoint waypoint40 = waypoint_15;
									Doctrine doctrine_11 = waypoint_15.Doctrine;
									waypoint40.Waypoint_LeadElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_15, bool_0: false, bool_1: false, ref doctrine_11);
									Waypoint waypoint41 = waypoint_15;
									doctrine_11 = waypoint_15.Doctrine;
									waypoint41.Waypoint_SecondElement = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_15, bool_0: false, bool_1: false, ref doctrine_11);
									Waypoint waypoint42 = waypoint_15;
									doctrine_11 = waypoint_15.Doctrine;
									waypoint42.Waypoint_SecondElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_15, bool_0: false, bool_1: false, ref doctrine_11);
									waypoint_15.Waypoint_LeadElementWingman.SpeedFixed = Waypoint.FixedFree.Relative;
									waypoint_15.Waypoint_SecondElement.SpeedFixed = Waypoint.FixedFree.Relative;
									waypoint_15.Waypoint_SecondElementWingman.SpeedFixed = Waypoint.FixedFree.Relative;
									if (strike.AttackMethod == Mission._AttackMethod.BananaSplit)
									{
										waypoint_15.Waypoint_LeadElementWingman.TimeFixed = Waypoint.FixedFree.Free;
										waypoint_15.Waypoint_SecondElement.TimeFixed = Waypoint.FixedFree.Free;
										waypoint_15.Waypoint_SecondElementWingman.TimeFixed = Waypoint.FixedFree.Free;
									}
									else
									{
										waypoint_15.Waypoint_LeadElementWingman.TimeFixed = Waypoint.FixedFree.Relative;
										waypoint_15.Waypoint_SecondElement.TimeFixed = Waypoint.FixedFree.Relative;
										waypoint_15.Waypoint_SecondElementWingman.TimeFixed = Waypoint.FixedFree.Relative;
									}
									if (strike.AttackMethod != Mission._AttackMethod.BananaSplit)
									{
										if (!Information.IsNothing(waypoint_15.Waypoint_LeadElementWingman.Time_Zulu))
										{
											waypoint_15.Waypoint_LeadElementWingman.Time_Zulu = waypoint_15.Waypoint_LeadElementWingman.Time_Zulu.Value.AddSeconds(waypoint_15.Separation_Time);
										}
										if (!Information.IsNothing(waypoint_15.Waypoint_SecondElement.Time_Zulu))
										{
											waypoint_15.Waypoint_SecondElement.Time_Zulu = waypoint_15.Waypoint_SecondElement.Time_Zulu.Value.AddSeconds(waypoint_15.Separation_Time * 2f);
										}
										if (!Information.IsNothing(waypoint_15.Waypoint_SecondElementWingman.Time_Zulu))
										{
											waypoint_15.Waypoint_SecondElementWingman.Time_Zulu = waypoint_15.Waypoint_SecondElementWingman.Time_Zulu.Value.AddSeconds(waypoint_15.Separation_Time * 3f);
										}
									}
								}
								else if (flightSize2 == 6)
								{
									waypoint_15.Waypoint_LeadElementWingman = new Waypoint();
									waypoint_15.Waypoint_SecondElement = new Waypoint();
									waypoint_15.Waypoint_SecondElementWingman = new Waypoint();
									waypoint_15.Waypoint_ThirdElement = new Waypoint();
									waypoint_15.Waypoint_ThirdElementWingman = new Waypoint();
									Waypoint waypoint43 = waypoint_15;
									Doctrine doctrine_12 = waypoint_15.Doctrine;
									waypoint43.Waypoint_LeadElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_15, bool_0: false, bool_1: false, ref doctrine_12);
									Waypoint waypoint2 = waypoint_15;
									doctrine_12 = waypoint_15.Doctrine;
									waypoint2.Waypoint_SecondElement = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_15, bool_0: false, bool_1: false, ref doctrine_12);
									Waypoint waypoint3 = waypoint_15;
									doctrine_12 = waypoint_15.Doctrine;
									waypoint3.Waypoint_SecondElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_15, bool_0: false, bool_1: false, ref doctrine_12);
									Waypoint waypoint4 = waypoint_15;
									doctrine_12 = waypoint_15.Doctrine;
									waypoint4.Waypoint_ThirdElement = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_15, bool_0: false, bool_1: false, ref doctrine_12);
									Waypoint waypoint5 = waypoint_15;
									doctrine_12 = waypoint_15.Doctrine;
									waypoint5.Waypoint_ThirdElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_15, bool_0: false, bool_1: false, ref doctrine_12);
									waypoint_15.Waypoint_LeadElementWingman.SpeedFixed = Waypoint.FixedFree.Relative;
									waypoint_15.Waypoint_SecondElement.SpeedFixed = Waypoint.FixedFree.Relative;
									waypoint_15.Waypoint_SecondElementWingman.SpeedFixed = Waypoint.FixedFree.Relative;
									waypoint_15.Waypoint_ThirdElement.SpeedFixed = Waypoint.FixedFree.Relative;
									waypoint_15.Waypoint_ThirdElementWingman.SpeedFixed = Waypoint.FixedFree.Relative;
									if (strike.AttackMethod == Mission._AttackMethod.BananaSplit)
									{
										waypoint_15.Waypoint_LeadElementWingman.TimeFixed = Waypoint.FixedFree.Free;
										waypoint_15.Waypoint_SecondElement.TimeFixed = Waypoint.FixedFree.Free;
										waypoint_15.Waypoint_SecondElementWingman.TimeFixed = Waypoint.FixedFree.Free;
										waypoint_15.Waypoint_ThirdElement.TimeFixed = Waypoint.FixedFree.Free;
										waypoint_15.Waypoint_ThirdElementWingman.TimeFixed = Waypoint.FixedFree.Free;
									}
									else
									{
										waypoint_15.Waypoint_LeadElementWingman.TimeFixed = Waypoint.FixedFree.Relative;
										waypoint_15.Waypoint_SecondElement.TimeFixed = Waypoint.FixedFree.Relative;
										waypoint_15.Waypoint_SecondElementWingman.TimeFixed = Waypoint.FixedFree.Relative;
										waypoint_15.Waypoint_ThirdElement.TimeFixed = Waypoint.FixedFree.Relative;
										waypoint_15.Waypoint_ThirdElementWingman.TimeFixed = Waypoint.FixedFree.Relative;
									}
									if (strike.AttackMethod != Mission._AttackMethod.BananaSplit)
									{
										if (!Information.IsNothing(waypoint_15.Waypoint_LeadElementWingman.Time_Zulu))
										{
											waypoint_15.Waypoint_LeadElementWingman.Time_Zulu = waypoint_15.Waypoint_LeadElementWingman.Time_Zulu.Value.AddSeconds(waypoint_15.Separation_Time);
										}
										if (!Information.IsNothing(waypoint_15.Waypoint_SecondElement.Time_Zulu))
										{
											waypoint_15.Waypoint_SecondElement.Time_Zulu = waypoint_15.Waypoint_SecondElement.Time_Zulu.Value.AddSeconds(waypoint_15.Separation_Time * 2f);
										}
										if (!Information.IsNothing(waypoint_15.Waypoint_SecondElementWingman.Time_Zulu))
										{
											waypoint_15.Waypoint_SecondElementWingman.Time_Zulu = waypoint_15.Waypoint_SecondElementWingman.Time_Zulu.Value.AddSeconds(waypoint_15.Separation_Time * 3f);
										}
										if (!Information.IsNothing(waypoint_15.Waypoint_ThirdElement.Time_Zulu))
										{
											waypoint_15.Waypoint_ThirdElement.Time_Zulu = waypoint_15.Waypoint_ThirdElement.Time_Zulu.Value.AddSeconds(waypoint_15.Separation_Time * 4f);
										}
										if (!Information.IsNothing(waypoint_15.Waypoint_ThirdElementWingman.Time_Zulu))
										{
											waypoint_15.Waypoint_ThirdElementWingman.Time_Zulu = waypoint_15.Waypoint_ThirdElementWingman.Time_Zulu.Value.AddSeconds(waypoint_15.Separation_Time * 5f);
										}
									}
								}
								float num49 = 0f;
								float num50 = 0f;
								float num51 = 0f;
								float num52 = 0f;
								float num2 = 0f;
								float num3 = 0f;
								float num4 = 0f;
								float num5 = 0f;
								float num6 = 0f;
								float num7 = 0f;
								for (int k = j - 1; k >= 0; k += -1)
								{
									Waypoint waypoint_16 = waypoint_0[k];
									if (Information.IsNothing(waypoint_16))
									{
										continue;
									}
									if (k >= j || waypoint_0[k].FlightFormation == Waypoint.Formation.Split)
									{
										if (k > 0 && waypoint_0[k].FlightFormation == Waypoint.Formation.Split)
										{
											waypoint_10 = waypoint_16;
											if (!(waypoint_16.Leg_Distance_Turn <= 0f) && waypoint_16.Leg_Speed_Turn > 0f)
											{
												num49 += waypoint_16.Leg_Time_Straight + waypoint_16.Leg_Time_Turn;
											}
											else if (waypoint_16.Leg_Distance_Straight > 0f && waypoint_16.Leg_Speed_Straight > 0f)
											{
												num49 += waypoint_16.Leg_Time_Straight;
											}
										}
										Mission._FlightSize flightSize3 = flightSize;
										if (flightSize3 == 2)
										{
											waypoint_16.Waypoint_LeadElementWingman = new Waypoint();
											Waypoint waypoint6 = waypoint_16;
											Doctrine doctrine_13 = waypoint_16.Doctrine;
											waypoint6.Waypoint_LeadElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_16, bool_0: false, bool_1: false, ref doctrine_13);
											waypoint_16.Waypoint_LeadElementWingman.SpeedFixed = Waypoint.FixedFree.Free;
										}
										else if (flightSize3 == 3)
										{
											waypoint_16.Waypoint_LeadElementWingman = new Waypoint();
											Waypoint waypoint7 = waypoint_16;
											Doctrine doctrine_14 = waypoint_16.Doctrine;
											waypoint7.Waypoint_LeadElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_16, bool_0: false, bool_1: false, ref doctrine_14);
											waypoint_16.Waypoint_LeadElementWingman.SpeedFixed = Waypoint.FixedFree.Free;
											waypoint_16.Waypoint_SecondElement = new Waypoint();
											Waypoint waypoint8 = waypoint_16;
											doctrine_14 = waypoint_16.Doctrine;
											waypoint8.Waypoint_SecondElement = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_16, bool_0: false, bool_1: false, ref doctrine_14);
											waypoint_16.Waypoint_SecondElement.SpeedFixed = Waypoint.FixedFree.Free;
										}
										else if (flightSize3 == 4)
										{
											waypoint_16.Waypoint_LeadElementWingman = new Waypoint();
											Waypoint waypoint9 = waypoint_16;
											Doctrine doctrine_15 = waypoint_16.Doctrine;
											waypoint9.Waypoint_LeadElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_16, bool_0: false, bool_1: false, ref doctrine_15);
											waypoint_16.Waypoint_LeadElementWingman.SpeedFixed = Waypoint.FixedFree.Free;
											waypoint_16.Waypoint_SecondElement = new Waypoint();
											Waypoint waypoint10 = waypoint_16;
											doctrine_15 = waypoint_16.Doctrine;
											waypoint10.Waypoint_SecondElement = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_16, bool_0: false, bool_1: false, ref doctrine_15);
											waypoint_16.Waypoint_SecondElement.SpeedFixed = Waypoint.FixedFree.Free;
											waypoint_16.Waypoint_SecondElementWingman = new Waypoint();
											Waypoint waypoint11 = waypoint_16;
											doctrine_15 = waypoint_16.Doctrine;
											waypoint11.Waypoint_SecondElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_16, bool_0: false, bool_1: false, ref doctrine_15);
											waypoint_16.Waypoint_SecondElementWingman.SpeedFixed = Waypoint.FixedFree.Free;
										}
										else if (flightSize3 == 6)
										{
											waypoint_16.Waypoint_LeadElementWingman = new Waypoint();
											Waypoint waypoint13 = waypoint_16;
											Doctrine doctrine_16 = waypoint_16.Doctrine;
											waypoint13.Waypoint_LeadElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_16, bool_0: false, bool_1: false, ref doctrine_16);
											waypoint_16.Waypoint_LeadElementWingman.SpeedFixed = Waypoint.FixedFree.Free;
											waypoint_16.Waypoint_SecondElement = new Waypoint();
											Waypoint waypoint14 = waypoint_16;
											doctrine_16 = waypoint_16.Doctrine;
											waypoint14.Waypoint_SecondElement = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_16, bool_0: false, bool_1: false, ref doctrine_16);
											waypoint_16.Waypoint_SecondElement.SpeedFixed = Waypoint.FixedFree.Free;
											waypoint_16.Waypoint_SecondElementWingman = new Waypoint();
											Waypoint waypoint15 = waypoint_16;
											doctrine_16 = waypoint_16.Doctrine;
											waypoint15.Waypoint_SecondElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_16, bool_0: false, bool_1: false, ref doctrine_16);
											waypoint_16.Waypoint_SecondElementWingman.SpeedFixed = Waypoint.FixedFree.Free;
											waypoint_16.Waypoint_ThirdElement = new Waypoint();
											Waypoint waypoint16 = waypoint_16;
											doctrine_16 = waypoint_16.Doctrine;
											waypoint16.Waypoint_ThirdElement = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_16, bool_0: false, bool_1: false, ref doctrine_16);
											waypoint_16.Waypoint_ThirdElement.SpeedFixed = Waypoint.FixedFree.Free;
											waypoint_16.Waypoint_ThirdElementWingman = new Waypoint();
											Waypoint waypoint17 = waypoint_16;
											doctrine_16 = waypoint_16.Doctrine;
											waypoint17.Waypoint_ThirdElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_16, bool_0: false, bool_1: false, ref doctrine_16);
											waypoint_16.Waypoint_ThirdElementWingman.SpeedFixed = Waypoint.FixedFree.Free;
										}
										if (waypoint_16.Type == Waypoint.WaypointType.InitialPoint || waypoint_16.Type == Waypoint.WaypointType.WeaponLaunch)
										{
											num34 += waypoint_16.Leg_Distance_Straight + waypoint_16.Leg_Distance_Turn;
											Mission._FlightSize flightSize4 = flightSize;
											if (flightSize4 == 2)
											{
												waypoint_16.Waypoint_LeadElementWingman.SpeedFixed = Waypoint.FixedFree.Relative;
											}
											else if (flightSize4 == 3)
											{
												waypoint_16.Waypoint_LeadElementWingman.SpeedFixed = Waypoint.FixedFree.Relative;
												waypoint_16.Waypoint_SecondElement.SpeedFixed = Waypoint.FixedFree.Relative;
											}
											else if (flightSize4 == 4)
											{
												waypoint_16.Waypoint_LeadElementWingman.SpeedFixed = Waypoint.FixedFree.Relative;
												waypoint_16.Waypoint_SecondElement.SpeedFixed = Waypoint.FixedFree.Relative;
												waypoint_16.Waypoint_SecondElementWingman.SpeedFixed = Waypoint.FixedFree.Relative;
											}
											else if (flightSize4 == 6)
											{
												waypoint_16.Waypoint_LeadElementWingman.SpeedFixed = Waypoint.FixedFree.Relative;
												waypoint_16.Waypoint_SecondElement.SpeedFixed = Waypoint.FixedFree.Relative;
												waypoint_16.Waypoint_SecondElementWingman.SpeedFixed = Waypoint.FixedFree.Relative;
												waypoint_16.Waypoint_ThirdElement.SpeedFixed = Waypoint.FixedFree.Relative;
												waypoint_16.Waypoint_ThirdElementWingman.SpeedFixed = Waypoint.FixedFree.Relative;
											}
										}
										if (waypoint_16.Type == Waypoint.WaypointType.InitialPoint || waypoint_16.Type == Waypoint.WaypointType.WeaponLaunch)
										{
											waypoint_11 = waypoint_16;
										}
										continue;
									}
									waypoint_ = waypoint_16;
									if (k > 0)
									{
										waypoint_9 = waypoint_0[k - 1];
									}
									break;
								}
								if (!(waypoint_15.Leg_Distance_Turn <= 0f) && waypoint_15.Leg_Speed_Turn > 0f)
								{
									num49 += waypoint_15.Leg_Time_Straight + waypoint_15.Leg_Time_Turn;
								}
								else if (waypoint_15.Leg_Distance_Straight > 0f && waypoint_15.Leg_Speed_Straight > 0f)
								{
									num49 += waypoint_15.Leg_Time_Straight;
								}
								if (waypoint_15.Type == Waypoint.WaypointType.WeaponTarget && waypoint_15.FlightplanPointsList.Count > 0 && waypoint_15.ActualSpeed > 0f)
								{
									float num8 = Math2.VerifyClass(waypoint_15.Latitude, waypoint_15.Longitude, waypoint_15.FlightplanPointsList[waypoint_15.FlightplanPointsList.Count - 1].EndLatitude, waypoint_15.FlightplanPointsList[waypoint_15.FlightplanPointsList.Count - 1].EndLongitude);
									if (num8 > 0f)
									{
										num45 += num8;
										num34 += num8;
									}
								}
								if (waypoint_15.Type == Waypoint.WaypointType.Target || waypoint_15.Type == Waypoint.WaypointType.WeaponTarget)
								{
									waypoint = waypoint_15;
								}
								int num9 = j + 1;
								int num10 = waypoint_0.Count() - 1;
								for (int l = num9; l <= num10; l++)
								{
									Waypoint waypoint_2 = waypoint_0[l];
									if (Information.IsNothing(waypoint_2))
									{
										continue;
									}
									if (!(waypoint_2.Leg_Distance_Turn <= 0f) && waypoint_2.Leg_Speed_Turn > 0f)
									{
										num3 += waypoint_2.Leg_Time_Straight + waypoint_2.Leg_Time_Turn;
									}
									else if (waypoint_2.Leg_Distance_Straight > 0f && waypoint_2.Leg_Speed_Straight > 0f)
									{
										num3 += waypoint_2.Leg_Time_Straight;
									}
									Mission._FlightSize flightSize5 = flightSize;
									if (flightSize5 == 2)
									{
										waypoint_2.Waypoint_LeadElementWingman = new Waypoint();
										Waypoint waypoint18 = waypoint_2;
										Doctrine doctrine_17 = waypoint_2.Doctrine;
										waypoint18.Waypoint_LeadElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_2, bool_0: false, bool_1: false, ref doctrine_17);
										waypoint_2.Waypoint_LeadElementWingman.SpeedFixed = Waypoint.FixedFree.Free;
									}
									else if (flightSize5 == 3)
									{
										waypoint_2.Waypoint_LeadElementWingman = new Waypoint();
										Waypoint waypoint19 = waypoint_2;
										Doctrine doctrine_2 = waypoint_2.Doctrine;
										waypoint19.Waypoint_LeadElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_2, bool_0: false, bool_1: false, ref doctrine_2);
										waypoint_2.Waypoint_LeadElementWingman.SpeedFixed = Waypoint.FixedFree.Free;
										waypoint_2.Waypoint_SecondElement = new Waypoint();
										Waypoint waypoint20 = waypoint_2;
										doctrine_2 = waypoint_2.Doctrine;
										waypoint20.Waypoint_SecondElement = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_2, bool_0: false, bool_1: false, ref doctrine_2);
										waypoint_2.Waypoint_SecondElement.SpeedFixed = Waypoint.FixedFree.Free;
									}
									else if (flightSize5 == 4)
									{
										waypoint_2.Waypoint_LeadElementWingman = new Waypoint();
										Waypoint waypoint21 = waypoint_2;
										Doctrine doctrine_3 = waypoint_2.Doctrine;
										waypoint21.Waypoint_LeadElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_2, bool_0: false, bool_1: false, ref doctrine_3);
										waypoint_2.Waypoint_LeadElementWingman.SpeedFixed = Waypoint.FixedFree.Free;
										waypoint_2.Waypoint_SecondElement = new Waypoint();
										Waypoint waypoint22 = waypoint_2;
										doctrine_3 = waypoint_2.Doctrine;
										waypoint22.Waypoint_SecondElement = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_2, bool_0: false, bool_1: false, ref doctrine_3);
										waypoint_2.Waypoint_SecondElement.SpeedFixed = Waypoint.FixedFree.Free;
										waypoint_2.Waypoint_SecondElementWingman = new Waypoint();
										Waypoint waypoint24 = waypoint_2;
										doctrine_3 = waypoint_2.Doctrine;
										waypoint24.Waypoint_SecondElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_2, bool_0: false, bool_1: false, ref doctrine_3);
										waypoint_2.Waypoint_SecondElementWingman.SpeedFixed = Waypoint.FixedFree.Free;
									}
									else if (flightSize5 == 6)
									{
										waypoint_2.Waypoint_LeadElementWingman = new Waypoint();
										Waypoint waypoint25 = waypoint_2;
										Doctrine doctrine_4 = waypoint_2.Doctrine;
										waypoint25.Waypoint_LeadElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_2, bool_0: false, bool_1: false, ref doctrine_4);
										waypoint_2.Waypoint_LeadElementWingman.SpeedFixed = Waypoint.FixedFree.Free;
										waypoint_2.Waypoint_SecondElement = new Waypoint();
										Waypoint waypoint26 = waypoint_2;
										doctrine_4 = waypoint_2.Doctrine;
										waypoint26.Waypoint_SecondElement = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_2, bool_0: false, bool_1: false, ref doctrine_4);
										waypoint_2.Waypoint_SecondElement.SpeedFixed = Waypoint.FixedFree.Free;
										waypoint_2.Waypoint_SecondElementWingman = new Waypoint();
										Waypoint waypoint27 = waypoint_2;
										doctrine_4 = waypoint_2.Doctrine;
										waypoint27.Waypoint_SecondElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_2, bool_0: false, bool_1: false, ref doctrine_4);
										waypoint_2.Waypoint_SecondElementWingman.SpeedFixed = Waypoint.FixedFree.Free;
										waypoint_2.Waypoint_ThirdElement = new Waypoint();
										Waypoint waypoint28 = waypoint_2;
										doctrine_4 = waypoint_2.Doctrine;
										waypoint28.Waypoint_ThirdElement = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_2, bool_0: false, bool_1: false, ref doctrine_4);
										waypoint_2.Waypoint_ThirdElement.SpeedFixed = Waypoint.FixedFree.Free;
										waypoint_2.Waypoint_ThirdElementWingman = new Waypoint();
										Waypoint waypoint29 = waypoint_2;
										doctrine_4 = waypoint_2.Doctrine;
										waypoint29.Waypoint_ThirdElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_2, bool_0: false, bool_1: false, ref doctrine_4);
										waypoint_2.Waypoint_ThirdElementWingman.SpeedFixed = Waypoint.FixedFree.Free;
									}
									if (waypoint_2.FlightFormation == Waypoint.Formation.Split)
									{
										waypoint_12 = waypoint_2;
										continue;
									}
									waypoint_13 = waypoint_2;
									if (waypoint_0.Count() - 1 >= l + 1)
									{
										waypoint_14 = waypoint_0[l + 1];
									}
									i = l - 1;
									j = l - 1;
									break;
								}
								if (!Information.IsNothing(waypoint_10) && !Information.IsNothing(waypoint_13) && (uint)(strike.AttackMethod - 11) <= 2u)
								{
									if (!Information.IsNothing(waypoint_10.Waypoint_LeadElementWingman))
									{
										waypoint_10.Waypoint_LeadElementWingman.SpacingManeuver_Time = waypoint_15.Separation_Time;
										waypoint_13.Waypoint_LeadElementWingman.SpacingManeuver_Time = (float)((int)flightSize - 2) * waypoint_15.Separation_Time;
									}
									if (!Information.IsNothing(waypoint_10.Waypoint_SecondElement))
									{
										waypoint_10.Waypoint_SecondElement.SpacingManeuver_Time = (float)((int)flightSize - ((int)flightSize - 2)) * waypoint_15.Separation_Time;
										waypoint_13.Waypoint_SecondElement.SpacingManeuver_Time = (float)((int)flightSize - 3) * waypoint_15.Separation_Time;
									}
									if (!Information.IsNothing(waypoint_10.Waypoint_SecondElementWingman))
									{
										waypoint_10.Waypoint_SecondElementWingman.SpacingManeuver_Time = (float)((int)flightSize - ((int)flightSize - 3)) * waypoint_15.Separation_Time;
										waypoint_13.Waypoint_SecondElementWingman.SpacingManeuver_Time = (float)((int)flightSize - 4) * waypoint_15.Separation_Time;
									}
									if (!Information.IsNothing(waypoint_10.Waypoint_ThirdElement))
									{
										waypoint_10.Waypoint_ThirdElement.SpacingManeuver_Time = (float)((int)flightSize - ((int)flightSize - 4)) * waypoint_15.Separation_Time;
										waypoint_13.Waypoint_ThirdElement.SpacingManeuver_Time = (float)((int)flightSize - 5) * waypoint_15.Separation_Time;
									}
									if (!Information.IsNothing(waypoint_10.Waypoint_ThirdElementWingman))
									{
										waypoint_10.Waypoint_ThirdElementWingman.SpacingManeuver_Time = (float)((int)flightSize - ((int)flightSize - 5)) * waypoint_15.Separation_Time;
										waypoint_13.Waypoint_ThirdElementWingman.SpacingManeuver_Time = 0f;
									}
								}
								num49 += waypoint_15.Separation_Time;
								num50 = num49 + waypoint_15.Separation_Time;
								num51 = num50 + waypoint_15.Separation_Time;
								num52 = num51 + waypoint_15.Separation_Time;
								num2 = num52 + waypoint_15.Separation_Time;
								num3 -= waypoint_15.Separation_Time;
								num4 = num3 - waypoint_15.Separation_Time;
								num5 = num4 - waypoint_15.Separation_Time;
								num6 = num5 - waypoint_15.Separation_Time;
								num7 = num6 - waypoint_15.Separation_Time;
								Waypoint.FlightPlanSegment flightPlanSegment = waypoint_.FlightplanPointsList[waypoint_.FlightplanPointsList.Count - 1];
								float float_66 = Math2.PublishClass(flightPlanSegment.StartLatitude, flightPlanSegment.StartLongitude, flightPlanSegment.EndLatitude, flightPlanSegment.EndLongitude);
								bool flag = strike.AttackMethod == Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec || strike.AttackMethod == Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec || strike.AttackMethod == Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec;
								Mission._FlightSize flightSize6 = flightSize;
								if (flightSize6 == 2)
								{
									int num11;
									int num13;
									int num14;
									if ((!flag && turnDirection_0 == Misc.TurnDirection.TurnRight) || (flag && turnDirection_0 == Misc.TurnDirection.TurnLeft))
									{
										num11 = 1;
										num13 = 120;
										num14 = 1;
									}
									else
									{
										num11 = -1;
										num13 = -120;
										num14 = -1;
									}
									int? nullable_ = null;
									switch (strike.AttackMethod)
									{
									case Mission._AttackMethod.MultiAxisSimultaneousToT:
									{
										ref Waypoint waypoint_LeadElementWingman3 = ref waypoint_10.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman4 = ref waypoint_11.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman5 = ref waypoint_15.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman6 = ref waypoint_12.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman7 = ref waypoint_13.Waypoint_LeadElementWingman;
										float float_26 = num45;
										float float_37 = num49;
										float float_40 = num3;
										int int_67 = num11;
										int int_78 = num13;
										int int_89 = num14;
										string string_23 = ", a/c #2";
										GetTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_LeadElementWingman3, ref waypoint_11, ref waypoint_LeadElementWingman4, ref waypoint_15, ref waypoint_LeadElementWingman5, ref waypoint_12, ref waypoint_LeadElementWingman6, ref waypoint_13, ref waypoint_LeadElementWingman7, ref waypoint_14, turnDirection_0, float_66, float_3, float_3, float_26, float_37, float_40, int_67, int_78, int_89, float_0, bool_0: true, bool_1: true, bool_1, ref string_23, Mission.Flight.FlightElement.LeadElementWingman);
										break;
									}
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_40Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec:
									{
										int num15 = ((!flag && !bool_1) ? 1 : 0);
										ref Waypoint waypoint_LeadElementWingman56 = ref waypoint_10.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman58 = ref waypoint_11.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman59 = ref waypoint_15.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman60 = ref waypoint_12.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman2 = ref waypoint_13.Waypoint_LeadElementWingman;
										float float_121 = num45;
										float float_4 = num49;
										float float_15 = num3;
										int int_34 = num11;
										int int_45 = num13;
										int int_56 = num14;
										bool bool_12 = (byte)num15 != 0;
										string string_12 = ", a/c #2";
										ViewTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_LeadElementWingman56, ref waypoint_11, ref waypoint_LeadElementWingman58, ref waypoint_15, ref waypoint_LeadElementWingman59, ref waypoint_12, ref waypoint_LeadElementWingman60, ref waypoint_13, ref waypoint_LeadElementWingman2, ref waypoint_14, turnDirection_0, float_66, float_3, float_3, float_121, float_4, float_15, int_34, int_45, int_56, ref nullable_, float_0, bool_12, bool_1: false, bool_1, ref string_12);
										break;
									}
									case Mission._AttackMethod.BananaSplit:
									{
										ref Waypoint waypoint_LeadElementWingman = ref waypoint_10.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman12 = ref waypoint_11.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman23 = ref waypoint_15.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman34 = ref waypoint_12.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman45 = ref waypoint_13.Waypoint_LeadElementWingman;
										float float_77 = num34;
										float float_88 = num45;
										float float_99 = num49;
										float float_110 = num3;
										int int_ = num11;
										int int_12 = num13;
										int int_23 = num14;
										string string_ = ", a/c #2";
										LoginTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_LeadElementWingman, ref waypoint_11, ref waypoint_LeadElementWingman12, ref waypoint_15, ref waypoint_LeadElementWingman23, ref waypoint_12, ref waypoint_LeadElementWingman34, ref waypoint_13, ref waypoint_LeadElementWingman45, ref waypoint_14, turnDirection_0, float_66, float_3, float_77, float_88, float_99, float_110, int_, int_12, int_23, float_0, bool_0: false, bool_1: false, bool_1, ref string_, Mission.Flight.FlightElement.LeadElementWingman, ref bool_3);
										break;
									}
									}
									break;
								}
								if (flightSize6 == 3)
								{
									int num16;
									int num17;
									int num18;
									if ((!flag && turnDirection_0 == Misc.TurnDirection.TurnRight) || (flag && turnDirection_0 == Misc.TurnDirection.TurnLeft))
									{
										num16 = 1;
										num17 = 120;
										num18 = 1;
									}
									else
									{
										num16 = -1;
										num17 = -120;
										num18 = -1;
									}
									int? nullable_2 = null;
									switch (strike.AttackMethod)
									{
									case Mission._AttackMethod.MultiAxisSimultaneousToT:
									{
										ref Waypoint waypoint_LeadElementWingman19 = ref waypoint_10.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman20 = ref waypoint_11.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman21 = ref waypoint_15.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman22 = ref waypoint_12.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman24 = ref waypoint_13.Waypoint_LeadElementWingman;
										float float_48 = num45;
										float float_49 = num49;
										float float_50 = num3;
										int int_8 = num16;
										int int_9 = num17;
										int int_10 = num18;
										string string_30 = ", a/c #2";
										GetTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_LeadElementWingman19, ref waypoint_11, ref waypoint_LeadElementWingman20, ref waypoint_15, ref waypoint_LeadElementWingman21, ref waypoint_12, ref waypoint_LeadElementWingman22, ref waypoint_13, ref waypoint_LeadElementWingman24, ref waypoint_14, turnDirection_0, float_66, float_3, float_3, float_48, float_49, float_50, int_8, int_9, int_10, float_0, bool_0: true, bool_1: true, bool_1, ref string_30, Mission.Flight.FlightElement.LeadElementWingman);
										break;
									}
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_40Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec:
									{
										int num19 = ((!flag && !bool_1) ? 1 : 0);
										ref Waypoint waypoint_LeadElementWingman14 = ref waypoint_10.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman15 = ref waypoint_11.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman16 = ref waypoint_15.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman17 = ref waypoint_12.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman18 = ref waypoint_13.Waypoint_LeadElementWingman;
										float float_45 = num45;
										float float_46 = num49;
										float float_47 = num3;
										int int_5 = num16;
										int int_6 = num17;
										int int_7 = num18;
										bool bool_13 = (byte)num19 != 0;
										string string_29 = ", a/c #2";
										ViewTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_LeadElementWingman14, ref waypoint_11, ref waypoint_LeadElementWingman15, ref waypoint_15, ref waypoint_LeadElementWingman16, ref waypoint_12, ref waypoint_LeadElementWingman17, ref waypoint_13, ref waypoint_LeadElementWingman18, ref waypoint_14, turnDirection_0, float_66, float_3, float_3, float_45, float_46, float_47, int_5, int_6, int_7, ref nullable_2, float_0, bool_13, bool_1: false, bool_1, ref string_29);
										break;
									}
									case Mission._AttackMethod.BananaSplit:
									{
										ref Waypoint waypoint_LeadElementWingman8 = ref waypoint_10.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman9 = ref waypoint_11.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman10 = ref waypoint_15.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman11 = ref waypoint_12.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman13 = ref waypoint_13.Waypoint_LeadElementWingman;
										float float_41 = num34;
										float float_42 = num45;
										float float_43 = num49;
										float float_44 = num3;
										int int_2 = num16;
										int int_3 = num17;
										int int_4 = num18;
										string string_28 = ", a/c #2";
										LoginTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_LeadElementWingman8, ref waypoint_11, ref waypoint_LeadElementWingman9, ref waypoint_15, ref waypoint_LeadElementWingman10, ref waypoint_12, ref waypoint_LeadElementWingman11, ref waypoint_13, ref waypoint_LeadElementWingman13, ref waypoint_14, turnDirection_0, float_66, float_3, float_41, float_42, float_43, float_44, int_2, int_3, int_4, float_0, bool_0: false, bool_1: false, bool_1, ref string_28, Mission.Flight.FlightElement.LeadElementWingman, ref bool_3);
										break;
									}
									}
									Misc.TurnDirection turnDirection_ = (((!flag && turnDirection_0 == Misc.TurnDirection.TurnRight) || (flag && turnDirection_0 == Misc.TurnDirection.TurnLeft)) ? Misc.TurnDirection.TurnLeft : Misc.TurnDirection.TurnRight);
									if ((!flag && turnDirection_0 == Misc.TurnDirection.TurnRight) || (flag && turnDirection_0 == Misc.TurnDirection.TurnLeft))
									{
										num16 = -1;
										num17 = -120;
										num18 = -1;
									}
									else
									{
										num16 = 1;
										num17 = 120;
										num18 = 1;
									}
									nullable_2 = null;
									float float_51 = Math.Min((float)((double)float_3 + (double)waypoint_.ActualSpeed * ((double)waypoint_15.Separation_Time * 0.9 / 3600.0)), float_2);
									switch (strike.AttackMethod)
									{
									case Mission._AttackMethod.MultiAxisSimultaneousToT:
									{
										ref Waypoint waypoint_SecondElement3 = ref waypoint_10.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement4 = ref waypoint_11.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement5 = ref waypoint_15.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement6 = ref waypoint_12.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement7 = ref waypoint_13.Waypoint_SecondElement;
										float float_59 = num45;
										float float_60 = num50;
										float float_61 = num4;
										int int_18 = num16;
										int int_19 = num17;
										int int_20 = num18;
										string string_33 = ", a/c #3";
										GetTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_SecondElement3, ref waypoint_11, ref waypoint_SecondElement4, ref waypoint_15, ref waypoint_SecondElement5, ref waypoint_12, ref waypoint_SecondElement6, ref waypoint_13, ref waypoint_SecondElement7, ref waypoint_14, turnDirection_, float_66, float_3, float_51, float_59, float_60, float_61, int_18, int_19, int_20, float_0, bool_0: true, bool_1: true, bool_1, ref string_33, Mission.Flight.FlightElement.SecondElement);
										break;
									}
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_40Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec:
									{
										ref Waypoint waypoint_SecondElement42 = ref waypoint_10.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement43 = ref waypoint_11.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement44 = ref waypoint_15.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement45 = ref waypoint_12.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement2 = ref waypoint_13.Waypoint_SecondElement;
										float float_56 = num45;
										float float_57 = num50;
										float float_58 = num4;
										int int_15 = num16;
										int int_16 = num17;
										int int_17 = num18;
										string string_32 = ", a/c #3";
										ViewTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_SecondElement42, ref waypoint_11, ref waypoint_SecondElement43, ref waypoint_15, ref waypoint_SecondElement44, ref waypoint_12, ref waypoint_SecondElement45, ref waypoint_13, ref waypoint_SecondElement2, ref waypoint_14, turnDirection_, float_66, float_3, float_51, float_56, float_57, float_58, int_15, int_16, int_17, ref nullable_2, float_0, bool_0: true, bool_1: false, bool_1, ref string_32);
										break;
									}
									case Mission._AttackMethod.BananaSplit:
									{
										ref Waypoint waypoint_SecondElement = ref waypoint_10.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement12 = ref waypoint_11.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement23 = ref waypoint_15.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement34 = ref waypoint_12.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement41 = ref waypoint_13.Waypoint_SecondElement;
										float float_52 = num34;
										float float_53 = num45;
										float float_54 = num49;
										float float_55 = num3;
										int int_11 = num16;
										int int_13 = num17;
										int int_14 = num18;
										string string_31 = ", a/c #3";
										LoginTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_SecondElement, ref waypoint_11, ref waypoint_SecondElement12, ref waypoint_15, ref waypoint_SecondElement23, ref waypoint_12, ref waypoint_SecondElement34, ref waypoint_13, ref waypoint_SecondElement41, ref waypoint_14, turnDirection_0, float_66, float_3, float_52, float_53, float_54, float_55, int_11, int_13, int_14, float_0, bool_0: false, bool_1: false, bool_1, ref string_31, Mission.Flight.FlightElement.SecondElement, ref bool_3);
										break;
									}
									case Mission._AttackMethod.SingleAxisStackedToT_20Sec:
									case Mission._AttackMethod.SingleAxisStackedToT_30Sec:
									case Mission._AttackMethod.SingleAxisStackedToT_40Sec:
										break;
									}
								}
								else if (flightSize6 == 4)
								{
									int num20;
									int num21;
									int num22;
									if ((!flag && turnDirection_0 == Misc.TurnDirection.TurnRight) || (flag && turnDirection_0 == Misc.TurnDirection.TurnLeft))
									{
										num20 = 1;
										num21 = 120;
										num22 = 1;
									}
									else
									{
										num20 = -1;
										num21 = -120;
										num22 = -1;
									}
									int? nullable_3 = null;
									switch (strike.AttackMethod)
									{
									case Mission._AttackMethod.MultiAxisSimultaneousToT:
									{
										ref Waypoint waypoint_LeadElementWingman36 = ref waypoint_10.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman37 = ref waypoint_11.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman38 = ref waypoint_15.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman39 = ref waypoint_12.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman40 = ref waypoint_13.Waypoint_LeadElementWingman;
										float float_70 = num45;
										float float_71 = num49;
										float float_72 = num3;
										int int_28 = num20;
										int int_29 = num21;
										int int_30 = num22;
										string string_4 = ", a/c #2";
										GetTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_LeadElementWingman36, ref waypoint_11, ref waypoint_LeadElementWingman37, ref waypoint_15, ref waypoint_LeadElementWingman38, ref waypoint_12, ref waypoint_LeadElementWingman39, ref waypoint_13, ref waypoint_LeadElementWingman40, ref waypoint_14, turnDirection_0, float_66, float_3, float_3, float_70, float_71, float_72, int_28, int_29, int_30, float_0, bool_0: true, bool_1: true, bool_1, ref string_4, Mission.Flight.FlightElement.LeadElementWingman);
										break;
									}
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_40Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec:
									{
										int num24 = ((!flag && !bool_1) ? 1 : 0);
										ref Waypoint waypoint_LeadElementWingman30 = ref waypoint_10.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman31 = ref waypoint_11.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman32 = ref waypoint_15.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman33 = ref waypoint_12.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman35 = ref waypoint_13.Waypoint_LeadElementWingman;
										float float_67 = num45;
										float float_68 = num49;
										float float_69 = num3;
										int int_25 = num20;
										int int_26 = num21;
										int int_27 = num22;
										bool bool_14 = (byte)num24 != 0;
										string string_3 = ", a/c #2";
										ViewTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_LeadElementWingman30, ref waypoint_11, ref waypoint_LeadElementWingman31, ref waypoint_15, ref waypoint_LeadElementWingman32, ref waypoint_12, ref waypoint_LeadElementWingman33, ref waypoint_13, ref waypoint_LeadElementWingman35, ref waypoint_14, turnDirection_0, float_66, float_3, float_3, float_67, float_68, float_69, int_25, int_26, int_27, ref nullable_3, float_0, bool_14, bool_1: false, bool_1, ref string_3);
										break;
									}
									case Mission._AttackMethod.BananaSplit:
									{
										ref Waypoint waypoint_LeadElementWingman25 = ref waypoint_10.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman26 = ref waypoint_11.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman27 = ref waypoint_15.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman28 = ref waypoint_12.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman29 = ref waypoint_13.Waypoint_LeadElementWingman;
										float float_62 = num34;
										float float_63 = num45;
										float float_64 = num49;
										float float_65 = num3;
										int int_21 = num20;
										int int_22 = num21;
										int int_24 = num22;
										string string_2 = ", a/c #2";
										LoginTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_LeadElementWingman25, ref waypoint_11, ref waypoint_LeadElementWingman26, ref waypoint_15, ref waypoint_LeadElementWingman27, ref waypoint_12, ref waypoint_LeadElementWingman28, ref waypoint_13, ref waypoint_LeadElementWingman29, ref waypoint_14, turnDirection_0, float_66, float_3, float_62, float_63, float_64, float_65, int_21, int_22, int_24, float_0, bool_0: false, bool_1: false, bool_1, ref string_2, Mission.Flight.FlightElement.LeadElementWingman, ref bool_3);
										break;
									}
									}
									Misc.TurnDirection turnDirection = ((strike.AttackMethod == Mission._AttackMethod.MultiAxisSimultaneousToT || strike.AttackMethod == Mission._AttackMethod.BananaSplit) ? turnDirection_0 : (((!flag && turnDirection_0 == Misc.TurnDirection.TurnRight) || (flag && turnDirection_0 == Misc.TurnDirection.TurnLeft)) ? Misc.TurnDirection.TurnLeft : Misc.TurnDirection.TurnRight));
									if ((!flag && turnDirection_0 == Misc.TurnDirection.TurnRight) || (flag && turnDirection_0 == Misc.TurnDirection.TurnLeft))
									{
										num20 = -1;
										num21 = -120;
										num22 = -1;
									}
									else
									{
										num20 = 1;
										num21 = 120;
										num22 = 1;
									}
									nullable_3 = null;
									float num25 = Math.Min((float)((double)float_3 + (double)waypoint_.ActualSpeed * ((double)waypoint_15.Separation_Time * 0.9 / 3600.0)), (float)((double)float_2 * 0.9));
									switch (strike.AttackMethod)
									{
									case Mission._AttackMethod.MultiAxisSimultaneousToT:
									{
										ref Waypoint waypoint_SecondElement19 = ref waypoint_10.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement20 = ref waypoint_11.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement21 = ref waypoint_15.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement22 = ref waypoint_12.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement24 = ref waypoint_13.Waypoint_SecondElement;
										Misc.TurnDirection turnDirection_13 = turnDirection;
										float float_82 = num25;
										float float_83 = num45;
										float float_84 = num50;
										float float_85 = num4;
										int int_38 = num20;
										int int_39 = num21;
										int int_40 = num22;
										string string_7 = ", a/c #3";
										GetTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_SecondElement19, ref waypoint_11, ref waypoint_SecondElement20, ref waypoint_15, ref waypoint_SecondElement21, ref waypoint_12, ref waypoint_SecondElement22, ref waypoint_13, ref waypoint_SecondElement24, ref waypoint_14, turnDirection_13, float_66, float_3, float_82, float_83, float_84, float_85, int_38, int_39, int_40, float_0, bool_0: true, bool_1: true, bool_1, ref string_7, Mission.Flight.FlightElement.SecondElement);
										break;
									}
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_40Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec:
									{
										ref Waypoint waypoint_SecondElement14 = ref waypoint_10.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement15 = ref waypoint_11.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement16 = ref waypoint_15.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement17 = ref waypoint_12.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement18 = ref waypoint_13.Waypoint_SecondElement;
										Misc.TurnDirection turnDirection_12 = turnDirection;
										float float_78 = num25;
										float float_79 = num45;
										float float_80 = num50;
										float float_81 = num4;
										int int_35 = num20;
										int int_36 = num21;
										int int_37 = num22;
										string string_6 = ", a/c #3";
										ViewTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_SecondElement14, ref waypoint_11, ref waypoint_SecondElement15, ref waypoint_15, ref waypoint_SecondElement16, ref waypoint_12, ref waypoint_SecondElement17, ref waypoint_13, ref waypoint_SecondElement18, ref waypoint_14, turnDirection_12, float_66, float_3, float_78, float_79, float_80, float_81, int_35, int_36, int_37, ref nullable_3, float_0, bool_0: true, bool_1: false, bool_1, ref string_6);
										break;
									}
									case Mission._AttackMethod.BananaSplit:
									{
										ref Waypoint waypoint_SecondElement8 = ref waypoint_10.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement9 = ref waypoint_11.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement10 = ref waypoint_15.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement11 = ref waypoint_12.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement13 = ref waypoint_13.Waypoint_SecondElement;
										Misc.TurnDirection turnDirection_11 = turnDirection;
										float float_73 = num34;
										float float_74 = num45;
										float float_75 = num49;
										float float_76 = num3;
										int int_31 = num20;
										int int_32 = num21;
										int int_33 = num22;
										string string_5 = ", a/c #3";
										LoginTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_SecondElement8, ref waypoint_11, ref waypoint_SecondElement9, ref waypoint_15, ref waypoint_SecondElement10, ref waypoint_12, ref waypoint_SecondElement11, ref waypoint_13, ref waypoint_SecondElement13, ref waypoint_14, turnDirection_11, float_66, float_3, float_73, float_74, float_75, float_76, int_31, int_32, int_33, float_0, bool_0: false, bool_1: false, bool_1, ref string_5, Mission.Flight.FlightElement.SecondElement, ref bool_3);
										break;
									}
									}
									num25 = Math.Min((float)((double)float_3 + (double)waypoint_.ActualSpeed * ((double)waypoint_15.Separation_Time * 1.4 / 3600.0)), (float)((double)float_2 * 1.4));
									if (flag)
									{
										num20 = -num20;
										num21 = -num21;
										num22 = -num22;
										nullable_3 = (-nullable_3) ?? nullable_3;
										turnDirection = ((turnDirection != Misc.TurnDirection.TurnLeft) ? Misc.TurnDirection.TurnLeft : Misc.TurnDirection.TurnRight);
									}
									switch (strike.AttackMethod)
									{
									case Mission._AttackMethod.MultiAxisSimultaneousToT:
									{
										ref Waypoint waypoint_SecondElementWingman3 = ref waypoint_10.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman4 = ref waypoint_11.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman5 = ref waypoint_15.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman6 = ref waypoint_12.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman7 = ref waypoint_13.Waypoint_SecondElementWingman;
										Misc.TurnDirection turnDirection_16 = turnDirection;
										float float_95 = num25;
										float float_96 = num45;
										float float_97 = num51;
										float float_98 = num5;
										int int_48 = num20;
										int int_49 = num21;
										int int_50 = num22;
										string string_10 = ", a/c #4";
										GetTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_SecondElementWingman3, ref waypoint_11, ref waypoint_SecondElementWingman4, ref waypoint_15, ref waypoint_SecondElementWingman5, ref waypoint_12, ref waypoint_SecondElementWingman6, ref waypoint_13, ref waypoint_SecondElementWingman7, ref waypoint_14, turnDirection_16, float_66, float_3, float_95, float_96, float_97, float_98, int_48, int_49, int_50, float_0, bool_0: true, bool_1: true, bool_1, ref string_10, Mission.Flight.FlightElement.SecondElementWingman);
										break;
									}
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_40Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec:
									{
										if (flag)
										{
											nullable_3 = null;
										}
										ref Waypoint waypoint_SecondElementWingman27 = ref waypoint_10.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman28 = ref waypoint_11.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman29 = ref waypoint_15.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman30 = ref waypoint_12.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman2 = ref waypoint_13.Waypoint_SecondElementWingman;
										Misc.TurnDirection turnDirection_15 = turnDirection;
										float float_91 = num25;
										float float_92 = num45;
										float float_93 = num51;
										float float_94 = num5;
										int int_44 = num20;
										int int_46 = num21;
										int int_47 = num22;
										string string_9 = ", a/c #4";
										ViewTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_SecondElementWingman27, ref waypoint_11, ref waypoint_SecondElementWingman28, ref waypoint_15, ref waypoint_SecondElementWingman29, ref waypoint_12, ref waypoint_SecondElementWingman30, ref waypoint_13, ref waypoint_SecondElementWingman2, ref waypoint_14, turnDirection_15, float_66, float_3, float_91, float_92, float_93, float_94, int_44, int_46, int_47, ref nullable_3, float_0, bool_0: true, bool_1: false, bool_1, ref string_9);
										break;
									}
									case Mission._AttackMethod.BananaSplit:
									{
										ref Waypoint waypoint_SecondElementWingman = ref waypoint_10.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman12 = ref waypoint_11.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman23 = ref waypoint_15.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman25 = ref waypoint_12.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman26 = ref waypoint_13.Waypoint_SecondElementWingman;
										Misc.TurnDirection turnDirection_14 = turnDirection;
										float float_86 = num34;
										float float_87 = num45;
										float float_89 = num49;
										float float_90 = num3;
										int int_41 = num20;
										int int_42 = num21;
										int int_43 = num22;
										string string_8 = ", a/c #4";
										LoginTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_SecondElementWingman, ref waypoint_11, ref waypoint_SecondElementWingman12, ref waypoint_15, ref waypoint_SecondElementWingman23, ref waypoint_12, ref waypoint_SecondElementWingman25, ref waypoint_13, ref waypoint_SecondElementWingman26, ref waypoint_14, turnDirection_14, float_66, float_3, float_86, float_87, float_89, float_90, int_41, int_42, int_43, float_0, bool_0: false, bool_1: false, bool_1, ref string_8, Mission.Flight.FlightElement.SecondElementWingman, ref bool_3);
										break;
									}
									case Mission._AttackMethod.SingleAxisStackedToT_20Sec:
									case Mission._AttackMethod.SingleAxisStackedToT_30Sec:
									case Mission._AttackMethod.SingleAxisStackedToT_40Sec:
										break;
									}
								}
								else
								{
									if (!(flightSize6 == 6))
									{
										continue;
									}
									int num26;
									int num27;
									int num28;
									if ((!flag && turnDirection_0 == Misc.TurnDirection.TurnRight) || (flag && turnDirection_0 == Misc.TurnDirection.TurnLeft))
									{
										num26 = 1;
										num27 = 120;
										num28 = 1;
									}
									else
									{
										num26 = -1;
										num27 = -120;
										num28 = -1;
									}
									int? nullable_4 = null;
									bool flag12;
									switch (strike.AttackMethod)
									{
									case Mission._AttackMethod.MultiAxisSimultaneousToT:
									{
										ref Waypoint waypoint_LeadElementWingman52 = ref waypoint_10.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman53 = ref waypoint_11.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman54 = ref waypoint_15.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman55 = ref waypoint_12.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman57 = ref waypoint_13.Waypoint_LeadElementWingman;
										float float_107 = num45;
										float float_108 = num49;
										float float_109 = num3;
										int int_58 = num26;
										int int_59 = num27;
										int int_60 = num28;
										string string_14 = ", a/c #2";
										GetTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_LeadElementWingman52, ref waypoint_11, ref waypoint_LeadElementWingman53, ref waypoint_15, ref waypoint_LeadElementWingman54, ref waypoint_12, ref waypoint_LeadElementWingman55, ref waypoint_13, ref waypoint_LeadElementWingman57, ref waypoint_14, turnDirection_0, float_66, float_3, float_3, float_107, float_108, float_109, int_58, int_59, int_60, float_0, bool_0: true, bool_1: true, bool_1, ref string_14, Mission.Flight.FlightElement.LeadElementWingman);
										break;
									}
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_40Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec:
									{
										flag12 = !flag && !bool_1;
										ref Waypoint waypoint_LeadElementWingman47 = ref waypoint_10.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman48 = ref waypoint_11.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman49 = ref waypoint_15.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman50 = ref waypoint_12.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman51 = ref waypoint_13.Waypoint_LeadElementWingman;
										float float_104 = num45;
										float float_105 = num49;
										float float_106 = num3;
										int int_54 = num26;
										int int_55 = num27;
										int int_57 = num28;
										bool bool_15 = flag12;
										string string_13 = ", a/c #2";
										ViewTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_LeadElementWingman47, ref waypoint_11, ref waypoint_LeadElementWingman48, ref waypoint_15, ref waypoint_LeadElementWingman49, ref waypoint_12, ref waypoint_LeadElementWingman50, ref waypoint_13, ref waypoint_LeadElementWingman51, ref waypoint_14, turnDirection_0, float_66, float_3, float_3, float_104, float_105, float_106, int_54, int_55, int_57, ref nullable_4, float_0, bool_15, bool_1: false, bool_1, ref string_13);
										break;
									}
									case Mission._AttackMethod.BananaSplit:
									{
										flag12 = false;
										ref Waypoint waypoint_LeadElementWingman41 = ref waypoint_10.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman42 = ref waypoint_11.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman43 = ref waypoint_15.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman44 = ref waypoint_12.Waypoint_LeadElementWingman;
										ref Waypoint waypoint_LeadElementWingman46 = ref waypoint_13.Waypoint_LeadElementWingman;
										float float_100 = num34;
										float float_101 = num45;
										float float_102 = num49;
										float float_103 = num3;
										int int_51 = num26;
										int int_52 = num27;
										int int_53 = num28;
										string string_11 = ", a/c #2";
										LoginTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_LeadElementWingman41, ref waypoint_11, ref waypoint_LeadElementWingman42, ref waypoint_15, ref waypoint_LeadElementWingman43, ref waypoint_12, ref waypoint_LeadElementWingman44, ref waypoint_13, ref waypoint_LeadElementWingman46, ref waypoint_14, turnDirection_0, float_66, float_3, float_100, float_101, float_102, float_103, int_51, int_52, int_53, float_0, bool_0: false, bool_1: false, bool_1, ref string_11, Mission.Flight.FlightElement.LeadElementWingman, ref bool_3);
										break;
									}
									}
									Misc.TurnDirection turnDirection2 = ((strike.AttackMethod == Mission._AttackMethod.MultiAxisSimultaneousToT || strike.AttackMethod == Mission._AttackMethod.BananaSplit) ? turnDirection_0 : (((!flag && turnDirection_0 == Misc.TurnDirection.TurnRight) || (flag && turnDirection_0 == Misc.TurnDirection.TurnLeft)) ? Misc.TurnDirection.TurnLeft : Misc.TurnDirection.TurnRight));
									if ((!flag && turnDirection_0 == Misc.TurnDirection.TurnRight) || (flag && turnDirection_0 == Misc.TurnDirection.TurnLeft))
									{
										num26 = -1;
										num27 = -120;
										num28 = -1;
									}
									else
									{
										num26 = 1;
										num27 = 120;
										num28 = 1;
									}
									nullable_4 = null;
									float num29 = Math.Min((float)((double)float_3 + (double)waypoint_.ActualSpeed * ((double)waypoint_15.Separation_Time * 0.9 / 3600.0)), (float)((double)float_2 * 0.9));
									switch (strike.AttackMethod)
									{
									case Mission._AttackMethod.MultiAxisSimultaneousToT:
									{
										ref Waypoint waypoint_SecondElement36 = ref waypoint_10.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement37 = ref waypoint_11.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement38 = ref waypoint_15.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement39 = ref waypoint_12.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement40 = ref waypoint_13.Waypoint_SecondElement;
										Misc.TurnDirection turnDirection_2 = turnDirection2;
										float float_119 = num29;
										float float_120 = num45;
										float float_122 = num50;
										float float_123 = num4;
										int int_68 = num26;
										int int_69 = num27;
										int int_70 = num28;
										string string_17 = ", a/c #3";
										GetTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_SecondElement36, ref waypoint_11, ref waypoint_SecondElement37, ref waypoint_15, ref waypoint_SecondElement38, ref waypoint_12, ref waypoint_SecondElement39, ref waypoint_13, ref waypoint_SecondElement40, ref waypoint_14, turnDirection_2, float_66, float_3, float_119, float_120, float_122, float_123, int_68, int_69, int_70, float_0, bool_0: true, bool_1: true, bool_1, ref string_17, Mission.Flight.FlightElement.SecondElement);
										break;
									}
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_40Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec:
									{
										flag12 = !flag || !bool_1;
										ref Waypoint waypoint_SecondElement30 = ref waypoint_10.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement31 = ref waypoint_11.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement32 = ref waypoint_15.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement33 = ref waypoint_12.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement35 = ref waypoint_13.Waypoint_SecondElement;
										Misc.TurnDirection turnDirection_18 = turnDirection2;
										float float_115 = num29;
										float float_116 = num45;
										float float_117 = num50;
										float float_118 = num4;
										int int_64 = num26;
										int int_65 = num27;
										int int_66 = num28;
										bool bool_16 = flag12;
										string string_16 = ", a/c #3";
										ViewTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_SecondElement30, ref waypoint_11, ref waypoint_SecondElement31, ref waypoint_15, ref waypoint_SecondElement32, ref waypoint_12, ref waypoint_SecondElement33, ref waypoint_13, ref waypoint_SecondElement35, ref waypoint_14, turnDirection_18, float_66, float_3, float_115, float_116, float_117, float_118, int_64, int_65, int_66, ref nullable_4, float_0, bool_16, bool_1: false, bool_1, ref string_16);
										break;
									}
									case Mission._AttackMethod.BananaSplit:
									{
										flag12 = false;
										ref Waypoint waypoint_SecondElement25 = ref waypoint_10.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement26 = ref waypoint_11.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement27 = ref waypoint_15.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement28 = ref waypoint_12.Waypoint_SecondElement;
										ref Waypoint waypoint_SecondElement29 = ref waypoint_13.Waypoint_SecondElement;
										Misc.TurnDirection turnDirection_17 = turnDirection2;
										float float_111 = num34;
										float float_112 = num45;
										float float_113 = num49;
										float float_114 = num3;
										int int_61 = num26;
										int int_62 = num27;
										int int_63 = num28;
										string string_15 = ", a/c #3";
										LoginTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_SecondElement25, ref waypoint_11, ref waypoint_SecondElement26, ref waypoint_15, ref waypoint_SecondElement27, ref waypoint_12, ref waypoint_SecondElement28, ref waypoint_13, ref waypoint_SecondElement29, ref waypoint_14, turnDirection_17, float_66, float_3, float_111, float_112, float_113, float_114, int_61, int_62, int_63, float_0, bool_0: false, bool_1: false, bool_1, ref string_15, Mission.Flight.FlightElement.SecondElement, ref bool_3);
										break;
									}
									}
									num29 = Math.Min((float)((double)float_3 + (double)waypoint_.ActualSpeed * ((double)waypoint_15.Separation_Time * 1.4 / 3600.0)), (float)((double)float_2 * 1.4));
									if (flag)
									{
										num26 = -num26;
										num27 = -num27;
										num28 = -num28;
										nullable_4 = (-nullable_4) ?? nullable_4;
										turnDirection2 = ((turnDirection2 != Misc.TurnDirection.TurnLeft) ? Misc.TurnDirection.TurnLeft : Misc.TurnDirection.TurnRight);
									}
									switch (strike.AttackMethod)
									{
									case Mission._AttackMethod.MultiAxisSimultaneousToT:
									{
										ref Waypoint waypoint_SecondElementWingman19 = ref waypoint_10.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman20 = ref waypoint_11.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman21 = ref waypoint_15.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman22 = ref waypoint_12.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman24 = ref waypoint_13.Waypoint_SecondElementWingman;
										Misc.TurnDirection turnDirection_5 = turnDirection2;
										float float_5 = num29;
										float float_6 = num45;
										float float_7 = num51;
										float float_8 = num5;
										int int_77 = num26;
										int int_79 = num27;
										int int_80 = num28;
										string string_20 = ", a/c #4";
										GetTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_SecondElementWingman19, ref waypoint_11, ref waypoint_SecondElementWingman20, ref waypoint_15, ref waypoint_SecondElementWingman21, ref waypoint_12, ref waypoint_SecondElementWingman22, ref waypoint_13, ref waypoint_SecondElementWingman24, ref waypoint_14, turnDirection_5, float_66, float_3, float_5, float_6, float_7, float_8, int_77, int_79, int_80, float_0, bool_0: true, bool_1: true, bool_1, ref string_20, Mission.Flight.FlightElement.SecondElementWingman);
										break;
									}
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_40Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec:
									{
										if (flag)
										{
											nullable_4 = null;
										}
										ref Waypoint waypoint_SecondElementWingman14 = ref waypoint_10.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman15 = ref waypoint_11.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman16 = ref waypoint_15.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman17 = ref waypoint_12.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman18 = ref waypoint_13.Waypoint_SecondElementWingman;
										Misc.TurnDirection turnDirection_4 = turnDirection2;
										float float_128 = num29;
										float float_129 = num45;
										float float_130 = num51;
										float float_131 = num5;
										int int_74 = num26;
										int int_75 = num27;
										int int_76 = num28;
										string string_19 = ", a/c #4";
										ViewTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_SecondElementWingman14, ref waypoint_11, ref waypoint_SecondElementWingman15, ref waypoint_15, ref waypoint_SecondElementWingman16, ref waypoint_12, ref waypoint_SecondElementWingman17, ref waypoint_13, ref waypoint_SecondElementWingman18, ref waypoint_14, turnDirection_4, float_66, float_3, float_128, float_129, float_130, float_131, int_74, int_75, int_76, ref nullable_4, float_0, bool_0: true, bool_1: false, bool_1, ref string_19);
										break;
									}
									case Mission._AttackMethod.BananaSplit:
									{
										flag12 = false;
										ref Waypoint waypoint_SecondElementWingman8 = ref waypoint_10.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman9 = ref waypoint_11.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman10 = ref waypoint_15.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman11 = ref waypoint_12.Waypoint_SecondElementWingman;
										ref Waypoint waypoint_SecondElementWingman13 = ref waypoint_13.Waypoint_SecondElementWingman;
										Misc.TurnDirection turnDirection_3 = turnDirection2;
										float float_124 = num34;
										float float_125 = num45;
										float float_126 = num49;
										float float_127 = num3;
										int int_71 = num26;
										int int_72 = num27;
										int int_73 = num28;
										string string_18 = ", a/c #4";
										LoginTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_SecondElementWingman8, ref waypoint_11, ref waypoint_SecondElementWingman9, ref waypoint_15, ref waypoint_SecondElementWingman10, ref waypoint_12, ref waypoint_SecondElementWingman11, ref waypoint_13, ref waypoint_SecondElementWingman13, ref waypoint_14, turnDirection_3, float_66, float_3, float_124, float_125, float_126, float_127, int_71, int_72, int_73, float_0, bool_0: false, bool_1: false, bool_1, ref string_18, Mission.Flight.FlightElement.SecondElementWingman, ref bool_3);
										break;
									}
									}
									Misc.TurnDirection turnDirection3 = ((strike.AttackMethod == Mission._AttackMethod.MultiAxisSimultaneousToT || strike.AttackMethod == Mission._AttackMethod.BananaSplit) ? turnDirection_0 : (bool_1 ? turnDirection_0 : ((turnDirection_0 == Misc.TurnDirection.TurnRight) ? Misc.TurnDirection.TurnLeft : Misc.TurnDirection.TurnRight)));
									if (turnDirection_0 == Misc.TurnDirection.TurnRight)
									{
										num26 = 1;
										num27 = 120;
										num28 = 1;
									}
									else
									{
										num26 = -1;
										num27 = -120;
										num28 = -1;
									}
									nullable_4 = null;
									num29 = Math.Min((float)((double)float_3 + (double)waypoint_.ActualSpeed * ((double)waypoint_15.Separation_Time * 2.5 / 3600.0)), (float)((double)float_2 * 0.9));
									flag12 = !bool_1;
									switch (strike.AttackMethod)
									{
									case Mission._AttackMethod.MultiAxisSimultaneousToT:
									{
										ref Waypoint waypoint_ThirdElement3 = ref waypoint_10.Waypoint_ThirdElement;
										ref Waypoint waypoint_ThirdElement4 = ref waypoint_11.Waypoint_ThirdElement;
										ref Waypoint waypoint_ThirdElement5 = ref waypoint_15.Waypoint_ThirdElement;
										ref Waypoint waypoint_ThirdElement6 = ref waypoint_12.Waypoint_ThirdElement;
										ref Waypoint waypoint_ThirdElement7 = ref waypoint_13.Waypoint_ThirdElement;
										Misc.TurnDirection turnDirection_8 = turnDirection3;
										float float_20 = num29;
										float float_21 = num45;
										float float_22 = num52;
										float float_23 = num6;
										int int_87 = num26;
										int int_88 = num27;
										int int_90 = num28;
										string string_24 = ", a/c #5";
										GetTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_ThirdElement3, ref waypoint_11, ref waypoint_ThirdElement4, ref waypoint_15, ref waypoint_ThirdElement5, ref waypoint_12, ref waypoint_ThirdElement6, ref waypoint_13, ref waypoint_ThirdElement7, ref waypoint_14, turnDirection_8, float_66, float_3, float_20, float_21, float_22, float_23, int_87, int_88, int_90, float_0, bool_0: true, bool_1: true, bool_1, ref string_24, Mission.Flight.FlightElement.ThirdElement);
										break;
									}
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_40Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec:
									{
										if (!flag && bool_1 && strike.SplitDistance == Mission._SplitDistance.Close_10nm)
										{
											float float_13 = Math2.PublishClass(waypoint_.Latitude, waypoint_.Longitude, waypoint.Latitude, waypoint.Longitude);
											float float_14 = Math2.PublishClass(waypoint.Latitude, waypoint.Longitude, waypoint_14.Latitude, waypoint_14.Longitude);
											if (Math.Abs(MathFunctions.DeleteRequest(float_13, float_14)) > 90f)
											{
												flag12 = true;
											}
										}
										ref Waypoint waypoint_ThirdElement12 = ref waypoint_10.Waypoint_ThirdElement;
										ref Waypoint waypoint_ThirdElement13 = ref waypoint_11.Waypoint_ThirdElement;
										ref Waypoint waypoint_ThirdElement14 = ref waypoint_15.Waypoint_ThirdElement;
										ref Waypoint waypoint_ThirdElement15 = ref waypoint_12.Waypoint_ThirdElement;
										ref Waypoint waypoint_ThirdElement2 = ref waypoint_13.Waypoint_ThirdElement;
										Misc.TurnDirection turnDirection_7 = turnDirection3;
										float float_16 = num29;
										float float_17 = num45;
										float float_18 = num52;
										float float_19 = num6;
										int int_84 = num26;
										int int_85 = num27;
										int int_86 = num28;
										bool bool_17 = flag12;
										bool bool_4 = !bool_1;
										string string_22 = ", a/c #5";
										ViewTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_ThirdElement12, ref waypoint_11, ref waypoint_ThirdElement13, ref waypoint_15, ref waypoint_ThirdElement14, ref waypoint_12, ref waypoint_ThirdElement15, ref waypoint_13, ref waypoint_ThirdElement2, ref waypoint_14, turnDirection_7, float_66, float_3, float_16, float_17, float_18, float_19, int_84, int_85, int_86, ref nullable_4, float_0, bool_17, bool_4, bool_1, ref string_22);
										break;
									}
									case Mission._AttackMethod.BananaSplit:
									{
										flag12 = false;
										ref Waypoint waypoint_ThirdElement = ref waypoint_10.Waypoint_ThirdElement;
										ref Waypoint waypoint_ThirdElement8 = ref waypoint_11.Waypoint_ThirdElement;
										ref Waypoint waypoint_ThirdElement9 = ref waypoint_15.Waypoint_ThirdElement;
										ref Waypoint waypoint_ThirdElement10 = ref waypoint_12.Waypoint_ThirdElement;
										ref Waypoint waypoint_ThirdElement11 = ref waypoint_13.Waypoint_ThirdElement;
										Misc.TurnDirection turnDirection_6 = turnDirection3;
										float float_9 = num34;
										float float_10 = num45;
										float float_11 = num49;
										float float_12 = num3;
										int int_81 = num26;
										int int_82 = num27;
										int int_83 = num28;
										string string_21 = ", a/c #5";
										LoginTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_ThirdElement, ref waypoint_11, ref waypoint_ThirdElement8, ref waypoint_15, ref waypoint_ThirdElement9, ref waypoint_12, ref waypoint_ThirdElement10, ref waypoint_13, ref waypoint_ThirdElement11, ref waypoint_14, turnDirection_6, float_66, float_3, float_9, float_10, float_11, float_12, int_81, int_82, int_83, float_0, bool_0: false, bool_1: false, bool_1, ref string_21, Mission.Flight.FlightElement.ThirdElement, ref bool_3);
										break;
									}
									}
									num29 = Math.Min(float_3 + waypoint_.ActualSpeed * (waypoint_15.Separation_Time * 3f / 3600f), (float)((double)float_2 * 1.4));
									if (flag)
									{
										num26 = -num26;
										num27 = -num27;
										num28 = -num28;
										nullable_4 = (-nullable_4) ?? nullable_4;
										turnDirection3 = ((turnDirection3 != Misc.TurnDirection.TurnLeft) ? Misc.TurnDirection.TurnLeft : Misc.TurnDirection.TurnRight);
									}
									if (flag && bool_1)
									{
										flag12 = !flag12;
									}
									switch (strike.AttackMethod)
									{
									case Mission._AttackMethod.MultiAxisSimultaneousToT:
									{
										ref Waypoint waypoint_ThirdElementWingman3 = ref waypoint_10.Waypoint_ThirdElementWingman;
										ref Waypoint waypoint_ThirdElementWingman4 = ref waypoint_11.Waypoint_ThirdElementWingman;
										ref Waypoint waypoint_ThirdElementWingman5 = ref waypoint_15.Waypoint_ThirdElementWingman;
										ref Waypoint waypoint_ThirdElementWingman6 = ref waypoint_12.Waypoint_ThirdElementWingman;
										ref Waypoint waypoint_ThirdElementWingman7 = ref waypoint_13.Waypoint_ThirdElementWingman;
										Misc.TurnDirection turnDirection_10 = turnDirection3;
										float float_35 = num29;
										float float_36 = num45;
										float float_38 = num2;
										float float_39 = num7;
										int int_97 = num26;
										int int_98 = num27;
										int int_99 = num28;
										string string_27 = ", a/c #6";
										GetTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_ThirdElementWingman3, ref waypoint_11, ref waypoint_ThirdElementWingman4, ref waypoint_15, ref waypoint_ThirdElementWingman5, ref waypoint_12, ref waypoint_ThirdElementWingman6, ref waypoint_13, ref waypoint_ThirdElementWingman7, ref waypoint_14, turnDirection_10, float_66, float_3, float_35, float_36, float_38, float_39, int_97, int_98, int_99, float_0, bool_0: true, bool_1: true, bool_1, ref string_27, Mission.Flight.FlightElement.ThirdElementWingman);
										break;
									}
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Echelon_40Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec:
									case Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec:
									{
										if (!flag && bool_1 && strike.SplitDistance == Mission._SplitDistance.Close_10nm)
										{
											float float_29 = Math2.PublishClass(waypoint_.Latitude, waypoint_.Longitude, waypoint.Latitude, waypoint.Longitude);
											float float_30 = Math2.PublishClass(waypoint.Latitude, waypoint.Longitude, waypoint_14.Latitude, waypoint_14.Longitude);
											if (Math.Abs(MathFunctions.DeleteRequest(float_29, float_30)) > 90f)
											{
												flag12 = false;
											}
										}
										else if (flag)
										{
											nullable_4 = null;
										}
										ref Waypoint waypoint_ThirdElementWingman12 = ref waypoint_10.Waypoint_ThirdElementWingman;
										ref Waypoint waypoint_ThirdElementWingman13 = ref waypoint_11.Waypoint_ThirdElementWingman;
										ref Waypoint waypoint_ThirdElementWingman14 = ref waypoint_15.Waypoint_ThirdElementWingman;
										ref Waypoint waypoint_ThirdElementWingman15 = ref waypoint_12.Waypoint_ThirdElementWingman;
										ref Waypoint waypoint_ThirdElementWingman2 = ref waypoint_13.Waypoint_ThirdElementWingman;
										Misc.TurnDirection turnDirection_9 = turnDirection3;
										float float_31 = num29;
										float float_32 = num45;
										float float_33 = num2;
										float float_34 = num7;
										int int_94 = num26;
										int int_95 = num27;
										int int_96 = num28;
										bool bool_5 = flag12;
										bool bool_6 = !bool_1;
										string string_26 = ", a/c #6";
										ViewTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_ThirdElementWingman12, ref waypoint_11, ref waypoint_ThirdElementWingman13, ref waypoint_15, ref waypoint_ThirdElementWingman14, ref waypoint_12, ref waypoint_ThirdElementWingman15, ref waypoint_13, ref waypoint_ThirdElementWingman2, ref waypoint_14, turnDirection_9, float_66, float_3, float_31, float_32, float_33, float_34, int_94, int_95, int_96, ref nullable_4, float_0, bool_5, bool_6, bool_1, ref string_26);
										break;
									}
									case Mission._AttackMethod.BananaSplit:
									{
										flag12 = false;
										ref Waypoint waypoint_ThirdElementWingman = ref waypoint_10.Waypoint_ThirdElementWingman;
										ref Waypoint waypoint_ThirdElementWingman8 = ref waypoint_11.Waypoint_ThirdElementWingman;
										ref Waypoint waypoint_ThirdElementWingman9 = ref waypoint_15.Waypoint_ThirdElementWingman;
										ref Waypoint waypoint_ThirdElementWingman10 = ref waypoint_12.Waypoint_ThirdElementWingman;
										ref Waypoint waypoint_ThirdElementWingman11 = ref waypoint_13.Waypoint_ThirdElementWingman;
										float float_24 = num34;
										float float_25 = num45;
										float float_27 = num49;
										float float_28 = num3;
										int int_91 = num26;
										int int_92 = num27;
										int int_93 = num28;
										string string_25 = ", a/c #6";
										LoginTokenizer(ref scenario_0, ref mission, ref flight, ref *(ActiveUnit*)(&object_0), ref waypoint_9, ref waypoint_, ref waypoint_10, ref waypoint_ThirdElementWingman, ref waypoint_11, ref waypoint_ThirdElementWingman8, ref waypoint_15, ref waypoint_ThirdElementWingman9, ref waypoint_12, ref waypoint_ThirdElementWingman10, ref waypoint_13, ref waypoint_ThirdElementWingman11, ref waypoint_14, turnDirection_0, float_66, float_3, float_24, float_25, float_27, float_28, int_91, int_92, int_93, float_0, bool_0: false, bool_1: false, bool_1, ref string_25, Mission.Flight.FlightElement.ThirdElementWingman, ref bool_3);
										break;
									}
									case Mission._AttackMethod.SingleAxisStackedToT_20Sec:
									case Mission._AttackMethod.SingleAxisStackedToT_30Sec:
									case Mission._AttackMethod.SingleAxisStackedToT_40Sec:
										break;
									}
								}
								continue;
							}
							i = j;
							break;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception exception_ = ex;
							exception_?.Data.Add("Error at 999999", "");
							GameGeneral.WriteExceptionsToLog(ref exception_);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
				}
			}
			int num30 = waypoint_0.Count() - 1;
			Waypoint[] waypoint_3 = null;
			Waypoint[] waypoint_4 = null;
			Waypoint[] waypoint_5 = null;
			Waypoint[] waypoint_6 = null;
			Waypoint[] waypoint_7 = null;
			for (int m = 0; m <= num30; m++)
			{
				try
				{
					if (waypoint_0[m].FlightFormation != Waypoint.Formation.Split)
					{
						continue;
					}
					Waypoint[] gparam_ = new Waypoint[0];
					Mission._FlightSize flightSize7 = flightSize;
					if (flightSize7 != 1)
					{
						if (flightSize7 == 2)
						{
							waypoint_3 = new Waypoint[0];
						}
						else if (flightSize7 == 3)
						{
							waypoint_3 = new Waypoint[0];
							waypoint_4 = new Waypoint[0];
						}
						else if (flightSize7 == 4)
						{
							waypoint_3 = new Waypoint[0];
							waypoint_4 = new Waypoint[0];
							waypoint_5 = new Waypoint[0];
						}
						else if (flightSize7 == 5)
						{
							waypoint_3 = new Waypoint[0];
							waypoint_4 = new Waypoint[0];
							waypoint_5 = new Waypoint[0];
							waypoint_6 = new Waypoint[0];
						}
						else
						{
							waypoint_3 = new Waypoint[0];
							waypoint_4 = new Waypoint[0];
							waypoint_5 = new Waypoint[0];
							waypoint_6 = new Waypoint[0];
							waypoint_7 = new Waypoint[0];
						}
					}
					ArrayExtensions.Add(ref gparam_, waypoint_0[m - 2]);
					if (!Information.IsNothing(waypoint_3) && m > 1)
					{
						ArrayExtensions.Add(ref waypoint_3, waypoint_0[m - 2]);
					}
					if (!Information.IsNothing(waypoint_4) && m > 1)
					{
						ArrayExtensions.Add(ref waypoint_4, waypoint_0[m - 2]);
					}
					if (!Information.IsNothing(waypoint_5) && m > 1)
					{
						ArrayExtensions.Add(ref waypoint_5, waypoint_0[m - 2]);
					}
					if (!Information.IsNothing(waypoint_6) && m > 1)
					{
						ArrayExtensions.Add(ref waypoint_6, waypoint_0[m - 2]);
					}
					if (!Information.IsNothing(waypoint_7) && m > 1)
					{
						ArrayExtensions.Add(ref waypoint_7, waypoint_0[m - 2]);
					}
					ArrayExtensions.Add(ref gparam_, waypoint_0[m - 1]);
					if (!Information.IsNothing(waypoint_3) && m > 0)
					{
						ArrayExtensions.Add(ref waypoint_3, waypoint_0[m - 1]);
					}
					if (!Information.IsNothing(waypoint_4) && m > 0)
					{
						ArrayExtensions.Add(ref waypoint_4, waypoint_0[m - 1]);
					}
					if (!Information.IsNothing(waypoint_5) && m > 0)
					{
						ArrayExtensions.Add(ref waypoint_5, waypoint_0[m - 1]);
					}
					if (!Information.IsNothing(waypoint_6) && m > 0)
					{
						ArrayExtensions.Add(ref waypoint_6, waypoint_0[m - 1]);
					}
					if (!Information.IsNothing(waypoint_7) && m > 0)
					{
						ArrayExtensions.Add(ref waypoint_7, waypoint_0[m - 1]);
					}
					int num31 = m;
					int num32 = waypoint_0.Count() - 1;
					for (int n = num31; n <= num32; n++)
					{
						Waypoint waypoint_8 = waypoint_0[n];
						if (Information.IsNothing(waypoint_8))
						{
							continue;
						}
						m = n;
						if (!Information.IsNothing(waypoint_0[m].Waypoint_LeadElementWingman) && waypoint_0[m].Waypoint_LeadElementWingman.SpeedFixed == Waypoint.FixedFree.Relative)
						{
							waypoint_0[m].Waypoint_LeadElementWingman.ActualSpeed = waypoint_0[m].ActualSpeed;
							waypoint_0[m].Waypoint_LeadElementWingman.DesiredSpeed = waypoint_0[m].DesiredSpeed;
							waypoint_0[m].Waypoint_LeadElementWingman.DesiredSpeedOverride = waypoint_0[m].DesiredSpeedOverride;
							waypoint_0[m].Waypoint_LeadElementWingman.ThrottlePreset = waypoint_0[m].ThrottlePreset;
						}
						if (!Information.IsNothing(waypoint_0[m].Waypoint_SecondElement) && waypoint_0[m].Waypoint_SecondElement.SpeedFixed == Waypoint.FixedFree.Relative)
						{
							waypoint_0[m].Waypoint_SecondElement.ActualSpeed = waypoint_0[m].ActualSpeed;
							waypoint_0[m].Waypoint_SecondElement.DesiredSpeed = waypoint_0[m].DesiredSpeed;
							waypoint_0[m].Waypoint_SecondElement.DesiredSpeedOverride = waypoint_0[m].DesiredSpeedOverride;
							waypoint_0[m].Waypoint_SecondElement.ThrottlePreset = waypoint_0[m].ThrottlePreset;
						}
						if (!Information.IsNothing(waypoint_0[m].Waypoint_SecondElementWingman) && waypoint_0[m].Waypoint_SecondElementWingman.SpeedFixed == Waypoint.FixedFree.Relative)
						{
							waypoint_0[m].Waypoint_SecondElementWingman.ActualSpeed = waypoint_0[m].ActualSpeed;
							waypoint_0[m].Waypoint_SecondElementWingman.DesiredSpeed = waypoint_0[m].DesiredSpeed;
							waypoint_0[m].Waypoint_SecondElementWingman.DesiredSpeedOverride = waypoint_0[m].DesiredSpeedOverride;
							waypoint_0[m].Waypoint_SecondElementWingman.ThrottlePreset = waypoint_0[m].ThrottlePreset;
						}
						if (!Information.IsNothing(waypoint_0[m].Waypoint_ThirdElement) && waypoint_0[m].Waypoint_ThirdElement.SpeedFixed == Waypoint.FixedFree.Relative)
						{
							waypoint_0[m].Waypoint_ThirdElement.ActualSpeed = waypoint_0[m].ActualSpeed;
							waypoint_0[m].Waypoint_ThirdElement.DesiredSpeed = waypoint_0[m].DesiredSpeed;
							waypoint_0[m].Waypoint_ThirdElement.DesiredSpeedOverride = waypoint_0[m].DesiredSpeedOverride;
							waypoint_0[m].Waypoint_ThirdElement.ThrottlePreset = waypoint_0[m].ThrottlePreset;
						}
						if (!Information.IsNothing(waypoint_0[m].Waypoint_ThirdElementWingman) && waypoint_0[m].Waypoint_ThirdElementWingman.SpeedFixed == Waypoint.FixedFree.Relative)
						{
							waypoint_0[m].Waypoint_ThirdElementWingman.ActualSpeed = waypoint_0[m].ActualSpeed;
							waypoint_0[m].Waypoint_ThirdElementWingman.DesiredSpeed = waypoint_0[m].DesiredSpeed;
							waypoint_0[m].Waypoint_ThirdElementWingman.DesiredSpeedOverride = waypoint_0[m].DesiredSpeedOverride;
							waypoint_0[m].Waypoint_ThirdElementWingman.ThrottlePreset = waypoint_0[m].ThrottlePreset;
						}
						ArrayExtensions.Add(ref gparam_, waypoint_0[m]);
						if (!Information.IsNothing(waypoint_3) && !Information.IsNothing(waypoint_0[m].Waypoint_LeadElementWingman))
						{
							ArrayExtensions.Add(ref waypoint_3, waypoint_0[m].Waypoint_LeadElementWingman);
						}
						if (!Information.IsNothing(waypoint_4) && !Information.IsNothing(waypoint_0[m].Waypoint_SecondElement))
						{
							ArrayExtensions.Add(ref waypoint_4, waypoint_0[m].Waypoint_SecondElement);
						}
						if (!Information.IsNothing(waypoint_5) && !Information.IsNothing(waypoint_0[m].Waypoint_SecondElementWingman))
						{
							ArrayExtensions.Add(ref waypoint_5, waypoint_0[m].Waypoint_SecondElementWingman);
						}
						if (!Information.IsNothing(waypoint_6) && !Information.IsNothing(waypoint_0[m].Waypoint_ThirdElement))
						{
							ArrayExtensions.Add(ref waypoint_6, waypoint_0[m].Waypoint_ThirdElement);
						}
						if (!Information.IsNothing(waypoint_7) && !Information.IsNothing(waypoint_0[m].Waypoint_ThirdElementWingman))
						{
							ArrayExtensions.Add(ref waypoint_7, waypoint_0[m].Waypoint_ThirdElementWingman);
						}
						if (waypoint_8.FlightFormation == Waypoint.Formation.Split)
						{
							continue;
						}
						if (Information.IsNothing(waypoint_8.Waypoint_LeadElementWingman))
						{
							if (flightSize >= 2)
							{
								waypoint_8.Waypoint_LeadElementWingman = new Waypoint();
								Waypoint waypoint30 = waypoint_8;
								Doctrine doctrine_5 = waypoint_8.Doctrine;
								waypoint30.Waypoint_LeadElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_8, bool_0: false, bool_1: false, ref doctrine_5);
								waypoint_8.Waypoint_LeadElementWingman.SpeedFixed = Waypoint.FixedFree.Free;
								ArrayExtensions.Add(ref waypoint_3, waypoint_0[m].Waypoint_LeadElementWingman);
							}
						}
						else
						{
							waypoint_8.Waypoint_LeadElementWingman.Latitude = waypoint_8.Latitude;
							waypoint_8.Waypoint_LeadElementWingman.Longitude = waypoint_8.Longitude;
						}
						if (Information.IsNothing(waypoint_8.Waypoint_SecondElement))
						{
							if (flightSize >= 3)
							{
								waypoint_8.Waypoint_SecondElement = new Waypoint();
								Waypoint waypoint31 = waypoint_8;
								Doctrine doctrine_6 = waypoint_8.Doctrine;
								waypoint31.Waypoint_SecondElement = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_8, bool_0: false, bool_1: false, ref doctrine_6);
								waypoint_8.Waypoint_SecondElement.SpeedFixed = Waypoint.FixedFree.Free;
								ArrayExtensions.Add(ref waypoint_4, waypoint_0[m].Waypoint_SecondElement);
							}
						}
						else
						{
							waypoint_8.Waypoint_SecondElement.Latitude = waypoint_8.Latitude;
							waypoint_8.Waypoint_SecondElement.Longitude = waypoint_8.Longitude;
						}
						if (Information.IsNothing(waypoint_8.Waypoint_SecondElementWingman))
						{
							if (flightSize >= 4)
							{
								waypoint_8.Waypoint_SecondElementWingman = new Waypoint();
								Waypoint waypoint32 = waypoint_8;
								Doctrine doctrine_7 = waypoint_8.Doctrine;
								waypoint32.Waypoint_SecondElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_8, bool_0: false, bool_1: false, ref doctrine_7);
								waypoint_8.Waypoint_SecondElementWingman.SpeedFixed = Waypoint.FixedFree.Free;
								ArrayExtensions.Add(ref waypoint_5, waypoint_0[m].Waypoint_SecondElementWingman);
							}
						}
						else
						{
							waypoint_8.Waypoint_SecondElementWingman.Latitude = waypoint_8.Latitude;
							waypoint_8.Waypoint_SecondElementWingman.Longitude = waypoint_8.Longitude;
						}
						if (Information.IsNothing(waypoint_8.Waypoint_ThirdElement))
						{
							if (flightSize >= 6)
							{
								waypoint_8.Waypoint_ThirdElement = new Waypoint();
								Waypoint waypoint33 = waypoint_8;
								Doctrine doctrine_8 = waypoint_8.Doctrine;
								waypoint33.Waypoint_ThirdElement = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_8, bool_0: false, bool_1: false, ref doctrine_8);
								waypoint_8.Waypoint_ThirdElement.SpeedFixed = Waypoint.FixedFree.Free;
								ArrayExtensions.Add(ref waypoint_6, waypoint_0[m].Waypoint_ThirdElement);
							}
						}
						else
						{
							waypoint_8.Waypoint_ThirdElement.Latitude = waypoint_8.Latitude;
							waypoint_8.Waypoint_ThirdElement.Longitude = waypoint_8.Longitude;
						}
						if (Information.IsNothing(waypoint_8.Waypoint_ThirdElementWingman))
						{
							if (flightSize >= 6)
							{
								waypoint_8.Waypoint_ThirdElementWingman = new Waypoint();
								Waypoint waypoint35 = waypoint_8;
								Doctrine doctrine_9 = waypoint_8.Doctrine;
								waypoint35.Waypoint_ThirdElementWingman = Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_8, bool_0: false, bool_1: false, ref doctrine_9);
								waypoint_8.Waypoint_ThirdElementWingman.SpeedFixed = Waypoint.FixedFree.Free;
								ArrayExtensions.Add(ref waypoint_7, waypoint_0[m].Waypoint_ThirdElementWingman);
							}
						}
						else
						{
							waypoint_8.Waypoint_ThirdElementWingman.Latitude = waypoint_8.Latitude;
							waypoint_8.Waypoint_ThirdElementWingman.Longitude = waypoint_8.Longitude;
						}
						if (!Information.IsNothing(waypoint_3))
						{
							bool bool_7 = true;
							CallTokenizer(ref scenario_0, ref mission, ref flight, ref waypoint_3, ref gparam_, ref *(ActiveUnit*)(&object_0), float_0, ref bool_7, ref float_1, bool_0, ", a/c #2", Mission.Flight.FlightElement.LeadElementWingman);
						}
						if (!Information.IsNothing(waypoint_4))
						{
							bool bool_8 = true;
							CallTokenizer(ref scenario_0, ref mission, ref flight, ref waypoint_4, ref gparam_, ref *(ActiveUnit*)(&object_0), float_0, ref bool_8, ref float_1, bool_0, ", a/c #3", Mission.Flight.FlightElement.SecondElement);
						}
						if (!Information.IsNothing(waypoint_5))
						{
							bool bool_9 = true;
							CallTokenizer(ref scenario_0, ref mission, ref flight, ref waypoint_5, ref gparam_, ref *(ActiveUnit*)(&object_0), float_0, ref bool_9, ref float_1, bool_0, ", a/c #4", Mission.Flight.FlightElement.SecondElementWingman);
						}
						if (!Information.IsNothing(waypoint_6))
						{
							bool bool_10 = true;
							CallTokenizer(ref scenario_0, ref mission, ref flight, ref waypoint_6, ref gparam_, ref *(ActiveUnit*)(&object_0), float_0, ref bool_10, ref float_1, bool_0, ", a/c #5", Mission.Flight.FlightElement.ThirdElement);
						}
						if (!Information.IsNothing(waypoint_7))
						{
							bool bool_11 = true;
							CallTokenizer(ref scenario_0, ref mission, ref flight, ref waypoint_7, ref gparam_, ref *(ActiveUnit*)(&object_0), float_0, ref bool_11, ref float_1, bool_0, ", a/c #6", Mission.Flight.FlightElement.ThirdElementWingman);
						}
						break;
					}
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at 999999", "");
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			float num33 = float_1;
			float num35 = float_1;
			float num36 = float_1;
			float num37 = float_1;
			float num38 = float_1;
			float num39 = 0f;
			float num40 = 0f;
			float num41 = 0f;
			float num42 = 0f;
			float num43 = 0f;
			int num44 = waypoint_0.Count() - 1;
			Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment = null;
			for (int num46 = 0; num46 <= num44; num46++)
			{
				try
				{
					Waypoint waypoint36 = waypoint_0[num46];
					if (Information.IsNothing(waypoint36))
					{
						continue;
					}
					Waypoint waypoint37 = ((num46 <= 0) ? null : waypoint_0[num46 - 1]);
					Doctrine._UseUnderwayRefuelAndReplenishment? useReplenishment = waypoint36.Doctrine.GetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					Mission._FlightSize flightSize8 = flightSize;
					bool? flag34;
					byte? b;
					if (flightSize8 == 2)
					{
						if (waypoint36.FlightFormation != Waypoint.Formation.Split && (Information.IsNothing(waypoint37) || waypoint37.FlightFormation != Waypoint.Formation.Split))
						{
							num33 = ((waypoint36.Leg_FuelRemaining == float_1 || float_1 == float.MaxValue) ? float_1 : (num33 - waypoint36.Leg_FuelRequired));
							num39 += waypoint36.Leg_Distance_Straight + waypoint36.Leg_Distance_Turn;
						}
						else if (!Information.IsNothing(waypoint36.Waypoint_LeadElementWingman))
						{
							b = (byte?)useReplenishment;
							bool? flag23 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
							flag34 = (!flag23) ?? flag23;
							if (flag34.GetValueOrDefault(true))
							{
								b = (byte?)useReplenishment;
								bool? flag45;
								bool? flag56 = (flag45 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null));
								bool? flag67;
								flag45 = (flag67 = ((flag56.HasValue && !flag45.GetValueOrDefault()) ? new bool?(false) : (Information.IsNothing(useUnderwayRefuelAndReplenishment) ? new bool?(false) : flag45)));
								bool? flag68;
								if (flag45.HasValue && !flag67.GetValueOrDefault())
								{
									flag68 = false;
								}
								else
								{
									b = (byte?)useUnderwayRefuelAndReplenishment;
									bool? flag69;
									flag45 = (flag69 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null));
									flag68 = ((!flag45.HasValue) ? null : (flag69.GetValueOrDefault() & flag67));
								}
								flag23 = flag68;
								if (((!flag23) ?? flag23).GetValueOrDefault() && flag34.HasValue)
								{
									goto IL_84e9;
								}
							}
							if (float_1 == float.MaxValue)
							{
								goto IL_84e9;
							}
							num33 -= waypoint36.Waypoint_LeadElementWingman.Leg_FuelRequired;
							goto IL_84a3;
						}
						goto IL_84cc;
					}
					if (flightSize8 != 3)
					{
						if (flightSize8 == 4)
						{
							if (waypoint36.FlightFormation != Waypoint.Formation.Split && (Information.IsNothing(waypoint37) || waypoint37.FlightFormation != Waypoint.Formation.Split))
							{
								num33 = ((waypoint36.Leg_FuelRemaining == float_1 || float_1 == float.MaxValue) ? float_1 : (num33 - waypoint36.Leg_FuelRequired));
								num35 = ((waypoint36.Leg_FuelRemaining == float_1 || float_1 == float.MaxValue) ? float_1 : (num35 - waypoint36.Leg_FuelRequired));
								num36 = ((waypoint36.Leg_FuelRemaining == float_1 || float_1 == float.MaxValue) ? float_1 : (num36 - waypoint36.Leg_FuelRequired));
								num39 += waypoint36.Leg_Distance_Straight + waypoint36.Leg_Distance_Turn;
								num40 += waypoint36.Leg_Distance_Straight + waypoint36.Leg_Distance_Turn;
								num41 += waypoint36.Leg_Distance_Straight + waypoint36.Leg_Distance_Turn;
								goto IL_8072;
							}
							if (!Information.IsNothing(waypoint36.Waypoint_LeadElementWingman))
							{
								b = (byte?)useReplenishment;
								bool? flag2 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
								flag34 = (!flag2) ?? flag2;
								if (flag34.GetValueOrDefault(true))
								{
									b = (byte?)useReplenishment;
									bool? flag3;
									bool? flag4 = (flag3 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null));
									bool? flag5;
									flag3 = (flag5 = ((flag4.HasValue && !flag3.GetValueOrDefault()) ? new bool?(false) : (Information.IsNothing(useUnderwayRefuelAndReplenishment) ? new bool?(false) : flag3)));
									bool? flag6;
									if (flag3.HasValue && !flag5.GetValueOrDefault())
									{
										flag6 = false;
									}
									else
									{
										b = (byte?)useUnderwayRefuelAndReplenishment;
										bool? flag7;
										flag3 = (flag7 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null));
										flag6 = ((!flag3.HasValue) ? null : (flag7.GetValueOrDefault() & flag5));
									}
									flag2 = flag6;
									if (((!flag2) ?? flag2).GetValueOrDefault() && flag34.HasValue)
									{
										goto IL_7be5;
									}
								}
								if (float_1 == float.MaxValue)
								{
									goto IL_7be5;
								}
								num33 -= waypoint36.Waypoint_LeadElementWingman.Leg_FuelRequired;
								goto IL_6f21;
							}
							goto IL_899a;
						}
						if (flightSize8 == 6)
						{
							if (waypoint36.FlightFormation != Waypoint.Formation.Split && (Information.IsNothing(waypoint37) || waypoint37.FlightFormation != Waypoint.Formation.Split))
							{
								num33 = ((waypoint36.Leg_FuelRemaining == float_1 || float_1 == float.MaxValue) ? float_1 : (num33 - waypoint36.Leg_FuelRequired));
								num35 = ((waypoint36.Leg_FuelRemaining == float_1 || float_1 == float.MaxValue) ? float_1 : (num35 - waypoint36.Leg_FuelRequired));
								num36 = ((waypoint36.Leg_FuelRemaining == float_1 || float_1 == float.MaxValue) ? float_1 : (num36 - waypoint36.Leg_FuelRequired));
								num37 = ((waypoint36.Leg_FuelRemaining == float_1 || float_1 == float.MaxValue) ? float_1 : (num37 - waypoint36.Leg_FuelRequired));
								num38 = ((waypoint36.Leg_FuelRemaining == float_1 || float_1 == float.MaxValue) ? float_1 : (num38 - waypoint36.Leg_FuelRequired));
								num39 += waypoint36.Leg_Distance_Straight + waypoint36.Leg_Distance_Turn;
								num40 += waypoint36.Leg_Distance_Straight + waypoint36.Leg_Distance_Turn;
								num41 += waypoint36.Leg_Distance_Straight + waypoint36.Leg_Distance_Turn;
								num42 += waypoint36.Leg_Distance_Straight + waypoint36.Leg_Distance_Turn;
								num43 += waypoint36.Leg_Distance_Straight + waypoint36.Leg_Distance_Turn;
								goto IL_7b5d;
							}
							if (!Information.IsNothing(waypoint36.Waypoint_LeadElementWingman))
							{
								b = (byte?)useReplenishment;
								bool? flag8 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
								flag34 = (!flag8) ?? flag8;
								if (flag34.GetValueOrDefault(true))
								{
									b = (byte?)useReplenishment;
									bool? flag9;
									bool? flag10 = (flag9 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null));
									bool? flag11;
									flag9 = (flag11 = ((flag10.HasValue && !flag9.GetValueOrDefault()) ? new bool?(false) : (Information.IsNothing(useUnderwayRefuelAndReplenishment) ? new bool?(false) : flag9)));
									bool? flag13;
									if (flag9.HasValue && !flag11.GetValueOrDefault())
									{
										flag13 = false;
									}
									else
									{
										b = (byte?)useUnderwayRefuelAndReplenishment;
										bool? flag14;
										flag9 = (flag14 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null));
										flag13 = ((!flag9.HasValue) ? null : (flag14.GetValueOrDefault() & flag11));
									}
									flag8 = flag13;
									if (((!flag8) ?? flag8).GetValueOrDefault() && flag34.HasValue)
									{
										goto IL_773c;
									}
								}
								if (float_1 == float.MaxValue)
								{
									goto IL_773c;
								}
								num33 -= waypoint36.Waypoint_LeadElementWingman.Leg_FuelRequired;
								goto IL_7780;
							}
							goto IL_80c6;
						}
						goto IL_84f0;
					}
					if (waypoint36.FlightFormation != Waypoint.Formation.Split && (Information.IsNothing(waypoint37) || waypoint37.FlightFormation != Waypoint.Formation.Split))
					{
						num33 = ((waypoint36.Leg_FuelRemaining == float_1 || float_1 == float.MaxValue) ? float_1 : (num33 - waypoint36.Leg_FuelRequired));
						num35 = ((waypoint36.Leg_FuelRemaining == float_1 || float_1 == float.MaxValue) ? float_1 : (num35 - waypoint36.Leg_FuelRequired));
						num39 += waypoint36.Leg_Distance_Straight + waypoint36.Leg_Distance_Turn;
						num40 += waypoint36.Leg_Distance_Straight + waypoint36.Leg_Distance_Turn;
						goto IL_6f4d;
					}
					if (!Information.IsNothing(waypoint36.Waypoint_LeadElementWingman))
					{
						b = (byte?)useReplenishment;
						bool? flag15 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
						flag34 = (!flag15) ?? flag15;
						if (flag34.GetValueOrDefault(true))
						{
							b = (byte?)useReplenishment;
							bool? flag16;
							bool? flag17 = (flag16 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null));
							bool? flag18;
							flag16 = (flag18 = ((flag17.HasValue && !flag16.GetValueOrDefault()) ? new bool?(false) : (Information.IsNothing(useUnderwayRefuelAndReplenishment) ? new bool?(false) : flag16)));
							bool? flag19;
							if (flag16.HasValue && !flag18.GetValueOrDefault())
							{
								flag19 = false;
							}
							else
							{
								b = (byte?)useUnderwayRefuelAndReplenishment;
								bool? flag20;
								flag16 = (flag20 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null));
								flag19 = ((!flag16.HasValue) ? null : (flag20.GetValueOrDefault() & flag18));
							}
							flag15 = flag19;
							if (((!flag15) ?? flag15).GetValueOrDefault() && flag34.HasValue)
							{
								goto IL_7c7a;
							}
						}
						if (float_1 == float.MaxValue)
						{
							goto IL_7c7a;
						}
						num33 -= waypoint36.Waypoint_LeadElementWingman.Leg_FuelRequired;
						goto IL_7361;
					}
					goto IL_738a;
					IL_7c73:
					num36 = float_1;
					goto IL_7c1b;
					IL_7c8e:
					num35 = float_1;
					goto IL_8477;
					IL_7743:
					num35 = float_1;
					goto IL_7c98;
					IL_84f0:
					b = (byte?)useReplenishment;
					flag34 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null);
					if (((!flag34) ?? flag34).GetValueOrDefault())
					{
						useUnderwayRefuelAndReplenishment = useReplenishment;
					}
					goto end_IL_5b28;
					IL_7bef:
					num43 += waypoint36.Waypoint_ThirdElementWingman.Leg_Distance_Straight + waypoint36.Waypoint_ThirdElementWingman.Leg_Distance_Turn;
					goto IL_7b5d;
					IL_738a:
					if (!Information.IsNothing(waypoint36.Waypoint_SecondElement))
					{
						b = (byte?)useReplenishment;
						bool? flag28 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
						flag34 = (!flag28) ?? flag28;
						if (flag34.GetValueOrDefault(true))
						{
							b = (byte?)useReplenishment;
							bool? flag29;
							bool? flag30 = (flag29 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null));
							bool? flag31;
							flag29 = (flag31 = ((flag30.HasValue && !flag29.GetValueOrDefault()) ? new bool?(false) : (Information.IsNothing(useUnderwayRefuelAndReplenishment) ? new bool?(false) : flag29)));
							bool? flag32;
							if (flag29.HasValue && !flag31.GetValueOrDefault())
							{
								flag32 = false;
							}
							else
							{
								b = (byte?)useUnderwayRefuelAndReplenishment;
								bool? flag33;
								flag29 = (flag33 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null));
								flag32 = ((!flag29.HasValue) ? null : (flag33.GetValueOrDefault() & flag31));
							}
							flag28 = flag32;
							if (((!flag28) ?? flag28).GetValueOrDefault() && flag34.HasValue)
							{
								goto IL_7743;
							}
						}
						if (float_1 == float.MaxValue)
						{
							goto IL_7743;
						}
						num35 -= waypoint36.Waypoint_SecondElement.Leg_FuelRequired;
						goto IL_7c98;
					}
					goto IL_6f4d;
					IL_6f21:
					num39 += waypoint36.Waypoint_LeadElementWingman.Leg_Distance_Straight + waypoint36.Waypoint_LeadElementWingman.Leg_Distance_Turn;
					goto IL_899a;
					IL_7cc4:
					if (!Information.IsNothing(waypoint36.Waypoint_SecondElementWingman))
					{
						b = (byte?)useReplenishment;
						bool? flag41 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
						flag34 = (!flag41) ?? flag41;
						if (flag34.GetValueOrDefault(true))
						{
							b = (byte?)useReplenishment;
							bool? flag42;
							bool? flag43 = (flag42 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null));
							bool? flag44;
							flag42 = (flag44 = ((flag43.HasValue && !flag42.GetValueOrDefault()) ? new bool?(false) : (Information.IsNothing(useUnderwayRefuelAndReplenishment) ? new bool?(false) : flag42)));
							bool? flag46;
							if (flag42.HasValue && !flag44.GetValueOrDefault())
							{
								flag46 = false;
							}
							else
							{
								b = (byte?)useUnderwayRefuelAndReplenishment;
								bool? flag47;
								flag42 = (flag47 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null));
								flag46 = ((!flag42.HasValue) ? null : (flag47.GetValueOrDefault() & flag44));
							}
							flag41 = flag46;
							if (((!flag41) ?? flag41).GetValueOrDefault() && flag34.HasValue)
							{
								goto IL_7c73;
							}
						}
						if (float_1 == float.MaxValue)
						{
							goto IL_7c73;
						}
						num36 -= waypoint36.Waypoint_SecondElementWingman.Leg_FuelRequired;
						goto IL_7c1b;
					}
					goto IL_8072;
					IL_77ac:
					if (!Information.IsNothing(waypoint36.Waypoint_SecondElementWingman))
					{
						b = (byte?)useReplenishment;
						bool? flag35 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
						flag34 = (!flag35) ?? flag35;
						if (flag34.GetValueOrDefault(true))
						{
							b = (byte?)useReplenishment;
							bool? flag36;
							bool? flag37 = (flag36 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null));
							bool? flag38;
							flag36 = (flag38 = ((flag37.HasValue && !flag36.GetValueOrDefault()) ? new bool?(false) : (Information.IsNothing(useUnderwayRefuelAndReplenishment) ? new bool?(false) : flag36)));
							bool? flag39;
							if (flag36.HasValue && !flag38.GetValueOrDefault())
							{
								flag39 = false;
							}
							else
							{
								b = (byte?)useUnderwayRefuelAndReplenishment;
								bool? flag40;
								flag36 = (flag40 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null));
								flag39 = ((!flag36.HasValue) ? null : (flag40.GetValueOrDefault() & flag38));
							}
							flag35 = flag39;
							if (((!flag35) ?? flag35).GetValueOrDefault() && flag34.HasValue)
							{
								goto IL_6f17;
							}
						}
						if (float_1 == float.MaxValue)
						{
							goto IL_6f17;
						}
						num36 -= waypoint36.Waypoint_SecondElementWingman.Leg_FuelRequired;
						goto IL_7c47;
					}
					goto IL_6f87;
					IL_80c6:
					if (!Information.IsNothing(waypoint36.Waypoint_SecondElement))
					{
						b = (byte?)useReplenishment;
						bool? flag48 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
						flag34 = (!flag48) ?? flag48;
						if (flag34.GetValueOrDefault(true))
						{
							b = (byte?)useReplenishment;
							bool? flag49;
							bool? flag50 = (flag49 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null));
							bool? flag51;
							flag49 = (flag51 = ((flag50.HasValue && !flag49.GetValueOrDefault()) ? new bool?(false) : (Information.IsNothing(useUnderwayRefuelAndReplenishment) ? new bool?(false) : flag49)));
							bool? flag52;
							if (flag49.HasValue && !flag51.GetValueOrDefault())
							{
								flag52 = false;
							}
							else
							{
								b = (byte?)useUnderwayRefuelAndReplenishment;
								bool? flag53;
								flag49 = (flag53 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null));
								flag52 = ((!flag49.HasValue) ? null : (flag53.GetValueOrDefault() & flag51));
							}
							flag48 = flag52;
							if (((!flag48) ?? flag48).GetValueOrDefault() && flag34.HasValue)
							{
								goto IL_7735;
							}
						}
						if (float_1 == float.MaxValue)
						{
							goto IL_7735;
						}
						num35 -= waypoint36.Waypoint_SecondElement.Leg_FuelRequired;
						goto IL_774d;
					}
					goto IL_77ac;
					IL_7be5:
					num33 = float_1;
					goto IL_6f21;
					IL_8477:
					num40 += waypoint36.Waypoint_SecondElement.Leg_Distance_Straight + waypoint36.Waypoint_SecondElement.Leg_Distance_Turn;
					goto IL_7cc4;
					IL_7c47:
					num41 += waypoint36.Waypoint_SecondElementWingman.Leg_Distance_Straight + waypoint36.Waypoint_SecondElementWingman.Leg_Distance_Turn;
					goto IL_6f87;
					IL_7c7a:
					num33 = float_1;
					goto IL_7361;
					IL_8072:
					waypoint36.Leg_FuelRemaining_LeadElementWingman = num33;
					waypoint36.Leg_FuelRemaining_SecondElement = num35;
					waypoint36.Leg_FuelRemaining_SecondElementWingman = num36;
					waypoint36.Leg_TotalDistance_LeadElementWingman = num39;
					waypoint36.Leg_TotalDistance_SecondElement = num40;
					waypoint36.Leg_TotalDistance_SecondElementWingman = num41;
					goto IL_84f0;
					IL_6f17:
					num36 = float_1;
					goto IL_7c47;
					IL_7776:
					num38 = float_1;
					goto IL_7bef;
					IL_7b5d:
					waypoint36.Leg_FuelRemaining_LeadElementWingman = num33;
					waypoint36.Leg_FuelRemaining_SecondElement = num35;
					waypoint36.Leg_FuelRemaining_SecondElementWingman = num36;
					waypoint36.Leg_FuelRemaining_ThirdElement = num37;
					waypoint36.Leg_FuelRemaining_ThirdElementWingman = num38;
					waypoint36.Leg_TotalDistance_LeadElementWingman = num39;
					waypoint36.Leg_TotalDistance_SecondElement = num40;
					waypoint36.Leg_TotalDistance_SecondElementWingman = num41;
					waypoint36.Leg_TotalDistance_ThirdElement = num42;
					waypoint36.Leg_TotalDistance_ThirdElementWingman = num43;
					goto IL_84f0;
					IL_7361:
					num39 += waypoint36.Waypoint_LeadElementWingman.Leg_Distance_Straight + waypoint36.Waypoint_LeadElementWingman.Leg_Distance_Turn;
					goto IL_738a;
					IL_773c:
					num33 = float_1;
					goto IL_7780;
					IL_7c84:
					num37 = float_1;
					goto IL_7335;
					IL_85e9:
					if (!Information.IsNothing(waypoint36.Waypoint_ThirdElementWingman))
					{
						b = (byte?)useReplenishment;
						bool? flag54 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
						flag34 = (!flag54) ?? flag54;
						if (flag34.GetValueOrDefault(true))
						{
							b = (byte?)useReplenishment;
							bool? flag55;
							bool? flag57 = (flag55 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null));
							bool? flag58;
							flag55 = (flag58 = ((flag57.HasValue && !flag55.GetValueOrDefault()) ? new bool?(false) : (Information.IsNothing(useUnderwayRefuelAndReplenishment) ? new bool?(false) : flag55)));
							bool? flag59;
							if (flag55.HasValue && !flag58.GetValueOrDefault())
							{
								flag59 = false;
							}
							else
							{
								b = (byte?)useUnderwayRefuelAndReplenishment;
								bool? flag60;
								flag55 = (flag60 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null));
								flag59 = ((!flag55.HasValue) ? null : (flag60.GetValueOrDefault() & flag58));
							}
							flag54 = flag59;
							if (((!flag54) ?? flag54).GetValueOrDefault() && flag34.HasValue)
							{
								goto IL_7776;
							}
						}
						if (float_1 == float.MaxValue)
						{
							goto IL_7776;
						}
						num38 -= waypoint36.Waypoint_ThirdElementWingman.Leg_FuelRequired;
						goto IL_7bef;
					}
					goto IL_7b5d;
					IL_84a3:
					num39 += waypoint36.Waypoint_LeadElementWingman.Leg_Distance_Straight + waypoint36.Waypoint_LeadElementWingman.Leg_Distance_Turn;
					goto IL_84cc;
					IL_6f87:
					if (!Information.IsNothing(waypoint36.Waypoint_ThirdElement))
					{
						b = (byte?)useReplenishment;
						bool? flag21 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
						flag34 = (!flag21) ?? flag21;
						if (flag34.GetValueOrDefault(true))
						{
							b = (byte?)useReplenishment;
							bool? flag22;
							bool? flag24 = (flag22 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null));
							bool? flag25;
							flag22 = (flag25 = ((flag24.HasValue && !flag22.GetValueOrDefault()) ? new bool?(false) : (Information.IsNothing(useUnderwayRefuelAndReplenishment) ? new bool?(false) : flag22)));
							bool? flag26;
							if (flag22.HasValue && !flag25.GetValueOrDefault())
							{
								flag26 = false;
							}
							else
							{
								b = (byte?)useUnderwayRefuelAndReplenishment;
								bool? flag27;
								flag22 = (flag27 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null));
								flag26 = ((!flag22.HasValue) ? null : (flag27.GetValueOrDefault() & flag25));
							}
							flag21 = flag26;
							if (((!flag21) ?? flag21).GetValueOrDefault() && flag34.HasValue)
							{
								goto IL_7c84;
							}
						}
						if (float_1 == float.MaxValue)
						{
							goto IL_7c84;
						}
						num37 -= waypoint36.Waypoint_ThirdElement.Leg_FuelRequired;
						goto IL_7335;
					}
					goto IL_85e9;
					IL_774d:
					num40 += waypoint36.Waypoint_SecondElement.Leg_Distance_Straight + waypoint36.Waypoint_SecondElement.Leg_Distance_Turn;
					goto IL_77ac;
					IL_6f4d:
					waypoint36.Leg_FuelRemaining_LeadElementWingman = num33;
					waypoint36.Leg_FuelRemaining_SecondElement = num35;
					waypoint36.Leg_TotalDistance_LeadElementWingman = num39;
					waypoint36.Leg_TotalDistance_SecondElement = num40;
					goto IL_84f0;
					IL_7780:
					num39 += waypoint36.Waypoint_LeadElementWingman.Leg_Distance_Straight + waypoint36.Waypoint_LeadElementWingman.Leg_Distance_Turn;
					goto IL_80c6;
					IL_7735:
					num35 = float_1;
					goto IL_774d;
					IL_84e9:
					num33 = float_1;
					goto IL_84a3;
					IL_899a:
					if (!Information.IsNothing(waypoint36.Waypoint_SecondElement))
					{
						b = (byte?)useReplenishment;
						bool? flag61 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
						flag34 = (!flag61) ?? flag61;
						if (flag34.GetValueOrDefault(true))
						{
							b = (byte?)useReplenishment;
							bool? flag62;
							bool? flag63 = (flag62 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null));
							bool? flag64;
							flag62 = (flag64 = ((flag63.HasValue && !flag62.GetValueOrDefault()) ? new bool?(false) : (Information.IsNothing(useUnderwayRefuelAndReplenishment) ? new bool?(false) : flag62)));
							bool? flag65;
							if (flag62.HasValue && !flag64.GetValueOrDefault())
							{
								flag65 = false;
							}
							else
							{
								b = (byte?)useUnderwayRefuelAndReplenishment;
								bool? flag66;
								flag62 = (flag66 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null));
								flag65 = ((!flag62.HasValue) ? null : (flag66.GetValueOrDefault() & flag64));
							}
							flag61 = flag65;
							if (((!flag61) ?? flag61).GetValueOrDefault() && flag34.HasValue)
							{
								goto IL_7c8e;
							}
						}
						if (float_1 == float.MaxValue)
						{
							goto IL_7c8e;
						}
						num35 -= waypoint36.Waypoint_SecondElement.Leg_FuelRequired;
						goto IL_8477;
					}
					goto IL_7cc4;
					IL_7c98:
					num40 += waypoint36.Waypoint_SecondElement.Leg_Distance_Straight + waypoint36.Waypoint_SecondElement.Leg_Distance_Turn;
					goto IL_6f4d;
					IL_7c1b:
					num41 += waypoint36.Waypoint_SecondElementWingman.Leg_Distance_Straight + waypoint36.Waypoint_SecondElementWingman.Leg_Distance_Turn;
					goto IL_8072;
					IL_84cc:
					waypoint36.Leg_FuelRemaining_LeadElementWingman = num33;
					waypoint36.Leg_TotalDistance_LeadElementWingman = num39;
					goto IL_84f0;
					IL_7335:
					num42 += waypoint36.Waypoint_ThirdElement.Leg_Distance_Straight + waypoint36.Waypoint_ThirdElement.Leg_Distance_Turn;
					goto IL_85e9;
					end_IL_5b28:;
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception exception_3 = ex3;
					exception_3?.Data.Add("Error at 999999", "");
					GameGeneral.WriteExceptionsToLog(ref exception_3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (!bool_0)
			{
				return;
			}
			try
			{
				if (mission is Strike { AttackMethod: not Mission._AttackMethod.BananaSplit })
				{
					return;
				}
				int num47 = waypoint_0.Count() - 1;
				for (int num48 = 0; num48 <= num47; num48++)
				{
					Waypoint waypoint38 = waypoint_0[num48];
					if (!Information.IsNothing(waypoint38) && (waypoint38.Type == Waypoint.WaypointType.Target || waypoint38.Type == Waypoint.WaypointType.WeaponTarget))
					{
						if (!Information.IsNothing(waypoint38.Waypoint_LeadElementWingman) && !Information.IsNothing(waypoint38.Waypoint_LeadElementWingman.Time_Zulu) && waypoint38.TimeFixed == Waypoint.FixedFree.Fixed)
						{
							waypoint38.Waypoint_LeadElementWingman.TimeFixed = Waypoint.FixedFree.Relative;
							DetermineBoundSpeedsAndTimes(ref waypoint_3, bool_0: true);
						}
						if (!Information.IsNothing(waypoint38.Waypoint_SecondElement) && !Information.IsNothing(waypoint38.Waypoint_SecondElement.Time_Zulu) && waypoint38.TimeFixed == Waypoint.FixedFree.Fixed)
						{
							waypoint38.Waypoint_SecondElement.TimeFixed = Waypoint.FixedFree.Relative;
							DetermineBoundSpeedsAndTimes(ref waypoint_4, bool_0: true);
						}
						if (!Information.IsNothing(waypoint38.Waypoint_SecondElementWingman) && !Information.IsNothing(waypoint38.Waypoint_SecondElementWingman.Time_Zulu) && waypoint38.TimeFixed == Waypoint.FixedFree.Fixed)
						{
							waypoint38.Waypoint_SecondElementWingman.TimeFixed = Waypoint.FixedFree.Relative;
							DetermineBoundSpeedsAndTimes(ref waypoint_5, bool_0: true);
						}
						if (!Information.IsNothing(waypoint38.Waypoint_ThirdElement) && !Information.IsNothing(waypoint38.Waypoint_ThirdElement.Time_Zulu) && waypoint38.TimeFixed == Waypoint.FixedFree.Fixed)
						{
							waypoint38.Waypoint_ThirdElement.TimeFixed = Waypoint.FixedFree.Relative;
							DetermineBoundSpeedsAndTimes(ref waypoint_6, bool_0: true);
						}
						if (!Information.IsNothing(waypoint38.Waypoint_ThirdElementWingman) && !Information.IsNothing(waypoint38.Waypoint_ThirdElementWingman.Time_Zulu) && waypoint38.TimeFixed == Waypoint.FixedFree.Fixed)
						{
							waypoint38.Waypoint_ThirdElementWingman.TimeFixed = Waypoint.FixedFree.Relative;
							DetermineBoundSpeedsAndTimes(ref waypoint_7, bool_0: true);
						}
						break;
					}
				}
			}
			catch (Exception ex4)
			{
				ProjectData.SetProjectError(ex4);
				Exception exception_4 = ex4;
				exception_4?.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ref exception_4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception exception_5 = ex5;
			exception_5?.Data.Add("Error at 200618", "");
			GameGeneral.WriteExceptionsToLog(ref exception_5);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void CallTokenizer(ref Scenario scenario_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Waypoint[] waypoint_0, ref Waypoint[] waypoint_1, ref ActiveUnit activeUnit_0, float float_0, ref bool bool_0, ref float float_1, bool bool_1, string string_0, Mission.Flight.FlightElement flightElement_0)
	{
		try
		{
			ResetWaypointBoundTimes(ref waypoint_0, ref activeUnit_0, bool_0: true);
			DetermineDistanceFlown(waypoint_0, waypoint_1, ref flight_0, ref float_0, bool_0: true, string_0);
			if (ComputeTokenizer(ref activeUnit_0, ref waypoint_0, ref waypoint_1, bool_0: true, ref flight_0, string_0))
			{
				for (int i = 0; i <= 10; i++)
				{
					DetermineDistanceFlown(waypoint_0, waypoint_1, ref flight_0, ref float_0, bool_0: true, string_0);
					if (!ComputeTokenizer(ref activeUnit_0, ref waypoint_0, ref waypoint_1, bool_0: true, ref flight_0, string_0))
					{
						break;
					}
				}
			}
			float float_2 = 0f;
			DetermineTimesAndFuelQty(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref activeUnit_0, ref float_2, ref float_1, ref bool_0, bool_1: true, bool_1, string_0, bool_3: false);
			ActiveUnit obj = activeUnit_0;
			Side side_ = obj.GetUnitSide();
			CalculateFuelQtyAndTimesForWeaponRoutes(ref scenario_0, ref side_, bool_0: true, bool_1: true, ref flight_0, "", ref activeUnit_0, flightElement_0);
			obj.SetUnitSide(bool_0: false, side_);
			DetermineWaypointZuluTimes(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref activeUnit_0, bool_0: true, bool_1, bool_2: false, null, null, flightElement_0);
			DetermineBoundSpeedsAndTimes(ref waypoint_0, bool_0: true);
			DetermineLocalTimeForWaypoints(ref scenario_0, ref waypoint_0, bool_0: true);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101398", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void LogoutTokenizer()
	{
	}

	private static void ViewTokenizer(ref Scenario scenario_0, ref Mission mission_0, ref Mission.Flight flight_0, ref ActiveUnit activeUnit_0, ref Waypoint waypoint_0, ref Waypoint waypoint_1, ref Waypoint waypoint_2, ref Waypoint waypoint_3, ref Waypoint waypoint_4, ref Waypoint waypoint_5, ref Waypoint waypoint_6, ref Waypoint waypoint_7, ref Waypoint waypoint_8, ref Waypoint waypoint_9, ref Waypoint waypoint_10, ref Waypoint waypoint_11, ref Waypoint waypoint_12, Misc.TurnDirection turnDirection_0, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, int int_0, int int_1, int int_2, ref int? nullable_0, float float_6, bool bool_0, bool bool_1, bool bool_2, ref string string_0)
	{
		try
		{
			bool flag = false;
			float num = 0f;
			float num12 = int_0;
			double latitude = waypoint_3.Latitude;
			double longitude = waypoint_3.Longitude;
			double latitude2 = waypoint_5.Latitude;
			double longitude2 = waypoint_5.Longitude;
			float num17 = float.MaxValue;
			float num18 = float.MaxValue;
			float num19 = 45f;
			bool flag2 = false;
			int num20 = 10;
			int num21 = 0;
			float num22 = Math2.PublishClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_7.Latitude, waypoint_7.Longitude);
			float num23 = (Information.IsNothing(nullable_0) ? num22 : ((float)nullable_0.Value));
			float float_7 = 0f;
			Waypoint waypoint_13 = null;
			Waypoint waypoint_14 = null;
			Waypoint waypoint = null;
			float float_8 = 0f;
			List<Waypoint.FlightPlanSegment> list_ = null;
			List<Waypoint.FlightPlanSegment> list_2 = null;
			List<Waypoint.FlightPlanSegment> list_3 = null;
			bool bool_3 = false;
			while (true)
			{
				num12 += (float)int_2;
				num23 = Math2.UpdateClass(num23 + (float)int_2);
				if (!flag2)
				{
					double longitude3 = waypoint_1.Longitude;
					double latitude3 = waypoint_1.Latitude;
					Waypoint obj = waypoint_3;
					double double_ = obj.Longitude;
					Waypoint obj2 = waypoint_3;
					double double_2 = obj2.Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude3, latitude3, ref double_, ref double_2, float_2, num23);
					obj2.Latitude = double_2;
					obj.Longitude = double_;
				}
				if (Math2.VerifyClass(waypoint_3.Latitude, waypoint_3.Longitude, waypoint_7.Latitude, waypoint_7.Longitude) <= float_3)
				{
					flag = true;
				}
				if (!flag)
				{
					float_7 = float_0;
					waypoint_13 = waypoint_3;
					waypoint_14 = waypoint_1;
					waypoint = waypoint_0;
					float_8 = waypoint_14.ActualSpeed;
					float actualSpeed = waypoint.ActualSpeed;
					list_ = new List<Waypoint.FlightPlanSegment>();
					list_2 = new List<Waypoint.FlightPlanSegment>();
					list_3 = new List<Waypoint.FlightPlanSegment>();
					float num2 = num23;
					Misc.TurnDirection turnDirection = Misc.CountValue(float_7, num2);
					switch (turnDirection)
					{
					case Misc.TurnDirection.TurnRight:
						float_6 = 9f;
						break;
					case Misc.TurnDirection.TurnLeft:
						float_6 = -9f;
						break;
					}
					Waypoint waypoint_15 = null;
					CreateFlightPlanCurve(ref float_7, ref list_, ref waypoint_13, ref waypoint_14, ref waypoint_15, ref float_8, actualSpeed, ref flight_0, float_6, turnDirection, num2, ref bool_3, bool_1: true, string_0, null);
					if (!bool_3)
					{
						waypoint_13 = waypoint_5;
						waypoint_14 = waypoint_3;
						waypoint = waypoint_1;
						float_8 = waypoint_14.ActualSpeed;
						actualSpeed = waypoint.ActualSpeed;
						Waypoint waypoint2;
						if (!flag2)
						{
							double longitude4 = waypoint_6.Longitude;
							double latitude4 = waypoint_6.Latitude;
							double double_3 = (waypoint_15 = waypoint_13).Longitude;
							double double_4 = (waypoint2 = waypoint_13).Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(longitude4, latitude4, ref double_3, ref double_4, float_3, Math2.UpdateClass(num2 + 180f));
							waypoint2.Latitude = double_4;
							waypoint_15.Longitude = double_3;
						}
						num2 = Math2.PublishClass(waypoint_14.Latitude, waypoint_14.Longitude, waypoint_13.Latitude, waypoint_13.Longitude);
						float num3 = float_7;
						turnDirection = Misc.CountValue(float_7, num2);
						switch (turnDirection)
						{
						case Misc.TurnDirection.TurnRight:
							float_6 = 9f;
							break;
						case Misc.TurnDirection.TurnLeft:
							float_6 = -9f;
							break;
						}
						waypoint2 = null;
						CreateFlightPlanCurve(ref float_7, ref list_2, ref waypoint_13, ref waypoint_14, ref waypoint2, ref float_8, actualSpeed, ref flight_0, float_6, turnDirection, num2, ref bool_3, bool_1: true, string_0, null);
						if (!flag2 && (bool_3 || list_2.Count > 1))
						{
							num2 = Math2.PublishClass(waypoint_14.Latitude, waypoint_14.Longitude, waypoint_7.Latitude, waypoint_7.Longitude);
							float_7 = num3;
							turnDirection = Misc.CountValue(float_7, num2);
							switch (turnDirection)
							{
							case Misc.TurnDirection.TurnRight:
								float_6 = 9f;
								break;
							case Misc.TurnDirection.TurnLeft:
								float_6 = -9f;
								break;
							}
							list_2 = new List<Waypoint.FlightPlanSegment>();
							waypoint2 = null;
							CreateFlightPlanCurve(ref float_7, ref list_2, ref waypoint_7, ref waypoint_14, ref waypoint2, ref float_8, actualSpeed, ref flight_0, float_6, turnDirection, num2, ref bool_3, bool_1: true, string_0, null);
							if (!bool_3 && list_2.Count > 1)
							{
								float num4 = Math2.VerifyClass(waypoint_7.Latitude, waypoint_7.Longitude, list_2[list_2.Count - 1].StartLatitude, list_2[list_2.Count - 1].StartLongitude);
								float num5 = ActiveUnit_Kinematics.TurnRateCategoryToActualTurnRate(waypoint_14.TurnRate_Navigation, actualSpeed);
								float num6 = Math.Abs(float_6) / num5;
								float num7 = actualSpeed / 3600f * num6;
								num4 -= 3f * num7;
								if (num4 <= 0f)
								{
									bool_3 = true;
								}
								else
								{
									float float_9 = Math2.PublishClass(waypoint_6.Latitude, waypoint_6.Longitude, list_2[list_2.Count - 1].StartLatitude, list_2[list_2.Count - 1].StartLongitude);
									if (num4 <= float_3)
									{
										double longitude5 = waypoint_6.Longitude;
										double latitude5 = waypoint_6.Latitude;
										double double_5 = (waypoint_15 = waypoint_13).Longitude;
										double double_6 = (waypoint2 = waypoint_13).Latitude;
										Geodesic_EdWilliams.CalcPoint_Williams(longitude5, latitude5, ref double_5, ref double_6, num4, float_9);
										waypoint2.Latitude = double_6;
										waypoint_15.Longitude = double_5;
									}
									else
									{
										double longitude6 = waypoint_6.Longitude;
										double latitude6 = waypoint_6.Latitude;
										double double_7 = (waypoint2 = waypoint_13).Longitude;
										double double_8 = (waypoint_15 = waypoint_13).Latitude;
										Geodesic_EdWilliams.CalcPoint_Williams(longitude6, latitude6, ref double_7, ref double_8, float_3, float_9);
										waypoint_15.Latitude = double_8;
										waypoint2.Longitude = double_7;
									}
									num2 = Math2.PublishClass(waypoint_14.Latitude, waypoint_14.Longitude, waypoint_13.Latitude, waypoint_13.Longitude);
									float_7 = num3;
									turnDirection = Misc.CountValue(float_7, num2);
									switch (turnDirection)
									{
									case Misc.TurnDirection.TurnRight:
										float_6 = 9f;
										break;
									case Misc.TurnDirection.TurnLeft:
										float_6 = -9f;
										break;
									}
									list_2 = new List<Waypoint.FlightPlanSegment>();
									waypoint2 = null;
									CreateFlightPlanCurve(ref float_7, ref list_2, ref waypoint_13, ref waypoint_14, ref waypoint2, ref float_8, actualSpeed, ref flight_0, float_6, turnDirection, num2, ref bool_3, bool_1: true, string_0, null);
								}
							}
						}
					}
				}
				if (!bool_3 && !flag)
				{
					waypoint_13 = waypoint_7;
					waypoint_14 = waypoint_5;
					waypoint = waypoint_3;
					float_8 = waypoint_14.ActualSpeed;
					float actualSpeed2 = waypoint.ActualSpeed;
					float num8 = Math2.PublishClass(waypoint_14.Latitude, waypoint_14.Longitude, waypoint_13.Latitude, waypoint_13.Longitude);
					Misc.TurnDirection turnDirection2 = Misc.CountValue(float_7, num8);
					switch (turnDirection2)
					{
					case Misc.TurnDirection.TurnRight:
						float_6 = 9f;
						break;
					case Misc.TurnDirection.TurnLeft:
						float_6 = -9f;
						break;
					}
					Waypoint waypoint_16 = null;
					CreateFlightPlanCurve(ref float_7, ref list_3, ref waypoint_13, ref waypoint_14, ref waypoint_16, ref float_8, actualSpeed2, ref flight_0, float_6, turnDirection2, num8, ref bool_3, bool_1: true, string_0, null);
				}
				float num9 = ((bool_3 || flag) ? 0f : (waypoint.Leg_Time_Straight + waypoint.Leg_Time_Turn + waypoint_14.Leg_Time_Straight + waypoint_14.Leg_Time_Turn + waypoint_13.Leg_Time_Straight + waypoint_13.Leg_Time_Turn));
				if (flag2 || (!bool_3 && !flag && (double)Math.Abs(num9 - float_4) < 0.5))
				{
					break;
				}
				bool flag3 = ((!(bool_3 || flag) && !(num9 <= float_4) && !((double)Math.Abs(num9 - float_4) <= 0.5)) ? true : false);
				if (!bool_3 && !flag)
				{
					if (num < num9)
					{
						num = num9;
					}
					if (Math.Abs(float_4 - num9) < num17)
					{
						latitude = waypoint_3.Latitude;
						longitude = waypoint_3.Longitude;
						latitude2 = waypoint_5.Latitude;
						longitude2 = waypoint_5.Longitude;
						num17 = Math.Abs(num9 - float_4);
					}
					if (Math.Abs(float_4 - num9) < Math.Abs(num18))
					{
						num18 = float_4 - num9;
					}
				}
				if (num12 == (float)int_1)
				{
					if (num18 == float.MaxValue)
					{
						if (float_2 > 5f)
						{
							float_2 = (float)((double)float_2 * 0.5);
						}
						num12 = int_0;
						num = 0f;
						num18 = float.MaxValue;
						num23 = (Information.IsNothing(nullable_0) ? num22 : ((float)nullable_0.Value));
						num21++;
						if (num21 > num20 || float_2 < 0f)
						{
							flag2 = true;
							waypoint_3.Latitude = latitude;
							waypoint_3.Longitude = longitude;
							waypoint_5.Latitude = latitude2;
							waypoint_5.Longitude = longitude2;
						}
					}
					else
					{
						float num10 = Math.Abs(num18);
						float num11 = ((num10 < 5f) ? 0.98f : ((num10 < 15f) ? 0.85f : ((num10 < 30f) ? 0.75f : 0.7f)));
						float_2 += num18 * float_8 / 3600f * num11;
						num12 = int_0;
						num = 0f;
						num18 = float.MaxValue;
						num23 = (Information.IsNothing(nullable_0) ? num22 : ((float)nullable_0.Value));
						num21++;
						if (num21 > num20 || float_2 < 0f)
						{
							flag2 = true;
							waypoint_3.Latitude = latitude;
							waypoint_3.Longitude = longitude;
							waypoint_5.Latitude = latitude2;
							waypoint_5.Longitude = longitude2;
						}
					}
				}
				else if (num18 != float.MaxValue && !flag)
				{
					if (flag3)
					{
						if (Math.Abs(MathFunctions.DeleteRequest(num12, int_0)) > num19)
						{
							float num13 = Math.Abs(num18);
							float num14 = ((num13 < 5f) ? 0.9f : ((num13 < 15f) ? 0.85f : ((num13 < 30f) ? 0.8f : 0.7f)));
							float_2 += num18 * float_8 / 3600f * num14;
							num19 = Math.Abs(num12) + 15f;
							num12 = int_0;
							num = 0f;
							num18 = float.MaxValue;
							num23 = (Information.IsNothing(nullable_0) ? num22 : ((float)nullable_0.Value));
							num21++;
							if (num21 > num20 || float_2 < 0f)
							{
								flag2 = true;
								waypoint_3.Latitude = latitude;
								waypoint_3.Longitude = longitude;
								waypoint_5.Latitude = latitude2;
								waypoint_5.Longitude = longitude2;
							}
						}
					}
					else if (num > num9 && num < float_4 && Math.Abs(MathFunctions.DeleteRequest(num12, int_0)) > num19)
					{
						float num15 = Math.Abs(num18);
						float num16 = ((num15 < 5f) ? 1f : ((num15 < 15f) ? 0.9f : ((num15 < 30f) ? 0.8f : 0.7f)));
						float_2 += num18 * float_8 / 3600f * num16;
						num19 = Math.Abs(num12) + 15f;
						num12 = int_0;
						num = 0f;
						num18 = float.MaxValue;
						num23 = (Information.IsNothing(nullable_0) ? num22 : ((float)nullable_0.Value));
						num21++;
						if (num21 > num20 || float_2 < 0f)
						{
							flag2 = true;
							waypoint_3.Latitude = latitude;
							waypoint_3.Longitude = longitude;
							waypoint_5.Latitude = latitude2;
							waypoint_5.Longitude = longitude2;
						}
					}
				}
				if (!flag2)
				{
					flag = false;
					continue;
				}
				string text = "";
				if (Operators.CompareString(activeUnit_0.Name, activeUnit_0.UnitClass, TextCompare: false) != 0)
				{
					text = " (" + activeUnit_0.UnitClass + ")";
				}
				string text2 = ((mission_0.Category == Mission.MissionCategory.Package) ? "" : "任务");
				scenario_0.AddMessage(text2 + mission_0.Name + "飞机类型" + text + "其中一名僚机无法自动生成最佳的多方位时间目标（ToT）飞行计划" + string_0 + "。飞行计划已成功创建，但可能需要参演方注意。对于飞行编队分开的入口航段上的一个或多个航路点，僚机可能稍早或稍晚。", mission_0.Name + " needs extra attention", LoggedMessage.MessageType.AirOps, 15, activeUnit_0.ObjectID, activeUnit_0.GetUnitSide(), new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
				return;
			}
			waypoint.FlightplanPointsList = list_;
			waypoint_14.FlightplanPointsList = list_2;
			waypoint_13.FlightplanPointsList = list_3;
			nullable_0 = (int)Math.Round(Math2.PublishClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_3.Latitude, waypoint_3.Longitude));
			ValidateTokenizer(ref scenario_0, ref float_7, ref mission_0, ref flight_0, ref activeUnit_0, ref waypoint_5, ref waypoint_6, ref waypoint_7, ref waypoint_8, ref waypoint_9, ref waypoint_10, ref waypoint_11, ref waypoint_12, turnDirection_0, float_1, float_2, float_3, float_5, float_6, bool_0, bool_1, ref string_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200619", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void ValidateTokenizer(ref Scenario scenario_0, ref float float_0, ref Mission mission_0, ref Mission.Flight flight_0, ref ActiveUnit activeUnit_0, ref Waypoint waypoint_0, ref Waypoint waypoint_1, ref Waypoint waypoint_2, ref Waypoint waypoint_3, ref Waypoint waypoint_4, ref Waypoint waypoint_5, ref Waypoint waypoint_6, ref Waypoint waypoint_7, Misc.TurnDirection turnDirection_0, float float_1, float float_2, float float_3, float float_4, float float_5, bool bool_0, bool bool_1, ref string string_0)
	{
		try
		{
			bool bool_2 = false;
			bool flag = false;
			bool flag2 = false;
			float num = 0f;
			double latitude = waypoint_4.Latitude;
			double longitude = waypoint_4.Longitude;
			float num12 = float.MaxValue;
			float num23 = float.MaxValue;
			float num24 = 45f;
			bool flag3 = false;
			bool flag4 = false;
			if (float_1 <= 0f)
			{
				return;
			}
			Waypoint waypoint_10 = waypoint_4;
			Waypoint waypoint_11 = waypoint_2;
			Waypoint obj = waypoint_0;
			List<Waypoint.FlightPlanSegment> list_ = new List<Waypoint.FlightPlanSegment>();
			List<Waypoint.FlightPlanSegment> list_2 = new List<Waypoint.FlightPlanSegment>();
			float float_6 = waypoint_11.ActualSpeed;
			float actualSpeed = obj.ActualSpeed;
			float num25;
			float float_7;
			float float_8;
			if (float_3 < 6f)
			{
				num25 = Math2.PublishClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_5.Latitude, waypoint_5.Longitude);
				float_7 = Math2.PublishClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_7.Latitude, waypoint_7.Longitude);
				float_8 = Math2.PublishClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_3.Latitude, waypoint_3.Longitude);
			}
			else
			{
				num25 = Math2.PublishClass(waypoint_0.Latitude, waypoint_0.Longitude, waypoint_5.Latitude, waypoint_5.Longitude);
				float_7 = Math2.PublishClass(waypoint_0.Latitude, waypoint_0.Longitude, waypoint_7.Latitude, waypoint_7.Longitude);
				float_8 = Math2.PublishClass(waypoint_0.Latitude, waypoint_0.Longitude, waypoint_3.Latitude, waypoint_3.Longitude);
			}
			float num26 = Math.Abs(MathFunctions.DeleteRequest(num25, float_7));
			float num27 = float_0;
			int num28 = 0;
			int num29 = (int)Math.Round(Math.Abs(MathFunctions.DeleteRequest(float_8, num25)));
			int num2 = 0;
			if (bool_1)
			{
				num29 = 45;
			}
			else if (num29 - num28 < 45)
			{
				num29 = num28 + 45;
			}
			float num3;
			if (turnDirection_0 == Misc.TurnDirection.TurnRight)
			{
				if (bool_0)
				{
					num3 = 1f;
					if (bool_1)
					{
						num2 = -90;
					}
				}
				else
				{
					num28 = -num28;
					num29 = -num29;
					num3 = -1f;
					if (bool_1)
					{
						num2 = 90;
					}
				}
			}
			else if (bool_0)
			{
				num28 = -num28;
				num29 = -num29;
				num3 = -1f;
				if (bool_1)
				{
					num2 = 90;
				}
			}
			else
			{
				num3 = 1f;
				if (bool_1)
				{
					num2 = -90;
				}
			}
			float num4 = ((float_3 < 6f) ? Math2.VerifyClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_5.Latitude, waypoint_5.Longitude) : Math2.VerifyClass(waypoint_0.Latitude, waypoint_0.Longitude, waypoint_5.Latitude, waypoint_5.Longitude));
			float_2 = num4 - float_1;
			int num5 = 10;
			int num6 = 20;
			int num7 = 0;
			float num8 = Math2.UpdateClass(num25 + (float)num28 + (float)num2);
			float num9 = Math2.VerifyClass(waypoint_5.Latitude, waypoint_5.Longitude, waypoint_7.Latitude, waypoint_7.Longitude);
			float num10 = num28;
			float? num11 = null;
			while (true)
			{
				if (num7 < 10 && !flag3)
				{
					num10 += num3;
					num8 = Math2.UpdateClass(num8 + num3);
					if (float_3 < 6f)
					{
						double longitude2 = waypoint_1.Longitude;
						double latitude2 = waypoint_1.Latitude;
						Waypoint obj2 = waypoint_4;
						double double_ = obj2.Longitude;
						Waypoint obj3 = waypoint_4;
						double double_2 = obj3.Latitude;
						Geodesic_EdWilliams.CalcPoint_Williams(longitude2, latitude2, ref double_, ref double_2, float_2, num8);
						obj3.Latitude = double_2;
						obj2.Longitude = double_;
					}
					else
					{
						double longitude3 = waypoint_0.Longitude;
						double latitude3 = waypoint_0.Latitude;
						Waypoint obj4 = waypoint_4;
						double double_3 = obj4.Longitude;
						Waypoint obj5 = waypoint_4;
						double double_4 = obj5.Latitude;
						Geodesic_EdWilliams.CalcPoint_Williams(longitude3, latitude3, ref double_3, ref double_4, float_2, num8);
						obj5.Latitude = double_4;
						obj4.Longitude = double_3;
					}
					if (!flag2 && num26 <= 90f && Math2.VerifyClass(waypoint_4.Latitude, waypoint_4.Longitude, waypoint_7.Latitude, waypoint_7.Longitude) <= num9)
					{
						flag = true;
					}
					if (!flag2 && float_3 >= 6f && Math2.VerifyClass(waypoint_2.Latitude, waypoint_2.Longitude, waypoint_4.Latitude, waypoint_4.Longitude) - float_1 / 4f <= float_3)
					{
						flag = true;
					}
				}
				try
				{
					if (!flag)
					{
						float_0 = num27;
						waypoint_10 = waypoint_4;
						waypoint_11 = waypoint_2;
						Waypoint obj6 = waypoint_0;
						float_6 = waypoint_11.ActualSpeed;
						actualSpeed = obj6.ActualSpeed;
						list_ = new List<Waypoint.FlightPlanSegment>();
						list_2 = new List<Waypoint.FlightPlanSegment>();
						float num13;
						if (float_3 < 6f)
						{
							num13 = Math2.PublishClass(waypoint_11.Latitude, waypoint_11.Longitude, waypoint_10.Latitude, waypoint_10.Longitude);
						}
						else if (!Information.IsNothing(waypoint_11.FlightplanPointsList) && waypoint_11.FlightplanPointsList.Count > 0)
						{
							num13 = Math2.PublishClass(waypoint_11.FlightplanPointsList[waypoint_11.FlightplanPointsList.Count - 1].EndLatitude, waypoint_11.FlightplanPointsList[waypoint_11.FlightplanPointsList.Count - 1].EndLongitude, waypoint_10.Latitude, waypoint_10.Longitude);
						}
						else
						{
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							num13 = Math2.PublishClass(waypoint_11.Latitude, waypoint_11.Longitude, waypoint_10.Latitude, waypoint_10.Longitude);
						}
						Misc.TurnDirection turnDirection = Misc.CountValue(float_0, num13);
						switch (turnDirection)
						{
						case Misc.TurnDirection.TurnRight:
							float_5 = 9f;
							break;
						case Misc.TurnDirection.TurnLeft:
							float_5 = -9f;
							break;
						}
						Waypoint waypoint_8 = null;
						CreateFlightPlanCurve(ref float_0, ref list_, ref waypoint_10, ref waypoint_11, ref waypoint_8, ref float_6, actualSpeed, ref flight_0, float_5, turnDirection, num13, ref bool_2, bool_1: true, string_0, null);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 999999", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				try
				{
					if (!bool_2 && !flag)
					{
						waypoint_10 = waypoint_6;
						waypoint_11 = waypoint_4;
						Waypoint obj7 = waypoint_2;
						float_6 = waypoint_11.ActualSpeed;
						actualSpeed = obj7.ActualSpeed;
						float num14 = Math2.PublishClass(waypoint_11.Latitude, waypoint_11.Longitude, waypoint_10.Latitude, waypoint_10.Longitude);
						Misc.TurnDirection turnDirection2 = Misc.CountValue(float_0, num14);
						switch (turnDirection2)
						{
						case Misc.TurnDirection.TurnRight:
							float_5 = 9f;
							break;
						case Misc.TurnDirection.TurnLeft:
							float_5 = -9f;
							break;
						}
						Waypoint waypoint_9 = null;
						CreateFlightPlanCurve(ref float_0, ref list_2, ref waypoint_10, ref waypoint_11, ref waypoint_9, ref float_6, actualSpeed, ref flight_0, float_5, turnDirection2, num14, ref bool_2, bool_1: true, string_0, null);
					}
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at 999999", "");
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				float num15 = ((bool_2 || flag) ? 0f : (waypoint_11.Leg_Time_Straight + waypoint_11.Leg_Time_Turn + waypoint_10.Leg_Time_Straight + waypoint_10.Leg_Time_Turn));
				if (flag4 || (!bool_2 && !flag && (double)Math.Abs(num15 - float_4) < 0.5))
				{
					break;
				}
				if (!bool_2 && !flag)
				{
					if (num < num15)
					{
						num = num15;
					}
					if (Math.Abs(num15 - float_4) < Math.Abs(num12))
					{
						latitude = waypoint_4.Latitude;
						longitude = waypoint_4.Longitude;
						num12 = num15 - float_4;
					}
					if (Math.Abs(float_4 - num15) < Math.Abs(num23))
					{
						num23 = float_4 - num15;
					}
				}
				if (num7 < num5 && !flag3)
				{
					try
					{
						bool flag5 = ((!(bool_2 || flag) && !(num15 <= float_4) && !((double)Math.Abs(num15 - float_4) <= 0.5)) ? true : false);
						if (num10 == (float)num29)
						{
							if (num23 == float.MaxValue)
							{
								if (num29 < 360 && num29 > -360)
								{
									num29 = ((num29 < 0) ? (num29 - 10) : (num29 + 10));
									num10 = num28;
									num = 0f;
									num23 = float.MaxValue;
									num8 = Math2.UpdateClass(num25 + (float)num28 + (float)num2);
									float_2 = num4 - float_1;
								}
								else
								{
									flag3 = true;
									waypoint_4.Latitude = latitude;
									waypoint_4.Longitude = longitude;
									num23 = num12;
								}
							}
							else
							{
								float num16 = Math.Abs(num23);
								float num17 = ((num16 < 5f) ? 0.98f : ((num16 < 15f) ? 0.85f : ((num16 < 30f) ? 0.75f : 0.7f)));
								float_2 += Math.Min(num23 * float_6 / 3600f * num17, float_2);
								num10 = num28;
								num = 0f;
								num23 = float.MaxValue;
								num8 = Math2.UpdateClass(num25 + (float)num28 + (float)num2);
								num7++;
								if (num7 != num5 && (!(float_2 < 0f) || (num29 != -360 && num29 != 360)))
								{
									if (float_2 < 0f)
									{
										num29 = ((num29 < 0) ? (-360) : 360);
										flag2 = true;
										float_2 = num4 - float_1;
									}
								}
								else
								{
									flag3 = true;
									waypoint_4.Latitude = latitude;
									waypoint_4.Longitude = longitude;
									num23 = num12;
								}
							}
						}
						else if (num23 != float.MaxValue && !flag)
						{
							if (flag5)
							{
								if (Math.Abs(MathFunctions.DeleteRequest(num10, num28)) > num24)
								{
									float num18 = Math.Abs(num23);
									float num19 = ((num18 < 5f) ? 0.9f : ((num18 < 15f) ? 0.85f : ((num18 < 30f) ? 0.8f : ((num18 < 60f) ? 0.5f : 0.3f))));
									float_2 += num23 * float_6 / 3600f * num19;
									num24 = Math.Abs(num10) + 15f;
									num10 = num28;
									num = 0f;
									num23 = float.MaxValue;
									num8 = Math2.UpdateClass(num25 + (float)num28 + (float)num2);
									num7++;
									if (num7 != num5 && (!(float_2 < 0f) || (num29 != -360 && num29 != 360)))
									{
										if (float_2 < 0f)
										{
											num29 = ((num29 < 0) ? (-360) : 360);
											flag2 = true;
											float_2 = num4 - float_1;
										}
									}
									else
									{
										flag3 = true;
										waypoint_4.Latitude = latitude;
										waypoint_4.Longitude = longitude;
										num23 = num12;
									}
								}
							}
							else if (num > num15 && num < float_4 && Math.Abs(MathFunctions.DeleteRequest(num10, num28)) > num24)
							{
								float num20 = Math.Abs(num23);
								float num21 = ((num20 < 5f) ? 1f : ((num20 < 15f) ? 0.9f : ((num20 < 30f) ? 0.8f : 0.7f)));
								float_2 += num23 * float_6 / 3600f * num21;
								num24 = Math.Abs(num10) + 15f;
								num10 = num28;
								num = 0f;
								num23 = float.MaxValue;
								num8 = Math2.UpdateClass(num25 + (float)num28 + (float)num2);
								num7++;
								if (num7 != num5 && (!(float_2 < 0f) || (num29 != -360 && num29 != 360)))
								{
									if (float_2 < 0f)
									{
										num29 = ((num29 < 0) ? (-360) : 360);
										flag2 = true;
										float_2 = num4 - float_1;
									}
								}
								else
								{
									flag3 = true;
									waypoint_4.Latitude = latitude;
									waypoint_4.Longitude = longitude;
									num23 = num12;
								}
							}
						}
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception exception_3 = ex3;
						exception_3?.Data.Add("Error at 999999", "");
						GameGeneral.WriteExceptionsToLog(ref exception_3);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				if (num7 >= num5 || flag3)
				{
					try
					{
						if (num23 == float.MaxValue)
						{
							flag4 = true;
							waypoint_4.Latitude = latitude;
							waypoint_4.Longitude = longitude;
							num23 = num12;
						}
						else
						{
							if (Information.IsNothing(num11))
							{
								float_8 = ((float_3 < 6f) ? Math2.PublishClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_4.Latitude, waypoint_4.Longitude) : Math2.PublishClass(waypoint_0.Latitude, waypoint_0.Longitude, waypoint_4.Latitude, waypoint_4.Longitude));
								float num22 = MathFunctions.DeleteRequest(num25, float_8);
								if (num22 <= 0f)
								{
									if (num22 < 0f)
									{
										num11 = Math2.UpdateClass(num25 - 90f);
									}
									else
									{
										flag4 = true;
										waypoint_4.Latitude = latitude;
										waypoint_4.Longitude = longitude;
										num23 = num12;
									}
								}
								else
								{
									num11 = Math2.UpdateClass(num25 + 90f);
								}
							}
							if (!flag4 && !Information.IsNothing(num11))
							{
								float float_9 = num23 * waypoint_1.Leg_Speed_Straight / 3600f / 3f;
								double longitude4 = waypoint_4.Longitude;
								double latitude4 = waypoint_4.Latitude;
								Waypoint obj8 = waypoint_4;
								double double_5 = obj8.Longitude;
								Waypoint obj9 = waypoint_4;
								double double_6 = obj9.Latitude;
								Geodesic_EdWilliams.CalcPoint_Williams(longitude4, latitude4, ref double_5, ref double_6, float_9, num11.Value);
								obj9.Latitude = double_6;
								obj8.Longitude = double_5;
							}
						}
						num7++;
						if (num7 > num6)
						{
							flag4 = true;
							waypoint_4.Latitude = latitude;
							waypoint_4.Longitude = longitude;
							num23 = num12;
						}
						if (flag4)
						{
							string text = "";
							if (Operators.CompareString(activeUnit_0.Name, activeUnit_0.UnitClass, TextCompare: false) != 0)
							{
								text = " (" + activeUnit_0.UnitClass + ")";
							}
							string text2 = ((mission_0.Category == Mission.MissionCategory.Package) ? "" : "任务");
							scenario_0.AddMessage(text2 + mission_0.Name + "飞机类型" + text + "其中一名僚机无法自动生成最佳的多方位时间目标（ToT）飞行计划" + string_0 + "。飞行计划已成功创建，但可能需要参演方注意。对于飞行编队分开的出口航段上的一个或多个航路点，僚机可能稍早或稍晚。", mission_0.Name + " needs extra attention", LoggedMessage.MessageType.AirOps, 15, activeUnit_0.ObjectID, activeUnit_0.GetUnitSide(), new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
							return;
						}
					}
					catch (Exception ex4)
					{
						ProjectData.SetProjectError(ex4);
						Exception exception_4 = ex4;
						exception_4?.Data.Add("Error at 999999", "");
						GameGeneral.WriteExceptionsToLog(ref exception_4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				num23 = float.MaxValue;
				flag = false;
			}
			waypoint_11.FlightplanPointsList = list_;
			waypoint_10.FlightplanPointsList = list_2;
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception exception_5 = ex5;
			exception_5?.Data.Add("Error at 101399", "");
			GameGeneral.WriteExceptionsToLog(ref exception_5);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void LoginTokenizer(ref Scenario scenario_0, ref Mission mission_0, ref Mission.Flight flight_0, ref ActiveUnit activeUnit_0, ref Waypoint waypoint_0, ref Waypoint waypoint_1, ref Waypoint waypoint_2, ref Waypoint waypoint_3, ref Waypoint waypoint_4, ref Waypoint waypoint_5, ref Waypoint waypoint_6, ref Waypoint waypoint_7, ref Waypoint waypoint_8, ref Waypoint waypoint_9, ref Waypoint waypoint_10, ref Waypoint waypoint_11, ref Waypoint waypoint_12, Misc.TurnDirection turnDirection_0, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, int int_0, int int_1, int int_2, float float_6, bool bool_0, bool bool_1, bool bool_2, ref string string_0, Mission.Flight.FlightElement flightElement_0, ref bool bool_3)
	{
		try
		{
			float actualSpeed;
			float actualSpeed2;
			Misc.TurnDirection turnDirection;
			Waypoint waypoint;
			if (bool_3)
			{
				float_1 = 7f;
				float num = Math2.PublishClass(waypoint_6.Latitude, waypoint_6.Longitude, waypoint_1.Latitude, waypoint_1.Longitude);
				float num5 = 0f;
				float float_10 = 0f;
				switch (flightElement_0)
				{
				case Mission.Flight.FlightElement.LeadElementWingman:
					num5 = 20f;
					float_10 = (float)((double)float_1 / Math.Cos(0.34906585039886595));
					break;
				case Mission.Flight.FlightElement.SecondElement:
					num5 = 30f;
					float_10 = (float)((double)float_1 / Math.Cos(0.5235987755982989));
					break;
				case Mission.Flight.FlightElement.SecondElementWingman:
					num5 = 40f;
					float_10 = (float)((double)float_1 / Math.Cos(0.6981317007977319));
					break;
				case Mission.Flight.FlightElement.ThirdElement:
					num5 = 47f;
					float_10 = (float)((double)float_1 / Math.Cos(0.820304748437335));
					break;
				case Mission.Flight.FlightElement.ThirdElementWingman:
					num5 = 53f;
					float_10 = (float)((double)float_1 / Math.Cos(0.9250245035569948));
					break;
				}
				float float_11 = Math2.UpdateClass(num + 180f - num5);
				double longitude = waypoint_1.Longitude;
				double latitude = waypoint_1.Latitude;
				double double_ = (waypoint = waypoint_3).Longitude;
				Waypoint obj = waypoint_3;
				double double_5 = obj.Latitude;
				Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_, ref double_5, float_10, float_11);
				obj.Latitude = double_5;
				waypoint.Longitude = double_;
			}
			else
			{
				actualSpeed = waypoint_1.ActualSpeed;
				actualSpeed2 = waypoint_0.ActualSpeed;
				float num6 = ActiveUnit_Kinematics.TurnRateCategoryToActualTurnRate(Waypoint.TurnRateCategory.const_6, actualSpeed);
				float num7 = Math.Abs(float_6) / num6;
				float num8 = actualSpeed / 3600f * num7;
				float num9 = (float)((double)actualSpeed / ((double)num6 * 3.14159265358979 * 20.0));
				float_1 = num9 / 2f + num8;
				float num10 = Math2.PublishClass(waypoint_6.Latitude, waypoint_6.Longitude, waypoint_1.Latitude, waypoint_1.Longitude);
				float num11 = 0f;
				switch (flightElement_0)
				{
				case Mission.Flight.FlightElement.LeadElementWingman:
					num11 = 50f;
					break;
				case Mission.Flight.FlightElement.SecondElement:
					num11 = 70f;
					break;
				case Mission.Flight.FlightElement.SecondElementWingman:
					num11 = 90f;
					break;
				case Mission.Flight.FlightElement.ThirdElement:
					num11 = 110f;
					break;
				case Mission.Flight.FlightElement.ThirdElementWingman:
					num11 = 130f;
					break;
				}
				turnDirection = Misc.CountValue(Math2.UpdateClass(num10 + 180f), Math2.UpdateClass(num10 + 180f + 90f));
				switch (turnDirection)
				{
				case Misc.TurnDirection.TurnRight:
					float_6 = 9f;
					break;
				case Misc.TurnDirection.TurnLeft:
					float_6 = -9f;
					break;
				}
				float float_12 = 0f;
				GeoPoint geoPoint = PatchTokenizer(waypoint_1.Latitude, waypoint_1.Longitude, Math2.UpdateClass(num10 + 180f), Math2.UpdateClass(num10 + 180f + 90f), Waypoint.TurnRateCategory.const_6, waypoint_1.DesiredSpeed.Value, float_6, turnDirection, ref float_12);
				double double_6 = 0.0;
				double double_7 = 0.0;
				if (Information.IsNothing(geoPoint))
				{
					float_12 = 90f / num6;
					Geodesic_EdWilliams.CalcPoint_Williams(waypoint_1.Longitude, waypoint_1.Latitude, ref double_6, ref double_7, float_1, num10);
				}
				else
				{
					double_6 = geoPoint.Longitude;
					double_7 = geoPoint.Latitude;
				}
				float float_7 = num9 + actualSpeed / 3600f * (num11 - float_12);
				double double_8 = double_6;
				double double_9 = double_7;
				Waypoint waypoint2;
				double double_10 = (waypoint2 = waypoint_3).Longitude;
				double double_11 = (waypoint = waypoint_3).Latitude;
				Geodesic_EdWilliams.CalcPoint_Williams(double_8, double_9, ref double_10, ref double_11, float_7, Math2.UpdateClass(num10 + 180f + 90f));
				waypoint.Latitude = double_11;
				waypoint2.Longitude = double_10;
			}
			Waypoint waypoint_13 = waypoint_3;
			Waypoint waypoint_14 = waypoint_1;
			Waypoint obj2 = waypoint_0;
			actualSpeed = waypoint_14.ActualSpeed;
			actualSpeed2 = obj2.ActualSpeed;
			List<Waypoint.FlightPlanSegment> list_ = new List<Waypoint.FlightPlanSegment>();
			List<Waypoint.FlightPlanSegment> list_2 = new List<Waypoint.FlightPlanSegment>();
			List<Waypoint.FlightPlanSegment> list_3 = new List<Waypoint.FlightPlanSegment>();
			float float_8 = float_0;
			bool bool_4 = false;
			float num12 = Math2.PublishClass(waypoint_14.Latitude, waypoint_14.Longitude, waypoint_13.Latitude, waypoint_13.Longitude);
			turnDirection = Misc.CountValue(float_8, num12);
			switch (turnDirection)
			{
			case Misc.TurnDirection.TurnRight:
				float_6 = 9f;
				break;
			case Misc.TurnDirection.TurnLeft:
				float_6 = -9f;
				break;
			}
			waypoint = null;
			CreateFlightPlanCurve(ref float_8, ref list_, ref waypoint_13, ref waypoint_14, ref waypoint, ref actualSpeed, actualSpeed2, ref flight_0, float_6, turnDirection, num12, ref bool_4, bool_1: true, "", null);
			float num2 = float_8;
			waypoint_13 = waypoint_7;
			waypoint_14 = waypoint_3;
			Waypoint obj3 = waypoint_1;
			actualSpeed = waypoint_14.ActualSpeed;
			actualSpeed2 = obj3.ActualSpeed;
			num12 = Math2.PublishClass(waypoint_14.Latitude, waypoint_14.Longitude, waypoint_13.Latitude, waypoint_13.Longitude);
			turnDirection = Misc.CountValue(float_8, num12);
			switch (turnDirection)
			{
			case Misc.TurnDirection.TurnRight:
				float_6 = 9f;
				break;
			case Misc.TurnDirection.TurnLeft:
				float_6 = -9f;
				break;
			}
			waypoint = null;
			CreateFlightPlanCurve(ref float_8, ref list_3, ref waypoint_13, ref waypoint_14, ref waypoint, ref actualSpeed, actualSpeed2, ref flight_0, float_6, turnDirection, num12, ref bool_4, bool_1: true, "", null);
			if (!bool_4)
			{
				double startLatitude = list_3[list_3.Count - 1].StartLatitude;
				double startLongitude = list_3[list_3.Count - 1].StartLongitude;
				float num3 = Math2.VerifyClass(waypoint_7.Latitude, waypoint_7.Longitude, startLatitude, startLongitude);
				float float_9 = Math2.PublishClass(waypoint_7.Latitude, waypoint_7.Longitude, startLatitude, startLongitude);
				float_3 = Math2.VerifyClass(waypoint_6.Latitude, waypoint_6.Longitude, waypoint_4.Latitude, waypoint_4.Longitude);
				if (num3 <= float_3)
				{
					if (num3 > 1f)
					{
						num3 -= 1f;
					}
					double longitude2 = waypoint_7.Longitude;
					double latitude2 = waypoint_7.Latitude;
					Waypoint waypoint3;
					double double_12 = (waypoint3 = waypoint_5).Longitude;
					double double_2 = (waypoint = waypoint_5).Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude2, latitude2, ref double_12, ref double_2, num3, float_9);
					waypoint.Latitude = double_2;
					waypoint3.Longitude = double_12;
				}
				else
				{
					double longitude3 = waypoint_7.Longitude;
					double latitude3 = waypoint_7.Latitude;
					double double_3 = (waypoint = waypoint_5).Longitude;
					Waypoint obj4 = waypoint_5;
					double double_4 = obj4.Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude3, latitude3, ref double_3, ref double_4, float_3, float_9);
					obj4.Latitude = double_4;
					waypoint.Longitude = double_3;
				}
			}
			float_8 = num2;
			waypoint_13 = waypoint_5;
			waypoint_14 = waypoint_3;
			Waypoint obj5 = waypoint_1;
			actualSpeed = waypoint_14.ActualSpeed;
			actualSpeed2 = obj5.ActualSpeed;
			num12 = Math2.PublishClass(waypoint_14.Latitude, waypoint_14.Longitude, waypoint_13.Latitude, waypoint_13.Longitude);
			turnDirection = Misc.CountValue(float_8, num12);
			switch (turnDirection)
			{
			case Misc.TurnDirection.TurnRight:
				float_6 = 9f;
				break;
			case Misc.TurnDirection.TurnLeft:
				float_6 = -9f;
				break;
			}
			waypoint = null;
			CreateFlightPlanCurve(ref float_8, ref list_2, ref waypoint_13, ref waypoint_14, ref waypoint, ref actualSpeed, actualSpeed2, ref flight_0, float_6, turnDirection, num12, ref bool_4, bool_1: true, "", null);
			waypoint_13 = waypoint_7;
			waypoint_14 = waypoint_5;
			Waypoint obj6 = waypoint_3;
			actualSpeed = waypoint_14.ActualSpeed;
			actualSpeed2 = obj6.ActualSpeed;
			num12 = Math2.PublishClass(waypoint_14.Latitude, waypoint_14.Longitude, waypoint_13.Latitude, waypoint_13.Longitude);
			turnDirection = Misc.CountValue(float_8, num12);
			switch (turnDirection)
			{
			case Misc.TurnDirection.TurnRight:
				float_6 = 9f;
				break;
			case Misc.TurnDirection.TurnLeft:
				float_6 = -9f;
				break;
			}
			waypoint = null;
			CreateFlightPlanCurve(ref float_8, ref list_3, ref waypoint_13, ref waypoint_14, ref waypoint, ref actualSpeed, actualSpeed2, ref flight_0, float_6, turnDirection, num12, ref bool_4, bool_1: true, "", null);
			float num4 = waypoint_3.Leg_Time_Straight + waypoint_3.Leg_Time_Turn + waypoint_5.Leg_Time_Straight + waypoint_5.Leg_Time_Turn + waypoint_7.Leg_Time_Straight + waypoint_7.Leg_Time_Turn;
			float_5 = waypoint_2.Leg_Time_Straight + waypoint_2.Leg_Time_Turn + waypoint_4.Leg_Time_Straight + waypoint_4.Leg_Time_Turn + waypoint_6.Leg_Time_Straight + waypoint_6.Leg_Time_Turn + waypoint_8.Leg_Time_Straight + waypoint_8.Leg_Time_Turn + waypoint_10.Leg_Time_Straight + waypoint_10.Leg_Time_Turn - num4;
			waypoint_7.FlightplanPointsList = list_3;
			float_1 = 7f;
			ValidateTokenizer(ref scenario_0, ref float_8, ref mission_0, ref flight_0, ref activeUnit_0, ref waypoint_5, ref waypoint_6, ref waypoint_7, ref waypoint_8, ref waypoint_9, ref waypoint_10, ref waypoint_11, ref waypoint_12, turnDirection_0, float_1, float_2, float_3, float_5, float_6, bool_0, bool_1, ref string_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101400", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void GetTokenizer(ref Scenario scenario_0, ref Mission mission_0, ref Mission.Flight flight_0, ref ActiveUnit activeUnit_0, ref Waypoint waypoint_0, ref Waypoint waypoint_1, ref Waypoint waypoint_2, ref Waypoint waypoint_3, ref Waypoint waypoint_4, ref Waypoint waypoint_5, ref Waypoint waypoint_6, ref Waypoint waypoint_7, ref Waypoint waypoint_8, ref Waypoint waypoint_9, ref Waypoint waypoint_10, ref Waypoint waypoint_11, ref Waypoint waypoint_12, Misc.TurnDirection turnDirection_0, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, int int_0, int int_1, int int_2, float float_6, bool bool_0, bool bool_1, bool bool_2, ref string string_0, Mission.Flight.FlightElement flightElement_0)
	{
		try
		{
			Strike strike = (Strike)mission_0;
			if (Information.IsNothing(waypoint_6) || Information.IsNothing(waypoint_4) || Information.IsNothing(waypoint_2) || Information.IsNothing(waypoint_1))
			{
				return;
			}
			float_3 = Math2.VerifyClass(waypoint_6.Latitude, waypoint_6.Longitude, waypoint_4.Latitude, waypoint_4.Longitude);
			float num = Math2.PublishClass(waypoint_6.Latitude, waypoint_6.Longitude, waypoint_1.Latitude, waypoint_1.Longitude);
			float num12 = 0f;
			switch (strike.SplitDistance)
			{
			case Mission._SplitDistance.Close_10nm:
				num12 = 10f;
				break;
			case Mission._SplitDistance.Typical_20nm:
				num12 = 20f;
				break;
			case Mission._SplitDistance.Long_50nm:
				num12 = 40f;
				break;
			}
			if ((double)num12 > (double)float_3 * 1.5)
			{
				num12 = (float)((double)float_3 * 1.5);
			}
			float num13 = num12 / 2f;
			float float_27 = Math2.PublishClass(waypoint_6.Latitude, waypoint_6.Longitude, waypoint_10.Latitude, waypoint_10.Longitude);
			bool flag = MathFunctions.DeleteRequest(num, float_27) > 0f;
			float num14 = ((float_3 < 6f) ? 10f : ((float_3 < 20f) ? 7f : ((float_3 < 50f) ? 5f : ((float_3 < 100f) ? 2f : 1f))));
			Mission._FlightSize desiredAircraftQty = flight_0.DesiredAircraftQty;
			double double_;
			Waypoint waypoint;
			double double_2;
			Waypoint waypoint2;
			if (desiredAircraftQty == 2)
			{
				float num15 = (float)(Math.Asin(num13 / float_3) * 57.2957795130823);
				float float_28 = (flag ? Math2.UpdateClass(num + num15 - num14) : Math2.UpdateClass(num - num15 + num14));
				double longitude = waypoint_6.Longitude;
				double latitude = waypoint_6.Latitude;
				double_ = (waypoint = waypoint_5).Longitude;
				double_2 = (waypoint2 = waypoint_5).Latitude;
				Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_, ref double_2, float_3, float_28);
				waypoint2.Latitude = double_2;
				waypoint.Longitude = double_;
			}
			else if (desiredAircraftQty == 3)
			{
				switch (flightElement_0)
				{
				case Mission.Flight.FlightElement.SecondElement:
				{
					float num16 = (float)(Math.Asin(num13 / float_3) * 57.2957795130823);
					float float_7 = (flag ? Math2.UpdateClass(num + num16 - num14) : Math2.UpdateClass(num - num16 + num14));
					double longitude7 = waypoint_6.Longitude;
					double latitude7 = waypoint_6.Latitude;
					double_ = (waypoint = waypoint_5).Longitude;
					double_2 = (waypoint2 = waypoint_5).Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude7, latitude7, ref double_, ref double_2, float_3, float_7);
					waypoint2.Latitude = double_2;
					waypoint.Longitude = double_;
					break;
				}
				case Mission.Flight.FlightElement.LeadElementWingman:
				{
					float float_29 = (flag ? Math2.UpdateClass(num - num14) : Math2.UpdateClass(num + num14));
					double longitude6 = waypoint_6.Longitude;
					double latitude6 = waypoint_6.Latitude;
					double_2 = (waypoint2 = waypoint_5).Longitude;
					double_ = (waypoint = waypoint_5).Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude6, latitude6, ref double_2, ref double_, float_3, float_29);
					waypoint.Latitude = double_;
					waypoint2.Longitude = double_2;
					break;
				}
				}
			}
			else if (desiredAircraftQty == 4)
			{
				switch (flightElement_0)
				{
				case Mission.Flight.FlightElement.LeadElementWingman:
				{
					float num19 = (float)(Math.Asin(num12 / 6f / float_3) * 57.2957795130823);
					float float_10 = (flag ? Math2.UpdateClass(num - num19 - num14) : Math2.UpdateClass(num + num19 + num14));
					double longitude10 = waypoint_6.Longitude;
					double latitude10 = waypoint_6.Latitude;
					double_2 = (waypoint2 = waypoint_5).Longitude;
					double_ = (waypoint = waypoint_5).Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude10, latitude10, ref double_2, ref double_, float_3, float_10);
					waypoint.Latitude = double_;
					waypoint2.Longitude = double_2;
					break;
				}
				case Mission.Flight.FlightElement.SecondElement:
				{
					float num18 = (float)(Math.Asin(num12 / 6f / float_3) * 57.2957795130823);
					float float_9 = (flag ? Math2.UpdateClass(num + num18 - num14) : Math2.UpdateClass(num - num18 + num14));
					double longitude9 = waypoint_6.Longitude;
					double latitude9 = waypoint_6.Latitude;
					double_ = (waypoint = waypoint_5).Longitude;
					double_2 = (waypoint2 = waypoint_5).Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude9, latitude9, ref double_, ref double_2, float_3, float_9);
					waypoint2.Latitude = double_2;
					waypoint.Longitude = double_;
					break;
				}
				case Mission.Flight.FlightElement.SecondElementWingman:
				{
					float num17 = (float)(Math.Asin(num13 / float_3) * 57.2957795130823);
					float float_8 = (flag ? Math2.UpdateClass(num + num17 - num14) : Math2.UpdateClass(num - num17 + num14));
					double longitude8 = waypoint_6.Longitude;
					double latitude8 = waypoint_6.Latitude;
					double_2 = (waypoint2 = waypoint_5).Longitude;
					double_ = (waypoint = waypoint_5).Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude8, latitude8, ref double_2, ref double_, float_3, float_8);
					waypoint.Latitude = double_;
					waypoint2.Longitude = double_2;
					break;
				}
				}
			}
			else if (desiredAircraftQty == 6)
			{
				switch (flightElement_0)
				{
				case Mission.Flight.FlightElement.LeadElementWingman:
				{
					float num3 = (float)(Math.Asin((double)num12 * 0.3 / (double)float_3) * 57.2957795130823);
					float float_12 = (flag ? Math2.UpdateClass(num - num3 - num14) : Math2.UpdateClass(num + num3 + num14));
					double longitude12 = waypoint_6.Longitude;
					double latitude12 = waypoint_6.Latitude;
					double_ = (waypoint = waypoint_5).Longitude;
					double_2 = (waypoint2 = waypoint_5).Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude12, latitude12, ref double_, ref double_2, float_3, float_12);
					waypoint2.Latitude = double_2;
					waypoint.Longitude = double_;
					break;
				}
				case Mission.Flight.FlightElement.SecondElement:
				{
					float num5 = (float)(Math.Asin((double)num12 * 0.1 / (double)float_3) * 57.2957795130823);
					float float_14 = (flag ? Math2.UpdateClass(num - num5 - num14) : Math2.UpdateClass(num + num5 + num14));
					double longitude2 = waypoint_6.Longitude;
					double latitude2 = waypoint_6.Latitude;
					double_2 = (waypoint2 = waypoint_5).Longitude;
					double_ = (waypoint = waypoint_5).Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude2, latitude2, ref double_2, ref double_, float_3, float_14);
					waypoint.Latitude = double_;
					waypoint2.Longitude = double_2;
					break;
				}
				case Mission.Flight.FlightElement.SecondElementWingman:
				{
					float num4 = (float)(Math.Asin((double)num12 * 0.1 / (double)float_3) * 57.2957795130823);
					float float_13 = (flag ? Math2.UpdateClass(num + num4 - num14) : Math2.UpdateClass(num - num4 + num14));
					double longitude13 = waypoint_6.Longitude;
					double latitude13 = waypoint_6.Latitude;
					double_ = (waypoint = waypoint_5).Longitude;
					double_2 = (waypoint2 = waypoint_5).Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude13, latitude13, ref double_, ref double_2, float_3, float_13);
					waypoint2.Latitude = double_2;
					waypoint.Longitude = double_;
					break;
				}
				case Mission.Flight.FlightElement.ThirdElement:
				{
					float num6 = (float)(Math.Asin((double)num12 * 0.3 / (double)float_3) * 57.2957795130823);
					float float_15 = (flag ? Math2.UpdateClass(num + num6 - num14) : Math2.UpdateClass(num - num6 + num14));
					double longitude3 = waypoint_6.Longitude;
					double latitude3 = waypoint_6.Latitude;
					double_2 = (waypoint2 = waypoint_5).Longitude;
					double_ = (waypoint = waypoint_5).Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude3, latitude3, ref double_2, ref double_, float_3, float_15);
					waypoint.Latitude = double_;
					waypoint2.Longitude = double_2;
					break;
				}
				case Mission.Flight.FlightElement.ThirdElementWingman:
				{
					float num2 = (float)(Math.Asin(num13 / float_3) * 57.2957795130823);
					float float_11 = (flag ? Math2.UpdateClass(num + num2 - num14) : Math2.UpdateClass(num - num2 + num14));
					double longitude11 = waypoint_6.Longitude;
					double latitude11 = waypoint_6.Latitude;
					double_ = (waypoint = waypoint_5).Longitude;
					double_2 = (waypoint2 = waypoint_5).Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude11, latitude11, ref double_, ref double_2, float_3, float_11);
					waypoint2.Latitude = double_2;
					waypoint.Longitude = double_;
					break;
				}
				}
			}
			float float_16;
			float num7;
			if (float_3 < 6f)
			{
				if ((float_1 + float_2 - float_3) / 2f < 5f)
				{
					float_16 = (float_1 + float_2 - float_3) / 2f;
					num7 = (float_1 + float_2 - float_3) / 2f + 1f;
				}
				else
				{
					float_16 = 5f;
					num7 = float_3;
				}
			}
			else
			{
				float_16 = 5f;
				num7 = 6f;
			}
			double longitude4 = waypoint_5.Longitude;
			double latitude4 = waypoint_5.Latitude;
			double_2 = (waypoint2 = waypoint_3).Longitude;
			double_ = (waypoint = waypoint_3).Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(longitude4, latitude4, ref double_2, ref double_, float_16, num);
			waypoint.Latitude = double_;
			waypoint2.Longitude = double_2;
			bool bool_3 = false;
			Waypoint[] gparam_ = new Waypoint[0];
			Doctrine doctrine_ = null;
			ArrayExtensions.Add(ref gparam_, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_0, bool_0: false, bool_1: true, ref doctrine_));
			doctrine_ = null;
			ArrayExtensions.Add(ref gparam_, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_1, bool_0: false, bool_1: true, ref doctrine_));
			doctrine_ = null;
			ArrayExtensions.Add(ref gparam_, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_3, bool_0: false, bool_1: true, ref doctrine_));
			doctrine_ = null;
			ArrayExtensions.Add(ref gparam_, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_5, bool_0: false, bool_1: true, ref doctrine_));
			doctrine_ = null;
			ArrayExtensions.Add(ref gparam_, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_7, bool_0: false, bool_1: true, ref doctrine_));
			float num8 = Math2.PublishClass(gparam_[1].Latitude, gparam_[1].Longitude, gparam_[2].Latitude, gparam_[2].Longitude);
			float float_17 = ((Information.IsNothing(waypoint_1.FlightplanPointsList) || waypoint_1.FlightplanPointsList.Count <= 0) ? Math2.PublishClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_3.Latitude, waypoint_3.Longitude) : Math2.PublishClass(waypoint_1.FlightplanPointsList[waypoint_1.FlightplanPointsList.Count - 1].StartLatitude, waypoint_1.FlightplanPointsList[waypoint_1.FlightplanPointsList.Count - 1].StartLongitude, waypoint_1.FlightplanPointsList[waypoint_1.FlightplanPointsList.Count - 1].EndLatitude, waypoint_1.FlightplanPointsList[waypoint_1.FlightplanPointsList.Count - 1].EndLongitude));
			Misc.TurnDirection turnDirection = Misc.CountValue(float_17, num8);
			float float_18 = 0f;
			switch (turnDirection)
			{
			case Misc.TurnDirection.TurnRight:
				float_18 = 9f;
				break;
			case Misc.TurnDirection.TurnLeft:
				float_18 = -9f;
				break;
			}
			float float_19 = gparam_[1].ActualSpeed;
			float actualSpeed = gparam_[0].ActualSpeed;
			gparam_[2].FlightplanPointsList = new List<Waypoint.FlightPlanSegment>();
			ref List<Waypoint.FlightPlanSegment> flightplanPointsList = ref gparam_[2].FlightplanPointsList;
			ref Waypoint waypoint_13 = ref gparam_[2];
			ref Waypoint waypoint_14 = ref gparam_[1];
			waypoint = null;
			float float_20 = actualSpeed;
			Mission.Flight flight_ = null;
			CreateFlightPlanCurve(ref float_17, ref flightplanPointsList, ref waypoint_13, ref waypoint_14, ref waypoint, ref float_19, float_20, ref flight_, float_18, turnDirection, num8, ref bool_3, bool_1: true, "", null);
			if (bool_3)
			{
				scenario_0.AddMessage(activeUnit_0.UnitClass + "与挂载" + ((Aircraft)activeUnit_0).Loadout.Name + "在任务上" + activeUnit_0.AssignedMissionOrPackage().Name + "由于逻辑错误，无法创建多方位同时到达目标飞行计划。距离太短或速度太快。请使用不同的攻击模式，或命令飞机从距离目标更远的地点分开。", activeUnit_0.UnitClass + " on " + activeUnit_0.AssignedMissionOrPackage().Name + " cannot multi-axis", LoggedMessage.MessageType.AirOps, 0, activeUnit_0.ObjectID, activeUnit_0.GetUnitSide(), new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
				return;
			}
			num8 = Math2.PublishClass(gparam_[2].Latitude, gparam_[2].Longitude, gparam_[3].Latitude, gparam_[3].Longitude);
			turnDirection = Misc.CountValue(float_17, num8);
			switch (turnDirection)
			{
			case Misc.TurnDirection.TurnRight:
				float_18 = 9f;
				break;
			case Misc.TurnDirection.TurnLeft:
				float_18 = -9f;
				break;
			}
			float_19 = gparam_[2].ActualSpeed;
			float actualSpeed2 = gparam_[1].ActualSpeed;
			gparam_[3].FlightplanPointsList = new List<Waypoint.FlightPlanSegment>();
			ref List<Waypoint.FlightPlanSegment> flightplanPointsList2 = ref gparam_[3].FlightplanPointsList;
			ref Waypoint waypoint_15 = ref gparam_[3];
			ref Waypoint waypoint_16 = ref gparam_[2];
			waypoint = null;
			float float_21 = actualSpeed2;
			flight_ = null;
			CreateFlightPlanCurve(ref float_17, ref flightplanPointsList2, ref waypoint_15, ref waypoint_16, ref waypoint, ref float_19, float_21, ref flight_, float_18, turnDirection, num8, ref bool_3, bool_1: true, "", null);
			if (bool_3)
			{
				scenario_0.AddMessage(activeUnit_0.UnitClass + "与挂载" + ((Aircraft)activeUnit_0).Loadout.Name + "在任务上" + activeUnit_0.AssignedMissionOrPackage().Name + "由于逻辑错误，无法创建多方位同时到达目标飞行计划。距离太短或速度太快。请使用不同的攻击模式，或命令飞机从距离目标更远的地点分开。", activeUnit_0.UnitClass + " on " + activeUnit_0.AssignedMissionOrPackage().Name + " cannot multi-axis", LoggedMessage.MessageType.AirOps, 0, activeUnit_0.ObjectID, activeUnit_0.GetUnitSide(), new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
				return;
			}
			num8 = Math2.PublishClass(gparam_[3].Latitude, gparam_[3].Longitude, gparam_[4].Latitude, gparam_[4].Longitude);
			turnDirection = Misc.CountValue(float_17, num8);
			switch (turnDirection)
			{
			case Misc.TurnDirection.TurnRight:
				float_18 = 9f;
				break;
			case Misc.TurnDirection.TurnLeft:
				float_18 = -9f;
				break;
			}
			float_19 = gparam_[3].ActualSpeed;
			float actualSpeed3 = gparam_[2].ActualSpeed;
			gparam_[4].FlightplanPointsList = new List<Waypoint.FlightPlanSegment>();
			ref List<Waypoint.FlightPlanSegment> flightplanPointsList3 = ref gparam_[4].FlightplanPointsList;
			ref Waypoint waypoint_17 = ref gparam_[4];
			ref Waypoint waypoint_18 = ref gparam_[3];
			waypoint = null;
			float float_22 = actualSpeed3;
			flight_ = null;
			CreateFlightPlanCurve(ref float_17, ref flightplanPointsList3, ref waypoint_17, ref waypoint_18, ref waypoint, ref float_19, float_22, ref flight_, float_18, turnDirection, num8, ref bool_3, bool_1: true, "", null);
			if (bool_3)
			{
				scenario_0.AddMessage(activeUnit_0.UnitClass + "与挂载" + ((Aircraft)activeUnit_0).Loadout.Name + "在任务上" + activeUnit_0.AssignedMissionOrPackage().Name + "由于逻辑错误，无法创建多方位同时到达目标飞行计划。距离太短或速度太快。请使用不同的攻击模式，或命令飞机从距离目标更远的地点分开。", activeUnit_0.UnitClass + " on " + activeUnit_0.AssignedMissionOrPackage().Name + " cannot multi-axis", LoggedMessage.MessageType.AirOps, 0, activeUnit_0.ObjectID, activeUnit_0.GetUnitSide(), new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
				return;
			}
			float float_23 = 0f;
			float float_24 = 0f;
			bool bool_4 = false;
			DetermineTimesAndFuelQty(ref scenario_0, ref mission_0, ref flight_0, ref gparam_, ref activeUnit_0, ref float_23, ref float_24, ref bool_4, bool_1: true, bool_2: false, string_0, bool_3: false);
			float num9 = gparam_[2].Leg_Time_Turn + gparam_[2].Leg_Time_Straight + gparam_[3].Leg_Time_Turn + gparam_[3].Leg_Time_Straight + gparam_[4].Leg_Time_Turn + gparam_[4].Leg_Time_Straight;
			float num10 = waypoint_2.Leg_Time_Turn + waypoint_2.Leg_Time_Straight + waypoint_4.Leg_Time_Turn + waypoint_4.Leg_Time_Straight + waypoint_6.Leg_Time_Turn + waypoint_6.Leg_Time_Straight - num9;
			if (num10 > 0f)
			{
				waypoint_3.SpacingManeuver_Time = num10;
			}
			waypoint_7.FlightplanPointsList = gparam_[4].FlightplanPointsList;
			if (num7 < 6f)
			{
				ValidateTokenizer(ref scenario_0, ref float_17, ref mission_0, ref flight_0, ref activeUnit_0, ref waypoint_5, ref waypoint_6, ref waypoint_7, ref waypoint_8, ref waypoint_9, ref waypoint_10, ref waypoint_11, ref waypoint_12, turnDirection_0, float_1, float_2, float_3, float_5, float_6, bool_0, bool_1, ref string_0);
				return;
			}
			double longitude5 = waypoint_5.Longitude;
			double latitude5 = waypoint_5.Latitude;
			double_ = (waypoint = waypoint_9).Longitude;
			double_2 = (waypoint2 = waypoint_9).Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(longitude5, latitude5, ref double_, ref double_2, num7, float_27);
			waypoint2.Latitude = double_2;
			waypoint.Longitude = double_;
			Waypoint[] gparam_2 = new Waypoint[0];
			ArrayExtensions.Add(ref gparam_2, gparam_[4]);
			doctrine_ = null;
			ArrayExtensions.Add(ref gparam_2, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_9, bool_0: false, bool_1: true, ref doctrine_));
			doctrine_ = null;
			ArrayExtensions.Add(ref gparam_2, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_11, bool_0: false, bool_1: true, ref doctrine_));
			num8 = Math2.PublishClass(gparam_2[0].Latitude, gparam_2[0].Longitude, gparam_2[1].Latitude, gparam_2[1].Longitude);
			turnDirection = Misc.CountValue(float_17, num8);
			switch (turnDirection)
			{
			case Misc.TurnDirection.TurnRight:
				float_18 = 9f;
				break;
			case Misc.TurnDirection.TurnLeft:
				float_18 = -9f;
				break;
			}
			float_19 = gparam_2[0].ActualSpeed;
			float actualSpeed4 = gparam_[4].ActualSpeed;
			gparam_2[1].FlightplanPointsList = new List<Waypoint.FlightPlanSegment>();
			Waypoint waypoint_19 = gparam_2[0];
			ref List<Waypoint.FlightPlanSegment> flightplanPointsList4 = ref gparam_2[1].FlightplanPointsList;
			ref Waypoint waypoint_20 = ref gparam_2[1];
			waypoint2 = null;
			float float_25 = actualSpeed4;
			flight_ = null;
			CreateFlightPlanCurve(ref float_17, ref flightplanPointsList4, ref waypoint_20, ref waypoint_19, ref waypoint2, ref float_19, float_25, ref flight_, float_18, turnDirection, num8, ref bool_3, bool_1: true, "", null);
			if (bool_3)
			{
				scenario_0.AddMessage(activeUnit_0.UnitClass + "与挂载" + ((Aircraft)activeUnit_0).Loadout.Name + "在任务上" + activeUnit_0.AssignedMissionOrPackage().Name + "由于逻辑错误，无法创建多方位同时到达目标飞行计划。距离太短或速度太快。请使用不同的攻击模式，或命令飞机从距离目标更远的地点分开。", activeUnit_0.UnitClass + " on " + activeUnit_0.AssignedMissionOrPackage().Name + " cannot multi-axis", LoggedMessage.MessageType.AirOps, 0, activeUnit_0.ObjectID, activeUnit_0.GetUnitSide(), new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
				return;
			}
			num8 = Math2.PublishClass(gparam_2[1].Latitude, gparam_2[1].Longitude, gparam_2[2].Latitude, gparam_2[2].Longitude);
			turnDirection = Misc.CountValue(float_17, num8);
			switch (turnDirection)
			{
			case Misc.TurnDirection.TurnRight:
				float_18 = 9f;
				break;
			case Misc.TurnDirection.TurnLeft:
				float_18 = -9f;
				break;
			}
			float_19 = gparam_2[1].ActualSpeed;
			float actualSpeed5 = gparam_2[0].ActualSpeed;
			gparam_2[2].FlightplanPointsList = new List<Waypoint.FlightPlanSegment>();
			ref List<Waypoint.FlightPlanSegment> flightplanPointsList5 = ref gparam_2[2].FlightplanPointsList;
			ref Waypoint waypoint_21 = ref gparam_2[2];
			ref Waypoint waypoint_22 = ref gparam_2[1];
			waypoint2 = null;
			float float_26 = actualSpeed5;
			flight_ = null;
			CreateFlightPlanCurve(ref float_17, ref flightplanPointsList5, ref waypoint_21, ref waypoint_22, ref waypoint2, ref float_19, float_26, ref flight_, float_18, turnDirection, num8, ref bool_3, bool_1: true, "", null);
			if (bool_3)
			{
				scenario_0.AddMessage(activeUnit_0.UnitClass + "与挂载" + ((Aircraft)activeUnit_0).Loadout.Name + "在任务上" + activeUnit_0.AssignedMissionOrPackage().Name + "由于逻辑错误，无法创建多方位同时到达目标飞行计划。距离太短或速度太快。请使用不同的攻击模式，或命令飞机从距离目标更远的地点分开。", activeUnit_0.UnitClass + " on " + activeUnit_0.AssignedMissionOrPackage().Name + " cannot multi-axis", LoggedMessage.MessageType.AirOps, 0, activeUnit_0.ObjectID, activeUnit_0.GetUnitSide(), new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
				return;
			}
			float_24 = 0f;
			float_23 = 0f;
			bool_4 = false;
			DetermineTimesAndFuelQty(ref scenario_0, ref mission_0, ref flight_0, ref gparam_2, ref activeUnit_0, ref float_24, ref float_23, ref bool_4, bool_1: true, bool_2: false, string_0, bool_3: false);
			float num11 = gparam_2[1].Leg_Time_Turn + gparam_2[1].Leg_Time_Straight + gparam_2[2].Leg_Time_Turn + gparam_2[2].Leg_Time_Straight;
			num10 = waypoint_8.Leg_Time_Turn + waypoint_8.Leg_Time_Straight + waypoint_10.Leg_Time_Turn + waypoint_10.Leg_Time_Straight - num11;
			if (num10 > 0f)
			{
				waypoint_11.SpacingManeuver_Time = num10;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101401", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static Waypoint WriteTokenizer(Waypoint waypoint_0, Aircraft aircraft_0, ref Waypoint[] waypoint_1, double double_0, double double_1, AircraftMissionProfile aircraftMissionProfile_0, ref float float_0, ref float float_1, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref float float_2, ref Waypoint.Formation formation_0, Waypoint.TurnRateCategory turnRateCategory_0, Waypoint.SpeedToT speedToT_0)
	{
		try
		{
			Waypoint waypoint;
			if (Information.IsNothing(waypoint_0))
			{
				waypoint = new Waypoint(double_1, double_0, 0f, Waypoint.WaypointType.Assemble, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
			}
			else
			{
				waypoint = waypoint_0;
				waypoint.Type = Waypoint.WaypointType.Assemble;
			}
			waypoint.Name = Waypoint.GetWaypointTypeString(Waypoint.WaypointType.Assemble);
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			if (aircraftMissionProfile_0.CruiseAtOptimumAltitude)
			{
				Waypoint waypoint2 = waypoint;
				bool bool_ = false;
				waypoint2.DesiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_0, ActiveUnit.Throttle.Cruise, ref bool_);
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			else if (aircraftMissionProfile_0.CruiseAltitudeIngressTerrainFollowing)
			{
				waypoint.TerrainFollowing = true;
				waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.CruiseAltitudeIngress;
				float_0 = 0f;
				float_1 = waypoint.DesiredAltitude_TerrainFollowing.Value;
				bool_0 = waypoint.TerrainFollowing;
			}
			else
			{
				waypoint.DesiredAltitude = aircraftMissionProfile_0.CruiseAltitudeIngress;
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			else
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.CruiseThrottleSettingIngress;
				if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
				{
					unitThrottlePreset_0 = waypoint.ThrottlePreset;
				}
				else if (!Information.IsNothing(unitThrottlePreset_0) && unitThrottlePreset_0 != ActiveUnit_Kinematics.UnitThrottlePreset.None && unitThrottlePreset_0 != 0)
				{
					waypoint.ThrottlePreset = unitThrottlePreset_0;
				}
				else
				{
					waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
					unitThrottlePreset_0 = waypoint.ThrottlePreset;
				}
			}
			if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			else
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			if (!Information.IsNothing(waypoint.DesiredSpeed))
			{
				float_2 = waypoint.DesiredSpeed.Value;
			}
			if (Information.IsNothing(waypoint.Time_Zulu))
			{
				waypoint.TimeFixed = Waypoint.FixedFree.None;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
			waypoint.SpeedAdjustmentToT = speedToT_0;
			waypoint.FlightFormation = formation_0;
			waypoint.DesiredAltitudeOverride = true;
			waypoint.TurnRate_Navigation = turnRateCategory_0;
			if (Information.IsNothing(waypoint_0))
			{
				ArrayExtensions.Add(ref waypoint_1, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static Waypoint NewTokenizer(Waypoint waypoint_0, object object_0, ref Waypoint[] waypoint_1, double double_0, double double_1, AircraftMissionProfile aircraftMissionProfile_0, ref float float_0, ref float float_1, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref float float_2, ref Waypoint.Formation formation_0, Waypoint.TurnRateCategory turnRateCategory_0, Waypoint.SpeedToT speedToT_0)
	{
		try
		{
			Waypoint waypoint;
			if (Information.IsNothing(waypoint_0))
			{
				waypoint = new Waypoint(double_1, double_0, 0f, Waypoint.WaypointType.HoldStart, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
			}
			else
			{
				waypoint = waypoint_0;
				waypoint.Type = Waypoint.WaypointType.HoldStart;
			}
			waypoint.Name = Waypoint.GetWaypointTypeString(Waypoint.WaypointType.HoldStart);
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			if (Information.IsNothing(object_0))
			{
				if (Information.IsNothing(aircraftMissionProfile_0))
				{
					waypoint.DesiredAltitude = 609.6f;
				}
				else if (Information.IsNothing(aircraftMissionProfile_0.FormUpAltitude))
				{
					waypoint.DesiredAltitude = 609.6f;
				}
				else
				{
					float num = Terrain.GetElevation(double_0, double_1, bool_0: false, ((ActiveUnit)object_0).ParentScen);
					num = ((num <= 0f) ? 0f : ((float)(Math.Round(num * 3.28084f / 1000f, 0) * 1000.0 / 3.2808399200439453)));
					if (aircraftMissionProfile_0.FormUpAltitude <= 0f)
					{
						waypoint.DesiredAltitude = 609.6f + num;
					}
					else
					{
						waypoint.DesiredAltitude = aircraftMissionProfile_0.FormUpAltitude + num;
					}
				}
			}
			else
			{
				waypoint.DesiredAltitude = ((Aircraft)object_0).AI.VisitClient(ref double_0, ref double_1);
			}
			float_0 = waypoint.DesiredAltitude.Value;
			float_1 = 0f;
			bool_0 = false;
			if (Information.IsNothing(object_0))
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			else
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Loiter;
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			if (Information.IsNothing(object_0))
			{
				waypoint.DesiredSpeed = 500f;
				waypoint.DesiredSpeedOverride = waypoint.DesiredSpeed;
			}
			else if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
			{
				waypoint.DesiredSpeed = ((Aircraft)object_0).Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			else
			{
				waypoint.DesiredSpeed = ((Aircraft)object_0).Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			if (!Information.IsNothing(waypoint.DesiredSpeed))
			{
				float_2 = waypoint.DesiredSpeed.Value;
			}
			if (Information.IsNothing(waypoint.Time_Zulu))
			{
				waypoint.TimeFixed = Waypoint.FixedFree.None;
			}
			if (Information.IsNothing(object_0))
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
			waypoint.SpeedAdjustmentToT = speedToT_0;
			waypoint.FlightFormation = formation_0;
			waypoint.DesiredAltitudeOverride = true;
			waypoint.TurnRate_Navigation = turnRateCategory_0;
			if (Information.IsNothing(waypoint_0))
			{
				ArrayExtensions.Add(ref waypoint_1, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101402", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static Waypoint PushTokenizer(Waypoint waypoint_0, Aircraft aircraft_0, ref Waypoint[] waypoint_1, double double_0, double double_1, AircraftMissionProfile aircraftMissionProfile_0, ref float float_0, ref float float_1, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref float float_2, ref Waypoint.Formation formation_0, Waypoint.TurnRateCategory turnRateCategory_0, ref Mission mission_0, ref bool bool_1, int int_0)
	{
		try
		{
			Waypoint waypoint;
			if (Information.IsNothing(waypoint_0))
			{
				waypoint = new Waypoint(double_1, double_0, 0f, Waypoint.WaypointType.HoldEnd, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
			}
			else
			{
				waypoint = waypoint_0;
				waypoint.Type = Waypoint.WaypointType.HoldEnd;
			}
			waypoint.Name = Waypoint.GetWaypointTypeString(Waypoint.WaypointType.HoldEnd);
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			if (!Information.IsNothing(aircraft_0) && aircraftMissionProfile_0.CruiseAtOptimumAltitude)
			{
				Waypoint waypoint2 = waypoint;
				bool bool_2 = false;
				waypoint2.DesiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_0, ActiveUnit.Throttle.Cruise, ref bool_2);
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			else if (aircraftMissionProfile_0.CruiseAltitudeIngressTerrainFollowing)
			{
				waypoint.TerrainFollowing = true;
				waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.CruiseAltitudeIngress;
				float_0 = 0f;
				float_1 = waypoint.DesiredAltitude_TerrainFollowing.Value;
				bool_0 = waypoint.TerrainFollowing;
			}
			else
			{
				waypoint.DesiredAltitude = aircraftMissionProfile_0.CruiseAltitudeIngress;
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			if (bool_1)
			{
				if (Information.IsNothing(mission_0.TakeOffTime))
				{
					if (!Information.IsNothing(mission_0.TimeOnTarget))
					{
						waypoint.Time_Zulu = mission_0.TimeOnTarget;
					}
				}
				else
				{
					waypoint.Time_Zulu = mission_0.TakeOffTime;
				}
			}
			if (Information.IsNothing(aircraft_0))
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			else
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.CruiseThrottleSettingIngress;
				if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
				{
					unitThrottlePreset_0 = waypoint.ThrottlePreset;
				}
				else if (!Information.IsNothing(unitThrottlePreset_0) && unitThrottlePreset_0 != ActiveUnit_Kinematics.UnitThrottlePreset.None && unitThrottlePreset_0 != 0)
				{
					waypoint.ThrottlePreset = unitThrottlePreset_0;
				}
				else
				{
					waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
					unitThrottlePreset_0 = waypoint.ThrottlePreset;
				}
			}
			if (Information.IsNothing(aircraft_0))
			{
				waypoint.DesiredSpeed = 500f;
				waypoint.DesiredSpeedOverride = waypoint.DesiredSpeed;
			}
			else if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			else
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			if (!Information.IsNothing(waypoint.DesiredSpeed))
			{
				float_2 = waypoint.DesiredSpeed.Value;
			}
			if (Information.IsNothing(waypoint.Time_Zulu))
			{
				waypoint.TimeFixed = Waypoint.FixedFree.None;
			}
			if (Information.IsNothing(aircraft_0))
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
			waypoint.SpeedAdjustmentToT = Waypoint.SpeedToT.No;
			waypoint.FlightFormation = formation_0;
			waypoint.DesiredAltitudeOverride = true;
			waypoint.TurnRate_Navigation = turnRateCategory_0;
			if (int_0 <= 0)
			{
				if (aircraftMissionProfile_0.FormUpTime > 0)
				{
					waypoint.Hold_Time = aircraftMissionProfile_0.FormUpTime * 60;
				}
			}
			else
			{
				waypoint.Hold_Time = int_0 * 60;
			}
			if (Information.IsNothing(waypoint_0))
			{
				ArrayExtensions.Add(ref waypoint_1, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static Waypoint InvokeTokenizer(Waypoint waypoint_0, Aircraft aircraft_0, ref Waypoint[] waypoint_1, double double_0, double double_1, AircraftMissionProfile aircraftMissionProfile_0, Mission._RadarBehaviour _RadarBehaviour_0, ref float float_0, ref float float_1, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref float float_2, ref Waypoint.Formation formation_0, Waypoint.TurnRateCategory turnRateCategory_0, Waypoint.SpeedToT speedToT_0)
	{
		try
		{
			Waypoint waypoint;
			if (Information.IsNothing(waypoint_0))
			{
				waypoint = new Waypoint(double_1, double_0, 0f, Waypoint.WaypointType.StrikeIngress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
			}
			else
			{
				waypoint = waypoint_0;
				waypoint.Type = Waypoint.WaypointType.StrikeIngress;
			}
			waypoint.Name = Waypoint.GetWaypointTypeString(Waypoint.WaypointType.StrikeIngress);
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			if (aircraftMissionProfile_0.CruiseAtOptimumAltitude)
			{
				Waypoint waypoint2 = waypoint;
				bool bool_ = false;
				waypoint2.DesiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_0, ActiveUnit.Throttle.Cruise, ref bool_);
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			else if (aircraftMissionProfile_0.AttackDistanceIngress > 0 && aircraftMissionProfile_0.AttackAltitudeIngress > 0f)
			{
				if (aircraftMissionProfile_0.AttackAltitudeIngressTerrainFollowing)
				{
					waypoint.TerrainFollowing = true;
					waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.AttackAltitudeIngress;
					float_0 = 0f;
					float_1 = waypoint.DesiredAltitude_TerrainFollowing.Value;
					bool_0 = waypoint.TerrainFollowing;
				}
				else
				{
					waypoint.DesiredAltitude = aircraftMissionProfile_0.AttackAltitudeIngress;
					float_0 = waypoint.DesiredAltitude.Value;
					float_1 = 0f;
					bool_0 = false;
				}
			}
			else if (aircraftMissionProfile_0.CruiseAltitudeIngressTerrainFollowing)
			{
				waypoint.TerrainFollowing = true;
				waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.CruiseAltitudeIngress;
				float_0 = 0f;
				float_1 = waypoint.DesiredAltitude_TerrainFollowing.Value;
				bool_0 = waypoint.TerrainFollowing;
			}
			else
			{
				waypoint.DesiredAltitude = aircraftMissionProfile_0.CruiseAltitudeIngress;
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			if (aircraftMissionProfile_0.AttackThrottleSetting != 0 && aircraftMissionProfile_0.AttackDistanceIngress > 0)
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.AttackThrottleSetting;
			}
			else
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.CruiseThrottleSettingIngress;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			else if (!Information.IsNothing(unitThrottlePreset_0) && unitThrottlePreset_0 != ActiveUnit_Kinematics.UnitThrottlePreset.None && unitThrottlePreset_0 != 0)
			{
				waypoint.ThrottlePreset = unitThrottlePreset_0;
			}
			else
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			else
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			if (!Information.IsNothing(waypoint.DesiredSpeed))
			{
				float_2 = waypoint.DesiredSpeed.Value;
			}
			if (Information.IsNothing(waypoint.Time_Zulu))
			{
				waypoint.TimeFixed = Waypoint.FixedFree.None;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
			waypoint.SpeedAdjustmentToT = speedToT_0;
			waypoint.FlightFormation = formation_0;
			waypoint.DesiredAltitudeOverride = true;
			waypoint.TurnRate_Navigation = turnRateCategory_0;
			if (!Information.IsNothing(_RadarBehaviour_0) && _RadarBehaviour_0 == Mission._RadarBehaviour.ActiveOnAttackIngressAndIP)
			{
				waypoint.Doctrine.SetEMCON(Doctrine.EMCONSettings._EMCONSetting.Active, Doctrine.EMCONSettings._EMCONSetting.NotConfigured, Doctrine.EMCONSettings._EMCONSetting.NotConfigured);
			}
			if (Information.IsNothing(waypoint_0))
			{
				ArrayExtensions.Add(ref waypoint_1, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101403", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static Waypoint SetupTokenizer(Waypoint waypoint_0, Aircraft aircraft_0, ref Waypoint[] waypoint_1, double double_0, double double_1, AircraftMissionProfile aircraftMissionProfile_0, Mission._RadarBehaviour _RadarBehaviour_0, ref float float_0, ref float float_1, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref float float_2, ref Mission._AttackMethod _AttackMethod_0, ref Waypoint.Formation formation_0, Waypoint.TurnRateCategory turnRateCategory_0, Waypoint.SpeedToT speedToT_0)
	{
		try
		{
			Waypoint waypoint;
			if (Information.IsNothing(waypoint_0))
			{
				waypoint = new Waypoint(double_1, double_0, 0f, Waypoint.WaypointType.StrikeIngress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
			}
			else
			{
				waypoint = waypoint_0;
				waypoint.Type = Waypoint.WaypointType.StrikeIngress;
			}
			waypoint.Name = Waypoint.GetWaypointTypeString(Waypoint.WaypointType.StrikeIngress);
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			if (aircraftMissionProfile_0.CruiseAtOptimumAltitude)
			{
				Waypoint waypoint2 = waypoint;
				bool bool_ = false;
				waypoint2.DesiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_0, ActiveUnit.Throttle.Cruise, ref bool_);
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			else if (aircraftMissionProfile_0.AttackDistanceIngress > 0 && aircraftMissionProfile_0.AttackAltitudeIngress > 0f)
			{
				if (aircraftMissionProfile_0.AttackAltitudeIngressTerrainFollowing)
				{
					waypoint.TerrainFollowing = true;
					waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.AttackAltitudeIngress;
					float_0 = 0f;
					float_1 = waypoint.DesiredAltitude_TerrainFollowing.Value;
					bool_0 = waypoint.TerrainFollowing;
				}
				else
				{
					waypoint.DesiredAltitude = aircraftMissionProfile_0.AttackAltitudeIngress;
					float_0 = waypoint.DesiredAltitude.Value;
					float_1 = 0f;
					bool_0 = false;
				}
			}
			else if (aircraftMissionProfile_0.CruiseAltitudeIngressTerrainFollowing)
			{
				waypoint.TerrainFollowing = true;
				waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.CruiseAltitudeIngress;
				float_0 = 0f;
				float_1 = waypoint.DesiredAltitude_TerrainFollowing.Value;
				bool_0 = waypoint.TerrainFollowing;
			}
			else
			{
				waypoint.DesiredAltitude = aircraftMissionProfile_0.CruiseAltitudeIngress;
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			if (aircraftMissionProfile_0.AttackThrottleSetting != 0 && aircraftMissionProfile_0.AttackDistanceIngress > 0)
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.AttackThrottleSetting;
			}
			else
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.CruiseThrottleSettingIngress;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			else if (!Information.IsNothing(unitThrottlePreset_0) && unitThrottlePreset_0 != ActiveUnit_Kinematics.UnitThrottlePreset.None && unitThrottlePreset_0 != 0)
			{
				waypoint.ThrottlePreset = unitThrottlePreset_0;
			}
			else
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			else
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			if (!Information.IsNothing(waypoint.DesiredSpeed))
			{
				float_2 = waypoint.DesiredSpeed.Value;
			}
			if (Information.IsNothing(waypoint.Time_Zulu))
			{
				waypoint.TimeFixed = Waypoint.FixedFree.None;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
			waypoint.SpeedAdjustmentToT = speedToT_0;
			waypoint.FlightFormation = Waypoint.Formation.Spread;
			if ((uint)(_AttackMethod_0 - 4) <= 10u)
			{
				formation_0 = Waypoint.Formation.Split;
			}
			else
			{
				formation_0 = Waypoint.Formation.Spread;
			}
			waypoint.DesiredAltitudeOverride = true;
			waypoint.TurnRate_Navigation = turnRateCategory_0;
			if (!Information.IsNothing(_RadarBehaviour_0) && _RadarBehaviour_0 == Mission._RadarBehaviour.ActiveOnAttackIngressAndIP)
			{
				waypoint.Doctrine.SetEMCON(Doctrine.EMCONSettings._EMCONSetting.Active, Doctrine.EMCONSettings._EMCONSetting.NotConfigured, Doctrine.EMCONSettings._EMCONSetting.NotConfigured);
			}
			if (Information.IsNothing(waypoint_0))
			{
				ArrayExtensions.Add(ref waypoint_1, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101404", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static Waypoint ExcludeTokenizer(Waypoint waypoint_0, Aircraft aircraft_0, ref Waypoint[] waypoint_1, double double_0, double double_1, AircraftMissionProfile aircraftMissionProfile_0, Mission._RadarBehaviour _RadarBehaviour_0, ref float float_0, ref float float_1, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref float float_2, ref Mission._AttackMethod _AttackMethod_0, ref Waypoint.Formation formation_0, ref float float_3, Waypoint.TurnRateCategory turnRateCategory_0, Waypoint.SpeedToT speedToT_0)
	{
		try
		{
			Waypoint waypoint;
			if (Information.IsNothing(waypoint_0))
			{
				waypoint = new Waypoint(double_1, double_0, 0f, Waypoint.WaypointType.StrikeIngress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
			}
			else
			{
				waypoint = waypoint_0;
				waypoint.Type = Waypoint.WaypointType.StrikeIngress;
			}
			waypoint.Name = Waypoint.GetWaypointTypeString(Waypoint.WaypointType.StrikeIngress);
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			if (aircraftMissionProfile_0.CruiseAtOptimumAltitude)
			{
				Waypoint waypoint2 = waypoint;
				bool bool_ = false;
				waypoint2.DesiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_0, ActiveUnit.Throttle.Cruise, ref bool_);
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			else if (aircraftMissionProfile_0.AttackDistanceIngress > 0 && aircraftMissionProfile_0.AttackAltitudeIngress > 0f)
			{
				if (aircraftMissionProfile_0.AttackAltitudeIngressTerrainFollowing)
				{
					waypoint.TerrainFollowing = true;
					waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.AttackAltitudeIngress;
					float_0 = 0f;
					float_1 = waypoint.DesiredAltitude_TerrainFollowing.Value;
					bool_0 = waypoint.TerrainFollowing;
				}
				else
				{
					waypoint.DesiredAltitude = aircraftMissionProfile_0.AttackAltitudeIngress;
					float_0 = waypoint.DesiredAltitude.Value;
					float_1 = 0f;
					bool_0 = false;
				}
			}
			else if (aircraftMissionProfile_0.CruiseAltitudeIngressTerrainFollowing)
			{
				waypoint.TerrainFollowing = true;
				waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.CruiseAltitudeIngress;
				float_0 = 0f;
				float_1 = waypoint.DesiredAltitude_TerrainFollowing.Value;
				bool_0 = waypoint.TerrainFollowing;
			}
			else
			{
				waypoint.DesiredAltitude = aircraftMissionProfile_0.CruiseAltitudeIngress;
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			if (aircraftMissionProfile_0.AttackThrottleSetting != 0 && aircraftMissionProfile_0.AttackDistanceIngress > 0)
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.AttackThrottleSetting;
			}
			else
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.CruiseThrottleSettingIngress;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			else if (!Information.IsNothing(unitThrottlePreset_0) && unitThrottlePreset_0 != ActiveUnit_Kinematics.UnitThrottlePreset.None && unitThrottlePreset_0 != 0)
			{
				waypoint.ThrottlePreset = unitThrottlePreset_0;
			}
			else
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			else
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			if (!Information.IsNothing(waypoint.DesiredSpeed))
			{
				float_2 = waypoint.DesiredSpeed.Value;
			}
			if (Information.IsNothing(waypoint.Time_Zulu))
			{
				waypoint.TimeFixed = Waypoint.FixedFree.None;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
			waypoint.SpeedAdjustmentToT = speedToT_0;
			waypoint.FlightFormation = formation_0;
			waypoint.DesiredAltitudeOverride = true;
			waypoint.SpacingManeuver_Time = float_3;
			waypoint.TurnRate_Navigation = turnRateCategory_0;
			if (!Information.IsNothing(_RadarBehaviour_0) && _RadarBehaviour_0 == Mission._RadarBehaviour.ActiveOnAttackIngressAndIP)
			{
				waypoint.Doctrine.SetEMCON(Doctrine.EMCONSettings._EMCONSetting.Active, Doctrine.EMCONSettings._EMCONSetting.NotConfigured, Doctrine.EMCONSettings._EMCONSetting.NotConfigured);
			}
			if (Information.IsNothing(waypoint_0))
			{
				ArrayExtensions.Add(ref waypoint_1, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101405", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static Waypoint IncludeTokenizer(Waypoint waypoint_0, Aircraft aircraft_0, ref Waypoint[] waypoint_1, double double_0, double double_1, AircraftMissionProfile aircraftMissionProfile_0, Mission._RadarBehaviour _RadarBehaviour_0, float float_0, ref float float_1, ref float float_2, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref float float_3, ref Mission._AttackMethod _AttackMethod_0, ref Waypoint.Formation formation_0, Waypoint.TurnRateCategory turnRateCategory_0, Waypoint.SpeedToT speedToT_0, object object_0, Module_Unit.Unit unit_0)
	{
		try
		{
			Waypoint.WaypointType waypointType = (Weapon.IsStandOff(float_0) ? Waypoint.WaypointType.WeaponLaunch : Waypoint.WaypointType.InitialPoint);
			Waypoint waypoint;
			if (Information.IsNothing(waypoint_0))
			{
				waypoint = new Waypoint(double_1, double_0, 0f, waypointType, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
			}
			else
			{
				waypoint = waypoint_0;
				waypoint.Type = waypointType;
			}
			waypoint.Name = Waypoint.GetWaypointTypeString(waypointType);
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			if (aircraftMissionProfile_0.CruiseAtOptimumAltitude)
			{
				Waypoint waypoint2 = waypoint;
				bool bool_ = false;
				waypoint2.DesiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_0, ActiveUnit.Throttle.Cruise, ref bool_);
				float_1 = waypoint.DesiredAltitude.Value;
				float_2 = 0f;
				bool_0 = false;
			}
			else if (aircraftMissionProfile_0.AttackDistanceIngress > 0 && aircraftMissionProfile_0.AttackAltitudeIngress > 0f)
			{
				if (aircraftMissionProfile_0.AttackAltitudeIngressTerrainFollowing)
				{
					waypoint.TerrainFollowing = true;
					waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.AttackAltitudeIngress;
					float_1 = 0f;
					float_2 = waypoint.DesiredAltitude_TerrainFollowing.Value;
					bool_0 = waypoint.TerrainFollowing;
				}
				else
				{
					waypoint.DesiredAltitude = aircraftMissionProfile_0.AttackAltitudeIngress;
					float_1 = waypoint.DesiredAltitude.Value;
					float_2 = 0f;
					bool_0 = false;
				}
			}
			else if (aircraftMissionProfile_0.CruiseAltitudeIngressTerrainFollowing)
			{
				waypoint.TerrainFollowing = true;
				waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.CruiseAltitudeIngress;
				float_1 = 0f;
				float_2 = waypoint.DesiredAltitude_TerrainFollowing.Value;
				bool_0 = waypoint.TerrainFollowing;
			}
			else
			{
				waypoint.DesiredAltitude = aircraftMissionProfile_0.CruiseAltitudeIngress;
				float_1 = waypoint.DesiredAltitude.Value;
				float_2 = 0f;
				bool_0 = false;
			}
			float? desiredAltitude_TerrainFollowing = waypoint.DesiredAltitude_TerrainFollowing;
			float minLaunchAlt_AGL = ((Weapon)object_0).MinLaunchAlt_AGL;
			if ((desiredAltitude_TerrainFollowing.HasValue ? new bool?(desiredAltitude_TerrainFollowing.GetValueOrDefault() < minLaunchAlt_AGL) : null).GetValueOrDefault())
			{
				waypoint.DesiredAltitude_TerrainFollowing = ((Weapon)object_0).MinLaunchAlt_AGL + unit_0.GetCurrentAltitude();
				waypoint.DesiredAltitude = ((Weapon)object_0).MinLaunchAlt_AGL + unit_0.GetCurrentAltitude();
			}
			else
			{
				desiredAltitude_TerrainFollowing = waypoint.DesiredAltitude_TerrainFollowing;
				minLaunchAlt_AGL = ((Weapon)object_0).MaxLaunchAlt_AGL;
				bool? flag = (desiredAltitude_TerrainFollowing.HasValue ? new bool?(desiredAltitude_TerrainFollowing.GetValueOrDefault() > minLaunchAlt_AGL) : null);
				if (((((Weapon)object_0).MaxLaunchAlt_AGL == 0f) ? new bool?(false) : flag).GetValueOrDefault())
				{
					waypoint.DesiredAltitude_TerrainFollowing = ((Weapon)object_0).MaxLaunchAlt_AGL + unit_0.GetCurrentAltitude();
					waypoint.DesiredAltitude = ((Weapon)object_0).MaxLaunchAlt_AGL + unit_0.GetCurrentAltitude();
				}
			}
			waypoint.ReferenceWeapon_ID = ((ActiveUnit)object_0).DBID;
			if (aircraftMissionProfile_0.AttackThrottleSetting != 0 && aircraftMissionProfile_0.AttackDistanceIngress > 0)
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.AttackThrottleSetting;
			}
			else
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.CruiseThrottleSettingIngress;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			else if (!Information.IsNothing(unitThrottlePreset_0) && unitThrottlePreset_0 != ActiveUnit_Kinematics.UnitThrottlePreset.None && unitThrottlePreset_0 != 0)
			{
				waypoint.ThrottlePreset = unitThrottlePreset_0;
			}
			else
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			else
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			if (!Information.IsNothing(waypoint.DesiredSpeed))
			{
				float_3 = waypoint.DesiredSpeed.Value;
			}
			if (Information.IsNothing(waypoint.Time_Zulu))
			{
				waypoint.TimeFixed = Waypoint.FixedFree.None;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
			waypoint.SpeedAdjustmentToT = speedToT_0;
			waypoint.FlightFormation = formation_0;
			waypoint.TurnRate_Navigation = turnRateCategory_0;
			waypoint.DesiredAltitudeOverride = true;
			if (!Information.IsNothing(_RadarBehaviour_0) && (_RadarBehaviour_0 == Mission._RadarBehaviour.ActiveOnIP || _RadarBehaviour_0 == Mission._RadarBehaviour.ActiveOnAttackIngressAndIP))
			{
				waypoint.Doctrine.SetEMCON(Doctrine.EMCONSettings._EMCONSetting.Active, Doctrine.EMCONSettings._EMCONSetting.NotConfigured, Doctrine.EMCONSettings._EMCONSetting.NotConfigured);
			}
			if (Information.IsNothing(waypoint_0))
			{
				ArrayExtensions.Add(ref waypoint_1, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101406", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static Waypoint SearchTokenizer(Waypoint waypoint_0, Aircraft aircraft_0, ref Waypoint[] waypoint_1, double double_0, double double_1, AircraftMissionProfile aircraftMissionProfile_0, Mission._RadarBehaviour _RadarBehaviour_0, float float_0, ref float float_1, ref float float_2, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref float float_3, ref Mission._AttackMethod _AttackMethod_0, ref Waypoint.Formation formation_0, Waypoint.TurnRateCategory turnRateCategory_0, object object_0, Waypoint.SpeedToT speedToT_0, float float_4, object object_1, Module_Unit.Unit unit_0)
	{
		try
		{
			Waypoint.WaypointType waypointType = ((float_0 < 6f) ? Waypoint.WaypointType.Target : Waypoint.WaypointType.WeaponTarget);
			Waypoint waypoint;
			if (Information.IsNothing(waypoint_0))
			{
				waypoint = new Waypoint(double_1, double_0, 0f, waypointType, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
			}
			else
			{
				waypoint = waypoint_0;
				waypoint.Type = waypointType;
			}
			waypoint.Name = Waypoint.GetWaypointTypeString(waypointType);
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			if (_AttackMethod_0 <= Mission._AttackMethod.EchelonAtActionPoint)
			{
				waypoint.AttackMethod = _AttackMethod_0;
			}
			else
			{
				waypoint.AttackMethod = Mission._AttackMethod.None;
			}
			waypoint.Separation_Time = float_4;
			if (aircraftMissionProfile_0.CruiseAtOptimumAltitude)
			{
				Waypoint waypoint2 = waypoint;
				bool bool_ = false;
				waypoint2.DesiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_0, ActiveUnit.Throttle.Cruise, ref bool_);
				float_1 = waypoint.DesiredAltitude.Value;
				float_2 = 0f;
				bool_0 = false;
			}
			else if (aircraftMissionProfile_0.AttackDistanceEgress > 0 && aircraftMissionProfile_0.AttackAltitudeEgress > 0f)
			{
				if (aircraftMissionProfile_0.AttackAltitudeEgressTerrainFollowing)
				{
					waypoint.TerrainFollowing = true;
					waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.AttackAltitudeEgress;
					float_1 = 0f;
					float_2 = waypoint.DesiredAltitude_TerrainFollowing.Value;
					bool_0 = waypoint.TerrainFollowing;
				}
				else
				{
					waypoint.DesiredAltitude = aircraftMissionProfile_0.AttackAltitudeEgress;
					float_1 = waypoint.DesiredAltitude.Value;
					float_2 = 0f;
					bool_0 = false;
				}
			}
			else if (aircraftMissionProfile_0.CruiseAltitudeEgressTerrainFollowing)
			{
				waypoint.TerrainFollowing = true;
				waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.CruiseAltitudeEgress;
				float_1 = 0f;
				float_2 = waypoint.DesiredAltitude_TerrainFollowing.Value;
				bool_0 = waypoint.TerrainFollowing;
			}
			else
			{
				waypoint.DesiredAltitude = aircraftMissionProfile_0.CruiseAltitudeEgress;
				float_1 = waypoint.DesiredAltitude.Value;
				float_2 = 0f;
				bool_0 = false;
			}
			float? desiredAltitude_TerrainFollowing = waypoint.DesiredAltitude_TerrainFollowing;
			float minLaunchAlt_AGL = ((Weapon)object_1).MinLaunchAlt_AGL;
			if ((desiredAltitude_TerrainFollowing.HasValue ? new bool?(desiredAltitude_TerrainFollowing.GetValueOrDefault() < minLaunchAlt_AGL) : null).GetValueOrDefault())
			{
				waypoint.DesiredAltitude_TerrainFollowing = ((Weapon)object_1).MinLaunchAlt_AGL + unit_0.GetCurrentAltitude();
				waypoint.DesiredAltitude = ((Weapon)object_1).MinLaunchAlt_AGL + unit_0.GetCurrentAltitude();
			}
			else
			{
				desiredAltitude_TerrainFollowing = waypoint.DesiredAltitude_TerrainFollowing;
				minLaunchAlt_AGL = ((Weapon)object_1).MaxLaunchAlt_AGL;
				bool? flag = (desiredAltitude_TerrainFollowing.HasValue ? new bool?(desiredAltitude_TerrainFollowing.GetValueOrDefault() > minLaunchAlt_AGL) : null);
				if (((((Weapon)object_1).MaxLaunchAlt_AGL == 0f) ? new bool?(false) : flag).GetValueOrDefault())
				{
					waypoint.DesiredAltitude_TerrainFollowing = ((Weapon)object_1).MaxLaunchAlt_AGL + unit_0.GetCurrentAltitude();
					waypoint.DesiredAltitude = ((Weapon)object_1).MaxLaunchAlt_AGL + unit_0.GetCurrentAltitude();
				}
			}
			waypoint.ReferenceWeapon_ID = ((ActiveUnit)object_1).DBID;
			if (aircraftMissionProfile_0.AttackThrottleSetting != 0 && aircraftMissionProfile_0.AttackDistanceEgress > 0)
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.AttackThrottleSetting;
			}
			else
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.CruiseThrottleSettingIngress;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			else if (!Information.IsNothing(unitThrottlePreset_0) && unitThrottlePreset_0 != ActiveUnit_Kinematics.UnitThrottlePreset.None && unitThrottlePreset_0 != 0)
			{
				waypoint.ThrottlePreset = unitThrottlePreset_0;
			}
			else
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			else
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			if (!Information.IsNothing(waypoint.DesiredSpeed))
			{
				float_3 = waypoint.DesiredSpeed.Value;
			}
			if (Information.IsNothing(waypoint.Time_Zulu))
			{
				waypoint.TimeFixed = Waypoint.FixedFree.None;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
			waypoint.SpeedAdjustmentToT = speedToT_0;
			waypoint.FlightFormation = formation_0;
			waypoint.TurnRate_Navigation = turnRateCategory_0;
			waypoint.DesiredAltitudeOverride = true;
			if (!Information.IsNothing(_RadarBehaviour_0) && (_RadarBehaviour_0 == Mission._RadarBehaviour.ActiveOnIP || _RadarBehaviour_0 == Mission._RadarBehaviour.ActiveOnAttackIngressAndIP))
			{
				waypoint.Doctrine.SetEMCON(Doctrine.EMCONSettings._EMCONSetting.NotConfigured, Doctrine.EMCONSettings._EMCONSetting.NotConfigured, Doctrine.EMCONSettings._EMCONSetting.NotConfigured);
			}
			Waypoint[] obj = waypoint_1;
			Waypoint waypoint3 = null;
			Waypoint[] array = obj;
			Waypoint[] array2 = array;
			foreach (Waypoint waypoint4 in array2)
			{
				if (waypoint4.Type == Waypoint.WaypointType.WeaponLaunch)
				{
					waypoint3.DesiredAltitude_TerrainFollowing = waypoint4.DesiredAltitude_TerrainFollowing;
					waypoint3.DesiredAltitude = waypoint4.DesiredAltitude;
				}
				waypoint3 = waypoint4;
			}
			if (Information.IsNothing(waypoint_0))
			{
				ArrayExtensions.Add(ref waypoint_1, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101407", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static Waypoint EnableTokenizer(Waypoint waypoint_0, Aircraft aircraft_0, ref Waypoint[] waypoint_1, double double_0, double double_1, AircraftMissionProfile aircraftMissionProfile_0, ref float float_0, ref float float_1, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref float float_2, ref Mission._AttackMethod _AttackMethod_0, ref Waypoint.Formation formation_0, ref float float_3, Waypoint.TurnRateCategory turnRateCategory_0, Waypoint.SpeedToT speedToT_0)
	{
		try
		{
			Waypoint waypoint;
			if (Information.IsNothing(waypoint_0))
			{
				waypoint = new Waypoint(double_1, double_0, 0f, Waypoint.WaypointType.StrikeEgress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
			}
			else
			{
				waypoint = waypoint_0;
				waypoint.Type = Waypoint.WaypointType.StrikeEgress;
			}
			waypoint.Name = Waypoint.GetWaypointTypeString(Waypoint.WaypointType.StrikeEgress);
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			if (aircraftMissionProfile_0.CruiseAtOptimumAltitude)
			{
				Waypoint waypoint2 = waypoint;
				bool bool_ = false;
				waypoint2.DesiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_0, ActiveUnit.Throttle.Cruise, ref bool_);
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			else if (aircraftMissionProfile_0.AttackDistanceEgress > 0 && aircraftMissionProfile_0.AttackAltitudeEgress > 0f)
			{
				if (aircraftMissionProfile_0.AttackAltitudeEgressTerrainFollowing)
				{
					waypoint.TerrainFollowing = true;
					waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.AttackAltitudeEgress;
					float_0 = 0f;
					float_1 = waypoint.DesiredAltitude_TerrainFollowing.Value;
					bool_0 = waypoint.TerrainFollowing;
				}
				else
				{
					waypoint.DesiredAltitude = aircraftMissionProfile_0.AttackAltitudeEgress;
					float_0 = waypoint.DesiredAltitude.Value;
					float_1 = 0f;
					bool_0 = false;
				}
			}
			else if (aircraftMissionProfile_0.CruiseAltitudeEgressTerrainFollowing)
			{
				waypoint.TerrainFollowing = true;
				waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.CruiseAltitudeEgress;
				float_0 = 0f;
				float_1 = waypoint.DesiredAltitude_TerrainFollowing.Value;
				bool_0 = waypoint.TerrainFollowing;
			}
			else
			{
				waypoint.DesiredAltitude = aircraftMissionProfile_0.CruiseAltitudeEgress;
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			if (aircraftMissionProfile_0.AttackThrottleSetting != 0 && aircraftMissionProfile_0.AttackDistanceEgress > 0)
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.AttackThrottleSetting;
			}
			else
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.CruiseThrottleSettingIngress;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			else if (!Information.IsNothing(unitThrottlePreset_0) && unitThrottlePreset_0 != ActiveUnit_Kinematics.UnitThrottlePreset.None && unitThrottlePreset_0 != 0)
			{
				waypoint.ThrottlePreset = unitThrottlePreset_0;
			}
			else
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			else
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			if (!Information.IsNothing(waypoint.DesiredSpeed))
			{
				float_2 = waypoint.DesiredSpeed.Value;
			}
			if (Information.IsNothing(waypoint.Time_Zulu))
			{
				waypoint.TimeFixed = Waypoint.FixedFree.None;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
			waypoint.SpeedAdjustmentToT = speedToT_0;
			waypoint.FlightFormation = Waypoint.Formation.Spread;
			formation_0 = waypoint.FlightFormation;
			waypoint.DesiredAltitudeOverride = true;
			waypoint.SpacingManeuver_Time = float_3;
			waypoint.TurnRate_Navigation = turnRateCategory_0;
			if (Information.IsNothing(waypoint_0))
			{
				ArrayExtensions.Add(ref waypoint_1, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101408", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static Waypoint ChangeTokenizer(Waypoint waypoint_0, Aircraft aircraft_0, ref Waypoint[] waypoint_1, double double_0, double double_1, AircraftMissionProfile aircraftMissionProfile_0, ref float float_0, ref float float_1, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref float float_2, ref Mission._AttackMethod _AttackMethod_0, ref Waypoint.Formation formation_0, Waypoint.TurnRateCategory turnRateCategory_0, Waypoint.SpeedToT speedToT_0)
	{
		try
		{
			Waypoint waypoint;
			if (Information.IsNothing(waypoint_0))
			{
				waypoint = new Waypoint(double_1, double_0, 0f, Waypoint.WaypointType.StrikeEgress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
			}
			else
			{
				waypoint = waypoint_0;
				waypoint.Type = Waypoint.WaypointType.StrikeEgress;
			}
			waypoint.Name = Waypoint.GetWaypointTypeString(Waypoint.WaypointType.StrikeEgress);
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			if (aircraftMissionProfile_0.CruiseAtOptimumAltitude)
			{
				Waypoint waypoint2 = waypoint;
				bool bool_ = false;
				waypoint2.DesiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_0, ActiveUnit.Throttle.Cruise, ref bool_);
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			else if (aircraftMissionProfile_0.AttackDistanceEgress > 0 && aircraftMissionProfile_0.AttackAltitudeEgress > 0f)
			{
				if (aircraftMissionProfile_0.AttackAltitudeEgressTerrainFollowing)
				{
					waypoint.TerrainFollowing = true;
					waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.AttackAltitudeEgress;
					float_0 = 0f;
					float_1 = waypoint.DesiredAltitude_TerrainFollowing.Value;
					bool_0 = waypoint.TerrainFollowing;
				}
				else
				{
					waypoint.DesiredAltitude = aircraftMissionProfile_0.AttackAltitudeEgress;
					float_0 = waypoint.DesiredAltitude.Value;
					float_1 = 0f;
					bool_0 = false;
				}
			}
			else if (aircraftMissionProfile_0.CruiseAltitudeEgressTerrainFollowing)
			{
				waypoint.TerrainFollowing = true;
				waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.CruiseAltitudeEgress;
				float_0 = 0f;
				float_1 = waypoint.DesiredAltitude_TerrainFollowing.Value;
				bool_0 = waypoint.TerrainFollowing;
			}
			else
			{
				waypoint.DesiredAltitude = aircraftMissionProfile_0.CruiseAltitudeEgress;
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			if (aircraftMissionProfile_0.AttackThrottleSetting != 0 && aircraftMissionProfile_0.AttackDistanceEgress > 0)
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.AttackThrottleSetting;
			}
			else
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.CruiseThrottleSettingIngress;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			else if (!Information.IsNothing(unitThrottlePreset_0) && unitThrottlePreset_0 != ActiveUnit_Kinematics.UnitThrottlePreset.None && unitThrottlePreset_0 != 0)
			{
				waypoint.ThrottlePreset = unitThrottlePreset_0;
			}
			else
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			else
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			if (!Information.IsNothing(waypoint.DesiredSpeed))
			{
				float_2 = waypoint.DesiredSpeed.Value;
			}
			if (Information.IsNothing(waypoint.Time_Zulu))
			{
				waypoint.TimeFixed = Waypoint.FixedFree.None;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
			waypoint.SpeedAdjustmentToT = speedToT_0;
			waypoint.FlightFormation = formation_0;
			waypoint.TurnRate_Navigation = turnRateCategory_0;
			waypoint.DesiredAltitudeOverride = true;
			if (Information.IsNothing(waypoint_0))
			{
				ArrayExtensions.Add(ref waypoint_1, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101409", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static Waypoint InitTokenizer(Waypoint waypoint_0, Aircraft aircraft_0, ref Waypoint[] waypoint_1, double double_0, double double_1, AircraftMissionProfile aircraftMissionProfile_0, ref float float_0, ref float float_1, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref float float_2, ref Waypoint.Formation formation_0, Waypoint.TurnRateCategory turnRateCategory_0, Waypoint.SpeedToT speedToT_0)
	{
		try
		{
			Waypoint waypoint;
			if (Information.IsNothing(waypoint_0))
			{
				waypoint = new Waypoint(double_1, double_0, 0f, Waypoint.WaypointType.StrikeEgress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
			}
			else
			{
				waypoint = waypoint_0;
				waypoint.Type = Waypoint.WaypointType.StrikeEgress;
			}
			waypoint.Name = Waypoint.GetWaypointTypeString(Waypoint.WaypointType.StrikeEgress);
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			if (aircraftMissionProfile_0.CruiseAtOptimumAltitude)
			{
				Waypoint waypoint2 = waypoint;
				bool bool_ = false;
				waypoint2.DesiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_0, ActiveUnit.Throttle.Cruise, ref bool_);
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			else if (aircraftMissionProfile_0.AttackDistanceEgress > 0 && aircraftMissionProfile_0.AttackAltitudeEgress > 0f)
			{
				if (aircraftMissionProfile_0.AttackAltitudeEgressTerrainFollowing)
				{
					waypoint.TerrainFollowing = true;
					waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.AttackAltitudeEgress;
					float_0 = 0f;
					float_1 = waypoint.DesiredAltitude_TerrainFollowing.Value;
					bool_0 = waypoint.TerrainFollowing;
				}
				else
				{
					waypoint.DesiredAltitude = aircraftMissionProfile_0.AttackAltitudeEgress;
					float_0 = waypoint.DesiredAltitude.Value;
					float_1 = 0f;
					bool_0 = false;
				}
			}
			else if (aircraftMissionProfile_0.CruiseAltitudeEgressTerrainFollowing)
			{
				waypoint.TerrainFollowing = true;
				waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.CruiseAltitudeEgress;
				float_0 = 0f;
				float_1 = waypoint.DesiredAltitude_TerrainFollowing.Value;
				bool_0 = waypoint.TerrainFollowing;
			}
			else
			{
				waypoint.DesiredAltitude = aircraftMissionProfile_0.CruiseAltitudeEgress;
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			if (aircraftMissionProfile_0.AttackThrottleSetting != 0 && aircraftMissionProfile_0.AttackDistanceEgress > 0)
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.AttackThrottleSetting;
			}
			else
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.CruiseThrottleSettingIngress;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			else if (!Information.IsNothing(unitThrottlePreset_0) && unitThrottlePreset_0 != ActiveUnit_Kinematics.UnitThrottlePreset.None && unitThrottlePreset_0 != 0)
			{
				waypoint.ThrottlePreset = unitThrottlePreset_0;
			}
			else
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			else
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			if (!Information.IsNothing(waypoint.DesiredSpeed))
			{
				float_2 = waypoint.DesiredSpeed.Value;
			}
			if (Information.IsNothing(waypoint.Time_Zulu))
			{
				waypoint.TimeFixed = Waypoint.FixedFree.None;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
			waypoint.SpeedAdjustmentToT = speedToT_0;
			waypoint.FlightFormation = formation_0;
			waypoint.DesiredAltitudeOverride = true;
			waypoint.TurnRate_Navigation = turnRateCategory_0;
			if (Information.IsNothing(waypoint_0))
			{
				ArrayExtensions.Add(ref waypoint_1, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101410", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static Waypoint CheckTokenizer(Waypoint waypoint_0, object object_0, ref Waypoint[] waypoint_1, double double_0, double double_1, AircraftMissionProfile aircraftMissionProfile_0, ref float float_0, ref float float_1, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref float float_2, ref Waypoint.Formation formation_0, Waypoint.TurnRateCategory turnRateCategory_0, Waypoint.SpeedToT speedToT_0)
	{
		try
		{
			Waypoint waypoint;
			if (Information.IsNothing(waypoint_0))
			{
				waypoint = new Waypoint(double_1, double_0, 0f, Waypoint.WaypointType.LandingMarshal, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
			}
			else
			{
				waypoint = waypoint_0;
				waypoint.Type = Waypoint.WaypointType.LandingMarshal;
			}
			waypoint.Name = Waypoint.GetWaypointTypeString(Waypoint.WaypointType.LandingMarshal);
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			float num = Terrain.GetElevation(double_0, double_1, bool_0: false, ((ActiveUnit)object_0).ParentScen);
			num = ((num <= 0f) ? 0f : ((float)(Math.Round(num * 3.28084f / 1000f, 0) * 1000.0 / 3.2808399200439453)));
			float num2 = 914.39996f + num;
			if (!Information.IsNothing(object_0) && aircraftMissionProfile_0.CruiseAtOptimumAltitude)
			{
				waypoint.DesiredAltitude = num2;
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			else if (aircraftMissionProfile_0.CruiseAltitudeEgress < num2)
			{
				if (aircraftMissionProfile_0.CruiseAltitudeEgressTerrainFollowing)
				{
					waypoint.TerrainFollowing = true;
					waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.CruiseAltitudeEgress;
					float_0 = 0f;
					float_1 = waypoint.DesiredAltitude_TerrainFollowing.Value;
					bool_0 = waypoint.TerrainFollowing;
				}
				else
				{
					waypoint.DesiredAltitude = aircraftMissionProfile_0.CruiseAltitudeEgress;
					float_0 = waypoint.DesiredAltitude.Value;
					float_1 = 0f;
					bool_0 = false;
				}
			}
			else
			{
				waypoint.DesiredAltitude = num2;
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			if (Information.IsNothing(object_0))
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			else
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.CruiseThrottleSettingEgress;
				if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
				{
					unitThrottlePreset_0 = waypoint.ThrottlePreset;
				}
				else if (!Information.IsNothing(unitThrottlePreset_0) && unitThrottlePreset_0 != ActiveUnit_Kinematics.UnitThrottlePreset.None && unitThrottlePreset_0 != 0)
				{
					waypoint.ThrottlePreset = unitThrottlePreset_0;
				}
				else
				{
					waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
					unitThrottlePreset_0 = waypoint.ThrottlePreset;
				}
			}
			if (Information.IsNothing(object_0))
			{
				waypoint.DesiredSpeed = 500f;
				waypoint.DesiredSpeedOverride = waypoint.DesiredSpeed;
			}
			else if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
			{
				waypoint.DesiredSpeed = ((Aircraft)object_0).Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			else
			{
				waypoint.DesiredSpeed = ((Aircraft)object_0).Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			if (!Information.IsNothing(waypoint.DesiredSpeed))
			{
				float_2 = waypoint.DesiredSpeed.Value;
			}
			if (Information.IsNothing(waypoint.Time_Zulu))
			{
				waypoint.TimeFixed = Waypoint.FixedFree.None;
			}
			if (Information.IsNothing(object_0))
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
			waypoint.SpeedAdjustmentToT = speedToT_0;
			waypoint.FlightFormation = formation_0;
			waypoint.DesiredAltitudeOverride = true;
			waypoint.TurnRate_Navigation = turnRateCategory_0;
			if (Information.IsNothing(waypoint_0))
			{
				ArrayExtensions.Add(ref waypoint_1, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101411", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static Waypoint ConcatTokenizer(Waypoint waypoint_0, object object_0, ref Waypoint[] waypoint_1, double double_0, double double_1, AircraftMissionProfile aircraftMissionProfile_0, ref float float_0, ref float float_1, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref float float_2, ref Waypoint.Formation formation_0, Waypoint.TurnRateCategory turnRateCategory_0)
	{
		try
		{
			Waypoint waypoint;
			if (Information.IsNothing(waypoint_0))
			{
				waypoint = new Waypoint(double_1, double_0, 0f, Waypoint.WaypointType.TakeOff, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
			}
			else
			{
				waypoint = waypoint_0;
				waypoint.Type = Waypoint.WaypointType.TakeOff;
			}
			waypoint.Name = Waypoint.GetWaypointTypeString(Waypoint.WaypointType.TakeOff);
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			if (Information.IsNothing(object_0))
			{
				if (Information.IsNothing(aircraftMissionProfile_0))
				{
					waypoint.DesiredAltitude = 609.6f;
				}
				else if (Information.IsNothing(aircraftMissionProfile_0.FormUpAltitude))
				{
					waypoint.DesiredAltitude = 609.6f;
				}
				else
				{
					float num = Terrain.GetElevation(double_0, double_1, bool_0: false, ((ActiveUnit)object_0).ParentScen);
					num = ((num <= 0f) ? 0f : ((float)(Math.Round(num * 3.28084f / 1000f, 0) * 1000.0 / 3.2808399200439453)));
					if (aircraftMissionProfile_0.FormUpAltitude <= 0f)
					{
						waypoint.DesiredAltitude = 609.6f + num;
					}
					else
					{
						waypoint.DesiredAltitude = aircraftMissionProfile_0.FormUpAltitude + num;
					}
				}
			}
			else
			{
				waypoint.DesiredAltitude = ((Aircraft)object_0).AI.VisitClient(ref double_0, ref double_1);
			}
			float_0 = waypoint.DesiredAltitude.Value;
			float_1 = 0f;
			bool_0 = false;
			if (Information.IsNothing(object_0))
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				waypoint.DesiredSpeed = 350f;
				waypoint.DesiredSpeedOverride = waypoint.DesiredSpeed;
			}
			else
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Loiter;
				if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
				{
					waypoint.DesiredSpeed = ((Aircraft)object_0).Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
				}
				else
				{
					waypoint.DesiredSpeed = ((Aircraft)object_0).Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
				}
			}
			if (!Information.IsNothing(waypoint.DesiredSpeed))
			{
				float_2 = waypoint.DesiredSpeed.Value;
			}
			waypoint.DesiredAltitudeOverride = true;
			unitThrottlePreset_0 = waypoint.ThrottlePreset;
			if (Information.IsNothing(waypoint.Time_Zulu))
			{
				waypoint.TimeFixed = Waypoint.FixedFree.None;
			}
			if (waypoint.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
			else
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			waypoint.SpeedAdjustmentToT = Waypoint.SpeedToT.No;
			waypoint.FlightFormation = formation_0;
			waypoint.TurnRate_Navigation = turnRateCategory_0;
			if (Information.IsNothing(waypoint_0))
			{
				ActiveUnit_Navigator.AddWaypoint(ref waypoint_1, 0, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101412", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static Waypoint InterruptTokenizer(Waypoint waypoint_0, object object_0, ref Waypoint[] waypoint_1, double double_0, double double_1, object object_1, ref float float_0, ref float float_1, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref float float_2, ref Waypoint.Formation formation_0, Waypoint.TurnRateCategory turnRateCategory_0)
	{
		try
		{
			Waypoint waypoint;
			if (Information.IsNothing(waypoint_0))
			{
				waypoint = new Waypoint(double_1, double_0, 0f, Waypoint.WaypointType.Land, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
			}
			else
			{
				waypoint = waypoint_0;
				waypoint.Type = Waypoint.WaypointType.Land;
			}
			waypoint.Name = Waypoint.GetWaypointTypeString(Waypoint.WaypointType.Land);
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			waypoint.DesiredAltitude = Terrain.GetElevation(waypoint.Latitude, waypoint.Longitude, bool_0: false, ((ActiveUnit)object_0).ParentScen);
			float? desiredAltitude = waypoint.DesiredAltitude;
			if ((desiredAltitude.HasValue ? new bool?(desiredAltitude.GetValueOrDefault() < 0f) : null).GetValueOrDefault())
			{
				waypoint.DesiredAltitude = 0f;
			}
			if (Information.IsNothing(object_0))
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				waypoint.DesiredSpeed = 500f;
				waypoint.DesiredSpeedOverride = waypoint.DesiredSpeed;
			}
			else
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Loiter;
				if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
				{
					waypoint.DesiredSpeed = ((Aircraft)object_0).Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
				}
				else
				{
					waypoint.DesiredSpeed = ((Aircraft)object_0).Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
				}
			}
			if (!Information.IsNothing(waypoint.DesiredSpeed))
			{
				float_2 = waypoint.DesiredSpeed.Value;
			}
			waypoint.DesiredAltitudeOverride = true;
			if (Information.IsNothing(waypoint.Time_Zulu))
			{
				waypoint.TimeFixed = Waypoint.FixedFree.None;
			}
			if (Information.IsNothing(object_0))
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else if (waypoint.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
			else
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			waypoint.SpeedAdjustmentToT = Waypoint.SpeedToT.No;
			waypoint.FlightFormation = formation_0;
			waypoint.TurnRate_Navigation = turnRateCategory_0;
			if (Information.IsNothing(waypoint_0))
			{
				ArrayExtensions.Add(ref waypoint_1, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101413", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static Waypoint RemoveTokenizer(Waypoint waypoint_0, Aircraft aircraft_0, ref Waypoint[] waypoint_1, double double_0, double double_1, AircraftMissionProfile aircraftMissionProfile_0, Mission._RadarBehaviour _RadarBehaviour_0, ref float float_0, ref float float_1, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref float float_2, ref Waypoint.Formation formation_0, Waypoint.TurnRateCategory turnRateCategory_0, Waypoint.SpeedToT speedToT_0)
	{
		try
		{
			Waypoint waypoint;
			if (Information.IsNothing(waypoint_0))
			{
				waypoint = new Waypoint(double_1, double_0, 0f, Waypoint.WaypointType.StrikeIngress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
			}
			else
			{
				waypoint = waypoint_0;
				waypoint.Type = Waypoint.WaypointType.StrikeIngress;
			}
			waypoint.Name = Waypoint.GetWaypointTypeString(Waypoint.WaypointType.StrikeIngress);
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			if (aircraftMissionProfile_0.CruiseAtOptimumAltitude)
			{
				Waypoint waypoint2 = waypoint;
				bool bool_ = false;
				waypoint2.DesiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_0, ActiveUnit.Throttle.Cruise, ref bool_);
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			else if (aircraftMissionProfile_0.CruiseAltitudeIngressTerrainFollowing)
			{
				waypoint.TerrainFollowing = true;
				waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.CruiseAltitudeIngress;
				float_0 = 0f;
				float_1 = waypoint.DesiredAltitude_TerrainFollowing.Value;
				bool_0 = waypoint.TerrainFollowing;
			}
			else
			{
				waypoint.DesiredAltitude = aircraftMissionProfile_0.CruiseAltitudeIngress;
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.CruiseThrottleSettingIngress;
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			else if (!Information.IsNothing(unitThrottlePreset_0) && unitThrottlePreset_0 != ActiveUnit_Kinematics.UnitThrottlePreset.None && unitThrottlePreset_0 != 0)
			{
				waypoint.ThrottlePreset = unitThrottlePreset_0;
			}
			else
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			else
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			if (!Information.IsNothing(waypoint.DesiredSpeed))
			{
				float_2 = waypoint.DesiredSpeed.Value;
			}
			if (Information.IsNothing(waypoint.Time_Zulu))
			{
				waypoint.TimeFixed = Waypoint.FixedFree.None;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
			waypoint.SpeedAdjustmentToT = speedToT_0;
			waypoint.FlightFormation = formation_0;
			waypoint.TurnRate_Navigation = turnRateCategory_0;
			waypoint.DesiredAltitudeOverride = true;
			if (!Information.IsNothing(_RadarBehaviour_0) && _RadarBehaviour_0 == Mission._RadarBehaviour.ActiveOnAttackIngressAndIP)
			{
				waypoint.Doctrine.SetEMCON(Doctrine.EMCONSettings._EMCONSetting.Active, Doctrine.EMCONSettings._EMCONSetting.NotConfigured, Doctrine.EMCONSettings._EMCONSetting.NotConfigured);
			}
			if (Information.IsNothing(waypoint_0))
			{
				ArrayExtensions.Add(ref waypoint_1, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101414", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static Waypoint FindTokenizer(Waypoint waypoint_0, Aircraft aircraft_0, ref Waypoint[] waypoint_1, double double_0, double double_1, AircraftMissionProfile aircraftMissionProfile_0, ref float float_0, ref float float_1, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref float float_2, ref Waypoint.Formation formation_0, Waypoint.TurnRateCategory turnRateCategory_0, Waypoint.SpeedToT speedToT_0)
	{
		try
		{
			Waypoint waypoint;
			if (Information.IsNothing(waypoint_0))
			{
				waypoint = new Waypoint(double_1, double_0, 0f, Waypoint.WaypointType.StrikeEgress, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
			}
			else
			{
				waypoint = waypoint_0;
				waypoint.Type = Waypoint.WaypointType.StrikeEgress;
			}
			waypoint.Name = Waypoint.GetWaypointTypeString(Waypoint.WaypointType.StrikeEgress);
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			if (aircraftMissionProfile_0.CruiseAtOptimumAltitude)
			{
				Waypoint waypoint2 = waypoint;
				bool bool_ = false;
				waypoint2.DesiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_0, ActiveUnit.Throttle.Cruise, ref bool_);
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			else if (aircraftMissionProfile_0.CruiseAltitudeEgressTerrainFollowing)
			{
				waypoint.TerrainFollowing = true;
				waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.CruiseAltitudeEgress;
				float_0 = 0f;
				float_1 = waypoint.DesiredAltitude_TerrainFollowing.Value;
				bool_0 = waypoint.TerrainFollowing;
			}
			else
			{
				waypoint.DesiredAltitude = aircraftMissionProfile_0.CruiseAltitudeEgress;
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.CruiseThrottleSettingEgress;
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			else if (!Information.IsNothing(unitThrottlePreset_0) && unitThrottlePreset_0 != ActiveUnit_Kinematics.UnitThrottlePreset.None && unitThrottlePreset_0 != 0)
			{
				waypoint.ThrottlePreset = unitThrottlePreset_0;
			}
			else
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			else
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			if (!Information.IsNothing(waypoint.DesiredSpeed))
			{
				float_2 = waypoint.DesiredSpeed.Value;
			}
			if (Information.IsNothing(waypoint.Time_Zulu))
			{
				waypoint.TimeFixed = Waypoint.FixedFree.None;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
			waypoint.SpeedAdjustmentToT = speedToT_0;
			waypoint.FlightFormation = formation_0;
			waypoint.DesiredAltitudeOverride = true;
			waypoint.TurnRate_Navigation = turnRateCategory_0;
			if (Information.IsNothing(waypoint_0))
			{
				ArrayExtensions.Add(ref waypoint_1, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101415", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static Waypoint SetTokenizer(Waypoint waypoint_0, ref Waypoint[] waypoint_1, double double_0, double double_1, ref Waypoint.Formation formation_0, Waypoint.WaypointType waypointType_0, Waypoint.WaypointCreator waypointCreator_0, Waypoint.WaypointCategory waypointCategory_0)
	{
		try
		{
			Waypoint waypoint;
			if (Information.IsNothing(waypoint_0))
			{
				waypoint = new Waypoint(double_1, double_0, 0f, waypointType_0, waypointCreator_0, waypointCategory_0);
			}
			else
			{
				waypoint = waypoint_0;
				waypoint.Type = waypointType_0;
			}
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			waypoint.SpeedAdjustmentToT = Waypoint.SpeedToT.No;
			waypoint.FlightFormation = formation_0;
			if (Information.IsNothing(waypoint_0))
			{
				ArrayExtensions.Add(ref waypoint_1, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static Waypoint FillTokenizer(object object_0, object object_1, ref Waypoint[] waypoint_0, double double_0, double double_1, object object_2, ref float float_0, ref float float_1, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref float float_2, ref Waypoint.Formation formation_0, Waypoint.TurnRateCategory turnRateCategory_0, bool? nullable_0, Waypoint.SpeedToT speedToT_0)
	{
		try
		{
			Waypoint waypoint = (Waypoint)(Information.IsNothing(object_0) ? new Waypoint(double_1, double_0, 0f, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan) : object_0);
			if (Information.IsNothing(nullable_0))
			{
				waypoint.Type = Waypoint.WaypointType.TurningPoint;
			}
			else if (nullable_0.GetValueOrDefault())
			{
				waypoint.Type = Waypoint.WaypointType.StrikeIngress;
			}
			else
			{
				waypoint.Type = Waypoint.WaypointType.StrikeEgress;
			}
			waypoint.Name = Waypoint.GetWaypointTypeString(Waypoint.WaypointType.TurningPoint);
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			waypoint.DesiredAltitude = float_0;
			waypoint.TerrainFollowing = bool_0;
			waypoint.DesiredAltitude_TerrainFollowing = float_1;
			waypoint.ThrottlePreset = unitThrottlePreset_0;
			if (Information.IsNothing(object_1))
			{
				waypoint.DesiredSpeed = 500f;
				waypoint.DesiredSpeedOverride = waypoint.DesiredSpeed;
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else
			{
				waypoint.DesiredSpeed = float_2;
				if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
				{
					waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
				}
				else
				{
					waypoint.SpeedFixed = Waypoint.FixedFree.Free;
				}
			}
			waypoint.SpeedAdjustmentToT = speedToT_0;
			waypoint.FlightFormation = formation_0;
			waypoint.TurnRate_Navigation = turnRateCategory_0;
			waypoint.DesiredAltitudeOverride = true;
			if (Information.IsNothing(object_0))
			{
				ArrayExtensions.Add(ref waypoint_0, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101416", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static Waypoint CalculateTokenizer(Waypoint waypoint_0, Aircraft aircraft_0, ref Waypoint[] waypoint_1, double double_0, double double_1, AircraftMissionProfile aircraftMissionProfile_0, Mission._RadarBehaviour _RadarBehaviour_0, Waypoint.WaypointType waypointType_0, ref float float_0, ref float float_1, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref float float_2, ref Waypoint.Formation formation_0, Waypoint.TurnRateCategory turnRateCategory_0, Waypoint.SpeedToT speedToT_0, object object_0)
	{
		try
		{
			Waypoint waypoint;
			if (Information.IsNothing(waypoint_0))
			{
				waypoint = new Waypoint(double_1, double_0, 0f, waypointType_0, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
			}
			else
			{
				waypoint = waypoint_0;
				waypoint.Type = waypointType_0;
			}
			waypoint.Name = Waypoint.GetWaypointTypeString(waypointType_0);
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			if (aircraftMissionProfile_0.CruiseAtOptimumAltitude)
			{
				Waypoint waypoint2 = waypoint;
				bool bool_ = false;
				waypoint2.DesiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_0, ActiveUnit.Throttle.Cruise, ref bool_);
			}
			else if (aircraftMissionProfile_0.StationAltitude <= 0f)
			{
				if (aircraftMissionProfile_0.CruiseAltitudeIngressTerrainFollowing)
				{
					waypoint.TerrainFollowing = true;
					waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.CruiseAltitudeIngress;
				}
				else
				{
					waypoint.DesiredAltitude = aircraftMissionProfile_0.CruiseAltitudeIngress;
				}
			}
			else if (aircraftMissionProfile_0.StationAltitudeTerrainFollowing)
			{
				waypoint.TerrainFollowing = true;
				waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.StationAltitude;
			}
			else
			{
				waypoint.DesiredAltitude = aircraftMissionProfile_0.StationAltitude;
			}
			if (aircraftMissionProfile_0.StationThrottleSetting == ActiveUnit.Throttle.FullStop)
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Loiter;
			}
			else
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.StationThrottleSetting;
			}
			if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			else
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
			waypoint.SpeedAdjustmentToT = speedToT_0;
			waypoint.FlightFormation = Waypoint.Formation.Spread;
			waypoint.TurnRate_Navigation = turnRateCategory_0;
			waypoint.DesiredAltitudeOverride = true;
			if (!Information.IsNothing(_RadarBehaviour_0) && (_RadarBehaviour_0 == Mission._RadarBehaviour.ActiveOnIP || _RadarBehaviour_0 == Mission._RadarBehaviour.ActiveOnAttackIngressAndIP))
			{
				waypoint.Doctrine.SetEMCON(Doctrine.EMCONSettings._EMCONSetting.Active, Doctrine.EMCONSettings._EMCONSetting.NotConfigured, Doctrine.EMCONSettings._EMCONSetting.NotConfigured);
			}
			if (Information.IsNothing(waypoint_0))
			{
				ArrayExtensions.Add(ref waypoint_1, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static Waypoint PopTokenizer(Waypoint waypoint_0, Aircraft aircraft_0, ref Waypoint[] waypoint_1, double double_0, double double_1, AircraftMissionProfile aircraftMissionProfile_0, Mission._RadarBehaviour _RadarBehaviour_0, ref float float_0, ref float float_1, ref bool bool_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref float float_2, ref Waypoint.Formation formation_0, Waypoint.TurnRateCategory turnRateCategory_0)
	{
		try
		{
			Waypoint.WaypointType waypointType = Waypoint.WaypointType.StationEnd;
			Waypoint waypoint;
			if (Information.IsNothing(waypoint_0))
			{
				waypoint = new Waypoint(double_1, double_0, 0f, waypointType, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
			}
			else
			{
				waypoint = waypoint_0;
				waypoint.Type = waypointType;
			}
			waypoint.Name = Waypoint.GetWaypointTypeString(waypointType);
			waypoint.Category = Waypoint.WaypointCategory.FlightPlan;
			if (aircraftMissionProfile_0.CruiseAtOptimumAltitude)
			{
				Waypoint waypoint2 = waypoint;
				bool bool_ = false;
				waypoint2.DesiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_0, ActiveUnit.Throttle.Cruise, ref bool_);
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			else if (aircraftMissionProfile_0.CruiseAltitudeEgressTerrainFollowing)
			{
				waypoint.TerrainFollowing = true;
				waypoint.DesiredAltitude_TerrainFollowing = aircraftMissionProfile_0.CruiseAltitudeEgress;
				float_0 = 0f;
				float_1 = waypoint.DesiredAltitude_TerrainFollowing.Value;
				bool_0 = waypoint.TerrainFollowing;
			}
			else
			{
				waypoint.DesiredAltitude = aircraftMissionProfile_0.CruiseAltitudeEgress;
				float_0 = waypoint.DesiredAltitude.Value;
				float_1 = 0f;
				bool_0 = false;
			}
			if (aircraftMissionProfile_0.AttackThrottleSetting != 0 && aircraftMissionProfile_0.AttackDistanceEgress > 0)
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.AttackThrottleSetting;
			}
			else
			{
				waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)aircraftMissionProfile_0.CruiseThrottleSettingEgress;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			else if (!Information.IsNothing(unitThrottlePreset_0) && unitThrottlePreset_0 != ActiveUnit_Kinematics.UnitThrottlePreset.None && unitThrottlePreset_0 != 0)
			{
				waypoint.ThrottlePreset = unitThrottlePreset_0;
			}
			else
			{
				waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
				unitThrottlePreset_0 = waypoint.ThrottlePreset;
			}
			if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			else
			{
				waypoint.DesiredSpeed = aircraft_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
			}
			if (!Information.IsNothing(waypoint.DesiredSpeed))
			{
				float_2 = waypoint.DesiredSpeed.Value;
			}
			if (Information.IsNothing(waypoint.Time_Zulu))
			{
				waypoint.TimeFixed = Waypoint.FixedFree.None;
			}
			if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			else
			{
				waypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
			waypoint.SpeedAdjustmentToT = Waypoint.SpeedToT.No;
			waypoint.FlightFormation = formation_0;
			waypoint.TurnRate_Navigation = turnRateCategory_0;
			waypoint.DesiredAltitudeOverride = true;
			if (!Information.IsNothing(_RadarBehaviour_0) && (_RadarBehaviour_0 == Mission._RadarBehaviour.ActiveOnIP || _RadarBehaviour_0 == Mission._RadarBehaviour.ActiveOnAttackIngressAndIP))
			{
				waypoint.Doctrine.SetEMCON(Doctrine.EMCONSettings._EMCONSetting.Active, Doctrine.EMCONSettings._EMCONSetting.NotConfigured, Doctrine.EMCONSettings._EMCONSetting.NotConfigured);
			}
			if (Information.IsNothing(waypoint_0))
			{
				ArrayExtensions.Add(ref waypoint_1, waypoint);
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public static void UpdateMissionWaypoints_BeforeTakeOff(ref Scenario scenario_0, ref Mission mission_0)
	{
		try
		{
			if (mission_0 == null || !mission_0.RestartValue())
			{
				return;
			}
			_ = mission_0.FlightList.Count;
			Aircraft aircraft = null;
			ActiveUnit activeUnit = null;
			ActiveUnit activeUnit2 = null;
			float num = 0f;
			float float_ = 0f;
			foreach (Mission.Flight flight2 in mission_0.FlightList)
			{
				if (flight2 == null || flight2.GetIsActive(flight2.GetAUCurrentlyAssigned(mission_0, scenario_0)) || flight2.FlightPlan == null || flight2.FlightPlan.Count() <= 0)
				{
					continue;
				}
				bool flag = flight2.Type == Mission._FlightType.FlightplanTemplate || ((mission_0.MissionClass == Mission._MissionClass.Patrol || mission_0.MissionClass == Mission._MissionClass.Support) ? true : false);
				ActiveUnit activeUnit3 = flight2.GetReferenceUnit(scenario_0);
				if (activeUnit3 == null)
				{
					continue;
				}
				if (activeUnit3.IsGroup)
				{
					Group group = (Group)activeUnit3;
					if (group.Units.Count == 0)
					{
						continue;
					}
					if (group.GroupLead == null)
					{
						group.PrintInvocation();
					}
					activeUnit3 = group.GroupLead;
				}
				if (activeUnit3 != null)
				{
					aircraft = (Aircraft)activeUnit3;
				}
				bool flag2 = false;
				if (Operators.CompareString(flight2.TakeOffLocation_HostUnitObjectID, "", TextCompare: false) == 0)
				{
					flag2 = true;
				}
				else if (scenario_0.ActiveUnits.ContainsKey(flight2.TakeOffLocation_HostUnitObjectID))
				{
					activeUnit = scenario_0.ActiveUnits[flight2.TakeOffLocation_HostUnitObjectID];
					if (Information.IsNothing(activeUnit))
					{
						flag2 = true;
					}
				}
				else
				{
					flag2 = true;
				}
				bool flag3 = false;
				if (Operators.CompareString(flight2.LandingLocation_HostUnitObjectID, "", TextCompare: false) == 0)
				{
					flag3 = true;
				}
				else if (scenario_0.ActiveUnits.ContainsKey(flight2.LandingLocation_HostUnitObjectID))
				{
					activeUnit2 = scenario_0.ActiveUnits[flight2.LandingLocation_HostUnitObjectID];
					if (Information.IsNothing(activeUnit2))
					{
						flag3 = true;
					}
				}
				else
				{
					flag3 = true;
				}
				bool flag4 = false;
				bool flag5 = false;
				flight2.FlightPlan.Count();
				if (!flag3)
				{
					Waypoint[] flightPlan = flight2.FlightPlan;
					Waypoint[] array = flightPlan;
					foreach (Waypoint waypoint in array)
					{
						if (waypoint == null)
						{
							continue;
						}
						if (waypoint.Type == Waypoint.WaypointType.LandingMarshal)
						{
							Geopoint_Struct geopoint_Struct = ((Information.IsNothing(aircraft) || !aircraft.IsHelicopter) ? activeUnit2.AirOps.LandingQueueAssemblyPoint : new Geopoint_Struct(activeUnit2.GetLongitude(), activeUnit2.GetLatitude()));
							waypoint.Latitude = geopoint_Struct.Latitude;
							waypoint.Longitude = geopoint_Struct.Longitude;
							continue;
						}
						if (waypoint.Type != Waypoint.WaypointType.Land || (waypoint.Latitude == activeUnit2.GetLatitude() && waypoint.Longitude == activeUnit2.GetLongitude()))
						{
							break;
						}
						num = Math2.VerifyClass(waypoint.Latitude, waypoint.Longitude, activeUnit2.GetLatitude(), activeUnit2.GetLongitude());
						if (num < 5f)
						{
							break;
						}
						flag4 = true;
						waypoint.Latitude = activeUnit2.GetLatitude();
						waypoint.Longitude = activeUnit2.GetLongitude();
					}
				}
				if (!flag2)
				{
					Waypoint[] flightPlan2 = flight2.FlightPlan;
					Waypoint[] array2 = flightPlan2;
					foreach (Waypoint waypoint2 in array2)
					{
						if (waypoint2 == null)
						{
							continue;
						}
						if (waypoint2.Type == Waypoint.WaypointType.TakeOff)
						{
							if (waypoint2.Latitude == activeUnit.GetLatitude() && waypoint2.Longitude == activeUnit.GetLongitude())
							{
								break;
							}
							num = Math2.VerifyClass(waypoint2.Latitude, waypoint2.Longitude, activeUnit.GetLatitude(), activeUnit.GetLongitude());
							if (num < 5f)
							{
								break;
							}
							flag5 = true;
							float_ = Math2.PublishClass(waypoint2.Latitude, waypoint2.Longitude, activeUnit.GetLatitude(), activeUnit.GetLongitude());
							waypoint2.Latitude = activeUnit.GetLatitude();
							waypoint2.Longitude = activeUnit.GetLongitude();
						}
						else if (waypoint2.Type != Waypoint.WaypointType.Assemble && waypoint2.Type != Waypoint.WaypointType.HoldStart && waypoint2.Type != Waypoint.WaypointType.HoldEnd)
						{
							if (!(waypoint2.Type != Waypoint.WaypointType.LandingMarshal && waypoint2.Type != Waypoint.WaypointType.Land && flag))
							{
								break;
							}
							if (waypoint2.Type != Waypoint.WaypointType.InitialPoint && waypoint2.Type != Waypoint.WaypointType.Target && waypoint2.Type != Waypoint.WaypointType.WeaponLaunch && waypoint2.Type != Waypoint.WaypointType.WeaponTarget && waypoint2.FlightFormation != Waypoint.Formation.Split && !waypoint2.InvokeReponse())
							{
								double longitude = waypoint2.Longitude;
								double latitude = waypoint2.Latitude;
								double double_ = waypoint2.Longitude;
								double double_2 = waypoint2.Latitude;
								Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_, ref double_2, num, float_);
								waypoint2.Latitude = double_2;
								waypoint2.Longitude = double_;
							}
						}
						else
						{
							double longitude2 = waypoint2.Longitude;
							double latitude2 = waypoint2.Latitude;
							double double_3 = waypoint2.Longitude;
							double double_4 = waypoint2.Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(longitude2, latitude2, ref double_3, ref double_4, num, float_);
							waypoint2.Latitude = double_4;
							waypoint2.Longitude = double_3;
						}
					}
				}
				if (aircraft.Navigator.GetFlight() != null && aircraft.Navigator.HasFlightPlan && (flag5 || flag4))
				{
					Scenario scenario_ = scenario_0;
					Mission strike_ = mission_0;
					ActiveUnit object_ = activeUnit3;
					Mission.Flight flight = aircraft.Navigator.GetFlight();
					Waypoint[] waypoint_ = aircraft.Navigator.GetFlight()?.FlightPlan;
					float float_2 = 0f;
					float float_3 = 0f;
					ConnectTokenizer(scenario_, strike_, object_, flight, ref waypoint_, ref float_2, ref float_3, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: true, bool_8: false, mission_0.TakeOffTime, mission_0.TimeOnTarget, bool_9: false);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void UpdateStrikeMissionWaypoints_AirborneAircraft(float float_0, ref Scenario scenario_0, ref Side side_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			if (!scenario_0.MinuteIsChangingOnThisPulse || Information.IsNothing(side_0.Missions))
			{
				return;
			}
			Contact primaryTarget = null;
			foreach (Mission item in side_0.GetMissionsTotal(scenario_0))
			{
				Mission mission_ = item;
				if (Information.IsNothing(mission_) || mission_.GetStatus(scenario_0) != 0)
				{
					continue;
				}
				foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
				{
					ActiveUnit activeUnit_ = activeUnits_;
					if (activeUnit_ == null || !activeUnit_.IsAircraft || !activeUnit_.Navigator.HasFlightPlan || activeUnit_.AssignedMissionOrPackage() != mission_)
					{
						continue;
					}
					if (!activeUnit_.IsGroupLead() && activeUnit_.IsGroupMember())
					{
						if (mission_.MissionClass == Mission._MissionClass.Strike && activeUnit_ != null && activeUnit_.Navigator.PlottedCourse.Count() > 0)
						{
							Aircraft obj = (Aircraft)activeUnit_;
							_ = obj.AirOps;
							ref Waypoint waypoint_ = ref activeUnit_.Navigator.PlottedCourse[0];
							ActiveUnit_AI aI;
							Contact contact_ = (aI = activeUnit_.AI).PrimaryTarget;
							Mission.Flight flight;
							Scenario scenario_;
							ActiveUnit activeUnit_2 = (flight = obj.Navigator.GetFlight()).GetReferenceUnit(scenario_ = scenario_0);
							Aircraft_Navigator navigator = obj.Navigator;
							Mission.Flight flight_ = navigator.GetFlight();
							Waypoint waypoint_2 = null;
							Waypoint waypoint_3 = null;
							UpdateStrikeMissionWaypoints_TargetAndIP_WingmenSplitSegment(float_0, ref scenario_0, ref side_0, ref mission_, ref waypoint_, ref activeUnit_, ref contact_, ref activeUnit_0, bool_0: true, ref activeUnit_2, ref flight_, ref waypoint_2, ref waypoint_3, Mission.Flight.FlightElement.None, bool_1: false);
							navigator.SetFlight(bool_1: true, flight_);
							flight.SetReferenceUnit(scenario_, activeUnit_2);
							aI.PrimaryTarget = contact_;
						}
					}
					else
					{
						if (activeUnit_ == null || activeUnit_.Navigator.PlottedCourse.Count() <= 0)
						{
							continue;
						}
						Aircraft aircraft_ = (Aircraft)activeUnit_;
						Aircraft_AirOps aircraft_AirOps_ = aircraft_.AirOps;
						UpdateStrikeMissionWaypoints_TakeOffAndLanding(ref scenario_0, ref mission_, ref activeUnit_, ref aircraft_, ref aircraft_AirOps_);
						if (mission_.MissionClass != Mission._MissionClass.Strike)
						{
							continue;
						}
						if (activeUnit_.AI.PrimaryTarget == null)
						{
							Strike strike = (Strike)mission_;
							if (strike.SpecificTargets != null && strike.TargetCount > 0)
							{
								if (strike.SpecificTargets.ElementAtOrDefault(0).IsActiveUnit)
								{
									primaryTarget = new Contact((ActiveUnit)strike.SpecificTargets.ElementAtOrDefault(0), 0, bool_0: true);
								}
								else if (strike.SpecificTargets.ElementAtOrDefault(0).DisableWriter())
								{
									primaryTarget = (Contact)strike.SpecificTargets.ElementAtOrDefault(0);
								}
								activeUnit_.AI.PrimaryTarget = primaryTarget;
							}
						}
						if (activeUnit_ != null && activeUnit_.Navigator.PlottedCourse.Length != 0)
						{
							ref Waypoint waypoint_4 = ref activeUnit_.Navigator.PlottedCourse[0];
							ActiveUnit_AI aI2 = activeUnit_.AI;
							Contact contact_2 = aI2.PrimaryTarget;
							Mission.Flight flight2 = aircraft_.Navigator.GetFlight();
							Scenario scenario_2;
							ActiveUnit activeUnit_3 = flight2.GetReferenceUnit(scenario_2 = scenario_0);
							Aircraft_Navigator navigator2 = aircraft_.Navigator;
							Mission.Flight flight_2 = navigator2.GetFlight();
							Waypoint waypoint_5 = null;
							Waypoint waypoint_6 = null;
							UpdateStrikeMissionWaypoints_TargetAndIP_GroupLead(float_0, ref scenario_0, ref side_0, ref mission_, ref waypoint_4, ref activeUnit_, ref contact_2, ref activeUnit_0, bool_0: true, ref activeUnit_3, ref flight_2, ref waypoint_5, ref waypoint_6, bool_1: false);
							navigator2.SetFlight(bool_1: true, flight_2);
							flight2.SetReferenceUnit(scenario_2, activeUnit_3);
							aI2.PrimaryTarget = contact_2;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101247", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void UpdateStrikeMissionWaypoints_TakeOffAndLanding(ref Scenario scenario_0, ref Mission mission_0, ref ActiveUnit activeUnit_0, ref Aircraft aircraft_0, ref Aircraft_AirOps aircraft_AirOps_0)
	{
		try
		{
			if (Information.IsNothing(aircraft_AirOps_0.ActualDestinationHost))
			{
				return;
			}
			bool flag = false;
			for (int i = activeUnit_0.Navigator.GetFlight().FlightPlan.Count() - 1; i >= 0; i += -1)
			{
				Waypoint waypoint = activeUnit_0.Navigator.GetFlight().FlightPlan[i];
				if (waypoint.Type == Waypoint.WaypointType.LandingMarshal)
				{
					Geopoint_Struct geopoint_Struct = (aircraft_0.IsHelicopter ? new Geopoint_Struct(aircraft_AirOps_0.ActualDestinationHost.GetLongitude(), aircraft_AirOps_0.ActualDestinationHost.GetLatitude()) : aircraft_AirOps_0.ActualDestinationHost.AirOps.LandingQueueAssemblyPoint);
					waypoint.Latitude = geopoint_Struct.Latitude;
					waypoint.Longitude = geopoint_Struct.Longitude;
					continue;
				}
				if (waypoint.Type != Waypoint.WaypointType.Land || (waypoint.Latitude == aircraft_AirOps_0.ActualDestinationHost.GetLatitude() && waypoint.Longitude == aircraft_AirOps_0.ActualDestinationHost.GetLongitude()) || !(Math2.VerifyClass(waypoint.Latitude, waypoint.Longitude, aircraft_AirOps_0.ActualDestinationHost.GetLatitude(), aircraft_AirOps_0.ActualDestinationHost.GetLongitude()) >= 5f))
				{
					break;
				}
				flag = true;
				waypoint.Latitude = aircraft_AirOps_0.ActualDestinationHost.GetLatitude();
				waypoint.Longitude = aircraft_AirOps_0.ActualDestinationHost.GetLongitude();
			}
			if (flag)
			{
				Scenario scenario_ = scenario_0;
				Mission strike_ = mission_0;
				ActiveUnit referenceUnit = aircraft_0.Navigator.GetFlight().GetReferenceUnit(scenario_0);
				Mission.Flight flight = aircraft_0.Navigator.GetFlight();
				Mission.Flight flight2 = aircraft_0.Navigator.GetFlight();
				Waypoint[] waypoint_ = flight2.FlightPlan;
				float float_ = 0f;
				float float_2 = 0f;
				ConnectTokenizer(scenario_, strike_, referenceUnit, flight, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: true, bool_8: false, null, null, bool_9: false);
				flight2.FlightPlan = waypoint_;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void UpdateStrikeMissionWaypoints_TargetAndIP_GroupLead(float float_0, ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Waypoint waypoint_0, ref ActiveUnit activeUnit_0, ref Contact contact_0, ref ActiveUnit activeUnit_1, bool bool_0, ref ActiveUnit activeUnit_2, ref Mission.Flight flight_0, ref Waypoint waypoint_1, ref Waypoint waypoint_2, bool bool_1)
	{
		try
		{
			Strike strike = (Strike)mission_0;
			if (waypoint_0.Type == Waypoint.WaypointType.Assemble || waypoint_0.Type == Waypoint.WaypointType.HoldStart || waypoint_0.Type == Waypoint.WaypointType.HoldEnd)
			{
				return;
			}
			Waypoint waypoint = null;
			bool flag = false;
			List<Waypoint> list_ = new List<Waypoint>();
			bool flag2 = false;
			Waypoint[] flightPlan = flight_0.FlightPlan;
			float num = 0f;
			double double_ = 0.0;
			double double_2 = 0.0;
			Waypoint[] array = flightPlan;
			Waypoint[] array2 = array;
			foreach (Waypoint waypoint2 in array2)
			{
				if (!flag2)
				{
					if (waypoint2 != waypoint_0)
					{
						continue;
					}
					flag2 = true;
				}
				if (waypoint2.Type == Waypoint.WaypointType.InitialPoint || waypoint2.Type == Waypoint.WaypointType.WeaponLaunch)
				{
					if (!Information.IsNothing(waypoint_1) && waypoint_1 != waypoint2)
					{
						continue;
					}
					if (bool_0 && !Information.IsNothing(activeUnit_0) && !Information.IsNothing(activeUnit_1))
					{
						if (!Information.IsNothing(contact_0) && activeUnit_1 != contact_0.ActualUnit)
						{
							continue;
						}
						HandleDestroyedContact(ref activeUnit_0, waypoint2, ref list_);
						flag = true;
					}
					waypoint = waypoint2;
				}
				if ((waypoint2.Type != Waypoint.WaypointType.Target && waypoint2.Type != Waypoint.WaypointType.WeaponTarget) || (!Information.IsNothing(waypoint_2) && waypoint_2 != waypoint2))
				{
					continue;
				}
				if (bool_0 && !Information.IsNothing(activeUnit_0) && !flag && !Information.IsNothing(activeUnit_1))
				{
					if (!Information.IsNothing(contact_0) && activeUnit_1 != contact_0.ActualUnit)
					{
						continue;
					}
					HandleDestroyedContact(ref activeUnit_0, waypoint2, ref list_);
				}
				if (!Information.IsNothing(contact_0) & !Information.IsNothing(activeUnit_1))
				{
					if (waypoint2.Latitude != contact_0.GetLatitude() || waypoint2.Longitude != contact_0.GetLongitude())
					{
						num = Math2.VerifyClass(waypoint2.Latitude, waypoint2.Longitude, contact_0.GetLatitude(), contact_0.GetLongitude());
						float float_ = Math2.PublishClass(waypoint2.Latitude, waypoint2.Longitude, contact_0.GetLatitude(), contact_0.GetLongitude());
						waypoint2.Latitude = contact_0.GetLatitude();
						waypoint2.Longitude = contact_0.GetLongitude();
						if (waypoint2.TargeteeringMethod != Mission._TargeteeringMethod.Individual)
						{
							if (!Information.IsNothing(waypoint2.Waypoint_LeadElementWingman))
							{
								InstantiateTokenizer(ref waypoint2.Waypoint_LeadElementWingman, num, float_);
							}
							if (!Information.IsNothing(waypoint2.Waypoint_SecondElement))
							{
								InstantiateTokenizer(ref waypoint2.Waypoint_SecondElement, num, float_);
							}
							if (!Information.IsNothing(waypoint2.Waypoint_SecondElementWingman))
							{
								InstantiateTokenizer(ref waypoint2.Waypoint_SecondElementWingman, num, float_);
							}
							if (!Information.IsNothing(waypoint2.Waypoint_ThirdElement))
							{
								InstantiateTokenizer(ref waypoint2.Waypoint_ThirdElement, num, float_);
							}
							if (!Information.IsNothing(waypoint2.Waypoint_ThirdElementWingman))
							{
								InstantiateTokenizer(ref waypoint2.Waypoint_ThirdElementWingman, num, float_);
							}
						}
						if (!Information.IsNothing(waypoint))
						{
							if (num > 0f)
							{
								Geodesic_EdWilliams.CalcPoint_Williams(waypoint.Longitude, waypoint.Latitude, ref double_, ref double_2, num, float_);
								if (bool_0 && !Information.IsNothing(activeUnit_0) && waypoint2.Creator == Waypoint.WaypointCreator.Pathfinder)
								{
									double latitude;
									double longitude;
									if (waypoint2 == waypoint_0)
									{
										latitude = activeUnit_0.GetLatitude();
										longitude = activeUnit_0.GetLongitude();
									}
									else
									{
										int num2 = Array.IndexOf(flight_0.FlightPlan, waypoint2) - 1;
										latitude = flight_0.FlightPlan[num2].Latitude;
										longitude = flight_0.FlightPlan[num2].Longitude;
									}
									ActiveUnit_Navigator navigator = activeUnit_0.Navigator;
									double double_3 = double_2;
									double double_4 = double_;
									double double_5 = latitude;
									double double_6 = longitude;
									int int_ = 0;
									GeoPoint geoPoint_ = null;
									if (navigator.PathLineIsInterrupted(double_3, double_4, double_5, double_6, bool_1: true, 0f, bool_2: false, null, bool_3: true, bool_4: true, bool_5: false, null, ref int_, ref geoPoint_))
									{
										continue;
									}
									ActiveUnit_Navigator navigator2 = activeUnit_0.Navigator;
									double double_7 = double_2;
									double double_8 = double_;
									double latitude2 = contact_0.GetLatitude();
									double longitude2 = contact_0.GetLongitude();
									int_ = 0;
									geoPoint_ = null;
									if (navigator2.PathLineIsInterrupted(double_7, double_8, latitude2, longitude2, bool_1: true, 0f, bool_2: false, null, bool_3: true, bool_4: true, bool_5: false, null, ref int_, ref geoPoint_))
									{
										continue;
									}
								}
								waypoint.Latitude = double_2;
								waypoint.Longitude = double_;
								if (waypoint2.TargeteeringMethod != Mission._TargeteeringMethod.Individual)
								{
									if (!Information.IsNothing(waypoint.Waypoint_LeadElementWingman))
									{
										InstantiateTokenizer(ref waypoint.Waypoint_LeadElementWingman, num, float_);
									}
									if (!Information.IsNothing(waypoint.Waypoint_SecondElement))
									{
										InstantiateTokenizer(ref waypoint.Waypoint_SecondElement, num, float_);
									}
									if (!Information.IsNothing(waypoint.Waypoint_SecondElementWingman))
									{
										InstantiateTokenizer(ref waypoint.Waypoint_SecondElementWingman, num, float_);
									}
									if (!Information.IsNothing(waypoint.Waypoint_ThirdElement))
									{
										InstantiateTokenizer(ref waypoint.Waypoint_ThirdElement, num, float_);
									}
									if (!Information.IsNothing(waypoint.Waypoint_ThirdElementWingman))
									{
										InstantiateTokenizer(ref waypoint.Waypoint_ThirdElementWingman, num, float_);
									}
								}
							}
							if (waypoint2.FlightFormation == Waypoint.Formation.Split && num > 0f)
							{
								int num3 = Array.IndexOf(flight_0.FlightPlan, waypoint2);
								if (flight_0.FlightPlan.Count() > 1)
								{
									for (int i = num3 - 1; i >= 0; i += -1)
									{
										Waypoint waypoint_3 = flight_0.FlightPlan[i];
										if (flight_0.FlightPlan[i + 1].FlightFormation != Waypoint.Formation.Split)
										{
											break;
										}
										if (waypoint == waypoint_3)
										{
											continue;
										}
										InstantiateTokenizer(ref waypoint_3, num, float_);
										if (waypoint2.TargeteeringMethod != Mission._TargeteeringMethod.Individual)
										{
											if (!Information.IsNothing(waypoint_3.Waypoint_LeadElementWingman))
											{
												InstantiateTokenizer(ref waypoint_3.Waypoint_LeadElementWingman, num, float_);
											}
											if (!Information.IsNothing(waypoint_3.Waypoint_SecondElement))
											{
												InstantiateTokenizer(ref waypoint_3.Waypoint_SecondElement, num, float_);
											}
											if (!Information.IsNothing(waypoint_3.Waypoint_SecondElementWingman))
											{
												InstantiateTokenizer(ref waypoint_3.Waypoint_SecondElementWingman, num, float_);
											}
											if (!Information.IsNothing(waypoint_3.Waypoint_ThirdElement))
											{
												InstantiateTokenizer(ref waypoint_3.Waypoint_ThirdElement, num, float_);
											}
											if (!Information.IsNothing(waypoint_3.Waypoint_ThirdElementWingman))
											{
												InstantiateTokenizer(ref waypoint_3.Waypoint_ThirdElementWingman, num, float_);
											}
										}
									}
								}
								if (num3 < flight_0.FlightPlan.Count() - 1)
								{
									int num4 = num3 + 1;
									int num5 = flight_0.FlightPlan.Count() - 1;
									for (int j = num4; j <= num5; j++)
									{
										Waypoint waypoint_4 = flight_0.FlightPlan[j];
										if (flight_0.FlightPlan[j - 1].FlightFormation != Waypoint.Formation.Split)
										{
											break;
										}
										InstantiateTokenizer(ref waypoint_4, num, float_);
										if (waypoint2.TargeteeringMethod != Mission._TargeteeringMethod.Individual)
										{
											if (!Information.IsNothing(waypoint_4.Waypoint_LeadElementWingman))
											{
												InstantiateTokenizer(ref waypoint_4.Waypoint_LeadElementWingman, num, float_);
											}
											if (!Information.IsNothing(waypoint_4.Waypoint_SecondElement))
											{
												InstantiateTokenizer(ref waypoint_4.Waypoint_SecondElement, num, float_);
											}
											if (!Information.IsNothing(waypoint_4.Waypoint_SecondElementWingman))
											{
												InstantiateTokenizer(ref waypoint_4.Waypoint_SecondElementWingman, num, float_);
											}
											if (!Information.IsNothing(waypoint_4.Waypoint_ThirdElement))
											{
												InstantiateTokenizer(ref waypoint_4.Waypoint_ThirdElement, num, float_);
											}
											if (!Information.IsNothing(waypoint_4.Waypoint_ThirdElementWingman))
											{
												InstantiateTokenizer(ref waypoint_4.Waypoint_ThirdElementWingman, num, float_);
											}
										}
									}
								}
							}
						}
					}
				}
				else
				{
					if (Information.IsNothing(contact_0) & !Information.IsNothing(activeUnit_1))
					{
						activeUnit_0.AI.DeterminePrimaryTarget(float_0, bool_0: true, bool_1: true);
					}
					if ((Information.IsNothing(contact_0) & !Information.IsNothing(activeUnit_1)) || (strike.RTB_When_Target_Destroyed && strike.TargetCount == 0))
					{
						if (Information.IsNothing(waypoint))
						{
							waypoint2.Latitude = activeUnit_0.GetLatitude();
							waypoint2.Longitude = activeUnit_0.GetLongitude();
							Scenario scenario_ = scenario_0;
							Mission strike_ = mission_0;
							ActiveUnit object_ = activeUnit_2;
							Mission.Flight flight_ = flight_0;
							Mission.Flight flight;
							Waypoint[] waypoint_5 = (flight = flight_0).FlightPlan;
							float float_2 = 0f;
							float float_3 = 0f;
							ConnectTokenizer(scenario_, strike_, object_, flight_, ref waypoint_5, ref float_2, ref float_3, bool_0: false, bool_1, bool_2: false, bool_3: false, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: true, bool_8: false, null, null, bool_9: false);
							flight.FlightPlan = waypoint_5;
						}
						else
						{
							waypoint2.Latitude = waypoint.Latitude;
							waypoint2.Longitude = waypoint.Longitude;
							Scenario scenario_2 = scenario_0;
							Mission strike_2 = mission_0;
							ActiveUnit object_2 = activeUnit_2;
							Mission.Flight flight_2 = flight_0;
							Mission.Flight flight2;
							Waypoint[] waypoint_6 = (flight2 = flight_0).FlightPlan;
							float float_4 = 0f;
							float float_5 = 0f;
							ConnectTokenizer(scenario_2, strike_2, object_2, flight_2, ref waypoint_6, ref float_4, ref float_5, bool_0: false, bool_1, bool_2: false, bool_3: false, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: true, bool_8: false, null, null, bool_9: false);
							flight2.FlightPlan = waypoint_6;
						}
					}
				}
				if (!Information.IsNothing(waypoint_2))
				{
					break;
				}
			}
			if (bool_0 && !Information.IsNothing(activeUnit_0))
			{
				foreach (Waypoint item in list_)
				{
					activeUnit_0.Navigator.ApplyWaypointSpeedAltToUnit(item);
					activeUnit_0.Navigator.ApplyWaypointDoctrineToUnit(item);
					activeUnit_0.Navigator.RemoveWaypoint_Soft(item, bool_1: false);
					if (item.Type != Waypoint.WaypointType.InitialPoint && item.Type != Waypoint.WaypointType.WeaponLaunch)
					{
						if (item.Type == Waypoint.WaypointType.Target || item.Type == Waypoint.WaypointType.WeaponTarget)
						{
							((Aircraft_Navigator)activeUnit_0.Navigator).EgressToRejoinPoint(float_0, bool_1: false);
						}
					}
					else
					{
						((Aircraft_Navigator)activeUnit_0.Navigator).HandleReachedInitialPoint();
					}
				}
			}
			if (num > 0f)
			{
				Scenario scenario_3 = scenario_0;
				Mission strike_3 = mission_0;
				ActiveUnit object_3 = activeUnit_2;
				Mission.Flight flight_3 = flight_0;
				Mission.Flight flight3;
				Waypoint[] waypoint_7 = (flight3 = flight_0).FlightPlan;
				float float_6 = 0f;
				float float_7 = 0f;
				ConnectTokenizer(scenario_3, strike_3, object_3, flight_3, ref waypoint_7, ref float_6, ref float_7, bool_0: false, bool_1, bool_2: false, bool_3: false, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: true, bool_8: false, null, null, bool_9: false);
				flight3.FlightPlan = waypoint_7;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void UpdateStrikeMissionWaypoints_TargetAndIP_WingmenSplitSegment(float float_0, ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, ref Waypoint waypoint_0, ref ActiveUnit activeUnit_0, ref Contact contact_0, ref ActiveUnit activeUnit_1, bool bool_0, ref ActiveUnit activeUnit_2, ref Mission.Flight flight_0, ref Waypoint waypoint_1, ref Waypoint waypoint_2, Mission.Flight.FlightElement flightElement_0, bool bool_1)
	{
		try
		{
			Waypoint waypoint = null;
			Waypoint waypoint2 = null;
			bool flag = false;
			List<Waypoint> list_ = new List<Waypoint>();
			Strike strike = (Strike)mission_0;
			bool flag2 = false;
			Waypoint[] flightPlan = flight_0.FlightPlan;
			float num = 0f;
			double double_ = 0.0;
			double double_2 = 0.0;
			for (int num2 = 0; num2 < flightPlan.Length; num2 = checked(num2 + 1))
			{
				Waypoint waypoint_3 = flightPlan[num2];
				if (!flag2)
				{
					if (waypoint_3 != waypoint_0)
					{
						continue;
					}
					flag2 = true;
				}
				if (waypoint_3.Type == Waypoint.WaypointType.InitialPoint || waypoint_3.Type == Waypoint.WaypointType.WeaponLaunch)
				{
					if (!Information.IsNothing(waypoint_1))
					{
						switch (flightElement_0)
						{
						case Mission.Flight.FlightElement.LeadElementWingman:
							if (!Information.IsNothing(waypoint_3.Waypoint_LeadElementWingman))
							{
								if (waypoint_3.Waypoint_LeadElementWingman != waypoint_1)
								{
									continue;
								}
								break;
							}
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							return;
						case Mission.Flight.FlightElement.SecondElement:
							if (!Information.IsNothing(waypoint_3.Waypoint_SecondElement))
							{
								if (waypoint_3.Waypoint_SecondElement != waypoint_1)
								{
									continue;
								}
								break;
							}
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							return;
						case Mission.Flight.FlightElement.SecondElementWingman:
							if (!Information.IsNothing(waypoint_3.Waypoint_SecondElementWingman))
							{
								if (waypoint_3.Waypoint_SecondElementWingman != waypoint_1)
								{
									continue;
								}
								break;
							}
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							return;
						case Mission.Flight.FlightElement.ThirdElement:
							if (!Information.IsNothing(waypoint_3.Waypoint_ThirdElement))
							{
								if (waypoint_3.Waypoint_ThirdElement != waypoint_1)
								{
									continue;
								}
								break;
							}
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							return;
						case Mission.Flight.FlightElement.ThirdElementWingman:
							if (!Information.IsNothing(waypoint_3.Waypoint_ThirdElementWingman))
							{
								if (waypoint_3.Waypoint_ThirdElementWingman != waypoint_1)
								{
									continue;
								}
								break;
							}
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							return;
						default:
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							return;
						case Mission.Flight.FlightElement.LeadElement:
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							return;
						}
					}
					if (bool_0 && !Information.IsNothing(activeUnit_1))
					{
						if (!Information.IsNothing(contact_0) && activeUnit_1 != contact_0.ActualUnit)
						{
							continue;
						}
						HandleDestroyedContact(ref activeUnit_0, waypoint_3, ref list_);
						flag = true;
					}
					if (!Information.IsNothing(contact_0) && bool_0 && !Information.IsNothing(activeUnit_0) && (waypoint_0.Type == Waypoint.WaypointType.InitialPoint || waypoint_0.Type == Waypoint.WaypointType.WeaponLaunch))
					{
						if (Information.IsNothing(activeUnit_0.Weaponry.MostSuitableWeaponForThisTarget(contact_0, bool_1: false, bool_2: false, bool_3: true, activeUnit_0.Doctrine)))
						{
							continue;
						}
						float num3 = Math2.VerifyClass(waypoint_0.Latitude, waypoint_0.Longitude, contact_0.GetLatitude(), contact_0.GetLongitude());
						float num4 = Math2.VerifyClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), contact_0.GetLatitude(), contact_0.GetLongitude());
						if (num3 > num4)
						{
							activeUnit_0.Navigator.ApplyWaypointSpeedAltToUnit(waypoint_3);
							activeUnit_0.Navigator.ApplyWaypointDoctrineToUnit(waypoint_3);
							activeUnit_0.Navigator.AdjustTankerMustFollowMe_NumberOfWaypoints(ref waypoint_3);
							list_.Add(waypoint_3);
						}
					}
					waypoint = waypoint_3;
				}
				if (waypoint_3.Type != Waypoint.WaypointType.Target && waypoint_3.Type != Waypoint.WaypointType.WeaponTarget)
				{
					continue;
				}
				if (!Information.IsNothing(waypoint_2))
				{
					switch (flightElement_0)
					{
					case Mission.Flight.FlightElement.LeadElementWingman:
						if (!Information.IsNothing(waypoint_3.Waypoint_LeadElementWingman))
						{
							if (waypoint_3.Waypoint_LeadElementWingman != waypoint_2)
							{
								continue;
							}
							waypoint2 = waypoint_3.Waypoint_LeadElementWingman;
							break;
						}
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return;
					case Mission.Flight.FlightElement.SecondElement:
						if (!Information.IsNothing(waypoint_3.Waypoint_SecondElement))
						{
							if (waypoint_3.Waypoint_SecondElement != waypoint_2)
							{
								continue;
							}
							waypoint2 = waypoint_3.Waypoint_SecondElement;
							break;
						}
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return;
					case Mission.Flight.FlightElement.SecondElementWingman:
						if (!Information.IsNothing(waypoint_3.Waypoint_SecondElementWingman))
						{
							if (waypoint_3.Waypoint_SecondElementWingman != waypoint_2)
							{
								continue;
							}
							waypoint2 = waypoint_3.Waypoint_SecondElementWingman;
							break;
						}
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return;
					case Mission.Flight.FlightElement.ThirdElement:
						if (!Information.IsNothing(waypoint_3.Waypoint_ThirdElement))
						{
							if (waypoint_3.Waypoint_ThirdElement != waypoint_2)
							{
								continue;
							}
							waypoint2 = waypoint_3.Waypoint_ThirdElement;
							break;
						}
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return;
					case Mission.Flight.FlightElement.ThirdElementWingman:
						if (!Information.IsNothing(waypoint_3.Waypoint_ThirdElementWingman))
						{
							if (waypoint_3.Waypoint_ThirdElementWingman != waypoint_2)
							{
								continue;
							}
							waypoint2 = waypoint_3.Waypoint_ThirdElementWingman;
							break;
						}
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return;
					case Mission.Flight.FlightElement.LeadElement:
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return;
					}
				}
				if (waypoint2 == null)
				{
					return;
				}
				if (bool_0 && !Information.IsNothing(activeUnit_0))
				{
					if (!flag && !Information.IsNothing(activeUnit_1))
					{
						if (!Information.IsNothing(contact_0) && activeUnit_1 != contact_0.ActualUnit)
						{
							continue;
						}
						HandleDestroyedContact(ref activeUnit_0, waypoint2, ref list_);
					}
					if (Information.IsNothing(contact_0))
					{
						activeUnit_0.AI.DeterminePrimaryTarget(float_0, bool_0: true, bool_1: true);
					}
				}
				if (!Information.IsNothing(waypoint_2))
				{
					if (Information.IsNothing(contact_0))
					{
						if (Information.IsNothing(contact_0) || (strike.RTB_When_Target_Destroyed && strike.TargetCount == 0))
						{
							if (Information.IsNothing(waypoint))
							{
								waypoint2.Latitude = activeUnit_0.GetLatitude();
								waypoint2.Longitude = activeUnit_0.GetLongitude();
								Scenario scenario_ = scenario_0;
								Mission strike_ = mission_0;
								ActiveUnit object_ = activeUnit_2;
								Mission.Flight flight_ = flight_0;
								Mission.Flight flight;
								Waypoint[] waypoint_4 = (flight = flight_0).FlightPlan;
								float float_ = 0f;
								float float_2 = 0f;
								ConnectTokenizer(scenario_, strike_, object_, flight_, ref waypoint_4, ref float_, ref float_2, bool_0: false, bool_1, bool_2: false, bool_3: false, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: true, bool_8: false, null, null, bool_9: false);
								flight.FlightPlan = waypoint_4;
							}
							else
							{
								waypoint2.Latitude = waypoint.Latitude;
								waypoint2.Longitude = waypoint.Longitude;
								Scenario scenario_2 = scenario_0;
								Mission strike_2 = mission_0;
								ActiveUnit object_2 = activeUnit_2;
								Mission.Flight flight_2 = flight_0;
								Mission.Flight flight2;
								Waypoint[] waypoint_5 = (flight2 = flight_0).FlightPlan;
								float float_3 = 0f;
								float float_4 = 0f;
								ConnectTokenizer(scenario_2, strike_2, object_2, flight_2, ref waypoint_5, ref float_3, ref float_4, bool_0: false, bool_1, bool_2: false, bool_3: false, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: true, bool_8: false, null, null, bool_9: false);
								flight2.FlightPlan = waypoint_5;
							}
						}
					}
					else if (waypoint2.Latitude != contact_0.GetLatitude() || waypoint2.Longitude != contact_0.GetLongitude())
					{
						num = Math2.VerifyClass(waypoint2.Latitude, waypoint2.Longitude, contact_0.GetLatitude(), contact_0.GetLongitude());
						float float_5 = Math2.PublishClass(waypoint2.Latitude, waypoint2.Longitude, contact_0.GetLatitude(), contact_0.GetLongitude());
						waypoint2.Latitude = contact_0.GetLatitude();
						waypoint2.Longitude = contact_0.GetLongitude();
						if (!Information.IsNothing(waypoint) && num > 0f)
						{
							Geodesic_EdWilliams.CalcPoint_Williams(waypoint.Longitude, waypoint.Latitude, ref double_, ref double_2, num, float_5);
							waypoint.Latitude = double_2;
							waypoint.Longitude = double_;
						}
					}
				}
				if (!Information.IsNothing(waypoint_2))
				{
					break;
				}
			}
			if (bool_0 && !Information.IsNothing(activeUnit_0))
			{
				foreach (Waypoint item in list_)
				{
					activeUnit_0.Navigator.ApplyWaypointSpeedAltToUnit(item);
					activeUnit_0.Navigator.ApplyWaypointDoctrineToUnit(item);
					activeUnit_0.Navigator.RemoveWaypoint_Soft(item, bool_1: false);
					if (item.Type != Waypoint.WaypointType.InitialPoint && item.Type != Waypoint.WaypointType.WeaponLaunch)
					{
						if (item.Type == Waypoint.WaypointType.Target || item.Type == Waypoint.WaypointType.WeaponTarget)
						{
							((Aircraft_Navigator)activeUnit_0.Navigator).EgressToRejoinPoint(float_0, bool_1: false);
						}
					}
					else
					{
						((Aircraft_Navigator)activeUnit_0.Navigator).HandleReachedInitialPoint();
					}
				}
			}
			if (!Information.IsNothing(waypoint_2) && num > 0f)
			{
				Scenario scenario_3 = scenario_0;
				Mission strike_3 = mission_0;
				ActiveUnit object_3 = activeUnit_2;
				Mission.Flight flight_3 = flight_0;
				Mission.Flight flight3;
				Waypoint[] waypoint_6 = (flight3 = flight_0).FlightPlan;
				float float_6 = 0f;
				float float_7 = 0f;
				ConnectTokenizer(scenario_3, strike_3, object_3, flight_3, ref waypoint_6, ref float_6, ref float_7, bool_0: false, bool_1, bool_2: false, bool_3: false, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: true, bool_8: false, null, null, bool_9: false);
				flight3.FlightPlan = waypoint_6;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void InstantiateTokenizer(ref Waypoint waypoint_0, float float_0, float float_1)
	{
		try
		{
			double longitude = waypoint_0.Longitude;
			double latitude = waypoint_0.Latitude;
			Waypoint obj = waypoint_0;
			double double_ = obj.Longitude;
			Waypoint obj2 = waypoint_0;
			double double_2 = obj2.Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_, ref double_2, float_0, float_1);
			obj2.Latitude = double_2;
			obj.Longitude = double_;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void HandleDestroyedContact(ref ActiveUnit activeUnit_0, Waypoint waypoint_0, ref List<Waypoint> list_0)
	{
		activeUnit_0.AI.PrimaryTarget = null;
		activeUnit_0.AI.DeterminePrimaryTarget(1f, bool_0: true, bool_1: true);
		if (Information.IsNothing(activeUnit_0.AI.PrimaryTarget))
		{
			list_0.Add(waypoint_0);
		}
	}

	public static void CheckRangeToMissionTargets_LoadoutRadius(Scenario scenario_0, Mission mission_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			if (mission_0.MissionClass != Mission._MissionClass.Strike)
			{
				return;
			}
			Strike strike_ = (Strike)mission_0;
			if (strike_.Type == Strike.StrikeType.Air_Intercept || (strike_.RTB_When_Target_Destroyed && strike_.TargetCount == 0))
			{
				return;
			}
			Doctrine._UseUnderwayRefuelAndReplenishment? useReplenishment = mission_0.Doctrine.GetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			if (Information.IsNothing(activeUnit_0) || !activeUnit_0.IsAircraft || activeUnit_0.AI.IsEscort)
			{
				return;
			}
			Aircraft Local_theAC = null;
			Local_theAC = (Aircraft)activeUnit_0;
			byte? b = (byte?)useReplenishment;
			bool? flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
			if (((!flag) ?? flag).GetValueOrDefault() && (Local_theAC.ProbeRefuelling || Local_theAC.BoomRefuelling))
			{
				return;
			}
			bool flag2 = true;
			Doctrine._UseShootTourists? Local_Doctrine_ShootTourists = Local_theAC.Doctrine.GetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			List<Contact> list = new List<Contact>();
			list.AddRange(activeUnit_0.GetUnitSide().Contacts.Values);
			float num = Local_theAC.AI.PushClient(ref ((Strike)mission_0).Type);
			float num2;
			if (Local_theAC.Loadout.CombatRadius > 0 && Local_theAC.Loadout.TimeOnStation_Minutes == 0)
			{
				num2 = (float)Local_theAC.Loadout.CombatRadius + num;
			}
			else
			{
				num2 = Local_theAC.Kinematics.TacticalRadius();
				num2 += num;
			}
			if (num2 <= 0f)
			{
				return;
			}
			float num3 = 0f;
			if (strike_.TargetCount <= 0)
			{
				List<Contact> list2 = list.Where(delegate(Contact theC)
				{
					Aircraft_AI aI = Local_theAC.AI;
					string string_ = "";
					int int_ = 0;
					return aI.ContactIsRelevantToMission(theC, mission_0, Local_Doctrine_ShootTourists, bool_0: false, bool_1: false, bool_2: true, null, ref string_, ref int_);
				}).ToList();
				if (list2.Count <= 0)
				{
					flag2 = false;
				}
				else
				{
					foreach (Contact item in list2)
					{
						if (Local_theAC.AI.IncludeClient(ref strike_, item.GetStance(Local_theAC.GetUnitSide())))
						{
							num3 = Module_Unit.RangeToUnit_Horiz(activeUnit_0, item);
							if (num3 <= num2)
							{
								flag2 = false;
							}
							if (!flag2)
							{
								break;
							}
						}
					}
				}
			}
			else
			{
				foreach (Contact item2 in list)
				{
					if (item2.GetIsSpecificTargetForThisStrike(strike_) && Local_theAC.AI.IncludeClient(ref strike_, item2.GetStance(Local_theAC.GetUnitSide())))
					{
						num3 = Module_Unit.RangeToUnit_Horiz(activeUnit_0, item2);
						if (num3 <= num2)
						{
							flag2 = false;
						}
						if (!flag2)
						{
							break;
						}
					}
				}
				foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
				{
					if (!Information.IsNothing(activeUnits_) && activeUnits_.GetIsSpecificTargetForThisStrike(strike_))
					{
						num3 = Module_Unit.RangeToUnit_Horiz(activeUnit_0, activeUnits_);
						if (num3 <= num2)
						{
							flag2 = false;
						}
						if (!flag2)
						{
							break;
						}
					}
				}
			}
			if (flag2)
			{
				Interaction.MsgBox("飞机" + Local_theAC.Name + "目前已超出目标范围。到目标的距离是" + Conversions.ToString((int)Math.Round(num3)) + "海里而攻击半径为" + Conversions.ToString(num2) + "海里。该单元已添加到任务中，但除非目标靠近或您更改为更远程的挂载，否则不会起飞。");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200620", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void CreateTokenizer(ref Scenario scenario_0, ref Mission.Flight flight_0, ref Waypoint waypoint_0, ref float? nullable_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0)
	{
		try
		{
			if (waypoint_0.TerrainFollowing && !Information.IsNothing(waypoint_0.DesiredAltitude_TerrainFollowing))
			{
				nullable_0 = waypoint_0.DesiredAltitude_TerrainFollowing;
			}
			else if (Information.IsNothing(waypoint_0.DesiredAltitude))
			{
				nullable_0 = nullable_0;
			}
			else
			{
				nullable_0 = waypoint_0.DesiredAltitude;
			}
			if (unitThrottlePreset_0 != ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				return;
			}
			if (!(waypoint_0.ActualSpeed <= 0f) && !Information.IsNothing(nullable_0))
			{
				if (!Information.IsNothing(flight_0.GetReferenceUnit(scenario_0)))
				{
					unitThrottlePreset_0 = (ActiveUnit_Kinematics.UnitThrottlePreset)flight_0.GetReferenceUnit(scenario_0).Kinematics.GetThrottleSuitableForThisSpeed(nullable_0.Value, waypoint_0.ActualSpeed);
				}
			}
			else
			{
				unitThrottlePreset_0 = unitThrottlePreset_0;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200621", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void CompareTokenizer(ref Scenario scenario_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Waypoint[] waypoint_0, ref Waypoint waypoint_1, ref Waypoint waypoint_2, string string_0, bool bool_0)
	{
		try
		{
			if (Information.IsNothing(waypoint_2) || Information.IsNothing(waypoint_1.Time_Zulu) || Information.IsNothing(waypoint_2.Time_Zulu))
			{
				return;
			}
			bool flag = false;
			if (DateTime.Compare(waypoint_2.Time_Zulu.Value, waypoint_1.Time_Zulu.Value) > 0)
			{
				if (bool_0)
				{
					if (string.IsNullOrEmpty(waypoint_2.Description))
					{
						MoveTokenizer(ref waypoint_0);
					}
					if (Information.IsNothing(flight_0.ErrorList))
					{
						flight_0.ErrorList = new List<MDSP_Error>();
					}
					flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "：航点的到达时间" + waypoint_2.Description + "比航点的到达时间晚" + waypoint_1.Description + ". Check locked times and/or speeds."));
					flight_0.HasCriticalError = true;
				}
				else
				{
					scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "：航点的到达时间" + waypoint_2.Description + "比航点的到达时间晚" + waypoint_1.Description + ". Check locked times and/or speeds."));
					flight_0.HasCriticalError = true;
				}
				flag = true;
			}
			if (flag || waypoint_1.Type == Waypoint.WaypointType.TakeOff || waypoint_1.EnableReponse())
			{
				return;
			}
			double totalSeconds = (waypoint_2.Time_Zulu.Value.AddSeconds(waypoint_1.Leg_Time_Straight + waypoint_1.Leg_Time_Turn + waypoint_1.Hold_Time + waypoint_1.Station_Time + waypoint_1.SpacingManeuver_Time) - waypoint_1.Time_Zulu.Value).TotalSeconds;
			if (Math.Abs(totalSeconds) <= 20.0)
			{
				return;
			}
			double num = 0.0;
			double num2 = 0.0;
			if (!Information.IsNothing(waypoint_1.Leg_Distance_Straight) && waypoint_1.Leg_Distance_Straight > 0f && !Information.IsNothing(waypoint_1.Leg_Speed_Straight) && waypoint_1.Leg_Speed_Straight > 0f)
			{
				num = waypoint_1.Leg_Distance_Straight / waypoint_1.Leg_Speed_Straight * 3600f;
				num2 = waypoint_1.Leg_Distance_Straight / (waypoint_1.Leg_Speed_Straight + 21f) * 3600f;
			}
			if (!Information.IsNothing(waypoint_1.Leg_Distance_Turn) && waypoint_1.Leg_Distance_Turn > 0f && !Information.IsNothing(waypoint_1.Leg_Speed_Turn) && waypoint_1.Leg_Speed_Turn > 0f)
			{
				num += (double)(waypoint_1.Leg_Distance_Turn / waypoint_1.Leg_Speed_Turn * 3600f);
				num2 += (double)(waypoint_1.Leg_Distance_Turn / (waypoint_1.Leg_Speed_Turn + 21f) * 3600f);
			}
			double val = Math.Abs(num - num2) * 10.0;
			val = Math.Max(val, 100.0);
			if (totalSeconds <= val)
			{
				if (!(totalSeconds < 0.0 - val))
				{
					return;
				}
				if (bool_0)
				{
					if (string.IsNullOrEmpty(waypoint_1.Description))
					{
						MoveTokenizer(ref waypoint_0);
					}
					if (Information.IsNothing(flight_0.ErrorList))
					{
						flight_0.ErrorList = new List<MDSP_Error>();
					}
					flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "：到达航点" + waypoint_1.Description + "时间早于预期，请检查锁定的时间和/或速度。"));
					flight_0.HasCriticalError = true;
				}
				else
				{
					scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "：到达航点" + waypoint_1.Description + "时间早于预期，请检查锁定的时间和/或速度。"));
					flight_0.HasCriticalError = true;
				}
			}
			else if (bool_0)
			{
				if (string.IsNullOrEmpty(waypoint_1.Description))
				{
					MoveTokenizer(ref waypoint_0);
				}
				if (Information.IsNothing(flight_0.ErrorList))
				{
					flight_0.ErrorList = new List<MDSP_Error>();
				}
				flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "：到达航点" + waypoint_1.Description + "时间晚于预期，请检查锁定的时间和/或速度。"));
				flight_0.HasCriticalError = true;
			}
			else
			{
				scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "：到达航点" + waypoint_1.Description + "时间晚于预期，请检查锁定的时间和/或速度。"));
				flight_0.HasCriticalError = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200622", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void ReadTokenizer(ref Scenario scenario_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Waypoint[] waypoint_0, ref Waypoint waypoint_1, ref float? nullable_0, string string_0, bool bool_0)
	{
		try
		{
			if (Information.IsNothing(waypoint_1.DesiredSpeedOverride) || Information.IsNothing(waypoint_1.DesiredSpeed) || Information.IsNothing(nullable_0) || Information.IsNothing(flight_0.GetReferenceUnit(scenario_0)))
			{
				return;
			}
			if (waypoint_1.DesiredSpeed.Value < (float)flight_0.GetReferenceUnit(scenario_0).Kinematics.GetMinimumSpeed(nullable_0.Value, ActiveUnit.Throttle.Loiter, bool_0: false))
			{
				if (bool_0)
				{
					if (string.IsNullOrEmpty(waypoint_1.Description))
					{
						MoveTokenizer(ref waypoint_0);
					}
					if (Information.IsNothing(flight_0.ErrorList))
					{
						flight_0.ErrorList = new List<MDSP_Error>();
					}
					flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "：航点的速度" + waypoint_1.Description + "太低了（" + Conversions.ToString(waypoint_1.DesiredSpeed.Value) + "节 vs" + Conversions.ToString(flight_0.GetReferenceUnit(scenario_0).Kinematics.GetMinimumSpeed(nullable_0.Value, ActiveUnit.Throttle.Loiter, bool_0: false)) + "节）"));
					flight_0.HasCriticalError = true;
				}
				else
				{
					scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "：航点的速度" + waypoint_1.Description + "太低了（" + Conversions.ToString(waypoint_1.DesiredSpeed.Value) + "节 vs" + Conversions.ToString(flight_0.GetReferenceUnit(scenario_0).Kinematics.GetMinimumSpeed(nullable_0.Value, ActiveUnit.Throttle.Loiter, bool_0: false)) + "节）"));
					flight_0.HasCriticalError = true;
				}
			}
			if (waypoint_1.DesiredSpeed.Value <= (float)flight_0.GetReferenceUnit(scenario_0).Kinematics.GetMaximumSpeed(nullable_0.Value, ActiveUnit.Throttle.Flank, bool_0: false))
			{
				return;
			}
			if (bool_0)
			{
				if (string.IsNullOrEmpty(waypoint_1.Description))
				{
					MoveTokenizer(ref waypoint_0);
				}
				if (Information.IsNothing(flight_0.ErrorList))
				{
					flight_0.ErrorList = new List<MDSP_Error>();
				}
				flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "：航点的速度" + waypoint_1.Description + "太高了（" + Conversions.ToString(waypoint_1.DesiredSpeed.Value) + "节 vs" + Conversions.ToString(flight_0.GetReferenceUnit(scenario_0).Kinematics.GetMaximumSpeed(nullable_0.Value, ActiveUnit.Throttle.Flank, bool_0: false)) + "节）"));
				flight_0.HasCriticalError = true;
			}
			else
			{
				scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "：航点的速度" + waypoint_1.Description + "太高了（" + Conversions.ToString(waypoint_1.DesiredSpeed.Value) + "节 vs" + Conversions.ToString(flight_0.GetReferenceUnit(scenario_0).Kinematics.GetMaximumSpeed(nullable_0.Value, ActiveUnit.Throttle.Flank, bool_0: false)) + "节）"));
				flight_0.HasCriticalError = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200623", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void DisableTokenizer(ref Scenario scenario_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Waypoint[] waypoint_0, ref Waypoint waypoint_1, ref Waypoint waypoint_2, ref Waypoint waypoint_3, ref float? nullable_0, ref float? nullable_1, ref float? nullable_2, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_1, ref ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_2, ref bool? nullable_3, ref float? nullable_4, ref bool? nullable_5, ref float? nullable_6, ref bool? nullable_7, ref float? nullable_8, object object_0, bool bool_0)
	{
		try
		{
			if (waypoint_1.Type != Waypoint.WaypointType.TakeOff && waypoint_1.Type != Waypoint.WaypointType.Assemble && !waypoint_1.CheckReponse() && waypoint_1.Type != Waypoint.WaypointType.LandingMarshal && waypoint_1.Type != Waypoint.WaypointType.Land)
			{
				waypoint_1.IncludeReponse();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200624", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void UpdateTokenizer(ref Scenario scenario_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Waypoint waypoint_0, bool bool_0)
	{
		try
		{
			if (waypoint_0.Leg_FuelRemaining < 0f)
			{
				if (bool_0)
				{
					if (Information.IsNothing(flight_0.ErrorList))
					{
						flight_0.ErrorList = new List<MDSP_Error>();
					}
					flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, ", a/c #1: Not enough fuel for flightplan (" + Conversions.ToString(Math.Abs(Math.Round(waypoint_0.Leg_FuelRemaining))) + "kg)."));
					flight_0.HasCriticalError = true;
				}
				else
				{
					scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "a/c #1:  Not enough fuel for flightplan (" + Conversions.ToString(Math.Abs(Math.Round(waypoint_0.Leg_FuelRemaining))) + "kg)."));
					flight_0.HasCriticalError = true;
				}
			}
			if (waypoint_0.Leg_FuelRemaining_LeadElementWingman < 0f)
			{
				if (bool_0)
				{
					if (Information.IsNothing(flight_0.ErrorList))
					{
						flight_0.ErrorList = new List<MDSP_Error>();
					}
					flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, ", a / C #2:   Not enough fuel for flightplan (" + Conversions.ToString(Math.Abs(Math.Round(waypoint_0.Leg_FuelRemaining_LeadElementWingman))) + "kg)."));
					flight_0.HasCriticalError = true;
				}
				else
				{
					scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, ", a/c #2: Not enough fuel for flightplan (" + Conversions.ToString(Math.Abs(Math.Round(waypoint_0.Leg_FuelRemaining_LeadElementWingman))) + "kg)."));
					flight_0.HasCriticalError = true;
				}
			}
			if (waypoint_0.Leg_FuelRemaining_SecondElement < 0f)
			{
				if (bool_0)
				{
					if (Information.IsNothing(flight_0.ErrorList))
					{
						flight_0.ErrorList = new List<MDSP_Error>();
					}
					flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, ", a/c #3: Not enough fuel for flightplan (" + Conversions.ToString(Math.Abs(Math.Round(waypoint_0.Leg_FuelRemaining_SecondElement))) + "kg)."));
					flight_0.HasCriticalError = true;
				}
				else
				{
					scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, ", a/c #3: Not enough fuel for flightplan (" + Conversions.ToString(Math.Abs(Math.Round(waypoint_0.Leg_FuelRemaining_SecondElement))) + "kg)."));
					flight_0.HasCriticalError = true;
				}
			}
			if (waypoint_0.Leg_FuelRemaining_SecondElementWingman < 0f)
			{
				if (bool_0)
				{
					if (Information.IsNothing(flight_0.ErrorList))
					{
						flight_0.ErrorList = new List<MDSP_Error>();
					}
					flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, ", a/c #4: Not enough fuel for flightplan (" + Conversions.ToString(Math.Abs(Math.Round(waypoint_0.Leg_FuelRemaining_SecondElementWingman))) + "kg)."));
					flight_0.HasCriticalError = true;
				}
				else
				{
					scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, ", a/c #4: Not enough fuel for flightplan (" + Conversions.ToString(Math.Abs(Math.Round(waypoint_0.Leg_FuelRemaining_SecondElementWingman))) + "kg)."));
					flight_0.HasCriticalError = true;
				}
			}
			if (waypoint_0.Leg_FuelRemaining_ThirdElement < 0f)
			{
				if (bool_0)
				{
					if (Information.IsNothing(flight_0.ErrorList))
					{
						flight_0.ErrorList = new List<MDSP_Error>();
					}
					flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, ", a/c #5: Not enough fuel for flightplan (" + Conversions.ToString(Math.Abs(Math.Round(waypoint_0.Leg_FuelRemaining_ThirdElement))) + "kg)."));
					flight_0.HasCriticalError = true;
				}
				else
				{
					scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, ", a/c #5: Not enough fuel for flightplan (" + Conversions.ToString(Math.Abs(Math.Round(waypoint_0.Leg_FuelRemaining_ThirdElement))) + "kg)."));
					flight_0.HasCriticalError = true;
				}
			}
			if (!(waypoint_0.Leg_FuelRemaining_ThirdElementWingman < 0f))
			{
				return;
			}
			if (bool_0)
			{
				if (Information.IsNothing(flight_0.ErrorList))
				{
					flight_0.ErrorList = new List<MDSP_Error>();
				}
				flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, ", a/c #6: Not enough fuel for flightplan (" + Conversions.ToString(Math.Abs(Math.Round(waypoint_0.Leg_FuelRemaining_ThirdElementWingman))) + "kg)."));
				flight_0.HasCriticalError = true;
			}
			else
			{
				scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, ", a/c #6: Not enough fuel for flightplan (" + Conversions.ToString(Math.Abs(Math.Round(waypoint_0.Leg_FuelRemaining_ThirdElementWingman))) + "kg)."));
				flight_0.HasCriticalError = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200625", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void InsertTokenizer(ref Scenario scenario_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Waypoint waypoint_0, string string_0, bool bool_0)
	{
		try
		{
			Waypoint.WaypointType type = waypoint_0.Type;
			if (type != Waypoint.WaypointType.Assemble && type != Waypoint.WaypointType.HoldEnd)
			{
				if (waypoint_0.Hold_Time == 0f)
				{
					return;
				}
				if (bool_0)
				{
					if (Information.IsNothing(flight_0.ErrorList))
					{
						flight_0.ErrorList = new List<MDSP_Error>();
					}
					flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "不是警戒型。删除警戒时间。"));
					flight_0.HasCriticalError = true;
				}
				else
				{
					scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "不是警戒型。删除警戒时间。"));
					flight_0.HasCriticalError = true;
				}
			}
			else
			{
				if (waypoint_0.FlightFormation != Waypoint.Formation.Split)
				{
					return;
				}
				if (bool_0)
				{
					if (Information.IsNothing(flight_0.ErrorList))
					{
						flight_0.ErrorList = new List<MDSP_Error>();
					}
					flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是警戒型。删除分解队形。"));
					flight_0.HasCriticalError = true;
				}
				else
				{
					scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是警戒型。删除分解队形。"));
					flight_0.HasCriticalError = true;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void PrepareTokenizer(ref Scenario scenario_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Waypoint waypoint_0, string string_0, ref bool bool_0, ref bool bool_1, ref bool bool_2, bool bool_3)
	{
		try
		{
			if (flight_0.IsEscort)
			{
				switch (waypoint_0.Type)
				{
				case Waypoint.WaypointType.InitialPoint:
				case Waypoint.WaypointType.WeaponLaunch:
					if (bool_3)
					{
						if (Information.IsNothing(flight_0.ErrorList))
						{
							flight_0.ErrorList = new List<MDSP_Error>();
						}
						flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是初始点或武器发射类型，但这是一个护航编队，不应使用此航点类型！"));
						flight_0.HasCriticalError = true;
					}
					else
					{
						scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是初始点或武器发射类型，但这是一个护航编队，不应使用此航点类型！"));
						flight_0.HasCriticalError = true;
					}
					break;
				case Waypoint.WaypointType.Target:
				case Waypoint.WaypointType.WeaponTarget:
					if (bool_3)
					{
						if (Information.IsNothing(flight_0.ErrorList))
						{
							flight_0.ErrorList = new List<MDSP_Error>();
						}
						flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是Target或Weapon Target类型，但这是一个护航编队，不应该使用这种航点类型！"));
						flight_0.HasCriticalError = true;
					}
					else
					{
						scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是Target或Weapon Target类型，但这是一个护航编队，不应该使用这种航点类型！"));
						flight_0.HasCriticalError = true;
					}
					break;
				case Waypoint.WaypointType.StrikeIngress:
				case Waypoint.WaypointType.StrikeEgress:
					if (bool_3)
					{
						if (Information.IsNothing(flight_0.ErrorList))
						{
							flight_0.ErrorList = new List<MDSP_Error>();
						}
						flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是图灵点（入口）或转折点（出口）类型，但这是一个护航飞行，不应该使用这种航点类型！"));
						flight_0.HasCriticalError = true;
					}
					else
					{
						scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是图灵点（入口）或转折点（出口）类型，但这是一个护航飞行，不应该使用这种航点类型！"));
						flight_0.HasCriticalError = true;
					}
					break;
				}
				return;
			}
			if (bool_0)
			{
				switch (waypoint_0.Type)
				{
				case Waypoint.WaypointType.Target:
				case Waypoint.WaypointType.WeaponTarget:
					bool_0 = false;
					bool_1 = true;
					break;
				case Waypoint.WaypointType.InitialPoint:
				case Waypoint.WaypointType.WeaponLaunch:
					bool_2 = true;
					break;
				case Waypoint.WaypointType.StrikeEgress:
					if (bool_3)
					{
						if (Information.IsNothing(flight_0.ErrorList))
						{
							flight_0.ErrorList = new List<MDSP_Error>();
						}
						flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是转折点（出口）类型，但在入口航段上。"));
						flight_0.HasCriticalError = true;
					}
					else
					{
						scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是转折点（出口）类型，但在入口航段上。"));
						flight_0.HasCriticalError = true;
					}
					break;
				}
			}
			else if (waypoint_0.Type == Waypoint.WaypointType.StrikeIngress)
			{
				if (bool_3)
				{
					if (Information.IsNothing(flight_0.ErrorList))
					{
						flight_0.ErrorList = new List<MDSP_Error>();
					}
					flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是转折点（入口）类型，但在出口航段上。"));
					flight_0.HasCriticalError = true;
				}
				else
				{
					scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是转折点（入口）类型，但在出口航段上。"));
					flight_0.HasCriticalError = true;
				}
			}
			switch (waypoint_0.Type)
			{
			case Waypoint.WaypointType.StationStart_Racetrack:
			case Waypoint.WaypointType.StationStart_FigureEight:
			case Waypoint.WaypointType.StationStart_Area:
			case Waypoint.WaypointType.StationStart_RaceTrackRandom:
			case Waypoint.WaypointType.StationEnd:
				if (bool_3)
				{
					if (Information.IsNothing(flight_0.ErrorList))
					{
						flight_0.ErrorList = new List<MDSP_Error>();
					}
					flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是巡逻类型，对于攻击任务不合法。"));
					flight_0.HasCriticalError = true;
				}
				else
				{
					scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是巡逻类型，对于攻击任务不合法。"));
					flight_0.HasCriticalError = true;
				}
				break;
			case Waypoint.WaypointType.TurningPoint:
				if (bool_3)
				{
					if (Information.IsNothing(flight_0.ErrorList))
					{
						flight_0.ErrorList = new List<MDSP_Error>();
					}
					flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "必须是转折点（入口）或转折点（出口）类型。"));
					flight_0.HasCriticalError = true;
				}
				else
				{
					scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "必须是转折点（入口）或转折点（出口）类型。"));
					flight_0.HasCriticalError = true;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void ReflectTokenizer(ref Scenario scenario_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Waypoint waypoint_0, string string_0, ref bool bool_0, ref bool bool_1, bool bool_2)
	{
		try
		{
			if (bool_0 && waypoint_0.Type == Waypoint.WaypointType.StationEnd)
			{
				bool_1 = true;
			}
			switch (waypoint_0.Type)
			{
			case Waypoint.WaypointType.StationEnd:
			{
				if (flight_0.Type != Mission._FlightType.FlightplanTemplate || waypoint_0.Station_Time != 0f)
				{
					break;
				}
				if (mission_0.MissionClass == Mission._MissionClass.Patrol)
				{
					Patrol patrol = (Patrol)mission_0;
					if (flight_0.Task != Mission._FlightTask.QRA && patrol.ContinousCoverage_Enable)
					{
						if (bool_2)
						{
							if (Information.IsNothing(flight_0.ErrorList))
							{
								flight_0.ErrorList = new List<MDSP_Error>();
							}
							flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "（连续覆盖的模板）：Waypoint" + waypoint_0.Description + "是没有设置巡逻时间的结束巡逻航路点。使用连续覆盖的任务的飞行计划模板必须设置巡逻时间！"));
							flight_0.HasCriticalError = true;
						}
						else
						{
							scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "（连续覆盖的模板）：Waypoint" + waypoint_0.Description + "是没有设置巡逻时间的结束巡逻航路点。使用连续覆盖的任务的飞行计划模板必须设置巡逻时间！"));
							flight_0.HasCriticalError = true;
						}
					}
				}
				if (mission_0.MissionClass != Mission._MissionClass.Support)
				{
					break;
				}
				SupportMission supportMission = (SupportMission)mission_0;
				if (flight_0.Task == Mission._FlightTask.QRA || !supportMission.ContinousCoverage_Enable)
				{
					break;
				}
				if (bool_2)
				{
					if (Information.IsNothing(flight_0.ErrorList))
					{
						flight_0.ErrorList = new List<MDSP_Error>();
					}
					flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "（连续覆盖的模板）：Waypoint" + waypoint_0.Description + "是没有设置巡逻时间的结束巡逻航路点。使用连续覆盖的任务的飞行计划模板必须设置巡逻时间！"));
					flight_0.HasCriticalError = true;
				}
				else
				{
					scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "（连续覆盖的模板）：Waypoint" + waypoint_0.Description + "是没有设置巡逻时间的结束巡逻航路点。使用连续覆盖的任务的飞行计划模板必须设置巡逻时间！"));
					flight_0.HasCriticalError = true;
				}
				break;
			}
			case Waypoint.WaypointType.StrikeIngress:
			case Waypoint.WaypointType.StrikeEgress:
				if (bool_2)
				{
					if (Information.IsNothing(flight_0.ErrorList))
					{
						flight_0.ErrorList = new List<MDSP_Error>();
					}
					flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是转向点（入口）或转向点（出口）类型，对于巡逻或支援任务来说是不合法的。"));
					flight_0.HasCriticalError = true;
				}
				else
				{
					scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是转向点（入口）或转向点（出口）类型，对于巡逻或支援任务来说是不合法的。"));
					flight_0.HasCriticalError = true;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void VisitTokenizer(ref Scenario scenario_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Waypoint waypoint_0, string string_0, bool bool_0)
	{
		try
		{
			if (waypoint_0.Type != Waypoint.WaypointType.Refuel)
			{
				return;
			}
			Doctrine._UseUnderwayRefuelAndReplenishment? useReplenishment = waypoint_0.Doctrine.GetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			Doctrine._UnderwayRefuelAndReplenishmentSelection? replenishmentSelection = waypoint_0.Doctrine.GetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			byte? b = (byte?)useReplenishment;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				if (bool_0)
				{
					if (Information.IsNothing(flight_0.ErrorList))
					{
						flight_0.ErrorList = new List<MDSP_Error>();
					}
					flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是加油类型但加油机（AAR）设置为不允许。"));
					flight_0.HasCriticalError = true;
				}
				else
				{
					scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是加油类型但加油机（AAR）设置为不允许。"));
					flight_0.HasCriticalError = true;
				}
			}
			b = (byte?)useReplenishment;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
			{
				if (bool_0)
				{
					if (Information.IsNothing(flight_0.ErrorList))
					{
						flight_0.ErrorList = new List<MDSP_Error>();
					}
					flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是加油类型但加油机（AAR）设置为未配置。"));
					flight_0.HasCriticalError = true;
				}
				else
				{
					scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是加油类型但加油机（AAR）设置为未配置。"));
					flight_0.HasCriticalError = true;
				}
			}
			b = (byte?)replenishmentSelection;
			if (!(b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
			{
				return;
			}
			if (bool_0)
			{
				if (Information.IsNothing(flight_0.ErrorList))
				{
					flight_0.ErrorList = new List<MDSP_Error>();
				}
				flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是加油类型但加油机选择设置为未配置。"));
				flight_0.HasCriticalError = true;
			}
			else
			{
				scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, string_0 + "： 航点" + waypoint_0.Description + "是加油类型但加油机选择设置为未配置。"));
				flight_0.HasCriticalError = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void RestartTokenizer(ref Scenario scenario_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Waypoint[] waypoint_0, bool bool_0)
	{
		if (Information.IsNothing(scenario_0))
		{
			return;
		}
		try
		{
			if (Information.IsNothing(flight_0))
			{
				return;
			}
			for (int i = scenario_0.MissionPlannerErrorList.Count - 1; i >= 0; i += -1)
			{
				MDSP_Error mDSP_Error = scenario_0.MissionPlannerErrorList[i];
				if (Operators.CompareString(mDSP_Error.Flight, flight_0.Callsign, TextCompare: false) == 0)
				{
					scenario_0.MissionPlannerErrorList.Remove(mDSP_Error);
				}
			}
			if (propertyConsumer)
			{
				flight_0.HasCriticalError = true;
			}
			List<string> readerConsumer = _ReaderConsumer;
			if (readerConsumer != null && readerConsumer.Count > 0)
			{
				int num = _ReaderConsumer.Count - 1;
				for (int j = 0; j <= num; j++)
				{
					MDSP_Error mDSP_Error2 = new MDSP_Error();
					try
					{
						mDSP_Error2.Mission = mission_0.Name;
						mDSP_Error2.Flight = flight_0.Callsign;
						mDSP_Error2.Message = _ReaderConsumer[j];
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
						continue;
					}
					if (bool_0)
					{
						if (flight_0.ErrorList == null)
						{
							flight_0.ErrorList = new List<MDSP_Error>();
						}
						flight_0.ErrorList.Add(mDSP_Error2);
					}
					else
					{
						scenario_0.MissionPlannerErrorList.Add(mDSP_Error2);
					}
				}
				_ReaderConsumer.Clear();
			}
			ValidateFlightPlan(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, bool_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200626", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void ValidateFlightPlan(ref Scenario scenario_0, ref Mission mission_0, ref Mission.Flight flight_0, ref Waypoint[] waypoint_0, bool bool_0)
	{
		try
		{
			Waypoint[] array = waypoint_0;
			Waypoint[] array2 = array;
			foreach (Waypoint waypoint in array2)
			{
				DateTime? time_Zulu = waypoint.Time_Zulu;
				DateTime time = scenario_0.Time;
				if ((time_Zulu.HasValue ? new bool?(DateTime.Compare(time_Zulu.GetValueOrDefault(), time) < 0) : null).GetValueOrDefault())
				{
					if (Information.IsNothing(flight_0.ErrorList))
					{
						flight_0.ErrorList = new List<MDSP_Error>();
					}
					flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, waypoint.Description + " time is in the past"));
					flight_0.HasCriticalError = true;
				}
			}
			int num = waypoint_0.Count();
			if (num == 0 || flight_0.GetIsActive(flight_0.GetAUCurrentlyAssigned(mission_0, scenario_0)))
			{
				return;
			}
			Waypoint waypoint2 = null;
			Waypoint waypoint3 = null;
			Waypoint waypoint4 = null;
			Waypoint waypoint5 = null;
			Waypoint waypoint6 = null;
			Waypoint waypoint7 = null;
			Waypoint waypoint_ = null;
			Waypoint waypoint_5 = null;
			Waypoint waypoint_6 = null;
			Waypoint waypoint_7 = null;
			Waypoint waypoint_8 = null;
			Waypoint waypoint_9 = null;
			float? nullable_ = null;
			float? nullable_12 = null;
			float? nullable_23 = null;
			float? nullable_34 = null;
			float? nullable_45 = null;
			float? nullable_51 = null;
			float? nullable_52 = null;
			float? nullable_53 = null;
			float? nullable_54 = null;
			float? nullable_2 = null;
			float? nullable_3 = null;
			float? nullable_4 = null;
			bool? nullable_5 = null;
			bool? nullable_6 = null;
			bool? nullable_7 = null;
			bool? nullable_8 = null;
			bool? nullable_9 = null;
			bool? nullable_10 = null;
			ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_ = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_10 = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_11 = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_12 = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_13 = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_14 = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			Waypoint waypoint_10 = null;
			Waypoint waypoint_11 = null;
			Waypoint waypoint_12 = null;
			Waypoint waypoint_2 = null;
			Waypoint waypoint_3 = null;
			Waypoint waypoint_4 = null;
			float? nullable_11 = null;
			float? nullable_13 = null;
			float? nullable_14 = null;
			float? nullable_15 = null;
			float? nullable_16 = null;
			float? nullable_17 = null;
			float? nullable_18 = null;
			float? nullable_19 = null;
			float? nullable_20 = null;
			float? nullable_21 = null;
			float? nullable_22 = null;
			float? nullable_24 = null;
			bool? nullable_25 = null;
			bool? nullable_26 = null;
			bool? nullable_27 = null;
			bool? nullable_28 = null;
			bool? nullable_29 = null;
			bool? nullable_30 = null;
			ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_15 = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_16 = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_17 = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_2 = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_3 = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_4 = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			bool bool_ = true;
			bool bool_2 = false;
			bool bool_3 = false;
			bool bool_4 = true;
			bool bool_5 = false;
			int num2 = num - 1;
			for (int i = 0; i <= num2; i++)
			{
				waypoint2 = waypoint_0[i];
				waypoint3 = (Information.IsNothing(waypoint2.Waypoint_LeadElementWingman) ? null : waypoint2.Waypoint_LeadElementWingman);
				waypoint4 = (Information.IsNothing(waypoint2.Waypoint_SecondElement) ? null : waypoint2.Waypoint_SecondElement);
				waypoint5 = (Information.IsNothing(waypoint2.Waypoint_SecondElementWingman) ? null : waypoint2.Waypoint_SecondElementWingman);
				waypoint6 = (Information.IsNothing(waypoint2.Waypoint_ThirdElement) ? null : waypoint2.Waypoint_ThirdElement);
				waypoint7 = (Information.IsNothing(waypoint2.Waypoint_ThirdElementWingman) ? null : waypoint2.Waypoint_ThirdElementWingman);
				if (waypoint2.Type == Waypoint.WaypointType.TakeOff && Information.IsNothing(waypoint2.DesiredSpeed) && waypoint2.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
				{
					if (bool_0)
					{
						if (Information.IsNothing(flight_0.ErrorList))
						{
							flight_0.ErrorList = new List<MDSP_Error>();
						}
						flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：起飞航路点没有速度设置。"));
						flight_0.HasCriticalError = true;
					}
					else
					{
						scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：起飞航路点没有速度设置。"));
						flight_0.HasCriticalError = true;
					}
				}
				float? nullable_31 = null;
				float? nullable_32 = null;
				float? nullable_33 = null;
				float? nullable_35 = null;
				float? nullable_36 = null;
				float? nullable_37 = null;
				bool? nullable_38 = null;
				bool? nullable_39 = null;
				bool? nullable_40 = null;
				bool? nullable_41 = null;
				bool? nullable_42 = null;
				bool? nullable_43 = null;
				float? nullable_44 = null;
				float? nullable_46 = null;
				float? nullable_47 = null;
				float? nullable_48 = null;
				float? nullable_49 = null;
				float? nullable_50 = null;
				ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_5 = waypoint2.ThrottlePreset;
				ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_6 = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_7 = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_8 = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_9 = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				CreateTokenizer(ref scenario_0, ref flight_0, ref waypoint2, ref nullable_31, ref unitThrottlePreset_5);
				CompareTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref waypoint2, ref waypoint_, "", bool_0);
				ReadTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref waypoint2, ref nullable_31, "", bool_0);
				DisableTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref waypoint2, ref waypoint_, ref waypoint_10, ref nullable_31, ref nullable_, ref nullable_11, ref unitThrottlePreset_5, ref unitThrottlePreset_, ref unitThrottlePreset_15, ref nullable_38, ref nullable_44, ref nullable_5, ref nullable_52, ref nullable_25, ref nullable_18, "", bool_0);
				InsertTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint2, "", bool_0);
				VisitTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint2, "", bool_0);
				if (mission_0.MissionClass == Mission._MissionClass.Strike)
				{
					PrepareTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint2, "", ref bool_, ref bool_2, ref bool_3, bool_0);
				}
				else if (mission_0.MissionClass == Mission._MissionClass.Patrol || mission_0.MissionClass == Mission._MissionClass.Support)
				{
					ReflectTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint2, "", ref bool_4, ref bool_5, bool_0);
				}
				if (!Information.IsNothing(waypoint3))
				{
					unitThrottlePreset_6 = waypoint3.ThrottlePreset;
					CreateTokenizer(ref scenario_0, ref flight_0, ref waypoint3, ref nullable_32, ref unitThrottlePreset_6);
					CompareTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref waypoint3, ref waypoint_5, ", a/c #2", bool_0);
					ReadTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref waypoint3, ref nullable_32, ", a/c #2", bool_0);
					DisableTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref waypoint3, ref waypoint_5, ref waypoint_11, ref nullable_32, ref nullable_12, ref nullable_13, ref unitThrottlePreset_6, ref unitThrottlePreset_10, ref unitThrottlePreset_16, ref nullable_39, ref nullable_46, ref nullable_6, ref nullable_53, ref nullable_26, ref nullable_19, ", a/c #2", bool_0);
				}
				if (!Information.IsNothing(waypoint4))
				{
					unitThrottlePreset_7 = waypoint4.ThrottlePreset;
					CreateTokenizer(ref scenario_0, ref flight_0, ref waypoint4, ref nullable_33, ref unitThrottlePreset_7);
					CompareTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref waypoint4, ref waypoint_6, ", a/c #3", bool_0);
					ReadTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref waypoint4, ref nullable_33, ", a/c #3", bool_0);
					DisableTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref waypoint4, ref waypoint_6, ref waypoint_12, ref nullable_33, ref nullable_23, ref nullable_14, ref unitThrottlePreset_7, ref unitThrottlePreset_11, ref unitThrottlePreset_17, ref nullable_40, ref nullable_47, ref nullable_7, ref nullable_54, ref nullable_27, ref nullable_20, ", a/c #3", bool_0);
				}
				if (!Information.IsNothing(waypoint5))
				{
					unitThrottlePreset_8 = waypoint5.ThrottlePreset;
					CreateTokenizer(ref scenario_0, ref flight_0, ref waypoint5, ref nullable_35, ref unitThrottlePreset_8);
					CompareTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref waypoint5, ref waypoint_7, ", a/c #4", bool_0);
					ReadTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref waypoint5, ref nullable_35, ", a/c #4", bool_0);
					DisableTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref waypoint5, ref waypoint_7, ref waypoint_2, ref nullable_35, ref nullable_34, ref nullable_15, ref unitThrottlePreset_8, ref unitThrottlePreset_12, ref unitThrottlePreset_2, ref nullable_41, ref nullable_48, ref nullable_8, ref nullable_2, ref nullable_28, ref nullable_21, ", a/c #4", bool_0);
				}
				if (!Information.IsNothing(waypoint6))
				{
					unitThrottlePreset = waypoint6.ThrottlePreset;
					CreateTokenizer(ref scenario_0, ref flight_0, ref waypoint6, ref nullable_36, ref unitThrottlePreset);
					CompareTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref waypoint6, ref waypoint_8, ", a/c #5", bool_0);
					ReadTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref waypoint6, ref nullable_36, ", a/c #5", bool_0);
					DisableTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref waypoint6, ref waypoint_8, ref waypoint_3, ref nullable_36, ref nullable_45, ref nullable_16, ref unitThrottlePreset, ref unitThrottlePreset_13, ref unitThrottlePreset_3, ref nullable_42, ref nullable_49, ref nullable_9, ref nullable_3, ref nullable_29, ref nullable_22, ", a/c #5", bool_0);
				}
				if (!Information.IsNothing(waypoint7))
				{
					unitThrottlePreset_9 = waypoint7.ThrottlePreset;
					CreateTokenizer(ref scenario_0, ref flight_0, ref waypoint7, ref nullable_37, ref unitThrottlePreset_9);
					CompareTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref waypoint7, ref waypoint_9, ", a/c #6", bool_0);
					ReadTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref waypoint7, ref nullable_37, ", a/c #6", bool_0);
					DisableTokenizer(ref scenario_0, ref mission_0, ref flight_0, ref waypoint_0, ref waypoint7, ref waypoint_9, ref waypoint_4, ref nullable_37, ref nullable_51, ref nullable_17, ref unitThrottlePreset_9, ref unitThrottlePreset_14, ref unitThrottlePreset_4, ref nullable_43, ref nullable_50, ref nullable_10, ref nullable_4, ref nullable_30, ref nullable_24, ", a/c #6", bool_0);
				}
				if (!Information.IsNothing(waypoint2))
				{
					waypoint_10 = waypoint_;
					nullable_11 = nullable_;
					nullable_18 = nullable_52;
					nullable_25 = nullable_5;
					unitThrottlePreset_15 = unitThrottlePreset_;
					waypoint_ = waypoint2;
					nullable_ = nullable_31;
					nullable_52 = nullable_44;
					nullable_5 = nullable_38;
					unitThrottlePreset_ = unitThrottlePreset_5;
					if (Information.IsNothing(waypoint3))
					{
						waypoint_11 = waypoint_5;
						nullable_13 = nullable_12;
						nullable_19 = nullable_53;
						nullable_26 = nullable_6;
						unitThrottlePreset_16 = unitThrottlePreset_10;
						waypoint_5 = waypoint2;
						nullable_12 = nullable_31;
						nullable_53 = nullable_44;
						nullable_6 = nullable_38;
						unitThrottlePreset_10 = unitThrottlePreset_5;
					}
					else
					{
						waypoint_11 = waypoint_5;
						nullable_13 = nullable_12;
						nullable_19 = nullable_53;
						nullable_26 = nullable_6;
						unitThrottlePreset_16 = unitThrottlePreset_10;
						waypoint_5 = waypoint3;
						nullable_12 = nullable_32;
						nullable_53 = nullable_46;
						nullable_6 = nullable_39;
						unitThrottlePreset_10 = unitThrottlePreset_6;
					}
					if (Information.IsNothing(waypoint4))
					{
						waypoint_12 = waypoint_6;
						nullable_14 = nullable_23;
						nullable_20 = nullable_54;
						nullable_27 = nullable_7;
						unitThrottlePreset_17 = unitThrottlePreset_11;
						waypoint_6 = waypoint2;
						nullable_23 = nullable_31;
						nullable_54 = nullable_44;
						nullable_7 = nullable_38;
						unitThrottlePreset_11 = unitThrottlePreset_5;
					}
					else
					{
						waypoint_12 = waypoint_6;
						nullable_14 = nullable_23;
						nullable_20 = nullable_54;
						nullable_27 = nullable_7;
						unitThrottlePreset_17 = unitThrottlePreset_7;
						waypoint_6 = waypoint4;
						nullable_23 = nullable_33;
						nullable_54 = nullable_47;
						nullable_7 = nullable_40;
						unitThrottlePreset_11 = unitThrottlePreset_7;
					}
					if (Information.IsNothing(waypoint5))
					{
						waypoint_2 = waypoint_7;
						nullable_15 = nullable_34;
						nullable_21 = nullable_2;
						nullable_28 = nullable_8;
						unitThrottlePreset_2 = unitThrottlePreset_12;
						waypoint_7 = waypoint2;
						nullable_34 = nullable_31;
						nullable_2 = nullable_44;
						nullable_8 = nullable_38;
						unitThrottlePreset_12 = unitThrottlePreset_5;
					}
					else
					{
						waypoint_2 = waypoint_7;
						nullable_15 = nullable_34;
						nullable_21 = nullable_2;
						nullable_28 = nullable_8;
						unitThrottlePreset_2 = unitThrottlePreset_12;
						waypoint_7 = waypoint5;
						nullable_34 = nullable_35;
						nullable_2 = nullable_48;
						nullable_8 = nullable_41;
						unitThrottlePreset_12 = unitThrottlePreset_8;
					}
					if (Information.IsNothing(waypoint6))
					{
						waypoint_3 = waypoint_8;
						nullable_16 = nullable_45;
						nullable_22 = nullable_3;
						nullable_29 = nullable_9;
						unitThrottlePreset_3 = unitThrottlePreset_13;
						waypoint_8 = waypoint2;
						nullable_45 = nullable_31;
						nullable_3 = nullable_44;
						nullable_9 = nullable_38;
						unitThrottlePreset_13 = unitThrottlePreset_5;
					}
					else
					{
						waypoint_3 = waypoint_8;
						nullable_16 = nullable_45;
						nullable_22 = nullable_3;
						nullable_29 = nullable_9;
						unitThrottlePreset_3 = unitThrottlePreset_13;
						waypoint_8 = waypoint6;
						nullable_45 = nullable_36;
						nullable_3 = nullable_49;
						nullable_9 = nullable_42;
						unitThrottlePreset_13 = waypoint6.ThrottlePreset;
					}
					if (Information.IsNothing(waypoint7))
					{
						waypoint_4 = waypoint_9;
						nullable_17 = nullable_51;
						nullable_24 = nullable_4;
						nullable_30 = nullable_10;
						unitThrottlePreset_4 = unitThrottlePreset_14;
						waypoint_9 = waypoint2;
						nullable_51 = nullable_31;
						nullable_4 = nullable_44;
						nullable_10 = nullable_38;
						unitThrottlePreset_14 = unitThrottlePreset_5;
					}
					else
					{
						waypoint_4 = waypoint_9;
						nullable_17 = nullable_51;
						nullable_24 = nullable_4;
						nullable_30 = nullable_10;
						unitThrottlePreset_4 = unitThrottlePreset_14;
						waypoint_9 = waypoint7;
						nullable_51 = nullable_37;
						nullable_4 = nullable_50;
						nullable_10 = nullable_43;
						unitThrottlePreset_14 = unitThrottlePreset_9;
					}
				}
			}
			waypoint2 = waypoint_0[num - 1];
			if (mission_0.MissionClass == Mission._MissionClass.Strike && !flight_0.IsEscort)
			{
				if (!bool_2)
				{
					if (bool_0)
					{
						if (Information.IsNothing(flight_0.ErrorList))
						{
							flight_0.ErrorList = new List<MDSP_Error>();
						}
						flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：飞行计划没有目标或武器目标航路点。"));
					}
					else
					{
						scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：飞行计划没有目标或武器目标航路点。"));
					}
				}
				if (!bool_3)
				{
					if (bool_0)
					{
						if (Information.IsNothing(flight_0.ErrorList))
						{
							flight_0.ErrorList = new List<MDSP_Error>();
						}
						flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：飞行计划没有武器释放航路点初始点。"));
					}
					else
					{
						scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：飞行计划没有武器释放航路点初始点。"));
					}
				}
			}
			else if ((mission_0.MissionClass == Mission._MissionClass.Patrol || mission_0.MissionClass == Mission._MissionClass.Support) && !bool_5)
			{
				if (bool_0)
				{
					if (Information.IsNothing(flight_0.ErrorList))
					{
						flight_0.ErrorList = new List<MDSP_Error>();
					}
					flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：飞行计划没有巡逻航点。"));
				}
				else
				{
					scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：飞行计划没有巡逻航点。"));
				}
			}
			if (flight_0.GetStatus(scenario_0) == Mission._FlightStatus.None)
			{
				Waypoint waypoint8 = waypoint_0[0];
				if (!Information.IsNothing(waypoint8.Time_Zulu) && (waypoint8.Time_Zulu.Value - scenario_0.Time).TotalSeconds < -60.0)
				{
					if (bool_0)
					{
						if (Information.IsNothing(flight_0.ErrorList))
						{
							flight_0.ErrorList = new List<MDSP_Error>();
						}
						flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：编队设置为在过去起飞。"));
					}
					else
					{
						scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：编队设置为在过去起飞。"));
					}
				}
				if (!mission_0.IsActive && mission_0.Category == Mission.MissionCategory.Mission && !Information.IsNothing(waypoint_0[0].Time_Zulu))
				{
					DateTime? startTime = mission_0.StartTime;
					DateTime? time_Zulu2 = waypoint_0[0].Time_Zulu;
					if (((startTime.HasValue & time_Zulu2.HasValue) ? new bool?(DateTime.Compare(startTime.GetValueOrDefault(), time_Zulu2.GetValueOrDefault()) > 0) : null).GetValueOrDefault())
					{
						if (bool_0)
						{
							if (Information.IsNothing(flight_0.ErrorList))
							{
								flight_0.ErrorList = new List<MDSP_Error>();
							}
							flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：编队将在任务激活前启动。"));
						}
						else
						{
							scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：编队将在任务激活前启动。"));
						}
					}
				}
				if (!Information.IsNothing(waypoint_0[0].Time_Zulu))
				{
					DateTime value = waypoint_0[0].Time_Zulu.Value;
					float num3 = 0f;
					foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
					{
						if (activeUnits_ != null && !Information.IsNothing(activeUnits_.AssignedMissionOrPackage()) && !Information.IsNothing(activeUnits_.Navigator.GetFlight()) && flight_0 == activeUnits_.Navigator.GetFlight() && activeUnits_.IsAircraft)
						{
							Aircraft aircraft = (Aircraft)activeUnits_;
							if (aircraft.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying && aircraft.AirOps.ConditionTimer > 0f && aircraft.AirOps.ConditionTimer > num3)
							{
								num3 = aircraft.AirOps.ConditionTimer;
							}
						}
					}
					if (num3 > 0f && DateTime.Compare(scenario_0.Time.AddSeconds(num3), value) > 0)
					{
						if (bool_0)
						{
							if (Information.IsNothing(flight_0.ErrorList))
							{
								flight_0.ErrorList = new List<MDSP_Error>();
							}
							flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：该编队至少有一架飞机在编队起飞后才能准备好。"));
						}
						else
						{
							scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：该编队至少有一架飞机在编队起飞后才能准备好。"));
						}
					}
				}
				int count = flight_0.GetAUCurrentlyAssigned(mission_0, scenario_0).Count;
				if (count > 0)
				{
					if (count < flight_0.MinimumAircraftQty)
					{
						if (Information.IsNothing(waypoint_0[0].Time_Zulu))
						{
							if (bool_0)
							{
								if (Information.IsNothing(flight_0.ErrorList))
								{
									flight_0.ErrorList = new List<MDSP_Error>();
								}
								flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：该编队分配的飞机数量小于所需的最小数量。该编队不会起飞。"));
							}
							else
							{
								scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：该编队分配的飞机数量小于所需的最小数量。该编队不会起飞。"));
							}
						}
						else
						{
							DateTime t = waypoint_0[0].Time_Zulu.Value.AddMinutes(-5.0);
							if (DateTime.Compare(scenario_0.Time, t) > 0)
							{
								if (bool_0)
								{
									if (Information.IsNothing(flight_0.ErrorList))
									{
										flight_0.ErrorList = new List<MDSP_Error>();
									}
									flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：该编队分配的飞机数量小于所需的最小数量。该编队不会起飞。"));
								}
								else
								{
									scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：该编队分配的飞机数量小于所需的最小数量。该编队不会起飞。"));
								}
							}
						}
					}
					else if (flight_0.GetAUCurrentlyAssigned(mission_0, scenario_0).Count < flight_0.DesiredAircraftQty)
					{
						if (Information.IsNothing(waypoint_0[0].Time_Zulu))
						{
							if (bool_0)
							{
								if (Information.IsNothing(flight_0.ErrorList))
								{
									flight_0.ErrorList = new List<MDSP_Error>();
								}
								flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：该编队所分配的飞机数量较少。该编队将起飞，但将使用比计划更少的飞机。"));
							}
							else
							{
								scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：该编队所分配的飞机数量较少。该编队将起飞，但将使用比计划更少的飞机。"));
							}
						}
						else
						{
							DateTime t2 = waypoint_0[0].Time_Zulu.Value.AddMinutes(-5.0);
							if (DateTime.Compare(scenario_0.Time, t2) > 0)
							{
								if (bool_0)
								{
									if (Information.IsNothing(flight_0.ErrorList))
									{
										flight_0.ErrorList = new List<MDSP_Error>();
									}
									flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：该编队所分配的飞机数量较少。该编队将起飞，但将使用比计划更少的飞机。"));
								}
								else
								{
									scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：该编队所分配的飞机数量较少。该编队将起飞，但将使用比计划更少的飞机。"));
								}
							}
						}
					}
				}
				if (flight_0.IsEscort)
				{
					bool isEscort = flight_0.IsEscort;
					foreach (ActiveUnit activeUnits_2 in scenario_0.ActiveUnits_List)
					{
						if (activeUnits_2 == null || Information.IsNothing(activeUnits_2.AssignedMissionOrPackage()) || Information.IsNothing(activeUnits_2.Navigator.GetFlight()) || flight_0 != activeUnits_2.Navigator.GetFlight() || !activeUnits_2.IsAircraft)
						{
							continue;
						}
						if (activeUnits_2.AI.IsEscort && !isEscort)
						{
							string text = "";
							if (Operators.CompareString(activeUnits_2.Name, activeUnits_2.UnitClass, TextCompare: false) != 0)
							{
								text = " (" + activeUnits_2.UnitClass + ")";
							}
							if (bool_0)
							{
								if (Information.IsNothing(flight_0.ErrorList))
								{
									flight_0.ErrorList = new List<MDSP_Error>();
								}
								flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：飞行任务不是'护航'，而是飞机" + activeUnits_2.Name + text + " is configured as Escort in the Mission Editor 'Units assigned to mission/package' list. Change the flight task type or change the escort status of the aircraft."));
							}
							else
							{
								scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：飞行任务不是'护航'，而是飞机" + activeUnits_2.Name + text + " is configured as Escort in the Mission Editor 'Units assigned to mission/package' list. Change the flight task type or change the escort status of the aircraft."));
							}
						}
						else
						{
							if (!(!activeUnits_2.AI.IsEscort && isEscort))
							{
								continue;
							}
							string text2 = "";
							if (Operators.CompareString(activeUnits_2.Name, activeUnits_2.UnitClass, TextCompare: false) != 0)
							{
								text2 = " (" + activeUnits_2.UnitClass + ")";
							}
							if (bool_0)
							{
								if (Information.IsNothing(flight_0.ErrorList))
								{
									flight_0.ErrorList = new List<MDSP_Error>();
								}
								flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：飞行任务是'护航'，但飞机" + activeUnits_2.Name + text2 + " is NOT configured as Escort in the Mission Editor 'Units assigned to mission/package' list. Change the flight task type or change the escort status of the aircraft."));
							}
							else
							{
								scenario_0.MissionPlannerErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "：飞行任务是'护航'，但飞机" + activeUnits_2.Name + text2 + " is NOT configured as Escort in the Mission Editor 'Units assigned to mission/package' list. Change the flight task type or change the escort status of the aircraft."));
							}
						}
					}
				}
			}
			if (!flight_0.IsEscort && waypoint_0.Count() == 0)
			{
				flight_0.ErrorList.Add(new MDSP_Error(mission_0.Name, flight_0.Callsign, "错误！预先计划的编队必须有飞行计划！"));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200626", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal static float TestTokenizer(Mission._AttackMethod _AttackMethod_0)
	{
		switch (_AttackMethod_0)
		{
		default:
			return 0f;
		case Mission._AttackMethod.MultiAxisSimultaneousToT:
			return 0f;
		case Mission._AttackMethod.MultiAxisStackedToT_Echelon_20Sec:
		case Mission._AttackMethod.MultiAxisStackedToT_Split_20Sec:
			return 20f;
		case Mission._AttackMethod.MultiAxisStackedToT_Echelon_30Sec:
		case Mission._AttackMethod.MultiAxisStackedToT_Split_30Sec:
			return 30f;
		case Mission._AttackMethod.MultiAxisStackedToT_Echelon_40Sec:
		case Mission._AttackMethod.MultiAxisStackedToT_Split_40Sec:
			return 40f;
		case Mission._AttackMethod.SingleAxisStackedToT_20Sec:
			return 20f;
		case Mission._AttackMethod.SingleAxisStackedToT_30Sec:
			return 30f;
		case Mission._AttackMethod.SingleAxisStackedToT_40Sec:
			return 40f;
		case Mission._AttackMethod.BananaSplit:
			return 40f;
		}
	}

	public static void CreateWeaponRoute(ref Scenario scenario_0, ref ActiveUnit activeUnit_0, ref Mission.TargeteeringEntry targeteeringEntry_0, ref Mission.WeaponeeringEntry weaponeeringEntry_0, ref Waypoint waypoint_0, ref Waypoint waypoint_1, ref Waypoint[] waypoint_2, ref Weapon weapon_0, ref int int_0, ref Contact contact_0, double double_0, double double_1, float float_0, double double_2, double double_3, float float_1, ref bool bool_0, bool bool_1, ref Mission.Flight flight_0, string string_0)
	{
		try
		{
			if (weapon_0.Waypoints == 0)
			{
				return;
			}
			waypoint_2 = new Waypoint[0];
			Waypoint theAC = new Waypoint(double_1, double_0, 0f, Waypoint.WaypointType.Launch, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.WeaponRoute);
			ArrayExtensions.Add(ref waypoint_2, theAC);
			float num = Math2.VerifyClass(double_0, double_1, double_2, double_3);
			float float_2 = Math2.PublishClass(double_0, double_1, double_2, double_3);
			Waypoint.WaypointType waypointType_ = Waypoint.WaypointType.TerminalPoint;
			double double_4 = 0.0;
			double double_5 = 0.0;
			if (targeteeringEntry_0.Target_Type == 0)
			{
				if (weapon_0.Guidance == Weapon.WeaponGuidanceType.Inertial)
				{
					double_4 = double_2;
					double_5 = double_3;
				}
				else if (contact_0.Type == Contact_Base.ContactType.Surface)
				{
					double[] array = new double[weapon_0.Sensors_ReadOnly().Length + 1];
					double num2 = 0.0;
					int num3 = weapon_0.Sensors_ReadOnly().Length - 1;
					for (int i = 0; i <= num3; i++)
					{
						if (weapon_0.Sensors_ReadOnly()[i].Type != Sensor.Sensor_Type.ESM || weapon_0.ValidTargets.Radar)
						{
							array[i] = weapon_0.Sensors_ReadOnly()[i].maxRange;
						}
					}
					num2 = array.Max();
					if (weapon_0.Sensors_ReadOnly().Length == 0)
					{
						Warhead[] warheads = weapon_0.Warheads;
						Warhead[] array2 = warheads;
						foreach (Warhead warhead in array2)
						{
							if (warhead.Type != Warhead.WarheadType.Weapon)
							{
								continue;
							}
							Weapon carriedWeapon = warhead.GetCarriedWeapon(weapon_0.ParentScen);
							int num4 = carriedWeapon.Sensors_ReadOnly().Length - 1;
							for (int j = 0; j <= num4; j++)
							{
								if (carriedWeapon.Sensors_ReadOnly()[j].Type != Sensor.Sensor_Type.ESM || weapon_0.ValidTargets.Radar)
								{
									array[j] = carriedWeapon.Sensors_ReadOnly()[j].maxRange;
								}
							}
						}
						num2 = array.Max();
					}
					double num5 = (((double)num <= num2) ? ((double)num * 0.5) : ((double)num - num2 * 0.8));
					Geodesic_EdWilliams.CalcPoint_Williams(double_3, double_2, ref double_5, ref double_4, (float)num5, float_2);
				}
				else
				{
					double_4 = double_2;
					double_5 = double_3;
				}
			}
			else if (targeteeringEntry_0.Target_Type == 1)
			{
				double_4 = double_2;
				double_5 = double_3;
			}
			else if (targeteeringEntry_0.Target_Type == 2)
			{
				double_4 = double_2;
				double_5 = double_3;
			}
			else if (targeteeringEntry_0.Target_Type == 3)
			{
				double_4 = double_2;
				double_5 = double_3;
			}
			if (weapon_0.Waypoints > 1)
			{
				float num6 = Math2.VerifyClass(double_0, double_1, double_4, double_5);
				float float_3 = ((num6 < 30f) ? (num6 / 2f) : 15f);
				double double_6 = 0.0;
				double double_7 = 0.0;
				Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_6, ref double_7, float_3, float_2);
				theAC = new Waypoint(double_6, double_7, 0f, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.WeaponRoute);
				ArrayExtensions.Add(ref waypoint_2, theAC);
			}
			theAC = new Waypoint(double_5, double_4, 0f, waypointType_, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.WeaponRoute);
			ArrayExtensions.Add(ref waypoint_2, theAC);
			SetRealisticWeaponRouteSpeedAndAltitudes(ref weapon_0, ref waypoint_2, ref waypoint_1);
			StopTokenizer(ref scenario_0, ref weapon_0, ref waypoint_0, ref waypoint_1, ref contact_0, ref waypoint_2, bool_0, bool_1, float_1, ref activeUnit_0, double_0, double_1, ref flight_0, string_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void SetRealisticWeaponRouteSpeedAndAltitudes(ref Weapon weapon_0, ref Waypoint[] waypoint_0, ref Waypoint waypoint_1)
	{
		try
		{
			bool flag;
			float num;
			if (weapon_0.Flags.LevelCruiseFlight)
			{
				if (weapon_0.CruiseAltitude_AGL <= 0f)
				{
					flag = false;
					num = weapon_0.CruiseAltitude_ASL;
				}
				else
				{
					flag = true;
					num = weapon_0.CruiseAltitude_AGL;
				}
			}
			else
			{
				num = 0f;
				flag = false;
				_ = waypoint_0[waypoint_0.Count() - 1].Altitude;
			}
			int num2 = waypoint_0.Count() - 1;
			for (int i = 0; i <= num2; i++)
			{
				Waypoint waypoint = waypoint_0[i];
				float num3 = Terrain.GetElevation(waypoint.Latitude, waypoint.Longitude, bool_0: false, weapon_0.ParentScen);
				if (weapon_0.Flags.LevelCruiseFlight)
				{
					if (flag)
					{
						waypoint.DesiredAltitude_TerrainFollowing = num3 + num;
						waypoint.DesiredSpeed = weapon_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, ActiveUnit.Throttle.Cruise, bool_0: false);
					}
					else
					{
						waypoint.DesiredAltitude = num3 + num;
						waypoint.DesiredSpeed = weapon_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, ActiveUnit.Throttle.Cruise, bool_0: false);
					}
					waypoint.DesiredAltitudeOverride = true;
					waypoint.DesiredSpeedOverride = waypoint.DesiredSpeed;
					continue;
				}
				waypoint.DesiredAltitude = waypoint_1.DesiredAltitude;
				waypoint.DesiredAltitude_TerrainFollowing = waypoint_1.DesiredAltitude_TerrainFollowing;
				if (Information.IsNothing(waypoint.DesiredAltitude))
				{
					waypoint.DesiredAltitude = num3 + num;
				}
				waypoint.DesiredSpeed = weapon_0.Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, ActiveUnit.Throttle.Cruise, bool_0: false);
				waypoint.DesiredAltitudeOverride = true;
				waypoint.DesiredSpeedOverride = waypoint.DesiredSpeed;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void CalculateFuelQtyAndTimesForWeaponRoutes(ref Scenario scenario_0, ref Side side_0, bool bool_0, bool bool_1, ref Mission.Flight flight_0, string string_0, ref ActiveUnit activeUnit_0, Mission.Flight.FlightElement flightElement_0)
	{
		try
		{
			if (Information.IsNothing(flight_0) || Information.IsNothing(flight_0.FlightPlan))
			{
				return;
			}
			int num = flight_0.FlightPlan.Count() - 1;
			double num2 = 0.0;
			double num3 = 0.0;
			Weapon weapon_ = null;
			for (int i = 1; i <= num; i++)
			{
				Waypoint waypoint = flight_0.FlightPlan[i];
				Waypoint waypoint2 = flight_0.FlightPlan[i - 1];
				if ((waypoint.Type != Waypoint.WaypointType.Target && waypoint.Type != Waypoint.WaypointType.WeaponTarget) || waypoint.TargeteeringMethod != Mission._TargeteeringMethod.Individual)
				{
					continue;
				}
				waypoint.Leg_Time_Weapon = 0f;
				List<Mission.WeaponeeringEntry> list;
				List<Mission.TargeteeringEntry> list2;
				Waypoint waypoint_;
				Waypoint waypoint_2;
				if (flightElement_0 == Mission.Flight.FlightElement.LeadElement)
				{
					list = waypoint.WeaponeeringList;
					list2 = waypoint.TargeteeringList;
					waypoint_ = waypoint;
					waypoint_2 = waypoint2;
				}
				else if (flightElement_0 == Mission.Flight.FlightElement.LeadElementWingman && !Information.IsNothing(waypoint.WeaponeeringList_LeadElementWingman))
				{
					list = waypoint.WeaponeeringList_LeadElementWingman;
					list2 = waypoint.TargeteeringList_LeadElementWingman;
					waypoint_ = (Information.IsNothing(waypoint.Waypoint_LeadElementWingman) ? waypoint : waypoint.Waypoint_LeadElementWingman);
					waypoint_2 = (Information.IsNothing(waypoint2.Waypoint_LeadElementWingman) ? waypoint2 : waypoint2.Waypoint_LeadElementWingman);
				}
				else if (flightElement_0 == Mission.Flight.FlightElement.SecondElement && !Information.IsNothing(waypoint.WeaponeeringList_SecondElement))
				{
					list = waypoint.WeaponeeringList_SecondElement;
					list2 = waypoint.TargeteeringList_SecondElement;
					waypoint_ = (Information.IsNothing(waypoint.Waypoint_SecondElement) ? waypoint : waypoint.Waypoint_SecondElement);
					waypoint_2 = (Information.IsNothing(waypoint2.Waypoint_SecondElement) ? waypoint2 : waypoint2.Waypoint_SecondElement);
				}
				else if (flightElement_0 == Mission.Flight.FlightElement.SecondElementWingman && !Information.IsNothing(waypoint.WeaponeeringList_SecondElementWingman))
				{
					list = waypoint.WeaponeeringList_SecondElementWingman;
					list2 = waypoint.TargeteeringList_SecondElementWingman;
					waypoint_ = (Information.IsNothing(waypoint.Waypoint_SecondElementWingman) ? waypoint : waypoint.Waypoint_SecondElementWingman);
					waypoint_2 = (Information.IsNothing(waypoint2.Waypoint_SecondElementWingman) ? waypoint2 : waypoint2.Waypoint_SecondElementWingman);
				}
				else if (flightElement_0 == Mission.Flight.FlightElement.ThirdElement && !Information.IsNothing(waypoint.WeaponeeringList_ThirdElement))
				{
					list = waypoint.WeaponeeringList_ThirdElement;
					list2 = waypoint.TargeteeringList_ThirdElement;
					waypoint_ = (Information.IsNothing(waypoint.Waypoint_ThirdElement) ? waypoint : waypoint.Waypoint_ThirdElement);
					waypoint_2 = (Information.IsNothing(waypoint2.Waypoint_ThirdElement) ? waypoint2 : waypoint2.Waypoint_ThirdElement);
				}
				else if (flightElement_0 == Mission.Flight.FlightElement.ThirdElementWingman && !Information.IsNothing(waypoint.WeaponeeringList_ThirdElementWingman))
				{
					list = waypoint.WeaponeeringList_ThirdElementWingman;
					list2 = waypoint.TargeteeringList_ThirdElementWingman;
					waypoint_ = (Information.IsNothing(waypoint.Waypoint_ThirdElementWingman) ? waypoint : waypoint.Waypoint_ThirdElementWingman);
					waypoint_2 = (Information.IsNothing(waypoint2.Waypoint_ThirdElementWingman) ? waypoint2 : waypoint2.Waypoint_ThirdElementWingman);
				}
				else
				{
					list = waypoint.WeaponeeringList;
					list2 = waypoint.TargeteeringList;
					waypoint_ = waypoint;
					waypoint_2 = waypoint2;
				}
				if (Information.IsNothing(list) || Information.IsNothing(list2) || list.Count == 0 || list2.Count == 0)
				{
					continue;
				}
				if (!Information.IsNothing(waypoint_) && waypoint_.FlightplanPointsList.Count > 0)
				{
					int count = waypoint_.FlightplanPointsList.Count;
					if (waypoint_.Type == Waypoint.WaypointType.Target)
					{
						num2 = waypoint_.FlightplanPointsList[count - 1].StartLatitude;
						num3 = waypoint_.FlightplanPointsList[count - 1].StartLongitude;
					}
					else if (waypoint_.Type == Waypoint.WaypointType.WeaponTarget)
					{
						num2 = waypoint_.FlightplanPointsList[count - 1].EndLatitude;
						num3 = waypoint_.FlightplanPointsList[count - 1].EndLongitude;
					}
				}
				int num4 = 0;
				bool flag = false;
				bool flag2;
				if (waypoint.FlightFormation != Waypoint.Formation.Split && flightElement_0 != Mission.Flight.FlightElement.LeadElement)
				{
					flag2 = false;
				}
				else
				{
					flag2 = true;
					foreach (Mission.WeaponeeringEntry item in list)
					{
						if (flag)
						{
							item.IsRouteReference = false;
						}
						else if (item.IsRouteReference)
						{
							flag = true;
						}
					}
				}
				if (flag2 && !flag)
				{
					list[0].IsRouteReference = true;
				}
				foreach (Mission.WeaponeeringEntry item2 in list)
				{
					if (Information.IsNothing(item2.Route) || item2.Route.Count() == 0)
					{
						continue;
					}
					item2.Route[0].Latitude = num2;
					item2.Route[0].Longitude = num3;
					if (num4 != item2.int_0)
					{
						weapon_ = Weapon.GetNewWeapon(ref scenario_0, item2.int_0, bool_0: false);
						num4 = item2.int_0;
					}
					if (weapon_ == null)
					{
						Interaction.MsgBox("Could not find weapon for Weaponeering entry!");
						continue;
					}
					Mission.TargeteeringEntry targeteeringEntry = null;
					foreach (Mission.TargeteeringEntry item3 in list2)
					{
						if (Operators.CompareString(item3.ObjectID, item2.TargeteeringEntryObjectID, TextCompare: false) == 0)
						{
							targeteeringEntry = item3;
							break;
						}
					}
					if (Information.IsNothing(targeteeringEntry))
					{
						Interaction.MsgBox("Could not find matching Targeteering ObjectID");
					}
					Contact contact_ = null;
					if (side_0.Contacts.ContainsKey(targeteeringEntry.Target_ActualUnitObjectID))
					{
						side_0.Contacts.TryGetValue(targeteeringEntry.Target_ActualUnitObjectID, ref contact_);
					}
					double latitude = contact_.GetLatitude();
					double longitude = contact_.GetLongitude();
					float float_ = (contact_.AltitudeIsKnown ? contact_.GetCurrentAltitude() : ((float)Terrain.GetElevation(latitude, longitude, bool_0: false, contact_.ActualUnit.ParentScen)));
					int num5 = item2.Route.Count();
					item2.Route[0].Latitude = num2;
					item2.Route[0].Longitude = num3;
					item2.Route[num5 - 1].Latitude = latitude;
					item2.Route[num5 - 1].Longitude = longitude;
					StopTokenizer(ref scenario_0, ref weapon_, ref waypoint_, ref waypoint_2, ref contact_, ref item2.Route, bool_0, bool_1, float_, ref activeUnit_0, num2, num3, ref flight_0, string_0);
					if (item2.IsRouteReference)
					{
						waypoint_.Leg_Time_Weapon = item2.Route[item2.Route.Count() - 1].Leg_TotalTime;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal static bool StopTokenizer(ref Scenario scenario_0, ref Weapon weapon_0, ref Waypoint waypoint_0, ref Waypoint waypoint_1, ref Contact contact_0, ref Waypoint[] waypoint_2, bool bool_0, bool bool_1, float float_0, ref ActiveUnit activeUnit_0, double double_0, double double_1, ref Mission.Flight flight_0, string string_0)
	{
		try
		{
			if (waypoint_2.Count() == 0)
			{
				return false;
			}
			if (Information.IsNothing(waypoint_2))
			{
				return false;
			}
			if (waypoint_2.Count() == 0)
			{
				return false;
			}
			DetermineDistanceFlown_WeaponRoute(waypoint_2, 30, ref flight_0, ref waypoint_0, string_0);
			AddTokenizer(ref scenario_0, ref activeUnit_0, ref weapon_0, ref waypoint_2, ref waypoint_0, ref waypoint_1, ref contact_0, ref flight_0, ref string_0);
			int num = waypoint_2.Count() - 1;
			for (int i = 0; i <= num; i++)
			{
				if (!Information.IsNothing(waypoint_2[i]) && i != 0)
				{
					Waypoint waypoint = waypoint_2[i];
					new List<Waypoint.FlightPlanSegment>();
					if (i == 0)
					{
						_ = waypoint.DesiredSpeed.Value;
					}
				}
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public static void DetermineDistanceFlown_WeaponRoute(Waypoint[] waypoint_0, int int_0, ref Mission.Flight flight_0, ref Waypoint waypoint_1, string string_0)
	{
		float float_ = 0f;
		float num = 0f;
		float float_2 = 0f;
		if (Information.IsNothing(waypoint_0) || waypoint_0.Count() == 0)
		{
			return;
		}
		float num2 = waypoint_0[0].Leg_TotalDistance;
		try
		{
			int num3 = waypoint_0.Count() - 1;
			Misc.TurnDirection turnDirection = (Misc.TurnDirection)0;
			for (int i = 0; i <= num3; i++)
			{
				if (Information.IsNothing(waypoint_0[i]))
				{
					continue;
				}
				List<Waypoint.FlightPlanSegment> list_ = new List<Waypoint.FlightPlanSegment>();
				if (i == 0)
				{
					float_ = waypoint_0[i].DesiredSpeed.Value;
				}
				else if (!(float_ <= 0f) && num > 0f)
				{
					Waypoint waypoint_2 = waypoint_0[i];
					Waypoint waypoint_3 = waypoint_0[i - 1];
					if (!Information.IsNothing(waypoint_2.Time_Zulu) && waypoint_2.InitReponse())
					{
						num = float_;
						float num4 = Math2.PublishClass(waypoint_3.Latitude, waypoint_3.Longitude, waypoint_2.Latitude, waypoint_2.Longitude);
						float_2 = num4;
						num = float_;
						if (turnDirection == (Misc.TurnDirection)0)
						{
							turnDirection = Misc.CountValue(float_2, num4);
							switch (turnDirection)
							{
							case Misc.TurnDirection.TurnRight:
								int_0 = 30;
								break;
							case Misc.TurnDirection.TurnLeft:
								int_0 = -30;
								break;
							}
						}
						float float_3 = num;
						float float_4 = int_0;
						Misc.TurnDirection turnDirection_ = turnDirection;
						float float_5 = num4;
						bool bool_ = false;
						CreateWeaponRouteCurve(ref float_2, ref list_, ref waypoint_2, ref waypoint_3, ref waypoint_1, ref float_, float_3, ref flight_0, float_4, turnDirection_, float_5, ref bool_, bool_1: false, string_0, waypoint_0);
					}
					else
					{
						float num5 = Math2.PublishClass(waypoint_3.Latitude, waypoint_3.Longitude, waypoint_2.Latitude, waypoint_2.Longitude);
						turnDirection = Misc.CountValue(float_2, num5);
						if (i == 1)
						{
							float_2 = num5;
						}
						switch (turnDirection)
						{
						case Misc.TurnDirection.TurnRight:
							int_0 = 30;
							break;
						case Misc.TurnDirection.TurnLeft:
							int_0 = -30;
							break;
						}
						float float_6 = num;
						float float_7 = int_0;
						Misc.TurnDirection turnDirection_2 = turnDirection;
						float float_8 = num5;
						bool bool_2 = false;
						CreateWeaponRouteCurve(ref float_2, ref list_, ref waypoint_2, ref waypoint_3, ref waypoint_1, ref float_, float_6, ref flight_0, float_7, turnDirection_2, float_8, ref bool_2, bool_1: false, string_0, waypoint_0);
						if (waypoint_3.InitReponse())
						{
							waypoint_0[i].Leg_Distance_Straight = Math2.VerifyClass(waypoint_0[i].Latitude, waypoint_0[i].Longitude, waypoint_0[i - 2].Latitude, waypoint_0[i - 2].Longitude);
							waypoint_0[i].Leg_Distance_Turn = 0f;
							waypoint_2.Leg_Time_Turn = 0f;
							waypoint_2.Leg_Time_Straight = waypoint_2.Leg_Distance_Straight / float_ * 3600f;
						}
					}
				}
				else
				{
					Waypoint waypoint = waypoint_0[i];
					Waypoint waypoint2;
					double double_ = (waypoint2 = waypoint_0[i - 1]).Latitude;
					Waypoint.FlightPlanSegment flightPlanSegment = new Waypoint.FlightPlanSegment(ref double_, waypoint_0[i - 1].Longitude, waypoint.Latitude, waypoint.Longitude);
					waypoint2.Latitude = double_;
					Waypoint.FlightPlanSegment item = flightPlanSegment;
					list_.Add(item);
					waypoint.Leg_Distance_Straight += Math2.VerifyClass(waypoint_0[i - 1].Latitude, waypoint_0[i - 1].Longitude, waypoint.Latitude, waypoint.Longitude);
					waypoint.Leg_Speed_Straight = float_;
				}
				num = float_;
				if (!Information.IsNothing(waypoint_0[i].DesiredSpeed))
				{
					float? desiredSpeed = waypoint_0[i].DesiredSpeed;
					if ((desiredSpeed.HasValue ? new bool?(desiredSpeed.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						waypoint_0[i].DesiredSpeed = null;
					}
					else
					{
						float_ = waypoint_0[i].DesiredSpeed.Value;
					}
				}
				num2 += waypoint_0[i].Leg_Distance_Straight + waypoint_0[i].Leg_Distance_Turn;
				if (i > 0)
				{
					waypoint_0[i].Leg_TotalDistance = num2;
					waypoint_0[i].ActualSpeed = float_;
				}
				if (i > 0)
				{
					waypoint_0[i].FlightplanPointsList = list_;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void CreateWeaponRouteCurve(ref float float_0, ref List<Waypoint.FlightPlanSegment> list_0, ref Waypoint waypoint_0, ref Waypoint waypoint_1, ref Waypoint waypoint_2, ref float float_1, float float_2, ref Mission.Flight flight_0, float float_3, Misc.TurnDirection turnDirection_0, float float_4, ref bool bool_0, bool bool_1, string string_0, Waypoint[] waypoint_3)
	{
		try
		{
			if (Information.IsNothing(waypoint_0) || Information.IsNothing(waypoint_1))
			{
				return;
			}
			float num = float_0;
			float num12 = Math.Abs(float_3);
			if (waypoint_1.Type == Waypoint.WaypointType.WeaponTarget && !Information.IsNothing(waypoint_1.FlightplanPointsList) && waypoint_1.FlightplanPointsList.Count > 0)
			{
				double endLatitude = waypoint_1.FlightplanPointsList[waypoint_1.FlightplanPointsList.Count - 1].EndLatitude;
				double endLongitude = waypoint_1.FlightplanPointsList[waypoint_1.FlightplanPointsList.Count - 1].EndLongitude;
				waypoint_1 = new Waypoint(endLongitude, endLatitude, 0f, Waypoint.WaypointType.WeaponTarget, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan);
				float_4 = Math2.PublishClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_0.Latitude, waypoint_0.Longitude);
			}
			float num19 = Math.Abs(MathFunctions.DeleteRequest(float_0, float_4));
			float num20 = Math.Abs(float_3) / num12;
			float num21 = float_2 / 3600f * num20;
			float num22 = (float)((double)float_2 / ((double)num12 * 3.14159265358979 * 20.0));
			float num23 = Math2.VerifyClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_0.Latitude, waypoint_0.Longitude);
			float num24 = (float)((double)(2f * num22) * Math.Sin(0.5 * MathFunctions.DestroyRequest(num19))) + num21 * 2f;
			bool_0 = false;
			if (num23 < num24)
			{
				bool_0 = true;
				if (bool_1)
				{
					waypoint_0.Leg_Time_Turn = 0f;
					waypoint_0.Leg_Time_Straight = 0f;
					return;
				}
			}
			if (bool_0)
			{
				if (Information.IsNothing(waypoint_3))
				{
					DestroyTokenizer(ref flight_0, ref waypoint_2, "错误！任务" + flight_0.ParentMissionOrPackageName + "，飞行编队" + flight_0.Callsign + string_0 + ", Target Waypoint " + waypoint_2.Description + "：两个航点太近了。");
				}
				else
				{
					if (Information.IsNothing(waypoint_2.Description) || Information.IsNothing(waypoint_2.Description))
					{
						Mission.Flight obj = flight_0;
						Waypoint[] waypoint_4 = obj.FlightPlan;
						MoveTokenizer(ref waypoint_4);
						obj.FlightPlan = waypoint_4;
					}
					DestroyTokenizer(ref flight_0, ref waypoint_2, "错误！任务" + flight_0.ParentMissionOrPackageName + "，飞行编队" + flight_0.Callsign + string_0 + ", Target Waypoint " + waypoint_2.Description + "： 航点" + waypoint_1.Description + "离航点太近了" + waypoint_0.Description + ".");
				}
			}
			float num25 = 0f;
			if (!bool_0 && !Information.IsNothing(waypoint_0.Time_Zulu) && waypoint_0.InitReponse() && waypoint_1.ChangeReponse())
			{
				float float_5 = Math2.VerifyClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_0.Latitude, waypoint_0.Longitude);
				Waypoint waypoint;
				double double_ = (waypoint = waypoint_1).Latitude;
				Waypoint.FlightPlanSegment flightPlanSegment = new Waypoint.FlightPlanSegment(ref double_, waypoint_1.Longitude, waypoint_0.Latitude, waypoint_0.Longitude);
				waypoint.Latitude = double_;
				Waypoint.FlightPlanSegment item = flightPlanSegment;
				list_0.Add(item);
				float num2 = Math.Abs(float_3);
				float num3 = Math2.UpdateClass(num + num2);
				double double_9 = waypoint_0.Latitude;
				double num4 = waypoint_0.Longitude;
				int i = 0;
				int num5 = (int)Math.Round(180f / num2) - 1;
				float num6 = num3;
				Math2.UpdateClass(float_4 + 180f);
				double double_10 = 0.0;
				double double_11 = 0.0;
				for (; i <= num5; i++)
				{
					try
					{
						Geodesic_EdWilliams.CalcPoint_Williams(num4, double_9, ref double_10, ref double_11, num21, num6);
						item = new Waypoint.FlightPlanSegment(ref double_9, num4, double_11, double_10);
						list_0.Add(item);
						num25 += num20;
						double_9 = double_11;
						num4 = double_10;
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					num6 = Math2.UpdateClass(num6 + num2);
				}
				double double_12 = 0.0;
				double double_13 = 0.0;
				Geodesic_EdWilliams.CalcPoint_Williams(num4, double_9, ref double_12, ref double_13, float_5, Math2.UpdateClass(float_4 + 180f));
				item = new Waypoint.FlightPlanSegment(ref double_9, num4, double_13, double_12);
				list_0.Add(item);
				double_9 = double_13;
				num4 = double_12;
				waypoint_0.RaceTrackHelperPoint = new GeoPoint(double_12, double_13);
				Math2.UpdateClass(float_4 + 180f + num2);
				for (i = 0; i <= num5 - 1; i++)
				{
					try
					{
						Geodesic_EdWilliams.CalcPoint_Williams(num4, double_9, ref double_10, ref double_11, num21, num6);
						item = new Waypoint.FlightPlanSegment(ref double_9, num4, double_11, double_10);
						list_0.Add(item);
						num25 += num20;
						double_9 = double_11;
						num4 = double_10;
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						ProjectData.ClearProjectError();
					}
					num6 = Math2.UpdateClass(num6 + num2);
				}
				item = new Waypoint.FlightPlanSegment(ref double_9, num4, waypoint_1.Latitude, waypoint_1.Longitude);
				list_0.Add(item);
				waypoint_0.Leg_Distance_Straight = 0f;
				waypoint_0.Leg_Speed_Turn = 0f;
				waypoint_0.Leg_Distance_Turn = 0f;
				waypoint_0.Leg_Speed_Straight = float_1;
				float_0 = 0f;
				waypoint_0.Leg_Time_Turn = 0f;
				waypoint_0.Leg_Time_Straight = 0f;
			}
			else if (!bool_0 && num19 > Math.Abs(float_3 * 2f))
			{
				float num7 = Math2.UpdateClass(num + float_3);
				double double_14 = waypoint_1.Latitude;
				double num8 = waypoint_1.Longitude;
				int num9 = 0;
				int num10 = (int)Math.Round(360f / Math.Abs(float_3));
				float num11 = num7;
				float num13 = Math2.UpdateClass(float_4);
				float num14 = num13;
				double double_15 = 0.0;
				double double_16 = 0.0;
				do
				{
					switch (turnDirection_0)
					{
					case Misc.TurnDirection.TurnRight:
						if (num7 <= num13)
						{
							if (num11 >= num14 && num11 > num7)
							{
								num7 = num11;
								num13 = num14;
							}
						}
						else if (num11 >= num14 && num11 < num7)
						{
							num7 = num11;
							num13 = num14;
						}
						break;
					case Misc.TurnDirection.TurnLeft:
						if (num7 <= num13)
						{
							if (num11 <= num14 && num11 > num7)
							{
								num7 = num11;
								num13 = num14;
							}
						}
						else if (num11 <= num14 && num11 < num7)
						{
							num7 = num11;
							num13 = num14;
						}
						break;
					}
					num9++;
					if ((int)Math.Round(num11) == (int)Math.Round(num14))
					{
						try
						{
							Geodesic_EdWilliams.CalcPoint_Williams(num8, double_14, ref double_15, ref double_16, num21, num11);
							Waypoint.FlightPlanSegment item4 = new Waypoint.FlightPlanSegment(ref double_14, num8, double_16, double_15);
							list_0.Add(item4);
							num25 += num20;
							double_14 = double_16;
							num8 = double_15;
						}
						catch (Exception projectError3)
						{
							ProjectData.SetProjectError(projectError3);
							ProjectData.ClearProjectError();
							goto IL_07de;
						}
						break;
					}
					try
					{
						Geodesic_EdWilliams.CalcPoint_Williams(num8, double_14, ref double_15, ref double_16, num21, num11);
						Waypoint.FlightPlanSegment item5 = new Waypoint.FlightPlanSegment(ref double_14, num8, double_16, double_15);
						list_0.Add(item5);
						num25 += num20;
						double_14 = double_16;
						num8 = double_15;
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						ProjectData.ClearProjectError();
					}
					goto IL_07de;
					IL_07de:
					num14 = Math2.PublishClass(double_14, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					num11 = Math2.UpdateClass(num11 + float_3);
					if (num9 >= num10)
					{
						bool_0 = true;
						waypoint_0.Leg_Time_Turn = 0f;
						waypoint_0.Leg_Time_Straight = 0f;
						return;
					}
				}
				while (!(Math.Abs(MathFunctions.DeleteRequest(num11, num14)) <= 30f));
				if (waypoint_0.Type == Waypoint.WaypointType.WeaponTarget)
				{
					Waypoint waypoint2;
					double double_2 = (waypoint2 = waypoint_0).Latitude;
					Waypoint.FlightPlanSegment flightPlanSegment2 = new Waypoint.FlightPlanSegment(ref double_2, waypoint_0.Longitude, double_14, num8);
					waypoint2.Latitude = double_2;
					Waypoint.FlightPlanSegment item6 = flightPlanSegment2;
					list_0.Add(item6);
					float float_6 = Math2.PublishClass(double_14, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					float num15 = Math2.VerifyClass(double_14, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					float num16 = Math.Min(5f, num15 - 1f);
					double double_3 = 0.0;
					double double_4 = 0.0;
					if (num16 <= 0f)
					{
						waypoint_0.Leg_Distance_Straight = 0f;
						double_3 = num8;
						double_4 = double_14;
					}
					else
					{
						waypoint_0.Leg_Distance_Straight = num16;
						Geodesic_EdWilliams.CalcPoint_Williams(num8, double_14, ref double_3, ref double_4, num16, float_6);
					}
					item6 = new Waypoint.FlightPlanSegment(ref double_14, num8, double_4, double_3);
					list_0.Add(item6);
					waypoint_0.Leg_Distance_Turn = float_2 * num25 / 3600f;
					waypoint_0.Leg_Speed_Straight = float_1;
					float_0 = Math2.UpdateClass(Math2.PublishClass(waypoint_0.Latitude, waypoint_0.Longitude, list_0[list_0.Count - 1].StartLatitude, list_0[list_0.Count - 1].StartLongitude) + 180f);
					waypoint_0.Leg_Time_Turn = num25;
					waypoint_0.Leg_Time_Straight = waypoint_0.Leg_Distance_Straight / float_1 * 3600f;
				}
				else if (waypoint_0.EnableReponse() && waypoint_1.SearchReponse())
				{
					Waypoint.FlightPlanSegment item7 = new Waypoint.FlightPlanSegment(ref double_14, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					list_0.Add(item7);
					waypoint_0.Leg_Distance_Straight = Math2.VerifyClass(double_14, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					waypoint_0.Leg_Speed_Turn = float_2;
					waypoint_0.Leg_Distance_Turn = float_2 * num25 / 3600f;
					waypoint_0.Leg_Speed_Straight = float_1;
					float_0 = Math2.UpdateClass(Math2.PublishClass(waypoint_0.Latitude, waypoint_0.Longitude, list_0[list_0.Count - 1].StartLatitude, list_0[list_0.Count - 1].StartLongitude) + 180f);
					waypoint_0.Leg_Time_Turn = num25;
					waypoint_0.Leg_Time_Straight = waypoint_0.Leg_Distance_Straight / float_1 * 3600f;
				}
				else if (waypoint_0.SearchReponse() && waypoint_1.EnableReponse())
				{
					Waypoint.FlightPlanSegment item8 = new Waypoint.FlightPlanSegment(ref double_14, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					list_0.Add(item8);
					waypoint_1.Leg_Distance_Straight += Math2.VerifyClass(double_14, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					waypoint_1.Leg_Time_Straight = waypoint_0.Leg_Distance_Straight / waypoint_1.Leg_Speed_Straight * 3600f;
					waypoint_1.Leg_Time_Turn += num25;
					waypoint_1.Leg_Distance_Turn = waypoint_1.Leg_Speed_Turn * waypoint_1.Leg_Time_Turn / 3600f;
				}
				else if (!Information.IsNothing(waypoint_0.Time_Zulu) && waypoint_0.InitReponse() && waypoint_1.ChangeReponse())
				{
					Waypoint.FlightPlanSegment item9 = new Waypoint.FlightPlanSegment(ref double_14, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					list_0.Add(item9);
					waypoint_0.Leg_Distance_Straight = Math2.VerifyClass(double_14, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					waypoint_0.Leg_Speed_Turn = float_2;
					waypoint_0.Leg_Distance_Turn = float_2 * num25 / 3600f;
					waypoint_0.Leg_Speed_Straight = float_1;
					float_0 = Math2.UpdateClass(Math2.PublishClass(waypoint_0.Latitude, waypoint_0.Longitude, list_0[list_0.Count - 1].StartLatitude, list_0[list_0.Count - 1].StartLongitude) + 180f);
					waypoint_0.Leg_Time_Turn = num25;
					waypoint_0.Leg_Time_Straight = waypoint_0.Leg_Distance_Straight / float_1 * 3600f;
				}
				else if (!Information.IsNothing(waypoint_0.Time_Zulu) && waypoint_0.ChangeReponse() && waypoint_1.InitReponse())
				{
					Waypoint.FlightPlanSegment item10 = new Waypoint.FlightPlanSegment(ref double_14, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					list_0.Add(item10);
					waypoint_1.Leg_Distance_Straight += Math2.VerifyClass(double_14, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					waypoint_1.Leg_Time_Straight = waypoint_0.Leg_Distance_Straight / waypoint_1.Leg_Speed_Straight * 3600f;
					waypoint_1.Leg_Time_Turn += num25;
					waypoint_1.Leg_Distance_Turn = waypoint_1.Leg_Speed_Turn * waypoint_1.Leg_Time_Turn / 3600f;
				}
				else
				{
					Waypoint.FlightPlanSegment item11 = new Waypoint.FlightPlanSegment(ref double_14, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					list_0.Add(item11);
					waypoint_0.Leg_Distance_Straight = Math2.VerifyClass(double_14, num8, waypoint_0.Latitude, waypoint_0.Longitude);
					waypoint_0.Leg_Speed_Turn = float_2;
					waypoint_0.Leg_Distance_Turn = float_2 * num25 / 3600f;
					waypoint_0.Leg_Speed_Straight = float_1;
					float_0 = Math2.UpdateClass(Math2.PublishClass(waypoint_0.Latitude, waypoint_0.Longitude, list_0[list_0.Count - 1].StartLatitude, list_0[list_0.Count - 1].StartLongitude) + 180f);
					waypoint_0.Leg_Time_Turn = num25;
					waypoint_0.Leg_Time_Straight = waypoint_0.Leg_Distance_Straight / float_1 * 3600f;
				}
			}
			else if (waypoint_0.Type == Waypoint.WaypointType.WeaponTarget)
			{
				Waypoint waypoint3;
				double double_5 = (waypoint3 = waypoint_0).Latitude;
				Waypoint.FlightPlanSegment flightPlanSegment3 = new Waypoint.FlightPlanSegment(ref double_5, waypoint_0.Longitude, waypoint_1.Latitude, waypoint_1.Longitude);
				waypoint3.Latitude = double_5;
				Waypoint.FlightPlanSegment item2 = flightPlanSegment3;
				list_0.Add(item2);
				float float_7 = Math2.PublishClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_0.Latitude, waypoint_0.Longitude);
				float num17 = Math2.VerifyClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_0.Latitude, waypoint_0.Longitude);
				float num18 = Math.Min(5f, num17 - 1f);
				double double_6 = 0.0;
				double double_7 = 0.0;
				if (num18 <= 0f)
				{
					waypoint_0.Leg_Distance_Straight = 0f;
					double_6 = waypoint_1.Longitude;
					double_7 = waypoint_1.Latitude;
				}
				else
				{
					waypoint_0.Leg_Distance_Straight = num18;
					Geodesic_EdWilliams.CalcPoint_Williams(waypoint_1.Longitude, waypoint_1.Latitude, ref double_6, ref double_7, num18, float_7);
				}
				double_5 = (waypoint3 = waypoint_1).Latitude;
				Waypoint.FlightPlanSegment flightPlanSegment4 = new Waypoint.FlightPlanSegment(ref double_5, waypoint_1.Longitude, double_7, double_6);
				waypoint3.Latitude = double_5;
				item2 = flightPlanSegment4;
				list_0.Add(item2);
				waypoint_0.Leg_Distance_Turn = 0f;
				waypoint_0.Leg_Speed_Straight = float_1;
				float_0 = Math2.UpdateClass(Math2.PublishClass(waypoint_0.Latitude, waypoint_0.Longitude, list_0[list_0.Count - 1].StartLatitude, list_0[list_0.Count - 1].StartLongitude) + 180f);
				waypoint_0.Leg_Time_Turn = num25;
				waypoint_0.Leg_Time_Straight = waypoint_0.Leg_Distance_Straight / float_1 * 3600f;
			}
			else
			{
				Waypoint waypoint4;
				double double_8 = (waypoint4 = waypoint_1).Latitude;
				Waypoint.FlightPlanSegment flightPlanSegment5 = new Waypoint.FlightPlanSegment(ref double_8, waypoint_1.Longitude, waypoint_0.Latitude, waypoint_0.Longitude);
				waypoint4.Latitude = double_8;
				Waypoint.FlightPlanSegment item3 = flightPlanSegment5;
				list_0.Add(item3);
				waypoint_0.Leg_Distance_Straight = Math2.VerifyClass(waypoint_1.Latitude, waypoint_1.Longitude, waypoint_0.Latitude, waypoint_0.Longitude);
				waypoint_0.Leg_Distance_Turn = 0f;
				waypoint_0.Leg_Speed_Straight = float_1;
				float_0 = Math2.UpdateClass(Math2.PublishClass(waypoint_0.Latitude, waypoint_0.Longitude, list_0[list_0.Count - 1].StartLatitude, list_0[list_0.Count - 1].StartLongitude) + 180f);
				waypoint_0.Leg_Time_Turn = num25;
				waypoint_0.Leg_Time_Straight = waypoint_0.Leg_Distance_Straight / float_1 * 3600f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200627", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void ValidateWeaponRoute()
	{
	}
}
