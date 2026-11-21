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

public sealed class Strike : Mission
{
	public enum StrikeType
	{
		Air_Intercept,
		Land_Strike,
		Maritime_Strike,
		Sub_Strike
	}

	public StrikeType Type;

	public HashSet<Module_Unit.Unit> SpecificTargets;

	private List<string> m_SpecificationProxy;

	public bool UsePlanner;

	public Doctrine Doctrine_Escorts;

	public _FlightQty MinimumNumberOfAircraft;

	public _FlightQty MinimumNumberOfAircraft_Escorts_Shooter;

	public _FlightQty MinimumNumberOfAircraft_Escorts_NonShooter;

	public _FlightQty MaxFlightNumber_Strike;

	public _FlightQty MaximumNumberOfAircraft_Escorts_Shooter;

	public _FlightQty MaximumNumberOfAircraft_Escorts_NonShooter;

	public _AircraftFormationType Formation_Cruise;

	public _AircraftFormationType Formation_Attack;

	public _BingoFuelSetting BingoFuel;

	public _TargeteeringMethod TargeteeringMethod;

	public _FlightSize Escort_FlightSize_Shooter;

	public _FlightSize Escort_FlightSize_NonShooter;

	public _AircraftFormationType Escort_Formation_Cruise;

	public _AircraftFormationType Escort_Formation_Attack;

	public ActiveUnit.Throttle? Escort_TransitThrottle;

	public ActiveUnit.Throttle? Escort_AttackThrottle;

	public bool Escort_TransitTerrainFollowing;

	public bool Escort_AttackTerrainFollowing;

	public _GroupSize Escort_GroupSize;

	public float? Escort_TransitAltitude;

	public float? Escort_AttackAltitude;

	public int Escort_ResponseRadius;

	public int Escort_ResponseRadius_SEAD;

	public _FlightQty Escort_NumberOfFlights_Investigate;

	public _FlightQty Escort_NumberOfFlights_Engage;

	public int Escort_WingmanEngageDistance;

	public _GroupQty Escort_NumberOfBoats_Investigate;

	public _GroupQty Escort_NumberOfBoats_Engage;

	public int Escort_GroupMemberEngageDistance;

	public int MinResponseRadius_Aircraft;

	public int MaxResponseRadius_Aircraft;

	public int MinResponseRadius_Ship;

	public int MaxResponseRadius_Ship;

	public bool OneTimeOnly;

	public bool OneTimeOnlyFlown;

	public _RadarBehaviour RadarBehaviour;

	public bool RTB_When_Target_Destroyed;

	public bool UseFlightSizeHardLimit_Escort;

	public bool UseGroupSizeHardLimit_Escort;

	public _AttackMethod AttackMethod;

	public _SplitDistance SplitDistance;

	public Misc.PostureStance MinimumContactStanceToTrigger;

	public bool FocusEntirelyOnStrikeTargets;

	public int TargetCount
	{
		get
		{
			if (SpecificTargets == null)
			{
				SpecificTargets = new HashSet<Module_Unit.Unit>();
			}
			return SpecificTargets.Count;
		}
	}

