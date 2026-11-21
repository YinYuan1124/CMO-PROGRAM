using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Group_Weaponry : ActiveUnit_Weaponry
{
	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Group_Weaponry");
			xmlWriter_0.WriteStartElement("WeaponAssignments");
			foreach (WeaponAssignment weaponAssignment in WeaponAssignments)
			{
				weaponAssignment.ToXML(ref xmlWriter_0, ref hashSet_0);
			}
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100625", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Group_Weaponry FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Group_Weaponry group_Weaponry = new Group_Weaponry(ref activeUnit_0);
			group_Weaponry.myUnit = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					string name = xmlNode.Name;
					if (Operators.CompareString(name, "WeaponAssignments", TextCompare: false) == 0)
					{
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
								WeaponAssignment weaponAssignment = WeaponAssignment.FromXML(ref xmlNode_, concurrentDictionary_0, ref activeUnit_0.ParentScen);
								if (!Information.IsNothing(weaponAssignment.Target))
								{
									group_Weaponry.WeaponAssignments.Add(weaponAssignment);
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
					}
					else if (Operators.CompareString(name, "HF", TextCompare: false) == 0 && !Information.IsNothing(activeUnit_0.Doctrine) && Conversions.ToBoolean(xmlNode.InnerText))
					{
						activeUnit_0.Doctrine.SetWeaponControlStatus_Air(activeUnit_0.ParentScen, bool_0: false, null, bool_1: false, bool_2: false, Doctrine._WCS.Hold);
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
			return group_Weaponry;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100626", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Group_Weaponry result = new Group_Weaponry(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Group_Weaponry(ref ActiveUnit activeUnit_0)
		: base(activeUnit_0)
	{
	}

	public override int HowManyOfThisWeaponOnMagazines(int int_0)
	{
		int num = 0;
		try
		{
			foreach (Platform value in ((Group)myUnit).Units.Values)
			{
				Magazine[] magazines = value.Magazines;
				for (int i = 0; i < magazines.Length; i++)
				{
					foreach (WeaponRec weapon in magazines[i].Weapons)
					{
						if (weapon.GetReferenceWeapon(myUnit.ParentScen).DBID == int_0)
						{
							num += weapon.CurrentLoad;
						}
					}
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100628", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	public override string RemoveWeaponFromMagazines(int int_0, bool bool_1, ref float float_0)
	{
		if (myUnit == null)
		{
			return "Error";
		}
		if (Information.IsNothing(myUnit.ParentScen))
		{
			return "Error";
		}
		try
		{
			if (bool_1 && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
			{
				return "OK";
			}
			if (!Information.IsNothing(((Group)myUnit).SharedMagazines))
			{
				Magazine[] sharedMagazines = ((Group)myUnit).SharedMagazines;
				Magazine[] array = sharedMagazines;
				foreach (Magazine magazine in array)
				{
					if (!Information.IsNothing(magazine) && Operators.CompareString(magazine.RemoveWeapon(int_0, bool_1, ref float_0), "OK", TextCompare: false) == 0)
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
			exception_?.Data.Add("Error at 100629", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return "Error";
		}
	}

	public override string AddWeaponToMagazines(int int_0, bool bool_1, bool bool_2, bool bool_3 = false)
	{
		try
		{
			if (Information.IsNothing(((Group)myUnit).SharedMagazines))
			{
				return "Failure";
			}
			Magazine[] sharedMagazines = ((Group)myUnit).SharedMagazines;
			for (int i = 0; i < sharedMagazines.Length; i = checked(i + 1))
			{
				if (Operators.CompareString(sharedMagazines[i].AddWeapon(int_0), "OK", TextCompare: false) == 0)
				{
					return "OK";
				}
			}
			if (((Group)myUnit).SharedMagazines.Length == 0)
			{
				return "Failure";
			}
			((Group)myUnit).SharedMagazines[0].Weapons.Add(new WeaponRec(ref myUnit.ParentScen, int_0, 1, 10000, 1, 1, bool_0: false, bool_1: false));
			return "OK";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100630", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return "Failure";
		}
	}

	public override ActiveUnit._ActiveUnitWeaponState IsWinchesterOrShotgun()
	{
		Group group = (Group)myUnit;
		try
		{
			if (group.Units.Count > 0)
			{
				Doctrine._WeaponStateRTB? winchesterShotgunRTB = group.Doctrine.GetWinchesterShotgunRTB(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				if (!winchesterShotgunRTB.HasValue)
				{
					return ActiveUnit._ActiveUnitWeaponState.None;
				}
				bool flag = true;
				bool flag2 = false;
				byte? b;
				foreach (ActiveUnit item in new List<ActiveUnit>(group.Units.Values))
				{
					if (item == null)
					{
						continue;
					}
					switch (item.IsAircraft ? ((Aircraft)item).Weaponry.IsWinchesterOrShotgun() : item.Weaponry.IsWinchesterOrShotgun())
					{
					case ActiveUnit._ActiveUnitWeaponState.IsWinchester:
						b = (byte?)winchesterShotgunRTB;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						break;
					case ActiveUnit._ActiveUnitWeaponState.IsShotgun:
						flag2 = true;
						break;
					case ActiveUnit._ActiveUnitWeaponState.None:
					case ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO:
					case ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO:
						flag = false;
						break;
					}
				}
				b = (byte?)winchesterShotgunRTB;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					if (flag)
					{
						if (flag2)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
						}
						return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					}
				}
				else
				{
					b = (byte?)winchesterShotgunRTB;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault() && flag2)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
					}
				}
			}
			return ActiveUnit._ActiveUnitWeaponState.None;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}
}
