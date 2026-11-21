using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class WaterSplash : Module_Unit.Unit
{
	public float MaxRadius;

	public float CurrentRadius;

	public WaterSplash(ref Scenario scenario_0, double double_0, double double_1, float float_0)
	{
		SetLongitude(null, double_0);
		SetLatitude(null, double_1);
		MaxRadius = float_0;
		if (!Information.IsNothing(scenario_0))
		{
			scenario_0.WaterSplashes.Add(this);
		}
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("WaterSplash");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			if (hashSet_0.Contains(ObjectID))
			{
				xmlWriter_0.WriteEndElement();
				return;
			}
			hashSet_0.Add(ObjectID);
			xmlWriter_0.WriteElementString("Lon", XmlConvert.ToString(GetLongitude()));
			xmlWriter_0.WriteElementString("Lat", XmlConvert.ToString(GetLatitude()));
			xmlWriter_0.WriteElementString("MR", MaxRadius.ToString());
			xmlWriter_0.WriteElementString("CR", CurrentRadius.ToString());
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100877", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private WaterSplash()
	{
	}

	public static WaterSplash FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		try
		{
			WaterSplash waterSplash = new WaterSplash();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "MR":
						waterSplash.MaxRadius = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "Lon":
						waterSplash.SetLongitude(null, XmlConvert.ToDouble(xmlNode.InnerText));
						break;
					case "Lat":
						waterSplash.SetLatitude(null, XmlConvert.ToDouble(xmlNode.InnerText));
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							waterSplash.ObjectID_Set(xmlNode.InnerText);
							concurrentDictionary_0.TryAdd(waterSplash.ObjectID, waterSplash);
							break;
						}
						return (WaterSplash)concurrentDictionary_0[xmlNode.InnerText];
					case "CR":
						waterSplash.CurrentRadius = XmlConvert.ToSingle(xmlNode.InnerText);
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
			return waterSplash;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100878", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			WaterSplash result = new WaterSplash();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public void Spread(Scenario scenario_0, float float_0)
	{
		CurrentRadius += float_0 * Math.Max(MaxRadius / 50f, (MaxRadius - CurrentRadius) / 5f);
		if (CurrentRadius > MaxRadius)
		{
			scenario_0.WaterSplashes.Remove(this);
		}
	}

	private static void PushReponse(object object_0, object object_1)
	{
	}
}
