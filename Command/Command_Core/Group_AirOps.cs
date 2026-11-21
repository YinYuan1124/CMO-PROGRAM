using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Group_AirOps : ActiveUnit_AirOps
{
	private static ActiveUnit contextDic;

	public override List<Aircraft> EmbarkedAircraft_ReadOnly
	{
		get
		{
			List<Aircraft> result = null;
			try
			{
				List<Aircraft> list = new List<Aircraft>();
				foreach (ActiveUnit value in ((Group)myUnit).Units.Values)
				{
					foreach (Aircraft item in value.AirOps.EmbarkedAircraft_ReadOnly)
					{
						list.Add(item);
					}
				}
				result = list;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100610", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Group_AirOps");
			xmlWriter_0.WriteStartElement("LandingQueue");
			Aircraft[] landingQueue = _LandingQueue;
			Aircraft[] array = landingQueue;
			foreach (Aircraft aircraft in array)
			{
				if (!Information.IsNothing(aircraft))
				{
					xmlWriter_0.WriteElementString("ID", aircraft.ObjectID);
				}
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100608", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Group_AirOps FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		Group_AirOps result = null;
		try
		{
			Group_AirOps group_AirOps = new Group_AirOps();
			group_AirOps.myUnit = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					if (Operators.CompareString(xmlNode.Name, "LandingQueue", TextCompare: false) == 0)
					{
						int num = xmlNode.ChildNodes.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							ArrayExtensions.Add(ref group_AirOps._LandingQueue_IDs, xmlNode.ChildNodes[i].InnerText);
						}
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
			result = group_AirOps;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100609", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private Group_AirOps()
		: base(ref contextDic)
	{
	}

	public Group_AirOps(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}
}
