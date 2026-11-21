using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class BallisticMissile_AI : Weapon_AI
{
	[CompilerGenerated]
	private sealed class StatusDispatcherList
	{
		public List<Contact> Local_PrimaryTargets;

		public List<Contact> Local_SecondaryTargets;

		public BallisticMissile_AI Me;

		internal bool ResolveInterruptibleTag(Contact theC)
		{
			if (theC.IDStatus >= Contact_Base.IdentificationStatus.KnownClass && !Local_PrimaryTargets.Contains(theC) && !Local_SecondaryTargets.Contains(theC))
			{
				BallisticMissile ballisticMissile = Me.CalcReader();
				ActiveUnit eventVal = Me.m_EventVal;
				Contact contact_ = theC;
				bool? nullable_ = null;
				return ballisticMissile.QueryReponse(eventVal, ref contact_, ref nullable_);
			}
			return false;
		}
	}

	private BallisticMissile contextObserver;

	public BallisticMissile_AI(Weapon weapon_0)
		: base(weapon_0)
	{
	}

	private BallisticMissile CalcReader()
	{
		if (contextObserver == null)
		{
			contextObserver = (BallisticMissile)m_EventVal;
		}
		return contextObserver;
	}

	public void method_0()
	{
		if (!CalcReader().Flags.IsBallisticMissile || !CalcReader().Flags.Warhead_MIRV || CalcReader().Warheads.Length < 2 || PrimaryTarget == null || PrimaryTarget.ActualUnit == null)
		{
			return;
		}
		try
		{
			_ = CalcReader().Warheads.Length;
			List<Contact> list = new List<Contact>();
			List<Contact> list2 = new List<Contact>();
			List<Contact> Local_PrimaryTargets = new List<Contact>();
			List<Contact> Local_SecondaryTargets = new List<Contact>();
			List<Contact> list3 = new List<Contact>();
			List<Contact> list4 = new List<Contact>();
			list2 = myWeapon().GetUnitSide().Contacts_List.Where(delegate(Contact contact_0)
			{
				if (contact_0.SideIsKnown && contact_0 != PrimaryTarget && !Information.IsNothing(contact_0.ActualUnit) && contact_0.GetUnitSide() == PrimaryTarget.GetUnitSide() && Module_Unit.RangeToUnit_Horiz(contact_0, PrimaryTarget) < 125f)
				{
					Weapon weapon = myWeapon();
					ActiveUnit eventVal3 = m_EventVal;
					bool? nullable_3 = null;
					return weapon.QueryReponse(eventVal3, ref contact_0, ref nullable_3);
				}
				return false;
			}).ToList();
			Local_PrimaryTargets = (from contact_0 in list2
				where contact_0.IDStatus >= Contact_Base.IdentificationStatus.KnownClass && PrimaryTarget.ActualUnit.DBID == contact_0.ActualUnit.DBID
				orderby Module_Unit.RangeToUnit_Horiz_Angular(contact_0, PrimaryTarget)
				select contact_0).ToList();
			Local_SecondaryTargets = (from contact_0 in list2.Where(delegate(Contact contact_0)
				{
					if (contact_0.IDStatus >= Contact_Base.IdentificationStatus.KnownClass && PrimaryTarget.ActualUnit.DBID != contact_0.ActualUnit.DBID && Operators.CompareString(PrimaryTarget.ActualUnit.SubTypeDescription, contact_0.ActualUnit.SubTypeDescription, TextCompare: false) == 0)
					{
						BallisticMissile ballisticMissile2 = CalcReader();
						ActiveUnit eventVal2 = m_EventVal;
						Contact contact_2 = contact_0;
						bool? nullable_2 = null;
						return ballisticMissile2.QueryReponse(eventVal2, ref contact_2, ref nullable_2);
					}
					return false;
				})
				orderby Module_Unit.RangeToUnit_Horiz_Angular(contact_0, PrimaryTarget)
				select contact_0).ToList();
			list3 = (from contact_0 in list2.Where(delegate(Contact theC)
				{
					if (theC.IDStatus >= Contact_Base.IdentificationStatus.KnownClass && !Local_PrimaryTargets.Contains(theC) && !Local_SecondaryTargets.Contains(theC))
					{
						BallisticMissile ballisticMissile = CalcReader();
						ActiveUnit eventVal = m_EventVal;
						Contact contact_ = theC;
						bool? nullable_ = null;
						return ballisticMissile.QueryReponse(eventVal, ref contact_, ref nullable_);
					}
					return false;
				})
				orderby Module_Unit.RangeToUnit_Horiz_Angular(contact_0, PrimaryTarget)
				select contact_0).ToList();
			list.AddRange(Local_PrimaryTargets);
			list.AddRange(Local_SecondaryTargets);
			list.AddRange(list3);
			int? num = null;
			Misc.ShuffleList(list);
			if (list.Count <= 0)
			{
				return;
			}
			int num2 = CalcReader().Warheads.Length - 1;
			for (int i = 1; i <= num2; i++)
			{
				try
				{
					if (list4.Count == 0)
					{
						num = RateReader(list);
						if (Information.IsNothing(num))
						{
							break;
						}
						foreach (Contact item in list)
						{
							int? num3 = num;
							int num4 = item.InvokeImporter();
							if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == num4) : null).GetValueOrDefault())
							{
								list4.Add(item);
							}
						}
						if (list.Count == 0)
						{
							break;
						}
					}
					for (int j = list4.Count - 1; j >= 0; j += -1)
					{
						TargetThisContact(list4[j], bool_0: false, bool_1: false, TargetingEntry._TargetingBehavior.AutoTargeted);
						list4.RemoveAt(j);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200050", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100966", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private int? RateReader(List<Contact> list_0)
	{
		int num = 9999;
		foreach (Contact item in list_0)
		{
			int num2 = item.InvokeImporter();
			if (num2 < num)
			{
				num = num2;
			}
		}
		return num;
	}

	public override void DetermineDesiredAttitudeAndThrottle(float float_0, bool bool_0 = true)
	{
		if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
		{
			ActiveUnit_Navigator navigator = m_EventVal.Navigator;
			bool bool_ = false;
			bool bool_2 = false;
			navigator.CheckIfReachedWaypoint(float_0, ref bool_, ref bool_2);
		}
		if (CalcReader().IsPerformingTerminalManeuvers)
		{
			base.DetermineDesiredAttitudeAndThrottle(float_0, bool_0);
		}
	}

	public override void DetermineDesiredAltitude(float float_0)
	{
		if (CalcReader().IsPerformingTerminalManeuvers)
		{
			base.DetermineDesiredAltitude(float_0);
		}
	}

	protected override void Trajectory_LoftedFlight(float float_0)
	{
		if (CalcReader().IsPerformingTerminalManeuvers)
		{
			base.Trajectory_LoftedFlight(float_0);
		}
	}

	[CompilerGenerated]
	private bool FlushReader(Contact contact_0)
	{
		if (contact_0.SideIsKnown && contact_0 != PrimaryTarget && !Information.IsNothing(contact_0.ActualUnit) && contact_0.GetUnitSide() == PrimaryTarget.GetUnitSide() && Module_Unit.RangeToUnit_Horiz(contact_0, PrimaryTarget) < 125f)
		{
			Weapon weapon = myWeapon();
			ActiveUnit eventVal = m_EventVal;
			bool? nullable_ = null;
			return weapon.QueryReponse(eventVal, ref contact_0, ref nullable_);
		}
		return false;
	}

	[CompilerGenerated]
	private bool ForgotReader(Contact contact_0)
	{
		if (contact_0.IDStatus >= Contact_Base.IdentificationStatus.KnownClass)
		{
			return PrimaryTarget.ActualUnit.DBID == contact_0.ActualUnit.DBID;
		}
		return false;
	}

	[CompilerGenerated]
	private double CollectReader(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(contact_0, PrimaryTarget);
	}

	[CompilerGenerated]
	private bool OrderReader(Contact contact_0)
	{
		if (contact_0.IDStatus >= Contact_Base.IdentificationStatus.KnownClass && PrimaryTarget.ActualUnit.DBID != contact_0.ActualUnit.DBID && Operators.CompareString(PrimaryTarget.ActualUnit.SubTypeDescription, contact_0.ActualUnit.SubTypeDescription, TextCompare: false) == 0)
		{
			BallisticMissile ballisticMissile = CalcReader();
			ActiveUnit eventVal = m_EventVal;
			Contact contact_ = contact_0;
			bool? nullable_ = null;
			return ballisticMissile.QueryReponse(eventVal, ref contact_, ref nullable_);
		}
		return false;
	}

	[CompilerGenerated]
	private double RegisterReader(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(contact_0, PrimaryTarget);
	}

	[CompilerGenerated]
	private double ManageReader(Contact contact_0)
	{
		return Module_Unit.RangeToUnit_Horiz_Angular(contact_0, PrimaryTarget);
	}
}
