using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class ChaffCorridorCloud : Module_Unit.Unit
{
	private double m_CandidateObserver;

	public const int MaxLength = 6000;

	public int CoverageLength => Math.Min(100 + (int)Math.Round(m_CandidateObserver * 100.0), 6000);

	public int CoverageWidth => Math.Min(40 + (int)Math.Round(m_CandidateObserver * 50.0), 1500);

	public int CurtainCeiling
	{
		get
		{
			float num = (float)(m_CandidateObserver * 0.6);
			return Math.Max(0, (int)Math.Round((double)GetCurrentAltitude() + (double)num * 0.5));
		}
	}

	public int CurtainFloor
	{
		get
		{
			float num = (float)(m_CandidateObserver * 0.6);
			return Math.Max(0, (int)Math.Round((double)GetCurrentAltitude() - (double)num * 1.5));
		}
	}

	public ChaffCorridorCloud(double double_0, double double_1, float float_0, float float_1)
	{
		SetLatitude(null, double_0);
		SetLongitude(null, double_1);
		SetCurrentAltitude(bool_0: false, float_0);
		CurrentHeading = float_1;
	}

	public void Progress(float float_0)
	{
		m_CandidateObserver += float_0;
		SetCurrentAltitude(bool_0: false, (float)((double)GetCurrentAltitude() - 0.6 * (double)float_0));
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("ChaffCloud");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			if (hashSet_0.Contains(ObjectID))
			{
				xmlWriter_0.WriteEndElement();
				return;
			}
			hashSet_0.Add(ObjectID);
			xmlWriter_0.WriteElementString("CH", XmlConvert.ToString(CurrentHeading));
			xmlWriter_0.WriteElementString("Age", XmlConvert.ToString(m_CandidateObserver));
			xmlWriter_0.WriteElementString("Lon", XmlConvert.ToString(GetLongitude()));
			xmlWriter_0.WriteElementString("Lat", XmlConvert.ToString(GetLatitude()));
			xmlWriter_0.WriteElementString("Alt", XmlConvert.ToString(GetCurrentAltitude()));
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 112340-231495090911", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private ChaffCorridorCloud()
	{
	}

	public static ChaffCorridorCloud FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		try
		{
			ChaffCorridorCloud chaffCorridorCloud = new ChaffCorridorCloud();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "Lon":
						chaffCorridorCloud.SetLongitude(null, XmlConvert.ToDouble(xmlNode.InnerText));
						break;
					case "Lat":
						chaffCorridorCloud.SetLatitude(null, XmlConvert.ToDouble(xmlNode.InnerText));
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							chaffCorridorCloud.ObjectID_Set(xmlNode.InnerText);
							concurrentDictionary_0.TryAdd(chaffCorridorCloud.ObjectID, chaffCorridorCloud);
							break;
						}
						return (ChaffCorridorCloud)concurrentDictionary_0[xmlNode.InnerText];
					case "CH":
						chaffCorridorCloud.CurrentHeading = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "Alt":
						chaffCorridorCloud.SetCurrentAltitude(bool_0: false, XmlConvert.ToSingle(xmlNode.InnerText));
						break;
					case "Age":
						chaffCorridorCloud.m_CandidateObserver = XmlConvert.ToSingle(xmlNode.InnerText);
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
			return chaffCorridorCloud;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10213412354093409922", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ChaffCorridorCloud result = new ChaffCorridorCloud();
			ProjectData.ClearProjectError();
			return result;
		}
	}
}
