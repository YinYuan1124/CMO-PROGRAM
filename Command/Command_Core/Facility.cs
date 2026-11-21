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

public sealed class Facility : Platform, ICargoClient, ICargoHost
{
	public enum _FacilityCategory : short
	{
		None = 1001,
		Runway = 2001,
		RunwayGrade_Taxiway = 2002,
		RunwayAccessPoint = 2003,
		Building_Surface = 3001,
		Building_Reveted = 3002,
		Building_Bunker = 3003,
		Building_Underground = 3004,
		Structure_Open = 3005,
		Structure_Reveted = 3006,
		SurfaceAndUnderground = 3007,
		Underwater = 4001,
		Water_Surface = 4050,
		Mobile_Vehicle = 5001,
		Mobile_Personnel = 5002,
		Mobile_Vehicules_Tracked = 5003,
		Mobile_Vehicules_HalfTrack = 5004,
		Mobile_Vehicule_Wheeled = 5005,
		AerostatMooring = 6001,
		AirBase = 9001
	}

	public enum SamplingPointAccessibility
	{
		Yes_Overland,
		Yes_ShallowWater,
		No
	}

	public int CombatSystemGen;

	public GlobalVariables.ArmorRating Armor_General;

	public _FacilityCategory Category;

	public float Width;

	public double Area;

	public int MastHeight;

	public int MissileDefense;

	public bool HasAimpoints;

	public int AimpointDispersalRadius;

	public CIC CIC;

	public Cargo Cargo;

	private Facility_Navigator m_FieldClient;

	private Facility_AI queueClient;

	private Facility_Kinematics regClient;

	private Facility_Sensory m_ParamClient;

	private Facility_Weaponry m_PageClient;

	private Facility_CommStuff m_RulesClient;

	private Facility_Damage _MethodClient;

	private bool? m_ServiceClient;

	private bool? systemClient;

	private IMobileGroundUnit._MobileUnitCategory? m_CandidateClient;

	private static Scenario _BaseClient;

