using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class ReferencePointFlag : ScenarioObject
{
	public string ToXML(ref HashSet<string> hashSet_0)
	{
		string result = null;
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Clear();
			stringBuilder.Append("<RPointFlag>");
			stringBuilder.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (hashSet_0 != null)
			{
				if (hashSet_0.Contains(ObjectID))
				{
					stringBuilder.Append("</RPointFlag>");
					result = stringBuilder.ToString();
					return result;
				}
				hashSet_0.Add(ObjectID);
			}
			stringBuilder.Append("<Name>").Append(SecurityElement.Escape(Name)).Append("</Name>");
			stringBuilder.Append("</RPointFlag>");
			result = stringBuilder.ToString();
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100584_b", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static ReferencePointFlag FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		try
		{
			ReferencePointFlag referencePointFlag = new ReferencePointFlag("");
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					string name = xmlNode.Name;
					if (Operators.CompareString(name, "ID", TextCompare: false) == 0)
					{
						if (concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							return (ReferencePointFlag)concurrentDictionary_0[xmlNode.InnerText];
						}
						referencePointFlag.ObjectID_Set(xmlNode.InnerText);
						concurrentDictionary_0.TryAdd(referencePointFlag.ObjectID, referencePointFlag);
					}
					else if (Operators.CompareString(name, "Name", TextCompare: false) == 0)
					{
						referencePointFlag.Name = xmlNode.InnerText;
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
			return referencePointFlag;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100585_b", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ReferencePointFlag result = new ReferencePointFlag("");
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public ReferencePointFlag(string string_0)
	{
		Name = string_0;
	}
}
