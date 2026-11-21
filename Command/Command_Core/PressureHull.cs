using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class PressureHull : PlatformComponent
{
	public void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("PressureHull");
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
			xmlWriter_0.WriteElementString("DamageSeverity", ((byte)base.DamageSeverity).ToString());
			xmlWriter_0.WriteElementString("Name", Name);
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100689", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static PressureHull FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		PressureHull result = null;
		try
		{
			PressureHull pressureHull = new PressureHull();
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
							pressureHull._Status = (_ComponentStatus)Conversions.ToByte(xmlNode.InnerText);
							break;
						case "Operational":
							pressureHull._Status = _ComponentStatus.Operational;
							break;
						case "Destroyed":
							pressureHull._Status = _ComponentStatus.Destroyed;
							break;
						case "Damaged":
							pressureHull._Status = _ComponentStatus.Damaged;
							break;
						}
						break;
					case "Name":
						pressureHull.Name = xmlNode.InnerText;
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							pressureHull.ObjectID_Set(xmlNode.InnerText);
							concurrentDictionary_0.TryAdd(pressureHull.ObjectID, pressureHull);
							break;
						}
						result = (PressureHull)concurrentDictionary_0[xmlNode.InnerText];
						return result;
					case "DamageSeverity":
						pressureHull.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(xmlNode.InnerText);
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
			result = pressureHull;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100690", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private PressureHull()
	{
	}

	public PressureHull(ActiveUnit activeUnit_0)
		: base(activeUnit_0)
	{
	}
}
