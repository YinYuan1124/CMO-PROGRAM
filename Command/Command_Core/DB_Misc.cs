using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class DB_Misc
{
	private static HashSet<int> _RequestIssuer;

	private static HashSet<int> valueIssuer;

	private static HashSet<int> m_TokenizerIssuer;

	private static HashSet<int> _StubIssuer;

	private static HashSet<int> _WriterIssuer;

	private static HashSet<int> specificationIssuer;

	private static HashSet<int> _WatcherIssuer;

	private static HashSet<int> _ReponseIssuer;

	private static HashSet<int> _DescriptorIssuer;

	private static HashSet<int> _PoolIssuer;

	private static HashSet<int> taskIssuer;

	private static HashSet<int> m_FilterIssuer;

	private static HashSet<int> testsIssuer;

	private static HashSet<int> m_InterpreterIssuer;

	private static HashSet<int> m_ContainerIssuer;

	private static HashSet<int> m_ComposerIssuer;

	private static HashSet<int> modelIssuer;

	static DB_Misc()
	{
		_RequestIssuer = new HashSet<int>();
		valueIssuer = new HashSet<int>();
		m_TokenizerIssuer = new HashSet<int>();
		_StubIssuer = new HashSet<int>();
		_WriterIssuer = new HashSet<int>();
		specificationIssuer = new HashSet<int>();
		_WatcherIssuer = new HashSet<int>();
		_ReponseIssuer = new HashSet<int>();
		_DescriptorIssuer = new HashSet<int>();
		_PoolIssuer = new HashSet<int>();
		taskIssuer = new HashSet<int>();
		m_FilterIssuer = new HashSet<int>();
		testsIssuer = new HashSet<int>();
		m_InterpreterIssuer = new HashSet<int>();
		m_ContainerIssuer = new HashSet<int>();
		m_ComposerIssuer = new HashSet<int>();
		modelIssuer = new HashSet<int>();
	}

	public static void BindScenToCustomDB(Scenario scenario_0, ref string string_0)
	{
		DBOps.DBFileCheckResult dbfileCheckResult_ = DBOps.DBFileCheckResult.Undefined;
		DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(scenario_0.DBUsed, ref dbfileCheckResult_);
		if (dBRecordByHash == null)
		{
			throw new Exception(DBOps.PublishImporter(dbfileCheckResult_));
		}
		string text = Guid.NewGuid().ToString() + Path.GetExtension(dBRecordByHash.FileName);
		File.Copy(Path.Combine(GameGeneral.DBFolderPath, dBRecordByHash.FileName), Path.Combine(GameGeneral.DBFolderPath, text));
		SQLiteHelper sQLiteHelper = new SQLiteHelper(new SQLiteConnection("Data Source=" + Path.Combine(GameGeneral.DBFolderPath, text) + ";Version=3"));
		CloneRepository(scenario_0);
		StripTables(sQLiteHelper);
		sQLiteHelper.ExecuteNonQuery("VACUUM");
		string fileHashFromFilename = Crypto.GetFileHashFromFilename(Path.Combine(GameGeneral.DBFolderPath, text));
		DBRecord dbrecord_ = new DBRecord(dBRecordByHash.DBID, fileHashFromFilename, text, text);
		DBOps.AddUnregisteredDB(fileHashFromFilename, dbrecord_);
		scenario_0.DBUsed = fileHashFromFilename;
		string_0 = Path.Combine(GameGeneral.DBFolderPath, text);
	}

	private static void CloneRepository(Scenario scenario_0)
	{
		_RequestIssuer.Clear();
		valueIssuer.Clear();
		m_TokenizerIssuer.Clear();
		_StubIssuer.Clear();
		_WriterIssuer.Clear();
		specificationIssuer.Clear();
		_WatcherIssuer.Clear();
		_ReponseIssuer.Clear();
		_DescriptorIssuer.Clear();
		_PoolIssuer.Clear();
		taskIssuer.Clear();
		m_FilterIssuer.Clear();
		testsIssuer.Clear();
		m_InterpreterIssuer.Clear();
		m_ContainerIssuer.Clear();
		m_ComposerIssuer.Clear();
		modelIssuer.Clear();
		foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
		{
			if (activeUnits_ != null)
			{
				ConnectRepository(activeUnits_, scenario_0);
			}
		}
		foreach (UnguidedWeapon value in scenario_0.UnguidedWeapons.Values)
		{
			_WatcherIssuer.Add(value.ReferenceWeapon.DBID);
		}
	}

	private static void ConnectRepository(object object_0, Scenario scenario_0)
	{
		switch (((ActiveUnit)object_0).UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			_RequestIssuer.Add(((ActiveUnit)object_0).DBID);
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			m_TokenizerIssuer.Add(((ActiveUnit)object_0).DBID);
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			_StubIssuer.Add(((ActiveUnit)object_0).DBID);
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			valueIssuer.Add(((ActiveUnit)object_0).DBID);
			break;
		case GlobalVariables.ActiveUnitType.Weapon:
			_WatcherIssuer.Add(((ActiveUnit)object_0).DBID);
			break;
		case GlobalVariables.ActiveUnitType.Satellite:
			_WriterIssuer.Add(((ActiveUnit)object_0).DBID);
			break;
		}
		Sensor[] sensors_Cached = ((ActiveUnit)object_0).Sensors_Cached;
		Sensor[] array = sensors_Cached;
		foreach (Sensor sensor in array)
		{
			if (!sensor.m_IsMk1Eyeball)
			{
				specificationIssuer.Add(sensor.DBID);
			}
		}
		CommDevice[] commDevices;
		foreach (Mount mount in ((ActiveUnit)object_0).Mounts)
		{
			_ReponseIssuer.Add(mount.DBID);
			if (!Information.IsNothing(mount.MountMagazine))
			{
				_DescriptorIssuer.Add(mount.MountMagazine.DBID);
			}
			sensors_Cached = mount.Sensors_ReadOnly;
			Sensor[] array2 = sensors_Cached;
			foreach (Sensor sensor2 in array2)
			{
				specificationIssuer.Add(sensor2.DBID);
			}
			commDevices = mount.CommDevices;
			CommDevice[] array3 = commDevices;
			foreach (CommDevice commDevice in array3)
			{
				taskIssuer.Add(commDevice.DBID);
			}
			foreach (WeaponRec mountWeapon in mount.MountWeapons)
			{
				if (mountWeapon.WRecDBID.HasValue)
				{
					modelIssuer.Add(mountWeapon.WRecDBID.Value);
				}
				ConnectRepository(mountWeapon.GetReferenceWeapon(scenario_0), scenario_0);
			}
		}
		if (!Information.IsNothing(((ActiveUnit)object_0).SharedMagazines))
		{
			Magazine[] sharedMagazines = ((ActiveUnit)object_0).SharedMagazines;
			Magazine[] array4 = sharedMagazines;
			foreach (Magazine magazine in array4)
			{
				_DescriptorIssuer.Add(magazine.DBID);
			}
		}
		if (((ScenarioObject)object_0).IsAircraft)
		{
			foreach (Loadout item in DBFunctions.LoadoutsForThisAircraft(((ActiveUnit)object_0).DBID, scenario_0))
			{
				_PoolIssuer.Add(item.DBID);
				WeaponRec[] weapons = item.Weapons;
				WeaponRec[] array5 = weapons;
				foreach (WeaponRec weaponRec in array5)
				{
					if (weaponRec.WRecDBID.HasValue)
					{
						modelIssuer.Add(weaponRec.WRecDBID.Value);
					}
					ConnectRepository(weaponRec.GetReferenceWeapon(scenario_0), scenario_0);
				}
				foreach (Sensor item2 in item.NewClass(scenario_0))
				{
					specificationIssuer.Add(item2.DBID);
				}
			}
		}
		if (((ScenarioObject)object_0).IsWeapon)
		{
			Warhead[] warheads = ((Weapon)object_0).Warheads;
			Warhead[] array6 = warheads;
			foreach (Warhead warhead in array6)
			{
				testsIssuer.Add(warhead.DBID);
			}
		}
		foreach (WeaponRec value in ((ActiveUnit)object_0).Weaponry.AllDistinctWeaponsAboard_Potential_WeaponRecs(bool_1: true).Values)
		{
			if (value.WRecDBID.HasValue)
			{
				modelIssuer.Add(value.WRecDBID.Value);
			}
			ConnectRepository(value.GetReferenceWeapon(scenario_0), scenario_0);
		}
		commDevices = ((ActiveUnit)object_0).Comms_ReadOnly;
		CommDevice[] array7 = commDevices;
		foreach (CommDevice commDevice2 in array7)
		{
			taskIssuer.Add(commDevice2.DBID);
		}
		foreach (Engine item3 in ((ActiveUnit)object_0).Propulsion)
		{
			m_FilterIssuer.Add(item3.DBID);
		}
		AirFacility[] airFacilities_ReadOnly = ((ActiveUnit)object_0).AirFacilities_ReadOnly;
		AirFacility[] array8 = airFacilities_ReadOnly;
		foreach (AirFacility airFacility in array8)
		{
			m_InterpreterIssuer.Add(airFacility.DBID);
		}
		DockFacility[] dockFacilities_ReadOnly = ((ActiveUnit)object_0).DockFacilities_ReadOnly;
		DockFacility[] array9 = dockFacilities_ReadOnly;
		foreach (DockFacility dockFacility in array9)
		{
			m_ContainerIssuer.Add(dockFacility.DBID);
		}
		foreach (FuelRec item4 in ((ActiveUnit)object_0).Fuel_ReadOnly)
		{
			if (item4.DBID.HasValue)
			{
				m_ComposerIssuer.Add(item4.DBID.Value);
			}
		}
	}

	public static void StripTables(SQLiteHelper sqliteHelper_0)
	{
		string string_ = "DELETE FROM DataAircraft WHERE NOT ID IN (" + string.Join(",", _RequestIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataAircraftCodes WHERE NOT ID IN (" + string.Join(",", _RequestIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataAircraftComms WHERE NOT ID IN (" + string.Join(",", _RequestIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataAircraftFacility WHERE NOT ID IN (" + string.Join(",", m_InterpreterIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataAircraftFuel WHERE NOT ID IN (" + string.Join(",", _RequestIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataAircraftLoadouts WHERE NOT ID IN (" + string.Join(",", _RequestIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataAircraftMounts WHERE NOT ID IN (" + string.Join(",", _RequestIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataAircraftPropulsion WHERE NOT ID IN (" + string.Join(",", _RequestIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataAircraftSensors WHERE NOT ID IN (" + string.Join(",", _RequestIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataAircraftSignatures WHERE NOT ID IN (" + string.Join(",", _RequestIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataComm WHERE NOT ID IN (" + string.Join(",", taskIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataCommCapabilities WHERE NOT ID IN (" + string.Join(",", taskIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataCommDirectors WHERE NOT ID IN (" + string.Join(",", taskIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataDockingFacility WHERE NOT ID IN (" + string.Join(",", m_ContainerIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFacility WHERE NOT ID IN (" + string.Join(",", valueIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFacilityAircraftFacilities WHERE NOT ID IN (" + string.Join(",", valueIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFacilityComms WHERE NOT ID IN (" + string.Join(",", valueIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFacilityDockingFacilities WHERE NOT ID IN (" + string.Join(",", valueIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFacilityFuel WHERE NOT ID IN (" + string.Join(",", valueIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFacilityMagazines WHERE NOT ID IN (" + string.Join(",", valueIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFacilityMounts WHERE NOT ID IN (" + string.Join(",", valueIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFacilitySensors WHERE NOT ID IN (" + string.Join(",", valueIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFacilitySignatures WHERE NOT ID IN (" + string.Join(",", valueIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataFuel WHERE NOT ID IN (" + string.Join(",", m_ComposerIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataLoadout WHERE NOT ID IN (" + string.Join(",", _PoolIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataLoadoutWeapons WHERE NOT ID IN (" + string.Join(",", _PoolIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataMagazine WHERE NOT ID IN (" + string.Join(",", _DescriptorIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataMagazineWeapons WHERE NOT ID IN (" + string.Join(",", _DescriptorIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataMount WHERE NOT ID IN (" + string.Join(",", _ReponseIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataMountComms WHERE NOT ID IN (" + string.Join(",", _ReponseIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataMountDirectors WHERE NOT ID IN (" + string.Join(",", _ReponseIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataMountMagazineWeapons WHERE NOT ID IN (" + string.Join(",", _ReponseIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataMountSensors WHERE NOT ID IN (" + string.Join(",", _ReponseIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataMountWeapons WHERE NOT ID IN (" + string.Join(",", _ReponseIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataPropulsion WHERE NOT ID IN (" + string.Join(",", m_FilterIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataPropulsionPerformance WHERE NOT ID IN (" + string.Join(",", m_FilterIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSatellite WHERE NOT ID IN (" + string.Join(",", _WriterIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSatelliteCodes WHERE NOT ID IN (" + string.Join(",", _WriterIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSatelliteComms WHERE NOT ID IN (" + string.Join(",", _WriterIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSatelliteMounts WHERE NOT ID IN (" + string.Join(",", _WriterIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSatelliteOrbits WHERE NOT ID IN (" + string.Join(",", _WriterIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSatelliteSensors WHERE NOT ID IN (" + string.Join(",", _WriterIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSatelliteSignatures WHERE NOT ID IN (" + string.Join(",", _WriterIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSensor WHERE NOT ID IN (" + string.Join(",", specificationIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSensorCapabilities WHERE NOT ID IN (" + string.Join(",", specificationIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSensorCodes WHERE NOT ID IN (" + string.Join(",", specificationIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSensorFrequencyIlluminate WHERE NOT ID IN (" + string.Join(",", specificationIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSensorFrequencySearchAndTrack WHERE NOT ID IN (" + string.Join(",", specificationIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSensorSensorGroups WHERE NOT ID IN (" + string.Join(",", specificationIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShip WHERE NOT ID IN (" + string.Join(",", m_TokenizerIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipAircraftFacilities WHERE NOT ID IN (" + string.Join(",", m_TokenizerIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipCodes WHERE NOT ID IN (" + string.Join(",", m_TokenizerIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipComms WHERE NOT ID IN (" + string.Join(",", m_TokenizerIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipDockingFacilities WHERE NOT ID IN (" + string.Join(",", m_TokenizerIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipFuel WHERE NOT ID IN (" + string.Join(",", m_TokenizerIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipMagazines WHERE NOT ID IN (" + string.Join(",", m_TokenizerIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipMounts WHERE NOT ID IN (" + string.Join(",", m_TokenizerIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipPropulsion WHERE NOT ID IN (" + string.Join(",", m_TokenizerIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipSensors WHERE NOT ID IN (" + string.Join(",", m_TokenizerIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataShipSignatures WHERE NOT ID IN (" + string.Join(",", m_TokenizerIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarine WHERE NOT ID IN (" + string.Join(",", _StubIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarineCodes WHERE NOT ID IN (" + string.Join(",", _StubIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarineComms WHERE NOT ID IN (" + string.Join(",", _StubIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarineDockingFacilities WHERE NOT ID IN (" + string.Join(",", _StubIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarineFuel WHERE NOT ID IN (" + string.Join(",", _StubIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarineMagazines WHERE NOT ID IN (" + string.Join(",", _StubIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarineMounts WHERE NOT ID IN (" + string.Join(",", _StubIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarinePropulsion WHERE NOT ID IN (" + string.Join(",", _StubIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarineSensors WHERE NOT ID IN (" + string.Join(",", _StubIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataSubmarineSignatures WHERE NOT ID IN (" + string.Join(",", _StubIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWarhead WHERE NOT ID IN (" + string.Join(",", testsIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeapon WHERE NOT ID IN (" + string.Join(",", _WatcherIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponCodes WHERE NOT ID IN (" + string.Join(",", _WatcherIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponComms WHERE NOT ID IN (" + string.Join(",", _WatcherIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponDirectors WHERE NOT ID IN (" + string.Join(",", _WatcherIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponFuel WHERE NOT ID IN (" + string.Join(",", _WatcherIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponPropulsion WHERE NOT ID IN (" + string.Join(",", _WatcherIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponRecord WHERE NOT ID IN (" + string.Join(",", modelIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponSensors WHERE NOT ID IN (" + string.Join(",", _WatcherIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponSignatures WHERE NOT ID IN (" + string.Join(",", _WatcherIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponTargets WHERE NOT ID IN (" + string.Join(",", _WatcherIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponWarheads WHERE NOT ID IN (" + string.Join(",", _WatcherIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponWeapons WHERE NOT ID IN (" + string.Join(",", _WatcherIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
		string_ = "DELETE FROM DataWeaponWRA WHERE NOT ID IN (" + string.Join(",", _WatcherIssuer) + ")";
		sqliteHelper_0.ExecuteNonQuery(string_);
	}
}
