using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class SpecialAction : ScenarioObject
{
	public string Description;

	public bool IsActive;

	public bool IsRepeatable;

	public string ScriptText;

	public void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("SpecialAction");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("Name", Name);
			xmlWriter_0.WriteElementString("Description", Description);
			xmlWriter_0.WriteElementString("IsRepeatable", IsRepeatable.ToString());
			xmlWriter_0.WriteElementString("IsActive", IsActive.ToString());
			xmlWriter_0.WriteElementString("ScriptText", ScriptText);
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200654", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static SpecialAction FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		SpecialAction result = null;
		try
		{
			SpecialAction specialAction = new SpecialAction();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "ScriptText":
						specialAction.ScriptText = xmlNode.InnerText;
						break;
					case "Name":
						specialAction.Name = xmlNode.InnerText;
						break;
					case "IsRepeatable":
						specialAction.IsRepeatable = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "IsActive":
						specialAction.IsActive = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "ID":
						specialAction.ObjectID_Set(xmlNode.InnerText);
						break;
					case "Description":
						specialAction.Description = xmlNode.InnerText;
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
			result = specialAction;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101324", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public SpecialAction()
	{
		IsActive = true;
		IsRepeatable = false;
	}

	internal string MoveSpecification(Scenario scenario_0)
	{
		string result = null;
		try
		{
			if (!IsRepeatable)
			{
				IsActive = false;
			}
			object[] array = scenario_0.Scenario_LuaSandbox.RunScript(ScriptText, bool_0: false, Name);
			if (array != null && array.Length != 0)
			{
				result = array[0].ToString();
				return result;
			}
			result = "特别动作'" + Name + "'已被执行。";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			GameGeneral.ResolveBridge("执行错误：" + exception_.Message + "\r\nStack:" + exception_.StackTrace, null);
			exception_?.Data.Add("Error at 101325", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public SpecialAction Clone()
	{
		SpecialAction obj = (SpecialAction)MemberwiseClone();
		obj.ObjectID_Set(Guid.NewGuid().ToString());
		obj.Description = "[克隆]" + Description;
		obj.Name = "[克隆]" + Name;
		return obj;
	}
}
