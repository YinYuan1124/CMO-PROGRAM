using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class CommLink : ScenarioObject
{
	public ActiveUnit CommPartner;

	public string CommPartner_ObjectID;

	public CommDevice DeviceUsed;

	public void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			if (!Information.IsNothing(CommPartner))
			{
				xmlWriter_0.WriteStartElement("CommLink");
				xmlWriter_0.WriteElementString("ID", ObjectID);
				xmlWriter_0.WriteElementString("CommPartner", CommPartner.ObjectID);
				xmlWriter_0.WriteStartElement("DeviceUsed");
				xmlWriter_0.WriteRaw(DeviceUsed.ToXML(ref hashSet_0));
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteEndElement();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100997", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static CommLink FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			CommLink commLink = new CommLink();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "ID":
						commLink.ObjectID_Set(xmlNode.InnerText);
						break;
					case "DeviceUsed":
					{
						XmlNode xmlNode_ = xmlNode.ChildNodes[0];
						commLink.DeviceUsed = CommDevice.FromXML(ref xmlNode_, ref concurrentDictionary_0, activeUnit_0);
						break;
					}
					case "CommPartner":
						commLink.CommPartner_ObjectID = xmlNode.InnerText;
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
			return commLink;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100998", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private CommLink()
	{
	}

	public CommLink(ref ActiveUnit activeUnit_0, ref CommDevice commDevice_0)
	{
		CommPartner = activeUnit_0;
		DeviceUsed = commDevice_0;
	}

	public void PostDeserializationHousekeeping(ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		if (concurrentDictionary_0.TryGetValue(CommPartner_ObjectID, out var value))
		{
			CommPartner = (ActiveUnit)value;
		}
	}
}
