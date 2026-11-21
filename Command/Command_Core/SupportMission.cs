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

public sealed class SupportMission : Mission
{
	public enum SupportMissionNavigationLoopType : byte
	{
		ContinousLoop,
		SingleLoop
	}

	public SupportMissionNavigationLoopType NavigationLoopType;

	public List<ReferencePoint> NavigationCourse;

	public List<ReferencePoint> NavigationCourse_ChangeCheck;

	public List<ReferencePoint> NavigationCourse_2nm_ChangeCheck;

	public List<ReferencePoint> NavigationCourse_2nm_Buffered;

	public List<ReferencePoint> NavigationCourse_10nm_ChangeCheck;

	public List<ReferencePoint> NavigationCourse_10nm_Buffered;

	public bool OneThirdRule;

	public int MinimumNumberOnStation;

	public bool OneTimeOnly;

	public bool A2AR_OneTankingCycleOnly;

	public int A2AR_MaxNumberOfReceiversPerTanker;

	public _FlightQty MinimumNumberOfAircraft;

	public ActiveUnit.Throttle? TransitThrottle_Aircraft;

	public ActiveUnit.Throttle? StationThrottle_Aircraft;

	public float? TransitAltitude_Aircraft;

	public float? StationAltitude_Aircraft;

	public bool TransitTerrainFollowing_Aircraft;

	public bool StationTerrainFollowing_Aircraft;

	public ActiveUnit.Throttle TransitThrottle_Submarine;

	public ActiveUnit.Throttle StationThrottle_Submarine;

	public float? TransitDepth_Submarine;

	public float? StationDepth_Submarine;

	private ActiveUnit_AI.AircraftAltitudePreset? publisherProxy;

	private ActiveUnit_AI.AircraftAltitudePreset? m_ServerProxy;

	private bool? m_AdapterProxy;

	private bool? _SchemaProxy;

	private ActiveUnit_AI.SubmarineDepthPreset? m_UtilsProxy;

	private ActiveUnit_AI.SubmarineDepthPreset? _PredicateProxy;

	private bool? singletonProxy;

	private bool? _RecordProxy;

	public ActiveUnit.Throttle TransitThrottle_Ship;

	public ActiveUnit.Throttle StationThrottle_Ship;

	public ActiveUnit.Throttle TransitThrottle_Facility;

	public ActiveUnit.Throttle StationThrottle_Facility;

	public bool ActiveEMCONOnlyOnStation;

	public _AircraftFormationType Formation_Cruise;

	public bool MarkAsSatisfiedUponReachingDestination;

	public bool RTBUponCompletion;

	public bool ContinousCoverage_Enable;

	public List<ContinousCoverageStation> ContinousCoverage_Stations;

	public _ContinousCoverageMethod ContinousCoverage_FlightGenerationMethod;

	public _ContinousCoverageStationTime ContinousCoverage_StationTime;

	public _ContinousCoverageOverlap ContinousCoverage_Overlap;

	public _ContinousCoverageDuration ContinousCoverage_Duration;

	public bool ContinousCoverage_QRAEnable;

	public List<ContinousCoverageStation> ContinousCoverage_QRAs;

	public _ContinousCoverageMethod ContinousCoverage_QRAFlightGenerationMethod;

	public _FlightQty ContinousCoverage_QRANumberOfFlights;

	public _FlightQty ContinousCoverage_NumberOfFlightsNeededToAllowQRA;

	public ActiveUnit_AI.AircraftAltitudePreset? TransitAltitude_Preset
	{
		get
		{
			return publisherProxy;
		}
		set
		{
			publisherProxy = value;
		}
	}

	public ActiveUnit_AI.AircraftAltitudePreset? StationAltitude_Preset
	{
		get
		{
			return m_ServerProxy;
		}
		set
		{
			m_ServerProxy = value;
		}
	}

	public bool? UseTransitAltitude_Preset
	{
		get
		{
			return m_AdapterProxy;
		}
		set
		{
			m_AdapterProxy = value;
		}
	}

