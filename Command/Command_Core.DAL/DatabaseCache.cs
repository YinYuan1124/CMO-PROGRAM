using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using OpenDis.Pages;

namespace Command_Core.DAL;

public class DatabaseCache
{
	[CompilerGenerated]
	private sealed class FactoryMerchantService
	{
		public SQLiteConnection Local_dBConnection;

		public Action<(GlobalVariables.ActiveUnitType, int)> _003C_003E9__1;

		internal void ReadInterruptibleParam((GlobalVariables.ActiveUnitType, int) theTuple)
		{
			DBFunctions.EW_GetAllPossibleEmissionsForThisUnit(theTuple.Item1, theTuple.Item2, Local_dBConnection);
		}
	}

	[CompilerGenerated]
	private sealed class ParserConfigObject
	{
		public DataTable Local_theTable;

		public List<(GlobalVariables.ActiveUnitType, int)> Local_theList;

		public FactoryMerchantService CS_0024_003C_003E8__locals1;

		internal void DisableInterruptibleParam()
		{
			int num = 1;
			IEnumerator enumerator = null;
			while (true)
			{
				GlobalVariables.ActiveUnitType item = GlobalVariables.ActiveUnitType.Aircraft;
				Local_theTable = DBFunctions.GetAllAircraft(CS_0024_003C_003E8__locals1.Local_dBConnection);
				while (true)
				{
					try
					{
						enumerator = Local_theTable.Rows.GetEnumerator();
						while (enumerator.MoveNext())
						{
							DataRow dataRow = (DataRow)enumerator.Current;
							Local_theList.Add((item, Conversions.ToInteger(dataRow["ID"])));
						}
					}
					finally
					{
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					num++;
					if (num <= 7)
					{
						switch (num)
						{
						case 2:
							item = GlobalVariables.ActiveUnitType.Weapon;
							Local_theTable = DBFunctions.GetAllWeapons(CS_0024_003C_003E8__locals1.Local_dBConnection);
							continue;
						case 3:
							item = GlobalVariables.ActiveUnitType.Ship;
							Local_theTable = DBFunctions.GetAllShips(CS_0024_003C_003E8__locals1.Local_dBConnection);
							continue;
						case 4:
							item = GlobalVariables.ActiveUnitType.Submarine;
							Local_theTable = DBFunctions.GetAllSubmarines(CS_0024_003C_003E8__locals1.Local_dBConnection);
							continue;
						case 5:
							item = GlobalVariables.ActiveUnitType.Facility;
							Local_theTable = DBFunctions.GetAllFacilities(CS_0024_003C_003E8__locals1.Local_dBConnection);
							continue;
						case 6:
							item = GlobalVariables.ActiveUnitType.Satellite;
							Local_theTable = DBFunctions.GetAllSatellites(CS_0024_003C_003E8__locals1.Local_dBConnection);
							continue;
						case 7:
							item = GlobalVariables.ActiveUnitType.Vehicle;
							Local_theTable = DBFunctions.GetAllGroundUnits(CS_0024_003C_003E8__locals1.Local_dBConnection);
							continue;
						default:
							continue;
						case 1:
							break;
						}
						break;
					}
					try
					{
						Parallel.ForEach(Local_theList, delegate((GlobalVariables.ActiveUnitType, int) theTuple)
						{
							DBFunctions.EW_GetAllPossibleEmissionsForThisUnit(theTuple.Item1, theTuple.Item2, CS_0024_003C_003E8__locals1.Local_dBConnection);
						});
						return;
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
						return;
					}
				}
			}
		}
	}

	public DataTable Cache_Aircraft_DT;

	public DataTable Cache_Ships_DT;

	public DataTable Cache_Subs_DT;

	public DataTable Cache_Facilities_DT;

	public DataTable Cache_GroundUnits_DT;

	public DataTable Cache_Satellites_DT;

	public DataTable Cache_Weapons_DT;

	public DataTable Cache_OperatorCountries_DT;

	public string CacheVersion_DT;

	public ConcurrentDictionary<string, HashSet<int>> Cache_AllPossibleEmissionsPerUnit;

