using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Command_Core.DAL;
using Command_Core.LoadSave;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OpenDis.Pages;

namespace Command_Core;

public sealed class SBR
{
	[CompilerGenerated]
	private sealed class ProccesorDispatcherList
	{
		public Cargo Local_theCargo;

		public Func<Cargo, bool> _003C_003E9__0;

		internal bool RemoveInterruptibleReg(Cargo CARGO)
		{
			return Operators.CompareString(CARGO.ObjectID, Local_theCargo.ObjectID, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class ComparatorItem
	{
		public Cargo Local_theCargo;

		public Func<Cargo, bool> _003C_003E9__0;

		internal bool FindInterruptibleReg(Cargo CARGO)
		{
			return Operators.CompareString(CARGO.ObjectID, Local_theCargo.ObjectID, TextCompare: false) == 0;
		}
	}

	public static void GenerateTemplate(Scenario scenario_0, Stream stream_0, ref bool bool_0)
	{
		bool_0 = true;
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Indent = true;
		xmlWriterSettings.IndentChars = "    ";
		try
		{
			using XmlWriter xmlWriter = XmlWriter.Create(stream_0, xmlWriterSettings);
			xmlWriter.WriteStartElement("ScenarioUnits");
			foreach (ActiveUnit value in scenario_0.ActiveUnits.Values)
			{
				xmlWriter.WriteStartElement("Unit_" + value.ObjectID);
				xmlWriter.WriteComment(value.Name + " (" + value.UnitClass + " [" + Conversions.ToString(value.DBID) + "])");
				xmlWriter.WriteEndElement();
			}
			xmlWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101113", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			bool_0 = false;
			ProjectData.ClearProjectError();
		}
	}

	public static void CloneHostedAircraftToUnit(ActiveUnit activeUnit_0, ref ActiveUnit activeUnit_1)
	{
		AirFacility[] airFacilities_ReadOnly = activeUnit_0.AirFacilities_ReadOnly;
		for (int i = 0; i < airFacilities_ReadOnly.Length; i++)
		{
			foreach (Aircraft value in airFacilities_ReadOnly[i].HostedAircraft.Values)
			{
				ActiveUnit activeUnit = CloneModifiedUnit(value, value.GetLatitude(), value.GetLongitude());
				if (activeUnit != null)
				{
					activeUnit_1.AirOps.AddThisAircraft((Aircraft)activeUnit, bool_0: true);
				}
			}
		}
	}

	public static void CloneHostedBoatToUnit(ActiveUnit activeUnit_0, ref ActiveUnit activeUnit_1)
	{
		DockFacility[] dockFacilities_ReadOnly = activeUnit_0.DockFacilities_ReadOnly;
		for (int i = 0; i < dockFacilities_ReadOnly.Length; i++)
		{
			foreach (ActiveUnit value in dockFacilities_ReadOnly[i].DestroyRepository().Values)
			{
				ActiveUnit activeUnit_2 = CloneModifiedUnit(value, value.GetLatitude(), value.GetLongitude());
				activeUnit_1.DockingOps.AddThisBoat(activeUnit_2);
			}
		}
	}

	public static ActiveUnit CloneModifiedUnit(ActiveUnit activeUnit_0, double double_0, double double_1)
	{
		try
		{
			ActiveUnit activeUnit_ = null;
			try
			{
				switch (activeUnit_0.UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					activeUnit_ = ((((Aircraft)activeUnit_0).Loadout == null) ? activeUnit_0.ParentScen.AddNewAircraft(activeUnit_0.GetUnitSide(), activeUnit_0.Name, double_1, double_0, activeUnit_0.DBID, 0, activeUnit_0.GetCurrentAltitude()) : activeUnit_0.ParentScen.AddNewAircraft(activeUnit_0.GetUnitSide(), activeUnit_0.Name, double_1, double_0, activeUnit_0.DBID, ((Aircraft)activeUnit_0).Loadout.DBID, activeUnit_0.GetCurrentAltitude()));
					break;
				case GlobalVariables.ActiveUnitType.Ship:
					activeUnit_ = activeUnit_0.ParentScen.AddNewShip(activeUnit_0.GetUnitSide(), activeUnit_0.DBID, activeUnit_0.Name, double_1, double_0);
					CloneHostedAircraftToUnit(activeUnit_0, ref activeUnit_);
					CloneHostedBoatToUnit(activeUnit_0, ref activeUnit_);
					break;
				case GlobalVariables.ActiveUnitType.Submarine:
					activeUnit_ = activeUnit_0.ParentScen.AddNewSubmarine(activeUnit_0.GetUnitSide(), activeUnit_0.DBID, activeUnit_0.Name, double_1, double_0);
					CloneHostedBoatToUnit(activeUnit_0, ref activeUnit_);
					break;
				case GlobalVariables.ActiveUnitType.Facility:
					activeUnit_ = activeUnit_0.ParentScen.AddNewFacility(activeUnit_0.GetUnitSide(), activeUnit_0.DBID, activeUnit_0.Name, double_1, double_0);
					CloneHostedAircraftToUnit(activeUnit_0, ref activeUnit_);
					break;
				case GlobalVariables.ActiveUnitType.Vehicle:
					activeUnit_ = activeUnit_0.ParentScen.AddNewVehicle(activeUnit_0.GetUnitSide(), activeUnit_0.DBID, activeUnit_0.Name, double_1, double_0);
					CloneHostedAircraftToUnit(activeUnit_0, ref activeUnit_);
					break;
				case GlobalVariables.ActiveUnitType.Aimpoint:
				case GlobalVariables.ActiveUnitType.Weapon:
				case GlobalVariables.ActiveUnitType.Satellite:
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				GameGeneral.ResolveBridge("错误：" + ex2.Message, activeUnit_0.GetUnitSide());
				ProjectData.ClearProjectError();
			}
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.Indent = true;
			xmlWriterSettings.IndentChars = "    ";
			xmlWriterSettings.ConformanceLevel = ConformanceLevel.Auto;
			MemoryTributary memoryTributary = new MemoryTributary();
			XmlWriter xmlWriter = XmlWriter.Create(memoryTributary, xmlWriterSettings);
			xmlWriter.WriteStartElement("ScenarioUnits");
			StreamWriter streamWriter_ = null;
			int int_ = 0;
			GenerateDeltaFragmentForThisUnit(activeUnit_0, activeUnit_0.ParentScen, xmlWriter, streamWriter_, ref int_);
			xmlWriter.WriteEndElement();
			xmlWriter.Flush();
			if (memoryTributary.Length <= 60)
			{
				return activeUnit_;
			}
			xmlWriter.Flush();
			memoryTributary.Seek(0L, SeekOrigin.Begin);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(memoryTributary);
			RenameNode(xmlDocument.SelectSingleNode("/ScenarioUnits").ChildNodes[0], "", "Unit_" + activeUnit_.ObjectID);
			memoryTributary = new MemoryTributary();
			xmlDocument.Save(memoryTributary);
			memoryTributary.Seek(0L, SeekOrigin.Begin);
			ApplyScriptToScenario(activeUnit_0.ParentScen, null, bool_0: true, memoryTributary);
			if (activeUnit_0.UnitType == GlobalVariables.ActiveUnitType.Submarine)
			{
				foreach (ActiveUnit assignedBoat in activeUnit_.DockingOps.AssignedBoats)
				{
					if (assignedBoat.DockingOps.HostDockFacility == null)
					{
						activeUnit_.DockingOps.AddThisBoat(assignedBoat);
					}
				}
			}
			activeUnit_.CurrentHeading = activeUnit_0.CurrentHeading;
			return activeUnit_;
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

	public static XmlNode RenameNode(XmlNode xmlNode_0, string string_0, string string_1)
	{
		if (xmlNode_0.NodeType == XmlNodeType.Element)
		{
			XmlElement xmlElement = (XmlElement)xmlNode_0;
			XmlElement xmlElement2 = xmlNode_0.OwnerDocument.CreateElement(string_1, string_0);
			while (xmlElement.HasAttributes)
			{
				xmlElement2.SetAttributeNode(xmlElement.RemoveAttributeNode(xmlElement.Attributes[0]));
			}
			while (xmlElement.HasChildNodes)
			{
				xmlElement2.AppendChild(xmlElement.FirstChild);
			}
			if (xmlElement.ParentNode != null)
			{
				xmlElement.ParentNode.ReplaceChild(xmlElement2, xmlElement);
			}
			return xmlElement2;
		}
		return null;
	}

	public static void GenerateDeltaTemplate(Scenario scenario_0, Stream stream_0, string string_0, ActiveUnit activeUnit_0)
	{
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Indent = true;
		xmlWriterSettings.IndentChars = "    ";
		try
		{
			string text = "想定：" + scenario_0.Title + "\r\nScenario file: " + GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Scenarios" + Conversions.ToString(Path.DirectorySeparatorChar) + scenario_0.FileName + ".scen\r\nConfig file:   " + string_0;
			StreamWriter streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR INI template log file.txt");
			streamWriter.Write("\r\n\r\n" + text);
			streamWriter.Close();
			int int_ = 0;
			using (XmlWriter xmlWriter = XmlWriter.Create(stream_0, xmlWriterSettings))
			{
				xmlWriter.WriteStartElement("ScenarioUnits");
				if (Information.IsNothing(activeUnit_0))
				{
					foreach (ActiveUnit value in scenario_0.ActiveUnits.Values)
					{
						GenerateDeltaFragmentForThisUnit(value, scenario_0, xmlWriter, streamWriter, ref int_);
						if (xmlWriter.WriteState == WriteState.Error)
						{
							if (int_ == 0)
							{
								int_ = -1;
							}
							break;
						}
					}
				}
				else
				{
					GenerateDeltaFragmentForThisUnit(activeUnit_0, scenario_0, xmlWriter, streamWriter, ref int_);
				}
				xmlWriter.WriteEndElement();
			}
			if (Information.IsNothing(activeUnit_0))
			{
				if (int_ == 0)
				{
					GameGeneral.ResolveBridge("INI模板已完成，未检测到错误。", null);
				}
				else
				{
					GameGeneral.ResolveBridge("INI template completed with errors.\r\n\r\nNUMBER OF ERRORS FOUND: " + Conversions.ToString(int_) + "\r\n\r\n Please check '" + GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR INI template log file.txt' for details.", null);
				}
			}
			text = "导出已完成";
			streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR INI template log file.txt");
			streamWriter.Write("\r\n" + text);
			streamWriter.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101114", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			GameGeneral.ResolveBridge("INI delta template failed.\r\n\r\n Please check Exception Log for details.", null);
			ProjectData.ClearProjectError();
		}
	}

	public static void GenerateDeltaFragmentForThisUnit(ActiveUnit activeUnit_0, Scenario scenario_0, XmlWriter xmlWriter_0, StreamWriter streamWriter_0, ref int int_0, bool bool_0 = false)
	{
		try
		{
			SQLiteHelper sQLiteHelper = new SQLiteHelper(scenario_0.DBConnection);
			string text = "";
			string text12 = "";
			DataTable dataTable = null;
			ActiveUnit activeUnit = null;
			string string_ = null;
			string string_2 = null;
			string text23 = null;
			string string_3 = null;
			string string_4 = null;
			switch (activeUnit_0.UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				string_ = "select ComponentID, Name, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2 from DataAircraftMounts as dsm, DataMount as dm  where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and  dsm.ComponentID = dm.ID) ORDER BY dm.Name ASC";
				string_2 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataAircraftSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type < 6000 or Type > 6999) ORDER BY dm.Type, dm.Name ASC";
				text23 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataAircraftSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type > 6000 and Type < 7000) ORDER BY dm.Type, dm.Name ASC";
				string_3 = "select ComponentID, Name from DataAircraftComms as dsm, DataComm as dm  where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and  dsm.ComponentID = dm.ID)";
				activeUnit = new Aircraft(ref scenario_0);
				break;
			case GlobalVariables.ActiveUnitType.Ship:
				string_ = "select ComponentID, Name, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2 from DataShipMounts as dsm, DataMount as dm  where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and  dsm.ComponentID = dm.ID) ORDER BY dm.Name ASC";
				string_4 = "select ComponentID, Name from DataShipMagazines as dsmag, DataMagazine as dmag  where (dsmag.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and  dsmag.ComponentID = dmag.ID) ORDER BY dmag.Name ASC";
				string_2 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataShipSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and dsm.ComponentID = dm.ID) and (Type < 6000 or Type > 6999) ORDER BY dm.Type, dm.Name ASC";
				text23 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataShipSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type > 6000 and Type < 7000) ORDER BY dm.Type, dm.Name ASC";
				string_3 = "select ComponentID, Name from DataShipComms as dsm, DataComm as dm  where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and  dsm.ComponentID = dm.ID)";
				text12 = "select * from DataShipDockingFacilities where id = " + Conversions.ToString(activeUnit_0.DBID);
				text = "select * from DataShipAircraftFacilities where id = " + Conversions.ToString(activeUnit_0.DBID);
				activeUnit = new Ship(ref scenario_0);
				break;
			case GlobalVariables.ActiveUnitType.Submarine:
				string_ = "select ComponentID, Name, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2 from DataSubmarineMounts as dsm, DataMount as dm  where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and  dsm.ComponentID = dm.ID) ORDER BY dm.Name ASC";
				string_4 = "select ComponentID, Name from DataSubmarineMagazines as dsmag, DataMagazine as dmag  where (dsmag.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and  dsmag.ComponentID = dmag.ID) ORDER BY dmag.Name ASC";
				string_2 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataSubmarineSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type < 6000 or Type > 6999) ORDER BY dm.Type, dm.Name ASC";
				text23 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataSubmarineSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type > 6000 and Type < 7000) ORDER BY dm.Type, dm.Name ASC";
				string_3 = "select ComponentID, Name from DataSubmarineComms as dsm, DataComm as dm  where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and  dsm.ComponentID = dm.ID)";
				text12 = "select * from DataSubmarineDockingFacilities where id = " + Conversions.ToString(activeUnit_0.DBID);
				text = "select * from DataSubmarineAircraftFacilities where id = " + Conversions.ToString(activeUnit_0.DBID);
				activeUnit = new Submarine(ref scenario_0);
				break;
			case GlobalVariables.ActiveUnitType.Facility:
				string_ = "select ComponentID, Name, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2 from DataFacilityMounts as dsm, DataMount as dm  where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and  dsm.ComponentID = dm.ID) ORDER BY dm.Name ASC";
				string_4 = "select ComponentID, Name from DataFacilityMagazines as dsmag, DataMagazine as dmag  where (dsmag.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and  dsmag.ComponentID = dmag.ID) ORDER BY dmag.Name ASC";
				string_2 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataFacilitySensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type < 6000 or Type > 6999) ORDER BY dm.Type, dm.Name ASC";
				text23 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataFacilitySensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type > 6000 and Type < 7000) ORDER BY dm.Type, dm.Name ASC";
				string_3 = "select ComponentID, Name from DataFacilityComms as dsm, DataComm as dm  where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and  dsm.ComponentID = dm.ID)";
				text12 = "select * from DataFacilityDockingFacilities where id = " + Conversions.ToString(activeUnit_0.DBID);
				text = "select * from DataFacilityAircraftFacilities where id = " + Conversions.ToString(activeUnit_0.DBID);
				activeUnit = new Facility(ref scenario_0);
				break;
			case GlobalVariables.ActiveUnitType.Satellite:
				string_ = "select ComponentID, Name, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2 from DataSatelliteMounts as dsm, DataMount as dm  where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and  dsm.ComponentID = dm.ID) ORDER BY dm.Name ASC";
				string_2 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataSatelliteSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type < 6000 or Type > 6999) ORDER BY dm.Type, dm.Name ASC";
				text23 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataSatelliteSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type > 6000 and Type < 7000) ORDER BY dm.Type, dm.Name ASC";
				string_3 = "select ComponentID, Name from DataSatelliteComms as dsm, DataComm as dm  where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and  dsm.ComponentID = dm.ID)";
				activeUnit = new Satellite(ref scenario_0);
				break;
			case GlobalVariables.ActiveUnitType.Vehicle:
				string_ = "select ComponentID, Name, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2 from DataGroundUnitMounts as dsm, DataMount as dm  where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and  dsm.ComponentID = dm.ID) ORDER BY dm.Name ASC";
				string_2 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataGroundUnitSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type < 6000 or Type > 6999) ORDER BY dm.Type, dm.Name ASC";
				string_4 = "select ComponentID, Name from DataGroundUnitMagazines as dsmag, DataMagazine as dmag  where (dsmag.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and  dsmag.ComponentID = dmag.ID) ORDER BY dmag.Name ASC";
				text23 = "select ComponentID, Name, Type, SB1, SB2, SMF1, SMF2, SMA1, SMA2, SS1, SS2, PB1, PB2, PMF1, PMF2, PMA1, PMA2, PS1, PS2, SB1Max, SB2Max, SMF1Max, SMF2Max, SMA1Max, SMA2Max, SS1Max, SS2Max, PB1Max, PB2Max, PMF1Max, PMF2Max, PMA1Max, PMA2Max, PS1Max, PS2Max from DataGroundUnitSensors as dsm, DataSensor as dm where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and dsm.ComponentID = dm.ID) and Type <> 9001 and (Type > 6000 and Type < 7000) ORDER BY dm.Type, dm.Name ASC";
				string_3 = "select ComponentID, Name from DataGroundUnitComms as dsm, DataComm as dm  where (dsm.ID = " + Conversions.ToString(activeUnit_0.DBID) + " and  dsm.ComponentID = dm.ID)";
				activeUnit = new Vehicle(ref scenario_0);
				break;
			}
			bool flag = false;
			if (!(activeUnit_0.IsAircraft | activeUnit_0.IsFacility | activeUnit_0.IsShip | activeUnit_0.IsSubmarine | activeUnit_0.IsSatellite | activeUnit_0.IsVehicle))
			{
				return;
			}
			if (activeUnit_0.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)activeUnit_0;
				if (aircraft.FuelCapacityMax != aircraft.FuelCapacityCurrent)
				{
					flag = true;
				}
			}
			else if (!activeUnit_0.IsFacility && (activeUnit_0.IsShip || activeUnit_0.IsSubmarine) && activeUnit_0.FuelCapacityMax != activeUnit_0.FuelCapacityCurrent)
			{
				flag = true;
			}
			DataTable dataTable12 = new DataTable();
			if (!dataTable12.Columns.Contains("DBID"))
			{
				dataTable12.Columns.Add("DBID", typeof(int));
			}
			if (!dataTable12.Columns.Contains("Name"))
			{
				dataTable12.Columns.Add("Name", typeof(string));
			}
			Sensor[] sensors_Cached;
			if (!activeUnit_0.Sensory.Boolean_0)
			{
				sensors_Cached = activeUnit_0.Sensors_Cached;
				Sensor[] array6 = sensors_Cached;
				foreach (Sensor sensor in array6)
				{
					if (sensor.IsActive)
					{
						dataTable12.Rows.Add(sensor.DBID, sensor.Name);
					}
				}
			}
			DataTable dataTable23 = sQLiteHelper.ComputeSpecification(string_);
			if (!dataTable23.Columns.Contains("MountIndex"))
			{
				dataTable23.Columns.Add("MountIndex", typeof(int));
			}
			int num = dataTable23.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				dataTable23.Rows[i]["MountIndex"] = i;
			}
			DataTable dataTable32 = new DataTable();
			dataTable32.Columns.Add("ID", typeof(int));
			dataTable32.Columns.Add("Name", typeof(string));
			dataTable32.Columns.Add("SB1", typeof(bool));
			dataTable32.Columns.Add("SB2", typeof(bool));
			dataTable32.Columns.Add("SMF1", typeof(bool));
			dataTable32.Columns.Add("SMF2", typeof(bool));
			dataTable32.Columns.Add("SMA1", typeof(bool));
			dataTable32.Columns.Add("SMA2", typeof(bool));
			dataTable32.Columns.Add("SS1", typeof(bool));
			dataTable32.Columns.Add("SS2", typeof(bool));
			dataTable32.Columns.Add("PB1", typeof(bool));
			dataTable32.Columns.Add("PB2", typeof(bool));
			dataTable32.Columns.Add("PMF1", typeof(bool));
			dataTable32.Columns.Add("PMF2", typeof(bool));
			dataTable32.Columns.Add("PMA1", typeof(bool));
			dataTable32.Columns.Add("PMA2", typeof(bool));
			dataTable32.Columns.Add("PS1", typeof(bool));
			dataTable32.Columns.Add("PS2", typeof(bool));
			dataTable32.Columns.Add("Has360Coverage", typeof(bool));
			DataTable dataTable33 = new DataTable();
			dataTable33.Columns.Add("MountID", typeof(int));
			dataTable33.Columns.Add("MountIndex", typeof(int));
			dataTable33.Columns.Add("MountName", typeof(string));
			DataTable dataTable34 = new DataTable();
			dataTable34.Columns.Add("MountID", typeof(int));
			dataTable34.Columns.Add("MountIndex", typeof(int));
			dataTable34.Columns.Add("WeaponID", typeof(int));
			dataTable34.Columns.Add("WeaponQty", typeof(int));
			dataTable34.Columns.Add("WeaponName", typeof(string));
			DataTable dataTable35 = new DataTable();
			dataTable35.Columns.Add("MountID", typeof(int));
			dataTable35.Columns.Add("MountIndex", typeof(int));
			dataTable35.Columns.Add("WeapRecID", typeof(int));
			dataTable35.Columns.Add("WeaponName", typeof(string));
			dataTable35.Columns.Add("WeaponID", typeof(string));
			DataTable dataTable36 = new DataTable();
			dataTable36.Columns.Add("MountID", typeof(int));
			dataTable36.Columns.Add("MountIndex", typeof(int));
			dataTable36.Columns.Add("WeaponID", typeof(int));
			dataTable36.Columns.Add("WeaponName", typeof(string));
			DataTable dataTable38 = new DataTable();
			dataTable38.Columns.Add("MountID", typeof(int));
			dataTable38.Columns.Add("MountIndex", typeof(int));
			dataTable38.Columns.Add("MountName", typeof(string));
			DataTable dataTable37 = new DataTable();
			dataTable37.Columns.Add("MountID", typeof(int));
			dataTable37.Columns.Add("MountIndex", typeof(int));
			dataTable37.Columns.Add("WeaponID", typeof(int));
			dataTable37.Columns.Add("WeaponQty", typeof(int));
			dataTable37.Columns.Add("WeaponName", typeof(string));
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add("MountID", typeof(int));
			dataTable2.Columns.Add("MountIndex", typeof(int));
			dataTable2.Columns.Add("WeapRecID", typeof(int));
			dataTable2.Columns.Add("WeaponName", typeof(string));
			dataTable2.Columns.Add("WeaponID", typeof(string));
			DataTable dataTable3 = new DataTable();
			dataTable3.Columns.Add("MountID", typeof(int));
			dataTable3.Columns.Add("MountIndex", typeof(int));
			dataTable3.Columns.Add("WeaponID", typeof(int));
			dataTable3.Columns.Add("WeaponName", typeof(string));
			DataTable dataTable4 = new DataTable();
			dataTable4.Columns.Add("MountID", typeof(int));
			dataTable4.Columns.Add("MountIndex", typeof(int));
			dataTable4.Columns.Add("SensorID", typeof(int));
			dataTable4.Columns.Add("Name", typeof(string));
			dataTable4.Columns.Add("Remove", typeof(bool));
			dataTable38 = new DataTable();
			dataTable38.Columns.Add("MountID", typeof(int));
			dataTable38.Columns.Add("MountIndex", typeof(int));
			dataTable38.Columns.Add("CommsID", typeof(int));
			dataTable38.Columns.Add("Name", typeof(string));
			dataTable38.Columns.Add("Remove", typeof(bool));
			DataTable dataTable5 = new DataTable();
			dataTable5.Columns.Add("MagID", typeof(int));
			dataTable5.Columns.Add("MagIndex", typeof(int));
			dataTable5.Columns.Add("MagName", typeof(string));
			DataTable dataTable6 = new DataTable();
			dataTable6.Columns.Add("MagID", typeof(int));
			dataTable6.Columns.Add("MagIndex", typeof(int));
			dataTable6.Columns.Add("WeaponID", typeof(int));
			dataTable6.Columns.Add("WeaponQty", typeof(int));
			dataTable6.Columns.Add("WeaponName", typeof(string));
			DataTable dataTable7 = new DataTable();
			dataTable7.Columns.Add("MagID", typeof(int));
			dataTable7.Columns.Add("MagIndex", typeof(int));
			dataTable7.Columns.Add("WeapRecID", typeof(int));
			dataTable7.Columns.Add("WeaponName", typeof(string));
			dataTable7.Columns.Add("WeaponID", typeof(string));
			DataTable dataTable8 = new DataTable();
			dataTable8.Columns.Add("MagID", typeof(int));
			dataTable8.Columns.Add("MagIndex", typeof(int));
			dataTable8.Columns.Add("WeaponID", typeof(int));
			dataTable8.Columns.Add("WeaponName", typeof(string));
			int num88 = dataTable23.Rows.Count - 1;
			bool flag7 = false;
			IEnumerator enumerator = null;
			IEnumerator enumerator11 = null;
			IEnumerator enumerator14 = null;
			IEnumerator enumerator15 = null;
			IEnumerator enumerator16 = null;
			int num99 = 0;
			foreach (Mount mount in activeUnit_0.Mounts)
			{
				flag7 = false;
				try
				{
					enumerator = dataTable23.Rows.GetEnumerator();
					while (enumerator.MoveNext())
					{
						DataRow dataRow = (DataRow)enumerator.Current;
						if ((Conversions.ToInteger(dataRow["ComponentID"]) == mount.DBID) & (mount.Coverage.SB1 == Conversions.ToBoolean(dataRow["SB1"])) & (mount.Coverage.SB2 == Conversions.ToBoolean(dataRow["SB2"])) & (mount.Coverage.SMF1 == Conversions.ToBoolean(dataRow["SMF1"])) & (mount.Coverage.SMF2 == Conversions.ToBoolean(dataRow["SMF2"])) & (mount.Coverage.SMA1 == Conversions.ToBoolean(dataRow["SMA1"])) & (mount.Coverage.SMA2 == Conversions.ToBoolean(dataRow["SMA2"])) & (mount.Coverage.SS1 == Conversions.ToBoolean(dataRow["SS1"])) & (mount.Coverage.SS2 == Conversions.ToBoolean(dataRow["SS2"])) & (mount.Coverage.PB1 == Conversions.ToBoolean(dataRow["PB1"])) & (mount.Coverage.PB2 == Conversions.ToBoolean(dataRow["PB2"])) & (mount.Coverage.PMF1 == Conversions.ToBoolean(dataRow["PMF1"])) & (mount.Coverage.PMF2 == Conversions.ToBoolean(dataRow["PMF2"])) & (mount.Coverage.PMA1 == Conversions.ToBoolean(dataRow["PMA1"])) & (mount.Coverage.PMA2 == Conversions.ToBoolean(dataRow["PMA2"])) & (mount.Coverage.PS1 == Conversions.ToBoolean(dataRow["PS1"])) & (mount.Coverage.PS2 == Conversions.ToBoolean(dataRow["PS2"])))
						{
							num99 = Conversions.ToInteger(dataRow["MountIndex"].ToString());
							dataRow.Delete();
							flag7 = true;
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
				if (!flag7 && !flag7)
				{
					num99 = num88 + 1;
					num88++;
				}
				if (!flag7)
				{
					dataTable32.Rows.Add(mount.DBID, mount.Name, mount.Coverage.SB1, mount.Coverage.SB2, mount.Coverage.SMF1, mount.Coverage.SMF2, mount.Coverage.SMA1, mount.Coverage.SMA2, mount.Coverage.SS1, mount.Coverage.SS2, mount.Coverage.PB1, mount.Coverage.PB2, mount.Coverage.PMF1, mount.Coverage.PMF2, mount.Coverage.PMA1, mount.Coverage.PMA2, mount.Coverage.PS1, mount.Coverage.PS2, mount.Coverage.Has360Coverage());
				}
				Mount mount_ = new Mount();
				DBFunctions.PopulateMountSensors(ref mount_, mount.DBID, scenario_0.DBConnection);
				if (mount.Sensors_ReadOnly.Count() != mount_.Sensors_ReadOnly.Count())
				{
					if (mount.Sensors_ReadOnly.Count() == 0)
					{
						sensors_Cached = mount_.Sensors_ReadOnly;
						Sensor[] array7 = sensors_Cached;
						foreach (Sensor sensor2 in array7)
						{
							dataTable4.Rows.Add(mount.DBID, num99, sensor2.DBID, sensor2.Name, true);
						}
					}
					else
					{
						sensors_Cached = mount_.Sensors_ReadOnly;
						Sensor[] array8 = sensors_Cached;
						foreach (Sensor sensor3 in array8)
						{
							dataTable4.Rows.Add(mount.DBID, num99, sensor3.DBID, sensor3.Name, true);
						}
						sensors_Cached = mount.Sensors_ReadOnly;
						Sensor[] array9 = sensors_Cached;
						foreach (Sensor sensor4 in array9)
						{
							dataTable4.Rows.Add(mount.DBID, num99, sensor4.DBID, sensor4.Name, false);
						}
					}
				}
				string string_5 = "select dwr.ComponentID, DefaultLoad, MaxLoad, Multiple, Name from DataWeaponRecord dwr, DataMountWeapons dmw, DataWeapon dw where dmw.ID = " + Conversions.ToString(mount.DBID) + " and  dmw.ComponentID = dwr.ID and dw.ID = dwr.ComponentID;";
				DataTable dataTable9 = sQLiteHelper.ComputeSpecification(string_5);
				bool flag8 = false;
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					bool flag9 = false;
					try
					{
						enumerator11 = dataTable9.Rows.GetEnumerator();
						while (enumerator11.MoveNext())
						{
							DataRow dataRow12 = (DataRow)enumerator11.Current;
							int num110 = Conversions.ToInteger(dataRow12["ComponentID"]);
							string text34 = Conversions.ToString(dataRow12["Name"]);
							int num121 = Conversions.ToInteger(dataRow12["DefaultLoad"]);
							int num132 = Conversions.ToInteger(dataRow12["MaxLoad"]);
							int num143 = Conversions.ToInteger(dataRow12["Multiple"]);
							if ((num110 == mountWeapon.int_0) & (num132 == mountWeapon.MaxLoad) & (num143 == mountWeapon.Multiple))
							{
								dataRow12.Delete();
								flag9 = true;
								if (num121 != mountWeapon.CurrentLoad)
								{
									dataTable34.Rows.Add(mount.DBID, num99, mountWeapon.int_0, mountWeapon.CurrentLoad, text34);
									flag8 = true;
								}
								break;
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
					if (!flag9)
					{
						mountWeapon.ResetTimeToFire();
						string_5 = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = " + Conversions.ToString(mountWeapon.int_0) + " and DefaultLoad = " + Conversions.ToString(mountWeapon.CurrentLoad) + " and MaxLoad = " + Conversions.ToString(mountWeapon.MaxLoad) + " and Multiple = " + Conversions.ToString(mountWeapon.Multiple) + " and ROF = " + Conversions.ToString(mountWeapon.TimeToFire) + " and dw.ID = dwr.ComponentID;";
						DataTable dataTable10 = sQLiteHelper.ComputeSpecification(string_5);
						if (dataTable10.Rows.Count > 0)
						{
							DataRow dataRow23 = dataTable10.Rows[0];
							int num154 = Conversions.ToInteger(dataRow23["ID"]);
							string text45 = Conversions.ToString(dataRow23["Name"]);
							dataTable35.Rows.Add(mount.DBID, num99, num154, text45, mountWeapon.int_0);
							flag9 = true;
							flag8 = true;
						}
						string_5 = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = " + Conversions.ToString(mountWeapon.int_0) + " and DefaultLoad = " + Conversions.ToString(mountWeapon.DefaultLoad) + " and MaxLoad = " + Conversions.ToString(mountWeapon.MaxLoad) + " and Multiple = " + Conversions.ToString(mountWeapon.Multiple) + " and ROF = " + Conversions.ToString(mountWeapon.TimeToFire) + " and dw.ID = dwr.ComponentID;";
						dataTable10 = sQLiteHelper.ComputeSpecification(string_5);
						if (dataTable10.Rows.Count > 0 && !flag9)
						{
							DataRow dataRow34 = dataTable10.Rows[0];
							int num165 = Conversions.ToInteger(dataRow34["ID"]);
							string text56 = Conversions.ToString(dataRow34["Name"]);
							dataTable35.Rows.Add(mount.DBID, num99, num165, text56, mountWeapon.int_0);
							dataTable34.Rows.Add(mount.DBID, num99, mountWeapon.int_0, mountWeapon.CurrentLoad, text56);
							flag9 = true;
							flag8 = true;
						}
						string_5 = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = " + Conversions.ToString(mountWeapon.int_0) + " and DefaultLoad = " + Conversions.ToString(mountWeapon.CurrentLoad) + " and MaxLoad = " + Conversions.ToString(mountWeapon.MaxLoad) + " and Multiple = " + Conversions.ToString(mountWeapon.Multiple) + " and dw.ID = dwr.ComponentID;";
						dataTable10 = sQLiteHelper.ComputeSpecification(string_5);
						if (dataTable10.Rows.Count > 0 && !flag9)
						{
							DataRow dataRow45 = dataTable10.Rows[0];
							int num2 = Conversions.ToInteger(dataRow45["ID"]);
							string text58 = Conversions.ToString(dataRow45["Name"]);
							dataTable35.Rows.Add(mount.DBID, num99, num2, text58, mountWeapon.int_0);
							dataTable34.Rows.Add(mount.DBID, num99, mountWeapon.int_0, mountWeapon.CurrentLoad, text58);
							flag9 = true;
							flag8 = true;
						}
						string_5 = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = " + Conversions.ToString(mountWeapon.int_0) + " and DefaultLoad = " + Conversions.ToString(mountWeapon.DefaultLoad) + " and MaxLoad = " + Conversions.ToString(mountWeapon.MaxLoad) + " and Multiple = " + Conversions.ToString(mountWeapon.Multiple) + " and dw.ID = dwr.ComponentID;";
						dataTable10 = sQLiteHelper.ComputeSpecification(string_5);
						if (dataTable10.Rows.Count > 0 && !flag9)
						{
							DataRow dataRow49 = dataTable10.Rows[0];
							int num13 = Conversions.ToInteger(dataRow49["ID"]);
							string text59 = Conversions.ToString(dataRow49["Name"]);
							dataTable35.Rows.Add(mount.DBID, num99, num13, text59, mountWeapon.int_0);
							dataTable34.Rows.Add(mount.DBID, num99, mountWeapon.int_0, mountWeapon.CurrentLoad, text59);
							flag9 = true;
							flag8 = true;
						}
						string_5 = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = " + Conversions.ToString(mountWeapon.int_0) + " and MaxLoad = " + Conversions.ToString(mountWeapon.MaxLoad) + " and Multiple = " + Conversions.ToString(mountWeapon.Multiple) + " and dw.ID = dwr.ComponentID;";
						dataTable10 = sQLiteHelper.ComputeSpecification(string_5);
						if (dataTable10.Rows.Count > 0 && !flag9)
						{
							DataRow dataRow50 = dataTable10.Rows[0];
							int num24 = Conversions.ToInteger(dataRow50["ID"]);
							string text60 = Conversions.ToString(dataRow50["Name"]);
							dataTable35.Rows.Add(mount.DBID, num99, num24, text60, mountWeapon.int_0);
							dataTable34.Rows.Add(mount.DBID, num99, mountWeapon.int_0, mountWeapon.CurrentLoad, text60);
							flag9 = true;
							flag8 = true;
						}
						if (!flag9 && Information.IsNothing(mountWeapon.WRecDBID) && mountWeapon.MaxLoad == 10000)
						{
							int num35 = 0;
							string text2 = (Information.IsNothing(mountWeapon.GetReferenceWeapon(scenario_0)) ? "错误：找不到名称" : mountWeapon.GetReferenceWeapon(scenario_0).Name);
							dataTable35.Rows.Add(mount.DBID, num99, num35, text2, mountWeapon.int_0);
							dataTable34.Rows.Add(mount.DBID, num99, mountWeapon.int_0, mountWeapon.CurrentLoad, text2);
							flag9 = true;
							flag8 = true;
						}
						if (!flag9)
						{
							string text3 = "警告：挂载" + mount.Name + " (ID: " + Conversions.ToString(mount.DBID) + "）有一个新的武器添加到它，但在数据库中找不到一个很好的匹配！武器ID：" + Conversions.ToString(mountWeapon.int_0) + "默认挂载：" + Conversions.ToString(mountWeapon.DefaultLoad) + "最大挂载：" + Conversions.ToString(mountWeapon.MaxLoad) + "多个：" + Conversions.ToString(mountWeapon.Multiple);
							streamWriter_0 = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR INI template log file.txt");
							streamWriter_0.Write("\r\n      " + text3);
							streamWriter_0.Close();
							int_0++;
						}
					}
				}
				if (dataTable9.Rows.Count > 0)
				{
					try
					{
						enumerator14 = dataTable9.Rows.GetEnumerator();
						while (enumerator14.MoveNext())
						{
							DataRow obj = (DataRow)enumerator14.Current;
							int num46 = Conversions.ToInteger(obj["ComponentID"]);
							string text4 = Conversions.ToString(obj["Name"]);
							dataTable36.Rows.Add(mount.DBID, num99, num46, text4);
						}
					}
					finally
					{
						if (enumerator14 is IDisposable)
						{
							(enumerator14 as IDisposable).Dispose();
						}
					}
					flag8 = true;
				}
				string_5 = "select dwr.ComponentID, DefaultLoad, MaxLoad, Multiple, Name from DataWeaponRecord dwr, DataMountMagazineWeapons dmw, DataWeapon dw where dmw.ID = " + Conversions.ToString(mount.DBID) + " and  dmw.ComponentID = dwr.ID and dw.ID = dwr.ComponentID;";
				dataTable9 = sQLiteHelper.ComputeSpecification(string_5);
				flag7 = false;
				foreach (WeaponRec weapon in mount.MountMagazine.Weapons)
				{
					bool flag10 = false;
					try
					{
						enumerator15 = dataTable9.Rows.GetEnumerator();
						while (enumerator15.MoveNext())
						{
							DataRow dataRow51 = (DataRow)enumerator15.Current;
							int num57 = Conversions.ToInteger(dataRow51["ComponentID"]);
							string text5 = Conversions.ToString(dataRow51["Name"]);
							int num68 = Conversions.ToInteger(dataRow51["DefaultLoad"]);
							int num79 = Conversions.ToInteger(dataRow51["MaxLoad"]);
							int num86 = Conversions.ToInteger(dataRow51["Multiple"]);
							if ((num57 == weapon.int_0) & (num79 == weapon.MaxLoad) & (num86 == weapon.Multiple))
							{
								dataRow51.Delete();
								flag10 = true;
								if (num68 != weapon.CurrentLoad)
								{
									dataTable37.Rows.Add(mount.DBID, num99, weapon.int_0, weapon.CurrentLoad, text5);
									flag8 = true;
								}
								break;
							}
						}
					}
					finally
					{
						if (enumerator15 is IDisposable)
						{
							(enumerator15 as IDisposable).Dispose();
						}
					}
					if (!flag10)
					{
						weapon.ResetTimeToFire();
						string_5 = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = " + Conversions.ToString(weapon.int_0) + " and DefaultLoad = " + Conversions.ToString(weapon.CurrentLoad) + " and MaxLoad = " + Conversions.ToString(weapon.MaxLoad) + " and Multiple = " + Conversions.ToString(weapon.Multiple) + " and ROF = " + Conversions.ToString(weapon.TimeToFire) + " and dw.ID = dwr.ComponentID;";
						DataTable dataTable11 = sQLiteHelper.ComputeSpecification(string_5);
						if (dataTable11.Rows.Count > 0)
						{
							DataRow dataRow52 = dataTable11.Rows[0];
							int num87 = Conversions.ToInteger(dataRow52["ID"]);
							string text6 = Conversions.ToString(dataRow52["Name"]);
							dataTable2.Rows.Add(mount.DBID, num99, num87, text6, weapon.int_0);
							flag10 = true;
							flag8 = true;
						}
						string_5 = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = " + Conversions.ToString(weapon.int_0) + " and DefaultLoad = " + Conversions.ToString(weapon.DefaultLoad) + " and MaxLoad = " + Conversions.ToString(weapon.MaxLoad) + " and Multiple = " + Conversions.ToString(weapon.Multiple) + " and ROF = " + Conversions.ToString(weapon.TimeToFire) + " and dw.ID = dwr.ComponentID;";
						dataTable11 = sQLiteHelper.ComputeSpecification(string_5);
						if (dataTable11.Rows.Count > 0 && !flag10)
						{
							DataRow dataRow2 = dataTable11.Rows[0];
							int num89 = Conversions.ToInteger(dataRow2["ID"]);
							string text7 = Conversions.ToString(dataRow2["Name"]);
							dataTable2.Rows.Add(mount.DBID, num99, num89, text7, weapon.int_0);
							dataTable37.Rows.Add(mount.DBID, num99, weapon.int_0, weapon.CurrentLoad, text7);
							flag10 = true;
							flag8 = true;
						}
						string_5 = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = " + Conversions.ToString(weapon.int_0) + " and DefaultLoad = " + Conversions.ToString(weapon.CurrentLoad) + " and MaxLoad = " + Conversions.ToString(weapon.MaxLoad) + " and Multiple = " + Conversions.ToString(weapon.Multiple) + " and dw.ID = dwr.ComponentID;";
						dataTable11 = sQLiteHelper.ComputeSpecification(string_5);
						if (dataTable11.Rows.Count > 0 && !flag10)
						{
							DataRow dataRow3 = dataTable11.Rows[0];
							int num90 = Conversions.ToInteger(dataRow3["ID"]);
							string text8 = Conversions.ToString(dataRow3["Name"]);
							dataTable2.Rows.Add(mount.DBID, num99, num90, text8, weapon.int_0);
							dataTable37.Rows.Add(mount.DBID, num99, weapon.int_0, weapon.CurrentLoad, text8);
							flag10 = true;
							flag8 = true;
						}
						string_5 = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = " + Conversions.ToString(weapon.int_0) + " and DefaultLoad = " + Conversions.ToString(weapon.DefaultLoad) + " and MaxLoad = " + Conversions.ToString(weapon.MaxLoad) + " and Multiple = " + Conversions.ToString(weapon.Multiple) + " and dw.ID = dwr.ComponentID;";
						dataTable11 = sQLiteHelper.ComputeSpecification(string_5);
						if (dataTable11.Rows.Count > 0 && !flag10)
						{
							DataRow dataRow4 = dataTable11.Rows[0];
							int num91 = Conversions.ToInteger(dataRow4["ID"]);
							string text9 = Conversions.ToString(dataRow4["Name"]);
							dataTable2.Rows.Add(mount.DBID, num99, num91, text9, weapon.int_0);
							dataTable37.Rows.Add(mount.DBID, num99, weapon.int_0, weapon.CurrentLoad, text9);
							flag10 = true;
							flag8 = true;
						}
						string_5 = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = " + Conversions.ToString(weapon.int_0) + " and MaxLoad = " + Conversions.ToString(weapon.MaxLoad) + " and Multiple = " + Conversions.ToString(weapon.Multiple) + " and dw.ID = dwr.ComponentID;";
						dataTable11 = sQLiteHelper.ComputeSpecification(string_5);
						if (dataTable11.Rows.Count > 0 && !flag10)
						{
							DataRow dataRow5 = dataTable11.Rows[0];
							int num92 = Conversions.ToInteger(dataRow5["ID"]);
							string text10 = Conversions.ToString(dataRow5["Name"]);
							dataTable2.Rows.Add(mount.DBID, num99, num92, text10, weapon.int_0);
							dataTable37.Rows.Add(mount.DBID, num99, weapon.int_0, weapon.CurrentLoad, text10);
							flag10 = true;
							flag8 = true;
						}
						if (!flag10 && Information.IsNothing(weapon.WRecDBID) && weapon.MaxLoad == 10000)
						{
							int num93 = 0;
							string text11 = (Information.IsNothing(weapon.GetReferenceWeapon(scenario_0)) ? "错误：找不到名称" : weapon.GetReferenceWeapon(scenario_0).Name);
							dataTable2.Rows.Add(mount.DBID, num99, num93, text11, weapon.int_0);
							dataTable37.Rows.Add(mount.DBID, num99, weapon.int_0, weapon.CurrentLoad, text11);
							flag10 = true;
							flag8 = true;
						}
						if (!flag10)
						{
							string text13 = "警告：挂载" + mount.Name + " (ID: " + Conversions.ToString(mount.DBID) + "）有一个新的挂载弹药库武器添加到它，但在数据库中找不到一个很好的匹配！武器ID：" + Conversions.ToString(weapon.int_0) + "默认挂载：" + Conversions.ToString(weapon.DefaultLoad) + "最大挂载：" + Conversions.ToString(weapon.MaxLoad) + "多个：" + Conversions.ToString(weapon.Multiple);
							streamWriter_0 = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR INI template log file.txt");
							streamWriter_0.Write("\r\n      " + text13);
							streamWriter_0.Close();
							int_0++;
						}
					}
				}
				if (dataTable9.Rows.Count > 0)
				{
					try
					{
						enumerator16 = dataTable9.Rows.GetEnumerator();
						while (enumerator16.MoveNext())
						{
							DataRow obj2 = (DataRow)enumerator16.Current;
							int num94 = Conversions.ToInteger(obj2["ComponentID"]);
							string text14 = Conversions.ToString(obj2["Name"]);
							dataTable3.Rows.Add(mount.DBID, num99, num94, text14);
						}
					}
					finally
					{
						if (enumerator16 is IDisposable)
						{
							(enumerator16 as IDisposable).Dispose();
						}
					}
					flag8 = true;
				}
				if (flag8)
				{
					dataTable33.Rows.Add(mount.DBID, num99, mount.Name);
				}
			}
			int num95 = 0;
			if (!Information.IsNothing(activeUnit_0.OnboardCargo))
			{
				num95 = activeUnit_0.OnboardCargo.Count();
			}
			DataTable dataTable13 = null;
			DataTable dataTable14 = null;
			Magazine[] array;
			if (activeUnit_0.IsFacility | activeUnit_0.IsShip | activeUnit_0.IsSubmarine | activeUnit_0.IsVehicle)
			{
				dataTable13 = sQLiteHelper.ComputeSpecification(string_4);
				if (!dataTable13.Columns.Contains("MagIndex"))
				{
					dataTable13.Columns.Add("MagIndex", typeof(int));
				}
				int num96 = dataTable13.Rows.Count - 1;
				for (int j = 0; j <= num96; j++)
				{
					dataTable13.Rows[j]["MagIndex"] = j;
				}
				dataTable14 = new DataTable();
				dataTable14.Columns.Add("ID", typeof(int));
				dataTable14.Columns.Add("Name", typeof(string));
				int num97 = dataTable13.Rows.Count - 1;
				Magazine[] sharedMagazines = activeUnit_0.SharedMagazines;
				IEnumerator enumerator17 = null;
				int num98 = 0;
				IEnumerator enumerator18 = null;
				IEnumerator enumerator2 = null;
				array = sharedMagazines;
				Magazine[] array10 = array;
				foreach (Magazine magazine in array10)
				{
					bool flag11 = false;
					try
					{
						enumerator17 = dataTable13.Rows.GetEnumerator();
						while (enumerator17.MoveNext())
						{
							DataRow dataRow6 = (DataRow)enumerator17.Current;
							if (Conversions.ToInteger(dataRow6["ComponentID"]) == magazine.DBID)
							{
								num98 = Conversions.ToInteger(dataRow6["MagIndex"].ToString());
								dataRow6.Delete();
								flag11 = true;
								break;
							}
						}
					}
					finally
					{
						if (enumerator17 is IDisposable)
						{
							(enumerator17 as IDisposable).Dispose();
						}
					}
					if (!flag11 && !flag7)
					{
						num98 = num97 + 1;
						num97++;
					}
					if (!flag11)
					{
						dataTable14.Rows.Add(magazine.DBID, magazine.Name);
					}
					string string_6 = "select dwr.ComponentID, DefaultLoad, MaxLoad, Multiple, Name from DataWeaponRecord dwr, DataMagazineWeapons dmw, DataWeapon dw where dmw.ID = " + Conversions.ToString(magazine.DBID) + " and  dmw.ComponentID = dwr.ID and dw.ID = dwr.ComponentID;";
					DataTable dataTable15 = sQLiteHelper.ComputeSpecification(string_6);
					bool flag12 = false;
					foreach (WeaponRec weapon2 in magazine.Weapons)
					{
						bool flag13 = false;
						try
						{
							enumerator18 = dataTable15.Rows.GetEnumerator();
							while (enumerator18.MoveNext())
							{
								DataRow dataRow7 = (DataRow)enumerator18.Current;
								int num100 = Conversions.ToInteger(dataRow7["ComponentID"]);
								string text15 = Conversions.ToString(dataRow7["Name"]);
								int num101 = Conversions.ToInteger(dataRow7["DefaultLoad"]);
								int num102 = Conversions.ToInteger(dataRow7["MaxLoad"]);
								int num103 = Conversions.ToInteger(dataRow7["Multiple"]);
								if ((num100 == weapon2.int_0) & (num102 == weapon2.MaxLoad) & (num103 == weapon2.Multiple))
								{
									dataRow7.Delete();
									flag13 = true;
									if (num101 != weapon2.CurrentLoad)
									{
										dataTable6.Rows.Add(magazine.DBID, num98, weapon2.int_0, weapon2.CurrentLoad, text15);
										flag12 = true;
									}
									break;
								}
							}
						}
						finally
						{
							if (enumerator18 is IDisposable)
							{
								(enumerator18 as IDisposable).Dispose();
							}
						}
						if (!flag13)
						{
							weapon2.ResetTimeToFire();
							string_6 = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = " + Conversions.ToString(weapon2.int_0) + " and DefaultLoad = " + Conversions.ToString(weapon2.CurrentLoad) + " and MaxLoad = " + Conversions.ToString(weapon2.MaxLoad) + " and Multiple = " + Conversions.ToString(weapon2.Multiple) + " and ROF = " + Conversions.ToString(weapon2.TimeToFire) + " and dw.ID = dwr.ComponentID;";
							DataTable dataTable16 = sQLiteHelper.ComputeSpecification(string_6);
							if (dataTable16.Rows.Count > 0)
							{
								DataRow dataRow8 = dataTable16.Rows[0];
								int num104 = Conversions.ToInteger(dataRow8["ID"]);
								string text16 = Conversions.ToString(dataRow8["Name"]);
								dataTable7.Rows.Add(magazine.DBID, num98, num104, text16, weapon2.int_0);
								flag13 = true;
								flag12 = true;
							}
							string_6 = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = " + Conversions.ToString(weapon2.int_0) + " and DefaultLoad = " + Conversions.ToString(weapon2.DefaultLoad) + " and MaxLoad = " + Conversions.ToString(weapon2.MaxLoad) + " and Multiple = " + Conversions.ToString(weapon2.Multiple) + " and ROF = " + Conversions.ToString(weapon2.TimeToFire) + " and dw.ID = dwr.ComponentID;";
							dataTable16 = sQLiteHelper.ComputeSpecification(string_6);
							if (dataTable16.Rows.Count > 0 && !flag13)
							{
								DataRow dataRow9 = dataTable16.Rows[0];
								int num105 = Conversions.ToInteger(dataRow9["ID"]);
								string text17 = Conversions.ToString(dataRow9["Name"]);
								dataTable7.Rows.Add(magazine.DBID, num98, num105, text17, weapon2.int_0);
								dataTable6.Rows.Add(magazine.DBID, num98, weapon2.int_0, weapon2.CurrentLoad, text17);
								flag13 = true;
								flag12 = true;
							}
							string_6 = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = " + Conversions.ToString(weapon2.int_0) + " and DefaultLoad = " + Conversions.ToString(weapon2.CurrentLoad) + " and MaxLoad = " + Conversions.ToString(weapon2.MaxLoad) + " and Multiple = " + Conversions.ToString(weapon2.Multiple) + " and dw.ID = dwr.ComponentID;";
							dataTable16 = sQLiteHelper.ComputeSpecification(string_6);
							if (dataTable16.Rows.Count > 0 && !flag13)
							{
								DataRow dataRow10 = dataTable16.Rows[0];
								int num106 = Conversions.ToInteger(dataRow10["ID"]);
								string text18 = Conversions.ToString(dataRow10["Name"]);
								dataTable7.Rows.Add(magazine.DBID, num98, num106, text18, weapon2.int_0);
								dataTable6.Rows.Add(magazine.DBID, num98, weapon2.int_0, weapon2.CurrentLoad, text18);
								flag13 = true;
								flag12 = true;
							}
							string_6 = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = " + Conversions.ToString(weapon2.int_0) + " and DefaultLoad = " + Conversions.ToString(weapon2.DefaultLoad) + " and MaxLoad = " + Conversions.ToString(weapon2.MaxLoad) + " and Multiple = " + Conversions.ToString(weapon2.Multiple) + " and dw.ID = dwr.ComponentID;";
							dataTable16 = sQLiteHelper.ComputeSpecification(string_6);
							if (dataTable16.Rows.Count > 0 && !flag13)
							{
								DataRow dataRow11 = dataTable16.Rows[0];
								int num107 = Conversions.ToInteger(dataRow11["ID"]);
								string text19 = Conversions.ToString(dataRow11["Name"]);
								dataTable7.Rows.Add(magazine.DBID, num98, num107, text19, weapon2.int_0);
								dataTable6.Rows.Add(magazine.DBID, num98, weapon2.int_0, weapon2.CurrentLoad, text19);
								flag13 = true;
								flag12 = true;
							}
							string_6 = "select dwr.ID, dw.Name from DataWeaponRecord dwr, DataWeapon dw where dwr.ComponentID = " + Conversions.ToString(weapon2.int_0) + " and MaxLoad = " + Conversions.ToString(weapon2.MaxLoad) + " and Multiple = " + Conversions.ToString(weapon2.Multiple) + " and dw.ID = dwr.ComponentID;";
							dataTable16 = sQLiteHelper.ComputeSpecification(string_6);
							if (dataTable16.Rows.Count > 0 && !flag13)
							{
								DataRow dataRow13 = dataTable16.Rows[0];
								int num108 = Conversions.ToInteger(dataRow13["ID"]);
								string text20 = Conversions.ToString(dataRow13["Name"]);
								dataTable7.Rows.Add(magazine.DBID, num98, num108, text20, weapon2.int_0);
								dataTable6.Rows.Add(magazine.DBID, num98, weapon2.int_0, weapon2.CurrentLoad, text20);
								flag13 = true;
								flag12 = true;
							}
							if (!flag13 && Information.IsNothing(weapon2.WRecDBID) && weapon2.MaxLoad == 10000)
							{
								int num109 = 0;
								string text21 = (Information.IsNothing(weapon2.GetReferenceWeapon(scenario_0)) ? "错误：找不到名称" : weapon2.GetReferenceWeapon(scenario_0).Name);
								dataTable7.Rows.Add(magazine.DBID, num98, num109, text21, weapon2.int_0);
								dataTable6.Rows.Add(magazine.DBID, num98, weapon2.int_0, weapon2.CurrentLoad, text21);
								flag13 = true;
								flag12 = true;
							}
							if (!flag13)
							{
								string text22 = "警告：弹药库" + magazine.Name + " (ID: " + Conversions.ToString(magazine.DBID) + "）有一个新的武器添加到它，但在数据库中找不到一个很好的匹配！武器ID：" + Conversions.ToString(weapon2.int_0) + "默认挂载：" + Conversions.ToString(weapon2.DefaultLoad) + "最大挂载：" + Conversions.ToString(weapon2.MaxLoad) + "多个：" + Conversions.ToString(weapon2.Multiple);
								streamWriter_0 = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR INI template log file.txt");
								streamWriter_0.Write("\r\n      " + text22);
								streamWriter_0.Close();
								int_0++;
							}
						}
					}
					if (dataTable15.Rows.Count > 0)
					{
						try
						{
							enumerator2 = dataTable15.Rows.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								DataRow obj3 = (DataRow)enumerator2.Current;
								int num111 = Conversions.ToInteger(obj3["ComponentID"]);
								string text24 = Conversions.ToString(obj3["Name"]);
								dataTable8.Rows.Add(magazine.DBID, num98, num111, text24);
							}
						}
						finally
						{
							if (enumerator2 is IDisposable)
							{
								(enumerator2 as IDisposable).Dispose();
							}
						}
						flag12 = true;
					}
					if (flag12)
					{
						dataTable5.Rows.Add(magazine.DBID, num98, magazine.Name);
					}
				}
			}
			else
			{
				if (!Information.IsNothing(dataTable13))
				{
					dataTable13.Rows.Clear();
				}
				if (!Information.IsNothing(dataTable14))
				{
					dataTable14.Rows.Clear();
				}
			}
			DataTable dataTable17 = new DataTable();
			dataTable17.Columns.Add("ComponentID", typeof(int));
			dataTable17.Columns.Add("Name", typeof(string));
			dataTable17.Columns.Add("Type", typeof(int));
			dataTable17.Columns.Add("SB1", typeof(bool));
			dataTable17.Columns.Add("SB2", typeof(bool));
			dataTable17.Columns.Add("SMF1", typeof(bool));
			dataTable17.Columns.Add("SMF2", typeof(bool));
			dataTable17.Columns.Add("SMA1", typeof(bool));
			dataTable17.Columns.Add("SMA2", typeof(bool));
			dataTable17.Columns.Add("SS1", typeof(bool));
			dataTable17.Columns.Add("SS2", typeof(bool));
			dataTable17.Columns.Add("PB1", typeof(bool));
			dataTable17.Columns.Add("PB2", typeof(bool));
			dataTable17.Columns.Add("PMF1", typeof(bool));
			dataTable17.Columns.Add("PMF2", typeof(bool));
			dataTable17.Columns.Add("PMA1", typeof(bool));
			dataTable17.Columns.Add("PMA2", typeof(bool));
			dataTable17.Columns.Add("PS1", typeof(bool));
			dataTable17.Columns.Add("PS2", typeof(bool));
			dataTable17.Columns.Add("SB1Max", typeof(bool));
			dataTable17.Columns.Add("SB2Max", typeof(bool));
			dataTable17.Columns.Add("SMF1Max", typeof(bool));
			dataTable17.Columns.Add("SMF2Max", typeof(bool));
			dataTable17.Columns.Add("SMA1Max", typeof(bool));
			dataTable17.Columns.Add("SMA2Max", typeof(bool));
			dataTable17.Columns.Add("SS1Max", typeof(bool));
			dataTable17.Columns.Add("SS2Max", typeof(bool));
			dataTable17.Columns.Add("PB1Max", typeof(bool));
			dataTable17.Columns.Add("PB2Max", typeof(bool));
			dataTable17.Columns.Add("PMF1Max", typeof(bool));
			dataTable17.Columns.Add("PMF2Max", typeof(bool));
			dataTable17.Columns.Add("PMA1Max", typeof(bool));
			dataTable17.Columns.Add("PMA2Max", typeof(bool));
			dataTable17.Columns.Add("PS1Max", typeof(bool));
			dataTable17.Columns.Add("PS2Max", typeof(bool));
			dataTable17.Columns.Add("SensorGroup", typeof(int));
			DBFunctions.PopulateSensors(activeUnit, activeUnit_0.DBID);
			sensors_Cached = activeUnit.Sensors_ReadOnly();
			Sensor[] array11 = sensors_Cached;
			foreach (Sensor sensor5 in array11)
			{
				dataTable17.Rows.Add(sensor5.DBID, sensor5.Name, sensor5.Type, sensor5.Coverage.SB1, sensor5.Coverage.SB2, sensor5.Coverage.SMF1, sensor5.Coverage.SMF2, sensor5.Coverage.SMA1, sensor5.Coverage.SMA2, sensor5.Coverage.SS1, sensor5.Coverage.SS2, sensor5.Coverage.PB1, sensor5.Coverage.PB2, sensor5.Coverage.PMF1, sensor5.Coverage.PMF2, sensor5.Coverage.PMA1, sensor5.Coverage.PMA2, sensor5.Coverage.PS1, sensor5.Coverage.PS2, sensor5.Coverage_Illuminate.SB1, sensor5.Coverage_Illuminate.SB2, sensor5.Coverage_Illuminate.SMF1, sensor5.Coverage_Illuminate.SMF2, sensor5.Coverage_Illuminate.SMA1, sensor5.Coverage_Illuminate.SMA2, sensor5.Coverage_Illuminate.SS1, sensor5.Coverage_Illuminate.SS2, sensor5.Coverage_Illuminate.PB1, sensor5.Coverage_Illuminate.PB2, sensor5.Coverage_Illuminate.PMF1, sensor5.Coverage_Illuminate.PMF2, sensor5.Coverage_Illuminate.PMA1, sensor5.Coverage_Illuminate.PMA2, sensor5.Coverage_Illuminate.PS1, sensor5.Coverage_Illuminate.PS2, sensor5.IsSensorInGroup);
			}
			if (!dataTable17.Columns.Contains("SensorIndex"))
			{
				dataTable17.Columns.Add("SensorIndex", typeof(int));
			}
			int num112 = dataTable17.Rows.Count - 1;
			for (int k = 0; k <= num112; k++)
			{
				dataTable17.Rows[k]["SensorIndex"] = k;
			}
			DataTable dataTable18 = new DataTable();
			dataTable18.Columns.Add("ID", typeof(int));
			dataTable18.Columns.Add("Name", typeof(string));
			dataTable18.Columns.Add("Type", typeof(int));
			dataTable18.Columns.Add("SB1", typeof(bool));
			dataTable18.Columns.Add("SB2", typeof(bool));
			dataTable18.Columns.Add("SMF1", typeof(bool));
			dataTable18.Columns.Add("SMF2", typeof(bool));
			dataTable18.Columns.Add("SMA1", typeof(bool));
			dataTable18.Columns.Add("SMA2", typeof(bool));
			dataTable18.Columns.Add("SS1", typeof(bool));
			dataTable18.Columns.Add("SS2", typeof(bool));
			dataTable18.Columns.Add("PB1", typeof(bool));
			dataTable18.Columns.Add("PB2", typeof(bool));
			dataTable18.Columns.Add("PMF1", typeof(bool));
			dataTable18.Columns.Add("PMF2", typeof(bool));
			dataTable18.Columns.Add("PMA1", typeof(bool));
			dataTable18.Columns.Add("PMA2", typeof(bool));
			dataTable18.Columns.Add("PS1", typeof(bool));
			dataTable18.Columns.Add("PS2", typeof(bool));
			dataTable18.Columns.Add("SB1Max", typeof(bool));
			dataTable18.Columns.Add("SB2Max", typeof(bool));
			dataTable18.Columns.Add("SMF1Max", typeof(bool));
			dataTable18.Columns.Add("SMF2Max", typeof(bool));
			dataTable18.Columns.Add("SMA1Max", typeof(bool));
			dataTable18.Columns.Add("SMA2Max", typeof(bool));
			dataTable18.Columns.Add("SS1Max", typeof(bool));
			dataTable18.Columns.Add("SS2Max", typeof(bool));
			dataTable18.Columns.Add("PB1Max", typeof(bool));
			dataTable18.Columns.Add("PB2Max", typeof(bool));
			dataTable18.Columns.Add("PMF1Max", typeof(bool));
			dataTable18.Columns.Add("PMF2Max", typeof(bool));
			dataTable18.Columns.Add("PMA1Max", typeof(bool));
			dataTable18.Columns.Add("PMA2Max", typeof(bool));
			dataTable18.Columns.Add("PS1Max", typeof(bool));
			dataTable18.Columns.Add("PS2Max", typeof(bool));
			dataTable18.Columns.Add("Has360Coverage", typeof(bool));
			dataTable18.Columns.Add("Has360CoverageMax", typeof(bool));
			Sensor[] array2 = activeUnit_0.Sensors_ReadOnly();
			IEnumerator enumerator3 = null;
			IEnumerator enumerator4 = null;
			IEnumerator enumerator5 = null;
			sensors_Cached = array2;
			Sensor[] array12 = sensors_Cached;
			foreach (Sensor sensor6 in array12)
			{
				bool flag14 = false;
				try
				{
					enumerator3 = dataTable17.Rows.GetEnumerator();
					while (enumerator3.MoveNext())
					{
						DataRow dataRow14 = (DataRow)enumerator3.Current;
						if ((Conversions.ToInteger(dataRow14["ComponentID"]) == sensor6.DBID) & (sensor6.Coverage.SB1 == Conversions.ToBoolean(dataRow14["SB1"])) & (sensor6.Coverage.SB2 == Conversions.ToBoolean(dataRow14["SB2"])) & (sensor6.Coverage.SMF1 == Conversions.ToBoolean(dataRow14["SMF1"])) & (sensor6.Coverage.SMF2 == Conversions.ToBoolean(dataRow14["SMF2"])) & (sensor6.Coverage.SMA1 == Conversions.ToBoolean(dataRow14["SMA1"])) & (sensor6.Coverage.SMA2 == Conversions.ToBoolean(dataRow14["SMA2"])) & (sensor6.Coverage.SS1 == Conversions.ToBoolean(dataRow14["SS1"])) & (sensor6.Coverage.SS2 == Conversions.ToBoolean(dataRow14["SS2"])) & (sensor6.Coverage.PB1 == Conversions.ToBoolean(dataRow14["PB1"])) & (sensor6.Coverage.PB2 == Conversions.ToBoolean(dataRow14["PB2"])) & (sensor6.Coverage.PMF1 == Conversions.ToBoolean(dataRow14["PMF1"])) & (sensor6.Coverage.PMF2 == Conversions.ToBoolean(dataRow14["PMF2"])) & (sensor6.Coverage.PMA1 == Conversions.ToBoolean(dataRow14["PMA1"])) & (sensor6.Coverage.PMA2 == Conversions.ToBoolean(dataRow14["PMA2"])) & (sensor6.Coverage.PS1 == Conversions.ToBoolean(dataRow14["PS1"])) & (sensor6.Coverage.PS2 == Conversions.ToBoolean(dataRow14["PS2"])) & (sensor6.Coverage_Illuminate.SB1 == Conversions.ToBoolean(dataRow14["SB1Max"])) & (sensor6.Coverage_Illuminate.SB2 == Conversions.ToBoolean(dataRow14["SB2Max"])) & (sensor6.Coverage_Illuminate.SMF1 == Conversions.ToBoolean(dataRow14["SMF1Max"])) & (sensor6.Coverage_Illuminate.SMF2 == Conversions.ToBoolean(dataRow14["SMF2Max"])) & (sensor6.Coverage_Illuminate.SMA1 == Conversions.ToBoolean(dataRow14["SMA1Max"])) & (sensor6.Coverage_Illuminate.SMA2 == Conversions.ToBoolean(dataRow14["SMA2Max"])) & (sensor6.Coverage_Illuminate.SS1 == Conversions.ToBoolean(dataRow14["SS1Max"])) & (sensor6.Coverage_Illuminate.SS2 == Conversions.ToBoolean(dataRow14["SS2Max"])) & (sensor6.Coverage_Illuminate.PB1 == Conversions.ToBoolean(dataRow14["PB1Max"])) & (sensor6.Coverage_Illuminate.PB2 == Conversions.ToBoolean(dataRow14["PB2Max"])) & (sensor6.Coverage_Illuminate.PMF1 == Conversions.ToBoolean(dataRow14["PMF1Max"])) & (sensor6.Coverage_Illuminate.PMF2 == Conversions.ToBoolean(dataRow14["PMF2Max"])) & (sensor6.Coverage_Illuminate.PMA1 == Conversions.ToBoolean(dataRow14["PMA1Max"])) & (sensor6.Coverage_Illuminate.PMA2 == Conversions.ToBoolean(dataRow14["PMA2Max"])) & (sensor6.Coverage_Illuminate.PS1 == Conversions.ToBoolean(dataRow14["PS1Max"])) & (sensor6.Coverage_Illuminate.PS2 == Conversions.ToBoolean(dataRow14["PS2Max"])) & !sensor6.IsSensorInMount)
						{
							dataRow14.Delete();
							flag14 = true;
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
				if (sensor6.IsSensorInMount)
				{
					flag14 = true;
				}
				if (flag14)
				{
					continue;
				}
				if (!flag14 & (activeUnit_0.UnitType == GlobalVariables.ActiveUnitType.Aircraft))
				{
					string_2 = "SELECT dws.ComponentID from DataWeaponSensors dws where dws.ID in (Select dw.ComponentID from DataWeaponRecord dw where dw.ID in (Select dlw.ComponentID from DataLoadoutWeapons dlw where dlw.ID in (Select dal.ComponentID from DataAircraftLoadouts dal where dal.ID = " + Conversions.ToString(activeUnit_0.DBID) + ")))";
					DataTable dataTable19 = sQLiteHelper.ComputeSpecification(string_2);
					try
					{
						enumerator4 = dataTable19.Rows.GetEnumerator();
						while (enumerator4.MoveNext())
						{
							int num113 = Conversions.ToInteger(((DataRow)enumerator4.Current)["ComponentID"]);
							if (sensor6.DBID == num113)
							{
								flag14 = true;
								break;
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
				}
				if (!flag14 && dataTable32.Rows.Count > 0)
				{
					int num114 = dataTable32.Rows.Count - 1;
					for (int l = 0; l <= num114; l++)
					{
						int num115 = Conversions.ToInteger(dataTable32.Rows[l]["ID"].ToString());
						string_2 = "SELECT ComponentID from DataMountSensors where  ID = " + Conversions.ToString(num115);
						DataTable dataTable20 = sQLiteHelper.ComputeSpecification(string_2);
						try
						{
							enumerator5 = dataTable20.Rows.GetEnumerator();
							while (enumerator5.MoveNext())
							{
								int num116 = Conversions.ToInteger(((DataRow)enumerator5.Current)["ComponentID"]);
								if (sensor6.DBID == num116 && sensor6.IsSensorInMount)
								{
									flag14 = true;
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
					}
				}
				if (!flag14 & !sensor6.m_IsMk1Eyeball)
				{
					dataTable18.Rows.Add(sensor6.DBID, sensor6.Name, sensor6.Type, sensor6.Coverage.SB1, sensor6.Coverage.SB2, sensor6.Coverage.SMF1, sensor6.Coverage.SMF2, sensor6.Coverage.SMA1, sensor6.Coverage.SMA2, sensor6.Coverage.SS1, sensor6.Coverage.SS2, sensor6.Coverage.PB1, sensor6.Coverage.PB2, sensor6.Coverage.PMF1, sensor6.Coverage.PMF2, sensor6.Coverage.PMA1, sensor6.Coverage.PMA2, sensor6.Coverage.PS1, sensor6.Coverage.PS2, sensor6.Coverage_Illuminate.SB1, sensor6.Coverage_Illuminate.SB2, sensor6.Coverage_Illuminate.SMF1, sensor6.Coverage_Illuminate.SMF2, sensor6.Coverage_Illuminate.SMA1, sensor6.Coverage_Illuminate.SMA2, sensor6.Coverage_Illuminate.SS1, sensor6.Coverage_Illuminate.SS2, sensor6.Coverage_Illuminate.PB1, sensor6.Coverage_Illuminate.PB2, sensor6.Coverage_Illuminate.PMF1, sensor6.Coverage_Illuminate.PMF2, sensor6.Coverage_Illuminate.PMA1, sensor6.Coverage_Illuminate.PMA2, sensor6.Coverage_Illuminate.PS1, sensor6.Coverage_Illuminate.PS2, sensor6.Coverage.Has360Coverage(), sensor6.Coverage_Illuminate.Has360Coverage());
				}
			}
			if (text23.Length > 0)
			{
				dataTable = new DataTable();
				dataTable.Columns.Add("ComponentID", typeof(int));
				dataTable.Columns.Add("Name", typeof(string));
				dataTable.Columns.Add("Type", typeof(int));
				dataTable.Columns.Add("SB1", typeof(bool));
				dataTable.Columns.Add("SB2", typeof(bool));
				dataTable.Columns.Add("SMF1", typeof(bool));
				dataTable.Columns.Add("SMF2", typeof(bool));
				dataTable.Columns.Add("SMA1", typeof(bool));
				dataTable.Columns.Add("SMA2", typeof(bool));
				dataTable.Columns.Add("SS1", typeof(bool));
				dataTable.Columns.Add("SS2", typeof(bool));
				dataTable.Columns.Add("PB1", typeof(bool));
				dataTable.Columns.Add("PB2", typeof(bool));
				dataTable.Columns.Add("PMF1", typeof(bool));
				dataTable.Columns.Add("PMF2", typeof(bool));
				dataTable.Columns.Add("PMA1", typeof(bool));
				dataTable.Columns.Add("PMA2", typeof(bool));
				dataTable.Columns.Add("PS1", typeof(bool));
				dataTable.Columns.Add("PS2", typeof(bool));
				dataTable.Columns.Add("SB1Max", typeof(bool));
				dataTable.Columns.Add("SB2Max", typeof(bool));
				dataTable.Columns.Add("SMF1Max", typeof(bool));
				dataTable.Columns.Add("SMF2Max", typeof(bool));
				dataTable.Columns.Add("SMA1Max", typeof(bool));
				dataTable.Columns.Add("SMA2Max", typeof(bool));
				dataTable.Columns.Add("SS1Max", typeof(bool));
				dataTable.Columns.Add("SS2Max", typeof(bool));
				dataTable.Columns.Add("PB1Max", typeof(bool));
				dataTable.Columns.Add("PB2Max", typeof(bool));
				dataTable.Columns.Add("PMF1Max", typeof(bool));
				dataTable.Columns.Add("PMF2Max", typeof(bool));
				dataTable.Columns.Add("PMA1Max", typeof(bool));
				dataTable.Columns.Add("PMA2Max", typeof(bool));
				dataTable.Columns.Add("PS1Max", typeof(bool));
				dataTable.Columns.Add("PS2Max", typeof(bool));
				dataTable.Columns.Add("SensorGroup", typeof(int));
				foreach (Sensor mineCountermeasure in activeUnit.MineCountermeasures)
				{
					dataTable.Rows.Add(mineCountermeasure.DBID, mineCountermeasure.Name, mineCountermeasure.Type, mineCountermeasure.Coverage.SB1, mineCountermeasure.Coverage.SB2, mineCountermeasure.Coverage.SMF1, mineCountermeasure.Coverage.SMF2, mineCountermeasure.Coverage.SMA1, mineCountermeasure.Coverage.SMA2, mineCountermeasure.Coverage.SS1, mineCountermeasure.Coverage.SS2, mineCountermeasure.Coverage.PB1, mineCountermeasure.Coverage.PB2, mineCountermeasure.Coverage.PMF1, mineCountermeasure.Coverage.PMF2, mineCountermeasure.Coverage.PMA1, mineCountermeasure.Coverage.PMA2, mineCountermeasure.Coverage.PS1, mineCountermeasure.Coverage.PS2, mineCountermeasure.Coverage_Illuminate.SB1, mineCountermeasure.Coverage_Illuminate.SB2, mineCountermeasure.Coverage_Illuminate.SMF1, mineCountermeasure.Coverage_Illuminate.SMF2, mineCountermeasure.Coverage_Illuminate.SMA1, mineCountermeasure.Coverage_Illuminate.SMA2, mineCountermeasure.Coverage_Illuminate.SS1, mineCountermeasure.Coverage_Illuminate.SS2, mineCountermeasure.Coverage_Illuminate.PB1, mineCountermeasure.Coverage_Illuminate.PB2, mineCountermeasure.Coverage_Illuminate.PMF1, mineCountermeasure.Coverage_Illuminate.PMF2, mineCountermeasure.Coverage_Illuminate.PMA1, mineCountermeasure.Coverage_Illuminate.PMA2, mineCountermeasure.Coverage_Illuminate.PS1, mineCountermeasure.Coverage_Illuminate.PS2, mineCountermeasure.IsSensorInGroup);
				}
				if (!dataTable.Columns.Contains("SensorIndex"))
				{
					dataTable.Columns.Add("SensorIndex", typeof(int));
				}
				int num117 = dataTable.Rows.Count - 1;
				for (int m = 0; m <= num117; m++)
				{
					dataTable.Rows[m]["SensorIndex"] = m;
				}
				IEnumerator enumerator6 = null;
				IEnumerator enumerator7 = null;
				IEnumerator enumerator8 = null;
				foreach (Sensor mineCountermeasure2 in activeUnit_0.MineCountermeasures)
				{
					bool flag2 = false;
					try
					{
						enumerator6 = dataTable.Rows.GetEnumerator();
						while (enumerator6.MoveNext())
						{
							DataRow dataRow15 = (DataRow)enumerator6.Current;
							if ((Conversions.ToInteger(dataRow15["ComponentID"]) == mineCountermeasure2.DBID) & (mineCountermeasure2.Coverage.SB1 == Conversions.ToBoolean(dataRow15["SB1"])) & (mineCountermeasure2.Coverage.SB2 == Conversions.ToBoolean(dataRow15["SB2"])) & (mineCountermeasure2.Coverage.SMF1 == Conversions.ToBoolean(dataRow15["SMF1"])) & (mineCountermeasure2.Coverage.SMF2 == Conversions.ToBoolean(dataRow15["SMF2"])) & (mineCountermeasure2.Coverage.SMA1 == Conversions.ToBoolean(dataRow15["SMA1"])) & (mineCountermeasure2.Coverage.SMA2 == Conversions.ToBoolean(dataRow15["SMA2"])) & (mineCountermeasure2.Coverage.SS1 == Conversions.ToBoolean(dataRow15["SS1"])) & (mineCountermeasure2.Coverage.SS2 == Conversions.ToBoolean(dataRow15["SS2"])) & (mineCountermeasure2.Coverage.PB1 == Conversions.ToBoolean(dataRow15["PB1"])) & (mineCountermeasure2.Coverage.PB2 == Conversions.ToBoolean(dataRow15["PB2"])) & (mineCountermeasure2.Coverage.PMF1 == Conversions.ToBoolean(dataRow15["PMF1"])) & (mineCountermeasure2.Coverage.PMF2 == Conversions.ToBoolean(dataRow15["PMF2"])) & (mineCountermeasure2.Coverage.PMA1 == Conversions.ToBoolean(dataRow15["PMA1"])) & (mineCountermeasure2.Coverage.PMA2 == Conversions.ToBoolean(dataRow15["PMA2"])) & (mineCountermeasure2.Coverage.PS1 == Conversions.ToBoolean(dataRow15["PS1"])) & (mineCountermeasure2.Coverage.PS2 == Conversions.ToBoolean(dataRow15["PS2"])) & (mineCountermeasure2.Coverage_Illuminate.SB1 == Conversions.ToBoolean(dataRow15["SB1Max"])) & (mineCountermeasure2.Coverage_Illuminate.SB2 == Conversions.ToBoolean(dataRow15["SB2Max"])) & (mineCountermeasure2.Coverage_Illuminate.SMF1 == Conversions.ToBoolean(dataRow15["SMF1Max"])) & (mineCountermeasure2.Coverage_Illuminate.SMF2 == Conversions.ToBoolean(dataRow15["SMF2Max"])) & (mineCountermeasure2.Coverage_Illuminate.SMA1 == Conversions.ToBoolean(dataRow15["SMA1Max"])) & (mineCountermeasure2.Coverage_Illuminate.SMA2 == Conversions.ToBoolean(dataRow15["SMA2Max"])) & (mineCountermeasure2.Coverage_Illuminate.SS1 == Conversions.ToBoolean(dataRow15["SS1Max"])) & (mineCountermeasure2.Coverage_Illuminate.SS2 == Conversions.ToBoolean(dataRow15["SS2Max"])) & (mineCountermeasure2.Coverage_Illuminate.PB1 == Conversions.ToBoolean(dataRow15["PB1Max"])) & (mineCountermeasure2.Coverage_Illuminate.PB2 == Conversions.ToBoolean(dataRow15["PB2Max"])) & (mineCountermeasure2.Coverage_Illuminate.PMF1 == Conversions.ToBoolean(dataRow15["PMF1Max"])) & (mineCountermeasure2.Coverage_Illuminate.PMF2 == Conversions.ToBoolean(dataRow15["PMF2Max"])) & (mineCountermeasure2.Coverage_Illuminate.PMA1 == Conversions.ToBoolean(dataRow15["PMA1Max"])) & (mineCountermeasure2.Coverage_Illuminate.PMA2 == Conversions.ToBoolean(dataRow15["PMA2Max"])) & (mineCountermeasure2.Coverage_Illuminate.PS1 == Conversions.ToBoolean(dataRow15["PS1Max"])) & (mineCountermeasure2.Coverage_Illuminate.PS2 == Conversions.ToBoolean(dataRow15["PS2Max"])))
							{
								dataRow15.Delete();
								flag2 = true;
								break;
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
					if (mineCountermeasure2.IsSensorInMount)
					{
						flag2 = true;
					}
					if (flag2)
					{
						continue;
					}
					if (!flag2 & (activeUnit_0.UnitType == GlobalVariables.ActiveUnitType.Aircraft))
					{
						string_2 = "SELECT dws.ComponentID from DataWeaponSensors dws where dws.ID in (Select dw.ComponentID from DataWeaponRecord dw where dw.ID in (Select dlw.ComponentID from DataLoadoutWeapons dlw where dlw.ID in (Select dal.ComponentID from DataAircraftLoadouts dal where dal.ID = " + Conversions.ToString(activeUnit_0.DBID) + ")))";
						DataTable dataTable21 = sQLiteHelper.ComputeSpecification(string_2);
						try
						{
							enumerator7 = dataTable21.Rows.GetEnumerator();
							while (enumerator7.MoveNext())
							{
								int num118 = Conversions.ToInteger(((DataRow)enumerator7.Current)["ComponentID"]);
								if (mineCountermeasure2.DBID == num118)
								{
									flag2 = true;
									break;
								}
							}
						}
						finally
						{
							if (enumerator7 is IDisposable)
							{
								(enumerator7 as IDisposable).Dispose();
							}
						}
					}
					if (!flag2 && dataTable32.Rows.Count > 0)
					{
						int num119 = dataTable32.Rows.Count - 1;
						for (int num120 = 0; num120 <= num119; num120++)
						{
							int num122 = Conversions.ToInteger(dataTable32.Rows[num120]["ID"].ToString());
							string_2 = "SELECT ComponentID from DataMountSensors where  ID = " + Conversions.ToString(num122);
							DataTable dataTable22 = sQLiteHelper.ComputeSpecification(string_2);
							try
							{
								enumerator8 = dataTable22.Rows.GetEnumerator();
								while (enumerator8.MoveNext())
								{
									int num123 = Conversions.ToInteger(((DataRow)enumerator8.Current)["ComponentID"]);
									if (mineCountermeasure2.DBID == num123)
									{
										flag2 = true;
										break;
									}
								}
							}
							finally
							{
								if (enumerator8 is IDisposable)
								{
									(enumerator8 as IDisposable).Dispose();
								}
							}
						}
					}
					if (!flag2)
					{
						dataTable18.Rows.Add(mineCountermeasure2.DBID, mineCountermeasure2.Name, mineCountermeasure2.Type, mineCountermeasure2.Coverage.SB1, mineCountermeasure2.Coverage.SB2, mineCountermeasure2.Coverage.SMF1, mineCountermeasure2.Coverage.SMF2, mineCountermeasure2.Coverage.SMA1, mineCountermeasure2.Coverage.SMA2, mineCountermeasure2.Coverage.SS1, mineCountermeasure2.Coverage.SS2, mineCountermeasure2.Coverage.PB1, mineCountermeasure2.Coverage.PB2, mineCountermeasure2.Coverage.PMF1, mineCountermeasure2.Coverage.PMF2, mineCountermeasure2.Coverage.PMA1, mineCountermeasure2.Coverage.PMA2, mineCountermeasure2.Coverage.PS1, mineCountermeasure2.Coverage.PS2, mineCountermeasure2.Coverage_Illuminate.SB1, mineCountermeasure2.Coverage_Illuminate.SB2, mineCountermeasure2.Coverage_Illuminate.SMF1, mineCountermeasure2.Coverage_Illuminate.SMF2, mineCountermeasure2.Coverage_Illuminate.SMA1, mineCountermeasure2.Coverage_Illuminate.SMA2, mineCountermeasure2.Coverage_Illuminate.SS1, mineCountermeasure2.Coverage_Illuminate.SS2, mineCountermeasure2.Coverage_Illuminate.PB1, mineCountermeasure2.Coverage_Illuminate.PB2, mineCountermeasure2.Coverage_Illuminate.PMF1, mineCountermeasure2.Coverage_Illuminate.PMF2, mineCountermeasure2.Coverage_Illuminate.PMA1, mineCountermeasure2.Coverage_Illuminate.PMA2, mineCountermeasure2.Coverage_Illuminate.PS1, mineCountermeasure2.Coverage_Illuminate.PS2, mineCountermeasure2.Coverage.Has360Coverage(), mineCountermeasure2.Coverage_Illuminate.Has360Coverage());
					}
				}
			}
			DataTable dataTable24 = sQLiteHelper.ComputeSpecification(string_3);
			if (!dataTable24.Columns.Contains("CommIndex"))
			{
				dataTable24.Columns.Add("CommIndex", typeof(int));
			}
			int num124 = dataTable24.Rows.Count - 1;
			for (int num125 = 0; num125 <= num124; num125++)
			{
				dataTable24.Rows[num125]["CommIndex"] = num125;
			}
			DataTable dataTable25 = new DataTable();
			dataTable25.Columns.Add("ID", typeof(int));
			dataTable25.Columns.Add("Name", typeof(string));
			CommDevice[] comms_ReadOnly = activeUnit_0.Comms_ReadOnly;
			IEnumerator enumerator9 = null;
			IEnumerator enumerator10 = null;
			CommDevice[] array3 = comms_ReadOnly;
			CommDevice[] array13 = array3;
			foreach (CommDevice commDevice in array13)
			{
				bool flag3 = false;
				try
				{
					enumerator9 = dataTable24.Rows.GetEnumerator();
					while (enumerator9.MoveNext())
					{
						DataRow dataRow16 = (DataRow)enumerator9.Current;
						if (Conversions.ToInteger(dataRow16["ComponentID"]) == commDevice.DBID && !commDevice.IsCommsInMount)
						{
							dataRow16.Delete();
							flag3 = true;
							break;
						}
					}
				}
				finally
				{
					if (enumerator9 is IDisposable)
					{
						(enumerator9 as IDisposable).Dispose();
					}
				}
				if (commDevice.IsCommsInMount)
				{
					flag3 = true;
				}
				if (!flag3)
				{
					switch (activeUnit_0.UnitType)
					{
					case GlobalVariables.ActiveUnitType.Aircraft:
						string_2 = "SELECT ComponentID from DataMountComms where  ID in (Select ComponentID from DataAircraftMounts where ID = " + Conversions.ToString(activeUnit_0.DBID) + ")";
						break;
					case GlobalVariables.ActiveUnitType.Ship:
						string_2 = "SELECT ComponentID from DataMountComms where  ID in (Select ComponentID from DataShipMounts where ID = " + Conversions.ToString(activeUnit_0.DBID) + ")";
						break;
					case GlobalVariables.ActiveUnitType.Submarine:
						string_2 = "SELECT ComponentID from DataMountComms where  ID in (Select ComponentID from DataSubmarineMounts where ID = " + Conversions.ToString(activeUnit_0.DBID) + ")";
						break;
					case GlobalVariables.ActiveUnitType.Facility:
						string_2 = "SELECT ComponentID from DataMountComms where  ID in (Select ComponentID from DataFacilityMounts where ID = " + Conversions.ToString(activeUnit_0.DBID) + ")";
						break;
					case GlobalVariables.ActiveUnitType.Satellite:
						string_2 = "SELECT ComponentID from DataMountComms where  ID in (Select ComponentID from DataSatelliteMounts where ID = " + Conversions.ToString(activeUnit_0.DBID) + ")";
						break;
					case GlobalVariables.ActiveUnitType.Vehicle:
						string_2 = "SELECT ComponentID from DataMountComms where  ID in (Select ComponentID from DataGroundUnitSensors where ID = " + Conversions.ToString(activeUnit_0.DBID) + ")";
						break;
					}
					DataTable dataTable26 = sQLiteHelper.ComputeSpecification(string_2);
					try
					{
						enumerator10 = dataTable26.Rows.GetEnumerator();
						while (enumerator10.MoveNext())
						{
							int num126 = Conversions.ToInteger(((DataRow)enumerator10.Current)["ComponentID"]);
							if (commDevice.DBID == num126 && commDevice.IsCommsInMount)
							{
								flag3 = true;
								break;
							}
						}
					}
					finally
					{
						if (enumerator10 is IDisposable)
						{
							(enumerator10 as IDisposable).Dispose();
						}
					}
				}
				if (!flag3)
				{
					dataTable25.Rows.Add(commDevice.DBID, commDevice.Name);
				}
			}
			DataTable dataTable27 = new DataTable();
			dataTable27.Columns.Add("ID", typeof(int));
			dataTable27.Columns.Add("Name", typeof(string));
			DataTable dataTable28 = new DataTable();
			dataTable28.Columns.Add("ID", typeof(int));
			dataTable28.Columns.Add("Name", typeof(string));
			DataTable dataTable29 = new DataTable();
			DataTable dataTable30 = new DataTable();
			if (text12.Length > 0)
			{
				dataTable29 = sQLiteHelper.ComputeSpecification(text12);
			}
			if (!dataTable29.Columns.Contains("FacilityIndex"))
			{
				dataTable29.Columns.Add("FacilityIndex", typeof(int));
			}
			int num127 = dataTable29.Rows.Count - 1;
			for (int num128 = 0; num128 <= num127; num128++)
			{
				dataTable29.Rows[num128]["FacilityIndex"] = num128;
			}
			DockFacility[] array4;
			if (activeUnit_0.DockFacilities_ReadOnly.Length != 0)
			{
				DockFacility[] dockFacilities_ReadOnly = activeUnit_0.DockFacilities_ReadOnly;
				IEnumerator enumerator12 = null;
				array4 = dockFacilities_ReadOnly;
				DockFacility[] array14 = array4;
				foreach (DockFacility dockFacility in array14)
				{
					bool flag4 = false;
					try
					{
						enumerator12 = dataTable29.Rows.GetEnumerator();
						while (enumerator12.MoveNext())
						{
							DataRow dataRow17 = (DataRow)enumerator12.Current;
							if (Conversions.ToInteger(dataRow17["ComponentID"].ToString()) == dockFacility.DBID)
							{
								dataRow17.Delete();
								flag4 = true;
								break;
							}
						}
					}
					finally
					{
						if (enumerator12 is IDisposable)
						{
							(enumerator12 as IDisposable).Dispose();
						}
					}
					if (!flag4)
					{
						dataTable27.Rows.Add(dockFacility.DBID, dockFacility.Name);
					}
				}
			}
			if (dataTable29.Rows.Count > 0)
			{
				if (!dataTable29.Columns.Contains("Name"))
				{
					dataTable29.Columns.Add("Name", typeof(string));
				}
				int num129 = dataTable29.Rows.Count - 1;
				for (int num130 = 0; num130 <= num129; num130++)
				{
					int int_ = Conversions.ToInteger(dataTable29.Rows[num130]["ComponentID"].ToString());
					SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
					DockFacility dockFacility2 = DBFunctions.GetDockFacility(int_, ref sqliteConnection_);
					dataTable29.Rows[num130]["Name"] = dockFacility2.Name;
				}
			}
			if (text.Length > 0)
			{
				dataTable30 = sQLiteHelper.ComputeSpecification(text);
			}
			if (!dataTable30.Columns.Contains("FacilityIndex"))
			{
				dataTable30.Columns.Add("FacilityIndex", typeof(int));
			}
			int num131 = dataTable30.Rows.Count - 1;
			for (int num133 = 0; num133 <= num131; num133++)
			{
				dataTable30.Rows[num133]["FacilityIndex"] = num133;
			}
			AirFacility[] array5;
			if (activeUnit_0.AirFacilities_ReadOnly.Length != 0)
			{
				AirFacility[] airFacilities_ReadOnly = activeUnit_0.AirFacilities_ReadOnly;
				IEnumerator enumerator13 = null;
				array5 = airFacilities_ReadOnly;
				AirFacility[] array15 = array5;
				foreach (AirFacility airFacility in array15)
				{
					bool flag5 = false;
					try
					{
						enumerator13 = dataTable30.Rows.GetEnumerator();
						while (enumerator13.MoveNext())
						{
							DataRow dataRow18 = (DataRow)enumerator13.Current;
							if (Conversions.ToInteger(dataRow18["ComponentID"].ToString()) == airFacility.DBID)
							{
								dataRow18.Delete();
								flag5 = true;
								break;
							}
						}
					}
					finally
					{
						if (enumerator13 is IDisposable)
						{
							(enumerator13 as IDisposable).Dispose();
						}
					}
					if (!flag5)
					{
						dataTable28.Rows.Add(airFacility.DBID, airFacility.Name);
					}
				}
			}
			if (dataTable30.Rows.Count > 0)
			{
				if (!dataTable30.Columns.Contains("Name"))
				{
					dataTable30.Columns.Add("Name", typeof(string));
				}
				int num134 = dataTable30.Rows.Count - 1;
				for (int num135 = 0; num135 <= num134; num135++)
				{
					int int_2 = Conversions.ToInteger(dataTable30.Rows[num135]["ComponentID"].ToString());
					SQLiteConnection sqliteConnection_2 = scenario_0.DBConnection;
					AirFacility airFacility2 = DBFunctions.GetAirFacility(int_2, ref sqliteConnection_2);
					dataTable30.Rows[num135]["Name"] = airFacility2.Name;
				}
			}
			DataTable dataTable31 = new DataTable();
			dataTable31.Columns.Add("ID", typeof(string));
			dataTable31.Columns.Add("Type", typeof(string));
			dataTable31.Columns.Add("Status", typeof(int));
			dataTable31.Columns.Add("DamageSeverity", typeof(int));
			dataTable31.Columns.Add("Name", typeof(string));
			if (activeUnit_0.GetDamagePts() != (float)activeUnit_0.InitialDP)
			{
				dataTable31.Rows.Add("", "DamagePts", activeUnit_0.GetDamagePts());
			}
			if ((int)activeUnit_0.Damage.FireIntensity > 0)
			{
				dataTable31.Rows.Add("", "Fire", (byte)activeUnit_0.Damage.FireIntensity);
			}
			if ((int)activeUnit_0.Damage.FloodIntensity > 0)
			{
				dataTable31.Rows.Add("", "Flood", (byte)activeUnit_0.Damage.FloodIntensity);
			}
			switch (activeUnit_0.UnitType)
			{
			case GlobalVariables.ActiveUnitType.Ship:
			{
				Ship ship = (Ship)activeUnit_0;
				if (ship.CIC.Status != 0 || ship.CIC.DamageSeverity != 0)
				{
					dataTable31.Rows.Add("", "CIC", (byte)ship.CIC.Status, (byte)ship.CIC.DamageSeverity);
				}
				if (ship.Rudder.Status != 0 || ship.Rudder.DamageSeverity != 0)
				{
					dataTable31.Rows.Add("", "Rudder", (byte)ship.Rudder.Status, (byte)ship.Rudder.DamageSeverity);
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.Submarine:
			{
				Submarine submarine = (Submarine)activeUnit_0;
				if (submarine.CIC.Status != 0 || submarine.CIC.DamageSeverity != 0)
				{
					dataTable31.Rows.Add("", "CIC", (byte)submarine.CIC.Status, (byte)submarine.CIC.DamageSeverity);
				}
				if (submarine.Rudder.Status != 0 || submarine.Rudder.DamageSeverity != 0)
				{
					dataTable31.Rows.Add("", "Rudder", (byte)submarine.Rudder.Status, (byte)submarine.Rudder.DamageSeverity);
				}
				if (submarine.PressureHull.Status != 0 || submarine.PressureHull.DamageSeverity != 0)
				{
					dataTable31.Rows.Add("", "PressureHull", (byte)submarine.PressureHull.Status, (byte)submarine.PressureHull.DamageSeverity);
				}
				if (submarine.Cargo.Status != 0 || submarine.Cargo.DamageSeverity != 0)
				{
					dataTable31.Rows.Add("", "Cargo", (byte)submarine.Cargo.Status, (byte)submarine.Cargo.DamageSeverity);
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.Facility:
			{
				Facility facility = (Facility)activeUnit_0;
				if (facility.CIC.Status != 0 || facility.CIC.DamageSeverity != 0)
				{
					dataTable31.Rows.Add("", "CIC", (byte)facility.CIC.Status, (byte)facility.CIC.DamageSeverity);
				}
				if (facility.Cargo.Status != 0 || facility.Cargo.DamageSeverity != 0)
				{
					dataTable31.Rows.Add("", "Cargo", (byte)facility.Cargo.Status, (byte)facility.Cargo.DamageSeverity);
				}
				break;
			}
			}
			sensors_Cached = activeUnit_0.Sensors_ReadOnly();
			Sensor[] array16 = sensors_Cached;
			foreach (Sensor sensor7 in array16)
			{
				if (sensor7.Status != 0 || sensor7.DamageSeverity != 0)
				{
					dataTable31.Rows.Add(sensor7.ObjectID, "Sensor", (byte)sensor7.Status, (byte)sensor7.DamageSeverity, sensor7.Name);
				}
			}
			array3 = activeUnit_0.Comms_ReadOnly;
			CommDevice[] array17 = array3;
			foreach (CommDevice commDevice2 in array17)
			{
				if (commDevice2.Status != 0 || commDevice2.DamageSeverity != 0)
				{
					dataTable31.Rows.Add(commDevice2.ObjectID, "Comm", (byte)commDevice2.Status, (byte)commDevice2.DamageSeverity, commDevice2.Name);
				}
			}
			foreach (Engine item in activeUnit_0.Propulsion)
			{
				if (item.Status != 0 || item.DamageSeverity != 0)
				{
					dataTable31.Rows.Add(item.ObjectID, "Engine", (byte)item.Status, (byte)item.DamageSeverity, item.Name);
				}
			}
			foreach (Mount mount2 in activeUnit_0.Mounts)
			{
				if (mount2.Status != 0 || mount2.DamageSeverity != 0)
				{
					dataTable31.Rows.Add(mount2.ObjectID, "Mount", (byte)mount2.Status, (byte)mount2.DamageSeverity, mount2.Name);
				}
			}
			array = activeUnit_0.SharedMagazines;
			Magazine[] array18 = array;
			foreach (Magazine magazine2 in array18)
			{
				if (magazine2.Status != 0 || magazine2.DamageSeverity != 0)
				{
					dataTable31.Rows.Add(magazine2.ObjectID, "Mag", (byte)magazine2.Status, (byte)magazine2.DamageSeverity, magazine2.Name);
				}
			}
			Cargo[] onboardCargo = activeUnit_0.OnboardCargo;
			Cargo[] array19 = onboardCargo;
			foreach (Cargo cargo in array19)
			{
				if (cargo.Status != 0 || cargo.DamageSeverity != 0)
				{
					dataTable31.Rows.Add(cargo.ObjectID, "Cargo", (byte)cargo.Status, (byte)cargo.DamageSeverity, cargo.Name);
				}
			}
			array5 = activeUnit_0.AirFacilities_ReadOnly;
			AirFacility[] array20 = array5;
			foreach (AirFacility airFacility3 in array20)
			{
				if (airFacility3.Status != 0 || airFacility3.DamageSeverity != 0)
				{
					dataTable31.Rows.Add(airFacility3.ObjectID, "AirFacility", (byte)airFacility3.Status, (byte)airFacility3.DamageSeverity, airFacility3.Name);
				}
			}
			array4 = activeUnit_0.DockFacilities_ReadOnly;
			DockFacility[] array21 = array4;
			foreach (DockFacility dockFacility3 in array21)
			{
				if (dockFacility3.Status != 0 || dockFacility3.DamageSeverity != 0)
				{
					dataTable31.Rows.Add(dockFacility3.ObjectID, "DockFacility", (byte)dockFacility3.Status, (byte)dockFacility3.DamageSeverity, dockFacility3.Name);
				}
			}
			bool flag6 = false;
			if (num95 <= 0 && !flag && dataTable12.Rows.Count <= 0 && dataTable31.Rows.Count <= 0)
			{
				if (dataTable23.Rows.Count <= 0 && dataTable32.Rows.Count <= 0 && (Information.IsNothing(dataTable13) || dataTable13.Rows.Count <= 0) && (Information.IsNothing(dataTable14) || dataTable14.Rows.Count <= 0))
				{
					if (dataTable.Rows.Count <= 0 && dataTable17.Rows.Count <= 0 && dataTable18.Rows.Count <= 0 && dataTable24.Rows.Count <= 0 && dataTable25.Rows.Count <= 0)
					{
						if (dataTable36.Rows.Count <= 0 && dataTable35.Rows.Count <= 0 && dataTable34.Rows.Count <= 0 && dataTable3.Rows.Count <= 0 && dataTable2.Rows.Count <= 0 && dataTable37.Rows.Count <= 0 && dataTable8.Rows.Count <= 0 && dataTable7.Rows.Count <= 0 && dataTable6.Rows.Count <= 0)
						{
							if (dataTable29.Rows.Count <= 0 && dataTable27.Rows.Count <= 0 && dataTable30.Rows.Count <= 0 && dataTable28.Rows.Count <= 0)
							{
								if (dataTable4.Rows.Count > 0)
								{
									flag6 = true;
								}
							}
							else
							{
								flag6 = true;
							}
						}
						else
						{
							flag6 = true;
						}
					}
					else
					{
						flag6 = true;
					}
				}
				else
				{
					flag6 = true;
				}
			}
			else
			{
				flag6 = true;
			}
			if (!flag6)
			{
				return;
			}
			xmlWriter_0.WriteStartElement("Unit_" + activeUnit_0.ObjectID);
			xmlWriter_0.WriteComment(activeUnit_0.Name + " (" + activeUnit_0.UnitClass + " [" + Conversions.ToString(activeUnit_0.DBID) + "])");
			onboardCargo = activeUnit_0.OnboardCargo;
			Cargo[] array22 = onboardCargo;
			foreach (Cargo cargo2 in array22)
			{
				xmlWriter_0.WriteStartElement("CargoAdd");
				xmlWriter_0.WriteRaw(cargo2.ToXML(null, activeUnit_0.ParentScen));
				xmlWriter_0.WriteEndElement();
			}
			if (flag)
			{
				if (activeUnit_0.IsAircraft)
				{
					float num136 = ((Aircraft)activeUnit_0).FuelCapacityCurrent;
					xmlWriter_0.WriteStartElement("SetFuel_" + Conversions.ToString(num136));
					xmlWriter_0.WriteEndElement();
				}
				else if (!activeUnit_0.IsFacility && (activeUnit_0.IsShip || activeUnit_0.IsSubmarine))
				{
					foreach (FuelRec item2 in activeUnit_0.Fuel_ReadOnly)
					{
						if (item2.CurrentQuantity < (float)item2.MaxQuantity)
						{
							xmlWriter_0.WriteStartElement("SetFuel_" + Conversions.ToString((int)item2.FuelType) + "_" + item2.CurrentQuantity.ToString("F3"));
							xmlWriter_0.WriteEndElement();
						}
					}
				}
			}
			if (dataTable32.Rows.Count > 0)
			{
				int num137 = dataTable32.Rows.Count - 1;
				for (int num138 = 0; num138 <= num137; num138++)
				{
					DataRow dataRow19 = dataTable32.Rows[num138];
					int num139 = Conversions.ToInteger(dataRow19["ID"].ToString());
					string text25 = Conversions.ToString(dataRow19["Name"]);
					xmlWriter_0.WriteStartElement("MountAdd_" + Conversions.ToString(num139));
					xmlWriter_0.WriteComment(text25);
					string text26 = PopWriter(xmlWriter_0, bool_0: false, dataRow19, activeUnit_0, text25);
					if (Operators.CompareString(text26, "", TextCompare: false) != 0)
					{
						streamWriter_0 = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR INI template log file.txt");
						streamWriter_0.Write("\r\n      " + text26);
						streamWriter_0.Close();
						int_0++;
					}
				}
			}
			if (dataTable33.Rows.Count > 0)
			{
				int num140 = dataTable33.Rows.Count - 1;
				for (int num141 = 0; num141 <= num140; num141++)
				{
					DataRow dataRow20 = dataTable33.Rows[num141];
					int num142 = Conversions.ToInteger(dataRow20["MountID"].ToString());
					num99 = Conversions.ToInteger(dataRow20["MountIndex"].ToString());
					string text27 = Conversions.ToString(dataRow20["MountName"]);
					xmlWriter_0.WriteStartElement("Mount_" + Conversions.ToString(num99 + 1) + "_" + Conversions.ToString(num142));
					xmlWriter_0.WriteComment(text27);
					if (dataTable36.Rows.Count > 0)
					{
						int num144 = dataTable36.Rows.Count - 1;
						for (int num145 = 0; num145 <= num144; num145++)
						{
							DataRow dataRow21 = dataTable36.Rows[num145];
							int num146 = Conversions.ToInteger(dataRow21["MountID"].ToString());
							int num147 = Conversions.ToInteger(dataRow21["MountIndex"].ToString());
							int num148 = Conversions.ToInteger(dataRow21["WeaponID"].ToString());
							string text28 = Conversions.ToString(dataRow21["WeaponName"]);
							if (num146 == num142 && num147 == num99)
							{
								xmlWriter_0.WriteStartElement("WeaponRemove_" + Conversions.ToString(num148));
								xmlWriter_0.WriteEndElement();
								xmlWriter_0.WriteComment(text28);
							}
						}
					}
					if (dataTable35.Rows.Count > 0)
					{
						int num149 = dataTable35.Rows.Count - 1;
						for (int num150 = 0; num150 <= num149; num150++)
						{
							DataRow dataRow22 = dataTable35.Rows[num150];
							int num151 = Conversions.ToInteger(dataRow22["MountID"].ToString());
							int num152 = Conversions.ToInteger(dataRow22["MountIndex"].ToString());
							int num153 = Conversions.ToInteger(dataRow22["WeapRecID"].ToString());
							string text29 = Conversions.ToString(dataRow22["WeaponName"]);
							int num155 = Conversions.ToInteger(dataRow22["WeaponID"].ToString());
							if (num151 == num142 && num152 == num99)
							{
								xmlWriter_0.WriteStartElement("WeaponRecAdd_" + Conversions.ToString(num153) + "_" + Conversions.ToString(num155));
								xmlWriter_0.WriteEndElement();
								xmlWriter_0.WriteComment(text29);
							}
						}
					}
					if (dataTable34.Rows.Count > 0)
					{
						int num156 = dataTable34.Rows.Count - 1;
						for (int num157 = 0; num157 <= num156; num157++)
						{
							DataRow dataRow24 = dataTable34.Rows[num157];
							int num158 = Conversions.ToInteger(dataRow24["MountID"].ToString());
							int num159 = Conversions.ToInteger(dataRow24["MountIndex"].ToString());
							int num160 = Conversions.ToInteger(dataRow24["WeaponID"].ToString());
							int num161 = Conversions.ToInteger(dataRow24["WeaponQty"].ToString());
							string text30 = Conversions.ToString(dataRow24["WeaponName"]);
							if (num158 == num142 && num159 == num99)
							{
								xmlWriter_0.WriteStartElement("WeaponEdit_" + Conversions.ToString(num160) + "_" + Conversions.ToString(num161));
								xmlWriter_0.WriteEndElement();
								xmlWriter_0.WriteComment(text30);
							}
						}
					}
					if ((dataTable3.Rows.Count > 0) | (dataTable2.Rows.Count > 0) | (dataTable37.Rows.Count > 0))
					{
						xmlWriter_0.WriteStartElement("MountMag");
						if (dataTable3.Rows.Count > 0)
						{
							int num162 = dataTable3.Rows.Count - 1;
							for (int num163 = 0; num163 <= num162; num163++)
							{
								DataRow dataRow25 = dataTable3.Rows[num163];
								int num164 = Conversions.ToInteger(dataRow25["MountID"].ToString());
								int num166 = Conversions.ToInteger(dataRow25["MountIndex"].ToString());
								int num167 = Conversions.ToInteger(dataRow25["WeaponID"].ToString());
								string text31 = Conversions.ToString(dataRow25["WeaponName"]);
								if (num164 == num142 && num166 == num99)
								{
									xmlWriter_0.WriteStartElement("WeaponRemove_" + Conversions.ToString(num167));
									xmlWriter_0.WriteEndElement();
									xmlWriter_0.WriteComment(text31);
								}
							}
						}
						if (dataTable2.Rows.Count > 0)
						{
							int num168 = dataTable2.Rows.Count - 1;
							for (int num169 = 0; num169 <= num168; num169++)
							{
								DataRow dataRow26 = dataTable2.Rows[num169];
								int num170 = Conversions.ToInteger(dataRow26["MountID"].ToString());
								int num171 = Conversions.ToInteger(dataRow26["MountIndex"].ToString());
								int num172 = Conversions.ToInteger(dataRow26["WeapRecID"].ToString());
								string text32 = Conversions.ToString(dataRow26["WeaponName"]);
								int num173 = Conversions.ToInteger(dataRow26["WeaponID"].ToString());
								if (num170 == num142 && num171 == num99)
								{
									xmlWriter_0.WriteStartElement("WeaponRecAdd_" + Conversions.ToString(num172) + "_" + Conversions.ToString(num173));
									xmlWriter_0.WriteEndElement();
									xmlWriter_0.WriteComment(text32);
								}
							}
						}
						if (dataTable37.Rows.Count > 0)
						{
							int num174 = dataTable37.Rows.Count - 1;
							for (int num175 = 0; num175 <= num174; num175++)
							{
								DataRow dataRow27 = dataTable37.Rows[num175];
								int num3 = Conversions.ToInteger(dataRow27["MountID"].ToString());
								int num4 = Conversions.ToInteger(dataRow27["MountIndex"].ToString());
								int num5 = Conversions.ToInteger(dataRow27["WeaponID"].ToString());
								int num6 = Conversions.ToInteger(dataRow27["WeaponQty"].ToString());
								string text33 = Conversions.ToString(dataRow27["WeaponName"]);
								if (num3 == num142 && num4 == num99)
								{
									xmlWriter_0.WriteStartElement("WeaponEdit_" + Conversions.ToString(num5) + "_" + Conversions.ToString(num6));
									xmlWriter_0.WriteEndElement();
									xmlWriter_0.WriteComment(text33);
								}
							}
						}
						xmlWriter_0.WriteEndElement();
					}
					xmlWriter_0.WriteEndElement();
				}
			}
			if (dataTable23.Rows.Count > 0)
			{
				int count = dataTable23.Rows.Count;
				int num7 = count - 1;
				for (int num8 = 0; num8 <= num7; num8++)
				{
					DataRow dataRow28 = dataTable23.Rows[count - 1 - num8];
					int num9 = Conversions.ToInteger(dataRow28["ComponentID"].ToString());
					string text35 = Conversions.ToString(dataRow28["Name"]);
					num99 = Conversions.ToInteger(dataRow28["MountIndex"].ToString());
					xmlWriter_0.WriteStartElement("MountRemove_" + Conversions.ToString(num99 + 1) + "_" + Conversions.ToString(num9));
					xmlWriter_0.WriteEndElement();
					xmlWriter_0.WriteComment(text35);
				}
			}
			if (activeUnit_0.IsFacility | activeUnit_0.IsShip | activeUnit_0.IsSubmarine | activeUnit_0.IsVehicle)
			{
				if (dataTable13.Rows.Count > 0)
				{
					int count3 = dataTable13.Rows.Count;
					int num10 = count3 - 1;
					for (int num11 = 0; num11 <= num10; num11++)
					{
						DataRow dataRow29 = dataTable13.Rows[count3 - 1 - num11];
						int num12 = Conversions.ToInteger(dataRow29["ComponentID"].ToString());
						string text36 = Conversions.ToString(dataRow29["Name"]);
						int num14 = Conversions.ToInteger(dataRow29["MagIndex"].ToString());
						xmlWriter_0.WriteStartElement("MagRemove_" + Conversions.ToString(num14 + 1) + "_" + Conversions.ToString(num12));
						xmlWriter_0.WriteEndElement();
						xmlWriter_0.WriteComment(text36);
					}
				}
				if (dataTable14.Rows.Count > 0)
				{
					int num15 = dataTable14.Rows.Count - 1;
					for (int num16 = 0; num16 <= num15; num16++)
					{
						DataRow dataRow30 = dataTable14.Rows[num16];
						int num17 = Conversions.ToInteger(dataRow30["ID"].ToString());
						string text37 = Conversions.ToString(dataRow30["Name"]);
						xmlWriter_0.WriteStartElement("MagAdd_" + Conversions.ToString(num17));
						xmlWriter_0.WriteEndElement();
						xmlWriter_0.WriteComment(text37);
					}
				}
				if (dataTable5.Rows.Count > 0)
				{
					int num18 = dataTable5.Rows.Count - 1;
					for (int num19 = 0; num19 <= num18; num19++)
					{
						DataRow dataRow31 = dataTable5.Rows[num19];
						int num20 = Conversions.ToInteger(dataRow31["MagID"].ToString());
						int num21 = Conversions.ToInteger(dataRow31["MagIndex"].ToString());
						string text38 = Conversions.ToString(dataRow31["MagName"]);
						xmlWriter_0.WriteStartElement("Mag_" + Conversions.ToString(num21 + 1) + "_" + Conversions.ToString(num20));
						xmlWriter_0.WriteComment(text38);
						if (dataTable8.Rows.Count > 0)
						{
							int num22 = dataTable8.Rows.Count - 1;
							for (int num23 = 0; num23 <= num22; num23++)
							{
								DataRow dataRow32 = dataTable8.Rows[num23];
								int num25 = Conversions.ToInteger(dataRow32["MagID"].ToString());
								int num26 = Conversions.ToInteger(dataRow32["MagIndex"].ToString());
								int num27 = Conversions.ToInteger(dataRow32["WeaponID"].ToString());
								string text39 = Conversions.ToString(dataRow32["WeaponName"]);
								if (num25 == num20 && num26 == num21)
								{
									xmlWriter_0.WriteStartElement("WeaponRemove_" + Conversions.ToString(num27));
									xmlWriter_0.WriteEndElement();
									xmlWriter_0.WriteComment(text39);
								}
							}
						}
						if (dataTable7.Rows.Count > 0)
						{
							int num28 = dataTable7.Rows.Count - 1;
							for (int num29 = 0; num29 <= num28; num29++)
							{
								DataRow dataRow33 = dataTable7.Rows[num29];
								int num30 = Conversions.ToInteger(dataRow33["MagID"].ToString());
								int num31 = Conversions.ToInteger(dataRow33["MagIndex"].ToString());
								int num32 = Conversions.ToInteger(dataRow33["WeapRecID"].ToString());
								int num33 = Conversions.ToInteger(dataRow33["WeaponID"].ToString());
								string text40 = Conversions.ToString(dataRow33["WeaponName"]);
								if (num30 == num20 && num31 == num21)
								{
									xmlWriter_0.WriteStartElement("WeaponRecAdd_" + Conversions.ToString(num32) + "_" + Conversions.ToString(num33));
									xmlWriter_0.WriteEndElement();
									xmlWriter_0.WriteComment(text40);
								}
							}
						}
						if (dataTable6.Rows.Count > 0)
						{
							int num34 = dataTable6.Rows.Count - 1;
							for (int num36 = 0; num36 <= num34; num36++)
							{
								DataRow dataRow35 = dataTable6.Rows[num36];
								int num37 = Conversions.ToInteger(dataRow35["MagID"].ToString());
								int num38 = Conversions.ToInteger(dataRow35["MagIndex"].ToString());
								int num39 = Conversions.ToInteger(dataRow35["WeaponID"].ToString());
								int num40 = Conversions.ToInteger(dataRow35["WeaponQty"].ToString());
								string text41 = Conversions.ToString(dataRow35["WeaponName"]);
								if (num37 == num20 && num38 == num21)
								{
									xmlWriter_0.WriteStartElement("WeaponEdit_" + Conversions.ToString(num39) + "_" + Conversions.ToString(num40));
									xmlWriter_0.WriteEndElement();
									xmlWriter_0.WriteComment(text41);
								}
							}
						}
						xmlWriter_0.WriteEndElement();
					}
				}
			}
			if (dataTable17.Rows.Count > 0 || dataTable4.Rows.Count > 0)
			{
				if (dataTable17.Rows.Count > 0)
				{
					int count4 = dataTable17.Rows.Count;
					int num41 = count4 - 1;
					for (int num42 = 0; num42 <= num41; num42++)
					{
						DataRow dataRow36 = dataTable17.Rows[count4 - 1 - num42];
						int num43 = Conversions.ToInteger(dataRow36["ComponentID"].ToString());
						string text42 = Conversions.ToString(dataRow36["Name"]);
						int num44 = Conversions.ToInteger(dataRow36["SensorIndex"].ToString());
						xmlWriter_0.WriteStartElement("SensorRemove_" + Conversions.ToString(num44 + 1) + "_" + Conversions.ToString(num43));
						xmlWriter_0.WriteEndElement();
						xmlWriter_0.WriteComment(text42);
					}
				}
				if (dataTable4.Rows.Count > 0)
				{
					int count5 = dataTable4.Rows.Count;
					int num45 = count5 - 1;
					for (int num47 = 0; num47 <= num45; num47++)
					{
						DataRow dataRow37 = dataTable4.Rows[count5 - 1 - num47];
						int num48 = Conversions.ToInteger(dataRow37["SensorID"].ToString());
						string text43 = Conversions.ToString(dataRow37["Name"]);
						num99 = Conversions.ToInteger(dataRow37["MountIndex"].ToString());
						int num49 = Conversions.ToInteger(dataRow37["MountID"].ToString());
						if (Conversions.ToBoolean(dataRow37["Remove"]))
						{
							xmlWriter_0.WriteStartElement("SensorMountRemove_" + Conversions.ToString(num99 + 1) + "_" + Conversions.ToString(num49) + "_" + Conversions.ToString(num48));
						}
						else
						{
							xmlWriter_0.WriteStartElement("SensorMountAdd_" + Conversions.ToString(num99 + 1) + "_" + Conversions.ToString(num49) + "_" + Conversions.ToString(num48));
						}
						xmlWriter_0.WriteEndElement();
						xmlWriter_0.WriteComment(text43);
					}
				}
			}
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				int count6 = dataTable.Rows.Count;
				int num50 = count6 - 1;
				for (int num51 = 0; num51 <= num50; num51++)
				{
					DataRow dataRow38 = dataTable.Rows[count6 - 1 - num51];
					int num52 = Conversions.ToInteger(dataRow38["ComponentID"].ToString());
					string text44 = Conversions.ToString(dataRow38["Name"]);
					int num53 = Conversions.ToInteger(dataRow38["SensorIndex"].ToString());
					xmlWriter_0.WriteStartElement("MCMRemove_" + Conversions.ToString(num53 + 1) + "_" + Conversions.ToString(num52));
					xmlWriter_0.WriteEndElement();
					xmlWriter_0.WriteComment(text44);
				}
			}
			if (dataTable24.Rows.Count > 0)
			{
				int count7 = dataTable24.Rows.Count;
				int num54 = count7 - 1;
				for (int num55 = 0; num55 <= num54; num55++)
				{
					DataRow dataRow39 = dataTable24.Rows[count7 - 1 - num55];
					int num56 = Conversions.ToInteger(dataRow39["ComponentID"].ToString());
					string text46 = Conversions.ToString(dataRow39["Name"]);
					int num58 = Conversions.ToInteger(dataRow39["CommIndex"].ToString());
					xmlWriter_0.WriteStartElement("CommRemove_" + Conversions.ToString(num58 + 1) + "_" + Conversions.ToString(num56));
					xmlWriter_0.WriteEndElement();
					xmlWriter_0.WriteComment(text46);
				}
			}
			if (dataTable18.Rows.Count > 0)
			{
				int num59 = dataTable18.Rows.Count - 1;
				for (int num60 = 0; num60 <= num59; num60++)
				{
					DataRow dataRow40 = dataTable18.Rows[num60];
					int num61 = Conversions.ToInteger(dataRow40["ID"].ToString());
					string text47 = Conversions.ToString(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow40["Name"])) ? "" : dataRow40["Name"]);
					xmlWriter_0.WriteStartElement("SensorAdd_" + Conversions.ToString(num61));
					xmlWriter_0.WriteComment(text47);
					PopWriter(xmlWriter_0, bool_0: true, dataRow40, activeUnit_0, text47);
				}
			}
			if (dataTable25.Rows.Count > 0)
			{
				int num62 = dataTable25.Rows.Count - 1;
				for (int num63 = 0; num63 <= num62; num63++)
				{
					DataRow dataRow41 = dataTable25.Rows[num63];
					int num64 = Conversions.ToInteger(dataRow41["ID"].ToString());
					string text48 = Conversions.ToString(dataRow41["Name"]);
					xmlWriter_0.WriteStartElement("CommAdd_" + Conversions.ToString(num64));
					xmlWriter_0.WriteEndElement();
					xmlWriter_0.WriteComment(text48);
				}
			}
			if (dataTable12.Rows.Count > 0)
			{
				int count8 = dataTable12.Rows.Count;
				int num65 = count8 - 1;
				for (int num66 = 0; num66 <= num65; num66++)
				{
					DataRow dataRow42 = dataTable12.Rows[count8 - 1 - num66];
					int num67 = Conversions.ToInteger(dataRow42["DBID"]);
					string text49 = dataRow42["Name"].ToString();
					xmlWriter_0.WriteStartElement("SensorActive_" + Conversions.ToString(num67));
					xmlWriter_0.WriteEndElement();
					xmlWriter_0.WriteComment(text49);
				}
				dataTable12.Clear();
			}
			if (dataTable29 != null && dataTable29.Rows.Count > 0)
			{
				int count9 = dataTable29.Rows.Count;
				int num69 = count9 - 1;
				for (int num70 = 0; num70 <= num69; num70++)
				{
					DataRow dataRow43 = dataTable29.Rows[count9 - 1 - num70];
					int num71 = Conversions.ToInteger(dataRow43["ComponentID"].ToString());
					string text50 = Conversions.ToString(dataRow43["Name"]);
					int num72 = Conversions.ToInteger(dataRow43["FacilityIndex"].ToString());
					xmlWriter_0.WriteStartElement("DockRemove_" + Conversions.ToString(num72 + 1) + "_" + Conversions.ToString(num71));
					xmlWriter_0.WriteEndElement();
					xmlWriter_0.WriteComment(text50);
				}
			}
			if (dataTable27 != null && dataTable27.Rows.Count > 0)
			{
				int num73 = dataTable27.Rows.Count - 1;
				for (int num74 = 0; num74 <= num73; num74++)
				{
					DataRow dataRow44 = dataTable27.Rows[num74];
					int num75 = Conversions.ToInteger(dataRow44["ID"].ToString());
					string text51 = Conversions.ToString(dataRow44["Name"]);
					xmlWriter_0.WriteStartElement("DockAdd_" + Conversions.ToString(num75));
					xmlWriter_0.WriteEndElement();
					xmlWriter_0.WriteComment(text51);
				}
			}
			if (dataTable30 != null && dataTable30.Rows.Count > 0)
			{
				int count10 = dataTable30.Rows.Count;
				int num76 = count10 - 1;
				for (int num77 = 0; num77 <= num76; num77++)
				{
					DataRow dataRow46 = dataTable30.Rows[count10 - 1 - num77];
					int num78 = Conversions.ToInteger(dataRow46["ComponentID"].ToString());
					string text52 = Conversions.ToString(dataRow46["Name"]);
					int num80 = Conversions.ToInteger(dataRow46["FacilityIndex"].ToString());
					xmlWriter_0.WriteStartElement("AirOpsRemove_" + Conversions.ToString(num80 + 1) + "_" + Conversions.ToString(num78));
					xmlWriter_0.WriteEndElement();
					xmlWriter_0.WriteComment(text52);
				}
			}
			if (dataTable28 != null && dataTable28.Rows.Count > 0)
			{
				int num81 = dataTable28.Rows.Count - 1;
				for (int num82 = 0; num82 <= num81; num82++)
				{
					DataRow dataRow47 = dataTable28.Rows[num82];
					int num83 = Conversions.ToInteger(dataRow47["ID"].ToString());
					string text53 = Conversions.ToString(dataRow47["Name"]);
					xmlWriter_0.WriteStartElement("AirOpsAdd_" + Conversions.ToString(num83));
					xmlWriter_0.WriteEndElement();
					xmlWriter_0.WriteComment(text53);
				}
			}
			if (dataTable31.Rows.Count > 0)
			{
				int count2 = dataTable31.Rows.Count;
				xmlWriter_0.WriteStartElement("Damage");
				int num84 = count2 - 1;
				for (int num85 = 0; num85 <= num84; num85++)
				{
					DataRow dataRow48 = dataTable31.Rows[num85];
					string text54 = Conversions.ToString(dataRow48["ID"]);
					string text55 = Conversions.ToString(dataRow48["Type"]);
					string value = dataRow48["Status"].ToString();
					string value2 = dataRow48["DamageSeverity"].ToString();
					string text57 = dataRow48["Name"].ToString();
					if (Operators.CompareString(text54, "", TextCompare: false) == 0)
					{
						xmlWriter_0.WriteElementString(text55, value);
						continue;
					}
					xmlWriter_0.WriteStartElement(text55 + "_" + text54);
					xmlWriter_0.WriteComment(text57);
					xmlWriter_0.WriteElementString("Status", value);
					xmlWriter_0.WriteElementString("Severity", value2);
					xmlWriter_0.WriteEndElement();
				}
				xmlWriter_0.WriteEndElement();
				dataTable31.Clear();
			}
			if (activeUnit_0.HasCustomOODA)
			{
				xmlWriter_0.WriteStartElement("CustomOODA");
				xmlWriter_0.WriteElementString("Detection", activeUnit_0.m_TokenVal.ToString());
				xmlWriter_0.WriteElementString("Targeting", activeUnit_0._IndexerVal.ToString());
				xmlWriter_0.WriteElementString("Evasion", activeUnit_0._ResolverVal.ToString());
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101417", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static string PopWriter(XmlWriter xmlWriter_0, bool bool_0, DataRow dataRow_0, object object_0, string string_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Cov");
			if (Conversions.ToBoolean(dataRow_0["Has360Coverage"]))
			{
				xmlWriter_0.WriteElementString("Seg", "360");
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (Conversions.ToBoolean(dataRow_0["PB1"]))
				{
					stringBuilder.Append("PB1,");
				}
				if (Conversions.ToBoolean(dataRow_0["PB2"]))
				{
					stringBuilder.Append("PB2,");
				}
				if (Conversions.ToBoolean(dataRow_0["PMA1"]))
				{
					stringBuilder.Append("PMA1,");
				}
				if (Conversions.ToBoolean(dataRow_0["PMA2"]))
				{
					stringBuilder.Append("PMA2,");
				}
				if (Conversions.ToBoolean(dataRow_0["PMF1"]))
				{
					stringBuilder.Append("PMF1,");
				}
				if (Conversions.ToBoolean(dataRow_0["PMF2"]))
				{
					stringBuilder.Append("PMF2,");
				}
				if (Conversions.ToBoolean(dataRow_0["PS1"]))
				{
					stringBuilder.Append("PS1,");
				}
				if (Conversions.ToBoolean(dataRow_0["PS2"]))
				{
					stringBuilder.Append("PS2,");
				}
				if (Conversions.ToBoolean(dataRow_0["SB1"]))
				{
					stringBuilder.Append("SB1,");
				}
				if (Conversions.ToBoolean(dataRow_0["SB2"]))
				{
					stringBuilder.Append("SB2,");
				}
				if (Conversions.ToBoolean(dataRow_0["SMA1"]))
				{
					stringBuilder.Append("SMA1,");
				}
				if (Conversions.ToBoolean(dataRow_0["SMA2"]))
				{
					stringBuilder.Append("SMA2,");
				}
				if (Conversions.ToBoolean(dataRow_0["SMF1"]))
				{
					stringBuilder.Append("SMF1,");
				}
				if (Conversions.ToBoolean(dataRow_0["SMF2"]))
				{
					stringBuilder.Append("SMF2,");
				}
				if (Conversions.ToBoolean(dataRow_0["SS2"]))
				{
					stringBuilder.Append("SS2,");
				}
				if (Conversions.ToBoolean(dataRow_0["SS1"]))
				{
					stringBuilder.Append("SS1,");
				}
				xmlWriter_0.WriteElementString("Seg", stringBuilder.ToString());
			}
			xmlWriter_0.WriteEndElement();
			string result = null;
			if (!Conversions.ToBoolean(dataRow_0["PB1"]) & !Conversions.ToBoolean(dataRow_0["PB2"]) & !Conversions.ToBoolean(dataRow_0["PMA1"]) & !Conversions.ToBoolean(dataRow_0["PMA2"]) & !Conversions.ToBoolean(dataRow_0["PMF1"]) & !Conversions.ToBoolean(dataRow_0["PMF2"]) & !Conversions.ToBoolean(dataRow_0["PS1"]) & !Conversions.ToBoolean(dataRow_0["PS2"]) & !Conversions.ToBoolean(dataRow_0["SB1"]) & !Conversions.ToBoolean(dataRow_0["SB2"]) & !Conversions.ToBoolean(dataRow_0["SMA1"]) & !Conversions.ToBoolean(dataRow_0["SMA2"]) & !Conversions.ToBoolean(dataRow_0["SMF1"]) & !Conversions.ToBoolean(dataRow_0["SMF2"]) & !Conversions.ToBoolean(dataRow_0["SS1"]) & !Conversions.ToBoolean(dataRow_0["SS2"]))
			{
				result = "错误：组件" + string_0 + "单元" + ((ActiveUnit)object_0).Name + " (" + ((Module_Unit.Unit)object_0).UnitClass + " [" + Conversions.ToString(((ActiveUnit)object_0).DBID) + "]）没有有效的弧！";
			}
			if (bool_0)
			{
				xmlWriter_0.WriteStartElement("Cov_Ill");
				if (Conversions.ToBoolean(dataRow_0["Has360CoverageMax"]))
				{
					xmlWriter_0.WriteElementString("Seg", "360");
				}
				else
				{
					StringBuilder stringBuilder2 = new StringBuilder();
					if (Conversions.ToBoolean(dataRow_0["PB1Max"]))
					{
						stringBuilder2.Append("PB1,");
					}
					if (Conversions.ToBoolean(dataRow_0["PB2Max"]))
					{
						stringBuilder2.Append("PB2,");
					}
					if (Conversions.ToBoolean(dataRow_0["PMA1Max"]))
					{
						stringBuilder2.Append("PMA1,");
					}
					if (Conversions.ToBoolean(dataRow_0["PMA2Max"]))
					{
						stringBuilder2.Append("PMA2,");
					}
					if (Conversions.ToBoolean(dataRow_0["PMF1Max"]))
					{
						stringBuilder2.Append("PMF1,");
					}
					if (Conversions.ToBoolean(dataRow_0["PMF2Max"]))
					{
						stringBuilder2.Append("PMF2,");
					}
					if (Conversions.ToBoolean(dataRow_0["PS1Max"]))
					{
						stringBuilder2.Append("PS1,");
					}
					if (Conversions.ToBoolean(dataRow_0["PS2Max"]))
					{
						stringBuilder2.Append("PS2,");
					}
					if (Conversions.ToBoolean(dataRow_0["SB1Max"]))
					{
						stringBuilder2.Append("SB1,");
					}
					if (Conversions.ToBoolean(dataRow_0["SB2Max"]))
					{
						stringBuilder2.Append("SB2,");
					}
					if (Conversions.ToBoolean(dataRow_0["SMA1Max"]))
					{
						stringBuilder2.Append("SMA1,");
					}
					if (Conversions.ToBoolean(dataRow_0["SMA2Max"]))
					{
						stringBuilder2.Append("SMA2,");
					}
					if (Conversions.ToBoolean(dataRow_0["SMF1Max"]))
					{
						stringBuilder2.Append("SMF1,");
					}
					if (Conversions.ToBoolean(dataRow_0["SMF2Max"]))
					{
						stringBuilder2.Append("SMF2,");
					}
					if (Conversions.ToBoolean(dataRow_0["SS2Max"]))
					{
						stringBuilder2.Append("SS2,");
					}
					if (Conversions.ToBoolean(dataRow_0["SS1Max"]))
					{
						stringBuilder2.Append("SS1,");
					}
					xmlWriter_0.WriteElementString("Seg", stringBuilder2.ToString());
				}
				xmlWriter_0.WriteEndElement();
				if (!Conversions.ToBoolean(dataRow_0["PB1Max"]) & !Conversions.ToBoolean(dataRow_0["PB2Max"]) & !Conversions.ToBoolean(dataRow_0["PMA1Max"]) & !Conversions.ToBoolean(dataRow_0["PMA2Max"]) & !Conversions.ToBoolean(dataRow_0["PMF1Max"]) & !Conversions.ToBoolean(dataRow_0["PMF2Max"]) & !Conversions.ToBoolean(dataRow_0["PS1Max"]) & !Conversions.ToBoolean(dataRow_0["PS2Max"]) & !Conversions.ToBoolean(dataRow_0["PS1Max"]) & !Conversions.ToBoolean(dataRow_0["SB2Max"]) & !Conversions.ToBoolean(dataRow_0["SMA1Max"]) & !Conversions.ToBoolean(dataRow_0["SMA2Max"]) & !Conversions.ToBoolean(dataRow_0["SMF1Max"]) & !Conversions.ToBoolean(dataRow_0["SMF2Max"]) & !Conversions.ToBoolean(dataRow_0["SS1Max"]) & !Conversions.ToBoolean(dataRow_0["SS2Max"]))
				{
					result = "错误：组件" + string_0 + "单元" + ((ActiveUnit)object_0).Name + " (" + ((Module_Unit.Unit)object_0).UnitClass + " [" + Conversions.ToString(((ActiveUnit)object_0).DBID) + "]) does not have a valid Max/Illuminate arc!";
				}
			}
			xmlWriter_0.WriteEndElement();
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101115", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return "Error!";
		}
	}

	private static int InstantiateWriter(Scenario scenario_0, ref Mount mount_0, XmlNode xmlNode_0, int int_0)
	{
		int result = 0;
		try
		{
			bool flag = false;
			bool flag2 = false;
			IEnumerator enumerator = null;
			int num = 0;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					string[] array = xmlNode.Name.Split('_');
					switch (array[0])
					{
					case "WeaponRemove":
					{
						int num2 = Conversions.ToInteger(array[1]);
						bool flag3 = false;
						List<WeaponRec> list = new List<WeaponRec>();
						foreach (WeaponRec mountWeapon in mount_0.MountWeapons)
						{
							if (mountWeapon.int_0 == num2)
							{
								list.Add(mountWeapon);
							}
						}
						foreach (WeaponRec item in list)
						{
							mount_0.MountWeapons.Remove(item);
							flag3 = true;
							if (int_0 == 0)
							{
								flag = true;
							}
							string text = "用DBID删除了武器" + Conversions.ToString(num2);
							StreamWriter streamWriter2 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter2.Write("\r\n      " + text);
							streamWriter2.Close();
							num++;
						}
						if (!flag3 && int_0 != 0)
						{
							string text2 = "错误：武器DBID" + Conversions.ToString(num2) + "可能无法移除，也未找到挂载！";
							StreamWriter streamWriter3 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter3.Write("\r\n      " + text2);
							streamWriter3.Close();
						}
						break;
					}
					case "WeaponRecAdd":
					{
						int num5 = Conversions.ToInteger(array[1]);
						int int_ = ((array.Length > 2) ? Conversions.ToInteger(array[2]) : 0);
						if (num5 == 0)
						{
							WeaponRec weaponRec = new WeaponRec(ref scenario_0, int_, 0, 10000, 1, 1, bool_0: false, bool_1: false);
							mount_0.MountWeapons.Add(weaponRec);
							if (int_0 == 0)
							{
								flag = true;
							}
							string text5 = "Added non-database 0/10000 WeaponRec, Weapon DBID " + Conversions.ToString(weaponRec.int_0) + "到弹药库" + mount_0.Name;
							StreamWriter streamWriter6 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter6.Write("\r\n      " + text5);
							streamWriter6.Close();
							num++;
							break;
						}
						SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
						string string_ = "SELECT * from DataWeaponRecord where ID = " + Conversions.ToString(num5);
						if (DBCache.GetDatatable(sqliteHelper_, string_).Rows.Count == 0)
						{
							if (int_0 != 0)
							{
								string text6 = "错误：武器纪录" + Conversions.ToString(num5) + "不能添加，也不能在数据库中找到！";
								StreamWriter streamWriter7 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter7.Write("\r\n      " + text6);
								streamWriter7.Close();
							}
							break;
						}
						WeaponRec weaponRec2 = DBFunctions.GetWeaponRec(num5, mount_0.ParentPlatform.ParentScen);
						mount_0.MountWeapons.Add(weaponRec2);
						if (int_0 == 0)
						{
							flag = true;
						}
						string text7 = "添加了WeaponRec" + Conversions.ToString(num5) + "，武器DBID" + Conversions.ToString(weaponRec2.int_0) + "挂载" + mount_0.Name;
						StreamWriter streamWriter8 = File.AppendText(GameGeneral.SBRLogFilePath);
						streamWriter8.Write("\r\n      " + text7);
						streamWriter8.Close();
						num++;
						break;
					}
					case "WeaponEdit":
					{
						int num3 = Conversions.ToInteger(array[1]);
						int num4 = Conversions.ToInteger(array[2]);
						bool flag4 = false;
						foreach (WeaponRec mountWeapon2 in mount_0.MountWeapons)
						{
							if (mountWeapon2.int_0 == num3)
							{
								flag4 = true;
								mountWeapon2.CurrentLoad = num4;
								if (int_0 == 0)
								{
									flag = true;
								}
								string text3 = "使用DBID更新武器" + Conversions.ToString(num3) + "，数量：" + Conversions.ToString(num4);
								StreamWriter streamWriter4 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter4.Write("\r\n      " + text3);
								streamWriter4.Close();
								num++;
							}
						}
						if (!flag4 && int_0 != 0)
						{
							string text4 = "错误：武器数量不能更新，武器与DBID" + Conversions.ToString(num3) + "没有找到安装！";
							StreamWriter streamWriter5 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter5.Write("\r\n      " + text4);
							streamWriter5.Close();
						}
						break;
					}
					case "MountMag":
					{
						Magazine magazine_ = mount_0.MountMagazine;
						CreateWriter(scenario_0, ref magazine_, xmlNode, int_0, bool_0: true);
						break;
					}
					case "#comment":
					{
						string innerText = xmlNode.InnerText;
						StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
						if (!flag2 && int_0 != 0)
						{
							flag2 = true;
							streamWriter.Write("\r\n    " + innerText);
						}
						else if ((flag2 && int_0 != 0) || (int_0 == 0 && flag))
						{
							streamWriter.Write(" -- " + innerText);
						}
						streamWriter.Close();
						break;
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
			result = num;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101116", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private static int CreateWriter(Scenario scenario_0, ref Magazine magazine_0, XmlNode xmlNode_0, int int_0, bool bool_0)
	{
		bool flag = false;
		bool flag2 = false;
		if (bool_0)
		{
			flag2 = true;
		}
		string text = (bool_0 ? "    " : "");
		int result = 0;
		try
		{
			IEnumerator enumerator = null;
			int num = 0;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					string[] array = xmlNode.Name.Split('_');
					switch (array[0])
					{
					case "WeaponRemove":
					{
						int num5 = Conversions.ToInteger(array[1]);
						bool flag4 = false;
						List<WeaponRec> list = new List<WeaponRec>();
						foreach (WeaponRec weapon in magazine_0.Weapons)
						{
							if (weapon.int_0 == num5)
							{
								list.Add(weapon);
							}
						}
						foreach (WeaponRec item in list)
						{
							magazine_0.Weapons.Remove(item);
							flag4 = true;
							if (int_0 == 0)
							{
								flag = true;
							}
							string text6 = "删除了武器DBID" + Conversions.ToString(num5);
							StreamWriter streamWriter7 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter7.Write("\r\n      " + text + text6);
							streamWriter7.Close();
							num++;
						}
						if (!flag4 && int_0 != 0)
						{
							string text7 = "错误：武器DBID" + Conversions.ToString(num5) + "可能无法移除，也未找到挂载！";
							StreamWriter streamWriter8 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter8.Write("\r\n      " + text + text7);
							streamWriter8.Close();
						}
						break;
					}
					case "WeaponRecAdd":
					{
						int num4 = Conversions.ToInteger(array[1]);
						int int_ = ((array.Length > 2) ? Conversions.ToInteger(array[2]) : 0);
						if (num4 == 0)
						{
							WeaponRec weaponRec = new WeaponRec(ref scenario_0, int_, 0, 10000, 1, 1, bool_0: false, bool_1: false);
							magazine_0.Weapons.Add(weaponRec);
							if (int_0 == 0)
							{
								flag = true;
							}
							string text4 = "Added non-database 0/10000 WeaponRec, Weapon DBID " + Conversions.ToString(weaponRec.int_0) + "到弹药库" + magazine_0.Name;
							StreamWriter streamWriter4 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter4.Write("\r\n      " + text + text4);
							streamWriter4.Close();
							num++;
							break;
						}
						SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
						string string_ = "SELECT * from DataWeaponRecord where ID = " + Conversions.ToString(num4);
						string text5;
						if (DBCache.GetDatatable(sqliteHelper_, string_).Rows.Count == 0)
						{
							if (int_0 != 0)
							{
								text5 = "错误：武器纪录" + Conversions.ToString(num4) + "不能添加，也不能在数据库中找到！";
								StreamWriter streamWriter5 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter5.Write("\r\n      " + text + text5);
								streamWriter5.Close();
							}
							break;
						}
						WeaponRec weaponRec2 = DBFunctions.GetWeaponRec(num4, magazine_0.ParentPlatform.ParentScen);
						magazine_0.Weapons.Add(weaponRec2);
						if (int_0 == 0)
						{
							flag = true;
						}
						text5 = "添加了WeaponRec" + Conversions.ToString(num4) + "，武器DBID" + Conversions.ToString(weaponRec2.int_0) + "到弹药库" + magazine_0.Name;
						StreamWriter streamWriter6 = File.AppendText(GameGeneral.SBRLogFilePath);
						streamWriter6.Write("\r\n      " + text + text5);
						streamWriter6.Close();
						num++;
						break;
					}
					case "WeaponEdit":
					{
						bool flag3 = false;
						int num2 = Conversions.ToInteger(array[1]);
						int num3 = Conversions.ToInteger(array[2]);
						foreach (WeaponRec weapon2 in magazine_0.Weapons)
						{
							if (weapon2.int_0 == num2)
							{
								flag3 = true;
								weapon2.CurrentLoad = num3;
								if (int_0 == 0)
								{
									flag = true;
								}
								string text2 = "使用DBID更新武器" + Conversions.ToString(num2) + "，数量：" + Conversions.ToString(num3);
								StreamWriter streamWriter2 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter2.Write("\r\n      " + text + text2);
								streamWriter2.Close();
								num++;
							}
						}
						if (!flag3 && int_0 != 0)
						{
							string text3 = "错误：武器数量不能更新，武器与DBID" + Conversions.ToString(num2) + "没找到弹药库！";
							StreamWriter streamWriter3 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter3.Write("\r\n      " + text + text3);
							streamWriter3.Close();
						}
						break;
					}
					case "#comment":
					{
						string innerText = xmlNode.InnerText;
						StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
						if (!flag2 && int_0 != 0)
						{
							flag2 = true;
							streamWriter.Write("\r\n   " + innerText);
						}
						else if ((flag2 && int_0 != 0) || (int_0 == 0 && flag))
						{
							streamWriter.Write(" -- " + innerText);
						}
						streamWriter.Close();
						break;
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
			result = num;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101117", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static void ApplyDeltaToThisUnit(XmlNode xmlNode_0, ActiveUnit activeUnit_0, Scenario scenario_0, XmlWriter xmlWriter_0, StreamWriter streamWriter_0, bool bool_0, ref int int_0)
	{
		Cargo Local_theCargo = null;
		string text = xmlNode_0.Name.Split('_')[1];
		if (activeUnit_0 == null)
		{
			activeUnit_0 = scenario_0.ActiveUnits[text];
		}
		if (activeUnit_0 == null)
		{
			string text2 = "错误：单元#" + text + "在想定中不存在！";
			StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
			streamWriter.Write("\r\n  " + text2);
			streamWriter.Close();
			int_0++;
			return;
		}
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		string string_ = null;
		string string_2 = null;
		string string_3 = null;
		switch (activeUnit_0.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			string_ = "Select YearCommissioned, YearDecommissioned from DataAircraft where ID = " + Conversions.ToString(activeUnit_0.DBID);
			string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataAircraft where ID = " + Conversions.ToString(activeUnit_0.DBID) + ")";
			string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataAircraft where ID = " + Conversions.ToString(activeUnit_0.DBID) + ")";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			string_ = "Select YearCommissioned, YearDecommissioned from DataShip where ID = " + Conversions.ToString(activeUnit_0.DBID);
			string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataShip where ID = " + Conversions.ToString(activeUnit_0.DBID) + ")";
			string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataShip where ID = " + Conversions.ToString(activeUnit_0.DBID) + ")";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			string_ = "Select YearCommissioned, YearDecommissioned from DataSubmarine where ID = " + Conversions.ToString(activeUnit_0.DBID);
			string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataSubmarine where ID = " + Conversions.ToString(activeUnit_0.DBID) + ")";
			string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataSubmarine where ID = " + Conversions.ToString(activeUnit_0.DBID) + ")";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			string_ = "Select YearCommissioned, YearDecommissioned from DataFacility where ID = " + Conversions.ToString(activeUnit_0.DBID);
			string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataFacility where ID = " + Conversions.ToString(activeUnit_0.DBID) + ")";
			string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataFacility where ID = " + Conversions.ToString(activeUnit_0.DBID) + ")";
			break;
		case GlobalVariables.ActiveUnitType.Satellite:
			string_ = "Select YearCommissioned, YearDecommissioned from DataSatellite where ID = " + Conversions.ToString(activeUnit_0.DBID);
			string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataSatellite where ID = " + Conversions.ToString(activeUnit_0.DBID) + ")";
			string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataSatellite where ID = " + Conversions.ToString(activeUnit_0.DBID) + ")";
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			string_ = "Select YearCommissioned, YearDecommissioned from DataGroundUnit where ID = " + Conversions.ToString(activeUnit_0.DBID);
			string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataGroundUnit where ID = " + Conversions.ToString(activeUnit_0.DBID) + ")";
			string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataGroundUnit where ID = " + Conversions.ToString(activeUnit_0.DBID) + ")";
			break;
		}
		if (!(activeUnit_0.IsAircraft | activeUnit_0.IsFacility | activeUnit_0.IsShip | activeUnit_0.IsSubmarine | activeUnit_0.IsSatellite | activeUnit_0.IsVehicle))
		{
			return;
		}
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, string_);
		DataTable datatable2 = DBCache.GetDatatable(sqliteHelper_, string_2);
		DataTable datatable3 = DBCache.GetDatatable(sqliteHelper_, string_3);
		string text7;
		if ((datatable.Rows.Count != 0) & (datatable2.Rows.Count != 0) & (datatable3.Rows.Count != 0))
		{
			DataRow dataRow = datatable.Rows[0];
			DataRow dataRow2 = datatable2.Rows[0];
			DataRow dataRow3 = datatable3.Rows[0];
			string text3 = Strings.Trim(dataRow2["Description"].ToString());
			string text4 = Strings.Trim(dataRow3["Description"].ToString());
			string text5 = Conversions.ToString(Conversions.ToInteger(dataRow["YearCommissioned"].ToString()));
			string text6 = Conversions.ToString(Conversions.ToInteger(dataRow["YearDecommissioned"].ToString()));
			text7 = Conversions.ToString(activeUnit_0.DBID) + " -- " + activeUnit_0.Name + "  ----  " + activeUnit_0.UnitClass + " -- " + text3 + " (" + text4 + "), " + text5 + "-" + text6 + "  ----  " + activeUnit_0.ObjectID;
			StreamWriter streamWriter12 = File.AppendText(GameGeneral.SBRLogFilePath);
			streamWriter12.Write("\r\n  " + text7);
			streamWriter12.Close();
			List<Tuple<string, int, int, string>> list = new List<Tuple<string, int, int, string>>();
			list.Clear();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				IEnumerator enumerator3 = null;
				int num = 0;
				IEnumerator enumerator4 = null;
				IEnumerator enumerator5 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					string text8 = xmlNode.Name.Split('_')[0];
					switch (text8)
					{
					case "AirOpsAdd":
					{
						int num18 = Conversions.ToInteger(xmlNode.Name.Split('_')[1]);
						if (num18 <= 0)
						{
							if (num18 == -1)
							{
								AirFacility airFacility2 = AirFacility.AddUAV_Class1_Hanger(activeUnit_0);
								text7 = "Added Air Facility, DBID: " + Conversions.ToString(num18) + " 名称: " + airFacility2.Name;
								StreamWriter streamWriter39 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter39.Write("\r\n    " + text7);
								streamWriter39.Close();
							}
							break;
						}
						SQLiteConnection sqliteConnection_2 = scenario_0.DBConnection;
						AirFacility airFacility3 = DBFunctions.GetAirFacility(num18, ref sqliteConnection_2);
						if (airFacility3 == null)
						{
							text7 = "ERROR: AIR FACILITY WITH DBID " + Conversions.ToString(num18) + "不能添加，也不能在数据库中找到！";
							StreamWriter streamWriter40 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter40.Write("\r\n    " + text7);
							streamWriter40.Close();
						}
						else
						{
							activeUnit_0.AddAirFacility(airFacility3);
							airFacility3.ParentPlatform = activeUnit_0;
							text7 = "Added Air Facility, DBID: " + Conversions.ToString(num18) + " 名称: " + airFacility3.Name;
							StreamWriter streamWriter41 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter41.Write("\r\n    " + text7);
							streamWriter41.Close();
						}
						break;
					}
					case "SensorActive":
					{
						if (activeUnit_0.Sensory.Boolean_0)
						{
							activeUnit_0.Sensory.Boolean_0 = false;
						}
						float num9 = Conversions.ToInteger(xmlNode.Name.Split('_')[1]);
						Sensor[] sensors_ReadOnly4 = activeUnit_0.Sensors_Cached;
						Sensor[] array7 = sensors_ReadOnly4;
						foreach (Sensor sensor3 in array7)
						{
							if ((float)sensor3.DBID == num9 && !sensor3.IsActive)
							{
								sensor3.GoActive();
								text7 = "激活传感器[" + Conversions.ToString(num9) + "]";
								StreamWriter streamWriter26 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter26.Write("\r\n    " + text7);
								streamWriter26.Close();
							}
						}
						break;
					}
					case "MountAdd":
					{
						int num17 = Conversions.ToInteger(xmlNode.Name.Split('_')[1]);
						bool flag = false;
						if (num17 <= 0)
						{
							break;
						}
						string string_5 = "SELECT Name from DataMount where ID = " + Conversions.ToString(num17);
						if (DBCache.GetDatatable(sqliteHelper_, string_5).Rows.Count == 0)
						{
							text7 = "错误：挂载DBID" + Conversions.ToString(num17) + "不能添加，也不能在数据库中找到！";
							StreamWriter streamWriter36 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter36.Write("\r\n    " + text7);
							streamWriter36.Close();
							int_0++;
							break;
						}
						Mount mount2 = DBFunctions.GetMount(num17, ref scenario_0);
						activeUnit_0.Mounts.Add(mount2);
						mount2.ParentPlatform = activeUnit_0;
						try
						{
							enumerator4 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator4.Current;
								string name12 = xmlNode_2.Name;
								if (Operators.CompareString(name12, "Coverage", TextCompare: false) == 0 || Operators.CompareString(name12, "Cov", TextCompare: false) == 0)
								{
									mount2.Coverage = PlatformComponent._Coverage.FromXML(ref xmlNode_2);
									flag = true;
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
						if (flag && mount2.Sensors_ReadOnly.Count() > 0)
						{
							Sensor[] sensors_ReadOnly3 = mount2.Sensors_ReadOnly;
							Sensor[] array8 = sensors_ReadOnly3;
							foreach (Sensor obj in array8)
							{
								obj.ParentPlatform = activeUnit_0;
								obj.Coverage.PB1 = mount2.Coverage.PB1;
								obj.Coverage.PB2 = mount2.Coverage.PB2;
								obj.Coverage.PMA1 = mount2.Coverage.PMA1;
								obj.Coverage.PMA2 = mount2.Coverage.PMA2;
								obj.Coverage.PMF1 = mount2.Coverage.PMF1;
								obj.Coverage.PMF2 = mount2.Coverage.PMF2;
								obj.Coverage.PS1 = mount2.Coverage.PS1;
								obj.Coverage.PS2 = mount2.Coverage.PS2;
								obj.Coverage.SB1 = mount2.Coverage.SB1;
								obj.Coverage.SB2 = mount2.Coverage.SB2;
								obj.Coverage.SMA1 = mount2.Coverage.SMA1;
								obj.Coverage.SMA2 = mount2.Coverage.SMA2;
								obj.Coverage.SMF1 = mount2.Coverage.SMF1;
								obj.Coverage.SMF2 = mount2.Coverage.SMF2;
								obj.Coverage.SS1 = mount2.Coverage.SS1;
								obj.Coverage.SS2 = mount2.Coverage.SS2;
							}
						}
						text7 = "添加了挂架，DBID：" + Conversions.ToString(num17) + " 名称 " + mount2.Name;
						StreamWriter streamWriter37 = File.AppendText(GameGeneral.SBRLogFilePath);
						streamWriter37.Write("\r\n    " + text7);
						streamWriter37.Close();
						if (!flag)
						{
							text7 = "错误：挂载DBID" + Conversions.ToString(num17) + "没有设置角度！";
							StreamWriter streamWriter38 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter38.Write("\r\n    " + text7);
							streamWriter38.Close();
							int_0++;
						}
						break;
					}
					case "Damage":
						try
						{
							enumerator3 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator3.Current;
								switch (xmlNode2.Name.Split('_')[0])
								{
								case "Cargo":
								{
									string right4 = xmlNode2.Name.Split('_')[1];
									Cargo[] onboardCargo = activeUnit_0.OnboardCargo;
									Cargo[] array5 = onboardCargo;
									foreach (Cargo cargo in array5)
									{
										if (Operators.CompareString(cargo.ObjectID, right4, TextCompare: false) != 0)
										{
											continue;
										}
										PlatformComponent._ComponentStatus componentStatus4 = PlatformComponent._ComponentStatus.Operational;
										PlatformComponent._DamageSeverityFactor damageSeverityFactor4 = PlatformComponent._DamageSeverityFactor.Light;
										if (xmlNode2.SelectSingleNode("Severity") != null)
										{
											damageSeverityFactor4 = (PlatformComponent._DamageSeverityFactor)Conversions.ToByte(xmlNode2.SelectSingleNode("Severity").InnerText);
											if (cargo.DamageSeverity == damageSeverityFactor4)
											{
												damageSeverityFactor4 = PlatformComponent._DamageSeverityFactor.Light;
											}
											else
											{
												cargo.Damage(damageSeverityFactor4);
											}
										}
										if (xmlNode2.SelectSingleNode("Status") == null)
										{
											continue;
										}
										componentStatus4 = (PlatformComponent._ComponentStatus)Conversions.ToByte(xmlNode2.SelectSingleNode("Status").InnerText);
										if (cargo.Status == componentStatus4)
										{
											break;
										}
										switch (componentStatus4)
										{
										case PlatformComponent._ComponentStatus.Operational:
											cargo.Repair();
											break;
										case PlatformComponent._ComponentStatus.Damaged:
											if (damageSeverityFactor4 == PlatformComponent._DamageSeverityFactor.Light)
											{
												cargo.Damage(cargo.DamageSeverity);
											}
											break;
										case PlatformComponent._ComponentStatus.Destroyed:
											cargo.Destroy(activeUnit_0.GetUnitSide(), bool_0: true, bool_1: false);
											break;
										}
										break;
									}
									break;
								}
								case "Fire":
									activeUnit_0.Damage.FireIntensity = (ActiveUnit_Damage.FireIntensityLevel)Conversions.ToByte(xmlNode2.InnerText);
									break;
								case "Mag":
								{
									string right2 = xmlNode2.Name.Split('_')[1];
									Magazine[] sharedMagazines = activeUnit_0.SharedMagazines;
									Magazine[] array3 = sharedMagazines;
									foreach (Magazine magazine2 in array3)
									{
										if (Operators.CompareString(magazine2.ObjectID, right2, TextCompare: false) != 0)
										{
											continue;
										}
										PlatformComponent._ComponentStatus componentStatus2 = PlatformComponent._ComponentStatus.Operational;
										PlatformComponent._DamageSeverityFactor damageSeverityFactor2 = PlatformComponent._DamageSeverityFactor.Light;
										if (xmlNode2.SelectSingleNode("Severity") != null)
										{
											damageSeverityFactor2 = (PlatformComponent._DamageSeverityFactor)Conversions.ToByte(xmlNode2.SelectSingleNode("Severity").InnerText);
											if (magazine2.DamageSeverity == damageSeverityFactor2)
											{
												damageSeverityFactor2 = PlatformComponent._DamageSeverityFactor.Light;
											}
											else
											{
												magazine2.Damage(damageSeverityFactor2);
											}
										}
										if (xmlNode2.SelectSingleNode("Status") == null)
										{
											continue;
										}
										componentStatus2 = (PlatformComponent._ComponentStatus)Conversions.ToByte(xmlNode2.SelectSingleNode("Status").InnerText);
										if (magazine2.Status == componentStatus2)
										{
											break;
										}
										switch (componentStatus2)
										{
										case PlatformComponent._ComponentStatus.Operational:
											magazine2.Repair();
											break;
										case PlatformComponent._ComponentStatus.Damaged:
											if (damageSeverityFactor2 == PlatformComponent._DamageSeverityFactor.Light)
											{
												magazine2.Damage(magazine2.DamageSeverity);
											}
											break;
										case PlatformComponent._ComponentStatus.Destroyed:
											magazine2.Destroy(activeUnit_0.GetUnitSide(), bool_0: true, bool_1: false);
											break;
										}
										break;
									}
									break;
								}
								case "Mount":
								{
									string right7 = xmlNode2.Name.Split('_')[1];
									foreach (Mount mount3 in activeUnit_0.Mounts)
									{
										if (Operators.CompareString(mount3.ObjectID, right7, TextCompare: false) != 0)
										{
											continue;
										}
										PlatformComponent._ComponentStatus componentStatus7 = PlatformComponent._ComponentStatus.Operational;
										PlatformComponent._DamageSeverityFactor damageSeverityFactor7 = PlatformComponent._DamageSeverityFactor.Light;
										if (xmlNode2.SelectSingleNode("Severity") != null)
										{
											damageSeverityFactor7 = (PlatformComponent._DamageSeverityFactor)Conversions.ToByte(xmlNode2.SelectSingleNode("Severity").InnerText);
											if (mount3.DamageSeverity == damageSeverityFactor7)
											{
												damageSeverityFactor7 = PlatformComponent._DamageSeverityFactor.Light;
											}
											else
											{
												mount3.Damage(damageSeverityFactor7);
											}
										}
										if (xmlNode2.SelectSingleNode("Status") == null)
										{
											continue;
										}
										componentStatus7 = (PlatformComponent._ComponentStatus)Conversions.ToByte(xmlNode2.SelectSingleNode("Status").InnerText);
										if (mount3.Status == componentStatus7)
										{
											break;
										}
										switch (componentStatus7)
										{
										case PlatformComponent._ComponentStatus.Operational:
											mount3.Repair();
											break;
										case PlatformComponent._ComponentStatus.Damaged:
											if (damageSeverityFactor7 == PlatformComponent._DamageSeverityFactor.Light)
											{
												mount3.Damage(mount3.DamageSeverity);
											}
											break;
										case PlatformComponent._ComponentStatus.Destroyed:
											mount3.Destroy(activeUnit_0.GetUnitSide(), bool_0: true, bool_1: false);
											break;
										}
										break;
									}
									break;
								}
								case "DamagePts":
									activeUnit_0.SetDamagePts(bool_0: false, null, Conversions.ToInteger(xmlNode2.InnerText));
									break;
								case "Comm":
								{
									string right6 = xmlNode2.Name.Split('_')[1];
									CommDevice[] comms_ReadOnly = activeUnit_0.Comms_ReadOnly;
									CommDevice[] array6 = comms_ReadOnly;
									foreach (CommDevice commDevice in array6)
									{
										if (Operators.CompareString(commDevice.ObjectID, right6, TextCompare: false) != 0)
										{
											continue;
										}
										PlatformComponent._ComponentStatus componentStatus6 = PlatformComponent._ComponentStatus.Operational;
										PlatformComponent._DamageSeverityFactor damageSeverityFactor6 = PlatformComponent._DamageSeverityFactor.Light;
										if (xmlNode2.SelectSingleNode("Severity") != null)
										{
											damageSeverityFactor6 = (PlatformComponent._DamageSeverityFactor)Conversions.ToByte(xmlNode2.SelectSingleNode("Severity").InnerText);
											if (commDevice.DamageSeverity == damageSeverityFactor6)
											{
												damageSeverityFactor6 = PlatformComponent._DamageSeverityFactor.Light;
											}
											else
											{
												commDevice.Damage(damageSeverityFactor6);
											}
										}
										if (xmlNode2.SelectSingleNode("Status") == null)
										{
											continue;
										}
										componentStatus6 = (PlatformComponent._ComponentStatus)Conversions.ToByte(xmlNode2.SelectSingleNode("Status").InnerText);
										if (commDevice.Status == componentStatus6)
										{
											break;
										}
										switch (componentStatus6)
										{
										case PlatformComponent._ComponentStatus.Operational:
											commDevice.Repair();
											break;
										case PlatformComponent._ComponentStatus.Damaged:
											if (damageSeverityFactor6 == PlatformComponent._DamageSeverityFactor.Light)
											{
												commDevice.Damage(commDevice.DamageSeverity);
											}
											break;
										case PlatformComponent._ComponentStatus.Destroyed:
											commDevice.Destroy(activeUnit_0.GetUnitSide(), bool_0: true, bool_1: false);
											break;
										}
										break;
									}
									break;
								}
								case "Flood":
									activeUnit_0.Damage.FloodIntensity = (ActiveUnit_Damage.FloodingIntensityLevel)Conversions.ToByte(xmlNode2.InnerText);
									break;
								case "Engine":
								{
									string right5 = xmlNode2.Name.Split('_')[1];
									foreach (Engine item7 in activeUnit_0.Propulsion)
									{
										if (Operators.CompareString(item7.ObjectID, right5, TextCompare: false) != 0)
										{
											continue;
										}
										PlatformComponent._ComponentStatus componentStatus5 = PlatformComponent._ComponentStatus.Operational;
										PlatformComponent._DamageSeverityFactor damageSeverityFactor5 = PlatformComponent._DamageSeverityFactor.Light;
										if (xmlNode2.SelectSingleNode("Severity") != null)
										{
											damageSeverityFactor5 = (PlatformComponent._DamageSeverityFactor)Conversions.ToByte(xmlNode2.SelectSingleNode("Severity").InnerText);
											if (item7.DamageSeverity == damageSeverityFactor5)
											{
												damageSeverityFactor5 = PlatformComponent._DamageSeverityFactor.Light;
											}
											else
											{
												item7.Damage(damageSeverityFactor5);
											}
										}
										if (xmlNode2.SelectSingleNode("Status") == null)
										{
											continue;
										}
										componentStatus5 = (PlatformComponent._ComponentStatus)Conversions.ToByte(xmlNode2.SelectSingleNode("Status").InnerText);
										if (item7.Status == componentStatus5)
										{
											break;
										}
										switch (componentStatus5)
										{
										case PlatformComponent._ComponentStatus.Operational:
											item7.Repair();
											break;
										case PlatformComponent._ComponentStatus.Damaged:
											if (damageSeverityFactor5 == PlatformComponent._DamageSeverityFactor.Light)
											{
												item7.Damage(item7.DamageSeverity);
											}
											break;
										case PlatformComponent._ComponentStatus.Destroyed:
											item7.Destroy(activeUnit_0.GetUnitSide(), bool_0: true, bool_1: false);
											break;
										}
										break;
									}
									break;
								}
								case "Sensor":
								{
									string right3 = xmlNode2.Name.Split('_')[1];
									Sensor[] sensors_ReadOnly2 = activeUnit_0.Sensors_ReadOnly();
									Sensor[] array4 = sensors_ReadOnly2;
									foreach (Sensor sensor2 in array4)
									{
										if (Operators.CompareString(sensor2.ObjectID, right3, TextCompare: false) != 0)
										{
											continue;
										}
										PlatformComponent._ComponentStatus componentStatus3 = PlatformComponent._ComponentStatus.Operational;
										PlatformComponent._DamageSeverityFactor damageSeverityFactor3 = PlatformComponent._DamageSeverityFactor.Light;
										if (xmlNode2.SelectSingleNode("Severity") != null)
										{
											damageSeverityFactor3 = (PlatformComponent._DamageSeverityFactor)Conversions.ToByte(xmlNode2.SelectSingleNode("Severity").InnerText);
											if (sensor2.DamageSeverity == damageSeverityFactor3)
											{
												damageSeverityFactor3 = PlatformComponent._DamageSeverityFactor.Light;
											}
											else
											{
												sensor2.Damage(damageSeverityFactor3);
											}
										}
										if (xmlNode2.SelectSingleNode("Status") == null)
										{
											continue;
										}
										componentStatus3 = (PlatformComponent._ComponentStatus)Conversions.ToByte(xmlNode2.SelectSingleNode("Status").InnerText);
										if (sensor2.Status == componentStatus3)
										{
											break;
										}
										switch (componentStatus3)
										{
										case PlatformComponent._ComponentStatus.Operational:
											sensor2.Repair();
											break;
										case PlatformComponent._ComponentStatus.Damaged:
											if (damageSeverityFactor3 == PlatformComponent._DamageSeverityFactor.Light)
											{
												sensor2.Damage(sensor2.DamageSeverity);
											}
											break;
										case PlatformComponent._ComponentStatus.Destroyed:
											sensor2.Destroy(activeUnit_0.GetUnitSide(), bool_0: true, bool_1: false);
											break;
										}
										break;
									}
									break;
								}
								case "AirFacility":
								{
									string right = xmlNode2.Name.Split('_')[1];
									AirFacility[] airFacilities_ReadOnly = activeUnit_0.AirFacilities_ReadOnly;
									AirFacility[] array2 = airFacilities_ReadOnly;
									foreach (AirFacility airFacility in array2)
									{
										if (Operators.CompareString(airFacility.ObjectID, right, TextCompare: false) != 0)
										{
											continue;
										}
										PlatformComponent._ComponentStatus componentStatus = PlatformComponent._ComponentStatus.Operational;
										PlatformComponent._DamageSeverityFactor damageSeverityFactor = PlatformComponent._DamageSeverityFactor.Light;
										if (xmlNode2.SelectSingleNode("Severity") != null)
										{
											damageSeverityFactor = (PlatformComponent._DamageSeverityFactor)Conversions.ToByte(xmlNode2.SelectSingleNode("Severity").InnerText);
											if (airFacility.DamageSeverity == damageSeverityFactor)
											{
												damageSeverityFactor = PlatformComponent._DamageSeverityFactor.Light;
											}
											else
											{
												airFacility.Damage(damageSeverityFactor);
											}
										}
										if (xmlNode2.SelectSingleNode("Status") == null)
										{
											continue;
										}
										componentStatus = (PlatformComponent._ComponentStatus)Conversions.ToByte(xmlNode2.SelectSingleNode("Status").InnerText);
										if (airFacility.Status == componentStatus)
										{
											break;
										}
										switch (componentStatus)
										{
										case PlatformComponent._ComponentStatus.Operational:
											airFacility.Repair();
											break;
										case PlatformComponent._ComponentStatus.Damaged:
											if (damageSeverityFactor == PlatformComponent._DamageSeverityFactor.Light)
											{
												airFacility.Damage(airFacility.DamageSeverity);
											}
											break;
										case PlatformComponent._ComponentStatus.Destroyed:
											airFacility.Destroy(activeUnit_0.GetUnitSide(), bool_0: true, bool_1: false);
											break;
										}
										break;
									}
									break;
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
					case "MagAdd":
					{
						int num4 = Conversions.ToInteger(xmlNode.Name.Split('_')[1]);
						if (num4 > 0)
						{
							string string_4 = "SELECT Name from DataMagazine where ID = " + Conversions.ToString(num4);
							if (DBCache.GetDatatable(sqliteHelper_, string_4).Rows.Count == 0)
							{
								text7 = "错误：带有DBID的弹药库" + Conversions.ToString(num4) + "不能添加，也不能在数据库中找到！";
								StreamWriter streamWriter14 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter14.Write("\r\n    " + text7);
								streamWriter14.Close();
								int_0++;
							}
							else
							{
								Magazine magazine = DBFunctions.GetMagazine(num4, ref scenario_0);
								((Platform)activeUnit_0).AddSharedMagazine(magazine);
								magazine.ParentPlatform = activeUnit_0;
								text7 = "添加弹药库，DBID：" + Conversions.ToString(num4) + " 名称 " + magazine.Name;
								StreamWriter streamWriter15 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter15.Write("\r\n    " + text7);
								streamWriter15.Close();
							}
						}
						break;
					}
					case "Mount":
					{
						int num23 = Conversions.ToInteger(xmlNode.Name.Split('_')[1]);
						int num25;
						try
						{
							num25 = Conversions.ToInteger(xmlNode.Name.Split('_')[2]);
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							num25 = 0;
							if (num23 != 0)
							{
								text7 = "错误：挂载索引" + Conversions.ToString(num23) + " HAS NO DBID LISTED (Example: <Mount_<MountIndex>_<MountDBID>> ). THIS MAY CAUSE THE WRONG MOUNT TO BE UPDATED IN CASE A DATABASE UPDATE ALTERS THE MOUNT INDEX!";
								StreamWriter streamWriter45 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter45.Write("\r\n    " + text7);
								streamWriter45.Close();
								int_0++;
							}
							ProjectData.ClearProjectError();
						}
						try
						{
							if (num23 == 0)
							{
								int num26 = 0;
								text7 = "更新所有相关挂架：";
								StreamWriter streamWriter56 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter56.Write("\r\n    " + text7);
								streamWriter56.Close();
								foreach (Mount mount4 in activeUnit_0.Mounts)
								{
									Mount mount_ = mount4;
									int num27 = InstantiateWriter(scenario_0, ref mount_, xmlNode, num23);
									num26 += num27;
								}
								if (num26 == 0)
								{
									text7 = "错误：试图更新所有相关的挂架，可能无法找到任何更新！";
									StreamWriter streamWriter67 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter67.Write("\r\n      " + text7);
									streamWriter67.Close();
									int_0++;
								}
							}
							else if (activeUnit_0.Mounts[num23 - 1].DBID != num25 && num25 != 0)
							{
								text7 = "错误：挂载索引" + Conversions.ToString(num23) + "不匹配DBID" + Conversions.ToString(num25) + "！数据库更新可能会更改安装索引，您需要将安装索引更改为正确值！";
								StreamWriter streamWriter71 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter71.Write("\r\n    " + text7);
								streamWriter71.Close();
								int_0++;
							}
							else
							{
								Scenario scenario_ = scenario_0;
								ObservableList<Mount> mounts;
								int index;
								Mount mount_2 = (mounts = activeUnit_0.Mounts)[index = num23 - 1];
								InstantiateWriter(scenario_, ref mount_2, xmlNode, num23);
								mounts[index] = mount_2;
							}
						}
						catch (Exception projectError12)
						{
							ProjectData.SetProjectError(projectError12);
							text7 = "错误：挂载索引" + Conversions.ToString(num23) + "不存在单元！";
							StreamWriter streamWriter72 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter72.Write("\r\n    " + text7);
							streamWriter72.Close();
							int_0++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "CustomOODA":
					{
						short result = 0;
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode obj2 = (XmlNode)enumerator2.Current;
								text8 = obj2.Name;
								if (short.TryParse(obj2.InnerText, out result))
								{
									switch (text8)
									{
									case "Targeting":
										activeUnit_0.HasCustomOODA = true;
										activeUnit_0._IndexerVal = result;
										break;
									case "Evasion":
										activeUnit_0.HasCustomOODA = true;
										activeUnit_0._ResolverVal = result;
										break;
									case "Detection":
										activeUnit_0.HasCustomOODA = true;
										activeUnit_0.m_TokenVal = result;
										break;
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
						break;
					}
					case "CargoAdd":
					{
						XmlNode xmlNode_ = xmlNode.FirstChild;
						ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_ = null;
						Local_theCargo = Cargo.FromXML(ref xmlNode_, ref concurrentDictionary_, scenario_0, activeUnit_0);
						if (bool_0)
						{
							Local_theCargo.ResetIDs();
						}
						if (activeUnit_0.OnboardCargo.FirstOrDefault((Cargo CARGO) => Operators.CompareString(CARGO.ObjectID, Local_theCargo.ObjectID, TextCompare: false) == 0) == null)
						{
							ArrayExtensions.Add(ref activeUnit_0.OnboardCargo, Local_theCargo);
							Local_theCargo.PostDeserializationHousekeeping_General(ref activeUnit_0.ParentScen, null, bool_0: false);
							text7 = "增加货物" + Local_theCargo.CargoObjectName;
							StreamWriter streamWriter5 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter5.Write("\r\n      " + text7);
							streamWriter5.Close();
						}
						break;
					}
					case "CommAdd":
					{
						int num21 = Conversions.ToInteger(xmlNode.Name.Split('_')[1]);
						if (num21 > 0)
						{
							string string_6 = "SELECT Name from DataComm where ID = " + Conversions.ToString(num21);
							if (DBCache.GetDatatable(sqliteHelper_, string_6).Rows.Count == 0)
							{
								text7 = "错误：COMMID与DBID" + Conversions.ToString(num21) + "不能添加，也不能在数据库中找到！";
								StreamWriter streamWriter46 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter46.Write("\r\n    " + text7);
								streamWriter46.Close();
								int_0++;
							}
							else
							{
								CommDevice commDevice2 = DBFunctions.GetCommDevice(num21, ref activeUnit_0);
								activeUnit_0.AddCommDevice(commDevice2);
								commDevice2.ParentPlatform = activeUnit_0;
								text7 = "添加了通讯设备，DBID：" + Conversions.ToString(num21) + " 名称: " + commDevice2.Name;
								StreamWriter streamWriter47 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter47.Write("\r\n    " + text7);
								streamWriter47.Close();
							}
						}
						break;
					}
					case "Mag":
					{
						int num10 = Conversions.ToInteger(xmlNode.Name.Split('_')[1]);
						int num11;
						try
						{
							num11 = Conversions.ToInteger(xmlNode.Name.Split('_')[2]);
						}
						catch (Exception projectError5)
						{
							ProjectData.SetProjectError(projectError5);
							num11 = 0;
							if (num10 != 0)
							{
								text7 = "错误：带索引的弹药库" + Conversions.ToString(num10) + " HAS NO DBID LISTED (Example: <Mag_<MagIndex>_<MagDBID>> ). THIS MAY CAUSE THE WRONG MAGAZINE TO BE UPDATED IN CASE A DATABASE UPDATE ALTERS THE MAGAZINE INDEX!";
								StreamWriter streamWriter27 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter27.Write("\r\n    " + text7);
								streamWriter27.Close();
								int_0++;
							}
							ProjectData.ClearProjectError();
						}
						try
						{
							if (num10 == 0)
							{
								int num13 = 0;
								text7 = "更新所有相关弹药库：";
								StreamWriter streamWriter28 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter28.Write("\r\n    " + text7);
								streamWriter28.Close();
								Magazine[] sharedMagazines2 = activeUnit_0.SharedMagazines;
								for (int i = 0; i < sharedMagazines2.Length; i = checked(i + 1))
								{
									Magazine magazine_ = sharedMagazines2[i];
									int num14 = CreateWriter(scenario_0, ref magazine_, xmlNode, num10, bool_0: false);
									num13 += num14;
								}
								if (num13 == 0)
								{
									text7 = "错误：可能无法找到任何更新的弹药库！";
									StreamWriter streamWriter29 = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter29.Write("\r\n      " + text7);
									streamWriter29.Close();
									int_0++;
								}
							}
							else if (activeUnit_0.SharedMagazines[num10 - 1].DBID != num11 && num11 != 0)
							{
								text7 = "错误：带索引的弹药库" + Conversions.ToString(num10) + "不匹配DBID" + Conversions.ToString(num11) + "！数据库更新可能会更改弹药库索引，您需要将安装索引更改为正确值！";
								StreamWriter streamWriter30 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter30.Write("\r\n    " + text7);
								streamWriter30.Close();
								int_0++;
							}
							else
							{
								CreateWriter(scenario_0, ref activeUnit_0.SharedMagazines[num10 - 1], xmlNode, num10, bool_0: false);
							}
						}
						catch (Exception projectError6)
						{
							ProjectData.SetProjectError(projectError6);
							text7 = "错误：带索引的弹药库" + Conversions.ToString(num10 - 1) + "不存在单元！";
							StreamWriter streamWriter31 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter31.Write("\r\n    " + text7);
							streamWriter31.Close();
							int_0++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "MCMRemove":
					{
						int num3 = Conversions.ToInteger(xmlNode.Name.Split('_')[1]);
						try
						{
							num = Conversions.ToInteger(xmlNode.Name.Split('_')[2]);
						}
						catch (Exception projectError18)
						{
							ProjectData.SetProjectError(projectError18);
							num = 0;
							if (num3 != 0)
							{
								text7 = "错误：传感器索引为" + Conversions.ToString(num3) + " HAS NO DBID LISTED (Example: <SensorRemove_<SensorIndex>_<SensorDBID> ). THIS MAY CAUSE THE WRONG SENSOR TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE SENSOR INDEX!";
								StreamWriter streamWriter10 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter10.Write("\r\n    " + text7);
								streamWriter10.Close();
								int_0++;
							}
							ProjectData.ClearProjectError();
						}
						if (num3 <= 0)
						{
							break;
						}
						try
						{
							if (num == activeUnit_0.MineCountermeasures[num3 - 1].DBID)
							{
								string name8 = activeUnit_0.MineCountermeasures[num3 - 1].Name;
								list.Add(new Tuple<string, int, int, string>(text8, num3, num, name8));
								break;
							}
							text7 = "错误：传感器索引为" + Conversions.ToString(num3) + " 的单元没有DBID " + Conversions.ToString(num);
							StreamWriter streamWriter11 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter11.Write("\r\n    " + text7);
							streamWriter11.Close();
							int_0++;
						}
						catch (Exception projectError19)
						{
							ProjectData.SetProjectError(projectError19);
							text7 = "错误：传感器索引为" + Conversions.ToString(num3) + "且DBID" + Conversions.ToString(num) + "不能删除，不能找到单元！";
							StreamWriter streamWriter13 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter13.Write("\r\n    " + text7);
							streamWriter13.Close();
							int_0++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "MagRemove":
					{
						int num28 = Conversions.ToInteger(xmlNode.Name.Split('_')[1]);
						int num29;
						try
						{
							num29 = Conversions.ToInteger(xmlNode.Name.Split('_')[2]);
						}
						catch (Exception projectError14)
						{
							ProjectData.SetProjectError(projectError14);
							num29 = 0;
							if (num28 != 0)
							{
								text7 = "错误：带索引的弹药库" + Conversions.ToString(num28) + " HAS NO DBID LISTED (Example: <MagRemove_<MagIndex>_<MagDBID> ). THIS MAY CAUSE THE WRONG MAGAZINE TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE MAGAZINE INDEX!";
								StreamWriter streamWriter2 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter2.Write("\r\n    " + text7);
								streamWriter2.Close();
								int_0++;
							}
							ProjectData.ClearProjectError();
						}
						if (num28 <= 0)
						{
							break;
						}
						try
						{
							if (activeUnit_0.SharedMagazines[num28 - 1].DBID == num29)
							{
								string name = activeUnit_0.SharedMagazines[num28 - 1].Name;
								list.Add(new Tuple<string, int, int, string>(text8, num28, num29, name));
								break;
							}
							text7 = "错误：弹药库索引" + Conversions.ToString(num28) + " 的单元没有DBID " + Conversions.ToString(num29);
							StreamWriter streamWriter3 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter3.Write("\r\n    " + text7);
							streamWriter3.Close();
							int_0++;
						}
						catch (Exception projectError15)
						{
							ProjectData.SetProjectError(projectError15);
							text7 = "错误：带索引的弹药库" + Conversions.ToString(num28) + "且DBID" + Conversions.ToString(num29) + "不能删除，不能找到单元！";
							StreamWriter streamWriter4 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter4.Write("\r\n    " + text7);
							streamWriter4.Close();
							int_0++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "DockRemove":
					{
						int num22 = Conversions.ToInteger(xmlNode.Name.Split('_')[1]);
						int num24;
						try
						{
							num24 = Conversions.ToInteger(xmlNode.Name.Split('_')[2]);
						}
						catch (Exception projectError11)
						{
							ProjectData.SetProjectError(projectError11);
							num24 = 0;
							if (num22 != 0)
							{
								text7 = "ERROR: DOCK FACILITY WITH INDEX " + Conversions.ToString(num22) + " HAS NO DBID LISTED (Example: <DockRemove_<Index>_<DBID> ). THIS MAY CAUSE THE WRONG FACILITY TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE INDEX!";
								StreamWriter streamWriter48 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter48.Write("\r\n    " + text7);
								streamWriter48.Close();
								int_0++;
							}
							ProjectData.ClearProjectError();
						}
						if (num22 <= 0)
						{
							break;
						}
						try
						{
							if (num24 == activeUnit_0.DockFacilities_ReadOnly[num22 - 1].DBID)
							{
								string name14 = activeUnit_0.DockFacilities_ReadOnly[num22 - 1].Name;
								list.Add(new Tuple<string, int, int, string>(text8, num22, num24, name14));
								break;
							}
							text7 = "ERROR: DOCK FACILITY WITH INDEX " + Conversions.ToString(num22) + " 的单元没有DBID " + Conversions.ToString(num24);
							StreamWriter streamWriter49 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter49.Write("\r\n    " + text7);
							streamWriter49.Close();
							int_0++;
						}
						catch (Exception projectError13)
						{
							ProjectData.SetProjectError(projectError13);
							text7 = "ERROR: DOCK FACILITY WITH INDEX " + Conversions.ToString(num22) + "且DBID" + Conversions.ToString(num24) + "不能删除，不能找到单元！";
							StreamWriter streamWriter50 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter50.Write("\r\n    " + text7);
							streamWriter50.Close();
							int_0++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "SetFuel":
					{
						float num7 = 0f;
						if (activeUnit_0.IsAircraft)
						{
							num7 = Conversions.ToSingle(xmlNode.Name.Split('_')[1].Replace(",", "."));
							((Aircraft)activeUnit_0).FuelCapacitySet(num7);
							text7 = "设置燃料：" + Conversions.ToString(num7);
							StreamWriter streamWriter19 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter19.Write("\r\n    " + text7);
							streamWriter19.Close();
						}
						else if (!activeUnit_0.IsFacility && (activeUnit_0.IsShip || activeUnit_0.IsSubmarine))
						{
							FuelRec._FuelType fuelType_ = (FuelRec._FuelType)Conversions.ToShort(xmlNode.Name.Split('_')[1].Replace(",", "."));
							num7 = Conversions.ToSingle(xmlNode.Name.Split('_')[2].Replace(",", "."));
							activeUnit_0.FuelCapacitySet(num7, fuelType_);
							text7 = "设置燃料：" + fuelType_.ToString() + "至" + Conversions.ToString(num7);
							StreamWriter streamWriter20 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter20.Write("\r\n    " + text7);
							streamWriter20.Close();
						}
						break;
					}
					case "SensorAdd":
					{
						num = Conversions.ToInteger(xmlNode.Name.Split('_')[1]);
						bool flag2 = false;
						bool flag3 = false;
						if (num <= 0)
						{
							break;
						}
						string string_7 = "SELECT Name from DataSensor where ID = " + Conversions.ToString(num);
						if (DBCache.GetDatatable(sqliteHelper_, string_7).Rows.Count == 0)
						{
							text7 = "错误：带有DBID的弹药库" + Conversions.ToString(num) + "不能添加，也不能在数据库中找到！";
							StreamWriter streamWriter51 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter51.Write("\r\n    " + text7);
							streamWriter51.Close();
							int_0++;
							break;
						}
						int int_ = num;
						SQLiteConnection sqliteConnection_3 = activeUnit_0.ParentScen.DBConnection;
						Sensor sensor4 = DBFunctions.GetSensor(int_, ref sqliteConnection_3);
						activeUnit_0.AddSensor(sensor4);
						sensor4.ParentPlatform = activeUnit_0;
						try
						{
							enumerator5 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator5.MoveNext())
							{
								XmlNode xmlNode_3 = (XmlNode)enumerator5.Current;
								switch (xmlNode_3.Name)
								{
								case "Cov_Ill":
								case "Coverage_Illuminate":
									sensor4.Coverage_Illuminate = PlatformComponent._Coverage.FromXML(ref xmlNode_3);
									flag3 = true;
									break;
								case "Cov":
								case "Coverage":
									sensor4.Coverage = PlatformComponent._Coverage.FromXML(ref xmlNode_3);
									flag2 = true;
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
						text7 = "添加传感器，DBID：" + Conversions.ToString(num) + " 名称: " + sensor4.Name;
						StreamWriter streamWriter52 = File.AppendText(GameGeneral.SBRLogFilePath);
						streamWriter52.Write("\r\n    " + text7);
						streamWriter52.Close();
						if (!flag2)
						{
							text7 = "错误：带有DBID的传感器" + Conversions.ToString(num) + "没有设置角度！";
							StreamWriter streamWriter53 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter53.Write("\r\n    " + text7);
							streamWriter53.Close();
							int_0++;
						}
						if (!flag3)
						{
							text7 = "错误：带有DBID的传感器" + Conversions.ToString(num) + "没有设置照射角度！";
							StreamWriter streamWriter54 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter54.Write("\r\n    " + text7);
							streamWriter54.Close();
							int_0++;
						}
						break;
					}
					case "MountRemove":
					{
						int num19 = Conversions.ToInteger(xmlNode.Name.Split('_')[1]);
						int num20;
						try
						{
							num20 = Conversions.ToInteger(xmlNode.Name.Split('_')[2]);
						}
						catch (Exception projectError9)
						{
							ProjectData.SetProjectError(projectError9);
							num20 = 0;
							if (num19 != 0)
							{
								text7 = "错误：挂载索引" + Conversions.ToString(num19) + " HAS NO DBID LISTED (Example: <MountRemove_<MountIndex>_<MountDBID> ). THIS MAY CAUSE THE WRONG MOUNT TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE MOUNT INDEX!";
								StreamWriter streamWriter42 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter42.Write("\r\n    " + text7);
								streamWriter42.Close();
								int_0++;
							}
							ProjectData.ClearProjectError();
						}
						if (num19 <= 0)
						{
							break;
						}
						try
						{
							if (activeUnit_0.Mounts[num19 - 1].DBID == num20)
							{
								string name13 = activeUnit_0.Mounts[num19 - 1].Name;
								list.Add(new Tuple<string, int, int, string>(text8, num19, num20, name13));
								break;
							}
							text7 = "错误：挂载索引" + Conversions.ToString(num19) + " 的单元没有DBID " + Conversions.ToString(num20);
							StreamWriter streamWriter43 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter43.Write("\r\n    " + text7);
							streamWriter43.Close();
							int_0++;
						}
						catch (Exception projectError10)
						{
							ProjectData.SetProjectError(projectError10);
							text7 = "错误：挂载索引" + Conversions.ToString(num19) + "且DBID" + Conversions.ToString(num20) + "不能删除，不能找到单元！";
							StreamWriter streamWriter44 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter44.Write("\r\n    " + text7);
							streamWriter44.Close();
							int_0++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "CommRemove":
					{
						int num15 = Conversions.ToInteger(xmlNode.Name.Split('_')[1]);
						int num16;
						try
						{
							num16 = Conversions.ToInteger(xmlNode.Name.Split('_')[2]);
						}
						catch (Exception projectError7)
						{
							ProjectData.SetProjectError(projectError7);
							num16 = 0;
							if (num15 != 0)
							{
								text7 = "错误：通信设备索引" + Conversions.ToString(num15) + " 没有在列出的DBID中 (例如: <CommRemove_<CommIndex>_<CommDBID>)，当数据库升级时如果修改了通信设备索引可能导致通信设备被删除。";
								StreamWriter streamWriter32 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter32.Write("\r\n    " + text7);
								streamWriter32.Close();
								int_0++;
							}
							ProjectData.ClearProjectError();
						}
						if (num15 <= 0)
						{
							break;
						}
						try
						{
							if (num16 == activeUnit_0.Comms_ReadOnly[num15 - 1].DBID)
							{
								string name11 = activeUnit_0.Comms_ReadOnly[num15 - 1].Name;
								list.Add(new Tuple<string, int, int, string>(text8, num15, num16, name11));
								break;
							}
							text7 = "错误：通信设备索引为" + Conversions.ToString(num15) + " 的单元没有DBID " + Conversions.ToString(num16);
							StreamWriter streamWriter33 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter33.Write("\r\n    " + text7);
							streamWriter33.Close();
							int_0++;
						}
						catch (Exception projectError8)
						{
							ProjectData.SetProjectError(projectError8);
							text7 = "错误：通信设备索引为" + Conversions.ToString(num15) + "且DBID" + Conversions.ToString(num16) + "不能删除，不能找到单元！";
							StreamWriter streamWriter35 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter35.Write("\r\n    " + text7);
							streamWriter35.Close();
							int_0++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "SensorRemove":
					{
						int num8 = Conversions.ToInteger(xmlNode.Name.Split('_')[1]);
						try
						{
							num = Conversions.ToInteger(xmlNode.Name.Split('_')[2]);
						}
						catch (Exception projectError3)
						{
							ProjectData.SetProjectError(projectError3);
							num = 0;
							if (num8 != 0)
							{
								text7 = "错误：传感器索引为" + Conversions.ToString(num8) + " HAS NO DBID LISTED (Example: <SensorRemove_<SensorIndex>_<SensorDBID> ). THIS MAY CAUSE THE WRONG SENSOR TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE SENSOR INDEX!";
								StreamWriter streamWriter22 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter22.Write("\r\n    " + text7);
								streamWriter22.Close();
								int_0++;
							}
							ProjectData.ClearProjectError();
						}
						if (num8 <= 0)
						{
							break;
						}
						try
						{
							if (num == activeUnit_0.Sensors_ReadOnly()[num8 - 1].DBID)
							{
								string name10 = activeUnit_0.Sensors_ReadOnly()[num8 - 1].Name;
								list.Add(new Tuple<string, int, int, string>(text8, num8, num, name10));
								break;
							}
							text7 = "错误：传感器索引为" + Conversions.ToString(num8) + " 的单元没有DBID " + Conversions.ToString(num);
							StreamWriter streamWriter24 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter24.Write("\r\n    " + text7);
							streamWriter24.Close();
							int_0++;
						}
						catch (Exception projectError4)
						{
							ProjectData.SetProjectError(projectError4);
							text7 = "错误：传感器索引为" + Conversions.ToString(num8) + "且DBID" + Conversions.ToString(num) + "不能删除，不能找到单元！";
							StreamWriter streamWriter25 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter25.Write("\r\n    " + text7);
							streamWriter25.Close();
							int_0++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "#comment":
					{
						text7 = xmlNode.InnerText;
						StreamWriter streamWriter21 = File.AppendText(GameGeneral.SBRLogFilePath);
						streamWriter21.Write("  --  " + text7);
						streamWriter21.Close();
						break;
					}
					case "AirOpsRemove":
					{
						int num5 = Conversions.ToInteger(xmlNode.Name.Split('_')[1]);
						int num6;
						try
						{
							num6 = Conversions.ToInteger(xmlNode.Name.Split('_')[2]);
						}
						catch (Exception projectError20)
						{
							ProjectData.SetProjectError(projectError20);
							num6 = 0;
							if (num5 != 0)
							{
								text7 = "ERROR: AIR FACILITY WITH INDEX " + Conversions.ToString(num5) + " HAS NO DBID LISTED (Example: <AirOpsRemove_<Index>_<DBID> ). THIS MAY CAUSE THE WRONG FACILITY TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE INDEX!";
								StreamWriter streamWriter16 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter16.Write("\r\n    " + text7);
								streamWriter16.Close();
								int_0++;
							}
							ProjectData.ClearProjectError();
						}
						if (num5 <= 0)
						{
							break;
						}
						try
						{
							if (num6 == activeUnit_0.AirFacilities_ReadOnly[num5 - 1].DBID)
							{
								string name9 = activeUnit_0.AirFacilities_ReadOnly[num5 - 1].Name;
								list.Add(new Tuple<string, int, int, string>(text8, num5, num6, name9));
								break;
							}
							text7 = "ERROR: AIR FACILITY WITH INDEX " + Conversions.ToString(num5) + " 的单元没有DBID " + Conversions.ToString(num6);
							StreamWriter streamWriter17 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter17.Write("\r\n    " + text7);
							streamWriter17.Close();
							int_0++;
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							text7 = "ERROR: AIR FACILITY WITH INDEX " + Conversions.ToString(num5) + "且DBID" + Conversions.ToString(num6) + "不能删除，不能找到单元！";
							StreamWriter streamWriter18 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter18.Write("\r\n    " + text7);
							streamWriter18.Close();
							int_0++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "SensorMountRemove":
					{
						int num30 = Conversions.ToInteger(xmlNode.Name.Split('_')[1]);
						int num2;
						try
						{
							num2 = Conversions.ToInteger(xmlNode.Name.Split('_')[2]);
							num = Conversions.ToInteger(xmlNode.Name.Split('_')[3]);
						}
						catch (Exception projectError16)
						{
							ProjectData.SetProjectError(projectError16);
							num2 = 0;
							if (num30 != 0)
							{
								text7 = "错误：挂载索引" + Conversions.ToString(num30) + " HAS NO DBID LISTED (Example: <MountRemove_<MountIndex>_<MountDBID> ). THIS MAY CAUSE THE WRONG MOUNT TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE MOUNT INDEX!";
								StreamWriter streamWriter6 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter6.Write("\r\n    " + text7);
								streamWriter6.Close();
								int_0++;
							}
							ProjectData.ClearProjectError();
						}
						if (num30 <= 0)
						{
							break;
						}
						try
						{
							if (activeUnit_0.Mounts[num30 - 1].DBID == num2)
							{
								Mount mount = activeUnit_0.Mounts[num30 - 1];
								_ = mount.Name;
								if (mount.Sensors_ReadOnly.Count() <= 0)
								{
									break;
								}
								Sensor[] sensors_ReadOnly = mount.Sensors_ReadOnly;
								Sensor[] array = sensors_ReadOnly;
								foreach (Sensor sensor in array)
								{
									if (sensor.DBID == num)
									{
										mount.RemoveSensor(sensor);
										text7 = "Removed sensor from mount (" + mount.Name + "), DBID: " + Conversions.ToString(num) + " 名称: " + sensor.Name;
										StreamWriter streamWriter7 = File.AppendText(GameGeneral.SBRLogFilePath);
										streamWriter7.Write("\r\n    " + text7);
										streamWriter7.Close();
										break;
									}
								}
								break;
							}
							text7 = "错误：挂载索引" + Conversions.ToString(num30) + " 的单元没有DBID " + Conversions.ToString(num2);
							StreamWriter streamWriter8 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter8.Write("\r\n    " + text7);
							streamWriter8.Close();
							int_0++;
						}
						catch (Exception projectError17)
						{
							ProjectData.SetProjectError(projectError17);
							text7 = "错误：挂载索引" + Conversions.ToString(num30) + "且DBID" + Conversions.ToString(num2) + "不能删除，不能找到单元！";
							StreamWriter streamWriter9 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter9.Write("\r\n    " + text7);
							streamWriter9.Close();
							int_0++;
							ProjectData.ClearProjectError();
						}
						break;
					}
					case "DockAdd":
					{
						int num12 = Conversions.ToInteger(xmlNode.Name.Split('_')[1]);
						if (num12 > 0)
						{
							SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
							DockFacility dockFacility = DBFunctions.GetDockFacility(num12, ref sqliteConnection_);
							if (dockFacility == null)
							{
								text7 = "ERROR: DOCK FACILITY WITH DBID " + Conversions.ToString(num12) + "不能添加，也不能在数据库中找到！";
								StreamWriter streamWriter23 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter23.Write("\r\n    " + text7);
								streamWriter23.Close();
							}
							else
							{
								activeUnit_0.AddDockFacility(dockFacility);
								dockFacility.ParentPlatform = activeUnit_0;
								text7 = "Added dock facility, DBID: " + Conversions.ToString(num12) + " 名称: " + dockFacility.Name;
								StreamWriter streamWriter34 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter34.Write("\r\n    " + text7);
								streamWriter34.Close();
							}
						}
						break;
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
			if (list.Count <= 0)
			{
				return;
			}
			{
				foreach (Tuple<string, int, int, string> item8 in list)
				{
					switch (item8.Item1)
					{
					case "MagRemove":
					{
						int item10 = item8.Item2;
						int item11 = item8.Item3;
						if (item10 > 0)
						{
							if (activeUnit_0.SharedMagazines[item10 - 1].DBID == item11)
							{
								string name2 = activeUnit_0.SharedMagazines[item10 - 1].Name;
								((Platform)activeUnit_0).RemoveSharedMagazine(activeUnit_0.SharedMagazines[item10 - 1]);
								text7 = "用索引删除了Mag" + Conversions.ToString(item10) + "，DBID：" + Conversions.ToString(item11) + " 名称: " + name2;
								StreamWriter streamWriter58 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter58.Write("\r\n    " + text7);
								streamWriter58.Close();
							}
							else
							{
								text7 = "错误：弹药库索引" + Conversions.ToString(item10) + " 的单元没有DBID " + Conversions.ToString(item11);
								StreamWriter streamWriter59 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter59.Write("\r\n    " + text7);
								streamWriter59.Close();
								int_0++;
							}
						}
						break;
					}
					case "DockRemove":
					{
						int item14 = item8.Item2;
						int item15 = item8.Item3;
						if (item14 > 0)
						{
							if (item15 == activeUnit_0.DockFacilities_ReadOnly[item14 - 1].DBID)
							{
								string name4 = activeUnit_0.DockFacilities_ReadOnly[item14 - 1].Name;
								activeUnit_0.RemoveDockFacility(activeUnit_0.DockFacilities_ReadOnly[item14 - 1]);
								text7 = "Removed Dock Facility with index " + Conversions.ToString(item14) + "，DBID：" + Conversions.ToString(item15) + " 名称: " + name4;
								StreamWriter streamWriter61 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter61.Write("\r\n    " + text7);
								streamWriter61.Close();
							}
							else
							{
								text7 = "ERROR: DOCK FACILITY WITH INDEX " + Conversions.ToString(item14) + " 的单元没有DBID " + Conversions.ToString(item15);
								StreamWriter streamWriter62 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter62.Write("\r\n    " + text7);
								streamWriter62.Close();
								int_0++;
							}
						}
						break;
					}
					case "MCMRemove":
					{
						int item5 = item8.Item2;
						int item6 = item8.Item3;
						if (item5 > 0)
						{
							if (item6 == activeUnit_0.MineCountermeasures[item5 - 1].DBID)
							{
								string name7 = activeUnit_0.MineCountermeasures[item5 - 1].Name;
								activeUnit_0.RemoveSensor(activeUnit_0.MineCountermeasures[item5 - 1]);
								text7 = "Removed MCM Sensor with index " + Conversions.ToString(item5) + "，DBID：" + Conversions.ToString(item6) + " 名称: " + name7;
								StreamWriter streamWriter68 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter68.Write("\r\n    " + text7);
								streamWriter68.Close();
							}
							else
							{
								text7 = "错误：传感器索引为" + Conversions.ToString(item5) + " 的单元没有DBID " + Conversions.ToString(item6);
								StreamWriter streamWriter69 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter69.Write("\r\n    " + text7);
								streamWriter69.Close();
								int_0++;
							}
						}
						break;
					}
					case "SensorRemove":
					{
						int item3 = item8.Item2;
						int item4 = item8.Item3;
						if (item3 > 0)
						{
							if (item4 == activeUnit_0.Sensors_ReadOnly()[item3 - 1].DBID)
							{
								string name6 = activeUnit_0.Sensors_ReadOnly()[item3 - 1].Name;
								activeUnit_0.RemoveSensor(activeUnit_0.Sensors_ReadOnly()[item3 - 1]);
								text7 = "删除了传感器索引为" + Conversions.ToString(item3) + "，DBID：" + Conversions.ToString(item4) + " 名称: " + name6;
								StreamWriter streamWriter65 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter65.Write("\r\n    " + text7);
								streamWriter65.Close();
							}
							else
							{
								text7 = "错误：传感器索引为" + Conversions.ToString(item3) + " 的单元没有DBID " + Conversions.ToString(item4);
								StreamWriter streamWriter66 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter66.Write("\r\n    " + text7);
								streamWriter66.Close();
								int_0++;
							}
						}
						break;
					}
					case "MountRemove":
					{
						int item12 = item8.Item2;
						int item13 = item8.Item3;
						if (item12 > 0)
						{
							string name3 = activeUnit_0.Mounts[item12 - 1].Name;
							activeUnit_0.Mounts.Remove(activeUnit_0.Mounts[item12 - 1]);
							text7 = "删除了带索引的挂载" + Conversions.ToString(item12) + "，DBID：" + Conversions.ToString(item13) + " 名称: " + name3;
							StreamWriter streamWriter60 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter60.Write("\r\n    " + text7);
							streamWriter60.Close();
						}
						break;
					}
					case "AirOpsRemove":
					{
						int item16 = item8.Item2;
						int item2 = item8.Item3;
						if (item16 > 0)
						{
							if (item2 == activeUnit_0.AirFacilities_ReadOnly[item16 - 1].DBID)
							{
								string name5 = activeUnit_0.AirFacilities_ReadOnly[item16 - 1].Name;
								activeUnit_0.RemoveAirFacility(activeUnit_0.AirFacilities_ReadOnly[item16 - 1]);
								text7 = "Removed Air Facility with index " + Conversions.ToString(item16) + "，DBID：" + Conversions.ToString(item2) + " 名称: " + name5;
								StreamWriter streamWriter63 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter63.Write("\r\n    " + text7);
								streamWriter63.Close();
							}
							else
							{
								text7 = "ERROR: AIR FACILITY WITH INDEX " + Conversions.ToString(item16) + " 的单元没有DBID " + Conversions.ToString(item2);
								StreamWriter streamWriter64 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter64.Write("\r\n    " + text7);
								streamWriter64.Close();
								int_0++;
							}
						}
						break;
					}
					case "CommRemove":
					{
						int item = item8.Item2;
						int item9 = item8.Item3;
						if (item > 0)
						{
							if (item9 == activeUnit_0.Comms_ReadOnly[item - 1].DBID)
							{
								string name15 = activeUnit_0.Comms_ReadOnly[item - 1].Name;
								activeUnit_0.RemoveCommDevice(activeUnit_0.Comms_ReadOnly[item - 1]);
								text7 = "删除了通信设备索引为" + Conversions.ToString(item) + "，DBID：" + Conversions.ToString(item9) + " 名称: " + name15;
								StreamWriter streamWriter55 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter55.Write("\r\n    " + text7);
								streamWriter55.Close();
							}
							else
							{
								text7 = "错误：通信设备索引为" + Conversions.ToString(item) + " 的单元没有DBID " + Conversions.ToString(item9);
								StreamWriter streamWriter57 = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter57.Write("\r\n    " + text7);
								streamWriter57.Close();
								int_0++;
							}
						}
						break;
					}
					}
				}
				return;
			}
		}
		text7 = "错误：没有单元DBID为" + Conversions.ToString(activeUnit_0.DBID) + " FOUND IN DATABASE!\r\n";
		StreamWriter streamWriter70 = File.AppendText(GameGeneral.SBRLogFilePath);
		streamWriter70.Write("\r\n  " + text7);
		streamWriter70.Close();
		int_0++;
	}

	public static void ApplyScriptToScenario(Scenario scenario_0, string string_0, bool bool_0, Stream stream_0 = null)
	{
		if (stream_0 == null)
		{
			stream_0 = new FileStream(string_0, FileMode.Open, FileAccess.Read);
		}
		int int_ = 0;
		XmlDocument xmlDocument = new XmlDocument();
		try
		{
			using (stream_0)
			{
				try
				{
					xmlDocument.Load(stream_0);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					GameGeneral.ResolveBridge("XML文件" + string_0 + "格式不正确，读取失败！", null);
					ProjectData.ClearProjectError();
				}
			}
			XmlNode xmlNode = xmlDocument.SelectSingleNode("/ScenarioUnits");
			if (xmlNode != null)
			{
				string value = "\r\nPlatform list: \r\n  DBID -- Unit name  ----  Class Info  ----  ObjectID";
				StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
				streamWriter.Write(value);
				streamWriter.Close();
				XmlNodeList childNodes = xmlNode.ChildNodes;
				IEnumerator enumerator = null;
				try
				{
					enumerator = childNodes.GetEnumerator();
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode2 = (XmlNode)enumerator.Current;
						string text = xmlNode2.Name.Split('_')[1];
						ActiveUnit activeUnit = scenario_0.ActiveUnits[text];
						if (activeUnit == null)
						{
							value = "错误：单元#" + text + "在想定中不存在！";
							StreamWriter streamWriter2 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter2.Write("\r\n  " + value);
							streamWriter2.Close();
						}
						else
						{
							ApplyDeltaToThisUnit(xmlNode2, activeUnit, scenario_0, null, null, bool_0, ref int_);
						}
					}
					return;
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
			}
			string text2 = "错误：找不到INI配置文件！";
			StreamWriter streamWriter3 = File.AppendText(GameGeneral.SBRLogFilePath);
			streamWriter3.Write("\r\n  " + text2);
			streamWriter3.Close();
			GameGeneral.ResolveBridge("找不到XML数据。", null);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101118", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void GenerateScenarioContentsList(Scenario scenario_0)
	{
		HashSet<string> hashSet = new HashSet<string>();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		try
		{
			string value = "\r\nPlatform list: \r\n  DBID -- Unit name  ----  Class Info  ----  ObjectID\r\n";
			StreamWriter streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt");
			streamWriter.Write(value);
			streamWriter.Close();
			string string_ = null;
			string string_2 = null;
			string string_3 = null;
			foreach (ActiveUnit value2 in scenario_0.ActiveUnits.Values)
			{
				SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
				switch (value2.UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					string_ = "Select YearCommissioned, YearDecommissioned from DataAircraft where ID = " + Conversions.ToString(value2.DBID);
					string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataAircraft where ID = " + Conversions.ToString(value2.DBID) + ")";
					string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataAircraft where ID = " + Conversions.ToString(value2.DBID) + ")";
					break;
				case GlobalVariables.ActiveUnitType.Ship:
					string_ = "Select YearCommissioned, YearDecommissioned from DataShip where ID = " + Conversions.ToString(value2.DBID);
					string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataShip where ID = " + Conversions.ToString(value2.DBID) + ")";
					string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataShip where ID = " + Conversions.ToString(value2.DBID) + ")";
					break;
				case GlobalVariables.ActiveUnitType.Submarine:
					string_ = "Select YearCommissioned, YearDecommissioned from DataSubmarine where ID = " + Conversions.ToString(value2.DBID);
					string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataSubmarine where ID = " + Conversions.ToString(value2.DBID) + ")";
					string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataSubmarine where ID = " + Conversions.ToString(value2.DBID) + ")";
					break;
				case GlobalVariables.ActiveUnitType.Facility:
					string_ = "Select YearCommissioned, YearDecommissioned from DataFacility where ID = " + Conversions.ToString(value2.DBID);
					string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataFacility where ID = " + Conversions.ToString(value2.DBID) + ")";
					string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataFacility where ID = " + Conversions.ToString(value2.DBID) + ")";
					break;
				case GlobalVariables.ActiveUnitType.Satellite:
					string_ = "Select YearCommissioned, YearDecommissioned from DataSatellite where ID = " + Conversions.ToString(value2.DBID);
					string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataSatellite where ID = " + Conversions.ToString(value2.DBID) + ")";
					string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataSatellite where ID = " + Conversions.ToString(value2.DBID) + ")";
					break;
				case GlobalVariables.ActiveUnitType.Vehicle:
					string_ = "Select YearCommissioned, YearDecommissioned from DataGroundUnit where ID = " + Conversions.ToString(value2.DBID);
					string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataGroundUnit where ID = " + Conversions.ToString(value2.DBID) + ")";
					string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataGroundUnit where ID = " + Conversions.ToString(value2.DBID) + ")";
					break;
				}
				if (!(value2.IsAircraft | value2.IsFacility | value2.IsShip | value2.IsSubmarine | value2.IsSatellite))
				{
					continue;
				}
				DataTable datatable = DBCache.GetDatatable(sqliteHelper_, string_);
				DataTable datatable2 = DBCache.GetDatatable(sqliteHelper_, string_2);
				DataTable datatable3 = DBCache.GetDatatable(sqliteHelper_, string_3);
				if ((datatable.Rows.Count != 0) & (datatable2.Rows.Count != 0) & (datatable3.Rows.Count != 0))
				{
					DataRow dataRow = datatable.Rows[0];
					DataRow dataRow2 = datatable2.Rows[0];
					DataRow dataRow3 = datatable3.Rows[0];
					string text = Strings.Trim(dataRow2["Description"].ToString());
					string text2 = Strings.Trim(dataRow3["Description"].ToString());
					string text3 = Conversions.ToString(Conversions.ToInteger(dataRow["YearCommissioned"].ToString()));
					string text4 = Conversions.ToString(Conversions.ToInteger(dataRow["YearDecommissioned"].ToString()));
					if (value2.IsOperating())
					{
						if (!hashSet.Contains(value2.ObjectID))
						{
							hashSet.Add(value2.ObjectID);
						}
						if (value2.IsAircraft)
						{
							Aircraft aircraft = (Aircraft)value2;
							value = "  " + Conversions.ToString(aircraft.DBID) + " -- " + aircraft.Name + " -- " + aircraft.UnitClass + " -- " + text + " (" + text2 + "), " + text3 + "-" + text4 + " : " + Conversions.ToString(aircraft.Int32_0) + " -- " + aircraft.LoadoutName + "  ----  " + aircraft.ObjectID + "\r\n";
						}
						else
						{
							value = "  " + Conversions.ToString(value2.DBID) + " -- " + value2.Name + "  ----  " + value2.UnitClass + " -- " + text + " (" + text2 + "), " + text3 + "-" + text4 + "  ----  " + value2.ObjectID + "\r\n";
						}
						streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt");
						streamWriter.Write(value);
						streamWriter.Close();
						try
						{
							AirFacility[] airFacilities_ReadOnly = value2.AirFacilities_ReadOnly;
							for (int j = 0; j < airFacilities_ReadOnly.Length; j++)
							{
								foreach (Aircraft value3 in airFacilities_ReadOnly[j].HostedAircraft.Values)
								{
									string_ = "Select YearCommissioned, YearDecommissioned from DataAircraft where ID = " + Conversions.ToString(value3.DBID);
									string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataAircraft where ID = " + Conversions.ToString(value3.DBID) + ")";
									string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataAircraft where ID = " + Conversions.ToString(value3.DBID) + ")";
									datatable = DBCache.GetDatatable(sqliteHelper_, string_);
									datatable2 = DBCache.GetDatatable(sqliteHelper_, string_2);
									datatable3 = DBCache.GetDatatable(sqliteHelper_, string_3);
									if ((datatable.Rows.Count != 0) & (datatable2.Rows.Count != 0) & (datatable3.Rows.Count != 0))
									{
										DataRow dataRow4 = datatable.Rows[0];
										DataRow dataRow5 = datatable2.Rows[0];
										DataRow dataRow6 = datatable3.Rows[0];
										text = Strings.Trim(dataRow5["Description"].ToString());
										text2 = Strings.Trim(dataRow6["Description"].ToString());
										text3 = dataRow4["YearCommissioned"].ToString();
										text4 = dataRow4["YearDecommissioned"].ToString();
										if (!hashSet.Contains(value3.ObjectID))
										{
											hashSet.Add(value3.ObjectID);
										}
										value = "    " + Conversions.ToString(value3.DBID) + " -- " + value3.UnitClass + " -- " + text + " (" + text2 + "), " + text3 + "-" + text4 + " : " + Conversions.ToString(value3.Int32_0) + " -- " + value3.LoadoutName + "  ----  " + value3.Name + "  ----  " + value3.ObjectID + "\r\n";
										streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt");
										streamWriter.Write(value);
										streamWriter.Close();
										continue;
									}
									value = "错误：没有飞机ID为" + Conversions.ToString(value3.DBID) + "基于" + value2.Name + " (" + value2.UnitClass + ") WAS FOUND IN DATABASE!\r\n";
									streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter.Write("\r\n  " + value);
									streamWriter.Close();
									return;
								}
							}
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception exception_ = ex;
							exception_?.Data.Add("Error at 200097", exception_.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						try
						{
							DockFacility[] dockFacilities_ReadOnly = value2.DockFacilities_ReadOnly;
							for (int i = 0; i < dockFacilities_ReadOnly.Length; i++)
							{
								foreach (ActiveUnit value4 in dockFacilities_ReadOnly[i].HostedBoats.Values)
								{
									switch (value4.UnitType)
									{
									case GlobalVariables.ActiveUnitType.Submarine:
										string_ = "Select YearCommissioned, YearDecommissioned from DataSubmarine where ID = " + Conversions.ToString(value4.DBID);
										string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataSubmarine where ID = " + Conversions.ToString(value4.DBID) + ")";
										string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataSubmarine where ID = " + Conversions.ToString(value4.DBID) + ")";
										break;
									case GlobalVariables.ActiveUnitType.Ship:
										string_ = "Select YearCommissioned, YearDecommissioned from DataShip where ID = " + Conversions.ToString(value4.DBID);
										string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataShip where ID = " + Conversions.ToString(value4.DBID) + ")";
										string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataShip where ID = " + Conversions.ToString(value4.DBID) + ")";
										break;
									}
									datatable = DBCache.GetDatatable(sqliteHelper_, string_);
									datatable2 = DBCache.GetDatatable(sqliteHelper_, string_2);
									datatable3 = DBCache.GetDatatable(sqliteHelper_, string_3);
									if ((datatable.Rows.Count != 0) & (datatable2.Rows.Count != 0) & (datatable3.Rows.Count != 0))
									{
										DataRow dataRow7 = datatable.Rows[0];
										DataRow dataRow8 = datatable2.Rows[0];
										DataRow dataRow9 = datatable3.Rows[0];
										text = Strings.Trim(dataRow8["Description"].ToString());
										text2 = Strings.Trim(dataRow9["Description"].ToString());
										text3 = Conversions.ToString(Conversions.ToInteger(dataRow7["YearCommissioned"].ToString()));
										text4 = Conversions.ToString(Conversions.ToInteger(dataRow7["YearDecommissioned"].ToString()));
										if (!hashSet.Contains(value4.ObjectID))
										{
											hashSet.Add(value4.ObjectID);
										}
										value = "    " + Conversions.ToString(value4.DBID) + " -- " + value4.Name + " -- " + text + " (" + text2 + "), " + text3 + "-" + text4 + "  ----  " + value4.UnitClass + "  ----  " + value4.ObjectID + "\r\n";
										streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt");
										streamWriter.Write(value);
										streamWriter.Close();
										continue;
									}
									value = "错误：没有船只ID为" + Conversions.ToString(value4.DBID) + "基于" + value2.Name + " (" + value2.UnitClass + ") WAS FOUND IN DATABASE!\r\n";
									streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
									streamWriter.Write("\r\n  " + value);
									streamWriter.Close();
									return;
								}
							}
						}
						catch (Exception ex2)
						{
							ProjectData.SetProjectError(ex2);
							Exception exception_2 = ex2;
							exception_2?.Data.Add("Error at 200098", exception_2.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_2);
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						if (value2.IsAircraft)
						{
							Aircraft aircraft2 = (Aircraft)value2;
							value = "  " + Conversions.ToString(aircraft2.DBID) + " -- " + aircraft2.Name + " -- " + aircraft2.UnitClass + " -- " + text + " (" + text2 + "), " + text3 + "-" + text4 + " : " + Conversions.ToString(aircraft2.Int32_0) + " -- " + aircraft2.LoadoutName + "  ----  " + aircraft2.ObjectID + "\r\n";
						}
						else
						{
							value = "  " + Conversions.ToString(value2.DBID) + " -- " + value2.Name + "  ----  " + value2.UnitClass + " -- " + text + " (" + text2 + "), " + text3 + "-" + text4 + "  ----  " + value2.ObjectID + "\r\n";
						}
						dictionary.Add(value2.ObjectID, value);
					}
					continue;
				}
				value = "错误：没有单元ID为" + Conversions.ToString(value2.DBID) + " FOUND IN DATABASE!\r\n";
				streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
				streamWriter.Write("\r\n  " + value);
				streamWriter.Close();
				return;
			}
			streamWriter = File.AppendText(MerchantMerchantPage.LogoutList.Info.DirectoryPath + Conversions.ToString(Path.DirectorySeparatorChar) + "Logs" + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt");
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				if (!hashSet.Contains(item.Key))
				{
					streamWriter.Write(item.Value);
				}
			}
			streamWriter.Close();
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 101119", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void ApplyEMCON_ToScenario(ref Scenario scenario_0)
	{
		foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
		{
			if (activeUnits_ != null)
			{
				if (activeUnits_.IsAircraft)
				{
					((Aircraft)activeUnits_).Sensory.vmethod_0(activeUnits_.Sensors_Cached);
				}
				else if (activeUnits_.IsFacility)
				{
					((Facility)activeUnits_).Sensory.vmethod_0(activeUnits_.Sensors_Cached);
				}
				else if (activeUnits_.IsShip)
				{
					((Ship)activeUnits_).Sensory.vmethod_0(activeUnits_.Sensors_Cached);
				}
				else if (activeUnits_.IsSubmarine)
				{
					((Submarine)activeUnits_).Sensory.vmethod_0(activeUnits_.Sensors_Cached);
				}
				else if (activeUnits_.IsSatellite)
				{
					((Satellite)activeUnits_).Sensory.vmethod_0(activeUnits_.Sensors_Cached);
				}
			}
		}
	}

	public static void AllInOne(string string_0)
	{
		FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read);
		XmlDocument xmlDocument = new XmlDocument();
		try
		{
			using (fileStream)
			{
				try
				{
					xmlDocument.Load(fileStream);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					Interaction.MsgBox("想定列表文件格式不正确，读取失败！");
					ProjectData.ClearProjectError();
				}
			}
			XmlNode xmlNode = xmlDocument.SelectSingleNode("/ScenarioList");
			if (xmlNode == null)
			{
				Interaction.MsgBox("找不到XML数据。");
				return;
			}
			XmlNodeList childNodes = xmlNode.ChildNodes;
			IEnumerator enumerator = null;
			try
			{
				enumerator = childNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				IEnumerator enumerator3 = null;
				string text = null;
				IEnumerator enumerator4 = null;
				string text2 = null;
				int num = 0;
				Scenario scenario = null;
				DBOps.DBFileCheckResult dbfileCheckResult_ = DBOps.DBFileCheckResult.Undefined;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode2 = (XmlNode)enumerator.Current;
					StreamWriter streamWriter;
					try
					{
						try
						{
							enumerator2 = xmlNode2.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode3 = (XmlNode)enumerator2.Current;
								string left = xmlNode3.Name.Split('_')[0];
								if (Operators.CompareString(left, "ScenarioFilePath", TextCompare: false) == 0)
								{
									try
									{
										try
										{
											enumerator3 = xmlNode3.ChildNodes.GetEnumerator();
											while (enumerator3.MoveNext())
											{
												XmlNode xmlNode4 = (XmlNode)enumerator3.Current;
												if (Operators.CompareString(xmlNode4.Name.Split('_')[0], "#comment", TextCompare: false) == 0)
												{
													text = xmlNode4.InnerText;
													text = text.Trim();
													Application.DoEvents();
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
									}
									catch (Exception projectError2)
									{
										ProjectData.SetProjectError(projectError2);
										Interaction.MsgBox("找不到想定文件路径。");
										ProjectData.ClearProjectError();
									}
								}
								else
								{
									if (Operators.CompareString(left, "ConfigFilePath", TextCompare: false) != 0)
									{
										continue;
									}
									try
									{
										try
										{
											enumerator4 = xmlNode3.ChildNodes.GetEnumerator();
											while (enumerator4.MoveNext())
											{
												XmlNode xmlNode5 = (XmlNode)enumerator4.Current;
												if (Operators.CompareString(xmlNode5.Name.Split('_')[0], "#comment", TextCompare: false) == 0)
												{
													text2 = xmlNode5.InnerText;
													text2 = text2.Trim();
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
									}
									catch (Exception projectError3)
									{
										ProjectData.SetProjectError(projectError3);
										Interaction.MsgBox("找不到配置文件路径。");
										ProjectData.ClearProjectError();
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
						num++;
						if (FileExistsNative.FileExistsFast(text))
						{
							Scenario scenario_ = scenario;
							if (!Information.IsNothing(scenario_))
							{
								GameGeneral.DestroyPreviousScenario(ref scenario_, bool_1: true);
							}
							ScenContainer scenContainer = ScenContainer.LoadFromFile(text);
							string string_ = "";
							scenario = scenContainer.GetScenarioObject(ref string_, null, bool_0: false);
							string text3 = "想定" + Conversions.ToString(num) + ": " + scenario.Title + "\r\nScenario file: " + text + "\r\nConfig file:   " + text2;
							streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter.Write("\r\n\r\n" + text3);
							streamWriter.Close();
							streamWriter = File.AppendText(MerchantMerchantPage.LogoutList.Info.DirectoryPath + Conversions.ToString(Path.DirectorySeparatorChar) + "Logs" + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt");
							streamWriter.Write("\r\n\r\n" + text3);
							streamWriter.Close();
							DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(scenario.DBUsed, ref dbfileCheckResult_);
							if (Information.IsNothing(dBRecordByHash))
							{
								Interaction.MsgBox("错误：" + DBOps.PublishImporter(dbfileCheckResult_) + "\r\nAborting...");
								break;
							}
							_ = scenario.DBUsed;
							string text7 = (scenario.DBUsed = DBOps.GetHashForMostRecentVersionOfThisDB(dBRecordByHash.DBID));
							string text4 = text7;
							string string_2 = text4;
							List<string> list = CheckForPlatFormsMissingFromDB(scenario, string_2, bool_0: false);
							if (list.Count > 0)
							{
								text3 = "  ERROR: ONE OR MORE PLATFORMS FEATURED IN THIS SCENARIO IS MISSING FROM THE DATABASE YOU ARE ATTEMPTING TO MIGRATE TO.\r\n  THE MISSING PLATFORMS ARE AS FOLLOWS:\r\n";
								foreach (string item in list)
								{
									text3 = text3 + "  " + item + "\r\n";
								}
								text3 += "  Please contact the author of this DB in order to have this problem rectified. The unit(s) have to be deleted and replaced with units that actually exist in the database.\r\n";
								text3 += "迁移中止！";
								streamWriter = File.AppendText(MerchantMerchantPage.LogoutList.Info.DirectoryPath + Conversions.ToString(Path.DirectorySeparatorChar) + "Logs" + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR log file.txt");
								streamWriter.Close();
								text3 = "想定" + Conversions.ToString(num) + ": ERROR! REBUILD FAILED!";
								streamWriter = File.AppendText(MerchantMerchantPage.LogoutList.Info.DirectoryPath + Conversions.ToString(Path.DirectorySeparatorChar) + "Logs" + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR log file.txt");
								streamWriter.Write("\r\n\r\n" + text3);
								streamWriter.Close();
								continue;
							}
							scenario.LastSavedInScenEdit = true;
							Command_Core.LoadSave.LoadSave.SaveScenario(scenario, scenario.Sides_ReadOnly[0], text, bool_0: true);
							scenario = null;
							Thread.Sleep(2000);
							scenario_ = scenario;
							if (!Information.IsNothing(scenario_))
							{
								GameGeneral.DestroyPreviousScenario(ref scenario_, bool_1: true);
							}
							ScenContainer scenContainer2 = ScenContainer.LoadFromFile(text);
							string_ = "";
							scenario = scenContainer2.GetScenarioObject(ref string_, null, bool_0: true);
							List<string> list2 = CheckForAircraftCarryingIllegalLoadouts(scenario);
							if (list2.Count > 0)
							{
								text3 = "  错误：一个或多个飞机的指定挂载不在飞机的可用挂载列表中\r\n 这些飞机包括：\r\n";
								foreach (string item2 in list2)
								{
									text3 = text3 + "  " + item2 + "\r\n";
								}
								text3 += "请联系此数据库的作者以解决此问题。";
								streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter.Write("\r\n" + text3);
								streamWriter.Close();
							}
							List<string> list3 = new List<string>();
							Side[] sides_ReadOnly = scenario.Sides_ReadOnly;
							for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
							{
								Side side_ = sides_ReadOnly[i];
								if (Information.IsNothing(side_.Missions))
								{
									continue;
								}
								foreach (Mission item3 in side_.GetMissionsTotal(scenario))
								{
									Mission mission_ = item3;
									list3.AddRange(scenario.CheckForAircraftNotTakingOffDueToFlightSizeRestrictions(ref side_, ref mission_));
								}
							}
							if (list3.Count > 0)
							{
								text3 = "  WARNING! SOME AIRCRAFT IN THIS SCENARIO WILL NOT BE ABLE TO TAKE OFF DUE TO THE MISSION'S FLIGHT SIZE RESTRICTIONS!\r\n  To rectify this, you can change the flight size of the mission, add more aircraft to the mission, change loadouts on existing aircraft so there are enough aircraft armed with identical loadouts, or uncheck the flag Aircraft numbers below Flight Size do not take off.\r\n";
								foreach (string item4 in list3)
								{
									text3 = text3 + "\r\n    " + item4;
								}
								streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter.Write("\r\n" + text3);
								streamWriter.Close();
							}
							text3 = "";
							if (!string.IsNullOrEmpty(text3))
							{
								text3 = "  ERROR! SOME AREAS IN THIS SCENARIO HAS PROBLEMS!\r\n" + text3;
								streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
								streamWriter.Write("\r\n" + text3);
								streamWriter.Close();
							}
							ApplyScriptToScenario(scenario, text2, bool_0: false);
							GenerateScenarioContentsList(scenario);
							foreach (ActiveUnit activeUnits_ in scenario.ActiveUnits_List)
							{
								activeUnits_.Sensory.vmethod_0(activeUnits_.Sensors_Cached);
							}
							scenario.LastSavedInScenEdit = true;
							Command_Core.LoadSave.LoadSave.SaveScenario(scenario, scenario.Sides_ReadOnly[0], text, bool_0: true);
							text3 = "想定" + Conversions.ToString(num) + "：重建完成";
							streamWriter = File.AppendText(MerchantMerchantPage.LogoutList.Info.DirectoryPath + Conversions.ToString(Path.DirectorySeparatorChar) + "Logs" + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR log file.txt");
							streamWriter.Write("\r\n" + text3);
							streamWriter.Close();
							streamWriter = File.AppendText(MerchantMerchantPage.LogoutList.Info.DirectoryPath + Conversions.ToString(Path.DirectorySeparatorChar) + "Logs" + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt");
							streamWriter.Write(text3);
							streamWriter.Close();
						}
						else
						{
							string text5 = "想定" + Conversions.ToString(num) + ": ERROR! FILE NOT FOUND!";
							streamWriter = File.AppendText(MerchantMerchantPage.LogoutList.Info.DirectoryPath + Conversions.ToString(Path.DirectorySeparatorChar) + "Logs" + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR log file.txt");
							streamWriter.Write("\r\n\r\n" + text5);
							streamWriter.Close();
							streamWriter = File.AppendText(MerchantMerchantPage.LogoutList.Info.DirectoryPath + Conversions.ToString(Path.DirectorySeparatorChar) + "Logs" + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt");
							streamWriter.Write("\r\n\r\n" + text5);
							streamWriter.Close();
						}
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						string text6 = "想定" + Conversions.ToString(num) + ": ERROR! LOAD FAILED!";
						streamWriter = File.AppendText(MerchantMerchantPage.LogoutList.Info.DirectoryPath + Conversions.ToString(Path.DirectorySeparatorChar) + "Logs" + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR log file.txt");
						streamWriter.Write("\r\n\r\n" + text6);
						streamWriter.Close();
						ProjectData.ClearProjectError();
					}
					streamWriter.Dispose();
					streamWriter = null;
					Thread.Sleep(2000);
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
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101120", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static List<string> CheckForPlatFormsMissingFromDB(Scenario scenario_0, string string_0, bool bool_0)
	{
		HashSet<string> hashSet = new HashSet<string>();
		List<string> list = new List<string>();
		try
		{
			DBOps.DBFileCheckResult dbfileCheckResult_ = DBOps.DBFileCheckResult.Undefined;
			DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(string_0, ref dbfileCheckResult_);
			if (Information.IsNothing(dBRecordByHash))
			{
				throw new Exception(DBOps.PublishImporter(dbfileCheckResult_));
			}
			List<string> list_ = dBRecordByHash.List_0;
			Weapon[] gparam_ = null;
			foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
			{
				if (activeUnits_ == null)
				{
					continue;
				}
				if (activeUnits_.IsAircraft)
				{
					if (hashSet.Contains("飞机 #" + Conversions.ToString(activeUnits_.DBID)))
					{
						continue;
					}
					hashSet.Add("飞机 #" + Conversions.ToString(activeUnits_.DBID));
					if (!list_.Contains("飞机 #" + Conversions.ToString(activeUnits_.DBID)))
					{
						list.Add("飞机 #" + Conversions.ToString(activeUnits_.DBID) + ", " + activeUnits_.UnitClass);
					}
				}
				else if (activeUnits_.IsShip)
				{
					if (hashSet.Contains("船 #" + Conversions.ToString(activeUnits_.DBID)))
					{
						continue;
					}
					hashSet.Add("船 #" + Conversions.ToString(activeUnits_.DBID));
					if (!list_.Contains("船 #" + Conversions.ToString(activeUnits_.DBID)))
					{
						list.Add("船 #" + Conversions.ToString(activeUnits_.DBID) + ", " + activeUnits_.UnitClass);
					}
				}
				else if (activeUnits_.IsSubmarine)
				{
					if (hashSet.Contains("潜艇 #" + Conversions.ToString(activeUnits_.DBID)))
					{
						continue;
					}
					hashSet.Add("潜艇 #" + Conversions.ToString(activeUnits_.DBID));
					if (!list_.Contains("潜艇 #" + Conversions.ToString(activeUnits_.DBID)))
					{
						list.Add("潜艇 #" + Conversions.ToString(activeUnits_.DBID) + ", " + activeUnits_.UnitClass);
					}
				}
				else if (activeUnits_.IsFacility)
				{
					if (hashSet.Contains("设施 #" + Conversions.ToString(activeUnits_.DBID)))
					{
						continue;
					}
					hashSet.Add("设施 #" + Conversions.ToString(activeUnits_.DBID));
					if (!list_.Contains("设施 #" + Conversions.ToString(activeUnits_.DBID)))
					{
						list.Add("设施 #" + Conversions.ToString(activeUnits_.DBID) + ", " + activeUnits_.UnitClass);
					}
				}
				else if (activeUnits_.IsMobileGroundUnit)
				{
					if (hashSet.Contains("GroundUnit #" + Conversions.ToString(activeUnits_.DBID)))
					{
						continue;
					}
					hashSet.Add("GroundUnit #" + Conversions.ToString(activeUnits_.DBID));
					if (!list_.Contains("GroundUnit #" + Conversions.ToString(activeUnits_.DBID)))
					{
						list.Add("GroundUnit #" + Conversions.ToString(activeUnits_.DBID) + ", " + activeUnits_.UnitClass);
					}
				}
				else if (activeUnits_.IsWeapon)
				{
					if (hashSet.Contains("武器 #" + Conversions.ToString(activeUnits_.DBID)))
					{
						continue;
					}
					hashSet.Add("武器 #" + Conversions.ToString(activeUnits_.DBID));
					if (!list_.Contains("武器 #" + Conversions.ToString(activeUnits_.DBID)))
					{
						list.Add("武器 #" + Conversions.ToString(activeUnits_.DBID) + ", " + activeUnits_.Name);
					}
				}
				else if (activeUnits_.IsSatellite)
				{
					if (hashSet.Contains("卫星 #" + Conversions.ToString(activeUnits_.DBID)))
					{
						continue;
					}
					hashSet.Add("卫星 #" + Conversions.ToString(activeUnits_.DBID));
					if (!list_.Contains("卫星 #" + Conversions.ToString(activeUnits_.DBID)))
					{
						list.Add("卫星 #" + Conversions.ToString(activeUnits_.DBID) + ", " + activeUnits_.UnitClass);
					}
				}
				else if (!activeUnits_.IsGroup)
				{
					throw new NotImplementedException();
				}
				if (!bool_0)
				{
					continue;
				}
				gparam_ = activeUnits_.Weaponry.AllDistinctWeaponsAboard_Actual().ToArray();
				Weapon[] array = gparam_;
				Weapon[] array2 = array;
				foreach (Weapon weapon in array2)
				{
					if (!hashSet.Contains("武器 #" + Conversions.ToString(weapon.DBID)))
					{
						hashSet.Add("武器 #" + Conversions.ToString(weapon.DBID));
						if (!list_.Contains("武器 #" + Conversions.ToString(weapon.DBID)))
						{
							list.Add("武器 #" + Conversions.ToString(weapon.DBID) + ", " + weapon.Name);
						}
					}
				}
			}
			if (!Information.IsNothing(gparam_))
			{
				ArrayExtensions.Clear(ref gparam_);
			}
			gparam_ = null;
			if (!Information.IsNothing(hashSet))
			{
				hashSet.Clear();
			}
			hashSet = null;
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101121", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<string> result = new List<string>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static List<string> CheckForAircraftCarryingIllegalLoadouts(Scenario scenario_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(scenario_0.DBConnection);
		List<string> list = new List<string>();
		try
		{
			foreach (ActiveUnit value in scenario_0.ActiveUnits.Values)
			{
				if (value.IsAircraft)
				{
					Aircraft aircraft = (Aircraft)value;
					string string_ = "Select ID from DataAircraftLoadouts where ID = " + Conversions.ToString(aircraft.DBID) + " and ComponentID = " + Conversions.ToString(aircraft.Int32_0);
					if ((sQLiteHelper.ComputeSpecification(string_).Rows.Count == 0) & (aircraft.Int32_0 > 0))
					{
						Aircraft_AirOps airOps = aircraft.AirOps;
						string item = (value.IsOperating() ? ("飞机：" + aircraft.UnitClass + "，DBID：" + Conversions.ToString(aircraft.DBID) + "，挂载：" + aircraft.Loadout.Name + "，DBID：" + Conversions.ToString(aircraft.Loadout.DBID) + "（空中）") : ("飞机：" + aircraft.UnitClass + "，呼号：" + aircraft.Name + "，DBID：" + Conversions.ToString(aircraft.DBID) + "，挂载：" + aircraft.Loadout.Name + "，DBID：" + Conversions.ToString(aircraft.Loadout.DBID) + "（停在上面" + airOps.CurrentHostUnit.UnitClass + ")"));
						list.Add(item);
					}
				}
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101122", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<string> result = new List<string>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static void ProcessUnit(Scenario scenario_0, XmlDocument xmlDocument_0, ref ActiveUnit activeUnit_0)
	{
		Cargo Local_theCargo = null;
		if (Information.IsNothing(xmlDocument_0.FirstChild))
		{
			return;
		}
		try
		{
			XmlNode xmlNode = xmlDocument_0.SelectSingleNode("/DeltaUnit");
			if (xmlNode != null)
			{
				string value = "\r\nPlatform list: \r\n  DBID -- Unit name  ----  Class Info  ----  ObjectID";
				StreamWriter streamWriter = File.AppendText(GameGeneral.SBRLogFilePath);
				streamWriter.Write(value);
				streamWriter.Close();
				XmlNodeList childNodes = xmlNode.ChildNodes;
				IEnumerator enumerator = null;
				try
				{
					enumerator = childNodes.GetEnumerator();
					string string_ = null;
					string string_2 = null;
					string string_3 = null;
					IEnumerator enumerator2 = null;
					IEnumerator enumerator3 = null;
					int num = 0;
					IEnumerator enumerator4 = null;
					IEnumerator enumerator5 = null;
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode2 = (XmlNode)enumerator.Current;
						string text = xmlNode2.Name.Split('_')[1];
						ActiveUnit activeUnit_ = ((activeUnit_0 == null) ? scenario_0.ActiveUnits[text] : activeUnit_0);
						if (activeUnit_ == null)
						{
							value = "错误：单元#" + text + "在想定中不存在！";
							StreamWriter streamWriter12 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter12.Write("\r\n  " + value);
							streamWriter12.Close();
							continue;
						}
						SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
						switch (activeUnit_.UnitType)
						{
						case GlobalVariables.ActiveUnitType.Aircraft:
							string_ = "Select YearCommissioned, YearDecommissioned from DataAircraft where ID = " + Conversions.ToString(activeUnit_.DBID);
							string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataAircraft where ID = " + Conversions.ToString(activeUnit_.DBID) + ")";
							string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataAircraft where ID = " + Conversions.ToString(activeUnit_.DBID) + ")";
							break;
						case GlobalVariables.ActiveUnitType.Ship:
							string_ = "Select YearCommissioned, YearDecommissioned from DataShip where ID = " + Conversions.ToString(activeUnit_.DBID);
							string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataShip where ID = " + Conversions.ToString(activeUnit_.DBID) + ")";
							string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataShip where ID = " + Conversions.ToString(activeUnit_.DBID) + ")";
							break;
						case GlobalVariables.ActiveUnitType.Submarine:
							string_ = "Select YearCommissioned, YearDecommissioned from DataSubmarine where ID = " + Conversions.ToString(activeUnit_.DBID);
							string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataSubmarine where ID = " + Conversions.ToString(activeUnit_.DBID) + ")";
							string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataSubmarine where ID = " + Conversions.ToString(activeUnit_.DBID) + ")";
							break;
						case GlobalVariables.ActiveUnitType.Facility:
							string_ = "Select YearCommissioned, YearDecommissioned from DataFacility where ID = " + Conversions.ToString(activeUnit_.DBID);
							string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataFacility where ID = " + Conversions.ToString(activeUnit_.DBID) + ")";
							string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataFacility where ID = " + Conversions.ToString(activeUnit_.DBID) + ")";
							break;
						case GlobalVariables.ActiveUnitType.Satellite:
							string_ = "Select YearCommissioned, YearDecommissioned from DataSatellite where ID = " + Conversions.ToString(activeUnit_.DBID);
							string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataSatellite where ID = " + Conversions.ToString(activeUnit_.DBID) + ")";
							string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataSatellite where ID = " + Conversions.ToString(activeUnit_.DBID) + ")";
							break;
						case GlobalVariables.ActiveUnitType.Vehicle:
							string_ = "Select YearCommissioned, YearDecommissioned from DataGroundUnit where ID = " + Conversions.ToString(activeUnit_.DBID);
							string_2 = "Select Description from EnumOperatorCountry where ID in (Select OperatorCountry from DataGroundUnit where ID = " + Conversions.ToString(activeUnit_.DBID) + ")";
							string_3 = "Select Description from EnumOperatorService where ID in (Select OperatorService from DataGroundUnit where ID = " + Conversions.ToString(activeUnit_.DBID) + ")";
							break;
						}
						List<Tuple<string, int, int, string>> list = new List<Tuple<string, int, int, string>>();
						if (!(activeUnit_.IsAircraft | activeUnit_.IsFacility | activeUnit_.IsShip | activeUnit_.IsSubmarine | activeUnit_.IsSatellite))
						{
							continue;
						}
						DataTable datatable = DBCache.GetDatatable(sqliteHelper_, string_);
						DataTable datatable2 = DBCache.GetDatatable(sqliteHelper_, string_2);
						DataTable datatable3 = DBCache.GetDatatable(sqliteHelper_, string_3);
						if ((datatable.Rows.Count != 0) & (datatable2.Rows.Count != 0) & (datatable3.Rows.Count != 0))
						{
							DataRow dataRow = datatable.Rows[0];
							DataRow dataRow2 = datatable2.Rows[0];
							DataRow dataRow3 = datatable3.Rows[0];
							string text2 = Strings.Trim(dataRow2["Description"].ToString());
							string text3 = Strings.Trim(dataRow3["Description"].ToString());
							string text4 = Conversions.ToString(Conversions.ToInteger(dataRow["YearCommissioned"].ToString()));
							string text5 = Conversions.ToString(Conversions.ToInteger(dataRow["YearDecommissioned"].ToString()));
							value = Conversions.ToString(activeUnit_.DBID) + " -- " + activeUnit_.Name + "  ----  " + activeUnit_.UnitClass + " -- " + text2 + " (" + text3 + "), " + text4 + "-" + text5 + "  ----  " + activeUnit_.ObjectID;
							StreamWriter streamWriter23 = File.AppendText(GameGeneral.SBRLogFilePath);
							streamWriter23.Write("\r\n  " + value);
							streamWriter23.Close();
							list.Clear();
							try
							{
								enumerator2 = xmlNode2.ChildNodes.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									XmlNode xmlNode3 = (XmlNode)enumerator2.Current;
									string text6 = xmlNode3.Name.Split('_')[0];
									switch (text6)
									{
									case "AirOpsAdd":
									{
										int num14 = Conversions.ToInteger(xmlNode3.Name.Split('_')[1]);
										if (num14 <= 0)
										{
											if (num14 == -1)
											{
												AirFacility airFacility2 = AirFacility.AddUAV_Class1_Hanger(activeUnit_);
												value = "Added AirOps, DBID: " + Conversions.ToString(num14) + " 名称: " + airFacility2.Name;
												StreamWriter streamWriter32 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter32.Write("\r\n    " + value);
												streamWriter32.Close();
											}
											break;
										}
										SQLiteConnection sqliteConnection_2 = scenario_0.DBConnection;
										AirFacility airFacility3 = DBFunctions.GetAirFacility(num14, ref sqliteConnection_2);
										if (airFacility3 == null)
										{
											value = "ERROR: AIROPS WITH DBID " + Conversions.ToString(num14) + "不能添加，也不能在数据库中找到！";
											StreamWriter streamWriter33 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter33.Write("\r\n    " + value);
											streamWriter33.Close();
										}
										else
										{
											activeUnit_.AddAirFacility(airFacility3);
											airFacility3.ParentPlatform = activeUnit_;
											value = "Added AirOps, DBID: " + Conversions.ToString(num14) + " 名称: " + airFacility3.Name;
											StreamWriter streamWriter35 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter35.Write("\r\n    " + value);
											streamWriter35.Close();
										}
										break;
									}
									case "SensorActive":
									{
										if (activeUnit_.Sensory.Boolean_0)
										{
											activeUnit_.Sensory.Boolean_0 = false;
										}
										float num29 = Conversions.ToInteger(xmlNode3.Name.Split('_')[1]);
										Sensor[] array4 = activeUnit_.Sensors_Cached;
										Sensor[] array11 = array4;
										foreach (Sensor sensor3 in array11)
										{
											if ((float)sensor3.DBID == num29 && !sensor3.IsActive)
											{
												sensor3.GoActive();
												value = "激活传感器[" + Conversions.ToString(num29) + "]";
												StreamWriter streamWriter7 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter7.Write("\r\n    " + value);
												streamWriter7.Close();
											}
										}
										break;
									}
									case "MountAdd":
									{
										int num4 = Conversions.ToInteger(xmlNode3.Name.Split('_')[1]);
										bool flag = false;
										if (num4 <= 0)
										{
											break;
										}
										string string_5 = "SELECT Name from DataMount where ID = " + Conversions.ToString(num4);
										if (DBCache.GetDatatable(sqliteHelper_, string_5).Rows.Count == 0)
										{
											value = "错误：挂载DBID" + Conversions.ToString(num4) + "不能添加，也不能在数据库中找到！";
											StreamWriter streamWriter15 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter15.Write("\r\n    " + value);
											streamWriter15.Close();
											break;
										}
										Mount mount2 = DBFunctions.GetMount(num4, ref scenario_0);
										activeUnit_.Mounts.Add(mount2);
										mount2.ParentPlatform = activeUnit_;
										try
										{
											enumerator4 = xmlNode3.ChildNodes.GetEnumerator();
											while (enumerator4.MoveNext())
											{
												XmlNode xmlNode_2 = (XmlNode)enumerator4.Current;
												string name10 = xmlNode_2.Name;
												if (Operators.CompareString(name10, "Coverage", TextCompare: false) == 0 || Operators.CompareString(name10, "Cov", TextCompare: false) == 0)
												{
													mount2.Coverage = PlatformComponent._Coverage.FromXML(ref xmlNode_2);
													flag = true;
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
										if (flag && mount2.Sensors_ReadOnly.Count() > 0)
										{
											Sensor[] array3 = mount2.Sensors_ReadOnly;
											Sensor[] array12 = array3;
											foreach (Sensor obj in array12)
											{
												obj.ParentPlatform = activeUnit_;
												obj.Coverage.PB1 = mount2.Coverage.PB1;
												obj.Coverage.PB2 = mount2.Coverage.PB2;
												obj.Coverage.PMA1 = mount2.Coverage.PMA1;
												obj.Coverage.PMA2 = mount2.Coverage.PMA2;
												obj.Coverage.PMF1 = mount2.Coverage.PMF1;
												obj.Coverage.PMF2 = mount2.Coverage.PMF2;
												obj.Coverage.PS1 = mount2.Coverage.PS1;
												obj.Coverage.PS2 = mount2.Coverage.PS2;
												obj.Coverage.SB1 = mount2.Coverage.SB1;
												obj.Coverage.SB2 = mount2.Coverage.SB2;
												obj.Coverage.SMA1 = mount2.Coverage.SMA1;
												obj.Coverage.SMA2 = mount2.Coverage.SMA2;
												obj.Coverage.SMF1 = mount2.Coverage.SMF1;
												obj.Coverage.SMF2 = mount2.Coverage.SMF2;
												obj.Coverage.SS1 = mount2.Coverage.SS1;
												obj.Coverage.SS2 = mount2.Coverage.SS2;
											}
										}
										value = "添加了挂架，DBID：" + Conversions.ToString(num4) + " 名称 " + mount2.Name;
										StreamWriter streamWriter16 = File.AppendText(GameGeneral.SBRLogFilePath);
										streamWriter16.Write("\r\n    " + value);
										streamWriter16.Close();
										if (!flag)
										{
											value = "错误：挂载DBID" + Conversions.ToString(num4) + "没有设置角度！";
											StreamWriter streamWriter17 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter17.Write("\r\n    " + value);
											streamWriter17.Close();
										}
										break;
									}
									case "Damage":
										try
										{
											enumerator3 = xmlNode3.ChildNodes.GetEnumerator();
											while (enumerator3.MoveNext())
											{
												XmlNode xmlNode4 = (XmlNode)enumerator3.Current;
												switch (xmlNode4.Name.Split('_')[0])
												{
												case "Cargo":
												{
													string right4 = xmlNode4.Name.Split('_')[1];
													Cargo[] onboardCargo = activeUnit_.OnboardCargo;
													Cargo[] array8 = onboardCargo;
													foreach (Cargo cargo in array8)
													{
														if (Operators.CompareString(cargo.ObjectID, right4, TextCompare: false) != 0)
														{
															continue;
														}
														PlatformComponent._ComponentStatus componentStatus4 = PlatformComponent._ComponentStatus.Operational;
														PlatformComponent._DamageSeverityFactor damageSeverityFactor4 = PlatformComponent._DamageSeverityFactor.Light;
														if (xmlNode4.SelectSingleNode("Severity") != null)
														{
															damageSeverityFactor4 = (PlatformComponent._DamageSeverityFactor)Conversions.ToByte(xmlNode4.SelectSingleNode("Severity").InnerText);
															if (cargo.DamageSeverity == damageSeverityFactor4)
															{
																damageSeverityFactor4 = PlatformComponent._DamageSeverityFactor.Light;
															}
															else
															{
																cargo.Damage(damageSeverityFactor4);
															}
														}
														if (xmlNode4.SelectSingleNode("Status") == null)
														{
															continue;
														}
														componentStatus4 = (PlatformComponent._ComponentStatus)Conversions.ToByte(xmlNode4.SelectSingleNode("Status").InnerText);
														if (cargo.Status == componentStatus4)
														{
															break;
														}
														switch (componentStatus4)
														{
														case PlatformComponent._ComponentStatus.Operational:
															cargo.Repair();
															break;
														case PlatformComponent._ComponentStatus.Damaged:
															if (damageSeverityFactor4 == PlatformComponent._DamageSeverityFactor.Light)
															{
																cargo.Damage(cargo.DamageSeverity);
															}
															break;
														case PlatformComponent._ComponentStatus.Destroyed:
															cargo.Destroy(activeUnit_.GetUnitSide(), bool_0: true, bool_1: false);
															break;
														}
														break;
													}
													break;
												}
												case "Fire":
													activeUnit_.Damage.FireIntensity = (ActiveUnit_Damage.FireIntensityLevel)Conversions.ToByte(xmlNode4.InnerText);
													break;
												case "Mag":
												{
													string right2 = xmlNode4.Name.Split('_')[1];
													Magazine[] sharedMagazines = activeUnit_.SharedMagazines;
													Magazine[] array6 = sharedMagazines;
													foreach (Magazine magazine in array6)
													{
														if (Operators.CompareString(magazine.ObjectID, right2, TextCompare: false) != 0)
														{
															continue;
														}
														PlatformComponent._ComponentStatus componentStatus2 = PlatformComponent._ComponentStatus.Operational;
														PlatformComponent._DamageSeverityFactor damageSeverityFactor2 = PlatformComponent._DamageSeverityFactor.Light;
														if (xmlNode4.SelectSingleNode("Severity") != null)
														{
															damageSeverityFactor2 = (PlatformComponent._DamageSeverityFactor)Conversions.ToByte(xmlNode4.SelectSingleNode("Severity").InnerText);
															if (magazine.DamageSeverity == damageSeverityFactor2)
															{
																damageSeverityFactor2 = PlatformComponent._DamageSeverityFactor.Light;
															}
															else
															{
																magazine.Damage(damageSeverityFactor2);
															}
														}
														if (xmlNode4.SelectSingleNode("Status") == null)
														{
															continue;
														}
														componentStatus2 = (PlatformComponent._ComponentStatus)Conversions.ToByte(xmlNode4.SelectSingleNode("Status").InnerText);
														if (magazine.Status == componentStatus2)
														{
															break;
														}
														switch (componentStatus2)
														{
														case PlatformComponent._ComponentStatus.Operational:
															magazine.Repair();
															break;
														case PlatformComponent._ComponentStatus.Damaged:
															if (damageSeverityFactor2 == PlatformComponent._DamageSeverityFactor.Light)
															{
																magazine.Damage(magazine.DamageSeverity);
															}
															break;
														case PlatformComponent._ComponentStatus.Destroyed:
															magazine.Destroy(activeUnit_.GetUnitSide(), bool_0: true, bool_1: false);
															break;
														}
														break;
													}
													break;
												}
												case "Mount":
												{
													string right7 = xmlNode4.Name.Split('_')[1];
													foreach (Mount mount3 in activeUnit_.Mounts)
													{
														if (Operators.CompareString(mount3.ObjectID, right7, TextCompare: false) != 0)
														{
															continue;
														}
														PlatformComponent._ComponentStatus componentStatus7 = PlatformComponent._ComponentStatus.Operational;
														PlatformComponent._DamageSeverityFactor damageSeverityFactor7 = PlatformComponent._DamageSeverityFactor.Light;
														if (xmlNode4.SelectSingleNode("Severity") != null)
														{
															damageSeverityFactor7 = (PlatformComponent._DamageSeverityFactor)Conversions.ToByte(xmlNode4.SelectSingleNode("Severity").InnerText);
															if (mount3.DamageSeverity == damageSeverityFactor7)
															{
																damageSeverityFactor7 = PlatformComponent._DamageSeverityFactor.Light;
															}
															else
															{
																mount3.Damage(damageSeverityFactor7);
															}
														}
														if (xmlNode4.SelectSingleNode("Status") == null)
														{
															continue;
														}
														componentStatus7 = (PlatformComponent._ComponentStatus)Conversions.ToByte(xmlNode4.SelectSingleNode("Status").InnerText);
														if (mount3.Status == componentStatus7)
														{
															break;
														}
														switch (componentStatus7)
														{
														case PlatformComponent._ComponentStatus.Operational:
															mount3.Repair();
															break;
														case PlatformComponent._ComponentStatus.Damaged:
															if (damageSeverityFactor7 == PlatformComponent._DamageSeverityFactor.Light)
															{
																mount3.Damage(mount3.DamageSeverity);
															}
															break;
														case PlatformComponent._ComponentStatus.Destroyed:
															mount3.Destroy(activeUnit_.GetUnitSide(), bool_0: true, bool_1: false);
															break;
														}
														break;
													}
													break;
												}
												case "DamagePts":
													activeUnit_.SetDamagePts(bool_0: false, null, Conversions.ToInteger(xmlNode4.InnerText));
													break;
												case "Comm":
												{
													string right6 = xmlNode4.Name.Split('_')[1];
													CommDevice[] comms_ReadOnly = activeUnit_.Comms_ReadOnly;
													CommDevice[] array9 = comms_ReadOnly;
													foreach (CommDevice commDevice in array9)
													{
														if (Operators.CompareString(commDevice.ObjectID, right6, TextCompare: false) != 0)
														{
															continue;
														}
														PlatformComponent._ComponentStatus componentStatus6 = PlatformComponent._ComponentStatus.Operational;
														PlatformComponent._DamageSeverityFactor damageSeverityFactor6 = PlatformComponent._DamageSeverityFactor.Light;
														if (xmlNode4.SelectSingleNode("Severity") != null)
														{
															damageSeverityFactor6 = (PlatformComponent._DamageSeverityFactor)Conversions.ToByte(xmlNode4.SelectSingleNode("Severity").InnerText);
															if (commDevice.DamageSeverity == damageSeverityFactor6)
															{
																damageSeverityFactor6 = PlatformComponent._DamageSeverityFactor.Light;
															}
															else
															{
																commDevice.Damage(damageSeverityFactor6);
															}
														}
														if (xmlNode4.SelectSingleNode("Status") == null)
														{
															continue;
														}
														componentStatus6 = (PlatformComponent._ComponentStatus)Conversions.ToByte(xmlNode4.SelectSingleNode("Status").InnerText);
														if (commDevice.Status == componentStatus6)
														{
															break;
														}
														switch (componentStatus6)
														{
														case PlatformComponent._ComponentStatus.Operational:
															commDevice.Repair();
															break;
														case PlatformComponent._ComponentStatus.Damaged:
															if (damageSeverityFactor6 == PlatformComponent._DamageSeverityFactor.Light)
															{
																commDevice.Damage(commDevice.DamageSeverity);
															}
															break;
														case PlatformComponent._ComponentStatus.Destroyed:
															commDevice.Destroy(activeUnit_.GetUnitSide(), bool_0: true, bool_1: false);
															break;
														}
														break;
													}
													break;
												}
												case "Flood":
													activeUnit_.Damage.FloodIntensity = (ActiveUnit_Damage.FloodingIntensityLevel)Conversions.ToByte(xmlNode4.InnerText);
													break;
												case "Engine":
												{
													string right5 = xmlNode4.Name.Split('_')[1];
													foreach (Engine item5 in activeUnit_.Propulsion)
													{
														if (Operators.CompareString(item5.ObjectID, right5, TextCompare: false) != 0)
														{
															continue;
														}
														PlatformComponent._ComponentStatus componentStatus5 = PlatformComponent._ComponentStatus.Operational;
														PlatformComponent._DamageSeverityFactor damageSeverityFactor5 = PlatformComponent._DamageSeverityFactor.Light;
														if (xmlNode4.SelectSingleNode("Severity") != null)
														{
															damageSeverityFactor5 = (PlatformComponent._DamageSeverityFactor)Conversions.ToByte(xmlNode4.SelectSingleNode("Severity").InnerText);
															if (item5.DamageSeverity == damageSeverityFactor5)
															{
																damageSeverityFactor5 = PlatformComponent._DamageSeverityFactor.Light;
															}
															else
															{
																item5.Damage(damageSeverityFactor5);
															}
														}
														if (xmlNode4.SelectSingleNode("Status") == null)
														{
															continue;
														}
														componentStatus5 = (PlatformComponent._ComponentStatus)Conversions.ToByte(xmlNode4.SelectSingleNode("Status").InnerText);
														if (item5.Status == componentStatus5)
														{
															break;
														}
														switch (componentStatus5)
														{
														case PlatformComponent._ComponentStatus.Operational:
															item5.Repair();
															break;
														case PlatformComponent._ComponentStatus.Damaged:
															if (damageSeverityFactor5 == PlatformComponent._DamageSeverityFactor.Light)
															{
																item5.Damage(item5.DamageSeverity);
															}
															break;
														case PlatformComponent._ComponentStatus.Destroyed:
															item5.Destroy(activeUnit_.GetUnitSide(), bool_0: true, bool_1: false);
															break;
														}
														break;
													}
													break;
												}
												case "Sensor":
												{
													string right3 = xmlNode4.Name.Split('_')[1];
													Sensor[] array2 = activeUnit_.Sensors_ReadOnly();
													Sensor[] array7 = array2;
													foreach (Sensor sensor in array7)
													{
														if (Operators.CompareString(sensor.ObjectID, right3, TextCompare: false) != 0)
														{
															continue;
														}
														PlatformComponent._ComponentStatus componentStatus3 = PlatformComponent._ComponentStatus.Operational;
														PlatformComponent._DamageSeverityFactor damageSeverityFactor3 = PlatformComponent._DamageSeverityFactor.Light;
														if (xmlNode4.SelectSingleNode("Severity") != null)
														{
															damageSeverityFactor3 = (PlatformComponent._DamageSeverityFactor)Conversions.ToByte(xmlNode4.SelectSingleNode("Severity").InnerText);
															if (sensor.DamageSeverity == damageSeverityFactor3)
															{
																damageSeverityFactor3 = PlatformComponent._DamageSeverityFactor.Light;
															}
															else
															{
																sensor.Damage(damageSeverityFactor3);
															}
														}
														if (xmlNode4.SelectSingleNode("Status") == null)
														{
															continue;
														}
														componentStatus3 = (PlatformComponent._ComponentStatus)Conversions.ToByte(xmlNode4.SelectSingleNode("Status").InnerText);
														if (sensor.Status == componentStatus3)
														{
															break;
														}
														switch (componentStatus3)
														{
														case PlatformComponent._ComponentStatus.Operational:
															sensor.Repair();
															break;
														case PlatformComponent._ComponentStatus.Damaged:
															if (damageSeverityFactor3 == PlatformComponent._DamageSeverityFactor.Light)
															{
																sensor.Damage(sensor.DamageSeverity);
															}
															break;
														case PlatformComponent._ComponentStatus.Destroyed:
															sensor.Destroy(activeUnit_.GetUnitSide(), bool_0: true, bool_1: false);
															break;
														}
														break;
													}
													break;
												}
												case "AirFacility":
												{
													string right = xmlNode4.Name.Split('_')[1];
													AirFacility[] airFacilities_ReadOnly = activeUnit_.AirFacilities_ReadOnly;
													AirFacility[] array5 = airFacilities_ReadOnly;
													foreach (AirFacility airFacility in array5)
													{
														if (Operators.CompareString(airFacility.ObjectID, right, TextCompare: false) != 0)
														{
															continue;
														}
														PlatformComponent._ComponentStatus componentStatus = PlatformComponent._ComponentStatus.Operational;
														PlatformComponent._DamageSeverityFactor damageSeverityFactor = PlatformComponent._DamageSeverityFactor.Light;
														if (xmlNode4.SelectSingleNode("Severity") != null)
														{
															damageSeverityFactor = (PlatformComponent._DamageSeverityFactor)Conversions.ToByte(xmlNode4.SelectSingleNode("Severity").InnerText);
															if (airFacility.DamageSeverity == damageSeverityFactor)
															{
																damageSeverityFactor = PlatformComponent._DamageSeverityFactor.Light;
															}
															else
															{
																airFacility.Damage(damageSeverityFactor);
															}
														}
														if (xmlNode4.SelectSingleNode("Status") == null)
														{
															continue;
														}
														componentStatus = (PlatformComponent._ComponentStatus)Conversions.ToByte(xmlNode4.SelectSingleNode("Status").InnerText);
														if (airFacility.Status == componentStatus)
														{
															break;
														}
														switch (componentStatus)
														{
														case PlatformComponent._ComponentStatus.Operational:
															airFacility.Repair();
															break;
														case PlatformComponent._ComponentStatus.Damaged:
															if (damageSeverityFactor == PlatformComponent._DamageSeverityFactor.Light)
															{
																airFacility.Damage(airFacility.DamageSeverity);
															}
															break;
														case PlatformComponent._ComponentStatus.Destroyed:
															airFacility.Destroy(activeUnit_.GetUnitSide(), bool_0: true, bool_1: false);
															break;
														}
														break;
													}
													break;
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
									case "MagAdd":
									{
										int num26 = Conversions.ToInteger(xmlNode3.Name.Split('_')[1]);
										if (num26 > 0)
										{
											string string_4 = "SELECT Name from DataMagazine where ID = " + Conversions.ToString(num26);
											if (DBCache.GetDatatable(sqliteHelper_, string_4).Rows.Count == 0)
											{
												value = "错误：带有DBID的弹药库" + Conversions.ToString(num26) + "不能添加，也不能在数据库中找到！";
												StreamWriter streamWriter72 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter72.Write("\r\n    " + value);
												streamWriter72.Close();
											}
											else
											{
												Magazine magazine2 = DBFunctions.GetMagazine(num26, ref scenario_0);
												((Platform)activeUnit_).AddSharedMagazine(magazine2);
												magazine2.ParentPlatform = activeUnit_;
												value = "添加弹药库，DBID：" + Conversions.ToString(num26) + " 名称 " + magazine2.Name;
												StreamWriter streamWriter2 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter2.Write("\r\n    " + value);
												streamWriter2.Close();
											}
										}
										break;
									}
									case "Mount":
									{
										int num20 = Conversions.ToInteger(xmlNode3.Name.Split('_')[1]);
										int num21;
										try
										{
											num21 = Conversions.ToInteger(xmlNode3.Name.Split('_')[2]);
										}
										catch (Exception projectError11)
										{
											ProjectData.SetProjectError(projectError11);
											num21 = 0;
											if (num20 != 0)
											{
												value = "错误：挂载索引" + Conversions.ToString(num20) + " HAS NO DBID LISTED (Example: <Mount_<MountIndex>_<MountDBID>> ). THIS MAY CAUSE THE WRONG MOUNT TO BE UPDATED IN CASE A DATABASE UPDATE ALTERS THE MOUNT INDEX!";
												StreamWriter streamWriter44 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter44.Write("\r\n    " + value);
												streamWriter44.Close();
											}
											ProjectData.ClearProjectError();
										}
										try
										{
											if (num20 == 0)
											{
												int num22 = 0;
												value = "更新所有相关挂架：";
												StreamWriter streamWriter46 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter46.Write("\r\n    " + value);
												streamWriter46.Close();
												foreach (Mount mount4 in activeUnit_.Mounts)
												{
													Mount mount_ = mount4;
													int num24 = InstantiateWriter(scenario_0, ref mount_, xmlNode3, num20);
													num22 += num24;
												}
												if (num22 == 0)
												{
													value = "错误：试图更新所有相关的挂架，可能无法找到任何更新！";
													StreamWriter streamWriter47 = File.AppendText(GameGeneral.SBRLogFilePath);
													streamWriter47.Write("\r\n      " + value);
													streamWriter47.Close();
												}
											}
											else if (activeUnit_.Mounts[num20 - 1].DBID != num21 && num21 != 0)
											{
												value = "错误：挂载索引" + Conversions.ToString(num20) + "不匹配DBID" + Conversions.ToString(num21) + "！数据库更新可能会更改安装索引，您需要将安装索引更改为正确值！";
												StreamWriter streamWriter48 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter48.Write("\r\n    " + value);
												streamWriter48.Close();
											}
											else
											{
												Scenario scenario_ = scenario_0;
												ObservableList<Mount> mounts;
												int index;
												Mount mount_2 = (mounts = activeUnit_.Mounts)[index = num20 - 1];
												InstantiateWriter(scenario_, ref mount_2, xmlNode3, num20);
												mounts[index] = mount_2;
											}
										}
										catch (Exception projectError13)
										{
											ProjectData.SetProjectError(projectError13);
											value = "错误：挂载索引" + Conversions.ToString(num20) + "不存在单元！";
											StreamWriter streamWriter49 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter49.Write("\r\n    " + value);
											streamWriter49.Close();
											ProjectData.ClearProjectError();
										}
										break;
									}
									case "CargoAdd":
									{
										XmlNode xmlNode_ = xmlNode3.FirstChild;
										ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_ = null;
										Local_theCargo = Cargo.FromXML(ref xmlNode_, ref concurrentDictionary_, scenario_0, activeUnit_);
										if (activeUnit_.OnboardCargo.FirstOrDefault((Cargo CARGO) => Operators.CompareString(CARGO.ObjectID, Local_theCargo.ObjectID, TextCompare: false) == 0) == null)
										{
											ArrayExtensions.Add(ref activeUnit_.OnboardCargo, Local_theCargo);
										}
										break;
									}
									case "CommAdd":
									{
										int num15 = Conversions.ToInteger(xmlNode3.Name.Split('_')[1]);
										if (num15 > 0)
										{
											string string_6 = "SELECT Name from DataComm where ID = " + Conversions.ToString(num15);
											if (DBCache.GetDatatable(sqliteHelper_, string_6).Rows.Count == 0)
											{
												value = "错误：COMMID与DBID" + Conversions.ToString(num15) + "不能添加，也不能在数据库中找到！";
												StreamWriter streamWriter36 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter36.Write("\r\n    " + value);
												streamWriter36.Close();
											}
											else
											{
												CommDevice commDevice2 = DBFunctions.GetCommDevice(num15, ref activeUnit_);
												activeUnit_.AddCommDevice(commDevice2);
												commDevice2.ParentPlatform = activeUnit_;
												value = "添加了通讯设备，DBID：" + Conversions.ToString(num15) + " 名称: " + commDevice2.Name;
												StreamWriter streamWriter37 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter37.Write("\r\n    " + value);
												streamWriter37.Close();
											}
										}
										break;
									}
									case "Mag":
									{
										int num7 = Conversions.ToInteger(xmlNode3.Name.Split('_')[1]);
										int num8;
										try
										{
											num8 = Conversions.ToInteger(xmlNode3.Name.Split('_')[2]);
										}
										catch (Exception projectError3)
										{
											ProjectData.SetProjectError(projectError3);
											num8 = 0;
											if (num7 != 0)
											{
												value = "错误：带索引的弹药库" + Conversions.ToString(num7) + " HAS NO DBID LISTED (Example: <Mag_<MagIndex>_<MagDBID>> ). THIS MAY CAUSE THE WRONG MAGAZINE TO BE UPDATED IN CASE A DATABASE UPDATE ALTERS THE MAGAZINE INDEX!";
												StreamWriter streamWriter24 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter24.Write("\r\n    " + value);
												streamWriter24.Close();
											}
											ProjectData.ClearProjectError();
										}
										try
										{
											if (num7 == 0)
											{
												int num9 = 0;
												value = "更新所有相关弹药库：";
												StreamWriter streamWriter25 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter25.Write("\r\n    " + value);
												streamWriter25.Close();
												Magazine[] sharedMagazines2 = activeUnit_.SharedMagazines;
												for (int i = 0; i < sharedMagazines2.Length; i = checked(i + 1))
												{
													Magazine magazine_ = sharedMagazines2[i];
													int num10 = CreateWriter(scenario_0, ref magazine_, xmlNode3, num7, bool_0: false);
													num9 += num10;
												}
												if (num9 == 0)
												{
													value = "错误：可能无法找到任何更新的弹药库！";
													StreamWriter streamWriter26 = File.AppendText(GameGeneral.SBRLogFilePath);
													streamWriter26.Write("\r\n      " + value);
													streamWriter26.Close();
												}
											}
											else if (activeUnit_.SharedMagazines[num7 - 1].DBID != num8 && num8 != 0)
											{
												value = "错误：带索引的弹药库" + Conversions.ToString(num7) + "不匹配DBID" + Conversions.ToString(num8) + "！数据库更新可能会更改弹药库索引，您需要将安装索引更改为正确值！";
												StreamWriter streamWriter27 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter27.Write("\r\n    " + value);
												streamWriter27.Close();
											}
											else
											{
												CreateWriter(scenario_0, ref activeUnit_.SharedMagazines[num7 - 1], xmlNode3, num7, bool_0: false);
											}
										}
										catch (Exception projectError4)
										{
											ProjectData.SetProjectError(projectError4);
											value = "错误：带索引的弹药库" + Conversions.ToString(num7 - 1) + "不存在单元！";
											StreamWriter streamWriter28 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter28.Write("\r\n    " + value);
											streamWriter28.Close();
											ProjectData.ClearProjectError();
										}
										break;
									}
									case "MCMRemove":
									{
										int num3 = Conversions.ToInteger(xmlNode3.Name.Split('_')[1]);
										try
										{
											num = Conversions.ToInteger(xmlNode3.Name.Split('_')[2]);
										}
										catch (Exception projectError18)
										{
											ProjectData.SetProjectError(projectError18);
											num = 0;
											if (num3 != 0)
											{
												value = "错误：传感器索引为" + Conversions.ToString(num3) + " HAS NO DBID LISTED (Example: <SensorRemove_<SensorIndex>_<SensorDBID> ). THIS MAY CAUSE THE WRONG SENSOR TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE SENSOR INDEX!";
												StreamWriter streamWriter11 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter11.Write("\r\n    " + value);
												streamWriter11.Close();
											}
											ProjectData.ClearProjectError();
										}
										if (num3 <= 0)
										{
											break;
										}
										try
										{
											if (num == activeUnit_.MineCountermeasures[num3 - 1].DBID)
											{
												string name9 = activeUnit_.MineCountermeasures[num3 - 1].Name;
												list.Add(new Tuple<string, int, int, string>(text6, num3, num, name9));
												break;
											}
											value = "错误：传感器索引为" + Conversions.ToString(num3) + " 的单元没有DBID " + Conversions.ToString(num);
											StreamWriter streamWriter13 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter13.Write("\r\n    " + value);
											streamWriter13.Close();
										}
										catch (Exception projectError19)
										{
											ProjectData.SetProjectError(projectError19);
											value = "错误：传感器索引为" + Conversions.ToString(num3) + "且DBID" + Conversions.ToString(num) + "不能删除，不能找到单元！";
											StreamWriter streamWriter14 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter14.Write("\r\n    " + value);
											streamWriter14.Close();
											ProjectData.ClearProjectError();
										}
										break;
									}
									case "MagRemove":
									{
										int num23 = Conversions.ToInteger(xmlNode3.Name.Split('_')[1]);
										int num25;
										try
										{
											num25 = Conversions.ToInteger(xmlNode3.Name.Split('_')[2]);
										}
										catch (Exception projectError)
										{
											ProjectData.SetProjectError(projectError);
											num25 = 0;
											if (num23 != 0)
											{
												value = "错误：带索引的弹药库" + Conversions.ToString(num23) + " HAS NO DBID LISTED (Example: <MagRemove_<MagIndex>_<MagDBID> ). THIS MAY CAUSE THE WRONG MAGAZINE TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE MAGAZINE INDEX!";
												StreamWriter streamWriter56 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter56.Write("\r\n    " + value);
												streamWriter56.Close();
											}
											ProjectData.ClearProjectError();
										}
										if (num23 <= 0)
										{
											break;
										}
										try
										{
											if (activeUnit_.SharedMagazines[num23 - 1].DBID == num25)
											{
												string name = activeUnit_.SharedMagazines[num23 - 1].Name;
												list.Add(new Tuple<string, int, int, string>(text6, num23, num25, name));
												break;
											}
											value = "错误：弹药库索引" + Conversions.ToString(num23) + " 的单元没有DBID " + Conversions.ToString(num25);
											StreamWriter streamWriter67 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter67.Write("\r\n    " + value);
											streamWriter67.Close();
										}
										catch (Exception projectError12)
										{
											ProjectData.SetProjectError(projectError12);
											value = "错误：带索引的弹药库" + Conversions.ToString(num23) + "且DBID" + Conversions.ToString(num25) + "不能删除，不能找到单元！";
											StreamWriter streamWriter71 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter71.Write("\r\n    " + value);
											streamWriter71.Close();
											ProjectData.ClearProjectError();
										}
										break;
									}
									case "DockRemove":
									{
										int num18 = Conversions.ToInteger(xmlNode3.Name.Split('_')[1]);
										int num19;
										try
										{
											num19 = Conversions.ToInteger(xmlNode3.Name.Split('_')[2]);
										}
										catch (Exception projectError9)
										{
											ProjectData.SetProjectError(projectError9);
											num19 = 0;
											if (num18 != 0)
											{
												value = "ERROR: DOCK FACILITY WITH INDEX " + Conversions.ToString(num18) + " HAS NO DBID LISTED (Example: <DockRemove_<Index>_<DBID> ). THIS MAY CAUSE THE WRONG FACILITY TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE INDEX!";
												StreamWriter streamWriter41 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter41.Write("\r\n    " + value);
												streamWriter41.Close();
											}
											ProjectData.ClearProjectError();
										}
										if (num18 <= 0)
										{
											break;
										}
										try
										{
											if (num19 == activeUnit_.DockFacilities_ReadOnly[num18 - 1].DBID)
											{
												string name14 = activeUnit_.DockFacilities_ReadOnly[num18 - 1].Name;
												list.Add(new Tuple<string, int, int, string>(text6, num18, num19, name14));
												break;
											}
											value = "ERROR: DOCK FACILITY WITH INDEX " + Conversions.ToString(num18) + " 的单元没有DBID " + Conversions.ToString(num19);
											StreamWriter streamWriter42 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter42.Write("\r\n    " + value);
											streamWriter42.Close();
										}
										catch (Exception projectError10)
										{
											ProjectData.SetProjectError(projectError10);
											value = "ERROR: DOCK FACILITY WITH INDEX " + Conversions.ToString(num18) + "且DBID" + Conversions.ToString(num19) + "不能删除，不能找到单元！";
											StreamWriter streamWriter43 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter43.Write("\r\n    " + value);
											streamWriter43.Close();
											ProjectData.ClearProjectError();
										}
										break;
									}
									case "SetFuel":
									{
										float num6 = Conversions.ToSingle(xmlNode3.Name.Split('_')[1].Replace(",", "."));
										if (activeUnit_.IsAircraft)
										{
											((Aircraft)activeUnit_).FuelCapacitySet(num6);
											value = "设置燃料：" + Conversions.ToString(num6);
											StreamWriter streamWriter22 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter22.Write("\r\n    " + value);
											streamWriter22.Close();
										}
										else if (!activeUnit_.IsFacility && !activeUnit_.IsShip)
										{
										}
										break;
									}
									case "SensorAdd":
									{
										num = Conversions.ToInteger(xmlNode3.Name.Split('_')[1]);
										bool flag2 = false;
										bool flag3 = false;
										if (num <= 0)
										{
											break;
										}
										string string_7 = "SELECT Name from DataSensor where ID = " + Conversions.ToString(num);
										if (DBCache.GetDatatable(sqliteHelper_, string_7).Rows.Count == 0)
										{
											value = "错误：带有DBID的弹药库" + Conversions.ToString(num) + "不能添加，也不能在数据库中找到！";
											StreamWriter streamWriter50 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter50.Write("\r\n    " + value);
											streamWriter50.Close();
											break;
										}
										int int_ = num;
										SQLiteConnection sqliteConnection_3 = activeUnit_.ParentScen.DBConnection;
										Sensor sensor4 = DBFunctions.GetSensor(int_, ref sqliteConnection_3);
										activeUnit_.AddSensor(sensor4);
										sensor4.ParentPlatform = activeUnit_;
										try
										{
											enumerator5 = xmlNode3.ChildNodes.GetEnumerator();
											while (enumerator5.MoveNext())
											{
												XmlNode xmlNode_3 = (XmlNode)enumerator5.Current;
												switch (xmlNode_3.Name)
												{
												case "Cov_Ill":
												case "Coverage_Illuminate":
													sensor4.Coverage_Illuminate = PlatformComponent._Coverage.FromXML(ref xmlNode_3);
													flag3 = true;
													break;
												case "Cov":
												case "Coverage":
													sensor4.Coverage = PlatformComponent._Coverage.FromXML(ref xmlNode_3);
													flag2 = true;
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
										value = "添加传感器，DBID：" + Conversions.ToString(num) + " 名称: " + sensor4.Name;
										StreamWriter streamWriter51 = File.AppendText(GameGeneral.SBRLogFilePath);
										streamWriter51.Write("\r\n    " + value);
										streamWriter51.Close();
										if (!flag2)
										{
											value = "错误：带有DBID的传感器" + Conversions.ToString(num) + "没有设置角度！";
											StreamWriter streamWriter52 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter52.Write("\r\n    " + value);
											streamWriter52.Close();
										}
										if (!flag3)
										{
											value = "错误：带有DBID的传感器" + Conversions.ToString(num) + "没有设置照射角度！";
											StreamWriter streamWriter53 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter53.Write("\r\n    " + value);
											streamWriter53.Close();
										}
										break;
									}
									case "MountRemove":
									{
										int num16 = Conversions.ToInteger(xmlNode3.Name.Split('_')[1]);
										int num17;
										try
										{
											num17 = Conversions.ToInteger(xmlNode3.Name.Split('_')[2]);
										}
										catch (Exception projectError7)
										{
											ProjectData.SetProjectError(projectError7);
											num17 = 0;
											if (num16 != 0)
											{
												value = "错误：挂载索引" + Conversions.ToString(num16) + " HAS NO DBID LISTED (Example: <MountRemove_<MountIndex>_<MountDBID> ). THIS MAY CAUSE THE WRONG MOUNT TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE MOUNT INDEX!";
												StreamWriter streamWriter38 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter38.Write("\r\n    " + value);
												streamWriter38.Close();
											}
											ProjectData.ClearProjectError();
										}
										if (num16 <= 0)
										{
											break;
										}
										try
										{
											if (activeUnit_.Mounts[num16 - 1].DBID == num17)
											{
												string name13 = activeUnit_.Mounts[num16 - 1].Name;
												list.Add(new Tuple<string, int, int, string>(text6, num16, num17, name13));
												break;
											}
											value = "错误：挂载索引" + Conversions.ToString(num16) + " 的单元没有DBID " + Conversions.ToString(num17);
											StreamWriter streamWriter39 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter39.Write("\r\n    " + value);
											streamWriter39.Close();
										}
										catch (Exception projectError8)
										{
											ProjectData.SetProjectError(projectError8);
											value = "错误：挂载索引" + Conversions.ToString(num16) + "且DBID" + Conversions.ToString(num17) + "不能删除，不能找到单元！";
											StreamWriter streamWriter40 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter40.Write("\r\n    " + value);
											streamWriter40.Close();
											ProjectData.ClearProjectError();
										}
										break;
									}
									case "CommRemove":
									{
										int num11 = Conversions.ToInteger(xmlNode3.Name.Split('_')[1]);
										int num13;
										try
										{
											num13 = Conversions.ToInteger(xmlNode3.Name.Split('_')[2]);
										}
										catch (Exception projectError5)
										{
											ProjectData.SetProjectError(projectError5);
											num13 = 0;
											if (num11 != 0)
											{
												value = "错误：通信设备索引" + Conversions.ToString(num11) + " 没有在列出的DBID中 (例如: <CommRemove_<CommIndex>_<CommDBID>)，当数据库升级时如果修改了通信设备索引可能导致通信设备被删除。";
												StreamWriter streamWriter29 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter29.Write("\r\n    " + value);
												streamWriter29.Close();
											}
											ProjectData.ClearProjectError();
										}
										if (num11 <= 0)
										{
											break;
										}
										try
										{
											if (num13 == activeUnit_.Comms_ReadOnly[num11 - 1].DBID)
											{
												string name12 = activeUnit_.Comms_ReadOnly[num11 - 1].Name;
												list.Add(new Tuple<string, int, int, string>(text6, num11, num13, name12));
												break;
											}
											value = "错误：通信设备索引为" + Conversions.ToString(num11) + " 的单元没有DBID " + Conversions.ToString(num13);
											StreamWriter streamWriter30 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter30.Write("\r\n    " + value);
											streamWriter30.Close();
										}
										catch (Exception projectError6)
										{
											ProjectData.SetProjectError(projectError6);
											value = "错误：通信设备索引为" + Conversions.ToString(num11) + "且DBID" + Conversions.ToString(num13) + "不能删除，不能找到单元！";
											StreamWriter streamWriter31 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter31.Write("\r\n    " + value);
											streamWriter31.Close();
											ProjectData.ClearProjectError();
										}
										break;
									}
									case "SensorRemove":
									{
										int num5 = Conversions.ToInteger(xmlNode3.Name.Split('_')[1]);
										try
										{
											num = Conversions.ToInteger(xmlNode3.Name.Split('_')[2]);
										}
										catch (Exception projectError20)
										{
											ProjectData.SetProjectError(projectError20);
											num = 0;
											if (num5 != 0)
											{
												value = "错误：传感器索引为" + Conversions.ToString(num5) + " HAS NO DBID LISTED (Example: <SensorRemove_<SensorIndex>_<SensorDBID> ). THIS MAY CAUSE THE WRONG SENSOR TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE SENSOR INDEX!";
												StreamWriter streamWriter19 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter19.Write("\r\n    " + value);
												streamWriter19.Close();
											}
											ProjectData.ClearProjectError();
										}
										if (num5 <= 0)
										{
											break;
										}
										try
										{
											if (num == activeUnit_.Sensors_ReadOnly()[num5 - 1].DBID)
											{
												string name11 = activeUnit_.Sensors_ReadOnly()[num5 - 1].Name;
												list.Add(new Tuple<string, int, int, string>(text6, num5, num, name11));
												break;
											}
											value = "错误：传感器索引为" + Conversions.ToString(num5) + " 的单元没有DBID " + Conversions.ToString(num);
											StreamWriter streamWriter20 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter20.Write("\r\n    " + value);
											streamWriter20.Close();
										}
										catch (Exception projectError2)
										{
											ProjectData.SetProjectError(projectError2);
											value = "错误：传感器索引为" + Conversions.ToString(num5) + "且DBID" + Conversions.ToString(num) + "不能删除，不能找到单元！";
											StreamWriter streamWriter21 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter21.Write("\r\n    " + value);
											streamWriter21.Close();
											ProjectData.ClearProjectError();
										}
										break;
									}
									case "#comment":
									{
										value = xmlNode3.InnerText;
										StreamWriter streamWriter18 = File.AppendText(GameGeneral.SBRLogFilePath);
										streamWriter18.Write("  --  " + value);
										streamWriter18.Close();
										break;
									}
									case "AirOpsRemove":
									{
										int num30 = Conversions.ToInteger(xmlNode3.Name.Split('_')[1]);
										int num2;
										try
										{
											num2 = Conversions.ToInteger(xmlNode3.Name.Split('_')[2]);
										}
										catch (Exception projectError16)
										{
											ProjectData.SetProjectError(projectError16);
											num2 = 0;
											if (num30 != 0)
											{
												value = "ERROR: AIR FACILITY WITH INDEX " + Conversions.ToString(num30) + " HAS NO DBID LISTED (Example: <AirOpsRemove_<Index>_<DBID> ). THIS MAY CAUSE THE WRONG FACILITY TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE INDEX!";
												StreamWriter streamWriter8 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter8.Write("\r\n    " + value);
												streamWriter8.Close();
											}
											ProjectData.ClearProjectError();
										}
										if (num30 <= 0)
										{
											break;
										}
										try
										{
											if (num2 == activeUnit_.AirFacilities_ReadOnly[num30 - 1].DBID)
											{
												string name8 = activeUnit_.AirFacilities_ReadOnly[num30 - 1].Name;
												list.Add(new Tuple<string, int, int, string>(text6, num30, num2, name8));
												break;
											}
											value = "ERROR: AIR FACILITY WITH INDEX " + Conversions.ToString(num30) + " 的单元没有DBID " + Conversions.ToString(num2);
											StreamWriter streamWriter9 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter9.Write("\r\n    " + value);
											streamWriter9.Close();
										}
										catch (Exception projectError17)
										{
											ProjectData.SetProjectError(projectError17);
											value = "ERROR: AIR FACILITY WITH INDEX " + Conversions.ToString(num30) + "且DBID" + Conversions.ToString(num2) + "不能删除，不能找到单元！";
											StreamWriter streamWriter10 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter10.Write("\r\n    " + value);
											streamWriter10.Close();
											ProjectData.ClearProjectError();
										}
										break;
									}
									case "SensorMountRemove":
									{
										int num27 = Conversions.ToInteger(xmlNode3.Name.Split('_')[1]);
										int num28;
										try
										{
											num28 = Conversions.ToInteger(xmlNode3.Name.Split('_')[2]);
											num = Conversions.ToInteger(xmlNode3.Name.Split('_')[3]);
										}
										catch (Exception projectError14)
										{
											ProjectData.SetProjectError(projectError14);
											num28 = 0;
											if (num27 != 0)
											{
												value = "错误：挂载索引" + Conversions.ToString(num27) + " HAS NO DBID LISTED (Example: <MountRemove_<MountIndex>_<MountDBID> ). THIS MAY CAUSE THE WRONG MOUNT TO BE DELETED IN CASE A DATABASE UPDATE ALTERS THE MOUNT INDEX!";
												StreamWriter streamWriter3 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter3.Write("\r\n    " + value);
												streamWriter3.Close();
											}
											ProjectData.ClearProjectError();
										}
										if (num27 <= 0)
										{
											break;
										}
										try
										{
											if (activeUnit_.Mounts[num27 - 1].DBID == num28)
											{
												Mount mount = activeUnit_.Mounts[num27 - 1];
												_ = mount.Name;
												if (mount.Sensors_ReadOnly.Count() <= 0)
												{
													break;
												}
												Sensor[] array = mount.Sensors_ReadOnly;
												Sensor[] array10 = array;
												foreach (Sensor sensor2 in array10)
												{
													if (sensor2.DBID == num)
													{
														mount.RemoveSensor(sensor2);
														value = "Removed sensor from mount (" + mount.Name + "), DBID: " + Conversions.ToString(num) + " 名称: " + sensor2.Name;
														StreamWriter streamWriter4 = File.AppendText(GameGeneral.SBRLogFilePath);
														streamWriter4.Write("\r\n    " + value);
														streamWriter4.Close();
														break;
													}
												}
												break;
											}
											value = "错误：挂载索引" + Conversions.ToString(num27) + " 的单元没有DBID " + Conversions.ToString(num28);
											StreamWriter streamWriter5 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter5.Write("\r\n    " + value);
											streamWriter5.Close();
										}
										catch (Exception projectError15)
										{
											ProjectData.SetProjectError(projectError15);
											value = "错误：挂载索引" + Conversions.ToString(num27) + "且DBID" + Conversions.ToString(num28) + "不能删除，不能找到单元！";
											StreamWriter streamWriter6 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter6.Write("\r\n    " + value);
											streamWriter6.Close();
											ProjectData.ClearProjectError();
										}
										break;
									}
									case "DockAdd":
									{
										int num12 = Conversions.ToInteger(xmlNode3.Name.Split('_')[1]);
										if (num12 > 0)
										{
											SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
											DockFacility dockFacility = DBFunctions.GetDockFacility(num12, ref sqliteConnection_);
											if (dockFacility == null)
											{
												value = "ERROR: DOCK WITH DBID " + Conversions.ToString(num12) + "不能添加，也不能在数据库中找到！";
												StreamWriter streamWriter34 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter34.Write("\r\n    " + value);
												streamWriter34.Close();
											}
											else
											{
												activeUnit_.AddDockFacility(dockFacility);
												dockFacility.ParentPlatform = activeUnit_;
												value = "Added dock, DBID: " + Conversions.ToString(num12) + " 名称: " + dockFacility.Name;
												StreamWriter streamWriter45 = File.AppendText(GameGeneral.SBRLogFilePath);
												streamWriter45.Write("\r\n    " + value);
												streamWriter45.Close();
											}
										}
										break;
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
							if (list.Count <= 0)
							{
								continue;
							}
							foreach (Tuple<string, int, int, string> item6 in list)
							{
								switch (item6.Item1)
								{
								case "MagRemove":
								{
									int item8 = item6.Item2;
									int item9 = item6.Item3;
									if (item8 > 0)
									{
										if (activeUnit_.SharedMagazines[item8 - 1].DBID == item9)
										{
											string name2 = activeUnit_.SharedMagazines[item8 - 1].Name;
											((Platform)activeUnit_).RemoveSharedMagazine(activeUnit_.SharedMagazines[item8 - 1]);
											value = "用索引删除了Mag" + Conversions.ToString(item8) + "，DBID：" + Conversions.ToString(item9) + " 名称: " + name2;
											StreamWriter streamWriter57 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter57.Write("\r\n    " + value);
											streamWriter57.Close();
										}
										else
										{
											value = "错误：弹药库索引" + Conversions.ToString(item8) + " 的单元没有DBID " + Conversions.ToString(item9);
											StreamWriter streamWriter58 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter58.Write("\r\n    " + value);
											streamWriter58.Close();
										}
									}
									break;
								}
								case "DockRemove":
								{
									int item12 = item6.Item2;
									int item13 = item6.Item3;
									if (item12 > 0)
									{
										if (item13 == activeUnit_.DockFacilities_ReadOnly[item12 - 1].DBID)
										{
											string name4 = activeUnit_.DockFacilities_ReadOnly[item12 - 1].Name;
											activeUnit_.RemoveDockFacility(activeUnit_.DockFacilities_ReadOnly[item12 - 1]);
											value = "Removed Dock Facility with index " + Conversions.ToString(item12) + "，DBID：" + Conversions.ToString(item13) + " 名称: " + name4;
											StreamWriter streamWriter60 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter60.Write("\r\n    " + value);
											streamWriter60.Close();
										}
										else
										{
											value = "ERROR: DOCK FACILITY WITH INDEX " + Conversions.ToString(item12) + " 的单元没有DBID " + Conversions.ToString(item13);
											StreamWriter streamWriter61 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter61.Write("\r\n    " + value);
											streamWriter61.Close();
										}
									}
									break;
								}
								case "MCMRemove":
								{
									int item4 = item6.Item2;
									num = item6.Item3;
									if (item4 > 0)
									{
										if (num == activeUnit_.MineCountermeasures[item4 - 1].DBID)
										{
											string name7 = activeUnit_.MineCountermeasures[item4 - 1].Name;
											activeUnit_.RemoveSensor(activeUnit_.MineCountermeasures[item4 - 1]);
											value = "Removed MCM Sensor with index " + Conversions.ToString(item4) + "，DBID：" + Conversions.ToString(num) + " 名称: " + name7;
											StreamWriter streamWriter66 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter66.Write("\r\n    " + value);
											streamWriter66.Close();
										}
										else
										{
											value = "错误：传感器索引为" + Conversions.ToString(item4) + " 的单元没有DBID " + Conversions.ToString(num);
											StreamWriter streamWriter68 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter68.Write("\r\n    " + value);
											streamWriter68.Close();
										}
									}
									break;
								}
								case "SensorRemove":
								{
									int item3 = item6.Item2;
									num = item6.Item3;
									if (item3 > 0)
									{
										if (num == activeUnit_.Sensors_ReadOnly()[item3 - 1].DBID)
										{
											string name6 = activeUnit_.Sensors_ReadOnly()[item3 - 1].Name;
											activeUnit_.RemoveSensor(activeUnit_.Sensors_ReadOnly()[item3 - 1]);
											value = "删除了传感器索引为" + Conversions.ToString(item3) + "，DBID：" + Conversions.ToString(num) + " 名称: " + name6;
											StreamWriter streamWriter64 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter64.Write("\r\n    " + value);
											streamWriter64.Close();
										}
										else
										{
											value = "错误：传感器索引为" + Conversions.ToString(item3) + " 的单元没有DBID " + Conversions.ToString(num);
											StreamWriter streamWriter65 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter65.Write("\r\n    " + value);
											streamWriter65.Close();
										}
									}
									break;
								}
								case "MountRemove":
								{
									int item10 = item6.Item2;
									int item11 = item6.Item3;
									if (item10 > 0)
									{
										string name3 = activeUnit_.Mounts[item10 - 1].Name;
										activeUnit_.Mounts.Remove(activeUnit_.Mounts[item10 - 1]);
										value = "删除了带索引的挂载" + Conversions.ToString(item10) + "，DBID：" + Conversions.ToString(item11) + " 名称: " + name3;
										StreamWriter streamWriter59 = File.AppendText(GameGeneral.SBRLogFilePath);
										streamWriter59.Write("\r\n    " + value);
										streamWriter59.Close();
									}
									break;
								}
								case "AirOpsRemove":
								{
									int item14 = item6.Item2;
									int item2 = item6.Item3;
									if (item14 > 0)
									{
										if (item2 == activeUnit_.AirFacilities_ReadOnly[item14 - 1].DBID)
										{
											string name5 = activeUnit_.AirFacilities_ReadOnly[item14 - 1].Name;
											activeUnit_.RemoveAirFacility(activeUnit_.AirFacilities_ReadOnly[item14 - 1]);
											value = "Removed Air Facility with index " + Conversions.ToString(item14) + "，DBID：" + Conversions.ToString(item2) + " 名称: " + name5;
											StreamWriter streamWriter62 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter62.Write("\r\n    " + value);
											streamWriter62.Close();
										}
										else
										{
											value = "ERROR: AIR FACILITY WITH INDEX " + Conversions.ToString(item14) + " 的单元没有DBID " + Conversions.ToString(item2);
											StreamWriter streamWriter63 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter63.Write("\r\n    " + value);
											streamWriter63.Close();
										}
									}
									break;
								}
								case "CommRemove":
								{
									int item = item6.Item2;
									int item7 = item6.Item3;
									if (item > 0)
									{
										if (item7 == activeUnit_.Comms_ReadOnly[item - 1].DBID)
										{
											string name15 = activeUnit_.Comms_ReadOnly[item - 1].Name;
											activeUnit_.RemoveCommDevice(activeUnit_.Comms_ReadOnly[item - 1]);
											value = "删除了通信设备索引为" + Conversions.ToString(item) + "，DBID：" + Conversions.ToString(item7) + " 名称: " + name15;
											StreamWriter streamWriter54 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter54.Write("\r\n    " + value);
											streamWriter54.Close();
										}
										else
										{
											value = "错误：通信设备索引为" + Conversions.ToString(item) + " 的单元没有DBID " + Conversions.ToString(item7);
											StreamWriter streamWriter55 = File.AppendText(GameGeneral.SBRLogFilePath);
											streamWriter55.Write("\r\n    " + value);
											streamWriter55.Close();
										}
									}
									break;
								}
								}
							}
							continue;
						}
						value = "错误：没有单元DBID为" + Conversions.ToString(activeUnit_.DBID) + " FOUND IN DATABASE!\r\n";
						StreamWriter streamWriter69 = File.AppendText(GameGeneral.SBRLogFilePath);
						streamWriter69.Write("\r\n  " + value);
						streamWriter69.Close();
						break;
					}
					return;
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
			}
			string text7 = "错误：找不到INI配置文件！";
			StreamWriter streamWriter70 = File.AppendText(GameGeneral.SBRLogFilePath);
			streamWriter70.Write("\r\n  " + text7);
			streamWriter70.Close();
			GameGeneral.ResolveBridge("找不到XML数据。", null);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101118", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
