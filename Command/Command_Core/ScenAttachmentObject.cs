using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class ScenAttachmentObject
{
	public enum AttachmentObjectType
	{
		MapOverlay_SingleImage,
		MapOverlay_Tiles,
		Audio,
		LocalVideo,
		LuaScript,
		Inst,
		localSound,
		const_7
	}

	protected string _GUID;

	public string Description;

	public AttachmentObjectType Type;

	public string ObjectID
	{
		get
		{
			if (string.IsNullOrEmpty(_GUID))
			{
				_GUID = Guid.NewGuid().ToString();
			}
			return _GUID;
		}
	}

	public string Name
	{
		get
		{
			return Description;
		}
		set
		{
			Description = value;
		}
	}

	public ScenAttachmentObject()
	{
	}

	public ScenAttachmentObject(string string_0)
	{
		_GUID = string_0;
	}

	public virtual void CopyToLocalRepository(string string_0)
	{
		throw new NotImplementedException();
	}

	public virtual void ToXML(XmlWriter xmlWriter_0, HashSet<string> hashSet_0, Scenario scenario_0)
	{
		throw new NotImplementedException();
	}

	public virtual void vmethod_0(string string_0)
	{
		throw new NotImplementedException();
	}

	public static ScenAttachmentObject FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0)
	{
		try
		{
			string name = xmlNode_0.Name;
			if (1 == 0)
			{
			}
			ScenAttachmentObject result = name switch
			{
				"SAO_OverlaySingle" => SAO_OverlaySingle.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0), 
				"SAO_LuaScript" => SAO_LuaScript.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0), 
				"SAO_LocalVideo" => SAO_LocalVideo.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0), 
				"SAO_LocalSound" => SAO_LocalSound.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0), 
				"SAO_LocalHTML" => SAO_LocalHTML.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0), 
				"SAO_Inst" => SAO_Inst.FromXML(xmlNode_0, concurrentDictionary_0, scenario_0), 
				_ => null, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101310", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public virtual bool UseAttachment(Scenario scenario_0)
	{
		throw new NotImplementedException();
	}

	public virtual bool UseAttachmentOnSide(Scenario scenario_0, Side side_0)
	{
		return UseAttachment(scenario_0);
	}

	public static ScenAttachmentObject ReadFromFolder(string string_0)
	{
		ScenAttachmentObject scenAttachmentObject = null;
		if (Directory.GetFiles(string_0).Contains(Path.Combine(string_0, "desc.xml")))
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(Path.Combine(string_0, "desc.xml"));
			string fileName = Path.GetFileName(string_0);
			AttachmentObjectType attachmentObjectType = (AttachmentObjectType)Conversions.ToInteger(xmlDocument.SelectSingleNode("/Attachment/Type").InnerText);
			string innerText = xmlDocument.SelectSingleNode("/Attachment/Desc").InnerText;
			switch (attachmentObjectType)
			{
			case AttachmentObjectType.MapOverlay_SingleImage:
				scenAttachmentObject = new SAO_OverlaySingle(fileName);
				scenAttachmentObject.Name = innerText;
				((SAO_OverlaySingle)scenAttachmentObject).ImageFileName = xmlDocument.SelectSingleNode("/Attachment/IFN").InnerText;
				break;
			case AttachmentObjectType.LocalVideo:
				scenAttachmentObject = new SAO_LocalVideo(fileName);
				scenAttachmentObject.Name = innerText;
				((SAO_LocalVideo)scenAttachmentObject).VideoFileName = xmlDocument.SelectSingleNode("/Attachment/VFN").InnerText;
				break;
			case AttachmentObjectType.LuaScript:
				scenAttachmentObject = new SAO_LuaScript(fileName);
				scenAttachmentObject.Name = innerText;
				((SAO_LuaScript)scenAttachmentObject).ScriptFileName = xmlDocument.SelectSingleNode("/Attachment/SFN").InnerText;
				break;
			case AttachmentObjectType.Inst:
				scenAttachmentObject = new SAO_Inst(fileName);
				scenAttachmentObject.Name = innerText;
				((SAO_Inst)scenAttachmentObject).InstFileName = xmlDocument.SelectSingleNode("/Attachment/IFN").InnerText;
				break;
			case AttachmentObjectType.localSound:
				scenAttachmentObject = new SAO_LocalSound(fileName);
				scenAttachmentObject.Name = innerText;
				((SAO_LocalSound)scenAttachmentObject).SoundFileName = xmlDocument.SelectSingleNode("/Attachment/FFN").InnerText;
				break;
			case AttachmentObjectType.const_7:
				scenAttachmentObject = new SAO_LocalHTML(fileName);
				scenAttachmentObject.Name = innerText;
				((SAO_LocalHTML)scenAttachmentObject).HTMLFileName = xmlDocument.SelectSingleNode("/Attachment/HFN").InnerText;
				break;
			}
		}
		return scenAttachmentObject;
	}
}
