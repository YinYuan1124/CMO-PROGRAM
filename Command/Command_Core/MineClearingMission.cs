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

public sealed class MineClearingMission : Mission
{
	public List<ReferencePoint> Area;

	public List<ReferencePoint> Area_ChangeCheck;

	public List<ReferencePoint> Area_1nm_ChangeCheck;

	public List<ReferencePoint> Area_2nm_ChangeCheck;

	public List<ReferencePoint> Area_5nm_ChangeCheck;

	public List<ReferencePoint> Area_10nm_ChangeCheck;

	public List<ReferencePoint> Area_30nm_ChangeCheck;

	public List<ReferencePoint> Area_1nm_Buffered;

	public List<ReferencePoint> Area_2nm_Buffered;

	public List<ReferencePoint> Area_5nm_Buffered;

	public List<ReferencePoint> Area_10nm_Buffered;

	public List<ReferencePoint> Area_30nm_Buffered;

	public bool OneThirdRule;

	public _FlightQty MinimumNumberOfAircraft;

	public ActiveUnit.Throttle? TransitThrottle_Aircraft;

	public ActiveUnit.Throttle? StationThrottle_Aircraft;

	public float? TransitAltitude_Aircraft;

	public float? StationAltitude_Aircraft;

	public bool TransitTerrainFollowing_Aircraft;

	public bool StationTerrainFollowing_Aircraft;

	private ActiveUnit_AI.AircraftAltitudePreset? callbackConsumer;

	private ActiveUnit_AI.AircraftAltitudePreset? m_DecoratorConsumer;

	private bool? _ProcessConsumer;

	private bool? threadConsumer;

	private ActiveUnit_AI.SubmarineDepthPreset? ruleConsumer;

	private ActiveUnit_AI.SubmarineDepthPreset? collectionConsumer;

	private bool? m_InstanceConsumer;

	private bool? m_ObjectConsumer;

	public ActiveUnit.Throttle TransitThrottle_Submarine;

	public ActiveUnit.Throttle StationThrottle_Submarine;

	public float? TransitDepth_Submarine;

	public float? StationDepth_Submarine;

	public ActiveUnit.Throttle TransitThrottle_Ship;

	public ActiveUnit.Throttle StationThrottle_Ship;

	public ActiveUnit.Throttle TransitThrottle_Facility;

	public ActiveUnit.Throttle StationThrottle_Facility;

	public _AircraftFormationType Formation_Cruise;

	public _AircraftFormationType Formation_Attack;

	public MissionMovementStyle MovementStyle;

	public ActiveUnit_AI.AircraftAltitudePreset? TransitAltitude_Preset
	{
		get
		{
			return callbackConsumer;
		}
		set
		{
			callbackConsumer = value;
		}
	}

	public ActiveUnit_AI.AircraftAltitudePreset? StationAltitude_Preset
	{
		get
		{
			return m_DecoratorConsumer;
		}
		set
		{
			m_DecoratorConsumer = value;
		}
	}

	public bool? UseTransitAltitude_Preset
	{
		get
		{
			return _ProcessConsumer;
		}
		set
		{
			_ProcessConsumer = value;
		}
	}

	public bool? UseStationAltitude_Preset
	{
		get
		{
			return threadConsumer;
		}
		set
		{
			threadConsumer = value;
		}
	}

	public bool? UseStationDepth_Submarine_Preset
	{
		get
		{
			return m_ObjectConsumer;
		}
		set
		{
			m_ObjectConsumer = value;
		}
	}

	public bool? UseTransitDepth_Submarine_Preset
	{
		get
		{
			return m_InstanceConsumer;
		}
		set
		{
			m_InstanceConsumer = value;
		}
	}

	public ActiveUnit_AI.SubmarineDepthPreset? StationDepth_Submarine_Preset
	{
		get
		{
			return collectionConsumer;
		}
		set
		{
			collectionConsumer = value;
		}
	}

