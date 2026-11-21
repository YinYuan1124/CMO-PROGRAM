using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Rudder : PlatformComponent
{
	protected float _lastHeadingChangePerSecond;

	public float lastHeadingChangePerSecond => _lastHeadingChangePerSecond;

	public void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Rudder");
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
			if (_lastHeadingChangePerSecond != 0f)
			{
				xmlWriter_0.WriteElementString("LHCPS", XmlConvert.ToString(_lastHeadingChangePerSecond));
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100691", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Rudder FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		try
		{
			Rudder rudder = new Rudder();
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
							rudder._Status = (_ComponentStatus)Conversions.ToByte(xmlNode.InnerText);
							break;
						case "Operational":
							rudder._Status = _ComponentStatus.Operational;
							break;
						case "Destroyed":
							rudder._Status = _ComponentStatus.Destroyed;
							break;
						case "Damaged":
							rudder._Status = _ComponentStatus.Damaged;
							break;
						}
						break;
					case "Name":
						rudder.Name = xmlNode.InnerText;
						break;
					case "LHCPS":
						rudder._lastHeadingChangePerSecond = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "ID":
						rudder.ObjectID_Set(xmlNode.InnerText);
						break;
					case "DamageSeverity":
						rudder.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(xmlNode.InnerText);
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
			return rudder;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100692", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Rudder result = new Rudder();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private Rudder()
	{
		_lastHeadingChangePerSecond = 0f;
		Name = "Rudder";
	}

	public Rudder(ActiveUnit activeUnit_0)
		: base(activeUnit_0)
	{
		_lastHeadingChangePerSecond = 0f;
		Name = "Rudder";
	}

	public float headingChangeAsFractionOfTurnrate()
	{
		return 0f;
	}

	internal float IncludeWriter(float float_0, float float_1, float float_2)
	{
		float val = float_1;
		float num = float_0 * float_2;
		float num2 = _lastHeadingChangePerSecond * float_2;
		val = Math.Max(num2 - num, val);
		val = Math.Min(num2 + num, val);
		float num3 = 1f;
		if (Status == _ComponentStatus.Destroyed)
		{
			_lastHeadingChangePerSecond = 0f;
			return 0f;
		}
		if (Status == _ComponentStatus.Damaged)
		{
			switch (base.DamageSeverity)
			{
			case _DamageSeverityFactor.Light:
				num3 = 0.66f;
				break;
			case _DamageSeverityFactor.Medium:
				num3 = 0.33f;
				break;
			case _DamageSeverityFactor.Heavy:
				num3 = 0f;
				break;
			}
		}
		float num4 = num3;
		if (num4 == 0f)
		{
			val = num2;
		}
		else if (num4 != 1f)
		{
			val = val * num4 + num2 * (1f - num4);
		}
		_lastHeadingChangePerSecond = val / float_2;
		return val;
	}
}
