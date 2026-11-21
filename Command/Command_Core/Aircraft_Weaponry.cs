using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Aircraft_Weaponry : ActiveUnit_Weaponry
{
	private Aircraft composerObserver;

	[SpecialName]
	private Aircraft GetAircraft()
	{
		if (Information.IsNothing(composerObserver))
		{
			composerObserver = (Aircraft)myUnit;
		}
		return composerObserver;
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
			exception_?.Data.Add("Error at 100472", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Aircraft_Weaponry FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Aircraft_Weaponry aircraft_Weaponry = new Aircraft_Weaponry(ref activeUnit_0);
			aircraft_Weaponry.myUnit = activeUnit_0;
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
									aircraft_Weaponry.WeaponAssignments.Add(weaponAssignment);
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
						aircraft_Weaponry.LayChaffStream = true;
						break;
					case "IDLZ":
						aircraft_Weaponry.bool_0 = true;
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
			return aircraft_Weaponry;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100473", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Aircraft_Weaponry result = new Aircraft_Weaponry(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Aircraft_Weaponry(ref ActiveUnit activeUnit_0)
		: base(activeUnit_0)
	{
	}

	public void JettisonSpecificOrdnance(bool bool_1, int int_0)
	{
		if (!bool_1 && !myUnit.ParentScen.FifthSecondIsChangingOnThisPulse)
		{
			return;
		}
		if (!Information.IsNothing(GetAircraft().Loadout))
		{
			Dictionary<Weapon, int> dictionary = new Dictionary<Weapon, int>();
			WeaponRec[] weapons = GetAircraft().Loadout.Weapons;
			WeaponRec[] array = weapons;
			foreach (WeaponRec weaponRec in array)
			{
				if (weaponRec.CurrentLoad != 0 && weaponRec.int_0 == int_0)
				{
					Weapon referenceWeapon = weaponRec.GetReferenceWeapon(GetAircraft().ParentScen);
					if (dictionary.ContainsKey(referenceWeapon))
					{
						dictionary[referenceWeapon] += weaponRec.CurrentLoad;
					}
					else
					{
						dictionary.Add(referenceWeapon, weaponRec.CurrentLoad);
					}
					weaponRec.CurrentLoad = 0;
				}
			}
			if (dictionary.Count > 0)
			{
				List<string> list = new List<string>();
				foreach (KeyValuePair<Weapon, int> item in dictionary)
				{
					try
					{
						GetAircraft().GetUnitSide().AAR.AddToExpenditures(item.Key.DBID, item.Value);
						list.Add(Conversions.ToString(item.Value) + "x " + item.Key.Name);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
				string string_ = GetAircraft().Name + " (" + GetAircraft().UnitClass + ") has jettisoned stores (" + string.Join(", ", list) + ") ";
				string string_2 = GetAircraft().Name + " jettisoned stores";
				GetAircraft().AddMessage(string_, string_2, LoggedMessage.MessageType.UnitAI, 0, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
				ClearCachedWeapons();
			}
		}
		if (GetAircraft().Loadout.PayloadWeight > 0)
		{
			AdjustLoadoutPayloadWeight();
		}
	}

	public void JettisonOrdnance(bool bool_1, bool bool_2, bool bool_3, bool bool_4, bool bool_5, bool bool_6, bool bool_7)
	{
		if (!bool_1 && !myUnit.ParentScen.FifthSecondIsChangingOnThisPulse)
		{
			return;
		}
		if (!Information.IsNothing(GetAircraft().Loadout))
		{
			Dictionary<Weapon, int> dictionary = new Dictionary<Weapon, int>();
			WeaponRec[] weapons = GetAircraft().Loadout.Weapons;
			WeaponRec[] array = weapons;
			foreach (WeaponRec weaponRec in array)
			{
				if (weaponRec.CurrentLoad == 0 || (!bool_7 && weaponRec.InternalWeapons))
				{
					continue;
				}
				Weapon referenceWeapon = weaponRec.GetReferenceWeapon(GetAircraft().ParentScen);
				if (referenceWeapon.Type != Weapon._WeaponType.FerryTank && (bool_5 || !referenceWeapon.IsAAW) && (bool_6 || referenceWeapon.Type != Weapon._WeaponType.SensorPod) && (bool_2 || referenceWeapon.Type != Weapon._WeaponType.DropTank) && (bool_3 || !referenceWeapon.IsUnguidedBallisticWeapon) && (bool_4 || !referenceWeapon.IsGuidedWeapon()))
				{
					if (dictionary.ContainsKey(referenceWeapon))
					{
						dictionary[referenceWeapon] += weaponRec.CurrentLoad;
					}
					else
					{
						dictionary.Add(referenceWeapon, weaponRec.CurrentLoad);
					}
					weaponRec.CurrentLoad = 0;
				}
			}
			if (dictionary.Count > 0)
			{
				List<string> list = new List<string>();
				foreach (KeyValuePair<Weapon, int> item in dictionary)
				{
					GetAircraft().GetUnitSide().AAR.AddToWeaponsLost(item.Key.DBID, item.Value);
					list.Add(Conversions.ToString(item.Value) + "x " + item.Key.Name);
				}
				GetAircraft().AddMessage(GetAircraft().Name + " (" + GetAircraft().UnitClass + "丢弃了外部弹药储备（" + string.Join(", ", list) + ") ", GetAircraft().Name + " jettisoning", LoggedMessage.MessageType.UnitAI, 0, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
				ClearCachedWeapons();
			}
		}
		if (GetAircraft().Loadout.PayloadWeight > 0)
		{
			AdjustLoadoutPayloadWeight();
		}
	}

	public override void ReduceTimesToFire(float float_0)
	{
		try
		{
			base.ReduceTimesToFire(float_0);
			if ((object)myUnit.GetType() != typeof(Aircraft) || Information.IsNothing(GetAircraft().Loadout))
			{
				return;
			}
			WeaponRec[] weapons = GetAircraft().Loadout.Weapons;
			WeaponRec[] array = weapons;
			foreach (WeaponRec weaponRec in array)
			{
				if (weaponRec.TimeToFire > 0f)
				{
					weaponRec.TimeToFire -= float_0;
					if (weaponRec.TimeToFire < 0f)
					{
						weaponRec.TimeToFire = 0f;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100474", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override List<Weapon> AllDistinctWeaponsAboard_Actual()
	{
		if (Information.IsNothing(_AllDistinctWeaponsAboard_Actual))
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			List<Weapon> list = new List<Weapon>();
			try
			{
				ObservableList<Mount> mounts = myUnit.Mounts;
				if (mounts.Count > 0)
				{
					int num = mounts.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						Mount mount = mounts[i];
						ObservableList<WeaponRec> mountWeapons = mount.MountWeapons;
						int num2 = mountWeapons.Count - 1;
						for (int j = 0; j <= num2; j++)
						{
							WeaponRec weaponRec = mountWeapons[j];
							if (weaponRec.CurrentLoad > 0 && !dictionary.ContainsKey(weaponRec.int_0))
							{
								dictionary.Add(weaponRec.int_0, 0);
								list.Add(weaponRec.GetReferenceWeapon(myUnit.ParentScen));
							}
						}
						ObservableList<WeaponRec> weapons = mount.MountMagazine.Weapons;
						int num3 = weapons.Count - 1;
						for (int k = 0; k <= num3; k++)
						{
							WeaponRec weaponRec2 = weapons[k];
							if (weaponRec2.CurrentLoad > 0 && !dictionary.ContainsKey(weaponRec2.int_0))
							{
								dictionary.Add(weaponRec2.int_0, 0);
								list.Add(weaponRec2.GetReferenceWeapon(myUnit.ParentScen));
							}
						}
					}
				}
				Magazine[] sharedMagazines = myUnit.SharedMagazines;
				if (!Information.IsNothing(sharedMagazines))
				{
					int num4 = sharedMagazines.Length - 1;
					for (int l = 0; l <= num4; l++)
					{
						ObservableList<WeaponRec> weapons2 = sharedMagazines[l].Weapons;
						int num5 = weapons2.Count - 1;
						for (int m = 0; m <= num5; m++)
						{
							WeaponRec weaponRec3 = weapons2[m];
							if (weaponRec3.CurrentLoad > 0 && !dictionary.ContainsKey(weaponRec3.int_0))
							{
								dictionary.Add(weaponRec3.int_0, 0);
								list.Add(weaponRec3.GetReferenceWeapon(myUnit.ParentScen));
							}
						}
					}
				}
				if (!Information.IsNothing(GetAircraft().Loadout))
				{
					WeaponRec[] weapons3 = GetAircraft().Loadout.Weapons;
					int num6 = weapons3.Length - 1;
					for (int n = 0; n <= num6; n++)
					{
						WeaponRec weaponRec4 = weapons3[n];
						if (weaponRec4.CurrentLoad > 0 && !dictionary.ContainsKey(weaponRec4.int_0))
						{
							dictionary.Add(weaponRec4.int_0, 0);
							list.Add(weaponRec4.GetReferenceWeapon(myUnit.ParentScen));
						}
					}
				}
				_AllDistinctWeaponsAboard_Actual = list;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100288", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		return _AllDistinctWeaponsAboard_Actual;
	}

	public ActiveUnit._ActiveUnitWeaponState CheckWinchester(ref List<WeaponRec> list_0, bool bool_1, bool bool_2)
	{
		bool flag = false;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		float num5 = 0f;
		if (!Information.IsNothing(list_0) && list_0.Count > 0)
		{
			if (!Information.IsNothing(list_0) && list_0.Count > 0)
			{
				foreach (WeaponRec item in list_0)
				{
					if (bool_2 && (!bool_2 || item.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun))
					{
						if (bool_1)
						{
							num += item.CurrentLoad;
							num3 += item.MaxLoad;
							float maxRange_NoTargetType = item.GetReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
							if (item.CurrentLoad > 0 && num5 < maxRange_NoTargetType)
							{
								num5 = maxRange_NoTargetType;
							}
						}
					}
					else
					{
						num2 += item.CurrentLoad;
						num4 += item.MaxLoad;
					}
				}
			}
			if (num == 0 && num2 == 0)
			{
				return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
			}
			if (num2 == 0)
			{
				flag = true;
			}
		}
		if (flag)
		{
			if (myUnit.GetUnitSide().NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtAnyTarget(ref myUnit) <= 0)
			{
				Contact[] targets_ReadOnly = myUnit.AI.Targets_ReadOnly;
				Contact[] array = targets_ReadOnly;
				foreach (Contact contact_ in array)
				{
					ActiveUnit_AI.TargetingEntry._TargetingBehavior targetingBehavior = myUnit.AI.TargetingBehaviorForThisTarget(contact_);
					if (targetingBehavior == ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted || targetingBehavior == ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
					}
				}
				float num6;
				if (myUnit.AI.Targets_ReadOnly.Length == 1)
				{
					num6 = Module_Unit.RangeToUnit_Horiz(myUnit, myUnit.AI.Targets_ReadOnly[0]);
				}
				else
				{
					IEnumerable<Contact> source = myUnit.AI.Targets_ReadOnly.OrderBy((Contact contact_0) => Module_Unit.RangeToUnit_Horiz_Angular(myUnit, contact_0));
					num6 = Module_Unit.RangeToUnit_Horiz(myUnit, source.ElementAtOrDefault(0));
				}
				if (num > 0 && num5 < 5f)
				{
					num5 = 5f;
				}
				if (!(num5 <= 0f) && (double)num6 > Math.Max((double)num5 * 1.2, num5 + 5f))
				{
					return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
				}
				if (!myUnit.IsRTB && myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsBingo && myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsJoker)
				{
					return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
				}
				return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
			}
			return ActiveUnit._ActiveUnitWeaponState.None;
		}
		return ActiveUnit._ActiveUnitWeaponState.None;
	}

	public ActiveUnit._ActiveUnitWeaponState CheckShotgunBVR(ref List<WeaponRec> list_0, ref bool bool_1, bool bool_2, bool bool_3, bool bool_4, bool bool_5, bool bool_6)
	{
		bool flag = false;
		bool flag2 = false;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		float num7 = 0f;
		float num8 = 0f;
		if (!Information.IsNothing(list_0) && list_0.Count > 0)
		{
			foreach (WeaponRec item in list_0)
			{
				if (!bool_6 || (bool_6 && item.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun))
				{
					num4 += item.CurrentLoad;
					num6 += item.MaxLoad;
				}
				if (bool_1)
				{
					if (!item.GetReferenceWeapon(myUnit.ParentScen).ReadReponse() && (!bool_3 || !item.GetReferenceWeapon(myUnit.ParentScen).DisableReponse()))
					{
						if (item.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun)
						{
							if (bool_5)
							{
								num3 += item.CurrentLoad;
								float maxRange_NoTargetType = item.GetReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
								if (item.CurrentLoad > 0 && num8 < maxRange_NoTargetType)
								{
									num8 = maxRange_NoTargetType;
								}
							}
						}
						else if (bool_4)
						{
							num2 += item.CurrentLoad;
							float maxRange_NoTargetType2 = item.GetReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
							if (item.CurrentLoad > 0 && num8 < maxRange_NoTargetType2)
							{
								num8 = maxRange_NoTargetType2;
							}
						}
					}
					else
					{
						if (!bool_2 && item.CurrentLoad > 0)
						{
							return ActiveUnit._ActiveUnitWeaponState.None;
						}
						num += item.CurrentLoad;
						num5 += item.MaxLoad;
						float maxRange_NoTargetType3 = item.GetReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
						if (item.CurrentLoad > 0 && num7 < maxRange_NoTargetType3)
						{
							num7 = maxRange_NoTargetType3;
						}
					}
				}
				else if (!item.GetReferenceWeapon(myUnit.ParentScen).UpdateReponse() && (!bool_3 || item.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun))
				{
					if (bool_4)
					{
						num2 += item.CurrentLoad;
						float maxRange_NoTargetType4 = item.GetReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
						if (item.CurrentLoad > 0 && num8 < maxRange_NoTargetType4)
						{
							num8 = maxRange_NoTargetType4;
						}
					}
				}
				else
				{
					if (!bool_2 && item.CurrentLoad > 0)
					{
						return ActiveUnit._ActiveUnitWeaponState.None;
					}
					num += item.CurrentLoad;
					num5 += item.MaxLoad;
					float maxRange_NoTargetType5 = item.GetReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
					if (item.CurrentLoad > 0 && num7 < maxRange_NoTargetType5)
					{
						num7 = maxRange_NoTargetType5;
					}
				}
			}
			if (num3 == 0 && num2 == 0 && num == 0)
			{
				return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
			}
			if (bool_2)
			{
				if (num < num5)
				{
					flag2 = true;
				}
			}
			else if (num == 0)
			{
				flag2 = true;
			}
			if (num4 == 0)
			{
				flag = true;
			}
		}
		if (flag || flag2)
		{
			if (myUnit.AI.Targets_ReadOnly.Length == 0)
			{
				return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
			}
			if (myUnit.GetUnitSide().NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtAnyTarget(ref myUnit) <= 0)
			{
				Contact[] targets_ReadOnly = myUnit.AI.Targets_ReadOnly;
				Contact[] array = targets_ReadOnly;
				foreach (Contact contact_ in array)
				{
					ActiveUnit_AI.TargetingEntry._TargetingBehavior targetingBehavior = myUnit.AI.TargetingBehaviorForThisTarget(contact_);
					if (targetingBehavior == ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted || targetingBehavior == ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc)
					{
						if (flag)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
						}
						if (flag2)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
						}
					}
				}
				float num9;
				if (myUnit.AI.Targets_ReadOnly.Length == 1)
				{
					num9 = Module_Unit.RangeToUnit_Horiz(myUnit, myUnit.AI.Targets_ReadOnly[0]);
				}
				else
				{
					IEnumerable<Contact> source = myUnit.AI.Targets_ReadOnly.OrderBy((Contact contact_0) => Module_Unit.RangeToUnit_Horiz_Angular(myUnit, contact_0));
					num9 = Module_Unit.RangeToUnit_Horiz(myUnit, source.ElementAtOrDefault(0));
				}
				if ((bool_5 || (!bool_3 && bool_4)) && (num2 > 0 || num3 > 0) && num8 < 5f)
				{
					num8 = 5f;
				}
				if (num > 0 && num7 > 0f)
				{
					if ((double)num9 > Math.Max((double)num7 * 1.2, num7 + 5f))
					{
						if (flag)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						if (flag2)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
						}
					}
				}
				else
				{
					if (num8 <= 0f)
					{
						if (flag)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
					}
					if ((double)num9 > Math.Max((double)num8 * 1.2, num8 + 5f))
					{
						if (flag)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						if (flag2)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
						}
					}
				}
				if (!myUnit.IsRTB && myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsBingo && myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsJoker)
				{
					if (flag)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
					}
					if (myUnit.Doctrine.GetIsShotgunSingleEngagment(myUnit.ParentScen))
					{
						return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
					}
					return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
				}
				if (flag)
				{
					return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
				}
				return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
			}
			return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
		}
		return ActiveUnit._ActiveUnitWeaponState.None;
	}

	public ActiveUnit._ActiveUnitWeaponState CheckShotgunWVR(ref List<WeaponRec> list_0, ref bool bool_1, bool bool_2, bool bool_3, bool bool_4)
	{
		bool flag = false;
		bool flag2 = false;
		int num = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		float num9 = 0f;
		float num10 = 0f;
		if (!Information.IsNothing(list_0) && list_0.Count > 0)
		{
			foreach (WeaponRec item in list_0)
			{
				if (!bool_4 || (bool_4 && item.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun))
				{
					num5 += item.CurrentLoad;
					num8 += item.MaxLoad;
				}
				if (bool_1)
				{
					if (item.GetReferenceWeapon(myUnit.ParentScen).IsAAW_GuidedMissile)
					{
						if (!bool_2 && item.CurrentLoad > 0)
						{
							return ActiveUnit._ActiveUnitWeaponState.None;
						}
						if (item.GetReferenceWeapon(myUnit.ParentScen).ReadReponse())
						{
							num += item.CurrentLoad;
							num6 += item.MaxLoad;
						}
						else
						{
							num3 += item.CurrentLoad;
							num7 += item.MaxLoad;
						}
						float maxRange_NoTargetType = item.GetReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
						if (num9 < maxRange_NoTargetType)
						{
							num9 = maxRange_NoTargetType;
						}
					}
					else if (bool_3)
					{
						num4 += item.CurrentLoad;
						float maxRange_NoTargetType2 = item.GetReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
						if (item.CurrentLoad > 0 && num10 < maxRange_NoTargetType2)
						{
							num10 = maxRange_NoTargetType2;
						}
					}
				}
				else
				{
					if (!bool_2 && item.CurrentLoad > 0)
					{
						return ActiveUnit._ActiveUnitWeaponState.None;
					}
					if (item.GetReferenceWeapon(myUnit.ParentScen).UpdateReponse())
					{
						num += item.CurrentLoad;
						num6 += item.MaxLoad;
					}
					else
					{
						num3 += item.CurrentLoad;
						num7 += item.MaxLoad;
					}
					float maxRange_NoTargetType3 = item.GetReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
					if (num9 < maxRange_NoTargetType3)
					{
						num9 = maxRange_NoTargetType3;
					}
				}
			}
			if (num4 == 0 && num3 == 0 && num == 0)
			{
				return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
			}
			if (bool_2)
			{
				if (num3 < num7)
				{
					flag2 = true;
				}
			}
			else if (num3 == 0)
			{
				flag2 = true;
			}
			if (num7 == 0 && num == 0)
			{
				flag = true;
			}
			if (num5 == 0)
			{
				flag = true;
			}
		}
		if (flag || flag2)
		{
			if (myUnit.AI.Targets_ReadOnly.Length == 0)
			{
				return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
			}
			if (myUnit.GetUnitSide().NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtAnyTarget(ref myUnit) <= 0)
			{
				Contact[] targets_ReadOnly = myUnit.AI.Targets_ReadOnly;
				Contact[] array = targets_ReadOnly;
				foreach (Contact contact_ in array)
				{
					ActiveUnit_AI.TargetingEntry._TargetingBehavior targetingBehavior = myUnit.AI.TargetingBehaviorForThisTarget(contact_);
					if (targetingBehavior == ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted || targetingBehavior == ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc)
					{
						if (flag)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
						}
						if (flag2)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
						}
					}
				}
				float num2;
				if (myUnit.AI.Targets_ReadOnly.Length == 1)
				{
					num2 = Module_Unit.RangeToUnit_Horiz(myUnit, myUnit.AI.Targets_ReadOnly[0]);
				}
				else
				{
					IEnumerable<Contact> source = myUnit.AI.Targets_ReadOnly.OrderBy((Contact contact_0) => Module_Unit.RangeToUnit_Horiz_Angular(myUnit, contact_0));
					num2 = Module_Unit.RangeToUnit_Horiz(myUnit, source.ElementAtOrDefault(0));
				}
				if (bool_3 && num4 > 0 && num10 < 5f)
				{
					num10 = 5f;
				}
				if (num3 > 0 && num9 < 5f)
				{
					num9 = 5f;
				}
				if ((num7 <= 0 && num6 <= 0) || num9 <= 0f)
				{
					if (num10 > 0f && (double)num2 > Math.Max((double)num10 * 1.2, num10 + 5f))
					{
						if (flag)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						if (flag2)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
						}
					}
				}
				else if ((double)num2 > Math.Max((double)num9 * 1.2, num9 + 5f))
				{
					if (flag)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					}
					if (flag2)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
					}
				}
				if (!myUnit.IsRTB && myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsBingo && myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsJoker)
				{
					if (flag)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
					}
					return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
				}
				if (flag)
				{
					return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
				}
				return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
			}
			return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
		}
		return ActiveUnit._ActiveUnitWeaponState.None;
	}

	public ActiveUnit._ActiveUnitWeaponState CheckShotgunGun(ref List<WeaponRec> list_0, ref bool bool_1, bool bool_2, bool bool_3)
	{
		bool flag = false;
		bool flag2 = false;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		float num7 = 0f;
		float num8 = 0f;
		if (!Information.IsNothing(list_0) && list_0.Count > 0)
		{
			foreach (WeaponRec item in list_0)
			{
				if (!bool_3 || (bool_3 && item.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun))
				{
					num3 += item.CurrentLoad;
					num6 += item.MaxLoad;
				}
				if (item.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun)
				{
					num += item.CurrentLoad;
					num4 += item.MaxLoad;
					float maxRange_NoTargetType = item.GetReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
					if (item.CurrentLoad > 0 && num7 < maxRange_NoTargetType)
					{
						num7 = maxRange_NoTargetType;
					}
				}
				else
				{
					num2 += item.CurrentLoad;
					num5 += item.MaxLoad;
					float maxRange_NoTargetType2 = item.GetReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
					if (item.CurrentLoad > 0 && num8 < maxRange_NoTargetType2)
					{
						num8 = maxRange_NoTargetType2;
					}
				}
			}
			if (num == 0 && num2 == 0)
			{
				return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
			}
			if (num < num4)
			{
				flag2 = true;
			}
			if (num4 == 0 && num2 == 0)
			{
				flag = true;
			}
			if (num3 == 0)
			{
				flag = true;
			}
		}
		if (flag || flag2)
		{
			if (myUnit.AI.Targets_ReadOnly.Length == 0)
			{
				return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
			}
			if (myUnit.GetUnitSide().NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtAnyTarget(ref myUnit) <= 0)
			{
				Contact[] targets_ReadOnly = myUnit.AI.Targets_ReadOnly;
				Contact[] array = targets_ReadOnly;
				foreach (Contact contact_ in array)
				{
					ActiveUnit_AI.TargetingEntry._TargetingBehavior targetingBehavior = myUnit.AI.TargetingBehaviorForThisTarget(contact_);
					if (targetingBehavior == ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted || targetingBehavior == ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc)
					{
						if (flag)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
						}
						if (flag2)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
						}
					}
				}
				float num9;
				if (myUnit.AI.Targets_ReadOnly.Length == 1)
				{
					num9 = Module_Unit.RangeToUnit_Horiz(myUnit, myUnit.AI.Targets_ReadOnly[0]);
				}
				else
				{
					IEnumerable<Contact> source = myUnit.AI.Targets_ReadOnly.OrderBy((Contact contact_0) => Module_Unit.RangeToUnit_Horiz_Angular(myUnit, contact_0));
					num9 = Module_Unit.RangeToUnit_Horiz(myUnit, source.ElementAtOrDefault(0));
				}
				if (num > 0 && num7 < 5f)
				{
					num7 = 5f;
				}
				if (num8 <= 0f)
				{
					if (num7 > 0f && (double)num9 > Math.Max((double)num7 * 1.2, num7 + 5f))
					{
						if (flag)
						{
							if (bool_3 && !flag2)
							{
								return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
							}
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						if (flag2)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
						}
					}
				}
				else if ((double)num9 > Math.Max((double)num8 * 1.2, num8 + 5f))
				{
					if (flag)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					}
					if (flag2)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
					}
				}
				if (!myUnit.IsRTB && myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsBingo && myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsJoker)
				{
					if (flag)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
					}
					return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
				}
				if (flag)
				{
					return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
				}
				return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
			}
			return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
		}
		return ActiveUnit._ActiveUnitWeaponState.None;
	}

	public ActiveUnit._ActiveUnitWeaponState CheckShotgunPercentage(ref List<WeaponRec> list_0, ref bool bool_1, int int_0, bool bool_2, bool bool_3)
	{
		bool flag = false;
		bool flag2 = false;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		float num7 = 0f;
		float num8 = 0f;
		if (!Information.IsNothing(list_0) && list_0.Count > 0)
		{
			if (!Information.IsNothing(list_0) && list_0.Count > 0)
			{
				foreach (WeaponRec item in list_0)
				{
					if (!bool_3 || (bool_3 && item.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun))
					{
						num3 += item.CurrentLoad;
						num6 += item.MaxLoad;
					}
					if (item.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun)
					{
						num += item.CurrentLoad;
						num4 += item.MaxLoad;
						if (bool_2)
						{
							float maxRange_NoTargetType = item.GetReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
							if (item.CurrentLoad > 0 && num7 < maxRange_NoTargetType)
							{
								num7 = maxRange_NoTargetType;
							}
						}
						continue;
					}
					num2 += item.CurrentLoad;
					num5 += item.MaxLoad;
					if (bool_2)
					{
						float maxRange_NoTargetType2 = item.GetReferenceWeapon(myUnit.ParentScen).MaxRange_NoTargetType;
						if (item.CurrentLoad > 0 && num8 < maxRange_NoTargetType2)
						{
							num8 = maxRange_NoTargetType2;
						}
					}
				}
			}
			if (num == 0 && num2 == 0)
			{
				return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
			}
			if (bool_3)
			{
				if (num5 > 1 && (float)num2 <= (float)num5 * ((float)int_0 / 100f))
				{
					flag2 = true;
				}
			}
			else if (num4 + num5 > 1 && (double)(num + num2) <= (double)(num4 + num5) * ((double)int_0 / 100.0))
			{
				flag2 = true;
			}
			if (num3 == 0)
			{
				flag = true;
			}
		}
		if (flag || flag2)
		{
			if (bool_2)
			{
				if (myUnit.AI.Targets_ReadOnly.Length == 0)
				{
					return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
				}
				if (myUnit.GetUnitSide().NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtAnyTarget(ref myUnit) <= 0)
				{
					Contact[] targets_ReadOnly = myUnit.AI.Targets_ReadOnly;
					Contact[] array = targets_ReadOnly;
					foreach (Contact contact_ in array)
					{
						ActiveUnit_AI.TargetingEntry._TargetingBehavior targetingBehavior = myUnit.AI.TargetingBehaviorForThisTarget(contact_);
						if (targetingBehavior == ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted || targetingBehavior == ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc)
						{
							if (flag)
							{
								return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
							}
							if (flag2)
							{
								return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
							}
						}
					}
					float num9;
					if (myUnit.AI.Targets_ReadOnly.Length == 1)
					{
						num9 = Module_Unit.RangeToUnit_Horiz(myUnit, myUnit.AI.Targets_ReadOnly[0]);
					}
					else
					{
						IEnumerable<Contact> source = myUnit.AI.Targets_ReadOnly.OrderBy((Contact contact_0) => Module_Unit.RangeToUnit_Horiz_Angular(myUnit, contact_0));
						num9 = Module_Unit.RangeToUnit_Horiz(myUnit, source.ElementAtOrDefault(0));
					}
					if (num > 0 && num7 < 5f)
					{
						num7 = 5f;
					}
					if (num8 <= 0f)
					{
						if (num7 > 0f && (double)num9 > Math.Max((double)num7 * 1.2, num7 + 5f))
						{
							if (flag)
							{
								if (bool_3 && !flag2)
								{
									return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
								}
								return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							}
							if (flag2)
							{
								return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
							}
						}
					}
					else if ((double)num9 > Math.Max((double)num8 * 1.2, num8 + 5f))
					{
						if (flag)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						if (flag2)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
						}
					}
					if (!myUnit.IsRTB && myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsBingo && myUnit.FuelState != ActiveUnit._ActiveUnitFuelState.IsJoker)
					{
						if (flag)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO;
						}
						return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
					}
					if (flag)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					}
					return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
				}
				return ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO;
			}
			if (flag)
			{
				return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
			}
			return ActiveUnit._ActiveUnitWeaponState.IsShotgun;
		}
		return ActiveUnit._ActiveUnitWeaponState.None;
	}

	public override ActiveUnit._ActiveUnitWeaponState IsWinchesterOrShotgun()
	{
		if (!Information.IsNothing(GetAircraft().Loadout))
		{
			try
			{
				Doctrine._WeaponState? weaponState = myUnit.Doctrine.GetWinchesterShotgun(myUnit.ParentScen, bool_0: false, bool_1: true, bool_2: false, bool_3: false);
				int? num = (int?)weaponState;
				bool flag;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					flag = true;
					if (!Information.IsNothing(GetAircraft().Loadout))
					{
						weaponState = GetAircraft().Loadout.WinchesterShotgun;
					}
				}
				else
				{
					flag = false;
				}
				bool flag2 = false;
				bool flag3 = false;
				List<WeaponRec> list_3;
				int num3;
				ActiveUnit._ActiveUnitWeaponState activeUnitWeaponState;
				bool bool_;
				switch (GetAircraft().Loadout.Role)
				{
				case Loadout.LoadoutRole.Intercept_BVR:
				case Loadout.LoadoutRole.Intercept_WVR:
				case Loadout.LoadoutRole.AirSuperiority_BVR:
				case Loadout.LoadoutRole.AirSuperiority_WVR:
				case Loadout.LoadoutRole.PointDefence_BVR:
				case Loadout.LoadoutRole.PointDefence_WVR:
				case Loadout.LoadoutRole.GunsOnly:
					if (!(!GetAircraft().ParentScen.FeatureCompatibility.GetWeaponAGL_ASL(GetAircraft().ParentScen.DBConnection) && flag))
					{
						bool flag5 = false;
						bool flag6 = false;
						if (GetAircraft().Loadout.Role == Loadout.LoadoutRole.GunsOnly)
						{
							flag5 = true;
						}
						if (GetAircraft().Loadout.Role == Loadout.LoadoutRole.AirSuperiority_WVR || GetAircraft().Loadout.Role == Loadout.LoadoutRole.Intercept_WVR || GetAircraft().Loadout.Role == Loadout.LoadoutRole.PointDefence_WVR)
						{
							flag6 = true;
						}
						num = (int?)weaponState;
						if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 2001) : null).GetValueOrDefault())
						{
							num = (int?)weaponState;
							if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 2002) : null).GetValueOrDefault())
							{
								num = (int?)weaponState;
								if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 3001) : null).GetValueOrDefault())
								{
									num = (int?)weaponState;
									if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 3002) : null).GetValueOrDefault())
									{
										num = (int?)weaponState;
										if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 3003) : null).GetValueOrDefault())
										{
											num = (int?)weaponState;
											if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5001) : null).GetValueOrDefault())
											{
												num = (int?)weaponState;
												if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5002) : null).GetValueOrDefault())
												{
													num = (int?)weaponState;
													if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5003) : null).GetValueOrDefault())
													{
														num = (int?)weaponState;
														if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5005) : null).GetValueOrDefault())
														{
															num = (int?)weaponState;
															if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5006) : null).GetValueOrDefault())
															{
																num = (int?)weaponState;
																if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5011) : null).GetValueOrDefault())
																{
																	num = (int?)weaponState;
																	if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5012) : null).GetValueOrDefault())
																	{
																		num = (int?)weaponState;
																		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5021) : null).GetValueOrDefault())
																		{
																			List<WeaponRec> list_4 = (flag5 ? GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun).ToList() : GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW).ToList());
																			foreach (Mount mount in myUnit.Mounts)
																			{
																				if (mount.Status == PlatformComponent._ComponentStatus.Operational)
																				{
																					List<WeaponRec> list = (flag5 ? mount.MountWeapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun).ToList() : mount.MountWeapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW).ToList());
																					if (!Information.IsNothing(list) && list.Count > 0)
																					{
																						list_4.AddRange(list);
																					}
																				}
																			}
																			bool_ = true;
																			return CheckShotgunGun(ref list_4, ref bool_, bool_2: true, !flag5);
																		}
																		List<WeaponRec> list_5 = (flag5 ? GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun).ToList() : GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW).ToList());
																		foreach (Mount mount2 in myUnit.Mounts)
																		{
																			if (mount2.Status == PlatformComponent._ComponentStatus.Operational)
																			{
																				List<WeaponRec> list2 = (flag5 ? mount2.MountWeapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun).ToList() : mount2.MountWeapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW).ToList());
																				if (!Information.IsNothing(list2) && list2.Count > 0)
																				{
																					list_5.AddRange(list2);
																				}
																			}
																		}
																		bool bool_7 = false;
																		num = (int?)weaponState;
																		int int_3;
																		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4001) : null).GetValueOrDefault())
																		{
																			int_3 = 25;
																		}
																		else
																		{
																			num = (int?)weaponState;
																			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4002) : null).GetValueOrDefault())
																			{
																				int_3 = 25;
																				bool_7 = true;
																			}
																			else
																			{
																				num = (int?)weaponState;
																				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4011) : null).GetValueOrDefault())
																				{
																					int_3 = 50;
																				}
																				else
																				{
																					num = (int?)weaponState;
																					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4012) : null).GetValueOrDefault())
																					{
																						int_3 = 50;
																						bool_7 = true;
																					}
																					else
																					{
																						num = (int?)weaponState;
																						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4021) : null).GetValueOrDefault())
																						{
																							int_3 = 75;
																						}
																						else
																						{
																							int_3 = 75;
																							bool_7 = true;
																						}
																					}
																				}
																			}
																		}
																		bool_ = true;
																		return CheckShotgunPercentage(ref list_5, ref bool_, int_3, bool_7, !flag5);
																	}
																}
																if (flag5)
																{
																	if (myUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester || myUnit.ParentScen.MinuteIsChangingOnThisPulse)
																	{
																		string text2 = "";
																		if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, TextCompare: false) != 0)
																		{
																			text2 = " (" + myUnit.UnitClass + ")";
																		}
																		if (!myUnit.IsRTB)
																		{
																			myUnit.AddMessage("机炮武器状态已被设置为Beyond Visual Range（BVR）耗尽，但飞机" + myUnit.Name + text2 + "只携带枪支。因此飞机将立即返回基地。将Shotgun武器状态更改为枪支，或使用Winchester武器状态。", myUnit.Name + " 立即返回基地", LoggedMessage.MessageType.AirOps, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
																		}
																	}
																	if (myUnit.IsOperating())
																	{
																		return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
																	}
																	return ActiveUnit._ActiveUnitWeaponState.None;
																}
																List<WeaponRec> list_6 = GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW).ToList();
																foreach (Mount mount3 in myUnit.Mounts)
																{
																	if (mount3.Status == PlatformComponent._ComponentStatus.Operational)
																	{
																		List<WeaponRec> list3 = mount3.MountWeapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW).ToList();
																		if (!Information.IsNothing(list3) && list3.Count > 0)
																		{
																			list_6.AddRange(list3);
																		}
																	}
																}
																num = (int?)weaponState;
																bool value = (num.HasValue ? new bool?(num.GetValueOrDefault() == 3003) : null).Value;
																bool_ = true;
																return CheckShotgunWVR(ref list_6, ref bool_, bool_2: true, value, bool_4: true);
															}
														}
													}
												}
											}
											if (flag5)
											{
												if (myUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester || myUnit.ParentScen.MinuteIsChangingOnThisPulse)
												{
													string text3 = "";
													if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, TextCompare: false) != 0)
													{
														text3 = " (" + myUnit.UnitClass + ")";
													}
													if (!myUnit.IsRTB)
													{
														myUnit.AddMessage("机炮武器国家已被设定为与Beyond Visual Range（BVR）武器的一次交战，但飞机" + myUnit.Name + text3 + "只携带枪支。因此飞机将立即返回基地。将Shotgun武器状态更改为枪支，或使用Winchester武器状态。", myUnit.Name + " 立即返回基地", LoggedMessage.MessageType.AirOps, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
													}
												}
												if (myUnit.IsOperating())
												{
													return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
												}
												return ActiveUnit._ActiveUnitWeaponState.None;
											}
											if (flag6)
											{
												if (myUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester || myUnit.ParentScen.MinuteIsChangingOnThisPulse)
												{
													string text4 = "";
													if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, TextCompare: false) != 0)
													{
														text4 = " (" + myUnit.UnitClass + ")";
													}
													if (!myUnit.IsRTB)
													{
														myUnit.AddMessage("机炮武器国家已被设定为与Beyond Visual Range（BVR）武器的一次交战，但飞机" + myUnit.Name + text4 + "仅配备视觉范围（WVR）武器。因此飞机将立即返回基地。将Shotgun武器状态更改为枪支或WVR，或使用Winchester武器状态。", myUnit.Name + " 立即返回基地", LoggedMessage.MessageType.AirOps, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
													}
												}
												if (myUnit.IsOperating())
												{
													return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
												}
												return ActiveUnit._ActiveUnitWeaponState.None;
											}
											list_3 = GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW).ToList();
											foreach (Mount mount4 in myUnit.Mounts)
											{
												if (mount4.Status == PlatformComponent._ComponentStatus.Operational)
												{
													List<WeaponRec> list4 = mount4.MountWeapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW).ToList();
													if (!Information.IsNothing(list4) && list4.Count > 0)
													{
														list_3.AddRange(list4);
													}
												}
											}
											num = (int?)weaponState;
											if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5002) : null).Value)
											{
												num = (int?)weaponState;
												if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5003) : null).Value)
												{
													num = (int?)weaponState;
													if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5005) : null).Value)
													{
														num = (int?)weaponState;
														num3 = ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5006) : null).Value ? 1 : 0);
														break;
													}
												}
											}
											num3 = 1;
											break;
										}
									}
								}
								if (flag5)
								{
									if (myUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester || myUnit.ParentScen.MinuteIsChangingOnThisPulse)
									{
										string text5 = "";
										if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, TextCompare: false) != 0)
										{
											text5 = " (" + myUnit.UnitClass + ")";
										}
										if (!myUnit.IsRTB)
										{
											myUnit.AddMessage("机炮武器状态已被设置为Beyond Visual Range（BVR）耗尽，但飞机" + myUnit.Name + text5 + "只携带枪支。因此飞机将立即返回基地。将Shotgun武器状态更改为枪支，或使用Winchester武器状态。", myUnit.Name + " 立即返回基地", LoggedMessage.MessageType.AirOps, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
										}
									}
									if (myUnit.IsOperating())
									{
										return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
									}
									return ActiveUnit._ActiveUnitWeaponState.None;
								}
								if (flag6)
								{
									if (myUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester || myUnit.ParentScen.MinuteIsChangingOnThisPulse)
									{
										string text6 = "";
										if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, TextCompare: false) != 0)
										{
											text6 = " (" + myUnit.UnitClass + ")";
										}
										if (!myUnit.IsRTB)
										{
											myUnit.AddMessage("机炮武器状态已被设置为Beyond Visual Range（BVR）耗尽，但飞机" + myUnit.Name + text6 + "仅配备视觉范围（WVR）武器。因此飞机将立即返回基地。将Shotgun武器状态更改为枪支或WVR，或使用Winchester武器状态。", myUnit.Name + " 立即返回基地", LoggedMessage.MessageType.AirOps, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
										}
									}
									if (myUnit.IsOperating())
									{
										return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
									}
									return ActiveUnit._ActiveUnitWeaponState.None;
								}
								List<WeaponRec> list_7 = GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW).ToList();
								foreach (Mount mount5 in myUnit.Mounts)
								{
									if (mount5.Status == PlatformComponent._ComponentStatus.Operational)
									{
										List<WeaponRec> list5 = mount5.MountWeapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW).ToList();
										if (!Information.IsNothing(list5) && list5.Count > 0)
										{
											list_7.AddRange(list5);
										}
									}
								}
								num = (int?)weaponState;
								int num6;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3002) : null).Value)
								{
									num6 = 1;
								}
								else
								{
									num = (int?)weaponState;
									num6 = ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3003) : null).Value ? 1 : 0);
								}
								bool bool_8 = (byte)num6 != 0;
								num = (int?)weaponState;
								bool value2 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 3003) : null).Value;
								bool_ = true;
								return CheckShotgunBVR(ref list_7, ref bool_, bool_2: false, bool_3: false, bool_8, value2, bool_6: true);
							}
						}
						List<WeaponRec> list_8 = (flag5 ? GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun).ToList() : GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW).ToList());
						foreach (Mount mount6 in myUnit.Mounts)
						{
							if (mount6.Status == PlatformComponent._ComponentStatus.Operational)
							{
								List<WeaponRec> list6 = (flag5 ? mount6.MountWeapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun).ToList() : mount6.MountWeapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW).ToList());
								if (!Information.IsNothing(list6) && list6.Count > 0)
								{
									list_8.AddRange(list6);
								}
							}
						}
						if (Information.IsNothing(myUnit.AssignedMissionOrPackage()) || (myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && ((Strike)myUnit.AssignedMissionOrPackage()).Type == Strike.StrikeType.Air_Intercept) || flag5)
						{
							return CheckWinchester(ref list_8, bool_1: false, bool_2: false);
						}
						num = (int?)weaponState;
						return CheckWinchester(ref list_8, (num.HasValue ? new bool?(num.GetValueOrDefault() == 2002) : null).Value, !flag5);
					}
					switch (GetAircraft().Loadout.Role)
					{
					case Loadout.LoadoutRole.AirSuperiority_BVR:
					{
						if (Information.IsNothing(myUnit.AssignedMissionOrPackage()))
						{
							if (GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW && weaponRec_0.CurrentLoad > 0).Count() == 0)
							{
								flag2 = true;
							}
							if (myUnit.Mounts.Where((Mount theM) => theM.Status == PlatformComponent._ComponentStatus.Operational && theM.HasGuns && !theM.IsEmpty).Count() == 0)
							{
								flag3 = true;
							}
							if (flag2 && flag3)
							{
								return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							}
							return ActiveUnit._ActiveUnitWeaponState.None;
						}
						bool flag7 = GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsMissile && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).ReadReponse() && weaponRec_0.CurrentLoad > 0).Count() > 0;
						switch (myUnit.AssignedMissionOrPackage().MissionClass)
						{
						case Mission._MissionClass.Patrol:
							if (flag7)
							{
								return ActiveUnit._ActiveUnitWeaponState.None;
							}
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						case Mission._MissionClass.Strike:
							if (((Strike)myUnit.AssignedMissionOrPackage()).Type == Strike.StrikeType.Air_Intercept)
							{
								if (GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW && weaponRec_0.CurrentLoad > 0).Count() == 0)
								{
									flag2 = true;
								}
								if (myUnit.Mounts.Where((Mount theM) => theM.Status == PlatformComponent._ComponentStatus.Operational && theM.HasGuns && !theM.IsEmpty).Count() == 0)
								{
									flag3 = true;
								}
								if (flag2 && flag3)
								{
									return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
								}
								return ActiveUnit._ActiveUnitWeaponState.None;
							}
							break;
						}
						break;
					}
					case Loadout.LoadoutRole.Intercept_BVR:
					case Loadout.LoadoutRole.PointDefence_BVR:
					{
						if (Information.IsNothing(myUnit.AssignedMissionOrPackage()))
						{
							if (GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW && weaponRec_0.CurrentLoad > 0).Count() == 0)
							{
								flag2 = true;
							}
							if (myUnit.Mounts.Where((Mount theM) => theM.Status == PlatformComponent._ComponentStatus.Operational && theM.HasGuns && !theM.IsEmpty).Count() == 0)
							{
								flag3 = true;
							}
							if (flag2 && flag3)
							{
								return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
							}
							return ActiveUnit._ActiveUnitWeaponState.None;
						}
						bool flag8 = GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsMissile && weaponRec_0.CurrentLoad > 0).Count() > 0;
						switch (myUnit.AssignedMissionOrPackage().MissionClass)
						{
						case Mission._MissionClass.Patrol:
							if (flag8)
							{
								return ActiveUnit._ActiveUnitWeaponState.None;
							}
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						case Mission._MissionClass.Strike:
							if (((Strike)myUnit.AssignedMissionOrPackage()).Type == Strike.StrikeType.Air_Intercept)
							{
								if (GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW && weaponRec_0.CurrentLoad > 0).Count() == 0)
								{
									flag2 = true;
								}
								if (myUnit.Mounts.Where((Mount theM) => theM.Status == PlatformComponent._ComponentStatus.Operational && theM.HasGuns && !theM.IsEmpty).Count() == 0)
								{
									flag3 = true;
								}
								if (flag2 && flag3)
								{
									return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
								}
								return ActiveUnit._ActiveUnitWeaponState.None;
							}
							break;
						}
						break;
					}
					case Loadout.LoadoutRole.Intercept_WVR:
					case Loadout.LoadoutRole.AirSuperiority_WVR:
					case Loadout.LoadoutRole.PointDefence_WVR:
						if (GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW && weaponRec_0.CurrentLoad > 0).Count() == 0)
						{
							flag2 = true;
						}
						if (myUnit.Mounts.Where((Mount theM) => theM.Status == PlatformComponent._ComponentStatus.Operational && theM.HasGuns && !theM.IsEmpty).Count() == 0)
						{
							flag3 = true;
						}
						if (flag2 && flag3)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						return ActiveUnit._ActiveUnitWeaponState.None;
					}
					goto IL_47e5;
				case Loadout.LoadoutRole.LandNaval_Strike:
				case Loadout.LoadoutRole.LandOnly_Strike:
				case Loadout.LoadoutRole.NavalOnly_Strike:
				case Loadout.LoadoutRole.BAI_CAS:
					if (!(!GetAircraft().ParentScen.FeatureCompatibility.GetWeaponAGL_ASL(GetAircraft().ParentScen.DBConnection) && flag))
					{
						byte? b6 = (byte?)myUnit.Doctrine.GetGunStrafing(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
						bool value3;
						List<WeaponRec> list_9;
						if (value3 = (b6.HasValue ? new bool?(b6.GetValueOrDefault() == 1) : null).Value)
						{
							list_9 = ((GetAircraft().Loadout.Role == Loadout.LoadoutRole.LandNaval_Strike) ? GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval || weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land).ToList() : ((GetAircraft().Loadout.Role == Loadout.LoadoutRole.NavalOnly_Strike) ? GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval).ToList() : GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land).ToList()));
							foreach (Mount mount7 in myUnit.Mounts)
							{
								if (mount7.Status == PlatformComponent._ComponentStatus.Operational)
								{
									List<WeaponRec> list7 = ((GetAircraft().Loadout.Role == Loadout.LoadoutRole.LandNaval_Strike) ? mount7.MountWeapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval || weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land).ToList() : ((GetAircraft().Loadout.Role == Loadout.LoadoutRole.NavalOnly_Strike) ? mount7.MountWeapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval).ToList() : mount7.MountWeapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land).ToList()));
									if (!Information.IsNothing(list7) && list7.Count > 0)
									{
										list_9.AddRange(list7);
									}
								}
							}
						}
						else
						{
							list_9 = ((GetAircraft().Loadout.Role == Loadout.LoadoutRole.LandNaval_Strike) ? GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval || weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land) && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun).ToList() : ((GetAircraft().Loadout.Role == Loadout.LoadoutRole.NavalOnly_Strike) ? GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun).ToList() : GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun).ToList()));
						}
						num = (int?)weaponState;
						if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 2001) : null).GetValueOrDefault())
						{
							num = (int?)weaponState;
							if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 2002) : null).GetValueOrDefault())
							{
								num = (int?)weaponState;
								if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 3001) : null).GetValueOrDefault())
								{
									num = (int?)weaponState;
									if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 3002) : null).GetValueOrDefault())
									{
										num = (int?)weaponState;
										if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 3003) : null).GetValueOrDefault())
										{
											num = (int?)weaponState;
											if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5001) : null).GetValueOrDefault())
											{
												num = (int?)weaponState;
												if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5002) : null).GetValueOrDefault())
												{
													num = (int?)weaponState;
													if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5003) : null).GetValueOrDefault())
													{
														num = (int?)weaponState;
														if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5005) : null).GetValueOrDefault())
														{
															num = (int?)weaponState;
															if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5006) : null).GetValueOrDefault())
															{
																num = (int?)weaponState;
																if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5011) : null).GetValueOrDefault())
																{
																	num = (int?)weaponState;
																	if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5012) : null).GetValueOrDefault())
																	{
																		num = (int?)weaponState;
																		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5021) : null).GetValueOrDefault())
																		{
																			bool_ = false;
																			return CheckShotgunGun(ref list_9, ref bool_, bool_2: true, !value3);
																		}
																		bool bool_9 = false;
																		num = (int?)weaponState;
																		int int_4;
																		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4001) : null).GetValueOrDefault())
																		{
																			int_4 = 25;
																		}
																		else
																		{
																			num = (int?)weaponState;
																			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4002) : null).GetValueOrDefault())
																			{
																				int_4 = 25;
																				bool_9 = true;
																			}
																			else
																			{
																				num = (int?)weaponState;
																				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4011) : null).GetValueOrDefault())
																				{
																					int_4 = 50;
																				}
																				else
																				{
																					num = (int?)weaponState;
																					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4012) : null).GetValueOrDefault())
																					{
																						int_4 = 50;
																						bool_9 = true;
																					}
																					else
																					{
																						num = (int?)weaponState;
																						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4021) : null).GetValueOrDefault())
																						{
																							int_4 = 75;
																						}
																						else
																						{
																							int_4 = 75;
																							bool_9 = true;
																						}
																					}
																				}
																			}
																		}
																		bool_ = false;
																		return CheckShotgunPercentage(ref list_9, ref bool_, int_4, bool_9, !value3);
																	}
																}
																bool_ = false;
																return CheckShotgunWVR(ref list_9, ref bool_, bool_2: true, bool_3: false, !value3);
															}
														}
														bool_ = false;
														return CheckShotgunBVR(ref list_9, ref bool_, bool_2: true, bool_3: true, bool_4: false, bool_5: false, value3);
													}
												}
											}
											if (myUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester || myUnit.ParentScen.MinuteIsChangingOnThisPulse)
											{
												string text7 = "";
												if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, TextCompare: false) != 0)
												{
													text7 = " (" + myUnit.UnitClass + ")";
												}
												if (!myUnit.IsRTB)
												{
													myUnit.AddMessage("机炮武器状态已被设定为与远程武器的一次交战，但飞机" + myUnit.Name + text7 + "只配备了短程武器。因此飞机将立即返回基地。将Shotgun武器状态更改为短程武器或枪支，或使用Winchester武器状态。", myUnit.Name + " 立即返回基地", LoggedMessage.MessageType.AirOps, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
												}
											}
											if (myUnit.IsOperating())
											{
												return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
											}
											return ActiveUnit._ActiveUnitWeaponState.None;
										}
									}
								}
								if (myUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.IsWinchester || myUnit.ParentScen.MinuteIsChangingOnThisPulse)
								{
									string text8 = "";
									if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, TextCompare: false) != 0)
									{
										text8 = " (" + myUnit.UnitClass + ")";
									}
									if (!myUnit.IsRTB)
									{
										myUnit.AddMessage("机炮武器状态已被设定为与远程武器的一次交战，但飞机" + myUnit.Name + text8 + "只配备了短程武器。因此飞机将立即返回基地。将Shotgun武器状态更改为短程武器或枪支，或使用Winchester武器状态。", myUnit.Name + " 立即返回基地", LoggedMessage.MessageType.AirOps, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
									}
								}
								if (myUnit.IsOperating())
								{
									return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
								}
								return ActiveUnit._ActiveUnitWeaponState.None;
							}
						}
						return CheckWinchester(ref list_9, bool_1: false, !value3);
					}
					switch (GetAircraft().Loadout.Role)
					{
					case Loadout.LoadoutRole.LandNaval_Strike:
					{
						byte? b4 = (byte?)myUnit.Doctrine.GetGunStrafing(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
						if (((b4.HasValue ? new bool?(b4.GetValueOrDefault() == 0) : null).GetValueOrDefault() ? GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval || weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land) && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun && weaponRec_0.CurrentLoad > 0).Count() : GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval || weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land) && weaponRec_0.CurrentLoad > 0).Count()) == 0)
						{
							flag2 = true;
						}
						b4 = (byte?)myUnit.Doctrine.GetGunStrafing(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
						int num9 = 0;
						if (!(b4.HasValue ? new bool?(b4.GetValueOrDefault() == 0) : null).GetValueOrDefault())
						{
							num9 = myUnit.Mounts.Where((Mount theM) => theM.Status == PlatformComponent._ComponentStatus.Operational && theM.HasGuns && !theM.IsEmpty).Count();
						}
						if (num9 == 0)
						{
							flag3 = true;
						}
						if (flag2 && flag3)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						return ActiveUnit._ActiveUnitWeaponState.None;
					}
					case Loadout.LoadoutRole.LandOnly_Strike:
					case Loadout.LoadoutRole.BAI_CAS:
					{
						byte? b5 = (byte?)myUnit.Doctrine.GetGunStrafing(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
						if (((b5.HasValue ? new bool?(b5.GetValueOrDefault() == 0) : null).GetValueOrDefault() ? GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun && weaponRec_0.CurrentLoad > 0).Count() : GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land && weaponRec_0.CurrentLoad > 0).Count()) == 0)
						{
							flag2 = true;
						}
						b5 = (byte?)myUnit.Doctrine.GetGunStrafing(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
						int num8 = 0;
						if (!(b5.HasValue ? new bool?(b5.GetValueOrDefault() == 0) : null).GetValueOrDefault())
						{
							num8 = myUnit.Mounts.Where((Mount theM) => theM.Status == PlatformComponent._ComponentStatus.Operational && theM.HasGuns && !theM.IsEmpty).Count();
						}
						if (num8 == 0)
						{
							flag3 = true;
						}
						if (flag2 && flag3)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						return ActiveUnit._ActiveUnitWeaponState.None;
					}
					case Loadout.LoadoutRole.NavalOnly_Strike:
					{
						byte? b3 = (byte?)myUnit.Doctrine.GetGunStrafing(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
						if (((b3.HasValue ? new bool?(b3.GetValueOrDefault() == 0) : null).GetValueOrDefault() ? GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun && weaponRec_0.CurrentLoad > 0).Count() : GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval && weaponRec_0.CurrentLoad > 0).Count()) == 0)
						{
							flag2 = true;
						}
						b3 = (byte?)myUnit.Doctrine.GetGunStrafing(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
						int num7 = 0;
						if (!(b3.HasValue ? new bool?(b3.GetValueOrDefault() == 0) : null).GetValueOrDefault())
						{
							num7 = myUnit.Mounts.Where((Mount theM) => theM.Status == PlatformComponent._ComponentStatus.Operational && theM.HasGuns && !theM.IsEmpty).Count();
						}
						if (num7 == 0)
						{
							flag3 = true;
						}
						if (flag2 && flag3)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						return ActiveUnit._ActiveUnitWeaponState.None;
					}
					}
					goto IL_47e5;
				case Loadout.LoadoutRole.LandNaval_Standoff:
				case Loadout.LoadoutRole.LandOnly_Standoff:
				case Loadout.LoadoutRole.NavalOnly_Standoff:
				{
					if (!GetAircraft().ParentScen.FeatureCompatibility.GetWeaponAGL_ASL(GetAircraft().ParentScen.DBConnection) && flag)
					{
						byte? b2 = (byte?)myUnit.Doctrine.GetGunStrafing(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
						if (((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 0) : null).GetValueOrDefault() ? GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).UpdateReponse() && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun && weaponRec_0.CurrentLoad > 0).Count() : GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).UpdateReponse() && weaponRec_0.CurrentLoad > 0).Count()) == 0)
						{
							flag2 = true;
						}
						b2 = (byte?)myUnit.Doctrine.GetGunStrafing(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
						int num2 = 0;
						if (!(b2.HasValue ? new bool?(b2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
						{
							num2 = myUnit.Mounts.Where((Mount theM) => theM.Status == PlatformComponent._ComponentStatus.Operational && theM.HasGuns && !theM.IsEmpty).Count();
						}
						if (num2 == 0)
						{
							flag3 = true;
						}
						if (flag2 && flag3)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						return ActiveUnit._ActiveUnitWeaponState.None;
					}
					List<WeaponRec> list_ = GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).UpdateReponse()).ToList();
					num = (int?)weaponState;
					if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 2001) : null).GetValueOrDefault())
					{
						num = (int?)weaponState;
						if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 2002) : null).GetValueOrDefault())
						{
							num = (int?)weaponState;
							if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 3001) : null).GetValueOrDefault())
							{
								num = (int?)weaponState;
								if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 3002) : null).GetValueOrDefault())
								{
									num = (int?)weaponState;
									if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 3003) : null).GetValueOrDefault())
									{
										num = (int?)weaponState;
										if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5001) : null).GetValueOrDefault())
										{
											num = (int?)weaponState;
											if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5002) : null).GetValueOrDefault())
											{
												num = (int?)weaponState;
												if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5003) : null).GetValueOrDefault())
												{
													num = (int?)weaponState;
													if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5005) : null).GetValueOrDefault())
													{
														num = (int?)weaponState;
														if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5006) : null).GetValueOrDefault())
														{
															num = (int?)weaponState;
															if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5011) : null).GetValueOrDefault())
															{
																num = (int?)weaponState;
																if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5012) : null).GetValueOrDefault())
																{
																	num = (int?)weaponState;
																	if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5021) : null).GetValueOrDefault())
																	{
																		bool_ = false;
																		activeUnitWeaponState = CheckShotgunGun(ref list_, ref bool_, bool_2: true, bool_3: true);
																	}
																	else
																	{
																		bool bool_2 = false;
																		num = (int?)weaponState;
																		int int_;
																		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4001) : null).GetValueOrDefault())
																		{
																			int_ = 25;
																		}
																		else
																		{
																			num = (int?)weaponState;
																			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4002) : null).GetValueOrDefault())
																			{
																				int_ = 25;
																				bool_2 = true;
																			}
																			else
																			{
																				num = (int?)weaponState;
																				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4011) : null).GetValueOrDefault())
																				{
																					int_ = 50;
																				}
																				else
																				{
																					num = (int?)weaponState;
																					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4012) : null).GetValueOrDefault())
																					{
																						int_ = 50;
																						bool_2 = true;
																					}
																					else
																					{
																						num = (int?)weaponState;
																						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4021) : null).GetValueOrDefault())
																						{
																							int_ = 75;
																						}
																						else
																						{
																							int_ = 75;
																							bool_2 = true;
																						}
																					}
																				}
																			}
																		}
																		bool_ = false;
																		activeUnitWeaponState = CheckShotgunPercentage(ref list_, ref bool_, int_, bool_2, bool_3: true);
																	}
																	goto IL_463c;
																}
															}
															bool_ = false;
															activeUnitWeaponState = CheckShotgunWVR(ref list_, ref bool_, bool_2: true, bool_3: false, bool_4: true);
															goto IL_463c;
														}
													}
													bool_ = false;
													activeUnitWeaponState = CheckShotgunBVR(ref list_, ref bool_, bool_2: true, bool_3: true, bool_4: false, bool_5: false, bool_6: true);
													goto IL_463c;
												}
											}
										}
										bool_ = false;
										activeUnitWeaponState = CheckShotgunBVR(ref list_, ref bool_, bool_2: true, bool_3: false, bool_4: true, bool_5: false, bool_6: true);
										goto IL_463c;
									}
								}
							}
							bool_ = false;
							activeUnitWeaponState = CheckShotgunBVR(ref list_, ref bool_, bool_2: false, bool_3: false, bool_4: false, bool_5: false, bool_6: true);
							goto IL_463c;
						}
					}
					activeUnitWeaponState = CheckWinchester(ref list_, bool_1: false, bool_2: true);
					goto IL_463c;
				}
				case Loadout.LoadoutRole.LandNaval_SEAD_TALD:
				case Loadout.LoadoutRole.LandOnly_SEAD_TALD:
				case Loadout.LoadoutRole.NavalOnly_SEAD_TALD:
					if (GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.CurrentLoad > 0 && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsMobileDecoy).Count() == 0)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					}
					return ActiveUnit._ActiveUnitWeaponState.None;
				case Loadout.LoadoutRole.LandNaval_SEAD_ARM:
				case Loadout.LoadoutRole.LandNaval_DEAD:
				case Loadout.LoadoutRole.LandOnly_SEAD_ARM:
				case Loadout.LoadoutRole.LandOnly_DEAD:
				case Loadout.LoadoutRole.NavalOnly_SEAD_ARM:
				case Loadout.LoadoutRole.NavalOnly_DEAD:
					if (!(!GetAircraft().ParentScen.FeatureCompatibility.GetWeaponAGL_ASL(GetAircraft().ParentScen.DBConnection) && flag))
					{
						List<WeaponRec> list_2 = null;
						switch (GetAircraft().Loadout.Role)
						{
						case Loadout.LoadoutRole.LandNaval_SEAD_ARM:
						case Loadout.LoadoutRole.LandNaval_DEAD:
							list_2 = GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval || weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land || weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAntiradar) && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun).ToList();
							break;
						case Loadout.LoadoutRole.NavalOnly_SEAD_ARM:
						case Loadout.LoadoutRole.NavalOnly_DEAD:
							list_2 = GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval || weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAntiradar) && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun).ToList();
							break;
						case Loadout.LoadoutRole.LandOnly_SEAD_ARM:
						case Loadout.LoadoutRole.LandOnly_DEAD:
							list_2 = GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land || weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAntiradar) && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun).ToList();
							break;
						}
						num = (int?)weaponState;
						if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 2001) : null).GetValueOrDefault())
						{
							num = (int?)weaponState;
							if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 2002) : null).GetValueOrDefault())
							{
								num = (int?)weaponState;
								if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 3001) : null).GetValueOrDefault())
								{
									num = (int?)weaponState;
									if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 3002) : null).GetValueOrDefault())
									{
										num = (int?)weaponState;
										if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 3003) : null).GetValueOrDefault())
										{
											num = (int?)weaponState;
											if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5001) : null).GetValueOrDefault())
											{
												num = (int?)weaponState;
												if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5002) : null).GetValueOrDefault())
												{
													num = (int?)weaponState;
													if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5003) : null).GetValueOrDefault())
													{
														num = (int?)weaponState;
														if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5005) : null).GetValueOrDefault())
														{
															num = (int?)weaponState;
															if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5006) : null).GetValueOrDefault())
															{
																num = (int?)weaponState;
																if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5011) : null).GetValueOrDefault())
																{
																	num = (int?)weaponState;
																	if (!(num.HasValue ? new bool?(num.GetValueOrDefault() == 5012) : null).GetValueOrDefault())
																	{
																		num = (int?)weaponState;
																		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5021) : null).GetValueOrDefault())
																		{
																			bool_ = false;
																			return CheckShotgunGun(ref list_2, ref bool_, bool_2: true, bool_3: true);
																		}
																		bool bool_3 = false;
																		num = (int?)weaponState;
																		int int_2;
																		if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4001) : null).GetValueOrDefault())
																		{
																			int_2 = 25;
																		}
																		else
																		{
																			num = (int?)weaponState;
																			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4002) : null).GetValueOrDefault())
																			{
																				int_2 = 25;
																				bool_3 = true;
																			}
																			else
																			{
																				num = (int?)weaponState;
																				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4011) : null).GetValueOrDefault())
																				{
																					int_2 = 50;
																				}
																				else
																				{
																					num = (int?)weaponState;
																					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4012) : null).GetValueOrDefault())
																					{
																						int_2 = 50;
																						bool_3 = true;
																					}
																					else
																					{
																						num = (int?)weaponState;
																						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4021) : null).GetValueOrDefault())
																						{
																							int_2 = 75;
																						}
																						else
																						{
																							int_2 = 75;
																							bool_3 = true;
																						}
																					}
																				}
																			}
																		}
																		bool_ = false;
																		return CheckShotgunPercentage(ref list_2, ref bool_, int_2, bool_3, bool_3: true);
																	}
																}
																bool_ = false;
																return CheckShotgunWVR(ref list_2, ref bool_, bool_2: true, bool_3: false, bool_4: true);
															}
														}
														bool_ = false;
														return CheckShotgunBVR(ref list_2, ref bool_, bool_2: true, bool_3: true, bool_4: false, bool_5: false, bool_6: true);
													}
												}
											}
											bool_ = false;
											return CheckShotgunBVR(ref list_2, ref bool_, bool_2: true, bool_3: false, bool_4: true, bool_5: false, bool_6: true);
										}
									}
								}
								bool_ = false;
								return CheckShotgunBVR(ref list_2, ref bool_, bool_2: false, bool_3: false, bool_4: false, bool_5: false, bool_6: true);
							}
						}
						return CheckWinchester(ref list_2, bool_1: false, bool_2: true);
					}
					switch (GetAircraft().Loadout.Role)
					{
					case Loadout.LoadoutRole.LandNaval_SEAD_ARM:
					case Loadout.LoadoutRole.LandNaval_DEAD:
						if (GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval || weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land || weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAntiradar) && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun && weaponRec_0.CurrentLoad > 0).Count() == 0)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						return ActiveUnit._ActiveUnitWeaponState.None;
					case Loadout.LoadoutRole.NavalOnly_SEAD_ARM:
					case Loadout.LoadoutRole.NavalOnly_DEAD:
						if (GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval || weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAntiradar) && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun && weaponRec_0.CurrentLoad > 0).Count() == 0)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						return ActiveUnit._ActiveUnitWeaponState.None;
					case Loadout.LoadoutRole.LandOnly_SEAD_ARM:
					case Loadout.LoadoutRole.LandOnly_DEAD:
						if (GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land || weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAntiradar) && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun && weaponRec_0.CurrentLoad > 0).Count() == 0)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						return ActiveUnit._ActiveUnitWeaponState.None;
					}
					goto IL_47e5;
				default:
					return ActiveUnit._ActiveUnitWeaponState.None;
				case Loadout.LoadoutRole.ASW_Patrol:
				{
					bool flag4 = true;
					WeaponRec[] weapons = GetAircraft().Loadout.Weapons;
					for (int i = 0; i < weapons.Length; i = checked(i + 1))
					{
						if (weapons[i].GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Sonobuoy)
						{
							flag4 = false;
							break;
						}
					}
					if (flag4)
					{
						if (GetAircraft().Loadout.Weapons.Where((WeaponRec WR) => WR.CurrentLoad > 0).Count() == 0)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						return ActiveUnit._ActiveUnitWeaponState.None;
					}
					if (GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASW && weaponRec_0.CurrentLoad > 0).Count() == 0)
					{
						return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
					}
					return ActiveUnit._ActiveUnitWeaponState.None;
				}
				case Loadout.LoadoutRole.NavalMineLaying:
					{
						if (GetAircraft().Loadout.Weapons.Where((WeaponRec weaponRec_0) => weaponRec_0.CurrentLoad > 0 && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsMine).Count() == 0)
						{
							return ActiveUnit._ActiveUnitWeaponState.IsWinchester;
						}
						return ActiveUnit._ActiveUnitWeaponState.None;
					}
					IL_47e5:
					return ActiveUnit._ActiveUnitWeaponState.None;
					IL_463c:
					if (myUnit.WeaponState != activeUnitWeaponState)
					{
						byte? b = (byte?)myUnit.Doctrine.GetGunStrafing(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false);
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
						{
							string text = "";
							if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, TextCompare: false) != 0)
							{
								text = " (" + myUnit.UnitClass + ")";
							}
							if (!myUnit.IsRTB)
							{
								myUnit.AddMessage("条令允许空地扫射（枪），但飞机" + myUnit.Name + text + "只配备了对抗武器。因此，飞机将立即返回基地，而不是冒着使用枪支进行近距离攻击的风险。如果您想使用枪支，请使用短程武器切换到挂载，或者手动攻击。", myUnit.Name + " 立即返回基地", LoggedMessage.MessageType.AirOps, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
							}
						}
					}
					return activeUnitWeaponState;
				}
				bool bool_4 = (byte)num3 != 0;
				num = (int?)weaponState;
				int num4;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5003) : null).Value)
				{
					num4 = 1;
				}
				else
				{
					num = (int?)weaponState;
					num4 = ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5006) : null).Value ? 1 : 0);
				}
				bool bool_5 = (byte)num4 != 0;
				num = (int?)weaponState;
				int num5;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5005) : null).Value)
				{
					num5 = 1;
				}
				else
				{
					num = (int?)weaponState;
					num5 = ((num.HasValue ? new bool?(num.GetValueOrDefault() == 5006) : null).Value ? 1 : 0);
				}
				bool bool_6 = (byte)num5 != 0;
				bool_ = true;
				return CheckShotgunBVR(ref list_3, ref bool_, bool_2: true, bool_6, bool_4, bool_5, bool_6: true);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200295", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return ActiveUnit._ActiveUnitWeaponState.None;
			}
		}
		return ActiveUnit._ActiveUnitWeaponState.None;
	}

	public void DropSonobuoy(float float_0, bool bool_1, ref string string_0, SonarModel.PositionRelativeToThermocline? nullable_0 = null, bool? nullable_1 = null)
	{
		List<WeaponRec> list = new List<WeaponRec>();
		try
		{
			if (SeaIceProvider.PrepareWriter(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()))
			{
				if (bool_1)
				{
					string_0 = "无法在冰面上投放声呐！";
				}
				return;
			}
			foreach (Mount mount in GetAircraft().Mounts)
			{
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					mountWeapon.ParentMount = mount;
					if (mountWeapon.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Sonobuoy && mountWeapon.CurrentLoad != 0 && mount.Status == PlatformComponent._ComponentStatus.Operational && mount.TimeToFire == 0f && mountWeapon.TimeToFire == 0f)
					{
						list.Add(mountWeapon);
					}
				}
			}
			if (!Information.IsNothing(GetAircraft().Loadout))
			{
				WeaponRec[] weapons = GetAircraft().Loadout.Weapons;
				WeaponRec[] array = weapons;
				foreach (WeaponRec weaponRec in array)
				{
					weaponRec.ParentMount = null;
					if (weaponRec.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Sonobuoy && weaponRec.CurrentLoad != 0 && weaponRec.TimeToFire <= 0f)
					{
						list.Add(weaponRec);
					}
				}
			}
			if (list.Count == 0)
			{
				if (bool_1)
				{
					string_0 = "无可用声呐！";
				}
				return;
			}
			if (nullable_1.HasValue)
			{
				List<WeaponRec> list2 = new List<WeaponRec>();
				if (nullable_1.Value)
				{
					foreach (WeaponRec item in list)
					{
						if (item.GetReferenceWeapon(myUnit.ParentScen).Sensors_ReadOnly().Count() == 0 || !item.GetReferenceWeapon(myUnit.ParentScen).Sensors_ReadOnly()[0].HasActiveModeOnly)
						{
							list2.Add(item);
						}
					}
				}
				else
				{
					foreach (WeaponRec item2 in list)
					{
						if (item2.GetReferenceWeapon(myUnit.ParentScen).Sensors_ReadOnly().Count() == 0 || item2.GetReferenceWeapon(myUnit.ParentScen).Sensors_ReadOnly()[0].HasActiveModeOnly)
						{
							list2.Add(item2);
						}
					}
				}
				foreach (WeaponRec item3 in list2)
				{
					list.Remove(item3);
				}
			}
			if (list.Count == 0)
			{
				if (bool_1)
				{
					string_0 = "所选类型无可用声呐！";
				}
				return;
			}
			WeaponRec weaponRec_ = ((list.Count == 1) ? list[0] : list[GameGeneral.LockRandom_0.Next(0, list.Count)]);
			if (!nullable_0.HasValue)
			{
				nullable_0 = ((GameGeneral.LockRandom_0.Next(0, 1000) <= 500) ? new SonarModel.PositionRelativeToThermocline?(SonarModel.PositionRelativeToThermocline.Below) : new SonarModel.PositionRelativeToThermocline?(SonarModel.PositionRelativeToThermocline.Above));
			}
			int int_ = 0;
			SonarModel.PositionRelativeToThermocline value = nullable_0.Value;
			WeaponSalvo weaponSalvo_ = null;
			ResetConsumer(float_0, ref weaponRec_, null, ref int_, 0, 0f, ActiveUnit.Throttle.Flank, null, value, 0L, ref weaponSalvo_);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100476", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[CompilerGenerated]
	private double RevertProxy(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(myUnit, contact_0);
	}

	[CompilerGenerated]
	private double CountReader(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(myUnit, contact_0);
	}

	[CompilerGenerated]
	private double CustomizeReader(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(myUnit, contact_0);
	}

	[CompilerGenerated]
	private double CloneReader(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(myUnit, contact_0);
	}

	[CompilerGenerated]
	private double ConnectReader(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(myUnit, contact_0);
	}

	[CompilerGenerated]
	private bool MoveReader(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW)
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool DeleteReader(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsMissile && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).ReadReponse())
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool AddReader(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW)
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool DestroyReader(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW)
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool ComputeReader(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW)
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool PatchReader(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsMissile)
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool SelectReader(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW)
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool CallReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun;
	}

	[CompilerGenerated]
	private bool LogoutReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW;
	}

	[CompilerGenerated]
	private bool ViewReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun;
	}

	[CompilerGenerated]
	private bool ValidateReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW;
	}

	[CompilerGenerated]
	private bool LoginReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun;
	}

	[CompilerGenerated]
	private bool GetReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW;
	}

	[CompilerGenerated]
	private bool WriteReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun;
	}

	[CompilerGenerated]
	private bool NewReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW;
	}

	[CompilerGenerated]
	private bool PushReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW;
	}

	[CompilerGenerated]
	private bool InvokeReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW;
	}

	[CompilerGenerated]
	private bool SetupReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW;
	}

	[CompilerGenerated]
	private bool ExcludeReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW;
	}

	[CompilerGenerated]
	private bool IncludeReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW;
	}

	[CompilerGenerated]
	private bool SearchReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW;
	}

	[CompilerGenerated]
	private bool EnableReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun;
	}

	[CompilerGenerated]
	private bool ChangeReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW;
	}

	[CompilerGenerated]
	private bool InitReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.Gun;
	}

	[CompilerGenerated]
	private bool CheckReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAAW;
	}

	[CompilerGenerated]
	private bool ConcatReader(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASW)
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool InterruptReader(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun)
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool RemoveReader(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land)
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool FindReader(WeaponRec weaponRec_0)
	{
		if ((weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval || weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land) && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun)
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool SetReader(WeaponRec weaponRec_0)
	{
		if (!weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval && !weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land)
		{
			return false;
		}
		return weaponRec_0.CurrentLoad > 0;
	}

	[CompilerGenerated]
	private bool FillReader(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun)
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool CalculateReader(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval)
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool PopReader(WeaponRec weaponRec_0)
	{
		if (!weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval)
		{
			return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land;
		}
		return true;
	}

	[CompilerGenerated]
	private bool InstantiateReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval;
	}

	[CompilerGenerated]
	private bool CreateReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land;
	}

	[CompilerGenerated]
	private bool CompareReader(WeaponRec weaponRec_0)
	{
		if (!weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval)
		{
			return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land;
		}
		return true;
	}

	[CompilerGenerated]
	private bool ReadReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval;
	}

	[CompilerGenerated]
	private bool DisableReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land;
	}

	[CompilerGenerated]
	private bool UpdateReader(WeaponRec weaponRec_0)
	{
		if (!weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval && !weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land)
		{
			return false;
		}
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun;
	}

	[CompilerGenerated]
	private bool InsertReader(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval)
		{
			return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun;
		}
		return false;
	}

	[CompilerGenerated]
	private bool PrepareReader(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land)
		{
			return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun;
		}
		return false;
	}

	[CompilerGenerated]
	private bool ReflectReader(WeaponRec weaponRec_0)
	{
		if ((weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval || weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land || weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAntiradar) && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun)
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool VisitReader(WeaponRec weaponRec_0)
	{
		if ((weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land || weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAntiradar) && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun)
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool RestartReader(WeaponRec weaponRec_0)
	{
		if ((weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval || weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAntiradar) && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun)
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool TestReader(WeaponRec weaponRec_0)
	{
		if (!weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval && !weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land && !weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAntiradar)
		{
			return false;
		}
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun;
	}

	[CompilerGenerated]
	private bool StopReader(WeaponRec weaponRec_0)
	{
		if (!weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Land && !weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAntiradar)
		{
			return false;
		}
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun;
	}

	[CompilerGenerated]
	private bool CancelReader(WeaponRec weaponRec_0)
	{
		if (!weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsASuW_Naval && !weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsAntiradar)
		{
			return false;
		}
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun;
	}

	[CompilerGenerated]
	private bool VerifyReader(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.CurrentLoad > 0)
		{
			return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsMobileDecoy;
		}
		return false;
	}

	[CompilerGenerated]
	private bool ListReader(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).UpdateReponse() && weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).Type != Weapon._WeaponType.Gun)
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool ResolveReader(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).UpdateReponse())
		{
			return weaponRec_0.CurrentLoad > 0;
		}
		return false;
	}

	[CompilerGenerated]
	private bool PostReader(WeaponRec weaponRec_0)
	{
		return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).UpdateReponse();
	}

	[CompilerGenerated]
	private bool RunReader(WeaponRec weaponRec_0)
	{
		if (weaponRec_0.CurrentLoad > 0)
		{
			return weaponRec_0.GetReferenceWeapon(myUnit.ParentScen).IsMine;
		}
		return false;
	}
}
