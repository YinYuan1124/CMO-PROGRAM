using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Posture : ScenarioObject
{
	public Misc.PostureStance PostureType;

	public Side PostureTarget;

	private string m_ManagerConsumer;

	private string _GetterConsumer;

	public void ToXML(ref XmlWriter xmlWriter_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Posture");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			XmlWriter obj = xmlWriter_0;
			int postureType = (int)PostureType;
			obj.WriteElementString("PostureType", postureType.ToString());
			xmlWriter_0.WriteElementString("PostureTarget", PostureTarget.ObjectID);
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101015", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Posture()
	{
	}

	public static Posture FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		Posture result = null;
		try
		{
			Posture posture = new Posture();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "PostureType":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							posture.PostureType = (Misc.PostureStance)Conversions.ToByte(xmlNode.InnerText);
						}
						else
						{
							posture.PostureType = (Misc.PostureStance)Enum.Parse(typeof(Misc.PostureStance), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "PostureTargetName":
						posture._GetterConsumer = xmlNode.InnerText;
						break;
					case "PostureTarget":
						posture.m_ManagerConsumer = xmlNode.InnerText;
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							posture.ObjectID_Set(xmlNode.InnerText);
							concurrentDictionary_0.TryAdd(posture.ObjectID, posture);
							break;
						}
						result = (Posture)concurrentDictionary_0[xmlNode.InnerText];
						return result;
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
			result = posture;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101016", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Posture(Side side_0, Misc.PostureStance postureStance_0)
	{
		PostureTarget = side_0;
		PostureType = postureStance_0;
	}

	public void PostDeserializationHousekeeping(ref Scenario scenario_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		if (Information.IsNothing(m_ManagerConsumer))
		{
			return;
		}
		try
		{
			PostureTarget = (Side)concurrentDictionary_0[m_ManagerConsumer];
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101017", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
