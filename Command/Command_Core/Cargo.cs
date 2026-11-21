using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Cargo : PlatformComponent
{
	public enum CargoObjectType
	{
		None,
		Mount,
		Vehicle,
		Facility,
		CargoContainer,
		CargoContainerContent
	}

	public enum CargoStorageType
	{
		StoredInternal,
		StoredExternal,
		TowedExternal
	}

	private CargoObjectType _AttrObserver;

	private ICargoClient _VisitorObserver;

	private string m_ExporterObserver;

	private CargoStorageType prototypeObserver;

	public const float SQUARE_FEET_PER_SQUARE_METER = 10.76391f;

	public const float SHORT_TONS_PER_METRIC_TON = 1.102311f;

	public const float POUNDS_PER_KILOGRAM = 2.204623f;

	public const float GALLONS_PER_LITER = 0.2641729f;

	public CargoStorageType StorageType
	{
		get
		{
			return prototypeObserver;
		}
		set
		{
			prototypeObserver = value;
		}
	}

	public CargoObjectType InternalObjectType => _AttrObserver;

	public int CargoObjectQuantity
	{
		get
		{
			if (_VisitorObserver == null)
			{
				return 0;
			}
			return _VisitorObserver.GetCargoQuantity();
		}
	}

	public CargoType RequiredCargoType
	{
		get
		{
			if (_VisitorObserver == null)
			{
				return CargoType.NoCargo;
			}
			return _VisitorObserver.GetRequiredCargoType();
		}
	}

	public float RequiredCrewSpace
	{
		get
		{
			if (_VisitorObserver == null)
			{
				return 0f;
			}
			if (prototypeObserver == CargoStorageType.TowedExternal)
			{
				return 0f;
			}
			return _VisitorObserver.GetRequiredCrewSpace();
		}
	}

	public float RequiredArea
	{
		get
		{
			if (_VisitorObserver == null)
			{
				return 0f;
			}
			if (prototypeObserver == CargoStorageType.TowedExternal)
			{
				return 0f;
			}
			return _VisitorObserver.GetRequiredArea();
		}
	}

	public float RequiredMass
	{
		get
		{
			if (_VisitorObserver == null)
			{
				return 0f;
			}
			return _VisitorObserver.GetRequiredMass();
		}
	}

	public float RequiredAreaExternal
	{
		get
		{
			if (_VisitorObserver == null)
			{
				return 0f;
			}
			return _VisitorObserver.GetRequiredArea();
		}
	}

	public float RequiredCrewSpaceExternal
	{
		get
		{
			if (_VisitorObserver == null)
			{
				return 0f;
			}
			return _VisitorObserver.GetRequiredCrewSpace();
		}
	}

	public bool isParadropCapable
	{
		get
		{
			if (_VisitorObserver == null)
			{
				return false;
			}
			return _VisitorObserver.GetParadropCapable();
		}
	}

	public CargoObjectType CurrentType
	{
		get
		{
			return _AttrObserver;
		}
		private set
		{
			_AttrObserver = value;
		}
	}

	public ICargoClient GetCargoClient => _VisitorObserver;

	public ActiveUnit CargoObjectActiveUnit
	{
		get
		{
			if ((uint)(_AttrObserver - 2) <= 1u)
			{
				return (ActiveUnit)_VisitorObserver;
			}
			return null;
		}
	}

	public CargoContainer CargoObjectContainer
	{
		get
		{
			if (_AttrObserver == CargoObjectType.CargoContainer)
			{
				return (CargoContainer)_VisitorObserver;
			}
			return null;
		}
	}

	public CargoContainerContent CargoObjectContainerContents
	{
		get
		{
			if (_AttrObserver == CargoObjectType.CargoContainerContent)
			{
				return (CargoContainerContent)_VisitorObserver;
			}
			return null;
		}
	}

	public string CargoObjectName
	{
		get
		{
			if (_VisitorObserver == null)
			{
				return "(No cargo)";
			}
			if (prototypeObserver == CargoStorageType.TowedExternal)
			{
				if (Name == null)
				{
					Name = "[TOWED] " + _VisitorObserver.GetCargoName();
				}
				return Name;
			}
			return _VisitorObserver.GetCargoName();
		}
	}

	public string CargoObjectID
	{
		get
		{
			if (_VisitorObserver == null)
			{
				return "";
			}
			return _VisitorObserver.GetCargoObjectID();
		}
	}

	public int CargoObjectDBID
	{
		get
		{
			if (_VisitorObserver == null)
			{
				return 0;
			}
			return _VisitorObserver.imethod_0();
		}
	}

	public _ComponentStatus CargoObjectStatus
	{
		get
		{
			if (_VisitorObserver == null)
			{
				return _ComponentStatus.Destroyed;
			}
			return _VisitorObserver.GetCargoObjectStatus();
		}
	}

	public _DamageSeverityFactor CargoObjectDamageSeverity
	{
		get
		{
			if (_VisitorObserver == null)
			{
				return _DamageSeverityFactor.Heavy;
			}
			return _VisitorObserver.GetCargoObjectDamageSeverity();
		}
	}

	public string CargoObjectReasonForInoperative
	{
		get
		{
			if (_VisitorObserver == null)
			{
				return "None";
			}
			return _VisitorObserver.GetCargoObjectReasonForInoperative();
		}
	}

	public string CargoObjectLossString
	{
		get
		{
			if (_VisitorObserver == null)
			{
				return "";
			}
			return _VisitorObserver.GetCargoObjectLossString();
		}
	}

	public override void ResetIDs()
	{
		if (_VisitorObserver != null)
		{
			_VisitorObserver.imethod_1();
		}
		base.ResetIDs();
	}

	public bool IsMatch(Cargo cargo_0)
	{
		if (cargo_0 == null)
		{
			return false;
		}
		if (cargo_0._AttrObserver == _AttrObserver)
		{
			return cargo_0.CargoObjectDBID == CargoObjectDBID;
		}
		return false;
	}

	internal bool RestartProperty()
	{
		if (_VisitorObserver == null)
		{
			return false;
		}
		return _VisitorObserver.WantsToUnload();
	}

	public string ToXML(HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			if (_VisitorObserver == null)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<Cargo>");
			stringBuilder.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (hashSet_0 != null)
			{
				if (hashSet_0.Contains(ObjectID))
				{
					stringBuilder.Append("</Cargo>");
					return stringBuilder.ToString();
				}
				hashSet_0.Add(ObjectID);
			}
			if (_Status != 0)
			{
				StringBuilder stringBuilder2 = stringBuilder.Append("<Status>");
				byte status = (byte)_Status;
				stringBuilder2.Append(status.ToString()).Append("</Status>");
			}
			if (base.DamageSeverity != 0)
			{
				stringBuilder.Append("<DamageSeverity>").Append(((byte)base.DamageSeverity).ToString()).Append("</DamageSeverity>");
			}
			if (!string.IsNullOrEmpty(Name))
			{
				stringBuilder.Append("<Name>").Append(SecurityElement.Escape(Name)).Append("</Name>");
			}
			stringBuilder.Append("<CurrentType>").Append((byte)_AttrObserver).Append("</CurrentType>");
			if (prototypeObserver != 0)
			{
				stringBuilder.Append("<StorageType>").Append((byte)prototypeObserver).Append("</StorageType>");
			}
			stringBuilder.Append(_VisitorObserver.CargoObjectToXML(hashSet_0, scenario_0));
			stringBuilder.Append("</Cargo>");
			return stringBuilder.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100658", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return "";
	}

	public override void Destroy(Side side_0, bool bool_0, bool bool_1)
	{
		try
		{
			if (Status == _ComponentStatus.Destroyed)
			{
				return;
			}
			base.Destroy(side_0, bool_0, bool_1);
			if (_VisitorObserver == null)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			else
			{
				_VisitorObserver.DestroyCargoObject(side_0, bool_0, bool_1, bool_2: true, "Containing Unit Destroyed");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100678", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Cargo FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0, ActiveUnit activeUnit_0, ICargoHost icargoHost_0 = null)
	{
		try
		{
			Cargo cargo = new Cargo();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode_ = (XmlNode)enumerator.Current;
					switch (xmlNode_.Name)
					{
					case "Name":
						cargo.Name = xmlNode_.InnerText;
						break;
					case "Status":
						switch (xmlNode_.InnerText)
						{
						default:
							cargo._Status = (_ComponentStatus)Conversions.ToByte(xmlNode_.InnerText);
							break;
						case "Operational":
							cargo._Status = _ComponentStatus.Operational;
							break;
						case "Destroyed":
							cargo._Status = _ComponentStatus.Destroyed;
							break;
						case "Damaged":
							cargo._Status = _ComponentStatus.Damaged;
							break;
						}
						break;
					case "CargoContainer":
						cargo._VisitorObserver = CargoContainer.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0, activeUnit_0, icargoHost_0);
						break;
					case "Mount":
					{
						Mount mount = Mount.FromXML(ref xmlNode_, ref concurrentDictionary_0, activeUnit_0);
						mount.ParentPlatform = null;
						cargo._VisitorObserver = mount;
						break;
					}
					case "CargoContainerContent":
						cargo._VisitorObserver = CargoContainerContent.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0, activeUnit_0, icargoHost_0);
						break;
					case "StorageType":
						cargo.prototypeObserver = (CargoStorageType)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "DamageSeverity":
						cargo.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "ID":
						if (!Information.IsNothing(concurrentDictionary_0))
						{
							if (concurrentDictionary_0.ContainsKey(xmlNode_.InnerText))
							{
								return (Cargo)concurrentDictionary_0[xmlNode_.InnerText];
							}
							cargo.ObjectID_Set(xmlNode_.InnerText);
							concurrentDictionary_0.TryAdd(cargo.ObjectID, cargo);
						}
						break;
					case "CurrentType":
						cargo._AttrObserver = (CargoObjectType)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Vehicle":
					case "Facility":
						cargo.m_ExporterObserver = xmlNode_.InnerText;
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
			return cargo;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100659", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return null;
	}

	public void PostDeserializationHousekeeping_General(ref Scenario scenario_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, bool bool_0)
	{
		if (_AttrObserver != CargoObjectType.Vehicle && _AttrObserver != CargoObjectType.Facility)
		{
			return;
		}
		ActiveUnit activeUnit = scenario_0.ActiveUnits[m_ExporterObserver];
		if (activeUnit == null)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		else if (activeUnit is ICargoClient)
		{
			_VisitorObserver = (ICargoClient)activeUnit;
		}
	}

	private Cargo()
		: base(null)
	{
		_AttrObserver = CargoObjectType.None;
		_VisitorObserver = null;
		prototypeObserver = CargoStorageType.StoredInternal;
	}

	public Cargo(ActiveUnit activeUnit_0)
		: base(activeUnit_0)
	{
		_AttrObserver = CargoObjectType.None;
		_VisitorObserver = null;
		prototypeObserver = CargoStorageType.StoredInternal;
	}

	public Cargo(ActiveUnit activeUnit_0, Mount mount_0)
		: base(activeUnit_0)
	{
		_AttrObserver = CargoObjectType.None;
		_VisitorObserver = null;
		prototypeObserver = CargoStorageType.StoredInternal;
		CurrentType = CargoObjectType.Mount;
		_VisitorObserver = mount_0;
	}

	public Cargo(ActiveUnit activeUnit_0, Vehicle vehicle_0)
		: base(activeUnit_0)
	{
		_AttrObserver = CargoObjectType.None;
		_VisitorObserver = null;
		prototypeObserver = CargoStorageType.StoredInternal;
		CurrentType = CargoObjectType.Vehicle;
		_VisitorObserver = vehicle_0;
	}

	public Cargo(ActiveUnit activeUnit_0, Facility facility_0)
		: base(activeUnit_0)
	{
		_AttrObserver = CargoObjectType.None;
		_VisitorObserver = null;
		prototypeObserver = CargoStorageType.StoredInternal;
		CurrentType = CargoObjectType.Facility;
		_VisitorObserver = facility_0;
	}

	public Cargo(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1)
	{
		_AttrObserver = CargoObjectType.None;
		_VisitorObserver = null;
		prototypeObserver = CargoStorageType.StoredInternal;
		if (activeUnit_1 is Vehicle)
		{
			CurrentType = CargoObjectType.Vehicle;
		}
		else if (activeUnit_1 is Facility)
		{
			CurrentType = CargoObjectType.Facility;
		}
		else if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		_VisitorObserver = (ICargoClient)activeUnit_1;
	}

	public Cargo(ActiveUnit activeUnit_0, CargoContainer cargoContainer_0, ICargoHost icargoHost_0)
	{
		_AttrObserver = CargoObjectType.None;
		_VisitorObserver = null;
		prototypeObserver = CargoStorageType.StoredInternal;
		CurrentType = CargoObjectType.CargoContainer;
		cargoContainer_0.Parent = icargoHost_0;
		_VisitorObserver = cargoContainer_0;
	}

	public Cargo(ActiveUnit activeUnit_0, CargoContainerContent cargoContainerContent_0, ICargoHost icargoHost_0)
	{
		_AttrObserver = CargoObjectType.None;
		_VisitorObserver = null;
		prototypeObserver = CargoStorageType.StoredInternal;
		CurrentType = CargoObjectType.CargoContainerContent;
		cargoContainerContent_0.Parent = icargoHost_0;
		_VisitorObserver = cargoContainerContent_0;
	}

	public static Cargo CreateNewCargo(CargoObjectType cargoObjectType_0, int int_0, ActiveUnit activeUnit_0, Scenario scenario_0)
	{
		Cargo result = null;
		switch (cargoObjectType_0)
		{
		case CargoObjectType.Mount:
			result = new Cargo(activeUnit_0, DBFunctions.GetMount(int_0, ref scenario_0));
			break;
		case CargoObjectType.Vehicle:
		{
			SQLiteConnection sqliteConnection_2 = scenario_0.DBConnection;
			string vehicleName = DBFunctions.GetVehicleName(int_0, ref sqliteConnection_2);
			vehicleName = vehicleName + " #" + Conversions.ToString(scenario_0.UnitsAutoIncrement);
			Vehicle vehicle = scenario_0.AddNewVehicle(activeUnit_0.GetUnitSide(), int_0, vehicleName, activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude(), bool_0: true);
			vehicle.SetCurrentAltitude(bool_0: false, activeUnit_0.GetCurrentAltitude());
			vehicle.DockingOps.LoadIntoCargo(activeUnit_0);
			result = new Cargo(activeUnit_0, vehicle);
			break;
		}
		case CargoObjectType.Facility:
		{
			SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
			string facilityName = DBFunctions.GetFacilityName(int_0, ref sqliteConnection_);
			facilityName = facilityName + " #" + Conversions.ToString(scenario_0.UnitsAutoIncrement);
			Facility facility = scenario_0.AddNewFacility(activeUnit_0.GetUnitSide(), int_0, facilityName, activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude(), bool_0: true);
			facility.SetCurrentAltitude(bool_0: false, activeUnit_0.GetCurrentAltitude());
			facility.DockingOps.LoadIntoCargo(activeUnit_0);
			result = new Cargo(activeUnit_0, facility);
			break;
		}
		}
		return result;
	}

	public static List<ActiveUnit> UnloadSingleCargoAtLocation(ActiveUnit activeUnit_0, ref Cargo[] cargo_0, Cargo cargo_1, double double_0, double double_1, Scenario scenario_0, Side side_0, bool bool_0)
	{
		List<Cargo> list = new List<Cargo>();
		list.Add(cargo_1);
		return UnloadCargoAtLocation(activeUnit_0, ref cargo_0, list, double_0, double_1, scenario_0, side_0, bool_0);
	}

	public static List<ActiveUnit> UnloadCargoAtLocation(ActiveUnit activeUnit_0, ref Cargo[] cargo_0, List<Cargo> list_0, double double_0, double double_1, Scenario scenario_0, Side side_0, bool bool_0, bool bool_1 = false)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		Cargo[] gparam_ = new Cargo[0];
		List<Mount> list2 = new List<Mount>();
		List<CargoContainer> list3 = new List<CargoContainer>();
		if (list_0 == null)
		{
			Cargo[] array = cargo_0;
			Cargo[] array2 = array;
			foreach (Cargo cargo in array2)
			{
				if (!bool_0 || cargo.isParadropCapable)
				{
					switch (cargo._AttrObserver)
					{
					case CargoObjectType.Mount:
					{
						Mount item6 = (Mount)cargo._VisitorObserver;
						list2.Add(item6);
						ArrayExtensions.Add(ref gparam_, cargo);
						break;
					}
					case CargoObjectType.Vehicle:
					{
						Vehicle item5 = (Vehicle)cargo._VisitorObserver;
						list.Add(item5);
						ArrayExtensions.Add(ref gparam_, cargo);
						break;
					}
					case CargoObjectType.Facility:
					{
						Facility item4 = (Facility)cargo._VisitorObserver;
						list.Add(item4);
						ArrayExtensions.Add(ref gparam_, cargo);
						break;
					}
					case CargoObjectType.CargoContainer:
					{
						CargoContainer item = (CargoContainer)cargo._VisitorObserver;
						list3.Add(item);
						ArrayExtensions.Add(ref gparam_, cargo);
						break;
					}
					}
				}
			}
		}
		else
		{
			foreach (Cargo item11 in list_0)
			{
				if (cargo_0.Contains(item11) && (!bool_0 || item11.isParadropCapable))
				{
					switch (item11.CurrentType)
					{
					case CargoObjectType.Mount:
					{
						Mount item10 = (Mount)item11._VisitorObserver;
						list2.Add(item10);
						ArrayExtensions.Add(ref gparam_, item11);
						break;
					}
					case CargoObjectType.Vehicle:
					{
						Vehicle item9 = (Vehicle)item11._VisitorObserver;
						list.Add(item9);
						ArrayExtensions.Add(ref gparam_, item11);
						break;
					}
					case CargoObjectType.Facility:
					{
						Facility item8 = (Facility)item11._VisitorObserver;
						list.Add(item8);
						ArrayExtensions.Add(ref gparam_, item11);
						break;
					}
					case CargoObjectType.CargoContainer:
					{
						CargoContainer item7 = (CargoContainer)item11._VisitorObserver;
						list3.Add(item7);
						ArrayExtensions.Add(ref gparam_, item11);
						break;
					}
					}
				}
			}
		}
		if (list2.Count > 0)
		{
			List<Facility> collection = Facility.SpawnFacilityFromCargoMountList(list2, scenario_0, side_0, bool_0: false);
			list.AddRange(collection);
		}
		foreach (ActiveUnit item2 in list)
		{
			item2.Teleport(ref scenario_0, double_1, double_0);
			item2.DockingOps.UnloadFromCargo();
		}
		if (list3.Count > 0)
		{
			bool flag = false;
			bool flag2 = false;
			foreach (CargoContainer item3 in list3)
			{
				if (item3.OnboardCargo.Count() == 0)
				{
					continue;
				}
				if (item3.ContainerType == CargoContainer.CargoContainerType.Tank)
				{
					flag = true;
				}
				else
				{
					Cargo[] onboardCargo = item3.OnboardCargo;
					for (int i = 0; i < onboardCargo.Length; i = checked(i + 1))
					{
						CargoContainerContent cargoObjectContainerContents = onboardCargo[i].CargoObjectContainerContents;
						if (cargoObjectContainerContents != null && cargoObjectContainerContents.ContentType == CargoContainerContent.CargoContainerContentType.Ammunition)
						{
							flag2 = true;
						}
					}
				}
				if (!(flag && flag2))
				{
					continue;
				}
				break;
			}
			Facility activeUnit_ = Facility.LocateOrSpawnSupplyFacilityForCargoContainers(double_0, double_1, scenario_0, side_0, flag, flag2);
			UnloadCargoContainersToSupplyDump(activeUnit_0, list3, activeUnit_);
		}
		if (!bool_0 && list_0 == null)
		{
			ArrayExtensions.Clear(ref cargo_0);
		}
		else
		{
			cargo_0 = cargo_0.Except(gparam_).ToArray();
		}
		return list;
	}

	public static bool UnloadCargoContainersToSupplyDump(ActiveUnit activeUnit_0, List<CargoContainer> list_0, ActiveUnit activeUnit_1, bool bool_0 = true)
	{
		if (activeUnit_1 == null)
		{
			return false;
		}
		CargoContainerContent cargoContainerContent = null;
		foreach (CargoContainer item in list_0)
		{
			Cargo[] gparam_ = new Cargo[0];
			Cargo[] onboardCargo = item.OnboardCargo;
			Cargo[] array = onboardCargo;
			foreach (Cargo cargo in array)
			{
				cargoContainerContent = cargo.CargoObjectContainerContents;
				if (cargoContainerContent != null && (!cargoContainerContent.TransferToUnit(activeUnit_0, activeUnit_1, cargo) || cargoContainerContent.GetCargoQuantity() > 0))
				{
					ArrayExtensions.Add(ref gparam_, cargo);
				}
			}
			if (bool_0 || gparam_.Count() > 0)
			{
				item.OnboardCargo = gparam_;
				Cargo theAC = new Cargo(activeUnit_1, item, (ICargoHost)activeUnit_1);
				ArrayExtensions.Add(ref activeUnit_1.OnboardCargo, theAC);
			}
		}
		return true;
	}

	public static bool UnloadContainerContentsToUnit(CargoContainer cargoContainer_0, List<CargoContainerContent> list_0, ActiveUnit activeUnit_0)
	{
		bool result = false;
		foreach (CargoContainerContent item in list_0)
		{
			Cargo[] onboardCargo = cargoContainer_0.OnboardCargo;
			Cargo[] array = onboardCargo;
			foreach (Cargo cargo in array)
			{
				if (cargo.CargoObjectContainerContents != null && cargo.CargoObjectContainerContents.isMatch(item))
				{
					CargoContainerContent cargoObjectContainerContents = cargo.CargoObjectContainerContents;
					float float_ = 1f;
					switch (item.ContentType)
					{
					case CargoContainerContent.CargoContainerContentType.LiquidFuel:
						float_ = ((CargoLiquidFuel)item).CurrentQuantity;
						break;
					case CargoContainerContent.CargoContainerContentType.Ammunition:
						float_ = item.GetCargoQuantity();
						break;
					}
					if (cargoObjectContainerContents.TransferToUnit(activeUnit_0, activeUnit_0, cargo, float_))
					{
						result = true;
					}
					if (cargoObjectContainerContents.GetCargoQuantity() <= 0)
					{
						ArrayExtensions.Remove(ref cargoContainer_0.OnboardCargo, cargo);
					}
					break;
				}
			}
		}
		return result;
	}

	public static bool LoadContainerContentsFromUnit(ActiveUnit activeUnit_0, CargoContainer cargoContainer_0, List<CargoContainerContent> list_0)
	{
		bool result = false;
		foreach (CargoContainerContent item in list_0)
		{
			float float_ = 1f;
			switch (item.ContentType)
			{
			case CargoContainerContent.CargoContainerContentType.LiquidFuel:
				float_ = ((CargoLiquidFuel)item).CurrentQuantity;
				break;
			case CargoContainerContent.CargoContainerContentType.Ammunition:
				float_ = item.GetCargoQuantity();
				break;
			}
			Cargo cargo_ = new Cargo(activeUnit_0, item, cargoContainer_0);
			if (item.TransferFromUnit(cargoContainer_0, activeUnit_0, cargo_, float_))
			{
				cargoContainer_0.Add(cargo_);
				result = true;
			}
		}
		return result;
	}

	public static int GetFuelMassInCargo(ActiveUnit activeUnit_0, FuelRec._FuelType _FuelType_0)
	{
		int num = 0;
		CargoContainer cargoContainer = null;
		CargoContainerContent cargoContainerContent = null;
		CargoLiquidFuel cargoLiquidFuel = null;
		Cargo[] onboardCargo = activeUnit_0.OnboardCargo;
		for (int i = 0; i < onboardCargo.Length; i = checked(i + 1))
		{
			cargoContainer = onboardCargo[i].CargoObjectContainer;
			if (cargoContainer == null || cargoContainer.ContainerType != CargoContainer.CargoContainerType.Tank)
			{
				continue;
			}
			cargoContainerContent = cargoContainer.CargoArray[0].CargoObjectContainerContents;
			if (cargoContainerContent != null && cargoContainerContent.ContentType == CargoContainerContent.CargoContainerContentType.LiquidFuel)
			{
				cargoLiquidFuel = (CargoLiquidFuel)cargoContainerContent;
				if (cargoLiquidFuel.FuelType == _FuelType_0 && cargoLiquidFuel.CurrentQuantity > 0f)
				{
					num += (int)Math.Round(cargoLiquidFuel.DeleteImporter(cargoLiquidFuel.CurrentQuantity));
				}
			}
		}
		return num;
	}

	public static bool UnloadCargoFuelToUnit(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, FuelRec._FuelType _FuelType_0 = FuelRec._FuelType.NoFuel, float float_0 = float.MaxValue)
	{
		if (activeUnit_0 != null && activeUnit_1 != null)
		{
			bool flag = _FuelType_0 == FuelRec._FuelType.NoFuel;
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			double num4 = 0.0;
			CargoContainer cargoContainer = null;
			CargoContainerContent cargoContainerContent = null;
			CargoLiquidFuel cargoLiquidFuel = null;
			foreach (FuelRec item in activeUnit_1.Fuel_ReadOnly)
			{
				if ((!flag && item.FuelType != _FuelType_0) || !(item.CurrentQuantity < (float)item.MaxQuantity))
				{
					continue;
				}
				num = (float)item.MaxQuantity - item.CurrentQuantity;
				if (num > float_0)
				{
					num = float_0;
				}
				Cargo[] onboardCargo = activeUnit_0.OnboardCargo;
				for (int i = 0; i < onboardCargo.Length; i = checked(i + 1))
				{
					cargoContainer = onboardCargo[i].CargoObjectContainer;
					if (cargoContainer == null || cargoContainer.ContainerType != CargoContainer.CargoContainerType.Tank)
					{
						continue;
					}
					Cargo cargo = cargoContainer.CargoArray[0];
					cargoContainerContent = cargo.CargoObjectContainerContents;
					if (cargoContainerContent == null || cargoContainerContent.ContentType != CargoContainerContent.CargoContainerContentType.LiquidFuel)
					{
						continue;
					}
					cargoLiquidFuel = (CargoLiquidFuel)cargoContainerContent;
					if (cargoLiquidFuel.FuelType == item.FuelType && cargoLiquidFuel.CurrentQuantity > 0f)
					{
						num2 = cargoLiquidFuel.MoveImporter(num);
						if (num2 <= cargoLiquidFuel.CurrentQuantity)
						{
							cargoLiquidFuel.CurrentQuantity -= num2;
							item.AddFuel(num);
							num4 += (double)num;
						}
						else
						{
							num3 = cargoLiquidFuel.DeleteImporter(cargoLiquidFuel.CurrentQuantity);
							cargoLiquidFuel.CurrentQuantity = 0f;
							item.AddFuel(num3);
							num4 += (double)num3;
						}
					}
					if (cargoLiquidFuel.CurrentQuantity == 0f)
					{
						cargoContainer.Remove(cargo);
					}
				}
				if (num4 < (double)float_0)
				{
					continue;
				}
				break;
			}
			if (num4 <= 0.0)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static int GetWeaponCountInCargo(ActiveUnit activeUnit_0, int int_0)
	{
		return 0;
	}

	public static bool UnloadCargoWeaponsToUnit(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, int int_0 = -1, int int_1 = int.MaxValue)
	{
		if (activeUnit_0 != null && activeUnit_1 != null)
		{
			bool flag = int_0 == -1;
			int num = 0;
			int num2 = 0;
			Magazine[] totalMagazines = activeUnit_1.TotalMagazines;
			for (int i = 0; i < totalMagazines.Length; i++)
			{
				foreach (WeaponRec weapon in totalMagazines[i].Weapons)
				{
					if (weapon.CurrentLoad >= weapon.MaxLoad || (!flag && weapon.int_0 != int_0))
					{
						continue;
					}
					num2 = weapon.MaxLoad - weapon.CurrentLoad;
					if (num + num2 <= int_1)
					{
						continue;
					}
					num2 = int_1 - num;
					if (num2 > 0)
					{
						Cargo[] onboardCargo = activeUnit_0.OnboardCargo;
						for (int j = 0; j < onboardCargo.Length; j = checked(j + 1))
						{
							CargoContainer cargoObjectContainer = onboardCargo[j].CargoObjectContainer;
							if (cargoObjectContainer != null && cargoObjectContainer.ContainerType != CargoContainer.CargoContainerType.Tank)
							{
								for (int k = cargoObjectContainer.CargoArray.Count() - 1; k >= 0; k += -1)
								{
									Cargo cargo = cargoObjectContainer.CargoArray[k];
									CargoContainerContent cargoObjectContainerContents = cargo.CargoObjectContainerContents;
									if (cargoObjectContainerContents != null && cargoObjectContainerContents.ContentType == CargoContainerContent.CargoContainerContentType.Ammunition)
									{
										CargoAmmunition cargoAmmunition = (CargoAmmunition)cargoObjectContainerContents;
										if (cargoAmmunition.int_0 == weapon.int_0 && cargoAmmunition.WeaponQuantity > 0)
										{
											if (num2 <= cargoAmmunition.WeaponQuantity)
											{
												weapon.CurrentLoad += num2;
												num += num2;
												cargoAmmunition.WeaponQuantity -= num2;
											}
											else
											{
												weapon.CurrentLoad += cargoAmmunition.WeaponQuantity;
												num += cargoAmmunition.WeaponQuantity;
												cargoAmmunition.WeaponQuantity = 0;
											}
										}
										if (cargoAmmunition.WeaponQuantity < 1)
										{
											Cargo[] gparam_ = cargoObjectContainer.CargoArray;
											ArrayExtensions.Remove(ref gparam_, cargo);
											cargoObjectContainer.CargoArray = gparam_;
										}
									}
									if (num >= int_1)
									{
										break;
									}
								}
							}
							if (num >= int_1)
							{
								break;
							}
						}
					}
					if (num < int_1)
					{
						continue;
					}
					break;
				}
			}
			if (num <= 0)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static List<CargoManifestItem> GenerateCargoManifest(List<Cargo> list_0, bool bool_0 = false)
	{
		List<CargoManifestItem> list = new List<CargoManifestItem>();
		if (list_0 == null)
		{
			return list;
		}
		foreach (Cargo item in list_0)
		{
			CargoManifestItem.Add(item, list, bool_0);
		}
		return list;
	}

	public static List<CargoManifestItem> GenerateCargoManifest(ActiveUnit activeUnit_0, bool bool_0 = true, bool bool_1 = false, bool bool_2 = false)
	{
		List<CargoManifestItem> list = new List<CargoManifestItem>();
		if (activeUnit_0 != null)
		{
			if (activeUnit_0.IsGroup && bool_2)
			{
				foreach (ActiveUnit value in ((Group)activeUnit_0).Units.Values)
				{
					Cargo[] onboardCargo = value.OnboardCargo;
					for (int i = 0; i < onboardCargo.Length; i = checked(i + 1))
					{
						CargoManifestItem.Add(onboardCargo[i], list, bool_1);
					}
				}
			}
			else
			{
				Cargo[] onboardCargo2 = activeUnit_0.OnboardCargo;
				for (int j = 0; j < onboardCargo2.Length; j = checked(j + 1))
				{
					CargoManifestItem.Add(onboardCargo2[j], list, bool_1);
				}
			}
		}
		if (bool_0)
		{
			if (activeUnit_0 is Vehicle)
			{
				Vehicle vehicle = (Vehicle)activeUnit_0;
				if (vehicle.GetRequiredCargoType() != 0)
				{
					CargoManifestItem.Add(new Cargo(null, vehicle), list);
				}
			}
			else if (activeUnit_0 is Facility)
			{
				Facility facility = (Facility)activeUnit_0;
				if (facility.GetRequiredCargoType() != 0)
				{
					CargoManifestItem.Add(new Cargo(null, facility), list);
				}
			}
			foreach (Mount mount in activeUnit_0.Mounts)
			{
				if (mount.Cargo_Type != 0)
				{
					CargoManifestItem.Add(new Cargo(activeUnit_0, mount), list);
				}
			}
			return list;
		}
		return list;
	}

	public static string CargoMassLabel(bool bool_0)
	{
		return "tons";
	}

	public static string CargoSmallMassLabel(bool bool_0)
	{
		if (bool_0)
		{
			return "pounds";
		}
		return "kilograms";
	}

	public static string CargoDistanceLabel(bool bool_0)
	{
		if (bool_0)
		{
			return "feet";
		}
		return "meters";
	}

	public static string CargoAreaLabel(bool bool_0)
	{
		if (bool_0)
		{
			return "sq.ft.";
		}
		return "sq.m.";
	}

	public static string CargoLiquidVolumeLabel(bool bool_0)
	{
		if (bool_0)
		{
			return "gallons";
		}
		return "liters";
	}

	public static float InputValueDistance(float float_0, bool bool_0)
	{
		if (bool_0)
		{
			return float_0 * 0.3048f;
		}
		return float_0;
	}

	public static float DisplayValueArea(float float_0, bool bool_0)
	{
		if (bool_0)
		{
			return float_0 * 10.76391f;
		}
		return float_0;
	}

	public static float InputValueArea(float float_0, bool bool_0)
	{
		if (bool_0)
		{
			return float_0 / 10.76391f;
		}
		return float_0;
	}

	public static float DisplayValueMass(float float_0, bool bool_0)
	{
		if (bool_0)
		{
			return float_0 * 1.102311f;
		}
		return float_0;
	}

	public static float InputValueMass(float float_0, bool bool_0)
	{
		if (bool_0)
		{
			return float_0 / 1.102311f;
		}
		return float_0;
	}

	public static float DisplayValueSmallMass(float float_0, bool bool_0)
	{
		if (bool_0)
		{
			return float_0 * 2.204623f;
		}
		return float_0;
	}

	public static float InputValueSmallMass(float float_0, bool bool_0)
	{
		if (bool_0)
		{
			return float_0 / 2.204623f;
		}
		return float_0;
	}

	public static float InputValueLiquidVolume(float float_0, bool bool_0)
	{
		if (bool_0)
		{
			return float_0 / 0.2641729f;
		}
		return float_0;
	}

	public static float DisplayValueLiquidVolume(float float_0, bool bool_0)
	{
		if (bool_0)
		{
			return float_0 * 0.2641729f;
		}
		return float_0;
	}

	public static string CanUnloadToMap(ActiveUnit activeUnit_0)
	{
		if (activeUnit_0 != null && activeUnit_0 is ICargoHost)
		{
			if (activeUnit_0.IsOperating())
			{
				ICargoHost cargoHost = (ICargoHost)activeUnit_0;
				if (cargoHost.CargoArray.Count() == 0)
				{
					return "The unit is not currently carrying cargo.";
				}
				if (activeUnit_0.IsAircraft)
				{
					Aircraft aircraft = (Aircraft)activeUnit_0;
					if (Module_Unit.ResetTokenizer(aircraft))
					{
						if (aircraft.IsHelicopter)
						{
							return "Ok";
						}
						if (cargoHost.GetCargo_ParadropCapable())
						{
							Cargo[] cargoArray = cargoHost.CargoArray;
							for (int i = 0; i < cargoArray.Length; i = checked(i + 1))
							{
								if (cargoArray[i].isParadropCapable)
								{
									return "Ok";
								}
							}
							return "None of the cargo on board can be paradropped.";
						}
						return "The aircraft's loadout is not capable of cargo paradrop.";
					}
					return "The aircraft is not curently over land.";
				}
				if (activeUnit_0.IsShip)
				{
					if (activeUnit_0.DockingOps.RegisterClient())
					{
						if (activeUnit_0.DockingOps.RevertClient().Count <= 0)
						{
							return "The ship is too far from land (more than 2nm) to unload cargo ashore.";
						}
						return "Ok";
					}
					return "The ship cannot unload cargo directly to the shore.";
				}
				if (activeUnit_0.IsVehicle)
				{
					if (Module_Unit.ResetTokenizer(activeUnit_0))
					{
						return "Ok";
					}
					return "The ground unit is not currently on land.";
				}
				if (activeUnit_0.IsFixedFacility)
				{
					if (Module_Unit.ResetTokenizer(activeUnit_0))
					{
						return "Ok";
					}
					return "The facility is not on land.";
				}
				return "Unsupported unit type.";
			}
			return "The unit is currently hosted by another unit.";
		}
		return "The unit is not cargo capable.";
	}

	public static List<ActiveUnit> GetPossibleTransferDestinations(ActiveUnit activeUnit_0)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		if (activeUnit_0 != null && (activeUnit_0.IsVehicle || activeUnit_0.IsFixedFacility))
		{
			List<ActiveUnit> units = activeUnit_0.GetUnitSide().Units;
			bool isFixedFacility = activeUnit_0.IsFixedFacility;
			foreach (ActiveUnit item in units)
			{
				if (item != activeUnit_0 && item.IsOperating() && item is ICargoHost && ((ICargoHost)item).GetCargo_Type() != 0 && (item.IsFixedFacility || (item.IsVehicle && isFixedFacility)))
				{
					if (activeUnit_0.IsFixedFacility && item.IsFixedFacility && activeUnit_0.GetParentGroup() != null && activeUnit_0.GetParentGroup() == item.GetParentGroup())
					{
						list.Add(item);
					}
					else if (Module_Unit.RangeToUnit_Horiz(item, activeUnit_0) < 2f)
					{
						list.Add(item);
					}
				}
			}
			return list;
		}
		return list;
	}

	public static ActiveUnit GetGroupCargoDestinationUnit(Group group_0, ActiveUnit activeUnit_0, Cargo cargo_0)
	{
		if (group_0 != null && activeUnit_0 != null && cargo_0 != null)
		{
			List<ActiveUnit> list = group_0.Units.Values.ToList();
			ActiveUnit activeUnit = null;
			ActiveUnit activeUnit2 = null;
			float num = float.MaxValue;
			if (activeUnit_0.AssignedMissionOrPackage() != null && activeUnit_0.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Cargo)
			{
				activeUnit = ((CargoMission)activeUnit_0.AssignedMissionOrPackage()).DestinationUnit;
			}
			foreach (ActiveUnit item in list)
			{
				if (item == activeUnit_0 || item.IsDestroyed)
				{
					continue;
				}
				if (item != activeUnit)
				{
					if (item is ICargoHost && ((ICargoHost)item).CanLoad(cargo_0.GetCargoClient))
					{
						if (item.OnboardCargo.Count() > 0)
						{
							return item;
						}
						float num2 = Module_Unit.RangeToUnit_Horiz(item, activeUnit_0);
						if (num2 < num)
						{
							activeUnit2 = item;
							num = num2;
						}
					}
					continue;
				}
				return item;
			}
			if (activeUnit2 == null)
			{
				activeUnit2 = ((list.Count <= 0) ? group_0 : list[0]);
			}
			return activeUnit2;
		}
		return null;
	}
}
