using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Aircraft_Kinematics : ActiveUnit_Kinematics
{
	public enum G_Straining_Mode : byte
	{
		StrainingToLimit,
		Recovering
	}

	private Aircraft _DescriptorObserver;

	private float poolObserver;

	internal const int taskObserver = -80;

	internal G_Straining_Mode _FilterObserver;

	private float _TestsObserver;

	private float m_InterpreterObserver;

	public int MaxPositivePitchAngle
	{
		get
		{
			float agility_Nominal = GetAircraft().Agility_Nominal;
			if (agility_Nominal <= 1f)
			{
				return 20;
			}
			if (agility_Nominal <= 2f)
			{
				return 30;
			}
			if (agility_Nominal <= 3f)
			{
				return 45;
			}
			if (agility_Nominal <= 4f)
			{
				return 60;
			}
			if (agility_Nominal < 5f)
			{
				return 70;
			}
			return 80;
		}
	}

	public bool IsInCombatManouvers
	{
		get
		{
			if (myUnit.Status == ActiveUnit._ActiveUnitStatus.Unassigned)
			{
				return false;
			}
			if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation && myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedDefensive && myUnit.Status != ActiveUnit._ActiveUnitStatus.EngagedOffensive)
			{
				return false;
			}
			return true;
		}
	}

	public int CornerVelocity => (int)Math.Round(1.5 * (double)myUnit.Kinematics.GetMaximumSpeed(myUnit.GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false));

	[SpecialName]
	private Aircraft GetAircraft()
	{
		if (_DescriptorObserver == null)
		{
			_DescriptorObserver = (Aircraft)myUnit;
		}
		return _DescriptorObserver;
	}

	public Aircraft_Kinematics(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}

	public override void DetermineReserveFuelQty(bool bool_0 = false)
	{
		try
		{
			float num = 0f;
			foreach (FuelRec item in myUnit.Fuel_ReadOnly)
			{
				num += (float)item.MaxQuantity;
			}
			int num2 = 0;
			int num3 = 0;
			float num4 = 0f;
			if (GetAircraft().Loadout != null && GetAircraft().Loadout.GetMissionProfile(GetAircraft().ParentScen) != null)
			{
				num2 = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).ReservePercentage;
				num3 = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).ReserveLoiterTime;
				num4 = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).ReserveLoiterAltitude;
			}
			float num5 = 0f;
			if (num2 > 0)
			{
				num5 = (float)((double)num * ((double)num2 / 100.0));
			}
			if (num3 > 0 && num4 > 0f)
			{
				num5 += myUnit.FuelConsumption(ActiveUnit.Throttle.Loiter, null, GetMaximumSpeed(num4, ActiveUnit.Throttle.Loiter, bool_0: false), num4, bool_0: false, bool_1: true, bool_2: false, bool_3: false, bool_4: false) * 60f * (float)num3;
			}
			myUnit.Kinematics.ReserveFuel = num5;
			if (bool_0)
			{
				myUnit.Kinematics.JokerFuel = 0f;
				return;
			}
			float num6 = num - num5;
			Doctrine._FuelState? bingoJoker = myUnit.Doctrine.GetBingoJoker(myUnit.ParentScen, bool_0: false, bool_1: true, bool_2: false, bool_3: false);
			byte? b = (byte?)bingoJoker;
			float jokerFuel;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				jokerFuel = 0f;
			}
			else
			{
				b = (byte?)bingoJoker;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					jokerFuel = (float)((double)num6 * 0.1);
				}
				else
				{
					b = (byte?)bingoJoker;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						jokerFuel = (float)((double)num6 * 0.2);
					}
					else
					{
						b = (byte?)bingoJoker;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							jokerFuel = (float)((double)num6 * 0.25);
						}
						else
						{
							b = (byte?)bingoJoker;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								jokerFuel = (float)((double)num6 * 0.3);
							}
							else
							{
								b = (byte?)bingoJoker;
								if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 5) : null).GetValueOrDefault())
								{
									jokerFuel = (float)((double)num6 * 0.4);
								}
								else
								{
									b = (byte?)bingoJoker;
									if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 6) : null).GetValueOrDefault())
									{
										jokerFuel = (float)((double)num6 * 0.5);
									}
									else
									{
										b = (byte?)bingoJoker;
										if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 7) : null).GetValueOrDefault())
										{
											jokerFuel = (float)((double)num6 * 0.6);
										}
										else
										{
											b = (byte?)bingoJoker;
											if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 8) : null).GetValueOrDefault())
											{
												jokerFuel = (float)((double)num6 * 0.7);
											}
											else
											{
												b = (byte?)bingoJoker;
												if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 9) : null).GetValueOrDefault())
												{
													jokerFuel = (float)((double)num6 * 0.75);
												}
												else
												{
													b = (byte?)bingoJoker;
													if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 10) : null).GetValueOrDefault())
													{
														jokerFuel = (float)((double)num6 * 0.8);
													}
													else
													{
														b = (byte?)bingoJoker;
														jokerFuel = ((b.HasValue ? new bool?(b.GetValueOrDefault() == 11) : null).GetValueOrDefault() ? ((float)((double)num6 * 0.9)) : 0f);
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			myUnit.Kinematics.JokerFuel = jokerFuel;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200446", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			if (GetAircraft().Loadout == null)
			{
				GameGeneral.ResolveBridge("飞机的挂载" + GetAircraft().Name + " (" + GetAircraft().UnitClass + "） 不存在。", GetAircraft().GetUnitSide());
			}
			else
			{
				GameGeneral.ResolveBridge("挂载" + GetAircraft().Loadout.Name + "对于飞机" + GetAircraft().Name + " (" + GetAircraft().UnitClass + "）在所选数据库中不存在。请为此飞机选择新的挂载。", GetAircraft().GetUnitSide());
			}
			ProjectData.ClearProjectError();
		}
	}

	public override float TacticalRadius()
	{
		if (_TacticalRadius <= 0f)
		{
			_TacticalRadius = MaxRadius();
			return _TacticalRadius;
		}
		return _TacticalRadius;
	}

	public override float MaxRange(bool bool_0, float? nullable_0, float? nullable_1)
	{
		try
		{
			ActiveUnit.Throttle throttle_ = ActiveUnit.Throttle.FullStop;
			if (Information.IsNothing(nullable_0))
			{
				throttle_ = (Information.IsNothing(myUnit.AssignedMissionOrPackage()) ? ActiveUnit.Throttle.Cruise : ((myUnit.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Strike) ? ActiveUnit.Throttle.Cruise : ((((Strike)myUnit.AssignedMissionOrPackage()).Type == Strike.StrikeType.Air_Intercept) ? ActiveUnit.Throttle.Full : ActiveUnit.Throttle.Cruise)));
			}
			if (Information.IsNothing(nullable_1))
			{
				nullable_1 = myUnit.Propulsion[0].GetOptimumAltBandForThisThrottle(throttle_).MaxAlt;
			}
			if (Information.IsNothing(nullable_0))
			{
				nullable_0 = GetMaximumSpeed(nullable_1.Value, throttle_, bool_0: false);
			}
			return (float)(MaxEndurance(throttle_, nullable_0, nullable_1, bool_0, 0f) * (double?)nullable_0 / 3600.0).Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100451", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public override float MaxRadius()
	{
		try
		{
			ActiveUnit.Throttle throttle;
			ActiveUnit.Throttle throttle2;
			if (Information.IsNothing(myUnit.AssignedMissionOrPackage()))
			{
				throttle = ActiveUnit.Throttle.Cruise;
				throttle2 = ActiveUnit.Throttle.Cruise;
			}
			else if (myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				if (((Strike)myUnit.AssignedMissionOrPackage()).Type == Strike.StrikeType.Air_Intercept)
				{
					throttle = ActiveUnit.Throttle.Full;
					throttle2 = ActiveUnit.Throttle.Cruise;
				}
				else
				{
					throttle = ActiveUnit.Throttle.Cruise;
					throttle2 = ActiveUnit.Throttle.Cruise;
				}
			}
			else
			{
				throttle = ActiveUnit.Throttle.Cruise;
				throttle2 = ActiveUnit.Throttle.Cruise;
			}
			ref Scenario parentScen = ref myUnit.ParentScen;
			Aircraft aircraft_ = GetAircraft();
			float float_ = MissionPlanner.CustomizeTokenizer(ref parentScen, ref aircraft_);
			double num = MaxEndurance(throttle, null, null, bool_0: false, float_);
			double num2 = MaxEndurance(throttle2, null, null, bool_0: true, float_);
			double num3 = (num + num2) / 2.0;
			if (throttle == throttle2)
			{
				return (float)(num3 / 2.0 * (double)GetMaximumSpeed(myUnit.Propulsion[0].GetOptimumAltBandForThisThrottle(throttle).MaxAlt, throttle, bool_0: false) / 3600.0);
			}
			return (float)(num3 / 2.0 * ((double)GetMaximumSpeed(myUnit.Propulsion[0].GetOptimumAltBandForThisThrottle(throttle).MaxAlt, throttle, bool_0: false) / 3600.0 + (double)GetMaximumSpeed(myUnit.Propulsion[0].GetOptimumAltBandForThisThrottle(throttle2).MaxAlt, throttle2, bool_0: false) / 3600.0)) / 2f;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100451", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public new double MaxEndurance(ActiveUnit.Throttle throttle_0, float? nullable_0, float? nullable_1, bool bool_0, float float_0)
	{
		try
		{
			float num = 0f;
			foreach (FuelRec item in myUnit.Fuel_ReadOnly)
			{
				num += item.CurrentQuantity;
			}
			num -= myUnit.Kinematics.ReserveFuel;
			num -= float_0;
			if (num < 0f)
			{
				return 0.0;
			}
			AltBand altBand_ = null;
			if (Information.IsNothing(nullable_1))
			{
				altBand_ = myUnit.Propulsion[0].GetOptimumAltBandForThisThrottle(throttle_0);
			}
			return num / myUnit.FuelConsumption(throttle_0, altBand_, nullable_0, nullable_1, bool_0, bool_1: false, bool_2: false, bool_3: false, bool_4: false);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100452", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0.0;
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
			num -= myUnit.Kinematics.ReserveFuel;
			float num3 = num - myUnit.Kinematics.JokerFuel;
			byte? b;
			if (num < 0f)
			{
				b = (byte?)nullable_0;
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					GetAircraft().FuelState_RemainingFuelToBingo = 0f;
					GetAircraft().FuelState_RemainingFuelToJoker = 0f;
					return 0f;
				}
			}
			Aircraft_Navigator navigator = GetAircraft().Navigator;
			ActiveUnit.Throttle throttle = navigator.CollectProxy();
			ActiveUnit.Throttle maxPossibleThrottleSetting = myUnit.MaxPossibleThrottleSetting;
			if ((int)throttle > (int)maxPossibleThrottleSetting)
			{
				throttle = maxPossibleThrottleSetting;
			}
			bool bool_ = false;
			float num4 = navigator.OrderProxy(ref bool_);
			float maximumAltitude = myUnit.Kinematics.GetMaximumAltitude();
			if (num4 > maximumAltitude)
			{
				num4 = maximumAltitude;
			}
			int maximumSpeed = GetMaximumSpeed(num4, throttle, bool_0: false);
			float num5 = myUnit.FuelConsumption(throttle, null, maximumSpeed, num4, bool_0: true, bool_1: false, bool_2: false, bool_3: false, bool_4: false);
			float num6 = num / num5;
			float num7 = num3 / num5;
			float num8 = num6 * (float)maximumSpeed / 3600f;
			float num9 = num7 * (float)maximumSpeed / 3600f;
			double num10 = num8 - GetAircraft().FuelState_DistanceToBase;
			double num2 = num9 - GetAircraft().FuelState_DistanceToBase;
			GetAircraft().FuelState_RemainingFuelToBingo = Math.Max((float)(num10 / (double)num8) * num, 0f);
			GetAircraft().FuelState_RemainingFuelToJoker = Math.Max((float)(num2 / (double)num9) * num3, 0f);
			b = (byte?)nullable_0;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				return num8;
			}
			return num9;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100453", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public override void Loiter(float float_0, bool bool_0 = false, bool bool_1 = false)
	{
		try
		{
			myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Max, Math2.UpdateClass(myUnit.CurrentHeading + 3f * float_0));
			myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100454", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void MatchTankerSpeedAndAltitude()
	{
		Aircraft a2AR_Destination = GetAircraft().AirOps.A2AR_Destination;
		if (!Information.IsNothing(a2AR_Destination))
		{
			GetAircraft().SetLatitude(null, a2AR_Destination.GetLatitude());
			GetAircraft().SetLongitude(null, a2AR_Destination.GetLongitude());
			GetAircraft().SetCurrentAltitude(bool_1: false, a2AR_Destination.GetCurrentAltitude() - 4.572f);
			GetAircraft().CurrentHeading = a2AR_Destination.CurrentHeading;
			GetAircraft().CurrentSpeed = a2AR_Destination.CurrentSpeed;
		}
	}

	public void CheckForSinkingCondition(float float_0)
	{
		if (!GetAircraft().IsHelicopter && GetAircraft().AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Landing_PreTouchdown)
		{
			double num = (double)GetMaximumSpeed(GetAircraft().GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false) * Math.Cos((double)GetAircraft().Attitude_Roll * 0.0174532925199433);
			if ((double)GetAircraft().CurrentSpeed < num)
			{
				Aircraft aircraft;
				(aircraft = GetAircraft()).SetCurrentAltitude(bool_1: false, aircraft.GetCurrentAltitude() - (float)(9.81 * (double)float_0 * (1.0 - (double)GetAircraft().CurrentSpeed / num)));
			}
		}
	}

	public override void Move(float float_0, bool bool_0, bool bool_1, DateTime dateTime_0)
	{
		if (!myUnit.IsOperating())
		{
			return;
		}
		try
		{
			Module_Unit.FlushTokenizer(myUnit, float_0);
			AdjustAttitude_Roll(float_0);
			if (float.IsNaN(myUnit.CurrentHeading))
			{
				myUnit.CurrentHeading = 0f;
			}
			if (float.IsNaN(myUnit.DesiredHeading))
			{
				myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Max, myUnit.CurrentHeading);
			}
			double num6;
			bool flag4;
			if (GetAircraft().Status == ActiveUnit._ActiveUnitStatus.Refuelling)
			{
				MatchTankerSpeedAndAltitude();
				ThrottlePreset = UnitThrottlePreset.None;
				GetAircraft().SetThrottle(ActiveUnit.Throttle.FullStop, GetAircraft().CurrentSpeed);
			}
			else if (GetAircraft().Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || !myUnit.IsGroupWingman() || GetAircraft().AirOps.A2AR_Destination == null || myUnit.GetLatitude() != GetAircraft().AirOps.A2AR_Destination.GetLatitude() || myUnit.GetLongitude() != GetAircraft().AirOps.A2AR_Destination.GetLongitude())
			{
				if (GetAircraft().IsMCMPlatform)
				{
					bool flag = false;
					if (!GetAircraft().IsRTB || GetAircraft().Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
					{
						Sensor[] array = myUnit.Sensors_ReadOnly();
						Sensor[] array2 = array;
						foreach (Sensor sensor in array2)
						{
							if ((sensor.IsMineCountermeasure || sensor.IsMineHuntingSensor) && sensor.IsActive)
							{
								flag = true;
								break;
							}
						}
					}
					if (flag && myUnit.DesiredAltitude > 76.200005f)
					{
						myUnit.DesiredAltitude = 76.200005f;
						myUnit.DesiredSpeed = 30f;
					}
				}
				if (myUnit.DesiredSpeed < 0f)
				{
					myUnit.DesiredSpeed = 0f - myUnit.DesiredSpeed;
				}
				(bool, short?) tuple = Terrain.ExcludeWatcher(myUnit.GetLatitude(), myUnit.GetLongitude());
				bool item = tuple.Item1;
				int? num = null;
				if (tuple.Item2.HasValue)
				{
					num = tuple.Item2.Value;
				}
				bool flag2 = false;
				int? num2 = null;
				if (item)
				{
					flag2 = true;
				}
				else
				{
					num2 = myUnit.GetLandElevation_next(bool_0: true, float_0);
					if (num2.Value > 0)
					{
						flag2 = true;
					}
				}
				myUnit.Altitude_old = myUnit.GetCurrentAltitude();
				bool flag3 = false;
				if (!myUnit.GetDesiredAltitude_UseTerrainFollowing(myUnit) && (flag2 || myUnit.DesiredAltitude != myUnit.GetCurrentAltitude()))
				{
					flag3 = true;
				}
				else if (myUnit.GetDesiredAltitude_UseTerrainFollowing(myUnit) && (flag2 || myUnit.DesiredAltitude_AGL != myUnit.GetCurrentAltitude()))
				{
					flag3 = true;
				}
				else if (myUnit.IsGroupWingman() && myUnit.GetParentGroup().GroupLead != null && myUnit.GetParentGroup().GroupLead.GetDesiredAltitude_UseTerrainFollowing(myUnit) && (flag2 || myUnit.DesiredAltitude_AGL != myUnit.GetCurrentAltitude()))
				{
					flag3 = true;
				}
				if (flag3)
				{
					bool desiredAltitude_UseTerrainFollowing;
					float desiredAltitude_AGL;
					if (myUnit.IsGroupWingman() && myUnit.GetParentGroup().GroupLead != null && !myUnit.Kinematics.DesiredAltitudeOverride)
					{
						desiredAltitude_UseTerrainFollowing = myUnit.GetParentGroup().GroupLead.GetDesiredAltitude_UseTerrainFollowing(myUnit.GetParentGroup().GroupLead);
						desiredAltitude_AGL = myUnit.DesiredAltitude_AGL;
					}
					else
					{
						desiredAltitude_UseTerrainFollowing = myUnit.GetDesiredAltitude_UseTerrainFollowing(myUnit);
						desiredAltitude_AGL = myUnit.DesiredAltitude_AGL;
					}
					float float_;
					if (desiredAltitude_UseTerrainFollowing)
					{
						if (!num2.HasValue)
						{
							num2 = myUnit.GetLandElevation_next(bool_0: true, float_0);
						}
						if (!num.HasValue)
						{
							num = myUnit.GetLandElevation(bool_0: true, bool_1: false, bool_2: false, myUnit.ParentScen);
						}
						float num3 = Math.Max(num.Value, num2.Value);
						float_ = desiredAltitude_AGL + num3;
					}
					else
					{
						float_ = myUnit.DesiredAltitude;
					}
					float? nullable_ = null;
					if (GetAircraft().GetCurrentAltitude() < (float)Terrain.GlobalMaxTerrainElevation)
					{
						nullable_ = GetAircraft().MinimumSafeHeight;
					}
					if (GetAircraft().SupportsAttitude_Pitch)
					{
						AdjustAttitude_Pitch(float_0);
					}
					ChangeAltitude(float_0, float_, nullable_, bool_0: true);
				}
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
							Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)myUnit.AirOps;
							if (aircraft_AirOps.RefuellingQueue.Count + aircraft_AirOps.A2AR_Connections.Count == 0)
							{
								myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
							}
						}
					}
					else
					{
						myUnit.SetThrottle(GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
					}
				}
				float num4 = GetMaximumSpeed(myUnit.GetCurrentAltitude(), myUnit.ThrottleSetting, bool_0: true);
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
				num6 = (double)Math.Abs(MathFunctions.DeleteRequest((float)num5, myUnit.CurrentHeading)) * (double)(1f / float_0);
				CalcTurnDeceleration(num6, float_0);
				flag4 = false;
				if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation && myUnit.Navigator.HasFlightPlan && (!myUnit.IsGroupWingman() || myUnit.GetParentGroup() == null || myUnit.GetParentGroup().GroupLead == null || (int)Math.Round(myUnit.CurrentSpeed) == (int)Math.Round(myUnit.GetParentGroup().GroupLead.CurrentSpeed)) && (int)Math.Round(num5) != (int)Math.Round(myUnit.CurrentHeading))
				{
					if (myUnit.Navigator.PreviousWaypointType.HasValue)
					{
						int? num7 = (int?)myUnit.Navigator.PreviousWaypointType;
						if (!(num7.HasValue ? new bool?(num7.GetValueOrDefault() != 15) : null).GetValueOrDefault())
						{
							goto IL_0b89;
						}
					}
					flag4 = true;
				}
				goto IL_0b89;
			}
			goto IL_09a5;
			IL_0b89:
			if (!flag4 && myUnit.CurrentSpeed != myUnit.DesiredSpeed)
			{
				GoToDesiredSpeed(float_0, (float)num6);
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
			goto IL_09a5;
			IL_09a5:
			if (GetAircraft().Loadout != null)
			{
				WeaponRec[] weapons = GetAircraft().Loadout.Weapons;
				for (int i = 0; i < weapons.Length; i = checked(i + 1))
				{
					Weapon referenceWeapon = weapons[i].GetReferenceWeapon(GetAircraft().ParentScen);
					referenceWeapon.SetLongitude(null, GetAircraft().GetLongitude());
					referenceWeapon.SetLatitude(null, GetAircraft().GetLatitude());
					referenceWeapon.SetCurrentAltitude(bool_0: false, GetAircraft().GetCurrentAltitude());
					referenceWeapon.CurrentHeading = GetAircraft().CurrentHeading;
					referenceWeapon.CurrentSpeed = GetAircraft().CurrentSpeed;
				}
			}
			if (myUnit.CommStuff.IsConnectedToSideNetwork)
			{
				myUnit.Longitude_LastReported = myUnit.GetLongitude();
				myUnit.Latitude_LastReported = myUnit.GetLatitude();
				return;
			}
			if (!myUnit.Longitude_LastReported.HasValue)
			{
				myUnit.Longitude_LastReported = myUnit.GetLongitude();
			}
			if (!myUnit.Latitude_LastReported.HasValue)
			{
				myUnit.Latitude_LastReported = myUnit.GetLatitude();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100455", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override float HorizMovementDistanceOnThisTime(float float_0)
	{
		if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation)
		{
			return myUnit.CurrentSpeed / 3600f * float_0;
		}
		return Module_Unit.CalcTokenizer(myUnit) / 3600f * float_0;
	}

	public override void ChangeAltitude(float float_0, float float_1, float? nullable_0, bool bool_0)
	{
		try
		{
			myUnit.Altitude_old = myUnit.GetCurrentAltitude();
			float currentAltitude = myUnit.GetCurrentAltitude();
			bool desiredAltitude_UseTerrainFollowing;
			if (!(desiredAltitude_UseTerrainFollowing = myUnit.GetDesiredAltitude_UseTerrainFollowing(myUnit)) && myUnit.IsGroupWingman() && !Information.IsNothing(myUnit.GetParentGroup().GroupLead))
			{
				desiredAltitude_UseTerrainFollowing = myUnit.GetParentGroup().GroupLead.GetDesiredAltitude_UseTerrainFollowing(myUnit.GetParentGroup().GroupLead);
			}
			((Aircraft)myUnit).Kinematics.CheckForSinkingCondition(float_0);
			((Aircraft)myUnit).AI.VisitFacade(null, float_0, float_1);
			float attitude_Pitch = GetAircraft().Attitude_Pitch;
			float num = ClimbRate_Actual(attitude_Pitch) * float_0;
			float num2 = DiveRate_Actual(attitude_Pitch) * float_0;
			if ((num > 0f) & (float_1 > myUnit.GetCurrentAltitude()))
			{
				if (nullable_0.HasValue && (nullable_0.HasValue ? new bool?(float_1 < nullable_0.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					float_1 = nullable_0.Value;
				}
				if (myUnit.SupportsAttitude_Pitch)
				{
					if (float_1 - myUnit.GetCurrentAltitude() <= num && myUnit.GetCurrentAltitude() - float_1 <= num2 && myUnit.Attitude_Pitch < 3f && myUnit.Attitude_Pitch > 0f)
					{
						currentAltitude = float_1;
						myUnit.Attitude_Pitch = 0f;
					}
					else
					{
						currentAltitude = myUnit.GetCurrentAltitude() + num;
					}
				}
				else
				{
					currentAltitude = ((float_1 - myUnit.GetCurrentAltitude() <= num) ? float_1 : (myUnit.GetCurrentAltitude() + num));
				}
				myUnit.SetCurrentAltitude(bool_0, currentAltitude);
			}
			else if ((num2 > 0f) & (float_1 < myUnit.GetCurrentAltitude()))
			{
				if (!GetAircraft().HasLostControlPulse_CACHED && nullable_0.HasValue && (nullable_0.HasValue ? new bool?(float_1 < nullable_0.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					float_1 = nullable_0.Value;
				}
				if (myUnit.SupportsAttitude_Pitch)
				{
					if (myUnit.GetCurrentAltitude() - float_1 <= num2 && float_1 - myUnit.GetCurrentAltitude() <= num && myUnit.Attitude_Pitch > -3f && myUnit.Attitude_Pitch < 0f)
					{
						currentAltitude = float_1;
						myUnit.Attitude_Pitch = 0f;
					}
					else
					{
						currentAltitude = myUnit.GetCurrentAltitude() - num2;
					}
				}
				else
				{
					currentAltitude = ((myUnit.GetCurrentAltitude() - float_1 <= num2) ? float_1 : (myUnit.GetCurrentAltitude() - num2));
				}
				if (!GetAircraft().HasLostControlPulse_CACHED && nullable_0.HasValue && (nullable_0.HasValue ? new bool?(currentAltitude <= nullable_0.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					myUnit.Attitude_Pitch = 0f;
				}
				myUnit.SetCurrentAltitude(bool_0, currentAltitude);
			}
			else if (myUnit.SupportsAttitude_Pitch)
			{
				if (desiredAltitude_UseTerrainFollowing)
				{
					if (myUnit.GetCurrentAltitude() - myUnit.DesiredAltitude_AGL + (float)Terrain.GetElevation(myUnit.GetLatitude(), myUnit.GetLongitude(), bool_0: false, myUnit.ParentScen) == 0f)
					{
						myUnit.DesiredPitch = 0f;
					}
				}
				else if (myUnit.GetCurrentAltitude() - myUnit.DesiredAltitude == 0f)
				{
					myUnit.DesiredPitch = 0f;
				}
				if (!GetAircraft().HasLostControlPulse_CACHED && nullable_0.HasValue)
				{
					float currentAltitude2 = myUnit.GetCurrentAltitude();
					if ((nullable_0.HasValue ? new bool?(currentAltitude2 <= nullable_0.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						myUnit.Attitude_Pitch = 0f;
						myUnit.SetCurrentAltitude(bool_0, nullable_0.Value);
						goto IL_0594;
					}
				}
				if (myUnit.Attitude_Pitch <= 0f)
				{
					if (myUnit.Attitude_Pitch < 0f)
					{
						currentAltitude = myUnit.GetCurrentAltitude() - num2;
						myUnit.SetCurrentAltitude(bool_0, currentAltitude);
					}
				}
				else
				{
					currentAltitude = myUnit.GetCurrentAltitude() + num;
					myUnit.SetCurrentAltitude(bool_0, currentAltitude);
				}
			}
			goto IL_0594;
			IL_0594:
			float maximumAltitude = GetMaximumAltitude();
			if (myUnit.GetCurrentAltitude() > maximumAltitude)
			{
				myUnit.DesiredPitch = -45f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100196", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	public float GetActualAgility(StringBuilder stringBuilder_0 = null)
	{
		stringBuilder_0?.Append(GetAircraft().Name).Append("具有名义敏捷性：").Append(GetAircraft().Agility_Nominal)
			.Append(", ");
		float num = (float)Math.Round(GetAircraft().Kinematics.SortProxy(GetAircraft().Agility_Nominal), 1);
		stringBuilder_0?.Append("调整高度：").Append(num).Append(". ");
		GlobalVariables.ProficiencyLevel? proficiency = GetAircraft().Proficiency;
		int? num2 = (int?)proficiency;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
		{
			num = (float)((double)num * 0.3);
		}
		else
		{
			num2 = (int?)proficiency;
			if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				num = (float)((double)num * 0.5);
			}
			else
			{
				num2 = (int?)proficiency;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					num = (float)((double)num * 0.8);
				}
				else
				{
					num2 = (int?)proficiency;
					if (!(num2.HasValue ? new bool?(num2.GetValueOrDefault() == 3) : null).GetValueOrDefault())
					{
						num2 = (int?)proficiency;
						if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 4) : null).GetValueOrDefault())
						{
							num = (float)((double)num * 1.2);
						}
					}
				}
			}
		}
		stringBuilder_0?.Append("敏捷度调整为熟练程度（" + Misc.TestRequest(GetAircraft().Proficiency.Value) + "): " + Conversions.ToString(num) + ". ");
		float weightFraction = GetAircraft().WeightFraction;
		num = (float)(0.4 * (double)num + 0.6 * (double)num * (double)(1f - weightFraction));
		stringBuilder_0?.Append("飞机的重量权重为" + Conversions.ToString(Math.Round(weightFraction, 2)) + " - 敏捷度调整为" + Conversions.ToString(Math.Round(num, 2)) + ". ");
		if (GetAircraft().Damage.DamagePercent > 0f)
		{
			num = num * (100f - GetAircraft().Damage.DamagePercent) / 100f;
			stringBuilder_0?.Append("飞机有" + Conversions.ToString(GetAircraft().Damage.DamagePercent) + "%机身受损，灵敏度调整到" + Conversions.ToString(Math.Round(num, 2)) + ". ");
		}
		if (num == 0f)
		{
			num = 0.01f;
		}
		return num;
	}

	public override float Acceleration_Nominal(ActiveUnit.Throttle throttle_0, float float_0)
	{
		float num = (float)((double)GetAircraft().Agility_Nominal * 0.05 * (double)GetMaximumSpeed(float_0, throttle_0, bool_0: false));
		switch (myUnit.Propulsion[0].Type)
		{
		case Engine.EngineType.Turbojet:
		case Engine.EngineType.Turbofan:
			num = (float)(1.2 * (double)num);
			break;
		case Engine.EngineType.Turboprop:
		case Engine.EngineType.Turboshaft:
			num = (float)(0.8 * (double)num);
			break;
		}
		return num;
	}

	public override float PitchRate_Negative()
	{
		return GetActualAgility() * 2f;
	}

	public override float PitchRate_Positive()
	{
		return GetActualAgility() * 4f;
	}

	public override int GetMaximumSpeed(float float_0, ActiveUnit.Throttle throttle_0, bool bool_0, bool bool_1 = true)
	{
		if (float.IsNaN(float_0))
		{
			return 0;
		}
		AltBand altBand = null;
		AltBand altBand2 = null;
		Engine engine = null;
		try
		{
			if (throttle_0 == ActiveUnit.Throttle.FullStop)
			{
				return 0;
			}
			if (myUnit.Propulsion.Count == 0)
			{
				return 0;
			}
			altBand = GetCurrentAltBand_CurrentAltitude(float_0, null, bool_0: false);
			if (altBand == null)
			{
				return 0;
			}
			foreach (Engine item in myUnit.Propulsion)
			{
				if (item.Status == PlatformComponent._ComponentStatus.Operational)
				{
					engine = item;
					break;
				}
			}
			if (Information.IsNothing(engine))
			{
				return 0;
			}
			AltBand[] altBands = engine.AltBands;
			if (altBands.Length == 0)
			{
				return 0;
			}
			float num = 0f;
			switch (throttle_0)
			{
			case ActiveUnit.Throttle.FullStop:
				num = 0f;
				break;
			case ActiveUnit.Throttle.Loiter:
				num = altBand.Speed_Loiter;
				break;
			case ActiveUnit.Throttle.Cruise:
				num = ((altBand.Speed_Cruise <= 0) ? ((float)altBand.Speed_Loiter) : ((float)altBand.Speed_Cruise));
				break;
			case ActiveUnit.Throttle.Full:
				num = (altBand.Speed_Full.HasValue ? ((float)altBand.Speed_Full.Value) : ((float)altBand.Speed_Cruise));
				break;
			case ActiveUnit.Throttle.Flank:
				num = (altBand.Speed_Flank.HasValue ? ((float)altBand.Speed_Flank.Value) : (altBand.Speed_Full.HasValue ? ((float)altBand.Speed_Full.Value) : ((float)altBand.Speed_Cruise)));
				break;
			}
			int num2 = (int)Math.Round(num);
			if (altBand != HighestAltBand(engine))
			{
				List<AltBand> list = new List<AltBand>();
				AltBand[] array = altBands;
				AltBand[] array2 = array;
				foreach (AltBand altBand3 in array2)
				{
					if (altBand3 != null && altBand3.MinAlt >= altBand.MaxAlt)
					{
						list.Add(altBand3);
					}
				}
				if (list.Count > 1)
				{
					list.Sort(new AltBandComparer_SortyByMaxAltAscending());
				}
				if (list.Count > 0)
				{
					altBand2 = list[0];
				}
				if (altBand2 != null)
				{
					float num3 = 0f;
					switch (throttle_0)
					{
					case ActiveUnit.Throttle.FullStop:
						num3 = 0f;
						break;
					case ActiveUnit.Throttle.Loiter:
						num3 = altBand2.Speed_Loiter;
						break;
					case ActiveUnit.Throttle.Cruise:
						num3 = altBand2.Speed_Cruise;
						break;
					case ActiveUnit.Throttle.Full:
						num3 = (altBand2.Speed_Full.HasValue ? ((float)altBand2.Speed_Full.Value) : ((float)altBand2.Speed_Cruise));
						break;
					case ActiveUnit.Throttle.Flank:
						num3 = (altBand2.Speed_Flank.HasValue ? ((float)altBand2.Speed_Flank.Value) : (altBand2.Speed_Full.HasValue ? ((float)altBand2.Speed_Full.Value) : ((float)altBand2.Speed_Cruise)));
						break;
					}
					num2 = (int)Math.Round(num3 + (float_0 - altBand2.MinAlt) * (num - num3) / (altBand.MinAlt - altBand2.MinAlt));
				}
			}
			if (bool_1)
			{
				int num4 = 0;
				foreach (Engine item2 in GetAircraft().Propulsion)
				{
					if (item2.Status == PlatformComponent._ComponentStatus.Operational)
					{
						num4++;
					}
				}
				double num5 = (double)num4 / (double)GetAircraft().Propulsion.Count;
				if (num5 < 1.0)
				{
					num2 = (int)Math.Round((double)num2 * Math.Sqrt(num5));
				}
			}
			return (int)Math.Round(ActiveUnit_Kinematics.RoundAircraftSpeed(num2));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101340", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	public override float RollRate()
	{
		float actualAgility = GetActualAgility();
		if (actualAgility <= 4f)
		{
			if (actualAgility <= 3f)
			{
				if (actualAgility <= 2f)
				{
					if (actualAgility <= 1f)
					{
						return 20f;
					}
					return 45f;
				}
				return 90f;
			}
			return 180f;
		}
		return 270f;
	}

	public override float Acceleration_Actual(ActiveUnit.Throttle throttle_0, float float_0, float float_1)
	{
		try
		{
			float num = Acceleration_Nominal(throttle_0, float_0);
			float num2 = Math.Min(1f, float_1 / (float)GetMaximumSpeed(float_0, throttle_0, bool_0: false));
			float num3 = (float)((double)num * Math.Pow(1f - num2, 2.0));
			float num4 = float_0 / myUnit.Kinematics.GetMaximumAltitude();
			switch (myUnit.Propulsion[0].Type)
			{
			case Engine.EngineType.Turbofan:
				num3 = (float)((double)num3 * (1.5 - (double)(num4 / 2f)));
				break;
			case Engine.EngineType.Turbojet:
				num3 *= 1f + num4 / 2f;
				break;
			}
			double num5 = (double)GetAircraft().Propulsion.Where((Engine theE) => theE.Status == PlatformComponent._ComponentStatus.Operational).Count() / (double)GetAircraft().Propulsion.Count;
			num3 = (float)((double)num3 * num5 * num5);
			return (float)(0.75 * (double)num3 + 0.25 * (double)num3 * (double)(1f - GetAircraft().WeightFraction));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100456", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			float result = Acceleration_Nominal(throttle_0, float_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override void CalcTurnDeceleration(double double_0, float float_0)
	{
		try
		{
			if (myUnit.DesiredTurnRate != ActiveUnit.TurnRate.Navigation && (long)Math.Round(Math.Abs(myUnit.CurrentHeading - myUnit.DesiredHeading)) > 5)
			{
				float num = (float)(0.6 * double_0 * Math.Pow(Physics.CompareStub(myUnit.GetCurrentAltitude(), myUnit.CurrentSpeed), 3.0));
				myUnit.CurrentSpeed -= num;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100457", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public float Estimate_Gs()
	{
		if (GetAircraft().Attitude_Roll > 0f && MathFunctions.DeleteRequest(GetAircraft().CurrentHeading, GetAircraft().DesiredHeading) < 0f)
		{
			return 0f;
		}
		if (GetAircraft().Attitude_Roll < 0f && MathFunctions.DeleteRequest(GetAircraft().CurrentHeading, GetAircraft().DesiredHeading) > 0f)
		{
			return 0f;
		}
		float attitude_Roll = GetAircraft().Attitude_Roll;
		if (attitude_Roll < 83.6f)
		{
			if (attitude_Roll < 82.8f)
			{
				if (attitude_Roll < 81.8f)
				{
					if (attitude_Roll < 80.4f)
					{
						if (attitude_Roll < 78.5f)
						{
							if (attitude_Roll < 75.5f)
							{
								if (attitude_Roll < 70.6f)
								{
									if (attitude_Roll < 60f)
									{
										return GetAircraft().Agility_Nominal / 5f;
									}
									return 2f * (GetAircraft().Agility_Nominal / 5f);
								}
								return 3f * (GetAircraft().Agility_Nominal / 5f);
							}
							return 4f * (GetAircraft().Agility_Nominal / 5f);
						}
						return 5f * (GetAircraft().Agility_Nominal / 5f);
					}
					return 6f * (GetAircraft().Agility_Nominal / 5f);
				}
				return 7f * (GetAircraft().Agility_Nominal / 5f);
			}
			return 8f * (GetAircraft().Agility_Nominal / 5f);
		}
		return 9f * (GetAircraft().Agility_Nominal / 5f);
	}

	public override void TurnToDesiredHeading(float float_0)
	{
		try
		{
			double num2;
			if (IsInCombatManouvers)
			{
				GetAircraft().G_StrainAccumulated = Math.Max(0f, GetAircraft().G_StrainAccumulated - 3f * float_0);
				switch (_FilterObserver)
				{
				case G_Straining_Mode.Recovering:
					if ((double)GetAircraft().G_StrainAccumulated < (double)GetAircraft().G_Tolerance * 0.25)
					{
						_FilterObserver = G_Straining_Mode.StrainingToLimit;
					}
					break;
				case G_Straining_Mode.StrainingToLimit:
				{
					float num = Estimate_Gs();
					GetAircraft().G_StrainAccumulated += num * float_0;
					if (GetAircraft().G_StrainAccumulated >= GetAircraft().G_Tolerance)
					{
						_FilterObserver = G_Straining_Mode.Recovering;
					}
					break;
				}
				}
				if ((GetAircraft().Attitude_Roll > 0f && MathFunctions.DeleteRequest(GetAircraft().CurrentHeading, GetAircraft().DesiredHeading) < 0f) || (GetAircraft().Attitude_Roll < 0f && MathFunctions.DeleteRequest(GetAircraft().CurrentHeading, GetAircraft().DesiredHeading) > 0f))
				{
					return;
				}
				num2 = Math.Abs(GetAircraft().Attitude_Roll) / 89f * TurnRate() * float_0;
			}
			else
			{
				num2 = (Information.IsNothing(myUnit.Navigator.GetFlight()) ? ((double)(TurnRate() * float_0)) : ((double)(ActiveUnit_Kinematics.TurnRateCategoryToActualTurnRate(myUnit.DesiredTurnRate_Navigation, myUnit.CurrentSpeed) * float_0)));
				GetAircraft().G_StrainAccumulated = Math.Max(0f, GetAircraft().G_StrainAccumulated - 3f * float_0);
			}
			ActiveUnit activeUnit = (myUnit.Navigator.HasPlottedCourse() ? myUnit : ((!myUnit.IsGroupWingman() || Information.IsNothing(myUnit.GetParentGroup().GroupLead) || !myUnit.GetParentGroup().GroupLead.Navigator.HasPlottedCourse()) ? myUnit : myUnit.GetParentGroup().GroupLead));
			bool? flag2;
			bool? flag;
			if (activeUnit.Navigator.HasPlottedCourse() && activeUnit.Status == ActiveUnit._ActiveUnitStatus.OnPlottedCourse)
			{
				Waypoint waypoint = activeUnit.Navigator.PlottedCourse.FirstOrDefault();
				flag = ((waypoint == null) ? null : new bool?(waypoint.Type == Waypoint.WaypointType.StationEnd));
				int? num3;
				if (flag.GetValueOrDefault(true))
				{
					num3 = (int?)activeUnit.Navigator.PreviousWaypointType;
					if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 21) : null).GetValueOrDefault() && flag.HasValue)
					{
						myUnit.CurrentHeading = (float)Math2.DisableClass((double)myUnit.CurrentHeading + num2);
						if (Math.Abs(MathFunctions.DeleteRequest(myUnit.CurrentHeading, myUnit.DesiredHeading)) < 90f && IsRightOfDesired(myUnit.CurrentHeading, myUnit.DesiredHeading))
						{
							myUnit.CurrentHeading = myUnit.DesiredHeading;
						}
						return;
					}
				}
				num3 = (int?)activeUnit.Navigator.PreviousWaypointType;
				bool? flag3 = (flag2 = (num3.HasValue ? new bool?(num3.GetValueOrDefault() == 24) : null));
				flag = ((flag3.HasValue && !flag2.GetValueOrDefault()) ? new bool?(false) : (activeUnit.Navigator.HasPlottedCourse() & flag2));
				if (flag.GetValueOrDefault(true))
				{
					Waypoint waypoint2 = activeUnit.Navigator.PlottedCourse.FirstOrDefault();
					if (waypoint2 != null && waypoint2.Type == Waypoint.WaypointType.StationStart_FigureEight && flag.HasValue)
					{
						myUnit.CurrentHeading = (float)Math2.DisableClass((double)myUnit.CurrentHeading - num2);
						if (Math.Abs(MathFunctions.DeleteRequest(myUnit.CurrentHeading, myUnit.DesiredHeading)) < 90f && IsLeftOfDesired(myUnit.CurrentHeading, myUnit.DesiredHeading))
						{
							myUnit.CurrentHeading = myUnit.DesiredHeading;
						}
						return;
					}
				}
				if (activeUnit.Navigator.HasPlottedCourse())
				{
					Waypoint waypoint3 = activeUnit.Navigator.PlottedCourse.FirstOrDefault();
					flag = ((waypoint3 == null) ? null : new bool?(waypoint3.Type == Waypoint.WaypointType.StationEnd));
					if (flag.GetValueOrDefault(true))
					{
						num3 = (int?)activeUnit.Navigator.PreviousWaypointType;
						if (!(num3.HasValue ? new bool?(num3.GetValueOrDefault() == 20) : null).GetValueOrDefault())
						{
							num3 = (int?)activeUnit.Navigator.PreviousWaypointType;
							if (!(num3.HasValue ? new bool?(num3.GetValueOrDefault() == 23) : null).GetValueOrDefault())
							{
								goto IL_07cc;
							}
						}
						if (flag.HasValue)
						{
							goto IL_0666;
						}
					}
				}
				goto IL_07cc;
			}
			goto IL_06bc;
			IL_06bc:
			if (num2 > 179.0)
			{
				num2 = 179.0;
			}
			switch (Misc.CountValue(myUnit.CurrentHeading, myUnit.DesiredHeading))
			{
			case Misc.TurnDirection.TurnRight:
				myUnit.CurrentHeading = (float)Math2.DisableClass((double)myUnit.CurrentHeading + num2);
				if (IsRightOfDesired(myUnit.CurrentHeading, myUnit.DesiredHeading))
				{
					myUnit.CurrentHeading = myUnit.DesiredHeading;
				}
				break;
			case Misc.TurnDirection.TurnLeft:
				myUnit.CurrentHeading = (float)Math2.DisableClass((double)myUnit.CurrentHeading - num2);
				if (IsLeftOfDesired(myUnit.CurrentHeading, myUnit.DesiredHeading))
				{
					myUnit.CurrentHeading = myUnit.DesiredHeading;
				}
				break;
			}
			return;
			IL_07cc:
			Waypoint waypoint4 = activeUnit.Navigator.PlottedCourse.FirstOrDefault();
			bool? flag4 = (flag2 = ((waypoint4 == null) ? null : new bool?(waypoint4.Type == Waypoint.WaypointType.StationStart_Racetrack)));
			bool? flag5;
			if (flag4.HasValue && flag2.GetValueOrDefault())
			{
				flag5 = true;
			}
			else
			{
				Waypoint waypoint5 = activeUnit.Navigator.PlottedCourse.FirstOrDefault();
				bool? flag6;
				flag4 = (flag6 = ((waypoint5 == null) ? null : new bool?(waypoint5.Type == Waypoint.WaypointType.StationStart_Racetrack)));
				flag5 = ((!flag4.HasValue) ? null : (flag6.GetValueOrDefault() | flag2));
			}
			flag = flag5;
			if (flag.GetValueOrDefault(true))
			{
				int? num4 = (int?)activeUnit.Navigator.PreviousWaypointType;
				if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 24) : null).GetValueOrDefault() && flag.HasValue)
				{
					goto IL_0666;
				}
			}
			Waypoint waypoint6 = activeUnit.Navigator.PlottedCourse.FirstOrDefault();
			if (waypoint6 != null && waypoint6.Type == Waypoint.WaypointType.HoldEnd && Math.Abs(MathFunctions.DeleteRequest(myUnit.CurrentHeading, myUnit.DesiredHeading)) > 90f)
			{
				myUnit.CurrentHeading = (float)Math2.DisableClass((double)myUnit.CurrentHeading + num2);
				return;
			}
			goto IL_06bc;
			IL_0666:
			if (Math.Abs(MathFunctions.DeleteRequest(myUnit.CurrentHeading, myUnit.DesiredHeading)) > 90f)
			{
				myUnit.CurrentHeading = (float)Math2.DisableClass((double)myUnit.CurrentHeading + num2);
				return;
			}
			goto IL_06bc;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100456464561", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public ActiveUnit.Throttle ThrottleForCornerVelocity()
	{
		return GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), CornerVelocity);
	}

	private float SortProxy(float float_0)
	{
		if (GetAircraft().GetCurrentAltitude() <= 3000f)
		{
			return float_0;
		}
		float num = 0.5f;
		if (GetAircraft().SuperManouverable)
		{
			num = 0.25f;
		}
		float num2 = GetMaximumAltitude() - GetAircraft().GetCurrentAltitude();
		float num3 = GetAircraft().GetCurrentAltitude() - 3000f;
		float num4 = float_0 * num * (num3 / num2);
		return (float)(double)Math.Max(float_0 * (1f - num), float_0 - num4);
	}

	public override float TurnRate()
	{
		try
		{
			switch (GetAircraft().Category)
			{
			case Aircraft._AircraftCategory.AirShip:
				_TestsObserver = 1f;
				break;
			default:
			{
				if (Math.Abs(m_InterpreterObserver - myUnit.CurrentSpeed) <= 30f)
				{
					if (_TestsObserver < 3f)
					{
						_TestsObserver = 3f;
					}
					break;
				}
				float num = GetAircraft().Agility_Nominal * 4f;
				float num2 = myUnit.Kinematics.GetMaximumSpeed(myUnit.GetCurrentAltitude(), myUnit.MaxPossibleThrottleSetting, bool_0: false);
				float num3 = ((myUnit.CurrentSpeed <= (float)CornerVelocity) ? (num * (myUnit.CurrentSpeed / (float)CornerVelocity)) : (((double)Physics.CompareStub(myUnit.GetCurrentAltitude(), myUnit.CurrentSpeed) <= 1.0) ? Math.Max(num * (1f - (myUnit.CurrentSpeed - (float)CornerVelocity) / (num2 - (float)CornerVelocity)), 3f) : (GetAircraft().SuperManouverable ? ((float)((double)num - 0.25 * (double)num * (double)(myUnit.CurrentSpeed - (float)CornerVelocity) / (double)(num2 - (float)CornerVelocity))) : ((float)((double)num - 0.5 * (double)num * (double)(myUnit.CurrentSpeed - (float)CornerVelocity) / (double)(num2 - (float)CornerVelocity))))));
				GlobalVariables.ProficiencyLevel? proficiency = myUnit.Proficiency;
				int? num4 = (int?)proficiency;
				if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					num3 = (float)((double)num3 * 0.4);
				}
				else
				{
					num4 = (int?)proficiency;
					if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						num3 = (float)((double)num3 * 0.6);
					}
					else
					{
						num4 = (int?)proficiency;
						if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 2) : null).GetValueOrDefault())
						{
							num3 = (float)((double)num3 * 0.8);
						}
						else
						{
							num4 = (int?)proficiency;
							if (!(num4.HasValue ? new bool?(num4.GetValueOrDefault() == 3) : null).GetValueOrDefault())
							{
								num4 = (int?)proficiency;
								if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 4) : null).GetValueOrDefault())
								{
									num3 = (float)((double)num3 * 1.2);
								}
							}
						}
					}
				}
				num3 = Math.Max(num3, 3f);
				m_InterpreterObserver = myUnit.CurrentSpeed;
				_TestsObserver = num3;
				break;
			}
			case Aircraft._AircraftCategory.Helicopter:
			case Aircraft._AircraftCategory.Tiltrotor:
				_TestsObserver = 45f;
				break;
			}
			return _TestsObserver;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100458", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 3f;
		}
	}

	public override float ClimbRate_Actual(float float_0)
	{
		if (myUnit.SupportsAttitude_Pitch)
		{
			if (float_0 <= 0f)
			{
				return 0f;
			}
			return (float)Math.Min(GetClimbRate_Nominal(), (double)myUnit.CurrentSpeed * 0.514444 * (double)(float_0 / (float)MaxPositivePitchAngle));
		}
		return GetClimbRate_Nominal();
	}

	[SpecialName]
	public override float GetClimbRate_Nominal(bool bool_0 = true)
	{
		poolObserver = (float)(0.4 * (double)_ClimbRate + 0.6 * (double)_ClimbRate * (double)(1f - GetAircraft().WeightFraction));
		double num = (double)GetAircraft().Propulsion.Where((Engine theE) => theE.Status == PlatformComponent._ComponentStatus.Operational).Count() / (double)GetAircraft().Propulsion.Count;
		poolObserver = (float)((double)poolObserver * num);
		if (bool_0 && !GetAircraft().GetCanHover(bool_1: true) && (double)poolObserver > (double)GetAircraft().CurrentSpeed * 0.514444)
		{
			poolObserver = (float)((double)GetAircraft().CurrentSpeed * 0.514444);
		}
		if (float.IsNaN(poolObserver))
		{
			return 0f;
		}
		return poolObserver;
	}

	[SpecialName]
	public override void SetClimbRate_Nominal(bool bool_0, float float_0)
	{
		base.SetClimbRate_Nominal(bool_0: true, float_0);
	}

	public override float DiveRate_Nominal()
	{
		float num = (float)(0.4 * (double)base.DiveRate_Nominal() + 0.6 * (double)base.DiveRate_Nominal() * (double)(1f + GetAircraft().WeightFraction));
		if (!GetAircraft().GetCanHover(bool_1: true) && (double)num > (double)GetAircraft().CurrentSpeed * 0.514444)
		{
			num = (float)((double)GetAircraft().CurrentSpeed * 0.514444);
		}
		return num;
	}
}