	public bool? UseStationAltitude_Preset
	{
		get
		{
			return _SchemaProxy;
		}
		set
		{
			_SchemaProxy = value;
		}
	}

	public bool? UseStationDepth_Submarine_Preset
	{
		get
		{
			return _RecordProxy;
		}
		set
		{
			_RecordProxy = value;
		}
	}

	public bool? UseTransitDepth_Submarine_Preset
	{
		get
		{
			return singletonProxy;
		}
		set
		{
			singletonProxy = value;
		}
	}

	public ActiveUnit_AI.SubmarineDepthPreset? StationDepth_Submarine_Preset
	{
		get
		{
			return _PredicateProxy;
		}
		set
		{
			_PredicateProxy = value;
		}
	}

	public ActiveUnit_AI.SubmarineDepthPreset? TransitDepth_Submarine_Preset
	{
		get
		{
			return m_UtilsProxy;
		}
		set
		{
			m_UtilsProxy = value;
		}
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, ref Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("SupportMission");
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
			xmlWriter_0.WriteStartElement("NavigationCourse");
			foreach (ReferencePoint item in NavigationCourse)
			{
				xmlWriter_0.WriteRaw(item.ToXML(ref hashSet_0));
			}
			xmlWriter_0.WriteEndElement();
			XmlWriter obj = xmlWriter_0;
			int navigationLoopType = (int)NavigationLoopType;
			obj.WriteElementString("NLT", navigationLoopType.ToString());
			xmlWriter_0.WriteElementString("OTR", OneThirdRule.ToString());
			if (MinimumNumberOnStation > 0)
			{
				xmlWriter_0.WriteElementString("MNOS", MinimumNumberOnStation.ToString());
			}
			xmlWriter_0.WriteElementString("OTO", OneTimeOnly.ToString());
			xmlWriter_0.WriteElementString("AEOOS", ActiveEMCONOnlyOnStation.ToString());
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
			XmlWriter obj10 = xmlWriter_0;
			byte transitThrottle_Submarine = (byte)TransitThrottle_Submarine;
			obj10.WriteElementString("TransitThrottle_Submarine", transitThrottle_Submarine.ToString());
			XmlWriter obj11 = xmlWriter_0;
			transitThrottle_Submarine = (byte)StationThrottle_Submarine;
			obj11.WriteElementString("StationThrottle_Submarine", transitThrottle_Submarine.ToString());
			if (TransitDepth_Submarine.HasValue)
			{
				xmlWriter_0.WriteElementString("TransitDepth_Submarine", TransitDepth_Submarine.Value.ToString());
			}
			if (StationDepth_Submarine.HasValue)
			{
				xmlWriter_0.WriteElementString("StationDepth_Submarine", StationDepth_Submarine.Value.ToString());
			}
			XmlWriter obj12 = xmlWriter_0;
			transitThrottle_Submarine = (byte)TransitThrottle_Ship;
			obj12.WriteElementString("TransitThrottle_Ship", transitThrottle_Submarine.ToString());
			XmlWriter obj13 = xmlWriter_0;
			transitThrottle_Submarine = (byte)StationThrottle_Ship;
			obj13.WriteElementString("StationThrottle_Ship", transitThrottle_Submarine.ToString());
			XmlWriter obj14 = xmlWriter_0;
			transitThrottle_Submarine = (byte)TransitThrottle_Facility;
			obj14.WriteElementString("TransitThrottle_Facility", transitThrottle_Submarine.ToString());
			XmlWriter obj15 = xmlWriter_0;
			transitThrottle_Submarine = (byte)StationThrottle_Facility;
			obj15.WriteElementString("StationThrottle_Facility", transitThrottle_Submarine.ToString());
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
			if (GetStatus(scenario_0) != 0)
			{
				xmlWriter_0.WriteElementString("Status", ((byte)GetStatus(scenario_0)).ToString());
			}
			Doctrine.ToXML(ref xmlWriter_0, ref scenario_0);
			xmlWriter_0.WriteElementString("FlightSize", ((int)base.FlightSize).ToString());
			xmlWriter_0.WriteElementString("GroupSize", ((int)GroupSize).ToString());
			XmlWriter obj16 = xmlWriter_0;
			navigationLoopType = (int)Formation_Cruise;
			obj16.WriteElementString("Formation_Cruise", navigationLoopType.ToString());
			xmlWriter_0.WriteElementString("A2AR_MaxNumberOfReceiversPerTanker", A2AR_MaxNumberOfReceiversPerTanker.ToString());
			xmlWriter_0.WriteElementString("A2AR_OneTankingCycleOnly", A2AR_OneTankingCycleOnly.ToString());
			XmlWriter obj17 = xmlWriter_0;
			navigationLoopType = (int)MinimumNumberOfAircraft;
			obj17.WriteElementString("MinAircraftReq", navigationLoopType.ToString());
			xmlWriter_0.WriteElementString("UseFlightSizeHardLimit", UseFlightSizeHardLimit.ToString());
			xmlWriter_0.WriteElementString("UseGroupSizeHardLimit", UseGroupSizeHardLimit.ToString());
			XmlWriter obj2 = xmlWriter_0;
			transitThrottle_Submarine = (byte)TankerUsage;
			obj2.WriteElementString("TankerUsage", transitThrottle_Submarine.ToString());
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
			xmlWriter_0.WriteElementString("MarkAsSatisfiedUponReachingDestination", MarkAsSatisfiedUponReachingDestination.ToString());
			xmlWriter_0.WriteElementString("RTBUponCompletion", RTBUponCompletion.ToString());
			xmlWriter_0.WriteElementString("ContinousCoverage_Enable", ContinousCoverage_Enable.ToString());
			xmlWriter_0.WriteElementString("ContinousCoverage_AllowQRA", ContinousCoverage_QRAEnable.ToString());
			XmlWriter obj3 = xmlWriter_0;
			navigationLoopType = (int)ContinousCoverage_FlightGenerationMethod;
			obj3.WriteElementString("ContinousCoverage_FlightGenerationMethod", navigationLoopType.ToString());
			XmlWriter obj4 = xmlWriter_0;
			navigationLoopType = (int)ContinousCoverage_StationTime;
			obj4.WriteElementString("ContinousCoverage_StationTime", navigationLoopType.ToString());
			XmlWriter obj5 = xmlWriter_0;
			navigationLoopType = (int)ContinousCoverage_Overlap;
			obj5.WriteElementString("ContinousCoverage_Overlap", navigationLoopType.ToString());
			XmlWriter obj6 = xmlWriter_0;
			navigationLoopType = (int)ContinousCoverage_Duration;
			obj6.WriteElementString("ContinousCoverage_Duration", navigationLoopType.ToString());
			if (!Information.IsNothing(ContinousCoverage_Stations) && ContinousCoverage_Stations.Count > 0)
			{
				ContinousCoverageStation.ToXML(ref xmlWriter_0, ref hashSet_0, ref scenario_0, ref ContinousCoverage_Stations);
			}
			if (!Information.IsNothing(ContinousCoverage_QRAs) && ContinousCoverage_QRAs.Count > 0)
			{
				ContinousCoverageStation.ToXML(ref xmlWriter_0, ref hashSet_0, ref scenario_0, ref ContinousCoverage_QRAs);
			}
			XmlWriter obj7 = xmlWriter_0;
			navigationLoopType = (int)ContinousCoverage_QRANumberOfFlights;
			obj7.WriteElementString("ContinousCoverage_QRANumberOfFlights", navigationLoopType.ToString());
			XmlWriter obj8 = xmlWriter_0;
			navigationLoopType = (int)ContinousCoverage_QRAFlightGenerationMethod;
			obj8.WriteElementString("ContinousCoverage_QRAFlightGenerationMethod", navigationLoopType.ToString());
			XmlWriter obj9 = xmlWriter_0;
			navigationLoopType = (int)ContinousCoverage_NumberOfFlightsNeededToAllowQRA;
			obj9.WriteElementString("ContinousCoverage_NumberOfFlightsNeededToAllowQRA", navigationLoopType.ToString());
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
			exception_?.Data.Add("Error at 100650", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static SupportMission FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		SupportMission result = null;
		try
		{
			Side side_ = null;
			List<ReferencePoint> list_ = null;
			SupportMission supportMission = new SupportMission(ref side_, ref scenario_0, "", MissionCategory.Mission, ref list_, bool_0: false);
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
					Mission.FromXMLCommon(supportMission, xmlNode_);
					switch (xmlNode_.Name)
					{
					case "Status":
						supportMission.SetStatus(scenario_0, (MissionStatus)Conversions.ToByte(xmlNode_.InnerText));
						break;
					case "TransitDepth_Submarine_Preset":
						supportMission.TransitDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "ContinousCoverage_QRANumberOfFlights":
						supportMission.ContinousCoverage_QRANumberOfFlights = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "OTO":
						supportMission.OneTimeOnly = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Name":
						supportMission.Name = xmlNode_.InnerText;
						break;
					case "START":
					{
						DateTime value4 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						supportMission._StartTime = value4;
						break;
					}
					case "TransitTerrainFollowing_Aircraft":
						supportMission.TransitTerrainFollowing_Aircraft = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "UseFlightplan":
						supportMission.UseFlightplans = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "IncludeInATO":
						supportMission.IncludeInATO = Conversions.ToBoolean(xmlNode_.InnerText);
						flag = true;
						break;
					case "CCSList":
						supportMission.ContinousCoverage_Stations = ContinousCoverageStation.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
						break;
					case "ContinousCoverage_Overlap":
						supportMission.ContinousCoverage_Overlap = (_ContinousCoverageOverlap)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "SISIH":
						supportMission.ScrubIfSideIsHuman = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "UseGroupSizeHardLimit":
						supportMission.UseGroupSizeHardLimit = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "MarkAsSatisfiedUponReachingDestination":
						supportMission.MarkAsSatisfiedUponReachingDestination = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TankerMinNumber_Airborne":
						supportMission.TankerMinNumber_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "A2AR_MaxNumberOfReceiversPerTanker":
						supportMission.A2AR_MaxNumberOfReceiversPerTanker = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TransitThrottle_Ship":
						supportMission.TransitThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TankerMaxDistance_Airborne":
						supportMission.TankerMaxDistance_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "UseTransitDepth_Submarine_Preset":
						supportMission.UseTransitDepth_Submarine_Preset = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "LaunchMissionWithoutTankersInPlace":
						supportMission.LaunchMissionWithoutTankersInPlace = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "MNOS":
						supportMission.MinimumNumberOnStation = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "UseFlightplansOnly":
						supportMission.UsePreGeneratedFlightplansOnly = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "OTR":
					case "OneThirdRule":
						supportMission.OneThirdRule = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TimeOnTarget":
					{
						DateTime value3 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						supportMission.TimeOnTarget = value3;
						break;
					}
					case "EmptySlotsList":
						supportMission.EmptySlotsList = EmptyAircraftSlot.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
						break;
					case "TankerMinNumber_Total":
						supportMission.TankerMinNumber_Total = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "HomeNavalbase":
						supportMission._SecondaryNavalBaseID = xmlNode_.InnerText;
						break;
					case "StationThrottle_Ship":
						supportMission.StationThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode_.InnerText))
						{
							supportMission.ObjectID_Set(xmlNode_.InnerText);
							concurrentDictionary_0.TryAdd(supportMission.ObjectID, supportMission);
							break;
						}
						result = (SupportMission)concurrentDictionary_0[xmlNode_.InnerText];
						return result;
					case "Doctrine":
						supportMission.Doctrine = Doctrine.FromXML(ref xmlNode_, supportMission);
						break;
					case "TankerMinNumber_Station":
						supportMission.TankerMinNumber_Station = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TakeOffTime":
					{
						DateTime value2 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						supportMission.TakeOffTime = value2;
						break;
					}
					case "ContinousCoverage_Enable":
						supportMission.ContinousCoverage_Enable = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "QRAs":
						supportMission.ContinousCoverage_QRAs = ContinousCoverageStation.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
						break;
					case "NavigationCourse":
						supportMission.NavigationCourse = new List<ReferencePoint>();
						try
						{
							enumerator3 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator3.Current;
								supportMission.NavigationCourse.Add(ReferencePoint.FromXML(ref xmlNode_2, ref concurrentDictionary_0));
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
					case "StationThrottle_Facility":
						supportMission.StationThrottle_Facility = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "ContinousCoverage_NumberOfFlightsNeededToAllowQRA":
						supportMission.ContinousCoverage_NumberOfFlightsNeededToAllowQRA = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "FlightList":
						supportMission.FlightList = Flight.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
						break;
					case "AEOOS":
						supportMission.ActiveEMCONOnlyOnStation = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "FuelQtyToStartLookingForTanker_Airborne":
						supportMission.FuelQtyToStartLookingForTanker_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "A2AR_OneTankingCycleOnly":
						supportMission.A2AR_OneTankingCycleOnly = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "FlightSize":
						supportMission.FlightSize = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "RTBUponCompletion":
						supportMission.RTBUponCompletion = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TankerMissionList":
						try
						{
							enumerator4 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator4.Current;
								supportMission.TankerMissions_IDs.Add(xmlNode2.InnerText);
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
					case "ContinousCoverage_QRAFlightGenerationMethod":
						supportMission.ContinousCoverage_QRAFlightGenerationMethod = (_ContinousCoverageMethod)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "HomeAirbase":
						supportMission._SecondaryAirBaseID = xmlNode_.InnerText;
						break;
					case "UseFlightSizeHardLimit":
						supportMission.UseFlightSizeHardLimit = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "NLT":
						supportMission.NavigationLoopType = (SupportMissionNavigationLoopType)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TransitDepth_Submarine":
						supportMission.TransitDepth_Submarine = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "UseTransitAltitude_Preset":
						supportMission.UseTransitAltitude_Preset = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TransitThrottle_Facility":
						supportMission.TransitThrottle_Facility = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "ContinousCoverage_FlightGenerationMethod":
						supportMission.ContinousCoverage_FlightGenerationMethod = (_ContinousCoverageMethod)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TransitAltitude_Preset":
						supportMission.TransitAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "PriorityWeight":
						supportMission.PriorityWeight = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Category":
						supportMission.Category = (MissionCategory)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "END":
					{
						DateTime value = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						supportMission._EndTime = value;
						break;
					}
					case "UseStationDepth_Submarine_Preset":
						supportMission.UseStationDepth_Submarine_Preset = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "ContinousCoverage_StationTime":
						supportMission.ContinousCoverage_StationTime = (_ContinousCoverageStationTime)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "_Phase":
						supportMission._Phase = (MissionPhase)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "StationDepth_Submarine_Preset":
						supportMission.StationDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "ContinousCoverage_Duration":
						supportMission.ContinousCoverage_Duration = (_ContinousCoverageDuration)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TankerUsage":
						supportMission.TankerUsage = (TankerMethod)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "AssignedUnitsList":
						try
						{
							enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode = (XmlNode)enumerator2.Current;
								supportMission.UnitsAssignedToMissionIDs.Add(xmlNode.InnerText);
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
					case "StationThrottle_Submarine":
						supportMission.StationThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "StationThrottle":
					case "LTh":
					case "StationThrottle_Aircraft":
						supportMission.StationThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "MinAircraftReq":
						supportMission.MinimumNumberOfAircraft = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "LAO":
					case "StationAltitude_Aircraft":
					case "StationAltitude":
						supportMission.StationAltitude_Aircraft = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "TankerFollowsReceivers":
						supportMission.TankerFollowsReceivers = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "UseStationAltitude_Preset":
						supportMission.UseStationAltitude_Preset = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "GroupSize":
						supportMission.GroupSize = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TAO":
					case "TransitAltitude":
					case "TransitAltitude_Aircraft":
						supportMission.TransitAltitude_Aircraft = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Completion":
						supportMission.Completion = Conversions.ToSingle(xmlNode_.InnerText);
						break;
					case "TransitThrottle_Submarine":
						supportMission.TransitThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Formation_Cruise":
						supportMission.Formation_Cruise = (_AircraftFormationType)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "MaxReceiversInQueuePerTanker_Airborne":
						supportMission.MaxReceiversInQueuePerTanker_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "ContinousCoverage_AllowQRA":
						supportMission.ContinousCoverage_QRAEnable = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "StationAltitude_Preset":
						supportMission.StationAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "StationDepth_Submarine":
						supportMission.StationDepth_Submarine = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "TTh":
					case "TransitThrottle":
					case "TransitThrottle_Aircraft":
						supportMission.TransitThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "StationTerrainFollowing_Aircraft":
						supportMission.StationTerrainFollowing_Aircraft = Conversions.ToBoolean(xmlNode_.InnerText);
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
			if (supportMission.TransitThrottle_Submarine == ActiveUnit.Throttle.FullStop)
			{
				supportMission.TransitTerrainFollowing_Aircraft = false;
				supportMission.StationTerrainFollowing_Aircraft = false;
				supportMission.TransitThrottle_Submarine = ActiveUnit.Throttle.Cruise;
				supportMission.StationThrottle_Submarine = ActiveUnit.Throttle.Loiter;
				supportMission.TransitThrottle_Ship = ActiveUnit.Throttle.Cruise;
				supportMission.StationThrottle_Ship = ActiveUnit.Throttle.Loiter;
				supportMission.TransitThrottle_Facility = ActiveUnit.Throttle.Cruise;
				supportMission.StationThrottle_Facility = ActiveUnit.Throttle.Loiter;
			}
			if (supportMission.Doctrine.ReplenishmentSelection_Inherits())
			{
				supportMission.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
			}
			if (supportMission.TransitAltitude_Aircraft.HasValue && supportMission.UseTransitAltitude_Preset.GetValueOrDefault())
			{
				supportMission.UseTransitAltitude_Preset = false;
				supportMission.TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
			}
			if (supportMission.StationAltitude_Aircraft.HasValue && supportMission.UseStationAltitude_Preset.GetValueOrDefault())
			{
				supportMission.UseStationAltitude_Preset = false;
				supportMission.StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
			}
			if (supportMission.TransitDepth_Submarine.HasValue && supportMission.UseTransitDepth_Submarine_Preset.GetValueOrDefault())
			{
				supportMission.UseTransitDepth_Submarine_Preset = false;
				supportMission.TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
			}
			if (supportMission.StationDepth_Submarine.HasValue && supportMission.UseStationDepth_Submarine_Preset.GetValueOrDefault())
			{
				supportMission.UseStationDepth_Submarine_Preset = false;
				supportMission.StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
			}
			if (!flag)
			{
				supportMission.IncludeInATO = true;
			}
			if (supportMission.ContinousCoverage_QRANumberOfFlights == _FlightQty.NoPreferences)
			{
				supportMission.ContinousCoverage_Enable = false;
				supportMission.ContinousCoverage_FlightGenerationMethod = _ContinousCoverageMethod.Dynamic;
				supportMission.ContinousCoverage_StationTime = _ContinousCoverageStationTime.min_45;
				supportMission.ContinousCoverage_Overlap = _ContinousCoverageOverlap.Min_2;
				supportMission.ContinousCoverage_Duration = _ContinousCoverageDuration.hr_6;
				supportMission.ContinousCoverage_QRAEnable = false;
				supportMission.ContinousCoverage_QRAFlightGenerationMethod = _ContinousCoverageMethod.Dynamic;
				supportMission.ContinousCoverage_QRANumberOfFlights = _FlightQty.Flight_x1;
				supportMission.ContinousCoverage_NumberOfFlightsNeededToAllowQRA = _FlightQty.Flight_x2;
			}
			result = supportMission;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100651", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public SupportMission(ref Side side_0, ref Scenario scenario_0, string string_0, MissionCategory missionCategory_0, ref List<ReferencePoint> list_0, bool bool_0)
		: base(side_0, scenario_0, string_0)
	{
		NavigationCourse = new List<ReferencePoint>();
		NavigationCourse_ChangeCheck = new List<ReferencePoint>();
		NavigationCourse_2nm_ChangeCheck = new List<ReferencePoint>();
		NavigationCourse_2nm_Buffered = new List<ReferencePoint>();
		NavigationCourse_10nm_ChangeCheck = new List<ReferencePoint>();
		NavigationCourse_10nm_Buffered = new List<ReferencePoint>();
		RTBUponCompletion = true;
		IsMission = true;
		MissionClass = _MissionClass.Support;
		Name = string_0;
		Category = missionCategory_0;
		NavigationCourse = list_0;
		NavigationLoopType = SupportMissionNavigationLoopType.ContinousLoop;
		TransitThrottle_Aircraft = ActiveUnit.Throttle.Cruise;
		StationThrottle_Aircraft = ActiveUnit.Throttle.Loiter;
		TransitTerrainFollowing_Aircraft = false;
		StationTerrainFollowing_Aircraft = false;
		TransitThrottle_Submarine = ActiveUnit.Throttle.Cruise;
		StationThrottle_Submarine = ActiveUnit.Throttle.Loiter;
		TransitThrottle_Ship = ActiveUnit.Throttle.Cruise;
		StationThrottle_Ship = ActiveUnit.Throttle.Loiter;
		TransitThrottle_Facility = ActiveUnit.Throttle.Cruise;
		StationThrottle_Facility = ActiveUnit.Throttle.Loiter;
		IncludeInATO = true;
		OneThirdRule = true;
		TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.const_6;
		StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.const_6;
		UseTransitAltitude_Preset = true;
		UseStationAltitude_Preset = true;
		TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
		StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
		UseTransitDepth_Submarine_Preset = true;
		UseStationDepth_Submarine_Preset = true;
		base.FlightSize = 1;
		UseFlightSizeHardLimit = true;
		string string_ = null;
		if (bool_0 && !ActiveUnit_Navigator.ValidateArea(ref list_0, ref string_, side_0, scenario_0, "支援任务 '" + Name + "'"))
		{
			GameGeneral.ResolveBridge(string_, side_0);
		}
		Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
		GroupSize = 1;
		ContinousCoverage_Enable = false;
		ContinousCoverage_FlightGenerationMethod = _ContinousCoverageMethod.Dynamic;
		ContinousCoverage_StationTime = _ContinousCoverageStationTime.min_45;
		ContinousCoverage_Overlap = _ContinousCoverageOverlap.Min_2;
		ContinousCoverage_Duration = _ContinousCoverageDuration.hr_6;
		ContinousCoverage_QRAEnable = false;
		ContinousCoverage_QRAFlightGenerationMethod = _ContinousCoverageMethod.Dynamic;
		ContinousCoverage_QRANumberOfFlights = _FlightQty.Flight_x1;
		ContinousCoverage_NumberOfFlightsNeededToAllowQRA = _FlightQty.Flight_x2;
	}

	public override void Printout(StringBuilder stringBuilder_0)
	{
		throw new NotImplementedException();
	}

	public override Mission Clone()
	{
		SupportMission obj = (SupportMission)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Name = "[克隆]" + Name;
		obj.NavigationCourse = new ReferencePoint().ExcludeWriter(ref NavigationCourse);
		return obj;
	}

	[SpecialName]
	public override string GetDescriptionString(Scenario scenario_0)
	{
		return "支援任务";
	}
}
