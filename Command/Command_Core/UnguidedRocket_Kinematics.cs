using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class UnguidedRocket_Kinematics : Weapon_Kinematics
{
	private float? m_MockProxy;

	private bool? tagProxy;

	public UnguidedRocket_Kinematics(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}

	public override float PitchRate_Negative()
	{
		return 1f;
	}

	public override float PitchRate_Positive()
	{
		return 1f;
	}

	public override float RollRate()
	{
		return 25f;
	}

	public override float TurnRate()
	{
		float num = Physics.CompareStub(base.myWeapon.GetCurrentAltitude(), base.myWeapon.CurrentSpeed);
		if (num <= 8f)
		{
			if (num <= 7f)
			{
				if (num <= 6f)
				{
					if (num <= 5f)
					{
						if (num <= 4f)
						{
							if (num <= 3f)
							{
								if (num <= 2f)
								{
									if (num <= 1f)
									{
										return 10f;
									}
									return 9f;
								}
								return 8f;
							}
							return 7f;
						}
						return 6f;
					}
					return 5f;
				}
				return 4f;
			}
			return 3f;
		}
		return 2f;
	}

	public override int GetMaximumSpeed(float float_0, ActiveUnit.Throttle throttle_0, bool bool_0, bool bool_1 = true)
	{
		return (int)Math.Round(UnguidedWeapon.CalculateGunMuzzleVelocity_mpersec(Contact_Base.ContactType.Air, base.myWeapon.MaxRange_NoTargetType, method_0()) * 1.94384);
	}

	public override float GetMaximumAltitude()
	{
		if (!m_MockProxy.HasValue)
		{
			float value = (float)(Math.Pow(UnguidedWeapon.CalculateGunMuzzleVelocity_mpersec(Contact_Base.ContactType.Air, base.myWeapon.MaxRange_NoTargetType, method_0()), 2.0) * Math.Pow(Math.Sin(1.570796326794897), 2.0) / 19.62);
			m_MockProxy = value;
		}
		return m_MockProxy.Value;
	}

	public override float GetMinimumAltitude()
	{
		return 0f;
	}

	[SpecialName]
	private bool method_0()
	{
		try
		{
			if (!tagProxy.HasValue)
			{
				if (base.myWeapon.AI.PrimaryTarget == null)
				{
					return false;
				}
				tagProxy = !base.myWeapon.SetReponse() && !base.myWeapon.AI.PrimaryTarget.IsAircraftContact && !base.myWeapon.AI.PrimaryTarget.IsWeaponContact;
			}
			return tagProxy.Value;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public override void Move(float float_0, bool bool_0, bool bool_1, DateTime dateTime_0)
	{
		double double_ = base.myWeapon.GetLatitude();
		double double_2 = base.myWeapon.GetLongitude();
		Contact primaryTarget = base.myWeapon.AI.PrimaryTarget;
		double num;
		double num8;
		float num9;
		double num10;
		if (primaryTarget == null)
		{
			num = base.myWeapon.AI.PrimaryTarget_LastKnown_Lat;
			num8 = base.myWeapon.AI.PrimaryTarget_LastKnown_Lon;
			num9 = base.myWeapon.AI.PrimaryTarget_LastKnown_Altitude;
			num10 = UnguidedWeapon.CalculateGunMuzzleVelocity_mpersec(Contact_Base.ContactType.Air, base.myWeapon.MaxRange_NoTargetType, method_0());
		}
		else
		{
			num = primaryTarget.GetLatitude();
			num8 = primaryTarget.GetLongitude();
			num9 = primaryTarget.GetCurrentAltitude();
			num10 = UnguidedWeapon.CalculateGunMuzzleVelocity_mpersec(primaryTarget.Type, base.myWeapon.MaxRange_NoTargetType, method_0());
		}
		double num11 = base.myWeapon.LaunchPoint.RangeToPoint_Horiz(num8, num);
		if (method_0())
		{
			double num12 = num11 * 1852.0;
			double num13 = (base.myWeapon.FiringParent.IsAerospaceUnit ? Math.Atan((Math.Pow(num10, 2.0) - Math.Sqrt(Math.Pow(num10, 4.0) - 9.81 * (9.81 * Math.Pow(num12, 2.0) + (double)(2f * (num9 - base.myWeapon.LaunchPoint.Altitude)) * Math.Pow(num10, 2.0)))) / (9.81 * num12)) : Math.Atan((Math.Pow(num10, 2.0) + Math.Sqrt(Math.Pow(num10, 4.0) - 9.81 * (9.81 * Math.Pow(num12, 2.0) + (double)(2f * (num9 - base.myWeapon.LaunchPoint.Altitude)) * Math.Pow(num10, 2.0)))) / (9.81 * num12)));
			num13 = Math.Abs(num13 * (180.0 / Math.PI));
			double num14 = Math.Pow(num10, 2.0) * Math.Pow(Math2.SetClass(num13), 2.0) / 19.62;
			double double_3 = num10 * 1.94384 * Math2.CalculateClass(num13) * (double)float_0 / 3600.0;
			Weapon weapon = base.myWeapon;
			float float_ = weapon.CurrentHeading;
			double double_4 = 0.0;
			double double_5 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(ref double_2, ref double_, ref double_4, ref double_5, ref double_3, ref float_);
			weapon.CurrentHeading = float_;
			base.myWeapon.SetLongitude(null, double_4);
			base.myWeapon.SetLatitude(null, double_5);
			double num15 = num11 * 0.5 * 1852.0;
			double num2 = num14 / Math.Pow(num15, 2.0);
			double x = Math.Abs((double)(Module_Unit.RangeToPoint_Horiz(base.myWeapon, base.myWeapon.LaunchPoint) * 1852f) - num15);
			double num3 = 0.0 - num2 * Math.Pow(x, 2.0) + num14;
			base.myWeapon.SetCurrentAltitude(bool_0: false, Math.Max(1f, (float)(num3 + (double)base.myWeapon.LaunchPoint.Altitude)));
		}
		else
		{
			base.myWeapon.ActualHorizMovement(float_0, bool_0: false);
			float num4 = Math.Abs(base.myWeapon.LaunchPoint.Altitude - num9);
			double num5 = (double)Module_Unit.RangeToPoint_Horiz(base.myWeapon, num, num8) / num11;
			if (num5 > 1.0)
			{
				num5 = 0.99999;
			}
			if (num9 <= base.myWeapon.LaunchPoint.Altitude)
			{
				base.myWeapon.SetCurrentAltitude(bool_0: false, (float)((double)num9 + (double)num4 * num5));
			}
			else
			{
				base.myWeapon.SetCurrentAltitude(bool_0: false, (float)((double)num9 - (double)num4 * num5));
			}
		}
		TurnToDesiredHeading(float_0);
		double num6 = Module_Unit.RangeToPoint_Slant(base.myWeapon, base.myWeapon.LaunchPoint) / base.myWeapon.MaxRange_NoTargetType;
		double num7 = num10 * 1.94384;
		base.myWeapon.CurrentSpeed = (float)(num7 * (0.34 + 0.67 * (1.0 - num6)));
		if (!bool_1)
		{
			myUnit.Kinematics.ExportLocationEvent(myUnit.Kinematics.PerformOutOfSequenceExportLocation);
		}
		Module_Unit.FlushTokenizer(myUnit, float_0);
	}
}
