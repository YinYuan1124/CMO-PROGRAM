using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml;
using Command_Core.DAL;
using DarkUI.Collections;
using Easy.Common;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class Weapon : ActiveUnit, IFlier
{
	public delegate void WeaponImpactEventHandler(Scenario theScen, Weapon theWeapon, Module_Unit.Unit theTarget, bool DirectHit);

	internal enum WeaponAttitudeControlType
	{
		Undefined,
		AerodynamicOnly,
		NonAerodynamicOnly,
		Combined
	}

	public enum _WeaponType : short
	{
		None = 1001,
		GuidedWeapon = 2001,
		Rocket = 2002,
		IronBomb = 2003,
		Gun = 2004,
		Decoy_Expendable = 2005,
		Decoy_Towed = 2006,
		Decoy_Vehicle = 2007,
		TrainingRound = 2008,
		Dispenser = 2009,
		ContactBomb_Suicide = 2010,
		ContactBomb_Sabotage = 2011,
		GuidedProjectile = 2012,
		UAV_Expendable = 2014,
		SensorPod = 3001,
		DropTank = 3002,
		BuddyStore = 3003,
		FerryTank = 3004,
		Torpedo = 4001,
		DepthCharge = 4002,
		Sonobuoy = 4003,
		BottomMine = 4004,
		MooredMine = 4005,
		FloatingMine = 4006,
		MovingMine = 4007,
		RisingMine = 4008,
		DriftingMine = 4009,
		AttachedMine = 4010,
		DummyMine = 4011,
		HeliTowedPackage = 4101,
		Aircraft = 4102,
		Ship = 4103,
		Submarine = 4104,
		Satellite = 4105,
		GroundUnit = 4106,
		BallisticMissile = 5000,
		RV = 5001,
		PalletWeapon = 5002,
		Laser = 6001,
		Microwave = 6002,
		LaserDazzler = 6003,
		HGV = 8001,
		HypersonicCruiseMissile = 8003,
		Cargo = 9001,
		Troops = 9002,
		Paratroops = 9003
	}

	public enum WeaponGuidanceType : byte
	{
		SemiActive = 0,
		Inertial_Plus_SemiActive = 1,
		Datalink_Plus_SemiActive = 2,
		Passive = 4,
		Inertial_Plus_Passive = 5,
		DataLink_Plus_Passive = 6,
		Active = 7,
		Datalink_Plus_Active = 8,
		Inertial_Plus_Active = 9,
		CommandGuided_Datalinked = 10,
		TVM = 11,
		BeamRiding = 12,
		Inertial = 13,
		SemiActive_Plus_Active = 14,
		TimesharedSemiActive_Plus_Active = 15
	}

	public enum WeaponSearchPatternType : byte
	{
		None,
		Snake,
		Circle
	}

	public enum DetonationMedium : byte
	{
		Air,
		Surface,
		Underwater,
		Underground,
		Space
	}

	public struct WeaponFlags
	{
		public enum AttitudeControlEnum
		{
			None,
			Aerodynamic,
			NonAerodynamic,
			Combined
		}

		public bool IlluminateAtLaunch;

		public bool LauncherOccupiedDuringGuidance;

		public bool TerminalIllumination;

		public bool SupportsBuddyIllumination;

		public bool HomeOnJam;

		public bool SternChase_AAM;

		public bool RearAspect_AAM;

		public bool AllAspect_AAM;

		public bool HOB_AAM;

		public bool NoDivingTargetMod;

		public bool CapableVsSeaskimmer;

		public bool ARMTargetMemory;

		public bool LoiterCapability;

		public bool ParachuteLoiter;

		public bool SearchPattern;

		public bool DriveThroughLogic;

		public bool BearingOnlyLaunch;

		public bool IsBallisticMissile;

		public bool IsMultiStageMissile;

		public bool TerrainFollowing;

		public bool C_RAM;

		public bool LOAL;

		public bool LOAL_CEC;

		public bool Pod_TerrainAvoidance;

		public bool Pod_TerrainFollowing;

		public bool Pod_DayOnlyNavigation;

		public bool Pod_DayOnlyNavigationAttack;

		public bool Pod_NightNavigation;

		public bool Pod_NightNavigationAttack;

		public bool Pod_ReconDayOnly;

		public bool Pod_ReconNight;

		public bool Navigation_INS;

		public bool Navigation_INS_GPS;

		public bool Navigation_TERCOM;

		public bool Navigation_AltitudeControl;

		public bool PreBriefedTargetOnly;

		public bool UsesImagingSeeker;

		public bool Mine_ContactFuze;

		public bool Mine_SimpleMagneticFuze;

		public bool Mine_TotalFieldMagnetometerFuze;

		public bool Mine_PassiveBroadBandAcousticFuze;

		public bool Mine_PassiveNarrowBandAcousticFuze;

		public bool Mine_PressureFuze;

		public bool Mine_SeismicFuze;

		public bool Mine_DelayCounter;

		public bool Mine_ArmingDelay;

		public bool Mine_TargetDiscriminationAndIdentification;

		public bool Mine_RemoteControlled;

		public bool Warhead_SingleRV;

		public bool Warhead_MRV;

		public bool Warhead_MIRV;

		public bool CapableVsMobileTarget;

		public bool IsRetardedWeapon;

		public bool Torpedo_StraightRunning;

		public bool Torpedo_WakeHoming;

		public bool Torpedo_StraightRunningTimeDetonation;

		public bool Torpedo_PatternRunning;

		public bool LevelCruiseFlight;

		public bool TerminalManeuver_PopUp;

		public bool TerminalManeuver_ZigZag;

		public bool TerminalManeuver_Random;

		public bool ReAttack_Capability;

		public AttitudeControlEnum AttitudeControl;

		public bool Fuze_Impact;

		public bool Fuze_Barometric_Altimeter;

		public bool Fuze_Proximity;

		public bool Fuze_Combination;

		public bool Fuze_ShockFactor_Under_Keel_Optimized;
	}

	public enum ActionToUndertake
	{
		None,
		GoAutonomous,
		SelfDestruct
	}

	public enum WeaponSpecialMode
	{
		None,
		HighAltitudeDetonation
	}

	[CompilerGenerated]
	private sealed class StrategyDispatcherList
	{
		public Weapon Me;

		public Warhead Local_theWH;

		internal bool InvokeInterruptibleParam(WeaponRec theCW)
		{
			return theCW.GetReferenceWeapon(Me.ParentScen).DBID == Local_theWH.GetCarriedWeapon(Me.ParentScen).DBID;
		}

		internal bool SetupInterruptibleParam(Warhead theW)
		{
			return theW.GetCarriedWeapon(Me.ParentScen).DBID == Local_theWH.GetCarriedWeapon(Me.ParentScen).DBID;
		}
	}

	[CompilerGenerated]
	private sealed class SerializerDecoratorEntry
	{
		public Weapon Me;

		public Warhead Local_theWH;

		internal bool ExcludeInterruptibleParam(WeaponRec theCW)
		{
			return theCW.GetReferenceWeapon(Me.ParentScen).DBID == Local_theWH.GetCarriedWeapon(Me.ParentScen).DBID;
		}

		internal bool IncludeInterruptibleParam(Warhead w)
		{
			return w.GetCarriedWeapon(Me.ParentScen).DBID == Local_theWH.GetCarriedWeapon(Me.ParentScen).DBID;
		}
	}

	[CompilerGenerated]
	private sealed class InterpreterRuleWatcher
	{
		public Contact theTarget;

		public int targetRadarID;

		internal bool SearchInterruptibleParam(ActiveUnit theW)
		{
			if (theW.AI.PrimaryTarget == theTarget)
			{
				return ((Weapon)theW).ARM_SpecifiedEMission.Key == targetRadarID;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RefDecoratorEntry
	{
		public Weapon Me;

		public Side Local_theSide;

		public Contact Local_theTarget;

		internal int EnableInterruptibleParam(int theCandidateKey)
		{
			return Me.ReflectReponse(Local_theSide, Local_theTarget, theCandidateKey);
		}
	}

	[CompilerGenerated]
	private sealed class AccountCollectionRecord
	{
		public Contact theTarget;

		public Weapon _003C_003E4__this;

		internal double ChangeInterruptibleParam(ActiveUnit theAU0)
		{
			return Module_Unit.RangeToPoint_Horiz_Angular(theAU0, new GeoPoint(theTarget.GetLongitude(), theTarget.GetLatitude()));
		}
	}

	[CompilerGenerated]
	private sealed class ProcItem
	{
		public Sensor sensor;

		public AccountCollectionRecord CS_0024_003C_003E8__locals1;

		internal bool InitInterruptibleParam(ActiveUnit theAU)
		{
			ActiveUnit_Sensory sensory = theAU.Sensory;
			Contact theTarget = CS_0024_003C_003E8__locals1.theTarget;
			Weapon _003C_003E4__this = CS_0024_003C_003E8__locals1._003C_003E4__this;
			ref Sensor sensor_ = ref sensor;
			bool? nullable_ = null;
			bool? nullable_2 = null;
			LOSCheckResult? nullable_3 = null;
			bool? nullable_4 = null;
			return sensory.CanIlluminateThisContactForThisWeapon(theTarget, _003C_003E4__this, ref sensor_, ref nullable_, ref nullable_2, ref nullable_3, ref nullable_4);
		}
	}

	[CompilerGenerated]
	private sealed class StructSetter
	{
		public Contact theTarget;

		public Weapon _003C_003E4__this;

		internal double CheckInterruptibleParam(ActiveUnit theAU0)
		{
			return Module_Unit.RangeToPoint_Horiz_Angular(theAU0, new GeoPoint(theTarget.GetLongitude(), theTarget.GetLatitude()));
		}
	}

	[CompilerGenerated]
	private sealed class ReponseDefinitionSpec
	{
		public Sensor sensor;

		public StructSetter CS_0024_003C_003E8__locals1;

		internal bool ConcatInterruptibleParam(ActiveUnit theAU)
		{
			ActiveUnit_Sensory sensory = theAU.Sensory;
			Contact theTarget = CS_0024_003C_003E8__locals1.theTarget;
			Weapon _003C_003E4__this = CS_0024_003C_003E8__locals1._003C_003E4__this;
			ref Sensor sensor_ = ref sensor;
			bool? nullable_ = null;
			bool? nullable_2 = null;
			LOSCheckResult? nullable_3 = null;
			bool? nullable_4 = null;
			return sensory.CanIlluminateThisContactForThisWeapon(theTarget, _003C_003E4__this, ref sensor_, ref nullable_, ref nullable_2, ref nullable_3, ref nullable_4);
		}
	}

	public _WeaponType Type;

	private GlobalVariables.TechGenerationClass listenerReader;

	public float Span;

	public float Diameter;

	public int CEP_Surface_Nominal;

	private int configReader;

	public int CEP_Land_Nominal;

	private int m_RegistryReader;

	public float CruiseAltitude_AGL;

	public float CruiseAltitude_ASL;

	public int Waypoints;

	public int IlluminationTime;

	public int AirPOK;

	public int SurfPOK;

	public int LandPOK;

	public int SubPOK;

	public int MaxLaunchSpeed;

	public int MinLaunchSpeed;

	public float MaxAirRange;

	public float MinAirRange;

	public float MaxSurfaceRange;

	public float MinSurfaceRange;

	public float MaxLandRange;

	public float MinLandRange;

	public float MaxSubsurfaceRange;

	public float MinSubsurfaceRange;

	public float MinLaunchAlt_AGL;

	public float MaxLaunchAlt_AGL;

	public float MinTargetAlt_AGL;

	public float MaxTargetAlt_AGL;

	public float MinLaunchAlt_ASL;

	public float MaxLaunchAlt_ASL;

	public float MinTargetAlt_ASL;

	public float MaxTargetAlt_ASL;

	public int MinTargetSpeed;

	public int MaxTargetSpeed;

	public float SnapUpDown;

	public string TextDescription;

	public WeaponTargets ValidTargets;

	public Warhead[] Warheads;

	public List<int> Directors;

	protected float _BlindTime;

	protected float _DatalinkRetargetTime;

	public WeaponFlags Flags;

	private ActiveUnit m_DefinitionReader;

	protected string _FiringParent_ID;

	private ActiveUnit valReader;

	protected string _DataLinkParent_ID;

	public WeaponSearchPatternType SearchPatternType;

	private WeaponGuidanceType? m_WrapperReader;

	public GeoPoint LaunchPoint;

	public float TimeSinceLaunch;

	public float TimeSinceBurnout;

	internal float m_ObserverReader;

	public bool CanActAsSensor;

	private Sensor issuerReader;

	protected string _SensorIlluminatingForMe_ObjectID;

	public KeyValuePair<int, EmissionContainer> ARM_SpecifiedEMission;

	public bool ARM_SpecifiedEmissionIsMandatory;

	internal bool clientReader;

	internal bool dicReader;

	[AccessedThroughProperty("WeaponWeapons")]
	[CompilerGenerated]
	private ObservableList<WeaponRec> m_ConsumerReader;

	public List<WeaponSpecialMode> ValidSpecialModes;

	internal bool _FacadeReader;

	private float _ProxyReader;

	public int TotalBurnTime;

	public int? FlightEndurance;

	public Lazy<bool> IsMIRVedMissile;

	public Lazy<bool> IsMRVedMissile;

	public Lazy<bool> UsesBoostCoastModel;

	public Lazy<bool> IsNuke;

	protected Weapon_Navigator _Navigator;

	private Weapon_AI m_ReaderReader;

	private Weapon_Kinematics m_PropertyReader;

	private Weapon_Sensory importerReader;

	private Weapon_CommStuff repositoryReader;

	private Weapon_Damage _BridgeReader;

	protected ActiveUnit _IlluminatorUnit;

	internal bool _InvocationReader;

	public const float ParachuteLoiterPitch = -85f;

	public const float ParachuteLoiterDescentMetersPerSecond = 50f;

	internal int classReader;

	private bool? _RequestReader;

	private bool m_ValueReader;

	private bool tokenizerReader;

	private bool? stubReader;

	private bool? m_WriterReader;

	private bool? specificationReader;

	private bool? m_WatcherReader;

	public Lazy<bool> HasRVs;

	public static float StandOffMaxRange;

	[CompilerGenerated]
	private static WeaponImpactEventHandler reponseReader;

	public virtual ObservableList<WeaponRec> WeaponWeapons
	{
		[CompilerGenerated]
		get
		{
			return m_ConsumerReader;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ConsumerReader = value;
		}
	}

	public override bool UseAerialUnitUI
	{
		get
		{
			if (!base.IsMobileDecoy_Air && !base.isUAV)
			{
				return false;
			}
			return true;
		}
	}

	public override bool SupportsAltitude_Control => Flags.Navigation_AltitudeControl;

	public override bool SupportsAttitude_Pitch
	{
		get
		{
			if (!tokenizerReader)
			{
				m_ValueReader = Type == _WeaponType.RV || Type == _WeaponType.GuidedWeapon || IsBallisticMissile || IsPalletWeapon;
				tokenizerReader = true;
			}
			return m_ValueReader;
		}
	}

	public override float DesiredPitch
	{
		get
		{
			return base.DesiredPitch;
		}
		set
		{
			base.DesiredPitch = value;
		}
	}

	public GlobalVariables.TechGenerationClass TechGeneration
	{
		get
		{
			if (listenerReader == GlobalVariables.TechGenerationClass.None && base.Sensors_Cached.Length != 0)
			{
				listenerReader = base.Sensors_Cached[0].TechGeneration;
			}
			return listenerReader;
		}
		set
		{
			listenerReader = value;
		}
	}

	internal virtual bool IsHGV => Type == _WeaponType.HGV;

	public Sensor[] TerminalGuidingSensors
	{
		get
		{
			switch (Guidance)
			{
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return null;
			case WeaponGuidanceType.SemiActive:
			case WeaponGuidanceType.Inertial_Plus_SemiActive:
			case WeaponGuidanceType.Datalink_Plus_SemiActive:
			case WeaponGuidanceType.CommandGuided_Datalinked:
			case WeaponGuidanceType.TVM:
			case WeaponGuidanceType.BeamRiding:
				return new Sensor[1] { SensorProvidingFireControlForMe };
			case WeaponGuidanceType.Inertial:
				return null;
			case WeaponGuidanceType.Passive:
			case WeaponGuidanceType.Inertial_Plus_Passive:
			case WeaponGuidanceType.DataLink_Plus_Passive:
			case WeaponGuidanceType.Active:
			case WeaponGuidanceType.Datalink_Plus_Active:
			case WeaponGuidanceType.Inertial_Plus_Active:
			case WeaponGuidanceType.SemiActive_Plus_Active:
			case WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
				return _Sensors;
			}
		}
	}

	public List<string> ValidTargets_Description
	{
		get
		{
			List<string> list = new List<string>();
			if (ValidTargets.Aircraft)
			{
				list.Add("Aircraft");
			}
			if (ValidTargets.Helicopter)
			{
				list.Add("Helicopters");
			}
			if (ValidTargets.Submarine)
			{
				list.Add("Submarines");
			}
			if (ValidTargets.SurfaceVessel)
			{
				list.Add("水面舰艇");
			}
			if (ValidTargets.LandStructure_Hard)
			{
				list.Add("地面结构（硬）");
			}
			if (ValidTargets.LandStructure_Soft)
			{
				list.Add("地面结构（软）");
			}
			if (ValidTargets.MobileTarget_Hard)
			{
				list.Add("移动单元（硬）");
			}
			if (ValidTargets.MobileTarget_Soft)
			{
				list.Add("移动单元（软）");
			}
			if (ValidTargets.Radar)
			{
				list.Add("Radars");
			}
			if (ValidTargets.Runway)
			{
				list.Add("Runways");
			}
			if (ValidTargets.Mine)
			{
				list.Add("Mines");
			}
			if (ValidTargets.Missile)
			{
				list.Add("导弹和\u200b\u200b制导炸弹");
			}
			if (ValidTargets.Torpedo)
			{
				list.Add("Torpedoes");
			}
			return list;
		}
	}

	public string Type_Description => Misc.ForgotRequest(Type);

	public override GlobalVariables.ActiveUnitType UnitType => GlobalVariables.ActiveUnitType.Weapon;

	public override CommDevice[] Comms_ReadOnly
	{
		get
		{
			if (Type == _WeaponType.Sonobuoy)
			{
				return _Comms;
			}
			return base.Comms_ReadOnly;
		}
	}

	public bool IsLongFlightCruiseMissile
	{
		get
		{
			if (base.IsMissile && (IsASuW_Land || IsASuW_Naval) && CruiseAltitude_AGL != 0f && Propulsion.Count > 0 && Propulsion[0].AltBands.Length == 1 && Fuel_ReadOnly[0].MaxQuantity > 600)
			{
				return true;
			}
			return false;
		}
	}

	public bool SupportsWaypoints
	{
		get
		{
			if (!IsHGV && !InterruptReponse())
			{
				if (Type == _WeaponType.GuidedWeapon)
				{
					if (Propulsion.Count > 0 && Propulsion[0].Type == Engine.EngineType.WeaponCoast && !IsDecoy)
					{
						return false;
					}
					if ((IsASuW_Land || IsASuW_Naval) && Waypoints > 0)
					{
						return true;
					}
				}
				else if (IsDecoy || base.isUAV)
				{
					return Waypoints > 0;
				}
				return false;
			}
			return true;
		}
	}

	public bool IsChaffBundle
	{
		get
		{
			if (!specificationReader.HasValue)
			{
				specificationReader = Type == _WeaponType.Decoy_Expendable && Name.ToLower().Contains("chaff");
			}
			return specificationReader.Value;
		}
	}

	public bool IsMine
	{
		get
		{
			_WeaponType type = Type;
			if ((uint)(type - 4004) > 5u && type != _WeaponType.DummyMine)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsUnguidedBallisticWeapon
	{
		get
		{
			if (Guidance == WeaponGuidanceType.Inertial)
			{
				switch (Type)
				{
				default:
					return false;
				case _WeaponType.Rocket:
				case _WeaponType.IronBomb:
				case _WeaponType.Gun:
				case _WeaponType.DepthCharge:
				case _WeaponType.Sonobuoy:
				case _WeaponType.BottomMine:
				case _WeaponType.MooredMine:
				case _WeaponType.FloatingMine:
				case _WeaponType.MovingMine:
				case _WeaponType.RisingMine:
				case _WeaponType.DriftingMine:
				case _WeaponType.RV:
				case _WeaponType.Cargo:
				case _WeaponType.Troops:
				case _WeaponType.Paratroops:
					return true;
				}
			}
			return false;
		}
	}

	public new bool IsPalletWeapon => Type == _WeaponType.PalletWeapon;

	public float DP_Total
	{
		get
		{
			float num = 0f;
			Warhead[] warheads = Warheads;
			Warhead[] array = warheads;
			foreach (Warhead warhead in array)
			{
				num += warhead.DP;
			}
			return num;
		}
	}

	public float MaxRange_NoTargetType => Math.Max(MaxAirRange, Math.Max(MaxSurfaceRange, Math.Max(MaxLandRange, MaxSubsurfaceRange)));

	public float MinRange_NoTargetType => Math.Max(MinAirRange, Math.Max(MinSurfaceRange, Math.Max(MinLandRange, MinSubsurfaceRange)));

	public float AcceptableCrossRangeAmbiguity
	{
		get
		{
			try
			{
				switch (Guidance)
				{
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new NotImplementedException();
				case WeaponGuidanceType.Inertial_Plus_SemiActive:
				case WeaponGuidanceType.Datalink_Plus_SemiActive:
				case WeaponGuidanceType.Passive:
				case WeaponGuidanceType.Inertial_Plus_Passive:
				case WeaponGuidanceType.DataLink_Plus_Passive:
				case WeaponGuidanceType.Active:
				case WeaponGuidanceType.Datalink_Plus_Active:
				case WeaponGuidanceType.Inertial_Plus_Active:
					if (_Sensors.Length == 0)
					{
						return 0f;
					}
					return _Sensors.OrderByDescending((Sensor theS) => theS.Swath_Total).ElementAtOrDefault(0).Swath_Total;
				case WeaponGuidanceType.Inertial:
					if (Warheads.Length == 0)
					{
						return 0f;
					}
					if (Warheads[0].Type == Warhead.WarheadType.Weapon)
					{
						Weapon carriedWeapon = Warheads[0].GetCarriedWeapon(ParentScen);
						if (carriedWeapon._Sensors.Length != 0)
						{
							return carriedWeapon._Sensors[0].Swath_Total;
						}
						if (carriedWeapon.Warheads.Length == 0)
						{
							return 0f;
						}
						if (carriedWeapon.Warheads[0].IsExplosive)
						{
							DetonationMedium detonationMedium_;
							switch (carriedWeapon.Type)
							{
							default:
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								throw new NotImplementedException();
							case _WeaponType.GuidedWeapon:
							case _WeaponType.Rocket:
							case _WeaponType.IronBomb:
							case _WeaponType.Gun:
							case _WeaponType.GuidedProjectile:
							case _WeaponType.BallisticMissile:
							case _WeaponType.RV:
							case _WeaponType.HGV:
								detonationMedium_ = DetonationMedium.Air;
								break;
							case _WeaponType.Torpedo:
							case _WeaponType.DepthCharge:
							case _WeaponType.BottomMine:
							case _WeaponType.MooredMine:
							case _WeaponType.FloatingMine:
							case _WeaponType.MovingMine:
							case _WeaponType.RisingMine:
							case _WeaponType.DriftingMine:
								detonationMedium_ = DetonationMedium.Underwater;
								break;
							}
							return Explosion.GetCutoffRange_Blast_nm(carriedWeapon.Warheads[0].DP, detonationMedium_);
						}
					}
					return 0f;
				case WeaponGuidanceType.SemiActive:
				case WeaponGuidanceType.CommandGuided_Datalinked:
				case WeaponGuidanceType.TVM:
				case WeaponGuidanceType.BeamRiding:
				case WeaponGuidanceType.SemiActive_Plus_Active:
				case WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
					return 0f;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100885", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return 0f;
			}
		}
	}

	public bool IsContactExplosive
	{
		get
		{
			if ((uint)(Type - 2010) <= 1u)
			{
				return true;
			}
			return false;
		}
	}

	public float AcceptableDownRangeAmbiguity
	{
		get
		{
			try
			{
				if (IsContactExplosive)
				{
					return 0f;
				}
				switch (Guidance)
				{
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new NotImplementedException();
				case WeaponGuidanceType.Inertial_Plus_SemiActive:
				case WeaponGuidanceType.Datalink_Plus_SemiActive:
				case WeaponGuidanceType.Passive:
				case WeaponGuidanceType.Inertial_Plus_Passive:
				case WeaponGuidanceType.DataLink_Plus_Passive:
				case WeaponGuidanceType.Active:
				case WeaponGuidanceType.Datalink_Plus_Active:
				case WeaponGuidanceType.Inertial_Plus_Active:
					return MaxRange_NoTargetType;
				case WeaponGuidanceType.Inertial:
					if (Warheads.Length == 0)
					{
						return 0f;
					}
					if (Warheads[0].Type == Warhead.WarheadType.Weapon)
					{
						Weapon carriedWeapon = Warheads[0].GetCarriedWeapon(ParentScen);
						if (carriedWeapon._Sensors.Length != 0)
						{
							return carriedWeapon._Sensors[0].Swath_Total;
						}
						if (carriedWeapon.Warheads.Length == 0)
						{
							return 0f;
						}
						if (carriedWeapon.Warheads[0].IsExplosive)
						{
							DetonationMedium detonationMedium_;
							switch (carriedWeapon.Type)
							{
							default:
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								throw new NotImplementedException();
							case _WeaponType.GuidedWeapon:
							case _WeaponType.Rocket:
							case _WeaponType.IronBomb:
							case _WeaponType.Gun:
							case _WeaponType.BallisticMissile:
							case _WeaponType.RV:
							case _WeaponType.HGV:
								detonationMedium_ = DetonationMedium.Air;
								break;
							case _WeaponType.Torpedo:
							case _WeaponType.DepthCharge:
							case _WeaponType.BottomMine:
							case _WeaponType.MooredMine:
							case _WeaponType.FloatingMine:
							case _WeaponType.MovingMine:
							case _WeaponType.RisingMine:
							case _WeaponType.DriftingMine:
								detonationMedium_ = DetonationMedium.Underwater;
								break;
							}
							return Explosion.GetCutoffRange_Blast_nm(carriedWeapon.Warheads[0].DP, detonationMedium_);
						}
					}
					if (Warheads[0].IsExplosive)
					{
						DetonationMedium detonationMedium_2;
						switch (Type)
						{
						default:
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							throw new NotImplementedException();
						case _WeaponType.GuidedWeapon:
						case _WeaponType.Rocket:
						case _WeaponType.IronBomb:
						case _WeaponType.Gun:
						case _WeaponType.GuidedProjectile:
						case _WeaponType.BallisticMissile:
						case _WeaponType.RV:
						case _WeaponType.HGV:
							detonationMedium_2 = DetonationMedium.Air;
							break;
						case _WeaponType.Torpedo:
						case _WeaponType.DepthCharge:
						case _WeaponType.BottomMine:
						case _WeaponType.MooredMine:
						case _WeaponType.FloatingMine:
						case _WeaponType.MovingMine:
						case _WeaponType.RisingMine:
						case _WeaponType.DriftingMine:
							detonationMedium_2 = DetonationMedium.Underwater;
							break;
						}
						return Explosion.GetCutoffRange_Blast_nm(Warheads[0].DP, detonationMedium_2);
					}
					return 0f;
				case WeaponGuidanceType.SemiActive:
				case WeaponGuidanceType.CommandGuided_Datalinked:
				case WeaponGuidanceType.TVM:
				case WeaponGuidanceType.BeamRiding:
				case WeaponGuidanceType.SemiActive_Plus_Active:
				case WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
					return 0f;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200294", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return 0f;
			}
		}
	}

	public bool HasManInTheLoop
	{
		get
		{
			switch (Guidance)
			{
			default:
				return false;
			case WeaponGuidanceType.SemiActive:
			case WeaponGuidanceType.Datalink_Plus_SemiActive:
			case WeaponGuidanceType.DataLink_Plus_Passive:
			case WeaponGuidanceType.Datalink_Plus_Active:
			case WeaponGuidanceType.CommandGuided_Datalinked:
			case WeaponGuidanceType.BeamRiding:
			case WeaponGuidanceType.SemiActive_Plus_Active:
			case WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
				if (Information.IsNothing(DataLinkParent))
				{
					return false;
				}
				return true;
			}
		}
	}

	public bool IsBrilliantWeapon
	{
		get
		{
			Sensor[] sensors = _Sensors;
			int num = 0;
			while (true)
			{
				if (num < sensors.Length)
				{
					if (sensors[num].Codes.Classification)
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

	public bool IsArmed
	{
		get
		{
			try
			{
				if (Guidance == WeaponGuidanceType.Inertial)
				{
					if (Navigator.HasNonPathfindPlottedCourse())
					{
						Waypoint waypoint = Navigator.PlottedCourse[Navigator.PlottedCourse.Count() - 1];
						float num = Math2.VerifyClass(GetLatitude(), GetLongitude(), waypoint.Latitude, waypoint.Longitude);
						float num2 = Math2.VerifyClass(GetLatitude(), GetLongitude(), LaunchPoint.Latitude, LaunchPoint.Longitude);
						return num < num2;
					}
					return true;
				}
				return true;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100887", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
		}
	}

	public WeaponGuidanceType Guidance
	{
		get
		{
			if (!m_WrapperReader.HasValue)
			{
				DetermineGuidance();
			}
			return m_WrapperReader.Value;
		}
	}

	public Sensor SensorProvidingFireControlForMe
	{
		get
		{
			return issuerReader;
		}
		set
		{
			issuerReader = value;
		}
	}

	public bool IsRemoteControllable => CommStuff.CommLinksEstablished_ReadOnly.Length != 0;

	public int CEP_Surface
	{
		get
		{
			return configReader;
		}
		set
		{
			configReader = value;
		}
	}

	public int CEP_Land
	{
		get
		{
			return m_RegistryReader;
		}
		set
		{
			m_RegistryReader = value;
		}
	}

	public bool IsSoftKill
	{
		get
		{
			_WeaponType type = Type;
			if ((uint)(type - 2005) > 2u && type != _WeaponType.SensorPod)
			{
				return false;
			}
			return true;
		}
	}

	public ActiveUnit FiringParent
	{
		get
		{
			if (Information.IsNothing(m_DefinitionReader))
			{
				return null;
			}
			return m_DefinitionReader;
		}
		set
		{
			m_DefinitionReader = value;
			if (value == null)
			{
				_FiringParent_ID = null;
			}
			else
			{
				_FiringParent_ID = value.ObjectID;
			}
		}
	}

	public ActiveUnit DataLinkParent
	{
		get
		{
			if (valReader == null)
			{
				return null;
			}
			ActiveUnit activeUnit = valReader;
			if (activeUnit != null && activeUnit.IsDestroyed)
			{
				return null;
			}
			return valReader;
		}
		set
		{
			if (value == null)
			{
				if (!PlayerIsPlottingCourse)
				{
					CommDevice[] comms_ReadOnly = Comms_ReadOnly;
					for (int i = 0; i < comms_ReadOnly.Length; i = checked(i + 1))
					{
						comms_ReadOnly[i].OccupiedChannels = 0;
					}
					DetermineGuidance();
					valReader = null;
				}
			}
			else
			{
				valReader = value;
			}
		}
	}

	public float BlindTime
	{
		get
		{
			return _BlindTime;
		}
		set
		{
			_BlindTime = value;
			if (!(_BlindTime > 5f) || (!Information.IsNothing(DataLinkParent) && Guidance != WeaponGuidanceType.TVM))
			{
				return;
			}
			switch (Guidance)
			{
			case WeaponGuidanceType.SemiActive_Plus_Active:
			case WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
				StopReponse(bool_0: true, bool_1: true);
				return;
			case WeaponGuidanceType.Inertial_Plus_SemiActive:
				return;
			}
			if (IsAAW)
			{
				if (IsNuke.Value && AI.PrimaryTarget != null)
				{
					if (Module_Unit.RangeToUnit_Slant(this, AI.PrimaryTarget) < LaunchPoint.RangeToPoint_Slant(new Geopoint_Struct(AI.PrimaryTarget.GetLongitude(), AI.PrimaryTarget.GetLatitude())) / 2f)
					{
						AddMessage("武器：" + Name + "丢失视野达到" + Conversions.ToString((int)Math.Round(_BlindTime)) + " 秒并已接近目标 - 引爆中.", "武器引爆中", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						double latitude = GetLatitude();
						double longitude = GetLongitude();
						float currentAltitude = GetCurrentAltitude();
						LockRandom lockRandom_ = GameGeneral.LockRandom_0;
						Detonate(latitude, longitude, currentAltitude, ref lockRandom_, bool_0: false);
					}
					else
					{
						AddMessage("武器：" + Name + "丢失视野达到" + Conversions.ToString((int)Math.Round(_BlindTime)) + "秒 ...自毁中。", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						ParentScen.DestroyThisUnit(this, "Weapon has been blinded");
					}
				}
				else
				{
					AddMessage("武器：" + Name + "丢失视野达到" + Conversions.ToString((int)Math.Round(_BlindTime)) + "秒 ...自毁中。", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
					ParentScen.DestroyThisUnit(this, "Weapon has been blinded");
				}
			}
			else
			{
				AddMessage("武器：" + Name + "丢失视野达到" + Conversions.ToString((int)Math.Round(_BlindTime)) + "秒 ...目标丢失。", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
			}
		}
	}

	public float DatalinkRetargetTime
	{
		get
		{
			return _DatalinkRetargetTime;
		}
		set
		{
			_DatalinkRetargetTime = value;
		}
	}

	public override bool IsPlatform => false;

	public new Weapon_Navigator Navigator => _Navigator;

	public new virtual Weapon_AI AI => m_ReaderReader;

	public new virtual Weapon_Kinematics Kinematics
	{
		get
		{
			if (Information.IsNothing(m_PropertyReader))
			{
				ActiveUnit activeUnit_ = this;
				m_PropertyReader = new Weapon_Kinematics(ref activeUnit_);
			}
			return m_PropertyReader;
		}
	}

	public new Weapon_Sensory Sensory
	{
		get
		{
			if (Information.IsNothing(importerReader))
			{
				ActiveUnit activeUnit_ = this;
				importerReader = new Weapon_Sensory(ref activeUnit_);
			}
			return importerReader;
		}
	}

	public new Weapon_CommStuff CommStuff
	{
		get
		{
			if (Information.IsNothing(repositoryReader))
			{
				ActiveUnit activeUnit_ = this;
				repositoryReader = new Weapon_CommStuff(ref activeUnit_);
			}
			return repositoryReader;
		}
	}

	public new Weapon_Damage Damage
	{
		get
		{
			if (Information.IsNothing(_BridgeReader))
			{
				ActiveUnit activeUnit_ = this;
				_BridgeReader = new Weapon_Damage(ref activeUnit_);
			}
			return _BridgeReader;
		}
	}

	public override string AnnexAndDBID => "武器_" + Conversions.ToString(DBID);

	public bool IsASuW_Land
	{
		get
		{
			if (!ValidTargets.LandStructure_Hard && !ValidTargets.LandStructure_Soft && !ValidTargets.MobileTarget_Hard && !ValidTargets.MobileTarget_Soft && !ValidTargets.Runway)
			{
				return ValidTargets.Radar;
			}
			return true;
		}
	}

	public bool IsASuW_Naval
	{
		get
		{
			if (ValidTargets == null)
			{
				return false;
			}
			if (ValidTargets.SurfaceVessel)
			{
				return true;
			}
			return ValidTargets.Radar;
		}
	}

	public bool IsASW
	{
		get
		{
			if (ValidTargets == null)
			{
				return false;
			}
			return ValidTargets.Submarine;
		}
	}

	public bool IsAntiradar => ValidTargets.Radar;

	public override bool IsBallisticMissile
	{
		get
		{
			_WeaponType type = Type;
			if (1 == 0)
			{
			}
			bool result = type switch
			{
				_WeaponType.HGV => false, 
				_WeaponType.RV => false, 
				_WeaponType.BallisticMissile => true, 
				_ => Flags.IsBallisticMissile, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
	}

	public bool IsAAW
	{
		get
		{
			if (Type == _WeaponType.Decoy_Vehicle)
			{
				return false;
			}
			if (Type == _WeaponType.Decoy_Expendable)
			{
				return false;
			}
			if (Type == _WeaponType.Decoy_Towed)
			{
				return false;
			}
			if (ValidTargets == null)
			{
				return false;
			}
			if (!ValidTargets.Missile)
			{
				return ValidTargets.Aircraft;
			}
			return true;
		}
	}

	public bool IsAAW_GuidedMissile
	{
		get
		{
			if (Type == _WeaponType.GuidedWeapon)
			{
				if (ValidTargets != null)
				{
					if (!ValidTargets.Missile)
					{
						return ValidTargets.Aircraft;
					}
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public bool IsAAW_GuidedMissile_ARH
	{
		get
		{
			if (IsAAW_GuidedMissile)
			{
				Sensor[] sensors = _Sensors;
				bool flag = false;
				for (int i = 0; i < sensors.Length; i = checked(i + 1))
				{
					if (sensors[i].Type == Sensor.Sensor_Type.Radar)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public bool CanBeDestroyedByNuke
	{
		get
		{
			switch (Type)
			{
			case _WeaponType.GuidedWeapon:
			case _WeaponType.Torpedo:
				return true;
			default:
				return false;
			case _WeaponType.BottomMine:
			case _WeaponType.MooredMine:
			case _WeaponType.FloatingMine:
			case _WeaponType.MovingMine:
			case _WeaponType.RisingMine:
			case _WeaponType.DriftingMine:
			case _WeaponType.DummyMine:
				return true;
			case _WeaponType.Decoy_Vehicle:
			case _WeaponType.UAV_Expendable:
			case _WeaponType.Sonobuoy:
				return true;
			}
		}
	}

	public bool IsASAT => ValidTargets.Satellite;

	public bool IsReEntryVehicle
	{
		get
		{
			if (Type != _WeaponType.RV && Type != _WeaponType.HGV)
			{
				return false;
			}
			return true;
		}
	}

	public bool Is_LOAL_capable
	{
		get
		{
			WeaponGuidanceType guidance = Guidance;
			if ((int)(guidance - 1) > 1 && (int)(guidance - 5) > 4)
			{
				return false;
			}
			return true;
		}
	}

	public bool isLoiterCapable
	{
		get
		{
			if (Flags.LoiterCapability)
			{
				return true;
			}
			return Flags.ParachuteLoiter;
		}
	}

	public bool CanParachuteLoiter
	{
		get
		{
			if (Flags.ParachuteLoiter && TimeSinceBurnout == 0f)
			{
				return (ThrottleSetting != Throttle.FullStop) | IsPalletWeapon;
			}
			return false;
		}
	}

	public bool IsParachuteLoitering
	{
		get
		{
			if (Flags.ParachuteLoiter && ThrottleSetting == Throttle.FullStop)
			{
				return CurrentAltitude_AGL > 0f;
			}
			return false;
		}
	}

	public override GlobalVariables.TargetVisualSizeClass VisualSizeClass
	{
		get
		{
			float length = Length;
			if (length <= 10f)
			{
				if (length <= 5f)
				{
					if (length <= 3.5f)
					{
						if (length <= 2.5f)
						{
							if (length <= 1.5f)
							{
								return GlobalVariables.TargetVisualSizeClass.Stealthy;
							}
							return GlobalVariables.TargetVisualSizeClass.VSmall;
						}
						return GlobalVariables.TargetVisualSizeClass.Small;
					}
					return GlobalVariables.TargetVisualSizeClass.Medium;
				}
				return GlobalVariables.TargetVisualSizeClass.Large;
			}
			return GlobalVariables.TargetVisualSizeClass.VLarge;
		}
	}

	public bool IsLaserShot
	{
		get
		{
			if (Warheads.Length == 0)
			{
				return false;
			}
			if ((uint)(Warheads[0].Type - 9101) <= 3u)
			{
				return true;
			}
			return false;
		}
	}

	public new bool IsDecoy
	{
		get
		{
			if (Type != _WeaponType.Decoy_Expendable && Type != _WeaponType.Decoy_Towed)
			{
				return Type == _WeaponType.Decoy_Vehicle;
			}
			return true;
		}
	}

	public bool IsTrainingRound => Type == _WeaponType.TrainingRound;

	public bool IsSonarCountermeasure
	{
		get
		{
			if (IsDecoy)
			{
				XSection[] xSections_ReadOnly = base.XSections_ReadOnly;
				XSection[] array = xSections_ReadOnly;
				foreach (XSection xSection in array)
				{
					if ((xSection.SignatureType == XSection._SignatureType.ActiveSonar || xSection.SignatureType == XSection._SignatureType.HullSonar_PassiveOnly_VLF) && (xSection.GetFront(this) > -10000f || xSection.GetSide(this) > -10000f || xSection.GetRear(this) > -10000f))
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}
	}

	public bool IsRadarCountermeasure
	{
		get
		{
			if (!m_WatcherReader.HasValue)
			{
				m_WatcherReader = false;
				if (IsDecoy)
				{
					XSection[] xSections_ReadOnly = base.XSections_ReadOnly;
					XSection[] array = xSections_ReadOnly;
					foreach (XSection xSection in array)
					{
						if ((xSection.SignatureType == XSection._SignatureType.Radar_A_D || xSection.SignatureType == XSection._SignatureType.Radar_E_M) && (xSection.GetFront(this) > -10000f || xSection.GetSide(this) > -10000f || !(xSection.GetRear(this) <= -10000f)))
						{
							m_WatcherReader = true;
							break;
						}
					}
				}
				else
				{
					m_WatcherReader = false;
				}
			}
			return m_WatcherReader.Value;
		}
	}

	public bool Boolean_0
	{
		get
		{
			if (IsDecoy)
			{
				XSection[] xSections_ReadOnly = base.XSections_ReadOnly;
				XSection[] array = xSections_ReadOnly;
				foreach (XSection xSection in array)
				{
					if ((uint)(xSection.SignatureType - 4001) <= 1u && (xSection.GetFront(this) > -10000f || xSection.GetSide(this) > -10000f || xSection.GetRear(this) > -10000f))
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}
	}

	public bool IsSmokeGrenade
	{
		get
		{
			if (IsDecoy)
			{
				XSection[] xSections_ReadOnly = base.XSections_ReadOnly;
				XSection[] array = xSections_ReadOnly;
				foreach (XSection xSection in array)
				{
					if ((uint)(xSection.SignatureType - 3001) <= 1u && (xSection.GetFront(this) > 0f || xSection.GetSide(this) > 0f || xSection.GetRear(this) > 0f))
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}
	}

	public bool IsVisualCountermeasure
	{
		get
		{
			if (IsDecoy)
			{
				XSection[] xSections_ReadOnly = base.XSections_ReadOnly;
				XSection[] array = xSections_ReadOnly;
				foreach (XSection xSection in array)
				{
					if ((uint)(xSection.SignatureType - 3001) <= 1u && (xSection.GetFront(this) > -10000f || xSection.GetSide(this) > -10000f || xSection.GetRear(this) > -10000f))
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}
	}

	public bool IsChaff_CM_SG => IsRadarCountermeasure | IsSonarCountermeasure | IsVisualCountermeasure | IsSmokeGrenade | IsChaffBundle;

	public bool IsFuelTank
	{
		get
		{
			if (Type == _WeaponType.DropTank)
			{
				return true;
			}
			return Type == _WeaponType.FerryTank;
		}
	}

	public bool IsSensorPod => Type == _WeaponType.SensorPod;

	public bool IsSensorPodWithFuelTank
	{
		get
		{
			if (Type == _WeaponType.SensorPod)
			{
				return FuelCapacityMax > 0;
			}
			return false;
		}
	}

	public override float CurrentAltitude_AGL => GetCurrentAltitude() - (float)Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, ParentScen);

	public bool HasGoneAutonomous
	{
		get
		{
			if (IsFullyAutonomous)
			{
				return !Navigator.HasPlottedCourse();
			}
			if (IsSemiAutonomous)
			{
				return DataLinkParent == null;
			}
			return false;
		}
	}

	public bool IsSemiAutonomous
	{
		get
		{
			WeaponGuidanceType guidance = Guidance;
			if (guidance != WeaponGuidanceType.DataLink_Plus_Passive && guidance != WeaponGuidanceType.Datalink_Plus_Active && (int)(guidance - 14) > 1)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsFullyAutonomous
	{
		get
		{
			switch (Guidance)
			{
			default:
				return false;
			case WeaponGuidanceType.Passive:
			case WeaponGuidanceType.Inertial_Plus_Passive:
			case WeaponGuidanceType.Active:
			case WeaponGuidanceType.Inertial_Plus_Active:
			case WeaponGuidanceType.Inertial:
				return true;
			}
		}
	}

	public bool HasTorpedoPayload
	{
		get
		{
			try
			{
				Warhead[] warheads = Warheads;
				Warhead[] array = warheads;
				foreach (Warhead warhead in array)
				{
					if (!warhead.IsTorpedo)
					{
						if (warhead.Type == Warhead.WarheadType.Weapon && warhead.GetCarriedWeapon(ParentScen).IsTorpedo)
						{
							return true;
						}
						continue;
					}
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100929", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
		}
	}

	public bool IsDualModeARM
	{
		get
		{
			try
			{
				if (ValidTargets.Radar)
				{
					if (_Sensors.Length < 2)
					{
						return false;
					}
					Sensor[] sensors = _Sensors;
					for (int i = 0; i < sensors.Length; i = checked(i + 1))
					{
						if (sensors[i].Type != Sensor.Sensor_Type.ESM)
						{
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
				exception_?.Data.Add("Error at 100956", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
		}
	}

	public string WeaponGuidanceTypeString
	{
		get
		{
			string text = "";
			string text2 = "";
			bool flag = false;
			if (Flags.Navigation_INS)
			{
				text = "惯性（INS）";
				flag = true;
			}
			else if (Flags.Navigation_INS_GPS)
			{
				text = "GPS更新的惯性（INS）";
				flag = true;
			}
			else if (Flags.Navigation_TERCOM)
			{
				text = "地形对比（TERCOM）";
				flag = true;
			}
			else if (Flags.RearAspect_AAM)
			{
				text = "Rear-Aspect";
				flag = true;
			}
			else if (Flags.SternChase_AAM)
			{
				text = "Stern-Chase";
				flag = true;
			}
			else if (Flags.AllAspect_AAM)
			{
				text = "All-Aspect";
				flag = true;
			}
			else if (Flags.HOB_AAM)
			{
				text = "全方位，高瞄准镜";
				flag = true;
			}
			else if (Flags.Torpedo_PatternRunning)
			{
				text = "Pattern-Running";
				flag = true;
			}
			else if (Flags.Torpedo_StraightRunningTimeDetonation)
			{
				text = "直行时间爆轰";
				flag = true;
			}
			else if (Flags.Torpedo_StraightRunning)
			{
				text = "Straight-Running";
				flag = true;
			}
			else if (Flags.Torpedo_WakeHoming)
			{
				text = "唤醒（WH）";
				flag = true;
			}
			checked
			{
				switch (Guidance)
				{
				case WeaponGuidanceType.SemiActive:
					text = "Semi-Active";
					if (Directors.Count <= 0)
					{
						break;
					}
					foreach (int director in Directors)
					{
						SQLiteConnection sqliteConnection_3 = ParentScen.DBConnection;
						Sensor sensor6 = DBFunctions.GetSensor(director, ref sqliteConnection_3);
						if (sensor6.Type != Sensor.Sensor_Type.Radar)
						{
							if (sensor6.Type == Sensor.Sensor_Type.LaserDesignator)
							{
								return text + "激光归位（SALH）";
							}
							continue;
						}
						return text + "雷达归航（SARH）";
					}
					return text;
				case WeaponGuidanceType.Inertial_Plus_SemiActive:
					text = "惯性（INS）中段加半主动";
					if (Directors.Count > 0)
					{
						foreach (int director2 in Directors)
						{
							SQLiteConnection sqliteConnection_2 = ParentScen.DBConnection;
							Sensor sensor5 = DBFunctions.GetSensor(director2, ref sqliteConnection_2);
							if (sensor5.Type != Sensor.Sensor_Type.Radar)
							{
								if (sensor5.Type == Sensor.Sensor_Type.LaserDesignator)
								{
									text += "激光归位（SALH）";
									break;
								}
								continue;
							}
							text += "雷达归航（SARH）";
							break;
						}
					}
					text += "末端制导";
					break;
				case WeaponGuidanceType.Datalink_Plus_SemiActive:
					text = "数据链（DL/INS）中段加半主动";
					if (Directors.Count > 0)
					{
						foreach (int director3 in Directors)
						{
							SQLiteConnection sqliteConnection_ = ParentScen.DBConnection;
							Sensor sensor3 = DBFunctions.GetSensor(director3, ref sqliteConnection_);
							if (sensor3.Type != Sensor.Sensor_Type.Radar)
							{
								if (sensor3.Type == Sensor.Sensor_Type.LaserDesignator)
								{
									text += "激光归位（SALH）";
									break;
								}
								continue;
							}
							text += "雷达归航（SARH）";
							break;
						}
					}
					if (_Sensors.Length != 0)
					{
						Sensor[] sensors6 = _Sensors;
						Sensor[] array3 = sensors6;
						foreach (Sensor sensor4 in array3)
						{
							if (sensor4.Type == Sensor.Sensor_Type.Infrared)
							{
								text2 = "具备红外（IR）备用导引头";
							}
							else if (sensor4.Type == Sensor.Sensor_Type.Visual)
							{
								text2 = "具备电光（EO）备用导引头";
							}
						}
					}
					text = text + "末端制导" + text2;
					break;
				case WeaponGuidanceType.Passive:
					if (flag)
					{
						text += "中段加";
					}
					text += "Passive";
					if (_Sensors.Length != 0)
					{
						Sensor[] sensors5 = _Sensors;
						Sensor[] array5 = sensors5;
						foreach (Sensor sensor8 in array5)
						{
							if (sensor8.Type != Sensor.Sensor_Type.Infrared)
							{
								if (sensor8.Type != Sensor.Sensor_Type.Visual)
								{
									if (sensor8.Type == Sensor.Sensor_Type.ESM)
									{
										text += "雷达归航";
										break;
									}
									continue;
								}
								text += "电光（EO）";
								break;
							}
							text += "红外线（IR）";
							break;
						}
					}
					if (flag)
					{
						text += "末端制导";
					}
					break;
				case WeaponGuidanceType.Inertial_Plus_Passive:
					text = "惯性（INS）中段加被动";
					if (_Sensors.Length != 0)
					{
						Sensor[] sensors4 = _Sensors;
						Sensor[] array2 = sensors4;
						foreach (Sensor sensor2 in array2)
						{
							if (sensor2.Type != Sensor.Sensor_Type.Infrared)
							{
								if (sensor2.Type != Sensor.Sensor_Type.Visual)
								{
									if (sensor2.Type == Sensor.Sensor_Type.ESM)
									{
										text += "雷达归位（ARM）";
										break;
									}
									continue;
								}
								text += "电光（EO）";
								break;
							}
							text += "红外线（IR）";
							break;
						}
					}
					text += "末端制导";
					break;
				case WeaponGuidanceType.DataLink_Plus_Passive:
					if (flag)
					{
						text += "和";
					}
					if (Type == _WeaponType.GuidedWeapon)
					{
						text += "数据链（DL/INS）中段加被动";
					}
					else if (Type == _WeaponType.Torpedo)
					{
						text += "电磁导引中段加被动";
					}
					if (_Sensors.Length != 0)
					{
						Sensor[] sensors8 = _Sensors;
						for (int k = 0; k < sensors8.Length; k++)
						{
							if (sensors8[k].Type == Sensor.Sensor_Type.Radar)
							{
								text += "雷达归航（ARH）";
								break;
							}
						}
					}
					text += "末端制导";
					break;
				case WeaponGuidanceType.Active:
					if (flag)
					{
						text += "中段加";
					}
					text += "Active";
					if (_Sensors.Length != 0)
					{
						Sensor[] sensors9 = _Sensors;
						for (int l = 0; l < sensors9.Length; l++)
						{
							if (sensors9[l].Type == Sensor.Sensor_Type.Radar)
							{
								text += "雷达归航（ARH）";
								break;
							}
						}
					}
					if (flag)
					{
						text += "末端制导";
					}
					break;
				case WeaponGuidanceType.Datalink_Plus_Active:
					if (flag)
					{
						text += "和";
					}
					if (Type == _WeaponType.GuidedWeapon)
					{
						text += "数据链（DL/INS）中段加主动";
					}
					else if (Type == _WeaponType.Torpedo)
					{
						text += "电磁导引中段加主动";
					}
					if (_Sensors.Length != 0)
					{
						Sensor[] sensors3 = _Sensors;
						Sensor[] array = sensors3;
						foreach (Sensor sensor in array)
						{
							if (sensor.Type == Sensor.Sensor_Type.Radar)
							{
								text += "雷达归航（ARH）";
							}
							else if (sensor.Type == Sensor.Sensor_Type.Infrared)
							{
								text2 = "具备红外（IR）备用导引头";
							}
							else if (sensor.Type == Sensor.Sensor_Type.Visual)
							{
								text2 = "具备电光（EO）备用导引头";
							}
						}
					}
					text = text + "末端制导" + text2;
					break;
				case WeaponGuidanceType.Inertial_Plus_Active:
					text = "惯性导引（INS）中段加主动";
					if (_Sensors.Length != 0)
					{
						Sensor[] sensors2 = _Sensors;
						Sensor[] array4 = sensors2;
						foreach (Sensor sensor7 in array4)
						{
							if (sensor7.Type == Sensor.Sensor_Type.Radar)
							{
								text += "雷达归航（ARH）";
							}
							else if (sensor7.Type == Sensor.Sensor_Type.Infrared)
							{
								text2 = "具备红外（IR）备用导引头";
							}
							else if (sensor7.Type == Sensor.Sensor_Type.Visual)
							{
								text2 = "具备电光（EO）备用导引头";
							}
							else if (sensor7.Type == Sensor.Sensor_Type.ESM && ValidTargets.Radar)
							{
								text2 = "使用反雷达（ARM）备份导引头";
							}
						}
					}
					text = text + "末端制导" + text2;
					break;
				case WeaponGuidanceType.CommandGuided_Datalinked:
					text = "Command-Guided";
					break;
				case WeaponGuidanceType.TVM:
					text = "通过导弹追踪（TVM）";
					break;
				case WeaponGuidanceType.BeamRiding:
					text = "波束运动";
					break;
				case WeaponGuidanceType.Inertial:
					text = "惯性制导";
					break;
				case WeaponGuidanceType.SemiActive_Plus_Active:
					text = "半主动（SARH）中段加主动";
					if (_Sensors.Length != 0)
					{
						Sensor[] sensors7 = _Sensors;
						for (int j = 0; j < sensors7.Length; j++)
						{
							if (sensors7[j].Type == Sensor.Sensor_Type.Radar)
							{
								text += "雷达归航（ARH）";
								break;
							}
						}
					}
					text += "末端制导";
					break;
				case WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
					text = "时间共享半主动（TSARH）中段加主动";
					if (_Sensors.Length != 0)
					{
						Sensor[] sensors = _Sensors;
						for (int i = 0; i < sensors.Length; i++)
						{
							if (sensors[i].Type == Sensor.Sensor_Type.Radar)
							{
								text += "雷达归航（ARH）";
								break;
							}
						}
					}
					text += "末端制导";
					break;
				}
				return text;
			}
		}
	}

	public bool HasTerminalGuidance
	{
		get
		{
			if (Guidance == WeaponGuidanceType.Inertial)
			{
				return false;
			}
			return true;
		}
	}

	public float? MinimumSafeHeight
	{
		get
		{
			try
			{
				int landElevation = GetLandElevation(bool_0: false, bool_1: false, bool_2: false, ParentScen);
				bool num = landElevation > 0;
				float num2 = (num ? 18.288f : 9.144f);
				if (IsHGV)
				{
					num2 = 1000f;
				}
				if (num)
				{
					return (float)landElevation + num2;
				}
				return num2;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100891", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				float? result = 0f;
				ProjectData.ClearProjectError();
				return result;
			}
		}
		set
		{
		}
	}

	public static event WeaponImpactEventHandler WeaponImpact
	{
		[CompilerGenerated]
		add
		{
			WeaponImpactEventHandler weaponImpactEventHandler = reponseReader;
			WeaponImpactEventHandler weaponImpactEventHandler2;
			do
			{
				weaponImpactEventHandler2 = weaponImpactEventHandler;
				WeaponImpactEventHandler value2 = (WeaponImpactEventHandler)Delegate.Combine(weaponImpactEventHandler2, value);
				weaponImpactEventHandler = Interlocked.CompareExchange(ref reponseReader, value2, weaponImpactEventHandler2);
			}
			while ((object)weaponImpactEventHandler != weaponImpactEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			WeaponImpactEventHandler weaponImpactEventHandler = reponseReader;
			WeaponImpactEventHandler weaponImpactEventHandler2;
			do
			{
				weaponImpactEventHandler2 = weaponImpactEventHandler;
				WeaponImpactEventHandler value2 = (WeaponImpactEventHandler)Delegate.Remove(weaponImpactEventHandler2, value);
				weaponImpactEventHandler = Interlocked.CompareExchange(ref reponseReader, value2, weaponImpactEventHandler2);
			}
			while ((object)weaponImpactEventHandler != weaponImpactEventHandler2);
		}
	}

	[SpecialName]
	internal float MoveDescriptor()
	{
		switch (Type)
		{
		case _WeaponType.GuidedProjectile:
			return -30f;
		case _WeaponType.GuidedWeapon:
			return -5f;
		case _WeaponType.Rocket:
		case _WeaponType.Gun:
			return -30f;
		default:
			return 0f;
		case _WeaponType.HGV:
			return -70f;
		case _WeaponType.BallisticMissile:
		case _WeaponType.RV:
			return -80f;
		case _WeaponType.Torpedo:
			return -85f;
		}
	}

	[SpecialName]
	internal float AddDescriptor()
	{
		return _ProxyReader;
	}

	[SpecialName]
	internal void DestroyDescriptor(float float_0)
	{
		_ProxyReader = float_0;
	}

	static Weapon()
	{
		StandOffMaxRange = 6f;
	}

	internal bool InterruptReponse()
	{
		if (Warheads.Count() > 0)
		{
			Weapon carriedWeapon = Warheads[0].GetCarriedWeapon(ParentScen);
			if (carriedWeapon != null && carriedWeapon.IsHGV)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsBallisticTargetManeuvering()
	{
		if (this is BallisticMissile)
		{
			return ((BallisticMissile)this).IsPerformingTerminalManeuvers;
		}
		if (Module_Unit.MapTokenizer(this) && (_Sensors.Count() > 0 || IsHGV))
		{
			return true;
		}
		return false;
	}

	internal float RemoveReponse()
	{
		if (IsAAW_GuidedMissile)
		{
			float num = Physics.CompareStub(GetCurrentAltitude(), CurrentSpeed);
			double num2 = ((num <= 1f) ? (0.12 + 0.13 * Math.Pow(num, 2.0)) : (0.25 / (double)num));
			double num3 = 0.0;
			if (num > 1f)
			{
				num3 = (1.59 + 1.83 / Math.Pow(num, 2.0)) * Math.Pow(Math.Atan(0.20833332505491078), 1.69);
			}
			double num4 = Length / Diameter;
			double num5 = Length * 3.28084f;
			double num6 = Physics.DisableStub(Physics.ReadStub((int)Math.Round(GetCurrentAltitude()), (double)CurrentSpeed * 0.514444));
			double num7 = 0.053 * num4 * Math.Pow((double)num / (num6 * num5), 0.2);
			return (float)(num2 + num3 + num7);
		}
		if (IsReEntryVehicle)
		{
			return 0.1f;
		}
		return 0.35f;
	}

	internal int FindReponse()
	{
		if (classReader <= 0)
		{
			if (Flags.IsMultiStageMissile)
			{
				return (int)Math.Round((double)MaxWeight * 0.1);
			}
			return (int)Math.Round((double)MaxWeight * 0.25);
		}
		return classReader;
	}

	public override void Teleport(ref Scenario scenario_0, double double_0, double double_1)
	{
		base.Teleport(ref scenario_0, double_0, double_1);
		Kinematics.ExportLocationEvent(bool_0: true);
	}

	internal bool SetReponse()
	{
		if (!_RequestReader.HasValue)
		{
			try
			{
				if (FiringParent == null)
				{
					return false;
				}
				_RequestReader = FiringParent.IsAircraft || FiringParent.IsMissile;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				_RequestReader = false;
				ProjectData.ClearProjectError();
			}
		}
		return _RequestReader.Value;
	}

	private bool FillReponse()
	{
		if (SupportsAttitude_Pitch)
		{
			if (CalculateReponse())
			{
				return false;
			}
			if (!IsBallisticMissile && Propulsion.Count != 0)
			{
				if (IsAAW)
				{
					short? num = (short?)Propulsion[0]?.Type;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2001) : null).GetValueOrDefault())
					{
						return false;
					}
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	internal bool CalculateReponse()
	{
		if (stubReader.HasValue)
		{
			return stubReader.Value;
		}
		if (ValidTargets.Missile)
		{
			try
			{
				if (ValidTargets.Missile && !ValidTargets.Aircraft && !ValidTargets.Helicopter)
				{
					stubReader = true;
					return stubReader.Value;
				}
				if (Doctrine.WRA == null)
				{
					Weapon weapon_ = this;
					Doctrine doctrine = Doctrine;
					Dictionary<int, Doctrine.WRA_Weapon> dictionary_ = doctrine.WRA;
					DBFunctions.PopulateWeaponWRA(ref weapon_, ref dictionary_);
					doctrine.WRA = dictionary_;
				}
				Doctrine.WRA_Weapon wRA_Weapon = Doctrine.WRA.Values.ElementAtOrDefault(0);
				bool flag = false;
				bool flag2 = false;
				Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets = wRA_Weapon.WRA_WeaponTargets;
				Doctrine.WRA_FiringDoctrineEntry[] array = wRA_WeaponTargets;
				foreach (Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry in array)
				{
					int? weaponQty = wRA_FiringDoctrineEntry.WeaponQty;
					if ((weaponQty.HasValue ? new bool?(weaponQty.GetValueOrDefault() > 0) : null).GetValueOrDefault())
					{
						switch (wRA_FiringDoctrineEntry.TargetType)
						{
						case Doctrine._WRA_WeaponTargetType.Guided_Weapon_Ballistic:
							flag = true;
							break;
						case Doctrine._WRA_WeaponTargetType.Air_Contact_Unknown_Type:
							flag2 = true;
							break;
						}
					}
				}
				if (flag && !flag2)
				{
					stubReader = true;
					return stubReader.Value;
				}
				stubReader = false;
				return false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 23453209860112", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		stubReader = false;
		return stubReader.Value;
	}

	internal bool PopReponse()
	{
		if (m_WriterReader.HasValue)
		{
			return m_WriterReader.Value;
		}
		if (ValidTargets.Missile)
		{
			try
			{
				m_WriterReader = false;
				if (ValidTargets.Missile)
				{
					if (Doctrine.WRA == null)
					{
						Weapon weapon_ = this;
						Doctrine doctrine = Doctrine;
						Dictionary<int, Doctrine.WRA_Weapon> dictionary_ = doctrine.WRA;
						DBFunctions.PopulateWeaponWRA(ref weapon_, ref dictionary_);
						doctrine.WRA = dictionary_;
					}
					Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets = Doctrine.WRA.Values.ElementAtOrDefault(0).WRA_WeaponTargets;
					Doctrine.WRA_FiringDoctrineEntry[] array = wRA_WeaponTargets;
					foreach (Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry in array)
					{
						int? weaponQty = wRA_FiringDoctrineEntry.WeaponQty;
						if ((weaponQty.HasValue ? new bool?(weaponQty.GetValueOrDefault() > 0) : null).GetValueOrDefault() && wRA_FiringDoctrineEntry.TargetType == Doctrine._WRA_WeaponTargetType.Guided_Weapon_Ballistic)
						{
							m_WriterReader = true;
						}
					}
					return m_WriterReader.Value;
				}
				m_WriterReader = false;
				return m_WriterReader.Value;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 23453209860112", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		m_WriterReader = false;
		return m_WriterReader.Value;
	}

	private bool InstantiateReponse()
	{
		if (!IsASuW_Land && !IsASuW_Naval)
		{
			return false;
		}
		if (CruiseAltitude_AGL > 0f && CruiseAltitude_AGL < 1000f)
		{
			return true;
		}
		return false;
	}

	public override void ResetIDs()
	{
		base.ResetIDs();
		Warhead[] warheads = Warheads;
		for (int i = 0; i < warheads.Length; i = checked(i + 1))
		{
			warheads[i].ResetIDs();
		}
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			if ((GetUnitSide() == null) & (Name == null))
			{
				return;
			}
			xmlWriter_0.WriteStartElement("Weapon");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			if (hashSet_0.Contains(ObjectID))
			{
				xmlWriter_0.WriteEndElement();
				return;
			}
			hashSet_0.Add(ObjectID);
			xmlWriter_0.WriteElementString("Name", Name.Replace("\0", "").Replace("\u0010", ""));
			xmlWriter_0.WriteElementString("CH", XmlConvert.ToString(CurrentHeading));
			xmlWriter_0.WriteElementString("CS", XmlConvert.ToString(CurrentSpeed));
			xmlWriter_0.WriteElementString("CA", XmlConvert.ToString(GetCurrentAltitude()));
			xmlWriter_0.WriteElementString("ImpactAltitude", XmlConvert.ToString(ImpactAltitude));
			xmlWriter_0.WriteElementString("Lon", XmlConvert.ToString(GetLongitude()));
			xmlWriter_0.WriteElementString("Lat", XmlConvert.ToString(GetLatitude()));
			if (base.Longitude_LastReported.HasValue)
			{
				xmlWriter_0.WriteElementString("LonLR", XmlConvert.ToString(base.Longitude_LastReported.Value));
			}
			if (base.Latitude_LastReported.HasValue)
			{
				xmlWriter_0.WriteElementString("LatLR", XmlConvert.ToString(base.Latitude_LastReported.Value));
			}
			if (Attitude_Pitch != 0f)
			{
				xmlWriter_0.WriteElementString("Pitch", XmlConvert.ToString(Attitude_Pitch));
			}
			if (Attitude_Roll != 0f)
			{
				xmlWriter_0.WriteElementString("Roll", XmlConvert.ToString(Attitude_Roll));
			}
			if (Longitude__UnitEntersAreaCheck.HasValue)
			{
				xmlWriter_0.WriteElementString("Longitude_UnitEntersAreaCheck", XmlConvert.ToString(Longitude__UnitEntersAreaCheck.Value));
			}
			if (Latitude__UnitEntersAreaCheck.HasValue)
			{
				xmlWriter_0.WriteElementString("Latitude_UnitEntersAreaCheck", XmlConvert.ToString(Latitude__UnitEntersAreaCheck.Value));
			}
			if (ActiveEnterAreaTriggers.Count > 0)
			{
				xmlWriter_0.WriteStartElement("ActiveEnterAreaTriggers");
				foreach (string activeEnterAreaTrigger in ActiveEnterAreaTriggers)
				{
					xmlWriter_0.WriteElementString("ActiveEnterAreaTrigger", activeEnterAreaTrigger);
				}
				xmlWriter_0.WriteEndElement();
			}
			if (ActiveRemainAreaTriggers.Count > 0)
			{
				xmlWriter_0.WriteStartElement("ActiveRemainAreaTriggers");
				foreach (KeyValuePair<string, DateTime> activeRemainAreaTrigger in ActiveRemainAreaTriggers)
				{
					xmlWriter_0.WriteElementString("RemainAreaTrigger", activeRemainAreaTrigger.Key.ToString());
					xmlWriter_0.WriteElementString("RemainAreaStartTime", activeRemainAreaTrigger.Value.ToBinary().ToString());
				}
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteElementString("CEP_Surface", Conversions.ToString(XmlConvert.ToDouble(Conversions.ToString(CEP_Surface))));
			xmlWriter_0.WriteElementString("CEP_Land", Conversions.ToString(XmlConvert.ToDouble(Conversions.ToString(CEP_Land))));
			if (GetUnitSide() == null)
			{
				Side[] sides_ReadOnly = ParentScen.Sides_ReadOnly;
				Side[] array = sides_ReadOnly;
				foreach (Side side in array)
				{
					if (side.Units.Contains(this))
					{
						_UnitSide = side;
						break;
					}
				}
			}
			if (!Information.IsNothing(GetUnitSide()))
			{
				xmlWriter_0.WriteElementString("Side", GetUnitSide().Name);
			}
			if (!string.IsNullOrEmpty(Message))
			{
				xmlWriter_0.WriteElementString("Message", Message);
			}
			xmlWriter_0.WriteElementString("DBID", DBID.ToString());
			if (DesiredHeading != 0f)
			{
				xmlWriter_0.WriteElementString("DH", XmlConvert.ToString(DesiredHeading));
			}
			if (DesiredSpeed != 0f)
			{
				xmlWriter_0.WriteElementString("DS", XmlConvert.ToString(DesiredSpeed));
			}
			if (DesiredAltitude != 0f)
			{
				xmlWriter_0.WriteElementString("DA", XmlConvert.ToString(DesiredAltitude));
			}
			if (DesiredTurnRate != 0)
			{
				xmlWriter_0.WriteElementString("DT", ((byte)DesiredTurnRate).ToString());
			}
			if (DesiredTurnRate_Navigation != 0)
			{
				xmlWriter_0.WriteElementString("DTN", ((byte)DesiredTurnRate_Navigation).ToString());
			}
			if (GetDesiredAltitude_UseTerrainFollowing(this))
			{
				xmlWriter_0.WriteElementString("TerrainFollowing", GetDesiredAltitude_UseTerrainFollowing(this).ToString());
			}
			if (ThrottleSetting != 0)
			{
				xmlWriter_0.WriteElementString("TS", ((byte)ThrottleSetting).ToString());
			}
			xmlWriter_0.WriteStartElement("Sensors");
			Sensor[] sensors = _Sensors;
			Sensor[] array2 = sensors;
			foreach (Sensor sensor in array2)
			{
				xmlWriter_0.WriteRaw(sensor.ToXML(hashSet_0));
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Comms");
			CommDevice[] comms = _Comms;
			CommDevice[] array3 = comms;
			foreach (CommDevice commDevice in array3)
			{
				xmlWriter_0.WriteRaw(commDevice.ToXML(ref hashSet_0));
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Propulsion");
			foreach (Engine item2 in Propulsion)
			{
				xmlWriter_0.WriteRaw(item2.ToXML(hashSet_0));
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Fuel");
			foreach (FuelRec item3 in _Fuel)
			{
				xmlWriter_0.WriteRaw(item3.ToXML());
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Mounts");
			foreach (Mount mount in Mounts)
			{
				if (mount.ParentPlatform == null)
				{
					mount.ParentPlatform = this;
				}
				xmlWriter_0.WriteRaw(mount.ToXML(ref hashSet_0, ParentScen));
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("OnboardCargo");
			Cargo[] onboardCargo = OnboardCargo;
			Cargo[] array4 = onboardCargo;
			foreach (Cargo cargo in array4)
			{
				xmlWriter_0.WriteRaw(cargo.ToXML(hashSet_0, ParentScen));
			}
			xmlWriter_0.WriteEndElement();
			XmlWriter obj = xmlWriter_0;
			byte status = (byte)_Status;
			obj.WriteElementString("Status", status.ToString());
			XmlWriter obj5 = xmlWriter_0;
			status = (byte)_FuelState;
			obj5.WriteElementString("FuelState", status.ToString());
			XmlWriter obj6 = xmlWriter_0;
			status = (byte)_WeaponState;
			obj6.WriteElementString("WeaponState", status.ToString());
			if (predicateVal != 0)
			{
				XmlWriter obj7 = xmlWriter_0;
				status = (byte)predicateVal;
				obj7.WriteElementString("SBR", status.ToString());
			}
			if (_SingletonVal != 0)
			{
				XmlWriter obj8 = xmlWriter_0;
				status = (byte)_SingletonVal;
				obj8.WriteElementString("SBED", status.ToString());
			}
			if (_RecordVal != 0)
			{
				XmlWriter obj9 = xmlWriter_0;
				status = (byte)_RecordVal;
				obj9.WriteElementString("SBEO", status.ToString());
			}
			if (comparatorVal != 0)
			{
				XmlWriter obj10 = xmlWriter_0;
				status = (byte)comparatorVal;
				obj10.WriteElementString("FSBR", status.ToString());
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
			XmlWriter obj11 = xmlWriter_0;
			status = (byte)_TemplateVal;
			obj11.WriteElementString("SBR_ThrottleSetting", status.ToString());
			xmlWriter_0.WriteElementString("SBED_Altitude", XmlConvert.ToString(m_MappingVal));
			if (m_MockVal.HasValue)
			{
				xmlWriter_0.WriteElementString("SBED_Altitude_TF", XmlConvert.ToString(m_MockVal.Value));
			}
			xmlWriter_0.WriteElementString("SBED_TF", XmlConvert.ToString(tagVal));
			XmlWriter obj12 = xmlWriter_0;
			status = (byte)fieldVal;
			obj12.WriteElementString("SBED_ThrottleSetting", status.ToString());
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
			XmlWriter obj3 = xmlWriter_0;
			status = (byte)candidateVal;
			obj3.WriteElementString("SBPF_ThrottleSetting", status.ToString());
			xmlWriter_0.WriteElementString("AMP_OC", m_AttrVal.ToString());
			if (!Information.IsNothing(_VisitorVal))
			{
				xmlWriter_0.WriteElementString("AMP_OC_DSO", _VisitorVal.ToString());
			}
			xmlWriter_0.WriteElementString("AMP_OC_DAO", _ExporterVal.ToString());
			xmlWriter_0.WriteElementString("AMP_OC_Speed", XmlConvert.ToString(m_PrototypeVal));
			if (AddDescriptor() > 0f)
			{
				xmlWriter_0.WriteElementString("TTReseek", XmlConvert.ToString(AddDescriptor()));
			}
			if (CruiseAltitude_ASL != 0f)
			{
				xmlWriter_0.WriteElementString("CruiseAltitude_ASL", XmlConvert.ToString(CruiseAltitude_ASL));
			}
			xmlWriter_0.WriteElementString("DamagePts", XmlConvert.ToString(GetDamagePts()));
			if (_AirFacilities.Length != 0)
			{
				xmlWriter_0.WriteStartElement("AirFacilities");
				AirFacility[] airFacilities = _AirFacilities;
				AirFacility[] array5 = airFacilities;
				foreach (AirFacility airFacility in array5)
				{
					xmlWriter_0.WriteRaw(airFacility.ToXML(hashSet_0));
				}
				xmlWriter_0.WriteEndElement();
			}
			if (_DockFacilities.Length != 0)
			{
				xmlWriter_0.WriteStartElement("DockFacilities");
				DockFacility[] dockFacilities = _DockFacilities;
				DockFacility[] array6 = dockFacilities;
				foreach (DockFacility dockFacility in array6)
				{
					xmlWriter_0.WriteRaw(dockFacility.ToXML(hashSet_0));
				}
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(_AssignedMissionOrPackage))
			{
				xmlWriter_0.WriteElementString("AssignedMission", _AssignedMissionOrPackage.ObjectID);
			}
			if (!Information.IsNothing(AssignedTaskPool))
			{
				xmlWriter_0.WriteElementString("AssignedTaskPool", _AssignedTaskPool.ObjectID);
			}
			if (!Information.IsNothing(GetParentGroup()))
			{
				xmlWriter_0.WriteElementString("ParentGroup", _ParentGroup.ObjectID);
			}
			if (GetIsAutoDetectable(null))
			{
				xmlWriter_0.WriteElementString("IsAD", GetIsAutoDetectable(null).ToString());
			}
			Doctrine.ToXML(ref xmlWriter_0, ref ParentScen);
			xmlWriter_0.WriteStartElement("Warheads");
			Warhead[] warheads = Warheads;
			for (int i = 0; i < warheads.Length; i = checked(i + 1))
			{
				warheads[i].ToXML(ref xmlWriter_0);
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteElementString("BT", _BlindTime.ToString());
			xmlWriter_0.WriteElementString("DRT", _DatalinkRetargetTime.ToString());
			if (!Information.IsNothing(DataLinkParent))
			{
				xmlWriter_0.WriteElementString("DataLinkParent", DataLinkParent.ObjectID);
			}
			if (!Information.IsNothing(FiringParent))
			{
				xmlWriter_0.WriteElementString("FiringParent", FiringParent.ObjectID);
			}
			if (!Information.IsNothing(SearchPatternType))
			{
				XmlWriter obj4 = xmlWriter_0;
				status = (byte)SearchPatternType;
				obj4.WriteElementString("SearchPatternType", status.ToString());
			}
			xmlWriter_0.WriteElementString("Guidance", ((int)Guidance).ToString());
			if (LaunchPoint != null)
			{
				xmlWriter_0.WriteStartElement("LaunchPoint");
				xmlWriter_0.WriteRaw(LaunchPoint.ToXML(hashSet_0));
				xmlWriter_0.WriteEndElement();
			}
			if (TimeSinceLaunch > 0f)
			{
				xmlWriter_0.WriteElementString("TSL", XmlConvert.ToString(TimeSinceLaunch));
			}
			if (TimeSinceBurnout > 0f)
			{
				xmlWriter_0.WriteElementString("TSB", XmlConvert.ToString(TimeSinceBurnout));
			}
			xmlWriter_0.WriteElementString("TTD", XmlConvert.ToString(m_ObserverReader));
			if (!Information.IsNothing(issuerReader))
			{
				xmlWriter_0.WriteElementString("SIFM", issuerReader.ObjectID);
			}
			if (!Information.IsNothing(ARM_SpecifiedEMission.Value))
			{
				xmlWriter_0.WriteStartElement("ARM_SE");
				xmlWriter_0.WriteElementString("Emission" + ARM_SpecifiedEMission.Key, ARM_SpecifiedEMission.Value.ToString());
				xmlWriter_0.WriteEndElement();
			}
			if (IsPalletWeapon && WeaponWeapons.Count == 0)
			{
				Warhead[] warheads2 = Warheads;
				Warhead[] array7 = warheads2;
				foreach (Warhead Local_theWH in array7)
				{
					if (Local_theWH.GetCarriedWeapon(ParentScen) != null && WeaponWeapons.Where((WeaponRec theCW) => theCW.GetReferenceWeapon(ParentScen).DBID == Local_theWH.GetCarriedWeapon(ParentScen).DBID).Count() <= 0)
					{
						int num = Warheads.Where((Warhead theW) => theW.GetCarriedWeapon(ParentScen).DBID == Local_theWH.GetCarriedWeapon(ParentScen).DBID).Count();
						WeaponRec item = new WeaponRec(ref ParentScen, Local_theWH.GetCarriedWeapon(ParentScen).DBID, num, num, 1, 1, bool_0: false, bool_1: false);
						WeaponWeapons.Add(item);
					}
				}
			}
			if (WeaponWeapons.Count > 0)
			{
				xmlWriter_0.WriteStartElement("WeaponWeapons");
				foreach (WeaponRec weaponWeapon in WeaponWeapons)
				{
					xmlWriter_0.WriteRaw(weaponWeapon.ToXML(hashSet_0, ParentScen));
				}
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteElementString("ARM_SEIM", ARM_SpecifiedEmissionIsMandatory.ToString());
			if (!Information.IsNothing(_IlluminatorUnit))
			{
				xmlWriter_0.WriteElementString("IlluminatorUnit", _IlluminatorUnit.ObjectID);
			}
			Navigator.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteStartElement("Weapon_AI");
			AI.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Weapon_Kinematics");
			Kinematics.ToXML(ref xmlWriter_0);
			xmlWriter_0.WriteEndElement();
			Sensory.ToXML(ref xmlWriter_0);
			CommStuff.ToXML(ref xmlWriter_0, ref hashSet_0);
			Damage.ToXML(ref xmlWriter_0, ref hashSet_0);
			if (SetReponse())
			{
				xmlWriter_0.WriteElementString("WasAirLaunched", "True");
			}
			if (SetReponse())
			{
				xmlWriter_0.WriteElementString("WasAirLaunched", "True");
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100881", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	protected Weapon(string string_0 = null)
	{
		Warheads = new Warhead[0];
		Directors = new List<int>();
		Flags = default(WeaponFlags);
		WeaponWeapons = new ObservableList<WeaponRec>();
		ValidSpecialModes = new List<WeaponSpecialMode>();
		_FacadeReader = false;
		IsMIRVedMissile = new Lazy<bool>(RestartReponse);
		IsMRVedMissile = new Lazy<bool>(TestReponse);
		UsesBoostCoastModel = new Lazy<bool>(FillReponse);
		IsNuke = new Lazy<bool>(CompareReponse);
		ActiveUnit activeUnit_ = this;
		_Navigator = new Weapon_Navigator(ref activeUnit_);
		m_ReaderReader = new Weapon_AI(this);
		_InvocationReader = false;
		HasRVs = new Lazy<bool>(RevertReponse);
		if (string.IsNullOrEmpty(string_0))
		{
			ObjectID_Set(IDGenerator.Instance.Next.ToLower());
		}
		else
		{
			ObjectID_Set(string_0);
		}
		IsWeapon = true;
		EvaluateIfDumb();
	}

	public new static Weapon FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		Weapon weapon = null;
		try
		{
			weapon = FromXML_Private(xmlNode_0, concurrentDictionary_0, scenario_0, scenario_0.LoadStockUnits);
			return weapon;
		}
		catch (PlatformComponentNotFoundException projectError)
		{
			ProjectData.SetProjectError(projectError);
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			ConcurrentDictionary<string, ScenarioObject> obj = concurrentDictionary_0;
			ScenarioObject value = weapon;
			obj.TryRemove(innerText, out value);
			weapon = FromXML_Private(xmlNode_0, concurrentDictionary_0, scenario_0, bool_0: true);
			string text = "";
			if (weapon.IsGroupMember())
			{
				text = "(member of group: [" + weapon.GetParentGroup().Name + "])";
			}
			scenario_0.LoadingNotices.Add("The following weapon:[" + weapon.Name + "]" + text + " failed to shallow-rebuild because of a component missing. The weapon was instead deep-rebuilt, and instantiated in its pristine DB-stock condition. All customizations present in the weapon's components (damaged components, additions/removals etc. etc.) have been lost. Please re-apply any necessary customizations either manually or using an SBR script.");
			ProjectData.ClearProjectError();
			return weapon;
		}
	}

	public void InitializeWeaponWeaponsPallet()
	{
		if (WeaponWeapons.Count != 0)
		{
			return;
		}
		Warhead[] warheads = Warheads;
		Warhead[] array = warheads;
		foreach (Warhead Local_theWH in array)
		{
			if (Local_theWH.GetCarriedWeapon(ParentScen) != null && WeaponWeapons.Where((WeaponRec theCW) => theCW.GetReferenceWeapon(ParentScen).DBID == Local_theWH.GetCarriedWeapon(ParentScen).DBID).Count() <= 0)
			{
				int num = Warheads.Where((Warhead w) => w.GetCarriedWeapon(ParentScen).DBID == Local_theWH.GetCarriedWeapon(ParentScen).DBID).Count();
				WeaponRec item = new WeaponRec(ref ParentScen, Local_theWH.GetCarriedWeapon(ParentScen).DBID, num, num, 1, 1, bool_0: false, bool_1: false);
				WeaponWeapons.Add(item);
			}
		}
	}

	protected static void LoadSavedComponents(Weapon weapon_0, Scenario scenario_0, XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		IEnumerator enumerator = null;
		try
		{
			enumerator = xmlNode_0.ChildNodes.GetEnumerator();
			IEnumerator enumerator2 = null;
			IEnumerator enumerator3 = null;
			IEnumerator enumerator4 = null;
			IEnumerator enumerator5 = null;
			IEnumerator enumerator6 = null;
			IEnumerator enumerator7 = null;
			IEnumerator enumerator8 = null;
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				switch (xmlNode.Name)
				{
				case "OnboardCargo":
					try
					{
						enumerator5 = xmlNode.ChildNodes.GetEnumerator();
						while (enumerator5.MoveNext())
						{
							XmlNode xmlNode_5 = (XmlNode)enumerator5.Current;
							Cargo cargo = Cargo.FromXML(ref xmlNode_5, ref concurrentDictionary_0, scenario_0, weapon_0);
							ArrayExtensions.Add(ref weapon_0.OnboardCargo, cargo);
							cargo.ParentPlatform = weapon_0;
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
				case "WeaponWeapons":
					try
					{
						enumerator8 = xmlNode.ChildNodes.GetEnumerator();
						while (enumerator8.MoveNext())
						{
							XmlNode xmlNode_7 = (XmlNode)enumerator8.Current;
							WeaponRec item2 = WeaponRec.FromXML(ref xmlNode_7, ref concurrentDictionary_0, ref scenario_0);
							weapon_0.WeaponWeapons.Add(item2);
						}
					}
					finally
					{
						if (enumerator8 is IDisposable)
						{
							(enumerator8 as IDisposable).Dispose();
						}
					}
					break;
				case "Fuel":
					try
					{
						enumerator3 = xmlNode.ChildNodes.GetEnumerator();
						while (enumerator3.MoveNext())
						{
							XmlNode xmlNode_6 = (XmlNode)enumerator3.Current;
							FuelRec item = FuelRec.FromXML(ref xmlNode_6, ref concurrentDictionary_0);
							weapon_0._Fuel.Add(item);
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
				case "Comms":
				{
					int num = xmlNode.ChildNodes.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						XmlNode xmlNode_4 = xmlNode.ChildNodes[i];
						CommDevice commDevice = CommDevice.FromXML(ref xmlNode_4, ref concurrentDictionary_0, weapon_0);
						if (commDevice.DBID == 0)
						{
							Weapon weapon = new Weapon();
							weapon.ParentScen = scenario_0;
							DBFunctions.GetWeapon(scenario_0.DBConnection, weapon, weapon_0.DBID, scenario_0);
							try
							{
								commDevice = weapon.Comms_ReadOnly[i];
								weapon = null;
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError(ex);
								Exception exception_ = ex;
								exception_?.Data.Add("Error at 101179", "");
								GameGeneral.WriteExceptionsToLog(ref exception_);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
							concurrentDictionary_0.TryAdd(commDevice.ObjectID, commDevice);
						}
						if (weapon_0.Type == _WeaponType.Sonobuoy)
						{
							commDevice.ParentSpecific = false;
						}
						weapon_0.AddCommDevice(commDevice);
						commDevice.ParentPlatform = weapon_0;
					}
					break;
				}
				case "Sensors":
					try
					{
						enumerator7 = xmlNode.ChildNodes.GetEnumerator();
						while (enumerator7.MoveNext())
						{
							Sensor sensor = Sensor.FromXML((XmlNode)enumerator7.Current, concurrentDictionary_0, weapon_0);
							ArrayExtensions.Add(ref weapon_0._Sensors, sensor);
							sensor.ParentPlatform = weapon_0;
						}
					}
					finally
					{
						if (enumerator7 is IDisposable)
						{
							(enumerator7 as IDisposable).Dispose();
						}
					}
					break;
				case "Propulsion":
					try
					{
						enumerator6 = xmlNode.ChildNodes.GetEnumerator();
						while (enumerator6.MoveNext())
						{
							XmlNode xmlNode_3 = (XmlNode)enumerator6.Current;
							ActiveUnit activeUnit_ = weapon_0;
							Engine engine = Engine.FromXML(ref xmlNode_3, ref concurrentDictionary_0, ref activeUnit_);
							weapon_0.Propulsion.Add(engine);
							engine.ParentPlatform = weapon_0;
						}
					}
					finally
					{
						if (enumerator6 is IDisposable)
						{
							(enumerator6 as IDisposable).Dispose();
						}
					}
					break;
				case "AirFacilities":
					try
					{
						enumerator2 = xmlNode.ChildNodes.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							XmlNode xmlNode_2 = (XmlNode)enumerator2.Current;
							AirFacility airFacility = AirFacility.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref scenario_0);
							weapon_0.AddAirFacility(airFacility);
							airFacility.ParentPlatform = weapon_0;
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
				case "Mounts":
					try
					{
						enumerator4 = xmlNode.ChildNodes.GetEnumerator();
						while (enumerator4.MoveNext())
						{
							XmlNode xmlNode_ = (XmlNode)enumerator4.Current;
							Mount mount = Mount.FromXML(ref xmlNode_, ref concurrentDictionary_0, weapon_0);
							weapon_0.Mounts.Add(mount);
							mount.ParentPlatform = weapon_0;
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

	protected static Weapon FromXML_Private(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0, bool bool_0)
	{
		try
		{
			XmlNode xmlNode = Misc.StartRequest(xmlNode_0.ChildNodes, "DBID");
			int num = 0;
			if (xmlNode != null)
			{
				num = Conversions.ToInteger(xmlNode.InnerText);
				switch (DBFunctions.GetWeaponType(num, scenario_0))
				{
				case _WeaponType.GuidedProjectile:
					return GuidedProjectile.FromXML_Private(xmlNode_0, concurrentDictionary_0, scenario_0, bool_0);
				case _WeaponType.Rocket:
					return UnguidedRocket.FromXML_Private(xmlNode_0, concurrentDictionary_0, scenario_0, bool_0);
				case _WeaponType.HGV:
					return HGV.FromXML_Private(xmlNode_0, concurrentDictionary_0, scenario_0, bool_0);
				case _WeaponType.BallisticMissile:
					return BallisticMissile.FromXML_Private(xmlNode_0, concurrentDictionary_0, scenario_0, bool_0);
				case _WeaponType.Torpedo:
					return Torpedo.FromXML_Private(xmlNode_0, concurrentDictionary_0, scenario_0, bool_0);
				}
			}
			Weapon weapon = new Weapon();
			weapon.ParentScen = scenario_0;
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (concurrentDictionary_0.ContainsKey(innerText))
			{
				return (Weapon)concurrentDictionary_0[innerText];
			}
			weapon.ObjectID_Set(innerText);
			if (xmlNode_0.ChildNodes.Count == 1)
			{
				scenario_0.UnitsForLateInstantiation.Add(xmlNode_0);
				return weapon;
			}
			concurrentDictionary_0.TryAdd(weapon.ObjectID, weapon);
			DBFunctions.GetWeapon(scenario_0.DBConnection, weapon, num, scenario_0, bool_0);
			weapon.DBID = num;
			if (weapon.IsHGV)
			{
				weapon.CruiseAltitude_ASL = 100000f;
			}
			if (bool_0)
			{
				weapon.RegisterIssuer(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0);
			}
			if (!bool_0)
			{
				LoadSavedComponents(weapon, scenario_0, xmlNode_0, concurrentDictionary_0);
			}
			LoadMutableProperties(weapon, scenario_0, xmlNode_0, concurrentDictionary_0);
			float maximumAltitude = weapon.Kinematics.GetMaximumAltitude();
			float minimumAltitude = weapon.Kinematics.GetMinimumAltitude();
			if (weapon.GetCurrentAltitude() > maximumAltitude && (weapon.Type == _WeaponType.GuidedWeapon || weapon.Type == _WeaponType.Torpedo))
			{
				weapon.SetCurrentAltitude(bool_0: false, maximumAltitude);
			}
			else if (weapon.GetCurrentAltitude() < minimumAltitude && (weapon.Type == _WeaponType.GuidedWeapon || weapon.Type == _WeaponType.Torpedo))
			{
				weapon.SetCurrentAltitude(bool_0: false, minimumAltitude);
			}
			if (weapon.DesiredAltitude > maximumAltitude && (weapon.Type == _WeaponType.GuidedWeapon || weapon.Type == _WeaponType.Torpedo))
			{
				weapon.DesiredAltitude = maximumAltitude;
			}
			else if (weapon.DesiredAltitude < minimumAltitude && (weapon.Type == _WeaponType.GuidedWeapon || weapon.Type == _WeaponType.Torpedo))
			{
				weapon.DesiredAltitude = minimumAltitude;
			}
			weapon.EvaluateIfDumb();
			if (weapon.IsPalletWeapon && weapon.WeaponWeapons.Count == 0)
			{
				weapon.InitializeWeaponWeaponsPallet();
			}
			if (weapon.IsReEntryVehicle && !weapon.HasTerminalGuidance && weapon.Navigator.PlottedCourse.Count() == 1 && weapon.AI.PrimaryTarget != null && weapon.AI.PrimaryTarget_Type == Contact_Base.ContactType.Aimpoint)
			{
				weapon.Navigator.PlottedCourse[0].Altitude = weapon.AI.PrimaryTarget.GetCurrentAltitude();
			}
			return weapon;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100882", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Weapon result = new Weapon();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	protected static void LoadMutableProperties(Weapon weapon_0, Scenario scenario_0, XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
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
				XmlNode xmlNode_ = (XmlNode)enumerator.Current;
				switch (xmlNode_.Name)
				{
				case "Name":
					weapon_0.Name = xmlNode_.InnerText;
					break;
				case "FSBR":
					weapon_0.comparatorVal = (_ActiveUnitFuelState)Conversions.ToByte(xmlNode_.InnerText);
					break;
				case "Status":
					if (Versioned.IsNumeric(xmlNode_.InnerText))
					{
						weapon_0.Status = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_.InnerText);
					}
					else
					{
						weapon_0.Status = (_ActiveUnitStatus)Enum.Parse(typeof(_ActiveUnitStatus), xmlNode_.InnerText, ignoreCase: true);
					}
					if (weapon_0.Status == (_ActiveUnitStatus)9)
					{
						weapon_0.Status = _ActiveUnitStatus.RTB;
					}
					break;
				case "AMP_OC_Speed":
					weapon_0.m_PrototypeVal = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "SBED_Altitude_TF":
					weapon_0.m_MockVal = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "SBPF_TF":
					weapon_0.m_SystemVal = Conversions.ToBoolean(xmlNode_.InnerText);
					break;
				case "LatLR":
					weapon_0.Latitude_LastReported = XmlConvert.ToDouble(xmlNode_.InnerText.Replace(",", "."));
					break;
				case "DRT":
					weapon_0._DatalinkRetargetTime = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
					break;
				case "FuelState":
					weapon_0._FuelState = (_ActiveUnitFuelState)Conversions.ToByte(xmlNode_.InnerText);
					break;
				case "Weapon_AI":
					Weapon_AI.FromXML(xmlNode_, concurrentDictionary_0, weapon_0);
					if (weapon_0.GetDesiredAltitude_UseTerrainFollowing(weapon_0) && weapon_0.DesiredAltitude_AGL == 0f)
					{
						weapon_0.DesiredAltitude_AGL = 60.96f;
					}
					break;
				case "CruiseAltitude_ASL":
					weapon_0.CruiseAltitude_ASL = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "IlluminatorUnit":
					weapon_0._IlluminatorUnit = ActiveUnit.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref scenario_0);
					break;
				case "Weapon_Navigator":
				{
					ActiveUnit activeUnit_4 = weapon_0;
					weapon_0._Navigator = Weapon_Navigator.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_4);
					break;
				}
				case "Weapon_CommStuff":
				{
					ActiveUnit activeUnit_3 = weapon_0;
					weapon_0.repositoryReader = Weapon_CommStuff.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_3);
					break;
				}
				case "SBED_Altitude":
					weapon_0.m_MappingVal = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "DamagePts":
					weapon_0.SetDamagePts(bool_0: false, null, XmlConvert.ToSingle(xmlNode_.InnerText));
					break;
				case "AMP_OC_DAO":
					weapon_0._ExporterVal = Conversions.ToBoolean(xmlNode_.InnerText);
					break;
				case "TSB":
					weapon_0.TimeSinceBurnout = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "SBPF_ThrottleSetting":
					switch (xmlNode_.InnerText)
					{
					default:
						weapon_0.candidateVal = (Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Loiter":
						weapon_0.candidateVal = Throttle.Loiter;
						break;
					case "FullStop":
						weapon_0.candidateVal = Throttle.FullStop;
						break;
					case "Full":
						weapon_0.candidateVal = Throttle.Full;
						break;
					case "Flank":
						weapon_0.candidateVal = Throttle.Flank;
						break;
					case "Cruise":
						weapon_0.candidateVal = Throttle.Cruise;
						break;
					}
					break;
				case "BT":
				case "BlindTime":
					weapon_0._BlindTime = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
					break;
				case "TSL":
					weapon_0.TimeSinceLaunch = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "SBR_Altitude_TF":
					weapon_0.setterVal = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "SBPF_Altitude_TF":
					weapon_0.serviceVal = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "DesiredHeading":
				case "DH":
					weapon_0.SetDesiredHeading(TurnRate.Max, XmlConvert.ToSingle(xmlNode_.InnerText));
					break;
				case "SIFM":
				case "SensorIlluminatingForMe":
					weapon_0._SensorIlluminatingForMe_ObjectID = xmlNode_.InnerText;
					break;
				case "DataLinkParent":
					weapon_0._DataLinkParent_ID = xmlNode_.InnerText;
					break;
				case "SBR":
					weapon_0.predicateVal = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_.InnerText);
					break;
				case "SBED_ThrottleSetting":
					switch (xmlNode_.InnerText)
					{
					default:
						weapon_0.fieldVal = (Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Loiter":
						weapon_0.fieldVal = Throttle.Loiter;
						break;
					case "FullStop":
						weapon_0.fieldVal = Throttle.FullStop;
						break;
					case "Full":
						weapon_0.fieldVal = Throttle.Full;
						break;
					case "Flank":
						weapon_0.fieldVal = Throttle.Flank;
						break;
					case "Cruise":
						weapon_0.fieldVal = Throttle.Cruise;
						break;
					}
					break;
				case "TS":
				case "ThrottleSetting":
					switch (xmlNode_.InnerText)
					{
					default:
						weapon_0.ThrottleSetting = (Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Loiter":
						weapon_0.ThrottleSetting = Throttle.Loiter;
						break;
					case "FullStop":
						weapon_0.ThrottleSetting = Throttle.FullStop;
						break;
					case "Full":
						weapon_0.ThrottleSetting = Throttle.Full;
						break;
					case "Flank":
						weapon_0.ThrottleSetting = Throttle.Flank;
						break;
					case "Cruise":
						weapon_0.ThrottleSetting = Throttle.Cruise;
						break;
					}
					break;
				case "SBED_DesiredSpeedOverride":
					weapon_0.queueVal = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "WeaponState":
					weapon_0._WeaponState = (_ActiveUnitWeaponState)Conversions.ToByte(xmlNode_.InnerText);
					break;
				case "Doctrine":
					weapon_0.Doctrine = Doctrine.FromXML(ref xmlNode_, weapon_0);
					break;
				case "ActiveEnterAreaTriggers":
					try
					{
						enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							string innerText2 = ((XmlNode)enumerator2.Current).InnerText;
							weapon_0.ActiveEnterAreaTriggers.Add(innerText2);
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
				case "Weapon_Kinematics":
					ActiveUnit_Kinematics.FromXML(xmlNode_, concurrentDictionary_0, weapon_0);
					break;
				case "SBEO_TF":
					weapon_0.m_PageVal = Conversions.ToBoolean(xmlNode_.InnerText);
					break;
				case "SBED_TF":
					weapon_0.tagVal = Conversions.ToBoolean(xmlNode_.InnerText);
					break;
				case "CurrentAltitude":
				case "CA":
					weapon_0.SetCurrentAltitude(bool_0: false, XmlConvert.ToSingle(xmlNode_.InnerText));
					break;
				case "Latitude_UnitEntersAreaCheck":
					weapon_0.Latitude__UnitEntersAreaCheck = XmlConvert.ToDouble(xmlNode_.InnerText);
					break;
				case "AMP_OC_DSO":
					weapon_0._VisitorVal = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "DA":
				case "DesiredAltitude":
					weapon_0.DesiredAltitude = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "Pitch":
					weapon_0.Attitude_Pitch = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "TerrainFollowing":
					weapon_0.SetDesiredAltitude_UseTerrainFollowing(weapon_0, Conversions.ToBoolean(xmlNode_.InnerText));
					break;
				case "WasAirLaunched":
					weapon_0._RequestReader = Conversions.ToBoolean(xmlNode_.InnerText);
					break;
				case "AssignedMission":
					if (xmlNode_.HasChildNodes)
					{
						XmlNode xmlNode2 = xmlNode_.ChildNodes[0];
						weapon_0._AssignedMissionOrPackage_ID = xmlNode2.InnerText;
					}
					break;
				case "ActiveRemainAreaTriggers":
				{
					string key2 = null;
					DateTime result = DateTime.MinValue;
					try
					{
						enumerator3 = xmlNode_.ChildNodes.GetEnumerator();
						while (enumerator3.MoveNext())
						{
							XmlNode xmlNode = (XmlNode)enumerator3.Current;
							if (Operators.CompareString(xmlNode.Name, "RemainAreaTrigger", TextCompare: false) == 0)
							{
								key2 = xmlNode.InnerText;
								result = DateTime.MinValue;
								continue;
							}
							if (DateTime.TryParse(xmlNode.InnerText, CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
							{
								weapon_0.ActiveRemainAreaTriggers.Add(key2, result);
								continue;
							}
							string innerText = xmlNode.InnerText;
							long result2 = 0L;
							if (long.TryParse(innerText, out result2))
							{
								result = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
								weapon_0.ActiveRemainAreaTriggers.Add(key2, result);
							}
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
				case "Roll":
					weapon_0.Attitude_Roll = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "FiringParent":
					weapon_0._FiringParent_ID = xmlNode_.InnerText;
					break;
				case "Side":
					weapon_0._SideName = xmlNode_.InnerText;
					break;
				case "Longitude":
				case "Lon":
					weapon_0.SetLongitude(null, XmlConvert.ToDouble(xmlNode_.InnerText));
					break;
				case "LaunchPoint":
				{
					XmlNode xmlNode_3 = xmlNode_.FirstChild;
					weapon_0.LaunchPoint = GeoPoint.FromXML(ref xmlNode_3, ref concurrentDictionary_0);
					break;
				}
				case "TTD":
				case "TimeToDetonate":
					xmlNode_.InnerText = xmlNode_.InnerText.Replace(",", ".");
					weapon_0.m_ObserverReader = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "ARM_SpecifiedEmission":
				case "ARM_SE":
					try
					{
						enumerator4 = xmlNode_.ChildNodes.GetEnumerator();
						while (enumerator4.MoveNext())
						{
							XmlNode obj = (XmlNode)enumerator4.Current;
							int key = Conversions.ToInteger(obj.Name.Remove(0, 8));
							string string_ = obj.InnerText;
							EmissionContainer value = EmissionContainer.FromString(ref string_);
							obj.InnerText = string_;
							weapon_0.ARM_SpecifiedEMission = new KeyValuePair<int, EmissionContainer>(key, value);
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
				case "SearchPatternType":
					weapon_0.SearchPatternType = (WeaponSearchPatternType)Conversions.ToByte(xmlNode_.InnerText);
					break;
				case "Warheads":
					try
					{
						enumerator5 = xmlNode_.ChildNodes.GetEnumerator();
						while (enumerator5.MoveNext())
						{
							XmlNode xmlNode_2 = (XmlNode)enumerator5.Current;
							Warhead theAC = Warhead.FromXML(ref xmlNode_2, ref concurrentDictionary_0);
							ArrayExtensions.Add(ref weapon_0.Warheads, theAC);
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
				case "DS":
				case "DesiredSpeed":
					weapon_0.DesiredSpeed = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "TTReseek":
					weapon_0.DestroyDescriptor(XmlConvert.ToSingle(xmlNode_.InnerText));
					break;
				case "CEP_Land":
					weapon_0.CEP_Land = Conversions.ToInteger(xmlNode_.InnerText);
					break;
				case "SBEO_Altitude":
					weapon_0.regVal = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "SBPF_Altitude":
					weapon_0._MethodVal = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "SBR_ThrottleSetting":
					switch (xmlNode_.InnerText)
					{
					default:
						weapon_0._TemplateVal = (Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Loiter":
						weapon_0._TemplateVal = Throttle.Loiter;
						break;
					case "FullStop":
						weapon_0._TemplateVal = Throttle.FullStop;
						break;
					case "Full":
						weapon_0._TemplateVal = Throttle.Full;
						break;
					case "Flank":
						weapon_0._TemplateVal = Throttle.Flank;
						break;
					case "Cruise":
						weapon_0._TemplateVal = Throttle.Cruise;
						break;
					}
					break;
				case "Message":
					weapon_0.Message = xmlNode_.InnerText;
					break;
				case "SBEO_Altitude_TF":
					weapon_0.paramVal = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "CEP":
				case "CEP_Surface":
					weapon_0.CEP_Surface = Conversions.ToInteger(xmlNode_.InnerText);
					break;
				case "SBR_Altitude":
					weapon_0._ItemVal = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "Latitude":
				case "Lat":
					weapon_0.SetLatitude(null, XmlConvert.ToDouble(xmlNode_.InnerText));
					break;
				case "SBEO":
					weapon_0._RecordVal = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_.InnerText);
					break;
				case "LonLR":
					weapon_0.Longitude_LastReported = XmlConvert.ToDouble(xmlNode_.InnerText.Replace(",", "."));
					break;
				case "AMP_OC":
					weapon_0.m_AttrVal = Conversions.ToBoolean(xmlNode_.InnerText);
					break;
				case "Weapon_Sensory":
				{
					ActiveUnit activeUnit_2 = weapon_0;
					weapon_0.importerReader = Weapon_Sensory.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_2);
					break;
				}
				case "CS":
				case "CurrentSpeed":
					weapon_0.CurrentSpeed = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "SBR_TF":
					weapon_0._CreatorVal = Conversions.ToBoolean(xmlNode_.InnerText);
					break;
				case "ARM_SEIM":
				case "ARM_SpecifiedEmissionIsMandatory":
					weapon_0.ARM_SpecifiedEmissionIsMandatory = Conversions.ToBoolean(xmlNode_.InnerText);
					break;
				case "SBEO_ThrottleSetting":
					switch (xmlNode_.InnerText)
					{
					default:
						weapon_0.m_RulesVal = (Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Loiter":
						weapon_0.m_RulesVal = Throttle.Loiter;
						break;
					case "FullStop":
						weapon_0.m_RulesVal = Throttle.FullStop;
						break;
					case "Full":
						weapon_0.m_RulesVal = Throttle.Full;
						break;
					case "Flank":
						weapon_0.m_RulesVal = Throttle.Flank;
						break;
					case "Cruise":
						weapon_0.m_RulesVal = Throttle.Cruise;
						break;
					}
					break;
				case "SBED":
					weapon_0._SingletonVal = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_.InnerText);
					break;
				case "Longitude_UnitEntersAreaCheck":
					weapon_0.Longitude__UnitEntersAreaCheck = XmlConvert.ToDouble(xmlNode_.InnerText);
					break;
				case "ParentGroup":
					weapon_0._ParentGroup_ID = xmlNode_.InnerText;
					break;
				case "ImpactAltitude":
					weapon_0.ImpactAltitude = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "CH":
				case "CurrentHeading":
					weapon_0.CurrentHeading = XmlConvert.ToSingle(xmlNode_.InnerText);
					break;
				case "Weapon_Damage":
				{
					ActiveUnit activeUnit_ = weapon_0;
					weapon_0._BridgeReader = Weapon_Damage.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_);
					break;
				}
				case "IsAD":
				case "IsAutoDetectable":
					weapon_0.SetIsAutoDetectable(null, Conversions.ToBoolean(xmlNode_.InnerText));
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
	}

	public override void PostDeserializationHousekeeping_General(ref Scenario scenario_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, List<ActiveUnit> list_0, bool bool_0)
	{
		try
		{
			base.PostDeserializationHousekeeping_General(ref scenario_0, concurrentDictionary_0, list_0, bool_0);
			if (!Information.IsNothing(_DataLinkParent_ID))
			{
				scenario_0.ActiveUnits.TryGetValue(_DataLinkParent_ID, ref valReader);
			}
			if (!Information.IsNothing(_FiringParent_ID))
			{
				scenario_0.ActiveUnits.TryGetValue(_FiringParent_ID, ref m_DefinitionReader);
			}
			if (!Information.IsNothing(_SensorIlluminatingForMe_ObjectID))
			{
				foreach (ActiveUnit value in scenario_0.ActiveUnits.Values)
				{
					Sensor[] array = value.Sensors_ReadOnly();
					Sensor[] array2 = array;
					foreach (Sensor sensor in array2)
					{
						if (string.CompareOrdinal(sensor.ObjectID, _SensorIlluminatingForMe_ObjectID) == 0)
						{
							issuerReader = sensor;
							return;
						}
					}
				}
			}
			if (AI.PrimaryTarget != null && AI.PrimaryTarget.ActualUnit == null)
			{
				Contact primaryTarget = AI.PrimaryTarget;
				Side side_ = GetUnitSide();
				primaryTarget.PostDeserializationHousekeeping(ref scenario_0, ref concurrentDictionary_0, ref side_);
				SetUnitSide(bool_0: false, side_);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100883", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	public override float GetCurrentAltitude(bool bool_0 = false)
	{
		return base.GetCurrentAltitude(bool_0);
	}

	[SpecialName]
	public override void SetCurrentAltitude(bool bool_0, float float_0)
	{
		if (bool_0 && IsGuidedWeapon() && float_0 < 6.0959997f)
		{
			float_0 = 6.0959997f;
		}
		base.SetCurrentAltitude(bool_0, float_0);
	}

	public override Sensor[] Sensors_ReadOnly()
	{
		return _Sensors;
	}

	[SpecialName]
	public override bool GetDesiredAltitude_UseTerrainFollowing(ActiveUnit activeUnit_0)
	{
		return _TerrainFollowing;
	}

	[SpecialName]
	public override void SetDesiredAltitude_UseTerrainFollowing(ActiveUnit activeUnit_0, bool bool_0)
	{
		_TerrainFollowing = bool_0;
	}

	internal float CreateReponse(GlobalVariables.ArmorRating armorRating_0, GlobalVariables.TargetVisualSizeClass targetVisualSizeClass_0)
	{
		Warhead warhead = Warheads[0];
		if (armorRating_0 == GlobalVariables.ArmorRating.None && Type == _WeaponType.Gun)
		{
			switch (targetVisualSizeClass_0)
			{
			case GlobalVariables.TargetVisualSizeClass.Stealthy:
				return 100f;
			case GlobalVariables.TargetVisualSizeClass.Small:
				if ((uint)(warhead.Caliber - 2001) > 1u)
				{
					return 100f;
				}
				break;
			case GlobalVariables.TargetVisualSizeClass.Medium:
				if ((uint)(warhead.Caliber - 2001) > 2u)
				{
					return 100f;
				}
				break;
			case GlobalVariables.TargetVisualSizeClass.Large:
			case GlobalVariables.TargetVisualSizeClass.VLarge:
				if ((uint)(warhead.Caliber - 2001) > 3u)
				{
					return 100f;
				}
				break;
			}
		}
		short num = 0;
		switch (warhead.Type)
		{
		case Warhead.WarheadType.Incendiary:
			num = 0;
			break;
		case Warhead.WarheadType.SuperFrag:
		case Warhead.WarheadType.Fragmentation_ABM:
			switch (armorRating_0)
			{
			case GlobalVariables.ArmorRating.Armor_Handgun:
				num = 100;
				break;
			case GlobalVariables.ArmorRating.None:
				num = 100;
				break;
			case GlobalVariables.ArmorRating.Armor_HMG:
				num = 80;
				break;
			case GlobalVariables.ArmorRating.Armor_Rifle:
				num = 90;
				break;
			case GlobalVariables.ArmorRating.RHA_25mm:
				num = 60;
				break;
			case GlobalVariables.ArmorRating.RHA_20mm:
				num = 70;
				break;
			case GlobalVariables.ArmorRating.Light:
				num = 30;
				break;
			case GlobalVariables.ArmorRating.Medium:
				return 0f;
			case GlobalVariables.ArmorRating.Heavy:
				return 0f;
			case GlobalVariables.ArmorRating.Special:
				return 0f;
			case GlobalVariables.ArmorRating.RHA_35mm:
				num = 40;
				break;
			case GlobalVariables.ArmorRating.RHA_30mm:
				num = 50;
				break;
			}
			break;
		case Warhead.WarheadType.Weapon:
			return Warheads[0].GetCarriedWeapon(ParentScen).CreateReponse(armorRating_0, targetVisualSizeClass_0);
		case Warhead.WarheadType.Nuclear:
			num = 0;
			break;
		case Warhead.WarheadType.HEAT:
		case Warhead.WarheadType.Torpedo_ASWOptimized:
		case Warhead.WarheadType.Cluster_AT:
		{
			if (1 == 0)
			{
			}
			short num3 = armorRating_0 switch
			{
				GlobalVariables.ArmorRating.Medium => 60, 
				GlobalVariables.ArmorRating.Heavy => 35, 
				GlobalVariables.ArmorRating.Special => 15, 
				_ => 100, 
			};
			if (1 == 0)
			{
			}
			num = num3;
			break;
		}
		case Warhead.WarheadType.Fragmentation:
		case Warhead.WarheadType.ContinuousRod:
		case Warhead.WarheadType.Cluster_AP:
			switch (armorRating_0)
			{
			case GlobalVariables.ArmorRating.None:
			case GlobalVariables.ArmorRating.Armor_Handgun:
				num = 100;
				break;
			case GlobalVariables.ArmorRating.Armor_Rifle:
			case GlobalVariables.ArmorRating.Armor_HMG:
				num = 90;
				break;
			case GlobalVariables.ArmorRating.RHA_25mm:
				num = 70;
				break;
			case GlobalVariables.ArmorRating.RHA_20mm:
				num = 80;
				break;
			default:
				num = 0;
				break;
			case GlobalVariables.ArmorRating.Light:
				num = 50;
				break;
			case GlobalVariables.ArmorRating.RHA_35mm:
				num = 55;
				break;
			case GlobalVariables.ArmorRating.RHA_30mm:
				num = 60;
				break;
			}
			break;
		case Warhead.WarheadType.Laser_COIL:
		case Warhead.WarheadType.Laser_CarbonDioxide:
		case Warhead.WarheadType.Laser_DeuteriumFluoride:
		case Warhead.WarheadType.Laser_SolidStateFiber:
			switch (armorRating_0)
			{
			case GlobalVariables.ArmorRating.Armor_Handgun:
				num = 80;
				break;
			case GlobalVariables.ArmorRating.None:
				num = 100;
				break;
			case GlobalVariables.ArmorRating.Armor_HMG:
				num = 50;
				break;
			case GlobalVariables.ArmorRating.Armor_Rifle:
				num = 60;
				break;
			case GlobalVariables.ArmorRating.RHA_25mm:
				num = 30;
				break;
			case GlobalVariables.ArmorRating.RHA_20mm:
				num = 40;
				break;
			default:
				return 0f;
			case GlobalVariables.ArmorRating.RHA_35mm:
				num = 10;
				break;
			case GlobalVariables.ArmorRating.RHA_30mm:
				num = 20;
				break;
			}
			break;
		case Warhead.WarheadType.ArmorPiercing:
		case Warhead.WarheadType.SemiAP:
		case Warhead.WarheadType.HardTargetPenetrator:
		case Warhead.WarheadType.LongRodPenetrator:
			switch (warhead.ExplosivesType)
			{
			case Warhead.WarheadExplosivesType.KineticEnergy:
				switch (armorRating_0)
				{
				case GlobalVariables.ArmorRating.Armor_Handgun:
					num = 90;
					break;
				case GlobalVariables.ArmorRating.None:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.Armor_HMG:
					num = 70;
					break;
				case GlobalVariables.ArmorRating.Armor_Rifle:
					num = 80;
					break;
				case GlobalVariables.ArmorRating.RHA_25mm:
					num = 50;
					break;
				case GlobalVariables.ArmorRating.RHA_20mm:
					num = 60;
					break;
				case GlobalVariables.ArmorRating.Light:
					num = 20;
					break;
				case GlobalVariables.ArmorRating.Medium:
					return 0f;
				case GlobalVariables.ArmorRating.Heavy:
					return 0f;
				case GlobalVariables.ArmorRating.Special:
					return 0f;
				case GlobalVariables.ArmorRating.RHA_35mm:
					num = 30;
					break;
				case GlobalVariables.ArmorRating.RHA_30mm:
					num = 40;
					break;
				}
				break;
			default:
				switch (armorRating_0)
				{
				default:
					return 100f;
				case GlobalVariables.ArmorRating.Special:
					num = 50;
					break;
				case GlobalVariables.ArmorRating.Heavy:
					num = 80;
					break;
				}
				break;
			case Warhead.WarheadExplosivesType.LongRodPenetrator_LightArmor:
				switch (armorRating_0)
				{
				case GlobalVariables.ArmorRating.Armor_Handgun:
					num = 85;
					break;
				case GlobalVariables.ArmorRating.None:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.Armor_HMG:
					num = 75;
					break;
				case GlobalVariables.ArmorRating.Armor_Rifle:
					num = 80;
					break;
				case GlobalVariables.ArmorRating.RHA_25mm:
					num = 65;
					break;
				case GlobalVariables.ArmorRating.RHA_20mm:
					num = 70;
					break;
				case GlobalVariables.ArmorRating.Light:
					num = 50;
					break;
				case GlobalVariables.ArmorRating.Medium:
					num = 20;
					break;
				case GlobalVariables.ArmorRating.Heavy:
					return 0f;
				case GlobalVariables.ArmorRating.Special:
					return 0f;
				case GlobalVariables.ArmorRating.RHA_35mm:
					num = 55;
					break;
				case GlobalVariables.ArmorRating.RHA_30mm:
					num = 60;
					break;
				}
				break;
			case Warhead.WarheadExplosivesType.LongRodPenetrator_MediumArmor:
				switch (armorRating_0)
				{
				case GlobalVariables.ArmorRating.Armor_Handgun:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.None:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.Armor_HMG:
					num = 95;
					break;
				case GlobalVariables.ArmorRating.Armor_Rifle:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.RHA_25mm:
					num = 85;
					break;
				case GlobalVariables.ArmorRating.RHA_20mm:
					num = 90;
					break;
				case GlobalVariables.ArmorRating.Light:
					num = 70;
					break;
				case GlobalVariables.ArmorRating.Medium:
					num = 50;
					break;
				case GlobalVariables.ArmorRating.Heavy:
					num = 20;
					break;
				case GlobalVariables.ArmorRating.Special:
					return 0f;
				case GlobalVariables.ArmorRating.RHA_35mm:
					num = 75;
					break;
				case GlobalVariables.ArmorRating.RHA_30mm:
					num = 80;
					break;
				}
				break;
			case Warhead.WarheadExplosivesType.LongRodPenetrator_HeavyArmor:
				switch (armorRating_0)
				{
				case GlobalVariables.ArmorRating.Armor_Handgun:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.None:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.Armor_HMG:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.Armor_Rifle:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.RHA_25mm:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.RHA_20mm:
					num = 100;
					break;
				case GlobalVariables.ArmorRating.Light:
					num = 85;
					break;
				case GlobalVariables.ArmorRating.Medium:
					num = 80;
					break;
				case GlobalVariables.ArmorRating.Heavy:
					num = 50;
					break;
				case GlobalVariables.ArmorRating.Special:
					num = 20;
					break;
				case GlobalVariables.ArmorRating.RHA_35mm:
					num = 90;
					break;
				case GlobalVariables.ArmorRating.RHA_30mm:
					num = 95;
					break;
				}
				break;
			case Warhead.WarheadExplosivesType.LongRodPenetrator_SpecialArmor:
				switch (armorRating_0)
				{
				default:
					return 100f;
				case GlobalVariables.ArmorRating.Special:
					num = 50;
					break;
				case GlobalVariables.ArmorRating.Heavy:
					num = 80;
					break;
				}
				break;
			}
			break;
		case Warhead.WarheadType.HE_BlastFrag:
		case Warhead.WarheadType.Torpedo:
		case Warhead.WarheadType.DepthCharge:
		case Warhead.WarheadType.Cluster_SmartSubs:
		{
			if (1 == 0)
			{
			}
			short num3 = armorRating_0 switch
			{
				GlobalVariables.ArmorRating.Light => 90, 
				GlobalVariables.ArmorRating.Medium => 40, 
				GlobalVariables.ArmorRating.Heavy => 20, 
				GlobalVariables.ArmorRating.Special => 5, 
				_ => 100, 
			};
			if (1 == 0)
			{
			}
			num = num3;
			break;
		}
		}
		int num2 = GameGeneral.LockRandom_0.Next(num - 15, num + 16);
		if (num2 <= 100)
		{
			if (num2 < 0)
			{
				return 0f;
			}
			return num2;
		}
		return 100f;
	}

	[SpecialName]
	public bool GetNeedsVisualLOSBeforeLaunch(bool bool_0)
	{
		WeaponGuidanceType guidance = Guidance;
		if ((int)guidance > 1 && (int)(guidance - 4) > 1 && guidance != WeaponGuidanceType.BeamRiding)
		{
			return false;
		}
		if (base.Sensors_Cached.Length == 0)
		{
			return false;
		}
		Sensor.Sensor_Type type = base.Sensors_Cached[0].Type;
		if ((uint)(type - 2003) > 1u && type != Sensor.Sensor_Type.LaserSpotTracker)
		{
			return false;
		}
		if (bool_0 && (Flags.Navigation_INS || Flags.Navigation_INS_GPS || Flags.Navigation_TERCOM))
		{
			return false;
		}
		return true;
	}

	[SpecialName]
	public override Side GetUnitSide(bool bool_0 = false)
	{
		return base.GetUnitSide(bool_0);
	}

	[SpecialName]
	public override void SetUnitSide(bool bool_0, Side side_0)
	{
		base.SetUnitSide(bool_0, side_0);
	}

	[SpecialName]
	public float GetMaxDownRange(float float_0, float float_1, Contact_Base.ContactType contactType_0)
	{
		try
		{
			float num = float_0 - float_1;
			bool num2 = MinLaunchAlt_ASL != 0f && float_0 < MinLaunchAlt_ASL;
			bool flag = MaxLaunchAlt_ASL != 0f && float_0 > MaxLaunchAlt_ASL;
			bool flag2 = MinLaunchAlt_AGL != 0f && float_1 < MinLaunchAlt_AGL;
			bool flag3 = MaxLaunchAlt_AGL != 0f && float_1 > MaxLaunchAlt_AGL;
			float num3 = MinLaunchAlt_AGL;
			if (num3 == 0f && MinLaunchAlt_ASL != 0f)
			{
				num3 = MinLaunchAlt_ASL - num;
			}
			float num4 = MaxLaunchAlt_AGL;
			if (num4 == 0f && MaxLaunchAlt_ASL != 0f)
			{
				num4 = MaxLaunchAlt_ASL - num;
			}
			if (Type == _WeaponType.Gun)
			{
				num4 = (float)((double)GetRangeMaxToTargetType(contactType_0) * 1852.0 / 2.0) - num;
				flag = float_1 > num4;
			}
			if (num2 || flag2)
			{
				return -1f;
			}
			if (flag || flag3)
			{
				return GetRangeMaxToTargetType(contactType_0);
			}
			if (num4 == 0f && num3 == 0f)
			{
				return GetRangeMaxToTargetType(contactType_0);
			}
			float num5 = (float_1 - num3) / (num4 - num3);
			float num6 = ((Type == _WeaponType.Gun) ? 0.05f : 0.5f);
			float num7 = 1f;
			float num8 = num6 + (num7 - num6) * num5;
			return Math.Max(GetRangeMaxToTargetType(contactType_0), GetRangeMaxToTargetType(Contact_Base.ContactType.Submarine)) * num8;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100884", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public bool GuidanceHasSemiActivePhase()
	{
		switch (Guidance)
		{
		default:
			return false;
		case WeaponGuidanceType.SemiActive:
		case WeaponGuidanceType.Inertial_Plus_SemiActive:
		case WeaponGuidanceType.Datalink_Plus_SemiActive:
		case WeaponGuidanceType.CommandGuided_Datalinked:
		case WeaponGuidanceType.BeamRiding:
		case WeaponGuidanceType.SemiActive_Plus_Active:
		case WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
			return true;
		}
	}

	public bool GuidanceHasDataLink()
	{
		switch (Guidance)
		{
		default:
			return false;
		case WeaponGuidanceType.Datalink_Plus_SemiActive:
		case WeaponGuidanceType.DataLink_Plus_Passive:
		case WeaponGuidanceType.Datalink_Plus_Active:
		case WeaponGuidanceType.CommandGuided_Datalinked:
			return true;
		}
	}

	[SpecialName]
	public float GetMaxRangeForThisTarget(ActiveUnit activeUnit_0, Contact contact_0, bool bool_0, Doctrine doctrine_0, bool bool_1)
	{
		try
		{
			float num = 0f;
			if (IsPalletWeapon)
			{
				InitializeWeaponWeaponsPallet();
				foreach (WeaponRec weaponWeapon in WeaponWeapons)
				{
					float num2 = 0f;
					num2 = weaponWeapon.GetReferenceWeapon(activeUnit_0.ParentScen).GetMaxRangeForThisTarget(activeUnit_0, contact_0, bool_0, doctrine_0, bool_1);
					if (num2 > num)
					{
						num = num2;
					}
				}
				return num;
			}
			if (!bool_1 && doctrine_0 != null && activeUnit_0 != null && Type == _WeaponType.Gun && contact_0.IsSurfaceContact && activeUnit_0.IsAircraft)
			{
				byte? b = (byte?)doctrine_0.GetGunStrafing(ParentScen, bool_0: false, bool_1: false, bool_2: false);
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					return 0f;
				}
			}
			if (contact_0.ActualUnit == null)
			{
				if (IsAAW)
				{
					return GetRangeMaxToTargetType(Contact_Base.ContactType.Air);
				}
				if (IsShip)
				{
					return GetRangeMaxToTargetType(Contact_Base.ContactType.Surface);
				}
				if (IsFacility)
				{
					return GetRangeMaxToTargetType(Contact_Base.ContactType.Facility_Fixed);
				}
				if (IsSubmarine)
				{
					return GetRangeMaxToTargetType(Contact_Base.ContactType.Submarine);
				}
				return MaxRange_NoTargetType;
			}
			ActiveUnit actualUnit = contact_0.ActualUnit;
			float num3 = ((actualUnit == null) ? GetRangeMaxToTargetType(contact_0.Type) : ((actualUnit.IsSubmarine && ((Submarine)actualUnit).IsSurfaced) ? ((GetRangeMaxToTargetType(Contact_Base.ContactType.Submarine) == 0f) ? GetRangeMaxToTargetType(Contact_Base.ContactType.Surface) : GetRangeMaxToTargetType(Contact_Base.ContactType.Submarine)) : ((actualUnit.IsFacility && ((Facility)actualUnit).Category == Facility._FacilityCategory.Water_Surface) ? Math.Max(GetRangeMaxToTargetType(Contact_Base.ContactType.Facility_Fixed), GetRangeMaxToTargetType(Contact_Base.ContactType.Surface)) : ((!actualUnit.IsAircraft || !((Aircraft)actualUnit).IsAerostat) ? GetRangeMaxToTargetType(contact_0.Type) : Math.Max(GetRangeMaxToTargetType(Contact_Base.ContactType.Air), GetRangeMaxToTargetType(Contact_Base.ContactType.Surface))))));
			if (bool_0 && num3 > 0f && !Information.IsNothing(doctrine_0))
			{
				Weapon weapon_ = this;
				if (doctrine_0.InsertRepository(ref weapon_))
				{
					weapon_ = this;
					bool? nullable_ = null;
					Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_ = Doctrine.WRA_DetermineTargetType(ref contact_0, this, ref nullable_);
					Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_ = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref weapon_, ref contact_0, ref _WRA_WeaponTargetType_, activeUnit_0.GetUnitSide().ObjectID);
					Scenario parentScen = ParentScen;
					int? nullable_2 = null;
					int? nullable_3 = null;
					nullable_3 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine_0, parentScen, this, wRA_WeaponTargetType_, bool_0: false, ref nullable_2, ref nullable_3);
					if ((nullable_3.HasValue ? new bool?(nullable_3.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						num3 = 0f;
					}
					if (num3 > 0f)
					{
						Scenario parentScen2 = ParentScen;
						int dBID = DBID;
						float? nullable_4 = null;
						float? nullable_5 = null;
						float? num4 = doctrine_0.IncludeRepository(doctrine_0, parentScen2, dBID, wRA_WeaponTargetType_, bool_0: false, ref nullable_4, ref nullable_5);
						if (!Information.IsNothing(num4))
						{
							nullable_5 = num4;
							if ((nullable_5.HasValue ? new bool?(nullable_5.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
							{
								num3 = 0f;
							}
							nullable_5 = num4;
							nullable_4 = nullable_5;
							if ((nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() == -95f) : null).GetValueOrDefault())
							{
								num3 = (float)((double)num3 * 0.25);
							}
							else
							{
								nullable_4 = nullable_5;
								if ((nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() == -96f) : null).GetValueOrDefault())
								{
									num3 = (float)((double)num3 * 0.5);
								}
								else
								{
									nullable_4 = nullable_5;
									if ((nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() == -97f) : null).GetValueOrDefault())
									{
										num3 = (float)((double)num3 * 0.75);
									}
								}
							}
							nullable_4 = num4;
							nullable_ = (nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() > 0f) : null);
							if (nullable_.GetValueOrDefault(true))
							{
								nullable_4 = num4;
								if ((nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() < num3) : null).GetValueOrDefault() && nullable_.HasValue)
								{
									num3 = num4.Value;
								}
							}
						}
					}
				}
			}
			return num3;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200582", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	[SpecialName]
	private float GetRangeMaxToTargetType(Contact_Base.ContactType contactType_0)
	{
		switch (contactType_0)
		{
		case Contact_Base.ContactType.Air:
		case Contact_Base.ContactType.Missile:
		case Contact_Base.ContactType.Orbital:
			return MaxAirRange;
		case Contact_Base.ContactType.Aimpoint:
		case Contact_Base.ContactType.Facility_Fixed:
		case Contact_Base.ContactType.Facility_Mobile:
			return MaxLandRange;
		case Contact_Base.ContactType.Submarine:
		case Contact_Base.ContactType.Torpedo:
			return MaxSubsurfaceRange;
		case Contact_Base.ContactType.Decoy_Air:
			return MaxAirRange;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new NotImplementedException();
		case Contact_Base.ContactType.Surface:
		case Contact_Base.ContactType.UndeterminedNaval:
		case Contact_Base.ContactType.Mine:
		case Contact_Base.ContactType.ActivationPoint:
			return MaxSurfaceRange;
		}
	}

	private bool CompareReponse()
	{
		if (Warheads.Length == 0)
		{
			return false;
		}
		if (Warheads[0].GetIsNuclear(ParentScen))
		{
			return true;
		}
		return false;
	}

	internal bool ReadReponse()
	{
		return MaxAirRange > 15f;
	}

	internal bool DisableReponse()
	{
		if (Type == _WeaponType.GuidedWeapon)
		{
			return MaxAirRange <= 15f;
		}
		return false;
	}

	public static bool IsStandOff(float float_0)
	{
		return new Weapon
		{
			MaxSurfaceRange = float_0,
			MaxLandRange = float_0,
			MaxSubsurfaceRange = float_0
		}.UpdateReponse();
	}

	internal bool UpdateReponse()
	{
		return Math.Max(MaxSurfaceRange, Math.Max(MaxLandRange, MaxSubsurfaceRange)) >= StandOffMaxRange;
	}

	internal bool InsertReponse()
	{
		if (IsGuidedWeapon() && Propulsion.Count == 1)
		{
			return Propulsion[0].Type == Engine.EngineType.WeaponCoast;
		}
		return false;
	}

	internal bool PrepareReponse()
	{
		if (ValidTargets.Submarine)
		{
			if (Type == _WeaponType.GuidedWeapon)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	[SpecialName]
	public override double GetLongitude(bool? nullable_0 = null)
	{
		return _Longitude;
	}

	[SpecialName]
	public override void SetLongitude(bool? nullable_0, double double_0)
	{
		_Longitude = double_0;
	}

	[SpecialName]
	public override double GetLatitude(bool? nullable_0 = null)
	{
		return _Latitude;
	}

	[SpecialName]
	public override void SetLatitude(bool? nullable_0, double double_0)
	{
		_Latitude = double_0;
	}

	public override bool IsOperating()
	{
		return !base.IsDestroyed;
	}

	[SpecialName]
	public int GetOptimumBurstHeight_AGL(ActiveUnit activeUnit_0)
	{
		if (Warheads.Length == 0)
		{
			return 0;
		}
		if (Warheads[0].GetIsAirburst(this, activeUnit_0))
		{
			if (activeUnit_0 != null)
			{
				if (IsNuke.Value)
				{
					if (activeUnit_0.IsSubmarine)
					{
						if (((Submarine)activeUnit_0).IsSurfaced)
						{
							return 220;
						}
						return -100;
					}
					if (activeUnit_0.IsAircraft || activeUnit_0.IsMissile || activeUnit_0.IsSatellite)
					{
						return (int)Math.Round(activeUnit_0.CurrentAltitude_AGL);
					}
				}
				if (Warheads[0].GetIsAirburst(this, activeUnit_0))
				{
					switch (Warheads[0].Type)
					{
					case Warhead.WarheadType.Nuclear:
						return (int)Math.Round(Math.Pow(Warheads[0].DP / 1000000f, 1.0 / 3.0) * 220.0);
					case Warhead.WarheadType.FAE:
						return 1;
					case Warhead.WarheadType.Fragmentation:
					case Warhead.WarheadType.ContinuousRod:
					case Warhead.WarheadType.SuperFrag:
					case Warhead.WarheadType.Fragmentation_ABM:
						return (int)Math.Round((double)(Explosion.GetCutoffRange_Frag_nm(Warheads[0].DP, DetonationMedium.Air) * 1852f) * 0.5);
					case Warhead.WarheadType.HE_BlastFrag:
						return (int)Math.Round((double)(Explosion.GetCutoffRange_Blast_nm(Warheads[0].DP, DetonationMedium.Air) * 1852f) * 0.5);
					default:
						return 0;
					case Warhead.WarheadType.EMP_Omni:
						return (int)Math.Round(3055.8);
					case Warhead.WarheadType.Cluster_AP:
					case Warhead.WarheadType.Cluster_AT:
					case Warhead.WarheadType.Cluster_Penetrator:
					case Warhead.WarheadType.Cluster_SmartSubs:
						return 800;
					}
				}
				return 0;
			}
			return 0;
		}
		return 0;
	}

	[SpecialName]
	public DetonationMedium GetDetonationTransmissionMedium(Module_Unit.Unit unit_0)
	{
		if (CurrentAltitude_AGL < 0f && unit_0.CurrentAltitude_AGL < 0f && Module_Unit.ResetTokenizer(this) && Module_Unit.ResetTokenizer(unit_0))
		{
			return DetonationMedium.Underground;
		}
		if (GetCurrentAltitude() <= 0f && !Module_Unit.ResetTokenizer(this) && unit_0.GetCurrentAltitude() <= 0f && !Module_Unit.ResetTokenizer(unit_0))
		{
			return DetonationMedium.Underwater;
		}
		if (GetCurrentAltitude() <= 100000f && unit_0.GetCurrentAltitude() <= 100000f)
		{
			return DetonationMedium.Air;
		}
		return DetonationMedium.Space;
	}

	public void DeployLoiterParachute()
	{
		ThrottleSetting = Throttle.FullStop;
		CurrentSpeed = 97.192f;
		Attitude_Pitch = -85f;
		DesiredPitch = -85f;
		DesiredSpeed = CurrentSpeed;
	}

	public void ReleaseFromLoiterParachute()
	{
		ThrottleSetting = Throttle.Cruise;
		CurrentSpeed = Kinematics.InitDescriptor(GetCurrentAltitude());
	}

	public static void RecalculateWeaponFlightEnergyIfNecessary(Weapon weapon_0, Scenario scenario_0, bool bool_0, Action<string> action_0 = null)
	{
		if (weapon_0.UsesBoostCoastModel.Value)
		{
			if (scenario_0.Cache_BurnTimesForBoostCoastWeapons.ContainsKey(weapon_0.DBID))
			{
				(int, int) tuple = scenario_0.Cache_BurnTimesForBoostCoastWeapons[weapon_0.DBID];
				weapon_0.TotalBurnTime = tuple.Item1;
				weapon_0.FlightEndurance = tuple.Item2;
			}
			else
			{
				(int, int) value = DBValidation.CountRepository(weapon_0.DBID, scenario_0, bool_0);
				scenario_0.Cache_BurnTimesForBoostCoastWeapons.TryAdd(weapon_0.DBID, value);
				weapon_0.TotalBurnTime = value.Item1;
				weapon_0.FlightEndurance = value.Item2;
			}
		}
		else if (weapon_0.SupportsAttitude_Pitch && weapon_0.Type == _WeaponType.GuidedWeapon && (!weapon_0.IsBallisticMissile || !weapon_0.HasRVs.Value) && !scenario_0.FeatureCompatibility.GetGuidedWeaponsPitchAttitude(scenario_0.DBConnection))
		{
			int num;
			if (scenario_0.Cache_FuelForPitchEnabledWeapons.ContainsKey(weapon_0.DBID))
			{
				num = scenario_0.Cache_FuelForPitchEnabledWeapons[weapon_0.DBID];
			}
			else
			{
				num = DBValidation.ManageImporter(weapon_0.DBID, scenario_0, bool_0);
				scenario_0.Cache_FuelForPitchEnabledWeapons.TryAdd(weapon_0.DBID, num);
			}
			if ((float)num > weapon_0.Fuel_ReadOnly[0].CurrentQuantity)
			{
				weapon_0.Fuel_ReadOnly[0].CurrentQuantity = num;
				weapon_0.Fuel_ReadOnly[0].MaxQuantity = num;
			}
		}
	}

	public static Weapon GetNewWeapon(ref Scenario scenario_0, int int_0, bool bool_0, string string_0 = null)
	{
		try
		{
			if (int_0 != 0 && int_0 != -1)
			{
				_WeaponType weaponType = DBFunctions.GetWeaponType(int_0, scenario_0);
				if (1 == 0)
				{
				}
				Weapon weapon2 = weaponType switch
				{
					_WeaponType.GuidedProjectile => new GuidedProjectile(ref scenario_0, int_0), 
					_WeaponType.Rocket => new UnguidedRocket(ref scenario_0, int_0), 
					_WeaponType.HGV => new HGV(ref scenario_0, int_0), 
					_WeaponType.BallisticMissile => new BallisticMissile(ref scenario_0, int_0), 
					_WeaponType.Torpedo => new Torpedo(ref scenario_0, int_0), 
					_ => new Weapon(ref scenario_0, int_0), 
				};
				if (1 == 0)
				{
				}
				Weapon weapon = weapon2;
				weapon.ParentScen = scenario_0;
				weapon.IsWeapon = true;
				weapon._FacadeReader = bool_0;
				DBFunctions.GetWeapon(scenario_0.DBConnection, weapon, int_0, scenario_0);
				if (weapon.IsHGV && weapon.CruiseAltitude_ASL > 100000f)
				{
					weapon.CruiseAltitude_ASL = 100000f;
				}
				if (weapon.Type == _WeaponType.RV)
				{
					weapon.MinSurfaceRange = 1f;
				}
				if (weapon.Type == _WeaponType.Sonobuoy && weapon._Sensors.Length != 0 && weapon._Sensors[0].HasActiveModeOnly)
				{
					weapon._Sensors[0].GoActive();
				}
				if (weapon.IsBallisticMissile && weapon.IsNuke.Value)
				{
					weapon.ValidSpecialModes.Add(WeaponSpecialMode.HighAltitudeDetonation);
				}
				if (string.IsNullOrEmpty(string_0))
				{
					weapon.ObjectID_Set(IDGenerator.Instance.Next.ToLower());
				}
				else
				{
					weapon.ObjectID_Set(string_0);
				}
				return weapon;
			}
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			exception_?.Data.Add("Error at 100902", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public Weapon(ref Scenario scenario_0)
		: base(ref scenario_0)
	{
		Warheads = new Warhead[0];
		Directors = new List<int>();
		Flags = default(WeaponFlags);
		WeaponWeapons = new ObservableList<WeaponRec>();
		ValidSpecialModes = new List<WeaponSpecialMode>();
		_FacadeReader = false;
		IsMIRVedMissile = new Lazy<bool>(RestartReponse);
		IsMRVedMissile = new Lazy<bool>(TestReponse);
		UsesBoostCoastModel = new Lazy<bool>(FillReponse);
		IsNuke = new Lazy<bool>(CompareReponse);
		ActiveUnit activeUnit_ = this;
		_Navigator = new Weapon_Navigator(ref activeUnit_);
		m_ReaderReader = new Weapon_AI(this);
		_InvocationReader = false;
		HasRVs = new Lazy<bool>(RevertReponse);
		IsWeapon = true;
		EvaluateIfDumb();
	}

	public Weapon(ref Scenario scenario_0, int int_0, string string_0 = null)
		: base(ref scenario_0)
	{
		Warheads = new Warhead[0];
		Directors = new List<int>();
		Flags = default(WeaponFlags);
		WeaponWeapons = new ObservableList<WeaponRec>();
		ValidSpecialModes = new List<WeaponSpecialMode>();
		_FacadeReader = false;
		IsMIRVedMissile = new Lazy<bool>(RestartReponse);
		IsMRVedMissile = new Lazy<bool>(TestReponse);
		UsesBoostCoastModel = new Lazy<bool>(FillReponse);
		IsNuke = new Lazy<bool>(CompareReponse);
		ActiveUnit activeUnit_ = this;
		_Navigator = new Weapon_Navigator(ref activeUnit_);
		m_ReaderReader = new Weapon_AI(this);
		_InvocationReader = false;
		HasRVs = new Lazy<bool>(RevertReponse);
		IsWeapon = true;
		EvaluateIfDumb();
	}

	public static bool WeaponIsNonRivalrous(int int_0, ref Scenario scenario_0)
	{
		if (!WeaponIsFuelTank(int_0, ref scenario_0) && !WeaponIsSonobuoy(int_0, ref scenario_0) && !WeaponIsGunPodAmmo(int_0, ref scenario_0))
		{
			return WeaponIsCargo(int_0, ref scenario_0);
		}
		return true;
	}

	public static bool WeaponIsFuelTank(int int_0, ref Scenario scenario_0)
	{
		SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
		_WeaponType weaponType = DBFunctions.GetWeaponType(int_0, ref sqliteConnection_);
		if (weaponType == _WeaponType.DropTank)
		{
			return true;
		}
		return weaponType == _WeaponType.FerryTank;
	}

	public static bool WeaponIsCargo(int int_0, ref Scenario scenario_0)
	{
		SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
		_WeaponType weaponType = DBFunctions.GetWeaponType(int_0, ref sqliteConnection_);
		if (weaponType != _WeaponType.Cargo && weaponType != _WeaponType.Paratroops)
		{
			return weaponType == _WeaponType.Troops;
		}
		return true;
	}

	public static bool WeaponIsSonobuoy(int int_0, ref Scenario scenario_0)
	{
		SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
		return DBFunctions.GetWeaponType(int_0, ref sqliteConnection_) == _WeaponType.Sonobuoy;
	}

	public static bool WeaponIsGunPodAmmo(int int_0, ref Scenario scenario_0)
	{
		SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
		return DBFunctions.GetWeaponType(int_0, ref sqliteConnection_) == _WeaponType.Gun;
	}

	private int ReflectReponse(Side side_0, Contact contact_0, int int_0)
	{
		try
		{
			if (side_0 == null)
			{
				return 0;
			}
			return (from theAU in Misc.ChangeRequest(side_0.Units)
				select (theAU) into theAU
				where theAU.IsWeapon
				select theAU into theW
				select (theW) into theW
				where theW.AI.PrimaryTarget == contact_0 && ((Weapon)theW).ARM_SpecifiedEMission.Key == int_0
				select theW).Count();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100903", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	public bool ARM_DetermineEmissionToTrack(ObservableDictionary<int, EmissionContainer> observableDictionary_0, Side side_0, Contact contact_0, bool bool_0, ref LockRandom lockRandom_0)
	{
		int count = observableDictionary_0.Count;
		try
		{
			float num = (bool_0 ? 36000f : 20f);
			List<int> list = new List<int>();
			int num4 = count - 1;
			for (int i = 0; i <= num4; i++)
			{
				int num5;
				EmissionContainer emissionContainer;
				try
				{
					num5 = observableDictionary_0.Keys.ElementAtOrDefault(i);
					emissionContainer = observableDictionary_0[num5];
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
					continue;
				}
				if (!((emissionContainer.Age <= num) | (contact_0.ActualUnit != null && side_0 != null && contact_0.ActualUnit.GetIsAutoDetectable(side_0))))
				{
					continue;
				}
				if (!emissionContainer.IsIllumination)
				{
					SQLiteConnection sqliteConnection_ = ParentScen.DBConnection;
					if (!DBFunctions.GetSensor(num5, ref sqliteConnection_).IsPureIlluminator)
					{
						continue;
					}
				}
				list.Add(num5);
			}
			if (list.Count > 0)
			{
				foreach (int item in list)
				{
					if (ReflectReponse(side_0, contact_0, item) == 0)
					{
						ARM_SpecifiedEMission = new KeyValuePair<int, EmissionContainer>(item, observableDictionary_0[item]);
						return true;
					}
				}
			}
			List<int> list2 = new List<int>();
			int num6 = count - 1;
			for (int j = 0; j <= num6; j++)
			{
				int num7;
				EmissionContainer emissionContainer2;
				try
				{
					num7 = observableDictionary_0.Keys.ElementAtOrDefault(j);
					emissionContainer2 = observableDictionary_0[num7];
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
					continue;
				}
				if ((emissionContainer2.Age <= num) | (contact_0.ActualUnit != null && side_0 != null && contact_0.ActualUnit.GetIsAutoDetectable(side_0)))
				{
					SQLiteConnection sqliteConnection_2 = ParentScen.DBConnection;
					if (DBFunctions.GetSensor(num7, ref sqliteConnection_2).IsGroundBasedFireControlRadar)
					{
						list2.Add(num7);
					}
				}
			}
			if (list2.Count > 0)
			{
				foreach (int item2 in list2)
				{
					if (ReflectReponse(side_0, contact_0, item2) == 0)
					{
						ARM_SpecifiedEMission = new KeyValuePair<int, EmissionContainer>(item2, observableDictionary_0[item2]);
						return true;
					}
				}
			}
			List<int> list3 = new List<int>();
			int num8 = count - 1;
			for (int k = 0; k <= num8; k++)
			{
				int num9;
				EmissionContainer emissionContainer3;
				try
				{
					num9 = observableDictionary_0.Keys.ElementAtOrDefault(k);
					emissionContainer3 = observableDictionary_0[num9];
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					ProjectData.ClearProjectError();
					continue;
				}
				if ((emissionContainer3.Age <= num) | (contact_0.ActualUnit != null && side_0 != null && contact_0.ActualUnit.GetIsAutoDetectable(side_0)))
				{
					SQLiteConnection sqliteConnection_3 = ParentScen.DBConnection;
					if (DBFunctions.GetSensor(num9, ref sqliteConnection_3).IsGroundBasedAirSearchRadar)
					{
						list3.Add(num9);
					}
				}
			}
			if (list3.Count > 0)
			{
				foreach (int item3 in list3)
				{
					if (ReflectReponse(side_0, contact_0, item3) == 0)
					{
						ARM_SpecifiedEMission = new KeyValuePair<int, EmissionContainer>(item3, observableDictionary_0[item3]);
						return true;
					}
				}
			}
			if (Flags.HomeOnJam)
			{
				List<int> list4 = new List<int>();
				int num10 = count - 1;
				for (int l = 0; l <= num10; l++)
				{
					int num11;
					EmissionContainer emissionContainer4;
					try
					{
						num11 = observableDictionary_0.Keys.ElementAtOrDefault(l);
						emissionContainer4 = observableDictionary_0[num11];
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						ProjectData.ClearProjectError();
						continue;
					}
					if ((emissionContainer4.Age <= num) | (contact_0.ActualUnit != null && side_0 != null && contact_0.ActualUnit.GetIsAutoDetectable(side_0)))
					{
						SQLiteConnection sqliteConnection_4 = ParentScen.DBConnection;
						if (DBFunctions.GetSensor(num11, ref sqliteConnection_4).IsGroundBasedOECM)
						{
							list4.Add(num11);
						}
					}
				}
				if (list4.Count > 0)
				{
					foreach (int item4 in list4)
					{
						if (ReflectReponse(side_0, contact_0, item4) == 0)
						{
							ARM_SpecifiedEMission = new KeyValuePair<int, EmissionContainer>(item4, observableDictionary_0[item4]);
							return true;
						}
					}
				}
			}
			List<int> list5 = new List<int>();
			int num2 = count - 1;
			for (int m = 0; m <= num2; m++)
			{
				int num3;
				EmissionContainer emissionContainer5;
				try
				{
					num3 = observableDictionary_0.Keys.ElementAtOrDefault(m);
					emissionContainer5 = observableDictionary_0[num3];
				}
				catch (Exception projectError5)
				{
					ProjectData.SetProjectError(projectError5);
					ProjectData.ClearProjectError();
					continue;
				}
				if (!((emissionContainer5.Age <= num) | (contact_0.ActualUnit != null && side_0 != null && contact_0.ActualUnit.GetIsAutoDetectable(side_0))))
				{
					continue;
				}
				if (observableDictionary_0[num3].IsIllumination)
				{
					list5.Add(num3);
					continue;
				}
				SQLiteConnection sqliteConnection_5 = ParentScen.DBConnection;
				Sensor sensor = DBFunctions.GetSensor(num3, ref sqliteConnection_5);
				if (!sensor.IsGroundBasedAirSearchRadar && !sensor.IsGroundBasedFireControlRadar && !sensor.IsPureIlluminator)
				{
					if (Flags.HomeOnJam && sensor.IsGroundBasedOECM)
					{
						list5.Add(num3);
					}
					else if (sensor.Capabilities.SurfaceSearch || sensor.Capabilities.MissileApproachWarning || sensor.Capabilities.SpaceSearch_ABM)
					{
						list5.Add(num3);
					}
				}
				else
				{
					list5.Add(num3);
				}
			}
			if (list5.Count <= 0)
			{
				return false;
			}
			IEnumerable<int> source = list5.OrderBy((int theCandidateKey) => ReflectReponse(side_0, contact_0, theCandidateKey));
			ARM_SpecifiedEMission = new KeyValuePair<int, EmissionContainer>(source.ElementAtOrDefault(0), observableDictionary_0[source.ElementAtOrDefault(0)]);
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100904", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public override void DoTypeSpecificActions(float float_0, ref LockRandom lockRandom_0)
	{
		if (Weaponry == null)
		{
			return;
		}
		try
		{
			if (Type == _WeaponType.Sonobuoy || base.IsDestroyed || IsBeingDestroyed)
			{
				return;
			}
			switch (Guidance)
			{
			case WeaponGuidanceType.SemiActive:
				try
				{
					DefineReponse(float_0);
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception exception_7 = ex7;
					exception_7?.Data.Add("Error at 100908", "");
					GameGeneral.WriteExceptionsToLog(ref exception_7);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.Inertial_Plus_SemiActive:
				try
				{
					PublishReponse(float_0);
				}
				catch (Exception ex6)
				{
					ProjectData.SetProjectError(ex6);
					Exception exception_6 = ex6;
					exception_6?.Data.Add("Error at 100922", "");
					GameGeneral.WriteExceptionsToLog(ref exception_6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.Datalink_Plus_SemiActive:
				try
				{
					WeaponLogic_DatalinkedWeapons(float_0);
					AwakeReponse(float_0);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception exception_5 = ex5;
					exception_5?.Data.Add("Error at 100917", "");
					GameGeneral.WriteExceptionsToLog(ref exception_5);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.Passive:
				try
				{
					if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon() && GuidanceLogic_Overshoot(60f, bool_0: true, bool_1: false, bool_2: true, float_0))
					{
						return;
					}
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception exception_4 = ex4;
					exception_4?.Data.Add("Error at 100914", "");
					GameGeneral.WriteExceptionsToLog(ref exception_4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.Inertial_Plus_Passive:
				try
				{
					if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon())
					{
						if (GuidanceLogic_Overshoot(60f, bool_0: true, bool_1: false, bool_2: false, float_0))
						{
							return;
						}
						HandleReachingActivationPoint();
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception exception_3 = ex3;
					exception_3?.Data.Add("Error at 100921", "");
					GameGeneral.WriteExceptionsToLog(ref exception_3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.DataLink_Plus_Passive:
				try
				{
					WeaponLogic_DatalinkedWeapons(float_0);
					HandleReachingActivationPoint();
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at 100916", "");
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.Active:
				try
				{
					if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon() && GuidanceLogic_Overshoot(60f, bool_0: true, bool_1: false, bool_2: true, float_0))
					{
						return;
					}
					if (Navigator.HasNonPathfindPlottedCourse())
					{
						HandleReachingActivationPoint();
						break;
					}
					Sensor[] array = _Sensors;
					Sensor[] array4 = array;
					foreach (Sensor sensor2 in array4)
					{
						if (sensor2.CanBeActive && !sensor2.IsActive)
						{
							sensor2.GoActive();
						}
					}
				}
				catch (Exception ex18)
				{
					ProjectData.SetProjectError(ex18);
					Exception exception_18 = ex18;
					exception_18?.Data.Add("Error at 100913", "");
					GameGeneral.WriteExceptionsToLog(ref exception_18);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.Datalink_Plus_Active:
				try
				{
					if (_Sensors.Length != 0 && _Sensors[0].IsActive)
					{
						float float_ = 60f;
						if (AI.PrimaryTarget != null && AI.PrimaryTarget.IsBallisticTarget())
						{
							float_ = StartReponse();
						}
						if (GuidanceLogic_DatalinkParentNotAvailable(float_0) || GuidanceLogic_DestroyedOrVanishedPrimaryTarget_DatalinkedWeapon(float_0) || GuidanceLogic_Overshoot(float_, bool_0: true, bool_1: true, bool_2: true, float_0))
						{
							return;
						}
					}
					else
					{
						WeaponLogic_DatalinkedWeapons(float_0);
					}
					HandleReachingActivationPoint();
				}
				catch (Exception ex17)
				{
					ProjectData.SetProjectError(ex17);
					Exception exception_17 = ex17;
					exception_17?.Data.Add("Error at 100915", "");
					GameGeneral.WriteExceptionsToLog(ref exception_17);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.Inertial_Plus_Active:
				try
				{
					if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon())
					{
						if (GuidanceLogic_Overshoot(60f, bool_0: true, bool_1: false, bool_2: false, float_0))
						{
							return;
						}
						if (_Sensors.Length != 0 && !_Sensors[0].IsActive)
						{
							HandleReachingActivationPoint();
						}
					}
				}
				catch (Exception ex16)
				{
					ProjectData.SetProjectError(ex16);
					Exception exception_16 = ex16;
					exception_16?.Data.Add("Error at 100920", "");
					GameGeneral.WriteExceptionsToLog(ref exception_16);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.CommandGuided_Datalinked:
				try
				{
					WeaponLogic_DatalinkedWeapons(float_0);
				}
				catch (Exception ex15)
				{
					ProjectData.SetProjectError(ex15);
					Exception exception_15 = ex15;
					exception_15?.Data.Add("Error at 100919", "");
					GameGeneral.WriteExceptionsToLog(ref exception_15);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.TVM:
				try
				{
					AssetReponse(float_0);
				}
				catch (Exception ex14)
				{
					ProjectData.SetProjectError(ex14);
					Exception exception_14 = ex14;
					exception_14?.Data.Add("Error at 100918", "");
					GameGeneral.WriteExceptionsToLog(ref exception_14);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.BeamRiding:
				try
				{
					if (!ListReponse(float_0))
					{
						Sensor sensorProvidingFireControlForMe2 = SensorProvidingFireControlForMe;
						if (Information.IsNothing(sensorProvidingFireControlForMe2))
						{
							AI.PrimaryTarget = null;
							AddMessage("武器：" + Name + "不再接收制导信号。", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
							return;
						}
						if (sensorProvidingFireControlForMe2.TargetsTrackedForFireControl_Readonly.Contains(AI.PrimaryTarget))
						{
							if (sensorProvidingFireControlForMe2.IsActive)
							{
								if (myTargetDoesNotExist() && !Information.IsNothing(sensorProvidingFireControlForMe2))
								{
									AttemptRetargeting_Beamrider(float_0);
									return;
								}
								if (myTargetDoesNotExist())
								{
									BlindTime += float_0;
									return;
								}
								BlindTime = 0f;
								AI.PrimaryTarget.Age = 0f;
								break;
							}
							AI.PrimaryTarget = null;
							AddMessage("武器：" + Name + "不再接收制导信号。", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
							return;
						}
						AI.PrimaryTarget = null;
						AddMessage("武器：" + Name + "不再接收制导信号。", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						return;
					}
					return;
				}
				catch (Exception ex13)
				{
					ProjectData.SetProjectError(ex13);
					Exception exception_13 = ex13;
					exception_13?.Data.Add("Error at 100912", "");
					GameGeneral.WriteExceptionsToLog(ref exception_13);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.Inertial:
				ResolveReponse();
				break;
			case WeaponGuidanceType.SemiActive_Plus_Active:
				try
				{
					if (_Sensors.Length != 0 && _Sensors[0].IsActive)
					{
						if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon() && GuidanceLogic_Overshoot(60f, bool_0: true, bool_1: true, bool_2: true, float_0))
						{
							return;
						}
						break;
					}
					if ((double)Module_Unit.RangeToUnit_Slant(this, AI.PrimaryTarget) <= (double)_Sensors[0].maxRange * 0.8)
					{
						StopReponse(bool_0: false, bool_1: true, bool_2: true);
						break;
					}
					if (BlindTime > 5f)
					{
						StopReponse(bool_0: false, bool_1: true, bool_2: true);
						break;
					}
					if (ListReponse(float_0))
					{
						return;
					}
					Sensor sensorProvidingFireControlForMe = SensorProvidingFireControlForMe;
					if (Information.IsNothing(sensorProvidingFireControlForMe))
					{
						if (AttemptBuddyIllumination())
						{
							goto IL_0a69;
						}
						BlindTime += float_0;
					}
					else if (sensorProvidingFireControlForMe.TargetsTrackedForFireControl_Readonly.Contains(AI.PrimaryTarget))
					{
						if (sensorProvidingFireControlForMe.IsActive || AttemptBuddyIllumination())
						{
							goto IL_0a69;
						}
						BlindTime += float_0;
					}
					else
					{
						if (AttemptBuddyIllumination())
						{
							goto IL_0a69;
						}
						BlindTime += float_0;
					}
					goto end_IL_08f9;
					IL_0a69:
					if (BlindTime > 0f)
					{
						BlindTime = 0f;
					}
					if (!RunReponse(90f) && !GuidanceLogic_Overshoot(60f, bool_0: true, bool_1: true, bool_2: true, float_0))
					{
						break;
					}
					return;
					end_IL_08f9:;
				}
				catch (Exception ex12)
				{
					ProjectData.SetProjectError(ex12);
					Exception exception_12 = ex12;
					exception_12?.Data.Add("Error at 100909", "");
					GameGeneral.WriteExceptionsToLog(ref exception_12);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case WeaponGuidanceType.TimesharedSemiActive_Plus_Active:
				try
				{
					if (_Sensors.Length != 0 && _Sensors[0].IsActive)
					{
						if (!GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon() && GuidanceLogic_Overshoot(60f, bool_0: true, bool_1: true, bool_2: true, float_0))
						{
							return;
						}
					}
					else if ((double)Module_Unit.RangeToUnit_Slant(this, AI.PrimaryTarget) <= (double)_Sensors[0].maxRange * 0.8)
					{
						StopReponse(bool_0: false, bool_1: true, bool_2: true);
					}
					else if (BlindTime <= 5f)
					{
						if (ListReponse(float_0))
						{
							return;
						}
						bool flag = false;
						if (!Information.IsNothing(DataLinkParent))
						{
							try
							{
								List<ActiveUnit> list = null;
								LOSCheckResult? nullable_ = null;
								bool? nullable_2 = null;
								bool? nullable_3 = null;
								bool? nullable_4 = null;
								bool? nullable_5 = null;
								bool? nullable_6 = null;
								Sensor[] array2 = DataLinkParent.Sensors_ReadOnly();
								Sensor[] array3 = array2;
								foreach (Sensor sensor in array3)
								{
									if (sensor.IsActive)
									{
										if (sensor.Type == Sensor.Sensor_Type.Radar && Information.IsNothing(list))
										{
											list = DataLinkParent.Sensory.GetJammerUnitsAffectingMe(bool_0: false);
										}
										Lazy<Dictionary<int, EmissionContainer>> lazy_ = new Lazy<Dictionary<int, EmissionContainer>>();
										ActiveUnit dataLinkParent = DataLinkParent;
										ActiveUnit actualUnit = AI.PrimaryTarget.ActualUnit;
										List<Geopoint_Struct> list_ = null;
										if (sensor.CanDetectTarget(Sensor.DetectionAttemptType.SpecificTargetTracking, dataLinkParent, actualUnit, ref list_, Module_Unit.RangeToUnit_Slant(DataLinkParent, AI.PrimaryTarget), ref lazy_, list, ref nullable_2, ref nullable_3, ref nullable_, ref nullable_4, ref nullable_5, ref nullable_6))
										{
											flag = true;
											break;
										}
									}
								}
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError(ex);
								Exception exception_ = ex;
								exception_?.Data.Add("Error at 100910", "");
								GameGeneral.WriteExceptionsToLog(ref exception_);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						if (flag)
						{
							if (BlindTime > 0f)
							{
								BlindTime = 0f;
							}
							if (RunReponse(90f) || GuidanceLogic_Overshoot(60f, bool_0: true, bool_1: true, bool_2: true, float_0))
							{
								return;
							}
						}
						else
						{
							BlindTime += float_0;
						}
					}
					else
					{
						StopReponse(bool_0: false, bool_1: true, bool_2: true);
					}
				}
				catch (Exception ex11)
				{
					ProjectData.SetProjectError(ex11);
					Exception exception_11 = ex11;
					exception_11?.Data.Add("Error at 100911", "");
					GameGeneral.WriteExceptionsToLog(ref exception_11);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				break;
			case (WeaponGuidanceType)3:
				break;
			}
		}
		catch (Exception ex8)
		{
			ProjectData.SetProjectError(ex8);
			Exception exception_8 = ex8;
			exception_8?.Data.Add("Error at 100907", "");
			GameGeneral.WriteExceptionsToLog(ref exception_8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (DatalinkRetargetTime > 0f && !Information.IsNothing(AI.PrimaryTarget))
		{
			DatalinkRetargetTime = 0f;
		}
		if (!Information.IsNothing(ARM_SpecifiedEMission) && !Information.IsNothing(ARM_SpecifiedEMission.Value))
		{
			ARM_SpecifiedEMission.Value.Age = ARM_SpecifiedEMission.Value.Age + float_0;
		}
		short elevation = Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, ParentScen);
		if (GetCurrentAltitude() < (float)elevation && !InstantiateReponse() && !(clientReader | dicReader))
		{
			AddMessage("武器：" + Name + "已经撞入地下", "武器问题", LoggedMessage.MessageType.WeaponEndgame, 0, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
			double latitude = GetLatitude();
			double longitude = GetLongitude();
			float currentAltitude = GetCurrentAltitude();
			LockRandom lockRandom_ = GameGeneral.LockRandom_0;
			Detonate(latitude, longitude, currentAltitude, ref lockRandom_, bool_0: true);
			return;
		}
		try
		{
			if (IsBallisticMissile)
			{
				if (GetCurrentAltitude() >= 100000f && InterruptReponse())
				{
					int num = Warheads.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						Weapon carriedWeapon = Warheads[i].GetCarriedWeapon(ParentScen);
						VisitReponse(this, carriedWeapon, AI.PrimaryTarget, float_0, bool_0: true);
					}
					ParentScen.DestroyThisUnit(this, "All child weapons are away!", "Sub-munitions Expended");
					return;
				}
				if (((BallisticMissile_Kinematics)Kinematics).CountProperty())
				{
					List<Warhead> list2 = new List<Warhead>();
					BallisticMissile ballisticMissile = (BallisticMissile)this;
					bool flag2 = false;
					short? nullable_7 = null;
					if (IsMIRVedMissile.Value)
					{
						if (ParentScen.FifthSecondIsChangingOnThisPulse)
						{
							ReleaseMIRVs(list2, float_0, ref nullable_7);
						}
					}
					else if (IsMRVedMissile.Value)
					{
						int num2 = Warheads.Length - 1;
						Contact contact = null;
						for (int j = 0; j <= num2; j++)
						{
							Warhead warhead = Warheads[j];
							Weapon carriedWeapon2 = warhead.GetCarriedWeapon(ParentScen);
							if (Information.IsNothing(AI.PrimaryTarget))
							{
								if (Navigator.HasPlottedCourse())
								{
									contact = ((carriedWeapon2._Sensors.Count() <= 0) ? ((Contact)new AimpointContact(Navigator.PlottedCourse.Last().Latitude, Navigator.PlottedCourse.Last().Longitude)) : ((Contact)new ActivationPointContact(Navigator.PlottedCourse.Last().Latitude, Navigator.PlottedCourse.Last().Longitude)));
								}
							}
							else if (AI.PrimaryTarget.GetIsDestroyed(ParentScen))
							{
								if (Navigator.HasPlottedCourse())
								{
									contact = ((carriedWeapon2._Sensors.Count() <= 0) ? ((Contact)new AimpointContact(Navigator.PlottedCourse.Last().Latitude, Navigator.PlottedCourse.Last().Longitude)) : ((Contact)new ActivationPointContact(Navigator.PlottedCourse.Last().Latitude, Navigator.PlottedCourse.Last().Longitude)));
								}
							}
							else
							{
								contact = (carriedWeapon2.IsReEntryVehicle ? new AimpointContact(AI.PrimaryTarget.GetLatitude(), AI.PrimaryTarget.GetLongitude()) : AI.PrimaryTarget);
							}
							ActiveUnit_Weaponry weaponry = Weaponry;
							Contact contact_ = contact;
							Sensor sensor_ = null;
							if (weaponry.CanThisWeaponEngageThisTarget(carriedWeapon2, contact_, ref nullable_7, bool_1: false, bool_2: false, bool_3: false, null, ref sensor_).EvaluationEnum == ActiveUnit_Weaponry.WeaponPrefireChecklistEvaluation.OK)
							{
								VisitReponse(this, carriedWeapon2, contact, float_0, j == 0);
								list2.Add(warhead);
							}
						}
					}
					else
					{
						Warhead warhead2 = Warheads[0];
						Weapon carriedWeapon3 = warhead2.GetCarriedWeapon(ParentScen);
						if (carriedWeapon3 != null)
						{
							float maximumAltitude = carriedWeapon3.Kinematics.GetMaximumAltitude();
							if (maximumAltitude == 0f || maximumAltitude > GetCurrentAltitude())
							{
								Contact contact2;
								if (AI.PrimaryTarget == null)
								{
									if (Navigator.HasPlottedCourse())
									{
										contact2 = ((carriedWeapon3._Sensors.Count() <= 0) ? ((Contact)new AimpointContact(Navigator.PlottedCourse.Last().Latitude, Navigator.PlottedCourse.Last().Longitude)) : ((Contact)new ActivationPointContact(Navigator.PlottedCourse.Last().Latitude, Navigator.PlottedCourse.Last().Longitude)));
									}
									else
									{
										contact2 = ballisticMissile.SortReader();
										flag2 = carriedWeapon3._Sensors.Count() > 0;
									}
								}
								else if (AI.PrimaryTarget.GetIsDestroyed(ParentScen))
								{
									if (Navigator.HasPlottedCourse())
									{
										contact2 = ((carriedWeapon3._Sensors.Count() <= 0) ? ((Contact)new AimpointContact(Navigator.PlottedCourse.Last().Latitude, Navigator.PlottedCourse.Last().Longitude)) : ((Contact)new ActivationPointContact(Navigator.PlottedCourse.Last().Latitude, Navigator.PlottedCourse.Last().Longitude)));
									}
									else
									{
										contact2 = ballisticMissile.SortReader();
										flag2 = carriedWeapon3._Sensors.Count() > 0;
									}
								}
								else
								{
									contact2 = ((!carriedWeapon3.IsReEntryVehicle || carriedWeapon3.Sensors_Cached.Length != 0) ? AI.PrimaryTarget : new AimpointContact(AI.PrimaryTarget.GetLatitude(), AI.PrimaryTarget.GetLongitude()));
								}
								ActiveUnit_Weaponry weaponry2 = Weaponry;
								Contact contact_2 = contact2;
								Sensor sensor_2 = null;
								if (weaponry2.CanThisWeaponEngageThisTarget(carriedWeapon3, contact_2, ref nullable_7, bool_1: false, bool_2: false, bool_3: false, null, ref sensor_2).EvaluationEnum == ActiveUnit_Weaponry.WeaponPrefireChecklistEvaluation.OK)
								{
									List<Module_Unit.Unit> list3 = VisitReponse(this, carriedWeapon3, contact2, float_0, bool_0: true);
									if (flag2)
									{
										foreach (Weapon item in list3)
										{
											item.StopReponse(bool_0: true, bool_1: true, bool_2: true);
										}
									}
									list2.Add(warhead2);
								}
							}
						}
					}
					foreach (Warhead item2 in list2)
					{
						ArrayExtensions.Remove(ref Warheads, item2);
					}
					if (Warheads.Length == 0)
					{
						ParentScen.DestroyThisUnit(this, "All MIRV warheads are away!", "Sub-munitions Expended");
						return;
					}
				}
			}
			else if (!IsPalletWeapon && !HasTorpedoPayload && Warheads.Length != 0 && Warheads[0].Type == Warhead.WarheadType.Weapon && !Warheads[0].GetCarriedWeapon(ParentScen).IsNuke.Value)
			{
				Weapon carriedWeapon4 = Warheads[0].GetCarriedWeapon(ParentScen);
				ActiveUnit_Weaponry weaponry3 = Weaponry;
				Contact primaryTarget = AI.PrimaryTarget;
				short? nullable_8 = (short)Math.Round(GetCurrentAltitude());
				Sensor sensor_3 = null;
				if (weaponry3.CanThisWeaponEngageThisTarget(carriedWeapon4, primaryTarget, ref nullable_8, bool_1: false, bool_2: false, bool_3: false, null, ref sensor_3).EvaluationEnum == ActiveUnit_Weaponry.WeaponPrefireChecklistEvaluation.OK)
				{
					VisitReponse(this, carriedWeapon4, AI.PrimaryTarget, float_0, bool_0: true);
					ParentScen.DestroyThisUnit(this, "All child weapons are away!", "Sub-munitions Expended");
					return;
				}
			}
		}
		catch (Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			Exception exception_9 = ex9;
			exception_9?.Data.Add("Error at 100923", "");
			GameGeneral.WriteExceptionsToLog(ref exception_9);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (Warheads.Any() && Warheads[0].IsEMP)
		{
			float num3 = 5f;
			try
			{
				double? num4 = null;
				double? num5 = null;
				if (Information.IsNothing(AI.PrimaryTarget))
				{
					if (Navigator.HasPlottedCourse())
					{
						num4 = Navigator.PlottedCourse[0].Latitude;
						num5 = Navigator.PlottedCourse[0].Longitude;
					}
				}
				else
				{
					num4 = AI.PrimaryTarget.GetLatitude();
					num5 = AI.PrimaryTarget.GetLongitude();
				}
				switch (Warheads[0].Type)
				{
				case Warhead.WarheadType.EMP_Omni:
					if (num4.HasValue && num5.HasValue)
					{
						float num6 = Module_Unit.RangeToPoint_Horiz(this, num4.Value, num5.Value);
						if ((double)num6 <= (double)num3 * 0.33)
						{
							Detonate(GetLatitude(), GetLongitude(), GetCurrentAltitude(), ref lockRandom_0, bool_0: true);
							return;
						}
						if (num6 <= num3 && !Information.IsNothing(AI.PrimaryTarget) && !Information.IsNothing(AI.PrimaryTarget.ActualUnit))
						{
							DesiredAltitude = ImpactAltitude;
							Kinematics.DesiredAltitudeOverride = true;
						}
					}
					break;
				case Warhead.WarheadType.EMP_Directed:
					if (!num4.HasValue || !num5.HasValue)
					{
						break;
					}
					if (!((double)Module_Unit.RangeToPoint_Horiz(this, num4.Value, num5.Value) <= 0.25))
					{
						return;
					}
					if (!Information.IsNothing(AI.PrimaryTarget))
					{
						if (!Information.IsNothing(AI.PrimaryTarget.ActualUnit))
						{
							AI.PrimaryTarget.ActualUnit.Damage.method_0(0.9f);
						}
						AI.DropTarget(AI.PrimaryTarget);
						AI.PrimaryTarget = null;
						Navigator.ClearPlottedCourse();
					}
					if (AI.Targets_ReadOnly.Length == 0)
					{
						ParentScen.DestroyThisUnit(this, "Directed EMP weapon ran out of targets to engage, self-destructed.", "Self-destruct");
						return;
					}
					AI.PrimaryTarget = AI.Targets_ReadOnly.OrderBy((Contact contact_0) => Module_Unit.RangeToUnit_Horiz_Angular(this, contact_0)).ElementAtOrDefault(0);
					return;
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
		try
		{
			if ((AI.PrimaryTarget != null && clientReader) || dicReader)
			{
				if (base.IsMobileDecoy)
				{
					if (Navigator.HasNonPathfindPlottedCourse())
					{
						Navigator.ClearPlottedCourse();
					}
					return;
				}
				if (HasTorpedoPayload && (AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine || AI.PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint || AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint))
				{
					if (Navigator.HasPlottedCourse())
					{
						SetLongitude(null, Navigator.PlottedCourse[0].Longitude);
						SetLatitude(null, Navigator.PlottedCourse[0].Latitude);
					}
					else
					{
						SetLongitude(null, AI.PrimaryTarget.GetLongitude());
						SetLatitude(null, AI.PrimaryTarget.GetLatitude());
					}
					CancelReponse();
					return;
				}
				if (HasDepthChargeWarhead())
				{
					VerifyReponse();
					return;
				}
				if (Warheads.Length != 0 && Warheads[0].GetIsNuclear(ParentScen))
				{
					if (!Information.IsNothing(AI.PrimaryTarget) && !Information.IsNothing(AI.PrimaryTarget.ActualUnit))
					{
						ActiveUnit actualUnit2 = AI.PrimaryTarget.ActualUnit;
						Scenario parentScen = ParentScen;
						List<string> list_2 = null;
						ResolveImpact(actualUnit2, parentScen, bool_0: false, ref list_2);
						if (!ParentScen.MorituriUnits.Contains(this))
						{
							Detonate(GetLatitude(), GetLongitude(), GetCurrentAltitude(), ref lockRandom_0, bool_0: true);
						}
					}
					else if (Information.IsNothing(AI.PrimaryTarget))
					{
						if (Navigator.HasPlottedCourse())
						{
							Detonate(Navigator.PlottedCourse[0].Latitude, Navigator.PlottedCourse[0].Longitude, ImpactAltitude, ref lockRandom_0, bool_0: true);
						}
						else
						{
							Detonate(GetLatitude(), GetLongitude(), ImpactAltitude, ref lockRandom_0, bool_0: true);
						}
					}
					else if (AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint && Navigator.HasPlottedCourse() && Navigator.PlottedCourse.First().Altitude > 9000f)
					{
						Detonate(AI.PrimaryTarget.GetLatitude(), AI.PrimaryTarget.GetLongitude(), Navigator.PlottedCourse.First().Altitude, ref lockRandom_0, bool_0: true);
					}
					else
					{
						Detonate(AI.PrimaryTarget.GetLatitude(), AI.PrimaryTarget.GetLongitude(), ImpactAltitude, ref lockRandom_0, bool_0: true);
					}
					return;
				}
				if (clientReader)
				{
					if (AI.PrimaryTarget != null)
					{
						if (AI.PrimaryTarget.GetIsDestroyed(ParentScen))
						{
							if (AI.PrimaryTarget.IsGroundContact)
							{
								Detonate(AI.PrimaryTarget.GetLatitude(), AI.PrimaryTarget.GetLongitude(), ImpactAltitude, ref lockRandom_0, bool_0: true);
							}
							return;
						}
						if (AI.PrimaryTarget.ActualUnit != null && AI.PrimaryTarget.ActualUnit.Weaponry != null)
						{
							ActiveUnit_Weaponry weaponry4 = AI.PrimaryTarget.ActualUnit.Weaponry;
							Weapon weapon_ = this;
							weaponry4.ResolvePointDefence(float_0, ref weapon_);
							ActiveUnit actualUnit3 = AI.PrimaryTarget.ActualUnit;
							Scenario parentScen2 = ParentScen;
							List<string> list_3 = null;
							ResolveImpact(actualUnit3, parentScen2, bool_0: false, ref list_3);
						}
						else
						{
							if (AI.PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint && Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ParentScen.DestroyThisUnit(this, "Weapon destroyed.", "Weapon Interaction");
						}
					}
				}
				else if (AI.PrimaryTarget != null && AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint)
				{
					if (Warheads.Any() && Warheads[0].GetIsAirburst(this, AI.PrimaryTarget.ActualUnit))
					{
						Detonate(AI.PrimaryTarget.GetLatitude(), AI.PrimaryTarget.GetLongitude(), ImpactAltitude, ref lockRandom_0, bool_0: true);
					}
					else
					{
						float float_2 = 0f;
						float float_3 = 0f;
						Impact_CEP_MissDistanceAndDirection(AI.PrimaryTarget.ActualUnit, ref ParentScen, ref float_2, ref float_3, ref lockRandom_0);
						double double_ = 0.0;
						double double_2 = 0.0;
						Geodesic_EdWilliams.CalcPoint_Williams(AI.PrimaryTarget.GetLongitude(), AI.PrimaryTarget.GetLatitude(), ref double_, ref double_2, float_2 / 1852f, float_3);
						foreach (ActiveUnit activeUnits_ in ParentScen.ActiveUnits_List)
						{
							if (activeUnits_ != null && Module_Unit.RangeToPoint_Horiz_Angular(activeUnits_, ref double_2, ref double_) < Misc.AngularDistance_5nm)
							{
								float float_4 = Math2.VerifyClass(double_2, double_, activeUnits_.GetLatitude(), activeUnits_.GetLongitude()) * 1852f;
								if (CheckForDirectHit(activeUnits_, double_2, double_, float_4, LaunchPoint, MaxRange_NoTargetType, bool_0: false))
								{
									ParentScen.AddMessage("武器：" + Name + "毁伤了" + activeUnits_.Name + ". ", Name + " 命中", LoggedMessage.MessageType.WeaponEndgame, 0, ObjectID, null, new Geopoint_Struct(activeUnits_.GetLongitude(), activeUnits_.GetLatitude()));
									Impact(activeUnits_, null);
									ParentScen.DestroyThisUnit(this, "武器：" + Name + "毁伤了" + activeUnits_.Name + ". ", "Impact / Detonation");
									return;
								}
							}
						}
						short elevation2 = Terrain.GetElevation(double_2, double_, bool_0: false, ParentScen);
						if (Warheads.Length != 0 && (Warheads[0].Type == Warhead.WarheadType.Cluster_Penetrator || Warheads[0].Type == Warhead.WarheadType.HardTargetPenetrator))
						{
							elevation2 -= 10;
							ParentScen.AddMessage("武器：" + Name + " impacts surface, penetrates and detonates. ", Name + " 命中", LoggedMessage.MessageType.WeaponEndgame, 0, ObjectID, null, new Geopoint_Struct(double_, double_2));
							Detonate(double_2, double_, elevation2, ref lockRandom_0, bool_0: false);
						}
						else
						{
							ParentScen.AddMessage("武器：" + Name + "击中地面或水面。", Name + " 命中", LoggedMessage.MessageType.WeaponEndgame, 0, ObjectID, null, new Geopoint_Struct(double_, double_2));
							Detonate(double_2, double_, elevation2, ref lockRandom_0, bool_0: false);
						}
					}
				}
				else
				{
					if (Guidance != WeaponGuidanceType.Inertial && (Information.IsNothing(AI.PrimaryTarget) || !AI.PrimaryTarget.IsGroundContact))
					{
						AI.DropTarget(AI.PrimaryTarget);
						return;
					}
					if (AI.PrimaryTarget == null)
					{
						if (Navigator.HasPlottedCourse())
						{
							Waypoint waypoint = Navigator.PlottedCourse[0];
							Detonate(waypoint.Latitude, waypoint.Longitude, ImpactAltitude, ref lockRandom_0, bool_0: true);
						}
						else
						{
							Detonate(GetLatitude(), GetLongitude(), Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, ParentScen), ref lockRandom_0, bool_0: true);
						}
					}
					else
					{
						Detonate(AI.PrimaryTarget.GetLatitude(), AI.PrimaryTarget.GetLongitude(), ImpactAltitude, ref lockRandom_0, bool_0: true);
					}
				}
			}
			if (m_ObserverReader > 0f)
			{
				m_ObserverReader -= float_0;
				if (m_ObserverReader <= 0f)
				{
					Detonate(GetLatitude(), GetLongitude(), GetLandElevation(bool_0: false, bool_1: false, bool_2: false, ParentScen), ref lockRandom_0, bool_0: true);
				}
			}
			if (!IsReEntryVehicle && GetCurrentAltitude() < (float)elevation)
			{
				if (!(GetCurrentAltitude() < Kinematics.GetMaximumAltitude()) && !InstantiateReponse())
				{
					AddMessage("武器：" + Name + "已经撞入地下", Name + " 已解体", LoggedMessage.MessageType.WeaponEndgame, 0, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
					double latitude2 = GetLatitude();
					double longitude2 = GetLongitude();
					float currentAltitude2 = GetCurrentAltitude();
					LockRandom lockRandom_2 = GameGeneral.LockRandom_0;
					Detonate(latitude2, longitude2, currentAltitude2, ref lockRandom_2, bool_0: true);
				}
				else
				{
					SetCurrentAltitude(bool_0: false, Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, ParentScen) + 1);
				}
			}
		}
		catch (Exception ex10)
		{
			ProjectData.SetProjectError(ex10);
			Exception exception_10 = ex10;
			exception_10?.Data.Add("Error at 100925", "");
			GameGeneral.WriteExceptionsToLog(ref exception_10);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ReleaseMIRVs(List<Warhead> list_0, float float_0, ref short? nullable_0)
	{
		int num = Warheads.Length - 1;
		int i = 0;
		Contact contact = null;
		for (; i <= num; i++)
		{
			Warhead warhead = Warheads[i];
			Weapon carriedWeapon = warhead.GetCarriedWeapon(ParentScen);
			float maximumAltitude = carriedWeapon.Kinematics.GetMaximumAltitude();
			if (maximumAltitude != 0f && !(maximumAltitude >= GetCurrentAltitude()))
			{
				break;
			}
			Weapon newWeapon = GetNewWeapon(ref ParentScen, DBID, bool_0: false);
			int num2 = i + newWeapon.Warheads.Length - Warheads.Length;
			if (AI.PrimaryTarget == null)
			{
				contact = ((carriedWeapon._Sensors.Count() <= 0) ? ((Contact)new AimpointContact(Navigator.PlottedCourse.Last().Latitude, Navigator.PlottedCourse.Last().Longitude)) : ((Contact)new ActivationPointContact(Navigator.PlottedCourse.Last().Latitude, Navigator.PlottedCourse.Last().Longitude)));
			}
			else if (AI.PrimaryTarget.GetIsDestroyed(ParentScen))
			{
				if (Navigator.HasPlottedCourse())
				{
					contact = ((carriedWeapon._Sensors.Count() <= 0) ? ((Contact)new AimpointContact(Navigator.PlottedCourse.Last().Latitude, Navigator.PlottedCourse.Last().Longitude)) : ((Contact)new ActivationPointContact(Navigator.PlottedCourse.Last().Latitude, Navigator.PlottedCourse.Last().Longitude)));
				}
			}
			else
			{
				contact = (carriedWeapon.IsReEntryVehicle ? new AimpointContact(AI.PrimaryTarget.GetLatitude(), AI.PrimaryTarget.GetLongitude()) : AI.PrimaryTarget);
			}
			ActiveUnit_Weaponry weaponry = Weaponry;
			Contact contact_ = contact;
			Sensor sensor_ = null;
			if (weaponry.CanThisWeaponEngageThisTarget(carriedWeapon, contact_, ref nullable_0, bool_1: false, bool_2: false, bool_3: false, null, ref sensor_).EvaluationEnum != 0)
			{
				continue;
			}
			if (num2 == 0)
			{
				VisitReponse(this, carriedWeapon, contact, float_0, bool_0: true);
			}
			else
			{
				try
				{
					if (AI.Targets_ReadOnly.Length == 0)
					{
						VisitReponse(this, carriedWeapon, contact, float_0, bool_0: false);
					}
					else if (num2 - 1 < AI.Targets_ReadOnly.Length)
					{
						if (carriedWeapon.IsReEntryVehicle)
						{
							AimpointContact contact_2 = new AimpointContact(AI.Targets_ReadOnly[num2 - 1].GetLatitude(), AI.Targets_ReadOnly[num2 - 1].GetLongitude());
							VisitReponse(this, carriedWeapon, contact_2, float_0, bool_0: false);
						}
						else
						{
							VisitReponse(this, carriedWeapon, AI.Targets_ReadOnly[num2 - 1], float_0, bool_0: false);
						}
					}
					else
					{
						VisitReponse(this, carriedWeapon, contact, float_0, bool_0: false);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					VisitReponse(this, carriedWeapon, AI.PrimaryTarget, float_0, bool_0: false);
					exception_?.Data.Add("Error at 200047", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			list_0.Add(warhead);
			break;
		}
	}

	private List<Module_Unit.Unit> VisitReponse(Weapon weapon_0, Weapon weapon_1, Contact contact_0, float float_0, bool bool_0)
	{
		List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
		WeaponRec weaponRec_ = new WeaponRec(ref ParentScen, weapon_1.DBID, 1, 1, 1, 1, bool_0: false, bool_1: false);
		Contact contact_ = weapon_0.AI.PrimaryTarget;
		if (contact_ == null)
		{
			contact_ = contact_0;
		}
		WeaponSalvo weaponSalvo_ = null;
		checked
		{
			if (!Information.IsNothing(contact_))
			{
				WeaponSalvo[] weaponSalvos = GetUnitSide().WeaponSalvos;
				for (int i = 0; i < weaponSalvos.Length; i++)
				{
					WeaponSalvo weaponSalvo_2 = weaponSalvos[i];
					if (Information.IsNothing(weaponSalvo_2) || weaponSalvo_2.ShootersList.Length == 0 || weaponSalvo_2.int_0 != weapon_1.DBID || weaponSalvo_2.Target != contact_)
					{
						continue;
					}
					if (!Information.IsNothing(weapon_0) && !Information.IsNothing(weapon_0.FiringParent))
					{
						bool flag = false;
						WeaponSalvo.Shooter[] shootersList = weaponSalvo_2.ShootersList;
						for (int j = 0; j < shootersList.Length; j++)
						{
							if (Operators.CompareString(shootersList[j].ShooterObjectID, weapon_0.FiringParent.ObjectID, TextCompare: false) == 0)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							int value = 1;
							if (!Information.IsNothing(weapon_0.Warheads) && weapon_0.Warheads.Count() > 1)
							{
								value = weapon_0.Warheads.Count();
							}
							weapon_0.FiringParent.GetUnitSide().AddShooterToExistingSalvo(ref weaponSalvo_2, value, 1, value, bool_0: false, ref weapon_0.FiringParent.ObjectID);
						}
					}
					weaponSalvo_ = weaponSalvo_2;
					break;
				}
			}
			if (Information.IsNothing(weaponSalvo_))
			{
				string string_ = null;
				int num = 1;
				if (!Information.IsNothing(weapon_0) && !Information.IsNothing(weapon_0.FiringParent))
				{
					string_ = weapon_0.FiringParent.ObjectID;
				}
				if (!Information.IsNothing(weapon_0.Warheads) && weapon_0.Warheads.Count() > 1)
				{
					num = weapon_0.Warheads.Count();
				}
				ref int dBID = ref weapon_1.DBID;
				int int_ = num;
				bool bool_ = false;
				weaponSalvo_ = new WeaponSalvo(ref dBID, 1, 1, int_, ref contact_, ref bool_, string_, 1, bool_1: false, DateTime.MinValue);
				ArrayExtensions.Add(ref GetUnitSide().WeaponSalvos, weaponSalvo_);
			}
			ActiveUnit_Weaponry weaponry = Weaponry;
			int int_2 = 0;
			list = weaponry.ResetConsumer(float_0, ref weaponRec_, contact_0, ref int_2, 0, 0f, Throttle.Flank, null, SonarModel.PositionRelativeToThermocline.Above, 0L, ref weaponSalvo_);
			foreach (Module_Unit.Unit item in list)
			{
				if (item.IsWeapon && ((Weapon)item).IsReEntryVehicle && !((Weapon)item).IsHGV)
				{
					((Weapon)item).CruiseAltitude_ASL = GetCurrentAltitude();
				}
			}
			if (bool_0)
			{
				Contact contact = null;
				foreach (Module_Unit.Unit item2 in list)
				{
					if (!(item2 is ActiveUnit))
					{
						continue;
					}
					ActiveUnit activeUnit = (ActiveUnit)item2;
					foreach (ActiveUnit activeUnits_ in ParentScen.ActiveUnits_List)
					{
						if (Information.IsNothing(activeUnits_))
						{
							continue;
						}
						foreach (Contact value2 in activeUnits_.Sensory.Contacts_Local_ReadOnly.Values)
						{
							if (!Information.IsNothing(value2.ActualUnit) && value2.ActualUnit == this)
							{
								activeUnits_.Sensory.NewContactsQueue_Local.AddIfNotExistsElseUpdate(activeUnit.ObjectID, value2);
								activeUnits_.Sensory.DroppedContactsQueue_Local.AddIfNotExistsElseUpdate(ObjectID, value2);
							}
						}
					}
					Side[] sides_ReadOnly = ParentScen.Sides_ReadOnly;
					Side[] array = sides_ReadOnly;
					foreach (Side side in array)
					{
						if (side.Contacts.ContainsKey(ObjectID))
						{
							side.Contacts.TryGetValue(ObjectID, ref contact);
							if (!Information.IsNothing(contact))
							{
								contact.ActualUnit = activeUnit;
								contact._ActualUnitID = activeUnit.ObjectID;
								side.Contacts.Add(activeUnit.ObjectID, contact);
								side.Contacts.Remove(ObjectID);
							}
						}
					}
				}
				return list;
			}
			return list;
		}
	}

	private bool RestartReponse()
	{
		if (IsBallisticMissile)
		{
			return Flags.Warhead_MIRV;
		}
		return false;
	}

	private bool TestReponse()
	{
		if (IsBallisticMissile)
		{
			return Flags.Warhead_MRV;
		}
		return false;
	}

	public bool AttemptBuddyIllumination()
	{
		try
		{
			bool? flag = FiringParent?.IsMobileGroundUnit;
			if (flag.GetValueOrDefault(true))
			{
				ActiveUnit firingParent = FiringParent;
				if (firingParent != null && firingParent.IsGroupMember() && flag.HasValue)
				{
					List<ActiveUnit> list = FetchAvailableIlluminators_VehicleGroup(new List<ActiveUnit>(FiringParent?.GetParentGroup().Units.Values), AI.PrimaryTarget);
					if (list.Count <= 0)
					{
						return false;
					}
					ActiveUnit_Sensory sensory = list[0].Sensory;
					Contact primaryTarget = AI.PrimaryTarget;
					flag = null;
					bool? nullable_ = null;
					LOSCheckResult? nullable_2 = null;
					bool? nullable_3 = null;
					sensory.IlluminateThisContactForThisWeapon(primaryTarget, this, ref flag, ref nullable_, ref nullable_2, ref nullable_3);
					return true;
				}
			}
			if (Flags.SupportsBuddyIllumination)
			{
				List<ActiveUnit> list2 = FetchAvailableBuddyIlluminatorUnits(GetUnitSide(), AI.PrimaryTarget);
				if (list2.Count <= 0)
				{
					return false;
				}
				ActiveUnit_Sensory sensory2 = list2[0].Sensory;
				Contact primaryTarget2 = AI.PrimaryTarget;
				bool? nullable_4 = null;
				bool? nullable_5 = null;
				LOSCheckResult? nullable_6 = null;
				flag = null;
				sensory2.IlluminateThisContactForThisWeapon(primaryTarget2, this, ref nullable_4, ref nullable_5, ref nullable_6, ref flag);
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100927", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public void Detonate(double double_0, double double_1, float float_0, ref LockRandom lockRandom_0, bool bool_0)
	{
		try
		{
			if (Type == _WeaponType.Sonobuoy)
			{
				return;
			}
			string string_ = "Impact / Detonation";
			float num = OrderReponse();
			int num2 = lockRandom_0.Next(1, 101);
			_InvocationReader = (float)num2 < num;
			StringBuilder stringBuilder = new StringBuilder();
			string text;
			if (_InvocationReader)
			{
				float float_ = 0f;
				float float_2 = 0f;
				if (Impact_CEP_MissDistanceAndDirection(null, ref ParentScen, ref float_, ref float_2, ref lockRandom_0))
				{
					short elevation = Terrain.GetElevation(double_0, double_1, bool_0: false, ParentScen);
					double double_2 = 0.0;
					double double_3 = 0.0;
					Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_2, ref double_3, float_ / 1852f, float_2);
					float num3 = Terrain.GetElevation(double_3, double_2, bool_0: false, ParentScen);
					if (num3 != (float)elevation)
					{
						float_0 = float_0 + num3 - (float)elevation;
					}
					new Explosion(ref ParentScen, double_2, double_3, double_2, double_3, CurrentHeading, float_0, Type, Warheads[0].DP, Warheads[0].DP, Warheads[0].Type, Warheads[0].ExplosivesType, null, null, null, null, null, Warheads[0].ClusterBombDispersionAreaLength, Warheads[0].ClusterBombDispersionAreaWidth, Warheads[0].NumberOfWarheads);
				}
				else
				{
					new Explosion(ref ParentScen, double_1, double_0, double_1, double_0, CurrentHeading, float_0, Type, Warheads[0].DP, Warheads[0].DP, Warheads[0].Type, Warheads[0].ExplosivesType, null, null, null, null, null, Warheads[0].ClusterBombDispersionAreaLength, Warheads[0].ClusterBombDispersionAreaWidth, Warheads[0].NumberOfWarheads);
				}
				text = ((Warheads.Count() > 0 && Warheads[0].IsCluster) ? ("武器：" + Name + " 爆裂为子弹头...") : ((AI.PrimaryTarget == null) ? ("武器：" + Name + "撞到地面，距预期的目标点" + Conversions.ToString(float_) + "米。") : ("武器：" + Name + "引爆了，" + Conversions.ToString(float_) + "米。")));
				_ = Name + " 正引爆";
			}
			else if (IsPalletWeapon)
			{
				text = "Pallet Weapon: " + Name + " reached the ground and was self destroyed.";
				string_ = "Impact / Detonation";
				ParentScen.AddMessage(text, Name + " landed and self destroyed ", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
			}
			else
			{
				text = "武器：" + Name + "发生故障。";
				string_ = "Malfunction";
				ParentScen.AddMessage(text, Name + " 故障", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
			}
			if (bool_0)
			{
				ParentScen.AddMessage(text, Name + " 正引爆", LoggedMessage.MessageType.WeaponEndgame, 0, ObjectID, null, new Geopoint_Struct(double_1, double_0));
			}
			ParentScen.DestroyThisUnit(this, text, string_);
			stringBuilder.Append(text);
			Module_Unit.Unit unit_ = null;
			if (AI.PrimaryTarget != null)
			{
				unit_ = ((AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint) ? ((Module_Unit.Unit)AI.PrimaryTarget) : ((Module_Unit.Unit)AI.PrimaryTarget.ActualUnit));
			}
			ExportResolveImpactEvent(unit_, bool_0: false, bool_1: false, stringBuilder);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101338", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool myTargetDoesNotExist()
	{
		if (AI.PrimaryTarget == null)
		{
			return true;
		}
		if (ParentScen == null)
		{
			return true;
		}
		if (AI.PrimaryTarget.ActualUnit != null && !AI.PrimaryTarget.ActualUnit.IsOperating())
		{
			return true;
		}
		if (AI.PrimaryTarget.ActualUnit == null)
		{
			return true;
		}
		if (AI.PrimaryTarget.ActualUnit.IsDestroyed)
		{
			return true;
		}
		return false;
	}

	protected virtual void HandleReachingActivationPoint()
	{
		if (Guidance == WeaponGuidanceType.Inertial)
		{
			return;
		}
		bool bool_ = (AI.PrimaryTarget == null || !AI.PrimaryTarget.IsBallisticTarget()) && !Flags.LoiterCapability;
		if (Navigator.HasNonPathfindPlottedCourse())
		{
			return;
		}
		if (AI.PrimaryTarget != null && AI.PrimaryTarget.ActualUnit != null && AI.PrimaryTarget.IsAir_Missile_Orbital_Contact && DataLinkParent != null)
		{
			Sensory.ActivateTerminalSensors();
			if (AI.PrimaryTarget.LastDetections.Where(((string DetectorUnitID, string DetectingSensorID, float RangeEstimate, ActiveUnit_Sensory.SpecialDetectionMode theDetectionMode, DateTime theTime) valueTuple_0) => Operators.CompareString(valueTuple_0.DetectorUnitID, ObjectID, TextCompare: false) == 0).Count() > 0)
			{
				StopReponse(AI.PrimaryTarget != null && AI.PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint, bool_);
			}
		}
		else
		{
			StopReponse(AI.PrimaryTarget != null && AI.PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint, bool_);
		}
	}

	internal void StopReponse(bool bool_0 = false, bool bool_1 = false, bool bool_2 = false)
	{
		try
		{
			if (_DatalinkRetargetTime <= 0f || Guidance != WeaponGuidanceType.Datalink_Plus_SemiActive)
			{
				_BlindTime = 0f;
			}
			if (!Information.IsNothing(AI.PrimaryTarget))
			{
				_DatalinkRetargetTime = 0f;
			}
			if (bool_0)
			{
				Weapon_AI aI = AI;
				ActiveUnit activeUnit_ = this;
				aI.ClearAllTargets(ref activeUnit_);
				if (!Navigator.HasNonPathfindPlottedCourse())
				{
					SetDesiredHeading(TurnRate.Max, CurrentHeading);
				}
			}
			if (bool_1)
			{
				ClearAllComms();
				DetermineGuidance();
				byte? b = (byte?)m_WrapperReader;
				bool? flag;
				bool? flag2 = (flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 13) : null));
				bool? flag3 = ((flag2.HasValue && !flag.GetValueOrDefault()) ? new bool?(false) : (Information.IsNothing(AI.PrimaryTarget) ? new bool?(false) : flag));
				if (flag3.GetValueOrDefault(true) && Navigator.PlottedCourse.Length == 0 && flag3.HasValue)
				{
					Navigator.AddWaypoint(AI.PrimaryTarget.GetLatitude(), AI.PrimaryTarget.GetLongitude(), AI.PrimaryTarget.GetCurrentAltitude(), Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
				}
			}
			if (bool_2 && Guidance != WeaponGuidanceType.Inertial)
			{
				Navigator.ClearPlottedCourse();
			}
			if (!Navigator.HasNonPathfindPlottedCourse() && !PlayerIsPlottingCourse)
			{
				Sensory.ActivateTerminalSensors();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100928", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ClearAllComms()
	{
		if (DataLinkParent != null)
		{
			DataLinkParent = null;
		}
		_Comms = new CommDevice[0];
	}

	public void ClearAllSensors()
	{
		if (_Sensors.Length != 0)
		{
			ArrayExtensions.Clear(ref _Sensors);
			base.Sensors_Cached = null;
			MineCountermeasures = null;
		}
	}

	[SpecialName]
	private bool HasDepthChargeWarhead()
	{
		try
		{
			Warhead[] warheads = Warheads;
			int num = 0;
			while (true)
			{
				if (num < warheads.Length)
				{
					Warhead warhead = warheads[num];
					if (warhead.Type != Warhead.WarheadType.DepthCharge)
					{
						if (warhead.Type == Warhead.WarheadType.Weapon && warhead.GetCarriedWeapon(ParentScen).Type == _WeaponType.DepthCharge)
						{
							break;
						}
						num++;
						continue;
					}
					return true;
				}
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100930", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private void CancelReponse()
	{
		List<Warhead> list = new List<Warhead>();
		try
		{
			Warhead[] warheads = Warheads;
			Warhead[] array = warheads;
			foreach (Warhead warhead in array)
			{
				if (warhead.GetCarriedWeapon(ParentScen) != null && warhead.GetCarriedWeapon(ParentScen).IsTorpedo)
				{
					Weapon weapon_ = GetNewWeapon(ref ParentScen, (int)Math.Round(warhead.DP), bool_0: false);
					weapon_.SetLatitude(null, GetLatitude());
					weapon_.SetLongitude(null, GetLongitude());
					weapon_.SetCurrentAltitude(bool_0: false, -20f);
					weapon_.CurrentHeading = CurrentHeading;
					weapon_.SetDesiredHeading(TurnRate.Max, weapon_.CurrentHeading);
					weapon_.LaunchPoint = new GeoPoint(GetLongitude(), GetLatitude());
					weapon_.SetUnitSide(bool_0: false, GetUnitSide());
					weapon_.SetThrottle(weapon_.MaxPossibleThrottleSetting);
					weapon_.AI.PrimaryTarget = AI.PrimaryTarget;
					weapon_.FiringParent = FiringParent;
					weapon_.SearchPatternType = WeaponSearchPatternType.Circle;
					if (!ParentScen.ActiveUnits.ContainsKey(weapon_.ObjectID))
					{
						ParentScen.AddThisUnit(weapon_);
					}
					list.Add(warhead);
					Weapon_AI aI = weapon_.AI;
					Contact contact_ = aI.PrimaryTarget;
					CreateSalvo_Airborne(ref weapon_, ref contact_, ParentScen);
					aI.PrimaryTarget = contact_;
				}
			}
			foreach (Warhead item in list)
			{
				ArrayExtensions.Remove(ref Warheads, item);
			}
			if (Warheads.Length == 0 || AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine)
			{
				ParentScen.DestroyThisUnit(this, "Torpedo payload has been released, self-destructing", "Sub-munitions Expended");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100931", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void VerifyReponse()
	{
		List<Warhead> list = new List<Warhead>();
		try
		{
			Warhead[] warheads = Warheads;
			Warhead[] array = warheads;
			foreach (Warhead warhead in array)
			{
				if (Information.IsNothing(warhead.GetCarriedWeapon(ParentScen)) || warhead.GetCarriedWeapon(ParentScen).Type != _WeaponType.DepthCharge)
				{
					continue;
				}
				UnguidedWeapon unguidedWeapon = new UnguidedWeapon(warhead.GetCarriedWeapon(ParentScen), AI.PrimaryTarget, this, GetLatitude(), GetLongitude(), 0L);
				unguidedWeapon.CEP_Surface = warhead.GetCarriedWeapon(ParentScen).CEP_Surface_Nominal;
				unguidedWeapon.CurrentHeading = AI.BearingToUnit_True(AI.PrimaryTarget);
				unguidedWeapon.SetUnitSide(bool_0: false, GetUnitSide());
				unguidedWeapon.FiringParent = m_DefinitionReader;
				if (!Information.IsNothing(m_DefinitionReader))
				{
					unguidedWeapon.FiringParent_ID = m_DefinitionReader.ObjectID;
				}
				if (warhead.GetCarriedWeapon(ParentScen).IsNuke.Value)
				{
					if ((float)GameGeneral.LockRandom_0.Next(1, 101) < unguidedWeapon.SubPOK)
					{
						unguidedWeapon.Detonate(ParentScen);
					}
				}
				else
				{
					ParentScen.UnguidedWeapons.Add(unguidedWeapon.ObjectID, unguidedWeapon);
				}
				list.Add(warhead);
			}
			foreach (Warhead item in list)
			{
				ArrayExtensions.Remove(ref Warheads, item);
			}
			if (Warheads.Length == 0 || AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine)
			{
				ParentScen.DestroyThisUnit(this, "Torpedo payload has been released, self-destructing", "Sub-munitions Expended");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100932", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected bool GuidanceLogic_DestroyedFiringParent()
	{
		return false;
	}

	public void GoDumb(bool bool_0 = true)
	{
		try
		{
			if (Guidance == WeaponGuidanceType.SemiActive)
			{
				Flags.IlluminateAtLaunch = false;
				Flags.TerminalIllumination = false;
				foreach (ActiveUnit value in ParentScen.ActiveUnits.Values)
				{
					Sensor[] array = value.Sensors_ReadOnly();
					Sensor[] array2 = array;
					foreach (Sensor sensor in array2)
					{
						if (sensor.SemiActiveWeaponsGuided.Contains(this))
						{
							sensor.SemiActiveWeaponsGuided.Remove(this);
							SensorProvidingFireControlForMe = null;
						}
						if (sensor.SemiActiveWeaponsGuided.Count == 0)
						{
							sensor.StopTrackingTarget(AI.PrimaryTarget);
						}
					}
				}
			}
			if (_Comms.Count() > 0 && (AI.PrimaryTarget_Type == Contact_Base.ContactType.Surface || AI.PrimaryTarget_Type == Contact_Base.ContactType.Submarine || AI.PrimaryTarget_Type == Contact_Base.ContactType.Facility_Fixed || AI.PrimaryTarget_Type == Contact_Base.ContactType.Facility_Mobile))
			{
				if (Information.IsNothing(AI.PrimaryTarget))
				{
					AimpointContact primaryTarget = new AimpointContact(AI.PrimaryTarget_LastKnown_Lat, AI.PrimaryTarget_LastKnown_Lon);
					AI.PrimaryTarget = primaryTarget;
				}
				else
				{
					AimpointContact primaryTarget2 = new AimpointContact(AI.PrimaryTarget.GetLatitude(), AI.PrimaryTarget.GetLongitude());
					AI.PrimaryTarget = primaryTarget2;
				}
			}
			else
			{
				ClearAllSensors();
				ClearAllComms();
				DetermineGuidance();
				if (Guidance == WeaponGuidanceType.Inertial && bool_0)
				{
					Navigator.CalculateDescriptor(Kinematics.GetMaximumSpeed(GetCurrentAltitude(), ThrottleSetting, bool_0: false), bool_1: false);
				}
			}
			if (Flags.ReAttack_Capability)
			{
				Flags.ReAttack_Capability = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100933", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected bool GuidanceLogic_DatalinkParentNotAvailable(float float_0)
	{
		try
		{
			if (!IsAAW && Type != _WeaponType.Torpedo && Navigator.HasNonPathfindPlottedCourse())
			{
				return false;
			}
			if (DataLinkParent == null || DataLinkParent.IsDestroyed)
			{
				CommStuff.CheckCommsAndDataLinks(float_0, null);
			}
			if (DataLinkParent != null && !DataLinkParent.IsDestroyed)
			{
				if (DataLinkParent.IsShip && ((Ship)DataLinkParent).IsSinking)
				{
					StopReponse(bool_0: false, bool_1: true);
					return true;
				}
				return false;
			}
			if (Guidance == WeaponGuidanceType.TVM)
			{
				StopReponse(bool_0: true, bool_1: true, bool_2: true);
			}
			else
			{
				StopReponse(bool_0: false, bool_1: true);
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100934", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	protected virtual bool GuidanceLogic_DestroyedOrVanishedPrimaryTarget_DatalinkedWeapon(float float_0)
	{
		try
		{
			if (myTargetDoesNotExist())
			{
				AttemptRetargeting_Datalink(float_0, 60f);
				return true;
			}
			if (AI.PrimaryTarget != null && !AI.PrimaryTarget.GetIsDestroyed(ParentScen))
			{
				if (AI.PrimaryTarget.Age > 30f && AI.PrimaryTarget.IsAir_Missile_Orbital_Contact && !Navigator.HasNonPathfindPlottedCourse())
				{
					if (!HasGoneAutonomous)
					{
						StopReponse(bool_0: true, bool_1: true);
						AddMessage("武器：" + Name + "没有收到来自父单元的确切目标更新...自主决策。", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
					}
					return true;
				}
				return false;
			}
			AttemptRetargeting_Datalink(float_0, 60f);
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100935", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private bool ListReponse(float float_0)
	{
		try
		{
			if (myTargetDoesNotExist())
			{
				if (!base.HasInfraredSensor)
				{
					BlindTime += float_0;
				}
				return true;
			}
			if (AI.PrimaryTarget.GetIsDestroyed(ParentScen))
			{
				if (!AI.PrimaryTarget.IsSurfaceContact)
				{
					if (Information.IsNothing(DataLinkParent))
					{
						AddMessage("武器：" + Name + "的目标被摧毁了...", "武器问题", LoggedMessage.MessageType.WeaponEndgame, 5, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						StopReponse(bool_0: true, bool_1: true, bool_2: true);
					}
					else
					{
						AddMessage("武器：" + Name + "在终端照射阶段将目标摧毁，尝试重新定位...", "武器问题", LoggedMessage.MessageType.WeaponEndgame, 5, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						AttemptRetargeting_Datalink(float_0, 60f);
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
			exception_?.Data.Add("Error at 100936", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	protected bool GuidanceLogic_DestroyedOrVanishedPrimaryTarget_AutonomousWeapon()
	{
		try
		{
			if (Navigator.HasNonPathfindPlottedCourse())
			{
				return false;
			}
			if (Information.IsNothing(AI.PrimaryTarget))
			{
				if (!Information.IsNothing(AI.PrimaryTarget) && IsTorpedo && AI.PrimaryTarget.Age > 600f)
				{
					AddMessage("武器：" + Name + "没有收到来自父单元的确切目标更新...自主决策。", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
					return true;
				}
			}
			else if (AI.PrimaryTarget.GetIsDestroyed(ParentScen))
			{
				StopReponse(bool_0: true, bool_1: true);
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100937", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private bool ResolveReponse()
	{
		try
		{
			if (AI.PrimaryTarget_Type == Contact_Base.ContactType.Surface || AI.PrimaryTarget_Type == Contact_Base.ContactType.Submarine || AI.PrimaryTarget_Type == Contact_Base.ContactType.Facility_Fixed || AI.PrimaryTarget_Type == Contact_Base.ContactType.Facility_Mobile)
			{
				if (myTargetDoesNotExist())
				{
					AimpointContact primaryTarget = new AimpointContact(AI.PrimaryTarget_LastKnown_Lat, AI.PrimaryTarget_LastKnown_Lon);
					if ((AI.PrimaryTarget_LastKnown_Lat == 0.0) & (AI.PrimaryTarget_LastKnown_Lon == 0.0))
					{
						AI.PrimaryTarget_LastKnown_Lat = AI.PrimaryTarget.GetLatitude();
						AI.PrimaryTarget_LastKnown_Lon = AI.PrimaryTarget.GetLongitude();
						primaryTarget = new AimpointContact(AI.PrimaryTarget.GetLatitude(), AI.PrimaryTarget.GetLongitude());
					}
					AI.PrimaryTarget = primaryTarget;
					return true;
				}
				if (AI.PrimaryTarget.GetIsDestroyed(ParentScen))
				{
					AimpointContact primaryTarget2 = new AimpointContact(AI.PrimaryTarget.GetLatitude(), AI.PrimaryTarget.GetLongitude());
					AI.PrimaryTarget = primaryTarget2;
					return true;
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101297", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	protected bool GuidanceLogic_Overshoot(float float_0, bool bool_0, bool bool_1, bool bool_2, float float_1)
	{
		if (Flags.ReAttack_Capability)
		{
			return false;
		}
		try
		{
			if (Navigator.HasNonPathfindPlottedCourse())
			{
				return false;
			}
			if (!Information.IsNothing(AI.PrimaryTarget) && HasTorpedoPayload && (AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine || AI.PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint || AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint))
			{
				return false;
			}
			if (!Information.IsNothing(AI.PrimaryTarget) && AI.PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint)
			{
				if ((double)Module_Unit.RangeToUnit_Horiz(this, AI.PrimaryTarget) < 0.3)
				{
					return false;
				}
				if (IsTorpedo && Flags.SearchPattern)
				{
					Weapon_AI aI = AI;
					Weapon weapon_ = this;
					if (!aI.ReadClient(ref weapon_))
					{
						return false;
					}
				}
				float num = (Information.IsNothing(AI.PrimaryTarget.ActualUnit) ? MathFunctions.GetRelativeBearing(CurrentHeading, AI.BearingToUnit_True(AI.PrimaryTarget)) : MathFunctions.GetRelativeBearing(CurrentHeading, AI.BearingToUnit_True(AI.PrimaryTarget.ActualUnit)));
				if (360f - float_0 > num && num > float_0 && !clientReader)
				{
					if (Information.IsNothing(DataLinkParent))
					{
						if (!Information.IsNothing(FiringParent) && Module_Unit.RangeToUnit_Horiz(this, FiringParent) < 2f)
						{
							return false;
						}
						if (AI.PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint)
						{
							AddMessage("武器：" + Name + "未击中目标...", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						}
						StopReponse(bool_0, bool_1, bool_2);
						return true;
					}
					if (Module_Unit.RangeToUnit_Horiz(this, DataLinkParent) < 2f)
					{
						return false;
					}
					AttemptRetargeting_Datalink(float_1, float_0);
					return true;
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100938", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal bool PostReponse()
	{
		if ((uint)(Type - 4102) <= 4u)
		{
			return true;
		}
		return false;
	}

	private bool RunReponse(float float_0)
	{
		if (Information.IsNothing(DataLinkParent) && Information.IsNothing(FiringParent))
		{
			return false;
		}
		if (Information.IsNothing(AI.PrimaryTarget.ActualUnit))
		{
			return false;
		}
		try
		{
			if (AI.PrimaryTarget.ActualUnit.IsAircraft || AI.PrimaryTarget.ActualUnit.IsWeapon)
			{
				if ((double)Module_Unit.RangeToUnit_Horiz(this, AI.PrimaryTarget) < 0.3)
				{
					return false;
				}
				float num = 0f;
				if (Information.IsNothing(DataLinkParent))
				{
					if (!Information.IsNothing(FiringParent))
					{
						if (Module_Unit.RangeToUnit_Horiz(this, FiringParent) < 2f)
						{
							return false;
						}
						num = MathFunctions.GetRelativeBearing(CurrentHeading, Math2.PublishClass(FiringParent.GetLatitude(), FiringParent.GetLongitude(), GetLatitude(), GetLongitude()));
					}
				}
				else
				{
					if (Module_Unit.RangeToUnit_Horiz(this, DataLinkParent) < 2f)
					{
						return false;
					}
					num = MathFunctions.GetRelativeBearing(CurrentHeading, Math2.PublishClass(DataLinkParent.GetLatitude(), DataLinkParent.GetLongitude(), GetLatitude(), GetLongitude()));
				}
				if (num > float_0 && num < 360f - float_0 && !clientReader)
				{
					if (Guidance != WeaponGuidanceType.SemiActive_Plus_Active && Guidance != WeaponGuidanceType.TimesharedSemiActive_Plus_Active)
					{
						if (_Sensors.Length != 1 && Guidance != WeaponGuidanceType.TVM)
						{
							AddMessage("武器：" + Name + "检测不到来自目标的反射能量（攻击几何问题）......切换到备用导引头", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
							StopReponse(bool_0: false, bool_1: true, bool_2: true);
						}
						else
						{
							AddMessage("武器：" + Name + "检测不到来自目标的反射能量（攻击几何问题）......", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
							StopReponse(bool_0: true, bool_1: true, bool_2: true);
						}
					}
					else
					{
						AddMessage("武器：" + Name + "检测不到目标的反射能量（攻击几何问题）......切换到机载导引头", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						StopReponse(bool_0: false, bool_1: true, bool_2: true);
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
			exception_?.Data.Add("Error at 100939", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private float StartReponse()
	{
		float result = 60f;
		if (DataLinkParent != null && AI.PrimaryTarget != null && AI.PrimaryTarget.IsBallisticTarget())
		{
			result = 120f;
			Geopoint_Struct geopoint_Struct = Navigator.RemoveDescriptor(AI.PrimaryTarget);
			if (!geopoint_Struct.HasZeroCoords && Math.Abs(DesiredHeading - Module_Unit.BearingToPoint_True(this, geopoint_Struct.Latitude, geopoint_Struct.Longitude)) < 60f)
			{
				result = 180f;
			}
		}
		return result;
	}

	protected virtual void WeaponLogic_DatalinkedWeapons(float float_0)
	{
		try
		{
			if (GuidanceLogic_DatalinkParentNotAvailable(float_0) || GuidanceLogic_DestroyedOrVanishedPrimaryTarget_DatalinkedWeapon(float_0))
			{
				return;
			}
			float float_ = 60f;
			if (AI.PrimaryTarget != null)
			{
				if (AI.PrimaryTarget.IsBallisticTarget())
				{
					float_ = StartReponse();
				}
				else if (isLoiterCapable)
				{
					float_ = 180f;
				}
			}
			GuidanceLogic_Overshoot(float_, bool_0: true, bool_1: true, bool_2: true, float_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100941", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public List<ActiveUnit> FetchAvailableIlluminators_VehicleGroup(List<ActiveUnit> list_0, Contact contact_0)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		try
		{
			Sensor sensor = null;
			if (_IlluminatorUnit != null && contact_0 != null)
			{
				ActiveUnit_Sensory sensory = _IlluminatorUnit.Sensory;
				Contact contact_ = contact_0;
				ref Sensor sensor_ = ref sensor;
				bool? nullable_ = null;
				bool? nullable_2 = null;
				LOSCheckResult? nullable_3 = null;
				bool? nullable_4 = null;
				if (sensory.CanIlluminateThisContactForThisWeapon(contact_, this, ref sensor_, ref nullable_, ref nullable_2, ref nullable_3, ref nullable_4))
				{
					list.Add(_IlluminatorUnit);
				}
			}
			if (contact_0 != null)
			{
				IEnumerable<ActiveUnit> collection = from theAU0 in list_0.Where(delegate(ActiveUnit theAU)
					{
						ActiveUnit_Sensory sensory2 = theAU.Sensory;
						Contact contact_2 = contact_0;
						Weapon weapon_ = this;
						ref Sensor sensor_2 = ref sensor;
						bool? nullable_5 = null;
						bool? nullable_6 = null;
						LOSCheckResult? nullable_7 = null;
						bool? nullable_8 = null;
						return sensory2.CanIlluminateThisContactForThisWeapon(contact_2, weapon_, ref sensor_2, ref nullable_5, ref nullable_6, ref nullable_7, ref nullable_8);
					})
					orderby Module_Unit.RangeToPoint_Horiz_Angular(theAU0, new GeoPoint(contact_0.GetLongitude(), contact_0.GetLatitude()))
					select theAU0;
				list.AddRange(collection);
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100942", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return list;
		}
	}

	public List<ActiveUnit> FetchAvailableBuddyIlluminatorUnits(Side side_0, Contact contact_0)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		try
		{
			Sensor sensor = null;
			if (!Information.IsNothing(_IlluminatorUnit) && !Information.IsNothing(contact_0))
			{
				ActiveUnit_Sensory sensory = _IlluminatorUnit.Sensory;
				Contact contact_ = contact_0;
				ref Sensor sensor_ = ref sensor;
				bool? nullable_ = null;
				bool? nullable_2 = null;
				LOSCheckResult? nullable_3 = null;
				bool? nullable_4 = null;
				if (sensory.CanIlluminateThisContactForThisWeapon(contact_, this, ref sensor_, ref nullable_, ref nullable_2, ref nullable_3, ref nullable_4))
				{
					list.Add(_IlluminatorUnit);
				}
			}
			if (Flags.SupportsBuddyIllumination && !Information.IsNothing(contact_0))
			{
				IEnumerable<ActiveUnit> collection = from theAU0 in side_0.Units.ToList().Where(delegate(ActiveUnit theAU)
					{
						ActiveUnit_Sensory sensory2 = theAU.Sensory;
						Contact contact_2 = contact_0;
						Weapon weapon_ = this;
						ref Sensor sensor_2 = ref sensor;
						bool? nullable_5 = null;
						bool? nullable_6 = null;
						LOSCheckResult? nullable_7 = null;
						bool? nullable_8 = null;
						return sensory2.CanIlluminateThisContactForThisWeapon(contact_2, weapon_, ref sensor_2, ref nullable_5, ref nullable_6, ref nullable_7, ref nullable_8);
					})
					orderby Module_Unit.RangeToPoint_Horiz_Angular(theAU0, new GeoPoint(contact_0.GetLongitude(), contact_0.GetLatitude()))
					select theAU0;
				list.AddRange(collection);
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100942", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return list;
		}
	}

	private void AssetReponse(float float_0)
	{
		try
		{
			if (Type == _WeaponType.Sonobuoy || GuidanceLogic_DatalinkParentNotAvailable(float_0) || GuidanceLogic_DestroyedOrVanishedPrimaryTarget_DatalinkedWeapon(float_0))
			{
				return;
			}
			if (PrintReponse())
			{
				BlindTime += float_0;
				return;
			}
			BlindTime = 0f;
			AI.PrimaryTarget.Age = 0f;
			Module_Unit.ClosureSpeed(this, AI.PrimaryTarget, CurrentSpeed, CurrentHeading);
			if (clientReader || dicReader)
			{
				if (AI.PrimaryTarget.GetIsDestroyed(ParentScen))
				{
					return;
				}
				if (Information.IsNothing(DataLinkParent) || Information.IsNothing(SensorProvidingFireControlForMe))
				{
					List<ActiveUnit> list = FetchAvailableBuddyIlluminatorUnits(GetUnitSide(), AI.PrimaryTarget);
					if (list.Count <= 0)
					{
						Contact_Base.ContactType type = AI.PrimaryTarget.Type;
						if ((int)type > 1 && type != Contact_Base.ContactType.Orbital)
						{
							CEP_Surface = 3 * CEP_Surface;
							CEP_Land = 3 * CEP_Land;
							SurfPOK = (int)Math.Round((double)SurfPOK / 3.0);
							LandPOK = (int)Math.Round((double)LandPOK / 3.0);
							SubPOK = (int)Math.Round((double)SubPOK / 3.0);
						}
						else if (_Sensors.Length == 1)
						{
							AddMessage("武器：" + Name + "不能让目标照亮......", "武器问题", LoggedMessage.MessageType.WeaponEndgame, 5, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
							AI.PrimaryTarget = null;
							return;
						}
					}
					else
					{
						foreach (ActiveUnit item in list)
						{
							if (!Information.IsNothing(item))
							{
								ActiveUnit_Sensory sensory = item.Sensory;
								Contact primaryTarget = AI.PrimaryTarget;
								bool? nullable_ = null;
								bool? nullable_2 = null;
								LOSCheckResult? nullable_3 = null;
								bool? nullable_4 = null;
								sensory.IlluminateThisContactForThisWeapon(primaryTarget, this, ref nullable_, ref nullable_2, ref nullable_3, ref nullable_4);
								break;
							}
						}
					}
				}
			}
			if (!DataLinkParent.Sensory.IsIlluminatingThisContact(AI.PrimaryTarget))
			{
				ActiveUnit_Sensory sensory2 = DataLinkParent.Sensory;
				Contact primaryTarget2 = AI.PrimaryTarget;
				bool? nullable_5 = null;
				bool? nullable_6 = null;
				LOSCheckResult? nullable_7 = null;
				bool? nullable_8 = null;
				Sensor sensor_ = null;
				if (sensory2.CanIlluminateThisContactForThisWeapon(primaryTarget2, this, ref sensor_, ref nullable_5, ref nullable_6, ref nullable_7, ref nullable_8))
				{
					ActiveUnit_Sensory sensory3 = DataLinkParent.Sensory;
					Contact primaryTarget3 = AI.PrimaryTarget;
					nullable_8 = null;
					nullable_6 = null;
					nullable_7 = null;
					nullable_5 = null;
					sensory3.IlluminateThisContactForThisWeapon(primaryTarget3, this, ref nullable_8, ref nullable_6, ref nullable_7, ref nullable_5);
				}
			}
			if (!RunReponse(90f))
			{
				GuidanceLogic_Overshoot(60f, bool_0: true, bool_1: true, bool_2: true, float_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100943", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool PrintReponse()
	{
		try
		{
			if (Information.IsNothing(AI.PrimaryTarget))
			{
				return true;
			}
			if (Information.IsNothing(AI.PrimaryTarget.ActualUnit))
			{
				return true;
			}
			Sensor sensorProvidingFireControlForMe = SensorProvidingFireControlForMe;
			bool flag = false;
			if (!Information.IsNothing(sensorProvidingFireControlForMe) && sensorProvidingFireControlForMe.Status == PlatformComponent._ComponentStatus.Operational)
			{
				Weapon_AI aI;
				Contact contact_ = (aI = AI).PrimaryTarget;
				bool num = sensorProvidingFireControlForMe.IsTrackingThisTargetForFireControl(ref contact_);
				aI.PrimaryTarget = contact_;
				if (!num)
				{
					flag = true;
				}
				ActiveUnit parentPlatform = sensorProvidingFireControlForMe.ParentPlatform;
				contact_ = (aI = AI).PrimaryTarget;
				ref Scenario parentScen = ref ParentScen;
				float float_ = Module_Unit.RangeToUnit_Slant(sensorProvidingFireControlForMe.ParentPlatform, AI.PrimaryTarget.ActualUnit);
				bool isShip = sensorProvidingFireControlForMe.ParentPlatform.IsShip;
				bool isShip2 = sensorProvidingFireControlForMe.ParentPlatform.IsShip;
				bool? nullable_ = null;
				bool? nullable_2 = null;
				LOSCheckResult? nullable_3 = null;
				bool? nullable_4 = null;
				Sensor.SensorDetectionCheckResult num2 = sensorProvidingFireControlForMe.CanIlluminateTarget(parentPlatform, ref contact_, ref parentScen, float_, null, isShip, isShip2, ref nullable_, ref nullable_2, ref nullable_3, ref nullable_4);
				aI.PrimaryTarget = contact_;
				if (num2 != Sensor.SensorDetectionCheckResult.Success)
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				if (!Information.IsNothing(FiringParent))
				{
					ActiveUnit_Sensory sensory = FiringParent.Sensory;
					Contact primaryTarget = AI.PrimaryTarget;
					bool? nullable_5 = null;
					bool? nullable_6 = null;
					LOSCheckResult? nullable_7 = null;
					bool? nullable_8 = null;
					if (sensory.IlluminateThisContactForThisWeapon(primaryTarget, this, ref nullable_5, ref nullable_6, ref nullable_7, ref nullable_8))
					{
						flag = false;
					}
				}
				if (flag && AttemptBuddyIllumination())
				{
					flag = false;
				}
			}
			return flag;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100944", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private void DefineReponse(float float_0)
	{
		try
		{
			if (ListReponse(float_0))
			{
				return;
			}
			if (PrintReponse())
			{
				BlindTime += float_0;
			}
			else
			{
				BlindTime = 0f;
				AI.PrimaryTarget.Age = 0f;
			}
			if (clientReader || dicReader)
			{
				if (AI.PrimaryTarget.GetIsDestroyed(ParentScen))
				{
					return;
				}
				if ((double)BlindTime > 0.5)
				{
					Contact_Base.ContactType type = AI.PrimaryTarget.Type;
					if ((int)type > 1 && type != Contact_Base.ContactType.Orbital)
					{
						CEP_Surface = 200 * CEP_Surface * (int)Math.Round(BlindTime);
						CEP_Land = 200 * CEP_Land * (int)Math.Round(BlindTime);
						AddMessage("武器：" + Name + "不能让它的目标被照亮...会严重降低精度。", "武器问题", LoggedMessage.MessageType.WeaponEndgame, 5, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						return;
					}
					if (_Sensors.Length == 1)
					{
						AddMessage("武器：" + Name + "不能让目标照亮......", "武器问题", LoggedMessage.MessageType.WeaponEndgame, 5, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						AI.PrimaryTarget = null;
						return;
					}
				}
			}
			if (!RunReponse(90f))
			{
				GuidanceLogic_Overshoot(60f, bool_0: true, bool_1: true, bool_2: true, float_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100945", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PublishReponse(float float_0)
	{
		try
		{
			if (Navigator.HasPlottedCourse() || ListReponse(float_0))
			{
				return;
			}
			float float_ = Module_Unit.ClosureSpeed(this, AI.PrimaryTarget, CurrentSpeed, CurrentHeading);
			if (PrintReponse())
			{
				BlindTime += float_0;
			}
			else
			{
				BlindTime = 0f;
				AI.PrimaryTarget.Age = 0f;
			}
			if (clientReader || dicReader)
			{
				if (AI.PrimaryTarget.GetIsDestroyed(ParentScen))
				{
					return;
				}
				if ((double)BlindTime > 0.5)
				{
					Contact_Base.ContactType type = AI.PrimaryTarget.Type;
					if ((int)type > 1 && type != Contact_Base.ContactType.Orbital)
					{
						CEP_Surface = 200 * CEP_Surface;
						CEP_Land = 200 * CEP_Land;
						AddMessage("武器：" + Name + "不能让它的目标被照亮...会严重降低精度。", "武器已致盲", LoggedMessage.MessageType.WeaponEndgame, 5, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						return;
					}
					if (_Sensors.Length == 1)
					{
						AddMessage("武器：" + Name + "不能让目标照亮......", "武器已致盲", LoggedMessage.MessageType.WeaponEndgame, 5, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						AI.PrimaryTarget = null;
						return;
					}
				}
			}
			if (ETA_To_Location(float_, Module_Unit.RangeToUnit_Horiz(this, AI.PrimaryTarget)) <= (float)Math.Max(10, IlluminationTime))
			{
				if (AI.PrimaryTarget.GetIsDestroyed(ParentScen))
				{
					return;
				}
				bool flag;
				if (flag = Information.IsNothing(DataLinkParent))
				{
					if (flag)
					{
						foreach (ActiveUnit item in FetchAvailableBuddyIlluminatorUnits(GetUnitSide(), AI.PrimaryTarget))
						{
							if (!Information.IsNothing(item))
							{
								ActiveUnit_Sensory sensory = item.Sensory;
								Contact primaryTarget = AI.PrimaryTarget;
								bool? nullable_ = null;
								bool? nullable_2 = null;
								LOSCheckResult? nullable_3 = null;
								bool? nullable_4 = null;
								sensory.IlluminateThisContactForThisWeapon(primaryTarget, this, ref nullable_, ref nullable_2, ref nullable_3, ref nullable_4);
								break;
							}
						}
					}
				}
				else if (!DataLinkParent.Sensory.IsIlluminatingThisContact(AI.PrimaryTarget))
				{
					PrintReponse();
				}
			}
			if (!RunReponse(90f) && Guidance != WeaponGuidanceType.Datalink_Plus_SemiActive)
			{
				GuidanceLogic_Overshoot(60f, bool_0: true, bool_1: true, bool_2: true, float_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100946", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void AwakeReponse(float float_0)
	{
		try
		{
			if (ListReponse(float_0))
			{
				return;
			}
			float float_ = Module_Unit.ClosureSpeed(this, AI.PrimaryTarget, CurrentSpeed, CurrentHeading);
			if (clientReader || dicReader)
			{
				if (AI.PrimaryTarget.GetIsDestroyed(ParentScen))
				{
					return;
				}
				if ((double)BlindTime > 0.5)
				{
					Contact_Base.ContactType type = AI.PrimaryTarget.Type;
					if ((int)type > 1 && type != Contact_Base.ContactType.Orbital)
					{
						CEP_Surface = 200 * CEP_Surface;
						CEP_Land = 200 * CEP_Land;
						AddMessage("武器：" + Name + "不能让它的目标被照亮...会严重降低精度。", "武器问题", LoggedMessage.MessageType.WeaponEndgame, 5, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						return;
					}
					if (_Sensors.Length == 1)
					{
						AddMessage("武器：" + Name + "不能让目标照亮......", "武器问题", LoggedMessage.MessageType.WeaponEndgame, 5, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						AI.PrimaryTarget = null;
						return;
					}
				}
			}
			if (ETA_To_Location(float_, Module_Unit.RangeToUnit_Horiz(this, AI.PrimaryTarget)) <= (float)Math.Max(10, IlluminationTime))
			{
				if (AI.PrimaryTarget.GetIsDestroyed(ParentScen))
				{
					return;
				}
				bool flag = false;
				bool flag2;
				if (flag2 = DataLinkParent == null)
				{
					if (flag2)
					{
						foreach (ActiveUnit item in FetchAvailableBuddyIlluminatorUnits(GetUnitSide(), AI.PrimaryTarget))
						{
							if (item != null)
							{
								ActiveUnit_Sensory sensory = item.Sensory;
								Contact primaryTarget = AI.PrimaryTarget;
								bool? nullable_ = null;
								bool? nullable_2 = null;
								LOSCheckResult? nullable_3 = null;
								bool? nullable_4 = null;
								sensory.IlluminateThisContactForThisWeapon(primaryTarget, this, ref nullable_, ref nullable_2, ref nullable_3, ref nullable_4);
								break;
							}
						}
					}
				}
				else if (!DataLinkParent.Sensory.IsIlluminatingThisContact(AI.PrimaryTarget))
				{
					flag = PrintReponse();
				}
				if (flag)
				{
					BlindTime += float_0;
				}
				else
				{
					BlindTime = 0f;
					AI.PrimaryTarget.Age = 0f;
				}
			}
			if (!RunReponse(90f) && Guidance != WeaponGuidanceType.Datalink_Plus_SemiActive)
			{
				GuidanceLogic_Overshoot(60f, bool_0: true, bool_1: true, bool_2: true, float_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100946", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CreateSalvo_Airborne(ref Weapon weapon_0, ref Contact contact_0, Scenario scenario_0)
	{
		WeaponSalvo[] weaponSalvos = weapon_0.GetUnitSide().WeaponSalvos;
		for (int i = 0; i < weaponSalvos.Length; i = checked(i + 1))
		{
			WeaponSalvo weaponSalvo_ = weaponSalvos[i];
			if (weaponSalvo_.Target != contact_0 || weaponSalvo_.int_0 != weapon_0.DBID)
			{
				continue;
			}
			WeaponSalvo.Shooter[] shootersList = weaponSalvo_.ShootersList;
			WeaponSalvo.Shooter[] array = shootersList;
			foreach (WeaponSalvo.Shooter shooter in array)
			{
				if (!Information.IsNothing(weapon_0.FiringParent) && Operators.CompareString(shooter.ShooterObjectID, weapon_0.FiringParent.ObjectID, TextCompare: false) == 0)
				{
					if (shooter.QuantityAssigned < int.MaxValue)
					{
						shooter.QuantityAssigned++;
					}
					if (shooter.QuantityFired < int.MaxValue)
					{
						shooter.QuantityFired++;
					}
					ArrayExtensions.Add(ref weaponSalvo_.WeaponList, weapon_0.ObjectID);
					if (weaponSalvo_.MaxNumberOfWeapons != int.MaxValue)
					{
						weaponSalvo_.MaxNumberOfWeapons++;
					}
					return;
				}
			}
			if (Information.IsNothing(weapon_0.FiringParent))
			{
				Side unitSide = weapon_0.GetUnitSide();
				int? nullable_ = 1;
				int? nullable_2 = 1;
				string string_ = "12456789";
				unitSide.AddShooterToExistingSalvo(ref weaponSalvo_, nullable_, 1, nullable_2, bool_0: false, ref string_);
			}
			else
			{
				weapon_0.GetUnitSide().AddShooterToExistingSalvo(ref weaponSalvo_, 1, 1, 1, bool_0: false, ref weapon_0.FiringParent.ObjectID);
			}
		}
		if (Information.IsNothing(weapon_0.FiringParent))
		{
			Side unitSide2 = weapon_0.GetUnitSide();
			int? nullable_3 = 1;
			int? nullable_4 = 1;
			string string_2 = "123456789";
			int? nullable_5 = 1;
			ArrayExtensions.Add(ref unitSide2.AssignSalvoToTarget(scenario_0, ref weapon_0, ref contact_0, nullable_3, 1, nullable_4, bool_0: false, ref string_2, ref nullable_5, DateTime.MinValue, DateTime.MinValue).WeaponList, weapon_0.ObjectID);
		}
		else
		{
			Side unitSide3 = weapon_0.GetUnitSide();
			int? nullable_6 = 1;
			int? nullable_7 = 1;
			ref string objectID = ref weapon_0.FiringParent.ObjectID;
			int? nullable_8 = 1;
			ArrayExtensions.Add(ref unitSide3.AssignSalvoToTarget(scenario_0, ref weapon_0, ref contact_0, nullable_6, 1, nullable_7, bool_0: false, ref objectID, ref nullable_8, DateTime.MinValue, DateTime.MinValue).WeaponList, weapon_0.ObjectID);
		}
	}

	public virtual void AttemptRetargeting_Datalink(float float_0, float float_1)
	{
		try
		{
			if (Type == _WeaponType.Sonobuoy)
			{
				return;
			}
			Contact contact = null;
			if (!Information.IsNothing(AI.PrimaryTarget))
			{
				contact = AI.PrimaryTarget;
				Weapon_AI aI = AI;
				ActiveUnit activeUnit_ = this;
				aI.ClearAllTargets(ref activeUnit_);
				if (!Navigator.HasNonPathfindPlottedCourse())
				{
					SetDesiredHeading(TurnRate.Max, CurrentHeading);
				}
			}
			DatalinkRetargetTime += float_0;
			double num = Math.Round(DatalinkRetargetTime, 1);
			if (num != 0.1 && num != 1.0 && num != 6.0 && num != 11.0 && (num <= 11.0 || AI.PrimaryTarget_Type != Contact_Base.ContactType.ActivationPoint || num % 15.0 != 0.0))
			{
				return;
			}
			List<Contact> list = new List<Contact>();
			List<Contact> list2 = new List<Contact>();
			if (!Information.IsNothing(AI.PrimaryTarget_Type) && (AI.PrimaryTarget_Type == Contact_Base.ContactType.Air || AI.PrimaryTarget_Type == Contact_Base.ContactType.Missile || AI.PrimaryTarget_Type == Contact_Base.ContactType.Submarine || AI.PrimaryTarget_Type == Contact_Base.ContactType.Torpedo))
			{
				GetUnitSide().RemoveWeaponFromSalvos(ref ParentScen, ref ObjectID);
			}
			if (Information.IsNothing(DataLinkParent))
			{
				DatalinkRetargetTime = 0f;
				StopReponse(bool_0: true, bool_1: true);
				if (Guidance == WeaponGuidanceType.Datalink_Plus_Active)
				{
					AddMessage("武器：" + Name + "没有合适的替代目标被重定向到...自行决策。", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
					return;
				}
				AddMessage("武器：" + Name + "丢失数据链接...", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
				AI.PrimaryTarget = null;
				return;
			}
			Contact[] targets_ReadOnly = DataLinkParent.AI.Targets_ReadOnly;
			Contact[] array = targets_ReadOnly;
			foreach (Contact contact2 in array)
			{
				string string_ = "";
				float value = Module_Unit.PrintTokenizer(contact2, this, bool_0: true, ref string_);
				if (Math.Abs(value) > float_1 || contact == contact2)
				{
					continue;
				}
				bool? flag;
				if (contact2.GetStance(DataLinkParent.GetUnitSide()) == Misc.PostureStance.Hostile)
				{
					flag = false;
				}
				else
				{
					byte? b = (byte?)DataLinkParent.Doctrine.GetWeaponControlStatus_Air(DataLinkParent.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
					bool? flag2 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null);
					flag = (!flag2) ?? flag2;
				}
				bool? flag3 = flag;
				if ((!(!flag3).GetValueOrDefault() && !contact2.IsSubmergedContact && flag3.HasValue) || !DataLinkParent.AI.IsClearedToEngageThisTarget(contact2) || (Math.Abs(value) > 20f && !contact2.IsBallisticTarget() && !contact2.IsOrbitalContact))
				{
					continue;
				}
				float num2 = ((contact2.CurrentSpeed == 0f) ? CurrentSpeed : Module_Unit.ClosureSpeed(this, contact2, CurrentSpeed, CurrentHeading));
				if (Module_Unit.RangeToUnit_Horiz(this, contact2) / (num2 / 3600f) < 3f)
				{
					continue;
				}
				try
				{
					if (!Information.IsNothing(DataLinkParent) && Operators.CompareString(DataLinkParent.Weaponry.CanThisWeaponEngageThisTarget_AttemptRetargeting(this, contact2), "OK", TextCompare: false) == 0)
					{
						goto IL_0523;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200048", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					goto IL_0523;
				}
				continue;
				IL_0523:
				if (!Information.IsNothing(AI.PrimaryTarget_Type) && contact2.Type == AI.PrimaryTarget_Type)
				{
					list.Add(contact2);
				}
				else
				{
					list2.Add(contact2);
				}
			}
			Weapon weapon_;
			Contact contact_;
			switch (list.Count)
			{
			case 1:
			{
				BlindTime = 0f;
				DatalinkRetargetTime = 0f;
				AI.PrimaryTarget = list[0];
				weapon_ = this;
				Weapon_AI aI4 = AI;
				contact_ = aI4.PrimaryTarget;
				CreateSalvo_Airborne(ref weapon_, ref contact_, ParentScen);
				aI4.PrimaryTarget = contact_;
				AddMessage("武器：" + Name + "只有一个替代目标可以重定向到：" + AI.PrimaryTarget.Name, "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
				return;
			}
			case 0:
				AddMessage("武器：" + Name + "没有合格的替代目标可以重定向到...", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
				switch (list2.Count)
				{
				default:
				{
					BlindTime = 0f;
					DatalinkRetargetTime = 0f;
					IEnumerable<Contact> source = list2.OrderBy((Contact theC) => theC.IncomingGuidedWeapons.Length).ThenBy((Contact contact_0) => Module_Unit.RangeToUnit_Horiz_Angular(this, contact_0));
					AI.PrimaryTarget = source.ElementAtOrDefault(0);
					weapon_ = this;
					Weapon_AI aI2 = AI;
					contact_ = aI2.PrimaryTarget;
					CreateSalvo_Airborne(ref weapon_, ref contact_, ParentScen);
					aI2.PrimaryTarget = contact_;
					if (!Information.IsNothing(contact) && contact == AI.PrimaryTarget)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else
					{
						AddMessage("武器：" + Name + "已被重定向到新目标：" + AI.PrimaryTarget.Name, "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
					}
					break;
				}
				case 1:
				{
					BlindTime = 0f;
					DatalinkRetargetTime = 0f;
					AI.PrimaryTarget = list2[0];
					weapon_ = this;
					Weapon_AI aI3 = AI;
					contact_ = aI3.PrimaryTarget;
					CreateSalvo_Airborne(ref weapon_, ref contact_, ParentScen);
					aI3.PrimaryTarget = contact_;
					AddMessage("武器：" + Name + "只有一个备用（辅助）目标可以重定向到：" + AI.PrimaryTarget.Name, "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
					break;
				}
				case 0:
					if (AI.PrimaryTarget_Type != Contact_Base.ContactType.Surface && AI.PrimaryTarget_Type != Contact_Base.ContactType.Submarine && AI.PrimaryTarget_Type != Contact_Base.ContactType.Facility_Fixed && AI.PrimaryTarget_Type != Contact_Base.ContactType.Facility_Mobile)
					{
						if (DatalinkRetargetTime < 11f)
						{
							break;
						}
						if (IsAAW)
						{
							StopReponse(bool_0: true, bool_1: true, bool_2: true);
							if (Guidance != WeaponGuidanceType.Active && Guidance != WeaponGuidanceType.Passive && Guidance != WeaponGuidanceType.SemiActive_Plus_Active && Guidance != WeaponGuidanceType.TimesharedSemiActive_Plus_Active && _Sensors.Length <= 1)
							{
								AddMessage("武器：" + Name + "没有合格的替代目标可以重定向到...", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
							}
							else
							{
								AddMessage("武器：" + Name + "没有合适的替代目标被重定向到...自行决策。", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
							}
						}
						else if (AI.PrimaryTarget_Type != Contact_Base.ContactType.ActivationPoint)
						{
							StopReponse(bool_0: true, bool_1: true, bool_2: true);
							return;
						}
					}
					else
					{
						if (_Sensors.Length != 0 && ValidTargets.Radar && Is_LOAL_capable)
						{
							StopReponse(bool_0: true, bool_1: true, bool_2: true);
							return;
						}
						GoDumb();
					}
					break;
				}
				if (!Information.IsNothing(AI.PrimaryTarget) && Navigator.HasNonPathfindPlottedCourse())
				{
					Navigator.CalculateDescriptor(Kinematics.GetMaximumSpeed(GetCurrentAltitude(), ThrottleSetting, bool_0: false), bool_1: false);
					if (Navigator.HasNonPathfindPlottedCourse())
					{
						SetDesiredHeading(TurnRate.Max, Math2.PublishClass(GetLatitude(), GetLongitude(), Navigator.PlottedCourse[0].Latitude, Navigator.PlottedCourse[0].Longitude));
					}
				}
				return;
			}
			BlindTime = 0f;
			DatalinkRetargetTime = 0f;
			IEnumerable<Contact> source2 = list.OrderBy((Contact theC) => theC.IncomingGuidedWeapons.Length).ThenBy((Contact contact_0) => Module_Unit.RangeToUnit_Horiz_Angular(this, contact_0));
			AI.PrimaryTarget = source2.ElementAtOrDefault(0);
			weapon_ = this;
			Weapon_AI aI5 = AI;
			contact_ = aI5.PrimaryTarget;
			CreateSalvo_Airborne(ref weapon_, ref contact_, ParentScen);
			aI5.PrimaryTarget = contact_;
			if (!Information.IsNothing(contact) && contact == AI.PrimaryTarget)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			else
			{
				AddMessage("武器：" + Name + "已被重定向到新目标：" + AI.PrimaryTarget.Name, "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100947", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AttemptRetargeting_Beamrider(float float_0)
	{
		try
		{
			ActiveUnit parentPlatform = SensorProvidingFireControlForMe.ParentPlatform;
			if (!Information.IsNothing(AI.PrimaryTarget))
			{
				Weapon_AI aI = AI;
				ActiveUnit activeUnit_ = this;
				aI.ClearAllTargets(ref activeUnit_);
				if (!Navigator.HasNonPathfindPlottedCourse())
				{
					SetDesiredHeading(TurnRate.Max, CurrentHeading);
				}
			}
			DatalinkRetargetTime += float_0;
			double num = Math.Round(DatalinkRetargetTime, 1);
			if (num != 0.1 && num != 1.0 && num != 6.0 && num != 11.0)
			{
				return;
			}
			List<Contact> list = new List<Contact>();
			Contact[] targets_ReadOnly = parentPlatform.AI.Targets_ReadOnly;
			Contact[] array = targets_ReadOnly;
			foreach (Contact contact in array)
			{
				float relativeBearing = MathFunctions.GetRelativeBearing(CurrentHeading, Math2.PublishClass(GetLatitude(), GetLongitude(), contact.GetLatitude(), contact.GetLongitude()));
				if (340f <= relativeBearing || relativeBearing <= 20f)
				{
					list.Add(contact);
				}
			}
			switch (list.Count)
			{
			default:
			{
				DatalinkRetargetTime = 0f;
				AI.PrimaryTarget = AI.FindClient(list);
				Weapon weapon_ = this;
				Weapon_AI aI2 = AI;
				Contact contact_ = aI2.PrimaryTarget;
				CreateSalvo_Airborne(ref weapon_, ref contact_, ParentScen);
				aI2.PrimaryTarget = contact_;
				break;
			}
			case 1:
			{
				DatalinkRetargetTime = 0f;
				AI.PrimaryTarget = list[0];
				Weapon weapon_2 = this;
				Weapon_AI aI3 = AI;
				Contact contact_2 = aI3.PrimaryTarget;
				CreateSalvo_Airborne(ref weapon_2, ref contact_2, ParentScen);
				aI3.PrimaryTarget = contact_2;
				break;
			}
			case 0:
				if (DatalinkRetargetTime >= 11f)
				{
					DatalinkRetargetTime = 0f;
					AI.PrimaryTarget = null;
					AddMessage("武器：" + Name + "没有合格的替代目标可以重定向到...", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100948", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool QueryReponse(ActiveUnit activeUnit_0, ref Contact contact_0, ref bool? nullable_0)
	{
		if (contact_0 != null)
		{
			if (contact_0.ActualUnit == null)
			{
				return Flags.BearingOnlyLaunch;
			}
			Scenario parentScen = contact_0.ActualUnit.ParentScen;
			bool flag = false;
			if (contact_0 == null)
			{
				return false;
			}
			try
			{
				if (IsPalletWeapon)
				{
					Warhead[] warheads = Warheads;
					Warhead[] array3 = warheads;
					foreach (Warhead warhead in array3)
					{
						if (warhead.GetCarriedWeapon(parentScen) != null)
						{
							return warhead.GetCarriedWeapon(parentScen).QueryReponse(activeUnit_0, ref contact_0, ref nullable_0);
						}
					}
				}
				if (IsFuelTank)
				{
					return false;
				}
				if (contact_0.Type != Contact_Base.ContactType.Aimpoint && contact_0.Type != Contact_Base.ContactType.ActivationPoint)
				{
					_WeaponType type = Type;
					if (type != _WeaponType.Decoy_Vehicle && type != _WeaponType.UAV_Expendable)
					{
						if (IsDecoy && Type != _WeaponType.Decoy_Vehicle)
						{
							Contact_Base.ContactType type2 = contact_0.Type;
							if (type2 != Contact_Base.ContactType.Missile && (int)(type2 - 9) > 1)
							{
								return false;
							}
							ActiveUnit actualUnit = contact_0.ActualUnit;
							if (actualUnit == null)
							{
								return false;
							}
							if (actualUnit.IsWeapon)
							{
								Sensor[] array = actualUnit.Sensors_ReadOnly();
								Sensor[] array4 = array;
								foreach (Sensor sensor_ in array4)
								{
									if (RateReponse(sensor_))
									{
										if (!nullable_0.HasValue)
										{
											nullable_0 = contact_0.GetIsDestroyed(parentScen);
										}
										return !nullable_0.Value;
									}
								}
							}
							return false;
						}
						if (ValidTargets.Radar)
						{
							if (contact_0.HasDetectedEmissions)
							{
								int num = 0;
								int[] array2 = contact_0.DetectedEmissions.Keys.ToArray();
								int[] array5 = array2;
								foreach (int num2 in array5)
								{
									try
									{
										if ((contact_0.DetectedEmissions[num2].Age < 30f) | (contact_0.ActualUnit != null && contact_0.ActualUnit.GetIsAutoDetectable(activeUnit_0?.GetUnitSide())))
										{
											num++;
										}
									}
									catch (Exception projectError)
									{
										ProjectData.SetProjectError(projectError);
										ProjectData.ClearProjectError();
									}
								}
								if (num > 0)
								{
									if (MaxAirRange <= 0f)
									{
										if (MaxSurfaceRange > 0f && (contact_0.Type == Contact_Base.ContactType.Facility_Fixed || contact_0.Type == Contact_Base.ContactType.Facility_Mobile || contact_0.Type == Contact_Base.ContactType.Surface))
										{
											if (!nullable_0.HasValue)
											{
												nullable_0 = contact_0.GetIsDestroyed(parentScen);
											}
											return !nullable_0.Value;
										}
									}
									else if (contact_0.Type == Contact_Base.ContactType.Air)
									{
										if (!nullable_0.HasValue)
										{
											nullable_0 = contact_0.GetIsDestroyed(parentScen);
										}
										return !nullable_0.Value;
									}
								}
							}
							else if (contact_0.ActualUnit == null)
							{
								if (!ValidTargets.MultipleTypes)
								{
									return false;
								}
							}
							else
							{
								if (contact_0.IDStatus >= Contact_Base.IdentificationStatus.KnownClass && contact_0.ActualUnit.Sensors_Cached.Where((Sensor theS) => theS.Type == Sensor.Sensor_Type.Radar && theS.Status == PlatformComponent._ComponentStatus.Operational).Count() > 0)
								{
									if (!nullable_0.HasValue)
									{
										nullable_0 = contact_0.GetIsDestroyed(parentScen);
									}
									return !nullable_0.Value;
								}
								if (!ValidTargets.MultipleTypes)
								{
									return false;
								}
							}
						}
						switch (contact_0.Type)
						{
						case Contact_Base.ContactType.ActivationPoint:
							return ValidTargets.SurfaceVessel;
						case Contact_Base.ContactType.Air:
							if (contact_0.ActualUnit != null)
							{
								if (contact_0.ActualUnit.IsAircraft)
								{
									if (((Aircraft)contact_0.ActualUnit).IsAerostat)
									{
										if (IsAAW)
										{
											flag = true;
										}
										if ((IsASuW_Land || IsASuW_Naval) && Type == _WeaponType.GuidedWeapon)
										{
											flag = true;
										}
									}
									else if (ValidTargets.Aircraft)
									{
										flag = true;
									}
								}
								else if (ValidTargets.Aircraft)
								{
									flag = true;
								}
								break;
							}
							return false;
						case Contact_Base.ContactType.Missile:
						{
							if (contact_0.ActualUnit == null)
							{
								return false;
							}
							if (contact_0.ActualUnit.IsMissile && ValidTargets.Missile)
							{
								flag = true;
							}
							if ((object)contact_0.ActualUnit.GetType() == typeof(UnguidedRocket) && ValidTargets.RAMB)
							{
								flag = true;
							}
							if (IsLaserShot)
							{
								if (!nullable_0.HasValue)
								{
									nullable_0 = contact_0.GetIsDestroyed(parentScen);
								}
								return !nullable_0.Value;
							}
							if (!((Weapon)contact_0.ActualUnit).IsAAW)
							{
								break;
							}
							if (((Weapon)(contact_0?.ActualUnit))?.AI?.PrimaryTarget?.ActualUnit == null)
							{
								flag = false;
								break;
							}
							bool? flag2;
							bool? flag3 = (flag2 = ((Weapon)contact_0.ActualUnit)?.AI?.PrimaryTarget?.ActualUnit?.IsShip);
							bool? flag4;
							if (flag3.HasValue && flag2.GetValueOrDefault())
							{
								flag4 = true;
							}
							else
							{
								bool? flag5 = (flag3 = ((Weapon)contact_0.ActualUnit)?.AI?.PrimaryTarget?.ActualUnit?.IsSubmarine);
								bool? flag6;
								bool? flag7;
								if (flag5.HasValue && !flag3.GetValueOrDefault())
								{
									flag6 = false;
								}
								else
								{
									flag5 = (flag7 = ((Submarine)(((Weapon)contact_0.ActualUnit)?.AI?.PrimaryTarget?.ActualUnit))?.IsSurfaced);
									flag6 = ((!flag5.HasValue) ? null : (flag7.GetValueOrDefault() & flag3));
								}
								bool? flag8 = flag6;
								flag7 = flag6;
								flag4 = ((!flag7.HasValue) ? null : (flag8.GetValueOrDefault() | flag2));
							}
							bool? flag9 = flag4;
							if (((!flag9) ?? flag9).GetValueOrDefault())
							{
								flag = false;
							}
							break;
						}
						case Contact_Base.ContactType.Surface:
						{
							if (ValidTargets.SurfaceVessel)
							{
								flag = true;
							}
							ActiveUnit actualUnit2 = contact_0.ActualUnit;
							if (actualUnit2 != null)
							{
								if (ValidTargets.Submarine && actualUnit2.IsSubmarine && actualUnit2.GetCurrentAltitude() == 0f)
								{
									flag = true;
								}
								break;
							}
							return false;
						}
						case Contact_Base.ContactType.Submarine:
							if (ValidTargets.Submarine)
							{
								flag = true;
							}
							if (contact_0.GetCurrentAltitude() == 0f && ValidTargets.SurfaceVessel)
							{
								flag = true;
							}
							break;
						case Contact_Base.ContactType.Aimpoint:
							return ValidTargets.LandStructure_Hard || ValidTargets.LandStructure_Soft || ValidTargets.Runway;
						case Contact_Base.ContactType.Orbital:
							return ValidTargets.Satellite;
						case Contact_Base.ContactType.Facility_Fixed:
							if (contact_0.ActualUnit != null)
							{
								if (contact_0.ActualUnit.IsUnderwater)
								{
									if ((uint)(Type - 4001) <= 1u)
									{
										if (!nullable_0.HasValue)
										{
											nullable_0 = contact_0.GetIsDestroyed(parentScen);
										}
										return !nullable_0.Value;
									}
									return false;
								}
								switch (((Facility)contact_0.ActualUnit).Category)
								{
								case Facility._FacilityCategory.AirBase:
									return false;
								default:
									return ValidTargets.LandStructure_Hard || ValidTargets.LandStructure_Soft;
								case Facility._FacilityCategory.Water_Surface:
									return ValidTargets.LandStructure_Hard || ValidTargets.LandStructure_Soft || ValidTargets.SurfaceVessel;
								case Facility._FacilityCategory.Runway:
								case Facility._FacilityCategory.RunwayGrade_Taxiway:
								case Facility._FacilityCategory.RunwayAccessPoint:
									return ValidTargets.Runway;
								}
							}
							return false;
						case Contact_Base.ContactType.Facility_Mobile:
							return ValidTargets.MobileTarget_Hard || ValidTargets.MobileTarget_Soft || ((ValidTargets.LandStructure_Hard || ValidTargets.LandStructure_Soft) && contact_0.CurrentSpeed == 0f);
						case Contact_Base.ContactType.Torpedo:
							return ValidTargets.Torpedo;
						case Contact_Base.ContactType.Decoy_Air:
							if (!ValidTargets.Aircraft || contact_0.DetectedEmissions.Count <= 0)
							{
								break;
							}
							foreach (KeyValuePair<int, EmissionContainer> detectedEmission in contact_0.DetectedEmissions)
							{
								if (detectedEmission.Value.GetAssociatedSensor(detectedEmission.Key, parentScen).IsOECM)
								{
									flag = true;
								}
							}
							break;
						}
						if (flag)
						{
							if (!nullable_0.HasValue)
							{
								nullable_0 = contact_0.GetIsDestroyed(parentScen);
							}
							return !nullable_0.Value;
						}
						return false;
					}
					switch (contact_0.Type)
					{
					case Contact_Base.ContactType.Air:
						return MaxAirRange > 0f;
					case Contact_Base.ContactType.Surface:
						return MaxSurfaceRange > 0f;
					case Contact_Base.ContactType.Submarine:
						return MaxSubsurfaceRange > 0f;
					default:
						return false;
					case Contact_Base.ContactType.Facility_Fixed:
					case Contact_Base.ContactType.Facility_Mobile:
						return MaxLandRange > 0f;
					}
				}
				switch (Type)
				{
				default:
					if (!nullable_0.HasValue)
					{
						nullable_0 = contact_0.GetIsDestroyed(parentScen);
					}
					return !nullable_0.Value;
				case _WeaponType.Decoy_Expendable:
				case _WeaponType.Decoy_Towed:
				case _WeaponType.TrainingRound:
				case _WeaponType.SensorPod:
				case _WeaponType.DropTank:
				case _WeaponType.BuddyStore:
				case _WeaponType.FerryTank:
				case _WeaponType.HeliTowedPackage:
					return false;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200276", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
		}
		return false;
	}

	internal bool ResetReponse(float float_0, Contact contact_0)
	{
		return GetRangeMaxToTargetType(contact_0.Type) >= float_0;
	}

	public bool CanBeFiredOnAmbigousTarget(Contact contact_0, bool bool_0)
	{
		try
		{
			if (contact_0.ActualUnit.IsShip || contact_0.ActualUnit.IsSubmarine || contact_0.ActualUnit.IsFacility || contact_0.ActualUnit.IsTorpedo)
			{
				if (Is_LOAL_capable)
				{
					if ((int)(Guidance - 1) <= 1)
					{
						return false;
					}
					return true;
				}
				if (Flags.BearingOnlyLaunch)
				{
					return true;
				}
				if (ValidTargets.Radar)
				{
					return true;
				}
				if (Flags.IlluminateAtLaunch)
				{
					return true;
				}
				if ((uint)(Type - 2002) <= 2u)
				{
					switch (contact_0.Type)
					{
					case Contact_Base.ContactType.Surface:
						return false;
					default:
						return bool_0;
					case Contact_Base.ContactType.Submarine:
					case Contact_Base.ContactType.Aimpoint:
					case Contact_Base.ContactType.Facility_Fixed:
					case Contact_Base.ContactType.Facility_Mobile:
					case Contact_Base.ContactType.Torpedo:
						return true;
					}
				}
				if (Comms_ReadOnly.Count() > 0 && _Sensors.Length != 0 && (contact_0.IsGroundContact || contact_0.IsSurfaceContact || contact_0.IsSubmergedContact))
				{
					return true;
				}
				if (Guidance == WeaponGuidanceType.Inertial)
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
			exception_?.Data.Add("Error at 100950", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal bool MapReponse(float float_0, Contact contact_0)
	{
		switch (contact_0.Type)
		{
		case Contact_Base.ContactType.Surface:
		case Contact_Base.ContactType.UndeterminedNaval:
			return MinSurfaceRange > float_0;
		case Contact_Base.ContactType.Aimpoint:
		case Contact_Base.ContactType.ActivationPoint:
			if (!Module_Unit.ResetTokenizer(contact_0) && (MaxSurfaceRange != 0f || MaxLandRange <= 0f))
			{
				return MinSurfaceRange > float_0;
			}
			return MinLandRange > float_0;
		case Contact_Base.ContactType.Air:
		case Contact_Base.ContactType.Missile:
		case Contact_Base.ContactType.Orbital:
			return MinAirRange > float_0;
		case Contact_Base.ContactType.Facility_Fixed:
		case Contact_Base.ContactType.Facility_Mobile:
			return MinLandRange > float_0;
		default:
			return false;
		case Contact_Base.ContactType.Submarine:
		case Contact_Base.ContactType.Mine:
			return MinSubsurfaceRange > float_0;
		}
	}

	internal float SortReponse(Contact contact_0)
	{
		switch (contact_0.Type)
		{
		case Contact_Base.ContactType.Surface:
		case Contact_Base.ContactType.UndeterminedNaval:
			return MinSurfaceRange;
		case Contact_Base.ContactType.Air:
		case Contact_Base.ContactType.Missile:
		case Contact_Base.ContactType.Orbital:
			return MinAirRange;
		case Contact_Base.ContactType.Facility_Fixed:
		case Contact_Base.ContactType.Facility_Mobile:
			return MinLandRange;
		default:
			return 0f;
		case Contact_Base.ContactType.Submarine:
		case Contact_Base.ContactType.Mine:
			return MinSubsurfaceRange;
		}
	}

	internal bool CalcReponse(Module_Unit.Unit unit_0, float float_0, bool bool_0 = false)
	{
		try
		{
			if (AI.PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint && Guidance != WeaponGuidanceType.Inertial)
			{
				return false;
			}
			if (AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint)
			{
				if (IsAAW)
				{
					return false;
				}
				if ((IsASuW_Naval || IsASuW_Land) && Guidance != WeaponGuidanceType.Inertial && AI.PrimaryTarget_Type != Contact_Base.ContactType.Surface && AI.PrimaryTarget_Type != Contact_Base.ContactType.Submarine && AI.PrimaryTarget_Type != Contact_Base.ContactType.Facility_Fixed && AI.PrimaryTarget_Type != Contact_Base.ContactType.Facility_Mobile)
				{
					return false;
				}
			}
			if (Flags.ReAttack_Capability && AI.PrimaryTarget != null)
			{
				float num = Module_Unit.BearingToPoint_Relative(this, AI.PrimaryTarget.GetLatitude(), AI.PrimaryTarget.GetLongitude());
				if (num > 90f && num < 270f)
				{
					return false;
				}
			}
			if (Module_Unit.RangeToUnit_Horiz(this, unit_0) <= 10f)
			{
				float num12 = 1f;
				if (float_0 != 0.1f)
				{
					num12 += float_0;
				}
				float num15 = 0f;
				if (IsTorpedo || Guidance != WeaponGuidanceType.Inertial)
				{
					num15 = Module_Unit.ClosureSpeed(this, unit_0, Module_Unit.CalcTokenizer(this), CurrentHeading);
				}
				float num16 = num15 / 3600f;
				bool flag = false;
				if (Navigator.HasPlottedCourse() && ((Guidance == WeaponGuidanceType.Inertial && !IsTorpedo) || (!Information.IsNothing(AI.PrimaryTarget.Type) && HasTorpedoPayload && (AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine || AI.PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint || AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint))))
				{
					Waypoint geoPoint_ = Navigator.PlottedCourse[Navigator.PlottedCourse.Count() - 1];
					float num17 = Module_Unit.RangeToPoint_Horiz(this, geoPoint_);
					float num18 = CurrentSpeed / 3600f * num12;
					if (num17 <= num18)
					{
						flag = true;
						num16 = num18;
					}
				}
				else if (num16 >= 0f)
				{
					if (IsTorpedo && (unit_0.IsSubmarine || (unit_0.DisableWriter() && ((Contact)unit_0).IsSubmergedContact)) && Math.Abs(Math.Abs(GetCurrentAltitude()) - Math.Abs(unit_0.GetCurrentAltitude())) > 15f)
					{
						return false;
					}
					float horizMovementDistanceOnThisTime = unit_0.GetHorizMovementDistanceOnThisTime(num12);
					double double_ = 0.0;
					double double_2 = 0.0;
					Geodesic_EdWilliams.CalcPoint_Williams(unit_0.GetLongitude(), unit_0.GetLatitude(), ref double_, ref double_2, horizMovementDistanceOnThisTime, unit_0.CurrentHeading);
					float num19 = Math2.VerifyClass(GetLatitude(), GetLongitude(), double_2, double_);
					float num20 = Module_Unit.CalcTokenizer(this) / 3600f * num12;
					if (num19 <= num20)
					{
						flag = true;
					}
					else if (num19 - num20 < 0.5f * num12)
					{
						float num21 = 0.1f;
						int num2 = Math.Max((int)Math.Round(num12 / num21), 1);
						float horizMovementDistanceOnThisTime2 = unit_0.GetHorizMovementDistanceOnThisTime(num21);
						float float_ = Module_Unit.CalcTokenizer(this) / 3600f * num21;
						double double_3 = unit_0.GetLatitude();
						double double_4 = unit_0.GetLongitude();
						double double_5 = GetLatitude();
						double double_6 = GetLongitude();
						float num3 = Math2.VerifyClass(double_5, double_6, double_3, double_4);
						int num4 = num2;
						for (int i = 0; i <= num4; i++)
						{
							Geodesic_EdWilliams.CalcPoint_Williams(double_4, double_3, ref double_4, ref double_3, horizMovementDistanceOnThisTime2, unit_0.CurrentHeading);
							Geodesic_EdWilliams.CalcPoint_Williams(double_6, double_5, ref double_6, ref double_5, float_, CurrentHeading);
							float num5 = Math2.VerifyClass(double_5, double_6, double_3, double_4);
							if (num5 <= num3)
							{
								num3 = num5;
								continue;
							}
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						float horizMovementDistanceOnThisTime3 = GetHorizMovementDistanceOnThisTime(num12);
						float float_2 = Math2.PublishClass(GetLatitude(), GetLongitude(), double_2, double_);
						double double_7 = 0.0;
						double double_8 = 0.0;
						Geodesic_EdWilliams.CalcPoint_Williams(GetLongitude(), GetLatitude(), ref double_7, ref double_8, horizMovementDistanceOnThisTime3, float_2);
						float num6 = Math2.VerifyClass(unit_0.GetLatitude(), unit_0.GetLongitude(), double_8, double_7);
						float num7 = Math.Abs((num16 - Module_Unit.CalcTokenizer(this) / 3600f) * num12);
						if (num6 <= num7)
						{
							flag = true;
						}
					}
					if (!flag && bool_0 && num19 <= num16 * num12)
					{
						flag = true;
					}
					if (!flag && SupportsAttitude_Pitch && Attitude_Pitch < -60f)
					{
						float num8 = Module_Unit.RateTokenizer(this, ParentScen);
						if (num12 < 1f)
						{
							num8 *= num12;
						}
						if (GetCurrentAltitude() + num8 <= ImpactAltitude && num19 - num20 < 1f)
						{
							flag = true;
						}
					}
				}
				if (flag)
				{
					if (Warheads.Length != 0 && Warheads[0].IsCluster)
					{
						return true;
					}
					if (base.IsMissile && AI.PrimaryTarget.IsSubmergedContact)
					{
						return true;
					}
					if (base.IsMissile && Warheads.Count() > 0 && (Warheads[0].Type == Warhead.WarheadType.Weapon || Warheads[0].Type == Warhead.WarheadType.Nuclear) && !Module_Unit.ResetTokenizer(this))
					{
						return true;
					}
					if (!SupportsAttitude_Pitch)
					{
						float minimumAltitude = Kinematics.GetMinimumAltitude();
						if (base.IsMissile && ImpactAltitude < minimumAltitude && GetCurrentAltitude() <= minimumAltitude + 25f)
						{
							return true;
						}
						if (ImpactAltitude <= Kinematics.GetMaximumAltitude())
						{
							if (ImpactAltitude < minimumAltitude)
							{
								return false;
							}
							return true;
						}
						return false;
					}
					if ((int)Math.Round(ImpactAltitude) == (int)Math.Round(GetCurrentAltitude()))
					{
						return true;
					}
					double num9 = (double)((num12 - 1f) * num16) * 1852.0;
					if ((double)Math.Abs(ImpactAltitude - GetCurrentAltitude()) < (double)Module_Unit.RangeToUnit_Horiz(this, unit_0) * 1852.0 + num9)
					{
						return true;
					}
					if (GetCurrentAltitude() < ImpactAltitude && (AI.PrimaryTarget.IsLandContact || AI.PrimaryTarget.IsSurfaceContact))
					{
						return true;
					}
					float attitude_Pitch = Attitude_Pitch;
					if ((int)Math.Round(GetCurrentAltitude()) < (int)Math.Round(ImpactAltitude))
					{
						if (DesiredPitch > 0f)
						{
							Attitude_Pitch = DesiredPitch;
						}
						float num10 = Kinematics.ClimbRate_Actual(attitude_Pitch) * num12;
						if (!(num10 * 2f < ImpactAltitude - GetCurrentAltitude()))
						{
							return true;
						}
						if (unit_0.SupportsAttitude_Pitch && unit_0.Attitude_Pitch < 0f)
						{
							float num11 = (float)((double)unit_0.CurrentSpeed * Math2.FillClass(unit_0.Attitude_Pitch) * (double)num12);
							if (num10 - num11 >= ImpactAltitude - GetCurrentAltitude())
							{
								return true;
							}
						}
					}
					else
					{
						if ((int)Math.Round(GetCurrentAltitude()) <= (int)Math.Round(ImpactAltitude))
						{
							return true;
						}
						if (DesiredPitch < 0f)
						{
							Attitude_Pitch = DesiredPitch;
						}
						float num13 = Kinematics.DiveRate_Actual(attitude_Pitch) * num12;
						if (!(num13 * 2f < GetCurrentAltitude() - ImpactAltitude))
						{
							return true;
						}
						if (unit_0.SupportsAttitude_Pitch && unit_0.Attitude_Pitch > 0f)
						{
							float num14 = (float)((double)unit_0.CurrentSpeed * Math2.FillClass(unit_0.Attitude_Pitch) * (double)num12);
							if (num13 + num14 >= GetCurrentAltitude() - ImpactAltitude)
							{
								return true;
							}
						}
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
			exception_?.Data.Add("Error at 100951", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public bool AboutToImpact_Contact(float float_0)
	{
		try
		{
			if (AI.PrimaryTarget == null)
			{
				return false;
			}
			return CalcReponse(AI.PrimaryTarget, float_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100952", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public virtual bool AboutToImpact_ActualTarget(float float_0)
	{
		if (AI.PrimaryTarget == null)
		{
			return false;
		}
		if (AI.PrimaryTarget.ActualUnit == null)
		{
			return false;
		}
		if (AI.PrimaryTarget.GetIsDestroyed(ParentScen))
		{
			return false;
		}
		return CalcReponse(AI.PrimaryTarget.ActualUnit, float_0, bool_0: true);
	}

	private bool RateReponse(Sensor sensor_0)
	{
		if (!sensor_0.IsSonar)
		{
			switch (sensor_0.Type)
			{
			case Sensor.Sensor_Type.LaserDesignator:
			case Sensor.Sensor_Type.LaserSpotTracker:
			case Sensor.Sensor_Type.LaserRangefinder:
				return IsSmokeGrenade;
			case Sensor.Sensor_Type.Radar:
				return IsRadarCountermeasure;
			case Sensor.Sensor_Type.SemiActive:
				if (!Information.IsNothing(sensor_0.ParentPlatform) && !Information.IsNothing(((Weapon)sensor_0.ParentPlatform).SensorProvidingFireControlForMe) && ((Weapon)sensor_0.ParentPlatform).SensorProvidingFireControlForMe.Type == Sensor.Sensor_Type.Radar)
				{
					return IsRadarCountermeasure;
				}
				goto default;
			default:
				return false;
			case Sensor.Sensor_Type.Visual:
				return IsVisualCountermeasure;
			case Sensor.Sensor_Type.Infrared:
				return Boolean_0;
			}
		}
		return IsSonarCountermeasure;
	}

	private bool FlushReponse(ref Weapon weapon_0, ref Sensor sensor_0, ref ActiveUnit activeUnit_0, ref List<string> list_0)
	{
		try
		{
			if (sensor_0.IsNeutralized.GetValueOrDefault())
			{
				return false;
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (sensor_0 == null)
			{
				return false;
			}
			float num = OrderReponse();
			if (weapon_0.AI.PrimaryTarget == null)
			{
				return false;
			}
			float num2 = 0f;
			if (IsRadarCountermeasure && TechGeneration == GlobalVariables.TechGenerationClass.NotApplicable)
			{
				if (weapon_0.AI.PrimaryTarget.ActualUnit != null)
				{
					float num3 = GlobalSingleton.GetInstance().ChaffEffectivnessConstants[sensor_0.TechGeneration].ShipSize[weapon_0.AI.PrimaryTarget.ActualUnit.VisualSizeClass];
					num2 = ((num3 == 0f) ? num : num3);
				}
			}
			else if (TechGeneration == GlobalVariables.TechGenerationClass.NotApplicable)
			{
				num2 = num;
			}
			else if (Boolean_0)
			{
				int num4 = TechGeneration - sensor_0.TechGeneration;
				if (num4 < 0)
				{
					num2 = num - 10f;
				}
				else if (num4 == 0)
				{
					num2 = num;
				}
				else if (num4 > 0)
				{
					num2 = num + 5f;
				}
			}
			else
			{
				int num5 = TechGeneration - sensor_0.TechGeneration;
				if (num5 < -3)
				{
					num2 = num - 15f;
				}
				else if (num5 == -3)
				{
					num2 = num - 10f;
				}
				else if (num5 == -2)
				{
					num2 = num - 5f;
				}
				else if (num5 == -1)
				{
					num2 = num;
				}
				else if (num5 == 0)
				{
					num2 = num;
				}
				else if (num5 == 1)
				{
					num2 = num;
				}
				else if (num5 == 2)
				{
					num2 = num + 5f;
				}
				else if (num5 == 3)
				{
					num2 = num + 10f;
				}
				else if (num5 > 3)
				{
					num2 = num + 15f;
				}
			}
			if (num2 < 0f)
			{
				num2 = 0f;
			}
			stringBuilder.Append("诱饵（" + UnitClass + ";技术：" + Misc.MapRequest(TechGeneration) + "）来自" + activeUnit_0.Name + "试图引诱传感器：" + Misc.ReadRequest(sensor_0.Name) + "（技术：" + Misc.MapRequest(sensor_0.TechGeneration) + "）（引导武器：" + weapon_0.Name + "）。最终概率：" + Conversions.ToString(Math.Round(num2, 2)) + "%. ");
			if (weapon_0.Flags.UsesImagingSeeker)
			{
				stringBuilder.Append("失败：武器使用成像导引头。");
				weapon_0.ParentScen.AddMessage(stringBuilder.ToString(), Misc.ReadRequest(Name) + " 未能欺骗" + Misc.ReadRequest(sensor_0.Name), LoggedMessage.MessageType.WeaponEndgame, 10, ObjectID, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
				if (list_0 != null)
				{
					list_0.Add(stringBuilder.ToString());
				}
				return false;
			}
			int num6 = GameGeneral.LockRandom_0.Next(1, 101);
			string string_;
			bool result;
			if ((float)num6 <= num2)
			{
				stringBuilder.Append("结果：" + Conversions.ToString(num6) + " - 成功");
				string_ = Misc.ReadRequest(Name) + " 被欺骗" + Misc.ReadRequest(sensor_0.Name);
				sensor_0.IsNeutralized = true;
				result = true;
			}
			else
			{
				stringBuilder.Append("结果：" + Conversions.ToString(num6) + " - 失败");
				string_ = Misc.ReadRequest(Name) + " 未能欺骗" + Misc.ReadRequest(sensor_0.Name);
				sensor_0.IsNeutralized = false;
				result = false;
			}
			weapon_0.ParentScen.AddMessage(stringBuilder.ToString(), string_, LoggedMessage.MessageType.WeaponEndgame, 10, ObjectID, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
			if (list_0 != null)
			{
				list_0.Add(stringBuilder.ToString());
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100953", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public bool ResolveDecoyAttempt(ref Weapon weapon_0, ref ActiveUnit activeUnit_0, ref List<string> list_0)
	{
		try
		{
			if (weapon_0.Guidance == WeaponGuidanceType.TVM)
			{
				Sensor sensor_ = weapon_0.SensorProvidingFireControlForMe;
				if (sensor_ == null)
				{
					return false;
				}
				return FlushReponse(ref weapon_0, ref sensor_, ref activeUnit_0, ref list_0);
			}
			Sensor[] sensors = weapon_0._Sensors;
			bool result = false;
			for (int i = 0; i < sensors.Length; i = checked(i + 1))
			{
				Sensor sensor_2 = sensors[i];
				if (sensor_2 != null && RateReponse(sensor_2) && FlushReponse(ref weapon_0, ref sensor_2, ref activeUnit_0, ref list_0))
				{
					result = true;
				}
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100954", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private double ForgotReponse(double double_0)
	{
		if (double_0 > 180.0)
		{
			double_0 = -360.0 + double_0;
		}
		double_0 = Math.Abs(double_0);
		if (double_0 > 90.0)
		{
			double_0 = 180.0 - double_0;
		}
		double num = 0.5;
		return 1.0 - double_0 * num / 90.0;
	}

	public virtual bool ResolveImpact(ActiveUnit activeUnit_0, Scenario scenario_0, bool bool_0, ref List<string> list_0)
	{
		if (this == null)
		{
			return false;
		}
		if (ParentScen.MorituriUnits.Contains(this))
		{
			return false;
		}
		LockRandom lockRandom_ = GameGeneral.LockRandom_0;
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			bool flag2 = false;
			if (HasTerminalGuidance && SensorProvidingFireControlForMe == null && Guidance != WeaponGuidanceType.CommandGuided_Datalinked)
			{
				bool flag3 = false;
				Sensor[] terminalGuidingSensors = TerminalGuidingSensors;
				if (terminalGuidingSensors != null)
				{
					Sensor[] array = terminalGuidingSensors;
					Sensor[] array2 = array;
					foreach (Sensor sensor in array2)
					{
						if (sensor != null && sensor.Status == PlatformComponent._ComponentStatus.Operational)
						{
							flag3 = true;
							break;
						}
					}
				}
				if (!flag3)
				{
					if (IsNuke.Value)
					{
						stringBuilder.Append("武器：" + Name + " has no functioning sensors for terminal guidance... salvage-detonating nuclear warhead.");
						Detonate(AI.PrimaryTarget.GetLatitude(), AI.PrimaryTarget.GetLongitude(), ImpactAltitude, ref lockRandom_, bool_0: true);
					}
					else
					{
						stringBuilder.Append("武器：" + Name + " has no functioning sensors for terminal guidance... clean miss.");
					}
					return false;
				}
			}
			float num = 0f;
			if (activeUnit_0.IsAircraft)
			{
				if (((Aircraft)activeUnit_0).IsAerostat)
				{
					if (!IsAAW)
					{
						bool num12 = Impact_CEP(activeUnit_0, ref scenario_0, ref lockRandom_);
						if (num12)
						{
							ParentScen.DestroyThisUnit(this, "Weapon impacted " + activeUnit_0.Name, "Impact / Detonation");
						}
						else
						{
							ParentScen.DestroyThisUnit(this, "Weapon missed " + activeUnit_0.Name, "Missed");
						}
						return num12;
					}
					num = AirPOK;
				}
				else
				{
					num = AirPOK;
				}
			}
			else if (activeUnit_0.IsWeapon)
			{
				if (!activeUnit_0.IsMissile && (object)activeUnit_0.GetType() != typeof(UnguidedRocket))
				{
					if (!activeUnit_0.IsMobileDecoy_Air && !activeUnit_0.isUAV)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else
					{
						num = AirPOK;
					}
				}
				else
				{
					num = AirPOK;
				}
			}
			else if (activeUnit_0.IsSatellite)
			{
				num = AirPOK;
			}
			else
			{
				if (activeUnit_0.IsShip)
				{
					bool num17 = Impact_CEP(activeUnit_0, ref scenario_0, ref lockRandom_);
					if (num17)
					{
						ParentScen.DestroyThisUnit(this, "Weapon impacted " + activeUnit_0.Name, "Impact / Detonation");
					}
					else
					{
						ParentScen.DestroyThisUnit(this, "Weapon missed " + activeUnit_0.Name, "Missed");
					}
					return num17;
				}
				if (activeUnit_0.IsSubmarine)
				{
					if (activeUnit_0.GetCurrentAltitude() == 0f)
					{
						if (!IsTorpedo)
						{
							bool num18 = Impact_CEP(activeUnit_0, ref scenario_0, ref lockRandom_);
							if (num18)
							{
								ParentScen.DestroyThisUnit(this, "Weapon impacted " + activeUnit_0.Name, "Impact / Detonation");
							}
							else
							{
								ParentScen.DestroyThisUnit(this, "Weapon missed " + activeUnit_0.Name, "Missed");
							}
							return num18;
						}
						num = Math.Max(SubPOK, SurfPOK);
					}
					else
					{
						num = SubPOK;
					}
				}
				else if (activeUnit_0.IsFacility || activeUnit_0.IsMobileGroundUnit)
				{
					bool num19 = Impact_CEP(activeUnit_0, ref scenario_0, ref lockRandom_);
					if (num19)
					{
						ParentScen.DestroyThisUnit(this, "Weapon impacted " + activeUnit_0.Name, "Impact / Detonation");
					}
					else
					{
						ParentScen.DestroyThisUnit(this, "Weapon missed " + activeUnit_0.Name, "Missed");
					}
					return num19;
				}
			}
			string text = (string.IsNullOrEmpty(Name) ? UnitClass : Name);
			if ((float)lockRandom_.Next(1, 101) < num && IsNuke.Value)
			{
				Detonate(AI.PrimaryTarget.GetLatitude(), AI.PrimaryTarget.GetLongitude(), ImpactAltitude, ref lockRandom_, bool_0: true);
				return false;
			}
			if (Type == _WeaponType.Gun)
			{
				stringBuilder.Append("火炮 (" + text + "）正在攻击" + activeUnit_0.Name + " With a base PH Of " + Conversions.ToString(Math.Round(num, 2)) + "%. ");
			}
			else
			{
				string text2 = ((!activeUnit_0.IsAircraft || Operators.CompareString(activeUnit_0.Name, activeUnit_0.UnitClass, TextCompare: false) == 0) ? activeUnit_0.Name : (activeUnit_0.Name + " (" + activeUnit_0.UnitClass + ")"));
				stringBuilder.Append("武器：" + Name + " 正在攻击" + text2 + " 基本PH为" + Conversions.ToString(Math.Round(num, 2)) + "%. ");
			}
			float num8;
			if (activeUnit_0.IsAerospaceUnit)
			{
				if (activeUnit_0.IsBeingDestroyed || activeUnit_0.IsDestroyed)
				{
					return false;
				}
				if ((base.IsMissile || IsGuidedProjectile) && (!activeUnit_0.IsAircraft || !((Aircraft)activeUnit_0).IsAerostat) && Flags.AttitudeControl != WeaponFlags.AttitudeControlEnum.NonAerodynamic)
				{
					if (UsesBoostCoastModel.Value)
					{
						float num20 = CurrentSpeed / (float)Kinematics.GetMaximumSpeed(GetCurrentAltitude());
						float num21 = Kinematics.ConcatDescriptor();
						if (num20 < num21)
						{
							float num22 = num * num20 / num21;
							float num23 = num - num22;
							switch (Flags.AttitudeControl)
							{
							case WeaponFlags.AttitudeControlEnum.Combined:
								num -= num23 / 2f;
								if (float.IsNaN(num))
								{
									num = 0f;
								}
								stringBuilder.Append("PH adjusted for weapon speed: " + Conversions.ToString((int)Math.Round(num)) + "% (combined attitude control). ");
								break;
							case WeaponFlags.AttitudeControlEnum.Aerodynamic:
								num = num22;
								if (float.IsNaN(num))
								{
									num = 0f;
								}
								stringBuilder.Append("PH adjusted for weapon speed: " + Conversions.ToString((int)Math.Round(num)) + "% (pure-aerodynamic attitude control). ");
								break;
							}
						}
					}
					else
					{
						float num2 = Module_Unit.RangeToPoint_Horiz(this, LaunchPoint) / MaxAirRange;
						float num3;
						if (Propulsion.Count <= 0)
						{
							num3 = 0.75f;
						}
						else
						{
							Engine.EngineType type = Propulsion[0].Type;
							num3 = ((type == Engine.EngineType.Rocket_BoostCoast || (uint)(type - 5003) <= 2u) ? 0.5f : 0.75f);
						}
						if (num2 > num3)
						{
							float num4 = num * num3 + num * (1f - num3) * (1f - (num2 - num3) / (1f - num3));
							float num5 = num - num4;
							switch (Flags.AttitudeControl)
							{
							case WeaponFlags.AttitudeControlEnum.Combined:
								num -= num5 / 2f;
								if (float.IsNaN(num))
								{
									num = 0f;
								}
								stringBuilder.Append("PH调整距离：" + Conversions.ToString((int)Math.Round(num)) + "% (combined attitude control). ");
								break;
							case WeaponFlags.AttitudeControlEnum.Aerodynamic:
								num = num4;
								if (float.IsNaN(num))
								{
									num = 0f;
								}
								stringBuilder.Append("PH调整距离：" + Conversions.ToString((int)Math.Round(num)) + "% (pure-aerodynamic attitude control). ");
								break;
							}
						}
					}
				}
				if (!activeUnit_0.IsMissile && MaxTargetSpeed > 0)
				{
					float num6 = 0f;
					if (activeUnit_0.CurrentSpeed <= (float)MaxTargetSpeed)
					{
						if ((double)activeUnit_0.CurrentSpeed <= (double)MaxTargetSpeed * 0.8)
						{
							if ((double)activeUnit_0.CurrentSpeed <= (double)MaxTargetSpeed * 0.7)
							{
								if ((double)activeUnit_0.CurrentSpeed <= (double)MaxTargetSpeed * 0.6)
								{
									if ((double)activeUnit_0.CurrentSpeed > (double)MaxTargetSpeed * 0.5)
									{
										num6 = 5f;
									}
								}
								else
								{
									num6 = 10f;
								}
							}
							else
							{
								num6 = 15f;
							}
						}
						else
						{
							num6 = 25f;
						}
					}
					else
					{
						num6 = 50f;
					}
					if (num6 != 0f)
					{
						num = (int)Math.Round(num - num6);
						if (num < 0f)
						{
							num = 0f;
						}
						stringBuilder.Append("PH调整为实际目标速度（").Append((int)Math.Round(activeUnit_0.CurrentSpeed)).Append(" 节): ")
							.Append(Math.Round(num, 1))
							.Append("%. ");
					}
				}
				if (activeUnit_0.IsAircraft && !((Aircraft)activeUnit_0).IsAerostat && ((Aircraft)activeUnit_0).Crew > 0 && ((Aircraft)activeUnit_0).Agility_Nominal > 0f)
				{
					if (AI.PrimaryTarget.ActualUnit != null && AI.PrimaryTarget.ActualUnit.GetUnitSide().AwakeOrder(this))
					{
						float actualAgility = ((Aircraft)activeUnit_0).Kinematics.GetActualAgility(stringBuilder);
						string string_ = "";
						float num7 = Module_Unit.PrintTokenizer(this, activeUnit_0, bool_0: false, ref string_);
						if (num7 < 345f && num7 > 15f)
						{
							if ((num7 >= 15f && num7 <= 60f) || (num7 <= 345f && num7 >= 300f))
							{
								actualAgility = (float)((double)actualAgility * 0.7);
								stringBuilder.Append("灵敏度调整为向前倾斜冲击效果：" + Conversions.ToString(Math.Round(actualAgility, 1)) + ". ");
							}
							else if ((num7 >= 60f && num7 <= 110f) || (num7 <= 300f && num7 >= 250f))
							{
								actualAgility = actualAgility;
								stringBuilder.Append("高挠度冲击（对敏捷性没有影响）。");
							}
							else if ((num7 >= 110f && num7 <= 165f) || (num7 <= 250f && num7 >= 195f))
							{
								actualAgility = (float)((double)actualAgility * 0.85);
								stringBuilder.Append("灵敏度调整后倾斜冲击效果：" + Conversions.ToString(Math.Round(actualAgility, 1)) + ". ");
							}
							else
							{
								actualAgility = (float)((double)actualAgility * 0.5);
								stringBuilder.Append("灵敏度调整为尾部撞击效果：" + Conversions.ToString(Math.Round(actualAgility, 1)) + ". ");
							}
						}
						else
						{
							actualAgility = (float)((double)actualAgility * 0.6);
							stringBuilder.Append("针对正面碰撞效果调整敏捷度：" + Conversions.ToString(Math.Round(actualAgility, 1)) + ". ");
						}
						actualAgility = (float)Math.Round(actualAgility, 1);
						stringBuilder.Append("最终的敏捷修正： - " + Conversions.ToString((int)Math.Round(actualAgility * 10f)) + "%. ");
						num8 = num - actualAgility * 10f;
					}
					else
					{
						num8 = num;
					}
				}
				else
				{
					num8 = num;
				}
			}
			else
			{
				num8 = num;
			}
			if (activeUnit_0.IsAerospaceUnit && activeUnit_0.GetCurrentAltitude() > 0f && !Flags.CapableVsSeaskimmer)
			{
				double num9 = Math.Round(ManageReponse(activeUnit_0.GetCurrentAltitude()), 2);
				if (num9 > 0.0)
				{
					num8 = (float)((double)num8 - num9);
					stringBuilder.Append("撇水器修正： - " + Conversions.ToString(num9) + "%. ");
				}
			}
			if (activeUnit_0.IsMissile || (object)activeUnit_0.GetType() == typeof(UnguidedRocket))
			{
				num8 = ModifierVsTargetSpeed((int)Math.Round(num8), this, activeUnit_0, stringBuilder);
			}
			if (activeUnit_0.IsAerospaceUnit)
			{
				string string_2 = "";
				float num10 = Module_Unit.PrintTokenizer(this, activeUnit_0, bool_0: false, ref string_2);
				XSection xSection = Sensor.smethod_0(activeUnit_0, XSection._SignatureType.Radar_E_M);
				XSection xSection2 = Sensor.smethod_0(activeUnit_0, XSection._SignatureType.IR_Detect);
				bool flag4 = false;
				if (xSection.isDBInvisible(activeUnit_0) | xSection2.isDBInvisible(activeUnit_0))
				{
					flag4 = true;
				}
				float float_ = 0f;
				float float_2 = 0f;
				if (num10 < 315f && num10 > 45f)
				{
					if ((num10 >= 45f && num10 <= 135f) || (num10 >= 225f && num10 <= 315f))
					{
						float_ = xSection.GetSide(activeUnit_0);
						float_2 = xSection2.GetSide(activeUnit_0);
					}
					else if (num10 >= 135f && num10 <= 225f)
					{
						float_ = xSection.GetRear(activeUnit_0);
						float_2 = xSection2.GetRear(activeUnit_0);
					}
				}
				else
				{
					float_ = xSection.GetFront(activeUnit_0);
					float_2 = xSection2.GetFront(activeUnit_0);
				}
				if (flag4)
				{
					float_ = 0f;
					float_2 = 0f;
				}
				num8 = ModifierVsTargetSignature((int)Math.Round(num8), FiringParent, this, activeUnit_0, TerminalGuidingSensors?.FirstOrDefault(), float_, float_2, stringBuilder);
			}
			if (activeUnit_0.IsAerospaceUnit)
			{
				string string_3 = "";
				float num11 = Module_Unit.PrintTokenizer(this, activeUnit_0, bool_0: false, ref string_3);
				num8 = (float)((double)num8 * ForgotReponse(num11));
				stringBuilder.Append("拦截角度是" + Conversions.ToString((int)Math.Round(num11)) + " 度 - 命中概率调整为" + Conversions.ToString((int)Math.Round(num8)) + "%.");
			}
			if (activeUnit_0.IsMissile && (bool_0 || Module_Unit.RangeToPoint_Horiz(this, LaunchPoint) <= 2f))
			{
				Weapon weapon = (Weapon)activeUnit_0;
				if (weapon.AI.PrimaryTarget != null && Module_Unit.RangeToUnit_Horiz(weapon, weapon.AI.PrimaryTarget) < 2f)
				{
					if (weapon.Flags.TerminalManeuver_PopUp)
					{
						stringBuilder.Append("目标是具有弹出终端操纵杆的导弹 - 命中概率降低25％。");
						num8 = (float)((double)num8 * 0.75);
					}
					else if (weapon.Flags.TerminalManeuver_ZigZag)
					{
						stringBuilder.Append("目标是具有之字形终端的导弹 - 命中率降低了33％。");
						num8 = (float)((double)num8 * 0.66);
					}
					else if (weapon.Flags.TerminalManeuver_Random)
					{
						stringBuilder.Append("目标是具有随机终端管理的导弹 - 命中概率降低50％。");
						num8 = (float)((double)num8 * 0.5);
					}
				}
			}
			if (activeUnit_0.IsTorpedo)
			{
				stringBuilder.Append("目标是鱼雷 - 命中概率减半。");
				num8 = (float)((double)num8 * 0.5);
			}
			if (num8 < 0f)
			{
				num8 = 1f;
			}
			stringBuilder.Append("最终PH：" + Conversions.ToString((int)Math.Round(num8)) + "%. ");
			int num13 = lockRandom_.Next(1, 101);
			if ((float)num13 <= num8)
			{
				stringBuilder.Append("结果：" + Conversions.ToString(num13) + " - 命中");
				flag = true;
			}
			else
			{
				stringBuilder.Append("结果：" + Conversions.ToString(num13));
				if (Flags.ReAttack_Capability)
				{
					float num14 = num8 / 4f;
					if ((float)lockRandom_.Next(1, 101) < num14)
					{
						stringBuilder.Append(" - 未命中 - 不重新攻击（DUD）");
					}
					else
					{
						stringBuilder.Append(" - 未命中 - 重新攻击");
						PrepareForReattack(activeUnit_0);
						flag2 = true;
					}
				}
				else
				{
					stringBuilder.Append(" - 未命中");
					if (Warheads.Length != 0 && activeUnit_0.IsFacility && Warheads[0].IsExplosive)
					{
						float num15 = 0f;
						num15 = lockRandom_.Next(0, 359);
						float num16 = lockRandom_.Next(1, 50);
						stringBuilder.Append("（接近命中：" + Conversions.ToString(num16) + "m)");
						ActiveUnit_Damage damage = activeUnit_0.Damage;
						GeoPoint launchPoint = LaunchPoint;
						float float_3 = num15;
						string string_4 = "";
						damage.ResolveDamageFromWeapon(this, launchPoint, num16, float_3, null, null, null, null, ref string_4, bool_0: false);
					}
				}
			}
			string string_5 = (flag ? (Misc.ReadRequest(Name) + " 命中" + activeUnit_0.Name) : (Misc.ReadRequest(Name) + "错过" + activeUnit_0.Name));
			activeUnit_0.ParentScen.AddMessage(stringBuilder.ToString(), string_5, LoggedMessage.MessageType.WeaponEndgame, 10, ObjectID, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
			if (list_0 != null)
			{
				list_0.Add(stringBuilder.ToString());
			}
			if (flag)
			{
				Impact(activeUnit_0, stringBuilder);
			}
			else
			{
				ExportResolveImpactEvent(activeUnit_0, bool_0: false, bool_1: false, stringBuilder);
			}
			if (flag || !flag2)
			{
				ParentScen.DestroyThisUnit(this, "Weapon has been destroyed though interaction with " + activeUnit_0.Name + ", export WeaponEndgame data for more information.", "Impact / Detonation");
			}
			return flag;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100955", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public void ExportResolveImpactEvent(Module_Unit.Unit unit_0, bool bool_0, bool bool_1, StringBuilder stringBuilder_0)
	{
		try
		{
			foreach (IEventExporter applicableEventExporter in ParentScen.ApplicableEventExporters)
			{
				if (!applicableEventExporter.IsOperating || !applicableEventExporter.ExportWeaponEndgame)
				{
					continue;
				}
				Dictionary<string, IEventExporter.EventNotificationParameter> dictionary = new Dictionary<string, IEventExporter.EventNotificationParameter>(30);
				if (ParentScen.MonteCarloIteration > 0)
				{
					dictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(ParentScen.Title, typeof(string), 500));
					dictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(ParentScen.MonteCarloIteration, typeof(int)));
				}
				dictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(ParentScen.TimelineID, typeof(string), 40));
				if (applicableEventExporter.UseZeroHour)
				{
					dictionary.Add("Time", new IEventExporter.EventNotificationParameter(ParentScen.Time.Subtract(ParentScen.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				else
				{
					dictionary.Add("Time", new IEventExporter.EventNotificationParameter(ParentScen.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + ParentScen.Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				dictionary.Add("WeaponID", new IEventExporter.EventNotificationParameter(ObjectID, typeof(string), 40));
				dictionary.Add("WeaponName", new IEventExporter.EventNotificationParameter(Name, typeof(string), 500));
				dictionary.Add("WeaponSide", new IEventExporter.EventNotificationParameter(GetUnitSide().Name, typeof(string), 500));
				if (FiringParent == null)
				{
					dictionary.Add("ParentFiringUnitID", new IEventExporter.EventNotificationParameter("-", typeof(string), 40));
					dictionary.Add("ParentFiringUnitName", new IEventExporter.EventNotificationParameter("-", typeof(string), 500));
				}
				else
				{
					dictionary.Add("ParentFiringUnitID", new IEventExporter.EventNotificationParameter(FiringParent.ObjectID, typeof(string), 40));
					dictionary.Add("ParentFiringUnitName", new IEventExporter.EventNotificationParameter(FiringParent.Name, typeof(string), 500));
				}
				if (unit_0 == null)
				{
					dictionary.Add("TargetID", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					dictionary.Add("TargetName", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					dictionary.Add("TargetSide", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
					dictionary.Add("TargetLongitude", new IEventExporter.EventNotificationParameter(string.Empty, typeof(double)));
					dictionary.Add("TargetLatitude", new IEventExporter.EventNotificationParameter(string.Empty, typeof(double)));
					dictionary.Add("TargetAltitude_ASL_m", new IEventExporter.EventNotificationParameter(string.Empty, typeof(float)));
					dictionary.Add("TargetAltitude_AGL_m", new IEventExporter.EventNotificationParameter(string.Empty, typeof(float)));
				}
				else
				{
					dictionary.Add("TargetID", new IEventExporter.EventNotificationParameter(unit_0.ObjectID, typeof(string), 40));
					dictionary.Add("TargetName", new IEventExporter.EventNotificationParameter(unit_0.Name, typeof(string), 500));
					if (Information.IsNothing(unit_0.GetUnitSide()))
					{
						dictionary.Add("TargetSide", new IEventExporter.EventNotificationParameter("-", typeof(string), 500));
					}
					else
					{
						dictionary.Add("TargetSide", new IEventExporter.EventNotificationParameter(unit_0.GetUnitSide().Name, typeof(string), 500));
					}
					dictionary.Add("TargetLongitude", new IEventExporter.EventNotificationParameter(unit_0.GetLongitude(), typeof(double)));
					dictionary.Add("TargetLatitude", new IEventExporter.EventNotificationParameter(unit_0.GetLatitude(), typeof(double)));
					dictionary.Add("TargetAltitude_ASL_m", new IEventExporter.EventNotificationParameter(unit_0.GetCurrentAltitude(), typeof(float)));
					dictionary.Add("TargetAltitude_AGL_m", new IEventExporter.EventNotificationParameter(unit_0.CurrentAltitude_AGL, typeof(float)));
				}
				dictionary.Add("DistanceFromFiringUnit_Horiz", new IEventExporter.EventNotificationParameter(Conversions.ToString(Interaction.IIf(FiringParent != null, Module_Unit.RangeToUnit_Horiz(this, FiringParent), "")), typeof(float)));
				if (bool_0)
				{
					if (bool_1)
					{
						dictionary.Add("Result", new IEventExporter.EventNotificationParameter("KILL", typeof(string), 10));
					}
					else
					{
						dictionary.Add("Result", new IEventExporter.EventNotificationParameter("HIT", typeof(string), 10));
					}
				}
				else
				{
					dictionary.Add("Result", new IEventExporter.EventNotificationParameter("MISS", typeof(string), 10));
				}
				if (Information.IsNothing(stringBuilder_0))
				{
					dictionary.Add("EndgameMessage", new IEventExporter.EventNotificationParameter("-", typeof(string)));
				}
				else
				{
					dictionary.Add("EndgameMessage", new IEventExporter.EventNotificationParameter(Strings.Trim(stringBuilder_0.ToString()), typeof(string)));
				}
				applicableEventExporter.ExportEvent(IEventExporter.ExportedEventType.WeaponEndgame, dictionary, ParentScen);
			}
			ISimConnector[] activeSimConnectors = SimConnect_General.ActiveSimConnectors;
			ISimConnector[] array = activeSimConnectors;
			foreach (ISimConnector simConnector in array)
			{
				if (!simConnector.ExportWeaponImpactOrDetonation)
				{
					continue;
				}
				Dictionary<string, Tuple<Type, string>> dictionary2 = new Dictionary<string, Tuple<Type, string>>();
				dictionary2.Add("TimelineID", new Tuple<Type, string>(typeof(string), ParentScen.TimelineID));
				dictionary2.Add("Time", new Tuple<Type, string>(typeof(DateTime), ParentScen.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + ParentScen.Time.Millisecond.ToString("D3")));
				dictionary2.Add("Longitude", new Tuple<Type, string>(typeof(double), Conversions.ToString(GetLongitude())));
				dictionary2.Add("Latitude", new Tuple<Type, string>(typeof(double), Conversions.ToString(GetLatitude())));
				dictionary2.Add("Altitude", new Tuple<Type, string>(typeof(float), Conversions.ToString(GetCurrentAltitude())));
				dictionary2.Add("WeaponID", new Tuple<Type, string>(typeof(string), ObjectID));
				dictionary2.Add("WeaponDBID", new Tuple<Type, string>(typeof(string), Conversions.ToString(DBID)));
				dictionary2.Add("WeaponCourse", new Tuple<Type, string>(typeof(string), CurrentHeading.ToString()));
				dictionary2.Add("WeaponSpeed_Horiz", new Tuple<Type, string>(typeof(string), Module_Unit.CalcTokenizer(this).ToString()));
				dictionary2.Add("WeaponSpeed_Vert", new Tuple<Type, string>(typeof(string), Module_Unit.RateTokenizer(this, ParentScen).ToString()));
				if (FiringParent != null)
				{
					dictionary2.Add("FiringUnitID", new Tuple<Type, string>(typeof(string), FiringParent.ObjectID));
				}
				if (!Information.IsNothing(unit_0))
				{
					dictionary2.Add("TargetID", new Tuple<Type, string>(typeof(string), unit_0.ObjectID));
				}
				if (bool_0)
				{
					if (bool_1)
					{
						dictionary2.Add("Result", new Tuple<Type, string>(typeof(string), "KILL"));
					}
					else
					{
						dictionary2.Add("Result", new Tuple<Type, string>(typeof(string), "HIT"));
					}
				}
				else
				{
					dictionary2.Add("Result", new Tuple<Type, string>(typeof(string), "MISS"));
				}
				dictionary2.Add("EventType", new Tuple<Type, string>(typeof(string), "WeaponImpact"));
				simConnector.ExportInfo(ISimConnector.ExportedInfoType.WeaponImpactOrDetonation, dictionary2, ParentScen);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101329", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static bool CheckForDirectHit(ActiveUnit activeUnit_0, double double_0, double double_1, float float_0, GeoPoint geoPoint_0, float float_1, bool bool_0)
	{
		try
		{
			if (activeUnit_0.IsShip)
			{
				if (((Ship)activeUnit_0).Length / 2f < float_0)
				{
					return false;
				}
				Geopoint_Struct[] rectangularArea = Math2.GetRectangularArea(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), ((Ship)activeUnit_0).Length, ((Ship)activeUnit_0).Beam, activeUnit_0.CurrentHeading);
				if (GeoPoint.IsInsideThisArea(double_0, double_1, rectangularArea))
				{
					return true;
				}
				return false;
			}
			if (activeUnit_0.IsSubmarine)
			{
				if (((Submarine)activeUnit_0).Length / 2f < float_0)
				{
					return false;
				}
				if (!(((Submarine)activeUnit_0).Length / 2f <= float_0) && ((Submarine)activeUnit_0).Beam / 2f > float_0)
				{
					return true;
				}
				Geopoint_Struct[] rectangularArea2 = Math2.GetRectangularArea(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), ((Submarine)activeUnit_0).Length, ((Submarine)activeUnit_0).Beam, activeUnit_0.CurrentHeading);
				if (GeoPoint.IsInsideThisArea(double_0, double_1, rectangularArea2))
				{
					return true;
				}
				return false;
			}
			if (activeUnit_0.IsFacility)
			{
				if (((Facility)activeUnit_0).HasAimpoints)
				{
					return (int)Math.Round(float_0) <= 4;
				}
				if (Math.Max(((Facility)activeUnit_0).Length, ((Facility)activeUnit_0).Width) / 2f < float_0)
				{
					return false;
				}
				Geopoint_Struct[] rectangularArea3 = Math2.GetRectangularArea(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), ((Facility)activeUnit_0).Length, ((Facility)activeUnit_0).Width, activeUnit_0.CurrentHeading);
				if (GeoPoint.IsInsideThisArea(double_0, double_1, rectangularArea3))
				{
					return true;
				}
				return false;
			}
			if (activeUnit_0.IsMobileGroundUnit)
			{
				if (activeUnit_0.Length < float_0)
				{
					return false;
				}
				return true;
			}
			if (activeUnit_0.IsAircraft && ((Aircraft)activeUnit_0).IsAerostat)
			{
				if (((Aircraft)activeUnit_0).Length / 2f < float_0)
				{
					return false;
				}
				Geopoint_Struct[] rectangularArea4 = Math2.GetRectangularArea(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), ((Aircraft)activeUnit_0).Length, ((Aircraft)activeUnit_0).Span, activeUnit_0.CurrentHeading);
				if (GeoPoint.IsInsideThisArea(double_0, double_1, rectangularArea4))
				{
					return true;
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100957", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public static void RaiseEvent_WeaponImpact(Scenario scenario_0, Weapon weapon_0, Module_Unit.Unit unit_0, bool bool_0)
	{
		reponseReader?.Invoke(scenario_0, weapon_0, unit_0, bool_0);
	}

	internal float CollectReponse(ref ActiveUnit activeUnit_0)
	{
		if (activeUnit_0 == null)
		{
			return 0f;
		}
		if (!activeUnit_0.IsShip && (!activeUnit_0.IsSubmarine || !((Submarine)activeUnit_0).IsSurfaced))
		{
			if (activeUnit_0.IsAircraft && ((Aircraft)activeUnit_0).IsAerostat)
			{
				return Math.Max(AirPOK, SurfPOK);
			}
			if (activeUnit_0.IsFacility && ((Facility)activeUnit_0).Category == Facility._FacilityCategory.Water_Surface)
			{
				return Math.Max(SurfPOK, LandPOK);
			}
			if (!activeUnit_0.IsFacility && !activeUnit_0.IsMobileGroundUnit)
			{
				if (!activeUnit_0.IsSubmarine && !activeUnit_0.IsTorpedo)
				{
					return 0f;
				}
				return SubPOK;
			}
			return LandPOK;
		}
		return SurfPOK;
	}

	internal float OrderReponse()
	{
		return Math.Max(AirPOK, Math.Max(SurfPOK, Math.Max(LandPOK, SubPOK)));
	}

	protected bool Impact_CEP(ActiveUnit activeUnit_0, ref Scenario scenario_0, ref LockRandom lockRandom_0)
	{
		try
		{
			scenario_0.DestroyThisUnit(this, "Weapon has been destroyed though interaction with " + activeUnit_0.Name + ", export WeaponEndgame data for more information.", "Impact / Detonation");
			float num = CollectReponse(ref activeUnit_0);
			bool flag = (float)lockRandom_0.Next(1, 101) < num;
			string text = "";
			bool flag2 = false;
			float float_ = 0f;
			float float_2 = 0f;
			if (Impact_CEP_MissDistanceAndDirection(activeUnit_0, ref scenario_0, ref float_, ref float_2, ref lockRandom_0))
			{
				double double_ = 0.0;
				double double_2 = 0.0;
				double double_3 = 0.0;
				double double_4 = 0.0;
				if (Guidance == WeaponGuidanceType.Inertial)
				{
					if (Navigator.HasNonPathfindPlottedCourse())
					{
						double_ = Navigator.PlottedCourse[Navigator.PlottedCourse.Count() - 1].Latitude;
						double_2 = Navigator.PlottedCourse[Navigator.PlottedCourse.Count() - 1].Longitude;
						double_3 = double_;
						double_4 = double_2;
					}
				}
				else if (Module_ActiveUnit.CancelTokenizer(activeUnit_0))
				{
					Mount mount;
					if (ARM_SpecifiedEMission.Value == null)
					{
						mount = ((Facility)activeUnit_0).PickRandomAimpoint();
					}
					else
					{
						List<Mount> list = new List<Mount>();
						List<Mount> list2 = new List<Mount>();
						foreach (Mount mount2 in activeUnit_0.Mounts)
						{
							Sensor[] sensors_ReadOnly = mount2.Sensors_ReadOnly;
							Sensor[] array = sensors_ReadOnly;
							foreach (Sensor sensor in array)
							{
								if (sensor.DBID == ARM_SpecifiedEMission.Key || sensor.classFacade == ARM_SpecifiedEMission.Key)
								{
									list.Add(mount2);
									if (sensor.IsActive)
									{
										list2.Add(mount2);
									}
								}
							}
						}
						mount = ((list2.Count > 0) ? list2[lockRandom_0.Next(0, list2.Count)] : ((list.Count <= 0) ? ((Facility)activeUnit_0).PickRandomAimpoint() : list[lockRandom_0.Next(0, list.Count)]));
					}
					if (mount == null)
					{
						if (AI.PrimaryTarget.Age == 0f && AI.PrimaryTarget.ActualUnit != null)
						{
							double_ = AI.PrimaryTarget.ActualUnit.GetLatitude();
							double_2 = AI.PrimaryTarget.ActualUnit.GetLongitude();
						}
						else
						{
							double_ = AI.PrimaryTarget.GetLatitude();
							double_2 = AI.PrimaryTarget.GetLongitude();
						}
					}
					else
					{
						Geodesic_EdWilliams.CalcPoint_Williams(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude(), ref double_2, ref double_, mount.AimpointOffset_Distance / 1852f, mount.AimpointOffset_Bearing);
						double_3 = double_;
						double_4 = double_2;
					}
				}
				else if (AI.PrimaryTarget.Age == 0f && AI.PrimaryTarget.ActualUnit != null)
				{
					double_ = AI.PrimaryTarget.ActualUnit.GetLatitude();
					double_2 = AI.PrimaryTarget.ActualUnit.GetLongitude();
				}
				else
				{
					double_ = AI.PrimaryTarget.GetLatitude();
					double_2 = AI.PrimaryTarget.GetLongitude();
				}
				double double_5 = 0.0;
				double double_6 = 0.0;
				Geodesic_EdWilliams.CalcPoint_Williams(double_2, double_, ref double_5, ref double_6, float_ / 1852f, float_2);
				float num2 = (Module_ActiveUnit.CancelTokenizer(activeUnit_0) ? (Math2.VerifyClass(double_6, double_5, double_3, double_4) * 1852f) : (Math2.VerifyClass(double_6, double_5, activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude()) * 1852f));
				float float_3 = Math2.PublishClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), double_6, double_5);
				bool flag3;
				if ((flag3 = !Warheads[0].GetIsAirburst(this, activeUnit_0) && CheckForDirectHit(activeUnit_0, double_6, double_5, num2, LaunchPoint, MaxRange_NoTargetType, bool_0: false)) && !Flags.Fuze_ShockFactor_Under_Keel_Optimized)
				{
					reponseReader?.Invoke(ParentScen, this, activeUnit_0, DirectHit: false);
				}
				if (Warheads.Length != 0 && Warheads[0].IsCluster)
				{
					if (flag)
					{
						float float_4 = Math.Max(0, (int)Terrain.GetElevation(double_6, double_5, bool_0: false, scenario_0)) + GetOptimumBurstHeight_AGL(activeUnit_0);
						Warhead[] warheads = Warheads;
						Warhead[] array2 = warheads;
						foreach (Warhead warhead in array2)
						{
							if (warhead.IsCluster)
							{
								new Explosion(ref scenario_0, double_5, double_6, double_5, double_6, CurrentHeading, float_4, Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, null, null, warhead.ClusterBombDispersionAreaLength, warhead.ClusterBombDispersionAreaWidth, warhead.NumberOfWarheads).CurrentHeading = CurrentHeading;
							}
						}
						text = ((!((double)num2 < 926.0)) ? ("武器：" + Name + "错过" + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Round(num2 / 1852f, 1)) + "海里，配发子弹药......") : (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? ("武器：" + Name + "错过" + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Max(1, (int)Math.Round(num2 * 3.28084f))) + "英尺，分发子弹药......") : ("武器：" + Name + "错过" + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Max(1, (int)Math.Round(num2))) + "米，配发子弹药......")));
						scenario_0.AddMessage(text, Name + " 正引爆", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
					}
					else
					{
						text = "武器：" + Name + "发生故障。";
						scenario_0.AddMessage(text, "武器故障", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(double_5, double_6));
					}
					return false;
				}
				if (Warheads[0].IsExplosive)
				{
					if (flag)
					{
						if (flag3)
						{
							if (Warheads[0].GetIsAirburst(this, activeUnit_0))
							{
								if (base.IsMissile && IsAAW && (activeUnit_0.IsShip || activeUnit_0.IsFacility))
								{
									if ((int)activeUnit_0.VisualSizeClass <= 1)
									{
										text = "武器：" + Name + "直接在空中爆炸在" + activeUnit_0.Name;
										scenario_0.AddMessage(text, "武器命中", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
										ActiveUnit_Damage damage = activeUnit_0.Damage;
										GeoPoint launchPoint = LaunchPoint;
										string string_ = "";
										damage.ResolveDamageFromWeapon(this, launchPoint, num2, float_3, null, null, null, null, ref string_, flag3);
									}
									else
									{
										Impact(activeUnit_0, null);
										flag2 = true;
									}
								}
								else
								{
									text = "武器：" + Name + "直接在空中爆炸在" + activeUnit_0.Name;
									scenario_0.AddMessage(text, "武器命中", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
									ActiveUnit_Damage damage2 = activeUnit_0.Damage;
									GeoPoint launchPoint2 = LaunchPoint;
									string string_2 = "";
									damage2.ResolveDamageFromWeapon(this, launchPoint2, num2, float_3, null, null, null, null, ref string_2, flag3);
								}
							}
							else if (Flags.Fuze_ShockFactor_Under_Keel_Optimized && activeUnit_0.IsShip)
							{
								text = "武器：" + Name + " detonated directly under target: " + activeUnit_0.Name;
								double latitude = activeUnit_0.GetLatitude();
								double longitude = activeUnit_0.GetLongitude();
								float float_5 = 0f - (((Ship)activeUnit_0).Draft + 10f);
								LockRandom lockRandom_ = GameGeneral.LockRandom_0;
								Detonate(latitude, longitude, float_5, ref lockRandom_, bool_0: true);
							}
							else
							{
								Impact(activeUnit_0, null);
								flag2 = true;
							}
						}
						else
						{
							if (!Module_ActiveUnit.CancelTokenizer(activeUnit_0))
							{
								if (Warheads[0].GetIsAirburst(this, activeUnit_0))
								{
									string text2 = "空中爆炸";
									if (IsUnderwater || IsUnderground || CurrentAltitude_AGL == 0f)
									{
										text2 = "错过";
									}
									text = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? ("武器：" + Name + text2 + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Max(1, (int)Math.Round(num2 * 3.28084f))) + "ft") : ("武器：" + Name + text2 + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Max(1, (int)Math.Round(num2))) + "m"));
									scenario_0.AddMessage(text, "武器未命中", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
								}
								else
								{
									text = ((!(num2 < 926f)) ? ("武器：" + Name + "错过" + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Round(num2 / 1852f, 1)) + "nm") : (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? ("武器：" + Name + "错过" + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Max(1, (int)Math.Round(num2 * 3.28084f))) + "ft") : ("武器：" + Name + "错过" + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Max(1, (int)Math.Round(num2))) + "m")));
									scenario_0.AddMessage(text, "武器未命中", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
								}
							}
							if ((IsTorpedo ? GetCurrentAltitude() : ImpactAltitude) >= 0f || Warheads[0].GetIsNuclear(ParentScen) || IsTorpedo || (Warheads[0].GetIsAirburst(this, activeUnit_0) ? true : false))
							{
								if (Warheads[0].GetIsAirburst(this, activeUnit_0))
								{
									double double_7 = double_6;
									double double_8 = double_5;
									float impactAltitude = ImpactAltitude;
									LockRandom lockRandom_2 = GameGeneral.LockRandom_0;
									Detonate(double_7, double_8, impactAltitude, ref lockRandom_2, bool_0: true);
									flag2 = true;
								}
								else
								{
									ActiveUnit_Damage damage3 = activeUnit_0.Damage;
									GeoPoint launchPoint3 = LaunchPoint;
									float num3 = 0f;
									float float_6 = num2 - num3;
									string string_3 = "";
									damage3.ResolveDamageFromWeapon(this, launchPoint3, float_6, float_3, null, null, null, null, ref string_3, flag3);
								}
							}
						}
					}
					else
					{
						text = "武器：" + Name + "发生故障。";
						scenario_0.AddMessage(text, "武器故障", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(double_5, double_6));
					}
				}
				else if (flag)
				{
					if (flag)
					{
						if (flag3)
						{
							Impact(activeUnit_0, null);
							flag2 = true;
						}
						else if (Warheads[0].GetIsAirburst(this, activeUnit_0))
						{
							text = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? ("武器：" + Name + "空中爆炸" + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Max(1, (int)Math.Round(num2 * 3.28084f))) + "ft") : ("武器：" + Name + "空中爆炸" + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Max(1, (int)Math.Round(num2))) + "m"));
							scenario_0.AddMessage(text, "武器空中爆炸", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						}
						else
						{
							text = ((num2 <= 926f) ? ("武器：" + Name + "错过" + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Round(num2 / 1852f, 1)) + "nm") : (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? ("武器：" + Name + "错过" + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Max(1, (int)Math.Round(num2 * 3.28084f))) + "ft") : ("武器：" + Name + "错过" + activeUnit_0.Name + "通过" + Conversions.ToString(Math.Max(1, (int)Math.Round(num2))) + "m")));
							scenario_0.AddMessage(text, "武器未命中", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						}
					}
					else
					{
						text = "武器：" + Name + "发生故障。";
						scenario_0.AddMessage(text, "武器故障", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(double_5, double_6));
					}
				}
				else
				{
					scenario_0.AddMessage("武器：" + Name + "发生故障。", "武器故障", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(double_5, double_6));
				}
				if (!flag2)
				{
					ExportResolveImpactEvent(activeUnit_0, bool_0: false, bool_1: false, new StringBuilder(text));
				}
				return flag3;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100958", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public bool Impact_CEP_MissDistanceAndDirection(ActiveUnit activeUnit_0, ref Scenario scenario_0, ref float float_0, ref float float_1, ref LockRandom lockRandom_0)
	{
		try
		{
			float num = ((activeUnit_0 == null) ? ((float)Math.Max(CEP_Land, CEP_Surface)) : (activeUnit_0.IsFacility ? ((float)CEP_Land) : ((float)CEP_Surface)));
			if (Guidance == WeaponGuidanceType.Inertial && activeUnit_0 != null)
			{
				if (Navigator.HasPlottedCourse())
				{
					Waypoint waypoint = Navigator.PlottedCourse.Last();
					double num2 = Geodesic_Haversine.Distance_Horiz_Approx_nm(waypoint.Latitude, waypoint.Longitude, activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude());
					double num3 = 0.01 + (double)(CurrentSpeed / 3600f * 1.1f);
					if (num2 > num3)
					{
						return false;
					}
				}
				float num4 = activeUnit_0.Kinematics.GetMaximumSpeed(activeUnit_0.GetCurrentAltitude(), Throttle.Flank, bool_0: false);
				float num5 = ((num4 <= 0f) ? 0f : (activeUnit_0.CurrentSpeed / num4));
				num = (activeUnit_0.IsFacility ? ((float)CEP_Land + (float)CEP_Land * num5) : ((float)CEP_Surface + (float)CEP_Surface * num5));
			}
			if (ValidTargets.Radar)
			{
				if (ARM_SpecifiedEMission.Value == null)
				{
					if (!IsDualModeARM && !isLoiterCapable)
					{
						scenario_0.AddMessage("武器：" + Name + "没有发射锁定，没有替代传感器....完全未命中。", Name + " 完全未命中", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						return false;
					}
				}
				else
				{
					if (ARM_SpecifiedEMission.Value.Age > 1f)
					{
						if (Flags.ARMTargetMemory)
						{
							num = Math.Min(num * 5f, num + ARM_SpecifiedEMission.Value.Age * 100f);
						}
						else
						{
							float num6 = Math.Min(ARM_SpecifiedEMission.Value.Age, (float)Fuel_ReadOnly[0].MaxQuantity - Fuel_ReadOnly[0].CurrentQuantity);
							num += num6 * 20f;
						}
					}
					int key = ARM_SpecifiedEMission.Key;
					SQLiteConnection sqliteConnection_ = ParentScen.DBConnection;
					Sensor sensor = DBFunctions.GetSensor(key, ref sqliteConnection_);
					float num7 = 1f;
					Sensor.FrequencyBand frequencyBand = Sensor.FrequencyBand.A_Band;
					Sensor.RadioElectronicFrequency[] searchFreqs = sensor.SearchFreqs;
					Sensor.RadioElectronicFrequency[] array = searchFreqs;
					foreach (Sensor.RadioElectronicFrequency radioElectronicFrequency in array)
					{
						if (Conversion.Int((long)radioElectronicFrequency.Band) > 1001 && Conversion.Int((long)radioElectronicFrequency.Band) <= 1013 && Conversion.Int((long)radioElectronicFrequency.Band) > Conversion.Int((long)frequencyBand))
						{
							frequencyBand = radioElectronicFrequency.Band;
						}
					}
					switch (frequencyBand)
					{
					case Sensor.FrequencyBand.B_Band:
						num7 = 1.2f;
						break;
					case Sensor.FrequencyBand.A_Band:
						num7 = 1.6f;
						break;
					}
					num *= num7;
				}
			}
			float_1 = (float)(lockRandom_0.NextDouble() * 359.99);
			double num8 = lockRandom_0.NextDouble();
			if (num8 <= 0.5)
			{
				float_0 = (float)((double)lockRandom_0.Next(0, 101) / 100.0 * (double)num);
			}
			else if (num8 < 0.937)
			{
				float_0 = (float)((double)num + (double)num * lockRandom_0.NextDouble());
			}
			else
			{
				float_0 = (float)((double)(2f * num) + (double)num * lockRandom_0.NextDouble());
			}
			if (ARM_SpecifiedEMission.Value != null && activeUnit_0 != null && activeUnit_0.CurrentSpeed > 0f && ARM_SpecifiedEMission.Value.Age > 1f)
			{
				float_0 += ARM_SpecifiedEMission.Value.Age / 3600f * activeUnit_0.CurrentSpeed * 1852f;
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101339", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public bool IsGuidedOrUnguidedGun()
	{
		_WeaponType type = Type;
		if (type != _WeaponType.Gun && type != _WeaponType.GuidedProjectile)
		{
			return false;
		}
		return true;
	}

	public void Impact(ActiveUnit activeUnit_0, StringBuilder stringBuilder_0)
	{
		try
		{
			if (stringBuilder_0 == null)
			{
				stringBuilder_0 = new StringBuilder();
			}
			else
			{
				stringBuilder_0.Append("\r\n");
			}
			string text = "";
			bool bool_ = false;
			if (!IsDecoy)
			{
				reponseReader?.Invoke(ParentScen, this, activeUnit_0, DirectHit: true);
				new WeaponImpact(ref activeUnit_0.ParentScen, activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude(), activeUnit_0.GetCurrentAltitude(), Command_Core.WeaponImpact.ImpactType.Kinetic, DBID);
			}
			if (IsNuke.Value)
			{
				double latitude = GetLatitude();
				double longitude = GetLongitude();
				float currentAltitude = GetCurrentAltitude();
				LockRandom lockRandom_ = GameGeneral.LockRandom_0;
				Detonate(latitude, longitude, currentAltitude, ref lockRandom_, bool_0: true);
				return;
			}
			if (!activeUnit_0.IsAircraft && !activeUnit_0.IsWeapon)
			{
				if (activeUnit_0.IsFacility)
				{
					if (!((Facility)activeUnit_0).HasAimpoints)
					{
						text = "武器：" + Name + "毁伤了" + activeUnit_0.Name + ". ";
					}
				}
				else
				{
					text = "武器：" + Name + "毁伤了" + activeUnit_0.Name + ". ";
				}
			}
			if (activeUnit_0.IsWeapon)
			{
				Weapon weapon = (Weapon)activeUnit_0;
				if (weapon.IsReEntryVehicle || weapon.IsBallisticMissile)
				{
					switch (Warheads[0].Type)
					{
					default:
					{
						text += "常规弹头：直接破坏的几率为15％，显著偏差的几率为30％。";
						int num3 = GameGeneral.LockRandom_0.Next(1, 101);
						int num4 = num3;
						if (num4 <= 15)
						{
							text = text + "结果：" + Conversions.ToString(num3) + "。目标被彻底摧毁。";
							bool_ = true;
						}
						else if (num4 <= 30)
						{
							text = text + "结果：" + Conversions.ToString(num3) + "。显著的轨迹偏差（目标武器的CEP增加三倍）。";
							weapon.CEP_Land *= 3;
							weapon.CEP_Surface *= 3;
							activeUnit_0.ParentScen.AddMessage(text, Name + " 命中" + activeUnit_0.Name + " - major deflection", LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
							bool_ = false;
						}
						else
						{
							text = text + "结果：" + Conversions.ToString(num3) + "。较小的轨迹偏差（目标武器的CEP乘以1.5）。";
							weapon.CEP_Land = (int)Math.Round((double)weapon.CEP_Land * 1.5);
							weapon.CEP_Surface = (int)Math.Round((double)weapon.CEP_Surface * 1.5);
							activeUnit_0.ParentScen.AddMessage(text, Name + " 命中" + activeUnit_0.Name + " - minor deflection", LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
							bool_ = false;
						}
						break;
					}
					case Warhead.WarheadType.Fragmentation_ABM:
					{
						text += "ABM优化的碎片弹头：彻底破坏的几率为30％，显著偏差的几率为60％。";
						int num = GameGeneral.LockRandom_0.Next(1, 101);
						int num2 = num;
						if (num2 <= 30)
						{
							text = text + "结果：" + Conversions.ToString(num) + "。目标被彻底摧毁。";
							bool_ = true;
						}
						else if (num2 <= 60)
						{
							text = text + "结果：" + Conversions.ToString(num) + "。显著的轨迹偏差（目标武器的CEP增加三倍）。";
							weapon.CEP_Land *= 3;
							weapon.CEP_Surface *= 3;
							activeUnit_0.ParentScen.AddMessage(text, Name + " 命中" + activeUnit_0.Name + " - major deflection", LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
							bool_ = false;
						}
						else
						{
							text = text + "结果：" + Conversions.ToString(num) + "。较小的轨迹偏差（目标武器的CEP乘以1.5）。";
							weapon.CEP_Land = (int)Math.Round((double)weapon.CEP_Land * 1.5);
							weapon.CEP_Surface = (int)Math.Round((double)weapon.CEP_Surface * 1.5);
							activeUnit_0.ParentScen.AddMessage(text, Name + " 命中" + activeUnit_0.Name + " - minor deflection", LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
							bool_ = false;
						}
						break;
					}
					case Warhead.WarheadType.ArmorPiercing:
					case Warhead.WarheadType.Kinetic:
						text += "击杀弹头：目标被彻底摧毁。";
						bool_ = true;
						break;
					}
					stringBuilder_0.Append(text);
					ExportResolveImpactEvent(activeUnit_0, bool_0: true, bool_, stringBuilder_0);
					if (bool_)
					{
						ActiveUnit_Damage damage = activeUnit_0.Damage;
						GeoPoint launchPoint = LaunchPoint;
						string string_ = "";
						damage.ResolveDamageFromWeapon(this, launchPoint, 0f, 0f, null, null, null, null, ref string_, bool_0: true);
					}
					return;
				}
			}
			if (Operators.CompareString(text, "", TextCompare: false) != 0)
			{
				activeUnit_0.ParentScen.AddMessage(text, Name + " 命中" + activeUnit_0.Name, LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
			}
			if (!activeUnit_0.IsAircraft && !activeUnit_0.IsMissile)
			{
				if (activeUnit_0.IsMissile)
				{
					stringBuilder_0.Append("\r\n").Append(text);
					ExportResolveImpactEvent(activeUnit_0, bool_0: true, bool_, stringBuilder_0);
					ActiveUnit_Damage damage2 = activeUnit_0.Damage;
					GeoPoint launchPoint2 = LaunchPoint;
					string string_2 = "";
					damage2.ResolveDamageFromWeapon(this, launchPoint2, 0f, 0f, null, null, null, null, ref string_2, bool_0: true);
				}
				else
				{
					stringBuilder_0.Append(text);
					ActiveUnit_Damage damage3 = activeUnit_0.Damage;
					GeoPoint launchPoint3 = LaunchPoint;
					string string_3 = "";
					damage3.ResolveDamageFromWeapon(this, launchPoint3, 0f, 0f, null, null, null, null, ref string_3, bool_0: true);
					bool isDestroyed = activeUnit_0.IsDestroyed;
					ExportResolveImpactEvent(activeUnit_0, bool_0: true, isDestroyed, stringBuilder_0);
				}
			}
			else
			{
				ActiveUnit_Damage damage4 = activeUnit_0.Damage;
				GeoPoint launchPoint4 = LaunchPoint;
				string string_4 = "";
				damage4.ResolveDamageFromWeapon(this, launchPoint4, 0f, 0f, null, null, null, null, ref string_4, bool_0: true);
				bool_ = activeUnit_0.IsDestroyed;
				ExportResolveImpactEvent(activeUnit_0, bool_0: true, bool_, stringBuilder_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100959", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool HasMandatoryDatalink()
	{
		CommDevice[] comms_ReadOnly = Comms_ReadOnly;
		for (int i = 0; i < comms_ReadOnly.Length; i = checked(i + 1))
		{
			if (!comms_ReadOnly[i].IsOptional)
			{
				return true;
			}
		}
		return false;
	}

	public override void Destroy(bool bool_0, bool bool_1, bool bool_2, string string_0, string string_1 = null)
	{
		IsBeingDestroyed = true;
		try
		{
			if (AI.PrimaryTarget != null && !AI.PrimaryTarget.GetIsDestroyed(ParentScen) && AI.PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint && AI.PrimaryTarget.Type != Contact_Base.ContactType.ActivationPoint && AI.PrimaryTarget.ActualUnit != null)
			{
				if (AI.PrimaryTarget.ActualUnit.AI.Threats_ReadOnly != null)
				{
					foreach (Contact item in AI.PrimaryTarget.ActualUnit.AI.Threats_ReadOnly)
					{
						if (item.ActualUnit == this)
						{
							AI.PrimaryTarget.ActualUnit.AI.DropThreat(item);
							break;
						}
					}
				}
				AI.PrimaryTarget.ActualUnit.AI.PrimaryThreat = null;
			}
			foreach (ActiveUnit value in ParentScen.ActiveUnits.Values)
			{
				if (value == null)
				{
					continue;
				}
				Sensor[] array = value.Sensors_ReadOnly();
				Sensor[] array2 = array;
				foreach (Sensor sensor in array2)
				{
					if (sensor.SemiActiveWeaponsGuided.Contains(this))
					{
						sensor.SemiActiveWeaponsGuided.Remove(this);
						SensorProvidingFireControlForMe = null;
					}
					if (sensor.SemiActiveWeaponsGuided.Count == 0)
					{
						sensor.StopTrackingTarget(AI.PrimaryTarget);
					}
				}
			}
			ClearAllComms();
			base.Destroy(bool_0, bool_1, bool_2, string_0, string_1);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200343", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DetermineGuidance()
	{
		if (Type != _WeaponType.Decoy_Vehicle && Type != _WeaponType.UAV_Expendable)
		{
			if (Flags.IlluminateAtLaunch)
			{
				if (_Sensors.Length == 0)
				{
					if (Comms_ReadOnly.Count() <= 0)
					{
						m_WrapperReader = WeaponGuidanceType.BeamRiding;
					}
					else
					{
						m_WrapperReader = WeaponGuidanceType.TVM;
					}
					return;
				}
				switch (_Sensors[0].Type)
				{
				case Sensor.Sensor_Type.LaserSpotTracker:
					m_WrapperReader = WeaponGuidanceType.SemiActive;
					break;
				case Sensor.Sensor_Type.SemiActive:
					m_WrapperReader = WeaponGuidanceType.SemiActive;
					break;
				case Sensor.Sensor_Type.Radar:
					m_WrapperReader = WeaponGuidanceType.SemiActive_Plus_Active;
					break;
				}
			}
			else if (Directors.Count > 0 && Comms_ReadOnly.Count() == 0 && !Flags.TerminalIllumination && base.HasRadarSensor)
			{
				m_WrapperReader = WeaponGuidanceType.TimesharedSemiActive_Plus_Active;
			}
			else if (Flags.TerminalIllumination)
			{
				if (Comms_ReadOnly.Count() == 0)
				{
					if (base.HasInfraredSensor)
					{
						if (!Flags.BearingOnlyLaunch && !Flags.Navigation_INS && !Flags.Navigation_INS_GPS && !Flags.Navigation_TERCOM)
						{
							m_WrapperReader = WeaponGuidanceType.Passive;
						}
						else
						{
							m_WrapperReader = WeaponGuidanceType.Inertial_Plus_Passive;
						}
					}
					else
					{
						m_WrapperReader = WeaponGuidanceType.Inertial_Plus_SemiActive;
					}
				}
				else
				{
					m_WrapperReader = WeaponGuidanceType.Datalink_Plus_SemiActive;
				}
			}
			else if (!base.HasRadarSensor && !HasActiveCapableSonarSensor())
			{
				if (HasPassiveSensor() && Type != _WeaponType.Microwave)
				{
					if (!Flags.BearingOnlyLaunch && !Flags.Navigation_INS && !Flags.Navigation_INS_GPS && !Flags.Navigation_TERCOM)
					{
						if (Comms_ReadOnly.Count() == 0)
						{
							m_WrapperReader = WeaponGuidanceType.Passive;
						}
						else
						{
							m_WrapperReader = WeaponGuidanceType.DataLink_Plus_Passive;
						}
					}
					else if (Comms_ReadOnly.Count() == 0)
					{
						m_WrapperReader = WeaponGuidanceType.Inertial_Plus_Passive;
					}
					else
					{
						m_WrapperReader = WeaponGuidanceType.DataLink_Plus_Passive;
					}
				}
				else if (Comms_ReadOnly.Count() <= 0)
				{
					m_WrapperReader = WeaponGuidanceType.Inertial;
				}
				else
				{
					m_WrapperReader = WeaponGuidanceType.CommandGuided_Datalinked;
				}
			}
			else if (Flags.BearingOnlyLaunch)
			{
				if (Comms_ReadOnly.Count() == 0)
				{
					m_WrapperReader = WeaponGuidanceType.Inertial_Plus_Active;
				}
				else
				{
					m_WrapperReader = WeaponGuidanceType.Datalink_Plus_Active;
				}
			}
			else if (Comms_ReadOnly.Count() == 0)
			{
				m_WrapperReader = WeaponGuidanceType.Active;
			}
			else
			{
				m_WrapperReader = WeaponGuidanceType.Datalink_Plus_Active;
			}
		}
		else
		{
			m_WrapperReader = WeaponGuidanceType.Inertial;
		}
	}

	internal float RegisterReponse(float float_0)
	{
		if (MaxTargetSpeed == 0)
		{
			return 0f;
		}
		int maxTargetSpeed = MaxTargetSpeed;
		int num = (int)Math.Round((float)MaxTargetSpeed * 1.2f);
		int num2 = 50;
		if (float_0 <= (float)maxTargetSpeed)
		{
			return 0f;
		}
		if (float_0 <= (float)num)
		{
			return (float)Math.Round((float_0 - (float)maxTargetSpeed) * (float)num2 / (float)(num - maxTargetSpeed), 2);
		}
		return num2;
	}

	internal float ManageReponse(float float_0)
	{
		if (float_0 < 91.44f)
		{
			if (float_0 < 60.96f)
			{
				if (float_0 < 30.48f)
				{
					return 30f;
				}
				return 15f;
			}
			return 5f;
		}
		return 0f;
	}

	public override void DoFuelConsumption(float float_0)
	{
		try
		{
			if (IsParachuteLoitering)
			{
				return;
			}
			if (UsesBoostCoastModel.Value && TotalBurnTime == 0)
			{
				RecalculateWeaponFlightEnergyIfNecessary(this, ParentScen, SetReponse());
			}
			if (UsesBoostCoastModel.Value)
			{
				if (TimeSinceLaunch <= (float)TotalBurnTime)
				{
					return;
				}
				int num = Kinematics.InitDescriptor(GetCurrentAltitude());
				if (!(CurrentSpeed < (float)num))
				{
					return;
				}
				if (IsNuke.Value && !IsAAW)
				{
					double latitude = GetLatitude();
					double longitude = GetLongitude();
					float currentAltitude = GetCurrentAltitude();
					LockRandom lockRandom_ = GameGeneral.LockRandom_0;
					Detonate(latitude, longitude, currentAltitude, ref lockRandom_, bool_0: true);
				}
				else
				{
					string string_ = "武器：" + Name + "已耗尽能量...自我毁灭";
					if (Type != _WeaponType.Sonobuoy)
					{
						ParentScen.AddMessage(string_, Name + " 消失", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
					}
					ParentScen.DestroyThisUnit(this, string_);
				}
			}
			else
			{
				if (Fuel_ReadOnly.Count == 0)
				{
					return;
				}
				if (Type != _WeaponType.Sonobuoy && Type != _WeaponType.Torpedo && (double)Module_Unit.RangeToPoint_Horiz(this, LaunchPoint) > (double)MaxRange_NoTargetType * 1.25)
				{
					ParentScen.AddMessage("武器：" + Name + "已耗尽能量...自我毁灭", Name + " 消失", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
					ParentScen.DestroyThisUnit(this, "耗尽燃料，自我销毁");
					return;
				}
				if (_Fuel[0].CurrentQuantity == 0f)
				{
					if (SupportsAttitude_Pitch)
					{
						if (Module_Unit.MapTokenizer(this))
						{
							if (Attitude_Pitch < MoveDescriptor())
							{
								return;
							}
						}
						else if (IsBallisticMissile || IsReEntryVehicle || IsHGV)
						{
							return;
						}
					}
					if (!IsNuke.Value || IsAAW)
					{
						if (Type != _WeaponType.Sonobuoy)
						{
							ParentScen.AddMessage("武器：" + Name + "已耗尽能量...自我毁灭", Name + " 消失", LoggedMessage.MessageType.WeaponEndgame, 3, null, null, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						}
						ParentScen.DestroyThisUnit(this, Message, "燃料已用完");
						return;
					}
					double latitude2 = GetLatitude();
					double longitude2 = GetLongitude();
					float currentAltitude2 = GetCurrentAltitude();
					LockRandom lockRandom_2 = GameGeneral.LockRandom_0;
					Detonate(latitude2, longitude2, currentAltitude2, ref lockRandom_2, bool_0: true);
				}
				float num2 = FuelConsumption(ThrottleSetting, null, null, null, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false);
				_Fuel[0].SubtractFuel(float_0 * num2);
				if (_Fuel[0].CurrentQuantity < 0f)
				{
					_Fuel[0].CurrentQuantity = 0f;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100961", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override float FuelConsumption(Throttle throttle_0, AltBand altBand_0, float? nullable_0, float? nullable_1, bool bool_0, bool bool_1, bool bool_2, bool bool_3, bool bool_4)
	{
		try
		{
			if (Propulsion.Count == 0)
			{
				return 1f;
			}
			AltBand altBand = ((!Information.IsNothing(altBand_0)) ? altBand_0 : (Information.IsNothing(nullable_1) ? Kinematics.GetCurrentAltBand(GetCurrentAltitude(), bool_0: false) : Kinematics.GetCurrentAltBand(nullable_1.Value, bool_0: false)));
			if (Information.IsNothing(altBand))
			{
				throw new Exception();
			}
			switch (throttle_0)
			{
			default:
				return 0f;
			case Throttle.Loiter:
				if (Information.IsNothing(altBand.Consumption_Loiter))
				{
					return 0f;
				}
				return Math.Max(1f, altBand.Consumption_Loiter);
			case Throttle.Cruise:
				return altBand.Consumption_Cruise;
			case Throttle.Full:
				if (altBand.Consumption_Full.HasValue)
				{
					return altBand.Consumption_Full.Value;
				}
				return altBand.Consumption_Cruise;
			case Throttle.Flank:
				if (altBand.Consumption_Flank.HasValue)
				{
					return altBand.Consumption_Flank.Value;
				}
				if (altBand.Consumption_Full.HasValue)
				{
					return altBand.Consumption_Full.Value;
				}
				return altBand.Consumption_Cruise;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100962", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public static float ModifierVsTargetSpeed(int int_0, Weapon weapon_0, ActiveUnit activeUnit_0, StringBuilder stringBuilder_0)
	{
		float num = 0f;
		try
		{
			if (weapon_0.MaxTargetSpeed > 0)
			{
				if (activeUnit_0.CurrentSpeed <= (float)weapon_0.MaxTargetSpeed)
				{
					if ((double)activeUnit_0.CurrentSpeed <= (double)weapon_0.MaxTargetSpeed * 0.8)
					{
						if ((double)activeUnit_0.CurrentSpeed <= (double)weapon_0.MaxTargetSpeed * 0.7)
						{
							if ((double)activeUnit_0.CurrentSpeed <= (double)weapon_0.MaxTargetSpeed * 0.6)
							{
								if ((double)activeUnit_0.CurrentSpeed > (double)weapon_0.MaxTargetSpeed * 0.5)
								{
									num = 5f;
								}
							}
							else
							{
								num = 10f;
							}
						}
						else
						{
							num = 15f;
						}
					}
					else
					{
						num = 25f;
					}
				}
				else
				{
					num = 50f;
				}
				if (num != 0f)
				{
					stringBuilder_0.Append("目标速度修正：" + Conversions.ToString(-(int)Math.Round(num)) + "%. ");
				}
			}
			return Math.Max(1f, (float)int_0 - num);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100963", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public static float ModifierVsTargetSignature(int int_0, ActiveUnit activeUnit_0, Weapon weapon_0, ActiveUnit activeUnit_1, Sensor sensor_0, float float_0, float float_1, StringBuilder stringBuilder_0)
	{
		float num = 0f;
		if (sensor_0 != null)
		{
			switch (sensor_0.Type)
			{
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				num = 0f;
				break;
			case Sensor.Sensor_Type.LaserDesignator:
				num = 0f;
				break;
			case Sensor.Sensor_Type.ESM:
				num = 0f;
				break;
			case Sensor.Sensor_Type.Radar:
			case Sensor.Sensor_Type.SemiActive:
			{
				float num2 = (float)new RadarModel.TTarget
				{
					RCS = float_0
				}.RCS_m2;
				if (num2 <= 1f)
				{
					if (num2 <= 0.1f)
					{
						if (num2 <= 0.01f)
						{
							GlobalVariables.TechGenerationClass techGeneration7 = sensor_0.TechGeneration;
							if (techGeneration7 <= GlobalVariables.TechGenerationClass.Early1960s)
							{
								num = 60f;
							}
							else if (techGeneration7 <= GlobalVariables.TechGenerationClass.Early1970s)
							{
								num = 45f;
							}
							else if (techGeneration7 <= GlobalVariables.TechGenerationClass.Early1980s)
							{
								num = 30f;
							}
							else if (techGeneration7 <= GlobalVariables.TechGenerationClass.Early1990s)
							{
								num = 20f;
							}
							else if (techGeneration7 <= GlobalVariables.TechGenerationClass.Early2000s)
							{
								num = 15f;
							}
							else if (techGeneration7 <= GlobalVariables.TechGenerationClass.Early2010s)
							{
								num = 10f;
							}
							else if (techGeneration7 <= GlobalVariables.TechGenerationClass.Early2020s)
							{
								num = 5f;
							}
						}
						else
						{
							GlobalVariables.TechGenerationClass techGeneration8 = sensor_0.TechGeneration;
							if (techGeneration8 <= GlobalVariables.TechGenerationClass.Early1960s)
							{
								num = 50f;
							}
							else if (techGeneration8 <= GlobalVariables.TechGenerationClass.Early1970s)
							{
								num = 35f;
							}
							else if (techGeneration8 <= GlobalVariables.TechGenerationClass.Early1980s)
							{
								num = 20f;
							}
							else if (techGeneration8 <= GlobalVariables.TechGenerationClass.Early1990s)
							{
								num = 10f;
							}
							else if (techGeneration8 <= GlobalVariables.TechGenerationClass.Early2000s)
							{
								num = 5f;
							}
						}
					}
					else
					{
						GlobalVariables.TechGenerationClass techGeneration9 = sensor_0.TechGeneration;
						if (techGeneration9 <= GlobalVariables.TechGenerationClass.Early1960s)
						{
							num = 40f;
						}
						else if (techGeneration9 <= GlobalVariables.TechGenerationClass.Early1970s)
						{
							num = 25f;
						}
						else if (techGeneration9 <= GlobalVariables.TechGenerationClass.Early1980s)
						{
							num = 15f;
						}
						else if (techGeneration9 <= GlobalVariables.TechGenerationClass.Early1990s)
						{
							num = 10f;
						}
						else if (techGeneration9 <= GlobalVariables.TechGenerationClass.Early2000s)
						{
							num = 5f;
						}
					}
				}
				else
				{
					num = 0f;
				}
				break;
			}
			case Sensor.Sensor_Type.Visual:
				switch (activeUnit_1.VisualSizeClass)
				{
				case GlobalVariables.TargetVisualSizeClass.Stealthy:
				{
					GlobalVariables.TechGenerationClass techGeneration5 = sensor_0.TechGeneration;
					if (techGeneration5 <= GlobalVariables.TechGenerationClass.Early1960s)
					{
						num = 60f;
					}
					else if (techGeneration5 <= GlobalVariables.TechGenerationClass.Early1970s)
					{
						num = 45f;
					}
					else if (techGeneration5 <= GlobalVariables.TechGenerationClass.Early1980s)
					{
						num = 30f;
					}
					else if (techGeneration5 <= GlobalVariables.TechGenerationClass.Early1990s)
					{
						num = 20f;
					}
					else if (techGeneration5 <= GlobalVariables.TechGenerationClass.Early2000s)
					{
						num = 15f;
					}
					else if (techGeneration5 <= GlobalVariables.TechGenerationClass.Early2010s)
					{
						num = 10f;
					}
					else if (techGeneration5 <= GlobalVariables.TechGenerationClass.Early2020s)
					{
						num = 5f;
					}
					break;
				}
				case GlobalVariables.TargetVisualSizeClass.VSmall:
				{
					GlobalVariables.TechGenerationClass techGeneration6 = sensor_0.TechGeneration;
					if (techGeneration6 <= GlobalVariables.TechGenerationClass.Early1960s)
					{
						num = 50f;
					}
					else if (techGeneration6 <= GlobalVariables.TechGenerationClass.Early1970s)
					{
						num = 35f;
					}
					else if (techGeneration6 <= GlobalVariables.TechGenerationClass.Early1980s)
					{
						num = 20f;
					}
					else if (techGeneration6 <= GlobalVariables.TechGenerationClass.Early1990s)
					{
						num = 10f;
					}
					else if (techGeneration6 <= GlobalVariables.TechGenerationClass.Early2000s)
					{
						num = 5f;
					}
					break;
				}
				case GlobalVariables.TargetVisualSizeClass.Small:
				{
					GlobalVariables.TechGenerationClass techGeneration4 = sensor_0.TechGeneration;
					if (techGeneration4 <= GlobalVariables.TechGenerationClass.Early1960s)
					{
						num = 40f;
					}
					else if (techGeneration4 <= GlobalVariables.TechGenerationClass.Early1970s)
					{
						num = 25f;
					}
					else if (techGeneration4 <= GlobalVariables.TechGenerationClass.Early1980s)
					{
						num = 15f;
					}
					else if (techGeneration4 <= GlobalVariables.TechGenerationClass.Early1990s)
					{
						num = 10f;
					}
					else if (techGeneration4 <= GlobalVariables.TechGenerationClass.Early2000s)
					{
						num = 5f;
					}
					break;
				}
				case GlobalVariables.TargetVisualSizeClass.Medium:
					num = 9f;
					break;
				case GlobalVariables.TargetVisualSizeClass.Large:
					num = 3f;
					break;
				}
				break;
			case Sensor.Sensor_Type.Infrared:
				if (float_1 <= 1f)
				{
					if (float_1 <= 0.5f)
					{
						if (float_1 <= 0.25f)
						{
							GlobalVariables.TechGenerationClass techGeneration = sensor_0.TechGeneration;
							if (techGeneration <= GlobalVariables.TechGenerationClass.Early1960s)
							{
								num = 60f;
							}
							else if (techGeneration <= GlobalVariables.TechGenerationClass.Early1970s)
							{
								num = 45f;
							}
							else if (techGeneration <= GlobalVariables.TechGenerationClass.Early1980s)
							{
								num = 30f;
							}
							else if (techGeneration <= GlobalVariables.TechGenerationClass.Early1990s)
							{
								num = 20f;
							}
							else if (techGeneration <= GlobalVariables.TechGenerationClass.Early2000s)
							{
								num = 15f;
							}
							else if (techGeneration <= GlobalVariables.TechGenerationClass.Early2010s)
							{
								num = 10f;
							}
							else if (techGeneration <= GlobalVariables.TechGenerationClass.Early2020s)
							{
								num = 5f;
							}
						}
						else
						{
							GlobalVariables.TechGenerationClass techGeneration2 = sensor_0.TechGeneration;
							if (techGeneration2 <= GlobalVariables.TechGenerationClass.Early1960s)
							{
								num = 50f;
							}
							else if (techGeneration2 <= GlobalVariables.TechGenerationClass.Early1970s)
							{
								num = 35f;
							}
							else if (techGeneration2 <= GlobalVariables.TechGenerationClass.Early1980s)
							{
								num = 20f;
							}
							else if (techGeneration2 <= GlobalVariables.TechGenerationClass.Early1990s)
							{
								num = 10f;
							}
							else if (techGeneration2 <= GlobalVariables.TechGenerationClass.Early2000s)
							{
								num = 5f;
							}
						}
					}
					else
					{
						GlobalVariables.TechGenerationClass techGeneration3 = sensor_0.TechGeneration;
						if (techGeneration3 <= GlobalVariables.TechGenerationClass.Early1960s)
						{
							num = 40f;
						}
						else if (techGeneration3 <= GlobalVariables.TechGenerationClass.Early1970s)
						{
							num = 25f;
						}
						else if (techGeneration3 <= GlobalVariables.TechGenerationClass.Early1980s)
						{
							num = 15f;
						}
						else if (techGeneration3 <= GlobalVariables.TechGenerationClass.Early1990s)
						{
							num = 10f;
						}
						else if (techGeneration3 <= GlobalVariables.TechGenerationClass.Early2000s)
						{
							num = 5f;
						}
					}
				}
				else
				{
					num = 0f;
				}
				break;
			}
			if (num != 0f)
			{
				stringBuilder_0.Append("目标特性修正：" + Conversions.ToString(-(int)Math.Round(num)) + "% (Director [" + sensor_0.Name + "] has tech-gen: " + Misc.MapRequest(sensor_0.TechGeneration) + "). ");
			}
		}
		float num3 = Math.Max(1f, (float)int_0 - num);
		bool? flag2;
		if (sensor_0 == null)
		{
			bool? flag = activeUnit_0?.IsAircraft;
			flag2 = (!flag) ?? flag;
		}
		else
		{
			flag2 = false;
		}
		bool? flag3 = flag2;
		if (flag3.GetValueOrDefault(true) && weapon_0.IsUnguidedBallisticWeapon && flag3.HasValue)
		{
			num3 -= 60f;
			stringBuilder_0.Append(" Weapon has been fired without director control (manual backup?). Hit probability reduced by 60%.");
		}
		return num3;
	}

	public void PrepareForReattack(Module_Unit.Unit unit_0)
	{
		Module_Unit.BearingToUnit_True(this, unit_0);
		Module_Unit.RangeToUnit_Horiz(this, unit_0);
		float num = ETA_To_Unit(unit_0);
		DestroyDescriptor(Math.Max(num * 2f, 15f));
		SearchPatternType = WeaponSearchPatternType.Circle;
		Sensor[] sensors = _Sensors;
		for (int i = 0; i < sensors.Length; i = checked(i + 1))
		{
			sensors[i].IsNeutralized = null;
		}
	}

	private bool RevertReponse()
	{
		if (!IsMIRVedMissile.Value && !IsMRVedMissile.Value)
		{
			if (Warheads.Length != 0 && Warheads[0].Type == Warhead.WarheadType.Weapon && Warheads[0].GetCarriedWeapon(ParentScen).IsReEntryVehicle)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	public float ShockDamage_KE()
	{
		try
		{
			switch (Type)
			{
			case _WeaponType.GuidedProjectile:
			{
				float num4 = (float)((double)CurrentSpeed * 0.514444);
				return (float)(0.5 * (double)EmptyWeight * Math.Pow(num4, 2.0) / 100.0 / 15000.0);
			}
			case _WeaponType.Rocket:
				return (float)(0.5 * (double)EmptyWeight * Math.Pow(300.0, 2.0) / 100.0 / 15000.0);
			case _WeaponType.IronBomb:
				return (float)(0.5 * (double)EmptyWeight * Math.Pow(200.0, 2.0) / 100.0 / 15000.0);
			case _WeaponType.Gun:
			{
				float num5 = (float)((double)CurrentSpeed * 0.514444);
				return (float)(0.5 * (double)EmptyWeight * Math.Pow(num5, 2.0) / 100.0 / 15000.0);
			}
			default:
				return 0f;
			case _WeaponType.HGV:
			{
				float num2 = Math.Max(Math.Max(MaxWeight, FindReponse()), Math.Max(EmptyWeight, MaxPayloadWeight));
				if (num2 == 0f && Warheads.Any())
				{
					num2 = Warheads[0].DP;
				}
				float num3 = (float)((double)CurrentSpeed * 0.514444);
				return (float)(0.5 * (double)num2 * Math.Pow(num3, 2.0) / 100.0 / 15000.0);
			}
			case _WeaponType.GuidedWeapon:
			case _WeaponType.Torpedo:
			{
				float num = (float)((double)CurrentSpeed * 0.514444);
				return (float)(0.5 * (double)EmptyWeight * Math.Pow(num, 2.0) / 100.0 / 15000.0);
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100979", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	[CompilerGenerated]
	private double CountDescriptor(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(this, contact_0);
	}

	[CompilerGenerated]
	private bool CustomizeDescriptor((string DetectorUnitID, string DetectingSensorID, float RangeEstimate, ActiveUnit_Sensory.SpecialDetectionMode theDetectionMode, DateTime theTime) valueTuple_0)
	{
		return Operators.CompareString(valueTuple_0.DetectorUnitID, ObjectID, TextCompare: false) == 0;
	}

	[CompilerGenerated]
	private double CloneDescriptor(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(this, contact_0);
	}

	[CompilerGenerated]
	private double ConnectDescriptor(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(this, contact_0);
	}
}
