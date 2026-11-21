using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class WeaponAssignment : ScenarioObject
{
	public Weapon Weapon;

	public int Quantity;

	public Contact Target;

	public DateTime ScheduledFireTime;

	public List<Waypoint> PlottedCourse;

	public bool ManualFire;

	public void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("WeaponAssignment");
			xmlWriter_0.WriteElementString("ID", ObjectID);
			if (hashSet_0.Contains(ObjectID))
			{
				xmlWriter_0.WriteEndElement();
				return;
			}
			hashSet_0.Add(ObjectID);
			xmlWriter_0.WriteElementString("Weapon", Weapon.DBID.ToString());
			xmlWriter_0.WriteElementString("Quantity", Quantity.ToString());
			xmlWriter_0.WriteElementString("Target", Target.ObjectID);
			xmlWriter_0.WriteElementString("ScheduledFireTime", ScheduledFireTime.ToBinary().ToString());
			xmlWriter_0.WriteStartElement("PlottedCourse");
			foreach (Waypoint item in PlottedCourse)
			{
				item.ToXML(ref xmlWriter_0, ref hashSet_0);
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteElementString("ManualFire", ManualFire.ToString());
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101072", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static WeaponAssignment FromXML(ref XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		try
		{
			WeaponAssignment weaponAssignment = new WeaponAssignment();
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
					case "ID":
						weaponAssignment.ObjectID_Set(xmlNode.InnerText);
						break;
					case "ManualFire":
						weaponAssignment.ManualFire = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "Quantity":
						weaponAssignment.Quantity = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "Weapon":
						weaponAssignment.Weapon = scenario_0.Cache_GetWeapon(Conversions.ToInteger(xmlNode.InnerText));
						break;
					case "Target":
						if (xmlNode.InnerText.StartsWith("Aimpoint_"))
						{
							weaponAssignment.Target = AimpointContact.FromString(xmlNode.InnerText);
						}
						else
						{
							weaponAssignment.Target = Contact.FromXML(xmlNode.InnerText, ref concurrentDictionary_0);
						}
						break;
					case "ScheduledFireTime":
						weaponAssignment.ScheduledFireTime = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
						break;
					case "PlottedCourse":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
								Waypoint item = Waypoint.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0);
								weaponAssignment.PlottedCourse.Add(item);
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
			return weaponAssignment;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101073", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			WeaponAssignment result = new WeaponAssignment();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private WeaponAssignment()
	{
		PlottedCourse = new List<Waypoint>();
	}

	public WeaponAssignment(ref Weapon weapon_0, int int_0, ref Contact contact_0, ref bool bool_0, [Optional][DateTimeConstant(0L)] DateTime theScheduledTime, List<Waypoint> list_0 = null)
	{
		PlottedCourse = new List<Waypoint>();
		try
		{
			Weapon = weapon_0;
			Quantity = int_0;
			Target = contact_0;
			ManualFire = bool_0;
			if (!Information.IsNothing(theScheduledTime))
			{
				ScheduledFireTime = theScheduledTime;
			}
			if (!Information.IsNothing(list_0))
			{
				PlottedCourse = list_0;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101074", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool IsIdenticalToThisWA(WeaponAssignment weaponAssignment_0)
	{
		if (Weapon.DBID == weaponAssignment_0.Weapon.DBID)
		{
			if (Target == weaponAssignment_0.Target)
			{
				if (Information.IsNothing(ScheduledFireTime) && !Information.IsNothing(weaponAssignment_0.ScheduledFireTime))
				{
					return false;
				}
				if (!Information.IsNothing(ScheduledFireTime) && Information.IsNothing(weaponAssignment_0.ScheduledFireTime))
				{
					return false;
				}
				if (DateTime.Compare(ScheduledFireTime, weaponAssignment_0.ScheduledFireTime) == 0)
				{
					if (ManualFire == weaponAssignment_0.ManualFire)
					{
						if (Information.IsNothing(PlottedCourse) && !Information.IsNothing(weaponAssignment_0.PlottedCourse))
						{
							return false;
						}
						if (!Information.IsNothing(PlottedCourse) && Information.IsNothing(weaponAssignment_0.PlottedCourse))
						{
							return false;
						}
						if (!Information.IsNothing(PlottedCourse) && (PlottedCourse.Count != 0 || weaponAssignment_0.PlottedCourse.Count != 0) && PlottedCourse != weaponAssignment_0.PlottedCourse)
						{
							return false;
						}
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		return false;
	}
}
