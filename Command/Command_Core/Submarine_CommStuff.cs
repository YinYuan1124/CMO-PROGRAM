using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Submarine_CommStuff : ActiveUnit_CommStuff
{
	public new static Submarine_CommStuff FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Submarine_CommStuff submarine_CommStuff = new Submarine_CommStuff(ref activeUnit_0);
			submarine_CommStuff.myUnit = activeUnit_0;
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
						submarine_CommStuff._IsConnectedToSideNetwork = !Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "ICS":
						submarine_CommStuff._InternalCommsStatus = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "CLE":
					{
						submarine_CommStuff._CommLinksEstablished = new CommLink[xmlNode.ChildNodes.Count - 1 + 1];
						int num = xmlNode.ChildNodes.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							XmlNode xmlNode_ = xmlNode.ChildNodes[i];
							CommLink commLink = CommLink.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_0);
							submarine_CommStuff._CommLinksEstablished[i] = commLink;
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
			return submarine_CommStuff;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100827", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Submarine_CommStuff result = new Submarine_CommStuff(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Submarine_CommStuff(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}
}
