using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Vehicle_Weaponry : ActiveUnit_Weaponry
{
	private Vehicle _ProducerProxy;

	[SpecialName]
	private Vehicle GetVehicle()
	{
		if (Information.IsNothing(_ProducerProxy))
		{
			_ProducerProxy = (Vehicle)myUnit;
		}
		return _ProducerProxy;
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Weaponry");
			if (WeaponAssignments.Count > 0)
			{
				xmlWriter_0.WriteStartElement("WeaponAssignments");
				foreach (WeaponAssignment weaponAssignment in WeaponAssignments)
				{
					weaponAssignment.ToXML(ref xmlWriter_0, ref hashSet_0);
				}
				xmlWriter_0.WriteEndElement();
			}
			if (LayChaffStream)
			{
				xmlWriter_0.WriteElementString("LCS", "True");
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
			exception_?.Data.Add("Error at 100568", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Vehicle_Weaponry FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Vehicle_Weaponry vehicle_Weaponry = new Vehicle_Weaponry(ref activeUnit_0);
			vehicle_Weaponry.myUnit = activeUnit_0;
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
									vehicle_Weaponry.WeaponAssignments.Add(weaponAssignment);
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
					case "LCS":
						vehicle_Weaponry.LayChaffStream = true;
						break;
					case "IDLZ":
						vehicle_Weaponry.bool_0 = true;
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
			return vehicle_Weaponry;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100569", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Vehicle_Weaponry result = new Vehicle_Weaponry(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override string RemoveWeaponFromMagazines(int int_0, bool bool_1, ref float float_0)
	{
		try
		{
			if (bool_1 && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
			{
				return "OK";
			}
			Magazine[] magazines = ((Platform)myUnit).Magazines;
			Magazine[] array = magazines;
			foreach (Magazine magazine in array)
			{
				if (magazine.Status != PlatformComponent._ComponentStatus.Destroyed && Operators.CompareString(magazine.RemoveWeapon(int_0, bool_1, ref float_0), "OK", TextCompare: false) == 0)
				{
					return "OK";
				}
			}
			if (myUnit.IsGroupMember() && !Information.IsNothing(myUnit.GetParentGroup().SharedMagazines))
			{
				Magazine[] sharedMagazines = myUnit.GetParentGroup().SharedMagazines;
				Magazine[] array2 = sharedMagazines;
				foreach (Magazine magazine2 in array2)
				{
					if (magazine2.Status != PlatformComponent._ComponentStatus.Destroyed && Operators.CompareString(magazine2.RemoveWeapon(int_0, bool_1, ref float_0), "OK", TextCompare: false) == 0)
					{
						return "OK";
					}
				}
			}
			return "弹药库中没有找到武器";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100570", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return "Error!";
		}
	}

	public Vehicle_Weaponry(ref ActiveUnit activeUnit_0)
		: base(activeUnit_0)
	{
	}

	public override void ExecuteWeaponAssignments(float float_0)
	{
		try
		{
			if ((int)Math.Round(GetVehicle().CurrentSpeed) <= 0 || GetVehicle().CanFireOnTheMove)
			{
				base.ExecuteWeaponAssignments(float_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100571", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void ExecuteWeaponSalvos(float float_0)
	{
		try
		{
			if ((int)Math.Round(GetVehicle().CurrentSpeed) <= 0 || GetVehicle().CanFireOnTheMove)
			{
				base.ExecuteWeaponSalvos(float_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101209", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
