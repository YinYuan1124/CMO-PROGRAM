using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class SAO_OverlaySingle : ScenAttachmentObject
{
	public delegate void UseMapOverlayEventHandler(string theFullFileName);

	[DoNotObfuscate]
	public string ImageFileName;

	[CompilerGenerated]
	private static UseMapOverlayEventHandler parameterFacade;

	public static event UseMapOverlayEventHandler UseMapOverlay
	{
		[CompilerGenerated]
		add
		{
			UseMapOverlayEventHandler useMapOverlayEventHandler = parameterFacade;
			UseMapOverlayEventHandler useMapOverlayEventHandler2;
			do
			{
				useMapOverlayEventHandler2 = useMapOverlayEventHandler;
				UseMapOverlayEventHandler value2 = (UseMapOverlayEventHandler)Delegate.Combine(useMapOverlayEventHandler2, value);
				useMapOverlayEventHandler = Interlocked.CompareExchange(ref parameterFacade, value2, useMapOverlayEventHandler2);
			}
			while ((object)useMapOverlayEventHandler != useMapOverlayEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			UseMapOverlayEventHandler useMapOverlayEventHandler = parameterFacade;
			UseMapOverlayEventHandler useMapOverlayEventHandler2;
			do
			{
				useMapOverlayEventHandler2 = useMapOverlayEventHandler;
				UseMapOverlayEventHandler value2 = (UseMapOverlayEventHandler)Delegate.Remove(useMapOverlayEventHandler2, value);
				useMapOverlayEventHandler = Interlocked.CompareExchange(ref parameterFacade, value2, useMapOverlayEventHandler2);
			}
			while ((object)useMapOverlayEventHandler != useMapOverlayEventHandler2);
		}
	}

	public SAO_OverlaySingle(string string_0)
		: base(string_0)
	{
		Type = AttachmentObjectType.MapOverlay_SingleImage;
	}

	public SAO_OverlaySingle()
	{
		Type = AttachmentObjectType.MapOverlay_SingleImage;
	}

	public override void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("SAO_OverlaySingle");
			xmlWriter_0.WriteElementString("ID", base.ObjectID);
			xmlWriter_0.WriteElementString("Desc", Description);
			xmlWriter_0.WriteElementString("IFN", ImageFileName);
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101308", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static SAO_OverlaySingle FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		SAO_OverlaySingle result = null;
		try
		{
			SAO_OverlaySingle sAO_OverlaySingle = new SAO_OverlaySingle();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "IFN":
						sAO_OverlaySingle.ImageFileName = xmlNode.InnerText;
						break;
					case "ID":
						sAO_OverlaySingle._GUID = xmlNode.InnerText;
						break;
					case "Desc":
						sAO_OverlaySingle.Description = xmlNode.InnerText;
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
			result = sAO_OverlaySingle;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101309", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
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
		string text = Misc.CalculateRequest(string_0);
		if (string.IsNullOrEmpty(text))
		{
			GameGeneral.ResolveBridge("找不到适合图像的地理参考文件！", null);
			return;
		}
		Directory.CreateDirectory(Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID));
		File.Copy(string_0, Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, ImageFileName), overwrite: true);
		File.Copy(text, Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, Path.GetFileName(text)), overwrite: true);
	}

	public override bool UseAttachment(Scenario scenario_0)
	{
		parameterFacade?.Invoke(Path.Combine(GameGeneral.AttachmentRepoPath, base.ObjectID, ImageFileName));
		return false;
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
		xmlWriter.WriteElementString("IFN", ImageFileName);
		xmlWriter.WriteEndElement();
		xmlWriter.Close();
	}
}
