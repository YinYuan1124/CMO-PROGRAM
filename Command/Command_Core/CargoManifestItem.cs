using System.Collections.Generic;
using System.Data.SQLite;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscateType]
public sealed class CargoManifestItem
{
	public Cargo.CargoObjectType objectType;

	public int DBID;

	public int quantity;

	public string _Name;

	public string ObjectID;

	public string Name
	{
		get
		{
			if (objectType == Cargo.CargoObjectType.Mount)
			{
				return Conversions.ToString(quantity) + "x " + _Name;
			}
			return _Name;
		}
	}

	public string NameNoQuantity => _Name;

	public void GenerateName(Scenario scenario_0)
	{
		if (!string.IsNullOrEmpty(_Name))
		{
			return;
		}
		if (scenario_0 == null)
		{
			_Name = "(unknown)";
			return;
		}
		if (!string.IsNullOrEmpty(ObjectID) && scenario_0.ActiveUnits.ContainsKey(ObjectID))
		{
			_Name = scenario_0.ActiveUnits[ObjectID].Name;
			return;
		}
		switch (objectType)
		{
		case Cargo.CargoObjectType.Mount:
			_Name = DBFunctions.GetMountName(DBID, ref scenario_0);
			break;
		case Cargo.CargoObjectType.Vehicle:
		{
			int dBID3 = DBID;
			SQLiteConnection sqliteConnection_3 = scenario_0.DBConnection;
			_Name = DBFunctions.GetVehicleName(dBID3, ref sqliteConnection_3);
			break;
		}
		case Cargo.CargoObjectType.Facility:
		{
			int dBID2 = DBID;
			SQLiteConnection sqliteConnection_2 = scenario_0.DBConnection;
			_Name = DBFunctions.GetFacilityName(dBID2, ref sqliteConnection_2);
			break;
		}
		case Cargo.CargoObjectType.CargoContainer:
		{
			int dBID = DBID;
			SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
			_Name = DBFunctions.GetCargoContainerName(dBID, ref sqliteConnection_);
			break;
		}
		}
	}

	public CargoManifestItem(Cargo cargo_0)
	{
		objectType = cargo_0.CurrentType;
		DBID = cargo_0.CargoObjectDBID;
		quantity = 1;
		_Name = cargo_0.CargoObjectName;
		if (objectType != Cargo.CargoObjectType.Mount)
		{
			ObjectID = cargo_0.CargoObjectID;
		}
	}

	public CargoManifestItem(Cargo.CargoObjectType cargoObjectType_0, int int_0, string string_0 = "")
	{
		objectType = cargoObjectType_0;
		DBID = int_0;
		quantity = 1;
		ObjectID = string_0;
	}

	public CargoManifestItem(CargoManifestItem cargoManifestItem_0)
	{
		objectType = cargoManifestItem_0.objectType;
		DBID = cargoManifestItem_0.DBID;
		quantity = cargoManifestItem_0.quantity;
		_Name = cargoManifestItem_0._Name;
		ObjectID = cargoManifestItem_0.ObjectID;
	}

	public static void Add(Cargo cargo_0, List<CargoManifestItem> list_0, bool bool_0 = false)
	{
		if (cargo_0 == null || list_0 == null)
		{
			return;
		}
		if (!bool_0 && cargo_0.InternalObjectType != Cargo.CargoObjectType.Mount)
		{
			CargoManifestItem item = new CargoManifestItem(cargo_0);
			list_0.Add(item);
			return;
		}
		CargoManifestItem cargoManifestItem = FindMatch(cargo_0, list_0);
		if (cargoManifestItem == null)
		{
			cargoManifestItem = new CargoManifestItem(cargo_0);
			if (bool_0 && cargo_0.CargoObjectActiveUnit != null)
			{
				cargoManifestItem._Name = cargo_0.CargoObjectActiveUnit.UnitClass;
				cargoManifestItem.ObjectID = null;
			}
			list_0.Add(cargoManifestItem);
		}
		else
		{
			cargoManifestItem.quantity++;
		}
	}

