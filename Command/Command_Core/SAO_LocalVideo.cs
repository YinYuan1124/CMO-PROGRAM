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

public sealed class SAO_LocalVideo : ScenAttachmentObject
{
	[DoNotObfuscate]
	public string VideoFileName;

	private bool _InstanceFacade;

	private int _ObjectFacade;

	public bool FullScreen
	{
		get
		{
			return _InstanceFacade;
		}
		set
		{
			_InstanceFacade = value;
		}
	}

	public int Delay
	{
		get
		{
			return _ObjectFacade;
		}
		set
		{
			_ObjectFacade = value;
		}
	}

	public SAO_LocalVideo(string string_0)
		: base(string_0)
	{
		_InstanceFacade = true;
		Type = AttachmentObjectType.LocalVideo;
	}

	public SAO_LocalVideo()
	{
		_InstanceFacade = true;
		Type = AttachmentObjectType.LocalVideo;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("SAO_LocalVideo");
			xmlWriter_0.WriteElementString("ID", base.ObjectID);
			xmlWriter_0.WriteElementString("Desc", Description);
			xmlWriter_0.WriteElementString("VFN", VideoFileName);
			if (FullScreen)
			{
				xmlWriter_0.WriteElementString("FS", FullScreen.ToString());
			}
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

	public new static SAO_LocalVideo FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			SAO_LocalVideo sAO_LocalVideo = new SAO_LocalVideo();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "VFN":
						sAO_LocalVideo.VideoFileName = xmlNode.InnerText;
						break;
					case "ID":
						sAO_LocalVideo._GUID = xmlNode.InnerText;
						break;
					case "FS":
						sAO_LocalVideo.FullScreen = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "Desc":
						sAO_LocalVideo.Description = xmlNode.InnerText;
						break;
					case "Delay":
						sAO_LocalVideo.Delay = Conversions.ToInteger(xmlNode.InnerText);
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
			return sAO_LocalVideo;
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
			SAO_LocalVideo result = new SAO_LocalVideo();
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
		File.Copy(string_0, Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, VideoFileName), overwrite: true);
	}

	public override bool UseAttachment(Scenario scenario_0)
	{
		PrivateMethods.ScenEdit_LocalVideo(Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, VideoFileName), scenario_0, FullScreen, Delay);
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
		xmlWriter.WriteElementString("VFN", VideoFileName);
		xmlWriter.WriteEndElement();
		xmlWriter.Close();
	}
}
