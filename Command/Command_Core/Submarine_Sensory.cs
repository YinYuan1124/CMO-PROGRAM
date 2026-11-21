using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Submarine_Sensory : ActiveUnit_Sensory
{
	public new static Submarine_Sensory FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		Submarine_Sensory result = null;
		try
		{
			Submarine_Sensory submarine_Sensory = new Submarine_Sensory(ref activeUnit_0);
			submarine_Sensory.strategyWrapper = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				string string_ = null;
				IEnumerator enumerator3 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode_ = (XmlNode)enumerator.Current;
					switch (xmlNode_.Name)
					{
					case "ObE":
						submarine_Sensory._ObeysEMCON = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "EmissionInterval":
						submarine_Sensory.m_UtilsWrapper = ActiveEmissionInterval.FromXML(ref xmlNode_);
						submarine_Sensory.m_UtilsWrapper?.Initialize(submarine_Sensory);
						break;
					case "ContactList_OffGrid":
						try
						{
							enumerator3 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode_3 = (XmlNode)enumerator3.Current;
								Contact contact = Contact.FromXML(ref xmlNode_3, ref concurrentDictionary_0);
								submarine_Sensory._ContactsList_OffGrid.Add(contact._ActualUnitID, contact);
							}
						}
						finally
						{
							if (enumerator3 is IDisposable)
							{
								(enumerator3 as IDisposable).Dispose();
							}
						}
						break;
					case "ContactList":
					case "ContactList_Local":
						try
						{
							enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator2.Current;
								ContactEntry_Local contactEntry_Local = ContactEntry_Local.FromXML(ref xmlNode_2, ref concurrentDictionary_0, ref string_);
								if (!Information.IsNothing(string_) && !submarine_Sensory._ContactsList_Local.ContainsKey(string_))
								{
									submarine_Sensory._ContactsList_Local.Add(string_, contactEntry_Local);
								}
							}
						}
						finally
						{
							if (enumerator2 is IDisposable)
							{
								(enumerator2 as IDisposable).Dispose();
							}
						}
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
			result = submarine_Sensory;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100839", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Submarine_Sensory(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}
}
