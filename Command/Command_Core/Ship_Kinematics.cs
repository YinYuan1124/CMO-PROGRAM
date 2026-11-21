using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Ship_Kinematics : ActiveUnit_Kinematics
{
	public Ship_Kinematics(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}

	public override long RemainingEndurance(float float_0, float float_1, bool bool_0, bool bool_1)
	{
		if (((Ship)myUnit).IsNuke)
		{
			return long.MaxValue;
		}
		return base.RemainingEndurance(float_0, float_1, bool_0, bool_1);
	}

	internal float StartOrder()
	{
		int emptyWeight = myUnit.EmptyWeight;
		if (emptyWeight < 350)
		{
			return 10f;
		}
		if (emptyWeight < 2500)
		{
			return 2.5f;
		}
		if (emptyWeight < 5000)
		{
			return 0.1f;
		}
		if (emptyWeight < 50000)
		{
			return 0.01f;
		}
		return 0.001f;
	}

	public override float TurnRate()
	{
		int emptyWeight = myUnit.EmptyWeight;
		float num = ((emptyWeight < 350) ? 20f : ((emptyWeight < 5500) ? 5f : ((emptyWeight < 18000) ? 3f : ((emptyWeight < 50000) ? 1f : 0.7f))));
		if (myUnit.IsMCMPlatform)
		{
			num *= 3f;
		}
		return num;
	}

	public static int GetMaximumSpeedForThisSeaState(Ship ship_0, int int_0)
	{
		int maximumSpeed = ship_0.Kinematics.GetMaximumSpeed();
		float displacement_Standard = ship_0.Displacement_Standard;
		if (displacement_Standard > 5500f)
		{
			switch (int_0)
			{
			default:
				return 0;
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
				return maximumSpeed;
			case 6:
				return (int)Math.Round((double)maximumSpeed * 0.75);
			case 7:
				return (int)Math.Round((double)maximumSpeed * 0.5);
			case 8:
				return (int)Math.Round((double)maximumSpeed * 0.25);
			}
		}
		if (displacement_Standard > 1500f)
		{
			switch (int_0)
			{
			default:
				return 0;
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
				return maximumSpeed;
			case 5:
				return (int)Math.Round((double)maximumSpeed * 0.75);
			case 6:
			case 7:
				return (int)Math.Round((double)maximumSpeed * 0.5);
			case 8:
				return (int)Math.Round((double)maximumSpeed * 0.25);
			}
		}
		if (displacement_Standard > 350f)
		{
			switch (int_0)
			{
			default:
				return 0;
			case 0:
			case 1:
			case 2:
			case 3:
				return maximumSpeed;
			case 4:
				return (int)Math.Round((double)maximumSpeed * 0.75);
			case 5:
			case 6:
				return (int)Math.Round((double)maximumSpeed * 0.5);
			case 7:
				return (int)Math.Round((double)maximumSpeed * 0.25);
			}
		}
		switch (int_0)
		{
		default:
			return 0;
		case 0:
		case 1:
		case 2:
			return maximumSpeed;
		case 3:
			return (int)Math.Round((double)maximumSpeed * 0.75);
		case 4:
			return (int)Math.Round((double)maximumSpeed * 0.5);
		case 5:
			return (int)Math.Round((double)maximumSpeed * 0.25);
		}
	}

	public override float TacticalRadius()
	{
		if (((Ship)myUnit).IsNuke)
		{
			return float.PositiveInfinity;
		}
		if (_TacticalRadius <= 0f)
		{
			float num = MaxRange(bool_0: true, null, null);
			_TacticalRadius = num / 2f;
			return _TacticalRadius;
		}
		return _TacticalRadius;
	}

	public override float MaxRange(bool bool_0, float? nullable_0, float? nullable_1)
	{
		try
		{
			if (((Ship)myUnit).IsNuke)
			{
				return float.MaxValue;
			}
			if (myUnit.Propulsion.Count == 0)
			{
				return 0f;
			}
			if (myUnit.Propulsion[0].AltBands.Length == 0)
			{
				return 0f;
			}
			ActiveUnit.Throttle throttle_ = (Information.IsNothing(myUnit.AssignedMissionOrPackage()) ? ActiveUnit.Throttle.Cruise : ((myUnit.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Strike) ? ActiveUnit.Throttle.Cruise : ((((Strike)myUnit.AssignedMissionOrPackage()).Type == Strike.StrikeType.Air_Intercept) ? ActiveUnit.Throttle.Full : ActiveUnit.Throttle.Cruise)));
			return (float)(GetMaxEndurance(throttle_, nullable_0, nullable_1, bool_0, 0f) * (double)GetMaximumSpeed(myUnit.Propulsion[0].GetOptimumAltBandForThisThrottle(throttle_).MaxAlt, throttle_, bool_0: false) / 3600.0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100788", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return float.MaxValue;
		}
	}

	[SpecialName]
	public double GetMaxEndurance(ActiveUnit.Throttle throttle_0, float? nullable_0, float? nullable_1, bool bool_0, float float_0)
	{
		try
		{
			double num = 0.0;
			foreach (Engine item in myUnit.Propulsion)
			{
				double num2 = 0.0;
				foreach (FuelRec item2 in myUnit.Fuel_ReadOnly)
				{
					if (item.CanUseThisFuelType(item2.FuelType))
					{
						num2 += (double)(item2.CurrentQuantity / myUnit.FuelConsumption(throttle_0, item.GetOptimumAltBandForThisThrottle(throttle_0), null, null, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false));
					}
				}
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100789", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return double.MaxValue;
		}
	}

	public override float CurrentRangeAtBingoThrottleAltitudeDepth(Doctrine._FuelState? nullable_0)
	{
		try
		{
			float num = 0f;
			foreach (FuelRec item in myUnit.Fuel_ReadOnly)
			{
				num += item.CurrentQuantity;
			}
			AltBand optimumAltBandForThisThrottle = myUnit.Propulsion[0].GetOptimumAltBandForThisThrottle(ActiveUnit.Throttle.Cruise);
			return (float)((double)(num / myUnit.FuelConsumption(ActiveUnit.Throttle.Cruise, optimumAltBandForThisThrottle, null, null, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false)) * ((double)GetMaximumSpeed(optimumAltBandForThisThrottle.MaxAlt, ActiveUnit.Throttle.Cruise, bool_0: false) / 3600.0));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100790", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return float.MaxValue;
		}
	}

	public override float Acceleration_Nominal(ActiveUnit.Throttle throttle_0, float float_0)
	{
		float num;
		if (myUnit.CurrentSpeed < (float)((double)GetMaximumSpeed(0f, myUnit.MaxPossibleThrottleSetting, bool_0: false) / 2.0))
		{
			int emptyWeight = myUnit.EmptyWeight;
			num = ((emptyWeight < 350) ? (8f / 9f) : ((emptyWeight < 5500) ? 0.5f : ((emptyWeight < 18000) ? (2f / 9f) : ((emptyWeight < 50000) ? (2f / 15f) : (4f / 45f)))));
		}
		else
		{
			int emptyWeight2 = myUnit.EmptyWeight;
			num = ((emptyWeight2 < 350) ? (4f / 9f) : ((emptyWeight2 < 5500) ? 0.25f : ((emptyWeight2 < 18000) ? (1f / 9f) : ((emptyWeight2 < 50000) ? (1f / 15f) : (2f / 45f)))));
		}
		if (((Ship)myUnit).Category == Ship._ShipCategory.Merchant)
		{
			num /= 2f;
		}
		if (((Ship)myUnit).IsNuke)
		{
			num = (float)(1.5 * (double)num);
		}
		return num;
	}

	public override float Acceleration_Actual(ActiveUnit.Throttle throttle_0, float float_0, float float_1)
	{
		float num = Acceleration_Nominal(throttle_0, float_0);
		float result = num;
		if (myUnit.ThrottleSetting != 0)
		{
			result = num * (float)(int)myUnit.ThrottleSetting / 2f;
		}
		return result;
	}

	public override void CalcTurnDeceleration(double double_0, float float_0)
	{
		if (myUnit.DesiredTurnRate != ActiveUnit.TurnRate.Navigation)
		{
			double num = GetMaximumSpeed(0f, ActiveUnit.Throttle.Flank, bool_0: false);
			double num2 = ((num <= 0.0) ? (0.5 * double_0 * (double)float_0) : (0.5 * double_0 * (double)float_0 * (((double)myUnit.CurrentSpeed + 1E-06) / num)));
			int num3 = (int)Math.Round(Math.Abs(myUnit.CurrentHeading - myUnit.DesiredHeading));
			if (num3 < 5)
			{
				num2 = 0.0;
			}
			else if (num3 < 15)
			{
				num2 *= 0.25;
			}
			else if (num3 < 30)
			{
				num2 *= 0.5;
			}
			myUnit.CurrentSpeed = (float)((double)myUnit.CurrentSpeed - num2);
			if (myUnit.CurrentSpeed < 0f)
			{
				myUnit.CurrentSpeed = 0f;
			}
		}
	}

	public override float GetMinimumAltitude()
	{
		return 0f;
	}

	public override float GetMaximumAltitude()
	{
		return 0f;
	}
}
