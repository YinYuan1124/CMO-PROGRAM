using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Command_Core.Lua;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class SAO_LocalSound : ScenAttachmentObject
{
	[DoNotObfuscate]
	public string SoundFileName;

	private bool ruleFacade;

	private int m_CollectionFacade;

	public int Delay
	{
		get
		{
			return m_CollectionFacade;
		}
		set
		{
			m_CollectionFacade = value;
		}
	}

	public SAO_LocalSound(string string_0)
		: base(string_0)
	{
		ruleFacade = true;
		Type = AttachmentObjectType.localSound;
	}

	public SAO_LocalSound()
	{
		ruleFacade = true;
		Type = AttachmentObjectType.localSound;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("SAO_LocalSound");
			xmlWriter_0.WriteElementString("ID", base.ObjectID);
			xmlWriter_0.WriteElementString("Desc", Description);
			xmlWriter_0.WriteElementString("FFN", SoundFileName);
			if (Delay > 0)
			{
				xmlWriter_0.WriteElementString("Delay", Delay.ToString());
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

	public new static SAO_LocalSound FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			SAO_LocalSound sAO_LocalSound = new SAO_LocalSound();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "ID":
						sAO_LocalSound._GUID = xmlNode.InnerText;
						break;
					case "FFN":
						sAO_LocalSound.SoundFileName = xmlNode.InnerText;
						break;
					case "Desc":
						sAO_LocalSound.Description = xmlNode.InnerText;
						break;
					case "Delay":
						sAO_LocalSound.Delay = Conversions.ToInteger(xmlNode.InnerText);
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
			return sAO_LocalSound;
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
			SAO_LocalSound result = new SAO_LocalSound();
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
		File.Copy(string_0, Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, SoundFileName), overwrite: true);
	}

	public override bool UseAttachment(Scenario scenario_0)
	{
		PrivateMethods.ScenEdit_LocalSound(Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, SoundFileName), Delay);
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
		xmlWriter.WriteElementString("FFN", SoundFileName);
		xmlWriter.WriteEndElement();
		xmlWriter.Close();
	}
}
