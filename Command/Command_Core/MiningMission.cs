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

public sealed class MiningMission : Mission
{
	public class MiningInformation
	{
		private int? m_PropertyItem;

		private int? m_ImporterItem;

		private int? m_RepositoryItem;

		private byte? bridgeItem;

		public GeoPoint LastMineLocal;

		public GeoPoint LastMineSet;

		public Waypoint LastPlottedWayPoint;

		public int? Sequence
		{
			get
			{
				return m_PropertyItem;
			}
			set
			{
				m_PropertyItem = value;
			}
		}

		public int? Spacing
		{
			get
			{
				return m_ImporterItem;
			}
			set
			{
				m_ImporterItem = value;
			}
		}

		public int? SpacingSet
		{
			get
			{
				return m_RepositoryItem;
			}
			set
			{
				m_RepositoryItem = value;
			}
		}

		public byte? Method
		{
			get
			{
				return bridgeItem;
			}
			set
			{
				bridgeItem = value;
			}
		}

		public MiningInformation(GeoPoint geoPoint_0, int? nullable_0, int? nullable_1, byte? nullable_2, int? nullable_3 = null)
		{
			LastMineLocal = null;
			LastMineSet = null;
			LastPlottedWayPoint = null;
			m_PropertyItem = nullable_0;
			m_ImporterItem = nullable_1;
			m_RepositoryItem = nullable_3;
			bridgeItem = nullable_2;
			LastMineLocal = geoPoint_0;
		}
	}

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

	public long ArmDelay;

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

	private ActiveUnit_AI.AircraftAltitudePreset? m_ParameterConsumer;

	private ActiveUnit_AI.AircraftAltitudePreset? _ExpressionConsumer;

	private bool? dispatcherConsumer;

	private bool? m_ListenerConsumer;

	private ActiveUnit_AI.SubmarineDepthPreset? m_ConfigConsumer;

	private ActiveUnit_AI.SubmarineDepthPreset? _RegistryConsumer;

	private bool? _DefinitionConsumer;

	private bool? valConsumer;

	public ActiveUnit.Throttle TransitThrottle_Ship;

	public ActiveUnit.Throttle StationThrottle_Ship;

	public ActiveUnit.Throttle TransitThrottle_Facility;

	public ActiveUnit.Throttle StationThrottle_Facility;

	public _AircraftFormationType Formation_Cruise;

	public _AircraftFormationType Formation_Attack;

	public int? MinesLaidInSets;

	public int? MinesLaidInterval;

	public int? MinesLaidSetInterval;

	public byte? MinesLaidMethod;

	public ActiveUnit_AI.AircraftAltitudePreset? TransitAltitude_Preset
	{
		get
		{
			return m_ParameterConsumer;
		}
		set
		{
			m_ParameterConsumer = value;
		}
	}

	public ActiveUnit_AI.AircraftAltitudePreset? StationAltitude_Preset
	{
		get
		{
			return _ExpressionConsumer;
		}
		set
		{
			_ExpressionConsumer = value;
		}
	}

	public bool? UseTransitAltitude_Preset
	{
		get
		{
			return dispatcherConsumer;
		}
		set
		{
			dispatcherConsumer = value;
		}
	}

	public bool? UseStationAltitude_Preset
	{
		get
		{
			return m_ListenerConsumer;
		}
		set
		{
			m_ListenerConsumer = value;
		}
	}

	public bool? UseStationDepth_Submarine_Preset
	{
		get
		{
			return valConsumer;
		}
		set
		{
			valConsumer = value;
		}
	}

	public bool? UseTransitDepth_Submarine_Preset
	{
		get
		{
			return _DefinitionConsumer;
		}
		set
		{
			_DefinitionConsumer = value;
		}
	}

	public ActiveUnit_AI.SubmarineDepthPreset? StationDepth_Submarine_Preset
	{
		get
		{
			return _RegistryConsumer;
		}
		set
		{
			_RegistryConsumer = value;
		}
	}

