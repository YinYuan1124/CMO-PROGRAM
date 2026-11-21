using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EscortMission : Mission
{
	public string EscortTargetMissionID;

	public string EscortTargetUnitID;

	public _FlightQty MinimumNumberOfAircraft;

	public ActiveUnit.Throttle? TransitThrottle;

	public ActiveUnit.Throttle? AttackThrottle_Aircraft;

	public float? TransitAltitude_Aircraft;

	public float? AttackAltitude_Aircraft;

	public bool TransitTerrainFollowing_Aircraft;

	public bool AttackTerrainFollowing_Aircraft;

	public _AircraftFormationType Formation_Cruise;

	public _AircraftFormationType Formation_Attack;

	public EscortMission(ref Side side_0, ref Scenario scenario_0, string string_0)
		: base(side_0, scenario_0, string_0)
	{
		IsMission = true;
		Name = string_0;
		MissionClass = _MissionClass.Escort;
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, ref Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Mission");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Name", Name);
			xmlWriter_0.WriteElementString("Category", ((byte)Category).ToString());
			Doctrine.ToXML(ref xmlWriter_0, ref scenario_0);
			xmlWriter_0.WriteElementString("SISIH", ScrubIfSideIsHuman.ToString());
			xmlWriter_0.WriteElementString("UseFlightplan", UseFlightplans.ToString());
			xmlWriter_0.WriteElementString("UseFlightplansOnly", UsePreGeneratedFlightplansOnly.ToString());
			xmlWriter_0.WriteElementString("ETMID", EscortTargetMissionID);
			if (GetStatus(scenario_0) != 0)
			{
				xmlWriter_0.WriteElementString("Status", ((byte)GetStatus(scenario_0)).ToString());
			}
			if (TransitThrottle.HasValue)
			{
				xmlWriter_0.WriteElementString("TransitThrottle_Aircraft", Conversions.ToString((int)TransitThrottle.Value));
			}
			if (AttackThrottle_Aircraft.HasValue)
			{
				xmlWriter_0.WriteElementString("StationThrottle_Aircraft", Conversions.ToString((int)AttackThrottle_Aircraft.Value));
			}
			if (TransitAltitude_Aircraft.HasValue)
			{
				xmlWriter_0.WriteElementString("TransitAltitude_Aircraft", TransitAltitude_Aircraft.Value.ToString());
			}
			if (AttackAltitude_Aircraft.HasValue)
			{
				xmlWriter_0.WriteElementString("StationAltitude_Aircraft", AttackAltitude_Aircraft.Value.ToString());
			}
			xmlWriter_0.WriteElementString("TransitTerrainFollowing_Aircraft", TransitTerrainFollowing_Aircraft.ToString());
			xmlWriter_0.WriteElementString("AttackTerrainFollowing_Aircraft", AttackTerrainFollowing_Aircraft.ToString());
			xmlWriter_0.WriteElementString("FlightSize", ((int)base.FlightSize).ToString());
			XmlWriter obj = xmlWriter_0;
			int formation_Cruise = (int)Formation_Cruise;
			obj.WriteElementString("Formation_Cruise", formation_Cruise.ToString());
			XmlWriter obj2 = xmlWriter_0;
			formation_Cruise = (int)Formation_Attack;
			obj2.WriteElementString("Formation_Attack", formation_Cruise.ToString());
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
			byte tankerUsage = (byte)TankerUsage;
			obj4.WriteElementString("TankerUsage", tankerUsage.ToString());
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
			exception_?.Data.Add("Error at 100631", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static EscortMission FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		EscortMission result = null;
		try
		{
			Side side_ = null;
			EscortMission escortMission = new EscortMission(ref side_, ref scenario_0, "");
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode_ = (XmlNode)enumerator.Current;
					switch (xmlNode_.Name)
					{
					case "TransitTerrainFollowing_Aircraft":
						escortMission.TransitTerrainFollowing_Aircraft = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Status":
						escortMission.SetStatus(scenario_0, (MissionStatus)Conversions.ToByte(xmlNode_.InnerText));
						break;
					case "UseFlightplan":
						escortMission.UseFlightplans = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Name":
						escortMission.Name = xmlNode_.InnerText;
						break;
					case "ETMID":
						escortMission.EscortTargetMissionID = xmlNode_.InnerText;
						break;
					case "SISIH":
						escortMission.ScrubIfSideIsHuman = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TankerMaxDistance_Airborne":
						escortMission.TankerMaxDistance_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TankerMinNumber_Airborne":
						escortMission.TankerMinNumber_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "UseFlightplansOnly":
						escortMission.UsePreGeneratedFlightplansOnly = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "LaunchMissionWithoutTankersInPlace":
						escortMission.LaunchMissionWithoutTankersInPlace = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "EmptySlotsList":
						escortMission.EmptySlotsList = EmptyAircraftSlot.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
						break;
					case "TankerMinNumber_Total":
						escortMission.TankerMinNumber_Total = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "AttackTerrainFollowing_Aircraft":
						escortMission.AttackTerrainFollowing_Aircraft = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TankerMinNumber_Station":
						escortMission.TankerMinNumber_Station = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode_.InnerText))
						{
							escortMission.ObjectID_Set(xmlNode_.InnerText);
							concurrentDictionary_0.TryAdd(escortMission.ObjectID, escortMission);
							break;
						}
						result = (EscortMission)concurrentDictionary_0[xmlNode_.InnerText];
						return result;
					case "Doctrine":
						escortMission.Doctrine = Doctrine.FromXML(ref xmlNode_, escortMission);
						break;
					case "FuelQtyToStartLookingForTanker_Airborne":
						escortMission.FuelQtyToStartLookingForTanker_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "FlightSize":
						escortMission.FlightSize = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TankerMissionList":
						try
						{
							enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode = (XmlNode)enumerator2.Current;
								escortMission.TankerMissions_IDs.Add(xmlNode.InnerText);
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
					case "UseFlightSizeHardLimit":
						escortMission.UseFlightSizeHardLimit = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "AttackThrottle":
					case "AttackThrottle_Aircraft":
						escortMission.AttackThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Formation_Attack":
						escortMission.Formation_Attack = (_AircraftFormationType)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Category":
						escortMission.Category = (MissionCategory)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "AttackAltitude_Aircraft":
					case "AttackAltitude":
						escortMission.AttackAltitude_Aircraft = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "TankerFollowsReceivers":
						escortMission.TankerFollowsReceivers = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TankerUsage":
						escortMission.TankerUsage = (TankerMethod)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TransitAltitude":
					case "TransitAltitude_Aircraft":
						escortMission.TransitAltitude_Aircraft = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "MinAircraftReq":
						escortMission.MinimumNumberOfAircraft = (_FlightQty)Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "TransitThrottle":
					case "TransitThrottle_Aircraft":
						escortMission.TransitThrottle = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "MaxReceiversInQueuePerTanker_Airborne":
						escortMission.MaxReceiversInQueuePerTanker_Airborne = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Formation_Cruise":
						escortMission.Formation_Cruise = (_AircraftFormationType)Conversions.ToInteger(xmlNode_.InnerText);
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
			result = escortMission;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100632", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override void Printout(StringBuilder stringBuilder_0)
	{
		throw new NotImplementedException();
	}

	public override Mission Clone()
	{
		EscortMission obj = (EscortMission)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Name = "[克隆]" + Name;
		return obj;
	}
}
