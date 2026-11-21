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

public sealed class Submarine : Platform, ICargoHost, IBoat
{
	public enum ConventionalSubmarineEngineType : byte
	{
		Diesel,
		Electric,
		AIP
	}

	public struct _Flags
	{
		public bool AnechoicCoating;

		public bool NoLaunchTransient;

		public bool ShroudedPropulsor;

		public bool AdvancedPropulsor;

		public bool DoubleHull;

		public bool ShockResistant;

		public bool LowConstructionStandards;

		public bool NonmagneticHull;

		public bool bool_0;

		public bool UsesLiOnBattery;

		public bool HasSnorkel;
	}

	public enum _SubmarineCategory
	{
		None = 1001,
		Submarine = 2001,
		Biologics = 2002,
		FalseTarget = 2003
	}

	public enum _SubmarineType
	{
		None = 1001,
		AGSS = 2001,
		APSS = 2002,
		SS = 2003,
		SSB = 2004,
		SSBN = 2005,
		SSG = 2006,
		SSGN = 2007,
		SSK = 2008,
		SSM = 2009,
		SSN = 2010,
		SSP = 2011,
		SSR = 2012,
		SSRN = 2013,
		SDV = 3001,
		ROV = 4001,
		UUV = 4002,
		Biologics = 9001,
		FalseTarget = 9002
	}

	[CompilerGenerated]
	private sealed class AccountItem
	{
		public Submarine _003C_003E4__this;

		public bool bool_24;

		public bool bool_17;

		public bool bool_25;

		public double lat;

		public double lon;

		public bool flag;

		internal void CountInterruptibleParam(string theID, ParallelLoopState loopstate)
		{
			UnguidedWeapon unguidedWeapon = null;
			_003C_003E4__this.ParentScen.UnguidedWeapons.TryGetValue(theID, ref unguidedWeapon);
			if (Information.IsNothing(unguidedWeapon) || !unguidedWeapon.IsMine)
			{
				return;
			}
			short num = (short)_003C_003E4__this.GetSafeDistanceAgainstKnownMineType_meters(unguidedWeapon.Type, bool_24);
			if (!bool_17)
			{
				if (bool_25)
				{
					return;
				}
				UnguidedWeapon unit_ = unguidedWeapon;
				Submarine unit_2 = _003C_003E4__this;
				string string_ = "";
				if (Math.Abs(Module_Unit.PrintTokenizer(unit_, unit_2, bool_0: true, ref string_)) > 45f)
				{
					return;
				}
			}
			if (Math2.VerifyClass(lat, lon, unguidedWeapon.GetLatitude(), unguidedWeapon.GetLongitude()) * 1852f < (float)num)
			{
				flag = true;
				loopstate.Stop();
			}
		}
	}

	[CompilerGenerated]
	private sealed class StateItem
	{
		public FuelRec._FuelType Local_FuelTypeToConsume;

		internal bool CustomizeInterruptibleParam(FuelRec theRec)
		{
			return theRec.FuelType == Local_FuelTypeToConsume;
		}
	}

	[CompilerGenerated]
	private sealed class AuthenticationItem
	{
		public FuelRec._FuelType theType;

		internal bool CloneInterruptibleParam(FuelRec theRec)
		{
			return theRec.FuelType == theType;
		}
	}

	[CompilerGenerated]
	private sealed class IssuerProcessProducer
	{
		public AltBand altBand;

		internal bool ConnectInterruptibleParam(AltBand AltBand)
		{
			return AltBand.MinAlt >= altBand.MaxAlt;
		}
	}

	public int CombatSystemGen;

	public _Flags Flags;

	public PressureHull PressureHull;

	public Rudder Rudder;

	public CIC CIC;

	public Cargo Cargo;

	public _SubmarineCategory Category;

	public _SubmarineType Type;

	public DockFacility.DockingPhysicalSize DockingPhysicalSize;

	public int MaxDepth;

	public int RepairCapacity;

	public float Beam;

	public float Draft;

	public float Height;

	public short ROVControlRadius_m;

	private Dictionary<int, Engine> m_ReponseProxy;

	private Engine _DescriptorProxy;

	private int poolProxy;

	private Submarine_Navigator _TaskProxy;

	private Submarine_AI filterProxy;

	private Submarine_Kinematics m_TestsProxy;

	private Submarine_Sensory _InterpreterProxy;

	private Submarine_Weaponry m_ContainerProxy;

	private Submarine_CommStuff composerProxy;

	private Submarine_Damage modelProxy;

	private bool? advisorProxy;

	public static int CommsEstablishDepth;

	public static int MaxTorpedoWireSpeed;

	private float customerProxy;

	private float _SerializerProxy;

	private float m_RefProxy;

	private static Scenario errorProxy;

	public override bool RepresentsMobileGroundUnit => false;

	public override bool UseSubmerisbleUnitUI => true;

	public override bool SupportsAltitude_Control => true;

	public override bool SupportsAttitude_Pitch => true;

	public bool IsBiological => Type == _SubmarineType.Biologics;

	public bool IsFalseTarget => Type == _SubmarineType.FalseTarget;

	public override ActiveUnit_DockingOps.ResupplyCapacity DesignatedSupplier
	{
		get
		{
			if (!_DesignatedSupplier.HasValue)
			{
				_DesignatedSupplier = ActiveUnit_DockingOps.ResupplyCapacity.None;
			}
			return _DesignatedSupplier.Value;
		}
		set
		{
			_DesignatedSupplier = value;
		}
	}

	public override float FlatSurfaceArea_m2 => Length * Beam;

	public override bool IsPlatform => true;

	public string Type_Description => Type.ToString();

	public override string AnnexAndDBID => "潜艇_" + Conversions.ToString(DBID);

	public override GlobalVariables.ActiveUnitType UnitType => GlobalVariables.ActiveUnitType.Submarine;

	public Dictionary<int, Engine> SelectedEngines
	{
		get
		{
			if (m_ReponseProxy == null)
			{
				m_ReponseProxy = AI.SelectEngines();
			}
			return m_ReponseProxy;
		}
		set
		{
			m_ReponseProxy = value;
		}
	}

	public Engine PrimaryEngine
	{
		get
		{
			if (_DescriptorProxy == null)
			{
				AI.SelectEngines();
			}
			return _DescriptorProxy;
		}
		set
		{
			_DescriptorProxy = value;
		}
	}

	public int PrimaryEngineNo
	{
		get
		{
			if (_DescriptorProxy == null)
			{
				AI.SelectEngines();
			}
			return poolProxy;
		}
		set
		{
			poolProxy = value;
		}
	}

