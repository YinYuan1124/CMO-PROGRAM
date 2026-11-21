using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Ship : Platform, ICargoHost, IBoat
{
	public struct _Flags
	{
		public bool PassiveOrSingleStabilizers;

		public bool DualOrTripleStabilizers;

		public bool ShockResistant;

		public bool bool_0;

		public bool CivilianConstruction;

		public bool AviationVessel;

		public bool AluminumConstruction;

		public bool PrairieMasker;

		public bool AdvancedQuieting;

		public bool MCM_DegaussedSteelHull;

		public bool MCM_OnboardDegaussingGear;

		public bool MCM_WoodenHull;

		public bool MCM_GRPHull;

		public bool LowConstructionStandards;

		public bool AllAluminumConstruction;

		public bool AluminumSuperstructureOnly;

		public bool WoodenHullConstruction;

		public bool GRP_Construction;

		public bool Hovercraft_SES;

		public bool CatamaranTrimaranMultihull;

		public bool bool_1;

		public bool BuiltToMercantileStandards;

		public bool CanLaunchCargoDirectlyToSea;
	}

	public enum _ShipCategory
	{
		None = 1001,
		SurfaceCombatant = 2002,
		AviationShip = 2001,
		Amphibious = 2003,
		Auxiliary = 2004,
		Merchant = 2005,
		Civilian = 2006,
		SurfaceCombatantAviation = 2007,
		MobileOffshoreBase = 2008
	}

	public enum _ShipType
	{
		None = 1001,
		CV = 2001,
		CVA = 2002,
		CVB = 2003,
		CVE = 2004,
		CVGH = 2005,
		CVH = 2006,
		CVL = 2007,
		CVN = 2008,
		SeaplaneCarrier = 2009,
		CVS = 2010,
		B = 3001,
		BB = 3002,
		BBC = 3003,
		BBG = 3004,
		BBH = 3005,
		BCGN = 3006,
		BM = 3007,
		C = 3101,
		CA = 3102,
		CAG = 3103,
		CB = 3104,
		CBG = 3105,
		CG = 3106,
		CGH = 3107,
		CGN = 3108,
		CL = 3109,
		CLAA = 3110,
		CLC = 3111,
		CLG = 3112,
		CLH = 3113,
		CS = 3114,
		D = 3201,
		DD = 3202,
		DDG = 3203,
		DDH = 3204,
		DDK = 3205,
		DDR = 3206,
		DE = 3207,
		DEG = 3208,
		DER = 3209,
		DL = 3210,
		DLG = 3211,
		DM = 3212,
		F = 3301,
		FF = 3302,
		FFG = 3303,
		FFL = 3304,
		PF = 3305,
		LCS = 3306,
		OPV = 3307,
		PB = 3401,
		PC1 = 3402,
		PC2 = 3403,
		PCE = 3404,
		PCF = 3405,
		PCFG = 3406,
		PG1 = 3407,
		PG2 = 3408,
		PGM = 3409,
		PH = 3410,
		PHM = 3411,
		PHT = 3412,
		PT = 3413,
		PTS = 3414,
		MTB = 3415,
		WHEC = 3416,
		WMEC = 3417,
		WPB = 3418,
		WPG = 3419,
		MCDV = 3420,
		AGC = 4001,
		LCAC = 4002,
		LCC = 4003,
		LCM = 4004,
		LCP = 4005,
		LCT = 4006,
		LCU = 4007,
		LCVP = 4008,
		LFR = 4009,
		LHA = 4010,
		LHD = 4011,
		LKA = 4012,
		LPD = 4013,
		LPH = 4014,
		LSD = 4015,
		LSH = 4016,
		LSL = 4017,
		LSM = 4018,
		LSMR = 4019,
		LST = 4020,
		LSU = 4021,
		LSV = 4022,
		A = 5001,
		AD = 5002,
		AE = 5003,
		AF = 5004,
		AFS = 5005,
		AG = 5006,
		AGB = 5007,
		AGF = 5008,
		AGI = 5009,
		AGMR = 5010,
		AGOR = 5011,
		AGOS = 5012,
		AGR = 5013,
		AGS = 5014,
		AGTR = 5015,
		AH = 5016,
		AK = 5017,
		AKA = 5018,
		AKE = 5019,
		AKR = 5020,
		AKS = 5021,
		AO = 5022,
		AOE = 5023,
		AOL = 5024,
		AOR = 5025,
		AOT = 5026,
		APA = 5027,
		APD = 5028,
		AR = 5029,
		AS_ = 5030,
		ATC = 5031,
		ATA = 5032,
		ATS = 5033,
		AV = 5034,
		AX = 5035,
		DTV = 5041,
		GPV = 5042,
		TAGOS = 5101,
		TAH = 5102,
		TAK = 5103,
		TAKE = 5104,
		TAKR = 5105,
		TAO1 = 5106,
		TAO2 = 5107,
		TMLP = 5108,
		MCD = 6001,
		MCM = 6002,
		MCS = 6003,
		MHC = 6004,
		ML = 6005,
		MSC = 6006,
		MSF = 6007,
		MSI = 6008,
		MSO = 6010,
		MST = 6011,
		YAG = 7001,
		Civilian = 9001,
		Merchant = 9002,
		Platform = 9003,
		NGSBuoy = 9004,
		BottomFixedArraySonar = 9005,
		MooredSonobuoy = 9006,
		Special = 9007
	}

	public enum ShipWakeSize : byte
	{
		NoWake,
		VSmall,
		Small,
		Medium,
		Large,
		VLarge
	}

	[CompilerGenerated]
	private sealed class IteratorItem
	{
		public Ship _003C_003E4__this;

		public bool UsePathfindingBufferDistance;

		public bool IsPathfindingQuery;

		public bool IgnoreMinesBehindUs;

		public double theLat;

		public double theLon;

		public bool flag;

		public UnguidedWeapon unguidedWeapon;

		internal void RunInterruptibleReg(string theID, ParallelLoopState loopstate)
		{
			if (theID == null)
			{
				return;
			}
			UnguidedWeapon unguidedWeapon = null;
			_003C_003E4__this.ParentScen.UnguidedWeapons.TryGetValue(theID, ref unguidedWeapon);
			if (unguidedWeapon == null || !unguidedWeapon.IsMine)
			{
				return;
			}
			short num = (short)_003C_003E4__this.GetSafeDistanceAgainstKnownMineType_meters(unguidedWeapon.Type, UsePathfindingBufferDistance);
			string string_ = "";
			Math.Abs(Module_Unit.PrintTokenizer(unguidedWeapon, _003C_003E4__this, bool_0: true, ref string_));
			if (!IsPathfindingQuery)
			{
				if (IgnoreMinesBehindUs)
				{
					return;
				}
				UnguidedWeapon unit_ = unguidedWeapon;
				Ship unit_2 = _003C_003E4__this;
				string string_2 = "";
				if (Math.Abs(Module_Unit.PrintTokenizer(unit_, unit_2, bool_0: true, ref string_2)) > 45f)
				{
					return;
				}
			}
			if (Math2.VerifyClass(theLat, theLon, unguidedWeapon.GetLatitude(), unguidedWeapon.GetLongitude()) * 1852f < (float)num && (!_003C_003E4__this.IsMineLayingPlatform || !_003C_003E4__this.IsOnActiveMiningMission || unguidedWeapon.TimeToDetonate <= 0f) && (!((unguidedWeapon.TimeToDetonate > 3600f) & (unguidedWeapon.FiringParent_ID != null)) || !string.Equals(unguidedWeapon.FiringParent_ID, _003C_003E4__this.ObjectID, StringComparison.OrdinalIgnoreCase)))
			{
				flag = true;
				this.unguidedWeapon = unguidedWeapon;
				loopstate.Stop();
			}
		}
	}

	[CompilerGenerated]
	private sealed class SerializerObjectListener
	{
		public FuelRec._FuelType theType;

		internal bool StartInterruptibleReg(FuelRec theFuelrec)
		{
			return theFuelrec.FuelType == theType;
		}
	}

	public int CombatSystemGen;

	public _ShipCategory Category;

	public _ShipType Type;

	public GlobalVariables.ArmorRating Armor_Bridge;

	public GlobalVariables.ArmorRating Armor_Engineering;

	public GlobalVariables.ArmorRating Armor_Belt;

	public GlobalVariables.ArmorRating Armor_Bulkhead;

	public GlobalVariables.ArmorRating Armor_Deck;

	public GlobalVariables.ArmorRating Armor_CIC;

	public GlobalVariables.ArmorRating Armor_Rudder;

	public DockFacility.DockingPhysicalSize DockingPhysicalSize;

	public byte MaxSeaState;

	public short RepairCapacity;

	public short TroopCapacity;

	public int CargoCapacity;

	public short MissileDefense;

	public float Beam;

	public float Draft;

	public float Height;

	public float Cargo_Crew;

	public float Cargo_Area;

	public CargoType Cargo_Type;

	public float Cargo_Mass;

	public _Flags Flags;

	public Rudder Rudder;

	public CIC CIC;

	private Ship_Navigator m_FieldFacade;

	private Ship_AI queueFacade;

	private Ship_Kinematics m_RegFacade;

	private Ship_Sensory _ParamFacade;

	private Ship_Weaponry _PageFacade;

	private Ship_CommStuff _RulesFacade;

	private Ship_Damage methodFacade;

	private bool? _ServiceFacade;

	private float systemFacade;

	private float _CandidateFacade;

	private float baseFacade;

	public const float SMALL_CRAFT_MAX_LENGTH = 13f;

	public const float SMALL_CRAFT_MAX_DRAFT = 0.7f;

	private static Scenario _PolicyFacade;

	public override bool RepresentsMobileGroundUnit => false;

	public override float CurrentAltitude_AGL => GetCurrentAltitude() - (float)Terrain.GetElevation(GetLatitude(), GetLongitude(), bool_0: false, ParentScen);

	public override float FlatSurfaceArea_m2 => Length * Beam;

	public string Type_Description => Type.ToString();

	public override GlobalVariables.ActiveUnitType UnitType => GlobalVariables.ActiveUnitType.Ship;

	public override bool IsMCMPlatform
	{
		get
		{
			switch (Type)
			{
			default:
			{
				if (MineCountermeasures != null && MineCountermeasures.Count > 0)
				{
					return true;
				}
				Sensor[] sensors_Cached = base.Sensors_Cached;
				for (int i = 0; i < sensors_Cached.Length; i = checked(i + 1))
				{
					if (sensors_Cached[i].IsMineHuntingSensor)
					{
						return true;
					}
				}
				return false;
			}
			case _ShipType.MCDV:
			case _ShipType.MCD:
			case _ShipType.MCM:
			case _ShipType.MCS:
			case _ShipType.MHC:
			case _ShipType.MSC:
			case _ShipType.MSF:
			case _ShipType.MSI:
			case _ShipType.MSO:
				return true;
			}
		}
	}

	public override bool IsMineLayingPlatform
	{
		get
		{
			if (Type == _ShipType.ML)
			{
				return true;
			}
			foreach (Mount mount in Mounts)
			{
				if (mount.Status != 0)
				{
					continue;
				}
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					if (mountWeapon.CurrentLoad != 0)
					{
						Weapon referenceWeapon = mountWeapon.GetReferenceWeapon(ParentScen);
						if (referenceWeapon != null && referenceWeapon.IsMine)
						{
							return true;
						}
					}
				}
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
			_ = Status;
			base.Status = value;
		}
	}

	public override float DesiredHeading => base.DesiredHeading;

	public override float DesiredSpeed
	{
		get
		{
			return base.DesiredSpeed;
		}
		set
		{
			if (Navigator.AvoidCavitation && Status != _ActiveUnitStatus.EngagedDefensive)
			{
				float num = Kinematics.CavitationSpeed(0f);
				if (value >= num)
				{
					value = (float)((double)num - 0.1);
				}
			}
			if (value != DesiredSpeed)
			{
				base.DesiredSpeed = value;
			}
		}
	}

	public ShipWakeSize WakeSize
	{
		get
		{
			if (CurrentSpeed == 0f)
			{
				return ShipWakeSize.NoWake;
			}
			if (Type == _ShipType.LCAC && !Module_Unit.ResetTokenizer(this))
			{
				return ShipWakeSize.VLarge;
			}
			float currentSpeed = CurrentSpeed;
			if (currentSpeed < 10f)
			{
				return (ShipWakeSize)Math.Max(0, (int)(VisualSizeClass - 1));
			}
			if (currentSpeed < 20f)
			{
				return (ShipWakeSize)VisualSizeClass;
			}
			if (currentSpeed < 30f)
			{
				return (ShipWakeSize)Math.Min(5, (int)(VisualSizeClass + 1));
			}
			if (currentSpeed < 40f)
			{
				return (ShipWakeSize)Math.Min(5, (int)(VisualSizeClass + 2));
			}
			return (ShipWakeSize)Math.Min(5, (int)(VisualSizeClass + 3));
		}
	}

	public new Ship_Navigator Navigator => m_FieldFacade;

	public new Ship_AI AI => queueFacade;

	public new Ship_Kinematics Kinematics
	{
		get
		{
			if (Information.IsNothing(m_RegFacade))
			{
				ActiveUnit activeUnit_ = this;
				m_RegFacade = new Ship_Kinematics(ref activeUnit_);
			}
			return m_RegFacade;
		}
	}

	public new Ship_Sensory Sensory
	{
		get
		{
			if (Information.IsNothing(_ParamFacade))
			{
				ActiveUnit activeUnit_ = this;
				_ParamFacade = new Ship_Sensory(ref activeUnit_);
			}
			return _ParamFacade;
		}
	}

	public new Ship_Weaponry Weaponry
	{
		get
		{
			if (Information.IsNothing(_PageFacade))
			{
				ActiveUnit activeUnit_ = this;
				_PageFacade = new Ship_Weaponry(ref activeUnit_);
			}
			return _PageFacade;
		}
	}

	public new Ship_CommStuff CommStuff
	{
		get
		{
			if (Information.IsNothing(_RulesFacade))
			{
				ActiveUnit activeUnit_ = this;
				_RulesFacade = new Ship_CommStuff(ref activeUnit_);
			}
			return _RulesFacade;
		}
	}

	public new Ship_Damage Damage
	{
		get
		{
			if (Information.IsNothing(methodFacade))
			{
				ActiveUnit activeUnit_ = this;
				methodFacade = new Ship_Damage(ref activeUnit_);
			}
			return methodFacade;
		}
	}

	public bool IsNuke
	{
		get
		{
			if (!_ServiceFacade.HasValue)
			{
				_ServiceFacade = false;
				foreach (Engine item in Propulsion)
				{
					if (item.Type == Engine.EngineType.Nuclear)
					{
						_ServiceFacade = true;
						break;
					}
				}
			}
			return _ServiceFacade.Value;
		}
	}

	public bool IsSinking => GetDamagePts() <= 0f;

	public override GlobalVariables.TargetVisualSizeClass VisualSizeClass
	{
		get
		{
			float length = Length;
			if (length <= 280f)
			{
				if (length <= 220f)
				{
					if (length <= 120f)
					{
						if (length <= 45f)
						{
							if (length <= 10f)
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

	public override bool IsPlatform => true;

	public bool IsIcebreaker => Type == _ShipType.AGB;

	public override string AnnexAndDBID => "舰船_" + Conversions.ToString(DBID);

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

	public override bool CanPhysicallyReplenishOtherUnits
	{
		get
		{
			if (UNREP_Capabilities.instanceComparator <= 0)
			{
				if (UNREP_Capabilities.m_ParameterComparator <= 0)
				{
					if (UNREP_Capabilities.m_RuleComparator <= 0)
					{
						return false;
					}
					return true;
				}
				return true;
			}
			return true;
		}
	}

	public override bool IsOutOfFuel
	{
		get
		{
			try
			{
				if (IsNuke)
				{
					return false;
				}
				if (Propulsion.Count == 0)
				{
					return false;
				}
				FuelRec fuelRec = (from theFuelrec in Fuel_ReadOnly
					select (theFuelrec) into fuelRec_0
					where Propulsion[0].CanUseThisFuelType(fuelRec_0.FuelType)
					select fuelRec_0).ElementAtOrDefault(0);
				if (Information.IsNothing(fuelRec))
				{
					return true;
				}
				if (fuelRec.CurrentQuantity == 0f)
				{
					return true;
				}
				return Fuel_ReadOnly[0].CurrentQuantity == 0f;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100769", "");
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

	public float Displacement_Empty
	{
		get
		{
			return systemFacade;
		}
		set
		{
			systemFacade = value;
		}
	}

	public float Displacement_Standard
	{
		get
		{
			return _CandidateFacade;
		}
		set
		{
			_CandidateFacade = value;
		}
	}

	public float Displacement_Full
	{
		get
		{
			return baseFacade;
		}
		set
		{
			baseFacade = value;
		}
	}

	public bool IsDedicatedTankerOrUNREP
	{
		get
		{
			switch (Type)
			{
			default:
				return false;
			case _ShipType.LKA:
			case _ShipType.AD:
			case _ShipType.AE:
			case _ShipType.AF:
			case _ShipType.AFS:
			case _ShipType.AG:
			case _ShipType.AK:
			case _ShipType.AKA:
			case _ShipType.AKE:
			case _ShipType.AKR:
			case _ShipType.AKS:
			case _ShipType.AO:
			case _ShipType.AOE:
			case _ShipType.AOL:
			case _ShipType.AOR:
			case _ShipType.AOT:
			case _ShipType.APA:
			case _ShipType.AS_:
			case _ShipType.AV:
			case _ShipType.TAK:
			case _ShipType.TAKE:
			case _ShipType.TAKR:
			case _ShipType.TAO1:
			case _ShipType.TAO2:
			case _ShipType.TMLP:
				return true;
			}
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

	private Ship()
		: base(ref _PolicyFacade)
	{
		Flags = default(_Flags);
		Rudder = new Rudder(this);
		CIC = new CIC(this, "桥梁 / CIC指挥中心");
		ActiveUnit activeUnit_ = this;
		m_FieldFacade = new Ship_Navigator(ref activeUnit_);
		activeUnit_ = this;
		queueFacade = new Ship_AI(ref activeUnit_);
		IsShip = true;
		IsBoat = true;
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			if (GetUnitSide() == null)
			{
				return;
			}
			xmlWriter_0.WriteStartElement("Ship");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			if (hashSet_0.Contains(ObjectID))
			{
				xmlWriter_0.WriteEndElement();
				return;
			}
			hashSet_0.Add(ObjectID);
			method_0(ref xmlWriter_0);
			xmlWriter_0.WriteElementString("Name", Name.Replace("\0", "").Replace("\u0010", ""));
			if (ChanceOfAppearance != 0)
			{
				xmlWriter_0.WriteElementString("COA", Conversions.ToString(ChanceOfAppearance));
			}
			if (TimeUnderway != 0f)
			{
				xmlWriter_0.WriteElementString("TUW", Conversions.ToString(TimeUnderway));
			}
			xmlWriter_0.WriteElementString("CH", XmlConvert.ToString(CurrentHeading));
			xmlWriter_0.WriteElementString("CS", XmlConvert.ToString(CurrentSpeed));
			xmlWriter_0.WriteElementString("CA", XmlConvert.ToString(GetCurrentAltitude()));
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
			if (_Proficiency.HasValue)
			{
				xmlWriter_0.WriteElementString("Prof", ((int)_Proficiency.Value).ToString());
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
			xmlWriter_0.WriteElementString("TS", ((byte)ThrottleSetting).ToString());
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
			xmlWriter_0.WriteStartElement("Fuel");
			foreach (FuelRec item2 in _Fuel)
			{
				xmlWriter_0.WriteRaw(item2.ToXML());
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
			xmlWriter_0.WriteStartElement("Magazines");
			Magazine[] magazines = Magazines;
			Magazine[] array3 = magazines;
			foreach (Magazine magazine in array3)
			{
				xmlWriter_0.WriteRaw(magazine.ToXML(hashSet_0, ParentScen));
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
			xmlWriter_0.WriteElementString("SBR_TF", XmlConvert.ToString(_CreatorVal));
			XmlWriter obj10 = xmlWriter_0;
			status = (byte)_TemplateVal;
			obj10.WriteElementString("SBR_ThrottleSetting", status.ToString());
			xmlWriter_0.WriteElementString("SBED_TF", XmlConvert.ToString(tagVal));
			XmlWriter obj11 = xmlWriter_0;
			status = (byte)fieldVal;
			obj11.WriteElementString("SBED_ThrottleSetting", status.ToString());
			if (queueVal.HasValue)
			{
				xmlWriter_0.WriteElementString("SBED_DesiredSpeedOverride", XmlConvert.ToString(queueVal.Value));
			}
			xmlWriter_0.WriteElementString("SBEO_TF", XmlConvert.ToString(m_PageVal));
			if (m_RulesVal != 0)
			{
				XmlWriter obj2 = xmlWriter_0;
				status = (byte)m_RulesVal;
				obj2.WriteElementString("SBEO_ThrottleSetting", status.ToString());
			}
			xmlWriter_0.WriteElementString("SBPF_TF", XmlConvert.ToString(m_SystemVal));
			XmlWriter obj3 = xmlWriter_0;
			status = (byte)candidateVal;
			obj3.WriteElementString("SBPF_ThrottleSetting", status.ToString());
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
			if (_DockFacilities.Count() > 0)
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
			if (_DestroyEventsChecked)
			{
				xmlWriter_0.WriteElementString("DEC", _DestroyEventsChecked.ToString());
			}
			Doctrine.ToXML(ref xmlWriter_0, ref ParentScen);
			xmlWriter_0.WriteStartElement("Rudder");
			Rudder.ToXML(ref xmlWriter_0, ref hashSet_0, ParentScen);
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("CIC");
			CIC.ToXML(ref xmlWriter_0, ref hashSet_0, ParentScen);
			xmlWriter_0.WriteEndElement();
			Navigator.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteStartElement("Ship_AI");
			if (AI.m_EventVal == null)
			{
				AI.m_EventVal = this;
			}
			AI.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Ship_Kinematics");
			Kinematics.ToXML(ref xmlWriter_0);
			xmlWriter_0.WriteEndElement();
			Sensory.ToXML(ref xmlWriter_0);
			Weaponry.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteStartElement("Ship_CommStuff");
			CommStuff.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteEndElement();
			Damage.ToXML(ref xmlWriter_0, ref hashSet_0);
			AirOps.ToXML(ref xmlWriter_0, ref hashSet_0);
			ActiveUnit_DockingOps.ToXML(DockingOps, ref xmlWriter_0, ref hashSet_0);
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
			exception_?.Data.Add("Error at 100761", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public new static Ship FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		Ship ship = null;
		try
		{
			ship = CheckOrder(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0, scenario_0.LoadStockUnits);
			return ship;
		}
		catch (PlatformComponentNotFoundException projectError)
		{
			ProjectData.SetProjectError(projectError);
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			ConcurrentDictionary<string, ScenarioObject> obj = concurrentDictionary_0;
			ScenarioObject value = ship;
			obj.TryRemove(innerText, out value);
			ship = CheckOrder(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0, bool_0: true);
			string text = "";
			if (ship.IsGroupMember())
			{
				text = "(member of group: [" + ship.GetParentGroup().Name + "])";
			}
			scenario_0.LoadingNotices.Add("The following ship:[" + ship.Name + "]" + text + " failed to shallow-rebuild because of a component missing. The ship was instead deep-rebuilt, and instantiated in its pristine DB-stock condition. All customizations present in the ship's components (damaged components, weapon additions/removals etc. etc.) have been lost. Please re-apply any necessary customizations either manually or using an SBR script.");
			ProjectData.ClearProjectError();
			return ship;
		}
	}

	private static Ship CheckOrder(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0, bool bool_0)
	{
		try
		{
			Ship ship_ = new Ship();
			ship_.ParentScen = scenario_0;
			string text = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (Misc.CreateRequest(text, ' '))
			{
				text = text.Replace(" ", "-");
			}
			if (concurrentDictionary_0.ContainsKey(text))
			{
				return (Ship)concurrentDictionary_0[text];
			}
			ship_.ObjectID_Set(text);
			if (xmlNode_0.ChildNodes.Count == 1)
			{
				scenario_0.UnitsForLateInstantiation.Add(xmlNode_0);
				return ship_;
			}
			concurrentDictionary_0.TryAdd(ship_.ObjectID, ship_);
			int num = Conversions.ToInteger(Misc.StartRequest(xmlNode_0.ChildNodes, "DBID").InnerText);
			try
			{
				DBFunctions.GetShip(ref scenario_0, ref ship_, num, bool_0);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ConcurrentDictionary<string, ScenarioObject> obj = concurrentDictionary_0;
				string objectID = ship_.ObjectID;
				ScenarioObject value = ship_;
				obj.TryRemove(objectID, out value);
				scenario_0.LoadingNotices.Add("舰船数据库ID" + Conversions.ToString(num) + "在数据库中缺少因此未能加载。");
				ProjectData.ClearProjectError();
				return null;
			}
			if (bool_0)
			{
				ship_.RegisterIssuer(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0);
			}
			if (!bool_0)
			{
				IEnumerator enumerator = null;
				try
				{
					enumerator = xmlNode_0.ChildNodes.GetEnumerator();
					IEnumerator enumerator6 = null;
					IEnumerator enumerator7 = null;
					IEnumerator enumerator8 = null;
					IEnumerator enumerator9 = null;
					IEnumerator enumerator10 = null;
					IEnumerator enumerator11 = null;
					IEnumerator enumerator12 = null;
					IEnumerator enumerator13 = null;
					IEnumerator enumerator2 = null;
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode_ = (XmlNode)enumerator.Current;
						ship_.CommonFromXML(xmlNode_);
						switch (xmlNode_.Name)
						{
						case "CIC":
							ship_.CIC = CIC.FromXML(ref xmlNode_, ref concurrentDictionary_0);
							break;
						case "OnboardCargo":
							try
							{
								enumerator12 = xmlNode_.ChildNodes.GetEnumerator();
								while (enumerator12.MoveNext())
								{
									XmlNode xmlNode_10 = (XmlNode)enumerator12.Current;
									Cargo cargo = Cargo.FromXML(ref xmlNode_10, ref concurrentDictionary_0, scenario_0, ship_);
									ArrayExtensions.Add(ref ship_.OnboardCargo, cargo);
									cargo.ParentPlatform = ship_;
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
						case "Fuel":
							try
							{
								enumerator9 = xmlNode_.ChildNodes.GetEnumerator();
								while (enumerator9.MoveNext())
								{
									XmlNode xmlNode_9 = (XmlNode)enumerator9.Current;
									FuelRec item = FuelRec.FromXML(ref xmlNode_9, ref concurrentDictionary_0);
									ship_._Fuel.Add(item);
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
						case "DockFacilities":
							try
							{
								enumerator8 = xmlNode_.ChildNodes.GetEnumerator();
								while (enumerator8.MoveNext())
								{
									XmlNode xmlNode_8 = (XmlNode)enumerator8.Current;
									DockFacility dockFacility = DockFacility.FromXML(ref xmlNode_8, ref concurrentDictionary_0, ref scenario_0);
									ship_.AddDockFacility(dockFacility);
									dockFacility.ParentPlatform = ship_;
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
						case "Comms":
							try
							{
								enumerator7 = xmlNode_.ChildNodes.GetEnumerator();
								while (enumerator7.MoveNext())
								{
									XmlNode xmlNode_7 = (XmlNode)enumerator7.Current;
									CommDevice commDevice = CommDevice.FromXML(ref xmlNode_7, ref concurrentDictionary_0, ship_);
									ship_.AddCommDevice(commDevice);
									commDevice.ParentPlatform = ship_;
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
						case "Rudder":
							ship_.Rudder = Rudder.FromXML(ref xmlNode_, ref concurrentDictionary_0);
							break;
						case "Sensors":
							try
							{
								enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									Sensor sensor = Sensor.FromXML((XmlNode)enumerator2.Current, concurrentDictionary_0, ship_);
									ArrayExtensions.Add(ref ship_._Sensors, sensor);
									sensor.ParentPlatform = ship_;
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
						case "Propulsion":
							try
							{
								enumerator13 = xmlNode_.ChildNodes.GetEnumerator();
								while (enumerator13.MoveNext())
								{
									XmlNode xmlNode_6 = (XmlNode)enumerator13.Current;
									ActiveUnit activeUnit_ = ship_;
									Engine engine = Engine.FromXML(ref xmlNode_6, ref concurrentDictionary_0, ref activeUnit_);
									ship_.Propulsion.Add(engine);
									engine.ParentPlatform = ship_;
								}
							}
							finally
							{
								if (enumerator13 is IDisposable)
								{
									(enumerator13 as IDisposable).Dispose();
								}
							}
							break;
						case "AirFacilities":
							try
							{
								enumerator6 = xmlNode_.ChildNodes.GetEnumerator();
								while (enumerator6.MoveNext())
								{
									XmlNode xmlNode_5 = (XmlNode)enumerator6.Current;
									AirFacility airFacility = AirFacility.FromXML(ref xmlNode_5, ref concurrentDictionary_0, ref scenario_0);
									ship_.AddAirFacility(airFacility);
									airFacility.ParentPlatform = ship_;
									if (airFacility.DBID == -1)
									{
										ship_.parserVal = true;
									}
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
						case "Magazines":
							try
							{
								enumerator10 = xmlNode_.ChildNodes.GetEnumerator();
								while (enumerator10.MoveNext())
								{
									XmlNode xmlNode_4 = (XmlNode)enumerator10.Current;
									Magazine magazine = Magazine.FromXML(ref xmlNode_4, ref concurrentDictionary_0, ref scenario_0);
									ship_.AddSharedMagazine(magazine, bool_0: false);
									magazine.ParentPlatform = ship_;
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
						case "Mounts":
							try
							{
								enumerator11 = xmlNode_.ChildNodes.GetEnumerator();
								while (enumerator11.MoveNext())
								{
									XmlNode xmlNode_3 = (XmlNode)enumerator11.Current;
									Mount mount = Mount.FromXML(ref xmlNode_3, ref concurrentDictionary_0, ship_);
									if (mount != null)
									{
										ship_.Mounts.Add(mount);
										mount.ParentPlatform = ship_;
									}
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
			IEnumerator enumerator3 = null;
			try
			{
				enumerator3 = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator4 = null;
				IEnumerator enumerator5 = null;
				while (enumerator3.MoveNext())
				{
					XmlNode xmlNode_2 = (XmlNode)enumerator3.Current;
					switch (xmlNode_2.Name)
					{
					case "Status":
						if (Versioned.IsNumeric(xmlNode_2.InnerText))
						{
							ship_.Status = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_2.InnerText);
						}
						else
						{
							ship_.Status = (_ActiveUnitStatus)Enum.Parse(typeof(_ActiveUnitStatus), xmlNode_2.InnerText, ignoreCase: true);
						}
						if (ship_.Status == (_ActiveUnitStatus)9)
						{
							ship_.Status = _ActiveUnitStatus.RTB;
						}
						break;
					case "Name":
						ship_.Name = xmlNode_2.InnerText;
						break;
					case "FSBR":
						ship_.comparatorVal = (_ActiveUnitFuelState)Conversions.ToByte(xmlNode_2.InnerText);
						break;
					case "AMP_OC_Speed":
						ship_.m_PrototypeVal = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "SBPF_TF":
						ship_.m_SystemVal = Conversions.ToBoolean(xmlNode_2.InnerText);
						break;
					case "DTN":
					case "DesiredTurnRate_Navigation":
						ship_.DesiredTurnRate_Navigation = (Waypoint.TurnRateCategory)Conversions.ToByte(xmlNode_2.InnerText);
						break;
					case "LatLR":
						ship_.Latitude_LastReported = XmlConvert.ToDouble(xmlNode_2.InnerText.Replace(",", "."));
						break;
					case "FuelState":
						ship_._FuelState = (_ActiveUnitFuelState)Conversions.ToByte(xmlNode_2.InnerText);
						break;
					case "Ship_Navigator":
					{
						Ship ship8 = ship_;
						ActiveUnit activeUnit_9 = ship_;
						ship8.m_FieldFacade = Ship_Navigator.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref activeUnit_9);
						break;
					}
					case "TUW":
						ship_.TimeUnderway = XmlConvert.ToSingle(xmlNode_2.InnerText.Replace(",", "."));
						break;
					case "COA":
						ship_.ChanceOfAppearance = Conversions.ToInteger(xmlNode_2.InnerText);
						break;
					case "DamagePts":
						if (!bool_0)
						{
							ship_.SetDamagePts(bool_0: true, null, XmlConvert.ToSingle(xmlNode_2.InnerText));
						}
						break;
					case "AMP_OC_DAO":
						ship_._ExporterVal = Conversions.ToBoolean(xmlNode_2.InnerText);
						break;
					case "OldDamagePercent":
						ship_.utilsVal = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "Ship_Weaponry":
					{
						Ship ship7 = ship_;
						ActiveUnit activeUnit_8 = ship_;
						ship7._PageFacade = Ship_Weaponry.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref activeUnit_8);
						break;
					}
					case "Ship_CommStuff":
					{
						Ship ship6 = ship_;
						ActiveUnit activeUnit_7 = ship_;
						ship6._RulesFacade = Ship_CommStuff.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref activeUnit_7);
						break;
					}
					case "SBPF_ThrottleSetting":
						switch (xmlNode_2.InnerText)
						{
						default:
							ship_.candidateVal = (Throttle)Conversions.ToByte(xmlNode_2.InnerText);
							break;
						case "Loiter":
							ship_.candidateVal = Throttle.Loiter;
							break;
						case "FullStop":
							ship_.candidateVal = Throttle.FullStop;
							break;
						case "Full":
							ship_.candidateVal = Throttle.Full;
							break;
						case "Flank":
							ship_.candidateVal = Throttle.Flank;
							break;
						case "Cruise":
							ship_.candidateVal = Throttle.Cruise;
							break;
						}
						break;
					case "ActiveUnit_AirOps":
					{
						Ship ship5 = ship_;
						ActiveUnit activeUnit_6 = ship_;
						ship5._AirOps = ActiveUnit_AirOps.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref activeUnit_6);
						break;
					}
					case "SBR":
						ship_.predicateVal = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_2.InnerText);
						break;
					case "DesiredHeading":
					case "DH":
						ship_.SetDesiredHeading(TurnRate.Max, XmlConvert.ToSingle(xmlNode_2.InnerText));
						break;
					case "SBED_DesiredSpeedOverride":
						ship_.queueVal = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "DEC":
						ship_._DestroyEventsChecked = Conversions.ToBoolean(xmlNode_2.InnerText);
						break;
					case "ActiveEnterAreaTriggers":
						try
						{
							enumerator4 = xmlNode_2.ChildNodes.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								string innerText2 = ((XmlNode)enumerator4.Current).InnerText;
								ship_.ActiveEnterAreaTriggers.Add(innerText2);
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
					case "SBED_ThrottleSetting":
						switch (xmlNode_2.InnerText)
						{
						default:
							ship_.fieldVal = (Throttle)Conversions.ToByte(xmlNode_2.InnerText);
							break;
						case "Loiter":
							ship_.fieldVal = Throttle.Loiter;
							break;
						case "FullStop":
							ship_.fieldVal = Throttle.FullStop;
							break;
						case "Full":
							ship_.fieldVal = Throttle.Full;
							break;
						case "Flank":
							ship_.fieldVal = Throttle.Flank;
							break;
						case "Cruise":
							ship_.fieldVal = Throttle.Cruise;
							break;
						}
						break;
					case "TS":
					case "ThrottleSetting":
						switch (xmlNode_2.InnerText)
						{
						default:
							ship_.ThrottleSetting = (Throttle)Conversions.ToByte(xmlNode_2.InnerText);
							break;
						case "Loiter":
							ship_.ThrottleSetting = Throttle.Loiter;
							break;
						case "FullStop":
							ship_.ThrottleSetting = Throttle.FullStop;
							break;
						case "Full":
							ship_.ThrottleSetting = Throttle.Full;
							break;
						case "Flank":
							ship_.ThrottleSetting = Throttle.Flank;
							break;
						case "Cruise":
							ship_.ThrottleSetting = Throttle.Cruise;
							break;
						}
						break;
					case "Prof":
						ship_.Proficiency = (GlobalVariables.ProficiencyLevel)Conversions.ToInteger(xmlNode_2.InnerText);
						break;
					case "Doctrine":
						ship_.Doctrine = Doctrine.FromXML(ref xmlNode_2, ship_);
						break;
					case "SBEO_TF":
						ship_.m_PageVal = Conversions.ToBoolean(xmlNode_2.InnerText);
						break;
					case "WeaponState":
						ship_._WeaponState = (_ActiveUnitWeaponState)Conversions.ToByte(xmlNode_2.InnerText);
						break;
					case "SBED_TF":
						ship_.tagVal = Conversions.ToBoolean(xmlNode_2.InnerText);
						break;
					case "AMP_OC_DSO":
						ship_._VisitorVal = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "OODA_D":
						ship_.HasCustomOODA = true;
						ship_.m_TokenVal = Conversions.ToShort(xmlNode_2.InnerText);
						break;
					case "OODA_E":
						ship_.HasCustomOODA = true;
						ship_._ResolverVal = Conversions.ToShort(xmlNode_2.InnerText);
						break;
					case "CurrentAltitude":
					case "CA":
						ship_.SetCurrentAltitude(bool_0: false, XmlConvert.ToSingle(xmlNode_2.InnerText.Replace(",", ".")));
						break;
					case "Latitude_UnitEntersAreaCheck":
						ship_.Latitude__UnitEntersAreaCheck = XmlConvert.ToDouble(xmlNode_2.InnerText);
						break;
					case "OODA_T":
						ship_.HasCustomOODA = true;
						ship_._IndexerVal = Conversions.ToShort(xmlNode_2.InnerText);
						break;
					case "AssignedMission":
						if (xmlNode_2.HasChildNodes)
						{
							XmlNode xmlNode3 = xmlNode_2.ChildNodes[0];
							ship_._AssignedMissionOrPackage_ID = xmlNode3.InnerText;
						}
						break;
					case "ActiveRemainAreaTriggers":
					{
						string key = null;
						DateTime result = DateTime.MinValue;
						try
						{
							enumerator5 = xmlNode_2.ChildNodes.GetEnumerator();
							while (enumerator5.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator5.Current;
								if (Operators.CompareString(xmlNode2.Name, "RemainAreaTrigger", TextCompare: false) == 0)
								{
									key = xmlNode2.InnerText;
									result = DateTime.MinValue;
									continue;
								}
								if (DateTime.TryParse(xmlNode2.InnerText, CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
								{
									ship_.ActiveRemainAreaTriggers.Add(key, result);
									continue;
								}
								string innerText = xmlNode2.InnerText;
								long result2 = 0L;
								if (long.TryParse(innerText, out result2))
								{
									result = DateTime.FromBinary(Conversions.ToLong(xmlNode2.InnerText));
									ship_.ActiveRemainAreaTriggers.Add(key, result);
								}
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
					}
					case "Ship_Sensory":
					case "Sensory":
					{
						Ship ship4 = ship_;
						ActiveUnit activeUnit_5 = ship_;
						ship4._ParamFacade = Ship_Sensory.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref activeUnit_5);
						break;
					}
					case "EFSAR":
						ship_.EligibleForSAR = Conversions.ToBoolean(xmlNode_2.InnerText);
						break;
					case "Side":
						ship_._SideName = xmlNode_2.InnerText;
						break;
					case "Longitude":
					case "Lon":
						ship_.SetLongitude(null, XmlConvert.ToDouble(xmlNode_2.InnerText.Replace(",", ".")));
						break;
					case "DS":
					case "DesiredSpeed":
						ship_.DesiredSpeed = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "IBPU":
						ship_.IsBeingPickedUp = Conversions.ToBoolean(xmlNode_2.InnerText);
						break;
					case "CustomIcon":
						ship_.CustomIcon = xmlNode_2.InnerText;
						break;
					case "Message":
						ship_.Message = xmlNode_2.InnerText;
						break;
					case "AssignedTaskPool":
						if (xmlNode_2.HasChildNodes)
						{
							XmlNode xmlNode = xmlNode_2.ChildNodes[0];
							ship_._AssignedTaskPool_ID = xmlNode.InnerText;
						}
						break;
					case "ActiveUnit_DockingOps":
					{
						Ship ship3 = ship_;
						ActiveUnit activeUnit_4 = ship_;
						ship3._DockingOps = ActiveUnit_DockingOps.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref activeUnit_4);
						break;
					}
					case "Latitude":
					case "Lat":
						ship_.SetLatitude(null, XmlConvert.ToDouble(xmlNode_2.InnerText.Replace(",", ".")));
						break;
					case "SBR_ThrottleSetting":
						switch (xmlNode_2.InnerText)
						{
						default:
							ship_._TemplateVal = (Throttle)Conversions.ToByte(xmlNode_2.InnerText);
							break;
						case "Loiter":
							ship_._TemplateVal = Throttle.Loiter;
							break;
						case "FullStop":
							ship_._TemplateVal = Throttle.FullStop;
							break;
						case "Full":
							ship_._TemplateVal = Throttle.Full;
							break;
						case "Flank":
							ship_._TemplateVal = Throttle.Flank;
							break;
						case "Cruise":
							ship_._TemplateVal = Throttle.Cruise;
							break;
						}
						break;
					case "Ship_Kinematics":
						ActiveUnit_Kinematics.FromXML(xmlNode_2, concurrentDictionary_0, ship_);
						break;
					case "Ship_AI":
					{
						Ship ship2 = ship_;
						ActiveUnit activeUnit_3 = ship_;
						ship2.queueFacade = Ship_AI.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref activeUnit_3);
						break;
					}
					case "SBEO":
						ship_._RecordVal = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_2.InnerText);
						break;
					case "LonLR":
						ship_.Longitude_LastReported = XmlConvert.ToDouble(xmlNode_2.InnerText.Replace(",", "."));
						break;
					case "AMP_OC":
						ship_.m_AttrVal = Conversions.ToBoolean(xmlNode_2.InnerText);
						break;
					case "CS":
					case "CurrentSpeed":
						ship_.CurrentSpeed = XmlConvert.ToSingle(xmlNode_2.InnerText.Replace(",", "."));
						break;
					case "SBR_TF":
						ship_._CreatorVal = Conversions.ToBoolean(xmlNode_2.InnerText);
						break;
					case "SBEO_ThrottleSetting":
						switch (xmlNode_2.InnerText)
						{
						default:
							ship_.m_RulesVal = (Throttle)Conversions.ToByte(xmlNode_2.InnerText);
							break;
						case "Loiter":
							ship_.m_RulesVal = Throttle.Loiter;
							break;
						case "FullStop":
							ship_.m_RulesVal = Throttle.FullStop;
							break;
						case "Full":
							ship_.m_RulesVal = Throttle.Full;
							break;
						case "Flank":
							ship_.m_RulesVal = Throttle.Flank;
							break;
						case "Cruise":
							ship_.m_RulesVal = Throttle.Cruise;
							break;
						}
						break;
					case "SBED":
						ship_._SingletonVal = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_2.InnerText);
						break;
					case "DT":
					case "DesiredTurnRate":
						ship_.DesiredTurnRate = (TurnRate)Conversions.ToByte(xmlNode_2.InnerText);
						break;
					case "ParentGroup":
						ship_._ParentGroup_ID = xmlNode_2.InnerText;
						break;
					case "Ship_Damage":
					{
						Ship ship = ship_;
						ActiveUnit activeUnit_2 = ship_;
						ship.methodFacade = Ship_Damage.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref activeUnit_2);
						break;
					}
					case "CH":
					case "CurrentHeading":
						ship_.CurrentHeading = XmlConvert.ToSingle(xmlNode_2.InnerText.Replace(",", "."));
						break;
					case "IsAD":
					case "IsAutoDetectable":
						ship_.SetIsAutoDetectable(null, Conversions.ToBoolean(xmlNode_2.InnerText));
						break;
					case "Longitude_UnitEntersAreaCheck":
						ship_.Longitude__UnitEntersAreaCheck = XmlConvert.ToDouble(xmlNode_2.InnerText);
						break;
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
			return ship_;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100762", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Ship result3 = new Ship();
			ProjectData.ClearProjectError();
			return result3;
		}
	}

	public override void Set_AssignedMissionOrPackage(Mission mission_0, bool bool_0, bool bool_1, ref Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_0)
	{
		try
		{
			base.Set_AssignedMissionOrPackage(mission_0, bool_0, bool_1, ref missionAssignmentAttemptResult_0);
			if (missionAssignmentAttemptResult_0 != Mission.MissionAssignmentAttemptResult.Success)
			{
				return;
			}
			foreach (ActiveUnit activeUnits_ in ParentScen.ActiveUnits_List)
			{
				if (activeUnits_ == null || !activeUnits_.IsSubmarine)
				{
					continue;
				}
				if (((Submarine)activeUnits_).IsTetheredROV)
				{
					if (activeUnits_.DockingOps.GetAssignedHostUnit(bool_0: true) == this)
					{
						Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
						activeUnits_.Set_AssignedMissionOrPackage(mission_0, bool_0, bool_1, ref missionAssignmentAttemptResult_);
					}
				}
				else if (((Submarine)activeUnits_).Type == Submarine._SubmarineType.UUV && activeUnits_.DockingOps.GetAssignedHostUnit(bool_0: true) == this)
				{
					Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_2 = Mission.MissionAssignmentAttemptResult.None;
					activeUnits_.Set_AssignedMissionOrPackage(mission_0, bool_0, bool_1, ref missionAssignmentAttemptResult_2);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100763", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	public override int GetSafeDistanceAgainstUnknownMine_meters(bool bool_0)
	{
		if (IsMCMPlatform)
		{
			if (bool_0)
			{
				return Math.Max((int)Math.Round((double)base.GetSafeDistanceAgainstUnknownMine_meters(bool_0) * 0.3), 1000);
			}
			return (int)Math.Round((double)base.GetSafeDistanceAgainstUnknownMine_meters(bool_0) * 0.1);
		}
		if (bool_0)
		{
			return base.GetSafeDistanceAgainstUnknownMine_meters(bool_0) * 3;
		}
		return base.GetSafeDistanceAgainstUnknownMine_meters(bool_0);
	}

	[SpecialName]
	public override int GetMastHeight_Radar(Sensor sensor_0 = null)
	{
		if (sensor_0 != null && sensor_0.MastHeight != 0)
		{
			return sensor_0.MastHeight;
		}
		GlobalVariables.TargetVisualSizeClass visualSizeClass = VisualSizeClass;
		if (1 == 0)
		{
		}
		int result = visualSizeClass switch
		{
			GlobalVariables.TargetVisualSizeClass.Stealthy => 3, 
			GlobalVariables.TargetVisualSizeClass.VSmall => 7, 
			GlobalVariables.TargetVisualSizeClass.Small => 14, 
			GlobalVariables.TargetVisualSizeClass.Medium => 25, 
			GlobalVariables.TargetVisualSizeClass.Large => 40, 
			GlobalVariables.TargetVisualSizeClass.VLarge => 50, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	[SpecialName]
	public override int GetMastHeight_Visual(Sensor sensor_0 = null)
	{
		if (sensor_0 != null && sensor_0.MastHeight != 0)
		{
			return sensor_0.MastHeight;
		}
		GlobalVariables.TargetVisualSizeClass visualSizeClass = VisualSizeClass;
		if (1 == 0)
		{
		}
		int result = visualSizeClass switch
		{
			GlobalVariables.TargetVisualSizeClass.Stealthy => 2, 
			GlobalVariables.TargetVisualSizeClass.VSmall => 6, 
			GlobalVariables.TargetVisualSizeClass.Small => 10, 
			GlobalVariables.TargetVisualSizeClass.Medium => 15, 
			GlobalVariables.TargetVisualSizeClass.Large => 20, 
			GlobalVariables.TargetVisualSizeClass.VLarge => 25, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public override void PostDeserializationHousekeeping_General(ref Scenario scenario_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, List<ActiveUnit> list_0, bool bool_0)
	{
		base.PostDeserializationHousekeeping_General(ref scenario_0, concurrentDictionary_0, list_0, bool_0);
		ActiveUnit_DockingOps.PostDeserializationHousekeeping(DockingOps, ref scenario_0, concurrentDictionary_0, bool_0);
	}

	public override void DoTypeSpecificActions(float float_0, ref LockRandom lockRandom_0)
	{
		DockingOps.DoDockingOps(float_0);
		if (IsOperating())
		{
			TimeUnderway += float_0;
		}
		else
		{
			TimeUnderway = 0f;
		}
	}

	public override void SetThrottle(Throttle throttle_0, float? nullable_0 = null)
	{
		try
		{
			if (ThrottleSetting == throttle_0 && Information.IsNothing(nullable_0) && !ParentScen.MinuteIsChangingOnThisPulse)
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
				if (Information.IsNothing(nullable_0))
				{
					DesiredSpeed = Kinematics.GetMaximumSpeed(GetCurrentAltitude(), ThrottleSetting, bool_0: false);
				}
				else if (IsGroupLead() && AI.MustSlowDownToAllowGroupFormUp())
				{
					if (Kinematics.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
					{
						DesiredSpeed = Kinematics.GetMaximumSpeed(GetCurrentAltitude(), (Throttle)Kinematics.ThrottlePreset, bool_0: false);
					}
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
							goto IL_033c;
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
				else
				{
					DesiredSpeed = Kinematics.GetMaximumSpeed(GetCurrentAltitude(), (Throttle)Kinematics.ThrottlePreset, bool_0: false);
				}
			}
			goto IL_033c;
			IL_033c:
			RaiseEvent_ChangedThrottleSetting(this, ThrottleSetting);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100034957377", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override bool CanMoveToThisLocation(double double_0, double double_1, ref int int_0, bool bool_0, bool bool_1, bool bool_2, ref bool bool_3, bool bool_4, ref bool bool_5, float? nullable_0, short? nullable_1, ref List<ActiveUnit> list_0, float float_0, bool bool_6, bool bool_7, ref string string_0, ref bool bool_8)
	{
		try
		{
			int_0 = 1;
			if (!double.IsNaN(double_0) && !double.IsNaN(double_1))
			{
				if (bool_6 && Status == _ActiveUnitStatus.EngagedOffensive && AssignedMissionOrPackage() != null && AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
				{
					Patrol patrol = (Patrol)AssignedMissionOrPackage();
					Geopoint_Struct geopoint_Struct = new Geopoint_Struct(double_1, double_0);
					if (GetIsInsideThisArea(patrol.ProsecutionArea, ParentScen, bool_0: true) && !GeoPoint.IsInsideThisArea(geopoint_Struct.Latitude, geopoint_Struct.Longitude, patrol.ProsecutionArea))
					{
						bool_3 = false;
						bool_5 = false;
						string_0 = "目标已离开警戒区。";
						return false;
					}
				}
				if (bool_7)
				{
					bool_3 = CustomizeClient();
				}
				if ((bool_3 || bool_0) && CountClient(double_0, double_1, float_0))
				{
					bool_3 = true;
					bool_5 = false;
					string_0 = "这一点在禁航区域内。";
					return false;
				}
				if (ConcatOrder(double_0, double_1, bool_4, nullable_1, ref list_0))
				{
					bool flag = false;
					UnguidedWeapon unguidedWeapon = null;
					if (GetUnitSide() != null)
					{
						if (GetUnitSide().Contacts_NonAU.Count > 0)
						{
							Parallel.ForEach(GetUnitSide().Contacts_NonAU.ToList(), delegate(string theID, ParallelLoopState loopstate)
							{
								if (theID != null)
								{
									UnguidedWeapon value = null;
									ParentScen.UnguidedWeapons.TryGetValue(theID, ref value);
									if (value != null && value.IsMine)
									{
										short num = (short)GetSafeDistanceAgainstKnownMineType_meters(value.Type, bool_1);
										string string_ = "";
										Math.Abs(Module_Unit.PrintTokenizer(value, this, bool_0: true, ref string_));
										if (!bool_0)
										{
											if (bool_2)
											{
												return;
											}
											UnguidedWeapon unit_ = value;
											Ship unit_2 = this;
											string string_2 = "";
											if (Math.Abs(Module_Unit.PrintTokenizer(unit_, unit_2, bool_0: true, ref string_2)) > 45f)
											{
												return;
											}
										}
										if (Math2.VerifyClass(double_0, double_1, value.GetLatitude(), value.GetLongitude()) * 1852f < (float)num && (!IsMineLayingPlatform || !base.IsOnActiveMiningMission || value.TimeToDetonate <= 0f) && (!((value.TimeToDetonate > 3600f) & (value.FiringParent_ID != null)) || !string.Equals(value.FiringParent_ID, ObjectID, StringComparison.OrdinalIgnoreCase)))
										{
											flag = true;
											unguidedWeapon = value;
											loopstate.Stop();
										}
									}
								}
							});
						}
						if (flag)
						{
							bool_3 = false;
							bool_5 = true;
							if (!IsMCMPlatform && (AssignedMissionOrPackage() == null || AssignedMissionOrPackage().MissionClass != Mission._MissionClass.MineClearing))
							{
								string_0 = "该单元不是扫雷单元，而且已发现的水雷距离太近。";
							}
							else
							{
								string_0 = "距离雷区太近了。";
							}
							return false;
						}
					}
					bool_3 = false;
					bool_5 = false;
					return true;
				}
				bool_3 = false;
				bool_5 = false;
				string_0 = "该单元无法在陆地上航行。";
				return false;
			}
			bool_3 = false;
			bool_5 = false;
			string_0 = "Unknown.";
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200285", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			bool_3 = false;
			bool_5 = false;
			string_0 = "Error.";
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private bool ConcatOrder(double double_0, double double_1, bool bool_0, short? nullable_0, ref List<ActiveUnit> list_0)
	{
		try
		{
			if (Type == _ShipType.LCAC)
			{
				LandCover.LandCoverType landCoverType = LandCover.DestroyClass(double_0, double_1, ParentScen);
				return landCoverType != LandCover.LandCoverType.Deciduous_Broadleaf_forest && landCoverType != LandCover.LandCoverType.Deciduous_Needleleaf_forest && landCoverType != LandCover.LandCoverType.Evergreen_Broadleaf_forest && landCoverType != LandCover.LandCoverType.Evergreen_Needleleaf_forest && landCoverType != LandCover.LandCoverType.Mixed_forest;
			}
			if (GeoPoint.GetIsInCanal(double_0, double_1))
			{
				return true;
			}
			if (GeoPoint.IsInPierLane(double_0, double_1, ParentScen))
			{
				return true;
			}
			if (bool_0 && !IsIcebreaker && SeaIceProvider.PrepareWriter(double_1, double_0))
			{
				return false;
			}
			short num = -2;
			short num2;
			if (nullable_0.HasValue)
			{
				num2 = nullable_0.Value;
			}
			else
			{
				if (ParentScen.NatureSideExists())
				{
					foreach (CustomEnvironmentZone customEnvironmentZone in ParentScen.GetNatureSide().CustomEnvironmentZones)
					{
						if (customEnvironmentZone.HasCustomTerrain && GeoPoint.IsInsideThisArea(double_0, double_1, customEnvironmentZone.Area) && customEnvironmentZone.TerrainType == LandCover.LandCoverType.Water)
						{
							return true;
						}
					}
				}
				(bool, short?) tuple = Terrain.ExcludeWatcher(double_0, double_1);
				if (tuple.Item1)
				{
					return false;
				}
				num2 = (tuple.Item2.HasValue ? tuple.Item2.Value : Terrain.GetElevation(double_0, double_1, bool_0: false, ParentScen));
			}
			if (num2 < num)
			{
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100765", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[SpecialName]
	public override long GetFuelEndurance(Throttle throttle_0, AltBand altBand_0, float? nullable_0, float? nullable_1)
	{
		try
		{
			if (Fuel_ReadOnly.Count == 0)
			{
				return 0L;
			}
			FuelRec fuelRec = (from theFuelrec in Fuel_ReadOnly
				select (theFuelrec) into fuelRec_0
				where Propulsion[0].CanUseThisFuelType(fuelRec_0.FuelType)
				select fuelRec_0).ElementAtOrDefault(0);
			if (Information.IsNothing(fuelRec))
			{
				return 0L;
			}
			float currentQuantity = fuelRec.CurrentQuantity;
			if (currentQuantity == 0f)
			{
				return 0L;
			}
			if (throttle_0 == Throttle.FullStop)
			{
				return 2147483647L;
			}
			float num = FuelConsumption(throttle_0, altBand_0, nullable_0, nullable_1, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false);
			if (num == 0f)
			{
				return long.MaxValue;
			}
			return (long)Math.Round(currentQuantity / num);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100766", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return 0L;
	}

	[SpecialName]
	public override _ActiveUnitFuelState GetIsBingoTowardsThisDestination(ActiveUnit activeUnit_0, GeoPoint geoPoint_0, Doctrine._FuelState? nullable_0)
	{
		try
		{
			if (GetFuelEndurance(Throttle.Cruise, null, null, null) <= 900)
			{
				return _ActiveUnitFuelState.IsBingo;
			}
			float num = Module_Unit.RangeToUnit_Horiz(this, activeUnit_0);
			if ((double)Kinematics.CurrentRangeAtBingoThrottleAltitudeDepth(null) < (double)num * 1.1)
			{
				return _ActiveUnitFuelState.IsBingo;
			}
			return _ActiveUnitFuelState.None;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100767", "");
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
			if (IsNuke)
			{
				return _ActiveUnitFuelState.None;
			}
			ActiveUnit actualDestinationHost = DockingOps.ActualDestinationHost;
			if (Information.IsNothing(actualDestinationHost))
			{
				return _ActiveUnitFuelState.None;
			}
			if (actualDestinationHost.IsDestroyed)
			{
				return _ActiveUnitFuelState.None;
			}
			return GetIsBingoTowardsThisDestination(actualDestinationHost, null, null);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100768", "");
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
	public override bool GetCanPhysicallyReplenishThisUnit(ActiveUnit activeUnit_0)
	{
		if (activeUnit_0.IsAircraft)
		{
			return false;
		}
		if (UNREP_Capabilities.instanceComparator <= 0)
		{
			if (UNREP_Capabilities.m_ParameterComparator <= 0)
			{
				if (UNREP_Capabilities.m_RuleComparator <= 0)
				{
					return false;
				}
				return true;
			}
			return true;
		}
		return true;
	}

	public override void DoFuelConsumption(float float_0)
	{
		try
		{
			if (IsNuke || ThrottleSetting == Throttle.FullStop || (!Navigator.HasPlottedCourse() && CurrentSpeed == 0f) || IsOutOfFuel)
			{
				return;
			}
			float float_ = FuelConsumption(ThrottleSetting, null, null, null, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false) * float_0;
			FuelRec fuelRec = null;
			foreach (FuelRec item in Fuel_ReadOnly)
			{
				if (Propulsion[0].CanUseThisFuelType(item.FuelType))
				{
					fuelRec = item;
					break;
				}
			}
			Fuel_Subtract(float_, fuelRec.FuelType);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100770", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void Fuel_Subtract(float float_0, FuelRec._FuelType _FuelType_0)
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
					AddMessage(Name + " (" + Misc.ReadRequest(UnitClass) + "）燃料耗尽，在水里沉没！", Name + "油料耗尽！", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
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
			exception_?.Data.Add("Error at 100771", "");
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
		if (Propulsion.Count == 0)
		{
			return 0f;
		}
		AltBand altBand = null;
		try
		{
			if (Propulsion[0].Status == PlatformComponent._ComponentStatus.Destroyed)
			{
				return 0f;
			}
			if (Propulsion[0].AltBands.Length == 0)
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
			float num;
			float num2;
			float num3;
			switch (throttle_0)
			{
			default:
				return 0f;
			case Throttle.FullStop:
				return 0f;
			case Throttle.Loiter:
				num = altBand.Consumption_Loiter;
				num2 = 0f;
				goto IL_02c1;
			case Throttle.Cruise:
				if (Propulsion[0].AltBands[0].Consumption_Cruise <= 0f)
				{
					return FuelConsumption(Throttle.Loiter, altBand_0, nullable_0, nullable_1, bool_0, bool_1, bool_2: false, bool_3: false, bool_4: false);
				}
				num = altBand.Consumption_Cruise;
				num2 = altBand.Consumption_Loiter;
				goto IL_02c1;
			case Throttle.Full:
				if (altBand.Speed_Full.HasValue)
				{
					float? consumption_Full = Propulsion[0].AltBands[0].Consumption_Full;
					if ((consumption_Full.HasValue ? new bool?(consumption_Full.GetValueOrDefault() > 0f) : null).GetValueOrDefault())
					{
						num = altBand.Consumption_Full.Value;
						_ = altBand.Speed_Full.Value;
						num2 = altBand.Consumption_Cruise;
						goto IL_02c1;
					}
				}
				return FuelConsumption(Throttle.Cruise, altBand_0, nullable_0, nullable_1, bool_0, bool_1, bool_2: false, bool_3: false, bool_4: false);
			case Throttle.Flank:
				{
					if (!altBand.Speed_Flank.HasValue)
					{
						break;
					}
					float? consumption_Flank = Propulsion[0].AltBands[0].Consumption_Flank;
					if (!(consumption_Flank.HasValue ? new bool?(consumption_Flank.GetValueOrDefault() > 0f) : null).GetValueOrDefault())
					{
						break;
					}
					num = altBand.Consumption_Flank.Value;
					_ = altBand.Speed_Flank.Value;
					num2 = (altBand.Speed_Full.HasValue ? altBand.Consumption_Full.Value : altBand.Consumption_Cruise);
					goto IL_02c1;
				}
				IL_02c1:
				num3 = num;
				if (nullable_0.HasValue)
				{
					float num4 = Kinematics.GetMaximumSpeed(nullable_1.Value, throttle_0, bool_0: false);
					float? num5 = nullable_0;
					if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() < num4) : null).GetValueOrDefault())
					{
						float num6 = Kinematics.GetMaximumSpeed(nullable_1.Value, throttle_0 - 1, bool_0: false);
						num5 = nullable_0;
						float value;
						if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() >= num6) : null).GetValueOrDefault())
						{
							value = ((nullable_0 - num6) / (num4 - num6)).Value;
							value = Math.Abs(value);
						}
						else
						{
							value = 0f;
						}
						num3 = num2 + (num - num2) * value;
					}
				}
				return num3 / 60f;
			}
			return FuelConsumption(Throttle.Full, altBand_0, nullable_0, nullable_1, bool_0, bool_1, bool_2: false, bool_3: false, bool_4: false);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101253", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public void CommenceSinking(float float_0, string string_0 = null)
	{
		AddMessage(Name + "正在下沉！", Name + " 正下沉！！！", LoggedMessage.MessageType.UnitLost, 1, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
		Kinematics.ExportLocationEvent(bool_0: true);
		ParentScen.ExportUnitDestructionEvent(this, "Ship has suffered catastrophic structural damage and is sinking.", string_0);
		IsBeingDestroyed = true;
		PreDestructionHousekeeping(bool_0: false, bool_1: true, float_0, bool_2: true);
	}

	public override void Destroy(bool bool_0, bool bool_1, bool bool_2, string string_0, string string_1 = null)
	{
		bool bool_3 = false;
		try
		{
			IsBeingDestroyed = true;
			DockingOps.HostDockFacility = null;
			if (!IsOperating() && !bool_0)
			{
				ParentScen.AddMessage(Name + "已被摧毁！", Name + " 被摧毁！", LoggedMessage.MessageType.UnitLost, 0, ObjectID, GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
			}
			PreDestructionHousekeeping(bool_0, bool_3, Damage.DamagePercent, bool_2);
			if (!IsSinking && !bool_0)
			{
				ParentScen.AddMessage(Name + "已被摧毁！", Name + " 被摧毁！", LoggedMessage.MessageType.UnitLost, 0, ObjectID, GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
			}
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
			if (DockFacilities_ReadOnly.Length != 0)
			{
				foreach (ActiveUnit embarkedBoat in DockingOps.EmbarkedBoats)
				{
					embarkedBoat.Destroy(bool_0, bool_1, bool_2, "Destroyed as the object it is docked to is being destroyed", "Host Destruction");
				}
			}
			if (AirFacilities_ReadOnly.Length != 0)
			{
				foreach (Aircraft item3 in AirOps.EmbarkedAircraft_ReadOnly)
				{
					item3.Destroy(bool_0, bool_1, bool_2, "Destroyed as the object it is landed on is being destroyed", "Host Destruction");
				}
			}
			if (IsGroupMember())
			{
				GetParentGroup().Units.Remove(ObjectID);
			}
			if (bool_0)
			{
				DeleteImmediately();
			}
			else if (bool_2)
			{
				ParentScen.DestroyThisUnit(this, string_0);
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
			exception_?.Data.Add("Error at 100772", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Ship(ref Scenario scenario_0, string string_0 = null)
		: base(ref scenario_0, string_0)
	{
		Flags = default(_Flags);
		Rudder = new Rudder(this);
		CIC = new CIC(this, "桥梁 / CIC指挥中心");
		ActiveUnit activeUnit_ = this;
		m_FieldFacade = new Ship_Navigator(ref activeUnit_);
		activeUnit_ = this;
		queueFacade = new Ship_AI(ref activeUnit_);
		IsShip = true;
		IsBoat = true;
	}

	public override void Teleport(ref Scenario scenario_0, double double_0, double double_1)
	{
		base.Teleport(ref scenario_0, double_0, double_1);
		Kinematics.ExportLocationEvent(bool_0: true);
	}

	internal float InterruptOrder()
	{
		return Cargo_Crew;
	}

	float ICargoHost.GetCargo_Crew()
	{
		return InterruptOrder();
	}

	internal float RemoveOrder()
	{
		if (Cargo_Type == CargoType.Personnel && Cargo_Area == 0f)
		{
			return Cargo_Crew * Mount.PersonnelArea;
		}
		return Cargo_Area;
	}

	float ICargoHost.GetCargo_Area()
	{
		return RemoveOrder();
	}

	internal CargoType FindOrder()
	{
		return Cargo_Type;
	}

	CargoType ICargoHost.GetCargo_Type()
	{
		return FindOrder();
	}

	internal float SetOrder()
	{
		if (Cargo_Type == CargoType.Personnel && Cargo_Mass == 0f)
		{
			return Cargo_Crew * Mount.PersonnelMass;
		}
		return Cargo_Mass;
	}

	float ICargoHost.GetCargo_Mass()
	{
		return SetOrder();
	}

	public float GetCargo_TowingCapacity()
	{
		return 0f;
	}

	public float GetCargo_MassAvailable()
	{
		return CargoHostHelper.GetAvailableMass(this, OnboardCargo);
	}

	internal bool FillOrder()
	{
		return false;
	}

	bool ICargoHost.GetCargo_ParadropCapable()
	{
		return FillOrder();
	}

	internal bool CalculateOrder()
	{
		return false;
	}

	bool ICargoHost.CanStackCargo()
	{
		return CalculateOrder();
	}

	public float GetCargo_Height()
	{
		return 0f;
	}

	internal int PopOrder(List<Cargo> list_0)
	{
		if (list_0 != null && list_0.Count > 0)
		{
			double double_ = ActiveUnit_DockingOps.DEFAULT_CARGO_LOAD_TIME;
			double num = 0.0;
			foreach (Cargo item in list_0)
			{
				num += (double)item.RequiredMass;
			}
			switch (Type)
			{
			default:
				double_ = (CreateOrder() ? ActiveUnit_DockingOps.GetCargoMoveTime(5.0, 60.0, num, SetOrder()) : ActiveUnit_DockingOps.GetCargoMoveTime(60.0, double_, num, SetOrder()));
				break;
			case _ShipType.LST:
			case _ShipType.LSU:
			case _ShipType.LSV:
				double_ = ActiveUnit_DockingOps.GetCargoMoveTime(10.0, 90.0, num, SetOrder());
				break;
			case _ShipType.LCM:
			case _ShipType.LCP:
			case _ShipType.LCT:
			case _ShipType.LCU:
			case _ShipType.LCVP:
				double_ = ActiveUnit_DockingOps.GetCargoMoveTime(10.0, 60.0, num, SetOrder());
				break;
			case _ShipType.LCAC:
				double_ = ActiveUnit_DockingOps.GetCargoMoveTime(5.0, 60.0, num, SetOrder());
				break;
			}
			return (int)Math.Round(double_ * 60.0);
		}
		return 0;
	}

	int ICargoHost.GetLoadTime(List<Cargo> list_0)
	{
		return PopOrder(list_0);
	}

	internal int InstantiateOrder(List<Cargo> list_0)
	{
		if (list_0 != null && list_0.Count > 0)
		{
			double num = ActiveUnit_DockingOps.DEFAULT_CARGO_UNLOAD_TIME;
			double num2 = 0.0;
			foreach (Cargo item in list_0)
			{
				num2 += (double)item.RequiredMass;
			}
			switch (Type)
			{
			default:
				if (CreateOrder())
				{
					num = ActiveUnit_DockingOps.GetCargoMoveTime(5.0, 30.0, num2, SetOrder());
				}
				break;
			case _ShipType.LST:
			case _ShipType.LSU:
			case _ShipType.LSV:
				num = ActiveUnit_DockingOps.GetCargoMoveTime(10.0, 30.0, num2, SetOrder());
				break;
			case _ShipType.LCM:
			case _ShipType.LCP:
			case _ShipType.LCT:
			case _ShipType.LCU:
			case _ShipType.LCVP:
				num = ActiveUnit_DockingOps.GetCargoMoveTime(5.0, 15.0, num2, SetOrder());
				break;
			case _ShipType.LCAC:
				num = ActiveUnit_DockingOps.GetCargoMoveTime(8.5, 11.5, num2, SetOrder());
				break;
			}
			return (int)Math.Round(num * 60.0);
		}
		return 0;
	}

	int ICargoHost.GetUnloadTime(List<Cargo> list_0)
	{
		return InstantiateOrder(list_0);
	}

	public bool CanLoad(ICargoClient icargoClient_0)
	{
		return CargoHostHelper.CanLoad(this, OnboardCargo, icargoClient_0);
	}

	internal bool CreateOrder()
	{
		if (Length < 13f)
		{
			return Draft < 0.7f;
		}
		return false;
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

	internal bool CompareOrder()
	{
		if (Type == _ShipType.LCAC)
		{
			return false;
		}
		if (CurrentSpeed > 0f)
		{
			return DesiredSpeed >= (float)Kinematics.CavitationSpeed(0f);
		}
		return false;
	}

	bool IBoat.IsCavitating()
	{
		return CompareOrder();
	}

	[CompilerGenerated]
	private bool ReadOrder(FuelRec fuelRec_0)
	{
		return Propulsion[0].CanUseThisFuelType(fuelRec_0.FuelType);
	}

	[CompilerGenerated]
	private bool DisableOrder(FuelRec fuelRec_0)
	{
		return Propulsion[0].CanUseThisFuelType(fuelRec_0.FuelType);
	}
}
