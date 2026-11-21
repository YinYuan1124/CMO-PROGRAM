using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;
using Command_Core.DAL;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public abstract class ActiveUnit : Module_Unit.Unit
{
	public enum TerrainFollowMode
	{
		IgnoreLandCover,
		WithinLandCover,
		AboveLandCover
	}

	public delegate void ChangedThrottleSettingEventHandler(ActiveUnit theUnit, Throttle NewThrottleSetting);

	public delegate void ParentGroupChangedEventHandler(string UnitObjectID);

	public delegate void NameChangedEventHandler(string UnitObjectID);

	public delegate void ActiveUnitMountsAddedEventHandler(string UnitObjectID, string NewMountObjectID);

	public delegate void ActiveUnitMountsRemovedEventHandler(string UnitObjectID, string RemovedMountObjectID);

	public enum TurnRate : byte
	{
		Max,
		Navigation
	}

	public enum Throttle : byte
	{
		FullStop,
		Loiter,
		Cruise,
		Full,
		Flank,
		External
	}

	public enum _ActiveUnitStatus : byte
	{
		Unassigned = 0,
		OnPlottedCourse = 1,
		EngagedOffensive = 2,
		EngagedDefensive = 3,
		OnAttackRun = 4,
		OnPatrol = 5,
		RTB = 6,
		Tasked = 7,
		FormingUp = 8,
		RTB_Manual = 10,
		OnSupportMission = 11,
		OnFerryMission = 12,
		HeadingToRefuelPoint = 13,
		Refuelling = 14,
		RTB_MissionOver = 15,
		GroupLead_SlowingToAllowFormUp = 16,
		RTB_Group = 19,
		RTB_CalledOff = 20,
		WaitForPathfinder = 21,
		AttemptingToReestablishComms = 22,
		AvoidingWeaponEffects = 23,
		ExternalControl = 30,
		RTB_Exhaustion = 99,
		Manual_Unassigned = 98
	}

	public enum _ActiveUnitFuelState : byte
	{
		None,
		IsBingo,
		IsJoker,
		IgnoreBingoAndJoker
	}

	public enum _ActiveUnitWeaponState : byte
	{
		None,
		IsWinchester,
		IsWinchester_EngagingToO,
		IsShotgun,
		IsShotgun_EngagingToO,
		IgnoreWinchesterAndShotgun
	}

	public enum GroupMemberType : byte
	{
		None
	}

	public enum AirContrailSize : byte
	{
		NoContrail,
		VSmall,
		Small,
		Medium,
		Large,
		VLarge
	}

	public struct _UNREP_Capabilities
	{
		internal byte decoratorComparator;

		internal byte processComparator;

		internal byte _ThreadComparator;

		internal byte m_RuleComparator;

		internal byte m_CollectionComparator;

		internal byte instanceComparator;

		internal byte m_ObjectComparator;

		internal byte m_ParameterComparator;

		internal byte expressionComparator;

		internal byte m_DispatcherComparator;

		internal byte listenerComparator;

		internal byte m_ConfigComparator;
	}

	[CompilerGenerated]
	private sealed class RegistryComparator
	{
		public Contact theTarget;

		internal bool IncludeInterruptibleMock(Sensor theS)
		{
			return theS.TargetsTrackedForFireControl_Readonly.Contains(theTarget);
		}
	}

	[CompilerGenerated]
	private sealed class DefinitionComparator
	{
		public FuelRec._FuelType theType;

		internal bool SearchInterruptibleMock(FuelRec theFuelrec)
		{
			return theFuelrec.FuelType == theType;
		}
	}

	public static float WEAPON_TOT_ACCEPTABLE_ERROR;

	public static float FP_RECALC_THREASHOLD;

	public int DBID;

	public bool Decoy;

	private List<string> composerVal;

	private double? _ModelVal;

	private double? m_AdvisorVal;

	internal double _CustomerVal;

	internal double m_SerializerVal;

	protected float _DesiredHeading;

	protected float _DesiredSpeed;

	protected float _DesiredAltitude;

	protected float _DesiredAltitude_AGL;

	protected TurnRate _DesiredTurnRate;

	protected Waypoint.TurnRateCategory _DesiredTurnRate_Navigation;

	protected bool _TerrainFollowing;

	public float Length;

	private Geopoint_Struct? m_RefVal;

	public float SettledTime;

	private float m_ErrorVal;

	public ActiveUnit_DockingOps.ResupplyCapacity? _DesignatedSupplier;

	public TerrainFollowMode TerrainFollowingType;

	public int EmptyWeight;

	public int MaxWeight;

	public int MaxPayloadWeight;

	public Scenario ParentScen;

	public ActiveUnit AttachedTo;

	protected Throttle _ThrottleSetting;

	protected Sensor[] _Sensors;

	protected CommDevice[] _Comms;

	[AccessedThroughProperty("Propulsion")]
	[CompilerGenerated]
	private ObservableList<Engine> m_CodeVal;

	protected List<FuelRec> _Fuel;

	private XSection[] connectionVal;

	[CompilerGenerated]
	[AccessedThroughProperty("Mounts")]
	private ObservableList<Mount> _ContextVal;

	public Cargo[] OnboardCargo;

	protected _ActiveUnitStatus _Status;

	protected _ActiveUnitFuelState _FuelState;

	protected _ActiveUnitWeaponState _WeaponState;

	private float m_StatusVal;

	protected AirFacility[] _AirFacilities;

	protected DockFacility[] _DockFacilities;

	protected Mission _AssignedMission;

	protected string _AssignedMission_ID;

	protected Mission _AssignedMissionOrPackage;

	protected string _AssignedMissionOrPackage_ID;

	protected Mission _AssignedTaskPool;

	public Dictionary<Mission, Mission> AssignedMissionsQueue;

	public List<string> _AssignedMissionsQueue_ID;

	private bool proccesorVal;

	protected string _AssignedTaskPool_ID;

	protected Group _ParentGroup;

	protected string _ParentGroup_ID;

	private bool strategyVal;

	public Doctrine Doctrine;

	internal bool configurationVal;

	protected string _SideName;

	public bool HasCustomOODA;

	internal short m_TokenVal;

	internal short _IndexerVal;

	internal short _ResolverVal;

	internal bool _PublisherVal;

	internal bool _ServerVal;

	private Throttle? adapterVal;

	internal _ActiveUnitStatus m_SchemaVal;

	internal float utilsVal;

	internal _ActiveUnitStatus predicateVal;

	internal _ActiveUnitStatus _SingletonVal;

	internal _ActiveUnitStatus _RecordVal;

	internal _ActiveUnitStatus _ExceptionVal;

	internal bool m_AttrVal;

	internal float? _VisitorVal;

	internal bool _ExporterVal;

	internal float m_PrototypeVal;

	internal _ActiveUnitFuelState comparatorVal;

	internal float _ItemVal;

	internal float setterVal;

	internal bool _CreatorVal;

	internal Throttle _TemplateVal;

	internal float m_MappingVal;

	internal float? m_MockVal;

	internal bool tagVal;

	internal Throttle fieldVal;

	internal float? queueVal;

	internal float regVal;

	internal float paramVal;

	internal bool m_PageVal;

	internal Throttle m_RulesVal;

	internal float _MethodVal;

	internal float serviceVal;

	internal bool m_SystemVal;

	internal Throttle candidateVal;

	public float TimeSinceLastThreatDetection_ESM;

	protected GlobalVariables.ProficiencyLevel? _Proficiency;

	public int OperatorCountryCode;

	public bool Hypothetical;

	private string _BaseVal;

	public bool IsBeingDestroyed;

	public Weapon[] IncomingGuidedWeaponsList;

	public bool IsBeingPickedUp;

	public bool EligibleForSAR;

	public ActiveUnit PickUpUnit;

	private int policyVal;

	public Mission.Flight.FlightElement FlightRole;

	public GroupMemberType GroupRole;

	public int ChanceOfAppearance;

	public bool IsDumbAU;

	public float TimeUnderway;

	public _UNREP_Capabilities UNREP_Capabilities;

	private ActiveUnit_Navigator broadcasterVal;

	protected ActiveUnit_AI _AI;

	private ActiveUnit_Kinematics _IdentifierVal;

	protected ActiveUnit_Sensory _Sensory;

	private ActiveUnit_Weaponry m_PrinterVal;

	protected ActiveUnit_CommStuff _CommStuff;

	protected ActiveUnit_Damage _Damage;

	protected ActiveUnit_DockingOps _DockingOps;

	protected ActiveUnit_AirOps _AirOps;

	internal bool parserVal;

	internal List<string> algoVal;

	public List<Cargo> CargoTransferList;

	[CompilerGenerated]
	private static ChangedThrottleSettingEventHandler databaseVal;

	[CompilerGenerated]
	private static ParentGroupChangedEventHandler m_InterceptorVal;

	[CompilerGenerated]
	private static NameChangedEventHandler messageVal;

	[CompilerGenerated]
	private static ActiveUnitMountsAddedEventHandler productVal;

	[CompilerGenerated]
	private static ActiveUnitMountsRemovedEventHandler _AnnotationVal;

	protected bool _DestroyEventsChecked;

	public Dictionary<XSection._SignatureType, Str_TemporaryEmission> TemporaryEmissionEM;

	public StoredCourse Journey;

	public bool IsStoringJourney;

	protected object _MineCountermeasures_Lock;

	protected List<Sensor> _MineCountermeasures;

	private object m_IteratorVal;

	private Sensor[] m_InitializerVal;

	[ThreadStatic]
	protected List<Sensor> _SensorList;

	private int _RoleVal;

	[CompilerGenerated]
	private bool factoryVal;

	public float TemporaryBlindness
	{
		get
		{
			return m_ErrorVal;
		}
		set
		{
			m_ErrorVal = Math.Min(Math.Max(value, 0f), 240f);
		}
	}

	public bool LandCoverMaskingCapability
	{
		[CompilerGenerated]
		get
		{
			return factoryVal;
		}
		[CompilerGenerated]
		set
		{
			factoryVal = value;
		}
	}

	public float MaxSpeed
	{
		get
		{
			try
			{
				return Kinematics.GetMaximumSpeed();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
				return 0f;
			}
		}
	}

	public virtual ObservableList<Engine> Propulsion
	{
		[CompilerGenerated]
		get
		{
			return m_CodeVal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<Engine>> value2 = MoveClient;
			EventHandler<ObservableListModified<Engine>> value3 = DeleteClient;
			ObservableList<Engine> codeVal = m_CodeVal;
			if (codeVal != null)
			{
				codeVal.ItemsAdded -= value2;
				codeVal.ItemsRemoved -= value3;
			}
			m_CodeVal = value;
			codeVal = m_CodeVal;
			if (codeVal != null)
			{
				codeVal.ItemsAdded += value2;
				codeVal.ItemsRemoved += value3;
			}
		}
	}

	public virtual ObservableList<Mount> Mounts
	{
		[CompilerGenerated]
		get
		{
			return _ContextVal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<Mount>> value2 = CloneClient;
			EventHandler<ObservableListModified<Mount>> value3 = ConnectClient;
			ObservableList<Mount> contextVal = _ContextVal;
			if (contextVal != null)
			{
				contextVal.ItemsAdded -= value2;
				contextVal.ItemsRemoved -= value3;
			}
			_ContextVal = value;
			contextVal = _ContextVal;
			if (contextVal != null)
			{
				contextVal.ItemsAdded += value2;
				contextVal.ItemsRemoved += value3;
			}
		}
	}

	public virtual float MAX_Exhaustion => 100f;

	public virtual float Current_Exhaustion => 0f;

	public virtual ActiveUnit CurrentHostUnitCargoSource
	{
		get
		{
			if (IsAircraft)
			{
				return ((Aircraft)this).AirOps.CurrentHostUnit;
			}
			if ((IsShip || IsSubmarine || (IsVehicle && ((Vehicle)this).IsOutOfFuel)) && DockingOps.CurrentHostUnit != null && DockingOps.CurrentHostUnit.IsGroupMember())
			{
				Group.GroupType? groupType = DockingOps.CurrentHostUnit.GetParentGroup()?.Type;
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
					return DockingOps.CurrentHostUnit.GetParentGroup();
				}
			}
			return DockingOps.CurrentHostUnit;
		}
	}

	public virtual ActiveUnit AssignedHostUnitCargoSource
	{
		get
		{
			ActiveUnit activeUnit = DockingOps.GetAssignedHostUnit();
			bool flag = false;
			if (IsAircraft)
			{
				activeUnit = ((Aircraft)this).AirOps.GetAssignedHostUnit();
				flag = true;
			}
			else if (IsShip || IsSubmarine || (IsVehicle && ((Vehicle)this).IsOutOfFuel))
			{
				flag = true;
			}
			if (flag && activeUnit != null && activeUnit.IsGroupMember())
			{
				Group.GroupType? groupType = activeUnit.GetParentGroup()?.Type;
				byte? b = (byte?)groupType;
				bool? flag2;
				bool? flag3 = (flag2 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null));
				bool? flag4;
				bool? flag5;
				if (flag3.HasValue && flag2.GetValueOrDefault())
				{
					flag4 = true;
				}
				else
				{
					b = (byte?)groupType;
					flag3 = (flag5 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null));
					flag4 = ((!flag3.HasValue) ? null : (flag5.GetValueOrDefault() | flag2));
				}
				bool? flag6 = flag4;
				flag5 = flag4;
				bool? flag7;
				bool? flag8;
				if (flag5.HasValue && flag6.GetValueOrDefault())
				{
					flag7 = true;
				}
				else
				{
					b = (byte?)groupType;
					flag5 = (flag8 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 6) : null));
					flag7 = ((!flag5.HasValue) ? null : (flag8.GetValueOrDefault() | flag6));
				}
				flag8 = flag7;
				if (flag8.GetValueOrDefault())
				{
					activeUnit = activeUnit.GetParentGroup();
				}
			}
			if (IsVehicle && activeUnit == null)
			{
				return DockingOps.OriginalCargoHostUnit;
			}
			return activeUnit;
		}
	}

	public bool AllowMultiMission
	{
		get
		{
			return proccesorVal;
		}
		set
		{
			proccesorVal = value;
		}
	}

	public override string Name
	{
		get
		{
			if (IsDecoy)
			{
				if (base.Name.Contains("[DECOY]"))
				{
					return base.Name;
				}
				return "[DECOY] " + base.Name;
			}
			return base.Name;
		}
		set
		{
			Operators.CompareString(base.Name, value, TextCompare: false);
			base.Name = value;
			messageVal?.Invoke(ObjectID);
		}
	}

	public double? Latitude_LastReported
	{
		get
		{
			if (!m_AdvisorVal.HasValue)
			{
				m_AdvisorVal = GetLatitude();
			}
			return m_AdvisorVal;
		}
		set
		{
			m_AdvisorVal = value;
		}
	}

	public double? Longitude_LastReported
	{
		get
		{
			if (!_ModelVal.HasValue)
			{
				_ModelVal = GetLongitude();
			}
			return _ModelVal;
		}
		set
		{
			_ModelVal = value;
		}
	}

	public int InitialDP
	{
		get
		{
			return policyVal;
		}
		set
		{
			policyVal = value;
		}
	}

	public virtual bool IsBallisticMissile => false;

	public override float Attitude_Pitch
	{
		get
		{
			if (SupportsAttitude_Pitch)
			{
				return _Attitude_Pitch;
			}
			if (IsWeapon && ((Weapon)this).IsPalletWeapon)
			{
				return _Attitude_Pitch;
			}
			if (!IsFacility && !IsShip)
			{
				float num = GetCurrentAltitude() - base.Altitude_old;
				if (num == 0f)
				{
					return 0f;
				}
				double x = (double)CurrentSpeed * 0.514444 * (double)ParentScen.GameResolution;
				double num2 = Math.Atan2(Math.Abs(num), x) * 57.2957795130823;
				if (num <= 0f)
				{
					return 0f - (float)num2;
				}
				return (float)num2;
			}
			return 0f;
		}
		set
		{
			base.Attitude_Pitch = value;
		}
	}

	public override float CurrentHeading
	{
		get
		{
			return base.CurrentHeading;
		}
		set
		{
			base.CurrentHeading = Math2.UpdateClass(value);
			DockingOps.ResetPierEntranceLaneCache();
		}
	}

	public virtual bool IsDecoy => Decoy;

	public virtual GlobalVariables.ProficiencyLevel? Proficiency
	{
		get
		{
			GlobalVariables.ProficiencyLevel? result;
			if (_Proficiency.HasValue)
			{
				result = _Proficiency.Value;
			}
			else if (GetUnitSide() == null)
			{
				if (this is Weapon && !((Weapon)this)._FacadeReader && Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = GlobalVariables.ProficiencyLevel.Regular;
			}
			else
			{
				result = GetUnitSide().Proficiency;
			}
			return result;
		}
		set
		{
			_Proficiency = value;
		}
	}

	public virtual bool HasSystemsRunning
	{
		get
		{
			if (IsOperating())
			{
				return true;
			}
			ActiveUnit_DockingOps._DockingOpsCondition condition = DockingOps.Condition;
			if (condition != ActiveUnit_DockingOps._DockingOpsCondition.Docked && condition != ActiveUnit_DockingOps._DockingOpsCondition.Readying && condition != ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
			{
				return true;
			}
			return false;
		}
	}

	public string UnitType_String
	{
		get
		{
			if (string.IsNullOrEmpty(_BaseVal))
			{
				if (IsGroup)
				{
					return "Group";
				}
				switch (UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					_BaseVal = "Aircraft";
					break;
				case GlobalVariables.ActiveUnitType.Ship:
					_BaseVal = "Ship";
					break;
				case GlobalVariables.ActiveUnitType.Submarine:
					_BaseVal = "Submarine";
					break;
				case GlobalVariables.ActiveUnitType.Facility:
					_BaseVal = "Facility";
					break;
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
						break;
					}
					return UnitType.ToString();
				case GlobalVariables.ActiveUnitType.Weapon:
					_BaseVal = "Weapon";
					break;
				case GlobalVariables.ActiveUnitType.Satellite:
					_BaseVal = "Satellite";
					break;
				case GlobalVariables.ActiveUnitType.Vehicle:
					_BaseVal = "地面单元";
					break;
				}
			}
			return _BaseVal;
		}
	}

	public XSection[] XSections_ReadOnly
	{
		get
		{
			if (connectionVal == null)
			{
				string key = UnitType_String + "_" + Conversions.ToString(DBID);
				if (ParentScen.Cache_XSections.ContainsKey(key))
				{
					connectionVal = ParentScen.Cache_XSections[key];
				}
				else
				{
					connectionVal = DBFunctions.GetXSections(this);
					ParentScen.Cache_XSections.TryAdd(key, connectionVal);
				}
			}
			return connectionVal;
		}
	}

	public virtual GlobalVariables.ActiveUnitType UnitType => GlobalVariables.ActiveUnitType.None;

	public virtual int SubType
	{
		get
		{
			switch (UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				return DBFunctions.GetAircraftType_Int(ref ParentScen, DBID);
			case GlobalVariables.ActiveUnitType.Ship:
				return DBFunctions.GetShipType_Int(ref ParentScen, DBID);
			case GlobalVariables.ActiveUnitType.Submarine:
				return DBFunctions.GetSubmarineType_Int(ref ParentScen, DBID);
			case GlobalVariables.ActiveUnitType.Facility:
				return DBFunctions.GetFacilityType_Int(ref ParentScen, DBID);
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new NotImplementedException();
			case GlobalVariables.ActiveUnitType.Weapon:
				return DBFunctions.GetWeaponType_Int(ref ParentScen, DBID);
			case GlobalVariables.ActiveUnitType.Satellite:
				return DBFunctions.GetSatelliteType_Int(ref ParentScen, DBID);
			case GlobalVariables.ActiveUnitType.Vehicle:
				return DBFunctions.GetVehicleType_Int(ref ParentScen, DBID);
			}
		}
	}

	public virtual string SubTypeDescription
	{
		get
		{
			switch (UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				return DBFunctions.GetAircraftType_String(ref ParentScen, DBID);
			case GlobalVariables.ActiveUnitType.Ship:
				return DBFunctions.GetShipType_String(ref ParentScen, DBID);
			case GlobalVariables.ActiveUnitType.Submarine:
				return DBFunctions.GetSubmarineType_String(ref ParentScen, DBID);
			case GlobalVariables.ActiveUnitType.Facility:
				return DBFunctions.GetFacilityType_String(ref ParentScen, DBID);
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return UnitType.ToString();
			case GlobalVariables.ActiveUnitType.Weapon:
				return DBFunctions.GetWeaponType_String(ref ParentScen, DBID);
			case GlobalVariables.ActiveUnitType.Satellite:
				return DBFunctions.GetSatelliteType_String(ref ParentScen, DBID);
			case GlobalVariables.ActiveUnitType.Vehicle:
				return DBFunctions.GetGroundUnitType_String(ref ParentScen, DBID);
			}
		}
	}

	public override bool UseAerialUnitUI
	{
		get
		{
			if (IsAircraft)
			{
				return true;
			}
			return false;
		}
	}

	public override bool UseSubmerisbleUnitUI
	{
		get
		{
			if (IsSubmarine)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsAerospaceUnit
	{
		get
		{
			switch (UnitType)
			{
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return false;
			case GlobalVariables.ActiveUnitType.Weapon:
				switch (((Weapon)this).Type)
				{
				default:
					return false;
				case Weapon._WeaponType.GuidedWeapon:
				case Weapon._WeaponType.Rocket:
				case Weapon._WeaponType.IronBomb:
				case Weapon._WeaponType.Decoy_Vehicle:
				case Weapon._WeaponType.GuidedProjectile:
				case Weapon._WeaponType.UAV_Expendable:
				case Weapon._WeaponType.BallisticMissile:
				case Weapon._WeaponType.RV:
				case Weapon._WeaponType.PalletWeapon:
				case Weapon._WeaponType.HGV:
					return true;
				}
			case GlobalVariables.ActiveUnitType.Aircraft:
			case GlobalVariables.ActiveUnitType.Satellite:
				return true;
			case GlobalVariables.ActiveUnitType.None:
			case GlobalVariables.ActiveUnitType.Ship:
			case GlobalVariables.ActiveUnitType.Submarine:
			case GlobalVariables.ActiveUnitType.Facility:
			case GlobalVariables.ActiveUnitType.Vehicle:
			case GlobalVariables.ActiveUnitType.Personnel:
				return false;
			}
		}
	}

	public bool IsHardTarget
	{
		get
		{
			if (UnitType == GlobalVariables.ActiveUnitType.Facility)
			{
				switch (((Facility)this).Category)
				{
				default:
					return false;
				case Facility._FacilityCategory.Runway:
				case Facility._FacilityCategory.RunwayGrade_Taxiway:
				case Facility._FacilityCategory.RunwayAccessPoint:
				case Facility._FacilityCategory.Building_Bunker:
				case Facility._FacilityCategory.Building_Underground:
				case Facility._FacilityCategory.SurfaceAndUnderground:
				case Facility._FacilityCategory.AirBase:
					return true;
				}
			}
			return false;
		}
	}

	public bool IsExpendableUAV
	{
		get
		{
			if (AssignedMissionOrPackage() == null)
			{
				return false;
			}
			if (AssignedMissionOrPackage().IsActive)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsOnActivePatrol
	{
		get
		{
			if (AssignedMissionOrPackage() == null)
			{
				return false;
			}
			if (AssignedMissionOrPackage().IsActive)
			{
				return AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol;
			}
			return false;
		}
	}

	public bool IsOnActiveStrike
	{
		get
		{
			if (AssignedMissionOrPackage() == null)
			{
				return false;
			}
			if (AssignedMissionOrPackage().IsActive)
			{
				return AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike;
			}
			return false;
		}
	}

	public bool IsOnActiveMiningMission
	{
		get
		{
			if (AssignedMissionOrPackage() == null)
			{
				return false;
			}
			if (AssignedMissionOrPackage().IsActive)
			{
				return AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Mining;
			}
			return false;
		}
	}

	public bool IsOnActiveMineClearingMission
	{
		get
		{
			if (AssignedMissionOrPackage() == null)
			{
				return false;
			}
			if (AssignedMissionOrPackage().IsActive)
			{
				return AssignedMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing;
			}
			return false;
		}
	}

	public bool IsOnActiveCargoMission
	{
		get
		{
			if (AssignedMissionOrPackage() == null)
			{
				return false;
			}
			if (AssignedMissionOrPackage().IsActive)
			{
				return AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Cargo;
			}
			return false;
		}
	}

	public bool IsOnActiveFerryMission
	{
		get
		{
			if (AssignedMissionOrPackage() == null)
			{
				return false;
			}
			if (AssignedMissionOrPackage().IsActive)
			{
				return AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Ferry;
			}
			return false;
		}
	}

	public virtual bool IsMCMPlatform => false;

	public virtual bool IsMineLayingPlatform => false;

	public Weather.WeatherProfile WeatherAtMyLocation
	{
		get
		{
			if (ParentScen.WeatherLevel != 0)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new NotImplementedException();
			}
			return Weather.GetWeatherAtThisTimeAndPlace(ParentScen, GetLatitude(), GetLongitude(), (int)Math.Round(GetCurrentAltitude()));
		}
	}

	public virtual List<FuelRec> Fuel_ReadOnly => _Fuel;

	public override float DesiredPitch
	{
		get
		{
			return base.DesiredPitch;
		}
		set
		{
			base.DesiredPitch = value;
			AI.CalculatedDesiredPitchThisPulse = true;
		}
	}

	public virtual float DesiredHeading => _DesiredHeading;

	public virtual float DesiredSpeed
	{
		get
		{
			return _DesiredSpeed;
		}
		set
		{
			if (value > 0f)
			{
				float num = Kinematics.GetMaximumSpeed();
				if (value > num)
				{
					value = num;
				}
			}
			float minimumSpeed_Total = Kinematics.GetMinimumSpeed_Total(GetCurrentAltitude(), bool_0: false);
			if (value < minimumSpeed_Total)
			{
				value = minimumSpeed_Total;
			}
			_DesiredSpeed = value;
		}
	}

	public virtual float DesiredAltitude
	{
		get
		{
			return _DesiredAltitude;
		}
		set
		{
			float maximumAltitude = Kinematics.GetMaximumAltitude();
			if (value > maximumAltitude)
			{
				value = maximumAltitude;
			}
			value = (float)Math.Round(value, 2);
			if (value != _DesiredAltitude)
			{
				_DesiredAltitude = value;
				AI.CalculatedDesiredPitchThisPulse = false;
			}
		}
	}

	public virtual float DesiredAltitude_AGL
	{
		get
		{
			return _DesiredAltitude_AGL;
		}
		set
		{
			float maximumAltitude = Kinematics.GetMaximumAltitude();
			if (value > maximumAltitude)
			{
				value = maximumAltitude;
			}
			value = (float)Math.Round(value, 2);
			_DesiredAltitude_AGL = value;
		}
	}

	public virtual TurnRate DesiredTurnRate
	{
		get
		{
			return _DesiredTurnRate;
		}
		set
		{
			_DesiredTurnRate = value;
		}
	}

	public virtual Waypoint.TurnRateCategory DesiredTurnRate_Navigation
	{
		get
		{
			return _DesiredTurnRate_Navigation;
		}
		set
		{
			_DesiredTurnRate_Navigation = value;
		}
	}

	public virtual double CornerSpeed => CurrentSpeed;

	public virtual Throttle MaxPossibleThrottleSetting
	{
		get
		{
			if (!adapterVal.HasValue)
			{
				if (Propulsion.Count == 0)
				{
					if (IsPalletWeapon)
					{
						adapterVal = Throttle.Cruise;
					}
					adapterVal = Throttle.FullStop;
				}
				else if (Kinematics.CanApplyFlankThrottle())
				{
					adapterVal = Throttle.Flank;
				}
				else if (Kinematics.CanApplyFullThrottle())
				{
					adapterVal = Throttle.Full;
				}
				else
				{
					adapterVal = Throttle.Cruise;
				}
			}
			return adapterVal.Value;
		}
	}

	public virtual Throttle MinPossibleThrottleSetting
	{
		get
		{
			if (IsAircraft && !((Aircraft)this).IsHelicopter)
			{
				return Throttle.Loiter;
			}
			return Throttle.FullStop;
		}
	}

	public virtual Throttle ThrottleSetting
	{
		get
		{
			return _ThrottleSetting;
		}
		set
		{
			_ThrottleSetting = value;
		}
	}

	public virtual ActiveUnit_Navigator Navigator
	{
		get
		{
			if (broadcasterVal == null)
			{
				if (IsGroup)
				{
					return ((Group)this).Navigator;
				}
				switch (UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					return ((Aircraft)this).Navigator;
				case GlobalVariables.ActiveUnitType.Ship:
					return ((Ship)this).Navigator;
				case GlobalVariables.ActiveUnitType.Submarine:
					return ((Submarine)this).Navigator;
				case GlobalVariables.ActiveUnitType.Facility:
					return ((Facility)this).Navigator;
				case GlobalVariables.ActiveUnitType.Weapon:
					return ((Weapon)this).Navigator;
				case GlobalVariables.ActiveUnitType.Vehicle:
					return ((Vehicle)this).Navigator;
				}
				ActiveUnit activeUnit_ = this;
				broadcasterVal = new ActiveUnit_Navigator(ref activeUnit_);
			}
			return broadcasterVal;
		}
	}

	public virtual ActiveUnit_AI AI
	{
		get
		{
			if (_AI == null)
			{
				if (IsGroup)
				{
					return ((Group)this).AI;
				}
				switch (UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					return ((Aircraft)this).AI;
				case GlobalVariables.ActiveUnitType.Ship:
					return ((Ship)this).AI;
				case GlobalVariables.ActiveUnitType.Submarine:
					return ((Submarine)this).AI;
				case GlobalVariables.ActiveUnitType.Facility:
					return ((Facility)this).AI;
				case GlobalVariables.ActiveUnitType.Weapon:
					return ((Weapon)this).AI;
				case GlobalVariables.ActiveUnitType.Vehicle:
					return ((Vehicle)this).AI;
				}
				_AI = new ActiveUnit_AI(this);
			}
			return _AI;
		}
	}

	public virtual ActiveUnit_Kinematics Kinematics
	{
		get
		{
			if (_IdentifierVal == null)
			{
				if (IsGroup)
				{
					return ((Group)this).Kinematics;
				}
				switch (UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					return ((Aircraft)this).Kinematics;
				case GlobalVariables.ActiveUnitType.Ship:
					return ((Ship)this).Kinematics;
				case GlobalVariables.ActiveUnitType.Submarine:
					return ((Submarine)this).Kinematics;
				case GlobalVariables.ActiveUnitType.Facility:
					return ((Facility)this).Kinematics;
				case GlobalVariables.ActiveUnitType.Weapon:
					return ((Weapon)this).Kinematics;
				case GlobalVariables.ActiveUnitType.Satellite:
					return ((Satellite)this).Kinematics;
				case GlobalVariables.ActiveUnitType.Vehicle:
					return ((Vehicle)this).Kinematics;
				}
				ActiveUnit activeUnit_ = this;
				_IdentifierVal = new ActiveUnit_Kinematics(ref activeUnit_);
			}
			return _IdentifierVal;
		}
	}

	public virtual ActiveUnit_Sensory Sensory
	{
		get
		{
			if (_Sensory == null)
			{
				if (IsGroup)
				{
					return ((Group)this).Sensory;
				}
				switch (UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					return ((Aircraft)this).Sensory;
				case GlobalVariables.ActiveUnitType.Ship:
					return ((Ship)this).Sensory;
				case GlobalVariables.ActiveUnitType.Submarine:
					return ((Submarine)this).Sensory;
				case GlobalVariables.ActiveUnitType.Facility:
					return ((Facility)this).Sensory;
				case GlobalVariables.ActiveUnitType.Weapon:
					return ((Weapon)this).Sensory;
				case GlobalVariables.ActiveUnitType.Vehicle:
					return ((Vehicle)this).Sensory;
				}
				ActiveUnit activeUnit_ = this;
				_Sensory = new ActiveUnit_Sensory(ref activeUnit_);
			}
			return _Sensory;
		}
	}

	public virtual ActiveUnit_Weaponry Weaponry
	{
		get
		{
			if (m_PrinterVal == null)
			{
				if (IsGroup)
				{
					return ((Group)this).Weaponry;
				}
				switch (UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					return ((Aircraft)this).Weaponry;
				case GlobalVariables.ActiveUnitType.Ship:
					return ((Ship)this).Weaponry;
				case GlobalVariables.ActiveUnitType.Submarine:
					return ((Submarine)this).Weaponry;
				case GlobalVariables.ActiveUnitType.Facility:
					return ((Facility)this).Weaponry;
				case GlobalVariables.ActiveUnitType.Vehicle:
					return ((Vehicle)this).Weaponry;
				}
				m_PrinterVal = new ActiveUnit_Weaponry(this);
			}
			return m_PrinterVal;
		}
	}

	public virtual ActiveUnit_CommStuff CommStuff
	{
		get
		{
			if (_CommStuff == null)
			{
				if (IsGroup)
				{
					return ((Group)this).CommStuff;
				}
				switch (UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					return ((Aircraft)this).CommStuff;
				case GlobalVariables.ActiveUnitType.Ship:
					return ((Ship)this).CommStuff;
				case GlobalVariables.ActiveUnitType.Submarine:
					return ((Submarine)this).CommStuff;
				case GlobalVariables.ActiveUnitType.Facility:
					return ((Facility)this).CommStuff;
				case GlobalVariables.ActiveUnitType.Weapon:
					return ((Weapon)this).CommStuff;
				case GlobalVariables.ActiveUnitType.Vehicle:
					return ((Vehicle)this).CommStuff;
				}
				ActiveUnit activeUnit_ = this;
				_CommStuff = new ActiveUnit_CommStuff(ref activeUnit_);
			}
			return _CommStuff;
		}
	}

	public virtual ActiveUnit_Damage Damage
	{
		get
		{
			if (_Damage == null)
			{
				if (IsGroup)
				{
					return ((Group)this).Damage;
				}
				switch (UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					return ((Aircraft)this).Damage;
				case GlobalVariables.ActiveUnitType.Ship:
					return ((Ship)this).Damage;
				case GlobalVariables.ActiveUnitType.Submarine:
					return ((Submarine)this).Damage;
				case GlobalVariables.ActiveUnitType.Facility:
					return ((Facility)this).Damage;
				case GlobalVariables.ActiveUnitType.Weapon:
					return ((Weapon)this).Damage;
				case GlobalVariables.ActiveUnitType.Satellite:
					return ((Satellite)this).Damage;
				case GlobalVariables.ActiveUnitType.Vehicle:
					return ((Vehicle)this).Damage;
				}
				ActiveUnit activeUnit_ = this;
				_Damage = new ActiveUnit_Damage(ref activeUnit_);
			}
			return _Damage;
		}
	}

	public virtual ActiveUnit_AirOps AirOps
	{
		get
		{
			if (_AirOps == null)
			{
				if (IsGroup)
				{
					return ((Group)this).AirOps;
				}
				if (UnitType == GlobalVariables.ActiveUnitType.Aircraft)
				{
					return ((Aircraft)this).AirOps;
				}
				ActiveUnit activeUnit_ = this;
				_AirOps = new ActiveUnit_AirOps(ref activeUnit_);
			}
			return _AirOps;
		}
	}

	public virtual ActiveUnit_DockingOps DockingOps
	{
		get
		{
			if (_DockingOps == null)
			{
				ActiveUnit activeUnit_ = this;
				_DockingOps = new ActiveUnit_DockingOps(ref activeUnit_);
			}
			return _DockingOps;
		}
	}

	public virtual CommDevice[] Comms_ReadOnly
	{
		get
		{
			if (Mounts.Count <= 0)
			{
				return _Comms;
			}
			CommDevice[] gparam_ = null;
			int num = Mounts.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				Mount mount = Mounts[i];
				int num2 = mount.CommDevices.Length - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (gparam_ == null)
					{
						gparam_ = ForgotIssuer();
					}
					CommDevice commDevice = mount.CommDevices[j];
					commDevice.IsCommsInMount = true;
					ArrayExtensions.Add(ref gparam_, commDevice);
				}
			}
			if (gparam_ == null)
			{
				return _Comms;
			}
			return gparam_;
		}
	}

	public virtual List<Sensor> MineCountermeasures
	{
		get
		{
			if (_MineCountermeasures == null)
			{
				object mineCountermeasures_Lock = _MineCountermeasures_Lock;
				ObjectFlowControl.CheckForSyncLockOnValueType(mineCountermeasures_Lock);
				bool lockTaken = false;
				try
				{
					Monitor.Enter(mineCountermeasures_Lock, ref lockTaken);
					List<Sensor> list = new List<Sensor>();
					Sensor[] sensors = _Sensors;
					Sensor[] array = sensors;
					foreach (Sensor sensor in array)
					{
						if (sensor.IsMineCountermeasure)
						{
							list.Add(sensor);
						}
					}
					_MineCountermeasures = list;
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(mineCountermeasures_Lock);
					}
				}
			}
			return _MineCountermeasures;
		}
		set
		{
			object mineCountermeasures_Lock = _MineCountermeasures_Lock;
			ObjectFlowControl.CheckForSyncLockOnValueType(mineCountermeasures_Lock);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(mineCountermeasures_Lock, ref lockTaken);
				_MineCountermeasures = value;
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(mineCountermeasures_Lock);
				}
			}
		}
	}

	public Sensor[] Sensors_Cached
	{
		get
		{
			if (m_InitializerVal == null)
			{
				object iteratorVal = m_IteratorVal;
				ObjectFlowControl.CheckForSyncLockOnValueType(iteratorVal);
				bool lockTaken = false;
				try
				{
					Monitor.Enter(iteratorVal, ref lockTaken);
					m_InitializerVal = Sensors_ReadOnly();
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(iteratorVal);
					}
				}
			}
			return m_InitializerVal;
		}
		set
		{
			object iteratorVal = m_IteratorVal;
			ObjectFlowControl.CheckForSyncLockOnValueType(iteratorVal);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(iteratorVal, ref lockTaken);
				m_InitializerVal = value;
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(iteratorVal);
				}
			}
		}
	}

	public bool HasEmittingSensors
	{
		get
		{
			bool result = false;
			try
			{
				if (Sensors_Cached.Length == 0)
				{
					result = false;
					return false;
				}
				Sensor[] sensors_Cached = Sensors_Cached;
				int num = 0;
				while (true)
				{
					if (num < sensors_Cached.Length)
					{
						if (sensors_Cached[num].IsActive)
						{
							break;
						}
						num = checked(num + 1);
						continue;
					}
					result = false;
					return false;
				}
				result = true;
				return true;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101186", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public bool HasEmittingRadars
	{
		get
		{
			bool result = false;
			try
			{
				if (Sensors_Cached.Length == 0)
				{
					result = false;
					return false;
				}
				Sensor[] sensors_Cached = Sensors_Cached;
				int num = 0;
				while (true)
				{
					if (num < sensors_Cached.Length)
					{
						Sensor sensor = sensors_Cached[num];
						if ((sensor.Type == Sensor.Sensor_Type.Radar) & sensor.IsActive)
						{
							break;
						}
						num++;
						continue;
					}
					result = false;
					return false;
				}
				result = true;
				return true;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101186", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public virtual bool IsOutOfFuel
	{
		get
		{
			bool result = false;
			try
			{
				List<FuelRec> fuel_ReadOnly = Fuel_ReadOnly;
				if (fuel_ReadOnly.Count == 0)
				{
					result = false;
					return false;
				}
				foreach (FuelRec item in fuel_ReadOnly)
				{
					if (item != null && !(item.CurrentQuantity <= 0f))
					{
						result = false;
						return false;
					}
				}
				result = true;
				return true;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101187", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public bool IsDestroyed
	{
		get
		{
			if (IsBeingDestroyed)
			{
				return true;
			}
			if (!ParentScen.ActiveUnits.ContainsKey(ObjectID) && !ParentScen.NewbornUnits.Contains(this))
			{
				return true;
			}
			return ParentScen.MorituriUnits.Contains(this);
		}
	}

	public virtual AirFacility[] AirFacilities_ReadOnly => _AirFacilities;

	public virtual DockFacility[] DockFacilities_ReadOnly => _DockFacilities;

	public bool HasMineDisposalCharges
	{
		get
		{
			foreach (Sensor mineCountermeasure in MineCountermeasures)
			{
				if (mineCountermeasure.IsExplosiveMineNeutralizer)
				{
					return true;
				}
			}
			return false;
		}
	}

	public virtual Mission AssignedTaskPool
	{
		get
		{
			try
			{
				if (_AssignedTaskPool == null)
				{
					if (_AssignedMissionOrPackage != null && _AssignedMissionOrPackage.Category == Mission.MissionCategory.Package && !string.IsNullOrEmpty(_AssignedMissionOrPackage.GetParentTaskPoolID(GetUnitSide())))
					{
						_AssignedTaskPool_ID = _AssignedMissionOrPackage.GetParentTaskPoolID(GetUnitSide());
					}
					if (!string.IsNullOrEmpty(_AssignedTaskPool_ID))
					{
						ReadOnlyCollection<Mission> missionsTotal = GetUnitSide().GetMissionsTotal(ParentScen);
						int num = missionsTotal.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							Mission mission = missionsTotal[i];
							if (mission != null && Operators.CompareString(mission.ObjectID, _AssignedTaskPool_ID, TextCompare: false) == 0)
							{
								_AssignedTaskPool = mission;
								break;
							}
						}
						if (_AssignedTaskPool == null)
						{
							_AssignedTaskPool_ID = null;
						}
					}
				}
				return _AssignedTaskPool;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200638", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return null;
			}
		}
		set
		{
			try
			{
				if (value == null)
				{
					_AssignedTaskPool = null;
					_AssignedTaskPool_ID = "";
				}
				else
				{
					_AssignedTaskPool = value;
					_AssignedTaskPool_ID = value.ObjectID;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200639", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public virtual ActiveUnit_DockingOps.ResupplyCapacity DesignatedSupplier
	{
		get
		{
			if (_DesignatedSupplier.HasValue)
			{
				return _DesignatedSupplier.Value;
			}
			return ActiveUnit_DockingOps.ResupplyCapacity.None;
		}
		set
		{
			_DesignatedSupplier = value;
		}
	}

	public virtual bool CanPhysicallyReplenishOtherUnits => false;

	public virtual _ActiveUnitStatus Status
	{
		get
		{
			return _Status;
		}
		set
		{
			try
			{
				configurationVal = value != _Status;
				if (configurationVal)
				{
					if (((value == _ActiveUnitStatus.RTB || value == _ActiveUnitStatus.RTB_MissionOver || value == _ActiveUnitStatus.RTB_Group || value == _ActiveUnitStatus.Tasked) && _Status == _ActiveUnitStatus.Manual_Unassigned) || (CountClient(GetLatitude(), GetLongitude(), 0f) && _Status == _ActiveUnitStatus.OnPlottedCourse))
					{
						return;
					}
					m_SchemaVal = _Status;
					if (((value == _ActiveUnitStatus.RTB && FuelState == _ActiveUnitFuelState.IsBingo) || value == _ActiveUnitStatus.HeadingToRefuelPoint || value == _ActiveUnitStatus.Refuelling) && (m_SchemaVal != _ActiveUnitStatus.RTB || FuelState != _ActiveUnitFuelState.IsBingo) && m_SchemaVal != _ActiveUnitStatus.HeadingToRefuelPoint && m_SchemaVal != _ActiveUnitStatus.Refuelling)
					{
						predicateVal = _Status;
						comparatorVal = _FuelState;
						if (IsGroupWingman() && !IsGroupLead() && !Navigator.HasPlottedCourse())
						{
							if (GetParentGroup().GroupLead.Status == _ActiveUnitStatus.EngagedDefensive)
							{
								_TemplateVal = GetParentGroup().GroupLead.fieldVal;
							}
							else if (GetParentGroup().GroupLead.Status == _ActiveUnitStatus.EngagedOffensive)
							{
								_TemplateVal = GetParentGroup().GroupLead.m_RulesVal;
							}
							else if (GetParentGroup().GroupLead.Status == _ActiveUnitStatus.WaitForPathfinder)
							{
								_TemplateVal = GetParentGroup().GroupLead.candidateVal;
							}
							else
							{
								_TemplateVal = GetParentGroup().GroupLead.ThrottleSetting;
							}
						}
						else
						{
							_TemplateVal = ThrottleSetting;
						}
						_ItemVal = DesiredAltitude;
						setterVal = DesiredAltitude_AGL;
						_CreatorVal = GetDesiredAltitude_UseTerrainFollowing(this);
						SetDesiredAltitude_UseTerrainFollowing(this, bool_0: false);
						if (IsAircraft && Navigator.HasFlightPlan)
						{
							if (AssignedMissionOrPackage() != null && (AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Strike || (AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && AI.IsEscort)))
							{
								m_AttrVal = true;
							}
							else
							{
								m_AttrVal = false;
							}
						}
						if (m_AttrVal)
						{
							_VisitorVal = Kinematics.DesiredSpeedOverride;
							m_PrototypeVal = DesiredSpeed;
							_ExporterVal = Kinematics.DesiredAltitudeOverride;
							Kinematics.DesiredSpeedOverride = null;
							Kinematics.DesiredAltitudeOverride = false;
						}
					}
					else
					{
						switch (value)
						{
						default:
							if ((m_SchemaVal == _ActiveUnitStatus.HeadingToRefuelPoint && value != _ActiveUnitStatus.Refuelling) || m_SchemaVal == _ActiveUnitStatus.Refuelling)
							{
								if (queueVal.HasValue)
								{
									Kinematics.DesiredSpeedOverride = queueVal.Value;
									queueVal = null;
								}
								if (!IsGroupWingman() || Navigator.HasPlottedCourse())
								{
									if (AssignedMissionOrPackage() == null)
									{
										if (IsAircraft && (int)ThrottleSetting <= 2)
										{
											_TemplateVal = Throttle.Cruise;
										}
										SetThrottle(_TemplateVal, Kinematics.DesiredSpeedOverride);
										DesiredAltitude = _ItemVal;
										DesiredAltitude_AGL = setterVal;
										SetDesiredAltitude_UseTerrainFollowing(this, _CreatorVal);
									}
									else
									{
										if (AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
										{
											if (IsAircraft && IsOnActivePatrol)
											{
												((Aircraft_Navigator)Navigator).SetPatrolThrottle(bool_1: false, ((Aircraft)this).AirOps.Condition);
											}
										}
										else
										{
											if (IsAircraft && (int)ThrottleSetting <= 2)
											{
												_TemplateVal = Throttle.Cruise;
											}
											SetThrottle(_TemplateVal, Kinematics.DesiredSpeedOverride);
										}
										DesiredAltitude = _ItemVal;
										DesiredAltitude_AGL = setterVal;
										SetDesiredAltitude_UseTerrainFollowing(this, _CreatorVal);
									}
								}
								if (m_AttrVal && Navigator.HasFlightPlan && !Information.IsNothing(AssignedMissionOrPackage()) && (AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Strike || (AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && AI.IsEscort)))
								{
									Kinematics.DesiredSpeedOverride = _VisitorVal;
									if (!Information.IsNothing(_VisitorVal))
									{
										DesiredSpeed = m_PrototypeVal;
									}
									Kinematics.DesiredAltitudeOverride = _ExporterVal;
								}
								m_AttrVal = false;
							}
							else if (m_SchemaVal == _ActiveUnitStatus.EngagedDefensive)
							{
								if (queueVal.HasValue)
								{
									Kinematics.DesiredSpeedOverride = queueVal.Value;
									queueVal = null;
								}
								if (!IsGroupWingman() || Navigator.HasPlottedCourse())
								{
									SetThrottle(fieldVal, Kinematics.DesiredSpeedOverride);
									DesiredAltitude = m_MappingVal;
									if (m_MockVal.HasValue)
									{
										DesiredAltitude_AGL = m_MockVal.Value;
									}
									SetDesiredAltitude_UseTerrainFollowing(this, tagVal);
								}
								if (m_AttrVal && Navigator.HasFlightPlan && !Information.IsNothing(AssignedMissionOrPackage()) && (AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Strike || (AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && AI.IsEscort)))
								{
									Kinematics.DesiredSpeedOverride = _VisitorVal;
									if (!Information.IsNothing(_VisitorVal))
									{
										DesiredSpeed = m_PrototypeVal;
									}
									Kinematics.DesiredAltitudeOverride = _ExporterVal;
								}
								m_AttrVal = false;
							}
							else if (m_SchemaVal == _ActiveUnitStatus.EngagedOffensive)
							{
								if (queueVal.HasValue)
								{
									Kinematics.DesiredSpeedOverride = queueVal.Value;
									queueVal = null;
								}
								if (!IsGroupWingman() || Navigator.HasPlottedCourse())
								{
									SetThrottle(m_RulesVal, Kinematics.DesiredSpeedOverride);
									DesiredAltitude = regVal;
									DesiredAltitude_AGL = paramVal;
									SetDesiredAltitude_UseTerrainFollowing(this, m_PageVal);
								}
								if (m_AttrVal && Navigator.HasFlightPlan)
								{
									if (!Information.IsNothing(AssignedMissionOrPackage()) && (AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Strike || (AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && AI.IsEscort)))
									{
										Kinematics.DesiredSpeedOverride = _VisitorVal;
										if (!Information.IsNothing(_VisitorVal))
										{
											DesiredSpeed = m_PrototypeVal;
										}
										Kinematics.DesiredAltitudeOverride = _ExporterVal;
									}
									if (IsAircraft)
									{
										Aircraft aircraft = (Aircraft)this;
										Aircraft_AirOps._AirOpsCondition condition = aircraft.AirOps.Condition;
										if ((int)(condition - 19) <= 2 || condition == Aircraft_AirOps._AirOpsCondition.BVRDrag)
										{
											aircraft.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
										}
									}
								}
								m_AttrVal = false;
							}
							else
							{
								if (m_SchemaVal != _ActiveUnitStatus.WaitForPathfinder)
								{
									break;
								}
								if (queueVal.HasValue)
								{
									Kinematics.DesiredSpeedOverride = queueVal.Value;
									queueVal = null;
								}
								if (!IsGroupWingman() || Navigator.HasPlottedCourse())
								{
									SetThrottle(candidateVal, Kinematics.DesiredSpeedOverride);
									DesiredAltitude = _MethodVal;
									DesiredAltitude_AGL = serviceVal;
									SetDesiredAltitude_UseTerrainFollowing(this, m_SystemVal);
								}
								if (m_AttrVal && Navigator.HasFlightPlan && !Information.IsNothing(AssignedMissionOrPackage()) && (AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Strike || (AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && AI.IsEscort)))
								{
									Kinematics.DesiredSpeedOverride = _VisitorVal;
									if (!Information.IsNothing(_VisitorVal))
									{
										DesiredSpeed = m_PrototypeVal;
									}
									Kinematics.DesiredAltitudeOverride = _ExporterVal;
								}
								m_AttrVal = false;
							}
							break;
						case _ActiveUnitStatus.WaitForPathfinder:
							_ExceptionVal = _Status;
							if (m_SchemaVal == _ActiveUnitStatus.EngagedOffensive)
							{
								candidateVal = m_RulesVal;
								_MethodVal = regVal;
								serviceVal = paramVal;
								m_SystemVal = m_PageVal;
							}
							else if (m_SchemaVal == _ActiveUnitStatus.EngagedDefensive)
							{
								candidateVal = fieldVal;
								_MethodVal = m_MappingVal;
								if (m_MockVal.HasValue)
								{
									serviceVal = m_MockVal.Value;
								}
								m_SystemVal = tagVal;
							}
							else if (m_SchemaVal != _ActiveUnitStatus.HeadingToRefuelPoint && m_SchemaVal != _ActiveUnitStatus.Refuelling)
							{
								if (IsGroupWingman() && !Information.IsNothing(IsGroupLead()) && !Navigator.HasPlottedCourse())
								{
									if (GetParentGroup().GroupLead.Status == _ActiveUnitStatus.EngagedDefensive)
									{
										candidateVal = GetParentGroup().GroupLead.fieldVal;
									}
									else if (GetParentGroup().GroupLead.Status == _ActiveUnitStatus.EngagedOffensive)
									{
										candidateVal = GetParentGroup().GroupLead.m_RulesVal;
									}
									else if (GetParentGroup().GroupLead.Status == _ActiveUnitStatus.EngagedOffensive)
									{
										candidateVal = GetParentGroup().GroupLead.m_RulesVal;
									}
									else
									{
										candidateVal = GetParentGroup().GroupLead.ThrottleSetting;
									}
								}
								else
								{
									candidateVal = ThrottleSetting;
								}
								_MethodVal = DesiredAltitude;
								serviceVal = DesiredAltitude_AGL;
								m_SystemVal = GetDesiredAltitude_UseTerrainFollowing(this);
								if (IsAircraft)
								{
									if (!Information.IsNothing(AssignedMissionOrPackage()) && (AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Strike || (AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && AI.IsEscort)))
									{
										m_AttrVal = true;
									}
									else
									{
										m_AttrVal = false;
									}
								}
								if (m_AttrVal)
								{
									if (Navigator.NextWaypointIsManual)
									{
										m_AttrVal = false;
										break;
									}
									_VisitorVal = Kinematics.DesiredSpeedOverride;
									m_PrototypeVal = DesiredSpeed;
									_ExporterVal = Kinematics.DesiredAltitudeOverride;
									Kinematics.DesiredSpeedOverride = null;
									Kinematics.DesiredAltitudeOverride = false;
								}
							}
							else
							{
								candidateVal = _TemplateVal;
								_MethodVal = _ItemVal;
								serviceVal = setterVal;
								m_SystemVal = _CreatorVal;
							}
							break;
						case _ActiveUnitStatus.EngagedDefensive:
							_SingletonVal = _Status;
							queueVal = Kinematics.DesiredSpeedOverride;
							if (m_SchemaVal == _ActiveUnitStatus.EngagedOffensive)
							{
								fieldVal = m_RulesVal;
								m_MappingVal = regVal;
								m_MockVal = paramVal;
								tagVal = m_PageVal;
							}
							else if (m_SchemaVal == _ActiveUnitStatus.WaitForPathfinder)
							{
								fieldVal = candidateVal;
								m_MappingVal = _MethodVal;
								m_MockVal = serviceVal;
								tagVal = m_SystemVal;
							}
							else if (m_SchemaVal != _ActiveUnitStatus.HeadingToRefuelPoint && m_SchemaVal != _ActiveUnitStatus.Refuelling)
							{
								if (IsGroupWingman() && !IsGroupLead() && !Navigator.HasPlottedCourse())
								{
									if (GetParentGroup().GroupLead.Status == _ActiveUnitStatus.EngagedDefensive)
									{
										fieldVal = GetParentGroup().GroupLead.fieldVal;
									}
									else if (GetParentGroup().GroupLead.Status == _ActiveUnitStatus.EngagedOffensive)
									{
										fieldVal = GetParentGroup().GroupLead.m_RulesVal;
									}
									else if (GetParentGroup().GroupLead.Status == _ActiveUnitStatus.WaitForPathfinder)
									{
										fieldVal = GetParentGroup().GroupLead.candidateVal;
									}
									else
									{
										fieldVal = GetParentGroup().GroupLead.ThrottleSetting;
									}
								}
								else
								{
									fieldVal = ThrottleSetting;
								}
								m_MappingVal = DesiredAltitude;
								m_MockVal = DesiredAltitude_AGL;
								tagVal = GetDesiredAltitude_UseTerrainFollowing(this);
								if (IsAircraft)
								{
									if (AssignedMissionOrPackage() != null && (AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Strike || (AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && AI.IsEscort)))
									{
										m_AttrVal = true;
									}
									else
									{
										m_AttrVal = false;
									}
								}
								if (!m_AttrVal)
								{
									break;
								}
								if (Navigator.NextWaypointIsManual)
								{
									byte? b2 = (byte?)Doctrine.GetAutoEvade(ParentScen, bool_0: false, bool_1: false, bool_2: false);
									if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
									{
										m_AttrVal = false;
										break;
									}
								}
								_VisitorVal = Kinematics.DesiredSpeedOverride;
								m_PrototypeVal = DesiredSpeed;
								_ExporterVal = Kinematics.DesiredAltitudeOverride;
								Kinematics.DesiredSpeedOverride = null;
								Kinematics.DesiredAltitudeOverride = false;
							}
							else
							{
								fieldVal = _TemplateVal;
								m_MappingVal = _ItemVal;
								m_MockVal = setterVal;
								tagVal = _CreatorVal;
							}
							break;
						case _ActiveUnitStatus.EngagedOffensive:
							if (IsAircraft && Navigator.IsOnAutoPlannerPlottedCourse_HoldOrAssemble)
							{
								List<Waypoint> list = new List<Waypoint>();
								Waypoint[] plottedCourse = Navigator.PlottedCourse;
								Waypoint[] array = plottedCourse;
								foreach (Waypoint waypoint in array)
								{
									if (!waypoint.ConcatReponse())
									{
										break;
									}
									list.Add(waypoint);
								}
								foreach (Waypoint item in list)
								{
									ActiveUnit_Navigator navigator = Navigator;
									bool bool_ = true;
									bool bool_2 = false;
									navigator.CheckIfReachedWaypoint(0f, ref bool_, ref bool_2);
								}
							}
							_RecordVal = _Status;
							if (m_SchemaVal == _ActiveUnitStatus.EngagedDefensive)
							{
								m_RulesVal = fieldVal;
								regVal = m_MappingVal;
								if (m_MockVal.HasValue)
								{
									paramVal = m_MockVal.Value;
								}
								m_PageVal = tagVal;
							}
							else if (m_SchemaVal == _ActiveUnitStatus.WaitForPathfinder)
							{
								m_RulesVal = candidateVal;
								regVal = _MethodVal;
								paramVal = serviceVal;
								m_PageVal = m_SystemVal;
							}
							else if (m_SchemaVal != _ActiveUnitStatus.HeadingToRefuelPoint && m_SchemaVal != _ActiveUnitStatus.Refuelling)
							{
								if (IsGroupWingman() && !Information.IsNothing(IsGroupLead()) && !Navigator.HasPlottedCourse() && GetParentGroup().GroupLead != null)
								{
									if (GetParentGroup().GroupLead.Status == _ActiveUnitStatus.EngagedDefensive)
									{
										m_RulesVal = GetParentGroup().GroupLead.fieldVal;
									}
									else if (GetParentGroup().GroupLead.Status == _ActiveUnitStatus.EngagedOffensive)
									{
										m_RulesVal = GetParentGroup().GroupLead.m_RulesVal;
									}
									else if (GetParentGroup().GroupLead.Status == _ActiveUnitStatus.WaitForPathfinder)
									{
										m_RulesVal = GetParentGroup().GroupLead.candidateVal;
									}
									else
									{
										m_RulesVal = GetParentGroup().GroupLead.ThrottleSetting;
									}
								}
								else
								{
									m_RulesVal = ThrottleSetting;
								}
								regVal = DesiredAltitude;
								paramVal = DesiredAltitude_AGL;
								m_PageVal = GetDesiredAltitude_UseTerrainFollowing(this);
								if (IsAircraft)
								{
									if (!Information.IsNothing(AssignedMissionOrPackage()) && (AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Strike || (AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && AI.IsEscort)))
									{
										m_AttrVal = true;
									}
									else
									{
										m_AttrVal = false;
									}
								}
								if (!m_AttrVal)
								{
									break;
								}
								if (Navigator.NextWaypointIsManual)
								{
									byte? b = (byte?)Doctrine.GetIgnorePlottedCourse(ParentScen, bool_0: false, false, bool_1: false, bool_2: false);
									if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
									{
										m_AttrVal = false;
										break;
									}
								}
								_VisitorVal = Kinematics.DesiredSpeedOverride;
								m_PrototypeVal = DesiredSpeed;
								_ExporterVal = Kinematics.DesiredAltitudeOverride;
								Kinematics.DesiredSpeedOverride = null;
								Kinematics.DesiredAltitudeOverride = false;
							}
							else
							{
								m_RulesVal = _TemplateVal;
								regVal = _ItemVal;
								paramVal = setterVal;
								m_PageVal = _CreatorVal;
							}
							break;
						}
					}
				}
				if (configurationVal && (IsShip || IsSubmarine))
				{
					if (value == _ActiveUnitStatus.RTB && FuelState == _ActiveUnitFuelState.IsBingo && DockingOps.IsCurrentlyProvidingUNREP)
					{
						if (!string.IsNullOrEmpty(DockingOps.UNREP_Port_ReceiverUnitID))
						{
							ActiveUnit activeUnit = ParentScen.ActiveUnits[DockingOps.UNREP_Port_ReceiverUnitID];
							if (!Information.IsNothing(activeUnit) && !activeUnit.IsDestroyed)
							{
								activeUnit.DockingOps.DisconnectFromSupplier();
							}
						}
						if (!string.IsNullOrEmpty(DockingOps.UNREP_Starboard_ReceiverUnitID))
						{
							ActiveUnit activeUnit2 = ParentScen.ActiveUnits[DockingOps.UNREP_Starboard_ReceiverUnitID];
							if (!Information.IsNothing(activeUnit2) && !activeUnit2.IsDestroyed)
							{
								activeUnit2.DockingOps.DisconnectFromSupplier();
							}
						}
						if (!string.IsNullOrEmpty(DockingOps.UNREP_Astern_ReceiverUnitID))
						{
							ActiveUnit activeUnit3 = ParentScen.ActiveUnits[DockingOps.UNREP_Astern_ReceiverUnitID];
							if (!Information.IsNothing(activeUnit3) && !activeUnit3.IsDestroyed)
							{
								activeUnit3.DockingOps.DisconnectFromSupplier();
							}
						}
					}
					switch (value)
					{
					case _ActiveUnitStatus.Unassigned:
					case _ActiveUnitStatus.RTB:
					case _ActiveUnitStatus.RTB_Manual:
					case _ActiveUnitStatus.RTB_MissionOver:
					case _ActiveUnitStatus.RTB_Group:
					case _ActiveUnitStatus.RTB_CalledOff:
					case _ActiveUnitStatus.RTB_Exhaustion:
						if (m_SchemaVal == _ActiveUnitStatus.Refuelling || DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Replenishing)
						{
							DockingOps.DisconnectFromSupplier();
						}
						break;
					}
				}
				if (configurationVal && m_SchemaVal == _ActiveUnitStatus.EngagedOffensive && (value == _ActiveUnitStatus.OnPatrol || value == _ActiveUnitStatus.OnPlottedCourse || value == _ActiveUnitStatus.Tasked || value == _ActiveUnitStatus.Unassigned || value == _ActiveUnitStatus.RTB_CalledOff) && m_SchemaVal == _Status && IsAircraft && (Navigator.IsOnAutoPlannerPlottedCourse_StationIngressRun || (!Information.IsNothing(AssignedMissionOrPackage()) && AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && AI.IsEscort && Navigator.IsOnAutoPlannerPlottedCourse)))
				{
					_Status = value;
					Aircraft_AirOps airOps = ((Aircraft)this).AirOps;
					List<Waypoint> list_ = Navigator.PlottedCourse.ToList();
					airOps.SwitchToNearestWaypoint(ref list_, bool_0: false, bool_1: false);
				}
				if (configurationVal)
				{
					Kinematics.PerformOutOfSequenceExportLocation = true;
				}
				_Status = value;
				if (IsRTB && !IsAircraft && IsGroupMember())
				{
					SetParentGroup(bool_0: false, null);
				}
				if (Navigator.HasFlightPlan && !IsRTB && Navigator.PlottedCourse.Count() > 0 && !Navigator.HasPathfindingPlottedCourse && Navigator.PlottedCourse[0].Category != Waypoint.WaypointCategory.FlightPlan)
				{
					Navigator.ClearPlottedCourse();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 1234546744567", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public _ActiveUnitStatus StatusBeforeNeedToRefuel => predicateVal;

	public virtual _ActiveUnitFuelState FuelState
	{
		get
		{
			return _FuelState;
		}
		set
		{
			_FuelState = value;
		}
	}

	public virtual _ActiveUnitWeaponState WeaponState
	{
		get
		{
			return _WeaponState;
		}
		set
		{
			_WeaponState = value;
		}
	}

	public bool IsRTB
	{
		get
		{
			switch (Status)
			{
			default:
				return false;
			case _ActiveUnitStatus.RTB:
			case _ActiveUnitStatus.RTB_Manual:
			case _ActiveUnitStatus.RTB_MissionOver:
			case _ActiveUnitStatus.RTB_Group:
			case _ActiveUnitStatus.RTB_CalledOff:
			case _ActiveUnitStatus.RTB_Exhaustion:
				return true;
			}
		}
	}

	public bool IsRTB_Or_CalledOff
	{
		get
		{
			switch (Status)
			{
			default:
				return false;
			case _ActiveUnitStatus.RTB:
			case _ActiveUnitStatus.RTB_Manual:
			case _ActiveUnitStatus.RTB_MissionOver:
			case _ActiveUnitStatus.RTB_Group:
			case _ActiveUnitStatus.RTB_CalledOff:
			case _ActiveUnitStatus.RTB_Exhaustion:
				return true;
			}
		}
	}

	public virtual int FuelCapacityMax
	{
		get
		{
			int num = 0;
			foreach (FuelRec item in Fuel_ReadOnly)
			{
				num += item.MaxQuantity;
			}
			return num;
		}
	}

	public virtual int FuelCapacityCurrent
	{
		get
		{
			int num = 0;
			foreach (FuelRec item in Fuel_ReadOnly)
			{
				num = (int)Math.Round((float)num + item.CurrentQuantity);
			}
			return num;
		}
	}

	public bool isUAV
	{
		get
		{
			if (IsWeapon)
			{
				Weapon weapon = (Weapon)this;
				if (weapon.Type == Weapon._WeaponType.UAV_Expendable)
				{
					return true;
				}
				if (weapon.isLoiterCapable)
				{
					return true;
				}
			}
			else if (IsAircraft && ((Aircraft)this).Crew == 0)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsMobileDecoy
	{
		get
		{
			if (!IsMobileDecoy_Air && !IsMobileDecoy_Surface)
			{
				return IsMobileDecoy_Sub;
			}
			return true;
		}
	}

	public bool IsMobileDecoy_Air
	{
		get
		{
			if (IsWeapon)
			{
				Weapon weapon = (Weapon)this;
				if (weapon.Type == Weapon._WeaponType.Decoy_Vehicle && weapon.Kinematics.GetMaximumAltitude() > 0f)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool IsMobileDecoy_Surface
	{
		get
		{
			if (IsWeapon)
			{
				Weapon weapon = (Weapon)this;
				if (weapon.Type == Weapon._WeaponType.Decoy_Vehicle && weapon.Kinematics.GetMaximumAltitude() == 0f && weapon.Kinematics.GetMinimumAltitude() == 0f)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool IsMobileDecoy_Sub
	{
		get
		{
			if (IsWeapon)
			{
				Weapon weapon = (Weapon)this;
				if (weapon.Type == Weapon._WeaponType.Decoy_Vehicle && weapon.Kinematics.GetMinimumAltitude() < 0f)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool IsPalletWeapon
	{
		get
		{
			if (IsWeapon)
			{
				return ((Weapon)this).Type == Weapon._WeaponType.PalletWeapon;
			}
			return false;
		}
	}

	public override bool IsPlatform => (object)GetType().BaseType == typeof(Platform);

	public Magazine[] TotalMagazines
	{
		get
		{
			if (Mounts == null)
			{
				return SharedMagazines;
			}
			List<Magazine> list = new List<Magazine>();
			list.AddRange(SharedMagazines);
			foreach (Mount mount in Mounts)
			{
				if (mount.MountMagazine != null)
				{
					list.Add(mount.MountMagazine);
				}
			}
			return list.ToArray();
		}
	}

	public virtual Magazine[] SharedMagazines
	{
		get
		{
			if (IsPlatform)
			{
				return ((Platform)this).Magazines;
			}
			if (IsGroup)
			{
				return ((Group)this).SharedMagazines;
			}
			return null;
		}
	}

	public virtual bool IsCivilian
	{
		get
		{
			if ((uint)(OperatorCountryCode - 1101) <= 1u)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsPaintingATarget => (from theS in Sensors_ReadOnly()
		where theS.TargetsTrackedForFireControl_Readonly.Count > 0 || theS.SemiActiveWeaponsGuided.Count > 0
		select theS).Count() > 0;

	public bool WillNeedToPaintATarget
	{
		get
		{
			if (ParentScen.GuidedWeaponsInAir.Count == 0)
			{
				return false;
			}
			return ParentScen.GuidedWeaponsInAir.Where((Weapon weapon_0) => weapon_0.FiringParent == this && weapon_0.Flags.TerminalIllumination).Count() > 0;
		}
	}

	public Contact ClosestWeaponTarget
	{
		get
		{
			if (ParentScen.GuidedWeaponsInAir.Count == 0)
			{
				return null;
			}
			IEnumerable<Weapon> source = from weapon_0 in ParentScen.GuidedWeaponsInAir
				where weapon_0.FiringParent == this && (weapon_0.Flags.TerminalIllumination || weapon_0.Flags.IlluminateAtLaunch) && weapon_0.AI.PrimaryTarget != null
				orderby Module_Unit.RangeToUnit_Horiz_Angular(this, weapon_0)
				select weapon_0;
			if (source.Count() <= 0)
			{
				return null;
			}
			return source.ElementAtOrDefault(0).AI.PrimaryTarget;
		}
	}

	public GlobalVariables.UnitNoiseLevelClass NoiseLevelClass
	{
		get
		{
			XSection xSection = Sensor.smethod_0(this, XSection._SignatureType.HullSonar_PassiveOnly_VLF);
			if (xSection == null)
			{
				xSection = Sensor.smethod_0(this, XSection._SignatureType.HullSonar_PassiveOnly_VLF);
			}
			if (xSection == null)
			{
				return GlobalVariables.UnitNoiseLevelClass.Quiet;
			}
			float rear = xSection.GetRear(this);
			if (rear < 100f)
			{
				return GlobalVariables.UnitNoiseLevelClass.ExQuiet;
			}
			if (rear < 120f)
			{
				return GlobalVariables.UnitNoiseLevelClass.VQuiet;
			}
			if (rear < 130f)
			{
				return GlobalVariables.UnitNoiseLevelClass.Quiet;
			}
			if (rear < 140f)
			{
				return GlobalVariables.UnitNoiseLevelClass.Noisy;
			}
			return GlobalVariables.UnitNoiseLevelClass.Loud;
		}
	}

	public virtual GlobalVariables.TargetVisualSizeClass VisualSizeClass
	{
		get
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new NotImplementedException();
		}
	}

	public virtual float Fuel_FreeLoad
	{
		get
		{
			float result = 0f;
			try
			{
				FuelRec fuelRec = Fuel_ReadOnly[0];
				result = (float)fuelRec.MaxQuantity - fuelRec.CurrentQuantity;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100006", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public bool HasRunwaysOrPads
	{
		get
		{
			AirFacility[] airFacilities_ReadOnly = AirFacilities_ReadOnly;
			int num = 0;
			while (true)
			{
				if (num < airFacilities_ReadOnly.Length)
				{
					if (airFacilities_ReadOnly[num].DefineReader())
					{
						break;
					}
					num = checked(num + 1);
					continue;
				}
				return false;
			}
			return true;
		}
	}

	public bool HasAirFacilities
	{
		get
		{
			if (AirFacilities_ReadOnly != null && AirFacilities_ReadOnly.Length != 0)
			{
				return true;
			}
			return false;
		}
	}

	public bool HasCargo => OnboardCargo.Count() != 0;

	public bool HasDockFacilities
	{
		get
		{
			if (DockFacilities_ReadOnly != null && DockFacilities_ReadOnly.Length != 0)
			{
				return true;
			}
			return false;
		}
	}

	public bool HasRadarSensor
	{
		get
		{
			bool result = false;
			try
			{
				List<Sensor> list = new List<Sensor>(Sensors_Cached);
				int num = list.Count - 1;
				int num2 = 0;
				while (true)
				{
					if (num2 <= num)
					{
						if (list[num2].Type == Sensor.Sensor_Type.Radar)
						{
							break;
						}
						num2++;
						continue;
					}
					if (IsWeapon)
					{
						Weapon weapon = (Weapon)this;
						Warhead[] warheads = weapon.Warheads;
						Warhead[] array = warheads;
						foreach (Warhead warhead in array)
						{
							if (warhead.Type != Warhead.WarheadType.Weapon)
							{
								continue;
							}
							List<Sensor> list2 = new List<Sensor>(warhead.GetCarriedWeapon(weapon.ParentScen).Sensors_Cached);
							int num3 = list2.Count - 1;
							for (int i = 0; i <= num3; i++)
							{
								if (list2[i].Type == Sensor.Sensor_Type.Radar)
								{
									result = true;
									return true;
								}
							}
						}
					}
					result = false;
					return false;
				}
				result = true;
				return true;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100014", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public bool HasSonarSensor
	{
		get
		{
			bool result = false;
			try
			{
				List<Sensor> list = new List<Sensor>();
				list.AddRange(Sensors_Cached);
				int num = list.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (list[i].IsSonar)
					{
						result = true;
						return true;
					}
				}
				if (IsWeapon)
				{
					Weapon weapon = (Weapon)this;
					Warhead[] warheads = weapon.Warheads;
					Warhead[] array = warheads;
					foreach (Warhead warhead in array)
					{
						if (warhead.Type != Warhead.WarheadType.Weapon)
						{
							continue;
						}
						Weapon carriedWeapon = warhead.GetCarriedWeapon(weapon.ParentScen);
						List<Sensor> list2 = new List<Sensor>();
						list2.AddRange(carriedWeapon.Sensors_Cached);
						int num2 = list2.Count - 1;
						for (int j = 0; j <= num2; j++)
						{
							if (list2[j].IsSonar)
							{
								result = true;
								return true;
							}
						}
					}
				}
				result = false;
				return false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100014", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public bool HasOECMSensor
	{
		get
		{
			bool result = false;
			try
			{
				List<Sensor> list = new List<Sensor>();
				list.AddRange(Sensors_Cached);
				int num = list.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (list[i].IsOECM)
					{
						result = true;
						return true;
					}
				}
				if (IsWeapon)
				{
					Weapon weapon = (Weapon)this;
					Warhead[] warheads = weapon.Warheads;
					Warhead[] array = warheads;
					foreach (Warhead warhead in array)
					{
						if (warhead.Type != Warhead.WarheadType.Weapon)
						{
							continue;
						}
						Weapon carriedWeapon = warhead.GetCarriedWeapon(weapon.ParentScen);
						List<Sensor> list2 = new List<Sensor>();
						list2.AddRange(carriedWeapon.Sensors_Cached);
						int num2 = list2.Count - 1;
						for (int j = 0; j <= num2; j++)
						{
							if (list2[j].IsOECM)
							{
								result = true;
								return true;
							}
						}
					}
				}
				result = false;
				return false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100014", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public bool HasInfraredSensor
	{
		get
		{
			bool result = false;
			try
			{
				List<Sensor> list = new List<Sensor>();
				list.AddRange(Sensors_Cached);
				int num = list.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (list[i].Type == Sensor.Sensor_Type.Infrared)
					{
						result = true;
						return true;
					}
				}
				result = false;
				return false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100015", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public bool HasLaserSpotTracker
	{
		get
		{
			bool result = false;
			try
			{
				List<Sensor> list = new List<Sensor>();
				list.AddRange(Sensors_Cached);
				int num = list.Count - 1;
				int num2 = 0;
				while (true)
				{
					if (num2 <= num)
					{
						if (list[num2].Type == Sensor.Sensor_Type.LaserSpotTracker)
						{
							break;
						}
						num2++;
						continue;
					}
					result = false;
					return false;
				}
				result = true;
				return true;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100015", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public static event ChangedThrottleSettingEventHandler ChangedThrottleSetting
	{
		[CompilerGenerated]
		add
		{
			ChangedThrottleSettingEventHandler changedThrottleSettingEventHandler = databaseVal;
			ChangedThrottleSettingEventHandler changedThrottleSettingEventHandler2;
			do
			{
				changedThrottleSettingEventHandler2 = changedThrottleSettingEventHandler;
				ChangedThrottleSettingEventHandler value2 = (ChangedThrottleSettingEventHandler)Delegate.Combine(changedThrottleSettingEventHandler2, value);
				changedThrottleSettingEventHandler = Interlocked.CompareExchange(ref databaseVal, value2, changedThrottleSettingEventHandler2);
			}
			while ((object)changedThrottleSettingEventHandler != changedThrottleSettingEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ChangedThrottleSettingEventHandler changedThrottleSettingEventHandler = databaseVal;
			ChangedThrottleSettingEventHandler changedThrottleSettingEventHandler2;
			do
			{
				changedThrottleSettingEventHandler2 = changedThrottleSettingEventHandler;
				ChangedThrottleSettingEventHandler value2 = (ChangedThrottleSettingEventHandler)Delegate.Remove(changedThrottleSettingEventHandler2, value);
				changedThrottleSettingEventHandler = Interlocked.CompareExchange(ref databaseVal, value2, changedThrottleSettingEventHandler2);
			}
			while ((object)changedThrottleSettingEventHandler != changedThrottleSettingEventHandler2);
		}
	}

	public static event ParentGroupChangedEventHandler ParentGroupChanged
	{
		[CompilerGenerated]
		add
		{
			ParentGroupChangedEventHandler parentGroupChangedEventHandler = m_InterceptorVal;
			ParentGroupChangedEventHandler parentGroupChangedEventHandler2;
			do
			{
				parentGroupChangedEventHandler2 = parentGroupChangedEventHandler;
				ParentGroupChangedEventHandler value2 = (ParentGroupChangedEventHandler)Delegate.Combine(parentGroupChangedEventHandler2, value);
				parentGroupChangedEventHandler = Interlocked.CompareExchange(ref m_InterceptorVal, value2, parentGroupChangedEventHandler2);
			}
			while ((object)parentGroupChangedEventHandler != parentGroupChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ParentGroupChangedEventHandler parentGroupChangedEventHandler = m_InterceptorVal;
			ParentGroupChangedEventHandler parentGroupChangedEventHandler2;
			do
			{
				parentGroupChangedEventHandler2 = parentGroupChangedEventHandler;
				ParentGroupChangedEventHandler value2 = (ParentGroupChangedEventHandler)Delegate.Remove(parentGroupChangedEventHandler2, value);
				parentGroupChangedEventHandler = Interlocked.CompareExchange(ref m_InterceptorVal, value2, parentGroupChangedEventHandler2);
			}
			while ((object)parentGroupChangedEventHandler != parentGroupChangedEventHandler2);
		}
	}

	public static event NameChangedEventHandler NameChanged
	{
		[CompilerGenerated]
		add
		{
			NameChangedEventHandler nameChangedEventHandler = messageVal;
			NameChangedEventHandler nameChangedEventHandler2;
			do
			{
				nameChangedEventHandler2 = nameChangedEventHandler;
				NameChangedEventHandler value2 = (NameChangedEventHandler)Delegate.Combine(nameChangedEventHandler2, value);
				nameChangedEventHandler = Interlocked.CompareExchange(ref messageVal, value2, nameChangedEventHandler2);
			}
			while ((object)nameChangedEventHandler != nameChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			NameChangedEventHandler nameChangedEventHandler = messageVal;
			NameChangedEventHandler nameChangedEventHandler2;
			do
			{
				nameChangedEventHandler2 = nameChangedEventHandler;
				NameChangedEventHandler value2 = (NameChangedEventHandler)Delegate.Remove(nameChangedEventHandler2, value);
				nameChangedEventHandler = Interlocked.CompareExchange(ref messageVal, value2, nameChangedEventHandler2);
			}
			while ((object)nameChangedEventHandler != nameChangedEventHandler2);
		}
	}

	public static event ActiveUnitMountsAddedEventHandler ActiveUnitMountsAdded
	{
		[CompilerGenerated]
		add
		{
			ActiveUnitMountsAddedEventHandler activeUnitMountsAddedEventHandler = productVal;
			ActiveUnitMountsAddedEventHandler activeUnitMountsAddedEventHandler2;
			do
			{
				activeUnitMountsAddedEventHandler2 = activeUnitMountsAddedEventHandler;
				ActiveUnitMountsAddedEventHandler value2 = (ActiveUnitMountsAddedEventHandler)Delegate.Combine(activeUnitMountsAddedEventHandler2, value);
				activeUnitMountsAddedEventHandler = Interlocked.CompareExchange(ref productVal, value2, activeUnitMountsAddedEventHandler2);
			}
			while ((object)activeUnitMountsAddedEventHandler != activeUnitMountsAddedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ActiveUnitMountsAddedEventHandler activeUnitMountsAddedEventHandler = productVal;
			ActiveUnitMountsAddedEventHandler activeUnitMountsAddedEventHandler2;
			do
			{
				activeUnitMountsAddedEventHandler2 = activeUnitMountsAddedEventHandler;
				ActiveUnitMountsAddedEventHandler value2 = (ActiveUnitMountsAddedEventHandler)Delegate.Remove(activeUnitMountsAddedEventHandler2, value);
				activeUnitMountsAddedEventHandler = Interlocked.CompareExchange(ref productVal, value2, activeUnitMountsAddedEventHandler2);
			}
			while ((object)activeUnitMountsAddedEventHandler != activeUnitMountsAddedEventHandler2);
		}
	}

	public static event ActiveUnitMountsRemovedEventHandler ActiveUnitMountsRemoved
	{
		[CompilerGenerated]
		add
		{
			ActiveUnitMountsRemovedEventHandler activeUnitMountsRemovedEventHandler = _AnnotationVal;
			ActiveUnitMountsRemovedEventHandler activeUnitMountsRemovedEventHandler2;
			do
			{
				activeUnitMountsRemovedEventHandler2 = activeUnitMountsRemovedEventHandler;
				ActiveUnitMountsRemovedEventHandler value2 = (ActiveUnitMountsRemovedEventHandler)Delegate.Combine(activeUnitMountsRemovedEventHandler2, value);
				activeUnitMountsRemovedEventHandler = Interlocked.CompareExchange(ref _AnnotationVal, value2, activeUnitMountsRemovedEventHandler2);
			}
			while ((object)activeUnitMountsRemovedEventHandler != activeUnitMountsRemovedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ActiveUnitMountsRemovedEventHandler activeUnitMountsRemovedEventHandler = _AnnotationVal;
			ActiveUnitMountsRemovedEventHandler activeUnitMountsRemovedEventHandler2;
			do
			{
				activeUnitMountsRemovedEventHandler2 = activeUnitMountsRemovedEventHandler;
				ActiveUnitMountsRemovedEventHandler value2 = (ActiveUnitMountsRemovedEventHandler)Delegate.Remove(activeUnitMountsRemovedEventHandler2, value);
				activeUnitMountsRemovedEventHandler = Interlocked.CompareExchange(ref _AnnotationVal, value2, activeUnitMountsRemovedEventHandler2);
			}
			while ((object)activeUnitMountsRemovedEventHandler != activeUnitMountsRemovedEventHandler2);
		}
	}

	static ActiveUnit()
	{
		WEAPON_TOT_ACCEPTABLE_ERROR = 10f;
		FP_RECALC_THREASHOLD = 300f;
	}

	public void ToggleUnitAsDecoyForCurrentSide(string string_0)
	{
		if (composerVal.Contains(string_0))
		{
			composerVal.Remove(string_0);
		}
		else
		{
			composerVal.Add(string_0);
		}
	}

	[SpecialName]
	public bool GetisTaggedAsDecoyByThisSide(string string_0)
	{
		if (composerVal.Contains(string_0))
		{
			return true;
		}
		return false;
	}

	public virtual void ReleaseReferences()
	{
		try
		{
			ParentScen = null;
			_UnitSide = null;
			if (IsGroup)
			{
				((Group)this).Units = null;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public virtual bool IsExhausted()
	{
		return false;
	}

	public void AddNewJourneyWaypoint()
	{
		if (IsStoringJourney)
		{
			Journey.AddWaypoint(new TravelWaypoint(new Geopoint_Struct(GetLongitude(), GetLatitude(), GetCurrentAltitude()), ParentScen.Time, CurrentSpeed, CurrentHeading));
		}
	}

	public virtual float Attitude_Pitch_Derived()
	{
		float num = GetCurrentAltitude() - base.Altitude_old;
		if (num == 0f)
		{
			return 0f;
		}
		double x = (double)Math2.VerifyClass(GetLatitude(), GetLongitude(), Latitude_old, Longitude_old) * 1852.0;
		double num2 = Math.Atan2(Math.Abs(num), x) * 57.2957795130823;
		if (num <= 0f)
		{
			return 0f - (float)num2;
		}
		return (float)num2;
	}

	public short OODA_Targeting_Actual()
	{
		GlobalVariables.ProficiencyLevel? proficiency = Proficiency;
		int? num = (int?)proficiency;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
		{
			return (short)(_IndexerVal * 2);
		}
		num = (int?)proficiency;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
		{
			return (short)Math.Round((double)_IndexerVal * 1.5);
		}
		num = (int?)proficiency;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			return (short)Math.Round((double)_IndexerVal * 1.2);
		}
		num = (int?)proficiency;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
		{
			return _IndexerVal;
		}
		num = (int?)proficiency;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
		{
			return (short)Math.Round((double)_IndexerVal * 0.8);
		}
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		return 0;
	}

	[SpecialName]
	public override double GetLongitude(bool? nullable_0 = null)
	{
		if (nullable_0.HasValue ? nullable_0.Value : IsOperating())
		{
			return base.GetLongitude();
		}
		ActiveUnit currentHostUnit = DockingOps.CurrentHostUnit;
		if (currentHostUnit == null)
		{
			if (!IsBeingDestroyed)
			{
				_ = Debugger.IsAttached;
			}
			return 0.0;
		}
		return currentHostUnit.GetLongitude();
	}

	[SpecialName]
	public override void SetLongitude(bool? nullable_0, double double_0)
	{
		base.SetLongitude(null, double_0);
		DockingOps.ResetPierEntranceLaneCache();
	}

	[SpecialName]
	public override double GetLatitude(bool? nullable_0 = null)
	{
		if (nullable_0.HasValue ? nullable_0.Value : IsOperating())
		{
			return base.GetLatitude();
		}
		ActiveUnit currentHostUnit = DockingOps.CurrentHostUnit;
		if (currentHostUnit == null)
		{
			if (!IsBeingDestroyed)
			{
				_ = Debugger.IsAttached;
			}
			return 0.0;
		}
		return currentHostUnit.GetLatitude();
	}

	[SpecialName]
	public override void SetLatitude(bool? nullable_0, double double_0)
	{
		base.SetLatitude(null, double_0);
		DockingOps.ResetPierEntranceLaneCache();
	}

	[SpecialName]
	public bool GetIsEligibleForAutodetection(Side side_0)
	{
		if (GetIsAutoDetectable(side_0))
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	public virtual _ActiveUnitFuelState GetIsBingoOrJoker(GeoPoint geoPoint_0, Doctrine._FuelState? nullable_0)
	{
		return _ActiveUnitFuelState.None;
	}

	[SpecialName]
	public virtual _ActiveUnitFuelState GetIsBingoTowardsThisDestination(ActiveUnit activeUnit_0, GeoPoint geoPoint_0, Doctrine._FuelState? nullable_0)
	{
		_ActiveUnitFuelState result = _ActiveUnitFuelState.None;
		try
		{
			if (GetFuelEndurance(Throttle.Cruise, null, null, null) <= 900)
			{
				result = _ActiveUnitFuelState.IsBingo;
				return _ActiveUnitFuelState.IsBingo;
			}
			float num;
			if (geoPoint_0 == null)
			{
				num = Module_Unit.RangeToUnit_Horiz(this, activeUnit_0);
			}
			else
			{
				float num2 = Module_Unit.RangeToPoint_Horiz(activeUnit_0, geoPoint_0);
				num = Module_Unit.RangeToPoint_Horiz(this, geoPoint_0) + num2;
			}
			if ((double)Kinematics.MaxRange(bool_0: true, null, null) < (double)num * 1.1)
			{
				result = _ActiveUnitFuelState.IsBingo;
				return _ActiveUnitFuelState.IsBingo;
			}
			result = _ActiveUnitFuelState.None;
			return _ActiveUnitFuelState.None;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101183", "");
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
	public virtual float GetDamagePts(bool bool_0 = false, Weapon weapon_0 = null)
	{
		return m_StatusVal;
	}

	[SpecialName]
	public virtual void SetDamagePts(bool bool_0, Weapon weapon_0, float float_0)
	{
		try
		{
			bool flag = m_StatusVal != float_0;
			float damagePercent = Damage.DamagePercent;
			float statusVal = m_StatusVal;
			if (IsFacility && AirFacilities_ReadOnly != null && AirFacilities_ReadOnly.Where((AirFacility AF) => AF.IsOpenAirFacility).Any() && 0f - float_0 < (float)(InitialDP * 100))
			{
				float_0 = Math.Max(1f, float_0);
			}
			m_StatusVal = float_0;
			float damagePercent2 = Damage.DamagePercent;
			if (!bool_0)
			{
				if (m_StatusVal <= 0f && m_StatusVal != statusVal)
				{
					if (IsShip)
					{
						if (!IsBeingDestroyed)
						{
							((Ship)this).CommenceSinking(damagePercent);
						}
					}
					else
					{
						ParentScen.DestroyThisUnit(this, "单元已遭受结构性损伤。", "Weapon Interaction");
					}
				}
				if ((!IsShip || !((Ship)this).IsSinking) && (flag || damagePercent != damagePercent2) && float_0 < statusVal)
				{
					if (ParentScen.EventTriggers.Count > 0)
					{
						List<EventTrigger> list = new List<EventTrigger>();
						foreach (EventTrigger value in ParentScen.EventTriggers.Values)
						{
							if (value.Type == EventTrigger.EventTriggerType.UnitDamaged && ((EventTrigger_UnitDamaged)value).GetIsFulfilled(this, damagePercent, damagePercent2, weapon_0))
							{
								list.Add(value);
							}
						}
						ParentScen.FireEvents(list);
					}
					utilsVal = damagePercent2;
				}
			}
			Kinematics.PerformOutOfSequenceExportLocation = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101184", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal AirContrailSize FlushIssuer()
	{
		if (GetCurrentAltitude() < 8000f)
		{
			return AirContrailSize.NoContrail;
		}
		if (IsWeapon)
		{
			if (Propulsion.Count <= 0)
			{
				return AirContrailSize.NoContrail;
			}
			switch (Propulsion[0].Type)
			{
			case Engine.EngineType.None:
			case Engine.EngineType.Nuclear:
			case Engine.EngineType.Electric:
			case Engine.EngineType.WeaponCoast:
				return AirContrailSize.NoContrail;
			}
			if (((Weapon)this).UsesBoostCoastModel.Value && ((Weapon)this).TimeSinceBurnout > 0f)
			{
				return AirContrailSize.NoContrail;
			}
		}
		if (Weather.VisitDescriptor(Weather.TAtmosphereType.atm_ITU_R_Ref_Std, (int)Math.Round(GetCurrentAltitude())).Temperature > 233.0)
		{
			return AirContrailSize.NoContrail;
		}
		switch (VisualSizeClass)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new NotImplementedException();
		case GlobalVariables.TargetVisualSizeClass.Stealthy:
			return AirContrailSize.NoContrail;
		case GlobalVariables.TargetVisualSizeClass.VSmall:
			return AirContrailSize.VSmall;
		case GlobalVariables.TargetVisualSizeClass.Small:
			return AirContrailSize.Small;
		case GlobalVariables.TargetVisualSizeClass.Medium:
			return AirContrailSize.Medium;
		case GlobalVariables.TargetVisualSizeClass.Large:
			return AirContrailSize.Large;
		case GlobalVariables.TargetVisualSizeClass.VLarge:
			return AirContrailSize.VLarge;
		}
	}

	[SpecialName]
	public bool GetIsSpecificTargetForThisStrike(Strike strike_0)
	{
		if (strike_0.TargetCount == 0)
		{
			return false;
		}
		if (strike_0.SpecificTargets.Contains(this))
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	public override float GetCurrentAltitude(bool bool_0 = false)
	{
		return base.GetCurrentAltitude();
	}

	[SpecialName]
	public override void SetCurrentAltitude(bool bool_0, float float_0)
	{
		if (bool_0)
		{
			float maximumAltitude = Kinematics.GetMaximumAltitude();
			float num = Kinematics.GetMinimumAltitude();
			if (IsWeapon && ((Weapon)this).Type == Weapon._WeaponType.Sonobuoy)
			{
				num = GetLandElevation(bool_0: false, bool_1: false, bool_2: false, ParentScen);
			}
			if (IsWeapon && ((Weapon)this).Type == Weapon._WeaponType.PalletWeapon)
			{
				base.SetCurrentAltitude(bool_0: false, float_0);
				return;
			}
			if (float_0 > maximumAltitude)
			{
				float_0 = maximumAltitude;
			}
			if (float_0 < num)
			{
				float_0 = num;
			}
		}
		if (float_0 != GetCurrentAltitude() && IsSubmarine)
		{
			((Submarine)this).PrimaryEngine = null;
		}
		base.SetCurrentAltitude(bool_0: false, float_0);
	}

	[SpecialName]
	public override Side GetUnitSide(bool bool_0 = false)
	{
		if (_UnitSide == null)
		{
			Side[] sides_ReadOnly = ParentScen.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side in array)
			{
				if (string.CompareOrdinal(side.Name, _SideName) == 0)
				{
					SetUnitSide(bool_0: true, side);
					break;
				}
			}
		}
		return _UnitSide;
	}

	[SpecialName]
	public override void SetUnitSide(bool bool_0, Side side_0)
	{
		try
		{
			if (side_0 == _UnitSide)
			{
				return;
			}
			if (!bool_0)
			{
				if (_UnitSide != null)
				{
					_UnitSide.Units.Remove(this);
					if (IsGroupMember() && GetParentGroup().GetUnitSide() != side_0)
					{
						GetParentGroup().Units.Remove(new KeyValuePair<string, ActiveUnit>(ObjectID, this));
						SetParentGroup(bool_0: false, null);
					}
					if (AssignedMissionOrPackage() != null)
					{
						Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
						Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
					}
					ActiveUnit_AI aI = AI;
					ActiveUnit activeUnit_ = this;
					aI.ClearAllTargets(ref activeUnit_);
					AI.ClearAllThreats();
				}
				if (side_0 != null)
				{
					lock (side_0.Units)
					{
						side_0.Units.Add(this);
					}
				}
			}
			_UnitSide = side_0;
			_SideName = _UnitSide.Name;
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

	[SpecialName]
	public virtual Group GetParentGroup(bool bool_0 = false)
	{
		return _ParentGroup;
	}

	[SpecialName]
	public virtual void SetParentGroup(bool bool_0, Group group_0)
	{
		bool flag;
		if (flag = group_0 != _ParentGroup)
		{
			_ParentGroup?.Units.Remove(ObjectID);
			_ParentGroup = group_0;
			group_0?.Units.Add(ObjectID, this);
			if (group_0 != null && group_0.ParentScen == null)
			{
				group_0.ParentScen = ParentScen;
			}
			if (!bool_0 && flag && group_0 != null && !IsGroupLead())
			{
				Navigator.ClearPlottedCourse();
				Navigator.CalculateFormationStationRelativeData(GetLongitude(), GetLatitude(), bool_1: false);
				Navigator.ClearFlight();
			}
			if (flag)
			{
				m_InterceptorVal?.Invoke(ObjectID);
			}
			if (group_0 == null)
			{
				Navigator.UnitFormationStation = null;
			}
		}
	}

	[SpecialName]
	public virtual void SetDesiredHeading(TurnRate turnRate_0, float float_0)
	{
		if (float.IsNaN(float_0))
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		else
		{
			_DesiredHeading = float_0;
			DesiredTurnRate = turnRate_0;
		}
	}

	[SpecialName]
	public virtual bool GetDesiredAltitude_UseTerrainFollowing(ActiveUnit activeUnit_0)
	{
		return false;
	}

	[SpecialName]
	public virtual void SetDesiredAltitude_UseTerrainFollowing(ActiveUnit activeUnit_0, bool bool_0)
	{
	}

	private CommDevice[] ForgotIssuer()
	{
		CommDevice[] array = new CommDevice[_Comms.Length - 1 + 1];
		if (_Comms.Length != 0)
		{
			Array.Copy(_Comms, array, _Comms.Length);
		}
		return array;
	}

	[SpecialName]
	public bool GetCanSweepMine(UnguidedWeapon unguidedWeapon_0)
	{
		if (unguidedWeapon_0 == null)
		{
			return false;
		}
		foreach (Sensor mineCountermeasure in MineCountermeasures)
		{
			if (mineCountermeasure.IsActive && (mineCountermeasure.GetCanSweepThisMine(unguidedWeapon_0) || mineCountermeasure.GetCanTriggerThisMine(unguidedWeapon_0)))
			{
				return true;
			}
		}
		return false;
	}

	internal virtual List<Sensor> DeleteInterruptibleIdentifier()
	{
		if (_SensorList == null)
		{
			_SensorList = new List<Sensor>();
		}
		else
		{
			_SensorList.Clear();
		}
		Sensor[] sensors = _Sensors;
		Sensor[] array = sensors;
		foreach (Sensor sensor in array)
		{
			if (!sensor.IsMineCountermeasure)
			{
				_SensorList.Add(sensor);
			}
		}
		int num = Mounts.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			sensors = Mounts[i].Sensors_ReadOnly;
			Sensor[] array2 = sensors;
			foreach (Sensor sensor2 in array2)
			{
				if (!sensor2.IsMineCountermeasure)
				{
					sensor2.IsSensorInMount = true;
					_SensorList.Add(sensor2);
				}
			}
		}
		return new List<Sensor>(_SensorList);
	}

	public virtual Sensor[] Sensors_ReadOnly()
	{
		Sensor[] result = null;
		try
		{
			List<Sensor> list = DeleteInterruptibleIdentifier();
			foreach (Sensor item in list)
			{
				if (item != null && item.IsOECM && item.ParentPlatform != null)
				{
					item.ParentPlatform.AttachedTo = this;
				}
			}
			Sensor[] array = new Sensor[list.Count - 1 + 1];
			int num = list.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				array[i] = list[i];
			}
			result = array;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101185", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public virtual float FuelConsumption(Throttle throttle_0, AltBand altBand_0, float? nullable_0, float? nullable_1, bool bool_0, bool bool_1, bool bool_2, bool bool_3, bool bool_4)
	{
		return 1E-07f;
	}

	public virtual Mission AssignedMissionOrPackage()
	{
		try
		{
			if (GetUnitSide() == null)
			{
				return null;
			}
			if (_AssignedMissionOrPackage == null && !string.IsNullOrEmpty(_AssignedMissionOrPackage_ID))
			{
				ReadOnlyCollection<Mission> missionsTotal = GetUnitSide().GetMissionsTotal(ParentScen);
				int num = missionsTotal.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Mission mission = missionsTotal[i];
					if (mission != null && Operators.CompareString(mission.ObjectID, _AssignedMissionOrPackage_ID, TextCompare: false) == 0)
					{
						_AssignedMissionOrPackage = mission;
						mission.UnitsAssignedToMission.TryAdd(this, this);
						break;
					}
				}
				if (_AssignedMissionOrPackage == null)
				{
					_AssignedMissionOrPackage_ID = null;
				}
			}
			Mission assignedMissionOrPackage = _AssignedMissionOrPackage;
			if (assignedMissionOrPackage != null && assignedMissionOrPackage.Category == Mission.MissionCategory.Package && !string.IsNullOrEmpty(_AssignedMissionOrPackage.GetParentTaskPoolID(GetUnitSide())))
			{
				_AssignedTaskPool_ID = _AssignedMissionOrPackage.GetParentTaskPoolID(GetUnitSide());
			}
			return _AssignedMissionOrPackage;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101188", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			_ = Debugger.IsAttached;
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public void AssignMissionInQueue(Mission mission_0)
	{
		if (Information.IsNothing(mission_0))
		{
			return;
		}
		AllowMultiMission = true;
		if (AssignedMissionOrPackage() == mission_0)
		{
			Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
			Set_AssignedMissionOrPackage(null, bool_0: true, bool_1: true, ref missionAssignmentAttemptResult_);
			if (!AssignedMissionsQueue.ContainsKey(mission_0))
			{
				AssignedMissionsQueue.Add(mission_0, mission_0);
				if (!mission_0.UnitsQueuedToMission.ContainsKey(this))
				{
					mission_0.UnitsQueuedToMission.Add(this, this);
				}
			}
		}
		else if (!AssignedMissionsQueue.ContainsKey(mission_0))
		{
			AssignedMissionsQueue.Add(mission_0, mission_0);
			if (!mission_0.UnitsQueuedToMission.ContainsKey(this))
			{
				mission_0.UnitsQueuedToMission.Add(this, this);
			}
		}
	}

	public void UnassignAllMissionInQueue()
	{
		foreach (Mission item in AssignedMissionsQueue.Values.ToList())
		{
			UnassignMissionInQueue(item);
		}
	}

	public void UnassignMissionInQueue(Mission mission_0)
	{
		if (!Information.IsNothing(mission_0) && AssignedMissionsQueue.ContainsKey(mission_0))
		{
			AssignedMissionsQueue.Remove(mission_0);
			if (mission_0.UnitsQueuedToMission.ContainsKey(this))
			{
				mission_0.UnitsQueuedToMission.Remove(this);
			}
		}
	}

	public virtual void Set_AssignedMissionOrPackage(Mission mission_0, bool bool_0, bool bool_1, ref Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_0)
	{
		try
		{
			Mission mission = AssignedMissionOrPackage();
			if (!bool_1 && !CommStuff.IsConnectedToSideNetwork)
			{
				missionAssignmentAttemptResult_0 = Mission.MissionAssignmentAttemptResult.Fail_OutOfComms;
				return;
			}
			bool flag = mission_0 != _AssignedMissionOrPackage;
			if (mission_0 == null)
			{
				if (AI.Targets_ReadOnly.Length != 0)
				{
					bool isInsidePatrolArea_10nmBuffer = AI.IsInsidePatrolArea_10nmBuffer;
					Contact[] targets_ReadOnly = AI.Targets_ReadOnly;
					Contact[] array = targets_ReadOnly;
					foreach (Contact contact_ in array)
					{
						if (AI.TargetingBehaviorForThisTarget(contact_) == ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted)
						{
							ActiveUnit_AI aI = AI;
							Mission assignedMissionOrPackage = _AssignedMissionOrPackage;
							Doctrine._UseShootTourists? nullable_ = Doctrine.GetShootTourists(ParentScen, bool_0: false, bool_1: false, bool_2: false).Value;
							string string_ = "";
							int int_ = 0;
							if (aI.ContactIsRelevantToMission(contact_, assignedMissionOrPackage, nullable_, bool_0: false, isInsidePatrolArea_10nmBuffer, bool_2: true, null, ref string_, ref int_))
							{
								AI.DropTarget(contact_);
							}
						}
					}
				}
				if (_AssignedMissionOrPackage == null || (_AssignedMissionOrPackage != null && _AssignedMissionOrPackage.Category != Mission.MissionCategory.Package))
				{
					_AssignedTaskPool = null;
					_AssignedTaskPool_ID = "";
				}
				if (mission != null)
				{
					ConcurrentDictionary<ActiveUnit, ActiveUnit> unitsAssignedToMission = mission.UnitsAssignedToMission;
					ActiveUnit value = this;
					unitsAssignedToMission.TryRemove(this, out value);
				}
				_AssignedMissionOrPackage = null;
				_AssignedMissionOrPackage_ID = "";
				if (bool_0)
				{
					missionAssignmentAttemptResult_0 = Mission.MissionAssignmentAttemptResult.Success;
					return;
				}
				if (!IsRTB)
				{
					Status = _ActiveUnitStatus.Unassigned;
				}
			}
			else
			{
				if (mission_0.Category == Mission.MissionCategory.TaskPool)
				{
					_AssignedTaskPool = mission_0;
					_AssignedTaskPool_ID = mission_0.ObjectID;
					if (mission != null)
					{
						ConcurrentDictionary<ActiveUnit, ActiveUnit> unitsAssignedToMission2 = mission.UnitsAssignedToMission;
						ActiveUnit value2 = this;
						unitsAssignedToMission2.TryRemove(this, out value2);
					}
					mission_0.UnitsAssignedToMission.TryAdd(this, this);
					missionAssignmentAttemptResult_0 = Mission.MissionAssignmentAttemptResult.Success;
					return;
				}
				_AssignedMissionOrPackage = mission_0;
				_AssignedMissionOrPackage_ID = mission_0.ObjectID;
				if (mission != null)
				{
					ConcurrentDictionary<ActiveUnit, ActiveUnit> unitsAssignedToMission3 = mission.UnitsAssignedToMission;
					ActiveUnit value3 = this;
					unitsAssignedToMission3.TryRemove(this, out value3);
				}
				mission_0.UnitsAssignedToMission.TryAdd(this, this);
				if (bool_0)
				{
					missionAssignmentAttemptResult_0 = Mission.MissionAssignmentAttemptResult.Success;
					return;
				}
				Status = _ActiveUnitStatus.Tasked;
				if (GetUnitSide() != null)
				{
					GetUnitSide().Missions_Add(mission_0);
				}
				if (Navigator.HasPlottedCourse() && flag && Navigator.PlottedCourse[0].Type != 0)
				{
					Navigator.ClearPlottedCourse();
					if (Navigator.HasFlightPlan)
					{
						Navigator.GetFlight().ClearFlightPlan();
					}
				}
				if (mission_0.MissionClass != Mission._MissionClass.Escort)
				{
					AI.EscortTargetID = null;
				}
				if (mission_0.MissionClass == Mission._MissionClass.Patrol)
				{
					if (mission_0.Doctrine.IgnorePlottedCourse_Inherits() == Doctrine.IgnorePlottedCourse_Inherits())
					{
						byte? b = (byte?)Doctrine.GetIgnorePlottedCourse(ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
						bool? flag2 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
						if (((!flag2) ?? flag2).GetValueOrDefault())
						{
							Doctrine.SetIgnorePlottedCourse(ParentScen, bool_0: false, false, bool_1: false, bool_2: false, Doctrine._UseIgnorePlottedCourse.Yes);
						}
					}
					else
					{
						Doctrine.SetIgnorePlottedCourse(ParentScen, bool_0: false, false, bool_1: false, bool_2: false, Doctrine._UseIgnorePlottedCourse.Yes);
					}
				}
				if (mission_0.MissionClass == Mission._MissionClass.Ferry)
				{
					switch (((FerryMission)mission_0).Behavior)
					{
					case FerryMission.FerryMissionBehavior.Random:
						if (IsAircraft)
						{
							((Aircraft)this).AirOps.PickNewAssignedHost_RandomWithinRange(((Aircraft)this).AirOps.GetAssignedHostUnit());
						}
						else
						{
							DockingOps.PickNewAssignedHost_RandomWithinRange(DockingOps.GetAssignedHostUnit());
						}
						break;
					case FerryMission.FerryMissionBehavior.Cycle:
						AI.InitializeCycleFerry();
						break;
					}
				}
				if (mission_0.MissionClass == Mission._MissionClass.Support)
				{
					Status = _ActiveUnitStatus.OnSupportMission;
					Navigator.ClearPlottedCourse();
					Navigator.FollowSupportMissionCourse(ParentScen.GameResolution, bool_1: true);
				}
			}
			if (flag)
			{
				AI.IsEscort = false;
				if (IsGroupLead())
				{
					Group parentGroup = GetParentGroup();
					Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
					parentGroup.Set_AssignedMissionOrPackage(mission_0, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
				}
			}
			missionAssignmentAttemptResult_0 = Mission.MissionAssignmentAttemptResult.Success;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101189", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			missionAssignmentAttemptResult_0 = Mission.MissionAssignmentAttemptResult.Fail_Other;
			ProjectData.ClearProjectError();
		}
	}

	internal Mission.MissionAssignmentAttemptResult CollectIssuer(ref Scenario scenario_0, ref ActiveUnit activeUnit_0, ref Mission mission_0, ref bool bool_0)
	{
		Mission.MissionAssignmentAttemptResult result = Mission.MissionAssignmentAttemptResult.None;
		try
		{
			string text = "";
			if (activeUnit_0.IsAircraft && Operators.CompareString(activeUnit_0.Name, activeUnit_0.UnitClass, TextCompare: false) != 0)
			{
				text = " (" + activeUnit_0.UnitClass + ")";
			}
			Mission mission = null;
			if (activeUnit_0.AssignedMissionOrPackage() != null && mission_0 != activeUnit_0.AssignedMissionOrPackage())
			{
				mission = activeUnit_0.AssignedMissionOrPackage();
			}
			if (mission_0.Category == Mission.MissionCategory.TaskPool)
			{
				Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
				activeUnit_0.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
				if (missionAssignmentAttemptResult_ == Mission.MissionAssignmentAttemptResult.Success)
				{
					if (mission != null && activeUnit_0.Navigator.HasFlight && mission.FlightList.Contains(activeUnit_0.Navigator.GetFlight()))
					{
						mission.FlightList.Remove(activeUnit_0.Navigator.GetFlight());
					}
					if (activeUnit_0.AssignedTaskPool == null || activeUnit_0.AssignedTaskPool != mission_0)
					{
						activeUnit_0.AssignedTaskPool = mission_0;
						activeUnit_0.ParentScen.AddMessage(activeUnit_0.Name + text + "已分配给任务池：" + mission_0.Name, activeUnit_0.Name + " 分配到任务池", LoggedMessage.MessageType.UnitAI, 0, activeUnit_0.ObjectID, activeUnit_0.GetUnitSide(), new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
						if (activeUnit_0.IsGroup)
						{
							foreach (ActiveUnit value in ((Group)activeUnit_0).Units.Values)
							{
								if (value.IsOperating())
								{
									value.AI.EvaluateTargets(0f, bool_0: false, bool_1: true);
								}
							}
						}
						else if (activeUnit_0.IsOperating())
						{
							activeUnit_0.AI.EvaluateTargets(0f, bool_0: false, bool_1: true);
						}
						activeUnit_0.Doctrine.ClearCachedParentDoctrine();
					}
					result = missionAssignmentAttemptResult_;
					return result;
				}
				result = missionAssignmentAttemptResult_;
				return result;
			}
			if (activeUnit_0.IsGroup)
			{
				_ = ((Group)activeUnit_0).GroupLead;
			}
			Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_2 = Mission.MissionAssignmentAttemptResult.None;
			activeUnit_0.Set_AssignedMissionOrPackage(mission_0, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_2);
			if (missionAssignmentAttemptResult_2 == Mission.MissionAssignmentAttemptResult.Success)
			{
				if (mission != null && activeUnit_0.Navigator.HasFlight && mission.FlightList.Contains(activeUnit_0.Navigator.GetFlight()))
				{
					mission.FlightList.Remove(activeUnit_0.Navigator.GetFlight());
				}
				if (activeUnit_0.AssignedMissionOrPackage().Category == Mission.MissionCategory.Package)
				{
					foreach (Mission mission2 in activeUnit_0.GetUnitSide().Missions)
					{
						if (Operators.CompareString(mission2.ObjectID, activeUnit_0.AssignedMissionOrPackage().GetParentTaskPoolID(activeUnit_0.GetUnitSide()), TextCompare: false) == 0)
						{
							activeUnit_0.AssignedTaskPool = mission2;
							break;
						}
					}
				}
				else
				{
					activeUnit_0.AssignedTaskPool = null;
				}
				if (activeUnit_0.IsGroup)
				{
					foreach (ActiveUnit value2 in ((Group)activeUnit_0).Units.Values)
					{
						value2.AssignedTaskPool = activeUnit_0.AssignedTaskPool;
					}
				}
				if ((activeUnit_0.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike) & bool_0)
				{
					if (activeUnit_0.IsGroup)
					{
						foreach (ActiveUnit value3 in ((Group)activeUnit_0).Units.Values)
						{
							value3.AI.IsEscort = true;
						}
					}
					else
					{
						activeUnit_0.AI.IsEscort = true;
					}
					scenario_0.AddMessage(activeUnit_0.Name + text + "已被指定为执行任务的护航：" + mission_0.Name, activeUnit_0.Name + " 指定为护航", LoggedMessage.MessageType.UnitAI, 0, activeUnit_0.ObjectID, activeUnit_0.GetUnitSide(), new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
				}
				else
				{
					if (activeUnit_0.IsGroup)
					{
						foreach (ActiveUnit value4 in ((Group)activeUnit_0).Units.Values)
						{
							value4.AI.IsEscort = false;
						}
					}
					else
					{
						activeUnit_0.AI.IsEscort = false;
					}
					scenario_0.AddMessage(activeUnit_0.Name + text + "已被分配到任务：" + mission_0.Name, activeUnit_0.Name + " 分配到任务", LoggedMessage.MessageType.UnitAI, 0, activeUnit_0.ObjectID, activeUnit_0.GetUnitSide(), new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
				}
				activeUnit_0.Doctrine.ClearCachedParentDoctrine();
				activeUnit_0.Sensory.vmethod_0(activeUnit_0.Sensors_Cached);
				if (activeUnit_0.IsGroup)
				{
					foreach (ActiveUnit value5 in ((Group)activeUnit_0).Units.Values)
					{
						if (value5.IsOperating())
						{
							value5.AI.EvaluateTargets(0f, bool_0: false, bool_1: true);
							value5.Doctrine.ClearCachedParentDoctrine();
							value5.Sensory.vmethod_0(activeUnit_0.Sensors_Cached);
						}
					}
				}
				else if (activeUnit_0.IsOperating())
				{
					activeUnit_0.AI.EvaluateTargets(0f, bool_0: false, bool_1: true);
				}
				activeUnit_0.Doctrine.ClearCachedParentDoctrine();
				result = missionAssignmentAttemptResult_2;
				return result;
			}
			result = missionAssignmentAttemptResult_2;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101189", "");
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
	public virtual bool GetCanPhysicallyReplenishThisUnit(ActiveUnit activeUnit_0)
	{
		return false;
	}

	[SpecialName]
	public virtual bool GetHasEnoughFuelToReplenishThisUnit(ActiveUnit activeUnit_0, Aircraft_AirOps aircraft_AirOps_0, float float_0, bool bool_0)
	{
		return true;
	}

	[SpecialName]
	public virtual long GetFuelEndurance(Throttle throttle_0, AltBand altBand_0, float? nullable_0, float? nullable_1)
	{
		return 0L;
	}

	public void FuelCapacitySet(float float_0, FuelRec._FuelType _FuelType_0)
	{
		try
		{
			foreach (FuelRec item in Fuel_ReadOnly)
			{
				if (item.FuelType == _FuelType_0)
				{
					item.CurrentQuantity = float_0;
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101227", "FuelCapacitySet");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	public bool GetIsAutoDetectable(Side side_0)
	{
		if (IsGroup)
		{
			return false;
		}
		if (strategyVal)
		{
			return true;
		}
		if (side_0 == null)
		{
			return false;
		}
		if (IsCivilian && side_0.CanAutoTrackCivs)
		{
			return true;
		}
		if (side_0.AwarenessLevel == Side.AwarenessLevel_Enum.Omniscient)
		{
			return true;
		}
		if (GetUnitSide().GetConsidersThisSideToBe(side_0) == Misc.PostureStance.Friendly && CommStuff.IsConnectedToSideNetwork)
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	public void SetIsAutoDetectable(Side side_0, bool bool_0)
	{
		try
		{
			if (bool_0)
			{
				Side[] sides_ReadOnly = ParentScen.Sides_ReadOnly;
				Side[] array = sides_ReadOnly;
				foreach (Side side in array)
				{
					if (side != null)
					{
						ParentScen.UnitAutodetectionValidation.Add(side);
					}
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
		strategyVal = bool_0;
	}

	public virtual double FuelPercent(ref double double_0, ref double double_1, bool bool_0)
	{
		try
		{
			if (Propulsion.Count > 0 && Propulsion[0].Type == Engine.EngineType.Nuclear)
			{
				return 1.0;
			}
			if (IsSubmarine && ((Submarine)this).IsTetheredROV && Propulsion.Count > 0 && Propulsion[0].Type == Engine.EngineType.Electric && Fuel_ReadOnly.Count == 0)
			{
				return 1.0;
			}
			if (Fuel_ReadOnly.Count == 0)
			{
				return 0.0;
			}
			foreach (FuelRec item in Fuel_ReadOnly.ToList())
			{
				if (item != null && (Propulsion.Count <= 0 || !IsShip || Propulsion[0].CanUseThisFuelType(item.FuelType)))
				{
					double_0 += item.CurrentQuantity;
					double_1 += item.MaxQuantity;
				}
			}
			if (bool_0 && IsAircraft)
			{
				double_0 -= Kinematics.ReserveFuel;
				double_1 -= Kinematics.ReserveFuel;
			}
			if (double_1 <= 0.0)
			{
				return 0.0;
			}
			return double_0 / double_1;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101346", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0.0;
		}
	}

	internal ReadOnlyCollection<PlatformComponent> OrderIssuer()
	{
		List<PlatformComponent> list = ((_RoleVal == 0) ? new List<PlatformComponent>() : new List<PlatformComponent>(_RoleVal));
		Sensor[] array = Sensors_ReadOnly();
		Sensor[] array3 = array;
		foreach (Sensor item in array3)
		{
			list.Add(item);
		}
		foreach (Mount mount in Mounts)
		{
			list.Add(mount);
		}
		CommDevice[] comms_ReadOnly = Comms_ReadOnly;
		CommDevice[] array4 = comms_ReadOnly;
		foreach (CommDevice item2 in array4)
		{
			list.Add(item2);
		}
		DockFacility[] dockFacilities = _DockFacilities;
		DockFacility[] array5 = dockFacilities;
		foreach (DockFacility item3 in array5)
		{
			list.Add(item3);
		}
		AirFacility[] airFacilities = _AirFacilities;
		AirFacility[] array6 = airFacilities;
		foreach (AirFacility item4 in array6)
		{
			list.Add(item4);
		}
		Cargo[] onboardCargo = OnboardCargo;
		Cargo[] array7 = onboardCargo;
		foreach (Cargo item5 in array7)
		{
			list.Add(item5);
		}
		foreach (Engine item7 in Propulsion)
		{
			list.Add(item7);
		}
		Magazine[] sharedMagazines = SharedMagazines;
		if (sharedMagazines != null)
		{
			Magazine[] array2 = sharedMagazines;
			Magazine[] array8 = array2;
			foreach (Magazine item6 in array8)
			{
				list.Add(item6);
			}
		}
		_RoleVal = list.Count;
		return list.AsReadOnly();
	}

	[SpecialName]
	public bool GetIsPaintingThisTarget(Contact contact_0)
	{
		return (from theS in Sensors_ReadOnly()
			where theS.TargetsTrackedForFireControl_Readonly.Contains(contact_0)
			select theS).Count() > 0;
	}

	public override void ObjectID_Set(string string_0)
	{
		if (!string.IsNullOrEmpty(string_0))
		{
			string_0 = string_0.Replace("_", "");
		}
		base.ObjectID_Set(string_0);
	}

	public override void ResetIDs()
	{
		base.ResetIDs();
		Sensor[] sensors = _Sensors;
		checked
		{
			for (int i = 0; i < sensors.Length; i++)
			{
				sensors[i].ResetIDs();
			}
			CommDevice[] comms = _Comms;
			for (int j = 0; j < comms.Length; j++)
			{
				comms[j].ResetIDs();
			}
			foreach (Engine item in Propulsion)
			{
				item.ResetIDs();
			}
			foreach (FuelRec item2 in _Fuel)
			{
				item2.ResetIDs();
			}
			foreach (Mount mount in Mounts)
			{
				mount.ResetIDs();
			}
			Cargo[] onboardCargo = OnboardCargo;
			for (int k = 0; k < onboardCargo.Length; k++)
			{
				onboardCargo[k].ResetIDs();
			}
			AirFacility[] airFacilities = _AirFacilities;
			for (int l = 0; l < airFacilities.Length; l++)
			{
				airFacilities[l].ResetIDs();
			}
		}
	}

	public override void PrePulseHousekeeping(float float_0, Scenario scenario_0)
	{
		base.PrePulseHousekeeping(float_0, scenario_0);
		if (GetUnitSide().NoNavZones.Count > 0)
		{
			ActiveUnit_Navigator navigator = Navigator;
			if (navigator.TimeToNextUnitDistanceToNearestNoNavZoneEvaluation > 0.0)
			{
				navigator.TimeToNextUnitDistanceToNearestNoNavZoneEvaluation -= float_0;
			}
		}
		if (IsWeapon)
		{
			((Weapon)this).Navigator._ProccesorReader = null;
		}
		if (IsAircraft)
		{
			((Aircraft)this).MinimumSafeHeight = null;
		}
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("ActiveUnit");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			if (hashSet_0.Contains(ObjectID))
			{
				xmlWriter_0.WriteEndElement();
				return;
			}
			hashSet_0.Add(ObjectID);
			xmlWriter_0.WriteElementString("Name", Name);
			xmlWriter_0.WriteElementString("CurrentHeading", XmlConvert.ToString(CurrentHeading));
			xmlWriter_0.WriteElementString("CurrentSpeed", XmlConvert.ToString(CurrentSpeed));
			xmlWriter_0.WriteElementString("CurrentAltitude", XmlConvert.ToString(GetCurrentAltitude()));
			xmlWriter_0.WriteElementString("Longitude", XmlConvert.ToString(GetLongitude()));
			xmlWriter_0.WriteElementString("Latitude", XmlConvert.ToString(GetLatitude()));
			xmlWriter_0.WriteElementString("UnitClass", UnitClass);
			xmlWriter_0.WriteElementString("Side", GetUnitSide().Name);
			if (!string.IsNullOrEmpty(Message))
			{
				xmlWriter_0.WriteElementString("Message", Message);
			}
			xmlWriter_0.WriteElementString("DBID", DBID.ToString());
			xmlWriter_0.WriteElementString("DesiredHeading", XmlConvert.ToString(DesiredHeading));
			xmlWriter_0.WriteElementString("DesiredSpeed", XmlConvert.ToString(DesiredSpeed));
			xmlWriter_0.WriteElementString("DesiredAltitude", XmlConvert.ToString(DesiredAltitude));
			if (DesiredAltitude_AGL != 0f)
			{
				xmlWriter_0.WriteElementString("DesiredAltitude_TerrainFollowing", XmlConvert.ToString(DesiredAltitude_AGL));
			}
			xmlWriter_0.WriteElementString("DesiredTurnRate", ((byte)DesiredTurnRate).ToString());
			xmlWriter_0.WriteElementString("DesiredTurnRate_Navigation", ((byte)DesiredTurnRate_Navigation).ToString());
			if (GetDesiredAltitude_UseTerrainFollowing(this))
			{
				xmlWriter_0.WriteElementString("TerrainFollowing", GetDesiredAltitude_UseTerrainFollowing(this).ToString());
			}
			xmlWriter_0.WriteElementString("Weight", XmlConvert.ToString(EmptyWeight));
			xmlWriter_0.WriteElementString("ThrottleSetting", ((byte)ThrottleSetting).ToString());
			if (_Proficiency.HasValue)
			{
				xmlWriter_0.WriteElementString("Prof", ((int)_Proficiency.Value).ToString());
			}
			xmlWriter_0.WriteStartElement("Sensors");
			Sensor[] sensors = _Sensors;
			Sensor[] array = sensors;
			foreach (Sensor sensor in array)
			{
				xmlWriter_0.WriteRaw(sensor.ToXML(hashSet_0));
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Comms");
			CommDevice[] comms = _Comms;
			CommDevice[] array2 = comms;
			foreach (CommDevice commDevice in array2)
			{
				xmlWriter_0.WriteRaw(commDevice.ToXML(ref hashSet_0));
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Propulsion");
			foreach (Engine item in Propulsion)
			{
				xmlWriter_0.WriteRaw(item.ToXML(hashSet_0));
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("XSections");
			XSection[] xSections_ReadOnly = XSections_ReadOnly;
			for (int i = 0; i < xSections_ReadOnly.Length; i = checked(i + 1))
			{
				xSections_ReadOnly[i].ToXML(ref xmlWriter_0);
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Fuel");
			foreach (FuelRec item2 in _Fuel)
			{
				xmlWriter_0.WriteRaw(item2.ToXML());
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Mounts");
			foreach (Mount mount in Mounts)
			{
				xmlWriter_0.WriteRaw(mount.ToXML(ref hashSet_0, ParentScen));
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("OnboardCargo");
			Cargo[] onboardCargo = OnboardCargo;
			Cargo[] array3 = onboardCargo;
			foreach (Cargo cargo in array3)
			{
				xmlWriter_0.WriteRaw(cargo.ToXML(hashSet_0, ParentScen));
			}
			xmlWriter_0.WriteEndElement();
			XmlWriter obj = xmlWriter_0;
			byte status = (byte)_Status;
			obj.WriteElementString("Status", status.ToString());
			XmlWriter obj4 = xmlWriter_0;
			status = (byte)_FuelState;
			obj4.WriteElementString("FuelState", status.ToString());
			XmlWriter obj5 = xmlWriter_0;
			status = (byte)_WeaponState;
			obj5.WriteElementString("WeaponState", status.ToString());
			if (predicateVal != 0)
			{
				XmlWriter obj6 = xmlWriter_0;
				status = (byte)predicateVal;
				obj6.WriteElementString("SBR", status.ToString());
			}
			if (_SingletonVal != 0)
			{
				XmlWriter obj7 = xmlWriter_0;
				status = (byte)_SingletonVal;
				obj7.WriteElementString("SBED", status.ToString());
			}
			if (_RecordVal != 0)
			{
				XmlWriter obj8 = xmlWriter_0;
				status = (byte)_RecordVal;
				obj8.WriteElementString("SBEO", status.ToString());
			}
			if (comparatorVal != 0)
			{
				XmlWriter obj9 = xmlWriter_0;
				status = (byte)comparatorVal;
				obj9.WriteElementString("FSBR", status.ToString());
			}
			if (_ItemVal != 0f)
			{
				xmlWriter_0.WriteElementString("SBR_Altitude", XmlConvert.ToString(_ItemVal));
			}
			if (setterVal != 0f)
			{
				xmlWriter_0.WriteElementString("SBR_Altitude_TF", XmlConvert.ToString(setterVal));
			}
			xmlWriter_0.WriteElementString("SBR_TF", XmlConvert.ToString(_CreatorVal));
			XmlWriter obj10 = xmlWriter_0;
			status = (byte)_TemplateVal;
			obj10.WriteElementString("SBR_ThrottleSetting", status.ToString());
			xmlWriter_0.WriteElementString("SBED_Altitude", XmlConvert.ToString(m_MappingVal));
			if (m_MockVal.HasValue)
			{
				xmlWriter_0.WriteElementString("SBED_Altitude_TF", XmlConvert.ToString(m_MockVal.Value));
			}
			xmlWriter_0.WriteElementString("SBED_TF", XmlConvert.ToString(tagVal));
			XmlWriter obj11 = xmlWriter_0;
			status = (byte)fieldVal;
			obj11.WriteElementString("SBED_ThrottleSetting", status.ToString());
			if (queueVal.HasValue)
			{
				xmlWriter_0.WriteElementString("SBED_DesiredSpeedOverride", XmlConvert.ToString(queueVal.Value));
			}
			xmlWriter_0.WriteElementString("SBEO_Altitude", XmlConvert.ToString(regVal));
			xmlWriter_0.WriteElementString("SBEO_Altitude_TF", XmlConvert.ToString(paramVal));
			xmlWriter_0.WriteElementString("SBEO_TF", XmlConvert.ToString(m_PageVal));
			if (m_RulesVal != 0)
			{
				XmlWriter obj2 = xmlWriter_0;
				status = (byte)m_RulesVal;
				obj2.WriteElementString("SBEO_ThrottleSetting", status.ToString());
			}
			xmlWriter_0.WriteElementString("SBPF_Altitude", XmlConvert.ToString(_MethodVal));
			xmlWriter_0.WriteElementString("SBPF_Altitude_TF", XmlConvert.ToString(serviceVal));
			xmlWriter_0.WriteElementString("SBPF_TF", XmlConvert.ToString(m_SystemVal));
			if (candidateVal != 0)
			{
				XmlWriter obj3 = xmlWriter_0;
				status = (byte)candidateVal;
				obj3.WriteElementString("SBPF_ThrottleSetting", status.ToString());
			}
			xmlWriter_0.WriteElementString("AMP_OC", m_AttrVal.ToString());
			if (_VisitorVal.HasValue)
			{
				xmlWriter_0.WriteElementString("AMP_OC_DSO", _VisitorVal.ToString());
			}
			xmlWriter_0.WriteElementString("AMP_OC_DAO", _ExporterVal.ToString());
			xmlWriter_0.WriteElementString("AMP_OC_Speed", XmlConvert.ToString(m_PrototypeVal));
			xmlWriter_0.WriteElementString("DamagePts", XmlConvert.ToString(m_StatusVal));
			xmlWriter_0.WriteElementString("OldDamagePercent", XmlConvert.ToString(utilsVal));
			if (EligibleForSAR)
			{
				xmlWriter_0.WriteElementString("EFSAR", XmlConvert.ToString(EligibleForSAR));
			}
			if (IsBeingPickedUp)
			{
				xmlWriter_0.WriteElementString("IBPU", XmlConvert.ToString(IsBeingPickedUp));
			}
			if (_AirFacilities.Length != 0)
			{
				xmlWriter_0.WriteStartElement("AirFacilities");
				AirFacility[] airFacilities = _AirFacilities;
				AirFacility[] array4 = airFacilities;
				foreach (AirFacility airFacility in array4)
				{
					xmlWriter_0.WriteRaw(airFacility.ToXML(hashSet_0));
				}
				xmlWriter_0.WriteEndElement();
			}
			if (_DockFacilities.Count() > 0)
			{
				xmlWriter_0.WriteStartElement("DockFacilities");
				DockFacility[] dockFacilities = _DockFacilities;
				DockFacility[] array5 = dockFacilities;
				foreach (DockFacility dockFacility in array5)
				{
					xmlWriter_0.WriteRaw(dockFacility.ToXML(hashSet_0));
				}
				xmlWriter_0.WriteEndElement();
			}
			if (AssignedMissionOrPackage() != null)
			{
				xmlWriter_0.WriteElementString("AssignedMission", _AssignedMissionOrPackage.ObjectID);
			}
			if (AssignedTaskPool != null)
			{
				xmlWriter_0.WriteElementString("AssignedTaskPool", _AssignedTaskPool.ObjectID);
			}
			if (GetParentGroup() != null)
			{
				xmlWriter_0.WriteElementString("ParentGroup", _ParentGroup.ObjectID);
			}
			if (GetIsAutoDetectable(null))
			{
				xmlWriter_0.WriteElementString("IsAD", GetIsAutoDetectable(null).ToString());
			}
			Doctrine.ToXML(ref xmlWriter_0, ref ParentScen);
			broadcasterVal.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteStartElement("ActiveUnit_AI");
			_AI.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("ActiveUnit_Kinematics");
			_IdentifierVal.ToXML(ref xmlWriter_0);
			xmlWriter_0.WriteEndElement();
			_Sensory.ToXML(ref xmlWriter_0);
			m_PrinterVal.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteStartElement("ActiveUnit_CommStuff");
			_CommStuff.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteEndElement();
			_Damage.ToXML(ref xmlWriter_0, ref hashSet_0);
			_AirOps.ToXML(ref xmlWriter_0, ref hashSet_0);
			if (HasCustomOODA)
			{
				xmlWriter_0.WriteElementString("OODA_D", m_TokenVal.ToString());
				xmlWriter_0.WriteElementString("OODA_T", _IndexerVal.ToString());
				xmlWriter_0.WriteElementString("OODA_E", _ResolverVal.ToString());
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100000", "Name: " + Name + " DBID: " + Conversions.ToString(DBID) + " ObjectID: " + ObjectID);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CommonFromXML(XmlNode xmlNode_0)
	{
		switch (xmlNode_0.Name)
		{
		case "AltOld":
			base.Altitude_old = XmlConvert.ToSingle(xmlNode_0.InnerText);
			break;
		case "SettledTime":
			SettledTime = XmlConvert.ToSingle(xmlNode_0.InnerText);
			break;
		case "Decoy":
			Decoy = Conversions.ToBoolean(xmlNode_0.InnerText);
			break;
		case "TemporaryBlindness":
			TemporaryBlindness = XmlConvert.ToSingle(xmlNode_0.InnerText);
			break;
		case "DesignatedSupplier":
			if (Versioned.IsNumeric(xmlNode_0.InnerText))
			{
				_DesignatedSupplier = (ActiveUnit_DockingOps.ResupplyCapacity)Conversions.ToInteger(xmlNode_0.InnerText);
			}
			else
			{
				_DesignatedSupplier = (ActiveUnit_DockingOps.ResupplyCapacity)Enum.Parse(typeof(ActiveUnit_DockingOps.ResupplyCapacity), xmlNode_0.InnerText, ignoreCase: true);
			}
			break;
		case "TaggedAsDecoy":
		{
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
					composerVal.Add(xmlNode2.InnerText);
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
		case "AllowMultiMission":
			AllowMultiMission = Conversions.ToBoolean(xmlNode_0.InnerText);
			break;
		case "AssignedMissionsQueue":
		{
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					_AssignedMissionsQueue_ID.Add(xmlNode.InnerText);
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

	public void method_0(ref XmlWriter xmlWriter_0)
	{
		if (!string.IsNullOrEmpty(CustomIcon))
		{
			xmlWriter_0.WriteElementString("CustomIcon", CustomIcon);
		}
		if (AssignedMissionsQueue.Count > 0)
		{
			xmlWriter_0.WriteStartElement("AssignedMissionsQueue");
			foreach (Mission key in AssignedMissionsQueue.Keys)
			{
				xmlWriter_0.WriteElementString("Mission", key.ObjectID);
			}
			xmlWriter_0.WriteEndElement();
		}
		xmlWriter_0.WriteElementString("AllowMultiMission", AllowMultiMission.ToString());
		if (_DesignatedSupplier.HasValue)
		{
			xmlWriter_0.WriteElementString("DesignatedSupplier", ((byte)_DesignatedSupplier.Value).ToString());
		}
		if (SettledTime != 0f)
		{
			xmlWriter_0.WriteElementString("SettledTime", XmlConvert.ToString(SettledTime));
		}
		xmlWriter_0.WriteElementString("AltOld", XmlConvert.ToString(base.Altitude_old));
		if (TemporaryBlindness != 0f)
		{
			xmlWriter_0.WriteElementString("TemporaryBlindness", XmlConvert.ToString(TemporaryBlindness));
		}
		xmlWriter_0.WriteElementString("Decoy", Decoy.ToString());
		if (composerVal.Count <= 0)
		{
			return;
		}
		xmlWriter_0.WriteStartElement("TaggedAsDecoy");
		foreach (string item in composerVal)
		{
			xmlWriter_0.WriteElementString("Side", item);
		}
		xmlWriter_0.WriteEndElement();
	}

	public static ActiveUnit FromXML(string string_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		try
		{
			if (concurrentDictionary_0.ContainsKey(string_0))
			{
				return (ActiveUnit)concurrentDictionary_0[string_0];
			}
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100001.2.", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public static ActiveUnit FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		try
		{
			string name = xmlNode_0.Name;
			if (1 == 0)
			{
			}
			ActiveUnit result = name switch
			{
				"Ship" => Ship.FromXML(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0), 
				"Group" => Group.FromXML(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0), 
				"Facility" => Facility.FromXML(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0), 
				"Submarine" => Submarine.FromXML(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0), 
				"Weapon" => Weapon.FromXML(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0), 
				"Vehicle" => Vehicle.FromXML(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0), 
				"Aircraft" => Aircraft.FromXML(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0), 
				"Satellite" => Satellite.FromXML(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0), 
				_ => null, 
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
			exception_?.Data.Add("Error at 100001", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	internal void RegisterIssuer(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		try
		{
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					if (Operators.CompareString(xmlNode.Name, "AirFacilities", TextCompare: false) != 0)
					{
						continue;
					}
					try
					{
						enumerator2 = xmlNode.ChildNodes.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
							algoVal.Add(xmlNode2.ChildNodes[0].InnerXml);
						}
					}
					finally
					{
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
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
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100002", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PostDeserializationHousekeeping_Groupmembership(ref Scenario scenario_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		try
		{
			if (!string.IsNullOrEmpty(_ParentGroup_ID))
			{
				try
				{
					SetParentGroup(bool_0: true, (Group)scenario_0.ActiveUnits[_ParentGroup_ID]);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200004", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (GetParentGroup() == null)
			{
				Navigator.UnitFormationStation = null;
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100003", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void PostDeserializationHousekeeping_General(ref Scenario scenario_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, List<ActiveUnit> list_0, bool bool_0)
	{
		try
		{
			if (string.IsNullOrEmpty(_SideName))
			{
				list_0.Add(this);
				if (DBID != 0 && Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return;
			}
			SetUnitSide(bool_0: false, Side.FromXML_ByName(_SideName, ref concurrentDictionary_0, scenario_0));
			AirOps.PostDeserializationHousekeeping(ref scenario_0, concurrentDictionary_0, bool_0);
			Navigator.PostDeserializationHousekeeping(ref scenario_0, concurrentDictionary_0, bool_0);
			foreach (string item in _AssignedMissionsQueue_ID)
			{
				if (concurrentDictionary_0.ContainsKey(item))
				{
					Mission mission = (Mission)concurrentDictionary_0[item];
					AssignedMissionsQueue.Add(mission, mission);
					if (!mission.UnitsQueuedToMission.ContainsKey(this))
					{
						mission.UnitsQueuedToMission.Add(this, this);
					}
				}
			}
			if (OnboardCargo != null)
			{
				Cargo[] onboardCargo = OnboardCargo;
				for (int i = 0; i < onboardCargo.Length; i = checked(i + 1))
				{
					onboardCargo[i].PostDeserializationHousekeeping_General(ref scenario_0, concurrentDictionary_0, bool_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100004", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual bool IsParkedAndReady()
	{
		if (DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Docked)
		{
			return DockingOps.ConditionTimer == 0f;
		}
		return false;
	}

	public virtual bool IsParkedAndReadying()
	{
		if (DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Docked)
		{
			return DockingOps.ConditionTimer > 0f;
		}
		return false;
	}

	public virtual bool IsAvailableForOps(ref string string_0)
	{
		return true;
	}

	public ActiveUnit()
	{
		Decoy = false;
		composerVal = new List<string>();
		m_RefVal = null;
		SettledTime = 0f;
		_DesignatedSupplier = null;
		TerrainFollowingType = TerrainFollowMode.IgnoreLandCover;
		LandCoverMaskingCapability = false;
		_Sensors = new Sensor[0];
		_Comms = new CommDevice[0];
		Propulsion = new ObservableList<Engine>();
		_Fuel = new List<FuelRec>();
		Mounts = new ObservableList<Mount>();
		OnboardCargo = new Cargo[0];
		_AirFacilities = new AirFacility[0];
		_DockFacilities = new DockFacility[0];
		AssignedMissionsQueue = new Dictionary<Mission, Mission>();
		_AssignedMissionsQueue_ID = new List<string>();
		List<ActiveUnit> list_ = null;
		Doctrine = new Doctrine(this, ref list_);
		HasCustomOODA = false;
		TimeSinceLastThreatDetection_ESM = 1801f;
		IsBeingDestroyed = false;
		IncomingGuidedWeaponsList = new Weapon[0];
		IsBeingPickedUp = false;
		EligibleForSAR = false;
		PickUpUnit = null;
		ChanceOfAppearance = 0;
		IsDumbAU = false;
		TimeUnderway = 0f;
		UNREP_Capabilities = default(_UNREP_Capabilities);
		parserVal = false;
		algoVal = new List<string>();
		CargoTransferList = null;
		_DestroyEventsChecked = false;
		TemporaryEmissionEM = new Dictionary<XSection._SignatureType, Str_TemporaryEmission>();
		Journey = new StoredCourse();
		IsStoringJourney = false;
		_MineCountermeasures_Lock = RuntimeHelpers.GetObjectValue(new object());
		m_IteratorVal = RuntimeHelpers.GetObjectValue(new object());
		IsActiveUnit = true;
	}

	public ActiveUnit(ref Scenario scenario_0, string string_0 = null)
	{
		Decoy = false;
		composerVal = new List<string>();
		m_RefVal = null;
		SettledTime = 0f;
		_DesignatedSupplier = null;
		TerrainFollowingType = TerrainFollowMode.IgnoreLandCover;
		LandCoverMaskingCapability = false;
		_Sensors = new Sensor[0];
		_Comms = new CommDevice[0];
		Propulsion = new ObservableList<Engine>();
		_Fuel = new List<FuelRec>();
		Mounts = new ObservableList<Mount>();
		OnboardCargo = new Cargo[0];
		_AirFacilities = new AirFacility[0];
		_DockFacilities = new DockFacility[0];
		AssignedMissionsQueue = new Dictionary<Mission, Mission>();
		_AssignedMissionsQueue_ID = new List<string>();
		List<ActiveUnit> list_ = null;
		Doctrine = new Doctrine(this, ref list_);
		HasCustomOODA = false;
		TimeSinceLastThreatDetection_ESM = 1801f;
		IsBeingDestroyed = false;
		IncomingGuidedWeaponsList = new Weapon[0];
		IsBeingPickedUp = false;
		EligibleForSAR = false;
		PickUpUnit = null;
		ChanceOfAppearance = 0;
		IsDumbAU = false;
		TimeUnderway = 0f;
		UNREP_Capabilities = default(_UNREP_Capabilities);
		parserVal = false;
		algoVal = new List<string>();
		CargoTransferList = null;
		_DestroyEventsChecked = false;
		TemporaryEmissionEM = new Dictionary<XSection._SignatureType, Str_TemporaryEmission>();
		Journey = new StoredCourse();
		IsStoringJourney = false;
		_MineCountermeasures_Lock = RuntimeHelpers.GetObjectValue(new object());
		m_IteratorVal = RuntimeHelpers.GetObjectValue(new object());
		try
		{
			IsActiveUnit = true;
			ParentScen = scenario_0;
			if (!string.IsNullOrEmpty(string_0))
			{
				ObjectID_Set(string_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100005", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void DoTypeSpecificActions(float float_0, ref LockRandom lockRandom_0)
	{
	}

	public virtual bool IsOperating()
	{
		switch (DockingOps.Condition)
		{
		default:
			return false;
		case ActiveUnit_DockingOps._DockingOpsCondition.Underway:
		case ActiveUnit_DockingOps._DockingOpsCondition.RTB:
		case ActiveUnit_DockingOps._DockingOpsCondition.ManoeuveringToRefuel:
		case ActiveUnit_DockingOps._DockingOpsCondition.Replenishing:
		case ActiveUnit_DockingOps._DockingOpsCondition.ProvidingUNREP:
		case ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries:
		case ActiveUnit_DockingOps._DockingOpsCondition.SettlingForCargoTransfer:
		case ActiveUnit_DockingOps._DockingOpsCondition.TransferringCargo:
		case ActiveUnit_DockingOps._DockingOpsCondition.TransferringMissionCargo:
			return true;
		}
	}

	public virtual bool IsHostedInExposedSpace()
	{
		if (IsOperating())
		{
			return false;
		}
		if (DockingOps.HostDockFacility == null)
		{
			return false;
		}
		if (DockingOps.HostDockFacility.IsOpenDockFacility)
		{
			return true;
		}
		return false;
	}

	public void AddCommDevice(CommDevice commDevice_0)
	{
		ArrayExtensions.Add(ref _Comms, commDevice_0);
	}

	public void AddSensor(Sensor sensor_0)
	{
		ArrayExtensions.Add(ref _Sensors, sensor_0);
		Sensors_Cached = null;
		MineCountermeasures = null;
	}

	public void AddAirFacility(AirFacility airFacility_0)
	{
		ArrayExtensions.Add(ref _AirFacilities, airFacility_0);
	}

	public void RemoveAirFacility(AirFacility airFacility_0)
	{
		ArrayExtensions.Remove(ref _AirFacilities, airFacility_0);
	}

	public void AddDockFacility(DockFacility dockFacility_0)
	{
		ArrayExtensions.Add(ref _DockFacilities, dockFacility_0);
	}

	public void RemoveDockFacility(DockFacility dockFacility_0)
	{
		ArrayExtensions.Remove(ref _DockFacilities, dockFacility_0);
	}

	public void AddFuelRec(FuelRec fuelRec_0)
	{
		_Fuel.Add(fuelRec_0);
	}

	public void RemoveFuelRec(FuelRec fuelRec_0)
	{
		_Fuel.Remove(fuelRec_0);
	}

	public virtual void DoWithdrawalCleanUp()
	{
		AI.ClearAllThreats();
		AI.PrimaryThreat = null;
	}

	public void NeutralizeMine(UnguidedWeapon unguidedWeapon_0, Sensor sensor_0)
	{
		try
		{
			string text = "";
			ActiveUnit parentPlatform = sensor_0.ParentPlatform;
			if ((IsAircraft || IsShip) && Operators.CompareString(Name, UnitClass, TextCompare: false) != 0)
			{
				text = " (" + UnitClass + ")";
			}
			List<EventTrigger> list = new List<EventTrigger>();
			if (sensor_0.ParentPlatform.GetUnitSide().Contacts_NonAU.Contains(unguidedWeapon_0.ObjectID))
			{
				unguidedWeapon_0.DestroyMe(ref ParentScen, "Mine neutralized");
			}
			else
			{
				foreach (EventTrigger value in parentPlatform.ParentScen.EventTriggers.Values)
				{
					if (value.Type == EventTrigger.EventTriggerType.UnitDetected && ((EventTrigger_UnitDetected)value).GetIsFulfilled(unguidedWeapon_0, parentPlatform, bool_0: true, Contact_Base.IdentificationStatus.KnownClass, Contact_Base.IdentificationStatus.Unknown, null))
					{
						list.Add(value);
					}
				}
				unguidedWeapon_0.DestroyMe(ref ParentScen, "Mine neutralized");
			}
			unguidedWeapon_0.SetCurrentAltitude(bool_0: false, -2f);
			foreach (EventTrigger value2 in ParentScen.EventTriggers.Values)
			{
				if (value2.Type == EventTrigger.EventTriggerType.UnitDestroyed && ((EventTrigger_UnitDestroyed)value2).GetIsFulfilled(unguidedWeapon_0, sensor_0.ParentPlatform))
				{
					list.Add(value2);
				}
			}
			if (list != null && list.Count > 0)
			{
				parentPlatform.ParentScen.FireEvents(list);
			}
			if (unguidedWeapon_0.IsMine)
			{
				unguidedWeapon_0.GetUnitSide().AAR.AddToLosses(unguidedWeapon_0, bool_0: false);
			}
			ParentScen.AddMessage(Name + text + "有中立雷：" + unguidedWeapon_0.Name + " with " + sensor_0.Name, Name + " 中立雷区", LoggedMessage.MessageType.WeaponEndgame, 0, null, GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
			if (sensor_0.ParentPlatform.IsShip && sensor_0.Type == Sensor.Sensor_Type.MineNeutralization_DiverExplosiveCharge)
			{
				sensor_0.TimeToNextScan = GameGeneral.LockRandom_0.Next(600, 10000);
			}
			else if (sensor_0.IsExplosiveMineNeutralizer)
			{
				sensor_0.Destroy(GetUnitSide(), bool_0: false, bool_1: false);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100007", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PreDestructionHousekeeping(bool bool_0, bool bool_1, float float_0, bool bool_2)
	{
		try
		{
			if (!bool_0 && !_DestroyEventsChecked)
			{
				if (!IsShip || (IsShip && bool_1) || !IsShip || !((Ship)this).IsSinking)
				{
					ParentScen.CheckForDestroyEvents(this, float_0);
				}
				_DestroyEventsChecked = true;
			}
			if (AirFacilities_ReadOnly.Length != 0)
			{
				foreach (Aircraft item in AirOps.EmbarkedAircraft_ReadOnly)
				{
					item.Destroy(bool_0, Module_ActiveUnit.CancelTokenizer(this), bool_2, "Destroyed as the object it is landed on is being destroyed", "Host Destruction");
				}
			}
			if (DockFacilities_ReadOnly.Length != 0)
			{
				foreach (ActiveUnit embarkedBoat in DockingOps.EmbarkedBoats)
				{
					embarkedBoat.Destroy(bool_0, Module_ActiveUnit.CancelTokenizer(this), bool_2, "Destroyed as the object it is docked to is being destroyed", "Host Destruction");
				}
			}
			Cargo[] onboardCargo = OnboardCargo;
			Cargo[] array4 = onboardCargo;
			foreach (Cargo cargo in array4)
			{
				if (cargo.CargoObjectStatus != PlatformComponent._ComponentStatus.Destroyed)
				{
					cargo.Destroy(GetUnitSide(), bool_0, Module_ActiveUnit.CancelTokenizer(this));
					GetUnitSide().AAR.AddToLosses(cargo, bool_0: false);
				}
			}
			foreach (PlatformComponent item2 in OrderIssuer())
			{
				if (item2.Status != PlatformComponent._ComponentStatus.Destroyed)
				{
					item2.Destroy(GetUnitSide(), bool_0, Module_ActiveUnit.CancelTokenizer(this));
				}
			}
			Mission[] array = ParentScen.Sides_ReadOnly.SelectMany((Side s) => s.Missions).ToArray();
			Mission[] array5 = array;
			foreach (Mission mission in array5)
			{
				if (!(mission is Strike))
				{
					continue;
				}
				Strike strike = (Strike)mission;
				Contact[] array2 = strike.SpecificTargets.OfType<Contact>().ToArray();
				Contact[] array6 = array2;
				foreach (Contact contact in array6)
				{
					if (contact.ActualUnit == null)
					{
						strike.SpecificTargets.Remove(contact);
					}
					else if (contact.ActualUnit == this)
					{
						strike.SpecificTargets.Remove(contact);
					}
				}
				ActiveUnit[] array3 = strike.SpecificTargets.OfType<ActiveUnit>().ToArray();
				ActiveUnit[] array7 = array3;
				foreach (ActiveUnit activeUnit in array7)
				{
					if (activeUnit == this)
					{
						strike.SpecificTargets.Remove(activeUnit);
					}
				}
			}
			onboardCargo = OnboardCargo;
			Cargo[] array8 = onboardCargo;
			foreach (Cargo cargo2 in array8)
			{
				if (cargo2.Status != PlatformComponent._ComponentStatus.Destroyed)
				{
					cargo2.Destroy(GetUnitSide(), bool_0, cargo2.CurrentType == Cargo.CargoObjectType.Mount);
				}
			}
			foreach (WeaponRec item3 in Weaponry.AllDistinctWeaponsAboard_Actual_WeaponRecs(bool_1: true))
			{
				if (item3.CurrentLoad > 0)
				{
					GetUnitSide().AAR.AddToWeaponsLost(item3.int_0, item3.CurrentLoad);
				}
			}
			ArrayExtensions.Clear(ref _Sensors);
			Mounts.Clear();
			ArrayExtensions.Clear(ref _AirFacilities);
			ArrayExtensions.Clear(ref _DockFacilities);
			ArrayExtensions.Clear(ref OnboardCargo);
			if (SharedMagazines != null)
			{
				Magazine[] gparam_ = SharedMagazines;
				ArrayExtensions.Clear(ref gparam_);
			}
			if (GetUnitSide() != null)
			{
				List<ActiveUnit> list = new List<ActiveUnit>();
				list.AddRange(GetUnitSide().Units);
				List<CommLink> list2 = new List<CommLink>();
				foreach (ActiveUnit item4 in list)
				{
					if (item4 == null)
					{
						continue;
					}
					list2.AddRange(item4.CommStuff.CommLinksEstablished_ReadOnly);
					foreach (CommLink item5 in list2)
					{
						if (item5 == null || item5.CommPartner != this)
						{
							continue;
						}
						item4.CommStuff.DropCommLink(item5);
						if (item4.IsWeapon)
						{
							Weapon weapon = (Weapon)item4;
							if (weapon.DataLinkParent != null)
							{
								weapon.DataLinkParent = null;
								LockRandom lockRandom_ = GameGeneral.LockRandom_0;
								weapon.DoTypeSpecificActions(0f, ref lockRandom_);
							}
						}
					}
					list2.Clear();
				}
			}
			List<ActiveUnit> list3 = new List<ActiveUnit>();
			list3.AddRange(ParentScen.ActiveUnits_List);
			foreach (ActiveUnit item6 in list3.Where((ActiveUnit AU) => AU?.IsPlatform ?? false))
			{
				if (!item6.IsOperating())
				{
					continue;
				}
				if (item6.IsAircraft)
				{
					if (((Aircraft)item6).AirOps.GetAssignedHostUnit() == this)
					{
						((Aircraft)item6).AirOps.PickNewAssignedHost_Nearest();
					}
				}
				else if ((item6.IsShip || item6.IsSubmarine) && item6.DockingOps.GetAssignedHostUnit() == this)
				{
					item6.DockingOps.PickNewAssignedHost_Nearest();
				}
			}
			checked
			{
				if (GetUnitSide() == null)
				{
					if (IsWeapon)
					{
						Side[] sides_ReadOnly = ParentScen.Sides_ReadOnly;
						for (int i = 0; i < sides_ReadOnly.Length; i++)
						{
							sides_ReadOnly[i].RemoveWeaponFromSalvos(ref ParentScen, ref ObjectID);
						}
					}
					else
					{
						Side[] sides_ReadOnly2 = ParentScen.Sides_ReadOnly;
						for (int j = 0; j < sides_ReadOnly2.Length; j++)
						{
							sides_ReadOnly2[j].RemoveUnitFromSalvos(ref ParentScen, ObjectID);
						}
					}
				}
				else if (IsWeapon)
				{
					GetUnitSide().RemoveWeaponFromSalvos(ref ParentScen, ref ObjectID);
				}
				else
				{
					GetUnitSide().RemoveUnitFromSalvos(ref ParentScen, ObjectID);
				}
				if (IsGroupMember())
				{
					GetParentGroup().Units.Remove(ObjectID);
				}
				if (bool_0 || GetUnitSide() == null)
				{
					return;
				}
				if (!IsShip && !IsWeapon && !IsGroup)
				{
					string text = "";
					if (IsAircraft && Operators.CompareString(Name, UnitClass, TextCompare: false) != 0)
					{
						text = " (" + UnitClass + ")";
					}
					ParentScen.AddMessage(Name + text + "已被摧毁！", Name + " 被摧毁！", LoggedMessage.MessageType.UnitLost, 0, ObjectID, GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
				}
				if (!IsWeapon && !IsGroup && !Module_ActiveUnit.CancelTokenizer(this))
				{
					GetUnitSide().AAR.AddToLosses(this, bool_0: false);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100008", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private int ManageIssuer()
	{
		try
		{
			if (!ParentScen.MaxRisingMineRange_meters.HasValue)
			{
				DataTable allWeapons = DBFunctions.GetAllWeapons(ParentScen.DBConnection);
				IEnumerator enumerator = null;
				float num = 0f;
				try
				{
					enumerator = allWeapons.Rows.GetEnumerator();
					while (enumerator.MoveNext())
					{
						DataRow dataRow = (DataRow)enumerator.Current;
						if (Conversions.ToInteger(dataRow["Type"]) != 4008)
						{
							continue;
						}
						Weapon carriedWeapon = ParentScen.Cache_GetWeapon(Conversions.ToInteger(dataRow["ID"])).Warheads[0].GetCarriedWeapon(ParentScen);
						if (carriedWeapon != null)
						{
							if (carriedWeapon.MaxSurfaceRange > num)
							{
								num = carriedWeapon.MaxSurfaceRange;
							}
							if (carriedWeapon.MaxSubsurfaceRange > num)
							{
								num = carriedWeapon.MaxSubsurfaceRange;
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
				if (num == 0f)
				{
					num = 1.5f;
				}
				ParentScen.MaxRisingMineRange_meters = (int)Math.Round(num * 1852f);
			}
			return ParentScen.MaxRisingMineRange_meters.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100009", "");
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
	public virtual int GetSafeDistanceAgainstUnknownMine_meters(bool bool_0)
	{
		if (bool_0)
		{
			return ManageIssuer() * 3;
		}
		return ManageIssuer();
	}

	[SpecialName]
	public virtual int GetSafeDistanceAgainstKnownMineType_meters(Weapon._WeaponType _WeaponType_0, bool bool_0)
	{
		try
		{
			if (_WeaponType_0 == Weapon._WeaponType.RisingMine)
			{
				if (!IsMCMPlatform && !IsMineLayingPlatform)
				{
					if (bool_0)
					{
						return Math.Max(ManageIssuer() * 3, 1000);
					}
					return ManageIssuer();
				}
				if (bool_0)
				{
					return Math.Max((int)Math.Round((double)ManageIssuer() * 0.3), 1000);
				}
				return (int)Math.Round((double)ManageIssuer() * 0.1);
			}
			if (!IsMCMPlatform && !IsMineLayingPlatform)
			{
				if (bool_0)
				{
					return 1000;
				}
				return 400;
			}
			if (bool_0)
			{
				return 1000;
			}
			return 100;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100010", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			if (bool_0)
			{
				ProjectData.ClearProjectError();
				return 1000;
			}
			ProjectData.ClearProjectError();
			return 400;
		}
	}

	public virtual void Destroy(bool bool_0, bool bool_1, bool bool_2, string string_0, string string_1 = null)
	{
		try
		{
			IsBeingDestroyed = true;
			DockingOps.HostDockFacility = null;
			PreDestructionHousekeeping(bool_0, bool_1: false, Damage.DamagePercent, bool_2);
			Side[] sides_ReadOnly = ParentScen.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
			{
				sides_ReadOnly[i].HandleUnitDestruction(this, bool_0);
			}
			foreach (Weapon item in ParentScen.AllWeaponsAlive)
			{
				List<Contact> list = new List<Contact>();
				Contact[] targets_ReadOnly = ((ActiveUnit)item).AI.Targets_ReadOnly;
				Contact[] array = targets_ReadOnly;
				foreach (Contact contact in array)
				{
					if (contact.ActualUnit == this)
					{
						list.Add(contact);
					}
				}
				foreach (Contact item2 in list)
				{
					((ActiveUnit)item).AI.DropTarget(item2);
				}
			}
			foreach (ActiveUnit embarkedBoat in DockingOps.EmbarkedBoats)
			{
				embarkedBoat.Destroy(bool_0, Module_ActiveUnit.CancelTokenizer(this), bool_2, "Destroyed as the object it is docked to is being destroyed", "Host Destruction");
			}
			foreach (Aircraft item3 in AirOps.EmbarkedAircraft_ReadOnly)
			{
				item3.Destroy(bool_0, Module_ActiveUnit.CancelTokenizer(this), bool_2, "Destroyed as the object it is landed on is being destroyed", "Host Destruction");
			}
			if (bool_0)
			{
				DeleteImmediately();
			}
			else if (bool_2)
			{
				ParentScen.DestroyThisUnit(this, string_0, string_1);
			}
			else
			{
				DeleteImmediately();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100011", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected void DeleteImmediately()
	{
		ParentScen.ActiveUnits.Remove(ObjectID);
	}

	private bool RevertIssuer()
	{
		bool result = false;
		try
		{
			foreach (ActiveUnit value in ParentScen.ActiveUnits.Values)
			{
				Contact[] targets_ReadOnly = value.AI.Targets_ReadOnly;
				for (int i = 0; i < targets_ReadOnly.Length; i = checked(i + 1))
				{
					if (targets_ReadOnly[i].ActualUnit == this)
					{
						result = true;
						return true;
					}
				}
				if (value.AI.PrimaryTarget != null && value.AI.PrimaryTarget.ActualUnit == this)
				{
					result = true;
					return true;
				}
			}
			result = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100012", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public virtual void SetThrottle(Throttle throttle_0, float? nullable_0 = null)
	{
		try
		{
			if (ThrottleSetting == throttle_0 && !nullable_0.HasValue && !ParentScen.MinuteIsChangingOnThisPulse)
			{
				return;
			}
			if (throttle_0 == Throttle.External)
			{
				throttle_0 = Throttle.External;
			}
			if ((int)throttle_0 > 4)
			{
				throttle_0 = Throttle.Flank;
			}
			if ((int)throttle_0 < 0)
			{
				throttle_0 = Throttle.FullStop;
			}
			if ((int)throttle_0 > (int)MaxPossibleThrottleSetting)
			{
				throttle_0 = MaxPossibleThrottleSetting;
			}
			ThrottleSetting = throttle_0;
			if (!IsGroup)
			{
				if (!nullable_0.HasValue & (_ThrottleSetting != Throttle.External))
				{
					DesiredSpeed = Kinematics.GetMaximumSpeed(GetCurrentAltitude(), _ThrottleSetting, bool_0: false);
				}
				else if (Kinematics.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
				{
					float? num = nullable_0;
					float num2 = Kinematics.GetMaximumSpeed(GetCurrentAltitude(), throttle_0, bool_0: false);
					bool? flag = (num.HasValue ? new bool?(num.GetValueOrDefault() > num2) : null);
					bool? flag2 = (!flag) ?? flag;
					if (flag2.GetValueOrDefault(true))
					{
						num = nullable_0;
						num2 = Kinematics.GetMinimumSpeed((int)Math.Round(GetCurrentAltitude()), throttle_0, bool_0: false);
						flag = (num.HasValue ? new bool?(num.GetValueOrDefault() < num2) : null);
						if (((!flag) ?? flag).GetValueOrDefault() && flag2.HasValue)
						{
							DesiredSpeed = nullable_0.Value;
							goto IL_0316;
						}
					}
					if (_ThrottleSetting == Throttle.External)
					{
						DesiredSpeed = nullable_0.Value;
					}
					else
					{
						ThrottleSetting = Kinematics.GetThrottleSuitableForThisSpeed(GetCurrentAltitude(), nullable_0.Value);
						num = nullable_0;
						num2 = Kinematics.GetMaximumSpeed(GetCurrentAltitude(), ThrottleSetting, bool_0: false);
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() > num2) : null).GetValueOrDefault())
						{
							DesiredSpeed = Kinematics.GetMaximumSpeed(GetCurrentAltitude(), ThrottleSetting, bool_0: false);
						}
					}
				}
				else
				{
					DesiredSpeed = Kinematics.GetMaximumSpeed(GetCurrentAltitude(), (Throttle)Kinematics.ThrottlePreset, bool_0: false);
				}
			}
			goto IL_0316;
			IL_0316:
			RaiseEvent_ChangedThrottleSetting(this, ThrottleSetting);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100013", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RaiseEvent_ChangedThrottleSetting(ActiveUnit activeUnit_0, Throttle throttle_0)
	{
		databaseVal?.Invoke(activeUnit_0, throttle_0);
	}

	public bool HasMineCountermeasures()
	{
		return MineCountermeasures.Count > 0;
	}

	public bool HasMineCounterWeapons()
	{
		if ((object)GetType() == typeof(Aircraft))
		{
			WeaponRec[] weapons = ((Aircraft)this).Loadout.Weapons;
			WeaponRec[] array = weapons;
			foreach (WeaponRec weaponRec in array)
			{
				if (weaponRec.CurrentLoad > 0)
				{
					Weapon referenceWeapon = weaponRec.GetReferenceWeapon(ParentScen);
					if (referenceWeapon.Type == Weapon._WeaponType.Torpedo && weaponRec.CurrentLoad >= 1 && referenceWeapon.ValidTargets.Mine)
					{
						return true;
					}
				}
			}
		}
		else if ((object)GetType() == typeof(Ship))
		{
			foreach (Weapon item in Weaponry.AllDistinctWeaponsAboard_Actual())
			{
				if (item.Type == Weapon._WeaponType.Torpedo && item.ValidTargets.Mine)
				{
					return true;
				}
			}
		}
		else if ((object)GetType() == typeof(Weapon) && ((Weapon)this).ValidTargets.Mine)
		{
			return true;
		}
		return false;
	}

	public bool HasPassiveSensor()
	{
		return (from theS in Sensors_ReadOnly()
			where !theS.CanBeActive
			select theS).Count() > 0;
	}

	public bool HasActiveCapableSonarSensor()
	{
		bool result = false;
		try
		{
			Sensor[] sensors_Cached = Sensors_Cached;
			Sensor[] array = sensors_Cached;
			foreach (Sensor sensor in array)
			{
				if (sensor.IsSonar && sensor.CanBeActive)
				{
					result = true;
					return true;
				}
			}
			result = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100016", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public bool IsGroupMember()
	{
		return GetParentGroup() != null;
	}

	public bool IsGroupWingman()
	{
		if (IsGroupMember() && !IsGroupLead())
		{
			return true;
		}
		return false;
	}

	public bool IsGroupLead()
	{
		if (IsGroupMember())
		{
			return GetParentGroup().GroupLead == this;
		}
		return false;
	}

	public void SetFlight(Mission.Flight flight_0, int int_0)
	{
		if (IsGroupMember())
		{
			FlightRole = RetrieveFlightRole(int_0);
		}
		else
		{
			FlightRole = Mission.Flight.FlightElement.None;
		}
		Navigator.SetFlight(bool_1: true, flight_0);
	}

	public static Mission.Flight.FlightElement RetrieveFlightRole(int int_0)
	{
		switch (int_0)
		{
		default:
		{
			int num = int_0;
			while (num - 5 > 0 && num != 2 && num != 3 && num != 4 && num != 5 && num != 6)
			{
				num -= 5;
			}
			if (1 == 0)
			{
			}
			Mission.Flight.FlightElement result = num switch
			{
				2 => Mission.Flight.FlightElement.LeadElementWingman, 
				3 => Mission.Flight.FlightElement.SecondElement, 
				4 => Mission.Flight.FlightElement.SecondElementWingman, 
				5 => Mission.Flight.FlightElement.ThirdElement, 
				6 => Mission.Flight.FlightElement.ThirdElementWingman, 
				_ => Mission.Flight.FlightElement.None, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		case 1:
			return Mission.Flight.FlightElement.LeadElement;
		case 2:
			return Mission.Flight.FlightElement.LeadElementWingman;
		case 3:
			return Mission.Flight.FlightElement.SecondElement;
		case 4:
			return Mission.Flight.FlightElement.SecondElementWingman;
		case 5:
			return Mission.Flight.FlightElement.ThirdElement;
		case 6:
			return Mission.Flight.FlightElement.ThirdElementWingman;
		}
	}

	public void SetGroup()
	{
	}

	public void AddMessage(string string_0, string string_1, LoggedMessage.MessageType messageType_0, byte byte_0, bool bool_0, Geopoint_Struct geopoint_Struct_0)
	{
		if (bool_0)
		{
			Message = string_0;
		}
		if (ParentScen != null)
		{
			ParentScen.AddMessage(string_0, string_1, messageType_0, byte_0, ObjectID, GetUnitSide(), geopoint_Struct_0);
		}
	}

	public void RemoveCommDevice(CommDevice commDevice_0)
	{
		ArrayExtensions.Remove(ref _Comms, commDevice_0);
	}

	public virtual void Fuel_Add(float float_0, FuelRec._FuelType _FuelType_0)
	{
		try
		{
			float num = float_0;
			foreach (FuelRec item in Fuel_ReadOnly)
			{
				if (num == 0f)
				{
					break;
				}
				if (item.FuelType == _FuelType_0)
				{
					float num2 = (float)item.MaxQuantity - item.CurrentQuantity;
					if (num2 <= num)
					{
						item.CurrentQuantity = item.MaxQuantity;
						num -= num2;
					}
					else
					{
						item.AddFuel(num);
						num = 0f;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100017", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void Fuel_Subtract(float float_0, FuelRec._FuelType _FuelType_0)
	{
		try
		{
			if (float_0 == 0f)
			{
				return;
			}
			FuelRec fuelRec = (from theFuelrec in Fuel_ReadOnly
				select (theFuelrec) into theFuelrec
				where theFuelrec.FuelType == _FuelType_0
				select theFuelrec).ElementAtOrDefault(0);
			if (fuelRec.CurrentQuantity <= float_0)
			{
				bool flag = fuelRec.CurrentQuantity > 0f;
				fuelRec.CurrentQuantity = 0f;
				SetThrottle(Throttle.FullStop);
				if (flag)
				{
					AddMessage(Name + " (" + Misc.ReadRequest(UnitClass) + "）燃料耗尽！", "单元油料耗尽", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
				}
			}
			else
			{
				fuelRec.SubtractFuel(float_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100018", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void DoFuelConsumption(float float_0)
	{
	}

	public virtual void AttemptToSetNewAssignedHost(ActiveUnit activeUnit_0, bool bool_0 = false, bool bool_1 = false)
	{
		bool num = !activeUnit_0.IsGroup;
		bool flag = false;
		bool flag2 = false;
		if (activeUnit_0.IsGroup)
		{
			if (((Group)activeUnit_0).Type == Group.GroupType.AirBase)
			{
				flag2 = true;
			}
			else
			{
				flag = true;
			}
		}
		if (num || flag2)
		{
			string text = DockingOps.ThisUnitCanHostMe(activeUnit_0);
			if (Operators.CompareString(text, "OK", TextCompare: false) == 0)
			{
				DockingOps.SetAssignedHostUnit(bool_0: false, activeUnit_0);
				if (bool_0)
				{
					AI.ReturnToBase(1f);
				}
				ParentScen.AddMessage(activeUnit_0.Name + "现在是基地" + Name, Name + " 指定了新的基地", LoggedMessage.MessageType.DockingOps, 5, ObjectID, GetUnitSide());
			}
			else
			{
				string string_ = "未能设置" + activeUnit_0.Name + "作为新的基地" + Name + "。原因：" + text;
				if (bool_1)
				{
					GameGeneral.ResolveBridge(string_, GetUnitSide(), "设置基地失败" + Name, GameGeneral.MessageBoxMessageType.Warning);
				}
				ParentScen.AddMessage(string_, "设置基地失败" + Name, LoggedMessage.MessageType.DockingOps, 5, ObjectID, GetUnitSide());
			}
		}
		if (!flag)
		{
			return;
		}
		Module_Unit.Unit unit = null;
		foreach (ActiveUnit value in ((Group)activeUnit_0).Units.Values)
		{
			if (Operators.CompareString(DockingOps.ThisUnitCanHostMe(value), "OK", TextCompare: false) == 0)
			{
				DockingOps.SetAssignedHostUnit(bool_0: false, value);
				unit = value;
				break;
			}
		}
		if (unit == null)
		{
			ParentScen.AddMessage("未能设置" + activeUnit_0.Name + "作为新的基地" + Name, "设置基地失败" + Name, LoggedMessage.MessageType.DockingOps, 5, ObjectID, GetUnitSide());
		}
		else
		{
			ParentScen.AddMessage(activeUnit_0.Name + "现在是基地" + Name, Name + " 指定了新的基地", LoggedMessage.MessageType.DockingOps, 5, ObjectID, GetUnitSide());
		}
	}

	public void GoInoperative()
	{
		try
		{
			ActiveUnit_AI aI = AI;
			ActiveUnit activeUnit_ = this;
			aI.ClearAllTargets(ref activeUnit_);
			Side[] sides_ReadOnly = ParentScen.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
			{
				sides_ReadOnly[i].HandleUnitGoingInoperative(this);
			}
			ActiveUnit activeUnit = (IsAircraft ? ((Aircraft)this).AirOps.CurrentHostUnit : DockingOps.CurrentHostUnit);
			if (activeUnit != null)
			{
				if (activeUnit.CommStuff.IsConnectedToSideNetwork)
				{
					CommStuff.SetIsConnectedToSideNetwork(ActiveUnit_CommStuff.ReasonForGoingOffGrid.None, bool_0: true);
				}
				else if (CommStuff.IsConnectedToSideNetwork)
				{
					ActiveUnit_CommStuff.ReasonForGoingOffGrid reasonForBeingOffGrid = activeUnit.CommStuff.ReasonForBeingOffGrid;
					activeUnit.CommStuff.SetIsConnectedToSideNetwork(ActiveUnit_CommStuff.ReasonForGoingOffGrid.None, bool_0: true);
					activeUnit.CommStuff.SetIsConnectedToSideNetwork(reasonForBeingOffGrid, bool_0: false);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100019", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RemoveSensor(Sensor sensor_0)
	{
		try
		{
			ArrayExtensions.Remove(ref _Sensors, sensor_0);
			foreach (Mount mount in Mounts)
			{
				mount.RemoveSensor(sensor_0);
			}
			Sensors_Cached = null;
			MineCountermeasures = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100020", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void ClearManualOrders()
	{
		AI.ClearManualOrders();
	}

	public void DetachUnit(bool bool_0, bool bool_1, bool bool_2)
	{
		if (IsWeapon || !IsGroupMember())
		{
			return;
		}
		try
		{
			if (IsGroupLead() && GetParentGroup().Units.Count > 1)
			{
				ActiveUnit activeUnit = null;
				if (IsFacility)
				{
					foreach (ActiveUnit value in GetParentGroup().Units.Values)
					{
						if (value != this)
						{
							activeUnit = value;
						}
					}
				}
				else
				{
					double num = 0.0;
					foreach (ActiveUnit item in new List<ActiveUnit>(GetParentGroup().Units.Values))
					{
						if (item != this && (double)item.EmptyWeight > num)
						{
							activeUnit = item;
							num = item.EmptyWeight;
						}
					}
				}
				if (activeUnit != null)
				{
					GetParentGroup().SetGroupLead(activeUnit);
					activeUnit.Status = Status;
					activeUnit.Kinematics.DesiredSpeedOverride = Kinematics.DesiredSpeedOverride;
					activeUnit.Kinematics.DesiredAltitudeOverride = Kinematics.DesiredAltitudeOverride;
					activeUnit.DesiredAltitude = DesiredAltitude;
					activeUnit.DesiredAltitude_AGL = DesiredAltitude_AGL;
					activeUnit.DesiredSpeed = DesiredSpeed;
					activeUnit.SetDesiredAltitude_UseTerrainFollowing(activeUnit, GetDesiredAltitude_UseTerrainFollowing(this));
				}
			}
			if (bool_0)
			{
				string text = "";
				if (IsAircraft && Operators.CompareString(Name, UnitClass, TextCompare: false) != 0)
				{
					text = " (" + UnitClass + ")";
				}
				ParentScen.AddMessage(Name + text + "已脱离群组：" + GetParentGroup().Name, Name + " 分离", LoggedMessage.MessageType.UnitAI, 5, ObjectID, GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
			}
			if (bool_2 && IsAircraft && GetParentGroup().GroupLead != null && GetParentGroup().GroupLead.Navigator.HasPlottedCourse())
			{
				Waypoint[] plottedCourse = GetParentGroup().GroupLead.Navigator.PlottedCourse;
				Waypoint[] array = plottedCourse;
				foreach (Waypoint theAC in array)
				{
					ActiveUnit_Navigator navigator = Navigator;
					Waypoint[] gparam_ = navigator.PlottedCourse;
					ArrayExtensions.Add(ref gparam_, theAC);
					navigator.PlottedCourse = gparam_;
				}
			}
			SetParentGroup(bool_0: false, null);
			if (bool_1)
			{
				Navigator.ClearPlottedCourse();
			}
			Kinematics.DesiredSpeedOverride = null;
			Kinematics.DesiredAltitudeOverride = false;
			Doctrine.ClearCachedParentDoctrine();
			Sensory.vmethod_0(Sensors_Cached);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101262", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool CountClient(double double_0, double double_1, float float_0)
	{
		try
		{
			foreach (NoNavZone noNavZone in GetUnitSide().NoNavZones)
			{
				if (noNavZone.Area.Count == 0 || !noNavZone.IsActive || !noNavZone.GetAffectsThisUnit(this))
				{
					continue;
				}
				if (float_0 == 0.2f)
				{
					if (noNavZone.Area_RefPoints_020deg_ChangeCheck.Count == 0 || noNavZone.FlushDescriptor(noNavZone.Area_RefPoints_020deg_ChangeCheck))
					{
						noNavZone.CalculateAreaWithThresholdAdded(float_0, ref noNavZone.Area_GeoPoints_020deg_Buffered, ref noNavZone.Area_RefPoints_020deg_ChangeCheck);
					}
					if (GeoPoint.IsInsideThisArea(double_0, double_1, noNavZone.Area_GeoPoints_020deg_Buffered))
					{
						return true;
					}
				}
				else if (float_0 == 0.15f)
				{
					if (noNavZone.Area_RefPoints_015deg_ChangeCheck.Count == 0 || noNavZone.FlushDescriptor(noNavZone.Area_RefPoints_015deg_ChangeCheck))
					{
						noNavZone.CalculateAreaWithThresholdAdded(float_0, ref noNavZone.Area_GeoPoints_015deg_Buffered, ref noNavZone.Area_RefPoints_015deg_ChangeCheck);
					}
					if (GeoPoint.IsInsideThisArea(double_0, double_1, noNavZone.Area_GeoPoints_015deg_Buffered))
					{
						return true;
					}
				}
				else if (GeoPoint.IsInsideThisArea(double_0, double_1, noNavZone.Area))
				{
					return true;
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101268", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal bool CustomizeClient()
	{
		try
		{
			if (GetUnitSide().NoNavZones.Count == 0)
			{
				return false;
			}
			if (Navigator.TimeToNextUnitDistanceToNearestNoNavZoneEvaluation <= 0.0)
			{
				float num = float.MaxValue;
				foreach (NoNavZone noNavZone in GetUnitSide().NoNavZones)
				{
					if (noNavZone.Area.Count != 0 && noNavZone.GetAffectsThisUnit(this))
					{
						float num2 = noNavZone.CalcDescriptor(GetLatitude(), GetLongitude(), ParentScen);
						if (num2 < num)
						{
							num = num2;
						}
					}
				}
				if (num < 10f)
				{
					Navigator.TimeToNextUnitDistanceToNearestNoNavZoneEvaluation = 300.0;
					Navigator.CheckNoNavZones_UnitMovementOnEveryPulse = true;
				}
				else
				{
					double num3 = (num - 5f) / (float)Kinematics.GetMaximumSpeed() * 3600f;
					if (num3 > 300.0)
					{
						num3 = 300.0;
					}
					Navigator.TimeToNextUnitDistanceToNearestNoNavZoneEvaluation = num3;
					Navigator.CheckNoNavZones_UnitMovementOnEveryPulse = false;
				}
			}
			if (Navigator.CheckNoNavZones_UnitMovementOnEveryPulse)
			{
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200340", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Navigator.TimeToNextUnitDistanceToNearestNoNavZoneEvaluation = 300.0;
			Navigator.CheckNoNavZones_UnitMovementOnEveryPulse = true;
			ProjectData.ClearProjectError();
			return true;
		}
	}

	private void CloneClient(object object_0, ObservableListModified<Mount> observableListModified_0)
	{
		foreach (Mount item in observableListModified_0.Items)
		{
			productVal?.Invoke(ObjectID, item.ObjectID);
		}
		IsDumbAU = false;
	}

	private void ConnectClient(object object_0, ObservableListModified<Mount> observableListModified_0)
	{
		foreach (Mount item in observableListModified_0.Items)
		{
			_AnnotationVal?.Invoke(ObjectID, item.ObjectID);
		}
		EvaluateIfDumb();
	}

	public void EvaluateIfDumb()
	{
		if ((object)GetType() == typeof(GuidedProjectile))
		{
			IsDumbAU = false;
		}
		else if (IsPalletWeapon)
		{
			IsDumbAU = false;
		}
		else if (Mounts.Count == 0)
		{
			if (base.IsFixedFacility)
			{
				IsDumbAU = true;
			}
			else if (UnitType == GlobalVariables.ActiveUnitType.Facility && ((Facility)this).RepresentsMobileGroundUnit)
			{
				IsDumbAU = false;
			}
			else
			{
				IsDumbAU = Propulsion.Count == 0;
			}
		}
		else
		{
			IsDumbAU = false;
		}
	}

	private void MoveClient(object object_0, ObservableListModified<Engine> observableListModified_0)
	{
		IsDumbAU = false;
		Kinematics.ResetMaxSpeed();
		Kinematics.ResetCachedMaxMinAlt();
		adapterVal = null;
	}

	private void DeleteClient(object object_0, ObservableListModified<Engine> observableListModified_0)
	{
		EvaluateIfDumb();
		Kinematics.ResetMaxSpeed();
		Kinematics.ResetCachedMaxMinAlt();
		adapterVal = null;
	}

	public void TemporarySignatureIncrease_Factor(XSection._SignatureType _SignatureType_0, float float_0, int int_0 = 1)
	{
		if (TemporaryEmissionEM.ContainsKey(_SignatureType_0))
		{
			TemporaryEmissionEM[_SignatureType_0].SignatureMultiplier = float_0;
			TemporaryEmissionEM[_SignatureType_0].SignatureAbsoluteIncrease = 0f;
			TemporaryEmissionEM[_SignatureType_0].TerminationDate = ParentScen.Time;
			TemporaryEmissionEM[_SignatureType_0].TerminationDate.AddSeconds(int_0);
		}
		else
		{
			TemporaryEmissionEM.Add(_SignatureType_0, new Str_TemporaryEmission(float_0, 0f, int_0, this));
		}
	}

	public void TemporarySignatureIncrease_Absolute(XSection._SignatureType _SignatureType_0, float float_0, int int_0 = 1)
	{
		if (TemporaryEmissionEM.ContainsKey(_SignatureType_0))
		{
			TemporaryEmissionEM[_SignatureType_0].SignatureMultiplier = 1f;
			TemporaryEmissionEM[_SignatureType_0].SignatureAbsoluteIncrease = float_0;
			TemporaryEmissionEM[_SignatureType_0].TerminationDate = ParentScen.Time;
			TemporaryEmissionEM[_SignatureType_0].TerminationDate.AddSeconds(int_0);
		}
		else
		{
			TemporaryEmissionEM.Add(_SignatureType_0, new Str_TemporaryEmission(1f, float_0, int_0, this));
		}
	}

	internal bool AddClient()
	{
		if (IsFacility)
		{
			return Kinematics.GetMaximumSpeed() > 0;
		}
		return false;
	}

	internal float DestroyClient(XSection._SignatureType _SignatureType_0, string string_0)
	{
		int num = 0;
		if (Operators.CompareString(string_0, "Factor", TextCompare: false) == 0)
		{
			num = 1;
		}
		if (TemporaryEmissionEM.ContainsKey(_SignatureType_0))
		{
			if (TemporaryEmissionEM[_SignatureType_0].SetSpecification(ParentScen.Time))
			{
				return num;
			}
			if (Operators.CompareString(string_0, "Factor", TextCompare: false) == 0)
			{
				return TemporaryEmissionEM[_SignatureType_0].SignatureMultiplier;
			}
			if (Operators.CompareString(string_0, "Absolute", TextCompare: false) == 0)
			{
				return TemporaryEmissionEM[_SignatureType_0].SignatureAbsoluteIncrease;
			}
		}
		return num;
	}

	internal void ComputeClient(ref ActiveUnit activeUnit_0)
	{
		if (!activeUnit_0.IsActiveUnit || activeUnit_0.IsWeapon)
		{
			return;
		}
		ActiveUnit activeUnit_ = activeUnit_0;
		if (activeUnit_.IsOperating())
		{
			if (activeUnit_0.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)activeUnit_0;
				Aircraft_AirOps airOps = aircraft.AirOps;
				if (airOps.Condition != Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar || airOps.ConditionTimer == 0f)
				{
					airOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
				}
				if (aircraft.Navigator.PlottedCourse.Count() > 0 && aircraft.Status == _ActiveUnitStatus.OnPlottedCourse)
				{
					aircraft.Status = _ActiveUnitStatus.OnPlottedCourse;
				}
				else if (aircraft.Status == _ActiveUnitStatus.Tasked)
				{
					aircraft.Status = _ActiveUnitStatus.Tasked;
				}
				else
				{
					aircraft.Status = _ActiveUnitStatus.Unassigned;
				}
				if (aircraft.FuelState != 0)
				{
					aircraft.FuelState = _ActiveUnitFuelState.IgnoreBingoAndJoker;
				}
				if (aircraft.WeaponState != 0)
				{
					aircraft.WeaponState = _ActiveUnitWeaponState.IgnoreWinchesterAndShotgun;
				}
				if (!Information.IsNothing(airOps.A2AR_Destination))
				{
					airOps.DisconnectFromTanker();
				}
			}
			else if (activeUnit_0.IsShip)
			{
				Ship ship = (Ship)activeUnit_0;
				ActiveUnit_DockingOps dockingOps = ship.DockingOps;
				dockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Underway;
				if (ship.Navigator.PlottedCourse.Count() <= 0)
				{
					ship.Status = _ActiveUnitStatus.Unassigned;
				}
				else
				{
					ship.Status = _ActiveUnitStatus.OnPlottedCourse;
				}
				if (!Information.IsNothing(dockingOps.UNREP_Destination))
				{
					dockingOps.DisconnectFromSupplier();
				}
			}
			else if (activeUnit_0.IsSubmarine)
			{
				Submarine submarine = (Submarine)activeUnit_0;
				ActiveUnit_DockingOps dockingOps2 = submarine.DockingOps;
				dockingOps2.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Underway;
				if (submarine.Navigator.PlottedCourse.Count() <= 0)
				{
					submarine.Status = _ActiveUnitStatus.Unassigned;
				}
				else
				{
					submarine.Status = _ActiveUnitStatus.OnPlottedCourse;
				}
				if (!Information.IsNothing(dockingOps2.UNREP_Destination))
				{
					dockingOps2.DisconnectFromSupplier();
				}
			}
			else if (activeUnit_0.IsGroup)
			{
				RemoveUnitFromMission(ref activeUnit_);
				activeUnit_.Doctrine.ClearCachedParentDoctrine();
				foreach (ActiveUnit value in ((Group)activeUnit_0).Units.Values)
				{
					ActiveUnit activeUnit_2 = value;
					if (activeUnit_2.IsOperating())
					{
						ComputeClient(ref activeUnit_2);
					}
				}
			}
			else
			{
				activeUnit_.Status = _ActiveUnitStatus.Unassigned;
			}
		}
		else
		{
			activeUnit_.Status = _ActiveUnitStatus.Unassigned;
		}
		activeUnit_.ClearManualOrders();
		RemoveUnitFromMission(ref activeUnit_);
		activeUnit_.Doctrine.ClearCachedParentDoctrine();
		activeUnit_.Sensory.vmethod_0(activeUnit_.Sensors_Cached);
		activeUnit_.DesiredTurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
	}

	public void RemoveUnitFromMission(ref ActiveUnit activeUnit_0, bool bool_0 = true)
	{
		string text = "";
		if (activeUnit_0.IsAircraft && Operators.CompareString(activeUnit_0.Name, activeUnit_0.UnitClass, TextCompare: false) != 0)
		{
			text = " (" + activeUnit_0.UnitClass + ")";
		}
		if (Information.IsNothing(activeUnit_0.AssignedMissionOrPackage()))
		{
			if (Information.IsNothing(activeUnit_0.AssignedTaskPool))
			{
				if (bool_0)
				{
					ParentScen.AddMessage(activeUnit_0.Name + text + "没有命令（未分配）", "单元未指定", LoggedMessage.MessageType.UnitAI, 5, activeUnit_0.ObjectID, GetUnitSide(), new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
				}
				return;
			}
			string name = activeUnit_0.AssignedTaskPool.Name;
			Mission mission = activeUnit_0.AssignedMissionOrPackage();
			ActiveUnit obj = activeUnit_0;
			Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
			obj.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
			activeUnit_0.AssignedTaskPool = null;
			if (!Information.IsNothing(mission))
			{
				mission.RemoveFlightsWithoutAircraft(ParentScen, GetUnitSide());
			}
			if (bool_0)
			{
				ParentScen.AddMessage(activeUnit_0.Name + text + "已从任务池中删除：" + name, "单元从任务池中移除", LoggedMessage.MessageType.UnitAI, 5, activeUnit_0.ObjectID, GetUnitSide(), new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
			}
		}
		else
		{
			string name2 = activeUnit_0.AssignedMissionOrPackage().Name;
			Mission mission2 = activeUnit_0.AssignedMissionOrPackage();
			if (activeUnit_0.AI.IsEscort)
			{
				activeUnit_0.AI.IsEscort = false;
			}
			activeUnit_0.Navigator.ClearFlight();
			ActiveUnit obj2 = activeUnit_0;
			Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_2 = Mission.MissionAssignmentAttemptResult.None;
			obj2.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_2);
			activeUnit_0.AssignedTaskPool = null;
			if (!Information.IsNothing(mission2))
			{
				mission2.RemoveFlightsWithoutAircraft(ParentScen, GetUnitSide());
			}
			if (bool_0)
			{
				ParentScen.AddMessage(activeUnit_0.Name + text + "已从任务中删除：" + name2, "单元从任务中移除", LoggedMessage.MessageType.UnitAI, 5, activeUnit_0.ObjectID, GetUnitSide(), new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
			}
		}
	}

	public void UpdateSettlingOnPosition(float float_0)
	{
		Geopoint_Struct geopoint_Struct = new Geopoint_Struct(GetLongitude(), GetLatitude(), GetCurrentAltitude());
		if (!Information.IsNothing(m_RefVal))
		{
			Geopoint_Struct? refVal = m_RefVal;
			if ((refVal.HasValue ? new bool?(refVal.GetValueOrDefault() == geopoint_Struct) : null).GetValueOrDefault())
			{
				SettledTime = Math.Min(SettledTime + float_0, float.MaxValue);
			}
			else
			{
				SettledTime = 0f;
			}
		}
		m_RefVal = geopoint_Struct;
	}

	public static void RefuelIfPossible(Module_Unit.Unit unit_0, IEnumerable<Module_Unit.Unit> ienumerable_0, ref ActiveUnit activeUnit_0, ref Mission mission_0, Scenario scenario_0)
	{
		if (unit_0 == null || ienumerable_0 == null || ienumerable_0.Count() == 0)
		{
			return;
		}
		List<Mission> list_ = null;
		if (mission_0 != null)
		{
			list_ = new List<Mission>();
			list_.Add(mission_0);
		}
		if (activeUnit_0 != null && activeUnit_0.IsGroup)
		{
			Group group = (Group)activeUnit_0;
			if (group.GroupLead == null)
			{
				return;
			}
			activeUnit_0 = group.GroupLead;
		}
		foreach (Module_Unit.Unit item in ienumerable_0)
		{
			Aircraft aircraft = null;
			string string_ = "";
			if (item.IsAircraft)
			{
				aircraft = (Aircraft)item;
				bool bool_ = false;
				Aircraft_AirOps airOps = aircraft.AirOps;
				GeoPoint geoPoint_ = aircraft.AI.LoginClient();
				bool bool_2 = true;
				bool bool_3 = false;
				if (!airOps.AssetProxy(geoPoint_, Doctrine._UnderwayRefuelAndReplenishmentSelection.PickNearest, ref bool_2, bool_1: false, ref activeUnit_0, ref list_, ref string_, ref bool_3, ref bool_) && Operators.CompareString(string_, "", TextCompare: false) != 0)
				{
					string text = "";
					if (Operators.CompareString(aircraft.Name, aircraft.UnitClass, TextCompare: false) != 0)
					{
						text = " (" + aircraft.UnitClass + ")";
					}
					scenario_0.AddMessage("飞机" + aircraft.Name + text + "无法加油。原因：" + string_, "飞机无法加油", LoggedMessage.MessageType.AirOps, 5, aircraft.ObjectID, item.GetUnitSide(), new Geopoint_Struct(aircraft.GetLongitude(), aircraft.GetLatitude()));
				}
				aircraft.AI.EvaluateUnitStatus(0f, bool_0: false, bool_1: false);
			}
			else if (item.IsGroup)
			{
				Group group2 = (Group)item;
				if (group2.Type == Group.GroupType.AirGroup && !Information.IsNothing(((Group)item).GroupLead))
				{
					Aircraft aircraft2 = (Aircraft)((Group)item).GroupLead;
					bool bool_4 = false;
					Aircraft_AirOps airOps2 = aircraft2.AirOps;
					GeoPoint geoPoint_2 = aircraft2.AI.LoginClient();
					bool bool_5 = true;
					bool bool_6 = false;
					if (airOps2.AssetProxy(geoPoint_2, Doctrine._UnderwayRefuelAndReplenishmentSelection.PickNearest, ref bool_5, bool_1: false, ref activeUnit_0, ref list_, ref string_, ref bool_6, ref bool_4))
					{
						Aircraft a2AR_Destination = aircraft2.AirOps.A2AR_Destination;
						if (!Information.IsNothing(a2AR_Destination))
						{
							foreach (ActiveUnit value in group2.Units.Values)
							{
								if (value != aircraft2 && value.Status != _ActiveUnitStatus.Refuelling && value.IsOperating() && value != a2AR_Destination)
								{
									Aircraft_AirOps obj = (Aircraft_AirOps)value.AirOps;
									value.Status = _ActiveUnitStatus.HeadingToRefuelPoint;
									obj.Condition = Aircraft_AirOps._AirOpsCondition.ManoeuveringToRefuel;
									obj.A2AR_Destination = a2AR_Destination;
								}
							}
						}
					}
					else if (Operators.CompareString(string_, "", TextCompare: false) != 0)
					{
						scenario_0.AddMessage("飞机编队" + group2.Name + "无法加油。原因：" + string_, "飞机无法加油", LoggedMessage.MessageType.AirOps, 5, aircraft2.ObjectID, group2.GetUnitSide(), new Geopoint_Struct(aircraft2.GetLongitude(), aircraft2.GetLatitude()));
					}
				}
				group2.AI.EvaluateUnitStatus(0f, bool_0: false, bool_1: false);
			}
			if (item.IsBoat)
			{
				(ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP, string) tuple = ((ActiveUnit)item).DockingOps.IncludeDic(((ActiveUnit)item).AI.LoginClient(), activeUnit_0, list_, bool_0: false, 100);
				if (tuple.Item1 != ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success && Operators.CompareString(tuple.Item2, string.Empty, TextCompare: false) != 0)
				{
					GameGeneral.ResolveBridge(tuple.Item2, item.GetUnitSide(), "无法补给");
					scenario_0.AddMessage("单元" + item.Name + "不能补给。原因：" + tuple.Item2, "单元" + item.Name + " 无法补给", LoggedMessage.MessageType.DockingOps, 5, item.ObjectID, item.GetUnitSide(), new Geopoint_Struct(item.GetLongitude(), item.GetLatitude()));
				}
				((ActiveUnit)item).AI.EvaluateUnitStatus(0f, bool_0: false, bool_1: false);
			}
			else if (item.IsFacility && !((Facility)item).IsFixedFacility)
			{
				(ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP, string) tuple2 = ((ActiveUnit)item).DockingOps.IncludeDic(((ActiveUnit)item).AI.LoginClient(), activeUnit_0, list_, bool_0: false, 100, ActiveUnit_DockingOps.ResupplyRequest.Fuel);
				if (tuple2.Item1 != ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success && Operators.CompareString(tuple2.Item2, string.Empty, TextCompare: false) != 0)
				{
					GameGeneral.ResolveBridge(tuple2.Item2, item.GetUnitSide(), "无法补给");
					scenario_0.AddMessage("单元" + item.Name + " 无法补给，原因：" + tuple2.Item2, "单元" + item.Name + " 无法补给", LoggedMessage.MessageType.DockingOps, 5, item.ObjectID, item.GetUnitSide(), new Geopoint_Struct(item.GetLongitude(), item.GetLatitude()));
				}
				((ActiveUnit)item).AI.EvaluateUnitStatus(0f, bool_0: false, bool_1: false);
			}
			else if (item.IsMobileGroundUnit)
			{
				(ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP, string) tuple3 = ((ActiveUnit)item).DockingOps.IncludeDic(((ActiveUnit)item).AI.LoginClient(), activeUnit_0, list_, bool_0: false, 100, ActiveUnit_DockingOps.ResupplyRequest.Fuel);
				if (tuple3.Item1 != ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success && Operators.CompareString(tuple3.Item2, string.Empty, TextCompare: false) != 0)
				{
					GameGeneral.ResolveBridge(tuple3.Item2, item.GetUnitSide(), "无法补给");
					scenario_0.AddMessage("单元" + item.Name + " 无法补给，原因：" + tuple3.Item2, "单元" + item.Name + " 无法补给", LoggedMessage.MessageType.DockingOps, 5, item.ObjectID, item.GetUnitSide(), new Geopoint_Struct(item.GetLongitude(), item.GetLatitude()));
				}
				((ActiveUnit)item).AI.EvaluateUnitStatus(0f, bool_0: false, bool_1: false);
			}
			if (!item.IsGroup)
			{
				continue;
			}
			Group group3 = (Group)item;
			if (group3.Type != 0)
			{
				List<string> list = new List<string>();
				foreach (ActiveUnit value2 in group3.Units.Values)
				{
					(ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP, string) tuple4 = value2.DockingOps.IncludeDic(value2.AI.LoginClient(), activeUnit_0, list_, bool_0: false, 100);
					if (tuple4.Item1 != ActiveUnit_DockingOps.ResultOfAttemptToScheduleUNREP.Success && Operators.CompareString(tuple4.Item2, string.Empty, TextCompare: false) != 0)
					{
						scenario_0.AddMessage("单元" + value2.Name + "不能补给。原因：" + tuple4.Item2, "单元" + item.Name + " 无法补给", LoggedMessage.MessageType.AirOps, 5, value2.ObjectID, value2.GetUnitSide(), new Geopoint_Struct(value2.GetLongitude(), value2.GetLatitude()));
						list.Add(value2.Name + ": " + tuple4.Item2);
					}
				}
				if (list.Count > 0)
				{
					GameGeneral.ResolveBridge(string.Join("\r\n", list), item.GetUnitSide(), "编队中的一些单元无法进行补给");
				}
			}
			group3.AI.EvaluateUnitStatus(0f, bool_0: false, bool_1: false);
		}
	}

	internal bool PatchClient()
	{
		if ((Latitude_old != GetLatitude()) | (Longitude_old != GetLongitude()) | (base.Altitude_old != GetCurrentAltitude()))
		{
			return true;
		}
		return false;
	}

	[CompilerGenerated]
	private bool SelectClient(Weapon weapon_0)
	{
		if (weapon_0.FiringParent == this)
		{
			return weapon_0.Flags.TerminalIllumination;
		}
		return false;
	}

	[CompilerGenerated]
	private bool CallClient(Weapon weapon_0)
	{
		if (weapon_0.FiringParent == this && (weapon_0.Flags.TerminalIllumination || weapon_0.Flags.IlluminateAtLaunch))
		{
			return weapon_0.AI.PrimaryTarget != null;
		}
		return false;
	}

	[CompilerGenerated]
	private double LogoutClient(Weapon weapon_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(this, weapon_0);
	}
}
