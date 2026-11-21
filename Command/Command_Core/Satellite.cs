using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Satellite : Platform
{
	public enum _SatelliteCategory
	{
		None = 1001,
		GeoStationary = 2001
	}

	public enum _SatelliteType
	{
		None = 1001,
		IMGSAT = 2001,
		RORSAT = 2002,
		EORSAT = 2003,
		SIGINT = 2004,
		ELINT = 2005,
		NOSS = 2006,
		MASINT = 2007
	}

	public class SatelliteOrbitAnchor
	{
		public double Longitude;

		public double Latitude;

		public float Altitude;
	}

	public string SpacecraftID;

	public DateTime LaunchDate;

	public DateTime DeOrbitDate;

	public _SatelliteCategory Category;

	public _SatelliteType Type;

	public GlobalVariables.ArmorRating Armor;

	public double WeightEmpty;

	public double WeightMax;

	public double WeightPayload;

	public float Span;

	public float Height;

	public float DamagePoints;

	public SatelliteOrbitAnchor OrbitAnchor;

	private Satellite_Kinematics expressionFacade;

	private Satellite_Damage dispatcherFacade;

	private bool _ListenerFacade;

	private MathFunctions.Vector m_ConfigFacade;

	public override bool RepresentsMobileGroundUnit => false;

	public MathFunctions.Vector PositionVector
	{
		get
		{
			if (!_ListenerFacade)
			{
				double double_ = 6371.0 + (double)GetCurrentAltitude() / 1000.0;
				m_ConfigFacade = MathFunctions.Vector.FromSpherical(double_, GetLongitude() * 0.0174532925199433, GetLatitude() * 0.0174532925199433);
				_ListenerFacade = true;
			}
			return m_ConfigFacade;
		}
	}

	public new Satellite_Kinematics Kinematics => expressionFacade;

	public new Satellite_Damage Damage
	{
		get
		{
			if (dispatcherFacade == null)
			{
				ActiveUnit activeUnit_ = this;
				dispatcherFacade = new Satellite_Damage(ref activeUnit_);
			}
			return dispatcherFacade;
		}
	}

	public override float FlatSurfaceArea_m2 => Length * Span;

	public bool IsGEO
	{
		get
		{
			if (Kinematics.Apogee < 40000000 && Kinematics.Perigee > 30000000)
			{
				return true;
			}
			return false;
		}
	}

	public override string AnnexAndDBID => "卫星_" + Conversions.ToString(DBID);

	public override bool IsPlatform => true;

	public override GlobalVariables.ActiveUnitType UnitType => GlobalVariables.ActiveUnitType.Satellite;

	public void InvalidatePositionVector()
	{
		_ListenerFacade = false;
	}

	public override void Teleport(ref Scenario scenario_0, double double_0, double double_1)
	{
		base.Teleport(ref scenario_0, double_0, double_1);
		Kinematics.ExportLocationEvent(bool_0: true);
	}

	public Satellite(ref Scenario scenario_0, string string_0 = null)
		: base(ref scenario_0, string_0)
	{
		ActiveUnit activeUnit_ = this;
		expressionFacade = new Satellite_Kinematics(ref activeUnit_);
		_ListenerFacade = false;
		IsSatellite = true;
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		if (Information.IsNothing(GetUnitSide()))
		{
			return;
		}
		try
		{
			xmlWriter_0.WriteStartElement("Satellite");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			if (hashSet_0.Contains(ObjectID))
			{
				xmlWriter_0.WriteEndElement();
				return;
			}
			hashSet_0.Add(ObjectID);
			method_0(ref xmlWriter_0);
			xmlWriter_0.WriteElementString("Name", Name.Replace("\0", "").Replace("\u0010", ""));
			if (ChanceOfAppearance != 0)
			{
				xmlWriter_0.WriteElementString("COA", Conversions.ToString(ChanceOfAppearance));
			}
			xmlWriter_0.WriteElementString("SID", SpacecraftID);
			xmlWriter_0.WriteElementString("Side", GetUnitSide().Name);
			if (!string.IsNullOrEmpty(Message))
			{
				xmlWriter_0.WriteElementString("Message", Message);
			}
			if (Longitude__UnitEntersAreaCheck.HasValue)
			{
				xmlWriter_0.WriteElementString("Longitude_UnitEntersAreaCheck", XmlConvert.ToString(Longitude__UnitEntersAreaCheck.Value));
			}
			if (Latitude__UnitEntersAreaCheck.HasValue)
			{
				xmlWriter_0.WriteElementString("Latitude_UnitEntersAreaCheck", XmlConvert.ToString(Latitude__UnitEntersAreaCheck.Value));
			}
			if (ActiveEnterAreaTriggers.Count > 0)
			{
				xmlWriter_0.WriteStartElement("ActiveEnterAreaTriggers");
				foreach (string activeEnterAreaTrigger in ActiveEnterAreaTriggers)
				{
					xmlWriter_0.WriteElementString("ActiveEnterAreaTrigger", activeEnterAreaTrigger);
				}
				xmlWriter_0.WriteEndElement();
			}
			if (ActiveRemainAreaTriggers.Count > 0)
			{
				xmlWriter_0.WriteStartElement("ActiveRemainAreaTriggers");
				foreach (KeyValuePair<string, DateTime> activeRemainAreaTrigger in ActiveRemainAreaTriggers)
				{
					xmlWriter_0.WriteElementString("RemainAreaTrigger", activeRemainAreaTrigger.Key.ToString());
					xmlWriter_0.WriteElementString("RemainAreaStartTime", activeRemainAreaTrigger.Value.ToBinary().ToString());
				}
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteElementString("DBID", DBID.ToString());
			if (!Information.IsNothing(OrbitAnchor))
			{
				xmlWriter_0.WriteStartElement("Anchor");
				xmlWriter_0.WriteElementString("Lon", XmlConvert.ToString(OrbitAnchor.Longitude));
				xmlWriter_0.WriteElementString("Lat", XmlConvert.ToString(OrbitAnchor.Latitude));
				xmlWriter_0.WriteElementString("Alt", XmlConvert.ToString(OrbitAnchor.Altitude));
				xmlWriter_0.WriteEndElement();
			}
			if (_Sensors.Length != 0)
			{
				xmlWriter_0.WriteStartElement("Sensors");
				Sensor[] sensors = _Sensors;
				Sensor[] array = sensors;
				foreach (Sensor sensor in array)
				{
					xmlWriter_0.WriteRaw(sensor.ToXML(hashSet_0));
				}
				xmlWriter_0.WriteEndElement();
			}
			if (Comms_ReadOnly.Length != 0)
			{
				xmlWriter_0.WriteStartElement("Comms");
				CommDevice[] comms = _Comms;
				CommDevice[] array2 = comms;
				foreach (CommDevice commDevice in array2)
				{
					xmlWriter_0.WriteRaw(commDevice.ToXML(ref hashSet_0));
				}
				xmlWriter_0.WriteEndElement();
			}
			if (Mounts.Count > 0)
			{
				xmlWriter_0.WriteStartElement("Mounts");
				foreach (Mount mount in Mounts)
				{
					xmlWriter_0.WriteRaw(mount.ToXML(ref hashSet_0, ParentScen));
				}
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteElementString("Status", ((byte)Status).ToString());
			if (AssignedMissionOrPackage() != null)
			{
				xmlWriter_0.WriteElementString("AssignedMission", _AssignedMissionOrPackage.ObjectID);
			}
			if (!Information.IsNothing(AssignedTaskPool))
			{
				xmlWriter_0.WriteElementString("AssignedTaskPool", _AssignedTaskPool.ObjectID);
			}
			if (!Information.IsNothing(GetParentGroup()))
			{
				xmlWriter_0.WriteElementString("ParentGroup", _ParentGroup.ObjectID);
			}
			if (GetIsAutoDetectable(null))
			{
				xmlWriter_0.WriteElementString("IsAD", GetIsAutoDetectable(null).ToString());
			}
			Doctrine.ToXML(ref xmlWriter_0, ref ParentScen);
			xmlWriter_0.WriteStartElement("ActiveUnit_AI");
			AI.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteEndElement();
			Sensory.ToXML(ref xmlWriter_0);
			xmlWriter_0.WriteStartElement("ActiveUnit_CommStuff");
			CommStuff.ToXML(ref xmlWriter_0, ref hashSet_0);
			xmlWriter_0.WriteEndElement();
			if (HasCustomOODA)
			{
				xmlWriter_0.WriteElementString("OODA_D", m_TokenVal.ToString());
				xmlWriter_0.WriteElementString("OODA_T", _IndexerVal.ToString());
				xmlWriter_0.WriteElementString("OODA_E", _ResolverVal.ToString());
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100753", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Satellite FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		Satellite satellite = null;
		try
		{
			satellite = EnableWriter(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0, scenario_0.LoadStockUnits);
			return satellite;
		}
		catch (PlatformComponentNotFoundException projectError)
		{
			ProjectData.SetProjectError(projectError);
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			ConcurrentDictionary<string, ScenarioObject> obj = concurrentDictionary_0;
			ScenarioObject value = satellite;
			obj.TryRemove(innerText, out value);
			satellite = EnableWriter(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0, bool_0: true);
			string text = "";
			if (satellite.IsGroupMember())
			{
				text = "(member of group: [" + satellite.GetParentGroup().Name + "])";
			}
			scenario_0.LoadingNotices.Add("The following satellite:[" + satellite.Name + "]" + text + " failed to shallow-rebuild because of a component missing. The satellite was instead deep-rebuilt, and instantiated in its pristine DB-stock condition. All customizations present in the satellite's components (damaged components, weapon additions/removals etc. etc.) have been lost. Please re-apply any necessary customizations either manually or using an SBR script.");
			ProjectData.ClearProjectError();
			return satellite;
		}
	}

	private static Satellite EnableWriter(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0, bool bool_0)
	{
		try
		{
			Satellite satellite_ = new Satellite(ref scenario_0);
			satellite_.ParentScen = scenario_0;
			string text = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (Misc.CreateRequest(text, ' '))
			{
				text = text.Replace(" ", "-");
			}
			if (concurrentDictionary_0.ContainsKey(text))
			{
				return (Satellite)concurrentDictionary_0[text];
			}
			satellite_.ObjectID_Set(text);
			if (xmlNode_0.ChildNodes.Count == 1)
			{
				scenario_0.UnitsForLateInstantiation.Add(xmlNode_0);
				return satellite_;
			}
			concurrentDictionary_0.TryAdd(satellite_.ObjectID, satellite_);
			int num = Conversions.ToInteger(Misc.StartRequest(xmlNode_0.ChildNodes, "DBID").InnerText);
			int int_ = Conversions.ToInteger(Misc.StartRequest(xmlNode_0.ChildNodes, "SID").InnerText.Split('_')[1]);
			try
			{
				DBFunctions.GetSatellite(ref scenario_0, ref satellite_, num, int_, bool_0);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ConcurrentDictionary<string, ScenarioObject> obj = concurrentDictionary_0;
				string objectID = satellite_.ObjectID;
				ScenarioObject value = satellite_;
				obj.TryRemove(objectID, out value);
				scenario_0.LoadingNotices.Add("具有数据库ID的卫星" + Conversions.ToString(num) + "在数据库中缺少因此未能加载。");
				ProjectData.ClearProjectError();
				return null;
			}
			if (bool_0)
			{
				satellite_.RegisterIssuer(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0);
			}
			if (!bool_0)
			{
				IEnumerator enumerator = null;
				try
				{
					enumerator = xmlNode_0.ChildNodes.GetEnumerator();
					IEnumerator enumerator2 = null;
					IEnumerator enumerator3 = null;
					IEnumerator enumerator4 = null;
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode = (XmlNode)enumerator.Current;
						satellite_.CommonFromXML(xmlNode);
						switch (xmlNode.Name)
						{
						case "Sensors":
							try
							{
								enumerator4 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator4.MoveNext())
								{
									Sensor sensor = Sensor.FromXML((XmlNode)enumerator4.Current, concurrentDictionary_0, satellite_);
									if (!sensor.m_IsMk1Eyeball)
									{
										ArrayExtensions.Add(ref satellite_._Sensors, sensor);
										sensor.ParentPlatform = satellite_;
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
						case "Mounts":
							try
							{
								enumerator3 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator3.MoveNext())
								{
									XmlNode xmlNode_2 = (XmlNode)enumerator3.Current;
									Mount mount = Mount.FromXML(ref xmlNode_2, ref concurrentDictionary_0, satellite_);
									satellite_.Mounts.Add(mount);
									mount.ParentPlatform = satellite_;
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
						case "Comms":
							try
							{
								enumerator2 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
									CommDevice commDevice = CommDevice.FromXML(ref xmlNode_, ref concurrentDictionary_0, satellite_);
									satellite_.AddCommDevice(commDevice);
									commDevice.ParentPlatform = satellite_;
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
			}
			IEnumerator enumerator5 = null;
			try
			{
				enumerator5 = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator6 = null;
				IEnumerator enumerator7 = null;
				IEnumerator enumerator8 = null;
				while (enumerator5.MoveNext())
				{
					XmlNode xmlNode_3 = (XmlNode)enumerator5.Current;
					switch (xmlNode_3.Name)
					{
					case "Name":
						satellite_.Name = xmlNode_3.InnerText;
						break;
					case "Status":
						if (Versioned.IsNumeric(xmlNode_3.InnerText))
						{
							satellite_.Status = (_ActiveUnitStatus)Conversions.ToByte(xmlNode_3.InnerText);
						}
						else
						{
							satellite_.Status = (_ActiveUnitStatus)Enum.Parse(typeof(_ActiveUnitStatus), xmlNode_3.InnerText, ignoreCase: true);
						}
						if (satellite_.Status == (_ActiveUnitStatus)9)
						{
							satellite_.Status = _ActiveUnitStatus.RTB;
						}
						break;
					case "ActiveEnterAreaTriggers":
						try
						{
							enumerator6 = xmlNode_3.ChildNodes.GetEnumerator();
							while (enumerator6.MoveNext())
							{
								string innerText2 = ((XmlNode)enumerator6.Current).InnerText;
								satellite_.ActiveEnterAreaTriggers.Add(innerText2);
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
					case "COA":
						satellite_.ChanceOfAppearance = Conversions.ToInteger(xmlNode_3.InnerText);
						break;
					case "ActiveUnit_CommStuff":
					{
						Satellite satellite2 = satellite_;
						ActiveUnit activeUnit_2 = satellite_;
						satellite2._CommStuff = ActiveUnit_CommStuff.FromXML(ref xmlNode_3, ref concurrentDictionary_0, ref activeUnit_2);
						break;
					}
					case "OODA_E":
						satellite_.HasCustomOODA = true;
						satellite_._ResolverVal = Conversions.ToShort(xmlNode_3.InnerText);
						break;
					case "SID":
						satellite_.SpacecraftID = xmlNode_3.InnerText;
						break;
					case "ActiveUnit_AI":
						ActiveUnit_AI.FromXML(xmlNode_3, concurrentDictionary_0, satellite_);
						break;
					case "Latitude_UnitEntersAreaCheck":
						satellite_.Latitude__UnitEntersAreaCheck = XmlConvert.ToDouble(xmlNode_3.InnerText);
						break;
					case "OODA_D":
						satellite_.HasCustomOODA = true;
						satellite_.m_TokenVal = Conversions.ToShort(xmlNode_3.InnerText);
						break;
					case "ActiveUnit_Sensory":
					case "Sensory":
					{
						Satellite satellite = satellite_;
						ActiveUnit activeUnit_ = satellite_;
						satellite._Sensory = ActiveUnit_Sensory.FromXML(ref xmlNode_3, ref concurrentDictionary_0, ref activeUnit_);
						break;
					}
					case "OODA_T":
						satellite_.HasCustomOODA = true;
						satellite_._IndexerVal = Conversions.ToShort(xmlNode_3.InnerText);
						break;
					case "AssignedMission":
						if (xmlNode_3.HasChildNodes)
						{
							XmlNode xmlNode5 = xmlNode_3.ChildNodes[0];
							satellite_._AssignedMissionOrPackage_ID = xmlNode5.InnerText;
						}
						break;
					case "CustomIcon":
						satellite_.CustomIcon = xmlNode_3.InnerText;
						break;
					case "Side":
						satellite_._SideName = xmlNode_3.InnerText;
						break;
					case "ActiveRemainAreaTriggers":
					{
						string key = null;
						DateTime result = DateTime.MinValue;
						try
						{
							enumerator7 = xmlNode_3.ChildNodes.GetEnumerator();
							while (enumerator7.MoveNext())
							{
								XmlNode xmlNode4 = (XmlNode)enumerator7.Current;
								if (Operators.CompareString(xmlNode4.Name, "RemainAreaTrigger", TextCompare: false) == 0)
								{
									key = xmlNode4.InnerText;
									result = DateTime.MinValue;
									continue;
								}
								if (DateTime.TryParse(xmlNode4.InnerText, CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
								{
									satellite_.ActiveRemainAreaTriggers.Add(key, result);
									continue;
								}
								string innerText = xmlNode4.InnerText;
								long result2 = 0L;
								if (long.TryParse(innerText, out result2))
								{
									result = DateTime.FromBinary(Conversions.ToLong(xmlNode4.InnerText));
									satellite_.ActiveRemainAreaTriggers.Add(key, result);
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
						break;
					}
					case "Anchor":
						satellite_.OrbitAnchor = new SatelliteOrbitAnchor();
						try
						{
							enumerator8 = xmlNode_3.ChildNodes.GetEnumerator();
							while (enumerator8.MoveNext())
							{
								XmlNode xmlNode3 = (XmlNode)enumerator8.Current;
								switch (xmlNode3.Name)
								{
								case "Lon":
									satellite_.OrbitAnchor.Longitude = XmlConvert.ToDouble(xmlNode3.InnerText);
									break;
								case "Lat":
									satellite_.OrbitAnchor.Latitude = XmlConvert.ToDouble(xmlNode3.InnerText);
									break;
								case "Alt":
									satellite_.OrbitAnchor.Altitude = XmlConvert.ToSingle(xmlNode3.InnerText);
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
						break;
					case "Message":
						satellite_.Message = xmlNode_3.InnerText;
						break;
					case "AssignedTaskPool":
						if (xmlNode_3.HasChildNodes)
						{
							XmlNode xmlNode2 = xmlNode_3.ChildNodes[0];
							satellite_._AssignedTaskPool_ID = xmlNode2.InnerText;
						}
						break;
					case "IsAD":
					case "IsAutoDetectable":
						satellite_.SetIsAutoDetectable(null, Conversions.ToBoolean(xmlNode_3.InnerText));
						break;
					case "Longitude_UnitEntersAreaCheck":
						satellite_.Longitude__UnitEntersAreaCheck = XmlConvert.ToDouble(xmlNode_3.InnerText);
						break;
					case "ParentGroup":
						satellite_._ParentGroup_ID = xmlNode_3.InnerText;
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
			satellite_.Kinematics.Move(1f, bool_0: false, bool_1: false, scenario_0.Time);
			satellite_.EvaluateIfDumb();
			return satellite_;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100754", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public override bool IsOperating()
	{
		if (DateTime.Compare(ParentScen.Time, LaunchDate) < 0)
		{
			return false;
		}
		if (DateTime.Compare(ParentScen.Time, DeOrbitDate) > 0 && DateTime.Compare(DeOrbitDate, new DateTime(1900, 1, 1)) > 0)
		{
			return false;
		}
		return true;
	}
}