	public ActiveUnit_AI.SubmarineDepthPreset? TransitDepth_Submarine_Preset
	{
		get
		{
			return ruleConsumer;
		}
		set
		{
			ruleConsumer = value;
		}
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, ref Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("MineClearingMission");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Name", Name);
			xmlWriter_0.WriteElementString("Category", ((byte)Category).ToString());
			method_0(ref xmlWriter_0, ref hashSet_0, ref scenario_0);
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
			xmlWriter_0.WriteStartElement("Area");
			foreach (ReferencePoint item in Area)
			{
				xmlWriter_0.WriteRaw(item.ToXML(ref hashSet_0));
			}
			xmlWriter_0.WriteEndElement();
			XmlWriter obj = xmlWriter_0;
			int movementStyle = (int)MovementStyle;
			obj.WriteElementString("MovementStyle", movementStyle.ToString());
			xmlWriter_0.WriteElementString("OTR", OneThirdRule.ToString());
			xmlWriter_0.WriteElementString("SISIH", ScrubIfSideIsHuman.ToString());
			xmlWriter_0.WriteElementString("UseFlightplan", UseFlightplans.ToString());
			xmlWriter_0.WriteElementString("UseFlightplansOnly", UsePreGeneratedFlightplansOnly.ToString());
			xmlWriter_0.WriteElementString("IncludeInATO", IncludeInATO.ToString());
			if (SecondaryAirBase != null)
			{
				xmlWriter_0.WriteElementString("HomeAirbase", SecondaryAirBase.ObjectID.ToString());
			}
			if (SecondaryNavalBase != null)
			{
				xmlWriter_0.WriteElementString("HomeNavalbase", SecondaryNavalBase.ObjectID.ToString());
			}
			if (GetStatus(scenario_0) != 0)
			{
				xmlWriter_0.WriteElementString("Status", ((byte)GetStatus(scenario_0)).ToString());
			}
			Doctrine.ToXML(ref xmlWriter_0, ref scenario_0);
			if (TransitThrottle_Aircraft.HasValue)
			{
				xmlWriter_0.WriteElementString("TransitThrottle_Aircraft", Conversions.ToString((int)TransitThrottle_Aircraft.Value));
			}
			if (StationThrottle_Aircraft.HasValue)
			{
				xmlWriter_0.WriteElementString("StationThrottle_Aircraft", Conversions.ToString((int)StationThrottle_Aircraft.Value));
			}
			if (TransitAltitude_Aircraft.HasValue)
			{
				xmlWriter_0.WriteElementString("TransitAltitude_Aircraft", TransitAltitude_Aircraft.Value.ToString());
			}
			if (StationAltitude_Aircraft.HasValue)
			{
				xmlWriter_0.WriteElementString("StationAltitude_Aircraft", StationAltitude_Aircraft.Value.ToString());
			}
			xmlWriter_0.WriteElementString("TransitTerrainFollowing_Aircraft", TransitTerrainFollowing_Aircraft.ToString());
			xmlWriter_0.WriteElementString("StationTerrainFollowing_Aircraft", StationTerrainFollowing_Aircraft.ToString());
			XmlWriter obj4 = xmlWriter_0;
			byte transitThrottle_Submarine = (byte)TransitThrottle_Submarine;
			obj4.WriteElementString("TransitThrottle_Submarine", transitThrottle_Submarine.ToString());
			XmlWriter obj5 = xmlWriter_0;
			transitThrottle_Submarine = (byte)StationThrottle_Submarine;
			obj5.WriteElementString("StationThrottle_Submarine", transitThrottle_Submarine.ToString());
			if (TransitDepth_Submarine.HasValue)
			{
				xmlWriter_0.WriteElementString("TransitDepth_Submarine", TransitDepth_Submarine.Value.ToString());
			}
			if (StationDepth_Submarine.HasValue)
			{
				xmlWriter_0.WriteElementString("StationDepth_Submarine", StationDepth_Submarine.Value.ToString());
			}
			XmlWriter obj6 = xmlWriter_0;
			transitThrottle_Submarine = (byte)TransitThrottle_Ship;
			obj6.WriteElementString("TransitThrottle_Ship", transitThrottle_Submarine.ToString());
			XmlWriter obj7 = xmlWriter_0;
			transitThrottle_Submarine = (byte)StationThrottle_Ship;
			obj7.WriteElementString("StationThrottle_Ship", transitThrottle_Submarine.ToString());
			XmlWriter obj8 = xmlWriter_0;
			transitThrottle_Submarine = (byte)TransitThrottle_Facility;
			obj8.WriteElementString("TransitThrottle_Facility", transitThrottle_Submarine.ToString());
			XmlWriter obj9 = xmlWriter_0;
			transitThrottle_Submarine = (byte)StationThrottle_Facility;
			obj9.WriteElementString("StationThrottle_Facility", transitThrottle_Submarine.ToString());
			xmlWriter_0.WriteElementString("FlightSize", ((int)base.FlightSize).ToString());
			xmlWriter_0.WriteElementString("GroupSize", ((int)GroupSize).ToString());
			XmlWriter obj10 = xmlWriter_0;
			movementStyle = (int)Formation_Cruise;
			obj10.WriteElementString("Formation_Cruise", movementStyle.ToString());
			XmlWriter obj11 = xmlWriter_0;
			movementStyle = (int)Formation_Attack;
			obj11.WriteElementString("Formation_Attack", movementStyle.ToString());
			XmlWriter obj2 = xmlWriter_0;
			movementStyle = (int)MinimumNumberOfAircraft;
			obj2.WriteElementString("MinAircraftReq", movementStyle.ToString());
			xmlWriter_0.WriteElementString("UseFlightSizeHardLimit", UseFlightSizeHardLimit.ToString());
			xmlWriter_0.WriteElementString("UseGroupSizeHardLimit", UseGroupSizeHardLimit.ToString());
			if (UseStationAltitude_Preset.HasValue)
			{
				xmlWriter_0.WriteElementString("UseStationAltitude_Preset", ((byte)(-(UseStationAltitude_Preset.Value ? 1 : 0))).ToString());
			}
			if (UseTransitAltitude_Preset.HasValue)
			{
				xmlWriter_0.WriteElementString("UseTransitAltitude_Preset", ((byte)(-(UseTransitAltitude_Preset.Value ? 1 : 0))).ToString());
			}
			if (StationAltitude_Preset.HasValue)
			{
				xmlWriter_0.WriteElementString("StationAltitude_Preset", ((byte)StationAltitude_Preset.Value).ToString());
			}
			if (TransitAltitude_Preset.HasValue)
			{
				xmlWriter_0.WriteElementString("TransitAltitude_Preset", ((byte)TransitAltitude_Preset.Value).ToString());
			}
			if (TransitDepth_Submarine_Preset.HasValue)
			{
				xmlWriter_0.WriteElementString("TransitDepth_Submarine_Preset", ((byte)TransitDepth_Submarine_Preset.Value).ToString());
			}
			if (StationDepth_Submarine_Preset.HasValue)
			{
				xmlWriter_0.WriteElementString("StationDepth_Submarine_Preset", ((byte)StationDepth_Submarine_Preset.Value).ToString());
			}
			if (UseTransitDepth_Submarine_Preset.HasValue)
			{
				xmlWriter_0.WriteElementString("UseTransitDepth_Submarine_Preset", UseTransitDepth_Submarine_Preset.Value.ToString());
			}
			if (UseStationDepth_Submarine_Preset.HasValue)
			{
				xmlWriter_0.WriteElementString("UseStationDepth_Submarine_Preset", UseStationDepth_Submarine_Preset.Value.ToString());
			}
			XmlWriter obj3 = xmlWriter_0;
			transitThrottle_Submarine = (byte)TankerUsage;
			obj3.WriteElementString("TankerUsage", transitThrottle_Submarine.ToString());
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
			exception_?.Data.Add("Error at 100635", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static MineClearingMission FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		MineClearingMission result = null;
		try
		{
			MineClearingMission mineClearingMission = new MineClearingMission(null, scenario_0, "");
			bool flag = false;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				IEnumerator enumerator3 = null;
				IEnumerator enumerator4 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode_ = (XmlNode)enumerator.Current;
					Mission.FromXMLCommon(mineClearingMission, xmlNode_);
					switch (xmlNode_.Name)
					{
					case "Status":
						mineClearingMission.SetStatus(scenario_0, (MissionStatus)Conversions.ToByte(xmlNode_.InnerText));
						break;
					case "TransitTerrainFollowing_Aircraft":
						mineClearingMission.TransitTerrainFollowing_Aircraft = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TransitDepth_Submarine_Preset":
						mineClearingMission.TransitDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Name":
						mineClearingMission.Name = xmlNode_.InnerText;
						break;
					case "START":
					{
						DateTime value4 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						mineClearingMission._StartTime = value4;
						break;
					}
					case "UseFlightplan":
						mineClearingMission.UseFlightplans = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "IncludeInATO":
						mineClearingMission.IncludeInATO = Conversions.ToBoolean(xmlNode_.InnerText);
						flag = true;
						break;
					case "Area":
						try
						{
							enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator2.Current;
								mineClearingMission.Area.Add(ReferencePoint.FromXML(ref xmlNode_2, ref concurrentDictionary_0));
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
					case "SISIH":
						mineClearingMission.ScrubIfSideIsHuman = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TankerMinNumber_Airborne":
						mineClearingMission.TankerMinNumber_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "UseGroupSizeHardLimit":
						mineClearingMission.UseGroupSizeHardLimit = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TankerMaxDistance_Airborne":
						mineClearingMission.TankerMaxDistance_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "UseTransitDepth_Submarine_Preset":
						mineClearingMission.UseTransitDepth_Submarine_Preset = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "LaunchMissionWithoutTankersInPlace":
						mineClearingMission.LaunchMissionWithoutTankersInPlace = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TransitThrottle_Ship":
						mineClearingMission.TransitThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "UseFlightplansOnly":
						mineClearingMission.UsePreGeneratedFlightplansOnly = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "OTR":
					case "OneThirdRule":
						mineClearingMission.OneThirdRule = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "EmptySlotsList":
						mineClearingMission.EmptySlotsList = EmptyAircraftSlot.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
						break;
					case "TankerMinNumber_Total":
						mineClearingMission.TankerMinNumber_Total = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "StationThrottle_Ship":
						mineClearingMission.StationThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TimeOnTarget":
					{
						DateTime value3 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						mineClearingMission.TimeOnTarget = value3;
						break;
					}
					case "HomeNavalbase":
						mineClearingMission._SecondaryNavalBaseID = xmlNode_.InnerText;
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode_.InnerText))
						{
							mineClearingMission.ObjectID_Set(xmlNode_.InnerText);
							concurrentDictionary_0.TryAdd(mineClearingMission.ObjectID, mineClearingMission);
							break;
						}
						result = (MineClearingMission)concurrentDictionary_0[xmlNode_.InnerText];
						return result;
					case "Doctrine":
						mineClearingMission.Doctrine = Doctrine.FromXML(ref xmlNode_, mineClearingMission);
						break;
					case "TankerMinNumber_Station":
						mineClearingMission.TankerMinNumber_Station = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TakeOffTime":
					{
						DateTime value2 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						mineClearingMission.TakeOffTime = value2;
						break;
					}
					case "FlightList":
						mineClearingMission.FlightList = Flight.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
						break;
					case "StationThrottle_Facility":
						mineClearingMission.StationThrottle_Facility = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "FlightSize":
						mineClearingMission.FlightSize = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TankerMissionList":
						try
						{
							enumerator4 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator4.Current;
								mineClearingMission.TankerMissions_IDs.Add(xmlNode2.InnerText);
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
					case "FuelQtyToStartLookingForTanker_Airborne":
						mineClearingMission.FuelQtyToStartLookingForTanker_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "HomeAirbase":
						mineClearingMission._SecondaryAirBaseID = xmlNode_.InnerText;
						break;
					case "UseFlightSizeHardLimit":
						mineClearingMission.UseFlightSizeHardLimit = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TransitDepth_Submarine":
						mineClearingMission.TransitDepth_Submarine = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "UseTransitAltitude_Preset":
						mineClearingMission.UseTransitAltitude_Preset = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TransitThrottle_Facility":
						mineClearingMission.TransitThrottle_Facility = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TransitAltitude_Preset":
						mineClearingMission.TransitAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Category":
						mineClearingMission.Category = (MissionCategory)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "END":
					{
						DateTime value = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						mineClearingMission._EndTime = value;
						break;
					}
					case "Formation_Attack":
						mineClearingMission.Formation_Attack = (_AircraftFormationType)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "MovementStyle":
						mineClearingMission.MovementStyle = (MissionMovementStyle)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "_Phase":
						mineClearingMission._Phase = (MissionPhase)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "PriorityWeight":
						mineClearingMission.PriorityWeight = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "StationDepth_Submarine_Preset":
						mineClearingMission.StationDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "UseStationDepth_Submarine_Preset":
						mineClearingMission.UseStationDepth_Submarine_Preset = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TankerUsage":
						mineClearingMission.TankerUsage = (TankerMethod)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "AssignedUnitsList":
						try
						{
							enumerator3 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode = (XmlNode)enumerator3.Current;
								mineClearingMission.UnitsAssignedToMissionIDs.Add(xmlNode.InnerText);
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
					case "StationThrottle":
					case "StationThrottle_Aircraft":
						mineClearingMission.StationThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TankerFollowsReceivers":
						mineClearingMission.TankerFollowsReceivers = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "StationThrottle_Submarine":
						mineClearingMission.StationThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "MinAircraftReq":
						mineClearingMission.MinimumNumberOfAircraft = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "StationAltitude_Aircraft":
					case "StationAltitude":
						mineClearingMission.StationAltitude_Aircraft = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "GroupSize":
						mineClearingMission.GroupSize = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TransitAltitude":
					case "TransitAltitude_Aircraft":
						mineClearingMission.TransitAltitude_Aircraft = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Formation_Cruise":
						mineClearingMission.Formation_Cruise = (_AircraftFormationType)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "UseStationAltitude_Preset":
						mineClearingMission.UseStationAltitude_Preset = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Completion":
						mineClearingMission.Completion = Conversions.ToSingle(xmlNode_.InnerText);
						break;
					case "TransitThrottle_Submarine":
						mineClearingMission.TransitThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "MaxReceiversInQueuePerTanker_Airborne":
						mineClearingMission.MaxReceiversInQueuePerTanker_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "StationAltitude_Preset":
						mineClearingMission.StationAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "StationDepth_Submarine":
						mineClearingMission.StationDepth_Submarine = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "TransitThrottle":
					case "TransitThrottle_Aircraft":
						mineClearingMission.TransitThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "StationTerrainFollowing_Aircraft":
						mineClearingMission.StationTerrainFollowing_Aircraft = Conversions.ToBoolean(xmlNode_.InnerText);
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
			if (mineClearingMission.TransitThrottle_Submarine == ActiveUnit.Throttle.FullStop)
			{
				mineClearingMission.TransitTerrainFollowing_Aircraft = false;
				mineClearingMission.StationTerrainFollowing_Aircraft = false;
				mineClearingMission.TransitThrottle_Submarine = ActiveUnit.Throttle.Cruise;
				mineClearingMission.StationThrottle_Submarine = ActiveUnit.Throttle.Loiter;
				mineClearingMission.TransitThrottle_Ship = ActiveUnit.Throttle.Cruise;
				mineClearingMission.StationThrottle_Ship = ActiveUnit.Throttle.Loiter;
				mineClearingMission.TransitThrottle_Facility = ActiveUnit.Throttle.Cruise;
				mineClearingMission.StationThrottle_Facility = ActiveUnit.Throttle.Loiter;
			}
			if (mineClearingMission.Doctrine.ReplenishmentSelection_Inherits())
			{
				mineClearingMission.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
			}
			if (mineClearingMission.TransitAltitude_Aircraft.HasValue && mineClearingMission.UseTransitAltitude_Preset.GetValueOrDefault())
			{
				mineClearingMission.UseTransitAltitude_Preset = false;
				mineClearingMission.TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
			}
			if (mineClearingMission.StationAltitude_Aircraft.HasValue && mineClearingMission.UseStationAltitude_Preset.GetValueOrDefault())
			{
				mineClearingMission.UseStationAltitude_Preset = false;
				mineClearingMission.StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
			}
			if (mineClearingMission.TransitDepth_Submarine.HasValue && mineClearingMission.UseTransitDepth_Submarine_Preset.GetValueOrDefault())
			{
				mineClearingMission.UseTransitDepth_Submarine_Preset = false;
				mineClearingMission.TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
			}
			if (mineClearingMission.StationDepth_Submarine.HasValue && mineClearingMission.UseStationDepth_Submarine_Preset.GetValueOrDefault())
			{
				mineClearingMission.UseStationDepth_Submarine_Preset = false;
				mineClearingMission.StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
			}
			if (!flag)
			{
				mineClearingMission.IncludeInATO = false;
			}
			result = mineClearingMission;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100636", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private MineClearingMission(Side side_0, Scenario scenario_0, string string_0)
		: base(side_0, scenario_0, string_0)
	{
		Area = new List<ReferencePoint>();
		Area_ChangeCheck = new List<ReferencePoint>();
		Area_1nm_ChangeCheck = new List<ReferencePoint>();
		Area_2nm_ChangeCheck = new List<ReferencePoint>();
		Area_5nm_ChangeCheck = new List<ReferencePoint>();
		Area_10nm_ChangeCheck = new List<ReferencePoint>();
		Area_30nm_ChangeCheck = new List<ReferencePoint>();
		Area_1nm_Buffered = new List<ReferencePoint>();
		Area_2nm_Buffered = new List<ReferencePoint>();
		Area_5nm_Buffered = new List<ReferencePoint>();
		Area_10nm_Buffered = new List<ReferencePoint>();
		Area_30nm_Buffered = new List<ReferencePoint>();
		IsMission = true;
		MissionClass = _MissionClass.MineClearing;
	}

	public MineClearingMission(Side side_0, Scenario scenario_0, string string_0, MissionCategory missionCategory_0, List<ReferencePoint> list_0, bool bool_0)
		: base(side_0, scenario_0, string_0)
	{
		Area = new List<ReferencePoint>();
		Area_ChangeCheck = new List<ReferencePoint>();
		Area_1nm_ChangeCheck = new List<ReferencePoint>();
		Area_2nm_ChangeCheck = new List<ReferencePoint>();
		Area_5nm_ChangeCheck = new List<ReferencePoint>();
		Area_10nm_ChangeCheck = new List<ReferencePoint>();
		Area_30nm_ChangeCheck = new List<ReferencePoint>();
		Area_1nm_Buffered = new List<ReferencePoint>();
		Area_2nm_Buffered = new List<ReferencePoint>();
		Area_5nm_Buffered = new List<ReferencePoint>();
		Area_10nm_Buffered = new List<ReferencePoint>();
		Area_30nm_Buffered = new List<ReferencePoint>();
		IsMission = true;
		Name = string_0;
		MissionClass = _MissionClass.MineClearing;
		Category = missionCategory_0;
		Area = list_0;
		OneThirdRule = true;
		StationThrottle_Aircraft = ActiveUnit.Throttle.Loiter;
		TransitThrottle_Aircraft = ActiveUnit.Throttle.Cruise;
		TransitTerrainFollowing_Aircraft = false;
		StationTerrainFollowing_Aircraft = false;
		TransitThrottle_Submarine = ActiveUnit.Throttle.Cruise;
		StationThrottle_Submarine = ActiveUnit.Throttle.Loiter;
		TransitThrottle_Ship = ActiveUnit.Throttle.Cruise;
		StationThrottle_Ship = ActiveUnit.Throttle.Loiter;
		TransitThrottle_Facility = ActiveUnit.Throttle.Cruise;
		StationThrottle_Facility = ActiveUnit.Throttle.Loiter;
		TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.const_6;
		StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.const_6;
		UseTransitAltitude_Preset = true;
		UseStationAltitude_Preset = true;
		TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
		StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
		UseTransitDepth_Submarine_Preset = true;
		UseStationDepth_Submarine_Preset = true;
		Doctrine.SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Active, scenario_0);
		base.FlightSize = 1;
		UseFlightSizeHardLimit = true;
		IncludeInATO = false;
		string string_ = null;
		if (bool_0 && !ActiveUnit_Navigator.ValidateArea(ref Area, ref string_, side_0, scenario_0, "扫雷任务'" + Name + "'"))
		{
			GameGeneral.ResolveBridge(string_, side_0);
		}
		Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
		GroupSize = 1;
	}

	[SpecialName]
	public override string GetDescriptionString(Scenario scenario_0)
	{
		return "扫雷任务";
	}

	public override void Printout(StringBuilder stringBuilder_0)
	{
		throw new NotImplementedException();
	}

	public override Mission Clone()
	{
		MineClearingMission obj = (MineClearingMission)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Name = "[克隆]" + Name;
		obj.Area = new ReferencePoint().ExcludeWriter(ref Area);
		return obj;
	}
}
