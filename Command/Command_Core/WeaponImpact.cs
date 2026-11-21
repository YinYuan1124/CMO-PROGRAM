using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class WeaponImpact : Module_Unit.Unit
{
	public enum ImpactType : short
	{
		Kinetic,
		Electronic
	}

	public ImpactType Type;

	public float Age;

	public int int_0;

	public WeaponImpact(ref Scenario scenario_0, double double_0, double double_1, float float_0, ImpactType impactType_0, int int_1)
	{
		SetLongitude(null, double_0);
		SetLatitude(null, double_1);
		SetCurrentAltitude(bool_0: false, float_0);
		Type = impactType_0;
		int_0 = int_1;
		if (!Information.IsNothing(scenario_0))
		{
			scenario_0.WeaponImpacts.Add(this);
		}
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("WeaponImpact");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			if (hashSet_0.Contains(ObjectID))
			{
				xmlWriter_0.WriteEndElement();
				return;
			}
			hashSet_0.Add(ObjectID);
			xmlWriter_0.WriteElementString("Name", Name);
			xmlWriter_0.WriteElementString("CurrentAltitude", XmlConvert.ToString(GetCurrentAltitude()));
			xmlWriter_0.WriteElementString("Longitude", XmlConvert.ToString(GetLongitude()));
			xmlWriter_0.WriteElementString("Latitude", XmlConvert.ToString(GetLatitude()));
			XmlWriter obj = xmlWriter_0;
			short type = (short)Type;
			obj.WriteElementString("Type", type.ToString());
			xmlWriter_0.WriteElementString("Age", XmlConvert.ToString(Age));
			xmlWriter_0.WriteElementString("Message", Message);
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101328", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private WeaponImpact()
	{
	}

	public void Progress(ref Scenario scenario_0, float float_0)
	{
		Age += float_0;
	}

	public static WeaponImpact FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		try
		{
			WeaponImpact weaponImpact = new WeaponImpact();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "CurrentAltitude":
						weaponImpact.SetCurrentAltitude(bool_0: false, XmlConvert.ToSingle(xmlNode.InnerText));
						break;
					case "Name":
						weaponImpact.Name = xmlNode.InnerText;
						break;
					case "Latitude":
						weaponImpact.SetLatitude(null, XmlConvert.ToDouble(xmlNode.InnerText));
						break;
					case "Longitude":
						weaponImpact.SetLongitude(null, XmlConvert.ToDouble(xmlNode.InnerText));
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							weaponImpact.ObjectID_Set(xmlNode.InnerText);
							concurrentDictionary_0.TryAdd(weaponImpact.ObjectID, weaponImpact);
							break;
						}
						return (WeaponImpact)concurrentDictionary_0[xmlNode.InnerText];
					case "Message":
						weaponImpact.Message = xmlNode.InnerText;
						break;
					case "Age":
						weaponImpact.Age = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "CurrentHeading":
						weaponImpact.CurrentHeading = (float)XmlConvert.ToDouble(xmlNode.InnerText);
						break;
					case "Type":
						if (xmlNode.InnerText.Contains("Kinetic"))
						{
							weaponImpact.Type = ImpactType.Kinetic;
						}
						else
						{
							weaponImpact.Type = (ImpactType)Conversions.ToShort(xmlNode.InnerText);
						}
						break;
					case "CurrentSpeed":
						weaponImpact.CurrentSpeed = (float)XmlConvert.ToDouble(xmlNode.InnerText);
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
			return weaponImpact;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100880", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			WeaponImpact result = new WeaponImpact();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static void ExportWeaponImpactEvent(WeaponImpact weaponImpact_0, Scenario scenario_0)
	{
		foreach (IEventExporter applicableEventExporter in scenario_0.ApplicableEventExporters)
		{
			if (applicableEventExporter.IsOperating && applicableEventExporter.ExportExplosions)
			{
				Dictionary<string, IEventExporter.EventNotificationParameter> dictionary = new Dictionary<string, IEventExporter.EventNotificationParameter>(30);
				if (scenario_0.MonteCarloIteration > 0)
				{
					dictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(scenario_0.Title, typeof(string), 500));
					dictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(scenario_0.MonteCarloIteration, typeof(int)));
				}
				dictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(scenario_0.TimelineID, typeof(string), 40));
				if (applicableEventExporter.UseZeroHour)
				{
					dictionary.Add("Time", new IEventExporter.EventNotificationParameter(scenario_0.Time.Subtract(scenario_0.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				else
				{
					dictionary.Add("Time", new IEventExporter.EventNotificationParameter(scenario_0.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + scenario_0.Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				dictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(weaponImpact_0.ObjectID, typeof(string), 40));
				dictionary.Add("UnitLongitude", new IEventExporter.EventNotificationParameter(weaponImpact_0.GetLongitude(), typeof(double)));
				dictionary.Add("UnitLatitude", new IEventExporter.EventNotificationParameter(weaponImpact_0.GetLatitude(), typeof(double)));
				dictionary.Add("UnitCourse", new IEventExporter.EventNotificationParameter(weaponImpact_0.CurrentHeading, typeof(float)));
				dictionary.Add("UnitSpeed_kts", new IEventExporter.EventNotificationParameter(weaponImpact_0.CurrentSpeed, typeof(float)));
				dictionary.Add("UnitAltitude_m", new IEventExporter.EventNotificationParameter(weaponImpact_0.GetCurrentAltitude(), typeof(float)));
				applicableEventExporter.ExportEvent(IEventExporter.ExportedEventType.WeaponImpact, dictionary, scenario_0);
			}
		}
		ISimConnector[] activeSimConnectors = SimConnect_General.ActiveSimConnectors;
		for (int i = 0; i < activeSimConnectors.Length; i = checked(i + 1))
		{
			if (activeSimConnectors[i].ExportWeaponImpactOrDetonation)
			{
				Dictionary<string, Tuple<Type, string>> dictionary2 = new Dictionary<string, Tuple<Type, string>>();
				dictionary2.Add("TimelineID", new Tuple<Type, string>(typeof(string), scenario_0.TimelineID));
				dictionary2.Add("Time", new Tuple<Type, string>(typeof(DateTime), scenario_0.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + scenario_0.Time.Millisecond.ToString("D3")));
				dictionary2.Add("Longitude", new Tuple<Type, string>(typeof(double), weaponImpact_0.GetLongitude().ToString()));
				dictionary2.Add("Latitude", new Tuple<Type, string>(typeof(double), weaponImpact_0.GetLatitude().ToString()));
				dictionary2.Add("Altitude", new Tuple<Type, string>(typeof(float), weaponImpact_0.GetCurrentAltitude().ToString()));
				dictionary2.Add("WeaponDBID", new Tuple<Type, string>(typeof(string), Conversions.ToString(weaponImpact_0.int_0)));
				dictionary2.Add("UnitID", new Tuple<Type, string>(typeof(string), weaponImpact_0.ObjectID));
				dictionary2.Add("EventType", new Tuple<Type, string>(typeof(string), "Explosion"));
			}
		}
	}
}
