using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Vehicle_CommStuff : ActiveUnit_CommStuff
{
	public new static Vehicle_CommStuff FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		Vehicle_CommStuff result = null;
		try
		{
			Vehicle_CommStuff vehicle_CommStuff = new Vehicle_CommStuff(ref activeUnit_0);
			vehicle_CommStuff.myUnit = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "OOC":
						vehicle_CommStuff._IsConnectedToSideNetwork = !Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "ICS":
						vehicle_CommStuff._InternalCommsStatus = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "CLE":
					{
						vehicle_CommStuff._CommLinksEstablished = new CommLink[xmlNode.ChildNodes.Count - 1 + 1];
						int num = xmlNode.ChildNodes.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							XmlNode xmlNode_ = xmlNode.ChildNodes[i];
							CommLink commLink = CommLink.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_0);
							vehicle_CommStuff._CommLinksEstablished[i] = commLink;
						}
						break;
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
			result = vehicle_CommStuff;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100552", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Vehicle_CommStuff(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}
}
