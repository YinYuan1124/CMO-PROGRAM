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

public sealed class SAO_LocalHTML : ScenAttachmentObject
{
	[DoNotObfuscate]
	public string HTMLFileName;

	private int _ProcessFacade;

	private int _ThreadFacade;

	public int SizeX
	{
		get
		{
			return _ProcessFacade;
		}
		set
		{
			_ProcessFacade = value;
		}
	}

	public int SizeY
	{
		get
		{
			return _ThreadFacade;
		}
		set
		{
			_ThreadFacade = value;
		}
	}

	public SAO_LocalHTML(string string_0)
		: base(string_0)
	{
		Type = AttachmentObjectType.const_7;
	}

	public SAO_LocalHTML()
	{
		Type = AttachmentObjectType.const_7;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("SAO_LocalHTML");
			xmlWriter_0.WriteElementString("ID", base.ObjectID);
			xmlWriter_0.WriteElementString("Desc", Description);
			xmlWriter_0.WriteElementString("HFN", HTMLFileName);
			if (SizeX > 0)
			{
				xmlWriter_0.WriteElementString("WindowSizeX", SizeX.ToString());
			}
			if (SizeY > 0)
			{
				xmlWriter_0.WriteElementString("WindowSizeY", SizeY.ToString());
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101304", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static SAO_LocalHTML FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			SAO_LocalHTML sAO_LocalHTML = new SAO_LocalHTML();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "WindowSizeY":
						sAO_LocalHTML.SizeY = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "WindowSizeX":
						sAO_LocalHTML.SizeX = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "ID":
						sAO_LocalHTML._GUID = xmlNode.InnerText;
						break;
					case "HFN":
						sAO_LocalHTML.HTMLFileName = xmlNode.InnerText;
						break;
					case "Desc":
						sAO_LocalHTML.Description = xmlNode.InnerText;
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
			return sAO_LocalHTML;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101305", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			SAO_LocalHTML result = new SAO_LocalHTML();
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
		File.Copy(string_0, Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, HTMLFileName), overwrite: true);
	}

	internal string SearchWriter()
	{
		string text = "[LOADDOC";
		if (SizeX > 0)
		{
			text = text + " SizeX=" + SizeX;
		}
		if (SizeY > 0)
		{
			text = text + " SizeY=" + SizeY;
		}
		return text + "]" + _GUID.ToString() + "\\" + HTMLFileName + "[/LOADDOC]";
	}

	public override bool UseAttachment(Scenario scenario_0)
	{
		scenario_0.AddMessage(SearchWriter(), "Special Message", LoggedMessage.MessageType.SpecialMessage, 0, "", scenario_0.GetCurrentSide());
		return true;
	}

	public override bool UseAttachmentOnSide(Scenario scenario_0, Side side_0)
	{
		scenario_0.AddMessage(SearchWriter(), "Special Message", LoggedMessage.MessageType.SpecialMessage, 0, "", side_0);
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
		xmlWriter.WriteElementString("HFN", HTMLFileName);
		if (SizeX > 0)
		{
			xmlWriter.WriteElementString("WindowSizeX", SizeX.ToString());
		}
		if (SizeY > 0)
		{
			xmlWriter.WriteElementString("WindowSizeY", SizeY.ToString());
		}
		xmlWriter.WriteEndElement();
		xmlWriter.Close();
	}
}
