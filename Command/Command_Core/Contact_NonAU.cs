using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Contact_NonAU : Contact_Base
{
	public Module_Unit.Unit ActualUnit;

	protected string _ActualUnitID;

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Contact_NonAU");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			if (!Information.IsNothing(ActualUnit))
			{
				xmlWriter_0.WriteElementString("ActualUnitID", ActualUnit.ObjectID);
			}
			XmlWriter obj = xmlWriter_0;
			int iDStatus = (int)_IDStatus;
			obj.WriteElementString("IDStatus", iDStatus.ToString());
			xmlWriter_0.WriteElementString("SIK", SideIsKnown.ToString());
			if (!Information.IsNothing(Type))
			{
				XmlWriter obj2 = xmlWriter_0;
				iDStatus = (int)Type;
				obj2.WriteElementString("Type", iDStatus.ToString());
			}
			xmlWriter_0.WriteElementString("AInc", _AutoIncrement.ToString());
			if (!Information.IsNothing(OriginalDetectorSide))
			{
				xmlWriter_0.WriteElementString("ODS", OriginalDetectorSide.Name);
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100499", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Contact_NonAU FromXML(ref XmlNode xmlNode_0)
	{
		Contact_NonAU contact_NonAU = new Contact_NonAU();
		try
		{
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (Misc.CreateRequest(innerText, ' '))
			{
				innerText = innerText.Replace(" ", "-");
			}
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
						if (xmlNode_0.ChildNodes.Count != 1)
						{
							contact_NonAU.ObjectID_Set(xmlNode.InnerText);
							break;
						}
						return null;
					case "ActualUnitID":
						contact_NonAU._ActualUnitID = xmlNode.InnerText;
						break;
					case "SIK":
					case "SideIsKnown":
						contact_NonAU.SideIsKnown = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "IDStatus":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							contact_NonAU._IDStatus = (IdentificationStatus)Conversions.ToShort(xmlNode.InnerText);
						}
						else
						{
							contact_NonAU._IDStatus = (IdentificationStatus)Enum.Parse(typeof(IdentificationStatus), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "ODS":
					case "OriginalDetectorSide":
						contact_NonAU._OriginalDetectorSide_Name = xmlNode.InnerText;
						break;
					case "Type":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							contact_NonAU.Type = (ContactType)Conversions.ToByte(xmlNode.InnerText);
						}
						else
						{
							contact_NonAU.Type = (ContactType)Enum.Parse(typeof(ContactType), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "AutoIncrement":
					case "AInc":
						contact_NonAU._AutoIncrement = Conversions.ToInteger(xmlNode.InnerText);
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
			return contact_NonAU;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100500", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Contact_NonAU result = new Contact_NonAU();
			ProjectData.ClearProjectError();
			return result;
		}
	}
}
