using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Command_Core.DAL;
using Easy.Common;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua.Exceptions;

namespace Command_Core;

public abstract class Mission : ScenarioObject
{
	public class TriggerOperationWrapper
	{
		public bool Value;

		public bool ConditionalOperator;

		public TriggerOperationWrapper(bool bool_0, bool bool_1)
		{
			Value = bool_0;
			ConditionalOperator = bool_1;
		}
	}

	public enum TankerMethod : byte
	{
		Automatic,
		Mission
	}

	public enum MissionCategory
	{
		Mission,
		Package,
		TaskPool
	}

	public delegate void StartTimeChangedEventHandler(Mission theM);

	public delegate void EndTimeChangedEventHandler(Mission theM);

	public delegate void TakeOffTimeChangedEventHandler(Mission theM);

	public delegate void TimeOnTargetChangedEventHandler(Mission theM);

	public enum MissionMovementStyle
	{
		RandomWithinArea,
		RepeatableLoop
	}

	public enum _FlightQty
	{
		NoPreferences = 0,
		All = -99,
		None = -100,
		Flight_x1 = -97,
		Flight_x2 = -96,
		Flight_x3 = -95,
		Flight_x4 = -94,
		Flight_x6 = -93,
		Flight_x8 = -92,
		Flight_x12 = -91,
		Aircraft_x1 = -87,
		Aircraft_x2 = -86,
		Aircraft_x3 = -85,
		Aircraft_x4 = -84,
		Aircraft_x6 = -83,
		Aircraft_x8 = -82,
		Aircraft_x12 = -81
	}

	public enum MissionAssignmentAttemptResult
	{
		None,
		Success,
		Fail_OutOfComms,
		Fail_Other
	}

	public enum _MissionClass : byte
	{
		None,
		Strike,
		Patrol,
		Support,
		Ferry,
		Mining,
		MineClearing,
		Escort,
		Cargo
	}

	public enum MissionStatus : byte
	{
		Active,
		Inactive
	}

	public enum _BingoFuelSetting : byte
	{
		UseLoadoutSetting,
		ExpendJettison,
		BringBack
	}

	public struct _FlightSize
	{
		public int value;

		public const int None = 0;

		public const int SingleAircraft = 1;

		public const int TwoAircraft = 2;

		public const int ThreeAircraft = 3;

		public const int FourAircraft = 4;

		public const int SixAircraft = 6;

		public _FlightSize(int int_0)
		{
			this = default(_FlightSize);
			value = int_0;
		}

		public static implicit operator int(_FlightSize _FlightSize_0)
		{
			return _FlightSize_0.value;
		}

		public static implicit operator _FlightSize(int int_0)
		{
			_FlightSize flightSize = default(_FlightSize);
			flightSize = new _FlightSize(int_0);
			flightSize.value = int_0;
			return flightSize;
		}

		public static bool operator ==(_FlightSize _FlightSize_0, int int_0)
		{
			if (_FlightSize_0.value == int_0)
			{
				return true;
			}
			return false;
		}

		public static bool operator !=(_FlightSize _FlightSize_0, int int_0)
		{
			if (_FlightSize_0.value == int_0)
			{
				return false;
			}
			return true;
		}

		public static int operator -(_FlightSize _FlightSize_0, int int_0)
		{
			return _FlightSize_0.value - int_0;
		}

		public static bool operator <(_FlightSize _FlightSize_0, _FlightSize _FlightSize_1)
		{
			return _FlightSize_0.value < _FlightSize_1.value;
		}

		public static bool operator >(_FlightSize _FlightSize_0, _FlightSize _FlightSize_1)
		{
			return _FlightSize_0.value > _FlightSize_1.value;
		}

		public static bool operator <=(_FlightSize _FlightSize_0, _FlightSize _FlightSize_1)
		{
			return _FlightSize_0.value <= _FlightSize_1.value;
		}

		public static bool operator >=(_FlightSize _FlightSize_0, _FlightSize _FlightSize_1)
		{
			return _FlightSize_0.value >= _FlightSize_1.value;
		}
	}

	public struct _GroupSize
	{
		public int value;

		public const int None = 0;

		public const int SingleVessel = 1;

		public const int TwoVessels = 2;

		public const int ThreeVessels = 3;

		public const int FourVessels = 4;

		public const int SixVessels = 6;

		public _GroupSize(int int_0)
		{
			this = default(_GroupSize);
			value = int_0;
		}

		public static implicit operator int(_GroupSize _GroupSize_0)
		{
			return _GroupSize_0.value;
		}

		public static implicit operator _GroupSize(int int_0)
		{
			_GroupSize groupSize = default(_GroupSize);
			groupSize = new _GroupSize(int_0);
			groupSize.value = int_0;
			return groupSize;
		}

		public static bool operator ==(_GroupSize _GroupSize_0, int int_0)
		{
			if (_GroupSize_0.value == int_0)
			{
				return true;
			}
			return false;
		}

		public static bool operator !=(_GroupSize _GroupSize_0, int int_0)
		{
			if (_GroupSize_0.value == int_0)
			{
				return false;
			}
			return true;
		}

		public static int operator -(_GroupSize _GroupSize_0, int int_0)
		{
			return _GroupSize_0.value - int_0;
		}

		public static bool operator <(_GroupSize _GroupSize_0, _GroupSize _GroupSize_1)
		{
			return _GroupSize_0.value < _GroupSize_1.value;
		}

		public static bool operator >(_GroupSize _GroupSize_0, _GroupSize _GroupSize_1)
		{
			return _GroupSize_0.value > _GroupSize_1.value;
		}

		public static bool operator <=(_GroupSize _GroupSize_0, _GroupSize _GroupSize_1)
		{
			return _GroupSize_0.value <= _GroupSize_1.value;
		}

		public static bool operator >=(_GroupSize _GroupSize_0, _GroupSize _GroupSize_1)
		{
			return _GroupSize_0.value >= _GroupSize_1.value;
		}
	}

	public enum _AircraftFormationType
	{
		NoFormation = 1
	}

	public enum _RadarBehaviour
	{
		None,
		UseMissionEMCON,
		ActiveOnIP,
		ActiveOnAttackIngressAndIP
	}

	public enum _FlightTask
	{
		None = 0,
		Strike_Land = 1,
		Strike_Naval = 2,
		Strike_OCA = 3,
		Strike_SEAD = 4,
		Sweep_Fighter = 5,
		Sweep_SEAD = 6,
		BAI = 7,
		CAS = 8,
		CAP = 9,
		TARCAP = 10,
		BARCAP = 11,
		GLI = 12,
		DLI = 13,
		Escort_FighterSweep = 14,
		Escort_TARCAP = 15,
		Escort_SEAD = 16,
		ASAT = 17,
		AirborneLaser = 18,
		Buddy_Illumination = 19,
		OECM = 20,
		AEW = 21,
		CommandPost = 22,
		ChaffLaying = 23,
		SearchAndRescue = 24,
		CombatSearchAndRescue = 25,
		MineSweeping = 26,
		MineRecon = 27,
		NavalMineLaying = 28,
		ASW = 29,
		Forward_Observer = 30,
		Area_Surveillance = 31,
		Armed_Recon = 32,
		Unarmed_Recon = 33,
		Maritime_Surveillance = 34,
		Paratroopers = 35,
		Troop_Transport = 36,
		Cargo = 37,
		AirRefueling = 38,
		Training = 39,
		TargetTow = 40,
		TargetDrone = 41,
		Ferry = 42,
		HAVCAP = 44,
		RESCAP = 45,
		Strike_Interdiction = 46,
		Support = 47,
		Escort_Support = 48,
		QRA = 49
	}

	public enum _FlightType
	{
		Flightplan,
		FlightplanTemplate
	}

	public enum _AttackMethod
	{
		None = -1,
		Formation_SingleAim,
		Formation_IndependentAim,
		SplitAtActionPoint,
		EchelonAtActionPoint,
		MultiAxisSimultaneousToT,
		MultiAxisStackedToT_Echelon_20Sec,
		MultiAxisStackedToT_Echelon_30Sec,
		MultiAxisStackedToT_Echelon_40Sec,
		MultiAxisStackedToT_Split_20Sec,
		MultiAxisStackedToT_Split_30Sec,
		MultiAxisStackedToT_Split_40Sec,
		SingleAxisStackedToT_20Sec,
		SingleAxisStackedToT_30Sec,
		SingleAxisStackedToT_40Sec,
		BananaSplit
	}

	public enum _SplitDistance
	{
		Close_10nm,
		Typical_20nm,
		Long_50nm
	}

	public enum _ContinousCoverageMethod
	{
		Dynamic,
		FlightplanTemplates
	}

	public enum _ContinousCoverageStationTime
	{
		min_15,
		min_20,
		min_30,
		min_40,
		min_45,
		min_50,
		hr_1,
		hr_1_min_15,
		hr_1_min_30,
		hr_1_min_45,
		hr_2,
		hr_2_min_15,
		hr_2_min_30,
		hr_2_min_45,
		hr_3,
		hr_3_min_30,
		hr_4,
		hr_5,
		hr_6,
		hr_8,
		hr_10,
		hr_12
	}

	public enum _ContinousCoverageOverlap
	{
		None,
		Min_2,
		Min_5
	}

	public enum _ContinousCoverageDuration
	{
		hr_2,
		hr_4,
		hr_6,
		hr_12,
		hr_24
	}

	public enum _GroupQty
	{
		NoPreferences = 0,
		All = -99,
		None = -100,
		Group_x1 = -97,
		Group_x2 = -96,
		Group_x3 = -95,
		Group_x4 = -94,
		Group_x6 = -93,
		Group_x8 = -92,
		Group_x12 = -91,
		Boat_x1 = -87,
		Boat_x2 = -86,
		Boat_x3 = -85,
		Boat_x4 = -84,
		Boat_x6 = -83,
		Boat_x8 = -82,
		Boat_x12 = -81
	}

	public enum _FlightPriority
	{
		None,
		Mandatory
	}

	public enum _FlightStatus
	{
		None,
		LookingForAvailableAircraft,
		WaitingForPackageActivation,
		WaitingForAircraftToBecomeReady,
		TakingOff,
		Airborne,
		Completed,
		PackageEnded,
		Airborne_EgressLeg
	}

	public enum _FlightCreatedBy
	{
		None,
		MissionAI,
		Player
	}

	public enum _TankerFollowsReceiver
	{
		UntilFull = 0,
		Waypoint1 = 1,
		Waypoint2 = 2,
		Weaypoin3 = 3,
		UntilHoldWaypoint = -97,
		UntilStationWaypoint = -98,
		UntilLandingMarshalWaypoint = -99
	}

	public enum _TargeteeringMethod
	{
		Mission,
		Flight,
		Individual
	}

	public sealed class Flight : ScenarioObject
	{
		public enum FlightElement : byte
		{
			None = 0,
			LeadElement = 1,
			LeadElementWingman = 2,
			SecondElement = 3,
			SecondElementWingman = 4,
			ThirdElement = 5,
			ThirdElementWingman = 6,
			Other = 99
		}

		[CompilerGenerated]
		private sealed class SerializerMapping
		{
			public Waypoint.WaypointType waypointType_0;

			internal bool RemoveInterruptiblePolicy(Waypoint theWP)
			{
				return theWP.Type == waypointType_0;
			}
		}

		public string ParentMissionOrPackageObjectID;

		public string ParentMissionOrPackageName;

		public string Callsign;

		public _FlightTask Task;

		public _FlightType Type;

		public string TakeOffLocation_HostUnitObjectID;

		public string TakeOffLocation_HostUnitObjectName;

		public string LandingLocation_HostUnitObjectID;

		public string LandingLocation_HostUnitObjectName;

		public string AlternativeLandingLocation_HostUnitObjectID;

		public string AlternativeLandingLocation_HostUnitObjectName;

		public List<MDSP_Error> ErrorList;

		public List<string> NotificationList;

		private bool invocationItem;

		public DateTime? EarliestTaskingTime;

		public DateTime? LatestTaskingTime;

		public float MaxReadyTime;

		public DateTime? EarliestLaunchTime;

		public DateTime? LatestLaunchTime;

		public bool IsEscort;

		public _FlightPriority Priority;

		private _FlightStatus m_ClassItem;

		public _FlightCreatedBy CreatedBy;

		public _FlightCreatedBy EditedBy;

		public _FlightSize DesiredAircraftQty;

		public _FlightSize MinimumAircraftQty;

		public int ReadyAircraftQty;

		public bool UsedByFlight;

		private ActiveUnit m_RequestItem;

		public int ReferenceUnit_DBID;

		public string ReferenceUnit_ObjectID;

		public string ReferenceUnit_Name;

		public int int_0;

		private string valueItem;

		protected Waypoint[] _FlightPlan;

		protected Waypoint[] _FlightPlan_Pathfinder_Ingress_1;

		protected Waypoint[] _FlightPlan_Pathfinder_Ingress_2;

		protected Waypoint[] _FlightPlan_Pathfinder_Egress_1;

		protected Waypoint[] _FlightPlan_Pathfinder_Egress_2;

		public Mission TaskPool;

		public string TaskPool_ID;

		public string TaskPool_Name;

		public string TakeOffTimeZuluString;

		public string TakeOffTimeLocalString;

		public string ObjectiveTimeZuluString;

		public string ObjectiveTimeLocalString;

		public Waypoint.FixedFree TakeOffWaypointFixedTime;

		public Waypoint.FixedFree ObjectiveWaypointFixedTime;

		public int Age;

		public Contact PrimaryTarget;

		public string PrimaryTarget_ID;

		public bool Pathfinder_Ingress_RequestBeingProcessed;

		public bool Pathfinder_Egress_RequestBeingProcessed;

		public bool PathfinderRequestBeingProcessed_OnThisPulse;

		public bool FlightCannotLaunch;

		public string FlightCannotLaunch_Feedback;

		public bool Departed;

		public bool Landed;

		public bool HasCriticalError
		{
			get
			{
				return invocationItem;
			}
			set
			{
				invocationItem = value;
			}
		}

		public Waypoint[] FlightPlan
		{
			get
			{
				return _FlightPlan;
			}
			set
			{
				_FlightPlan = value;
			}
		}

		public Waypoint[] FlightPlan_Pathfinder_Ingress_1
		{
			get
			{
				return _FlightPlan_Pathfinder_Ingress_1;
			}
			set
			{
				_FlightPlan_Pathfinder_Ingress_1 = value;
			}
		}

		public Waypoint[] FlightPlan_Pathfinder_Ingress_2
		{
			get
			{
				return _FlightPlan_Pathfinder_Ingress_2;
			}
			set
			{
				_FlightPlan_Pathfinder_Ingress_2 = value;
			}
		}

		public Waypoint[] FlightPlan_Pathfinder_Egress_1
		{
			get
			{
				return _FlightPlan_Pathfinder_Egress_1;
			}
			set
			{
				_FlightPlan_Pathfinder_Egress_1 = value;
			}
		}

		public Waypoint[] FlightPlan_Pathfinder_Egress_2
		{
			get
			{
				return _FlightPlan_Pathfinder_Egress_2;
			}
			set
			{
				_FlightPlan_Pathfinder_Egress_2 = value;
			}
		}

		[SpecialName]
		public List<ActiveUnit> GetAUCurrentlyAssigned(Mission mission_0, Scenario scenario_0)
		{
			return (from activeUnit_0 in (from x in Module_Mission.AssetTokenizer(mission_0, scenario_0)
					where !Information.IsNothing(x.Navigator.GetFlight())
					select x).ToList()
				where Operators.CompareString(activeUnit_0.Navigator.GetFlight().Callsign, Callsign, TextCompare: false) == 0
				select activeUnit_0).ToList();
		}

		public Flight()
		{
			invocationItem = false;
			UsedByFlight = false;
			_FlightPlan = new Waypoint[0];
			_FlightPlan_Pathfinder_Ingress_1 = new Waypoint[0];
			_FlightPlan_Pathfinder_Ingress_2 = new Waypoint[0];
			_FlightPlan_Pathfinder_Egress_1 = new Waypoint[0];
			_FlightPlan_Pathfinder_Egress_2 = new Waypoint[0];
			TakeOffTimeZuluString = "-";
			TakeOffTimeLocalString = "-";
			ObjectiveTimeZuluString = "-";
			ObjectiveTimeLocalString = "-";
			TakeOffWaypointFixedTime = Waypoint.FixedFree.None;
			ObjectiveWaypointFixedTime = Waypoint.FixedFree.None;
			Pathfinder_Ingress_RequestBeingProcessed = false;
			Pathfinder_Egress_RequestBeingProcessed = false;
			PathfinderRequestBeingProcessed_OnThisPulse = false;
			FlightCannotLaunch = false;
			FlightCannotLaunch_Feedback = "";
			Departed = false;
			Landed = false;
		}