	public ActiveUnit_AI.SubmarineDepthPreset? TransitDepth_Submarine_Preset
	{
		get
		{
			return m_ConfigConsumer;
		}
		set
		{
			m_ConfigConsumer = value;
		}
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, ref Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("MiningMission");
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
			xmlWriter_0.WriteElementString("OTR", OneThirdRule.ToString());
			xmlWriter_0.WriteElementString("AD", ArmDelay.ToString());
			if (SecondaryAirBase != null)
			{
				xmlWriter_0.WriteElementString("HomeAirbase", SecondaryAirBase.ObjectID.ToString());
			}
			if (SecondaryNavalBase != null)
			{
				xmlWriter_0.WriteElementString("HomeNavalbase", SecondaryNavalBase.ObjectID.ToString());
			}
			xmlWriter_0.WriteElementString("SISIH", ScrubIfSideIsHuman.ToString());
			xmlWriter_0.WriteElementString("UseFlightplan", UseFlightplans.ToString());
			xmlWriter_0.WriteElementString("UseFlightplansOnly", UsePreGeneratedFlightplansOnly.ToString());
			xmlWriter_0.WriteElementString("IncludeInATO", IncludeInATO.ToString());
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
			XmlWriter obj = xmlWriter_0;
			byte transitThrottle_Submarine = (byte)TransitThrottle_Submarine;
			obj.WriteElementString("TransitThrottle_Submarine", transitThrottle_Submarine.ToString());
			XmlWriter obj3 = xmlWriter_0;
			transitThrottle_Submarine = (byte)StationThrottle_Submarine;
			obj3.WriteElementString("StationThrottle_Submarine", transitThrottle_Submarine.ToString());
			if (TransitDepth_Submarine.HasValue)
			{
				xmlWriter_0.WriteElementString("TransitDepth_Submarine", TransitDepth_Submarine.Value.ToString());
			}
			if (StationDepth_Submarine.HasValue)
			{
				xmlWriter_0.WriteElementString("StationDepth_Submarine", StationDepth_Submarine.Value.ToString());
			}
			XmlWriter obj4 = xmlWriter_0;
			transitThrottle_Submarine = (byte)TransitThrottle_Ship;
			obj4.WriteElementString("TransitThrottle_Ship", transitThrottle_Submarine.ToString());
			XmlWriter obj5 = xmlWriter_0;
			transitThrottle_Submarine = (byte)StationThrottle_Ship;
			obj5.WriteElementString("StationThrottle_Ship", transitThrottle_Submarine.ToString());
			XmlWriter obj6 = xmlWriter_0;
			transitThrottle_Submarine = (byte)TransitThrottle_Facility;
			obj6.WriteElementString("TransitThrottle_Facility", transitThrottle_Submarine.ToString());
			XmlWriter obj7 = xmlWriter_0;
			transitThrottle_Submarine = (byte)StationThrottle_Facility;
			obj7.WriteElementString("StationThrottle_Facility", transitThrottle_Submarine.ToString());
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
			xmlWriter_0.WriteElementString("FlightSize", ((int)base.FlightSize).ToString());
			xmlWriter_0.WriteElementString("GroupSize", ((int)GroupSize).ToString());
			XmlWriter obj8 = xmlWriter_0;
			int formation_Cruise = (int)Formation_Cruise;
			obj8.WriteElementString("Formation_Cruise", formation_Cruise.ToString());
			XmlWriter obj9 = xmlWriter_0;
			formation_Cruise = (int)Formation_Attack;
			obj9.WriteElementString("Formation_Attack", formation_Cruise.ToString());
			XmlWriter obj10 = xmlWriter_0;
			formation_Cruise = (int)MinimumNumberOfAircraft;
			obj10.WriteElementString("MinAircraftReq", formation_Cruise.ToString());
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
			if (MinesLaidInSets.HasValue)
			{
				xmlWriter_0.WriteElementString("MinesLaidInSets", MinesLaidInSets.ToString());
			}
			if (MinesLaidInterval.HasValue)
			{
				xmlWriter_0.WriteElementString("MinesLaidInterval", MinesLaidInterval.ToString());
			}
			if (MinesLaidMethod.HasValue)
			{
				xmlWriter_0.WriteElementString("MinesLaidMethod", MinesLaidMethod.ToString());
			}
			if (MinesLaidSetInterval.HasValue)
			{
				xmlWriter_0.WriteElementString("MinesLaidSetInterval", MinesLaidSetInterval.ToString());
			}
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
			exception_?.Data.Add("Error at 100637", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static MiningMission FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		try
		{
			MiningMission miningMission = new MiningMission(null, scenario_0, "");
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
					Mission.FromXMLCommon(miningMission, xmlNode_);
					switch (xmlNode_.Name)
					{
					case "Status":
						miningMission.SetStatus(scenario_0, (MissionStatus)Conversions.ToByte(xmlNode_.InnerText));
						break;
					case "TransitTerrainFollowing_Aircraft":
						miningMission.TransitTerrainFollowing_Aircraft = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TransitDepth_Submarine_Preset":
						miningMission.TransitDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Name":
						miningMission.Name = xmlNode_.InnerText;
						break;
					case "START":
					{
						DateTime value4 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						miningMission._StartTime = value4;
						break;
					}
					case "SISIH":
						miningMission.ScrubIfSideIsHuman = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "UseFlightplan":
						miningMission.UseFlightplans = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "IncludeInATO":
						miningMission.IncludeInATO = Conversions.ToBoolean(xmlNode_.InnerText);
						flag = true;
						break;
					case "UseGroupSizeHardLimit":
						miningMission.UseGroupSizeHardLimit = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Area":
						try
						{
							enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator2.Current;
								miningMission.Area.Add(ReferencePoint.FromXML(ref xmlNode_2, ref concurrentDictionary_0));
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
					case "TankerMinNumber_Airborne":
						miningMission.TankerMinNumber_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "MinesLaidSetInterval":
						miningMission.MinesLaidSetInterval = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "AD":
						miningMission.ArmDelay = Conversions.ToLong(xmlNode_.InnerText);
						break;
					case "LaunchMissionWithoutTankersInPlace":
						miningMission.LaunchMissionWithoutTankersInPlace = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TransitThrottle_Ship":
						miningMission.TransitThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TankerMaxDistance_Airborne":
						miningMission.TankerMaxDistance_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "OTR":
					case "OneThirdRule":
						miningMission.OneThirdRule = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "UseTransitDepth_Submarine_Preset":
						miningMission.UseTransitDepth_Submarine_Preset = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TankerMinNumber_Total":
						miningMission.TankerMinNumber_Total = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "UseFlightplansOnly":
						miningMission.UsePreGeneratedFlightplansOnly = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TimeOnTarget":
					{
						DateTime value3 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						miningMission.TimeOnTarget = value3;
						break;
					}
					case "EmptySlotsList":
						miningMission.EmptySlotsList = EmptyAircraftSlot.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
						break;
					case "HomeNavalbase":
						miningMission._SecondaryNavalBaseID = xmlNode_.InnerText;
						break;
					case "StationThrottle_Ship":
						miningMission.StationThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode_.InnerText))
						{
							miningMission.ObjectID_Set(xmlNode_.InnerText);
							concurrentDictionary_0.TryAdd(miningMission.ObjectID, miningMission);
							break;
						}
						return (MiningMission)concurrentDictionary_0[xmlNode_.InnerText];
					case "Doctrine":
						miningMission.Doctrine = Doctrine.FromXML(ref xmlNode_, miningMission);
						break;
					case "TankerMinNumber_Station":
						miningMission.TankerMinNumber_Station = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TakeOffTime":
					{
						DateTime value2 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						miningMission.TakeOffTime = value2;
						break;
					}
					case "FlightList":
						miningMission.FlightList = Flight.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
						break;
					case "StationThrottle_Facility":
						miningMission.StationThrottle_Facility = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "MinesLaidInSets":
						miningMission.MinesLaidInSets = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TankerMissionList":
						try
						{
							enumerator4 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator4.Current;
								miningMission.TankerMissions_IDs.Add(xmlNode2.InnerText);
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
						miningMission.FuelQtyToStartLookingForTanker_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "UseFlightSizeHardLimit":
						miningMission.UseFlightSizeHardLimit = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "FlightSize":
						miningMission.FlightSize = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "UseTransitAltitude_Preset":
						miningMission.UseTransitAltitude_Preset = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "HomeAirbase":
						miningMission._SecondaryAirBaseID = xmlNode_.InnerText;
						break;
					case "TransitAltitude_Preset":
						miningMission.TransitAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TransitDepth_Submarine":
						miningMission.TransitDepth_Submarine = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Category":
						miningMission.Category = (MissionCategory)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "END":
					{
						DateTime value = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						miningMission._EndTime = value;
						break;
					}
					case "TransitThrottle_Facility":
						miningMission.TransitThrottle_Facility = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Formation_Attack":
						miningMission.Formation_Attack = (_AircraftFormationType)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "MinesLaidInterval":
						miningMission.MinesLaidInterval = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "_Phase":
						miningMission._Phase = (MissionPhase)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "PriorityWeight":
						miningMission.PriorityWeight = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "StationDepth_Submarine_Preset":
						miningMission.StationDepth_Submarine_Preset = (ActiveUnit_AI.SubmarineDepthPreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "UseStationDepth_Submarine_Preset":
						miningMission.UseStationDepth_Submarine_Preset = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TankerUsage":
						miningMission.TankerUsage = (TankerMethod)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "AssignedUnitsList":
						try
						{
							enumerator3 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode = (XmlNode)enumerator3.Current;
								miningMission.UnitsAssignedToMissionIDs.Add(xmlNode.InnerText);
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
						miningMission.StationThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TankerFollowsReceivers":
						miningMission.TankerFollowsReceivers = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "StationThrottle_Submarine":
						miningMission.StationThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "MinAircraftReq":
						miningMission.MinimumNumberOfAircraft = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "StationAltitude_Aircraft":
					case "StationAltitude":
						miningMission.StationAltitude_Aircraft = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "UseStationAltitude_Preset":
						miningMission.UseStationAltitude_Preset = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "GroupSize":
						miningMission.GroupSize = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TransitAltitude":
					case "TransitAltitude_Aircraft":
						miningMission.TransitAltitude_Aircraft = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "TransitThrottle_Submarine":
						miningMission.TransitThrottle_Submarine = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Formation_Cruise":
						miningMission.Formation_Cruise = (_AircraftFormationType)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "StationAltitude_Preset":
						miningMission.StationAltitude_Preset = (ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Completion":
						miningMission.Completion = Conversions.ToSingle(xmlNode_.InnerText);
						break;
					case "StationTerrainFollowing_Aircraft":
						miningMission.StationTerrainFollowing_Aircraft = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "MaxReceiversInQueuePerTanker_Airborne":
						miningMission.MaxReceiversInQueuePerTanker_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "MinesLaidMethod":
						miningMission.MinesLaidMethod = Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "StationDepth_Submarine":
						miningMission.StationDepth_Submarine = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "TransitThrottle":
					case "TransitThrottle_Aircraft":
						miningMission.TransitThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
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
			if (miningMission.TransitThrottle_Submarine == ActiveUnit.Throttle.FullStop)
			{
				miningMission.TransitTerrainFollowing_Aircraft = false;
				miningMission.StationTerrainFollowing_Aircraft = false;
				miningMission.TransitThrottle_Submarine = ActiveUnit.Throttle.Cruise;
				miningMission.StationThrottle_Submarine = ActiveUnit.Throttle.Loiter;
				miningMission.TransitThrottle_Ship = ActiveUnit.Throttle.Cruise;
				miningMission.StationThrottle_Ship = ActiveUnit.Throttle.Loiter;
				miningMission.TransitThrottle_Facility = ActiveUnit.Throttle.Cruise;
				miningMission.StationThrottle_Facility = ActiveUnit.Throttle.Loiter;
			}
			if (miningMission.TransitAltitude_Aircraft.HasValue && miningMission.UseTransitAltitude_Preset.GetValueOrDefault())
			{
				miningMission.UseTransitAltitude_Preset = false;
				miningMission.TransitAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
			}
			if (miningMission.StationAltitude_Aircraft.HasValue && miningMission.UseStationAltitude_Preset.GetValueOrDefault())
			{
				miningMission.UseStationAltitude_Preset = false;
				miningMission.StationAltitude_Preset = ActiveUnit_AI.AircraftAltitudePreset.Custom;
			}
			if (miningMission.TransitDepth_Submarine.HasValue && miningMission.UseTransitDepth_Submarine_Preset.GetValueOrDefault())
			{
				miningMission.UseTransitDepth_Submarine_Preset = false;
				miningMission.TransitDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
			}
			if (miningMission.StationDepth_Submarine.HasValue && miningMission.UseStationDepth_Submarine_Preset.GetValueOrDefault())
			{
				miningMission.UseStationDepth_Submarine_Preset = false;
				miningMission.StationDepth_Submarine_Preset = ActiveUnit_AI.SubmarineDepthPreset.Custom;
			}
			if (miningMission.Doctrine.ReplenishmentSelection_Inherits())
			{
				miningMission.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
			}
			if (!flag)
			{
				miningMission.IncludeInATO = true;
			}
			return miningMission;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100638", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			MiningMission result = new MiningMission(null, scenario_0, "");
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private MiningMission(Side side_0, Scenario scenario_0, string string_0)
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
		MinesLaidInSets = null;
		MinesLaidInterval = null;
		MinesLaidSetInterval = null;
		MinesLaidMethod = null;
		IsMission = true;
		MissionClass = _MissionClass.Mining;
	}

	public MiningMission(Side side_0, Scenario scenario_0, string string_0, MissionCategory missionCategory_0, List<ReferencePoint> list_0, bool bool_0)
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
		MinesLaidInSets = null;
		MinesLaidInterval = null;
		MinesLaidSetInterval = null;
		MinesLaidMethod = null;
		IsMission = true;
		Name = string_0;
		MissionClass = _MissionClass.Mining;
		Category = missionCategory_0;
		Area = list_0;
		OneThirdRule = true;
		ArmDelay = 7200L;
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
		base.FlightSize = 4;
		GroupSize = 1;
		UseFlightSizeHardLimit = true;
		IncludeInATO = true;
		string string_ = null;
		if (bool_0 && !ActiveUnit_Navigator.ValidateArea(ref Area, ref string_, side_0, scenario_0, "布雷任务'" + Name + "'"))
		{
			GameGeneral.ResolveBridge(string_, side_0);
		}
		Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
		Doctrine.SetWithdrawAttackThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._WeaponQuantityThreshold.Exhausted);
	}

	[SpecialName]
	public override string GetDescriptionString(Scenario scenario_0)
	{
		return "布雷任务";
	}

	public override void Printout(StringBuilder stringBuilder_0)
	{
		throw new NotImplementedException();
	}

	public override Mission Clone()
	{
		MiningMission obj = (MiningMission)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Name = "[克隆]" + Name;
		obj.Area = new ReferencePoint().ExcludeWriter(ref Area);
		return obj;
	}
}