	public static void Add(CargoManifestItem cargoManifestItem_0, List<CargoManifestItem> list_0)
	{
		if (cargoManifestItem_0 == null || list_0 == null)
		{
			return;
		}
		if (cargoManifestItem_0.objectType == Cargo.CargoObjectType.Mount)
		{
			CargoManifestItem cargoManifestItem = FindMatch(cargoManifestItem_0, list_0);
			if (cargoManifestItem == null)
			{
				cargoManifestItem = new CargoManifestItem(cargoManifestItem_0.objectType, cargoManifestItem_0.DBID, cargoManifestItem_0.ObjectID);
				cargoManifestItem.quantity = cargoManifestItem_0.quantity;
				list_0.Add(cargoManifestItem);
			}
			else
			{
				cargoManifestItem.quantity += cargoManifestItem_0.quantity;
			}
		}
		else
		{
			CargoManifestItem item = new CargoManifestItem(cargoManifestItem_0.objectType, cargoManifestItem_0.DBID, cargoManifestItem_0.ObjectID);
			list_0.Add(item);
		}
	}

	public static bool Remove(Cargo cargo_0, List<CargoManifestItem> list_0)
	{
		if (cargo_0 != null && list_0 != null)
		{
			CargoManifestItem cargoManifestItem = FindMatch(cargo_0, list_0);
			if (cargoManifestItem != null)
			{
				cargoManifestItem.quantity--;
				if (cargoManifestItem.quantity < 1)
				{
					list_0.Remove(cargoManifestItem);
				}
				return true;
			}
		}
		return false;
	}

	public static bool Remove(CargoManifestItem cargoManifestItem_0, List<CargoManifestItem> list_0)
	{
		if (cargoManifestItem_0 != null && list_0 != null)
		{
			CargoManifestItem cargoManifestItem = FindMatch(cargoManifestItem_0, list_0);
			if (cargoManifestItem != null)
			{
				cargoManifestItem.quantity -= cargoManifestItem_0.quantity;
				if (cargoManifestItem.quantity < 1)
				{
					list_0.Remove(cargoManifestItem);
				}
				return true;
			}
		}
		return false;
	}

	public bool IsMatch(Cargo cargo_0)
	{
		if (cargo_0 != null && cargo_0.CurrentType == objectType && cargo_0.CargoObjectDBID == DBID)
		{
			if (!string.IsNullOrEmpty(ObjectID) && !string.IsNullOrEmpty(cargo_0.CargoObjectID))
			{
				return Operators.CompareString(cargo_0.CargoObjectID, ObjectID, TextCompare: false) == 0;
			}
			return true;
		}
		return false;
	}

	public bool IsMatch(CargoManifestItem cargoManifestItem_0)
	{
		if (cargoManifestItem_0 == null)
		{
			return false;
		}
		if (cargoManifestItem_0.objectType == objectType)
		{
			return cargoManifestItem_0.DBID == DBID;
		}
		return false;
	}

	public static CargoManifestItem FindMatch(Cargo cargo_0, List<CargoManifestItem> list_0)
	{
		if (cargo_0 != null && list_0 != null)
		{
			foreach (CargoManifestItem item in list_0)
			{
				if (item.IsMatch(cargo_0))
				{
					return item;
				}
			}
		}
		return null;
	}

	public static CargoManifestItem FindMatch(CargoManifestItem cargoManifestItem_0, List<CargoManifestItem> list_0)
	{
		if (cargoManifestItem_0 != null && list_0 != null)
		{
			foreach (CargoManifestItem item in list_0)
			{
				if (item.objectType == cargoManifestItem_0.objectType && item.DBID == cargoManifestItem_0.DBID && (string.IsNullOrEmpty(item.ObjectID) || string.IsNullOrEmpty(cargoManifestItem_0.ObjectID) || Operators.CompareString(item.ObjectID, cargoManifestItem_0.ObjectID, TextCompare: false) == 0))
				{
					return item;
				}
			}
		}
		return null;
	}
}
