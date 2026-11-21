using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Module_ActiveUnit
{
	private static object m_RepositoryConsumer;

	static Module_ActiveUnit()
	{
		m_RepositoryConsumer = RuntimeHelpers.GetObjectValue(new object());
	}

	public static bool IsVehicleDecoy(ActiveUnit activeUnit_0)
	{
		if (activeUnit_0.IsWeapon)
		{
			if (((Weapon)activeUnit_0).Type == Weapon._WeaponType.Decoy_Vehicle)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	internal static bool CancelTokenizer(ActiveUnit activeUnit)
	{
		if (!activeUnit.IsFacility || !(activeUnit is Facility { HasAimpoints: var hasAimpoints }))
		{
			return false;
		}
		return hasAimpoints;
	}

	internal static bool VerifyTokenizer(ActiveUnit activeUnit)
	{
		if (activeUnit.IsFacility && activeUnit is Facility facility)
		{
			if (facility.RepresentsMobileGroundUnit)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool IsGuidedWeapon(ActiveUnit activeUnit_0)
	{
		if (activeUnit_0.IsWeapon)
		{
			if (((Weapon)activeUnit_0).Type == Weapon._WeaponType.GuidedWeapon)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public static bool HasIncomingGuidedWeapons(ActiveUnit activeUnit_0, Scenario scenario_0)
	{
		try
		{
			if (scenario_0.GuidedWeaponsInAir.Count > 0)
			{
				List<Weapon> guidedWeaponsInAir = scenario_0.GuidedWeaponsInAir;
				if (guidedWeaponsInAir == null)
				{
					return false;
				}
				foreach (Weapon item in guidedWeaponsInAir)
				{
					if (item == null)
					{
						continue;
					}
					Weapon_AI aI = item.AI;
					if (aI == null || aI.PrimaryTarget == null || aI?.PrimaryTarget?.ActualUnit == null || aI?.PrimaryTarget?.ActualUnit != activeUnit_0)
					{
						if (!item.IsMIRVedMissile.Value)
						{
							continue;
						}
						Contact[] targets_ReadOnly = aI.Targets_ReadOnly;
						Contact[] array = targets_ReadOnly;
						foreach (Contact contact in array)
						{
							if (contact.ActualUnit != null && contact.ActualUnit == activeUnit_0)
							{
								return true;
							}
						}
						continue;
					}
					return true;
				}
			}
			object repositoryConsumer = m_RepositoryConsumer;
			ObjectFlowControl.CheckForSyncLockOnValueType(repositoryConsumer);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(repositoryConsumer, ref lockTaken);
				try
				{
					List<ActiveUnit> list;
					try
					{
						list = new List<ActiveUnit>(scenario_0.NewbornUnits);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						list = new List<ActiveUnit>(scenario_0.NewbornUnits);
						ProjectData.ClearProjectError();
					}
					foreach (ActiveUnit item2 in list)
					{
						if (item2 != null && item2.IsWeapon)
						{
							Weapon_AI aI2 = ((Weapon)item2).AI;
							if (aI2.PrimaryTarget != null && aI2.PrimaryTarget.ActualUnit != null && aI2.PrimaryTarget.ActualUnit == activeUnit_0)
							{
								return true;
							}
						}
					}
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(repositoryConsumer);
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200273", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}
}
