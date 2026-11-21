using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Ship_Weaponry : ActiveUnit_Weaponry
{
	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Ship_Weaponry");
			if (WeaponAssignments.Count > 0)
			{
				xmlWriter_0.WriteStartElement("WeaponAssignments");
				foreach (WeaponAssignment weaponAssignment in WeaponAssignments)
				{
					weaponAssignment.ToXML(ref xmlWriter_0, ref hashSet_0);
				}
				xmlWriter_0.WriteEndElement();
			}
			if (bool_0)
			{
				xmlWriter_0.WriteElementString("IDLZ", "True");
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100797", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Ship_Weaponry FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Ship_Weaponry ship_Weaponry = new Ship_Weaponry(ref activeUnit_0);
			ship_Weaponry.myUnit = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "WeaponAssignments":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
								WeaponAssignment weaponAssignment = WeaponAssignment.FromXML(ref xmlNode_, concurrentDictionary_0, ref activeUnit_0.ParentScen);
								if (!Information.IsNothing(weaponAssignment.Target))
								{
									ship_Weaponry.WeaponAssignments.Add(weaponAssignment);
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
					case "IDLZ":
						ship_Weaponry.bool_0 = true;
						break;
					case "HF":
						if (!Information.IsNothing(activeUnit_0.Doctrine) && Conversions.ToBoolean(xmlNode.InnerText))
						{
							activeUnit_0.Doctrine.SetWeaponControlStatus_Air(activeUnit_0.ParentScen, bool_0: false, null, bool_1: false, bool_2: false, Doctrine._WCS.Hold);
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
			return ship_Weaponry;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100798", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Ship_Weaponry result = new Ship_Weaponry(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Ship_Weaponry(ref ActiveUnit activeUnit_0)
		: base(activeUnit_0)
	{
	}
}
