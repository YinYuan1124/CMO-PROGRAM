using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class FerryMission : Mission
{
	public enum FerryMissionBehavior : byte
	{
		OneWay,
		Cycle,
		Random
	}

	private FerryMissionBehavior m_ParserClient;

	private ActiveUnit _AlgoClient;

	private string _DatabaseClient;

	public _FlightQty MinimumNumberOfAircraft;

	public ActiveUnit.Throttle? FerryThrottle_Aircraft;

	public float? FerryAltitude_Aircraft;

	public bool FerryTerrainFollowing_Aircraft;

	public ActiveUnit.Throttle? FerryThrottle_Ship;

	public ActiveUnit.Throttle? FerryThrottle_Submarine;

	public float? FerryAltitude_Submarine;

	public _AircraftFormationType Formation_Cruise;

	public FerryMissionBehavior Behavior
	{
		get
		{
			return m_ParserClient;
		}
		set
		{
			m_ParserClient = value;
		}
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, ref Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("FerryMission");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Name", Name);
			xmlWriter_0.WriteElementString("Category", ((byte)Category).ToString());
			method_0(ref xmlWriter_0, ref hashSet_0, ref scenario_0);
			XmlWriter obj = xmlWriter_0;
			byte parserClient = (byte)m_ParserClient;
			obj.WriteElementString("Behavior", parserClient.ToString());
			Doctrine.ToXML(ref xmlWriter_0, ref scenario_0);
			if (_StartTime.HasValue)
			{
				xmlWriter_0.WriteElementString("START", _StartTime.Value.ToBinary().ToString());
			}
			if (_EndTime.HasValue)
			{
				xmlWriter_0.WriteElementString("END", _EndTime.Value.ToBinary().ToString());
			}
			if (_TakeOffTime.HasValue)
			{
				xmlWriter_0.WriteElementString("TakeOffTime", _TakeOffTime.Value.ToBinary().ToString());
			}
			if (_TimeOnTarget.HasValue)
			{
				xmlWriter_0.WriteElementString("TimeOnTarget", _TimeOnTarget.Value.ToBinary().ToString());
			}
			xmlWriter_0.WriteElementString("Deactivation_UnassignUnits", Deactivation_UnassignUnits.ToString());
			xmlWriter_0.WriteElementString("CheckBox_OrderRTB", Deactivation_OrderRTB.ToString());
			xmlWriter_0.WriteElementString("CheckBox_DeleteMission", Deactivation_DeleteMission.ToString());
			xmlWriter_0.WriteElementString("SISIH", ScrubIfSideIsHuman.ToString());
			xmlWriter_0.WriteElementString("UseFlightplan", UseFlightplans.ToString());
			xmlWriter_0.WriteElementString("UseFlightplansOnly", UsePreGeneratedFlightplansOnly.ToString());
			xmlWriter_0.WriteElementString("IncludeInATO", IncludeInATO.ToString());
			xmlWriter_0.WriteElementString("NDH", _DatabaseClient);
			if (GetStatus(scenario_0) != 0)
			{
				xmlWriter_0.WriteElementString("Status", ((byte)GetStatus(scenario_0)).ToString());
			}
			if (FerryThrottle_Aircraft.HasValue)
			{
				xmlWriter_0.WriteElementString("FerryThrottle_Aircraft", Conversions.ToString((int)FerryThrottle_Aircraft.Value));
			}
			if (FerryAltitude_Aircraft.HasValue)
			{
				xmlWriter_0.WriteElementString("FerryAltitude_Aircraft", FerryAltitude_Aircraft.Value.ToString());
			}
			xmlWriter_0.WriteElementString("FerryTerrainFollowing_Aircraft", FerryTerrainFollowing_Aircraft.ToString());
			if (FerryThrottle_Ship.HasValue)
			{
				xmlWriter_0.WriteElementString("FerryThrottle_Ship", Conversions.ToString((int)FerryThrottle_Ship.Value));
			}
			if (FerryThrottle_Submarine.HasValue)
			{
				xmlWriter_0.WriteElementString("FerryThrottle_Submarine", Conversions.ToString((int)FerryThrottle_Submarine.Value));
			}
			if (FerryAltitude_Submarine.HasValue)
			{
				xmlWriter_0.WriteElementString("FerryAltitude_Submarine", FerryAltitude_Submarine.Value.ToString());
			}
			xmlWriter_0.WriteElementString("FlightSize", ((int)base.FlightSize).ToString());
			XmlWriter obj2 = xmlWriter_0;
			int formation_Cruise = (int)Formation_Cruise;
			obj2.WriteElementString("Formation_Cruise", formation_Cruise.ToString());
			XmlWriter obj3 = xmlWriter_0;
			formation_Cruise = (int)MinimumNumberOfAircraft;
			obj3.WriteElementString("MinAircraftReq", formation_Cruise.ToString());
			xmlWriter_0.WriteElementString("UseFlightSizeHardLimit", UseFlightSizeHardLimit.ToString());
			if (SecondaryAirBase != null)
			{
				xmlWriter_0.WriteElementString("HomeAirbase", SecondaryAirBase.ObjectID.ToString());
			}
			if (SecondaryNavalBase != null)
			{
				xmlWriter_0.WriteElementString("HomeNavalbase", SecondaryNavalBase.ObjectID.ToString());
			}
			XmlWriter obj4 = xmlWriter_0;
			parserClient = (byte)TankerUsage;
			obj4.WriteElementString("TankerUsage", parserClient.ToString());
			xmlWriter_0.WriteStartElement("TankerMissionList");
			foreach (Mission tankerMission in TankerMissions)
			{
				if (!Information.IsNothing(tankerMission))
				{
					xmlWriter_0.WriteElementString("ID", tankerMission.ObjectID);
				}
			}
			xmlWriter_0.WriteEndElement();
			if (LaunchMissionWithoutTankersInPlace)
			{
				xmlWriter_0.WriteElementString("LaunchMissionWithoutTankersInPlace", LaunchMissionWithoutTankersInPlace.ToString());
			}
			xmlWriter_0.WriteElementString("TankerMinNumber_Total", TankerMinNumber_Total.ToString());
			xmlWriter_0.WriteElementString("TankerMinNumber_Airborne", TankerMinNumber_Airborne.ToString());
			xmlWriter_0.WriteElementString("TankerMinNumber_Station", TankerMinNumber_Station.ToString());
			xmlWriter_0.WriteElementString("MaxReceiversInQueuePerTanker_Airborne", MaxReceiversInQueuePerTanker_Airborne.ToString());
			xmlWriter_0.WriteElementString("FuelQtyToStartLookingForTanker_Airborne", FuelQtyToStartLookingForTanker_Airborne.ToString());
			xmlWriter_0.WriteElementString("TankerMaxDistance_Airborne", TankerMaxDistance_Airborne.ToString());
			xmlWriter_0.WriteElementString("TankerFollowsReceivers", TankerFollowsReceivers.ToString());
			if (RestartValue())
			{
				Flight.ToXML(ref xmlWriter_0, ref hashSet_0, ref scenario_0, ref FlightList);
			}
			if (!Information.IsNothing(EmptySlotsList) && EmptySlotsList.Count > 0)
			{
				EmptyAircraftSlot.ToXML(ref xmlWriter_0, ref hashSet_0, ref scenario_0, ref EmptySlotsList);
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100633", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private FerryMission(Side side_0, Scenario scenario_0, string string_0)
		: base(side_0, scenario_0, string_0)
	{
		IsMission = true;
		MissionClass = _MissionClass.Ferry;
	}

	public static FerryMission FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			FerryMission ferryMission = new FerryMission(null, scenario_0, "");
			bool flag = false;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				IEnumerator enumerator3 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode_ = (XmlNode)enumerator.Current;
					Mission.FromXMLCommon(ferryMission, xmlNode_);
					switch (xmlNode_.Name)
					{
					case "Name":
						ferryMission.Name = xmlNode_.InnerText;
						break;
					case "START":
					{
						DateTime value3 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						ferryMission._StartTime = value3;
						break;
					}
					case "Status":
						ferryMission.SetStatus(scenario_0, (MissionStatus)Conversions.ToByte(xmlNode_.InnerText));
						break;
					case "SISIH":
						ferryMission.ScrubIfSideIsHuman = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "UseFlightplan":
						ferryMission.UseFlightplans = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "IncludeInATO":
						ferryMission.IncludeInATO = Conversions.ToBoolean(xmlNode_.InnerText);
						flag = true;
						break;
					case "TankerMaxDistance_Airborne":
						ferryMission.TankerMaxDistance_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TankerMinNumber_Airborne":
						ferryMission.TankerMinNumber_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Behavior":
						ferryMission.m_ParserClient = (FerryMissionBehavior)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TankerMinNumber_Total":
						ferryMission.TankerMinNumber_Total = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "UseFlightplansOnly":
						ferryMission.UsePreGeneratedFlightplansOnly = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "LaunchMissionWithoutTankersInPlace":
						ferryMission.LaunchMissionWithoutTankersInPlace = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "HomeNavalbase":
						ferryMission._SecondaryNavalBaseID = xmlNode_.InnerText;
						break;
					case "TimeOnTarget":
					{
						DateTime value4 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						ferryMission.TimeOnTarget = value4;
						break;
					}
					case "EmptySlotsList":
						ferryMission.EmptySlotsList = EmptyAircraftSlot.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode_.InnerText))
						{
							ferryMission.ObjectID_Set(xmlNode_.InnerText);
							concurrentDictionary_0.TryAdd(ferryMission.ObjectID, ferryMission);
							break;
						}
						return (FerryMission)concurrentDictionary_0[xmlNode_.InnerText];
					case "Doctrine":
						ferryMission.Doctrine = Doctrine.FromXML(ref xmlNode_, ferryMission);
						break;
					case "TankerMinNumber_Station":
						ferryMission.TankerMinNumber_Station = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "FerryAltitude_Submarine":
						ferryMission.FerryAltitude_Submarine = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "TakeOffTime":
					{
						DateTime value2 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						ferryMission.TakeOffTime = value2;
						break;
					}
					case "CheckBox_OrderRTB":
						ferryMission.Deactivation_OrderRTB = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "FerryTerrainFollowing_Aircraft":
						ferryMission.FerryTerrainFollowing_Aircraft = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Deactivation_UnassignUnits":
						ferryMission.Deactivation_UnassignUnits = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "FlightList":
						ferryMission.FlightList = Flight.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
						break;
					case "FerryThrottle_Ship":
						ferryMission.FerryThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "FuelQtyToStartLookingForTanker_Airborne":
						ferryMission.FuelQtyToStartLookingForTanker_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "FerryThrottle":
					case "FerryThrottle_Aircraft":
						ferryMission.FerryThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "UseFlightSizeHardLimit":
						ferryMission.UseFlightSizeHardLimit = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "FlightSize":
						ferryMission.FlightSize = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TankerMissionList":
						try
						{
							enumerator3 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator3.Current;
								ferryMission.TankerMissions_IDs.Add(xmlNode2.InnerText);
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
					case "Category":
						ferryMission.Category = (MissionCategory)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "END":
					{
						DateTime value = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						ferryMission._EndTime = value;
						break;
					}
					case "HomeAirbase":
						ferryMission._SecondaryAirBaseID = xmlNode_.InnerText;
						break;
					case "_Phase":
						ferryMission._Phase = (MissionPhase)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "PriorityWeight":
						ferryMission.PriorityWeight = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "NDH":
					case "NominalDestinationHost":
						ferryMission._DatabaseClient = xmlNode_.InnerText;
						break;
					case "FerryAltitude":
					case "FerryAltitude_Aircraft":
						ferryMission.FerryAltitude_Aircraft = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "AssignedUnitsList":
						try
						{
							enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode = (XmlNode)enumerator2.Current;
								ferryMission.UnitsAssignedToMissionIDs.Add(xmlNode.InnerText);
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
					case "CheckBox_DeleteMission":
						ferryMission.Deactivation_DeleteMission = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "MinAircraftReq":
						ferryMission.MinimumNumberOfAircraft = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TankerFollowsReceivers":
						ferryMission.TankerFollowsReceivers = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TankerUsage":
						ferryMission.TankerUsage = (TankerMethod)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Completion":
						ferryMission.Completion = Conversions.ToSingle(xmlNode_.InnerText);
						break;
					case "Formation_Cruise":
						ferryMission.Formation_Cruise = (_AircraftFormationType)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "FerryThrottle_Submarine":
						ferryMission.FerryThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "MaxReceiversInQueuePerTanker_Airborne":
						ferryMission.MaxReceiversInQueuePerTanker_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
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
			byte? b = (byte?)ferryMission.FerryThrottle_Aircraft;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				ferryMission.FerryThrottle_Aircraft = ActiveUnit.Throttle.Cruise;
			}
			if (ferryMission.Doctrine.ReplenishmentSelection_Inherits())
			{
				ferryMission.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
			}
			if (!flag)
			{
				ferryMission.IncludeInATO = false;
			}
			return ferryMission;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100634", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			FerryMission result = new FerryMission(null, scenario_0, "");
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public override string GetDescriptionString(Scenario scenario_0)
	{
		string text = "转场任务";
		if (!Information.IsNothing(GetNominalDestinationHost(scenario_0)))
		{
			text = text + " - 目的地：" + GetNominalDestinationHost(scenario_0).Name;
		}
		return text + " (" + m_ParserClient.ToString() + ")";
	}

	[SpecialName]
	public ActiveUnit GetNominalDestinationHost(Scenario scenario_0)
	{
		if (Information.IsNothing(_AlgoClient))
		{
			if (!string.IsNullOrEmpty(_DatabaseClient))
			{
				_AlgoClient = scenario_0.ActiveUnits[_DatabaseClient];
			}
			return _AlgoClient;
		}
		return _AlgoClient;
	}

	[SpecialName]
	public void SetNominalDestinationHost(Scenario scenario_0, ActiveUnit activeUnit_0)
	{
		_AlgoClient = activeUnit_0;
		if (_AlgoClient == null)
		{
			_DatabaseClient = string.Empty;
		}
		else
		{
			_DatabaseClient = _AlgoClient.ObjectID;
		}
	}

	public FerryMission(Side side_0, Scenario scenario_0, string string_0, MissionCategory missionCategory_0, ActiveUnit activeUnit_0)
		: base(side_0, scenario_0, string_0)
	{
		IsMission = true;
		MissionClass = _MissionClass.Ferry;
		Name = string_0;
		Category = missionCategory_0;
		SetNominalDestinationHost(scenario_0, activeUnit_0);
		FerryThrottle_Aircraft = ActiveUnit.Throttle.Cruise;
		base.FlightSize = 4;
		UseFlightSizeHardLimit = true;
		IncludeInATO = false;
		Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
	}

	public override void Printout(StringBuilder stringBuilder_0)
	{
		throw new NotImplementedException();
	}

	public override Mission Clone()
	{
		FerryMission obj = (FerryMission)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Name = "[克隆]" + Name;
		return obj;
	}
}
