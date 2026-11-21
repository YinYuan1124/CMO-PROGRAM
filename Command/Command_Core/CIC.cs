using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class CIC : PlatformComponent
{
	public void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("CIC");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			if (hashSet_0.Contains(ObjectID))
			{
				xmlWriter_0.WriteEndElement();
				return;
			}
			hashSet_0.Add(ObjectID);
			XmlWriter obj = xmlWriter_0;
			byte status = (byte)_Status;
			obj.WriteElementString("Status", status.ToString());
			xmlWriter_0.WriteElementString("Name", Name);
			if (base.DamageSeverity != 0)
			{
				xmlWriter_0.WriteElementString("DamageSeverity", ((byte)base.DamageSeverity).ToString());
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100660", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static CIC FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		CIC result = null;
		try
		{
			CIC cIC = new CIC("");
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes[0].ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "Status":
						switch (xmlNode.InnerText)
						{
						default:
							cIC._Status = (_ComponentStatus)Conversions.ToByte(xmlNode.InnerText);
							break;
						case "Operational":
							cIC._Status = _ComponentStatus.Operational;
							break;
						case "Destroyed":
							cIC._Status = _ComponentStatus.Destroyed;
							break;
						case "Damaged":
							cIC._Status = _ComponentStatus.Damaged;
							break;
						}
						break;
					case "Name":
						cIC.Name = xmlNode.InnerText;
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							cIC.ObjectID_Set(xmlNode.InnerText);
							concurrentDictionary_0.TryAdd(cIC.ObjectID, cIC);
							break;
						}
						result = (CIC)concurrentDictionary_0[xmlNode.InnerText];
						return result;
					case "DamageSeverity":
						cIC.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(xmlNode.InnerText);
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
			result = cIC;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100661", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private CIC(string string_0)
	{
	}

	public CIC(ActiveUnit activeUnit_0, string string_0)
		: base(activeUnit_0)
	{
		Name = string_0;
	}
}
