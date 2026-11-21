using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Aircraft_CommStuff : ActiveUnit_CommStuff
{
	public new static Aircraft_CommStuff FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Aircraft_CommStuff aircraft_CommStuff = new Aircraft_CommStuff(ref activeUnit_0);
			aircraft_CommStuff.myUnit = activeUnit_0;
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
						aircraft_CommStuff._IsConnectedToSideNetwork = !Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "ICS":
						aircraft_CommStuff._InternalCommsStatus = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "CLE":
					{
						aircraft_CommStuff._CommLinksEstablished = new CommLink[xmlNode.ChildNodes.Count - 1 + 1];
						int num = xmlNode.ChildNodes.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							XmlNode xmlNode_ = xmlNode.ChildNodes[i];
							CommLink commLink = CommLink.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_0);
							aircraft_CommStuff._CommLinksEstablished[i] = commLink;
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
			return aircraft_CommStuff;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101192", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Aircraft_CommStuff result = new Aircraft_CommStuff(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Aircraft_CommStuff(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}
}
