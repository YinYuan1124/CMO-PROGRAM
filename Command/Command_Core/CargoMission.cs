using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class CargoMission : Mission
{
	public enum CargoMissionType : byte
	{
		Delivery,
		Transfer
	}

	public List<ReferencePoint> Area;

	public List<ReferencePoint> Area_30nm_ChangeCheck;

	public List<ReferencePoint> Area_30nm_Buffered;

	public List<ReferencePoint> Area_1nm_Buffered;

	public List<ReferencePoint> Area_1nm_ChangeCheck;

	public TransportWave TransportWaveManifest;

	public List<CargoManifestItem> CargoToUnload;

	public bool InstantLoadingForNextManifest;

	public float TransitAltitude_Aircraft;

	public float StationAltitude_Aircraft;

	public ActiveUnit.Throttle TransitThrottle_Aircraft;

	public ActiveUnit.Throttle StationThrottle_Aircraft;

	public ActiveUnit.Throttle TransitThrottle_Ship;

	public ActiveUnit.Throttle StationThrottle_Ship;

	public bool RTBUponCompletion;

	public bool _IsFulfilled;

	public CargoMissionType Type;

	public ActiveUnit DestinationUnit;

	public bool MoveAllCargo;

	public bool AllowSelfDeliveryFromCargo;

	public bool AllowAllSelfDelivery;

	public bool UnpackAllContainers;

	private string m_ServiceObserver;

	private List<ActiveUnit> m_SystemObserver;

	public override bool IsFulfilled()
	{
		int num = 0;
		foreach (CargoManifestItem item in CargoToUnload)
		{
			num += item.quantity;
		}
		if (num == 0)
		{
			if (UnitsAssignedToMission.Count == 0)
			{
				return true;
			}
			foreach (KeyValuePair<ActiveUnit, ActiveUnit> item2 in UnitsAssignedToMission)
			{
				if (item2.Value.HasCargo)
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	public static bool IsValidDestinationUnit(Module_Unit.Unit unit_0, bool bool_0 = false)
	{
		if (unit_0 != null && unit_0.IsActiveUnit)
		{
			ActiveUnit activeUnit = (ActiveUnit)unit_0;
			if (bool_0 || activeUnit.GetUnitSide() == activeUnit.ParentScen.GetCurrentSide())
			{
				if (activeUnit.IsGroup)
				{
					Group group = (Group)activeUnit;
					Group.GroupType type = group.Type;
					if (type == Group.GroupType.Installation || (int)(type - 5) <= 1)
					{
						return group.StartInvocation();
					}
				}
				else if (activeUnit.IsFixedFacility || activeUnit.IsShip)
				{
					return activeUnit is ICargoHost;
				}
			}
		}
		return false;
	}

	[SpecialName]
	public List<ActiveUnit> GetAssignedUnits_Cached(Scenario scenario_0)
	{
		if (m_SystemObserver == null)
		{
			m_SystemObserver = Module_Mission.AssetTokenizer(this, scenario_0);
		}
		return m_SystemObserver;
	}

	public override void PrePulseHousekeeping(Scenario scenario_0)
	{
		m_SystemObserver = null;
	}

	public override void Printout(StringBuilder stringBuilder_0)
	{
		throw new NotImplementedException();
	}

	[SpecialName]
	public override string GetDescriptionString(Scenario scenario_0)
	{
		return "Cargo";
	}

	public CargoMission(Side side_0, Scenario scenario_0, string string_0, MissionCategory missionCategory_0, List<ReferencePoint> list_0, bool bool_0, ActiveUnit activeUnit_0 = null, bool bool_1 = false, bool bool_2 = false, bool bool_3 = false, bool bool_4 = false)
		: base(side_0, scenario_0, string_0)
	{
		Area = new List<ReferencePoint>();
		Area_30nm_ChangeCheck = new List<ReferencePoint>();
		Area_30nm_Buffered = new List<ReferencePoint>();
		Area_1nm_Buffered = new List<ReferencePoint>();
		Area_1nm_ChangeCheck = new List<ReferencePoint>();
		CargoToUnload = new List<CargoManifestItem>();
		RTBUponCompletion = true;
		Type = CargoMissionType.Delivery;
		DestinationUnit = null;
		MoveAllCargo = false;
		AllowSelfDeliveryFromCargo = false;
		AllowAllSelfDelivery = false;
		UnpackAllContainers = false;
		MissionClass = _MissionClass.Cargo;
		Name = string_0;
		Area = list_0;
		DestinationUnit = activeUnit_0;
		AllowSelfDeliveryFromCargo = bool_1;
		if (AllowSelfDeliveryFromCargo)
		{
			AllowAllSelfDelivery = bool_3;
		}
		UnpackAllContainers = bool_4;
		MoveAllCargo = bool_2;
		TransitAltitude_Aircraft = 609.60004f;
		StationAltitude_Aircraft = 304.80002f;
		TransitThrottle_Aircraft = ActiveUnit.Throttle.Cruise;
		StationThrottle_Aircraft = ActiveUnit.Throttle.Flank;
		TransitThrottle_Ship = ActiveUnit.Throttle.Cruise;
		StationThrottle_Ship = ActiveUnit.Throttle.Cruise;
		if (DestinationUnit != null)
		{
			Type = CargoMissionType.Transfer;
			TransitAltitude_Aircraft = 0f;
			StationAltitude_Aircraft = 0f;
		}
		string string_ = null;
		if (bool_0 && !ActiveUnit_Navigator.ValidateArea(ref Area, ref string_, side_0, scenario_0, "货物任务'" + Name + "'"))
		{
			GameGeneral.ResolveBridge(string_, side_0);
		}
		Category = missionCategory_0;
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, ref Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("CargoMission");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Name", Name);
			method_0(ref xmlWriter_0, ref hashSet_0, ref scenario_0);
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
			XmlWriter obj = xmlWriter_0;
			byte transitThrottle_Aircraft = (byte)TransitThrottle_Aircraft;
			obj.WriteElementString("TransitThrottle_Aircraft", transitThrottle_Aircraft.ToString());
			XmlWriter obj2 = xmlWriter_0;
			transitThrottle_Aircraft = (byte)StationThrottle_Aircraft;
			obj2.WriteElementString("StationThrottle_Aircraft", transitThrottle_Aircraft.ToString());
			xmlWriter_0.WriteElementString("TransitAltitude_Aircraft", TransitAltitude_Aircraft.ToString());
			xmlWriter_0.WriteElementString("StationAltitude_Aircraft", StationAltitude_Aircraft.ToString());
			XmlWriter obj3 = xmlWriter_0;
			transitThrottle_Aircraft = (byte)TransitThrottle_Ship;
			obj3.WriteElementString("TransitThrottle_Ship", transitThrottle_Aircraft.ToString());
			XmlWriter obj4 = xmlWriter_0;
			transitThrottle_Aircraft = (byte)StationThrottle_Ship;
			obj4.WriteElementString("StationThrottle_Ship", transitThrottle_Aircraft.ToString());
			xmlWriter_0.WriteElementString("UseFlightplan", UseFlightplans.ToString());
			xmlWriter_0.WriteElementString("UseFlightplansOnly", UsePreGeneratedFlightplansOnly.ToString());
			if (SecondaryAirBase != null)
			{
				xmlWriter_0.WriteElementString("HomeAirbase", SecondaryAirBase.ObjectID.ToString());
			}
			if (SecondaryNavalBase != null)
			{
				xmlWriter_0.WriteElementString("HomeNavalbase", SecondaryNavalBase.ObjectID.ToString());
			}
			Doctrine.ToXML(ref xmlWriter_0, ref scenario_0);
			if (Area.Count > 0)
			{
				xmlWriter_0.WriteStartElement("Area");
				foreach (ReferencePoint item in Area)
				{
					xmlWriter_0.WriteRaw(item.ToXML(ref hashSet_0));
				}
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteElementString("SISIH", ScrubIfSideIsHuman.ToString());
			xmlWriter_0.WriteStartElement("MountsToUnload");
			foreach (CargoManifestItem item2 in CargoToUnload)
			{
				switch (item2.objectType)
				{
				case Cargo.CargoObjectType.Mount:
					xmlWriter_0.WriteStartElement("Mount");
					break;
				case Cargo.CargoObjectType.Vehicle:
					xmlWriter_0.WriteStartElement("Vehicle");
					break;
				case Cargo.CargoObjectType.Facility:
					xmlWriter_0.WriteStartElement("Facility");
					break;
				case Cargo.CargoObjectType.CargoContainer:
					xmlWriter_0.WriteStartElement("Container");
					xmlWriter_0.WriteAttributeString("Name", item2.Name);
					break;
				}
				xmlWriter_0.WriteAttributeString("DBID", item2.DBID.ToString());
				if (!string.IsNullOrEmpty(item2.ObjectID))
				{
					xmlWriter_0.WriteAttributeString("ObjectID", item2.ObjectID);
				}
				xmlWriter_0.WriteString(item2.quantity.ToString());
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteEndElement();
			if (GetStatus(scenario_0) != 0)
			{
				xmlWriter_0.WriteElementString("Status", ((byte)GetStatus(scenario_0)).ToString());
			}
			xmlWriter_0.WriteElementString("RTBUponCompletion", RTBUponCompletion.ToString());
			if (Type != 0)
			{
				XmlWriter obj5 = xmlWriter_0;
				transitThrottle_Aircraft = (byte)Type;
				obj5.WriteElementString("CargoMissionType", transitThrottle_Aircraft.ToString());
			}
			if (DestinationUnit != null)
			{
				xmlWriter_0.WriteElementString("DestinationUnit", DestinationUnit.ObjectID);
			}
			if (AllowSelfDeliveryFromCargo)
			{
				xmlWriter_0.WriteElementString("ASD", ((byte)(-(AllowSelfDeliveryFromCargo ? 1 : 0))).ToString());
			}
			if (AllowAllSelfDelivery)
			{
				xmlWriter_0.WriteElementString("AASD", ((byte)(-(AllowAllSelfDelivery ? 1 : 0))).ToString());
			}
			if (MoveAllCargo)
			{
				xmlWriter_0.WriteElementString("MAC", ((byte)(-(MoveAllCargo ? 1 : 0))).ToString());
			}
			if (UnpackAllContainers)
			{
				xmlWriter_0.WriteElementString("UAC", ((byte)(-(UnpackAllContainers ? 1 : 0))).ToString());
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200654", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private CargoMission(Side side_0, Scenario scenario_0, string string_0)
		: base(side_0, scenario_0, string_0)
	{
		Area = new List<ReferencePoint>();
		Area_30nm_ChangeCheck = new List<ReferencePoint>();
		Area_30nm_Buffered = new List<ReferencePoint>();
		Area_1nm_Buffered = new List<ReferencePoint>();
		Area_1nm_ChangeCheck = new List<ReferencePoint>();
		CargoToUnload = new List<CargoManifestItem>();
		RTBUponCompletion = true;
		Type = CargoMissionType.Delivery;
		DestinationUnit = null;
		MoveAllCargo = false;
		AllowSelfDeliveryFromCargo = false;
		AllowAllSelfDelivery = false;
		UnpackAllContainers = false;
		MissionClass = _MissionClass.Cargo;
	}

	public new static CargoMission FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		CargoMission result = null;
		try
		{
			CargoMission cargoMission = new CargoMission(null, scenario_0, "");
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
					Mission.FromXMLCommon(cargoMission, xmlNode_);
					switch (xmlNode_.Name)
					{
					case "START":
					{
						DateTime value2 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						cargoMission._StartTime = value2;
						break;
					}
					case "Status":
						cargoMission.SetStatus(scenario_0, (MissionStatus)Conversions.ToByte(xmlNode_.InnerText));
						break;
					case "UseFlightplan":
						cargoMission.UseFlightplans = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "Name":
						cargoMission.Name = xmlNode_.InnerText;
						break;
					case "Area":
						try
						{
							enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator2.Current;
								cargoMission.Area.Add(ReferencePoint.FromXML(ref xmlNode_2, ref concurrentDictionary_0));
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
						cargoMission.ScrubIfSideIsHuman = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "TransitThrottle_Ship":
						cargoMission.TransitThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "CargoMissionType":
						cargoMission.Type = (CargoMissionType)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "UseFlightplansOnly":
						cargoMission.UsePreGeneratedFlightplansOnly = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "MAC":
						cargoMission.MoveAllCargo = true;
						break;
					case "StationThrottle_Ship":
						cargoMission.StationThrottle_Ship = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TimeOnTarget":
					{
						DateTime value4 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						cargoMission.TimeOnTarget = value4;
						break;
					}
					case "Doctrine":
						cargoMission.Doctrine = Doctrine.FromXML(ref xmlNode_, cargoMission);
						break;
					case "HomeNavalbase":
						cargoMission._SecondaryNavalBaseID = xmlNode_.InnerText;
						break;
					case "TakeOffTime":
					{
						DateTime value3 = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						cargoMission.TakeOffTime = value3;
						break;
					}
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode_.InnerText))
						{
							cargoMission.ObjectID_Set(xmlNode_.InnerText);
							concurrentDictionary_0.TryAdd(cargoMission.ObjectID, cargoMission);
							break;
						}
						result = (CargoMission)concurrentDictionary_0[xmlNode_.InnerText];
						return result;
					case "ASD":
						cargoMission.AllowSelfDeliveryFromCargo = true;
						break;
					case "AASD":
						cargoMission.AllowAllSelfDelivery = true;
						break;
					case "RTBUponCompletion":
						cargoMission.RTBUponCompletion = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "MountsToUnload":
						try
						{
							enumerator4 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								XmlNode xmlNode2 = (XmlNode)enumerator4.Current;
								int int_ = int.Parse(xmlNode2.Attributes.GetNamedItem("DBID").Value);
								CargoManifestItem cargoManifestItem = null;
								string string_ = "";
								string text = "";
								if (xmlNode2.Attributes.GetNamedItem("ObjectID") != null)
								{
									string_ = xmlNode2.Attributes.GetNamedItem("ObjectID").Value;
								}
								if (xmlNode2.Attributes.GetNamedItem("Name") != null)
								{
									text = xmlNode2.Attributes.GetNamedItem("Name").Value;
								}
								switch (xmlNode2.Name)
								{
								case "Vehicle":
									cargoManifestItem = new CargoManifestItem(Cargo.CargoObjectType.Vehicle, int_, string_);
									break;
								case "Mount":
									cargoManifestItem = new CargoManifestItem(Cargo.CargoObjectType.Mount, int_);
									break;
								case "Facility":
									cargoManifestItem = new CargoManifestItem(Cargo.CargoObjectType.Facility, int_, string_);
									break;
								case "Container":
									cargoManifestItem = new CargoManifestItem(Cargo.CargoObjectType.CargoContainer, int_, string_);
									break;
								}
								if (cargoManifestItem != null)
								{
									cargoManifestItem.quantity = int.Parse(xmlNode2.InnerText);
									if (string.IsNullOrEmpty(text))
									{
										cargoManifestItem.GenerateName(scenario_0);
									}
									else
									{
										cargoManifestItem._Name = text;
									}
									cargoMission.CargoToUnload.Add(cargoManifestItem);
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
					case "UAC":
						cargoMission.UnpackAllContainers = true;
						break;
					case "HomeAirbase":
						cargoMission._SecondaryAirBaseID = xmlNode_.InnerText;
						break;
					case "DestinationUnit":
						cargoMission.m_ServiceObserver = xmlNode_.InnerText;
						break;
					case "END":
					{
						DateTime value = DateTime.FromBinary(Conversions.ToLong(xmlNode_.InnerText));
						cargoMission._EndTime = value;
						break;
					}
					case "_Phase":
						cargoMission._Phase = (MissionPhase)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "PriorityWeight":
						cargoMission.PriorityWeight = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "StationAltitude_Aircraft":
						cargoMission.StationAltitude_Aircraft = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "AssignedUnitsList":
						try
						{
							enumerator3 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode = (XmlNode)enumerator3.Current;
								cargoMission.UnitsAssignedToMissionIDs.Add(xmlNode.InnerText);
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
					case "TransitAltitude_Aircraft":
						cargoMission.TransitAltitude_Aircraft = XmlConvert.ToSingle(xmlNode_.InnerText.Replace(",", "."));
						break;
					case "StationThrottle_Aircraft":
						cargoMission.StationThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "TransitThrottle_Aircraft":
						cargoMission.TransitThrottle_Aircraft = (ActiveUnit.Throttle)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Completion":
						cargoMission.Completion = Conversions.ToSingle(xmlNode_.InnerText);
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
			if (cargoMission.TransitThrottle_Aircraft == ActiveUnit.Throttle.FullStop)
			{
				cargoMission.TransitThrottle_Aircraft = ActiveUnit.Throttle.Cruise;
			}
			if (cargoMission.StationThrottle_Aircraft == ActiveUnit.Throttle.FullStop)
			{
				cargoMission.StationThrottle_Aircraft = ActiveUnit.Throttle.Cruise;
			}
			if (cargoMission.TransitThrottle_Ship == ActiveUnit.Throttle.FullStop)
			{
				cargoMission.TransitThrottle_Ship = ActiveUnit.Throttle.Cruise;
			}
			if (cargoMission.StationThrottle_Ship == ActiveUnit.Throttle.FullStop)
			{
				cargoMission.StationThrottle_Ship = ActiveUnit.Throttle.Cruise;
			}
			result = cargoMission;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200656", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override void PostDeserializationHousekeeping(ref Scenario scenario_0, Side side_0, bool bool_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		try
		{
			base.PostDeserializationHousekeeping(ref scenario_0, side_0, bool_0, ref concurrentDictionary_0);
			if (!string.IsNullOrEmpty(m_ServiceObserver))
			{
				DestinationUnit = scenario_0.ActiveUnits[m_ServiceObserver];
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200657", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override Mission Clone()
	{
		CargoMission cargoMission = (CargoMission)MemberwiseClone();
		cargoMission.ObjectID_Set(Guid.NewGuid().ToString());
		cargoMission.Name = "[克隆]" + Name;
		if (Area.Count > 0)
		{
			cargoMission.Area = new ReferencePoint().ExcludeWriter(ref Area);
		}
		if (DestinationUnit != null)
		{
			cargoMission.DestinationUnit = DestinationUnit;
		}
		cargoMission.MoveAllCargo = MoveAllCargo;
		cargoMission.AllowSelfDeliveryFromCargo = AllowSelfDeliveryFromCargo;
		cargoMission.AllowAllSelfDelivery = AllowAllSelfDelivery;
		cargoMission.CargoToUnload.Clear();
		return cargoMission;
	}
}
