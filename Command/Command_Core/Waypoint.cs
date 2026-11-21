using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Waypoint : GeoPoint
{
	public sealed class FlightPlanSegment
	{
		public double StartLatitude;

		public double StartLongitude;

		public double EndLatitude;

		public double EndLongitude;

		public FlightPlanSegment(ref double double_0, double double_1, double double_2, double double_3)
		{
			StartLatitude = double_0;
			StartLongitude = double_1;
			EndLatitude = double_2;
			EndLongitude = double_3;
		}

		public FlightPlanSegment()
		{
		}
	}

	public enum WaypointType
	{
		ManualPlottedCourseWaypoint,
		PatrolStation,
		TerminalPoint,
		LocalizationRun,
		PathfindingPoint,
		Assemble,
		TurningPoint,
		InitialPoint,
		Split,
		Formate,
		Target,
		LandingMarshal,
		StrikeIngress,
		StrikeEgress,
		Refuel,
		TakeOff,
		Marshal,
		WeaponLaunch,
		Land,
		WeaponTarget,
		StationStart_Racetrack,
		StationStart_FigureEight,
		StationStart_Area,
		StationStart_RaceTrackRandom,
		StationEnd,
		PickupPoint,
		HoldStart,
		HoldEnd,
		Launch,
		Activation,
		Termination,
		DropOffPoint
	}

	public enum WaypointCategory
	{
		PlottedCourse,
		FlightPlan,
		WeaponRoute
	}

	public enum WaypointCreator : byte
	{
		Pathfinder,
		Navigator,
		Manual,
		MissionPlanner
	}

	public enum TurnRateCategory : byte
	{
		StandardRateTurn,
		HalfStandardRateTurn,
		DoubleStandardRateTurn,
		FlatTurn,
		TwoGTurn,
		const_5,
		const_6
	}

	public enum FixedFree
	{
		Free,
		Fixed,
		Bound,
		Relative,
		None
	}

	public enum Formation
	{
		Spread = 0,
		Trail_1nm = 1,
		Split = 100
	}

	public enum SpeedToT
	{
		No,
		Yes_DownOnly,
		Yes_UpOrDown_Military,
		Yes_UpOrDown_Afterburner
	}

	public WaypointType Type;

	public WaypointCategory Category;

	public string Description;

	public bool IsManualEditable;

	private ActiveUnit_Kinematics.UnitThrottlePreset decoratorReader;

	private ActiveUnit_AI.AircraftAltitudePreset _ProcessReader;

	private ActiveUnit_AI.SubmarineDepthPreset _ThreadReader;

	private bool _RuleReader;

	private float? collectionReader;

	public ActiveUnit.TerrainFollowMode TerrainFollowingType;

	public int ReferenceWeapon_ID;

	public float ActualSpeed;

	private float? instanceReader;

	public bool OvershootWaypoint;

	public float? DesiredAltitude_TerrainFollowing;

	private float? m_ObjectReader;

	private bool m_ParameterReader;

	public bool? SprintDrift;

	public float? SprintDrift_AverageSpeed;

	public bool? AvoidCavitation;

	public WaypointCreator Creator;

	private DateTime? m_ExpressionReader;

	public DateTime? Time_Zulu_Weapon;

	public DateTime? Time_Local;

	public DateTime? Time_Local_Weapon;

	public Weather.TTimeOfDayType TimeOfDay;

	public FixedFree TimeFixed;

	public FixedFree SpeedFixed;

	public SpeedToT SpeedAdjustmentToT;

	public Formation FlightFormation;

	public float Leg_FuelRequired;

	public float Leg_FuelRemaining;

	public float Leg_Time_Straight;

	public float Leg_Time_Turn;

	public float Leg_Time_Weapon;

	public float Leg_TotalTime;

	public float Leg_Time_ErrorMargin;

	public float Leg_Distance_Straight;

	public float Leg_Distance_Turn;

	public float Leg_Speed_Straight;

	public float Leg_Speed_Turn;

	public float Leg_TotalDistance;

	public bool Leg_PreviousWaypointIsFixedSpeed;

	public bool Leg_TwoWaypointsAgoIsFixedSpeed;

	public Waypoint Waypoint_LeadElementWingman;

	public Waypoint Waypoint_SecondElement;

	public Waypoint Waypoint_SecondElementWingman;

	public Waypoint Waypoint_ThirdElement;

	public Waypoint Waypoint_ThirdElementWingman;

	public float Leg_FuelRemaining_LeadElementWingman;

	public float Leg_FuelRemaining_SecondElement;

	public float Leg_FuelRemaining_SecondElementWingman;

	public float Leg_FuelRemaining_ThirdElement;

	public float Leg_FuelRemaining_ThirdElementWingman;

	public float Leg_TotalDistance_LeadElementWingman;

	public float Leg_TotalDistance_SecondElement;

	public float Leg_TotalDistance_SecondElementWingman;

	public float Leg_TotalDistance_ThirdElement;

	public float Leg_TotalDistance_ThirdElementWingman;

	public float Hold_Time;

	public float Station_Time;

	public float SpacingManeuver_Time;

	public float Separation_Time;

	public Mission._AttackMethod AttackMethod;

	public TurnRateCategory TurnRate_Navigation;

	public Mission.TankerMethod TankerUsage;

	public List<string> TankerMissions_IDs;

	public List<Mission> TankerMissions;

	public int MaxReceiversInQueuePerTanker_Airborne;

	public int TankerMaxDistance_Airborne;

	public bool TankerFollowsReceivers;

	public int TankerFollowsReceivers_NumberOfWaypoints;

	public List<FlightPlanSegment> FlightplanPointsList;

	public GeoPoint RaceTrackHelperPoint;

	public int PreferredWeaponID;

	public string PreferredWeaponName;

	public float PreferredWeaponSpeed;

	public float PreferredWeaponAltitude;

	public float PreferredWeaponRange;

	public Mission._TargeteeringMethod TargeteeringMethod;

	public List<Mission.TargeteeringEntry> TargeteeringList;

	public List<Mission.TargeteeringEntry> TargeteeringList_LeadElementWingman;

	public List<Mission.TargeteeringEntry> TargeteeringList_SecondElement;

	public List<Mission.TargeteeringEntry> TargeteeringList_SecondElementWingman;

	public List<Mission.TargeteeringEntry> TargeteeringList_ThirdElement;

	public List<Mission.TargeteeringEntry> TargeteeringList_ThirdElementWingman;

	public List<Mission.WeaponeeringEntry> WeaponeeringList;

	public List<Mission.WeaponeeringEntry> WeaponeeringList_LeadElementWingman;

	public List<Mission.WeaponeeringEntry> WeaponeeringList_SecondElement;

	public List<Mission.WeaponeeringEntry> WeaponeeringList_SecondElementWingman;

	public List<Mission.WeaponeeringEntry> WeaponeeringList_ThirdElement;

	public List<Mission.WeaponeeringEntry> WeaponeeringList_ThirdElementWingman;

	private Doctrine dispatcherReader;

	public float? DesiredSpeed
	{
		get
		{
			return collectionReader;
		}
		set
		{
			collectionReader = value;
		}
	}

	public float? DesiredAltitude
	{
		get
		{
			return instanceReader;
		}
		set
		{
			instanceReader = value;
		}
	}

	public DateTime? Time_Zulu
	{
		get
		{
			return m_ExpressionReader;
		}
		set
		{
			m_ExpressionReader = value;
		}
	}

	public bool HasDoctrine => dispatcherReader != null;

	public Doctrine Doctrine
	{
		get
		{
			if (dispatcherReader == null)
			{
				List<ActiveUnit> list_ = null;
				dispatcherReader = new Doctrine(this, ref list_);
			}
			return dispatcherReader;
		}
	}

	public float? DesiredSpeedOverride
	{
		get
		{
			return m_ObjectReader;
		}
		set
		{
			m_ObjectReader = value;
		}
	}

	public bool DesiredAltitudeOverride
	{
		get
		{
			return m_ParameterReader;
		}
		set
		{
			if (!value)
			{
				TerrainFollowing = false;
			}
			m_ParameterReader = value;
		}
	}

	public ActiveUnit_AI.AircraftAltitudePreset AltitudePreset
	{
		get
		{
			return _ProcessReader;
		}
		set
		{
			_ProcessReader = value;
			if (value != 0)
			{
				DesiredAltitudeOverride = true;
			}
		}
	}

	public ActiveUnit_AI.SubmarineDepthPreset DepthPreset
	{
		get
		{
			return _ThreadReader;
		}
		set
		{
			_ThreadReader = value;
			if (value != 0)
			{
				DesiredAltitudeOverride = true;
			}
		}
	}

	public ActiveUnit_Kinematics.UnitThrottlePreset ThrottlePreset
	{
		get
		{
			return decoratorReader;
		}
		set
		{
			decoratorReader = value;
		}
	}

	public bool TerrainFollowing
	{
		get
		{
			return _RuleReader;
		}
		set
		{
			if (value && !DesiredAltitudeOverride)
			{
				DesiredAltitudeOverride = true;
			}
			_RuleReader = value;
		}
	}

	public void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("WPoint");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			if (hashSet_0 != null)
			{
				if (hashSet_0.Contains(ObjectID))
				{
					xmlWriter_0.WriteEndElement();
					return;
				}
				hashSet_0.Add(ObjectID);
			}
			xmlWriter_0.WriteElementString("Lon", XmlConvert.ToString(base.Longitude));
			xmlWriter_0.WriteElementString("Lat", XmlConvert.ToString(base.Latitude));
			if (base.Altitude != 0f)
			{
				xmlWriter_0.WriteElementString("Alt", XmlConvert.ToString(base.Altitude));
			}
			if (DesiredAltitude.HasValue)
			{
				xmlWriter_0.WriteElementString("DesiredAltitude", DesiredAltitude.ToString());
			}
			if (DesiredAltitude_TerrainFollowing.HasValue)
			{
				xmlWriter_0.WriteElementString("DesiredAltitude_TerrainFollowing", DesiredAltitude_TerrainFollowing.ToString());
			}
			int terrainFollowingType;
			if (TerrainFollowingType != 0)
			{
				XmlWriter obj = xmlWriter_0;
				terrainFollowingType = (int)TerrainFollowingType;
				obj.WriteElementString("TFT", terrainFollowingType.ToString());
			}
			if (DesiredSpeed.HasValue)
			{
				xmlWriter_0.WriteElementString("DesiredSpeed", DesiredSpeed.ToString());
			}
			if (!string.IsNullOrEmpty(Name))
			{
				xmlWriter_0.WriteElementString("Name", Name.ToString());
			}
			if (Creator != 0)
			{
				XmlWriter obj5 = xmlWriter_0;
				terrainFollowingType = (int)Creator;
				obj5.WriteElementString("Creator", terrainFollowingType.ToString());
			}
			XmlWriter obj6 = xmlWriter_0;
			terrainFollowingType = (int)Type;
			obj6.WriteElementString("Type", terrainFollowingType.ToString());
			if (Category != 0)
			{
				XmlWriter obj7 = xmlWriter_0;
				terrainFollowingType = (int)Category;
				obj7.WriteElementString("Category", terrainFollowingType.ToString());
			}
			if (!string.IsNullOrEmpty(Description))
			{
				xmlWriter_0.WriteElementString("Description", Description.ToString());
			}
			xmlWriter_0.WriteElementString("ThrottlePreset", ((byte)ThrottlePreset).ToString());
			if (AltitudePreset != 0)
			{
				xmlWriter_0.WriteElementString("AltitudePreset", ((byte)AltitudePreset).ToString());
			}
			if (DepthPreset != 0)
			{
				xmlWriter_0.WriteElementString("DepthPreset", ((byte)DepthPreset).ToString());
			}
			if (TurnRate_Navigation != 0)
			{
				XmlWriter obj8 = xmlWriter_0;
				byte turnRate_Navigation = (byte)TurnRate_Navigation;
				obj8.WriteElementString("TurnRate", turnRate_Navigation.ToString());
			}
			if (IsManualEditable)
			{
				xmlWriter_0.WriteElementString("IME", true.ToString());
			}
			if (TerrainFollowing)
			{
				xmlWriter_0.WriteElementString("TerrainFollowing", TerrainFollowing.ToString());
			}
			if (m_ObjectReader.HasValue)
			{
				xmlWriter_0.WriteElementString("DSO", m_ObjectReader.ToString());
			}
			if (m_ParameterReader)
			{
				xmlWriter_0.WriteElementString("DAO", m_ParameterReader.ToString());
			}
			if (SprintDrift.HasValue)
			{
				xmlWriter_0.WriteElementString("SprintDrift", SprintDrift.ToString());
			}
			if (SprintDrift_AverageSpeed.HasValue)
			{
				xmlWriter_0.WriteElementString("SprintDrift_AverageSpeed", SprintDrift_AverageSpeed.Value.ToString());
			}
			if (AvoidCavitation.HasValue)
			{
				xmlWriter_0.WriteElementString("AvoidCavitation", AvoidCavitation.ToString());
			}
			if (Time_Zulu.HasValue)
			{
				xmlWriter_0.WriteElementString("Time_Zulu", Time_Zulu.Value.ToBinary().ToString());
			}
			if (Time_Zulu_Weapon.HasValue)
			{
				xmlWriter_0.WriteElementString("Time_Zulu_Weapon", Time_Zulu_Weapon.Value.ToBinary().ToString());
			}
			if (Time_Local.HasValue)
			{
				xmlWriter_0.WriteElementString("Time_Local", Time_Local.Value.ToBinary().ToString());
			}
			if (Time_Local_Weapon.HasValue)
			{
				xmlWriter_0.WriteElementString("Time_Local_Weapon", Time_Local_Weapon.Value.ToBinary().ToString());
			}
			if (TimeOfDay != 0)
			{
				XmlWriter obj9 = xmlWriter_0;
				byte timeOfDay = (byte)TimeOfDay;
				obj9.WriteElementString("TimeOfDay", timeOfDay.ToString());
			}
			if (TimeFixed != 0)
			{
				XmlWriter obj10 = xmlWriter_0;
				terrainFollowingType = (int)TimeFixed;
				obj10.WriteElementString("TimeFixed", terrainFollowingType.ToString());
			}
			if (SpeedFixed != 0)
			{
				XmlWriter obj11 = xmlWriter_0;
				terrainFollowingType = (int)SpeedFixed;
				obj11.WriteElementString("SpeedFixed", terrainFollowingType.ToString());
			}
			if (FlightFormation != 0)
			{
				XmlWriter obj12 = xmlWriter_0;
				terrainFollowingType = (int)FlightFormation;
				obj12.WriteElementString("FlightFormation", terrainFollowingType.ToString());
			}
			if (SpeedAdjustmentToT != 0)
			{
				XmlWriter obj2 = xmlWriter_0;
				terrainFollowingType = (int)SpeedAdjustmentToT;
				obj2.WriteElementString("SpeedAdjustmentToT", terrainFollowingType.ToString());
			}
			if (TankerUsage != 0)
			{
				XmlWriter obj3 = xmlWriter_0;
				byte tankerUsage = (byte)TankerUsage;
				obj3.WriteElementString("TankerUsage", tankerUsage.ToString());
			}
			if (TankerMissions.Count > 0)
			{
				xmlWriter_0.WriteStartElement("TankerMissionList");
				foreach (Mission tankerMission in TankerMissions)
				{
					if (!Information.IsNothing(tankerMission))
					{
						xmlWriter_0.WriteElementString("ID", tankerMission.ObjectID);
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (MaxReceiversInQueuePerTanker_Airborne > 0)
			{
				xmlWriter_0.WriteElementString("MaxReceiversInQueuePerTanker_Airborne", MaxReceiversInQueuePerTanker_Airborne.ToString());
			}
			if (TankerFollowsReceivers)
			{
				xmlWriter_0.WriteElementString("TankerFollowsReceivers", TankerFollowsReceivers.ToString());
			}
			if (TankerFollowsReceivers_NumberOfWaypoints > 0)
			{
				xmlWriter_0.WriteElementString("TankerFollowsReceivers_NumberOfWaypoints", TankerFollowsReceivers_NumberOfWaypoints.ToString());
			}
			if (Leg_FuelRequired != 0f)
			{
				xmlWriter_0.WriteElementString("Leg_FuelRequired", Leg_FuelRequired.ToString());
			}
			if (Leg_FuelRemaining != 0f)
			{
				xmlWriter_0.WriteElementString("Leg_FuelRemaining", Leg_FuelRemaining.ToString());
			}
			if (Leg_Time_Turn != 0f)
			{
				xmlWriter_0.WriteElementString("Leg_Time_Turn", Leg_Time_Turn.ToString());
			}
			if (Leg_Time_Straight != 0f)
			{
				xmlWriter_0.WriteElementString("Leg_Time_Straight", Leg_Time_Straight.ToString());
			}
			if (Leg_Time_Weapon != 0f)
			{
				xmlWriter_0.WriteElementString("Leg_Time_Weapon", Leg_Time_Weapon.ToString());
			}
			if (Leg_TotalTime != 0f)
			{
				xmlWriter_0.WriteElementString("Leg_TotalTime", Leg_TotalTime.ToString());
			}
			if (Leg_Time_ErrorMargin != 0f)
			{
				xmlWriter_0.WriteElementString("Leg_Time_ErrorMargin", Leg_Time_ErrorMargin.ToString());
			}
			if (Leg_Distance_Straight != 0f)
			{
				xmlWriter_0.WriteElementString("Leg_Distance", Leg_Distance_Straight.ToString());
			}
			if (Leg_TotalDistance != 0f)
			{
				xmlWriter_0.WriteElementString("Leg_TotalDistance", Leg_TotalDistance.ToString());
			}
			if (Hold_Time != 0f)
			{
				xmlWriter_0.WriteElementString("Hold_Time", Hold_Time.ToString());
			}
			if (Station_Time != 0f)
			{
				xmlWriter_0.WriteElementString("Station_Time", Station_Time.ToString());
			}
			if (SpacingManeuver_Time != 0f)
			{
				xmlWriter_0.WriteElementString("SpacingManeuver_Time", SpacingManeuver_Time.ToString());
			}
			if (!Information.IsNothing(FlightplanPointsList) && FlightplanPointsList.Count > 0)
			{
				xmlWriter_0.WriteStartElement("FlightplanPointsList");
				foreach (FlightPlanSegment flightplanPoints in FlightplanPointsList)
				{
					if (!Information.IsNothing(flightplanPoints))
					{
						xmlWriter_0.WriteStartElement("FlightPlanSegment");
						xmlWriter_0.WriteElementString("StartLatitude", flightplanPoints.StartLatitude.ToString());
						xmlWriter_0.WriteElementString("StartLongitude", flightplanPoints.StartLongitude.ToString());
						xmlWriter_0.WriteElementString("EndLatitude", flightplanPoints.EndLatitude.ToString());
						xmlWriter_0.WriteElementString("EndLongitude", flightplanPoints.EndLongitude.ToString());
						xmlWriter_0.WriteEndElement();
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (PreferredWeaponID != 0)
			{
				xmlWriter_0.WriteElementString("PreferredWeaponID", PreferredWeaponID.ToString());
			}
			if (!string.IsNullOrEmpty(PreferredWeaponName))
			{
				xmlWriter_0.WriteElementString("PreferredWeaponName", PreferredWeaponName.ToString());
			}
			if (PreferredWeaponSpeed != 0f)
			{
				xmlWriter_0.WriteElementString("PreferredWeaponSpeed", PreferredWeaponSpeed.ToString());
			}
			if (PreferredWeaponAltitude != 0f)
			{
				xmlWriter_0.WriteElementString("PreferredWeaponAltitude", PreferredWeaponAltitude.ToString());
			}
			if (PreferredWeaponRange != 0f)
			{
				xmlWriter_0.WriteElementString("PreferredWeaponRange", PreferredWeaponRange.ToString());
			}
			if (!Information.IsNothing(Waypoint_LeadElementWingman))
			{
				xmlWriter_0.WriteStartElement("WP_LeadElementWingman");
				Waypoint_LeadElementWingman.ToXML(ref xmlWriter_0, ref hashSet_0);
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(Waypoint_SecondElement))
			{
				xmlWriter_0.WriteStartElement("WP_SecondElement");
				Waypoint_SecondElement.ToXML(ref xmlWriter_0, ref hashSet_0);
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(Waypoint_SecondElementWingman))
			{
				xmlWriter_0.WriteStartElement("WP_SecondElementWingman");
				Waypoint_SecondElementWingman.ToXML(ref xmlWriter_0, ref hashSet_0);
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(Waypoint_ThirdElement))
			{
				xmlWriter_0.WriteStartElement("WP_ThirdElement");
				Waypoint_ThirdElement.ToXML(ref xmlWriter_0, ref hashSet_0);
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(Waypoint_ThirdElementWingman))
			{
				xmlWriter_0.WriteStartElement("WP_ThirdElementWingman");
				Waypoint_ThirdElementWingman.ToXML(ref xmlWriter_0, ref hashSet_0);
				xmlWriter_0.WriteEndElement();
			}
			if (Leg_FuelRemaining_LeadElementWingman > 0f)
			{
				xmlWriter_0.WriteElementString("Leg_FuelRemaining_LeadElementWingman", Leg_FuelRemaining_LeadElementWingman.ToString());
			}
			if (Leg_FuelRemaining_SecondElement > 0f)
			{
				xmlWriter_0.WriteElementString("Leg_FuelRemaining_SecondElement", Leg_FuelRemaining_SecondElement.ToString());
			}
			if (Leg_FuelRemaining_SecondElementWingman > 0f)
			{
				xmlWriter_0.WriteElementString("Leg_FuelRemaining_SecondElementWingman", Leg_FuelRemaining_SecondElementWingman.ToString());
			}
			if (Leg_FuelRemaining_ThirdElement > 0f)
			{
				xmlWriter_0.WriteElementString("Leg_FuelRemaining_ThirdElement", Leg_FuelRemaining_ThirdElement.ToString());
			}
			if (Leg_FuelRemaining_ThirdElementWingman > 0f)
			{
				xmlWriter_0.WriteElementString("Leg_FuelRemaining_ThirdElementWingman", Leg_FuelRemaining_ThirdElementWingman.ToString());
			}
			if (Leg_TotalDistance_LeadElementWingman > 0f)
			{
				xmlWriter_0.WriteElementString("Leg_TotalDistance_LeadElementWingman", Leg_TotalDistance_LeadElementWingman.ToString());
			}
			if (Leg_TotalDistance_SecondElement > 0f)
			{
				xmlWriter_0.WriteElementString("Leg_TotalDistance_SecondElement", Leg_TotalDistance_SecondElement.ToString());
			}
			if (Leg_TotalDistance_SecondElementWingman > 0f)
			{
				xmlWriter_0.WriteElementString("Leg_TotalDistance_SecondElementWingman", Leg_TotalDistance_SecondElementWingman.ToString());
			}
			if (Leg_TotalDistance_ThirdElement > 0f)
			{
				xmlWriter_0.WriteElementString("Leg_TotalDistance_ThirdElement", Leg_TotalDistance_ThirdElement.ToString());
			}
			if (Leg_TotalDistance_ThirdElementWingman > 0f)
			{
				xmlWriter_0.WriteElementString("Leg_TotalDistance_ThirdElementWingman", Leg_TotalDistance_ThirdElementWingman.ToString());
			}
			XmlWriter obj4 = xmlWriter_0;
			terrainFollowingType = (int)AttackMethod;
			obj4.WriteElementString("AttackMethod", terrainFollowingType.ToString());
			if (Separation_Time > 0f)
			{
				xmlWriter_0.WriteElementString("AttackMethod_Time", Separation_Time.ToString());
			}
			if (!Information.IsNothing(RaceTrackHelperPoint))
			{
				xmlWriter_0.WriteStartElement("RaceTrackHelperPoint");
				xmlWriter_0.WriteRaw(RaceTrackHelperPoint.ToXML(hashSet_0));
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(dispatcherReader))
			{
				Doctrine doctrine = dispatcherReader;
				Scenario scenario_ = null;
				doctrine.ToXML(ref xmlWriter_0, ref scenario_);
			}
			xmlWriter_0.WriteElementString("ReferenceWeapon", ReferenceWeapon_ID.ToString());
			xmlWriter_0.WriteElementString("TargeteeringMethod", ((byte)TargeteeringMethod).ToString());
			if (!Information.IsNothing(TargeteeringList))
			{
				xmlWriter_0.WriteStartElement("TargeteeringList");
				foreach (Mission.TargeteeringEntry targeteering in TargeteeringList)
				{
					Mission.TargeteeringEntry targeteeringEntry_ = targeteering;
					if (!Information.IsNothing(targeteeringEntry_))
					{
						Mission.TargeteeringEntry.ToXML(ref xmlWriter_0, ref targeteeringEntry_);
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(TargeteeringList_LeadElementWingman))
			{
				xmlWriter_0.WriteStartElement("TargeteeringList_LeadElementWingman");
				foreach (Mission.TargeteeringEntry item in TargeteeringList_LeadElementWingman)
				{
					Mission.TargeteeringEntry targeteeringEntry_2 = item;
					if (!Information.IsNothing(targeteeringEntry_2))
					{
						Mission.TargeteeringEntry.ToXML(ref xmlWriter_0, ref targeteeringEntry_2);
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(TargeteeringList_SecondElement))
			{
				xmlWriter_0.WriteStartElement("TargeteeringList_SecondElement");
				foreach (Mission.TargeteeringEntry item3 in TargeteeringList_SecondElement)
				{
					Mission.TargeteeringEntry targeteeringEntry_3 = item3;
					if (!Information.IsNothing(targeteeringEntry_3))
					{
						Mission.TargeteeringEntry.ToXML(ref xmlWriter_0, ref targeteeringEntry_3);
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(TargeteeringList_SecondElementWingman))
			{
				xmlWriter_0.WriteStartElement("TargeteeringList_SecondElementWingman");
				foreach (Mission.TargeteeringEntry item4 in TargeteeringList_SecondElementWingman)
				{
					Mission.TargeteeringEntry targeteeringEntry_4 = item4;
					if (!Information.IsNothing(targeteeringEntry_4))
					{
						Mission.TargeteeringEntry.ToXML(ref xmlWriter_0, ref targeteeringEntry_4);
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(TargeteeringList_ThirdElement))
			{
				xmlWriter_0.WriteStartElement("TargeteeringList_ThirdElement");
				foreach (Mission.TargeteeringEntry item5 in TargeteeringList_ThirdElement)
				{
					Mission.TargeteeringEntry targeteeringEntry_5 = item5;
					if (!Information.IsNothing(targeteeringEntry_5))
					{
						Mission.TargeteeringEntry.ToXML(ref xmlWriter_0, ref targeteeringEntry_5);
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(TargeteeringList_ThirdElementWingman))
			{
				xmlWriter_0.WriteStartElement("TargeteeringList_ThirdElementWingman");
				foreach (Mission.TargeteeringEntry item6 in TargeteeringList_ThirdElementWingman)
				{
					Mission.TargeteeringEntry targeteeringEntry_6 = item6;
					if (!Information.IsNothing(targeteeringEntry_6))
					{
						Mission.TargeteeringEntry.ToXML(ref xmlWriter_0, ref targeteeringEntry_6);
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(WeaponeeringList))
			{
				xmlWriter_0.WriteStartElement("WeaponeeringList");
				foreach (Mission.WeaponeeringEntry weaponeering in WeaponeeringList)
				{
					Mission.WeaponeeringEntry weaponeeringEntry_ = weaponeering;
					if (!Information.IsNothing(weaponeeringEntry_))
					{
						Mission.WeaponeeringEntry.ToXML(ref xmlWriter_0, ref hashSet_0, ref weaponeeringEntry_);
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(WeaponeeringList_LeadElementWingman))
			{
				xmlWriter_0.WriteStartElement("WeaponeeringList_LeadElementWingman");
				foreach (Mission.WeaponeeringEntry item7 in WeaponeeringList_LeadElementWingman)
				{
					Mission.WeaponeeringEntry weaponeeringEntry_2 = item7;
					if (!Information.IsNothing(weaponeeringEntry_2))
					{
						Mission.WeaponeeringEntry.ToXML(ref xmlWriter_0, ref hashSet_0, ref weaponeeringEntry_2);
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(WeaponeeringList_SecondElement))
			{
				xmlWriter_0.WriteStartElement("WeaponeeringList_SecondElement");
				foreach (Mission.WeaponeeringEntry item8 in WeaponeeringList_SecondElement)
				{
					Mission.WeaponeeringEntry weaponeeringEntry_3 = item8;
					if (!Information.IsNothing(weaponeeringEntry_3))
					{
						Mission.WeaponeeringEntry.ToXML(ref xmlWriter_0, ref hashSet_0, ref weaponeeringEntry_3);
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(WeaponeeringList_SecondElementWingman))
			{
				xmlWriter_0.WriteStartElement("WeaponeeringList_SecondElementWingman");
				foreach (Mission.WeaponeeringEntry item9 in WeaponeeringList_SecondElementWingman)
				{
					Mission.WeaponeeringEntry weaponeeringEntry_4 = item9;
					if (!Information.IsNothing(weaponeeringEntry_4))
					{
						Mission.WeaponeeringEntry.ToXML(ref xmlWriter_0, ref hashSet_0, ref weaponeeringEntry_4);
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(WeaponeeringList_ThirdElement))
			{
				xmlWriter_0.WriteStartElement("WeaponeeringList_ThirdElement");
				foreach (Mission.WeaponeeringEntry item10 in WeaponeeringList_ThirdElement)
				{
					Mission.WeaponeeringEntry weaponeeringEntry_5 = item10;
					if (!Information.IsNothing(weaponeeringEntry_5))
					{
						Mission.WeaponeeringEntry.ToXML(ref xmlWriter_0, ref hashSet_0, ref weaponeeringEntry_5);
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(WeaponeeringList_ThirdElementWingman))
			{
				xmlWriter_0.WriteStartElement("WeaponeeringList_ThirdElementWingman");
				foreach (Mission.WeaponeeringEntry item2 in WeaponeeringList_ThirdElementWingman)
				{
					Mission.WeaponeeringEntry weaponeeringEntry_6 = item2;
					if (!Information.IsNothing(weaponeeringEntry_6))
					{
						Mission.WeaponeeringEntry.ToXML(ref xmlWriter_0, ref hashSet_0, ref weaponeeringEntry_6);
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100587", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static Waypoint FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			Waypoint waypoint = new Waypoint();
			bool flag = false;
			IEnumerator enumerator = null;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator12 = null;
				IEnumerator enumerator16 = null;
				IEnumerator enumerator17 = null;
				IEnumerator enumerator18 = null;
				IEnumerator enumerator19 = null;
				IEnumerator enumerator20 = null;
				IEnumerator enumerator21 = null;
				IEnumerator enumerator22 = null;
				IEnumerator enumerator2 = null;
				IEnumerator enumerator3 = null;
				IEnumerator enumerator4 = null;
				IEnumerator enumerator5 = null;
				IEnumerator enumerator6 = null;
				IEnumerator enumerator7 = null;
				IEnumerator enumerator8 = null;
				IEnumerator enumerator9 = null;
				IEnumerator enumerator10 = null;
				IEnumerator enumerator11 = null;
				IEnumerator enumerator13 = null;
				IEnumerator enumerator14 = null;
				IEnumerator enumerator15 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode_ = (XmlNode)enumerator.Current;
					switch (xmlNode_.Name)
					{
					case "TimeFixed":
						waypoint.TimeFixed = (FixedFree)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "RaceTrackHelperPoint":
						try
						{
							enumerator17 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator17.MoveNext())
							{
								XmlNode xmlNode_5 = (XmlNode)enumerator17.Current;
								waypoint.RaceTrackHelperPoint = GeoPoint.FromXML(ref xmlNode_5, ref concurrentDictionary_0);
							}
						}
						finally
						{
							if (enumerator17 is IDisposable)
							{
								(enumerator17 as IDisposable).Dispose();
							}
						}
						break;
					case "Leg_FuelRemaining":
						waypoint.Leg_FuelRemaining = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "AttackMethod_Time":
						waypoint.Separation_Time = Conversions.ToSingle(xmlNode_.InnerText);
						break;
					case "Leg_TotalDistance_SecondElement":
						waypoint.Leg_TotalDistance_SecondElement = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Name":
						waypoint.Name = xmlNode_.InnerText;
						break;
					case "TargeteeringList":
						waypoint.TargeteeringList = new List<Mission.TargeteeringEntry>();
						try
						{
							enumerator19 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator19.MoveNext())
							{
								XmlNode xmlNode_8 = (XmlNode)enumerator19.Current;
								Mission.TargeteeringEntry item12 = Mission.TargeteeringEntry.FromXML(ref xmlNode_8);
								waypoint.TargeteeringList.Add(item12);
							}
						}
						finally
						{
							if (enumerator19 is IDisposable)
							{
								(enumerator19 as IDisposable).Dispose();
							}
						}
						break;
					case "TurnRate":
						waypoint.TurnRate_Navigation = (TurnRateCategory)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "DesiredSpeedOverride":
					case "DSO":
						if (Operators.CompareString(xmlNode_.InnerText, false.ToString(), TextCompare: false) == 0)
						{
							waypoint.m_ObjectReader = null;
						}
						else
						{
							waypoint.m_ObjectReader = XmlConvert.ToSingle(xmlNode_.InnerText);
						}
						break;
					case "WP_ThirdElement":
						try
						{
							enumerator14 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator14.MoveNext())
							{
								XmlNode xmlNode_3 = (XmlNode)enumerator14.Current;
								waypoint.Waypoint_ThirdElement = FromXML(ref xmlNode_3, ref concurrentDictionary_0, scenario_0);
							}
						}
						finally
						{
							if (enumerator14 is IDisposable)
							{
								(enumerator14 as IDisposable).Dispose();
							}
						}
						break;
					case "Time_Local":
					{
						DateTime value = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						waypoint.Time_Local = value;
						break;
					}
					case "Station_Time":
						waypoint.Station_Time = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "FlightplanPointsList":
						waypoint.FlightplanPointsList = new List<FlightPlanSegment>();
						try
						{
							enumerator12 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator12.MoveNext())
							{
								XmlNode xmlNode = (XmlNode)enumerator12.Current;
								FlightPlanSegment flightPlanSegment = new FlightPlanSegment();
								try
								{
									enumerator16 = xmlNode.ChildNodes.GetEnumerator();
									while (enumerator16.MoveNext())
									{
										XmlNode xmlNode2 = (XmlNode)enumerator16.Current;
										switch (xmlNode2.Name)
										{
										case "StartLongitude":
											flightPlanSegment.StartLongitude = XmlConvert.ToDouble(xmlNode2.InnerText.Replace(",", "."));
											break;
										case "StartLatitude":
											flightPlanSegment.StartLatitude = XmlConvert.ToDouble(xmlNode2.InnerText.Replace(",", "."));
											break;
										case "EndLongitude":
											flightPlanSegment.EndLongitude = XmlConvert.ToDouble(xmlNode2.InnerText.Replace(",", "."));
											break;
										case "EndLatitude":
											flightPlanSegment.EndLatitude = XmlConvert.ToDouble(xmlNode2.InnerText.Replace(",", "."));
											break;
										}
									}
								}
								finally
								{
									if (enumerator16 is IDisposable)
									{
										(enumerator16 as IDisposable).Dispose();
									}
								}
								waypoint.FlightplanPointsList.Add(flightPlanSegment);
							}
						}
						finally
						{
							if (enumerator12 is IDisposable)
							{
								(enumerator12 as IDisposable).Dispose();
							}
						}
						break;
					case "PreferredWeaponRange":
						waypoint.PreferredWeaponRange = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Leg_TotalDistance_SecondElementWingman":
						waypoint.Leg_TotalDistance_SecondElementWingman = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "ReferenceWeapon":
						waypoint.ReferenceWeapon_ID = Conversions.ToInteger(xmlNode_.InnerText.ToString());
						break;
					case "TankerMaxDistance_Airborne":
						waypoint.TankerMaxDistance_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "SprintDrift_AverageSpeed":
						waypoint.SprintDrift_AverageSpeed = Conversions.ToSingle(xmlNode_.InnerText);
						break;
					case "SonarActive":
						flag = true;
						flag4 = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Doctrine":
						waypoint.dispatcherReader = Doctrine.FromXML(ref xmlNode_, waypoint);
						break;
					case "WeaponeeringList_LeadElementWingman":
						waypoint.WeaponeeringList_LeadElementWingman = new List<Mission.WeaponeeringEntry>();
						try
						{
							enumerator5 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator5.MoveNext())
							{
								XmlNode xmlNode_11 = (XmlNode)enumerator5.Current;
								Mission.WeaponeeringEntry item4 = Mission.WeaponeeringEntry.FromXML(ref xmlNode_11, ref scenario_0, ref concurrentDictionary_0);
								waypoint.WeaponeeringList_LeadElementWingman.Add(item4);
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
					case "TimeOfDay":
						if (Operators.CompareString(xmlNode_.InnerText, "", TextCompare: false) == 0)
						{
							waypoint.TimeOfDay = Weather.TTimeOfDayType.tod_Day;
						}
						else
						{
							waypoint.TimeOfDay = (Weather.TTimeOfDayType)Conversions.ToByte(xmlNode_.InnerText);
						}
						break;
					case "ECMActive":
						flag = true;
						flag2 = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Hold_Time":
						waypoint.Hold_Time = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode_.InnerText))
						{
							waypoint.ObjectID_Set(xmlNode_.InnerText);
							concurrentDictionary_0.TryAdd(waypoint.ObjectID, waypoint);
							break;
						}
						return (Waypoint)concurrentDictionary_0[xmlNode_.InnerText];
					case "PreferredWeaponName":
						waypoint.PreferredWeaponName = xmlNode_.InnerText;
						break;
					case "Description":
						waypoint.Description = xmlNode_.InnerText;
						break;
					case "Leg_FuelRemaining_SecondElementWingman":
						waypoint.Leg_FuelRemaining_SecondElementWingman = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Leg_FuelRemaining_SecondElement":
						waypoint.Leg_FuelRemaining_SecondElement = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Leg_Time_ErrorMargin":
						waypoint.Leg_Time_ErrorMargin = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "WeaponeeringList_ThirdElement":
						waypoint.WeaponeeringList_ThirdElement = new List<Mission.WeaponeeringEntry>();
						try
						{
							enumerator8 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator8.MoveNext())
							{
								XmlNode xmlNode_10 = (XmlNode)enumerator8.Current;
								Mission.WeaponeeringEntry item3 = Mission.WeaponeeringEntry.FromXML(ref xmlNode_10, ref scenario_0, ref concurrentDictionary_0);
								waypoint.WeaponeeringList_ThirdElement.Add(item3);
							}
						}
						finally
						{
							if (enumerator8 is IDisposable)
							{
								(enumerator8 as IDisposable).Dispose();
							}
						}
						break;
					case "RadarActive":
						flag = true;
						flag3 = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Leg_TotalDistance_LeadElementWingman":
						waypoint.Leg_TotalDistance_LeadElementWingman = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Leg_TotalTime":
						waypoint.Leg_TotalTime = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "SpeedAdjustmentToT":
						waypoint.SpeedAdjustmentToT = (SpeedToT)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "DepthPreset":
						waypoint.DepthPreset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TargeteeringList_LeadElementWingman":
						waypoint.TargeteeringList_LeadElementWingman = new List<Mission.TargeteeringEntry>();
						try
						{
							enumerator20 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator20.MoveNext())
							{
								XmlNode xmlNode_9 = (XmlNode)enumerator20.Current;
								Mission.TargeteeringEntry item2 = Mission.TargeteeringEntry.FromXML(ref xmlNode_9);
								waypoint.TargeteeringList_LeadElementWingman.Add(item2);
							}
						}
						finally
						{
							if (enumerator20 is IDisposable)
							{
								(enumerator20 as IDisposable).Dispose();
							}
						}
						break;
					case "Altitude":
					case "Alt":
						waypoint.Altitude = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "DesiredAltitude":
						if (Operators.CompareString(xmlNode_.InnerText, false.ToString(), TextCompare: false) == 0)
						{
							waypoint.DesiredAltitude = null;
						}
						else
						{
							waypoint.DesiredAltitude = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						}
						break;
					case "SpacingManeuver_Time":
						waypoint.SpacingManeuver_Time = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Time_Zulu":
					{
						DateTime value4 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						waypoint.Time_Zulu = value4;
						break;
					}
					case "TargeteeringList_SecondElementWingman":
						waypoint.TargeteeringList_SecondElementWingman = new List<Mission.TargeteeringEntry>();
						try
						{
							enumerator22 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator22.MoveNext())
							{
								XmlNode xmlNode_7 = (XmlNode)enumerator22.Current;
								Mission.TargeteeringEntry item11 = Mission.TargeteeringEntry.FromXML(ref xmlNode_7);
								waypoint.TargeteeringList_SecondElementWingman.Add(item11);
							}
						}
						finally
						{
							if (enumerator22 is IDisposable)
							{
								(enumerator22 as IDisposable).Dispose();
							}
						}
						break;
					case "TankerMissionList":
						try
						{
							enumerator18 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator18.MoveNext())
							{
								XmlNode xmlNode3 = (XmlNode)enumerator18.Current;
								waypoint.TankerMissions_IDs.Add(xmlNode3.InnerText);
							}
						}
						finally
						{
							if (enumerator18 is IDisposable)
							{
								(enumerator18 as IDisposable).Dispose();
							}
						}
						break;
					case "TargeteeringList_ThirdElementWingman":
						waypoint.TargeteeringList_ThirdElementWingman = new List<Mission.TargeteeringEntry>();
						try
						{
							enumerator3 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode_6 = (XmlNode)enumerator3.Current;
								Mission.TargeteeringEntry item10 = Mission.TargeteeringEntry.FromXML(ref xmlNode_6);
								waypoint.TargeteeringList_ThirdElementWingman.Add(item10);
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
					case "TerrainFollowing":
						waypoint.TerrainFollowing = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Leg_FuelRequired":
						waypoint.Leg_FuelRequired = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Leg_TotalDistance":
						waypoint.Leg_TotalDistance = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Time_Zulu_Weapon":
					{
						DateTime value3 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						waypoint.Time_Zulu_Weapon = value3;
						break;
					}
					case "Leg_FuelRemaining_LeadElementWingman":
						waypoint.Leg_FuelRemaining_LeadElementWingman = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Lon":
						waypoint.Longitude = XmlConvert.ToDouble(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "AltitudePreset":
						waypoint.AltitudePreset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "SpeedFixed":
						waypoint.SpeedFixed = (FixedFree)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "DesiredAltitude_TerrainFollowing":
						if (Operators.CompareString(xmlNode_.InnerText, false.ToString(), TextCompare: false) == 0)
						{
							waypoint.DesiredAltitude_TerrainFollowing = null;
						}
						else
						{
							waypoint.DesiredAltitude_TerrainFollowing = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						}
						break;
					case "Time_Local_Weapon":
					{
						DateTime value2 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						waypoint.Time_Local_Weapon = value2;
						break;
					}
					case "TargeteeringList_SecondElement":
						waypoint.TargeteeringList_SecondElement = new List<Mission.TargeteeringEntry>();
						try
						{
							enumerator21 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator21.MoveNext())
							{
								XmlNode xmlNode_4 = (XmlNode)enumerator21.Current;
								Mission.TargeteeringEntry item9 = Mission.TargeteeringEntry.FromXML(ref xmlNode_4);
								waypoint.TargeteeringList_SecondElement.Add(item9);
							}
						}
						finally
						{
							if (enumerator21 is IDisposable)
							{
								(enumerator21 as IDisposable).Dispose();
							}
						}
						break;
					case "DesiredSpeed":
						if (Operators.CompareString(xmlNode_.InnerText, false.ToString(), TextCompare: false) == 0)
						{
							waypoint.DesiredSpeed = null;
						}
						else
						{
							waypoint.DesiredSpeed = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						}
						break;
					case "Lat":
						waypoint.Latitude = XmlConvert.ToDouble(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Leg_FuelRemaining_ThirdElement":
						waypoint.Leg_FuelRemaining_ThirdElement = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Category":
						waypoint.Category = (WaypointCategory)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "PreferredWeaponID":
						waypoint.PreferredWeaponID = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "DAO":
					case "DesiredAltitudeOverride":
						waypoint.m_ParameterReader = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TankerFollowsReceivers_NumberOfWaypoints":
						waypoint.TankerFollowsReceivers_NumberOfWaypoints = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "AvoidCavitation":
						waypoint.AvoidCavitation = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "PreferredWeaponSpeed":
						waypoint.PreferredWeaponSpeed = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Leg_Time_Weapon":
						waypoint.Leg_Time_Weapon = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Leg_FuelRemaining_ThirdElementWingman":
						waypoint.Leg_FuelRemaining_ThirdElementWingman = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "TargeteeringMethod":
						waypoint.TargeteeringMethod = (Mission._TargeteeringMethod)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "WeaponeeringList_ThirdElementWingman":
						waypoint.WeaponeeringList_ThirdElementWingman = new List<Mission.WeaponeeringEntry>();
						try
						{
							enumerator9 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator9.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator9.Current;
								Mission.WeaponeeringEntry item8 = Mission.WeaponeeringEntry.FromXML(ref xmlNode_2, ref scenario_0, ref concurrentDictionary_0);
								waypoint.WeaponeeringList_ThirdElementWingman.Add(item8);
							}
						}
						finally
						{
							if (enumerator9 is IDisposable)
							{
								(enumerator9 as IDisposable).Dispose();
							}
						}
						break;
					case "SprintDrift":
						waypoint.SprintDrift = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "WP_LeadElementWingman":
						try
						{
							enumerator10 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator10.MoveNext())
							{
								XmlNode xmlNode_19 = (XmlNode)enumerator10.Current;
								waypoint.Waypoint_LeadElementWingman = FromXML(ref xmlNode_19, ref concurrentDictionary_0, scenario_0);
							}
						}
						finally
						{
							if (enumerator10 is IDisposable)
							{
								(enumerator10 as IDisposable).Dispose();
							}
						}
						break;
					case "IsManualEditable":
					case "IME":
						waypoint.IsManualEditable = true;
						break;
					case "WeaponeeringList_SecondElementWingman":
						waypoint.WeaponeeringList_SecondElementWingman = new List<Mission.WeaponeeringEntry>();
						try
						{
							enumerator7 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator7.MoveNext())
							{
								XmlNode xmlNode_18 = (XmlNode)enumerator7.Current;
								Mission.WeaponeeringEntry item7 = Mission.WeaponeeringEntry.FromXML(ref xmlNode_18, ref scenario_0, ref concurrentDictionary_0);
								waypoint.WeaponeeringList_SecondElementWingman.Add(item7);
							}
						}
						finally
						{
							if (enumerator7 is IDisposable)
							{
								(enumerator7 as IDisposable).Dispose();
							}
						}
						break;
					case "Leg_Time_Turn":
						waypoint.Leg_Time_Turn = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Type":
						if (Versioned.IsNumeric(xmlNode_.InnerText))
						{
							waypoint.Type = (WaypointType)Conversions.ToInteger(xmlNode_.InnerText);
						}
						else
						{
							waypoint.Type = (WaypointType)Enum.Parse(typeof(WaypointType), xmlNode_.InnerText, ignoreCase: true);
						}
						if (waypoint.Type == WaypointType.Split)
						{
							waypoint.Type = WaypointType.StrikeIngress;
						}
						else if (waypoint.Type == WaypointType.Formate)
						{
							waypoint.Type = WaypointType.StrikeEgress;
						}
						break;
					case "Leg_TotalDistance_ThirdElementWingman":
						waypoint.Leg_TotalDistance_ThirdElementWingman = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "TankerUsage":
						waypoint.TankerUsage = (Mission.TankerMethod)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "FlightFormation":
						waypoint.FlightFormation = (Formation)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "WP_SecondElementWingman":
						try
						{
							enumerator13 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator13.MoveNext())
							{
								XmlNode xmlNode_17 = (XmlNode)enumerator13.Current;
								waypoint.Waypoint_SecondElementWingman = FromXML(ref xmlNode_17, ref concurrentDictionary_0, scenario_0);
							}
						}
						finally
						{
							if (enumerator13 is IDisposable)
							{
								(enumerator13 as IDisposable).Dispose();
							}
						}
						break;
					case "TankerFollowsReceivers":
						waypoint.TankerFollowsReceivers = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "WP_SecondElement":
						try
						{
							enumerator11 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator11.MoveNext())
							{
								XmlNode xmlNode_16 = (XmlNode)enumerator11.Current;
								waypoint.Waypoint_SecondElement = FromXML(ref xmlNode_16, ref concurrentDictionary_0, scenario_0);
							}
						}
						finally
						{
							if (enumerator11 is IDisposable)
							{
								(enumerator11 as IDisposable).Dispose();
							}
						}
						break;
					case "WeaponeeringList_SecondElement":
						waypoint.WeaponeeringList_SecondElement = new List<Mission.WeaponeeringEntry>();
						try
						{
							enumerator6 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator6.MoveNext())
							{
								XmlNode xmlNode_15 = (XmlNode)enumerator6.Current;
								Mission.WeaponeeringEntry item6 = Mission.WeaponeeringEntry.FromXML(ref xmlNode_15, ref scenario_0, ref concurrentDictionary_0);
								waypoint.WeaponeeringList_SecondElement.Add(item6);
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
					case "PreferredWeaponAltitude":
						waypoint.PreferredWeaponAltitude = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "ThrottlePreset":
						waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "WeaponeeringList":
						waypoint.WeaponeeringList = new List<Mission.WeaponeeringEntry>();
						try
						{
							enumerator4 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								XmlNode xmlNode_14 = (XmlNode)enumerator4.Current;
								Mission.WeaponeeringEntry item5 = Mission.WeaponeeringEntry.FromXML(ref xmlNode_14, ref scenario_0, ref concurrentDictionary_0);
								waypoint.WeaponeeringList.Add(item5);
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
					case "Leg_TotalDistance_ThirdElement":
						waypoint.Leg_TotalDistance_ThirdElement = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Leg_Distance":
						waypoint.Leg_Distance_Straight = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "TFT":
						waypoint.TerrainFollowingType = (ActiveUnit.TerrainFollowMode)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "MaxReceiversInQueuePerTanker_Airborne":
						waypoint.MaxReceiversInQueuePerTanker_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "WP_ThirdElementWingman":
						try
						{
							enumerator15 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator15.MoveNext())
							{
								XmlNode xmlNode_13 = (XmlNode)enumerator15.Current;
								waypoint.Waypoint_ThirdElementWingman = FromXML(ref xmlNode_13, ref concurrentDictionary_0, scenario_0);
							}
						}
						finally
						{
							if (enumerator15 is IDisposable)
							{
								(enumerator15 as IDisposable).Dispose();
							}
						}
						break;
					case "Leg_Time_Straight":
						waypoint.Leg_Time_Straight = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "AttackMethod":
						waypoint.AttackMethod = (Mission._AttackMethod)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TargeteeringList_ThirdElement":
						waypoint.TargeteeringList_ThirdElement = new List<Mission.TargeteeringEntry>();
						try
						{
							enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_12 = (XmlNode)enumerator2.Current;
								Mission.TargeteeringEntry item = Mission.TargeteeringEntry.FromXML(ref xmlNode_12);
								waypoint.TargeteeringList_ThirdElement.Add(item);
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
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			if (waypoint.TerrainFollowing && Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
			{
				waypoint.DesiredAltitude_TerrainFollowing = 60.96f;
			}
			if (flag && waypoint.HasDoctrine)
			{
				Doctrine doctrine = waypoint.Doctrine;
				if (!Information.IsNothing(doctrine))
				{
					if (flag3)
					{
						doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Active, scenario_0);
					}
					else
					{
						doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Passive, scenario_0);
					}
					if (flag4)
					{
						doctrine.SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Active, scenario_0);
					}
					else
					{
						doctrine.SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Passive, scenario_0);
					}
					if (flag2)
					{
						doctrine.SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Active, scenario_0);
					}
					else
					{
						doctrine.SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Passive, scenario_0);
					}
				}
			}
			return waypoint;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100588", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Waypoint result = new Waypoint();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Waypoint()
	{
		decoratorReader = ActiveUnit_Kinematics.UnitThrottlePreset.None;
		_ProcessReader = ActiveUnit_AI.AircraftAltitudePreset.None;
		_ThreadReader = ActiveUnit_AI.SubmarineDepthPreset.None;
		TerrainFollowingType = ActiveUnit.TerrainFollowMode.IgnoreLandCover;
		OvershootWaypoint = true;
		Hold_Time = 0f;
		Station_Time = 0f;
		SpacingManeuver_Time = 0f;
		Separation_Time = 0f;
		AttackMethod = Mission._AttackMethod.None;
		TankerMissions_IDs = new List<string>();
		TankerMissions = new List<Mission>();
		MaxReceiversInQueuePerTanker_Airborne = 0;
		TankerMaxDistance_Airborne = int.MaxValue;
		TankerFollowsReceivers = true;
		TankerFollowsReceivers_NumberOfWaypoints = 0;
		IsWaypoint = true;
	}

	public Waypoint(double double_0, double double_1, float float_0, WaypointType waypointType_0, WaypointCreator waypointCreator_0, WaypointCategory waypointCategory_0, bool bool_0 = true)
	{
		decoratorReader = ActiveUnit_Kinematics.UnitThrottlePreset.None;
		_ProcessReader = ActiveUnit_AI.AircraftAltitudePreset.None;
		_ThreadReader = ActiveUnit_AI.SubmarineDepthPreset.None;
		TerrainFollowingType = ActiveUnit.TerrainFollowMode.IgnoreLandCover;
		OvershootWaypoint = true;
		Hold_Time = 0f;
		Station_Time = 0f;
		SpacingManeuver_Time = 0f;
		Separation_Time = 0f;
		AttackMethod = Mission._AttackMethod.None;
		TankerMissions_IDs = new List<string>();
		TankerMissions = new List<Mission>();
		MaxReceiversInQueuePerTanker_Airborne = 0;
		TankerMaxDistance_Airborne = int.MaxValue;
		TankerFollowsReceivers = true;
		TankerFollowsReceivers_NumberOfWaypoints = 0;
		IsWaypoint = true;
		base.Longitude = double_0;
		base.Latitude = double_1;
		base.Altitude = float_0;
		Type = waypointType_0;
		Creator = waypointCreator_0;
		Category = waypointCategory_0;
		OvershootWaypoint = bool_0;
	}

	public static Waypoint CopyWaypoint(ref Scenario scenario_0, ref Waypoint waypoint_0, bool bool_0, bool bool_1, ref Doctrine doctrine_0)
	{
		return new Waypoint(ref scenario_0, waypoint_0.Type, waypoint_0.Category, waypoint_0.Description, waypoint_0.Doctrine, waypoint_0.IsManualEditable, waypoint_0.decoratorReader, waypoint_0._ProcessReader, waypoint_0._ThreadReader, waypoint_0.DesiredSpeed, waypoint_0.DesiredAltitude, waypoint_0.m_ObjectReader, waypoint_0.m_ParameterReader, waypoint_0.SprintDrift, waypoint_0.SprintDrift_AverageSpeed, waypoint_0.AvoidCavitation, waypoint_0.Name, waypoint_0.Longitude, waypoint_0.Latitude, waypoint_0.Altitude, waypoint_0.Creator, waypoint_0.TerrainFollowing, waypoint_0.DesiredAltitude_TerrainFollowing, waypoint_0.Time_Zulu, waypoint_0.Time_Zulu_Weapon, waypoint_0.Time_Local, waypoint_0.Time_Local_Weapon, waypoint_0.TimeOfDay, waypoint_0.TimeFixed, waypoint_0.SpeedFixed, waypoint_0.FlightFormation, waypoint_0.SpeedAdjustmentToT, waypoint_0.TankerUsage, waypoint_0.TankerMissions_IDs, waypoint_0.TankerMissions, waypoint_0.MaxReceiversInQueuePerTanker_Airborne, waypoint_0.TankerMaxDistance_Airborne, waypoint_0.TankerFollowsReceivers, waypoint_0.TankerFollowsReceivers_NumberOfWaypoints, waypoint_0.Leg_FuelRequired, waypoint_0.Leg_FuelRemaining, waypoint_0.Leg_Time_Straight, waypoint_0.Leg_Time_Turn, waypoint_0.Leg_Time_Weapon, waypoint_0.Leg_TotalTime, waypoint_0.Leg_Time_ErrorMargin, waypoint_0.Leg_Distance_Straight, waypoint_0.Leg_TotalDistance, waypoint_0.Hold_Time, waypoint_0.Station_Time, waypoint_0.SpacingManeuver_Time, waypoint_0.Leg_Distance_Turn, waypoint_0.Leg_Speed_Straight, waypoint_0.Leg_Speed_Turn, waypoint_0.Leg_PreviousWaypointIsFixedSpeed, waypoint_0.Leg_TwoWaypointsAgoIsFixedSpeed, waypoint_0.TurnRate_Navigation, waypoint_0.FlightplanPointsList, waypoint_0.ActualSpeed, bool_0, waypoint_0.Waypoint_LeadElementWingman, waypoint_0.Waypoint_SecondElement, waypoint_0.Waypoint_SecondElementWingman, waypoint_0.Waypoint_ThirdElement, waypoint_0.Waypoint_ThirdElementWingman, waypoint_0.Leg_FuelRemaining_LeadElementWingman, waypoint_0.Leg_FuelRemaining_SecondElement, waypoint_0.Leg_FuelRemaining_SecondElementWingman, waypoint_0.Leg_FuelRemaining_ThirdElement, waypoint_0.Leg_FuelRemaining_ThirdElementWingman, waypoint_0.Leg_TotalDistance_LeadElementWingman, waypoint_0.Leg_TotalDistance_SecondElement, waypoint_0.Leg_TotalDistance_SecondElementWingman, waypoint_0.Leg_TotalDistance_ThirdElement, waypoint_0.Leg_TotalDistance_ThirdElementWingman, waypoint_0.PreferredWeaponID, waypoint_0.PreferredWeaponName, waypoint_0.PreferredWeaponSpeed, waypoint_0.PreferredWeaponAltitude, waypoint_0.PreferredWeaponRange, ref waypoint_0.RaceTrackHelperPoint, bool_1, ref doctrine_0, waypoint_0.AttackMethod, waypoint_0.Separation_Time, waypoint_0.TargeteeringMethod, waypoint_0.TargeteeringList, waypoint_0.TargeteeringList_LeadElementWingman, waypoint_0.TargeteeringList_SecondElement, waypoint_0.TargeteeringList_SecondElementWingman, waypoint_0.TargeteeringList_ThirdElement, waypoint_0.TargeteeringList_ThirdElementWingman, waypoint_0.WeaponeeringList, waypoint_0.WeaponeeringList_LeadElementWingman, waypoint_0.WeaponeeringList_SecondElement, waypoint_0.WeaponeeringList_SecondElementWingman, waypoint_0.WeaponeeringList_ThirdElement, waypoint_0.WeaponeeringList_ThirdElementWingman, waypoint_0.ReferenceWeapon_ID);
	}

	public void SplitWaypoint(ref Scenario scenario_0, ref Mission._FlightSize _FlightSize_0, ref Waypoint waypoint_0, ref Waypoint waypoint_1, bool bool_0)
	{
		try
		{
			if (Information.IsNothing(waypoint_0) || Information.IsNothing(waypoint_1))
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			Mission._FlightSize flightSize = _FlightSize_0;
			if (flightSize == 2)
			{
				if (bool_0 || Information.IsNothing(Waypoint_LeadElementWingman))
				{
					Waypoint_LeadElementWingman = new Waypoint();
					Waypoint waypoint_5 = this;
					Doctrine doctrine_ = Doctrine;
					Waypoint_LeadElementWingman = CopyWaypoint(ref scenario_0, ref waypoint_5, bool_0: false, bool_1: false, ref doctrine_);
					Waypoint_LeadElementWingman.SpeedFixed = FixedFree.Free;
					Waypoint_LeadElementWingman.TimeFixed = FixedFree.Free;
					flag = true;
				}
				Waypoint_SecondElement = null;
				Waypoint_SecondElementWingman = null;
				Waypoint_ThirdElement = null;
				Waypoint_ThirdElementWingman = null;
			}
			else if (flightSize == 3)
			{
				if (bool_0 || Information.IsNothing(Waypoint_LeadElementWingman))
				{
					Waypoint_LeadElementWingman = new Waypoint();
					Waypoint waypoint_6 = this;
					Doctrine doctrine_9 = Doctrine;
					Waypoint_LeadElementWingman = CopyWaypoint(ref scenario_0, ref waypoint_6, bool_0: false, bool_1: false, ref doctrine_9);
					Waypoint_LeadElementWingman.SpeedFixed = FixedFree.Free;
					Waypoint_LeadElementWingman.TimeFixed = FixedFree.Free;
					flag = true;
				}
				if (bool_0 || Information.IsNothing(Waypoint_SecondElement))
				{
					Waypoint_SecondElement = new Waypoint();
					Waypoint waypoint_7 = this;
					Doctrine doctrine_10 = Doctrine;
					Waypoint_SecondElement = CopyWaypoint(ref scenario_0, ref waypoint_7, bool_0: false, bool_1: false, ref doctrine_10);
					Waypoint_SecondElement.SpeedFixed = FixedFree.Free;
					Waypoint_SecondElement.TimeFixed = FixedFree.Free;
					flag2 = true;
				}
				Waypoint_SecondElementWingman = null;
				Waypoint_ThirdElement = null;
				Waypoint_ThirdElementWingman = null;
			}
			else if (flightSize == 4)
			{
				if (bool_0 || Information.IsNothing(Waypoint_LeadElementWingman))
				{
					Waypoint_LeadElementWingman = new Waypoint();
					Waypoint waypoint_8 = this;
					Doctrine doctrine_11 = Doctrine;
					Waypoint_LeadElementWingman = CopyWaypoint(ref scenario_0, ref waypoint_8, bool_0: false, bool_1: false, ref doctrine_11);
					Waypoint_LeadElementWingman.SpeedFixed = FixedFree.Free;
					Waypoint_LeadElementWingman.TimeFixed = FixedFree.Free;
					flag = true;
				}
				if (bool_0 || Information.IsNothing(Waypoint_SecondElement))
				{
					Waypoint_SecondElement = new Waypoint();
					Waypoint waypoint_9 = this;
					Doctrine doctrine_12 = Doctrine;
					Waypoint_SecondElement = CopyWaypoint(ref scenario_0, ref waypoint_9, bool_0: false, bool_1: false, ref doctrine_12);
					Waypoint_SecondElement.SpeedFixed = FixedFree.Free;
					Waypoint_SecondElement.TimeFixed = FixedFree.Free;
					flag2 = true;
				}
				if (bool_0 || Information.IsNothing(Waypoint_SecondElementWingman))
				{
					Waypoint_SecondElementWingman = new Waypoint();
					Waypoint waypoint_10 = this;
					Doctrine doctrine_13 = Doctrine;
					Waypoint_SecondElementWingman = CopyWaypoint(ref scenario_0, ref waypoint_10, bool_0: false, bool_1: false, ref doctrine_13);
					Waypoint_SecondElementWingman.SpeedFixed = FixedFree.Free;
					Waypoint_SecondElementWingman.TimeFixed = FixedFree.Free;
					flag3 = true;
				}
				Waypoint_ThirdElement = null;
				Waypoint_ThirdElementWingman = null;
			}
			else if (flightSize == 6)
			{
				if (bool_0 || Information.IsNothing(Waypoint_LeadElementWingman))
				{
					Waypoint_LeadElementWingman = new Waypoint();
					Waypoint waypoint_11 = this;
					Doctrine doctrine_14 = Doctrine;
					Waypoint_LeadElementWingman = CopyWaypoint(ref scenario_0, ref waypoint_11, bool_0: false, bool_1: false, ref doctrine_14);
					Waypoint_LeadElementWingman.SpeedFixed = FixedFree.Free;
					Waypoint_LeadElementWingman.TimeFixed = FixedFree.Free;
					flag = true;
				}
				if (bool_0 || Information.IsNothing(Waypoint_SecondElement))
				{
					Waypoint_SecondElement = new Waypoint();
					Waypoint waypoint_12 = this;
					Doctrine doctrine_15 = Doctrine;
					Waypoint_SecondElement = CopyWaypoint(ref scenario_0, ref waypoint_12, bool_0: false, bool_1: false, ref doctrine_15);
					Waypoint_SecondElement.SpeedFixed = FixedFree.Free;
					Waypoint_SecondElement.TimeFixed = FixedFree.Free;
					flag2 = true;
				}
				if (bool_0 || Information.IsNothing(Waypoint_SecondElementWingman))
				{
					Waypoint_SecondElementWingman = new Waypoint();
					Waypoint waypoint_2 = this;
					Doctrine doctrine_16 = Doctrine;
					Waypoint_SecondElementWingman = CopyWaypoint(ref scenario_0, ref waypoint_2, bool_0: false, bool_1: false, ref doctrine_16);
					Waypoint_SecondElementWingman.SpeedFixed = FixedFree.Free;
					Waypoint_SecondElementWingman.TimeFixed = FixedFree.Free;
					flag3 = true;
				}
				if (bool_0 || Information.IsNothing(Waypoint_ThirdElement))
				{
					Waypoint_ThirdElement = new Waypoint();
					Waypoint waypoint_3 = this;
					Doctrine doctrine_2 = Doctrine;
					Waypoint_ThirdElement = CopyWaypoint(ref scenario_0, ref waypoint_3, bool_0: false, bool_1: false, ref doctrine_2);
					Waypoint_ThirdElement.SpeedFixed = FixedFree.Free;
					Waypoint_ThirdElement.TimeFixed = FixedFree.Free;
					flag4 = true;
				}
				if (bool_0 || Information.IsNothing(Waypoint_ThirdElementWingman))
				{
					Waypoint_ThirdElementWingman = new Waypoint();
					Waypoint waypoint_4 = this;
					Doctrine doctrine_3 = Doctrine;
					Waypoint_ThirdElementWingman = CopyWaypoint(ref scenario_0, ref waypoint_4, bool_0: false, bool_1: false, ref doctrine_3);
					Waypoint_ThirdElementWingman.SpeedFixed = FixedFree.Free;
					Waypoint_ThirdElementWingman.TimeFixed = FixedFree.Free;
					flag5 = true;
				}
			}
			if (waypoint_1.FlightFormation != Formation.Split)
			{
				if (!Information.IsNothing(Waypoint_LeadElementWingman) && Information.IsNothing(waypoint_1.Waypoint_LeadElementWingman))
				{
					waypoint_1.Waypoint_LeadElementWingman = new Waypoint();
					Waypoint obj = waypoint_1;
					Doctrine doctrine_4 = Doctrine;
					obj.Waypoint_LeadElementWingman = CopyWaypoint(ref scenario_0, ref waypoint_1, bool_0: false, bool_1: false, ref doctrine_4);
					waypoint_1.Waypoint_LeadElementWingman.SpeedFixed = FixedFree.Free;
				}
				if (!Information.IsNothing(Waypoint_SecondElement) && Information.IsNothing(waypoint_1.Waypoint_SecondElement))
				{
					waypoint_1.Waypoint_SecondElement = new Waypoint();
					Waypoint obj2 = waypoint_1;
					Doctrine doctrine_5 = Doctrine;
					obj2.Waypoint_SecondElement = CopyWaypoint(ref scenario_0, ref waypoint_1, bool_0: false, bool_1: false, ref doctrine_5);
					waypoint_1.Waypoint_SecondElement.SpeedFixed = FixedFree.Free;
				}
				if (!Information.IsNothing(Waypoint_SecondElementWingman) && Information.IsNothing(waypoint_1.Waypoint_SecondElementWingman))
				{
					waypoint_1.Waypoint_SecondElementWingman = new Waypoint();
					Waypoint obj3 = waypoint_1;
					Doctrine doctrine_6 = Doctrine;
					obj3.Waypoint_SecondElementWingman = CopyWaypoint(ref scenario_0, ref waypoint_1, bool_0: false, bool_1: false, ref doctrine_6);
					waypoint_1.Waypoint_SecondElementWingman.SpeedFixed = FixedFree.Free;
				}
				if (!Information.IsNothing(Waypoint_ThirdElement) && Information.IsNothing(waypoint_1.Waypoint_ThirdElement))
				{
					waypoint_1.Waypoint_ThirdElement = new Waypoint();
					Waypoint obj4 = waypoint_1;
					Doctrine doctrine_7 = Doctrine;
					obj4.Waypoint_ThirdElement = CopyWaypoint(ref scenario_0, ref waypoint_1, bool_0: false, bool_1: false, ref doctrine_7);
					waypoint_1.Waypoint_ThirdElement.SpeedFixed = FixedFree.Free;
				}
				if (!Information.IsNothing(Waypoint_ThirdElementWingman) && Information.IsNothing(waypoint_1.Waypoint_ThirdElementWingman))
				{
					waypoint_1.Waypoint_ThirdElementWingman = new Waypoint();
					Waypoint obj5 = waypoint_1;
					Doctrine doctrine_8 = Doctrine;
					obj5.Waypoint_ThirdElementWingman = CopyWaypoint(ref scenario_0, ref waypoint_1, bool_0: false, bool_1: false, ref doctrine_8);
					waypoint_1.Waypoint_ThirdElementWingman.SpeedFixed = FixedFree.Free;
				}
			}
			float num = Math2.PublishClass(waypoint_0.Latitude, waypoint_0.Longitude, base.Latitude, base.Longitude);
			if (Type != WaypointType.Target && Type != WaypointType.WeaponTarget)
			{
				if (flag && !Information.IsNothing(Waypoint_LeadElementWingman))
				{
					float float_ = Math2.UpdateClass(num + 90f);
					float float_3 = 3f;
					double longitude = base.Longitude;
					double latitude = base.Latitude;
					Waypoint waypoint_LeadElementWingman = Waypoint_LeadElementWingman;
					double double_ = waypoint_LeadElementWingman.Longitude;
					Waypoint waypoint_LeadElementWingman2 = Waypoint_LeadElementWingman;
					double double_3 = waypoint_LeadElementWingman2.Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_, ref double_3, float_3, float_);
					waypoint_LeadElementWingman2.Latitude = double_3;
					waypoint_LeadElementWingman.Longitude = double_;
				}
				if (flag2 && !Information.IsNothing(Waypoint_SecondElement))
				{
					float float_4 = Math2.UpdateClass(num + 90f);
					float float_5 = 6f;
					double longitude2 = base.Longitude;
					double latitude2 = base.Latitude;
					Waypoint waypoint_SecondElement = Waypoint_SecondElement;
					double double_4 = waypoint_SecondElement.Longitude;
					Waypoint waypoint_SecondElement2 = Waypoint_SecondElement;
					double double_5 = waypoint_SecondElement2.Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude2, latitude2, ref double_4, ref double_5, float_5, float_4);
					waypoint_SecondElement2.Latitude = double_5;
					waypoint_SecondElement.Longitude = double_4;
				}
				if (flag3 && !Information.IsNothing(Waypoint_SecondElementWingman))
				{
					float float_6 = Math2.UpdateClass(num + 90f);
					float float_7 = 9f;
					double longitude3 = base.Longitude;
					double latitude3 = base.Latitude;
					Waypoint waypoint_SecondElementWingman = Waypoint_SecondElementWingman;
					double double_6 = waypoint_SecondElementWingman.Longitude;
					Waypoint waypoint_SecondElementWingman2 = Waypoint_SecondElementWingman;
					double double_7 = waypoint_SecondElementWingman2.Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude3, latitude3, ref double_6, ref double_7, float_7, float_6);
					waypoint_SecondElementWingman2.Latitude = double_7;
					waypoint_SecondElementWingman.Longitude = double_6;
				}
				if (flag4 && !Information.IsNothing(Waypoint_ThirdElement))
				{
					float float_8 = Math2.UpdateClass(num + 90f);
					float float_9 = 12f;
					double longitude4 = base.Longitude;
					double latitude4 = base.Latitude;
					Waypoint waypoint_ThirdElement = Waypoint_ThirdElement;
					double double_8 = waypoint_ThirdElement.Longitude;
					Waypoint waypoint_ThirdElement2 = Waypoint_ThirdElement;
					double double_9 = waypoint_ThirdElement2.Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude4, latitude4, ref double_8, ref double_9, float_9, float_8);
					waypoint_ThirdElement2.Latitude = double_9;
					waypoint_ThirdElement.Longitude = double_8;
				}
				if (flag5 && !Information.IsNothing(Waypoint_ThirdElementWingman))
				{
					float float_10 = Math2.UpdateClass(num + 90f);
					float float_2 = 15f;
					double longitude5 = base.Longitude;
					double latitude5 = base.Latitude;
					Waypoint waypoint_ThirdElementWingman = Waypoint_ThirdElementWingman;
					double double_10 = waypoint_ThirdElementWingman.Longitude;
					Waypoint waypoint_ThirdElementWingman2 = Waypoint_ThirdElementWingman;
					double double_2 = waypoint_ThirdElementWingman2.Latitude;
					Geodesic_EdWilliams.CalcPoint_Williams(longitude5, latitude5, ref double_10, ref double_2, float_2, float_10);
					waypoint_ThirdElementWingman2.Latitude = double_2;
					waypoint_ThirdElementWingman.Longitude = double_10;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool InvokeReponse()
	{
		if (Information.IsNothing(Waypoint_LeadElementWingman) && Information.IsNothing(Waypoint_SecondElement) && Information.IsNothing(Waypoint_SecondElementWingman) && Information.IsNothing(Waypoint_ThirdElement) && Information.IsNothing(Waypoint_ThirdElementWingman))
		{
			return false;
		}
		return true;
	}

	internal bool SetupReponse()
	{
		if (InvokeReponse() && FlightFormation == Formation.Split)
		{
			return true;
		}
		return false;
	}

	internal bool ExcludeReponse()
	{
		if (InvokeReponse() && FlightFormation != Formation.Split)
		{
			return true;
		}
		return false;
	}

	public void FormateWaypoint(ref Waypoint waypoint_0, ref Waypoint waypoint_1)
	{
		try
		{
			if (!Information.IsNothing(waypoint_0) && !Information.IsNothing(waypoint_1))
			{
				if (waypoint_0.SetupReponse())
				{
					if (!Information.IsNothing(Waypoint_LeadElementWingman))
					{
						Waypoint_LeadElementWingman.Latitude = base.Latitude;
						Waypoint_LeadElementWingman.Longitude = base.Longitude;
						Waypoint_LeadElementWingman.SpeedFixed = FixedFree.Free;
						Waypoint_LeadElementWingman.DesiredSpeed = DesiredSpeed;
						Waypoint_LeadElementWingman.DesiredSpeedOverride = DesiredSpeedOverride;
						Waypoint_LeadElementWingman.ThrottlePreset = ThrottlePreset;
					}
					if (!Information.IsNothing(Waypoint_SecondElement))
					{
						Waypoint_SecondElement.Latitude = base.Latitude;
						Waypoint_SecondElement.Longitude = base.Longitude;
						Waypoint_SecondElement.SpeedFixed = FixedFree.Free;
						Waypoint_SecondElement.DesiredSpeed = DesiredSpeed;
						Waypoint_SecondElement.DesiredSpeedOverride = DesiredSpeedOverride;
						Waypoint_SecondElement.ThrottlePreset = ThrottlePreset;
					}
					if (!Information.IsNothing(Waypoint_SecondElementWingman))
					{
						Waypoint_SecondElementWingman.Latitude = base.Latitude;
						Waypoint_SecondElementWingman.Longitude = base.Longitude;
						Waypoint_SecondElementWingman.SpeedFixed = FixedFree.Free;
						Waypoint_SecondElementWingman.DesiredSpeed = DesiredSpeed;
						Waypoint_SecondElementWingman.DesiredSpeedOverride = DesiredSpeedOverride;
						Waypoint_SecondElementWingman.ThrottlePreset = ThrottlePreset;
					}
					if (!Information.IsNothing(Waypoint_ThirdElement))
					{
						Waypoint_ThirdElement.Latitude = base.Latitude;
						Waypoint_ThirdElement.Longitude = base.Longitude;
						Waypoint_ThirdElement.SpeedFixed = FixedFree.Free;
						Waypoint_ThirdElement.DesiredSpeed = DesiredSpeed;
						Waypoint_ThirdElement.DesiredSpeedOverride = DesiredSpeedOverride;
						Waypoint_ThirdElement.ThrottlePreset = ThrottlePreset;
					}
					if (!Information.IsNothing(Waypoint_ThirdElementWingman))
					{
						Waypoint_ThirdElementWingman.Latitude = base.Latitude;
						Waypoint_ThirdElementWingman.Longitude = base.Longitude;
						Waypoint_ThirdElementWingman.SpeedFixed = FixedFree.Free;
						Waypoint_ThirdElementWingman.DesiredSpeed = DesiredSpeed;
						Waypoint_ThirdElementWingman.DesiredSpeedOverride = DesiredSpeedOverride;
						Waypoint_ThirdElementWingman.ThrottlePreset = ThrottlePreset;
					}
				}
				else
				{
					Waypoint_LeadElementWingman = null;
					Waypoint_SecondElement = null;
					Waypoint_SecondElementWingman = null;
					Waypoint_ThirdElement = null;
					Waypoint_ThirdElementWingman = null;
				}
				if (waypoint_1.ExcludeReponse())
				{
					waypoint_1.Waypoint_LeadElementWingman = null;
					waypoint_1.Waypoint_SecondElement = null;
					waypoint_1.Waypoint_SecondElementWingman = null;
					waypoint_1.Waypoint_ThirdElement = null;
					waypoint_1.Waypoint_ThirdElementWingman = null;
				}
			}
			else
			{
				Waypoint_LeadElementWingman = null;
				Waypoint_SecondElement = null;
				Waypoint_SecondElementWingman = null;
				Waypoint_ThirdElement = null;
				Waypoint_ThirdElementWingman = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Waypoint(ref Scenario scenario_0, WaypointType waypointType_0, WaypointCategory waypointCategory_0, string string_0, Doctrine doctrine_0, bool bool_0, ActiveUnit_Kinematics.UnitThrottlePreset unitThrottlePreset_0, ActiveUnit_AI.AircraftAltitudePreset aircraftAltitudePreset_0, ActiveUnit_AI.SubmarineDepthPreset submarineDepthPreset_0, float? nullable_0, float? nullable_1, float? nullable_2, bool bool_1, bool? nullable_3, float? nullable_4, bool? nullable_5, string string_1, double double_0, double double_1, float float_0, WaypointCreator waypointCreator_0, bool bool_2, float? nullable_6, DateTime? nullable_7, DateTime? nullable_8, DateTime? nullable_9, DateTime? nullable_10, Weather.TTimeOfDayType ttimeOfDayType_0, FixedFree fixedFree_0, FixedFree fixedFree_1, Formation formation_0, SpeedToT speedToT_0, Mission.TankerMethod tankerMethod_0, List<string> list_0, List<Mission> list_1, int int_0, int int_1, bool bool_3, int int_2, float float_1, float float_2, float float_3, float float_4, float float_5, float float_6, float float_7, float float_8, float float_9, float float_10, float float_11, float float_12, float float_13, float float_14, float float_15, bool bool_4, bool bool_5, TurnRateCategory turnRateCategory_0, List<FlightPlanSegment> list_2, float float_16, bool bool_6, Waypoint waypoint_0, Waypoint waypoint_1, Waypoint waypoint_2, Waypoint waypoint_3, Waypoint waypoint_4, float float_17, float float_18, float float_19, float float_20, float float_21, float float_22, float float_23, float float_24, float float_25, float float_26, int int_3, string string_2, float float_27, float float_28, float float_29, ref GeoPoint geoPoint_0, bool bool_7, ref Doctrine doctrine_1, Mission._AttackMethod _AttackMethod_0, float float_30, Mission._TargeteeringMethod _TargeteeringMethod_0, List<Mission.TargeteeringEntry> list_3, List<Mission.TargeteeringEntry> list_4, List<Mission.TargeteeringEntry> list_5, List<Mission.TargeteeringEntry> list_6, List<Mission.TargeteeringEntry> list_7, List<Mission.TargeteeringEntry> list_8, List<Mission.WeaponeeringEntry> list_9, List<Mission.WeaponeeringEntry> list_10, List<Mission.WeaponeeringEntry> list_11, List<Mission.WeaponeeringEntry> list_12, List<Mission.WeaponeeringEntry> list_13, List<Mission.WeaponeeringEntry> list_14, int int_4)
	{
		decoratorReader = ActiveUnit_Kinematics.UnitThrottlePreset.None;
		_ProcessReader = ActiveUnit_AI.AircraftAltitudePreset.None;
		_ThreadReader = ActiveUnit_AI.SubmarineDepthPreset.None;
		TerrainFollowingType = ActiveUnit.TerrainFollowMode.IgnoreLandCover;
		OvershootWaypoint = true;
		Hold_Time = 0f;
		Station_Time = 0f;
		SpacingManeuver_Time = 0f;
		Separation_Time = 0f;
		AttackMethod = Mission._AttackMethod.None;
		TankerMissions_IDs = new List<string>();
		TankerMissions = new List<Mission>();
		MaxReceiversInQueuePerTanker_Airborne = 0;
		TankerMaxDistance_Airborne = int.MaxValue;
		TankerFollowsReceivers = true;
		TankerFollowsReceivers_NumberOfWaypoints = 0;
		try
		{
			IsWaypoint = true;
			Type = waypointType_0;
			Category = waypointCategory_0;
			Description = string_0;
			IsManualEditable = bool_0;
			decoratorReader = unitThrottlePreset_0;
			_ProcessReader = aircraftAltitudePreset_0;
			_ThreadReader = submarineDepthPreset_0;
			DesiredSpeed = nullable_0;
			DesiredAltitude = nullable_1;
			DesiredAltitude_TerrainFollowing = nullable_6;
			m_ObjectReader = nullable_2;
			m_ParameterReader = bool_1;
			SprintDrift = nullable_3;
			SprintDrift_AverageSpeed = nullable_4;
			AvoidCavitation = nullable_5;
			base.Longitude = double_0;
			base.Latitude = double_1;
			base.Altitude = float_0;
			Name = string_1;
			Creator = waypointCreator_0;
			TerrainFollowing = bool_2;
			Time_Zulu = nullable_7;
			Time_Zulu_Weapon = nullable_8;
			Time_Local = nullable_9;
			Time_Local_Weapon = nullable_10;
			TimeOfDay = ttimeOfDayType_0;
			TimeFixed = fixedFree_0;
			SpeedFixed = fixedFree_1;
			FlightFormation = formation_0;
			SpeedAdjustmentToT = speedToT_0;
			TankerUsage = tankerMethod_0;
			foreach (string item6 in list_0)
			{
				TankerMissions_IDs.Add(item6);
			}
			foreach (Mission item7 in list_1)
			{
				TankerMissions.Add(item7);
			}
			MaxReceiversInQueuePerTanker_Airborne = int_0;
			TankerMaxDistance_Airborne = int_1;
			TankerFollowsReceivers = bool_3;
			TankerFollowsReceivers_NumberOfWaypoints = int_2;
			Leg_FuelRequired = float_1;
			Leg_FuelRemaining = float_2;
			Leg_Time_Straight = float_3;
			Leg_Time_Turn = float_4;
			Leg_Time_Weapon = float_5;
			Leg_TotalTime = float_6;
			Leg_Time_ErrorMargin = float_7;
			Leg_Distance_Straight = float_8;
			Leg_TotalDistance = float_9;
			Leg_Distance_Turn = float_13;
			Leg_Speed_Straight = float_14;
			Leg_Speed_Turn = float_15;
			Leg_PreviousWaypointIsFixedSpeed = bool_4;
			Leg_TwoWaypointsAgoIsFixedSpeed = bool_5;
			TurnRate_Navigation = turnRateCategory_0;
			if (bool_7 && !Information.IsNothing(list_2))
			{
				FlightplanPointsList = new List<FlightPlanSegment>();
				foreach (FlightPlanSegment item8 in list_2)
				{
					FlightPlanSegment item = new FlightPlanSegment(ref item8.StartLatitude, item8.StartLongitude, item8.EndLatitude, item8.EndLongitude);
					FlightplanPointsList.Add(item);
				}
			}
			Leg_FuelRemaining_LeadElementWingman = float_17;
			Leg_TotalDistance_LeadElementWingman = float_22;
			Leg_FuelRemaining_SecondElement = float_18;
			Leg_TotalDistance_SecondElement = float_23;
			Leg_FuelRemaining_SecondElementWingman = float_19;
			Leg_TotalDistance_SecondElementWingman = float_24;
			Leg_FuelRemaining_ThirdElement = float_20;
			Leg_TotalDistance_ThirdElement = float_25;
			Leg_FuelRemaining_ThirdElementWingman = float_21;
			Leg_TotalDistance_ThirdElementWingman = float_26;
			if (Information.IsNothing(doctrine_1))
			{
				dispatcherReader = Doctrine.PatchRepository(ref doctrine_0, this, ref scenario_0);
			}
			else
			{
				dispatcherReader = doctrine_1;
			}
			if (bool_6)
			{
				if (!Information.IsNothing(waypoint_0))
				{
					Doctrine doctrine_2 = Doctrine;
					Waypoint_LeadElementWingman = CopyWaypoint(ref scenario_0, ref waypoint_0, bool_0: false, bool_7, ref doctrine_2);
				}
				if (!Information.IsNothing(waypoint_1))
				{
					Doctrine doctrine_3 = Doctrine;
					Waypoint_SecondElement = CopyWaypoint(ref scenario_0, ref waypoint_1, bool_0: false, bool_7, ref doctrine_3);
				}
				if (!Information.IsNothing(waypoint_2))
				{
					Doctrine doctrine_4 = Doctrine;
					Waypoint_SecondElementWingman = CopyWaypoint(ref scenario_0, ref waypoint_2, bool_0: false, bool_7, ref doctrine_4);
				}
				if (!Information.IsNothing(waypoint_3))
				{
					Doctrine doctrine_5 = Doctrine;
					Waypoint_ThirdElement = CopyWaypoint(ref scenario_0, ref waypoint_3, bool_0: false, bool_7, ref doctrine_5);
				}
				if (!Information.IsNothing(waypoint_4))
				{
					Doctrine doctrine_6 = Doctrine;
					Waypoint_ThirdElementWingman = CopyWaypoint(ref scenario_0, ref waypoint_4, bool_0: false, bool_7, ref doctrine_6);
				}
			}
			Hold_Time = float_10;
			Station_Time = float_11;
			SpacingManeuver_Time = float_12;
			AttackMethod = _AttackMethod_0;
			Separation_Time = float_30;
			ActualSpeed = float_16;
			PreferredWeaponID = int_3;
			PreferredWeaponName = string_2;
			PreferredWeaponSpeed = float_27;
			PreferredWeaponAltitude = float_28;
			PreferredWeaponRange = float_29;
			if (!Information.IsNothing(geoPoint_0))
			{
				RaceTrackHelperPoint = new GeoPoint(geoPoint_0.Longitude, geoPoint_0.Latitude);
			}
			TargeteeringMethod = _TargeteeringMethod_0;
			if (!Information.IsNothing(list_3))
			{
				TargeteeringList = new List<Mission.TargeteeringEntry>();
				foreach (Mission.TargeteeringEntry item9 in list_3)
				{
					Mission.TargeteeringEntry item12 = new Mission.TargeteeringEntry(item9.ObjectID, item9.Target_Type, item9.Target_Description, item9.Target_ContactObjectID, item9.Target_ActualUnitObjectID, item9.Target_ActualUnitDBID, item9.Target_Latitude, item9.Target_Longitude, item9.Target_PreliminaryPoint, null, null);
					TargeteeringList.Add(item12);
				}
			}
			if (!Information.IsNothing(list_4))
			{
				TargeteeringList_LeadElementWingman = new List<Mission.TargeteeringEntry>();
				foreach (Mission.TargeteeringEntry item10 in list_4)
				{
					Mission.TargeteeringEntry item22 = new Mission.TargeteeringEntry(item10.ObjectID, item10.Target_Type, item10.Target_Description, item10.Target_ContactObjectID, item10.Target_ActualUnitObjectID, item10.Target_ActualUnitDBID, item10.Target_Latitude, item10.Target_Longitude, item10.Target_PreliminaryPoint, null, null);
					TargeteeringList_LeadElementWingman.Add(item22);
				}
			}
			if (!Information.IsNothing(list_5))
			{
				TargeteeringList_SecondElement = new List<Mission.TargeteeringEntry>();
				foreach (Mission.TargeteeringEntry item11 in list_5)
				{
					Mission.TargeteeringEntry item23 = new Mission.TargeteeringEntry(item11.ObjectID, item11.Target_Type, item11.Target_Description, item11.Target_ContactObjectID, item11.Target_ActualUnitObjectID, item11.Target_ActualUnitDBID, item11.Target_Latitude, item11.Target_Longitude, item11.Target_PreliminaryPoint, null, null);
					TargeteeringList_SecondElement.Add(item23);
				}
			}
			if (!Information.IsNothing(list_6))
			{
				TargeteeringList_SecondElementWingman = new List<Mission.TargeteeringEntry>();
				foreach (Mission.TargeteeringEntry item13 in list_6)
				{
					Mission.TargeteeringEntry item24 = new Mission.TargeteeringEntry(item13.ObjectID, item13.Target_Type, item13.Target_Description, item13.Target_ContactObjectID, item13.Target_ActualUnitObjectID, item13.Target_ActualUnitDBID, item13.Target_Latitude, item13.Target_Longitude, item13.Target_PreliminaryPoint, null, null);
					TargeteeringList_SecondElementWingman.Add(item24);
				}
			}
			if (!Information.IsNothing(list_7))
			{
				TargeteeringList_ThirdElement = new List<Mission.TargeteeringEntry>();
				foreach (Mission.TargeteeringEntry item14 in list_7)
				{
					Mission.TargeteeringEntry item25 = new Mission.TargeteeringEntry(item14.ObjectID, item14.Target_Type, item14.Target_Description, item14.Target_ContactObjectID, item14.Target_ActualUnitObjectID, item14.Target_ActualUnitDBID, item14.Target_Latitude, item14.Target_Longitude, item14.Target_PreliminaryPoint, null, null);
					TargeteeringList_ThirdElement.Add(item25);
				}
			}
			if (!Information.IsNothing(list_8))
			{
				TargeteeringList_ThirdElementWingman = new List<Mission.TargeteeringEntry>();
				foreach (Mission.TargeteeringEntry item15 in list_8)
				{
					Mission.TargeteeringEntry item26 = new Mission.TargeteeringEntry(item15.ObjectID, item15.Target_Type, item15.Target_Description, item15.Target_ContactObjectID, item15.Target_ActualUnitObjectID, item15.Target_ActualUnitDBID, item15.Target_Latitude, item15.Target_Longitude, item15.Target_PreliminaryPoint, null, null);
					TargeteeringList_ThirdElementWingman.Add(item26);
				}
			}
			if (!Information.IsNothing(list_9))
			{
				WeaponeeringList = new List<Mission.WeaponeeringEntry>();
				foreach (Mission.WeaponeeringEntry item16 in list_9)
				{
					int int_6 = item16.int_0;
					Weapon._WeaponType weaponType = item16.WeaponType;
					string weaponName = item16.WeaponName;
					float weaponMaxRange = item16.WeaponMaxRange;
					float weaponMinRange = item16.WeaponMinRange;
					bool bool_12 = item16.bool_0;
					string targeteeringEntryObjectID = item16.TargeteeringEntryObjectID;
					int lostTarget = item16.LostTarget;
					int weaponQty = item16.WeaponQty;
					int weaponMaxQty = item16.WeaponMaxQty;
					int firingRange = item16.FiringRange;
					Waypoint[] waypoint_6 = null;
					Mission.WeaponeeringEntry item27 = new Mission.WeaponeeringEntry(int_6, weaponType, weaponName, weaponMaxRange, weaponMinRange, bool_12, targeteeringEntryObjectID, lostTarget, weaponQty, weaponMaxQty, firingRange, ref waypoint_6);
					WeaponeeringList.Add(item27);
				}
			}
			if (!Information.IsNothing(list_10))
			{
				WeaponeeringList_LeadElementWingman = new List<Mission.WeaponeeringEntry>();
				foreach (Mission.WeaponeeringEntry item17 in list_10)
				{
					int int_7 = item17.int_0;
					Weapon._WeaponType weaponType2 = item17.WeaponType;
					string weaponName2 = item17.WeaponName;
					float weaponMaxRange2 = item17.WeaponMaxRange;
					float weaponMinRange2 = item17.WeaponMinRange;
					bool bool_13 = item17.bool_0;
					string targeteeringEntryObjectID2 = item17.TargeteeringEntryObjectID;
					int lostTarget2 = item17.LostTarget;
					int weaponQty2 = item17.WeaponQty;
					int weaponMaxQty2 = item17.WeaponMaxQty;
					int firingRange2 = item17.FiringRange;
					Waypoint[] waypoint_7 = null;
					Mission.WeaponeeringEntry item28 = new Mission.WeaponeeringEntry(int_7, weaponType2, weaponName2, weaponMaxRange2, weaponMinRange2, bool_13, targeteeringEntryObjectID2, lostTarget2, weaponQty2, weaponMaxQty2, firingRange2, ref waypoint_7);
					WeaponeeringList_LeadElementWingman.Add(item28);
				}
			}
			if (!Information.IsNothing(list_11))
			{
				WeaponeeringList_SecondElement = new List<Mission.WeaponeeringEntry>();
				foreach (Mission.WeaponeeringEntry item18 in list_11)
				{
					int int_8 = item18.int_0;
					Weapon._WeaponType weaponType3 = item18.WeaponType;
					string weaponName3 = item18.WeaponName;
					float weaponMaxRange3 = item18.WeaponMaxRange;
					float weaponMinRange3 = item18.WeaponMinRange;
					bool bool_8 = item18.bool_0;
					string targeteeringEntryObjectID3 = item18.TargeteeringEntryObjectID;
					int lostTarget3 = item18.LostTarget;
					int weaponQty3 = item18.WeaponQty;
					int weaponMaxQty3 = item18.WeaponMaxQty;
					int firingRange3 = item18.FiringRange;
					Waypoint[] waypoint_8 = null;
					Mission.WeaponeeringEntry item2 = new Mission.WeaponeeringEntry(int_8, weaponType3, weaponName3, weaponMaxRange3, weaponMinRange3, bool_8, targeteeringEntryObjectID3, lostTarget3, weaponQty3, weaponMaxQty3, firingRange3, ref waypoint_8);
					WeaponeeringList_SecondElement.Add(item2);
				}
			}
			if (!Information.IsNothing(list_12))
			{
				WeaponeeringList_SecondElementWingman = new List<Mission.WeaponeeringEntry>();
				foreach (Mission.WeaponeeringEntry item19 in list_12)
				{
					int int_9 = item19.int_0;
					Weapon._WeaponType weaponType4 = item19.WeaponType;
					string weaponName4 = item19.WeaponName;
					float weaponMaxRange4 = item19.WeaponMaxRange;
					float weaponMinRange4 = item19.WeaponMinRange;
					bool bool_9 = item19.bool_0;
					string targeteeringEntryObjectID4 = item19.TargeteeringEntryObjectID;
					int lostTarget4 = item19.LostTarget;
					int weaponQty4 = item19.WeaponQty;
					int weaponMaxQty4 = item19.WeaponMaxQty;
					int firingRange4 = item19.FiringRange;
					Waypoint[] waypoint_9 = null;
					Mission.WeaponeeringEntry item3 = new Mission.WeaponeeringEntry(int_9, weaponType4, weaponName4, weaponMaxRange4, weaponMinRange4, bool_9, targeteeringEntryObjectID4, lostTarget4, weaponQty4, weaponMaxQty4, firingRange4, ref waypoint_9);
					WeaponeeringList_SecondElementWingman.Add(item3);
				}
			}
			if (!Information.IsNothing(list_13))
			{
				WeaponeeringList_ThirdElement = new List<Mission.WeaponeeringEntry>();
				foreach (Mission.WeaponeeringEntry item20 in list_13)
				{
					int int_10 = item20.int_0;
					Weapon._WeaponType weaponType5 = item20.WeaponType;
					string weaponName5 = item20.WeaponName;
					float weaponMaxRange5 = item20.WeaponMaxRange;
					float weaponMinRange5 = item20.WeaponMinRange;
					bool bool_10 = item20.bool_0;
					string targeteeringEntryObjectID5 = item20.TargeteeringEntryObjectID;
					int lostTarget5 = item20.LostTarget;
					int weaponQty5 = item20.WeaponQty;
					int weaponMaxQty5 = item20.WeaponMaxQty;
					int firingRange5 = item20.FiringRange;
					Waypoint[] waypoint_10 = null;
					Mission.WeaponeeringEntry item4 = new Mission.WeaponeeringEntry(int_10, weaponType5, weaponName5, weaponMaxRange5, weaponMinRange5, bool_10, targeteeringEntryObjectID5, lostTarget5, weaponQty5, weaponMaxQty5, firingRange5, ref waypoint_10);
					WeaponeeringList_ThirdElement.Add(item4);
				}
			}
			if (!Information.IsNothing(list_14))
			{
				WeaponeeringList_ThirdElementWingman = new List<Mission.WeaponeeringEntry>();
				foreach (Mission.WeaponeeringEntry item21 in list_14)
				{
					int int_5 = item21.int_0;
					Weapon._WeaponType weaponType6 = item21.WeaponType;
					string weaponName6 = item21.WeaponName;
					float weaponMaxRange6 = item21.WeaponMaxRange;
					float weaponMinRange6 = item21.WeaponMinRange;
					bool bool_11 = item21.bool_0;
					string targeteeringEntryObjectID6 = item21.TargeteeringEntryObjectID;
					int lostTarget6 = item21.LostTarget;
					int weaponQty6 = item21.WeaponQty;
					int weaponMaxQty6 = item21.WeaponMaxQty;
					int firingRange6 = item21.FiringRange;
					Waypoint[] waypoint_5 = null;
					Mission.WeaponeeringEntry item5 = new Mission.WeaponeeringEntry(int_5, weaponType6, weaponName6, weaponMaxRange6, weaponMinRange6, bool_11, targeteeringEntryObjectID6, lostTarget6, weaponQty6, weaponMaxQty6, firingRange6, ref waypoint_5);
					WeaponeeringList_ThirdElementWingman.Add(item5);
				}
			}
			ReferenceWeapon_ID = int_4;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void FollowAltitudePreset()
	{
		if (Information.IsNothing(this) || !DesiredAltitudeOverride)
		{
			return;
		}
		switch (AltitudePreset)
		{
		case ActiveUnit_AI.AircraftAltitudePreset.None:
			DesiredAltitude = null;
			DesiredAltitude_TerrainFollowing = null;
			break;
		case ActiveUnit_AI.AircraftAltitudePreset.MinAltitude:
			DesiredAltitude = 0f;
			DesiredAltitude_TerrainFollowing = 0f;
			break;
		case ActiveUnit_AI.AircraftAltitudePreset.Low1000:
			if (TerrainFollowing)
			{
				DesiredAltitude = null;
				DesiredAltitude_TerrainFollowing = 304.8f;
			}
			else
			{
				DesiredAltitude = 304.8f;
				DesiredAltitude_TerrainFollowing = null;
			}
			break;
		case ActiveUnit_AI.AircraftAltitudePreset.Low2000:
			if (TerrainFollowing)
			{
				DesiredAltitude = null;
				DesiredAltitude_TerrainFollowing = 609.6f;
			}
			else
			{
				DesiredAltitude = 609.6f;
				DesiredAltitude_TerrainFollowing = null;
			}
			break;
		case ActiveUnit_AI.AircraftAltitudePreset.const_4:
			if (TerrainFollowing)
			{
				DesiredAltitude = null;
				DesiredAltitude_TerrainFollowing = 3657.6f;
			}
			else
			{
				DesiredAltitude = 3657.6f;
				DesiredAltitude_TerrainFollowing = null;
			}
			break;
		case ActiveUnit_AI.AircraftAltitudePreset.const_5:
			if (TerrainFollowing)
			{
				DesiredAltitude = null;
				DesiredAltitude_TerrainFollowing = 7620f;
			}
			else
			{
				DesiredAltitude = 7620f;
				DesiredAltitude_TerrainFollowing = null;
			}
			break;
		case ActiveUnit_AI.AircraftAltitudePreset.const_6:
			if (TerrainFollowing)
			{
				DesiredAltitude = null;
				DesiredAltitude_TerrainFollowing = 10972.8f;
			}
			else
			{
				DesiredAltitude = 10972.8f;
				DesiredAltitude_TerrainFollowing = null;
			}
			break;
		case ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude:
			DesiredAltitude = null;
			DesiredAltitude_TerrainFollowing = null;
			break;
		}
	}

	public void FollowDepthPreset(Scenario scenario_0)
	{
		if (!Information.IsNothing(this) && DesiredAltitudeOverride)
		{
			switch (DepthPreset)
			{
			case ActiveUnit_AI.SubmarineDepthPreset.None:
				DesiredAltitude = null;
				break;
			case ActiveUnit_AI.SubmarineDepthPreset.Periscope:
				DesiredAltitude = -20f;
				break;
			case ActiveUnit_AI.SubmarineDepthPreset.Shallow:
				DesiredAltitude = -40f;
				break;
			case ActiveUnit_AI.SubmarineDepthPreset.OverLayer:
				DesiredAltitude = OverLayerDepth(this, scenario_0);
				break;
			case ActiveUnit_AI.SubmarineDepthPreset.UnderLayer:
				DesiredAltitude = UnderLayerDepth(this, scenario_0);
				break;
			case ActiveUnit_AI.SubmarineDepthPreset.MaxDepth:
				DesiredAltitude = 0f;
				break;
			case ActiveUnit_AI.SubmarineDepthPreset.Surface:
				DesiredAltitude = 0f;
				break;
			}
		}
	}

	public static float OverLayerDepth(Waypoint waypoint_0, Scenario scenario_0)
	{
		return SonarModel.GetThermalLayerAtThisLocation(waypoint_0.Latitude, waypoint_0.Longitude, Terrain.GetElevation(waypoint_0.Latitude, waypoint_0.Longitude, bool_0: false, scenario_0), scenario_0).Ceiling + 10;
	}

	public static float UnderLayerDepth(Waypoint waypoint_0, Scenario scenario_0)
	{
		return SonarModel.GetThermalLayerAtThisLocation(waypoint_0.Latitude, waypoint_0.Longitude, Terrain.GetElevation(waypoint_0.Latitude, waypoint_0.Longitude, bool_0: false, scenario_0), scenario_0).Floor - 10;
	}

	public static void ComboBoxDataSource_WaypointType(ref DataTable dataTable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		dataTable_0.Rows.Add(0, GetWaypointTypeString(WaypointType.TakeOff));
		dataTable_0.Rows.Add(1, GetWaypointTypeString(WaypointType.Assemble));
		dataTable_0.Rows.Add(2, GetWaypointTypeString(WaypointType.TurningPoint));
		dataTable_0.Rows.Add(3, GetWaypointTypeString(WaypointType.Refuel));
		dataTable_0.Rows.Add(4, GetWaypointTypeString(WaypointType.StrikeIngress));
		dataTable_0.Rows.Add(5, GetWaypointTypeString(WaypointType.InitialPoint));
		dataTable_0.Rows.Add(6, GetWaypointTypeString(WaypointType.WeaponLaunch));
		dataTable_0.Rows.Add(7, GetWaypointTypeString(WaypointType.Target));
		dataTable_0.Rows.Add(8, GetWaypointTypeString(WaypointType.WeaponTarget));
		dataTable_0.Rows.Add(9, GetWaypointTypeString(WaypointType.StrikeEgress));
		dataTable_0.Rows.Add(10, GetWaypointTypeString(WaypointType.LandingMarshal));
		dataTable_0.Rows.Add(11, GetWaypointTypeString(WaypointType.Land));
		dataTable_0.Rows.Add(12, GetWaypointTypeString(WaypointType.StationStart_Racetrack));
		dataTable_0.Rows.Add(13, GetWaypointTypeString(WaypointType.StationStart_RaceTrackRandom));
		dataTable_0.Rows.Add(14, GetWaypointTypeString(WaypointType.StationStart_FigureEight));
		dataTable_0.Rows.Add(15, GetWaypointTypeString(WaypointType.StationStart_Area));
		dataTable_0.Rows.Add(16, GetWaypointTypeString(WaypointType.StationEnd));
		dataTable_0.Rows.Add(17, GetWaypointTypeString(WaypointType.HoldStart));
		dataTable_0.Rows.Add(18, GetWaypointTypeString(WaypointType.HoldEnd));
	}

	public static int? WaypointTypeSelection_To_WaypointType(ref object object_0)
	{
		try
		{
			int num = Conversions.ToInteger(object_0);
			if (1 == 0)
			{
			}
			int? result2 = num switch
			{
				0 => 15, 
				1 => 5, 
				2 => 6, 
				3 => 14, 
				4 => 12, 
				5 => 7, 
				6 => 17, 
				7 => 10, 
				8 => 19, 
				9 => 13, 
				10 => 11, 
				11 => 18, 
				12 => 20, 
				13 => 23, 
				14 => 21, 
				15 => 22, 
				16 => 24, 
				17 => 26, 
				18 => 27, 
				_ => null, 
			};
			if (1 == 0)
			{
			}
			return result2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101300", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			int? result = 6;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static int WaypointType_To_WaypointTypeSelection(object object_0)
	{
		try
		{
			int num = Conversions.ToInteger(object_0);
			if (1 == 0)
			{
			}
			int result = num switch
			{
				5 => 1, 
				6 => 2, 
				7 => 5, 
				10 => 7, 
				11 => 10, 
				12 => 4, 
				13 => 9, 
				14 => 3, 
				15 => 0, 
				17 => 6, 
				18 => 11, 
				19 => 8, 
				20 => 12, 
				21 => 14, 
				22 => 15, 
				23 => 13, 
				24 => 16, 
				26 => 17, 
				27 => 18, 
				_ => 0, 
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
			exception_?.Data.Add("Error at 101303", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 2;
		}
	}

	public static void ComboBoxDataSource_WaypointType_WeaponRoute(ref DataTable dataTable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		dataTable_0.Rows.Add(0, GetWaypointTypeString(WaypointType.Launch));
		dataTable_0.Rows.Add(1, GetWaypointTypeString(WaypointType.TurningPoint));
		dataTable_0.Rows.Add(2, GetWaypointTypeString(WaypointType.TerminalPoint));
		dataTable_0.Rows.Add(3, GetWaypointTypeString(WaypointType.Activation));
		dataTable_0.Rows.Add(4, GetWaypointTypeString(WaypointType.Termination));
		dataTable_0.Rows.Add(5, GetWaypointTypeString(WaypointType.HoldStart));
		dataTable_0.Rows.Add(6, GetWaypointTypeString(WaypointType.HoldEnd));
	}

	public static int? WaypointTypeSelection_To_WaypointType_WeaponRoute(ref object object_0)
	{
		try
		{
			int num = Conversions.ToInteger(object_0);
			if (1 == 0)
			{
			}
			int? result2 = num switch
			{
				0 => 28, 
				1 => 6, 
				2 => 2, 
				3 => 29, 
				4 => 30, 
				5 => 26, 
				6 => 27, 
				_ => null, 
			};
			if (1 == 0)
			{
			}
			return result2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			int? result = 6;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static int WaypointType_To_WaypointTypeSelection_WeaponRoute(object object_0)
	{
		try
		{
			int num = Conversions.ToInteger(object_0);
			if (1 == 0)
			{
			}
			int result = num switch
			{
				26 => 5, 
				27 => 6, 
				28 => 0, 
				29 => 3, 
				30 => 4, 
				6 => 1, 
				2 => 2, 
				_ => 1, 
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
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 1;
		}
	}

	[SpecialName]
	public static string GetWaypointTypeString(WaypointType waypointType_0)
	{
		if (1 == 0)
		{
		}
		string result = waypointType_0 switch
		{
			WaypointType.TerminalPoint => "终点", 
			WaypointType.Assemble => "Assemble", 
			WaypointType.TurningPoint => "转弯点", 
			WaypointType.InitialPoint => "初始点（IP）", 
			WaypointType.Split => "Split", 
			WaypointType.Formate => "Formate", 
			WaypointType.Target => "Target", 
			WaypointType.LandingMarshal => "着陆集结点", 
			WaypointType.StrikeIngress => "转弯点（入口）", 
			WaypointType.StrikeEgress => "转弯点（出口）", 
			WaypointType.Refuel => "Refuel", 
			WaypointType.TakeOff => "Take-Off", 
			WaypointType.Marshal => "Marshal", 
			WaypointType.WeaponLaunch => "武器发射", 
			WaypointType.Land => "Land", 
			WaypointType.WeaponTarget => "武器目标", 
			WaypointType.StationStart_Racetrack => "巡逻开始（跑道形）", 
			WaypointType.StationStart_FigureEight => "巡逻开始（八字形）", 
			WaypointType.StationStart_Area => "巡逻开始（区域）", 
			WaypointType.StationStart_RaceTrackRandom => "巡逻开始（跑道形+随机）", 
			WaypointType.StationEnd => "巡逻结束", 
			WaypointType.HoldStart => "警戒开始", 
			WaypointType.HoldEnd => "警戒结束", 
			WaypointType.Launch => "Launch", 
			WaypointType.Activation => "Activation", 
			WaypointType.Termination => "Termination", 
			_ => "None", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static void ComboBoxDataSource_Formation(ref DataTable dataTable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		dataTable_0.Rows.Add(0, GetFormationString(Formation.Spread));
		dataTable_0.Rows.Add(1, GetFormationString(Formation.Trail_1nm));
		dataTable_0.Rows.Add(2, GetFormationString(Formation.Split));
	}

	public static void ComboBoxDataSource_TurnRate(ref DataTable dataTable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		dataTable_0.Rows.Add(0, GetTurnRateString(TurnRateCategory.StandardRateTurn));
		dataTable_0.Rows.Add(1, GetTurnRateString(TurnRateCategory.HalfStandardRateTurn));
		dataTable_0.Rows.Add(2, GetTurnRateString(TurnRateCategory.DoubleStandardRateTurn));
		dataTable_0.Rows.Add(3, GetTurnRateString(TurnRateCategory.FlatTurn));
		dataTable_0.Rows.Add(4, GetTurnRateString(TurnRateCategory.TwoGTurn));
		dataTable_0.Rows.Add(5, GetTurnRateString(TurnRateCategory.const_5));
		dataTable_0.Rows.Add(6, GetTurnRateString(TurnRateCategory.const_6));
	}

	public static int? FormationSelection_To_Formation(ref object object_0)
	{
		int? result = null;
		try
		{
			switch (Conversions.ToInteger(object_0))
			{
			default:
				result = null;
				return result;
			case 0:
				result = 0;
				return result;
			case 1:
				result = 1;
				return result;
			case 2:
				result = 100;
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101301", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static int? TurnRateSelection_To_TurnRate(ref object object_0)
	{
		int? result = null;
		try
		{
			switch (Conversions.ToInteger(object_0))
			{
			default:
				result = null;
				return result;
			case 0:
				result = 0;
				return result;
			case 1:
				result = 1;
				return result;
			case 2:
				result = 2;
				return result;
			case 3:
				result = 3;
				return result;
			case 4:
				result = 4;
				return result;
			case 5:
				result = 5;
				return result;
			case 6:
				result = 6;
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200642", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static int Formation_To_FormationSelection(object object_0)
	{
		try
		{
			int num = Conversions.ToInteger(object_0);
			if (1 == 0)
			{
			}
			int result = num switch
			{
				100 => 2, 
				1 => 1, 
				0 => 0, 
				_ => 0, 
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
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	[SpecialName]
	public static string GetFormationString(Formation formation_0)
	{
		if (1 == 0)
		{
		}
		string result = formation_0 switch
		{
			Formation.Split => "Split", 
			Formation.Trail_1nm => "1nm Trail", 
			Formation.Spread => "Spread", 
			_ => "None", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	[SpecialName]
	public static string GetTurnRateString(TurnRateCategory turnRateCategory_0)
	{
		if (1 == 0)
		{
		}
		string result = turnRateCategory_0 switch
		{
			TurnRateCategory.StandardRateTurn => "标准速率，每秒3度", 
			TurnRateCategory.HalfStandardRateTurn => "半标准速率，每秒1.5度", 
			TurnRateCategory.DoubleStandardRateTurn => "双倍标准速率，每秒6度", 
			TurnRateCategory.FlatTurn => "平转（无坡度角），每秒0.6度", 
			TurnRateCategory.TwoGTurn => "2G速率，60度倾斜角度", 
			TurnRateCategory.const_5 => "3G转弯，70度倾斜角度", 
			TurnRateCategory.const_6 => "4G转弯，75度倾斜角度", 
			_ => "None", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static void ComboBoxDataSource_SpeedToT(ref DataTable dataTable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		dataTable_0.Rows.Add(0, GetSpeedToTString(SpeedToT.No));
		dataTable_0.Rows.Add(1, GetSpeedToTString(SpeedToT.Yes_DownOnly));
		dataTable_0.Rows.Add(2, GetSpeedToTString(SpeedToT.Yes_UpOrDown_Military));
		dataTable_0.Rows.Add(3, GetSpeedToTString(SpeedToT.Yes_UpOrDown_Afterburner));
	}

	public static int? SpeedToTSelection_To_SpeedToT(ref object object_0)
	{
		int? result = null;
		try
		{
			switch (Conversions.ToInteger(object_0))
			{
			default:
				result = null;
				return result;
			case 0:
				result = 0;
				return result;
			case 1:
				result = 1;
				return result;
			case 2:
				result = 2;
				return result;
			case 3:
				result = 3;
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public static string GetSpeedToTString(SpeedToT speedToT_0)
	{
		if (1 == 0)
		{
		}
		string result = speedToT_0 switch
		{
			SpeedToT.No => "No", 
			SpeedToT.Yes_DownOnly => "是，仅向下", 
			SpeedToT.Yes_UpOrDown_Military => "是，向下或向上（最大：军事）", 
			SpeedToT.Yes_UpOrDown_Afterburner => "是，向下或向上（最大：加力燃烧）", 
			_ => "None", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static int SpeedToT_To_FormationSpeedToT(object object_0)
	{
		try
		{
			int num = Conversions.ToInteger(object_0);
			if (1 == 0)
			{
			}
			int result = num switch
			{
				0 => 0, 
				1 => 1, 
				2 => 2, 
				3 => 3, 
				_ => 0, 
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
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	internal bool IncludeReponse()
	{
		if ((uint)(Type - 20) <= 4u)
		{
			return true;
		}
		return false;
	}

	internal bool SearchReponse()
	{
		if ((uint)(Type - 20) <= 3u)
		{
			return true;
		}
		return false;
	}

	internal bool EnableReponse()
	{
		if (Type == WaypointType.StationEnd)
		{
			return true;
		}
		return false;
	}

	internal bool ChangeReponse()
	{
		if (Type == WaypointType.HoldStart)
		{
			return true;
		}
		return false;
	}

	internal bool InitReponse()
	{
		if (Type == WaypointType.HoldEnd)
		{
			return true;
		}
		return false;
	}

	internal bool CheckReponse()
	{
		if ((uint)(Type - 26) <= 1u)
		{
			return true;
		}
		return false;
	}

	internal bool ConcatReponse()
	{
		WaypointType type = Type;
		if (type != WaypointType.Assemble && (uint)(type - 26) > 1u)
		{
			return false;
		}
		return true;
	}

	public void PostDeserializationHousekeeping(ref Scenario scenario_0, Side side_0, bool bool_0)
	{
		try
		{
			if (TankerMissions_IDs.Count <= 0)
			{
				return;
			}
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i++)
			{
				foreach (Mission mission in sides_ReadOnly[i].Missions)
				{
					if (TankerMissions_IDs.Contains(mission.ObjectID))
					{
						TankerMissions.Add(mission);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
