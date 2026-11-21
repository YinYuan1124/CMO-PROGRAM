using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Submarine_Kinematics : ActiveUnit_Kinematics
{
	[CompilerGenerated]
	private sealed class InfoItem
	{
		public float Local_DesiredSpeed;

		internal bool DestroyInterruptibleParam(AltBand theB)
		{
			return (float)theB.Speed_Cruise >= Local_DesiredSpeed;
		}

		internal bool ComputeInterruptibleParam(AltBand theB)
		{
			float? num = theB.Speed_Flank;
			return (num.HasValue ? new bool?(num.GetValueOrDefault() >= Local_DesiredSpeed) : null).GetValueOrDefault();
		}

		internal bool PatchInterruptibleParam(AltBand theB)
		{
			float? num = theB.Speed_Full;
			return (num.HasValue ? new bool?(num.GetValueOrDefault() >= Local_DesiredSpeed) : null).GetValueOrDefault();
		}

		internal bool SelectInterruptibleParam(AltBand theB0)
		{
			return (float)theB0.Speed_Loiter >= Local_DesiredSpeed;
		}
	}

	private Submarine tokenProxy;

	public Submarine_Kinematics(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}

	[SpecialName]
	private Submarine GetParentPlatform()
	{
		if (tokenProxy == null)
		{
			tokenProxy = (Submarine)myUnit;
		}
		return tokenProxy;
	}

	public override float PitchRate_Negative()
	{
		return 1f;
	}

	public override float PitchRate_Positive()
	{
		return 1f;
	}

	public override float CurrentRangeAtBingoThrottleAltitudeDepth(Doctrine._FuelState? nullable_0)
	{
		float float_ = Math.Max(-20f, GetMinimumAltitude());
		return (float)((double)(float)RemainingEndurance(ActiveUnit.Throttle.Cruise, float_, bool_0: true) * ((double)GetMaximumSpeed(float_, ActiveUnit.Throttle.Cruise, bool_0: false) / 3600.0));
	}

	public override long RemainingEndurance(ActiveUnit.Throttle throttle_0, float float_0, bool bool_0)
	{
		long result = 0L;
		try
		{
			if (!((Submarine)myUnit).IsNuke && (!((Submarine)myUnit).IsTetheredROV || myUnit.Fuel_ReadOnly.Count != 0))
			{
				FuelRec fuelRec = ((myUnit.Fuel_ReadOnly.Count == 1) ? myUnit.Fuel_ReadOnly[0] : ((Math.Round(float_0) < -20.0) ? (from theFuelrec in myUnit.Fuel_ReadOnly
					select (theFuelrec) into fuelRec_0
					where myUnit.Propulsion[0].CanUseThisFuelType(FuelRec._FuelType.Battery)
					select fuelRec_0).ElementAtOrDefault(0) : (from theFuelrec in myUnit.Fuel_ReadOnly
					select (theFuelrec) into fuelRec_0
					where myUnit.Propulsion[0].CanUseThisFuelType(FuelRec._FuelType.DieselFuel)
					select fuelRec_0).ElementAtOrDefault(0)));
				if (Information.IsNothing(fuelRec))
				{
					result = 0L;
					return 0L;
				}
				result = (long)Math.Round((double)fuelRec.CurrentQuantity / (double)myUnit.FuelConsumption(throttle_0, null, null, null, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false));
				return result;
			}
			result = long.MaxValue;
			return long.MaxValue;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100833", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override long RemainingEndurance(float float_0, float float_1, bool bool_0, bool bool_1)
	{
		if (((Submarine)myUnit).IsBiological)
		{
			return long.MaxValue;
		}
		long result = 0L;
		try
		{
			if (!((Submarine)myUnit).IsNuke && (!((Submarine)myUnit).IsTetheredROV || myUnit.Fuel_ReadOnly.Count != 0))
			{
				if (float_0 == 0f)
				{
					result = long.MaxValue;
					return long.MaxValue;
				}
				float num = 0f;
				foreach (FuelRec item in myUnit.Fuel_ReadOnly)
				{
					num += item.CurrentQuantity;
				}
				if (!bool_0)
				{
					num -= myUnit.Kinematics.ReserveFuel;
				}
				float num2 = myUnit.FuelConsumption(GetThrottleSuitableForThisSpeed(float_1, (int)Math.Round(float_0)), null, (int)Math.Round(float_0), float_1, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false);
				if (num2 == 0f)
				{
					result = long.MaxValue;
					return long.MaxValue;
				}
				result = (long)Math.Round(num / num2);
				return result;
			}
			result = long.MaxValue;
			return long.MaxValue;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100185", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override float RollRate()
	{
		int emptyWeight = myUnit.EmptyWeight;
		if (emptyWeight < 350)
		{
			return 4f;
		}
		if (emptyWeight < 3500)
		{
			return 3f;
		}
		if (emptyWeight < 8100)
		{
			return 2f;
		}
		if (emptyWeight < 15000)
		{
			return 1f;
		}
		return 0.5f;
	}

	public override void CalcTurnDeceleration(double double_0, float float_0)
	{
		if (myUnit.DesiredTurnRate != ActiveUnit.TurnRate.Navigation && (int)Math.Round(Math.Abs(myUnit.CurrentHeading - myUnit.DesiredHeading)) > 5)
		{
			float num = 0f;
			if (double_0 > 25.0)
			{
				num = (float)(0.25 * (double)float_0);
			}
			if (double_0 > 45.0)
			{
				num = 1f * float_0;
			}
			myUnit.CurrentSpeed -= num;
		}
	}

	public override int GetMaximumSpeed(float float_0, ActiveUnit.Throttle throttle_0, bool bool_0, bool bool_1 = true)
	{
		if (((Submarine)myUnit).GetFuelEndurance(throttle_0, null, null, null, ((Submarine)myUnit).PrimaryEngine, ((Submarine)myUnit).PrimaryEngineNo) == 0)
		{
			return 0;
		}
		return base.GetMaximumSpeed(float_0, throttle_0, bool_0);
	}

	public int GetMaximumSpeed(float float_0, ActiveUnit.Throttle throttle_0, Engine engine_0, int int_0, bool bool_0)
	{
		if (((Submarine)myUnit).GetFuelEndurance(throttle_0, null, null, null, engine_0, int_0) == 0)
		{
			return 0;
		}
		return base.GetMaximumSpeed(float_0, throttle_0, bool_0);
	}

	public override float MaxRange(bool bool_0, float? nullable_0, float? nullable_1)
	{
		return float.MaxValue;
	}

	public override void ChangeAltitude(float float_0, float float_1, float? nullable_0, bool bool_0)
	{
		try
		{
			myUnit.Altitude_old = myUnit.GetCurrentAltitude();
			float num = myUnit.GetCurrentAltitude();
			double num2 = (myUnit.GetCurrentAltitude() - myUnit.Altitude_old) / float_0;
			float attitude_Pitch = myUnit.Attitude_Pitch;
			float num3 = ClimbRate_Actual(attitude_Pitch) * float_0;
			float num4 = DiveRate_Actual(attitude_Pitch) * float_0;
			if (Math.Abs(float_1 - myUnit.GetCurrentAltitude()) < 1f)
			{
				myUnit.SetCurrentAltitude(bool_0, float_1);
				myUnit.DesiredPitch = 0f;
			}
			else if (myUnit.GetCurrentAltitude() < float_1)
			{
				if (num2 < 0.0)
				{
					num3 = (float)((double)num3 - num2);
				}
				num = (myUnit.SupportsAttitude_Pitch ? (myUnit.GetCurrentAltitude() + num3) : ((float_1 - myUnit.GetCurrentAltitude() <= num3) ? float_1 : (myUnit.GetCurrentAltitude() + num3)));
				myUnit.SetCurrentAltitude(bool_0, num);
			}
			else if (myUnit.GetCurrentAltitude() <= float_1)
			{
				myUnit.DesiredPitch = 0f;
			}
			else
			{
				if (num2 > 0.0)
				{
					num4 = (float)((double)num4 - Math.Abs(num2));
				}
				num = (myUnit.SupportsAttitude_Pitch ? (myUnit.GetCurrentAltitude() - num4) : ((myUnit.GetCurrentAltitude() - float_1 <= num4) ? float_1 : (myUnit.GetCurrentAltitude() - num4)));
				myUnit.SetCurrentAltitude(bool_0, num);
			}
			float maximumAltitude = GetMaximumAltitude();
			float minimumAltitude = GetMinimumAltitude();
			if (myUnit.GetCurrentAltitude() <= maximumAltitude)
			{
				if (myUnit.GetCurrentAltitude() < minimumAltitude)
				{
					myUnit.SetCurrentAltitude(bool_0, minimumAltitude);
					myUnit.Attitude_Pitch = 0f;
				}
				else if (nullable_0.HasValue && (nullable_0.HasValue ? new bool?(num <= nullable_0.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					myUnit.SetCurrentAltitude(bool_0, nullable_0.Value);
					myUnit.Attitude_Pitch = 0f;
				}
			}
			else
			{
				myUnit.SetCurrentAltitude(bool_0, maximumAltitude - 10f);
				myUnit.Attitude_Pitch = 0f;
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

	public override float ClimbRate_Actual(float float_0)
	{
		if (myUnit.SupportsAttitude_Pitch)
		{
			return (float)((double)GetClimbRate_Nominal() + (double)myUnit.CurrentSpeed * 0.514444 * Math2.FillClass(float_0));
		}
		return GetClimbRate_Nominal();
	}

	public override float DiveRate_Nominal()
	{
		return (float)((double)GetClimbRate_Nominal() * 1.5);
	}

	public override float DiveRate_Actual(float float_0)
	{
		if (myUnit.SupportsAttitude_Pitch)
		{
			if (float_0 < 0f)
			{
				return (float)((double)DiveRate_Nominal() - (double)myUnit.CurrentSpeed * 0.514444 * Math2.FillClass(float_0));
			}
			return (float)((double)DiveRate_Nominal() + (double)myUnit.CurrentSpeed * 0.514444 * Math2.FillClass(float_0));
		}
		return DiveRate_Nominal();
	}

	internal float MapSpecification()
	{
		int emptyWeight = myUnit.EmptyWeight;
		if (emptyWeight < 350)
		{
			return 7.5f;
		}
		if (emptyWeight < 2500)
		{
			return 2f;
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
		float num = ((emptyWeight < 350) ? 15f : ((emptyWeight < 2500) ? 5f : ((emptyWeight < 5000) ? 3f : ((emptyWeight < 50000) ? 1f : 0.8f))));
		switch (myUnit.DesiredTurnRate)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return 0f;
		case ActiveUnit.TurnRate.Navigation:
			return num;
		case ActiveUnit.TurnRate.Max:
			return (float)((double)num * 1.25);
		}
	}

	public int BestTacticalSpeed(float float_0)
	{
		return CavitationSpeed(float_0) - 1;
	}

	public int? MinimumDepthToAchieveThisSpeed(float float_0, ActiveUnit.Throttle throttle_0)
	{
		int? result = null;
		try
		{
			List<AltBand> list = new List<AltBand>();
			foreach (Engine item2 in myUnit.Propulsion)
			{
				AltBand[] altBands = item2.AltBands;
				AltBand[] array = altBands;
				foreach (AltBand item in array)
				{
					list.Add(item);
				}
			}
			IEnumerable<AltBand> source = null;
			switch (throttle_0)
			{
			case ActiveUnit.Throttle.Loiter:
				source = from theB0 in list
					where (float)theB0.Speed_Loiter >= float_0
					orderby theB0.MaxAlt descending
					select theB0;
				break;
			case ActiveUnit.Throttle.Cruise:
				source = from theB in list
					where (float)theB.Speed_Cruise >= float_0
					orderby theB.MaxAlt descending
					select theB;
				break;
			case ActiveUnit.Throttle.Full:
				source = from theB0 in list.Where(delegate(AltBand theB)
					{
						float? num = theB.Speed_Full;
						return (num.HasValue ? new bool?(num.GetValueOrDefault() >= float_0) : null).GetValueOrDefault();
					})
					orderby theB0.MaxAlt descending
					select theB0;
				break;
			case ActiveUnit.Throttle.Flank:
				source = from theB0 in list.Where(delegate(AltBand theB)
					{
						float? num2 = theB.Speed_Flank;
						return (num2.HasValue ? new bool?(num2.GetValueOrDefault() >= float_0) : null).GetValueOrDefault();
					})
					orderby theB0.MaxAlt descending
					select theB0;
				break;
			}
			if (source.Count() == 0)
			{
				result = null;
				return result;
			}
			result = (int)Math.Round(source.ElementAtOrDefault(0).MaxAlt);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100834", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override AltBand GetCurrentAltBand(float float_0, bool bool_0)
	{
		try
		{
			AltBand altBand = null;
			AltBand[] array = null;
			foreach (Engine item in myUnit.Propulsion)
			{
				array = item.AltBands;
				int num = array.Length - 1;
				for (int i = 0; i <= num; i++)
				{
					AltBand altBand2 = array[i];
					if (altBand2.MaxAlt >= float_0 && !(float_0 + 1f < altBand2.MinAlt))
					{
						altBand = altBand2;
						break;
					}
				}
			}
			if (Information.IsNothing(altBand))
			{
				if (myUnit.IsAircraft)
				{
					altBand = array.OrderByDescending((AltBand theb) => theb.MaxAlt).ElementAtOrDefault(0);
					if (bool_0)
					{
						myUnit.SetCurrentAltitude(bool_0: false, altBand.MaxAlt);
					}
				}
				else
				{
					altBand = array.OrderBy((AltBand theb) => theb.MinAlt).ElementAtOrDefault(0);
					if (bool_0)
					{
						myUnit.SetCurrentAltitude(bool_0: true, altBand.MinAlt);
					}
				}
			}
			return altBand;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100835", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public override float Acceleration_Nominal(ActiveUnit.Throttle throttle_0, float float_0)
	{
		float currentSpeed = myUnit.CurrentSpeed;
		if (currentSpeed < 7f)
		{
			int emptyWeight = myUnit.EmptyWeight;
			if (emptyWeight < 350)
			{
				return 0.45f;
			}
			if (emptyWeight < 3500)
			{
				return 0.43f;
			}
			if (emptyWeight < 8100)
			{
				return 0.41f;
			}
			if (emptyWeight < 15000)
			{
				return 0.27f;
			}
			return 0.2f;
		}
		if (currentSpeed <= 20f)
		{
			int emptyWeight2 = myUnit.EmptyWeight;
			if (emptyWeight2 < 350)
			{
				return 0.3f;
			}
			if (emptyWeight2 < 3500)
			{
				return 0.3f;
			}
			if (emptyWeight2 < 8100)
			{
				return 0.65f;
			}
			if (emptyWeight2 < 15000)
			{
				return 0.45f;
			}
			return 0.25f;
		}
		int emptyWeight3 = myUnit.EmptyWeight;
		if (emptyWeight3 < 350)
		{
			return 0.25f;
		}
		if (emptyWeight3 < 3500)
		{
			return 0.25f;
		}
		if (emptyWeight3 < 8100)
		{
			return 0.55f;
		}
		if (emptyWeight3 < 15000)
		{
			return 0.4f;
		}
		return 0.2f;
	}

	public override float Acceleration_Actual(ActiveUnit.Throttle throttle_0, float float_0, float float_1)
	{
		float num = Acceleration_Nominal(throttle_0, float_0);
		if (GetParentPlatform().Flags.ShroudedPropulsor)
		{
			num = (float)((double)num * 1.1);
		}
		return num;
	}

	public override void Move(float float_0, bool bool_0, bool bool_1, DateTime dateTime_0)
	{
		try
		{
			if (!myUnit.IsOperating() || double.IsNaN(myUnit.GetLongitude()) || double.IsNaN(myUnit.GetLatitude()))
			{
				return;
			}
			AdjustAttitude_Roll(float_0);
			if (myUnit.DesiredAltitude > 0f)
			{
				myUnit.DesiredAltitude = 0f;
			}
			float num = myUnit.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, myUnit.ParentScen);
			if (SeaIceProvider.PrepareWriter(myUnit.GetLongitude(), myUnit.GetLatitude()) && myUnit.DesiredAltitude > -25f)
			{
				myUnit.DesiredAltitude = -25f;
			}
			if (((Submarine)myUnit).IsTetheredROV)
			{
				ActiveUnit assignedHostUnit = myUnit.DockingOps.GetAssignedHostUnit();
				if (assignedHostUnit != null && (double)Module_Unit.RangeToUnit_Horiz(myUnit, assignedHostUnit) * 1852.0 > (double)((Submarine)myUnit).ROVControlRadius_m)
				{
					ActiveUnit unit_ = myUnit;
					string string_ = "";
					if (Math.Abs(Module_Unit.PrintTokenizer(assignedHostUnit, unit_, bool_0: true, ref string_)) > 90f || assignedHostUnit.CurrentSpeed > myUnit.CurrentSpeed)
					{
						if (myUnit.AssignedMissionOrPackage() != null && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing)
						{
							_ = ((MineClearingMission)myUnit.AssignedMissionOrPackage()).Area;
							if (!myUnit.Navigator.HasPlottedCourse())
							{
								float num2 = assignedHostUnit.CurrentHeading;
								if (num2 - 45f <= 0f)
								{
									num2 += 360f;
								}
								int int_ = Math2.InsertClass(GameGeneral.LockRandom_0.Next((int)Math.Round(num2 - 45f), (int)Math.Round(num2 + 46f)));
								double double_ = 0.0;
								double double_2 = 0.0;
								Geodesic_EdWilliams.CalcPoint_Williams(assignedHostUnit.GetLongitude(), assignedHostUnit.GetLatitude(), ref double_, ref double_2, (float)((double)GetParentPlatform().ROVControlRadius_m / 1852.0), int_);
								GetParentPlatform().SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.PublishClass(GetParentPlatform().GetLatitude(), GetParentPlatform().GetLongitude(), double_2, double_));
								if (myUnit.Navigator.HasPlottedCourse())
								{
									myUnit.Navigator.PlottedCourse[0].Latitude = double_2;
									myUnit.Navigator.PlottedCourse[0].Longitude = double_;
								}
								else
								{
									myUnit.Navigator.AddWaypoint(new Waypoint(double_, double_2, 0f, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
								}
							}
						}
						else if (assignedHostUnit.CurrentSpeed > 0f)
						{
							float num3 = Module_Unit.BearingToUnit_True(myUnit, assignedHostUnit);
							myUnit.CurrentHeading = num3;
							myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Max, num3);
							myUnit.CurrentSpeed = assignedHostUnit.CurrentSpeed;
						}
					}
				}
			}
			if (myUnit.AI.HoldPosition)
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
			}
			else if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				if (myUnit.Kinematics.ThrottlePreset == UnitThrottlePreset.None)
				{
					myUnit.SetThrottle(GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
				}
				else if (myUnit.Status != 0 && myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
				{
					ActiveUnit_DockingOps dockingOps = myUnit.DockingOps;
					if (dockingOps.UNREP_Queue.Count == 0 && string.IsNullOrEmpty(dockingOps.UNREP_Starboard_ReceiverUnitID) && string.IsNullOrEmpty(dockingOps.UNREP_Port_ReceiverUnitID) && string.IsNullOrEmpty(dockingOps.UNREP_Astern_ReceiverUnitID))
					{
						myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
					}
				}
			}
			float num4 = GetMaximumSpeed(myUnit.GetCurrentAltitude(), myUnit.ThrottleSetting, bool_0: true);
			if (GeoPoint.GetIsInCanal(myUnit.GetLatitude(), myUnit.GetLongitude()))
			{
				num4 = 8f;
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
			if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation && myUnit.Navigator.HasFlightPlan && (!(myUnit.IsGroupWingman() & (myUnit.GetParentGroup() != null)) || myUnit.GetParentGroup().GroupLead == null || (int)Math.Round(myUnit.CurrentSpeed) == (int)Math.Round(myUnit.GetParentGroup().GroupLead.CurrentSpeed)) && (int)Math.Round(num5) != (int)Math.Round(myUnit.CurrentHeading))
			{
				if (myUnit.Navigator.PreviousWaypointType.HasValue)
				{
					int? num7 = (int?)myUnit.Navigator.PreviousWaypointType;
					bool? flag2 = (num7.HasValue ? new bool?(num7.GetValueOrDefault() == 15) : null);
					if (!((!flag2) ?? flag2).GetValueOrDefault())
					{
						goto IL_080a;
					}
				}
				flag = true;
			}
			goto IL_080a;
			IL_080a:
			if (!flag && myUnit.CurrentSpeed != myUnit.DesiredSpeed)
			{
				GoToDesiredSpeed(float_0, (float)num6);
			}
			if (myUnit.SupportsAttitude_Pitch)
			{
				AdjustAttitude_Pitch(float_0);
			}
			ChangeAltitude(float_0, myUnit.DesiredAltitude, num + 1f, bool_0: true);
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
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100836", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[CompilerGenerated]
	private bool SortSpecification(FuelRec fuelRec_0)
	{
		return myUnit.Propulsion[0].CanUseThisFuelType(FuelRec._FuelType.Battery);
	}

	[CompilerGenerated]
	private bool CalcSpecification(FuelRec fuelRec_0)
	{
		return myUnit.Propulsion[0].CanUseThisFuelType(FuelRec._FuelType.DieselFuel);
	}
}
