using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Command_Core.DAL;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Doctrine
{
	public delegate void DoctrineChangedEventHandler(ScenarioObject theSubject, bool? viaMainForm, bool MultipleUnits, bool ViaDoctrineForm, bool ViaRightColumn, bool viaFlightPlanEditor);

	public delegate void EmconChangedEventHandler(ScenarioObject theSubject, bool? viaMainForm, bool MultipleUnits, bool ViaDoctrineForm, bool ViaRightColumn, bool viaFlightPlanEditor);

	public class PriorityTargetEntry
	{
		public enum PriorityFlags
		{
			PriorityLow,
			PriorityDefault,
			PriorityHigh
		}

		[CompilerGenerated]
		private sealed class CustomerMapping
		{
			public GlobalVariables.ActiveUnitType unitType;

			public int unitSubType;

			public int unitDBID;

			internal bool EnableInterruptiblePolicy(ActiveUnit au)
			{
				return au.UnitType == unitType;
			}

			internal bool ChangeInterruptiblePolicy(ActiveUnit au)
			{
				return au.SubType == unitSubType;
			}

			internal bool InitInterruptiblePolicy(ActiveUnit au)
			{
				return ((Facility)au).EnableBridge() == (IMobileGroundUnit._MobileUnitCategory)unitSubType;
			}

			internal bool CheckInterruptiblePolicy(ActiveUnit au)
			{
				return au.SubType == unitSubType - FACILITY_SUBTYPE_OFFSET_INDEX;
			}

			internal bool ConcatInterruptiblePolicy(ActiveUnit au)
			{
				return ((IMobileGroundUnit)au).MobileUnitCategory == (IMobileGroundUnit._MobileUnitCategory)unitSubType;
			}

			internal bool InterruptInterruptiblePolicy(ActiveUnit au)
			{
				return au.DBID == unitDBID;
			}
		}

		private static GlobalVariables.ActiveUnitType[] _StrategyComparator;

		private static string[] _ConfigurationComparator;

		public static int FACILITY_SUBTYPE_OFFSET_INDEX;

		public GlobalVariables.ActiveUnitType Type;

		public int SubType;

		public int DBID;

		public PriorityFlags Priority;

		static PriorityTargetEntry()
		{
			_StrategyComparator = new GlobalVariables.ActiveUnitType[7]
			{
				GlobalVariables.ActiveUnitType.None,
				GlobalVariables.ActiveUnitType.Aircraft,
				GlobalVariables.ActiveUnitType.Ship,
				GlobalVariables.ActiveUnitType.Submarine,
				GlobalVariables.ActiveUnitType.Facility,
				GlobalVariables.ActiveUnitType.Weapon,
				GlobalVariables.ActiveUnitType.Vehicle
			};
			_ConfigurationComparator = new string[3] { "Delayed", "Default", "Immediate" };
			FACILITY_SUBTYPE_OFFSET_INDEX = 32768;
		}

		public PriorityTargetEntry()
		{
			Type = GlobalVariables.ActiveUnitType.None;
			SubType = 0;
			DBID = 0;
			Priority = PriorityFlags.PriorityDefault;
		}

		public PriorityTargetEntry(GlobalVariables.ActiveUnitType activeUnitType_0, int int_0, int int_1, PriorityFlags priorityFlags_0, bool bool_0 = false)
		{
			Type = GlobalVariables.ActiveUnitType.None;
			SubType = 0;
			DBID = 0;
			Priority = PriorityFlags.PriorityDefault;
			Type = activeUnitType_0;
			SubType = int_0;
			if (bool_0)
			{
				SubType += FACILITY_SUBTYPE_OFFSET_INDEX;
			}
			DBID = int_1;
			Priority = priorityFlags_0;
		}

		internal string DeleteInterruptibleField()
		{
			if (Type == GlobalVariables.ActiveUnitType.None)
			{
				return "Any";
			}
			return Misc.RunRequest(Type);
		}

		internal string AddInterruptibleField(Scenario scenario_0)
		{
			if (SubType != 0)
			{
				switch (Type)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					return Misc.Description((Aircraft._AircraftType)SubType, scenario_0.DBConnection);
				case GlobalVariables.ActiveUnitType.Ship:
					return Misc.Description((Ship._ShipType)SubType, scenario_0.DBConnection);
				case GlobalVariables.ActiveUnitType.Submarine:
					return Misc.Description((Submarine._SubmarineType)SubType, scenario_0.DBConnection);
				case GlobalVariables.ActiveUnitType.Facility:
					if (SubType < FACILITY_SUBTYPE_OFFSET_INDEX)
					{
						return Misc.ToEnglishString((IMobileGroundUnit._MobileUnitCategory)SubType);
					}
					return Misc.Description((Facility._FacilityCategory)(SubType - FACILITY_SUBTYPE_OFFSET_INDEX), scenario_0.DBConnection);
				case GlobalVariables.ActiveUnitType.Weapon:
					return Misc.ForgotRequest((Weapon._WeaponType)SubType);
				default:
					return "";
				case GlobalVariables.ActiveUnitType.Vehicle:
					return Misc.ToEnglishString((IMobileGroundUnit._MobileUnitCategory)SubType);
				}
			}
			return "Any";
		}

		internal string DestroyInterruptibleField(Scenario scenario_0)
		{
			if (DBID == 0)
			{
				return "Any";
			}
			return DBFunctions.GetActiveUnitName(Type, DBID, scenario_0.DBConnection);
		}

		internal string ComputeInterruptibleField()
		{
			return _ConfigurationComparator[(int)Priority];
		}

		internal string PatchInterruptibleField(Scenario scenario_0)
		{
			return "\t" + DeleteInterruptibleField() + "\t" + AddInterruptibleField(scenario_0) + "\t" + DestroyInterruptibleField(scenario_0) + "\t" + ComputeInterruptibleField();
		}

		internal string SelectInterruptibleField(Scenario scenario_0)
		{
			return "(" + DeleteInterruptibleField() + ", " + AddInterruptibleField(scenario_0) + ", " + DestroyInterruptibleField(scenario_0) + ")";
		}

		public void ToXML(ref XmlWriter xmlWriter_0, ref Scenario scenario_0, string string_0 = "Doctrine")
		{
			xmlWriter_0.WriteStartElement("PTLEntry");
			if (Type != 0)
			{
				XmlWriter obj = xmlWriter_0;
				int type = (int)Type;
				obj.WriteElementString("PTL_T", type.ToString());
			}
			if (SubType != 0)
			{
				xmlWriter_0.WriteElementString("PTL_ST", SubType.ToString());
			}
			if (DBID != 0)
			{
				xmlWriter_0.WriteElementString("PTL_DBID", DBID.ToString());
			}
			if (Priority != PriorityFlags.PriorityDefault)
			{
				XmlWriter obj2 = xmlWriter_0;
				int priority = (int)Priority;
				obj2.WriteElementString("PTL_P", priority.ToString());
			}
			xmlWriter_0.WriteEndElement();
		}

		public static PriorityTargetEntry FromXML(ref XmlNode xmlNode_0)
		{
			PriorityTargetEntry priorityTargetEntry = new PriorityTargetEntry();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "PTL_T":
						priorityTargetEntry.Type = (GlobalVariables.ActiveUnitType)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "PTL_ST":
						priorityTargetEntry.SubType = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "PTL_P":
						priorityTargetEntry.Priority = (PriorityFlags)Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "PTL_DBID":
						priorityTargetEntry.DBID = Conversions.ToInteger(xmlNode.InnerText);
						break;
					}
				}
				return priorityTargetEntry;
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
		}

		internal bool CallInterruptibleField(Contact contact_0)
		{
			if (contact_0.IDStatus >= Contact_Base.IdentificationStatus.KnownDomain && contact_0.ActualUnit != null)
			{
				GlobalVariables.ActiveUnitType type = Type;
				if (1 == 0)
				{
				}
				bool result = type switch
				{
					GlobalVariables.ActiveUnitType.None => true, 
					GlobalVariables.ActiveUnitType.Aircraft => contact_0.ActualUnit.IsAircraft, 
					GlobalVariables.ActiveUnitType.Ship => contact_0.ActualUnit.IsShip, 
					GlobalVariables.ActiveUnitType.Submarine => contact_0.ActualUnit.IsSubmarine, 
					GlobalVariables.ActiveUnitType.Facility => contact_0.ActualUnit.IsFacility, 
					GlobalVariables.ActiveUnitType.Weapon => contact_0.ActualUnit.IsWeapon, 
					GlobalVariables.ActiveUnitType.Vehicle => contact_0.ActualUnit.IsVehicle, 
					_ => false, 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			return false;
		}

		internal bool LogoutInterruptibleField(Contact contact_0)
		{
			if (SubType == 0)
			{
				return true;
			}
			if (contact_0.IDStatus >= Contact_Base.IdentificationStatus.KnownType && contact_0.ActualUnit != null)
			{
				switch (Type)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					return SubType == contact_0.ActualUnit.SubType;
				case GlobalVariables.ActiveUnitType.Ship:
					return SubType == contact_0.ActualUnit.SubType;
				case GlobalVariables.ActiveUnitType.Submarine:
					return SubType == contact_0.ActualUnit.SubType;
				case GlobalVariables.ActiveUnitType.Facility:
				{
					Facility facility = (Facility)contact_0.ActualUnit;
					if (SubType < FACILITY_SUBTYPE_OFFSET_INDEX)
					{
						return SubType == (int)facility.EnableBridge();
					}
					return SubType - FACILITY_SUBTYPE_OFFSET_INDEX == facility.SubType;
				}
				case GlobalVariables.ActiveUnitType.Weapon:
					return SubType == contact_0.ActualUnit.SubType;
				default:
					return false;
				case GlobalVariables.ActiveUnitType.Vehicle:
					return SubType == (int)((IMobileGroundUnit)contact_0.ActualUnit).MobileUnitCategory;
				}
			}
			return false;
		}

		internal bool ViewInterruptibleField(Contact contact_0)
		{
			if (DBID == 0)
			{
				return true;
			}
			if (contact_0.IDStatus >= Contact_Base.IdentificationStatus.KnownClass && contact_0.ActualUnit != null)
			{
				return contact_0.ActualUnit.DBID == DBID;
			}
			return false;
		}

		internal bool ValidateInterruptibleField(Contact contact_0)
		{
			if (CallInterruptibleField(contact_0) && LogoutInterruptibleField(contact_0))
			{
				return ViewInterruptibleField(contact_0);
			}
			return false;
		}

		public static void PopulateUnitTypeList(ComboBox comboBox_0)
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(int));
			dataTable.Columns.Add("Description", typeof(string));
			dataTable.Rows.Add(GlobalVariables.ActiveUnitType.Aircraft, Misc.RunRequest(GlobalVariables.ActiveUnitType.Aircraft));
			dataTable.Rows.Add(GlobalVariables.ActiveUnitType.Ship, Misc.RunRequest(GlobalVariables.ActiveUnitType.Ship));
			dataTable.Rows.Add(GlobalVariables.ActiveUnitType.Submarine, Misc.RunRequest(GlobalVariables.ActiveUnitType.Submarine));
			dataTable.Rows.Add(GlobalVariables.ActiveUnitType.Facility, Misc.RunRequest(GlobalVariables.ActiveUnitType.Facility));
			dataTable.Rows.Add(GlobalVariables.ActiveUnitType.Vehicle, Misc.RunRequest(GlobalVariables.ActiveUnitType.Vehicle));
			dataTable.Rows.Add(GlobalVariables.ActiveUnitType.Weapon, Misc.RunRequest(GlobalVariables.ActiveUnitType.Weapon));
			comboBox_0.DataSource = dataTable;
			comboBox_0.DisplayMember = "Description";
			comboBox_0.ValueMember = "ID";
			comboBox_0.SelectedIndex = 0;
		}

		public static bool ScenarioContains(GlobalVariables.ActiveUnitType activeUnitType_0, int int_0, int int_1, Scenario scenario_0)
		{
			if (scenario_0 != null && scenario_0.ActiveUnits.Count >= 1)
			{
				List<ActiveUnit> list = scenario_0.ActiveUnits_List.Where((ActiveUnit au) => au.UnitType == activeUnitType_0).ToList();
				if (list.Count <= 0)
				{
					return false;
				}
				if (int_1 <= 0)
				{
					List<ActiveUnit> list2 = null;
					switch (activeUnitType_0)
					{
					case GlobalVariables.ActiveUnitType.Facility:
						list2 = ((int_0 < FACILITY_SUBTYPE_OFFSET_INDEX) ? list.Where((ActiveUnit au) => ((Facility)au).EnableBridge() == (IMobileGroundUnit._MobileUnitCategory)int_0).ToList() : list.Where((ActiveUnit au) => au.SubType == int_0 - FACILITY_SUBTYPE_OFFSET_INDEX).ToList());
						break;
					case GlobalVariables.ActiveUnitType.Aircraft:
					case GlobalVariables.ActiveUnitType.Ship:
					case GlobalVariables.ActiveUnitType.Submarine:
					case GlobalVariables.ActiveUnitType.Weapon:
						list2 = list.Where((ActiveUnit au) => au.SubType == int_0).ToList();
						break;
					case GlobalVariables.ActiveUnitType.Vehicle:
						list2 = list.Where((ActiveUnit au) => ((IMobileGroundUnit)au).MobileUnitCategory == (IMobileGroundUnit._MobileUnitCategory)int_0).ToList();
						break;
					}
					return list2.Count > 0;
				}
				return list.Where((ActiveUnit au) => au.DBID == int_1).ToList().Count > 0;
			}
			return false;
		}

		public static void PopulateUnitSubTypeList(ComboBox comboBox_0, GlobalVariables.ActiveUnitType activeUnitType_0, Scenario scenario_0, bool bool_0 = false)
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(int));
			dataTable.Columns.Add("Description", typeof(string));
			dataTable.Rows.Add(0, "Any");
			switch (activeUnitType_0)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
			{
				IEnumerator enumerator4 = null;
				try
				{
					enumerator4 = Enum.GetValues(typeof(Aircraft._AircraftType)).GetEnumerator();
					while (enumerator4.MoveNext())
					{
						Aircraft._AircraftType aircraftType = (Aircraft._AircraftType)Conversions.ToInteger(enumerator4.Current);
						Aircraft._AircraftType aircraftType2 = aircraftType;
						Aircraft._AircraftType aircraftType3 = aircraftType2;
						if (aircraftType3 != Aircraft._AircraftType.None && (uint)(aircraftType3 - 9000) > 9u && (!bool_0 || ScenarioContains(activeUnitType_0, (int)aircraftType, 0, scenario_0)))
						{
							string text4 = Misc.Description(aircraftType, scenario_0.DBConnection);
							if (string.IsNullOrEmpty(text4))
							{
								dataTable.Rows.Add((int)aircraftType, aircraftType.ToString());
							}
							else
							{
								dataTable.Rows.Add((int)aircraftType, text4);
							}
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
			case GlobalVariables.ActiveUnitType.Ship:
			{
				IEnumerator enumerator6 = null;
				try
				{
					enumerator6 = Enum.GetValues(typeof(Ship._ShipType)).GetEnumerator();
					while (enumerator6.MoveNext())
					{
						Ship._ShipType shipType = (Ship._ShipType)Conversions.ToInteger(enumerator6.Current);
						if (shipType != Ship._ShipType.None && (!bool_0 || ScenarioContains(activeUnitType_0, (int)shipType, 0, scenario_0)))
						{
							string text6 = Misc.Description(shipType, scenario_0.DBConnection);
							if (string.IsNullOrEmpty(text6))
							{
								dataTable.Rows.Add((int)shipType, shipType.ToString());
							}
							else
							{
								dataTable.Rows.Add((int)shipType, text6);
							}
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
			}
			case GlobalVariables.ActiveUnitType.Submarine:
			{
				IEnumerator enumerator5 = null;
				try
				{
					enumerator5 = Enum.GetValues(typeof(Submarine._SubmarineType)).GetEnumerator();
					while (enumerator5.MoveNext())
					{
						Submarine._SubmarineType submarineType = (Submarine._SubmarineType)Conversions.ToInteger(enumerator5.Current);
						if (submarineType != Submarine._SubmarineType.None && (!bool_0 || ScenarioContains(activeUnitType_0, (int)submarineType, 0, scenario_0)))
						{
							string text5 = Misc.Description(submarineType, scenario_0.DBConnection);
							if (string.IsNullOrEmpty(text5))
							{
								dataTable.Rows.Add((int)submarineType, submarineType.ToString());
							}
							else
							{
								dataTable.Rows.Add((int)submarineType, text5);
							}
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
			case GlobalVariables.ActiveUnitType.Facility:
			{
				IEnumerator enumerator2 = null;
				try
				{
					enumerator2 = Enum.GetValues(typeof(Facility._FacilityCategory)).GetEnumerator();
					while (enumerator2.MoveNext())
					{
						Facility._FacilityCategory facilityCategory = (Facility._FacilityCategory)Conversions.ToShort(enumerator2.Current);
						if (facilityCategory == Facility._FacilityCategory.None)
						{
							continue;
						}
						int num = (int)facilityCategory + FACILITY_SUBTYPE_OFFSET_INDEX;
						if (!bool_0 || ScenarioContains(activeUnitType_0, num, 0, scenario_0))
						{
							string text2 = Misc.Description(facilityCategory, scenario_0.DBConnection);
							if (string.IsNullOrEmpty(text2))
							{
								dataTable.Rows.Add(num, facilityCategory.ToString());
							}
							else
							{
								dataTable.Rows.Add(num, text2);
							}
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
				IEnumerator enumerator3 = null;
				try
				{
					enumerator3 = Enum.GetValues(typeof(IMobileGroundUnit._MobileUnitCategory)).GetEnumerator();
					while (enumerator3.MoveNext())
					{
						IMobileGroundUnit._MobileUnitCategory mobileUnitCategory2 = (IMobileGroundUnit._MobileUnitCategory)Conversions.ToInteger(enumerator3.Current);
						if (mobileUnitCategory2 != 0 && mobileUnitCategory2 != IMobileGroundUnit._MobileUnitCategory.Infantry_Old && (!bool_0 || ScenarioContains(activeUnitType_0, (int)mobileUnitCategory2, 0, scenario_0)))
						{
							string text3 = Misc.ToEnglishString(mobileUnitCategory2);
							if (string.IsNullOrEmpty(text3))
							{
								dataTable.Rows.Add((int)mobileUnitCategory2, mobileUnitCategory2.ToString());
							}
							else
							{
								dataTable.Rows.Add((int)mobileUnitCategory2, text3);
							}
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
			case GlobalVariables.ActiveUnitType.Weapon:
				dataTable.Rows.Add(2001, Misc.ForgotRequest(Weapon._WeaponType.GuidedWeapon));
				break;
			case GlobalVariables.ActiveUnitType.Vehicle:
			{
				IEnumerator enumerator = null;
				try
				{
					enumerator = Enum.GetValues(typeof(IMobileGroundUnit._MobileUnitCategory)).GetEnumerator();
					while (enumerator.MoveNext())
					{
						IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = (IMobileGroundUnit._MobileUnitCategory)Conversions.ToInteger(enumerator.Current);
						if (mobileUnitCategory != 0 && mobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Infantry_Old && (!bool_0 || ScenarioContains(activeUnitType_0, (int)mobileUnitCategory, 0, scenario_0)))
						{
							string text = Misc.ToEnglishString(mobileUnitCategory);
							if (string.IsNullOrEmpty(text))
							{
								dataTable.Rows.Add((int)mobileUnitCategory, mobileUnitCategory.ToString());
							}
							else
							{
								dataTable.Rows.Add((int)mobileUnitCategory, text);
							}
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
				break;
			}
			}
			comboBox_0.DataSource = dataTable;
			comboBox_0.DisplayMember = "Description";
			comboBox_0.ValueMember = "ID";
			comboBox_0.SelectedIndex = 0;
		}

		public static void PopulateDBIDList(ComboBox comboBox_0, GlobalVariables.ActiveUnitType activeUnitType_0, int int_0, Scenario scenario_0, bool bool_0 = false)
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(int));
			dataTable.Columns.Add("Description", typeof(string));
			dataTable.Rows.Add(0, "Any");
			if (bool_0 && !ScenarioContains(activeUnitType_0, int_0, 0, scenario_0))
			{
				comboBox_0.DataSource = dataTable;
				comboBox_0.DisplayMember = "Description";
				comboBox_0.ValueMember = "ID";
				comboBox_0.SelectedIndex = 0;
				return;
			}
			if (int_0 != 0)
			{
				switch (activeUnitType_0)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
				{
					IEnumerator enumerator4 = null;
					try
					{
						enumerator4 = scenario_0.Cache_Aircraft_DT.Rows.GetEnumerator();
						while (enumerator4.MoveNext())
						{
							DataRow dataRow4 = (DataRow)enumerator4.Current;
							if (Conversions.ToInteger(dataRow4["Type"]) == int_0 && (!bool_0 || ScenarioContains(activeUnitType_0, int_0, Conversions.ToInteger(dataRow4["ID"]), scenario_0)))
							{
								dataTable.Rows.Add(Conversions.ToInteger(dataRow4["ID"]), dataRow4["LongName"]);
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
				case GlobalVariables.ActiveUnitType.Ship:
				{
					IEnumerator enumerator5 = null;
					try
					{
						enumerator5 = scenario_0.Cache_Ships_DT.Rows.GetEnumerator();
						while (enumerator5.MoveNext())
						{
							DataRow dataRow5 = (DataRow)enumerator5.Current;
							if (Conversions.ToInteger(dataRow5["Type"]) == int_0 && (!bool_0 || ScenarioContains(activeUnitType_0, int_0, Conversions.ToInteger(dataRow5["ID"]), scenario_0)))
							{
								dataTable.Rows.Add(Conversions.ToInteger(dataRow5["ID"]), dataRow5["LongName"]);
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
				case GlobalVariables.ActiveUnitType.Submarine:
				{
					IEnumerator enumerator6 = null;
					try
					{
						enumerator6 = scenario_0.Cache_Subs_DT.Rows.GetEnumerator();
						while (enumerator6.MoveNext())
						{
							DataRow dataRow6 = (DataRow)enumerator6.Current;
							if (Conversions.ToInteger(dataRow6["Type"]) == int_0 && (!bool_0 || ScenarioContains(activeUnitType_0, int_0, Conversions.ToInteger(dataRow6["ID"]), scenario_0)))
							{
								dataTable.Rows.Add(Conversions.ToInteger(dataRow6["ID"]), dataRow6["LongName"]);
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
				}
				case GlobalVariables.ActiveUnitType.Facility:
				{
					bool flag = true;
					int num = int_0;
					if (int_0 >= FACILITY_SUBTYPE_OFFSET_INDEX)
					{
						num -= FACILITY_SUBTYPE_OFFSET_INDEX;
						flag = false;
					}
					IEnumerator enumerator3 = null;
					try
					{
						enumerator3 = scenario_0.Cache_Facilities_DT.Rows.GetEnumerator();
						while (enumerator3.MoveNext())
						{
							DataRow dataRow3 = (DataRow)enumerator3.Current;
							if (flag)
							{
								if (Facility.MobileUnitCategory(dataRow3["Name"].ToString()) == (IMobileGroundUnit._MobileUnitCategory)num && (!bool_0 || ScenarioContains(activeUnitType_0, int_0, Conversions.ToInteger(dataRow3["ID"]), scenario_0)))
								{
									dataTable.Rows.Add(Conversions.ToInteger(dataRow3["ID"]), dataRow3["LongName"]);
								}
							}
							else if (Conversions.ToInteger(dataRow3["Category"]) == num && (!bool_0 || ScenarioContains(activeUnitType_0, int_0, Conversions.ToInteger(dataRow3["ID"]), scenario_0)))
							{
								dataTable.Rows.Add(Conversions.ToInteger(dataRow3["ID"]), dataRow3["LongName"]);
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
				case GlobalVariables.ActiveUnitType.Weapon:
				{
					IEnumerator enumerator2 = null;
					try
					{
						enumerator2 = scenario_0.Cache_Weapons_DT.Rows.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							DataRow dataRow2 = (DataRow)enumerator2.Current;
							if (Conversions.ToInteger(dataRow2["Type"]) == int_0 && (!bool_0 || ScenarioContains(activeUnitType_0, int_0, Conversions.ToInteger(dataRow2["ID"]), scenario_0)))
							{
								dataTable.Rows.Add(Conversions.ToInteger(dataRow2["ID"]), dataRow2["LongName"]);
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
					break;
				}
				case GlobalVariables.ActiveUnitType.Vehicle:
				{
					IEnumerator enumerator = null;
					try
					{
						enumerator = scenario_0.Cache_GroundUnits_DT.Rows.GetEnumerator();
						while (enumerator.MoveNext())
						{
							DataRow dataRow = (DataRow)enumerator.Current;
							if (Conversions.ToInteger(dataRow["Category"]) == int_0 && (!bool_0 || ScenarioContains(activeUnitType_0, int_0, Conversions.ToInteger(dataRow["ID"]), scenario_0)))
							{
								dataTable.Rows.Add(Conversions.ToInteger(dataRow["ID"]), dataRow["LongName"]);
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
					break;
				}
				}
			}
			comboBox_0.DataSource = dataTable;
			comboBox_0.DisplayMember = "Description";
			comboBox_0.ValueMember = "ID";
			comboBox_0.SelectedIndex = 0;
		}
	}

	public enum _BehaviorTowardsTargetAmbiguity : byte
	{
		Ignore,
		Optimistic,
		Pessimistic,
		Various,
		NotConfigured
	}

	public enum _WCS : byte
	{
		Free,
		Tight,
		Hold,
		Various,
		NotConfigured
	}

	public enum _QuickTurnAroundForAicraft : byte
	{
		Yes,
		FightersAndASW,
		No,
		Various,
		NotConfigured
	}

	public enum _AirOpsTempo : byte
	{
		Surge,
		Sustained,
		Various,
		NotConfigured
	}

	public enum _WeaponState
	{
		LoadoutSetting = 0,
		Winchester = 2001,
		Winchester_ToO = 2002,
		const_3 = 3001,
		ShotgunBVR_WVR = 3002,
		ShotgunBVR_WVR_Guns = 3003,
		ShotgunOneEngagementBVR = 5001,
		ShotgunOneEngagementBVR_Opportunity_WVR = 5002,
		ShotgunOneEngagementBVR_Opportunity_WVR_Guns = 5003,
		ShotgunOneEngagementBVR_And_WVR = 5005,
		ShotgunOneEngagementBVR_And_WVR_Opportunity_Guns = 5006,
		ShotgunOneEngagementWVR = 5011,
		ShotgunOneEngagementWVR_Guns = 5012,
		ShotgunOneEngagementGun = 5021,
		const_14 = 4001,
		Shotgun25_ToO = 4002,
		const_16 = 4011,
		Shotgun50_ToO = 4012,
		const_18 = 4021,
		Shotgun75_ToO = 4022,
		Various = 1,
		NotConfigured = 2
	}

	public enum _FuelState : byte
	{
		Bingo,
		Joker10Percent,
		Joker20Percent,
		Joker25Percent,
		Joker30Percent,
		Joker40Percent,
		Joker50Percent,
		Joker60Percent,
		Joker70Percent,
		Joker75Percent,
		Joker80Percent,
		Joker90Percent,
		Various,
		Chicken,
		NotConfigured
	}

	public enum _UseKinematicRangeForTorpedoes : byte
	{
		AutomaticAndManualFire,
		ManualFireOnly,
		No,
		Various,
		NotConfigured
	}

	public enum _UseUnderwayRefuelAndReplenishment : byte
	{
		Always_ExceptTankersRefuellingTankers,
		Never,
		Always_IncludingTankersRefuellingTankers,
		Various,
		NotConfigured
	}

	public enum _UnderwayRefuelAndReplenishmentSelection : byte
	{
		PickNearest,
		TankersBetweenUsAndObjectiveOnly,
		TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround,
		Various,
		NotConfigured
	}

	public enum _UseSAMsAgainstShips : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _UseWpMissileAgainstShips : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _UseShootTourists : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _UseIgnoreEMCONunderAttack : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _UseAutoEvade : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _UseMaintainStandoff : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _NavigationMethod : byte
	{
		ShortestRoute,
		DeepWater,
		Littoral,
		DeepWater_Submarine,
		CZ_Submarine,
		Littoral_Submarine,
		Various,
		NotConfigured,
		Direct
	}

	public enum _GunStrafeGroundTargets : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _UseIgnorePlottedCourse : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _UseNukesAllowed : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _CanRedeployOnlyWithFullWeapons : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _WeaponStateRTB : byte
	{
		No,
		YesLastUnit,
		YesFirstUnit,
		YesLeaveGroup,
		Various,
		NotConfigured
	}

	public enum _FuelStateRTB : byte
	{
		No,
		YesLastUnit,
		YesFirstUnit,
		YesLeaveGroup,
		Various,
		NotConfigured
	}

	public enum _JettisonOrdnance : byte
	{
		No,
		Yes,
		Various,
		NotConfigured
	}

	public enum _BVRLogicEnum : byte
	{
		StraightIn,
		Crank,
		CrankAndDrag,
		Various,
		NotConfigured,
		DragImmediately
	}

	public enum _RefuelAlliedUnits : byte
	{
		Yes,
		Yes_ReceiveOnly,
		Yes_DeliverOnly,
		No,
		Various,
		NotConfigured
	}

	public enum _BingoThreshold_E : byte
	{
		Bingo30Percent,
		Bingo40Percent,
		Bingo50Percent,
		Bingo60Percent,
		Bingo70Percent,
		Bingo80Percent,
		Various,
		NotConfigured
	}

	public enum _AvoidContactWhenPossible : byte
	{
		No,
		Yes_ExceptSelfDefence,
		Yes_Always,
		Various,
		NotConfigured
	}

	public enum _DiveOnContact : byte
	{
		Yes,
		Yes_ESM_Only,
		Yes_Ships20nm_Aircraft30nm,
		No,
		Various,
		NotConfigured
	}

	public enum _RechargeBatteryPercentage
	{
		Recharge_Empty = 0,
		Recharge_10_Percent = 10,
		Recharge_20_Percent = 20,
		Recharge_30_Percent = 30,
		Recharge_40_Percent = 40,
		Recharge_50_Percent = 50,
		Recharge_60_Percent = 60,
		Recharge_70_Percent = 70,
		Recharge_80_Percent = 80,
		Recharge_90_Percent = 90,
		Various = -100,
		NotConfigured = -101
	}

	public enum _UseAIP : byte
	{
		No,
		Yes_AttackOnly,
		Yes_Always,
		Various,
		NotConfigured
	}

	public enum _UseDippingSonar : byte
	{
		Automatically_HoverAnd150ft,
		ManualAndMissionOnly,
		Various,
		NotConfigured
	}

	public enum _DamageThreshold : short
	{
		Ignore,
		Percent5,
		const_2,
		const_3,
		const_4,
		Various,
		NotConfigured
	}

	public enum _FuelQuantityThreshold : short
	{
		Ignore,
		Bingo,
		const_2,
		const_3,
		const_4,
		const_5,
		Various,
		NotConfigured
	}

	public enum _WeaponQuantityThreshold : short
	{
		Ignore,
		Exhausted,
		const_2,
		const_3,
		const_4,
		const_5,
		LoadFullWeapons,
		Various,
		NotConfigured
	}

	public class EMCONSettings
	{
		public enum _EMCONSetting : byte
		{
			Passive,
			Active,
			Various,
			NotConfigured,
			Intermittent
		}

		private _EMCONSetting m_TokenComparator;

		private _EMCONSetting _IndexerComparator;

		private _EMCONSetting _ResolverComparator;

		public EMCONSettings()
		{
		}

		public EMCONSettings(_EMCONSetting _EMCONSetting_0, _EMCONSetting _EMCONSetting_1, _EMCONSetting _EMCONSetting_2)
		{
			m_TokenComparator = _EMCONSetting_0;
			_IndexerComparator = _EMCONSetting_1;
			_ResolverComparator = _EMCONSetting_2;
		}

		public bool HasActiveEmissions()
		{
			if (m_TokenComparator != _EMCONSetting.Active && _IndexerComparator != _EMCONSetting.Active)
			{
				return _ResolverComparator == _EMCONSetting.Active;
			}
			return true;
		}

		internal _EMCONSetting LoginInterruptibleField()
		{
			return m_TokenComparator;
		}

		internal _EMCONSetting GetInterruptibleField()
		{
			return _IndexerComparator;
		}

		internal _EMCONSetting OECM()
		{
			return _ResolverComparator;
		}

		public static _EMCONSetting EMCONSettingSelection_To_EMCONSetting(int int_0)
		{
			if (1 == 0)
			{
			}
			_EMCONSetting result = int_0 switch
			{
				1 => _EMCONSetting.Active, 
				0 => _EMCONSetting.Passive, 
				_ => _EMCONSetting.NotConfigured, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
	}

	public class WRA_Weapon
	{
		public WRA_FiringDoctrineEntry[] WRA_WeaponTargets;

		private Weapon m_PublisherComparator;

		public WRA_Weapon()
		{
			WRA_WeaponTargets = new WRA_FiringDoctrineEntry[0];
		}

		public WRA_Weapon(ref Weapon weapon_0, Scenario scenario_0)
		{
			WRA_WeaponTargets = new WRA_FiringDoctrineEntry[0];
			List<WRA_FiringDoctrineEntry> list = new List<WRA_FiringDoctrineEntry>();
			if (weapon_0.ValidTargets.Aircraft || weapon_0.ValidTargets.Helicopter || weapon_0.ValidTargets.Missile || weapon_0.ValidTargets.Satellite)
			{
				WRA_FiringDoctrineEntry item = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Air_Contact_Unknown_Type);
				list.Add(item);
			}
			if (weapon_0.ValidTargets.Aircraft)
			{
				WRA_FiringDoctrineEntry item8 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Aircraft_Unspecified);
				list.Add(item8);
				item8 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Aircraft_5th_Generation);
				list.Add(item8);
				item8 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Aircraft_4th_Generation);
				list.Add(item8);
				item8 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Aircraft_3rd_Generation);
				list.Add(item8);
				item8 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Aircraft_Less_Capable);
				list.Add(item8);
				item8 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Aircraft_High_Perf_Bombers);
				list.Add(item8);
				item8 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Aircraft_Medium_Perf_Bombers);
				list.Add(item8);
				item8 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers);
				list.Add(item8);
				item8 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Aircraft_High_Perf_Recon_EW);
				list.Add(item8);
				item8 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Aircraft_Medium_Perf_Recon_EW);
				list.Add(item8);
				item8 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW);
				list.Add(item8);
				item8 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Aircraft_AEW);
				list.Add(item8);
				item8 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Aircraft_Tanker);
				list.Add(item8);
				item8 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Aircraft_MicroUAV);
				list.Add(item8);
				item8 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Helicopter_Unspecified);
				list.Add(item8);
			}
			else if (weapon_0.ValidTargets.Helicopter)
			{
				WRA_FiringDoctrineEntry item9 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Helicopter_Unspecified);
				list.Add(item9);
			}
			if (weapon_0.ValidTargets.Missile)
			{
				WRA_FiringDoctrineEntry item10 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Guided_Weapon_Unspecified);
				list.Add(item10);
				item10 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Guided_Weapon_Subsonic_Sea_Skimming);
				list.Add(item10);
				item10 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Guided_Weapon_Supersonic_Sea_Skimming);
				list.Add(item10);
				item10 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Guided_Weapon_Subsonic);
				list.Add(item10);
				item10 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Guided_Weapon_Supersonic);
				list.Add(item10);
				item10 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Guided_Weapon_Ballistic);
				list.Add(item10);
			}
			if (weapon_0.ValidTargets.Satellite)
			{
				WRA_FiringDoctrineEntry item11 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Satellite_Unspecified);
				list.Add(item11);
			}
			if (weapon_0.ValidTargets.SurfaceVessel)
			{
				WRA_FiringDoctrineEntry item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Surface_Contact_Unknown_Type);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Unspecified);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Carrier_0_25000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Carrier_25001_45000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Carrier_45001_95000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Carrier_95000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Surface_Combatant_0_500_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Surface_Combatant_501_1500_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Surface_Combatant_1501_5000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Surface_Combatant_5001_10000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Surface_Combatant_10001_25000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Surface_Combatant_25001_45000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Surface_Combatant_45001_95000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Surface_Combatant_95000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Amphibious_0_500_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Amphibious_501_1500_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Amphibious_1501_5000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Amphibious_5001_10000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Amphibious_10001_25000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Amphibious_25001_45000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Amphibious_45001_95000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Amphibious_95000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Auxiliary_0_500_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Auxiliary_501_1500_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Auxiliary_1501_5000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Auxiliary_5001_10000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Auxiliary_10001_25000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Auxiliary_25001_45000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Auxiliary_45001_95000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Auxiliary_95000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Merchant_Civilian_0_500_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Merchant_Civilian_501_1500_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Merchant_Civilian_1501_5000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Merchant_Civilian_5001_10000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Merchant_Civilian_10001_25000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Merchant_Civilian_25001_45000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Merchant_Civilian_45001_95000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Merchant_Civilian_95000_tons);
				list.Add(item12);
				item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Submarine_Surfaced);
				list.Add(item12);
			}
			if (weapon_0.ValidTargets.Submarine)
			{
				WRA_FiringDoctrineEntry item13 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Submarine_Unspecified);
				list.Add(item13);
				item13 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type);
				list.Add(item13);
			}
			if (weapon_0.ValidTargets.LandStructure_Soft || weapon_0.ValidTargets.LandStructure_Hard || weapon_0.ValidTargets.MobileTarget_Soft || weapon_0.ValidTargets.MobileTarget_Hard || weapon_0.ValidTargets.Runway || weapon_0.ValidTargets.UnderwaterStructure || weapon_0.ValidTargets.AerostatMooring || weapon_0.ValidTargets.AirBaseSingleUnit)
			{
				WRA_FiringDoctrineEntry item14 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Contact_Unknown_Type);
				list.Add(item14);
			}
			if (weapon_0.ValidTargets.LandStructure_Soft || weapon_0.ValidTargets.LandStructure_Hard)
			{
				WRA_FiringDoctrineEntry item15 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Soft_Unspecified);
				list.Add(item15);
				item15 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Soft_Building_Surface);
				list.Add(item15);
				item15 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Soft_Building_Reveted);
				list.Add(item15);
				item15 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Soft_Structure_Open);
				list.Add(item15);
				item15 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Soft_Structure_Reveted);
				list.Add(item15);
				item15 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Soft_Aerostat_Moring);
				list.Add(item15);
				item15 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified);
				list.Add(item15);
				item15 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Hardened_Building_Surface);
				list.Add(item15);
				item15 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Hardened_Building_Reveted);
				list.Add(item15);
				item15 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Hardened_Building_Bunker);
				list.Add(item15);
				item15 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Hardened_Building_Underground);
				list.Add(item15);
				item15 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Open);
				list.Add(item15);
				item15 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Reveted);
				list.Add(item15);
			}
			if (weapon_0.ValidTargets.Runway)
			{
				WRA_FiringDoctrineEntry item2 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Runway_Facility_Unspecified);
				list.Add(item2);
				item2 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Runway);
				list.Add(item2);
				item2 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Runway_Grade_Taxiway);
				list.Add(item2);
				item2 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Runway_Access_Point);
				list.Add(item2);
			}
			if (weapon_0.ValidTargets.Radar)
			{
				WRA_FiringDoctrineEntry item3 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Radar_Unspecified);
				list.Add(item3);
			}
			if (weapon_0.ValidTargets.MobileTarget_Soft || weapon_0.ValidTargets.MobileTarget_Hard)
			{
				WRA_FiringDoctrineEntry item4 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified);
				list.Add(item4);
				item4 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Vehicle);
				list.Add(item4);
				item4 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel);
				list.Add(item4);
				item4 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified);
				list.Add(item4);
				item4 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle);
				list.Add(item4);
			}
			bool flag = false;
			foreach (WRA_Weapon value in weapon_0.Doctrine.WRA.Values)
			{
				if ((weapon_0.ValidTargets.LandStructure_Soft || weapon_0.ValidTargets.LandStructure_Hard) && !weapon_0.ValidTargets.MobileTarget_Soft && !weapon_0.ValidTargets.MobileTarget_Hard)
				{
					WRA_FiringDoctrineEntry[] wRA_WeaponTargets = value.WRA_WeaponTargets;
					WRA_FiringDoctrineEntry[] array = wRA_WeaponTargets;
					foreach (WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry in array)
					{
						if (wRA_FiringDoctrineEntry.TargetType == _WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified || wRA_FiringDoctrineEntry.TargetType == _WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified)
						{
							WRA_FiringDoctrineEntry item5 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified);
							list.Add(item5);
							item5 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Vehicle);
							list.Add(item5);
							item5 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel);
							list.Add(item5);
							item5 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified);
							list.Add(item5);
							item5 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle);
							list.Add(item5);
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (weapon_0.ValidTargets.UnderwaterStructure)
			{
				WRA_FiringDoctrineEntry item6 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Underwater_Structure);
				list.Add(item6);
			}
			if (weapon_0.ValidTargets.AirBaseSingleUnit)
			{
				WRA_FiringDoctrineEntry item7 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield);
				list.Add(item7);
			}
			WRA_WeaponTargets = Misc.ChangeRequest(list);
		}

		public void WRA_Skeleton(ref Weapon weapon_0)
		{
			List<WRA_FiringDoctrineEntry> list = new List<WRA_FiringDoctrineEntry>();
			if (weapon_0.ValidTargets.Aircraft || weapon_0.ValidTargets.Helicopter || weapon_0.ValidTargets.Missile || weapon_0.ValidTargets.Satellite)
			{
				WRA_FiringDoctrineEntry item = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Air_Contact_Unknown_Type, 2, 1, 0f, null);
				list.Add(item);
			}
			if (weapon_0.ValidTargets.Aircraft)
			{
				WRA_FiringDoctrineEntry item12 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Aircraft_Unspecified, 2, 1, 0f, null);
				list.Add(item12);
			}
			if (weapon_0.ValidTargets.Helicopter || weapon_0.ValidTargets.Aircraft)
			{
				WRA_FiringDoctrineEntry item16 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Helicopter_Unspecified, 2, 1, 0f, null);
				list.Add(item16);
			}
			if (weapon_0.ValidTargets.Missile)
			{
				WRA_FiringDoctrineEntry item17 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Guided_Weapon_Unspecified, 2, 1, 0f, null);
				list.Add(item17);
			}
			if (weapon_0.ValidTargets.Satellite)
			{
				WRA_FiringDoctrineEntry item18 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Satellite_Unspecified, 2, 1, 0f, null);
				list.Add(item18);
			}
			if (weapon_0.ValidTargets.SurfaceVessel)
			{
				if (weapon_0.Type != Weapon._WeaponType.Gun && weapon_0.Type != Weapon._WeaponType.Rocket && weapon_0.Type != Weapon._WeaponType.IronBomb)
				{
					if (weapon_0.Type == Weapon._WeaponType.Torpedo)
					{
						WRA_FiringDoctrineEntry item19 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Surface_Contact_Unknown_Type, 2, 1, 0f, null);
						list.Add(item19);
						item19 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Unspecified, 2, 1, 0f, null);
						list.Add(item19);
					}
					else
					{
						WRA_FiringDoctrineEntry item20 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Surface_Contact_Unknown_Type, 2, 1, 0f, null);
						list.Add(item20);
						item20 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Unspecified, -2, -99, 0f, null);
						list.Add(item20);
					}
				}
				else
				{
					WRA_FiringDoctrineEntry item21 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Surface_Contact_Unknown_Type, -99, -99, 0f, null);
					list.Add(item21);
					item21 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Ship_Unspecified, -99, -99, 0f, null);
					list.Add(item21);
				}
			}
			if (weapon_0.ValidTargets.Submarine)
			{
				if (weapon_0.Type == Weapon._WeaponType.DepthCharge)
				{
					WRA_FiringDoctrineEntry item22 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Submarine_Unspecified, -99, -99, 0f, null);
					list.Add(item22);
					item22 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type, -99, -99, 0f, null);
					list.Add(item22);
				}
				else
				{
					WRA_FiringDoctrineEntry item2 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Submarine_Unspecified, 2, 1, 0f, null);
					list.Add(item2);
					item2 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type, 2, 1, 0f, null);
					list.Add(item2);
				}
			}
			if (weapon_0.ValidTargets.LandStructure_Soft || weapon_0.ValidTargets.LandStructure_Hard || weapon_0.ValidTargets.MobileTarget_Soft || weapon_0.ValidTargets.MobileTarget_Hard || weapon_0.ValidTargets.Runway || weapon_0.ValidTargets.UnderwaterStructure || weapon_0.ValidTargets.AerostatMooring || weapon_0.ValidTargets.AirBaseSingleUnit)
			{
				if (weapon_0.Type != Weapon._WeaponType.Gun && weapon_0.Type != Weapon._WeaponType.Rocket && weapon_0.Type != Weapon._WeaponType.IronBomb)
				{
					WRA_FiringDoctrineEntry item3 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Contact_Unknown_Type, 2, 1, 0f, null);
					list.Add(item3);
					item3 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Runway_Facility_Unspecified, 2, 1, 0f, null);
					list.Add(item3);
				}
				else
				{
					WRA_FiringDoctrineEntry item4 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Contact_Unknown_Type, -99, -99, 0f, null);
					list.Add(item4);
					item4 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Runway_Facility_Unspecified, -99, -99, 0f, null);
					list.Add(item4);
				}
			}
			if (weapon_0.ValidTargets.LandStructure_Soft || weapon_0.ValidTargets.LandStructure_Hard)
			{
				if (weapon_0.Type != Weapon._WeaponType.Gun && weapon_0.Type != Weapon._WeaponType.Rocket && weapon_0.Type != Weapon._WeaponType.IronBomb)
				{
					WRA_FiringDoctrineEntry item5 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Soft_Unspecified, -2, 1, 0f, null);
					list.Add(item5);
					item5 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified, -2, 1, 0f, null);
					list.Add(item5);
				}
				else
				{
					WRA_FiringDoctrineEntry item6 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Soft_Unspecified, -99, -99, 0f, null);
					list.Add(item6);
					item6 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified, -99, -99, 0f, null);
					list.Add(item6);
				}
			}
			if (weapon_0.ValidTargets.Radar)
			{
				if (weapon_0.Type != Weapon._WeaponType.Gun && weapon_0.Type != Weapon._WeaponType.Rocket && weapon_0.Type != Weapon._WeaponType.IronBomb)
				{
					WRA_FiringDoctrineEntry item7 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Radar_Unspecified, -2, -99, 0f, null);
					list.Add(item7);
				}
				else
				{
					WRA_FiringDoctrineEntry item8 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Radar_Unspecified, -99, -99, 0f, null);
					list.Add(item8);
				}
			}
			if (weapon_0.ValidTargets.MobileTarget_Soft || (weapon_0.ValidTargets.LandStructure_Soft && !weapon_0.Flags.PreBriefedTargetOnly && !weapon_0.ValidTargets.MobileTarget_Soft) || weapon_0.ValidTargets.MobileTarget_Hard || (weapon_0.ValidTargets.LandStructure_Hard && !weapon_0.Flags.PreBriefedTargetOnly && !weapon_0.ValidTargets.MobileTarget_Hard))
			{
				if (weapon_0.Type != Weapon._WeaponType.Gun && weapon_0.Type != Weapon._WeaponType.Rocket && weapon_0.Type != Weapon._WeaponType.IronBomb)
				{
					WRA_FiringDoctrineEntry item9 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified, -2, 1, 0f, null);
					list.Add(item9);
					item9 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified, -2, 1, 0f, null);
					list.Add(item9);
				}
				else
				{
					WRA_FiringDoctrineEntry item10 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified, -99, -99, 0f, null);
					list.Add(item10);
					item10 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified, -99, -99, 0f, null);
					list.Add(item10);
				}
			}
			if (weapon_0.ValidTargets.UnderwaterStructure)
			{
				if (weapon_0.Type != Weapon._WeaponType.Gun && weapon_0.Type != Weapon._WeaponType.Rocket && weapon_0.Type != Weapon._WeaponType.IronBomb)
				{
					WRA_FiringDoctrineEntry item11 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Underwater_Structure, -2, 1, 0f, null);
					list.Add(item11);
				}
				else
				{
					WRA_FiringDoctrineEntry item13 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Underwater_Structure, -99, -99, 0f, null);
					list.Add(item13);
				}
			}
			if (weapon_0.ValidTargets.AirBaseSingleUnit)
			{
				if (weapon_0.Type != Weapon._WeaponType.Gun && weapon_0.Type != Weapon._WeaponType.Rocket && weapon_0.Type != Weapon._WeaponType.IronBomb)
				{
					WRA_FiringDoctrineEntry item14 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield, -2, 1, 0f, null);
					list.Add(item14);
				}
				else
				{
					WRA_FiringDoctrineEntry item15 = new WRA_FiringDoctrineEntry(_WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield, -99, -99, 0f, null);
					list.Add(item15);
				}
			}
			WRA_WeaponTargets = Misc.ChangeRequest(list);
		}

		internal Weapon WriteInterruptibleField(Scenario scenario_0, int int_0)
		{
			if (m_PublisherComparator == null)
			{
				if (IsUnguidedWeapon(scenario_0, int_0))
				{
					m_PublisherComparator = scenario_0.Cache_GetWeapon(int_0);
				}
				else
				{
					m_PublisherComparator = Weapon.GetNewWeapon(ref scenario_0, int_0, bool_0: false);
				}
			}
			return m_PublisherComparator;
		}

		public bool IsUnguidedWeapon(Scenario scenario_0, int int_0)
		{
			SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
			switch (DBFunctions.GetWeaponType(int_0, ref sqliteConnection_))
			{
			default:
				return false;
			case Weapon._WeaponType.Rocket:
			case Weapon._WeaponType.IronBomb:
			case Weapon._WeaponType.Gun:
			case Weapon._WeaponType.DepthCharge:
			case Weapon._WeaponType.Laser:
			case Weapon._WeaponType.Microwave:
			case Weapon._WeaponType.LaserDazzler:
			case Weapon._WeaponType.Troops:
			case Weapon._WeaponType.Paratroops:
				return true;
			}
		}
	}

	public class WRA_FiringDoctrineEntry
	{
		public _WRA_WeaponTargetType TargetType;

		public int? WeaponQty;

		public int? ShooterQty;

		public float? FiringRange;

		public float? SelfDefenceRange;

		public WRA_FiringDoctrineEntry()
		{
		}

		public WRA_FiringDoctrineEntry(WeaponTargets weaponTargets_0)
		{
		}

		public WRA_FiringDoctrineEntry(_WRA_WeaponTargetType _WRA_WeaponTargetType_0)
		{
			try
			{
				TargetType = _WRA_WeaponTargetType_0;
				WeaponQty = null;
				ShooterQty = null;
				SelfDefenceRange = null;
				FiringRange = null;
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

		public WRA_FiringDoctrineEntry(_WRA_WeaponTargetType _WRA_WeaponTargetType_0, int? nullable_0, int? nullable_1, float? nullable_2, float? nullable_3)
		{
			try
			{
				TargetType = _WRA_WeaponTargetType_0;
				WeaponQty = nullable_0;
				ShooterQty = nullable_1;
				SelfDefenceRange = nullable_2;
				FiringRange = nullable_3;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101203", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public enum _WRA_WeaponTargetType
	{
		None = 1001,
		Decoy = 1002,
		Air_Contact_Unknown_Type = 1999,
		Aircraft_Unspecified = 2000,
		Aircraft_5th_Generation = 2001,
		Aircraft_4th_Generation = 2002,
		Aircraft_3rd_Generation = 2003,
		Aircraft_Less_Capable = 2004,
		Aircraft_High_Perf_Bombers = 2011,
		Aircraft_Medium_Perf_Bombers = 2012,
		Aircraft_Low_Perf_Bombers = 2013,
		Aircraft_High_Perf_Recon_EW = 2021,
		Aircraft_Medium_Perf_Recon_EW = 2022,
		Aircraft_Low_Perf_Recon_EW = 2023,
		Aircraft_AEW = 2031,
		Aircraft_MicroUAV = 2032,
		Aircraft_Tanker = 2033,
		Helicopter_Unspecified = 2100,
		Guided_Weapon_Unspecified = 2200,
		Guided_Weapon_Supersonic_Sea_Skimming = 2201,
		Guided_Weapon_Subsonic_Sea_Skimming = 2202,
		Guided_Weapon_Supersonic = 2203,
		Guided_Weapon_Subsonic = 2204,
		Guided_Weapon_Ballistic = 2211,
		Satellite_Unspecified = 2300,
		C_RAM = 2400,
		Surface_Contact_Unknown_Type = 2999,
		Ship_Unspecified = 3000,
		Ship_Carrier_0_25000_tons = 3001,
		Ship_Carrier_25001_45000_tons = 3002,
		Ship_Carrier_45001_95000_tons = 3003,
		Ship_Carrier_95000_tons = 3004,
		Ship_Surface_Combatant_0_500_tons = 3101,
		Ship_Surface_Combatant_501_1500_tons = 3102,
		Ship_Surface_Combatant_1501_5000_tons = 3103,
		Ship_Surface_Combatant_5001_10000_tons = 3104,
		Ship_Surface_Combatant_10001_25000_tons = 3105,
		Ship_Surface_Combatant_25001_45000_tons = 3106,
		Ship_Surface_Combatant_45001_95000_tons = 3107,
		Ship_Surface_Combatant_95000_tons = 3108,
		Ship_Amphibious_0_500_tons = 3201,
		Ship_Amphibious_501_1500_tons = 3202,
		Ship_Amphibious_1501_5000_tons = 3203,
		Ship_Amphibious_5001_10000_tons = 3204,
		Ship_Amphibious_10001_25000_tons = 3205,
		Ship_Amphibious_25001_45000_tons = 3206,
		Ship_Amphibious_45001_95000_tons = 3207,
		Ship_Amphibious_95000_tons = 3208,
		Ship_Auxiliary_0_500_tons = 3301,
		Ship_Auxiliary_501_1500_tons = 3302,
		Ship_Auxiliary_1501_5000_tons = 3303,
		Ship_Auxiliary_5001_10000_tons = 3304,
		Ship_Auxiliary_10001_25000_tons = 3305,
		Ship_Auxiliary_25001_45000_tons = 3306,
		Ship_Auxiliary_45001_95000_tons = 3307,
		Ship_Auxiliary_95000_tons = 3308,
		Ship_Merchant_Civilian_0_500_tons = 3401,
		Ship_Merchant_Civilian_501_1500_tons = 3402,
		Ship_Merchant_Civilian_1501_5000_tons = 3403,
		Ship_Merchant_Civilian_5001_10000_tons = 3404,
		Ship_Merchant_Civilian_10001_25000_tons = 3405,
		Ship_Merchant_Civilian_25001_45000_tons = 3406,
		Ship_Merchant_Civilian_45001_95000_tons = 3407,
		Ship_Merchant_Civilian_95000_tons = 3408,
		Submarine_Surfaced = 3501,
		Subsurface_Contact_Unknown_Type = 3999,
		Submarine_Unspecified = 4000,
		Land_Contact_Unknown_Type = 4999,
		Land_Structure_Soft_Unspecified = 5000,
		Land_Structure_Soft_Building_Surface = 5001,
		Land_Structure_Soft_Building_Reveted = 5002,
		Land_Structure_Soft_Structure_Open = 5005,
		Land_Structure_Soft_Structure_Reveted = 5006,
		Land_Structure_Soft_Aerostat_Moring = 5011,
		Land_Structure_Hardened_Unspecified = 5100,
		Land_Structure_Hardened_Building_Surface = 5101,
		Land_Structure_Hardened_Building_Reveted = 5102,
		Land_Structure_Hardened_Building_Bunker = 5103,
		Land_Structure_Hardened_Building_Underground = 5104,
		Land_Structure_Hardened_Structure_Open = 5105,
		Land_Structure_Hardened_Structure_Reveted = 5106,
		Runway_Facility_Unspecified = 5200,
		Runway = 5201,
		Runway_Grade_Taxiway = 5202,
		Runway_Access_Point = 5203,
		Radar_Unspecified = 5300,
		Mobile_Target_Soft_Unspecified = 5400,
		Mobile_Target_Soft_Mobile_Vehicle = 5401,
		Mobile_Target_Soft_Mobile_Personnel = 5402,
		Mobile_Target_Hardened_Unspecified = 5500,
		Mobile_Target_Hardened_Mobile_Vehicle = 5501,
		Underwater_Structure = 5601,
		Air_Base_Single_Unit_Airfield = 5801
	}

	public enum _WRA_WeaponQty
	{
		SystemDefault = -1,
		DoNotUse = 0,
		NotDefined = -98,
		AllWeapons = -99,
		MissileDefence = -2,
		MissileDefence_x_2 = -3,
		MissileDefence_x_4 = -4,
		MissileDefence_d_2 = -5,
		MissileDefence_d_4 = -6,
		Various = -100,
		NotConfigured = -101
	}

	public enum _WRA_ShooterQty
	{
		SystemDefault = -1,
		AnyNumber = -99,
		Various = -100,
		NotConfigured = -101
	}

	public enum _WRA_SelfDefenceRange
	{
		SystemDefault = -1,
		DoNotUse = 0,
		NotDefined = -98,
		MaxRange = -99,
		Various = -100,
		NotConfigured = -101,
		NoEscapeZone = -102
	}

	public enum _WRA_FiringRange
	{
		DoNotUse = 0,
		Range25Percent = -95,
		Range50Percent = -96,
		Range75Percent = -97,
		NotDefined = -98,
		MaxRange = -99,
		Various = -100,
		NotConfigured = -101,
		NoEscapeZone = -102
	}

	public ScenarioObject Subject;

	public Type SubjectType;

	public List<ActiveUnit> SelectedUnits;

	public Scenario ScenarioContext;

	private EMCONSettings refIssuer;

	private Dictionary<int, WRA_Weapon> m_ErrorIssuer;

	private _WCS? codeIssuer;

	private bool connectionIssuer;

	private _WCS? m_ContextIssuer;

	private bool m_StatusIssuer;

	private _WCS? proccesorIssuer;

	private bool strategyIssuer;

	private _WCS? _ConfigurationIssuer;

	private bool m_TokenIssuer;

	private _GunStrafeGroundTargets? indexerIssuer;

	private bool m_ResolverIssuer;

	private _UseIgnorePlottedCourse? m_PublisherIssuer;

	private bool m_ServerIssuer;

	private _UseNukesAllowed? _AdapterIssuer;

	private bool _SchemaIssuer;

	private _WeaponStateRTB? m_UtilsIssuer;

	private bool _PredicateIssuer;

	private _FuelStateRTB? m_SingletonIssuer;

	private bool _RecordIssuer;

	private _JettisonOrdnance? _ExceptionIssuer;

	private bool attrIssuer;

	private _BVRLogicEnum? visitorIssuer;

	private bool exporterIssuer;

	private _BehaviorTowardsTargetAmbiguity? m_PrototypeIssuer;

	private bool comparatorIssuer;

	private _UseAutoEvade? _ItemIssuer;

	private bool _SetterIssuer;

	private _UseMaintainStandoff? creatorIssuer;

	private bool templateIssuer;

	private _NavigationMethod? _MappingIssuer;

	private bool mockIssuer;

	private _NavigationMethod? _TagIssuer;

	private bool m_FieldIssuer;

	private _NavigationMethod? m_QueueIssuer;

	private bool _RegIssuer;

	private _UseUnderwayRefuelAndReplenishment? paramIssuer;

	private bool m_PageIssuer;

	private _UnderwayRefuelAndReplenishmentSelection? rulesIssuer;

	private bool _MethodIssuer;

	private _UseShootTourists? serviceIssuer;

	private bool _SystemIssuer;

	private _UseSAMsAgainstShips? candidateIssuer;

	private bool baseIssuer;

	private _UseWpMissileAgainstShips? m_PolicyIssuer;

	private bool m_BroadcasterIssuer;

	private _UseIgnoreEMCONunderAttack? m_IdentifierIssuer;

	private bool printerIssuer;

	private _QuickTurnAroundForAicraft? parserIssuer;

	private bool m_AlgoIssuer;

	private _AirOpsTempo? m_DatabaseIssuer;

	private bool m_InterceptorIssuer;

	private _FuelState? m_MessageIssuer;

	private bool _ProductIssuer;

	private _WeaponState? _AnnotationIssuer;

	private bool iteratorIssuer;

	private _UseKinematicRangeForTorpedoes? m_InitializerIssuer;

	private bool _RoleIssuer;

	private _RefuelAlliedUnits? factoryIssuer;

	private bool m_AttributeIssuer;

	private _BingoThreshold_E? m_EventIssuer;

	private bool globalIssuer;

	private _AvoidContactWhenPossible? _WorkerIssuer;

	private bool accountIssuer;

	private _DiveOnContact? stateIssuer;

	private bool m_AuthenticationIssuer;

	private _RechargeBatteryPercentage? paramsIssuer;

	private bool infoIssuer;

	private _RechargeBatteryPercentage? helperIssuer;

	private bool mapperIssuer;

	private _UseAIP? _ManagerIssuer;

	private bool m_GetterIssuer;

	private _UseDippingSonar? m_ProducerIssuer;

	private bool _ProcIssuer;

	private _DamageThreshold? structClient;

	private _FuelQuantityThreshold? m_MerchantClient;

	private _WeaponQuantityThreshold? callbackClient;

	private _WeaponQuantityThreshold? _DecoratorClient;

	private _DamageThreshold? _ProcessClient;

	private _FuelQuantityThreshold? threadClient;

	private _WeaponQuantityThreshold? _RuleClient;

	private _WeaponQuantityThreshold? m_CollectionClient;

	[CompilerGenerated]
	private static DoctrineChangedEventHandler m_InstanceClient;

	[CompilerGenerated]
	private static EmconChangedEventHandler _ObjectClient;

	public bool DoctrineRefresh;

	private List<PriorityTargetEntry> m_ParameterClient;

	private Doctrine expressionClient;

	public List<PriorityTargetEntry> PriorityTargetList
	{
		get
		{
			List<PriorityTargetEntry> list = new List<PriorityTargetEntry>();
			list.AddRange(m_ParameterClient);
			return list;
		}
	}

	public bool EMCON_Inherits
	{
		get
		{
			return Information.IsNothing(refIssuer);
		}
		set
		{
			if (value)
			{
				refIssuer = null;
			}
			else if (Information.IsNothing(refIssuer))
			{
				refIssuer = new EMCONSettings();
			}
		}
	}

	public Dictionary<int, WRA_Weapon> WRA
	{
		get
		{
			return m_ErrorIssuer;
		}
		set
		{
			m_ErrorIssuer = value;
		}
	}

	public bool BingoThreshold_Inherits => !m_EventIssuer.HasValue;

	public static event DoctrineChangedEventHandler DoctrineChanged
	{
		[CompilerGenerated]
		add
		{
			DoctrineChangedEventHandler doctrineChangedEventHandler = m_InstanceClient;
			DoctrineChangedEventHandler doctrineChangedEventHandler2;
			do
			{
				doctrineChangedEventHandler2 = doctrineChangedEventHandler;
				DoctrineChangedEventHandler value2 = (DoctrineChangedEventHandler)Delegate.Combine(doctrineChangedEventHandler2, value);
				doctrineChangedEventHandler = Interlocked.CompareExchange(ref m_InstanceClient, value2, doctrineChangedEventHandler2);
			}
			while ((object)doctrineChangedEventHandler != doctrineChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DoctrineChangedEventHandler doctrineChangedEventHandler = m_InstanceClient;
			DoctrineChangedEventHandler doctrineChangedEventHandler2;
			do
			{
				doctrineChangedEventHandler2 = doctrineChangedEventHandler;
				DoctrineChangedEventHandler value2 = (DoctrineChangedEventHandler)Delegate.Remove(doctrineChangedEventHandler2, value);
				doctrineChangedEventHandler = Interlocked.CompareExchange(ref m_InstanceClient, value2, doctrineChangedEventHandler2);
			}
			while ((object)doctrineChangedEventHandler != doctrineChangedEventHandler2);
		}
	}

	public static event EmconChangedEventHandler EmconChanged
	{
		[CompilerGenerated]
		add
		{
			EmconChangedEventHandler emconChangedEventHandler = _ObjectClient;
			EmconChangedEventHandler emconChangedEventHandler2;
			do
			{
				emconChangedEventHandler2 = emconChangedEventHandler;
				EmconChangedEventHandler value2 = (EmconChangedEventHandler)Delegate.Combine(emconChangedEventHandler2, value);
				emconChangedEventHandler = Interlocked.CompareExchange(ref _ObjectClient, value2, emconChangedEventHandler2);
			}
			while ((object)emconChangedEventHandler != emconChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EmconChangedEventHandler emconChangedEventHandler = _ObjectClient;
			EmconChangedEventHandler emconChangedEventHandler2;
			do
			{
				emconChangedEventHandler2 = emconChangedEventHandler;
				EmconChangedEventHandler value2 = (EmconChangedEventHandler)Delegate.Remove(emconChangedEventHandler2, value);
				emconChangedEventHandler = Interlocked.CompareExchange(ref _ObjectClient, value2, emconChangedEventHandler2);
			}
			while ((object)emconChangedEventHandler != emconChangedEventHandler2);
		}
	}

	public static void RaiseEvent_EMCONChanged(ScenarioObject scenarioObject_0, bool? nullable_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3)
	{
		_ObjectClient?.Invoke(scenarioObject_0, nullable_0, bool_0, bool_1, bool_2, bool_3);
	}

	public Doctrine(ScenarioObject scenarioObject_0, ref List<ActiveUnit> list_0)
	{
		m_ParameterClient = new List<PriorityTargetEntry>();
		try
		{
			Subject = scenarioObject_0;
			SubjectType = scenarioObject_0.GetType();
			SelectedUnits = list_0;
			if ((object)SubjectType == typeof(Side))
			{
				_AdapterIssuer = _UseNukesAllowed.No;
				_SchemaIssuer = false;
				codeIssuer = _WCS.Tight;
				connectionIssuer = true;
				m_ContextIssuer = _WCS.Tight;
				m_StatusIssuer = true;
				proccesorIssuer = _WCS.Tight;
				strategyIssuer = true;
				_ConfigurationIssuer = _WCS.Tight;
				m_TokenIssuer = true;
				indexerIssuer = _GunStrafeGroundTargets.No;
				m_ResolverIssuer = true;
				m_PublisherIssuer = _UseIgnorePlottedCourse.No;
				m_ServerIssuer = true;
				m_PrototypeIssuer = _BehaviorTowardsTargetAmbiguity.Pessimistic;
				comparatorIssuer = true;
				_ItemIssuer = _UseAutoEvade.Yes;
				_SetterIssuer = true;
				creatorIssuer = _UseMaintainStandoff.Yes;
				templateIssuer = true;
				_MappingIssuer = _NavigationMethod.ShortestRoute;
				mockIssuer = true;
				_TagIssuer = _NavigationMethod.ShortestRoute;
				m_FieldIssuer = true;
				m_QueueIssuer = _NavigationMethod.ShortestRoute;
				_RegIssuer = true;
				paramIssuer = _UseUnderwayRefuelAndReplenishment.Always_ExceptTankersRefuellingTankers;
				m_PageIssuer = true;
				rulesIssuer = _UnderwayRefuelAndReplenishmentSelection.PickNearest;
				_MethodIssuer = true;
				serviceIssuer = _UseShootTourists.No;
				_SystemIssuer = true;
				candidateIssuer = _UseSAMsAgainstShips.No;
				baseIssuer = true;
				m_IdentifierIssuer = _UseIgnoreEMCONunderAttack.Yes;
				printerIssuer = true;
				parserIssuer = _QuickTurnAroundForAicraft.FightersAndASW;
				m_AlgoIssuer = false;
				m_DatabaseIssuer = _AirOpsTempo.Surge;
				m_InterceptorIssuer = false;
				_AnnotationIssuer = _WeaponState.LoadoutSetting;
				iteratorIssuer = true;
				m_UtilsIssuer = _WeaponStateRTB.YesLastUnit;
				_PredicateIssuer = true;
				m_MessageIssuer = _FuelState.Bingo;
				_ProductIssuer = true;
				_RecordIssuer = true;
				m_SingletonIssuer = _FuelStateRTB.YesFirstUnit;
				_ExceptionIssuer = _JettisonOrdnance.No;
				attrIssuer = true;
				visitorIssuer = _BVRLogicEnum.Crank;
				exporterIssuer = true;
				m_InitializerIssuer = _UseKinematicRangeForTorpedoes.No;
				_RoleIssuer = true;
				factoryIssuer = _RefuelAlliedUnits.Yes;
				m_AttributeIssuer = true;
				m_EventIssuer = _BingoThreshold_E.Bingo60Percent;
				globalIssuer = true;
				_WorkerIssuer = _AvoidContactWhenPossible.No;
				accountIssuer = true;
				stateIssuer = _DiveOnContact.Yes;
				m_AuthenticationIssuer = true;
				paramsIssuer = _RechargeBatteryPercentage.Recharge_60_Percent;
				infoIssuer = true;
				helperIssuer = _RechargeBatteryPercentage.Recharge_10_Percent;
				mapperIssuer = true;
				_ManagerIssuer = _UseAIP.Yes_AttackOnly;
				m_GetterIssuer = true;
				m_ProducerIssuer = _UseDippingSonar.Automatically_HoverAnd150ft;
				_ProcIssuer = true;
				refIssuer = new EMCONSettings();
				structClient = _DamageThreshold.Ignore;
				m_MerchantClient = _FuelQuantityThreshold.Bingo;
				callbackClient = _WeaponQuantityThreshold.Ignore;
				_DecoratorClient = _WeaponQuantityThreshold.Ignore;
				_ProcessClient = _DamageThreshold.Percent5;
				threadClient = _FuelQuantityThreshold.const_5;
				_RuleClient = _WeaponQuantityThreshold.const_5;
				m_CollectionClient = _WeaponQuantityThreshold.const_5;
			}
			else if ((object)SubjectType == typeof(Waypoint))
			{
				_AdapterIssuer = _UseNukesAllowed.NotConfigured;
				codeIssuer = _WCS.NotConfigured;
				m_ContextIssuer = _WCS.NotConfigured;
				proccesorIssuer = _WCS.NotConfigured;
				_ConfigurationIssuer = _WCS.NotConfigured;
				indexerIssuer = _GunStrafeGroundTargets.NotConfigured;
				m_PublisherIssuer = _UseIgnorePlottedCourse.NotConfigured;
				m_PrototypeIssuer = _BehaviorTowardsTargetAmbiguity.NotConfigured;
				_ItemIssuer = _UseAutoEvade.NotConfigured;
				creatorIssuer = _UseMaintainStandoff.NotConfigured;
				_MappingIssuer = _NavigationMethod.NotConfigured;
				_TagIssuer = _NavigationMethod.NotConfigured;
				m_QueueIssuer = _NavigationMethod.NotConfigured;
				paramIssuer = _UseUnderwayRefuelAndReplenishment.NotConfigured;
				rulesIssuer = _UnderwayRefuelAndReplenishmentSelection.NotConfigured;
				serviceIssuer = _UseShootTourists.NotConfigured;
				candidateIssuer = _UseSAMsAgainstShips.NotConfigured;
				m_IdentifierIssuer = _UseIgnoreEMCONunderAttack.NotConfigured;
				parserIssuer = _QuickTurnAroundForAicraft.NotConfigured;
				m_DatabaseIssuer = _AirOpsTempo.NotConfigured;
				_AnnotationIssuer = _WeaponState.NotConfigured;
				m_UtilsIssuer = _WeaponStateRTB.NotConfigured;
				m_MessageIssuer = _FuelState.NotConfigured;
				m_SingletonIssuer = _FuelStateRTB.NotConfigured;
				m_EventIssuer = _BingoThreshold_E.NotConfigured;
				_ExceptionIssuer = _JettisonOrdnance.NotConfigured;
				visitorIssuer = _BVRLogicEnum.NotConfigured;
				m_InitializerIssuer = _UseKinematicRangeForTorpedoes.NotConfigured;
				factoryIssuer = _RefuelAlliedUnits.NotConfigured;
				_WorkerIssuer = _AvoidContactWhenPossible.NotConfigured;
				stateIssuer = _DiveOnContact.NotConfigured;
				paramsIssuer = _RechargeBatteryPercentage.NotConfigured;
				helperIssuer = _RechargeBatteryPercentage.NotConfigured;
				_ManagerIssuer = _UseAIP.NotConfigured;
				m_ProducerIssuer = _UseDippingSonar.NotConfigured;
				structClient = _DamageThreshold.NotConfigured;
				m_MerchantClient = _FuelQuantityThreshold.NotConfigured;
				callbackClient = _WeaponQuantityThreshold.NotConfigured;
				_DecoratorClient = _WeaponQuantityThreshold.NotConfigured;
				_ProcessClient = _DamageThreshold.NotConfigured;
				threadClient = _FuelQuantityThreshold.NotConfigured;
				_RuleClient = _WeaponQuantityThreshold.NotConfigured;
				m_CollectionClient = _WeaponQuantityThreshold.NotConfigured;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101000", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal Doctrine PatchRepository(ref Doctrine doctrine_0, ScenarioObject scenarioObject_0, ref Scenario scenario_0)
	{
		EMCONSettings._EMCONSetting eMCONSetting_;
		EMCONSettings._EMCONSetting eMCONSetting_2;
		EMCONSettings._EMCONSetting eMCONSetting_3;
		if (doctrine_0.EMCON_Inherits && (object)SubjectType == typeof(Waypoint))
		{
			eMCONSetting_ = EMCONSettings._EMCONSetting.NotConfigured;
			eMCONSetting_2 = EMCONSettings._EMCONSetting.NotConfigured;
			eMCONSetting_3 = EMCONSettings._EMCONSetting.NotConfigured;
		}
		else
		{
			eMCONSetting_ = doctrine_0.NewRepository(scenario_0).LoginInterruptibleField();
			eMCONSetting_2 = doctrine_0.NewRepository(scenario_0).GetInterruptibleField();
			eMCONSetting_3 = doctrine_0.NewRepository(scenario_0).OECM();
		}
		return new Doctrine(ref scenario_0, ref scenarioObject_0, doctrine_0._AdapterIssuer, doctrine_0.NukesAllowed_Inherits(), doctrine_0.codeIssuer, doctrine_0.WeaponControlStatus_Air_Inherits(), doctrine_0.m_ContextIssuer, doctrine_0.WeaponControlStatus_Surface_Inherits(), doctrine_0.proccesorIssuer, doctrine_0.WeaponControlStatus_Submarine_Inherits(), doctrine_0._ConfigurationIssuer, doctrine_0.WeaponControlStatus_Land_Inherits(), doctrine_0.indexerIssuer, doctrine_0.GunStrafing_Inherits(), doctrine_0.m_PublisherIssuer, doctrine_0.IgnorePlottedCourse_Inherits(), doctrine_0.m_PrototypeIssuer, doctrine_0.BehaviorTowardsAmbigousTarget_Inherits(), doctrine_0._ItemIssuer, doctrine_0.AutoEvade_Inherits(), doctrine_0.creatorIssuer, doctrine_0.MaintainStandoff_Inherits(), doctrine_0.paramIssuer, doctrine_0.UseReplenishment_Inherits(), doctrine_0.rulesIssuer, doctrine_0.ReplenishmentSelection_Inherits(), doctrine_0.serviceIssuer, doctrine_0.ShootTourists_Inherits(), doctrine_0.candidateIssuer, doctrine_0.UseSAMsOnASuW_Inherits(), doctrine_0.m_IdentifierIssuer, doctrine_0.IgnoreEMCONunderAttack_Inherits(), doctrine_0.parserIssuer, doctrine_0.QuickTurnAroundForAicraft_Inherits(), doctrine_0.m_DatabaseIssuer, doctrine_0.AirOpsTempo_Inherits(), doctrine_0._AnnotationIssuer, doctrine_0.WinchesterShotgun_Inherits(), doctrine_0.m_UtilsIssuer, doctrine_0.WinchesterShotgunRTB_Inherits(), doctrine_0.m_MessageIssuer, doctrine_0.BingoJoker_Inherits(), doctrine_0.m_SingletonIssuer, doctrine_0.BingoJokerRTB_Inherits(), doctrine_0._ExceptionIssuer, doctrine_0.JettisonOrdnance_Inherits(), doctrine_0.visitorIssuer, doctrine_0.BVRLogic_Inherits(), doctrine_0.m_InitializerIssuer, doctrine_0.UseKinematicRangeForTorpedoes_Inherits(), doctrine_0.factoryIssuer, doctrine_0.RefuelAllies_Inherits(), doctrine_0.m_EventIssuer, doctrine_0.BingoThreshold_Inherits, doctrine_0._WorkerIssuer, doctrine_0.AvoidContact_Inherits(), doctrine_0.stateIssuer, doctrine_0.DiveWhenThreatsDetected_Inherits(), doctrine_0.paramsIssuer, doctrine_0.RechargePercentagePatrol_Inherits(), doctrine_0.helperIssuer, doctrine_0.RechargePercentageAttack_Inherits(), doctrine_0._ManagerIssuer, doctrine_0.AIPUsage_Inherits(), doctrine_0.m_ProducerIssuer, doctrine_0.DippingSonar_Inherits(), doctrine_0.structClient, doctrine_0.WithdrawDamageThreshold_Inherits(), doctrine_0.m_MerchantClient, doctrine_0.WithdrawFuelThreshold_Inherits(), doctrine_0.callbackClient, doctrine_0.WithdrawAttackThreshold_Inherits(), doctrine_0._DecoratorClient, doctrine_0.WithdrawDefenceThreshold_Inherits(), doctrine_0._ProcessClient, doctrine_0.RedeployDamageThreshold_Inherits(), doctrine_0.threadClient, doctrine_0.RedeployFuelThreshold_Inherits(), doctrine_0._RuleClient, doctrine_0.RedeployAttackThreshold_Inherits(), doctrine_0.m_CollectionClient, doctrine_0.RedeployDefenceThreshold_Inherits(), eMCONSetting_, eMCONSetting_2, eMCONSetting_3, doctrine_0.EMCON_Inherits, doctrine_0._MappingIssuer, doctrine_0.SurfaceNavigation_Inherits(), doctrine_0._TagIssuer, doctrine_0.SubmarineNavigation_Inherits(), doctrine_0.m_QueueIssuer, doctrine_0.LandNavigation_Inherits());
	}

	public Doctrine(ref Scenario scenario_0, ref ScenarioObject scenarioObject_0, _UseNukesAllowed? nullable_0, bool bool_0, _WCS? nullable_1, bool bool_1, _WCS? nullable_2, bool bool_2, _WCS? nullable_3, bool bool_3, _WCS? nullable_4, bool bool_4, _GunStrafeGroundTargets? nullable_5, bool bool_5, _UseIgnorePlottedCourse? nullable_6, bool bool_6, _BehaviorTowardsTargetAmbiguity? nullable_7, bool bool_7, _UseAutoEvade? nullable_8, bool bool_8, _UseMaintainStandoff? nullable_9, bool bool_9, _UseUnderwayRefuelAndReplenishment? nullable_10, bool bool_10, _UnderwayRefuelAndReplenishmentSelection? nullable_11, bool bool_11, _UseShootTourists? nullable_12, bool bool_12, _UseSAMsAgainstShips? nullable_13, bool bool_13, _UseIgnoreEMCONunderAttack? nullable_14, bool bool_14, _QuickTurnAroundForAicraft? nullable_15, bool bool_15, _AirOpsTempo? nullable_16, bool bool_16, _WeaponState? nullable_17, bool bool_17, _WeaponStateRTB? nullable_18, bool bool_18, _FuelState? nullable_19, bool bool_19, _FuelStateRTB? nullable_20, bool bool_20, _JettisonOrdnance? nullable_21, bool bool_21, _BVRLogicEnum? nullable_22, bool bool_22, _UseKinematicRangeForTorpedoes? nullable_23, bool bool_23, _RefuelAlliedUnits? nullable_24, bool bool_24, _BingoThreshold_E? nullable_25, bool bool_25, _AvoidContactWhenPossible? nullable_26, bool bool_26, _DiveOnContact? nullable_27, bool bool_27, _RechargeBatteryPercentage? nullable_28, bool bool_28, _RechargeBatteryPercentage? nullable_29, bool bool_29, _UseAIP? nullable_30, bool bool_30, _UseDippingSonar? nullable_31, bool bool_31, _DamageThreshold? nullable_32, bool bool_32, _FuelQuantityThreshold? nullable_33, bool bool_33, _WeaponQuantityThreshold? nullable_34, bool bool_34, _WeaponQuantityThreshold? nullable_35, bool bool_35, _DamageThreshold? nullable_36, bool bool_36, _FuelQuantityThreshold? nullable_37, bool bool_37, _WeaponQuantityThreshold? nullable_38, bool bool_38, _WeaponQuantityThreshold? nullable_39, bool bool_39, EMCONSettings._EMCONSetting _EMCONSetting_0, EMCONSettings._EMCONSetting _EMCONSetting_1, EMCONSettings._EMCONSetting _EMCONSetting_2, bool bool_40, _NavigationMethod? nullable_40, bool bool_41, _NavigationMethod? nullable_41, bool bool_42, _NavigationMethod? nullable_42, bool bool_43)
	{
		m_ParameterClient = new List<PriorityTargetEntry>();
		try
		{
			Subject = scenarioObject_0;
			SubjectType = scenarioObject_0.GetType();
			if (bool_0)
			{
				_AdapterIssuer = null;
			}
			else
			{
				_AdapterIssuer = nullable_0;
			}
			if (bool_1)
			{
				codeIssuer = null;
			}
			else
			{
				codeIssuer = nullable_1;
			}
			if (bool_2)
			{
				m_ContextIssuer = null;
			}
			else
			{
				m_ContextIssuer = nullable_2;
			}
			if (bool_3)
			{
				proccesorIssuer = null;
			}
			else
			{
				proccesorIssuer = nullable_3;
			}
			if (bool_4)
			{
				_ConfigurationIssuer = null;
			}
			else
			{
				_ConfigurationIssuer = nullable_4;
			}
			if (bool_5)
			{
				indexerIssuer = null;
			}
			else
			{
				indexerIssuer = nullable_5;
			}
			if (bool_6)
			{
				m_PublisherIssuer = null;
			}
			else
			{
				m_PublisherIssuer = nullable_6;
			}
			if (bool_7)
			{
				m_PrototypeIssuer = null;
			}
			else
			{
				m_PrototypeIssuer = nullable_7;
			}
			if (bool_8)
			{
				_ItemIssuer = null;
			}
			else
			{
				_ItemIssuer = nullable_8;
			}
			if (bool_9)
			{
				creatorIssuer = null;
			}
			else
			{
				creatorIssuer = nullable_9;
			}
			if (bool_41)
			{
				_MappingIssuer = null;
			}
			else
			{
				_MappingIssuer = nullable_40;
			}
			if (bool_42)
			{
				_TagIssuer = null;
			}
			else
			{
				_TagIssuer = nullable_41;
			}
			if (bool_43)
			{
				m_QueueIssuer = null;
			}
			else
			{
				m_QueueIssuer = nullable_42;
			}
			if (bool_10)
			{
				paramIssuer = null;
			}
			else
			{
				paramIssuer = nullable_10;
			}
			if (bool_11)
			{
				rulesIssuer = null;
			}
			else
			{
				rulesIssuer = nullable_11;
			}
			if (bool_12)
			{
				serviceIssuer = null;
			}
			else
			{
				serviceIssuer = nullable_12;
			}
			if (bool_13)
			{
				candidateIssuer = null;
			}
			else
			{
				candidateIssuer = nullable_13;
			}
			if (bool_14)
			{
				m_IdentifierIssuer = null;
			}
			else
			{
				m_IdentifierIssuer = nullable_14;
			}
			if (bool_15)
			{
				parserIssuer = null;
			}
			else
			{
				parserIssuer = nullable_15;
			}
			if (bool_16)
			{
				m_DatabaseIssuer = null;
			}
			else
			{
				m_DatabaseIssuer = nullable_16;
			}
			if (bool_17)
			{
				_AnnotationIssuer = null;
			}
			else
			{
				_AnnotationIssuer = nullable_17;
			}
			if (bool_18)
			{
				m_UtilsIssuer = null;
			}
			else
			{
				m_UtilsIssuer = nullable_18;
			}
			if (bool_19)
			{
				m_MessageIssuer = null;
			}
			else
			{
				m_MessageIssuer = nullable_19;
			}
			if (bool_20)
			{
				m_SingletonIssuer = null;
			}
			else
			{
				m_SingletonIssuer = nullable_20;
			}
			if (bool_21)
			{
				_ExceptionIssuer = null;
			}
			else
			{
				_ExceptionIssuer = nullable_21;
			}
			if (bool_22)
			{
				visitorIssuer = null;
			}
			else
			{
				visitorIssuer = nullable_22;
			}
			if (bool_23)
			{
				m_InitializerIssuer = null;
			}
			else
			{
				m_InitializerIssuer = nullable_23;
			}
			if (bool_24)
			{
				factoryIssuer = null;
			}
			else
			{
				factoryIssuer = nullable_24;
			}
			if (bool_25)
			{
				m_EventIssuer = null;
			}
			else
			{
				m_EventIssuer = nullable_25;
			}
			if (bool_26)
			{
				_WorkerIssuer = null;
			}
			else
			{
				_WorkerIssuer = nullable_26;
			}
			if (bool_27)
			{
				stateIssuer = null;
			}
			else
			{
				stateIssuer = nullable_27;
			}
			if (bool_28)
			{
				paramsIssuer = null;
			}
			else
			{
				paramsIssuer = nullable_28;
			}
			if (bool_29)
			{
				helperIssuer = null;
			}
			else
			{
				helperIssuer = nullable_29;
			}
			if (bool_30)
			{
				_ManagerIssuer = null;
			}
			else
			{
				_ManagerIssuer = nullable_30;
			}
			if (bool_31)
			{
				m_ProducerIssuer = null;
			}
			else
			{
				m_ProducerIssuer = nullable_31;
			}
			if (bool_32)
			{
				structClient = null;
			}
			else
			{
				structClient = nullable_32;
			}
			if (bool_33)
			{
				m_MerchantClient = null;
			}
			else
			{
				m_MerchantClient = nullable_33;
			}
			if (bool_34)
			{
				callbackClient = null;
			}
			else
			{
				callbackClient = nullable_34;
			}
			if (bool_35)
			{
				_DecoratorClient = null;
			}
			else
			{
				_DecoratorClient = nullable_35;
			}
			if (bool_36)
			{
				_ProcessClient = null;
			}
			else
			{
				_ProcessClient = nullable_36;
			}
			if (bool_37)
			{
				threadClient = null;
			}
			else
			{
				threadClient = nullable_37;
			}
			if (bool_38)
			{
				_RuleClient = null;
			}
			else
			{
				_RuleClient = nullable_38;
			}
			if (bool_39)
			{
				m_CollectionClient = null;
			}
			else
			{
				m_CollectionClient = nullable_39;
			}
			if (bool_40)
			{
				EMCON_Inherits = bool_40;
				return;
			}
			EMCON_Inherits = bool_40;
			SetEMCON_Radar(_EMCONSetting_0, scenario_0);
			SetEMCON_Sonar(_EMCONSetting_1, scenario_0);
			SetEMCON_OECM(_EMCONSetting_2, scenario_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101306", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CreatePriorityTargetList()
	{
		m_ParameterClient.Add(new PriorityTargetEntry());
	}

	public void RemovePriorityTargetList()
	{
		m_ParameterClient = new List<PriorityTargetEntry>();
	}

	public void AddPriorityTargetListEntry(GlobalVariables.ActiveUnitType activeUnitType_0, int int_0, int int_1, int int_2)
	{
		if (int_2 >= 0 && int_2 < m_ParameterClient.Count)
		{
			int num = 0;
			PriorityTargetEntry.PriorityFlags priorityFlags_ = PriorityTargetEntry.PriorityFlags.PriorityLow;
			using (List<PriorityTargetEntry>.Enumerator enumerator = m_ParameterClient.GetEnumerator())
			{
				while (enumerator.MoveNext() && enumerator.Current.Priority != PriorityTargetEntry.PriorityFlags.PriorityDefault)
				{
					num++;
				}
			}
			if (int_2 <= num)
			{
				priorityFlags_ = PriorityTargetEntry.PriorityFlags.PriorityHigh;
			}
			PriorityTargetEntry item = new PriorityTargetEntry(activeUnitType_0, int_0, int_1, priorityFlags_);
			m_ParameterClient.Insert(int_2, item);
		}
		else
		{
			PriorityTargetEntry item2 = new PriorityTargetEntry(activeUnitType_0, int_0, int_1, PriorityTargetEntry.PriorityFlags.PriorityLow);
			m_ParameterClient.Add(item2);
		}
	}

	public void DeletePriorityTargetListEntry(int int_0)
	{
		if (m_ParameterClient.Count > int_0 && m_ParameterClient[int_0].Priority != PriorityTargetEntry.PriorityFlags.PriorityDefault)
		{
			m_ParameterClient.RemoveAt(int_0);
		}
	}

	public void SwapPriorityTargetListEntry(int int_0, bool bool_0)
	{
		if (m_ParameterClient.Count < 2)
		{
			return;
		}
		int num = int_0;
		num = (bool_0 ? Math.Max(int_0 - 1, 0) : Math.Min(int_0 + 1, m_ParameterClient.Count - 1));
		if (int_0 == num)
		{
			return;
		}
		PriorityTargetEntry priorityTargetEntry = m_ParameterClient[num];
		m_ParameterClient[num] = m_ParameterClient[int_0];
		m_ParameterClient[int_0] = priorityTargetEntry;
		if (priorityTargetEntry.Priority == PriorityTargetEntry.PriorityFlags.PriorityDefault)
		{
			if (bool_0)
			{
				m_ParameterClient[num].Priority = PriorityTargetEntry.PriorityFlags.PriorityHigh;
			}
			else
			{
				m_ParameterClient[num].Priority = PriorityTargetEntry.PriorityFlags.PriorityLow;
			}
		}
		else if (m_ParameterClient[num].Priority == PriorityTargetEntry.PriorityFlags.PriorityDefault)
		{
			if (bool_0)
			{
				priorityTargetEntry.Priority = PriorityTargetEntry.PriorityFlags.PriorityLow;
			}
			else
			{
				priorityTargetEntry.Priority = PriorityTargetEntry.PriorityFlags.PriorityHigh;
			}
		}
	}

	public void SortPriorityTargetList()
	{
		if (m_ParameterClient == null || m_ParameterClient.Count <= 1)
		{
			return;
		}
		List<PriorityTargetEntry> list = new List<PriorityTargetEntry>();
		List<PriorityTargetEntry> list2 = new List<PriorityTargetEntry>();
		foreach (PriorityTargetEntry item in m_ParameterClient)
		{
			switch (item.Priority)
			{
			case PriorityTargetEntry.PriorityFlags.PriorityHigh:
				list.Add(item);
				break;
			case PriorityTargetEntry.PriorityFlags.PriorityLow:
				list2.Add(item);
				break;
			}
		}
		m_ParameterClient = new List<PriorityTargetEntry>();
		m_ParameterClient.AddRange(list);
		m_ParameterClient.Add(new PriorityTargetEntry());
		m_ParameterClient.AddRange(list2);
	}

	internal string SelectRepository(Scenario scenario_0)
	{
		if (m_ParameterClient.Count > 1)
		{
			int num = m_ParameterClient.Count - 2;
			for (int i = 0; i <= num; i++)
			{
				int num2 = i + 1;
				int num3 = m_ParameterClient.Count - 1;
				for (int j = num2; j <= num3; j++)
				{
					if (m_ParameterClient[j].Type == m_ParameterClient[i].Type)
					{
						if (m_ParameterClient[i].SubType == 0)
						{
							return "Warning: Priority Target List entry at index " + i + " " + m_ParameterClient[i].SelectInterruptibleField(scenario_0) + " will always apply before similar entry at index " + j + " " + m_ParameterClient[j].SelectInterruptibleField(scenario_0);
						}
						if (m_ParameterClient[j].SubType == m_ParameterClient[i].SubType && (m_ParameterClient[i].DBID == 0 || m_ParameterClient[j].DBID == m_ParameterClient[i].DBID))
						{
							return "Warning: Priority Target List entry at index " + i + " " + m_ParameterClient[i].SelectInterruptibleField(scenario_0) + " will always apply before similar entry at index " + j + " " + m_ParameterClient[j].SelectInterruptibleField(scenario_0);
						}
					}
				}
			}
		}
		return "";
	}

	internal bool CallRepository(Scenario scenario_0)
	{
		if (m_ParameterClient.Count <= 0)
		{
			bool bool_ = true;
			Doctrine parentDoctrine = GetParentDoctrine(scenario_0, ref bool_);
			while (true)
			{
				if (parentDoctrine != null)
				{
					if (parentDoctrine.m_ParameterClient.Count > 0)
					{
						break;
					}
					if (!(parentDoctrine.Subject is Side))
					{
						Doctrine doctrine = parentDoctrine;
						bool_ = true;
						parentDoctrine = doctrine.GetParentDoctrine(scenario_0, ref bool_);
						continue;
					}
					return false;
				}
				return false;
			}
			return true;
		}
		return true;
	}

	internal Doctrine LogoutRepository(Scenario scenario_0)
	{
		if (m_ParameterClient.Count <= 0)
		{
			bool bool_ = true;
			Doctrine parentDoctrine = GetParentDoctrine(scenario_0, ref bool_);
			while (true)
			{
				if (parentDoctrine != null)
				{
					if (parentDoctrine.m_ParameterClient.Count > 0)
					{
						break;
					}
					if (!(parentDoctrine.Subject is Side))
					{
						Doctrine doctrine = parentDoctrine;
						bool_ = true;
						parentDoctrine = doctrine.GetParentDoctrine(scenario_0, ref bool_);
						continue;
					}
					return null;
				}
				return null;
			}
			return parentDoctrine;
		}
		return this;
	}

	internal List<Contact> ViewRepository(Scenario scenario_0, List<Contact> list_0)
	{
		List<Contact> list = new List<Contact>();
		if (list_0 != null && list_0.Count != 0)
		{
			List<Contact> list2 = new List<Contact>();
			List<Contact> list3 = new List<Contact>();
			List<PriorityTargetEntry> parameterClient = m_ParameterClient;
			bool bool_ = true;
			Doctrine parentDoctrine = GetParentDoctrine(scenario_0, ref bool_);
			bool flag = false;
			while (parameterClient.Count < 2 && parentDoctrine != null)
			{
				parameterClient = parentDoctrine.m_ParameterClient;
				if (parentDoctrine.Subject is Side)
				{
					break;
				}
				Doctrine doctrine = parentDoctrine;
				bool_ = true;
				parentDoctrine = doctrine.GetParentDoctrine(scenario_0, ref bool_);
			}
			list.AddRange(list_0);
			if (parameterClient.Count < 2)
			{
				return list;
			}
			foreach (PriorityTargetEntry item in parameterClient)
			{
				switch (item.Priority)
				{
				case PriorityTargetEntry.PriorityFlags.PriorityHigh:
					foreach (Contact item2 in list_0)
					{
						if (item.ValidateInterruptibleField(item2))
						{
							list2.Add(item2);
						}
					}
					if (list2.Count > 0)
					{
						return list2;
					}
					break;
				case PriorityTargetEntry.PriorityFlags.PriorityLow:
					foreach (Contact item3 in list_0)
					{
						if (item.ValidateInterruptibleField(item3))
						{
							list.Remove(item3);
							if (!flag)
							{
								list3.Add(item3);
							}
						}
					}
					if (list3.Count > 0)
					{
						flag = true;
					}
					break;
				}
			}
			if (list.Count == 0 && list3.Count > 0)
			{
				list.AddRange(list3);
			}
			return list;
		}
		return list;
	}

	internal List<Contact> ValidateRepository(Scenario scenario_0, List<Contact> list_0)
	{
		List<Contact> list = new List<Contact>();
		if (list_0 != null && list_0.Count != 0)
		{
			List<Contact> list2 = new List<Contact>();
			List<Contact> list3 = new List<Contact>();
			List<Contact> list4 = new List<Contact>();
			List<PriorityTargetEntry> parameterClient = m_ParameterClient;
			bool bool_ = true;
			Doctrine parentDoctrine = GetParentDoctrine(scenario_0, ref bool_);
			bool flag = false;
			while (parameterClient.Count < 2 && parentDoctrine != null)
			{
				parameterClient = parentDoctrine.m_ParameterClient;
				if (parentDoctrine.Subject is Side)
				{
					break;
				}
				Doctrine doctrine = parentDoctrine;
				bool_ = true;
				parentDoctrine = doctrine.GetParentDoctrine(scenario_0, ref bool_);
			}
			if (parameterClient.Count < 2)
			{
				list.AddRange(list_0);
				return list;
			}
			list4.AddRange(list_0);
			foreach (PriorityTargetEntry item in parameterClient)
			{
				switch (item.Priority)
				{
				case PriorityTargetEntry.PriorityFlags.PriorityHigh:
					foreach (Contact item2 in list_0)
					{
						if (item.ValidateInterruptibleField(item2))
						{
							list2.Add(item2);
							list4.Remove(item2);
						}
					}
					break;
				case PriorityTargetEntry.PriorityFlags.PriorityLow:
					foreach (Contact item3 in list_0)
					{
						if (item.ValidateInterruptibleField(item3))
						{
							list.Remove(item3);
							if (!flag)
							{
								list3.Add(item3);
								list4.Remove(item3);
							}
						}
					}
					break;
				}
			}
			list.AddRange(list2);
			list.AddRange(list4);
			list.AddRange(list3);
			return list;
		}
		return list;
	}

	public void FireEvent_DoctrineChanged(ScenarioObject scenarioObject_0, bool? nullable_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3)
	{
		m_InstanceClient?.Invoke(scenarioObject_0, nullable_0, bool_0, bool_1, bool_2, bool_3);
	}

	public void FireEvent_EmconChanged(ScenarioObject scenarioObject_0, bool? nullable_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3)
	{
		_ObjectClient?.Invoke(scenarioObject_0, nullable_0, bool_0, bool_1, bool_2, bool_3);
	}

	public void InheritDoctrine(ref Scenario scenario_0, ref Type type_0)
	{
		try
		{
			if ((object)type_0 != typeof(Side) && (object)type_0 != typeof(Waypoint))
			{
				_AdapterIssuer = null;
				codeIssuer = null;
				m_ContextIssuer = null;
				proccesorIssuer = null;
				_ConfigurationIssuer = null;
				indexerIssuer = null;
				m_PublisherIssuer = null;
				m_PrototypeIssuer = null;
				_ItemIssuer = null;
				creatorIssuer = null;
				_MappingIssuer = null;
				_TagIssuer = null;
				m_QueueIssuer = null;
				paramIssuer = null;
				rulesIssuer = null;
				serviceIssuer = null;
				candidateIssuer = null;
				m_IdentifierIssuer = null;
				parserIssuer = null;
				m_DatabaseIssuer = null;
				_AnnotationIssuer = null;
				m_UtilsIssuer = null;
				m_MessageIssuer = null;
				m_SingletonIssuer = null;
				_ExceptionIssuer = null;
				visitorIssuer = null;
				m_InitializerIssuer = null;
				factoryIssuer = null;
				m_EventIssuer = null;
				_WorkerIssuer = null;
				stateIssuer = null;
				paramsIssuer = null;
				helperIssuer = null;
				_ManagerIssuer = null;
				m_ProducerIssuer = null;
				structClient = null;
				m_MerchantClient = null;
				callbackClient = null;
				_DecoratorClient = null;
				_ProcessClient = null;
				threadClient = null;
				_RuleClient = null;
				m_CollectionClient = null;
				EMCON_Inherits = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at IneritDoctrine", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Doctrine GetParentDoctrine(Scenario scenario_0, ref bool bool_0, bool bool_1 = false, Side side_0 = null)
	{
		try
		{
			if (expressionClient == null)
			{
				try
				{
					if (!bool_0 && Subject.IsActiveUnit)
					{
						ActiveUnit activeUnit = (ActiveUnit)Subject;
						if (activeUnit.IsAircraft)
						{
							Aircraft aircraft = (Aircraft)activeUnit;
							if (!aircraft.IsOperating())
							{
								Aircraft_AirOps airOps = aircraft.AirOps;
								if (airOps.CurrentHostUnit != null)
								{
									return airOps.CurrentHostUnit.Doctrine;
								}
							}
						}
					}
					if (Subject.IsGroup)
					{
						Group group = (Group)Subject;
						if (group.AssignedMissionOrPackage() != null && (group.AssignedMissionOrPackage().IsActive || bool_1))
						{
							if (group.GroupLead != null && group.GroupLead.AI.IsEscort)
							{
								if (group.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
								{
									expressionClient = ((Strike)group.AssignedMissionOrPackage()).Doctrine_Escorts;
								}
								else
								{
									expressionClient = group.AssignedMissionOrPackage().Doctrine;
								}
							}
							else
							{
								expressionClient = group.AssignedMissionOrPackage().Doctrine;
							}
						}
						else
						{
							expressionClient = group.GetUnitSide().Doctrine;
						}
					}
					else if (Subject.IsActiveUnit)
					{
						ActiveUnit activeUnit2 = (ActiveUnit)Subject;
						if (activeUnit2.IsGroupMember())
						{
							expressionClient = activeUnit2.GetParentGroup().Doctrine;
						}
						else if (activeUnit2.AssignedMissionOrPackage() != null && (activeUnit2.AssignedMissionOrPackage().IsActive || bool_1))
						{
							if (activeUnit2.AI.IsEscort && activeUnit2.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
							{
								expressionClient = ((Strike)activeUnit2.AssignedMissionOrPackage()).Doctrine_Escorts;
							}
							else
							{
								expressionClient = activeUnit2.AssignedMissionOrPackage().Doctrine;
							}
						}
						else if (activeUnit2.IsWeapon)
						{
							ActiveUnit firingParent = ((Weapon)activeUnit2).FiringParent;
							if (firingParent == null)
							{
								expressionClient = activeUnit2.GetUnitSide().Doctrine;
							}
							else
							{
								expressionClient = firingParent.GetUnitSide().Doctrine;
							}
						}
						else
						{
							expressionClient = activeUnit2.GetUnitSide().Doctrine;
						}
					}
					else if (Subject.IsMission)
					{
						Mission value = (Mission)Subject;
						Side[] sides_ReadOnly2 = scenario_0.Sides_ReadOnly;
						Side[] array = sides_ReadOnly2;
						foreach (Side side in array)
						{
							if (side.GetMissionsTotal(scenario_0).Contains(value))
							{
								expressionClient = side.Doctrine;
								break;
							}
						}
						if (expressionClient == null)
						{
							if (side_0 != null)
							{
								return side_0.Doctrine;
							}
							side_0 = scenario_0.GetCurrentSide();
							if (side_0 != null)
							{
								return side_0.Doctrine;
							}
						}
					}
					else if (Subject.IsWaypoint)
					{
						Waypoint waypoint = (Waypoint)Subject;
						bool flag = false;
						if (scenario_0 != null)
						{
							if (waypoint.Category == Waypoint.WaypointCategory.PlottedCourse)
							{
								foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
								{
									if (activeUnits_ != null && activeUnits_.Navigator.HasPlottedCourse() && activeUnits_.Navigator.PlottedCourse.Contains(waypoint))
									{
										expressionClient = activeUnits_.Doctrine;
										break;
									}
								}
							}
							else
							{
								Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
								for (int i = 0; i < sides_ReadOnly.Length; i++)
								{
									foreach (Mission mission in sides_ReadOnly[i].Missions)
									{
										if (mission.TestValue())
										{
											foreach (Mission.Flight flight in mission.FlightList)
											{
												Waypoint[] flightPlan = flight.FlightPlan;
												Waypoint[] array2 = flightPlan;
												foreach (Waypoint waypoint2 in array2)
												{
													if (waypoint2 != waypoint)
													{
														if (waypoint2.Waypoint_LeadElementWingman == null)
														{
															if (waypoint2.Waypoint_SecondElement == null)
															{
																if (waypoint2.Waypoint_SecondElementWingman == null)
																{
																	if (waypoint2.Waypoint_ThirdElement == null)
																	{
																		if (waypoint2.Waypoint_ThirdElementWingman != null)
																		{
																			expressionClient = mission.Doctrine;
																			flag = true;
																			break;
																		}
																		continue;
																	}
																	expressionClient = mission.Doctrine;
																	flag = true;
																	break;
																}
																expressionClient = mission.Doctrine;
																flag = true;
																break;
															}
															expressionClient = mission.Doctrine;
															flag = true;
															break;
														}
														expressionClient = mission.Doctrine;
														flag = true;
														break;
													}
													expressionClient = mission.Doctrine;
													flag = true;
													break;
												}
												if (flag)
												{
													break;
												}
											}
										}
										if (flag)
										{
											break;
										}
									}
									if (flag)
									{
										break;
									}
								}
							}
						}
						if (expressionClient == null)
						{
							if (side_0 != null)
							{
								return side_0.Doctrine;
							}
							side_0 = scenario_0.GetCurrentSide();
							if (side_0 != null)
							{
								return side_0.Doctrine;
							}
						}
					}
					else if ((object)SubjectType == typeof(Side))
					{
						expressionClient = ((Side)Subject).Doctrine;
					}
					if (SelectedUnits != null && expressionClient == null)
					{
						if (side_0 != null)
						{
							return side_0.Doctrine;
						}
						side_0 = scenario_0.GetCurrentSide();
						if (side_0 != null)
						{
							return side_0.Doctrine;
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 101171", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (expressionClient == null)
			{
				_ = Debugger.IsAttached;
			}
			return expressionClient;
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 101001", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Doctrine doctrine = scenario_0.GetCurrentSide().Doctrine;
			ProjectData.ClearProjectError();
			return doctrine;
		}
	}

	public void ClearCachedParentDoctrine()
	{
		expressionClient = null;
	}

	internal List<ActiveUnit> LoginRepository(Scenario scenario_0, bool? nullable_0)
	{
		try
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			if ((object)SubjectType == typeof(Side))
			{
				list.AddRange(((Side)Subject).Units);
			}
			else
			{
				if ((object)SubjectType == typeof(Waypoint))
				{
					return new List<ActiveUnit>();
				}
				if (Subject.IsMission)
				{
					foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
					{
						if (activeUnits_ != null && activeUnits_.AssignedMissionOrPackage() == Subject)
						{
							if (!nullable_0.HasValue)
							{
								list.Add(activeUnits_);
							}
							bool? flag = nullable_0;
							if (flag.GetValueOrDefault(true) && activeUnits_.AI.IsEscort && flag.HasValue)
							{
								list.Add(activeUnits_);
							}
							flag = (!nullable_0) ?? nullable_0;
							if (flag.GetValueOrDefault(true) && !activeUnits_.AI.IsEscort && flag.HasValue)
							{
								list.Add(activeUnits_);
							}
						}
					}
				}
				else if (Subject.IsGroup)
				{
					list.AddRange(((Group)Subject).Units.Values);
				}
				else if (SelectedUnits != null && SelectedUnits.Count > 0)
				{
					list.AddRange(SelectedUnits);
				}
				else
				{
					list.Add((ActiveUnit)Subject);
				}
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101002", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<ActiveUnit> result = new List<ActiveUnit>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal bool GetRepository(Scenario scenario_0, object object_0, object object_1)
	{
		bool result = true;
		if (object_0 == object_1)
		{
			return false;
		}
		if (object_0 != null && object_0.Equals(RuntimeHelpers.GetObjectValue(object_1)))
		{
			return false;
		}
		return result;
	}

	internal StringBuilder WriteRepository(Doctrine doctrine_0, Scenario scenario_0, bool bool_0 = false)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Clear();
		bool bool_ = true;
		Doctrine parentDoctrine = GetParentDoctrine(scenario_0, ref bool_, bool_0);
		_UseNukesAllowed? adapterIssuer;
		_UseNukesAllowed? useNukesAllowed = (adapterIssuer = doctrine_0._AdapterIssuer);
		object object_ = (useNukesAllowed.HasValue ? adapterIssuer : parentDoctrine._AdapterIssuer);
		useNukesAllowed = (adapterIssuer = _AdapterIssuer);
		if (GetRepository(scenario_0, object_, useNukesAllowed.HasValue ? adapterIssuer : parentDoctrine._AdapterIssuer))
		{
			stringBuilder.Append(" NukeAllowed,");
		}
		_WCS? wCS;
		_WCS? wCS2 = (wCS = doctrine_0.codeIssuer);
		object object_12 = (wCS2.HasValue ? wCS : parentDoctrine.codeIssuer);
		wCS2 = (wCS = codeIssuer);
		if (GetRepository(scenario_0, object_12, wCS2.HasValue ? wCS : parentDoctrine.codeIssuer))
		{
			stringBuilder.Append(" WCS_Surface,");
		}
		wCS2 = (wCS = doctrine_0.m_ContextIssuer);
		object object_23 = (wCS2.HasValue ? wCS : parentDoctrine.m_ContextIssuer);
		wCS2 = (wCS = m_ContextIssuer);
		if (GetRepository(scenario_0, object_23, wCS2.HasValue ? wCS : parentDoctrine.m_ContextIssuer))
		{
			stringBuilder.Append(" WCS_Air,");
		}
		wCS2 = (wCS = doctrine_0.proccesorIssuer);
		object object_34 = (wCS2.HasValue ? wCS : parentDoctrine.proccesorIssuer);
		wCS2 = (wCS = proccesorIssuer);
		if (GetRepository(scenario_0, object_34, wCS2.HasValue ? wCS : parentDoctrine.proccesorIssuer))
		{
			stringBuilder.Append(" WCS_Submarine,");
		}
		wCS2 = (wCS = doctrine_0._ConfigurationIssuer);
		object object_42 = (wCS2.HasValue ? wCS : parentDoctrine._ConfigurationIssuer);
		wCS2 = (wCS = _ConfigurationIssuer);
		if (GetRepository(scenario_0, object_42, wCS2.HasValue ? wCS : parentDoctrine._ConfigurationIssuer))
		{
			stringBuilder.Append(" WCS_Land,");
		}
		_GunStrafeGroundTargets? gunStrafeGroundTargets;
		_GunStrafeGroundTargets? gunStrafeGroundTargets2 = (gunStrafeGroundTargets = doctrine_0.indexerIssuer);
		object object_43 = (gunStrafeGroundTargets2.HasValue ? gunStrafeGroundTargets : parentDoctrine.indexerIssuer);
		gunStrafeGroundTargets2 = (gunStrafeGroundTargets = indexerIssuer);
		if (GetRepository(scenario_0, object_43, gunStrafeGroundTargets2.HasValue ? gunStrafeGroundTargets : parentDoctrine.indexerIssuer))
		{
			stringBuilder.Append(" GunStrafing,");
		}
		_UseIgnorePlottedCourse? publisherIssuer;
		_UseIgnorePlottedCourse? useIgnorePlottedCourse = (publisherIssuer = doctrine_0.m_PublisherIssuer);
		object object_44 = (useIgnorePlottedCourse.HasValue ? publisherIssuer : parentDoctrine.m_PublisherIssuer);
		useIgnorePlottedCourse = (publisherIssuer = m_PublisherIssuer);
		if (GetRepository(scenario_0, object_44, useIgnorePlottedCourse.HasValue ? publisherIssuer : parentDoctrine.m_PublisherIssuer))
		{
			stringBuilder.Append(" IgnorePlottedCourse,");
		}
		_BehaviorTowardsTargetAmbiguity? prototypeIssuer;
		_BehaviorTowardsTargetAmbiguity? behaviorTowardsTargetAmbiguity = (prototypeIssuer = doctrine_0.m_PrototypeIssuer);
		object object_45 = (behaviorTowardsTargetAmbiguity.HasValue ? prototypeIssuer : parentDoctrine.m_PrototypeIssuer);
		behaviorTowardsTargetAmbiguity = (prototypeIssuer = m_PrototypeIssuer);
		if (GetRepository(scenario_0, object_45, behaviorTowardsTargetAmbiguity.HasValue ? prototypeIssuer : parentDoctrine.m_PrototypeIssuer))
		{
			stringBuilder.Append(" BehaviorTowardsAmbigousTarget,");
		}
		_UseAutoEvade? itemIssuer;
		_UseAutoEvade? useAutoEvade = (itemIssuer = doctrine_0._ItemIssuer);
		object object_46 = (useAutoEvade.HasValue ? itemIssuer : parentDoctrine._ItemIssuer);
		useAutoEvade = (itemIssuer = _ItemIssuer);
		if (GetRepository(scenario_0, object_46, useAutoEvade.HasValue ? itemIssuer : parentDoctrine._ItemIssuer))
		{
			stringBuilder.Append(" AutoEvade,");
		}
		_UseMaintainStandoff? useMaintainStandoff;
		_UseMaintainStandoff? useMaintainStandoff2 = (useMaintainStandoff = doctrine_0.creatorIssuer);
		object object_2 = (useMaintainStandoff2.HasValue ? useMaintainStandoff : parentDoctrine.creatorIssuer);
		useMaintainStandoff2 = (useMaintainStandoff = creatorIssuer);
		if (GetRepository(scenario_0, object_2, useMaintainStandoff2.HasValue ? useMaintainStandoff : parentDoctrine.creatorIssuer))
		{
			stringBuilder.Append(" MaintainStandoff,");
		}
		_NavigationMethod? mappingIssuer;
		_NavigationMethod? navigationMethod = (mappingIssuer = doctrine_0._MappingIssuer);
		object object_3 = (navigationMethod.HasValue ? mappingIssuer : parentDoctrine._MappingIssuer);
		navigationMethod = (mappingIssuer = _MappingIssuer);
		if (GetRepository(scenario_0, object_3, navigationMethod.HasValue ? mappingIssuer : parentDoctrine._MappingIssuer))
		{
			stringBuilder.Append(" SurfaceNavigation,");
		}
		navigationMethod = (mappingIssuer = doctrine_0._TagIssuer);
		object object_4 = (navigationMethod.HasValue ? mappingIssuer : parentDoctrine._TagIssuer);
		navigationMethod = (mappingIssuer = _TagIssuer);
		if (GetRepository(scenario_0, object_4, navigationMethod.HasValue ? mappingIssuer : parentDoctrine._TagIssuer))
		{
			stringBuilder.Append(" SubmarineNavigation,");
		}
		navigationMethod = (mappingIssuer = doctrine_0.m_QueueIssuer);
		object object_5 = (navigationMethod.HasValue ? mappingIssuer : parentDoctrine.m_QueueIssuer);
		navigationMethod = (mappingIssuer = m_QueueIssuer);
		if (GetRepository(scenario_0, object_5, navigationMethod.HasValue ? mappingIssuer : parentDoctrine.m_QueueIssuer))
		{
			stringBuilder.Append(" LandNavigation,");
		}
		_UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment;
		_UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment2 = (useUnderwayRefuelAndReplenishment = doctrine_0.paramIssuer);
		object object_6 = (useUnderwayRefuelAndReplenishment2.HasValue ? useUnderwayRefuelAndReplenishment : parentDoctrine.paramIssuer);
		useUnderwayRefuelAndReplenishment2 = (useUnderwayRefuelAndReplenishment = paramIssuer);
		if (GetRepository(scenario_0, object_6, useUnderwayRefuelAndReplenishment2.HasValue ? useUnderwayRefuelAndReplenishment : parentDoctrine.paramIssuer))
		{
			stringBuilder.Append(" UseReplenishment,");
		}
		_UnderwayRefuelAndReplenishmentSelection? underwayRefuelAndReplenishmentSelection;
		_UnderwayRefuelAndReplenishmentSelection? underwayRefuelAndReplenishmentSelection2 = (underwayRefuelAndReplenishmentSelection = doctrine_0.rulesIssuer);
		object object_7 = (underwayRefuelAndReplenishmentSelection2.HasValue ? underwayRefuelAndReplenishmentSelection : parentDoctrine.rulesIssuer);
		underwayRefuelAndReplenishmentSelection2 = (underwayRefuelAndReplenishmentSelection = rulesIssuer);
		if (GetRepository(scenario_0, object_7, underwayRefuelAndReplenishmentSelection2.HasValue ? underwayRefuelAndReplenishmentSelection : parentDoctrine.rulesIssuer))
		{
			stringBuilder.Append(" ReplenishmentSelection,");
		}
		_UseShootTourists? useShootTourists;
		_UseShootTourists? useShootTourists2 = (useShootTourists = doctrine_0.serviceIssuer);
		object object_8 = (useShootTourists2.HasValue ? useShootTourists : parentDoctrine.serviceIssuer);
		useShootTourists2 = (useShootTourists = serviceIssuer);
		if (GetRepository(scenario_0, object_8, useShootTourists2.HasValue ? useShootTourists : parentDoctrine.serviceIssuer))
		{
			stringBuilder.Append(" TargetOfOpportunity,");
		}
		_UseSAMsAgainstShips? useSAMsAgainstShips;
		_UseSAMsAgainstShips? useSAMsAgainstShips2 = (useSAMsAgainstShips = doctrine_0.candidateIssuer);
		object object_9 = (useSAMsAgainstShips2.HasValue ? useSAMsAgainstShips : parentDoctrine.candidateIssuer);
		useSAMsAgainstShips2 = (useSAMsAgainstShips = candidateIssuer);
		if (GetRepository(scenario_0, object_9, useSAMsAgainstShips2.HasValue ? useSAMsAgainstShips : parentDoctrine.candidateIssuer))
		{
			stringBuilder.Append(" UseSAMsOnASuW,");
		}
		_UseIgnoreEMCONunderAttack? identifierIssuer;
		_UseIgnoreEMCONunderAttack? useIgnoreEMCONunderAttack = (identifierIssuer = doctrine_0.m_IdentifierIssuer);
		object object_10 = (useIgnoreEMCONunderAttack.HasValue ? identifierIssuer : parentDoctrine.m_IdentifierIssuer);
		useIgnoreEMCONunderAttack = (identifierIssuer = m_IdentifierIssuer);
		if (GetRepository(scenario_0, object_10, useIgnoreEMCONunderAttack.HasValue ? identifierIssuer : parentDoctrine.m_IdentifierIssuer))
		{
			stringBuilder.Append(" IgnoreEMCONunderAttack,");
		}
		_QuickTurnAroundForAicraft? quickTurnAroundForAicraft;
		_QuickTurnAroundForAicraft? quickTurnAroundForAicraft2 = (quickTurnAroundForAicraft = doctrine_0.parserIssuer);
		object object_11 = (quickTurnAroundForAicraft2.HasValue ? quickTurnAroundForAicraft : parentDoctrine.parserIssuer);
		quickTurnAroundForAicraft2 = (quickTurnAroundForAicraft = parserIssuer);
		if (GetRepository(scenario_0, object_11, quickTurnAroundForAicraft2.HasValue ? quickTurnAroundForAicraft : parentDoctrine.parserIssuer))
		{
			stringBuilder.Append(" QuickTurnAround,");
		}
		_AirOpsTempo? databaseIssuer;
		_AirOpsTempo? airOpsTempo = (databaseIssuer = doctrine_0.m_DatabaseIssuer);
		object object_13 = (airOpsTempo.HasValue ? databaseIssuer : parentDoctrine.m_DatabaseIssuer);
		airOpsTempo = (databaseIssuer = m_DatabaseIssuer);
		if (GetRepository(scenario_0, object_13, airOpsTempo.HasValue ? databaseIssuer : parentDoctrine.m_DatabaseIssuer))
		{
			stringBuilder.Append(" AirOperationsTempo,");
		}
		_WeaponState? annotationIssuer;
		_WeaponState? weaponState = (annotationIssuer = doctrine_0._AnnotationIssuer);
		object object_14 = (weaponState.HasValue ? annotationIssuer : parentDoctrine._AnnotationIssuer);
		weaponState = (annotationIssuer = _AnnotationIssuer);
		if (GetRepository(scenario_0, object_14, weaponState.HasValue ? annotationIssuer : parentDoctrine._AnnotationIssuer))
		{
			stringBuilder.Append(" WinchesterShotgun,");
		}
		_WeaponStateRTB? utilsIssuer;
		_WeaponStateRTB? weaponStateRTB = (utilsIssuer = doctrine_0.m_UtilsIssuer);
		object object_15 = (weaponStateRTB.HasValue ? utilsIssuer : parentDoctrine.m_UtilsIssuer);
		weaponStateRTB = (utilsIssuer = m_UtilsIssuer);
		if (GetRepository(scenario_0, object_15, weaponStateRTB.HasValue ? utilsIssuer : parentDoctrine.m_UtilsIssuer))
		{
			stringBuilder.Append(" WinchesterShotgunRTB,");
		}
		_FuelState? messageIssuer;
		_FuelState? fuelState = (messageIssuer = doctrine_0.m_MessageIssuer);
		object object_16 = (fuelState.HasValue ? messageIssuer : parentDoctrine.m_MessageIssuer);
		fuelState = (messageIssuer = m_MessageIssuer);
		if (GetRepository(scenario_0, object_16, fuelState.HasValue ? messageIssuer : parentDoctrine.m_MessageIssuer))
		{
			stringBuilder.Append(" BingoJoker,");
		}
		_FuelStateRTB? singletonIssuer;
		_FuelStateRTB? fuelStateRTB = (singletonIssuer = doctrine_0.m_SingletonIssuer);
		object object_17 = (fuelStateRTB.HasValue ? singletonIssuer : parentDoctrine.m_SingletonIssuer);
		fuelStateRTB = (singletonIssuer = m_SingletonIssuer);
		if (GetRepository(scenario_0, object_17, fuelStateRTB.HasValue ? singletonIssuer : parentDoctrine.m_SingletonIssuer))
		{
			stringBuilder.Append(" BingoJokerRTB,");
		}
		_JettisonOrdnance? exceptionIssuer;
		_JettisonOrdnance? jettisonOrdnance = (exceptionIssuer = doctrine_0._ExceptionIssuer);
		object object_18 = (jettisonOrdnance.HasValue ? exceptionIssuer : parentDoctrine._ExceptionIssuer);
		jettisonOrdnance = (exceptionIssuer = _ExceptionIssuer);
		if (GetRepository(scenario_0, object_18, jettisonOrdnance.HasValue ? exceptionIssuer : parentDoctrine._ExceptionIssuer))
		{
			stringBuilder.Append(" Jettison,");
		}
		_BVRLogicEnum? bVRLogicEnum;
		_BVRLogicEnum? bVRLogicEnum2 = (bVRLogicEnum = doctrine_0.visitorIssuer);
		object object_19 = (bVRLogicEnum2.HasValue ? bVRLogicEnum : parentDoctrine.visitorIssuer);
		bVRLogicEnum2 = (bVRLogicEnum = visitorIssuer);
		if (GetRepository(scenario_0, object_19, bVRLogicEnum2.HasValue ? bVRLogicEnum : parentDoctrine.visitorIssuer))
		{
			stringBuilder.Append(" BVRLogic,");
		}
		_UseKinematicRangeForTorpedoes? initializerIssuer;
		_UseKinematicRangeForTorpedoes? useKinematicRangeForTorpedoes = (initializerIssuer = doctrine_0.m_InitializerIssuer);
		object object_20 = (useKinematicRangeForTorpedoes.HasValue ? initializerIssuer : parentDoctrine.m_InitializerIssuer);
		useKinematicRangeForTorpedoes = (initializerIssuer = m_InitializerIssuer);
		if (GetRepository(scenario_0, object_20, useKinematicRangeForTorpedoes.HasValue ? initializerIssuer : parentDoctrine.m_InitializerIssuer))
		{
			stringBuilder.Append(" UseTorpedoesKinematicRange,");
		}
		_RefuelAlliedUnits? refuelAlliedUnits;
		_RefuelAlliedUnits? refuelAlliedUnits2 = (refuelAlliedUnits = doctrine_0.factoryIssuer);
		object object_21 = (refuelAlliedUnits2.HasValue ? refuelAlliedUnits : parentDoctrine.factoryIssuer);
		refuelAlliedUnits2 = (refuelAlliedUnits = factoryIssuer);
		if (GetRepository(scenario_0, object_21, refuelAlliedUnits2.HasValue ? refuelAlliedUnits : parentDoctrine.factoryIssuer))
		{
			stringBuilder.Append(" RefuelAllies,");
		}
		_AvoidContactWhenPossible? workerIssuer;
		_AvoidContactWhenPossible? avoidContactWhenPossible = (workerIssuer = doctrine_0._WorkerIssuer);
		object object_22 = (avoidContactWhenPossible.HasValue ? workerIssuer : parentDoctrine._WorkerIssuer);
		avoidContactWhenPossible = (workerIssuer = _WorkerIssuer);
		if (GetRepository(scenario_0, object_22, avoidContactWhenPossible.HasValue ? workerIssuer : parentDoctrine._WorkerIssuer))
		{
			stringBuilder.Append(" AvoidContact,");
		}
		_DiveOnContact? diveOnContact;
		_DiveOnContact? diveOnContact2 = (diveOnContact = doctrine_0.stateIssuer);
		object object_24 = (diveOnContact2.HasValue ? diveOnContact : parentDoctrine.stateIssuer);
		diveOnContact2 = (diveOnContact = stateIssuer);
		if (GetRepository(scenario_0, object_24, diveOnContact2.HasValue ? diveOnContact : parentDoctrine.stateIssuer))
		{
			stringBuilder.Append(" DiveWhenThreatsDetected,");
		}
		_RechargeBatteryPercentage? rechargeBatteryPercentage;
		_RechargeBatteryPercentage? rechargeBatteryPercentage2 = (rechargeBatteryPercentage = doctrine_0.paramsIssuer);
		object object_25 = (rechargeBatteryPercentage2.HasValue ? rechargeBatteryPercentage : parentDoctrine.paramsIssuer);
		rechargeBatteryPercentage2 = (rechargeBatteryPercentage = paramsIssuer);
		if (GetRepository(scenario_0, object_25, rechargeBatteryPercentage2.HasValue ? rechargeBatteryPercentage : parentDoctrine.paramsIssuer))
		{
			stringBuilder.Append(" RechargePercentagePatrol,");
		}
		rechargeBatteryPercentage2 = (rechargeBatteryPercentage = doctrine_0.helperIssuer);
		object object_26 = (rechargeBatteryPercentage2.HasValue ? rechargeBatteryPercentage : parentDoctrine.helperIssuer);
		rechargeBatteryPercentage2 = (rechargeBatteryPercentage = helperIssuer);
		if (GetRepository(scenario_0, object_26, rechargeBatteryPercentage2.HasValue ? rechargeBatteryPercentage : parentDoctrine.helperIssuer))
		{
			stringBuilder.Append(" RechargePercentageAttack,");
		}
		_UseAIP? managerIssuer;
		_UseAIP? useAIP = (managerIssuer = doctrine_0._ManagerIssuer);
		object object_27 = (useAIP.HasValue ? managerIssuer : parentDoctrine._ManagerIssuer);
		useAIP = (managerIssuer = _ManagerIssuer);
		if (GetRepository(scenario_0, object_27, useAIP.HasValue ? managerIssuer : parentDoctrine._ManagerIssuer))
		{
			stringBuilder.Append(" AIPUsage,");
		}
		_UseDippingSonar? producerIssuer;
		_UseDippingSonar? useDippingSonar = (producerIssuer = doctrine_0.m_ProducerIssuer);
		object object_28 = (useDippingSonar.HasValue ? producerIssuer : parentDoctrine.m_ProducerIssuer);
		useDippingSonar = (producerIssuer = m_ProducerIssuer);
		if (GetRepository(scenario_0, object_28, useDippingSonar.HasValue ? producerIssuer : parentDoctrine.m_ProducerIssuer))
		{
			stringBuilder.Append(" DippingSonar,");
		}
		_DamageThreshold? damageThreshold;
		_DamageThreshold? damageThreshold2 = (damageThreshold = doctrine_0.structClient);
		object object_29 = (damageThreshold2.HasValue ? damageThreshold : parentDoctrine.structClient);
		damageThreshold2 = (damageThreshold = structClient);
		if (GetRepository(scenario_0, object_29, damageThreshold2.HasValue ? damageThreshold : parentDoctrine.structClient))
		{
			stringBuilder.Append(" WithdrawDamageThreshold,");
		}
		_FuelQuantityThreshold? merchantClient;
		_FuelQuantityThreshold? fuelQuantityThreshold = (merchantClient = doctrine_0.m_MerchantClient);
		object object_30 = (fuelQuantityThreshold.HasValue ? merchantClient : parentDoctrine.m_MerchantClient);
		fuelQuantityThreshold = (merchantClient = m_MerchantClient);
		if (GetRepository(scenario_0, object_30, fuelQuantityThreshold.HasValue ? merchantClient : parentDoctrine.m_MerchantClient))
		{
			stringBuilder.Append(" WithdrawFuelThreshold,");
		}
		_WeaponQuantityThreshold? weaponQuantityThreshold;
		_WeaponQuantityThreshold? weaponQuantityThreshold2 = (weaponQuantityThreshold = doctrine_0.callbackClient);
		object object_31 = (weaponQuantityThreshold2.HasValue ? weaponQuantityThreshold : parentDoctrine.callbackClient);
		weaponQuantityThreshold2 = (weaponQuantityThreshold = callbackClient);
		if (GetRepository(scenario_0, object_31, weaponQuantityThreshold2.HasValue ? weaponQuantityThreshold : parentDoctrine.callbackClient))
		{
			stringBuilder.Append(" WithdrawAttackThreshold,");
		}
		weaponQuantityThreshold2 = (weaponQuantityThreshold = doctrine_0._DecoratorClient);
		object object_32 = (weaponQuantityThreshold2.HasValue ? weaponQuantityThreshold : parentDoctrine._DecoratorClient);
		weaponQuantityThreshold2 = (weaponQuantityThreshold = _DecoratorClient);
		if (GetRepository(scenario_0, object_32, weaponQuantityThreshold2.HasValue ? weaponQuantityThreshold : parentDoctrine._DecoratorClient))
		{
			stringBuilder.Append(" WithdrawDefenceThreshold,");
		}
		damageThreshold2 = (damageThreshold = doctrine_0._ProcessClient);
		object object_33 = (damageThreshold2.HasValue ? damageThreshold : parentDoctrine._ProcessClient);
		damageThreshold2 = (damageThreshold = _ProcessClient);
		if (GetRepository(scenario_0, object_33, damageThreshold2.HasValue ? damageThreshold : parentDoctrine._ProcessClient))
		{
			stringBuilder.Append(" RedeployDamageThreshold,");
		}
		fuelQuantityThreshold = (merchantClient = doctrine_0.threadClient);
		object object_35 = (fuelQuantityThreshold.HasValue ? merchantClient : parentDoctrine.threadClient);
		fuelQuantityThreshold = (merchantClient = threadClient);
		if (GetRepository(scenario_0, object_35, fuelQuantityThreshold.HasValue ? merchantClient : parentDoctrine.threadClient))
		{
			stringBuilder.Append(" RedeployFuelThreshold,");
		}
		weaponQuantityThreshold2 = (weaponQuantityThreshold = doctrine_0._RuleClient);
		object object_36 = (weaponQuantityThreshold2.HasValue ? weaponQuantityThreshold : parentDoctrine._RuleClient);
		weaponQuantityThreshold2 = (weaponQuantityThreshold = _RuleClient);
		if (GetRepository(scenario_0, object_36, weaponQuantityThreshold2.HasValue ? weaponQuantityThreshold : parentDoctrine._RuleClient))
		{
			stringBuilder.Append(" RedeployAttackThreshold,");
		}
		weaponQuantityThreshold2 = (weaponQuantityThreshold = doctrine_0.m_CollectionClient);
		object object_37 = (weaponQuantityThreshold2.HasValue ? weaponQuantityThreshold : parentDoctrine.m_CollectionClient);
		weaponQuantityThreshold2 = (weaponQuantityThreshold = m_CollectionClient);
		if (GetRepository(scenario_0, object_37, weaponQuantityThreshold2.HasValue ? weaponQuantityThreshold : parentDoctrine.m_CollectionClient))
		{
			stringBuilder.Append(" RedeployDefenceThreshold,");
		}
		navigationMethod = (mappingIssuer = doctrine_0._MappingIssuer);
		object object_38 = (navigationMethod.HasValue ? mappingIssuer : parentDoctrine._MappingIssuer);
		navigationMethod = (mappingIssuer = _MappingIssuer);
		if (GetRepository(scenario_0, object_38, navigationMethod.HasValue ? mappingIssuer : parentDoctrine._MappingIssuer))
		{
			stringBuilder.Append("SurfaceNavigation,");
		}
		navigationMethod = (mappingIssuer = doctrine_0._TagIssuer);
		object object_39 = (navigationMethod.HasValue ? mappingIssuer : parentDoctrine._TagIssuer);
		navigationMethod = (mappingIssuer = _TagIssuer);
		if (GetRepository(scenario_0, object_39, navigationMethod.HasValue ? mappingIssuer : parentDoctrine._TagIssuer))
		{
			stringBuilder.Append("_SubmarineNavigation,");
		}
		navigationMethod = (mappingIssuer = doctrine_0.m_QueueIssuer);
		object object_40 = (navigationMethod.HasValue ? mappingIssuer : parentDoctrine.m_QueueIssuer);
		navigationMethod = (mappingIssuer = m_QueueIssuer);
		if (GetRepository(scenario_0, object_40, navigationMethod.HasValue ? mappingIssuer : parentDoctrine.m_QueueIssuer))
		{
			stringBuilder.Append("LandNavigation,");
		}
		_BingoThreshold_E? eventIssuer;
		_BingoThreshold_E? bingoThreshold_E = (eventIssuer = doctrine_0.m_EventIssuer);
		object object_41 = (bingoThreshold_E.HasValue ? eventIssuer : parentDoctrine.m_EventIssuer);
		bingoThreshold_E = (eventIssuer = m_EventIssuer);
		if (GetRepository(scenario_0, object_41, bingoThreshold_E.HasValue ? eventIssuer : parentDoctrine.m_EventIssuer))
		{
			stringBuilder.Append(" BingoThreshold,");
		}
		if ((refIssuer != null || doctrine_0.refIssuer != null) && refIssuer != null)
		{
			refIssuer.Equals(doctrine_0.refIssuer);
		}
		if (stringBuilder.Length > 0)
		{
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
		}
		return stringBuilder;
	}

	internal EMCONSettings NewRepository(Scenario scenario_0)
	{
		if (EMCON_Inherits)
		{
			bool bool_ = true;
			Doctrine parentDoctrine = GetParentDoctrine(scenario_0, ref bool_);
			if (!Information.IsNothing(parentDoctrine))
			{
				return parentDoctrine.NewRepository(scenario_0);
			}
		}
		return refIssuer;
	}

	public static int? WRA_WeaponQty_AnyTargetType(Doctrine doctrine_0, Scenario scenario_0, Weapon weapon_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0, bool bool_0, ref int? nullable_0, ref int? nullable_1)
	{
		if ((object)doctrine_0.SubjectType != typeof(Side) && weapon_0.DBID > 0)
		{
			if (bool_0)
			{
				bool bool_ = true;
				nullable_0 = WRA_WeaponQty_CurrentTargetType(doctrine_0.GetParentDoctrine(scenario_0, ref bool_), scenario_0, weapon_0, _WRA_WeaponTargetType_0);
			}
			else
			{
				nullable_0 = WRA_WeaponQty_CurrentTargetType(doctrine_0, scenario_0, weapon_0, _WRA_WeaponTargetType_0);
			}
			if (!nullable_0.HasValue && !WRA_IsTopNodeTargetType(ref _WRA_WeaponTargetType_0))
			{
				_WRA_WeaponTargetType wRA_WeaponTargetType_ = WRA_DetermineTargetType_Unspecified(ref _WRA_WeaponTargetType_0);
				nullable_1 = WRA_WeaponQty_CurrentTargetType(doctrine_0, scenario_0, weapon_0, wRA_WeaponTargetType_);
				return nullable_1;
			}
			int? num = nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -1) : null).GetValueOrDefault())
			{
				nullable_0 = WRA_WeaponQty_SystemDefault(weapon_0, _WRA_WeaponTargetType_0);
			}
			return nullable_0;
		}
		return null;
	}

	public static int? WRA_WeaponQty_CurrentTargetType(Doctrine doctrine_0, Scenario scenario_0, Weapon weapon_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		int? num = doctrine_0.PushRepository(weapon_0.DBID, _WRA_WeaponTargetType_0);
		if (!num.HasValue && (object)doctrine_0.SubjectType != typeof(Side))
		{
			bool bool_ = true;
			Doctrine parentDoctrine = doctrine_0.GetParentDoctrine(scenario_0, ref bool_);
			if (parentDoctrine != null)
			{
				num = WRA_WeaponQty_CurrentTargetType(parentDoctrine, scenario_0, weapon_0, _WRA_WeaponTargetType_0);
			}
		}
		return num ?? WRA_WeaponQty_SystemDefault(weapon_0, _WRA_WeaponTargetType_0);
	}

	public static int? WRA_WeaponQty_SystemDefault(Weapon weapon_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		if (_WRA_WeaponTargetType_0 == _WRA_WeaponTargetType.Decoy)
		{
			return 0;
		}
		ulong key = (ulong)Math.BigMul(weapon_0.DBID * 397, (int)_WRA_WeaponTargetType_0);
		if (weapon_0.ParentScen.Cache_WRA_FiringDoctrineEntry_SystemDefault.TryGetValue(key, out var value))
		{
			return value.WeaponQty;
		}
		Dictionary<int, WRA_Weapon> wRA = weapon_0.Doctrine.WRA;
		if (wRA != null)
		{
			Dictionary<int, WRA_Weapon>.Enumerator enumerator = wRA.GetEnumerator();
			while (enumerator.MoveNext())
			{
				WRA_FiringDoctrineEntry[] wRA_WeaponTargets = enumerator.Current.Value.WRA_WeaponTargets;
				int num = wRA_WeaponTargets.Length - 1;
				for (int i = 0; i <= num; i++)
				{
					WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry = wRA_WeaponTargets[i];
					if (_WRA_WeaponTargetType_0 != wRA_FiringDoctrineEntry.TargetType)
					{
						continue;
					}
					value = wRA_FiringDoctrineEntry;
					if (!weapon_0.ParentScen.Cache_WRA_FiringDoctrineEntry_SystemDefault.ContainsKey(key))
					{
						try
						{
							weapon_0.ParentScen.Cache_WRA_FiringDoctrineEntry_SystemDefault.TryAdd(key, value);
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
					return value.WeaponQty;
				}
			}
		}
		int? result = null;
		if (_WRA_WeaponTargetType_0 == _WRA_WeaponTargetType.Helicopter_Unspecified)
		{
			result = WRA_WeaponQty_SystemDefault(weapon_0, _WRA_WeaponTargetType.Aircraft_Unspecified);
		}
		if (_WRA_WeaponTargetType_0 == _WRA_WeaponTargetType.Aircraft_Unspecified)
		{
			result = WRA_WeaponQty_SystemDefault(weapon_0, _WRA_WeaponTargetType.Air_Contact_Unknown_Type);
		}
		return result;
	}

	[SpecialName]
	public int? GetWRA_WeaponQty_Inherits(int int_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		return PushRepository(int_0, _WRA_WeaponTargetType_0);
	}

	[SpecialName]
	public void SetWRA_WeaponQty_Inherits(int int_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0, int? nullable_0)
	{
		if (nullable_0.HasValue)
		{
			m_ErrorIssuer = new Dictionary<int, WRA_Weapon>();
		}
		else
		{
			m_ErrorIssuer = null;
		}
	}

	private int? PushRepository(int int_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		int? result;
		if (m_ErrorIssuer == null)
		{
			result = null;
		}
		else
		{
			m_ErrorIssuer.TryGetValue(int_0, out var value);
			if (value != null)
			{
				int num = value.WRA_WeaponTargets.Count() - 1;
				for (int i = 0; i <= num; i++)
				{
					WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry = value.WRA_WeaponTargets[i];
					if (wRA_FiringDoctrineEntry.TargetType == _WRA_WeaponTargetType_0)
					{
						return wRA_FiringDoctrineEntry.WeaponQty;
					}
				}
			}
			result = null;
		}
		return result;
	}

	public static int? WRA_ShooterQty_AnyTargetType(Doctrine doctrine_0, Scenario scenario_0, Weapon weapon_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0, bool bool_0, ref int? nullable_0, ref int? nullable_1)
	{
		if ((object)doctrine_0.SubjectType != typeof(Side) && weapon_0.DBID > 0)
		{
			if (bool_0)
			{
				bool bool_ = true;
				nullable_0 = WRA_ShooterQty_CurrentTargetType(doctrine_0.GetParentDoctrine(scenario_0, ref bool_), scenario_0, weapon_0, _WRA_WeaponTargetType_0);
			}
			else
			{
				nullable_0 = WRA_ShooterQty_CurrentTargetType(doctrine_0, scenario_0, weapon_0, _WRA_WeaponTargetType_0);
			}
			if (Information.IsNothing(nullable_0) && !WRA_IsTopNodeTargetType(ref _WRA_WeaponTargetType_0))
			{
				_WRA_WeaponTargetType wRA_WeaponTargetType_ = WRA_DetermineTargetType_Unspecified(ref _WRA_WeaponTargetType_0);
				nullable_1 = WRA_ShooterQty_CurrentTargetType(doctrine_0, scenario_0, weapon_0, wRA_WeaponTargetType_);
				return nullable_1;
			}
			int? num = nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -1) : null).GetValueOrDefault())
			{
				nullable_0 = WRA_ShooterQty_SystemDefault(weapon_0, _WRA_WeaponTargetType_0);
			}
			return nullable_0;
		}
		return null;
	}

	public static int? WRA_ShooterQty_CurrentTargetType(Doctrine doctrine_0, Scenario scenario_0, Weapon weapon_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		int? num = doctrine_0.InvokeRepository(weapon_0.DBID, _WRA_WeaponTargetType_0);
		if (!num.HasValue && (object)doctrine_0.SubjectType != typeof(Side))
		{
			bool bool_ = true;
			Doctrine parentDoctrine = doctrine_0.GetParentDoctrine(scenario_0, ref bool_);
			if (!Information.IsNothing(parentDoctrine))
			{
				num = WRA_ShooterQty_CurrentTargetType(parentDoctrine, scenario_0, weapon_0, _WRA_WeaponTargetType_0);
			}
		}
		return num ?? WRA_ShooterQty_SystemDefault(weapon_0, _WRA_WeaponTargetType_0);
	}

	public static int? WRA_ShooterQty_SystemDefault(Weapon weapon_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		if (_WRA_WeaponTargetType_0 == _WRA_WeaponTargetType.Decoy)
		{
			return -101;
		}
		ulong key = (ulong)Math.BigMul(weapon_0.DBID * 397, (int)_WRA_WeaponTargetType_0);
		if (weapon_0.ParentScen.Cache_WRA_FiringDoctrineEntry_SystemDefault.TryGetValue(key, out var value))
		{
			return value.ShooterQty;
		}
		Dictionary<int, WRA_Weapon> wRA = weapon_0.Doctrine.WRA;
		if (wRA != null)
		{
			foreach (KeyValuePair<int, WRA_Weapon> item in wRA)
			{
				WRA_FiringDoctrineEntry[] wRA_WeaponTargets = item.Value.WRA_WeaponTargets;
				WRA_FiringDoctrineEntry[] array = wRA_WeaponTargets;
				foreach (WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry in array)
				{
					if (_WRA_WeaponTargetType_0 != wRA_FiringDoctrineEntry.TargetType)
					{
						continue;
					}
					value = wRA_FiringDoctrineEntry;
					if (!weapon_0.ParentScen.Cache_WRA_FiringDoctrineEntry_SystemDefault.ContainsKey(key))
					{
						try
						{
							weapon_0.ParentScen.Cache_WRA_FiringDoctrineEntry_SystemDefault.TryAdd(key, value);
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
					return value.ShooterQty;
				}
			}
		}
		return (_WRA_WeaponTargetType_0 == _WRA_WeaponTargetType.Helicopter_Unspecified) ? WRA_ShooterQty_SystemDefault(weapon_0, _WRA_WeaponTargetType.Aircraft_Unspecified) : null;
	}

	[SpecialName]
	public int? GetWRA_ShooterQty_Inherits(int int_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		return InvokeRepository(int_0, _WRA_WeaponTargetType_0);
	}

	[SpecialName]
	public void SetWRA_ShooterQty_Inherits(int int_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0, int? nullable_0)
	{
		if (nullable_0.HasValue)
		{
			m_ErrorIssuer = new Dictionary<int, WRA_Weapon>();
		}
		else
		{
			m_ErrorIssuer = null;
		}
	}

	private int? InvokeRepository(int int_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		int? result;
		if (m_ErrorIssuer == null)
		{
			result = null;
		}
		else
		{
			m_ErrorIssuer.TryGetValue(int_0, out var value);
			if (value != null)
			{
				int num = value.WRA_WeaponTargets.Count() - 1;
				for (int i = 0; i <= num; i++)
				{
					WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry = value.WRA_WeaponTargets[i];
					if (wRA_FiringDoctrineEntry.TargetType == _WRA_WeaponTargetType_0)
					{
						return wRA_FiringDoctrineEntry.ShooterQty;
					}
				}
			}
			result = null;
		}
		return result;
	}

	internal float? SetupRepository(Doctrine doctrine_0, Scenario scenario_0, Weapon weapon_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0, bool bool_0, ref float? nullable_0, ref float? nullable_1)
	{
		if ((object)doctrine_0.SubjectType != typeof(Side) && weapon_0.DBID > 0)
		{
			if (bool_0)
			{
				bool bool_ = true;
				nullable_0 = WRA_SelfDefenceRange_CurrentTargetType(doctrine_0.GetParentDoctrine(scenario_0, ref bool_), scenario_0, weapon_0, _WRA_WeaponTargetType_0);
			}
			else
			{
				nullable_0 = WRA_SelfDefenceRange_CurrentTargetType(doctrine_0, scenario_0, weapon_0, _WRA_WeaponTargetType_0);
			}
			if (Information.IsNothing(nullable_0) && !WRA_IsTopNodeTargetType(ref _WRA_WeaponTargetType_0))
			{
				_WRA_WeaponTargetType wRA_WeaponTargetType_ = WRA_DetermineTargetType_Unspecified(ref _WRA_WeaponTargetType_0);
				nullable_1 = WRA_SelfDefenceRange_CurrentTargetType(doctrine_0, scenario_0, weapon_0, wRA_WeaponTargetType_);
				return nullable_1;
			}
			float? num = nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -1f) : null).GetValueOrDefault())
			{
				nullable_0 = WRA_SelfDefenceRange_SystemDefault(weapon_0, _WRA_WeaponTargetType_0);
			}
			return nullable_0;
		}
		return null;
	}

	public static float? WRA_SelfDefenceRange_CurrentTargetType(Doctrine doctrine_0, Scenario scenario_0, Weapon weapon_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		float? num = doctrine_0.ExcludeRepository(weapon_0.DBID, _WRA_WeaponTargetType_0);
		if (!num.HasValue && (object)doctrine_0.SubjectType != typeof(Side))
		{
			bool bool_ = true;
			Doctrine parentDoctrine = doctrine_0.GetParentDoctrine(scenario_0, ref bool_);
			if (parentDoctrine != null)
			{
				num = WRA_SelfDefenceRange_CurrentTargetType(parentDoctrine, scenario_0, weapon_0, _WRA_WeaponTargetType_0);
			}
		}
		return num ?? WRA_SelfDefenceRange_SystemDefault(weapon_0, _WRA_WeaponTargetType_0);
	}

	public static float? WRA_SelfDefenceRange_SystemDefault(Weapon weapon_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		if (_WRA_WeaponTargetType_0 == _WRA_WeaponTargetType.Decoy)
		{
			return 0f;
		}
		ulong key = (ulong)Math.BigMul(weapon_0.DBID * 397, (int)_WRA_WeaponTargetType_0);
		if (weapon_0.ParentScen.Cache_WRA_FiringDoctrineEntry_SystemDefault.TryGetValue(key, out var value))
		{
			return value.SelfDefenceRange;
		}
		Dictionary<int, WRA_Weapon> wRA = weapon_0.Doctrine.WRA;
		if (wRA != null)
		{
			foreach (KeyValuePair<int, WRA_Weapon> item in wRA)
			{
				WRA_FiringDoctrineEntry[] wRA_WeaponTargets = item.Value.WRA_WeaponTargets;
				WRA_FiringDoctrineEntry[] array = wRA_WeaponTargets;
				foreach (WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry in array)
				{
					if (_WRA_WeaponTargetType_0 != wRA_FiringDoctrineEntry.TargetType)
					{
						continue;
					}
					value = wRA_FiringDoctrineEntry;
					if (!weapon_0.ParentScen.Cache_WRA_FiringDoctrineEntry_SystemDefault.ContainsKey(key))
					{
						try
						{
							weapon_0.ParentScen.Cache_WRA_FiringDoctrineEntry_SystemDefault.TryAdd(key, value);
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
					return value.SelfDefenceRange;
				}
			}
		}
		return (_WRA_WeaponTargetType_0 == _WRA_WeaponTargetType.Helicopter_Unspecified) ? WRA_SelfDefenceRange_SystemDefault(weapon_0, _WRA_WeaponTargetType.Aircraft_Unspecified) : null;
	}

	[SpecialName]
	public float? GetWRA_SelfDefenceRange_Inherits(int int_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		return ExcludeRepository(int_0, _WRA_WeaponTargetType_0);
	}

	[SpecialName]
	public void SetWRA_SelfDefenceRange_Inherits(int int_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0, float? nullable_0)
	{
		if (nullable_0.HasValue)
		{
			m_ErrorIssuer = new Dictionary<int, WRA_Weapon>();
		}
		else
		{
			m_ErrorIssuer = null;
		}
	}

	private float? ExcludeRepository(int int_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		float? result;
		if (m_ErrorIssuer == null)
		{
			result = null;
		}
		else
		{
			m_ErrorIssuer.TryGetValue(int_0, out var value);
			if (value != null)
			{
				int num = value.WRA_WeaponTargets.Count() - 1;
				for (int i = 0; i <= num; i++)
				{
					WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry = value.WRA_WeaponTargets[i];
					if (wRA_FiringDoctrineEntry.TargetType == _WRA_WeaponTargetType_0)
					{
						return wRA_FiringDoctrineEntry.SelfDefenceRange;
					}
				}
			}
			result = null;
		}
		return result;
	}

	internal float? IncludeRepository(Doctrine doctrine_0, Scenario scenario_0, int int_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0, bool bool_0, ref float? nullable_0, ref float? nullable_1)
	{
		if ((object)doctrine_0.SubjectType != typeof(Side) && int_0 > 0)
		{
			if (bool_0)
			{
				bool bool_ = true;
				nullable_0 = SearchRepository(doctrine_0.GetParentDoctrine(scenario_0, ref bool_), scenario_0, int_0, _WRA_WeaponTargetType_0);
			}
			else
			{
				nullable_0 = SearchRepository(doctrine_0, scenario_0, int_0, _WRA_WeaponTargetType_0);
			}
			float? num;
			bool? flag;
			if (Information.IsNothing(nullable_0) && !WRA_IsTopNodeTargetType(ref _WRA_WeaponTargetType_0))
			{
				_WRA_WeaponTargetType wRA_WeaponTargetType_ = WRA_DetermineTargetType_Unspecified(ref _WRA_WeaponTargetType_0);
				nullable_1 = SearchRepository(doctrine_0, scenario_0, int_0, wRA_WeaponTargetType_);
				num = nullable_1;
				flag = (num.HasValue ? new bool?(num.GetValueOrDefault() == -102f) : null);
				if ((IsNEZValidTarget(_WRA_WeaponTargetType_0) ? new bool?(false) : flag).GetValueOrDefault())
				{
					nullable_1 = WRA_FiringRange_GetDefaultFiringRange(scenario_0, int_0, _WRA_WeaponTargetType_0);
				}
				return nullable_1;
			}
			num = nullable_0;
			flag = (num.HasValue ? new bool?(num.GetValueOrDefault() == -102f) : null);
			if ((IsNEZValidTarget(_WRA_WeaponTargetType_0) ? new bool?(false) : flag).GetValueOrDefault())
			{
				nullable_1 = WRA_FiringRange_GetDefaultFiringRange(scenario_0, int_0, _WRA_WeaponTargetType_0);
			}
			return nullable_0;
		}
		if (!nullable_0.HasValue)
		{
			nullable_1 = WRA_FiringRange_GetDefaultFiringRange(scenario_0, int_0, _WRA_WeaponTargetType_0);
		}
		return nullable_0;
	}

	public static float? WRA_FiringRange_GetDefaultFiringRange(Scenario scenario_0, int int_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		if (scenario_0.DefaultGuidedWeaponsVsAirTargetWRASetting != -101 && smethod_0(_WRA_WeaponTargetType_0) && DBFunctions.GetWeaponType(int_0, scenario_0) == Weapon._WeaponType.GuidedWeapon)
		{
			return scenario_0.DefaultGuidedWeaponsVsAirTargetWRASetting;
		}
		return -99f;
	}

	internal float? SearchRepository(Doctrine doctrine_0, Scenario scenario_0, int int_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		float? result = EnableRepository(doctrine_0, int_0, _WRA_WeaponTargetType_0);
		if (!result.HasValue && (object)doctrine_0.SubjectType != typeof(Side))
		{
			bool bool_ = true;
			Doctrine parentDoctrine = doctrine_0.GetParentDoctrine(scenario_0, ref bool_);
			if (parentDoctrine != null)
			{
				result = SearchRepository(parentDoctrine, scenario_0, int_0, _WRA_WeaponTargetType_0);
			}
		}
		return result;
	}

	[SpecialName]
	public float? GetWRA_FiringRange_Inherits(int int_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		return EnableRepository(this, int_0, _WRA_WeaponTargetType_0);
	}

	[SpecialName]
	public void SetWRA_FiringRange_Inherits(int int_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0, float? nullable_0)
	{
		if (nullable_0.HasValue)
		{
			m_ErrorIssuer = new Dictionary<int, WRA_Weapon>();
		}
		else
		{
			m_ErrorIssuer = null;
		}
	}

	private static float? EnableRepository(Doctrine doctrine_0, int int_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		float? result;
		WRA_Weapon value;
		if (doctrine_0.m_ErrorIssuer == null)
		{
			result = null;
		}
		else if (doctrine_0.m_ErrorIssuer.TryGetValue(int_0, out value))
		{
			if (value != null)
			{
				WRA_FiringDoctrineEntry[] wRA_WeaponTargets = value.WRA_WeaponTargets;
				WRA_FiringDoctrineEntry[] array = wRA_WeaponTargets;
				foreach (WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry in array)
				{
					if (wRA_FiringDoctrineEntry.TargetType == _WRA_WeaponTargetType_0)
					{
						return wRA_FiringDoctrineEntry.FiringRange;
					}
				}
			}
			result = null;
		}
		else
		{
			result = null;
		}
		return result;
	}

	public static _WRA_WeaponTargetType WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref Weapon weapon_0, ref Contact contact_0, ref _WRA_WeaponTargetType _WRA_WeaponTargetType_0, string string_0)
	{
		ActiveUnit actualUnit = contact_0.ActualUnit;
		if (actualUnit != null && actualUnit.GetisTaggedAsDecoyByThisSide(string_0))
		{
			return _WRA_WeaponTargetType.Decoy;
		}
		if (weapon_0.ValidTargets.Radar && _WRA_WeaponTargetType_0 == _WRA_WeaponTargetType.Radar_Unspecified)
		{
			return _WRA_WeaponTargetType.Radar_Unspecified;
		}
		if (weapon_0.ValidTargets.Submarine && _WRA_WeaponTargetType_0 == _WRA_WeaponTargetType.Submarine_Surfaced)
		{
			return _WRA_WeaponTargetType.Submarine_Unspecified;
		}
		if (weapon_0.ValidTargets.Torpedo && contact_0.Type == Contact_Base.ContactType.Torpedo)
		{
			return _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type;
		}
		if (contact_0.Type == Contact_Base.ContactType.Decoy_Air)
		{
			if (contact_0.DetectedEmissions.Count > 0)
			{
				foreach (KeyValuePair<int, EmissionContainer> detectedEmission in contact_0.DetectedEmissions)
				{
					if (detectedEmission.Value.GetAssociatedSensor(detectedEmission.Key, weapon_0.ParentScen).IsOECM)
					{
						return _WRA_WeaponTargetType.Aircraft_Unspecified;
					}
				}
			}
			return _WRA_WeaponTargetType.Decoy;
		}
		if (contact_0.Type != Contact_Base.ContactType.Decoy_Land && contact_0.Type != Contact_Base.ContactType.Decoy_Surface && contact_0.Type != Contact_Base.ContactType.Decoy_Sub)
		{
			return _WRA_WeaponTargetType_0;
		}
		return _WRA_WeaponTargetType.Decoy;
	}

	public static _WRA_WeaponTargetType WRA_DetermineTargetType(ref ActiveUnit activeUnit_0, Weapon weapon_0, ref bool? nullable_0)
	{
		Contact contact_ = new Contact(activeUnit_0, 0, bool_0: true);
		contact_.IDStatusBypassIdentification = Contact_Base.IdentificationStatus.PreciseID;
		return WRA_DetermineTargetType(ref contact_, weapon_0, ref nullable_0);
	}

	public static _WRA_WeaponTargetType WRA_DetermineTargetType(ref Contact contact_0, Weapon weapon_0, ref bool? nullable_0)
	{
		Contact_Base.IdentificationStatus iDStatus = contact_0.IDStatus;
		if (iDStatus != 0)
		{
			_WRA_WeaponTargetType wRA_WeaponTargetType = ((iDStatus != Contact_Base.IdentificationStatus.KnownDomain) ? InitRepository(contact_0) : ChangeRepository(contact_0));
			if (nullable_0.HasValue && !nullable_0.GetValueOrDefault())
			{
				nullable_0 = false;
				return wRA_WeaponTargetType;
			}
			if (weapon_0 != null && weapon_0.ValidTargets != null && !weapon_0.ValidTargets.Radar)
			{
				nullable_0 = false;
				return wRA_WeaponTargetType;
			}
			_WRA_WeaponTargetType num = contact_0.FillImporter(wRA_WeaponTargetType);
			if (num == _WRA_WeaponTargetType.Radar_Unspecified)
			{
				nullable_0 = true;
				return num;
			}
			nullable_0 = false;
			return num;
		}
		return _WRA_WeaponTargetType.None;
	}

	private static _WRA_WeaponTargetType ChangeRepository(object object_0)
	{
		if (((Contact)object_0).IDStatus >= Contact_Base.IdentificationStatus.KnownDomain)
		{
			if (((Contact)object_0).ActualUnit == null)
			{
				return _WRA_WeaponTargetType.None;
			}
			ActiveUnit actualUnit = ((Contact)object_0).ActualUnit;
			switch (((Contact_Base)object_0).Type)
			{
			case Contact_Base.ContactType.Air:
				return _WRA_WeaponTargetType.Air_Contact_Unknown_Type;
			case Contact_Base.ContactType.Missile:
				if (actualUnit.IsBallisticMissile)
				{
					return _WRA_WeaponTargetType.Guided_Weapon_Ballistic;
				}
				if (actualUnit.IsWeapon && ((Weapon)actualUnit).IsReEntryVehicle)
				{
					return _WRA_WeaponTargetType.Guided_Weapon_Ballistic;
				}
				if (((Contact)object_0).SpeedIsKnown)
				{
					if (((Module_Unit.Unit)object_0).CurrentSpeed <= 600f)
					{
						if (((Contact)object_0).AltitudeIsKnown && ((Module_Unit.Unit)object_0).GetCurrentAltitude() <= 30.48f)
						{
							return _WRA_WeaponTargetType.Guided_Weapon_Subsonic_Sea_Skimming;
						}
						return _WRA_WeaponTargetType.Guided_Weapon_Subsonic;
					}
					if (((Contact)object_0).AltitudeIsKnown && ((Module_Unit.Unit)object_0).GetCurrentAltitude() <= 30.48f)
					{
						return _WRA_WeaponTargetType.Guided_Weapon_Supersonic_Sea_Skimming;
					}
					return _WRA_WeaponTargetType.Guided_Weapon_Supersonic;
				}
				return _WRA_WeaponTargetType.Guided_Weapon_Unspecified;
			case Contact_Base.ContactType.Surface:
				return _WRA_WeaponTargetType.Surface_Contact_Unknown_Type;
			case Contact_Base.ContactType.Submarine:
				if (((Submarine)actualUnit).IsSurfaced)
				{
					return _WRA_WeaponTargetType.Surface_Contact_Unknown_Type;
				}
				return _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type;
			case Contact_Base.ContactType.Orbital:
				return _WRA_WeaponTargetType.Satellite_Unspecified;
			case Contact_Base.ContactType.Facility_Fixed:
			case Contact_Base.ContactType.Facility_Mobile:
				return _WRA_WeaponTargetType.Land_Contact_Unknown_Type;
			case Contact_Base.ContactType.Torpedo:
				return _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type;
			default:
				throw new NotImplementedException();
			case Contact_Base.ContactType.Decoy_Air:
			case Contact_Base.ContactType.Decoy_Surface:
			case Contact_Base.ContactType.Decoy_Land:
			case Contact_Base.ContactType.Decoy_Sub:
				return _WRA_WeaponTargetType.Decoy;
			case Contact_Base.ContactType.Sonobuoy:
				return _WRA_WeaponTargetType.None;
			}
		}
		return (_WRA_WeaponTargetType)0;
	}

	private static _WRA_WeaponTargetType InitRepository(object object_0)
	{
		if (((Contact)object_0).IDStatus >= Contact_Base.IdentificationStatus.KnownType)
		{
			if (((Contact)object_0).ActualUnit == null)
			{
				return _WRA_WeaponTargetType.None;
			}
			ActiveUnit actualUnit = ((Contact)object_0).ActualUnit;
			switch (((Contact_Base)object_0).Type)
			{
			case Contact_Base.ContactType.Air:
			{
				if (actualUnit.IsWeapon)
				{
					return _WRA_WeaponTargetType.Aircraft_Unspecified;
				}
				Aircraft aircraft = (Aircraft)actualUnit;
				if (aircraft.IsHelicopter && aircraft.Type != Aircraft._AircraftType.UAV && aircraft.Type != Aircraft._AircraftType.UCAV)
				{
					return _WRA_WeaponTargetType.Helicopter_Unspecified;
				}
				switch (aircraft.Type)
				{
				case Aircraft._AircraftType.Fighter:
				case Aircraft._AircraftType.Multirole:
				case Aircraft._AircraftType.Attack:
				case Aircraft._AircraftType.WildWeasel:
				case Aircraft._AircraftType.CAS:
					if ((double)aircraft.Agility_Nominal < 5.0)
					{
						if ((double)aircraft.Agility_Nominal < 4.0)
						{
							if ((double)aircraft.Agility_Nominal < 3.0)
							{
								if (!((double)aircraft.Agility_Nominal < 2.0))
								{
									return _WRA_WeaponTargetType.Aircraft_Less_Capable;
								}
								break;
							}
							return _WRA_WeaponTargetType.Aircraft_3rd_Generation;
						}
						return _WRA_WeaponTargetType.Aircraft_4th_Generation;
					}
					return _WRA_WeaponTargetType.Aircraft_5th_Generation;
				case Aircraft._AircraftType.Bomber:
					if ((double)aircraft.Agility_Nominal < 2.0)
					{
						if ((double)aircraft.Agility_Nominal < 1.5)
						{
							if (!((double)aircraft.Agility_Nominal < 1.0))
							{
								return _WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers;
							}
							break;
						}
						return _WRA_WeaponTargetType.Aircraft_Medium_Perf_Bombers;
					}
					return _WRA_WeaponTargetType.Aircraft_High_Perf_Bombers;
				case Aircraft._AircraftType.AEW:
				case Aircraft._AircraftType.AirborneCP:
					return _WRA_WeaponTargetType.Aircraft_AEW;
				default:
					return _WRA_WeaponTargetType.Aircraft_Unspecified;
				case Aircraft._AircraftType.UAV:
				case Aircraft._AircraftType.UCAV:
					if (aircraft.GetFacade() == Aircraft.NATO_UAS_ClassificationEnum.Class1_Micro)
					{
						return _WRA_WeaponTargetType.Aircraft_MicroUAV;
					}
					return _WRA_WeaponTargetType.Aircraft_Unspecified;
				case Aircraft._AircraftType.Tanker:
					return _WRA_WeaponTargetType.Aircraft_Tanker;
				case Aircraft._AircraftType.OECM:
				case Aircraft._AircraftType.MPA:
				case Aircraft._AircraftType.ForwardObserver:
				case Aircraft._AircraftType.AreaSurveillance:
				case Aircraft._AircraftType.Recon:
				case Aircraft._AircraftType.ELINT:
				case Aircraft._AircraftType.SIGINT:
				{
					float agility_Nominal = aircraft.Agility_Nominal;
					if (agility_Nominal < 4f)
					{
						if (agility_Nominal < 3f)
						{
							return _WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW;
						}
						return _WRA_WeaponTargetType.Aircraft_Medium_Perf_Recon_EW;
					}
					return _WRA_WeaponTargetType.Aircraft_High_Perf_Recon_EW;
				}
				}
				break;
			}
			case Contact_Base.ContactType.Missile:
			{
				Weapon weapon = (Weapon)actualUnit;
				if (weapon.IsBallisticMissile)
				{
					return _WRA_WeaponTargetType.Guided_Weapon_Ballistic;
				}
				if ((object)weapon.GetType() == typeof(UnguidedRocket))
				{
					return _WRA_WeaponTargetType.C_RAM;
				}
				if (((Contact)object_0).SpeedIsKnown)
				{
					if (((Module_Unit.Unit)object_0).CurrentSpeed <= 600f)
					{
						if (((Contact)object_0).AltitudeIsKnown && ((Module_Unit.Unit)object_0).GetCurrentAltitude() <= 30.48f)
						{
							return _WRA_WeaponTargetType.Guided_Weapon_Subsonic_Sea_Skimming;
						}
						return _WRA_WeaponTargetType.Guided_Weapon_Subsonic;
					}
					if (((Contact)object_0).AltitudeIsKnown && ((Module_Unit.Unit)object_0).GetCurrentAltitude() <= 30.48f)
					{
						return _WRA_WeaponTargetType.Guided_Weapon_Supersonic_Sea_Skimming;
					}
					return _WRA_WeaponTargetType.Guided_Weapon_Supersonic;
				}
				return _WRA_WeaponTargetType.Guided_Weapon_Unspecified;
			}
			case Contact_Base.ContactType.Surface:
			{
				Ship ship = (Ship)actualUnit;
				switch (ship.Category)
				{
				default:
					return _WRA_WeaponTargetType.Ship_Unspecified;
				case Ship._ShipCategory.Amphibious:
					if (ship.Displacement_Standard < 95001f)
					{
						if (ship.Displacement_Standard < 45001f)
						{
							if (ship.Displacement_Standard < 25001f)
							{
								if (ship.Displacement_Standard < 10001f)
								{
									if (ship.Displacement_Standard < 5001f)
									{
										if (ship.Displacement_Standard < 1501f)
										{
											if (ship.Displacement_Standard < 501f)
											{
												if (!(ship.Displacement_Standard < 0f))
												{
													return _WRA_WeaponTargetType.Ship_Amphibious_0_500_tons;
												}
												break;
											}
											return _WRA_WeaponTargetType.Ship_Amphibious_501_1500_tons;
										}
										return _WRA_WeaponTargetType.Ship_Amphibious_1501_5000_tons;
									}
									return _WRA_WeaponTargetType.Ship_Amphibious_5001_10000_tons;
								}
								return _WRA_WeaponTargetType.Ship_Amphibious_10001_25000_tons;
							}
							return _WRA_WeaponTargetType.Ship_Amphibious_25001_45000_tons;
						}
						return _WRA_WeaponTargetType.Ship_Amphibious_45001_95000_tons;
					}
					return _WRA_WeaponTargetType.Ship_Amphibious_95000_tons;
				case Ship._ShipCategory.Auxiliary:
					if (ship.Displacement_Standard < 95001f)
					{
						if (ship.Displacement_Standard < 45001f)
						{
							if (ship.Displacement_Standard < 25001f)
							{
								if (ship.Displacement_Standard < 10001f)
								{
									if (ship.Displacement_Standard < 5001f)
									{
										if (ship.Displacement_Standard < 1501f)
										{
											if (ship.Displacement_Standard < 501f)
											{
												if (!(ship.Displacement_Standard < 0f))
												{
													return _WRA_WeaponTargetType.Ship_Auxiliary_0_500_tons;
												}
												break;
											}
											return _WRA_WeaponTargetType.Ship_Auxiliary_501_1500_tons;
										}
										return _WRA_WeaponTargetType.Ship_Auxiliary_1501_5000_tons;
									}
									return _WRA_WeaponTargetType.Ship_Auxiliary_5001_10000_tons;
								}
								return _WRA_WeaponTargetType.Ship_Auxiliary_10001_25000_tons;
							}
							return _WRA_WeaponTargetType.Ship_Auxiliary_25001_45000_tons;
						}
						return _WRA_WeaponTargetType.Ship_Auxiliary_45001_95000_tons;
					}
					return _WRA_WeaponTargetType.Ship_Auxiliary_95000_tons;
				case Ship._ShipCategory.Merchant:
				case Ship._ShipCategory.Civilian:
					if (ship.Displacement_Standard < 95001f)
					{
						if (ship.Displacement_Standard < 45001f)
						{
							if (ship.Displacement_Standard < 25001f)
							{
								if (ship.Displacement_Standard < 10001f)
								{
									if (ship.Displacement_Standard < 5001f)
									{
										if (ship.Displacement_Standard < 1501f)
										{
											if (ship.Displacement_Standard < 501f)
											{
												if (!(ship.Displacement_Standard < 0f))
												{
													return _WRA_WeaponTargetType.Ship_Merchant_Civilian_0_500_tons;
												}
												break;
											}
											return _WRA_WeaponTargetType.Ship_Merchant_Civilian_501_1500_tons;
										}
										return _WRA_WeaponTargetType.Ship_Merchant_Civilian_1501_5000_tons;
									}
									return _WRA_WeaponTargetType.Ship_Merchant_Civilian_5001_10000_tons;
								}
								return _WRA_WeaponTargetType.Ship_Merchant_Civilian_10001_25000_tons;
							}
							return _WRA_WeaponTargetType.Ship_Merchant_Civilian_25001_45000_tons;
						}
						return _WRA_WeaponTargetType.Ship_Merchant_Civilian_45001_95000_tons;
					}
					return _WRA_WeaponTargetType.Ship_Merchant_Civilian_95000_tons;
				case Ship._ShipCategory.SurfaceCombatant:
				case Ship._ShipCategory.SurfaceCombatantAviation:
					if (ship.Displacement_Standard < 95001f)
					{
						if (ship.Displacement_Standard < 45001f)
						{
							if (ship.Displacement_Standard < 25001f)
							{
								if (ship.Displacement_Standard < 10001f)
								{
									if (ship.Displacement_Standard < 5001f)
									{
										if (ship.Displacement_Standard < 1501f)
										{
											if (ship.Displacement_Standard < 501f)
											{
												if (ship.Displacement_Standard < 0f)
												{
													break;
												}
												switch (ship.Type)
												{
												default:
												{
													bool flag = false;
													foreach (Weapon value in ship.Weaponry.AllDistinctWeaponsAboard_Potential(bool_1: false).Values)
													{
														if (value.IsMissile && (value.IsASuW_Naval || value.IsASuW_Land))
														{
															flag = true;
															break;
														}
													}
													if (flag)
													{
														return _WRA_WeaponTargetType.Ship_Surface_Combatant_501_1500_tons;
													}
													return _WRA_WeaponTargetType.Ship_Surface_Combatant_0_500_tons;
												}
												case Ship._ShipType.PCFG:
												case Ship._ShipType.PGM:
												case Ship._ShipType.PHM:
												case Ship._ShipType.MTB:
													return _WRA_WeaponTargetType.Ship_Surface_Combatant_501_1500_tons;
												}
											}
											Ship._ShipType type = ship.Type;
											if ((uint)(type - 3207) > 2u && (uint)(type - 3301) > 3u)
											{
												return _WRA_WeaponTargetType.Ship_Surface_Combatant_501_1500_tons;
											}
											return _WRA_WeaponTargetType.Ship_Surface_Combatant_1501_5000_tons;
										}
										return _WRA_WeaponTargetType.Ship_Surface_Combatant_1501_5000_tons;
									}
									return _WRA_WeaponTargetType.Ship_Surface_Combatant_5001_10000_tons;
								}
								return _WRA_WeaponTargetType.Ship_Surface_Combatant_10001_25000_tons;
							}
							return _WRA_WeaponTargetType.Ship_Surface_Combatant_25001_45000_tons;
						}
						return _WRA_WeaponTargetType.Ship_Surface_Combatant_45001_95000_tons;
					}
					return _WRA_WeaponTargetType.Ship_Surface_Combatant_95000_tons;
				case Ship._ShipCategory.AviationShip:
				case Ship._ShipCategory.MobileOffshoreBase:
					if (ship.Displacement_Standard < 95001f)
					{
						if (ship.Displacement_Standard < 45001f)
						{
							if (ship.Displacement_Standard < 25001f)
							{
								return _WRA_WeaponTargetType.Ship_Carrier_0_25000_tons;
							}
							return _WRA_WeaponTargetType.Ship_Carrier_25001_45000_tons;
						}
						return _WRA_WeaponTargetType.Ship_Carrier_45001_95000_tons;
					}
					return _WRA_WeaponTargetType.Ship_Carrier_95000_tons;
				}
				break;
			}
			case Contact_Base.ContactType.Submarine:
				if (((Submarine)actualUnit).IsSurfaced)
				{
					return _WRA_WeaponTargetType.Submarine_Surfaced;
				}
				return _WRA_WeaponTargetType.Submarine_Unspecified;
			case Contact_Base.ContactType.Orbital:
				return _WRA_WeaponTargetType.Satellite_Unspecified;
			case Contact_Base.ContactType.Facility_Fixed:
			case Contact_Base.ContactType.Facility_Mobile:
			{
				if (actualUnit.IsMobileGroundUnit)
				{
					switch (((IMobileGroundUnit)actualUnit).MobileUnitCategory)
					{
					case IMobileGroundUnit._MobileUnitCategory.Armor:
						return _WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle;
					default:
						return _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Vehicle;
					case IMobileGroundUnit._MobileUnitCategory.Infantry:
					case IMobileGroundUnit._MobileUnitCategory.Infantry_Old:
						return _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel;
					}
				}
				Facility facility = (Facility)actualUnit;
				switch (facility.Category)
				{
				case Facility._FacilityCategory.Building_Surface:
					if (facility.Armor_General < GlobalVariables.ArmorRating.Light)
					{
						return _WRA_WeaponTargetType.Land_Structure_Soft_Building_Surface;
					}
					return _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Surface;
				case Facility._FacilityCategory.Building_Reveted:
					if (facility.Armor_General < GlobalVariables.ArmorRating.Light)
					{
						return _WRA_WeaponTargetType.Land_Structure_Soft_Building_Reveted;
					}
					return _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Reveted;
				case Facility._FacilityCategory.Building_Bunker:
					return _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Bunker;
				case Facility._FacilityCategory.Structure_Open:
					if (facility.Armor_General < GlobalVariables.ArmorRating.Light)
					{
						return _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Open;
					}
					return _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Open;
				case Facility._FacilityCategory.Structure_Reveted:
					if (facility.Armor_General < GlobalVariables.ArmorRating.Light)
					{
						return _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Reveted;
					}
					return _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Reveted;
				case Facility._FacilityCategory.Building_Underground:
				case Facility._FacilityCategory.SurfaceAndUnderground:
					return _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Underground;
				case Facility._FacilityCategory.Runway:
					return _WRA_WeaponTargetType.Runway;
				case Facility._FacilityCategory.RunwayGrade_Taxiway:
					return _WRA_WeaponTargetType.Runway_Grade_Taxiway;
				case Facility._FacilityCategory.RunwayAccessPoint:
					return _WRA_WeaponTargetType.Runway_Access_Point;
				case Facility._FacilityCategory.Water_Surface:
					return _WRA_WeaponTargetType.Surface_Contact_Unknown_Type;
				case Facility._FacilityCategory.Underwater:
					return _WRA_WeaponTargetType.Underwater_Structure;
				case Facility._FacilityCategory.Mobile_Personnel:
					return _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel;
				case Facility._FacilityCategory.Mobile_Vehicle:
					return _WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle;
				default:
					if (facility.Armor_General < GlobalVariables.ArmorRating.Light)
					{
						return _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified;
					}
					return _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified;
				case Facility._FacilityCategory.AirBase:
					return _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified;
				case Facility._FacilityCategory.AerostatMooring:
					return _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified;
				}
			}
			case Contact_Base.ContactType.Torpedo:
				return _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type;
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new NotImplementedException();
			case Contact_Base.ContactType.Decoy_Air:
			case Contact_Base.ContactType.Decoy_Surface:
			case Contact_Base.ContactType.Decoy_Land:
			case Contact_Base.ContactType.Decoy_Sub:
				return _WRA_WeaponTargetType.Decoy;
			}
		}
		return (_WRA_WeaponTargetType)0;
	}

	public static bool WRA_IsTopNodeTargetType(ref _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		switch (_WRA_WeaponTargetType_0)
		{
		case _WRA_WeaponTargetType.Guided_Weapon_Unspecified:
			return true;
		case _WRA_WeaponTargetType.Helicopter_Unspecified:
			return true;
		case _WRA_WeaponTargetType.Air_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Aircraft_Unspecified:
			return true;
		case _WRA_WeaponTargetType.Land_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified:
			return true;
		case _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Submarine_Unspecified:
			return true;
		case _WRA_WeaponTargetType.Surface_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Ship_Unspecified:
			return true;
		case _WRA_WeaponTargetType.Radar_Unspecified:
			return true;
		case _WRA_WeaponTargetType.Runway_Facility_Unspecified:
			return true;
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified:
			return true;
		case _WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified:
			return true;
		case _WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified:
			return true;
		case _WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield:
			return true;
		default:
			return false;
		case _WRA_WeaponTargetType.Underwater_Structure:
			return true;
		}
	}

	public static _WRA_WeaponTargetType WRA_DetermineTargetType_Unspecified(ref _WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		switch (_WRA_WeaponTargetType_0)
		{
		case _WRA_WeaponTargetType.Aircraft_5th_Generation:
		case _WRA_WeaponTargetType.Aircraft_4th_Generation:
		case _WRA_WeaponTargetType.Aircraft_3rd_Generation:
		case _WRA_WeaponTargetType.Aircraft_Less_Capable:
		case _WRA_WeaponTargetType.Aircraft_High_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_High_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_AEW:
		case _WRA_WeaponTargetType.Aircraft_MicroUAV:
		case _WRA_WeaponTargetType.Aircraft_Tanker:
			return _WRA_WeaponTargetType.Aircraft_Unspecified;
		case _WRA_WeaponTargetType.Guided_Weapon_Supersonic_Sea_Skimming:
		case _WRA_WeaponTargetType.Guided_Weapon_Subsonic_Sea_Skimming:
		case _WRA_WeaponTargetType.Guided_Weapon_Supersonic:
		case _WRA_WeaponTargetType.Guided_Weapon_Subsonic:
		case _WRA_WeaponTargetType.Guided_Weapon_Ballistic:
			return _WRA_WeaponTargetType.Guided_Weapon_Unspecified;
		case _WRA_WeaponTargetType.Ship_Carrier_0_25000_tons:
		case _WRA_WeaponTargetType.Ship_Carrier_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Carrier_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Carrier_95000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_95000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_95000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_95000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_95000_tons:
		case _WRA_WeaponTargetType.Submarine_Surfaced:
			return _WRA_WeaponTargetType.Ship_Unspecified;
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Surface:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Reveted:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Bunker:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Underground:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Open:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Reveted:
			return _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified;
		case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Surface:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Reveted:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Open:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Reveted:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Aerostat_Moring:
			return _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified;
		default:
			return _WRA_WeaponTargetType.None;
		case _WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle:
			return _WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified;
		case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Vehicle:
		case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel:
			return _WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified;
		case _WRA_WeaponTargetType.Runway:
		case _WRA_WeaponTargetType.Runway_Grade_Taxiway:
		case _WRA_WeaponTargetType.Runway_Access_Point:
			return _WRA_WeaponTargetType.Runway_Facility_Unspecified;
		}
	}

	[SpecialName]
	public _UseNukesAllowed? GetNukesAllowed(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (NukesAllowed_Inherits())
			{
				Doctrine doctrine = null;
				while (Information.IsNothing(doctrine))
				{
					bool bool_3 = true;
					doctrine = GetParentDoctrine(scenario_0, ref bool_3);
				}
				return doctrine.GetNukesAllowed(scenario_0, bool_0, bool_1, bool_2);
			}
			return _AdapterIssuer.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200447", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			_UseNukesAllowed? result = _UseNukesAllowed.No;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public void SetNukesAllowed(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _UseNukesAllowed? nullable_0)
	{
		_AdapterIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool NukesAllowed_Inherits()
	{
		return !_AdapterIssuer.HasValue;
	}

	[SpecialName]
	public bool GetNukesAllowed_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return _SchemaIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetNukesAllowed_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetNukesAllowed_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			_SchemaIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetNukesAllowed_PlayerEditable(scenario_0, bool_0);
	}

	public void ComboBox_NukesAllowed(ref DataTable dataTable_0, Scenario scenario_0, _UseNukesAllowed? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "授权 - 使用核武器";
		string text2 = "未授权 - 不要使用核武器";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(2, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(2, "继承，多种设置");
				}
			}
		}
		else
		{
			bool bool_ = true;
			b = (byte?)GetParentDoctrine(scenario_0, ref bool_).GetNukesAllowed(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				dataTable_0.Rows.Add(2, "继承，" + text2);
			}
		}
		b = (byte?)GetNukesAllowed(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(3, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(3, "未配置");
		}
	}

	public void ComboBox_WeaponControlStatus_Air(ref DataTable dataTable_0, Scenario scenario_0, _WCS? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "FREE - fire at any contact not positively identified as friendly or neutral";
		string text2 = "谨慎开火 - 只有被确认为敌对的目标才会开火";
		string text3 = "限制开火 - 除自卫外不开火（仅限手动）";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(3, "继承，" + text3);
					}
					else
					{
						dataTable_0.Rows.Add(3, "继承，多种设置");
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_WCS? weaponControlStatus_Air = GetParentDoctrine(scenario_0, ref bool_).GetWeaponControlStatus_Air(scenario_0, bool_0: false, null, bool_1: false, bool_2: false);
			b = (byte?)weaponControlStatus_Air;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				b = (byte?)weaponControlStatus_Air;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(3, "继承，" + text3);
				}
			}
		}
		b = (byte?)GetWeaponControlStatus_Air(scenario_0, bool_0: false, false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(4, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(4, "未配置");
		}
	}

	public void ComboBox_WeaponControlStatus_Surface(ref DataTable dataTable_0, Scenario scenario_0, _WCS? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "FREE - fire at any contact not positively identified as friendly or neutral";
		string text2 = "谨慎开火 - 只有被确认为敌对的目标才会开火";
		string text3 = "限制开火 - 除自卫外不开火（仅限手动）";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(3, "继承，" + text3);
					}
					else
					{
						dataTable_0.Rows.Add(3, "继承，多种设置");
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_WCS? weaponControlStatus_Surface = GetParentDoctrine(scenario_0, ref bool_).GetWeaponControlStatus_Surface(scenario_0, bool_0: false, null, bool_1: false, bool_2: false);
			b = (byte?)weaponControlStatus_Surface;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				b = (byte?)weaponControlStatus_Surface;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(3, "继承，" + text3);
				}
			}
		}
		b = (byte?)GetWeaponControlStatus_Surface(scenario_0, bool_0: false, false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(4, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(4, "未配置");
		}
	}

	public void ComboBox_WeaponControlStatus_Submarine(ref DataTable dataTable_0, Scenario scenario_0, _WCS? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "FREE - fire at any contact not positively identified as friendly or neutral";
		string text2 = "谨慎开火 - 只有被确认为敌对的目标才会开火";
		string text3 = "限制开火 - 除自卫外不开火（仅限手动）";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(3, "继承，" + text3);
					}
					else
					{
						dataTable_0.Rows.Add(3, "继承，多种设置");
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_WCS? weaponControlStatus_Submarine = GetParentDoctrine(scenario_0, ref bool_).GetWeaponControlStatus_Submarine(scenario_0, bool_0: false, null, bool_1: false, bool_2: false);
			b = (byte?)weaponControlStatus_Submarine;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				b = (byte?)weaponControlStatus_Submarine;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(3, "继承，" + text3);
				}
			}
		}
		b = (byte?)GetWeaponControlStatus_Submarine(scenario_0, bool_0: false, false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(4, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(4, "未配置");
		}
	}

	public void ComboBox_WeaponControlStatus_Land(ref DataTable dataTable_0, Scenario scenario_0, _WCS? nullable_0)
	{
		try
		{
			if (!dataTable_0.Columns.Contains("ID"))
			{
				dataTable_0.Columns.Add("ID", typeof(int));
			}
			if (!dataTable_0.Columns.Contains("Description"))
			{
				dataTable_0.Columns.Add("Description", typeof(string));
			}
			string text = "FREE - fire at any contact not positively identified as friendly or neutral";
			string text2 = "谨慎开火 - 只有被确认为敌对的目标才会开火";
			string text3 = "限制开火 - 除自卫外不开火（仅限手动）";
			dataTable_0.Rows.Add(0, text);
			dataTable_0.Rows.Add(1, text2);
			dataTable_0.Rows.Add(2, text3);
			if ((object)SubjectType == typeof(Side))
			{
				return;
			}
			byte? b;
			if (Information.IsNothing(nullable_0))
			{
				bool bool_ = true;
				_WCS? weaponControlStatus_Land = GetParentDoctrine(scenario_0, ref bool_).GetWeaponControlStatus_Land(scenario_0, bool_0: false, null, bool_1: false, bool_2: false);
				b = (byte?)weaponControlStatus_Land;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text);
				}
				else
				{
					b = (byte?)weaponControlStatus_Land;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(3, "继承，" + text2);
					}
					else
					{
						dataTable_0.Rows.Add(3, "继承，" + text3);
					}
				}
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text);
				}
				else
				{
					b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(3, "继承，" + text2);
					}
					else
					{
						b = (byte?)nullable_0;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(3, "继承，" + text3);
						}
						else
						{
							dataTable_0.Rows.Add(3, "继承，多种设置");
						}
					}
				}
			}
			b = (byte?)GetWeaponControlStatus_Land(scenario_0, bool_0: false, false, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(4, "Various");
			}
			if ((object)SubjectType == typeof(Waypoint))
			{
				dataTable_0.Rows.Add(4, "未配置");
			}
			b = (byte?)GetWeaponControlStatus_Land(scenario_0, bool_0: false, false, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(4, "Various");
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

	public void ComboBox_IgnorePlottedCourse(ref DataTable dataTable_0, Scenario scenario_0, _UseIgnorePlottedCourse? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "Yes";
		string text2 = "No";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(2, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(2, "继承，多种设置");
				}
			}
		}
		else
		{
			bool bool_ = true;
			b = (byte?)GetParentDoctrine(scenario_0, ref bool_).GetIgnorePlottedCourse(scenario_0, bool_0: false, null, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				dataTable_0.Rows.Add(2, "继承，" + text2);
			}
		}
		b = (byte?)GetIgnorePlottedCourse(scenario_0, bool_0: false, false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(3, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(3, "未配置");
		}
	}

	public void ComboBox_WeaponStateRTB(ref DataTable dataTable_0, Scenario scenario_0, _WeaponStateRTB? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "是，飞机达到武器状态时离开编队并返回基地";
		string text2 = "是，当有一架飞机达到武器状态时整个编队返回基地";
		string text3 = "是，当所有飞机达到武器状态时整个编队返回基地";
		string text4 = "否，飞机在达到武器状态时不返回基地";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		dataTable_0.Rows.Add(3, text4);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(4, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(4, "继承，" + text2);
				}
				else
				{
					b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(4, "继承，" + text3);
					}
					else
					{
						b = (byte?)nullable_0;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(4, "继承，" + text4);
						}
						else
						{
							dataTable_0.Rows.Add(4, "继承，多种设置");
						}
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_WeaponStateRTB? winchesterShotgunRTB = GetParentDoctrine(scenario_0, ref bool_).GetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			b = (byte?)winchesterShotgunRTB;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(4, "继承，" + text);
			}
			else
			{
				b = (byte?)winchesterShotgunRTB;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(4, "继承，" + text2);
				}
				else
				{
					b = (byte?)winchesterShotgunRTB;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(4, "继承，" + text3);
					}
					else
					{
						dataTable_0.Rows.Add(4, "继承，" + text4);
					}
				}
			}
		}
		b = (byte?)GetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(5, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(5, "未配置");
		}
	}

	public void ComboBox_FuelStateRTB(ref DataTable dataTable_0, Scenario scenario_0, _FuelStateRTB? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "是，当单元达到燃料状态时离开编队并返回基地";
		string text2 = "是，当有一个单元达到燃料状态时整个编队返回基地";
		string text3 = "是，当所有单元达到燃料状态时整个编队返回基地（警告：不推荐！）";
		string text4 = "否，当达到燃料状态时，单元不返回基地";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		dataTable_0.Rows.Add(3, text4);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(4, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(4, "继承，" + text2);
				}
				else
				{
					b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(4, "继承，" + text3);
					}
					else
					{
						b = (byte?)nullable_0;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(4, "继承，" + text4);
						}
						else
						{
							dataTable_0.Rows.Add(4, "继承，多种设置");
						}
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_FuelStateRTB? bingoJokerRTB = GetParentDoctrine(scenario_0, ref bool_).GetBingoJokerRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			b = (byte?)bingoJokerRTB;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(4, "继承，" + text);
			}
			else
			{
				b = (byte?)bingoJokerRTB;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(4, "继承，" + text2);
				}
				else
				{
					b = (byte?)bingoJokerRTB;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(4, "继承，" + text3);
					}
					else
					{
						dataTable_0.Rows.Add(4, "继承，" + text4);
					}
				}
			}
		}
		b = (byte?)GetBingoJokerRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(5, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(5, "未配置");
		}
	}

	public void ComboBox_JettisonOrdnance(ref DataTable dataTable_0, Scenario scenario_0, _JettisonOrdnance? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "受到攻击时丢弃弹药";
		string text2 = "No";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(2, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(2, "继承，多种设置");
				}
			}
		}
		else
		{
			bool bool_ = true;
			b = (byte?)GetParentDoctrine(scenario_0, ref bool_).GetJettison(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				dataTable_0.Rows.Add(2, "继承，" + text2);
			}
		}
		b = (byte?)GetJettison(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(3, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(3, "未配置");
		}
	}

	public void ComboBox_BVRLogic(ref DataTable dataTable_0, Scenario scenario_0, _BVRLogicEnum? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "继续跟随导弹飞向目标";
		string text2 = "如果可能的话，在制导雷达探测范围边缘转弯";
		string text3 = "Crank and drag";
		string text4 = "Drag immediately";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		dataTable_0.Rows.Add(3, text4);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		if (Information.IsNothing(nullable_0))
		{
			bool bool_ = true;
			_BVRLogicEnum? bVRLogicEnum = GetParentDoctrine(scenario_0, ref bool_).method_0(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			byte? b = (byte?)bVRLogicEnum;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(4, "继承，" + text);
			}
			else
			{
				b = (byte?)bVRLogicEnum;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(4, "继承，" + text2);
				}
				else
				{
					b = (byte?)bVRLogicEnum;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(4, "继承，" + text3);
					}
					else
					{
						b = (byte?)bVRLogicEnum;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(4, "继承，" + text4);
						}
					}
				}
			}
			b = (byte?)method_0(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(5, "Various");
			}
			if ((object)SubjectType == typeof(Waypoint))
			{
				dataTable_0.Rows.Add(5, "未配置");
			}
			return;
		}
		byte? b2 = (byte?)nullable_0;
		if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(4, "继承，" + text);
			return;
		}
		b2 = (byte?)nullable_0;
		if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(4, "继承，" + text2);
			return;
		}
		b2 = (byte?)nullable_0;
		if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(4, "继承，" + text3);
			return;
		}
		b2 = (byte?)nullable_0;
		if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 5) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(4, "继承，" + text4);
		}
		else
		{
			dataTable_0.Rows.Add(4, "继承，多种设置");
		}
	}

	public void ComboBox_BehaviorTowardsAmbigousTarget(ref DataTable dataTable_0, Scenario scenario_0, _BehaviorTowardsTargetAmbiguity? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "Ignore";
		string text2 = "Optimistic";
		string text3 = "Pessimistic";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(3, "继承，" + text3);
					}
					else
					{
						dataTable_0.Rows.Add(3, "继承，多种设置");
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_BehaviorTowardsTargetAmbiguity? behaviorTowardsAmbigousTarget = GetParentDoctrine(scenario_0, ref bool_).GetBehaviorTowardsAmbigousTarget(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			b = (byte?)behaviorTowardsAmbigousTarget;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				b = (byte?)behaviorTowardsAmbigousTarget;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(3, "继承，" + text3);
				}
			}
		}
		b = (byte?)GetBehaviorTowardsAmbigousTarget(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(4, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(4, "未配置");
		}
	}

	private void CheckRepository(ref DataTable dataTable_0, Scenario scenario_0, _UseAutoEvade? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "Yes";
		string text2 = "No";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(2, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(2, "继承，多种设置");
				}
			}
		}
		else
		{
			bool bool_ = true;
			b = (byte?)GetParentDoctrine(scenario_0, ref bool_).GetAutoEvade(scenario_0, bool_0: false, bool_1: true, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				dataTable_0.Rows.Add(2, "继承，" + text2);
			}
		}
		b = (byte?)GetAutoEvade(scenario_0, bool_0: false, bool_1: true, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(3, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(3, "未配置");
		}
	}

	public void ComboBox_MaintainStandoff(ref DataTable dataTable_0, Scenario scenario_0, _UseMaintainStandoff? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "Yes";
		string text2 = "No";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(2, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(2, "继承，多种设置");
				}
			}
		}
		else
		{
			bool bool_ = true;
			b = (byte?)GetParentDoctrine(scenario_0, ref bool_).GetMaintainStandoff(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				dataTable_0.Rows.Add(2, "继承，" + text2);
			}
		}
		b = (byte?)GetMaintainStandoff(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(3, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(3, "未配置");
		}
	}

	public void ComboBox_SurfaceNavigation(ref DataTable dataTable_0, Scenario scenario_0, _NavigationMethod? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "最短路径";
		string text2 = "深水导航，深度1525米+ (5000英尺+)";
		string text3 = "浅海导航，深度200米 (660英尺)";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (Information.IsNothing(nullable_0))
		{
			bool bool_ = true;
			_NavigationMethod? surfaceNavigation = GetParentDoctrine(scenario_0, ref bool_).GetSurfaceNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			b = (byte?)surfaceNavigation;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				b = (byte?)surfaceNavigation;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(3, "继承，" + text3);
				}
			}
		}
		else
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(3, "继承，" + text3);
					}
					else
					{
						dataTable_0.Rows.Add(3, "继承，多种设置");
					}
				}
			}
		}
		b = (byte?)GetSurfaceNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 6) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(4, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(4, "未配置");
		}
	}

	public void ComboBox_SubmarineNavigation(ref DataTable dataTable_0, Scenario scenario_0, _NavigationMethod? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "最短路径";
		string text2 = "深水导航，深度1525米+ (5000英尺+)";
		string text3 = "CZ";
		string text4 = "Littoral";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		dataTable_0.Rows.Add(3, text4);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (Information.IsNothing(nullable_0))
		{
			bool bool_ = true;
			_NavigationMethod? submarineNavigation = GetParentDoctrine(scenario_0, ref bool_).GetSubmarineNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			b = (byte?)submarineNavigation;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(4, "继承，" + text);
			}
			else
			{
				b = (byte?)submarineNavigation;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(4, "继承，" + text2);
				}
				else
				{
					b = (byte?)submarineNavigation;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(4, "继承，" + text3);
					}
					else
					{
						dataTable_0.Rows.Add(4, "继承，" + text4);
					}
				}
			}
		}
		else
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(4, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(4, "继承，" + text2);
				}
				else
				{
					b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(4, "继承，" + text3);
					}
					else
					{
						b = (byte?)nullable_0;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(4, "继承，" + text4);
						}
						else
						{
							dataTable_0.Rows.Add(5, "继承，多种设置");
						}
					}
				}
			}
		}
		b = (byte?)GetSubmarineNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 6) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(5, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(5, "未配置");
		}
	}

	public void ComboBox_LandNavigation(ref DataTable dataTable_0, Scenario scenario_0, _NavigationMethod? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "最短路径";
		string text2 = "Direct Route";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (Information.IsNothing(nullable_0))
		{
			bool bool_ = true;
			_NavigationMethod? landNavigation = GetParentDoctrine(scenario_0, ref bool_).GetLandNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			b = (byte?)landNavigation;
			bool? flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null);
			b = (byte?)landNavigation;
			bool? flag2 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 8) : null);
			if ((flag.GetValueOrDefault() ? new bool?(true) : ((!flag2.HasValue) ? null : (flag2.GetValueOrDefault() | flag))).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
		}
		else
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				dataTable_0.Rows.Add(2, "继承，多种设置");
			}
		}
		b = (byte?)GetLandNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 6) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(3, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(3, "未配置");
		}
	}

	public void ComboBox_GunStrafing(ref DataTable dataTable_0, Scenario scenario_0, _GunStrafeGroundTargets? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "是（除非带有防区外武器挂载）";
		string text2 = "No";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(2, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(2, "继承，多种设置");
				}
			}
		}
		else
		{
			bool bool_ = true;
			b = (byte?)GetParentDoctrine(scenario_0, ref bool_).GetGunStrafing(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				dataTable_0.Rows.Add(2, "继承，" + text2);
			}
		}
		b = (byte?)GetGunStrafing(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(3, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(3, "未配置");
		}
	}

	public void ComboBox_UseReplenishment(ref DataTable dataTable_0, Scenario scenario_0, _UseUnderwayRefuelAndReplenishment? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "Allow";
		string text2 = "允许，但不是加油机给加油机加油";
		string text3 = "不允许";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(3, "继承，" + text3);
					}
					else
					{
						dataTable_0.Rows.Add(3, "继承，多种设置");
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_UseUnderwayRefuelAndReplenishment? useReplenishment = GetParentDoctrine(scenario_0, ref bool_).GetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			b = (byte?)useReplenishment;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				b = (byte?)useReplenishment;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(3, "继承，" + text3);
				}
			}
		}
		b = (byte?)GetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(4, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(4, "未配置");
		}
	}

	public void ComboBox_ReplenishmentSelection(ref DataTable dataTable_0, Scenario scenario_0, _UnderwayRefuelAndReplenishmentSelection? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "选择最近的";
		string text2 = "选择单元与目标（或巡逻点，或基地）之间的加油机";
		string text3 = "优先选择单元与目标（或巡逻点，或基地）之间的加油机，但允许返回燃料";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		if ((object)SubjectType != typeof(Side))
		{
			byte? b;
			if (nullable_0.HasValue)
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text);
				}
				else
				{
					b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(3, "继承，" + text2);
					}
					else
					{
						b = (byte?)nullable_0;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(3, "继承，" + text3);
						}
						else
						{
							dataTable_0.Rows.Add(3, "继承，多种设置");
						}
					}
				}
			}
			else
			{
				bool bool_ = true;
				_UnderwayRefuelAndReplenishmentSelection? replenishmentSelection = GetParentDoctrine(scenario_0, ref bool_).GetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
				b = (byte?)replenishmentSelection;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text);
				}
				else
				{
					b = (byte?)replenishmentSelection;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(3, "继承，" + text2);
					}
					else
					{
						dataTable_0.Rows.Add(3, "继承，" + text3);
					}
				}
			}
			b = (byte?)GetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(4, "Various");
			}
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(4, "未配置");
		}
	}

	public void ComboBox_ShootTourists(ref DataTable dataTable_0, Scenario scenario_0, _UseShootTourists? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "是（攻击任何目标）";
		string text2 = "否（仅限任务相关的目标）";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(2, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(2, "继承，多种设置");
				}
			}
		}
		else
		{
			bool bool_ = true;
			b = (byte?)GetParentDoctrine(scenario_0, ref bool_).GetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				dataTable_0.Rows.Add(2, "继承，" + text2);
			}
		}
		b = (byte?)GetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(3, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(3, "未配置");
		}
	}

	public void ComboBox_UseSAMsOnASuW(ref DataTable dataTable_0, Scenario scenario_0, _UseSAMsAgainstShips? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "是，使用SASS（地对地中的地对空）模式";
		string text2 = "No";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(2, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(2, "继承，多种设置");
				}
			}
		}
		else
		{
			bool bool_ = true;
			b = (byte?)GetParentDoctrine(scenario_0, ref bool_).GetUseSAMsOnASuW(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				dataTable_0.Rows.Add(2, "继承，" + text2);
			}
		}
		b = (byte?)GetUseSAMsOnASuW(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(3, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(3, "未配置");
		}
	}

	public void ComboBox_UseWPMissileOnASuW(ref DataTable dataTable_0, Scenario scenario_0, _UseWpMissileAgainstShips? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "Yes, use missile waypoint";
		string text2 = "No";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(2, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(2, "继承，多种设置");
				}
			}
		}
		else
		{
			bool bool_ = true;
			b = (byte?)GetParentDoctrine(scenario_0, ref bool_).GetUseWPMissileOnASuW(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				dataTable_0.Rows.Add(2, "继承，" + text2);
			}
		}
		b = (byte?)GetUseSAMsOnASuW(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(3, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(3, "未配置");
		}
	}

	public void ComboBox_IgnoreEMCONunderAttack(ref DataTable dataTable_0, Scenario scenario_0, _UseIgnoreEMCONunderAttack? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "Yes";
		string text2 = "No";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(2, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(2, "继承，多种设置");
				}
			}
		}
		else
		{
			bool bool_ = true;
			b = (byte?)GetParentDoctrine(scenario_0, ref bool_).GetIgnoreEMCONunderAttack(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				dataTable_0.Rows.Add(2, "继承，" + text2);
			}
		}
		b = (byte?)GetIgnoreEMCONunderAttack(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(3, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(3, "未配置");
		}
	}

	public void ComboBox_QuickTurnAroundForAicraft(ref DataTable dataTable_0, Scenario scenario_0, bool bool_0, _QuickTurnAroundForAicraft? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "Yes";
		string text2 = "战斗机和反潜ASW挂载";
		string text3 = "No";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(3, "继承，" + text3);
					}
					else
					{
						dataTable_0.Rows.Add(3, "继承，多种设置");
					}
				}
			}
		}
		else
		{
			_QuickTurnAroundForAicraft? quickTurnAroundForAicraft = GetParentDoctrine(scenario_0, ref bool_0)?.GetQuickTurnAroundForAicraft(scenario_0, bool_0: false, bool_1: true, bool_2: false, bool_3: false);
			b = (byte?)quickTurnAroundForAicraft;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				b = (byte?)quickTurnAroundForAicraft;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(3, "继承，" + text3);
				}
			}
		}
		b = (byte?)GetQuickTurnAroundForAicraft(scenario_0, bool_0: false, bool_1: true, bool_2: false, bool_3: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(4, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(4, "未配置");
		}
	}

	private void ConcatRepository(ref DataTable dataTable_0, Scenario scenario_0, bool bool_0, _AirOpsTempo? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "Surge";
		string text2 = "Sustained";
		dataTable_0.Rows.Add(0, text2);
		dataTable_0.Rows.Add(1, text);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(3, "继承，多种设置");
				}
			}
		}
		else
		{
			b = (byte?)GetParentDoctrine(scenario_0, ref bool_0)?.GetAirOpsTempo(scenario_0, bool_0: false, bool_1: true, bool_2: false, bool_3: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				dataTable_0.Rows.Add(3, "继承，" + text2);
			}
		}
		b = (byte?)GetAirOpsTempo(scenario_0, bool_0: false, bool_1: true, bool_2: false, bool_3: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(4, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(4, "未配置");
		}
	}

	public void ComboBox_WeaponState(ref DataTable dataTable_0, Scenario scenario_0, bool bool_0, _WeaponState? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "使用挂载设置";
		string text12 = "Winchester：任务武器已经用完。立即撤离";
		string text14 = "Winchester：任务武器已经用完。允许使用空对空机炮的机会目标。首选！";
		string text15 = "机炮：所有视距外(BVR)或防区外武器都已用完。立即撤离";
		string text16 = "机炮：所有视距外(BVR)或防区外武器都已用完。使用视距内(WVR)或直接攻击武器轻松实现机会目标。不使用空对空机炮";
		string text17 = "机炮：所有视距外(BVR)或防区外武器都已用完。使用视距内(WVR)或直接攻击武器和空对空机炮攻击机会目标";
		string text18 = "机炮：与视距外(BVR)或防区外(Stand-Off)武器的一次交战。立即撤离";
		string text19 = "机炮：与视距外(BVR)或防区外(Stand-Off)武器的一次交战。使用WVR或直接攻击武器轻松实现机会目标。不使用空对空机炮。首选！";
		string text20 = "机炮：与视距外(BVR)或防区外(Stand-Off)武器的一次交战。使用WVR或直接攻击武器和空对空机炮攻击机会目标";
		string text2 = "机炮：与视距外(BVR)和视距内(WVR)或防区外(Stand-Off)和直接攻击武器的一次交战。不使用空对空机炮。";
		string text3 = "机炮：与视距外(BVR)和视距内(WVR)或防区外(Stand-Off)和直接攻击武器的一次交战。通过空对空机炮攻击机会目标。首选！";
		string text4 = "机炮：与视距内(WVR)或攻击(Strike)武器的一次交战。立即撤离";
		string text5 = "机炮：与视距内(WVR)或攻击(Strike)武器的一次交战。允许使用空对空机炮的机会目标。首选！";
		string text6 = "机炮：与机炮进行一次交战";
		string text7 = "机炮：已经消耗了25％的相关武器。立即撤离";
		string text8 = "机炮：已经消耗了25％的相关武器。允许机会目标，包括空对空机炮";
		string text9 = "机炮：已经消耗了50％的相关武器。立即撤离";
		string text10 = "机炮：已经消耗了50％的相关武器。允许机会目标，包括空对空机炮";
		string text11 = "机炮：已经消耗了75％的相关武器。立即撤离";
		string text13 = "机炮：已经消耗了75％的相关武器。允许机会目标，包括空对空机炮";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text12);
		dataTable_0.Rows.Add(2, text14);
		dataTable_0.Rows.Add(3, text15);
		dataTable_0.Rows.Add(4, text16);
		dataTable_0.Rows.Add(5, text17);
		dataTable_0.Rows.Add(6, text18);
		dataTable_0.Rows.Add(7, text19);
		dataTable_0.Rows.Add(8, text20);
		dataTable_0.Rows.Add(9, text2);
		dataTable_0.Rows.Add(10, text3);
		dataTable_0.Rows.Add(11, text4);
		dataTable_0.Rows.Add(12, text5);
		dataTable_0.Rows.Add(13, text6);
		dataTable_0.Rows.Add(14, text7);
		dataTable_0.Rows.Add(15, text8);
		dataTable_0.Rows.Add(16, text9);
		dataTable_0.Rows.Add(17, text10);
		dataTable_0.Rows.Add(18, text11);
		dataTable_0.Rows.Add(19, text13);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		int? num;
		if (nullable_0.HasValue)
		{
			num = (int?)nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(20, "继承，" + text);
			}
			else
			{
				num = (int?)nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2001) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(20, "继承，" + text12);
				}
				else
				{
					num = (int?)nullable_0;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2002) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(20, "继承，" + text14);
					}
					else
					{
						num = (int?)nullable_0;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3001) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(20, "继承，" + text15);
						}
						else
						{
							num = (int?)nullable_0;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3002) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(20, "继承，" + text16);
							}
							else
							{
								num = (int?)nullable_0;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3003) : null).GetValueOrDefault())
								{
									dataTable_0.Rows.Add(20, "继承，" + text17);
								}
								else
								{
									num = (int?)nullable_0;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5001) : null).GetValueOrDefault())
									{
										dataTable_0.Rows.Add(20, "继承，" + text18);
									}
									else
									{
										num = (int?)nullable_0;
										if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5002) : null).GetValueOrDefault())
										{
											dataTable_0.Rows.Add(20, "继承，" + text19);
										}
										else
										{
											num = (int?)nullable_0;
											if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5003) : null).GetValueOrDefault())
											{
												dataTable_0.Rows.Add(20, "继承，" + text20);
											}
											else
											{
												num = (int?)nullable_0;
												if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5005) : null).GetValueOrDefault())
												{
													dataTable_0.Rows.Add(20, "继承，" + text2);
												}
												else
												{
													num = (int?)nullable_0;
													if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5006) : null).GetValueOrDefault())
													{
														dataTable_0.Rows.Add(20, "继承，" + text3);
													}
													else
													{
														num = (int?)nullable_0;
														if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5011) : null).GetValueOrDefault())
														{
															dataTable_0.Rows.Add(20, "继承，" + text4);
														}
														else
														{
															num = (int?)nullable_0;
															if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5012) : null).GetValueOrDefault())
															{
																dataTable_0.Rows.Add(20, "继承，" + text5);
															}
															else
															{
																num = (int?)nullable_0;
																if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5021) : null).GetValueOrDefault())
																{
																	dataTable_0.Rows.Add(20, "继承，" + text6);
																}
																else
																{
																	num = (int?)nullable_0;
																	if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4001) : null).GetValueOrDefault())
																	{
																		dataTable_0.Rows.Add(20, "继承，" + text7);
																	}
																	else
																	{
																		num = (int?)nullable_0;
																		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4002) : null).GetValueOrDefault())
																		{
																			dataTable_0.Rows.Add(20, "继承，" + text8);
																		}
																		else
																		{
																			num = (int?)nullable_0;
																			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4011) : null).GetValueOrDefault())
																			{
																				dataTable_0.Rows.Add(20, "继承，" + text9);
																			}
																			else
																			{
																				num = (int?)nullable_0;
																				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4012) : null).GetValueOrDefault())
																				{
																					dataTable_0.Rows.Add(20, "继承，" + text10);
																				}
																				else
																				{
																					num = (int?)nullable_0;
																					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4021) : null).GetValueOrDefault())
																					{
																						dataTable_0.Rows.Add(20, "继承，" + text11);
																					}
																					else
																					{
																						num = (int?)nullable_0;
																						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4022) : null).GetValueOrDefault())
																						{
																							dataTable_0.Rows.Add(20, "继承，" + text13);
																						}
																						else
																						{
																							dataTable_0.Rows.Add(20, "继承，多种设置");
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		else
		{
			_WeaponState? weaponState = GetParentDoctrine(scenario_0, ref bool_0)?.GetWinchesterShotgun(scenario_0, bool_0: false, bool_1: true, bool_2: false, bool_3: false);
			num = (int?)weaponState;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(20, "继承，" + text);
			}
			else
			{
				num = (int?)weaponState;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2001) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(20, "继承，" + text12);
				}
				else
				{
					num = (int?)weaponState;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2002) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(20, "继承，" + text14);
					}
					else
					{
						num = (int?)weaponState;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3001) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(20, "继承，" + text15);
						}
						else
						{
							num = (int?)weaponState;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3002) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(20, "继承，" + text16);
							}
							else
							{
								num = (int?)weaponState;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3003) : null).GetValueOrDefault())
								{
									dataTable_0.Rows.Add(20, "继承，" + text17);
								}
								else
								{
									num = (int?)weaponState;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5001) : null).GetValueOrDefault())
									{
										dataTable_0.Rows.Add(20, "继承，" + text18);
									}
									else
									{
										num = (int?)weaponState;
										if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5002) : null).GetValueOrDefault())
										{
											dataTable_0.Rows.Add(20, "继承，" + text19);
										}
										else
										{
											num = (int?)weaponState;
											if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5003) : null).GetValueOrDefault())
											{
												dataTable_0.Rows.Add(20, "继承，" + text20);
											}
											else
											{
												num = (int?)weaponState;
												if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5005) : null).GetValueOrDefault())
												{
													dataTable_0.Rows.Add(20, "继承，" + text2);
												}
												else
												{
													num = (int?)weaponState;
													if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5006) : null).GetValueOrDefault())
													{
														dataTable_0.Rows.Add(20, "继承，" + text3);
													}
													else
													{
														num = (int?)weaponState;
														if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5011) : null).GetValueOrDefault())
														{
															dataTable_0.Rows.Add(20, "继承，" + text4);
														}
														else
														{
															num = (int?)weaponState;
															if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5012) : null).GetValueOrDefault())
															{
																dataTable_0.Rows.Add(20, "继承，" + text5);
															}
															else
															{
																num = (int?)weaponState;
																if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5021) : null).GetValueOrDefault())
																{
																	dataTable_0.Rows.Add(20, "继承，" + text6);
																}
																else
																{
																	num = (int?)weaponState;
																	if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4001) : null).GetValueOrDefault())
																	{
																		dataTable_0.Rows.Add(20, "继承，" + text7);
																	}
																	else
																	{
																		num = (int?)weaponState;
																		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4002) : null).GetValueOrDefault())
																		{
																			dataTable_0.Rows.Add(20, "继承，" + text8);
																		}
																		else
																		{
																			num = (int?)weaponState;
																			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4011) : null).GetValueOrDefault())
																			{
																				dataTable_0.Rows.Add(20, "继承，" + text9);
																			}
																			else
																			{
																				num = (int?)weaponState;
																				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4012) : null).GetValueOrDefault())
																				{
																					dataTable_0.Rows.Add(20, "继承，" + text10);
																				}
																				else
																				{
																					num = (int?)weaponState;
																					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4021) : null).GetValueOrDefault())
																					{
																						dataTable_0.Rows.Add(20, "继承，" + text11);
																					}
																					else
																					{
																						dataTable_0.Rows.Add(20, "继承，" + text13);
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		num = (int?)GetWinchesterShotgun(scenario_0, bool_0: false, bool_1: true, bool_2: false, bool_3: false);
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(21, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(21, "未配置");
		}
	}

	public void ComboBox_FuelState(ref DataTable dataTable_0, Scenario scenario_0, bool bool_0, _FuelState? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "Bingo：终止任务并以计划剩余燃料返回基地";
		string text5 = "Joker：终止任务并返回基地，剩余10％的任务燃料（即比Bingo高出10％）";
		string text6 = "Joker：比Bingo高出20％";
		string text7 = "Joker：比Bingo高出25％";
		string text8 = "Joker：比Bingo高出30％";
		string text9 = "Joker：比Bingo高出40％";
		string text10 = "Joker：比Bingo高出50％";
		string text11 = "Joker：比Bingo高出60％";
		string text12 = "Joker：比Bingo高出70％";
		string text2 = "Joker：比Bingo高出75％";
		string text3 = "Joker：比Bingo高出80％";
		string text4 = "Joker：比Bingo高出90％";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text5);
		dataTable_0.Rows.Add(2, text6);
		dataTable_0.Rows.Add(3, text7);
		dataTable_0.Rows.Add(4, text8);
		dataTable_0.Rows.Add(5, text9);
		dataTable_0.Rows.Add(6, text10);
		dataTable_0.Rows.Add(7, text11);
		dataTable_0.Rows.Add(8, text12);
		dataTable_0.Rows.Add(9, text2);
		dataTable_0.Rows.Add(10, text3);
		dataTable_0.Rows.Add(11, text4);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(12, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(12, "继承，" + text5);
				}
				else
				{
					b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(12, "继承，" + text6);
					}
					else
					{
						b = (byte?)nullable_0;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(12, "继承，" + text7);
						}
						else
						{
							b = (byte?)nullable_0;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(12, "继承，" + text8);
							}
							else
							{
								b = (byte?)nullable_0;
								if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									dataTable_0.Rows.Add(12, "继承，" + text9);
								}
								else
								{
									b = (byte?)nullable_0;
									if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 6) : null).GetValueOrDefault())
									{
										dataTable_0.Rows.Add(12, "继承，" + text10);
									}
									else
									{
										b = (byte?)nullable_0;
										if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 7) : null).GetValueOrDefault())
										{
											dataTable_0.Rows.Add(12, "继承，" + text11);
										}
										else
										{
											b = (byte?)nullable_0;
											if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 8) : null).GetValueOrDefault())
											{
												dataTable_0.Rows.Add(12, "继承，" + text12);
											}
											else
											{
												b = (byte?)nullable_0;
												if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 9) : null).GetValueOrDefault())
												{
													dataTable_0.Rows.Add(12, "继承，" + text2);
												}
												else
												{
													b = (byte?)nullable_0;
													if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 10) : null).GetValueOrDefault())
													{
														dataTable_0.Rows.Add(12, "继承，" + text3);
													}
													else
													{
														b = (byte?)nullable_0;
														if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 11) : null).GetValueOrDefault())
														{
															dataTable_0.Rows.Add(12, "继承，" + text4);
														}
														else
														{
															dataTable_0.Rows.Add(12, "继承，多种设置");
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		else
		{
			_FuelState? fuelState = GetParentDoctrine(scenario_0, ref bool_0)?.GetBingoJoker(scenario_0, bool_0: false, bool_1: true, bool_2: false, bool_3: false);
			b = (byte?)fuelState;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(12, "继承，" + text);
			}
			else
			{
				b = (byte?)fuelState;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(12, "继承，" + text5);
				}
				else
				{
					b = (byte?)fuelState;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(12, "继承，" + text6);
					}
					else
					{
						b = (byte?)fuelState;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(12, "继承，" + text7);
						}
						else
						{
							b = (byte?)fuelState;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(12, "继承，" + text8);
							}
							else
							{
								b = (byte?)fuelState;
								if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									dataTable_0.Rows.Add(12, "继承，" + text9);
								}
								else
								{
									b = (byte?)fuelState;
									if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 6) : null).GetValueOrDefault())
									{
										dataTable_0.Rows.Add(12, "继承，" + text10);
									}
									else
									{
										b = (byte?)fuelState;
										if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 7) : null).GetValueOrDefault())
										{
											dataTable_0.Rows.Add(12, "继承，" + text11);
										}
										else
										{
											b = (byte?)fuelState;
											if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 8) : null).GetValueOrDefault())
											{
												dataTable_0.Rows.Add(12, "继承，" + text12);
											}
											else
											{
												b = (byte?)fuelState;
												if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 9) : null).GetValueOrDefault())
												{
													dataTable_0.Rows.Add(12, "继承，" + text2);
												}
												else
												{
													b = (byte?)fuelState;
													if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 10) : null).GetValueOrDefault())
													{
														dataTable_0.Rows.Add(12, "继承，" + text3);
													}
													else
													{
														dataTable_0.Rows.Add(12, "继承，" + text4);
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		b = (byte?)GetBingoJoker(scenario_0, bool_0: false, bool_1: true, bool_2: false, bool_3: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 12) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(13, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(13, "未配置");
		}
	}

	private void InterruptRepository(ref DataTable dataTable_0, Scenario scenario_0, _UseKinematicRangeForTorpedoes? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "自动和手动发射均使用动力范围";
		string text2 = "仅手动发射时使用动力范围";
		string text3 = "实际范围";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(3, "继承，" + text3);
					}
					else
					{
						dataTable_0.Rows.Add(3, "继承，多种设置");
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_UseKinematicRangeForTorpedoes? useKinematicRangeForTorpedoes = GetParentDoctrine(scenario_0, ref bool_).GetUseKinematicRangeForTorpedoes(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			b = (byte?)useKinematicRangeForTorpedoes;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				b = (byte?)useKinematicRangeForTorpedoes;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(3, "继承，" + text3);
				}
			}
		}
		b = (byte?)GetUseKinematicRangeForTorpedoes(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(4, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(4, "未配置");
		}
	}

	[SpecialName]
	public _WCS? GetWeaponControlStatus_Air(Scenario scenario_0, bool bool_0, bool? nullable_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (WeaponControlStatus_Air_Inherits())
			{
				bool bool_3 = true;
				return GetParentDoctrine(scenario_0, ref bool_3).GetWeaponControlStatus_Air(scenario_0, bool_0, nullable_0, bool_1, bool_2);
			}
			return codeIssuer.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200448", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			_WCS? result = _WCS.Hold;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public void SetWeaponControlStatus_Air(Scenario scenario_0, bool bool_0, bool? nullable_0, bool bool_1, bool bool_2, _WCS? nullable_1)
	{
		codeIssuer = nullable_1;
		m_InstanceClient?.Invoke(Subject, nullable_0, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool WeaponControlStatus_Air_Inherits()
	{
		return !codeIssuer.HasValue;
	}

	[SpecialName]
	public bool GetWeaponControlStatus_Air_PlayerEditable(Scenario scenario_0)
	{
		try
		{
			if ((object)SubjectType == typeof(Side))
			{
				return connectionIssuer;
			}
			bool bool_ = true;
			return GetParentDoctrine(scenario_0, ref bool_).GetWeaponControlStatus_Air_PlayerEditable(scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	[SpecialName]
	public void SetWeaponControlStatus_Air_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			connectionIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetWeaponControlStatus_Air_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _WCS? GetWeaponControlStatus_Surface(Scenario scenario_0, bool bool_0, bool? nullable_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (WeaponControlStatus_Surface_Inherits())
			{
				bool bool_3 = true;
				return GetParentDoctrine(scenario_0, ref bool_3).GetWeaponControlStatus_Surface(scenario_0, bool_0, nullable_0, bool_1, bool_2);
			}
			return m_ContextIssuer.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200449", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			_WCS? result = _WCS.Hold;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public void SetWeaponControlStatus_Surface(Scenario scenario_0, bool bool_0, bool? nullable_0, bool bool_1, bool bool_2, _WCS? nullable_1)
	{
		m_ContextIssuer = nullable_1;
		m_InstanceClient?.Invoke(Subject, nullable_0, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool WeaponControlStatus_Surface_Inherits()
	{
		return !m_ContextIssuer.HasValue;
	}

	[SpecialName]
	public bool GetWeaponControlStatus_Surface_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return m_StatusIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetWeaponControlStatus_Surface_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetWeaponControlStatus_Surface_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			m_StatusIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetWeaponControlStatus_Surface_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _WCS? GetWeaponControlStatus_Submarine(Scenario scenario_0, bool bool_0, bool? nullable_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (WeaponControlStatus_Submarine_Inherits())
			{
				bool bool_3 = true;
				return GetParentDoctrine(scenario_0, ref bool_3).GetWeaponControlStatus_Submarine(scenario_0, bool_0, nullable_0, bool_1, bool_2);
			}
			return proccesorIssuer.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200450", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			_WCS? result = _WCS.Hold;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public void SetWeaponControlStatus_Submarine(Scenario scenario_0, bool bool_0, bool? nullable_0, bool bool_1, bool bool_2, _WCS? nullable_1)
	{
		proccesorIssuer = nullable_1;
		m_InstanceClient?.Invoke(Subject, nullable_0, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool WeaponControlStatus_Submarine_Inherits()
	{
		return !proccesorIssuer.HasValue;
	}

	[SpecialName]
	public bool GetWeaponControlStatus_Submarine_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return strategyIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetWeaponControlStatus_Submarine_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetWeaponControlStatus_Submarine_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			strategyIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetWeaponControlStatus_Submarine_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _WCS? GetWeaponControlStatus_Land(Scenario scenario_0, bool bool_0, bool? nullable_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (WeaponControlStatus_Land_Inherits())
			{
				bool bool_3 = true;
				return GetParentDoctrine(scenario_0, ref bool_3).GetWeaponControlStatus_Land(scenario_0, bool_0, nullable_0, bool_1, bool_2);
			}
			return _ConfigurationIssuer.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200451", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			_WCS? result = _WCS.Hold;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public void SetWeaponControlStatus_Land(Scenario scenario_0, bool bool_0, bool? nullable_0, bool bool_1, bool bool_2, _WCS? nullable_1)
	{
		_ConfigurationIssuer = nullable_1;
		m_InstanceClient?.Invoke(Subject, nullable_0, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool WeaponControlStatus_Land_Inherits()
	{
		return !_ConfigurationIssuer.HasValue;
	}

	[SpecialName]
	public bool GetWeaponControlStatus_Land_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return m_TokenIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetWeaponControlStatus_Land_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetWeaponControlStatus_Land_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			m_TokenIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetWeaponControlStatus_Land_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _UseIgnorePlottedCourse? GetIgnorePlottedCourse(Scenario scenario_0, bool bool_0, bool? nullable_0, bool bool_1, bool bool_2)
	{
		if (IgnorePlottedCourse_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetIgnorePlottedCourse(scenario_0, bool_0, nullable_0, bool_1, bool_2);
		}
		if (m_PublisherIssuer.Value == (_UseIgnorePlottedCourse)255)
		{
			m_PublisherIssuer = _UseIgnorePlottedCourse.Yes;
		}
		return m_PublisherIssuer.Value;
	}

	[SpecialName]
	public void SetIgnorePlottedCourse(Scenario scenario_0, bool bool_0, bool? nullable_0, bool bool_1, bool bool_2, _UseIgnorePlottedCourse? nullable_1)
	{
		bool flag = false;
		if (m_PublisherIssuer.HasValue)
		{
			byte value = (byte)m_PublisherIssuer.Value;
			byte? b = (byte?)nullable_1;
			if ((b.HasValue ? new bool?(value != b.GetValueOrDefault()) : null).GetValueOrDefault())
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		m_PublisherIssuer = nullable_1;
		if (flag)
		{
			m_InstanceClient?.Invoke(Subject, nullable_0, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
		}
	}

	public bool IgnorePlottedCourse_Inherits()
	{
		return !m_PublisherIssuer.HasValue;
	}

	[SpecialName]
	public bool GetIgnorePlottedCourse_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return m_ServerIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetIgnorePlottedCourse_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetIgnorePlottedCourse_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			m_ServerIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetIgnorePlottedCourse_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _BehaviorTowardsTargetAmbiguity? GetBehaviorTowardsAmbigousTarget(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (BehaviorTowardsAmbigousTarget_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetBehaviorTowardsAmbigousTarget(scenario_0, bool_0, bool_1, bool_2);
		}
		return m_PrototypeIssuer.Value;
	}

	[SpecialName]
	public void SetBehaviorTowardsAmbigousTarget(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _BehaviorTowardsTargetAmbiguity? nullable_0)
	{
		m_PrototypeIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool BehaviorTowardsAmbigousTarget_Inherits()
	{
		return !m_PrototypeIssuer.HasValue;
	}

	[SpecialName]
	public bool GetBehaviorTowardsAmbigousTarget_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return comparatorIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetBehaviorTowardsAmbigousTarget_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetBehaviorTowardsAmbigousTarget_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			comparatorIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetBehaviorTowardsAmbigousTarget_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _DamageThreshold? GetWithdrawDamageThreshold(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (WithdrawDamageThreshold_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetWithdrawDamageThreshold(scenario_0, bool_0, bool_1, bool_2);
		}
		return structClient.Value;
	}

	[SpecialName]
	public void SetWithdrawDamageThreshold(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _DamageThreshold? nullable_0)
	{
		structClient = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool WithdrawDamageThreshold_Inherits()
	{
		return !structClient.HasValue;
	}

	[SpecialName]
	public _FuelQuantityThreshold? GetWithdrawFuelThreshold(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (WithdrawFuelThreshold_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetWithdrawFuelThreshold(scenario_0, bool_0, bool_1, bool_2);
		}
		return m_MerchantClient.Value;
	}

	[SpecialName]
	public void SetWithdrawFuelThreshold(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _FuelQuantityThreshold? nullable_0)
	{
		m_MerchantClient = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool WithdrawFuelThreshold_Inherits()
	{
		return !m_MerchantClient.HasValue;
	}

	[SpecialName]
	public _WeaponQuantityThreshold? GetWithdrawAttackThreshold(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (WithdrawAttackThreshold_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetWithdrawAttackThreshold(scenario_0, bool_0, bool_1, bool_2);
		}
		return callbackClient.Value;
	}

	[SpecialName]
	public void SetWithdrawAttackThreshold(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _WeaponQuantityThreshold? nullable_0)
	{
		callbackClient = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool WithdrawAttackThreshold_Inherits()
	{
		return !callbackClient.HasValue;
	}

	[SpecialName]
	public _WeaponQuantityThreshold? GetWithdrawDefenceThreshold(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (WithdrawDefenceThreshold_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetWithdrawDefenceThreshold(scenario_0, bool_0, bool_1, bool_2);
		}
		return _DecoratorClient.Value;
	}

	[SpecialName]
	public void SetWithdrawDefenceThreshold(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _WeaponQuantityThreshold? nullable_0)
	{
		_DecoratorClient = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool WithdrawDefenceThreshold_Inherits()
	{
		return !_DecoratorClient.HasValue;
	}

	[SpecialName]
	public _DamageThreshold? GetRedeployDamageThreshold(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (RedeployDamageThreshold_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetRedeployDamageThreshold(scenario_0, bool_0, bool_1, bool_2);
		}
		return _ProcessClient.Value;
	}

	[SpecialName]
	public void SetRedeployDamageThreshold(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _DamageThreshold? nullable_0)
	{
		_ProcessClient = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool RedeployDamageThreshold_Inherits()
	{
		return !_ProcessClient.HasValue;
	}

	[SpecialName]
	public _FuelQuantityThreshold? GetRedeployFuelThreshold(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (RedeployFuelThreshold_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetRedeployFuelThreshold(scenario_0, bool_0, bool_1, bool_2);
		}
		return threadClient.Value;
	}

	[SpecialName]
	public void SetRedeployFuelThreshold(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _FuelQuantityThreshold? nullable_0)
	{
		threadClient = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool RedeployFuelThreshold_Inherits()
	{
		return !threadClient.HasValue;
	}

	[SpecialName]
	public _WeaponQuantityThreshold? GetRedeployAttackThreshold(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (RedeployAttackThreshold_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetRedeployAttackThreshold(scenario_0, bool_0, bool_1, bool_2);
		}
		return _RuleClient.Value;
	}

	[SpecialName]
	public void SetRedeployAttackThreshold(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _WeaponQuantityThreshold? nullable_0)
	{
		_RuleClient = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool RedeployAttackThreshold_Inherits()
	{
		return !_RuleClient.HasValue;
	}

	[SpecialName]
	public _WeaponQuantityThreshold? GetRedeployDefenceThreshold(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (RedeployDefenceThreshold_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetRedeployDefenceThreshold(scenario_0, bool_0, bool_1, bool_2);
		}
		return m_CollectionClient.Value;
	}

	[SpecialName]
	public void SetRedeployDefenceThreshold(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _WeaponQuantityThreshold? nullable_0)
	{
		m_CollectionClient = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool RedeployDefenceThreshold_Inherits()
	{
		return !m_CollectionClient.HasValue;
	}

	[SpecialName]
	public _WeaponStateRTB? GetWinchesterShotgunRTB(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (WinchesterShotgunRTB_Inherits())
			{
				bool bool_3 = true;
				return GetParentDoctrine(scenario_0, ref bool_3).GetWinchesterShotgunRTB(scenario_0, bool_0, bool_1, bool_2);
			}
			return m_UtilsIssuer.Value;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	[SpecialName]
	public void SetWinchesterShotgunRTB(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _WeaponStateRTB? nullable_0)
	{
		m_UtilsIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool WinchesterShotgunRTB_Inherits()
	{
		return !m_UtilsIssuer.HasValue;
	}

	[SpecialName]
	public bool GetWinchesterShotgunRTB_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return _PredicateIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetWinchesterShotgunRTB_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetWinchesterShotgunRTB_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			_PredicateIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetWinchesterShotgunRTB_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _FuelStateRTB? GetBingoJokerRTB(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (BingoJokerRTB_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetBingoJokerRTB(scenario_0, bool_0, bool_1, bool_2);
		}
		return m_SingletonIssuer.Value;
	}

	[SpecialName]
	public void SetBingoJokerRTB(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _FuelStateRTB? nullable_0)
	{
		m_SingletonIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool BingoJokerRTB_Inherits()
	{
		return !m_SingletonIssuer.HasValue;
	}

	[SpecialName]
	public bool GetBingoJokerRTB_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return _RecordIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetBingoJokerRTB_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetBingoJokerRTB_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			_RecordIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetBingoJokerRTB_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _JettisonOrdnance? GetJettison(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (JettisonOrdnance_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetJettison(scenario_0, bool_0, bool_1, bool_2);
		}
		return _ExceptionIssuer.Value;
	}

	[SpecialName]
	public void SetJettison(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _JettisonOrdnance? nullable_0)
	{
		_ExceptionIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool JettisonOrdnance_Inherits()
	{
		return !_ExceptionIssuer.HasValue;
	}

	[SpecialName]
	public bool GetJettisonOrdnance_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return attrIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetJettisonOrdnance_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetJettisonOrdnance_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			attrIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetJettisonOrdnance_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _BVRLogicEnum? method_0(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (BVRLogic_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).method_0(scenario_0, bool_0, bool_1, bool_2);
		}
		return visitorIssuer.Value;
	}

	[SpecialName]
	public void method_1(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _BVRLogicEnum? nullable_0)
	{
		visitorIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool BVRLogic_Inherits()
	{
		return !visitorIssuer.HasValue;
	}

	[SpecialName]
	public bool GetBVRLogic_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return exporterIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetBVRLogic_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetBVRLogic_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			exporterIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetBVRLogic_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _UseAutoEvade? GetAutoEvade(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (AutoEvade_Inherits())
			{
				bool bool_3 = true;
				return GetParentDoctrine(scenario_0, ref bool_3).GetAutoEvade(scenario_0, bool_0, bool_1, bool_2);
			}
			return _ItemIssuer.Value;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	[SpecialName]
	public void SetAutoEvade(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _UseAutoEvade? nullable_0)
	{
		_ItemIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool AutoEvade_Inherits()
	{
		return !_ItemIssuer.HasValue;
	}

	[SpecialName]
	public bool GetAutoEvade_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return _SetterIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetAutoEvade_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetAutoEvade_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			_SetterIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetAutoEvade_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _UseMaintainStandoff? GetMaintainStandoff(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (MaintainStandoff_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetMaintainStandoff(scenario_0, bool_0, bool_1, bool_2);
		}
		return creatorIssuer.Value;
	}

	[SpecialName]
	public void SetMaintainStandoff(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _UseMaintainStandoff? nullable_0)
	{
		creatorIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool MaintainStandoff_Inherits()
	{
		return !creatorIssuer.HasValue;
	}

	[SpecialName]
	public bool GetMaintainStandoff_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return templateIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetMaintainStandoff_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetMaintainStandoff_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			templateIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetMaintainStandoff_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _GunStrafeGroundTargets? GetGunStrafing(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (GunStrafing_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetGunStrafing(scenario_0, bool_0, bool_1, bool_2);
		}
		return indexerIssuer.Value;
	}

	[SpecialName]
	public void SetGunStrafing(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _GunStrafeGroundTargets? nullable_0)
	{
		indexerIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool GunStrafing_Inherits()
	{
		return !indexerIssuer.HasValue;
	}

	[SpecialName]
	public bool GetGunStrafing_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return m_ResolverIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetGunStrafing_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetGunStrafing_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			m_ResolverIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetGunStrafing_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _UseUnderwayRefuelAndReplenishment? GetUseReplenishment(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3)
	{
		if (UseReplenishment_Inherits())
		{
			bool bool_4 = true;
			return GetParentDoctrine(scenario_0, ref bool_4).GetUseReplenishment(scenario_0, bool_0, bool_1, bool_2, bool_3);
		}
		return paramIssuer.Value;
	}

	[SpecialName]
	public void SetUseReplenishment(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3, _UseUnderwayRefuelAndReplenishment? nullable_0)
	{
		paramIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, bool_3);
	}

	public bool UseReplenishment_Inherits()
	{
		return !paramIssuer.HasValue;
	}

	[SpecialName]
	public bool GetUseReplenishment_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return m_PageIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetUseReplenishment_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetUseReplenishment_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			m_PageIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetUseReplenishment_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _UnderwayRefuelAndReplenishmentSelection? GetReplenishmentSelection(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3)
	{
		if (ReplenishmentSelection_Inherits())
		{
			bool bool_4 = true;
			return GetParentDoctrine(scenario_0, ref bool_4).GetReplenishmentSelection(scenario_0, bool_0, bool_1, bool_2, bool_3);
		}
		return rulesIssuer.Value;
	}

	[SpecialName]
	public void SetReplenishmentSelection(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3, _UnderwayRefuelAndReplenishmentSelection? nullable_0)
	{
		rulesIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, bool_3);
	}

	public bool ReplenishmentSelection_Inherits()
	{
		return !rulesIssuer.HasValue;
	}

	[SpecialName]
	public bool GetReplenishmentSelection_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return _MethodIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetReplenishmentSelection_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetReplenishmentSelection_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			_MethodIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetReplenishmentSelection_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _UseShootTourists? GetShootTourists(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (ShootTourists_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetShootTourists(scenario_0, bool_0, bool_1, bool_2);
		}
		return serviceIssuer.Value;
	}

	[SpecialName]
	public void SetShootTourists(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _UseShootTourists? nullable_0)
	{
		serviceIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool ShootTourists_Inherits()
	{
		return !serviceIssuer.HasValue;
	}

	[SpecialName]
	public bool GetShootTourists_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return _SystemIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetShootTourists_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetShootTourists_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			_SystemIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetShootTourists_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _UseSAMsAgainstShips? GetUseSAMsOnASuW(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (UseSAMsOnASuW_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetUseSAMsOnASuW(scenario_0, bool_0, bool_1, bool_2);
		}
		return candidateIssuer.Value;
	}

	[SpecialName]
	public void SetUseSAMsOnASuW(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _UseSAMsAgainstShips? nullable_0)
	{
		candidateIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool UseSAMsOnASuW_Inherits()
	{
		return !candidateIssuer.HasValue;
	}

	[SpecialName]
	public _UseWpMissileAgainstShips? GetUseWPMissileOnASuW(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (UseSAMsOnASuW_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetUseWPMissileOnASuW(scenario_0, bool_0, bool_1, bool_2);
		}
		if (!m_PolicyIssuer.HasValue)
		{
			return _UseWpMissileAgainstShips.No;
		}
		return m_PolicyIssuer.Value;
	}

	[SpecialName]
	public void SetUseWPMissileOnASuW(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _UseWpMissileAgainstShips? nullable_0)
	{
		m_PolicyIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool UseWPMissileOnASuW_Inherits()
	{
		return !m_PolicyIssuer.HasValue;
	}

	[SpecialName]
	public bool GetUseWPMissileOnASuW_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return m_BroadcasterIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetUseWPMissileOnASuW_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetUseWPMissileOnASuW_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			m_BroadcasterIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetUseWPMissileOnASuW_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public bool GetUseSAMsOnASuW_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return baseIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetUseSAMsOnASuW_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetUseSAMsOnASuW_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			baseIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetUseSAMsOnASuW_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _UseIgnoreEMCONunderAttack? GetIgnoreEMCONunderAttack(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (IgnoreEMCONunderAttack_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetIgnoreEMCONunderAttack(scenario_0, bool_0, bool_1, bool_2);
		}
		return m_IdentifierIssuer.Value;
	}

	[SpecialName]
	public void SetIgnoreEMCONunderAttack(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _UseIgnoreEMCONunderAttack? nullable_0)
	{
		m_IdentifierIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool IgnoreEMCONunderAttack_Inherits()
	{
		return !m_IdentifierIssuer.HasValue;
	}

	[SpecialName]
	public bool GetIgnoreEMCONunderAttack_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return printerIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetIgnoreEMCONunderAttack_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetIgnoreEMCONunderAttack_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			printerIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetIgnoreEMCONunderAttack_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _NavigationMethod? GetSurfaceNavigation(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (SurfaceNavigation_Inherits())
			{
				bool bool_3 = true;
				return GetParentDoctrine(scenario_0, ref bool_3).GetSurfaceNavigation(scenario_0, bool_0, bool_1, bool_2);
			}
			return _MappingIssuer.Value;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[SpecialName]
	public void SetSurfaceNavigation(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _NavigationMethod? nullable_0)
	{
		_MappingIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool SurfaceNavigation_Inherits()
	{
		return !_MappingIssuer.HasValue;
	}

	[SpecialName]
	public bool GetSurfaceNavigation_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return mockIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetSurfaceNavigation_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetSurfaceNavigation_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			mockIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetSurfaceNavigation_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _NavigationMethod? GetSubmarineNavigation(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (SubmarineNavigation_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetSubmarineNavigation(scenario_0, bool_0, bool_1, bool_2);
		}
		return _TagIssuer.Value;
	}

	[SpecialName]
	public void SetSubmarineNavigation(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _NavigationMethod? nullable_0)
	{
		_TagIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool SubmarineNavigation_Inherits()
	{
		return !_TagIssuer.HasValue;
	}

	[SpecialName]
	public bool GetSubmarineNavigation_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return m_FieldIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetSubmarineNavigation_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetSubmarineNavigation_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			m_FieldIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetSubmarineNavigation_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _NavigationMethod? GetLandNavigation(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (LandNavigation_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetLandNavigation(scenario_0, bool_0, bool_1, bool_2);
		}
		return m_QueueIssuer.Value;
	}

	[SpecialName]
	public void SetLandNavigation(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _NavigationMethod? nullable_0)
	{
		m_QueueIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool LandNavigation_Inherits()
	{
		return !m_QueueIssuer.HasValue;
	}

	[SpecialName]
	public bool GetLandNavigation_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return _RegIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetLandNavigation_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetLandNavigation_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			_RegIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetLandNavigation_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public bool GetIsShotgunSingleEngagment(Scenario scenario_0)
	{
		_WeaponState? winchesterShotgun = GetWinchesterShotgun(scenario_0, bool_0: false, bool_1: true, bool_2: false, bool_3: false);
		int? num = (int?)winchesterShotgun;
		bool? flag = (num.HasValue ? new bool?(num.GetValueOrDefault() == 5001) : null);
		num = (int?)winchesterShotgun;
		bool? flag2 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 5021) : null);
		bool? flag3 = (flag.GetValueOrDefault() ? new bool?(true) : ((!flag2.HasValue) ? null : (flag2.GetValueOrDefault() | flag)));
		num = (int?)winchesterShotgun;
		bool? flag4 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 5011) : null);
		bool? flag5 = (flag3.GetValueOrDefault() ? new bool?(true) : ((!flag4.HasValue) ? null : (flag4.GetValueOrDefault() | flag3)));
		num = (int?)winchesterShotgun;
		bool? flag6 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 5012) : null);
		if ((flag5.GetValueOrDefault() ? new bool?(true) : ((!flag6.HasValue) ? null : (flag6.GetValueOrDefault() | flag5))).GetValueOrDefault())
		{
			return true;
		}
		return false;
	}

	public void SetEMCON_Radar(EMCONSettings._EMCONSetting _EMCONSetting_0, Scenario scenario_0)
	{
		if (EMCON_Inherits && !Information.IsNothing(NewRepository(scenario_0)))
		{
			refIssuer = new EMCONSettings(_EMCONSetting_0, NewRepository(scenario_0).GetInterruptibleField(), NewRepository(scenario_0).OECM());
		}
		else if (Information.IsNothing(refIssuer))
		{
			refIssuer = new EMCONSettings(_EMCONSetting_0, EMCONSettings._EMCONSetting.NotConfigured, EMCONSettings._EMCONSetting.NotConfigured);
		}
		else
		{
			refIssuer = new EMCONSettings(_EMCONSetting_0, refIssuer.GetInterruptibleField(), refIssuer.OECM());
		}
	}

	public void SetEMCON_Sonar(EMCONSettings._EMCONSetting _EMCONSetting_0, Scenario scenario_0)
	{
		if (EMCON_Inherits && !Information.IsNothing(NewRepository(scenario_0)))
		{
			refIssuer = new EMCONSettings(NewRepository(scenario_0).LoginInterruptibleField(), _EMCONSetting_0, NewRepository(scenario_0).OECM());
		}
		else if (Information.IsNothing(refIssuer))
		{
			refIssuer = new EMCONSettings(EMCONSettings._EMCONSetting.NotConfigured, _EMCONSetting_0, EMCONSettings._EMCONSetting.NotConfigured);
		}
		else
		{
			refIssuer = new EMCONSettings(refIssuer.LoginInterruptibleField(), _EMCONSetting_0, refIssuer.OECM());
		}
	}

	public void SetEMCON_OECM(EMCONSettings._EMCONSetting _EMCONSetting_0, Scenario scenario_0)
	{
		if (EMCON_Inherits && !Information.IsNothing(NewRepository(scenario_0)))
		{
			refIssuer = new EMCONSettings(NewRepository(scenario_0).LoginInterruptibleField(), NewRepository(scenario_0).GetInterruptibleField(), _EMCONSetting_0);
		}
		else if (Information.IsNothing(refIssuer))
		{
			refIssuer = new EMCONSettings(EMCONSettings._EMCONSetting.NotConfigured, EMCONSettings._EMCONSetting.NotConfigured, _EMCONSetting_0);
		}
		else
		{
			refIssuer = new EMCONSettings(refIssuer.LoginInterruptibleField(), refIssuer.GetInterruptibleField(), _EMCONSetting_0);
		}
	}

	public void SetEMCON(EMCONSettings._EMCONSetting _EMCONSetting_0, EMCONSettings._EMCONSetting _EMCONSetting_1, EMCONSettings._EMCONSetting _EMCONSetting_2)
	{
		refIssuer = new EMCONSettings(_EMCONSetting_0, _EMCONSetting_1, _EMCONSetting_2);
	}

	[SpecialName]
	public _QuickTurnAroundForAicraft? GetQuickTurnAroundForAicraft(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3)
	{
		if (!bool_1)
		{
			ClearCachedParentDoctrine();
		}
		if (QuickTurnAroundForAicraft_Inherits())
		{
			_QuickTurnAroundForAicraft? result = GetParentDoctrine(scenario_0, ref bool_1)?.GetQuickTurnAroundForAicraft(scenario_0, bool_0, bool_1: true, bool_2, bool_3);
			if (!bool_1)
			{
				ClearCachedParentDoctrine();
			}
			return result;
		}
		return parserIssuer.Value;
	}

	[SpecialName]
	public void SetQuickTurnAroundForAicraft(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3, _QuickTurnAroundForAicraft? nullable_0)
	{
		parserIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_2, bool_3, viaFlightPlanEditor: false);
	}

	public bool QuickTurnAroundForAicraft_Inherits()
	{
		return !parserIssuer.HasValue;
	}

	[SpecialName]
	public bool GetQuickTurnAroundForAicraft_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return m_AlgoIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetQuickTurnAroundForAicraft_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetQuickTurnAroundForAicraft_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			m_AlgoIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetQuickTurnAroundForAicraft_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _AirOpsTempo? GetAirOpsTempo(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3)
	{
		if (!bool_1)
		{
			ClearCachedParentDoctrine();
		}
		if (AirOpsTempo_Inherits())
		{
			_AirOpsTempo? result = GetParentDoctrine(scenario_0, ref bool_1)?.GetAirOpsTempo(scenario_0, bool_0, bool_1: true, bool_2, bool_3);
			if (!bool_1)
			{
				ClearCachedParentDoctrine();
			}
			return result;
		}
		return m_DatabaseIssuer.Value;
	}

	[SpecialName]
	public void SetAirOpsTempo(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3, _AirOpsTempo? nullable_0)
	{
		m_DatabaseIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_2, bool_3, viaFlightPlanEditor: false);
	}

	public bool AirOpsTempo_Inherits()
	{
		return !m_DatabaseIssuer.HasValue;
	}

	[SpecialName]
	public bool GetAirOpsTempo_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return m_InterceptorIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetAirOpsTempo_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetAirOpsTempo_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			m_InterceptorIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetAirOpsTempo_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _FuelState? GetBingoJoker(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3)
	{
		try
		{
			if (BingoJoker_Inherits())
			{
				return GetParentDoctrine(scenario_0, ref bool_1)?.GetBingoJoker(scenario_0, bool_0, bool_1: true, bool_2, bool_3);
			}
			return m_MessageIssuer.Value;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	[SpecialName]
	public void SetBingoJoker(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3, _FuelState? nullable_0)
	{
		m_MessageIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_2, bool_3, viaFlightPlanEditor: false);
	}

	public bool BingoJoker_Inherits()
	{
		return !m_MessageIssuer.HasValue;
	}

	[SpecialName]
	public bool GetBingoJoker_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return _ProductIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetBingoJoker_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetBingoJoker_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			_ProductIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetBingoJoker_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _WeaponState? GetWinchesterShotgun(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3)
	{
		if (WinchesterShotgun_Inherits())
		{
			return GetParentDoctrine(scenario_0, ref bool_1)?.GetWinchesterShotgun(scenario_0, bool_0, bool_1: true, bool_2, bool_3);
		}
		return _AnnotationIssuer.Value;
	}

	[SpecialName]
	public void SetWinchesterShotgun(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3, _WeaponState? nullable_0)
	{
		_AnnotationIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_2, bool_3, viaFlightPlanEditor: false);
	}

	public bool WinchesterShotgun_Inherits()
	{
		return !_AnnotationIssuer.HasValue;
	}

	[SpecialName]
	public bool GetWinchesterShotgun_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return iteratorIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetWinchesterShotgun_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetWinchesterShotgun_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			iteratorIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetWinchesterShotgun_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public _UseKinematicRangeForTorpedoes? GetUseKinematicRangeForTorpedoes(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (UseKinematicRangeForTorpedoes_Inherits())
		{
			bool bool_3 = true;
			return GetParentDoctrine(scenario_0, ref bool_3).GetUseKinematicRangeForTorpedoes(scenario_0, bool_0, bool_1, bool_2);
		}
		return m_InitializerIssuer.Value;
	}

	[SpecialName]
	public void SetUseKinematicRangeForTorpedoes(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _UseKinematicRangeForTorpedoes? nullable_0)
	{
		m_InitializerIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool UseKinematicRangeForTorpedoes_Inherits()
	{
		return !m_InitializerIssuer.HasValue;
	}

	[SpecialName]
	public bool GetUseKinematicRangeForTorpedoes_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return _RoleIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetUseKinematicRangeForTorpedoes_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetUseKinematicRangeForTorpedoes_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			_RoleIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetUseKinematicRangeForTorpedoes_PlayerEditable(scenario_0, bool_0);
	}

	public void ComboBoxDataSource_WeaponQty(ref DataTable dataTable_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0, ref Weapon weapon_0, int int_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		int? num = null;
		foreach (KeyValuePair<int, WRA_Weapon> item in weapon_0.Doctrine.WRA)
		{
			_ = item.Key;
			WRA_FiringDoctrineEntry[] wRA_WeaponTargets = item.Value.WRA_WeaponTargets;
			WRA_FiringDoctrineEntry[] array = wRA_WeaponTargets;
			foreach (WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry in array)
			{
				if (wRA_FiringDoctrineEntry.TargetType == _WRA_WeaponTargetType_0)
				{
					num = wRA_FiringDoctrineEntry.WeaponQty;
					break;
				}
			}
		}
		int? nullable_ = null;
		int? nullable_2 = null;
		if ((object)SubjectType == typeof(Side))
		{
			if (!WRA_IsTopNodeTargetType(ref _WRA_WeaponTargetType_0))
			{
				_WRA_WeaponTargetType wRA_WeaponTargetType_ = WRA_DetermineTargetType_Unspecified(ref _WRA_WeaponTargetType_0);
				nullable_2 = WRA_WeaponQty_CurrentTargetType(this, weapon_0.ParentScen, weapon_0, wRA_WeaponTargetType_);
			}
		}
		else
		{
			WRA_WeaponQty_AnyTargetType(this, weapon_0.ParentScen, weapon_0, _WRA_WeaponTargetType_0, bool_0: true, ref nullable_, ref nullable_2);
		}
		switch (_WRA_WeaponTargetType_0)
		{
		case _WRA_WeaponTargetType.Satellite_Unspecified:
			if ((object)SubjectType != typeof(Side))
			{
				if (Information.IsNothing(num))
				{
					if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(0, "Inherited");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(num, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(nullable_, !Information.IsNothing(nullable_2)));
					}
				}
				else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
				{
					dataTable_0.Rows.Add(0, "Inherited");
				}
				else
				{
					dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(nullable_, !Information.IsNothing(nullable_2)));
				}
			}
			if (Information.IsNothing(num))
			{
				if ((object)SubjectType == typeof(Side) && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Satellite_Unspecified)
				{
					if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(1, "未配置");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(1, "未配置，" + WRA_WeaponQtyString(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(1, "未配置，" + WRA_WeaponQtyString(num, !Information.IsNothing(nullable_2)));
					}
				}
			}
			else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2) && (object)SubjectType != typeof(Side))
			{
				dataTable_0.Rows.Add(1, "系统默认");
			}
			else
			{
				dataTable_0.Rows.Add(1, "系统默认，" + WRA_WeaponQtyString(num, bool_0: false));
			}
			dataTable_0.Rows.Add(2, "不要对此目标类型使用武器");
			dataTable_0.Rows.Add(3, "1轮");
			dataTable_0.Rows.Add(4, "2轮");
			dataTable_0.Rows.Add(5, "使用所有武器对抗目标");
			if (int_0 == FillRepository(ref _WRA_WeaponTargetType_0, -100))
			{
				dataTable_0.Rows.Add(6, "各种设置");
			}
			break;
		case _WRA_WeaponTargetType.Air_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Aircraft_Unspecified:
		case _WRA_WeaponTargetType.Aircraft_5th_Generation:
		case _WRA_WeaponTargetType.Aircraft_4th_Generation:
		case _WRA_WeaponTargetType.Aircraft_3rd_Generation:
		case _WRA_WeaponTargetType.Aircraft_Less_Capable:
		case _WRA_WeaponTargetType.Aircraft_High_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_High_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_AEW:
		case _WRA_WeaponTargetType.Aircraft_MicroUAV:
		case _WRA_WeaponTargetType.Aircraft_Tanker:
		case _WRA_WeaponTargetType.Helicopter_Unspecified:
		case _WRA_WeaponTargetType.Guided_Weapon_Unspecified:
		case _WRA_WeaponTargetType.Guided_Weapon_Supersonic_Sea_Skimming:
		case _WRA_WeaponTargetType.Guided_Weapon_Subsonic_Sea_Skimming:
		case _WRA_WeaponTargetType.Guided_Weapon_Supersonic:
		case _WRA_WeaponTargetType.Guided_Weapon_Subsonic:
		case _WRA_WeaponTargetType.Guided_Weapon_Ballistic:
			if ((object)SubjectType != typeof(Side))
			{
				if (Information.IsNothing(num))
				{
					if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(0, "Inherited");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(num, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(nullable_, !Information.IsNothing(nullable_2)));
					}
				}
				else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
				{
					dataTable_0.Rows.Add(0, "Inherited");
				}
				else
				{
					dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(nullable_, !Information.IsNothing(nullable_2)));
				}
			}
			if (Information.IsNothing(num))
			{
				if ((object)SubjectType == typeof(Side) && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Air_Contact_Unknown_Type && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Aircraft_Unspecified)
				{
					if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(1, "未配置");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(1, "未配置，" + WRA_WeaponQtyString(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(1, "未配置，" + WRA_WeaponQtyString(num, !Information.IsNothing(nullable_2)));
					}
				}
			}
			else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2) && (object)SubjectType != typeof(Side))
			{
				dataTable_0.Rows.Add(1, "系统默认");
			}
			else
			{
				dataTable_0.Rows.Add(1, "系统默认，" + WRA_WeaponQtyString(num, bool_0: false));
			}
			dataTable_0.Rows.Add(2, "不要对此目标类型使用武器");
			dataTable_0.Rows.Add(3, "1轮（简易目标，或红外制导武器）");
			dataTable_0.Rows.Add(4, "2轮（非合作目标）");
			dataTable_0.Rows.Add(5, "3轮（非常困难的目标）");
			dataTable_0.Rows.Add(6, "4轮（非常困难的目标，很少使用）");
			dataTable_0.Rows.Add(7, "使用所有武器对抗目标");
			if (int_0 == FillRepository(ref _WRA_WeaponTargetType_0, -100))
			{
				dataTable_0.Rows.Add(8, "各种设置");
			}
			break;
		case _WRA_WeaponTargetType.Ship_Unspecified:
		case _WRA_WeaponTargetType.Ship_Carrier_0_25000_tons:
		case _WRA_WeaponTargetType.Ship_Carrier_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Carrier_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Carrier_95000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_95000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_95000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_95000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_95000_tons:
		case _WRA_WeaponTargetType.Submarine_Surfaced:
			if ((object)SubjectType != typeof(Side))
			{
				if (Information.IsNothing(num))
				{
					if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(0, "Inherited");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(num, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(nullable_, !Information.IsNothing(nullable_2)));
					}
				}
				else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
				{
					dataTable_0.Rows.Add(0, "Inherited");
				}
				else
				{
					dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(nullable_, !Information.IsNothing(nullable_2)));
				}
			}
			if (Information.IsNothing(num))
			{
				if ((object)SubjectType == typeof(Side) && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Ship_Unspecified)
				{
					if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(1, "未配置");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(1, "未配置，" + WRA_WeaponQtyString(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(1, "未配置，" + WRA_WeaponQtyString(num, !Information.IsNothing(nullable_2)));
					}
				}
			}
			else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2) && (object)SubjectType != typeof(Side))
			{
				dataTable_0.Rows.Add(1, "系统默认");
			}
			else
			{
				dataTable_0.Rows.Add(1, "系统默认，" + WRA_WeaponQtyString(num, bool_0: false));
			}
			dataTable_0.Rows.Add(2, "不要对此目标类型使用武器");
			dataTable_0.Rows.Add(3, "使用目标的导弹防御值");
			dataTable_0.Rows.Add(4, "使用两倍于目标的导弹防御值的武器");
			dataTable_0.Rows.Add(5, "使用目标的导弹防御值的四倍");
			dataTable_0.Rows.Add(6, "使用目标导弹防御能力的1/2");
			dataTable_0.Rows.Add(7, "使用目标导弹防御能力的1/4");
			dataTable_0.Rows.Add(8, "1轮");
			dataTable_0.Rows.Add(9, "2轮");
			dataTable_0.Rows.Add(10, "3轮");
			dataTable_0.Rows.Add(11, "4轮");
			dataTable_0.Rows.Add(12, "5轮");
			dataTable_0.Rows.Add(13, "6轮");
			dataTable_0.Rows.Add(14, "7轮");
			dataTable_0.Rows.Add(15, "8轮");
			dataTable_0.Rows.Add(16, "使用所有武器对抗目标");
			if (int_0 == FillRepository(ref _WRA_WeaponTargetType_0, -100))
			{
				dataTable_0.Rows.Add(17, "各种设置");
			}
			break;
		case _WRA_WeaponTargetType.Surface_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Land_Contact_Unknown_Type:
			if ((object)SubjectType != typeof(Side))
			{
				if (Information.IsNothing(num))
				{
					if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(0, "Inherited");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(num, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(nullable_, !Information.IsNothing(nullable_2)));
					}
				}
				else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
				{
					dataTable_0.Rows.Add(0, "Inherited");
				}
				else
				{
					dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(nullable_, !Information.IsNothing(nullable_2)));
				}
			}
			if (Information.IsNothing(num))
			{
				if ((object)SubjectType == typeof(Side) && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Surface_Contact_Unknown_Type && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Land_Contact_Unknown_Type)
				{
					if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(1, "未配置");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(1, "未配置，" + WRA_WeaponQtyString(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(1, "未配置，" + WRA_WeaponQtyString(num, !Information.IsNothing(nullable_2)));
					}
				}
			}
			else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2) && (object)SubjectType != typeof(Side))
			{
				dataTable_0.Rows.Add(1, "系统默认");
			}
			else
			{
				dataTable_0.Rows.Add(1, "系统默认，" + WRA_WeaponQtyString(num, bool_0: false));
			}
			dataTable_0.Rows.Add(2, "不要对此目标类型使用武器");
			dataTable_0.Rows.Add(3, "1轮");
			dataTable_0.Rows.Add(4, "2轮");
			dataTable_0.Rows.Add(5, "3轮");
			dataTable_0.Rows.Add(6, "4轮");
			dataTable_0.Rows.Add(7, "5轮");
			dataTable_0.Rows.Add(8, "6轮");
			dataTable_0.Rows.Add(9, "7轮");
			dataTable_0.Rows.Add(10, "8轮");
			dataTable_0.Rows.Add(11, "使用所有武器对抗目标");
			if (int_0 == FillRepository(ref _WRA_WeaponTargetType_0, -100))
			{
				dataTable_0.Rows.Add(12, "各种设置");
			}
			break;
		case _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Submarine_Unspecified:
			if ((object)SubjectType != typeof(Side))
			{
				if (Information.IsNothing(num))
				{
					if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(0, "Inherited");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(num, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(nullable_, !Information.IsNothing(nullable_2)));
					}
				}
				else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
				{
					dataTable_0.Rows.Add(0, "Inherited");
				}
				else
				{
					dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(nullable_, !Information.IsNothing(nullable_2)));
				}
			}
			if (Information.IsNothing(num))
			{
				if ((object)SubjectType == typeof(Side) && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Submarine_Unspecified && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type)
				{
					if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(1, "未配置");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(1, "未配置，" + WRA_WeaponQtyString(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(1, "未配置，" + WRA_WeaponQtyString(num, !Information.IsNothing(nullable_2)));
					}
				}
			}
			else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2) && (object)SubjectType != typeof(Side))
			{
				dataTable_0.Rows.Add(1, "系统默认");
			}
			else
			{
				dataTable_0.Rows.Add(1, "系统默认，" + WRA_WeaponQtyString(num, bool_0: false));
			}
			dataTable_0.Rows.Add(2, "不要对此目标类型使用武器");
			dataTable_0.Rows.Add(3, "1轮");
			dataTable_0.Rows.Add(4, "2轮");
			dataTable_0.Rows.Add(5, "3轮");
			dataTable_0.Rows.Add(6, "4轮");
			dataTable_0.Rows.Add(7, "使用所有武器对抗目标");
			if (int_0 == FillRepository(ref _WRA_WeaponTargetType_0, -100))
			{
				dataTable_0.Rows.Add(8, "各种设置");
			}
			break;
		default:
			dataTable_0.Rows.Add(0, "未实现");
			break;
		case _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Surface:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Reveted:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Open:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Reveted:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Aerostat_Moring:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Surface:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Reveted:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Bunker:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Underground:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Open:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Reveted:
		case _WRA_WeaponTargetType.Runway_Facility_Unspecified:
		case _WRA_WeaponTargetType.Runway:
		case _WRA_WeaponTargetType.Runway_Grade_Taxiway:
		case _WRA_WeaponTargetType.Runway_Access_Point:
		case _WRA_WeaponTargetType.Radar_Unspecified:
		case _WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified:
		case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Vehicle:
		case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel:
		case _WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified:
		case _WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle:
		case _WRA_WeaponTargetType.Underwater_Structure:
		case _WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield:
			if ((object)SubjectType != typeof(Side))
			{
				if (Information.IsNothing(num))
				{
					if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(0, "Inherited");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(num, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(nullable_, !Information.IsNothing(nullable_2)));
					}
				}
				else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
				{
					dataTable_0.Rows.Add(0, "Inherited");
				}
				else
				{
					dataTable_0.Rows.Add(0, "继承，" + WRA_WeaponQtyString(nullable_, !Information.IsNothing(nullable_2)));
				}
			}
			if (Information.IsNothing(num))
			{
				if ((object)SubjectType == typeof(Side) && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Runway_Facility_Unspecified && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Radar_Unspecified && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Underwater_Structure && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield)
				{
					if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(1, "未配置");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(1, "未配置，" + WRA_WeaponQtyString(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(1, "未配置，" + WRA_WeaponQtyString(num, !Information.IsNothing(nullable_2)));
					}
				}
			}
			else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2) && (object)SubjectType != typeof(Side))
			{
				dataTable_0.Rows.Add(1, "系统默认");
			}
			else
			{
				dataTable_0.Rows.Add(1, "系统默认，" + WRA_WeaponQtyString(num, bool_0: false));
			}
			dataTable_0.Rows.Add(2, "不要对此目标类型使用武器");
			dataTable_0.Rows.Add(3, "使用目标的导弹防御值");
			dataTable_0.Rows.Add(4, "使用两倍于目标的导弹防御值的武器");
			dataTable_0.Rows.Add(5, "使用目标的导弹防御值的四倍");
			dataTable_0.Rows.Add(6, "使用目标导弹防御能力的1/2");
			dataTable_0.Rows.Add(7, "使用目标导弹防御能力的1/4");
			dataTable_0.Rows.Add(8, "1轮");
			dataTable_0.Rows.Add(9, "2轮");
			dataTable_0.Rows.Add(10, "3轮");
			dataTable_0.Rows.Add(11, "4轮");
			dataTable_0.Rows.Add(12, "5轮");
			dataTable_0.Rows.Add(13, "6轮");
			dataTable_0.Rows.Add(14, "7轮");
			dataTable_0.Rows.Add(15, "8轮");
			dataTable_0.Rows.Add(16, "使用所有武器对抗目标");
			if (int_0 == FillRepository(ref _WRA_WeaponTargetType_0, -100))
			{
				dataTable_0.Rows.Add(17, "各种设置");
			}
			break;
		}
	}

	public void ComboBoxDataSource_ShooterQty(ref DataTable dataTable_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0, ref Weapon weapon_0, int int_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		int? num = null;
		foreach (KeyValuePair<int, WRA_Weapon> item in weapon_0.Doctrine.WRA)
		{
			_ = item.Key;
			WRA_FiringDoctrineEntry[] wRA_WeaponTargets = item.Value.WRA_WeaponTargets;
			WRA_FiringDoctrineEntry[] array = wRA_WeaponTargets;
			foreach (WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry in array)
			{
				if (wRA_FiringDoctrineEntry.TargetType == _WRA_WeaponTargetType_0)
				{
					num = wRA_FiringDoctrineEntry.ShooterQty;
					break;
				}
			}
		}
		int? nullable_ = null;
		int? nullable_2 = null;
		if ((object)SubjectType == typeof(Side))
		{
			if (!WRA_IsTopNodeTargetType(ref _WRA_WeaponTargetType_0))
			{
				_WRA_WeaponTargetType wRA_WeaponTargetType_ = WRA_DetermineTargetType_Unspecified(ref _WRA_WeaponTargetType_0);
				nullable_2 = WRA_ShooterQty_CurrentTargetType(this, weapon_0.ParentScen, weapon_0, wRA_WeaponTargetType_);
			}
		}
		else
		{
			WRA_ShooterQty_AnyTargetType(this, weapon_0.ParentScen, weapon_0, _WRA_WeaponTargetType_0, bool_0: true, ref nullable_, ref nullable_2);
		}
		if ((object)SubjectType != typeof(Side))
		{
			if (Information.IsNothing(num))
			{
				if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
				{
					dataTable_0.Rows.Add(0, "Inherited");
				}
				else if (Information.IsNothing(nullable_))
				{
					dataTable_0.Rows.Add(0, "继承，" + WRA_ShooterQtyString(nullable_2, !Information.IsNothing(nullable_2)));
				}
				else if (Information.IsNothing(nullable_))
				{
					dataTable_0.Rows.Add(0, "继承，" + WRA_ShooterQtyString(num, !Information.IsNothing(nullable_2)));
				}
				else
				{
					dataTable_0.Rows.Add(0, "继承，" + WRA_ShooterQtyString(nullable_, !Information.IsNothing(nullable_2)));
				}
			}
			else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
			{
				dataTable_0.Rows.Add(0, "Inherited");
			}
			else
			{
				dataTable_0.Rows.Add(0, "继承，" + WRA_ShooterQtyString(nullable_, !Information.IsNothing(nullable_2)));
			}
		}
		if (Information.IsNothing(num))
		{
			if ((object)SubjectType == typeof(Side) && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Air_Contact_Unknown_Type && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Aircraft_Unspecified)
			{
				if (!Information.IsNothing(nullable_) && !Information.IsNothing(nullable_2))
				{
					dataTable_0.Rows.Add(1, "未配置");
				}
				else if (Information.IsNothing(nullable_))
				{
					dataTable_0.Rows.Add(1, "未配置，" + WRA_ShooterQtyString(nullable_2, !Information.IsNothing(nullable_2)));
				}
				else
				{
					dataTable_0.Rows.Add(1, "未配置，" + WRA_ShooterQtyString(num, !Information.IsNothing(nullable_2)));
				}
			}
		}
		else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2) && (object)SubjectType != typeof(Side))
		{
			dataTable_0.Rows.Add(1, "系统默认");
		}
		else
		{
			dataTable_0.Rows.Add(1, "系统默认，" + WRA_ShooterQtyString(num, bool_0: false));
		}
		dataTable_0.Rows.Add(2, "从足够多的单元选择射击武器来填补齐射的武器数量要求");
		dataTable_0.Rows.Add(3, "1个单元");
		dataTable_0.Rows.Add(4, "2个单元");
		dataTable_0.Rows.Add(5, "4个单元");
		if (int_0 == PopRepository(-100))
		{
			dataTable_0.Rows.Add(6, "各种设置");
		}
	}

	public void ComboBoxDataSource_SelfDefenceRange(ref DataTable dataTable_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0, ref Weapon weapon_0, int int_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		float? num = null;
		foreach (KeyValuePair<int, WRA_Weapon> item in weapon_0.Doctrine.WRA)
		{
			_ = item.Key;
			WRA_FiringDoctrineEntry[] wRA_WeaponTargets = item.Value.WRA_WeaponTargets;
			WRA_FiringDoctrineEntry[] array = wRA_WeaponTargets;
			foreach (WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry in array)
			{
				if (wRA_FiringDoctrineEntry.TargetType == _WRA_WeaponTargetType_0)
				{
					num = wRA_FiringDoctrineEntry.SelfDefenceRange;
					break;
				}
			}
		}
		float? nullable_ = null;
		float? nullable_2 = null;
		if ((object)SubjectType == typeof(Side))
		{
			if (!WRA_IsTopNodeTargetType(ref _WRA_WeaponTargetType_0))
			{
				_WRA_WeaponTargetType wRA_WeaponTargetType_ = WRA_DetermineTargetType_Unspecified(ref _WRA_WeaponTargetType_0);
				nullable_2 = WRA_SelfDefenceRange_CurrentTargetType(this, weapon_0.ParentScen, weapon_0, wRA_WeaponTargetType_);
			}
		}
		else
		{
			SetupRepository(this, weapon_0.ParentScen, weapon_0, _WRA_WeaponTargetType_0, bool_0: true, ref nullable_, ref nullable_2);
		}
		switch (_WRA_WeaponTargetType_0)
		{
		case _WRA_WeaponTargetType.Satellite_Unspecified:
			if ((object)SubjectType != typeof(Side))
			{
				if (Information.IsNothing(num))
				{
					if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(0, "Inherited");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + DisableRepository(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + DisableRepository(num, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(0, "继承，" + DisableRepository(nullable_, !Information.IsNothing(nullable_2)));
					}
				}
				else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
				{
					dataTable_0.Rows.Add(0, "Inherited");
				}
				else
				{
					dataTable_0.Rows.Add(0, "继承，" + DisableRepository(nullable_, !Information.IsNothing(nullable_2)));
				}
			}
			if (Information.IsNothing(num))
			{
				if ((object)SubjectType == typeof(Side) && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Satellite_Unspecified)
				{
					if (!Information.IsNothing(nullable_) && !Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(1, "未配置");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(1, "未配置，" + DisableRepository(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(1, "未配置，" + DisableRepository(num, !Information.IsNothing(nullable_2)));
					}
				}
			}
			else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2) && (object)SubjectType != typeof(Side))
			{
				dataTable_0.Rows.Add(1, "系统默认");
			}
			else
			{
				dataTable_0.Rows.Add(1, "系统默认，" + DisableRepository(num, bool_0: false));
			}
			if (int_0 == CreateRepository(ref _WRA_WeaponTargetType_0, -100f))
			{
				dataTable_0.Rows.Add(2, "各种设置");
			}
			break;
		case _WRA_WeaponTargetType.Air_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Aircraft_Unspecified:
		case _WRA_WeaponTargetType.Aircraft_5th_Generation:
		case _WRA_WeaponTargetType.Aircraft_4th_Generation:
		case _WRA_WeaponTargetType.Aircraft_3rd_Generation:
		case _WRA_WeaponTargetType.Aircraft_Less_Capable:
		case _WRA_WeaponTargetType.Aircraft_High_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_High_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_AEW:
		case _WRA_WeaponTargetType.Aircraft_MicroUAV:
		case _WRA_WeaponTargetType.Aircraft_Tanker:
		case _WRA_WeaponTargetType.Helicopter_Unspecified:
		case _WRA_WeaponTargetType.Guided_Weapon_Unspecified:
		case _WRA_WeaponTargetType.Guided_Weapon_Supersonic_Sea_Skimming:
		case _WRA_WeaponTargetType.Guided_Weapon_Subsonic_Sea_Skimming:
		case _WRA_WeaponTargetType.Guided_Weapon_Supersonic:
		case _WRA_WeaponTargetType.Guided_Weapon_Subsonic:
		case _WRA_WeaponTargetType.Guided_Weapon_Ballistic:
			if ((object)SubjectType != typeof(Side))
			{
				if (Information.IsNothing(num))
				{
					if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(0, "Inherited");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + DisableRepository(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + DisableRepository(num, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(0, "继承，" + DisableRepository(nullable_, !Information.IsNothing(nullable_2)));
					}
				}
				else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
				{
					dataTable_0.Rows.Add(0, "Inherited");
				}
				else
				{
					dataTable_0.Rows.Add(0, "继承，" + DisableRepository(nullable_, !Information.IsNothing(nullable_2)));
				}
			}
			if (Information.IsNothing(num))
			{
				if ((object)SubjectType == typeof(Side) && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Air_Contact_Unknown_Type && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Aircraft_Unspecified)
				{
					if (!Information.IsNothing(nullable_) && !Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(1, "未配置");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(1, "未配置，" + DisableRepository(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(1, "未配置，" + DisableRepository(num, !Information.IsNothing(nullable_2)));
					}
				}
			}
			else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2) && (object)SubjectType != typeof(Side))
			{
				dataTable_0.Rows.Add(1, "系统默认");
			}
			else
			{
				dataTable_0.Rows.Add(1, "系统默认，" + DisableRepository(num, bool_0: false));
			}
			dataTable_0.Rows.Add(2, "不要在自卫中使用武器");
			if (weapon_0.MaxAirRange > 2f)
			{
				dataTable_0.Rows.Add(3, "2海里");
			}
			if (weapon_0.MaxAirRange > 5f)
			{
				dataTable_0.Rows.Add(4, "5海里");
			}
			if (weapon_0.MaxAirRange > 10f)
			{
				dataTable_0.Rows.Add(5, "10海里");
			}
			if (weapon_0.MaxAirRange > 15f)
			{
				dataTable_0.Rows.Add(6, "15海里");
			}
			dataTable_0.Rows.Add(7, "最大范围");
			if (int_0 == CreateRepository(ref _WRA_WeaponTargetType_0, -100f))
			{
				dataTable_0.Rows.Add(8, "各种设置");
			}
			break;
		case _WRA_WeaponTargetType.Surface_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Ship_Unspecified:
		case _WRA_WeaponTargetType.Ship_Carrier_0_25000_tons:
		case _WRA_WeaponTargetType.Ship_Carrier_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Carrier_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Carrier_95000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Surface_Combatant_95000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Amphibious_95000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Auxiliary_95000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_0_500_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_501_1500_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_1501_5000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_5001_10000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_10001_25000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_25001_45000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_45001_95000_tons:
		case _WRA_WeaponTargetType.Ship_Merchant_Civilian_95000_tons:
		case _WRA_WeaponTargetType.Submarine_Surfaced:
			if ((object)SubjectType != typeof(Side))
			{
				if (Information.IsNothing(num))
				{
					if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(0, "Inherited");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + DisableRepository(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + DisableRepository(num, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(0, "继承，" + DisableRepository(nullable_, !Information.IsNothing(nullable_2)));
					}
				}
				else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
				{
					dataTable_0.Rows.Add(0, "Inherited");
				}
				else
				{
					dataTable_0.Rows.Add(0, "继承，" + DisableRepository(nullable_, !Information.IsNothing(nullable_2)));
				}
			}
			if (Information.IsNothing(num))
			{
				if ((object)SubjectType == typeof(Side) && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Surface_Contact_Unknown_Type && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Ship_Unspecified)
				{
					if (!Information.IsNothing(nullable_) && !Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(1, "未配置");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(1, "未配置，" + DisableRepository(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(1, "未配置，" + DisableRepository(num, !Information.IsNothing(nullable_2)));
					}
				}
			}
			else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2) && (object)SubjectType != typeof(Side))
			{
				dataTable_0.Rows.Add(1, "系统默认");
			}
			else
			{
				dataTable_0.Rows.Add(1, "系统默认，" + DisableRepository(num, bool_0: false));
			}
			dataTable_0.Rows.Add(2, "不要在自卫中使用武器");
			if (weapon_0.MaxSurfaceRange > 2f)
			{
				dataTable_0.Rows.Add(3, "2海里");
			}
			if (weapon_0.MaxSurfaceRange > 5f)
			{
				dataTable_0.Rows.Add(4, "5海里");
			}
			if (weapon_0.MaxSurfaceRange > 10f)
			{
				dataTable_0.Rows.Add(5, "10海里");
			}
			if (weapon_0.MaxSurfaceRange > 15f)
			{
				dataTable_0.Rows.Add(6, "15海里");
			}
			dataTable_0.Rows.Add(7, "最大范围");
			if (int_0 == CreateRepository(ref _WRA_WeaponTargetType_0, -100f))
			{
				dataTable_0.Rows.Add(8, "各种设置");
			}
			break;
		case _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Submarine_Unspecified:
			if ((object)SubjectType != typeof(Side))
			{
				if (Information.IsNothing(num))
				{
					if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(0, "Inherited");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + DisableRepository(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + DisableRepository(num, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(0, "继承，" + DisableRepository(nullable_, !Information.IsNothing(nullable_2)));
					}
				}
				else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
				{
					dataTable_0.Rows.Add(0, "Inherited");
				}
				else
				{
					dataTable_0.Rows.Add(0, "继承，" + DisableRepository(nullable_, !Information.IsNothing(nullable_2)));
				}
			}
			if (Information.IsNothing(num))
			{
				if ((object)SubjectType == typeof(Side) && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Submarine_Unspecified)
				{
					if (!Information.IsNothing(nullable_) && !Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(1, "未配置");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(1, "未配置，" + DisableRepository(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(1, "未配置，" + DisableRepository(num, !Information.IsNothing(nullable_2)));
					}
				}
			}
			else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2) && (object)SubjectType != typeof(Side))
			{
				dataTable_0.Rows.Add(1, "系统默认");
			}
			else
			{
				dataTable_0.Rows.Add(1, "系统默认，" + DisableRepository(num, bool_0: false));
			}
			dataTable_0.Rows.Add(2, "不要在自卫中使用武器");
			if (weapon_0.MaxSubsurfaceRange > 2f)
			{
				dataTable_0.Rows.Add(3, "2海里");
			}
			if (weapon_0.MaxSubsurfaceRange > 5f)
			{
				dataTable_0.Rows.Add(4, "5海里");
			}
			if (weapon_0.MaxSubsurfaceRange > 10f)
			{
				dataTable_0.Rows.Add(5, "10海里");
			}
			if (weapon_0.MaxSubsurfaceRange > 15f)
			{
				dataTable_0.Rows.Add(6, "15海里");
			}
			dataTable_0.Rows.Add(7, "最大范围");
			if (int_0 == CreateRepository(ref _WRA_WeaponTargetType_0, -100f))
			{
				dataTable_0.Rows.Add(8, "各种设置");
			}
			break;
		default:
			dataTable_0.Rows.Add(0, "未实现");
			break;
		case _WRA_WeaponTargetType.Land_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Surface:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Reveted:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Open:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Reveted:
		case _WRA_WeaponTargetType.Land_Structure_Soft_Aerostat_Moring:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Surface:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Reveted:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Bunker:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Underground:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Open:
		case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Reveted:
		case _WRA_WeaponTargetType.Runway_Facility_Unspecified:
		case _WRA_WeaponTargetType.Runway:
		case _WRA_WeaponTargetType.Runway_Grade_Taxiway:
		case _WRA_WeaponTargetType.Runway_Access_Point:
		case _WRA_WeaponTargetType.Radar_Unspecified:
		case _WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified:
		case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Vehicle:
		case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel:
		case _WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified:
		case _WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle:
		case _WRA_WeaponTargetType.Underwater_Structure:
		case _WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield:
			if ((object)SubjectType != typeof(Side))
			{
				if (Information.IsNothing(num))
				{
					if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(0, "Inherited");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + DisableRepository(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(0, "继承，" + DisableRepository(num, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(0, "继承，" + DisableRepository(nullable_, !Information.IsNothing(nullable_2)));
					}
				}
				else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
				{
					dataTable_0.Rows.Add(0, "Inherited");
				}
				else
				{
					dataTable_0.Rows.Add(0, "继承，" + DisableRepository(nullable_, !Information.IsNothing(nullable_2)));
				}
			}
			if (Information.IsNothing(num))
			{
				if ((object)SubjectType == typeof(Side) && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Land_Contact_Unknown_Type && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Underwater_Structure && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Runway_Facility_Unspecified && _WRA_WeaponTargetType_0 != _WRA_WeaponTargetType.Radar_Unspecified)
				{
					if (!Information.IsNothing(nullable_) && !Information.IsNothing(nullable_2))
					{
						dataTable_0.Rows.Add(1, "未配置");
					}
					else if (Information.IsNothing(nullable_))
					{
						dataTable_0.Rows.Add(1, "未配置，" + DisableRepository(nullable_2, !Information.IsNothing(nullable_2)));
					}
					else
					{
						dataTable_0.Rows.Add(1, "未配置，" + DisableRepository(num, !Information.IsNothing(nullable_2)));
					}
				}
			}
			else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2) && (object)SubjectType != typeof(Side))
			{
				dataTable_0.Rows.Add(1, "系统默认");
			}
			else
			{
				dataTable_0.Rows.Add(1, "系统默认，" + DisableRepository(num, bool_0: false));
			}
			dataTable_0.Rows.Add(2, "不要在自卫中使用武器");
			if (weapon_0.MaxLandRange > 2f)
			{
				dataTable_0.Rows.Add(3, "2海里");
			}
			if (weapon_0.MaxLandRange > 5f)
			{
				dataTable_0.Rows.Add(4, "5海里");
			}
			if (weapon_0.MaxLandRange > 10f)
			{
				dataTable_0.Rows.Add(5, "10海里");
			}
			if (weapon_0.MaxLandRange > 15f)
			{
				dataTable_0.Rows.Add(6, "15海里");
			}
			dataTable_0.Rows.Add(7, "最大范围");
			if (int_0 == CreateRepository(ref _WRA_WeaponTargetType_0, -100f))
			{
				dataTable_0.Rows.Add(8, "各种设置");
			}
			break;
		}
	}

	public void ComboBoxDataSource_FiringRange(ref DataTable dataTable_0, _WRA_WeaponTargetType _WRA_WeaponTargetType_0, ref Weapon weapon_0, int int_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		float? num = WRA_FiringRange_GetDefaultFiringRange(weapon_0.ParentScen, weapon_0.DBID, _WRA_WeaponTargetType_0);
		float? nullable_ = null;
		float? nullable_2 = null;
		float? num2 = null;
		if ((object)SubjectType == typeof(Side))
		{
			if (WRA_IsTopNodeTargetType(ref _WRA_WeaponTargetType_0))
			{
				num2 = num;
			}
			else
			{
				_WRA_WeaponTargetType wRA_WeaponTargetType_ = WRA_DetermineTargetType_Unspecified(ref _WRA_WeaponTargetType_0);
				nullable_2 = SearchRepository(this, weapon_0.ParentScen, weapon_0.DBID, wRA_WeaponTargetType_);
			}
		}
		else
		{
			IncludeRepository(this, weapon_0.ParentScen, weapon_0.DBID, _WRA_WeaponTargetType_0, bool_0: true, ref nullable_, ref nullable_2);
		}
		if (Information.IsNothing(nullable_2))
		{
			nullable_2 = num;
		}
		if ((object)SubjectType != typeof(Side))
		{
			if (Information.IsNothing(num2))
			{
				if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
				{
					dataTable_0.Rows.Add(0, "Inherited");
				}
				else if (Information.IsNothing(nullable_))
				{
					dataTable_0.Rows.Add(0, "继承，" + UpdateRepository(nullable_2, !Information.IsNothing(nullable_2)));
				}
				else if (Information.IsNothing(nullable_))
				{
					dataTable_0.Rows.Add(0, "继承，" + UpdateRepository(num2, !Information.IsNothing(nullable_2)));
				}
				else
				{
					dataTable_0.Rows.Add(0, "继承，" + UpdateRepository(nullable_, !Information.IsNothing(nullable_2)));
				}
			}
			else if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
			{
				dataTable_0.Rows.Add(0, "Inherited");
			}
			else
			{
				dataTable_0.Rows.Add(0, "继承，" + UpdateRepository(nullable_, !Information.IsNothing(nullable_2)));
			}
		}
		if (Information.IsNothing(num2))
		{
			if ((object)SubjectType == typeof(Side))
			{
				if (Information.IsNothing(nullable_) && Information.IsNothing(nullable_2))
				{
					dataTable_0.Rows.Add(1, "未配置");
				}
				else if (Information.IsNothing(nullable_))
				{
					dataTable_0.Rows.Add(1, "未配置，" + UpdateRepository(nullable_2, !Information.IsNothing(nullable_2)));
				}
				else
				{
					dataTable_0.Rows.Add(1, "未配置，" + UpdateRepository(nullable_, !Information.IsNothing(nullable_2)));
				}
			}
			else
			{
				dataTable_0.Rows.Add(1, "在最大范围内自动开火");
			}
		}
		else if (!Information.IsNothing(nullable_) && !Information.IsNothing(nullable_2) && (object)SubjectType != typeof(Side))
		{
			float? num3 = num;
			if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == -102f) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(1, "系统默认，不可逃逸区NEZ");
			}
			else
			{
				dataTable_0.Rows.Add(1, "系统默认，在最大范围内自动开火");
			}
		}
		else
		{
			dataTable_0.Rows.Add(1, "系统默认，" + UpdateRepository(num2, !Information.IsNothing(nullable_2)));
		}
		dataTable_0.Rows.Add(2, "不自动开火");
		float maxRange_NoTargetType = weapon_0.MaxRange_NoTargetType;
		float minRange_NoTargetType = weapon_0.MinRange_NoTargetType;
		if (maxRange_NoTargetType > 2f && minRange_NoTargetType < 2f)
		{
			dataTable_0.Rows.Add(3, "2海里");
		}
		if (maxRange_NoTargetType > 5f && minRange_NoTargetType < 5f)
		{
			dataTable_0.Rows.Add(4, "5海里");
		}
		if (maxRange_NoTargetType > 10f && minRange_NoTargetType < 10f)
		{
			dataTable_0.Rows.Add(5, "10海里");
		}
		if (maxRange_NoTargetType > 15f && minRange_NoTargetType < 15f)
		{
			dataTable_0.Rows.Add(6, "15海里");
		}
		if (maxRange_NoTargetType > 20f && minRange_NoTargetType < 20f)
		{
			dataTable_0.Rows.Add(7, "20海里");
		}
		if (maxRange_NoTargetType > 25f && minRange_NoTargetType < 25f)
		{
			dataTable_0.Rows.Add(8, "25海里");
		}
		if (maxRange_NoTargetType > 30f && minRange_NoTargetType < 30f)
		{
			dataTable_0.Rows.Add(9, "30海里");
		}
		if (maxRange_NoTargetType > 35f && minRange_NoTargetType < 35f)
		{
			dataTable_0.Rows.Add(10, "35海里");
		}
		if (maxRange_NoTargetType > 40f && minRange_NoTargetType < 40f)
		{
			dataTable_0.Rows.Add(11, "40海里");
		}
		if (maxRange_NoTargetType > 45f && minRange_NoTargetType < 45f)
		{
			dataTable_0.Rows.Add(12, "45海里");
		}
		if (maxRange_NoTargetType > 50f && minRange_NoTargetType < 50f)
		{
			dataTable_0.Rows.Add(13, "50海里");
		}
		if (maxRange_NoTargetType > 60f && minRange_NoTargetType < 60f)
		{
			dataTable_0.Rows.Add(14, "60海里");
		}
		if (maxRange_NoTargetType > 70f && minRange_NoTargetType < 70f)
		{
			dataTable_0.Rows.Add(15, "70海里");
		}
		if (maxRange_NoTargetType > 80f && minRange_NoTargetType < 80f)
		{
			dataTable_0.Rows.Add(16, "80海里");
		}
		if (maxRange_NoTargetType > 90f && minRange_NoTargetType < 90f)
		{
			dataTable_0.Rows.Add(17, "90海里");
		}
		if (maxRange_NoTargetType > 100f && minRange_NoTargetType < 100f)
		{
			dataTable_0.Rows.Add(18, "100海里");
		}
		if (maxRange_NoTargetType > 125f && minRange_NoTargetType < 125f)
		{
			dataTable_0.Rows.Add(19, "125海里");
		}
		if (maxRange_NoTargetType > 150f && minRange_NoTargetType < 150f)
		{
			dataTable_0.Rows.Add(20, "150海里");
		}
		if (maxRange_NoTargetType > 175f && minRange_NoTargetType < 175f)
		{
			dataTable_0.Rows.Add(21, "175海里");
		}
		if (maxRange_NoTargetType > 200f && minRange_NoTargetType < 200f)
		{
			dataTable_0.Rows.Add(22, "200海里");
		}
		if (maxRange_NoTargetType > 250f && minRange_NoTargetType < 250f)
		{
			dataTable_0.Rows.Add(23, "250海里");
		}
		if (maxRange_NoTargetType > 300f && minRange_NoTargetType < 300f)
		{
			dataTable_0.Rows.Add(24, "300海里");
		}
		if (maxRange_NoTargetType > 500f && minRange_NoTargetType < 500f)
		{
			dataTable_0.Rows.Add(25, "500海里");
		}
		if (maxRange_NoTargetType > 750f && minRange_NoTargetType < 750f)
		{
			dataTable_0.Rows.Add(26, "750海里");
		}
		if (maxRange_NoTargetType > 1000f && minRange_NoTargetType < 1000f)
		{
			dataTable_0.Rows.Add(27, "1000海里");
		}
		if (maxRange_NoTargetType > 1500f && minRange_NoTargetType < 1500f)
		{
			dataTable_0.Rows.Add(28, "1500海里");
		}
		if (maxRange_NoTargetType > 2000f && minRange_NoTargetType < 2000f)
		{
			dataTable_0.Rows.Add(29, "2000海里");
		}
		if (maxRange_NoTargetType > 10f)
		{
			minRange_NoTargetType = (int)Math.Round((double)maxRange_NoTargetType * 0.25);
			dataTable_0.Rows.Add(32, "25% of max (" + Conversions.ToString(minRange_NoTargetType) + " 海里）");
			minRange_NoTargetType = (int)Math.Round((double)maxRange_NoTargetType * 0.5);
			dataTable_0.Rows.Add(33, "50% of max (" + Conversions.ToString(minRange_NoTargetType) + " 海里）");
			minRange_NoTargetType = (int)Math.Round((double)maxRange_NoTargetType * 0.75);
			dataTable_0.Rows.Add(34, "75% of max (" + Conversions.ToString(minRange_NoTargetType) + " 海里）");
		}
		if (IsNEZValidTarget(_WRA_WeaponTargetType_0))
		{
			dataTable_0.Rows.Add(35, "不可逃逸区NEZ");
		}
		if (int_0 == ReadRepository(-100f))
		{
			dataTable_0.Rows.Add(30, "各种设置");
		}
	}

	public static bool IsNEZValidTarget(_WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		switch (_WRA_WeaponTargetType_0)
		{
		default:
			return false;
		case _WRA_WeaponTargetType.Air_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Aircraft_Unspecified:
		case _WRA_WeaponTargetType.Aircraft_5th_Generation:
		case _WRA_WeaponTargetType.Aircraft_4th_Generation:
		case _WRA_WeaponTargetType.Aircraft_3rd_Generation:
		case _WRA_WeaponTargetType.Aircraft_Less_Capable:
		case _WRA_WeaponTargetType.Aircraft_High_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_High_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_AEW:
		case _WRA_WeaponTargetType.Aircraft_Tanker:
			return true;
		}
	}

	public static bool smethod_0(_WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		switch (_WRA_WeaponTargetType_0)
		{
		default:
			return false;
		case _WRA_WeaponTargetType.Air_Contact_Unknown_Type:
		case _WRA_WeaponTargetType.Aircraft_Unspecified:
		case _WRA_WeaponTargetType.Aircraft_5th_Generation:
		case _WRA_WeaponTargetType.Aircraft_4th_Generation:
		case _WRA_WeaponTargetType.Aircraft_3rd_Generation:
		case _WRA_WeaponTargetType.Aircraft_Less_Capable:
		case _WRA_WeaponTargetType.Aircraft_High_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers:
		case _WRA_WeaponTargetType.Aircraft_High_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW:
		case _WRA_WeaponTargetType.Aircraft_AEW:
		case _WRA_WeaponTargetType.Aircraft_Tanker:
			return true;
		}
	}

	public static bool IsNEZValidTarget(Weapon weapon_0, Contact contact_0)
	{
		bool? nullable_ = null;
		return smethod_0(WRA_DetermineTargetType(ref contact_0, weapon_0, ref nullable_));
	}

	public static bool isASuWTarget(int int_0)
	{
		if (int_0 != 2999 && int_0 != 2999 && int_0 != 2999 && int_0 != 3000 && int_0 != 3001 && int_0 != 3002 && int_0 != 3003 && int_0 != 3004 && int_0 != 3101 && int_0 != 3102 && int_0 != 3103 && int_0 != 3104 && int_0 != 3105 && int_0 != 3106 && int_0 != 3107 && int_0 != 3108 && int_0 != 3201 && int_0 != 3202 && int_0 != 3203 && int_0 != 3204 && int_0 != 3205 && int_0 != 3206 && int_0 != 3207 && int_0 != 3208 && int_0 != 3301 && int_0 != 3302 && int_0 != 3303 && int_0 != 3304 && int_0 != 3305 && int_0 != 3306 && int_0 != 3307 && int_0 != 3308 && int_0 != 3401 && int_0 != 3402 && int_0 != 3403 && int_0 != 3404 && int_0 != 3405 && int_0 != 3406 && int_0 != 3407 && int_0 != 3408 && int_0 != 3501)
		{
			return false;
		}
		return true;
	}

	public static string WRA_TargetType_String(_WRA_WeaponTargetType _WRA_WeaponTargetType_0, bool bool_0)
	{
		string text = "";
		if (bool_0)
		{
			text = " + Radar";
		}
		return RemoveRepository(_WRA_WeaponTargetType_0) + text;
	}

	private static string RemoveRepository(_WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		if (1 == 0)
		{
		}
		string result = _WRA_WeaponTargetType_0 switch
		{
			_WRA_WeaponTargetType.Aircraft_AEW => "飞机 - 空中预警和控制", 
			_WRA_WeaponTargetType.Aircraft_MicroUAV => "飞机 - 小型无人机", 
			_WRA_WeaponTargetType.Aircraft_Tanker => "飞机 - 加油机", 
			_WRA_WeaponTargetType.Aircraft_High_Perf_Recon_EW => "飞机 - 高性能侦察和电子战飞机", 
			_WRA_WeaponTargetType.Aircraft_Medium_Perf_Recon_EW => "飞机 - 中性能侦察和电子战飞机", 
			_WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW => "飞机 - 低性能侦察和电子战飞机", 
			_WRA_WeaponTargetType.Air_Contact_Unknown_Type => "空中目标 - 未知类型", 
			_WRA_WeaponTargetType.Aircraft_Unspecified => "飞机 - 未指定", 
			_WRA_WeaponTargetType.Aircraft_5th_Generation => "飞机 - 超高机动性战斗机 (F-22, Eurofighter, Su-35)", 
			_WRA_WeaponTargetType.Aircraft_4th_Generation => "飞机 - 高机动性战斗机 (F-14, F-15, F-16, MiG-29, Su-27)", 
			_WRA_WeaponTargetType.Aircraft_3rd_Generation => "飞机 - 机动性增强战斗机 (F-4, F-5, MiG-21, MiG-23)", 
			_WRA_WeaponTargetType.Aircraft_Less_Capable => "飞机 - 低机动性战斗机/攻击机 (F-111, Lightning, Su-7, MiG-17)", 
			_WRA_WeaponTargetType.Aircraft_High_Perf_Bombers => "飞机 - 高性能轰炸机 (B-1B, B-2A, Tu-22M", 
			_WRA_WeaponTargetType.Aircraft_Medium_Perf_Bombers => "飞机 - 中性能轰炸机 (B-52, Vulcan, Tu-16)", 
			_WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers => "飞机 - 低性能轰炸机 (B-24, Canberra, Tu-95, Bison)", 
			_WRA_WeaponTargetType.Guided_Weapon_Ballistic => "引导武器 - 弹道导弹", 
			_WRA_WeaponTargetType.Guided_Weapon_Unspecified => "引导武器 - 未指定", 
			_WRA_WeaponTargetType.Guided_Weapon_Supersonic_Sea_Skimming => "引导武器 - 超音速海掠", 
			_WRA_WeaponTargetType.Guided_Weapon_Subsonic_Sea_Skimming => "引导武器 - 亚音速海掠", 
			_WRA_WeaponTargetType.Guided_Weapon_Supersonic => "引导武器 - 超音速", 
			_WRA_WeaponTargetType.Guided_Weapon_Subsonic => "引导武器 - 亚音速", 
			_WRA_WeaponTargetType.Helicopter_Unspecified => "直升机 - 未指定", 
			_WRA_WeaponTargetType.Surface_Contact_Unknown_Type => "水面目标 - 未知类型", 
			_WRA_WeaponTargetType.Ship_Unspecified => "船 - 未指定", 
			_WRA_WeaponTargetType.Ship_Carrier_0_25000_tons => "船 - 载体，0-25000吨", 
			_WRA_WeaponTargetType.Ship_Carrier_25001_45000_tons => "船 - 承运人，25001-45000吨", 
			_WRA_WeaponTargetType.Ship_Carrier_45001_95000_tons => "船 - 承运人，45001-95000吨", 
			_WRA_WeaponTargetType.Ship_Carrier_95000_tons => "船 - 载体，95000+吨", 
			_WRA_WeaponTargetType.C_RAM => "反火箭炮、火炮和迫击炮", 
			_WRA_WeaponTargetType.Satellite_Unspecified => "卫星 - 未指定", 
			_WRA_WeaponTargetType.Ship_Auxiliary_0_500_tons => "船 - 辅助，0-500吨", 
			_WRA_WeaponTargetType.Ship_Auxiliary_501_1500_tons => "船 - 辅助，501-1500吨", 
			_WRA_WeaponTargetType.Ship_Auxiliary_1501_5000_tons => "船 - 辅助，1501-5000吨", 
			_WRA_WeaponTargetType.Ship_Auxiliary_5001_10000_tons => "船 - 辅助，5001-10000吨", 
			_WRA_WeaponTargetType.Ship_Auxiliary_10001_25000_tons => "船舶 - 辅助，10001-25000吨", 
			_WRA_WeaponTargetType.Ship_Auxiliary_25001_45000_tons => "船舶 - 辅助，25001-45000吨", 
			_WRA_WeaponTargetType.Ship_Auxiliary_45001_95000_tons => "船舶 - 辅助，45001-95000吨", 
			_WRA_WeaponTargetType.Ship_Auxiliary_95000_tons => "船 - 辅助，95000+吨", 
			_WRA_WeaponTargetType.Ship_Amphibious_0_500_tons => "船 - 两栖，0-500吨", 
			_WRA_WeaponTargetType.Ship_Amphibious_501_1500_tons => "船 - 两栖，501-1500吨", 
			_WRA_WeaponTargetType.Ship_Amphibious_1501_5000_tons => "船 - 两栖，1501-5000吨", 
			_WRA_WeaponTargetType.Ship_Amphibious_5001_10000_tons => "船 - 两栖，5001-10000吨", 
			_WRA_WeaponTargetType.Ship_Amphibious_10001_25000_tons => "船 - 两栖，10001-25000吨", 
			_WRA_WeaponTargetType.Ship_Amphibious_25001_45000_tons => "船 - 两栖，25001-45000吨", 
			_WRA_WeaponTargetType.Ship_Amphibious_45001_95000_tons => "船 - 两栖，45001-95000吨", 
			_WRA_WeaponTargetType.Ship_Amphibious_95000_tons => "船 - 两栖，95000 +吨", 
			_WRA_WeaponTargetType.Ship_Surface_Combatant_0_500_tons => "船 - 水面作战，0-500吨", 
			_WRA_WeaponTargetType.Ship_Surface_Combatant_501_1500_tons => "船 - 水面作战，501-1500吨，加上排水量较小的导弹艇", 
			_WRA_WeaponTargetType.Ship_Surface_Combatant_1501_5000_tons => "船 - 水面作战，1501-5000吨，加上少量位移的护卫舰和护卫舰", 
			_WRA_WeaponTargetType.Ship_Surface_Combatant_5001_10000_tons => "船 - 地面作战人员，5001-10000吨，加上排水量较小的驱逐舰", 
			_WRA_WeaponTargetType.Ship_Surface_Combatant_10001_25000_tons => "船 - 水面作战，10001-25000吨，加上小排量的巡洋舰", 
			_WRA_WeaponTargetType.Ship_Surface_Combatant_25001_45000_tons => "船 - 水面作战，25001-45000吨", 
			_WRA_WeaponTargetType.Ship_Surface_Combatant_45001_95000_tons => "船 - 水面作战，45001-95000吨", 
			_WRA_WeaponTargetType.Ship_Surface_Combatant_95000_tons => "船 - 水面作战，95000+吨", 
			_WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type => "次水面目标 - 未知类型", 
			_WRA_WeaponTargetType.Submarine_Surfaced => "船 - 浮出水面潜艇", 
			_WRA_WeaponTargetType.Ship_Merchant_Civilian_0_500_tons => "舰船 - 民用，0-500吨", 
			_WRA_WeaponTargetType.Ship_Merchant_Civilian_501_1500_tons => "舰船 - 民用，501-1500吨", 
			_WRA_WeaponTargetType.Ship_Merchant_Civilian_1501_5000_tons => "舰船 - 民用，1501-5000吨", 
			_WRA_WeaponTargetType.Ship_Merchant_Civilian_5001_10000_tons => "舰船 - 民用，5001-10000吨", 
			_WRA_WeaponTargetType.Ship_Merchant_Civilian_10001_25000_tons => "舰船 - 民用，10001-25000吨", 
			_WRA_WeaponTargetType.Ship_Merchant_Civilian_25001_45000_tons => "舰船 - 民用，25001-45000吨", 
			_WRA_WeaponTargetType.Ship_Merchant_Civilian_45001_95000_tons => "舰船 - 民用，45001-95000吨", 
			_WRA_WeaponTargetType.Ship_Merchant_Civilian_95000_tons => "舰船 - 民用，95000+吨", 
			_WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified => "地面结构 - 硬化 - 未指明", 
			_WRA_WeaponTargetType.Land_Structure_Hardened_Building_Surface => "地面结构 - 硬化 - 建筑（水面）", 
			_WRA_WeaponTargetType.Land_Structure_Hardened_Building_Reveted => "地面结构 - 硬化 - 建筑（遮盖）", 
			_WRA_WeaponTargetType.Land_Structure_Hardened_Building_Bunker => "地面结构 - 硬化 - 建筑（地堡）", 
			_WRA_WeaponTargetType.Land_Structure_Hardened_Building_Underground => "地面结构 - 硬化 - 建筑（地下）", 
			_WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Open => "地面结构 - 硬化 - 结构（露天）", 
			_WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Reveted => "地面结构 - 硬化 - 结构（遮盖）", 
			_WRA_WeaponTargetType.Land_Contact_Unknown_Type => "地面目标 - 未知类型", 
			_WRA_WeaponTargetType.Land_Structure_Soft_Unspecified => "地面结构 - 软 - 未指明", 
			_WRA_WeaponTargetType.Land_Structure_Soft_Building_Surface => "地面结构 - 软建筑（水面）", 
			_WRA_WeaponTargetType.Land_Structure_Soft_Building_Reveted => "地面结构 - 软建筑（遮盖）", 
			_WRA_WeaponTargetType.Land_Structure_Soft_Structure_Open => "地面结构 - 软 - 结构（露天）", 
			_WRA_WeaponTargetType.Land_Structure_Soft_Structure_Reveted => "地面结构 - 软 - 结构（遮盖）", 
			_WRA_WeaponTargetType.Land_Structure_Soft_Aerostat_Moring => "地面结构 - 软 - 浮空器Moring", 
			_WRA_WeaponTargetType.Submarine_Unspecified => "潜艇 - 未指定", 
			_WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified => "移动目标 - 软 - 未指定", 
			_WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Vehicle => "移动目标 - 软 - 移动车辆", 
			_WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel => "移动目标 - 软 - 移动人员", 
			_WRA_WeaponTargetType.Radar_Unspecified => "雷达 - 未指定", 
			_WRA_WeaponTargetType.Runway_Facility_Unspecified => "跑道设施 - 未指定", 
			_WRA_WeaponTargetType.Runway => "Runway", 
			_WRA_WeaponTargetType.Runway_Grade_Taxiway => "跑道级滑行道", 
			_WRA_WeaponTargetType.Runway_Access_Point => "跑道入口", 
			_WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle => "移动目标 - 强化 - 移动车辆", 
			_WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified => "移动目标 - 强化 - 未指定", 
			_WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield => "空军基地（单机场）", 
			_WRA_WeaponTargetType.Underwater_Structure => "水下结构", 
			_ => _WRA_WeaponTargetType_0.ToString(), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static string WRA_WeaponQty_String(int? nullable_0, ActiveUnit activeUnit_0, Contact contact_0, Weapon weapon_0)
	{
		int? num = nullable_0;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -99) : null).GetValueOrDefault())
		{
			return "每次齐射射击所有武器";
		}
		num = nullable_0;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
		{
			return "不要对此目标类型使用武器";
		}
		num = nullable_0;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -2) : null).GetValueOrDefault())
		{
			int? num2 = activeUnit_0.GetUnitSide().ConvertSalvoWeaponQty_To_ActualQuantity(nullable_0, ref activeUnit_0, ref contact_0, ref weapon_0);
			num = num2;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				return (num2.HasValue ? Conversions.ToString(num2.GetValueOrDefault()) : null) + "x 轮每次齐射（使用目标的导弹防御值）";
			}
			return (num2.HasValue ? Conversions.ToString(num2.GetValueOrDefault()) : null) + "x 轮每次齐射（使用目标的导弹防御值）";
		}
		num = nullable_0;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -3) : null).GetValueOrDefault())
		{
			int? num3 = activeUnit_0.GetUnitSide().ConvertSalvoWeaponQty_To_ActualQuantity(nullable_0, ref activeUnit_0, ref contact_0, ref weapon_0);
			num = num3;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				return (num3.HasValue ? Conversions.ToString(num3.GetValueOrDefault()) : null) + "x 轮每次齐射（使用目标的导弹防御值的两倍）";
			}
			return (num3.HasValue ? Conversions.ToString(num3.GetValueOrDefault()) : null) + "x 轮每次齐射（使用目标的导弹防御值的两倍）";
		}
		num = nullable_0;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -4) : null).GetValueOrDefault())
		{
			int? num4 = activeUnit_0.GetUnitSide().ConvertSalvoWeaponQty_To_ActualQuantity(nullable_0, ref activeUnit_0, ref contact_0, ref weapon_0);
			num = num4;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				return (num4.HasValue ? Conversions.ToString(num4.GetValueOrDefault()) : null) + "x 轮每次齐射（使用目标的导弹防御值的四倍）";
			}
			return (num4.HasValue ? Conversions.ToString(num4.GetValueOrDefault()) : null) + "x 轮每次齐射（使用目标的导弹防御值的四倍）";
		}
		num = nullable_0;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -5) : null).GetValueOrDefault())
		{
			int? num5 = activeUnit_0.GetUnitSide().ConvertSalvoWeaponQty_To_ActualQuantity(nullable_0, ref activeUnit_0, ref contact_0, ref weapon_0);
			num = num5;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				return (num5.HasValue ? Conversions.ToString(num5.GetValueOrDefault()) : null) + "x 轮每次齐射（使用目标的导弹防御值的一半）";
			}
			return (num5.HasValue ? Conversions.ToString(num5.GetValueOrDefault()) : null) + "x 轮每次齐射（使用目标的导弹防御值的一半）";
		}
		num = nullable_0;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -6) : null).GetValueOrDefault())
		{
			int? num6 = activeUnit_0.GetUnitSide().ConvertSalvoWeaponQty_To_ActualQuantity(nullable_0, ref activeUnit_0, ref contact_0, ref weapon_0);
			num = num6;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				return (num6.HasValue ? Conversions.ToString(num6.GetValueOrDefault()) : null) + "x 轮每次齐射（使用目标的导弹防御值的四分之一）";
			}
			return (num6.HasValue ? Conversions.ToString(num6.GetValueOrDefault()) : null) + "x 轮每次齐射（使用目标的导弹防御值的四分之一）";
		}
		num = nullable_0;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -98) : null).GetValueOrDefault())
		{
			return "没有定义的";
		}
		num = nullable_0;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -1) : null).GetValueOrDefault())
		{
			int? num7 = activeUnit_0.GetUnitSide().ConvertSalvoWeaponQty_To_ActualQuantity(nullable_0, ref activeUnit_0, ref contact_0, ref weapon_0);
			num = num7;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				return (num7.HasValue ? Conversions.ToString(num7.GetValueOrDefault()) : null) + "x rnd per salvo（使用系统默认值）";
			}
			return (num7.HasValue ? Conversions.ToString(num7.GetValueOrDefault()) : null) + "每次齐射x次（使用系统默认值）";
		}
		num = nullable_0;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -100) : null).GetValueOrDefault())
		{
			return "各种武器数量";
		}
		num = nullable_0;
		(num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault();
		int? num8 = nullable_0;
		return num8 + "x轮每次齐射";
	}

	internal string FindRepository(float? nullable_0)
	{
		if (!nullable_0.HasValue)
		{
			nullable_0 = -99f;
		}
		float? num = nullable_0;
		float? num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
		{
			return "对于此目标类型不自动射击，仅手动射击";
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -99f) : null).GetValueOrDefault())
		{
			return "武器在最大范围内发射";
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -98f) : null).GetValueOrDefault())
		{
			return "没有定义的";
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -100f) : null).GetValueOrDefault())
		{
			return "各种射程";
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -95f) : null).GetValueOrDefault())
		{
			return "25%最大范围";
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -96f) : null).GetValueOrDefault())
		{
			return "50%最大范围";
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -97f) : null).GetValueOrDefault())
		{
			return "75%最大范围";
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -102f) : null).GetValueOrDefault())
		{
			return "不可逃逸区NEZ";
		}
		return (nullable_0.HasValue ? Conversions.ToString(nullable_0.GetValueOrDefault()) : null) + "海里最大射程";
	}

	internal int? SetRepository(ref _WRA_WeaponTargetType _WRA_WeaponTargetType_0, ref object object_0)
	{
		int? result = null;
		try
		{
			switch (_WRA_WeaponTargetType_0)
			{
			case _WRA_WeaponTargetType.Satellite_Unspecified:
				switch (Conversions.ToInteger(object_0))
				{
				default:
					result = null;
					return result;
				case 2:
					result = 0;
					return result;
				case 3:
					result = 1;
					return result;
				case 4:
					result = 2;
					return result;
				case 5:
					result = -99;
					return result;
				case 6:
					result = -100;
					return result;
				}
			case _WRA_WeaponTargetType.Air_Contact_Unknown_Type:
			case _WRA_WeaponTargetType.Aircraft_Unspecified:
			case _WRA_WeaponTargetType.Aircraft_5th_Generation:
			case _WRA_WeaponTargetType.Aircraft_4th_Generation:
			case _WRA_WeaponTargetType.Aircraft_3rd_Generation:
			case _WRA_WeaponTargetType.Aircraft_Less_Capable:
			case _WRA_WeaponTargetType.Aircraft_High_Perf_Bombers:
			case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Bombers:
			case _WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers:
			case _WRA_WeaponTargetType.Aircraft_High_Perf_Recon_EW:
			case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Recon_EW:
			case _WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW:
			case _WRA_WeaponTargetType.Aircraft_AEW:
			case _WRA_WeaponTargetType.Aircraft_MicroUAV:
			case _WRA_WeaponTargetType.Aircraft_Tanker:
			case _WRA_WeaponTargetType.Helicopter_Unspecified:
			case _WRA_WeaponTargetType.Guided_Weapon_Unspecified:
			case _WRA_WeaponTargetType.Guided_Weapon_Supersonic_Sea_Skimming:
			case _WRA_WeaponTargetType.Guided_Weapon_Subsonic_Sea_Skimming:
			case _WRA_WeaponTargetType.Guided_Weapon_Supersonic:
			case _WRA_WeaponTargetType.Guided_Weapon_Subsonic:
			case _WRA_WeaponTargetType.Guided_Weapon_Ballistic:
				switch (Conversions.ToInteger(object_0))
				{
				default:
					result = null;
					return result;
				case 2:
					result = 0;
					return result;
				case 3:
					result = 1;
					return result;
				case 4:
					result = 2;
					return result;
				case 5:
					result = 3;
					return result;
				case 6:
					result = 4;
					return result;
				case 7:
					result = -99;
					return result;
				case 8:
					result = -100;
					return result;
				}
			case _WRA_WeaponTargetType.Ship_Unspecified:
			case _WRA_WeaponTargetType.Ship_Carrier_0_25000_tons:
			case _WRA_WeaponTargetType.Ship_Carrier_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Carrier_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Carrier_95000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_0_500_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_501_1500_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_1501_5000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_5001_10000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_10001_25000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_95000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_0_500_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_501_1500_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_1501_5000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_5001_10000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_10001_25000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_95000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_0_500_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_501_1500_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_1501_5000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_5001_10000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_10001_25000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_95000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_0_500_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_501_1500_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_1501_5000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_5001_10000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_10001_25000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_95000_tons:
			case _WRA_WeaponTargetType.Submarine_Surfaced:
				switch (Conversions.ToInteger(object_0))
				{
				default:
					result = null;
					return result;
				case 2:
					result = 0;
					return result;
				case 3:
					result = -2;
					return result;
				case 4:
					result = -3;
					return result;
				case 5:
					result = -4;
					return result;
				case 6:
					result = -5;
					return result;
				case 7:
					result = -6;
					return result;
				case 8:
					result = 1;
					return result;
				case 9:
					result = 2;
					return result;
				case 10:
					result = 3;
					return result;
				case 11:
					result = 4;
					return result;
				case 12:
					result = 5;
					return result;
				case 13:
					result = 6;
					return result;
				case 14:
					result = 7;
					return result;
				case 15:
					result = 8;
					return result;
				case 16:
					result = -99;
					return result;
				case 17:
					result = -100;
					return result;
				}
			case _WRA_WeaponTargetType.Surface_Contact_Unknown_Type:
			case _WRA_WeaponTargetType.Land_Contact_Unknown_Type:
				switch (Conversions.ToInteger(object_0))
				{
				default:
					result = null;
					return result;
				case 2:
					result = 0;
					return result;
				case 3:
					result = 1;
					return result;
				case 4:
					result = 2;
					return result;
				case 5:
					result = 3;
					return result;
				case 6:
					result = 4;
					return result;
				case 7:
					result = 5;
					return result;
				case 8:
					result = 6;
					return result;
				case 9:
					result = 7;
					return result;
				case 10:
					result = 8;
					return result;
				case 11:
					result = -99;
					return result;
				case 12:
					result = -100;
					return result;
				}
			case _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type:
			case _WRA_WeaponTargetType.Submarine_Unspecified:
				switch (Conversions.ToInteger(object_0))
				{
				default:
					result = null;
					return result;
				case 2:
					result = 0;
					return result;
				case 3:
					result = 1;
					return result;
				case 4:
					result = 2;
					return result;
				case 5:
					result = 3;
					return result;
				case 6:
					result = 4;
					return result;
				case 7:
					result = -99;
					return result;
				case 8:
					result = -100;
					return result;
				}
			default:
				result = 0;
				return result;
			case _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Surface:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Reveted:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Open:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Reveted:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Aerostat_Moring:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Surface:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Reveted:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Bunker:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Underground:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Open:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Reveted:
			case _WRA_WeaponTargetType.Runway_Facility_Unspecified:
			case _WRA_WeaponTargetType.Runway:
			case _WRA_WeaponTargetType.Runway_Grade_Taxiway:
			case _WRA_WeaponTargetType.Runway_Access_Point:
			case _WRA_WeaponTargetType.Radar_Unspecified:
			case _WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified:
			case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Vehicle:
			case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel:
			case _WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified:
			case _WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle:
			case _WRA_WeaponTargetType.Underwater_Structure:
			case _WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield:
				switch (Conversions.ToInteger(object_0))
				{
				default:
					result = null;
					return result;
				case 2:
					result = 0;
					return result;
				case 3:
					result = -2;
					return result;
				case 4:
					result = -3;
					return result;
				case 5:
					result = -4;
					return result;
				case 6:
					result = -5;
					return result;
				case 7:
					result = -6;
					return result;
				case 8:
					result = 1;
					return result;
				case 9:
					result = 2;
					return result;
				case 10:
					result = 3;
					return result;
				case 11:
					result = 4;
					return result;
				case 12:
					result = 5;
					return result;
				case 13:
					result = 6;
					return result;
				case 14:
					result = 7;
					return result;
				case 15:
					result = 8;
					return result;
				case 16:
					result = -99;
					return result;
				case 17:
					result = -100;
					return result;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101197", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal int FillRepository(ref _WRA_WeaponTargetType _WRA_WeaponTargetType_0, int? nullable_0)
	{
		try
		{
			switch (_WRA_WeaponTargetType_0)
			{
			case _WRA_WeaponTargetType.Satellite_Unspecified:
			{
				int? num6 = nullable_0;
				if ((num6.HasValue ? new bool?(num6.GetValueOrDefault() == -1) : null).GetValueOrDefault())
				{
					return 1;
				}
				num6 = nullable_0;
				if ((num6.HasValue ? new bool?(num6.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					return 2;
				}
				num6 = nullable_0;
				if ((num6.HasValue ? new bool?(num6.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					return 3;
				}
				num6 = nullable_0;
				if ((num6.HasValue ? new bool?(num6.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					return 4;
				}
				num6 = nullable_0;
				if ((num6.HasValue ? new bool?(num6.GetValueOrDefault() == -99) : null).GetValueOrDefault())
				{
					return 5;
				}
				num6 = nullable_0;
				if ((num6.HasValue ? new bool?(num6.GetValueOrDefault() == -100) : null).GetValueOrDefault())
				{
					return 6;
				}
				if ((object)SubjectType == typeof(Side))
				{
					return 1;
				}
				return 0;
			}
			case _WRA_WeaponTargetType.Air_Contact_Unknown_Type:
			case _WRA_WeaponTargetType.Aircraft_Unspecified:
			case _WRA_WeaponTargetType.Aircraft_5th_Generation:
			case _WRA_WeaponTargetType.Aircraft_4th_Generation:
			case _WRA_WeaponTargetType.Aircraft_3rd_Generation:
			case _WRA_WeaponTargetType.Aircraft_Less_Capable:
			case _WRA_WeaponTargetType.Aircraft_High_Perf_Bombers:
			case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Bombers:
			case _WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers:
			case _WRA_WeaponTargetType.Aircraft_High_Perf_Recon_EW:
			case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Recon_EW:
			case _WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW:
			case _WRA_WeaponTargetType.Aircraft_AEW:
			case _WRA_WeaponTargetType.Aircraft_MicroUAV:
			case _WRA_WeaponTargetType.Aircraft_Tanker:
			case _WRA_WeaponTargetType.Helicopter_Unspecified:
			case _WRA_WeaponTargetType.Guided_Weapon_Unspecified:
			case _WRA_WeaponTargetType.Guided_Weapon_Supersonic_Sea_Skimming:
			case _WRA_WeaponTargetType.Guided_Weapon_Subsonic_Sea_Skimming:
			case _WRA_WeaponTargetType.Guided_Weapon_Supersonic:
			case _WRA_WeaponTargetType.Guided_Weapon_Subsonic:
			case _WRA_WeaponTargetType.Guided_Weapon_Ballistic:
			{
				int? num4 = nullable_0;
				if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == -1) : null).GetValueOrDefault())
				{
					return 1;
				}
				num4 = nullable_0;
				if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					return 2;
				}
				num4 = nullable_0;
				if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					return 3;
				}
				num4 = nullable_0;
				if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					return 4;
				}
				num4 = nullable_0;
				if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 3) : null).GetValueOrDefault())
				{
					return 5;
				}
				num4 = nullable_0;
				if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 4) : null).GetValueOrDefault())
				{
					return 6;
				}
				num4 = nullable_0;
				if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == -99) : null).GetValueOrDefault())
				{
					return 7;
				}
				num4 = nullable_0;
				if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == -100) : null).GetValueOrDefault())
				{
					return 8;
				}
				if ((object)SubjectType == typeof(Side))
				{
					return 1;
				}
				return 0;
			}
			case _WRA_WeaponTargetType.Ship_Unspecified:
			case _WRA_WeaponTargetType.Ship_Carrier_0_25000_tons:
			case _WRA_WeaponTargetType.Ship_Carrier_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Carrier_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Carrier_95000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_0_500_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_501_1500_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_1501_5000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_5001_10000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_10001_25000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_95000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_0_500_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_501_1500_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_1501_5000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_5001_10000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_10001_25000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_95000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_0_500_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_501_1500_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_1501_5000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_5001_10000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_10001_25000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_95000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_0_500_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_501_1500_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_1501_5000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_5001_10000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_10001_25000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_95000_tons:
			case _WRA_WeaponTargetType.Submarine_Surfaced:
			{
				int? num2 = nullable_0;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -1) : null).GetValueOrDefault())
				{
					return 1;
				}
				num2 = nullable_0;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					return 2;
				}
				num2 = nullable_0;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -2) : null).GetValueOrDefault())
				{
					return 3;
				}
				num2 = nullable_0;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -3) : null).GetValueOrDefault())
				{
					return 4;
				}
				num2 = nullable_0;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -4) : null).GetValueOrDefault())
				{
					return 5;
				}
				num2 = nullable_0;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -5) : null).GetValueOrDefault())
				{
					return 6;
				}
				num2 = nullable_0;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -6) : null).GetValueOrDefault())
				{
					return 7;
				}
				num2 = nullable_0;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					return 8;
				}
				num2 = nullable_0;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					return 9;
				}
				num2 = nullable_0;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 3) : null).GetValueOrDefault())
				{
					return 10;
				}
				num2 = nullable_0;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 4) : null).GetValueOrDefault())
				{
					return 11;
				}
				num2 = nullable_0;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 5) : null).GetValueOrDefault())
				{
					return 12;
				}
				num2 = nullable_0;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 6) : null).GetValueOrDefault())
				{
					return 13;
				}
				num2 = nullable_0;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 7) : null).GetValueOrDefault())
				{
					return 14;
				}
				num2 = nullable_0;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 8) : null).GetValueOrDefault())
				{
					return 15;
				}
				num2 = nullable_0;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -99) : null).GetValueOrDefault())
				{
					return 16;
				}
				num2 = nullable_0;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -100) : null).GetValueOrDefault())
				{
					return 17;
				}
				if ((object)SubjectType == typeof(Side))
				{
					return 1;
				}
				return 0;
			}
			case _WRA_WeaponTargetType.Surface_Contact_Unknown_Type:
			case _WRA_WeaponTargetType.Land_Contact_Unknown_Type:
			{
				int? num3 = nullable_0;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == -1) : null).GetValueOrDefault())
				{
					return 1;
				}
				num3 = nullable_0;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					return 2;
				}
				num3 = nullable_0;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					return 3;
				}
				num3 = nullable_0;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					return 4;
				}
				num3 = nullable_0;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 3) : null).GetValueOrDefault())
				{
					return 5;
				}
				num3 = nullable_0;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 4) : null).GetValueOrDefault())
				{
					return 6;
				}
				num3 = nullable_0;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 5) : null).GetValueOrDefault())
				{
					return 7;
				}
				num3 = nullable_0;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 6) : null).GetValueOrDefault())
				{
					return 8;
				}
				num3 = nullable_0;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 7) : null).GetValueOrDefault())
				{
					return 9;
				}
				num3 = nullable_0;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 8) : null).GetValueOrDefault())
				{
					return 10;
				}
				num3 = nullable_0;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == -99) : null).GetValueOrDefault())
				{
					return 11;
				}
				num3 = nullable_0;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == -100) : null).GetValueOrDefault())
				{
					return 12;
				}
				if ((object)SubjectType == typeof(Side))
				{
					return 1;
				}
				return 0;
			}
			case _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type:
			case _WRA_WeaponTargetType.Submarine_Unspecified:
			{
				int? num5 = nullable_0;
				if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == -1) : null).GetValueOrDefault())
				{
					return 1;
				}
				num5 = nullable_0;
				if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					return 2;
				}
				num5 = nullable_0;
				if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					return 3;
				}
				num5 = nullable_0;
				if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					return 4;
				}
				num5 = nullable_0;
				if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 3) : null).GetValueOrDefault())
				{
					return 5;
				}
				num5 = nullable_0;
				if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 4) : null).GetValueOrDefault())
				{
					return 6;
				}
				num5 = nullable_0;
				if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == -99) : null).GetValueOrDefault())
				{
					return 7;
				}
				num5 = nullable_0;
				if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == -100) : null).GetValueOrDefault())
				{
					return 8;
				}
				if ((object)SubjectType == typeof(Side))
				{
					return 1;
				}
				return 0;
			}
			default:
				return 0;
			case _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Surface:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Reveted:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Open:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Reveted:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Aerostat_Moring:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Surface:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Reveted:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Bunker:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Underground:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Open:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Reveted:
			case _WRA_WeaponTargetType.Runway_Facility_Unspecified:
			case _WRA_WeaponTargetType.Runway:
			case _WRA_WeaponTargetType.Runway_Grade_Taxiway:
			case _WRA_WeaponTargetType.Runway_Access_Point:
			case _WRA_WeaponTargetType.Radar_Unspecified:
			case _WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified:
			case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Vehicle:
			case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel:
			case _WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified:
			case _WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle:
			case _WRA_WeaponTargetType.Underwater_Structure:
			case _WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield:
			{
				int? num = nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -1) : null).GetValueOrDefault())
				{
					return 1;
				}
				num = nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					return 2;
				}
				num = nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -2) : null).GetValueOrDefault())
				{
					return 3;
				}
				num = nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -3) : null).GetValueOrDefault())
				{
					return 4;
				}
				num = nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -4) : null).GetValueOrDefault())
				{
					return 5;
				}
				num = nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -5) : null).GetValueOrDefault())
				{
					return 6;
				}
				num = nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -6) : null).GetValueOrDefault())
				{
					return 7;
				}
				num = nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					return 8;
				}
				num = nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					return 9;
				}
				num = nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
				{
					return 10;
				}
				num = nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
				{
					return 11;
				}
				num = nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5) : null).GetValueOrDefault())
				{
					return 12;
				}
				num = nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 6) : null).GetValueOrDefault())
				{
					return 13;
				}
				num = nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 7) : null).GetValueOrDefault())
				{
					return 14;
				}
				num = nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 8) : null).GetValueOrDefault())
				{
					return 15;
				}
				num = nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -99) : null).GetValueOrDefault())
				{
					return 16;
				}
				num = nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -100) : null).GetValueOrDefault())
				{
					return 17;
				}
				if ((object)SubjectType == typeof(Side))
				{
					return 1;
				}
				return 0;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101198", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	internal int? CalculateRepository(ref object object_0)
	{
		try
		{
			int num = Conversions.ToInteger(object_0);
			if (1 == 0)
			{
			}
			int? result = num switch
			{
				2 => -99, 
				3 => 1, 
				4 => 2, 
				5 => 4, 
				6 => -100, 
				_ => null, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101212", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	internal int PopRepository(int? nullable_0)
	{
		try
		{
			int? num = nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -1) : null).GetValueOrDefault())
			{
				return 1;
			}
			num = nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -99) : null).GetValueOrDefault())
			{
				return 2;
			}
			num = nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				return 3;
			}
			num = nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
			{
				return 4;
			}
			num = nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
			{
				return 5;
			}
			num = nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -100) : null).GetValueOrDefault())
			{
				return 6;
			}
			if ((object)SubjectType == typeof(Side))
			{
				return 1;
			}
			return 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101213", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	internal float? InstantiateRepository(ref _WRA_WeaponTargetType _WRA_WeaponTargetType_0, ref object object_0, float float_0 = -99f)
	{
		try
		{
			switch (_WRA_WeaponTargetType_0)
			{
			case _WRA_WeaponTargetType.Satellite_Unspecified:
			{
				int num3 = Conversions.ToInteger(object_0);
				if (1 == 0)
				{
				}
				float? result = num3 switch
				{
					2 => 0f, 
					3 => -100f, 
					4 => float_0, 
					_ => null, 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			case _WRA_WeaponTargetType.Air_Contact_Unknown_Type:
			case _WRA_WeaponTargetType.Aircraft_Unspecified:
			case _WRA_WeaponTargetType.Aircraft_5th_Generation:
			case _WRA_WeaponTargetType.Aircraft_4th_Generation:
			case _WRA_WeaponTargetType.Aircraft_3rd_Generation:
			case _WRA_WeaponTargetType.Aircraft_Less_Capable:
			case _WRA_WeaponTargetType.Aircraft_High_Perf_Bombers:
			case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Bombers:
			case _WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers:
			case _WRA_WeaponTargetType.Aircraft_High_Perf_Recon_EW:
			case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Recon_EW:
			case _WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW:
			case _WRA_WeaponTargetType.Aircraft_AEW:
			case _WRA_WeaponTargetType.Aircraft_MicroUAV:
			case _WRA_WeaponTargetType.Aircraft_Tanker:
			case _WRA_WeaponTargetType.Helicopter_Unspecified:
			case _WRA_WeaponTargetType.Guided_Weapon_Unspecified:
			case _WRA_WeaponTargetType.Guided_Weapon_Supersonic_Sea_Skimming:
			case _WRA_WeaponTargetType.Guided_Weapon_Subsonic_Sea_Skimming:
			case _WRA_WeaponTargetType.Guided_Weapon_Supersonic:
			case _WRA_WeaponTargetType.Guided_Weapon_Subsonic:
			case _WRA_WeaponTargetType.Guided_Weapon_Ballistic:
			{
				int num4 = Conversions.ToInteger(object_0);
				if (1 == 0)
				{
				}
				float? result = num4 switch
				{
					2 => 0f, 
					3 => 2f, 
					4 => 5f, 
					5 => 10f, 
					6 => 15f, 
					7 => -99f, 
					8 => -100f, 
					9 => float_0, 
					_ => null, 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			case _WRA_WeaponTargetType.Surface_Contact_Unknown_Type:
			case _WRA_WeaponTargetType.Ship_Unspecified:
			case _WRA_WeaponTargetType.Ship_Carrier_0_25000_tons:
			case _WRA_WeaponTargetType.Ship_Carrier_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Carrier_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Carrier_95000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_0_500_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_501_1500_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_1501_5000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_5001_10000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_10001_25000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Surface_Combatant_95000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_0_500_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_501_1500_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_1501_5000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_5001_10000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_10001_25000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Amphibious_95000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_0_500_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_501_1500_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_1501_5000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_5001_10000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_10001_25000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Auxiliary_95000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_0_500_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_501_1500_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_1501_5000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_5001_10000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_10001_25000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_25001_45000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_45001_95000_tons:
			case _WRA_WeaponTargetType.Ship_Merchant_Civilian_95000_tons:
			case _WRA_WeaponTargetType.Submarine_Surfaced:
			{
				int num2 = Conversions.ToInteger(object_0);
				if (1 == 0)
				{
				}
				float? result = num2 switch
				{
					2 => 0f, 
					3 => 2f, 
					4 => 5f, 
					5 => 10f, 
					6 => 15f, 
					7 => -99f, 
					8 => -100f, 
					9 => float_0, 
					_ => null, 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			case _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type:
			case _WRA_WeaponTargetType.Submarine_Unspecified:
			{
				int num5 = Conversions.ToInteger(object_0);
				if (1 == 0)
				{
				}
				float? result = num5 switch
				{
					2 => 0f, 
					3 => 2f, 
					4 => 5f, 
					5 => 10f, 
					6 => 15f, 
					7 => -99f, 
					8 => -100f, 
					9 => float_0, 
					_ => null, 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			default:
				return null;
			case _WRA_WeaponTargetType.Land_Contact_Unknown_Type:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Surface:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Reveted:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Open:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Reveted:
			case _WRA_WeaponTargetType.Land_Structure_Soft_Aerostat_Moring:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Surface:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Reveted:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Bunker:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Underground:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Open:
			case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Reveted:
			case _WRA_WeaponTargetType.Runway_Facility_Unspecified:
			case _WRA_WeaponTargetType.Runway:
			case _WRA_WeaponTargetType.Runway_Grade_Taxiway:
			case _WRA_WeaponTargetType.Runway_Access_Point:
			case _WRA_WeaponTargetType.Radar_Unspecified:
			case _WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified:
			case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Vehicle:
			case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel:
			case _WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified:
			case _WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle:
			case _WRA_WeaponTargetType.Underwater_Structure:
			case _WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield:
			{
				int num = Conversions.ToInteger(object_0);
				if (1 == 0)
				{
				}
				float? result = num switch
				{
					2 => 0f, 
					3 => 2f, 
					4 => 5f, 
					5 => 10f, 
					6 => 15f, 
					7 => -99f, 
					8 => -100f, 
					9 => float_0, 
					_ => null, 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101199", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	internal int CreateRepository(ref _WRA_WeaponTargetType _WRA_WeaponTargetType_0, float? nullable_0)
	{
		try
		{
			if (nullable_0.HasValue)
			{
				switch (_WRA_WeaponTargetType_0)
				{
				case _WRA_WeaponTargetType.Satellite_Unspecified:
				{
					float? num8 = nullable_0;
					float? num9 = num8;
					if ((num9.HasValue ? new bool?(num9.GetValueOrDefault() == -1f) : null).GetValueOrDefault())
					{
						return 1;
					}
					num9 = num8;
					if ((num9.HasValue ? new bool?(num9.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
					{
						return 2;
					}
					num9 = num8;
					if ((num9.HasValue ? new bool?(num9.GetValueOrDefault() == -100f) : null).GetValueOrDefault())
					{
						return 3;
					}
					return 4;
				}
				case _WRA_WeaponTargetType.Air_Contact_Unknown_Type:
				case _WRA_WeaponTargetType.Aircraft_Unspecified:
				case _WRA_WeaponTargetType.Aircraft_5th_Generation:
				case _WRA_WeaponTargetType.Aircraft_4th_Generation:
				case _WRA_WeaponTargetType.Aircraft_3rd_Generation:
				case _WRA_WeaponTargetType.Aircraft_Less_Capable:
				case _WRA_WeaponTargetType.Aircraft_High_Perf_Bombers:
				case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Bombers:
				case _WRA_WeaponTargetType.Aircraft_Low_Perf_Bombers:
				case _WRA_WeaponTargetType.Aircraft_High_Perf_Recon_EW:
				case _WRA_WeaponTargetType.Aircraft_Medium_Perf_Recon_EW:
				case _WRA_WeaponTargetType.Aircraft_Low_Perf_Recon_EW:
				case _WRA_WeaponTargetType.Aircraft_AEW:
				case _WRA_WeaponTargetType.Aircraft_MicroUAV:
				case _WRA_WeaponTargetType.Aircraft_Tanker:
				case _WRA_WeaponTargetType.Helicopter_Unspecified:
				case _WRA_WeaponTargetType.Guided_Weapon_Unspecified:
				case _WRA_WeaponTargetType.Guided_Weapon_Supersonic_Sea_Skimming:
				case _WRA_WeaponTargetType.Guided_Weapon_Subsonic_Sea_Skimming:
				case _WRA_WeaponTargetType.Guided_Weapon_Supersonic:
				case _WRA_WeaponTargetType.Guided_Weapon_Subsonic:
				case _WRA_WeaponTargetType.Guided_Weapon_Ballistic:
				{
					float? num4 = nullable_0;
					float? num5 = num4;
					if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == -1f) : null).GetValueOrDefault())
					{
						return 1;
					}
					num5 = num4;
					if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
					{
						return 2;
					}
					num5 = num4;
					if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 2f) : null).GetValueOrDefault())
					{
						return 3;
					}
					num5 = num4;
					if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 5f) : null).GetValueOrDefault())
					{
						return 4;
					}
					num5 = num4;
					if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 10f) : null).GetValueOrDefault())
					{
						return 5;
					}
					num5 = num4;
					if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 15f) : null).GetValueOrDefault())
					{
						return 6;
					}
					num5 = num4;
					if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == -99f) : null).GetValueOrDefault())
					{
						return 7;
					}
					num5 = num4;
					if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == -100f) : null).GetValueOrDefault())
					{
						return 8;
					}
					return 9;
				}
				case _WRA_WeaponTargetType.Surface_Contact_Unknown_Type:
				case _WRA_WeaponTargetType.Ship_Unspecified:
				case _WRA_WeaponTargetType.Ship_Carrier_0_25000_tons:
				case _WRA_WeaponTargetType.Ship_Carrier_25001_45000_tons:
				case _WRA_WeaponTargetType.Ship_Carrier_45001_95000_tons:
				case _WRA_WeaponTargetType.Ship_Carrier_95000_tons:
				case _WRA_WeaponTargetType.Ship_Surface_Combatant_0_500_tons:
				case _WRA_WeaponTargetType.Ship_Surface_Combatant_501_1500_tons:
				case _WRA_WeaponTargetType.Ship_Surface_Combatant_1501_5000_tons:
				case _WRA_WeaponTargetType.Ship_Surface_Combatant_5001_10000_tons:
				case _WRA_WeaponTargetType.Ship_Surface_Combatant_10001_25000_tons:
				case _WRA_WeaponTargetType.Ship_Surface_Combatant_25001_45000_tons:
				case _WRA_WeaponTargetType.Ship_Surface_Combatant_45001_95000_tons:
				case _WRA_WeaponTargetType.Ship_Surface_Combatant_95000_tons:
				case _WRA_WeaponTargetType.Ship_Amphibious_0_500_tons:
				case _WRA_WeaponTargetType.Ship_Amphibious_501_1500_tons:
				case _WRA_WeaponTargetType.Ship_Amphibious_1501_5000_tons:
				case _WRA_WeaponTargetType.Ship_Amphibious_5001_10000_tons:
				case _WRA_WeaponTargetType.Ship_Amphibious_10001_25000_tons:
				case _WRA_WeaponTargetType.Ship_Amphibious_25001_45000_tons:
				case _WRA_WeaponTargetType.Ship_Amphibious_45001_95000_tons:
				case _WRA_WeaponTargetType.Ship_Amphibious_95000_tons:
				case _WRA_WeaponTargetType.Ship_Auxiliary_0_500_tons:
				case _WRA_WeaponTargetType.Ship_Auxiliary_501_1500_tons:
				case _WRA_WeaponTargetType.Ship_Auxiliary_1501_5000_tons:
				case _WRA_WeaponTargetType.Ship_Auxiliary_5001_10000_tons:
				case _WRA_WeaponTargetType.Ship_Auxiliary_10001_25000_tons:
				case _WRA_WeaponTargetType.Ship_Auxiliary_25001_45000_tons:
				case _WRA_WeaponTargetType.Ship_Auxiliary_45001_95000_tons:
				case _WRA_WeaponTargetType.Ship_Auxiliary_95000_tons:
				case _WRA_WeaponTargetType.Ship_Merchant_Civilian_0_500_tons:
				case _WRA_WeaponTargetType.Ship_Merchant_Civilian_501_1500_tons:
				case _WRA_WeaponTargetType.Ship_Merchant_Civilian_1501_5000_tons:
				case _WRA_WeaponTargetType.Ship_Merchant_Civilian_5001_10000_tons:
				case _WRA_WeaponTargetType.Ship_Merchant_Civilian_10001_25000_tons:
				case _WRA_WeaponTargetType.Ship_Merchant_Civilian_25001_45000_tons:
				case _WRA_WeaponTargetType.Ship_Merchant_Civilian_45001_95000_tons:
				case _WRA_WeaponTargetType.Ship_Merchant_Civilian_95000_tons:
				case _WRA_WeaponTargetType.Submarine_Surfaced:
				{
					float? num10 = nullable_0;
					float? num2 = num10;
					if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -1f) : null).GetValueOrDefault())
					{
						return 1;
					}
					num2 = num10;
					if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
					{
						return 2;
					}
					num2 = num10;
					if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 2f) : null).GetValueOrDefault())
					{
						return 3;
					}
					num2 = num10;
					if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 5f) : null).GetValueOrDefault())
					{
						return 4;
					}
					num2 = num10;
					if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 10f) : null).GetValueOrDefault())
					{
						return 5;
					}
					num2 = num10;
					if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 15f) : null).GetValueOrDefault())
					{
						return 6;
					}
					num2 = num10;
					if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -99f) : null).GetValueOrDefault())
					{
						return 7;
					}
					num2 = num10;
					if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -100f) : null).GetValueOrDefault())
					{
						return 8;
					}
					return 9;
				}
				case _WRA_WeaponTargetType.Subsurface_Contact_Unknown_Type:
				case _WRA_WeaponTargetType.Submarine_Unspecified:
				{
					float? num6 = nullable_0;
					float? num7 = num6;
					if ((num7.HasValue ? new bool?(num7.GetValueOrDefault() == -1f) : null).GetValueOrDefault())
					{
						return 1;
					}
					num7 = num6;
					if ((num7.HasValue ? new bool?(num7.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
					{
						return 2;
					}
					num7 = num6;
					if ((num7.HasValue ? new bool?(num7.GetValueOrDefault() == 2f) : null).GetValueOrDefault())
					{
						return 3;
					}
					num7 = num6;
					if ((num7.HasValue ? new bool?(num7.GetValueOrDefault() == 5f) : null).GetValueOrDefault())
					{
						return 4;
					}
					num7 = num6;
					if ((num7.HasValue ? new bool?(num7.GetValueOrDefault() == 10f) : null).GetValueOrDefault())
					{
						return 5;
					}
					num7 = num6;
					if ((num7.HasValue ? new bool?(num7.GetValueOrDefault() == 15f) : null).GetValueOrDefault())
					{
						return 6;
					}
					num7 = num6;
					if ((num7.HasValue ? new bool?(num7.GetValueOrDefault() == -99f) : null).GetValueOrDefault())
					{
						return 7;
					}
					num7 = num6;
					if ((num7.HasValue ? new bool?(num7.GetValueOrDefault() == -100f) : null).GetValueOrDefault())
					{
						return 8;
					}
					return 9;
				}
				default:
					return 0;
				case _WRA_WeaponTargetType.Land_Contact_Unknown_Type:
				case _WRA_WeaponTargetType.Land_Structure_Soft_Unspecified:
				case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Surface:
				case _WRA_WeaponTargetType.Land_Structure_Soft_Building_Reveted:
				case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Open:
				case _WRA_WeaponTargetType.Land_Structure_Soft_Structure_Reveted:
				case _WRA_WeaponTargetType.Land_Structure_Soft_Aerostat_Moring:
				case _WRA_WeaponTargetType.Land_Structure_Hardened_Unspecified:
				case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Surface:
				case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Reveted:
				case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Bunker:
				case _WRA_WeaponTargetType.Land_Structure_Hardened_Building_Underground:
				case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Open:
				case _WRA_WeaponTargetType.Land_Structure_Hardened_Structure_Reveted:
				case _WRA_WeaponTargetType.Runway_Facility_Unspecified:
				case _WRA_WeaponTargetType.Runway:
				case _WRA_WeaponTargetType.Runway_Grade_Taxiway:
				case _WRA_WeaponTargetType.Runway_Access_Point:
				case _WRA_WeaponTargetType.Radar_Unspecified:
				case _WRA_WeaponTargetType.Mobile_Target_Soft_Unspecified:
				case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Vehicle:
				case _WRA_WeaponTargetType.Mobile_Target_Soft_Mobile_Personnel:
				case _WRA_WeaponTargetType.Mobile_Target_Hardened_Unspecified:
				case _WRA_WeaponTargetType.Mobile_Target_Hardened_Mobile_Vehicle:
				case _WRA_WeaponTargetType.Underwater_Structure:
				case _WRA_WeaponTargetType.Air_Base_Single_Unit_Airfield:
				{
					float? num = nullable_0;
					float? num3 = num;
					if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == -1f) : null).GetValueOrDefault())
					{
						return 1;
					}
					num3 = num;
					if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
					{
						return 2;
					}
					num3 = num;
					if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 2f) : null).GetValueOrDefault())
					{
						return 3;
					}
					num3 = num;
					if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 5f) : null).GetValueOrDefault())
					{
						return 4;
					}
					num3 = num;
					if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 10f) : null).GetValueOrDefault())
					{
						return 5;
					}
					num3 = num;
					if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 15f) : null).GetValueOrDefault())
					{
						return 6;
					}
					num3 = num;
					if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == -99f) : null).GetValueOrDefault())
					{
						return 7;
					}
					num3 = num;
					if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == -100f) : null).GetValueOrDefault())
					{
						return 8;
					}
					return 9;
				}
				}
			}
			if ((object)Subject.GetType() == typeof(Side))
			{
				return 1;
			}
			return 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101200", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	internal float? CompareRepository(ref object object_0, float float_0 = -99f)
	{
		try
		{
			int num = Conversions.ToInteger(object_0);
			if (1 == 0)
			{
			}
			float? result = num switch
			{
				1 => -99f, 
				2 => 0f, 
				3 => 2f, 
				4 => 5f, 
				5 => 10f, 
				6 => 15f, 
				7 => 20f, 
				8 => 25f, 
				9 => 30f, 
				10 => 35f, 
				11 => 40f, 
				12 => 45f, 
				13 => 50f, 
				14 => 60f, 
				15 => 70f, 
				16 => 80f, 
				17 => 90f, 
				18 => 100f, 
				19 => 125f, 
				20 => 150f, 
				21 => 175f, 
				22 => 200f, 
				23 => 250f, 
				24 => 300f, 
				25 => 500f, 
				26 => 750f, 
				27 => 1000f, 
				28 => 1500f, 
				29 => 2000f, 
				30 => -100f, 
				31 => float_0, 
				32 => -95f, 
				33 => -96f, 
				34 => -97f, 
				35 => -102f, 
				_ => null, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101201", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	internal int ReadRepository(float? nullable_0)
	{
		try
		{
			if (nullable_0.HasValue)
			{
				float? num = nullable_0;
				float? num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -99f) : null).GetValueOrDefault())
				{
					return 1;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
				{
					return 2;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 2f) : null).GetValueOrDefault())
				{
					return 3;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 5f) : null).GetValueOrDefault())
				{
					return 4;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 10f) : null).GetValueOrDefault())
				{
					return 5;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 15f) : null).GetValueOrDefault())
				{
					return 6;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 20f) : null).GetValueOrDefault())
				{
					return 7;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 25f) : null).GetValueOrDefault())
				{
					return 8;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 30f) : null).GetValueOrDefault())
				{
					return 9;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 35f) : null).GetValueOrDefault())
				{
					return 10;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 40f) : null).GetValueOrDefault())
				{
					return 11;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 45f) : null).GetValueOrDefault())
				{
					return 12;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 50f) : null).GetValueOrDefault())
				{
					return 13;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 60f) : null).GetValueOrDefault())
				{
					return 14;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 70f) : null).GetValueOrDefault())
				{
					return 15;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 80f) : null).GetValueOrDefault())
				{
					return 16;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 90f) : null).GetValueOrDefault())
				{
					return 17;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 100f) : null).GetValueOrDefault())
				{
					return 18;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 125f) : null).GetValueOrDefault())
				{
					return 19;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 150f) : null).GetValueOrDefault())
				{
					return 20;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 175f) : null).GetValueOrDefault())
				{
					return 21;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 200f) : null).GetValueOrDefault())
				{
					return 22;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 250f) : null).GetValueOrDefault())
				{
					return 23;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 300f) : null).GetValueOrDefault())
				{
					return 24;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 500f) : null).GetValueOrDefault())
				{
					return 25;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 750f) : null).GetValueOrDefault())
				{
					return 26;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 1000f) : null).GetValueOrDefault())
				{
					return 27;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 1500f) : null).GetValueOrDefault())
				{
					return 28;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 2000f) : null).GetValueOrDefault())
				{
					return 29;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -100f) : null).GetValueOrDefault())
				{
					return 30;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -95f) : null).GetValueOrDefault())
				{
					return 32;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -96f) : null).GetValueOrDefault())
				{
					return 33;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -97f) : null).GetValueOrDefault())
				{
					return 34;
				}
				num2 = num;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -102f) : null).GetValueOrDefault())
				{
					return 35;
				}
				return 31;
			}
			if ((object)Subject.GetType() == typeof(Side))
			{
				return 1;
			}
			return 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101202", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	public static string WRA_WeaponQtyString(int? nullable_0, bool bool_0)
	{
		string text = "";
		if (bool_0)
		{
			text = "（使用'未指定'目标类型设置）";
		}
		int? num = nullable_0;
		int? num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -1) : null).GetValueOrDefault())
		{
			return "系统默认（来自数据库）" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
		{
			return "不要对此目标类型使用武器" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -98) : null).GetValueOrDefault())
		{
			return "没有定义的" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -99) : null).GetValueOrDefault())
		{
			return "所有武器" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -2) : null).GetValueOrDefault())
		{
			return "目标的导弹防御值" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -3) : null).GetValueOrDefault())
		{
			return "2x目标的导弹防御值" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -4) : null).GetValueOrDefault())
		{
			return "4x目标的导弹防御值" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -5) : null).GetValueOrDefault())
		{
			return "目标导弹防御能力的1/2" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -6) : null).GetValueOrDefault())
		{
			return "目标导弹防御能力的1/4" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -100) : null).GetValueOrDefault())
		{
			return "Various" + text;
		}
		if (nullable_0.HasValue)
		{
			num2 = nullable_0;
			(num2.HasValue ? new bool?(num2.GetValueOrDefault() > 1) : null).GetValueOrDefault();
			int? num3 = nullable_0;
			int? num4 = num3;
			return num4 + "轮" + text;
		}
		return text + "未配置";
	}

	public static string WRA_ShooterQtyString(int? nullable_0, bool bool_0)
	{
		string text = "";
		if (bool_0)
		{
			text = "（使用'未指定'目标类型设置）";
		}
		int? num = nullable_0;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -1) : null).GetValueOrDefault())
		{
			return "系统默认（来自数据库）" + text;
		}
		num = nullable_0;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -99) : null).GetValueOrDefault())
		{
			return "从足够多的单元选择射击武器来填补齐射的武器数量要求" + text;
		}
		num = nullable_0;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -100) : null).GetValueOrDefault())
		{
			return "Various" + text;
		}
		if (Information.IsNothing(nullable_0))
		{
			return text + "未配置";
		}
		num = nullable_0;
		(num.HasValue ? new bool?(num.GetValueOrDefault() > 1) : null).GetValueOrDefault();
		int? num2 = nullable_0;
		return num2 + "单元" + text;
	}

	internal string DisableRepository(float? nullable_0, bool bool_0)
	{
		string text = "";
		if (bool_0)
		{
			text = "（使用'未指定'目标类型设置）";
		}
		float? num = nullable_0;
		float? num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -1f) : null).GetValueOrDefault())
		{
			return "系统默认（来自数据库）" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
		{
			return "不要在自卫中使用武器" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -98f) : null).GetValueOrDefault())
		{
			return "没有定义的" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -99f) : null).GetValueOrDefault())
		{
			return "最大范围" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -100f) : null).GetValueOrDefault())
		{
			return "Various" + text;
		}
		if (nullable_0.HasValue)
		{
			float? num3 = nullable_0;
			float? num4 = num3;
			return num4 + "海里" + text;
		}
		return "未配置" + text;
	}

	internal string UpdateRepository(float? nullable_0, bool bool_0)
	{
		string text = "";
		if (bool_0)
		{
			text = "（使用'未指定'目标类型设置）";
		}
		float? num = nullable_0;
		float? num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
		{
			return "不自动使用，仅手动开火" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -98f) : null).GetValueOrDefault())
		{
			return "没有定义的" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -99f) : null).GetValueOrDefault())
		{
			return "在最大范围内自动开火" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -100f) : null).GetValueOrDefault())
		{
			return "Various" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -95f) : null).GetValueOrDefault())
		{
			return "25% of max" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -96f) : null).GetValueOrDefault())
		{
			return "50% of max" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -97f) : null).GetValueOrDefault())
		{
			return "75% of max" + text;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -102f) : null).GetValueOrDefault())
		{
			return "不可逃逸区NEZ" + text;
		}
		if (nullable_0.HasValue)
		{
			float? num3 = nullable_0;
			float? num4 = num3;
			return num4 + "nm" + text;
		}
		return "";
	}

	internal bool InsertRepository(ref Weapon weapon_0)
	{
		Weapon._WeaponType type = weapon_0.Type;
		if (1 == 0)
		{
		}
		bool result = type switch
		{
			Weapon._WeaponType.SensorPod => false, 
			Weapon._WeaponType.DropTank => false, 
			Weapon._WeaponType.BuddyStore => false, 
			Weapon._WeaponType.FerryTank => false, 
			Weapon._WeaponType.Decoy_Expendable => false, 
			Weapon._WeaponType.Decoy_Towed => false, 
			Weapon._WeaponType.TrainingRound => false, 
			Weapon._WeaponType.Cargo => false, 
			Weapon._WeaponType.Troops => false, 
			Weapon._WeaponType.Paratroops => false, 
			Weapon._WeaponType.HeliTowedPackage => false, 
			Weapon._WeaponType.Sonobuoy => false, 
			_ => true, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	[SpecialName]
	public _BingoThreshold_E? GetBingoThreshold(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (BingoThreshold_Inherits)
			{
				Doctrine doctrine = null;
				while (Information.IsNothing(doctrine))
				{
					bool bool_3 = true;
					doctrine = GetParentDoctrine(scenario_0, ref bool_3);
				}
				return doctrine.GetBingoThreshold(scenario_0, bool_0, bool_1, bool_2);
			}
			return m_EventIssuer.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200452", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			_BingoThreshold_E? result = _BingoThreshold_E.Bingo60Percent;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public void SetBingoThreshold(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _BingoThreshold_E? nullable_0)
	{
		m_EventIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	[SpecialName]
	public _RefuelAlliedUnits? GetRefuelAllies(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (RefuelAllies_Inherits())
			{
				Doctrine doctrine = null;
				while (Information.IsNothing(doctrine))
				{
					bool bool_3 = true;
					doctrine = GetParentDoctrine(scenario_0, ref bool_3);
				}
				return doctrine.GetRefuelAllies(scenario_0, bool_0, bool_1, bool_2);
			}
			return factoryIssuer.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200452", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			_RefuelAlliedUnits? result = _RefuelAlliedUnits.No;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public void SetRefuelAllies(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _RefuelAlliedUnits? nullable_0)
	{
		factoryIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool RefuelAllies_Inherits()
	{
		return !factoryIssuer.HasValue;
	}

	[SpecialName]
	public bool GetRefuelAllies_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return m_AttributeIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetRefuelAllies_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetRefuelAllies_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			m_AttributeIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetRefuelAllies_PlayerEditable(scenario_0, bool_0);
	}

	[SpecialName]
	public bool GetBingoRefuel_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return globalIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetBingoRefuel_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetBingoRefuel_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			globalIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetBingoRefuel_PlayerEditable(scenario_0, bool_0);
	}

	public void ComboBox_RefuelAllies(ref DataTable dataTable_0, Scenario scenario_0, _RefuelAlliedUnits? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "Yes";
		string text2 = "是，仅接受加油";
		string text3 = "是，仅给盟友加油";
		string text4 = "No";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		dataTable_0.Rows.Add(3, text4);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(4, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(4, "继承，" + text2);
				}
				else
				{
					b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(4, "继承，" + text3);
					}
					else
					{
						b = (byte?)nullable_0;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(4, "继承，" + text4);
						}
						else
						{
							dataTable_0.Rows.Add(4, "继承，多种设置");
						}
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_RefuelAlliedUnits? refuelAllies = GetParentDoctrine(scenario_0, ref bool_).GetRefuelAllies(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			b = (byte?)refuelAllies;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(4, "继承，" + text);
			}
			else
			{
				b = (byte?)refuelAllies;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(4, "继承，" + text2);
				}
				else
				{
					b = (byte?)refuelAllies;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(4, "继承，" + text3);
					}
					else
					{
						dataTable_0.Rows.Add(4, "继承，" + text4);
					}
				}
			}
		}
		b = (byte?)GetRefuelAllies(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(5, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(5, "未配置");
		}
	}

	public void ComboBox_BingoThreshold(ref DataTable dataTable_0, Scenario scenario_0, _BingoThreshold_E? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "30%";
		string text2 = "40%";
		string text3 = "50%";
		string text4 = "60%";
		string text5 = "70%";
		string text6 = "80%";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		dataTable_0.Rows.Add(3, text4);
		dataTable_0.Rows.Add(4, text5);
		dataTable_0.Rows.Add(5, text6);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (Information.IsNothing(nullable_0))
		{
			bool bool_ = true;
			_BingoThreshold_E? bingoThreshold = GetParentDoctrine(scenario_0, ref bool_).GetBingoThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			b = (byte?)bingoThreshold;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(6, "继承，" + text);
			}
			else
			{
				b = (byte?)bingoThreshold;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(6, "继承，" + text2);
				}
				else
				{
					b = (byte?)bingoThreshold;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(6, "继承，" + text3);
					}
					else
					{
						b = (byte?)bingoThreshold;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(6, "继承，" + text4);
						}
						else
						{
							b = (byte?)bingoThreshold;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(6, "继承，" + text5);
							}
							else
							{
								b = (byte?)bingoThreshold;
								if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									dataTable_0.Rows.Add(6, "继承，" + text6);
								}
								else
								{
									dataTable_0.Rows.Add(6, "继承，" + text4);
								}
							}
						}
					}
				}
			}
		}
		else
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(6, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(6, "继承，" + text2);
				}
				else
				{
					b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(6, "继承，" + text3);
					}
					else
					{
						b = (byte?)nullable_0;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(6, "继承，" + text4);
						}
						else
						{
							b = (byte?)nullable_0;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(6, "继承，" + text5);
							}
							else
							{
								b = (byte?)nullable_0;
								if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									dataTable_0.Rows.Add(6, "继承，" + text6);
								}
								else
								{
									dataTable_0.Rows.Add(6, "继承，多种设置");
								}
							}
						}
					}
				}
			}
		}
		b = (byte?)GetBingoThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 6) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(7, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(7, "未配置");
		}
	}

	[SpecialName]
	public _AvoidContactWhenPossible? GetAvoidContact(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (AvoidContact_Inherits())
			{
				Doctrine doctrine = null;
				while (Information.IsNothing(doctrine))
				{
					bool bool_3 = true;
					doctrine = GetParentDoctrine(scenario_0, ref bool_3);
				}
				return doctrine.GetAvoidContact(scenario_0, bool_0, bool_1, bool_2);
			}
			return _WorkerIssuer.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200453", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			_AvoidContactWhenPossible? result = _AvoidContactWhenPossible.Yes_Always;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public void SetAvoidContact(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _AvoidContactWhenPossible? nullable_0)
	{
		_WorkerIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool AvoidContact_Inherits()
	{
		return !_WorkerIssuer.HasValue;
	}

	[SpecialName]
	public bool GetAvoidContact_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return accountIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetAvoidContact_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetAvoidContact_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			accountIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetAvoidContact_PlayerEditable(scenario_0, bool_0);
	}

	public void ComboBox_AvoidContact(ref DataTable dataTable_0, Scenario scenario_0, _AvoidContactWhenPossible? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "No";
		string text2 = "是，总是";
		string text3 = "是，除了自卫时";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(3, "继承，" + text3);
					}
					else
					{
						dataTable_0.Rows.Add(3, "继承，多种设置");
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_AvoidContactWhenPossible? avoidContact = GetParentDoctrine(scenario_0, ref bool_).GetAvoidContact(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			b = (byte?)avoidContact;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text);
			}
			else
			{
				b = (byte?)avoidContact;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(3, "继承，" + text3);
				}
			}
		}
		b = (byte?)GetAvoidContact(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(4, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(4, "未配置");
		}
	}

	[SpecialName]
	public _DiveOnContact? GetDiveWhenThreatsDetected(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (DiveWhenThreatsDetected_Inherits())
			{
				Doctrine doctrine = null;
				while (Information.IsNothing(doctrine))
				{
					bool bool_3 = true;
					doctrine = GetParentDoctrine(scenario_0, ref bool_3);
				}
				return doctrine.GetDiveWhenThreatsDetected(scenario_0, bool_0, bool_1, bool_2);
			}
			return stateIssuer.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200454", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			_DiveOnContact? result = _DiveOnContact.Yes;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public void SetDiveWhenThreatsDetected(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _DiveOnContact? nullable_0)
	{
		stateIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool DiveWhenThreatsDetected_Inherits()
	{
		return !stateIssuer.HasValue;
	}

	[SpecialName]
	public bool GetDiveWhenThreatsDetected_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return m_AuthenticationIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetDiveWhenThreatsDetected_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetDiveWhenThreatsDetected_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			m_AuthenticationIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetDiveWhenThreatsDetected_PlayerEditable(scenario_0, bool_0);
	}

	public void ComboBox_DiveWhenThreatsDetected(ref DataTable dataTable_0, Scenario scenario_0, _DiveOnContact? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "是，关于ESM检测和威胁接近性";
		string text2 = "是，在潜望镜/海面搜索雷达探测时";
		string text3 = "是，当船舶在20海里范围内或飞机在30海里范围内时";
		string text4 = "No";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		dataTable_0.Rows.Add(3, text4);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(4, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(4, "继承，" + text2);
				}
				else
				{
					b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(4, "继承，" + text3);
					}
					else
					{
						b = (byte?)nullable_0;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(4, "继承，" + text4);
						}
						else
						{
							dataTable_0.Rows.Add(4, "继承，多种设置");
						}
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_DiveOnContact? diveOnContact = GetParentDoctrine(scenario_0, ref bool_)?.GetDiveWhenThreatsDetected(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			b = (byte?)diveOnContact;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(4, "继承，" + text);
			}
			else
			{
				b = (byte?)diveOnContact;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(4, "继承，" + text2);
				}
				else
				{
					b = (byte?)diveOnContact;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(4, "继承，" + text3);
					}
					else
					{
						dataTable_0.Rows.Add(4, "继承，" + text4);
					}
				}
			}
		}
		b = (byte?)GetDiveWhenThreatsDetected(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(5, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(5, "未配置");
		}
	}

	[SpecialName]
	public _RechargeBatteryPercentage? GetRechargePercentagePatrol(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (RechargePercentagePatrol_Inherits())
			{
				Doctrine doctrine = null;
				while (Information.IsNothing(doctrine))
				{
					bool bool_3 = true;
					doctrine = GetParentDoctrine(scenario_0, ref bool_3);
				}
				return doctrine.GetRechargePercentagePatrol(scenario_0, bool_0, bool_1, bool_2);
			}
			return paramsIssuer.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200455", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			_RechargeBatteryPercentage? result = _RechargeBatteryPercentage.Recharge_10_Percent;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public void SetRechargePercentagePatrol(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _RechargeBatteryPercentage? nullable_0)
	{
		paramsIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool RechargePercentagePatrol_Inherits()
	{
		return !paramsIssuer.HasValue;
	}

	[SpecialName]
	public bool GetRechargePercentagePatrol_PlayerEditable(Scenario scenario_0)
	{
		try
		{
			if ((object)SubjectType == typeof(Side))
			{
				return infoIssuer;
			}
			bool bool_ = true;
			return GetParentDoctrine(scenario_0, ref bool_).GetRechargePercentagePatrol_PlayerEditable(scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[SpecialName]
	public void SetRechargePercentagePatrol_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			infoIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetRechargePercentagePatrol_PlayerEditable(scenario_0, bool_0);
	}

	public void ComboBox_RechargePercentagePatrol(ref DataTable dataTable_0, Scenario scenario_0, _RechargeBatteryPercentage? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "无剩余电量时";
		string text3 = "当剩余10％的电池时";
		string text4 = "20%";
		string text5 = "30%";
		string text6 = "40%";
		string text7 = "50%";
		string text8 = "60%";
		string text9 = "70%";
		string text10 = "80%";
		string text2 = "90%";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text3);
		dataTable_0.Rows.Add(2, text4);
		dataTable_0.Rows.Add(3, text5);
		dataTable_0.Rows.Add(4, text6);
		dataTable_0.Rows.Add(5, text7);
		dataTable_0.Rows.Add(6, text8);
		dataTable_0.Rows.Add(7, text9);
		dataTable_0.Rows.Add(8, text10);
		dataTable_0.Rows.Add(9, text2);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		int? num;
		if (nullable_0.HasValue)
		{
			num = (int?)nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(10, "继承，" + text);
			}
			else
			{
				num = (int?)nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 10) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(10, "继承，" + text3);
				}
				else
				{
					num = (int?)nullable_0;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 20) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(10, "继承，" + text4);
					}
					else
					{
						num = (int?)nullable_0;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 30) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(10, "继承，" + text5);
						}
						else
						{
							num = (int?)nullable_0;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 40) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(10, "继承，" + text6);
							}
							else
							{
								num = (int?)nullable_0;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 50) : null).GetValueOrDefault())
								{
									dataTable_0.Rows.Add(10, "继承，" + text7);
								}
								else
								{
									num = (int?)nullable_0;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 60) : null).GetValueOrDefault())
									{
										dataTable_0.Rows.Add(10, "继承，" + text8);
									}
									else
									{
										num = (int?)nullable_0;
										if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 70) : null).GetValueOrDefault())
										{
											dataTable_0.Rows.Add(10, "继承，" + text9);
										}
										else
										{
											num = (int?)nullable_0;
											if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 80) : null).GetValueOrDefault())
											{
												dataTable_0.Rows.Add(10, "继承，" + text10);
											}
											else
											{
												num = (int?)nullable_0;
												if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 90) : null).GetValueOrDefault())
												{
													dataTable_0.Rows.Add(10, "继承，" + text2);
												}
												else
												{
													dataTable_0.Rows.Add(10, "继承，多种设置");
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_RechargeBatteryPercentage? rechargePercentagePatrol = GetParentDoctrine(scenario_0, ref bool_).GetRechargePercentagePatrol(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			num = (int?)rechargePercentagePatrol;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(10, "继承，" + text);
			}
			else
			{
				num = (int?)rechargePercentagePatrol;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 10) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(10, "继承，" + text3);
				}
				else
				{
					num = (int?)rechargePercentagePatrol;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 20) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(10, "继承，" + text4);
					}
					else
					{
						num = (int?)rechargePercentagePatrol;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 30) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(10, "继承，" + text5);
						}
						else
						{
							num = (int?)rechargePercentagePatrol;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 40) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(10, "继承，" + text6);
							}
							else
							{
								num = (int?)rechargePercentagePatrol;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 50) : null).GetValueOrDefault())
								{
									dataTable_0.Rows.Add(10, "继承，" + text7);
								}
								else
								{
									num = (int?)rechargePercentagePatrol;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 60) : null).GetValueOrDefault())
									{
										dataTable_0.Rows.Add(10, "继承，" + text8);
									}
									else
									{
										num = (int?)rechargePercentagePatrol;
										if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 70) : null).GetValueOrDefault())
										{
											dataTable_0.Rows.Add(10, "继承，" + text9);
										}
										else
										{
											num = (int?)rechargePercentagePatrol;
											if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 80) : null).GetValueOrDefault())
											{
												dataTable_0.Rows.Add(10, "继承，" + text10);
											}
											else
											{
												dataTable_0.Rows.Add(10, "继承，" + text2);
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		num = (int?)GetRechargePercentagePatrol(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -100) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(11, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(11, "未配置");
		}
	}

	[SpecialName]
	public _RechargeBatteryPercentage? GetRechargePercentageAttack(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (RechargePercentageAttack_Inherits())
			{
				Doctrine doctrine = null;
				while (Information.IsNothing(doctrine))
				{
					bool bool_3 = true;
					doctrine = GetParentDoctrine(scenario_0, ref bool_3);
				}
				return doctrine.GetRechargePercentageAttack(scenario_0, bool_0, bool_1, bool_2);
			}
			return helperIssuer.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200456", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			_RechargeBatteryPercentage? result = _RechargeBatteryPercentage.Recharge_10_Percent;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public void SetRechargePercentageAttack(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _RechargeBatteryPercentage? nullable_0)
	{
		helperIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool RechargePercentageAttack_Inherits()
	{
		return !helperIssuer.HasValue;
	}

	[SpecialName]
	public bool GetRechargePercentageAttack_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return mapperIssuer;
		}
		bool bool_ = true;
		Doctrine parentDoctrine = GetParentDoctrine(scenario_0, ref bool_);
		try
		{
			return parentDoctrine.GetRechargePercentageAttack_PlayerEditable(scenario_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[SpecialName]
	public void SetRechargePercentageAttack_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			mapperIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_);
		try
		{
			bool_ = true;
			GetParentDoctrine(scenario_0, ref bool_).SetRechargePercentageAttack_PlayerEditable(scenario_0, bool_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void ComboBox_RechargePercentageAttack(ref DataTable dataTable_0, Scenario scenario_0, _RechargeBatteryPercentage? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "无剩余电量时";
		string text3 = "当剩余10％的电池时";
		string text4 = "20%";
		string text5 = "30%";
		string text6 = "40%";
		string text7 = "50%";
		string text8 = "60%";
		string text9 = "70%";
		string text10 = "80%";
		string text2 = "90%";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text3);
		dataTable_0.Rows.Add(2, text4);
		dataTable_0.Rows.Add(3, text5);
		dataTable_0.Rows.Add(4, text6);
		dataTable_0.Rows.Add(5, text7);
		dataTable_0.Rows.Add(6, text8);
		dataTable_0.Rows.Add(7, text9);
		dataTable_0.Rows.Add(8, text10);
		dataTable_0.Rows.Add(9, text2);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		int? num;
		if (nullable_0.HasValue)
		{
			num = (int?)nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(10, "继承，" + text);
			}
			else
			{
				num = (int?)nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 10) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(10, "继承，" + text3);
				}
				else
				{
					num = (int?)nullable_0;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 20) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(10, "继承，" + text4);
					}
					else
					{
						num = (int?)nullable_0;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 30) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(10, "继承，" + text5);
						}
						else
						{
							num = (int?)nullable_0;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 40) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(10, "继承，" + text6);
							}
							else
							{
								num = (int?)nullable_0;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 50) : null).GetValueOrDefault())
								{
									dataTable_0.Rows.Add(10, "继承，" + text7);
								}
								else
								{
									num = (int?)nullable_0;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 60) : null).GetValueOrDefault())
									{
										dataTable_0.Rows.Add(10, "继承，" + text8);
									}
									else
									{
										num = (int?)nullable_0;
										if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 70) : null).GetValueOrDefault())
										{
											dataTable_0.Rows.Add(10, "继承，" + text9);
										}
										else
										{
											num = (int?)nullable_0;
											if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 80) : null).GetValueOrDefault())
											{
												dataTable_0.Rows.Add(10, "继承，" + text10);
											}
											else
											{
												num = (int?)nullable_0;
												if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 90) : null).GetValueOrDefault())
												{
													dataTable_0.Rows.Add(10, "继承，" + text2);
												}
												else
												{
													dataTable_0.Rows.Add(10, "继承，多种设置");
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_RechargeBatteryPercentage? rechargePercentageAttack = GetParentDoctrine(scenario_0, ref bool_).GetRechargePercentageAttack(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			num = (int?)rechargePercentageAttack;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(10, "继承，" + text);
			}
			else
			{
				num = (int?)rechargePercentageAttack;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 10) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(10, "继承，" + text3);
				}
				else
				{
					num = (int?)rechargePercentageAttack;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 20) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(10, "继承，" + text4);
					}
					else
					{
						num = (int?)rechargePercentageAttack;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 30) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(10, "继承，" + text5);
						}
						else
						{
							num = (int?)rechargePercentageAttack;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 40) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(10, "继承，" + text6);
							}
							else
							{
								num = (int?)rechargePercentageAttack;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 50) : null).GetValueOrDefault())
								{
									dataTable_0.Rows.Add(10, "继承，" + text7);
								}
								else
								{
									num = (int?)rechargePercentageAttack;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 60) : null).GetValueOrDefault())
									{
										dataTable_0.Rows.Add(10, "继承，" + text8);
									}
									else
									{
										num = (int?)rechargePercentageAttack;
										if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 70) : null).GetValueOrDefault())
										{
											dataTable_0.Rows.Add(10, "继承，" + text9);
										}
										else
										{
											num = (int?)rechargePercentageAttack;
											if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 80) : null).GetValueOrDefault())
											{
												dataTable_0.Rows.Add(10, "继承，" + text10);
											}
											else
											{
												dataTable_0.Rows.Add(10, "继承，" + text2);
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		num = (int?)GetRechargePercentageAttack(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -100) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(11, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(11, "未配置");
		}
	}

	[SpecialName]
	public _UseAIP? method_2(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (AIPUsage_Inherits())
			{
				Doctrine doctrine = null;
				while (Information.IsNothing(doctrine))
				{
					bool bool_3 = true;
					doctrine = GetParentDoctrine(scenario_0, ref bool_3);
				}
				return doctrine.method_2(scenario_0, bool_0, bool_1, bool_2);
			}
			return _ManagerIssuer.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200457", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			_UseAIP? result = _UseAIP.No;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public void method_3(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _UseAIP? nullable_0)
	{
		_ManagerIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool AIPUsage_Inherits()
	{
		return !_ManagerIssuer.HasValue;
	}

	[SpecialName]
	public bool GetAIPUsage_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return m_GetterIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetAIPUsage_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetAIPUsage_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			m_GetterIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetAIPUsage_PlayerEditable(scenario_0, bool_0);
	}

	private void PrepareRepository(ref DataTable dataTable_0, Scenario scenario_0, _UseAIP? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "No";
		string text2 = "是，当进攻或防守时";
		string text3 = "是，总是";
		dataTable_0.Rows.Add(0, text3);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text3);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					b = (byte?)nullable_0;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(3, "继承，" + text);
					}
					else
					{
						dataTable_0.Rows.Add(3, "继承，多种设置");
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_UseAIP? useAIP = GetParentDoctrine(scenario_0, ref bool_).method_2(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			b = (byte?)useAIP;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(3, "继承，" + text3);
			}
			else
			{
				b = (byte?)useAIP;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(3, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(3, "继承，" + text);
				}
			}
		}
		b = (byte?)method_2(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(4, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(4, "未配置");
		}
	}

	[SpecialName]
	public _UseDippingSonar? GetDippingSonar(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (DippingSonar_Inherits())
			{
				Doctrine doctrine = null;
				while (Information.IsNothing(doctrine))
				{
					bool bool_3 = true;
					doctrine = GetParentDoctrine(scenario_0, ref bool_3);
				}
				return doctrine.GetDippingSonar(scenario_0, bool_0, bool_1, bool_2);
			}
			return m_ProducerIssuer.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200458", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			_UseDippingSonar? result = _UseDippingSonar.Automatically_HoverAnd150ft;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public void SetDippingSonar(Scenario scenario_0, bool bool_0, bool bool_1, bool bool_2, _UseDippingSonar? nullable_0)
	{
		m_ProducerIssuer = nullable_0;
		m_InstanceClient?.Invoke(Subject, false, bool_0, bool_1, bool_2, viaFlightPlanEditor: false);
	}

	public bool DippingSonar_Inherits()
	{
		return !m_ProducerIssuer.HasValue;
	}

	[SpecialName]
	public bool GetDippingSonar_PlayerEditable(Scenario scenario_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			return _ProcIssuer;
		}
		bool bool_ = true;
		return GetParentDoctrine(scenario_0, ref bool_).GetDippingSonar_PlayerEditable(scenario_0);
	}

	[SpecialName]
	public void SetDippingSonar_PlayerEditable(Scenario scenario_0, bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			_ProcIssuer = bool_0;
			return;
		}
		bool bool_ = true;
		GetParentDoctrine(scenario_0, ref bool_).SetDippingSonar_PlayerEditable(scenario_0, bool_0);
	}

	public void ComboBox_DippingSonar(ref DataTable dataTable_0, Scenario scenario_0, _UseDippingSonar? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "在低于150英尺的高度盘旋时自动部署";
		string text2 = "仅手动部署或分配到任务时";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		byte? b;
		if (nullable_0.HasValue)
		{
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(2, "继承，" + text2);
				}
				else
				{
					dataTable_0.Rows.Add(2, "继承，多种设置");
				}
			}
		}
		else
		{
			bool bool_ = true;
			b = (byte?)GetParentDoctrine(scenario_0, ref bool_).GetDippingSonar(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(2, "继承，" + text);
			}
			else
			{
				dataTable_0.Rows.Add(2, "继承，" + text2);
			}
		}
		b = (byte?)GetDippingSonar(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(3, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(3, "未配置");
		}
	}

	public void ToXML(ref XmlWriter xmlWriter_0, ref Scenario scenario_0, string string_0 = "Doctrine")
	{
		try
		{
			xmlWriter_0.WriteStartElement(string_0);
			if (_AdapterIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("Nukes", ((byte)GetNukesAllowed(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (_SchemaIssuer)
			{
				xmlWriter_0.WriteElementString("Nukes_Player", _SchemaIssuer.ToString());
			}
			if (codeIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("WCS_Air", ((byte)GetWeaponControlStatus_Air(scenario_0, bool_0: false, null, bool_1: false, bool_2: false).Value).ToString());
			}
			if (connectionIssuer)
			{
				xmlWriter_0.WriteElementString("WCS_Air_Player", connectionIssuer.ToString());
			}
			if (m_ContextIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("WCS_Surface", ((byte)GetWeaponControlStatus_Surface(scenario_0, bool_0: false, null, bool_1: false, bool_2: false).Value).ToString());
			}
			if (m_StatusIssuer)
			{
				xmlWriter_0.WriteElementString("WCS_Surface_Player", m_StatusIssuer.ToString());
			}
			if (proccesorIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("WCS_Submarine", ((byte)GetWeaponControlStatus_Submarine(scenario_0, bool_0: false, null, bool_1: false, bool_2: false).Value).ToString());
			}
			if (strategyIssuer)
			{
				xmlWriter_0.WriteElementString("WCS_Submarine_Player", strategyIssuer.ToString());
			}
			if (_ConfigurationIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("WCS_Land", ((byte)GetWeaponControlStatus_Land(scenario_0, bool_0: false, null, bool_1: false, bool_2: false).Value).ToString());
			}
			if (m_TokenIssuer)
			{
				xmlWriter_0.WriteElementString("WCS_Land_Player", m_TokenIssuer.ToString());
			}
			if (m_PublisherIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("IPCWA", ((byte)GetIgnorePlottedCourse(scenario_0, bool_0: false, null, bool_1: false, bool_2: false).Value).ToString());
			}
			if (m_ServerIssuer)
			{
				xmlWriter_0.WriteElementString("IPCWA_Player", m_ServerIssuer.ToString());
			}
			if (m_UtilsIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("WinchesterShotgunRTB", ((byte)GetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (_PredicateIssuer)
			{
				xmlWriter_0.WriteElementString("WinchesterShotgunRTB_Player", _PredicateIssuer.ToString());
			}
			if (m_SingletonIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("BingoJokerRTB", ((byte)GetBingoJokerRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (_RecordIssuer)
			{
				xmlWriter_0.WriteElementString("BingoJokerRTB_Player", _RecordIssuer.ToString());
			}
			if (_ExceptionIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("JettisonOrdnance", ((byte)GetJettison(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (attrIssuer)
			{
				xmlWriter_0.WriteElementString("JettisonOrdnance_Player", attrIssuer.ToString());
			}
			if (visitorIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("BVRLogic", ((byte)method_0(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (exporterIssuer)
			{
				xmlWriter_0.WriteElementString("BVRLogic_Player", exporterIssuer.ToString());
			}
			if (m_PrototypeIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("BTAT", ((byte)GetBehaviorTowardsAmbigousTarget(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (comparatorIssuer)
			{
				xmlWriter_0.WriteElementString("BTAT_Player", comparatorIssuer.ToString());
			}
			if (_ItemIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("AE", ((byte)GetAutoEvade(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (_SetterIssuer)
			{
				xmlWriter_0.WriteElementString("AE_Player", _SetterIssuer.ToString());
			}
			if (creatorIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("MS", ((byte)GetMaintainStandoff(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (templateIssuer)
			{
				xmlWriter_0.WriteElementString("MS_Player", templateIssuer.ToString());
			}
			if (indexerIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("GS", ((byte)GetGunStrafing(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (m_ResolverIssuer)
			{
				xmlWriter_0.WriteElementString("GS_Player", m_ResolverIssuer.ToString());
			}
			if (paramIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("UR", ((byte)GetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value).ToString());
			}
			if (m_PageIssuer)
			{
				xmlWriter_0.WriteElementString("UR_Player", m_PageIssuer.ToString());
			}
			if (rulesIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("RS", ((byte)GetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value).ToString());
			}
			if (_MethodIssuer)
			{
				xmlWriter_0.WriteElementString("RS_Player", _MethodIssuer.ToString());
			}
			if (serviceIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("ST", ((byte)GetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (_SystemIssuer)
			{
				xmlWriter_0.WriteElementString("ST_Player", _SystemIssuer.ToString());
			}
			if (candidateIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("SAM_ASUW", ((byte)GetUseSAMsOnASuW(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (baseIssuer)
			{
				xmlWriter_0.WriteElementString("SAM_ASUW_Player", baseIssuer.ToString());
			}
			if (m_PolicyIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("WPMissile_ASUW", ((byte)GetUseWPMissileOnASuW(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (m_BroadcasterIssuer)
			{
				xmlWriter_0.WriteElementString("WPMissile_ASUW_Player", m_BroadcasterIssuer.ToString());
			}
			if (!Information.IsNothing(refIssuer))
			{
				xmlWriter_0.WriteElementString("E_Radar", ((byte)refIssuer.LoginInterruptibleField()).ToString());
				xmlWriter_0.WriteElementString("E_Sonar", ((byte)refIssuer.GetInterruptibleField()).ToString());
				xmlWriter_0.WriteElementString("E_OECM", ((byte)refIssuer.OECM()).ToString());
			}
			if (parserIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("QuickTurnAround", ((byte)GetQuickTurnAroundForAicraft(scenario_0, bool_0: false, bool_1: true, bool_2: false, bool_3: false).Value).ToString());
			}
			if (m_AlgoIssuer)
			{
				xmlWriter_0.WriteElementString("QTA_Player", m_AlgoIssuer.ToString());
			}
			if (m_DatabaseIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("AirOpsTempo", ((byte)GetAirOpsTempo(scenario_0, bool_0: false, bool_1: true, bool_2: false, bool_3: false).Value).ToString());
			}
			if (m_InterceptorIssuer)
			{
				xmlWriter_0.WriteElementString("AirOpsTempo_Player", m_InterceptorIssuer.ToString());
			}
			if (m_MessageIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("BingoJoker", ((byte)GetBingoJoker(scenario_0, bool_0: false, bool_1: true, bool_2: false, bool_3: false).Value).ToString());
			}
			if (_ProductIssuer)
			{
				xmlWriter_0.WriteElementString("BingoJoker_Player", _ProductIssuer.ToString());
			}
			if (_AnnotationIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("WinchesterShotgun", ((int)GetWinchesterShotgun(scenario_0, bool_0: false, bool_1: true, bool_2: false, bool_3: false).Value).ToString());
			}
			if (iteratorIssuer)
			{
				xmlWriter_0.WriteElementString("WinchesterShotgun_Player", iteratorIssuer.ToString());
			}
			if (structClient.HasValue)
			{
				xmlWriter_0.WriteElementString("WithdrawDamageThreshold", ((int)GetWithdrawDamageThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (m_MerchantClient.HasValue)
			{
				xmlWriter_0.WriteElementString("WithdrawFuelThreshold", ((int)GetWithdrawFuelThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (callbackClient.HasValue)
			{
				xmlWriter_0.WriteElementString("WithdrawAttackThreshold", ((int)GetWithdrawAttackThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (_DecoratorClient.HasValue)
			{
				xmlWriter_0.WriteElementString("WithdrawDefenceThreshold", ((int)GetWithdrawDefenceThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (_ProcessClient.HasValue)
			{
				xmlWriter_0.WriteElementString("RedeployDamageThreshold", ((int)GetRedeployDamageThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (threadClient.HasValue)
			{
				xmlWriter_0.WriteElementString("RedeployFuelThreshold", ((int)GetRedeployFuelThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (_RuleClient.HasValue)
			{
				xmlWriter_0.WriteElementString("RedeployAttackThreshold", ((int)GetRedeployAttackThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (m_CollectionClient.HasValue)
			{
				xmlWriter_0.WriteElementString("RedeployDefenceThreshold", ((int)GetRedeployDefenceThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (m_IdentifierIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("IgnoreEMCONUnderAttack", ((byte)GetIgnoreEMCONunderAttack(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (printerIssuer)
			{
				xmlWriter_0.WriteElementString("IgnoreEMCONUnderAttack_Player", printerIssuer.ToString());
			}
			if (m_InitializerIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("UseTorpedoesKinematicRange", ((byte)GetUseKinematicRangeForTorpedoes(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (_RoleIssuer)
			{
				xmlWriter_0.WriteElementString("UseTorpedoesKinematicRange_Player", _RoleIssuer.ToString());
			}
			if (factoryIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("RefuelAllies", ((byte)GetRefuelAllies(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (m_AttributeIssuer)
			{
				xmlWriter_0.WriteElementString("RefuelAllies_Player", m_AttributeIssuer.ToString());
			}
			if (m_EventIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("BingoThreshold", ((byte)GetBingoThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (globalIssuer)
			{
				xmlWriter_0.WriteElementString("BingoThreshold_Player", globalIssuer.ToString());
			}
			if (_WorkerIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("AvoidContact", ((byte)GetAvoidContact(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (accountIssuer)
			{
				xmlWriter_0.WriteElementString("AvoidContact_Player", accountIssuer.ToString());
			}
			if (stateIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("DiveWhenThreatsDetected", ((byte)GetDiveWhenThreatsDetected(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (m_AuthenticationIssuer)
			{
				xmlWriter_0.WriteElementString("DiveWhenThreatsDetected_Player", m_AuthenticationIssuer.ToString());
			}
			if (paramsIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("RechargePercentagePatrol", ((int)GetRechargePercentagePatrol(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (infoIssuer)
			{
				xmlWriter_0.WriteElementString("RechargePercentagePatrol_Player", infoIssuer.ToString());
			}
			if (helperIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("RechargePercentageAttack", ((int)GetRechargePercentageAttack(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (mapperIssuer)
			{
				xmlWriter_0.WriteElementString("RechargePercentageAttack_Player", mapperIssuer.ToString());
			}
			if (_ManagerIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("AIPUsage", ((byte)method_2(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (m_GetterIssuer)
			{
				xmlWriter_0.WriteElementString("AIPUsage_Player", m_GetterIssuer.ToString());
			}
			if (m_ProducerIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("DippingSonar", ((byte)GetDippingSonar(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (_ProcIssuer)
			{
				xmlWriter_0.WriteElementString("DippingSonar_Player", _ProcIssuer.ToString());
			}
			if (_MappingIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("SurfNav", ((byte)GetSurfaceNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (mockIssuer)
			{
				xmlWriter_0.WriteElementString("SurfNav_Player", mockIssuer.ToString());
			}
			if (_TagIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("SubNav", ((byte)GetSubmarineNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (m_FieldIssuer)
			{
				xmlWriter_0.WriteElementString("SubNav_Player", m_FieldIssuer.ToString());
			}
			if (m_QueueIssuer.HasValue)
			{
				xmlWriter_0.WriteElementString("LandNav", ((byte)GetLandNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString());
			}
			if (_RegIssuer)
			{
				xmlWriter_0.WriteElementString("LandNav_Player", _RegIssuer.ToString());
			}
			if (!Information.IsNothing(WRA))
			{
				xmlWriter_0.WriteStartElement("WRA");
				foreach (KeyValuePair<int, WRA_Weapon> item in WRA)
				{
					xmlWriter_0.WriteStartElement("Weapon_" + Conversions.ToString(Conversions.ToInteger(item.Key.ToString())));
					WRA_FiringDoctrineEntry[] wRA_WeaponTargets = item.Value.WRA_WeaponTargets;
					WRA_FiringDoctrineEntry[] array = wRA_WeaponTargets;
					foreach (WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry in array)
					{
						XmlWriter obj = xmlWriter_0;
						int targetType = (int)wRA_FiringDoctrineEntry.TargetType;
						obj.WriteStartElement("WeaponTarget_" + targetType);
						if ((object)SubjectType == typeof(Side))
						{
							if (!Information.IsNothing(wRA_FiringDoctrineEntry.WeaponQty))
							{
								int? weaponQty = wRA_FiringDoctrineEntry.WeaponQty;
								bool? flag = (weaponQty.HasValue ? new bool?(weaponQty.GetValueOrDefault() == -1) : null);
								if (((!flag) ?? flag).GetValueOrDefault())
								{
									xmlWriter_0.WriteElementString("WeaponQty", wRA_FiringDoctrineEntry.WeaponQty.Value.ToString());
								}
							}
							if (!Information.IsNothing(wRA_FiringDoctrineEntry.ShooterQty))
							{
								int? shooterQty = wRA_FiringDoctrineEntry.ShooterQty;
								bool? flag2 = (shooterQty.HasValue ? new bool?(shooterQty.GetValueOrDefault() == -1) : null);
								if (((!flag2) ?? flag2).GetValueOrDefault())
								{
									xmlWriter_0.WriteElementString("ShooterQty", wRA_FiringDoctrineEntry.ShooterQty.Value.ToString());
								}
							}
							if (!Information.IsNothing(wRA_FiringDoctrineEntry.SelfDefenceRange))
							{
								float? selfDefenceRange = wRA_FiringDoctrineEntry.SelfDefenceRange;
								bool? flag3 = (selfDefenceRange.HasValue ? new bool?(selfDefenceRange.GetValueOrDefault() == -1f) : null);
								if (((!flag3) ?? flag3).GetValueOrDefault())
								{
									xmlWriter_0.WriteElementString("SelfDefenceRange", wRA_FiringDoctrineEntry.SelfDefenceRange.Value.ToString());
								}
							}
							if (!Information.IsNothing(wRA_FiringDoctrineEntry.FiringRange))
							{
								xmlWriter_0.WriteElementString("FiringRange", wRA_FiringDoctrineEntry.FiringRange.Value.ToString());
							}
						}
						else
						{
							if (!Information.IsNothing(wRA_FiringDoctrineEntry.WeaponQty))
							{
								xmlWriter_0.WriteElementString("WeaponQty", wRA_FiringDoctrineEntry.WeaponQty.Value.ToString());
							}
							if (!Information.IsNothing(wRA_FiringDoctrineEntry.ShooterQty))
							{
								xmlWriter_0.WriteElementString("ShooterQty", wRA_FiringDoctrineEntry.ShooterQty.Value.ToString());
							}
							if (!Information.IsNothing(wRA_FiringDoctrineEntry.SelfDefenceRange))
							{
								xmlWriter_0.WriteElementString("SelfDefenceRange", wRA_FiringDoctrineEntry.SelfDefenceRange.Value.ToString());
							}
							if (!Information.IsNothing(wRA_FiringDoctrineEntry.FiringRange))
							{
								xmlWriter_0.WriteElementString("FiringRange", wRA_FiringDoctrineEntry.FiringRange.Value.ToString());
							}
						}
						xmlWriter_0.WriteEndElement();
					}
					xmlWriter_0.WriteEndElement();
				}
				xmlWriter_0.WriteEndElement();
			}
			if (m_ParameterClient.Count > 0)
			{
				xmlWriter_0.WriteStartElement("PTL");
				foreach (PriorityTargetEntry item2 in m_ParameterClient)
				{
					item2.ToXML(ref xmlWriter_0, ref scenario_0, string_0);
				}
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101003", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Doctrine FromXML(ref XmlNode xmlNode_0, ScenarioObject scenarioObject_0)
	{
		try
		{
			List<ActiveUnit> list_ = null;
			Doctrine doctrine = new Doctrine(scenarioObject_0, ref list_);
			if ((object)scenarioObject_0.GetType() == typeof(Side))
			{
				doctrine._SchemaIssuer = false;
				doctrine.connectionIssuer = false;
				doctrine.m_StatusIssuer = false;
				doctrine.strategyIssuer = false;
				doctrine.m_TokenIssuer = false;
				doctrine.m_ResolverIssuer = false;
				doctrine.m_ServerIssuer = false;
				doctrine.comparatorIssuer = false;
				doctrine._SetterIssuer = false;
				doctrine.templateIssuer = false;
				doctrine.m_PageIssuer = false;
				doctrine._MethodIssuer = false;
				doctrine._SystemIssuer = false;
				doctrine.baseIssuer = false;
				doctrine.printerIssuer = false;
				doctrine.m_AlgoIssuer = false;
				doctrine.m_InterceptorIssuer = false;
				doctrine.iteratorIssuer = false;
				doctrine._PredicateIssuer = false;
				doctrine._ProductIssuer = false;
				doctrine._RecordIssuer = false;
				doctrine.attrIssuer = false;
				doctrine.exporterIssuer = false;
				doctrine._RoleIssuer = false;
				doctrine.m_AttributeIssuer = false;
				doctrine.accountIssuer = false;
				doctrine.m_AuthenticationIssuer = false;
				doctrine.infoIssuer = false;
				doctrine.mapperIssuer = false;
				doctrine.m_GetterIssuer = false;
				doctrine._ProcIssuer = false;
				doctrine.globalIssuer = false;
			}
			IEnumerator enumerator = null;
			EMCONSettings._EMCONSetting? eMCONSetting = null;
			EMCONSettings._EMCONSetting? eMCONSetting2 = null;
			EMCONSettings._EMCONSetting? eMCONSetting3 = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				IEnumerator enumerator3 = null;
				IEnumerator enumerator4 = null;
				IEnumerator enumerator5 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "AvoidContact_Player":
						doctrine.accountIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "IgnoreEMCONUnderAttack_Player":
						doctrine.printerIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "RS_Player":
						doctrine._MethodIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "WCS_Submarine_Player":
						doctrine.strategyIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "QuickTurnAround":
						doctrine.SetQuickTurnAroundForAicraft(null, bool_0: false, bool_1: true, bool_2: true, bool_3: true, (_QuickTurnAroundForAicraft)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "RedeployFuelThreshold":
						doctrine.SetRedeployFuelThreshold(null, bool_0: false, bool_1: true, bool_2: true, (_FuelQuantityThreshold)Conversions.ToShort(xmlNode.InnerText));
						break;
					case "SubNav":
						doctrine.SetSubmarineNavigation(null, bool_0: false, bool_1: true, bool_2: true, (_NavigationMethod)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "WPMissile_ASUW_Player":
						doctrine.m_BroadcasterIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "SubNav_Player":
						doctrine.m_FieldIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "MS_Player":
						doctrine.templateIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "AE":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							if (Operators.CompareString(xmlNode.InnerText, "255", TextCompare: false) == 0)
							{
								doctrine.SetAutoEvade(null, bool_0: false, bool_1: true, bool_2: true, _UseAutoEvade.Yes);
							}
							else
							{
								doctrine.SetAutoEvade(null, bool_0: false, bool_1: true, bool_2: true, (_UseAutoEvade)Conversions.ToByte(xmlNode.InnerText));
							}
						}
						else if (Conversions.ToBoolean(xmlNode.InnerText))
						{
							doctrine.SetAutoEvade(null, bool_0: false, bool_1: true, bool_2: true, _UseAutoEvade.Yes);
						}
						else
						{
							doctrine.SetAutoEvade(null, bool_0: false, bool_1: true, bool_2: true, _UseAutoEvade.No);
						}
						break;
					case "WCS_Surface_Player":
						doctrine.m_StatusIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "LandNav_Player":
						doctrine._RegIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "JettisonOrdnance":
						doctrine.SetJettison(null, bool_0: false, bool_1: true, bool_2: true, (_JettisonOrdnance)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "BingoJokerRTB":
						doctrine.SetBingoJokerRTB(null, bool_0: false, bool_1: true, bool_2: true, (_FuelStateRTB)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "AirOpsTempo_Player":
						doctrine.m_InterceptorIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "SurfNav_Player":
						doctrine.mockIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "MS":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							if (Operators.CompareString(xmlNode.InnerText, "255", TextCompare: false) == 0)
							{
								doctrine.SetMaintainStandoff(null, bool_0: false, bool_1: true, bool_2: true, _UseMaintainStandoff.Yes);
							}
							else
							{
								doctrine.SetMaintainStandoff(null, bool_0: false, bool_1: true, bool_2: true, (_UseMaintainStandoff)Conversions.ToByte(xmlNode.InnerText));
							}
						}
						else if (Conversions.ToBoolean(xmlNode.InnerText))
						{
							doctrine.SetMaintainStandoff(null, bool_0: false, bool_1: true, bool_2: true, _UseMaintainStandoff.Yes);
						}
						else
						{
							doctrine.SetMaintainStandoff(null, bool_0: false, bool_1: true, bool_2: true, _UseMaintainStandoff.No);
						}
						break;
					case "WCS_Air_Player":
						doctrine.connectionIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "BingoJokerRTB_Player":
						doctrine._RecordIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "RechargePercentageAttack":
						doctrine.SetRechargePercentageAttack(null, bool_0: false, bool_1: true, bool_2: true, (_RechargeBatteryPercentage)Conversions.ToInteger(xmlNode.InnerText));
						break;
					case "GS_Player":
						doctrine.m_ResolverIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "SAM_ASUW":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							if (Operators.CompareString(xmlNode.InnerText, "255", TextCompare: false) == 0)
							{
								doctrine.SetUseSAMsOnASuW(null, bool_0: false, bool_1: true, bool_2: true, _UseSAMsAgainstShips.No);
							}
							else
							{
								doctrine.SetUseSAMsOnASuW(null, bool_0: false, bool_1: true, bool_2: true, (_UseSAMsAgainstShips)Conversions.ToByte(xmlNode.InnerText));
							}
						}
						else
						{
							doctrine.SetUseSAMsOnASuW(null, bool_0: false, bool_1: true, bool_2: true, (_UseSAMsAgainstShips)(-(Conversions.ToBoolean(xmlNode.InnerText) ? 1 : 0)));
						}
						break;
					case "UseTorpedoesKinematicRange_Player":
						doctrine._RoleIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "DiveWhenThreatsDetected":
						doctrine.SetDiveWhenThreatsDetected(null, bool_0: false, bool_1: true, bool_2: true, (_DiveOnContact)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "IgnoreEMCONUnderAttack":
						doctrine.SetIgnoreEMCONunderAttack(null, bool_0: false, bool_1: true, bool_2: true, (_UseIgnoreEMCONunderAttack)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "WRA":
						doctrine.m_ErrorIssuer = new Dictionary<int, WRA_Weapon>();
						try
						{
							enumerator3 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator3.Current;
								if (Operators.CompareString(xmlNode2.Name, "#comment", TextCompare: false) == 0)
								{
									continue;
								}
								int key = Conversions.ToInteger(xmlNode2.Name.Split('_')[1]);
								WRA_Weapon wRA_Weapon = new WRA_Weapon();
								doctrine.m_ErrorIssuer.Add(key, wRA_Weapon);
								try
								{
									enumerator4 = xmlNode2.ChildNodes.GetEnumerator();
									while (enumerator4.MoveNext())
									{
										XmlNode xmlNode3 = (XmlNode)enumerator4.Current;
										if (Operators.CompareString(xmlNode3.Name, "#comment", TextCompare: false) == 0)
										{
											continue;
										}
										WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry = new WRA_FiringDoctrineEntry((_WRA_WeaponTargetType)Conversions.ToInteger(xmlNode3.Name.Split('_')[1]));
										try
										{
											enumerator5 = xmlNode3.ChildNodes.GetEnumerator();
											while (enumerator5.MoveNext())
											{
												XmlNode xmlNode4 = (XmlNode)enumerator5.Current;
												switch (xmlNode4.Name)
												{
												case "WeaponQty":
													wRA_FiringDoctrineEntry.WeaponQty = Conversions.ToInteger(xmlNode4.InnerText);
													break;
												case "ShooterQty":
													wRA_FiringDoctrineEntry.ShooterQty = Conversions.ToInteger(xmlNode4.InnerText);
													break;
												case "SelfDefenceRange":
													wRA_FiringDoctrineEntry.SelfDefenceRange = Conversions.ToSingle(xmlNode4.InnerText);
													break;
												case "FiringRange":
													wRA_FiringDoctrineEntry.FiringRange = Conversions.ToSingle(xmlNode4.InnerText);
													break;
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
										ArrayExtensions.Add(ref wRA_Weapon.WRA_WeaponTargets, wRA_FiringDoctrineEntry);
									}
								}
								finally
								{
									if (enumerator4 is IDisposable)
									{
										(enumerator4 as IDisposable).Dispose();
									}
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
					case "IPCWA_Player":
						doctrine.m_ServerIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "DippingSonar":
						doctrine.SetDippingSonar(null, bool_0: false, bool_1: true, bool_2: true, (_UseDippingSonar)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "BTAT_Player":
						doctrine.comparatorIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "ST":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							if (Operators.CompareString(xmlNode.InnerText, "255", TextCompare: false) == 0)
							{
								doctrine.SetShootTourists(null, bool_0: false, bool_1: true, bool_2: true, _UseShootTourists.No);
							}
							else
							{
								doctrine.SetShootTourists(null, bool_0: false, bool_1: true, bool_2: true, (_UseShootTourists)Conversions.ToByte(xmlNode.InnerText));
							}
						}
						else if ((object)doctrine.SubjectType == typeof(Side))
						{
							doctrine.SetShootTourists(null, bool_0: false, bool_1: true, bool_2: true, _UseShootTourists.No);
						}
						else
						{
							doctrine.SetShootTourists(null, bool_0: false, bool_1: true, bool_2: true, (_UseShootTourists)(-(Conversions.ToBoolean(xmlNode.InnerText) ? 1 : 0)));
						}
						break;
					case "UR":
						if (Operators.CompareString(xmlNode.InnerText, "255", TextCompare: false) == 0)
						{
							doctrine.SetUseReplenishment(null, bool_0: false, bool_1: true, bool_2: true, bool_3: false, _UseUnderwayRefuelAndReplenishment.Always_ExceptTankersRefuellingTankers);
						}
						else
						{
							doctrine.SetUseReplenishment(null, bool_0: false, bool_1: true, bool_2: true, bool_3: false, (_UseUnderwayRefuelAndReplenishment)Conversions.ToByte(xmlNode.InnerText));
						}
						break;
					case "GS":
						doctrine.SetGunStrafing(null, bool_0: false, bool_1: true, bool_2: true, (_GunStrafeGroundTargets)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "SurfNav":
						doctrine.SetSurfaceNavigation(null, bool_0: false, bool_1: true, bool_2: true, (_NavigationMethod)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "BingoJoker_Player":
						doctrine._ProductIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "AE_Player":
						doctrine._SetterIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "RS":
						doctrine.SetReplenishmentSelection(null, bool_0: false, bool_1: true, bool_2: true, bool_3: false, (_UnderwayRefuelAndReplenishmentSelection)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "IPCWA":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							if (Operators.CompareString(xmlNode.InnerText, "255", TextCompare: false) == 0)
							{
								doctrine.SetIgnorePlottedCourse(null, bool_0: false, null, bool_1: true, bool_2: true, _UseIgnorePlottedCourse.Yes);
							}
							else
							{
								doctrine.SetIgnorePlottedCourse(null, bool_0: false, null, bool_1: true, bool_2: true, (_UseIgnorePlottedCourse)Conversions.ToByte(xmlNode.InnerText));
							}
						}
						else if (Conversions.ToBoolean(xmlNode.InnerText))
						{
							doctrine.SetIgnorePlottedCourse(null, bool_0: false, null, bool_1: true, bool_2: true, _UseIgnorePlottedCourse.Yes);
						}
						else
						{
							doctrine.SetIgnorePlottedCourse(null, bool_0: false, null, bool_1: true, bool_2: true, _UseIgnorePlottedCourse.No);
						}
						break;
					case "RefuelAllies_Player":
						doctrine.m_AttributeIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "RedeployDamageThreshold":
						doctrine.SetRedeployDamageThreshold(null, bool_0: false, bool_1: true, bool_2: true, (_DamageThreshold)Conversions.ToShort(xmlNode.InnerText));
						break;
					case "BingoJoker":
						doctrine.SetBingoJoker(null, bool_0: false, bool_1: true, bool_2: true, bool_3: true, (_FuelState)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "WithdrawDefenceThreshold":
						doctrine.SetWithdrawDefenceThreshold(null, bool_0: false, bool_1: true, bool_2: true, (_WeaponQuantityThreshold)Conversions.ToShort(xmlNode.InnerText));
						break;
					case "EMCON_Radar":
					case "E_Radar":
						eMCONSetting2 = (EMCONSettings._EMCONSetting)XmlConvert.ToByte(xmlNode.InnerText);
						break;
					case "RechargePercentagePatrol":
						doctrine.SetRechargePercentagePatrol(null, bool_0: false, bool_1: true, bool_2: true, (_RechargeBatteryPercentage)Conversions.ToInteger(xmlNode.InnerText));
						break;
					case "BVRLogic":
						doctrine.method_1(null, bool_0: false, bool_1: true, bool_2: true, (_BVRLogicEnum)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "WinchesterShotgun":
						doctrine.SetWinchesterShotgun(null, bool_0: false, bool_1: true, bool_2: true, bool_3: true, (_WeaponState)Conversions.ToInteger(xmlNode.InnerText));
						break;
					case "WithdrawFuelThreshold":
						doctrine.SetWithdrawFuelThreshold(null, bool_0: false, bool_1: true, bool_2: true, (_FuelQuantityThreshold)Conversions.ToShort(xmlNode.InnerText));
						break;
					case "PTL":
						doctrine.m_ParameterClient.Clear();
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
								PriorityTargetEntry item = PriorityTargetEntry.FromXML(ref xmlNode_);
								doctrine.m_ParameterClient.Add(item);
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
					case "EMCON_Sonar":
					case "E_Sonar":
						eMCONSetting3 = (EMCONSettings._EMCONSetting)XmlConvert.ToByte(xmlNode.InnerText);
						break;
					case "SAM_ASUW_Player":
						doctrine.baseIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "UseTorpedoesKinematicRange":
						doctrine.SetUseKinematicRangeForTorpedoes(null, bool_0: false, bool_1: true, bool_2: true, (_UseKinematicRangeForTorpedoes)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "WPMissile_ASUW":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							if (Operators.CompareString(xmlNode.InnerText, "255", TextCompare: false) == 0)
							{
								doctrine.SetUseWPMissileOnASuW(null, bool_0: false, bool_1: true, bool_2: true, _UseWpMissileAgainstShips.No);
							}
							else
							{
								doctrine.SetUseWPMissileOnASuW(null, bool_0: false, bool_1: true, bool_2: true, (_UseWpMissileAgainstShips)Conversions.ToByte(xmlNode.InnerText));
							}
						}
						else
						{
							doctrine.SetUseWPMissileOnASuW(null, bool_0: false, bool_1: true, bool_2: true, (_UseWpMissileAgainstShips)(-(Conversions.ToBoolean(xmlNode.InnerText) ? 1 : 0)));
						}
						break;
					case "WCS_Land_Player":
						doctrine.m_TokenIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "AvoidContact":
						doctrine.SetAvoidContact(null, bool_0: false, bool_1: true, bool_2: true, (_AvoidContactWhenPossible)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "SFirst":
					case "WCS_Air":
					case "ShootFirst":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							if (Operators.CompareString(xmlNode.InnerText, "255", TextCompare: false) == 0)
							{
								doctrine.SetWeaponControlStatus_Air(null, bool_0: false, null, bool_1: true, bool_2: true, _WCS.Free);
							}
							else
							{
								doctrine.SetWeaponControlStatus_Air(null, bool_0: false, null, bool_1: true, bool_2: true, (_WCS)Conversions.ToByte(xmlNode.InnerText));
							}
						}
						else if (Conversions.ToBoolean(xmlNode.InnerText))
						{
							doctrine.SetWeaponControlStatus_Air(null, bool_0: false, null, bool_1: true, bool_2: true, _WCS.Free);
							doctrine.SetWeaponControlStatus_Surface(null, bool_0: false, null, bool_1: true, bool_2: true, _WCS.Free);
							doctrine.SetWeaponControlStatus_Submarine(null, bool_0: false, null, bool_1: true, bool_2: true, _WCS.Free);
							doctrine.SetWeaponControlStatus_Land(null, bool_0: false, null, bool_1: true, bool_2: true, _WCS.Free);
						}
						else
						{
							doctrine.SetWeaponControlStatus_Air(null, bool_0: false, null, bool_1: true, bool_2: true, _WCS.Tight);
							doctrine.SetWeaponControlStatus_Surface(null, bool_0: false, null, bool_1: true, bool_2: true, _WCS.Tight);
							doctrine.SetWeaponControlStatus_Submarine(null, bool_0: false, null, bool_1: true, bool_2: true, _WCS.Tight);
							doctrine.SetWeaponControlStatus_Land(null, bool_0: false, null, bool_1: true, bool_2: true, _WCS.Tight);
						}
						break;
					case "RefuelAllies":
						doctrine.SetRefuelAllies(null, bool_0: false, bool_1: true, bool_2: true, (_RefuelAlliedUnits)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "NukesAllowed_Inherits":
						if (Conversions.ToBoolean(xmlNode.InnerText))
						{
							doctrine._AdapterIssuer = null;
						}
						break;
					case "QuickTurnAround_Player":
					case "QTA_Player":
						doctrine.m_AlgoIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "BehaviorTowardsAmbigousTarget":
					case "BTAT":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							if (Operators.CompareString(xmlNode.InnerText, "255", TextCompare: false) == 0)
							{
								doctrine.SetBehaviorTowardsAmbigousTarget(null, bool_0: false, bool_1: true, bool_2: true, _BehaviorTowardsTargetAmbiguity.Pessimistic);
							}
							else
							{
								doctrine.SetBehaviorTowardsAmbigousTarget(null, bool_0: false, bool_1: true, bool_2: true, (_BehaviorTowardsTargetAmbiguity)Conversions.ToByte(xmlNode.InnerText));
							}
						}
						else if (Conversions.ToBoolean(xmlNode.InnerText))
						{
							doctrine.SetBehaviorTowardsAmbigousTarget(null, bool_0: false, bool_1: true, bool_2: true, _BehaviorTowardsTargetAmbiguity.Pessimistic);
						}
						else
						{
							doctrine.SetBehaviorTowardsAmbigousTarget(null, bool_0: false, bool_1: true, bool_2: true, _BehaviorTowardsTargetAmbiguity.Optimistic);
						}
						break;
					case "EMCON_OECM":
					case "E_OECM":
						eMCONSetting = (EMCONSettings._EMCONSetting)XmlConvert.ToByte(xmlNode.InnerText);
						break;
					case "LandNav":
						doctrine.SetLandNavigation(null, bool_0: false, bool_1: true, bool_2: true, (_NavigationMethod)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "WinchesterShotgun_Player":
						doctrine.iteratorIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "Nukes_Player":
						doctrine._SchemaIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "BVRLogic_Player":
						doctrine.exporterIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "RedeployDefenceThreshold":
						doctrine.SetRedeployDefenceThreshold(null, bool_0: false, bool_1: true, bool_2: true, (_WeaponQuantityThreshold)Conversions.ToShort(xmlNode.InnerText));
						break;
					case "ST_Player":
						doctrine._SystemIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "WithdrawAttackThreshold":
						doctrine.SetWithdrawAttackThreshold(null, bool_0: false, bool_1: true, bool_2: true, (_WeaponQuantityThreshold)Conversions.ToShort(xmlNode.InnerText));
						break;
					case "RechargePercentagePatrol_Player":
						doctrine.infoIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "RedeployAttackThreshold":
						doctrine.SetRedeployAttackThreshold(null, bool_0: false, bool_1: true, bool_2: true, (_WeaponQuantityThreshold)Conversions.ToShort(xmlNode.InnerText));
						break;
					case "RTBWW_Player":
					case "WinchesterShotgunRTB_Player":
						doctrine._PredicateIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "NukesAllowed":
					case "Nukes":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							if (Operators.CompareString(xmlNode.InnerText, "255", TextCompare: false) == 0)
							{
								doctrine.SetNukesAllowed(null, bool_0: false, bool_1: true, bool_2: true, _UseNukesAllowed.Yes);
							}
							else
							{
								doctrine.SetNukesAllowed(null, bool_0: false, bool_1: true, bool_2: true, (_UseNukesAllowed)Conversions.ToByte(xmlNode.InnerText));
							}
						}
						else if (Conversions.ToBoolean(xmlNode.InnerText))
						{
							doctrine.SetNukesAllowed(null, bool_0: false, bool_1: true, bool_2: true, _UseNukesAllowed.Yes);
						}
						else
						{
							doctrine.SetNukesAllowed(null, bool_0: false, bool_1: true, bool_2: true, _UseNukesAllowed.No);
						}
						break;
					case "DippingSonar_Player":
						doctrine._ProcIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "AirOpsTempo":
						doctrine.SetAirOpsTempo(null, bool_0: false, bool_1: true, bool_2: true, bool_3: true, (_AirOpsTempo)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "BingoThreshold":
						doctrine.SetBingoThreshold(null, bool_0: false, bool_1: true, bool_2: true, (_BingoThreshold_E)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "AIPUsage":
						doctrine.method_3(null, bool_0: false, bool_1: true, bool_2: true, (_UseAIP)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "BingoThreshold_Player":
						doctrine.globalIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "WCS_Land":
						doctrine.SetWeaponControlStatus_Land(null, bool_0: false, null, bool_1: true, bool_2: true, (_WCS)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "RTBWW":
					case "RTBWhenWinchester":
					case "WinchesterShotgunRTB":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							if (Operators.CompareString(xmlNode.InnerText, "255", TextCompare: false) == 0)
							{
								doctrine.SetWinchesterShotgunRTB(null, bool_0: false, bool_1: true, bool_2: true, _WeaponStateRTB.YesLeaveGroup);
							}
							else
							{
								doctrine.SetWinchesterShotgunRTB(null, bool_0: false, bool_1: true, bool_2: true, (_WeaponStateRTB)Conversions.ToByte(xmlNode.InnerText));
							}
						}
						else if (Conversions.ToBoolean(xmlNode.InnerText))
						{
							doctrine.SetWinchesterShotgunRTB(null, bool_0: false, bool_1: true, bool_2: true, _WeaponStateRTB.YesLeaveGroup);
						}
						else
						{
							doctrine.SetWinchesterShotgunRTB(null, bool_0: false, bool_1: true, bool_2: true, _WeaponStateRTB.No);
						}
						break;
					case "WCS_Submarine":
						doctrine.SetWeaponControlStatus_Submarine(null, bool_0: false, null, bool_1: true, bool_2: true, (_WCS)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "WithdrawDamageThreshold":
						doctrine.SetWithdrawDamageThreshold(null, bool_0: false, bool_1: true, bool_2: true, (_DamageThreshold)Conversions.ToShort(xmlNode.InnerText));
						break;
					case "RechargePercentageAttack_Player":
						doctrine.mapperIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "WCS_Surface":
						doctrine.SetWeaponControlStatus_Surface(null, bool_0: false, null, bool_1: true, bool_2: true, (_WCS)Conversions.ToByte(xmlNode.InnerText));
						break;
					case "DiveWhenThreatsDetected_Player":
						doctrine.m_AuthenticationIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "UR_Player":
						doctrine.m_PageIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "AIPUsage_Player":
						doctrine.m_GetterIssuer = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "JettisonOrdnance_Player":
						doctrine.attrIssuer = Conversions.ToBoolean(xmlNode.InnerText);
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
			if (eMCONSetting2.HasValue || eMCONSetting3.HasValue || eMCONSetting.HasValue)
			{
				doctrine.refIssuer = new EMCONSettings(eMCONSetting2.Value, eMCONSetting3.Value, eMCONSetting.Value);
			}
			return doctrine;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101004", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<ActiveUnit> list_2 = null;
			Doctrine result = new Doctrine(scenarioObject_0, ref list_2);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public void Populate_Combo_UseNukes(ComboBox comboBox_0, ref Scenario scenario_0, _UseNukesAllowed? nullable_0)
	{
		_UseNukesAllowed? nukesAllowed = GetNukesAllowed(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_NukesAllowed(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (NukesAllowed_Inherits())
		{
			comboBox.SelectedIndex = 2;
		}
		else
		{
			_UseNukesAllowed? useNukesAllowed = nukesAllowed;
			byte? b = (byte?)useNukesAllowed;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)useNukesAllowed;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)useNukesAllowed;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 3;
					}
					else
					{
						b = (byte?)useNukesAllowed;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_UseNukes(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetNukesAllowed(scenario_0, bool_0: true, bool_0, bool_1, _UseNukesAllowed.Yes);
				}
			}
			SetNukesAllowed(scenario_0, bool_0: false, bool_0, bool_1, _UseNukesAllowed.Yes);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetNukesAllowed(scenario_0, bool_0: true, bool_0, bool_1, _UseNukesAllowed.No);
				}
			}
			SetNukesAllowed(scenario_0, bool_0: false, bool_0, bool_1, _UseNukesAllowed.No);
			break;
		case 2:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetNukesAllowed(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetNukesAllowed(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_WeaponControlStatus_Air(ComboBox comboBox_0, ref Scenario scenario_0, _WCS? nullable_0)
	{
		_WCS? weaponControlStatus_Air = GetWeaponControlStatus_Air(scenario_0, bool_0: false, null, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_WeaponControlStatus_Air(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (WeaponControlStatus_Air_Inherits())
		{
			comboBox.SelectedIndex = 3;
		}
		else
		{
			_WCS? wCS = weaponControlStatus_Air;
			byte? b = (byte?)wCS;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)wCS;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)wCS;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)wCS;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 4;
						}
						else
						{
							b = (byte?)wCS;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_WeaponControlStatus_Air(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetWeaponControlStatus_Air(scenario_0, bool_0: true, false, bool_0, bool_1, _WCS.Free);
				}
			}
			SetWeaponControlStatus_Air(scenario_0, bool_0: false, false, bool_0, bool_1, _WCS.Free);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetWeaponControlStatus_Air(scenario_0, bool_0: true, false, bool_0, bool_1, _WCS.Tight);
				}
			}
			SetWeaponControlStatus_Air(scenario_0, bool_0: false, false, bool_0, bool_1, _WCS.Tight);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetWeaponControlStatus_Air(scenario_0, bool_0: true, false, bool_0, bool_1, _WCS.Hold);
				}
			}
			SetWeaponControlStatus_Air(scenario_0, bool_0: false, false, bool_0, bool_1, _WCS.Hold);
			break;
		case 3:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetWeaponControlStatus_Air(scenario_0, bool_0: true, null, bool_0, bool_1, null);
				}
			}
			SetWeaponControlStatus_Air(scenario_0, bool_0: false, false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_WeaponControlStatus_Surface(ComboBox comboBox_0, ref Scenario scenario_0, _WCS? nullable_0)
	{
		_WCS? weaponControlStatus_Surface = GetWeaponControlStatus_Surface(scenario_0, bool_0: false, null, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_WeaponControlStatus_Surface(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (WeaponControlStatus_Surface_Inherits())
		{
			comboBox.SelectedIndex = 3;
		}
		else
		{
			_WCS? wCS = weaponControlStatus_Surface;
			byte? b = (byte?)wCS;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)wCS;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)wCS;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)wCS;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 4;
						}
						else
						{
							b = (byte?)wCS;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_WeaponControlStatus_Surface(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetWeaponControlStatus_Surface(scenario_0, bool_0: true, false, bool_0, bool_1, _WCS.Free);
				}
			}
			SetWeaponControlStatus_Surface(scenario_0, bool_0: false, false, bool_0, bool_1, _WCS.Free);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetWeaponControlStatus_Surface(scenario_0, bool_0: true, false, bool_0, bool_1, _WCS.Tight);
				}
			}
			SetWeaponControlStatus_Surface(scenario_0, bool_0: false, false, bool_0, bool_1, _WCS.Tight);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetWeaponControlStatus_Surface(scenario_0, bool_0: true, false, bool_0, bool_1, _WCS.Hold);
				}
			}
			SetWeaponControlStatus_Surface(scenario_0, bool_0: false, false, bool_0, bool_1, _WCS.Hold);
			break;
		case 3:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetWeaponControlStatus_Surface(scenario_0, bool_0: true, null, bool_0, bool_1, null);
				}
			}
			SetWeaponControlStatus_Surface(scenario_0, bool_0: false, false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_WeaponControlStatus_Submarine(ComboBox comboBox_0, ref Scenario scenario_0, _WCS? nullable_0)
	{
		_WCS? weaponControlStatus_Submarine = GetWeaponControlStatus_Submarine(scenario_0, bool_0: false, null, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_WeaponControlStatus_Submarine(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (WeaponControlStatus_Submarine_Inherits())
		{
			comboBox.SelectedIndex = 3;
		}
		else
		{
			_WCS? wCS = weaponControlStatus_Submarine;
			byte? b = (byte?)wCS;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)wCS;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)wCS;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)wCS;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 4;
						}
						else
						{
							b = (byte?)wCS;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_WeaponControlStatus_Submarine(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetWeaponControlStatus_Submarine(scenario_0, bool_0: true, false, bool_0, bool_1, _WCS.Free);
				}
			}
			SetWeaponControlStatus_Submarine(scenario_0, bool_0: false, false, bool_0, bool_1, _WCS.Free);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetWeaponControlStatus_Submarine(scenario_0, bool_0: true, false, bool_0, bool_1, _WCS.Tight);
				}
			}
			SetWeaponControlStatus_Submarine(scenario_0, bool_0: false, false, bool_0, bool_1, _WCS.Tight);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetWeaponControlStatus_Submarine(scenario_0, bool_0: true, false, bool_0, bool_1, _WCS.Hold);
				}
			}
			SetWeaponControlStatus_Submarine(scenario_0, bool_0: false, false, bool_0, bool_1, _WCS.Hold);
			break;
		case 3:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetWeaponControlStatus_Submarine(scenario_0, bool_0: true, null, bool_0, bool_1, null);
				}
			}
			SetWeaponControlStatus_Submarine(scenario_0, bool_0: false, false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_WeaponControlStatus_Land(ComboBox comboBox_0, ref Scenario scenario_0, _WCS? nullable_0)
	{
		_WCS? weaponControlStatus_Land = GetWeaponControlStatus_Land(scenario_0, bool_0: false, null, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_WeaponControlStatus_Land(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (WeaponControlStatus_Land_Inherits())
		{
			comboBox.SelectedIndex = 3;
		}
		else
		{
			_WCS? wCS = weaponControlStatus_Land;
			byte? b = (byte?)wCS;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)wCS;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)wCS;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)wCS;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 4;
						}
						else
						{
							b = (byte?)wCS;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_WeaponControlStatus_Land(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetWeaponControlStatus_Land(scenario_0, bool_0: true, false, bool_0, bool_1, _WCS.Free);
				}
			}
			SetWeaponControlStatus_Land(scenario_0, bool_0: false, false, bool_0, bool_1, _WCS.Free);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetWeaponControlStatus_Land(scenario_0, bool_0: true, false, bool_0, bool_1, _WCS.Tight);
				}
			}
			SetWeaponControlStatus_Land(scenario_0, bool_0: false, false, bool_0, bool_1, _WCS.Tight);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetWeaponControlStatus_Land(scenario_0, bool_0: true, false, bool_0, bool_1, _WCS.Hold);
				}
			}
			SetWeaponControlStatus_Land(scenario_0, bool_0: false, false, bool_0, bool_1, _WCS.Hold);
			break;
		case 3:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetWeaponControlStatus_Land(scenario_0, bool_0: true, null, bool_0, bool_1, null);
				}
			}
			SetWeaponControlStatus_Land(scenario_0, bool_0: false, false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_IgnorePlottedCourse(ComboBox comboBox_0, ref Scenario scenario_0, _UseIgnorePlottedCourse? nullable_0)
	{
		_UseIgnorePlottedCourse? ignorePlottedCourse = GetIgnorePlottedCourse(scenario_0, bool_0: false, null, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_IgnorePlottedCourse(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (IgnorePlottedCourse_Inherits())
		{
			comboBox.SelectedIndex = 2;
		}
		else
		{
			_UseIgnorePlottedCourse? useIgnorePlottedCourse = ignorePlottedCourse;
			byte? b = (byte?)useIgnorePlottedCourse;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)useIgnorePlottedCourse;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)useIgnorePlottedCourse;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 3;
					}
					else
					{
						b = (byte?)useIgnorePlottedCourse;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_IgnorePlottedCourse(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetIgnorePlottedCourse(scenario_0, bool_0: true, false, bool_0, bool_1, _UseIgnorePlottedCourse.Yes);
				}
			}
			SetIgnorePlottedCourse(scenario_0, bool_0: false, false, bool_0, bool_1, _UseIgnorePlottedCourse.Yes);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetIgnorePlottedCourse(scenario_0, bool_0: true, false, bool_0, bool_1, _UseIgnorePlottedCourse.No);
				}
			}
			SetIgnorePlottedCourse(scenario_0, bool_0: false, false, bool_0, bool_1, _UseIgnorePlottedCourse.No);
			break;
		case 2:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetIgnorePlottedCourse(scenario_0, bool_0: true, null, bool_0, bool_1, null);
				}
			}
			SetIgnorePlottedCourse(scenario_0, bool_0: false, false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_WinchesterShotgunRTB(ComboBox comboBox_0, ref Scenario scenario_0, _WeaponStateRTB? nullable_0)
	{
		_WeaponStateRTB? winchesterShotgunRTB = GetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_WeaponStateRTB(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (WinchesterShotgunRTB_Inherits())
		{
			comboBox.SelectedIndex = 4;
		}
		else
		{
			_WeaponStateRTB? weaponStateRTB = winchesterShotgunRTB;
			byte? b = (byte?)weaponStateRTB;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)weaponStateRTB;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)weaponStateRTB;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)weaponStateRTB;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
						else
						{
							b = (byte?)weaponStateRTB;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 5;
							}
							else
							{
								b = (byte?)weaponStateRTB;
								if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									comboBox.SelectedIndex = 5;
								}
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_WinchesterShotgunRTB(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: true, bool_0, bool_1, _WeaponStateRTB.YesLeaveGroup);
				}
			}
			SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_0, bool_1, _WeaponStateRTB.YesLeaveGroup);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: true, bool_0, bool_1, _WeaponStateRTB.YesFirstUnit);
				}
			}
			SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_0, bool_1, _WeaponStateRTB.YesFirstUnit);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: true, bool_0, bool_1, _WeaponStateRTB.YesLastUnit);
				}
			}
			SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_0, bool_1, _WeaponStateRTB.YesLastUnit);
			break;
		case 3:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: true, bool_0, bool_1, _WeaponStateRTB.No);
				}
			}
			SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_0, bool_1, _WeaponStateRTB.No);
			break;
		case 4:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				return;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit5 in SelectedUnits)
				{
					selectedUnit5.Doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
		if (comboBox_0.SelectedIndex < 0)
		{
			return;
		}
		foreach (ActiveUnit item in LoginRepository(scenario_0, null))
		{
			if (item.IsAircraft)
			{
				item.WeaponState = ActiveUnit._ActiveUnitWeaponState.None;
				if (item.IsOperating())
				{
					item.AI.EvaluateUnitStatus(0f, bool_0: false, bool_1: true);
				}
			}
		}
	}

	public void Populate_Combo_BingoJokerRTB(ComboBox comboBox_0, ref Scenario scenario_0, _FuelStateRTB? nullable_0)
	{
		_FuelStateRTB? bingoJokerRTB = GetBingoJokerRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_FuelStateRTB(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (BingoJokerRTB_Inherits())
		{
			comboBox.SelectedIndex = 4;
		}
		else
		{
			_FuelStateRTB? fuelStateRTB = bingoJokerRTB;
			byte? b = (byte?)fuelStateRTB;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)fuelStateRTB;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)fuelStateRTB;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)fuelStateRTB;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
						else
						{
							b = (byte?)fuelStateRTB;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 5;
							}
							else
							{
								b = (byte?)fuelStateRTB;
								if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									comboBox.SelectedIndex = 5;
								}
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_BingoJokerRTB(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetBingoJokerRTB(scenario_0, bool_0: true, bool_0, bool_1, _FuelStateRTB.YesLeaveGroup);
				}
			}
			SetBingoJokerRTB(scenario_0, bool_0: false, bool_0, bool_1, _FuelStateRTB.YesLeaveGroup);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetBingoJokerRTB(scenario_0, bool_0: true, bool_0, bool_1, _FuelStateRTB.YesFirstUnit);
				}
			}
			SetBingoJokerRTB(scenario_0, bool_0: false, bool_0, bool_1, _FuelStateRTB.YesFirstUnit);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetBingoJokerRTB(scenario_0, bool_0: true, bool_0, bool_1, _FuelStateRTB.YesLastUnit);
				}
			}
			SetBingoJokerRTB(scenario_0, bool_0: false, bool_0, bool_1, _FuelStateRTB.YesLastUnit);
			break;
		case 3:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetBingoJokerRTB(scenario_0, bool_0: true, bool_0, bool_1, _FuelStateRTB.No);
				}
			}
			SetBingoJokerRTB(scenario_0, bool_0: false, bool_0, bool_1, _FuelStateRTB.No);
			break;
		case 4:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				return;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit5 in SelectedUnits)
				{
					selectedUnit5.Doctrine.SetBingoJokerRTB(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetBingoJokerRTB(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
		if (comboBox_0.SelectedIndex < 0)
		{
			return;
		}
		foreach (ActiveUnit item in LoginRepository(scenario_0, null))
		{
			if (item.IsAircraft)
			{
				item.FuelState = ActiveUnit._ActiveUnitFuelState.None;
				if (item.IsOperating())
				{
					item.AI.EvaluateUnitStatus(0f, bool_0: true, bool_1: false);
				}
			}
		}
	}

	public void Populate_Combo_JettisonOrdnance(ComboBox comboBox_0, ref Scenario scenario_0, _JettisonOrdnance? nullable_0)
	{
		_JettisonOrdnance? jettison = GetJettison(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_JettisonOrdnance(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (JettisonOrdnance_Inherits())
		{
			comboBox.SelectedIndex = 2;
		}
		else
		{
			_JettisonOrdnance? jettisonOrdnance = jettison;
			byte? b = (byte?)jettisonOrdnance;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)jettisonOrdnance;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)jettisonOrdnance;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 3;
					}
					else
					{
						b = (byte?)jettisonOrdnance;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_JettisonOrdnance(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetJettison(scenario_0, bool_0: true, bool_0, bool_1, _JettisonOrdnance.Yes);
				}
			}
			SetJettison(scenario_0, bool_0: false, bool_0, bool_1, _JettisonOrdnance.Yes);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetJettison(scenario_0, bool_0: true, bool_0, bool_1, _JettisonOrdnance.No);
				}
			}
			SetJettison(scenario_0, bool_0: false, bool_0, bool_1, _JettisonOrdnance.No);
			break;
		case 2:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetJettison(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetJettison(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_BVRLogic(ComboBox comboBox_0, ref Scenario scenario_0, _BVRLogicEnum? nullable_0)
	{
		try
		{
			_BVRLogicEnum? bVRLogicEnum = method_0(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			DataTable dataTable_ = new DataTable();
			ComboBox_BVRLogic(ref dataTable_, scenario_0, nullable_0);
			ComboBox comboBox = comboBox_0;
			comboBox.DataSource = dataTable_;
			comboBox.DisplayMember = "Description";
			comboBox.ValueMember = "ID";
			if (BVRLogic_Inherits())
			{
				comboBox.SelectedIndex = 4;
			}
			else
			{
				_BVRLogicEnum? bVRLogicEnum2 = bVRLogicEnum;
				byte? b = (byte?)bVRLogicEnum2;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 0;
				}
				else
				{
					b = (byte?)bVRLogicEnum2;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 1;
					}
					else
					{
						b = (byte?)bVRLogicEnum2;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 2;
						}
						else
						{
							b = (byte?)bVRLogicEnum2;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 3;
							}
							else
							{
								b = (byte?)bVRLogicEnum2;
								if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
								{
									comboBox.SelectedIndex = 5;
								}
								else
								{
									b = (byte?)bVRLogicEnum2;
									if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
									{
										comboBox.SelectedIndex = 5;
									}
								}
							}
						}
					}
				}
			}
			comboBox = null;
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

	public void SelectionChanged_Combo_BVRLogic(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.method_1(scenario_0, bool_0: true, bool_0, bool_1, _BVRLogicEnum.StraightIn);
				}
			}
			method_1(scenario_0, bool_0: false, bool_0, bool_1, _BVRLogicEnum.StraightIn);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.method_1(scenario_0, bool_0: true, bool_0, bool_1, _BVRLogicEnum.Crank);
				}
			}
			method_1(scenario_0, bool_0: false, bool_0, bool_1, _BVRLogicEnum.Crank);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.method_1(scenario_0, bool_0: true, bool_0, bool_1, _BVRLogicEnum.CrankAndDrag);
				}
			}
			method_1(scenario_0, bool_0: false, bool_0, bool_1, _BVRLogicEnum.CrankAndDrag);
			break;
		case 3:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.method_1(scenario_0, bool_0: true, bool_0, bool_1, _BVRLogicEnum.DragImmediately);
				}
			}
			method_1(scenario_0, bool_0: false, bool_0, bool_1, _BVRLogicEnum.DragImmediately);
			break;
		case 4:
			if ((object)Subject.GetType() == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit5 in SelectedUnits)
				{
					selectedUnit5.Doctrine.method_1(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			method_1(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_BehaviorTowardsAmbigousTarget(ComboBox comboBox_0, ref Scenario scenario_0, _BehaviorTowardsTargetAmbiguity? nullable_0)
	{
		_BehaviorTowardsTargetAmbiguity? behaviorTowardsAmbigousTarget = GetBehaviorTowardsAmbigousTarget(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_BehaviorTowardsAmbigousTarget(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (BehaviorTowardsAmbigousTarget_Inherits())
		{
			comboBox.SelectedIndex = 3;
		}
		else
		{
			_BehaviorTowardsTargetAmbiguity? behaviorTowardsTargetAmbiguity = behaviorTowardsAmbigousTarget;
			byte? b = (byte?)behaviorTowardsTargetAmbiguity;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)behaviorTowardsTargetAmbiguity;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)behaviorTowardsTargetAmbiguity;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)behaviorTowardsTargetAmbiguity;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 4;
						}
						else
						{
							b = (byte?)behaviorTowardsTargetAmbiguity;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_BehaviorTowardsAmbigousTarget(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetBehaviorTowardsAmbigousTarget(scenario_0, bool_0: true, bool_0, bool_1, _BehaviorTowardsTargetAmbiguity.Ignore);
				}
			}
			SetBehaviorTowardsAmbigousTarget(scenario_0, bool_0: false, bool_0, bool_1, _BehaviorTowardsTargetAmbiguity.Ignore);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetBehaviorTowardsAmbigousTarget(scenario_0, bool_0: true, bool_0, bool_1, _BehaviorTowardsTargetAmbiguity.Optimistic);
				}
			}
			SetBehaviorTowardsAmbigousTarget(scenario_0, bool_0: false, bool_0, bool_1, _BehaviorTowardsTargetAmbiguity.Optimistic);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetBehaviorTowardsAmbigousTarget(scenario_0, bool_0: true, bool_0, bool_1, _BehaviorTowardsTargetAmbiguity.Pessimistic);
				}
			}
			SetBehaviorTowardsAmbigousTarget(scenario_0, bool_0: false, bool_0, bool_1, _BehaviorTowardsTargetAmbiguity.Pessimistic);
			break;
		case 3:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetBehaviorTowardsAmbigousTarget(scenario_0, bool_0: false, bool_0, bool_1, null);
				}
			}
			SetBehaviorTowardsAmbigousTarget(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_AutoEvade(ComboBox comboBox_0, ref Scenario scenario_0, _UseAutoEvade? nullable_0)
	{
		_UseAutoEvade? autoEvade = GetAutoEvade(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		CheckRepository(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (AutoEvade_Inherits())
		{
			comboBox.SelectedIndex = 2;
		}
		else
		{
			_UseAutoEvade? useAutoEvade = autoEvade;
			byte? b = (byte?)useAutoEvade;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)useAutoEvade;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)useAutoEvade;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 3;
					}
					else
					{
						b = (byte?)useAutoEvade;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_AutoEvade(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetAutoEvade(scenario_0, bool_0: true, bool_0, bool_1, _UseAutoEvade.Yes);
				}
			}
			SetAutoEvade(scenario_0, bool_0: false, bool_0, bool_1, _UseAutoEvade.Yes);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetAutoEvade(scenario_0, bool_0: true, bool_0, bool_1, _UseAutoEvade.No);
				}
			}
			SetAutoEvade(scenario_0, bool_0: false, bool_0, bool_1, _UseAutoEvade.No);
			break;
		case 2:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetAutoEvade(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetAutoEvade(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_Standoff(ComboBox comboBox_0, ref Scenario scenario_0, _UseMaintainStandoff? nullable_0)
	{
		_UseMaintainStandoff? maintainStandoff = GetMaintainStandoff(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_MaintainStandoff(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (MaintainStandoff_Inherits())
		{
			comboBox.SelectedIndex = 2;
		}
		else
		{
			_UseMaintainStandoff? useMaintainStandoff = maintainStandoff;
			byte? b = (byte?)useMaintainStandoff;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)useMaintainStandoff;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)useMaintainStandoff;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 3;
					}
					else
					{
						b = (byte?)useMaintainStandoff;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_Standoff(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetMaintainStandoff(scenario_0, bool_0: true, bool_0, bool_1, _UseMaintainStandoff.Yes);
				}
			}
			SetMaintainStandoff(scenario_0, bool_0: false, bool_0, bool_1, _UseMaintainStandoff.Yes);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetMaintainStandoff(scenario_0, bool_0: true, bool_0, bool_1, _UseMaintainStandoff.No);
				}
			}
			SetMaintainStandoff(scenario_0, bool_0: false, bool_0, bool_1, _UseMaintainStandoff.No);
			break;
		case 2:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetMaintainStandoff(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetMaintainStandoff(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_SurfaceNavigation(ComboBox comboBox_0, ref Scenario scenario_0, _NavigationMethod? nullable_0)
	{
		_NavigationMethod? surfaceNavigation = GetSurfaceNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_SurfaceNavigation(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (SurfaceNavigation_Inherits())
		{
			comboBox.SelectedIndex = 3;
		}
		else
		{
			_NavigationMethod? navigationMethod = surfaceNavigation;
			byte? b = (byte?)navigationMethod;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)navigationMethod;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)navigationMethod;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)navigationMethod;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 6) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 4;
						}
						else
						{
							b = (byte?)navigationMethod;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 7) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_SurfaceNavigation(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetSurfaceNavigation(scenario_0, bool_0: true, bool_0, bool_1, _NavigationMethod.ShortestRoute);
				}
			}
			SetSurfaceNavigation(scenario_0, bool_0: false, bool_0, bool_1, _NavigationMethod.ShortestRoute);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetSurfaceNavigation(scenario_0, bool_0: true, bool_0, bool_1, _NavigationMethod.DeepWater);
				}
			}
			SetSurfaceNavigation(scenario_0, bool_0: false, bool_0, bool_1, _NavigationMethod.DeepWater);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetSurfaceNavigation(scenario_0, bool_0: true, bool_0, bool_1, _NavigationMethod.Littoral);
				}
			}
			SetSurfaceNavigation(scenario_0, bool_0: false, bool_0, bool_1, _NavigationMethod.Littoral);
			break;
		case 3:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetSurfaceNavigation(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetSurfaceNavigation(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_SubmarineNavigation(ComboBox comboBox_0, ref Scenario scenario_0, _NavigationMethod? nullable_0)
	{
		_NavigationMethod? submarineNavigation = GetSubmarineNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_SubmarineNavigation(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (SubmarineNavigation_Inherits())
		{
			comboBox.SelectedIndex = 4;
		}
		else
		{
			_NavigationMethod? navigationMethod = submarineNavigation;
			byte? b = (byte?)navigationMethod;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)navigationMethod;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)navigationMethod;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)navigationMethod;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
						else
						{
							b = (byte?)navigationMethod;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 6) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 5;
							}
							else
							{
								b = (byte?)navigationMethod;
								if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 7) : null).GetValueOrDefault())
								{
									comboBox.SelectedIndex = 5;
								}
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_SubmarineNavigation(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetSubmarineNavigation(scenario_0, bool_0: true, bool_0, bool_1, _NavigationMethod.ShortestRoute);
				}
			}
			SetSubmarineNavigation(scenario_0, bool_0: false, bool_0, bool_1, _NavigationMethod.ShortestRoute);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetSubmarineNavigation(scenario_0, bool_0: true, bool_0, bool_1, _NavigationMethod.DeepWater_Submarine);
				}
			}
			SetSubmarineNavigation(scenario_0, bool_0: false, bool_0, bool_1, _NavigationMethod.DeepWater_Submarine);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetSubmarineNavigation(scenario_0, bool_0: true, bool_0, bool_1, _NavigationMethod.CZ_Submarine);
				}
			}
			SetSubmarineNavigation(scenario_0, bool_0: false, bool_0, bool_1, _NavigationMethod.CZ_Submarine);
			break;
		case 3:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetSubmarineNavigation(scenario_0, bool_0: true, bool_0, bool_1, _NavigationMethod.Littoral_Submarine);
				}
			}
			SetSubmarineNavigation(scenario_0, bool_0: false, bool_0, bool_1, _NavigationMethod.Littoral_Submarine);
			break;
		case 4:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit5 in SelectedUnits)
				{
					selectedUnit5.Doctrine.SetSubmarineNavigation(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetSubmarineNavigation(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_LandNavigation(ComboBox comboBox_0, ref Scenario scenario_0, _NavigationMethod? nullable_0)
	{
		_NavigationMethod? landNavigation = GetLandNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_LandNavigation(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (LandNavigation_Inherits())
		{
			comboBox.SelectedIndex = 0;
		}
		else
		{
			_NavigationMethod? navigationMethod = landNavigation;
			byte? b = (byte?)navigationMethod;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)navigationMethod;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 8) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)navigationMethod;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 6) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)navigationMethod;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 7) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 2;
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_LandNavigation(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetLandNavigation(scenario_0, bool_0: true, bool_0, bool_1, _NavigationMethod.ShortestRoute);
				}
			}
			SetLandNavigation(scenario_0, bool_0: false, bool_0, bool_1, _NavigationMethod.ShortestRoute);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetLandNavigation(scenario_0, bool_0: true, bool_0, bool_1, _NavigationMethod.Direct);
				}
			}
			SetLandNavigation(scenario_0, bool_0: false, bool_0, bool_1, _NavigationMethod.Direct);
			break;
		case 2:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetLandNavigation(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetLandNavigation(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_GunStrafing(ComboBox comboBox_0, ref Scenario scenario_0, _GunStrafeGroundTargets? nullable_0)
	{
		_GunStrafeGroundTargets? gunStrafing = GetGunStrafing(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_GunStrafing(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (GunStrafing_Inherits())
		{
			comboBox.SelectedIndex = 2;
		}
		else
		{
			_GunStrafeGroundTargets? gunStrafeGroundTargets = gunStrafing;
			byte? b = (byte?)gunStrafeGroundTargets;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)gunStrafeGroundTargets;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)gunStrafeGroundTargets;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 3;
					}
					else
					{
						b = (byte?)gunStrafeGroundTargets;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_GunStrafing(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetGunStrafing(scenario_0, bool_0: true, bool_0, bool_1, _GunStrafeGroundTargets.Yes);
				}
			}
			SetGunStrafing(scenario_0, bool_0: false, bool_0, bool_1, _GunStrafeGroundTargets.Yes);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetGunStrafing(scenario_0, bool_0: true, bool_0, bool_1, _GunStrafeGroundTargets.No);
					if (selectedUnit2.IsOperating() && selectedUnit2.IsAircraft)
					{
						selectedUnit2.AI.EvaluateUnitStatus(0f, bool_0: false, bool_1: false);
					}
				}
			}
			SetGunStrafing(scenario_0, bool_0: false, bool_0, bool_1, _GunStrafeGroundTargets.No);
			break;
		case 2:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				return;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetGunStrafing(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetGunStrafing(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
		if (comboBox_0.SelectedIndex < 0)
		{
			return;
		}
		foreach (ActiveUnit item in LoginRepository(scenario_0, null))
		{
			if (item.IsOperating() && item.IsAircraft)
			{
				item.AI.EvaluateUnitStatus(0f, bool_0: false, bool_1: false);
			}
		}
	}

	public void Populate_Combo_UseRefuel(ComboBox comboBox_0, ref Scenario scenario_0, _UseUnderwayRefuelAndReplenishment? nullable_0)
	{
		_UseUnderwayRefuelAndReplenishment? useReplenishment = GetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_UseReplenishment(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (UseReplenishment_Inherits())
		{
			comboBox.SelectedIndex = 3;
		}
		else
		{
			_UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment = useReplenishment;
			byte? b = (byte?)useUnderwayRefuelAndReplenishment;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)useUnderwayRefuelAndReplenishment;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)useUnderwayRefuelAndReplenishment;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)useUnderwayRefuelAndReplenishment;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 4;
						}
						else
						{
							b = (byte?)useUnderwayRefuelAndReplenishment;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_UseRefuel(int int_0, ref Scenario scenario_0, ref int int_1, bool bool_0, bool bool_1, bool bool_2)
	{
		switch (int_0)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetUseReplenishment(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _UseUnderwayRefuelAndReplenishment.Always_IncludingTankersRefuellingTankers);
				}
			}
			SetUseReplenishment(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _UseUnderwayRefuelAndReplenishment.Always_IncludingTankersRefuellingTankers);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetUseReplenishment(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _UseUnderwayRefuelAndReplenishment.Always_ExceptTankersRefuellingTankers);
				}
			}
			SetUseReplenishment(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _UseUnderwayRefuelAndReplenishment.Always_ExceptTankersRefuellingTankers);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetUseReplenishment(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _UseUnderwayRefuelAndReplenishment.Never);
				}
			}
			SetUseReplenishment(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _UseUnderwayRefuelAndReplenishment.Never);
			break;
		case 3:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				int_0 = int_1;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetUseReplenishment(scenario_0, bool_0: true, bool_0, bool_1, bool_2, null);
				}
			}
			SetUseReplenishment(scenario_0, bool_0: false, bool_0, bool_1, bool_2, null);
			break;
		case 4:
			SetUseReplenishment(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _UseUnderwayRefuelAndReplenishment.NotConfigured);
			break;
		}
	}

	public void Populate_Combo_ReplenishmentSelection(ComboBox comboBox_0, ref Scenario scenario_0, _UnderwayRefuelAndReplenishmentSelection? nullable_0)
	{
		_UnderwayRefuelAndReplenishmentSelection? replenishmentSelection = GetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_ReplenishmentSelection(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (ReplenishmentSelection_Inherits())
		{
			comboBox.SelectedIndex = 3;
		}
		else
		{
			_UnderwayRefuelAndReplenishmentSelection? underwayRefuelAndReplenishmentSelection = replenishmentSelection;
			byte? b = (byte?)underwayRefuelAndReplenishmentSelection;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)underwayRefuelAndReplenishmentSelection;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)underwayRefuelAndReplenishmentSelection;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)underwayRefuelAndReplenishmentSelection;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 4;
						}
						else
						{
							b = (byte?)underwayRefuelAndReplenishmentSelection;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_ReplenishmentSelection(int int_0, ref Scenario scenario_0, ref int int_1, bool bool_0, bool bool_1, bool bool_2)
	{
		switch (int_0)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _UnderwayRefuelAndReplenishmentSelection.PickNearest);
				}
			}
			SetReplenishmentSelection(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _UnderwayRefuelAndReplenishmentSelection.PickNearest);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveOnly);
				}
			}
			SetReplenishmentSelection(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveOnly);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
				}
			}
			SetReplenishmentSelection(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
			break;
		case 3:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				int_0 = int_1;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: true, bool_0, bool_1, bool_2, null);
				}
			}
			SetReplenishmentSelection(scenario_0, bool_0: false, bool_0, bool_1, bool_2, null);
			break;
		}
	}

	public void Populate_Combo_ShootTourists(ComboBox comboBox_0, ref Scenario scenario_0, _UseShootTourists? nullable_0)
	{
		_UseShootTourists? shootTourists = GetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_ShootTourists(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (ShootTourists_Inherits())
		{
			comboBox.SelectedIndex = 2;
		}
		else
		{
			_UseShootTourists? useShootTourists = shootTourists;
			byte? b = (byte?)useShootTourists;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)useShootTourists;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)useShootTourists;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 3;
					}
					else
					{
						b = (byte?)useShootTourists;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_ShootTourists(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetShootTourists(scenario_0, bool_0: true, bool_0, bool_1, _UseShootTourists.Yes);
				}
			}
			SetShootTourists(scenario_0, bool_0: false, bool_0, bool_1, _UseShootTourists.Yes);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetShootTourists(scenario_0, bool_0: true, bool_0, bool_1, _UseShootTourists.No);
				}
			}
			SetShootTourists(scenario_0, bool_0: false, bool_0, bool_1, _UseShootTourists.No);
			break;
		case 2:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetShootTourists(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetShootTourists(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_UseSAMsOnASuW(ComboBox comboBox_0, ref Scenario scenario_0, _UseSAMsAgainstShips? nullable_0)
	{
		_UseSAMsAgainstShips? useSAMsOnASuW = GetUseSAMsOnASuW(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_UseSAMsOnASuW(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (UseSAMsOnASuW_Inherits())
		{
			comboBox.SelectedIndex = 2;
		}
		else
		{
			_UseSAMsAgainstShips? useSAMsAgainstShips = useSAMsOnASuW;
			byte? b = (byte?)useSAMsAgainstShips;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)useSAMsAgainstShips;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)useSAMsAgainstShips;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 3;
					}
					else
					{
						b = (byte?)useSAMsAgainstShips;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void Populate_Combo_UseWPWeaponOnASuW(ComboBox comboBox_0, ref Scenario scenario_0, _UseWpMissileAgainstShips? nullable_0)
	{
		_UseWpMissileAgainstShips? useWPMissileOnASuW = GetUseWPMissileOnASuW(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_UseWPMissileOnASuW(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (UseSAMsOnASuW_Inherits())
		{
			comboBox.SelectedIndex = 2;
		}
		else
		{
			_UseWpMissileAgainstShips? useWpMissileAgainstShips = useWPMissileOnASuW;
			byte? b = (byte?)useWpMissileAgainstShips;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)useWpMissileAgainstShips;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)useWpMissileAgainstShips;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 3;
					}
					else
					{
						b = (byte?)useWpMissileAgainstShips;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_UseWPMissilesOnASuW(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetUseWPMissileOnASuW(scenario_0, bool_0: true, bool_0, bool_1, _UseWpMissileAgainstShips.Yes);
				}
			}
			SetUseWPMissileOnASuW(scenario_0, bool_0: false, bool_0, bool_1, _UseWpMissileAgainstShips.Yes);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetUseWPMissileOnASuW(scenario_0, bool_0: true, bool_0, bool_1, _UseWpMissileAgainstShips.No);
				}
			}
			SetUseWPMissileOnASuW(scenario_0, bool_0: false, bool_0, bool_1, _UseWpMissileAgainstShips.No);
			break;
		case 2:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetUseWPMissileOnASuW(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetUseWPMissileOnASuW(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void SelectionChanged_Combo_UseSAMsOnASuW(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetUseSAMsOnASuW(scenario_0, bool_0: true, bool_0, bool_1, _UseSAMsAgainstShips.Yes);
				}
			}
			SetUseSAMsOnASuW(scenario_0, bool_0: false, bool_0, bool_1, _UseSAMsAgainstShips.Yes);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetUseSAMsOnASuW(scenario_0, bool_0: true, bool_0, bool_1, _UseSAMsAgainstShips.No);
				}
			}
			SetUseSAMsOnASuW(scenario_0, bool_0: false, bool_0, bool_1, _UseSAMsAgainstShips.No);
			break;
		case 2:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetUseSAMsOnASuW(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetUseSAMsOnASuW(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_IgnoreEMCONunderAttack(ComboBox comboBox_0, ref Scenario scenario_0, _UseIgnoreEMCONunderAttack? nullable_0)
	{
		_UseIgnoreEMCONunderAttack? ignoreEMCONunderAttack = GetIgnoreEMCONunderAttack(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_IgnoreEMCONunderAttack(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (IgnoreEMCONunderAttack_Inherits())
		{
			comboBox.SelectedIndex = 2;
		}
		else
		{
			_UseIgnoreEMCONunderAttack? useIgnoreEMCONunderAttack = ignoreEMCONunderAttack;
			byte? b = (byte?)useIgnoreEMCONunderAttack;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)useIgnoreEMCONunderAttack;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)useIgnoreEMCONunderAttack;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 3;
					}
					else
					{
						b = (byte?)useIgnoreEMCONunderAttack;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_IgnoreEMCONunderAttack(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetIgnoreEMCONunderAttack(scenario_0, bool_0: true, bool_0, bool_1, _UseIgnoreEMCONunderAttack.Yes);
				}
			}
			SetIgnoreEMCONunderAttack(scenario_0, bool_0: false, bool_0, bool_1, _UseIgnoreEMCONunderAttack.Yes);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetIgnoreEMCONunderAttack(scenario_0, bool_0: true, bool_0, bool_1, _UseIgnoreEMCONunderAttack.No);
				}
			}
			SetIgnoreEMCONunderAttack(scenario_0, bool_0: false, bool_0, bool_1, _UseIgnoreEMCONunderAttack.No);
			break;
		case 2:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetIgnoreEMCONunderAttack(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetIgnoreEMCONunderAttack(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_QuickTurnAroundForAicraft(ComboBox comboBox_0, ref Scenario scenario_0, ref bool bool_0, _QuickTurnAroundForAicraft? nullable_0)
	{
		_QuickTurnAroundForAicraft? quickTurnAroundForAicraft = GetQuickTurnAroundForAicraft(scenario_0, bool_0: false, bool_0, bool_2: false, bool_3: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_QuickTurnAroundForAicraft(ref dataTable_, scenario_0, bool_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (QuickTurnAroundForAicraft_Inherits())
		{
			comboBox.SelectedIndex = 3;
		}
		else
		{
			_QuickTurnAroundForAicraft? quickTurnAroundForAicraft2 = quickTurnAroundForAicraft;
			byte? b = (byte?)quickTurnAroundForAicraft2;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)quickTurnAroundForAicraft2;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)quickTurnAroundForAicraft2;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)quickTurnAroundForAicraft2;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 4;
						}
						else
						{
							b = (byte?)quickTurnAroundForAicraft2;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_QuickTurnAroundForAicraft(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, ref bool bool_0, bool bool_1, bool bool_2)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetQuickTurnAroundForAicraft(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _QuickTurnAroundForAicraft.Yes);
				}
			}
			SetQuickTurnAroundForAicraft(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _QuickTurnAroundForAicraft.Yes);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetQuickTurnAroundForAicraft(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _QuickTurnAroundForAicraft.FightersAndASW);
				}
			}
			SetQuickTurnAroundForAicraft(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _QuickTurnAroundForAicraft.FightersAndASW);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetQuickTurnAroundForAicraft(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _QuickTurnAroundForAicraft.No);
				}
			}
			SetQuickTurnAroundForAicraft(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _QuickTurnAroundForAicraft.No);
			break;
		case 3:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetQuickTurnAroundForAicraft(scenario_0, bool_0: false, bool_0, bool_1, bool_2, null);
				}
			}
			SetQuickTurnAroundForAicraft(scenario_0, bool_0: false, bool_0, bool_1, bool_2, null);
			break;
		}
	}

	public void Populate_Combo_AirOpsTempo(ComboBox comboBox_0, ref Scenario scenario_0, ref bool bool_0, _AirOpsTempo? nullable_0)
	{
		_AirOpsTempo? airOpsTempo = GetAirOpsTempo(scenario_0, bool_0: false, bool_0, bool_2: false, bool_3: false);
		DataTable dataTable_ = new DataTable();
		ConcatRepository(ref dataTable_, scenario_0, bool_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (AirOpsTempo_Inherits())
		{
			comboBox.SelectedIndex = 2;
		}
		else
		{
			_AirOpsTempo? airOpsTempo2 = airOpsTempo;
			byte? b = (byte?)airOpsTempo2;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)airOpsTempo2;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)airOpsTempo2;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 3;
					}
					else
					{
						b = (byte?)airOpsTempo2;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_AirOpsTempo(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, ref bool bool_0, bool bool_1, bool bool_2)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetAirOpsTempo(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _AirOpsTempo.Sustained);
				}
			}
			SetAirOpsTempo(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _AirOpsTempo.Sustained);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetAirOpsTempo(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _AirOpsTempo.Surge);
				}
			}
			SetAirOpsTempo(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _AirOpsTempo.Surge);
			break;
		case 2:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetAirOpsTempo(scenario_0, bool_0: true, bool_0, bool_1, bool_2, null);
				}
			}
			SetAirOpsTempo(scenario_0, bool_0: false, bool_0, bool_1, bool_2, null);
			break;
		}
	}

	public void Populate_Combo_BingoJoker(ComboBox comboBox_0, ref Scenario scenario_0, ref bool bool_0, _FuelState? nullable_0)
	{
		_FuelState? bingoJoker = GetBingoJoker(scenario_0, bool_0: false, bool_0, bool_2: false, bool_3: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_FuelState(ref dataTable_, scenario_0, bool_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (BingoJoker_Inherits())
		{
			comboBox.SelectedIndex = 12;
		}
		else
		{
			_FuelState? fuelState = bingoJoker;
			byte? b = (byte?)fuelState;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)fuelState;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)fuelState;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)fuelState;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
						else
						{
							b = (byte?)fuelState;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
							else
							{
								b = (byte?)fuelState;
								if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									comboBox.SelectedIndex = 5;
								}
								else
								{
									b = (byte?)fuelState;
									if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 6) : null).GetValueOrDefault())
									{
										comboBox.SelectedIndex = 6;
									}
									else
									{
										b = (byte?)fuelState;
										if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 7) : null).GetValueOrDefault())
										{
											comboBox.SelectedIndex = 7;
										}
										else
										{
											b = (byte?)fuelState;
											if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 8) : null).GetValueOrDefault())
											{
												comboBox.SelectedIndex = 8;
											}
											else
											{
												b = (byte?)fuelState;
												if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 9) : null).GetValueOrDefault())
												{
													comboBox.SelectedIndex = 9;
												}
												else
												{
													b = (byte?)fuelState;
													if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 10) : null).GetValueOrDefault())
													{
														comboBox.SelectedIndex = 10;
													}
													else
													{
														b = (byte?)fuelState;
														if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 11) : null).GetValueOrDefault())
														{
															comboBox.SelectedIndex = 11;
														}
														else
														{
															b = (byte?)fuelState;
															if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 12) : null).GetValueOrDefault())
															{
																comboBox.SelectedIndex = 13;
															}
															else
															{
																b = (byte?)fuelState;
																if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 14) : null).GetValueOrDefault())
																{
																	comboBox.SelectedIndex = 13;
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_BingoJoker(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, ref bool bool_0, ref bool bool_1, bool bool_2, bool bool_3)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetBingoJoker(scenario_0, bool_0: true, bool_0, bool_2, bool_3, _FuelState.Bingo);
				}
			}
			SetBingoJoker(scenario_0, bool_0: false, bool_0, bool_2, bool_3, _FuelState.Bingo);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit6 in SelectedUnits)
				{
					selectedUnit6.Doctrine.SetBingoJoker(scenario_0, bool_0: true, bool_0, bool_2, bool_3, _FuelState.Joker10Percent);
				}
			}
			SetBingoJoker(scenario_0, bool_0: false, bool_0, bool_2, bool_3, _FuelState.Joker10Percent);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit7 in SelectedUnits)
				{
					selectedUnit7.Doctrine.SetBingoJoker(scenario_0, bool_0: true, bool_0, bool_2, bool_3, _FuelState.Joker20Percent);
				}
			}
			SetBingoJoker(scenario_0, bool_0: false, bool_0, bool_2, bool_3, _FuelState.Joker20Percent);
			break;
		case 3:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit8 in SelectedUnits)
				{
					selectedUnit8.Doctrine.SetBingoJoker(scenario_0, bool_0: true, bool_0, bool_2, bool_3, _FuelState.Joker25Percent);
				}
			}
			SetBingoJoker(scenario_0, bool_0: false, bool_0, bool_2, bool_3, _FuelState.Joker25Percent);
			break;
		case 4:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit9 in SelectedUnits)
				{
					selectedUnit9.Doctrine.SetBingoJoker(scenario_0, bool_0: true, bool_0, bool_2, bool_3, _FuelState.Joker30Percent);
				}
			}
			SetBingoJoker(scenario_0, bool_0: false, bool_0, bool_2, bool_3, _FuelState.Joker30Percent);
			break;
		case 5:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit10 in SelectedUnits)
				{
					selectedUnit10.Doctrine.SetBingoJoker(scenario_0, bool_0: true, bool_0, bool_2, bool_3, _FuelState.Joker40Percent);
				}
			}
			SetBingoJoker(scenario_0, bool_0: false, bool_0, bool_2, bool_3, _FuelState.Joker40Percent);
			break;
		case 6:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit11 in SelectedUnits)
				{
					selectedUnit11.Doctrine.SetBingoJoker(scenario_0, bool_0: true, bool_0, bool_2, bool_3, _FuelState.Joker50Percent);
				}
			}
			SetBingoJoker(scenario_0, bool_0: false, bool_0, bool_2, bool_3, _FuelState.Joker50Percent);
			break;
		case 7:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit12 in SelectedUnits)
				{
					selectedUnit12.Doctrine.SetBingoJoker(scenario_0, bool_0: true, bool_0, bool_2, bool_3, _FuelState.Joker60Percent);
				}
			}
			SetBingoJoker(scenario_0, bool_0: false, bool_0, bool_2, bool_3, _FuelState.Joker60Percent);
			break;
		case 8:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit13 in SelectedUnits)
				{
					selectedUnit13.Doctrine.SetBingoJoker(scenario_0, bool_0: true, bool_0, bool_2, bool_3, _FuelState.Joker70Percent);
				}
			}
			SetBingoJoker(scenario_0, bool_0: false, bool_0, bool_2, bool_3, _FuelState.Joker70Percent);
			break;
		case 9:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetBingoJoker(scenario_0, bool_0: true, bool_0, bool_2, bool_3, _FuelState.Joker75Percent);
				}
			}
			SetBingoJoker(scenario_0, bool_0: false, bool_0, bool_2, bool_3, _FuelState.Joker75Percent);
			break;
		case 10:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetBingoJoker(scenario_0, bool_0: true, bool_0, bool_2, bool_3, _FuelState.Joker80Percent);
				}
			}
			SetBingoJoker(scenario_0, bool_0: false, bool_0, bool_2, bool_3, _FuelState.Joker80Percent);
			break;
		case 11:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetBingoJoker(scenario_0, bool_0: true, bool_0, bool_2, bool_3, _FuelState.Joker90Percent);
				}
			}
			SetBingoJoker(scenario_0, bool_0: false, bool_0, bool_2, bool_3, _FuelState.Joker90Percent);
			break;
		case 12:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				return;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit5 in SelectedUnits)
				{
					selectedUnit5.Doctrine.SetBingoJoker(scenario_0, bool_0: false, bool_0, bool_2, bool_3, null);
				}
			}
			SetBingoJoker(scenario_0, bool_0: false, bool_0, bool_2, bool_3, null);
			break;
		}
		if ((object)SubjectType == typeof(Side))
		{
			foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
			{
				if (!Information.IsNothing(activeUnits_))
				{
					activeUnits_.Kinematics.DetermineReserveFuelQty();
				}
			}
			return;
		}
		foreach (ActiveUnit item in LoginRepository(scenario_0, bool_1))
		{
			item.Kinematics.DetermineReserveFuelQty();
		}
	}

	public void Populate_Combo_WinchesterShotgun(ComboBox comboBox_0, ref Scenario scenario_0, ref bool bool_0, _WeaponState? nullable_0)
	{
		_WeaponState? winchesterShotgun = GetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_2: false, bool_3: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_WeaponState(ref dataTable_, scenario_0, bool_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (WinchesterShotgun_Inherits())
		{
			comboBox.SelectedIndex = 20;
		}
		else
		{
			_WeaponState? weaponState = winchesterShotgun;
			int? num = (int?)weaponState;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				num = (int?)weaponState;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2001) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					num = (int?)weaponState;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2002) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						num = (int?)weaponState;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3001) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
						else
						{
							num = (int?)weaponState;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3002) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
							else
							{
								num = (int?)weaponState;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3003) : null).GetValueOrDefault())
								{
									comboBox.SelectedIndex = 5;
								}
								else
								{
									num = (int?)weaponState;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5001) : null).GetValueOrDefault())
									{
										comboBox.SelectedIndex = 6;
									}
									else
									{
										num = (int?)weaponState;
										if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5002) : null).GetValueOrDefault())
										{
											comboBox.SelectedIndex = 7;
										}
										else
										{
											num = (int?)weaponState;
											if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5003) : null).GetValueOrDefault())
											{
												comboBox.SelectedIndex = 8;
											}
											else
											{
												num = (int?)weaponState;
												if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5005) : null).GetValueOrDefault())
												{
													comboBox.SelectedIndex = 9;
												}
												else
												{
													num = (int?)weaponState;
													if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5006) : null).GetValueOrDefault())
													{
														comboBox.SelectedIndex = 10;
													}
													else
													{
														num = (int?)weaponState;
														if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5011) : null).GetValueOrDefault())
														{
															comboBox.SelectedIndex = 11;
														}
														else
														{
															num = (int?)weaponState;
															if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5012) : null).GetValueOrDefault())
															{
																comboBox.SelectedIndex = 12;
															}
															else
															{
																num = (int?)weaponState;
																if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5021) : null).GetValueOrDefault())
																{
																	comboBox.SelectedIndex = 13;
																}
																else
																{
																	num = (int?)weaponState;
																	if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4001) : null).GetValueOrDefault())
																	{
																		comboBox.SelectedIndex = 14;
																	}
																	else
																	{
																		num = (int?)weaponState;
																		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4002) : null).GetValueOrDefault())
																		{
																			comboBox.SelectedIndex = 15;
																		}
																		else
																		{
																			num = (int?)weaponState;
																			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4011) : null).GetValueOrDefault())
																			{
																				comboBox.SelectedIndex = 16;
																			}
																			else
																			{
																				num = (int?)weaponState;
																				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4012) : null).GetValueOrDefault())
																				{
																					comboBox.SelectedIndex = 17;
																				}
																				else
																				{
																					num = (int?)weaponState;
																					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4021) : null).GetValueOrDefault())
																					{
																						comboBox.SelectedIndex = 18;
																					}
																					else
																					{
																						num = (int?)weaponState;
																						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4022) : null).GetValueOrDefault())
																						{
																							comboBox.SelectedIndex = 19;
																						}
																						else
																						{
																							num = (int?)weaponState;
																							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
																							{
																								comboBox.SelectedIndex = 21;
																							}
																							else
																							{
																								num = (int?)weaponState;
																								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
																								{
																									comboBox.SelectedIndex = 21;
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_WinchesterShotgun(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, ref bool bool_0, bool bool_1, bool bool_2)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.LoadoutSetting);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.LoadoutSetting);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit12 in SelectedUnits)
				{
					selectedUnit12.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.Winchester);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.Winchester);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit15 in SelectedUnits)
				{
					selectedUnit15.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.Winchester_ToO);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.Winchester_ToO);
			break;
		case 3:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit16 in SelectedUnits)
				{
					selectedUnit16.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.const_3);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.const_3);
			break;
		case 4:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit17 in SelectedUnits)
				{
					selectedUnit17.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.ShotgunBVR_WVR);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.ShotgunBVR_WVR);
			break;
		case 5:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit18 in SelectedUnits)
				{
					selectedUnit18.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.ShotgunBVR_WVR_Guns);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.ShotgunBVR_WVR_Guns);
			break;
		case 6:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit19 in SelectedUnits)
				{
					selectedUnit19.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.ShotgunOneEngagementBVR);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.ShotgunOneEngagementBVR);
			break;
		case 7:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit20 in SelectedUnits)
				{
					selectedUnit20.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.ShotgunOneEngagementBVR_Opportunity_WVR);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.ShotgunOneEngagementBVR_Opportunity_WVR);
			break;
		case 8:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit21 in SelectedUnits)
				{
					selectedUnit21.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.ShotgunOneEngagementBVR_Opportunity_WVR_Guns);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.ShotgunOneEngagementBVR_Opportunity_WVR_Guns);
			break;
		case 9:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.ShotgunOneEngagementBVR_And_WVR);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.ShotgunOneEngagementBVR_And_WVR);
			break;
		case 10:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.ShotgunOneEngagementBVR_And_WVR_Opportunity_Guns);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.ShotgunOneEngagementBVR_And_WVR_Opportunity_Guns);
			break;
		case 11:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.ShotgunOneEngagementWVR);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.ShotgunOneEngagementWVR);
			break;
		case 12:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit5 in SelectedUnits)
				{
					selectedUnit5.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.ShotgunOneEngagementWVR_Guns);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.ShotgunOneEngagementWVR_Guns);
			break;
		case 13:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit6 in SelectedUnits)
				{
					selectedUnit6.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.ShotgunOneEngagementGun);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.ShotgunOneEngagementGun);
			break;
		case 14:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit7 in SelectedUnits)
				{
					selectedUnit7.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.const_14);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.const_14);
			break;
		case 15:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit8 in SelectedUnits)
				{
					selectedUnit8.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.Shotgun25_ToO);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.Shotgun25_ToO);
			break;
		case 16:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit9 in SelectedUnits)
				{
					selectedUnit9.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.const_16);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.const_16);
			break;
		case 17:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit10 in SelectedUnits)
				{
					selectedUnit10.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.Shotgun50_ToO);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.Shotgun50_ToO);
			break;
		case 18:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit11 in SelectedUnits)
				{
					selectedUnit11.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.const_18);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.const_18);
			break;
		case 19:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit13 in SelectedUnits)
				{
					selectedUnit13.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: true, bool_0, bool_1, bool_2, _WeaponState.Shotgun75_ToO);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, _WeaponState.Shotgun75_ToO);
			break;
		case 20:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit14 in SelectedUnits)
				{
					selectedUnit14.Doctrine.SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, null);
				}
			}
			SetWinchesterShotgun(scenario_0, bool_0: false, bool_0, bool_1, bool_2, null);
			break;
		}
	}

	public void Populate_Combo_UseKinematicRangeForTorpedoes(ComboBox comboBox_0, ref Scenario scenario_0, _UseKinematicRangeForTorpedoes? nullable_0)
	{
		_UseKinematicRangeForTorpedoes? useKinematicRangeForTorpedoes = GetUseKinematicRangeForTorpedoes(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		InterruptRepository(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (UseKinematicRangeForTorpedoes_Inherits())
		{
			comboBox.SelectedIndex = 3;
		}
		else
		{
			_UseKinematicRangeForTorpedoes? useKinematicRangeForTorpedoes2 = useKinematicRangeForTorpedoes;
			byte? b = (byte?)useKinematicRangeForTorpedoes2;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)useKinematicRangeForTorpedoes2;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)useKinematicRangeForTorpedoes2;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)useKinematicRangeForTorpedoes2;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 4;
						}
						else
						{
							b = (byte?)useKinematicRangeForTorpedoes2;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_UseKinematicRangeForTorpedoes(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetUseKinematicRangeForTorpedoes(scenario_0, bool_0: true, bool_0, bool_1, _UseKinematicRangeForTorpedoes.AutomaticAndManualFire);
				}
			}
			SetUseKinematicRangeForTorpedoes(scenario_0, bool_0: false, bool_0, bool_1, _UseKinematicRangeForTorpedoes.AutomaticAndManualFire);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetUseKinematicRangeForTorpedoes(scenario_0, bool_0: true, bool_0, bool_1, _UseKinematicRangeForTorpedoes.ManualFireOnly);
				}
			}
			SetUseKinematicRangeForTorpedoes(scenario_0, bool_0: false, bool_0, bool_1, _UseKinematicRangeForTorpedoes.ManualFireOnly);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetUseKinematicRangeForTorpedoes(scenario_0, bool_0: true, bool_0, bool_1, _UseKinematicRangeForTorpedoes.No);
				}
			}
			SetUseKinematicRangeForTorpedoes(scenario_0, bool_0: false, bool_0, bool_1, _UseKinematicRangeForTorpedoes.No);
			break;
		case 3:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetUseKinematicRangeForTorpedoes(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetUseKinematicRangeForTorpedoes(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_EMCON_Radar(ComboBox comboBox_0, ref Scenario scenario_0, ref Doctrine doctrine_0)
	{
		comboBox_0.Items.Clear();
		comboBox_0.Items.Add("Passive");
		comboBox_0.Items.Add("Active");
		if (!Information.IsNothing(SelectedUnits) && SelectedUnits.Count > 1 && !doctrine_0.EMCON_Inherits && refIssuer.LoginInterruptibleField() == EMCONSettings._EMCONSetting.Various)
		{
			comboBox_0.Items.Add("Various");
		}
		if (!doctrine_0.EMCON_Inherits && (object)SubjectType == typeof(Waypoint))
		{
			comboBox_0.Items.Add("未配置");
		}
		if (doctrine_0.NewRepository(scenario_0).LoginInterruptibleField() == EMCONSettings._EMCONSetting.Passive)
		{
			comboBox_0.SelectedIndex = 0;
		}
		else if (doctrine_0.NewRepository(scenario_0).LoginInterruptibleField() == EMCONSettings._EMCONSetting.Active)
		{
			comboBox_0.SelectedIndex = 1;
		}
		else if (doctrine_0.NewRepository(scenario_0).LoginInterruptibleField() == EMCONSettings._EMCONSetting.NotConfigured)
		{
			comboBox_0.SelectedIndex = 2;
		}
		comboBox_0.Enabled = !doctrine_0.EMCON_Inherits;
	}

	public void Populate_Combo_EMCON_OECM(ComboBox comboBox_0, ref Scenario scenario_0, ref Doctrine doctrine_0)
	{
		comboBox_0.Items.Clear();
		comboBox_0.Items.Add("Passive");
		comboBox_0.Items.Add("Active");
		if (!Information.IsNothing(SelectedUnits) && SelectedUnits.Count > 1 && !doctrine_0.EMCON_Inherits && refIssuer.OECM() == EMCONSettings._EMCONSetting.Various)
		{
			comboBox_0.Items.Add("Various");
		}
		if (!doctrine_0.EMCON_Inherits && (object)SubjectType == typeof(Waypoint))
		{
			comboBox_0.Items.Add("未配置");
		}
		if (doctrine_0.NewRepository(scenario_0).OECM() == EMCONSettings._EMCONSetting.Passive)
		{
			comboBox_0.SelectedIndex = 0;
		}
		else if (doctrine_0.NewRepository(scenario_0).OECM() == EMCONSettings._EMCONSetting.Active)
		{
			comboBox_0.SelectedIndex = 1;
		}
		else if (doctrine_0.NewRepository(scenario_0).OECM() == EMCONSettings._EMCONSetting.NotConfigured)
		{
			comboBox_0.SelectedIndex = 2;
		}
		comboBox_0.Enabled = !doctrine_0.EMCON_Inherits;
	}

	public void Populate_Combo_EMCON_Sonar(ComboBox comboBox_0, ref Scenario scenario_0, ref Doctrine doctrine_0)
	{
		comboBox_0.Items.Clear();
		comboBox_0.Items.Add("Passive");
		comboBox_0.Items.Add("Active");
		if (!Information.IsNothing(SelectedUnits) && SelectedUnits.Count > 1 && !doctrine_0.EMCON_Inherits && refIssuer.GetInterruptibleField() == EMCONSettings._EMCONSetting.Various)
		{
			comboBox_0.Items.Add("Various");
		}
		if (!doctrine_0.EMCON_Inherits && (object)SubjectType == typeof(Waypoint))
		{
			comboBox_0.Items.Add("未配置");
		}
		if (doctrine_0.NewRepository(scenario_0).GetInterruptibleField() == EMCONSettings._EMCONSetting.Passive)
		{
			comboBox_0.SelectedIndex = 0;
		}
		else if (doctrine_0.NewRepository(scenario_0).GetInterruptibleField() == EMCONSettings._EMCONSetting.Active)
		{
			comboBox_0.SelectedIndex = 1;
		}
		else if (doctrine_0.NewRepository(scenario_0).GetInterruptibleField() == EMCONSettings._EMCONSetting.NotConfigured)
		{
			comboBox_0.SelectedIndex = 2;
		}
		comboBox_0.Enabled = !doctrine_0.EMCON_Inherits;
	}

	public void Set_Checkbox_EMCON_Inherit(CheckBox checkBox_0, ref ScenarioObject scenarioObject_0, ref Doctrine doctrine_0)
	{
		if (Information.IsNothing(scenarioObject_0))
		{
			checkBox_0.Enabled = true;
		}
		else
		{
			checkBox_0.Enabled = (object)SubjectType != typeof(Side);
		}
		checkBox_0.Checked = doctrine_0.EMCON_Inherits;
	}

	public void Set_Checkbox_State_Visibility_EMCON(CheckBox checkBox_0, ComboBox comboBox_0, ComboBox comboBox_1, ComboBox comboBox_2, ref Doctrine doctrine_0, Scenario scenario_0, bool bool_0, bool bool_1)
	{
		EMCONSettings._EMCONSetting eMCONSetting_ = EMCONSettings._EMCONSetting.Passive;
		if (doctrine_0.NewRepository(scenario_0).LoginInterruptibleField() == EMCONSettings._EMCONSetting.Active)
		{
			eMCONSetting_ = EMCONSettings._EMCONSetting.Active;
		}
		else if (doctrine_0.NewRepository(scenario_0).LoginInterruptibleField() == EMCONSettings._EMCONSetting.Intermittent)
		{
			eMCONSetting_ = EMCONSettings._EMCONSetting.Intermittent;
		}
		EMCONSettings._EMCONSetting eMCONSetting_2 = EMCONSettings._EMCONSetting.Passive;
		if (doctrine_0.NewRepository(scenario_0).GetInterruptibleField() == EMCONSettings._EMCONSetting.Active)
		{
			eMCONSetting_2 = EMCONSettings._EMCONSetting.Active;
		}
		else if (doctrine_0.NewRepository(scenario_0).GetInterruptibleField() == EMCONSettings._EMCONSetting.Intermittent)
		{
			eMCONSetting_2 = EMCONSettings._EMCONSetting.Intermittent;
		}
		EMCONSettings._EMCONSetting eMCONSetting_3 = EMCONSettings._EMCONSetting.Passive;
		if (doctrine_0.NewRepository(scenario_0).OECM() == EMCONSettings._EMCONSetting.Active)
		{
			eMCONSetting_3 = EMCONSettings._EMCONSetting.Active;
		}
		else if (doctrine_0.NewRepository(scenario_0).OECM() == EMCONSettings._EMCONSetting.Intermittent)
		{
			eMCONSetting_3 = EMCONSettings._EMCONSetting.Intermittent;
		}
		doctrine_0.EMCON_Inherits = checkBox_0.Checked;
		comboBox_0.Enabled = !doctrine_0.EMCON_Inherits;
		comboBox_1.Enabled = !doctrine_0.EMCON_Inherits;
		comboBox_2.Enabled = !doctrine_0.EMCON_Inherits;
		if (doctrine_0.DoctrineRefresh)
		{
			return;
		}
		if (!Information.IsNothing(SelectedUnits))
		{
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				selectedUnit.Doctrine.EMCON_Inherits = checkBox_0.Checked;
				if (!selectedUnit.Doctrine.EMCON_Inherits)
				{
					selectedUnit.Doctrine.SetEMCON_Radar(eMCONSetting_, scenario_0);
					selectedUnit.Doctrine.SetEMCON_Sonar(eMCONSetting_2, scenario_0);
					selectedUnit.Doctrine.SetEMCON_OECM(eMCONSetting_3, scenario_0);
				}
			}
		}
		if (!doctrine_0.EMCON_Inherits)
		{
			doctrine_0.SetEMCON_Radar(eMCONSetting_, scenario_0);
			doctrine_0.SetEMCON_Sonar(eMCONSetting_2, scenario_0);
			doctrine_0.SetEMCON_OECM(eMCONSetting_3, scenario_0);
		}
		if (Information.IsNothing(SelectedUnits))
		{
			doctrine_0.FireEvent_EmconChanged(Subject, false, bool_0: false, bool_0, bool_1, bool_3: false);
			return;
		}
		foreach (ActiveUnit selectedUnit2 in SelectedUnits)
		{
			selectedUnit2.Doctrine.FireEvent_EmconChanged(selectedUnit2, false, bool_0: true, bool_0, bool_1, bool_3: false);
		}
	}

	public void ApplyEMCON_For_AffectedUnits(ref Side side_0, ref Scenario scenario_0, ref bool bool_0)
	{
		if ((object)SubjectType == typeof(Side))
		{
			foreach (ActiveUnit unit in side_0.Units)
			{
				unit.Sensory.vmethod_0(unit.Sensors_Cached);
			}
			return;
		}
		foreach (ActiveUnit item in LoginRepository(scenario_0, bool_0))
		{
			item.Sensory.vmethod_0(item.Sensors_Cached);
		}
	}

	public void Populate_Combo_RefuelAllies(ComboBox comboBox_0, ref Scenario scenario_0, _RefuelAlliedUnits? nullable_0)
	{
		_RefuelAlliedUnits? refuelAllies = GetRefuelAllies(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_RefuelAllies(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (RefuelAllies_Inherits())
		{
			comboBox.SelectedIndex = 4;
		}
		else
		{
			_RefuelAlliedUnits? refuelAlliedUnits = refuelAllies;
			byte? b = (byte?)refuelAlliedUnits;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)refuelAlliedUnits;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)refuelAlliedUnits;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)refuelAlliedUnits;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
						else
						{
							b = (byte?)refuelAlliedUnits;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 5;
							}
							else
							{
								b = (byte?)refuelAlliedUnits;
								if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									comboBox.SelectedIndex = 5;
								}
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void Populate_Combo_BingoRefuel(ComboBox comboBox_0, ref Scenario scenario_0, _BingoThreshold_E? nullable_0)
	{
		_BingoThreshold_E? bingoThreshold = GetBingoThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_BingoThreshold(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (BingoThreshold_Inherits)
		{
			comboBox.SelectedIndex = 6;
		}
		else
		{
			_BingoThreshold_E? bingoThreshold_E = bingoThreshold;
			byte? b = (byte?)bingoThreshold_E;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)bingoThreshold_E;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)bingoThreshold_E;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)bingoThreshold_E;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
						else
						{
							b = (byte?)bingoThreshold_E;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
							else
							{
								b = (byte?)bingoThreshold_E;
								if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									comboBox.SelectedIndex = 5;
								}
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	internal float ReflectRepository(ActiveUnit activeUnit_0)
	{
		if (activeUnit_0.AssignedMissionOrPackage() != null && activeUnit_0.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne > 0)
		{
			return Convert.ToSingle((double)activeUnit_0.AssignedMissionOrPackage().FuelQtyToStartLookingForTanker_Airborne / 100.0);
		}
		_BingoThreshold_E? bingoThreshold = GetBingoThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
		byte? b = (byte?)bingoThreshold;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
		{
			return 0.3f;
		}
		b = (byte?)bingoThreshold;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
		{
			return 0.4f;
		}
		b = (byte?)bingoThreshold;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
		{
			return 0.5f;
		}
		b = (byte?)bingoThreshold;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
		{
			return 0.6f;
		}
		b = (byte?)bingoThreshold;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
		{
			return 0.7f;
		}
		b = (byte?)bingoThreshold;
		if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null).GetValueOrDefault())
		{
			return 0.8f;
		}
		return 0.6f;
	}

	public void SelectionChanged_BingoThresholdCombo(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetBingoThreshold(scenario_0, bool_0: true, bool_0, bool_1, _BingoThreshold_E.Bingo30Percent);
				}
			}
			SetBingoThreshold(scenario_0, bool_0: false, bool_0, bool_1, _BingoThreshold_E.Bingo30Percent);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetBingoThreshold(scenario_0, bool_0: true, bool_0, bool_1, _BingoThreshold_E.Bingo40Percent);
				}
			}
			SetBingoThreshold(scenario_0, bool_0: false, bool_0, bool_1, _BingoThreshold_E.Bingo40Percent);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetBingoThreshold(scenario_0, bool_0: true, bool_0, bool_1, _BingoThreshold_E.Bingo50Percent);
				}
			}
			SetBingoThreshold(scenario_0, bool_0: false, bool_0, bool_1, _BingoThreshold_E.Bingo50Percent);
			break;
		case 3:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetBingoThreshold(scenario_0, bool_0: true, bool_0, bool_1, _BingoThreshold_E.Bingo60Percent);
				}
			}
			SetBingoThreshold(scenario_0, bool_0: false, bool_0, bool_1, _BingoThreshold_E.Bingo60Percent);
			break;
		case 4:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit5 in SelectedUnits)
				{
					selectedUnit5.Doctrine.SetBingoThreshold(scenario_0, bool_0: true, bool_0, bool_1, _BingoThreshold_E.Bingo70Percent);
				}
			}
			SetBingoThreshold(scenario_0, bool_0: false, bool_0, bool_1, _BingoThreshold_E.Bingo70Percent);
			break;
		case 5:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit6 in SelectedUnits)
				{
					selectedUnit6.Doctrine.SetBingoThreshold(scenario_0, bool_0: true, bool_0, bool_1, _BingoThreshold_E.Bingo80Percent);
				}
			}
			SetBingoThreshold(scenario_0, bool_0: false, bool_0, bool_1, _BingoThreshold_E.Bingo80Percent);
			break;
		case 6:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit7 in SelectedUnits)
				{
					selectedUnit7.Doctrine.SetBingoThreshold(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetBingoThreshold(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void SelectionChanged_Combo_RefuelAllies(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetRefuelAllies(scenario_0, bool_0: true, bool_0, bool_1, _RefuelAlliedUnits.Yes);
				}
			}
			SetRefuelAllies(scenario_0, bool_0: false, bool_0, bool_1, _RefuelAlliedUnits.Yes);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetRefuelAllies(scenario_0, bool_0: true, bool_0, bool_1, _RefuelAlliedUnits.Yes_ReceiveOnly);
				}
			}
			SetRefuelAllies(scenario_0, bool_0: false, bool_0, bool_1, _RefuelAlliedUnits.Yes_ReceiveOnly);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetRefuelAllies(scenario_0, bool_0: true, bool_0, bool_1, _RefuelAlliedUnits.Yes_DeliverOnly);
				}
			}
			SetRefuelAllies(scenario_0, bool_0: false, bool_0, bool_1, _RefuelAlliedUnits.Yes_DeliverOnly);
			break;
		case 3:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetRefuelAllies(scenario_0, bool_0: true, bool_0, bool_1, _RefuelAlliedUnits.No);
				}
			}
			SetRefuelAllies(scenario_0, bool_0: false, bool_0, bool_1, _RefuelAlliedUnits.No);
			break;
		case 4:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit5 in SelectedUnits)
				{
					selectedUnit5.Doctrine.SetRefuelAllies(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetRefuelAllies(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_AvoidContact(ComboBox comboBox_0, ref Scenario scenario_0, _AvoidContactWhenPossible? nullable_0)
	{
		_AvoidContactWhenPossible? avoidContact = GetAvoidContact(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_AvoidContact(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (AvoidContact_Inherits())
		{
			comboBox.SelectedIndex = 3;
		}
		else
		{
			_AvoidContactWhenPossible? avoidContactWhenPossible = avoidContact;
			byte? b = (byte?)avoidContactWhenPossible;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)avoidContactWhenPossible;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)avoidContactWhenPossible;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)avoidContactWhenPossible;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 4;
						}
						else
						{
							b = (byte?)avoidContactWhenPossible;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_AvoidContact(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetAvoidContact(scenario_0, bool_0: true, bool_0, bool_1, _AvoidContactWhenPossible.No);
				}
			}
			SetAvoidContact(scenario_0, bool_0: false, bool_0, bool_1, _AvoidContactWhenPossible.No);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetAvoidContact(scenario_0, bool_0: true, bool_0, bool_1, _AvoidContactWhenPossible.Yes_Always);
				}
			}
			SetAvoidContact(scenario_0, bool_0: false, bool_0, bool_1, _AvoidContactWhenPossible.Yes_Always);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetAvoidContact(scenario_0, bool_0: true, bool_0, bool_1, _AvoidContactWhenPossible.Yes_ExceptSelfDefence);
				}
			}
			SetAvoidContact(scenario_0, bool_0: false, bool_0, bool_1, _AvoidContactWhenPossible.Yes_ExceptSelfDefence);
			break;
		case 3:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetAvoidContact(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetAvoidContact(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_DiveWhenThreatsDetected(ComboBox comboBox_0, ref Scenario scenario_0, _DiveOnContact? nullable_0)
	{
		_DiveOnContact? diveWhenThreatsDetected = GetDiveWhenThreatsDetected(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_DiveWhenThreatsDetected(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (DiveWhenThreatsDetected_Inherits())
		{
			comboBox.SelectedIndex = 4;
		}
		else
		{
			_DiveOnContact? diveOnContact = diveWhenThreatsDetected;
			byte? b = (byte?)diveOnContact;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)diveOnContact;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)diveOnContact;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)diveOnContact;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
						else
						{
							b = (byte?)diveOnContact;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 5;
							}
							else
							{
								b = (byte?)diveOnContact;
								if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									comboBox.SelectedIndex = 5;
								}
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_DiveWhenThreatsDetected(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetDiveWhenThreatsDetected(scenario_0, bool_0: true, bool_0, bool_1, _DiveOnContact.Yes);
				}
			}
			SetDiveWhenThreatsDetected(scenario_0, bool_0: false, bool_0, bool_1, _DiveOnContact.Yes);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetDiveWhenThreatsDetected(scenario_0, bool_0: true, bool_0, bool_1, _DiveOnContact.Yes_ESM_Only);
				}
			}
			SetDiveWhenThreatsDetected(scenario_0, bool_0: false, bool_0, bool_1, _DiveOnContact.Yes_ESM_Only);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetDiveWhenThreatsDetected(scenario_0, bool_0: true, bool_0, bool_1, _DiveOnContact.Yes_Ships20nm_Aircraft30nm);
				}
			}
			SetDiveWhenThreatsDetected(scenario_0, bool_0: false, bool_0, bool_1, _DiveOnContact.Yes_Ships20nm_Aircraft30nm);
			break;
		case 3:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetDiveWhenThreatsDetected(scenario_0, bool_0: true, bool_0, bool_1, _DiveOnContact.No);
				}
			}
			SetDiveWhenThreatsDetected(scenario_0, bool_0: false, bool_0, bool_1, _DiveOnContact.No);
			break;
		case 4:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit5 in SelectedUnits)
				{
					selectedUnit5.Doctrine.SetDiveWhenThreatsDetected(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetDiveWhenThreatsDetected(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_RechargePercentagePatrol(ComboBox comboBox_0, ref Scenario scenario_0, _RechargeBatteryPercentage? nullable_0)
	{
		_RechargeBatteryPercentage? rechargePercentagePatrol = GetRechargePercentagePatrol(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_RechargePercentagePatrol(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (RechargePercentagePatrol_Inherits())
		{
			comboBox.SelectedIndex = 10;
		}
		else
		{
			_RechargeBatteryPercentage? rechargeBatteryPercentage = rechargePercentagePatrol;
			int? num = (int?)rechargeBatteryPercentage;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				num = (int?)rechargeBatteryPercentage;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 10) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					num = (int?)rechargeBatteryPercentage;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 20) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						num = (int?)rechargeBatteryPercentage;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 30) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
						else
						{
							num = (int?)rechargeBatteryPercentage;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 40) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
							else
							{
								num = (int?)rechargeBatteryPercentage;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 50) : null).GetValueOrDefault())
								{
									comboBox.SelectedIndex = 5;
								}
								else
								{
									num = (int?)rechargeBatteryPercentage;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 60) : null).GetValueOrDefault())
									{
										comboBox.SelectedIndex = 6;
									}
									else
									{
										num = (int?)rechargeBatteryPercentage;
										if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 70) : null).GetValueOrDefault())
										{
											comboBox.SelectedIndex = 7;
										}
										else
										{
											num = (int?)rechargeBatteryPercentage;
											if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 80) : null).GetValueOrDefault())
											{
												comboBox.SelectedIndex = 8;
											}
											else
											{
												num = (int?)rechargeBatteryPercentage;
												if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 90) : null).GetValueOrDefault())
												{
													comboBox.SelectedIndex = 9;
												}
												else
												{
													num = (int?)rechargeBatteryPercentage;
													if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -100) : null).GetValueOrDefault())
													{
														comboBox.SelectedIndex = 11;
													}
													else
													{
														num = (int?)rechargeBatteryPercentage;
														if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -101) : null).GetValueOrDefault())
														{
															comboBox.SelectedIndex = 11;
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_RechargePercentagePatrol(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetRechargePercentagePatrol(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_Empty);
				}
			}
			SetRechargePercentagePatrol(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_Empty);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetRechargePercentagePatrol(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_10_Percent);
				}
			}
			SetRechargePercentagePatrol(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_10_Percent);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit5 in SelectedUnits)
				{
					selectedUnit5.Doctrine.SetRechargePercentagePatrol(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_20_Percent);
				}
			}
			SetRechargePercentagePatrol(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_20_Percent);
			break;
		case 3:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit6 in SelectedUnits)
				{
					selectedUnit6.Doctrine.SetRechargePercentagePatrol(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_30_Percent);
				}
			}
			SetRechargePercentagePatrol(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_30_Percent);
			break;
		case 4:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit7 in SelectedUnits)
				{
					selectedUnit7.Doctrine.SetRechargePercentagePatrol(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_40_Percent);
				}
			}
			SetRechargePercentagePatrol(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_40_Percent);
			break;
		case 5:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit8 in SelectedUnits)
				{
					selectedUnit8.Doctrine.SetRechargePercentagePatrol(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_50_Percent);
				}
			}
			SetRechargePercentagePatrol(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_50_Percent);
			break;
		case 6:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit9 in SelectedUnits)
				{
					selectedUnit9.Doctrine.SetRechargePercentagePatrol(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_60_Percent);
				}
			}
			SetRechargePercentagePatrol(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_60_Percent);
			break;
		case 7:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit10 in SelectedUnits)
				{
					selectedUnit10.Doctrine.SetRechargePercentagePatrol(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_70_Percent);
				}
			}
			SetRechargePercentagePatrol(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_70_Percent);
			break;
		case 8:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit11 in SelectedUnits)
				{
					selectedUnit11.Doctrine.SetRechargePercentagePatrol(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_80_Percent);
				}
			}
			SetRechargePercentagePatrol(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_80_Percent);
			break;
		case 9:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetRechargePercentagePatrol(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_90_Percent);
				}
			}
			SetRechargePercentagePatrol(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_90_Percent);
			break;
		case 10:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetRechargePercentagePatrol(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetRechargePercentagePatrol(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_RechargePercentageAttack(ComboBox comboBox_0, ref Scenario scenario_0, _RechargeBatteryPercentage? nullable_0)
	{
		_RechargeBatteryPercentage? rechargePercentageAttack = GetRechargePercentageAttack(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_RechargePercentageAttack(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (RechargePercentageAttack_Inherits())
		{
			comboBox.SelectedIndex = 10;
		}
		else
		{
			_RechargeBatteryPercentage? rechargeBatteryPercentage = rechargePercentageAttack;
			int? num = (int?)rechargeBatteryPercentage;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				num = (int?)rechargeBatteryPercentage;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 10) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					num = (int?)rechargeBatteryPercentage;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 20) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						num = (int?)rechargeBatteryPercentage;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 30) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
						else
						{
							num = (int?)rechargeBatteryPercentage;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 40) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
							else
							{
								num = (int?)rechargeBatteryPercentage;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 50) : null).GetValueOrDefault())
								{
									comboBox.SelectedIndex = 5;
								}
								else
								{
									num = (int?)rechargeBatteryPercentage;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 60) : null).GetValueOrDefault())
									{
										comboBox.SelectedIndex = 6;
									}
									else
									{
										num = (int?)rechargeBatteryPercentage;
										if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 70) : null).GetValueOrDefault())
										{
											comboBox.SelectedIndex = 7;
										}
										else
										{
											num = (int?)rechargeBatteryPercentage;
											if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 80) : null).GetValueOrDefault())
											{
												comboBox.SelectedIndex = 8;
											}
											else
											{
												num = (int?)rechargeBatteryPercentage;
												if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 90) : null).GetValueOrDefault())
												{
													comboBox.SelectedIndex = 9;
												}
												else
												{
													num = (int?)rechargeBatteryPercentage;
													if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -100) : null).GetValueOrDefault())
													{
														comboBox.SelectedIndex = 11;
													}
													else
													{
														num = (int?)rechargeBatteryPercentage;
														if ((num.HasValue ? new bool?(num.GetValueOrDefault() == -101) : null).GetValueOrDefault())
														{
															comboBox.SelectedIndex = 11;
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_RechargePercentageAttack(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetRechargePercentageAttack(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_Empty);
				}
			}
			SetRechargePercentageAttack(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_Empty);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetRechargePercentageAttack(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_10_Percent);
				}
			}
			SetRechargePercentageAttack(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_10_Percent);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit5 in SelectedUnits)
				{
					selectedUnit5.Doctrine.SetRechargePercentageAttack(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_20_Percent);
				}
			}
			SetRechargePercentageAttack(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_20_Percent);
			break;
		case 3:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit6 in SelectedUnits)
				{
					selectedUnit6.Doctrine.SetRechargePercentageAttack(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_30_Percent);
				}
			}
			SetRechargePercentageAttack(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_30_Percent);
			break;
		case 4:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit7 in SelectedUnits)
				{
					selectedUnit7.Doctrine.SetRechargePercentageAttack(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_40_Percent);
				}
			}
			SetRechargePercentageAttack(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_40_Percent);
			break;
		case 5:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit8 in SelectedUnits)
				{
					selectedUnit8.Doctrine.SetRechargePercentageAttack(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_50_Percent);
				}
			}
			SetRechargePercentageAttack(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_50_Percent);
			break;
		case 6:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit9 in SelectedUnits)
				{
					selectedUnit9.Doctrine.SetRechargePercentageAttack(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_60_Percent);
				}
			}
			SetRechargePercentageAttack(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_60_Percent);
			break;
		case 7:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit10 in SelectedUnits)
				{
					selectedUnit10.Doctrine.SetRechargePercentageAttack(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_70_Percent);
				}
			}
			SetRechargePercentageAttack(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_70_Percent);
			break;
		case 8:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit11 in SelectedUnits)
				{
					selectedUnit11.Doctrine.SetRechargePercentageAttack(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_80_Percent);
				}
			}
			SetRechargePercentageAttack(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_80_Percent);
			break;
		case 9:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetRechargePercentageAttack(scenario_0, bool_0: true, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_90_Percent);
				}
			}
			SetRechargePercentageAttack(scenario_0, bool_0: false, bool_0, bool_1, _RechargeBatteryPercentage.Recharge_90_Percent);
			break;
		case 10:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetRechargePercentageAttack(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetRechargePercentageAttack(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_AIPUsage(ComboBox comboBox_0, ref Scenario scenario_0, _UseAIP? nullable_0)
	{
		_UseAIP? useAIP = method_2(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		PrepareRepository(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (AIPUsage_Inherits())
		{
			comboBox.SelectedIndex = 3;
		}
		else
		{
			_UseAIP? useAIP2 = useAIP;
			byte? b = (byte?)useAIP2;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)useAIP2;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)useAIP2;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						b = (byte?)useAIP2;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 4;
						}
						else
						{
							b = (byte?)useAIP2;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_AIPUsage(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.method_3(scenario_0, bool_0: true, bool_0, bool_1, _UseAIP.Yes_Always);
				}
			}
			method_3(scenario_0, bool_0: false, bool_0, bool_1, _UseAIP.Yes_Always);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.method_3(scenario_0, bool_0: true, bool_0, bool_1, _UseAIP.Yes_AttackOnly);
				}
			}
			method_3(scenario_0, bool_0: false, bool_0, bool_1, _UseAIP.Yes_AttackOnly);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.method_3(scenario_0, bool_0: true, bool_0, bool_1, _UseAIP.No);
				}
			}
			method_3(scenario_0, bool_0: false, bool_0, bool_1, _UseAIP.No);
			break;
		case 3:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.method_3(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			method_3(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void Populate_Combo_DippingSonar(ComboBox comboBox_0, ref Scenario scenario_0, _UseDippingSonar? nullable_0)
	{
		_UseDippingSonar? dippingSonar = GetDippingSonar(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ComboBox_DippingSonar(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (DippingSonar_Inherits())
		{
			comboBox.SelectedIndex = 2;
		}
		else
		{
			_UseDippingSonar? useDippingSonar = dippingSonar;
			byte? b = (byte?)useDippingSonar;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				b = (byte?)useDippingSonar;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					b = (byte?)useDippingSonar;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 3;
					}
					else
					{
						b = (byte?)useDippingSonar;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void SelectionChanged_Combo_DippingSonar(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetDippingSonar(scenario_0, bool_0: true, bool_0, bool_1, _UseDippingSonar.Automatically_HoverAnd150ft);
				}
			}
			SetDippingSonar(scenario_0, bool_0: false, bool_0, bool_1, _UseDippingSonar.Automatically_HoverAnd150ft);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetDippingSonar(scenario_0, bool_0: true, bool_0, bool_1, _UseDippingSonar.ManualAndMissionOnly);
				}
			}
			SetDippingSonar(scenario_0, bool_0: false, bool_0, bool_1, _UseDippingSonar.ManualAndMissionOnly);
			break;
		case 2:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetDippingSonar(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetDippingSonar(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void ResetMission_TimeSincePlayerNotification(ref Scenario scenario_0, ref Side side_0)
	{
		Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			if (side != side_0 && !Module_Side.IsAlliedWithThisSide(side, side_0))
			{
				continue;
			}
			foreach (Mission mission in side.Missions)
			{
				mission.TimeSincePlayerNotification = 0;
			}
		}
	}

	public static void ResetDoctrineSettings(ref ActiveUnit activeUnit_0, ref Doctrine doctrine_0, Scenario scenario_0)
	{
		if (!Information.IsNothing(doctrine_0.GetNukesAllowed(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetNukesAllowed(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetWeaponControlStatus_Air(scenario_0, bool_0: false, false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetWeaponControlStatus_Air(scenario_0, bool_0: false, false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetWeaponControlStatus_Surface(scenario_0, bool_0: false, false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetWeaponControlStatus_Surface(scenario_0, bool_0: false, false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetWeaponControlStatus_Submarine(scenario_0, bool_0: false, false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetWeaponControlStatus_Submarine(scenario_0, bool_0: false, false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetWeaponControlStatus_Land(scenario_0, bool_0: false, false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetWeaponControlStatus_Land(scenario_0, bool_0: false, false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetIgnorePlottedCourse(scenario_0, bool_0: false, false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetIgnorePlottedCourse(scenario_0, bool_0: false, false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetWinchesterShotgun(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false)))
		{
			doctrine_0.SetWinchesterShotgun(scenario_0, bool_0: false, bool_1: false, bool_2: true, bool_3: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetBingoJoker(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false)))
		{
			doctrine_0.SetBingoJoker(scenario_0, bool_0: false, bool_1: false, bool_2: true, bool_3: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetBingoJokerRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetBingoJokerRTB(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetJettison(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetJettison(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetBehaviorTowardsAmbigousTarget(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetBehaviorTowardsAmbigousTarget(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetAutoEvade(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetAutoEvade(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetGunStrafing(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetGunStrafing(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetMaintainStandoff(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetMaintainStandoff(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false)))
		{
			doctrine_0.SetUseReplenishment(scenario_0, bool_0: false, bool_1: true, bool_2: true, bool_3: false, null);
		}
		if (!Information.IsNothing(doctrine_0.GetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false)))
		{
			doctrine_0.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: true, bool_2: true, bool_3: false, null);
		}
		if (!Information.IsNothing(doctrine_0.GetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetShootTourists(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetUseSAMsOnASuW(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetUseSAMsOnASuW(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetIgnoreEMCONunderAttack(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetIgnoreEMCONunderAttack(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetUseKinematicRangeForTorpedoes(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetUseKinematicRangeForTorpedoes(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (Information.IsNothing(activeUnit_0))
		{
			if (!Information.IsNothing(doctrine_0.GetQuickTurnAroundForAicraft(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false)))
			{
				doctrine_0.SetQuickTurnAroundForAicraft(scenario_0, bool_0: false, bool_1: false, bool_2: true, bool_3: true, null);
			}
			if (!Information.IsNothing(doctrine_0.GetAirOpsTempo(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false)))
			{
				doctrine_0.SetAirOpsTempo(scenario_0, bool_0: false, bool_1: false, bool_2: true, bool_3: true, null);
			}
		}
		else
		{
			if (!Information.IsNothing(doctrine_0.GetQuickTurnAroundForAicraft(scenario_0, bool_0: false, activeUnit_0.IsOperating(), bool_2: false, bool_3: false)))
			{
				doctrine_0.SetQuickTurnAroundForAicraft(scenario_0, bool_0: false, activeUnit_0.IsOperating(), bool_2: true, bool_3: true, null);
			}
			if (!Information.IsNothing(doctrine_0.GetAirOpsTempo(scenario_0, bool_0: false, activeUnit_0.IsOperating(), bool_2: false, bool_3: false)))
			{
				doctrine_0.SetAirOpsTempo(scenario_0, bool_0: false, activeUnit_0.IsOperating(), bool_2: true, bool_3: true, null);
			}
		}
		if (!Information.IsNothing(activeUnit_0) && activeUnit_0.IsAircraft)
		{
			activeUnit_0.Kinematics.DetermineReserveFuelQty();
		}
		if (!Information.IsNothing(doctrine_0.GetRefuelAllies(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetRefuelAllies(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetAvoidContact(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetAvoidContact(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetDiveWhenThreatsDetected(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetDiveWhenThreatsDetected(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetRechargePercentagePatrol(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetRechargePercentagePatrol(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetRechargePercentageAttack(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetRechargePercentageAttack(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.method_2(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.method_3(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetDippingSonar(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetDippingSonar(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetWithdrawDamageThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetWithdrawDamageThreshold(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetWithdrawFuelThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetWithdrawFuelThreshold(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetWithdrawAttackThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetWithdrawAttackThreshold(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetWithdrawDefenceThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetWithdrawDefenceThreshold(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetRedeployDamageThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetRedeployDamageThreshold(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetRedeployFuelThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetRedeployFuelThreshold(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetRedeployAttackThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetRedeployAttackThreshold(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetRedeployDefenceThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetRedeployDefenceThreshold(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetSurfaceNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetSurfaceNavigation(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetSubmarineNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetSubmarineNavigation(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
		if (!Information.IsNothing(doctrine_0.GetLandNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false)))
		{
			doctrine_0.SetLandNavigation(scenario_0, bool_0: false, bool_1: true, bool_2: true, null);
		}
	}

	private void VisitRepository(ref DataTable dataTable_0, Scenario scenario_0, _DamageThreshold? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "忽略毁伤";
		string text2 = "5%";
		string text3 = "25%";
		string text4 = "50%";
		string text5 = "75%";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		dataTable_0.Rows.Add(3, text4);
		dataTable_0.Rows.Add(4, text5);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		short? num;
		if (nullable_0.HasValue)
		{
			num = (short?)nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(5, "继承，" + text);
			}
			else
			{
				num = (short?)nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(5, "继承，" + text2);
				}
				else
				{
					num = (short?)nullable_0;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(5, "继承，" + text3);
					}
					else
					{
						num = (short?)nullable_0;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(5, "继承，" + text4);
						}
						else
						{
							num = (short?)nullable_0;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(5, "继承，" + text5);
							}
							else
							{
								dataTable_0.Rows.Add(5, "继承，多种设置");
							}
						}
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_DamageThreshold? withdrawDamageThreshold = GetParentDoctrine(scenario_0, ref bool_).GetWithdrawDamageThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			num = (short?)withdrawDamageThreshold;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(5, "继承，" + text);
			}
			else
			{
				num = (short?)withdrawDamageThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(5, "继承，" + text2);
				}
				else
				{
					num = (short?)withdrawDamageThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(5, "继承，" + text3);
					}
					else
					{
						num = (short?)withdrawDamageThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(5, "继承，" + text4);
						}
						else
						{
							num = (short?)withdrawDamageThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(5, "继承，" + text5);
							}
						}
					}
				}
			}
		}
		num = (short?)GetWithdrawDamageThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(6, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(6, "未配置");
		}
	}

	private void RestartRepository(ref DataTable dataTable_0, Scenario scenario_0, _FuelQuantityThreshold? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "忽略燃料";
		string text2 = "Bingo";
		string text3 = "25%";
		string text4 = "50%";
		string text5 = "75%";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		dataTable_0.Rows.Add(3, text4);
		dataTable_0.Rows.Add(4, text5);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		short? num;
		if (nullable_0.HasValue)
		{
			num = (short?)nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(5, "继承，" + text);
			}
			else
			{
				num = (short?)nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(5, "继承，" + text2);
				}
				else
				{
					num = (short?)nullable_0;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(5, "继承，" + text3);
					}
					else
					{
						num = (short?)nullable_0;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(5, "继承，" + text4);
						}
						else
						{
							num = (short?)nullable_0;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(5, "继承，" + text5);
							}
							else
							{
								dataTable_0.Rows.Add(5, "继承，多种设置");
							}
						}
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_FuelQuantityThreshold? withdrawFuelThreshold = GetParentDoctrine(scenario_0, ref bool_).GetWithdrawFuelThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			num = (short?)withdrawFuelThreshold;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(5, "继承，" + text);
			}
			else
			{
				num = (short?)withdrawFuelThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(5, "继承，" + text2);
				}
				else
				{
					num = (short?)withdrawFuelThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(5, "继承，" + text3);
					}
					else
					{
						num = (short?)withdrawFuelThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(5, "继承，" + text4);
						}
						else
						{
							num = (short?)withdrawFuelThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(5, "继承，" + text5);
							}
						}
					}
				}
			}
		}
		num = (short?)GetWithdrawFuelThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 6) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(6, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(6, "未配置");
		}
	}

	private void TestRepository(ref DataTable dataTable_0, Scenario scenario_0, _FuelQuantityThreshold? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "忽略燃料";
		string text2 = "Bingo";
		string text3 = "25%";
		string text4 = "50%";
		string text5 = "75%";
		string text6 = "100%";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		dataTable_0.Rows.Add(3, text4);
		dataTable_0.Rows.Add(4, text5);
		dataTable_0.Rows.Add(5, text6);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		short? num;
		if (nullable_0.HasValue)
		{
			num = (short?)nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(6, "继承，" + text);
			}
			else
			{
				num = (short?)nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(6, "继承，" + text2);
				}
				else
				{
					num = (short?)nullable_0;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(6, "继承，" + text3);
					}
					else
					{
						num = (short?)nullable_0;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(6, "继承，" + text4);
						}
						else
						{
							num = (short?)nullable_0;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(6, "继承，" + text5);
							}
							else
							{
								num = (short?)nullable_0;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									dataTable_0.Rows.Add(6, "继承，" + text6);
								}
								else
								{
									dataTable_0.Rows.Add(6, "继承，多种设置");
								}
							}
						}
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_FuelQuantityThreshold? redeployFuelThreshold = GetParentDoctrine(scenario_0, ref bool_).GetRedeployFuelThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			num = (short?)redeployFuelThreshold;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(6, "继承，" + text);
			}
			else
			{
				num = (short?)redeployFuelThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(6, "继承，" + text2);
				}
				else
				{
					num = (short?)redeployFuelThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(6, "继承，" + text3);
					}
					else
					{
						num = (short?)redeployFuelThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(6, "继承，" + text4);
						}
						else
						{
							num = (short?)redeployFuelThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(6, "继承，" + text5);
							}
							else
							{
								num = (short?)redeployFuelThreshold;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									dataTable_0.Rows.Add(6, "继承，" + text6);
								}
							}
						}
					}
				}
			}
		}
		num = (short?)GetRedeployFuelThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 6) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(7, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(7, "未配置");
		}
	}

	private void StopRepository(ref DataTable dataTable_0, Scenario scenario_0, _WeaponQuantityThreshold? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "Ignore";
		string text2 = "Exhausted";
		string text3 = "25%";
		string text4 = "50%";
		string text5 = "75%";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		dataTable_0.Rows.Add(3, text4);
		dataTable_0.Rows.Add(4, text5);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		short? num;
		if (nullable_0.HasValue)
		{
			num = (short?)nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(5, "继承，" + text);
			}
			else
			{
				num = (short?)nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(5, "继承，" + text2);
				}
				else
				{
					num = (short?)nullable_0;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(5, "继承，" + text3);
					}
					else
					{
						num = (short?)nullable_0;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(5, "继承，" + text4);
						}
						else
						{
							num = (short?)nullable_0;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(5, "继承，" + text5);
							}
							else
							{
								dataTable_0.Rows.Add(5, "继承，多种设置");
							}
						}
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_WeaponQuantityThreshold? withdrawAttackThreshold = GetParentDoctrine(scenario_0, ref bool_).GetWithdrawAttackThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			num = (short?)withdrawAttackThreshold;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(5, "继承，" + text);
			}
			else
			{
				num = (short?)withdrawAttackThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(5, "继承，" + text2);
				}
				else
				{
					num = (short?)withdrawAttackThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(5, "继承，" + text3);
					}
					else
					{
						num = (short?)withdrawAttackThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(5, "继承，" + text4);
						}
						else
						{
							num = (short?)withdrawAttackThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(5, "继承，" + text5);
							}
						}
					}
				}
			}
		}
		num = (short?)GetWithdrawAttackThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 7) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(6, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(6, "未配置");
		}
	}

	private void CancelRepository(ref DataTable dataTable_0, Scenario scenario_0, _WeaponQuantityThreshold? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "Ignore";
		string text2 = "Exhausted";
		string text3 = "25%";
		string text4 = "50%";
		string text5 = "75%";
		string text6 = "100%";
		string text7 = "所有攻击武器";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		dataTable_0.Rows.Add(3, text4);
		dataTable_0.Rows.Add(4, text5);
		dataTable_0.Rows.Add(5, text6);
		dataTable_0.Rows.Add(6, text7);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		short? num;
		if (nullable_0.HasValue)
		{
			num = (short?)nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(7, "继承，" + text);
			}
			else
			{
				num = (short?)nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(7, "继承，" + text2);
				}
				else
				{
					num = (short?)nullable_0;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(7, "继承，" + text3);
					}
					else
					{
						num = (short?)nullable_0;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(7, "继承，" + text4);
						}
						else
						{
							num = (short?)nullable_0;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(7, "继承，" + text5);
							}
							else
							{
								num = (short?)nullable_0;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									dataTable_0.Rows.Add(7, "继承，" + text6);
								}
								else
								{
									num = (short?)nullable_0;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 6) : null).GetValueOrDefault())
									{
										dataTable_0.Rows.Add(7, "继承，" + text7);
									}
									else
									{
										dataTable_0.Rows.Add(7, "继承，多种设置");
									}
								}
							}
						}
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_WeaponQuantityThreshold? redeployAttackThreshold = GetParentDoctrine(scenario_0, ref bool_).GetRedeployAttackThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			num = (short?)redeployAttackThreshold;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(7, "继承，" + text);
			}
			else
			{
				num = (short?)redeployAttackThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(7, "继承，" + text2);
				}
				else
				{
					num = (short?)redeployAttackThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(7, "继承，" + text3);
					}
					else
					{
						num = (short?)redeployAttackThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(7, "继承，" + text4);
						}
						else
						{
							num = (short?)redeployAttackThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(7, "继承，" + text5);
							}
							else
							{
								num = (short?)redeployAttackThreshold;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									dataTable_0.Rows.Add(7, "继承，" + text6);
								}
								else
								{
									num = (short?)redeployAttackThreshold;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 6) : null).GetValueOrDefault())
									{
										dataTable_0.Rows.Add(7, "继承，" + text7);
									}
								}
							}
						}
					}
				}
			}
		}
		num = (short?)GetRedeployAttackThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 7) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(8, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(8, "未配置");
		}
	}

	private void VerifyRepository(ref DataTable dataTable_0, Scenario scenario_0, _WeaponQuantityThreshold? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "Ignore";
		string text2 = "Exhausted";
		string text3 = "25%";
		string text4 = "50%";
		string text5 = "75%";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		dataTable_0.Rows.Add(3, text4);
		dataTable_0.Rows.Add(4, text5);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		short? num;
		if (nullable_0.HasValue)
		{
			num = (short?)nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(5, "继承，" + text);
			}
			else
			{
				num = (short?)nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(5, "继承，" + text2);
				}
				else
				{
					num = (short?)nullable_0;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(5, "继承，" + text3);
					}
					else
					{
						num = (short?)nullable_0;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(5, "继承，" + text4);
						}
						else
						{
							num = (short?)nullable_0;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(5, "继承，" + text5);
							}
							else
							{
								dataTable_0.Rows.Add(5, "继承，多种设置");
							}
						}
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_WeaponQuantityThreshold? withdrawDefenceThreshold = GetParentDoctrine(scenario_0, ref bool_).GetWithdrawDefenceThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			num = (short?)withdrawDefenceThreshold;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(5, "继承，" + text);
			}
			else
			{
				num = (short?)withdrawDefenceThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(5, "继承，" + text2);
				}
				else
				{
					num = (short?)withdrawDefenceThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(5, "继承，" + text3);
					}
					else
					{
						num = (short?)withdrawDefenceThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(5, "继承，" + text4);
						}
						else
						{
							num = (short?)withdrawDefenceThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(5, "继承，" + text5);
							}
						}
					}
				}
			}
		}
		num = (short?)GetWithdrawDefenceThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 7) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(6, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(6, "未配置");
		}
	}

	private void ListRepository(ref DataTable dataTable_0, Scenario scenario_0, _WeaponQuantityThreshold? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "Ignore";
		string text2 = "Exhausted";
		string text3 = "25%";
		string text4 = "50%";
		string text5 = "75%";
		string text6 = "100%";
		string text7 = "所有防御武器";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		dataTable_0.Rows.Add(3, text4);
		dataTable_0.Rows.Add(4, text5);
		dataTable_0.Rows.Add(5, text6);
		dataTable_0.Rows.Add(6, text7);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		short? num;
		if (nullable_0.HasValue)
		{
			num = (short?)nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(7, "继承，" + text);
			}
			else
			{
				num = (short?)nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(7, "继承，" + text2);
				}
				else
				{
					num = (short?)nullable_0;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(7, "继承，" + text3);
					}
					else
					{
						num = (short?)nullable_0;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(7, "继承，" + text4);
						}
						else
						{
							num = (short?)nullable_0;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(7, "继承，" + text5);
							}
							else
							{
								num = (short?)nullable_0;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									dataTable_0.Rows.Add(7, "继承，" + text6);
								}
								else
								{
									num = (short?)nullable_0;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 6) : null).GetValueOrDefault())
									{
										dataTable_0.Rows.Add(7, "继承，" + text7);
									}
									else
									{
										dataTable_0.Rows.Add(7, "继承，多种设置");
									}
								}
							}
						}
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_WeaponQuantityThreshold? redeployDefenceThreshold = GetParentDoctrine(scenario_0, ref bool_).GetRedeployDefenceThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			num = (short?)redeployDefenceThreshold;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(7, "继承，" + text);
			}
			else
			{
				num = (short?)redeployDefenceThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(7, "继承，" + text2);
				}
				else
				{
					num = (short?)redeployDefenceThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(7, "继承，" + text3);
					}
					else
					{
						num = (short?)redeployDefenceThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(7, "继承，" + text4);
						}
						else
						{
							num = (short?)redeployDefenceThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(7, "继承，" + text5);
							}
							else
							{
								num = (short?)redeployDefenceThreshold;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									dataTable_0.Rows.Add(7, "继承，" + text6);
								}
								else
								{
									num = (short?)redeployDefenceThreshold;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 6) : null).GetValueOrDefault())
									{
										dataTable_0.Rows.Add(7, "继承，" + text7);
									}
								}
							}
						}
					}
				}
			}
		}
		num = (short?)GetRedeployDefenceThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 7) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(8, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(8, "未配置");
		}
	}

	private void ResolveRepository(ref DataTable dataTable_0, Scenario scenario_0, _DamageThreshold? nullable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		string text = "忽略毁伤";
		string text2 = "5%";
		string text3 = "25%";
		string text4 = "50%";
		string text5 = "75%";
		dataTable_0.Rows.Add(0, text);
		dataTable_0.Rows.Add(1, text2);
		dataTable_0.Rows.Add(2, text3);
		dataTable_0.Rows.Add(3, text4);
		dataTable_0.Rows.Add(4, text5);
		if ((object)SubjectType == typeof(Side))
		{
			return;
		}
		short? num;
		if (nullable_0.HasValue)
		{
			num = (short?)nullable_0;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(5, "继承，" + text);
			}
			else
			{
				num = (short?)nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(5, "继承，" + text2);
				}
				else
				{
					num = (short?)nullable_0;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(5, "继承，" + text3);
					}
					else
					{
						num = (short?)nullable_0;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(5, "继承，" + text4);
						}
						else
						{
							num = (short?)nullable_0;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(5, "继承，" + text5);
							}
							else
							{
								dataTable_0.Rows.Add(5, "继承，多种设置");
							}
						}
					}
				}
			}
		}
		else
		{
			bool bool_ = true;
			_DamageThreshold? redeployDamageThreshold = GetParentDoctrine(scenario_0, ref bool_).GetRedeployDamageThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
			num = (short?)redeployDamageThreshold;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				dataTable_0.Rows.Add(5, "继承，" + text);
			}
			else
			{
				num = (short?)redeployDamageThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					dataTable_0.Rows.Add(5, "继承，" + text2);
				}
				else
				{
					num = (short?)redeployDamageThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						dataTable_0.Rows.Add(5, "继承，" + text3);
					}
					else
					{
						num = (short?)redeployDamageThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							dataTable_0.Rows.Add(5, "继承，" + text4);
						}
						else
						{
							num = (short?)redeployDamageThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								dataTable_0.Rows.Add(5, "继承，" + text5);
							}
						}
					}
				}
			}
		}
		num = (short?)GetRedeployDamageThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5) : null).GetValueOrDefault())
		{
			dataTable_0.Rows.Add(6, "Various");
		}
		if ((object)SubjectType == typeof(Waypoint))
		{
			dataTable_0.Rows.Add(6, "未配置");
		}
	}

	public void Populate_Combo_WithdrawDamageThreshold(ComboBox comboBox_0, ref Scenario scenario_0, _DamageThreshold? nullable_0)
	{
		_DamageThreshold? withdrawDamageThreshold = GetWithdrawDamageThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		VisitRepository(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (WithdrawDamageThreshold_Inherits())
		{
			comboBox.SelectedIndex = 5;
		}
		else
		{
			_DamageThreshold? damageThreshold = withdrawDamageThreshold;
			short? num = (short?)damageThreshold;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				num = (short?)damageThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					num = (short?)damageThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						num = (short?)damageThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
						else
						{
							num = (short?)damageThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
							else
							{
								num = (short?)damageThreshold;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									comboBox.SelectedIndex = 6;
								}
								else
								{
									num = (short?)damageThreshold;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 6) : null).GetValueOrDefault())
									{
										comboBox.SelectedIndex = 6;
									}
								}
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void Populate_Combo_WithdrawFuelThreshold(ComboBox comboBox_0, ref Scenario scenario_0, _FuelQuantityThreshold? nullable_0)
	{
		_FuelQuantityThreshold? withdrawFuelThreshold = GetWithdrawFuelThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		RestartRepository(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (WithdrawFuelThreshold_Inherits())
		{
			comboBox.SelectedIndex = 5;
		}
		else
		{
			_FuelQuantityThreshold? fuelQuantityThreshold = withdrawFuelThreshold;
			short? num = (short?)fuelQuantityThreshold;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				num = (short?)fuelQuantityThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					num = (short?)fuelQuantityThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						num = (short?)fuelQuantityThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
						else
						{
							num = (short?)fuelQuantityThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
							else
							{
								num = (short?)fuelQuantityThreshold;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 6) : null).GetValueOrDefault())
								{
									comboBox.SelectedIndex = 6;
								}
								else
								{
									num = (short?)fuelQuantityThreshold;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 7) : null).GetValueOrDefault())
									{
										comboBox.SelectedIndex = 6;
									}
								}
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void Populate_Combo_WithdrawAttackThreshold(ComboBox comboBox_0, ref Scenario scenario_0, _WeaponQuantityThreshold? nullable_0)
	{
		_WeaponQuantityThreshold? withdrawAttackThreshold = GetWithdrawAttackThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		StopRepository(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (WithdrawAttackThreshold_Inherits())
		{
			comboBox.SelectedIndex = 5;
		}
		else
		{
			_WeaponQuantityThreshold? weaponQuantityThreshold = withdrawAttackThreshold;
			short? num = (short?)weaponQuantityThreshold;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				num = (short?)weaponQuantityThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					num = (short?)weaponQuantityThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						num = (short?)weaponQuantityThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
						else
						{
							num = (short?)weaponQuantityThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
							else
							{
								num = (short?)weaponQuantityThreshold;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 7) : null).GetValueOrDefault())
								{
									comboBox.SelectedIndex = 6;
								}
								else
								{
									num = (short?)weaponQuantityThreshold;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 8) : null).GetValueOrDefault())
									{
										comboBox.SelectedIndex = 6;
									}
								}
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void Populate_Combo_WithdrawDefenceThreshold(ComboBox comboBox_0, ref Scenario scenario_0, _WeaponQuantityThreshold? nullable_0)
	{
		_WeaponQuantityThreshold? withdrawDefenceThreshold = GetWithdrawDefenceThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		VerifyRepository(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (WithdrawDefenceThreshold_Inherits())
		{
			comboBox.SelectedIndex = 5;
		}
		else
		{
			_WeaponQuantityThreshold? weaponQuantityThreshold = withdrawDefenceThreshold;
			short? num = (short?)weaponQuantityThreshold;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				num = (short?)weaponQuantityThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					num = (short?)weaponQuantityThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						num = (short?)weaponQuantityThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
						else
						{
							num = (short?)weaponQuantityThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
							else
							{
								num = (short?)weaponQuantityThreshold;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 7) : null).GetValueOrDefault())
								{
									comboBox.SelectedIndex = 6;
								}
								else
								{
									num = (short?)weaponQuantityThreshold;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 8) : null).GetValueOrDefault())
									{
										comboBox.SelectedIndex = 6;
									}
								}
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void Populate_Combo_RedeployDamageThreshold(ComboBox comboBox_0, ref Scenario scenario_0, _DamageThreshold? nullable_0)
	{
		_DamageThreshold? redeployDamageThreshold = GetRedeployDamageThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ResolveRepository(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (RedeployDamageThreshold_Inherits())
		{
			comboBox.SelectedIndex = 5;
		}
		else
		{
			_DamageThreshold? damageThreshold = redeployDamageThreshold;
			short? num = (short?)damageThreshold;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				num = (short?)damageThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					num = (short?)damageThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						num = (short?)damageThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
						else
						{
							num = (short?)damageThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
							else
							{
								num = (short?)damageThreshold;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									comboBox.SelectedIndex = 6;
								}
								else
								{
									num = (short?)damageThreshold;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 6) : null).GetValueOrDefault())
									{
										comboBox.SelectedIndex = 6;
									}
								}
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void Populate_Combo_RedeployFuelThreshold(ComboBox comboBox_0, ref Scenario scenario_0, _FuelQuantityThreshold? nullable_0)
	{
		_FuelQuantityThreshold? redeployFuelThreshold = GetRedeployFuelThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		TestRepository(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (RedeployFuelThreshold_Inherits())
		{
			comboBox.SelectedIndex = 6;
		}
		else
		{
			_FuelQuantityThreshold? fuelQuantityThreshold = redeployFuelThreshold;
			short? num = (short?)fuelQuantityThreshold;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				num = (short?)fuelQuantityThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					num = (short?)fuelQuantityThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						num = (short?)fuelQuantityThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
						else
						{
							num = (short?)fuelQuantityThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
							else
							{
								num = (short?)fuelQuantityThreshold;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									comboBox.SelectedIndex = 5;
								}
								else
								{
									num = (short?)fuelQuantityThreshold;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 6) : null).GetValueOrDefault())
									{
										comboBox.SelectedIndex = 7;
									}
									else
									{
										num = (short?)fuelQuantityThreshold;
										if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 7) : null).GetValueOrDefault())
										{
											comboBox.SelectedIndex = 7;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void Populate_Combo_RedeployAttackThreshold(ComboBox comboBox_0, ref Scenario scenario_0, _WeaponQuantityThreshold? nullable_0)
	{
		_WeaponQuantityThreshold? redeployAttackThreshold = GetRedeployAttackThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		CancelRepository(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (RedeployAttackThreshold_Inherits())
		{
			comboBox.SelectedIndex = 7;
		}
		else
		{
			_WeaponQuantityThreshold? weaponQuantityThreshold = redeployAttackThreshold;
			short? num = (short?)weaponQuantityThreshold;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				num = (short?)weaponQuantityThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					num = (short?)weaponQuantityThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						num = (short?)weaponQuantityThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
						else
						{
							num = (short?)weaponQuantityThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
							else
							{
								num = (short?)weaponQuantityThreshold;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									comboBox.SelectedIndex = 5;
								}
								else
								{
									num = (short?)weaponQuantityThreshold;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 6) : null).GetValueOrDefault())
									{
										comboBox.SelectedIndex = 6;
									}
									else
									{
										num = (short?)weaponQuantityThreshold;
										if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 7) : null).GetValueOrDefault())
										{
											comboBox.SelectedIndex = 8;
										}
										else
										{
											num = (short?)weaponQuantityThreshold;
											if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 8) : null).GetValueOrDefault())
											{
												comboBox.SelectedIndex = 8;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void Populate_Combo_RedeployDefenceThreshold(ComboBox comboBox_0, ref Scenario scenario_0, _WeaponQuantityThreshold? nullable_0)
	{
		_WeaponQuantityThreshold? redeployDefenceThreshold = GetRedeployDefenceThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false);
		DataTable dataTable_ = new DataTable();
		ListRepository(ref dataTable_, scenario_0, nullable_0);
		ComboBox comboBox = comboBox_0;
		comboBox.DataSource = dataTable_;
		comboBox.DisplayMember = "Description";
		comboBox.ValueMember = "ID";
		if (RedeployDefenceThreshold_Inherits())
		{
			comboBox.SelectedIndex = 7;
		}
		else
		{
			_WeaponQuantityThreshold? weaponQuantityThreshold = redeployDefenceThreshold;
			short? num = (short?)weaponQuantityThreshold;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				comboBox.SelectedIndex = 0;
			}
			else
			{
				num = (short?)weaponQuantityThreshold;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					comboBox.SelectedIndex = 1;
				}
				else
				{
					num = (short?)weaponQuantityThreshold;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						comboBox.SelectedIndex = 2;
					}
					else
					{
						num = (short?)weaponQuantityThreshold;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							comboBox.SelectedIndex = 3;
						}
						else
						{
							num = (short?)weaponQuantityThreshold;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								comboBox.SelectedIndex = 4;
							}
							else
							{
								num = (short?)weaponQuantityThreshold;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									comboBox.SelectedIndex = 5;
								}
								else
								{
									num = (short?)weaponQuantityThreshold;
									if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 6) : null).GetValueOrDefault())
									{
										comboBox.SelectedIndex = 6;
									}
									else
									{
										num = (short?)weaponQuantityThreshold;
										if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 7) : null).GetValueOrDefault())
										{
											comboBox.SelectedIndex = 8;
										}
										else
										{
											num = (short?)weaponQuantityThreshold;
											if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 8) : null).GetValueOrDefault())
											{
												comboBox.SelectedIndex = 8;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		comboBox = null;
	}

	public void Populate_List_PriorityTarget(DarkListView darkListView_0, Scenario scenario_0, int int_0 = -1)
	{
		int num = 0;
		darkListView_0.Items.Clear();
		foreach (PriorityTargetEntry item in m_ParameterClient)
		{
			darkListView_0.Items.Add(new DarkListItem(item.PatchInterruptibleField(scenario_0)));
			if (int_0 == -1 && item.Priority == PriorityTargetEntry.PriorityFlags.PriorityDefault)
			{
				int_0 = num;
			}
			else
			{
				num++;
			}
		}
		if (int_0 > -1)
		{
			darkListView_0.SelectItem(int_0);
		}
	}

	public void SelectionChanged_Combo_WithdrawDamageThreshold(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetWithdrawDamageThreshold(scenario_0, bool_0: true, bool_0, bool_1, _DamageThreshold.Ignore);
				}
			}
			SetWithdrawDamageThreshold(scenario_0, bool_0: false, bool_0, bool_1, _DamageThreshold.Ignore);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetWithdrawDamageThreshold(scenario_0, bool_0: true, bool_0, bool_1, _DamageThreshold.Percent5);
				}
			}
			SetWithdrawDamageThreshold(scenario_0, bool_0: false, bool_0, bool_1, _DamageThreshold.Percent5);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetWithdrawDamageThreshold(scenario_0, bool_0: true, bool_0, bool_1, _DamageThreshold.const_2);
				}
			}
			SetWithdrawDamageThreshold(scenario_0, bool_0: false, bool_0, bool_1, _DamageThreshold.const_2);
			break;
		case 3:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetWithdrawDamageThreshold(scenario_0, bool_0: true, bool_0, bool_1, _DamageThreshold.const_3);
				}
			}
			SetWithdrawDamageThreshold(scenario_0, bool_0: false, bool_0, bool_1, _DamageThreshold.const_3);
			break;
		case 4:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit5 in SelectedUnits)
				{
					selectedUnit5.Doctrine.SetWithdrawDamageThreshold(scenario_0, bool_0: true, bool_0, bool_1, _DamageThreshold.const_4);
				}
			}
			SetWithdrawDamageThreshold(scenario_0, bool_0: false, bool_0, bool_1, _DamageThreshold.const_4);
			break;
		case 5:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit6 in SelectedUnits)
				{
					selectedUnit6.Doctrine.SetWithdrawDamageThreshold(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetWithdrawDamageThreshold(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void SelectionChanged_Combo_RedeployDamageThreshold(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetRedeployDamageThreshold(scenario_0, bool_0: true, bool_0, bool_1, _DamageThreshold.Ignore);
				}
			}
			SetRedeployDamageThreshold(scenario_0, bool_0: false, bool_0, bool_1, _DamageThreshold.Ignore);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetRedeployDamageThreshold(scenario_0, bool_0: true, bool_0, bool_1, _DamageThreshold.Percent5);
				}
			}
			SetRedeployDamageThreshold(scenario_0, bool_0: false, bool_0, bool_1, _DamageThreshold.Percent5);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetRedeployDamageThreshold(scenario_0, bool_0: true, bool_0, bool_1, _DamageThreshold.const_2);
				}
			}
			SetRedeployDamageThreshold(scenario_0, bool_0: false, bool_0, bool_1, _DamageThreshold.const_2);
			break;
		case 3:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetRedeployDamageThreshold(scenario_0, bool_0: true, bool_0, bool_1, _DamageThreshold.const_3);
				}
			}
			SetRedeployDamageThreshold(scenario_0, bool_0: false, bool_0, bool_1, _DamageThreshold.const_3);
			break;
		case 4:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit5 in SelectedUnits)
				{
					selectedUnit5.Doctrine.SetRedeployDamageThreshold(scenario_0, bool_0: true, bool_0, bool_1, _DamageThreshold.const_4);
				}
			}
			SetRedeployDamageThreshold(scenario_0, bool_0: false, bool_0, bool_1, _DamageThreshold.const_4);
			break;
		case 5:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit6 in SelectedUnits)
				{
					selectedUnit6.Doctrine.SetRedeployDamageThreshold(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetRedeployDamageThreshold(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void SelectionChanged_Combo_WithdrawFuelThreshold(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetWithdrawFuelThreshold(scenario_0, bool_0: true, bool_0, bool_1, _FuelQuantityThreshold.Ignore);
				}
			}
			SetWithdrawFuelThreshold(scenario_0, bool_0: false, bool_0, bool_1, _FuelQuantityThreshold.Ignore);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetWithdrawFuelThreshold(scenario_0, bool_0: true, bool_0, bool_1, _FuelQuantityThreshold.Bingo);
				}
			}
			SetWithdrawFuelThreshold(scenario_0, bool_0: false, bool_0, bool_1, _FuelQuantityThreshold.Bingo);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetWithdrawFuelThreshold(scenario_0, bool_0: true, bool_0, bool_1, _FuelQuantityThreshold.const_2);
				}
			}
			SetWithdrawFuelThreshold(scenario_0, bool_0: false, bool_0, bool_1, _FuelQuantityThreshold.const_2);
			break;
		case 3:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetWithdrawFuelThreshold(scenario_0, bool_0: true, bool_0, bool_1, _FuelQuantityThreshold.const_3);
				}
			}
			SetWithdrawFuelThreshold(scenario_0, bool_0: false, bool_0, bool_1, _FuelQuantityThreshold.const_3);
			break;
		case 4:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit5 in SelectedUnits)
				{
					selectedUnit5.Doctrine.SetWithdrawFuelThreshold(scenario_0, bool_0: true, bool_0, bool_1, _FuelQuantityThreshold.const_4);
				}
			}
			SetWithdrawFuelThreshold(scenario_0, bool_0: false, bool_0, bool_1, _FuelQuantityThreshold.const_4);
			break;
		case 5:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit6 in SelectedUnits)
				{
					selectedUnit6.Doctrine.SetWithdrawFuelThreshold(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetWithdrawFuelThreshold(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void SelectionChanged_Combo_RedeployFuelThreshold(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetRedeployFuelThreshold(scenario_0, bool_0: true, bool_0, bool_1, _FuelQuantityThreshold.Ignore);
				}
			}
			SetRedeployFuelThreshold(scenario_0, bool_0: false, bool_0, bool_1, _FuelQuantityThreshold.Ignore);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetRedeployFuelThreshold(scenario_0, bool_0: true, bool_0, bool_1, _FuelQuantityThreshold.Bingo);
				}
			}
			SetRedeployFuelThreshold(scenario_0, bool_0: false, bool_0, bool_1, _FuelQuantityThreshold.Bingo);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetRedeployFuelThreshold(scenario_0, bool_0: true, bool_0, bool_1, _FuelQuantityThreshold.const_2);
				}
			}
			SetRedeployFuelThreshold(scenario_0, bool_0: false, bool_0, bool_1, _FuelQuantityThreshold.const_2);
			break;
		case 3:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetRedeployFuelThreshold(scenario_0, bool_0: true, bool_0, bool_1, _FuelQuantityThreshold.const_3);
				}
			}
			SetRedeployFuelThreshold(scenario_0, bool_0: false, bool_0, bool_1, _FuelQuantityThreshold.const_3);
			break;
		case 4:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit5 in SelectedUnits)
				{
					selectedUnit5.Doctrine.SetRedeployFuelThreshold(scenario_0, bool_0: true, bool_0, bool_1, _FuelQuantityThreshold.const_4);
				}
			}
			SetRedeployFuelThreshold(scenario_0, bool_0: false, bool_0, bool_1, _FuelQuantityThreshold.const_4);
			break;
		case 5:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit6 in SelectedUnits)
				{
					selectedUnit6.Doctrine.SetRedeployFuelThreshold(scenario_0, bool_0: true, bool_0, bool_1, _FuelQuantityThreshold.const_5);
				}
			}
			SetRedeployFuelThreshold(scenario_0, bool_0: false, bool_0, bool_1, _FuelQuantityThreshold.const_5);
			break;
		case 6:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit7 in SelectedUnits)
				{
					selectedUnit7.Doctrine.SetRedeployFuelThreshold(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetRedeployFuelThreshold(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void SelectionChanged_Combo_WithdrawAttackThreshold(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetWithdrawAttackThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.Ignore);
				}
			}
			SetWithdrawAttackThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.Ignore);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetWithdrawAttackThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.Exhausted);
				}
			}
			SetWithdrawAttackThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.Exhausted);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetWithdrawAttackThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.const_2);
				}
			}
			SetWithdrawAttackThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.const_2);
			break;
		case 3:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetWithdrawAttackThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.const_3);
				}
			}
			SetWithdrawAttackThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.const_3);
			break;
		case 4:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit5 in SelectedUnits)
				{
					selectedUnit5.Doctrine.SetWithdrawAttackThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.const_4);
				}
			}
			SetWithdrawAttackThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.const_4);
			break;
		case 5:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit6 in SelectedUnits)
				{
					selectedUnit6.Doctrine.SetWithdrawAttackThreshold(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetWithdrawAttackThreshold(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void SelectionChanged_Combo_RedeployAttackThreshold(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetRedeployAttackThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.Ignore);
				}
			}
			SetRedeployAttackThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.Ignore);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetRedeployAttackThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.Exhausted);
				}
			}
			SetRedeployAttackThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.Exhausted);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetRedeployAttackThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.const_2);
				}
			}
			SetRedeployAttackThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.const_2);
			break;
		case 3:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetRedeployAttackThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.const_3);
				}
			}
			SetRedeployAttackThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.const_3);
			break;
		case 4:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit5 in SelectedUnits)
				{
					selectedUnit5.Doctrine.SetRedeployAttackThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.const_4);
				}
			}
			SetRedeployAttackThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.const_4);
			break;
		case 5:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit6 in SelectedUnits)
				{
					selectedUnit6.Doctrine.SetRedeployAttackThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.const_5);
				}
			}
			SetRedeployAttackThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.const_5);
			break;
		case 6:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit7 in SelectedUnits)
				{
					selectedUnit7.Doctrine.SetRedeployAttackThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.LoadFullWeapons);
				}
			}
			SetRedeployAttackThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.LoadFullWeapons);
			break;
		case 7:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit8 in SelectedUnits)
				{
					selectedUnit8.Doctrine.SetRedeployAttackThreshold(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetRedeployAttackThreshold(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void SelectionChanged_Combo_WithdrawDefenceThreshold(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetWithdrawDefenceThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.Ignore);
				}
			}
			SetWithdrawDefenceThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.Ignore);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetWithdrawDefenceThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.Exhausted);
				}
			}
			SetWithdrawDefenceThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.Exhausted);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetWithdrawDefenceThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.const_2);
				}
			}
			SetWithdrawDefenceThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.const_2);
			break;
		case 3:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetWithdrawDefenceThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.const_3);
				}
			}
			SetWithdrawDefenceThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.const_3);
			break;
		case 4:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit5 in SelectedUnits)
				{
					selectedUnit5.Doctrine.SetWithdrawDefenceThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.const_4);
				}
			}
			SetWithdrawDefenceThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.const_4);
			break;
		case 5:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit6 in SelectedUnits)
				{
					selectedUnit6.Doctrine.SetWithdrawDefenceThreshold(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetWithdrawDefenceThreshold(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}

	public void SelectionChanged_Combo_RedeployDefenceThreshold(ComboBox comboBox_0, ref Scenario scenario_0, ref int int_0, bool bool_0, bool bool_1)
	{
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit in SelectedUnits)
				{
					selectedUnit.Doctrine.SetRedeployDefenceThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.Ignore);
				}
			}
			SetRedeployDefenceThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.Ignore);
			break;
		case 1:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					selectedUnit2.Doctrine.SetRedeployDefenceThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.Exhausted);
				}
			}
			SetRedeployDefenceThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.Exhausted);
			break;
		case 2:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit3 in SelectedUnits)
				{
					selectedUnit3.Doctrine.SetRedeployDefenceThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.const_2);
				}
			}
			SetRedeployDefenceThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.const_2);
			break;
		case 3:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit4 in SelectedUnits)
				{
					selectedUnit4.Doctrine.SetRedeployDefenceThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.const_3);
				}
			}
			SetRedeployDefenceThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.const_3);
			break;
		case 4:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit5 in SelectedUnits)
				{
					selectedUnit5.Doctrine.SetRedeployDefenceThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.const_4);
				}
			}
			SetRedeployDefenceThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.const_4);
			break;
		case 5:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit6 in SelectedUnits)
				{
					selectedUnit6.Doctrine.SetRedeployDefenceThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.const_5);
				}
			}
			SetRedeployDefenceThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.const_5);
			break;
		case 6:
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit7 in SelectedUnits)
				{
					selectedUnit7.Doctrine.SetRedeployDefenceThreshold(scenario_0, bool_0: true, bool_0, bool_1, _WeaponQuantityThreshold.LoadFullWeapons);
				}
			}
			SetRedeployDefenceThreshold(scenario_0, bool_0: false, bool_0, bool_1, _WeaponQuantityThreshold.LoadFullWeapons);
			break;
		case 7:
			if ((object)SubjectType == typeof(Side))
			{
				GameGeneral.ResolveBridge("分方的条令/交战规则不能是继承的！", (Side)Subject);
				comboBox_0.SelectedIndex = int_0;
				break;
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				foreach (ActiveUnit selectedUnit8 in SelectedUnits)
				{
					selectedUnit8.Doctrine.SetRedeployDefenceThreshold(scenario_0, bool_0: true, bool_0, bool_1, null);
				}
			}
			SetRedeployDefenceThreshold(scenario_0, bool_0: false, bool_0, bool_1, null);
			break;
		}
	}
}
