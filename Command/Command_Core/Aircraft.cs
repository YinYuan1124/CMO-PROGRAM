using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Aircraft : Platform, ICargoHost, IFlier
{
	public enum CockpitVisibility
	{
		None,
		Excellent,
		Average,
		Poor
	}

	public enum NATO_UAS_ClassificationEnum
	{
		Undefined,
		Class1_Micro,
		Class1_Mini,
		Class1_Small,
		Class2,
		Class3
	}

	public enum _BombsightTech : byte
	{
		Basic,
		Ballistic,
		Computing,
		Advanced
	}

	public enum _AircraftCategory : short
	{
		None = 1001,
		FixedWing = 2001,
		CarrierCapable = 2002,
		Helicopter = 2003,
		Tiltrotor = 2004,
		Satellite = 2005,
		AirShip = 2006,
		SeaPlane = 2007,
		Amphibian = 2008
	}

	public enum _AircraftFuselageStructure
	{
		None = 0,
		LowSubsonicFighter = 9101,
		HighSubsonicFighter = 9102,
		LowSupersonicFighter = 9103,
		HighSupersonicFighter = 9104,
		LowSubsonicAttackAircraft = 9111,
		HighSubsonicAttackAircraft = 9112,
		LowSupersonicAttackAircraft = 9113,
		HighSupersonicAttackAircraft = 9114,
		LowSubsonicBomber = 9121,
		HighSubsonicBomber = 9122,
		LowSupersonicBomber = 9123,
		HighSupersonicBomber = 9124,
		HighAltitudeSlowSpeedRecon = 9185,
		HighAltitudeHighSpeedRecon = 9186,
		LowSubsonicCivilianStandards = 9191,
		HighSubsonicCivilianStandards = 9192,
		Airship = 9199
	}

	public enum _AircraftType
	{
		None = 1001,
		Fighter = 2001,
		Multirole = 2002,
		ASAT = 2101,
		AirborneLaserPlatform = 2102,
		Attack = 3001,
		WildWeasel = 3002,
		Bomber = 3101,
		CAS = 3401,
		OECM = 4001,
		AEW = 4002,
		AirborneCP = 4003,
		SAR = 4101,
		MCM = 4201,
		ASW = 6001,
		MPA = 6002,
		ForwardObserver = 7001,
		AreaSurveillance = 7002,
		Recon = 7003,
		ELINT = 7004,
		SIGINT = 7005,
		Transport = 7101,
		Cargo = 7201,
		Commercial = 7301,
		Civilian = 7302,
		Utility = 7401,
		Utility_Naval = 7402,
		Tanker = 8001,
		Trainer = 8101,
		TargetTowing = 8102,
		TargetDrone = 8103,
		UAV = 8201,
		UCAV = 8202,
		AirShip = 8901,
		AeroStat = 8902,
		Blimp = 8903,
		IMGSAT = 9001,
		RORSAT = 9002,
		EORSAT = 9003
	}

	public static float EMERGENCY_LANDING_DISTANCE_NM;

	public int CockpitGen;

	public float Agility_Nominal;

	public _AircraftType Type;

	public _AircraftCategory Category;

	public _AircraftFuselageStructure FuselageStructure;

	public int TotalEndurance;

	public float AirborneTime;

	public float Span;

	public float Height;

	private Loadout workerWrapper;

	internal float accountWrapper;

	public float G_StrainAccumulated;

	public float G_Tolerance;

	public bool ShouldDropSonobuoysOnThisPulse;

	public GlobalVariables.ArmorRating Armor_Cockpit;

	public GlobalVariables.ArmorRating Armor_Fuselage;

	public GlobalVariables.ArmorRating Armor_Powerplant;

	public bool ProbeRefuelling;

	public bool BoomRefuelling;

	public bool CenterlineDrogue;

	public bool WingDrogue;

	public bool CenterlineBoom;

	private bool stateWrapper;

	private bool authenticationWrapper;

	private bool paramsWrapper;

	public bool bool_0;

	public bool FlyByWire;

	public bool HasBlipEnhancer;

	public bool HasHelmetMountedSight;

	public GlobalVariables.AircraftSizeClass Size;

	public GlobalVariables.RunwayLengthClass RunwayLengthNeeded;

	public _BombsightTech BombSightTech;

	public bool SuperManouverable;

	public bool NightNavigationCapable;

	public bool NightNavigationAttackCapable;

	public bool RCSS_ActiveCancellation;

	public bool RCSS_SShapedIntakes;

	public bool RCSS_ExposedFanBlockers;

	public bool IRSS_ShieldedExhaustAntiStrela;

	public bool IRSS_MaskedExhaust;

	public bool IRSS_MaskedExhaust_Slit;

	public bool IRSS_PeakTempReduction;

	public bool RCCS_StealthPylons;

	public float FuelState_DistanceToBase;

	public ActiveUnit FuelState_Destination;

	public float FuelState_RemainingFuelToBingo;

	public float FuelState_RemainingFuelToJoker;

	public CockpitVisibility VisibilityForward;

	public CockpitVisibility VisibilitySideways;

	public CockpitVisibility VisibilityAft;

	private Aircraft_Navigator _InfoWrapper;

	private Aircraft_AI m_HelperWrapper;

	private Aircraft_Kinematics mapperWrapper;

	private Aircraft_Sensory managerWrapper;

	private Aircraft_Weaponry m_GetterWrapper;

	private Aircraft_CommStuff m_ProducerWrapper;

	private Aircraft_Damage m_ProcWrapper;

	private Aircraft_AirOps structObserver;

	internal bool merchantObserver;

	private float? callbackObserver;

	private static Scenario decoratorObserver;

	public override float MAX_Exhaustion
	{
		get
		{
			float num = 0f;
			float num2 = 0f;
			if (TotalEndurance <= 0)
			{
				if (num == 0f)
				{
					switch (Type)
					{
					case _AircraftType.Fighter:
					case _AircraftType.Multirole:
					case _AircraftType.Attack:
						if ((Crew == 1) | (Crew == 2))
						{
							num = 57600f;
						}
						break;
					case _AircraftType.Bomber:
					case _AircraftType.AEW:
					case _AircraftType.AirborneCP:
						num = 172800f;
						break;
					case _AircraftType.MPA:
					case _AircraftType.Tanker:
						num = 86400f;
						break;
					case _AircraftType.Transport:
						if ((Crew > 15) & (Size == GlobalVariables.AircraftSizeClass.VLarge))
						{
							num = 345600f;
						}
						break;
					}
				}
				if (num == 0f)
				{
					switch (Type)
					{
					case _AircraftType.TargetDrone:
						return float.MaxValue;
					case _AircraftType.None:
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return float.MaxValue;
					case _AircraftType.AirShip:
					case _AircraftType.AeroStat:
					case _AircraftType.Blimp:
						return float.MaxValue;
					case _AircraftType.UCAV:
						return float.MaxValue;
					case _AircraftType.UAV:
						return float.MaxValue;
					}
					switch (Size)
					{
					case GlobalVariables.AircraftSizeClass.Medium:
						num = 28800f;
						break;
					case GlobalVariables.AircraftSizeClass.None:
						num = float.MaxValue;
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						break;
					case GlobalVariables.AircraftSizeClass.UAS_Class1_Micro:
						num = float.MaxValue;
						break;
					case GlobalVariables.AircraftSizeClass.UAS_Class1_Mini:
						num = 21600f;
						break;
					case GlobalVariables.AircraftSizeClass.UAS_Class1_Small:
						num = 21600f;
						break;
					case GlobalVariables.AircraftSizeClass.UAS_Class2:
						num = 21600f;
						break;
					case GlobalVariables.AircraftSizeClass.Small:
						num = 21600f;
						break;
					case GlobalVariables.AircraftSizeClass.VLarge:
						num = 172800f;
						break;
					case GlobalVariables.AircraftSizeClass.Large:
						num = 86400f;
						break;
					}
				}
			}
			else
			{
				num2 = TotalEndurance;
				num2 *= 60f;
				if (num2 > 0f)
				{
					return num2;
				}
			}
			GlobalVariables.ProficiencyLevel? proficiency = Proficiency;
			int? num3 = (int?)proficiency;
			if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				num *= 1f;
			}
			else
			{
				num3 = (int?)proficiency;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					num *= 1.2f;
				}
				else
				{
					num3 = (int?)proficiency;
					if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						num *= 1.4f;
					}
					else
					{
						num3 = (int?)proficiency;
						if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							num *= 1.6f;
						}
						else
						{
							num3 = (int?)proficiency;
							if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								num *= 1.8f;
							}
						}
					}
				}
			}
			return num;
		}
	}

	public override float Current_Exhaustion => AirborneTime;

	public override bool SupportsAltitude_Control => true;

	public override bool SupportsAttitude_Pitch
	{
		get
		{
			if (!IsAerostat && !IsAirship && !IsHelicopter)
			{
				return true;
			}
			return false;
		}
	}

	public override float FlatSurfaceArea_m2 => Length * Span;

	public string Type_Description
	{
		get
		{
			_AircraftType type = Type;
			if (1 == 0)
			{
			}
			string result = type switch
			{
				_AircraftType.Multirole => "Multirole (Fighter/Attack)", 
				_AircraftType.Fighter => "Fighter", 
				_AircraftType.None => "None", 
				_AircraftType.Attack => "Attack", 
				_AircraftType.AirborneLaserPlatform => "Airborne Laser Platform", 
				_AircraftType.ASAT => "Anti-Satellite Interceptor (ASAT)", 
				_AircraftType.CAS => "Battlefield Air Interdiction (BAI/CAS)", 
				_AircraftType.Bomber => "Bomber", 
				_AircraftType.WildWeasel => "Wild Weasel", 
				_AircraftType.SAR => "Search And Rescue (SAR)", 
				_AircraftType.OECM => "Electronic Warfare", 
				_AircraftType.AEW => "Airborne Early Warning (AEW)", 
				_AircraftType.AirborneCP => "Airborne Command Post (ACP)", 
				_AircraftType.ASW => "反潜战（ASW）", 
				_AircraftType.MCM => "Mine Sweeper (MCM)", 
				_AircraftType.Transport => "Transport", 
				_AircraftType.ForwardObserver => "Forward Observer", 
				_AircraftType.AreaSurveillance => "Area Surveillance", 
				_AircraftType.Recon => "Recon", 
				_AircraftType.ELINT => "Electronic Intelligence (ELINT)", 
				_AircraftType.SIGINT => "Signals Intelligence (SIGINT)", 
				_AircraftType.MPA => "Maritime Patrol Aircraft (MPA)", 
				_AircraftType.Commercial => "Commercial", 
				_AircraftType.Cargo => "Cargo", 
				_AircraftType.Utility => "Utility", 
				_AircraftType.Civilian => "Civilian", 
				_AircraftType.Trainer => "Trainer", 
				_AircraftType.TargetTowing => "Target Towing", 
				_AircraftType.TargetDrone => "靶标目标", 
				_AircraftType.Tanker => "Tanker (Air Refueling)", 
				_AircraftType.Utility_Naval => "Naval Utility", 
				_AircraftType.UCAV => "Unmanned Combat Aerial Vehicle (UCAV)", 
				_AircraftType.UAV => "Unmanned Aerial Vehicle (UAV)", 
				_AircraftType.IMGSAT => "IMGSAT", 
				_AircraftType.RORSAT => "RORSAT", 
				_AircraftType.EORSAT => "EORSAT", 
				_AircraftType.AirShip => "Airship", 
				_AircraftType.AeroStat => "Aerostat", 
				_AircraftType.Blimp => "Blimp/Balloon", 
				_ => Type.ToString(), 
			};
			if (1 == 0)
			{
			}
			return result;
		}
	}

	public override GlobalVariables.ActiveUnitType UnitType => GlobalVariables.ActiveUnitType.Aircraft;

	public override bool IsMCMPlatform
	{
		get
		{
			if (Loadout == null)
			{
				return Type == _AircraftType.MCM;
			}
			return Loadout.Role == Loadout.LoadoutRole.MineSweeping;
		}
	}

	public override bool IsMineLayingPlatform
	{
		get
		{
			if (Loadout == null)
			{
				return false;
			}
			return Loadout.Role == Loadout.LoadoutRole.NavalMineLaying;
		}
	}

	public override bool HasSystemsRunning
	{
		get
		{
			if (IsOperating())
			{
				return true;
			}
			Aircraft_AirOps._AirOpsCondition condition = AirOps.Condition;
			if (condition != Aircraft_AirOps._AirOpsCondition.Parked && condition != Aircraft_AirOps._AirOpsCondition.Readying)
			{
				return true;
			}
			return false;
		}
	}

	public override _ActiveUnitStatus Status
	{
		get
		{
			return base.Status;
		}
		set
		{
			try
			{
				if (value != Status && value == _ActiveUnitStatus.RTB && (FuelState == _ActiveUnitFuelState.IsBingo || FuelState == _ActiveUnitFuelState.IsJoker))
				{
					DisconnectTankerClients();
				}
				if (!CountClient(GetLatitude(), GetLongitude(), 0f) || _Status != _ActiveUnitStatus.OnPlottedCourse)
				{
					base.Status = value;
					if (value == _ActiveUnitStatus.Refuelling)
					{
						AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Refuelling;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100352", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public bool HasBuddyStore
	{
		get
		{
			if (Loadout == null)
			{
				return false;
			}
			WeaponRec[] weapons = Loadout.Weapons;
			int num = 0;
			while (true)
			{
				if (num < weapons.Length)
				{
					if (weapons[num].GetReferenceWeapon(ParentScen).Type == Weapon._WeaponType.BuddyStore)
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

	public override ActiveUnit_DockingOps.ResupplyCapacity DesignatedSupplier
	{
		get
		{
			if (!_DesignatedSupplier.HasValue)
			{
				_DesignatedSupplier = ActiveUnit_DockingOps.ResupplyCapacity.FuelAndMaterial;
			}
			return _DesignatedSupplier.Value;
		}
		set
		{
			_DesignatedSupplier = value;
		}
	}

	public bool IsAerostat => Category == _AircraftCategory.AirShip;

	public bool IsAirship
	{
		get
		{
			if (Category == _AircraftCategory.AirShip)
			{
				return Type == _AircraftType.AirShip;
			}
			return false;
		}
	}

	public bool IsMooredBaloon
	{
		get
		{
			if (Category == _AircraftCategory.AirShip)
			{
				return Type == _AircraftType.AeroStat;
			}
			return false;
		}
	}

	public bool IsTanker
	{
		get
		{
			if (Type == _AircraftType.Tanker)
			{
				return true;
			}
			if (Loadout == null)
			{
				return false;
			}
			if (Loadout.Role == Loadout.LoadoutRole.AirRefueling)
			{
				return true;
			}
			return false;
		}
	}

	public override float DesiredAltitude
	{
		get
		{
			return base.DesiredAltitude;
		}
		set
		{
			if (!HasLostControlPulse_CACHED && value < 6.0959997f)
			{
				value = 6.0959997f;
			}
			base.DesiredAltitude = value;
		}
	}

	public override float DesiredAltitude_AGL
	{
		get
		{
			return base.DesiredAltitude_AGL;
		}
		set
		{
			if (value == 0f)
			{
				return;
			}
			base.DesiredAltitude_AGL = value;
			if (!paramsWrapper)
			{
				return;
			}
			if (Module_Unit.ResetTokenizer(this))
			{
				short elevation = Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, ParentScen);
				DesiredAltitude = value + (float)elevation;
				if (TerrainFollowingType == TerrainFollowMode.IgnoreLandCover || !ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects))
				{
					return;
				}
				(LandCover.LandCoverType, int) tuple = LandCover.AddClass(GetLatitude(), GetLongitude(), ParentScen, (List<CustomEnvironmentZone>)(object)ParentScen.GetNatureSide());
				switch (TerrainFollowingType)
				{
				case TerrainFollowMode.AboveLandCover:
					if (value < (float)tuple.Item2)
					{
						DesiredAltitude = elevation + tuple.Item2 + 1;
					}
					break;
				case TerrainFollowMode.WithinLandCover:
					if (tuple.Item2 > 2 && value > (float)tuple.Item2)
					{
						DesiredAltitude = elevation + tuple.Item2 - 1;
					}
					break;
				}
			}
			else
			{
				DesiredAltitude = value;
			}
		}
	}

	public override CommDevice[] Comms_ReadOnly
	{
		get
		{
			CommDevice[] result = null;
			try
			{
				if (Loadout == null)
				{
					result = _Comms;
					return result;
				}
				CommDevice[] gparam_ = null;
				int num = Loadout.Weapons.Count() - 1;
				for (int i = 0; i <= num; i++)
				{
					WeaponRec weaponRec = Loadout.Weapons[i];
					if (weaponRec.GetReferenceWeapon(ParentScen).Type != Weapon._WeaponType.SensorPod)
					{
						continue;
					}
					int num2 = weaponRec.GetReferenceWeapon(ParentScen).Comms_ReadOnly.Length - 1;
					for (int j = 0; j <= num2; j++)
					{
						if (gparam_ == null)
						{
							gparam_ = ValidateFacade();
						}
						CommDevice commDevice = weaponRec.GetReferenceWeapon(ParentScen).Comms_ReadOnly[j];
						commDevice.IsCommsInMount = true;
						ArrayExtensions.Add(ref gparam_, commDevice);
					}
				}
				if (gparam_ == null)
				{
					result = _Comms;
					return result;
				}
				result = gparam_;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100355", "");
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

	public override Throttle MaxPossibleThrottleSetting
	{
		get
		{
			if (Command_Core_002EICargoHost_002ECanStackCargo())
			{
				return Throttle.Flank;
			}
			return Throttle.Full;
		}
	}

	public override GlobalVariables.TargetVisualSizeClass VisualSizeClass
	{
		get
		{
			float length = Length;
			if (length <= 40f)
			{
				if (length <= 30f)
				{
					if (length <= 25f)
					{
						if (length <= 10f)
						{
							if (length <= 5f)
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

	public override string AnnexAndDBID => "飞机_" + Conversions.ToString(DBID);

	public override float DesiredRoll
	{
		get
		{
			return base.DesiredRoll;
		}
		set
		{
			base.DesiredRoll = value;
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

	public override float Attitude_Pitch
	{
		get
		{
			return base.Attitude_Pitch;
		}
		set
		{
			base.Attitude_Pitch = value;
		}
	}

	public override float Attitude_Roll
	{
		get
		{
			return base.Attitude_Roll;
		}
		set
		{
			base.Attitude_Roll = value;
		}
	}

	public override float CurrentSpeed
	{
		get
		{
			return base.CurrentSpeed;
		}
		set
		{
			base.CurrentSpeed = value;
		}
	}

	public bool IsOnOutboundLeg
	{
		get
		{
			switch (Status)
			{
			default:
				return false;
			case _ActiveUnitStatus.Unassigned:
			case _ActiveUnitStatus.OnPlottedCourse:
			case _ActiveUnitStatus.OnAttackRun:
			case _ActiveUnitStatus.OnPatrol:
			case _ActiveUnitStatus.Tasked:
			case _ActiveUnitStatus.FormingUp:
			case _ActiveUnitStatus.OnSupportMission:
				return true;
			}
		}
	}

	public bool IsOnReturnLeg
	{
		get
		{
			switch (Status)
			{
			default:
				return false;
			case _ActiveUnitStatus.RTB:
			case _ActiveUnitStatus.RTB_Manual:
			case _ActiveUnitStatus.OnFerryMission:
			case _ActiveUnitStatus.RTB_MissionOver:
			case _ActiveUnitStatus.RTB_Group:
			case _ActiveUnitStatus.RTB_CalledOff:
			case _ActiveUnitStatus.RTB_Exhaustion:
				return true;
			}
		}
	}

	public bool CanTakeOffVertically
	{
		get
		{
			if ((uint)(Category - 2003) <= 1u)
			{
				return true;
			}
			return RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.VTOL;
		}
	}

	public bool CanLandVertically
	{
		get
		{
			if ((uint)(Category - 2003) <= 1u)
			{
				return true;
			}
			return RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.VTOL;
		}
	}

	public bool CanRefuelOnAir
	{
		get
		{
			if (ProbeRefuelling)
			{
				return true;
			}
			return BoomRefuelling;
		}
	}

	public List<Tuple<string, int, float>> FuelByTank
	{
		get
		{
			try
			{
				List<Tuple<string, int, float>> list = new List<Tuple<string, int, float>>();
				if (Loadout != null)
				{
					WeaponRec[] weapons = Loadout.Weapons;
					WeaponRec[] array = weapons;
					foreach (WeaponRec weaponRec in array)
					{
						if (weaponRec.GetReferenceWeapon(ParentScen).IsFuelTank || (weaponRec.GetReferenceWeapon(ParentScen).IsSensorPod && weaponRec.GetReferenceWeapon(ParentScen).FuelCapacityMax > 0))
						{
							int currentLoad = weaponRec.CurrentLoad;
							for (int i = 1; i <= currentLoad; i++)
							{
								list.Add(new Tuple<string, int, float>(weaponRec.ObjectID, i, weaponRec.GetReferenceWeapon(ParentScen).Fuel_ReadOnly[0].CurrentQuantity));
							}
						}
					}
				}
				return list;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100361", "FuelByTank");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				List<Tuple<string, int, float>> result = new List<Tuple<string, int, float>>();
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public override List<FuelRec> Fuel_ReadOnly
	{
		get
		{
			List<FuelRec> list = new List<FuelRec>();
			try
			{
				int num = _Fuel.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					try
					{
						list.Add(_Fuel[i]);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
				if (Loadout != null)
				{
					WeaponRec[] weapons = Loadout.Weapons;
					WeaponRec[] array = weapons;
					foreach (WeaponRec weaponRec in array)
					{
						if (weaponRec.GetReferenceWeapon(ParentScen).IsFuelTank || (weaponRec.GetReferenceWeapon(ParentScen).IsSensorPod && weaponRec.GetReferenceWeapon(ParentScen).FuelCapacityCurrent > 0))
						{
							int currentLoad = weaponRec.CurrentLoad;
							for (int j = 1; j <= currentLoad; j++)
							{
								list.Add(weaponRec.GetReferenceWeapon(ParentScen).Fuel_ReadOnly[0]);
							}
						}
					}
				}
				return list;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100361", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				List<FuelRec> result = new List<FuelRec>();
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public override int FuelCapacityMax
	{
		get
		{
			try
			{
				int num = 0;
				foreach (FuelRec item in Fuel_ReadOnly)
				{
					num += item.MaxQuantity;
				}
				return num;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100362", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return 0;
			}
		}
	}

	public override int FuelCapacityCurrent
	{
		get
		{
			try
			{
				List<FuelRec> list = new List<FuelRec>(Fuel_ReadOnly);
				int num = 0;
				foreach (FuelRec item in list)
				{
					num = (int)Math.Round((float)num + item.CurrentQuantity);
				}
				return num;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100363", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return 0;
			}
		}
	}

	public new Aircraft_Navigator Navigator => _InfoWrapper;

	public new Aircraft_AI AI => m_HelperWrapper;

	public new Aircraft_Kinematics Kinematics => mapperWrapper;

	public new Aircraft_Sensory Sensory
	{
		get
		{
			if (managerWrapper == null)
			{
				ActiveUnit activeUnit_ = this;
				managerWrapper = new Aircraft_Sensory(ref activeUnit_);
			}
			return managerWrapper;
		}
	}

	public new Aircraft_Weaponry Weaponry
	{
		get
		{
			if (m_GetterWrapper == null)
			{
				ActiveUnit activeUnit_ = this;
				m_GetterWrapper = new Aircraft_Weaponry(ref activeUnit_);
			}
			return m_GetterWrapper;
		}
	}

	public new Aircraft_CommStuff CommStuff
	{
		get
		{
			if (m_ProducerWrapper == null)
			{
				ActiveUnit activeUnit_ = this;
				m_ProducerWrapper = new Aircraft_CommStuff(ref activeUnit_);
			}
			return m_ProducerWrapper;
		}
	}

	public new Aircraft_Damage Damage
	{
		get
		{
			if (m_ProcWrapper == null)
			{
				ActiveUnit activeUnit_ = this;
				m_ProcWrapper = new Aircraft_Damage(ref activeUnit_);
			}
			return m_ProcWrapper;
		}
	}

	public new Aircraft_AirOps AirOps
	{
		get
		{
			if (structObserver == null)
			{
				ActiveUnit activeUnit_ = this;
				structObserver = new Aircraft_AirOps(ref activeUnit_);
			}
			return structObserver;
		}
	}

	public string LoadoutName
	{
		get
		{
			if (workerWrapper == null)
			{
				return "Nothing";
			}
			return workerWrapper.Name;
		}
	}

	public int Int32_0
	{
		get
		{
			if (workerWrapper == null)
			{
				return 0;
			}
			return workerWrapper.DBID;
		}
	}

	public Loadout Loadout
	{
		get
		{
			return workerWrapper;
		}
		set
		{
			workerWrapper = value;
		}
	}

	public override List<Sensor> MineCountermeasures
	{
		get
		{
			try
			{
				if (_MineCountermeasures == null)
				{
					List<Sensor> list = new List<Sensor>();
					if (base.MineCountermeasures != null)
					{
						list.AddRange(base.MineCountermeasures);
					}
					if (Mounts != null)
					{
						foreach (Mount mount in Mounts)
						{
							if (mount == null)
							{
								continue;
							}
							Sensor[] sensors_ReadOnly = mount.Sensors_ReadOnly;
							Sensor[] array = sensors_ReadOnly;
							foreach (Sensor sensor in array)
							{
								if (sensor != null && sensor.IsMineCountermeasure)
								{
									list.Add(sensor);
								}
							}
						}
					}
					if (Loadout != null)
					{
						List<Sensor> list2 = Loadout.NewClass(ParentScen);
						if (list2.Count > 0)
						{
							foreach (Sensor item in list2)
							{
								if (item != null && item.IsMineCountermeasure)
								{
									list.Add(item);
								}
							}
						}
						if (Loadout.Weapons != null)
						{
							WeaponRec[] weapons = Loadout.Weapons;
							WeaponRec[] array2 = weapons;
							foreach (WeaponRec weaponRec in array2)
							{
								if (weaponRec.CurrentLoad <= 0 || weaponRec.GetReferenceWeapon(ParentScen).MineCountermeasures == null)
								{
									continue;
								}
								foreach (Sensor mineCountermeasure in weaponRec.GetReferenceWeapon(ParentScen).MineCountermeasures)
								{
									if (mineCountermeasure != null && mineCountermeasure.IsMineCountermeasure)
									{
										list.Add(mineCountermeasure);
									}
								}
							}
						}
					}
					_MineCountermeasures = list;
					return _MineCountermeasures;
				}
				return _MineCountermeasures;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100364", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				List<Sensor> result = new List<Sensor>();
				ProjectData.ClearProjectError();
				return result;
			}
		}
		set
		{
			_MineCountermeasures = value;
		}
	}

	public bool IsTiltrotor
	{
		get
		{
			if (Category == _AircraftCategory.Tiltrotor)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsHelicopter
	{
		get
		{
			if ((uint)(Category - 2003) <= 1u)
			{
				return true;
			}
			return false;
		}
	}

	public bool TerrainFollowingCapability
	{
		get
		{
			try
			{
				if (Loadout != null)
				{
					WeaponRec[] weapons = Loadout.Weapons;
					WeaponRec[] array = weapons;
					foreach (WeaponRec weaponRec in array)
					{
						if (weaponRec.GetReferenceWeapon(ParentScen).Type == Weapon._WeaponType.SensorPod && weaponRec.GetReferenceWeapon(ParentScen).Flags.Pod_TerrainFollowing)
						{
							return true;
						}
					}
				}
				return authenticationWrapper;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100365", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
		}
		set
		{
			authenticationWrapper = value;
		}
	}

	public bool TerrainAvoidanceCapability
	{
		get
		{
			try
			{
				if (Loadout != null)
				{
					WeaponRec[] weapons = Loadout.Weapons;
					WeaponRec[] array = weapons;
					foreach (WeaponRec weaponRec in array)
					{
						if (weaponRec.GetReferenceWeapon(ParentScen).Type == Weapon._WeaponType.SensorPod && weaponRec.GetReferenceWeapon(ParentScen).Flags.Pod_TerrainAvoidance)
						{
							return true;
						}
					}
				}
				return stateWrapper;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100365", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
		}
		set
		{
			stateWrapper = value;
		}
	}

	public float? MinimumSafeHeight
	{
		get
		{
			try
			{
				if (callbackObserver.HasValue)
				{
					return callbackObserver;
				}
				int num = GetLandElevation(bool_0: false, bool_1: false, bool_2: false, ParentScen);
				if (num < 0)
				{
					num = 0;
				}
				bool flag = num > 0;
				Weather.WeatherProfile weatherAtThisTimeAndPlace = Weather.GetWeatherAtThisTimeAndPlace(ParentScen, GetLatitude(), GetLongitude(), (int)Math.Round(GetCurrentAltitude()));
				DateTime time = ParentScen.Time;
				bool flag2 = SunModule.CollectSpecification(ParentScen, time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, bool_0: true, GetLatitude(), GetLongitude(), 0.0) == Weather.TTimeOfDayType.tod_Day;
				if (base.LandCoverMaskingCapability && TerrainFollowingType == TerrainFollowMode.WithinLandCover && GetDesiredAltitude_UseTerrainFollowing(this))
				{
					return (float)num + WriteFacade(flag, flag2, weatherAtThisTimeAndPlace.SeaState);
				}
				float num7 = 0f;
				if (flag)
				{
					if (!flag2)
					{
						float num15;
						if ((uint)(Category - 2003) > 1u)
						{
							num15 = (TerrainAvoidanceCapability ? 91.44f : (TerrainFollowingCapability ? 60.96f : 304.8f));
						}
						else
						{
							Throttle throttleSetting = ThrottleSetting;
							if (1 == 0)
							{
							}
							float num16 = throttleSetting switch
							{
								Throttle.Loiter => 15.24f, 
								Throttle.FullStop => 15.24f, 
								_ => TerrainAvoidanceCapability ? 91.44f : (TerrainFollowingCapability ? 60.96f : 152.4f), 
							};
							if (1 == 0)
							{
							}
							num15 = num16;
						}
						num7 = num15;
					}
					else
					{
						switch (Category)
						{
						default:
							if (TerrainAvoidanceCapability)
							{
								num7 = 91.44f;
								break;
							}
							if (TerrainFollowingCapability)
							{
								num7 = 60.96f;
								break;
							}
							num7 = 152.4f;
							switch (weatherAtThisTimeAndPlace.SeaState)
							{
							default:
								throw new NotImplementedException();
							case 0:
							{
								if (!(weatherAtThisTimeAndPlace.RainfallRate < 5f) || (int)Size > 30)
								{
									break;
								}
								GlobalVariables.ProficiencyLevel? proficiency7 = Proficiency;
								int? num11 = (int?)proficiency7;
								if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == 0) : null).GetValueOrDefault())
								{
									break;
								}
								num11 = (int?)proficiency7;
								if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == 1) : null).GetValueOrDefault())
								{
									break;
								}
								num11 = (int?)proficiency7;
								if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == 2) : null).GetValueOrDefault())
								{
									num7 = 121.92f;
									break;
								}
								num11 = (int?)proficiency7;
								if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == 3) : null).GetValueOrDefault())
								{
									num7 = 91.44f;
									break;
								}
								num11 = (int?)proficiency7;
								if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == 4) : null).GetValueOrDefault())
								{
									num7 = 60.96f;
								}
								break;
							}
							case 1:
							{
								if (!(weatherAtThisTimeAndPlace.RainfallRate < 5f) || (int)Size > 30)
								{
									break;
								}
								GlobalVariables.ProficiencyLevel? proficiency9 = Proficiency;
								int? num13 = (int?)proficiency9;
								if ((num13.HasValue ? new bool?(num13.GetValueOrDefault() == 0) : null).GetValueOrDefault())
								{
									break;
								}
								num13 = (int?)proficiency9;
								if ((num13.HasValue ? new bool?(num13.GetValueOrDefault() == 1) : null).GetValueOrDefault())
								{
									break;
								}
								num13 = (int?)proficiency9;
								if ((num13.HasValue ? new bool?(num13.GetValueOrDefault() == 2) : null).GetValueOrDefault())
								{
									num7 = 121.92f;
									break;
								}
								num13 = (int?)proficiency9;
								if ((num13.HasValue ? new bool?(num13.GetValueOrDefault() == 3) : null).GetValueOrDefault())
								{
									num7 = 91.44f;
									break;
								}
								num13 = (int?)proficiency9;
								if ((num13.HasValue ? new bool?(num13.GetValueOrDefault() == 4) : null).GetValueOrDefault())
								{
									num7 = 60.96f;
								}
								break;
							}
							case 2:
							{
								if (!(weatherAtThisTimeAndPlace.RainfallRate < 5f) || (int)Size > 30)
								{
									break;
								}
								GlobalVariables.ProficiencyLevel? proficiency8 = Proficiency;
								int? num12 = (int?)proficiency8;
								if ((num12.HasValue ? new bool?(num12.GetValueOrDefault() == 0) : null).GetValueOrDefault())
								{
									break;
								}
								num12 = (int?)proficiency8;
								if ((num12.HasValue ? new bool?(num12.GetValueOrDefault() == 1) : null).GetValueOrDefault())
								{
									break;
								}
								num12 = (int?)proficiency8;
								if ((num12.HasValue ? new bool?(num12.GetValueOrDefault() == 2) : null).GetValueOrDefault())
								{
									num7 = 121.92f;
									break;
								}
								num12 = (int?)proficiency8;
								if ((num12.HasValue ? new bool?(num12.GetValueOrDefault() == 3) : null).GetValueOrDefault())
								{
									num7 = 91.44f;
									break;
								}
								num12 = (int?)proficiency8;
								if ((num12.HasValue ? new bool?(num12.GetValueOrDefault() == 4) : null).GetValueOrDefault())
								{
									num7 = 60.96f;
								}
								break;
							}
							case 3:
							{
								if (!(weatherAtThisTimeAndPlace.RainfallRate < 5f) || (int)Size > 30)
								{
									break;
								}
								GlobalVariables.ProficiencyLevel? proficiency5 = Proficiency;
								int? num9 = (int?)proficiency5;
								if ((num9.HasValue ? new bool?(num9.GetValueOrDefault() == 0) : null).GetValueOrDefault())
								{
									break;
								}
								num9 = (int?)proficiency5;
								if ((num9.HasValue ? new bool?(num9.GetValueOrDefault() == 1) : null).GetValueOrDefault())
								{
									break;
								}
								num9 = (int?)proficiency5;
								if ((num9.HasValue ? new bool?(num9.GetValueOrDefault() == 2) : null).GetValueOrDefault())
								{
									num7 = 121.92f;
									break;
								}
								num9 = (int?)proficiency5;
								if ((num9.HasValue ? new bool?(num9.GetValueOrDefault() == 3) : null).GetValueOrDefault())
								{
									num7 = 91.44f;
									break;
								}
								num9 = (int?)proficiency5;
								if ((num9.HasValue ? new bool?(num9.GetValueOrDefault() == 4) : null).GetValueOrDefault())
								{
									num7 = 60.96f;
								}
								break;
							}
							case 4:
							{
								if (!(weatherAtThisTimeAndPlace.RainfallRate < 5f) || (int)Size > 30)
								{
									break;
								}
								GlobalVariables.ProficiencyLevel? proficiency6 = Proficiency;
								int? num10 = (int?)proficiency6;
								if ((num10.HasValue ? new bool?(num10.GetValueOrDefault() == 0) : null).GetValueOrDefault())
								{
									break;
								}
								num10 = (int?)proficiency6;
								if ((num10.HasValue ? new bool?(num10.GetValueOrDefault() == 1) : null).GetValueOrDefault())
								{
									break;
								}
								num10 = (int?)proficiency6;
								if ((num10.HasValue ? new bool?(num10.GetValueOrDefault() == 2) : null).GetValueOrDefault())
								{
									num7 = 121.92f;
									break;
								}
								num10 = (int?)proficiency6;
								if ((num10.HasValue ? new bool?(num10.GetValueOrDefault() == 3) : null).GetValueOrDefault())
								{
									num7 = 91.44f;
									break;
								}
								num10 = (int?)proficiency6;
								if ((num10.HasValue ? new bool?(num10.GetValueOrDefault() == 4) : null).GetValueOrDefault())
								{
									num7 = 60.96f;
								}
								break;
							}
							case 5:
							{
								if (!(weatherAtThisTimeAndPlace.RainfallRate < 5f) || (int)Size > 30)
								{
									break;
								}
								GlobalVariables.ProficiencyLevel? proficiency = Proficiency;
								int? num8 = (int?)proficiency;
								if ((num8.HasValue ? new bool?(num8.GetValueOrDefault() == 0) : null).GetValueOrDefault())
								{
									break;
								}
								num8 = (int?)proficiency;
								if ((num8.HasValue ? new bool?(num8.GetValueOrDefault() == 1) : null).GetValueOrDefault())
								{
									break;
								}
								num8 = (int?)proficiency;
								if ((num8.HasValue ? new bool?(num8.GetValueOrDefault() == 2) : null).GetValueOrDefault())
								{
									num7 = 121.92f;
									break;
								}
								num8 = (int?)proficiency;
								if ((num8.HasValue ? new bool?(num8.GetValueOrDefault() == 3) : null).GetValueOrDefault())
								{
									num7 = 91.44f;
									break;
								}
								num8 = (int?)proficiency;
								if ((num8.HasValue ? new bool?(num8.GetValueOrDefault() == 4) : null).GetValueOrDefault())
								{
									num7 = 60.96f;
								}
								break;
							}
							case 6:
							case 7:
							case 8:
							case 9:
							case 10:
								break;
							}
							break;
						case _AircraftCategory.Tiltrotor:
						{
							Throttle throttleSetting13 = ThrottleSetting;
							if (1 == 0)
							{
							}
							float num16 = throttleSetting13 switch
							{
								Throttle.Loiter => 15.24f, 
								Throttle.FullStop => 15.24f, 
								_ => TerrainAvoidanceCapability ? 91.44f : (TerrainFollowingCapability ? 60.96f : 152.4f), 
							};
							if (1 == 0)
							{
							}
							num7 = num16;
							break;
						}
						case _AircraftCategory.Helicopter:
							switch (weatherAtThisTimeAndPlace.SeaState)
							{
							case 0:
							{
								Throttle throttleSetting7 = ThrottleSetting;
								if (1 == 0)
								{
								}
								float num16 = throttleSetting7 switch
								{
									Throttle.Loiter => 15.24f, 
									Throttle.FullStop => 15.24f, 
									_ => 30.48f, 
								};
								if (1 == 0)
								{
								}
								num7 = num16;
								break;
							}
							case 1:
							{
								Throttle throttleSetting8 = ThrottleSetting;
								if (1 == 0)
								{
								}
								float num16 = throttleSetting8 switch
								{
									Throttle.Loiter => 15.24f, 
									Throttle.FullStop => 15.24f, 
									_ => 30.48f, 
								};
								if (1 == 0)
								{
								}
								num7 = num16;
								break;
							}
							case 2:
							{
								Throttle throttleSetting3 = ThrottleSetting;
								if (1 == 0)
								{
								}
								float num16 = throttleSetting3 switch
								{
									Throttle.Loiter => 15.24f, 
									Throttle.FullStop => 15.24f, 
									_ => 30.48f, 
								};
								if (1 == 0)
								{
								}
								num7 = num16;
								break;
							}
							case 3:
							{
								Throttle throttleSetting11 = ThrottleSetting;
								if (1 == 0)
								{
								}
								float num16 = throttleSetting11 switch
								{
									Throttle.Loiter => 15.24f, 
									Throttle.FullStop => 15.24f, 
									_ => 30.48f, 
								};
								if (1 == 0)
								{
								}
								num7 = num16;
								break;
							}
							case 4:
							{
								Throttle throttleSetting12 = ThrottleSetting;
								if (1 == 0)
								{
								}
								float num16 = throttleSetting12 switch
								{
									Throttle.Loiter => 15.24f, 
									Throttle.FullStop => 15.24f, 
									_ => 30.48f, 
								};
								if (1 == 0)
								{
								}
								num7 = num16;
								break;
							}
							case 5:
							{
								Throttle throttleSetting5 = ThrottleSetting;
								if (1 == 0)
								{
								}
								float num16 = throttleSetting5 switch
								{
									Throttle.Loiter => 15.24f, 
									Throttle.FullStop => 15.24f, 
									_ => 45.72f, 
								};
								if (1 == 0)
								{
								}
								num7 = num16;
								break;
							}
							case 6:
							{
								Throttle throttleSetting9 = ThrottleSetting;
								if (1 == 0)
								{
								}
								float num16 = throttleSetting9 switch
								{
									Throttle.Loiter => 15.24f, 
									Throttle.FullStop => 15.24f, 
									_ => 45.72f, 
								};
								if (1 == 0)
								{
								}
								num7 = num16;
								break;
							}
							case 7:
							{
								Throttle throttleSetting4 = ThrottleSetting;
								if (1 == 0)
								{
								}
								float num16 = throttleSetting4 switch
								{
									Throttle.Loiter => 15.24f, 
									Throttle.FullStop => 15.24f, 
									_ => 60.96f, 
								};
								if (1 == 0)
								{
								}
								num7 = num16;
								break;
							}
							case 8:
							{
								Throttle throttleSetting10 = ThrottleSetting;
								if (1 == 0)
								{
								}
								float num16 = throttleSetting10 switch
								{
									Throttle.Loiter => 15.24f, 
									Throttle.FullStop => 15.24f, 
									_ => 60.96f, 
								};
								if (1 == 0)
								{
								}
								num7 = num16;
								break;
							}
							case 9:
							{
								Throttle throttleSetting6 = ThrottleSetting;
								if (1 == 0)
								{
								}
								float num16 = throttleSetting6 switch
								{
									Throttle.Loiter => 15.24f, 
									Throttle.FullStop => 15.24f, 
									_ => 60.96f, 
								};
								if (1 == 0)
								{
								}
								num7 = num16;
								break;
							}
							case 10:
							{
								Throttle throttleSetting2 = ThrottleSetting;
								if (1 == 0)
								{
								}
								float num16 = throttleSetting2 switch
								{
									Throttle.Loiter => 15.24f, 
									Throttle.FullStop => 15.24f, 
									_ => 60.96f, 
								};
								if (1 == 0)
								{
								}
								num7 = num16;
								break;
							}
							}
							break;
						}
					}
				}
				else if (flag2)
				{
					if ((uint)(Category - 2003) <= 1u)
					{
						switch (weatherAtThisTimeAndPlace.SeaState)
						{
						case 0:
							num7 = 15.24f;
							break;
						case 1:
							num7 = 15.24f;
							break;
						case 2:
							num7 = 15.24f;
							break;
						case 3:
							num7 = 15.24f;
							break;
						case 4:
							num7 = 15.24f;
							break;
						case 5:
							num7 = 15.24f;
							break;
						case 6:
						{
							Throttle throttleSetting17 = ThrottleSetting;
							if (1 == 0)
							{
							}
							float num16 = throttleSetting17 switch
							{
								Throttle.Loiter => 15.24f, 
								Throttle.FullStop => 15.24f, 
								_ => 30.48f, 
							};
							if (1 == 0)
							{
							}
							num7 = num16;
							break;
						}
						case 7:
						{
							Throttle throttleSetting15 = ThrottleSetting;
							if (1 == 0)
							{
							}
							float num16 = throttleSetting15 switch
							{
								Throttle.Loiter => 15.24f, 
								Throttle.FullStop => 15.24f, 
								_ => 30.48f, 
							};
							if (1 == 0)
							{
							}
							num7 = num16;
							break;
						}
						case 8:
						{
							Throttle throttleSetting18 = ThrottleSetting;
							if (1 == 0)
							{
							}
							float num16 = throttleSetting18 switch
							{
								Throttle.Loiter => 15.24f, 
								Throttle.FullStop => 15.24f, 
								_ => 60.96f, 
							};
							if (1 == 0)
							{
							}
							num7 = num16;
							break;
						}
						case 9:
						{
							Throttle throttleSetting16 = ThrottleSetting;
							if (1 == 0)
							{
							}
							float num16 = throttleSetting16 switch
							{
								Throttle.Loiter => 15.24f, 
								Throttle.FullStop => 15.24f, 
								_ => 60.96f, 
							};
							if (1 == 0)
							{
							}
							num7 = num16;
							break;
						}
						case 10:
						{
							Throttle throttleSetting14 = ThrottleSetting;
							if (1 == 0)
							{
							}
							float num16 = throttleSetting14 switch
							{
								Throttle.Loiter => 15.24f, 
								Throttle.FullStop => 15.24f, 
								_ => 60.96f, 
							};
							if (1 == 0)
							{
							}
							num7 = num16;
							break;
						}
						}
					}
					else if (!TerrainAvoidanceCapability && !TerrainFollowingCapability)
					{
						num7 = 91.44f;
						switch (weatherAtThisTimeAndPlace.SeaState)
						{
						default:
							throw new NotImplementedException();
						case 0:
						{
							if (!(weatherAtThisTimeAndPlace.RainfallRate < 5f) || (int)Size > 30)
							{
								break;
							}
							GlobalVariables.ProficiencyLevel? proficiency3 = Proficiency;
							int? num5 = (int?)proficiency3;
							if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 0) : null).GetValueOrDefault())
							{
								num7 = 45.72f;
								break;
							}
							num5 = (int?)proficiency3;
							if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 1) : null).GetValueOrDefault())
							{
								num7 = 30.48f;
								break;
							}
							num5 = (int?)proficiency3;
							if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 2) : null).GetValueOrDefault())
							{
								num7 = 24.383999f;
								break;
							}
							num5 = (int?)proficiency3;
							if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 3) : null).GetValueOrDefault())
							{
								num7 = 24.383999f;
								break;
							}
							num5 = (int?)proficiency3;
							if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								num7 = 24.383999f;
							}
							break;
						}
						case 1:
						{
							if (!(weatherAtThisTimeAndPlace.RainfallRate < 5f) || (int)Size > 30)
							{
								break;
							}
							GlobalVariables.ProficiencyLevel? proficiency11 = Proficiency;
							int? num2 = (int?)proficiency11;
							if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
							{
								num7 = 45.72f;
								break;
							}
							num2 = (int?)proficiency11;
							if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 1) : null).GetValueOrDefault())
							{
								num7 = 30.48f;
								break;
							}
							num2 = (int?)proficiency11;
							if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 2) : null).GetValueOrDefault())
							{
								num7 = 24.383999f;
								break;
							}
							num2 = (int?)proficiency11;
							if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 3) : null).GetValueOrDefault())
							{
								num7 = 24.383999f;
								break;
							}
							num2 = (int?)proficiency11;
							if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								num7 = 24.383999f;
							}
							break;
						}
						case 2:
						{
							if (!(weatherAtThisTimeAndPlace.RainfallRate < 5f) || (int)Size > 30)
							{
								break;
							}
							GlobalVariables.ProficiencyLevel? proficiency4 = Proficiency;
							int? num6 = (int?)proficiency4;
							if ((num6.HasValue ? new bool?(num6.GetValueOrDefault() == 0) : null).GetValueOrDefault())
							{
								num7 = 45.72f;
								break;
							}
							num6 = (int?)proficiency4;
							if ((num6.HasValue ? new bool?(num6.GetValueOrDefault() == 1) : null).GetValueOrDefault())
							{
								num7 = 30.48f;
								break;
							}
							num6 = (int?)proficiency4;
							if ((num6.HasValue ? new bool?(num6.GetValueOrDefault() == 2) : null).GetValueOrDefault())
							{
								num7 = 24.383999f;
								break;
							}
							num6 = (int?)proficiency4;
							if ((num6.HasValue ? new bool?(num6.GetValueOrDefault() == 3) : null).GetValueOrDefault())
							{
								num7 = 24.383999f;
								break;
							}
							num6 = (int?)proficiency4;
							if ((num6.HasValue ? new bool?(num6.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								num7 = 24.383999f;
							}
							break;
						}
						case 3:
						{
							if (!(weatherAtThisTimeAndPlace.RainfallRate < 5f) || (int)Size > 30)
							{
								break;
							}
							GlobalVariables.ProficiencyLevel? proficiency12 = Proficiency;
							int? num3 = (int?)proficiency12;
							if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 0) : null).GetValueOrDefault())
							{
								num7 = 45.72f;
								break;
							}
							num3 = (int?)proficiency12;
							if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 1) : null).GetValueOrDefault())
							{
								num7 = 30.48f;
								break;
							}
							num3 = (int?)proficiency12;
							if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 2) : null).GetValueOrDefault())
							{
								num7 = 24.383999f;
								break;
							}
							num3 = (int?)proficiency12;
							if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 3) : null).GetValueOrDefault())
							{
								num7 = 24.383999f;
								break;
							}
							num3 = (int?)proficiency12;
							if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								num7 = 24.383999f;
							}
							break;
						}
						case 4:
						{
							if (!(weatherAtThisTimeAndPlace.RainfallRate < 5f) || (int)Size > 30)
							{
								break;
							}
							GlobalVariables.ProficiencyLevel? proficiency2 = Proficiency;
							int? num4 = (int?)proficiency2;
							if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 0) : null).GetValueOrDefault())
							{
								num7 = 45.72f;
								break;
							}
							num4 = (int?)proficiency2;
							if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 1) : null).GetValueOrDefault())
							{
								num7 = 30.48f;
								break;
							}
							num4 = (int?)proficiency2;
							if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 2) : null).GetValueOrDefault())
							{
								num7 = 24.383999f;
								break;
							}
							num4 = (int?)proficiency2;
							if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 3) : null).GetValueOrDefault())
							{
								num7 = 24.383999f;
								break;
							}
							num4 = (int?)proficiency2;
							if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								num7 = 24.383999f;
							}
							break;
						}
						case 5:
						{
							if (!(weatherAtThisTimeAndPlace.RainfallRate < 5f) || (int)Size > 30)
							{
								break;
							}
							GlobalVariables.ProficiencyLevel? proficiency10 = Proficiency;
							int? num14 = (int?)proficiency10;
							if ((num14.HasValue ? new bool?(num14.GetValueOrDefault() == 0) : null).GetValueOrDefault())
							{
								num7 = 45.72f;
								break;
							}
							num14 = (int?)proficiency10;
							if ((num14.HasValue ? new bool?(num14.GetValueOrDefault() == 1) : null).GetValueOrDefault())
							{
								num7 = 45.72f;
								break;
							}
							num14 = (int?)proficiency10;
							if ((num14.HasValue ? new bool?(num14.GetValueOrDefault() == 2) : null).GetValueOrDefault())
							{
								num7 = 30.48f;
								break;
							}
							num14 = (int?)proficiency10;
							if ((num14.HasValue ? new bool?(num14.GetValueOrDefault() == 3) : null).GetValueOrDefault())
							{
								num7 = 30.48f;
								break;
							}
							num14 = (int?)proficiency10;
							if ((num14.HasValue ? new bool?(num14.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								num7 = 24.383999f;
							}
							break;
						}
						case 6:
						case 7:
						case 8:
						case 9:
						case 10:
							break;
						}
					}
					else
					{
						num7 = 30.48f;
						switch (weatherAtThisTimeAndPlace.SeaState)
						{
						default:
							throw new NotImplementedException();
						case 8:
							num7 = 60.96f;
							break;
						case 9:
							num7 = 60.96f;
							break;
						case 10:
							num7 = 60.96f;
							break;
						case 0:
						case 1:
						case 2:
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
							break;
						}
					}
				}
				else if ((uint)(Category - 2003) <= 1u)
				{
					switch (weatherAtThisTimeAndPlace.SeaState)
					{
					case 0:
					{
						Throttle throttleSetting24 = ThrottleSetting;
						if (1 == 0)
						{
						}
						float num16 = throttleSetting24 switch
						{
							Throttle.Loiter => 15.24f, 
							Throttle.FullStop => 15.24f, 
							_ => 30.48f, 
						};
						if (1 == 0)
						{
						}
						num7 = num16;
						break;
					}
					case 1:
					{
						Throttle throttleSetting25 = ThrottleSetting;
						if (1 == 0)
						{
						}
						float num16 = throttleSetting25 switch
						{
							Throttle.Loiter => 15.24f, 
							Throttle.FullStop => 15.24f, 
							_ => 30.48f, 
						};
						if (1 == 0)
						{
						}
						num7 = num16;
						break;
					}
					case 2:
					{
						Throttle throttleSetting20 = ThrottleSetting;
						if (1 == 0)
						{
						}
						float num16 = throttleSetting20 switch
						{
							Throttle.Loiter => 15.24f, 
							Throttle.FullStop => 15.24f, 
							_ => 30.48f, 
						};
						if (1 == 0)
						{
						}
						num7 = num16;
						break;
					}
					case 3:
					{
						Throttle throttleSetting28 = ThrottleSetting;
						if (1 == 0)
						{
						}
						float num16 = throttleSetting28 switch
						{
							Throttle.Loiter => 15.24f, 
							Throttle.FullStop => 15.24f, 
							_ => 30.48f, 
						};
						if (1 == 0)
						{
						}
						num7 = num16;
						break;
					}
					case 4:
					{
						Throttle throttleSetting29 = ThrottleSetting;
						if (1 == 0)
						{
						}
						float num16 = throttleSetting29 switch
						{
							Throttle.Loiter => 15.24f, 
							Throttle.FullStop => 15.24f, 
							_ => 30.48f, 
						};
						if (1 == 0)
						{
						}
						num7 = num16;
						break;
					}
					case 5:
					{
						Throttle throttleSetting22 = ThrottleSetting;
						if (1 == 0)
						{
						}
						float num16 = throttleSetting22 switch
						{
							Throttle.Loiter => 15.24f, 
							Throttle.FullStop => 15.24f, 
							_ => 30.48f, 
						};
						if (1 == 0)
						{
						}
						num7 = num16;
						break;
					}
					case 6:
					{
						Throttle throttleSetting26 = ThrottleSetting;
						if (1 == 0)
						{
						}
						float num16 = throttleSetting26 switch
						{
							Throttle.Loiter => 15.24f, 
							Throttle.FullStop => 15.24f, 
							_ => 30.48f, 
						};
						if (1 == 0)
						{
						}
						num7 = num16;
						break;
					}
					case 7:
					{
						Throttle throttleSetting21 = ThrottleSetting;
						if (1 == 0)
						{
						}
						float num16 = throttleSetting21 switch
						{
							Throttle.Loiter => 15.24f, 
							Throttle.FullStop => 15.24f, 
							_ => 60.96f, 
						};
						if (1 == 0)
						{
						}
						num7 = num16;
						break;
					}
					case 8:
					{
						Throttle throttleSetting27 = ThrottleSetting;
						if (1 == 0)
						{
						}
						float num16 = throttleSetting27 switch
						{
							Throttle.Loiter => 15.24f, 
							Throttle.FullStop => 15.24f, 
							_ => 60.96f, 
						};
						if (1 == 0)
						{
						}
						num7 = num16;
						break;
					}
					case 9:
					{
						Throttle throttleSetting23 = ThrottleSetting;
						if (1 == 0)
						{
						}
						float num16 = throttleSetting23 switch
						{
							Throttle.Loiter => 15.24f, 
							Throttle.FullStop => 15.24f, 
							_ => 60.96f, 
						};
						if (1 == 0)
						{
						}
						num7 = num16;
						break;
					}
					case 10:
					{
						Throttle throttleSetting19 = ThrottleSetting;
						if (1 == 0)
						{
						}
						float num16 = throttleSetting19 switch
						{
							Throttle.Loiter => 15.24f, 
							Throttle.FullStop => 15.24f, 
							_ => 60.96f, 
						};
						if (1 == 0)
						{
						}
						num7 = num16;
						break;
					}
					}
				}
				else if (!TerrainAvoidanceCapability && !TerrainFollowingCapability)
				{
					num7 = 91.44f;
					int seaState = weatherAtThisTimeAndPlace.SeaState;
					if ((uint)seaState > 10u)
					{
						throw new NotImplementedException();
					}
				}
				else
				{
					num7 = 30.48f;
					switch (weatherAtThisTimeAndPlace.SeaState)
					{
					default:
						throw new NotImplementedException();
					case 8:
						num7 = 60.96f;
						break;
					case 9:
						num7 = 60.96f;
						break;
					case 10:
						num7 = 60.96f;
						break;
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
						break;
					}
				}
				return (float)num + num7;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100366", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				float? result = 15.24f;
				ProjectData.ClearProjectError();
				return result;
			}
		}
		set
		{
			try
			{
				callbackObserver = value;
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

	public override float Fuel_FreeLoad
	{
		get
		{
			float result = 0f;
			try
			{
				float num = 0f;
				foreach (FuelRec item in Fuel_ReadOnly)
				{
					num += (float)item.MaxQuantity - item.CurrentQuantity;
				}
				result = num;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100369", "");
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

	public override bool IsPlatform => true;

	public int CurrentNonEmptyWeight
	{
		get
		{
			int num = 0;
			if (Loadout != null)
			{
				num = Loadout.PayloadWeight;
			}
			int num2 = 0;
			foreach (FuelRec item in new List<FuelRec>(Fuel_ReadOnly))
			{
				if (item != null)
				{
					num2 += (int)Math.Round(item.CurrentQuantity);
				}
			}
			return num + num2;
		}
	}

	public int AirshowWeight
	{
		get
		{
			int num = 0;
			foreach (FuelRec item in _Fuel)
			{
				num += (int)Math.Round((double)item.CurrentQuantity * 0.6);
			}
			return EmptyWeight + num;
		}
	}

	public float WeightFraction
	{
		get
		{
			if (CurrentNonEmptyWeight == 0)
			{
				return 0f;
			}
			int num = EmptyWeight + CurrentNonEmptyWeight;
			int num2 = MaxWeight - AirshowWeight;
			float num3 = (float)Math.Min(0.99, (double)(num - AirshowWeight) / (double)num2);
			if (num3 < 0f)
			{
				num3 = 0f;
			}
			return num3;
		}
	}

	public Cargo[] CargoArray
	{
		get
		{
			return OnboardCargo;
		}
		set
		{
			OnboardCargo = value;
		}
	}

	public override bool RepresentsMobileGroundUnit => false;

	static Aircraft()
	{
		EMERGENCY_LANDING_DISTANCE_NM = 20f;
	}

	[SpecialName]
	public override int GetMastHeight_Radar(Sensor sensor_0 = null)
	{
		if (sensor_0 != null && sensor_0.MastHeight != 0)
		{
			return sensor_0.MastHeight;
		}
		return 0;
	}

	[SpecialName]
	public override int GetMastHeight_Visual(Sensor sensor_0 = null)
	{
		if (sensor_0 != null && sensor_0.MastHeight != 0)
		{
			return sensor_0.MastHeight;
		}
		return 0;
	}

	public override bool IsExhausted()
	{
		if (Crew == 0)
		{
			return false;
		}
		return Current_Exhaustion >= MAX_Exhaustion;
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		if (GetUnitSide() == null)
		{
			return;
		}
		xmlWriter_0.WriteStartElement("Aircraft");
		xmlWriter_0.WriteElementString("ID", ObjectID);
		if (hashSet_0.Contains(ObjectID))
		{
			xmlWriter_0.WriteEndElement();
			return;
		}
		hashSet_0.Add(ObjectID);
		try
		{
			method_0(ref xmlWriter_0);
			xmlWriter_0.WriteElementString("Name", Name.Replace("\0", "").Replace("\u0010", ""));
			if (ChanceOfAppearance != 0)
			{
				xmlWriter_0.WriteElementString("COA", Conversions.ToString(ChanceOfAppearance));
			}
			xmlWriter_0.WriteElementString("CH", XmlConvert.ToString(CurrentHeading));
			xmlWriter_0.WriteElementString("CS", XmlConvert.ToString(CurrentSpeed));
			xmlWriter_0.WriteElementString("CA", XmlConvert.ToString(GetCurrentAltitude()));
			xmlWriter_0.WriteElementString("Lon", XmlConvert.ToString(_Longitude));
			xmlWriter_0.WriteElementString("Lat", XmlConvert.ToString(_Latitude));
			if (base.Longitude_LastReported.HasValue)
			{
				xmlWriter_0.WriteElementString("LonLR", XmlConvert.ToString(base.Longitude_LastReported.Value));
			}
			if (base.Latitude_LastReported.HasValue)
			{
				xmlWriter_0.WriteElementString("LatLR", XmlConvert.ToString(base.Latitude_LastReported.Value));
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
			xmlWriter_0.WriteElementString("Side", GetUnitSide().Name);
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
			if (DesiredAltitude_AGL != 0f)
			{
				xmlWriter_0.WriteElementString("DesiredAltitude_TerrainFollowing", XmlConvert.ToString(DesiredAltitude_AGL));
			}
			if (GetDesiredAltitude_UseTerrainFollowing(this))
			{
				xmlWriter_0.WriteElementString("TerrainFollowing", GetDesiredAltitude_UseTerrainFollowing(this).ToString());
				if (TerrainFollowingType != 0)
				{
					XmlWriter obj = xmlWriter_0;
					int terrainFollowingType = (int)TerrainFollowingType;
					obj.WriteElementString("TerrainFollowingType", terrainFollowingType.ToString());
				}
			}
			XmlWriter obj6 = xmlWriter_0;
			byte flightRole = (byte)FlightRole;
			obj6.WriteElementString("FlightRole", flightRole.ToString());
			xmlWriter_0.WriteElementString("Thr", ((byte)ThrottleSetting).ToString());
			xmlWriter_0.WriteElementString("AbnTime", XmlConvert.ToString(AirborneTime));
			if (_Proficiency.HasValue)
			{
				xmlWriter_0.WriteElementString("Prof", ((int)_Proficiency.Value).ToString());
			}
			if (((base.Sensors_Cached == null) ? Sensors_ReadOnly() : base.Sensors_Cached).Length != 0)
			{
				xmlWriter_0.WriteStartElement("Sensors");
				Sensor[] sensors = _Sensors;
				Sensor[] array = sensors;
				foreach (Sensor sensor in array)
				{
					xmlWriter_0.WriteRaw(sensor.ToXML(hashSet_0));
				}
				xmlWriter_0.WriteEndElement();
				if (Loadout != null)
				{
					List<Sensor> list = Loadout.NewClass(ParentScen);
					if (list.Count > 0)
					{
						xmlWriter_0.WriteStartElement("PoddedSensors");
						foreach (Sensor item in list)
						{
							HashSet<string> hashSet_ = new HashSet<string>();
							xmlWriter_0.WriteRaw(item.ToXML(hashSet_));
						}
						xmlWriter_0.WriteEndElement();
					}
				}
			}
			if (Comms_ReadOnly.Length != 0)
			{
				xmlWriter_0.WriteStartElement("Comms");
				CommDevice[] comms = _Comms;
				CommDevice[] array2 = comms;
				foreach (CommDevice commDevice in array2)
				{
					xmlWriter_0.WriteRaw(commDevice.ToXML(ref hashSet_0));
				}
				xmlWriter_0.WriteEndElement();
			}
			if (Propulsion.Count > 0)
			{
				xmlWriter_0.WriteStartElement("Propulsion");
				foreach (Engine item2 in Propulsion)
				{
					xmlWriter_0.WriteRaw(item2.ToXML(hashSet_0));
				}
				xmlWriter_0.WriteEndElement();
			}
			if (_Fuel.Count > 0)
			{
				xmlWriter_0.WriteStartElement("Fuel");
				foreach (FuelRec item3 in _Fuel)
				{
					xmlWriter_0.WriteRaw(item3.ToXML());
				}
				xmlWriter_0.WriteEndElement();
			}
			if (Mounts.Count > 0)
			{
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
			}
			if (OnboardCargo.Count() > 0)
			{
				xmlWriter_0.WriteStartElement("OnboardCargo");
				Cargo[] onboardCargo = OnboardCargo;
				Cargo[] array3 = onboardCargo;
				foreach (Cargo cargo in array3)
				{
					xmlWriter_0.WriteRaw(cargo.ToXML(hashSet_0, ParentScen));
				}
				xmlWriter_0.WriteEndElement();
			}
			XmlWriter obj7 = xmlWriter_0;
			flightRole = (byte)_Status;
			obj7.WriteElementString("Status", flightRole.ToString());
			XmlWriter obj8 = xmlWriter_0;
			flightRole = (byte)_FuelState;
			obj8.WriteElementString("FuelState", flightRole.ToString());
			XmlWriter obj9 = xmlWriter_0;
			flightRole = (byte)_WeaponState;
			obj9.WriteElementString("WeaponState", flightRole.ToString());
			if (predicateVal != 0)
			{
				XmlWriter obj10 = xmlWriter_0;
				flightRole = (byte)predicateVal;
				obj10.WriteElementString("SBR", flightRole.ToString());
			}
			if (_SingletonVal != 0)
			{
				XmlWriter obj11 = xmlWriter_0;
				flightRole = (byte)_SingletonVal;
				obj11.WriteElementString("SBED", flightRole.ToString());
			}
			if (_RecordVal != 0)
			{
				XmlWriter obj12 = xmlWriter_0;
				flightRole = (byte)_RecordVal;
				obj12.WriteElementString("SBEO", flightRole.ToString());
			}
			if (comparatorVal != 0)
			{
				XmlWriter obj13 = xmlWriter_0;
				flightRole = (byte)comparatorVal;
				obj13.WriteElementString("FSBR", flightRole.ToString());
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
			XmlWriter obj2 = xmlWriter_0;
			flightRole = (byte)_TemplateVal;
			obj2.WriteElementString("SBR_ThrottleSetting", flightRole.ToString());
			xmlWriter_0.WriteElementString("SBED_Altitude", XmlConvert.ToString(m_MappingVal));
			if (m_MockVal.HasValue)
			{
				xmlWriter_0.WriteElementString("SBED_Altitude_TF", XmlConvert.ToString(m_MockVal.Value));
			}
			xmlWriter_0.WriteElementString("SBED_TF", XmlConvert.ToString(tagVal));
			XmlWriter obj3 = xmlWriter_0;
			flightRole = (byte)fieldVal;
			obj3.WriteElementString("SBED_ThrottleSetting", flightRole.ToString());
			if (queueVal.HasValue)
			{
				xmlWriter_0.WriteElementString("SBED_DesiredSpeedOverride", XmlConvert.ToString(queueVal.Value));
			}
			xmlWriter_0.WriteElementString("SBEO_Altitude", XmlConvert.ToString(regVal));
			xmlWriter_0.WriteElementString("SBEO_Altitude_TF", XmlConvert.ToString(paramVal));
			xmlWriter_0.WriteElementString("SBEO_TF", XmlConvert.ToString(m_PageVal));
			if (m_RulesVal != 0)
			{
				XmlWriter obj4 = xmlWriter_0;
				flightRole = (byte)m_RulesVal;
				obj4.WriteElementString("SBEO_ThrottleSetting", flightRole.ToString());
			}
			xmlWriter_0.WriteElementString("SBPF_Altitude", XmlConvert.ToString(_MethodVal));
			xmlWriter_0.WriteElementString("SBPF_Altitude_TF", XmlConvert.ToString(serviceVal));
			xmlWriter_0.WriteElementString("SBPF_TF", XmlConvert.ToString(m_SystemVal));
			XmlWriter obj5 = xmlWriter_0;
			flightRole = (byte)candidateVal;
			obj5.WriteElementString("SBPF_ThrottleSetting", flightRole.ToString());
			xmlWriter_0.WriteElementString("AMP_OC", m_AttrVal.ToString());
			if (_VisitorVal.HasValue)
			{
				xmlWriter_0.WriteElementString("AMP_OC_DSO", _VisitorVal.ToString());
			}
			xmlWriter_0.WriteElementString("AMP_OC_DAO", _ExporterVal.ToString());
			xmlWriter_0.WriteElementString("AMP_OC_Speed", XmlConvert.ToString(m_PrototypeVal));
			xmlWriter_0.WriteElementString("DamagePts", XmlConvert.ToString(GetDamagePts()));
			xmlWriter_0.WriteElementString("OldDamagePercent", XmlConvert.ToString(utilsVal));
			if (EligibleForSAR)
			{
				xmlWriter_0.WriteElementString("EFSAR", XmlConvert.ToString(EligibleForSAR));
			}
			if (IsBeingPickedUp)
			{
				xmlWriter_0.WriteElementString("IBPU", XmlConvert.ToString(IsBeingPickedUp));
			}
			if (Attitude_Pitch != 0f)
			{
				xmlWriter_0.WriteElementString("Pitch", XmlConvert.ToString(Attitude_Pitch));
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
			if (Loadout != null)
			{
				xmlWriter_0.WriteStartElement("Loadout");
				xmlWriter_0.WriteRaw(workerWrapper.ToXML(ref hashSet_0, ParentScen));
				xmlWriter_0.WriteEndElement();
			}
			Navigator.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteStartElement("AI");
			if (AI.m_EventVal == null)
			{
				AI.m_EventVal = this;
			}
			AI.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Kinematics");
			Kinematics.ToXML(ref xmlWriter_0);
			xmlWriter_0.WriteEndElement();
			Sensory.ToXML(ref xmlWriter_0);
			Weaponry.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteStartElement("CommStuff");
			CommStuff.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteEndElement();
			Damage.ToXML(ref xmlWriter_0, ref hashSet_0);
			AirOps.ToXML(ref xmlWriter_0, ref hashSet_0);
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
			exception_?.Data.Add("Error at 100348", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private Aircraft()
		: base(ref decoratorObserver)
	{
		G_Tolerance = 45f;
		ShouldDropSonobuoysOnThisPulse = false;
		Armor_Cockpit = GlobalVariables.ArmorRating.None;
		Armor_Fuselage = GlobalVariables.ArmorRating.None;
		Armor_Powerplant = GlobalVariables.ArmorRating.None;
		FuelState_RemainingFuelToBingo = 0f;
		FuelState_RemainingFuelToJoker = 0f;
		VisibilityForward = CockpitVisibility.Excellent;
		VisibilitySideways = CockpitVisibility.Excellent;
		VisibilityAft = CockpitVisibility.Excellent;
		ActiveUnit activeUnit_ = this;
		_InfoWrapper = new Aircraft_Navigator(ref activeUnit_);
		activeUnit_ = this;
		m_HelperWrapper = new Aircraft_AI(ref activeUnit_);
		activeUnit_ = this;
		mapperWrapper = new Aircraft_Kinematics(ref activeUnit_);
		IsAircraft = true;
		activeUnit_ = this;
		structObserver = new Aircraft_AirOps(ref activeUnit_);
	}

	public new static Aircraft FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		Aircraft aircraft = null;
		try
		{
			aircraft = ViewFacade(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0, scenario_0.LoadStockUnits);
		}
		catch (PlatformComponentNotFoundException projectError)
		{
			ProjectData.SetProjectError(projectError);
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			ConcurrentDictionary<string, ScenarioObject> obj = concurrentDictionary_0;
			ScenarioObject value = aircraft;
			obj.TryRemove(innerText, out value);
			aircraft = ViewFacade(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0, bool_1: true);
			string text = "";
			if (aircraft.IsGroupMember())
			{
				text = "(member of group: [" + aircraft.GetParentGroup().Name + "])";
			}
			scenario_0.LoadingNotices.Add("The following aircraft:[" + aircraft.Name + "]" + text + " failed to shallow-rebuild because of a component missing. The aircraft was instead deep-rebuilt, and instantiated in its pristine DB-stock condition. All customizations present in the aircraft's components (damaged components, weapon additions/removals etc. etc.) have been lost. Please re-apply any necessary customizations either manually or using an SBR script.");
			ProjectData.ClearProjectError();
		}
		if (aircraft.IsUnderground)
		{
			aircraft.SetCurrentAltitude(bool_1: false, Terrain.GetElevation(aircraft.GetLatitude(), aircraft.GetLongitude(), bool_0: false, aircraft.ParentScen) + 1);
		}
		return aircraft;
	}

	private static Aircraft ViewFacade(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0, bool bool_1)
	{
		Aircraft aircraft_ = new Aircraft();
		Sensor[] gparam_ = new Sensor[0];
		try
		{
			aircraft_.ParentScen = scenario_0;
			string text = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (Misc.CreateRequest(text, ' '))
			{
				text = text.Replace(" ", "-");
			}
			if (concurrentDictionary_0.ContainsKey(text))
			{
				return (Aircraft)concurrentDictionary_0[text];
			}
			aircraft_.ObjectID_Set(text);
			if (xmlNode_0.ChildNodes.Count == 1)
			{
				scenario_0.UnitsForLateInstantiation.Add(xmlNode_0);
				return aircraft_;
			}
			concurrentDictionary_0.TryAdd(aircraft_.ObjectID, aircraft_);
			int num = Conversions.ToInteger(Misc.StartRequest(xmlNode_0.ChildNodes, "DBID").InnerText);
			try
			{
				DBFunctions.GetAircraft(ref scenario_0, ref aircraft_, num, bool_1);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ConcurrentDictionary<string, ScenarioObject> obj = concurrentDictionary_0;
				string objectID = aircraft_.ObjectID;
				ScenarioObject value = aircraft_;
				obj.TryRemove(objectID, out value);
				scenario_0.LoadingNotices.Add("具有数据库ID的飞机" + Conversions.ToString(num) + "在数据库中缺少因此未能加载。");
				ProjectData.ClearProjectError();
				return null;
			}
			if (bool_1)
			{
				aircraft_.RegisterIssuer(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0);
			}
			if (!bool_1)
			{
				IEnumerator enumerator = null;
				try
				{
					enumerator = xmlNode_0.ChildNodes.GetEnumerator();
					IEnumerator enumerator5 = null;
					IEnumerator enumerator6 = null;
					IEnumerator enumerator7 = null;
					IEnumerator enumerator8 = null;
					IEnumerator enumerator9 = null;
					IEnumerator enumerator10 = null;
					IEnumerator enumerator11 = null;
					IEnumerator enumerator12 = null;
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode = (XmlNode)enumerator.Current;
						aircraft_.CommonFromXML(xmlNode);
						switch (xmlNode.Name)
						{
						case "Comms":
						{
							int num2 = xmlNode.ChildNodes.Count - 1;
							for (int i = 0; i <= num2; i++)
							{
								XmlNode xmlNode_8 = xmlNode.ChildNodes[i];
								CommDevice commDevice = CommDevice.FromXML(ref xmlNode_8, ref concurrentDictionary_0, aircraft_);
								if (commDevice.DBID == 0)
								{
									Aircraft aircraft_2 = new Aircraft(ref scenario_0);
									aircraft_2.ParentScen = scenario_0;
									DBFunctions.GetAircraft(ref scenario_0, ref aircraft_2, num);
									try
									{
										commDevice = aircraft_2.Comms_ReadOnly[i];
										aircraft_2 = null;
									}
									catch (Exception ex)
									{
										ProjectData.SetProjectError(ex);
										Exception exception_ = ex;
										exception_?.Data.Add("Error at 200018", exception_.Message);
										GameGeneral.WriteExceptionsToLog(ref exception_);
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										ProjectData.ClearProjectError();
										continue;
									}
								}
								concurrentDictionary_0.TryAdd(commDevice.ObjectID, commDevice);
								aircraft_.AddCommDevice(commDevice);
								commDevice.ParentPlatform = aircraft_;
							}
							break;
						}
						case "OnboardCargo":
							try
							{
								enumerator9 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator9.MoveNext())
								{
									XmlNode xmlNode_7 = (XmlNode)enumerator9.Current;
									Cargo cargo = Cargo.FromXML(ref xmlNode_7, ref concurrentDictionary_0, scenario_0, aircraft_);
									ArrayExtensions.Add(ref aircraft_.OnboardCargo, cargo);
									cargo.ParentPlatform = aircraft_;
								}
							}
							finally
							{
								if (enumerator9 is IDisposable)
								{
									(enumerator9 as IDisposable).Dispose();
								}
							}
							break;
						case "Fuel":
							try
							{
								enumerator7 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator7.MoveNext())
								{
									XmlNode xmlNode_6 = (XmlNode)enumerator7.Current;
									FuelRec item = FuelRec.FromXML(ref xmlNode_6, ref concurrentDictionary_0);
									aircraft_._Fuel.Add(item);
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
						case "DockFacilities":
							try
							{
								enumerator6 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator6.MoveNext())
								{
									XmlNode xmlNode_5 = (XmlNode)enumerator6.Current;
									DockFacility dockFacility = DockFacility.FromXML(ref xmlNode_5, ref concurrentDictionary_0, ref scenario_0);
									aircraft_.AddDockFacility(dockFacility);
									dockFacility.ParentPlatform = aircraft_;
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
						case "Sensors":
							try
							{
								enumerator12 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator12.MoveNext())
								{
									Sensor sensor = Sensor.FromXML((XmlNode)enumerator12.Current, concurrentDictionary_0, aircraft_);
									ArrayExtensions.Add(ref aircraft_._Sensors, sensor);
									sensor.ParentPlatform = aircraft_;
								}
							}
							finally
							{
								if (enumerator12 is IDisposable)
								{
									(enumerator12 as IDisposable).Dispose();
								}
							}
							break;
						case "Propulsion":
							try
							{
								enumerator11 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator11.MoveNext())
								{
									XmlNode xmlNode_4 = (XmlNode)enumerator11.Current;
									ActiveUnit activeUnit_ = aircraft_;
									Engine engine = Engine.FromXML(ref xmlNode_4, ref concurrentDictionary_0, ref activeUnit_);
									aircraft_.Propulsion.Add(engine);
									engine.ParentPlatform = aircraft_;
								}
							}
							finally
							{
								if (enumerator11 is IDisposable)
								{
									(enumerator11 as IDisposable).Dispose();
								}
							}
							break;
						case "AirFacilities":
							try
							{
								enumerator5 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator5.MoveNext())
								{
									XmlNode xmlNode_3 = (XmlNode)enumerator5.Current;
									AirFacility airFacility = AirFacility.FromXML(ref xmlNode_3, ref concurrentDictionary_0, ref scenario_0);
									aircraft_.AddAirFacility(airFacility);
									airFacility.ParentPlatform = aircraft_;
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
						case "Mounts":
							try
							{
								enumerator8 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator8.MoveNext())
								{
									XmlNode xmlNode_2 = (XmlNode)enumerator8.Current;
									Mount mount = Mount.FromXML(ref xmlNode_2, ref concurrentDictionary_0, aircraft_);
									aircraft_.Mounts.Add(mount);
									mount.ParentPlatform = aircraft_;
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
						case "PoddedSensors":
							try
							{
								enumerator10 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator10.MoveNext())
								{
									XmlNode xmlNode_ = (XmlNode)enumerator10.Current;
									ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_ = new ConcurrentDictionary<string, ScenarioObject>();
									Sensor theAC = Sensor.FromXML(xmlNode_, concurrentDictionary_, aircraft_);
									ArrayExtensions.Add(ref gparam_, theAC);
								}
							}
							finally
							{
								if (enumerator10 is IDisposable)
								{
									(enumerator10 as IDisposable).Dispose();
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
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator3 = null;
				IEnumerator enumerator4 = null;
				bool flag = false;
				while (enumerator2.MoveNext())
				{
					XmlNode xmlNode_9 = (XmlNode)enumerator2.Current;
					switch (xmlNode_9.Name)
					{
					case "FSBR":
						aircraft_.comparatorVal = (_ActiveUnitFuelState)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "Status":
						if (Versioned.IsNumeric(xmlNode_9.InnerText))
						{
							aircraft_._Status = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_9.InnerText);
						}
						else
						{
							aircraft_._Status = (_ActiveUnitStatus)Enum.Parse(typeof(_ActiveUnitStatus), xmlNode_9.InnerText, ignoreCase: true);
						}
						if (aircraft_._Status == (_ActiveUnitStatus)9)
						{
							aircraft_.Status = _ActiveUnitStatus.RTB;
						}
						if (aircraft_._Status != _ActiveUnitStatus.Refuelling && aircraft_._Status != _ActiveUnitStatus.HeadingToRefuelPoint)
						{
							if (aircraft_._Status == _ActiveUnitStatus.EngagedDefensive)
							{
								if (aircraft_._SingletonVal == _ActiveUnitStatus.Unassigned)
								{
									aircraft_._SingletonVal = _ActiveUnitStatus.Unassigned;
									aircraft_.fieldVal = Throttle.Cruise;
									aircraft_.m_MappingVal = aircraft_.GetCurrentAltitude();
									aircraft_.m_MockVal = 0f;
									aircraft_.tagVal = false;
								}
							}
							else if (aircraft_._Status == _ActiveUnitStatus.EngagedOffensive)
							{
								if (aircraft_._RecordVal == _ActiveUnitStatus.Unassigned)
								{
									aircraft_._RecordVal = _ActiveUnitStatus.Unassigned;
									aircraft_.m_RulesVal = Throttle.Cruise;
									aircraft_.regVal = aircraft_.GetCurrentAltitude();
									aircraft_.paramVal = 0f;
									aircraft_.m_PageVal = false;
								}
							}
							else if (aircraft_._Status == _ActiveUnitStatus.WaitForPathfinder && aircraft_._RecordVal == _ActiveUnitStatus.Unassigned)
							{
								aircraft_._RecordVal = _ActiveUnitStatus.Unassigned;
								aircraft_.m_RulesVal = Throttle.Cruise;
								aircraft_.regVal = aircraft_.GetCurrentAltitude();
								aircraft_.paramVal = 0f;
								aircraft_.m_PageVal = false;
							}
						}
						else if (aircraft_.predicateVal == _ActiveUnitStatus.Unassigned)
						{
							aircraft_.predicateVal = _ActiveUnitStatus.Unassigned;
							aircraft_._TemplateVal = Throttle.Cruise;
							aircraft_._ItemVal = aircraft_.GetCurrentAltitude();
							aircraft_.setterVal = 0f;
							aircraft_._CreatorVal = false;
						}
						break;
					case "AMP_OC_Speed":
						aircraft_.m_PrototypeVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "Name":
						aircraft_.Name = xmlNode_9.InnerText;
						break;
					case "DesiredTurnRate_Navigation":
					case "DTN":
						aircraft_.DesiredTurnRate_Navigation = (Waypoint.TurnRateCategory)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "SBED_Altitude_TF":
						if (XmlConvert.ToSingle(xmlNode_9.InnerText) != 0f)
						{
							aircraft_.m_MockVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						}
						break;
					case "SBPF_TF":
						aircraft_.m_SystemVal = Conversions.ToBoolean(xmlNode_9.InnerText);
						break;
					case "LatLR":
						aircraft_.Latitude_LastReported = XmlConvert.ToDouble(xmlNode_9.InnerText.Replace(",", "."));
						break;
					case "FlightRole":
						aircraft_.FlightRole = (Mission.Flight.FlightElement)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "FuelState":
						aircraft_._FuelState = (_ActiveUnitFuelState)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "COA":
						aircraft_.ChanceOfAppearance = Conversions.ToInteger(xmlNode_9.InnerText);
						break;
					case "DamagePts":
					{
						if (bool_1)
						{
							break;
						}
						float num3 = XmlConvert.ToSingle(xmlNode_9.InnerText);
						if ((int)Math.Round(num3) <= 50 && (int)Math.Round(num3) <= aircraft_.InitialDP)
						{
							if ((int)Math.Round(num3) == 0)
							{
								aircraft_.SetDamagePts(bool_1: false, null, aircraft_.InitialDP);
							}
							else
							{
								aircraft_.SetDamagePts(bool_1: false, null, num3);
							}
						}
						else
						{
							aircraft_.SetDamagePts(bool_1: false, null, aircraft_.InitialDP);
						}
						break;
					}
					case "SBED_Altitude":
						aircraft_.m_MappingVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "OldDamagePercent":
						aircraft_.utilsVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "AMP_OC_DAO":
						aircraft_._ExporterVal = Conversions.ToBoolean(xmlNode_9.InnerText);
						break;
					case "SBPF_Altitude_TF":
						aircraft_.serviceVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "DesiredHeading":
					case "DH":
						aircraft_.SetDesiredHeading(TurnRate.Max, XmlConvert.ToSingle(xmlNode_9.InnerText));
						break;
					case "SBPF_ThrottleSetting":
						switch (xmlNode_9.InnerText)
						{
						default:
							aircraft_.candidateVal = (Throttle)Conversions.ToByte(xmlNode_9.InnerText);
							break;
						case "Loiter":
							aircraft_.candidateVal = Throttle.Loiter;
							break;
						case "FullStop":
							aircraft_.candidateVal = Throttle.FullStop;
							break;
						case "Full":
							aircraft_.candidateVal = Throttle.Full;
							break;
						case "Flank":
							aircraft_.candidateVal = Throttle.Flank;
							break;
						case "Cruise":
							aircraft_.candidateVal = Throttle.Cruise;
							break;
						}
						break;
					case "SBED_DesiredSpeedOverride":
						aircraft_.queueVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "SBR":
						aircraft_.predicateVal = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "SBR_Altitude_TF":
						aircraft_.setterVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "ActiveEnterAreaTriggers":
						try
						{
							enumerator3 = xmlNode_9.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								string innerText2 = ((XmlNode)enumerator3.Current).InnerText;
								aircraft_.ActiveEnterAreaTriggers.Add(innerText2);
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
					case "SBED_ThrottleSetting":
						switch (xmlNode_9.InnerText)
						{
						default:
							aircraft_.fieldVal = (Throttle)Conversions.ToByte(xmlNode_9.InnerText);
							break;
						case "Loiter":
							aircraft_.fieldVal = Throttle.Loiter;
							break;
						case "FullStop":
							aircraft_.fieldVal = Throttle.FullStop;
							break;
						case "Full":
							aircraft_.fieldVal = Throttle.Full;
							break;
						case "Flank":
							aircraft_.fieldVal = Throttle.Flank;
							break;
						case "Cruise":
							aircraft_.fieldVal = Throttle.Cruise;
							break;
						}
						break;
					case "Thr":
					case "ThrottleSetting":
						switch (xmlNode_9.InnerText)
						{
						default:
							aircraft_.ThrottleSetting = (Throttle)Conversions.ToByte(xmlNode_9.InnerText);
							break;
						case "Loiter":
							aircraft_.ThrottleSetting = Throttle.Loiter;
							break;
						case "FullStop":
							aircraft_.ThrottleSetting = Throttle.FullStop;
							break;
						case "Full":
							aircraft_.ThrottleSetting = Throttle.Full;
							break;
						case "Flank":
							aircraft_.ThrottleSetting = Throttle.Flank;
							break;
						case "Cruise":
							aircraft_.ThrottleSetting = Throttle.Cruise;
							break;
						}
						if (aircraft_.ThrottleSetting == Throttle.FullStop && !aircraft_.GetCanHover(bool_1: false))
						{
							aircraft_.ThrottleSetting = Throttle.Cruise;
						}
						break;
					case "Prof":
						aircraft_.Proficiency = (GlobalVariables.ProficiencyLevel)Conversions.ToInteger(xmlNode_9.InnerText);
						break;
					case "Doctrine":
						aircraft_.Doctrine = Doctrine.FromXML(ref xmlNode_9, aircraft_);
						break;
					case "SBEO_TF":
						aircraft_.m_PageVal = Conversions.ToBoolean(xmlNode_9.InnerText);
						break;
					case "WeaponState":
						aircraft_._WeaponState = (_ActiveUnitWeaponState)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "SBED_TF":
						aircraft_.tagVal = Conversions.ToBoolean(xmlNode_9.InnerText);
						break;
					case "OODA_E":
						aircraft_.HasCustomOODA = true;
						aircraft_._ResolverVal = Conversions.ToShort(xmlNode_9.InnerText);
						break;
					case "Damage":
					case "Aircraft_Damage":
					{
						Aircraft aircraft7 = aircraft_;
						ActiveUnit activeUnit_8 = aircraft_;
						aircraft7.m_ProcWrapper = Aircraft_Damage.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_8);
						break;
					}
					case "AMP_OC_DSO":
						aircraft_._VisitorVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "CurrentAltitude":
					case "CA":
						aircraft_.SetCurrentAltitude(bool_1: true, XmlConvert.ToSingle(xmlNode_9.InnerText));
						break;
					case "Latitude_UnitEntersAreaCheck":
						aircraft_.Latitude__UnitEntersAreaCheck = XmlConvert.ToDouble(xmlNode_9.InnerText);
						break;
					case "OODA_D":
						aircraft_.HasCustomOODA = true;
						aircraft_.m_TokenVal = Conversions.ToShort(xmlNode_9.InnerText);
						break;
					case "Kinematics":
					case "Aircraft_Kinematics":
						ActiveUnit_Kinematics.FromXML(xmlNode_9, concurrentDictionary_0, aircraft_);
						break;
					case "DA":
					case "DesiredAltitude":
						aircraft_.DesiredAltitude = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "Pitch":
						aircraft_.Attitude_Pitch = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "OODA_T":
						aircraft_.HasCustomOODA = true;
						aircraft_._IndexerVal = Conversions.ToShort(xmlNode_9.InnerText);
						break;
					case "AssignedMission":
						if (xmlNode_9.HasChildNodes)
						{
							XmlNode xmlNode4 = xmlNode_9.ChildNodes[0];
							aircraft_._AssignedMissionOrPackage_ID = xmlNode4.InnerText;
						}
						break;
					case "AirOps":
					case "Aircraft_AirOps":
					{
						Aircraft aircraft6 = aircraft_;
						ActiveUnit activeUnit_7 = aircraft_;
						aircraft6.structObserver = Aircraft_AirOps.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_7);
						break;
					}
					case "Aircraft_Sensory":
					case "Sensory":
					{
						Aircraft aircraft5 = aircraft_;
						ActiveUnit activeUnit_6 = aircraft_;
						aircraft5.managerWrapper = Aircraft_Sensory.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_6);
						break;
					}
					case "EFSAR":
						aircraft_.EligibleForSAR = Conversions.ToBoolean(xmlNode_9.InnerText);
						break;
					case "Longitude":
					case "Lon":
						aircraft_._Longitude = XmlConvert.ToDouble(xmlNode_9.InnerText.Replace(",", "."));
						break;
					case "ActiveRemainAreaTriggers":
					{
						string key = null;
						DateTime result = DateTime.MinValue;
						try
						{
							enumerator4 = xmlNode_9.ChildNodes.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								XmlNode xmlNode3 = (XmlNode)enumerator4.Current;
								if (Operators.CompareString(xmlNode3.Name, "RemainAreaTrigger", TextCompare: false) == 0)
								{
									key = xmlNode3.InnerText;
									result = DateTime.MinValue;
									continue;
								}
								if (DateTime.TryParse(xmlNode3.InnerText, CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
								{
									aircraft_.ActiveRemainAreaTriggers.Add(key, result);
									continue;
								}
								string innerText = xmlNode3.InnerText;
								long result2 = 0L;
								if (long.TryParse(innerText, out result2))
								{
									result = DateTime.FromBinary(Conversions.ToLong(xmlNode3.InnerText));
									aircraft_.ActiveRemainAreaTriggers.Add(key, result);
								}
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
					case "TerrainFollowing":
						aircraft_.SetDesiredAltitude_UseTerrainFollowing(aircraft_, Conversions.ToBoolean(xmlNode_9.InnerText));
						break;
					case "CustomIcon":
						aircraft_.CustomIcon = xmlNode_9.InnerText;
						break;
					case "Side":
						aircraft_._SideName = xmlNode_9.InnerText;
						break;
					case "CommStuff":
					case "Aircraft_CommStuff":
					{
						Aircraft aircraft4 = aircraft_;
						ActiveUnit activeUnit_5 = aircraft_;
						aircraft4.m_ProducerWrapper = Aircraft_CommStuff.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_5);
						break;
					}
					case "AI":
					case "Aircraft_AI":
					{
						Aircraft aircraft3 = aircraft_;
						ActiveUnit activeUnit_4 = aircraft_;
						aircraft3.m_HelperWrapper = Aircraft_AI.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_4);
						if (aircraft_.GetDesiredAltitude_UseTerrainFollowing(aircraft_) && aircraft_.DesiredAltitude_AGL == 0f)
						{
							aircraft_.DesiredAltitude_AGL = 60.96f;
						}
						break;
					}
					case "DesiredAltitude_TerrainFollowing":
						aircraft_.DesiredAltitude_AGL = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "DS":
					case "DesiredSpeed":
						aircraft_.DesiredSpeed = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "IBPU":
						aircraft_.IsBeingPickedUp = Conversions.ToBoolean(xmlNode_9.InnerText);
						break;
					case "AssignedTaskPool":
						if (xmlNode_9.HasChildNodes)
						{
							XmlNode xmlNode2 = xmlNode_9.ChildNodes[0];
							aircraft_._AssignedTaskPool_ID = xmlNode2.InnerText;
						}
						break;
					case "SBEO_Altitude":
						aircraft_.regVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "SBPF_Altitude":
						aircraft_._MethodVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "SBR_ThrottleSetting":
						switch (xmlNode_9.InnerText)
						{
						default:
							aircraft_._TemplateVal = (Throttle)Conversions.ToByte(xmlNode_9.InnerText);
							break;
						case "Loiter":
							aircraft_._TemplateVal = Throttle.Loiter;
							break;
						case "FullStop":
							aircraft_._TemplateVal = Throttle.FullStop;
							break;
						case "Full":
							aircraft_._TemplateVal = Throttle.Full;
							break;
						case "Flank":
							aircraft_._TemplateVal = Throttle.Flank;
							break;
						case "Cruise":
							aircraft_._TemplateVal = Throttle.Cruise;
							break;
						}
						break;
					case "Message":
						aircraft_.Message = xmlNode_9.InnerText;
						break;
					case "SBEO_Altitude_TF":
						aircraft_.paramVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "AMP_OC":
						aircraft_.m_AttrVal = Conversions.ToBoolean(xmlNode_9.InnerText);
						break;
					case "SBR_Altitude":
						aircraft_._ItemVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "Latitude":
					case "Lat":
						aircraft_._Latitude = XmlConvert.ToDouble(xmlNode_9.InnerText.Replace(",", "."));
						break;
					case "SBR_TF":
						aircraft_._CreatorVal = Conversions.ToBoolean(xmlNode_9.InnerText);
						break;
					case "SBEO":
						aircraft_._RecordVal = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "LonLR":
						aircraft_.Longitude_LastReported = XmlConvert.ToDouble(xmlNode_9.InnerText.Replace(",", "."));
						break;
					case "SBED":
						aircraft_._SingletonVal = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "DT":
					case "DesiredTurnRate":
						aircraft_.DesiredTurnRate = (TurnRate)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "CS":
					case "CurrentSpeed":
						aircraft_.CurrentSpeed = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "Aircraft_Weaponry":
					case "Weaponry":
					{
						Aircraft aircraft2 = aircraft_;
						ActiveUnit activeUnit_3 = aircraft_;
						aircraft2.m_GetterWrapper = Aircraft_Weaponry.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_3);
						break;
					}
					case "SBEO_ThrottleSetting":
						switch (xmlNode_9.InnerText)
						{
						default:
							aircraft_.m_RulesVal = (Throttle)Conversions.ToByte(xmlNode_9.InnerText);
							break;
						case "Loiter":
							aircraft_.m_RulesVal = Throttle.Loiter;
							break;
						case "FullStop":
							aircraft_.m_RulesVal = Throttle.FullStop;
							break;
						case "Full":
							aircraft_.m_RulesVal = Throttle.Full;
							break;
						case "Flank":
							aircraft_.m_RulesVal = Throttle.Flank;
							break;
						case "Cruise":
							aircraft_.m_RulesVal = Throttle.Cruise;
							break;
						}
						break;
					case "Aircraft_Navigator":
					case "Navigator":
					{
						Aircraft aircraft = aircraft_;
						ActiveUnit activeUnit_2 = aircraft_;
						aircraft._InfoWrapper = Aircraft_Navigator.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_2);
						break;
					}
					case "Longitude_UnitEntersAreaCheck":
						aircraft_.Longitude__UnitEntersAreaCheck = XmlConvert.ToDouble(xmlNode_9.InnerText);
						break;
					case "Loadout":
						if (bool_1)
						{
							aircraft_.Loadout = Loadout.FromXML(xmlNode_9.ChildNodes[0], concurrentDictionary_0, ref aircraft_, ref scenario_0);
							if (aircraft_.Loadout != null && aircraft_.Loadout.NoOptionalWeapons)
							{
								flag = true;
							}
							aircraft_.Loadout = null;
							int int_ = Conversions.ToInteger(Misc.StartRequest(xmlNode_9.ChildNodes[0].ChildNodes, "DBID").InnerText);
							DBFunctions.GetLoadout(ref aircraft_, int_, flag);
						}
						else
						{
							aircraft_.Loadout = Loadout.FromXML(xmlNode_9.ChildNodes[0], concurrentDictionary_0, ref aircraft_, ref scenario_0);
						}
						aircraft_.Kinematics.DetermineReserveFuelQty(bool_0: true);
						break;
					case "ParentGroup":
						aircraft_._ParentGroup_ID = xmlNode_9.InnerText;
						break;
					case "TerrainFollowingType":
						aircraft_.TerrainFollowingType = (TerrainFollowMode)Conversions.ToInteger(xmlNode_9.InnerText);
						break;
					case "AirborneTime":
					case "AbnTime":
						aircraft_.AirborneTime = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "CH":
					case "CurrentHeading":
						aircraft_.CurrentHeading = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "IsAD":
					case "IsAutoDetectable":
						aircraft_.SetIsAutoDetectable(null, Conversions.ToBoolean(xmlNode_9.InnerText));
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
			float maximumAltitude = aircraft_.Kinematics.GetMaximumAltitude();
			if (aircraft_.GetCurrentAltitude() > maximumAltitude)
			{
				aircraft_.SetCurrentAltitude(bool_1: false, maximumAltitude);
			}
			if (aircraft_.DesiredAltitude > maximumAltitude)
			{
				aircraft_.DesiredAltitude = maximumAltitude;
			}
			if (!bool_1 && gparam_.Length != 0)
			{
				try
				{
					Sensor[] array = gparam_;
					Sensor[] array3 = array;
					foreach (Sensor sensor2 in array3)
					{
						Sensor[] array2 = aircraft_.Sensors_ReadOnly();
						Sensor[] array4 = array2;
						foreach (Sensor sensor3 in array4)
						{
							if (sensor3.DBID == sensor2.DBID && sensor2.IsActive)
							{
								sensor3.GoActive();
							}
						}
					}
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at 200019", exception_2.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			return aircraft_;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 100350", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public override float Attitude_Pitch_Derived()
	{
		if (IsHelicopter)
		{
			float num = GetCurrentAltitude() - base.Altitude_old;
			if (num <= 0f)
			{
				if (num < 0f)
				{
					return -5f;
				}
				return 0f;
			}
			return 5f;
		}
		return base.Attitude_Pitch_Derived();
	}

	public override bool IsHostedInExposedSpace()
	{
		if (IsOperating())
		{
			return false;
		}
		if (AirOps.HostAirFacility == null)
		{
			return false;
		}
		if (AirOps.HostAirFacility.IsOpenAirFacility)
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	public override int GetSafeDistanceAgainstUnknownMine_meters(bool bool_1)
	{
		return 0;
	}

	[SpecialName]
	public override int GetSafeDistanceAgainstKnownMineType_meters(Weapon._WeaponType _WeaponType_0, bool bool_1)
	{
		return 0;
	}

	public override void PostDeserializationHousekeeping_General(ref Scenario scenario_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, List<ActiveUnit> list_0, bool bool_1)
	{
		try
		{
			base.PostDeserializationHousekeeping_General(ref scenario_0, concurrentDictionary_0, list_0, bool_1);
			if (AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Parked && AirOps.CurrentHostUnit == null && AirOps.HostAirFacility == null)
			{
				GetUnitSide().Units.Remove(this);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100351", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DisconnectTankerClients()
	{
		try
		{
			if (!IsTanker)
			{
				return;
			}
			List<string> list = new List<string>();
			list.AddRange(structObserver.RefuellingQueue.Keys);
			foreach (string item in list)
			{
				if (ParentScen.ActiveUnits.ContainsKey(item))
				{
					((Aircraft)ParentScen.ActiveUnits[item]).structObserver.DisconnectFromTanker();
					continue;
				}
				ConcurrentDictionary<string, byte> refuellingQueue = structObserver.RefuellingQueue;
				byte value = 0;
				refuellingQueue.TryRemove(item, out value);
			}
			List<KeyValuePair<string, Aircraft_AirOps.GEnum6>> list2 = new List<KeyValuePair<string, Aircraft_AirOps.GEnum6>>();
			list2.AddRange(structObserver.A2AR_Connections);
			foreach (KeyValuePair<string, Aircraft_AirOps.GEnum6> item2 in list2)
			{
				if (ParentScen.ActiveUnits.ContainsKey(item2.Key))
				{
					Aircraft aircraft = (Aircraft)ParentScen.ActiveUnits[item2.Key];
					aircraft.structObserver.DisconnectFromTanker();
					if (!aircraft.IsExpendableUAV)
					{
						continue;
					}
					if (aircraft.structObserver.A2AR_Destination == null && aircraft.GetParentGroup() != null && ((Aircraft)aircraft.GetParentGroup().GroupLead).AirOps.A2AR_Destination != null)
					{
						if (aircraft != ((Aircraft)aircraft.GetParentGroup().GroupLead).AirOps.A2AR_Destination)
						{
							aircraft.structObserver.A2AR_Destination = ((Aircraft)aircraft.GetParentGroup().GroupLead).AirOps.A2AR_Destination;
							aircraft.structObserver.AttemptToConnectToTanker(bool_0: true);
						}
					}
					else if (aircraft.GetParentGroup() != null && aircraft.IsGroupLead() && aircraft.AirOps.A2AR_Destination == null)
					{
						aircraft.Status = _ActiveUnitStatus.HeadingToRefuelPoint;
					}
				}
				else
				{
					ConcurrentDictionary<string, Aircraft_AirOps.GEnum6> a2AR_Connections = structObserver.A2AR_Connections;
					string key = item2.Key;
					Aircraft_AirOps.GEnum6 value2 = Aircraft_AirOps.GEnum6.Drogue;
					a2AR_Connections.TryRemove(key, out value2);
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

	[SpecialName]
	public override bool GetCanPhysicallyReplenishThisUnit(ActiveUnit activeUnit_0)
	{
		bool result = false;
		try
		{
			if (activeUnit_0.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)activeUnit_0;
				if (CenterlineBoom && aircraft.BoomRefuelling)
				{
					result = true;
					return true;
				}
				if ((CenterlineDrogue || WingDrogue) && aircraft.ProbeRefuelling)
				{
					result = true;
					return true;
				}
				if (aircraft.ProbeRefuelling && Loadout != null)
				{
					WeaponRec[] weapons = Loadout.Weapons;
					for (int i = 0; i < weapons.Length; i = checked(i + 1))
					{
						if (weapons[i].GetReferenceWeapon(ParentScen).Type == Weapon._WeaponType.BuddyStore)
						{
							result = true;
							return true;
						}
					}
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
			exception_?.Data.Add("Error at 100353", "");
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
	public override bool GetHasEnoughFuelToReplenishThisUnit(ActiveUnit activeUnit_0, Aircraft_AirOps aircraft_AirOps_0, float float_0, bool bool_1)
	{
		bool result = false;
		try
		{
			if ((Fuel_ReadOnly != null) & (Fuel_ReadOnly.Count > 0))
			{
				int num = 0;
				foreach (FuelRec item in Fuel_ReadOnly.ToList())
				{
					if (item != null)
					{
						num = (int)Math.Round(((float)num + item?.CurrentQuantity).Value);
					}
				}
			}
			ActiveUnit actualDestinationHost = AirOps.ActualDestinationHost;
			if (actualDestinationHost != null)
			{
				float float_ = Module_Unit.RangeToUnit_Horiz(this, actualDestinationHost);
				Aircraft_Navigator navigator = Navigator;
				bool bool_2 = false;
				float num2 = navigator.OrderProxy(ref bool_2);
				float value = Kinematics.GetMaximumSpeed(num2, Throttle.Cruise, bool_0: false);
				Math.Round(Kinematics.InterruptDic(float_, Throttle.Cruise, num2, value, bool_0: false, bool_1: false, bool_2: false));
			}
			Math.Round(Kinematics.ReserveFuel);
			aircraft_AirOps_0.GetA2AR_Tanker_FuelReservation(activeUnit_0, activeUnit_0.GetParentGroup(), bool_1);
			result = true;
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100354", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public new Aircraft_AirOps.AirOpsAvailabilityStatus IsAvailableForOps(ref string string_0)
	{
		if (Loadout == null)
		{
			return Aircraft_AirOps.AirOpsAvailabilityStatus.HasNoMissionLoadout;
		}
		if (Loadout.Role == Loadout.LoadoutRole.Unavailable)
		{
			return Aircraft_AirOps.AirOpsAvailabilityStatus.IsUnderMaintenance;
		}
		if (Loadout.Role == Loadout.LoadoutRole.Reserve)
		{
			return Aircraft_AirOps.AirOpsAvailabilityStatus.IsReserve;
		}
		_ActiveUnitWeaponState activeUnitWeaponState = Weaponry.IsWinchesterOrShotgun();
		if (activeUnitWeaponState != 0 && activeUnitWeaponState != _ActiveUnitWeaponState.IgnoreWinchesterAndShotgun)
		{
			return Aircraft_AirOps.AirOpsAvailabilityStatus.IsWinchester;
		}
		return Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable;
	}

	public string QuickTurnaroundString()
	{
		if (Loadout == null)
		{
			return "-";
		}
		if (Loadout.QuickTurnaround)
		{
			byte? b = (byte?)Doctrine.GetQuickTurnAroundForAicraft(ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
			{
				return "禁用（条令）";
			}
			b = (byte?)Doctrine.GetQuickTurnAroundForAicraft(ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				Loadout loadout = Loadout;
				if (!loadout.IsAAW && !loadout.IsSupportOrPatrol && !loadout.IsASW)
				{
					return "禁用（条令）";
				}
			}
			Aircraft_AirOps airOps = AirOps;
			if (airOps.QuickTurnaround_Enabled)
			{
				return "启用，" + Misc.Description(Loadout.QuickTurnaround_TimeofDay) + ": " + Conversions.ToString(airOps.QuickTurnaround_SortiesFlown) + " / " + Conversions.ToString(airOps.QuickTurnaround_SortiesTotal) + "架次，" + Misc.UpdateRequest((long)Math.Round(airOps.QuickTurnaround_AirborneTime_Flown), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + " / " + Misc.UpdateRequest(Loadout.QuickTurnaround_AirborneTime * 60, Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: true) + "飞行时间，" + Misc.UpdateRequest(airOps.QuickTurnaround_TimePentalty * 60, Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: true) + "停机";
			}
			return "-";
		}
		return "-";
	}

	[SpecialName]
	public override double GetLongitude(bool? nullable_0 = null)
	{
		if (nullable_0.HasValue ? nullable_0.Value : IsOperating())
		{
			return _Longitude;
		}
		return AirOps.CurrentHostUnit?.GetLongitude() ?? 0.0;
	}

	[SpecialName]
	public override void SetLongitude(bool? nullable_0, double double_0)
	{
		_Longitude = double_0;
	}

	private CommDevice[] ValidateFacade()
	{
		CommDevice[] array = new CommDevice[_Comms.Length - 1 + 1];
		if (_Comms.Length != 0)
		{
			Array.Copy(_Comms, array, _Comms.Length);
		}
		return array;
	}

	[SpecialName]
	public bool GetCanHover(bool bool_1)
	{
		if ((uint)(Category - 2003) <= 1u)
		{
			return true;
		}
		if (bool_1)
		{
			return RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.VTOL;
		}
		return false;
	}

	[SpecialName]
	public override float GetCurrentAltitude(bool bool_1 = false)
	{
		if (IsOperating())
		{
			return base.GetCurrentAltitude(bool_0: false);
		}
		if (AirOps.CurrentHostUnit == null)
		{
			return Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, ParentScen);
		}
		return AirOps.CurrentHostUnit.GetCurrentAltitude();
	}

	[SpecialName]
	public override void SetCurrentAltitude(bool bool_1, float float_0)
	{
		try
		{
			if (bool_1)
			{
				int landElevation = GetLandElevation(bool_0: true, bool_1: false, bool_2: false, ParentScen);
				if (float_0 < (float)(landElevation + 1))
				{
					if (HasLostControlPulse_CACHED)
					{
						Destroy(bool_1: false, bool_2: false, bool_3: true, "Crashed on the ground (blinded crew)", "Crashed on the ground (blinded crew)");
					}
					else
					{
						float_0 = landElevation + 1;
						if (Attitude_Pitch < 0f)
						{
							Attitude_Pitch = 0f;
						}
					}
				}
			}
			base.SetCurrentAltitude(bool_1, float_0);
			if (Loadout != null)
			{
				WeaponRec[] weapons = Loadout.Weapons;
				for (int i = 0; i < weapons.Length; i = checked(i + 1))
				{
					weapons[i].GetReferenceWeapon(ParentScen).SetCurrentAltitude(bool_0: false, float_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101196", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	public override long GetFuelEndurance(Throttle throttle_0, AltBand altBand_0, float? nullable_0, float? nullable_1)
	{
		try
		{
			if (Type == _AircraftType.AeroStat)
			{
				return long.MaxValue;
			}
			float num = 0f;
			foreach (FuelRec item in Fuel_ReadOnly)
			{
				if (item != null)
				{
					num += item.CurrentQuantity;
				}
			}
			if (throttle_0 == Throttle.FullStop)
			{
				return 2147483647L;
			}
			float num2 = FuelConsumption(throttle_0, altBand_0, nullable_0, nullable_1, bool_1: false, bool_2: false, bool_3: false, bool_4: false, bool_5: false);
			if (num2 == 0f)
			{
				return long.MaxValue;
			}
			return (long)Math.Round(num / num2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100356", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 2147483647L;
		}
	}

	public override void SetThrottle(Throttle throttle_0, float? nullable_0 = null)
	{
		try
		{
			if (throttle_0 == Throttle.Flank && !Command_Core_002EICargoHost_002ECanStackCargo())
			{
				throttle_0 = Throttle.Full;
			}
			if (!IsHelicopter && throttle_0 == Throttle.FullStop)
			{
				throttle_0 = Throttle.Loiter;
			}
			if (ThrottleSetting == throttle_0 && !nullable_0.HasValue && !ParentScen.MinuteIsChangingOnThisPulse)
			{
				return;
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
				if (nullable_0.HasValue)
				{
					if (Kinematics.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && !Navigator.m_ErrorWrapper)
					{
						DesiredSpeed = Kinematics.GetMaximumSpeed(GetCurrentAltitude(), (Throttle)Kinematics.ThrottlePreset, bool_0: false);
					}
					else
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
								ThrottleSetting = Kinematics.GetThrottleSuitableForThisSpeed(GetCurrentAltitude(), nullable_0.Value);
								goto IL_0339;
							}
						}
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
					DesiredSpeed = Kinematics.GetMaximumSpeed(GetCurrentAltitude(), ThrottleSetting, bool_0: false);
				}
			}
			goto IL_0339;
			IL_0339:
			RaiseEvent_ChangedThrottleSetting(this, ThrottleSetting);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100357", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	private bool Command_Core_002EICargoHost_002ECanStackCargo()
	{
		bool result = false;
		try
		{
			AltBand[] altBands = Propulsion[0].AltBands;
			AltBand[] array = altBands;
			foreach (AltBand altBand in array)
			{
				if (altBand.Consumption_Flank.HasValue && altBand.Speed_Flank.HasValue)
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
			exception_?.Data.Add("Error at 100358", "");
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
	public override _ActiveUnitFuelState GetIsBingoTowardsThisDestination(ActiveUnit activeUnit_0, GeoPoint geoPoint_0, Doctrine._FuelState? nullable_0)
	{
		float num = float.MaxValue;
		List<Waypoint> list_ = new List<Waypoint>();
		try
		{
			if (activeUnit_0 == null)
			{
				FuelState_DistanceToBase = 0f;
				FuelState_Destination = null;
				return _ActiveUnitFuelState.None;
			}
			if (Fuel_ReadOnly.Count == 0)
			{
				return _ActiveUnitFuelState.IsBingo;
			}
			if (geoPoint_0 == null)
			{
				float num12;
				if (activeUnit_0.HasRunwaysOrPads)
				{
					if (IsHelicopter)
					{
						num12 = Module_Unit.RangeToUnit_Horiz(this, activeUnit_0);
						if (float.IsNaN(num12))
						{
							return _ActiveUnitFuelState.None;
						}
					}
					else
					{
						Geopoint_Struct landingQueueAssemblyPoint = activeUnit_0.AirOps.LandingQueueAssemblyPoint;
						float num19 = Math2.VerifyClass(GetLatitude(), GetLongitude(), landingQueueAssemblyPoint.Latitude, landingQueueAssemblyPoint.Longitude);
						float num20 = Math2.VerifyClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), landingQueueAssemblyPoint.Latitude, landingQueueAssemblyPoint.Longitude);
						if (float.IsNaN(num19) || float.IsNaN(num20))
						{
							return _ActiveUnitFuelState.None;
						}
						num12 = num19 + num20;
					}
				}
				else
				{
					num12 = Module_Unit.RangeToUnit_Horiz(this, activeUnit_0);
					if (float.IsNaN(num12))
					{
						return _ActiveUnitFuelState.None;
					}
				}
				FuelState_DistanceToBase = num12;
				FuelState_Destination = activeUnit_0;
			}
			else
			{
				float num21;
				if (activeUnit_0.HasRunwaysOrPads)
				{
					if (IsHelicopter)
					{
						num21 = Math2.VerifyClass(geoPoint_0.Latitude, geoPoint_0.Longitude, activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude());
						if (float.IsNaN(num21))
						{
							return _ActiveUnitFuelState.None;
						}
					}
					else
					{
						Geopoint_Struct landingQueueAssemblyPoint2 = activeUnit_0.AirOps.LandingQueueAssemblyPoint;
						float num22 = Math2.VerifyClass(geoPoint_0.Latitude, geoPoint_0.Longitude, landingQueueAssemblyPoint2.Latitude, landingQueueAssemblyPoint2.Longitude);
						float num23 = Math2.VerifyClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), landingQueueAssemblyPoint2.Latitude, landingQueueAssemblyPoint2.Longitude);
						if (float.IsNaN(num22) || float.IsNaN(num23))
						{
							return _ActiveUnitFuelState.None;
						}
						num21 = num22 + num23;
					}
				}
				else
				{
					num21 = Module_Unit.RangeToPoint_Horiz(activeUnit_0, geoPoint_0);
					if (float.IsNaN(num21))
					{
						return _ActiveUnitFuelState.None;
					}
				}
				float num24 = Module_Unit.RangeToPoint_Horiz(this, geoPoint_0);
				FuelState_DistanceToBase = num24 + num21;
				FuelState_Destination = activeUnit_0;
			}
			if (!activeUnit_0.IsAircraft)
			{
				if (Navigator.HasFlightPlan && Navigator.PlottedCourse.Length != 0 && Navigator.PlottedCourse[Navigator.PlottedCourse.Length - 1].Type == Waypoint.WaypointType.Land)
				{
					goto IL_08c7;
				}
				bool? flag;
				bool? flag12 = (flag = ((!IsGroupWingman() || GetParentGroup()?.GroupLead == null) ? new bool?(false) : GetParentGroup()?.GroupLead.Navigator.HasFlightPlan));
				bool? flag14;
				if (flag12.HasValue && !flag.GetValueOrDefault())
				{
					flag14 = false;
				}
				else
				{
					Group parentGroup = GetParentGroup();
					bool? flag15;
					flag12 = (flag15 = ((parentGroup == null) ? null : new bool?(parentGroup.GroupLead.Navigator.PlottedCourse.Length != 0)));
					flag14 = ((!flag12.HasValue) ? null : (flag15.GetValueOrDefault() & flag));
				}
				bool? flag16 = flag14;
				if (flag16.GetValueOrDefault(true))
				{
					Group parentGroup2 = GetParentGroup();
					if (parentGroup2 != null && parentGroup2.GroupLead.Navigator.PlottedCourse[GetParentGroup().GroupLead.Navigator.PlottedCourse.Length - 1].Type == Waypoint.WaypointType.Land && flag16.HasValue)
					{
						goto IL_08c7;
					}
				}
			}
			if (geoPoint_0 == null)
			{
				float num25;
				if (activeUnit_0.HasRunwaysOrPads)
				{
					if (IsHelicopter)
					{
						num25 = Module_Unit.RangeToUnit_Horiz(this, activeUnit_0);
						if (float.IsNaN(num25))
						{
							return _ActiveUnitFuelState.None;
						}
					}
					else
					{
						Geopoint_Struct landingQueueAssemblyPoint3 = activeUnit_0.AirOps.LandingQueueAssemblyPoint;
						float num2 = Math2.VerifyClass(GetLatitude(), GetLongitude(), landingQueueAssemblyPoint3.Latitude, landingQueueAssemblyPoint3.Longitude);
						float num3 = Math2.VerifyClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), landingQueueAssemblyPoint3.Latitude, landingQueueAssemblyPoint3.Longitude);
						if (float.IsNaN(num2) || float.IsNaN(num3))
						{
							return _ActiveUnitFuelState.None;
						}
						num25 = num2 + num3;
					}
				}
				else
				{
					num25 = Module_Unit.RangeToUnit_Horiz(this, activeUnit_0);
					if (float.IsNaN(num25))
					{
						return _ActiveUnitFuelState.None;
					}
				}
				FuelState_DistanceToBase = num25;
				FuelState_Destination = activeUnit_0;
			}
			else
			{
				float num4;
				if (activeUnit_0.HasRunwaysOrPads)
				{
					if (IsHelicopter)
					{
						num4 = Math2.VerifyClass(geoPoint_0.Latitude, geoPoint_0.Longitude, activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude());
						if (float.IsNaN(num4))
						{
							return _ActiveUnitFuelState.None;
						}
					}
					else
					{
						Geopoint_Struct landingQueueAssemblyPoint4 = activeUnit_0.AirOps.LandingQueueAssemblyPoint;
						float num5 = Math2.VerifyClass(geoPoint_0.Latitude, geoPoint_0.Longitude, landingQueueAssemblyPoint4.Latitude, landingQueueAssemblyPoint4.Longitude);
						float num6 = Math2.VerifyClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), landingQueueAssemblyPoint4.Latitude, landingQueueAssemblyPoint4.Longitude);
						if (float.IsNaN(num5) || float.IsNaN(num6))
						{
							return _ActiveUnitFuelState.None;
						}
						num4 = num5 + num6;
					}
				}
				else
				{
					num4 = Module_Unit.RangeToPoint_Horiz(activeUnit_0, geoPoint_0);
					if (float.IsNaN(num4))
					{
						return _ActiveUnitFuelState.None;
					}
				}
				float num7 = Module_Unit.RangeToPoint_Horiz(this, geoPoint_0);
				FuelState_DistanceToBase = num7 + num4;
				FuelState_Destination = activeUnit_0;
			}
			double num8 = Kinematics.CurrentRangeAtBingoThrottleAltitudeDepth(nullable_0);
			if (GetFuelEndurance(Throttle.Cruise, null, null, null) <= 900)
			{
				return _ActiveUnitFuelState.IsBingo;
			}
			int num9 = (int)Math.Round(Math.Min(2000.0, (double)Fuel_ReadOnly[0].MaxQuantity * 0.05));
			if (Fuel_ReadOnly[0].CurrentQuantity < (float)num9)
			{
				return _ActiveUnitFuelState.IsBingo;
			}
			if (activeUnit_0.IsAircraft)
			{
				if (((Aircraft)activeUnit_0).IsTanker)
				{
					num8 *= 0.7;
				}
			}
			else if (ThrottleSetting == Throttle.Flank)
			{
				num8 *= 0.9;
			}
			else if (Loadout != null && Loadout.Role == Loadout.LoadoutRole.AirRefueling)
			{
				num8 *= 0.9;
			}
			if (num8 >= (double)FuelState_DistanceToBase)
			{
				if (FuelState == _ActiveUnitFuelState.IsBingo)
				{
					if (num8 * 0.9 < (double)FuelState_DistanceToBase)
					{
						return _ActiveUnitFuelState.IsBingo;
					}
					return _ActiveUnitFuelState.None;
				}
				return _ActiveUnitFuelState.None;
			}
			byte? b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				return _ActiveUnitFuelState.IsBingo;
			}
			if (FuelState_RemainingFuelToBingo <= 0f)
			{
				return _ActiveUnitFuelState.IsBingo;
			}
			return _ActiveUnitFuelState.IsJoker;
			IL_08c7:
			Doctrine._UseUnderwayRefuelAndReplenishment? useReplenishment = Doctrine.GetUseReplenishment(ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			Waypoint.WaypointType? previousWaypointType;
			Aircraft aircraft;
			if (Navigator.HasFlightPlan && Navigator.PlottedCourse.Count() > 0)
			{
				if (IsGroupWingman())
				{
					Waypoint[] plottedCourse3 = Navigator.PlottedCourse;
					Waypoint[] array = plottedCourse3;
					foreach (Waypoint waypoint in array)
					{
						if (waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
						{
							list_.Add(waypoint);
						}
					}
					Waypoint waypoint2 = list_.LastOrDefault();
					bool flag17 = false;
					plottedCourse3 = Navigator.GetFlight().FlightPlan;
					Waypoint[] array2 = plottedCourse3;
					foreach (Waypoint waypoint3 in array2)
					{
						if (flag17)
						{
							list_.Add(waypoint3);
						}
						else if (waypoint3.FlightFormation != Waypoint.Formation.Split && waypoint3.InvokeReponse())
						{
							if (waypoint3.Waypoint_LeadElementWingman != null && waypoint3.Waypoint_LeadElementWingman == waypoint2)
							{
								flag17 = true;
								continue;
							}
							if (waypoint3.Waypoint_SecondElement != null && waypoint3.Waypoint_SecondElement == waypoint2)
							{
								flag17 = true;
								continue;
							}
							if (waypoint3.Waypoint_SecondElementWingman != null && waypoint3.Waypoint_SecondElementWingman == waypoint2)
							{
								flag17 = true;
								continue;
							}
							if (waypoint3.Waypoint_ThirdElement != null && waypoint3.Waypoint_ThirdElement == waypoint2)
							{
								flag17 = true;
								continue;
							}
							if (waypoint3.Waypoint_ThirdElementWingman != null && waypoint3.Waypoint_ThirdElementWingman == waypoint2)
							{
								flag17 = true;
								continue;
							}
						}
						bool? flag18;
						if (useReplenishment.HasValue)
						{
							b = (byte?)useReplenishment;
							flag18 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
						}
						else
						{
							flag18 = false;
						}
						bool? flag19 = flag18;
						if (flag19.GetValueOrDefault(true))
						{
							b = (byte?)waypoint3.Doctrine.GetUseReplenishment(ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
							bool? flag20 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
							if (((!flag20) ?? flag20).GetValueOrDefault() && flag19.HasValue)
							{
								break;
							}
						}
					}
					previousWaypointType = Navigator.PreviousWaypointType;
					aircraft = this;
				}
				else
				{
					Waypoint[] plottedCourse2 = Navigator.PlottedCourse;
					Waypoint[] array3 = plottedCourse2;
					foreach (Waypoint waypoint4 in array3)
					{
						if (waypoint4.Type == Waypoint.WaypointType.PathfindingPoint)
						{
							continue;
						}
						list_.Add(waypoint4);
						bool? flag2;
						if (useReplenishment.HasValue)
						{
							b = (byte?)useReplenishment;
							flag2 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
						}
						else
						{
							flag2 = false;
						}
						bool? flag3 = flag2;
						if (flag3.GetValueOrDefault(true))
						{
							b = (byte?)waypoint4.Doctrine.GetUseReplenishment(ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
							bool? flag4 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
							if (((!flag4) ?? flag4).GetValueOrDefault() && flag3.HasValue)
							{
								break;
							}
						}
					}
					previousWaypointType = Navigator.PreviousWaypointType;
					aircraft = this;
				}
			}
			else
			{
				Waypoint[] plottedCourse = GetParentGroup().GroupLead.Navigator.PlottedCourse;
				Waypoint[] array4 = plottedCourse;
				foreach (Waypoint waypoint5 in array4)
				{
					if (waypoint5.Type == Waypoint.WaypointType.PathfindingPoint)
					{
						continue;
					}
					list_.Add(waypoint5);
					bool? flag5;
					if (useReplenishment.HasValue)
					{
						b = (byte?)useReplenishment;
						flag5 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
					}
					else
					{
						flag5 = false;
					}
					bool? flag6 = flag5;
					if (flag6.GetValueOrDefault(true))
					{
						b = (byte?)waypoint5.Doctrine.GetUseReplenishment(ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
						bool? flag7 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
						if (((!flag7) ?? flag7).GetValueOrDefault() && flag6.HasValue)
						{
							break;
						}
					}
				}
				previousWaypointType = GetParentGroup().GroupLead.Navigator.PreviousWaypointType;
				aircraft = (Aircraft)GetParentGroup().GroupLead;
			}
			if (list_.Count == 0)
			{
				return _ActiveUnitFuelState.None;
			}
			int num10 = 0;
			float leg_FuelRequired;
			float num11;
			if (list_[0].Type == Waypoint.WaypointType.StationEnd && list_.Count > 1)
			{
				num = Module_Unit.RangeToPoint_Horiz(this, list_[1]);
				leg_FuelRequired = list_[1].Leg_FuelRequired;
				num11 = list_[1].Leg_Distance_Straight + list_[1].Leg_Distance_Turn;
				num10 = 1;
			}
			else
			{
				bool? flag8;
				if (previousWaypointType.HasValue)
				{
					int? num13 = (int?)previousWaypointType;
					flag8 = (num13.HasValue ? new bool?(num13.GetValueOrDefault() == 24) : null);
				}
				else
				{
					flag8 = false;
				}
				bool? flag9 = flag8;
				bool? flag10 = flag8;
				bool? flag11;
				flag9 = (flag11 = ((flag10.HasValue && !flag9.GetValueOrDefault()) ? new bool?(false) : (list_[0].SearchReponse() & flag9)));
				bool? flag13 = ((flag9.HasValue && !flag11.GetValueOrDefault()) ? new bool?(false) : ((list_.Count > 1) & flag11));
				if (flag13.GetValueOrDefault(true) && list_[1].Type == Waypoint.WaypointType.StationEnd && flag13.HasValue)
				{
					num = Module_Unit.RangeToPoint_Horiz(this, list_[2]);
					if (list_.Count == 0)
					{
						return _ActiveUnitFuelState.None;
					}
					leg_FuelRequired = list_[2].Leg_FuelRequired;
					num11 = list_[2].Leg_Distance_Straight + list_[2].Leg_Distance_Turn;
					num10 = 2;
				}
				else
				{
					if (!base.IsRTB_Or_CalledOff && aircraft != null)
					{
						aircraft.Navigator.EgressToRejoinPoint_RemoveWaypoints(ref list_, bool_1: false, bool_2: true);
						aircraft.AirOps.SwitchToNearestWaypoint(ref list_, bool_0: false, bool_1: true);
						_ActiveUnitFuelState result = _ActiveUnitFuelState.None;
						if (aircraft.Status == _ActiveUnitStatus.RTB)
						{
							return result;
						}
						num10 = 0;
					}
					if (list_.Count == 0)
					{
						return _ActiveUnitFuelState.None;
					}
					leg_FuelRequired = list_[num10].Leg_FuelRequired;
					num11 = list_[num10].Leg_Distance_Straight + list_[num10].Leg_Distance_Turn;
					num = Module_Unit.RangeToPoint_Horiz(this, list_[num10]);
				}
			}
			float num14 = 0f;
			if (num11 > 0f)
			{
				num14 = leg_FuelRequired / num11 * num;
			}
			if (list_.Count >= num10 + 1)
			{
				int num15 = num10 + 1;
				int num16 = list_.Count - 1;
				for (int i = num15; i <= num16; i++)
				{
					Waypoint waypoint6 = list_[i];
					num14 += waypoint6.Leg_FuelRequired;
				}
			}
			float num17 = 0f;
			foreach (FuelRec item in Fuel_ReadOnly)
			{
				num17 += item.CurrentQuantity;
			}
			num17 -= Kinematics.ReserveFuel;
			float num18 = num17 - Kinematics.JokerFuel;
			if (num17 < 0f)
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					FuelState_RemainingFuelToBingo = 0f;
					FuelState_RemainingFuelToJoker = 0f;
					return _ActiveUnitFuelState.IsBingo;
				}
			}
			if (num17 < num14)
			{
				FuelState_RemainingFuelToBingo = 0f;
				FuelState_RemainingFuelToJoker = 0f;
				return _ActiveUnitFuelState.IsBingo;
			}
			if (num18 < num14)
			{
				FuelState_RemainingFuelToBingo = num17 - num14;
				FuelState_RemainingFuelToJoker = 0f;
				return _ActiveUnitFuelState.IsJoker;
			}
			FuelState_RemainingFuelToBingo = num17 - num14;
			FuelState_RemainingFuelToJoker = num18 - num14;
			if (FuelState == _ActiveUnitFuelState.IsBingo)
			{
				if ((double)num17 * 0.9 < (double)num14)
				{
					return _ActiveUnitFuelState.IsBingo;
				}
				return _ActiveUnitFuelState.None;
			}
			return _ActiveUnitFuelState.None;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100359", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return _ActiveUnitFuelState.None;
		}
	}

	[SpecialName]
	public override _ActiveUnitFuelState GetIsBingoOrJoker(GeoPoint geoPoint_0, Doctrine._FuelState? nullable_0)
	{
		try
		{
			if (IsAerostat)
			{
				return _ActiveUnitFuelState.None;
			}
			Aircraft aircraft = null;
			bool? flag = null;
			ActiveUnit actualDestinationHost = AirOps.ActualDestinationHost;
			if (AssignedMissionOrPackage() != null)
			{
				byte? b = (byte?)Doctrine.GetUseReplenishment(ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					if (!Navigator.IsOnAutoPlannerPlottedCourse && (!IsGroupWingman() || GetParentGroup().GroupLead == null || !GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse))
					{
						flag = false;
					}
				}
				else
				{
					b = (byte?)Doctrine.GetUseReplenishment(ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault() && Type == _AircraftType.Tanker)
					{
						flag = false;
					}
				}
			}
			if (!flag.HasValue && CanRefuelOnAir)
			{
				bool flag2 = false;
				if (Type == _AircraftType.Tanker && AssignedMissionOrPackage() != null && AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Strike)
				{
					flag2 = true;
				}
				if (!flag2)
				{
					Aircraft_AirOps airOps = AirOps;
					bool flag3 = false;
					ActiveUnit activeUnit_ = null;
					string string_ = "";
					List<Aircraft> potentialTankers = airOps.GetPotentialTankers(ref flag3, ref activeUnit_, bool_1: true, null, ref string_);
					if (potentialTankers.Count == 0)
					{
						flag = false;
					}
					else if (IsOnReturnLeg)
					{
						flag = false;
					}
					else if (!Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackEgressRun && (!IsGroupMember() || GetParentGroup().GroupLead == null || !GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackEgressRun))
					{
						aircraft = potentialTankers.OrderBy((Aircraft aircraft_0) => Module_Unit.RangeToUnit_Horiz_Angular(this, aircraft_0)).ElementAtOrDefault(0);
						byte? b2 = (byte?)nullable_0;
						bool? flag4 = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 13) : null);
						flag = (((!flag4) ?? flag4).GetValueOrDefault() ? (((double)Module_Unit.RangeToUnit_Horiz(this, aircraft) * 0.7 < (double)Module_Unit.RangeToUnit_Horiz(this, actualDestinationHost)) ? new bool?(true) : new bool?(false)) : (((Module_Unit.RangeToUnit_Horiz(this, aircraft) < Module_Unit.RangeToUnit_Horiz(this, actualDestinationHost)) & (GetIsBingoTowardsThisDestination(actualDestinationHost, null, null) == _ActiveUnitFuelState.IsBingo)) ? new bool?(true) : new bool?(false)));
					}
					else
					{
						double num;
						if (Navigator.HasFlightPlan && Navigator.PlottedCourse.Count() > 0 && Navigator.PlottedCourse[Navigator.PlottedCourse.Count() - 1].Type == Waypoint.WaypointType.Land)
						{
							num = Module_Unit.RangeToPoint_Horiz(this, Navigator.PlottedCourse[0]);
							int num2 = Navigator.PlottedCourse.Count() - 1;
							for (int i = 1; i <= num2; i++)
							{
								Waypoint waypoint = Navigator.PlottedCourse[i];
								num += (double)(waypoint.Leg_Distance_Straight + waypoint.Leg_Distance_Turn);
							}
						}
						else
						{
							num = Module_Unit.RangeToUnit_Horiz(this, actualDestinationHost);
						}
						flag = false;
						aircraft = potentialTankers[0];
						if (potentialTankers.Count == 1)
						{
							if (((double)Module_Unit.RangeToUnit_Horiz(this, potentialTankers[0]) < num) & (GetIsBingoTowardsThisDestination(actualDestinationHost, null, null) == _ActiveUnitFuelState.IsBingo))
							{
								flag = true;
							}
						}
						else
						{
							double num3 = Module_Unit.RangeToUnit_Horiz(this, potentialTankers[0]);
							if (num3 < num)
							{
								flag = true;
							}
							foreach (Aircraft item in potentialTankers)
							{
								if (item != potentialTankers[0])
								{
									double num4 = Module_Unit.RangeToUnit_Horiz(this, item);
									if (num4 <= num && num4 < num3)
									{
										aircraft = item;
										flag = true;
									}
								}
							}
						}
						if (!(Navigator.HasFlightPlan & (Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.Refuel)))
						{
							float num5 = (float)GetFuelEndurance(ThrottleSetting, null, CurrentSpeed, GetCurrentAltitude()) * CurrentSpeed / 3600f;
							num = Module_Unit.RangeToUnit_Horiz(this, actualDestinationHost);
							if ((double)num5 - num > 50.0)
							{
								flag = false;
							}
						}
					}
				}
			}
			if (flag.GetValueOrDefault())
			{
				return GetIsBingoTowardsThisDestination(aircraft, null, nullable_0);
			}
			_ActiveUnitFuelState isBingoTowardsThisDestination = GetIsBingoTowardsThisDestination(actualDestinationHost, null, nullable_0);
			if (isBingoTowardsThisDestination == _ActiveUnitFuelState.IsBingo || isBingoTowardsThisDestination == _ActiveUnitFuelState.IsJoker)
			{
				Aircraft_AirOps airOps2 = AirOps;
				if (airOps2.A2AR_Destination != null)
				{
					airOps2.DisconnectFromTanker();
				}
				if (AirOps.Condition != Aircraft_AirOps._AirOpsCondition.EmergencyLanding && FuelState_DistanceToBase <= EMERGENCY_LANDING_DISTANCE_NM)
				{
					float num6 = (float)GetFuelEndurance(ThrottleSetting, null, CurrentSpeed, GetCurrentAltitude()) * CurrentSpeed / 3600f;
					if ((double)FuelState_DistanceToBase >= (double)num6 * 1.5)
					{
						if (Navigator.HasPlottedCourse())
						{
							if (Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.LandingMarshal || Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.Land)
							{
								AirOps.AttemptToRTB(bool_0: false, _ActiveUnitStatus.RTB, bool_1: false, _ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
								AirOps.Condition = Aircraft_AirOps._AirOpsCondition.EmergencyLanding;
							}
						}
						else
						{
							AirOps.AttemptToRTB(bool_0: false, _ActiveUnitStatus.RTB, bool_1: false, _ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
							AirOps.Condition = Aircraft_AirOps._AirOpsCondition.EmergencyLanding;
						}
					}
				}
			}
			return isBingoTowardsThisDestination;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200329", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return _ActiveUnitFuelState.None;
		}
	}

	[SpecialName]
	public override double GetLatitude(bool? nullable_0 = null)
	{
		if (nullable_0.HasValue ? nullable_0.Value : IsOperating())
		{
			return _Latitude;
		}
		return AirOps.CurrentHostUnit?.GetLatitude() ?? 0.0;
	}

	[SpecialName]
	public override void SetLatitude(bool? nullable_0, double double_0)
	{
		_Latitude = double_0;
	}

	public void FuelCapacitySet(float float_0)
	{
		try
		{
			FuelRec fuelRec = _Fuel[0];
			if (float_0 < (float)fuelRec.MaxQuantity)
			{
				fuelRec.CurrentQuantity = float_0;
				float_0 = 0f;
			}
			else
			{
				fuelRec.CurrentQuantity = fuelRec.MaxQuantity;
				float_0 -= (float)fuelRec.MaxQuantity;
			}
			if (Loadout == null)
			{
				return;
			}
			WeaponRec[] weapons = Loadout.Weapons;
			WeaponRec[] array = weapons;
			foreach (WeaponRec weaponRec in array)
			{
				if (!weaponRec.GetReferenceWeapon(ParentScen).IsFuelTank)
				{
					continue;
				}
				FuelRec fuelRec2 = weaponRec.GetReferenceWeapon(ParentScen).Fuel_ReadOnly[0];
				FuelRec fuelRec3 = new FuelRec(0, (short)fuelRec2.FuelType);
				int currentLoad = weaponRec.CurrentLoad;
				fuelRec3.MaxQuantity = fuelRec2.MaxQuantity * currentLoad;
				if (float_0 < (float)fuelRec3.MaxQuantity)
				{
					if (float_0 <= 0f)
					{
						fuelRec2.CurrentQuantity = 0f;
						continue;
					}
					fuelRec2.CurrentQuantity = float_0 / (float)currentLoad;
					float_0 = 0f;
				}
				else
				{
					fuelRec2.CurrentQuantity = fuelRec2.MaxQuantity;
					float_0 -= (float)fuelRec3.MaxQuantity;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101227", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal List<WeaponRec> LoginFacade()
	{
		List<WeaponRec> list = new List<WeaponRec>();
		WeaponRec[] weapons = Loadout.Weapons;
		WeaponRec[] array = weapons;
		foreach (WeaponRec weaponRec in array)
		{
			if (weaponRec.GetReferenceWeapon(ParentScen).IsFuelTank)
			{
				list.Add(weaponRec);
			}
		}
		return list;
	}

	[SpecialName]
	public override bool GetDesiredAltitude_UseTerrainFollowing(ActiveUnit activeUnit_0)
	{
		return paramsWrapper;
	}

	[SpecialName]
	public override void SetDesiredAltitude_UseTerrainFollowing(ActiveUnit activeUnit_0, bool bool_1)
	{
		paramsWrapper = bool_1;
		if (!paramsWrapper)
		{
			TerrainFollowingType = TerrainFollowMode.IgnoreLandCover;
		}
	}

	internal NATO_UAS_ClassificationEnum GetFacade()
	{
		int maxWeight = MaxWeight;
		if (maxWeight < 10)
		{
			return NATO_UAS_ClassificationEnum.Class1_Micro;
		}
		if (maxWeight < 15)
		{
			return NATO_UAS_ClassificationEnum.Class1_Mini;
		}
		if (maxWeight < 150)
		{
			return NATO_UAS_ClassificationEnum.Class1_Small;
		}
		if (maxWeight < 600)
		{
			return NATO_UAS_ClassificationEnum.Class2;
		}
		return NATO_UAS_ClassificationEnum.Class3;
	}

	private float WriteFacade(bool bool_1, bool bool_2, int int_0)
	{
		float num = 3.0479999f;
		switch (Category)
		{
		default:
			num = (bool_1 ? (bool_2 ? (TerrainFollowingCapability ? (num * 4f) : (TerrainAvoidanceCapability ? (num * 6f) : (num * 10f))) : (TerrainFollowingCapability ? (num * 4f) : (TerrainAvoidanceCapability ? (num * 6f) : (num * 20f)))) : (bool_2 ? ((!TerrainFollowingCapability && !TerrainAvoidanceCapability) ? (num * 6f) : ((int_0 < 8) ? (num * 2f) : (num * 4f))) : ((!TerrainFollowingCapability && !TerrainAvoidanceCapability) ? (num * 6f) : ((int_0 < 8) ? (num * 2f) : (num * 4f)))));
			break;
		case _AircraftCategory.Tiltrotor:
			if ((int)ThrottleSetting <= 1)
			{
				break;
			}
			if (bool_1)
			{
				num = (bool_2 ? (TerrainFollowingCapability ? (num * 4f) : (TerrainAvoidanceCapability ? (num * 6f) : (num * 10f))) : (TerrainFollowingCapability ? (num * 4f) : (TerrainAvoidanceCapability ? (num * 6f) : (num * 10f))));
			}
			else if (bool_2)
			{
				if (int_0 < 6)
				{
					if (int_0 >= 8)
					{
						num *= 3f;
					}
				}
				else
				{
					num *= 4f;
				}
			}
			else
			{
				num = ((int_0 < 7) ? (num * 2f) : (num * 4f));
			}
			break;
		case _AircraftCategory.Helicopter:
			if ((int)ThrottleSetting <= 1)
			{
				break;
			}
			if (bool_1)
			{
				num = (bool_2 ? ((int_0 >= 7) ? (num * 4f) : ((int_0 < 5) ? (num * 2f) : (num * 3f))) : (TerrainFollowingCapability ? (num * 4f) : (TerrainAvoidanceCapability ? (num * 6f) : (num * 10f))));
			}
			else if (bool_2)
			{
				if (int_0 < 6)
				{
					if (int_0 >= 8)
					{
						num *= 3f;
					}
				}
				else
				{
					num *= 4f;
				}
			}
			else
			{
				num = ((int_0 < 7) ? (num * 2f) : (num * 4f));
			}
			break;
		}
		return num;
	}

	public Aircraft(ref Scenario scenario_0, string string_0 = null)
		: base(ref scenario_0, string_0)
	{
		G_Tolerance = 45f;
		ShouldDropSonobuoysOnThisPulse = false;
		Armor_Cockpit = GlobalVariables.ArmorRating.None;
		Armor_Fuselage = GlobalVariables.ArmorRating.None;
		Armor_Powerplant = GlobalVariables.ArmorRating.None;
		FuelState_RemainingFuelToBingo = 0f;
		FuelState_RemainingFuelToJoker = 0f;
		VisibilityForward = CockpitVisibility.Excellent;
		VisibilitySideways = CockpitVisibility.Excellent;
		VisibilityAft = CockpitVisibility.Excellent;
		ActiveUnit activeUnit_ = this;
		_InfoWrapper = new Aircraft_Navigator(ref activeUnit_);
		activeUnit_ = this;
		m_HelperWrapper = new Aircraft_AI(ref activeUnit_);
		activeUnit_ = this;
		mapperWrapper = new Aircraft_Kinematics(ref activeUnit_);
		IsAircraft = true;
		activeUnit_ = this;
		structObserver = new Aircraft_AirOps(ref activeUnit_);
	}

	public static int smethod_0(int int_0)
	{
		if (int_0 < 20)
		{
			return 100;
		}
		if (int_0 < 50)
		{
			return 200;
		}
		if (int_0 < 100)
		{
			return 400;
		}
		if (int_0 < 120)
		{
			return 800;
		}
		if (int_0 < 150)
		{
			return 1600;
		}
		return 3200;
	}

	public override void Destroy(bool bool_1, bool bool_2, bool bool_3, string string_0, string string_1 = null)
	{
		try
		{
			IsBeingDestroyed = true;
			AirOps.HostAirFacility = null;
			if (AirOps.Condition == Aircraft_AirOps._AirOpsCondition.OffloadingFuel)
			{
				List<KeyValuePair<string, Aircraft_AirOps.GEnum6>> list = new List<KeyValuePair<string, Aircraft_AirOps.GEnum6>>();
				list.AddRange(structObserver.A2AR_Connections);
				foreach (KeyValuePair<string, Aircraft_AirOps.GEnum6> item in list)
				{
					((Aircraft)ParentScen.ActiveUnits[item.Key])?.structObserver.DisconnectFromTanker();
				}
				List<string> list2 = new List<string>();
				list2.AddRange(structObserver.RefuellingQueue.Keys);
				foreach (string item2 in list2)
				{
					ConcurrentDictionary<string, byte> refuellingQueue = structObserver.RefuellingQueue;
					byte value = 0;
					refuellingQueue.TryRemove(item2, out value);
				}
			}
			foreach (ActiveUnit activeUnits_ in ParentScen.ActiveUnits_List)
			{
				if (activeUnits_ != null)
				{
					if (activeUnits_.AirOps.LandingQueue_ReadOnly.Contains(this))
					{
						activeUnits_.AirOps.LandingQueue_RemoveAircraft(this);
					}
					if (activeUnits_.IsAircraft && ((Aircraft)activeUnits_).AirOps.RefuellingQueue != null && ((Aircraft)activeUnits_).AirOps.RefuellingQueue.Count > 0)
					{
						ConcurrentDictionary<string, byte> refuellingQueue2 = ((Aircraft)activeUnits_).AirOps.RefuellingQueue;
						string objectID = ObjectID;
						byte value2 = 0;
						refuellingQueue2.TryRemove(objectID, out value2);
					}
				}
			}
			base.Destroy(bool_1, bool_2, bool_3, string_0, string_1);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100367", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void Teleport(ref Scenario scenario_0, double double_0, double double_1)
	{
		base.Teleport(ref scenario_0, double_0, double_1);
		Kinematics.ExportLocationEvent(bool_0: true);
	}

	public override void DoTypeSpecificActions(float float_0, ref LockRandom lockRandom_0)
	{
		AirOps.DoAirOps(float_0);
	}

	public override void AttemptToSetNewAssignedHost(ActiveUnit activeUnit_0, bool bool_1 = false, bool bool_2 = false)
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
		string text = "";
		if (Operators.CompareString(Name, UnitClass, TextCompare: false) != 0)
		{
			text = " (" + UnitClass + ")";
		}
		if (num || flag2)
		{
			string text2 = AirOps.ThisUnitCanHostMe(activeUnit_0);
			if (Operators.CompareString(text2, "OK", TextCompare: false) == 0)
			{
				AirOps.SetAssignedHostUnit(bool_0: false, activeUnit_0);
				if (bool_1)
				{
					AI.ReturnToBase(1f);
				}
				ParentScen.AddMessage(activeUnit_0.Name + "现在是基地" + Name + text, Name + " 指定了新基地", LoggedMessage.MessageType.AirOps, 5, ObjectID, GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
			}
			else
			{
				string string_ = "未能设置" + activeUnit_0.Name + "作为新的基地" + Name + text + "。原因：" + text2;
				if (bool_2)
				{
					GameGeneral.ResolveBridge(string_, GetUnitSide(), "设置基地失败" + Name, GameGeneral.MessageBoxMessageType.Warning);
				}
				ParentScen.AddMessage(string_, Name + " 无法指定新基地", LoggedMessage.MessageType.AirOps, 5, ObjectID, GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
			}
		}
		if (!flag)
		{
			return;
		}
		Module_Unit.Unit unit = null;
		foreach (ActiveUnit value in ((Group)activeUnit_0).Units.Values)
		{
			if (Operators.CompareString(AirOps.ThisUnitCanHostMe(value), "OK", TextCompare: false) == 0)
			{
				AirOps.SetAssignedHostUnit(bool_0: false, value);
				unit = value;
				break;
			}
		}
		if (unit == null)
		{
			ParentScen.AddMessage("未能设置" + activeUnit_0.Name + "作为新的基地" + Name + text, Name + " 无法指定新基地", LoggedMessage.MessageType.AirOps, 5, ObjectID, GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
		}
		else
		{
			ParentScen.AddMessage(activeUnit_0.Name + "现在是基地" + Name + text, Name + " 指定了新基地", LoggedMessage.MessageType.AirOps, 5, ObjectID, GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
		}
	}

	public override bool CanMoveToThisLocation(double double_0, double double_1, ref int int_0, bool bool_1, bool bool_2, bool bool_3, ref bool bool_4, bool bool_5, ref bool bool_6, float? nullable_0, short? nullable_1, ref List<ActiveUnit> list_0, float float_0, bool bool_7, bool bool_8, ref string string_0, ref bool bool_9)
	{
		try
		{
			int_0 = 1;
			if (!double.IsNaN(double_0) && !double.IsNaN(double_1))
			{
				if (bool_7 && Status == _ActiveUnitStatus.EngagedOffensive && AssignedMissionOrPackage() != null && AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
				{
					Patrol patrol = (Patrol)AssignedMissionOrPackage();
					Geopoint_Struct geopoint_Struct = new Geopoint_Struct(double_1, double_0);
					if (GetIsInsideThisArea(patrol.ProsecutionArea, ParentScen, bool_0: true) && !GeoPoint.IsInsideThisArea(geopoint_Struct.Latitude, geopoint_Struct.Longitude, patrol.ProsecutionArea))
					{
						bool_4 = false;
						bool_6 = false;
						string_0 = "目标已离开警戒区。";
						return false;
					}
				}
				if (bool_8)
				{
					bool_4 = CustomizeClient();
				}
				if ((bool_4 || bool_1) && CountClient(double_0, double_1, float_0))
				{
					bool_4 = true;
					bool_6 = false;
					string_0 = "这一点在禁航区域内。";
					return false;
				}
				bool_4 = false;
				bool_6 = false;
				return true;
			}
			bool_4 = false;
			bool_6 = false;
			string_0 = "Unknown.";
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200284", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			bool_4 = false;
			bool_6 = false;
			string_0 = "Error.";
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal bool NewFacade()
	{
		return AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Parked;
	}

	public override bool IsParkedAndReady()
	{
		if (AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Parked)
		{
			return AirOps.ConditionTimer == 0f;
		}
		return false;
	}

	internal bool PushFacade()
	{
		if (AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Parked && AirOps.ConditionTimer == 0f)
		{
			return true;
		}
		if (AirOps.Condition == Aircraft_AirOps._AirOpsCondition.HoldingForAvailableRunway)
		{
			return true;
		}
		if (AirOps.Condition == Aircraft_AirOps._AirOpsCondition.HoldingForAvailableTransit)
		{
			return true;
		}
		return false;
	}

	public override bool IsParkedAndReadying()
	{
		if ((AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Parked) | (AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying))
		{
			return AirOps.ConditionTimer > 0f;
		}
		return false;
	}

	public override bool IsOperating()
	{
		try
		{
			switch (AirOps.Condition)
			{
			default:
				return false;
			case Aircraft_AirOps._AirOpsCondition.Airborne:
			case Aircraft_AirOps._AirOpsCondition.Landing_PreTouchdown:
			case Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue:
			case Aircraft_AirOps._AirOpsCondition.RTB:
			case Aircraft_AirOps._AirOpsCondition.ManoeuveringToRefuel:
			case Aircraft_AirOps._AirOpsCondition.Refuelling:
			case Aircraft_AirOps._AirOpsCondition.OffloadingFuel:
			case Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar:
			case Aircraft_AirOps._AirOpsCondition.EmergencyLanding:
			case Aircraft_AirOps._AirOpsCondition.const_19:
			case Aircraft_AirOps._AirOpsCondition.BVRCrank:
			case Aircraft_AirOps._AirOpsCondition.Dogfight:
			case Aircraft_AirOps._AirOpsCondition.TransferringCargo:
			case Aircraft_AirOps._AirOpsCondition.BVRDrag:
				return true;
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
			return false;
		}
	}

	public override void Fuel_Subtract(float float_0, FuelRec._FuelType _FuelType_0)
	{
		try
		{
			float num = float_0;
			if (Loadout != null)
			{
				WeaponRec[] weapons = Loadout.Weapons;
				WeaponRec[] array = weapons;
				foreach (WeaponRec weaponRec in array)
				{
					if (num == 0f)
					{
						break;
					}
					if (weaponRec.GetReferenceWeapon(ParentScen).IsFuelTank)
					{
						FuelRec fuelRec = weaponRec.GetReferenceWeapon(ParentScen).Fuel_ReadOnly[0];
						FuelRec fuelRec2 = new FuelRec(0, (short)fuelRec.FuelType);
						int currentLoad = weaponRec.CurrentLoad;
						fuelRec2.CurrentQuantity = fuelRec.CurrentQuantity * (float)currentLoad;
						fuelRec2.MaxQuantity = fuelRec.MaxQuantity * currentLoad;
						if (!(fuelRec2.CurrentQuantity < num))
						{
							fuelRec2.CurrentQuantity -= num;
							fuelRec.CurrentQuantity = fuelRec2.CurrentQuantity / (float)currentLoad;
							num = 0f;
							break;
						}
						num -= fuelRec2.CurrentQuantity;
						fuelRec2.CurrentQuantity = 0f;
						fuelRec.CurrentQuantity = 0f;
					}
				}
			}
			if (num == 0f)
			{
				return;
			}
			FuelRec fuelRec3 = _Fuel[0];
			if (fuelRec3.CurrentQuantity <= num)
			{
				string text = "";
				if (Operators.CompareString(Name, UnitClass, TextCompare: false) != 0)
				{
					text = " (" + UnitClass + ")";
				}
				AddMessage(Name + text + "已耗尽燃料并坠毁！", Name + " 已逃脱！", LoggedMessage.MessageType.UnitLost, 1, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
				ParentScen.DestroyThisUnit(this, "Out of fuel, crashed.", "燃料已用完");
			}
			else
			{
				fuelRec3.SubtractFuel(num);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100370", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void Fuel_Add(float float_0, FuelRec._FuelType _FuelType_0)
	{
		try
		{
			float num = float_0;
			FuelRec fuelRec = _Fuel[0];
			float num2 = (float)fuelRec.MaxQuantity - fuelRec.CurrentQuantity;
			if (num2 <= num)
			{
				fuelRec.CurrentQuantity = fuelRec.MaxQuantity;
				num -= num2;
			}
			else
			{
				fuelRec.AddFuel(num);
				num = 0f;
			}
			if (num == 0f || Loadout == null)
			{
				return;
			}
			WeaponRec[] weapons = Loadout.Weapons;
			WeaponRec[] array = weapons;
			foreach (WeaponRec weaponRec in array)
			{
				if (weaponRec.GetReferenceWeapon(ParentScen).IsFuelTank && num > 0f)
				{
					FuelRec fuelRec2 = weaponRec.GetReferenceWeapon(ParentScen).Fuel_ReadOnly[0];
					FuelRec fuelRec3 = new FuelRec(0, (short)fuelRec2.FuelType);
					int currentLoad = weaponRec.CurrentLoad;
					fuelRec3.CurrentQuantity = fuelRec2.CurrentQuantity * (float)currentLoad;
					fuelRec3.MaxQuantity = fuelRec2.MaxQuantity * currentLoad;
					num2 = (float)fuelRec3.MaxQuantity - fuelRec3.CurrentQuantity;
					if (num2 <= num)
					{
						fuelRec3.CurrentQuantity = fuelRec3.MaxQuantity;
						num -= num2;
					}
					else
					{
						fuelRec3.CurrentQuantity += num;
						num = 0f;
					}
					fuelRec2.CurrentQuantity = fuelRec3.CurrentQuantity / (float)currentLoad;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100371", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void DoFuelConsumption(float float_0)
	{
		try
		{
			if (Propulsion.Where((Engine theE) => theE.Status == PlatformComponent._ComponentStatus.Operational).Count() == 0)
			{
				AddMessage(Name + " (" + UnitClass + "）没有运转的发动机，正在被抛弃！", Name + " 跳伞！", LoggedMessage.MessageType.UnitLost, 0, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
				ParentScen.DestroyThisUnit(this, "No functioning engines, crashed.", "Weapon Interaction");
			}
			float float_ = FuelConsumption(ThrottleSetting, null, (int)Math.Round(DesiredSpeed), GetCurrentAltitude(), bool_1: false, bool_2: false, bool_3: false, bool_4: false, bool_5: false) * float_0;
			Fuel_Subtract(float_, FuelRec._FuelType.AviationFuel);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100372", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private float InvokeFacade()
	{
		switch (Type)
		{
		default:
			return 0.1f;
		case _AircraftType.CAS:
			return 0.5f;
		case _AircraftType.Fighter:
		case _AircraftType.Attack:
			return 0.3f;
		}
	}

	[SpecialName]
	public override float GetDamagePts(bool bool_1 = false, Weapon weapon_0 = null)
	{
		return base.GetDamagePts(bool_1, weapon_0);
	}

	[SpecialName]
	public override void SetDamagePts(bool bool_1, Weapon weapon_0, float float_0)
	{
		bool num = float_0 != base.GetDamagePts();
		float damagePercent = Damage.DamagePercent;
		base.SetDamagePts(bool_1, weapon_0, float_0);
		float damagePercent2 = Damage.DamagePercent;
		if (num && !bool_1)
		{
			float num2 = InvokeFacade();
			if (damagePercent < num2 * 100f && damagePercent2 >= num2 * 100f && !IsBeingDestroyed && !base.IsDestroyed)
			{
				AirOps.AttemptToRTB(bool_0: false, _ActiveUnitStatus.RTB, bool_1: false, _ActiveUnitStatus.RTB_Group, bool_2: true, bool_3: true);
				Weaponry.JettisonOrdnance(bool_1: false, bool_2: true, bool_3: true, bool_4: true, bool_5: false, bool_6: false, bool_7: false);
			}
		}
	}

	internal List<WeaponRec> SetupFacade(Weapon._WeaponType _WeaponType_0)
	{
		if (Information.IsNothing(Loadout))
		{
			return null;
		}
		List<WeaponRec> list = new List<WeaponRec>();
		if (_WeaponType_0 == Weapon._WeaponType.DropTank)
		{
			WeaponRec[] weapons = Loadout.Weapons;
			WeaponRec[] array = weapons;
			foreach (WeaponRec weaponRec in array)
			{
				if (weaponRec.GetReferenceWeapon(ParentScen).IsFuelTank && weaponRec.CurrentLoad > 0)
				{
					list.Add(weaponRec);
				}
			}
		}
		return list;
	}

	private int ExcludeFacade()
	{
		int num = Loadout.PayloadWeight;
		switch (Loadout.Role)
		{
		case Loadout.LoadoutRole.Cargo:
			num = (int)Math.Round(1000f * CargoHostHelper.GetCurrentLoadTotalMass(this, OnboardCargo));
			break;
		case Loadout.LoadoutRole.Paratroopers:
		case Loadout.LoadoutRole.Troop_Transport:
		{
			float currentLoadTotalCrewSpace = CargoHostHelper.GetCurrentLoadTotalCrewSpace(this, OnboardCargo);
			num = ((!(currentLoadTotalCrewSpace <= 0f)) ? ((int)Math.Round((float)num * currentLoadTotalCrewSpace / IncludeFacade())) : 0);
			break;
		}
		}
		return num;
	}

	public override float FuelConsumption(Throttle throttle_0, AltBand altBand_0, float? nullable_0, float? nullable_1, bool bool_1, bool bool_2, bool bool_3, bool bool_4, bool bool_5)
	{
		AltBand altBand = null;
		AltBand altBand2 = null;
		if (Propulsion.Count == 0)
		{
			return 0f;
		}
		try
		{
			List<Engine> list = new List<Engine>();
			foreach (Engine item in Propulsion)
			{
				if (item.Status == PlatformComponent._ComponentStatus.Operational)
				{
					list.Add(item);
				}
			}
			if (list.Count == 0)
			{
				return 0f;
			}
			Engine engine = list[0];
			if (engine.AltBands.Length == 0)
			{
				return 0f;
			}
			altBand = ((altBand_0 != null) ? altBand_0 : (nullable_1.HasValue ? Kinematics.GetCurrentAltBand_CurrentAltitude(nullable_1.Value, null, bool_0: false) : Kinematics.GetCurrentAltBand(GetCurrentAltitude(), bool_0: false)));
			if (altBand == null)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new Exception();
			}
			float num = 0f;
			bool flag = false;
			float num8;
			switch (throttle_0)
			{
			default:
				return 0f;
			case Throttle.FullStop:
				if (altBand.Speed_Full.HasValue)
				{
					num8 = altBand.Consumption_Full.Value;
					flag = true;
					break;
				}
				throw new Exception("飞机有全油门但数据库中没有全油门消耗参数！");
			case Throttle.Loiter:
				num8 = altBand.Consumption_Loiter;
				if (GetCanHover(bool_1: false))
				{
					num = altBand.Consumption_Full.Value;
				}
				else
				{
					flag = true;
				}
				break;
			case Throttle.Cruise:
				num8 = altBand.Consumption_Cruise;
				num = altBand.Consumption_Loiter;
				break;
			case Throttle.Full:
				if (altBand.Speed_Full.HasValue)
				{
					num8 = altBand.Consumption_Full.Value;
					_ = altBand.Speed_Full.Value;
					num = altBand.Consumption_Cruise;
					break;
				}
				if (!bool_4)
				{
					throw new Exception("飞机有军用油门但数据库中没有油耗参数！");
				}
				num8 = altBand.Consumption_Cruise;
				num = altBand.Consumption_Loiter;
				throttle_0 = Throttle.Cruise;
				break;
			case Throttle.Flank:
				if (altBand.Speed_Flank.HasValue)
				{
					num8 = altBand.Consumption_Flank.Value;
					_ = altBand.Speed_Flank.Value;
					num = (altBand.Speed_Full.HasValue ? altBand.Consumption_Full.Value : altBand.Consumption_Cruise);
					break;
				}
				if (!bool_4)
				{
					throw new Exception("飞机有加力燃烧室油门，但数据库中没有燃油消耗参数！");
				}
				if (altBand.Speed_Full.HasValue)
				{
					num8 = altBand.Consumption_Full.Value;
					_ = altBand.Speed_Full.Value;
					num = altBand.Consumption_Cruise;
					throttle_0 = Throttle.Full;
				}
				else
				{
					num8 = altBand.Consumption_Cruise;
					num = altBand.Consumption_Loiter;
					throttle_0 = Throttle.Cruise;
				}
				break;
			}
			float num9 = num8;
			if (nullable_0.HasValue && nullable_1.HasValue)
			{
				if (altBand != Kinematics.HighestAltBand(engine))
				{
					AltBand[] altBands = engine.AltBands;
					if (altBands.Length == 0)
					{
						return 0f;
					}
					List<AltBand> list2 = new List<AltBand>();
					AltBand[] array = altBands;
					AltBand[] array2 = array;
					foreach (AltBand altBand3 in array2)
					{
						if (altBand3.MinAlt >= altBand.MaxAlt)
						{
							list2.Add(altBand3);
						}
					}
					switch (list2.Count)
					{
					default:
					{
						float num10 = float.MaxValue;
						foreach (AltBand item2 in list2)
						{
							if (item2.MaxAlt < num10)
							{
								altBand2 = item2;
								num10 = item2.MaxAlt;
							}
						}
						break;
					}
					case 1:
						altBand2 = list2[0];
						break;
					case 0:
						altBand2 = null;
						break;
					}
					if (altBand2 != null)
					{
						float num11 = 0f;
						float num12 = 0f;
						switch (throttle_0)
						{
						default:
							return 0f;
						case Throttle.FullStop:
							if (altBand2.Speed_Full.HasValue)
							{
								num11 = altBand.Consumption_Full.Value;
								break;
							}
							throw new Exception("直升机处于全停止油门，但数据库中不存在全油门消耗参数！");
						case Throttle.Loiter:
							num11 = altBand2.Consumption_Loiter;
							if (!flag)
							{
								num12 = altBand2.Consumption_Full.Value;
							}
							break;
						case Throttle.Cruise:
							num11 = altBand2.Consumption_Cruise;
							num12 = altBand2.Consumption_Loiter;
							break;
						case Throttle.Full:
							if (altBand2.Speed_Full.HasValue)
							{
								num11 = altBand2.Consumption_Full.Value;
								_ = altBand2.Speed_Full.Value;
								num12 = altBand2.Consumption_Cruise;
								break;
							}
							if (bool_4)
							{
								num8 = altBand.Consumption_Cruise;
								num = altBand.Consumption_Loiter;
								throttle_0 = Throttle.Cruise;
								break;
							}
							throw new Exception("飞机有军用油门但数据库中没有油耗参数！");
						case Throttle.Flank:
							if (altBand2.Speed_Flank.HasValue)
							{
								num11 = altBand2.Consumption_Flank.Value;
								_ = altBand2.Speed_Flank.Value;
								num12 = (altBand2.Speed_Full.HasValue ? altBand2.Consumption_Full.Value : altBand2.Consumption_Cruise);
								break;
							}
							if (bool_4)
							{
								if (altBand.Speed_Full.HasValue)
								{
									num8 = altBand.Consumption_Full.Value;
									_ = altBand.Speed_Full.Value;
									num = altBand.Consumption_Cruise;
									throttle_0 = Throttle.Full;
								}
								else
								{
									num8 = altBand.Consumption_Cruise;
									num = altBand.Consumption_Loiter;
									throttle_0 = Throttle.Cruise;
								}
								break;
							}
							throw new Exception("飞机有加力燃烧室油门，但数据库中没有燃油消耗参数！");
						}
						if (num8 != num11)
						{
							float? num13 = nullable_1;
							float minAlt = altBand.MinAlt;
							if ((num13.HasValue ? new bool?(num13.GetValueOrDefault() != minAlt) : null).GetValueOrDefault())
							{
								float value = ((nullable_1 - altBand.MinAlt) / (altBand.MaxAlt - altBand.MinAlt)).Value;
								value = Math.Abs(value);
								num8 += (num11 - num8) * value;
								num9 = num8;
								if (!flag)
								{
									num += (num12 - num) * value;
								}
							}
						}
					}
				}
				if (!flag && (!GetCanHover(bool_1: false) || DesiredSpeed > (float)Kinematics.GetMaximumSpeed(GetCurrentAltitude(), Throttle.Loiter, bool_0: false)))
				{
					float num14 = Kinematics.GetMaximumSpeed(nullable_1.Value, throttle_0, bool_0: false);
					float? num15 = nullable_0;
					if ((num15.HasValue ? new bool?(num15.GetValueOrDefault() < num14) : null).GetValueOrDefault())
					{
						float num2 = Kinematics.GetMaximumSpeed(nullable_1.Value, throttle_0 - 1, bool_0: false);
						num15 = nullable_0;
						float value2;
						if ((num15.HasValue ? new bool?(num15.GetValueOrDefault() >= num2) : null).GetValueOrDefault())
						{
							value2 = ((nullable_0 - num2) / (num14 - num2)).Value;
							value2 = Math.Abs(value2);
						}
						else
						{
							value2 = 0f;
						}
						num9 = ((num2 == 0f) ? (num + (num8 - num) * value2) : (num + (num8 - num) * value2));
					}
				}
			}
			if (Loadout != null)
			{
				float weightDragModifier = Loadout.WeightDragModifier;
				int num3 = 0;
				int num4 = (bool_5 ? Loadout.PayloadWeight_TakeOff : ExcludeFacade());
				if (num4 > 0 && weightDragModifier > 0f)
				{
					if (bool_1 && Loadout.PayloadWeightDroppable > 0 && AssignedMissionOrPackage() != null && AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && !AI.IsEscort)
					{
						Strike strike = (Strike)AssignedMissionOrPackage();
						if (strike.BingoFuel == Mission._BingoFuelSetting.UseLoadoutSetting)
						{
							if (Loadout != null && Loadout.GetMissionProfile(ParentScen).DropBombsAtMaxRange)
							{
								num3 = Loadout.PayloadWeightDroppable;
							}
						}
						else if (strike.BingoFuel == Mission._BingoFuelSetting.ExpendJettison)
						{
							num3 = Loadout.PayloadWeightDroppable;
						}
					}
					if (bool_2 && AssignedMissionOrPackage() != null && AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && !AI.IsEscort)
					{
						Strike strike2 = (Strike)AssignedMissionOrPackage();
						if (strike2.BingoFuel == Mission._BingoFuelSetting.UseLoadoutSetting)
						{
							if (Loadout != null && Loadout.GetMissionProfile(ParentScen).DropBombsAtMaxRange)
							{
								num3 = Loadout.PayloadWeightDroppable;
							}
						}
						else if (strike2.BingoFuel == Mission._BingoFuelSetting.ExpendJettison)
						{
							num3 = Loadout.PayloadWeightDroppable;
						}
					}
					if (bool_3 && AssignedMissionOrPackage() != null && AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && !AI.IsEscort)
					{
						Strike strike3 = (Strike)AssignedMissionOrPackage();
						if (strike3.BingoFuel == Mission._BingoFuelSetting.UseLoadoutSetting)
						{
							if (Loadout != null && Loadout.GetMissionProfile(ParentScen).DropBombsAtMaxRange)
							{
								if (bool_5)
								{
									num3 = Loadout.PayloadWeightDroppable_TakeOff;
								}
								else
								{
									num3 = Loadout.PayloadWeightDroppable;
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
								}
							}
						}
						else if (strike3.BingoFuel == Mission._BingoFuelSetting.ExpendJettison)
						{
							if (bool_5)
							{
								num3 = Loadout.PayloadWeightDroppable_TakeOff;
							}
							else
							{
								num3 = Loadout.PayloadWeightDroppable;
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
							}
						}
					}
					float num5 = weightDragModifier * (num9 * (float)(num4 - num3)) / 100f;
					num9 += num5;
				}
			}
			int num6 = 0;
			foreach (Engine item3 in Propulsion)
			{
				if (item3.Status == PlatformComponent._ComponentStatus.Operational)
				{
					num6++;
				}
			}
			double num7 = (double)num6 / (double)Propulsion.Count;
			num9 = (float)((double)num9 * num7);
			return num9 / 60f;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			ex?.Data.Add("Error at 100373", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public static string LoadoutWeaponStateDescirption(int int_0, int int_1, Loadout.LoadoutRole loadoutRole_0, Scenario scenario_0)
	{
		switch (int_1)
		{
		case 2002:
			if ((uint)(loadoutRole_0 - 2001) <= 6u)
			{
				return "Winchester：当任务武器耗尽时返回基地。允许使用空对空机炮的机会目标。";
			}
			return "Winchester：当任务武器耗尽时返回基地。立即撤离。";
		case 2001:
			return "Winchester：当任务武器耗尽时返回基地。立即撤离。";
		case 4002:
			return "机炮：当25％的相关武器已用完时返回基地。允许机会目标，包括空对空机炮。";
		case 4001:
			return "机炮：当25％的相关武器已用完时返回基地。立即撤离。";
		case 3001:
			if ((uint)(loadoutRole_0 - 2001) <= 6u)
			{
				return "机炮：当所有BVR武器都用完后返回基地。立即撤离。";
			}
			return "机炮：当所有防区外都用完后返回基地。立即撤离。";
		case 3002:
			if ((uint)(loadoutRole_0 - 2001) <= 6u)
			{
				return "机炮：当所有BVR武器都用完后返回基地。使用视距内武器轻松实现机会目标。不使用空对空机炮。";
			}
			return "机炮：当所有防区外都用完后返回基地。使用打击武器轻松实现机会目标。";
		case 3003:
			if ((uint)(loadoutRole_0 - 2001) <= 6u)
			{
				return "机炮：当所有BVR武器都用完后返回基地。允许利用视距内武器和空对空机炮攻击机会目标。";
			}
			return "机炮：当所有防区外都用完后返回基地。使用打击武器轻松实现机会目标。";
		case 4012:
			return "机炮：当50％的相关武器已用完时返回基地。允许机会目标，包括空对空机炮。";
		case 4011:
			return "机炮：当50％的相关武器已用完时返回基地。立即撤离。";
		case 5001:
			if ((uint)(loadoutRole_0 - 2001) <= 6u)
			{
				return "机炮：在与BVR武器交战后返回基地。立即撤离。";
			}
			return "机炮：在与防区外武器交战后返回基地。立即撤离。";
		case 5002:
			if ((uint)(loadoutRole_0 - 2001) <= 6u)
			{
				return "机炮：在与BVR武器交战后返回基地。使用视距内武器轻松实现机会目标。没有空对空机炮。";
			}
			return "机炮：在与防区外武器交战后返回基地。使用打击武器轻松实现机会目标。";
		case 5003:
			if ((uint)(loadoutRole_0 - 2001) <= 6u)
			{
				return "机炮：在与BVR武器交战后返回基地。利用视距内武器和空对空机炮，轻松实现机会目标。";
			}
			return "机炮：在与防区外武器交战后返回基地。使用打击武器轻松实现机会目标。";
		case 5005:
			if ((uint)(loadoutRole_0 - 2001) <= 6u)
			{
				return "机炮：在与BVR和视距内武器交战后返回基地。没有空对空机炮。";
			}
			return "机炮：在与一个防区外和直接攻击武器交战后返回基地。";
		case 5006:
			if ((uint)(loadoutRole_0 - 2001) <= 6u)
			{
				return "机炮：在与BVR和视距内武器交战后返回基地。通过空对空机炮轻松实现机会目标。";
			}
			return "机炮：在与一个防区外和直接攻击武器交战后返回基地。";
		default:
		{
			SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
			return DBFunctions.GetLoadoutWeaponStateDescription(int_0, int_1, ref sqliteConnection_, scenario_0, bool_0: true, loadoutRole_0);
		}
		case 5011:
			if ((uint)(loadoutRole_0 - 2001) <= 6u)
			{
				return "机炮：在与WVR的一次交战后返回基地。立即撤离。";
			}
			return "机炮：与直接攻击武器交战后返回基地。立即撤离。";
		case 5012:
			if ((uint)(loadoutRole_0 - 2001) <= 6u)
			{
				return "机炮：在与视距内武器交战后返回基地。允许使用空对空机炮的机会目标。";
			}
			return "机炮：与直接攻击武器交战后返回基地。";
		case 4022:
			return "机炮：75％的相关武器已用完后返回基地。允许机会目标，包括空对空机炮。";
		case 4021:
			return "机炮：75％的相关武器已用完后返回基地。立即撤离。";
		}
	}

	internal float IncludeFacade()
	{
		if (Loadout == null)
		{
			return 0f;
		}
		return Loadout.Cargo_Crew;
	}

	float ICargoHost.GetCargo_Crew()
	{
		return IncludeFacade();
	}

	internal float SearchFacade()
	{
		if (Loadout == null)
		{
			return 0f;
		}
		if (Loadout.Cargo_Type == CargoType.Personnel && Loadout.Cargo_Area == 0f)
		{
			return (float)Loadout.Cargo_Crew * Mount.PersonnelArea;
		}
		return Loadout.Cargo_Area;
	}

	float ICargoHost.GetCargo_Area()
	{
		return SearchFacade();
	}

	internal CargoType EnableFacade()
	{
		if (Loadout == null)
		{
			return CargoType.NoCargo;
		}
		return Loadout.Cargo_Type;
	}

	CargoType ICargoHost.GetCargo_Type()
	{
		return EnableFacade();
	}

	internal float ChangeFacade()
	{
		if (Loadout == null)
		{
			return 0f;
		}
		if (Loadout.Cargo_Type == CargoType.Personnel && Loadout.Cargo_Mass == 0f)
		{
			return (float)Loadout.Cargo_Crew * Mount.PersonnelMass;
		}
		return Loadout.Cargo_Mass;
	}

	float ICargoHost.GetCargo_Mass()
	{
		return ChangeFacade();
	}

	public float GetCargo_TowingCapacity()
	{
		return 0f;
	}

	public float GetCargo_MassAvailable()
	{
		if (Loadout == null)
		{
			return 0f;
		}
		return CargoHostHelper.GetAvailableMass(this, OnboardCargo);
	}

	internal bool InitFacade()
	{
		if (Loadout == null)
		{
			return false;
		}
		return Loadout.Cargo_ParadropCapable;
	}

	bool ICargoHost.GetCargo_ParadropCapable()
	{
		return InitFacade();
	}

	internal bool CheckFacade()
	{
		return false;
	}

	bool ICargoHost.CanStackCargo()
	{
		return CheckFacade();
	}

	public float GetCargo_Height()
	{
		return 0f;
	}

	internal int ConcatFacade(List<Cargo> list_0)
	{
		if (list_0 != null && list_0.Count > 0)
		{
			double num = 0.0;
			double num2 = 0.0;
			foreach (Cargo item in list_0)
			{
				num2 += (double)item.RequiredMass;
				if (num > -1.0)
				{
					num = ((item.RequiredCargoType == CargoType.Personnel) ? (num + (double)item.RequiredCrewSpace) : (-1.0));
				}
			}
			return (int)Math.Round(((num <= 0.0) ? ActiveUnit_DockingOps.GetCargoMoveTime(10.0, 60.0, num2, ChangeFacade()) : (num / 10.0)) * 60.0);
		}
		return 0;
	}

	int ICargoHost.GetLoadTime(List<Cargo> list_0)
	{
		return ConcatFacade(list_0);
	}

	internal int InterruptFacade(List<Cargo> list_0)
	{
		if (list_0 != null && list_0.Count > 0)
		{
			double num = 0.0;
			double num2 = 0.0;
			foreach (Cargo item in list_0)
			{
				num2 += (double)item.RequiredMass;
				if (num > -1.0)
				{
					num = ((item.RequiredCargoType == CargoType.Personnel) ? (num + (double)item.RequiredCrewSpace) : (-1.0));
				}
			}
			return (int)Math.Round(((num <= 0.0) ? ActiveUnit_DockingOps.GetCargoMoveTime(2.0, 60.0, num2, ChangeFacade()) : (num / 20.0)) * 60.0);
		}
		return 0;
	}

	int ICargoHost.GetUnloadTime(List<Cargo> list_0)
	{
		return InterruptFacade(list_0);
	}

	public bool CanLoad(ICargoClient icargoClient_0)
	{
		return CargoHostHelper.CanLoad(this, OnboardCargo, icargoClient_0);
	}

	public bool Add(Cargo cargo_0)
	{
		return CargoHostHelper.Add(this, cargo_0);
	}

	public bool Remove(Cargo cargo_0)
	{
		return CargoHostHelper.Remove(this, cargo_0);
	}

	public bool CanTow(ICargoClient icargoClient_0)
	{
		return false;
	}

	internal override List<Sensor> DeleteInterruptibleIdentifier()
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
		if (Loadout != null)
		{
			foreach (Sensor item in Loadout.NewClass(ParentScen))
			{
				item.IsSensorInLoadout = true;
				_SensorList.Add(item);
			}
			HashSet<int> hashSet = new HashSet<int>();
			if (Loadout.Weapons != null)
			{
				WeaponRec[] weapons = Loadout.Weapons;
				WeaponRec[] array3 = weapons;
				foreach (WeaponRec weaponRec in array3)
				{
					if (weaponRec.CurrentLoad <= 0)
					{
						continue;
					}
					Weapon referenceWeapon = weaponRec.GetReferenceWeapon(ParentScen);
					if (!referenceWeapon.CanActAsSensor && referenceWeapon.Type != Weapon._WeaponType.HeliTowedPackage)
					{
						continue;
					}
					sensors = referenceWeapon.Sensors_ReadOnly();
					Sensor[] array4 = sensors;
					foreach (Sensor sensor3 in array4)
					{
						if (referenceWeapon.Type != Weapon._WeaponType.SensorPod && referenceWeapon.Type != Weapon._WeaponType.HeliTowedPackage)
						{
							if (!hashSet.Contains(sensor3.DBID))
							{
								hashSet.Add(sensor3.DBID);
								sensor3.IsSensorInLoadout = true;
								_SensorList.Add(sensor3);
								if (sensor3.ScanInterval < 10)
								{
									sensor3.ScanInterval = 10;
								}
							}
						}
						else
						{
							_SensorList.Add(sensor3);
							sensor3.IsSensorInLoadout = true;
						}
					}
				}
			}
		}
		return new List<Sensor>(_SensorList);
	}

	public override void ActualHorizMovement(float float_0, bool bool_1)
	{
		if (CurrentSpeed == 0f)
		{
			return;
		}
		Longitude_old = GetLongitude();
		Latitude_old = GetLatitude();
		try
		{
			float num = (IsActiveUnit ? ((ActiveUnit)this).Kinematics.HorizMovementDistanceOnThisTime(float_0) : GetHorizMovementDistanceOnThisTime(float_0));
			double double_ = 0.0;
			double double_3 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(Longitude_old, Latitude_old, ref double_, ref double_3, num, CurrentHeading);
			if (double.IsNaN(double_3))
			{
				double_3 = Latitude_old;
			}
			if (double.IsNaN(double_))
			{
				double_ = Longitude_old;
			}
			bool bool_2 = false;
			bool bool_3 = true;
			bool bool_4 = true;
			double double_4 = double_3;
			double double_5 = double_;
			int int_ = 0;
			string string_ = "";
			List<ActiveUnit> list_ = null;
			if (CanMoveToThisLocation(double_4, double_5, ref int_, bool_1: false, bool_2: false, bool_3: true, ref bool_3, bool_5: true, ref bool_2, null, null, ref list_, 0f, bool_7: false, bool_8: true, ref string_, ref bool_4))
			{
				SetLatitude(null, double_3);
				SetLongitude(null, double_);
				if (ParentScen.MinuteIsChangingOnThisPulse)
				{
					((ActiveUnit)this).Navigator.GetNearestAccessibleSpotHeading = null;
				}
			}
			else if (bool_2)
			{
				if (!ParentScen.MinuteIsChangingOnThisPulse && !Information.IsNothing(((ActiveUnit)this).Navigator.GetNearestAccessibleSpotHeading))
				{
					CurrentHeading = ((ActiveUnit)this).Navigator.GetNearestAccessibleSpotHeading.Value;
				}
				else
				{
					if (bool_2 && ((ActiveUnit)this).Navigator.HasPathfindingPlottedCourse)
					{
						((ActiveUnit)this).Navigator.ClearPathfindingWaypoints();
					}
					double double_6 = 0.0;
					double double_7 = 0.0;
					if (((ActiveUnit)this).Navigator.GetNearestAccessibleSpot(double_3, double_, ref double_6, ref double_7, bool_1: false, bool_2: false, bool_3: true, 0f, ref list_, bool_4: false))
					{
						((ActiveUnit)this).Navigator.GetNearestAccessibleSpotHeading = Math2.PublishClass(GetLatitude(), GetLongitude(), double_6, double_7);
						CurrentHeading = ((ActiveUnit)this).Navigator.GetNearestAccessibleSpotHeading.Value;
						((ActiveUnit)this).Navigator.ResetTimeToNextPathfinderCheck();
					}
				}
				SetLatitude(null, double_3);
				SetLongitude(null, double_);
			}
			else if (bool_3)
			{
				SetLatitude(null, double_3);
				SetLongitude(null, double_);
				if (ParentScen.MinuteIsChangingOnThisPulse)
				{
					((ActiveUnit)this).Navigator.GetNearestAccessibleSpotHeading = null;
				}
			}
			else
			{
				double latitude_old = Latitude_old;
				double longitude_old = Longitude_old;
				int_ = 0;
				string_ = "";
				if (CanMoveToThisLocation(latitude_old, longitude_old, ref int_, bool_1: false, bool_2: false, bool_3: true, ref bool_3, bool_5: true, ref bool_2, null, null, ref list_, 0f, bool_7: false, bool_8: true, ref string_, ref bool_4))
				{
					bool_4 = true;
				}
				if (bool_4)
				{
					CurrentHeading = Bounce(CurrentHeading, num, bool_0: false);
					Geodesic_EdWilliams.CalcPoint_Williams(GetLongitude(), GetLatitude(), ref double_, ref double_3, num, CurrentHeading);
					if (ParentScen.MinuteIsChangingOnThisPulse)
					{
						double double_8 = double_3;
						double double_9 = double_;
						int_ = 0;
						bool bool_5 = false;
						string_ = "";
						bool bool_6 = false;
						double double_10 = 0.0;
						double double_2 = 0.0;
						if (!CanMoveToThisLocation(double_8, double_9, ref int_, bool_1: false, bool_2: false, bool_3: true, ref bool_5, bool_5: true, ref bool_2, null, null, ref list_, 0f, bool_7: false, bool_8: false, ref string_, ref bool_6) && ((ActiveUnit)this).Navigator.GetNearestAccessibleSpot(double_3, double_, ref double_10, ref double_2, bool_1: false, bool_2: false, bool_3: true, 0f, ref list_, bool_4: false))
						{
							double_3 = double_10;
							double_ = double_2;
							((ActiveUnit)this).Navigator.ResetTimeToNextPathfinderCheck();
						}
						((ActiveUnit)this).Navigator.GetNearestAccessibleSpotHeading = null;
					}
				}
			}
			SetLatitude(null, double_3);
			SetLongitude(null, double_);
			if (double.IsNaN(GetLatitude()))
			{
				SetLatitude(null, Latitude_old);
			}
			if (double.IsNaN(GetLongitude()))
			{
				SetLongitude(null, Longitude_old);
			}
			if (!bool_1)
			{
				CacheOldPosAndNextPos(float_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100875", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool RemoveFacade()
	{
		List<ActiveUnit> list = new List<ActiveUnit>(ParentScen.ActiveUnits_List);
		List<ActiveUnit> list2 = new List<ActiveUnit>();
		foreach (ActiveUnit item in list)
		{
			if (item.GetUnitSide() != GetUnitSide() && !Module_Side.IsAlliedWithThisSide(GetUnitSide(), item.GetUnitSide()))
			{
				continue;
			}
			if (item.IsFixedFacility && item.GetParentGroup() != null && item.GetParentGroup().Type == Group.GroupType.AirBase)
			{
				Group parentGroup = item.GetParentGroup();
				if (!list2.Contains(parentGroup) && Operators.CompareString(AirOps.ThisUnitCanHostMe(parentGroup), "OK", TextCompare: false) == 0)
				{
					list2.Add(parentGroup);
				}
			}
			else if ((item.IsSingleUnitAirbase || item.IsShip) && Operators.CompareString(AirOps.ThisUnitCanHostMe(item), "OK", TextCompare: false) == 0)
			{
				list2.Add(item);
			}
		}
		if (list2.Count > 1)
		{
			ActiveUnit activeUnit = list2.OrderBy((ActiveUnit activeUnit_0) => Module_Unit.RangeToUnit_Horiz(activeUnit_0, this)).First();
			if (AirOps.GetAssignedHostUnit() != activeUnit)
			{
				AttemptToSetNewAssignedHost(activeUnit, bool_1: true);
				if (AirOps.GetAssignedHostUnit() == activeUnit)
				{
					string text = "";
					if (Operators.CompareString(Name, UnitClass, TextCompare: false) != 0)
					{
						text = " (" + UnitClass + ")";
					}
					AddMessage(Name + text + " diverting to new base to land: " + activeUnit.Name + ".", Name + " emergency diversion!", LoggedMessage.MessageType.UnitAIEmergency, 0, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
				}
			}
		}
		return false;
	}

	[CompilerGenerated]
	private double FindFacade(Aircraft aircraft_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(this, aircraft_0);
	}

	[CompilerGenerated]
	private float SetFacade(ActiveUnit activeUnit_0)
	{
		return Module_Unit.RangeToUnit_Horiz(activeUnit_0, this);
	}
}