	public override bool RepresentsMobileGroundUnit
	{
		get
		{
			if (Module_ActiveUnit.CancelTokenizer(this))
			{
				if ((uint)(Category - 5001) <= 4u)
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public override float FlatSurfaceArea_m2 => (float)Area;

	public string Type_Description
	{
		get
		{
			bool? nullable_ = null;
			string text = "";
			ActiveUnit activeUnit_ = this;
			Doctrine.WRA_DetermineTargetType(ref activeUnit_, null, ref nullable_);
			if (nullable_.Value)
			{
				text = " + Radar";
			}
			return SearchBridge() + text;
		}
	}

	public override bool IsPlatform => true;

	public override GlobalVariables.ActiveUnitType UnitType => GlobalVariables.ActiveUnitType.Facility;

	public bool CanFireOnTheMove
	{
		get
		{
			switch (EnableBridge())
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

	public override bool IsOutOfFuel => false;

	public override ActiveUnit_DockingOps.ResupplyCapacity DesignatedSupplier
	{
		get
		{
			if (!_DesignatedSupplier.HasValue)
			{
				if (EnableBridge() == IMobileGroundUnit._MobileUnitCategory.Supply)
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
								gparam_ = InitBridge();
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

	public new Facility_Navigator Navigator => m_FieldClient;

	public new Facility_AI AI => queueClient;

	public new Facility_Kinematics Kinematics
	{
		get
		{
			if (Information.IsNothing(regClient))
			{
				ActiveUnit activeUnit_ = this;
				regClient = new Facility_Kinematics(ref activeUnit_);
			}
			return regClient;
		}
	}

	public new Facility_Sensory Sensory
	{
		get
		{
			if (Information.IsNothing(m_ParamClient))
			{
				ActiveUnit activeUnit_ = this;
				m_ParamClient = new Facility_Sensory(ref activeUnit_);
			}
			return m_ParamClient;
		}
	}

	public new Facility_Weaponry Weaponry
	{
		get
		{
			if (Information.IsNothing(m_PageClient))
			{
				ActiveUnit activeUnit_ = this;
				m_PageClient = new Facility_Weaponry(ref activeUnit_);
			}
			return m_PageClient;
		}
	}

	public new Facility_CommStuff CommStuff
	{
		get
		{
			if (Information.IsNothing(m_RulesClient))
			{
				ActiveUnit activeUnit_ = this;
				m_RulesClient = new Facility_CommStuff(ref activeUnit_);
			}
			return m_RulesClient;
		}
	}

	public new Facility_Damage Damage
	{
		get
		{
			if (Information.IsNothing(_MethodClient))
			{
				ActiveUnit activeUnit_ = this;
				_MethodClient = new Facility_Damage(ref activeUnit_);
			}
			return _MethodClient;
		}
	}

	public override bool IsUnderground
	{
		get
		{
			if (!m_ServiceClient.HasValue)
			{
				m_ServiceClient = base.IsUnderground;
			}
			return m_ServiceClient.Value;
		}
	}

	public override bool IsUnderwater
	{
		get
		{
			if (Category == _FacilityCategory.Water_Surface)
			{
				return false;
			}
			if (!systemClient.HasValue)
			{
				systemClient = base.IsUnderwater;
			}
			return systemClient.Value;
		}
	}

	public override string AnnexAndDBID => "设施_" + Conversions.ToString(DBID);

	public override GlobalVariables.TargetVisualSizeClass VisualSizeClass
	{
		get
		{
			float damagePts = GetDamagePts();
			if (damagePts <= 5000f)
			{
				if (damagePts <= 1000f)
				{
					if (damagePts <= 500f)
					{
						if (damagePts <= 150f)
						{
							if (damagePts <= 30f)
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

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		if (GetUnitSide() == null)
		{
			return;
		}
		try
		{
			xmlWriter_0.WriteStartElement("Facility");
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
			if (CurrentHeading != 0f)
			{
				xmlWriter_0.WriteElementString("CH", XmlConvert.ToString(CurrentHeading));
			}
			if (CurrentSpeed != 0f)
			{
				xmlWriter_0.WriteElementString("CS", XmlConvert.ToString(CurrentSpeed));
			}
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
			if (DesiredHeading != 0f)
			{
				xmlWriter_0.WriteElementString("DH", XmlConvert.ToString(DesiredHeading));
			}
			if (DesiredSpeed != 0f)
			{
				xmlWriter_0.WriteElementString("DS", XmlConvert.ToString(DesiredSpeed));
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
			if (_Sensors.Length != 0)
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
			byte status;
			if (_Status != 0)
			{
				XmlWriter obj = xmlWriter_0;
				status = (byte)_Status;
				obj.WriteElementString("Status", status.ToString());
			}
			if (_FuelState != 0)
			{
				XmlWriter obj4 = xmlWriter_0;
				status = (byte)_FuelState;
				obj4.WriteElementString("FuelState", status.ToString());
			}
			if (_WeaponState != 0)
			{
				XmlWriter obj5 = xmlWriter_0;
				status = (byte)_WeaponState;
				obj5.WriteElementString("WeaponState", status.ToString());
			}
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
			Doctrine.ToXML(ref xmlWriter_0, ref ParentScen);
			xmlWriter_0.WriteStartElement("CIC");
			CIC.ToXML(ref xmlWriter_0, ref hashSet_0, ParentScen);
			xmlWriter_0.WriteEndElement();
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

	public override void PostDeserializationHousekeeping_General(ref Scenario scenario_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, List<ActiveUnit> list_0, bool bool_0)
	{
		base.PostDeserializationHousekeeping_General(ref scenario_0, concurrentDictionary_0, list_0, bool_0);
		ActiveUnit_DockingOps.PostDeserializationHousekeeping(DockingOps, ref scenario_0, concurrentDictionary_0, bool_0);
		if (DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
		{
			SetCurrentAltitude(bool_0: false, GetLandElevation(bool_0: false, bool_1: false, bool_2: true, ParentScen));
		}
	}

	private Facility()
		: base(ref _BaseClient)
	{
		CIC = new CIC(this, "指挥所");
		Cargo = new Cargo(this);
		ActiveUnit activeUnit_ = this;
		m_FieldClient = new Facility_Navigator(ref activeUnit_);
		activeUnit_ = this;
		queueClient = new Facility_AI(ref activeUnit_);
		IsFacility = true;
	}

	public static List<Facility> SpawnFacilityFromCargoMountList(List<Mount> list_0, Scenario scenario_0, Side side_0, bool bool_0 = true)
	{
		List<Facility> list = new List<Facility>();
		checked
		{
			if (bool_0)
			{
				foreach (var item in list_0.GroupBy((Mount m) => m.MobileUnitCategory, (Mount m) => m, (IMobileGroundUnit._MobileUnitCategory MobileUnitCategory, IEnumerable<Mount> ItAnonymous) => (MobileUnitCategory: MobileUnitCategory, ItAnonymous: ItAnonymous)))
				{
					string text = "";
					int int_;
					string text2;
					switch (item.MobileUnitCategory)
					{
					case IMobileGroundUnit._MobileUnitCategory.Artillery_Gun:
						int_ = 2985;
						text2 = "Arty";
						break;
					case IMobileGroundUnit._MobileUnitCategory.Armor:
						int_ = 2983;
						text2 = "Armor";
						break;
					case IMobileGroundUnit._MobileUnitCategory.Infantry:
						int_ = 2987;
						text2 = "Inf";
						break;
					case IMobileGroundUnit._MobileUnitCategory.SAM:
						int_ = 2988;
						text2 = "SAM";
						break;
					case IMobileGroundUnit._MobileUnitCategory.AAA:
						int_ = 2989;
						text2 = "AAA";
						break;
					default:
						int_ = 2990;
						text2 = "登陆支队";
						break;
					case IMobileGroundUnit._MobileUnitCategory.MechInfantry:
						int_ = 2984;
						text2 = "Mech Inf";
						break;
					case (IMobileGroundUnit._MobileUnitCategory)10040:
						int_ = 2986;
						text2 = "Recon";
						break;
					}
					Facility facility = null;
					facility = scenario_0.AddNewFacility(side_0, int_, text + text2 + " #" + Conversions.ToString(scenario_0.UnitsAutoIncrement), 0.0, 0.0, bool_0: true);
					facility.Mounts.Clear();
					foreach (Mount item2 in item.ItAnonymous)
					{
						facility.Mounts.Add(item2);
						item2.ParentPlatform = facility;
					}
					Sensor[] array = facility.Sensors_ReadOnly();
					for (int i = 0; i < array.Length; i++)
					{
						array[i].ParentPlatform = facility;
					}
					ArrayExtensions.Clear(ref facility.Magazines);
					list.Add(facility);
				}
				return list;
			}
			Facility facility2 = null;
			facility2 = scenario_0.AddNewFacility(side_0, 2990, "Landed Detachment #" + Conversions.ToString(scenario_0.UnitsAutoIncrement), 0.0, 0.0, bool_0: true);
			facility2.Mounts.Clear();
			foreach (Mount item3 in list_0)
			{
				facility2.Mounts.Add(item3);
				item3.ParentPlatform = facility2;
			}
			Sensor[] array2 = facility2.Sensors_ReadOnly();
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j].ParentPlatform = facility2;
			}
			ArrayExtensions.Clear(ref facility2.Magazines);
			list.Add(facility2);
			return list;
		}
	}

	public static Facility LocateOrSpawnSupplyFacilityForCargoContainers(double double_0, double double_1, Scenario scenario_0, Side side_0, bool bool_0, bool bool_1)
	{
		Facility facility = null;
		List<ActiveUnit> activeUnits_List = scenario_0.ActiveUnits_List;
		float num = float.MaxValue;
		float num2 = 0f;
		ActiveUnit_DockingOps.ResupplyCapacity resupplyCapacity = ActiveUnit_DockingOps.ResupplyCapacity.None;
		foreach (ActiveUnit item in activeUnits_List)
		{
			if (item.GetUnitSide() != side_0 || !item.IsFixedFacility)
			{
				continue;
			}
			Facility facility2 = (Facility)item;
			resupplyCapacity = facility2.DesignatedSupplier;
			if (facility2.IsSingleUnitAirbase || facility2.EnableBridge() == IMobileGroundUnit._MobileUnitCategory.Supply || (resupplyCapacity == ActiveUnit_DockingOps.ResupplyCapacity.FuelAndMaterial && (bool_0 || bool_1)) || (bool_0 && resupplyCapacity == ActiveUnit_DockingOps.ResupplyCapacity.Fuel) || (bool_1 && resupplyCapacity == ActiveUnit_DockingOps.ResupplyCapacity.Material))
			{
				num2 = Module_Unit.RangeToPoint_Horiz(facility2, double_0, double_1);
				if (num2 < 2f && num2 < num)
				{
					facility = facility2;
					num = num2;
				}
			}
		}
		if (facility == null)
		{
			facility = scenario_0.AddNewFacility(side_0, 1496, "Forward Arming and Refueling Point #" + Conversions.ToString(scenario_0.UnitsAutoIncrement), 0.0, 0.0, bool_0: true);
			facility.UnitClass = "Supply Dump";
			facility.SetIsAutoDetectable(null, bool_0: false);
			ArrayExtensions.Clear(ref facility.Magazines);
			facility.Teleport(ref scenario_0, double_1, double_0);
		}
		return facility;
	}

	public new static Facility FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		Facility facility = null;
		try
		{
			facility = IncludeBridge(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0, scenario_0.LoadStockUnits);
			return facility;
		}
		catch (PlatformComponentNotFoundException projectError)
		{
			ProjectData.SetProjectError(projectError);
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			ConcurrentDictionary<string, ScenarioObject> obj = concurrentDictionary_0;
			ScenarioObject value = facility;
			obj.TryRemove(innerText, out value);
			facility = IncludeBridge(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0, bool_0: true);
			string text = "";
			if (facility.IsGroupMember())
			{
				text = "(member of group: [" + facility.GetParentGroup().Name + "])";
			}
			scenario_0.LoadingNotices.Add("The following facility:[" + facility.Name + "]" + text + " failed to shallow-rebuild because of a component missing. The facility was instead deep-rebuilt, and instantiated in its pristine DB-stock condition. All customizations present in the facility's components (damaged components, weapon additions/removals etc. etc.) have been lost. Please re-apply any necessary customizations either manually or using an SBR script.");
			ProjectData.ClearProjectError();
			return facility;
		}
	}

	private static Facility IncludeBridge(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0, bool bool_0)
	{
		try
		{
			Facility facility_ = new Facility();
			facility_.ParentScen = scenario_0;
			string text = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (Misc.CreateRequest(text, ' '))
			{
				text = text.Replace(" ", "-");
			}
			if (concurrentDictionary_0.ContainsKey(text))
			{
				return (Facility)concurrentDictionary_0[text];
			}
			facility_.ObjectID_Set(text);
			if (xmlNode_0.ChildNodes.Count == 1)
			{
				scenario_0.UnitsForLateInstantiation.Add(xmlNode_0);
				return facility_;
			}
			concurrentDictionary_0.TryAdd(facility_.ObjectID, facility_);
			int num = Conversions.ToInteger(Misc.StartRequest(xmlNode_0.ChildNodes, "DBID").InnerText);
			try
			{
				DBFunctions.GetFacility(ref scenario_0, ref facility_, num, bool_0);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ConcurrentDictionary<string, ScenarioObject> obj = concurrentDictionary_0;
				string objectID = facility_.ObjectID;
				ScenarioObject value = facility_;
				obj.TryRemove(objectID, out value);
				scenario_0.LoadingNotices.Add("设施数据库ID" + Conversions.ToString(num) + "在数据库中缺少因此未能加载。");
				ProjectData.ClearProjectError();
				return null;
			}
			if (bool_0)
			{
				facility_.RegisterIssuer(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0);
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
						facility_.CommonFromXML(xmlNode);
						switch (xmlNode.Name)
						{
						case "Comms":
							try
							{
								enumerator7 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator7.MoveNext())
								{
									XmlNode xmlNode_8 = (XmlNode)enumerator7.Current;
									CommDevice commDevice = CommDevice.FromXML(ref xmlNode_8, ref concurrentDictionary_0, facility_);
									facility_.AddCommDevice(commDevice);
									commDevice.ParentPlatform = facility_;
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
									Cargo cargo = Cargo.FromXML(ref xmlNode_7, ref concurrentDictionary_0, scenario_0, facility_);
									ArrayExtensions.Add(ref facility_.OnboardCargo, cargo);
									cargo.ParentPlatform = facility_;
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
									facility_._Fuel.Add(item);
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
									facility_.AddDockFacility(dockFacility);
									dockFacility.ParentPlatform = facility_;
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
									Sensor sensor = Sensor.FromXML((XmlNode)enumerator2.Current, concurrentDictionary_0, facility_);
									ArrayExtensions.Add(ref facility_._Sensors, sensor);
									sensor.ParentPlatform = facility_;
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
									ActiveUnit activeUnit_ = facility_;
									Engine engine = Engine.FromXML(ref xmlNode_4, ref concurrentDictionary_0, ref activeUnit_);
									facility_.Propulsion.Add(engine);
									engine.ParentPlatform = facility_;
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
									facility_.AddAirFacility(airFacility);
									airFacility.ParentPlatform = facility_;
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
									facility_.AddSharedMagazine(magazine, bool_0: false);
									magazine.ParentPlatform = facility_;
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
									Mount mount = Mount.FromXML(ref xmlNode_, ref concurrentDictionary_0, facility_);
									if (mount != null)
									{
										facility_.Mounts.Add(mount);
										mount.ParentPlatform = facility_;
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
						facility_.comparatorVal = (_ActiveUnitFuelState)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "Status":
						if (Versioned.IsNumeric(xmlNode_9.InnerText))
						{
							facility_.Status = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_9.InnerText);
						}
						else
						{
							facility_.Status = (_ActiveUnitStatus)Enum.Parse(typeof(_ActiveUnitStatus), xmlNode_9.InnerText, ignoreCase: true);
						}
						if (facility_.Status == (_ActiveUnitStatus)9)
						{
							facility_.Status = _ActiveUnitStatus.RTB;
						}
						break;
					case "AMP_OC_Speed":
						facility_.m_PrototypeVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "Name":
						facility_.Name = xmlNode_9.InnerText;
						break;
					case "LatLR":
						facility_.Latitude_LastReported = XmlConvert.ToDouble(xmlNode_9.InnerText.Replace(",", "."));
						break;
					case "DTN":
					case "DesiredTurnRate_Navigation":
						facility_.DesiredTurnRate_Navigation = (Waypoint.TurnRateCategory)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "FuelState":
						facility_._FuelState = (_ActiveUnitFuelState)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "DamagePts":
						if (!bool_0)
						{
							facility_.SetDamagePts(bool_0: false, null, XmlConvert.ToSingle(xmlNode_9.InnerText));
						}
						break;
					case "AMP_OC_DAO":
						facility_._ExporterVal = Conversions.ToBoolean(xmlNode_9.InnerText);
						break;
					case "OldDamagePercent":
						facility_.utilsVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "COA":
						facility_.ChanceOfAppearance = Conversions.ToInteger(xmlNode_9.InnerText);
						break;
					case "SBPF_ThrottleSetting":
						switch (xmlNode_9.InnerText)
						{
						default:
							facility_.candidateVal = (Throttle)Conversions.ToByte(xmlNode_9.InnerText);
							break;
						case "Loiter":
							facility_.candidateVal = Throttle.Loiter;
							break;
						case "FullStop":
							facility_.candidateVal = Throttle.FullStop;
							break;
						case "Full":
							facility_.candidateVal = Throttle.Full;
							break;
						case "Flank":
							facility_.candidateVal = Throttle.Flank;
							break;
						case "Cruise":
							facility_.candidateVal = Throttle.Cruise;
							break;
						}
						break;
					case "SBR":
						facility_.predicateVal = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "DesiredHeading":
					case "DH":
						facility_.SetDesiredHeading(TurnRate.Max, XmlConvert.ToSingle(xmlNode_9.InnerText));
						break;
					case "AirOps":
					case "ActiveUnit_AirOps":
					{
						Facility facility8 = facility_;
						ActiveUnit activeUnit_9 = facility_;
						facility8._AirOps = ActiveUnit_AirOps.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_9);
						break;
					}
					case "SBED_DesiredSpeedOverride":
						facility_.queueVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "AI":
					case "Facility_AI":
					{
						Facility facility7 = facility_;
						ActiveUnit activeUnit_8 = facility_;
						facility7.queueClient = Facility_AI.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_8);
						break;
					}
					case "SBED_ThrottleSetting":
						switch (xmlNode_9.InnerText)
						{
						default:
							facility_.fieldVal = (Throttle)Conversions.ToByte(xmlNode_9.InnerText);
							break;
						case "Loiter":
							facility_.fieldVal = Throttle.Loiter;
							break;
						case "FullStop":
							facility_.fieldVal = Throttle.FullStop;
							break;
						case "Full":
							facility_.fieldVal = Throttle.Full;
							break;
						case "Flank":
							facility_.fieldVal = Throttle.Flank;
							break;
						case "Cruise":
							facility_.fieldVal = Throttle.Cruise;
							break;
						}
						break;
					case "ThrottleSetting":
						switch (xmlNode_9.InnerText)
						{
						default:
							facility_.ThrottleSetting = (Throttle)Conversions.ToByte(xmlNode_9.InnerText);
							break;
						case "Loiter":
							facility_.ThrottleSetting = Throttle.Loiter;
							break;
						case "FullStop":
							facility_.ThrottleSetting = Throttle.FullStop;
							break;
						case "Full":
							facility_.ThrottleSetting = Throttle.Full;
							break;
						case "Flank":
							facility_.ThrottleSetting = Throttle.Flank;
							break;
						case "Cruise":
							facility_.ThrottleSetting = Throttle.Cruise;
							break;
						}
						break;
					case "Prof":
						facility_.Proficiency = (GlobalVariables.ProficiencyLevel)Conversions.ToInteger(xmlNode_9.InnerText);
						break;
					case "Doctrine":
						facility_.Doctrine = Doctrine.FromXML(ref xmlNode_9, facility_);
						break;
					case "ActiveEnterAreaTriggers":
						try
						{
							enumerator4 = xmlNode_9.ChildNodes.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								string innerText2 = ((XmlNode)enumerator4.Current).InnerText;
								facility_.ActiveEnterAreaTriggers.Add(innerText2);
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
					case "WeaponState":
						facility_._WeaponState = (_ActiveUnitWeaponState)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "Facility_CommStuff":
					case "CommStuff":
					{
						Facility facility6 = facility_;
						ActiveUnit activeUnit_7 = facility_;
						facility6.m_RulesClient = Facility_CommStuff.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_7);
						break;
					}
					case "AMP_OC_DSO":
						facility_._VisitorVal = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "OODA_D":
						facility_.HasCustomOODA = true;
						facility_.m_TokenVal = Conversions.ToShort(xmlNode_9.InnerText);
						break;
					case "OODA_E":
						facility_.HasCustomOODA = true;
						facility_._ResolverVal = Conversions.ToShort(xmlNode_9.InnerText);
						break;
					case "Latitude_UnitEntersAreaCheck":
						facility_.Latitude__UnitEntersAreaCheck = XmlConvert.ToDouble(xmlNode_9.InnerText);
						break;
					case "EFSAR":
						facility_.EligibleForSAR = Conversions.ToBoolean(xmlNode_9.InnerText);
						break;
					case "OODA_T":
						facility_.HasCustomOODA = true;
						facility_._IndexerVal = Conversions.ToShort(xmlNode_9.InnerText);
						break;
					case "AssignedMission":
						if (xmlNode_9.HasChildNodes)
						{
							XmlNode xmlNode4 = xmlNode_9.ChildNodes[0];
							facility_._AssignedMissionOrPackage_ID = xmlNode4.InnerText;
						}
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
									facility_.ActiveRemainAreaTriggers.Add(key, result);
									continue;
								}
								string innerText = xmlNode3.InnerText;
								long result2 = 0L;
								if (long.TryParse(innerText, out result2))
								{
									result = DateTime.FromBinary(Conversions.ToLong(xmlNode3.InnerText));
									facility_.ActiveRemainAreaTriggers.Add(key, result);
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
					case "Facility_Sensory":
					case "Sensory":
					{
						Facility facility5 = facility_;
						ActiveUnit activeUnit_6 = facility_;
						facility5.m_ParamClient = Facility_Sensory.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_6);
						break;
					}
					case "CustomIcon":
						facility_.CustomIcon = xmlNode_9.InnerText;
						break;
					case "Side":
						facility_._SideName = xmlNode_9.InnerText;
						break;
					case "Longitude":
					case "Lon":
						facility_.SetLongitude(null, XmlConvert.ToDouble(xmlNode_9.InnerText.Replace(",", ".")));
						break;
					case "DS":
					case "DesiredSpeed":
						facility_.DesiredSpeed = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "IBPU":
						facility_.IsBeingPickedUp = Conversions.ToBoolean(xmlNode_9.InnerText);
						break;
					case "SBR_ThrottleSetting":
						switch (xmlNode_9.InnerText)
						{
						default:
							facility_._TemplateVal = (Throttle)Conversions.ToByte(xmlNode_9.InnerText);
							break;
						case "Loiter":
							facility_._TemplateVal = Throttle.Loiter;
							break;
						case "FullStop":
							facility_._TemplateVal = Throttle.FullStop;
							break;
						case "Full":
							facility_._TemplateVal = Throttle.Full;
							break;
						case "Flank":
							facility_._TemplateVal = Throttle.Flank;
							break;
						case "Cruise":
							facility_._TemplateVal = Throttle.Cruise;
							break;
						}
						break;
					case "Message":
						facility_.Message = xmlNode_9.InnerText;
						break;
					case "AssignedTaskPool":
						if (xmlNode_9.HasChildNodes)
						{
							XmlNode xmlNode2 = xmlNode_9.ChildNodes[0];
							facility_._AssignedTaskPool_ID = xmlNode2.InnerText;
						}
						break;
					case "DockingOps":
					case "ActiveUnit_DockingOps":
					{
						Facility facility4 = facility_;
						ActiveUnit activeUnit_5 = facility_;
						facility4._DockingOps = ActiveUnit_DockingOps.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_5);
						break;
					}
					case "Latitude":
					case "Lat":
						facility_.SetLatitude(null, XmlConvert.ToDouble(xmlNode_9.InnerText.Replace(",", ".")));
						break;
					case "Damage":
					case "Facility_Damage":
					{
						Facility facility3 = facility_;
						ActiveUnit activeUnit_4 = facility_;
						facility3._MethodClient = Facility_Damage.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_4);
						break;
					}
					case "LonLR":
						facility_.Longitude_LastReported = XmlConvert.ToDouble(xmlNode_9.InnerText.Replace(",", "."));
						break;
					case "AMP_OC":
						facility_.m_AttrVal = Conversions.ToBoolean(xmlNode_9.InnerText);
						break;
					case "DT":
					case "DesiredTurnRate":
						facility_.DesiredTurnRate = (TurnRate)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "CS":
					case "CurrentSpeed":
						facility_.CurrentSpeed = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "SBEO":
						facility_._RecordVal = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "Facility_Navigator":
					case "Navigator":
					{
						Facility facility2 = facility_;
						ActiveUnit activeUnit_3 = facility_;
						facility2.m_FieldClient = Facility_Navigator.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_3);
						break;
					}
					case "SBED":
						facility_._SingletonVal = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_9.InnerText);
						break;
					case "Facility_Weaponry":
					case "Weaponry":
					{
						Facility facility = facility_;
						ActiveUnit activeUnit_2 = facility_;
						facility.m_PageClient = Facility_Weaponry.FromXML(ref xmlNode_9, ref concurrentDictionary_0, ref activeUnit_2);
						break;
					}
					case "SBEO_ThrottleSetting":
						switch (xmlNode_9.InnerText)
						{
						default:
							facility_.m_RulesVal = (Throttle)Conversions.ToByte(xmlNode_9.InnerText);
							break;
						case "Loiter":
							facility_.m_RulesVal = Throttle.Loiter;
							break;
						case "FullStop":
							facility_.m_RulesVal = Throttle.FullStop;
							break;
						case "Full":
							facility_.m_RulesVal = Throttle.Full;
							break;
						case "Flank":
							facility_.m_RulesVal = Throttle.Flank;
							break;
						case "Cruise":
							facility_.m_RulesVal = Throttle.Cruise;
							break;
						}
						break;
					case "ParentGroup":
						facility_._ParentGroup_ID = xmlNode_9.InnerText;
						break;
					case "Kinematics":
					case "Facility_Kinematics":
						ActiveUnit_Kinematics.FromXML(xmlNode_9, concurrentDictionary_0, facility_);
						break;
					case "CH":
					case "CurrentHeading":
						facility_.CurrentHeading = XmlConvert.ToSingle(xmlNode_9.InnerText);
						break;
					case "IsAD":
					case "IsAutoDetectable":
						facility_.SetIsAutoDetectable(null, Conversions.ToBoolean(xmlNode_9.InnerText));
						break;
					case "Longitude_UnitEntersAreaCheck":
						facility_.Longitude__UnitEntersAreaCheck = XmlConvert.ToDouble(xmlNode_9.InnerText);
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
			facility_.SetCurrentAltitude(bool_0: false, facility_.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, facility_.ParentScen));
			facility_.EvaluateIfDumb();
			return facility_;
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

	private string SearchBridge()
	{
		_FacilityCategory category = Category;
		if (1 == 0)
		{
		}
		string result = category switch
		{
			_FacilityCategory.Runway => "Runway", 
			_FacilityCategory.RunwayGrade_Taxiway => "跑道级滑行道", 
			_FacilityCategory.RunwayAccessPoint => "跑道入口", 
			_FacilityCategory.None => "None", 
			_FacilityCategory.Underwater => "Underwater", 
			_FacilityCategory.Building_Surface => "建筑（露天）", 
			_FacilityCategory.Building_Reveted => "建筑（遮盖）", 
			_FacilityCategory.Building_Bunker => "建筑（碉堡）", 
			_FacilityCategory.Building_Underground => "建筑（地下）", 
			_FacilityCategory.Structure_Open => "设施（露天）", 
			_FacilityCategory.Structure_Reveted => "设施（遮盖）", 
			_FacilityCategory.SurfaceAndUnderground => "Surface & Underground", 
			_FacilityCategory.Mobile_Personnel => "移动人员", 
			_FacilityCategory.Mobile_Vehicle => "移动车辆", 
			_FacilityCategory.AirBase => "空军基地", 
			_FacilityCategory.AerostatMooring => "航空停泊", 
			_ => "None", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal IMobileGroundUnit._MobileUnitCategory EnableBridge()
	{
		if (!m_CandidateClient.HasValue)
		{
			m_CandidateClient = MobileUnitCategory(Misc.ResolveRequest(UnitClass));
		}
		return m_CandidateClient.Value;
	}

	public static IMobileGroundUnit._MobileUnitCategory MobileUnitCategory(string string_0)
	{
		switch (Misc.ResolveRequest(string_0))
		{
		case "SAM":
			return IMobileGroundUnit._MobileUnitCategory.SAM;
		case "Inf":
			return IMobileGroundUnit._MobileUnitCategory.Infantry;
		case "Armored":
			return IMobileGroundUnit._MobileUnitCategory.Armor;
		case "Arty":
			return IMobileGroundUnit._MobileUnitCategory.Artillery_Gun;
		case "Radar":
			return IMobileGroundUnit._MobileUnitCategory.Surveillance;
		case "SSM":
			return IMobileGroundUnit._MobileUnitCategory.Artillery_SSM;
		case "Mech":
			return IMobileGroundUnit._MobileUnitCategory.MechInfantry;
		case "AAA":
			return IMobileGroundUnit._MobileUnitCategory.AAA;
		default:
			if (!string_0.Contains("Ammo") && !string_0.Contains("Fuel") && !string_0.Contains("Supply"))
			{
				return IMobileGroundUnit._MobileUnitCategory.None;
			}
			return IMobileGroundUnit._MobileUnitCategory.Supply;
		case "Motor":
			return IMobileGroundUnit._MobileUnitCategory.MechInfantry;
		}
	}

	internal string ChangeBridge()
	{
		IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = EnableBridge();
		if (1 == 0)
		{
		}
		string result = mobileUnitCategory switch
		{
			IMobileGroundUnit._MobileUnitCategory.Infantry => "Infantry", 
			IMobileGroundUnit._MobileUnitCategory.None => "None", 
			IMobileGroundUnit._MobileUnitCategory.Artillery_Towed => "Towed Artillery", 
			IMobileGroundUnit._MobileUnitCategory.Artillery_Gun => "Artillery", 
			IMobileGroundUnit._MobileUnitCategory.Armor => "Armor", 
			IMobileGroundUnit._MobileUnitCategory.SAM => "SAM", 
			IMobileGroundUnit._MobileUnitCategory.AAA => "AAA", 
			IMobileGroundUnit._MobileUnitCategory.Artillery_SSM => "导弹炮兵", 
			IMobileGroundUnit._MobileUnitCategory.MechInfantry => "机械化步兵", 
			IMobileGroundUnit._MobileUnitCategory.Surveillance => "Surveillance", 
			IMobileGroundUnit._MobileUnitCategory.Engineer => "Engineer", 
			_ => throw new NotImplementedException(), 
		};
		if (1 == 0)
		{
		}
		return result;
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

	private CommDevice[] InitBridge()
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
		if (MastHeight == 0 && base.Sensors_Cached.Where((Sensor theS) => theS.Type == Sensor.Sensor_Type.PCLS).Count() > 0)
		{
			MastHeight = 25;
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
		switch (Category)
		{
		case _FacilityCategory.Building_Surface:
		{
			GlobalVariables.TargetVisualSizeClass visualSizeClass = VisualSizeClass;
			if (1 == 0)
			{
			}
			int result = visualSizeClass switch
			{
				GlobalVariables.TargetVisualSizeClass.Stealthy => 1, 
				GlobalVariables.TargetVisualSizeClass.VSmall => 4, 
				GlobalVariables.TargetVisualSizeClass.Small => 6, 
				GlobalVariables.TargetVisualSizeClass.Medium => 20, 
				GlobalVariables.TargetVisualSizeClass.Large => 30, 
				GlobalVariables.TargetVisualSizeClass.VLarge => 40, 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		default:
			return 0;
		case _FacilityCategory.Mobile_Personnel:
			return 2;
		case _FacilityCategory.Mobile_Vehicle:
			return 4;
		case _FacilityCategory.Building_Underground:
		case _FacilityCategory.SurfaceAndUnderground:
			return 0;
		}
	}

	public Facility(ref Scenario scenario_0, string string_0 = null)
		: base(ref scenario_0, string_0)
	{
		CIC = new CIC(this, "指挥所");
		Cargo = new Cargo(this);
		ActiveUnit activeUnit_ = this;
		m_FieldClient = new Facility_Navigator(ref activeUnit_);
		activeUnit_ = this;
		queueClient = new Facility_AI(ref activeUnit_);
		IsFacility = true;
		EvaluateIfDumb();
	}

	public override void DoTypeSpecificActions(float float_0, ref LockRandom lockRandom_0)
	{
		DockingOps.DoDockingOps(float_0);
	}

	public bool IsArtillery()
	{
		switch (EnableBridge())
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

	public override bool CanMoveToThisLocation(double double_0, double double_1, ref int int_0, bool bool_0, bool bool_1, bool bool_2, ref bool bool_3, bool bool_4, ref bool bool_5, float? nullable_0, short? nullable_1, ref List<ActiveUnit> list_0, float float_0, bool bool_6, bool bool_7, ref string string_0, ref bool bool_8)
	{
		try
		{
			int_0 = 1;
			if (ParentScen.NatureSideExists() && ParentScen.GetNatureSide().CustomEnvironmentZones != null)
			{
				foreach (CustomEnvironmentZone customEnvironmentZone in ParentScen.GetNatureSide().CustomEnvironmentZones)
				{
					if (!customEnvironmentZone.HasCustomTerrain || customEnvironmentZone.TerrainType != 0 || !GeoPoint.IsInsideThisArea(double_0, double_1, customEnvironmentZone.Area))
					{
						if ((customEnvironmentZone.HasCustomTerrainHeight & (customEnvironmentZone.TerrainHeight < 0)) && GeoPoint.IsInsideThisArea(double_0, double_1, customEnvironmentZone.Area))
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
				switch (CheckBridge(double_0, double_1, nullable_1))
				{
				case SamplingPointAccessibility.No:
					bool_3 = false;
					bool_5 = false;
					string_0 = "该点无法到达。";
					return false;
				default:
					if (!((double)Terrain.InvokeWatcher(double_0, double_1, bool_0: false, ParentScen) <= 0.75))
					{
						return false;
					}
					break;
				case SamplingPointAccessibility.Yes_ShallowWater:
					break;
				}
				bool_3 = false;
				bool_5 = false;
				return true;
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

	private SamplingPointAccessibility CheckBridge(double double_0, double double_1, short? nullable_0 = null)
	{
		SamplingPointAccessibility result = SamplingPointAccessibility.Yes_Overland;
		try
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
					result = SamplingPointAccessibility.Yes_Overland;
					return SamplingPointAccessibility.Yes_Overland;
				}
				num = (tuple.Item2.HasValue ? tuple.Item2.Value : Terrain.GetElevation(double_0, double_1, bool_0: false, ParentScen));
			}
			if (num < 0)
			{
				result = SamplingPointAccessibility.No;
				return SamplingPointAccessibility.No;
			}
			result = SamplingPointAccessibility.Yes_ShallowWater;
			return SamplingPointAccessibility.Yes_ShallowWater;
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
		SetCurrentAltitude(bool_0: false, GetLandElevation(bool_0: false, bool_1: false, bool_2: true, ParentScen));
		Kinematics.ExportLocationEvent(bool_0: true);
	}

	internal float ConcatBridge()
	{
		if (base.IsFixedFacility)
		{
			return Math.Max(1000f, (float)Area);
		}
		return 0f;
	}

	float ICargoHost.GetCargo_Crew()
	{
		return ConcatBridge();
	}

	internal float InterruptBridge()
	{
		if (base.IsFixedFacility)
		{
			return Math.Max(1000f, (float)Area);
		}
		return 0f;
	}

	float ICargoHost.GetCargo_Area()
	{
		return InterruptBridge();
	}

	internal CargoType RemoveBridge()
	{
		if (base.IsFixedFacility)
		{
			return CargoType.const_5;
		}
		return CargoType.NoCargo;
	}

	CargoType ICargoHost.GetCargo_Type()
	{
		return RemoveBridge();
	}

	internal float FindBridge()
	{
		if (base.IsFixedFacility)
		{
			return Math.Max(1000f, (float)Area);
		}
		return 0f;
	}

	float ICargoHost.GetCargo_Mass()
	{
		return FindBridge();
	}

	public float GetCargo_TowingCapacity()
	{
		return 0f;
	}

	public float GetCargo_MassAvailable()
	{
		return CargoHostHelper.GetAvailableMass(this, OnboardCargo);
	}

	internal bool SetBridge()
	{
		return false;
	}

	bool ICargoHost.CanStackCargo()
	{
		return SetBridge();
	}

	public float GetCargo_Height()
	{
		return 0f;
	}

	internal bool FillBridge()
	{
		return false;
	}

	bool ICargoHost.GetCargo_ParadropCapable()
	{
		return FillBridge();
	}

	internal int CalculateBridge(List<Cargo> list_0)
	{
		return ActiveUnit_DockingOps.DEFAULT_CARGO_LOAD_TIME;
	}

	int ICargoHost.GetLoadTime(List<Cargo> list_0)
	{
		return CalculateBridge(list_0);
	}

	internal int PopBridge(List<Cargo> list_0)
	{
		return ActiveUnit_DockingOps.DEFAULT_CARGO_UNLOAD_TIME;
	}

	int ICargoHost.GetUnloadTime(List<Cargo> list_0)
	{
		return PopBridge(list_0);
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

	public CargoType GetRequiredCargoType()
	{
		if (HasAimpoints)
		{
			CargoType cargoType = CargoType.NoCargo;
			foreach (Mount mount in Mounts)
			{
				if (mount.IsFacilityAimpoint)
				{
					CargoType requiredCargoType = mount.GetRequiredCargoType();
					if (requiredCargoType > cargoType)
					{
						cargoType = requiredCargoType;
					}
				}
			}
			return cargoType;
		}
		return CargoType.NoCargo;
	}

	public float GetRequiredCrewSpace()
	{
		if (HasAimpoints)
		{
			float num = 0f;
			foreach (Mount mount in Mounts)
			{
				if (mount.IsFacilityAimpoint)
				{
					num += mount.GetRequiredCrewSpace();
				}
			}
			return num;
		}
		return 0f;
	}

	public float GetRequiredArea()
	{
		if (HasAimpoints)
		{
			float num = 0f;
			foreach (Mount mount in Mounts)
			{
				if (mount.IsFacilityAimpoint)
				{
					num += mount.GetRequiredArea();
				}
			}
			return num;
		}
		return 0f;
	}

	public float GetRequiredAreaStacked(ICargoHost icargoHost_0, int int_0)
	{
		return GetRequiredArea() * (float)int_0;
	}

	public float GetRequiredMass()
	{
		if (HasAimpoints)
		{
			float num = 0f;
			foreach (Mount mount in Mounts)
			{
				if (mount.IsFacilityAimpoint)
				{
					num += mount.GetRequiredMass();
				}
			}
			return num;
		}
		return 0f;
	}

	public bool GetParadropCapable()
	{
		if (HasAimpoints)
		{
			bool result = false;
			foreach (Mount mount in Mounts)
			{
				if (mount.IsFacilityAimpoint)
				{
					if (!mount.GetParadropCapable())
					{
						result = false;
						break;
					}
					result = true;
				}
			}
			return result;
		}
		return false;
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
		return "设施_" + DBID;
	}

	public string CargoObjectToXML(HashSet<string> hashSet_0, Scenario scenario_0)
	{
		return "<Facility>" + ObjectID + "</Facility>";
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
		return false;
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
			if (cargoObjectActiveUnit.IsFacility && cargoObjectActiveUnit.DBID == DBID)
			{
				return true;
			}
		}
		return false;
	}
}