	public override float DesiredSpeed
	{
		get
		{
			return base.DesiredSpeed;
		}
		set
		{
			if (!Kinematics.DesiredSpeedOverride.HasValue && value > (float)MaxTorpedoWireSpeed && Status != _ActiveUnitStatus.EngagedDefensive && Weaponry.IsGuidingWireTorpedoes)
			{
				value = MaxTorpedoWireSpeed;
			}
			if (Navigator.AvoidCavitation && Status != _ActiveUnitStatus.EngagedDefensive)
			{
				float num = Math.Min(Kinematics.CavitationSpeed(GetCurrentAltitude()), Kinematics.CavitationSpeed(DesiredAltitude));
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

	public override float DesiredAltitude
	{
		get
		{
			return base.DesiredAltitude;
		}
		set
		{
			float desiredAltitude = DesiredAltitude;
			if (Math.Round(DesiredAltitude) < -20.0 && (int)Damage.FireIntensity > 1)
			{
				value = -20f;
			}
			if ((int)Damage.FloodIntensity > 1)
			{
				value = 0f;
			}
			if (desiredAltitude != value && Math.Round(value) < -20.0)
			{
				StopRechargingBatteries();
			}
			float num = GetLandElevation(bool_0: false, bool_1: false, bool_2: false, ParentScen);
			if (value < num + 1f)
			{
				value = num + 1f;
			}
			base.DesiredAltitude = value;
		}
	}

	public override bool IsOutOfFuel
	{
		get
		{
			if (IsNuke)
			{
				return false;
			}
			if (Fuel_ReadOnly.Count == 0)
			{
				return false;
			}
			return base.IsOutOfFuel;
		}
	}

	public Ship.ShipWakeSize WakeSize
	{
		get
		{
			if (CurrentSpeed == 0f)
			{
				return Ship.ShipWakeSize.NoWake;
			}
			if (IsSurfaced)
			{
				return Ship.ShipWakeSize.Small;
			}
			if (IsAtPeriscopeDepth)
			{
				return Ship.ShipWakeSize.VSmall;
			}
			return Ship.ShipWakeSize.NoWake;
		}
	}

	public new Submarine_Navigator Navigator
	{
		get
		{
			if (_TaskProxy == null)
			{
				ActiveUnit activeUnit_ = this;
				_TaskProxy = new Submarine_Navigator(ref activeUnit_);
			}
			return _TaskProxy;
		}
	}

	public new Submarine_AI AI => filterProxy;

	public new Submarine_Kinematics Kinematics
	{
		get
		{
			if (Information.IsNothing(m_TestsProxy))
			{
				ActiveUnit activeUnit_ = this;
				m_TestsProxy = new Submarine_Kinematics(ref activeUnit_);
			}
			return m_TestsProxy;
		}
	}

	public new Submarine_Sensory Sensory
	{
		get
		{
			if (Information.IsNothing(_InterpreterProxy))
			{
				ActiveUnit activeUnit_ = this;
				_InterpreterProxy = new Submarine_Sensory(ref activeUnit_);
			}
			return _InterpreterProxy;
		}
	}

	public new Submarine_Weaponry Weaponry
	{
		get
		{
			if (Information.IsNothing(m_ContainerProxy))
			{
				ActiveUnit activeUnit_ = this;
				m_ContainerProxy = new Submarine_Weaponry(ref activeUnit_);
			}
			return m_ContainerProxy;
		}
	}

	public new Submarine_CommStuff CommStuff
	{
		get
		{
			if (Information.IsNothing(composerProxy))
			{
				ActiveUnit activeUnit_ = this;
				composerProxy = new Submarine_CommStuff(ref activeUnit_);
			}
			return composerProxy;
		}
	}

	public new Submarine_Damage Damage
	{
		get
		{
			if (Information.IsNothing(modelProxy))
			{
				ActiveUnit activeUnit_ = this;
				modelProxy = new Submarine_Damage(ref activeUnit_);
			}
			return modelProxy;
		}
	}

	public bool IsTetheredROV
	{
		get
		{
			if (Type == _SubmarineType.ROV)
			{
				return ROVControlRadius_m > 0;
			}
			return false;
		}
	}

	public bool IsNuke
	{
		get
		{
			bool result = false;
			try
			{
				if (!advisorProxy.HasValue)
				{
					advisorProxy = false;
					foreach (Engine item in Propulsion)
					{
						if (item.Type == Engine.EngineType.Nuclear)
						{
							advisorProxy = true;
							break;
						}
					}
				}
				return result = advisorProxy.Value;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100803", "");
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
			AltBand currentAltBand = Kinematics.GetCurrentAltBand(GetCurrentAltitude(), bool_0: false);
			if (currentAltBand.Consumption_Flank.HasValue && currentAltBand.Speed_Flank.HasValue)
			{
				return Throttle.Flank;
			}
			return Throttle.Full;
		}
	}

	public bool IsSurfaced => GetCurrentAltitude() >= -5f;

	public bool IsAtPeriscopeDepth
	{
		get
		{
			if (Math.Round(GetCurrentAltitude()) < -20.0)
			{
				return false;
			}
			return Math.Round(GetCurrentAltitude()) < -5.0;
		}
	}

	public override GlobalVariables.TargetVisualSizeClass VisualSizeClass
	{
		get
		{
			if (GetCurrentAltitude() < -5f)
			{
				GetCurrentAltitude();
				return GlobalVariables.TargetVisualSizeClass.Stealthy;
			}
			float length = Length;
			if (length <= 150f)
			{
				if (length <= 100f)
				{
					if (length <= 60f)
					{
						if (length <= 35f)
						{
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

	public override bool IsMCMPlatform
	{
		get
		{
			if (MineCountermeasures != null && MineCountermeasures.Count > 0)
			{
				return true;
			}
			Sensor[] sensors_Cached = base.Sensors_Cached;
			int num = 0;
			while (true)
			{
				if (num < sensors_Cached.Length)
				{
					if (sensors_Cached[num].IsMineHuntingSensor)
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

	public override float CurrentSpeed
	{
		get
		{
			return base.CurrentSpeed;
		}
		set
		{
			base.CurrentSpeed = value;
			if (ParentScen.FifteenthSecondIsChangingOnThisPulse && value > (float)MaxTorpedoWireSpeed)
			{
				Weaponry.BreakTorpedoWires(Submarine_Weaponry.TorpedoWireBreakReason.ExcessiveSpeed);
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

	public bool IsAIP
	{
		get
		{
			foreach (FuelRec item in _Fuel)
			{
				if (item.FuelType == FuelRec._FuelType.AirIndepedent)
				{
					return true;
				}
			}
			return false;
		}
	}

	public override bool IsMineLayingPlatform
	{
		get
		{
			foreach (Mount mount in Mounts)
			{
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					if (mountWeapon.GetReferenceWeapon(ParentScen).IsMine && mount.Status == PlatformComponent._ComponentStatus.Operational && mountWeapon.CurrentLoad != 0)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	public float Displacement_Empty
	{
		get
		{
			return customerProxy;
		}
		set
		{
			customerProxy = value;
		}
	}

	public float Displacement_Standard
	{
		get
		{
			return _SerializerProxy;
		}
		set
		{
			_SerializerProxy = value;
		}
	}

	public float Displacement_Full
	{
		get
		{
			return m_RefProxy;
		}
		set
		{
			m_RefProxy = value;
		}
	}

	public bool IsDedicatedTankerOrUNREP => Type == _SubmarineType.APSS;

	static Submarine()
	{
		CommsEstablishDepth = -40;
		MaxTorpedoWireSpeed = 10;
	}

	private Submarine()
		: base(ref errorProxy)
	{
		Flags = default(_Flags);
		PressureHull = new PressureHull(this);
		Rudder = new Rudder(this);
		CIC = new CIC(this, "链路 / CIC");
		Cargo = new Cargo(this);
		ActiveUnit activeUnit_ = this;
		filterProxy = new Submarine_AI(ref activeUnit_);
		IsSubmarine = true;
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
			xmlWriter_0.WriteStartElement("Submarine");
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
			if (_Proficiency.HasValue)
			{
				xmlWriter_0.WriteElementString("Prof", ((int)_Proficiency.Value).ToString());
			}
			xmlWriter_0.WriteElementString("ThrottleSetting", ((byte)ThrottleSetting).ToString());
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
				xmlWriter_0.WriteElementString("IBPU", XmlConvert.ToString(EligibleForSAR));
			}
			if (IsBeingPickedUp)
			{
				xmlWriter_0.WriteElementString("IBPU", XmlConvert.ToString(IsBeingPickedUp));
			}
			if (AirFacilities_ReadOnly.Length != 0)
			{
				xmlWriter_0.WriteStartElement("AirFacilities");
				AirFacility[] airFacilities_ReadOnly = AirFacilities_ReadOnly;
				AirFacility[] array5 = airFacilities_ReadOnly;
				foreach (AirFacility airFacility in array5)
				{
					xmlWriter_0.WriteRaw(airFacility.ToXML(hashSet_0));
				}
				xmlWriter_0.WriteEndElement();
			}
			if (DockFacilities_ReadOnly.Length != 0)
			{
				xmlWriter_0.WriteStartElement("DockFacilities");
				DockFacility[] dockFacilities_ReadOnly = DockFacilities_ReadOnly;
				DockFacility[] array6 = dockFacilities_ReadOnly;
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
			Doctrine.ToXML(ref xmlWriter_0, ref ParentScen);
			xmlWriter_0.WriteStartElement("PressureHull");
			PressureHull.ToXML(ref xmlWriter_0, ref hashSet_0, ParentScen);
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Rudder");
			Rudder.ToXML(ref xmlWriter_0, ref hashSet_0, ParentScen);
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("CIC");
			CIC.ToXML(ref xmlWriter_0, ref hashSet_0, ParentScen);
			xmlWriter_0.WriteEndElement();
			Navigator.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteStartElement("Submarine_AI");
			AI.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteStartElement("Submarine_Kinematics");
			Kinematics.ToXML(ref xmlWriter_0);
			xmlWriter_0.WriteEndElement();
			Sensory.ToXML(ref xmlWriter_0);
			Weaponry.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteStartElement("Submarine_CommStuff");
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
			exception_?.Data.Add("Error at 100799", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Submarine FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		Submarine submarine = null;
		try
		{
			submarine = FillSpecification(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0, scenario_0.LoadStockUnits);
		}
		catch (PlatformComponentNotFoundException projectError)
		{
			ProjectData.SetProjectError(projectError);
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			ConcurrentDictionary<string, ScenarioObject> obj = concurrentDictionary_0;
			ScenarioObject value = submarine;
			obj.TryRemove(innerText, out value);
			submarine = FillSpecification(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0, bool_0: true);
			string text = "";
			if (submarine.IsGroupMember())
			{
				text = "(member of group: [" + submarine.GetParentGroup().Name + "])";
			}
			scenario_0.LoadingNotices.Add("The following submarine:[" + submarine.Name + "]" + text + " failed to shallow-rebuild because of a component missing. The submarine was instead deep-rebuilt, and instantiated in its pristine DB-stock condition. All customizations present in the submarine's components (damaged components, weapon additions/removals etc. etc.) have been lost. Please re-apply any necessary customizations either manually or using an SBR script.");
			ProjectData.ClearProjectError();
		}
		if (Information.IsNothing(submarine))
		{
			string innerText2 = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			ConcurrentDictionary<string, ScenarioObject> obj2 = concurrentDictionary_0;
			ScenarioObject value2 = new Submarine();
			obj2.TryRemove(innerText2, out value2);
		}
		return submarine;
	}

	private static Submarine FillSpecification(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0, bool bool_0)
	{
		try
		{
			Submarine submarine_ = new Submarine();
			submarine_.ParentScen = scenario_0;
			string text = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (Misc.CreateRequest(text, ' '))
			{
				text = text.Replace(" ", "-");
			}
			if (concurrentDictionary_0.ContainsKey(text))
			{
				return (Submarine)concurrentDictionary_0[text];
			}
			submarine_.ObjectID_Set(text);
			if (xmlNode_0.ChildNodes.Count == 1)
			{
				scenario_0.UnitsForLateInstantiation.Add(xmlNode_0);
				return submarine_;
			}
			concurrentDictionary_0.TryAdd(submarine_.ObjectID, submarine_);
			int num = Conversions.ToInteger(Misc.StartRequest(xmlNode_0.ChildNodes, "DBID").InnerText);
			try
			{
				DBFunctions.GetSubmarine(ref scenario_0, ref submarine_, num, bool_0);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ConcurrentDictionary<string, ScenarioObject> obj = concurrentDictionary_0;
				string objectID = submarine_.ObjectID;
				ScenarioObject value = submarine_;
				obj.TryRemove(objectID, out value);
				scenario_0.LoadingNotices.Add("潜艇数据库ID" + Conversions.ToString(num) + "在数据库中缺少因此未能加载。");
				ProjectData.ClearProjectError();
				return null;
			}
			if (bool_0)
			{
				submarine_.RegisterIssuer(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0);
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
						submarine_.CommonFromXML(xmlNode_);
						switch (xmlNode_.Name)
						{
						case "Comms":
							try
							{
								enumerator7 = xmlNode_.ChildNodes.GetEnumerator();
								while (enumerator7.MoveNext())
								{
									XmlNode xmlNode_10 = (XmlNode)enumerator7.Current;
									CommDevice commDevice = CommDevice.FromXML(ref xmlNode_10, ref concurrentDictionary_0, submarine_);
									submarine_.AddCommDevice(commDevice);
									commDevice.ParentPlatform = submarine_;
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
						case "CIC":
							submarine_.CIC = CIC.FromXML(ref xmlNode_, ref concurrentDictionary_0);
							break;
						case "OnboardCargo":
							try
							{
								enumerator12 = xmlNode_.ChildNodes.GetEnumerator();
								while (enumerator12.MoveNext())
								{
									XmlNode xmlNode_9 = (XmlNode)enumerator12.Current;
									Cargo cargo = Cargo.FromXML(ref xmlNode_9, ref concurrentDictionary_0, scenario_0, submarine_);
									ArrayExtensions.Add(ref submarine_.OnboardCargo, cargo);
									cargo.ParentPlatform = submarine_;
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
									XmlNode xmlNode_8 = (XmlNode)enumerator9.Current;
									FuelRec item = FuelRec.FromXML(ref xmlNode_8, ref concurrentDictionary_0);
									submarine_._Fuel.Add(item);
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
						case "PressureHull":
							submarine_.PressureHull = PressureHull.FromXML(ref xmlNode_, ref concurrentDictionary_0);
							break;
						case "DockFacilities":
							try
							{
								enumerator8 = xmlNode_.ChildNodes.GetEnumerator();
								while (enumerator8.MoveNext())
								{
									XmlNode xmlNode_7 = (XmlNode)enumerator8.Current;
									DockFacility dockFacility = DockFacility.FromXML(ref xmlNode_7, ref concurrentDictionary_0, ref scenario_0);
									submarine_.AddDockFacility(dockFacility);
									dockFacility.ParentPlatform = submarine_;
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
						case "Rudder":
							submarine_.Rudder = Rudder.FromXML(ref xmlNode_, ref concurrentDictionary_0);
							break;
						case "Sensors":
							try
							{
								enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									Sensor sensor = Sensor.FromXML((XmlNode)enumerator2.Current, concurrentDictionary_0, submarine_);
									ArrayExtensions.Add(ref submarine_._Sensors, sensor);
									sensor.ParentPlatform = submarine_;
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
									ActiveUnit activeUnit_ = submarine_;
									Engine engine = Engine.FromXML(ref xmlNode_6, ref concurrentDictionary_0, ref activeUnit_);
									submarine_.Propulsion.Add(engine);
									engine.ParentPlatform = submarine_;
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
									submarine_.AddAirFacility(airFacility);
									airFacility.ParentPlatform = submarine_;
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
									submarine_.AddSharedMagazine(magazine, bool_0: false);
									magazine.ParentPlatform = submarine_;
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
									Mount mount = Mount.FromXML(ref xmlNode_3, ref concurrentDictionary_0, submarine_);
									submarine_.Mounts.Add(mount);
									mount.ParentPlatform = submarine_;
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
			bool flag = false;
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
					case "Submarine_Damage":
					{
						Submarine submarine8 = submarine_;
						ActiveUnit activeUnit_9 = submarine_;
						submarine8.modelProxy = Submarine_Damage.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref activeUnit_9);
						break;
					}
					case "Status":
						if (Versioned.IsNumeric(xmlNode_2.InnerText))
						{
							if (Conversions.ToByte(xmlNode_2.InnerText) == 18)
							{
								flag = true;
							}
							else
							{
								submarine_.Status = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_2.InnerText);
							}
						}
						else
						{
							submarine_.Status = (_ActiveUnitStatus)Enum.Parse(typeof(_ActiveUnitStatus), xmlNode_2.InnerText, ignoreCase: true);
						}
						if (submarine_.Status == (_ActiveUnitStatus)9)
						{
							submarine_.Status = _ActiveUnitStatus.RTB;
						}
						break;
					case "AMP_OC_Speed":
						submarine_.m_PrototypeVal = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "Name":
						submarine_.Name = xmlNode_2.InnerText;
						break;
					case "FSBR":
						submarine_.comparatorVal = (_ActiveUnitFuelState)Conversions.ToByte(xmlNode_2.InnerText);
						break;
					case "DesiredTurnRate_Navigation":
					case "DTN":
						submarine_.DesiredTurnRate_Navigation = (Waypoint.TurnRateCategory)Conversions.ToByte(xmlNode_2.InnerText);
						break;
					case "SBED_Altitude_TF":
						submarine_.m_MockVal = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "SBPF_TF":
						submarine_.m_SystemVal = Conversions.ToBoolean(xmlNode_2.InnerText);
						break;
					case "LatLR":
						submarine_.Latitude_LastReported = XmlConvert.ToDouble(xmlNode_2.InnerText.Replace(",", "."));
						break;
					case "TUW":
						submarine_.TimeUnderway = XmlConvert.ToSingle(xmlNode_2.InnerText.Replace(",", "."));
						break;
					case "FuelState":
						submarine_._FuelState = (_ActiveUnitFuelState)Conversions.ToByte(xmlNode_2.InnerText);
						break;
					case "DamagePts":
						if (!bool_0)
						{
							submarine_.SetDamagePts(bool_0: false, null, XmlConvert.ToSingle(xmlNode_2.InnerText));
						}
						break;
					case "Submarine_Kinematics":
						ActiveUnit_Kinematics.FromXML(xmlNode_2, concurrentDictionary_0, submarine_);
						break;
					case "SBED_Altitude":
						submarine_.m_MappingVal = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "OldDamagePercent":
						submarine_.utilsVal = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "COA":
						submarine_.ChanceOfAppearance = Conversions.ToInteger(xmlNode_2.InnerText);
						break;
					case "AMP_OC_DAO":
						submarine_._ExporterVal = Conversions.ToBoolean(xmlNode_2.InnerText);
						break;
					case "SBPF_ThrottleSetting":
						switch (xmlNode_2.InnerText)
						{
						default:
							submarine_.candidateVal = (Throttle)Conversions.ToByte(xmlNode_2.InnerText);
							break;
						case "Loiter":
							submarine_.candidateVal = Throttle.Loiter;
							break;
						case "FullStop":
							submarine_.candidateVal = Throttle.FullStop;
							break;
						case "Full":
							submarine_.candidateVal = Throttle.Full;
							break;
						case "Flank":
							submarine_.candidateVal = Throttle.Flank;
							break;
						case "Cruise":
							submarine_.candidateVal = Throttle.Cruise;
							break;
						}
						break;
					case "Submarine_AI":
					{
						Submarine submarine7 = submarine_;
						ActiveUnit activeUnit_8 = submarine_;
						submarine7.filterProxy = Submarine_AI.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref activeUnit_8);
						break;
					}
					case "SBPF_Altitude_TF":
						submarine_.serviceVal = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "DesiredHeading":
					case "DH":
						submarine_.SetDesiredHeading(TurnRate.Max, XmlConvert.ToSingle(xmlNode_2.InnerText));
						break;
					case "ActiveUnit_AirOps":
					{
						Submarine submarine6 = submarine_;
						ActiveUnit activeUnit_7 = submarine_;
						submarine6._AirOps = ActiveUnit_AirOps.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref activeUnit_7);
						break;
					}
					case "SBR":
						submarine_.predicateVal = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_2.InnerText);
						break;
					case "SBR_Altitude_TF":
						submarine_.setterVal = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "ThrottleSetting":
						switch (xmlNode_2.InnerText)
						{
						default:
							submarine_.ThrottleSetting = (Throttle)Conversions.ToByte(xmlNode_2.InnerText);
							break;
						case "Loiter":
							submarine_.ThrottleSetting = Throttle.Loiter;
							break;
						case "FullStop":
							submarine_.ThrottleSetting = Throttle.FullStop;
							break;
						case "Full":
							submarine_.ThrottleSetting = Throttle.Full;
							break;
						case "Flank":
							submarine_.ThrottleSetting = Throttle.Flank;
							break;
						case "Cruise":
							submarine_.ThrottleSetting = Throttle.Cruise;
							break;
						}
						break;
					case "SBED_DesiredSpeedOverride":
						submarine_.queueVal = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "Doctrine":
						submarine_.Doctrine = Doctrine.FromXML(ref xmlNode_2, submarine_);
						break;
					case "ActiveEnterAreaTriggers":
						try
						{
							enumerator4 = xmlNode_2.ChildNodes.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								string innerText2 = ((XmlNode)enumerator4.Current).InnerText;
								submarine_.ActiveEnterAreaTriggers.Add(innerText2);
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
							submarine_.fieldVal = (Throttle)Conversions.ToByte(xmlNode_2.InnerText);
							break;
						case "Loiter":
							submarine_.fieldVal = Throttle.Loiter;
							break;
						case "FullStop":
							submarine_.fieldVal = Throttle.FullStop;
							break;
						case "Full":
							submarine_.fieldVal = Throttle.Full;
							break;
						case "Flank":
							submarine_.fieldVal = Throttle.Flank;
							break;
						case "Cruise":
							submarine_.fieldVal = Throttle.Cruise;
							break;
						}
						break;
					case "SBEO_TF":
						submarine_.m_PageVal = Conversions.ToBoolean(xmlNode_2.InnerText);
						break;
					case "WeaponState":
						submarine_._WeaponState = (_ActiveUnitWeaponState)Conversions.ToByte(xmlNode_2.InnerText);
						break;
					case "Prof":
						submarine_.Proficiency = (GlobalVariables.ProficiencyLevel)Conversions.ToInteger(xmlNode_2.InnerText);
						break;
					case "SBED_TF":
						submarine_.tagVal = Conversions.ToBoolean(xmlNode_2.InnerText);
						break;
					case "Submarine_Weaponry":
					{
						Submarine submarine5 = submarine_;
						ActiveUnit activeUnit_6 = submarine_;
						submarine5.m_ContainerProxy = Submarine_Weaponry.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref activeUnit_6);
						break;
					}
					case "OODA_D":
						submarine_.HasCustomOODA = true;
						submarine_.m_TokenVal = Conversions.ToShort(xmlNode_2.InnerText);
						break;
					case "OODA_E":
						submarine_.HasCustomOODA = true;
						submarine_._ResolverVal = Conversions.ToShort(xmlNode_2.InnerText);
						break;
					case "AMP_OC_DSO":
						submarine_._VisitorVal = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "CurrentAltitude":
					case "CA":
						submarine_.SetCurrentAltitude(bool_0: false, XmlConvert.ToSingle(xmlNode_2.InnerText));
						break;
					case "Latitude_UnitEntersAreaCheck":
						submarine_.Latitude__UnitEntersAreaCheck = XmlConvert.ToDouble(xmlNode_2.InnerText);
						break;
					case "AssignedMission":
						if (xmlNode_2.HasChildNodes)
						{
							XmlNode xmlNode3 = xmlNode_2.ChildNodes[0];
							submarine_._AssignedMissionOrPackage_ID = xmlNode3.InnerText;
						}
						break;
					case "DA":
					case "DesiredAltitude":
						submarine_.DesiredAltitude = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "EFSAR":
						submarine_.EligibleForSAR = Conversions.ToBoolean(xmlNode_2.InnerText);
						break;
					case "OODA_T":
						submarine_.HasCustomOODA = true;
						submarine_._IndexerVal = Conversions.ToShort(xmlNode_2.InnerText);
						break;
					case "Longitude":
					case "Lon":
						submarine_.SetLongitude(null, XmlConvert.ToDouble(xmlNode_2.InnerText));
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
									submarine_.ActiveRemainAreaTriggers.Add(key, result);
									continue;
								}
								string innerText = xmlNode2.InnerText;
								long result2 = 0L;
								if (long.TryParse(innerText, out result2))
								{
									result = DateTime.FromBinary(Conversions.ToLong(xmlNode2.InnerText));
									submarine_.ActiveRemainAreaTriggers.Add(key, result);
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
					case "Sensory":
					{
						Submarine submarine4 = submarine_;
						ActiveUnit activeUnit_5 = submarine_;
						submarine4._InterpreterProxy = Submarine_Sensory.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref activeUnit_5);
						break;
					}
					case "Submarine_CommStuff":
					{
						Submarine submarine3 = submarine_;
						ActiveUnit activeUnit_4 = submarine_;
						submarine3.composerProxy = Submarine_CommStuff.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref activeUnit_4);
						break;
					}
					case "CustomIcon":
						submarine_.CustomIcon = xmlNode_2.InnerText;
						break;
					case "Side":
						submarine_._SideName = xmlNode_2.InnerText;
						break;
					case "SBPF_Altitude":
						submarine_._MethodVal = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "DS":
					case "DesiredSpeed":
						submarine_.DesiredSpeed = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "IBPU":
						submarine_.IsBeingPickedUp = Conversions.ToBoolean(xmlNode_2.InnerText);
						break;
					case "AssignedTaskPool":
						if (xmlNode_2.HasChildNodes)
						{
							XmlNode xmlNode = xmlNode_2.ChildNodes[0];
							submarine_._AssignedTaskPool_ID = xmlNode.InnerText;
						}
						break;
					case "SBEO_Altitude":
						submarine_.regVal = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "SBR_ThrottleSetting":
						switch (xmlNode_2.InnerText)
						{
						default:
							submarine_._TemplateVal = (Throttle)Conversions.ToByte(xmlNode_2.InnerText);
							break;
						case "Loiter":
							submarine_._TemplateVal = Throttle.Loiter;
							break;
						case "FullStop":
							submarine_._TemplateVal = Throttle.FullStop;
							break;
						case "Full":
							submarine_._TemplateVal = Throttle.Full;
							break;
						case "Flank":
							submarine_._TemplateVal = Throttle.Flank;
							break;
						case "Cruise":
							submarine_._TemplateVal = Throttle.Cruise;
							break;
						}
						break;
					case "Message":
						submarine_.Message = xmlNode_2.InnerText;
						break;
					case "SBEO_Altitude_TF":
						submarine_.paramVal = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "ActiveUnit_DockingOps":
					{
						Submarine submarine2 = submarine_;
						ActiveUnit activeUnit_3 = submarine_;
						submarine2._DockingOps = ActiveUnit_DockingOps.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref activeUnit_3);
						break;
					}
					case "Latitude":
					case "Lat":
						submarine_.SetLatitude(null, XmlConvert.ToDouble(xmlNode_2.InnerText));
						break;
					case "LonLR":
						submarine_.Longitude_LastReported = XmlConvert.ToDouble(xmlNode_2.InnerText.Replace(",", "."));
						break;
					case "AMP_OC":
						submarine_.m_AttrVal = Conversions.ToBoolean(xmlNode_2.InnerText);
						break;
					case "SBR_Altitude":
						submarine_._ItemVal = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "SBR_TF":
						submarine_._CreatorVal = Conversions.ToBoolean(xmlNode_2.InnerText);
						break;
					case "SBEO":
						submarine_._RecordVal = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_2.InnerText);
						break;
					case "SBED":
						submarine_._SingletonVal = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_2.InnerText);
						break;
					case "DT":
					case "DesiredTurnRate":
						submarine_.DesiredTurnRate = (TurnRate)Conversions.ToByte(xmlNode_2.InnerText);
						break;
					case "CS":
					case "CurrentSpeed":
						submarine_.CurrentSpeed = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "Longitude_UnitEntersAreaCheck":
						submarine_.Longitude__UnitEntersAreaCheck = XmlConvert.ToDouble(xmlNode_2.InnerText);
						break;
					case "ParentGroup":
						submarine_._ParentGroup_ID = xmlNode_2.InnerText;
						break;
					case "SBEO_ThrottleSetting":
						switch (xmlNode_2.InnerText)
						{
						default:
							submarine_.m_RulesVal = (Throttle)Conversions.ToByte(xmlNode_2.InnerText);
							break;
						case "Loiter":
							submarine_.m_RulesVal = Throttle.Loiter;
							break;
						case "FullStop":
							submarine_.m_RulesVal = Throttle.FullStop;
							break;
						case "Full":
							submarine_.m_RulesVal = Throttle.Full;
							break;
						case "Flank":
							submarine_.m_RulesVal = Throttle.Flank;
							break;
						case "Cruise":
							submarine_.m_RulesVal = Throttle.Cruise;
							break;
						}
						break;
					case "CH":
					case "CurrentHeading":
						submarine_.CurrentHeading = XmlConvert.ToSingle(xmlNode_2.InnerText);
						break;
					case "Submarine_Navigator":
					{
						Submarine submarine = submarine_;
						ActiveUnit activeUnit_2 = submarine_;
						submarine._TaskProxy = Submarine_Navigator.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref activeUnit_2);
						break;
					}
					case "IsAD":
					case "IsAutoDetectable":
						submarine_.SetIsAutoDetectable(null, Conversions.ToBoolean(xmlNode_2.InnerText));
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
			float maximumAltitude = submarine_.Kinematics.GetMaximumAltitude();
			float minimumAltitude = submarine_.Kinematics.GetMinimumAltitude();
			if (submarine_.GetCurrentAltitude() <= maximumAltitude)
			{
				if (submarine_.GetCurrentAltitude() < minimumAltitude)
				{
					submarine_.SetCurrentAltitude(bool_0: false, minimumAltitude);
				}
			}
			else
			{
				submarine_.SetCurrentAltitude(bool_0: false, maximumAltitude);
			}
			if (submarine_.DesiredAltitude <= maximumAltitude)
			{
				if (submarine_.DesiredAltitude < minimumAltitude)
				{
					submarine_.DesiredAltitude = minimumAltitude;
				}
			}
			else
			{
				submarine_.DesiredAltitude = maximumAltitude;
			}
			if (flag)
			{
				submarine_.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries;
			}
			return submarine_;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100800", "");
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
	public override _ActiveUnitFuelState GetIsBingoOrJoker(GeoPoint geoPoint_0, Doctrine._FuelState? nullable_0)
	{
		try
		{
			if (IsNuke)
			{
				return _ActiveUnitFuelState.None;
			}
			if (IsTetheredROV && Fuel_ReadOnly.Count == 0)
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
			exception_?.Data.Add("Error at 100801", "");
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
	public override _ActiveUnitFuelState GetIsBingoTowardsThisDestination(ActiveUnit activeUnit_0, GeoPoint geoPoint_0, Doctrine._FuelState? nullable_0)
	{
		_ActiveUnitFuelState result = _ActiveUnitFuelState.None;
		try
		{
			Engine engine_ = null;
			Engine.EngineType engineType = ((Propulsion.Where((Engine theE) => theE.Type == Engine.EngineType.Diesel).Count() <= 0) ? Engine.EngineType.Electric : Engine.EngineType.Diesel);
			int num = Propulsion.Count - 1;
			int int_ = 0;
			for (int i = 0; i <= num; i++)
			{
				Engine engine = Propulsion[i];
				if (engine.Type == engineType)
				{
					engine_ = engine;
					int_ = i;
					break;
				}
			}
			float num2 = Math.Max(-20f, Kinematics.GetMinimumAltitude());
			float num3 = Kinematics.GetMaximumSpeed(num2, Throttle.Cruise, engine_, int_, bool_0: false);
			float num4 = GetFuelEndurance(Throttle.Cruise, null, num3, num2, engine_, int_);
			if (num4 <= 900f)
			{
				result = _ActiveUnitFuelState.IsBingo;
				return _ActiveUnitFuelState.IsBingo;
			}
			float num5 = Module_Unit.RangeToUnit_Horiz(this, activeUnit_0);
			if ((double)(num4 * (num3 / 3600f)) < (double)num5 * 1.1)
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
			exception_?.Data.Add("Error at 100802", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal bool CalculateSpecification()
	{
		if (CurrentSpeed <= 0f)
		{
			return false;
		}
		return DesiredSpeed >= (float)Kinematics.CavitationSpeed(GetCurrentAltitude());
	}

	bool IBoat.IsCavitating()
	{
		return CalculateSpecification();
	}

	[SpecialName]
	public override int GetMastHeight_Radar(Sensor sensor_0 = null)
	{
		if (sensor_0 != null && sensor_0.MastHeight != 0)
		{
			return sensor_0.MastHeight;
		}
		return (int)Math.Round(22f + GetCurrentAltitude());
	}

	[SpecialName]
	public override int GetMastHeight_Visual(Sensor sensor_0 = null)
	{
		if (sensor_0 != null && sensor_0.MastHeight != 0)
		{
			return sensor_0.MastHeight;
		}
		return (int)Math.Round(22f + GetCurrentAltitude());
	}

	public override void DoTypeSpecificActions(float float_0, ref LockRandom lockRandom_0)
	{
		try
		{
			if ((Type == _SubmarineType.ROV || Type == _SubmarineType.UUV) && AssignedMissionOrPackage() != null && AssignedMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing && IsOperating() && base.HasMineDisposalCharges)
			{
				bool flag = false;
				foreach (Sensor mineCountermeasure in MineCountermeasures)
				{
					if (mineCountermeasure.IsExplosiveMineNeutralizer && mineCountermeasure.Status == PlatformComponent._ComponentStatus.Operational)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					WeaponState = _ActiveUnitWeaponState.IsWinchester;
					DockingOps.AttemptToRTB(bool_0: false, _ActiveUnitStatus.RTB, bool_1: false, _ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
					return;
				}
			}
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
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100804", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void PostDeserializationHousekeeping_General(ref Scenario scenario_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, List<ActiveUnit> list_0, bool bool_0)
	{
		base.PostDeserializationHousekeeping_General(ref scenario_0, concurrentDictionary_0, list_0, bool_0);
		ActiveUnit_DockingOps.PostDeserializationHousekeeping(DockingOps, ref scenario_0, concurrentDictionary_0, bool_0);
	}

	public override void SetThrottle(Throttle throttle_0, float? nullable_0 = null)
	{
		try
		{
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
					DesiredSpeed = nullable_0.Value;
				}
				else
				{
					DesiredSpeed = Kinematics.GetMaximumSpeed(GetCurrentAltitude(), throttle_0, bool_0: false);
				}
			}
			RaiseEvent_ChangedThrottleSetting(this, throttle_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200583", exception_.Message);
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
					if (GetIsInsideThisArea(patrol.ProsecutionArea, ParentScen, bool_0: true) && !GeoPoint.IsInsideThisArea(double_0, double_1, patrol.ProsecutionArea))
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
				if (GeoPoint.GetIsInCanal(double_0, double_1))
				{
					bool_3 = false;
					bool_5 = false;
					return true;
				}
				if ((bool_3 || bool_0) && CountClient(double_0, double_1, float_0))
				{
					bool_3 = true;
					bool_5 = false;
					string_0 = "这一点在禁航区域内。";
					return false;
				}
				if (GeoPoint.IsInPierLane(double_0, double_1, ParentScen))
				{
					bool_3 = false;
					bool_5 = false;
					return true;
				}
				if (PopSpecification(double_0, double_1, bool_0, bool_1, bool_2, bool_4, ref bool_5, nullable_1, ref string_0, ref bool_8))
				{
					bool_3 = false;
					bool_5 = false;
					return true;
				}
				bool_3 = false;
				bool_5 = false;
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
			exception_?.Data.Add("Error at 200283", exception_.Message);
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

	public override void Destroy(bool bool_0, bool bool_1, bool bool_2, string string_0, string string_1 = null)
	{
		try
		{
			IsBeingDestroyed = true;
			DockingOps.HostDockFacility = null;
			if (!IsOperating() && !bool_0)
			{
				ParentScen.AddMessage(Name + "已被摧毁！", Name + " 已摧毁", LoggedMessage.MessageType.UnitLost, 0, ObjectID, GetUnitSide(), new Geopoint_Struct(GetLongitude(), GetLatitude()));
			}
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
			if (DockFacilities_ReadOnly.Length != 0)
			{
				foreach (ActiveUnit embarkedBoat in DockingOps.EmbarkedBoats)
				{
					embarkedBoat.Destroy(bool_0, bool_1, bool_2, "Destroyed as the object it is docked to is being destroyed", "Host Destruction");
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
			exception_?.Data.Add("Error at 100807", "");
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

	[SpecialName]
	public override int GetSafeDistanceAgainstUnknownMine_meters(bool bool_0)
	{
		if (Type != _SubmarineType.ROV && Type != _SubmarineType.UUV)
		{
			return base.GetSafeDistanceAgainstUnknownMine_meters(bool_0);
		}
		return 0;
	}

	private bool PopSpecification(double double_0, double double_1, bool bool_0, bool bool_1, bool bool_2, bool bool_3, ref bool bool_4, short? nullable_0, ref string string_0, ref bool bool_5)
	{
		short num;
		if (nullable_0.HasValue)
		{
			num = nullable_0.Value;
		}
		else
		{
			(bool, short?) tuple = Terrain.ExcludeWatcher(double_0, double_1);
			if (tuple.Item1)
			{
				return false;
			}
			num = (tuple.Item2.HasValue ? tuple.Item2.Value : Terrain.GetElevation(double_0, double_1, bool_0: false, ParentScen));
		}
		short num2 = -10;
		try
		{
			if (num <= num2)
			{
				if (bool_3 && !IsNuke && SeaIceProvider.PrepareWriter(double_1, double_0))
				{
					string_0 = "点在冰下，潜艇不是核动力。";
					return false;
				}
				if (bool_4)
				{
					bool flag = false;
					if (GetSafeDistanceAgainstUnknownMine_meters(bool_1) > 0 && GetUnitSide().Contacts_NonAU.Count > 0)
					{
						Parallel.ForEach(GetUnitSide().Contacts_NonAU.ToList(), delegate(string theID, ParallelLoopState loopstate)
						{
							UnguidedWeapon value = null;
							ParentScen.UnguidedWeapons.TryGetValue(theID, ref value);
							if (!Information.IsNothing(value) && value.IsMine)
							{
								short num3 = (short)GetSafeDistanceAgainstKnownMineType_meters(value.Type, bool_1);
								if (!bool_0)
								{
									if (bool_2)
									{
										return;
									}
									UnguidedWeapon unit_ = value;
									Submarine unit_2 = this;
									string string_ = "";
									if (Math.Abs(Module_Unit.PrintTokenizer(unit_, unit_2, bool_0: true, ref string_)) > 45f)
									{
										return;
									}
								}
								if (Math2.VerifyClass(double_0, double_1, value.GetLatitude(), value.GetLongitude()) * 1852f < (float)num3)
								{
									flag = true;
									loopstate.Stop();
								}
							}
						});
					}
					if (flag)
					{
						bool_4 = true;
						string_0 = "距离雷区太近了。";
						return false;
					}
				}
				return true;
			}
			bool_5 = false;
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100808", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			string_0 = "Error!";
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public Submarine(ref Scenario scenario_0, string string_0 = null)
		: base(ref scenario_0, string_0)
	{
		Flags = default(_Flags);
		PressureHull = new PressureHull(this);
		Rudder = new Rudder(this);
		CIC = new CIC(this, "链路 / CIC");
		Cargo = new Cargo(this);
		ActiveUnit activeUnit_ = this;
		filterProxy = new Submarine_AI(ref activeUnit_);
		IsSubmarine = true;
		IsBoat = true;
	}

	[SpecialName]
	public override float GetCurrentAltitude(bool bool_0 = false)
	{
		return base.GetCurrentAltitude(bool_0);
	}

	[SpecialName]
	public override void SetCurrentAltitude(bool bool_0, float float_0)
	{
		base.SetCurrentAltitude(bool_0, float_0);
		if (IsTetheredROV || IsBiological || IsFalseTarget || !ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticSubComms))
		{
			return;
		}
		if (float_0 >= (float)CommsEstablishDepth && CommStuff.CommsDeviceAvailable && CommStuff.ReasonForBeingOffGrid != ActiveUnit_CommStuff.ReasonForGoingOffGrid.ChangeOfInternalStatus)
		{
			CommStuff.SetIsConnectedToSideNetwork(ActiveUnit_CommStuff.ReasonForGoingOffGrid.None, bool_0: true);
			if (CommStuff.HasBeenSummonedToReestablishComms)
			{
				CommStuff.HasBeenSummonedToReestablishComms = false;
				AI.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
				DesiredAltitude = CommsEstablishDepth;
				Status = _ActiveUnitStatus.Unassigned;
			}
		}
		else if (CommStuff.CommsDeviceAvailable)
		{
			CommStuff.SetIsConnectedToSideNetwork(ActiveUnit_CommStuff.ReasonForGoingOffGrid.DivingDeep, bool_0: false);
		}
		else
		{
			CommStuff.SetIsConnectedToSideNetwork(ActiveUnit_CommStuff.ReasonForGoingOffGrid.AllCommDevicesDisabled, bool_0: false);
		}
	}

	[SpecialName]
	public override void SetDesiredHeading(TurnRate turnRate_0, float float_0)
	{
		base.SetDesiredHeading(turnRate_0, float_0);
		if (ParentScen.FifteenthSecondIsChangingOnThisPulse && float_0 == 0f)
		{
			Weaponry.BreakTorpedoWires(Submarine_Weaponry.TorpedoWireBreakReason.ExcessiveTurnRate);
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
				else if (((Submarine)activeUnits_).Type == _SubmarineType.UUV && activeUnits_.DockingOps.GetAssignedHostUnit(bool_0: true) == this)
				{
					Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_2 = Mission.MissionAssignmentAttemptResult.None;
					activeUnits_.Set_AssignedMissionOrPackage(mission_0, bool_0, bool_1, ref missionAssignmentAttemptResult_2);
				}
			}
			if (mission_0 != null && mission_0.Doctrine.NewRepository(ParentScen).LoginInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.Active && Doctrine.EMCON_Inherits && Doctrine.NewRepository(ParentScen).LoginInterruptibleField() != Doctrine.EMCONSettings._EMCONSetting.Active)
			{
				Doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Passive, ParentScen);
				AddMessage("潜艇：" + Name + " was assigned to mission: " + mission_0.Name + " which includes radar EMCON Active. Because the submarine is set to inherit this setting, and to avoid radiating at periscope or shallower depth, the submarine will override this EMCON directive and switch to passive instead. If you do indeed wish for this submarine to radiate, you must manually enforce this EMCON.", "潜艇：" + Name + " was assigned to mission: " + mission_0.Name + " which includes radar EMCON Active.", LoggedMessage.MessageType.SpecialMessage, 0, bool_0: false, default(Geopoint_Struct));
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

	public override void DoFuelConsumption(float float_0)
	{
		try
		{
			if (IsNuke || Fuel_ReadOnly.Count == 0 || (ThrottleSetting == Throttle.FullStop && IsNuke))
			{
				return;
			}
			SelectedEngines = AI.SelectEngines();
			FuelRec fuelRec = null;
			foreach (KeyValuePair<int, Engine> selectedEngine in SelectedEngines)
			{
				Engine value = selectedEngine.Value;
				int key = selectedEngine.Key;
				FuelRec._FuelType Local_FuelTypeToConsume = AI.SelectFuelTypeToConsume(value);
				if (Local_FuelTypeToConsume != FuelRec._FuelType.Battery)
				{
					if ((from theRec in Fuel_ReadOnly
						where theRec.FuelType == Local_FuelTypeToConsume
						select (theRec)).ElementAtOrDefault(0).CurrentQuantity == 0f)
					{
						continue;
					}
					if (fuelRec == null)
					{
						fuelRec = (from theRec in Fuel_ReadOnly
							where theRec.FuelType == FuelRec._FuelType.Battery
							select (theRec)).ElementAtOrDefault(0);
					}
					if (fuelRec != null && fuelRec.PercentFull >= 1f)
					{
						continue;
					}
				}
				float float_ = ((Local_FuelTypeToConsume == FuelRec._FuelType.AirIndepedent) ? InstantiateSpecification(Throttle.Loiter, null, null, null, value, key) : InstantiateSpecification(ThrottleSetting, null, (int)Math.Round(DesiredSpeed), GetCurrentAltitude(), value, key)) * float_0;
				Fuel_Subtract(float_, Local_FuelTypeToConsume);
				if (value.Type == Engine.EngineType.Diesel)
				{
					RechargeBatteries(value, fuelRec, float_0);
				}
				else if (value.Type == Engine.EngineType.AIP)
				{
					RechargeBatteries(value, fuelRec, float_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100809", "");
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
			FuelRec fuelRec = (from theRec in Fuel_ReadOnly
				where theRec.FuelType == _FuelType_0
				select (theRec)).ElementAtOrDefault(0);
			if (fuelRec.CurrentQuantity <= float_0)
			{
				bool flag = fuelRec.CurrentQuantity > 0f;
				fuelRec.CurrentQuantity = 0f;
				if (Fuel_ReadOnly.Where((FuelRec theFR) => theFR.CurrentQuantity > 0f).Count() == 0)
				{
					SetThrottle(Throttle.FullStop);
					if (flag)
					{
						AddMessage(Name + " (" + Misc.ReadRequest(UnitClass) + "）燃料耗尽，在水里沉没！", Name + " 油料耗尽", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
						Kinematics.DesiredSpeedOverride = null;
					}
				}
				else if (flag)
				{
					SetThrottle(Throttle.Loiter);
					AddMessage(Name + " (" + Misc.ReadRequest(UnitClass) + "）燃料耗尽，试图使用替代推进力。", Name + " 切换引擎", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
					Kinematics.DesiredSpeedOverride = null;
					Kinematics.DesiredAltitudeOverride = false;
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
			exception_?.Data.Add("Error at 100810", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void StopRechargingBatteries()
	{
		if (DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
		{
			DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Underway;
		}
	}

	public void RechargeBatteries(Engine engine_0, FuelRec fuelRec_0, float float_0)
	{
		try
		{
			if (fuelRec_0 == null || (engine_0.Type == Engine.EngineType.Diesel && !(Math.Round(GetCurrentAltitude()) >= -20.0)) || (engine_0.Type != Engine.EngineType.Diesel && engine_0.Type != Engine.EngineType.AIP))
			{
				return;
			}
			if (engine_0.Type == Engine.EngineType.Diesel && !Flags.HasSnorkel && !IsSurfaced)
			{
				StopRechargingBatteries();
				return;
			}
			float num = 0f;
			if (engine_0.Type == Engine.EngineType.Diesel)
			{
				if (DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
				{
					DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries;
				}
				num = (float)((double)fuelRec_0.MaxQuantity / 60.0 / 8.0);
				if (Flags.UsesLiOnBattery)
				{
					num = (float)(1.25 * (double)num);
				}
				float num2 = fuelRec_0.CurrentQuantity / (float)fuelRec_0.MaxQuantity;
				num = ((num2 < 0.25f) ? (num * 2f) : ((num2 < 0.5f) ? ((float)((double)num * 1.5)) : ((num2 < 0.75f) ? ((float)((double)num * 0.77)) : ((float)((double)num * 0.5)))));
			}
			else if (engine_0.Type == Engine.EngineType.AIP)
			{
				Engine engine = Propulsion.Where((Engine theE) => theE.Type == Engine.EngineType.Electric).ElementAtOrDefault(0);
				if (engine == null)
				{
					engine = Propulsion.Where((Engine theE) => theE.Type == Engine.EngineType.AIP).ElementAtOrDefault(0);
				}
				num = ((engine == null) ? 1f : ((engine.AltBands[0].Consumption_Loiter <= 0f) ? 1f : engine.AltBands[0].Consumption_Loiter));
				if (fuelRec_0.CurrentQuantity <= 0f)
				{
					fuelRec_0.CurrentQuantity = 0.0001f;
				}
			}
			if (engine_0.Status == PlatformComponent._ComponentStatus.Damaged)
			{
				num /= 2f;
			}
			fuelRec_0.CurrentQuantity += num / 60f * float_0;
			if (fuelRec_0.CurrentQuantity > (float)fuelRec_0.MaxQuantity)
			{
				fuelRec_0.CurrentQuantity = fuelRec_0.MaxQuantity;
			}
			if (fuelRec_0.CurrentQuantity == (float)fuelRec_0.MaxQuantity)
			{
				StopRechargingBatteries();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100811", "");
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
		if (!IsNuke && !IsBiological)
		{
			return InstantiateSpecification(throttle_0, null, (int)Math.Round(DesiredSpeed), GetCurrentAltitude(), PrimaryEngine, PrimaryEngineNo);
		}
		return 0f;
	}

	private float InstantiateSpecification(Throttle throttle_0, AltBand altBand_0, float? nullable_0, float? nullable_1, Engine engine_0, int int_0)
	{
		if (!IsNuke && !IsBiological)
		{
			if (engine_0 == null)
			{
				return 0f;
			}
			if (Propulsion.Count == 0)
			{
				return 0f;
			}
			AltBand altBand = null;
			AltBand altBand2 = null;
			try
			{
				if (engine_0.Status == PlatformComponent._ComponentStatus.Destroyed)
				{
					return 0f;
				}
				if (engine_0.AltBands.Length == 0)
				{
					return 0f;
				}
				if (altBand_0 == null)
				{
					if (nullable_1.HasValue)
					{
						altBand = Kinematics.GetCurrentAltBand_CurrentAltitude(nullable_1.Value, engine_0, bool_0: false);
					}
					else
					{
						altBand = Kinematics.GetCurrentAltBand(GetCurrentAltitude(), bool_0: false);
					}
				}
				else
				{
					altBand = altBand_0;
				}
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
					goto IL_0340;
				case Throttle.Cruise:
					if (engine_0.AltBands[0].Consumption_Cruise <= 0f)
					{
						return InstantiateSpecification(Throttle.Loiter, altBand_0, nullable_0, nullable_1, engine_0, int_0);
					}
					num = altBand.Consumption_Cruise;
					num2 = altBand.Consumption_Loiter;
					goto IL_0340;
				case Throttle.Full:
					if (altBand.Speed_Full.HasValue)
					{
						float? consumption_Full = engine_0.AltBands[0].Consumption_Full;
						if ((consumption_Full.HasValue ? new bool?(consumption_Full.GetValueOrDefault() > 0f) : null).GetValueOrDefault())
						{
							num = altBand.Consumption_Full.Value;
							_ = altBand.Speed_Full.Value;
							num2 = altBand.Consumption_Cruise;
							goto IL_0340;
						}
					}
					return InstantiateSpecification(Throttle.Cruise, altBand_0, nullable_0, nullable_1, engine_0, int_0);
				case Throttle.Flank:
					{
						if (!altBand.Speed_Flank.HasValue)
						{
							break;
						}
						float? consumption_Flank = engine_0.AltBands[0].Consumption_Flank;
						if (!(consumption_Flank.HasValue ? new bool?(consumption_Flank.GetValueOrDefault() > 0f) : null).GetValueOrDefault())
						{
							break;
						}
						num = altBand.Consumption_Flank.Value;
						_ = altBand.Speed_Flank.Value;
						num2 = (altBand.Speed_Full.HasValue ? altBand.Consumption_Full.Value : altBand.Consumption_Cruise);
						goto IL_0340;
					}
					IL_0340:
					num3 = num;
					if (nullable_0.HasValue && nullable_1.HasValue)
					{
						float? num6;
						if (altBand != Kinematics.HighestAltBand(engine_0))
						{
							AltBand[] altBands = engine_0.AltBands;
							if (altBands.Length == 0)
							{
								return 0f;
							}
							altBand2 = (from AltBand in altBands
								where AltBand.MinAlt >= altBand.MaxAlt
								orderby AltBand.MaxAlt
								select AltBand).ElementAtOrDefault(0);
							float num4;
							float num5;
							switch (throttle_0)
							{
							default:
								return 0f;
							case Throttle.FullStop:
								num4 = 0f;
								num5 = 0f;
								break;
							case Throttle.Loiter:
								num4 = altBand2.Consumption_Loiter;
								num5 = 0f;
								break;
							case Throttle.Cruise:
								num4 = altBand2.Consumption_Cruise;
								num5 = altBand2.Consumption_Loiter;
								break;
							case Throttle.Full:
								if (altBand2.Speed_Full.HasValue)
								{
									num4 = altBand2.Consumption_Full.Value;
									_ = altBand2.Speed_Full.Value;
									num5 = altBand2.Consumption_Cruise;
									break;
								}
								throw new Exception("潜艇有全油门但数据库中没有油耗参数！");
							case Throttle.Flank:
								if (altBand2.Speed_Flank.HasValue)
								{
									num4 = altBand2.Consumption_Flank.Value;
									_ = altBand2.Speed_Flank.Value;
									num5 = (altBand2.Speed_Full.HasValue ? altBand2.Consumption_Full.Value : altBand2.Consumption_Cruise);
								}
								else
								{
									num4 = num;
									num5 = num2;
								}
								break;
							}
							if (num4 != num)
							{
								num6 = nullable_1;
								float minAlt = altBand.MinAlt;
								if ((num6.HasValue ? new bool?(num6.GetValueOrDefault() != minAlt) : null).GetValueOrDefault())
								{
									float value = ((nullable_1 - altBand.MinAlt) / (altBand.MaxAlt - altBand.MinAlt)).Value;
									value = Math.Abs(value);
									num += (num4 - num) * value;
									num3 = num;
									num2 += (num5 - num2) * value;
								}
							}
						}
						float num7 = Kinematics.GetMaximumSpeed(nullable_1.Value, throttle_0, engine_0, int_0, bool_0: false);
						num6 = nullable_0;
						if ((num6.HasValue ? new bool?(num6.GetValueOrDefault() < num7) : null).GetValueOrDefault())
						{
							float num8 = Kinematics.GetMaximumSpeed(nullable_1.Value, throttle_0 - 1, engine_0, int_0, bool_0: false);
							num6 = nullable_0;
							float value2;
							if ((num6.HasValue ? new bool?(num6.GetValueOrDefault() >= num8) : null).GetValueOrDefault())
							{
								value2 = ((nullable_0 - num8) / (num7 - num8)).Value;
								value2 = Math.Abs(value2);
							}
							else
							{
								value2 = 0f;
							}
							num3 = num2 + (num - num2) * value2;
						}
					}
					return num3 / 60f;
				}
				return InstantiateSpecification(Throttle.Full, altBand_0, nullable_0, nullable_1, engine_0, int_0);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200349", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return 0.001f;
			}
		}
		return 0f;
	}

	internal float CreateSpecification()
	{
		return 0f;
	}

	float ICargoHost.GetCargo_Crew()
	{
		return CreateSpecification();
	}

	internal float CompareSpecification()
	{
		return 0f;
	}

	float ICargoHost.GetCargo_Area()
	{
		return CompareSpecification();
	}

	internal CargoType ReadSpecification()
	{
		return CargoType.NoCargo;
	}

	CargoType ICargoHost.GetCargo_Type()
	{
		return ReadSpecification();
	}

	internal float DisableSpecification()
	{
		return 0f;
	}

	float ICargoHost.GetCargo_Mass()
	{
		return DisableSpecification();
	}

	public float GetCargo_TowingCapacity()
	{
		return 0f;
	}

	public float GetCargo_MassAvailable()
	{
		return CargoHostHelper.GetAvailableMass(this, OnboardCargo);
	}

	internal bool UpdateSpecification()
	{
		return false;
	}

	bool ICargoHost.GetCargo_ParadropCapable()
	{
		return UpdateSpecification();
	}

	internal bool InsertSpecification()
	{
		return false;
	}

	bool ICargoHost.CanStackCargo()
	{
		return InsertSpecification();
	}

	public float GetCargo_Height()
	{
		return 0f;
	}

	internal int PrepareSpecification(List<Cargo> list_0)
	{
		return ActiveUnit_DockingOps.DEFAULT_CARGO_LOAD_TIME;
	}

	int ICargoHost.GetLoadTime(List<Cargo> list_0)
	{
		return PrepareSpecification(list_0);
	}

	internal int ReflectSpecification(List<Cargo> list_0)
	{
		return ActiveUnit_DockingOps.DEFAULT_CARGO_UNLOAD_TIME;
	}

	int ICargoHost.GetUnloadTime(List<Cargo> list_0)
	{
		return ReflectSpecification(list_0);
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

	[SpecialName]
	public long GetFuelEndurance(Throttle throttle_0, AltBand altBand_0, float? nullable_0, float? nullable_1, Engine engine_0, int int_0)
	{
		if (IsNuke)
		{
			return long.MaxValue;
		}
		if (IsTetheredROV && Fuel_ReadOnly.Count == 0)
		{
			return long.MaxValue;
		}
		if (Type != _SubmarineType.Biologics && Type != _SubmarineType.FalseTarget)
		{
			List<FuelRec> list = new List<FuelRec>(Fuel_ReadOnly.Count);
			foreach (FuelRec item in Fuel_ReadOnly)
			{
				if (item.FuelType == AI.SelectFuelTypeToConsume(engine_0))
				{
					list.Add(item);
				}
			}
			FuelRec fuelRec;
			switch (list.Count)
			{
			case 0:
				return 0L;
			default:
				fuelRec = list.OrderByDescending((FuelRec theRec) => theRec.CurrentQuantity).ElementAtOrDefault(0);
				break;
			case 1:
				fuelRec = list[0];
				break;
			}
			FuelRec fuelRec2 = fuelRec;
			if (throttle_0 == Throttle.FullStop)
			{
				return 2147483647L;
			}
			if (Information.IsNothing(fuelRec2))
			{
				return 0L;
			}
			float num = InstantiateSpecification(throttle_0, altBand_0, nullable_0, nullable_1, engine_0, int_0);
			if (num == 0f)
			{
				if (fuelRec2.CurrentQuantity == 0f)
				{
					return 0L;
				}
				return long.MaxValue;
			}
			return (long)Math.Round(fuelRec2.CurrentQuantity / num);
		}
		return long.MaxValue;
	}

	public override void ActualHorizMovement(float float_0, bool bool_0)
	{
		if (CurrentSpeed == 0f)
		{
			return;
		}
		Longitude_old = GetLongitude();
		Latitude_old = GetLatitude();
		try
		{
			float horizMovementDistanceOnThisTime = GetHorizMovementDistanceOnThisTime(float_0);
			double double_ = 0.0;
			double double_3 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(Longitude_old, Latitude_old, ref double_, ref double_3, horizMovementDistanceOnThisTime, CurrentHeading);
			if (double.IsNaN(double_3))
			{
				double_3 = Latitude_old;
			}
			if (double.IsNaN(double_))
			{
				double_ = Longitude_old;
			}
			if (IsPlatform)
			{
				bool bool_ = false;
				bool bool_2 = true;
				bool bool_3 = true;
				double double_4 = double_3;
				double double_5 = double_;
				int int_ = 0;
				string string_ = "";
				List<ActiveUnit> list_ = null;
				if (CanMoveToThisLocation(double_4, double_5, ref int_, bool_0: false, bool_1: false, bool_2: true, ref bool_2, bool_4: true, ref bool_, null, null, ref list_, 0f, bool_6: false, bool_7: true, ref string_, ref bool_3))
				{
					SetLatitude(null, double_3);
					SetLongitude(null, double_);
					if (ParentScen.MinuteIsChangingOnThisPulse)
					{
						Navigator.GetNearestAccessibleSpotHeading = null;
					}
				}
				else if (bool_ || bool_2)
				{
					if (!ParentScen.MinuteIsChangingOnThisPulse && !Information.IsNothing(Navigator.GetNearestAccessibleSpotHeading))
					{
						CurrentHeading = Navigator.GetNearestAccessibleSpotHeading.Value;
					}
					else
					{
						if (bool_ && Navigator.HasPathfindingPlottedCourse)
						{
							Navigator.ClearPathfindingWaypoints();
						}
						double double_6 = 0.0;
						double double_7 = 0.0;
						if (Navigator.GetNearestAccessibleSpot(double_3, double_, ref double_6, ref double_7, bool_1: false, bool_2: false, bool_3: true, 0f, ref list_, bool_4: false))
						{
							Navigator.GetNearestAccessibleSpotHeading = Math2.PublishClass(GetLatitude(), GetLongitude(), double_6, double_7);
							CurrentHeading = Navigator.GetNearestAccessibleSpotHeading.Value;
							Navigator.ResetTimeToNextPathfinderCheck();
						}
					}
					SetLatitude(null, double_3);
					SetLongitude(null, double_);
				}
				else
				{
					double latitude_old = Latitude_old;
					double longitude_old = Longitude_old;
					int_ = 0;
					string_ = "";
					if (CanMoveToThisLocation(latitude_old, longitude_old, ref int_, bool_0: false, bool_1: false, bool_2: true, ref bool_2, bool_4: true, ref bool_, null, null, ref list_, 0f, bool_6: false, bool_7: true, ref string_, ref bool_3))
					{
						CurrentHeading = Bounce(CurrentHeading, horizMovementDistanceOnThisTime, bool_0: false);
						Geodesic_EdWilliams.CalcPoint_Williams(GetLongitude(), GetLatitude(), ref double_, ref double_3, horizMovementDistanceOnThisTime, CurrentHeading);
						if (ParentScen.MinuteIsChangingOnThisPulse)
						{
							double double_8 = double_3;
							double double_9 = double_;
							int_ = 0;
							bool bool_4 = false;
							string_ = "";
							bool bool_5 = false;
							double double_10 = 0.0;
							double double_2 = 0.0;
							if (!CanMoveToThisLocation(double_8, double_9, ref int_, bool_0: false, bool_1: false, bool_2: true, ref bool_4, bool_4: true, ref bool_, null, null, ref list_, 0f, bool_6: false, bool_7: false, ref string_, ref bool_5) && Navigator.GetNearestAccessibleSpot(GetLatitude(), GetLongitude(), ref double_10, ref double_2, bool_1: false, bool_2: false, bool_3: true, 0f, ref list_, bool_4: false))
							{
								double_3 = double_10;
								double_ = double_2;
							}
							Navigator.GetNearestAccessibleSpotHeading = null;
						}
					}
					else if (Navigator.GetNearestAccessibleSpot(GetLatitude(), GetLongitude(), ref double_3, ref double_, bool_1: false, bool_2: false, bool_3: true, 0f, ref list_, bool_4: false))
					{
						Navigator.GetNearestAccessibleSpotHeading = Math2.PublishClass(GetLatitude(), GetLongitude(), double_3, double_);
						CurrentHeading = Navigator.GetNearestAccessibleSpotHeading.Value;
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
			if (!bool_0)
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
}
