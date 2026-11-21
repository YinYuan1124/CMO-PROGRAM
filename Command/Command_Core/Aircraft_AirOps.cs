using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Aircraft_AirOps : ActiveUnit_AirOps
{
	public delegate void TookOffEventHandler(Aircraft theAircraft);

	public delegate void LandingEventHandler(Aircraft theAircraft);

	public delegate void ReachedBingoFuelEventHandler(Aircraft theAircraft);

	public delegate void HostAirFacilityChangedEventHandler(string UnitObjectID);

	public delegate void AirOpsStatusChangeEventHandler(ActiveUnit theUnit, object oldStatus);

	public enum TakeOffCheck
	{
		OK = 0,
		unsufficient_runway_length = 10,
		runway_is_to_small = 20,
		runway_altitude = 30,
		not_catapult_lauchable = 40,
		other_issue = 1000
	}

	private enum TaxyingFacilityType : byte
	{

	}

	public enum _AirOpsCondition : byte
	{
		Airborne,
		Parked,
		TaxyingToTakeOff,
		TaxyingToPark,
		TakingOff,
		Landing_PreTouchdown,
		Landing_PostTouchdown,
		Readying,
		HoldingForAvailableTransit,
		HoldingForAvailableRunway,
		HoldingOnLandingQueue,
		RTB,
		PreparingToLaunch,
		ManoeuveringToRefuel,
		Refuelling,
		OffloadingFuel,
		DeployingDippingSonar,
		EmergencyLanding,
		TaxyingToFlightDeck,
		const_19,
		BVRCrank,
		Dogfight,
		TransferringCargo,
		BVRDrag
	}

	public enum GEnum6 : byte
	{
		Drogue,
		Boom,
		BuddyDrogue
	}

	public enum AirOpsAvailabilityStatus : byte
	{
		IsAvailable,
		IsWinchester,
		IsUnderMaintenance,
		IsReserve,
		HasNoMissionLoadout
	}

	[CompilerGenerated]
	private sealed class ExpressionProcessProducer
	{
		public ActiveUnit Local_theAU;

		internal double DisableInterruptibleTag(ActiveUnit theCand)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(theCand, Local_theAU);
		}
	}

	[CompilerGenerated]
	private sealed class GlobalProcessResolver
	{
		public Aircraft_AirOps Me;
	}

	[CompilerGenerated]
	private sealed class CandidateConfigObject
	{
		public Aircraft Local_ReceiverAC;

		public GlobalProcessResolver CS_0024_003C_003E8__locals1;

		internal bool UpdateInterruptibleTag(ActiveUnit theAC)
		{
			return (Module_Unit.RangeToUnit_Horiz(theAC, Local_ReceiverAC) < 2f) & (theAC != CS_0024_003C_003E8__locals1.Me.GetAircraft());
		}
	}

	[CompilerGenerated]
	private sealed class ItemThreadBridge
	{
		public Aircraft_AirOps _003C_003E4__this;

		public Aircraft_AirOps Me;

		public GeoPoint Local_IntermediateTargetPoint;

		internal int InsertInterruptibleTag(Aircraft theT)
		{
			return _003C_003E4__this.DefineProxy(theT);
		}

		internal int PrepareInterruptibleTag(Aircraft theT)
		{
			return _003C_003E4__this.DefineProxy(theT);
		}

		internal double ReflectInterruptibleTag(Aircraft theT)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(theT, _003C_003E4__this.GetAircraft());
		}

		internal int VisitInterruptibleTag(Aircraft theT)
		{
			return _003C_003E4__this.DefineProxy(theT);
		}

		internal int RestartInterruptibleTag(Aircraft theT)
		{
			return _003C_003E4__this.DefineProxy(theT);
		}

		internal int TestInterruptibleTag(Aircraft theT)
		{
			return _003C_003E4__this.DefineProxy(theT);
		}

		internal int StopInterruptibleTag(Aircraft theT)
		{
			return _003C_003E4__this.DefineProxy(theT);
		}

		internal double CancelInterruptibleTag(Aircraft theT)
		{
			return Module_Unit.RangeToUnit_Horiz_Angular(theT, _003C_003E4__this.GetAircraft());
		}
	}

	[CompilerGenerated]
	private sealed class TestsDecoratorEntry
	{
		public double Local_RangeToTarget_Angular;

		public ItemThreadBridge CS_0024_003C_003E8__locals1;

		internal bool VerifyInterruptibleTag(Aircraft theT)
		{
			if (Module_Unit.RangeToUnit_Horiz_Angular(CS_0024_003C_003E8__locals1.Me.GetAircraft(), theT) < Local_RangeToTarget_Angular)
			{
				return Module_Unit.RangeToPoint_Horiz_Angular(theT, CS_0024_003C_003E8__locals1.Local_IntermediateTargetPoint) < Local_RangeToTarget_Angular;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class InterpreterDecoratorEntry
	{
		public ActiveUnit Local_myHost;

		public double Local_RangeToBase_Angular;

		public TestsDecoratorEntry CS_0024_003C_003E8__locals2;

		internal bool ListInterruptibleTag(Aircraft theT)
		{
			if (Module_Unit.RangeToUnit_Horiz_Angular(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Me.GetAircraft(), theT) < Local_RangeToBase_Angular)
			{
				return Module_Unit.RangeToUnit_Horiz_Angular(theT, Local_myHost) < Local_RangeToBase_Angular;
			}
			return false;
		}
	}

	private _AirOpsCondition issuerObserver;

	private _AirOpsCondition clientObserver;

	private float _DicObserver;

	private AirFacility consumerObserver;

	private string facadeObserver;

	private ActiveUnit proxyObserver;

	private string _ReaderObserver;

	private ActiveUnit m_PropertyObserver;

	private string importerObserver;

	private Aircraft m_RepositoryObserver;

	private string bridgeObserver;

	public ConcurrentDictionary<string, byte> RefuellingQueue;

	public ConcurrentDictionary<string, GEnum6> A2AR_Connections;

	public List<ActiveUnit_Struct> A2AR_NumberOfReceiverHookups;

	public bool QuickTurnaround_Enabled;

	public int QuickTurnaround_SortiesFlown;

	public int QuickTurnaround_SortiesTotal;

	public int QuickTurnaround_TimePentalty;

	public float QuickTurnaround_AirborneTime_Flown;

	public float QuickTurnaround_AirborneTime_SortieAverage;

	public float TankerHookUpDistance;

	public float TankerHookUpDistance_Wingmen;

	internal bool invocationObserver;

	public Doctrine.EMCONSettings._EMCONSetting ActiveRadarDoctrineBeforeRefueling;

	public bool EMCONInheritFromParentBeforeRefueling;

	public bool ManuallySelectedA2AR_Destination;

	[CompilerGenerated]
	private static ReachedBingoFuelEventHandler m_ClassObserver;

	private Aircraft requestObserver;

	internal float _ValueObserver;

	public bool BadWeatherFlag;

	public string WeatherString;

	private object tokenizerObserver;

	[CompilerGenerated]
	private static TookOffEventHandler stubObserver;

	[CompilerGenerated]
	private static LandingEventHandler writerObserver;

	[CompilerGenerated]
	private static HostAirFacilityChangedEventHandler specificationObserver;

	[CompilerGenerated]
	private static AirOpsStatusChangeEventHandler _WatcherObserver;

	public ActiveUnit ActualDestinationHost
	{
		get
		{
			try
			{
				ActiveUnit activeUnit = null;
				Mission mission = myUnit.AssignedMissionOrPackage();
				if (Information.IsNothing(mission))
				{
					return GetAssignedHostUnit(bool_0: true);
				}
				if (mission.MissionClass == Mission._MissionClass.Ferry)
				{
					if (Information.IsNothing(((FerryMission)mission).GetNominalDestinationHost(myUnit.ParentScen)))
					{
						string text = "";
						if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, TextCompare: false) != 0)
						{
							text = " (" + myUnit.UnitClass + ")";
						}
						myUnit.AddMessage(myUnit.Name + text + "不再能够执行转场任务：" + mission.Name + "（转场目的地似乎不见了）。该单元将从任务中删除。", myUnit.Name + " 无法转场", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						ActiveUnit activeUnit2 = myUnit;
						Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
						activeUnit2.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
						activeUnit = GetAssignedHostUnit(bool_0: true);
					}
					switch (((FerryMission)mission).Behavior)
					{
					default:
						activeUnit = GetAssignedHostUnit(bool_0: true);
						break;
					case FerryMission.FerryMissionBehavior.OneWay:
					{
						ActiveUnit nominalDestinationHost2 = ((FerryMission)mission).GetNominalDestinationHost(myUnit.ParentScen);
						activeUnit = ((!myUnit.ParentScen.FifthSecondIsChangingOnThisPulse || Operators.CompareString(ThisUnitCanHostMe(nominalDestinationHost2), "OK", TextCompare: false) == 0) ? nominalDestinationHost2 : null);
						break;
					}
					case FerryMission.FerryMissionBehavior.Cycle:
						if (myUnit.AI.FerryCycleLegIsOutbound)
						{
							ActiveUnit nominalDestinationHost = ((FerryMission)mission).GetNominalDestinationHost(myUnit.ParentScen);
							activeUnit = ((!myUnit.ParentScen.FifthSecondIsChangingOnThisPulse || Operators.CompareString(ThisUnitCanHostMe(nominalDestinationHost), "OK", TextCompare: false) == 0) ? nominalDestinationHost : null);
						}
						else
						{
							activeUnit = GetAssignedHostUnit(bool_0: true);
						}
						break;
					case FerryMission.FerryMissionBehavior.Random:
						activeUnit = GetAssignedHostUnit(bool_0: true);
						break;
					}
				}
				else if (mission.MissionClass == Mission._MissionClass.Cargo && ((CargoMission)mission).Type == CargoMission.CargoMissionType.Transfer)
				{
					CargoMission cargoMission = (CargoMission)mission;
					if (cargoMission.DestinationUnit == null || !myUnit.ParentScen.ActiveUnits.Keys.Contains(cargoMission.DestinationUnit.ObjectID))
					{
						string text2 = "";
						if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, TextCompare: false) != 0)
						{
							text2 = " (" + myUnit.UnitClass + ")";
						}
						myUnit.AddMessage(myUnit.Name + text2 + " is no longer able to execute cargo mission: " + mission.Name + " (the cargo destination appears to be missing). The unit will be removed from the mission.", myUnit.Name + " cannot execute cargo mission", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						ActiveUnit activeUnit3 = myUnit;
						Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_2 = Mission.MissionAssignmentAttemptResult.None;
						activeUnit3.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_2);
						activeUnit = GetAssignedHostUnit();
					}
					activeUnit = ((myUnit.OnboardCargo.Count() <= 0) ? GetAssignedHostUnit() : cargoMission.DestinationUnit);
				}
				else
				{
					activeUnit = GetAssignedHostUnit(bool_0: true);
				}
				if (!Information.IsNothing(activeUnit) && activeUnit.IsGroupMember() && activeUnit.GetParentGroup().IsLandInstallation)
				{
					activeUnit = activeUnit.GetParentGroup();
				}
				return activeUnit;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100406", "");
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

	public bool IsTakingOff
	{
		get
		{
			switch (Condition)
			{
			case _AirOpsCondition.HoldingForAvailableTransit:
				if (HostAirFacility.QueryReader())
				{
					return true;
				}
				return false;
			default:
				return false;
			case _AirOpsCondition.TaxyingToTakeOff:
			case _AirOpsCondition.TakingOff:
			case _AirOpsCondition.HoldingForAvailableRunway:
			case _AirOpsCondition.PreparingToLaunch:
				return true;
			}
		}
	}

	public bool IsCompletingLanding
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public Aircraft A2AR_Destination
	{
		get
		{
			return m_RepositoryObserver;
		}
		set
		{
			try
			{
				if (value != m_RepositoryObserver && m_RepositoryObserver != null && m_RepositoryObserver.AirOps != null)
				{
					try
					{
						ConcurrentDictionary<string, byte> refuellingQueue = m_RepositoryObserver.AirOps.RefuellingQueue;
						string objectID = GetAircraft().ObjectID;
						byte value2 = 0;
						refuellingQueue.TryRemove(objectID, out value2);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 200020", exception_.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				m_RepositoryObserver = value;
				if (value != null && !m_RepositoryObserver.AirOps.RefuellingQueue.ContainsKey(GetAircraft().ObjectID))
				{
					m_RepositoryObserver.AirOps.RefuellingQueue.TryAdd(GetAircraft().ObjectID, 0);
				}
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 100408", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public ActiveUnit CurrentHostUnit
	{
		get
		{
			ActiveUnit result = null;
			try
			{
				if (Information.IsNothing(proxyObserver))
				{
					if (Information.IsNothing(HostAirFacility))
					{
						result = null;
						return result;
					}
					foreach (ActiveUnit activeUnits_ in GetAircraft().ParentScen.ActiveUnits_List)
					{
						if (activeUnits_ != null && activeUnits_.AirFacilities_ReadOnly.Contains(HostAirFacility))
						{
							proxyObserver = activeUnits_;
							break;
						}
					}
				}
				if (proxyObserver.IsGroupMember())
				{
					Group.GroupType? groupType = proxyObserver.GetParentGroup()?.Type;
					byte? b = (byte?)groupType;
					bool? flag;
					bool? flag2 = (flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null));
					bool? flag3;
					bool? flag4;
					if (flag2.HasValue && flag.GetValueOrDefault())
					{
						flag3 = true;
					}
					else
					{
						b = (byte?)groupType;
						flag2 = (flag4 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null));
						flag3 = ((!flag2.HasValue) ? null : (flag4.GetValueOrDefault() | flag));
					}
					bool? flag5 = flag3;
					flag4 = flag3;
					bool? flag6;
					bool? flag7;
					if (flag4.HasValue && flag5.GetValueOrDefault())
					{
						flag6 = true;
					}
					else
					{
						b = (byte?)groupType;
						flag4 = (flag7 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 6) : null));
						flag6 = ((!flag4.HasValue) ? null : (flag7.GetValueOrDefault() | flag5));
					}
					flag7 = flag6;
					if (flag7.GetValueOrDefault())
					{
						proxyObserver = proxyObserver.GetParentGroup();
					}
				}
				result = proxyObserver;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100413", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}
		set
		{
			proxyObserver = value;
		}
	}

	public AirFacility HostAirFacility
	{
		get
		{
			return consumerObserver;
		}
		set
		{
			try
			{
				if (consumerObserver != null)
				{
					consumerObserver.HostedAircraft.Remove(myUnit.ObjectID);
				}
				if (value != null && !value.HostedAircraft.ContainsKey(myUnit.ObjectID))
				{
					value.HostedAircraft.Add(myUnit.ObjectID, GetAircraft());
				}
				bool num = consumerObserver != value;
				AirFacility airFacility = consumerObserver;
				consumerObserver = value;
				if (!num)
				{
					return;
				}
				if (Information.IsNothing(consumerObserver))
				{
					CurrentHostUnit = null;
				}
				else
				{
					CurrentHostUnit = consumerObserver.ParentPlatform;
				}
				if (!Information.IsNothing(airFacility) && !Information.IsNothing(consumerObserver) && ((consumerObserver.IsOpenAirFacility & !airFacility.IsOpenAirFacility) || (!consumerObserver.IsOpenAirFacility & airFacility.IsOpenAirFacility)))
				{
					bool flag = false;
					Side[] sides_ReadOnly = GetAircraft().ParentScen.Sides_ReadOnly;
					Contact.HostedUnitReconRecord hostedUnitReconRecord = null;
					Contact.HostedUnitReconRecord hostedUnitReconRecord2 = null;
					Side[] array = sides_ReadOnly;
					Side[] array2 = array;
					foreach (Side side in array2)
					{
						if (flag)
						{
							break;
						}
						if (side == GetAircraft().GetUnitSide() || Module_Side.IsAlliedWithThisSide(side, GetAircraft().GetUnitSide()) || !side.Contacts.ContainsKey(consumerObserver.ParentPlatform.ObjectID))
						{
							continue;
						}
						List<ActiveUnit> list = side.Units.OrderBy((ActiveUnit activeUnit_0) => Module_Unit.RangeToUnit_Horiz_Angular(activeUnit_0, consumerObserver.ParentPlatform)).ToList();
						for (int i = list.Count - 1; i >= 0; i += -1)
						{
							ActiveUnit activeUnit = list[i];
							if (activeUnit == null)
							{
								continue;
							}
							if (flag)
							{
								break;
							}
							if (!activeUnit.IsOperating())
							{
								continue;
							}
							float num2 = Module_Unit.RangeToUnit_Slant(activeUnit, consumerObserver.ParentPlatform);
							IEnumerable<Sensor> enumerable = activeUnit.Sensors_Cached.Where((Sensor theS) => theS.GetCanPerformBDA(bool_0: true, bool_1: false));
							if (!enumerable.Any())
							{
								continue;
							}
							float num3 = enumerable.Select((Sensor theS) => theS.maxRange).Max();
							if (!(num3 > 0f) || !(num2 <= num3))
							{
								continue;
							}
							foreach (Sensor item in enumerable)
							{
								if (flag)
								{
									break;
								}
								ActiveUnit parentPlatform = consumerObserver.ParentPlatform;
								List<Geopoint_Struct> list_ = null;
								Lazy<Dictionary<int, EmissionContainer>> lazy_ = null;
								bool? nullable_ = null;
								bool? nullable_2 = null;
								Module_Unit.Unit.LOSCheckResult? nullable_3 = null;
								bool? nullable_4 = null;
								bool? nullable_5 = null;
								bool? nullable_6 = null;
								if (!item.CanDetectTarget(Sensor.DetectionAttemptType.Recon, activeUnit, parentPlatform, ref list_, num2, ref lazy_, null, ref nullable_, ref nullable_2, ref nullable_3, ref nullable_4, ref nullable_5, ref nullable_6) || !(item.MaxIDRangeOnThisTarget(item.ParentPlatform, GetAircraft()) * 3f >= num2))
								{
									continue;
								}
								flag = true;
								Contact contact = side.Contacts[airFacility.ParentPlatform.ObjectID];
								Contact contact_ = side.Contacts[consumerObserver.ParentPlatform.ObjectID];
								if (!consumerObserver.IsOpenAirFacility & airFacility.IsOpenAirFacility)
								{
									activeUnit.Sensory.AddNewHostedUnitReconRecord(GetAircraft(), contact_, item);
									foreach (Contact.HostedUnitReconRecord item2 in contact.IncludeImporter(activeUnit.GetUnitSide()))
									{
										if (Operators.CompareString(item2.UnitID, GetAircraft().ObjectID, TextCompare: false) == 0)
										{
											hostedUnitReconRecord = item2;
											break;
										}
									}
									if (hostedUnitReconRecord != null)
									{
										activeUnit.Sensory.CheckConsumer(contact, hostedUnitReconRecord);
									}
								}
								if (!(consumerObserver.IsOpenAirFacility & !airFacility.IsOpenAirFacility))
								{
									continue;
								}
								foreach (Contact.HostedUnitReconRecord item3 in contact.IncludeImporter(activeUnit.GetUnitSide()))
								{
									if (Operators.CompareString(item3.UnitID, GetAircraft().ObjectID, TextCompare: false) == 0)
									{
										hostedUnitReconRecord2 = item3;
										break;
									}
								}
								if (hostedUnitReconRecord2 != null)
								{
									activeUnit.Sensory.CheckConsumer(contact, hostedUnitReconRecord2);
								}
							}
						}
					}
				}
				specificationObserver?.Invoke(GetAircraft().ObjectID);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200569", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public _AirOpsCondition OldCondition => clientObserver;

	public _AirOpsCondition Condition
	{
		get
		{
			return issuerObserver;
		}
		set
		{
			bool num = issuerObserver != value;
			clientObserver = issuerObserver;
			if (num)
			{
				if (value == _AirOpsCondition.RTB && issuerObserver == _AirOpsCondition.Refuelling)
				{
					DisconnectFromTanker();
				}
				issuerObserver = value;
				_AirOpsCondition airOpsCondition = issuerObserver;
				if (airOpsCondition != 0 && airOpsCondition != _AirOpsCondition.const_19 && airOpsCondition != _AirOpsCondition.BVRCrank && airOpsCondition != _AirOpsCondition.BVRDrag && airOpsCondition != _AirOpsCondition.Dogfight)
				{
					if (((int)airOpsCondition >= 1 && (int)airOpsCondition <= 18) || airOpsCondition == _AirOpsCondition.TransferringCargo)
					{
						_WatcherObserver?.Invoke(myUnit, clientObserver);
					}
				}
				else if ((issuerObserver == _AirOpsCondition.Airborne) & ((int)clientObserver < 19))
				{
					_WatcherObserver?.Invoke(myUnit, clientObserver);
				}
				myUnit.Kinematics.PerformOutOfSequenceExportLocation = true;
			}
			else
			{
				issuerObserver = value;
			}
		}
	}

	public float ConditionTimer
	{
		get
		{
			return _DicObserver;
		}
		set
		{
			_DicObserver = value;
			if ((value == 0f) & (Condition == _AirOpsCondition.Readying))
			{
				Condition = _AirOpsCondition.Parked;
			}
		}
	}

	public string ConditionString
	{
		get
		{
			switch (Condition)
			{
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return Condition.ToString();
			case _AirOpsCondition.Airborne:
				return "Airborne";
			case _AirOpsCondition.Parked:
				if (!Information.IsNothing(HostAirFacility) && !Information.IsNothing(HostAirFacility.ParentPlatform) && HostAirFacility.ParentPlatform.IsShip)
				{
					if (HostAirFacility.AirFacType == AirFacility._AirFacType.OpenParking)
					{
						return "停在飞行甲板";
					}
					if (HostAirFacility.AirFacType == AirFacility._AirFacType.Hangar)
					{
						return "停在机库";
					}
				}
				return "Parked";
			case _AirOpsCondition.TaxyingToTakeOff:
				if (HostAirFacility.AirFacType == AirFacility._AirFacType.Elevator)
				{
					return WeatherString + " - On elevator, enroute to takeoff";
				}
				return WeatherString + " - Taxiing to take off";
			case _AirOpsCondition.TaxyingToPark:
				if (HostAirFacility.AirFacType == AirFacility._AirFacType.Elevator)
				{
					return WeatherString + " - On elevator, enroute to parking spot";
				}
				return WeatherString + " - Taxiing to parking spot";
			case _AirOpsCondition.TakingOff:
				return WeatherString + " - Taking off";
			case _AirOpsCondition.Landing_PreTouchdown:
				return WeatherString + " - On final approach";
			case _AirOpsCondition.Landing_PostTouchdown:
				return "完成着陆";
			case _AirOpsCondition.Readying:
				return WeatherString + " - Readying";
			case _AirOpsCondition.HoldingForAvailableTransit:
				return WeatherString + " - Waiting for available taxiway/elevator";
			case _AirOpsCondition.HoldingForAvailableRunway:
				return WeatherString + " - Waiting for runway to become available";
			case _AirOpsCondition.HoldingOnLandingQueue:
				return WeatherString + " - In landing queue";
			case _AirOpsCondition.RTB:
				return WeatherString + " - Returning to base";
			case _AirOpsCondition.PreparingToLaunch:
				return WeatherString + " - Preparing to launch";
			case _AirOpsCondition.ManoeuveringToRefuel:
				return WeatherString + " - Manoeuvering to refuel";
			case _AirOpsCondition.Refuelling:
				return WeatherString + " - Refuelling";
			case _AirOpsCondition.OffloadingFuel:
				return WeatherString + " - Offloading fuel";
			case _AirOpsCondition.DeployingDippingSonar:
				return WeatherString + " - Deploying Dipping Sonar";
			case _AirOpsCondition.EmergencyLanding:
				return WeatherString + " - Chicken, critically low on fuel";
			case _AirOpsCondition.TaxyingToFlightDeck:
				if (HostAirFacility.AirFacType == AirFacility._AirFacType.Elevator)
				{
					return WeatherString + " - On elevator, enroute to flight deck";
				}
				return WeatherString + " - Moving to flight deck";
			case _AirOpsCondition.const_19:
				return WeatherString + " - Executing BVR attack";
			case _AirOpsCondition.BVRCrank:
				return WeatherString + " - Cranking";
			case _AirOpsCondition.Dogfight:
				return WeatherString + " - Dogfight";
			case _AirOpsCondition.TransferringCargo:
				return WeatherString + " - Transferring Cargo";
			case _AirOpsCondition.BVRDrag:
				return WeatherString + " - Dragging";
			}
		}
	}

	public static event TookOffEventHandler TookOff
	{
		[CompilerGenerated]
		add
		{
			TookOffEventHandler tookOffEventHandler = stubObserver;
			TookOffEventHandler tookOffEventHandler2;
			do
			{
				tookOffEventHandler2 = tookOffEventHandler;
				TookOffEventHandler value2 = (TookOffEventHandler)Delegate.Combine(tookOffEventHandler2, value);
				tookOffEventHandler = Interlocked.CompareExchange(ref stubObserver, value2, tookOffEventHandler2);
			}
			while ((object)tookOffEventHandler != tookOffEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TookOffEventHandler tookOffEventHandler = stubObserver;
			TookOffEventHandler tookOffEventHandler2;
			do
			{
				tookOffEventHandler2 = tookOffEventHandler;
				TookOffEventHandler value2 = (TookOffEventHandler)Delegate.Remove(tookOffEventHandler2, value);
				tookOffEventHandler = Interlocked.CompareExchange(ref stubObserver, value2, tookOffEventHandler2);
			}
			while ((object)tookOffEventHandler != tookOffEventHandler2);
		}
	}

	public static event LandingEventHandler Landing
	{
		[CompilerGenerated]
		add
		{
			LandingEventHandler landingEventHandler = writerObserver;
			LandingEventHandler landingEventHandler2;
			do
			{
				landingEventHandler2 = landingEventHandler;
				LandingEventHandler value2 = (LandingEventHandler)Delegate.Combine(landingEventHandler2, value);
				landingEventHandler = Interlocked.CompareExchange(ref writerObserver, value2, landingEventHandler2);
			}
			while ((object)landingEventHandler != landingEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LandingEventHandler landingEventHandler = writerObserver;
			LandingEventHandler landingEventHandler2;
			do
			{
				landingEventHandler2 = landingEventHandler;
				LandingEventHandler value2 = (LandingEventHandler)Delegate.Remove(landingEventHandler2, value);
				landingEventHandler = Interlocked.CompareExchange(ref writerObserver, value2, landingEventHandler2);
			}
			while ((object)landingEventHandler != landingEventHandler2);
		}
	}

	public static event ReachedBingoFuelEventHandler ReachedBingoFuel
	{
		[CompilerGenerated]
		add
		{
			ReachedBingoFuelEventHandler reachedBingoFuelEventHandler = m_ClassObserver;
			ReachedBingoFuelEventHandler reachedBingoFuelEventHandler2;
			do
			{
				reachedBingoFuelEventHandler2 = reachedBingoFuelEventHandler;
				ReachedBingoFuelEventHandler value2 = (ReachedBingoFuelEventHandler)Delegate.Combine(reachedBingoFuelEventHandler2, value);
				reachedBingoFuelEventHandler = Interlocked.CompareExchange(ref m_ClassObserver, value2, reachedBingoFuelEventHandler2);
			}
			while ((object)reachedBingoFuelEventHandler != reachedBingoFuelEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ReachedBingoFuelEventHandler reachedBingoFuelEventHandler = m_ClassObserver;
			ReachedBingoFuelEventHandler reachedBingoFuelEventHandler2;
			do
			{
				reachedBingoFuelEventHandler2 = reachedBingoFuelEventHandler;
				ReachedBingoFuelEventHandler value2 = (ReachedBingoFuelEventHandler)Delegate.Remove(reachedBingoFuelEventHandler2, value);
				reachedBingoFuelEventHandler = Interlocked.CompareExchange(ref m_ClassObserver, value2, reachedBingoFuelEventHandler2);
			}
			while ((object)reachedBingoFuelEventHandler != reachedBingoFuelEventHandler2);
		}
	}

	public static event HostAirFacilityChangedEventHandler HostAirFacilityChanged
	{
		[CompilerGenerated]
		add
		{
			HostAirFacilityChangedEventHandler hostAirFacilityChangedEventHandler = specificationObserver;
			HostAirFacilityChangedEventHandler hostAirFacilityChangedEventHandler2;
			do
			{
				hostAirFacilityChangedEventHandler2 = hostAirFacilityChangedEventHandler;
				HostAirFacilityChangedEventHandler value2 = (HostAirFacilityChangedEventHandler)Delegate.Combine(hostAirFacilityChangedEventHandler2, value);
				hostAirFacilityChangedEventHandler = Interlocked.CompareExchange(ref specificationObserver, value2, hostAirFacilityChangedEventHandler2);
			}
			while ((object)hostAirFacilityChangedEventHandler != hostAirFacilityChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			HostAirFacilityChangedEventHandler hostAirFacilityChangedEventHandler = specificationObserver;
			HostAirFacilityChangedEventHandler hostAirFacilityChangedEventHandler2;
			do
			{
				hostAirFacilityChangedEventHandler2 = hostAirFacilityChangedEventHandler;
				HostAirFacilityChangedEventHandler value2 = (HostAirFacilityChangedEventHandler)Delegate.Remove(hostAirFacilityChangedEventHandler2, value);
				hostAirFacilityChangedEventHandler = Interlocked.CompareExchange(ref specificationObserver, value2, hostAirFacilityChangedEventHandler2);
			}
			while ((object)hostAirFacilityChangedEventHandler != hostAirFacilityChangedEventHandler2);
		}
	}

	public static event AirOpsStatusChangeEventHandler AirOpsStatusChange
	{
		[CompilerGenerated]
		add
		{
			AirOpsStatusChangeEventHandler airOpsStatusChangeEventHandler = _WatcherObserver;
			AirOpsStatusChangeEventHandler airOpsStatusChangeEventHandler2;
			do
			{
				airOpsStatusChangeEventHandler2 = airOpsStatusChangeEventHandler;
				AirOpsStatusChangeEventHandler value2 = (AirOpsStatusChangeEventHandler)Delegate.Combine(airOpsStatusChangeEventHandler2, value);
				airOpsStatusChangeEventHandler = Interlocked.CompareExchange(ref _WatcherObserver, value2, airOpsStatusChangeEventHandler2);
			}
			while ((object)airOpsStatusChangeEventHandler != airOpsStatusChangeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			AirOpsStatusChangeEventHandler airOpsStatusChangeEventHandler = _WatcherObserver;
			AirOpsStatusChangeEventHandler airOpsStatusChangeEventHandler2;
			do
			{
				airOpsStatusChangeEventHandler2 = airOpsStatusChangeEventHandler;
				AirOpsStatusChangeEventHandler value2 = (AirOpsStatusChangeEventHandler)Delegate.Remove(airOpsStatusChangeEventHandler2, value);
				airOpsStatusChangeEventHandler = Interlocked.CompareExchange(ref _WatcherObserver, value2, airOpsStatusChangeEventHandler2);
			}
			while ((object)airOpsStatusChangeEventHandler != airOpsStatusChangeEventHandler2);
		}
	}

	[SpecialName]
	private Aircraft GetAircraft()
	{
		if (requestObserver == null)
		{
			requestObserver = (Aircraft)myUnit;
		}
		return requestObserver;
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("AirOps");
			xmlWriter_0.WriteStartElement("LQ");
			Aircraft[] landingQueue = _LandingQueue;
			for (int i = 0; i < landingQueue.Length; i = checked(i + 1))
			{
				landingQueue[i].ToXML(ref xmlWriter_0, ref hashSet_0);
			}
			xmlWriter_0.WriteEndElement();
			XmlWriter obj = xmlWriter_0;
			int num = (int)issuerObserver;
			obj.WriteElementString("Con", num.ToString());
			xmlWriter_0.WriteElementString("CT", XmlConvert.ToString(ConditionTimer));
			if (_ValueObserver >= 0f)
			{
				xmlWriter_0.WriteElementString("CTOverride", XmlConvert.ToString(_ValueObserver));
			}
			if (!Information.IsNothing(HostAirFacility))
			{
				xmlWriter_0.WriteElementString("HAF", HostAirFacility.ObjectID);
			}
			if (!Information.IsNothing(CurrentHostUnit))
			{
				xmlWriter_0.WriteElementString("CHU", CurrentHostUnit.ObjectID);
			}
			if (!Information.IsNothing(GetAssignedHostUnit()))
			{
				xmlWriter_0.WriteElementString("AHU", m_PropertyObserver.ObjectID);
			}
			if (!Information.IsNothing(A2AR_Destination))
			{
				xmlWriter_0.WriteElementString("A2ARD", A2AR_Destination.ObjectID);
			}
			xmlWriter_0.WriteElementString("ManA2ARD", ManuallySelectedA2AR_Destination.ToString());
			if (RefuellingQueue.Count > 0)
			{
				xmlWriter_0.WriteStartElement("RQ");
				foreach (string key in RefuellingQueue.Keys)
				{
					xmlWriter_0.WriteElementString("ID", key);
				}
				xmlWriter_0.WriteEndElement();
			}
			if (A2AR_Connections.Count > 0)
			{
				xmlWriter_0.WriteStartElement("A2ARC");
				foreach (KeyValuePair<string, GEnum6> a2AR_Connection in A2AR_Connections)
				{
					if (Information.IsNothing(a2AR_Connection.Key))
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else
					{
						xmlWriter_0.WriteElementString("Conn", a2AR_Connection.Key + "_" + Conversions.ToString((int)a2AR_Connection.Value));
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteStartElement("A2AR_NumberOfReceiverHookups");
			if (A2AR_NumberOfReceiverHookups != null && A2AR_NumberOfReceiverHookups.Where((ActiveUnit_Struct x) => x.DBID != 0).Count() != 0 && !A2AR_NumberOfReceiverHookups.Contains(new ActiveUnit_Struct()))
			{
				foreach (ActiveUnit_Struct a2AR_NumberOfReceiverHookup in A2AR_NumberOfReceiverHookups)
				{
					a2AR_NumberOfReceiverHookup.ToXML(ref xmlWriter_0, ref hashSet_0);
				}
			}
			xmlWriter_0.WriteEndElement();
			if (QuickTurnaround_Enabled)
			{
				xmlWriter_0.WriteElementString("QuickTurnaround_Enabled", QuickTurnaround_Enabled.ToString());
			}
			if (QuickTurnaround_SortiesFlown != 0)
			{
				xmlWriter_0.WriteElementString("QuickTurnaround_SortiesFlown", QuickTurnaround_SortiesFlown.ToString());
			}
			if (QuickTurnaround_SortiesTotal != 0)
			{
				xmlWriter_0.WriteElementString("QuickTurnaround_SortiesTotal", QuickTurnaround_SortiesTotal.ToString());
			}
			if (QuickTurnaround_TimePentalty != 0)
			{
				xmlWriter_0.WriteElementString("QuickTurnaround_TimePentalty", QuickTurnaround_TimePentalty.ToString());
			}
			if (QuickTurnaround_AirborneTime_Flown != 0f)
			{
				xmlWriter_0.WriteElementString("QuickTurnaround_AirborneTime_Flown", QuickTurnaround_AirborneTime_Flown.ToString());
			}
			if (QuickTurnaround_AirborneTime_SortieAverage != 0f)
			{
				xmlWriter_0.WriteElementString("QuickTurnaround_AirborneTime_SortieAverage", QuickTurnaround_AirborneTime_SortieAverage.ToString());
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100404", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Aircraft_AirOps FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Aircraft_AirOps aircraft_AirOps = new Aircraft_AirOps(ref activeUnit_0);
			aircraft_AirOps.myUnit = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				IEnumerator enumerator3 = null;
				IEnumerator enumerator4 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "QuickTurnaround_AirborneTime_Flown":
						aircraft_AirOps.QuickTurnaround_AirborneTime_Flown = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
						break;
					case "QuickTurnaround_TimePentalty":
						aircraft_AirOps.QuickTurnaround_TimePentalty = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "A2AR_NumberOfReceiverHookups":
					{
						int result = 0;
						if (xmlNode.ChildNodes != null && xmlNode.ChildNodes.Count > 0 && int.TryParse(xmlNode.ChildNodes[0].InnerText, out result))
						{
							break;
						}
						aircraft_AirOps.A2AR_NumberOfReceiverHookups = new List<ActiveUnit_Struct>();
						try
						{
							enumerator3 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode_4 = (XmlNode)enumerator3.Current;
								ActiveUnit_Struct item = ActiveUnit_Struct.FromXML(ref xmlNode_4, ref concurrentDictionary_0, activeUnit_0.ParentScen);
								aircraft_AirOps.A2AR_NumberOfReceiverHookups.Add(item);
							}
						}
						finally
						{
							if (enumerator3 is IDisposable)
							{
								(enumerator3 as IDisposable).Dispose();
							}
						}
						break;
					}
					case "QuickTurnaround_SortiesTotal":
						aircraft_AirOps.QuickTurnaround_SortiesTotal = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "CurrentHostUnit":
					case "CHU":
					{
						if (string.IsNullOrEmpty(xmlNode.ChildNodes[0].InnerXml))
						{
							aircraft_AirOps._ReaderObserver = xmlNode.InnerXml;
							break;
						}
						XmlNode xmlNode_3 = xmlNode.ChildNodes[0];
						ActiveUnit activeUnit = ActiveUnit.FromXML(ref xmlNode_3, ref concurrentDictionary_0, ref activeUnit_0.ParentScen);
						if (!activeUnit_0.ParentScen.ActiveUnits.ContainsKey(activeUnit.ObjectID))
						{
							activeUnit_0.ParentScen.ActiveUnits.Add(activeUnit.ObjectID, activeUnit);
						}
						if (!activeUnit.AirFacilities_ReadOnly.Contains(aircraft_AirOps.HostAirFacility))
						{
							activeUnit.AirOps.AddThisAircraft((Aircraft)activeUnit_0, bool_0: false);
						}
						break;
					}
					case "RefuellingQueue":
					case "RQ":
						try
						{
							enumerator4 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator4.Current;
								aircraft_AirOps.RefuellingQueue.TryAdd(xmlNode2.InnerText, 0);
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
					case "CT":
					case "ConditionTimer":
						aircraft_AirOps.ConditionTimer = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "LandingQueue":
					case "LQ":
					{
						int num = xmlNode.ChildNodes.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							ArrayExtensions.Add(ref aircraft_AirOps._LandingQueue_IDs, xmlNode.ChildNodes[i].InnerText);
						}
						break;
					}
					case "QuickTurnaround_SortiesFlown":
						aircraft_AirOps.QuickTurnaround_SortiesFlown = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "CTOverride":
						aircraft_AirOps._ValueObserver = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "QuickTurnaround_Enabled":
						aircraft_AirOps.QuickTurnaround_Enabled = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "Con":
					case "Condition":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							aircraft_AirOps.Condition = (_AirOpsCondition)Conversions.ToByte(xmlNode.InnerText);
						}
						else
						{
							aircraft_AirOps.Condition = (_AirOpsCondition)Enum.Parse(typeof(_AirOpsCondition), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "A2AR_Destination":
					case "A2ARD":
						aircraft_AirOps.bridgeObserver = xmlNode.InnerText;
						break;
					case "A2AR_Connections":
					case "A2ARC":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								string[] array = ((XmlNode)enumerator2.Current).InnerText.Split('_');
								if (string.IsNullOrEmpty(array[0]))
								{
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
								}
								else
								{
									aircraft_AirOps.A2AR_Connections.TryAdd(array[0], (GEnum6)Conversions.ToByte(array[1]));
								}
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
					case "ManA2ARD":
						aircraft_AirOps.ManuallySelectedA2AR_Destination = bool.Parse(xmlNode.InnerText);
						break;
					case "AHU":
					case "AssignedHostUnit":
						if (xmlNode.FirstChild.HasChildNodes)
						{
							XmlNode xmlNode_2 = xmlNode.ChildNodes[0];
							ActiveUnit activeUnit_ = ActiveUnit.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref activeUnit_0.ParentScen);
							aircraft_AirOps.SetAssignedHostUnit(bool_0: false, activeUnit_);
						}
						else
						{
							aircraft_AirOps.importerObserver = xmlNode.InnerText;
						}
						break;
					case "QuickTurnaround_AirborneTime_SortieAverage":
						aircraft_AirOps.QuickTurnaround_AirborneTime_SortieAverage = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
						break;
					case "HAF":
					case "HostAirFacility":
					{
						if (string.IsNullOrEmpty(xmlNode.ChildNodes[0].InnerXml))
						{
							aircraft_AirOps.facadeObserver = xmlNode.InnerText;
							break;
						}
						XmlNode xmlNode_ = xmlNode.ChildNodes[0];
						aircraft_AirOps.HostAirFacility = AirFacility.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_0.ParentScen);
						aircraft_AirOps.facadeObserver = Misc.StartRequest(xmlNode.ChildNodes[0].ChildNodes, "ID").InnerText;
						break;
					}
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
			return aircraft_AirOps;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100405", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Aircraft_AirOps result2 = new Aircraft_AirOps(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result2;
		}
	}

	[SpecialName]
	public int GetA2AR_Tanker_FuelReservation(ActiveUnit activeUnit_0, Group group_0, bool bool_0)
	{
		try
		{
			List<string> list = RefuellingQueue.Keys.ToList();
			foreach (string item in list)
			{
				Aircraft aircraft = (Aircraft)GetAircraft().ParentScen.ActiveUnits[item];
				if (aircraft == null || aircraft.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
				{
					ConcurrentDictionary<string, byte> refuellingQueue = RefuellingQueue;
					byte value = 0;
					refuellingQueue.TryRemove(item, out value);
				}
			}
			list = RefuellingQueue.Keys.ToList();
			if (activeUnit_0 != null && list.Contains(activeUnit_0.ObjectID))
			{
				list.Remove(activeUnit_0.ObjectID);
			}
			if (group_0 != null)
			{
				foreach (ActiveUnit value2 in group_0.Units.Values)
				{
					if (list.Contains(value2.ObjectID))
					{
						list.Remove(value2.ObjectID);
					}
				}
			}
			int num = 0;
			foreach (string item2 in list)
			{
				Aircraft aircraft2 = (Aircraft)GetAircraft().ParentScen.ActiveUnits[item2];
				if (!aircraft2.IsDestroyed)
				{
					num = (bool_0 ? (num + (int)Math.Round((double)aircraft2.FuelCapacityMax * 0.1)) : (num + aircraft2.FuelCapacityMax));
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100407", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	public string ThisUnitCanHostMe(ActiveUnit activeUnit_0)
	{
		try
		{
			if (Information.IsNothing(activeUnit_0))
			{
				return "Error";
			}
			if (activeUnit_0.IsGroup && !activeUnit_0.HasRunwaysOrPads)
			{
				return "选定的组没有跑道或着陆垫";
			}
			AirOpsAttemptResult airOpsAttemptResult = activeUnit_0.AirOps.CanHostThisAircraft(GetAircraft());
			if (airOpsAttemptResult == AirOpsAttemptResult.Success)
			{
				AirOpsAttemptResult airOpsAttemptResult2 = StopProxy(activeUnit_0, bool_0: true);
				if (airOpsAttemptResult2 == AirOpsAttemptResult.Success)
				{
					return "OK";
				}
				return "Cannot land here " + airOpsAttemptResult2.ToString().Replace("_", " ");
			}
			return "The aircraft cannot be hosted on any air facility here (Last reason : " + airOpsAttemptResult.ToString().Replace("_", " ") + ")";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100409", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return "Error!";
		}
	}

	public void PickNewAssignedHost_NearestToThisUnit(ActiveUnit activeUnit_0)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		try
		{
			if (Information.IsNothing(CurrentHostUnit))
			{
				foreach (ActiveUnit item in myUnit.GetUnitSide().Units.ToList())
				{
					if (Operators.CompareString(ThisUnitCanHostMe(item), "OK", TextCompare: false) == 0)
					{
						list.Add(item);
					}
				}
				if (list.Count > 0)
				{
					m_PropertyObserver = list.OrderBy((ActiveUnit theCand) => Module_Unit.RangeToUnit_Horiz_Angular(theCand, activeUnit_0)).ElementAtOrDefault(0);
					string text = "";
					if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, TextCompare: false) != 0)
					{
						text = " (" + myUnit.UnitClass + ")";
					}
					GetAircraft().AddMessage(GetAircraft().Name + text + "选择一个新的基地：" + m_PropertyObserver.Name + ".", GetAircraft().Name + " 选择新基地", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
				}
			}
			else
			{
				SetAssignedHostUnit(bool_0: false, CurrentHostUnit);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100410", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PickNewAssignedHost_Nearest()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		try
		{
			if (CurrentHostUnit != null)
			{
				if (!CurrentHostUnit.IsDestroyed)
				{
					SetAssignedHostUnit(bool_0: false, CurrentHostUnit);
					return;
				}
				CurrentHostUnit = null;
			}
			if (myUnit.Navigator.HasFlight && !string.IsNullOrEmpty(myUnit.Navigator.GetFlight().AlternativeLandingLocation_HostUnitObjectID) && myUnit.ParentScen.ActiveUnits.ContainsKey(myUnit.Navigator.GetFlight().AlternativeLandingLocation_HostUnitObjectID))
			{
				m_PropertyObserver = myUnit.ParentScen.ActiveUnits[myUnit.Navigator.GetFlight().AlternativeLandingLocation_HostUnitObjectID];
				if (!Information.IsNothing(m_PropertyObserver))
				{
					return;
				}
			}
			foreach (ActiveUnit item in Misc.EnableRequest(myUnit.GetUnitSide().Units))
			{
				if (Operators.CompareString(ThisUnitCanHostMe(item), "OK", TextCompare: false) == 0)
				{
					list.Add(item);
				}
			}
			if (list.Count > 0)
			{
				m_PropertyObserver = list.OrderBy((ActiveUnit activeUnit_0) => Module_Unit.RangeToUnit_Horiz_Angular(activeUnit_0, myUnit)).ElementAtOrDefault(0);
				string text = "";
				if (Operators.CompareString(GetAircraft().Name, GetAircraft().UnitClass, TextCompare: false) != 0)
				{
					text = " (" + GetAircraft().UnitClass + ")";
				}
				GetAircraft().AddMessage(GetAircraft().Name + text + "选择一个新的基地：" + m_PropertyObserver.Name + ".", GetAircraft().Name + " 选择新基地", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100411", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PickNewAssignedHost_RandomWithinRange(ActiveUnit activeUnit_0 = null)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		try
		{
			double num = Math2.TestClass(myUnit.Kinematics.MaxRange(bool_0: true, null, null));
			foreach (ActiveUnit item in myUnit.GetUnitSide().Units.ToList())
			{
				if (!item.IsAircraft && !item.IsGroup && item.IsOperating() && item != myUnit && Module_Unit.RangeToUnit_Horiz_Angular(myUnit, item) <= num && Operators.CompareString(ThisUnitCanHostMe(item), "OK", TextCompare: false) == 0)
				{
					list.Add(item);
				}
			}
			if (!Information.IsNothing(activeUnit_0) && list.Contains(activeUnit_0))
			{
				list.Remove(activeUnit_0);
			}
			if (list.Count > 0)
			{
				int index = GameGeneral.LockRandom_0.Next(list.Count);
				m_PropertyObserver = list[index];
				string text = "";
				if (Operators.CompareString(GetAircraft().Name, GetAircraft().UnitClass, TextCompare: false) != 0)
				{
					text = " (" + GetAircraft().UnitClass + ")";
				}
				GetAircraft().AddMessage(GetAircraft().Name + text + "选择一个新的基地：" + m_PropertyObserver.Name + ".", GetAircraft().Name + " 选择新基地", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100412", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	public ActiveUnit GetAssignedHostUnit(bool bool_0 = false)
	{
		ActiveUnit result = null;
		try
		{
			if (bool_0)
			{
				if (m_PropertyObserver != null)
				{
					ActiveUnit propertyObserver = m_PropertyObserver;
					if (propertyObserver == null || !propertyObserver.IsDestroyed)
					{
						goto IL_0042;
					}
				}
				PickNewAssignedHost_Nearest();
			}
			goto IL_0042;
			IL_0042:
			result = m_PropertyObserver;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100414", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public void SetAssignedHostUnit(bool bool_0, ActiveUnit activeUnit_0)
	{
		m_PropertyObserver = activeUnit_0;
	}

	internal bool InitProxy(ActiveUnit activeUnit_0 = null)
	{
		double latitude;
		double longitude;
		double a;
		if (activeUnit_0 == null)
		{
			latitude = myUnit.GetLatitude();
			longitude = myUnit.GetLongitude();
			a = myUnit.GetCurrentAltitude();
		}
		else
		{
			latitude = activeUnit_0.GetLatitude();
			longitude = activeUnit_0.GetLongitude();
			a = activeUnit_0.GetCurrentAltitude();
		}
		if (myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations))
		{
			Weather.WeatherProfile weatherAtThisTimeAndPlace = Weather.GetWeatherAtThisTimeAndPlace(myUnit.ParentScen, latitude, longitude, (int)Math.Round(a));
			LandCover.LandCoverType landCoverType_ = LandCover.DestroyClass(latitude, longitude, myUnit.ParentScen);
			float? minimumSafeHeight = GetAircraft().MinimumSafeHeight;
			int num = 0;
			num = (minimumSafeHeight.HasValue ? Math.Max(LandCover.CallClass(landCoverType_), (int)Math.Round(minimumSafeHeight.Value)) : LandCover.CallClass(landCoverType_));
			if (weatherAtThisTimeAndPlace.CloudInfo.LowCloudBase_m <= num)
			{
				if ((float)weatherAtThisTimeAndPlace.CloudInfo.LowCloudCoverThickness <= 3f)
				{
					return true;
				}
				return false;
			}
			return true;
		}
		return true;
	}

	internal bool CheckProxy(ActiveUnit activeUnit_0 = null)
	{
		double latitude;
		double longitude;
		if (activeUnit_0 == null)
		{
			latitude = myUnit.GetLatitude();
			longitude = myUnit.GetLongitude();
			myUnit.GetCurrentAltitude();
		}
		else
		{
			latitude = activeUnit_0.GetLatitude();
			longitude = activeUnit_0.GetLongitude();
			activeUnit_0.GetCurrentAltitude();
		}
		if (myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations))
		{
			switch (GetAircraft().Loadout.Weather)
			{
			default:
				return true;
			case Loadout._LoadoutWeather.ClearWeather:
				if (Weather.GetWeatherAtThisTimeAndPlace(myUnit.ParentScen, latitude, longitude, 0).RainfallRate <= 5f)
				{
					return true;
				}
				return false;
			case Loadout._LoadoutWeather.None:
			case Loadout._LoadoutWeather.AllWeather:
			case Loadout._LoadoutWeather.LimitedAllWeather:
				return true;
			}
		}
		return true;
	}

	internal bool ConcatProxy(ActiveUnit activeUnit_0 = null)
	{
		double latitude;
		double longitude;
		if (activeUnit_0 == null)
		{
			latitude = myUnit.GetLatitude();
			longitude = myUnit.GetLongitude();
			myUnit.GetCurrentAltitude();
		}
		else
		{
			latitude = activeUnit_0.GetLatitude();
			longitude = activeUnit_0.GetLongitude();
			activeUnit_0.GetCurrentAltitude();
		}
		if (myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations))
		{
			Loadout._LoadoutDayNight timeOfDay = GetAircraft().Loadout.TimeOfDay;
			if (timeOfDay != Loadout._LoadoutDayNight.None && timeOfDay != Loadout._LoadoutDayNight.DayNight)
			{
				if (GetAircraft().Loadout.TimeOfDay == (Loadout._LoadoutDayNight)0)
				{
					return true;
				}
				bool flag = SunModule.CollectSpecification(myUnit.ParentScen, myUnit.ParentScen.Time.Year, myUnit.ParentScen.Time.Month, myUnit.ParentScen.Time.Day, myUnit.ParentScen.Time.Hour, myUnit.ParentScen.Time.Minute, myUnit.ParentScen.Time.Second, bool_0: true, latitude, longitude, 0.0) == Weather.TTimeOfDayType.tod_Day;
				if (GetAircraft().Loadout.TimeOfDay == Loadout._LoadoutDayNight.DayOnly && flag)
				{
					return true;
				}
				if (GetAircraft().Loadout.TimeOfDay == Loadout._LoadoutDayNight.NightOnly && !flag)
				{
					return true;
				}
				return false;
			}
			return true;
		}
		return true;
	}

	internal bool InterruptProxy(ActiveUnit activeUnit_0 = null)
	{
		WeatherString = "";
		BadWeatherFlag = false;
		if (!GetAircraft().AirOps.CheckProxy(activeUnit_0))
		{
			WeatherString = "Cannot land (rainfall too heavy)";
			ConditionTimer = 900f;
			BadWeatherFlag = true;
		}
		if (!GetAircraft().AirOps.ConcatProxy(activeUnit_0))
		{
			WeatherString += " Cannot land (daylight conditions not met)";
			ConditionTimer = 900f;
			BadWeatherFlag = true;
		}
		if (!GetAircraft().AirOps.InitProxy(activeUnit_0))
		{
			WeatherString += " Cannot land (visibility too low)";
			ConditionTimer = 900f;
			BadWeatherFlag = true;
		}
		return !BadWeatherFlag;
	}

	public Aircraft_AirOps(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
		RefuellingQueue = new ConcurrentDictionary<string, byte>();
		A2AR_Connections = new ConcurrentDictionary<string, GEnum6>();
		A2AR_NumberOfReceiverHookups = new List<ActiveUnit_Struct>();
		TankerHookUpDistance = 0.5f;
		TankerHookUpDistance_Wingmen = 2f;
		ActiveRadarDoctrineBeforeRefueling = Doctrine.EMCONSettings._EMCONSetting.Passive;
		EMCONInheritFromParentBeforeRefueling = false;
		ManuallySelectedA2AR_Destination = false;
		_ValueObserver = -1f;
		BadWeatherFlag = false;
		WeatherString = "";
		tokenizerObserver = RuntimeHelpers.GetObjectValue(new object());
	}

	private void RemoveProxy()
	{
		if (myUnit.AssignedMissionOrPackage() == null || !myUnit.AssignedMissionOrPackage().IsActive || !(myUnit is Aircraft) || !(myUnit.AssignedMissionOrPackage() is CargoMission))
		{
			return;
		}
		CargoMission cargoMission = (CargoMission)myUnit.AssignedMissionOrPackage();
		Aircraft aircraft = (Aircraft)myUnit;
		if (aircraft.Loadout.Cargo_Type == CargoType.NoCargo)
		{
			return;
		}
		if (aircraft.DockingOps.MoveDic())
		{
			aircraft.AirOps.Condition = _AirOpsCondition.PreparingToLaunch;
			return;
		}
		if (aircraft.DockingOps.ConnectDic())
		{
			if (Condition == _AirOpsCondition.Parked)
			{
				aircraft.AirOps.Condition = _AirOpsCondition.PreparingToLaunch;
			}
			return;
		}
		List<ActiveUnit> list = new List<ActiveUnit>();
		ActiveUnit currentHostUnitCargoSource = myUnit.CurrentHostUnitCargoSource;
		if (currentHostUnitCargoSource.IsGroup)
		{
			foreach (KeyValuePair<string, ActiveUnit> unit in ((Group)currentHostUnitCargoSource).Units)
			{
				list.Add(unit.Value);
			}
		}
		else
		{
			list.Add(currentHostUnitCargoSource);
		}
		object cargoOpsLockObj = ActiveUnit_DockingOps.CargoOpsLockObj;
		ObjectFlowControl.CheckForSyncLockOnValueType(cargoOpsLockObj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(cargoOpsLockObj, ref lockTaken);
			foreach (ActiveUnit item in list)
			{
				List<CargoManifestItem> list_ = null;
				if (!cargoMission.MoveAllCargo)
				{
					list_ = cargoMission.CargoToUnload;
				}
				List<Cargo> list2 = ActiveUnit_DockingOps.DetermineFeasibleCargoTransferManifest((ICargoHost)item, (ICargoHost)myUnit, list_, item);
				if (list2.Count <= 0)
				{
					continue;
				}
				int num = ActiveUnit_DockingOps.TimeToLoadCargo(myUnit, list2);
				ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(item, myUnit, list2);
				Condition = _AirOpsCondition.Readying;
				if (cargoMission.InstantLoadingForNextManifest)
				{
					cargoMission.InstantLoadingForNextManifest = false;
					ConditionTimer = Math.Max(ConditionTimer, 0f);
				}
				else
				{
					ConditionTimer = Math.Max(ConditionTimer, num);
				}
				foreach (Cargo item2 in list2)
				{
					CargoManifestItem.Remove(item2, cargoMission.CargoToUnload);
				}
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(cargoOpsLockObj);
			}
		}
	}

	public void DoAirOps(float float_0)
	{
		if (GetAircraft().IsOperating())
		{
			GetAircraft().AirborneTime += float_0;
		}
		try
		{
			float conditionTimer = ConditionTimer;
			ConditionTimer -= float_0;
			if (ConditionTimer < 0f)
			{
				ConditionTimer = 0f;
			}
			if (!(ConditionTimer <= 0f))
			{
				return;
			}
			switch (Condition)
			{
			case _AirOpsCondition.Parked:
				if (Information.IsNothing(HostAirFacility))
				{
					break;
				}
				RemoveProxy();
				if (!HostAirFacility.ResetReader() && (GetAircraft().IsHelicopter || !HostAirFacility.DefineReader()))
				{
					if (HostAirFacility.DefineReader())
					{
						List<AirFacility> list = new List<AirFacility>();
						AirFacility[] airFacilities_ReadOnly = CurrentHostUnit.AirFacilities_ReadOnly;
						AirFacility[] array = airFacilities_ReadOnly;
						foreach (AirFacility airFacility in array)
						{
							if (airFacility.DefineReader())
							{
								list.Add(airFacility);
							}
						}
						if (list.Count == 1 && HostAirFacility == list[0])
						{
							AttemptToPark(bool_0: true, bool_1: false);
							break;
						}
					}
					if (myUnit.ParentScen.FifthMinuteIsChangingOnThisPulse)
					{
						AttemptToMoveToFlightDeck();
					}
					if (((conditionTimer > 0f) & (ConditionTimer <= 0f)) && !Information.IsNothing(CurrentHostUnit))
					{
						string text = "";
						if (Operators.CompareString(GetAircraft().Name, GetAircraft().UnitClass, TextCompare: false) != 0)
						{
							text = " (" + GetAircraft().UnitClass + ")";
						}
						GetAircraft().AddMessage(GetAircraft().Name + text + "准备好了" + CurrentHostUnit.Name, GetAircraft().Name + " 已就绪", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(CurrentHostUnit.GetLongitude(), CurrentHostUnit.GetLatitude()));
					}
				}
				else
				{
					AttemptToPark(bool_0: true, bool_1: false);
				}
				break;
			case _AirOpsCondition.TaxyingToTakeOff:
				if (!PrepareProxy())
				{
					AttemptToMoveToRunway(bool_0: false);
				}
				break;
			case _AirOpsCondition.TaxyingToPark:
				if (GetAircraft().Navigator != null && GetAircraft().Navigator.GetFlight() != null && GetAircraft().Navigator.GetFlight().TaskPool == null)
				{
					GetAircraft().Navigator.ClearFlight();
				}
				AttemptToPark();
				break;
			case _AirOpsCondition.TakingOff:
				CompareProxy(float_0);
				break;
			case _AirOpsCondition.Landing_PreTouchdown:
				if (Module_Unit.RangeToUnit_Horiz(GetAircraft(), ActualDestinationHost) > 20f)
				{
					AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
				}
				if (GetAircraft().Navigator.AboutToLand(float_0))
				{
					if (GetAircraft().Navigator != null && GetAircraft().Navigator.GetFlight() != null && GetAircraft().Navigator.GetFlight().TaskPool == null)
					{
						GetAircraft().Navigator.ClearFlight();
					}
					AttemptToFinishLanding(float_0);
				}
				break;
			case _AirOpsCondition.Landing_PostTouchdown:
				if (GetAircraft().Navigator != null && GetAircraft().Navigator.GetFlight() != null && GetAircraft().Navigator.GetFlight().TaskPool == null)
				{
					GetAircraft().Navigator.ClearFlight();
				}
				AttemptToPark();
				break;
			case _AirOpsCondition.Readying:
				AttemptToMoveToFlightDeck();
				break;
			case _AirOpsCondition.HoldingForAvailableTransit:
				if (!PrepareProxy())
				{
					AttemptToMoveToRunway(bool_0: false);
				}
				break;
			case _AirOpsCondition.HoldingForAvailableRunway:
				if (!PrepareProxy())
				{
					AttemptToMoveToRunway(bool_0: false);
				}
				break;
			case _AirOpsCondition.HoldingOnLandingQueue:
				PopProxy();
				break;
			case _AirOpsCondition.RTB:
				if (!Information.IsNothing(HostAirFacility))
				{
					if (GetAircraft().Navigator != null && GetAircraft().Navigator.GetFlight() != null && GetAircraft().Navigator.GetFlight().TaskPool == null)
					{
						GetAircraft().Navigator.ClearFlight();
					}
					if (HostAirFacility.ResetReader() || (!GetAircraft().IsHelicopter && HostAirFacility.DefineReader()))
					{
						AttemptToPark();
					}
				}
				break;
			case _AirOpsCondition.PreparingToLaunch:
				if (!PrepareProxy())
				{
					AttemptToMoveToRunway(bool_0: false);
				}
				break;
			case _AirOpsCondition.ManoeuveringToRefuel:
				AttemptToConnectToTanker(bool_0: false);
				break;
			case _AirOpsCondition.Refuelling:
				if (A2AR_Destination != null && !A2AR_Destination.IsDestroyed)
				{
					if (A2AR_Destination.AirOps.Condition != _AirOpsCondition.OffloadingFuel)
					{
						DisconnectFromTanker();
					}
				}
				else
				{
					GetAircraft().Status = ActiveUnit._ActiveUnitStatus.Unassigned;
					Condition = _AirOpsCondition.Airborne;
				}
				break;
			case _AirOpsCondition.OffloadingFuel:
				SetProxy(float_0);
				if (A2AR_Connections.Skip(0).Count() == 0 && !myUnit.IsRTB)
				{
					GetAircraft().Status = ActiveUnit._ActiveUnitStatus.Unassigned;
					Condition = _AirOpsCondition.Airborne;
				}
				break;
			case _AirOpsCondition.DeployingDippingSonar:
				if (myUnit.Status == ActiveUnit._ActiveUnitStatus.Unassigned && !myUnit.Navigator.HasPlottedCourse() && myUnit.AI.PrimaryTarget == null)
				{
					ConditionTimer = 120f;
					break;
				}
				if (myUnit.IsRTB)
				{
					Condition = _AirOpsCondition.RTB;
					break;
				}
				GetAircraft().AI.FollowAltitudePreset();
				if (!myUnit.Kinematics.DesiredAltitudeOverride && myUnit.DesiredAltitude == (float)Math.Round(45.720001220703125, 1))
				{
					ActiveUnit activeUnit = myUnit;
					Aircraft aircraft_ = GetAircraft();
					ActiveUnit activeUnit2 = myUnit;
					ActiveUnit activeUnit_;
					bool bool_ = activeUnit2.GetDesiredAltitude_UseTerrainFollowing(activeUnit_ = myUnit);
					float desiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_, ActiveUnit.Throttle.Cruise, ref bool_);
					activeUnit2.SetDesiredAltitude_UseTerrainFollowing(activeUnit_, bool_);
					activeUnit.DesiredAltitude = desiredAltitude;
				}
				Condition = _AirOpsCondition.Airborne;
				break;
			case _AirOpsCondition.EmergencyLanding:
			{
				if (!GetAircraft().Navigator.AboutToLand(float_0))
				{
					break;
				}
				AirFacility[] airFacilities_ReadOnly2 = ActualDestinationHost.AirFacilities_ReadOnly;
				AirFacility[] array2 = airFacilities_ReadOnly2;
				foreach (AirFacility airFacility2 in array2)
				{
					if (airFacility2.Status == PlatformComponent._ComponentStatus.Operational && airFacility2.QueryReader() && airFacility2.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success)
					{
						HostAirFacility = airFacility2;
						break;
					}
				}
				if (GetAircraft().Navigator.AboutToLand(float_0) && GetAircraft().Navigator != null && GetAircraft().Navigator.GetFlight() != null && GetAircraft().Navigator.GetFlight().TaskPool == null)
				{
					GetAircraft().Navigator.ClearFlight();
				}
				if (Information.IsNothing(HostAirFacility))
				{
					ActiveUnit actualDestinationHost = ActualDestinationHost;
					IEnumerable<AirFacility> enumerable = CreateProxy(actualDestinationHost);
					if (Information.IsNothing(enumerable) || enumerable.Count() <= 0)
					{
						break;
					}
					AirFacility[] airFacilities_ReadOnly3 = ActualDestinationHost.AirFacilities_ReadOnly;
					AirFacility[] array3 = airFacilities_ReadOnly3;
					foreach (AirFacility airFacility3 in array3)
					{
						if (airFacility3.Status == PlatformComponent._ComponentStatus.Operational && airFacility3.QueryReader() && (int)airFacility3.MaxAircraftSize >= (int)GetAircraft().Size)
						{
							TouchDown(airFacility3, bool_0: false);
							break;
						}
					}
				}
				else
				{
					TouchDown(null, bool_0: false);
				}
				break;
			}
			case _AirOpsCondition.TaxyingToFlightDeck:
				if (!PrepareProxy())
				{
					AttemptToMoveToFlightDeck();
				}
				break;
			case _AirOpsCondition.TransferringCargo:
				if (Information.IsNothing(GetAircraft().AI.PrimaryPickupTarget))
				{
					UnloadCargo();
				}
				else if ((GetAircraft().Loadout != null) & (GetAircraft().Loadout.Role == Loadout.LoadoutRole.SearchAndRescue || GetAircraft().Loadout.Role == Loadout.LoadoutRole.CombatSearchAndRescue))
				{
					ActiveUnit primaryPickupTarget = GetAircraft().AI.PrimaryPickupTarget;
					GetAircraft().AI.RemovePickupTarget(primaryPickupTarget.ObjectID);
					primaryPickupTarget.PickUpUnit = GetAircraft();
					primaryPickupTarget.IsBeingPickedUp = true;
					primaryPickupTarget.ParentScen.AddMessage(primaryPickupTarget.Name + " has been rescued!", primaryPickupTarget.Name + " rescued!", LoggedMessage.MessageType.SpecialMessage, 0, primaryPickupTarget.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(primaryPickupTarget.GetLongitude(), primaryPickupTarget.GetLatitude()));
					primaryPickupTarget.Destroy(bool_0: true, bool_1: false, bool_2: true, "Rescued unit removed");
					primaryPickupTarget.ParentScen.CheckForDestroyEvents(primaryPickupTarget, 0f);
				}
				else
				{
					PickupCargoFromSource(GetAircraft().AI.PrimaryPickupTarget);
				}
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				Condition = _AirOpsCondition.Airborne;
				ConditionTimer = 0f;
				break;
			case _AirOpsCondition.const_19:
			case _AirOpsCondition.BVRCrank:
			case _AirOpsCondition.Dogfight:
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100416", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private float FindProxy(Aircraft aircraft_0, GEnum6? nullable_0)
	{
		if (Information.IsNothing(nullable_0))
		{
			nullable_0 = GEnum6.Boom;
		}
		GEnum6? gEnum = nullable_0;
		byte? b = (byte?)gEnum;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
		{
			if ((int)aircraft_0.Size < 20)
			{
				return 12f;
			}
			return 22.6f;
		}
		b = (byte?)gEnum;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
		{
			return 11f;
		}
		b = (byte?)gEnum;
		if (!(b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			throw new NotImplementedException();
		}
		return 8.33f;
	}

	private void SetProxy(float float_0)
	{
		List<KeyValuePair<string, GEnum6>> list = new List<KeyValuePair<string, GEnum6>>();
		List<string> list2 = new List<string>();
		try
		{
			list.AddRange(A2AR_Connections);
			foreach (KeyValuePair<string, GEnum6> item in list)
			{
				if (Information.IsNothing(item.Key))
				{
					continue;
				}
				Aircraft Local_ReceiverAC = (Aircraft)GetAircraft().ParentScen.ActiveUnits[item.Key];
				float num = QueryProxy(Local_ReceiverAC);
				if (Local_ReceiverAC == GetAircraft())
				{
					continue;
				}
				if (Information.IsNothing(Local_ReceiverAC))
				{
					list2.Add(item.Key);
				}
				else if (Local_ReceiverAC.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
				{
					float num2 = FindProxy(Local_ReceiverAC, item.Value) * float_0 / num;
					if (Information.IsNothing(Local_ReceiverAC))
					{
						continue;
					}
					if (Local_ReceiverAC.IsGroupMember())
					{
						List<ActiveUnit> list3 = Local_ReceiverAC.GetParentGroup().Units.Values.Where((ActiveUnit theAC) => (Module_Unit.RangeToUnit_Horiz(theAC, Local_ReceiverAC) < 2f) & (theAC != GetAircraft())).OrderBy(delegate(ActiveUnit theAC)
						{
							double double_ = 0.0;
							double double_2 = 0.0;
							return theAC.FuelPercent(ref double_, ref double_2, bool_0: false);
						}).ToList();
						if (list3.Count <= 0)
						{
							Local_ReceiverAC.AirOps.DisconnectFromTanker();
							continue;
						}
						Aircraft aircraft = (Aircraft)list3[0];
						if (aircraft.Fuel_FreeLoad <= num2)
						{
							if (Local_ReceiverAC.Navigator.TankerFollowsMe_NumberOfWaypoints == 0)
							{
								Local_ReceiverAC.AirOps.DisconnectFromTanker();
							}
						}
						else
						{
							aircraft.Fuel_Add(num2, FuelRec._FuelType.AviationFuel);
							GetAircraft().Fuel_Subtract(num2, FuelRec._FuelType.AviationFuel);
						}
					}
					else if (Local_ReceiverAC.Fuel_FreeLoad <= num2)
					{
						if (Local_ReceiverAC.Navigator.TankerFollowsMe_NumberOfWaypoints == 0)
						{
							Local_ReceiverAC.AirOps.DisconnectFromTanker();
						}
					}
					else
					{
						Local_ReceiverAC.Fuel_Add(num2, FuelRec._FuelType.AviationFuel);
						GetAircraft().Fuel_Subtract(num2, FuelRec._FuelType.AviationFuel);
					}
				}
				else
				{
					Local_ReceiverAC.AirOps.DisconnectFromTanker();
				}
			}
			if (list2.Count <= 0)
			{
				return;
			}
			foreach (string item2 in list2)
			{
				ConcurrentDictionary<string, GEnum6> a2AR_Connections = A2AR_Connections;
				GEnum6 value = GEnum6.Drogue;
				a2AR_Connections.TryRemove(item2, out value);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100417", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DisconnectFromTanker()
	{
		try
		{
			Aircraft aircraft = null;
			object obj = tokenizerObserver;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				if (A2AR_Destination == null)
				{
					foreach (Aircraft item in GetAircraft().ParentScen.ActiveUnits_List.OfType<Aircraft>())
					{
						if (item != null && item.AirOps.A2AR_Connections.ContainsKey(GetAircraft().ObjectID))
						{
							aircraft = item;
							ConcurrentDictionary<string, GEnum6> a2AR_Connections = item.AirOps.A2AR_Connections;
							string objectID = GetAircraft().ObjectID;
							GEnum6 value = GEnum6.Drogue;
							a2AR_Connections.TryRemove(objectID, out value);
						}
					}
				}
				else
				{
					aircraft = A2AR_Destination;
					ConcurrentDictionary<string, GEnum6> a2AR_Connections2 = A2AR_Destination.AirOps.A2AR_Connections;
					string objectID2 = GetAircraft().ObjectID;
					GEnum6 value2 = GEnum6.Drogue;
					a2AR_Connections2.TryRemove(objectID2, out value2);
					ConcurrentDictionary<string, byte> refuellingQueue = A2AR_Destination.AirOps.RefuellingQueue;
					string objectID3 = GetAircraft().ObjectID;
					byte value3 = 0;
					refuellingQueue.TryRemove(objectID3, out value3);
					A2AR_Destination = null;
					if (EMCONInheritFromParentBeforeRefueling)
					{
						GetAircraft().Doctrine.EMCON_Inherits = true;
					}
					else
					{
						GetAircraft().Doctrine.SetEMCON_Radar(ActiveRadarDoctrineBeforeRefueling, GetAircraft().ParentScen);
					}
					EMCONInheritFromParentBeforeRefueling = false;
					ActiveRadarDoctrineBeforeRefueling = Doctrine.EMCONSettings._EMCONSetting.Passive;
				}
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
				}
			}
			_ = Debugger.IsAttached;
			if (aircraft == null)
			{
				return;
			}
			Aircraft_AirOps airOps = aircraft.AirOps;
			if (GetAircraft().Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				airOps.A2AR_NumberOfReceiverHookups.Add(new ActiveUnit_Struct(GetAircraft().GetUnitSide(), myUnit.ObjectID, GetAircraft().Name, GetAircraft().DBID));
			}
			if (GetAircraft().predicateVal == ActiveUnit._ActiveUnitStatus.RTB && (GetAircraft().comparatorVal == ActiveUnit._ActiveUnitFuelState.IsBingo || GetAircraft().comparatorVal == ActiveUnit._ActiveUnitFuelState.IsJoker))
			{
				GetAircraft().Status = ActiveUnit._ActiveUnitStatus.Unassigned;
			}
			else if (GetAircraft().predicateVal == ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
			{
				if (myUnit.AssignedMissionOrPackage() != null && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && !myUnit.AI.IsEscort)
				{
					GetAircraft().Status = GetAircraft().predicateVal;
				}
				else
				{
					if (myUnit.Navigator.HasFlightPlan)
					{
						GetAircraft().Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
					}
					else
					{
						GetAircraft().Status = ActiveUnit._ActiveUnitStatus.Tasked;
					}
					if (myUnit.Navigator.HasFlight)
					{
						myUnit.Navigator.GetFlight().SetStatus(myUnit.ParentScen, Mission._FlightStatus.Airborne);
					}
				}
			}
			else
			{
				GetAircraft().Status = GetAircraft().predicateVal;
			}
			Condition = _AirOpsCondition.Airborne;
			GetAircraft().FuelState = GetAircraft().GetIsBingoOrJoker(null, GetAircraft().Doctrine.GetBingoJoker(GetAircraft().ParentScen, bool_0: false, bool_1: true, bool_2: false, bool_3: false));
			if (aircraft != null && !aircraft.IsRTB && aircraft.AssignedMissionOrPackage() != null && aircraft.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Support)
			{
				SupportMission supportMission = (SupportMission)aircraft.AssignedMissionOrPackage();
				if (supportMission.A2AR_OneTankingCycleOnly && airOps.RefuellingQueue.Skip(0).Count() == 0 && airOps.A2AR_Connections.Skip(0).Count() == 0)
				{
					string text = "";
					if (Operators.CompareString(aircraft.Name, aircraft.UnitClass, TextCompare: false) != 0)
					{
						text = " (" + aircraft.UnitClass + ")";
					}
					aircraft.ParentScen.AddMessage("飞机" + aircraft.Name + text + "正在返回基地。任务 " + aircraft.AssignedMissionOrPackage().Name + "仅允许一个加油循环，加油机队列现在为空。", "加油操作", LoggedMessage.MessageType.AirOps, 5, aircraft.ObjectID, aircraft.GetUnitSide(), new Geopoint_Struct(aircraft.GetLongitude(), aircraft.GetLatitude()));
					airOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
				}
				if (supportMission.A2AR_MaxNumberOfReceiversPerTanker > 0 && !airOps.FillProxy(supportMission.A2AR_MaxNumberOfReceiversPerTanker, GetAircraft()) && airOps.RefuellingQueue.Skip(0).Count() == 0 && airOps.A2AR_Connections.Skip(0).Count() == 0)
				{
					if (aircraft.AssignedMissionOrPackage() != null && aircraft.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Support && !((SupportMission)aircraft.AssignedMissionOrPackage()).RTBUponCompletion)
					{
						return;
					}
					string text2 = "";
					if (Operators.CompareString(aircraft.Name, aircraft.UnitClass, TextCompare: false) != 0)
					{
						text2 = " (" + aircraft.UnitClass + ")";
					}
					aircraft.ParentScen.AddMessage("飞机" + aircraft.Name + text2 + "正在返回基地。任务 " + aircraft.AssignedMissionOrPackage().Name + " 设置允许最多" + Conversions.ToString(supportMission.A2AR_MaxNumberOfReceiversPerTanker) + "个的接收加油飞机（四舍五入到最近的编队），总共已进行了" + Conversions.ToString(airOps.A2AR_NumberOfReceiverHookups.Count) + "次加油。", "加油操作", LoggedMessage.MessageType.AirOps, 5, aircraft.ObjectID, aircraft.GetUnitSide(), new Geopoint_Struct(aircraft.GetLongitude(), aircraft.GetLatitude()));
					airOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
				}
			}
			if (myUnit.AssignedMissionOrPackage() != null && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				byte? b = (byte?)myUnit.Doctrine.GetUseReplenishment(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
				bool? flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
				if (((!flag) ?? flag).GetValueOrDefault() && myUnit.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne > 0 && !myUnit.IsGroupWingman())
				{
					Aircraft aircraft2 = GetAircraft();
					double double_ = 0.0;
					double double_2 = 0.0;
					if (aircraft2.FuelPercent(ref double_, ref double_2, bool_0: false) < (double)myUnit.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne / 100.0)
					{
						GeoPoint geoPoint_ = GetAircraft().AI.LoginClient();
						bool bool_ = false;
						bool bool_2 = false;
						ActiveUnit activeUnit_ = null;
						List<Mission> list_ = null;
						string string_ = "";
						bool bool_3 = false;
						if (AssetProxy(geoPoint_, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround, ref bool_2, bool_1: false, ref activeUnit_, ref list_, ref string_, ref bool_3, ref bool_))
						{
							return;
						}
					}
				}
			}
			List<Waypoint> list_2 = myUnit.Navigator.PlottedCourse.ToList();
			SwitchToNearestWaypoint(ref list_2, bool_0: false, bool_1: false);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100418", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool FillProxy(int int_0, Aircraft aircraft_0)
	{
		foreach (ActiveUnit_Struct a2AR_NumberOfReceiverHookup in A2AR_NumberOfReceiverHookups)
		{
			if (Operators.CompareString(a2AR_NumberOfReceiverHookup.ObjectId, aircraft_0.ObjectID, TextCompare: false) == 0)
			{
				return true;
			}
		}
		if (A2AR_NumberOfReceiverHookups.Contains(new ActiveUnit_Struct(aircraft_0.GetUnitSide(), aircraft_0.ObjectID, aircraft_0.Name, aircraft_0.DBID)))
		{
			return true;
		}
		return A2AR_NumberOfReceiverHookups.Count < int_0;
	}

	public void SwitchToNearestWaypoint(ref List<Waypoint> list_0, bool bool_0, bool bool_1)
	{
		try
		{
			if (list_0.Count <= 0)
			{
				return;
			}
			double num = double.MaxValue;
			double num2 = 0.0;
			int num3 = 0;
			Waypoint waypoint = null;
			if (!Information.IsNothing(myUnit.AssignedMissionOrPackage()) && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && !myUnit.AI.IsEscort)
			{
				if (bool_0 || GetAircraft().Navigator.IsOnAutoPlannerPlottedCourse_CruiseIngressRun || GetAircraft().Navigator.IsOnAutoPlannerPlottedCourse_CruiseEgressRun)
				{
					foreach (Waypoint item in list_0)
					{
						double num4 = Math2.CancelClass(myUnit.GetLatitude(), myUnit.GetLongitude(), item.Latitude, item.Longitude);
						if (num3 == 0)
						{
							num2 = num4;
							waypoint = item;
							num = num4;
						}
						else
						{
							num2 = Math2.CancelClass(item.Latitude, item.Longitude, waypoint.Latitude, waypoint.Longitude);
							if (num > num4 || num4 <= num2)
							{
								ActiveUnit_Navigator navigator = myUnit.Navigator;
								double latitude = myUnit.GetLatitude();
								double longitude = myUnit.GetLongitude();
								double latitude2 = item.Latitude;
								double longitude2 = item.Longitude;
								int int_ = 0;
								GeoPoint geoPoint_ = null;
								if (!navigator.PathLineIsInterrupted(latitude, longitude, latitude2, longitude2, bool_1: false, 0f, bool_2: false, null, bool_3: true, bool_4: true, bool_5: false, null, ref int_, ref geoPoint_))
								{
									waypoint = item;
									num = num4;
								}
							}
						}
						num3++;
						if ((!bool_0 && (item.Type == Waypoint.WaypointType.InitialPoint || item.Type == Waypoint.WaypointType.WeaponLaunch || item.Type == Waypoint.WaypointType.WeaponTarget || item.Type == Waypoint.WaypointType.Target || item.FlightFormation == Waypoint.Formation.Split || item.Creator == Waypoint.WaypointCreator.Navigator || (!Information.IsNothing(item.Time_Zulu) && item.Hold_Time > 0f))) || item.Type == Waypoint.WaypointType.LandingMarshal || item.Type == Waypoint.WaypointType.Land)
						{
							break;
						}
					}
				}
			}
			else if (!GetAircraft().Navigator.IsOnAutoPlannerPlottedCourse_StationIngressRun && !GetAircraft().Navigator.IsOnAutoPlannerPlottedCourse_StationEgressRun)
			{
				foreach (Waypoint item2 in list_0)
				{
					double num5 = Math2.CancelClass(myUnit.GetLatitude(), myUnit.GetLongitude(), item2.Latitude, item2.Longitude);
					if (num3 == 0)
					{
						num2 = num5;
						waypoint = item2;
						num = num5;
					}
					else
					{
						num2 = Math2.CancelClass(item2.Latitude, item2.Longitude, waypoint.Latitude, waypoint.Longitude);
						if (num > num5 || num5 <= num2)
						{
							ActiveUnit_Navigator navigator2 = myUnit.Navigator;
							double latitude3 = myUnit.GetLatitude();
							double longitude3 = myUnit.GetLongitude();
							double latitude4 = item2.Latitude;
							double longitude4 = item2.Longitude;
							int int_2 = 0;
							GeoPoint geoPoint_2 = null;
							if (!navigator2.PathLineIsInterrupted(latitude3, longitude3, latitude4, longitude4, bool_1: false, 0f, bool_2: false, null, bool_3: true, bool_4: true, bool_5: false, null, ref int_2, ref geoPoint_2))
							{
								waypoint = item2;
								num = num5;
							}
						}
					}
					num3++;
					if ((!bool_0 && (item2.IncludeReponse() || item2.FlightFormation == Waypoint.Formation.Split || item2.Creator == Waypoint.WaypointCreator.Navigator || (!Information.IsNothing(item2.Time_Zulu) && item2.Hold_Time > 0f))) || item2.Type == Waypoint.WaypointType.LandingMarshal || item2.Type == Waypoint.WaypointType.Land)
					{
						break;
					}
				}
			}
			else
			{
				foreach (Waypoint item3 in list_0)
				{
					double num6 = Math2.CancelClass(myUnit.GetLatitude(), myUnit.GetLongitude(), item3.Latitude, item3.Longitude);
					if (num3 == 0)
					{
						num2 = num6;
						waypoint = item3;
						num = num6;
					}
					else
					{
						num2 = Math2.CancelClass(item3.Latitude, item3.Longitude, waypoint.Latitude, waypoint.Longitude);
						if (num > num6 || num6 <= num2)
						{
							ActiveUnit_Navigator navigator3 = myUnit.Navigator;
							double latitude5 = myUnit.GetLatitude();
							double longitude5 = myUnit.GetLongitude();
							double latitude6 = item3.Latitude;
							double longitude6 = item3.Longitude;
							int int_3 = 0;
							GeoPoint geoPoint_3 = null;
							if (!navigator3.PathLineIsInterrupted(latitude5, longitude5, latitude6, longitude6, bool_1: false, 0f, bool_2: false, null, bool_3: true, bool_4: true, bool_5: false, null, ref int_3, ref geoPoint_3))
							{
								waypoint = item3;
								num = num6;
							}
						}
					}
					num3++;
					if ((!bool_0 && (item3.IncludeReponse() || item3.FlightFormation == Waypoint.Formation.Split || item3.Creator == Waypoint.WaypointCreator.Navigator || (!Information.IsNothing(item3.Time_Zulu) && item3.Hold_Time > 0f))) || item3.Type == Waypoint.WaypointType.LandingMarshal || item3.Type == Waypoint.WaypointType.Land)
					{
						break;
					}
				}
			}
			if (bool_1)
			{
				if (Information.IsNothing(waypoint) || num3 <= 1)
				{
					myUnit.AI.ReturnToBase(myUnit.ParentScen.GameResolution);
					return;
				}
			}
			else if (Information.IsNothing(waypoint) || num3 <= 1)
			{
				if (!myUnit.Navigator.IsOnAutoPlannerPlottedCourse || myUnit.Navigator.GetFlight() == null)
				{
					return;
				}
				int num7 = myUnit.Navigator.GetFlight().FlightPlan.Count() - 1;
				for (int i = 1; i <= num7; i++)
				{
					if (myUnit.Navigator.GetFlight().FlightPlan[i] == myUnit.Navigator.PlottedCourse[0])
					{
						Waypoint waypoint2 = myUnit.Navigator.GetFlight().FlightPlan[i - 1];
						if (waypoint2.Type == Waypoint.WaypointType.TakeOff)
						{
							myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB;
							myUnit.AI.ReturnToBase(myUnit.ParentScen.GameResolution);
						}
						else
						{
							myUnit.Navigator.ApplyWaypointSpeedAltToUnit(waypoint2);
							myUnit.Navigator.ApplyWaypointDoctrineToUnit(waypoint2);
						}
						break;
					}
				}
				return;
			}
			List<Waypoint> list = new List<Waypoint>();
			if (bool_1)
			{
				foreach (Waypoint item4 in list_0)
				{
					if (item4 != waypoint)
					{
						list.Add(item4);
						continue;
					}
					break;
				}
			}
			else
			{
				Waypoint[] plottedCourse = myUnit.Navigator.PlottedCourse;
				Waypoint[] array = plottedCourse;
				foreach (Waypoint waypoint3 in array)
				{
					if (waypoint3 == waypoint)
					{
						break;
					}
					list.Add(waypoint3);
				}
			}
			if (!bool_1 && !Information.IsNothing(myUnit.Navigator.GetFlight()) && !Information.IsNothing(myUnit.Navigator.GetFlight().FlightPlan) && list.Count == 0)
			{
				if (!myUnit.Navigator.IsOnAutoPlannerPlottedCourse)
				{
					return;
				}
				int num8 = myUnit.Navigator.GetFlight().FlightPlan.Count() - 1;
				for (int j = 1; j <= num8; j++)
				{
					if (myUnit.Navigator.GetFlight().FlightPlan[j] == myUnit.Navigator.PlottedCourse[0])
					{
						Waypoint waypoint_ = myUnit.Navigator.GetFlight().FlightPlan[j - 1];
						myUnit.Navigator.ApplyWaypointSpeedAltToUnit(waypoint_);
						myUnit.Navigator.ApplyWaypointDoctrineToUnit(waypoint_);
						break;
					}
				}
				return;
			}
			if (!bool_1)
			{
				using (List<Waypoint>.Enumerator enumerator2 = list.GetEnumerator())
				{
					while (enumerator2.MoveNext() && enumerator2.Current != waypoint)
					{
						Aircraft_Navigator navigator4 = GetAircraft().Navigator;
						bool bool_2 = true;
						bool bool_3 = false;
						navigator4.CheckIfReachedWaypoint(0f, ref bool_2, ref bool_3);
					}
					return;
				}
			}
			foreach (Waypoint item5 in list)
			{
				if (item5 != waypoint)
				{
					list_0.Remove(item5);
					continue;
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

	public void EnterLandingQueue(ActiveUnit activeUnit_0)
	{
		if (StopProxy(activeUnit_0, bool_0: true) == AirOpsAttemptResult.Success)
		{
			Condition = _AirOpsCondition.HoldingOnLandingQueue;
			if (!activeUnit_0.AirOps.LandingQueue_ReadOnly.Contains(GetAircraft()))
			{
				activeUnit_0.AirOps.LandingQueue_AddAircraft(GetAircraft());
			}
		}
	}

	public void AttemptToPark(bool bool_0 = true, bool bool_1 = true, bool bool_2 = false)
	{
		try
		{
			if (Information.IsNothing(CurrentHostUnit))
			{
				return;
			}
			if (Information.IsNothing(HostAirFacility) && !Information.IsNothing(GetAssignedHostUnit()))
			{
				GetAssignedHostUnit().AirOps.AddThisAircraft(GetAircraft(), bool_0: true);
			}
			if (bool_0)
			{
				switch (HostAirFacility.AirFacType)
				{
				case AirFacility._AirFacType.Runway:
				case AirFacility._AirFacType.RunwayWithArrest:
				case AirFacility._AirFacType.Catapult:
				case AirFacility._AirFacType.SkiJump:
				case AirFacility._AirFacType.CarrierArrestingGear:
				case AirFacility._AirFacType.Pad:
				case AirFacility._AirFacType.PadWithHaulDown:
				{
					bool flag = false;
					for (int j = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; j >= 0; j += -1)
					{
						AirFacility airFacility4 = CurrentHostUnit.AirFacilities_ReadOnly[j];
						if (airFacility4.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility4.AirFacType == AirFacility._AirFacType.Hangar && airFacility4.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						if (HostAirFacility.ParentPlatform.IsShip)
						{
							Ship._ShipCategory category = ((Ship)HostAirFacility.ParentPlatform).Category;
							if (category != Ship._ShipCategory.AviationShip && category != Ship._ShipCategory.SurfaceCombatantAviation && category != Ship._ShipCategory.MobileOffshoreBase)
							{
								for (int k = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; k >= 0; k += -1)
								{
									AirFacility airFacility5 = CurrentHostUnit.AirFacilities_ReadOnly[k];
									if (airFacility5.QueryReader() && airFacility5.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success)
									{
										InsertProxy(airFacility5, bool_1, bool_2);
										return;
									}
								}
								for (int l = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; l >= 0; l += -1)
								{
									AirFacility airFacility6 = CurrentHostUnit.AirFacilities_ReadOnly[l];
									if (airFacility6.AirFacType == AirFacility._AirFacType.OpenParking || (airFacility6.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility6.AirFacType == AirFacility._AirFacType.Hangar))
									{
										InsertProxy(airFacility6, bool_1, bool_2);
										return;
									}
								}
							}
						}
						IEnumerable<AirFacility> enumerable = from theAF in GetRunwayAccessPointsInOperationOnMe_myUnitSize(CurrentHostUnit)
							orderby theAF.MaxAircraftSize
							select theAF;
						if (!Information.IsNothing(enumerable) && enumerable.Count() > 0)
						{
							IEnumerable<AirFacility> enumerable2 = MapClient(false, GetAircraft(), CurrentHostUnit, enumerable);
							if (!Information.IsNothing(enumerable2) && enumerable2.Count() > 0)
							{
								VerifyProxy(enumerable2.ElementAtOrDefault(0), (TaxyingFacilityType)1);
								break;
							}
							int num10 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
							AirFacility airFacility7;
							while (true)
							{
								if (num10 >= 0)
								{
									airFacility7 = CurrentHostUnit.AirFacilities_ReadOnly[num10];
									if (airFacility7.AirFacType == AirFacility._AirFacType.OpenParking && airFacility7.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success)
									{
										break;
									}
									num10 += -1;
									continue;
								}
								int num11 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
								while (true)
								{
									if (num11 >= 0)
									{
										airFacility7 = CurrentHostUnit.AirFacilities_ReadOnly[num11];
										if (airFacility7.AirFacType == AirFacility._AirFacType.OpenParking || (airFacility7.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility7.AirFacType == AirFacility._AirFacType.Hangar))
										{
											break;
										}
										num11 += -1;
										continue;
									}
									ConditionTimer = 5f;
									CurrentHostUnit.AirOps.MakeWayForLandings();
									return;
								}
								InsertProxy(airFacility7, bool_1, bool_2);
								return;
							}
							InsertProxy(airFacility7, bool_1, bool_2);
						}
						else
						{
							if (!HostAirFacility.ParentPlatform.IsShip)
							{
								break;
							}
							int num12 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
							AirFacility airFacility8;
							while (true)
							{
								if (num12 >= 0)
								{
									airFacility8 = CurrentHostUnit.AirFacilities_ReadOnly[num12];
									if (airFacility8.AirFacType == AirFacility._AirFacType.OpenParking && airFacility8.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success)
									{
										break;
									}
									num12 += -1;
									continue;
								}
								int num13 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
								while (true)
								{
									if (num13 >= 0)
									{
										airFacility8 = CurrentHostUnit.AirFacilities_ReadOnly[num13];
										if (airFacility8.AirFacType == AirFacility._AirFacType.OpenParking || (airFacility8.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility8.AirFacType == AirFacility._AirFacType.Hangar))
										{
											break;
										}
										num13 += -1;
										continue;
									}
									ConditionTimer = 5f;
									return;
								}
								InsertProxy(airFacility8, bool_1, bool_2);
								return;
							}
							InsertProxy(airFacility8, bool_1, bool_2);
						}
						break;
					}
					int num14 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
					AirFacility airFacility9;
					while (true)
					{
						if (num14 >= 0)
						{
							airFacility9 = CurrentHostUnit.AirFacilities_ReadOnly[num14];
							if (airFacility9.AirFacType == AirFacility._AirFacType.OpenParking && airFacility9.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success)
							{
								break;
							}
							num14 += -1;
							continue;
						}
						int num2 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
						while (true)
						{
							if (num2 >= 0)
							{
								airFacility9 = CurrentHostUnit.AirFacilities_ReadOnly[num2];
								if (airFacility9.AirFacType == AirFacility._AirFacType.OpenParking || (airFacility9.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility9.AirFacType == AirFacility._AirFacType.Hangar && (int)GetAircraft().Size <= (int)airFacility9.MaxAircraftSize))
								{
									break;
								}
								num2 += -1;
								continue;
							}
							if (GetAircraft().IsHelicopter && HostAirFacility.PublishReader())
							{
								Condition = _AirOpsCondition.Parked;
								GetAircraft().Status = ActiveUnit._ActiveUnitStatus.Unassigned;
							}
							else
							{
								ConditionTimer = 5f;
							}
							return;
						}
						InsertProxy(airFacility9, bool_1, bool_2);
						return;
					}
					InsertProxy(airFacility9, bool_1, bool_2);
					break;
				}
				case AirFacility._AirFacType.const_13:
				{
					if (bool_2)
					{
						if (!bool_1)
						{
							Condition = _AirOpsCondition.Readying;
						}
						if (myUnit.GetParentGroup() != null)
						{
							myUnit.SetParentGroup(bool_0: false, null);
						}
						break;
					}
					AirFacility airFacility3 = null;
					for (int num9 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; num9 >= 0; num9 += -1)
					{
						airFacility3 = CurrentHostUnit.AirFacilities_ReadOnly[num9];
						if (airFacility3.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility3.AirFacType == AirFacility._AirFacType.Hangar && airFacility3.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success)
						{
							InsertProxy(airFacility3, bool_1, bool_2);
							return;
						}
					}
					if (airFacility3 == null)
					{
						AirFacility.AddUAV_Class1_Hanger(CurrentHostUnit);
						for (int i = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; i >= 0; i += -1)
						{
							airFacility3 = CurrentHostUnit.AirFacilities_ReadOnly[i];
							if (airFacility3.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility3.AirFacType == AirFacility._AirFacType.Hangar && airFacility3.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success)
							{
								InsertProxy(airFacility3, bool_1, bool_2);
								return;
							}
						}
					}
					if (ConditionTimer == 0f)
					{
						Condition = _AirOpsCondition.Parked;
						if (myUnit.GetParentGroup() != null)
						{
							myUnit.SetParentGroup(bool_0: false, null);
						}
					}
					break;
				}
				case AirFacility._AirFacType.Hangar:
					if (bool_2)
					{
						if (!bool_1)
						{
							Condition = _AirOpsCondition.Readying;
						}
						if (myUnit.GetParentGroup() != null)
						{
							myUnit.SetParentGroup(bool_0: false, null);
						}
					}
					else if (ConditionTimer == 0f)
					{
						Condition = _AirOpsCondition.Parked;
						if (myUnit.GetParentGroup() != null)
						{
							myUnit.SetParentGroup(bool_0: false, null);
						}
					}
					break;
				case AirFacility._AirFacType.OpenParking:
					if (bool_2)
					{
						if (!bool_1)
						{
							Condition = _AirOpsCondition.Readying;
						}
						if (myUnit.GetParentGroup() != null)
						{
							myUnit.SetParentGroup(bool_0: false, null);
						}
					}
					else if (Condition == _AirOpsCondition.Landing_PostTouchdown)
					{
						int num3 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
						AirFacility airFacility10;
						while (true)
						{
							if (num3 >= 0)
							{
								airFacility10 = CurrentHostUnit.AirFacilities_ReadOnly[num3];
								if (airFacility10.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility10.AirFacType == AirFacility._AirFacType.Hangar && airFacility10.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success)
								{
									break;
								}
								num3 += -1;
								continue;
							}
							Condition = _AirOpsCondition.Readying;
							Aircraft aircraft_;
							if (Information.IsNothing(GetAircraft().Loadout))
							{
								Condition = _AirOpsCondition.Readying;
								ConditionTimer = 1800f;
							}
							else
							{
								ActiveUnit_AirOps airOps = CurrentHostUnit.AirOps;
								aircraft_ = GetAircraft();
								airOps.OutfitAC(ref aircraft_, GetAircraft().Loadout.DBID, GetAircraft().Loadout.DBID, bool_0: false, GetAircraft().Loadout.NoOptionalWeapons, !myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines), bool_3: false, bool_4: true);
							}
							ActiveUnit_AirOps airOps2 = CurrentHostUnit.AirOps;
							aircraft_ = GetAircraft();
							airOps2.RefuelAC_Simple(ref aircraft_);
							ActiveUnit_AirOps airOps3 = CurrentHostUnit.AirOps;
							aircraft_ = GetAircraft();
							airOps3.RepairAC(ref aircraft_);
							return;
						}
						InsertProxy(airFacility10, bool_1, bool_2);
					}
					else if (ConditionTimer == 0f)
					{
						Condition = _AirOpsCondition.Parked;
						if (myUnit.GetParentGroup() != null)
						{
							myUnit.SetParentGroup(bool_0: false, null);
						}
					}
					break;
				case AirFacility._AirFacType.RunwayGrade_Taxiway:
				case AirFacility._AirFacType.RunwayAccessPoint:
				case AirFacility._AirFacType.Elevator:
				{
					int num = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
					AirFacility airFacility;
					while (true)
					{
						if (num >= 0)
						{
							airFacility = CurrentHostUnit.AirFacilities_ReadOnly[num];
							if (airFacility.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility.AirFacType == AirFacility._AirFacType.Hangar && airFacility.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success)
							{
								break;
							}
							num += -1;
							continue;
						}
						int num7 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
						while (true)
						{
							if (num7 >= 0)
							{
								airFacility = CurrentHostUnit.AirFacilities_ReadOnly[num7];
								if (airFacility.AirFacType == AirFacility._AirFacType.OpenParking && airFacility.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success)
								{
									break;
								}
								num7 += -1;
								continue;
							}
							int num8 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
							while (true)
							{
								if (num8 >= 0)
								{
									airFacility = CurrentHostUnit.AirFacilities_ReadOnly[num8];
									if ((airFacility.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility.AirFacType == AirFacility._AirFacType.Hangar) || airFacility.AirFacType == AirFacility._AirFacType.OpenParking)
									{
										break;
									}
									num8 += -1;
									continue;
								}
								ConditionTimer = 5f;
								return;
							}
							InsertProxy(airFacility, bool_1, bool_2);
							return;
						}
						InsertProxy(airFacility, bool_1, bool_2);
						return;
					}
					InsertProxy(airFacility, bool_1, bool_2);
					break;
				}
				}
				return;
			}
			int num4 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
			AirFacility airFacility2;
			while (true)
			{
				if (num4 >= 0)
				{
					airFacility2 = CurrentHostUnit.AirFacilities_ReadOnly[num4];
					if (airFacility2.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility2.AirFacType == AirFacility._AirFacType.Hangar && airFacility2.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success)
					{
						break;
					}
					num4 += -1;
					continue;
				}
				int num5 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
				while (true)
				{
					if (num5 >= 0)
					{
						airFacility2 = CurrentHostUnit.AirFacilities_ReadOnly[num5];
						if (airFacility2.AirFacType == AirFacility._AirFacType.OpenParking && airFacility2.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success)
						{
							break;
						}
						num5 += -1;
						continue;
					}
					int num6 = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1;
					while (true)
					{
						if (num6 >= 0)
						{
							airFacility2 = CurrentHostUnit.AirFacilities_ReadOnly[num6];
							if ((airFacility2.Status != PlatformComponent._ComponentStatus.Destroyed && airFacility2.AirFacType == AirFacility._AirFacType.Hangar) || airFacility2.AirFacType == AirFacility._AirFacType.OpenParking)
							{
								break;
							}
							num6 += -1;
							continue;
						}
						if (GetAircraft().IsHelicopter && HostAirFacility.PublishReader())
						{
							Condition = _AirOpsCondition.Parked;
							GetAircraft().Status = ActiveUnit._ActiveUnitStatus.Unassigned;
						}
						else
						{
							ConditionTimer = 5f;
						}
						return;
					}
					InsertProxy(airFacility2, bool_1, bool_2);
					return;
				}
				InsertProxy(airFacility2, bool_1, bool_2);
				return;
			}
			InsertProxy(airFacility2, bool_1, bool_2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101191", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void UpdateQuickTurnaroundSettings_TakeOff(ref Aircraft aircraft_0)
	{
		if (aircraft_0.AirOps.QuickTurnaround_Enabled)
		{
			QuickTurnaround_SortiesFlown++;
		}
		else
		{
			QuickTurnaround_SortiesFlown = 0;
		}
	}

	public void UpdateQuickTurnaroundSettings_Landing(ref Aircraft aircraft_0)
	{
		QuickTurnaround_AirborneTime_Flown += aircraft_0.AirborneTime;
	}

	public void UpdateQuickTurnaroundSettings_StepDown(ref Aircraft_AirOps aircraft_AirOps_0, ref Aircraft aircraft_0)
	{
		if (!Information.IsNothing(aircraft_0.Loadout) && aircraft_AirOps_0.ConditionTimer < (float)(aircraft_AirOps_0.QuickTurnaround_TimePentalty * 60))
		{
			aircraft_AirOps_0.ConditionTimer = aircraft_AirOps_0.QuickTurnaround_TimePentalty * 60;
		}
		aircraft_AirOps_0.QuickTurnaround_SortiesFlown = 0;
		aircraft_AirOps_0.QuickTurnaround_TimePentalty = 0;
		aircraft_AirOps_0.QuickTurnaround_AirborneTime_Flown = 0f;
		aircraft_AirOps_0.QuickTurnaround_AirborneTime_SortieAverage = 0f;
	}

	public void UpdateQuickTurnaroundSettings_ContinueFlying(ref Aircraft_AirOps aircraft_AirOps_0, ref Aircraft aircraft_0)
	{
		if (!Information.IsNothing(aircraft_0.Loadout))
		{
			aircraft_AirOps_0.ConditionTimer = aircraft_0.Loadout.QuickTurnaround_ReadyTime * 60;
		}
		aircraft_AirOps_0.QuickTurnaround_AirborneTime_SortieAverage = aircraft_AirOps_0.QuickTurnaround_AirborneTime_Flown / (float)aircraft_AirOps_0.QuickTurnaround_SortiesFlown;
		if (float.IsNaN(aircraft_AirOps_0.QuickTurnaround_AirborneTime_SortieAverage))
		{
			aircraft_AirOps_0.QuickTurnaround_AirborneTime_SortieAverage = 0f;
		}
	}

	public void UpdateQuickTurnaroundSettings_Reset(ref Aircraft_AirOps aircraft_AirOps_0)
	{
		if (aircraft_AirOps_0.QuickTurnaround_Enabled)
		{
			aircraft_AirOps_0.QuickTurnaround_Enabled = false;
			aircraft_AirOps_0.QuickTurnaround_SortiesFlown = 0;
			aircraft_AirOps_0.QuickTurnaround_TimePentalty = 0;
			aircraft_AirOps_0.QuickTurnaround_AirborneTime_Flown = 0f;
			aircraft_AirOps_0.QuickTurnaround_AirborneTime_SortieAverage = 0f;
		}
	}

	public void AttemptToMoveToFlightDeck()
	{
		try
		{
			if (Information.IsNothing(HostAirFacility) || Information.IsNothing(HostAirFacility.ParentPlatform))
			{
				return;
			}
			bool flag = false;
			if (!HostAirFacility.ParentPlatform.IsShip)
			{
				flag = true;
			}
			if (!flag)
			{
				Ship._ShipCategory category = ((Ship)HostAirFacility.ParentPlatform).Category;
				if (category != Ship._ShipCategory.AviationShip && category != Ship._ShipCategory.SurfaceCombatantAviation && category != Ship._ShipCategory.MobileOffshoreBase)
				{
					flag = true;
				}
			}
			if (!flag && HostAirFacility.AirFacType == AirFacility._AirFacType.OpenParking)
			{
				flag = true;
			}
			if (flag)
			{
				if (Condition == _AirOpsCondition.Parked)
				{
					return;
				}
				Condition = _AirOpsCondition.Parked;
				if (!Information.IsNothing(CurrentHostUnit))
				{
					string text = "";
					if (Operators.CompareString(GetAircraft().Name, GetAircraft().UnitClass, TextCompare: false) != 0)
					{
						text = " (" + GetAircraft().UnitClass + ")";
					}
					GetAircraft().AddMessage(GetAircraft().Name + text + "准备好了" + CurrentHostUnit.Name, GetAircraft().Name + " 已就绪", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(CurrentHostUnit.GetLongitude(), CurrentHostUnit.GetLatitude()));
				}
			}
			else if (Information.IsNothing(GetAircraft().Loadout))
			{
				if (Condition == _AirOpsCondition.Parked)
				{
					return;
				}
				Condition = _AirOpsCondition.Parked;
				if (!Information.IsNothing(CurrentHostUnit))
				{
					string text2 = "";
					if (Operators.CompareString(GetAircraft().Name, GetAircraft().UnitClass, TextCompare: false) != 0)
					{
						text2 = " (" + GetAircraft().UnitClass + ")";
					}
					GetAircraft().AddMessage(GetAircraft().Name + text2 + "准备好了" + CurrentHostUnit.Name, GetAircraft().Name + " 已就绪", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(CurrentHostUnit.GetLongitude(), CurrentHostUnit.GetLatitude()));
				}
			}
			else if (GetAircraft().Loadout.Role != Loadout.LoadoutRole.Reserve && GetAircraft().Loadout.Role != Loadout.LoadoutRole.Unavailable)
			{
				switch (HostAirFacility.AirFacType)
				{
				case AirFacility._AirFacType.Elevator:
				{
					for (int k = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; k >= 0; k += -1)
					{
						AirFacility airFacility3 = CurrentHostUnit.AirFacilities_ReadOnly[k];
						if (airFacility3.AirFacType == AirFacility._AirFacType.OpenParking && airFacility3.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success && airFacility3.Status != PlatformComponent._ComponentStatus.Destroyed && !((double)airFacility3.ParkingSpace_Free / (double)(int)airFacility3.MaxAircraftSize <= 4.0))
						{
							InsertProxy(airFacility3, bool_0: false, bool_1: false);
							Condition = _AirOpsCondition.Parked;
							return;
						}
					}
					for (int l = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; l >= 0; l += -1)
					{
						AirFacility airFacility4 = CurrentHostUnit.AirFacilities_ReadOnly[l];
						if (airFacility4.AirFacType == AirFacility._AirFacType.Hangar && airFacility4.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success)
						{
							InsertProxy(airFacility4, bool_0: false, bool_1: false);
							Condition = _AirOpsCondition.Parked;
							return;
						}
					}
					break;
				}
				case AirFacility._AirFacType.Hangar:
				{
					if (!Information.IsNothing(CurrentHostUnit.AirOps.LandingQueue_ReadOnly) && !Information.IsNothing(CurrentHostUnit.AirOps.ResetClient()))
					{
						List<AirFacility> list = CurrentHostUnit.AirFacilities_ReadOnly.Where((AirFacility theAF) => theAF.ResetReader() && theAF.Status != PlatformComponent._ComponentStatus.Destroyed).ToList();
						List<AirFacility> list2 = list.Where((AirFacility theAF) => theAF.HostedAircraft.Count >= theAF.Capacity).ToList();
						if (((CurrentHostUnit.AirOps.LandingQueue_ReadOnly.Count() > 0 || CurrentHostUnit.AirOps.ResetClient().Count > 0) && list.Count - list2.Count <= 2) || (!Information.IsNothing(CurrentHostUnit.AirOps.HaveAircraftOnTouchdown()) && list.Count - list2.Count <= 2))
						{
							break;
						}
					}
					int num = 0;
					for (int i = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; i >= 0; i += -1)
					{
						AirFacility airFacility = CurrentHostUnit.AirFacilities_ReadOnly[i];
						if (airFacility.AirFacType != AirFacility._AirFacType.Elevator)
						{
							continue;
						}
						foreach (Aircraft value in airFacility.HostedAircraft.Values)
						{
							if (value.AirOps.Condition == _AirOpsCondition.TaxyingToFlightDeck)
							{
								num += (int)value.Size;
							}
						}
					}
					bool flag2 = false;
					for (int j = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; j >= 0; j += -1)
					{
						AirFacility airFacility2 = CurrentHostUnit.AirFacilities_ReadOnly[j];
						if (airFacility2.AirFacType == AirFacility._AirFacType.OpenParking && airFacility2.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success && airFacility2.Status != PlatformComponent._ComponentStatus.Destroyed && !((double)airFacility2.ParkingSpace_Free / (double)(int)airFacility2.MaxAircraftSize <= (double)(4 + num)))
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						break;
					}
					IEnumerable<AirFacility> enumerable = from theAF in GetRunwayAccessPointsInOperationOnMe_myUnitSize(CurrentHostUnit)
						orderby theAF.MaxAircraftSize
						select theAF;
					if (Information.IsNothing(enumerable) || enumerable.Count() <= 0)
					{
						break;
					}
					IEnumerable<AirFacility> enumerable2 = MapClient(null, GetAircraft(), CurrentHostUnit, enumerable);
					if (Information.IsNothing(enumerable2) || enumerable2.Count() <= 0)
					{
						break;
					}
					if (Condition != _AirOpsCondition.Parked && !Information.IsNothing(CurrentHostUnit))
					{
						string text3 = "";
						if (Operators.CompareString(GetAircraft().Name, GetAircraft().UnitClass, TextCompare: false) != 0)
						{
							text3 = " (" + GetAircraft().UnitClass + ")";
						}
						GetAircraft().AddMessage(GetAircraft().Name + text3 + "准备好了" + CurrentHostUnit.Name + "，搬到飞行甲板......", GetAircraft().Name + " 已就绪", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(CurrentHostUnit.GetLongitude(), CurrentHostUnit.GetLatitude()));
					}
					VerifyProxy(enumerable2.ElementAtOrDefault(0), (TaxyingFacilityType)2);
					return;
				}
				}
				if (Condition == _AirOpsCondition.Parked)
				{
					return;
				}
				Condition = _AirOpsCondition.Parked;
				if (!Information.IsNothing(CurrentHostUnit))
				{
					string text4 = "";
					if (Operators.CompareString(GetAircraft().Name, GetAircraft().UnitClass, TextCompare: false) != 0)
					{
						text4 = " (" + GetAircraft().UnitClass + ")";
					}
					GetAircraft().AddMessage(GetAircraft().Name + text4 + "准备好了" + CurrentHostUnit.Name, GetAircraft().Name + " 已就绪", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(CurrentHostUnit.GetLongitude(), CurrentHostUnit.GetLatitude()));
				}
			}
			else if (Condition != _AirOpsCondition.Parked)
			{
				Condition = _AirOpsCondition.Parked;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100419", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CalculateProxy()
	{
		Condition = _AirOpsCondition.Airborne;
		ConditionTimer = 1f;
	}

	private void PopProxy()
	{
		try
		{
			ActiveUnit actualDestinationHost = ActualDestinationHost;
			if (Information.IsNothing(actualDestinationHost))
			{
				CalculateProxy();
			}
			else
			{
				if (actualDestinationHost.AirOps.LandingQueue_ReadOnly.Count() != 0 && actualDestinationHost.AirOps.LandingQueue_ReadOnly[0] != myUnit)
				{
					return;
				}
				IEnumerable<AirFacility> enumerable = from theAirFac in RunwaysInOperationOnMe_myUnitSize(GetAircraft(), bool_0: false, bool_1: true, ActualDestinationHost, GetAircraft().CanLandVertically)
					orderby theAirFac.MaxAircraftSize, theAirFac.EffectiveRunwaySize
					select theAirFac;
				IEnumerable<AirFacility> enumerable2 = null;
				if (!Information.IsNothing(enumerable) && enumerable.Count() > 0)
				{
					enumerable2 = SortClient(bool_0: false, bool_1: false, GetAircraft(), ActualDestinationHost, GetAircraft().CanLandVertically, enumerable);
				}
				if (enumerable2 != null && enumerable2.Count() != 0)
				{
					using (IEnumerator<AirFacility> enumerator = enumerable.GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							AirFacility current = enumerator.Current;
							InstantiateProxy(current);
							return;
						}
					}
					ConditionTimer = 10f;
				}
				else if (StopProxy(actualDestinationHost, bool_0: true) == AirOpsAttemptResult.Success)
				{
					ConditionTimer = 5f;
				}
				else
				{
					myUnit.AddMessage(myUnit.Name + " is not able to land on " + actualDestinationHost.Name, myUnit.Name + " is not able to land ", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					Condition = _AirOpsCondition.Airborne;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100420", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void InstantiateProxy(AirFacility airFacility_0)
	{
		ActualDestinationHost.AirOps.LandingQueue_RemoveAircraft(GetAircraft());
		Condition = _AirOpsCondition.Landing_PreTouchdown;
		ConditionTimer = 120f;
	}

	public void AttemptToFinishLanding(float float_0)
	{
		try
		{
			GetAircraft().Navigator.ClearFlight();
			ActiveUnit actualDestinationHost = ActualDestinationHost;
			IEnumerable<AirFacility> enumerable = CreateProxy(actualDestinationHost);
			bool flag = actualDestinationHost.AirOps.CanHostThisAircraft(GetAircraft()) == AirOpsAttemptResult.Success;
			if (Information.IsNothing(enumerable))
			{
				Aircraft_Navigator navigator = GetAircraft().Navigator;
				float float_ = myUnit.Kinematics.GetMaximumSpeed(GetAircraft().GetCurrentAltitude(), ActiveUnit.Throttle.Cruise, bool_0: false);
				Aircraft_Navigator navigator2 = GetAircraft().Navigator;
				bool bool_ = false;
				float float_2 = navigator2.OrderProxy(ref bool_);
				Aircraft aircraft = GetAircraft();
				ActiveUnit aircraft2;
				bool bool_2 = aircraft.GetDesiredAltitude_UseTerrainFollowing(aircraft2 = GetAircraft());
				navigator.HeadToLandingAssemblyPoint(float_0, actualDestinationHost, float_, float_2, ref bool_2);
				aircraft.SetDesiredAltitude_UseTerrainFollowing(aircraft2, bool_2);
			}
			else if (flag)
			{
				TouchDown(enumerable.ElementAtOrDefault(0));
			}
			else
			{
				GetAircraft().AI.ReturnToBase(float_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100421", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private IEnumerable<AirFacility> CreateProxy(ActiveUnit activeUnit_0)
	{
		if (activeUnit_0.AirFacilities_ReadOnly.Length == 0)
		{
			return null;
		}
		IEnumerable<AirFacility> result = null;
		try
		{
			IEnumerable<AirFacility> enumerable = from theAirFac in RunwaysInOperationOnMe_myUnitSize(GetAircraft(), bool_0: false, bool_1: false, activeUnit_0, GetAircraft().CanLandVertically)
				orderby theAirFac.MaxAircraftSize, theAirFac.EffectiveRunwaySize
				select theAirFac;
			IEnumerable<AirFacility> enumerable2 = null;
			if (!Information.IsNothing(enumerable) && enumerable.Count() > 0)
			{
				enumerable2 = SortClient(bool_0: false, bool_1: true, GetAircraft(), activeUnit_0, GetAircraft().CanLandVertically, enumerable);
			}
			if (!Information.IsNothing(enumerable2) && enumerable2.Count() > 0)
			{
				result = enumerable2;
				return result;
			}
			result = null;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100422", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public void TouchDown(AirFacility airFacility_0, bool bool_0 = true)
	{
		try
		{
			if (!GetAircraft().AirOps.InterruptProxy())
			{
				int num = GameGeneral.LockRandom_0.Next(100);
				if (num < 50)
				{
					GetAircraft().SetDamagePts(bool_1: false, null, GetAircraft().GetDamagePts() - 5f);
					if (num < 20)
					{
						if (num < 5)
						{
							if (airFacility_0.DamageSeverity == PlatformComponent._DamageSeverityFactor.Heavy)
							{
								airFacility_0.Destroy(airFacility_0.ParentPlatform.GetUnitSide(), bool_0: false, bool_1: false);
							}
							else
							{
								airFacility_0.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
							}
							myUnit.AddMessage("Crashed on " + airFacility_0.Name + " during landing due to athospheric condition", "Crashed during landing due to athmosperic condition ", LoggedMessage.MessageType.UnitLost, 1, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
							GetAircraft().Destroy(bool_1: false, bool_2: false, bool_3: true, "Crashed on " + airFacility_0.Name + " during landing due to athospheric condition", "Crashed on " + airFacility_0.Name + " during landing due to athospheric condition");
						}
						else
						{
							myUnit.AddMessage("Crashed on " + airFacility_0.Name + " during landing due to athospheric condition", "Crashed during landing due to athmosperic condition ", LoggedMessage.MessageType.UnitLost, 1, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
							GetAircraft().Destroy(bool_1: false, bool_2: false, bool_3: true, "Crashed during landing due to athospheric condition", "Crashed during landing due to athospheric condition");
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1004265467483", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (GetAircraft().Navigator != null && GetAircraft().Navigator.GetFlight() != null && GetAircraft().Navigator.GetFlight().TaskPool == null)
			{
				GetAircraft().Navigator.ClearFlight();
			}
			Mission mission_ = myUnit.AssignedMissionOrPackage();
			GetAircraft().Navigator.ClearFlight();
			Aircraft aircraft_ = GetAircraft();
			UpdateQuickTurnaroundSettings_Landing(ref aircraft_);
			GetAircraft().Navigator.SupportMission_NextRefPoint = null;
			myUnit.WeaponState = ActiveUnit._ActiveUnitWeaponState.None;
			myUnit.FuelState = ActiveUnit._ActiveUnitFuelState.None;
			myUnit.AI.HasCaughtUpWithGroup = false;
			A2AR_NumberOfReceiverHookups.Add(new ActiveUnit_Struct());
			if (bool_0)
			{
				HostAirFacility = airFacility_0;
				Condition = _AirOpsCondition.Landing_PostTouchdown;
				switch (GetAircraft().VisualSizeClass)
				{
				case GlobalVariables.TargetVisualSizeClass.Stealthy:
					ConditionTimer = 20f;
					break;
				case GlobalVariables.TargetVisualSizeClass.VSmall:
					ConditionTimer = 30f;
					break;
				case GlobalVariables.TargetVisualSizeClass.Small:
					ConditionTimer = 30f;
					break;
				case GlobalVariables.TargetVisualSizeClass.Medium:
					ConditionTimer = 30f;
					break;
				case GlobalVariables.TargetVisualSizeClass.Large:
					ConditionTimer = 30f;
					break;
				case GlobalVariables.TargetVisualSizeClass.VLarge:
					ConditionTimer = 30f;
					break;
				}
				ReadProxy(mission_);
			}
			else
			{
				Condition = _AirOpsCondition.Landing_PostTouchdown;
				if (!Information.IsNothing(airFacility_0) && Information.IsNothing(HostAirFacility))
				{
					HostAirFacility = airFacility_0;
				}
				ReadProxy(mission_);
				AttemptToPark(bool_0: false);
			}
			writerObserver?.Invoke(GetAircraft());
			if (!Information.IsNothing(myUnit.AssignedMissionOrPackage()))
			{
				if (myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Ferry)
				{
					switch (((FerryMission)myUnit.AssignedMissionOrPackage()).Behavior)
					{
					case FerryMission.FerryMissionBehavior.Random:
						PickNewAssignedHost_RandomWithinRange(GetAssignedHostUnit());
						break;
					case FerryMission.FerryMissionBehavior.OneWay:
					{
						ActiveUnit activeUnit = myUnit;
						Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
						activeUnit.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
						SetAssignedHostUnit(bool_0: false, CurrentHostUnit);
						break;
					}
					}
				}
				if (!Information.IsNothing(myUnit.AssignedMissionOrPackage()) && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Support && ((SupportMission)myUnit.AssignedMissionOrPackage()).OneTimeOnly)
				{
					ActiveUnit activeUnit2 = myUnit;
					Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_2 = Mission.MissionAssignmentAttemptResult.None;
					activeUnit2.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: true, ref missionAssignmentAttemptResult_2);
				}
			}
			if (myUnit.IsGroupMember() && myUnit.GetParentGroup().Type == Group.GroupType.AirGroup)
			{
				myUnit.DetachUnit(bool_0: false, bool_1: true, bool_2: false);
			}
			myUnit.Navigator.ClearPlottedCourse();
			myUnit.GoInoperative();
			if (!myUnit.Navigator.HasFlight)
			{
				return;
			}
			Mission.Flight flight = myUnit.Navigator.GetFlight();
			Mission mission = myUnit.AssignedMissionOrPackage();
			if (Information.IsNothing(flight) || Information.IsNothing(mission))
			{
				return;
			}
			flight.SetStatus(myUnit.ParentScen, Mission._FlightStatus.Completed);
			myUnit.Navigator.ClearFlight();
			bool flag = false;
			foreach (ActiveUnit activeUnits_ in myUnit.ParentScen.ActiveUnits_List)
			{
				if (activeUnits_ != null && activeUnits_.Navigator.HasFlight && activeUnits_.Navigator.GetFlight() == flight)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				if (!Information.IsNothing(mission.EmptySlotsList) && mission.EmptySlotsList.Count > 0)
				{
					foreach (Mission.EmptyAircraftSlot emptySlots in mission.EmptySlotsList)
					{
						if (emptySlots.GetMissionFlight(myUnit.ParentScen) == flight)
						{
							emptySlots.SetMissionFlight(myUnit.ParentScen, null);
						}
					}
				}
				mission.RemoveFlight(flight);
			}
			if (mission.Category == Mission.MissionCategory.Package)
			{
				ActiveUnit activeUnit3 = myUnit;
				Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_3 = Mission.MissionAssignmentAttemptResult.None;
				activeUnit3.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_3);
				if (!mission.RestartValue())
				{
					myUnit.GetUnitSide().Missions_Remove(mission);
				}
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100423", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CompareProxy(float float_0)
	{
		if (CurrentHostUnit == null)
		{
			return;
		}
		try
		{
			string name = CurrentHostUnit.Name;
			Aircraft aircraft_ = (Aircraft)myUnit;
			UpdateQuickTurnaroundSettings_TakeOff(ref aircraft_);
			if (myUnit.AssignedMissionOrPackage() != null)
			{
				Doctrine.ResetDoctrineSettings(ref myUnit, ref myUnit.Doctrine, myUnit.ParentScen);
			}
			myUnit.CurrentSpeed = (float)(2.0 / 3.0 * (double)myUnit.Kinematics.GetMaximumSpeed(myUnit.GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false));
			myUnit.CurrentHeading = CurrentHostUnit.CurrentHeading;
			myUnit.Kinematics.DesiredAltitudeOverride = false;
			myUnit.Kinematics.DesiredSpeedOverride = null;
			if (GetAssignedHostUnit() == null)
			{
				SetAssignedHostUnit(bool_0: false, CurrentHostUnit);
			}
			ActiveUnit currentHostUnit = CurrentHostUnit;
			if (GetAircraft().Loadout != null && myUnit.AssignedMissionOrPackage() != null)
			{
				ActiveUnit activeUnit = myUnit;
				ActiveUnit_AI aI = myUnit.AI;
				Aircraft aircraft = (aircraft_ = GetAircraft());
				bool? nullable_ = null;
				double double_ = aircraft.GetLatitude(nullable_);
				Aircraft aircraft2 = GetAircraft();
				bool? nullable_2 = null;
				double double_2 = aircraft2.GetLongitude(nullable_2);
				float desiredAltitude = aI.VisitClient(ref double_, ref double_2);
				aircraft2.SetLongitude(nullable_2, double_2);
				aircraft_.SetLatitude(nullable_, double_);
				activeUnit.DesiredAltitude = desiredAltitude;
			}
			else
			{
				ActiveUnit activeUnit2 = myUnit;
				Aircraft aircraft_2 = GetAircraft();
				ActiveUnit activeUnit3 = myUnit;
				ActiveUnit activeUnit_;
				bool bool_ = activeUnit3.GetDesiredAltitude_UseTerrainFollowing(activeUnit_ = myUnit);
				float desiredAltitude2 = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_2, ActiveUnit.Throttle.Loiter, ref bool_);
				activeUnit3.SetDesiredAltitude_UseTerrainFollowing(activeUnit_, bool_);
				activeUnit2.DesiredAltitude = desiredAltitude2;
			}
			if (myUnit.AssignedMissionOrPackage() != null)
			{
				if (myUnit.Navigator.HasFlightPlan)
				{
					ActiveUnit actualDestinationHost = ActualDestinationHost;
					if (actualDestinationHost == null)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else if (Operators.CompareString(myUnit.Navigator.GetFlight().LandingLocation_HostUnitObjectID, actualDestinationHost.ObjectID, TextCompare: false) != 0)
					{
						if (myUnit.ParentScen.ActiveUnits.ContainsKey(myUnit.Navigator.GetFlight().LandingLocation_HostUnitObjectID))
						{
							SetAssignedHostUnit(bool_0: false, myUnit.ParentScen.ActiveUnits[myUnit.Navigator.GetFlight().LandingLocation_HostUnitObjectID]);
						}
						else
						{
							string text = "";
							if (Operators.CompareString(GetAircraft().Name, GetAircraft().UnitClass, TextCompare: false) != 0)
							{
								text = " (" + GetAircraft().UnitClass + ")";
							}
							GetAircraft().AddMessage("飞机的安全飞行条件" + GetAircraft().Name + text + "设置为着陆在不再存在的单元。恢复使用" + name + "作为回归基地。", "重置飞行任务", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
						}
					}
				}
				else if (myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Ferry && ((FerryMission)myUnit.AssignedMissionOrPackage()).Behavior == FerryMission.FerryMissionBehavior.Cycle)
				{
					if (ActualDestinationHost == null)
					{
						((Aircraft_AirOps)myUnit.AirOps).AttemptToPark(bool_0: true, bool_1: false, bool_2: true);
						if (myUnit.IsGroupMember())
						{
							myUnit.SetParentGroup(bool_0: false, null);
						}
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else if (myUnit.AI.FerryCycleLegIsOutbound && Operators.CompareString(ActualDestinationHost.ObjectID, CurrentHostUnit.ObjectID, TextCompare: false) == 0)
					{
						myUnit.AI.ChangeCycleLeg();
					}
					else if (!myUnit.AI.FerryCycleLegIsOutbound && Operators.CompareString(GetAssignedHostUnit().ObjectID, CurrentHostUnit.ObjectID, TextCompare: false) == 0)
					{
						myUnit.AI.InitializeCycleFerry();
					}
				}
			}
			HostAirFacility = null;
			myUnit.SetLongitude(null, currentHostUnit.GetLongitude());
			myUnit.SetLatitude(null, currentHostUnit.GetLatitude());
			myUnit.SetCurrentAltitude(bool_0: false, currentHostUnit.GetCurrentAltitude() + 30f);
			Condition = _AirOpsCondition.Airborne;
			stubObserver?.Invoke(GetAircraft());
			if (myUnit.Propulsion[0].Status == PlatformComponent._ComponentStatus.Destroyed || myUnit.Propulsion[0].Status == PlatformComponent._ComponentStatus.Damaged)
			{
				myUnit.Propulsion[0].Repair();
			}
			if (myUnit.GetParentGroup() != null && !myUnit.IsGroupLead())
			{
				if (GetAircraft().FlightRole == Mission.Flight.FlightElement.LeadElement)
				{
					myUnit.GetParentGroup().PublishInvocation(myUnit);
					foreach (ActiveUnit value in myUnit.GetParentGroup().Units.Values)
					{
						if (value != myUnit && value.Navigator.HasPlottedCourse())
						{
							value.Navigator.ClearPlottedCourse();
						}
					}
				}
				else
				{
					bool flag = true;
					foreach (ActiveUnit value2 in myUnit.GetParentGroup().Units.Values)
					{
						if (value2 != myUnit && value2.IsOperating())
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						myUnit.GetParentGroup().PublishInvocation(myUnit);
					}
				}
			}
			GetAircraft().Status = ActiveUnit._ActiveUnitStatus.Unassigned;
			myUnit.AI.HasCaughtUpWithGroup = false;
			myUnit.AI.EvaluateTargets(float_0, bool_0: true, bool_1: true);
			myUnit.AI.DeterminePrimaryTarget((short)Math.Round(float_0), bool_0: true, bool_1: false);
			myUnit.AI.EvaluateThreats();
			myUnit.AI.EvaluateUnitStatus(float_0, bool_0: false, bool_1: false);
			TakeOff_SetFlight_Flightplan_Doctrine(bool_0: true);
			if (myUnit.GetParentGroup() != null && myUnit.GetParentGroup().Type != 0 && myUnit.Status != ActiveUnit._ActiveUnitStatus.OnPatrol)
			{
				myUnit.DetachUnit(bool_0: false, bool_1: true, bool_2: false);
			}
			string text2 = "";
			if (Operators.CompareString(GetAircraft().Name, GetAircraft().UnitClass, TextCompare: false) != 0)
			{
				text2 = " (" + GetAircraft().UnitClass + ")";
			}
			if (GetAircraft().Status == ActiveUnit._ActiveUnitStatus.Unassigned)
			{
				GetAircraft().AddMessage(GetAircraft().Name + text2 + "离开" + name + "正在等待命令。", GetAircraft().Name + " 飞机行动", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
			}
			else if (GetAircraft().IsGroupLead() && Information.IsNothing(GetAircraft().AssignedMissionOrPackage()))
			{
				GetAircraft().AddMessage(GetAircraft().Name + text2 + "离开" + name + "正在等待命令。", GetAircraft().Name + " 飞机行动", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
			}
			else
			{
				GetAircraft().AddMessage(GetAircraft().Name + text2 + "离开" + name + ".", GetAircraft().Name + " 飞机行动", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
			}
			GetAircraft().Sensory.Boolean_0 = true;
			GetAircraft().Sensory.vmethod_0(GetAircraft().Sensors_Cached);
			GetAircraft().Navigator.PreviousWaypointTime = GetAircraft().ParentScen.Time;
			if (GetAircraft().Navigator.HasPlottedCourse() && GetAircraft().Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TakeOff)
			{
				Aircraft_Navigator navigator = GetAircraft().Navigator;
				bool bool_2 = true;
				bool bool_3 = false;
				navigator.CheckIfReachedWaypoint(float_0, ref bool_2, ref bool_3);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100424", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void TakeOff_SetFlight_Flightplan_Doctrine(bool bool_0)
	{
		if ((myUnit.Navigator.HasPlottedCourse() && bool_0) || Information.IsNothing(myUnit.AssignedMissionOrPackage()))
		{
			return;
		}
		if (myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
		{
			if (myUnit.AI.IsEscort)
			{
				DisableProxy(Doctrine._UseIgnorePlottedCourse.Yes, bool_0);
				return;
			}
			switch (((Strike)myUnit.AssignedMissionOrPackage()).Type)
			{
			case Strike.StrikeType.Land_Strike:
			case Strike.StrikeType.Maritime_Strike:
				DisableProxy(Doctrine._UseIgnorePlottedCourse.No, bool_0);
				return;
			case Strike.StrikeType.Air_Intercept:
			case Strike.StrikeType.Sub_Strike:
				UpdateProxy();
				return;
			}
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		else if (myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
		{
			DisableProxy(Doctrine._UseIgnorePlottedCourse.Yes, bool_0);
		}
		else if (myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Support)
		{
			DisableProxy(Doctrine._UseIgnorePlottedCourse.No, bool_0);
		}
		else
		{
			UpdateProxy();
		}
	}

	private void ReadProxy(Mission mission_0)
	{
		try
		{
			foreach (IEventExporter applicableEventExporter in myUnit.ParentScen.ApplicableEventExporters)
			{
				if (!applicableEventExporter.IsOperating || !applicableEventExporter.ExportAirOps || Information.IsNothing(myUnit.GetUnitSide()))
				{
					continue;
				}
				Dictionary<string, IEventExporter.EventNotificationParameter> dictionary = new Dictionary<string, IEventExporter.EventNotificationParameter>(30);
				if (myUnit.ParentScen.MonteCarloIteration > 0)
				{
					dictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Title, typeof(string)));
					dictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.MonteCarloIteration, typeof(int)));
				}
				dictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.TimelineID, typeof(string)));
				if (applicableEventExporter.UseZeroHour)
				{
					dictionary.Add("Time", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Time.Subtract(myUnit.ParentScen.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				else
				{
					dictionary.Add("Time", new IEventExporter.EventNotificationParameter(myUnit.ParentScen.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + myUnit.ParentScen.Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				dictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(myUnit.ObjectID, typeof(string)));
				dictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(myUnit.Name, typeof(string)));
				dictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(myUnit.UnitClass, typeof(string)));
				dictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(myUnit.GetUnitSide().Name, typeof(string)));
				dictionary.Add("UnitLongitude", new IEventExporter.EventNotificationParameter(myUnit.GetLongitude(), typeof(double)));
				dictionary.Add("UnitLatitude", new IEventExporter.EventNotificationParameter(myUnit.GetLatitude(), typeof(double)));
				dictionary.Add("Action", new IEventExporter.EventNotificationParameter("Landing", typeof(string)));
				dictionary.Add("DepartureHostID", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
				dictionary.Add("DepartureHostName", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
				if (CurrentHostUnit == null)
				{
					if (ActualDestinationHost == null)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						dictionary.Add("ArrivalHostID", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
						dictionary.Add("ArrivalHostName", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					}
					else
					{
						dictionary.Add("ArrivalHostID", new IEventExporter.EventNotificationParameter(ActualDestinationHost.ObjectID, typeof(string)));
						dictionary.Add("ArrivalHostName", new IEventExporter.EventNotificationParameter(ActualDestinationHost.Name, typeof(string)));
					}
				}
				else
				{
					dictionary.Add("ArrivalHostID", new IEventExporter.EventNotificationParameter(CurrentHostUnit.ObjectID, typeof(string)));
					dictionary.Add("ArrivalHostName", new IEventExporter.EventNotificationParameter(CurrentHostUnit.Name, typeof(string)));
				}
				dictionary.Add("MissionID", new IEventExporter.EventNotificationParameter((mission_0 == null) ? string.Empty : mission_0.ObjectID, typeof(string)));
				dictionary.Add("MissionName", new IEventExporter.EventNotificationParameter((mission_0 == null) ? string.Empty : mission_0.Name, typeof(string)));
				dictionary.Add("TotalFuel", new IEventExporter.EventNotificationParameter(Conversions.ToString(GetAircraft().FuelCapacityCurrent), typeof(int)));
				dictionary.Add("LoadoutID", new IEventExporter.EventNotificationParameter((GetAircraft().Loadout == null) ? string.Empty : GetAircraft().Loadout.DBID.ToString(), typeof(string)));
				dictionary.Add("LoadoutName", new IEventExporter.EventNotificationParameter((GetAircraft().Loadout == null) ? string.Empty : GetAircraft().Loadout.Name, typeof(string)));
				if (Information.IsNothing(GetAircraft().Loadout))
				{
					dictionary.Add("LoadoutStores", new IEventExporter.EventNotificationParameter(CurrentHostUnit.Name, typeof(string)));
				}
				else
				{
					List<string> list = new List<string>();
					WeaponRec[] weapons = GetAircraft().Loadout.Weapons;
					WeaponRec[] array = weapons;
					foreach (WeaponRec weaponRec in array)
					{
						list.Add(Conversions.ToString(weaponRec.CurrentLoad) + "x " + Conversions.ToString(weaponRec.int_0));
					}
					dictionary.Add("LoadoutStores", new IEventExporter.EventNotificationParameter(string.Join("|", list), typeof(string)));
				}
				applicableEventExporter.ExportEvent(IEventExporter.ExportedEventType.AirOps, dictionary, myUnit.ParentScen);
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

	private void DisableProxy(Doctrine._UseIgnorePlottedCourse _UseIgnorePlottedCourse_0, bool bool_0)
	{
		try
		{
			if (myUnit.GetParentGroup() == null)
			{
				GetAircraft().Doctrine.SetIgnorePlottedCourse(GetAircraft().ParentScen, bool_0: false, false, bool_1: false, bool_2: false, _UseIgnorePlottedCourse_0);
				if (GetAircraft().Navigator.HasFlightPlan)
				{
					if (bool_0)
					{
						Waypoint[] flightPlan = GetAircraft().Navigator.GetFlight().FlightPlan;
						Waypoint[] array = flightPlan;
						foreach (Waypoint theAC in array)
						{
							Aircraft_Navigator navigator = GetAircraft().Navigator;
							Waypoint[] gparam_ = navigator.PlottedCourse;
							ArrayExtensions.Add(ref gparam_, theAC);
							navigator.PlottedCourse = gparam_;
						}
					}
					else if (GetAircraft().Navigator.PlottedCourse_PrePlanned.Count() > 0)
					{
						GetAircraft().Navigator.PlottedCourse = GetAircraft().Navigator.PlottedCourse_PrePlanned;
					}
				}
				if (GetAircraft().Navigator.HasFlight)
				{
					GetAircraft().Navigator.GetFlight().SetStatus(myUnit.ParentScen, Mission._FlightStatus.Airborne);
				}
				return;
			}
			Aircraft aircraft = (Aircraft)myUnit.GetParentGroup().GroupLead;
			aircraft.Doctrine.SetIgnorePlottedCourse(aircraft.ParentScen, bool_0: false, false, bool_1: false, bool_2: false, _UseIgnorePlottedCourse_0);
			foreach (ActiveUnit value in myUnit.GetParentGroup().Units.Values)
			{
				if (!value.IsGroupLead())
				{
					value.Doctrine.SetIgnorePlottedCourse(aircraft.ParentScen, bool_0: false, false, bool_1: false, bool_2: false, _UseIgnorePlottedCourse_0);
				}
			}
			if (bool_0)
			{
				if (aircraft.Navigator.HasFlightPlan)
				{
					if (myUnit.IsGroupLead())
					{
						Waypoint[] flightPlan2 = aircraft.Navigator.GetFlight().FlightPlan;
						Waypoint[] array2 = flightPlan2;
						foreach (Waypoint theAC2 in array2)
						{
							Aircraft_Navigator navigator2 = aircraft.Navigator;
							Waypoint[] gparam_2 = navigator2.PlottedCourse;
							ArrayExtensions.Add(ref gparam_2, theAC2);
							navigator2.PlottedCourse = gparam_2;
						}
					}
				}
				else if ((myUnit.GetParentGroup().Type != 0 || !myUnit.GetParentGroup().IsFormingUp) && aircraft.Navigator.PlottedCourse_PrePlanned.Count() > 0)
				{
					aircraft.Navigator.PlottedCourse = aircraft.Navigator.PlottedCourse_PrePlanned;
				}
			}
			if (aircraft.Navigator.HasFlight)
			{
				aircraft.Navigator.GetFlight().SetStatus(myUnit.ParentScen, Mission._FlightStatus.Airborne);
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

	private void UpdateProxy()
	{
		try
		{
			if (myUnit.GetParentGroup() == null)
			{
				if (GetAircraft().Navigator.HasFlight)
				{
					GetAircraft().Navigator.GetFlight().SetStatus(myUnit.ParentScen, Mission._FlightStatus.Airborne);
				}
				return;
			}
			Aircraft aircraft = (Aircraft)myUnit.GetParentGroup().GroupLead;
			if (aircraft.Navigator.HasFlight)
			{
				aircraft.Navigator.GetFlight().SetStatus(myUnit.ParentScen, Mission._FlightStatus.Airborne);
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

	private void InsertProxy(AirFacility airFacility_0, bool bool_0, bool bool_1)
	{
		try
		{
			HostAirFacility = airFacility_0;
			bool flag = GetAircraft().AirborneTime > 0f;
			if (bool_0)
			{
				Aircraft aircraft_;
				if (Information.IsNothing(GetAircraft().Loadout))
				{
					Condition = _AirOpsCondition.Readying;
					ConditionTimer = 1800f;
				}
				else
				{
					ActiveUnit_AirOps airOps = CurrentHostUnit.AirOps;
					aircraft_ = GetAircraft();
					airOps.OutfitAC(ref aircraft_, GetAircraft().Loadout.DBID, GetAircraft().Loadout.DBID, bool_0: false, GetAircraft().Loadout.NoOptionalWeapons, !myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines), bool_3: false, bool_4: true);
				}
				ActiveUnit_AirOps airOps2 = CurrentHostUnit.AirOps;
				aircraft_ = GetAircraft();
				airOps2.RefuelAC_Simple(ref aircraft_);
				ActiveUnit_AirOps airOps3 = CurrentHostUnit.AirOps;
				aircraft_ = GetAircraft();
				airOps3.RepairAC(ref aircraft_);
			}
			else if (bool_1)
			{
				Condition = _AirOpsCondition.Parked;
				ConditionTimer = 0f;
				if (!Information.IsNothing(myUnit.GetParentGroup()))
				{
					myUnit.SetParentGroup(bool_0: false, null);
				}
			}
			if (!(myUnit.OnboardCargo.Count() > 0 && flag))
			{
				return;
			}
			bool bool_2 = false;
			CargoMission cargoMission = null;
			if (GetAircraft().AssignedMissionOrPackage() != null && GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Cargo)
			{
				cargoMission = (CargoMission)GetAircraft().AssignedMissionOrPackage();
				bool_2 = cargoMission.UnpackAllContainers;
			}
			ActiveUnit activeUnit = null;
			List<ActiveUnit> list = new List<ActiveUnit>();
			if (CurrentHostUnit is Group)
			{
				Group group = (Group)CurrentHostUnit;
				LockRandom lockRandom_ = GameGeneral.LockRandom_0;
				if (cargoMission != null && cargoMission.DestinationUnit != null && cargoMission.DestinationUnit.IsGroupMember() && cargoMission.DestinationUnit.GetParentGroup() == group)
				{
					list.Add(cargoMission.DestinationUnit);
				}
				if (list.Count == 0)
				{
					foreach (ActiveUnit value in group.Units.Values)
					{
						if (value.OnboardCargo.Count() > 0)
						{
							list.Add(value);
						}
					}
				}
				if (list.Count == 1)
				{
					activeUnit = list[0];
				}
				else if (list.Count <= 1)
				{
					foreach (ActiveUnit value2 in group.Units.Values)
					{
						if ((uint)(((Facility)value2).Category - 3001) <= 6u && ((Facility)value2).Area > 400.0)
						{
							list.Add(value2);
						}
					}
					activeUnit = ((list.Count == 1) ? list[0] : ((list.Count <= 1) ? group.Units.Values.ElementAtOrDefault(lockRandom_.Next(group.Units.Count)) : list[lockRandom_.Next(list.Count)]));
				}
				else
				{
					activeUnit = list[lockRandom_.Next(list.Count)];
				}
			}
			else
			{
				activeUnit = CurrentHostUnit;
			}
			if (!Information.IsNothing(activeUnit))
			{
				int num = ActiveUnit_DockingOps.TimeToUnloadCargo(myUnit, myUnit.OnboardCargo.ToList());
				ConditionTimer = Math.Max(ConditionTimer, num);
				ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(myUnit, activeUnit, myUnit.OnboardCargo.ToList(), bool_2);
			}
			RemoveProxy();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100425", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void UnloadStores()
	{
		bool flag = true;
		try
		{
			if (GetAircraft().Loadout == null)
			{
				return;
			}
			if (!GetAircraft().ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
			{
				WeaponRec[] weapons = GetAircraft().Loadout.Weapons;
				WeaponRec[] array = weapons;
				foreach (WeaponRec weaponRec in array)
				{
					if (Weapon.WeaponIsNonRivalrous(weaponRec.int_0, ref myUnit.ParentScen) || weaponRec.CurrentLoad <= 0)
					{
						continue;
					}
					int currentLoad = weaponRec.CurrentLoad;
					for (int i = 1; i <= currentLoad; i++)
					{
						if (Operators.CompareString(CurrentHostUnit.Weaponry.AddWeaponToMagazines(weaponRec.int_0, bool_1: true, bool_2: true), "OK", TextCompare: false) == 0)
						{
							weaponRec.CurrentLoad--;
							continue;
						}
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				GetAircraft().Loadout.Weapons = new WeaponRec[0];
			}
			else
			{
				myUnit.AddMessage(myUnit.Name + " is unable to unload weapons due magazine limitations at " + CurrentHostUnit.Name, myUnit.Name + " cannot change loadout", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100426", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool CanBeRearmedRightNow()
	{
		if (Information.IsNothing(HostAirFacility))
		{
			return false;
		}
		return HostAirFacility.QueryReader();
	}

	public override bool AttemptToRTB(bool bool_0, ActiveUnit._ActiveUnitStatus _ActiveUnitStatus_0, bool bool_1, ActiveUnit._ActiveUnitStatus _ActiveUnitStatus_1, bool bool_2, bool bool_3)
	{
		try
		{
			if (Condition == _AirOpsCondition.RTB && myUnit.IsRTB && !bool_0 && !Information.IsNothing(ActualDestinationHost))
			{
				return true;
			}
			bool flag = true;
			if (Condition == _AirOpsCondition.DeployingDippingSonar && ConditionTimer > 0f)
			{
				flag = false;
			}
			if (myUnit.IsOperating())
			{
				if (Information.IsNothing(ActualDestinationHost))
				{
					PickNewAssignedHost_Nearest();
					if (Information.IsNothing(GetAssignedHostUnit()))
					{
						string text = "";
						if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, TextCompare: false) != 0)
						{
							text = " (" + myUnit.UnitClass + ")";
						}
						if (bool_0)
						{
							myUnit.ParentScen.AddMessage(myUnit.Name + text + "没有合适的降落地点！", "着陆问题", LoggedMessage.MessageType.AirOps, 15, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						}
						myUnit.DesiredTurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
						return false;
					}
					if (bool_2)
					{
						myUnit.DetachUnit(bool_0: false, bool_3, bool_2: false);
					}
					if (!myUnit.IsRTB)
					{
						myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB;
					}
					if (flag)
					{
						Condition = _AirOpsCondition.RTB;
					}
					myUnit.Kinematics.DesiredSpeedOverride = null;
					myUnit.Kinematics.DesiredAltitudeOverride = false;
					if (bool_1 && myUnit.GetParentGroup() != null)
					{
						foreach (ActiveUnit value in myUnit.GetParentGroup().Units.Values)
						{
							if (value == myUnit)
							{
								continue;
							}
							if (bool_2)
							{
								myUnit.DetachUnit(bool_0: false, bool_3, bool_2: false);
							}
							if (!value.IsRTB)
							{
								value.Status = ActiveUnit._ActiveUnitStatus.RTB;
							}
							if (value.IsAircraft)
							{
								Aircraft aircraft = (Aircraft)value;
								if (aircraft.AirOps.Condition != _AirOpsCondition.DeployingDippingSonar || aircraft.AirOps.ConditionTimer == 0f)
								{
									Condition = _AirOpsCondition.RTB;
								}
							}
							else
							{
								Condition = _AirOpsCondition.RTB;
							}
							value.Kinematics.DesiredSpeedOverride = null;
							value.Kinematics.DesiredAltitudeOverride = false;
						}
					}
					myUnit.DesiredTurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
					return true;
				}
				if (bool_2)
				{
					myUnit.DetachUnit(bool_0: false, bool_3, bool_2: false);
				}
				if (myUnit.Navigator.HasPlottedCourse())
				{
					myUnit.Navigator.ClearPlottedCourse();
				}
				if (!myUnit.IsRTB)
				{
					myUnit.Status = _ActiveUnitStatus_0;
				}
				if (flag)
				{
					Condition = _AirOpsCondition.RTB;
				}
				myUnit.Kinematics.DesiredSpeedOverride = null;
				myUnit.Kinematics.DesiredAltitudeOverride = false;
				if (bool_1 && myUnit.GetParentGroup() != null)
				{
					foreach (ActiveUnit item in new List<ActiveUnit>(myUnit.GetParentGroup().Units.Values))
					{
						if (item == myUnit)
						{
							continue;
						}
						if (bool_2)
						{
							myUnit.DetachUnit(bool_0: false, bool_3, bool_2: false);
						}
						if (!item.IsRTB)
						{
							item.Status = ActiveUnit._ActiveUnitStatus.RTB;
						}
						if (item.IsAircraft)
						{
							Aircraft aircraft2 = (Aircraft)item;
							if (aircraft2.AirOps.Condition != _AirOpsCondition.DeployingDippingSonar || aircraft2.AirOps.ConditionTimer == 0f)
							{
								Condition = _AirOpsCondition.RTB;
							}
						}
						else
						{
							Condition = _AirOpsCondition.RTB;
						}
						item.Kinematics.DesiredSpeedOverride = null;
						item.Kinematics.DesiredAltitudeOverride = false;
					}
				}
				myUnit.DesiredTurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100427", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			myUnit.DesiredTurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal bool PrepareProxy()
	{
		ActiveUnit currentHostUnit = CurrentHostUnit;
		if (Information.IsNothing(currentHostUnit))
		{
			return false;
		}
		bool result = false;
		try
		{
			if (Information.IsNothing(GetAircraft().AssignedMissionOrPackage()))
			{
				result = false;
				return false;
			}
			if (GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				if (GetAircraft().AI.IsEscort)
				{
					result = false;
					return false;
				}
				if (!Information.IsNothing(HostAirFacility) && (HostAirFacility.AirFacType == AirFacility._AirFacType.RunwayAccessPoint || HostAirFacility.AirFacType == AirFacility._AirFacType.Catapult || HostAirFacility.AirFacType == AirFacility._AirFacType.SkiJump))
				{
					result = false;
					return false;
				}
				List<Aircraft> list = new List<Aircraft>();
				foreach (Aircraft item in currentHostUnit.AirOps.EmbarkedAircraft_ReadOnly)
				{
					if (item != myUnit && item.AI.IsEscort && !Information.IsNothing(item.AssignedMissionOrPackage()) && item.AssignedMissionOrPackage() == myUnit.AssignedMissionOrPackage())
					{
						string string_ = null;
						if (item.IsAvailableForOps(ref string_) == AirOpsAvailabilityStatus.IsAvailable && !item.IsParkedAndReady() && !item.IsParkedAndReadying() && item.AirOps.Condition != _AirOpsCondition.Readying)
						{
							list.Add(item);
						}
					}
				}
				if (list.Count == 0)
				{
					result = false;
					return false;
				}
				ConditionTimer = 30f;
				result = true;
				return true;
			}
			result = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200445", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public void AttemptToMoveToRunway(bool bool_0, bool bool_1 = false)
	{
		ReflectProxy();
		if (myUnit == null || !(ConditionTimer <= 0f) || Information.IsNothing(HostAirFacility))
		{
			return;
		}
		if (bool_0)
		{
			Condition = _AirOpsCondition.PreparingToLaunch;
		}
		if (Information.IsNothing(HostAirFacility.ParentPlatform) && !Information.IsNothing(CurrentHostUnit))
		{
			CurrentHostUnit.AddAirFacility(HostAirFacility);
			HostAirFacility.ParentPlatform = CurrentHostUnit;
		}
		try
		{
			switch (HostAirFacility.AirFacType)
			{
			case AirFacility._AirFacType.Catapult:
				CancelProxy(HostAirFacility);
				return;
			case AirFacility._AirFacType.Runway:
			case AirFacility._AirFacType.RunwayWithArrest:
			case AirFacility._AirFacType.SkiJump:
			case AirFacility._AirFacType.Pad:
			case AirFacility._AirFacType.PadWithHaulDown:
				if (VisitProxy(HostAirFacility) == TakeOffCheck.OK)
				{
					CancelProxy(HostAirFacility);
					return;
				}
				break;
			case AirFacility._AirFacType.const_13:
				if (Condition == _AirOpsCondition.HoldingForAvailableRunway)
				{
					AttemptToPark();
				}
				if (Condition == _AirOpsCondition.HoldingForAvailableTransit)
				{
					AttemptToPark();
				}
				if (Condition == _AirOpsCondition.PreparingToLaunch && myUnit.Kinematics.GetMaximumAltitude() > HostAirFacility.ParentPlatform.GetCurrentAltitude() + 50f)
				{
					CancelProxy(HostAirFacility);
				}
				else
				{
					ConditionTimer = 60f;
				}
				return;
			case AirFacility._AirFacType.Hangar:
			{
				if (HostAirFacility.ParentPlatform.IsShip)
				{
					Ship._ShipCategory category = ((Ship)HostAirFacility.ParentPlatform).Category;
					if (category != Ship._ShipCategory.AviationShip && category != Ship._ShipCategory.SurfaceCombatantAviation && category != Ship._ShipCategory.MobileOffshoreBase)
					{
						for (int k = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; k >= 0; k += -1)
						{
							AirFacility airFacility3 = CurrentHostUnit.AirFacilities_ReadOnly[k];
							if ((airFacility3.DefineReader() || airFacility3.AirFacType == AirFacility._AirFacType.const_13) && VisitProxy(airFacility3) == TakeOffCheck.OK && airFacility3.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success && (airFacility3.AirFacType != AirFacility._AirFacType.const_13 || airFacility3.HostedAircraft.Count < airFacility3.Capacity))
							{
								CancelProxy(airFacility3);
								return;
							}
						}
					}
				}
				else if (GetAircraft().Type == Aircraft._AircraftType.UAV || GetAircraft().Type == Aircraft._AircraftType.UCAV)
				{
					for (int l = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; l >= 0; l += -1)
					{
						AirFacility airFacility4 = CurrentHostUnit.AirFacilities_ReadOnly[l];
						if (airFacility4.AirFacType == AirFacility._AirFacType.const_13 && VisitProxy(airFacility4) == TakeOffCheck.OK && airFacility4.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success && airFacility4.HostedAircraft.Count < airFacility4.Capacity)
						{
							CancelProxy(airFacility4);
							return;
						}
					}
				}
				if (!Information.IsNothing(CurrentHostUnit.AirOps.LandingQueue_ReadOnly) && !Information.IsNothing(CurrentHostUnit.AirOps.ResetClient()))
				{
					List<AirFacility> list4 = CurrentHostUnit.AirFacilities_ReadOnly.Where((AirFacility theAF) => theAF.ResetReader() && theAF.Status != PlatformComponent._ComponentStatus.Destroyed).ToList();
					List<AirFacility> list5 = list4.Where((AirFacility theAF) => theAF.HostedAircraft.Count >= theAF.Capacity).ToList();
					if (CurrentHostUnit.AirOps.LandingQueue_ReadOnly.Count() <= 0 && CurrentHostUnit.AirOps.ResetClient().Count <= 0)
					{
						if (!Information.IsNothing(CurrentHostUnit.AirOps.HaveAircraftOnTouchdown()) && list4.Count - list5.Count <= 2)
						{
							Condition = _AirOpsCondition.HoldingForAvailableTransit;
							ConditionTimer = 35f;
							return;
						}
					}
					else if (list4.Count - list5.Count <= 2)
					{
						Condition = _AirOpsCondition.HoldingForAvailableTransit;
						ConditionTimer = 35f;
						return;
					}
				}
				IEnumerable<AirFacility> enumerable3 = from theAirFac in GetRunwayAccessPointsInOperationOnMe_myUnitSize(CurrentHostUnit)
					orderby theAirFac.MaxAircraftSize
					select theAirFac;
				if (!Information.IsNothing(enumerable3) && enumerable3.Count() > 0)
				{
					IEnumerable<AirFacility> enumerable4 = MapClient(true, GetAircraft(), CurrentHostUnit, enumerable3);
					if (!Information.IsNothing(enumerable4) && enumerable4.Count() > 0)
					{
						VerifyProxy(enumerable4.ElementAtOrDefault(0), (TaxyingFacilityType)0);
						return;
					}
				}
				TakeOffCheck takeOffCheck = TestProxy(CurrentHostUnit);
				if (takeOffCheck == TakeOffCheck.OK)
				{
					Condition = _AirOpsCondition.HoldingForAvailableTransit;
					ConditionTimer = 60f;
					break;
				}
				if (bool_1)
				{
					GameGeneral.ResolveBridge(takeOffCheck.ToString().Replace("_", " "), GetAircraft().GetUnitSide(), "Unable to take-off", GameGeneral.MessageBoxMessageType.Warning);
				}
				GetAircraft().ParentScen.AddMessage(GetAircraft().Name + " is unable to take-off due to no suitable facility, reason : " + takeOffCheck.ToString().Replace("_", " "), "Unit unable to launch", LoggedMessage.MessageType.AirOps, 5, GetAircraft().ObjectID, GetAircraft().GetUnitSide(), new Geopoint_Struct(CurrentHostUnit.GetLongitude(), CurrentHostUnit.GetLatitude()));
				Condition = _AirOpsCondition.Parked;
				ConditionTimer = 35f;
				return;
			}
			case AirFacility._AirFacType.CarrierArrestingGear:
			case AirFacility._AirFacType.OpenParking:
			{
				if (HostAirFacility.ParentPlatform.IsShip)
				{
					Ship._ShipCategory category2 = ((Ship)HostAirFacility.ParentPlatform).Category;
					if (category2 != Ship._ShipCategory.AviationShip && category2 != Ship._ShipCategory.SurfaceCombatantAviation && category2 != Ship._ShipCategory.MobileOffshoreBase)
					{
						for (int m = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; m >= 0; m += -1)
						{
							AirFacility airFacility5 = CurrentHostUnit.AirFacilities_ReadOnly[m];
							if (VisitProxy(airFacility5) == TakeOffCheck.OK && airFacility5.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success)
							{
								CancelProxy(airFacility5);
								return;
							}
						}
					}
					else
					{
						if (!Information.IsNothing(CurrentHostUnit.AirOps.LandingQueue_ReadOnly) && !Information.IsNothing(CurrentHostUnit.AirOps.ResetClient()))
						{
							if (category2 == Ship._ShipCategory.MobileOffshoreBase)
							{
								List<AirFacility> list6 = CurrentHostUnit.AirFacilities_ReadOnly.Where((AirFacility theAF) => theAF.DefineReader() && theAF.Status != PlatformComponent._ComponentStatus.Destroyed).ToList();
								List<AirFacility> list7 = list6.Where((AirFacility theAF) => theAF.HostedAircraft.Skip(0).Count() > 0).ToList();
								if (list6.Count > 0)
								{
									int count = list6.Count;
									int num = 0;
									if (count <= 0)
									{
										num = 0;
									}
									else if (count == 1)
									{
										num = 1;
									}
									else if (count == 2)
									{
										num = 1;
									}
									else if (count == 3)
									{
										num = 2;
									}
									else if (count >= 4)
									{
										num = 2;
									}
									if (list6.Count - list7.Count <= num)
									{
										if (CurrentHostUnit.AirOps.LandingQueue_ReadOnly.Count() > 0 || CurrentHostUnit.AirOps.ResetClient().Count > 0)
										{
											Condition = _AirOpsCondition.HoldingForAvailableRunway;
											ConditionTimer = 35f;
											return;
										}
										if (!Information.IsNothing(CurrentHostUnit.AirOps.HaveAircraftOnTouchdown()))
										{
											Condition = _AirOpsCondition.HoldingForAvailableRunway;
											ConditionTimer = 35f;
											return;
										}
									}
								}
							}
							else
							{
								List<AirFacility> list8 = CurrentHostUnit.AirFacilities_ReadOnly.Where((AirFacility theAF) => theAF.AwakeReader() && theAF.Status != PlatformComponent._ComponentStatus.Destroyed).ToList();
								List<AirFacility> list9 = list8.Where((AirFacility theAF) => theAF.HostedAircraft.Skip(0).Count() > 0).ToList();
								if (list8.Count > 0)
								{
									int count2 = list8.Count;
									int num2 = 0;
									if (count2 <= 0)
									{
										num2 = 0;
									}
									else if (count2 == 1)
									{
										num2 = 1;
									}
									else if (count2 == 2)
									{
										num2 = 1;
									}
									else if (count2 == 3)
									{
										num2 = 2;
									}
									else if (count2 >= 4)
									{
										num2 = 2;
									}
									if (list8.Count - list9.Count <= num2)
									{
										if (CurrentHostUnit.AirOps.LandingQueue_ReadOnly.Count() > 0 || CurrentHostUnit.AirOps.ResetClient().Count > 0)
										{
											Condition = _AirOpsCondition.HoldingForAvailableRunway;
											ConditionTimer = 35f;
											return;
										}
										if (!Information.IsNothing(CurrentHostUnit.AirOps.HaveAircraftOnTouchdown()))
										{
											Condition = _AirOpsCondition.HoldingForAvailableRunway;
											ConditionTimer = 35f;
											return;
										}
									}
								}
							}
						}
						for (int n = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; n >= 0; n += -1)
						{
							AirFacility airFacility6 = CurrentHostUnit.AirFacilities_ReadOnly[n];
							if (VisitProxy(airFacility6) == TakeOffCheck.OK && airFacility6.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success)
							{
								CancelProxy(airFacility6);
								return;
							}
						}
					}
					Condition = _AirOpsCondition.HoldingForAvailableRunway;
					ConditionTimer = 5f;
					break;
				}
				if (!Information.IsNothing(CurrentHostUnit.AirOps.LandingQueue_ReadOnly) && !Information.IsNothing(CurrentHostUnit.AirOps.ResetClient()))
				{
					if (CurrentHostUnit.AirOps.LandingQueue_ReadOnly.Count() > 0 || CurrentHostUnit.AirOps.ResetClient().Count > 0)
					{
						Condition = _AirOpsCondition.HoldingForAvailableTransit;
						ConditionTimer = 35f;
						return;
					}
					if (!Information.IsNothing(CurrentHostUnit.AirOps.HaveAircraftOnTouchdown()))
					{
						List<AirFacility> list10 = CurrentHostUnit.AirFacilities_ReadOnly.Where((AirFacility theAF) => theAF.ResetReader() && theAF.Status != PlatformComponent._ComponentStatus.Destroyed).ToList();
						List<AirFacility> list2 = list10.Where((AirFacility theAF) => theAF.HostedAircraft.Count >= theAF.Capacity).ToList();
						if (list10.Count - list2.Count <= 2)
						{
							Condition = _AirOpsCondition.HoldingForAvailableTransit;
							ConditionTimer = 35f;
							return;
						}
					}
				}
				IEnumerable<AirFacility> enumerable5 = from theAirFac in GetRunwayAccessPointsInOperationOnMe_myUnitSize(GetAircraft().AirOps.CurrentHostUnit)
					orderby theAirFac.MaxAircraftSize
					select theAirFac;
				if (!Information.IsNothing(enumerable5) && enumerable5.Count() > 0)
				{
					IEnumerable<AirFacility> enumerable6 = MapClient(true, GetAircraft(), CurrentHostUnit, enumerable5);
					if (!Information.IsNothing(enumerable6) && enumerable6.Count() > 0)
					{
						VerifyProxy(enumerable6.ElementAtOrDefault(0), (TaxyingFacilityType)0);
						return;
					}
				}
				Condition = _AirOpsCondition.HoldingForAvailableTransit;
				ConditionTimer = 35f;
				break;
			}
			case AirFacility._AirFacType.RunwayAccessPoint:
			case AirFacility._AirFacType.Elevator:
			{
				if (!Information.IsNothing(CurrentHostUnit.AirOps.LandingQueue_ReadOnly) && !Information.IsNothing(CurrentHostUnit.AirOps.ResetClient()))
				{
					List<AirFacility> list = CurrentHostUnit.AirFacilities_ReadOnly.Where((AirFacility theAF) => theAF.ResetReader() && theAF.Status != PlatformComponent._ComponentStatus.Destroyed).ToList();
					List<AirFacility> list3 = list.Where((AirFacility theAF) => theAF.HostedAircraft.Count >= theAF.Capacity).ToList();
					if ((CurrentHostUnit.AirOps.LandingQueue_ReadOnly.Count() > 0 || CurrentHostUnit.AirOps.ResetClient().Count > 0) && list.Count - list3.Count <= 2)
					{
						for (int i = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; i >= 0; i += -1)
						{
							AirFacility airFacility = CurrentHostUnit.AirFacilities_ReadOnly[i];
							if (airFacility.AirFacType == AirFacility._AirFacType.OpenParking && airFacility.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success)
							{
								InsertProxy(airFacility, bool_0: false, bool_1: false);
								Condition = _AirOpsCondition.HoldingForAvailableRunway;
								ConditionTimer = 35f;
								return;
							}
						}
					}
					if (!Information.IsNothing(CurrentHostUnit.AirOps.HaveAircraftOnTouchdown()) && list.Count - list3.Count <= 2)
					{
						for (int j = CurrentHostUnit.AirFacilities_ReadOnly.Length - 1; j >= 0; j += -1)
						{
							AirFacility airFacility2 = CurrentHostUnit.AirFacilities_ReadOnly[j];
							if (airFacility2.AirFacType == AirFacility._AirFacType.OpenParking && airFacility2.CanHostThisAircraft_BySize(GetAircraft()) == AirOpsAttemptResult.Success)
							{
								InsertProxy(airFacility2, bool_0: false, bool_1: false);
								Condition = _AirOpsCondition.HoldingForAvailableRunway;
								ConditionTimer = 35f;
								return;
							}
						}
					}
				}
				IEnumerable<AirFacility> enumerable = from theAirFac in RunwaysInOperationOnMe_myUnitSize(GetAircraft(), bool_0: true, bool_1: false, CurrentHostUnit, GetAircraft().CanLandVertically)
					orderby theAirFac.MaxAircraftSize, theAirFac.EffectiveRunwaySize
					select theAirFac;
				if (!Information.IsNothing(enumerable) && enumerable.Count() > 0)
				{
					IEnumerable<AirFacility> enumerable2 = SortClient(bool_0: true, bool_1: false, GetAircraft(), CurrentHostUnit, GetAircraft().CanLandVertically, enumerable);
					if (!Information.IsNothing(enumerable2) && enumerable2.Count() > 0)
					{
						CancelProxy(enumerable2.ElementAtOrDefault(0));
						return;
					}
				}
				break;
			}
			}
			if ((ConditionTimer == 0f) & (Condition != _AirOpsCondition.HoldingForAvailableRunway))
			{
				Condition = _AirOpsCondition.HoldingForAvailableRunway;
				GetAircraft().ParentScen.AddMessage(GetAircraft().Name + " is unable to take-off due to runway/access restrictions", "Unit unable to launch", LoggedMessage.MessageType.UnitAI, 5, GetAircraft().ObjectID, GetAircraft().GetUnitSide(), new Geopoint_Struct(CurrentHostUnit.GetLongitude(), CurrentHostUnit.GetLatitude()));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100428", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool ReflectProxy()
	{
		BadWeatherFlag = false;
		WeatherString = "";
		if (!GetAircraft().AirOps.CheckProxy())
		{
			WeatherString = "Cannot takeoff (rainfall too heavy)";
			ConditionTimer = 900f;
			BadWeatherFlag = true;
		}
		if (!GetAircraft().AirOps.ConcatProxy())
		{
			WeatherString = "Cannot takeoff (daylight conditions not met)";
			ConditionTimer = 900f;
			BadWeatherFlag = true;
		}
		return !BadWeatherFlag;
	}

	public static List<AirFacility> RunwaysInOperationOnMe_myUnitSize(Aircraft aircraft_0, bool bool_0, bool bool_1, ActiveUnit activeUnit_0, bool bool_2)
	{
		try
		{
			List<AirFacility> list = new List<AirFacility>();
			List<AirFacility> list2 = new List<AirFacility>();
			AirFacility[] airFacilities_ReadOnly = activeUnit_0.AirFacilities_ReadOnly;
			for (int i = airFacilities_ReadOnly.Length - 1; i >= 0; i += -1)
			{
				AirFacility airFacility = airFacilities_ReadOnly[i];
				switch (airFacility.AirFacType)
				{
				case AirFacility._AirFacType.Pad:
				case AirFacility._AirFacType.PadWithHaulDown:
					if (bool_0 && bool_2 && aircraft_0.AirOps.VisitProxy(airFacility) == TakeOffCheck.OK)
					{
						list.Add(airFacility);
					}
					else if (!bool_0 && bool_2 && aircraft_0.AirOps.RestartProxy(airFacility, bool_1) == AirOpsAttemptResult.Success)
					{
						list.Add(airFacility);
					}
					else if (bool_2 && aircraft_0.RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.VTOL && activeUnit_0.IsShip && (((Ship)activeUnit_0).Category == Ship._ShipCategory.AviationShip || ((Ship)activeUnit_0).Category == Ship._ShipCategory.SurfaceCombatantAviation))
					{
						list.Add(airFacility);
					}
					else if ((aircraft_0.Type == Aircraft._AircraftType.UAV || aircraft_0.Type == Aircraft._AircraftType.UCAV) && aircraft_0.RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.CatapultLaunched && (int)aircraft_0.Size <= (int)airFacility.MaxAircraftSize)
					{
						list.Add(airFacility);
					}
					break;
				case AirFacility._AirFacType.RunwayGrade_Taxiway:
					if (bool_0 && aircraft_0.AirOps.VisitProxy(airFacility) == TakeOffCheck.OK)
					{
						list2.Add(airFacility);
					}
					else if (!bool_0 && aircraft_0.AirOps.RestartProxy(airFacility, bool_1) == AirOpsAttemptResult.Success)
					{
						list2.Add(airFacility);
					}
					break;
				case AirFacility._AirFacType.Runway:
				case AirFacility._AirFacType.RunwayWithArrest:
				case AirFacility._AirFacType.Catapult:
				case AirFacility._AirFacType.SkiJump:
				case AirFacility._AirFacType.CarrierArrestingGear:
				case AirFacility._AirFacType.const_13:
					if (bool_0 && !bool_2 && aircraft_0.AirOps.VisitProxy(airFacility) == TakeOffCheck.OK)
					{
						list.Add(airFacility);
					}
					else if (!bool_0 && !bool_2 && aircraft_0.AirOps.RestartProxy(airFacility, bool_1) == AirOpsAttemptResult.Success)
					{
						list.Add(airFacility);
					}
					else if (bool_0 && bool_2 && aircraft_0.AirOps.VisitProxy(airFacility) == TakeOffCheck.OK)
					{
						list2.Add(airFacility);
					}
					else if (!bool_0 && bool_2 && aircraft_0.AirOps.RestartProxy(airFacility, bool_1) == AirOpsAttemptResult.Success)
					{
						list2.Add(airFacility);
					}
					else if (bool_2 && aircraft_0.RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.VTOL && activeUnit_0.IsShip && (((Ship)activeUnit_0).Category == Ship._ShipCategory.AviationShip || ((Ship)activeUnit_0).Category == Ship._ShipCategory.SurfaceCombatantAviation))
					{
						list.Add(airFacility);
					}
					else if ((aircraft_0.Type == Aircraft._AircraftType.UAV || aircraft_0.Type == Aircraft._AircraftType.UCAV) && aircraft_0.RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.CatapultLaunched && (int)aircraft_0.Size <= (int)airFacility.MaxAircraftSize)
					{
						list.Add(airFacility);
					}
					break;
				case AirFacility._AirFacType.OpenParking:
					if ((aircraft_0.Type == Aircraft._AircraftType.UAV || aircraft_0.Type == Aircraft._AircraftType.UCAV) && aircraft_0.RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.CatapultLaunched && (int)aircraft_0.Size <= (int)airFacility.MaxAircraftSize)
					{
						list.Add(airFacility);
					}
					break;
				}
			}
			if (list2.Count > 0 && list.Count == 0)
			{
				return list2;
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200355", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<AirFacility> result = new List<AirFacility>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal TakeOffCheck VisitProxy(AirFacility airFacility_0)
	{
		try
		{
			bool flag = false;
			bool flag2 = false;
			switch (airFacility_0.AirFacType)
			{
			case AirFacility._AirFacType.Runway:
			case AirFacility._AirFacType.RunwayGrade_Taxiway:
			case AirFacility._AirFacType.Pad:
			case AirFacility._AirFacType.PadWithHaulDown:
				flag = GetAircraft().RunwayLengthNeeded <= airFacility_0.RunwayLength;
				flag2 = (int)GetAircraft().Size <= (int)airFacility_0.EffectiveRunwaySize;
				if ((GetAircraft().Type == Aircraft._AircraftType.UAV || GetAircraft().Type == Aircraft._AircraftType.UCAV) && GetAircraft().RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.CatapultLaunched)
				{
					flag = true;
				}
				break;
			case AirFacility._AirFacType.Catapult:
			case AirFacility._AirFacType.SkiJump:
				if (myUnit.ParentScen.FeatureCompatibility.GetCarrierCapableFlag(myUnit.ParentScen.DBConnection) && GetAircraft().Category != Aircraft._AircraftCategory.CarrierCapable && GetAircraft().Category != Aircraft._AircraftCategory.Helicopter && GetAircraft().Category != Aircraft._AircraftCategory.Tiltrotor)
				{
					return TakeOffCheck.not_catapult_lauchable;
				}
				flag = true;
				flag2 = (int)GetAircraft().Size <= (int)airFacility_0.EffectiveRunwaySize;
				break;
			case AirFacility._AirFacType.const_13:
				flag = GetAircraft().RunwayLengthNeeded <= airFacility_0.RunwayLength;
				flag2 = (int)GetAircraft().Size <= (int)airFacility_0.EffectiveRunwaySize;
				if ((GetAircraft().Type == Aircraft._AircraftType.UAV || GetAircraft().Type == Aircraft._AircraftType.UCAV) && GetAircraft().RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.CatapultLaunched)
				{
					flag = true;
					flag2 = true;
				}
				break;
			case AirFacility._AirFacType.OpenParking:
				flag = GetAircraft().RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.CatapultLaunched;
				flag2 = (int)GetAircraft().Size <= (int)airFacility_0.EffectiveRunwaySize;
				break;
			}
			if (myUnit.Kinematics.GetMaximumAltitude() <= airFacility_0.ParentPlatform.GetCurrentAltitude() + 50f)
			{
				return TakeOffCheck.runway_altitude;
			}
			if (flag)
			{
				if (flag2)
				{
					return TakeOffCheck.OK;
				}
				return TakeOffCheck.runway_is_to_small;
			}
			return TakeOffCheck.unsufficient_runway_length;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100429", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return TakeOffCheck.other_issue;
		}
	}

	internal AirOpsAttemptResult RestartProxy(AirFacility airFacility_0, bool bool_0)
	{
		try
		{
			switch (airFacility_0.AirFacType)
			{
			case AirFacility._AirFacType.RunwayWithArrest:
				if ((int)GetAircraft().Size > (int)airFacility_0.EffectiveRunwaySize)
				{
					return AirOpsAttemptResult.Unsufficient_effective_runway_size;
				}
				break;
			case AirFacility._AirFacType.Catapult:
			case AirFacility._AirFacType.SkiJump:
			case AirFacility._AirFacType.Hangar:
				return AirOpsAttemptResult.Failure_other;
			case AirFacility._AirFacType.CarrierArrestingGear:
				if (myUnit.ParentScen.FeatureCompatibility.GetCarrierCapableFlag(myUnit.ParentScen.DBConnection) && GetAircraft().Category != Aircraft._AircraftCategory.CarrierCapable && GetAircraft().Category != Aircraft._AircraftCategory.Helicopter && GetAircraft().Category != Aircraft._AircraftCategory.Tiltrotor)
				{
					return AirOpsAttemptResult.Failure_other;
				}
				if ((int)GetAircraft().Size > (int)airFacility_0.EffectiveRunwaySize)
				{
					return AirOpsAttemptResult.Unsufficient_effective_runway_size;
				}
				break;
			default:
				if (GetAircraft().RunwayLengthNeeded <= airFacility_0.RunwayLength)
				{
					if ((int)GetAircraft().Size > (int)airFacility_0.EffectiveRunwaySize)
					{
						return AirOpsAttemptResult.Unsufficient_effective_runway_size;
					}
					break;
				}
				return AirOpsAttemptResult.Unsufficient_runway_length;
			case AirFacility._AirFacType.const_13:
				return AirOpsAttemptResult.Success;
			case AirFacility._AirFacType.OpenParking:
				if (GetAircraft().RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.CatapultLaunched)
				{
					if ((int)GetAircraft().Size > (int)airFacility_0.EffectiveRunwaySize)
					{
						return AirOpsAttemptResult.Unsufficient_effective_runway_size;
					}
					break;
				}
				return AirOpsAttemptResult.Unsufficient_runway_length;
			}
			if (!bool_0)
			{
				return airFacility_0.CanHostThisAircraft_BySize(GetAircraft());
			}
			return AirOpsAttemptResult.Success;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100430", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return AirOpsAttemptResult.Failure_Program;
		}
	}

	private TakeOffCheck TestProxy(ActiveUnit activeUnit_0)
	{
		try
		{
			if (Information.IsNothing(activeUnit_0.AirFacilities_ReadOnly))
			{
				return TakeOffCheck.other_issue;
			}
			TakeOffCheck takeOffCheck = TakeOffCheck.other_issue;
			AirFacility[] airFacilities_ReadOnly = activeUnit_0.AirFacilities_ReadOnly;
			AirFacility[] array = airFacilities_ReadOnly;
			foreach (AirFacility airFacility_ in array)
			{
				takeOffCheck = VisitProxy(airFacility_);
				if (takeOffCheck == TakeOffCheck.OK)
				{
					return TakeOffCheck.OK;
				}
			}
			return takeOffCheck;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100431", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return TakeOffCheck.other_issue;
		}
	}

	private AirOpsAttemptResult StopProxy(ActiveUnit activeUnit_0, bool bool_0)
	{
		try
		{
			AirOpsAttemptResult result = AirOpsAttemptResult.Failure_other;
			if (Information.IsNothing(activeUnit_0.AirFacilities_ReadOnly))
			{
				return AirOpsAttemptResult.Failure_other;
			}
			AirFacility[] airFacilities_ReadOnly = activeUnit_0.AirFacilities_ReadOnly;
			AirFacility[] array = airFacilities_ReadOnly;
			foreach (AirFacility airFacility_ in array)
			{
				AirOpsAttemptResult airOpsAttemptResult = RestartProxy(airFacility_, bool_0);
				if (airOpsAttemptResult != 0)
				{
					result = airOpsAttemptResult;
					continue;
				}
				return AirOpsAttemptResult.Success;
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100431", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return AirOpsAttemptResult.Failure_Program;
		}
	}

	private void CancelProxy(AirFacility airFacility_0)
	{
		HostAirFacility = airFacility_0;
		Condition = _AirOpsCondition.TakingOff;
		if (HostAirFacility.AirFacType == AirFacility._AirFacType.Catapult)
		{
			if (GetAircraft().Navigator.HasFlightPlan && !Information.IsNothing(GetAircraft().Navigator.GetFlight().FlightPlan[0].Time_Zulu))
			{
				double totalSeconds = (GetAircraft().Navigator.GetFlight().FlightPlan[0].Time_Zulu.Value - GetAircraft().ParentScen.Time).TotalSeconds;
				if (totalSeconds > 0.0 && totalSeconds <= 180.0)
				{
					ConditionTimer = (float)totalSeconds;
				}
				else
				{
					ConditionTimer = 80f;
				}
			}
			else
			{
				ConditionTimer = 80f;
			}
			return;
		}
		switch (GetAircraft().VisualSizeClass)
		{
		case GlobalVariables.TargetVisualSizeClass.Stealthy:
			ConditionTimer = 30f;
			break;
		case GlobalVariables.TargetVisualSizeClass.VSmall:
			ConditionTimer = 30f;
			break;
		case GlobalVariables.TargetVisualSizeClass.Small:
			ConditionTimer = 30f;
			break;
		case GlobalVariables.TargetVisualSizeClass.Medium:
			ConditionTimer = 30f;
			break;
		case GlobalVariables.TargetVisualSizeClass.Large:
			ConditionTimer = 30f;
			break;
		case GlobalVariables.TargetVisualSizeClass.VLarge:
			ConditionTimer = 30f;
			break;
		}
		if (GetAircraft().RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.CatapultLaunched)
		{
			if (HostAirFacility.AirFacType == AirFacility._AirFacType.const_13)
			{
				ConditionTimer = 120f;
			}
			else if (HostAirFacility.IsOpenAirFacility)
			{
				ConditionTimer = 90f;
			}
			else
			{
				ConditionTimer = 90f;
			}
		}
	}

	private void VerifyProxy(AirFacility airFacility_0, TaxyingFacilityType taxyingFacilityType_0)
	{
		HostAirFacility = airFacility_0;
		switch (taxyingFacilityType_0)
		{
		case (TaxyingFacilityType)0:
			Condition = _AirOpsCondition.TaxyingToTakeOff;
			break;
		case (TaxyingFacilityType)1:
			Condition = _AirOpsCondition.TaxyingToPark;
			break;
		case (TaxyingFacilityType)2:
			Condition = _AirOpsCondition.TaxyingToFlightDeck;
			break;
		}
		if (GetAircraft().Navigator.HasFlightPlan && !Information.IsNothing(GetAircraft().Navigator.GetFlight().FlightPlan[0].Time_Zulu))
		{
			double num = (GetAircraft().Navigator.GetFlight().FlightPlan[0].Time_Zulu.Value - GetAircraft().ParentScen.Time).TotalSeconds - 30.0;
			if (num > 0.0 && num <= 180.0)
			{
				ConditionTimer = (float)num;
				return;
			}
		}
		switch (GetAircraft().VisualSizeClass)
		{
		case GlobalVariables.TargetVisualSizeClass.Stealthy:
			ConditionTimer = 120f;
			break;
		case GlobalVariables.TargetVisualSizeClass.VSmall:
			ConditionTimer = 120f;
			break;
		case GlobalVariables.TargetVisualSizeClass.Small:
			ConditionTimer = 120f;
			break;
		case GlobalVariables.TargetVisualSizeClass.Medium:
			ConditionTimer = 120f;
			break;
		case GlobalVariables.TargetVisualSizeClass.Large:
			ConditionTimer = 120f;
			break;
		case GlobalVariables.TargetVisualSizeClass.VLarge:
			ConditionTimer = 120f;
			break;
		}
	}

	public bool SettleForCargoTransfer()
	{
		try
		{
			if (GetAircraft().IsHelicopter)
			{
				myUnit.Kinematics.DesiredSpeedOverride = null;
				myUnit.DesiredSpeed = 0f;
				myUnit.DesiredAltitude = Math.Max(0, (int)Terrain.GetElevation(myUnit.GetLatitude(), myUnit.GetLongitude(), bool_0: false, myUnit.ParentScen));
				Condition = _AirOpsCondition.TransferringCargo;
				ConditionTimer = Math.Max(240, ActiveUnit_DockingOps.TimeToUnloadCargo(myUnit, myUnit.OnboardCargo.ToList()));
				if (myUnit.GetCurrentAltitude() > myUnit.DesiredAltitude)
				{
					ConditionTimer = 240f;
				}
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10342058231234129034582930467587", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public bool HoverForDippingSonar()
	{
		try
		{
			if (Module_Unit.ResetTokenizer(GetAircraft()))
			{
				return false;
			}
			myUnit.Kinematics.DesiredSpeedOverride = null;
			myUnit.DesiredSpeed = 0f;
			myUnit.DesiredAltitude = 45.72f;
			Condition = _AirOpsCondition.DeployingDippingSonar;
			ConditionTimer = 240f;
			if (myUnit.GetCurrentAltitude() > 45.72f)
			{
				ConditionTimer = 240f;
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100432", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public override void PostDeserializationHousekeeping(ref Scenario scenario_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, bool bool_0)
	{
		try
		{
			if (Information.IsNothing(HostAirFacility) && !string.IsNullOrEmpty(facadeObserver))
			{
				if (concurrentDictionary_0.ContainsKey(facadeObserver))
				{
					HostAirFacility = (AirFacility)concurrentDictionary_0[facadeObserver];
				}
				else
				{
					bool flag = false;
					foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
					{
						if (activeUnits_ == null)
						{
							continue;
						}
						AirFacility[] airFacilities_ReadOnly = activeUnits_.AirFacilities_ReadOnly;
						AirFacility[] array = airFacilities_ReadOnly;
						foreach (AirFacility airFacility in array)
						{
							if (string.CompareOrdinal(airFacility.ObjectID, facadeObserver) == 0)
							{
								HostAirFacility = airFacility;
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							continue;
						}
						break;
					}
				}
			}
			if (!Information.IsNothing(CurrentHostUnit) && !Information.IsNothing(HostAirFacility) && !CurrentHostUnit.AirFacilities_ReadOnly.Contains(HostAirFacility))
			{
				CurrentHostUnit.AirOps.AddThisAircraft((Aircraft)myUnit, bool_0);
			}
			if (Information.IsNothing(CurrentHostUnit) && !string.IsNullOrEmpty(_ReaderObserver))
			{
				foreach (ActiveUnit activeUnits_2 in scenario_0.ActiveUnits_List)
				{
					if (activeUnits_2 != null && Operators.CompareString(activeUnits_2.ObjectID, _ReaderObserver, TextCompare: false) == 0)
					{
						activeUnits_2.AirOps.AddThisAircraft((Aircraft)myUnit, bool_0);
					}
				}
			}
			if (!GetAircraft().IsOperating() && Information.IsNothing(HostAirFacility))
			{
				using IEnumerator<ActiveUnit> enumerator2 = scenario_0.ActiveUnits.Values.GetEnumerator();
				while (enumerator2.MoveNext() && !enumerator2.Current.algoVal.Contains(facadeObserver))
				{
				}
			}
			if (Information.IsNothing(m_PropertyObserver) && !string.IsNullOrEmpty(importerObserver))
			{
				try
				{
					ActiveUnit activeUnit = scenario_0.ActiveUnits[importerObserver];
					if (activeUnit != null)
					{
						SetAssignedHostUnit(bool_0: false, activeUnit);
						if (!GetAircraft().IsOperating() && (Information.IsNothing(HostAirFacility) || Information.IsNothing(CurrentHostUnit)))
						{
							GetAssignedHostUnit().AirOps.AddThisAircraft(GetAircraft(), bool_0);
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200022", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (!string.IsNullOrEmpty(bridgeObserver))
			{
				m_RepositoryObserver = (Aircraft)scenario_0.ActiveUnits[bridgeObserver];
			}
			base.PostDeserializationHousekeeping(ref scenario_0, concurrentDictionary_0, bool_0);
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100433", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public List<Aircraft> GetPotentialTankers(ref bool bool_0, ref ActiveUnit activeUnit_0, bool bool_1, List<Mission> list_0, ref string string_0)
	{
		List<Aircraft> list = new List<Aircraft>();
		int num = 0;
		bool flag;
		Aircraft aircraft;
		if ((activeUnit_0 != null) | ((A2AR_Destination != null) & ManuallySelectedA2AR_Destination))
		{
			flag = false;
			if (activeUnit_0 == null && ((A2AR_Destination != null) & ManuallySelectedA2AR_Destination))
			{
				activeUnit_0 = A2AR_Destination;
			}
			if (activeUnit_0 != null && activeUnit_0.IsAircraft)
			{
				aircraft = (Aircraft)activeUnit_0;
				if (aircraft.IsTanker)
				{
					if (aircraft.IsRTB)
					{
						flag = true;
						if (num < 1)
						{
							num = 1;
							string_0 = "加油机在返回基地。";
						}
					}
					if (Information.IsNothing(AwakeProxy(aircraft, GetAircraft())))
					{
						flag = true;
						if (num < 2)
						{
							num = 2;
							string_0 = "飞机缺乏兼容的空对空加油（AAR）装备。";
						}
					}
					bool bool_2 = false;
					Aircraft_AirOps airOps = aircraft.AirOps;
					if (airOps.RefuellingQueue.ContainsKey(GetAircraft().ObjectID))
					{
						bool_2 = true;
					}
					if (!aircraft.GetHasEnoughFuelToReplenishThisUnit(GetAircraft(), airOps, 0.1f, bool_2))
					{
						flag = true;
						if (num < 11)
						{
							num = 11;
							if (!Information.IsNothing(list_0) && list_0.Count == 1)
							{
								string_0 = "任务加油机" + list_0[0].Name + "没有足够的燃料为更多的接收飞机加油。";
							}
							else
							{
								string_0 = "加油机没有足够的燃料为更多的接收飞机加油。";
							}
						}
					}
					if (aircraft.GetUnitSide() != GetAircraft().GetUnitSide())
					{
						Doctrine._RefuelAlliedUnits? refuelAllies = aircraft.Doctrine.GetRefuelAllies(aircraft.ParentScen, bool_0: false, bool_1: false, bool_2: false);
						byte? b = (byte?)refuelAllies;
						if (!(b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							b = (byte?)refuelAllies;
							if (!(b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
							{
								goto IL_113c;
							}
						}
						flag = true;
						if (num < 5)
						{
							num = 5;
							string_0 = "飞机" + aircraft.Name + "是盟军加油机，不允许为盟军加油。";
						}
					}
				}
				else
				{
					flag = true;
					if (num < 1)
					{
						num = 1;
						string_0 = "Selected unit is not a tanker.";
					}
				}
				goto IL_113c;
			}
			return null;
		}
		try
		{
			ManuallySelectedA2AR_Destination = false;
			Doctrine._UseUnderwayRefuelAndReplenishment? useReplenishment = myUnit.Doctrine.GetUseReplenishment(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			byte? b2 = (byte?)useReplenishment;
			if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				bool flag2 = false;
				Waypoint[] array = null;
				if (myUnit.Navigator.IsOnAutoPlannerPlottedCourse)
				{
					array = myUnit.Navigator.PlottedCourse;
				}
				else if (myUnit.IsGroupWingman() && !Information.IsNothing(myUnit.GetParentGroup().GroupLead) && myUnit.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse)
				{
					array = myUnit.GetParentGroup().GroupLead.Navigator.PlottedCourse;
				}
				if (!Information.IsNothing(array))
				{
					Waypoint[] array2 = array;
					for (int i = 0; i < array2.Length; i = checked(i + 1))
					{
						b2 = (byte?)array2[i].Doctrine.GetUseReplenishment(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
						bool? flag3 = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null);
						if (((!flag3) ?? flag3).GetValueOrDefault())
						{
							flag2 = true;
							break;
						}
					}
				}
				if (!flag2)
				{
					string_0 = "飞机" + myUnit.Name + "有一个不允许空对空加油的条令设置。因此，飞机不会加油。更改条令设置，然后重试。";
					return list;
				}
			}
			else
			{
				b2 = (byte?)useReplenishment;
				if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 0) : null).GetValueOrDefault() && GetAircraft().IsTanker)
				{
					string_0 = "飞机" + myUnit.Name + "是一个加油机，而空对空加油条令设置加油机不允许给加油机加油。因此，飞机不会加油。更改条令设置，然后重试。";
					return list;
				}
			}
			int num2 = 0;
			int num3 = int.MaxValue;
			if (Information.IsNothing(list_0) && !Information.IsNothing(myUnit.AssignedMissionOrPackage()))
			{
				int? num4 = (int?)myUnit.Navigator.PreviousWaypointType;
				if (!(num4.HasValue ? new bool?(num4.GetValueOrDefault() == 14) : null).GetValueOrDefault() && myUnit.AssignedMissionOrPackage().TankerUsage == Mission.TankerMethod.Mission)
				{
					if (myUnit.AssignedMissionOrPackage().TankerMissions.Count <= 0)
					{
						return list;
					}
					list_0 = myUnit.AssignedMissionOrPackage().TankerMissions;
				}
			}
			if (!Information.IsNothing(myUnit.AssignedMissionOrPackage()) && !bool_0)
			{
				num2 = myUnit.AssignedMissionOrPackage().MaxReceiversInQueuePerTanker_Airborne;
				num3 = myUnit.AssignedMissionOrPackage().TankerMaxDistance_Airborne;
			}
			bool flag4 = GetAircraft().IsOperating();
			string_0 = "没有加油机可用。";
			List<ActiveUnit> list2;
			if (bool_0 && !Information.IsNothing(activeUnit_0))
			{
				list2 = new List<ActiveUnit>();
				if (activeUnit_0.IsGroup)
				{
					list2 = ((Group)activeUnit_0).Units.Values.ToList();
				}
				else
				{
					list2.Add(activeUnit_0);
				}
			}
			else
			{
				list2 = GetAircraft().ParentScen.ActiveUnits_List;
			}
			if (list2 != null)
			{
				for (int j = list2.Count - 1; j >= 0; j += -1)
				{
					ActiveUnit activeUnit = list2[j];
					if (activeUnit == null || activeUnit == GetAircraft() || !activeUnit.IsAircraft || (activeUnit.GetUnitSide() != GetAircraft().GetUnitSide() && !Module_Side.IsAlliedWithThisSide(activeUnit.GetUnitSide(), GetAircraft().GetUnitSide())))
					{
						continue;
					}
					Aircraft aircraft2 = (Aircraft)activeUnit;
					if (!aircraft2.IsTanker || !activeUnit.IsOperating())
					{
						continue;
					}
					if (activeUnit.IsRTB)
					{
						if (num < 1)
						{
							num = 1;
							string_0 = "加油机在返回基地。";
						}
						continue;
					}
					if (Information.IsNothing(AwakeProxy(aircraft2, GetAircraft())))
					{
						if (num < 2)
						{
							num = 2;
							string_0 = "飞机缺乏兼容的空对空加油（AAR）装备。";
						}
						continue;
					}
					b2 = (byte?)activeUnit.Doctrine.GetUseReplenishment(activeUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						if (num < 3)
						{
							num = 3;
							string_0 = "飞机" + activeUnit.Name + "有一个条令设置，禁止空对空加油。因此，不会进行加油。更改条令设置，然后重试。";
						}
						continue;
					}
					if (GetAircraft().IsTanker)
					{
						b2 = (byte?)activeUnit.Doctrine.GetUseReplenishment(activeUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
						if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
						{
							if (num < 4)
							{
								num = 4;
								string_0 = "接收飞机" + GetAircraft().Name + "是一艘加油机和空对空加油原则" + activeUnit.Name + "设置为加油机不允许给加油机加油。因此，飞机不会加油。更改条令设置，然后重试。";
							}
							continue;
						}
					}
					if (activeUnit.GetUnitSide() != GetAircraft().GetUnitSide())
					{
						Doctrine._RefuelAlliedUnits? refuelAllies2 = activeUnit.Doctrine.GetRefuelAllies(activeUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
						b2 = (byte?)refuelAllies2;
						if (!(b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							b2 = (byte?)refuelAllies2;
							if (!(b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null).GetValueOrDefault())
							{
								goto IL_0b18;
							}
						}
						if (num < 5)
						{
							num = 5;
							string_0 = "飞机" + activeUnit.Name + "是盟军加油机，不允许为盟军加油。";
						}
						continue;
					}
					goto IL_0b18;
					IL_0b18:
					if (!activeUnit.GetCanPhysicallyReplenishThisUnit(GetAircraft()))
					{
						if (num < 6)
						{
							num = 6;
							string_0 = "飞机" + activeUnit.Name + "是一个加油机，但加油装置错误（boom Vs. probe）。";
						}
						continue;
					}
					if (activeUnit.FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo)
					{
						if (num < 7)
						{
							num = 7;
							string_0 = "飞机" + activeUnit.Name + "已达到Bingo燃料状态，不会向客户卸载燃料。";
						}
						continue;
					}
					if (!Information.IsNothing(list_0))
					{
						if (Information.IsNothing(activeUnit.AssignedMissionOrPackage()))
						{
							continue;
						}
						bool flag5 = true;
						for (int k = list_0.Count - 1; k >= 0; k += -1)
						{
							Mission mission = list_0[k];
							if (activeUnit.AssignedMissionOrPackage() == mission)
							{
								flag5 = false;
								break;
							}
						}
						if (flag5)
						{
							if (num < 8)
							{
								num = 8;
								if (list_0.Count == 1)
								{
									string_0 = "任务" + activeUnit.AssignedMissionOrPackage().Name + "没有可用的加油机。";
								}
								else
								{
									string_0 = "选定的任务中没有可用的加油机。";
								}
							}
							continue;
						}
					}
					bool flag6 = false;
					Aircraft_AirOps airOps2 = ((Aircraft)activeUnit).AirOps;
					if (airOps2.RefuellingQueue.ContainsKey(GetAircraft().ObjectID))
					{
						flag6 = true;
					}
					if (!bool_0 && flag4 && !flag6)
					{
						if (num2 > 0 && airOps2.RefuellingQueue.Count >= num2)
						{
							if (num < 9)
							{
								num = 9;
								if (!Information.IsNothing(list_0) && list_0.Count == 1)
								{
									string_0 = "任务加油机" + list_0[0].Name + "队列已满，不能服务更多的接收飞机。";
								}
								else
								{
									string_0 = "加油机队列已满，不能服务更多的接收飞机。";
								}
							}
							continue;
						}
						if (!Information.IsNothing(activeUnit.AssignedMissionOrPackage()) && activeUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Support)
						{
							SupportMission supportMission = (SupportMission)activeUnit.AssignedMissionOrPackage();
							if (supportMission.A2AR_MaxNumberOfReceiversPerTanker > 0)
							{
								_ = airOps2.A2AR_NumberOfReceiverHookups.Count;
								_ = airOps2.RefuellingQueue.Count;
								_ = airOps2.A2AR_Connections.Count;
								if (!aircraft2.AirOps.FillProxy(supportMission.A2AR_MaxNumberOfReceiversPerTanker, GetAircraft()))
								{
									if (num < 10)
									{
										num = 10;
										if (!Information.IsNothing(list_0) && list_0.Count == 1)
										{
											string_0 = "任务加油机" + list_0[0].Name + "只允许服务" + Conversions.ToString(supportMission.A2AR_MaxNumberOfReceiversPerTanker) + "个接收飞机。这些加油机都不能为更多接收飞机提供服务。";
										}
										else
										{
											string_0 = "加油机只允许服务" + Conversions.ToString(supportMission.A2AR_MaxNumberOfReceiversPerTanker) + "每个加油机的接收返回。没有可用的加油机可以服务更多的接收飞机。";
										}
									}
									continue;
								}
							}
						}
					}
					if (!activeUnit.GetHasEnoughFuelToReplenishThisUnit(GetAircraft(), airOps2, 0.1f, flag6))
					{
						if (num < 11)
						{
							num = 11;
							if (!Information.IsNothing(list_0) && list_0.Count == 1)
							{
								string_0 = "任务加油机" + list_0[0].Name + "没有足够的燃料为更多的接收飞机加油。";
							}
							else
							{
								string_0 = "加油机没有足够的燃料为更多的接收飞机加油。";
							}
						}
						continue;
					}
					float? num5 = null;
					if (!bool_0 && flag4 && !flag6 && num3 != int.MaxValue)
					{
						num5 = Module_Unit.RangeToUnit_Horiz(GetAircraft(), activeUnit);
						float num6 = num3;
						if ((num5.HasValue ? new bool?(num6 < num5.GetValueOrDefault()) : null).GetValueOrDefault())
						{
							if (num < 12)
							{
								num = 12;
								string_0 = "Aircraft" + GetAircraft().Name + "必须在...内" + Conversions.ToString(num3) + "海里的加油机进行加油，但最近的加油机是" + Conversions.ToString((int)Math.Round(num5.Value)) + "海里之外";
							}
							continue;
						}
					}
					if (bool_1)
					{
						if (!num5.HasValue)
						{
							num5 = Module_Unit.RangeToUnit_Horiz(GetAircraft(), activeUnit);
						}
						Aircraft_AI aI = GetAircraft().AI;
						float? nullable_ = num5;
						Aircraft_Navigator navigator = GetAircraft().Navigator;
						bool bool_3 = false;
						float float_ = navigator.OrderProxy(ref bool_3);
						float currentHeading = myUnit.CurrentHeading;
						float? nullable_2 = 2f;
						bool bool_4 = false;
						if (!aI.CanInterceptTarget(activeUnit, nullable_, float_, null, currentHeading, ActiveUnit.Throttle.Cruise, nullable_2, bool_0: true, bool_1: true, ref bool_4))
						{
							if (num < 13)
							{
								num = 13;
								string_0 = "Aircraft" + GetAircraft().Name + "没有足够的燃料到达加油机。或者，在范围内的加油机上排队的接收飞机太多，并且可能没有足够的燃料用于更多的接收飞机。";
							}
							continue;
						}
					}
					list.Add((Aircraft)activeUnit);
				}
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200293", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<Aircraft> result = new List<Aircraft>();
			ProjectData.ClearProjectError();
			return result;
		}
		IL_113c:
		if (flag)
		{
			ManuallySelectedA2AR_Destination = false;
			return new List<Aircraft>();
		}
		ManuallySelectedA2AR_Destination = true;
		list.Add(aircraft);
		return list;
	}

	internal bool ListProxy(Aircraft aircraft_0, ref bool bool_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (GetAircraft().Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				return true;
			}
			if (Information.IsNothing(aircraft_0))
			{
				return false;
			}
			if (aircraft_0 == GetAircraft())
			{
				return false;
			}
			if (!bool_1 && !bool_2 && myUnit.Navigator.IsOnAutoPlannerPlottedCourse && !myUnit.Navigator.PlottedCourse[0].IncludeReponse())
			{
				double num = Module_Unit.RangeToUnit_Horiz_Angular(GetAircraft(), aircraft_0);
				double num2 = Math2.CancelClass(GetAircraft().Navigator.PlottedCourse[0].Latitude, GetAircraft().Navigator.PlottedCourse[0].Longitude, GetAircraft().GetLatitude(), GetAircraft().GetLongitude());
				if (Math2.CancelClass(GetAircraft().Navigator.PlottedCourse[0].Latitude, GetAircraft().Navigator.PlottedCourse[0].Longitude, aircraft_0.GetLatitude(), aircraft_0.GetLongitude()) < num && num > num2)
				{
					bool_0 = true;
					return false;
				}
				float num3 = Math2.PostClass(aircraft_0, GetAircraft());
				if (!bool_0)
				{
					if ((aircraft_0.Navigator.PlottedCourse != null) & (aircraft_0.Navigator.PlottedCourse.Count() > 0))
					{
						if (!ResolveProxy(aircraft_0.Navigator.PlottedCourse, ref bool_0, num3))
						{
							return false;
						}
					}
					else if ((aircraft_0.Navigator.GetFlight().FlightPlan != null) & (aircraft_0.Navigator.GetFlight().FlightPlan.Count() > 0))
					{
						if (!ResolveProxy(aircraft_0.Navigator.GetFlight().FlightPlan, ref bool_0, num3))
						{
							return false;
						}
					}
					else if (aircraft_0.AssignedMissionOrPackage() != null)
					{
						Mission mission = aircraft_0.AssignedMissionOrPackage();
						if (mission.MissionClass == Mission._MissionClass.Support)
						{
							SupportMission supportMission = (SupportMission)mission;
							if (((supportMission.NavigationCourse != null) & (supportMission.NavigationCourse.Count > 0)) && !PostProxy(supportMission.NavigationCourse, ref bool_0, num3))
							{
								return false;
							}
						}
					}
				}
			}
			Aircraft_AI aI = GetAircraft().AI;
			Aircraft_Navigator navigator = GetAircraft().Navigator;
			bool bool_3 = false;
			float float_ = navigator.OrderProxy(ref bool_3);
			float currentHeading = myUnit.CurrentHeading;
			float? nullable_ = 0.25f;
			bool bool_4 = false;
			if (aI.CanInterceptTarget(aircraft_0, null, float_, null, currentHeading, ActiveUnit.Throttle.Cruise, nullable_, bool_0: true, bool_1: true, ref bool_4))
			{
				GetAircraft().Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
				Condition = _AirOpsCondition.ManoeuveringToRefuel;
				A2AR_Destination = aircraft_0;
				if (GetAircraft().IsGroupMember() && GetAircraft().GetParentGroup().Type == Group.GroupType.AirGroup)
				{
					ActiveUnit groupLead = GetAircraft().GetParentGroup().GroupLead;
					_ = ((Aircraft)GetAircraft().GetParentGroup().GroupLead).AirOps;
					if (!Information.IsNothing(aircraft_0))
					{
						foreach (ActiveUnit value in GetAircraft().GetParentGroup().Units.Values)
						{
							if (value != groupLead && value.Status != ActiveUnit._ActiveUnitStatus.Refuelling && value.IsOperating() && value != aircraft_0)
							{
								Aircraft_AirOps airOps = ((Aircraft)value).AirOps;
								value.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
								airOps.Condition = _AirOpsCondition.ManoeuveringToRefuel;
								airOps.A2AR_Destination = aircraft_0;
							}
						}
					}
				}
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100435", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private bool ResolveProxy(Waypoint[] waypoint_0, ref bool bool_0, double double_0)
	{
		for (int i = 0; i < waypoint_0.Length; i = checked(i + 1))
		{
			if ((double)Math2.RunClass(waypoint_0[i], GetAircraft().Navigator.PlottedCourse[0]) < double_0)
			{
				bool_0 = true;
				return false;
			}
		}
		return true;
	}

	private bool PostProxy(List<ReferencePoint> list_0, ref bool bool_0, double double_0)
	{
		foreach (ReferencePoint item in list_0)
		{
			if (!((double)Math2.RunClass(item, GetAircraft().Navigator.PlottedCourse[0]) >= double_0))
			{
				bool_0 = true;
				return false;
			}
		}
		return true;
	}

	private List<string> RunProxy(List<string> list_0)
	{
		List<string> list = list_0.ToList();
		list.Remove(GetAircraft().ObjectID);
		return list;
	}

	internal bool StartProxy(ref ActiveUnit activeUnit_0)
	{
		if (Information.IsNothing(activeUnit_0))
		{
			return false;
		}
		if (activeUnit_0 == GetAircraft())
		{
			return false;
		}
		if (Information.IsNothing(AwakeProxy((Aircraft)activeUnit_0, GetAircraft())))
		{
			return false;
		}
		return true;
	}

	internal bool AssetProxy(GeoPoint geoPoint_0, Doctrine._UnderwayRefuelAndReplenishmentSelection _UnderwayRefuelAndReplenishmentSelection_0, ref bool bool_0, bool bool_1, ref ActiveUnit activeUnit_0, ref List<Mission> list_0, ref string string_0, ref bool bool_2, ref bool bool_3)
	{
		try
		{
			bool num = PrintProxy(geoPoint_0, _UnderwayRefuelAndReplenishmentSelection_0, ref bool_0, bool_1, ref activeUnit_0, ref list_0, ref string_0, ref bool_2, ref bool_3);
			if (num && activeUnit_0 != null && activeUnit_0.AssignedMissionOrPackage() == null)
			{
				ActiveUnit_Navigator navigator = activeUnit_0.Navigator;
				Waypoint[] gparam_ = navigator.PlottedCourse;
				ArrayExtensions.Clear(ref gparam_);
				navigator.PlottedCourse = gparam_;
				ActiveUnit_Navigator navigator2 = activeUnit_0.Navigator;
				gparam_ = navigator2.PlottedCourse;
				ArrayExtensions.Add(ref gparam_, new Waypoint(myUnit.GetLongitude(), myUnit.GetLatitude(), myUnit.GetCurrentAltitude(), Waypoint.WaypointType.Refuel, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
				navigator2.PlottedCourse = gparam_;
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100434", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal bool PrintProxy(GeoPoint geoPoint_0, Doctrine._UnderwayRefuelAndReplenishmentSelection _UnderwayRefuelAndReplenishmentSelection_0, ref bool bool_0, bool bool_1, ref ActiveUnit activeUnit_0, ref List<Mission> list_0, ref string string_0, ref bool bool_2, ref bool bool_3)
	{
		try
		{
			if (!GetAircraft().BoomRefuelling && !GetAircraft().ProbeRefuelling)
			{
				string_0 = "飞机缺乏空对空加油（AAR）能力。";
				return false;
			}
			if (!Information.IsNothing(activeUnit_0))
			{
				if (activeUnit_0 == GetAircraft())
				{
					string_0 = "飞机无法自行加油。";
					return false;
				}
				if (Information.IsNothing(AwakeProxy((Aircraft)activeUnit_0, GetAircraft())))
				{
					string_0 = "飞机缺乏兼容的空对空加油（AAR）装备。";
					return false;
				}
			}
			if (bool_0 && !Information.IsNothing(activeUnit_0))
			{
				if (activeUnit_0.IsGroup)
				{
					if (Information.IsNothing(((Group)activeUnit_0).GroupLead))
					{
						return false;
					}
					activeUnit_0 = ((Group)activeUnit_0).GroupLead;
				}
				if (GetPotentialTankers(ref bool_0, ref activeUnit_0, bool_1: true, list_0, ref string_0).Count == 0)
				{
					return false;
				}
				if (ListProxy((Aircraft)activeUnit_0, ref bool_3, bool_0, bool_1))
				{
					return true;
				}
				string_0 = "无法与选定的加油机会合。";
				return false;
			}
			if (GetAircraft().IsGroupWingman() && GetAircraft().GetParentGroup().Type == Group.GroupType.AirGroup)
			{
				if (myUnit.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && (myUnit.GetParentGroup().GroupLead.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || myUnit.GetParentGroup().GroupLead.Status == ActiveUnit._ActiveUnitStatus.Refuelling))
				{
					return true;
				}
				Aircraft aircraft = (Aircraft)GetAircraft().GetParentGroup().GroupLead;
				if (aircraft.AirOps.AssetProxy(geoPoint_0, _UnderwayRefuelAndReplenishmentSelection_0, ref bool_0, bool_1, ref activeUnit_0, ref list_0, ref string_0, ref bool_2, ref bool_3))
				{
					Aircraft a2AR_Destination = aircraft.AirOps.A2AR_Destination;
					if (!Information.IsNothing(a2AR_Destination))
					{
						foreach (ActiveUnit value in GetAircraft().GetParentGroup().Units.Values)
						{
							if (value != aircraft && value.IsOperating())
							{
								Aircraft_AirOps airOps = ((Aircraft)value).AirOps;
								if (value != a2AR_Destination)
								{
									value.Status = ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint;
									airOps.Condition = _AirOpsCondition.ManoeuveringToRefuel;
									airOps.A2AR_Destination = a2AR_Destination;
								}
							}
						}
					}
					return true;
				}
				return false;
			}
			ActiveUnit activeUnit_ = null;
			List<Aircraft> potentialTankers = GetPotentialTankers(ref bool_0, ref activeUnit_, bool_1: true, list_0, ref string_0);
			if (potentialTankers.Count == 0)
			{
				return false;
			}
			if (!GetAircraft().IsOnReturnLeg && (_UnderwayRefuelAndReplenishmentSelection_0 == Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveOnly || _UnderwayRefuelAndReplenishmentSelection_0 == Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround) && Information.IsNothing(geoPoint_0))
			{
				_UnderwayRefuelAndReplenishmentSelection_0 = Doctrine._UnderwayRefuelAndReplenishmentSelection.PickNearest;
			}
			switch (_UnderwayRefuelAndReplenishmentSelection_0)
			{
			case Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveOnly:
			case Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround:
			{
				if (!bool_2 && geoPoint_0 != null)
				{
					double Local_RangeToTarget_Angular = Module_Unit.RangeToPoint_Horiz_Angular(GetAircraft(), geoPoint_0);
					IEnumerable<Aircraft> source = potentialTankers.Where((Aircraft theT) => Module_Unit.RangeToUnit_Horiz_Angular(GetAircraft(), theT) < Local_RangeToTarget_Angular && Module_Unit.RangeToPoint_Horiz_Angular(theT, geoPoint_0) < Local_RangeToTarget_Angular);
					if (source.Count() <= 0)
					{
						if (_UnderwayRefuelAndReplenishmentSelection_0 == Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround)
						{
							foreach (Aircraft item in potentialTankers.OrderBy((Aircraft theT) => DefineProxy(theT)))
							{
								double num = Module_Unit.RangeToUnit_Horiz_Angular(GetAircraft(), item);
								double num2 = Module_Unit.RangeToPoint_Horiz_Angular(item, geoPoint_0);
								if (num < Local_RangeToTarget_Angular && num2 < Local_RangeToTarget_Angular && ListProxy(item, ref bool_3, bool_0, bool_1))
								{
									activeUnit_0 = item;
									return true;
								}
							}
						}
					}
					else
					{
						foreach (Aircraft item2 in source.OrderBy((Aircraft theT) => DefineProxy(theT)))
						{
							if (ListProxy(item2, ref bool_3, bool_0, bool_1))
							{
								activeUnit_0 = item2;
								return true;
							}
						}
					}
					if (!bool_1 && !myUnit.Navigator.IsOnAutoPlannerPlottedCourse_OnStation && (!myUnit.IsGroupWingman() || Information.IsNothing(myUnit.GetParentGroup().GroupLead) || !myUnit.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_OnStation) && (myUnit.Navigator.IsOnAutoPlannerPlottedCourse || (myUnit.IsGroupWingman() && !Information.IsNothing(myUnit.GetParentGroup().GroupLead) && myUnit.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse)))
					{
						return false;
					}
					break;
				}
				ActiveUnit Local_myHost = ActualDestinationHost;
				if (Information.IsNothing(Local_myHost))
				{
					foreach (Aircraft item3 in potentialTankers.OrderBy((Aircraft theT) => DefineProxy(theT)))
					{
						if (ListProxy(item3, ref bool_3, bool_0, bool_1))
						{
							activeUnit_0 = item3;
							return true;
						}
					}
					break;
				}
				double Local_RangeToBase_Angular = Module_Unit.RangeToUnit_Horiz_Angular(GetAircraft(), Local_myHost);
				IEnumerable<Aircraft> source2 = from theT in potentialTankers
					where Module_Unit.RangeToUnit_Horiz_Angular(GetAircraft(), theT) < Local_RangeToBase_Angular && Module_Unit.RangeToUnit_Horiz_Angular(theT, Local_myHost) < Local_RangeToBase_Angular
					orderby Module_Unit.RangeToUnit_Horiz_Angular(theT, GetAircraft())
					select theT;
				if (source2.Count() <= 0)
				{
					if (_UnderwayRefuelAndReplenishmentSelection_0 != Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround)
					{
						break;
					}
					if (GetAircraft().GetIsBingoTowardsThisDestination(Local_myHost, null, GetAircraft().Doctrine.GetBingoJoker(GetAircraft().ParentScen, bool_0: false, bool_1: true, bool_2: false, bool_3: false)) == ActiveUnit._ActiveUnitFuelState.IsBingo)
					{
						foreach (Aircraft item4 in potentialTankers.OrderBy((Aircraft theT) => DefineProxy(theT)))
						{
							double num3 = Module_Unit.RangeToUnit_Horiz_Angular(GetAircraft(), item4);
							double num4 = Module_Unit.RangeToUnit_Horiz_Angular(item4, Local_myHost);
							if (num3 < Local_RangeToBase_Angular && num4 < Local_RangeToBase_Angular && ListProxy(item4, ref bool_3, bool_0, bool_1))
							{
								activeUnit_0 = item4;
								return true;
							}
						}
						return false;
					}
					return false;
				}
				foreach (Aircraft item5 in source2.OrderBy((Aircraft theT) => DefineProxy(theT)))
				{
					if (ListProxy(item5, ref bool_3, bool_0, bool_1))
					{
						activeUnit_0 = item5;
						return true;
					}
				}
				break;
			}
			case Doctrine._UnderwayRefuelAndReplenishmentSelection.PickNearest:
				foreach (Aircraft item6 in potentialTankers.OrderBy((Aircraft theT) => DefineProxy(theT)))
				{
					if (ListProxy(item6, ref bool_3, bool_0, bool_1))
					{
						activeUnit_0 = item6;
						return true;
					}
				}
				break;
			}
			if (_UnderwayRefuelAndReplenishmentSelection_0 != Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveOnly)
			{
				foreach (Aircraft item7 in potentialTankers.OrderBy((Aircraft theT) => Module_Unit.RangeToUnit_Horiz_Angular(theT, GetAircraft())))
				{
					if (ListProxy(item7, ref bool_3, bool_0, bool_1))
					{
						activeUnit_0 = item7;
						return true;
					}
				}
			}
			string_0 = "找不到合适的加油机。";
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100436", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private int DefineProxy(Aircraft aircraft_0)
	{
		float val = GetAircraft().ETA_To_Location(GetAircraft().CurrentSpeed, Module_Unit.RangeToPoint_Horiz(GetAircraft(), aircraft_0.GetLatitude(), aircraft_0.GetLongitude()));
		Aircraft_AirOps airOps = aircraft_0.AirOps;
		List<string> list = airOps.RefuellingQueue.Keys.ToList();
		foreach (string item in list)
		{
			Aircraft aircraft = (Aircraft)GetAircraft().ParentScen.ActiveUnits[item];
			if (Information.IsNothing(aircraft) || aircraft.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
			{
				ConcurrentDictionary<string, byte> refuellingQueue = airOps.RefuellingQueue;
				byte value = 0;
				refuellingQueue.TryRemove(item, out value);
			}
		}
		float num = 0f;
		foreach (string item2 in list)
		{
			Aircraft aircraft2 = (Aircraft)GetAircraft().ParentScen.ActiveUnits[item2];
			if (!aircraft2.IsDestroyed)
			{
				GEnum6? nullable_ = AwakeProxy(aircraft_0, aircraft2);
				float num2 = FindProxy(aircraft2, nullable_);
				float num3 = (float)aircraft2.FuelCapacityMax / num2;
				num += num3;
			}
		}
		return (int)Math.Round(Math.Max(val, num));
	}

	public bool AttemptToConnectToTanker(bool bool_0)
	{
		try
		{
			if (Information.IsNothing(A2AR_Destination))
			{
				return false;
			}
			if (!bool_0 && Module_Unit.RangeToUnit_Horiz(GetAircraft(), A2AR_Destination) > TankerHookUpDistance)
			{
				return false;
			}
			if (A2AR_Destination.AirOps.GetHasAvailableRefuelSlotForThisAircraft(GetAircraft(), bool_0))
			{
				PublishProxy(bool_0);
				return true;
			}
			if (GetAircraft().IsGroupMember())
			{
				foreach (ActiveUnit value in GetAircraft().GetParentGroup().Units.Values)
				{
					if (value.Status == ActiveUnit._ActiveUnitStatus.Refuelling && ((Aircraft)value).AirOps.A2AR_Destination == A2AR_Destination)
					{
						PublishProxy(bool_0);
						return true;
					}
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100437", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private void PublishProxy(bool bool_0)
	{
		try
		{
			Aircraft_AirOps airOps = A2AR_Destination.AirOps;
			if (Information.IsNothing(GetAircraft()))
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			else if (string.IsNullOrEmpty(GetAircraft().ObjectID) && Debugger.IsAttached)
			{
				Debugger.Break();
			}
			if (GetAircraft().BoomRefuelling)
			{
				if (airOps.A2AR_Connections.ContainsKey(GetAircraft().ObjectID))
				{
					airOps.A2AR_Connections[GetAircraft().ObjectID] = GEnum6.Boom;
				}
				else
				{
					airOps.A2AR_Connections.TryAdd(GetAircraft().ObjectID, GEnum6.Boom);
				}
				GetAircraft().Status = ActiveUnit._ActiveUnitStatus.Refuelling;
				airOps.Condition = _AirOpsCondition.OffloadingFuel;
				ConcurrentDictionary<string, byte> refuellingQueue = airOps.RefuellingQueue;
				string objectID = GetAircraft().ObjectID;
				byte value = 0;
				refuellingQueue.TryRemove(objectID, out value);
			}
			else
			{
				if (!GetAircraft().ProbeRefuelling)
				{
					return;
				}
				if (airOps.A2AR_Connections.ContainsKey(GetAircraft().ObjectID))
				{
					if (A2AR_Destination.HasBuddyStore)
					{
						airOps.A2AR_Connections[GetAircraft().ObjectID] = GEnum6.BuddyDrogue;
					}
					else
					{
						airOps.A2AR_Connections[GetAircraft().ObjectID] = GEnum6.Drogue;
					}
				}
				else if (A2AR_Destination.HasBuddyStore)
				{
					airOps.A2AR_Connections.TryAdd(GetAircraft().ObjectID, GEnum6.BuddyDrogue);
				}
				else
				{
					airOps.A2AR_Connections.TryAdd(GetAircraft().ObjectID, GEnum6.Drogue);
				}
				GetAircraft().Status = ActiveUnit._ActiveUnitStatus.Refuelling;
				airOps.Condition = _AirOpsCondition.OffloadingFuel;
				ConcurrentDictionary<string, byte> refuellingQueue2 = airOps.RefuellingQueue;
				string objectID2 = GetAircraft().ObjectID;
				byte value2 = 0;
				refuellingQueue2.TryRemove(objectID2, out value2);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100438", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private GEnum6? AwakeProxy(Aircraft aircraft_0, Aircraft aircraft_1)
	{
		if (aircraft_1.BoomRefuelling && aircraft_0.CenterlineBoom)
		{
			return GEnum6.Boom;
		}
		if (aircraft_1.ProbeRefuelling && (aircraft_0.CenterlineDrogue || aircraft_0.WingDrogue))
		{
			return GEnum6.Drogue;
		}
		if (aircraft_0.HasBuddyStore && aircraft_1.ProbeRefuelling)
		{
			return GEnum6.BuddyDrogue;
		}
		return null;
	}

	[SpecialName]
	private bool CanBoomRefuellingToAircraft(Aircraft aircraft_0, bool bool_0)
	{
		bool result = false;
		try
		{
			if (aircraft_0.BoomRefuelling)
			{
				if (bool_0 && aircraft_0.IsGroupWingman())
				{
					result = true;
					return true;
				}
				if (GetAircraft().CenterlineBoom)
				{
					foreach (KeyValuePair<string, GEnum6> a2AR_Connection in A2AR_Connections)
					{
						if (a2AR_Connection.Value == GEnum6.Boom)
						{
							result = false;
							return false;
						}
					}
					result = true;
					return true;
				}
				result = false;
				return false;
			}
			result = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100439", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private float QueryProxy(Aircraft aircraft_0)
	{
		if (aircraft_0 == null)
		{
			return 1f;
		}
		if (aircraft_0.ProbeRefuelling)
		{
			float num = 0f;
			if (GetAircraft().HasBuddyStore)
			{
				num += 1f;
			}
			if (GetAircraft().CenterlineDrogue)
			{
				num += 1f;
			}
			if (GetAircraft().WingDrogue)
			{
				num += 2f;
			}
			if (num <= 0f)
			{
				return 1f;
			}
			float num2 = 0f;
			foreach (KeyValuePair<string, GEnum6> a2AR_Connection in A2AR_Connections)
			{
				if (a2AR_Connection.Value == GEnum6.Drogue)
				{
					num2 += 1f;
				}
				else if (a2AR_Connection.Value == GEnum6.BuddyDrogue)
				{
					num2 += 1f;
				}
				else if (a2AR_Connection.Value == GEnum6.Boom)
				{
					num2 += 1f;
				}
			}
			if (num2 <= 0f)
			{
				return 0f;
			}
			return num2 / num;
		}
		return 1f;
	}

	[SpecialName]
	private bool CanProbeRefuellingToAircraft(Aircraft aircraft_0, bool bool_0)
	{
		bool result = false;
		try
		{
			if (aircraft_0 == null)
			{
				result = false;
				return false;
			}
			if (aircraft_0.ProbeRefuelling)
			{
				if (bool_0 && aircraft_0.IsGroupWingman())
				{
					result = true;
					return true;
				}
				return result = (double)QueryProxy(aircraft_0) < 1.0;
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100440", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public bool GetHasAvailableRefuelSlotForThisAircraft(Aircraft aircraft_0, bool bool_0)
	{
		try
		{
			if (GetAircraft().IsTanker)
			{
				if (GetAircraft().GetCanPhysicallyReplenishThisUnit(aircraft_0))
				{
					if (!bool_0)
					{
						List<string> list = new List<string>();
						bool flag = true;
						foreach (KeyValuePair<string, GEnum6> a2AR_Connection in A2AR_Connections)
						{
							if (!Information.IsNothing(a2AR_Connection.Key))
							{
								Aircraft aircraft = (Aircraft)GetAircraft().ParentScen.ActiveUnits[a2AR_Connection.Key];
								if (Information.IsNothing(aircraft))
								{
									list.Add(a2AR_Connection.Key);
								}
								else if ((int)aircraft.Size >= 30)
								{
									flag = false;
									break;
								}
							}
						}
						foreach (string item in list)
						{
							ConcurrentDictionary<string, GEnum6> a2AR_Connections = A2AR_Connections;
							GEnum6 value = GEnum6.Drogue;
							a2AR_Connections.TryRemove(item, out value);
						}
						if (!flag)
						{
							return false;
						}
					}
					if (CanBoomRefuellingToAircraft(aircraft_0, bool_0))
					{
						return true;
					}
					if (CanProbeRefuellingToAircraft(aircraft_0, bool_0))
					{
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100441", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public void UnloadCargoParadrop()
	{
		Cargo.UnloadCargoAtLocation(myUnit, ref myUnit.OnboardCargo, myUnit.CargoTransferList, myUnit.GetLatitude(), myUnit.GetLongitude(), myUnit.ParentScen, myUnit.GetUnitSide(), bool_0: true);
		myUnit.CargoTransferList = null;
	}

	public void UnloadCargo()
	{
		Cargo.UnloadCargoAtLocation(myUnit, ref myUnit.OnboardCargo, myUnit.CargoTransferList, myUnit.GetLatitude(), myUnit.GetLongitude(), myUnit.ParentScen, myUnit.GetUnitSide(), bool_0: false);
		myUnit.CargoTransferList = null;
	}

	public void PickupCargoFromSource(ActiveUnit activeUnit_0)
	{
		List<CargoManifestItem> list = Cargo.GenerateCargoManifest(activeUnit_0);
		if (list.Count > 0)
		{
			List<Cargo> list2 = ActiveUnit_DockingOps.DetermineFeasibleCargoTransferManifest((ICargoHost)activeUnit_0, (ICargoHost)myUnit, list);
			if (list2.Count > 0)
			{
				ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(activeUnit_0, myUnit, list2);
			}
		}
		myUnit.AI.RemovePickupTarget(activeUnit_0.ObjectID);
	}

	public int CalculateETIC()
	{
		int num = 0;
		switch (GetAircraft().Damage.FireIntensity)
		{
		case ActiveUnit_Damage.FireIntensityLevel.Minor:
			num = 900;
			break;
		case ActiveUnit_Damage.FireIntensityLevel.Major:
			num = 1800;
			break;
		case ActiveUnit_Damage.FireIntensityLevel.Severe:
			num = 2700;
			break;
		case ActiveUnit_Damage.FireIntensityLevel.Conflagration:
			num = 3600;
			break;
		}
		int num2 = (int)Math.Round(GetAircraft().Damage.DamagePercent / 100f * 86400f);
		switch (GetAircraft().Size)
		{
		case GlobalVariables.AircraftSizeClass.UAS_Class2:
			num2 = (int)Math.Round((double)num2 * 0.75);
			break;
		case GlobalVariables.AircraftSizeClass.UAS_Class1_Micro:
		case GlobalVariables.AircraftSizeClass.UAS_Class1_Mini:
		case GlobalVariables.AircraftSizeClass.UAS_Class1_Small:
			num2 = (int)Math.Round((double)num2 * 0.5);
			break;
		case GlobalVariables.AircraftSizeClass.VLarge:
			num2 *= 3;
			break;
		case GlobalVariables.AircraftSizeClass.Large:
			num2 *= 2;
			break;
		case GlobalVariables.AircraftSizeClass.Medium:
			num2 = (int)Math.Round((double)num2 * 1.5);
			break;
		}
		int num3 = 0;
		foreach (PlatformComponent item in GetAircraft().OrderIssuer())
		{
			if (item.Status == PlatformComponent._ComponentStatus.Operational)
			{
				continue;
			}
			if (item.IsCargo)
			{
				if (item.Status == PlatformComponent._ComponentStatus.Destroyed)
				{
					num3 += 3600;
					continue;
				}
				switch (item.DamageSeverity)
				{
				case PlatformComponent._DamageSeverityFactor.Light:
					num3 += 900;
					break;
				case PlatformComponent._DamageSeverityFactor.Medium:
					num3 += 1800;
					break;
				case PlatformComponent._DamageSeverityFactor.Heavy:
					num3 += 2700;
					break;
				}
			}
			else if (item.IsCIC)
			{
				if (item.Status == PlatformComponent._ComponentStatus.Destroyed)
				{
					num3 += 10800;
					continue;
				}
				switch (item.DamageSeverity)
				{
				case PlatformComponent._DamageSeverityFactor.Light:
					num3 += 2700;
					break;
				case PlatformComponent._DamageSeverityFactor.Medium:
					num3 += 5400;
					break;
				case PlatformComponent._DamageSeverityFactor.Heavy:
					num3 += 8100;
					break;
				}
			}
			else if (!item.IsCommDevice && !item.IsSensor && !item.IsMount)
			{
				if (!item.IsEngine)
				{
					continue;
				}
				if (item.Status == PlatformComponent._ComponentStatus.Destroyed)
				{
					num3 += 14400;
					continue;
				}
				switch (item.DamageSeverity)
				{
				case PlatformComponent._DamageSeverityFactor.Light:
					num3 += 3600;
					break;
				case PlatformComponent._DamageSeverityFactor.Medium:
					num3 += 7200;
					break;
				case PlatformComponent._DamageSeverityFactor.Heavy:
					num3 += 10800;
					break;
				}
			}
			else if (item.Status == PlatformComponent._ComponentStatus.Destroyed)
			{
				num3 += 14400;
			}
			else
			{
				switch (item.DamageSeverity)
				{
				case PlatformComponent._DamageSeverityFactor.Light:
					num3 += 3600;
					break;
				case PlatformComponent._DamageSeverityFactor.Medium:
					num3 += 7200;
					break;
				case PlatformComponent._DamageSeverityFactor.Heavy:
					num3 += 10800;
					break;
				}
			}
		}
		return num + num2 + num3;
	}

	[CompilerGenerated]
	private double ResetProxy(ActiveUnit activeUnit_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(activeUnit_0, consumerObserver.ParentPlatform);
	}

	[CompilerGenerated]
	private double MapProxy(ActiveUnit activeUnit_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(activeUnit_0, myUnit);
	}
}
