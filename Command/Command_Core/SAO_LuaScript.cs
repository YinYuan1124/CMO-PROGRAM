using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class SAO_LuaScript : ScenAttachmentObject
{
	[DoNotObfuscate]
	public string ScriptFileName;

	public SAO_LuaScript(string string_0)
		: base(string_0)
	{
		Type = AttachmentObjectType.LuaScript;
	}

	public SAO_LuaScript()
	{
		Type = AttachmentObjectType.LuaScript;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("SAO_LuaScript");
			xmlWriter_0.WriteElementString("ID", base.ObjectID);
			xmlWriter_0.WriteElementString("Desc", Description);
			xmlWriter_0.WriteElementString("SFN", ScriptFileName);
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101306", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static SAO_LuaScript FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			SAO_LuaScript sAO_LuaScript = new SAO_LuaScript();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "SFN":
						sAO_LuaScript.ScriptFileName = xmlNode.InnerText;
						break;
					case "ID":
						sAO_LuaScript._GUID = xmlNode.InnerText;
						break;
					case "Desc":
						sAO_LuaScript.Description = xmlNode.InnerText;
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
			return sAO_LuaScript;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101307", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			SAO_LuaScript result = new SAO_LuaScript();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override void CopyToLocalRepository(string string_0)
	{
		if (!Directory.Exists(GameGeneral.AttachmentRepoPath))
		{
			Directory.CreateDirectory(GameGeneral.AttachmentRepoPath);
		}
		Directory.CreateDirectory(Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID));
		File.Copy(string_0, Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, ScriptFileName), overwrite: true);
	}

	public override bool UseAttachment(Scenario scenario_0)
	{
		scenario_0.Scenario_LuaSandbox.LUA_ScenEdit_RunScript(Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, ScriptFileName));
		return true;
	}

	public override void vmethod_0(string string_0)
	{
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Indent = true;
		xmlWriterSettings.IndentChars = "    ";
		XmlWriter xmlWriter = XmlWriter.Create(Path.Combine(string_0, "desc.xml"), xmlWriterSettings);
		xmlWriter.WriteStartElement("Attachment");
		xmlWriter.WriteElementString("Type", Conversions.ToString((int)Type));
		xmlWriter.WriteElementString("Desc", Description);
		xmlWriter.WriteElementString("SFN", ScriptFileName);
		xmlWriter.WriteEndElement();
		xmlWriter.Close();
	}
}
