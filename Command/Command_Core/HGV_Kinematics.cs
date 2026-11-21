using System;

namespace Command_Core;

public sealed class HGV_Kinematics : Weapon_Kinematics
{
	public HGV_Kinematics(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}

	public override float PitchRate_Negative()
	{
		return 2f;
	}

	public override float PitchRate_Positive()
	{
		return 2f;
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

	public override void ChangeAltitude(float float_0, float float_1, float? nullable_0, bool bool_0)
	{
		myUnit.Altitude_old = myUnit.GetCurrentAltitude();
		if (myUnit.Attitude_Pitch != 0f)
		{
			double num = Math2.FillClass(myUnit.Attitude_Pitch) * (double)myUnit.CurrentSpeed * 0.514444 * (double)float_0;
			ActiveUnit activeUnit;
			(activeUnit = myUnit).SetCurrentAltitude(bool_0: false, activeUnit.GetCurrentAltitude() + (float)num);
		}
	}

	public override void Move(float float_0, bool bool_0, bool bool_1, DateTime dateTime_0)
	{
		base.myWeapon.TimeSinceLaunch = base.myWeapon.TimeSinceLaunch + float_0;
		if (!Module_Unit.MapTokenizer(myUnit))
		{
			SimpleBallisticFlight_Vaccum(float_0, myUnit.Attitude_Pitch, bool_1);
			if (myUnit.CommStuff.IsConnectedToSideNetwork)
			{
				myUnit.Longitude_LastReported = myUnit.GetLongitude();
				myUnit.Latitude_LastReported = myUnit.GetLatitude();
			}
			else
			{
				if (!myUnit.Longitude_LastReported.HasValue)
				{
					myUnit.Longitude_LastReported = myUnit.GetLongitude();
				}
				if (!myUnit.Latitude_LastReported.HasValue)
				{
					myUnit.Latitude_LastReported = myUnit.GetLatitude();
				}
			}
			if (!bool_1)
			{
				myUnit.Kinematics.ExportLocationEvent(myUnit.Kinematics.PerformOutOfSequenceExportLocation);
			}
			goto IL_06e2;
		}
		if (base.myWeapon.IsPalletWeapon & (base.myWeapon.Attitude_Pitch == base.myWeapon.DesiredPitch))
		{
			base.myWeapon.Kinematics.Loiter(float_0);
		}
		if (!bool_1)
		{
			_ = base.myWeapon.CurrentAltitude_AGL;
		}
		if (base.myWeapon.SupportsAttitude_Pitch)
		{
			AdjustAttitude_Pitch(float_0);
		}
		if (myUnit.DesiredSpeed < 0f)
		{
			myUnit.DesiredSpeed = 0f - myUnit.DesiredSpeed;
		}
		ChangeAltitude(float_0, myUnit.DesiredAltitude, null, bool_0: false);
		float num = GetMaximumSpeed(myUnit.GetCurrentAltitude(), myUnit.ThrottleSetting, bool_0: false, bool_1: false);
		int maximumSpeed_Total = base.myWeapon.Kinematics.GetMaximumSpeed_Total();
		double num2 = (double)(maximumSpeed_Total - 660) / 2.0;
		double num3 = (double)base.myWeapon.MaxRange_NoTargetType / num2 * 3600.0;
		float num4 = (float)((double)maximumSpeed_Total * (1.0 - (double)base.myWeapon.TimeSinceLaunch / num3));
		if (num < myUnit.CurrentSpeed)
		{
			num4 = num;
		}
		myUnit.DesiredSpeed = num4;
		if (myUnit.AI.HoldPosition)
		{
			myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
		}
		else if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
		{
			if (myUnit.Kinematics.ThrottlePreset != UnitThrottlePreset.None && !myUnit.Navigator.m_ErrorWrapper)
			{
				if (myUnit.Status != 0 && myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
				{
					myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
				}
			}
			else
			{
				myUnit.SetThrottle(GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
			}
		}
		if (myUnit.IsOutOfFuel)
		{
			if (myUnit.IsWeapon && myUnit.SupportsAttitude_Pitch)
			{
				if (myUnit.Attitude_Pitch > ((Weapon)myUnit).MoveDescriptor())
				{
					num4 = 0f;
				}
			}
			else
			{
				num4 = 0f;
			}
		}
		if (myUnit.DesiredSpeed > num4)
		{
			myUnit.DesiredSpeed = num4;
		}
		double num5 = myUnit.CurrentHeading;
		if (myUnit.CurrentHeading == myUnit.DesiredHeading)
		{
			ActualMovementVector = myUnit.CurrentHeading;
		}
		else
		{
			TurnToDesiredHeading(float_0);
		}
		if (myUnit.CurrentSpeed != 0f)
		{
			myUnit.ActualHorizMovement(float_0, bool_1);
		}
		double num6 = (double)Math.Abs(MathFunctions.DeleteRequest((float)num5, myUnit.CurrentHeading)) * (double)(1f / float_0);
		CalcTurnDeceleration(num6, float_0);
		bool flag = false;
		if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation && myUnit.Navigator.HasFlightPlan && (!myUnit.IsGroupWingman() || myUnit.GetParentGroup() == null || myUnit.GetParentGroup().GroupLead == null || (int)Math.Round(myUnit.CurrentSpeed) == (int)Math.Round(myUnit.GetParentGroup().GroupLead.CurrentSpeed)) && (int)Math.Round(num5) != (int)Math.Round(myUnit.CurrentHeading))
		{
			if (myUnit.Navigator.PreviousWaypointType.HasValue)
			{
				int? num7 = (int?)myUnit.Navigator.PreviousWaypointType;
				bool? flag2 = (num7.HasValue ? new bool?(num7.GetValueOrDefault() == 15) : null);
				if (!((!flag2) ?? flag2).GetValueOrDefault())
				{
					goto IL_06f5;
				}
			}
			flag = true;
		}
		goto IL_06f5;
		IL_06f5:
		if (!flag && myUnit.CurrentSpeed != myUnit.DesiredSpeed)
		{
			GoToDesiredSpeed(float_0, (float)num6, num4);
		}
		if (myUnit.CommStuff.IsConnectedToSideNetwork)
		{
			myUnit.Longitude_LastReported = myUnit.GetLongitude();
			myUnit.Latitude_LastReported = myUnit.GetLatitude();
		}
		else
		{
			if (!myUnit.Longitude_LastReported.HasValue)
			{
				myUnit.Longitude_LastReported = myUnit.GetLongitude();
			}
			if (!myUnit.Latitude_LastReported.HasValue)
			{
				myUnit.Latitude_LastReported = myUnit.GetLatitude();
			}
		}
		if (!bool_1)
		{
			myUnit.Kinematics.ExportLocationEvent(myUnit.Kinematics.PerformOutOfSequenceExportLocation);
		}
		goto IL_06e2;
		IL_06e2:
		Module_Unit.FlushTokenizer(myUnit, float_0);
	}
}
