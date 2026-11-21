using System;
using System.Collections;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class QuickJumpSlot
{
	public int Index;

	public string LocationString;

	public int CameraAlt;

	public bool Tracking;

	public void ToXML(ref XmlWriter xmlWriter_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("QJS");
			xmlWriter_0.WriteElementString("I", Index.ToString());
			xmlWriter_0.WriteElementString("LS", LocationString);
			xmlWriter_0.WriteElementString("CA", CameraAlt.ToString());
			if (Tracking)
			{
				xmlWriter_0.WriteElementString("TR", "True");
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101018", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static QuickJumpSlot FromXML(XmlNode xmlNode_0)
	{
		QuickJumpSlot result = null;
		try
		{
			QuickJumpSlot quickJumpSlot = new QuickJumpSlot();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "TR":
						quickJumpSlot.Tracking = true;
						break;
					case "LS":
						quickJumpSlot.LocationString = xmlNode.InnerText;
						break;
					case "I":
						quickJumpSlot.Index = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "CA":
						quickJumpSlot.CameraAlt = Conversions.ToInteger(xmlNode.InnerText);
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
			result = quickJumpSlot;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101019", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}
}