		public Flight(ref Scenario scenario_0, ref Mission mission_0, ref Flight flight_0, string string_0, Contact contact_0, Aircraft aircraft_0, _FlightSize _FlightSize_0, bool bool_0)
		{
			invocationItem = false;
			UsedByFlight = false;
			_FlightPlan = new Waypoint[0];
			_FlightPlan_Pathfinder_Ingress_1 = new Waypoint[0];
			_FlightPlan_Pathfinder_Ingress_2 = new Waypoint[0];
			_FlightPlan_Pathfinder_Egress_1 = new Waypoint[0];
			_FlightPlan_Pathfinder_Egress_2 = new Waypoint[0];
			TakeOffTimeZuluString = "-";
			TakeOffTimeLocalString = "-";
			ObjectiveTimeZuluString = "-";
			ObjectiveTimeLocalString = "-";
			TakeOffWaypointFixedTime = Waypoint.FixedFree.None;
			ObjectiveWaypointFixedTime = Waypoint.FixedFree.None;
			Pathfinder_Ingress_RequestBeingProcessed = false;
			Pathfinder_Egress_RequestBeingProcessed = false;
			PathfinderRequestBeingProcessed_OnThisPulse = false;
			FlightCannotLaunch = false;
			FlightCannotLaunch_Feedback = "";
			Departed = false;
			Landed = false;
			try
			{
				string landingLocation_HostUnitObjectID = "";
				string landingLocation_HostUnitObjectName = "";
				string takeOffLocation_HostUnitObjectID = "";
				string takeOffLocation_HostUnitObjectName = "";
				int num = 0;
				if (aircraft_0 != null)
				{
					_ = aircraft_0.AirOps;
					if (mission_0.SecondaryAirBase != null && mission_0.SecondaryAirBase.AirOps.CanHostThisAircraft(aircraft_0) == AirOpsAttemptResult.Success && mission_0.SecondaryAirBase.AirOps.CanThisAircraftLandHere(aircraft_0))
					{
						landingLocation_HostUnitObjectID = mission_0.SecondaryAirBase.ObjectID;
						landingLocation_HostUnitObjectName = mission_0.SecondaryAirBase.Name;
					}
					if (aircraft_0.AirOps.CurrentHostUnit != null)
					{
						takeOffLocation_HostUnitObjectID = aircraft_0.AirOps.CurrentHostUnit.ObjectID;
						takeOffLocation_HostUnitObjectName = aircraft_0.AirOps.CurrentHostUnit.Name;
					}
					num = aircraft_0.Loadout.DBID;
				}
				ParentMissionOrPackageObjectID = mission_0.ObjectID;
				ParentMissionOrPackageName = mission_0.Name;
				Callsign = string_0;
				TakeOffLocation_HostUnitObjectID = takeOffLocation_HostUnitObjectID;
				TakeOffLocation_HostUnitObjectName = takeOffLocation_HostUnitObjectName;
				LandingLocation_HostUnitObjectID = landingLocation_HostUnitObjectID;
				LandingLocation_HostUnitObjectName = landingLocation_HostUnitObjectName;
				int_0 = num;
				PrimaryTarget = contact_0;
				if (!Information.IsNothing(contact_0))
				{
					PrimaryTarget_ID = contact_0.ObjectID;
				}
				SetReferenceUnit(scenario_0, aircraft_0);
				DesiredAircraftQty = _FlightSize_0;
				Priority = _FlightPriority.Mandatory;
				IsEscort = bool_0;
				Name = "任务：" + mission_0.Name;
				if (mission_0.UseFlightSizeHardLimit)
				{
					MinimumAircraftQty = _FlightSize_0;
				}
				else
				{
					MinimumAircraftQty = 0;
				}
				if (!Information.IsNothing(flight_0))
				{
					Waypoint[] flightPlan = flight_0.FlightPlan;
					for (int i = 0; i < flightPlan.Length; i = checked(i + 1))
					{
						Waypoint waypoint_ = flightPlan[i];
						Waypoint[] gparam_ = FlightPlan;
						Doctrine doctrine_ = null;
						ArrayExtensions.Add(ref gparam_, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_, bool_0: true, bool_1: true, ref doctrine_));
						FlightPlan = gparam_;
					}
				}
				switch (mission_0.MissionClass)
				{
				case _MissionClass.Strike:
					if (IsEscort)
					{
						if (!Information.IsNothing(GetReferenceUnit(scenario_0)) && GetReferenceUnit(scenario_0).AI.IsEscort)
						{
							Aircraft aircraft = (Aircraft)GetReferenceUnit(scenario_0);
							if (Information.IsNothing(aircraft.Loadout))
							{
								Task = _FlightTask.Escort_Support;
							}
							else if (aircraft.Loadout.IsSupportOrPatrol)
							{
								Task = _FlightTask.Escort_Support;
							}
							else if (aircraft.Loadout.IsAAW)
							{
								Task = _FlightTask.Escort_FighterSweep;
							}
							else if (aircraft.Loadout.IsStrike)
							{
								Task = _FlightTask.Escort_SEAD;
							}
							else
							{
								Task = _FlightTask.Escort_Support;
							}
						}
						else
						{
							Task = _FlightTask.Escort_Support;
						}
						break;
					}
					switch (((Strike)mission_0).Type)
					{
					case Strike.StrikeType.Air_Intercept:
						Task = _FlightTask.GLI;
						break;
					case Strike.StrikeType.Land_Strike:
						Task = _FlightTask.Strike_Land;
						break;
					case Strike.StrikeType.Maritime_Strike:
						Task = _FlightTask.Strike_Naval;
						break;
					case Strike.StrikeType.Sub_Strike:
						Task = _FlightTask.ASW;
						break;
					}
					break;
				case _MissionClass.Patrol:
					switch (((Patrol)mission_0).Type)
					{
					case GlobalVariables.PatrolType.ASW:
						Task = _FlightTask.ASW;
						break;
					case GlobalVariables.PatrolType.ASuW_Naval:
						Task = _FlightTask.Maritime_Surveillance;
						break;
					case GlobalVariables.PatrolType.AAW:
						Task = _FlightTask.CAP;
						break;
					case GlobalVariables.PatrolType.ASuW_Land:
						Task = _FlightTask.Area_Surveillance;
						break;
					case GlobalVariables.PatrolType.ASuW_Mixed:
						Task = _FlightTask.Area_Surveillance;
						break;
					case GlobalVariables.PatrolType.SEAD:
						Task = _FlightTask.Strike_SEAD;
						break;
					case GlobalVariables.PatrolType.SeaControl:
						Task = _FlightTask.Maritime_Surveillance;
						break;
					}
					break;
				case _MissionClass.Support:
					Task = _FlightTask.Support;
					break;
				case _MissionClass.Ferry:
					Task = _FlightTask.Ferry;
					break;
				case _MissionClass.Mining:
					Task = _FlightTask.NavalMineLaying;
					break;
				case _MissionClass.MineClearing:
					Task = _FlightTask.MineSweeping;
					break;
				case _MissionClass.Escort:
					Task = _FlightTask.Escort_Support;
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		internal bool CheckInterruptibleQueue()
		{
			_FlightTask task = Task;
			if ((uint)(task - 14) > 2u && task != _FlightTask.Escort_Support)
			{
				return false;
			}
			return true;
		}

		public void SetTakeOffAndObjectiveTimeString(ref Scenario scenario_0)
		{
			try
			{
				DateTime time = scenario_0.Time;
				bool use_DST = scenario_0.Use_DST;
				string dST_Start = scenario_0.DST_Start;
				string dST_End = scenario_0.DST_End;
				DateTime? dateTime = null;
				DateTime? dateTime2 = null;
				DateTime? dateTime3 = null;
				DateTime? dateTime4 = null;
				string text = "";
				string text2 = "";
				bool? flag = null;
				if (FlightPlan.Count() > 0)
				{
					int num = FlightPlan.Count() - 1;
					for (int i = 0; i <= num; i++)
					{
						Waypoint waypoint = FlightPlan[i];
						if (!Information.IsNothing(waypoint.Time_Zulu))
						{
							flag = false;
							if (waypoint.Type == Waypoint.WaypointType.TakeOff)
							{
								dateTime = waypoint.Time_Zulu;
								TakeOffWaypointFixedTime = waypoint.TimeFixed;
								waypoint.TimeOfDay = SunModule.CollectSpecification(null, dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day, dateTime.Value.Hour, dateTime.Value.Minute, dateTime.Value.Second, bool_0: false, waypoint.Latitude, waypoint.Longitude, 0.0);
								waypoint.Time_Local = Misc.DisableRequest(waypoint.Time_Zulu.Value, waypoint.Longitude, use_DST, dST_Start, dST_End);
								dateTime2 = waypoint.Time_Local;
								text = " (" + SunModule.ForgotSpecification(waypoint.TimeOfDay, time, waypoint.Longitude, use_DST, dST_Start, dST_End) + ")";
							}
							else if (waypoint.Type == Waypoint.WaypointType.Target || waypoint.Type == Waypoint.WaypointType.WeaponTarget || waypoint.SearchReponse())
							{
								flag = true;
								ObjectiveWaypointFixedTime = waypoint.TimeFixed;
								dateTime3 = (Information.IsNothing(waypoint.Time_Zulu_Weapon) ? waypoint.Time_Zulu : waypoint.Time_Zulu_Weapon);
								waypoint.TimeOfDay = SunModule.CollectSpecification(null, dateTime3.Value.Year, dateTime3.Value.Month, dateTime3.Value.Day, dateTime3.Value.Hour, dateTime3.Value.Minute, dateTime3.Value.Second, bool_0: false, waypoint.Latitude, waypoint.Longitude, 0.0);
								if (Information.IsNothing(waypoint.Time_Zulu_Weapon))
								{
									waypoint.Time_Local = Misc.DisableRequest(waypoint.Time_Zulu.Value, waypoint.Longitude, use_DST, dST_Start, dST_End);
								}
								else
								{
									waypoint.Time_Local = Misc.DisableRequest(waypoint.Time_Zulu_Weapon.Value, waypoint.Longitude, use_DST, dST_Start, dST_End);
								}
								dateTime4 = waypoint.Time_Local;
								text2 = " (" + SunModule.ForgotSpecification(waypoint.TimeOfDay, time, waypoint.Longitude, use_DST, dST_Start, dST_End) + ")";
								break;
							}
							continue;
						}
						TakeOffTimeZuluString = "";
						TakeOffTimeLocalString = "";
						ObjectiveTimeZuluString = "";
						ObjectiveTimeLocalString = "";
						TakeOffWaypointFixedTime = Waypoint.FixedFree.None;
						ObjectiveWaypointFixedTime = Waypoint.FixedFree.None;
						break;
					}
				}
				if (Information.IsNothing(dateTime))
				{
					TakeOffTimeZuluString = "-";
				}
				else
				{
					DateTime dateTime_ = dateTime.Value;
					GameGeneral.PaddedTimeAndDateString(ref dateTime_, ref TakeOffTimeZuluString);
				}
				if (Information.IsNothing(dateTime2))
				{
					TakeOffTimeLocalString = "-";
				}
				else
				{
					TakeOffTimeLocalString = "";
					DateTime dateTime_2 = dateTime2.Value;
					GameGeneral.PaddedTimeString(ref dateTime_2, ref TakeOffTimeLocalString);
					TakeOffTimeLocalString += text;
				}
				if (Information.IsNothing(dateTime3))
				{
					if (!Information.IsNothing(flag) && ((!flag) ?? flag).GetValueOrDefault())
					{
						ObjectiveTimeZuluString = "No waypoint found";
					}
					else
					{
						ObjectiveTimeZuluString = "-";
					}
				}
				else
				{
					DateTime dateTime_3 = dateTime3.Value;
					GameGeneral.PaddedTimeAndDateString(ref dateTime_3, ref ObjectiveTimeZuluString);
				}
				if (Information.IsNothing(dateTime4))
				{
					if (!Information.IsNothing(flag) && ((!flag) ?? flag).GetValueOrDefault())
					{
						ObjectiveTimeLocalString = "No waypoint found";
					}
					else
					{
						ObjectiveTimeLocalString = "-";
					}
				}
				else
				{
					ObjectiveTimeLocalString = "";
					DateTime dateTime_4 = dateTime4.Value;
					GameGeneral.PaddedTimeString(ref dateTime_4, ref ObjectiveTimeLocalString);
					ObjectiveTimeLocalString += text2;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		public _FlightStatus GetStatus(Scenario scenario_0)
		{
			return m_ClassItem;
		}

		[SpecialName]
		public void SetStatus(Scenario scenario_0, _FlightStatus _FlightStatus_0)
		{
			bool num = _FlightStatus_0 != m_ClassItem;
			m_ClassItem = _FlightStatus_0;
			if (!num)
			{
				return;
			}
			for (int i = scenario_0.MissionPlannerErrorList.Count - 1; i >= 0; i += -1)
			{
				MDSP_Error mDSP_Error = scenario_0.MissionPlannerErrorList[i];
				if (Operators.CompareString(mDSP_Error.Flight, Callsign, TextCompare: false) == 0)
				{
					scenario_0.MissionPlannerErrorList.Remove(mDSP_Error);
				}
			}
		}

		[SpecialName]
		public bool GetIsActive(List<ActiveUnit> list_0)
		{
			if ((uint)(m_ClassItem - 4) <= 4u)
			{
				if (list_0 == null)
				{
					return true;
				}
				foreach (ActiveUnit item in list_0)
				{
					if (item.IsAircraft && ((Aircraft)item).AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Parked)
					{
						return true;
					}
				}
				m_ClassItem = _FlightStatus.None;
				return false;
			}
			return false;
		}

		[SpecialName]
		public string GetLoadoutName(Scenario scenario_0)
		{
			if (string.IsNullOrEmpty(valueItem))
			{
				try
				{
					if (int_0 == 0)
					{
						return "没有设置";
					}
					if (!Information.IsNothing(GetReferenceUnit(scenario_0)) && !Information.IsNothing(((Aircraft)GetReferenceUnit(scenario_0)).Loadout))
					{
						valueItem = ((Aircraft)GetReferenceUnit(scenario_0)).Loadout.Name;
					}
					else
					{
						Loadout loadout = DBFunctions.GetLoadout(ref scenario_0, int_0, bool_0: false, bool_1: false);
						if (!Information.IsNothing(loadout))
						{
							valueItem = loadout.Name;
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_.Data.Add("Error at 999999", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			return valueItem;
		}

		[SpecialName]
		public void SetLoadoutName(Scenario scenario_0, string string_0)
		{
			valueItem = string_0;
		}

		public void ClearFlightPlan()
		{
			ArrayExtensions.Clear(ref _FlightPlan);
		}

		public void ChangeDesiredFlightSize(ref Scenario scenario_0, ref Mission mission_0, Side side_0, _FlightSize _FlightSize_0)
		{
			try
			{
				if (GetStatus(scenario_0) == _FlightStatus.None)
				{
					if (_FlightSize_0 == DesiredAircraftQty)
					{
						return;
					}
					bool flag = !(_FlightSize_0 <= DesiredAircraftQty);
					if (ConcatInterruptibleQueue())
					{
						if (flag)
						{
							int num = FlightPlan.Count() - 2;
							for (int i = 1; i <= num; i++)
							{
								Waypoint waypoint = FlightPlan[i];
								Waypoint waypoint_ = FlightPlan[i - 1];
								Waypoint waypoint_2 = FlightPlan[i + 1];
								if (!Information.IsNothing(waypoint) && waypoint.FlightFormation == Waypoint.Formation.Split)
								{
									waypoint.SplitWaypoint(ref scenario_0, ref _FlightSize_0, ref waypoint_, ref waypoint_2, bool_0: false);
								}
							}
						}
						else
						{
							int num2 = FlightPlan.Count() - 1;
							for (int j = 0; j <= num2; j++)
							{
								Waypoint waypoint2 = FlightPlan[j];
								if (!Information.IsNothing(waypoint2))
								{
									if (!Information.IsNothing(waypoint2.Waypoint_LeadElementWingman) && _FlightSize_0 < 2)
									{
										waypoint2.Waypoint_LeadElementWingman = null;
									}
									if (!Information.IsNothing(waypoint2.Waypoint_SecondElement) && _FlightSize_0 < 3)
									{
										waypoint2.Waypoint_SecondElement = null;
									}
									if (!Information.IsNothing(waypoint2.Waypoint_SecondElementWingman) && _FlightSize_0 < 4)
									{
										waypoint2.Waypoint_SecondElementWingman = null;
									}
									if (!Information.IsNothing(waypoint2.Waypoint_ThirdElement) && _FlightSize_0 < 6)
									{
										waypoint2.Waypoint_ThirdElement = null;
									}
									if (!Information.IsNothing(waypoint2.Waypoint_ThirdElementWingman) && _FlightSize_0 < 6)
									{
										waypoint2.Waypoint_ThirdElementWingman = null;
									}
								}
							}
						}
					}
					DesiredAircraftQty = _FlightSize_0;
					if (MinimumAircraftQty > DesiredAircraftQty)
					{
						MinimumAircraftQty = DesiredAircraftQty;
					}
					Scenario scenario_ = scenario_0;
					Mission strike_ = mission_0;
					ActiveUnit referenceUnit = GetReferenceUnit(scenario_0);
					Waypoint[] waypoint_3 = FlightPlan;
					float float_ = 0f;
					float float_2 = 0f;
					MissionPlanner.ConnectTokenizer(scenario_, strike_, referenceUnit, this, ref waypoint_3, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
					FlightPlan = waypoint_3;
				}
				else
				{
					GameGeneral.ResolveBridge("Cannot change flight size for airborne flights.", side_0);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public void ChangeMinimumFlightSize(ref Scenario scenario_0, ref Mission mission_0, Side side_0, _FlightSize _FlightSize_0)
		{
			if (GetStatus(scenario_0) == _FlightStatus.None)
			{
				MinimumAircraftQty = _FlightSize_0;
			}
			else
			{
				GameGeneral.ResolveBridge("Cannot change flight size for airborne flights.", side_0);
			}
		}

		internal bool ConcatInterruptibleQueue()
		{
			int num = FlightPlan.Count() - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					Waypoint waypoint = FlightPlan[num2];
					if (!Information.IsNothing(waypoint) && waypoint.InvokeReponse())
					{
						break;
					}
					num2++;
					continue;
				}
				return false;
			}
			return true;
		}

		public void RenameFlightplanInFlightplanErrorList(ref Scenario scenario_0, ref Flight flight_0, string string_0, string string_1)
		{
			try
			{
				if (Information.IsNothing(scenario_0) || Information.IsNothing(scenario_0.MissionPlannerErrorList) || scenario_0.MissionPlannerErrorList.Count <= 0 || string.IsNullOrEmpty(flight_0.Callsign))
				{
					return;
				}
				for (int i = scenario_0.MissionPlannerErrorList.Count - 1; i >= 0; i += -1)
				{
					MDSP_Error mDSP_Error = scenario_0.MissionPlannerErrorList[i];
					if (string.IsNullOrEmpty(mDSP_Error.Flight))
					{
						scenario_0.MissionPlannerErrorList.Remove(scenario_0.MissionPlannerErrorList[i]);
					}
					else if (Operators.CompareString(mDSP_Error.Flight, string_0, TextCompare: false) == 0)
					{
						scenario_0.MissionPlannerErrorList[i].Flight = string_1;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 101383", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public void AddMasterFlightPlanErrorsToFlightplanErrorList(ref Scenario scenario_0, ref Flight flight_0)
		{
			try
			{
				if (Information.IsNothing(flight_0.ErrorList) || flight_0.ErrorList.Count <= 0 || string.IsNullOrEmpty(flight_0.Callsign))
				{
					return;
				}
				string right = "主飞行计划飞机DBID：" + Conversions.ToString(flight_0.ReferenceUnit_DBID) + "挂载DBID：" + Conversions.ToString(flight_0.int_0);
				for (int i = flight_0.ErrorList.Count - 1; i >= 0; i += -1)
				{
					MDSP_Error mDSP_Error = flight_0.ErrorList[i];
					if (string.IsNullOrEmpty(mDSP_Error.Flight))
					{
						flight_0.ErrorList.Remove(flight_0.ErrorList[i]);
						continue;
					}
					MDSP_Error mDSP_Error2 = mDSP_Error;
					if (Operators.CompareString(mDSP_Error2.Flight, right, TextCompare: false) == 0)
					{
						mDSP_Error2.Flight = Callsign;
					}
					scenario_0.MissionPlannerErrorList.Add(mDSP_Error2);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public void Copy(ref Scenario scenario_0, ref Flight flight_0, ref Flight flight_1, bool bool_0, ref Mission mission_0, ref int int_1, ref int int_2, bool bool_1, bool bool_2)
		{
			try
			{
				if (Information.IsNothing(flight_0) || Information.IsNothing(flight_1))
				{
					return;
				}
				string text = (Information.IsNothing(mission_0) ? "Temporary flightplan" : Callsigns.ReadProperty(ref mission_0));
				flight_1.ParentMissionOrPackageObjectID = flight_0.ParentMissionOrPackageObjectID;
				flight_1.ParentMissionOrPackageName = flight_0.ParentMissionOrPackageName;
				flight_1.Callsign = text;
				flight_1.Task = flight_0.Task;
				flight_1.Type = flight_0.Type;
				flight_1.Priority = flight_0.Priority;
				flight_1.TakeOffLocation_HostUnitObjectID = flight_0.TakeOffLocation_HostUnitObjectID;
				flight_1.TakeOffLocation_HostUnitObjectName = flight_0.TakeOffLocation_HostUnitObjectName;
				flight_1.LandingLocation_HostUnitObjectID = flight_0.LandingLocation_HostUnitObjectID;
				flight_1.LandingLocation_HostUnitObjectName = flight_0.LandingLocation_HostUnitObjectName;
				flight_1.AlternativeLandingLocation_HostUnitObjectID = flight_0.AlternativeLandingLocation_HostUnitObjectID;
				flight_1.AlternativeLandingLocation_HostUnitObjectName = flight_0.AlternativeLandingLocation_HostUnitObjectName;
				if (bool_0)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				else
				{
					flight_1.DesiredAircraftQty = flight_0.DesiredAircraftQty;
				}
				flight_1.IsEscort = flight_0.IsEscort;
				flight_1.EarliestTaskingTime = flight_0.EarliestTaskingTime;
				flight_1.LatestTaskingTime = flight_0.LatestTaskingTime;
				flight_1.MaxReadyTime = flight_0.MaxReadyTime;
				flight_1.EarliestLaunchTime = flight_0.EarliestLaunchTime;
				flight_1.LatestLaunchTime = flight_0.LatestLaunchTime;
				flight_1.Priority = flight_0.Priority;
				flight_1.SetStatus(scenario_0, _FlightStatus.None);
				flight_1.CreatedBy = flight_0.CreatedBy;
				flight_1.EditedBy = flight_0.EditedBy;
				flight_1.MinimumAircraftQty = flight_0.MinimumAircraftQty;
				flight_1.ReadyAircraftQty = flight_0.ReadyAircraftQty;
				flight_1.UsedByFlight = false;
				flight_1.SetReferenceUnit(null, null);
				flight_1.ReferenceUnit_DBID = flight_0.ReferenceUnit_DBID;
				flight_1.ReferenceUnit_ObjectID = "";
				flight_1.ReferenceUnit_Name = flight_0.ReferenceUnit_Name;
				flight_1.int_0 = flight_0.int_0;
				flight_1.SetLoadoutName(scenario_0, flight_0.GetLoadoutName(scenario_0));
				checked
				{
					if (!Information.IsNothing(flight_0.FlightPlan) && flight_0.FlightPlan.Count() > 0)
					{
						Waypoint[] flightPlan = flight_0.FlightPlan;
						for (int i = 0; i < flightPlan.Length; i++)
						{
							Waypoint waypoint_ = flightPlan[i];
							Flight obj = flight_1;
							Waypoint[] gparam_ = obj.FlightPlan;
							Doctrine doctrine_ = null;
							ArrayExtensions.Add(ref gparam_, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_, bool_0: true, bool_1: true, ref doctrine_));
							obj.FlightPlan = gparam_;
						}
					}
					if (!Information.IsNothing(flight_0.FlightPlan_Pathfinder_Ingress_1) && flight_0.FlightPlan_Pathfinder_Ingress_1.Count() > 0)
					{
						Waypoint[] flightPlan_Pathfinder_Ingress_ = flight_0.FlightPlan_Pathfinder_Ingress_1;
						for (int j = 0; j < flightPlan_Pathfinder_Ingress_.Length; j++)
						{
							Waypoint waypoint_2 = flightPlan_Pathfinder_Ingress_[j];
							Flight obj2 = flight_1;
							Waypoint[] gparam_2 = obj2.FlightPlan_Pathfinder_Ingress_1;
							Doctrine doctrine_2 = null;
							ArrayExtensions.Add(ref gparam_2, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_2, bool_0: true, bool_1: true, ref doctrine_2));
							obj2.FlightPlan_Pathfinder_Ingress_1 = gparam_2;
						}
					}
					if (!Information.IsNothing(flight_0.FlightPlan_Pathfinder_Ingress_2) && flight_0.FlightPlan_Pathfinder_Ingress_2.Count() > 0)
					{
						Waypoint[] flightPlan_Pathfinder_Ingress_2 = flight_0.FlightPlan_Pathfinder_Ingress_2;
						for (int k = 0; k < flightPlan_Pathfinder_Ingress_2.Length; k++)
						{
							Waypoint waypoint_3 = flightPlan_Pathfinder_Ingress_2[k];
							Flight obj3 = flight_1;
							Waypoint[] gparam_3 = obj3.FlightPlan_Pathfinder_Ingress_2;
							Doctrine doctrine_3 = null;
							ArrayExtensions.Add(ref gparam_3, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_3, bool_0: true, bool_1: true, ref doctrine_3));
							obj3.FlightPlan_Pathfinder_Ingress_2 = gparam_3;
						}
					}
					if (!Information.IsNothing(flight_0.FlightPlan_Pathfinder_Egress_1) && flight_0.FlightPlan_Pathfinder_Egress_1.Count() > 0)
					{
						Waypoint[] flightPlan_Pathfinder_Egress_ = flight_0.FlightPlan_Pathfinder_Egress_1;
						for (int l = 0; l < flightPlan_Pathfinder_Egress_.Length; l++)
						{
							Waypoint waypoint_4 = flightPlan_Pathfinder_Egress_[l];
							Flight obj4 = flight_1;
							Waypoint[] gparam_4 = obj4.FlightPlan_Pathfinder_Egress_1;
							Doctrine doctrine_4 = null;
							ArrayExtensions.Add(ref gparam_4, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_4, bool_0: true, bool_1: true, ref doctrine_4));
							obj4.FlightPlan_Pathfinder_Egress_1 = gparam_4;
						}
					}
					if (!Information.IsNothing(flight_0.FlightPlan_Pathfinder_Egress_2) && flight_0.FlightPlan_Pathfinder_Egress_2.Count() > 0)
					{
						Waypoint[] flightPlan_Pathfinder_Egress_2 = flight_0.FlightPlan_Pathfinder_Egress_2;
						for (int m = 0; m < flightPlan_Pathfinder_Egress_2.Length; m++)
						{
							Waypoint waypoint_5 = flightPlan_Pathfinder_Egress_2[m];
							Flight obj5 = flight_1;
							Waypoint[] gparam_5 = obj5.FlightPlan_Pathfinder_Egress_2;
							Doctrine doctrine_5 = null;
							ArrayExtensions.Add(ref gparam_5, Waypoint.CopyWaypoint(ref scenario_0, ref waypoint_5, bool_0: true, bool_1: true, ref doctrine_5));
							obj5.FlightPlan_Pathfinder_Egress_2 = gparam_5;
						}
					}
					flight_1.TaskPool = flight_0.TaskPool;
					flight_1.Age = 0;
					flight_1.PrimaryTarget = flight_0.PrimaryTarget;
					flight_1.PrimaryTarget_ID = flight_0.PrimaryTarget_ID;
					flight_1.Pathfinder_Ingress_RequestBeingProcessed = false;
					flight_1.Pathfinder_Egress_RequestBeingProcessed = false;
					flight_1.PathfinderRequestBeingProcessed_OnThisPulse = false;
					flight_1.FlightCannotLaunch = false;
					flight_1.FlightCannotLaunch_Feedback = "";
					if (!Information.IsNothing(mission_0))
					{
						mission_0.AddFlight(ref flight_1);
					}
				}
				if (!Information.IsNothing(mission_0) && bool_1)
				{
					if (Information.IsNothing(mission_0.EmptySlotsList))
					{
						mission_0.EmptySlotsList = new List<EmptyAircraftSlot>();
					}
					ActiveUnit activeUnit_ = null;
					if (scenario_0.ActiveUnits.ContainsKey(flight_1.TakeOffLocation_HostUnitObjectID))
					{
						activeUnit_ = scenario_0.ActiveUnits[flight_1.TakeOffLocation_HostUnitObjectID];
					}
					int num = flight_1.DesiredAircraftQty;
					for (int n = 1; n <= num; n++)
					{
						EmptyAircraftSlot emptyAircraftSlot = new EmptyAircraftSlot(null, flight_1.ReferenceUnit_DBID, flight_1.ReferenceUnit_Name, flight_1.int_0, flight_1.GetLoadoutName(scenario_0), ref activeUnit_, flight_1.TakeOffLocation_HostUnitObjectID, flight_1.LandingLocation_HostUnitObjectName, flight_1.IsEscort);
						mission_0.EmptySlotsList.Add(emptyAircraftSlot);
						emptyAircraftSlot.SetFlight(scenario_0, flight_1, n);
					}
				}
				if (!bool_2)
				{
					return;
				}
				MDSP_Error mDSP_Error = new MDSP_Error();
				for (int num2 = scenario_0.MissionPlannerErrorList.Count - 1; num2 >= 0; num2 += -1)
				{
					mDSP_Error.Mission = mission_0.Name;
					mDSP_Error.Flight = flight_0.Callsign;
					mDSP_Error = scenario_0.MissionPlannerErrorList[num2];
					if (string.IsNullOrEmpty(mDSP_Error.Flight))
					{
						scenario_0.MissionPlannerErrorList.Remove(scenario_0.MissionPlannerErrorList[num2]);
					}
					else if (Operators.CompareString(mDSP_Error.Flight, flight_0.Callsign, TextCompare: false) == 0)
					{
						MDSP_Error item = new MDSP_Error(mission_0.Name, text, mDSP_Error.Message);
						scenario_0.MissionPlannerErrorList.Add(item);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 101384", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		public ActiveUnit GetReferenceUnit(Scenario scenario_0)
		{
			try
			{
				if (Information.IsNothing(m_RequestItem) && !Information.IsNothing(scenario_0))
				{
					if (!string.IsNullOrEmpty(ReferenceUnit_ObjectID) && scenario_0.ActiveUnits.ContainsKey(ReferenceUnit_ObjectID))
					{
						m_RequestItem = scenario_0.ActiveUnits[ReferenceUnit_ObjectID];
					}
					List<ActiveUnit> list = Misc.EnableRequest(scenario_0.ActiveUnits.Values.ToList());
					if (Information.IsNothing(m_RequestItem))
					{
						foreach (ActiveUnit item in list)
						{
							if (item != null && item.Navigator.HasFlightPlan && item.Navigator.GetFlight() == this)
							{
								SetReferenceUnit(scenario_0, item);
								break;
							}
						}
					}
					if (Information.IsNothing(m_RequestItem) && ReferenceUnit_DBID > 0)
					{
						bool flag = false;
						Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
						for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
						{
							Side side_ = sides_ReadOnly[i];
							foreach (Mission mission in side_.Missions)
							{
								if (mission.RestartValue())
								{
									foreach (Flight flight in mission.FlightList)
									{
										Flight flight_ = flight;
										if (flight_ == this)
										{
											int referenceUnit_DBID = ReferenceUnit_DBID;
											int int_ = int_0;
											ObservableDictionary<string, ActiveUnit> activeUnits = scenario_0.ActiveUnits;
											string takeOffLocation_HostUnitObjectID;
											ActiveUnit activeUnit_ = activeUnits[takeOffLocation_HostUnitObjectID = TakeOffLocation_HostUnitObjectID];
											Aircraft requestItem = mission.CancelValue(ref scenario_0, ref side_, referenceUnit_DBID, int_, ref activeUnit_, ref flight_, bool_0: false, 1);
											activeUnits[takeOffLocation_HostUnitObjectID] = activeUnit_;
											m_RequestItem = requestItem;
											flag = true;
											break;
										}
									}
								}
								if (flag)
								{
									break;
								}
							}
							if (flag)
							{
								break;
							}
						}
					}
				}
				return m_RequestItem;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 101385", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return null;
			}
		}

		[SpecialName]
		public void SetReferenceUnit(Scenario scenario_0, ActiveUnit activeUnit_0)
		{
			m_RequestItem = activeUnit_0;
			if (activeUnit_0 == null)
			{
				ReferenceUnit_ObjectID = "";
				return;
			}
			ReferenceUnit_DBID = m_RequestItem.DBID;
			ReferenceUnit_ObjectID = m_RequestItem.ObjectID;
			ReferenceUnit_Name = m_RequestItem.UnitClass;
		}

		public static List<Flight> FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
		{
			List<Flight> result = null;
			try
			{
				List<Flight> list = new List<Flight>();
				IEnumerator enumerator = null;
				try
				{
					enumerator = xmlNode_0.ChildNodes.GetEnumerator();
					IEnumerator enumerator2 = null;
					IEnumerator enumerator3 = null;
					IEnumerator enumerator4 = null;
					IEnumerator enumerator5 = null;
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode = (XmlNode)enumerator.Current;
						if (Operators.CompareString(xmlNode.Name, "Flight", TextCompare: false) != 0)
						{
							continue;
						}
						Flight flight = new Flight();
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
								switch (xmlNode2.Name)
								{
								case "Landed":
									flight.Landed = Conversions.ToBoolean(xmlNode2.InnerText);
									break;
								case "Status":
									flight.SetStatus(scenario_0, (_FlightStatus)Conversions.ToByte(xmlNode2.InnerText));
									break;
								case "TakeOffLocation_HostUnitObjectName":
									flight.TakeOffLocation_HostUnitObjectName = xmlNode2.InnerText;
									break;
								case "TaskPool_Name":
									flight.TaskPool_Name = xmlNode2.InnerText;
									break;
								case "MinimumAircraftQty":
									flight.MinimumAircraftQty = Conversions.ToByte(xmlNode2.InnerText);
									break;
								case "UsedByFlight":
									flight.UsedByFlight = Conversions.ToBoolean(xmlNode2.InnerText);
									break;
								case "LandingLocation_HostUnitObjectID":
									flight.LandingLocation_HostUnitObjectID = xmlNode2.InnerText;
									break;
								case "EditedBy":
									flight.EditedBy = (_FlightCreatedBy)Conversions.ToByte(xmlNode2.InnerText);
									break;
								case "LoadoutDBID":
									flight.int_0 = Conversions.ToInteger(xmlNode2.InnerText);
									break;
								case "LoadoutName":
									flight.SetLoadoutName(scenario_0, xmlNode2.InnerText);
									break;
								case "ParentMissionOrPackageObjectID":
									flight.ParentMissionOrPackageObjectID = xmlNode2.InnerText;
									break;
								case "ReferenceUnit_Name":
									flight.ReferenceUnit_Name = xmlNode2.InnerText;
									break;
								case "Departed":
									flight.Departed = Conversions.ToBoolean(xmlNode2.InnerText);
									break;
								case "LatestTaskingTime":
								{
									DateTime value4 = DateTime.FromBinary(Conversions.ToLong(xmlNode2.InnerText));
									flight.LatestTaskingTime = value4;
									break;
								}
								case "NotificationList":
									if (Information.IsNothing(flight.NotificationList))
									{
										flight.NotificationList = new List<string>();
									}
									try
									{
										enumerator5 = xmlNode2.ChildNodes.GetEnumerator();
										while (enumerator5.MoveNext())
										{
											string innerText = ((XmlNode)enumerator5.Current).InnerText;
											flight.NotificationList.Add(innerText);
										}
									}
									finally
									{
										if (enumerator5 is IDisposable)
										{
											(enumerator5 as IDisposable).Dispose();
										}
									}
									break;
								case "PrimaryTarget_ID":
									flight.PrimaryTarget_ID = xmlNode2.InnerText;
									break;
								case "ID":
									flight.ObjectID_Set(xmlNode2.InnerText);
									break;
								case "EarliestLaunchTime":
								{
									DateTime value3 = DateTime.FromBinary(Conversions.ToLong(xmlNode2.InnerText));
									flight.EarliestLaunchTime = value3;
									break;
								}
								case "EarliestTaskingTime":
								{
									DateTime value2 = DateTime.FromBinary(Conversions.ToLong(xmlNode2.InnerText));
									flight.EarliestTaskingTime = value2;
									break;
								}
								case "AlternativeLandingLocation_HostUnitObjectID":
									flight.AlternativeLandingLocation_HostUnitObjectID = xmlNode2.InnerText;
									break;
								case "IsEscort":
									flight.IsEscort = Conversions.ToBoolean(xmlNode2.InnerText);
									break;
								case "Task":
									flight.Task = (_FlightTask)Conversions.ToByte(xmlNode2.InnerText);
									break;
								case "Age":
									flight.Age = Conversions.ToInteger(xmlNode2.InnerText);
									break;
								case "AlternativeLandingLocation_HostUnitObjectName":
									flight.AlternativeLandingLocation_HostUnitObjectName = xmlNode2.InnerText;
									break;
								case "CreatedBy":
									flight.CreatedBy = (_FlightCreatedBy)Conversions.ToByte(xmlNode2.InnerText);
									break;
								case "ReferenceUnit_ObjectID":
									flight.ReferenceUnit_ObjectID = xmlNode2.InnerText;
									break;
								case "LatestLaunchTime":
								{
									DateTime value = DateTime.FromBinary(Conversions.ToLong(xmlNode2.InnerText));
									flight.LatestLaunchTime = value;
									break;
								}
								case "ReferenceUnit_DBID":
									flight.ReferenceUnit_DBID = Conversions.ToInteger(xmlNode2.InnerText);
									break;
								case "ParentMissionOrPackageName":
									flight.ParentMissionOrPackageName = xmlNode2.InnerText;
									break;
								case "ErrorList":
									if (Information.IsNothing(flight.ErrorList))
									{
										flight.ErrorList = new List<MDSP_Error>();
									}
									try
									{
										enumerator3 = xmlNode2.ChildNodes.GetEnumerator();
										while (enumerator3.MoveNext())
										{
											XmlNode xmlNode_2 = (XmlNode)enumerator3.Current;
											MDSP_Error item = MDSP_Error.FromXML(ref xmlNode_2, ref concurrentDictionary_0);
											flight.ErrorList.Add(item);
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
								case "TakeOffLocation_HostUnitObjectID":
									flight.TakeOffLocation_HostUnitObjectID = xmlNode2.InnerText;
									break;
								case "Callsign":
									flight.Callsign = xmlNode2.InnerText;
									break;
								case "Type":
									flight.Type = (_FlightType)Conversions.ToByte(xmlNode2.InnerText);
									break;
								case "FlightPlan":
									try
									{
										enumerator4 = xmlNode2.ChildNodes.GetEnumerator();
										while (enumerator4.MoveNext())
										{
											XmlNode xmlNode_ = (XmlNode)enumerator4.Current;
											Waypoint theAC = Waypoint.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
											Waypoint[] gparam_ = flight.FlightPlan;
											ArrayExtensions.Add(ref gparam_, theAC);
											flight.FlightPlan = gparam_;
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
								case "ReadyAircraftQty":
									flight.ReadyAircraftQty = Conversions.ToByte(xmlNode2.InnerText);
									break;
								case "TaskPool_ID":
									flight.TaskPool_ID = xmlNode2.InnerText;
									break;
								case "MaxReadyTime":
									flight.MaxReadyTime = Conversions.ToShort(xmlNode2.InnerText);
									break;
								case "DesiredAircraftQty":
									flight.DesiredAircraftQty = Conversions.ToByte(xmlNode2.InnerText);
									break;
								case "LandingLocation_HostUnitObjectName":
									flight.LandingLocation_HostUnitObjectName = xmlNode2.InnerText;
									break;
								case "HasCriticalError":
									flight.HasCriticalError = Conversions.ToBoolean(xmlNode2.InnerText);
									break;
								case "Priority":
									flight.Priority = (_FlightPriority)Conversions.ToByte(xmlNode2.InnerText);
									break;
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
						list.Add(flight);
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				result = list;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}

		public static void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, ref Scenario scenario_0, ref List<Flight> list_0)
		{
			xmlWriter_0.WriteStartElement("FlightList");
			foreach (Flight item in list_0)
			{
				xmlWriter_0.WriteStartElement("Flight");
				xmlWriter_0.WriteElementString("ID", item.ObjectID);
				xmlWriter_0.WriteElementString("ParentMissionOrPackageObjectID", item.ParentMissionOrPackageObjectID);
				xmlWriter_0.WriteElementString("ParentMissionOrPackageName", item.ParentMissionOrPackageName);
				xmlWriter_0.WriteElementString("Callsign", item.Callsign);
				xmlWriter_0.WriteElementString("Task", ((byte)item.Task).ToString());
				xmlWriter_0.WriteElementString("Type", ((byte)item.Type).ToString());
				xmlWriter_0.WriteElementString("TakeOffLocation_HostUnitObjectID", item.TakeOffLocation_HostUnitObjectID);
				xmlWriter_0.WriteElementString("TakeOffLocation_HostUnitObjectName", item.TakeOffLocation_HostUnitObjectName);
				xmlWriter_0.WriteElementString("LandingLocation_HostUnitObjectID", item.LandingLocation_HostUnitObjectID);
				xmlWriter_0.WriteElementString("LandingLocation_HostUnitObjectName", item.LandingLocation_HostUnitObjectName);
				xmlWriter_0.WriteElementString("AlternativeLandingLocation_HostUnitObjectID", item.AlternativeLandingLocation_HostUnitObjectID);
				xmlWriter_0.WriteElementString("AlternativeLandingLocation_HostUnitObjectName", item.AlternativeLandingLocation_HostUnitObjectName);
				if (item.EarliestTaskingTime.HasValue)
				{
					xmlWriter_0.WriteElementString("EarliestTaskingTime", item.EarliestTaskingTime.Value.ToBinary().ToString());
				}
				if (item.LatestTaskingTime.HasValue)
				{
					xmlWriter_0.WriteElementString("LatestTaskingTime", item.LatestTaskingTime.Value.ToBinary().ToString());
				}
				if (item.EarliestLaunchTime.HasValue)
				{
					xmlWriter_0.WriteElementString("EarliestLaunchTime", item.EarliestLaunchTime.Value.ToBinary().ToString());
				}
				if (item.LatestLaunchTime.HasValue)
				{
					xmlWriter_0.WriteElementString("LatestLaunchTime", item.LatestLaunchTime.Value.ToBinary().ToString());
				}
				xmlWriter_0.WriteElementString("MaxReadyTime", item.MaxReadyTime.ToString());
				XmlWriter obj = xmlWriter_0;
				int priority = (int)item.Priority;
				obj.WriteElementString("Priority", priority.ToString());
				xmlWriter_0.WriteElementString("Status", ((int)item.GetStatus(scenario_0)).ToString());
				XmlWriter obj2 = xmlWriter_0;
				priority = (int)item.CreatedBy;
				obj2.WriteElementString("CreatedBy", priority.ToString());
				XmlWriter obj3 = xmlWriter_0;
				priority = (int)item.EditedBy;
				obj3.WriteElementString("EditedBy", priority.ToString());
				xmlWriter_0.WriteElementString("DesiredAircraftQty", ((int)item.DesiredAircraftQty).ToString());
				xmlWriter_0.WriteElementString("MinimumAircraftQty", ((int)item.MinimumAircraftQty).ToString());
				xmlWriter_0.WriteElementString("ReadyAircraftQty", item.ReadyAircraftQty.ToString());
				xmlWriter_0.WriteElementString("ReferenceUnit_DBID", item.ReferenceUnit_DBID.ToString());
				xmlWriter_0.WriteElementString("ReferenceUnit_ObjectID", item.ReferenceUnit_ObjectID);
				xmlWriter_0.WriteElementString("ReferenceUnit_Name", item.ReferenceUnit_Name);
				xmlWriter_0.WriteElementString("LoadoutDBID", item.int_0.ToString());
				xmlWriter_0.WriteElementString("LoadoutName", item.GetLoadoutName(scenario_0));
				xmlWriter_0.WriteElementString("UsedByFlight", item.UsedByFlight.ToString());
				xmlWriter_0.WriteElementString("IsEscort", item.IsEscort.ToString());
				xmlWriter_0.WriteElementString("Departed", item.Departed.ToString());
				xmlWriter_0.WriteElementString("Landed", item.Landed.ToString());
				if (Information.IsNothing(item.TaskPool))
				{
					xmlWriter_0.WriteElementString("TaskPool_ID", item.TaskPool_ID);
				}
				else
				{
					xmlWriter_0.WriteElementString("TaskPool_ID", item.TaskPool.ObjectID);
				}
				if (Information.IsNothing(item.PrimaryTarget))
				{
					xmlWriter_0.WriteElementString("PrimaryTarget_ID", item.PrimaryTarget_ID);
				}
				else
				{
					xmlWriter_0.WriteElementString("PrimaryTarget_ID", item.PrimaryTarget.ObjectID);
				}
				xmlWriter_0.WriteElementString("TaskPool_Name", item.TaskPool_Name);
				xmlWriter_0.WriteElementString("Age", item.Age.ToString());
				if (!Information.IsNothing(item.FlightPlan) && item.FlightPlan.Count() > 0)
				{
					xmlWriter_0.WriteStartElement("FlightPlan");
					List<Waypoint> list = new List<Waypoint>();
					list.AddRange(item.FlightPlan);
					foreach (Waypoint item2 in list)
					{
						if (!Information.IsNothing(item2))
						{
							item2.ToXML(ref xmlWriter_0, ref hashSet_0);
						}
					}
					xmlWriter_0.WriteEndElement();
				}
				if (!Information.IsNothing(item.ErrorList) && item.ErrorList.Count > 0)
				{
					xmlWriter_0.WriteStartElement("ErrorList");
					foreach (MDSP_Error error in item.ErrorList)
					{
						error.ToXML(hashSet_0);
					}
					xmlWriter_0.WriteEndElement();
				}
				if (!Information.IsNothing(item.NotificationList) && item.NotificationList.Count > 0)
				{
					xmlWriter_0.WriteStartElement("NotificationList");
					foreach (string notification in item.NotificationList)
					{
						xmlWriter_0.WriteElementString("Message", notification);
					}
					xmlWriter_0.WriteEndElement();
				}
				xmlWriter_0.WriteElementString("HasCriticalError", item.HasCriticalError.ToString());
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteEndElement();
		}

		public static void DetermineInitialFlightPlanTimes(ref Scenario scenario_0, ref Mission mission_0, ref DateTime? nullable_0, ref DateTime? nullable_1)
		{
			try
			{
				nullable_0 = null;
				nullable_1 = null;
				if (Information.IsNothing(mission_0.TakeOffTime))
				{
					if (!Information.IsNothing(mission_0.TimeOnTarget))
					{
						nullable_1 = mission_0.TimeOnTarget.Value;
					}
				}
				else
				{
					nullable_0 = mission_0.TakeOffTime.Value;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static string SetInitialFlightPlanTimes(ref Scenario scenario_0, ref Mission mission_0, Waypoint[] waypoint_0, bool bool_0, DateTime? nullable_0, DateTime? nullable_1)
		{
			try
			{
				if (waypoint_0.Count() == 0)
				{
					return null;
				}
				if (Information.IsNothing(nullable_0) && Information.IsNothing(nullable_1))
				{
					return "OK";
				}
				bool flag = false;
				DateTime value = default(DateTime);
				if (Information.IsNothing(nullable_0))
				{
					if (!Information.IsNothing(nullable_1))
					{
						value = nullable_1.Value;
						flag = false;
					}
				}
				else
				{
					value = nullable_0.Value;
					flag = true;
				}
				if (mission_0.MissionClass == _MissionClass.Strike && ((Strike)mission_0).AttackMethod == _AttackMethod.BananaSplit && !bool_0)
				{
					value = value.AddSeconds((float)(((Strike)mission_0).FlightSize - 1) * 10f);
				}
				Waypoint waypoint = null;
				foreach (Waypoint waypoint2 in waypoint_0)
				{
					if (!flag || waypoint2.Type != Waypoint.WaypointType.TakeOff)
					{
						if (waypoint2.Type != Waypoint.WaypointType.Target && waypoint2.Type != Waypoint.WaypointType.WeaponTarget && !((waypoint2.Type == Waypoint.WaypointType.Land) & (mission_0.MissionClass == _MissionClass.Ferry)))
						{
							if (waypoint2.SearchReponse())
							{
								waypoint = waypoint2;
								break;
							}
							continue;
						}
						waypoint = waypoint2;
						break;
					}
					waypoint = waypoint2;
					break;
				}
				if (Information.IsNothing(waypoint))
				{
					if (flag)
					{
						return "Could not find the take-off waypoint, so could not set flightplan waypoint times.";
					}
					return "Could not find the target or station waypoint, so could not set flightplan waypoint times.";
				}
				waypoint.TimeFixed = Waypoint.FixedFree.Fixed;
				if (!float.IsNaN(waypoint.Leg_Time_Weapon) && !float.IsInfinity(waypoint.Leg_Time_Weapon) && waypoint.Leg_Time_Weapon > 0f)
				{
					waypoint.Time_Zulu = value.AddSeconds(0f - waypoint.Leg_Time_Weapon);
					waypoint.Time_Zulu_Weapon = value;
				}
				else
				{
					waypoint.Time_Zulu = value;
					waypoint.Time_Zulu_Weapon = null;
				}
				return "OK";
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 200645", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return "Something went wrong.";
			}
		}

		[SpecialName]
		public static string GetFlightElementString(FlightElement flightElement_0)
		{
			if (1 == 0)
			{
			}
			string result = flightElement_0 switch
			{
				FlightElement.Other => "Other Element Wingman", 
				FlightElement.LeadElement => "Lead Element", 
				FlightElement.LeadElementWingman => "Lead Element Wingman", 
				FlightElement.SecondElement => "Second Element", 
				FlightElement.SecondElementWingman => "Second Element Wingman", 
				FlightElement.ThirdElement => "Third Element", 
				FlightElement.ThirdElementWingman => "Third Element Wingman", 
				_ => "None", 
			};
			if (1 == 0)
			{
			}
			return result;
		}

		public static void ComboBoxDataSource_Task(ref DataTable dataTable_0)
		{
			if (!dataTable_0.Columns.Contains("ID"))
			{
				dataTable_0.Columns.Add("ID", typeof(int));
			}
			if (!dataTable_0.Columns.Contains("Description"))
			{
				dataTable_0.Columns.Add("Description", typeof(string));
			}
			dataTable_0.Rows.Add(0, GetFlightTaskString(_FlightTask.Strike_Land));
			dataTable_0.Rows.Add(1, GetFlightTaskString(_FlightTask.Strike_OCA));
			dataTable_0.Rows.Add(2, GetFlightTaskString(_FlightTask.Strike_Interdiction));
			dataTable_0.Rows.Add(3, GetFlightTaskString(_FlightTask.Strike_SEAD));
			dataTable_0.Rows.Add(4, GetFlightTaskString(_FlightTask.Strike_Naval));
			dataTable_0.Rows.Add(5, GetFlightTaskString(_FlightTask.BAI));
			dataTable_0.Rows.Add(6, GetFlightTaskString(_FlightTask.CAS));
			dataTable_0.Rows.Add(7, GetFlightTaskString(_FlightTask.Buddy_Illumination));
			dataTable_0.Rows.Add(8, GetFlightTaskString(_FlightTask.CAP));
			dataTable_0.Rows.Add(9, GetFlightTaskString(_FlightTask.BARCAP));
			dataTable_0.Rows.Add(10, GetFlightTaskString(_FlightTask.TARCAP));
			dataTable_0.Rows.Add(11, GetFlightTaskString(_FlightTask.HAVCAP));
			dataTable_0.Rows.Add(12, GetFlightTaskString(_FlightTask.RESCAP));
			dataTable_0.Rows.Add(13, GetFlightTaskString(_FlightTask.GLI));
			dataTable_0.Rows.Add(14, GetFlightTaskString(_FlightTask.DLI));
			dataTable_0.Rows.Add(15, GetFlightTaskString(_FlightTask.Sweep_Fighter));
			dataTable_0.Rows.Add(16, GetFlightTaskString(_FlightTask.Sweep_SEAD));
			dataTable_0.Rows.Add(17, GetFlightTaskString(_FlightTask.QRA));
			dataTable_0.Rows.Add(18, GetFlightTaskString(_FlightTask.Escort_TARCAP));
			dataTable_0.Rows.Add(19, GetFlightTaskString(_FlightTask.Escort_FighterSweep));
			dataTable_0.Rows.Add(20, GetFlightTaskString(_FlightTask.Escort_SEAD));
			dataTable_0.Rows.Add(21, GetFlightTaskString(_FlightTask.Escort_Support));
			dataTable_0.Rows.Add(22, GetFlightTaskString(_FlightTask.ASAT));
			dataTable_0.Rows.Add(23, GetFlightTaskString(_FlightTask.AirborneLaser));
			dataTable_0.Rows.Add(24, GetFlightTaskString(_FlightTask.OECM));
			dataTable_0.Rows.Add(25, GetFlightTaskString(_FlightTask.AEW));
			dataTable_0.Rows.Add(26, GetFlightTaskString(_FlightTask.CommandPost));
			dataTable_0.Rows.Add(27, GetFlightTaskString(_FlightTask.ChaffLaying));
			dataTable_0.Rows.Add(28, GetFlightTaskString(_FlightTask.SearchAndRescue));
			dataTable_0.Rows.Add(29, GetFlightTaskString(_FlightTask.CombatSearchAndRescue));
			dataTable_0.Rows.Add(30, GetFlightTaskString(_FlightTask.MineSweeping));
			dataTable_0.Rows.Add(31, GetFlightTaskString(_FlightTask.MineRecon));
			dataTable_0.Rows.Add(32, GetFlightTaskString(_FlightTask.NavalMineLaying));
			dataTable_0.Rows.Add(33, GetFlightTaskString(_FlightTask.ASW));
			dataTable_0.Rows.Add(34, GetFlightTaskString(_FlightTask.Forward_Observer));
			dataTable_0.Rows.Add(35, GetFlightTaskString(_FlightTask.Area_Surveillance));
			dataTable_0.Rows.Add(36, GetFlightTaskString(_FlightTask.Armed_Recon));
			dataTable_0.Rows.Add(37, GetFlightTaskString(_FlightTask.Unarmed_Recon));
			dataTable_0.Rows.Add(38, GetFlightTaskString(_FlightTask.Maritime_Surveillance));
			dataTable_0.Rows.Add(39, GetFlightTaskString(_FlightTask.Paratroopers));
			dataTable_0.Rows.Add(40, GetFlightTaskString(_FlightTask.Troop_Transport));
			dataTable_0.Rows.Add(41, GetFlightTaskString(_FlightTask.Cargo));
			dataTable_0.Rows.Add(42, GetFlightTaskString(_FlightTask.AirRefueling));
			dataTable_0.Rows.Add(43, GetFlightTaskString(_FlightTask.Support));
			dataTable_0.Rows.Add(44, GetFlightTaskString(_FlightTask.Training));
			dataTable_0.Rows.Add(45, GetFlightTaskString(_FlightTask.TargetTow));
			dataTable_0.Rows.Add(46, GetFlightTaskString(_FlightTask.TargetDrone));
			dataTable_0.Rows.Add(47, GetFlightTaskString(_FlightTask.Ferry));
		}

		public static _FlightTask TaskSelection_To_Task(int int_1)
		{
			_FlightTask result = _FlightTask.None;
			try
			{
				switch (int_1)
				{
				default:
					result = _FlightTask.None;
					return _FlightTask.None;
				case 0:
					result = _FlightTask.Strike_Land;
					return _FlightTask.Strike_Land;
				case 1:
					result = _FlightTask.Strike_OCA;
					return _FlightTask.Strike_OCA;
				case 2:
					result = _FlightTask.Strike_Interdiction;
					return _FlightTask.Strike_Interdiction;
				case 3:
					result = _FlightTask.Strike_SEAD;
					return _FlightTask.Strike_SEAD;
				case 4:
					result = _FlightTask.Strike_Naval;
					return _FlightTask.Strike_Naval;
				case 5:
					result = _FlightTask.BAI;
					return _FlightTask.BAI;
				case 6:
					result = _FlightTask.CAS;
					return _FlightTask.CAS;
				case 7:
					result = _FlightTask.Buddy_Illumination;
					return _FlightTask.Buddy_Illumination;
				case 8:
					result = _FlightTask.CAP;
					return _FlightTask.CAP;
				case 9:
					result = _FlightTask.BARCAP;
					return _FlightTask.BARCAP;
				case 10:
					result = _FlightTask.TARCAP;
					return _FlightTask.TARCAP;
				case 11:
					result = _FlightTask.HAVCAP;
					return _FlightTask.HAVCAP;
				case 12:
					result = _FlightTask.RESCAP;
					return _FlightTask.RESCAP;
				case 13:
					result = _FlightTask.GLI;
					return _FlightTask.GLI;
				case 14:
					result = _FlightTask.DLI;
					return _FlightTask.DLI;
				case 15:
					result = _FlightTask.Sweep_Fighter;
					return _FlightTask.Sweep_Fighter;
				case 16:
					result = _FlightTask.Sweep_SEAD;
					return _FlightTask.Sweep_SEAD;
				case 17:
					result = _FlightTask.QRA;
					return _FlightTask.QRA;
				case 18:
					result = _FlightTask.Escort_TARCAP;
					return _FlightTask.Escort_TARCAP;
				case 19:
					result = _FlightTask.Escort_FighterSweep;
					return _FlightTask.Escort_FighterSweep;
				case 20:
					result = _FlightTask.Escort_SEAD;
					return _FlightTask.Escort_SEAD;
				case 21:
					result = _FlightTask.Escort_Support;
					return _FlightTask.Escort_Support;
				case 22:
					result = _FlightTask.ASAT;
					return _FlightTask.ASAT;
				case 23:
					result = _FlightTask.AirborneLaser;
					return _FlightTask.AirborneLaser;
				case 24:
					result = _FlightTask.OECM;
					return _FlightTask.OECM;
				case 25:
					result = _FlightTask.AEW;
					return _FlightTask.AEW;
				case 26:
					result = _FlightTask.CommandPost;
					return _FlightTask.CommandPost;
				case 27:
					result = _FlightTask.ChaffLaying;
					return _FlightTask.ChaffLaying;
				case 28:
					result = _FlightTask.SearchAndRescue;
					return _FlightTask.SearchAndRescue;
				case 29:
					result = _FlightTask.CombatSearchAndRescue;
					return _FlightTask.CombatSearchAndRescue;
				case 30:
					result = _FlightTask.MineSweeping;
					return _FlightTask.MineSweeping;
				case 31:
					result = _FlightTask.MineRecon;
					return _FlightTask.MineRecon;
				case 32:
					result = _FlightTask.NavalMineLaying;
					return _FlightTask.NavalMineLaying;
				case 33:
					result = _FlightTask.ASW;
					return _FlightTask.ASW;
				case 34:
					result = _FlightTask.Forward_Observer;
					return _FlightTask.Forward_Observer;
				case 35:
					result = _FlightTask.Area_Surveillance;
					return _FlightTask.Area_Surveillance;
				case 36:
					result = _FlightTask.Armed_Recon;
					return _FlightTask.Armed_Recon;
				case 37:
					result = _FlightTask.Unarmed_Recon;
					return _FlightTask.Unarmed_Recon;
				case 38:
					result = _FlightTask.Maritime_Surveillance;
					return _FlightTask.Maritime_Surveillance;
				case 39:
					result = _FlightTask.Paratroopers;
					return _FlightTask.Paratroopers;
				case 40:
					result = _FlightTask.Troop_Transport;
					return _FlightTask.Troop_Transport;
				case 41:
					result = _FlightTask.Cargo;
					return _FlightTask.Cargo;
				case 42:
					result = _FlightTask.AirRefueling;
					return _FlightTask.AirRefueling;
				case 43:
					result = _FlightTask.Support;
					return _FlightTask.Support;
				case 44:
					result = _FlightTask.Training;
					return _FlightTask.Training;
				case 45:
					result = _FlightTask.TargetTow;
					return _FlightTask.TargetTow;
				case 46:
					result = _FlightTask.TargetDrone;
					return _FlightTask.TargetDrone;
				case 47:
					result = _FlightTask.Ferry;
					return _FlightTask.Ferry;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 101297", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}

		public static int Task_To_TaskSelection(int int_1)
		{
			int result = 0;
			try
			{
				switch (int_1)
				{
				case 1:
					result = 0;
					return 0;
				case 2:
					result = 4;
					return 4;
				case 3:
					result = 1;
					return 1;
				case 4:
					result = 3;
					return 3;
				case 5:
					result = 15;
					return 15;
				case 6:
					result = 16;
					return 16;
				case 7:
					result = 5;
					return 5;
				case 8:
					result = 6;
					return 6;
				case 9:
					result = 8;
					return 8;
				case 10:
					result = 10;
					return 10;
				case 11:
					result = 9;
					return 9;
				case 12:
					result = 13;
					return 13;
				case 13:
					result = 14;
					return 14;
				case 14:
					result = 19;
					return 19;
				case 15:
					result = 18;
					return 18;
				case 16:
					result = 20;
					return 20;
				case 17:
					result = 22;
					return 22;
				case 18:
					result = 23;
					return 23;
				case 19:
					result = 7;
					return 7;
				case 20:
					result = 24;
					return 24;
				case 21:
					result = 25;
					return 25;
				case 22:
					result = 26;
					return 26;
				case 23:
					result = 27;
					return 27;
				case 24:
					result = 28;
					return 28;
				case 25:
					result = 29;
					return 29;
				case 26:
					result = 30;
					return 30;
				case 27:
					result = 31;
					return 31;
				case 28:
					result = 32;
					return 32;
				case 29:
					result = 33;
					return 33;
				case 30:
					result = 34;
					return 34;
				case 31:
					result = 35;
					return 35;
				case 32:
					result = 36;
					return 36;
				case 33:
					result = 37;
					return 37;
				case 34:
					result = 38;
					return 38;
				case 35:
					result = 39;
					return 39;
				case 36:
					result = 40;
					return 40;
				case 37:
					result = 41;
					return 41;
				case 38:
					result = 42;
					return 42;
				case 39:
					result = 44;
					return 44;
				case 40:
					result = 45;
					return 45;
				case 41:
					result = 46;
					return 46;
				case 42:
					result = 47;
					return 47;
				default:
					result = 0;
					return 0;
				case 44:
					result = 11;
					return 11;
				case 45:
					result = 12;
					return 12;
				case 46:
					result = 2;
					return 2;
				case 47:
					result = 43;
					return 43;
				case 48:
					result = 21;
					return 21;
				case 49:
					result = 17;
					return 17;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 101307", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}

		public static void ComboBoxDataSource_Priority(ref DataTable dataTable_0)
		{
			if (!dataTable_0.Columns.Contains("ID"))
			{
				dataTable_0.Columns.Add("ID", typeof(int));
			}
			if (!dataTable_0.Columns.Contains("Description"))
			{
				dataTable_0.Columns.Add("Description", typeof(string));
			}
			dataTable_0.Rows.Add(0, GetFlightPriorityString(_FlightPriority.Mandatory));
			dataTable_0.Rows.Add(1, GetFlightPriorityString(_FlightPriority.None));
		}

		public static _FlightPriority PrioritySelection_To_Priority(int int_1)
		{
			try
			{
				if (1 == 0)
				{
				}
				_FlightPriority result = int_1 switch
				{
					1 => _FlightPriority.None, 
					0 => _FlightPriority.Mandatory, 
					_ => _FlightPriority.None, 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 101298", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return _FlightPriority.None;
			}
		}

		public static int Priority_To_PrioritySelection(int int_1)
		{
			try
			{
				if (1 == 0)
				{
				}
				int result = int_1 switch
				{
					1 => 0, 
					0 => 1, 
					_ => 1, 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 101308", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return 0;
			}
		}

		public static void Combobox_AttackMethod(ref ComboBox comboBox_0, ref DataTable dataTable_0, _AttackMethod _AttackMethod_0)
		{
			if (!dataTable_0.Columns.Contains("ID"))
			{
				dataTable_0.Columns.Add("ID", typeof(int));
			}
			if (!dataTable_0.Columns.Contains("Description"))
			{
				dataTable_0.Columns.Add("Description", typeof(string));
			}
			dataTable_0.Rows.Add(0, "编队队形，单目标");
			dataTable_0.Rows.Add(1, "编队队形，独立目标");
			dataTable_0.Rows.Add(2, "在任务点分散避免时间冲突，独立目标");
			dataTable_0.Rows.Add(3, "在任务点梯形编队避免时间冲突，独立目标");
			ComboBox comboBox = comboBox_0;
			comboBox.DataSource = dataTable_0;
			comboBox.DisplayMember = "Description";
			comboBox.ValueMember = "ID";
			switch (_AttackMethod_0)
			{
			default:
				comboBox.SelectedIndex = 0;
				break;
			case _AttackMethod.Formation_SingleAim:
				comboBox.SelectedIndex = 0;
				break;
			case _AttackMethod.Formation_IndependentAim:
				comboBox.SelectedIndex = 1;
				break;
			case _AttackMethod.SplitAtActionPoint:
				comboBox.SelectedIndex = 2;
				break;
			case _AttackMethod.EchelonAtActionPoint:
				comboBox.SelectedIndex = 3;
				break;
			}
			comboBox = null;
		}

		public static void Combobox_AttackMethod(ref int int_1, ref _AttackMethod _AttackMethod_0)
		{
			switch (int_1)
			{
			default:
				_AttackMethod_0 = _AttackMethod.Formation_SingleAim;
				break;
			case 0:
				_AttackMethod_0 = _AttackMethod.Formation_SingleAim;
				break;
			case 1:
				_AttackMethod_0 = _AttackMethod.Formation_IndependentAim;
				break;
			case 2:
				_AttackMethod_0 = _AttackMethod.SplitAtActionPoint;
				break;
			case 3:
				_AttackMethod_0 = _AttackMethod.EchelonAtActionPoint;
				break;
			}
		}

		public static void Combobox_FlightSize(ref ComboBox comboBox_0, ref DataTable dataTable_0, _FlightSize _FlightSize_0)
		{
			if (!dataTable_0.Columns.Contains("ID"))
			{
				dataTable_0.Columns.Add("ID", typeof(int));
			}
			if (!dataTable_0.Columns.Contains("Description"))
			{
				dataTable_0.Columns.Add("Description", typeof(string));
			}
			dataTable_0.Rows.Add(0, GetFlightSizeString(1));
			dataTable_0.Rows.Add(1, GetFlightSizeString(2));
			dataTable_0.Rows.Add(2, GetFlightSizeString(3));
			dataTable_0.Rows.Add(3, GetFlightSizeString(4));
			dataTable_0.Rows.Add(4, GetFlightSizeString(6));
			ComboBox comboBox = comboBox_0;
			comboBox.DataSource = dataTable_0;
			comboBox.DisplayMember = "Description";
			comboBox.ValueMember = "ID";
			if (_FlightSize_0 == 1)
			{
				comboBox.SelectedIndex = 0;
			}
			else if (_FlightSize_0 == 2)
			{
				comboBox.SelectedIndex = 1;
			}
			else if (_FlightSize_0 == 3)
			{
				comboBox.SelectedIndex = 2;
			}
			else if (_FlightSize_0 == 4)
			{
				comboBox.SelectedIndex = 3;
			}
			else if (_FlightSize_0 == 6)
			{
				comboBox.SelectedIndex = 4;
			}
			comboBox = null;
		}

		public static void Combobox_GroupSize(ref ComboBox comboBox_0, ref DataTable dataTable_0, _GroupSize _GroupSize_0)
		{
			if (!dataTable_0.Columns.Contains("ID"))
			{
				dataTable_0.Columns.Add("ID", typeof(int));
			}
			if (!dataTable_0.Columns.Contains("Description"))
			{
				dataTable_0.Columns.Add("Description", typeof(string));
			}
			dataTable_0.Rows.Add(0, GetGroupSizeString(1));
			dataTable_0.Rows.Add(1, GetGroupSizeString(2));
			dataTable_0.Rows.Add(2, GetGroupSizeString(3));
			dataTable_0.Rows.Add(3, GetGroupSizeString(4));
			dataTable_0.Rows.Add(4, GetGroupSizeString(6));
			ComboBox comboBox = comboBox_0;
			comboBox.DataSource = dataTable_0;
			comboBox.DisplayMember = "Description";
			comboBox.ValueMember = "ID";
			if (_GroupSize_0 == 1)
			{
				comboBox.SelectedIndex = 0;
			}
			else if (_GroupSize_0 == 2)
			{
				comboBox.SelectedIndex = 1;
			}
			else if (_GroupSize_0 == 3)
			{
				comboBox.SelectedIndex = 2;
			}
			else if (_GroupSize_0 == 4)
			{
				comboBox.SelectedIndex = 3;
			}
			else if (_GroupSize_0 == 6)
			{
				comboBox.SelectedIndex = 4;
			}
			comboBox = null;
		}

		public static void Combobox_FlightSize_NonShooter(ref ComboBox comboBox_0, ref DataTable dataTable_0, _FlightSize _FlightSize_0)
		{
			if (!dataTable_0.Columns.Contains("ID"))
			{
				dataTable_0.Columns.Add("ID", typeof(int));
			}
			if (!dataTable_0.Columns.Contains("Description"))
			{
				dataTable_0.Columns.Add("Description", typeof(string));
			}
			dataTable_0.Rows.Add(0, "使用与战斗机和SEAD相同设置");
			dataTable_0.Rows.Add(1, "单架飞机，通常用于电子战和预警");
			ComboBox comboBox = comboBox_0;
			comboBox.DataSource = dataTable_0;
			comboBox.DisplayMember = "Description";
			comboBox.ValueMember = "ID";
			if (_FlightSize_0 == 0)
			{
				comboBox.SelectedIndex = 0;
			}
			else if (_FlightSize_0 == 1)
			{
				comboBox.SelectedIndex = 1;
			}
			comboBox = null;
		}

		public static void ComboBox_FlightSize_DataSource(ref DataTable dataTable_0)
		{
			if (!dataTable_0.Columns.Contains("ID"))
			{
				dataTable_0.Columns.Add("ID", typeof(int));
			}
			if (!dataTable_0.Columns.Contains("Description"))
			{
				dataTable_0.Columns.Add("Description", typeof(string));
			}
			dataTable_0.Rows.Add(0, GetFlightSizeString(1));
			dataTable_0.Rows.Add(1, GetFlightSizeString(2));
			dataTable_0.Rows.Add(2, GetFlightSizeString(3));
			dataTable_0.Rows.Add(3, GetFlightSizeString(4));
			dataTable_0.Rows.Add(4, GetFlightSizeString(6));
		}

		public static _FlightSize AircraftQtySelection_To_AircraftQty(int int_1)
		{
			try
			{
				if (1 == 0)
				{
				}
				int num = int_1 switch
				{
					0 => 1, 
					1 => 2, 
					2 => 3, 
					3 => 4, 
					4 => 6, 
					_ => 1, 
				};
				if (1 == 0)
				{
				}
				return num;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 101299", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				_FlightSize result = 0;
				ProjectData.ClearProjectError();
				return result;
			}
		}

		public static int AircraftQty_To_AircraftQtySelection(int int_1)
		{
			try
			{
				if (1 == 0)
				{
				}
				int result = int_1 switch
				{
					1 => 0, 
					2 => 1, 
					3 => 2, 
					4 => 3, 
					6 => 4, 
					_ => 0, 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 101310", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return 0;
			}
		}

		public static void ComboBoxDataSource_Type(ref DataTable dataTable_0)
		{
			if (!dataTable_0.Columns.Contains("ID"))
			{
				dataTable_0.Columns.Add("ID", typeof(int));
			}
			if (!dataTable_0.Columns.Contains("Description"))
			{
				dataTable_0.Columns.Add("Description", typeof(string));
			}
			dataTable_0.Rows.Add(0, Mission.GetFlightTypeString(_FlightType.Flightplan));
			dataTable_0.Rows.Add(1, Mission.GetFlightTypeString(_FlightType.FlightplanTemplate));
		}

		public static _FlightType TypeSelection_To_Type(int int_1)
		{
			try
			{
				if (1 == 0)
				{
				}
				_FlightType result = int_1 switch
				{
					1 => _FlightType.FlightplanTemplate, 
					0 => _FlightType.Flightplan, 
					_ => _FlightType.Flightplan, 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 101297", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return _FlightType.Flightplan;
			}
		}

		public static int Type_To_TypeSelection(int int_1)
		{
			try
			{
				if (1 == 0)
				{
				}
				int result = int_1 switch
				{
					1 => 1, 
					0 => 0, 
					_ => 0, 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return 0;
			}
		}

		[SpecialName]
		public static string GetFlightTypeString(_FlightType _FlightType_0)
		{
			if (1 == 0)
			{
			}
			string result = _FlightType_0 switch
			{
				_FlightType.FlightplanTemplate => "飞行计划模板", 
				_FlightType.Flightplan => "FLightplan", 
				_ => "未配置", 
			};
			if (1 == 0)
			{
			}
			return result;
		}

		internal Waypoint InterruptInterruptibleQueue(FlightElement flightElement_0, Waypoint.WaypointType waypointType_0)
		{
			Waypoint waypoint = FlightPlan.Where((Waypoint theWP) => theWP.Type == waypointType_0).FirstOrDefault();
			if (waypoint == null)
			{
				return null;
			}
			Waypoint waypoint2 = null;
			switch (flightElement_0)
			{
			case FlightElement.LeadElement:
				return waypoint;
			case FlightElement.LeadElementWingman:
				waypoint2 = waypoint.Waypoint_LeadElementWingman;
				break;
			case FlightElement.SecondElement:
				waypoint2 = waypoint.Waypoint_SecondElement;
				break;
			case FlightElement.SecondElementWingman:
				waypoint2 = waypoint.Waypoint_SecondElementWingman;
				break;
			case FlightElement.ThirdElement:
				waypoint2 = waypoint.Waypoint_ThirdElement;
				break;
			case FlightElement.ThirdElementWingman:
				waypoint2 = waypoint.Waypoint_ThirdElementWingman;
				break;
			}
			if (waypoint2 == null)
			{
				return waypoint;
			}
			return waypoint2;
		}

		[CompilerGenerated]
		private bool RemoveInterruptibleQueue(ActiveUnit activeUnit_0)
		{
			return Operators.CompareString(activeUnit_0.Navigator.GetFlight().Callsign, Callsign, TextCompare: false) == 0;
		}
	}

	public sealed class MissionAircraftEntry
	{
		public string HostUnitObjectID;

		public string HostUnitObjectName;

		public int AircraftDBID;

		public string AircraftName;

		public int int_0;

		public string LoadoutName;

		public bool IsMultiMission;

		public MissionAircraftEntry(string string_0, string string_1, int int_1, string string_2, int int_2, string string_3, bool bool_0 = false)
		{
			HostUnitObjectID = string_0;
			HostUnitObjectName = string_1;
			AircraftDBID = int_1;
			AircraftName = string_2;
			int_0 = int_2;
			LoadoutName = string_3;
			IsMultiMission = bool_0;
		}
	}

	public sealed class ContinousCoverageStation
	{
		public string FlightObjectID;

		public int AircraftDBID;

		public int int_0;

		public string HostUnitObjectID;

		public DateTime? StationStartTime;

		public DateTime? StationEndTime;

		public string FlightplanTemplateObjectID;

		public ContinousCoverageStation(string string_0, int int_1, int int_2, string string_1, DateTime? nullable_0, DateTime? nullable_1, string string_2)
		{
			FlightObjectID = string_0;
			AircraftDBID = int_1;
			int_0 = int_2;
			HostUnitObjectID = string_1;
			StationStartTime = nullable_0;
			StationEndTime = nullable_1;
			FlightplanTemplateObjectID = string_2;
		}

		public ContinousCoverageStation()
		{
		}

		public static void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, ref Scenario scenario_0, ref List<ContinousCoverageStation> list_0)
		{
			try
			{
				foreach (ContinousCoverageStation item in list_0)
				{
					xmlWriter_0.WriteStartElement("CCS");
					xmlWriter_0.WriteElementString("FlightObjectID", item.FlightObjectID);
					xmlWriter_0.WriteElementString("AircraftDBID", item.AircraftDBID.ToString());
					xmlWriter_0.WriteElementString("LoadoutDBID", item.int_0.ToString());
					xmlWriter_0.WriteElementString("HostUnitObjectID", item.HostUnitObjectID);
					if (item.StationStartTime.HasValue)
					{
						xmlWriter_0.WriteElementString("StationStartTime", item.StationStartTime.Value.ToBinary().ToString());
					}
					if (item.StationEndTime.HasValue)
					{
						xmlWriter_0.WriteElementString("StationEndTime", item.StationEndTime.Value.ToBinary().ToString());
					}
					xmlWriter_0.WriteElementString("FlightplanTemplateObjectID", item.FlightplanTemplateObjectID);
					xmlWriter_0.WriteEndElement();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static List<ContinousCoverageStation> FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
		{
			try
			{
				List<ContinousCoverageStation> list = new List<ContinousCoverageStation>();
				IEnumerator enumerator = null;
				try
				{
					enumerator = xmlNode_0.ChildNodes.GetEnumerator();
					IEnumerator enumerator2 = null;
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode = (XmlNode)enumerator.Current;
						if (Operators.CompareString(xmlNode.Name, "CCS", TextCompare: false) != 0)
						{
							continue;
						}
						ContinousCoverageStation continousCoverageStation = new ContinousCoverageStation();
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
								switch (xmlNode2.Name)
								{
								case "LoadoutDBID":
									continousCoverageStation.int_0 = Conversions.ToInteger(xmlNode2.InnerText);
									break;
								case "FlightObjectID":
									continousCoverageStation.FlightObjectID = xmlNode2.InnerText;
									break;
								case "StationEndTime":
								{
									DateTime value2 = DateTime.FromBinary(Conversions.ToLong(xmlNode2.InnerText));
									continousCoverageStation.StationEndTime = value2;
									break;
								}
								case "FlightplanTemplateObjectID":
									continousCoverageStation.FlightplanTemplateObjectID = xmlNode2.InnerText;
									break;
								case "StationStartTime":
								{
									DateTime value = DateTime.FromBinary(Conversions.ToLong(xmlNode2.InnerText));
									continousCoverageStation.StationStartTime = value;
									break;
								}
								case "HostUnitObjectID":
									continousCoverageStation.HostUnitObjectID = xmlNode2.InnerText;
									break;
								case "AircraftDBID":
									continousCoverageStation.AircraftDBID = Conversions.ToInteger(xmlNode2.InnerText);
									break;
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
						list.Add(continousCoverageStation);
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				return list;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				List<ContinousCoverageStation> result = new List<ContinousCoverageStation>();
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public sealed class EmptyAircraftSlot
	{
		private ActiveUnit tokenizerItem;

		public int ReferenceUnit_DBID;

		public string ReferenceUnit_UnitClass;

		public int int_0;

		public string LoadoutName;

		public bool Loadout_ExcludeOptionalWeapons;

		public bool Loadout_QuickTurnaround;

		public int Loadout_QuickTurnaround_NumberOfSorties;

		public int Loadout_QuickTurnaround_MaxSorties;

		private Flight stubItem;

		public string MissionFlight_ObjectID;

		private ActiveUnit _WriterItem;

		public string CurrentHostUnit_ObjectID;

		public string CurrentHostUnit_Name;

		public int NumberOfUnits;

		public bool IsEscort;

		public EmptyAircraftSlot()
		{
			Loadout_ExcludeOptionalWeapons = false;
		}

		public EmptyAircraftSlot(ActiveUnit activeUnit_0, int int_1, string string_0, int int_2, string string_1, ref ActiveUnit activeUnit_1, string string_2, string string_3, bool bool_0)
		{
			Loadout_ExcludeOptionalWeapons = false;
			tokenizerItem = activeUnit_0;
			ReferenceUnit_DBID = int_1;
			ReferenceUnit_UnitClass = string_0;
			int_0 = int_2;
			LoadoutName = string_1;
			IsEscort = bool_0;
			_WriterItem = activeUnit_1;
			CurrentHostUnit_ObjectID = string_2;
			CurrentHostUnit_Name = string_3;
		}

		public void Clear()
		{
			tokenizerItem = null;
			stubItem = null;
			_WriterItem = null;
		}

		[SpecialName]
		public ActiveUnit GetReferenceUnit(Scenario scenario_0, Mission mission_0)
		{
			if (Information.IsNothing(tokenizerItem) && ReferenceUnit_DBID > 0)
			{
				foreach (ActiveUnit value in scenario_0.ActiveUnits.Values)
				{
					if (value.IsAircraft && value.DBID == ReferenceUnit_DBID)
					{
						Aircraft aircraft = (Aircraft)value;
						if (!Information.IsNothing(aircraft.Loadout) && aircraft.Loadout.DBID == int_0 && !Information.IsNothing(aircraft.AirOps.CurrentHostUnit) && (Information.IsNothing(_WriterItem) || aircraft.AirOps.CurrentHostUnit == _WriterItem) && !Information.IsNothing(value.AssignedTaskPool) && value.AssignedTaskPool == mission_0)
						{
							tokenizerItem = value;
							break;
						}
					}
				}
			}
			return tokenizerItem;
		}

		[SpecialName]
		public void SetReferenceUnit(Scenario scenario_0, Mission mission_0, ActiveUnit activeUnit_0)
		{
			tokenizerItem = activeUnit_0;
			if (activeUnit_0 != null)
			{
				ReferenceUnit_DBID = tokenizerItem.DBID;
				ReferenceUnit_UnitClass = tokenizerItem.UnitClass;
			}
		}

		[SpecialName]
		public ActiveUnit GetCurrentHostUnit(Scenario scenario_0)
		{
			if (Information.IsNothing(_WriterItem) && !string.IsNullOrEmpty(CurrentHostUnit_ObjectID))
			{
				foreach (ActiveUnit value in scenario_0.ActiveUnits.Values)
				{
					if (Operators.CompareString(value.ObjectID, CurrentHostUnit_ObjectID, TextCompare: false) == 0)
					{
						_WriterItem = value;
						break;
					}
				}
			}
			return _WriterItem;
		}

		[SpecialName]
		public void SetCurrentHostUnit(Scenario scenario_0, ActiveUnit activeUnit_0)
		{
			_WriterItem = activeUnit_0;
		}

		[SpecialName]
		public Flight GetMissionFlight(Scenario scenario_0)
		{
			if (Information.IsNothing(stubItem) && !string.IsNullOrEmpty(MissionFlight_ObjectID))
			{
				bool flag = false;
				Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
				for (int i = 0; i < sides_ReadOnly.Length; i++)
				{
					foreach (Mission mission in sides_ReadOnly[i].Missions)
					{
						if (mission.RestartValue())
						{
							foreach (Flight flight in mission.FlightList)
							{
								if (Operators.CompareString(flight.ObjectID, MissionFlight_ObjectID, TextCompare: false) == 0)
								{
									stubItem = flight;
									flag = true;
									break;
								}
							}
						}
						if (flag)
						{
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
			}
			return stubItem;
		}

		[SpecialName]
		public void SetMissionFlight(Scenario scenario_0, Flight flight_0)
		{
			stubItem = flight_0;
			if (flight_0 != null)
			{
				MissionFlight_ObjectID = stubItem.ObjectID;
			}
		}

		public static void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, ref Scenario scenario_0, ref List<EmptyAircraftSlot> list_0)
		{
			try
			{
				xmlWriter_0.WriteStartElement("EmptySlotsList");
				foreach (EmptyAircraftSlot item in list_0)
				{
					xmlWriter_0.WriteStartElement("EmptySlot");
					xmlWriter_0.WriteElementString("DBID", item.ReferenceUnit_DBID.ToString());
					if (Information.IsNothing(item.ReferenceUnit_UnitClass))
					{
						xmlWriter_0.WriteElementString("UnitClass", "Any type");
					}
					else
					{
						xmlWriter_0.WriteElementString("UnitClass", item.ReferenceUnit_UnitClass.ToString());
					}
					xmlWriter_0.WriteElementString("LoadoutDBID", item.int_0.ToString());
					xmlWriter_0.WriteElementString("LoadoutName", item.LoadoutName.ToString());
					xmlWriter_0.WriteElementString("Loadout_ExcludeOptionalWeapons", item.Loadout_ExcludeOptionalWeapons.ToString());
					xmlWriter_0.WriteElementString("Loadout_QuickTurnaround", item.Loadout_QuickTurnaround.ToString());
					xmlWriter_0.WriteElementString("Loadout_QuickTurnaround_NumberOfSorties", item.Loadout_QuickTurnaround_NumberOfSorties.ToString());
					xmlWriter_0.WriteElementString("Loadout_QuickTurnaround_MaxSorties", item.Loadout_QuickTurnaround_MaxSorties.ToString());
					xmlWriter_0.WriteElementString("CurrentHostUnit_ObjectID", item.CurrentHostUnit_ObjectID.ToString());
					xmlWriter_0.WriteElementString("CurrentHostUnit_Name", item.CurrentHostUnit_Name.ToString());
					xmlWriter_0.WriteElementString("IsEscort", item.IsEscort.ToString());
					if (!string.IsNullOrEmpty(item.MissionFlight_ObjectID))
					{
						xmlWriter_0.WriteElementString("MissionFlight_ObjectID", item.MissionFlight_ObjectID.ToString());
					}
					xmlWriter_0.WriteEndElement();
				}
				xmlWriter_0.WriteEndElement();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 200646", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static List<EmptyAircraftSlot> FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
		{
			try
			{
				List<EmptyAircraftSlot> list = new List<EmptyAircraftSlot>();
				IEnumerator enumerator = null;
				try
				{
					enumerator = xmlNode_0.ChildNodes.GetEnumerator();
					IEnumerator enumerator2 = null;
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode = (XmlNode)enumerator.Current;
						if (Operators.CompareString(xmlNode.Name, "EmptySlot", TextCompare: false) != 0)
						{
							continue;
						}
						EmptyAircraftSlot emptyAircraftSlot = new EmptyAircraftSlot();
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
								switch (xmlNode2.Name)
								{
								case "CurrentHostUnit_ObjectID":
									emptyAircraftSlot.CurrentHostUnit_ObjectID = xmlNode2.InnerText;
									break;
								case "LoadoutDBID":
									emptyAircraftSlot.int_0 = Conversions.ToInteger(xmlNode2.InnerText);
									break;
								case "LoadoutName":
									emptyAircraftSlot.LoadoutName = xmlNode2.InnerText;
									break;
								case "UnitClass":
									emptyAircraftSlot.ReferenceUnit_UnitClass = xmlNode2.InnerText;
									break;
								case "Loadout_QuickTurnaround_NumberOfSorties":
									emptyAircraftSlot.Loadout_QuickTurnaround_NumberOfSorties = Conversions.ToInteger(xmlNode2.InnerText);
									break;
								case "CurrentHostUnit_Name":
									emptyAircraftSlot.CurrentHostUnit_Name = xmlNode2.InnerText;
									break;
								case "Loadout_QuickTurnaround":
									emptyAircraftSlot.Loadout_QuickTurnaround = Conversions.ToBoolean(xmlNode2.InnerText);
									break;
								case "DBID":
									emptyAircraftSlot.ReferenceUnit_DBID = Conversions.ToInteger(xmlNode2.InnerText);
									break;
								case "IsEscort":
									emptyAircraftSlot.IsEscort = Conversions.ToBoolean(xmlNode2.InnerText);
									break;
								case "MissionFlight_ObjectID":
									emptyAircraftSlot.MissionFlight_ObjectID = xmlNode2.InnerText;
									break;
								case "Loadout_ExcludeOptionalWeapons":
									emptyAircraftSlot.Loadout_ExcludeOptionalWeapons = Conversions.ToBoolean(xmlNode2.InnerText);
									break;
								case "Loadout_QuickTurnaround_MaxSorties":
									emptyAircraftSlot.Loadout_QuickTurnaround_MaxSorties = Conversions.ToInteger(xmlNode2.InnerText);
									break;
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
						list.Add(emptyAircraftSlot);
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				return list;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 200647", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				List<EmptyAircraftSlot> result = new List<EmptyAircraftSlot>();
				ProjectData.ClearProjectError();
				return result;
			}
		}

		public void SetFlight(Scenario scenario_0, Flight flight_0, int int_1)
		{
			SetMissionFlight(scenario_0, flight_0);
		}
	}

	public sealed class TargeteeringEntry
	{
		public string ObjectID;

		public int Target_Type;

		public string Target_Description;

		public string Target_ContactObjectID;

		public string Target_ActualUnitObjectID;

		public int Target_ActualUnitDBID;

		public double Target_Latitude;

		public double Target_Longitude;

		public GeoPoint Target_PreliminaryPoint;

		public List<GeoPoint> Target_Area;

		public TargeteeringEntry()
		{
		}

		public TargeteeringEntry(string string_0, int int_0, string string_1, string string_2, string string_3, int int_1, double double_0, double double_1, GeoPoint geoPoint_0, GeoPoint geoPoint_1, List<GeoPoint> list_0)
		{
			ObjectID = string_0;
			Target_Type = int_0;
			Target_Description = string_1;
			Target_ContactObjectID = string_2;
			Target_ActualUnitObjectID = string_3;
			Target_ActualUnitDBID = int_1;
			Target_Latitude = double_0;
			Target_Longitude = double_1;
			Target_PreliminaryPoint = geoPoint_0;
			Target_Area = list_0;
		}

		public static void ToXML(ref XmlWriter xmlWriter_0, ref TargeteeringEntry targeteeringEntry_0)
		{
			try
			{
				xmlWriter_0.WriteStartElement("TargeteeringEntry");
				xmlWriter_0.WriteElementString("ID", targeteeringEntry_0.ObjectID.ToString());
				xmlWriter_0.WriteElementString("Target_Type", targeteeringEntry_0.Target_Type.ToString());
				xmlWriter_0.WriteElementString("Target_Description", targeteeringEntry_0.Target_Description.ToString());
				xmlWriter_0.WriteElementString("Target_ContactObjectID", targeteeringEntry_0.Target_ContactObjectID.ToString());
				xmlWriter_0.WriteElementString("Target_ActualUnitObjectID", targeteeringEntry_0.Target_ActualUnitObjectID.ToString());
				xmlWriter_0.WriteElementString("Target_ActualUnitDBID", targeteeringEntry_0.Target_ActualUnitDBID.ToString());
				xmlWriter_0.WriteElementString("Target_Latitude", targeteeringEntry_0.Target_Latitude.ToString());
				xmlWriter_0.WriteElementString("Target_Longitude", targeteeringEntry_0.Target_Longitude.ToString());
				xmlWriter_0.WriteEndElement();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static TargeteeringEntry FromXML(ref XmlNode xmlNode_0)
		{
			try
			{
				TargeteeringEntry targeteeringEntry = new TargeteeringEntry();
				IEnumerator enumerator = null;
				try
				{
					enumerator = xmlNode_0.ChildNodes.GetEnumerator();
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode = (XmlNode)enumerator.Current;
						switch (xmlNode.Name)
						{
						case "Target_Type":
							targeteeringEntry.Target_Type = Conversions.ToInteger(xmlNode.InnerText);
							break;
						case "Target_ContactObjectID":
							targeteeringEntry.Target_ContactObjectID = xmlNode.InnerText;
							break;
						case "ID":
							targeteeringEntry.ObjectID = xmlNode.InnerText;
							break;
						case "Target_Latitude":
							targeteeringEntry.Target_Latitude = Conversions.ToDouble(xmlNode.InnerText);
							break;
						case "Target_ActualUnitObjectID":
							targeteeringEntry.Target_ActualUnitObjectID = xmlNode.InnerText;
							break;
						case "Target_ActualUnitDBID":
							targeteeringEntry.Target_ActualUnitDBID = Conversions.ToInteger(xmlNode.InnerText);
							break;
						case "Target_Description":
							targeteeringEntry.Target_Description = xmlNode.InnerText;
							break;
						case "Target_Longitude":
							targeteeringEntry.Target_Longitude = Conversions.ToDouble(xmlNode.InnerText);
							break;
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
				return targeteeringEntry;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 999999", "");
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

	public sealed class WeaponeeringEntry
	{
		public int int_0;

		public Weapon._WeaponType WeaponType;

		public string WeaponName;

		public float WeaponMaxRange;

		public float WeaponMinRange;

		public bool bool_0;

		public string TargeteeringEntryObjectID;

		public int LostTarget;

		public int WeaponQty;

		public int WeaponMaxQty;

		public int FiringRange;

		public Waypoint[] Route;

		public bool IsRouteReference;

		public WeaponeeringEntry()
		{
			IsRouteReference = false;
		}

		public WeaponeeringEntry(int int_1, Weapon._WeaponType _WeaponType_0, string string_0, float float_0, float float_1, bool bool_1, string string_1, int int_2, int int_3, int int_4, int int_5, ref Waypoint[] waypoint_0)
		{
			IsRouteReference = false;
			int_0 = int_1;
			WeaponType = _WeaponType_0;
			WeaponName = string_0;
			WeaponMaxRange = float_0;
			WeaponMinRange = float_1;
			bool_0 = bool_1;
			TargeteeringEntryObjectID = string_1;
			LostTarget = int_2;
			WeaponQty = int_3;
			WeaponMaxQty = int_4;
			FiringRange = int_5;
			Route = waypoint_0;
		}

		public static void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, ref WeaponeeringEntry weaponeeringEntry_0)
		{
			try
			{
				xmlWriter_0.WriteStartElement("WeaponeeringEntry");
				xmlWriter_0.WriteElementString("WeaponDBID", weaponeeringEntry_0.int_0.ToString());
				XmlWriter obj = xmlWriter_0;
				int weaponType = (int)weaponeeringEntry_0.WeaponType;
				obj.WriteElementString("WeaponType", weaponType.ToString());
				xmlWriter_0.WriteElementString("WeaponName", weaponeeringEntry_0.WeaponName.ToString());
				xmlWriter_0.WriteElementString("WeaponMaxRange", weaponeeringEntry_0.WeaponMaxRange.ToString());
				xmlWriter_0.WriteElementString("WeaponMinRange", weaponeeringEntry_0.WeaponMinRange.ToString());
				xmlWriter_0.WriteElementString("WeaponIsBOLCapable", weaponeeringEntry_0.bool_0.ToString());
				xmlWriter_0.WriteElementString("TargeteeringEntryObjectID", weaponeeringEntry_0.TargeteeringEntryObjectID.ToString());
				xmlWriter_0.WriteElementString("LostTarget", weaponeeringEntry_0.LostTarget.ToString());
				xmlWriter_0.WriteElementString("WeaponQty", weaponeeringEntry_0.WeaponQty.ToString());
				xmlWriter_0.WriteElementString("WeaponMaxQty", weaponeeringEntry_0.WeaponMaxQty.ToString());
				xmlWriter_0.WriteElementString("FiringRange", weaponeeringEntry_0.FiringRange.ToString());
				xmlWriter_0.WriteElementString("IsRouteReference", weaponeeringEntry_0.IsRouteReference.ToString());
				if (!Information.IsNothing(weaponeeringEntry_0.Route) && weaponeeringEntry_0.Route.Count() > 0)
				{
					xmlWriter_0.WriteStartElement("Route");
					List<Waypoint> list = new List<Waypoint>();
					list.AddRange(weaponeeringEntry_0.Route);
					foreach (Waypoint item in list)
					{
						if (!Information.IsNothing(item))
						{
							item.ToXML(ref xmlWriter_0, ref hashSet_0);
						}
					}
					xmlWriter_0.WriteEndElement();
				}
				xmlWriter_0.WriteEndElement();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static WeaponeeringEntry FromXML(ref XmlNode xmlNode_0, ref Scenario scenario_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
		{
			try
			{
				WeaponeeringEntry weaponeeringEntry = new WeaponeeringEntry();
				IEnumerator enumerator = null;
				try
				{
					enumerator = xmlNode_0.ChildNodes.GetEnumerator();
					IEnumerator enumerator2 = null;
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode = (XmlNode)enumerator.Current;
						switch (xmlNode.Name)
						{
						case "FiringRange":
							weaponeeringEntry.FiringRange = Conversions.ToInteger(xmlNode.InnerText);
							break;
						case "WeaponMinRange":
							weaponeeringEntry.WeaponMinRange = Conversions.ToInteger(xmlNode.InnerText);
							break;
						case "WeaponMaxQty":
							weaponeeringEntry.WeaponMaxQty = Conversions.ToInteger(xmlNode.InnerText);
							break;
						case "IsRouteReference":
							weaponeeringEntry.IsRouteReference = Conversions.ToBoolean(xmlNode.InnerText);
							break;
						case "WeaponType":
							weaponeeringEntry.WeaponType = (Weapon._WeaponType)Conversions.ToShort(xmlNode.InnerText);
							break;
						case "WeaponQty":
							weaponeeringEntry.WeaponQty = Conversions.ToInteger(xmlNode.InnerText);
							break;
						case "WeaponName":
							weaponeeringEntry.WeaponName = xmlNode.InnerText;
							break;
						case "TargeteeringEntryObjectID":
							weaponeeringEntry.TargeteeringEntryObjectID = xmlNode.InnerText;
							break;
						case "WeaponMaxRange":
							weaponeeringEntry.WeaponMaxRange = Conversions.ToInteger(xmlNode.InnerText);
							break;
						case "Route":
							weaponeeringEntry.Route = new Waypoint[0];
							try
							{
								enumerator2 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
									Waypoint theAC = Waypoint.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
									ArrayExtensions.Add(ref weaponeeringEntry.Route, theAC);
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
						case "WeaponDBID":
							weaponeeringEntry.int_0 = Conversions.ToInteger(xmlNode.InnerText);
							break;
						case "WeaponIsBOLCapable":
							weaponeeringEntry.bool_0 = Conversions.ToBoolean(xmlNode.InnerText);
							break;
						case "LostTarget":
							weaponeeringEntry.LostTarget = Conversions.ToInteger(xmlNode.InnerText);
							break;
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
				return weaponeeringEntry;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 999999", "");
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

	[CompilerGenerated]
	private sealed class SpecificationItem
	{
		public string escortTargetMissionID;

		internal bool FindInterruptibleQueue(Mission m)
		{
			return Operators.CompareString(m.ObjectID, escortTargetMissionID, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class EventCollectionRecord
	{
		public ActiveUnit HostUnit;

		internal float SetInterruptibleQueue(ReferencePoint s)
		{
			return s.RangeToPoint_Horiz(HostUnit.GetLongitude(), HostUnit.GetLatitude());
		}

		internal float FillInterruptibleQueue(ReferencePoint s)
		{
			return s.RangeToPoint_Horiz(HostUnit.GetLongitude(), HostUnit.GetLatitude());
		}

		internal float CalculateInterruptibleQueue(ReferencePoint s)
		{
			return s.RangeToPoint_Horiz(HostUnit.GetLongitude(), HostUnit.GetLatitude());
		}

		internal float PopInterruptibleQueue(ReferencePoint s)
		{
			return s.RangeToPoint_Horiz(HostUnit.GetLongitude(), HostUnit.GetLatitude());
		}

		internal float InstantiateInterruptibleQueue(ReferencePoint s)
		{
			return s.RangeToPoint_Horiz(HostUnit.GetLongitude(), HostUnit.GetLatitude());
		}
	}

	[CompilerGenerated]
	private sealed class WatcherItem
	{
		public Scenario Local_theScen;

		internal bool CreateInterruptibleQueue(EmptyAircraftSlot theES)
		{
			if (theES.IsEscort && !Information.IsNothing(theES.GetMissionFlight(Local_theScen)) && !Information.IsNothing(theES.GetMissionFlight(Local_theScen).FlightPlan))
			{
				return theES.GetMissionFlight(Local_theScen).FlightPlan.Count() == 0;
			}
			return false;
		}

		internal string CompareInterruptibleQueue(EmptyAircraftSlot theES)
		{
			return theES.GetMissionFlight(Local_theScen).Callsign;
		}

		internal bool ReadInterruptibleQueue(EmptyAircraftSlot theES)
		{
			if (!Information.IsNothing(theES.GetMissionFlight(Local_theScen)) && !Information.IsNothing(theES.GetMissionFlight(Local_theScen).FlightPlan))
			{
				return theES.GetMissionFlight(Local_theScen).FlightPlan.Count() > 0;
			}
			return false;
		}

		internal DateTime? DisableInterruptibleQueue(EmptyAircraftSlot theES)
		{
			return theES.GetMissionFlight(Local_theScen).FlightPlan[0].Time_Zulu;
		}

		internal string UpdateInterruptibleQueue(EmptyAircraftSlot theES)
		{
			return theES.GetMissionFlight(Local_theScen).Callsign;
		}

		internal bool InsertInterruptibleQueue(EmptyAircraftSlot theES)
		{
			if (!theES.IsEscort && !Information.IsNothing(theES.GetMissionFlight(Local_theScen)) && !Information.IsNothing(theES.GetMissionFlight(Local_theScen).FlightPlan))
			{
				return theES.GetMissionFlight(Local_theScen).FlightPlan.Count() == 0;
			}
			return false;
		}
	}

	public Doctrine Doctrine;

	public MissionCategory Category;

	public _MissionClass MissionClass;

	protected DateTime? _StartTime;

	protected DateTime? _EndTime;

	protected DateTime? _TakeOffTime;

	protected DateTime? _TimeOnTarget;

	public bool ScrubIfSideIsHuman;

	private MissionStatus _WrapperConsumer;

	public bool UseFlightSizeHardLimit;

	public bool UseGroupSizeHardLimit;

	public int TimeSincePlayerNotification;

	public List<Flight> MasterFlightList;

	public List<Flight> FlightList;

	private _FlightSize _ObserverConsumer;

	public _GroupSize GroupSize;

	private string _IssuerConsumer;

	public List<EmptyAircraftSlot> EmptySlotsList;

	public bool UseFlightplans;

	public bool UsePreGeneratedFlightplansOnly;

	public bool IncludeInATO;

	public bool FlightPlanPreventShotgunRTB;

	public TankerMethod TankerUsage;

	public List<string> TankerMissions_IDs;

	public List<Mission> TankerMissions;

	public int TankerMinNumber_Total;

	public int TankerMinNumber_Airborne;

	public int TankerMinNumber_Station;

	public bool LaunchMissionWithoutTankersInPlace;

	public int MaxReceiversInQueuePerTanker_Airborne;

	public int FuelQtyToStartLookingForTanker_Airborne;

	public int TankerMaxDistance_Airborne;

	public bool TankerFollowsReceivers;

	public bool Deactivation_UnassignUnits;

	public bool Deactivation_OrderRTB;

	public bool Deactivation_DeleteMission;

	public string _SecondaryAirBaseID;

	public string _SecondaryNavalBaseID;

	public ActiveUnit SecondaryAirBase;

	public ActiveUnit SecondaryNavalBase;

	public Dictionary<ActiveUnit, ActiveUnit> UnitsQueuedToMission;

	public ConcurrentDictionary<ActiveUnit, ActiveUnit> UnitsAssignedToMission;

	public List<string> UnitsAssignedToMissionIDs;

	public int PriorityWeight;

	public string _OperationName;

	public float Completion;

	public MissionPhase _Phase;

	public MissionCreationType CreationMode;

	public int MissionStartTrigger_Time;

	public bool MissionStartTrigger_Time_Enabled;

	public bool MissionStartTrigger_Time_LastResult;

	public bool MissionStartTrigger_Time_Operator;

	public Dictionary<Mission, Mission> MissionStartTrigger_MissionCompleted;

	public List<string> _MissionStartTrigger_MissionCompletedID;

	public bool MissionStartTrigger_MissionCompleted_Enabled;

	public bool MissionStartTrigger_MissionCompleted_LastResult;

	public bool MissionStartTrigger_MissionCompleted_Operator;

	public string MissionStartTrigger_LUADescription;

	public string MissionStartTrigger_LUA;

	public bool MissionStartTrigger_LUA_Enabled;

	public bool MissionStartTrigger_LUA_LastResult;

	public bool MissionStartTrigger_LUA_Operator;

	public float MissionCompletedTrigger_ElapsedTime;

	public float MissionCompletedTrigger_ElapsedTime_Current;

	public bool MissionCompletedTrigger_ElapsedTime_Enabled;

	public bool MissionCompletedTrigger_ElapsedTime_LastResult;

	public bool MissionCompletedTrigger_ElapsedTime_Operator;

	public string MissionCompletedTrigger_LUADescription;

	public string MissionCompletedTrigger_LUA;

	public bool MissionCompletedTrigger_LUA_Enabled;

	public bool MissionCompletedTrigger_LUA_LastResult;

	public bool MissionCompletedTrigger_LUA_Operator;

	public int EstimatedExecutionTime;

	public LandingPlan LandingPlan;

	public bool MarkedForBulkEdition;

	[CompilerGenerated]
	private static StartTimeChangedEventHandler _ClientConsumer;

	[CompilerGenerated]
	private static EndTimeChangedEventHandler _DicConsumer;

	[CompilerGenerated]
	private static TakeOffTimeChangedEventHandler m_ConsumerConsumer;

	[CompilerGenerated]
	private static TimeOnTargetChangedEventHandler m_FacadeConsumer;

	public _FlightSize FlightSize
	{
		get
		{
			return _ObserverConsumer;
		}
		set
		{
			_ObserverConsumer = value;
		}
	}

	public string OperationName
	{
		get
		{
			if (string.IsNullOrEmpty(_OperationName))
			{
				if (LandingPlan == null)
				{
					return _OperationName;
				}
				return LandingPlan.Name;
			}
			return _OperationName;
		}
		set
		{
			_OperationName = value;
		}
	}

	public bool IsActive => _WrapperConsumer == MissionStatus.Active;

	public DateTime? StartTime => _StartTime;

	public DateTime? EndTime => _EndTime;

	public DateTime? TakeOffTime
	{
		get
		{
			return _TakeOffTime;
		}
		set
		{
			bool flag = false;
			if (Information.IsNothing(_TakeOffTime) && value.HasValue)
			{
				flag = true;
			}
			else if (!value.HasValue && !Information.IsNothing(_TakeOffTime))
			{
				flag = true;
			}
			else
			{
				DateTime? takeOffTime = _TakeOffTime;
				bool? flag2 = ((takeOffTime.HasValue & value.HasValue) ? new bool?(DateTime.Compare(takeOffTime.GetValueOrDefault(), value.GetValueOrDefault()) == 0) : null);
				if (((!flag2) ?? flag2).GetValueOrDefault())
				{
					flag = true;
				}
			}
			_TakeOffTime = value;
			if (flag)
			{
				m_ConsumerConsumer?.Invoke(this);
			}
		}
	}

	public DateTime? TimeOnTarget
	{
		get
		{
			return _TimeOnTarget;
		}
		set
		{
			bool flag = false;
			if (Information.IsNothing(_TimeOnTarget) && value.HasValue)
			{
				flag = true;
			}
			else if (!value.HasValue && !Information.IsNothing(_TimeOnTarget))
			{
				flag = true;
			}
			else
			{
				DateTime? timeOnTarget = _TimeOnTarget;
				bool? flag2 = ((timeOnTarget.HasValue & value.HasValue) ? new bool?(DateTime.Compare(timeOnTarget.GetValueOrDefault(), value.GetValueOrDefault()) == 0) : null);
				if (((!flag2) ?? flag2).GetValueOrDefault())
				{
					flag = true;
				}
			}
			_TimeOnTarget = value;
			if (flag)
			{
				m_FacadeConsumer?.Invoke(this);
			}
		}
	}

	public static event StartTimeChangedEventHandler StartTimeChanged
	{
		[CompilerGenerated]
		add
		{
			StartTimeChangedEventHandler startTimeChangedEventHandler = _ClientConsumer;
			StartTimeChangedEventHandler startTimeChangedEventHandler2;
			do
			{
				startTimeChangedEventHandler2 = startTimeChangedEventHandler;
				StartTimeChangedEventHandler value2 = (StartTimeChangedEventHandler)Delegate.Combine(startTimeChangedEventHandler2, value);
				startTimeChangedEventHandler = Interlocked.CompareExchange(ref _ClientConsumer, value2, startTimeChangedEventHandler2);
			}
			while ((object)startTimeChangedEventHandler != startTimeChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			StartTimeChangedEventHandler startTimeChangedEventHandler = _ClientConsumer;
			StartTimeChangedEventHandler startTimeChangedEventHandler2;
			do
			{
				startTimeChangedEventHandler2 = startTimeChangedEventHandler;
				StartTimeChangedEventHandler value2 = (StartTimeChangedEventHandler)Delegate.Remove(startTimeChangedEventHandler2, value);
				startTimeChangedEventHandler = Interlocked.CompareExchange(ref _ClientConsumer, value2, startTimeChangedEventHandler2);
			}
			while ((object)startTimeChangedEventHandler != startTimeChangedEventHandler2);
		}
	}

	public static event EndTimeChangedEventHandler EndTimeChanged
	{
		[CompilerGenerated]
		add
		{
			EndTimeChangedEventHandler endTimeChangedEventHandler = _DicConsumer;
			EndTimeChangedEventHandler endTimeChangedEventHandler2;
			do
			{
				endTimeChangedEventHandler2 = endTimeChangedEventHandler;
				EndTimeChangedEventHandler value2 = (EndTimeChangedEventHandler)Delegate.Combine(endTimeChangedEventHandler2, value);
				endTimeChangedEventHandler = Interlocked.CompareExchange(ref _DicConsumer, value2, endTimeChangedEventHandler2);
			}
			while ((object)endTimeChangedEventHandler != endTimeChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EndTimeChangedEventHandler endTimeChangedEventHandler = _DicConsumer;
			EndTimeChangedEventHandler endTimeChangedEventHandler2;
			do
			{
				endTimeChangedEventHandler2 = endTimeChangedEventHandler;
				EndTimeChangedEventHandler value2 = (EndTimeChangedEventHandler)Delegate.Remove(endTimeChangedEventHandler2, value);
				endTimeChangedEventHandler = Interlocked.CompareExchange(ref _DicConsumer, value2, endTimeChangedEventHandler2);
			}
			while ((object)endTimeChangedEventHandler != endTimeChangedEventHandler2);
		}
	}

	public static event TakeOffTimeChangedEventHandler TakeOffTimeChanged
	{
		[CompilerGenerated]
		add
		{
			TakeOffTimeChangedEventHandler takeOffTimeChangedEventHandler = m_ConsumerConsumer;
			TakeOffTimeChangedEventHandler takeOffTimeChangedEventHandler2;
			do
			{
				takeOffTimeChangedEventHandler2 = takeOffTimeChangedEventHandler;
				TakeOffTimeChangedEventHandler value2 = (TakeOffTimeChangedEventHandler)Delegate.Combine(takeOffTimeChangedEventHandler2, value);
				takeOffTimeChangedEventHandler = Interlocked.CompareExchange(ref m_ConsumerConsumer, value2, takeOffTimeChangedEventHandler2);
			}
			while ((object)takeOffTimeChangedEventHandler != takeOffTimeChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TakeOffTimeChangedEventHandler takeOffTimeChangedEventHandler = m_ConsumerConsumer;
			TakeOffTimeChangedEventHandler takeOffTimeChangedEventHandler2;
			do
			{
				takeOffTimeChangedEventHandler2 = takeOffTimeChangedEventHandler;
				TakeOffTimeChangedEventHandler value2 = (TakeOffTimeChangedEventHandler)Delegate.Remove(takeOffTimeChangedEventHandler2, value);
				takeOffTimeChangedEventHandler = Interlocked.CompareExchange(ref m_ConsumerConsumer, value2, takeOffTimeChangedEventHandler2);
			}
			while ((object)takeOffTimeChangedEventHandler != takeOffTimeChangedEventHandler2);
		}
	}

	public static event TimeOnTargetChangedEventHandler TimeOnTargetChanged
	{
		[CompilerGenerated]
		add
		{
			TimeOnTargetChangedEventHandler timeOnTargetChangedEventHandler = m_FacadeConsumer;
			TimeOnTargetChangedEventHandler timeOnTargetChangedEventHandler2;
			do
			{
				timeOnTargetChangedEventHandler2 = timeOnTargetChangedEventHandler;
				TimeOnTargetChangedEventHandler value2 = (TimeOnTargetChangedEventHandler)Delegate.Combine(timeOnTargetChangedEventHandler2, value);
				timeOnTargetChangedEventHandler = Interlocked.CompareExchange(ref m_FacadeConsumer, value2, timeOnTargetChangedEventHandler2);
			}
			while ((object)timeOnTargetChangedEventHandler != timeOnTargetChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TimeOnTargetChangedEventHandler timeOnTargetChangedEventHandler = m_FacadeConsumer;
			TimeOnTargetChangedEventHandler timeOnTargetChangedEventHandler2;
			do
			{
				timeOnTargetChangedEventHandler2 = timeOnTargetChangedEventHandler;
				TimeOnTargetChangedEventHandler value2 = (TimeOnTargetChangedEventHandler)Delegate.Remove(timeOnTargetChangedEventHandler2, value);
				timeOnTargetChangedEventHandler = Interlocked.CompareExchange(ref m_FacadeConsumer, value2, timeOnTargetChangedEventHandler2);
			}
			while ((object)timeOnTargetChangedEventHandler != timeOnTargetChangedEventHandler2);
		}
	}

	public virtual void ReleaseReferences()
	{
		try
		{
			MasterFlightList.Clear();
			UnitsAssignedToMission.Clear();
			UnitsQueuedToMission.Clear();
			TankerMissions = null;
			SecondaryAirBase = null;
			SecondaryNavalBase = null;
			MissionStartTrigger_MissionCompleted.Clear();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	public string GetTargetCountString(Side side_0)
	{
		string text = "";
		if (MissionClass == _MissionClass.Strike)
		{
			text = ((Strike)this).TargetCount.ToString();
		}
		else if (MissionClass == _MissionClass.Escort)
		{
			string escortTargetMissionID = ((EscortMission)this).EscortTargetMissionID;
			IEnumerable<Mission> enumerable = side_0.Missions.Where((Mission m) => Operators.CompareString(m.ObjectID, escortTargetMissionID, TextCompare: false) == 0);
			if (enumerable != null)
			{
				text = ((Strike)(object)enumerable).TargetCount.ToString();
			}
		}
		string text2 = text;
		string text3 = text2;
		switch (text3)
		{
		default:
			if (text3.Length == 0)
			{
				break;
			}
			goto case null;
		case null:
			if (text3 != null)
			{
				return "[" + text + " Targets]";
			}
			break;
		case "1":
			return "[1 Target]";
		case "0":
			return "[No Targets]";
		}
		return "";
	}

	[SpecialName]
	public bool GetAdequateMissionWithNoTargets(Side side_0)
	{
		if (GetTargetCountString(side_0).ToLower().Contains("no target"))
		{
			return true;
		}
		return false;
	}

	public virtual bool IsFulfilled()
	{
		return false;
	}

	internal bool GetValue(Scenario scenario_0, Side side_0)
	{
		if (GetPhase(scenario_0, side_0) == MissionPhase.Active)
		{
			List<TriggerOperationWrapper> list = new List<TriggerOperationWrapper>();
			if (MissionCompletedTrigger_ElapsedTime_Enabled)
			{
				list.Add(new TriggerOperationWrapper(MissionCompletedTrigger_ElapsedTime_Current > MissionCompletedTrigger_ElapsedTime, MissionCompletedTrigger_ElapsedTime_Operator));
				MissionCompletedTrigger_ElapsedTime_LastResult = list[list.Count - 1].Value;
			}
			if (MissionCompletedTrigger_LUA_Enabled && !string.IsNullOrWhiteSpace(MissionCompletedTrigger_LUA))
			{
				object[] array = scenario_0.Scenario_LuaSandbox.RunScript(MissionCompletedTrigger_LUA, bool_0: false);
				if (array != null && array[0] != null)
				{
					if ((object)array[0].GetType() == typeof(LuaScriptException))
					{
						GameGeneral.ResolveBridge("错误：" + ((LuaScriptException)array[0]).InnerException.Message, side_0, "Error in the mission start trigger LUA", GameGeneral.MessageBoxMessageType.ErrorMessage);
					}
					else if ((object)array[0].GetType() == typeof(bool))
					{
						list.Add(new TriggerOperationWrapper(Conversions.ToBoolean(array[0]), bool_1: true));
						MissionCompletedTrigger_LUA_LastResult = list[list.Count - 1].Value;
					}
					else
					{
						GameGeneral.ResolveBridge("ERROR: the script in mission end trigger MUST return a boolean", side_0, "Error in the mission end trigger LUA", GameGeneral.MessageBoxMessageType.ErrorMessage);
					}
				}
			}
			bool result = false;
			foreach (TriggerOperationWrapper item in list)
			{
				if (item.Value)
				{
					if (!item.ConditionalOperator)
					{
						return true;
					}
					result = true;
				}
				else if (item.ConditionalOperator)
				{
					return false;
				}
			}
			return result;
		}
		return false;
	}

	internal bool WriteValue(Scenario scenario_0, Side side_0)
	{
		if (GetPhase(scenario_0, side_0) == MissionPhase.OnHold)
		{
			List<TriggerOperationWrapper> list = new List<TriggerOperationWrapper>();
			if (MissionStartTrigger_Time_Enabled && DateTime.Compare(side_0.Operation.HHourEffectiveStartTime, DateTime.MinValue) != 0)
			{
				list.Add(new TriggerOperationWrapper(DateTime.Compare(scenario_0.Time, side_0.Operation.HHourEffectiveStartTime.AddSeconds(MissionStartTrigger_Time)) > 0, MissionStartTrigger_Time_Operator));
				MissionStartTrigger_Time_LastResult = list[list.Count - 1].Value;
			}
			if (MissionStartTrigger_MissionCompleted_Enabled)
			{
				bool bool_ = true;
				foreach (Mission key in MissionStartTrigger_MissionCompleted.Keys)
				{
					if (key.GetPhase(scenario_0, side_0) != MissionPhase.Completed)
					{
						bool_ = false;
						break;
					}
				}
				list.Add(new TriggerOperationWrapper(bool_, MissionStartTrigger_MissionCompleted_Operator));
				MissionStartTrigger_MissionCompleted_LastResult = list[list.Count - 1].Value;
			}
			if (MissionStartTrigger_LUA_Enabled && !string.IsNullOrWhiteSpace(MissionStartTrigger_LUA))
			{
				object[] array = scenario_0.Scenario_LuaSandbox.RunScript(MissionStartTrigger_LUA, bool_0: false);
				if (array != null && array[0] != null)
				{
					if ((object)array[0].GetType() == typeof(LuaScriptException))
					{
						GameGeneral.ResolveBridge("错误：" + ((LuaScriptException)array[0]).InnerException.Message, side_0, "Error in the mission start trigger LUA", GameGeneral.MessageBoxMessageType.ErrorMessage);
					}
					else if ((object)array[0].GetType() == typeof(bool))
					{
						list.Add(new TriggerOperationWrapper(Conversions.ToBoolean(array[0]), MissionStartTrigger_LUA_Operator));
						MissionStartTrigger_LUA_LastResult = list[list.Count - 1].Value;
					}
					else
					{
						GameGeneral.ResolveBridge("ERROR: the script in mission start trigger MUST return a boolean", side_0, "Error in the mission start trigger LUA", GameGeneral.MessageBoxMessageType.ErrorMessage);
					}
				}
			}
			bool result = false;
			foreach (TriggerOperationWrapper item in list)
			{
				if (item.Value)
				{
					if (!item.ConditionalOperator)
					{
						return true;
					}
					result = true;
				}
				else if (item.ConditionalOperator)
				{
					return false;
				}
			}
			return result;
		}
		return false;
	}

	public virtual void PrePulseHousekeeping(Scenario scenario_0)
	{
	}

	public virtual void PostPulseHousekeeping(Scenario scenario_0)
	{
	}

	public virtual void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, ref Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Mission");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Name", Name);
			xmlWriter_0.WriteElementString("Category", ((byte)Category).ToString());
			Doctrine.ToXML(ref xmlWriter_0, ref scenario_0);
			if (_StartTime.HasValue)
			{
				xmlWriter_0.WriteElementString("START", _StartTime.Value.ToBinary().ToString());
			}
			if (_EndTime.HasValue)
			{
				xmlWriter_0.WriteElementString("END", _EndTime.Value.ToBinary().ToString());
			}
			if (_StartTime.HasValue)
			{
				xmlWriter_0.WriteElementString("TakeOffTime", _TakeOffTime.Value.ToBinary().ToString());
			}
			if (_EndTime.HasValue)
			{
				xmlWriter_0.WriteElementString("TimeOnTarget", _TimeOnTarget.Value.ToBinary().ToString());
			}
			xmlWriter_0.WriteElementString("Deactivation_UnassignUnits", Deactivation_UnassignUnits.ToString());
			xmlWriter_0.WriteElementString("CheckBox_OrderRTB", Deactivation_OrderRTB.ToString());
			xmlWriter_0.WriteElementString("CheckBox_DeleteMission", Deactivation_DeleteMission.ToString());
			if (SecondaryAirBase != null)
			{
				xmlWriter_0.WriteElementString("HomeAirbase", SecondaryAirBase.ObjectID.ToString());
			}
			if (SecondaryNavalBase != null)
			{
				xmlWriter_0.WriteElementString("HomeNavalbase", SecondaryNavalBase.ObjectID.ToString());
			}
			xmlWriter_0.WriteElementString("SISIH", ScrubIfSideIsHuman.ToString());
			xmlWriter_0.WriteElementString("UseFlightplan", UseFlightplans.ToString());
			xmlWriter_0.WriteElementString("UseFlightplansOnly", UsePreGeneratedFlightplansOnly.ToString());
			xmlWriter_0.WriteElementString("IncludeInATO", IncludeInATO.ToString());
			xmlWriter_0.WriteElementString("FlightPlanPreventShotgunRTB", FlightPlanPreventShotgunRTB.ToString());
			if (SecondaryAirBase != null)
			{
				xmlWriter_0.WriteElementString("HomeAirbase", SecondaryAirBase.ObjectID.ToString());
			}
			if (SecondaryNavalBase != null)
			{
				xmlWriter_0.WriteElementString("HomeNavalbase", SecondaryNavalBase.ObjectID.ToString());
			}
			byte wrapperConsumer;
			if (_WrapperConsumer != 0)
			{
				XmlWriter obj = xmlWriter_0;
				wrapperConsumer = (byte)_WrapperConsumer;
				obj.WriteElementString("Status", wrapperConsumer.ToString());
			}
			XmlWriter obj2 = xmlWriter_0;
			wrapperConsumer = (byte)TankerUsage;
			obj2.WriteElementString("TankerUsage", wrapperConsumer.ToString());
			xmlWriter_0.WriteStartElement("TankerMissionList");
			foreach (Mission tankerMission in TankerMissions)
			{
				if (!Information.IsNothing(tankerMission))
				{
					xmlWriter_0.WriteElementString("ID", tankerMission.ObjectID);
				}
			}
			xmlWriter_0.WriteEndElement();
			if (LaunchMissionWithoutTankersInPlace)
			{
				xmlWriter_0.WriteElementString("LaunchMissionWithoutTankersInPlace", LaunchMissionWithoutTankersInPlace.ToString());
			}
			xmlWriter_0.WriteElementString("TankerMinNumber_Total", TankerMinNumber_Total.ToString());
			xmlWriter_0.WriteElementString("TankerMinNumber_Airborne", TankerMinNumber_Airborne.ToString());
			xmlWriter_0.WriteElementString("TankerMinNumber_Station", TankerMinNumber_Station.ToString());
			xmlWriter_0.WriteElementString("MaxReceiversInQueuePerTanker_Airborne", MaxReceiversInQueuePerTanker_Airborne.ToString());
			xmlWriter_0.WriteElementString("FuelQtyToStartLookingForTanker_Airborne", FuelQtyToStartLookingForTanker_Airborne.ToString());
			xmlWriter_0.WriteElementString("TankerMaxDistance_Airborne", TankerMaxDistance_Airborne.ToString());
			xmlWriter_0.WriteElementString("TankerFollowsReceivers", TankerFollowsReceivers.ToString());
			xmlWriter_0.WriteElementString("FlightSize", ((int)FlightSize).ToString());
			xmlWriter_0.WriteElementString("GroupSize", ((int)GroupSize).ToString());
			if (RestartValue())
			{
				Flight.ToXML(ref xmlWriter_0, ref hashSet_0, ref scenario_0, ref FlightList);
			}
			if (!Information.IsNothing(EmptySlotsList) && EmptySlotsList.Count > 0)
			{
				EmptyAircraftSlot.ToXML(ref xmlWriter_0, ref hashSet_0, ref scenario_0, ref EmptySlotsList);
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 100639", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void method_0(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, ref Scenario scenario_0)
	{
		xmlWriter_0.WriteElementString("PriorityWeight", PriorityWeight.ToString());
		xmlWriter_0.WriteElementString("Completion", Completion.ToString());
		xmlWriter_0.WriteElementString("_Phase", ((byte)_Phase).ToString());
		xmlWriter_0.WriteStartElement("AssignedUnitsList");
		foreach (ActiveUnit key in UnitsAssignedToMission.Keys)
		{
			if (!Information.IsNothing(key))
			{
				xmlWriter_0.WriteElementString("ID", key.ObjectID);
			}
		}
		xmlWriter_0.WriteEndElement();
		xmlWriter_0.WriteElementString("OperationName", OperationName);
		xmlWriter_0.WriteElementString("MissionStartTrigger_Time", MissionStartTrigger_Time.ToString());
		xmlWriter_0.WriteElementString("MissionStartTrigger_Time_Enabled", MissionStartTrigger_Time_Enabled.ToString());
		xmlWriter_0.WriteElementString("MissionStartTrigger_Time_Operator", MissionStartTrigger_Time_Operator.ToString());
		xmlWriter_0.WriteStartElement("MissionStartTrigger_MissionCompleted");
		foreach (Mission key2 in MissionStartTrigger_MissionCompleted.Keys)
		{
			if (!Information.IsNothing(key2))
			{
				xmlWriter_0.WriteElementString("ID", key2.ObjectID);
			}
		}
		xmlWriter_0.WriteEndElement();
		xmlWriter_0.WriteElementString("MissionStartTrigger_MissionCompleted_Enabled", MissionStartTrigger_MissionCompleted_Enabled.ToString());
		xmlWriter_0.WriteElementString("MissionStartTrigger_MissionCompleted_Operator", MissionStartTrigger_MissionCompleted_Operator.ToString());
		xmlWriter_0.WriteElementString("MissionStartTrigger_LUA", MissionStartTrigger_LUA);
		xmlWriter_0.WriteElementString("MissionStartTrigger_LUADescription", MissionStartTrigger_LUADescription);
		xmlWriter_0.WriteElementString("MissionStartTrigger_LUA_Enabled", MissionStartTrigger_LUA_Enabled.ToString());
		xmlWriter_0.WriteElementString("MissionStartTrigger_LUA_Operator", MissionStartTrigger_LUA_Operator.ToString());
		xmlWriter_0.WriteElementString("MissionCompletedTrigger_ElapsedTime", MissionCompletedTrigger_ElapsedTime.ToString());
		xmlWriter_0.WriteElementString("MissionCompletedTrigger_ElapsedTime_Current", MissionCompletedTrigger_ElapsedTime_Current.ToString());
		xmlWriter_0.WriteElementString("MissionCompletedTrigger_ElapsedTime_Enabled", MissionCompletedTrigger_ElapsedTime_Enabled.ToString());
		xmlWriter_0.WriteElementString("MissionCompletedTrigger_ElapsedTime_Operator", MissionCompletedTrigger_ElapsedTime_Operator.ToString());
		xmlWriter_0.WriteElementString("MissionCompletedTrigger_LUA", MissionCompletedTrigger_LUA);
		xmlWriter_0.WriteElementString("MissionCompletedTrigger_LUADescription", MissionCompletedTrigger_LUADescription);
		xmlWriter_0.WriteElementString("MissionCompletedTrigger_LUA_Enabled", MissionCompletedTrigger_LUA_Enabled.ToString());
		xmlWriter_0.WriteElementString("MissionCompletedTrigger_LUA_Operator", MissionCompletedTrigger_LUA_Operator.ToString());
		xmlWriter_0.WriteElementString("EstimatedExecutionTime", EstimatedExecutionTime.ToString());
		XmlWriter obj = xmlWriter_0;
		int creationMode = (int)CreationMode;
		obj.WriteElementString("CreationMode", creationMode.ToString());
	}

	public static void FromXMLCommon(Mission mission_0, XmlNode xmlNode_0)
	{
		switch (xmlNode_0.Name)
		{
		case "MissionCompletedTrigger_LUA":
			mission_0.MissionCompletedTrigger_LUA = xmlNode_0.InnerText;
			break;
		case "MissionStartTrigger_LUA":
			mission_0.MissionStartTrigger_LUA = xmlNode_0.InnerText;
			break;
		case "MissionCompletedTrigger_ElapsedTime_Current":
			mission_0.MissionCompletedTrigger_ElapsedTime_Current = Conversions.ToInteger(xmlNode_0.InnerText);
			break;
		case "MissionStartTrigger_MissionCompleted_Operator":
			mission_0.MissionStartTrigger_MissionCompleted_Operator = Conversions.ToBoolean(xmlNode_0.InnerText);
			break;
		case "MissionStartTrigger_Time":
			mission_0.MissionStartTrigger_Time = Conversions.ToInteger(xmlNode_0.InnerText);
			break;
		case "MissionCompletedTrigger_ElapsedTime_Enabled":
			mission_0.MissionCompletedTrigger_ElapsedTime_Enabled = Conversions.ToBoolean(xmlNode_0.InnerText);
			break;
		case "EstimatedExecutionTime":
			mission_0.EstimatedExecutionTime = Conversions.ToInteger(xmlNode_0.InnerText);
			break;
		case "Deactivation_UnassignUnits":
			mission_0.Deactivation_UnassignUnits = Conversions.ToBoolean(xmlNode_0.InnerText);
			break;
		case "CheckBox_OrderRTB":
			mission_0.Deactivation_OrderRTB = Conversions.ToBoolean(xmlNode_0.InnerText);
			break;
		case "MissionStartTrigger_LUA_Enabled":
			mission_0.MissionStartTrigger_LUA_Enabled = Conversions.ToBoolean(xmlNode_0.InnerText);
			break;
		case "MissionCompletedTrigger_LUA_Operator":
			mission_0.MissionCompletedTrigger_LUA_Operator = Conversions.ToBoolean(xmlNode_0.InnerText);
			break;
		case "MissionCompletedTrigger_LUA_Enabled":
			mission_0.MissionCompletedTrigger_LUA_Enabled = Conversions.ToBoolean(xmlNode_0.InnerText);
			break;
		case "MissionStartTrigger_LUA_Operator":
			mission_0.MissionStartTrigger_LUA_Operator = Conversions.ToBoolean(xmlNode_0.InnerText);
			break;
		case "MissionCompletedTrigger_ElapsedTime_Operator":
			mission_0.MissionCompletedTrigger_ElapsedTime_Operator = Conversions.ToBoolean(xmlNode_0.InnerText);
			break;
		case "_Phase":
			mission_0._Phase = (MissionPhase)Conversions.ToInteger(xmlNode_0.InnerText);
			break;
		case "PriorityWeight":
			mission_0.PriorityWeight = Conversions.ToInteger(xmlNode_0.InnerText);
			break;
		case "OperationName":
			mission_0.OperationName = xmlNode_0.InnerText;
			break;
		case "CreationMode":
			mission_0.CreationMode = (MissionCreationType)Conversions.ToInteger(xmlNode_0.InnerText);
			break;
		case "CheckBox_DeleteMission":
			mission_0.Deactivation_DeleteMission = Conversions.ToBoolean(xmlNode_0.InnerText);
			break;
		case "AssignedUnitsList":
		{
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
					mission_0.UnitsAssignedToMissionIDs.Add(xmlNode2.InnerText);
				}
				break;
			}
			finally
			{
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
		}
		case "MissionStartTrigger_LUADescription":
			mission_0.MissionStartTrigger_LUADescription = xmlNode_0.InnerText;
			break;
		case "MissionCompletedTrigger_LUADescription":
			mission_0.MissionCompletedTrigger_LUADescription = xmlNode_0.InnerText;
			break;
		case "MissionCompletedTrigger_ElapsedTime":
			mission_0.MissionCompletedTrigger_ElapsedTime = Conversions.ToInteger(xmlNode_0.InnerText);
			break;
		case "MissionStartTrigger_Time_Operator":
			mission_0.MissionStartTrigger_Time_Operator = Conversions.ToBoolean(xmlNode_0.InnerText);
			break;
		case "MissionStartTrigger_Time_Enabled":
			mission_0.MissionStartTrigger_Time_Enabled = Conversions.ToBoolean(xmlNode_0.InnerText);
			break;
		case "MissionStartTrigger_MissionCompleted_Enabled":
			mission_0.MissionStartTrigger_MissionCompleted_Enabled = Conversions.ToBoolean(xmlNode_0.InnerText);
			break;
		case "Completion":
			mission_0.Completion = Conversions.ToSingle(xmlNode_0.InnerText);
			break;
		case "MissionStartTrigger_MissionCompleted":
		{
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					mission_0._MissionStartTrigger_MissionCompletedID.Add(xmlNode.InnerText);
				}
				break;
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
		}
		}
	}

	public static Mission FromXML(string string_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		return (Mission)concurrentDictionary_0[string_0];
	}

	public static Mission FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		try
		{
			string name = xmlNode_0.Name;
			if (1 == 0)
			{
			}
			Mission result2 = name switch
			{
				"CargoMission" => CargoMission.FromXML(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0), 
				"TaskPool" => TaskPool.FromXML(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0), 
				"FerryMission" => FerryMission.FromXML(ref xmlNode_0, ref concurrentDictionary_0, scenario_0), 
				"Strike" => Strike.FromXML(ref xmlNode_0, ref concurrentDictionary_0, scenario_0), 
				"MiningMission" => MiningMission.FromXML(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0), 
				"Patrol" => Patrol.FromXML(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0), 
				"SupportMission" => SupportMission.FromXML(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0), 
				"MineClearingMission" => MineClearingMission.FromXML(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0), 
				_ => new Patrol(null, scenario_0, "ERROR", MissionCategory.Mission, null, GlobalVariables.PatrolType.AAW, bool_0: false), 
			};
			if (1 == 0)
			{
			}
			return result2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 100640", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Patrol result = new Patrol(null, scenario_0, "ERROR", MissionCategory.Mission, null, GlobalVariables.PatrolType.AAW, bool_0: false);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public float GetAverageDistanceToMissionArea(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1)
	{
		float result = float.MaxValue;
		switch (MissionClass)
		{
		case _MissionClass.Strike:
		{
			Strike strike = (Strike)this;
			if (strike.TargetCount <= 0)
			{
				if (!strike.RTB_When_Target_Destroyed && activeUnit_0.AI.PrimaryTarget != null)
				{
					result = Module_Unit.RangeToUnit_Horiz(activeUnit_0.AI.PrimaryTarget, activeUnit_1);
				}
			}
			else
			{
				result = Module_Unit.RangeToUnit_Horiz(strike.SpecificTargets.First(), activeUnit_1);
			}
			break;
		}
		case _MissionClass.Patrol:
			result = ((Patrol)this).PatrolArea.Select((ReferencePoint s) => s.RangeToPoint_Horiz(activeUnit_1.GetLongitude(), activeUnit_1.GetLatitude())).Average();
			break;
		case _MissionClass.Support:
			result = ((SupportMission)this).NavigationCourse.Select((ReferencePoint s) => s.RangeToPoint_Horiz(activeUnit_1.GetLongitude(), activeUnit_1.GetLatitude())).Average();
			break;
		case _MissionClass.Ferry:
			result = Module_Unit.RangeToUnit_Horiz(((FerryMission)this).GetNominalDestinationHost(activeUnit_0.ParentScen), activeUnit_1);
			break;
		case _MissionClass.Mining:
			result = ((MiningMission)this).Area.Select((ReferencePoint s) => s.RangeToPoint_Horiz(activeUnit_1.GetLongitude(), activeUnit_1.GetLatitude())).Average();
			break;
		case _MissionClass.MineClearing:
			result = ((MineClearingMission)this).Area.Select((ReferencePoint s) => s.RangeToPoint_Horiz(activeUnit_1.GetLongitude(), activeUnit_1.GetLatitude())).Average();
			break;
		case _MissionClass.Cargo:
		{
			CargoMission cargoMission = (CargoMission)this;
			result = ((cargoMission.DestinationUnit == null) ? cargoMission.Area.Select((ReferencePoint s) => s.RangeToPoint_Horiz(activeUnit_1.GetLongitude(), activeUnit_1.GetLatitude())).Average() : Module_Unit.RangeToUnit_Horiz(cargoMission.DestinationUnit, activeUnit_1));
			break;
		}
		}
		return result;
	}

	internal float? NewValue(ref Aircraft aircraft_0, ref bool bool_0)
	{
		float? result;
		switch (MissionClass)
		{
		default:
			result = null;
			break;
		case _MissionClass.Strike:
			if (aircraft_0.AI.IsEscort)
			{
				Strike strike = (Strike)this;
				bool_0 = strike.Escort_TransitTerrainFollowing;
				return strike.Escort_TransitAltitude;
			}
			if (aircraft_0.Loadout == null)
			{
				bool_0 = false;
				result = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_0, ActiveUnit.Throttle.Cruise, ref bool_0);
			}
			else if (aircraft_0.Loadout.GetMissionProfile(aircraft_0.ParentScen).CruiseAtOptimumAltitude)
			{
				bool_0 = false;
				result = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_0, ActiveUnit.Throttle.Cruise, ref bool_0);
			}
			else
			{
				bool_0 = aircraft_0.Loadout.GetMissionProfile(aircraft_0.ParentScen).CruiseAltitudeEgressTerrainFollowing;
				result = aircraft_0.Loadout.GetMissionProfile(aircraft_0.ParentScen).CruiseAltitudeEgress;
			}
			break;
		case _MissionClass.Patrol:
		{
			Patrol patrol = (Patrol)this;
			bool_0 = patrol.TransitTerrainFollowing_Aircraft;
			return patrol.TransitAltitude_Aircraft;
		}
		case _MissionClass.Support:
		{
			SupportMission supportMission = (SupportMission)this;
			bool_0 = supportMission.TransitTerrainFollowing_Aircraft;
			return supportMission.TransitAltitude_Aircraft;
		}
		case _MissionClass.Ferry:
		{
			FerryMission obj = (FerryMission)this;
			bool_0 = false;
			return obj.FerryAltitude_Aircraft;
		}
		case _MissionClass.Mining:
		{
			MiningMission miningMission = (MiningMission)this;
			bool_0 = miningMission.TransitTerrainFollowing_Aircraft;
			return miningMission.TransitAltitude_Aircraft;
		}
		case _MissionClass.MineClearing:
		{
			MineClearingMission mineClearingMission = (MineClearingMission)this;
			bool_0 = mineClearingMission.TransitTerrainFollowing_Aircraft;
			return mineClearingMission.TransitAltitude_Aircraft;
		}
		case _MissionClass.Escort:
		{
			EscortMission escortMission = (EscortMission)this;
			bool_0 = escortMission.TransitTerrainFollowing_Aircraft;
			return escortMission.TransitAltitude_Aircraft;
		}
		}
		return result;
	}

	internal ActiveUnit.Throttle? PushValue(ref Aircraft aircraft_0)
	{
		ActiveUnit.Throttle? result;
		switch (MissionClass)
		{
		default:
			result = ActiveUnit.Throttle.FullStop;
			break;
		case _MissionClass.Strike:
			if (aircraft_0.AI.IsEscort)
			{
				return ((Strike)this).Escort_TransitThrottle;
			}
			return Information.IsNothing(aircraft_0.Loadout) ? new ActiveUnit.Throttle?(ActiveUnit.Throttle.Cruise) : new ActiveUnit.Throttle?(aircraft_0.Loadout.GetMissionProfile(aircraft_0.ParentScen).CruiseThrottleSettingEgress);
		case _MissionClass.Patrol:
			return ((Patrol)this).TransitThrottle_Aircraft;
		case _MissionClass.Support:
			return ((SupportMission)this).TransitThrottle_Aircraft;
		case _MissionClass.Ferry:
			return ((FerryMission)this).FerryThrottle_Aircraft;
		case _MissionClass.Mining:
			return ((MiningMission)this).TransitThrottle_Aircraft;
		case _MissionClass.MineClearing:
			return ((MineClearingMission)this).TransitThrottle_Aircraft;
		case _MissionClass.Escort:
			return ((EscortMission)this).TransitThrottle;
		case _MissionClass.Cargo:
			result = ((CargoMission)this).TransitThrottle_Aircraft;
			break;
		}
		return result;
	}

	[SpecialName]
	public MissionPhase GetPhase(Scenario scenario_0, Side side_0)
	{
		if (_Phase == MissionPhase.Auto)
		{
			if (Completion == 1f)
			{
				return MissionPhase.Completed;
			}
			if (GetStatus(scenario_0) == MissionStatus.Active)
			{
				return MissionPhase.Active;
			}
			if (GetStatus(scenario_0) == MissionStatus.Inactive)
			{
				return MissionPhase.OnHold;
			}
			return MissionPhase.None;
		}
		return _Phase;
	}

	[SpecialName]
	public void SetPhase(Scenario scenario_0, Side side_0, MissionPhase missionPhase_0)
	{
		if (_Phase == missionPhase_0)
		{
			return;
		}
		_Phase = missionPhase_0;
		side_0.Operation.PhasesValidation = false;
		if (missionPhase_0 != MissionPhase.Active && missionPhase_0 != MissionPhase.Completed)
		{
			return;
		}
		if (side_0.Operation.LHourMission != null && Operators.CompareString(ObjectID, side_0.Operation.LHourMission.ObjectID, TextCompare: false) == 0)
		{
			if (DateTime.Compare(side_0.Operation.LHourEffectiveStartTime, DateTime.MinValue) == 0)
			{
				side_0.Operation.LHourEffectiveStartTime = scenario_0.Time;
			}
		}
		else if (side_0.Operation.HHourMission != null && Operators.CompareString(ObjectID, side_0.Operation.HHourMission.ObjectID, TextCompare: false) == 0 && DateTime.Compare(side_0.Operation.HHourEffectiveStartTime, DateTime.MinValue) == 0)
		{
			side_0.Operation.HHourEffectiveStartTime = scenario_0.Time;
		}
	}

	[SpecialName]
	public MissionStatus GetStatus(Scenario scenario_0)
	{
		return _WrapperConsumer;
	}

	[SpecialName]
	public void SetStatus(Scenario scenario_0, MissionStatus missionStatus_0)
	{
		try
		{
			bool num = missionStatus_0 != _WrapperConsumer;
			_WrapperConsumer = missionStatus_0;
			if (!num)
			{
				return;
			}
			if (missionStatus_0 == MissionStatus.Inactive && StartTime.HasValue)
			{
				DateTime? startTime = StartTime;
				DateTime time = scenario_0.Time;
				if ((startTime.HasValue ? new bool?(DateTime.Compare(startTime.GetValueOrDefault(), time) < 0) : null).GetValueOrDefault())
				{
					if (EndTime.HasValue)
					{
						startTime = EndTime;
						time = scenario_0.Time;
						if ((startTime.HasValue ? new bool?(DateTime.Compare(startTime.GetValueOrDefault(), time) >= 0) : null).GetValueOrDefault())
						{
							EndTime_Set(scenario_0.Time, scenario_0);
						}
					}
					else
					{
						EndTime_Set(scenario_0.Time, scenario_0);
					}
				}
			}
			foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
			{
				if (activeUnits_ == null || activeUnits_.AssignedMissionOrPackage() == null || activeUnits_.AssignedMissionOrPackage() != this || !activeUnits_.IsOperating())
				{
					continue;
				}
				activeUnits_.AI.EvaluateTargets(0f, bool_0: false, bool_1: false);
				activeUnits_.AI.EvaluateThreats();
				activeUnits_.AI.EvaluateUnitStatus(0f, bool_0: false, bool_1: false);
				if (missionStatus_0 == MissionStatus.Inactive)
				{
					if (activeUnits_.UnitType == GlobalVariables.ActiveUnitType.Aircraft)
					{
						activeUnits_.AirOps.AttemptToRTB(bool_0: true, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
					}
					else
					{
						activeUnits_.DockingOps.AttemptToRTB(bool_0: true, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 100641", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	public string GetParentTaskPoolID(Side side_0)
	{
		if (Category == MissionCategory.Package && string.IsNullOrEmpty(_IssuerConsumer))
		{
			foreach (Mission mission in side_0.Missions)
			{
				if (mission.Category == MissionCategory.TaskPool && ((TaskPool)mission).PackageList.Contains(this))
				{
					_IssuerConsumer = mission.ObjectID;
					break;
				}
			}
		}
		return _IssuerConsumer;
	}

	[SpecialName]
	public void SetParentTaskPoolID(Side side_0, string string_0)
	{
		_IssuerConsumer = string_0;
	}

	[SpecialName]
	public bool GetHasEscortsAssigned(Scenario scenario_0)
	{
		foreach (ActiveUnit item in Module_Mission.AssetTokenizer(this, scenario_0))
		{
			if (item.AI.IsEscort)
			{
				return true;
			}
		}
		return false;
	}

	[SpecialName]
	public List<ActiveUnit> GetUnitsAssignedToTaskPool(Scenario scenario_0)
	{
		try
		{
			int count = scenario_0.ActiveUnits_List.Count;
			List<ActiveUnit> list = new List<ActiveUnit>();
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				ActiveUnit activeUnit = scenario_0.ActiveUnits_List[i];
				if (activeUnit != null && activeUnit.AssignedTaskPool == this)
				{
					list.Add(activeUnit);
				}
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 200643", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<ActiveUnit> result = new List<ActiveUnit>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public abstract void Printout(StringBuilder stringBuilder_0);

	public void ResetFlightReadyAicraftCount(Scenario scenario_0, Flight flight_0)
	{
		try
		{
			List<ActiveUnit> list = Module_Mission.AssetTokenizer(this, scenario_0).ToList();
			if (!Information.IsNothing(flight_0))
			{
				int num = list.Count - 1;
				int num2 = 0;
				int num3 = 0;
				for (int i = 0; i <= num; i++)
				{
					ActiveUnit activeUnit = list[i];
					if (activeUnit == null || !activeUnit.IsAircraft || !activeUnit.Navigator.HasFlight || activeUnit.Navigator.GetFlight() != flight_0)
					{
						continue;
					}
					num2++;
					Aircraft aircraft = (Aircraft)activeUnit;
					if (!activeUnit.IsOperating())
					{
						string string_ = null;
						if (aircraft.IsAvailableForOps(ref string_) != 0 || !aircraft.IsParkedAndReady())
						{
							continue;
						}
					}
					num3++;
				}
				flight_0.ReadyAircraftQty = num3;
				return;
			}
			for (int j = FlightList.Count - 1; j >= 0; j += -1)
			{
				Flight flight = FlightList[j];
				if (Information.IsNothing(flight))
				{
					continue;
				}
				int num4 = 0;
				int num5 = 0;
				for (int k = list.Count - 1; k >= 0; k += -1)
				{
					ActiveUnit activeUnit2 = list[k];
					if (activeUnit2 == null)
					{
						list.Remove(activeUnit2);
						continue;
					}
					if (!activeUnit2.IsAircraft)
					{
						list.Remove(activeUnit2);
						continue;
					}
					if (!activeUnit2.Navigator.HasFlight || activeUnit2.Navigator.GetFlight() != flight)
					{
						continue;
					}
					num4++;
					Aircraft aircraft2 = (Aircraft)activeUnit2;
					if (!activeUnit2.IsOperating())
					{
						string string_2 = null;
						if (aircraft2.IsAvailableForOps(ref string_2) != 0 || !aircraft2.IsParkedAndReady())
						{
							goto IL_01f4;
						}
					}
					num5++;
					goto IL_01f4;
					IL_01f4:
					list.Remove(activeUnit2);
				}
				flight.ReadyAircraftQty = num5;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void UnitsAssignedToMission_SeparatedByType(Scenario scenario_0, ref List<int> list_0, ref List<int> list_1, ref List<Aircraft> list_2, ref List<Aircraft> list_3, ref List<Aircraft> list_4, ref List<Aircraft> list_5, ref List<ActiveUnit> list_6, ref int int_0, ref int int_1, ref int int_2, ref int int_3, ref int int_4, ref int int_5, ref List<int> list_7, ref List<ActiveUnit> list_8, ref List<ActiveUnit> list_9, List<ActiveUnit> list_10, ref List<Aircraft> list_11, ref List<Aircraft> list_12, ref List<Aircraft> list_13, ref int int_6, ref int int_7, ref int int_8, ref List<Flight> list_14, ref List<Flight> list_15, ref List<Flight> list_16, bool bool_0, bool bool_1, bool bool_2)
	{
		try
		{
			List<ActiveUnit> list = scenario_0.ActiveUnits_List.ToList();
			int num = list.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				ActiveUnit activeUnit = list[i];
				if (activeUnit == null || activeUnit.IsGroup || activeUnit.AssignedMissionOrPackage() != this)
				{
					continue;
				}
				if (activeUnit.IsAircraft)
				{
					Aircraft aircraft = (Aircraft)activeUnit;
					list_2.Add(aircraft);
					if (aircraft.Navigator.GetFlight() == null || bool_2)
					{
						Aircraft_AirOps airOps = aircraft.AirOps;
						if (!list_1.Contains(aircraft.DBID))
						{
							list_1.Add(aircraft.DBID);
						}
						if (bool_2)
						{
							string string_ = null;
							if (aircraft.IsAvailableForOps(ref string_) != 0)
							{
								continue;
							}
							if (airOps.CurrentHostUnit == null)
							{
								if (airOps.GetAssignedHostUnit() != null && !list_6.Contains(airOps.GetAssignedHostUnit()))
								{
									list_6.Add(airOps.GetAssignedHostUnit());
								}
							}
							else if (!list_6.Contains(airOps.CurrentHostUnit))
							{
								list_6.Add(airOps.CurrentHostUnit);
							}
							if (aircraft.Loadout != null)
							{
								list_3.Add(aircraft);
								if (!list_0.Contains(aircraft.Loadout.DBID))
								{
									list_0.Add(aircraft.Loadout.DBID);
								}
							}
							continue;
						}
						if (airOps.CurrentHostUnit == null)
						{
							if (aircraft.AI.IsEscort)
							{
								if (aircraft.Loadout.IsSupportOrPatrol)
								{
									int_2++;
								}
								else
								{
									int_1++;
								}
							}
							else
							{
								int_0++;
							}
							continue;
						}
						if (!list_6.Contains(airOps.CurrentHostUnit))
						{
							list_6.Add(airOps.CurrentHostUnit);
						}
						string string_2 = null;
						if (aircraft.IsAvailableForOps(ref string_2) == Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable && (aircraft.IsParkedAndReady() || (!bool_0 && aircraft.IsParkedAndReadying())))
						{
							if (aircraft.Loadout == null)
							{
								continue;
							}
							list_3.Add(aircraft);
							if (!list_0.Contains(aircraft.Loadout.DBID))
							{
								list_0.Add(aircraft.Loadout.DBID);
							}
							if (aircraft.AI.IsEscort)
							{
								if (aircraft.Loadout.IsSupportOrPatrol)
								{
									int_5++;
								}
								else
								{
									int_4++;
								}
							}
							else
							{
								int_3++;
							}
						}
						else
						{
							if (!airOps.IsTakingOff)
							{
								continue;
							}
							if (aircraft.AI.IsEscort)
							{
								if (aircraft.Loadout.IsSupportOrPatrol)
								{
									int_2++;
								}
								else
								{
									int_1++;
								}
							}
							else
							{
								int_0++;
							}
						}
						continue;
					}
					list_4.Add(aircraft);
					string string_3 = null;
					if (aircraft.IsAvailableForOps(ref string_3) == Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable && aircraft.IsParkedAndReady() && aircraft.Loadout != null)
					{
						list_5.Add(aircraft);
						list_14.Add(aircraft.Navigator.GetFlight());
					}
					else
					{
						list_15.Add(aircraft.Navigator.GetFlight());
					}
					if (aircraft.AI.IsEscort)
					{
						if (aircraft.Loadout.IsSupportOrPatrol)
						{
							int_2++;
						}
						else
						{
							int_1++;
						}
					}
					else
					{
						int_0++;
					}
				}
				else
				{
					if (!activeUnit.IsShip && !activeUnit.IsSubmarine && (!activeUnit.IsVehicle || !((Vehicle)activeUnit).IsOutOfFuel))
					{
						continue;
					}
					list_8.Add(activeUnit);
					if (!list_7.Contains(activeUnit.DBID))
					{
						list_7.Add(activeUnit.DBID);
					}
					if (activeUnit.DockingOps.CurrentHostUnit != null)
					{
						if (!list_10.Contains(activeUnit.DockingOps.CurrentHostUnit))
						{
							list_10.Add(activeUnit.DockingOps.CurrentHostUnit);
						}
						if (activeUnit.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Docked)
						{
							list_9.Add(activeUnit);
						}
					}
				}
			}
			if (!bool_2 && bool_1 && list_11.Count > 0)
			{
				int num2 = list_11.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					Aircraft aircraft2 = list_11[j];
					list_2.Add(aircraft2);
					if (Information.IsNothing(aircraft2.Navigator.GetFlight()))
					{
						list_3.Add(aircraft2);
						Aircraft_AirOps airOps2 = aircraft2.AirOps;
						if (!list_1.Contains(aircraft2.DBID))
						{
							list_1.Add(aircraft2.DBID);
						}
						if (Information.IsNothing(airOps2.CurrentHostUnit))
						{
							continue;
						}
						if (!list_6.Contains(airOps2.CurrentHostUnit))
						{
							list_6.Add(airOps2.CurrentHostUnit);
						}
						if (Information.IsNothing(aircraft2.Loadout))
						{
							continue;
						}
						list_12.Add(aircraft2);
						if (!list_0.Contains(aircraft2.Loadout.DBID))
						{
							list_0.Add(aircraft2.Loadout.DBID);
						}
						if (aircraft2.AI.IsEscort)
						{
							if (aircraft2.Loadout.IsSupportOrPatrol)
							{
								int_8++;
							}
							else
							{
								int_7++;
							}
						}
						else
						{
							int_6++;
						}
					}
					else
					{
						list_13.Add(aircraft2);
						list_16.Add(aircraft2.Navigator.GetFlight());
					}
				}
			}
			if (bool_2)
			{
				return;
			}
			foreach (Flight item in list_15)
			{
				if (list_14.Contains(item))
				{
					list_14.Remove(item);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 101241", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ReconfigureMissionForPrePlannedFlights(ref Scenario scenario_0, ref Side side_0, bool? nullable_0)
	{
		if (Information.IsNothing(nullable_0))
		{
			foreach (Flight flight in FlightList)
			{
				if (!flight.GetIsActive(flight.GetAUCurrentlyAssigned(this, scenario_0)))
				{
					nullable_0 = true;
					break;
				}
			}
		}
		if (!Information.IsNothing(nullable_0) && nullable_0.GetValueOrDefault() && MissionClass == _MissionClass.Strike)
		{
			Strike strike = (Strike)this;
			if (strike.MinimumNumberOfAircraft != 0)
			{
				strike.MinimumNumberOfAircraft = _FlightQty.NoPreferences;
				scenario_0.AddMessage("任务" + Name + "使用预先计划的编队，因此指定飞行所需的最小编队数是没有意义的。参数重新设置为“无首选项”。", Name + " 重置编队最小数量", LoggedMessage.MessageType.SpecialMessage, 0, null, side_0);
			}
			if (strike.MaxFlightNumber_Strike != 0)
			{
				strike.MaxFlightNumber_Strike = _FlightQty.NoPreferences;
				scenario_0.AddMessage("任务" + Name + "使用预先计划的编队，因此指定允许飞行的最大编队数是没有意义的。参数重新设置为“无首选项”。", Name + " 重置编队最大数量", LoggedMessage.MessageType.SpecialMessage, 0, null, side_0);
			}
			if (strike.MinimumNumberOfAircraft_Escorts_Shooter != 0)
			{
				strike.MinimumNumberOfAircraft_Escorts_Shooter = _FlightQty.NoPreferences;
				scenario_0.AddMessage("任务" + Name + "使用预先计划的编队，因此指定飞行所需的最少护航编队数（射手）是没有意义的。参数重新设置为“无首选项”。", Name + " 重置武装护航编队最小数量", LoggedMessage.MessageType.SpecialMessage, 0, null, side_0);
			}
			if (strike.MaximumNumberOfAircraft_Escorts_Shooter != 0)
			{
				strike.MaximumNumberOfAircraft_Escorts_Shooter = _FlightQty.NoPreferences;
				scenario_0.AddMessage("任务" + Name + "使用预先计划的编队，因此指定允许飞行的最大护航编队数（射手）是没有意义的。参数重新设置为“无首选项”。", Name + " 重置武装护航编队最大数量", LoggedMessage.MessageType.SpecialMessage, 0, null, side_0);
			}
			if (strike.MinimumNumberOfAircraft_Escorts_NonShooter != 0)
			{
				strike.MinimumNumberOfAircraft_Escorts_NonShooter = _FlightQty.NoPreferences;
				scenario_0.AddMessage("任务" + Name + "使用预先计划的编队，因此指定飞行所需的最少护航编队数（非射手）是没有意义的。参数重新设置为“无首选项”。", Name + " 重置非武装护航编队最小数量", LoggedMessage.MessageType.SpecialMessage, 0, null, side_0);
			}
			if (strike.MaximumNumberOfAircraft_Escorts_NonShooter != 0)
			{
				strike.MaximumNumberOfAircraft_Escorts_NonShooter = _FlightQty.NoPreferences;
				scenario_0.AddMessage("任务" + Name + "使用预先计划的编队，因此指定允许飞行的最大护航编队数（非射手）是没有意义的。参数重新设置为“无首选项”。", Name + " 重置武装护航编队最大数量", LoggedMessage.MessageType.SpecialMessage, 0, null, side_0);
			}
		}
	}

	public void ClearAllAircraft_ReplaceWithEmptySlots(ref Scenario scenario_0, ref Side side_0, ref Flight flight_0)
	{
		try
		{
			if (Information.IsNothing(flight_0))
			{
				return;
			}
			foreach (ActiveUnit unit in side_0.Units)
			{
				ActiveUnit activeUnit_ = unit;
				if (activeUnit_.Navigator.HasFlight && Operators.CompareString(activeUnit_.Navigator.GetFlight().ObjectID, flight_0.ObjectID, TextCompare: false) == 0)
				{
					ClearAircraft_ReplaceWithEmptySlot(ref scenario_0, ref flight_0, ref activeUnit_);
				}
			}
			flight_0.SetReferenceUnit(scenario_0, null);
			flight_0.ReferenceUnit_ObjectID = "";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ClearAircraft_ReplaceWithEmptySlot(ref Scenario scenario_0, ref Flight flight_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			if (Information.IsNothing(flight_0))
			{
				return;
			}
			activeUnit_0.Navigator.ClearFlight();
			if (Information.IsNothing(EmptySlotsList))
			{
				EmptySlotsList = new List<EmptyAircraftSlot>();
			}
			if (activeUnit_0.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)activeUnit_0;
				int num = 0;
				string text = null;
				if (!Information.IsNothing(aircraft.Loadout))
				{
					num = aircraft.Loadout.DBID;
					text = aircraft.Loadout.Name;
				}
				string text2 = null;
				string text3 = null;
				if (!Information.IsNothing(aircraft.AirOps.CurrentHostUnit))
				{
					text2 = aircraft.AirOps.CurrentHostUnit.ObjectID;
					text3 = aircraft.AirOps.CurrentHostUnit.Name;
				}
				int dBID = activeUnit_0.DBID;
				string unitClass = activeUnit_0.UnitClass;
				int int_ = num;
				string string_ = text;
				ActiveUnit activeUnit_ = null;
				EmptyAircraftSlot emptyAircraftSlot = new EmptyAircraftSlot(null, dBID, unitClass, int_, string_, ref activeUnit_, text2, text3, activeUnit_0.AI.IsEscort);
				int flightRole = (int)activeUnit_0.FlightRole;
				EmptySlotsList.Add(emptyAircraftSlot);
				emptyAircraftSlot.SetFlight(scenario_0, flight_0, flightRole);
				emptyAircraftSlot.SetCurrentHostUnit(scenario_0, aircraft.AirOps.CurrentHostUnit);
				emptyAircraftSlot.CurrentHostUnit_Name = text3;
				emptyAircraftSlot.CurrentHostUnit_ObjectID = text2;
				ResetFlightReadyAicraftCount(scenario_0, flight_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void FillEmptySlots(Scenario scenario_0, ref Side side_0, ref bool bool_0, Flight flight_0, bool bool_1)
	{
		try
		{
			if (Category == MissionCategory.TaskPool)
			{
				return;
			}
			if (!Information.IsNothing(EmptySlotsList) && EmptySlotsList.Count != 0)
			{
				List<ActiveUnit> list = new List<ActiveUnit>();
				new List<ActiveUnit>();
				new List<ActiveUnit>();
				new List<ActiveUnit>();
				List<ActiveUnit> list2 = Module_Mission.AssetTokenizer(this, scenario_0).ToList();
				list.AddRange(list2.Where((ActiveUnit theAU) => !theAU.Navigator.HasFlight && theAU.IsAircraft && !theAU.IsOperating()).ToList());
				bool flag = true;
				if (MissionClass == _MissionClass.Patrol)
				{
					int count = list2.Count;
					_FlightSize _FlightSize_ = FlightSize;
					int num = ExcludeValue(ref _FlightSize_, ref ((Patrol)this).ContinousCoverage_NumberOfFlightsNeededToAllowQRA);
					FlightSize = _FlightSize_;
					int num2 = num;
					if (count < num2)
					{
						flag = false;
					}
				}
				else if (MissionClass == _MissionClass.Support)
				{
					int count2 = list2.Count;
					_FlightSize _FlightSize_2 = FlightSize;
					int num3 = ExcludeValue(ref _FlightSize_2, ref ((SupportMission)this).ContinousCoverage_NumberOfFlightsNeededToAllowQRA);
					FlightSize = _FlightSize_2;
					int num4 = num3;
					if (count2 < num4)
					{
						flag = false;
					}
				}
				if (!flag)
				{
					foreach (Flight flight3 in FlightList)
					{
						Flight flight_ = flight3;
						if (flight_.Task == _FlightTask.QRA)
						{
							ClearAllAircraft_ReplaceWithEmptySlots(ref scenario_0, ref side_0, ref flight_);
						}
					}
				}
				Mission mission = null;
				if (Category == MissionCategory.Package)
				{
					foreach (Mission mission2 in side_0.Missions)
					{
						if (Operators.CompareString(mission2.ObjectID, GetParentTaskPoolID(side_0), TextCompare: false) == 0)
						{
							mission = mission2;
							break;
						}
					}
					if (Information.IsNothing(mission))
					{
						GameGeneral.ResolveBridge("找不到任务的任务池！", side_0);
						return;
					}
					list.AddRange((from theAU in mission.GetUnitsAssignedToTaskPool(scenario_0)
						where Information.IsNothing(theAU.AssignedMissionOrPackage()) && theAU.IsAircraft && !theAU.IsOperating()
						select theAU).ToList());
				}
				if (list.Count == 0)
				{
					if (bool_0)
					{
						if (Category == MissionCategory.Package)
						{
							GameGeneral.ResolveBridge("在任务包或任务池中找不到任何可用的飞机！", side_0);
						}
						else
						{
							GameGeneral.ResolveBridge("在任务中找不到任何可用的飞机！", side_0);
						}
					}
					else if (TimeSincePlayerNotification == 0)
					{
						if (Category == MissionCategory.Package)
						{
							scenario_0.AddMessage("任务包" + Name + "在任务包或任务池中找不到任何可用的飞机！", Name + " 无法找到飞机", LoggedMessage.MessageType.AirOps, 0, null, side_0);
						}
						else
						{
							scenario_0.AddMessage("任务" + Name + "找不到任何可用的飞机！", Name + " 无法找到飞机", LoggedMessage.MessageType.AirOps, 0, null, side_0);
						}
					}
					ResetFlightReadyAicraftCount(scenario_0, null);
					return;
				}
				List<EmptyAircraftSlot> list3 = new List<EmptyAircraftSlot>();
				list3.AddRange((from theES in EmptySlotsList
					where theES.IsEscort && !Information.IsNothing(theES.GetMissionFlight(scenario_0)) && !Information.IsNothing(theES.GetMissionFlight(scenario_0).FlightPlan) && theES.GetMissionFlight(scenario_0).FlightPlan.Count() == 0
					orderby theES.GetMissionFlight(scenario_0).Callsign descending
					select theES).ToList());
				list3.AddRange((from theES in EmptySlotsList
					where !Information.IsNothing(theES.GetMissionFlight(scenario_0)) && !Information.IsNothing(theES.GetMissionFlight(scenario_0).FlightPlan) && theES.GetMissionFlight(scenario_0).FlightPlan.Count() > 0
					orderby theES.IsEscort descending, theES.GetMissionFlight(scenario_0).FlightPlan[0].Time_Zulu descending, theES.GetMissionFlight(scenario_0).Callsign descending
					select theES).ToList());
				if (bool_0 && EmptySlotsList.Where((EmptyAircraftSlot theES) => !theES.IsEscort && !Information.IsNothing(theES.GetMissionFlight(scenario_0)) && !Information.IsNothing(theES.GetMissionFlight(scenario_0).FlightPlan) && theES.GetMissionFlight(scenario_0).FlightPlan.Count() == 0).Count() > 0)
				{
					GameGeneral.ResolveBridge("至少有一个预先计划好的编队缺少飞行计划。只有带飞行计划的编队才能包含飞机。", side_0);
				}
				if (!Information.IsNothing(list3) && list3.Count != 0)
				{
					if (!Information.IsNothing(list3))
					{
						for (int i = list3.Count - 1; i >= 0; i += -1)
						{
							EmptyAircraftSlot emptyAircraftSlot = list3[i];
							if (Information.IsNothing(emptyAircraftSlot.GetMissionFlight(scenario_0)) || (!Information.IsNothing(flight_0) && Operators.CompareString(flight_0.ObjectID, emptyAircraftSlot.MissionFlight_ObjectID, TextCompare: false) != 0) || emptyAircraftSlot.GetMissionFlight(scenario_0).Type == _FlightType.FlightplanTemplate || (!flag && emptyAircraftSlot.GetMissionFlight(scenario_0).Task == _FlightTask.QRA))
							{
								continue;
							}
							foreach (ActiveUnit item in list)
							{
								if (item.DBID != emptyAircraftSlot.ReferenceUnit_DBID)
								{
									continue;
								}
								Aircraft aircraft = (Aircraft)item;
								if (aircraft.Int32_0 != emptyAircraftSlot.int_0 || Information.IsNothing(aircraft.AirOps.CurrentHostUnit) || !(aircraft.AirOps.ConditionTimer <= 0f) || (aircraft.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Parked && aircraft.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Readying))
								{
									continue;
								}
								aircraft.Navigator.SetFlight(bool_1: true, emptyAircraftSlot.GetMissionFlight(scenario_0));
								aircraft.Navigator.GetFlight().SetReferenceUnit(scenario_0, aircraft);
								aircraft.Navigator.GetFlight().ReferenceUnit_DBID = aircraft.DBID;
								aircraft.Navigator.GetFlight().ReferenceUnit_ObjectID = aircraft.ObjectID;
								aircraft.Navigator.GetFlight().ReferenceUnit_Name = aircraft.UnitClass;
								if (!Information.IsNothing(aircraft.Loadout))
								{
									aircraft.Navigator.GetFlight().int_0 = aircraft.Loadout.DBID;
									aircraft.Navigator.GetFlight().SetLoadoutName(scenario_0, aircraft.Loadout.Name);
								}
								EmptySlotsList.Remove(emptyAircraftSlot);
								list3.Remove(emptyAircraftSlot);
								MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = MissionAssignmentAttemptResult.None;
								aircraft.Set_AssignedMissionOrPackage(this, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
								aircraft.AI.IsEscort = emptyAircraftSlot.IsEscort;
								aircraft.Doctrine.ClearCachedParentDoctrine();
								list.Remove(aircraft);
								break;
							}
							if (list.Count == 0)
							{
								ResetFlightReadyAicraftCount(scenario_0, null);
								return;
							}
						}
					}
					list.Clear();
					list.AddRange((from theAU in Module_Mission.AssetTokenizer(this, scenario_0)
						where !theAU.Navigator.HasFlight && theAU.IsAircraft && !theAU.IsOperating()
						select theAU).ToList());
					if (Category == MissionCategory.Package)
					{
						list.AddRange((from theAU in mission.GetUnitsAssignedToTaskPool(scenario_0)
							where Information.IsNothing(theAU.AssignedMissionOrPackage()) && theAU.IsAircraft && !theAU.IsOperating()
							select theAU).ToList());
					}
					if (list.Count == 0)
					{
						ResetFlightReadyAicraftCount(scenario_0, null);
						return;
					}
					if (list3.Count == 0)
					{
						ResetFlightReadyAicraftCount(scenario_0, null);
						return;
					}
					if (!Information.IsNothing(list3))
					{
						for (int j = list3.Count - 1; j >= 0; j += -1)
						{
							EmptyAircraftSlot emptyAircraftSlot2 = list3[j];
							if (Information.IsNothing(emptyAircraftSlot2.GetMissionFlight(scenario_0)) || (!Information.IsNothing(flight_0) && Operators.CompareString(flight_0.ObjectID, emptyAircraftSlot2.MissionFlight_ObjectID, TextCompare: false) != 0) || emptyAircraftSlot2.GetMissionFlight(scenario_0).Type == _FlightType.FlightplanTemplate || (!flag && emptyAircraftSlot2.GetMissionFlight(scenario_0).Task == _FlightTask.QRA))
							{
								continue;
							}
							foreach (ActiveUnit item2 in list)
							{
								if (item2.DBID != emptyAircraftSlot2.ReferenceUnit_DBID)
								{
									continue;
								}
								Aircraft aircraft2 = (Aircraft)item2;
								if (aircraft2.Int32_0 != emptyAircraftSlot2.int_0 || Information.IsNothing(aircraft2.AirOps.CurrentHostUnit) || Operators.CompareString(aircraft2.AirOps.CurrentHostUnit.ObjectID, emptyAircraftSlot2.CurrentHostUnit_ObjectID, TextCompare: false) != 0 || (aircraft2.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Parked && aircraft2.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Readying) || !(aircraft2.AirOps.ConditionTimer < (float)(aircraft2.Loadout.ReadyTime * 60)))
								{
									continue;
								}
								if (emptyAircraftSlot2.GetMissionFlight(scenario_0).FlightPlan.Count() > 0 && !Information.IsNothing(emptyAircraftSlot2.GetMissionFlight(scenario_0).FlightPlan[0].Time_Zulu))
								{
									DateTime t = scenario_0.Time.AddSeconds(aircraft2.AirOps.ConditionTimer);
									DateTime? time_Zulu = emptyAircraftSlot2.GetMissionFlight(scenario_0).FlightPlan[0].Time_Zulu;
									if ((time_Zulu.HasValue ? new bool?(DateTime.Compare(t, time_Zulu.GetValueOrDefault()) > 0) : null).GetValueOrDefault())
									{
										continue;
									}
								}
								aircraft2.Navigator.SetFlight(bool_1: true, emptyAircraftSlot2.GetMissionFlight(scenario_0));
								aircraft2.Navigator.GetFlight().SetReferenceUnit(scenario_0, aircraft2);
								aircraft2.Navigator.GetFlight().ReferenceUnit_DBID = aircraft2.DBID;
								aircraft2.Navigator.GetFlight().ReferenceUnit_ObjectID = aircraft2.ObjectID;
								aircraft2.Navigator.GetFlight().ReferenceUnit_Name = aircraft2.UnitClass;
								if (!Information.IsNothing(aircraft2.Loadout))
								{
									aircraft2.Navigator.GetFlight().int_0 = aircraft2.Loadout.DBID;
									aircraft2.Navigator.GetFlight().SetLoadoutName(scenario_0, aircraft2.Loadout.Name);
								}
								EmptySlotsList.Remove(emptyAircraftSlot2);
								list3.Remove(emptyAircraftSlot2);
								MissionAssignmentAttemptResult missionAssignmentAttemptResult_2 = MissionAssignmentAttemptResult.None;
								aircraft2.Set_AssignedMissionOrPackage(this, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_2);
								aircraft2.AI.IsEscort = emptyAircraftSlot2.IsEscort;
								aircraft2.Doctrine.ClearCachedParentDoctrine();
								list.Remove(aircraft2);
								break;
							}
							if (list.Count == 0)
							{
								ResetFlightReadyAicraftCount(scenario_0, null);
								return;
							}
						}
					}
					list.Clear();
					list.AddRange((from theAU in Module_Mission.AssetTokenizer(this, scenario_0)
						where !theAU.Navigator.HasFlight && theAU.IsAircraft && !theAU.IsOperating()
						select theAU).ToList());
					if (Category == MissionCategory.Package)
					{
						list.AddRange((from theAU in mission.GetUnitsAssignedToTaskPool(scenario_0)
							where Information.IsNothing(theAU.AssignedMissionOrPackage()) && theAU.IsAircraft && !theAU.IsOperating()
							select theAU).ToList());
					}
					if (list.Count == 0)
					{
						ResetFlightReadyAicraftCount(scenario_0, null);
						return;
					}
					if (list3.Count == 0)
					{
						ResetFlightReadyAicraftCount(scenario_0, null);
						return;
					}
					if (!Information.IsNothing(list3))
					{
						for (int k = list3.Count - 1; k >= 0; k += -1)
						{
							EmptyAircraftSlot emptyAircraftSlot3 = list3[k];
							if (Information.IsNothing(emptyAircraftSlot3.GetMissionFlight(scenario_0)) || (!Information.IsNothing(flight_0) && Operators.CompareString(flight_0.ObjectID, emptyAircraftSlot3.MissionFlight_ObjectID, TextCompare: false) != 0) || emptyAircraftSlot3.GetMissionFlight(scenario_0).Type == _FlightType.FlightplanTemplate || (!flag && emptyAircraftSlot3.GetMissionFlight(scenario_0).Task == _FlightTask.QRA))
							{
								continue;
							}
							foreach (ActiveUnit item3 in list)
							{
								if (item3.DBID != emptyAircraftSlot3.ReferenceUnit_DBID)
								{
									continue;
								}
								Aircraft aircraft_ = (Aircraft)item3;
								if (Information.IsNothing(aircraft_.AirOps.CurrentHostUnit) || Operators.CompareString(aircraft_.AirOps.CurrentHostUnit.ObjectID, emptyAircraftSlot3.CurrentHostUnit_ObjectID, TextCompare: false) != 0 || aircraft_.Loadout.Role == Loadout.LoadoutRole.Unavailable || (aircraft_.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Parked && aircraft_.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Readying) || emptyAircraftSlot3.int_0 == 0)
								{
									continue;
								}
								Loadout loadout = DBFunctions.GetLoadout(ref aircraft_.ParentScen, emptyAircraftSlot3.int_0, bool_0: false, bool_1: false);
								if (!(aircraft_.AirOps.ConditionTimer <= (float)(loadout.ReadyTime * 60)))
								{
									continue;
								}
								if (emptyAircraftSlot3.GetMissionFlight(scenario_0).FlightPlan.Count() > 0 && !Information.IsNothing(emptyAircraftSlot3.GetMissionFlight(scenario_0).FlightPlan[0].Time_Zulu))
								{
									DateTime t2 = scenario_0.Time.AddMinutes(loadout.ReadyTime);
									DateTime? time_Zulu2 = emptyAircraftSlot3.GetMissionFlight(scenario_0).FlightPlan[0].Time_Zulu;
									if ((time_Zulu2.HasValue ? new bool?(DateTime.Compare(t2, time_Zulu2.GetValueOrDefault()) > 0) : null).GetValueOrDefault())
									{
										continue;
									}
								}
								if ((!aircraft_.AirOps.EnoughOrdnanceInMagazines(ref aircraft_, loadout, emptyAircraftSlot3.int_0, emptyAircraftSlot3.Loadout_ExcludeOptionalWeapons) && !aircraft_.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines)) || Operators.CompareString(aircraft_.AirOps.OutfitAC(ref aircraft_, emptyAircraftSlot3.int_0, aircraft_.Int32_0, bool_0: false, emptyAircraftSlot3.Loadout_ExcludeOptionalWeapons, !aircraft_.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines), bool_3: false, bool_4: false), "OK", TextCompare: false) != 0)
								{
									continue;
								}
								aircraft_.Navigator.SetFlight(bool_1: true, emptyAircraftSlot3.GetMissionFlight(scenario_0));
								aircraft_.Navigator.GetFlight().SetReferenceUnit(scenario_0, aircraft_);
								aircraft_.Navigator.GetFlight().ReferenceUnit_DBID = aircraft_.DBID;
								aircraft_.Navigator.GetFlight().ReferenceUnit_ObjectID = aircraft_.ObjectID;
								aircraft_.Navigator.GetFlight().ReferenceUnit_Name = aircraft_.UnitClass;
								if (!Information.IsNothing(aircraft_.Loadout))
								{
									aircraft_.Navigator.GetFlight().int_0 = aircraft_.Loadout.DBID;
									aircraft_.Navigator.GetFlight().SetLoadoutName(scenario_0, aircraft_.Loadout.Name);
								}
								EmptySlotsList.Remove(emptyAircraftSlot3);
								list3.Remove(emptyAircraftSlot3);
								Aircraft aircraft3 = aircraft_;
								MissionAssignmentAttemptResult missionAssignmentAttemptResult_3 = MissionAssignmentAttemptResult.None;
								aircraft3.Set_AssignedMissionOrPackage(this, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_3);
								aircraft_.AI.IsEscort = emptyAircraftSlot3.IsEscort;
								aircraft_.Doctrine.ClearCachedParentDoctrine();
								list.Remove(aircraft_);
								break;
							}
							if (list.Count == 0)
							{
								ResetFlightReadyAicraftCount(scenario_0, null);
								return;
							}
						}
					}
					list.Clear();
					list.AddRange((from theAU in Module_Mission.AssetTokenizer(this, scenario_0)
						where !theAU.Navigator.HasFlight && theAU.IsAircraft && !theAU.IsOperating()
						select theAU).ToList());
					if (Category == MissionCategory.Package)
					{
						list.AddRange((from theAU in mission.GetUnitsAssignedToTaskPool(scenario_0)
							where Information.IsNothing(theAU.AssignedMissionOrPackage()) && theAU.IsAircraft && !theAU.IsOperating()
							select theAU).ToList());
					}
					if (list.Count == 0)
					{
						ResetFlightReadyAicraftCount(scenario_0, null);
						return;
					}
					if (list3.Count == 0)
					{
						ResetFlightReadyAicraftCount(scenario_0, null);
						return;
					}
					if (!Information.IsNothing(list3))
					{
						for (int l = list3.Count - 1; l >= 0; l += -1)
						{
							EmptyAircraftSlot emptyAircraftSlot4 = list3[l];
							if (Information.IsNothing(emptyAircraftSlot4.GetMissionFlight(scenario_0)) || (!Information.IsNothing(flight_0) && Operators.CompareString(flight_0.ObjectID, emptyAircraftSlot4.MissionFlight_ObjectID, TextCompare: false) != 0) || emptyAircraftSlot4.GetMissionFlight(scenario_0).Type == _FlightType.FlightplanTemplate || (!flag && emptyAircraftSlot4.GetMissionFlight(scenario_0).Task == _FlightTask.QRA))
							{
								continue;
							}
							foreach (ActiveUnit item4 in list)
							{
								if (item4.DBID != emptyAircraftSlot4.ReferenceUnit_DBID)
								{
									continue;
								}
								Aircraft aircraft_2 = (Aircraft)item4;
								if (Information.IsNothing(aircraft_2.AirOps.CurrentHostUnit) || Operators.CompareString(aircraft_2.AirOps.CurrentHostUnit.ObjectID, emptyAircraftSlot4.CurrentHostUnit_ObjectID, TextCompare: false) != 0 || aircraft_2.Loadout.Role == Loadout.LoadoutRole.Unavailable || (aircraft_2.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Parked && aircraft_2.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Readying) || emptyAircraftSlot4.int_0 == 0)
								{
									continue;
								}
								Loadout loadout2 = DBFunctions.GetLoadout(ref aircraft_2.ParentScen, emptyAircraftSlot4.int_0, bool_0: false, bool_1: false);
								if (emptyAircraftSlot4.GetMissionFlight(scenario_0).FlightPlan.Count() > 0 && !Information.IsNothing(emptyAircraftSlot4.GetMissionFlight(scenario_0).FlightPlan[0].Time_Zulu))
								{
									if (aircraft_2.AirOps.ConditionTimer <= (float)(loadout2.ReadyTime * 60))
									{
										DateTime t3 = scenario_0.Time.AddMinutes(loadout2.ReadyTime);
										DateTime? time_Zulu3 = emptyAircraftSlot4.GetMissionFlight(scenario_0).FlightPlan[0].Time_Zulu;
										if ((time_Zulu3.HasValue ? new bool?(DateTime.Compare(t3, time_Zulu3.GetValueOrDefault()) > 0) : null).GetValueOrDefault())
										{
											continue;
										}
									}
									else
									{
										DateTime t4 = scenario_0.Time.AddSeconds(aircraft_2.AirOps.ConditionTimer);
										DateTime? time_Zulu4 = emptyAircraftSlot4.GetMissionFlight(scenario_0).FlightPlan[0].Time_Zulu;
										if ((time_Zulu4.HasValue ? new bool?(DateTime.Compare(t4, time_Zulu4.GetValueOrDefault()) > 0) : null).GetValueOrDefault())
										{
											continue;
										}
									}
								}
								if ((!aircraft_2.AirOps.EnoughOrdnanceInMagazines(ref aircraft_2, loadout2, emptyAircraftSlot4.int_0, emptyAircraftSlot4.Loadout_ExcludeOptionalWeapons) && !aircraft_2.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines)) || Operators.CompareString(aircraft_2.AirOps.OutfitAC(ref aircraft_2, emptyAircraftSlot4.int_0, aircraft_2.Int32_0, bool_0: false, emptyAircraftSlot4.Loadout_ExcludeOptionalWeapons, !aircraft_2.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines), bool_3: false, bool_4: false), "OK", TextCompare: false) != 0)
								{
									continue;
								}
								aircraft_2.Navigator.SetFlight(bool_1: true, emptyAircraftSlot4.GetMissionFlight(scenario_0));
								aircraft_2.Navigator.GetFlight().SetReferenceUnit(scenario_0, aircraft_2);
								aircraft_2.Navigator.GetFlight().ReferenceUnit_DBID = aircraft_2.DBID;
								aircraft_2.Navigator.GetFlight().ReferenceUnit_ObjectID = aircraft_2.ObjectID;
								aircraft_2.Navigator.GetFlight().ReferenceUnit_Name = aircraft_2.UnitClass;
								if (!Information.IsNothing(aircraft_2.Loadout))
								{
									aircraft_2.Navigator.GetFlight().int_0 = aircraft_2.Loadout.DBID;
									aircraft_2.Navigator.GetFlight().SetLoadoutName(scenario_0, aircraft_2.Loadout.Name);
								}
								EmptySlotsList.Remove(emptyAircraftSlot4);
								list3.Remove(emptyAircraftSlot4);
								Aircraft aircraft4 = aircraft_2;
								MissionAssignmentAttemptResult missionAssignmentAttemptResult_4 = MissionAssignmentAttemptResult.None;
								aircraft4.Set_AssignedMissionOrPackage(this, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_4);
								aircraft_2.AI.IsEscort = emptyAircraftSlot4.IsEscort;
								aircraft_2.Doctrine.ClearCachedParentDoctrine();
								list.Remove(aircraft_2);
								break;
							}
							if (list.Count == 0)
							{
								ResetFlightReadyAicraftCount(scenario_0, null);
								return;
							}
						}
					}
					if (bool_1)
					{
						list.Clear();
						list.AddRange((from theAU in Module_Mission.AssetTokenizer(this, scenario_0)
							where !theAU.Navigator.HasFlight && theAU.IsAircraft && !theAU.IsOperating()
							select theAU).ToList());
						if (Category == MissionCategory.Package)
						{
							list.AddRange((from theAU in mission.GetUnitsAssignedToTaskPool(scenario_0)
								where Information.IsNothing(theAU.AssignedMissionOrPackage()) && theAU.IsAircraft && !theAU.IsOperating()
								select theAU).ToList());
						}
						if (list.Count == 0)
						{
							ResetFlightReadyAicraftCount(scenario_0, null);
							return;
						}
						if (list3.Count == 0)
						{
							ResetFlightReadyAicraftCount(scenario_0, null);
							return;
						}
						if (!Information.IsNothing(list3))
						{
							for (int m = list3.Count - 1; m >= 0; m += -1)
							{
								EmptyAircraftSlot emptyAircraftSlot5 = list3[m];
								if (Information.IsNothing(emptyAircraftSlot5.GetMissionFlight(scenario_0)) || (!Information.IsNothing(flight_0) && Operators.CompareString(flight_0.ObjectID, emptyAircraftSlot5.MissionFlight_ObjectID, TextCompare: false) != 0) || emptyAircraftSlot5.GetMissionFlight(scenario_0).Type == _FlightType.FlightplanTemplate || (!flag && emptyAircraftSlot5.GetMissionFlight(scenario_0).Task == _FlightTask.QRA) || (emptyAircraftSlot5.ReferenceUnit_DBID > 0 && emptyAircraftSlot5.int_0 > 0))
								{
									continue;
								}
								foreach (ActiveUnit item5 in list)
								{
									if (emptyAircraftSlot5.ReferenceUnit_DBID > 0 && item5.DBID != emptyAircraftSlot5.ReferenceUnit_DBID)
									{
										continue;
									}
									Aircraft aircraft5 = (Aircraft)item5;
									if (Information.IsNothing(aircraft5.AirOps.CurrentHostUnit) || Operators.CompareString(aircraft5.AirOps.CurrentHostUnit.ObjectID, emptyAircraftSlot5.CurrentHostUnit_ObjectID, TextCompare: false) != 0 || aircraft5.Loadout.Role == Loadout.LoadoutRole.Unavailable || aircraft5.Loadout.Role == Loadout.LoadoutRole.Reserve || (aircraft5.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Parked && aircraft5.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Readying))
									{
										continue;
									}
									if (emptyAircraftSlot5.GetMissionFlight(scenario_0).FlightPlan.Count() > 0 && !Information.IsNothing(emptyAircraftSlot5.GetMissionFlight(scenario_0).FlightPlan[0].Time_Zulu) && aircraft5.AirOps.ConditionTimer > 0f)
									{
										DateTime t5 = scenario_0.Time.AddSeconds(aircraft5.AirOps.ConditionTimer);
										DateTime? time_Zulu5 = emptyAircraftSlot5.GetMissionFlight(scenario_0).FlightPlan[0].Time_Zulu;
										if ((time_Zulu5.HasValue ? new bool?(DateTime.Compare(t5, time_Zulu5.GetValueOrDefault()) > 0) : null).GetValueOrDefault())
										{
											continue;
										}
									}
									aircraft5.Navigator.SetFlight(bool_1: true, emptyAircraftSlot5.GetMissionFlight(scenario_0));
									aircraft5.Navigator.GetFlight().SetReferenceUnit(scenario_0, aircraft5);
									aircraft5.Navigator.GetFlight().ReferenceUnit_DBID = aircraft5.DBID;
									aircraft5.Navigator.GetFlight().ReferenceUnit_ObjectID = aircraft5.ObjectID;
									aircraft5.Navigator.GetFlight().ReferenceUnit_Name = aircraft5.UnitClass;
									if (!Information.IsNothing(aircraft5.Loadout))
									{
										aircraft5.Navigator.GetFlight().int_0 = aircraft5.Loadout.DBID;
										aircraft5.Navigator.GetFlight().SetLoadoutName(scenario_0, aircraft5.Loadout.Name);
									}
									aircraft5.AI.IsEscort = emptyAircraftSlot5.IsEscort;
									EmptySlotsList.Remove(emptyAircraftSlot5);
									list3.Remove(emptyAircraftSlot5);
									MissionAssignmentAttemptResult missionAssignmentAttemptResult_5 = MissionAssignmentAttemptResult.None;
									aircraft5.Set_AssignedMissionOrPackage(this, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_5);
									aircraft5.Doctrine.ClearCachedParentDoctrine();
									list.Remove(aircraft5);
									if (!Information.IsNothing(EmptySlotsList))
									{
										for (int n = EmptySlotsList.Count - 1; n >= 0; n += -1)
										{
											EmptyAircraftSlot emptyAircraftSlot6 = EmptySlotsList[n];
											if (Operators.CompareString(emptyAircraftSlot6.MissionFlight_ObjectID, aircraft5.Navigator.GetFlight().ObjectID, TextCompare: false) == 0)
											{
												emptyAircraftSlot6.SetReferenceUnit(scenario_0, null, aircraft5);
												emptyAircraftSlot6.ReferenceUnit_DBID = aircraft5.DBID;
												emptyAircraftSlot6.ReferenceUnit_UnitClass = aircraft5.UnitClass;
												if (!Information.IsNothing(aircraft5.Loadout))
												{
													emptyAircraftSlot6.int_0 = aircraft5.Loadout.DBID;
													emptyAircraftSlot6.LoadoutName = aircraft5.Loadout.Name;
												}
											}
										}
									}
									FillEmptySlots(scenario_0, ref side_0, ref bool_0, aircraft5.Navigator.GetFlight(), bool_1: false);
									ActiveUnit referenceUnit = aircraft5.Navigator.GetFlight().GetReferenceUnit(scenario_0);
									Flight flight = aircraft5.Navigator.GetFlight();
									Flight flight2 = aircraft5.Navigator.GetFlight();
									Waypoint[] waypoint_ = flight2.FlightPlan;
									float float_ = 0f;
									float float_2 = 0f;
									MissionPlanner.ConnectTokenizer(scenario_0, this, referenceUnit, flight, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
									flight2.FlightPlan = waypoint_;
									list.Clear();
									list.AddRange((from theAU2 in Module_Mission.AssetTokenizer(this, scenario_0)
										where !theAU2.Navigator.HasFlight && theAU2.IsAircraft && !theAU2.IsOperating()
										select theAU2).ToList());
									if (Category == MissionCategory.Package)
									{
										list.AddRange((from theAU2 in mission.GetUnitsAssignedToTaskPool(scenario_0)
											where Information.IsNothing(theAU2.AssignedMissionOrPackage()) && theAU2.IsAircraft && !theAU2.IsOperating()
											select theAU2).ToList());
									}
									break;
								}
								if (list.Count == 0)
								{
									ResetFlightReadyAicraftCount(scenario_0, null);
									return;
								}
							}
						}
					}
					ResetFlightReadyAicraftCount(scenario_0, null);
				}
				else
				{
					ResetFlightReadyAicraftCount(scenario_0, null);
				}
			}
			else
			{
				ResetFlightReadyAicraftCount(scenario_0, null);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 200644", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal Dictionary<string, Dictionary<string, Dictionary<string, int>>> InvokeValue(ref Scenario scenario_0, bool bool_0, bool bool_1)
	{
		try
		{
			Dictionary<string, Dictionary<string, Dictionary<string, int>>> dictionary = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
			Dictionary<string, Dictionary<string, string>> dictionary2 = new Dictionary<string, Dictionary<string, string>>();
			int num = scenario_0.ActiveUnits_List.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				ActiveUnit activeUnit = scenario_0.ActiveUnits_List[i];
				if (activeUnit == null || activeUnit.IsGroup || activeUnit.AssignedMissionOrPackage() != this || !activeUnit.IsAircraft || (bool_0 && !activeUnit.AI.IsEscort) || (bool_1 && !activeUnit.AI.IsEscort) || (!(bool_0 || bool_1) && activeUnit.AI.IsEscort) || (!(!bool_0 || bool_1) && MissionClass == _MissionClass.Strike && !(((Strike)this).Escort_FlightSize_NonShooter == 0)))
				{
					continue;
				}
				Aircraft aircraft = (Aircraft)activeUnit;
				Aircraft_AirOps airOps = aircraft.AirOps;
				if (aircraft.Loadout == null)
				{
					continue;
				}
				if (airOps.CurrentHostUnit == null)
				{
					if (airOps.GetAssignedHostUnit() == null)
					{
						continue;
					}
					Dictionary<string, string> value = null;
					if (!dictionary2.ContainsKey(airOps.GetAssignedHostUnit().Name))
					{
						dictionary2.Add(airOps.GetAssignedHostUnit().Name, null);
					}
					dictionary2.TryGetValue(airOps.GetAssignedHostUnit().Name, out value);
					if (value == null)
					{
						value = new Dictionary<string, string>();
						value.Add(aircraft.UnitClass, aircraft.Loadout.Name);
						dictionary2[airOps.GetAssignedHostUnit().Name] = value;
						continue;
					}
					value.TryGetValue(aircraft.UnitClass, out var value4);
					if (value4 == null && !value.ContainsKey(aircraft.UnitClass))
					{
						value.Add(aircraft.UnitClass, aircraft.Loadout.Name);
					}
					continue;
				}
				Dictionary<string, int> value5 = null;
				Dictionary<string, Dictionary<string, int>> value6 = null;
				if (!dictionary.ContainsKey(airOps.CurrentHostUnit.Name))
				{
					dictionary.Add(airOps.CurrentHostUnit.Name, null);
				}
				dictionary.TryGetValue(airOps.CurrentHostUnit.Name, out value6);
				if (value6 == null)
				{
					value6 = new Dictionary<string, Dictionary<string, int>>();
					value6.Add(aircraft.UnitClass, null);
					dictionary[airOps.CurrentHostUnit.Name] = value6;
				}
				value6.TryGetValue(aircraft.UnitClass, out value5);
				if (value5 == null)
				{
					value5 = new Dictionary<string, int>();
					value5.Add(aircraft.Loadout.Name, 1);
					value6[aircraft.UnitClass] = value5;
					continue;
				}
				value5.TryGetValue(aircraft.Loadout.Name, out var value7);
				if (value7 == 0)
				{
					value5.Add(aircraft.Loadout.Name, 1);
				}
				else
				{
					value5[aircraft.Loadout.Name]++;
				}
			}
			if (EmptySlotsList != null)
			{
				int num2 = EmptySlotsList.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					EmptyAircraftSlot emptyAircraftSlot = EmptySlotsList[j];
					if ((bool_0 && !emptyAircraftSlot.IsEscort) || (bool_1 && !emptyAircraftSlot.IsEscort) || (!bool_0 && !bool_1 && emptyAircraftSlot.IsEscort) || (bool_0 && !bool_1 && MissionClass == _MissionClass.Strike && ((Strike)this).Escort_FlightSize_NonShooter != 0))
					{
						continue;
					}
					Dictionary<string, int> value8 = null;
					Dictionary<string, Dictionary<string, int>> value9 = null;
					if (!dictionary.ContainsKey(emptyAircraftSlot.CurrentHostUnit_Name))
					{
						dictionary.Add(emptyAircraftSlot.CurrentHostUnit_Name, null);
					}
					dictionary.TryGetValue(emptyAircraftSlot.CurrentHostUnit_Name, out value9);
					if (value9 == null)
					{
						value9 = new Dictionary<string, Dictionary<string, int>>();
						value9.Add(emptyAircraftSlot.ReferenceUnit_UnitClass, null);
						dictionary[emptyAircraftSlot.CurrentHostUnit_Name] = value9;
					}
					value9.TryGetValue(emptyAircraftSlot.ReferenceUnit_UnitClass, out value8);
					if (value8 == null)
					{
						value8 = new Dictionary<string, int>();
						value8.Add(emptyAircraftSlot.LoadoutName, 1);
						value9[emptyAircraftSlot.ReferenceUnit_UnitClass] = value8;
						continue;
					}
					value8.TryGetValue(emptyAircraftSlot.LoadoutName, out var value10);
					if (value10 == 0)
					{
						value8.Add(emptyAircraftSlot.LoadoutName, 1);
					}
					else
					{
						value8[emptyAircraftSlot.LoadoutName]++;
					}
				}
			}
			foreach (KeyValuePair<string, Dictionary<string, string>> item8 in dictionary2)
			{
				foreach (KeyValuePair<string, string> item9 in item8.Value)
				{
					string value11 = item9.Value;
					List<string> list = new List<string>();
					foreach (KeyValuePair<string, Dictionary<string, Dictionary<string, int>>> item3 in dictionary)
					{
						List<string> list2 = new List<string>();
						Dictionary<string, Dictionary<string, int>> value2 = item3.Value;
						foreach (KeyValuePair<string, Dictionary<string, int>> item4 in value2)
						{
							List<string> list3 = new List<string>();
							Dictionary<string, int> value3 = item4.Value;
							foreach (KeyValuePair<string, int> item10 in value3)
							{
								if (Operators.CompareString(item10.Key, value11, TextCompare: false) == 0)
								{
									list3.Add(value11);
								}
							}
							foreach (string item5 in list3)
							{
								value3.Remove(item5);
							}
							if (item4.Value.Count == 0)
							{
								list2.Add(item4.Key);
							}
						}
						foreach (string item6 in list2)
						{
							value2.Remove(item6);
						}
						if (item3.Value.Count == 0)
						{
							list.Add(item3.Key);
						}
					}
					foreach (string item7 in list)
					{
						dictionary.Remove(item7);
					}
				}
			}
			return dictionary;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 101251", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Dictionary<string, Dictionary<string, Dictionary<string, int>>> result = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public void StartTime_Set(DateTime? nullable_0, Scenario scenario_0)
	{
		bool flag = false;
		if (!_StartTime.HasValue && nullable_0.HasValue)
		{
			flag = true;
		}
		else if (!nullable_0.HasValue && _StartTime.HasValue)
		{
			flag = true;
		}
		else
		{
			DateTime? startTime = _StartTime;
			bool? flag2 = ((startTime.HasValue & nullable_0.HasValue) ? new bool?(DateTime.Compare(startTime.GetValueOrDefault(), nullable_0.GetValueOrDefault()) == 0) : null);
			if (((!flag2) ?? flag2).GetValueOrDefault())
			{
				flag = true;
			}
		}
		_StartTime = nullable_0;
		if (flag)
		{
			_ClientConsumer?.Invoke(this);
		}
		SetupValue(scenario_0);
	}

	private void SetupValue(Scenario scenario_0)
	{
		bool? flag;
		if (StartTime.HasValue)
		{
			DateTime? startTime = StartTime;
			DateTime time = scenario_0.Time;
			flag = (startTime.HasValue ? new bool?(DateTime.Compare(startTime.GetValueOrDefault(), time) < 0) : null);
		}
		else
		{
			flag = true;
		}
		bool? flag2 = flag;
		if (flag2.GetValueOrDefault(true))
		{
			if (EndTime.HasValue)
			{
				DateTime? endTime = EndTime;
				DateTime time2 = scenario_0.Time;
				if (!(endTime.HasValue ? new bool?(DateTime.Compare(endTime.GetValueOrDefault(), time2) > 0) : null).GetValueOrDefault())
				{
					goto IL_00f3;
				}
			}
			if (flag2.HasValue)
			{
				SetStatus(scenario_0, MissionStatus.Active);
				return;
			}
		}
		goto IL_00f3;
		IL_00f3:
		SetStatus(scenario_0, MissionStatus.Inactive);
	}

	public void EndTime_Set(DateTime? nullable_0, Scenario scenario_0)
	{
		bool flag = false;
		if (!_EndTime.HasValue && nullable_0.HasValue)
		{
			flag = true;
		}
		else if (!nullable_0.HasValue && _EndTime.HasValue)
		{
			flag = true;
		}
		else
		{
			DateTime? endTime = _EndTime;
			bool? flag2 = ((endTime.HasValue & nullable_0.HasValue) ? new bool?(DateTime.Compare(endTime.GetValueOrDefault(), nullable_0.GetValueOrDefault()) == 0) : null);
			if (((!flag2) ?? flag2).GetValueOrDefault())
			{
				flag = true;
			}
		}
		_EndTime = nullable_0;
		if (flag)
		{
			_DicConsumer?.Invoke(this);
		}
		SetupValue(scenario_0);
	}

	public static int FlightQty_To_ActualFlightQty(ref _FlightQty _FlightQty_0)
	{
		_FlightQty flightQty = _FlightQty_0;
		if (1 == 0)
		{
		}
		int result = flightQty switch
		{
			_FlightQty.None => 0, 
			_FlightQty.All => int.MaxValue, 
			_FlightQty.Flight_x1 => 1, 
			_FlightQty.Flight_x2 => 2, 
			_FlightQty.Flight_x3 => 3, 
			_FlightQty.Flight_x4 => 4, 
			_FlightQty.Flight_x6 => 6, 
			_FlightQty.Flight_x8 => 8, 
			_FlightQty.Flight_x12 => 12, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal int ExcludeValue(ref _FlightSize _FlightSize_0, ref _FlightQty _FlightQty_0)
	{
		_FlightQty flightQty = _FlightQty_0;
		if (1 == 0)
		{
		}
		int result = flightQty switch
		{
			_FlightQty.None => 0, 
			_FlightQty.All => int.MaxValue, 
			_FlightQty.Flight_x1 => _FlightSize_0, 
			_FlightQty.Flight_x2 => (int)_FlightSize_0 * 2, 
			_FlightQty.Flight_x3 => (int)_FlightSize_0 * 3, 
			_FlightQty.Flight_x4 => (int)_FlightSize_0 * 4, 
			_FlightQty.Flight_x6 => (int)_FlightSize_0 * 6, 
			_FlightQty.Flight_x8 => (int)_FlightSize_0 * 8, 
			_FlightQty.Flight_x12 => (int)_FlightSize_0 * 12, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal _FlightQty IncludeValue(ref int int_0)
	{
		try
		{
			int num = int_0;
			if (1 == 0)
			{
			}
			_FlightQty result = num switch
			{
				0 => _FlightQty.All, 
				1 => _FlightQty.None, 
				2 => _FlightQty.Flight_x1, 
				3 => _FlightQty.Flight_x2, 
				4 => _FlightQty.Flight_x3, 
				5 => _FlightQty.Flight_x4, 
				6 => _FlightQty.Flight_x6, 
				7 => _FlightQty.Flight_x8, 
				8 => _FlightQty.Flight_x12, 
				_ => _FlightQty.All, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return _FlightQty.All;
		}
	}

	internal int SearchValue(_FlightQty _FlightQty_0)
	{
		try
		{
			if (1 == 0)
			{
			}
			int result = _FlightQty_0 switch
			{
				_FlightQty.None => 1, 
				_FlightQty.All => 0, 
				_FlightQty.Flight_x1 => 2, 
				_FlightQty.Flight_x2 => 3, 
				_FlightQty.Flight_x3 => 4, 
				_FlightQty.Flight_x4 => 5, 
				_FlightQty.Flight_x6 => 6, 
				_FlightQty.Flight_x8 => 7, 
				_FlightQty.Flight_x12 => 8, 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	internal _FlightQty EnableValue(ref int int_0, bool bool_0)
	{
		try
		{
			_FlightQty result;
			if (!bool_0)
			{
				int num = int_0;
				if (1 == 0)
				{
				}
				result = num switch
				{
					0 => _FlightQty.All, 
					1 => _FlightQty.NoPreferences, 
					2 => _FlightQty.Flight_x1, 
					3 => _FlightQty.Flight_x2, 
					4 => _FlightQty.Flight_x3, 
					5 => _FlightQty.Flight_x4, 
					6 => _FlightQty.Flight_x6, 
					7 => _FlightQty.Flight_x8, 
					8 => _FlightQty.Flight_x12, 
					_ => _FlightQty.NoPreferences, 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			int num2 = int_0;
			if (1 == 0)
			{
			}
			result = num2 switch
			{
				1 => _FlightQty.NoPreferences, 
				0 => _FlightQty.All, 
				_ => _FlightQty.NoPreferences, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 101242", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return _FlightQty.All;
		}
	}

	internal int ChangeValue(int int_0, bool bool_0)
	{
		try
		{
			if (!bool_0)
			{
				if (1 == 0)
				{
				}
				int result = int_0 switch
				{
					-99 => 0, 
					-98 => 1, 
					-97 => 2, 
					-96 => 3, 
					-95 => 4, 
					-94 => 5, 
					-93 => 6, 
					-92 => 7, 
					-91 => 8, 
					_ => 1, 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			if (int_0 != -99)
			{
				return 1;
			}
			return 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 101243", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	internal _FlightQty InitValue(ref int int_0, bool bool_0)
	{
		try
		{
			_FlightQty result;
			if (!bool_0)
			{
				int num = int_0;
				if (1 == 0)
				{
				}
				result = num switch
				{
					0 => _FlightQty.NoPreferences, 
					1 => _FlightQty.Flight_x1, 
					2 => _FlightQty.Flight_x2, 
					3 => _FlightQty.Flight_x3, 
					4 => _FlightQty.Flight_x4, 
					5 => _FlightQty.Flight_x6, 
					6 => _FlightQty.Flight_x8, 
					7 => _FlightQty.Flight_x12, 
					_ => _FlightQty.NoPreferences, 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			int num2 = int_0;
			if (1 == 0)
			{
			}
			result = num2 switch
			{
				0 => _FlightQty.NoPreferences, 
				1 => _FlightQty.Aircraft_x1, 
				2 => _FlightQty.Aircraft_x2, 
				3 => _FlightQty.Aircraft_x3, 
				4 => _FlightQty.Aircraft_x4, 
				5 => _FlightQty.Aircraft_x6, 
				6 => _FlightQty.Aircraft_x8, 
				7 => _FlightQty.Aircraft_x12, 
				_ => _FlightQty.NoPreferences, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 101245", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return _FlightQty.NoPreferences;
		}
	}

	internal int CheckValue(int int_0, bool bool_0)
	{
		try
		{
			int result;
			if (!bool_0)
			{
				if (1 == 0)
				{
				}
				result = int_0 switch
				{
					-97 => 1, 
					-96 => 2, 
					-95 => 3, 
					-94 => 4, 
					-93 => 5, 
					-92 => 6, 
					-91 => 7, 
					_ => 0, 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			if (1 == 0)
			{
			}
			result = int_0 switch
			{
				-87 => 1, 
				-86 => 2, 
				-85 => 3, 
				-84 => 4, 
				-83 => 5, 
				-82 => 6, 
				-81 => 7, 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 101244", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	internal int ConcatValue(_FlightQty _FlightQty_0)
	{
		try
		{
			if (1 == 0)
			{
			}
			int result = _FlightQty_0 switch
			{
				_FlightQty.Flight_x1 => 0, 
				_FlightQty.Flight_x2 => 1, 
				_FlightQty.Flight_x3 => 2, 
				_FlightQty.Flight_x4 => 3, 
				_FlightQty.Flight_x6 => 4, 
				_FlightQty.Flight_x8 => 5, 
				_FlightQty.Flight_x12 => 6, 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	internal _FlightQty InterruptValue(ref int int_0)
	{
		try
		{
			int num = int_0;
			if (1 == 0)
			{
			}
			_FlightQty result = num switch
			{
				0 => _FlightQty.Flight_x1, 
				1 => _FlightQty.Flight_x2, 
				2 => _FlightQty.Flight_x3, 
				3 => _FlightQty.Flight_x4, 
				4 => _FlightQty.Flight_x6, 
				5 => _FlightQty.Flight_x8, 
				6 => _FlightQty.Flight_x12, 
				_ => _FlightQty.All, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return _FlightQty.All;
		}
	}

	internal int RemoveValue(_FlightQty _FlightQty_0)
	{
		try
		{
			if (1 == 0)
			{
			}
			int result = _FlightQty_0 switch
			{
				_FlightQty.Flight_x2 => 0, 
				_FlightQty.Flight_x3 => 1, 
				_FlightQty.Flight_x4 => 2, 
				_FlightQty.Flight_x6 => 3, 
				_FlightQty.Flight_x8 => 4, 
				_FlightQty.Flight_x12 => 5, 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	internal _FlightQty FindValue(ref int int_0)
	{
		try
		{
			int num = int_0;
			if (1 == 0)
			{
			}
			_FlightQty result = num switch
			{
				0 => _FlightQty.Flight_x2, 
				1 => _FlightQty.Flight_x3, 
				2 => _FlightQty.Flight_x4, 
				3 => _FlightQty.Flight_x6, 
				4 => _FlightQty.Flight_x8, 
				5 => _FlightQty.Flight_x12, 
				_ => _FlightQty.NoPreferences, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return _FlightQty.All;
		}
	}

	public void OrderAircraftToTakeOff(ref Scenario scenario_0, List<Group> list_0, List<Aircraft> list_1, List<Aircraft> list_2, List<Aircraft> list_3)
	{
		try
		{
			if (!Information.IsNothing(list_0))
			{
				foreach (Group item in list_0)
				{
					if (item.Units.Values.Count == 1)
					{
						ActiveUnit activeUnit = item.Units.Values.ElementAtOrDefault(0);
						Flight flight = activeUnit.Navigator.GetFlight();
						item.Units.Values.ElementAtOrDefault(0).SetParentGroup(bool_0: true, null);
						item.Destroy(bool_0: false, bool_1: false, bool_2: false, "Group destroyed by mission logic");
						activeUnit.Navigator.SetFlight(bool_1: true, flight);
					}
				}
			}
			if (!Information.IsNothing(list_2))
			{
				Flight flight2 = null;
				foreach (Aircraft item2 in list_2)
				{
					Aircraft_AirOps airOps = item2.AirOps;
					if (airOps.Condition == Aircraft_AirOps._AirOpsCondition.Parked)
					{
						airOps.AttemptToMoveToRunway(bool_0: false);
					}
					if (item2.Navigator.HasFlight)
					{
						item2.Navigator.GetFlight().SetStatus(scenario_0, _FlightStatus.TakingOff);
						flight2 = item2.Navigator.GetFlight();
					}
				}
				if (flight2 != null)
				{
					flight2.Departed = true;
				}
			}
			if (!Information.IsNothing(list_3))
			{
				Flight flight3 = null;
				foreach (Aircraft item3 in list_3)
				{
					Aircraft_AirOps airOps2 = item3.AirOps;
					if (airOps2.Condition == Aircraft_AirOps._AirOpsCondition.Parked)
					{
						airOps2.AttemptToMoveToRunway(bool_0: false);
					}
					if (item3.Navigator.HasFlight)
					{
						item3.Navigator.GetFlight().SetStatus(scenario_0, _FlightStatus.TakingOff);
						flight3 = item3.Navigator.GetFlight();
					}
				}
				if (flight3 != null)
				{
					flight3.Departed = true;
				}
			}
			if (!Information.IsNothing(list_1))
			{
				Flight flight4 = null;
				foreach (Aircraft item4 in list_1)
				{
					Aircraft_AirOps airOps3 = item4.AirOps;
					if (airOps3.Condition == Aircraft_AirOps._AirOpsCondition.Parked && !airOps3.PrepareProxy())
					{
						airOps3.AttemptToMoveToRunway(bool_0: true);
					}
					if (item4.Navigator.HasFlight)
					{
						item4.Navigator.GetFlight().SetStatus(scenario_0, _FlightStatus.TakingOff);
						flight4 = item4.Navigator.GetFlight();
					}
				}
				if (flight4 != null)
				{
					flight4.Departed = true;
				}
				if (list_1.Count > 0 && MissionClass == _MissionClass.Strike)
				{
					((Strike)this).OneTimeOnlyFlown = true;
				}
			}
			list_0.Clear();
			list_1.Clear();
			if (!Information.IsNothing(list_2))
			{
				list_2.Clear();
			}
			if (!Information.IsNothing(list_3))
			{
				list_3.Clear();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	public virtual string GetDescriptionString(Scenario scenario_0)
	{
		return "";
	}

	public Mission(Side side_0, Scenario scenario_0, string string_0)
	{
		List<ActiveUnit> list_ = null;
		Doctrine = new Doctrine(this, ref list_);
		Category = MissionCategory.Mission;
		TimeSincePlayerNotification = 0;
		MasterFlightList = new List<Flight>();
		FlightList = new List<Flight>();
		FlightPlanPreventShotgunRTB = true;
		TankerMissions_IDs = new List<string>();
		TankerMissions = new List<Mission>();
		MaxReceiversInQueuePerTanker_Airborne = 0;
		TankerMaxDistance_Airborne = int.MaxValue;
		TankerFollowsReceivers = true;
		Deactivation_UnassignUnits = false;
		Deactivation_OrderRTB = false;
		Deactivation_DeleteMission = false;
		UnitsQueuedToMission = new Dictionary<ActiveUnit, ActiveUnit>();
		UnitsAssignedToMission = new ConcurrentDictionary<ActiveUnit, ActiveUnit>();
		UnitsAssignedToMissionIDs = new List<string>();
		_Phase = MissionPhase.OnHold;
		CreationMode = MissionCreationType.Unspecified;
		MissionStartTrigger_MissionCompleted = new Dictionary<Mission, Mission>();
		_MissionStartTrigger_MissionCompletedID = new List<string>();
		MarkedForBulkEdition = false;
		IsMission = true;
		Name = string_0;
		side_0?.Missions_Add(this);
		list_ = null;
		Doctrine = new Doctrine(this, ref list_);
		SetDefaultFuelQtyToStartLookingForTanker_Airborne();
	}

	public void SetDefaultFuelQtyToStartLookingForTanker_Airborne()
	{
		if (MissionClass == _MissionClass.Strike)
		{
			FuelQtyToStartLookingForTanker_Airborne = 85;
		}
		else if (MissionClass == _MissionClass.Ferry)
		{
			FuelQtyToStartLookingForTanker_Airborne = 80;
		}
		else if (MissionClass == _MissionClass.Support)
		{
			FuelQtyToStartLookingForTanker_Airborne = 0;
		}
		else
		{
			FuelQtyToStartLookingForTanker_Airborne = 30;
		}
	}

	[SpecialName]
	public static string GetFlightSizeString(_FlightSize _FlightSize_0)
	{
		_FlightSize flightSize = _FlightSize_0;
		if (flightSize == 0)
		{
			return "None";
		}
		if (flightSize == 1)
		{
			return "单机";
		}
		if (flightSize == 2)
		{
			return "2架飞机，通常为战斗机";
		}
		if (flightSize == 3)
		{
			return "3架飞机，通常为轰炸机";
		}
		if (flightSize == 4)
		{
			return "4架飞机，通常为攻击机";
		}
		if (flightSize == 6)
		{
			return "三段（6架飞机），对中型/重型攻击机";
		}
		return _FlightSize_0.value + "x aircraft";
	}

	[SpecialName]
	public static string GetGroupSizeString(_GroupSize _GroupSize_0)
	{
		_GroupSize groupSize = _GroupSize_0;
		if (groupSize == 0)
		{
			return "None";
		}
		if (groupSize == 1)
		{
			return "单船";
		}
		if (groupSize == 2)
		{
			return "2x船只";
		}
		if (groupSize == 3)
		{
			return "3x船只";
		}
		if (groupSize == 4)
		{
			return "4x船只";
		}
		if (groupSize == 6)
		{
			return "6x船只";
		}
		return _GroupSize_0.value + "x vessels";
	}

	internal _ContinousCoverageMethod SetValue(ref int int_0)
	{
		try
		{
			int num = int_0;
			if (1 == 0)
			{
			}
			_ContinousCoverageMethod result = num switch
			{
				1 => _ContinousCoverageMethod.FlightplanTemplates, 
				0 => _ContinousCoverageMethod.Dynamic, 
				_ => _ContinousCoverageMethod.Dynamic, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return _ContinousCoverageMethod.Dynamic;
		}
	}

	internal int FillValue(_ContinousCoverageMethod _ContinousCoverageMethod_0)
	{
		try
		{
			if (1 == 0)
			{
			}
			int result = _ContinousCoverageMethod_0 switch
			{
				_ContinousCoverageMethod.FlightplanTemplates => 1, 
				_ContinousCoverageMethod.Dynamic => 0, 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	internal _ContinousCoverageStationTime CalculateValue(ref int int_0)
	{
		try
		{
			int num = int_0;
			if (1 == 0)
			{
			}
			_ContinousCoverageStationTime result = num switch
			{
				0 => _ContinousCoverageStationTime.min_15, 
				1 => _ContinousCoverageStationTime.min_20, 
				2 => _ContinousCoverageStationTime.min_30, 
				3 => _ContinousCoverageStationTime.min_40, 
				4 => _ContinousCoverageStationTime.min_45, 
				5 => _ContinousCoverageStationTime.min_50, 
				6 => _ContinousCoverageStationTime.hr_1, 
				7 => _ContinousCoverageStationTime.hr_1_min_15, 
				8 => _ContinousCoverageStationTime.hr_1_min_30, 
				9 => _ContinousCoverageStationTime.hr_1_min_45, 
				10 => _ContinousCoverageStationTime.hr_2, 
				11 => _ContinousCoverageStationTime.hr_2_min_15, 
				12 => _ContinousCoverageStationTime.hr_2_min_30, 
				13 => _ContinousCoverageStationTime.hr_2_min_45, 
				14 => _ContinousCoverageStationTime.hr_3, 
				15 => _ContinousCoverageStationTime.hr_3_min_30, 
				16 => _ContinousCoverageStationTime.hr_4, 
				17 => _ContinousCoverageStationTime.hr_5, 
				18 => _ContinousCoverageStationTime.hr_6, 
				19 => _ContinousCoverageStationTime.hr_8, 
				20 => _ContinousCoverageStationTime.hr_10, 
				21 => _ContinousCoverageStationTime.hr_12, 
				_ => _ContinousCoverageStationTime.min_15, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return _ContinousCoverageStationTime.min_15;
		}
	}

	internal int PopValue(_ContinousCoverageStationTime _ContinousCoverageStationTime_0)
	{
		try
		{
			if (1 == 0)
			{
			}
			int result = _ContinousCoverageStationTime_0 switch
			{
				_ContinousCoverageStationTime.min_15 => 0, 
				_ContinousCoverageStationTime.min_20 => 1, 
				_ContinousCoverageStationTime.min_30 => 2, 
				_ContinousCoverageStationTime.min_40 => 3, 
				_ContinousCoverageStationTime.min_45 => 4, 
				_ContinousCoverageStationTime.min_50 => 5, 
				_ContinousCoverageStationTime.hr_1 => 6, 
				_ContinousCoverageStationTime.hr_1_min_15 => 7, 
				_ContinousCoverageStationTime.hr_1_min_30 => 8, 
				_ContinousCoverageStationTime.hr_1_min_45 => 9, 
				_ContinousCoverageStationTime.hr_2 => 10, 
				_ContinousCoverageStationTime.hr_2_min_15 => 11, 
				_ContinousCoverageStationTime.hr_2_min_30 => 12, 
				_ContinousCoverageStationTime.hr_2_min_45 => 13, 
				_ContinousCoverageStationTime.hr_3 => 14, 
				_ContinousCoverageStationTime.hr_3_min_30 => 15, 
				_ContinousCoverageStationTime.hr_4 => 16, 
				_ContinousCoverageStationTime.hr_5 => 17, 
				_ContinousCoverageStationTime.hr_6 => 18, 
				_ContinousCoverageStationTime.hr_8 => 19, 
				_ContinousCoverageStationTime.hr_10 => 20, 
				_ContinousCoverageStationTime.hr_12 => 21, 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	internal int InstantiateValue(_ContinousCoverageStationTime _ContinousCoverageStationTime_0)
	{
		try
		{
			if (1 == 0)
			{
			}
			int result = _ContinousCoverageStationTime_0 switch
			{
				_ContinousCoverageStationTime.min_15 => 15, 
				_ContinousCoverageStationTime.min_20 => 20, 
				_ContinousCoverageStationTime.min_30 => 30, 
				_ContinousCoverageStationTime.min_40 => 40, 
				_ContinousCoverageStationTime.min_45 => 45, 
				_ContinousCoverageStationTime.min_50 => 50, 
				_ContinousCoverageStationTime.hr_1 => 60, 
				_ContinousCoverageStationTime.hr_1_min_15 => 75, 
				_ContinousCoverageStationTime.hr_1_min_30 => 90, 
				_ContinousCoverageStationTime.hr_1_min_45 => 105, 
				_ContinousCoverageStationTime.hr_2 => 120, 
				_ContinousCoverageStationTime.hr_2_min_15 => 135, 
				_ContinousCoverageStationTime.hr_2_min_30 => 150, 
				_ContinousCoverageStationTime.hr_2_min_45 => 165, 
				_ContinousCoverageStationTime.hr_3 => 180, 
				_ContinousCoverageStationTime.hr_3_min_30 => 210, 
				_ContinousCoverageStationTime.hr_4 => 240, 
				_ContinousCoverageStationTime.hr_5 => 300, 
				_ContinousCoverageStationTime.hr_6 => 360, 
				_ContinousCoverageStationTime.hr_8 => 480, 
				_ContinousCoverageStationTime.hr_10 => 600, 
				_ContinousCoverageStationTime.hr_12 => 720, 
				_ => 15, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	internal _ContinousCoverageOverlap CreateValue(ref int int_0)
	{
		try
		{
			int num = int_0;
			if (1 == 0)
			{
			}
			_ContinousCoverageOverlap result = num switch
			{
				0 => _ContinousCoverageOverlap.None, 
				1 => _ContinousCoverageOverlap.Min_2, 
				2 => _ContinousCoverageOverlap.Min_5, 
				_ => _ContinousCoverageOverlap.Min_2, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return _ContinousCoverageOverlap.None;
		}
	}

	internal int CompareValue(_ContinousCoverageOverlap _ContinousCoverageOverlap_0)
	{
		try
		{
			if (1 == 0)
			{
			}
			int result = _ContinousCoverageOverlap_0 switch
			{
				_ContinousCoverageOverlap.None => 0, 
				_ContinousCoverageOverlap.Min_2 => 1, 
				_ContinousCoverageOverlap.Min_5 => 2, 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	internal int ReadValue(_ContinousCoverageOverlap _ContinousCoverageOverlap_0)
	{
		try
		{
			if (1 == 0)
			{
			}
			int result = _ContinousCoverageOverlap_0 switch
			{
				_ContinousCoverageOverlap.None => 0, 
				_ContinousCoverageOverlap.Min_2 => 2, 
				_ContinousCoverageOverlap.Min_5 => 5, 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	internal _ContinousCoverageDuration DisableValue(ref int int_0)
	{
		try
		{
			int num = int_0;
			if (1 == 0)
			{
			}
			_ContinousCoverageDuration result = num switch
			{
				0 => _ContinousCoverageDuration.hr_2, 
				1 => _ContinousCoverageDuration.hr_4, 
				2 => _ContinousCoverageDuration.hr_6, 
				3 => _ContinousCoverageDuration.hr_12, 
				4 => _ContinousCoverageDuration.hr_24, 
				_ => _ContinousCoverageDuration.hr_6, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return _ContinousCoverageDuration.hr_6;
		}
	}

	internal int UpdateValue(_ContinousCoverageDuration _ContinousCoverageDuration_0)
	{
		try
		{
			if (1 == 0)
			{
			}
			int result = _ContinousCoverageDuration_0 switch
			{
				_ContinousCoverageDuration.hr_2 => 0, 
				_ContinousCoverageDuration.hr_4 => 1, 
				_ContinousCoverageDuration.hr_6 => 2, 
				_ContinousCoverageDuration.hr_12 => 3, 
				_ContinousCoverageDuration.hr_24 => 4, 
				_ => 2, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 2;
		}
	}

	internal int InsertValue(_ContinousCoverageDuration _ContinousCoverageDuration_0)
	{
		try
		{
			if (1 == 0)
			{
			}
			int result = _ContinousCoverageDuration_0 switch
			{
				_ContinousCoverageDuration.hr_2 => 2, 
				_ContinousCoverageDuration.hr_4 => 4, 
				_ContinousCoverageDuration.hr_6 => 6, 
				_ContinousCoverageDuration.hr_12 => 12, 
				_ContinousCoverageDuration.hr_24 => 24, 
				_ => 2, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 2;
		}
	}

	internal int PrepareValue(ref _GroupSize _GroupSize_0, ref _GroupQty _GroupQty_0)
	{
		_GroupQty groupQty = _GroupQty_0;
		if (1 == 0)
		{
		}
		int result = groupQty switch
		{
			_GroupQty.None => 0, 
			_GroupQty.All => int.MaxValue, 
			_GroupQty.Group_x1 => _GroupSize_0, 
			_GroupQty.Group_x2 => (int)_GroupSize_0 * 2, 
			_GroupQty.Group_x3 => (int)_GroupSize_0 * 3, 
			_GroupQty.Group_x4 => (int)_GroupSize_0 * 4, 
			_GroupQty.Group_x6 => (int)_GroupSize_0 * 6, 
			_GroupQty.Group_x8 => (int)_GroupSize_0 * 8, 
			_GroupQty.Group_x12 => (int)_GroupSize_0 * 12, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal _GroupQty ReflectValue(ref int int_0)
	{
		try
		{
			int num = int_0;
			if (1 == 0)
			{
			}
			_GroupQty result = num switch
			{
				0 => _GroupQty.All, 
				1 => _GroupQty.None, 
				2 => _GroupQty.Group_x1, 
				3 => _GroupQty.Group_x2, 
				4 => _GroupQty.Group_x3, 
				5 => _GroupQty.Group_x4, 
				6 => _GroupQty.Group_x6, 
				7 => _GroupQty.Group_x8, 
				8 => _GroupQty.Group_x12, 
				_ => _GroupQty.All, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return _GroupQty.All;
		}
	}

	internal int VisitValue(_GroupQty _GroupQty_0)
	{
		try
		{
			if (1 == 0)
			{
			}
			int result = _GroupQty_0 switch
			{
				_GroupQty.None => 1, 
				_GroupQty.All => 0, 
				_GroupQty.Group_x1 => 2, 
				_GroupQty.Group_x2 => 3, 
				_GroupQty.Group_x3 => 4, 
				_GroupQty.Group_x4 => 5, 
				_GroupQty.Group_x6 => 6, 
				_GroupQty.Group_x8 => 7, 
				_GroupQty.Group_x12 => 8, 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	[SpecialName]
	public static string GetFlightTaskString(_FlightTask _FlightTask_0)
	{
		if (1 == 0)
		{
		}
		string result = _FlightTask_0 switch
		{
			_FlightTask.Strike_Land => "打击（地面）", 
			_FlightTask.Strike_Naval => "打击，海事（反舰）", 
			_FlightTask.Strike_OCA => "打击，OCA（进攻性对空）", 
			_FlightTask.Strike_SEAD => "打击，SEAD（压制敌方防空）", 
			_FlightTask.Sweep_Fighter => "战斗机扫荡（对空）", 
			_FlightTask.Sweep_SEAD => "SEAD（压制敌方防空）扫荡", 
			_FlightTask.BAI => "BAI（战场空中拦截）", 
			_FlightTask.CAS => "CAS（近距离空中支援）", 
			_FlightTask.CAP => "CAP（战斗空中巡逻）", 
			_FlightTask.TARCAP => "TARCAP（目标战斗空中巡逻）", 
			_FlightTask.BARCAP => "BARCAP（障碍战斗空中巡逻）", 
			_FlightTask.GLI => "GLI（地基拦截）", 
			_FlightTask.DLI => "DLI（舰基拦截）", 
			_FlightTask.Escort_FighterSweep => "护航，战斗机扫荡", 
			_FlightTask.Escort_TARCAP => "护航，TARCAP（目标战斗空中巡逻）", 
			_FlightTask.Escort_SEAD => "护航，SEAD（压制敌方防空）扫荡", 
			_FlightTask.ASAT => "ASAT（反卫星）", 
			_FlightTask.AirborneLaser => "机载激光", 
			_FlightTask.Buddy_Illumination => "支援照射", 
			_FlightTask.OECM => "OECM（进攻性ECM）", 
			_FlightTask.AEW => "AEW（空中预警）", 
			_FlightTask.CommandPost => "空中指挥所", 
			_FlightTask.ChaffLaying => "播撒箔条", 
			_FlightTask.SearchAndRescue => "SAR（搜索和救援）", 
			_FlightTask.CombatSearchAndRescue => "CSAR（战斗搜索和救援）", 
			_FlightTask.MineSweeping => "扫雷", 
			_FlightTask.MineRecon => "雷区侦察", 
			_FlightTask.NavalMineLaying => "海军雷区布设", 
			_FlightTask.ASW => "ASW（反潜战）", 
			_FlightTask.Forward_Observer => "FAC（前进空中控制）", 
			_FlightTask.Area_Surveillance => "Surveillance", 
			_FlightTask.Armed_Recon => "武装侦察", 
			_FlightTask.Unarmed_Recon => "非武装侦察", 
			_FlightTask.Maritime_Surveillance => "海上监视", 
			_FlightTask.Paratroopers => "空投", 
			_FlightTask.Troop_Transport => "部队运输", 
			_FlightTask.Cargo => "Cargo", 
			_FlightTask.AirRefueling => "空中加油", 
			_FlightTask.Training => "Training", 
			_FlightTask.TargetTow => "拖曳目标", 
			_FlightTask.TargetDrone => "靶标目标", 
			_FlightTask.Ferry => "Ferry", 
			_FlightTask.HAVCAP => "HAVCAP（高价值资产战斗空中巡逻）", 
			_FlightTask.RESCAP => "RESCAP（救援战斗空中巡逻）", 
			_FlightTask.Strike_Interdiction => "攻击，阻截（攻击后勤和增援）", 
			_FlightTask.Support => "Support", 
			_FlightTask.Escort_Support => "护航，支援", 
			_FlightTask.QRA => "QRA（快速反应警报）", 
			_ => "未配置", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	[SpecialName]
	public static string GetFlightPriorityString(_FlightPriority _FlightPriority_0)
	{
		if (_FlightPriority_0 == _FlightPriority.Mandatory)
		{
			return "Mandatory";
		}
		return "None";
	}

	[SpecialName]
	public static string GetFlightStatusString(_FlightStatus _FlightStatus_0)
	{
		if (1 == 0)
		{
		}
		string result = _FlightStatus_0 switch
		{
			_FlightStatus.LookingForAvailableAircraft => "寻找可用的飞机", 
			_FlightStatus.WaitingForPackageActivation => "等待任务包激活", 
			_FlightStatus.WaitingForAircraftToBecomeReady => "等待任务包就绪", 
			_FlightStatus.TakingOff => "起飞", 
			_FlightStatus.Airborne => "Airborne", 
			_FlightStatus.Completed => "Completed", 
			_FlightStatus.PackageEnded => "任务包已取消", 
			_FlightStatus.Airborne_EgressLeg => "Airborne", 
			_ => "Planning", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	[SpecialName]
	public static string GetFlightEditedByString(_FlightCreatedBy _FlightCreatedBy_0)
	{
		if (1 == 0)
		{
		}
		string result = _FlightCreatedBy_0 switch
		{
			_FlightCreatedBy.Player => "Player", 
			_FlightCreatedBy.MissionAI => "Mission AI", 
			_ => "None", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public virtual void PostDeserializationHousekeeping(ref Scenario scenario_0, Side side_0, bool bool_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		try
		{
			if (TankerMissions_IDs.Count > 0)
			{
				Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
				for (int j = 0; j < sides_ReadOnly.Length; j++)
				{
					foreach (Mission mission in sides_ReadOnly[j].Missions)
					{
						if (TankerMissions_IDs.Contains(mission.ObjectID))
						{
							TankerMissions.Add(mission);
						}
					}
				}
			}
			if (!string.IsNullOrEmpty(_SecondaryAirBaseID) && concurrentDictionary_0.ContainsKey(_SecondaryAirBaseID))
			{
				SecondaryAirBase = (ActiveUnit)concurrentDictionary_0[_SecondaryAirBaseID];
			}
			if (!string.IsNullOrEmpty(_SecondaryNavalBaseID) && concurrentDictionary_0.ContainsKey(_SecondaryNavalBaseID))
			{
				SecondaryNavalBase = (ActiveUnit)concurrentDictionary_0[_SecondaryNavalBaseID];
			}
			if (!RestartValue())
			{
				return;
			}
			foreach (Flight flight in FlightList)
			{
				if (!string.IsNullOrEmpty(flight.ReferenceUnit_ObjectID) && scenario_0.ActiveUnits.ContainsKey(flight.ReferenceUnit_ObjectID))
				{
					flight.SetReferenceUnit(null, scenario_0.ActiveUnits[flight.ReferenceUnit_ObjectID]);
				}
				Side[] sides_ReadOnly2;
				if (!string.IsNullOrEmpty(flight.TaskPool_ID))
				{
					sides_ReadOnly2 = scenario_0.Sides_ReadOnly;
					for (int i = 0; i < sides_ReadOnly2.Length; i++)
					{
						foreach (Mission mission2 in sides_ReadOnly2[i].Missions)
						{
							if (flight.TaskPool_ID.Contains(mission2.ObjectID))
							{
								flight.TaskPool = mission2;
							}
						}
					}
				}
				if (string.IsNullOrEmpty(flight.PrimaryTarget_ID))
				{
					continue;
				}
				sides_ReadOnly2 = scenario_0.Sides_ReadOnly;
				Side[] array = sides_ReadOnly2;
				foreach (Side side in array)
				{
					if (side.Contacts.ContainsKey(flight.PrimaryTarget_ID))
					{
						flight.PrimaryTarget = side.Contacts[flight.PrimaryTarget_ID];
						break;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool RestartValue()
	{
		if (FlightList != null && FlightList.Count != 0)
		{
			return true;
		}
		return false;
	}

	internal bool TestValue()
	{
		if (RestartValue())
		{
			foreach (Flight flight in FlightList)
			{
				if (!Information.IsNothing(flight.FlightPlan) && flight.FlightPlan.Count() > 0)
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	public void RemoveFlightsWithoutAircraft(Scenario scenario_0, Side side_0)
	{
		try
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			foreach (ActiveUnit unit in side_0.Units)
			{
				if (!unit.IsGroupMember() && (!unit.IsWeapon || ((Weapon)unit).Type != Weapon._WeaponType.Sonobuoy) && unit.AssignedMissionOrPackage() == this && unit.IsAircraft && !Information.IsNothing(unit.Navigator.GetFlight()))
				{
					list.Add(unit);
				}
			}
			bool flag = false;
			List<Flight> list2 = new List<Flight>();
			foreach (Flight flight in FlightList)
			{
				flag = false;
				foreach (ActiveUnit item in list)
				{
					if (item.Navigator.GetFlight() == flight)
					{
						flag = true;
						list.Remove(item);
						break;
					}
				}
				if (flag)
				{
					continue;
				}
				if (!Information.IsNothing(EmptySlotsList))
				{
					foreach (EmptyAircraftSlot emptySlots in EmptySlotsList)
					{
						if (!Information.IsNothing(emptySlots.GetMissionFlight(scenario_0)) && emptySlots.GetMissionFlight(scenario_0) == flight)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					list2.Add(flight);
				}
			}
			foreach (Flight item2 in list2)
			{
				Flight flight_ = item2;
				DeleteFlight(ref scenario_0, ref side_0, ref flight_, flight_.ObjectID);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DeleteFlight(ref Scenario scenario_0, ref Side side_0, ref Flight flight_0, string string_0)
	{
		try
		{
			if (Information.IsNothing(flight_0))
			{
				return;
			}
			foreach (ActiveUnit unit in side_0.Units)
			{
				if (unit != null && unit.Navigator.HasFlight && Operators.CompareString(unit.Navigator.GetFlight().ObjectID, string_0, TextCompare: false) == 0)
				{
					unit.Navigator.ClearFlight();
				}
			}
			if (!Information.IsNothing(EmptySlotsList))
			{
				for (int i = EmptySlotsList.Count - 1; i >= 0; i += -1)
				{
					EmptyAircraftSlot emptyAircraftSlot = EmptySlotsList[i];
					if ((emptyAircraftSlot.GetMissionFlight(scenario_0) == flight_0) | (emptyAircraftSlot.GetMissionFlight(scenario_0) == null))
					{
						EmptySlotsList.Remove(emptyAircraftSlot);
						emptyAircraftSlot = null;
					}
				}
			}
			for (int j = scenario_0.MissionPlannerErrorList.Count - 1; j >= 0; j += -1)
			{
				MDSP_Error mDSP_Error = scenario_0.MissionPlannerErrorList[j];
				if (Operators.CompareString(mDSP_Error.Flight, flight_0.Callsign, TextCompare: false) == 0)
				{
					scenario_0.MissionPlannerErrorList.Remove(mDSP_Error);
				}
			}
			RemoveFlight(flight_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DeleteFlightplan(ref Scenario scenario_0, ref Side side_0, ref Flight flight_0)
	{
		try
		{
			flight_0.ClearFlightPlan();
			for (int i = scenario_0.MissionPlannerErrorList.Count - 1; i >= 0; i += -1)
			{
				MDSP_Error mDSP_Error = scenario_0.MissionPlannerErrorList[i];
				if (Operators.CompareString(mDSP_Error.Flight, flight_0.Callsign, TextCompare: false) == 0)
				{
					scenario_0.MissionPlannerErrorList.Remove(mDSP_Error);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RemoveFlight(Flight flight_0)
	{
		try
		{
			if (!Information.IsNothing(flight_0) && FlightList.Contains(flight_0))
			{
				FlightList.Remove(flight_0);
				flight_0 = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AddFlight(ref Flight flight_0)
	{
		try
		{
			if (!Information.IsNothing(flight_0) && !FlightList.Contains(flight_0))
			{
				FlightList.Add(flight_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AddMasterFlight(ref Flight flight_0)
	{
		try
		{
			if (!Information.IsNothing(flight_0) && !MasterFlightList.Contains(flight_0))
			{
				MasterFlightList.Add(flight_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DeleteMission(ref Scenario scenario_0, ref Side side_0, bool bool_0 = false)
	{
		try
		{
			foreach (ActiveUnit unit in side_0.Units)
			{
				if (unit != null && unit.AssignedMissionOrPackage() == this)
				{
					MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = MissionAssignmentAttemptResult.None;
					unit.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: true, ref missionAssignmentAttemptResult_);
				}
			}
			if (Category == MissionCategory.TaskPool)
			{
				TaskPool taskPool = (TaskPool)this;
				foreach (ActiveUnit unit2 in side_0.Units)
				{
					if (unit2.AssignedTaskPool == this)
					{
						unit2.AssignedTaskPool = null;
					}
				}
				for (int i = taskPool.PackageList.Count - 1; i >= 0; i += -1)
				{
					Mission mission = taskPool.PackageList[i];
					foreach (ActiveUnit unit3 in side_0.Units)
					{
						if (unit3.AssignedMissionOrPackage() == mission)
						{
							unit3.AssignedTaskPool = null;
						}
					}
					mission.DeleteMission(ref scenario_0, ref side_0);
				}
			}
			foreach (Mission item in side_0.GetMissionsTotal(scenario_0))
			{
				if (item == null)
				{
					continue;
				}
				if (item.TankerMissions.Contains(this))
				{
					item.TankerMissions.Remove(this);
				}
				if (item.TankerMissions_IDs.Contains(ObjectID))
				{
					item.TankerMissions_IDs.Remove(ObjectID);
				}
				foreach (Flight flight in item.FlightList)
				{
					if (Information.IsNothing(flight) || flight.FlightPlan.Count() == 0)
					{
						continue;
					}
					Waypoint[] flightPlan = flight.FlightPlan;
					Waypoint[] array = flightPlan;
					foreach (Waypoint waypoint in array)
					{
						if (waypoint.TankerMissions.Contains(this))
						{
							waypoint.TankerMissions.Remove(this);
						}
						if (waypoint.TankerMissions_IDs.Contains(ObjectID))
						{
							waypoint.TankerMissions_IDs.Remove(ObjectID);
						}
					}
				}
			}
			DeleteFlights(ref scenario_0, ref side_0);
			side_0.Missions_Remove(this);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DeleteFlights(ref Scenario scenario_0, ref Side side_0)
	{
		for (int i = FlightList.Count - 1; i >= 0; i += -1)
		{
			Flight flight_ = FlightList[i];
			DeleteFlight(ref scenario_0, ref side_0, ref flight_, flight_.ObjectID);
		}
	}

	internal Mission StopValue(ref Scenario scenario_0, ref Side side_0)
	{
		Mission result = null;
		try
		{
			List<Flight> flightList = FlightList.ToList();
			UnitsAssignedToMission.ToList();
			Mission mission = Clone();
			mission.FlightList.Clear();
			mission.UnitsAssignedToMission.Clear();
			ObjectID_Set(IDGenerator.Instance.Next);
			mission.Doctrine = Doctrine.PatchRepository(ref Doctrine, mission, ref scenario_0);
			FlightList = flightList;
			mission.TankerMissions = new List<Mission>();
			side_0.Missions_Add(mission);
			result = mission;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "CloneMission");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal Aircraft CancelValue(ref Scenario scenario_0, ref Side side_0, int int_0, int int_1, ref ActiveUnit activeUnit_0, ref Flight flight_0, bool bool_0, int int_2)
	{
		try
		{
			Aircraft aircraft_ = new Aircraft(ref scenario_0);
			if (int_0 > 0)
			{
				DBFunctions.GetAircraft(ref scenario_0, ref aircraft_, int_0);
			}
			aircraft_.Name = "空位" + Conversions.ToString(int_2) + " (" + aircraft_.UnitClass + ")";
			aircraft_.SetUnitSide(bool_0: false, side_0);
			aircraft_.AI.IsEscort = bool_0;
			if (!Information.IsNothing(activeUnit_0))
			{
				aircraft_.AirOps.CurrentHostUnit = activeUnit_0;
				if (!Information.IsNothing(aircraft_.AirOps.CurrentHostUnit))
				{
					aircraft_.SetLatitude(null, aircraft_.AirOps.CurrentHostUnit.GetLatitude());
					aircraft_.SetLongitude(null, aircraft_.AirOps.CurrentHostUnit.GetLongitude());
				}
			}
			if (int_1 <= 0)
			{
				aircraft_.Loadout = new Loadout(0, "没有挂载", 0, 0, 0, 0, Loadout.LoadoutRole.None, Loadout._LoadoutDayNight.None, Loadout._LoadoutWeather.None, 0f, int.MaxValue, 0, bool_0: false, bool_1: false, bool_2: false, 0, 0, 0, 0, Loadout._LoadoutDayNight.None, Doctrine._WeaponState.NotConfigured);
			}
			else
			{
				aircraft_.Loadout = DBFunctions.GetLoadout(ref scenario_0, int_1, bool_0: false, bool_1: true);
			}
			Aircraft aircraft = aircraft_;
			MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = MissionAssignmentAttemptResult.None;
			aircraft.Set_AssignedMissionOrPackage(this, bool_0: true, bool_1: false, ref missionAssignmentAttemptResult_);
			aircraft_.Navigator.SetFlight(bool_1: true, flight_0);
			return aircraft_;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public static _TankerFollowsReceiver FollowReceiversSelection_To_FollowReceiversNumber(int int_0)
	{
		try
		{
			if (1 == 0)
			{
			}
			_TankerFollowsReceiver result = int_0 switch
			{
				0 => _TankerFollowsReceiver.UntilFull, 
				1 => _TankerFollowsReceiver.Waypoint1, 
				2 => _TankerFollowsReceiver.Waypoint2, 
				3 => _TankerFollowsReceiver.Weaypoin3, 
				4 => _TankerFollowsReceiver.UntilHoldWaypoint, 
				5 => _TankerFollowsReceiver.UntilStationWaypoint, 
				6 => _TankerFollowsReceiver.UntilLandingMarshalWaypoint, 
				_ => _TankerFollowsReceiver.UntilFull, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return _TankerFollowsReceiver.UntilFull;
		}
	}

	public static int FollowReceiversNumber_To_FollowReceiversSelection(int int_0)
	{
		try
		{
			if (1 == 0)
			{
			}
			int result = int_0 switch
			{
				0 => 0, 
				1 => 1, 
				2 => 2, 
				3 => 3, 
				-99 => 6, 
				-98 => 5, 
				-97 => 4, 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	[SpecialName]
	public static string GetTankerFollowsReceiverString(_TankerFollowsReceiver _TankerFollowsReceiver_0)
	{
		if (1 == 0)
		{
		}
		string result = _TankerFollowsReceiver_0 switch
		{
			_TankerFollowsReceiver.UntilFull => "...直到接收飞机已加满油或到达不允许加油的航点。", 
			_TankerFollowsReceiver.Waypoint1 => "...到下一个航点（1x）", 
			_TankerFollowsReceiver.Waypoint2 => "...到下一个航点后面的航点（2x）", 
			_TankerFollowsReceiver.Weaypoin3 => "...三个航点（3x）", 
			_TankerFollowsReceiver.UntilLandingMarshalWaypoint => "...直到下一个着陆集结航点", 
			_TankerFollowsReceiver.UntilStationWaypoint => "...直到下一个巡逻航点", 
			_TankerFollowsReceiver.UntilHoldWaypoint => "...直到下一个警戒结束航点", 
			_ => "None", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public virtual Mission Clone()
	{
		throw new NotImplementedException();
	}

	[SpecialName]
	public static string GetFlightTypeString(_FlightType _FlightType_0)
	{
		if (1 == 0)
		{
		}
		string result = _FlightType_0 switch
		{
			_FlightType.FlightplanTemplate => "飞行计划模板", 
			_FlightType.Flightplan => "Flightplan", 
			_ => "未配置", 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