	public override void ReleaseReferences()
	{
		try
		{
			base.ReleaseReferences();
			SpecificTargets = null;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, ref Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Strike");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Name", Name);
			xmlWriter_0.WriteElementString("Category", ((byte)Category).ToString());
			XmlWriter obj = xmlWriter_0;
			int type = (int)Type;
			obj.WriteElementString("Type", type.ToString());
			method_0(ref xmlWriter_0, ref hashSet_0, ref scenario_0);
			Doctrine.ToXML(ref xmlWriter_0, ref scenario_0);
			Doctrine_Escorts.ToXML(ref xmlWriter_0, ref scenario_0, "Doctrine_Escorts");
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
			if (Deactivation_UnassignUnits)
			{
				xmlWriter_0.WriteElementString("Deactivation_UnassignUnits", Deactivation_UnassignUnits.ToString());
			}
			if (Deactivation_OrderRTB)
			{
				xmlWriter_0.WriteElementString("CheckBox_OrderRTB", Deactivation_OrderRTB.ToString());
			}
			if (Deactivation_DeleteMission)
			{
				xmlWriter_0.WriteElementString("CheckBox_DeleteMission", Deactivation_DeleteMission.ToString());
			}
			if (ScrubIfSideIsHuman)
			{
				xmlWriter_0.WriteElementString("SISIH", ScrubIfSideIsHuman.ToString());
			}
			if (UseFlightplans)
			{
				xmlWriter_0.WriteElementString("UseFlightplan", UseFlightplans.ToString());
			}
			if (UsePreGeneratedFlightplansOnly)
			{
				xmlWriter_0.WriteElementString("UseFlightplansOnly", UsePreGeneratedFlightplansOnly.ToString());
			}
			if (IncludeInATO)
			{
				xmlWriter_0.WriteElementString("IncludeInATO", IncludeInATO.ToString());
			}
			if (SecondaryAirBase != null)
			{
				xmlWriter_0.WriteElementString("HomeAirbase", SecondaryAirBase.ObjectID.ToString());
			}
			if (SecondaryNavalBase != null)
			{
				xmlWriter_0.WriteElementString("HomeNavalbase", SecondaryNavalBase.ObjectID.ToString());
			}
			if (SpecificTargets.Count > 0)
			{
				xmlWriter_0.WriteStartElement("SpecificTargets");
				foreach (Module_Unit.Unit specificTarget in SpecificTargets)
				{
					if (!Information.IsNothing(specificTarget))
					{
						xmlWriter_0.WriteElementString("ID", specificTarget.ObjectID);
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteElementString("MCSTT", Conversions.ToString((byte)MinimumContactStanceToTrigger));
			if (GetStatus(scenario_0) != 0)
			{
				xmlWriter_0.WriteElementString("Status", ((byte)GetStatus(scenario_0)).ToString());
			}
			if (UsePlanner)
			{
				xmlWriter_0.WriteElementString("UP", UsePlanner.ToString());
			}
			if ((int)base.FlightSize != 0)
			{
				xmlWriter_0.WriteElementString("FlightSize", ((int)base.FlightSize).ToString());
			}
			if ((int)GroupSize != 0)
			{
				xmlWriter_0.WriteElementString("GroupSize", ((int)GroupSize).ToString());
			}
			XmlWriter obj12 = xmlWriter_0;
			type = (int)Formation_Cruise;
			obj12.WriteElementString("Formation_Cruise", type.ToString());
			XmlWriter obj15 = xmlWriter_0;
			type = (int)Formation_Attack;
			obj15.WriteElementString("Formation_Attack", type.ToString());
			XmlWriter obj16 = xmlWriter_0;
			type = (int)BingoFuel;
			obj16.WriteElementString("Bingo", type.ToString());
			XmlWriter obj17 = xmlWriter_0;
			type = (int)TargeteeringMethod;
			obj17.WriteElementString("TargeteeringMethod", type.ToString());
			xmlWriter_0.WriteElementString("Escort_FlightSize_Shooter", ((int)Escort_FlightSize_Shooter).ToString());
			xmlWriter_0.WriteElementString("Escort_FlightSize_NonShooter", ((int)Escort_FlightSize_NonShooter).ToString());
			XmlWriter obj18 = xmlWriter_0;
			type = (int)Escort_Formation_Cruise;
			obj18.WriteElementString("Escort_Formation_Cruise", type.ToString());
			XmlWriter obj19 = xmlWriter_0;
			type = (int)Escort_Formation_Attack;
			obj19.WriteElementString("Escort_Formation_Attack", type.ToString());
			if (Escort_TransitThrottle.HasValue)
			{
				xmlWriter_0.WriteElementString("Escort_TransitThrottle", ((byte)Escort_TransitThrottle.Value).ToString());
			}
			if (Escort_AttackThrottle.HasValue)
			{
				xmlWriter_0.WriteElementString("Escort_StationThrottle", ((byte)Escort_AttackThrottle.Value).ToString());
			}
			if (Escort_TransitAltitude.HasValue)
			{
				xmlWriter_0.WriteElementString("Escort_TransitAltitude", Escort_TransitAltitude.Value.ToString());
			}
			if (Escort_AttackAltitude.HasValue)
			{
				xmlWriter_0.WriteElementString("Escort_StationAltitude", Escort_AttackAltitude.Value.ToString());
			}
			xmlWriter_0.WriteElementString("Escort_TransitTerrainFollowing", Escort_TransitTerrainFollowing.ToString());
			xmlWriter_0.WriteElementString("Escort_AttackTerrainFollowing", Escort_AttackTerrainFollowing.ToString());
			xmlWriter_0.WriteElementString("Escort_ResponseRadius", Escort_ResponseRadius.ToString());
			xmlWriter_0.WriteElementString("Escort_ResponseRadius_SEAD", Escort_ResponseRadius_SEAD.ToString());
			xmlWriter_0.WriteElementString("Escort_GroupSize", ((int)Escort_GroupSize).ToString());
			xmlWriter_0.WriteElementString("Escort_ResponseRadius_SEAD", Escort_ResponseRadius_SEAD.ToString());
			XmlWriter obj20 = xmlWriter_0;
			type = (int)MinimumNumberOfAircraft;
			obj20.WriteElementString("MinAircraftReq_Strikers", type.ToString());
			XmlWriter obj21 = xmlWriter_0;
			type = (int)MaxFlightNumber_Strike;
			obj21.WriteElementString("MaxFlightNumber_Strike", type.ToString());
			XmlWriter obj2 = xmlWriter_0;
			type = (int)MinimumNumberOfAircraft_Escorts_Shooter;
			obj2.WriteElementString("MinAircraftReq_Escorts_Shooter", type.ToString());
			XmlWriter obj3 = xmlWriter_0;
			type = (int)MaximumNumberOfAircraft_Escorts_Shooter;
			obj3.WriteElementString("MaxAircraftToFly_Escort_Shooter", type.ToString());
			XmlWriter obj4 = xmlWriter_0;
			type = (int)MinimumNumberOfAircraft_Escorts_NonShooter;
			obj4.WriteElementString("MinAircraftReq_Escorts_NonShooter", type.ToString());
			XmlWriter obj5 = xmlWriter_0;
			type = (int)MaximumNumberOfAircraft_Escorts_NonShooter;
			obj5.WriteElementString("MaxAircraftToFly_Escort_NonShooter", type.ToString());
			xmlWriter_0.WriteElementString("FocusEntirelyOnStrikeTargets", FocusEntirelyOnStrikeTargets.ToString());
			xmlWriter_0.WriteElementString("MinResponseRadius_Aircraft", MinResponseRadius_Aircraft.ToString());
			xmlWriter_0.WriteElementString("MaxResponseRadius_Aircraft", MaxResponseRadius_Aircraft.ToString());
			xmlWriter_0.WriteElementString("MinResponseRadius_Ship", MinResponseRadius_Ship.ToString());
			xmlWriter_0.WriteElementString("MaxResponseRadius_Ship", MaxResponseRadius_Ship.ToString());
			xmlWriter_0.WriteElementString("PrePlannedOnly", RTB_When_Target_Destroyed.ToString());
			xmlWriter_0.WriteElementString("FocusEntirelyOnStrikeTargets", FocusEntirelyOnStrikeTargets.ToString());
			xmlWriter_0.WriteElementString("OneTimeOnly", OneTimeOnly.ToString());
			xmlWriter_0.WriteElementString("OneTimeOnlyFlown", OneTimeOnlyFlown.ToString());
			XmlWriter obj6 = xmlWriter_0;
			type = (int)RadarBehaviour;
			obj6.WriteElementString("RadarBehaviour", type.ToString());
			XmlWriter obj7 = xmlWriter_0;
			type = (int)AttackMethod;
			obj7.WriteElementString("AttackMethod", type.ToString());
			XmlWriter obj8 = xmlWriter_0;
			type = (int)SplitDistance;
			obj8.WriteElementString("SplitDistance", type.ToString());
			xmlWriter_0.WriteElementString("UseFlightSizeHardLimit", UseFlightSizeHardLimit.ToString());
			xmlWriter_0.WriteElementString("UseFlightSizeHardLimit_Escort", UseFlightSizeHardLimit_Escort.ToString());
			xmlWriter_0.WriteElementString("UseGroupSizeHardLimit", UseGroupSizeHardLimit.ToString());
			xmlWriter_0.WriteElementString("UseGroupSizeHardLimit_Escort", UseGroupSizeHardLimit_Escort.ToString());
			XmlWriter obj9 = xmlWriter_0;
			byte tankerUsage = (byte)TankerUsage;
			obj9.WriteElementString("TankerUsage", tankerUsage.ToString());
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
			XmlWriter obj10 = xmlWriter_0;
			type = (int)Escort_NumberOfFlights_Investigate;
			obj10.WriteElementString("Escort_NumberOfFlights_Investigate", type.ToString());
			XmlWriter obj11 = xmlWriter_0;
			type = (int)Escort_NumberOfFlights_Engage;
			obj11.WriteElementString("Escort_NumberOfFlights_Engage", type.ToString());
			xmlWriter_0.WriteElementString("Escort_WingmanEngageDistance", Escort_WingmanEngageDistance.ToString());
			XmlWriter obj13 = xmlWriter_0;
			type = (int)Escort_NumberOfBoats_Investigate;
			obj13.WriteElementString("Escort_NumberOfBoats_Investigate", type.ToString());
			XmlWriter obj14 = xmlWriter_0;
			type = (int)Escort_NumberOfBoats_Engage;
			obj14.WriteElementString("Escort_NumberOfBoats_Engage", type.ToString());
			xmlWriter_0.WriteElementString("Escort_GroupMemberEngageDistance", Escort_GroupMemberEngageDistance.ToString());
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
			exception_?.Data.Add("Error at 100646", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Strike(Side side_0, Scenario scenario_0, string string_0)
		: base(side_0, scenario_0, string_0)
	{
		SpecificTargets = new HashSet<Module_Unit.Unit>();
		m_SpecificationProxy = new List<string>();
		List<ActiveUnit> list_ = null;
		Doctrine_Escorts = new Doctrine(this, ref list_);
		AttackMethod = _AttackMethod.Formation_SingleAim;
		SplitDistance = _SplitDistance.Typical_20nm;
		IsMission = true;
		MissionClass = _MissionClass.Strike;
	}

	public static Strike FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			Strike strike = new Strike(null, scenario_0, "");
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
					Mission.FromXMLCommon(strike, xmlNode_);
					switch (xmlNode_.Name)
					{
					case "Status":
						strike.SetStatus(scenario_0, (MissionStatus)Conversions.ToByte(xmlNode_.InnerText));
						break;
					case "Name":
						strike.Name = xmlNode_.InnerText;
						break;
					case "START":
					{
						DateTime value = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						strike._StartTime = value;
						break;
					}
					case "OneTimeOnly":
						strike.OneTimeOnly = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "UseFlightplan":
						strike.UseFlightplans = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "IncludeInATO":
						strike.IncludeInATO = Conversions.ToBoolean(xmlNode_.InnerText);
						flag = true;
						break;
					case "RadarBehaviour":
						strike.RadarBehaviour = (_RadarBehaviour)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Escort_TransitAltitude":
					case "TAO":
						strike.Escort_TransitAltitude = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "UseGroupSizeHardLimit":
						strike.UseGroupSizeHardLimit = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "SISIH":
						strike.ScrubIfSideIsHuman = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Escort_TransitTerrainFollowing":
						strike.Escort_TransitTerrainFollowing = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TankerMinNumber_Airborne":
						strike.TankerMinNumber_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Escort_NumberOfBoats_Investigate":
						strike.Escort_NumberOfBoats_Investigate = (_GroupQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TankerMaxDistance_Airborne":
						strike.TankerMaxDistance_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "UseFlightplansOnly":
						strike.UsePreGeneratedFlightplansOnly = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "LaunchMissionWithoutTankersInPlace":
						strike.LaunchMissionWithoutTankersInPlace = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TimeOnTarget":
					{
						DateTime value4 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						strike.TimeOnTarget = value4;
						break;
					}
					case "EmptySlotsList":
						strike.EmptySlotsList = EmptyAircraftSlot.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
						break;
					case "TankerMinNumber_Total":
						strike.TankerMinNumber_Total = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Escort_GroupMemberEngageDistance":
						strike.Escort_GroupMemberEngageDistance = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "MinResponseRadius_Ship":
						strike.MinResponseRadius_Ship = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Doctrine_Escorts":
						strike.Doctrine_Escorts = Doctrine.FromXML(ref xmlNode_, strike);
						break;
					case "Escort_GroupSize":
						strike.Escort_GroupSize = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "HomeNavalbase":
						strike._SecondaryNavalBaseID = xmlNode_.InnerText;
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode_.InnerText))
						{
							strike.ObjectID_Set(xmlNode_.InnerText);
							concurrentDictionary_0.TryAdd(strike.ObjectID, strike);
							break;
						}
						return (Strike)concurrentDictionary_0[xmlNode_.InnerText];
					case "Doctrine":
						strike.Doctrine = Doctrine.FromXML(ref xmlNode_, strike);
						break;
					case "SpecificTargets":
						try
						{
							enumerator3 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode3 = (XmlNode)enumerator3.Current;
								if (Operators.CompareString(xmlNode3.Name, "Contact", TextCompare: false) == 0)
								{
									Contact item = Contact.FromXML(xmlNode3.InnerText, ref concurrentDictionary_0);
									strike.SpecificTargets.Add(item);
								}
								else
								{
									strike.m_SpecificationProxy.Add(xmlNode3.InnerText);
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
					case "Escort_TransitThrottle":
						strike.Escort_TransitThrottle = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TakeOffTime":
					{
						DateTime value3 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						strike.TakeOffTime = value3;
						break;
					}
					case "MaxResponseRadius_Ship":
						strike.MaxResponseRadius_Ship = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TankerMinNumber_Station":
						strike.TankerMinNumber_Station = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "UP":
						strike.UsePlanner = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "OAO":
					case "Escort_StationAltitude":
						strike.Escort_AttackAltitude = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "Escort_ResponseRadius_SEAD":
						strike.Escort_ResponseRadius_SEAD = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "FlightList":
						strike.FlightList = Flight.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
						break;
					case "PatrolThrottle":
					case "Escort_StationThrottle":
						strike.Escort_AttackThrottle = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "FuelQtyToStartLookingForTanker_Airborne":
						strike.FuelQtyToStartLookingForTanker_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "MCSTT":
					case "MinimumContactStanceToTrigger":
						strike.MinimumContactStanceToTrigger = (Misc.PostureStance)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "MaxFlightNumber_Strike":
					case "MaxAircraftToFly_Strikers":
						strike.MaxFlightNumber_Strike = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Escort_AttackTerrainFollowing":
						strike.Escort_AttackTerrainFollowing = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "FlightSize":
						strike.FlightSize = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TankerMissionList":
						try
						{
							enumerator4 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator4.Current;
								strike.TankerMissions_IDs.Add(xmlNode2.InnerText);
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
					case "HomeAirbase":
						strike._SecondaryAirBaseID = xmlNode_.InnerText;
						break;
					case "UseFlightSizeHardLimit":
						strike.UseFlightSizeHardLimit = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Escort_ResponseRadius":
						strike.Escort_ResponseRadius = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Category":
						strike.Category = (MissionCategory)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "END":
					{
						DateTime value2 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						strike._EndTime = value2;
						break;
					}
					case "Escort_FlightSize_NonShooter":
						strike.Escort_FlightSize_NonShooter = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "MinAircraftReq_Escorts":
					case "MinAircraftReq_Escorts_Shooter":
						strike.MinimumNumberOfAircraft_Escorts_Shooter = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Formation_Attack":
						strike.Formation_Attack = (_AircraftFormationType)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "MaxAircraftToFly_Escort":
					case "MaxAircraftToFly_Escort_Shooter":
						strike.MaximumNumberOfAircraft_Escorts_Shooter = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "SplitDistance":
						strike.SplitDistance = (_SplitDistance)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "PriorityWeight":
						strike.PriorityWeight = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Escort_NumberOfFlights_Engage":
						strike.Escort_NumberOfFlights_Engage = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "_Phase":
						strike._Phase = (MissionPhase)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Escort_Formation_Cruise":
						strike.Escort_Formation_Cruise = (_AircraftFormationType)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TargeteeringMethod":
						strike.TargeteeringMethod = (_TargeteeringMethod)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Escort_WingmanEngageDistance":
						strike.Escort_WingmanEngageDistance = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Escort_Formation_Attack":
						strike.Escort_Formation_Attack = (_AircraftFormationType)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "PrePlannedOnly":
						strike.RTB_When_Target_Destroyed = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Escort_FlightSize_Shooter":
					case "Escort_FlightSize_Preferred":
						strike.Escort_FlightSize_Shooter = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Escort_NumberOfFlights_Investigate":
						strike.Escort_NumberOfFlights_Investigate = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "MinAircraftReq_Escorts_NonShooter":
						strike.MinimumNumberOfAircraft_Escorts_NonShooter = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Type":
						if (Versioned.IsNumeric(xmlNode_.InnerText))
						{
							strike.Type = (StrikeType)Conversions.ToInteger(xmlNode_.InnerText);
						}
						else
						{
							strike.Type = (StrikeType)Enum.Parse(typeof(StrikeType), xmlNode_.InnerText, ignoreCase: true);
						}
						break;
					case "Escort_NumberOfBoats_Engage":
						strike.Escort_NumberOfBoats_Engage = (_GroupQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "MinAircraftReq_Strikers":
						strike.MinimumNumberOfAircraft = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "AssignedUnitsList":
						try
						{
							enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode = (XmlNode)enumerator2.Current;
								strike.UnitsAssignedToMissionIDs.Add(xmlNode.InnerText);
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
					case "OneTimeOnlyFlown":
						strike.OneTimeOnlyFlown = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Bingo":
						strike.BingoFuel = (_BingoFuelSetting)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "MinResponseRadius":
					case "MinResponseRadius_Aircraft":
						strike.MinResponseRadius_Aircraft = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TankerUsage":
						strike.TankerUsage = (TankerMethod)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "GroupSize":
						strike.GroupSize = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "MaxResponseRadius_Aircraft":
					case "MaxResponseRadius":
						strike.MaxResponseRadius_Aircraft = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TankerFollowsReceivers":
						strike.TankerFollowsReceivers = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Completion":
						strike.Completion = Conversions.ToSingle(xmlNode_.InnerText);
						break;
					case "Formation_Cruise":
						strike.Formation_Cruise = (_AircraftFormationType)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "UseGroupSizeHardLimit_Escort":
						strike.UseGroupSizeHardLimit_Escort = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "FocusEntirelyOnStrikeTargets":
						strike.FocusEntirelyOnStrikeTargets = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "MaxAircraftToFly_Escort_NonShooter":
						strike.MaximumNumberOfAircraft_Escorts_NonShooter = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "FlightPlanPreventShotgunRTB":
						strike.FlightPlanPreventShotgunRTB = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "AttackMethod":
						strike.AttackMethod = (_AttackMethod)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "MaxReceiversInQueuePerTanker_Airborne":
						strike.MaxReceiversInQueuePerTanker_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "UseFlightSizeHardLimit_Escort":
						strike.UseFlightSizeHardLimit_Escort = Conversions.ToBoolean(xmlNode_.InnerText);
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
			if (strike.FlightSize == 0 && strike.Type == StrikeType.Sub_Strike)
			{
				strike.Doctrine.SetWeaponControlStatus_Submarine(scenario_0, bool_0: false, null, bool_1: false, bool_2: false, Doctrine._WCS.Free);
			}
			if (strike.RadarBehaviour == _RadarBehaviour.None)
			{
				if (strike.TargetCount > 0 || strike.m_SpecificationProxy.Count > 0)
				{
					strike.RTB_When_Target_Destroyed = true;
				}
				strike.OneTimeOnly = false;
				strike.OneTimeOnlyFlown = false;
			}
			if (strike.RadarBehaviour == _RadarBehaviour.None)
			{
				if (strike.Type == StrikeType.Maritime_Strike)
				{
					strike.RadarBehaviour = _RadarBehaviour.ActiveOnAttackIngressAndIP;
				}
				else
				{
					strike.RadarBehaviour = _RadarBehaviour.UseMissionEMCON;
				}
			}
			if (strike.Escort_FlightSize_Shooter == 0)
			{
				strike.Escort_FlightSize_Shooter = 2;
				strike.Escort_FlightSize_NonShooter = 1;
				strike.Doctrine_Escorts.SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._WeaponStateRTB.YesLastUnit);
				strike.Doctrine_Escorts.EMCON_Inherits = false;
				strike.Doctrine_Escorts.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Active, scenario_0);
			}
			byte? b = (byte?)strike.Escort_TransitThrottle;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				strike.Escort_TransitThrottle = ActiveUnit.Throttle.Cruise;
			}
			b = (byte?)strike.Escort_AttackThrottle;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				strike.Escort_AttackThrottle = ActiveUnit.Throttle.Full;
			}
			if (strike.Escort_ResponseRadius == 0)
			{
				strike.Escort_ResponseRadius = 80;
			}
			if (strike.Escort_ResponseRadius_SEAD == 0)
			{
				strike.Escort_ResponseRadius_SEAD = 30;
			}
			if (strike.Doctrine.ReplenishmentSelection_Inherits())
			{
				strike.Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
			}
			if (!flag)
			{
				switch (strike.Type)
				{
				default:
					strike.IncludeInATO = true;
					break;
				case StrikeType.Sub_Strike:
					strike.IncludeInATO = false;
					break;
				case StrikeType.Air_Intercept:
					strike.IncludeInATO = false;
					break;
				}
			}
			if (strike.Escort_NumberOfFlights_Investigate == _FlightQty.NoPreferences)
			{
				strike.Escort_NumberOfFlights_Investigate = _FlightQty.Flight_x1;
				strike.Escort_NumberOfFlights_Engage = _FlightQty.All;
				strike.Escort_WingmanEngageDistance = 5;
				strike.Escort_NumberOfBoats_Investigate = _GroupQty.All;
				strike.Escort_NumberOfBoats_Engage = _GroupQty.All;
				strike.Escort_GroupMemberEngageDistance = 5;
			}
			return strike;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100648", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Strike result = new Strike(null, scenario_0, "");
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public override string GetDescriptionString(Scenario scenario_0)
	{
		StrikeType type = Type;
		if (1 == 0)
		{
		}
		string result = type switch
		{
			StrikeType.Air_Intercept => "空中拦截", 
			StrikeType.Land_Strike => "攻击地面目标", 
			StrikeType.Maritime_Strike => "海上攻击", 
			StrikeType.Sub_Strike => "攻击水下目标", 
			_ => throw new NotImplementedException(), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public Strike(Side side_0, Scenario scenario_0, string string_0, MissionCategory missionCategory_0, StrikeType strikeType_0)
		: base(side_0, scenario_0, string_0)
	{
		SpecificTargets = new HashSet<Module_Unit.Unit>();
		m_SpecificationProxy = new List<string>();
		List<ActiveUnit> list_ = null;
		Doctrine_Escorts = new Doctrine(this, ref list_);
		AttackMethod = _AttackMethod.Formation_SingleAim;
		SplitDistance = _SplitDistance.Typical_20nm;
		IsMission = true;
		MissionClass = _MissionClass.Strike;
		list_ = null;
		Doctrine_Escorts = new Doctrine(this, ref list_);
		Category = missionCategory_0;
		Type = strikeType_0;
		Name = string_0;
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
			Doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Passive, scenario_0);
			base.FlightSize = 4;
			IncludeInATO = true;
			break;
		case StrikeType.Sub_Strike:
			Doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Passive, scenario_0);
			Doctrine.SetWeaponControlStatus_Submarine(scenario_0, bool_0: false, null, bool_1: false, bool_2: false, value);
			base.FlightSize = 1;
			IncludeInATO = false;
			break;
		case StrikeType.Air_Intercept:
			Doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Active, scenario_0);
			base.FlightSize = 2;
			IncludeInATO = false;
			break;
		}
		GroupSize = 1;
		OneTimeOnly = false;
		OneTimeOnlyFlown = false;
		if (strikeType_0 == StrikeType.Maritime_Strike)
		{
			RadarBehaviour = _RadarBehaviour.ActiveOnAttackIngressAndIP;
		}
		else
		{
			RadarBehaviour = _RadarBehaviour.UseMissionEMCON;
		}
		Escort_FlightSize_Shooter = 2;
		Escort_FlightSize_NonShooter = 1;
		Escort_TransitThrottle = ActiveUnit.Throttle.Cruise;
		Escort_AttackThrottle = ActiveUnit.Throttle.Full;
		Escort_TransitTerrainFollowing = false;
		Escort_AttackTerrainFollowing = false;
		Escort_ResponseRadius = 80;
		Escort_ResponseRadius_SEAD = 30;
		Doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._WeaponStateRTB.YesLastUnit);
		Doctrine_Escorts.SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._WeaponStateRTB.YesLastUnit);
		Doctrine_Escorts.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Active, scenario_0);
		Doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
		Doctrine_Escorts.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
		Escort_NumberOfFlights_Investigate = _FlightQty.Flight_x1;
		Escort_NumberOfFlights_Engage = _FlightQty.All;
		Escort_WingmanEngageDistance = 5;
		Escort_NumberOfBoats_Investigate = _GroupQty.All;
		Escort_NumberOfBoats_Engage = _GroupQty.All;
		Escort_GroupMemberEngageDistance = 5;
		MinimumContactStanceToTrigger = Misc.PostureStance.Unknown;
		TargeteeringMethod = _TargeteeringMethod.Mission;
	}

	public override void PostDeserializationHousekeeping(ref Scenario scenario_0, Side side_0, bool bool_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		try
		{
			if (m_SpecificationProxy.Count > 0)
			{
				foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
				{
					if (activeUnits_ != null && m_SpecificationProxy.Contains(activeUnits_.ObjectID))
					{
						SpecificTargets.Add(activeUnits_);
						if (base.IsActive && side_0.GetConsidersThisSideToBe(activeUnits_.GetUnitSide()) != Misc.PostureStance.Hostile)
						{
							side_0.SetConsidersThisSideToBe(activeUnits_.GetUnitSide(), Misc.PostureStance.Hostile);
						}
					}
				}
				foreach (Contact contacts_ in side_0.Contacts_List)
				{
					if (m_SpecificationProxy.Contains(contacts_.ObjectID))
					{
						SpecificTargets.Add(contacts_);
						if (base.IsActive && contacts_.GetStance(side_0) != Misc.PostureStance.Hostile)
						{
							contacts_.SetStance(side_0, bool_0: false, Misc.PostureStance.Hostile);
						}
					}
				}
			}
			if (!string.IsNullOrEmpty(_SecondaryAirBaseID) && !concurrentDictionary_0.ContainsKey(_SecondaryAirBaseID))
			{
				SecondaryAirBase = (ActiveUnit)concurrentDictionary_0[_SecondaryAirBaseID];
			}
			if (!string.IsNullOrEmpty(_SecondaryNavalBaseID) && !concurrentDictionary_0.ContainsKey(_SecondaryNavalBaseID))
			{
				SecondaryNavalBase = (ActiveUnit)concurrentDictionary_0[_SecondaryNavalBaseID];
			}
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
			exception_?.Data.Add("Error at 100649", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void Printout(StringBuilder stringBuilder_0)
	{
		throw new NotImplementedException();
	}

	public override Mission Clone()
	{
		Strike obj = (Strike)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Name = "[克隆]" + Name;
		List<Module_Unit.Unit> collection = SpecificTargets.OrderBy((Module_Unit.Unit theUnit) => theUnit.Name).ToList();
		obj.SpecificTargets = new HashSet<Module_Unit.Unit>(collection);
		return obj;
	}
}
