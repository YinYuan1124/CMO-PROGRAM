using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Vehicle : Platform, ICargoClient, ICargoHost, IMobileGroundUnit
{
	public enum TractionType
	{
		Undefined = 0,
		Wheeled = 4001,
		HalfTrack = 4002,
		Tracked = 4003,
		Legged = 4004
	}

	[CompilerGenerated]
	private sealed class TestMerchantService
	{
		public FuelRec._FuelType theType;

		internal bool WriteInterruptibleParam(FuelRec theFuelrec)
		{
			return theFuelrec.FuelType == theType;
		}
	}

	public int CombatSystemGen;

	public float Width;

	public double Area;

	public float Mass;

	public int MastHeight;

	public int MissileDefense;

	public bool HasAimpoints;

	public int MaxSeaState;

	public TractionType TractionMode;

	public int Cargo_Crew;

	public float Cargo_Area;

	public CargoType Cargo_Type;

	public float Cargo_Mass;

	public bool Cargo_ParadropCapable;

	public int Cargo_Capacity_Crew;

	public float Cargo_Capacity_Area;

	public CargoType Cargo_Capacity_Type;

	public float Cargo_Capacity_Mass;

	public float Cargo_Capacity_Towing;

	public Cargo Cargo;

	private Vehicle_Navigator m_InitializerProxy;

	private Vehicle_AI roleProxy;

	private Vehicle_Kinematics _FactoryProxy;

	private Vehicle_Sensory attributeProxy;

	private Vehicle_Weaponry _EventProxy;

	private Vehicle_CommStuff m_GlobalProxy;

	private Vehicle_Damage workerProxy;

	private bool? accountProxy;

	private bool? _StateProxy;

	public bool IsAmphibious;

	protected bool? _IsAmphibiousSeaworthy;

	private Engine authenticationProxy;

	private IMobileGroundUnit._MobileUnitCategory? paramsProxy;

	private GlobalVariables.ArmorRating _InfoProxy;

	private static Scenario m_HelperProxy;

	public new bool IsOutOfFuel
	{
		get
		{
			if (!_IsAmphibiousSeaworthy.HasValue)
			{
				_IsAmphibiousSeaworthy = false;
				if (IsAmphibious)
				{
					foreach (Engine item in Propulsion)
					{
						if (item.CanBeUsedOnWater())
						{
							_IsAmphibiousSeaworthy = true;
						}
					}
				}
			}
			return _IsAmphibiousSeaworthy.Value;
		}
	}

	public override bool RepresentsMobileGroundUnit => true;

	public DockFacility.DockingPhysicalSize DockingPhysicalSize
	{
		get
		{
			if (IsAmphibious)
			{
				return DBFunctions.DisableList(Length);
			}
			return DockFacility.DockingPhysicalSize.None;
		}
	}

	public Engine PrimaryEngine
	{
		get
		{
			if (authenticationProxy == null)
			{
				AI.ForgotWatcher();
			}
			return authenticationProxy;
		}
		set
		{
			authenticationProxy = value;
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
			float currentSpeed = CurrentSpeed;
			if (currentSpeed < 10f)
			{
				return (Ship.ShipWakeSize)Math.Max(0, (int)(VisualSizeClass - 1));
			}
			if (currentSpeed < 20f)
			{
				return (Ship.ShipWakeSize)VisualSizeClass;
			}
			if (currentSpeed < 30f)
			{
				return (Ship.ShipWakeSize)Math.Min(5, (int)(VisualSizeClass + 1));
			}
			if (currentSpeed < 40f)
			{
				return (Ship.ShipWakeSize)Math.Min(5, (int)(VisualSizeClass + 2));
			}
			return (Ship.ShipWakeSize)Math.Min(5, (int)(VisualSizeClass + 3));
		}
	}

	public override float FlatSurfaceArea_m2 => (float)Area;

	public override bool IsPlatform => true;

	public override GlobalVariables.ActiveUnitType UnitType => GlobalVariables.ActiveUnitType.Vehicle;

	public bool CanFireOnTheMove
	{
		get
		{
			switch (MobileUnitCategory)
			{
			default:
				return true;
			case IMobileGroundUnit._MobileUnitCategory.Artillery_Gun:
			case IMobileGroundUnit._MobileUnitCategory.Artillery_Towed:
			case IMobileGroundUnit._MobileUnitCategory.Artillery_SSM:
			case IMobileGroundUnit._MobileUnitCategory.AAA:
			case IMobileGroundUnit._MobileUnitCategory.SAM:
			case IMobileGroundUnit._MobileUnitCategory.Surveillance:
				return false;
			}
		}
	}

	public override Throttle MaxPossibleThrottleSetting
	{
		get
		{
			if (base.IsFixedFacility)
			{
				return Throttle.FullStop;
			}
			return Throttle.Flank;
		}
	}

	public override CommDevice[] Comms_ReadOnly
	{
		get
		{
			CommDevice[] result = null;
			try
			{
				if (HasAimpoints)
				{
					CommDevice[] gparam_ = null;
					int num = Mounts.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						Mount mount = Mounts[i];
						if (mount.Status != 0)
						{
							continue;
						}
						int num2 = mount.CommDevices.Length - 1;
						for (int j = 0; j <= num2; j++)
						{
							if (Information.IsNothing(gparam_))
							{
								gparam_ = AssetWatcher();
							}
							CommDevice commDevice = mount.CommDevices[j];
							commDevice.IsCommsInMount = true;
							ArrayExtensions.Add(ref gparam_, commDevice);
						}
					}
					if (Information.IsNothing(gparam_))
					{
						result = _Comms;
						return result;
					}
					result = gparam_;
					return result;
				}
				result = base.Comms_ReadOnly;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100542", "");
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

	public new Vehicle_Navigator Navigator => m_InitializerProxy;

	public new Vehicle_AI AI
	{
		get
		{
			if (Information.IsNothing(roleProxy))
			{
				ActiveUnit activeUnit_ = this;
				roleProxy = new Vehicle_AI(ref activeUnit_);
			}
			return roleProxy;
		}
	}

	public new Vehicle_Kinematics Kinematics
	{
		get
		{
			if (Information.IsNothing(_FactoryProxy))
			{
				ActiveUnit activeUnit_ = this;
				_FactoryProxy = new Vehicle_Kinematics(ref activeUnit_);
			}
			return _FactoryProxy;
		}
	}

	public new Vehicle_Sensory Sensory
	{
		get
		{
			if (Information.IsNothing(attributeProxy))
			{
				ActiveUnit activeUnit_ = this;
				attributeProxy = new Vehicle_Sensory(ref activeUnit_);
			}
			return attributeProxy;
		}
	}

	public new Vehicle_Weaponry Weaponry
	{
		get
		{
			if (Information.IsNothing(_EventProxy))
			{
				ActiveUnit activeUnit_ = this;
				_EventProxy = new Vehicle_Weaponry(ref activeUnit_);
			}
			return _EventProxy;
		}
	}

	public new Vehicle_CommStuff CommStuff
	{
		get
		{
			if (Information.IsNothing(m_GlobalProxy))
			{
				ActiveUnit activeUnit_ = this;
				m_GlobalProxy = new Vehicle_CommStuff(ref activeUnit_);
			}
			return m_GlobalProxy;
		}
	}

	public new Vehicle_Damage Damage
	{
		get
		{
			if (Information.IsNothing(workerProxy))
			{
				ActiveUnit activeUnit_ = this;
				workerProxy = new Vehicle_Damage(ref activeUnit_);
			}
			return workerProxy;
		}
	}

	public override bool IsUnderground
	{
		get
		{
			if (!accountProxy.HasValue)
			{
				accountProxy = base.IsUnderground;
			}
			return accountProxy.Value;
		}
	}

	public override bool IsUnderwater
	{
		get
		{
			if (!_StateProxy.HasValue)
			{
				_StateProxy = base.IsUnderwater;
			}
			return _StateProxy.Value;
		}
	}

	public override string AnnexAndDBID => "GroundUnit_" + Conversions.ToString(DBID);

	public override GlobalVariables.TargetVisualSizeClass VisualSizeClass
	{
		get
		{
			float cargo_Area = Cargo_Area;
			if (cargo_Area <= 50f)
			{
				if (cargo_Area <= 25f)
				{
					if (cargo_Area <= 15f)
					{
						if (cargo_Area <= 10f)
						{
							if (cargo_Area <= 5f)
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

	public IMobileGroundUnit._MobileUnitCategory MobileUnitCategory
	{
		get
		{
			return paramsProxy.Value;
		}
		set
		{
			paramsProxy = value;
		}
	}

	public override ActiveUnit_DockingOps.ResupplyCapacity DesignatedSupplier
	{
		get
		{
			if (!_DesignatedSupplier.HasValue)
			{
				if (MobileUnitCategory == IMobileGroundUnit._MobileUnitCategory.Supply)
				{
					_DesignatedSupplier = ActiveUnit_DockingOps.ResupplyCapacity.FuelAndMaterial;
				}
				else
				{
					_DesignatedSupplier = ActiveUnit_DockingOps.ResupplyCapacity.None;
				}
			}
			return _DesignatedSupplier.Value;
		}
		set
		{
			_DesignatedSupplier = value;
		}
	}

	public GlobalVariables.ArmorRating Armor_General
	{
		get
		{
			return _InfoProxy;
		}
		set
		{
			_InfoProxy = value;
		}
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		if (GetUnitSide() == null)
		{
			return;
		}
		xmlWriter_0.WriteStartElement("Vehicle");
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
			if (TimeUnderway != 0f)
			{
				xmlWriter_0.WriteElementString("TUW", Conversions.ToString(TimeUnderway));
			}
			xmlWriter_0.WriteElementString("CH", XmlConvert.ToString(CurrentHeading));
			xmlWriter_0.WriteElementString("CS", XmlConvert.ToString(CurrentSpeed));
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
			xmlWriter_0.WriteElementString("Side", GetUnitSide().Name);
			if (!string.IsNullOrEmpty(Message))
			{
				xmlWriter_0.WriteElementString("Message", Message);
			}
			xmlWriter_0.WriteElementString("DBID", DBID.ToString());
			xmlWriter_0.WriteElementString("DH", XmlConvert.ToString(DesiredHeading));
			xmlWriter_0.WriteElementString("DS", XmlConvert.ToString(DesiredSpeed));
			xmlWriter_0.WriteElementString("DT", ((byte)DesiredTurnRate).ToString());
			xmlWriter_0.WriteElementString("DTN", ((byte)DesiredTurnRate_Navigation).ToString());
			if (_Proficiency.HasValue)
			{
				xmlWriter_0.WriteElementString("Prof", ((int)_Proficiency.Value).ToString());
			}
			xmlWriter_0.WriteElementString("ThrottleSetting", ((byte)ThrottleSetting).ToString());
			if (Sensors_ReadOnly().Length != 0)
			{
				xmlWriter_0.WriteStartElement("Sensors");
				Sensor[] sensors = _Sensors;
				Sensor[] array = sensors;
				foreach (Sensor sensor in array)
				{
					xmlWriter_0.WriteRaw(sensor.ToXML(hashSet_0));
				}
				xmlWriter_0.WriteEndElement();
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
				foreach (Engine item in Propulsion)
				{
					xmlWriter_0.WriteRaw(item.ToXML(hashSet_0));
				}
				xmlWriter_0.WriteEndElement();
			}
			if (_Fuel.Count > 0)
			{
				xmlWriter_0.WriteStartElement("Fuel");
				foreach (FuelRec item2 in _Fuel)
				{
					xmlWriter_0.WriteRaw(item2.ToXML());
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
			if (Magazines.Count() > 0)
			{
				xmlWriter_0.WriteStartElement("Magazines");
				Magazine[] magazines = Magazines;
				Magazine[] array3 = magazines;
				foreach (Magazine magazine in array3)
				{
					xmlWriter_0.WriteRaw(magazine.ToXML(hashSet_0, ParentScen));
				}
				xmlWriter_0.WriteEndElement();
			}
			if (OnboardCargo.Count() > 0)
			{
				xmlWriter_0.WriteStartElement("OnboardCargo");
				Cargo[] onboardCargo = OnboardCargo;
				Cargo[] array4 = onboardCargo;
				foreach (Cargo cargo in array4)
				{
					xmlWriter_0.WriteRaw(cargo.ToXML(hashSet_0, ParentScen));
				}
				xmlWriter_0.WriteEndElement();
			}
			XmlWriter obj = xmlWriter_0;
			byte status = (byte)_Status;
			obj.WriteElementString("Status", status.ToString());
			XmlWriter obj3 = xmlWriter_0;
			status = (byte)_FuelState;
			obj3.WriteElementString("FuelState", status.ToString());
			XmlWriter obj4 = xmlWriter_0;
			status = (byte)_WeaponState;
			obj4.WriteElementString("WeaponState", status.ToString());
			XmlWriter obj5 = xmlWriter_0;
			status = (byte)predicateVal;
			obj5.WriteElementString("SBR", status.ToString());
			XmlWriter obj6 = xmlWriter_0;
			status = (byte)_SingletonVal;
			obj6.WriteElementString("SBED", status.ToString());
			XmlWriter obj7 = xmlWriter_0;
			status = (byte)_RecordVal;
			obj7.WriteElementString("SBEO", status.ToString());
			XmlWriter obj8 = xmlWriter_0;
			status = (byte)comparatorVal;
			obj8.WriteElementString("FSBR", status.ToString());
			xmlWriter_0.WriteElementString("SBR_TF", XmlConvert.ToString(_CreatorVal));
			XmlWriter obj9 = xmlWriter_0;
			status = (byte)_TemplateVal;
			obj9.WriteElementString("SBR_ThrottleSetting", status.ToString());
			xmlWriter_0.WriteElementString("SBED_TF", XmlConvert.ToString(tagVal));
			XmlWriter obj10 = xmlWriter_0;
			status = (byte)fieldVal;
			obj10.WriteElementString("SBED_ThrottleSetting", status.ToString());
			xmlWriter_0.WriteElementString("SBEO_TF", XmlConvert.ToString(m_PageVal));
			XmlWriter obj2 = xmlWriter_0;
			status = (byte)m_RulesVal;
			obj2.WriteElementString("SBEO_ThrottleSetting", status.ToString());
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
			Doctrine.ToXML(ref xmlWriter_0, ref ParentScen);
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
			if (AirOps != null)
			{
				_AirOps.ToXML(ref xmlWriter_0, ref hashSet_0);
			}
			if (DockingOps != null)
			{
				ActiveUnit_DockingOps.ToXML(DockingOps, ref xmlWriter_0, ref hashSet_0);
			}
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
			exception_?.Data.Add("Error at 100540", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private Vehicle()
		: base(ref m_HelperProxy)
	{
		TractionMode = TractionType.Undefined;
		Cargo = new Cargo(this);
		ActiveUnit activeUnit_ = this;
		m_InitializerProxy = new Vehicle_Navigator(ref activeUnit_);
		IsAmphibious = false;
		IsMobileGroundUnit = true;
		IsVehicle = true;
	}

	public static List<Vehicle> SpawnVehicleFromCargoMountList(List<Mount> list_0, Scenario scenario_0, Side side_0)
	{
		IEnumerable<(IMobileGroundUnit._MobileUnitCategory, IEnumerable<Mount>)> enumerable = list_0.GroupBy((Mount m) => m.MobileUnitCategory, (Mount m) => m, (IMobileGroundUnit._MobileUnitCategory MobileUnitCategory, IEnumerable<Mount> ItAnonymous) => (MobileUnitCategory: MobileUnitCategory, ItAnonymous: ItAnonymous));
		List<Vehicle> list = new List<Vehicle>();
		foreach (var item in enumerable)
		{
			string text = "";
			int int_;
			string text2;
			switch (item.Item1)
			{
			case IMobileGroundUnit._MobileUnitCategory.Armor:
				int_ = 2983;
				text2 = "Armor";
				break;
			case IMobileGroundUnit._MobileUnitCategory.Infantry:
				int_ = 2987;
				text2 = "Inf";
				break;
			case IMobileGroundUnit._MobileUnitCategory.AAA:
				int_ = 2989;
				text2 = "AAA";
				break;
			case IMobileGroundUnit._MobileUnitCategory.Artillery_Gun:
				int_ = 2985;
				text2 = "Arty";
				break;
			case IMobileGroundUnit._MobileUnitCategory.SAM:
				int_ = 2988;
				text2 = "SAM";
				break;
			default:
				int_ = 2990;
				text2 = "登陆支队";
				break;
			case IMobileGroundUnit._MobileUnitCategory.MechInfantry:
				int_ = 2984;
				text2 = "Mech Inf";
				break;
			case IMobileGroundUnit._MobileUnitCategory.Surveillance:
			case IMobileGroundUnit._MobileUnitCategory.Recon:
				int_ = 2986;
				text2 = "Recon";
				break;
			}
			Vehicle vehicle = null;
			vehicle = scenario_0.AddNewVehicle(side_0, int_, text + text2 + " #" + Conversions.ToString(scenario_0.UnitsAutoIncrement), 0.0, 0.0, bool_0: true);
			vehicle.Mounts.Clear();
			foreach (Mount item2 in item.Item2)
			{
				vehicle.Mounts.Add(item2);
				item2.ParentPlatform = vehicle;
			}
			Sensor[] array = vehicle.Sensors_ReadOnly();
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				array[i].ParentPlatform = vehicle;
			}
			ArrayExtensions.Clear(ref vehicle.Magazines);
			list.Add(vehicle);
		}
		return list;
	}

	public new static Vehicle FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		Vehicle vehicle = null;
		try
		{
			vehicle = StartWatcher(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0, scenario_0.LoadStockUnits);
			return vehicle;
		}
		catch (PlatformComponentNotFoundException projectError)
		{
			ProjectData.SetProjectError(projectError);
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			ConcurrentDictionary<string, ScenarioObject> obj = concurrentDictionary_0;
			ScenarioObject value = vehicle;
			obj.TryRemove(innerText, out value);
			vehicle = StartWatcher(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0, bool_0: true);
			string text = "";
			if (vehicle.IsGroupMember())
			{
				text = "(member of group: [" + vehicle.GetParentGroup().Name + "])";
			}
			scenario_0.LoadingNotices.Add("The following Vehicle:[" + vehicle.Name + "]" + text + " failed to shallow-rebuild because of a component missing. The Vehicle was instead deep-rebuilt, and instantiated in its pristine DB-stock condition. All customizations present in the Vehicle's components (damaged components, weapon additions/removals etc. etc.) have been lost. Please re-apply any necessary customizations either manually or using an SBR script.");
			ProjectData.ClearProjectError();
			return vehicle;
		}
	}

	private static Vehicle StartWatcher(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0, bool bool_0)
	{
		try
		{
			Vehicle vehicle_ = new Vehicle();
			vehicle_.ParentScen = scenario_0;
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (concurrentDictionary_0.ContainsKey(innerText))
			{
				return (Vehicle)concurrentDictionary_0[innerText];
			}
			vehicle_.ObjectID_Set(innerText);
			if (xmlNode_0.ChildNodes.Count == 1)
			{
				scenario_0.UnitsForLateInstantiation.Add(xmlNode_0);
				return vehicle_;
			}
			concurrentDictionary_0.TryAdd(vehicle_.ObjectID, vehicle_);
			int num = Conversions.ToInteger(Misc.StartRequest(xmlNode_0.ChildNodes, "DBID").InnerText);
			try
			{
				DBFunctions.GetVehicle(ref scenario_0, ref vehicle_, num, bool_0);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ConcurrentDictionary<string, ScenarioObject> obj = concurrentDictionary_0;
				string objectID = vehicle_.ObjectID;
				ScenarioObject value = vehicle_;
				obj.TryRemove(objectID, out value);
				scenario_0.LoadingNotices.Add("Vehicle with Database ID " + Conversions.ToString(num) + "在数据库中缺少因此未能加载。");
				ProjectData.ClearProjectError();
				return null;
			}
			if (bool_0)
			{
				vehicle_.RegisterIssuer(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0);
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
						XmlNode xmlNode = (XmlNode)enumerator.Current;
						vehicle_.CommonFromXML(xmlNode);
						switch (xmlNode.Name)
						{
						case "Comms":
							try
							{
								enumerator7 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator7.MoveNext())
								{
									XmlNode xmlNode_8 = (XmlNode)enumerator7.Current;
									CommDevice commDevice = CommDevice.FromXML(ref xmlNode_8, ref concurrentDictionary_0, vehicle_);
									vehicle_.AddCommDevice(commDevice);
									commDevice.ParentPlatform = vehicle_;
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
						case "OnboardCargo":
							try
							{
								enumerator12 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator12.MoveNext())
								{
									XmlNode xmlNode_7 = (XmlNode)enumerator12.Current;
									Cargo cargo = Cargo.FromXML(ref xmlNode_7, ref concurrentDictionary_0, scenario_0, vehicle_);
									ArrayExtensions.Add(ref vehicle_.OnboardCargo, cargo);
									cargo.ParentPlatform = vehicle_;
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
								enumerator9 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator9.MoveNext())
								{
									XmlNode xmlNode_6 = (XmlNode)enumerator9.Current;
									FuelRec item = FuelRec.FromXML(ref xmlNode_6, ref concurrentDictionary_0);
									vehicle_._Fuel.Add(item);
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
								enumerator8 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator8.MoveNext())
								{
									XmlNode xmlNode_5 = (XmlNode)enumerator8.Current;
									DockFacility dockFacility = DockFacility.FromXML(ref xmlNode_5, ref concurrentDictionary_0, ref scenario_0);
									vehicle_.AddDockFacility(dockFacility);
									dockFacility.ParentPlatform = vehicle_;
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
						case "Sensors":
							try
							{
								enumerator2 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									Sensor sensor = Sensor.FromXML((XmlNode)enumerator2.Current, concurrentDictionary_0, vehicle_);
									ArrayExtensions.Add(ref vehicle_._Sensors, sensor);
									sensor.ParentPlatform = vehicle_;
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
								enumerator13 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator13.MoveNext())
								{
									XmlNode xmlNode_4 = (XmlNode)enumerator13.Current;
									ActiveUnit activeUnit_ = vehicle_;
									Engine engine = Engine.FromXML(ref xmlNode_4, ref concurrentDictionary_0, ref activeUnit_);
									vehicle_.Propulsion.Add(engine);
									engine.ParentPlatform = vehicle_;
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
								enumerator6 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator6.MoveNext())
								{
									XmlNode xmlNode_3 = (XmlNode)enumerator6.Current;
									AirFacility airFacility = AirFacility.FromXML(ref xmlNode_3, ref concurrentDictionary_0, ref scenario_0);
									vehicle_.AddAirFacility(airFacility);
									airFacility.ParentPlatform = vehicle_;
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
								enumerator10 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator10.MoveNext())
								{
									XmlNode xmlNode_2 = (XmlNode)enumerator10.Current;
									Magazine magazine = Magazine.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref scenario_0);
									vehicle_.AddSharedMagazine(magazine, bool_0: false);
									magazine.ParentPlatform = vehicle_;
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
								enumerator11 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator11.MoveNext())
								{
									XmlNode xmlNode_ = (XmlNode)enumerator11.Current;
									Mount mount = Mount.FromXML(ref xmlNode_, ref concurrentDictionary_0, vehicle_);
									if (mount != null)
									{
										vehicle_.Mounts.Add(mount);
										mount.ParentPlatform = vehicle_;
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
					XmlNode xmlNode_9 = (XmlNode)enumerator3.Current;
					switch (xmlNode_9.Name)
					{
					case "FSBR":
						vehicle_.comparatorVal = (_ActiveUnitFuelState)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "Status":
						if (Versioned.IsNumeric(xmlNode_9.InnerText))
						{
							vehicle_.Status = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_9.InnerText);
						}
						else
						{
							vehicle_.Status = (_ActiveUnitStatus)Enum.Parse(typeof(_ActiveUnitStatus), xmlNode_9.InnerText, ignoreCase: true);
						}
						if (vehicle_.Status == (_ActiveUnitStatus)9)
						{
							vehicle_.Status = _ActiveUnitStatus.RTB;
						}
						break;
					case "AMP_OC_Speed":
						vehicle_.m_PrototypeVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "Name":
						vehicle_.Name = xmlNode_9.InnerText;
						break;
					case "SBED_Altitude_TF":
						vehicle_.m_MockVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "DTN":
					case "DesiredTurnRate_Navigation":
						vehicle_.DesiredTurnRate_Navigation = (Waypoint.TurnRateCategory)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "AI":
					case "Vehicle_AI":
					{
						Vehicle vehicle8 = vehicle_;
						ActiveUnit activeUnit_9 = vehicle_;
						vehicle8.roleProxy = Vehicle_AI.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_9);
						break;
					}
					case "LatLR":
						vehicle_.Latitude_LastReported = XmlConvert.ToDouble(xmlNode_9.InnerText.Replace(",", "."));
						break;
					case "TUW":
						vehicle_.TimeUnderway = XmlConvert.ToSingle(xmlNode_9.InnerText.Replace(",", "."));
						break;
					case "FuelState":
						vehicle_._FuelState = (_ActiveUnitFuelState)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "Vehicle_Kinematics":
					case "Kinematics":
						ActiveUnit_Kinematics.FromXML(xmlNode_9, concurrentDictionary_0, vehicle_);
						break;
					case "Vehicle_Damage":
					case "Damage":
					{
						Vehicle vehicle7 = vehicle_;
						ActiveUnit activeUnit_8 = vehicle_;
						vehicle7.workerProxy = Vehicle_Damage.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_8);
						break;
					}
					case "COA":
						vehicle_.ChanceOfAppearance = Conversions.ToInteger(xmlNode_9.InnerText);
						break;
					case "DamagePts":
						if (!bool_0)
						{
							vehicle_.SetDamagePts(bool_0: false, null, XmlConvert.ToSingle(xmlNode_9.InnerText));
						}
						break;
					case "AMP_OC_DAO":
						vehicle_._ExporterVal = Conversions.ToBoolean(xmlNode_9.InnerText);
						break;
					case "SBED_Altitude":
						vehicle_.m_MappingVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "OldDamagePercent":
						vehicle_.utilsVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "DH":
					case "DesiredHeading":
						vehicle_.SetDesiredHeading(TurnRate.Max, XmlConvert.ToSingle(xmlNode_9.InnerText));
						break;
					case "AirOps":
					case "ActiveUnit_AirOps":
					{
						Vehicle vehicle6 = vehicle_;
						ActiveUnit activeUnit_7 = vehicle_;
						vehicle6._AirOps = ActiveUnit_AirOps.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_7);
						break;
					}
					case "SBR":
						vehicle_.predicateVal = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "SBR_Altitude_TF":
						vehicle_.setterVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "ThrottleSetting":
						switch (xmlNode_9.InnerText)
						{
						default:
							vehicle_.ThrottleSetting = (Throttle)Conversions.ToByte(xmlNode_9.InnerText);
							break;
						case "Loiter":
							vehicle_.ThrottleSetting = Throttle.Loiter;
							break;
						case "FullStop":
							vehicle_.ThrottleSetting = Throttle.FullStop;
							break;
						case "Full":
							vehicle_.ThrottleSetting = Throttle.Full;
							break;
						case "Flank":
							vehicle_.ThrottleSetting = Throttle.Flank;
							break;
						case "Cruise":
							vehicle_.ThrottleSetting = Throttle.Cruise;
							break;
						}
						break;
					case "Doctrine":
						vehicle_.Doctrine = Doctrine.FromXML(ref xmlNode_9, vehicle_);
						break;
					case "ActiveEnterAreaTriggers":
						try
						{
							enumerator4 = xmlNode_9.ChildNodes.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								string innerText3 = ((XmlNode)enumerator4.Current).InnerText;
								vehicle_.ActiveEnterAreaTriggers.Add(innerText3);
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
						switch (xmlNode_9.InnerText)
						{
						default:
							vehicle_.fieldVal = (Throttle)Conversions.ToByte(xmlNode_9.InnerText);
							break;
						case "Loiter":
							vehicle_.fieldVal = Throttle.Loiter;
							break;
						case "FullStop":
							vehicle_.fieldVal = Throttle.FullStop;
							break;
						case "Full":
							vehicle_.fieldVal = Throttle.Full;
							break;
						case "Flank":
							vehicle_.fieldVal = Throttle.Flank;
							break;
						case "Cruise":
							vehicle_.fieldVal = Throttle.Cruise;
							break;
						}
						break;
					case "SBEO_TF":
						vehicle_.m_PageVal = Conversions.ToBoolean(xmlNode_9.InnerText);
						break;
					case "WeaponState":
						vehicle_._WeaponState = (_ActiveUnitWeaponState)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "Prof":
						vehicle_.Proficiency = (GlobalVariables.ProficiencyLevel)Conversions.ToInteger(xmlNode_9.InnerText);
						break;
					case "CommStuff":
					case "Vehicle_CommStuff":
					{
						Vehicle vehicle5 = vehicle_;
						ActiveUnit activeUnit_6 = vehicle_;
						vehicle5.m_GlobalProxy = Vehicle_CommStuff.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_6);
						break;
					}
					case "AMP_OC_DSO":
						vehicle_._VisitorVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "SBED_TF":
						vehicle_.tagVal = Conversions.ToBoolean(xmlNode_9.InnerText);
						break;
					case "OODA_D":
						vehicle_.HasCustomOODA = true;
						vehicle_.m_TokenVal = Conversions.ToShort(xmlNode_9.InnerText);
						break;
					case "OODA_E":
						vehicle_.HasCustomOODA = true;
						vehicle_._ResolverVal = Conversions.ToShort(xmlNode_9.InnerText);
						break;
					case "AssignedMission":
						if (xmlNode_9.HasChildNodes)
						{
							XmlNode xmlNode4 = xmlNode_9.ChildNodes[0];
							vehicle_._AssignedMissionOrPackage_ID = xmlNode4.InnerText;
						}
						break;
					case "Latitude_UnitEntersAreaCheck":
						vehicle_.Latitude__UnitEntersAreaCheck = XmlConvert.ToDouble(xmlNode_9.InnerText);
						break;
					case "EFSAR":
						vehicle_.EligibleForSAR = Conversions.ToBoolean(xmlNode_9.InnerText);
						break;
					case "OODA_T":
						vehicle_.HasCustomOODA = true;
						vehicle_._IndexerVal = Conversions.ToShort(xmlNode_9.InnerText);
						break;
					case "ActiveRemainAreaTriggers":
					{
						string key = null;
						DateTime result = DateTime.MinValue;
						try
						{
							enumerator5 = xmlNode_9.ChildNodes.GetEnumerator();
							while (enumerator5.MoveNext())
							{
								XmlNode xmlNode3 = (XmlNode)enumerator5.Current;
								if (Operators.CompareString(xmlNode3.Name, "RemainAreaTrigger", TextCompare: false) == 0)
								{
									key = xmlNode3.InnerText;
									result = DateTime.MinValue;
									continue;
								}
								if (DateTime.TryParse(xmlNode3.InnerText, CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
								{
									vehicle_.ActiveRemainAreaTriggers.Add(key, result);
									continue;
								}
								string innerText2 = xmlNode3.InnerText;
								long result2 = 0L;
								if (long.TryParse(innerText2, out result2))
								{
									result = DateTime.FromBinary(Conversions.ToLong(xmlNode3.InnerText));
									vehicle_.ActiveRemainAreaTriggers.Add(key, result);
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
					case "Vehicle_Sensory":
					case "Sensory":
					{
						Vehicle vehicle4 = vehicle_;
						ActiveUnit activeUnit_5 = vehicle_;
						vehicle4.attributeProxy = Vehicle_Sensory.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_5);
						break;
					}
					case "CustomIcon":
						vehicle_.CustomIcon = xmlNode_9.InnerText;
						break;
					case "Side":
						vehicle_._SideName = xmlNode_9.InnerText;
						break;
					case "Longitude":
					case "Lon":
						vehicle_.SetLongitude(null, XmlConvert.ToDouble(xmlNode_9.InnerText.Replace(",", ".")));
						break;
					case "SBEO_Altitude":
						vehicle_.regVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "DS":
					case "DesiredSpeed":
						vehicle_.DesiredSpeed = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "IBPU":
						vehicle_.IsBeingPickedUp = Conversions.ToBoolean(xmlNode_9.InnerText);
						break;
					case "SBEO_Altitude_TF":
						vehicle_.paramVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "AssignedTaskPool":
						if (xmlNode_9.HasChildNodes)
						{
							XmlNode xmlNode2 = xmlNode_9.ChildNodes[0];
							vehicle_._AssignedTaskPool_ID = xmlNode2.InnerText;
						}
						break;
					case "Latitude":
					case "Lat":
						vehicle_.SetLatitude(null, XmlConvert.ToDouble(xmlNode_9.InnerText.Replace(",", ".")));
						break;
					case "SBR_ThrottleSetting":
						switch (xmlNode_9.InnerText)
						{
						default:
							vehicle_._TemplateVal = (Throttle)Conversions.ToByte(xmlNode_9.InnerText);
							break;
						case "Loiter":
							vehicle_._TemplateVal = Throttle.Loiter;
							break;
						case "FullStop":
							vehicle_._TemplateVal = Throttle.FullStop;
							break;
						case "Full":
							vehicle_._TemplateVal = Throttle.Full;
							break;
						case "Flank":
							vehicle_._TemplateVal = Throttle.Flank;
							break;
						case "Cruise":
							vehicle_._TemplateVal = Throttle.Cruise;
							break;
						}
						break;
					case "Message":
						vehicle_.Message = xmlNode_9.InnerText;
						break;
					case "SBR_Altitude":
						vehicle_._ItemVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "DockingOps":
					case "ActiveUnit_DockingOps":
					{
						Vehicle vehicle3 = vehicle_;
						ActiveUnit activeUnit_4 = vehicle_;
						vehicle3._DockingOps = ActiveUnit_DockingOps.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_4);
						break;
					}
					case "SBEO":
						vehicle_._RecordVal = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "LonLR":
						vehicle_.Longitude_LastReported = XmlConvert.ToDouble(xmlNode_9.InnerText.Replace(",", "."));
						break;
					case "AMP_OC":
						vehicle_.m_AttrVal = Conversions.ToBoolean(xmlNode_9.InnerText);
						break;
					case "CS":
					case "CurrentSpeed":
						vehicle_.CurrentSpeed = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "SBR_TF":
						vehicle_._CreatorVal = Conversions.ToBoolean(xmlNode_9.InnerText);
						break;
					case "Vehicle_Navigator":
					case "Navigator":
					{
						Vehicle vehicle2 = vehicle_;
						ActiveUnit activeUnit_3 = vehicle_;
						vehicle2.m_InitializerProxy = Vehicle_Navigator.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_3);
						break;
					}
					case "SBED":
						vehicle_._SingletonVal = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "DT":
					case "DesiredTurnRate":
						vehicle_.DesiredTurnRate = (TurnRate)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "ParentGroup":
						vehicle_._ParentGroup_ID = xmlNode_9.InnerText;
						break;
					case "Vehicle_Weaponry":
					case "Weaponry":
					{
						Vehicle vehicle = vehicle_;
						ActiveUnit activeUnit_2 = vehicle_;
						vehicle._EventProxy = Vehicle_Weaponry.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_2);
						break;
					}
					case "SBEO_ThrottleSetting":
						switch (xmlNode_9.InnerText)
						{
						default:
							vehicle_.m_RulesVal = (Throttle)Conversions.ToByte(xmlNode_9.InnerText);
							break;
						case "Loiter":
							vehicle_.m_RulesVal = Throttle.Loiter;
							break;
						case "FullStop":
							vehicle_.m_RulesVal = Throttle.FullStop;
							break;
						case "Full":
							vehicle_.m_RulesVal = Throttle.Full;
							break;
						case "Flank":
							vehicle_.m_RulesVal = Throttle.Flank;
							break;
						case "Cruise":
							vehicle_.m_RulesVal = Throttle.Cruise;
							break;
						}
						break;
					case "CH":
					case "CurrentHeading":
						vehicle_.CurrentHeading = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "IsAD":
					case "IsAutoDetectable":
						vehicle_.SetIsAutoDetectable(null, Conversions.ToBoolean(xmlNode_9.InnerText));
						break;
					case "Longitude_UnitEntersAreaCheck":
						vehicle_.Longitude__UnitEntersAreaCheck = XmlConvert.ToDouble(xmlNode_9.InnerText);
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
			vehicle_.SetCurrentAltitude(bool_0: false, vehicle_.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, vehicle_.ParentScen));
			vehicle_.EvaluateIfDumb();
			return vehicle_;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100541", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public override void PostDeserializationHousekeeping_General(ref Scenario scenario_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, List<ActiveUnit> list_0, bool bool_0)
	{
		base.PostDeserializationHousekeeping_General(ref scenario_0, concurrentDictionary_0, list_0, bool_0);
		ActiveUnit_DockingOps.PostDeserializationHousekeeping(DockingOps, ref scenario_0, concurrentDictionary_0, bool_0);
		if (DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
		{
			SetCurrentAltitude(bool_0: false, GetLandElevation(bool_0: false, bool_1: false, bool_2: true, scenario_0));
		}
	}

	private CommDevice[] AssetWatcher()
	{
		CommDevice[] array = new CommDevice[_Comms.Length - 1 + 1];
		if (_Comms.Length != 0)
		{
			Array.Copy(_Comms, array, _Comms.Length);
		}
		return array;
	}

	[SpecialName]
	public override int GetMastHeight_Radar(Sensor sensor_0 = null)
	{
		if (sensor_0 != null && sensor_0.MastHeight != 0)
		{
			return sensor_0.MastHeight;
		}
		return MastHeight;
	}

	[SpecialName]
	public override int GetMastHeight_Visual(Sensor sensor_0 = null)
	{
		if (sensor_0 != null && sensor_0.MastHeight != 0)
		{
			return sensor_0.MastHeight;
		}
		return 3;
	}

	public Vehicle(ref Scenario scenario_0, string string_0 = null)
		: base(ref scenario_0, string_0)
	{
		TractionMode = TractionType.Undefined;
		Cargo = new Cargo(this);
		ActiveUnit activeUnit_ = this;
		m_InitializerProxy = new Vehicle_Navigator(ref activeUnit_);
		IsAmphibious = false;
		IsMobileGroundUnit = true;
		IsVehicle = true;
		EvaluateIfDumb();
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

	public Mount PickRandomAimpoint()
	{
		IEnumerable<Mount> source = Mounts.Where((Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed);
		if (source.Count() <= 0)
		{
			return null;
		}
		int index = GameGeneral.LockRandom_0.Next(0, source.Count());
		return source.ElementAtOrDefault(index);
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
			if (Information.IsNothing(nullable_0))
			{
				DesiredSpeed = Kinematics.GetMaximumSpeed(GetCurrentAltitude(), ThrottleSetting, bool_0: false);
			}
			else if (!IsGroupLead() || !AI.MustSlowDownToAllowGroupFormUp())
			{
				if (Kinematics.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
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
							goto IL_02e9;
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
			goto IL_02e9;
			IL_02e9:
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
			if (ParentScen.NatureSideExists() && ParentScen.GetNatureSide().CustomEnvironmentZones != null)
			{
				foreach (CustomEnvironmentZone customEnvironmentZone in ParentScen.GetNatureSide().CustomEnvironmentZones)
				{
					if (!((customEnvironmentZone.HasCustomTerrain && customEnvironmentZone.TerrainType == LandCover.LandCoverType.Water) & !IsOutOfFuel) || !GeoPoint.IsInsideThisArea(double_0, double_1, customEnvironmentZone.Area))
					{
						if ((customEnvironmentZone.HasCustomTerrainHeight & (customEnvironmentZone.TerrainHeight < 0) & !IsOutOfFuel) && GeoPoint.IsInsideThisArea(double_0, double_1, customEnvironmentZone.Area))
						{
							bool_3 = false;
							bool_5 = false;
							string_0 = "CEZ water along the path.";
							return false;
						}
						continue;
					}
					bool_3 = false;
					bool_5 = false;
					string_0 = "CEZ water along the path.";
					return false;
				}
			}
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
				if (!bool_0 && Navigator.HasPathfindingPlottedCourse && Status != _ActiveUnitStatus.EngagedOffensive && (Information.IsNothing(nullable_0) ? Module_Unit.RangeToPoint_Horiz(this, double_0, double_1) : nullable_0.Value) <= GetHorizMovementDistanceOnThisTime(2f))
				{
					bool_3 = false;
					bool_5 = false;
					return true;
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
				if (PrintWatcher(double_0, double_1, nullable_1))
				{
					if ((double)Terrain.InvokeWatcher(double_0, double_1, bool_0: false, ParentScen) <= 0.75)
					{
						bool_3 = false;
						bool_5 = false;
						return true;
					}
					return false;
				}
				bool_3 = false;
				bool_5 = false;
				string_0 = "该点无法到达。";
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
			exception_?.Data.Add("Error at 200286", exception_.Message);
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

	public override bool CanPlotCourseToThisLocation(double double_0, double double_1)
	{
		double latitude = GetLatitude();
		double longitude = GetLongitude();
		if (Navigator.HasPlottedCourse())
		{
			latitude = Navigator.PlottedCourse.Last().Latitude;
			longitude = Navigator.PlottedCourse.Last().Longitude;
		}
		return GroundCostBasedPathfinder.CanSolve(latitude, longitude, double_0, double_1);
	}

	private bool PrintWatcher(double double_0, double double_1, short? nullable_0 = null)
	{
		bool result = false;
		try
		{
			if (ParentScen.NatureSideExists())
			{
				foreach (CustomEnvironmentZone customEnvironmentZone in ParentScen.GetNatureSide().CustomEnvironmentZones)
				{
					if (customEnvironmentZone.HasCustomTerrain && GeoPoint.IsInsideThisArea(double_0, double_1, customEnvironmentZone.Area) && customEnvironmentZone.TerrainType != 0)
					{
						result = true;
						return true;
					}
				}
			}
			if (IsOutOfFuel)
			{
				if (IsVehicle)
				{
					result = true;
					return true;
				}
				if (!Terrain.ExcludeWatcher(double_0, double_1).IsOverland)
				{
					Weather.WeatherProfile weatherAtThisTimeAndPlace = Weather.GetWeatherAtThisTimeAndPlace(ParentScen, double_0, double_1, 0);
					if (MaxSeaState < weatherAtThisTimeAndPlace.SeaState)
					{
						result = false;
						return false;
					}
				}
			}
			else
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
						result = true;
						return true;
					}
					num = (tuple.Item2.HasValue ? tuple.Item2.Value : Terrain.GetElevation(double_0, double_1, bool_0: false, ParentScen));
				}
				if (num <= 0)
				{
					int num2 = -415;
					if (Information.IsNothing(Propulsion.Where((Engine theE) => theE.CanBeUsedOnWater()).ElementAtOrDefault(0)))
					{
						if (num > num2 && LandCover.DestroyClass(double_0, double_1, ParentScen) != 0)
						{
							result = true;
							return true;
						}
						result = false;
						return false;
					}
					result = true;
					return true;
				}
			}
			result = true;
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100544", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override void Teleport(ref Scenario scenario_0, double double_0, double double_1)
	{
		base.Teleport(ref scenario_0, double_0, double_1);
		SetCurrentAltitude(bool_0: false, GetLandElevation(bool_0: false, bool_1: false, bool_2: true, scenario_0));
		Kinematics.ExportLocationEvent(bool_0: true);
	}

	internal float DefineWatcher()
	{
		return Cargo_Capacity_Crew;
	}

	float ICargoHost.GetCargo_Crew()
	{
		return DefineWatcher();
	}

	internal float PublishWatcher()
	{
		if (Cargo_Capacity_Type == CargoType.Personnel && Cargo_Capacity_Area == 0f)
		{
			return (float)Cargo_Capacity_Crew * Mount.PersonnelArea;
		}
		return Cargo_Capacity_Area;
	}

	float ICargoHost.GetCargo_Area()
	{
		return PublishWatcher();
	}

	internal CargoType AwakeWatcher()
	{
		return Cargo_Capacity_Type;
	}

	CargoType ICargoHost.GetCargo_Type()
	{
		return AwakeWatcher();
	}

	internal float QueryWatcher()
	{
		if (Cargo_Capacity_Type == CargoType.Personnel && Cargo_Capacity_Mass == 0f)
		{
			return (float)Cargo_Capacity_Crew * Mount.PersonnelMass;
		}
		return Cargo_Capacity_Mass;
	}

	float ICargoHost.GetCargo_Mass()
	{
		return QueryWatcher();
	}

	public float GetCargo_TowingCapacity()
	{
		return Cargo_Capacity_Towing;
	}

	public float GetCargo_MassAvailable()
	{
		return CargoHostHelper.GetAvailableMass(this, OnboardCargo);
	}

	internal bool ResetWatcher()
	{
		return false;
	}

	bool ICargoHost.GetCargo_ParadropCapable()
	{
		return ResetWatcher();
	}

	internal bool MapWatcher()
	{
		return false;
	}

	bool ICargoHost.CanStackCargo()
	{
		return MapWatcher();
	}

	public float GetCargo_Height()
	{
		return 0f;
	}

	internal int SortWatcher(List<Cargo> list_0)
	{
		if (list_0 != null && list_0.Count > 0)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			foreach (Cargo item in list_0)
			{
				if (item.StorageType == Cargo.CargoStorageType.TowedExternal)
				{
					num3 += (double)item.RequiredMass;
				}
				else
				{
					num2 += (double)item.RequiredMass;
				}
				if (num4 > -1.0)
				{
					num4 = ((item.RequiredCargoType == CargoType.Personnel) ? (num4 + (double)item.RequiredCrewSpace) : (-1.0));
				}
			}
			if (num4 > 0.0)
			{
				num = num4 / 10.0;
			}
			if (num2 > 0.0)
			{
				num = Math.Max(num, ActiveUnit_DockingOps.GetCargoMoveTime(10.0, 60.0, num2, QueryWatcher()));
			}
			if (num3 > 0.0)
			{
				num = Math.Max(num, ActiveUnit_DockingOps.GetCargoMoveTime(5.0, 30.0, num3, GetCargo_TowingCapacity()));
			}
			return (int)Math.Round(num * 60.0);
		}
		return 0;
	}

	int ICargoHost.GetLoadTime(List<Cargo> list_0)
	{
		return SortWatcher(list_0);
	}

	internal int CalcWatcher(List<Cargo> list_0)
	{
		if (list_0 != null && list_0.Count > 0)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			foreach (Cargo item in list_0)
			{
				if (item.StorageType == Cargo.CargoStorageType.TowedExternal)
				{
					num3 += (double)item.RequiredMass;
				}
				else
				{
					num2 += (double)item.RequiredMass;
				}
				if (num4 > -1.0)
				{
					num4 = ((item.RequiredCargoType == CargoType.Personnel) ? (num4 + (double)item.RequiredCrewSpace) : (-1.0));
				}
			}
			if (num4 > 0.0)
			{
				num = num4 / 20.0;
			}
			if (num2 > 0.0)
			{
				num = Math.Max(num, ActiveUnit_DockingOps.GetCargoMoveTime(2.0, 60.0, num2, QueryWatcher()));
			}
			if (num3 > 0.0)
			{
				num = Math.Max(num, ActiveUnit_DockingOps.GetCargoMoveTime(2.0, 15.0, num3, GetCargo_TowingCapacity()));
			}
			return (int)Math.Round(num * 60.0);
		}
		return 0;
	}

	int ICargoHost.GetUnloadTime(List<Cargo> list_0)
	{
		return CalcWatcher(list_0);
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
		if (Propulsion.Count > 0 && icargoClient_0.IsTowable() && Cargo_Capacity_Towing >= icargoClient_0.GetRequiredMass() && CargoHostHelper.GetTowedCargo(this) == null)
		{
			return true;
		}
		return false;
	}

	public CargoType GetRequiredCargoType()
	{
		Cargo towedCargo = CargoHostHelper.GetTowedCargo(this);
		if (towedCargo != null && towedCargo.RequiredCargoType > Cargo_Type)
		{
			return towedCargo.RequiredCargoType;
		}
		return Cargo_Type;
	}

	public float GetRequiredCrewSpace()
	{
		float num = Cargo_Crew;
		Cargo towedCargo = CargoHostHelper.GetTowedCargo(this);
		if (towedCargo != null)
		{
			num += towedCargo.RequiredCrewSpaceExternal;
		}
		return num;
	}

	public float GetRequiredArea()
	{
		float num = Cargo_Area;
		Cargo towedCargo = CargoHostHelper.GetTowedCargo(this);
		if (towedCargo != null)
		{
			num += towedCargo.RequiredAreaExternal;
		}
		return num;
	}

	public float GetRequiredAreaStacked(ICargoHost icargoHost_0, int int_0)
	{
		return GetRequiredArea() * (float)int_0;
	}

	public float GetRequiredMass()
	{
		return Cargo_Mass + CargoHostHelper.GetCurrentLoadTotalMass(this, OnboardCargo);
	}

	public bool GetParadropCapable()
	{
		return Cargo_ParadropCapable;
	}

	public string GetCargoName()
	{
		return Name;
	}

	public string GetCargoObjectID()
	{
		return ObjectID;
	}

	public int imethod_0()
	{
		return DBID;
	}

	public PlatformComponent._ComponentStatus GetCargoObjectStatus()
	{
		if (base.IsDestroyed)
		{
			return PlatformComponent._ComponentStatus.Destroyed;
		}
		if (Damage.DamagePercent <= 0f)
		{
			return PlatformComponent._ComponentStatus.Operational;
		}
		return PlatformComponent._ComponentStatus.Damaged;
	}

	public PlatformComponent._DamageSeverityFactor GetCargoObjectDamageSeverity()
	{
		float damagePercent = Damage.DamagePercent;
		if (damagePercent <= 66f)
		{
			if (damagePercent <= 33f)
			{
				return PlatformComponent._DamageSeverityFactor.Light;
			}
			return PlatformComponent._DamageSeverityFactor.Medium;
		}
		return PlatformComponent._DamageSeverityFactor.Heavy;
	}

	public string GetCargoObjectReasonForInoperative()
	{
		return "None";
	}

	public string GetCargoObjectLossString()
	{
		return "GroundUnit_" + DBID;
	}

	public string CargoObjectToXML(HashSet<string> hashSet_0, Scenario scenario_0)
	{
		return "<Vehicle>" + ObjectID + "</Vehicle>";
	}

	public void imethod_1()
	{
		ResetIDs();
	}

	public void DestroyCargoObject(Side side_0, bool bool_0, bool bool_1, bool bool_2, string string_0, string string_1 = null)
	{
		Destroy(bool_0, Module_ActiveUnit.CancelTokenizer(this), bool_2, string_0, string_1);
	}

	public bool WantsToUnload()
	{
		Mission mission = AssignedMissionOrPackage();
		if (mission != null && mission.IsActive)
		{
			if (mission.MissionClass == Mission._MissionClass.Cargo && ((CargoMission)mission).AllowSelfDeliveryFromCargo && DockingOps.OriginalCargoHostUnit != null)
			{
				return false;
			}
			if (IsGroupMember() && !IsGroupLead())
			{
				ActiveUnit groupLead = GetParentGroup().GroupLead;
				if (groupLead != null && groupLead.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo && groupLead.AssignedMissionOrPackage() == mission)
				{
					return false;
				}
			}
			return DockingOps.CustomizeDic();
		}
		return false;
	}

	public bool IsTowable()
	{
		return Propulsion.Count == 0;
	}

	public bool IsStackable()
	{
		return false;
	}

	public float GetRequiredHeight()
	{
		return 0f;
	}

	public int GetCargoQuantity()
	{
		return 1;
	}

	public bool isMatch(Cargo cargo_0)
	{
		if (cargo_0 != null && cargo_0.CargoObjectActiveUnit != null)
		{
			ActiveUnit cargoObjectActiveUnit = cargo_0.CargoObjectActiveUnit;
			if (cargoObjectActiveUnit.IsVehicle && cargoObjectActiveUnit.DBID == DBID)
			{
				return true;
			}
		}
		return false;
	}

	public override void DoFuelConsumption(float float_0)
	{
		try
		{
			if (ThrottleSetting == Throttle.FullStop || Propulsion.Count == 0 || ((ActiveUnit)this).IsOutOfFuel)
			{
				return;
			}
			AI.ForgotWatcher();
			float float_ = FuelConsumption(ThrottleSetting, null, null, null, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false) * float_0;
			FuelRec fuelRec = null;
			foreach (FuelRec item in Fuel_ReadOnly)
			{
				if (PrimaryEngine.CanUseThisFuelType(item.FuelType))
				{
					fuelRec = item;
					break;
				}
			}
			if (fuelRec != null)
			{
				Fuel_Subtract(float_, fuelRec.FuelType);
			}
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
					AddMessage(Name + " (" + Misc.ReadRequest(UnitClass) + "）燃料耗尽，在水里沉没！", Name + " immobilized", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(GetLongitude(), GetLatitude()));
				}
			}
			else
			{
				fuelRec.CurrentQuantity -= float_0;
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

	[SpecialName]
	public override bool GetCanPhysicallyReplenishThisUnit(ActiveUnit activeUnit_0)
	{
		if (!activeUnit_0.IsFixedFacility && (activeUnit_0.IsFacility || activeUnit_0.IsVehicle))
		{
			return true;
		}
		return false;
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
			altBand = ((!Information.IsNothing(altBand_0)) ? altBand_0 : (Information.IsNothing(nullable_1) ? Kinematics.GetCurrentAltBand(GetCurrentAltitude(), bool_0: false) : Kinematics.GetCurrentAltBand_CurrentAltitude(nullable_1.Value, null, bool_0: false)));
			if (Information.IsNothing(altBand))
			{
				return 0f;
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
				goto IL_02bf;
			case Throttle.Cruise:
				if (Propulsion[0].AltBands[0].Consumption_Cruise <= 0f)
				{
					return FuelConsumption(Throttle.Loiter, altBand_0, nullable_0, nullable_1, bool_0, bool_1, bool_2: false, bool_3: false, bool_4: false);
				}
				num = altBand.Consumption_Cruise;
				num2 = altBand.Consumption_Loiter;
				goto IL_02bf;
			case Throttle.Full:
				if (altBand.Speed_Full.HasValue)
				{
					float? consumption_Full = Propulsion[0].AltBands[0].Consumption_Full;
					if ((consumption_Full.HasValue ? new bool?(consumption_Full.GetValueOrDefault() > 0f) : null).GetValueOrDefault())
					{
						num = altBand.Consumption_Full.Value;
						_ = altBand.Speed_Full.Value;
						num2 = altBand.Consumption_Cruise;
						goto IL_02bf;
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
					goto IL_02bf;
				}
				IL_02bf:
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

	internal bool RateWatcher()
	{
		switch (MobileUnitCategory)
		{
		default:
			return false;
		case IMobileGroundUnit._MobileUnitCategory.Artillery_Gun:
		case IMobileGroundUnit._MobileUnitCategory.Artillery_Towed:
		case IMobileGroundUnit._MobileUnitCategory.Artillery_SP:
		case IMobileGroundUnit._MobileUnitCategory.Artillery_Rocket_Wheeled:
		case IMobileGroundUnit._MobileUnitCategory.Artillery_Rocket_Tracked:
		case IMobileGroundUnit._MobileUnitCategory.Artillery_Mortar:
		case IMobileGroundUnit._MobileUnitCategory.Artillery_SSM:
			return true;
		}
	}

	bool IMobileGroundUnit.IsArtillery()
	{
		return RateWatcher();
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
			if (Propulsion.Count == 0)
			{
				return 0L;
			}
			FuelRec fuelRec = (from theFuelrec in Fuel_ReadOnly
				select (theFuelrec) into fuelRec_0
				where Propulsion[0].CanUseThisFuelType(fuelRec_0.FuelType)
				select fuelRec_0).ElementAtOrDefault(0);
			if (fuelRec == null)
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

	[CompilerGenerated]
	private bool FlushWatcher(FuelRec fuelRec_0)
	{
		return Propulsion[0].CanUseThisFuelType(fuelRec_0.FuelType);
	}
}
