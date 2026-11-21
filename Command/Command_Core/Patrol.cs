using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Patrol : Mission, IRecurringMission
{
	public enum PatrolMovementStyle
	{
		RandomWithinArea,
		RepeatableLoop
	}

	public GlobalVariables.PatrolType Type;

	public List<ReferencePoint> PatrolArea;

	public List<ReferencePoint> PatrolArea_ChangeCheck;

	public List<ReferencePoint> PatrolArea_2nm_ChangeCheck;

	public List<ReferencePoint> PatrolArea_5nm_ChangeCheck;

	public List<ReferencePoint> PatrolArea_10nm_ChangeCheck;

	public List<ReferencePoint> PatrolArea_30nm_ChangeCheck;

	public List<ReferencePoint> PatrolArea_2nm_Buffered;

	public List<ReferencePoint> PatrolArea_5nm_Buffered;

	public List<ReferencePoint> PatrolArea_10nm_Buffered;

	public List<ReferencePoint> PatrolArea_30nm_Buffered;

	public List<ReferencePoint> ProsecutionArea;

	public List<ReferencePoint> ProsecutionArea_ChangeCheck;

	public List<ReferencePoint> ProsecutionArea_2nm_ChangeCheck;

	public List<ReferencePoint> ProsecutionArea_5nm_ChangeCheck;

	public List<ReferencePoint> ProsecutionArea_2nm_Buffered;

	public List<ReferencePoint> ProsecutionArea_5nm_Buffered;

	public bool OneThirdRule;

	public int MinimumNumberOnStation;

	private bool m_SetterConsumer;

	private bool _CreatorConsumer;

	public bool ActiveEMCONOnlyInPatrolOrProsecutionArea;

	public bool SprintAndDrift;

	public bool AvoidCavitation;

	public PatrolMovementStyle MovementStyle;

	public _FlightQty MinimumNumberOfAircraft;

	private ActiveUnit.Throttle? m_TemplateConsumer;

	private ActiveUnit.Throttle? mappingConsumer;

	private ActiveUnit.Throttle? mockConsumer;

	private float? _TagConsumer;

	private float? m_FieldConsumer;

	private float? queueConsumer;

	private float? m_RegConsumer;

	private bool m_ParamConsumer;

	private bool pageConsumer;

	private bool rulesConsumer;

	private ActiveUnit_AI.AircraftAltitudePreset? _MethodConsumer;

	private ActiveUnit_AI.AircraftAltitudePreset? _ServiceConsumer;

	private ActiveUnit_AI.AircraftAltitudePreset? _SystemConsumer;

	private bool? m_CandidateConsumer;

	private bool? m_BaseConsumer;

	private bool? policyConsumer;

	private ActiveUnit.Throttle broadcasterConsumer;

	private ActiveUnit.Throttle identifierConsumer;

	private ActiveUnit.Throttle? printerConsumer;

	private float? _ParserConsumer;

	private float? algoConsumer;

	private float? m_DatabaseConsumer;

	private float? m_InterceptorConsumer;

	private ActiveUnit_AI.SubmarineDepthPreset? m_MessageConsumer;

	private ActiveUnit_AI.SubmarineDepthPreset? productConsumer;

	private ActiveUnit_AI.SubmarineDepthPreset? _AnnotationConsumer;

	private bool? iteratorConsumer;

	private bool? initializerConsumer;

	private bool? roleConsumer;

	private ActiveUnit.Throttle factoryConsumer;

	private ActiveUnit.Throttle m_AttributeConsumer;

	private ActiveUnit.Throttle? m_EventConsumer;

	private float? _GlobalConsumer;

	private ActiveUnit.Throttle m_WorkerConsumer;

	private ActiveUnit.Throttle m_AccountConsumer;

	private ActiveUnit.Throttle? stateConsumer;

	public _AircraftFormationType Formation_Cruise;

	public _AircraftFormationType Formation_Attack;

	public _FlightQty NumberOfFlights_Investigate;

	public _FlightQty NumberOfFlights_Engage;

	public int WingmanEngageDistance;

	public _GroupQty NumberOfBoats_Investigate;

	public _GroupQty NumberOfBoats_Engage;

	public int GroupMemberEngageDistance;

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

	public bool HasProsecutionArea => ProsecutionArea.Count > 2;

	public ActiveUnit.Throttle? TransitThrottle_Aircraft
	{
		get
		{
			return m_TemplateConsumer;
		}
		set
		{
			m_TemplateConsumer = value;
		}
	}

	public ActiveUnit.Throttle? StationThrottle_Aircraft
	{
		get
		{
			return mappingConsumer;
		}
		set
		{
			mappingConsumer = value;
		}
	}

	public ActiveUnit.Throttle? AttackThrottle_Aircraft
	{
		get
		{
			return mockConsumer;
		}
		set
		{
			mockConsumer = value;
		}
	}

	public float? TransitAltitude_Aircraft
	{
		get
		{
			return _TagConsumer;
		}
		set
		{
			_TagConsumer = value;
		}
	}

	public float? StationAltitude_Aircraft
	{
		get
		{
			return m_FieldConsumer;
		}
		set
		{
			m_FieldConsumer = value;
		}
	}

	public float? AttackAltitude_Aircraft
	{
		get
		{
			return queueConsumer;
		}
		set
		{
			queueConsumer = value;
		}
	}

	public float? AttackDistance_Aircraft
	{
		get
		{
			return m_RegConsumer;
		}
		set
		{
			m_RegConsumer = value;
		}
	}

	public bool TransitTerrainFollowing_Aircraft
	{
		get
		{
			return m_ParamConsumer;
		}
		set
		{
			m_ParamConsumer = value;
		}
	}

	public bool StationTerrainFollowing_Aircraft
	{
		get
		{
			return pageConsumer;
		}
		set
		{
			pageConsumer = value;
		}
	}

	public bool AttackTerrainFollowing_Aircraft
	{
		get
		{
			return rulesConsumer;
		}
		set
		{
			rulesConsumer = value;
		}
	}

	public ActiveUnit.Throttle TransitThrottle_Submarine
	{
		get
		{
			return broadcasterConsumer;
		}
		set
		{
			broadcasterConsumer = value;
		}
	}

	public ActiveUnit.Throttle StationThrottle_Submarine
	{
		get
		{
			return identifierConsumer;
		}
		set
		{
			identifierConsumer = value;
		}
	}

	public ActiveUnit.Throttle? AttackThrottle_Submarine
	{
		get
		{
			return printerConsumer;
		}
		set
		{
			printerConsumer = value;
		}
	}

	public float? TransitDepth_Submarine
	{
		get
		{
			return _ParserConsumer;
		}
		set
		{
			_ParserConsumer = value;
		}
	}

	public float? StationDepth_Submarine
	{
		get
		{
			return algoConsumer;
		}
		set
		{
			algoConsumer = value;
		}
	}

	public float? AttackDepth_Submarine
	{
		get
		{
			return m_DatabaseConsumer;
		}
		set
		{
			m_DatabaseConsumer = value;
		}
	}

	public bool? UseStationDepth_Submarine_Preset
	{
		get
		{
			return initializerConsumer;
		}
		set
		{
			initializerConsumer = value;
		}
	}

	public bool? UseAttackDepth_Submarine_Preset
	{
		get
		{
			return roleConsumer;
		}
		set
		{
			roleConsumer = value;
		}
	}

	public bool? UseTransitDepth_Submarine_Preset
	{
		get
		{
			return iteratorConsumer;
		}
		set
		{
			iteratorConsumer = value;
		}
	}

	public ActiveUnit_AI.SubmarineDepthPreset? StationDepth_Submarine_Preset
	{
		get
		{
			return productConsumer;
		}
		set
		{
			productConsumer = value;
		}
	}

	public ActiveUnit_AI.SubmarineDepthPreset? AttackDepth_Submarine_Preset
	{
		get
		{
			return _AnnotationConsumer;
		}
		set
		{
			_AnnotationConsumer = value;
		}
	}

	public ActiveUnit_AI.SubmarineDepthPreset? TransitDepth_Submarine_Preset
	{
		get
		{
			return m_MessageConsumer;
		}
		set
		{
			m_MessageConsumer = value;
		}
	}

	public float? AttackDistance_Submarine
	{
		get
		{
			return m_InterceptorConsumer;
		}
		set
		{
			m_InterceptorConsumer = value;
		}
	}

	public bool? UseTransitAltitude_Preset
	{
		get
		{
			return m_CandidateConsumer;
		}
		set
		{
			m_CandidateConsumer = value;
		}
	}

	public bool? UseStationAltitude_Preset
	{
		get
		{
			return m_BaseConsumer;
		}
		set
		{
			m_BaseConsumer = value;
		}
	}

	public bool? UseAttackAltitude_Preset
	{
		get
		{
			return policyConsumer;
		}
		set
		{
			policyConsumer = value;
		}
	}

	public ActiveUnit_AI.AircraftAltitudePreset? TransitAltitude_Preset
	{
		get
		{
			return _MethodConsumer;
		}
		set
		{
			_MethodConsumer = value;
		}
	}

	public ActiveUnit_AI.AircraftAltitudePreset? StationAltitude_Preset
	{
		get
		{
			return _ServiceConsumer;
		}
		set
		{
			_ServiceConsumer = value;
		}
	}

	public ActiveUnit_AI.AircraftAltitudePreset? AttackAltitude_Preset
	{
		get
		{
			return _SystemConsumer;
		}
		set
		{
			_SystemConsumer = value;
		}
	}

	public ActiveUnit.Throttle TransitThrottle_Ship
	{
		get
		{
			return factoryConsumer;
		}
		set
		{
			factoryConsumer = value;
		}
	}

	public ActiveUnit.Throttle StationThrottle_Ship
	{
		get
		{
			return m_AttributeConsumer;
		}
		set
		{
			m_AttributeConsumer = value;
		}
	}

	public ActiveUnit.Throttle? AttackThrottle_Ship
	{
		get
		{
			return m_EventConsumer;
		}
		set
		{
			m_EventConsumer = value;
		}
	}

	public float? AttackDistance_Ship
	{
		get
		{
			return _GlobalConsumer;
		}
		set
		{
			_GlobalConsumer = value;
		}
	}

	public ActiveUnit.Throttle TransitThrottle_Facility
	{
		get
		{
			return m_WorkerConsumer;
		}
		set
		{
			m_WorkerConsumer = value;
		}
	}

	public ActiveUnit.Throttle StationThrottle_Facility
	{
		get
		{
			return m_AccountConsumer;
		}
		set
		{
			m_AccountConsumer = value;
		}
	}

	public ActiveUnit.Throttle? AttackThrottle_Facility
	{
		get
		{
			return stateConsumer;
		}
		set
		{
			stateConsumer = value;
		}
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, ref Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Patrol");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Name", Name);
			xmlWriter_0.WriteElementString("Category", ((byte)Category).ToString());
			XmlWriter obj = xmlWriter_0;
			int type = (int)Type;
			obj.WriteElementString("Type", type.ToString());
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
			if (PatrolArea.Count > 0)
			{
				xmlWriter_0.WriteStartElement("PatrolArea");
				foreach (ReferencePoint item in PatrolArea)
				{
					xmlWriter_0.WriteRaw(item.ToXML(ref hashSet_0));
				}
				xmlWriter_0.WriteEndElement();
			}
			if (ProsecutionArea.Count > 0)
			{
				xmlWriter_0.WriteStartElement("ProsecutionArea");
				foreach (ReferencePoint item2 in ProsecutionArea)
				{
					xmlWriter_0.WriteRaw(item2.ToXML(ref hashSet_0));
				}
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteElementString("OTR", OneThirdRule.ToString());
			if (MinimumNumberOnStation > 0)
			{
				xmlWriter_0.WriteElementString("MNOS", MinimumNumberOnStation.ToString());
			}
			xmlWriter_0.WriteElementString("IOPA", m_SetterConsumer.ToString());
			xmlWriter_0.WriteElementString("IWWR", _CreatorConsumer.ToString());
			xmlWriter_0.WriteElementString("AEOIPA", ActiveEMCONOnlyInPatrolOrProsecutionArea.ToString());
			xmlWriter_0.WriteElementString("SAD", SprintAndDrift.ToString());
			xmlWriter_0.WriteElementString("AvCav", AvoidCavitation.ToString());
			if (SecondaryAirBase != null)
			{
				xmlWriter_0.WriteElementString("HomeAirbase", SecondaryAirBase.ObjectID.ToString());
			}
			if (SecondaryNavalBase != null)
			{
				xmlWriter_0.WriteElementString("HomeNavalbase", SecondaryNavalBase.ObjectID.ToString());
			}
			if (TransitThrottle_Aircraft.HasValue)
			{
				xmlWriter_0.WriteElementString("TransitThrottle_Aircraft", ((byte)TransitThrottle_Aircraft.Value).ToString());
			}
			if (StationThrottle_Aircraft.HasValue)
			{
				xmlWriter_0.WriteElementString("StationThrottle_Aircraft", ((byte)StationThrottle_Aircraft.Value).ToString());
			}
			if (AttackThrottle_Aircraft.HasValue)
			{
				xmlWriter_0.WriteElementString("AttackThrottle_Aircraft", ((byte)AttackThrottle_Aircraft.Value).ToString());
			}
			if (TransitAltitude_Aircraft.HasValue)
			{
				xmlWriter_0.WriteElementString("TransitAltitude_Aircraft", TransitAltitude_Aircraft.Value.ToString());
			}
			if (StationAltitude_Aircraft.HasValue)
			{
				xmlWriter_0.WriteElementString("StationAltitude_Aircraft", StationAltitude_Aircraft.Value.ToString());
			}
			if (AttackAltitude_Aircraft.HasValue)
			{
				xmlWriter_0.WriteElementString("AttackAltitude_Aircraft", AttackAltitude_Aircraft.Value.ToString());
			}
			if (AttackDistance_Aircraft.HasValue)
			{
				xmlWriter_0.WriteElementString("AttackDistance_Aircraft", AttackDistance_Aircraft.Value.ToString());
			}
			if (UseAttackAltitude_Preset.HasValue)
			{
				xmlWriter_0.WriteElementString("UseAttackAltitude_Preset", ((byte)(-(UseAttackAltitude_Preset.Value ? 1 : 0))).ToString());
			}
			if (UseStationAltitude_Preset.HasValue)
			{
				xmlWriter_0.WriteElementString("UseStationAltitude_Preset", ((byte)(-(UseStationAltitude_Preset.Value ? 1 : 0))).ToString());
			}
			if (UseTransitAltitude_Preset.HasValue)
			{
				xmlWriter_0.WriteElementString("UseTransitAltitude_Preset", ((byte)(-(UseTransitAltitude_Preset.Value ? 1 : 0))).ToString());
			}
			if (AttackAltitude_Preset.HasValue)
			{
				xmlWriter_0.WriteElementString("AttackAltitude_Preset", ((byte)AttackAltitude_Preset.Value).ToString());
			}
			if (StationAltitude_Preset.HasValue)
			{
				xmlWriter_0.WriteElementString("StationAltitude_Preset", ((byte)StationAltitude_Preset.Value).ToString());
			}
			if (TransitAltitude_Preset.HasValue)
			{
				xmlWriter_0.WriteElementString("TransitAltitude_Preset", ((byte)TransitAltitude_Preset.Value).ToString());
			}
			xmlWriter_0.WriteElementString("TransitTerrainFollowing_Aircraft", TransitTerrainFollowing_Aircraft.ToString());
			xmlWriter_0.WriteElementString("StationTerrainFollowing_Aircraft", StationTerrainFollowing_Aircraft.ToString());
			xmlWriter_0.WriteElementString("AttackTerrainFollowing_Aircraft", AttackTerrainFollowing_Aircraft.ToString());
			xmlWriter_0.WriteElementString("TransitThrottle_Submarine", ((byte)TransitThrottle_Submarine).ToString());
			xmlWriter_0.WriteElementString("StationThrottle_Submarine", ((byte)StationThrottle_Submarine).ToString());
			if (AttackThrottle_Submarine.HasValue)
			{
				xmlWriter_0.WriteElementString("AttackThrottle_Submarine", ((byte)AttackThrottle_Submarine.Value).ToString());
			}
			if (TransitDepth_Submarine.HasValue)
			{
				xmlWriter_0.WriteElementString("TransitDepth_Submarine", TransitDepth_Submarine.Value.ToString());
			}
			if (StationDepth_Submarine.HasValue)
			{
				xmlWriter_0.WriteElementString("StationDepth_Submarine", StationDepth_Submarine.Value.ToString());
			}
			if (AttackDepth_Submarine.HasValue)
			{
				xmlWriter_0.WriteElementString("AttackDepth_Submarine", AttackDepth_Submarine.Value.ToString());
			}
			if (AttackDistance_Submarine.HasValue)
			{
				xmlWriter_0.WriteElementString("AttackDistance_Submarine", AttackDistance_Submarine.Value.ToString());
			}
			if (AttackDepth_Submarine_Preset.HasValue)
			{
				xmlWriter_0.WriteElementString("AttackDepth_Submarine_Preset", ((byte)AttackDepth_Submarine_Preset.Value).ToString());
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
			if (UseAttackDepth_Submarine_Preset.HasValue)
			{
				xmlWriter_0.WriteElementString("UseAttackDepth_Submarine_Preset", UseAttackDepth_Submarine_Preset.Value.ToString());
			}
			xmlWriter_0.WriteElementString("TransitThrottle_Ship", ((byte)TransitThrottle_Ship).ToString());
			xmlWriter_0.WriteElementString("StationThrottle_Ship", ((byte)StationThrottle_Ship).ToString());
			if (AttackThrottle_Ship.HasValue)
			{
				xmlWriter_0.WriteElementString("AttackThrottle_Ship", ((byte)AttackThrottle_Ship.Value).ToString());
			}
			if (AttackDistance_Ship.HasValue)
			{
				xmlWriter_0.WriteElementString("AttackDistance_Ship", AttackDistance_Ship.Value.ToString());
			}
			xmlWriter_0.WriteElementString("TransitThrottle_Facility", ((byte)TransitThrottle_Facility).ToString());
			xmlWriter_0.WriteElementString("StationThrottle_Facility", ((byte)StationThrottle_Facility).ToString());
			if (AttackThrottle_Facility.HasValue)
			{
				xmlWriter_0.WriteElementString("AttackThrottle_Facility", ((byte)AttackThrottle_Facility.Value).ToString());
			}
			xmlWriter_0.WriteElementString("SISIH", ScrubIfSideIsHuman.ToString());
			xmlWriter_0.WriteElementString("UseFlightplan", UseFlightplans.ToString());
			xmlWriter_0.WriteElementString("UseFlightplansOnly", UsePreGeneratedFlightplansOnly.ToString());
			xmlWriter_0.WriteElementString("IncludeInATO", IncludeInATO.ToString());
			if (GetStatus(scenario_0) != 0)
			{
				xmlWriter_0.WriteElementString("Status", ((byte)GetStatus(scenario_0)).ToString());
			}
			xmlWriter_0.WriteElementString("FlightSize", ((int)base.FlightSize).ToString());
			xmlWriter_0.WriteElementString("GroupSize", ((int)GroupSize).ToString());
			XmlWriter obj10 = xmlWriter_0;
			type = (int)Formation_Cruise;
			obj10.WriteElementString("Formation_Cruise", type.ToString());
			XmlWriter obj11 = xmlWriter_0;
			type = (int)Formation_Attack;
			obj11.WriteElementString("Formation_Attack", type.ToString());
			XmlWriter obj12 = xmlWriter_0;
			type = (int)MinimumNumberOfAircraft;
			obj12.WriteElementString("MinAircraftReq", type.ToString());
			xmlWriter_0.WriteElementString("UseFlightSizeHardLimit", UseFlightSizeHardLimit.ToString());
			xmlWriter_0.WriteElementString("UseGroupSizeHardLimit", UseGroupSizeHardLimit.ToString());
			XmlWriter obj13 = xmlWriter_0;
			byte tankerUsage = (byte)TankerUsage;
			obj13.WriteElementString("TankerUsage", tankerUsage.ToString());
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
			XmlWriter obj14 = xmlWriter_0;
			type = (int)NumberOfFlights_Investigate;
			obj14.WriteElementString("NumberOfFlights_Investigate", type.ToString());
			XmlWriter obj15 = xmlWriter_0;
			type = (int)NumberOfFlights_Engage;
			obj15.WriteElementString("NumberOfFlights_Engage", type.ToString());
			xmlWriter_0.WriteElementString("WingmanEngageDistance", WingmanEngageDistance.ToString());
			XmlWriter obj16 = xmlWriter_0;
			type = (int)NumberOfBoats_Investigate;
			obj16.WriteElementString("NumberOfBoats_Investigate", type.ToString());
			XmlWriter obj17 = xmlWriter_0;
			type = (int)NumberOfBoats_Engage;
			obj17.WriteElementString("NumberOfBoats_Engage", type.ToString());
			xmlWriter_0.WriteElementString("GroupMemberEngageDistance", GroupMemberEngageDistance.ToString());
			xmlWriter_0.WriteElementString("ContinousCoverage_Enable", ContinousCoverage_Enable.ToString());
			xmlWriter_0.WriteElementString("ContinousCoverage_AllowQRA", ContinousCoverage_QRAEnable.ToString());
			XmlWriter obj2 = xmlWriter_0;
			type = (int)ContinousCoverage_FlightGenerationMethod;
			obj2.WriteElementString("ContinousCoverage_FlightGenerationMethod", type.ToString());
			XmlWriter obj3 = xmlWriter_0;
			type = (int)ContinousCoverage_StationTime;
			obj3.WriteElementString("ContinousCoverage_StationTime", type.ToString());
			XmlWriter obj4 = xmlWriter_0;
			type = (int)ContinousCoverage_Overlap;
			obj4.WriteElementString("ContinousCoverage_Overlap", type.ToString());
			XmlWriter obj5 = xmlWriter_0;
			type = (int)ContinousCoverage_Duration;
			obj5.WriteElementString("ContinousCoverage_Duration", type.ToString());
			if (!Information.IsNothing(ContinousCoverage_Stations) && ContinousCoverage_Stations.Count > 0)
			{
				xmlWriter_0.WriteStartElement("CCSList");
				ContinousCoverageStation.ToXML(ref xmlWriter_0, ref hashSet_0, ref scenario_0, ref ContinousCoverage_Stations);
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(ContinousCoverage_QRAs) && ContinousCoverage_QRAs.Count > 0)
			{
				xmlWriter_0.WriteStartElement("QRAs");
				ContinousCoverageStation.ToXML(ref xmlWriter_0, ref hashSet_0, ref scenario_0, ref ContinousCoverage_QRAs);
				xmlWriter_0.WriteEndElement();
			}
			XmlWriter obj6 = xmlWriter_0;
			type = (int)ContinousCoverage_QRANumberOfFlights;
			obj6.WriteElementString("ContinousCoverage_QRANumberOfFlights", type.ToString());
			XmlWriter obj7 = xmlWriter_0;
			type = (int)ContinousCoverage_QRAFlightGenerationMethod;
			obj7.WriteElementString("ContinousCoverage_QRAFlightGenerationMethod", type.ToString());
			XmlWriter obj8 = xmlWriter_0;
			type = (int)ContinousCoverage_NumberOfFlightsNeededToAllowQRA;
			obj8.WriteElementString("ContinousCoverage_NumberOfFlightsNeededToAllowQRA", type.ToString());
			XmlWriter obj9 = xmlWriter_0;
			type = (int)MovementStyle;
			obj9.WriteElementString("MovementStyle", type.ToString());
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
			exception_?.Data.Add("Error at 100643", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Patrol FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		try
		{
			Patrol patrol = new Patrol(null, scenario_0, "");
			bool flag = false;
			patrol.StationThrottle_Aircraft = ActiveUnit.Throttle.Loiter;
			patrol._CreatorConsumer = true;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				IEnumerator enumerator3 = null;
				IEnumerator enumerator4 = null;
				IEnumerator enumerator5 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode_ = (XmlNode)enumerator.Current;
					Mission.FromXMLCommon(patrol, xmlNode_);
					switch (xmlNode_.Name)
					{
					case "PatrolArea":
						try
						{
							enumerator3 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator3.Current;
								patrol.PatrolArea.Add(ReferencePoint.FromXML(ref xmlNode_2, ref concurrentDictionary_0));
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
					case "Status":
						patrol.SetStatus(scenario_0, (MissionStatus)Conversions.ToByte(xmlNode_.InnerText));
						break;
					case "AttackAltitude_Preset":
						patrol.AttackAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "ContinousCoverage_QRANumberOfFlights":
						patrol.ContinousCoverage_QRANumberOfFlights = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TransitTerrainFollowing_Aircraft":
						patrol.TransitTerrainFollowing_Aircraft = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TransitDepth_Submarine_Preset":
						patrol.TransitDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "CCSList":
						patrol.ContinousCoverage_Stations = ContinousCoverageStation.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
						break;
					case "Name":
						patrol.Name = xmlNode_.InnerText;
						break;
					case "START":
					{
						DateTime value4 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						patrol._StartTime = value4;
						break;
					}
					case "UseFlightplan":
						patrol.UseFlightplans = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "IncludeInATO":
						patrol.IncludeInATO = Conversions.ToBoolean(xmlNode_.InnerText);
						flag = true;
						break;
					case "NumberOfBoats_Engage":
						patrol.NumberOfBoats_Engage = (_GroupQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "SISIH":
						patrol.ScrubIfSideIsHuman = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "UseGroupSizeHardLimit":
						patrol.UseGroupSizeHardLimit = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "ContinousCoverage_Overlap":
						patrol.ContinousCoverage_Overlap = (_ContinousCoverageOverlap)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "WingmanEngageDistance":
						patrol.WingmanEngageDistance = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TankerMinNumber_Airborne":
						patrol.TankerMinNumber_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TransitThrottle_Ship":
						patrol.TransitThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TankerMaxDistance_Airborne":
						patrol.TankerMaxDistance_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "SAD":
						patrol.SprintAndDrift = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "IWWR":
						patrol._CreatorConsumer = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "GroupMemberEngageDistance":
						patrol.GroupMemberEngageDistance = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "UseTransitDepth_Submarine_Preset":
						patrol.UseTransitDepth_Submarine_Preset = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "LaunchMissionWithoutTankersInPlace":
						patrol.LaunchMissionWithoutTankersInPlace = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "AttackThrottle_Facility":
						patrol.AttackThrottle_Facility = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "UseFlightplansOnly":
						patrol.UsePreGeneratedFlightplansOnly = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "OTR":
					case "OneThirdRule":
						patrol.OneThirdRule = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TankerMinNumber_Total":
						patrol.TankerMinNumber_Total = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "MNOS":
						patrol.MinimumNumberOnStation = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "EmptySlotsList":
						patrol.EmptySlotsList = EmptyAircraftSlot.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
						break;
					case "ProsecutionArea":
						try
						{
							enumerator4 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								XmlNode xmlNode_3 = (XmlNode)enumerator4.Current;
								patrol.ProsecutionArea.Add(ReferencePoint.FromXML(ref xmlNode_3, ref concurrentDictionary_0));
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
					case "StationThrottle_Ship":
						patrol.StationThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "AttackTerrainFollowing_Aircraft":
						patrol.AttackTerrainFollowing_Aircraft = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TimeOnTarget":
					{
						DateTime value3 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						patrol.TimeOnTarget = value3;
						break;
					}
					case "HomeNavalbase":
						patrol._SecondaryNavalBaseID = xmlNode_.InnerText;
						break;
					case "Doctrine":
						patrol.Doctrine = Doctrine.FromXML(ref xmlNode_, patrol);
						break;
					case "AvCav":
						patrol.AvoidCavitation = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "ContinousCoverage_Enable":
						patrol.ContinousCoverage_Enable = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "AttackDistance_Submarine":
						patrol.AttackDistance_Submarine = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode_.InnerText))
						{
							patrol.ObjectID_Set(xmlNode_.InnerText);
							concurrentDictionary_0.TryAdd(patrol.ObjectID, patrol);
							break;
						}
						return (Patrol)concurrentDictionary_0[xmlNode_.InnerText];
					case "AttackThrottle_Ship":
						patrol.AttackThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TakeOffTime":
					{
						DateTime value2 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						patrol.TakeOffTime = value2;
						break;
					}
					case "TankerMinNumber_Station":
						patrol.TankerMinNumber_Station = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "NumberOfFlights_Engage":
						patrol.NumberOfFlights_Engage = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "AttackThrottle_Submarine":
						patrol.AttackThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "StationThrottle_Facility":
						patrol.StationThrottle_Facility = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "QRAs":
						patrol.ContinousCoverage_QRAs = ContinousCoverageStation.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
						break;
					case "UseAttackAltitude_Preset":
						patrol.UseAttackAltitude_Preset = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "FlightList":
						patrol.FlightList = Flight.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
						break;
					case "AttackDepth_Submarine":
						patrol.AttackDepth_Submarine = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "FuelQtyToStartLookingForTanker_Airborne":
						patrol.FuelQtyToStartLookingForTanker_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "ContinousCoverage_NumberOfFlightsNeededToAllowQRA":
						patrol.ContinousCoverage_NumberOfFlightsNeededToAllowQRA = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "AttackAltitude_Aircraft":
						patrol.AttackAltitude_Aircraft = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "TankerMissionList":
						try
						{
							enumerator5 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator5.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator5.Current;
								patrol.TankerMissions_IDs.Add(xmlNode2.InnerText);
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
					case "ContinousCoverage_QRAFlightGenerationMethod":
						patrol.ContinousCoverage_QRAFlightGenerationMethod = (_ContinousCoverageMethod)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "FlightSize":
						patrol.FlightSize = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "UseTransitAltitude_Preset":
						patrol.UseTransitAltitude_Preset = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "HomeAirbase":
						patrol._SecondaryAirBaseID = xmlNode_.InnerText;
						break;
					case "UseFlightSizeHardLimit":
						patrol.UseFlightSizeHardLimit = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "NumberOfFlights_Investigate":
						patrol.NumberOfFlights_Investigate = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "AttackDistance_Aircraft":
						patrol.AttackDistance_Aircraft = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "TransitAltitude_Preset":
						patrol.TransitAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TransitDepth_Submarine":
						patrol.TransitDepth_Submarine = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "TransitThrottle_Facility":
						patrol.TransitThrottle_Facility = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "UseAttackDepth_Submarine_Preset":
						patrol.UseAttackDepth_Submarine_Preset = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "ContinousCoverage_FlightGenerationMethod":
						patrol.ContinousCoverage_FlightGenerationMethod = (_ContinousCoverageMethod)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Category":
						patrol.Category = (MissionCategory)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "END":
					{
						DateTime value = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						patrol._EndTime = value;
						break;
					}
					case "MovementStyle":
						patrol.MovementStyle = (PatrolMovementStyle)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "AttackDistance_Ship":
						patrol.AttackDistance_Ship = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "AttackThrottle_Aircraft":
						patrol.AttackThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Formation_Attack":
						patrol.Formation_Attack = (_AircraftFormationType)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "_Phase":
						patrol._Phase = (MissionPhase)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "PriorityWeight":
						patrol.PriorityWeight = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "NumberOfBoats_Investigate":
						patrol.NumberOfBoats_Investigate = (_GroupQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "ContinousCoverage_StationTime":
						patrol.ContinousCoverage_StationTime = (_ContinousCoverageStationTime)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "ContinousCoverage_Duration":
						patrol.ContinousCoverage_Duration = (_ContinousCoverageDuration)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "InvestigateOutsidePatrolArea":
					case "IOPA":
						patrol.m_SetterConsumer = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "UseStationDepth_Submarine_Preset":
						patrol.UseStationDepth_Submarine_Preset = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "StationDepth_Submarine_Preset":
						patrol.StationDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Type":
						if (Versioned.IsNumeric(xmlNode_.InnerText))
						{
							patrol.Type = (GlobalVariables.PatrolType)Conversions.ToByte(xmlNode_.InnerText);
						}
						else
						{
							patrol.Type = (GlobalVariables.PatrolType)Enum.Parse(typeof(GlobalVariables.PatrolType), xmlNode_.InnerText, ignoreCase: true);
						}
						break;
					case "AssignedUnitsList":
						try
						{
							enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode = (XmlNode)enumerator2.Current;
								patrol.UnitsAssignedToMissionIDs.Add(xmlNode.InnerText);
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
					case "AttackDepth_Submarine_Preset":
						patrol.AttackDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TankerUsage":
						patrol.TankerUsage = (TankerMethod)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "AEOIPA":
					case "ActiveEMCONOnlyInPatrolArea":
						patrol.ActiveEMCONOnlyInPatrolOrProsecutionArea = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "StationThrottle":
					case "PatrolThrottle":
					case "StationThrottle_Aircraft":
						patrol.StationThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TankerFollowsReceivers":
						patrol.TankerFollowsReceivers = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "StationThrottle_Submarine":
						patrol.StationThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TAO":
					case "TransitAltitude":
					case "TransitAltitude_Aircraft":
						patrol.TransitAltitude_Aircraft = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "MinAircraftReq":
						patrol.MinimumNumberOfAircraft = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "OAO":
					case "StationAltitude_Aircraft":
					case "StationAltitude":
						patrol.StationAltitude_Aircraft = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "UseStationAltitude_Preset":
						patrol.UseStationAltitude_Preset = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "GroupSize":
						patrol.GroupSize = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TransitThrottle_Submarine":
						patrol.TransitThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Formation_Cruise":
						patrol.Formation_Cruise = (_AircraftFormationType)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "ContinousCoverage_AllowQRA":
						patrol.ContinousCoverage_QRAEnable = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "StationAltitude_Preset":
						patrol.StationAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Completion":
						patrol.Completion = Conversions.ToSingle(xmlNode_.InnerText);
						break;
					case "StationTerrainFollowing_Aircraft":
						patrol.StationTerrainFollowing_Aircraft = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "MaxReceiversInQueuePerTanker_Airborne":
						patrol.MaxReceiversInQueuePerTanker_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "StationDepth_Submarine":
						patrol.StationDepth_Submarine = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "TransitThrottle":
					case "TransitThrottle_Aircraft":
						patrol.TransitThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
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
			if (patrol.FlightSize == 0)
			{
				Patrol patrol2 = patrol;
				if (patrol2.Type == GlobalVariables.PatrolType.SEAD)
				{
					patrol.Doctrine.SetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._UseShootTourists.No);
				}
				if (patrol2.Type == GlobalVariables.PatrolType.ASW || patrol2.Type == GlobalVariables.PatrolType.ASuW_Mixed || patrol2.Type == GlobalVariables.PatrolType.ASuW_Naval)
				{
					patrol.Doctrine.SetWeaponControlStatus_Submarine(scenario_0, bool_0: false, null, bool_1: false, bool_2: false, Doctrine._WCS.Free);
				}
			}
			byte? b = (byte?)patrol.TransitThrottle_Aircraft;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				patrol.TransitThrottle_Aircraft = ActiveUnit.Throttle.Cruise;
			}
			if (patrol.TransitThrottle_Submarine == ActiveUnit.Throttle.FullStop)
			{
				if (patrol.Type == GlobalVariables.PatrolType.ASW)
				{
					patrol.Doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._WeaponStateRTB.No);
					patrol.Doctrine.SetBingoJokerRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._FuelStateRTB.YesFirstUnit);
				}
				else
				{
					patrol.Doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._WeaponStateRTB.YesLastUnit);
					patrol.Doctrine.SetBingoJokerRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._FuelStateRTB.YesFirstUnit);
				}
				patrol.AttackThrottle_Aircraft = null;
				patrol.TransitTerrainFollowing_Aircraft = false;
				patrol.StationTerrainFollowing_Aircraft = false;
				patrol.AttackTerrainFollowing_Aircraft = false;
				patrol.TransitThrottle_Submarine = ActiveUnit.Throttle.Cruise;
				patrol.StationThrottle_Submarine = ActiveUnit.Throttle.Loiter;
				patrol.AttackThrottle_Submarine = null;
				patrol.TransitThrottle_Ship = ActiveUnit.Throttle.Cruise;
				patrol.StationThrottle_Ship = ActiveUnit.Throttle.Loiter;
				patrol.AttackThrottle_Ship = null;
				patrol.TransitThrottle_Facility = ActiveUnit.Throttle.Cruise;
				patrol.StationThrottle_Facility = ActiveUnit.Throttle.Loiter;
				patrol.AttackThrottle_Facility = null;
			}
			if (patrol.Doctrine.ReplenishmentSelection_Inherits())
			{
				patrol.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
			}
			if (patrol.TransitAltitude_Aircraft.HasValue && patrol.UseTransitAltitude_Preset.GetValueOrDefault())
			{
				patrol.UseTransitAltitude_Preset = false;
				patrol.TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
			}
			if (patrol.StationAltitude_Aircraft.HasValue && patrol.UseStationAltitude_Preset.GetValueOrDefault())
			{
				patrol.UseStationAltitude_Preset = false;
				patrol.StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
			}
			if (patrol.AttackAltitude_Aircraft.HasValue && patrol.UseAttackAltitude_Preset.GetValueOrDefault())
			{
				patrol.UseAttackAltitude_Preset = false;
				patrol.AttackAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
			}
			if (patrol.TransitDepth_Submarine.HasValue && patrol.UseTransitDepth_Submarine_Preset.GetValueOrDefault())
			{
				patrol.UseTransitDepth_Submarine_Preset = false;
				patrol.TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
			}
			if (patrol.StationDepth_Submarine.HasValue && patrol.UseStationDepth_Submarine_Preset.GetValueOrDefault())
			{
				patrol.UseStationDepth_Submarine_Preset = false;
				patrol.StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
			}
			if (patrol.AttackDepth_Submarine.HasValue && patrol.UseAttackDepth_Submarine_Preset.GetValueOrDefault())
			{
				patrol.UseAttackDepth_Submarine_Preset = false;
				patrol.AttackDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
			}
			if (!flag)
			{
				switch (patrol.Type)
				{
				default:
					patrol.IncludeInATO = false;
					break;
				case GlobalVariables.PatrolType.ASW:
					patrol.IncludeInATO = false;
					break;
				case GlobalVariables.PatrolType.ASuW_Naval:
					patrol.IncludeInATO = true;
					break;
				case GlobalVariables.PatrolType.AAW:
					patrol.IncludeInATO = true;
					break;
				case GlobalVariables.PatrolType.ASuW_Land:
					patrol.IncludeInATO = true;
					break;
				case GlobalVariables.PatrolType.ASuW_Mixed:
					patrol.IncludeInATO = true;
					break;
				case GlobalVariables.PatrolType.SEAD:
					patrol.IncludeInATO = true;
					break;
				}
			}
			if (patrol.NumberOfFlights_Investigate == _FlightQty.NoPreferences)
			{
				switch (patrol.Type)
				{
				default:
					patrol.NumberOfFlights_Investigate = _FlightQty.Flight_x1;
					patrol.NumberOfFlights_Engage = _FlightQty.All;
					patrol.WingmanEngageDistance = 5;
					patrol.NumberOfBoats_Investigate = _GroupQty.Group_x1;
					patrol.NumberOfBoats_Engage = _GroupQty.All;
					patrol.GroupMemberEngageDistance = 5;
					break;
				case GlobalVariables.PatrolType.ASW:
					patrol.NumberOfFlights_Investigate = _FlightQty.Flight_x2;
					patrol.NumberOfFlights_Engage = _FlightQty.Flight_x2;
					patrol.WingmanEngageDistance = 5;
					patrol.NumberOfBoats_Investigate = _GroupQty.Group_x2;
					patrol.NumberOfBoats_Engage = _GroupQty.Group_x2;
					patrol.GroupMemberEngageDistance = 5;
					break;
				case GlobalVariables.PatrolType.ASuW_Naval:
					patrol.NumberOfFlights_Investigate = _FlightQty.Flight_x1;
					patrol.NumberOfFlights_Engage = _FlightQty.All;
					patrol.WingmanEngageDistance = 5;
					patrol.NumberOfBoats_Investigate = _GroupQty.Group_x1;
					patrol.NumberOfBoats_Engage = _GroupQty.All;
					patrol.GroupMemberEngageDistance = 5;
					break;
				case GlobalVariables.PatrolType.AAW:
					patrol.NumberOfFlights_Investigate = _FlightQty.Flight_x1;
					patrol.NumberOfFlights_Engage = _FlightQty.All;
					patrol.WingmanEngageDistance = 5;
					patrol.NumberOfBoats_Investigate = _GroupQty.Group_x1;
					patrol.NumberOfBoats_Engage = _GroupQty.All;
					patrol.GroupMemberEngageDistance = 5;
					break;
				case GlobalVariables.PatrolType.ASuW_Land:
					patrol.NumberOfFlights_Investigate = _FlightQty.Flight_x1;
					patrol.NumberOfFlights_Engage = _FlightQty.All;
					patrol.WingmanEngageDistance = 5;
					patrol.NumberOfBoats_Investigate = _GroupQty.Group_x1;
					patrol.NumberOfBoats_Engage = _GroupQty.All;
					patrol.GroupMemberEngageDistance = 5;
					break;
				case GlobalVariables.PatrolType.ASuW_Mixed:
					patrol.NumberOfFlights_Investigate = _FlightQty.Flight_x1;
					patrol.NumberOfFlights_Engage = _FlightQty.All;
					patrol.WingmanEngageDistance = 5;
					patrol.NumberOfBoats_Investigate = _GroupQty.Group_x1;
					patrol.NumberOfBoats_Engage = _GroupQty.All;
					patrol.GroupMemberEngageDistance = 5;
					break;
				case GlobalVariables.PatrolType.SEAD:
					patrol.NumberOfFlights_Investigate = _FlightQty.Flight_x1;
					patrol.NumberOfFlights_Engage = _FlightQty.All;
					patrol.WingmanEngageDistance = 5;
					patrol.NumberOfBoats_Investigate = _GroupQty.Group_x1;
					patrol.NumberOfBoats_Engage = _GroupQty.All;
					patrol.GroupMemberEngageDistance = 5;
					break;
				}
			}
			if (patrol.ContinousCoverage_QRANumberOfFlights == _FlightQty.NoPreferences)
			{
				patrol.ContinousCoverage_Enable = false;
				patrol.ContinousCoverage_FlightGenerationMethod = _ContinousCoverageMethod.Dynamic;
				patrol.ContinousCoverage_StationTime = _ContinousCoverageStationTime.min_45;
				patrol.ContinousCoverage_Overlap = _ContinousCoverageOverlap.Min_2;
				patrol.ContinousCoverage_Duration = _ContinousCoverageDuration.hr_6;
				patrol.ContinousCoverage_QRAEnable = false;
				patrol.ContinousCoverage_QRAFlightGenerationMethod = _ContinousCoverageMethod.Dynamic;
				patrol.ContinousCoverage_QRANumberOfFlights = _FlightQty.Flight_x1;
				patrol.ContinousCoverage_NumberOfFlightsNeededToAllowQRA = _FlightQty.Flight_x2;
			}
			return patrol;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100644", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Patrol result = new Patrol(null, scenario_0, "");
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public bool GetInvestigateOutsidePatrolArea(Scenario scenario_0)
	{
		return m_SetterConsumer;
	}

	[SpecialName]
	public void SetInvestigateOutsidePatrolArea(Scenario scenario_0, bool bool_0)
	{
		try
		{
			m_SetterConsumer = bool_0;
			if (bool_0)
			{
				return;
			}
			foreach (ActiveUnit item in scenario_0.ActiveUnits_List.ToList())
			{
				if (item == null || Information.IsNothing(item.AssignedMissionOrPackage()) || item.AssignedMissionOrPackage() != this)
				{
					continue;
				}
				Contact[] targets_ReadOnly = item.AI.Targets_ReadOnly;
				Contact[] array = targets_ReadOnly;
				foreach (Contact contact in array)
				{
					if (!item.Weaponry.IsGuidingWeaponsOntoThisContact(contact) && item.AI.TargetingBehaviorForThisTarget(contact) == ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted && !contact.GetIsInsideThisArea(PatrolArea, scenario_0, bool_0: true))
					{
						item.AI.DropTarget(contact);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100645", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	public bool GetInvestigateWithinWeaponRange(Scenario scenario_0)
	{
		return _CreatorConsumer;
	}

	[SpecialName]
	public void SetInvestigateWithinWeaponRange(Scenario scenario_0, bool bool_0)
	{
		try
		{
			_CreatorConsumer = bool_0;
			if (bool_0)
			{
				return;
			}
			bool investigateOutsidePatrolArea = GetInvestigateOutsidePatrolArea(scenario_0);
			bool hasProsecutionArea = HasProsecutionArea;
			if (investigateOutsidePatrolArea && !hasProsecutionArea)
			{
				return;
			}
			foreach (ActiveUnit item in scenario_0.ActiveUnits_List.ToList())
			{
				if (item == null || Information.IsNothing(item.AssignedMissionOrPackage()) || item.AssignedMissionOrPackage() != this)
				{
					continue;
				}
				Contact[] targets_ReadOnly = item.AI.Targets_ReadOnly;
				if (targets_ReadOnly.Count() <= 0)
				{
					continue;
				}
				Contact[] array = targets_ReadOnly;
				Contact[] array2 = array;
				foreach (Contact contact in array2)
				{
					if (item.AI.TargetingBehaviorForThisTarget(contact) != 0 || item.Weaponry.IsGuidingWeaponsOntoThisContact(contact))
					{
						continue;
					}
					if (investigateOutsidePatrolArea)
					{
						if (!hasProsecutionArea || contact.GetIsInsideThisArea(PatrolArea, scenario_0, bool_0: true) || contact.GetIsInsideThisArea(ProsecutionArea, scenario_0, bool_0: true))
						{
							continue;
						}
					}
					else if (contact.GetIsInsideThisArea(PatrolArea, scenario_0, bool_0: true))
					{
						continue;
					}
					item.AI.DropTarget(contact);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101296", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Patrol(Side side_0, Scenario scenario_0, string string_0)
		: base(side_0, scenario_0, string_0)
	{
		PatrolArea = new List<ReferencePoint>();
		PatrolArea_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_2nm_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_5nm_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_10nm_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_30nm_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_2nm_Buffered = new List<ReferencePoint>();
		PatrolArea_5nm_Buffered = new List<ReferencePoint>();
		PatrolArea_10nm_Buffered = new List<ReferencePoint>();
		PatrolArea_30nm_Buffered = new List<ReferencePoint>();
		ProsecutionArea = new List<ReferencePoint>();
		ProsecutionArea_ChangeCheck = new List<ReferencePoint>();
		ProsecutionArea_2nm_ChangeCheck = new List<ReferencePoint>();
		ProsecutionArea_5nm_ChangeCheck = new List<ReferencePoint>();
		ProsecutionArea_2nm_Buffered = new List<ReferencePoint>();
		ProsecutionArea_5nm_Buffered = new List<ReferencePoint>();
		IsMission = true;
		MissionClass = _MissionClass.Patrol;
	}

	public Patrol(Side side_0, Scenario scenario_0, string string_0, MissionCategory missionCategory_0, List<ReferencePoint> list_0, GlobalVariables.PatrolType patrolType_0, bool bool_0)
		: base(side_0, scenario_0, string_0)
	{
		PatrolArea = new List<ReferencePoint>();
		PatrolArea_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_2nm_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_5nm_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_10nm_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_30nm_ChangeCheck = new List<ReferencePoint>();
		PatrolArea_2nm_Buffered = new List<ReferencePoint>();
		PatrolArea_5nm_Buffered = new List<ReferencePoint>();
		PatrolArea_10nm_Buffered = new List<ReferencePoint>();
		PatrolArea_30nm_Buffered = new List<ReferencePoint>();
		ProsecutionArea = new List<ReferencePoint>();
		ProsecutionArea_ChangeCheck = new List<ReferencePoint>();
		ProsecutionArea_2nm_ChangeCheck = new List<ReferencePoint>();
		ProsecutionArea_5nm_ChangeCheck = new List<ReferencePoint>();
		ProsecutionArea_2nm_Buffered = new List<ReferencePoint>();
		ProsecutionArea_5nm_Buffered = new List<ReferencePoint>();
		IsMission = true;
		MissionClass = _MissionClass.Patrol;
		Name = string_0;
		Category = missionCategory_0;
		PatrolArea = list_0;
		Type = patrolType_0;
		OneThirdRule = true;
		StationThrottle_Aircraft = ActiveUnit.Throttle.Loiter;
		TransitThrottle_Aircraft = ActiveUnit.Throttle.Cruise;
		AttackThrottle_Aircraft = null;
		TransitTerrainFollowing_Aircraft = false;
		StationTerrainFollowing_Aircraft = false;
		AttackTerrainFollowing_Aircraft = false;
		TransitThrottle_Submarine = ActiveUnit.Throttle.Cruise;
		StationThrottle_Submarine = ActiveUnit.Throttle.Loiter;
		AttackThrottle_Submarine = null;
		TransitThrottle_Ship = ActiveUnit.Throttle.Cruise;
		StationThrottle_Ship = ActiveUnit.Throttle.Loiter;
		AttackThrottle_Ship = null;
		TransitThrottle_Facility = ActiveUnit.Throttle.Cruise;
		StationThrottle_Facility = ActiveUnit.Throttle.Loiter;
		AttackThrottle_Facility = null;
		TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
		StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
		AttackDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Shallow;
		TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.const_6;
		StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.const_6;
		AttackAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.const_6;
		UseTransitAltitude_Preset = true;
		UseStationAltitude_Preset = true;
		UseAttackAltitude_Preset = true;
		UseStationDepth_Submarine_Preset = true;
		UseTransitDepth_Submarine_Preset = true;
		UseAttackDepth_Submarine_Preset = true;
		m_SetterConsumer = true;
		_CreatorConsumer = true;
		SprintAndDrift = false;
		AvoidCavitation = false;
		UseFlightSizeHardLimit = true;
		Doctrine._WCS value = Doctrine._WCS.Free;
		if (scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticSubComms))
		{
			byte? b = (byte?)Doctrine.GetWeaponControlStatus_Submarine(scenario_0, bool_0: false, false, bool_1: false, bool_2: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() != 0) : null).GetValueOrDefault())
			{
				value = Doctrine._WCS.Tight;
			}
		}
		switch (Type)
		{
		default:
			Doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._WeaponStateRTB.YesLastUnit);
			Doctrine.SetBingoJokerRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._FuelStateRTB.YesFirstUnit);
			base.FlightSize = 1;
			IncludeInATO = false;
			break;
		case GlobalVariables.PatrolType.ASW:
			Doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._WeaponStateRTB.No);
			Doctrine.SetBingoJokerRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._FuelStateRTB.YesFirstUnit);
			Doctrine.SetWeaponControlStatus_Submarine(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, value);
			SprintAndDrift = true;
			base.FlightSize = 1;
			IncludeInATO = false;
			break;
		case GlobalVariables.PatrolType.ASuW_Naval:
			Doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._WeaponStateRTB.YesLastUnit);
			Doctrine.SetBingoJokerRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._FuelStateRTB.YesFirstUnit);
			Doctrine.SetWeaponControlStatus_Submarine(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, value);
			base.FlightSize = 1;
			IncludeInATO = true;
			break;
		case GlobalVariables.PatrolType.AAW:
			Doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._WeaponStateRTB.YesLastUnit);
			Doctrine.SetBingoJokerRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._FuelStateRTB.YesFirstUnit);
			base.FlightSize = 2;
			IncludeInATO = true;
			break;
		case GlobalVariables.PatrolType.ASuW_Land:
			Doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._WeaponStateRTB.YesLastUnit);
			Doctrine.SetBingoJokerRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._FuelStateRTB.YesFirstUnit);
			base.FlightSize = 2;
			IncludeInATO = true;
			break;
		case GlobalVariables.PatrolType.ASuW_Mixed:
			Doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._WeaponStateRTB.YesLastUnit);
			Doctrine.SetBingoJokerRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._FuelStateRTB.YesFirstUnit);
			Doctrine.SetWeaponControlStatus_Submarine(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, value);
			base.FlightSize = 2;
			IncludeInATO = true;
			break;
		case GlobalVariables.PatrolType.SEAD:
			Doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._WeaponStateRTB.YesLastUnit);
			Doctrine.SetBingoJokerRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._FuelStateRTB.YesFirstUnit);
			base.FlightSize = 2;
			IncludeInATO = true;
			break;
		}
		GroupSize = 1;
		Doctrine.SetIgnorePlottedCourse(scenario_0, bool_0: false, null, bool_1: false, bool_2: false, Doctrine._UseIgnorePlottedCourse.Yes);
		Doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Active, scenario_0);
		Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
		switch (Type)
		{
		default:
			NumberOfFlights_Investigate = _FlightQty.Flight_x1;
			NumberOfFlights_Engage = _FlightQty.All;
			WingmanEngageDistance = 5;
			NumberOfBoats_Investigate = _GroupQty.Group_x1;
			NumberOfBoats_Engage = _GroupQty.All;
			GroupMemberEngageDistance = 5;
			break;
		case GlobalVariables.PatrolType.ASW:
			NumberOfFlights_Investigate = _FlightQty.Flight_x2;
			NumberOfFlights_Engage = _FlightQty.Flight_x2;
			WingmanEngageDistance = 5;
			NumberOfBoats_Investigate = _GroupQty.Group_x2;
			NumberOfBoats_Engage = _GroupQty.Group_x2;
			GroupMemberEngageDistance = 5;
			break;
		case GlobalVariables.PatrolType.ASuW_Naval:
			NumberOfFlights_Investigate = _FlightQty.Flight_x1;
			NumberOfFlights_Engage = _FlightQty.All;
			WingmanEngageDistance = 5;
			NumberOfBoats_Investigate = _GroupQty.Group_x1;
			NumberOfBoats_Engage = _GroupQty.All;
			GroupMemberEngageDistance = 5;
			break;
		case GlobalVariables.PatrolType.AAW:
			NumberOfFlights_Investigate = _FlightQty.Flight_x1;
			NumberOfFlights_Engage = _FlightQty.All;
			WingmanEngageDistance = 5;
			NumberOfBoats_Investigate = _GroupQty.Group_x1;
			NumberOfBoats_Engage = _GroupQty.All;
			GroupMemberEngageDistance = 5;
			break;
		case GlobalVariables.PatrolType.ASuW_Land:
			NumberOfFlights_Investigate = _FlightQty.Flight_x1;
			NumberOfFlights_Engage = _FlightQty.All;
			WingmanEngageDistance = 5;
			NumberOfBoats_Investigate = _GroupQty.Group_x1;
			NumberOfBoats_Engage = _GroupQty.All;
			GroupMemberEngageDistance = 5;
			break;
		case GlobalVariables.PatrolType.ASuW_Mixed:
			NumberOfFlights_Investigate = _FlightQty.Flight_x1;
			NumberOfFlights_Engage = _FlightQty.All;
			WingmanEngageDistance = 5;
			NumberOfBoats_Investigate = _GroupQty.Group_x1;
			NumberOfBoats_Engage = _GroupQty.All;
			GroupMemberEngageDistance = 5;
			break;
		case GlobalVariables.PatrolType.SEAD:
			NumberOfFlights_Investigate = _FlightQty.Flight_x1;
			NumberOfFlights_Engage = _FlightQty.All;
			WingmanEngageDistance = 5;
			NumberOfBoats_Investigate = _GroupQty.Group_x1;
			NumberOfBoats_Engage = _GroupQty.All;
			GroupMemberEngageDistance = 5;
			break;
		}
		ContinousCoverage_Enable = false;
		ContinousCoverage_FlightGenerationMethod = _ContinousCoverageMethod.Dynamic;
		ContinousCoverage_StationTime = _ContinousCoverageStationTime.min_45;
		ContinousCoverage_Overlap = _ContinousCoverageOverlap.Min_2;
		ContinousCoverage_Duration = _ContinousCoverageDuration.hr_6;
		ContinousCoverage_QRAEnable = false;
		ContinousCoverage_QRAFlightGenerationMethod = _ContinousCoverageMethod.Dynamic;
		ContinousCoverage_QRANumberOfFlights = _FlightQty.Flight_x1;
		ContinousCoverage_NumberOfFlightsNeededToAllowQRA = _FlightQty.Flight_x2;
		string string_ = null;
		if (bool_0 && !ActiveUnit_Navigator.ValidateArea(ref PatrolArea, ref string_, side_0, scenario_0, "巡逻任务'" + Name + "'"))
		{
			GameGeneral.ResolveBridge(string_, side_0);
		}
	}

	[SpecialName]
	public override string GetDescriptionString(Scenario scenario_0)
	{
		GlobalVariables.PatrolType type = Type;
		if (1 == 0)
		{
		}
		string result = type switch
		{
			GlobalVariables.PatrolType.ASW => "反潜ASW巡逻", 
			GlobalVariables.PatrolType.ASuW_Naval => "反海面目标ASuW巡逻（海军）", 
			GlobalVariables.PatrolType.AAW => "反空中目标AAW巡逻", 
			GlobalVariables.PatrolType.ASuW_Land => "反地面目标ASuW巡逻（陆军）", 
			GlobalVariables.PatrolType.ASuW_Mixed => "反地面和海面目标ASuW巡逻（联合）", 
			GlobalVariables.PatrolType.SEAD => "防空压制SEAD巡逻", 
			GlobalVariables.PatrolType.SeaControl => "海域控制巡逻", 
			_ => Type.ToString(), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	[SpecialName]
	public Group GetParentGroup(Scenario scenario_0)
	{
		foreach (Group group in scenario_0.Groups)
		{
			if (group.Patrols.Contains(this))
			{
				return group;
			}
		}
		return null;
	}

	public override void Printout(StringBuilder stringBuilder_0)
	{
		throw new NotImplementedException();
	}

	public override Mission Clone()
	{
		Patrol obj = (Patrol)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Name = "[克隆]" + Name;
		obj.PatrolArea = new ReferencePoint().ExcludeWriter(ref PatrolArea);
		obj.ProsecutionArea = new ReferencePoint().ExcludeWriter(ref ProsecutionArea);
		return obj;
	}

	internal bool PopStub(Contact contact_0)
	{
		if (contact_0 != null && contact_0.ActualUnit != null)
		{
			if (HasProsecutionArea && contact_0.GetIsInsideThisArea(ProsecutionArea, contact_0.ActualUnit.ParentScen, bool_0: true))
			{
				return true;
			}
			if (contact_0.GetIsInsideThisArea(PatrolArea, contact_0.ActualUnit.ParentScen, bool_0: true))
			{
				return true;
			}
		}
		return false;
	}
}
