using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class ActiveUnit_Struct
{
	public Side UnitSide;

	public string ObjectId;

	public string Name;

	public int DBID;

	public ActiveUnit_Struct()
	{
	}

	public ActiveUnit_Struct(Side side_0, string string_0, string string_1, int int_0)
	{
		UnitSide = side_0;
		ObjectId = string_0;
		DBID = int_0;
		Name = string_1;
	}

	public void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("ActiveUnit");
			xmlWriter_0.WriteElementString("ID", ObjectId);
			xmlWriter_0.WriteElementString("Name", Name);
			if (UnitSide == null)
			{
				xmlWriter_0.WriteElementString("Side", "");
			}
			else
			{
				xmlWriter_0.WriteElementString("Side", UnitSide.Name);
			}
			xmlWriter_0.WriteElementString("DBID", DBID.ToString());
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 19876590817", " ActiveUnit_Struct Name: " + Name + " DBID: " + Conversions.ToString(DBID) + " ObjectID: " + ObjectId);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static ActiveUnit_Struct FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			ActiveUnit_Struct activeUnit_Struct = new ActiveUnit_Struct();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "Side":
						activeUnit_Struct.UnitSide = Side.FromXML_ByName(xmlNode.InnerText, ref concurrentDictionary_0, scenario_0);
						break;
					case "Name":
						activeUnit_Struct.Name = xmlNode.InnerText;
						break;
					case "ID":
						activeUnit_Struct.ObjectId = xmlNode.InnerText;
						break;
					case "DBID":
						activeUnit_Struct.DBID = int.Parse(xmlNode.InnerText);
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
			return activeUnit_Struct;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100865", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ActiveUnit_Struct result = new ActiveUnit_Struct();
			ProjectData.ClearProjectError();
			return result;
		}
	}
}