	public DatabaseCache()
	{
		Cache_Aircraft_DT = new DataTable();
		Cache_Ships_DT = new DataTable();
		Cache_Subs_DT = new DataTable();
		Cache_Facilities_DT = new DataTable();
		Cache_GroundUnits_DT = new DataTable();
		Cache_Satellites_DT = new DataTable();
		Cache_Weapons_DT = new DataTable();
		Cache_OperatorCountries_DT = new DataTable();
		Cache_AllPossibleEmissionsPerUnit = new ConcurrentDictionary<string, HashSet<int>>();
	}

	public void BuildCache(string string_0, SQLiteConnection sqliteConnection_0 = null)
	{
		if (string.IsNullOrEmpty(string_0) || (Operators.CompareString(string_0, CacheVersion_DT, TextCompare: false) == 0 && Cache_Aircraft_DT.Rows.Count > 0))
		{
			return;
		}
		try
		{
			if (sqliteConnection_0 == null)
			{
				sqliteConnection_0 = new SQLiteConnection(DBOps.smethod_1(MerchantMerchantPage.LogoutList.Info.DirectoryPath, string_0));
			}
			CacheVersion_DT = string_0;
			new List<int>();
			DataTable Local_theTable = null;
			List<(GlobalVariables.ActiveUnitType, int)> Local_theList = new List<(GlobalVariables.ActiveUnitType, int)>();
			DBFunctions.GetPlatformLists(ref Cache_Aircraft_DT, ref Cache_Ships_DT, ref Cache_Subs_DT, ref Cache_Facilities_DT, ref Cache_GroundUnits_DT, ref Cache_Satellites_DT, ref Cache_Weapons_DT, ref sqliteConnection_0);
			Cache_OperatorCountries_DT = DBFunctions.GetAllCountries(ref sqliteConnection_0);
			Task.Factory.StartNew(delegate
			{
				int num = 1;
				IEnumerator enumerator = null;
				while (true)
				{
					GlobalVariables.ActiveUnitType item = GlobalVariables.ActiveUnitType.Aircraft;
					Local_theTable = DBFunctions.GetAllAircraft(sqliteConnection_0);
					while (true)
					{
						try
						{
							enumerator = Local_theTable.Rows.GetEnumerator();
							while (enumerator.MoveNext())
							{
								DataRow dataRow = (DataRow)enumerator.Current;
								Local_theList.Add((item, Conversions.ToInteger(dataRow["ID"])));
							}
						}
						finally
						{
							if (enumerator is IDisposable)
							{
								(enumerator as IDisposable).Dispose();
							}
						}
						num++;
						if (num <= 7)
						{
							switch (num)
							{
							case 2:
								item = GlobalVariables.ActiveUnitType.Weapon;
								Local_theTable = DBFunctions.GetAllWeapons(sqliteConnection_0);
								continue;
							case 3:
								item = GlobalVariables.ActiveUnitType.Ship;
								Local_theTable = DBFunctions.GetAllShips(sqliteConnection_0);
								continue;
							case 4:
								item = GlobalVariables.ActiveUnitType.Submarine;
								Local_theTable = DBFunctions.GetAllSubmarines(sqliteConnection_0);
								continue;
							case 5:
								item = GlobalVariables.ActiveUnitType.Facility;
								Local_theTable = DBFunctions.GetAllFacilities(sqliteConnection_0);
								continue;
							case 6:
								item = GlobalVariables.ActiveUnitType.Satellite;
								Local_theTable = DBFunctions.GetAllSatellites(sqliteConnection_0);
								continue;
							case 7:
								item = GlobalVariables.ActiveUnitType.Vehicle;
								Local_theTable = DBFunctions.GetAllGroundUnits(sqliteConnection_0);
								continue;
							default:
								continue;
							case 1:
								break;
							}
							break;
						}
						try
						{
							Parallel.ForEach(Local_theList, delegate((GlobalVariables.ActiveUnitType, int) theTuple)
							{
								DBFunctions.EW_GetAllPossibleEmissionsForThisUnit(theTuple.Item1, theTuple.Item2, sqliteConnection_0);
							});
							return;
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							ProjectData.ClearProjectError();
							return;
						}
					}
				}
			});
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}
}
