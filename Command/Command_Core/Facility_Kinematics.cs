using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Facility_Kinematics : ActiveUnit_Kinematics
{
	private Facility identifierClient;

	[SpecialName]
	private Facility GetParentPlatform()
	{
		if (identifierClient == null)
		{
			identifierClient = (Facility)myUnit;
		}
		return identifierClient;
	}

	public Facility_Kinematics(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}

	public override ActiveUnit.Throttle GetThrottleSuitableForThisSpeed(float float_0, float float_1)
	{
		if (float_1 == 0f)
		{
			return ActiveUnit.Throttle.FullStop;
		}
		if (float_1 <= 3f)
		{
			return ActiveUnit.Throttle.Loiter;
		}
		if (float_1 <= 10f)
		{
			return ActiveUnit.Throttle.Cruise;
		}
		if (float_1 <= 20f)
		{
			return ActiveUnit.Throttle.Full;
		}
		return ActiveUnit.Throttle.Flank;
	}

	public override float MaxRange(bool bool_0, float? nullable_0, float? nullable_1)
	{
		return float.MaxValue;
	}

	public override float TurnRate()
	{
		return 45f;
	}

	public override float Acceleration_Nominal(ActiveUnit.Throttle throttle_0, float float_0)
	{
		return 2f;
	}

	public override float Acceleration_Actual(ActiveUnit.Throttle throttle_0, float float_0, float float_1)
	{
		return 2f;
	}

	public override bool CanApplyFlankThrottle()
	{
		return true;
	}

	public override int GetMaximumSpeed()
	{
		if (GetParentPlatform().EnableBridge() == IMobileGroundUnit._MobileUnitCategory.Infantry)
		{
			return 5;
		}
		return 30;
	}

	public int GetMaximumSpeedAtThisLocation(double double_0, double double_1, bool bool_0 = true)
	{
		try
		{
			float num = GetMaximumSpeed();
			float num2 = Terrain.InvokeWatcher(double_0, double_1, bool_0: false, myUnit.ParentScen);
			Facility facility = (Facility)myUnit;
			float num3 = 1f;
			switch (facility.Category)
			{
			case Facility._FacilityCategory.Mobile_Vehicle:
				num3 = 1f;
				break;
			case Facility._FacilityCategory.Mobile_Personnel:
				num3 = 0.75f;
				break;
			case Facility._FacilityCategory.Mobile_Vehicules_Tracked:
				num3 = 2f;
				break;
			case Facility._FacilityCategory.Mobile_Vehicules_HalfTrack:
				num3 = 1.5f;
				break;
			case Facility._FacilityCategory.Mobile_Vehicule_Wheeled:
				num3 = 0.4f;
				break;
			}
			num /= 1f + num2;
			num /= (float)Math.Pow(1f + num2, 2.0);
			if (GetParentPlatform().ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects))
			{
				switch (LandCover.DestroyClass(double_0, double_1, GetParentPlatform().ParentScen))
				{
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					num = 0f;
					break;
				case LandCover.LandCoverType.Water:
					num = 0.01f;
					break;
				case LandCover.LandCoverType.Evergreen_Needleleaf_forest:
				case LandCover.LandCoverType.Evergreen_Broadleaf_forest:
				case LandCover.LandCoverType.Deciduous_Needleleaf_forest:
				case LandCover.LandCoverType.Deciduous_Broadleaf_forest:
				case LandCover.LandCoverType.Mixed_forest:
					num = ((facility.Category == Facility._FacilityCategory.Mobile_Personnel) ? ((float)(int)Math.Round((double)num * 0.7)) : ((float)(int)Math.Round((double)num * 0.3 * (double)((num3 + 1f) / 2f))));
					break;
				case LandCover.LandCoverType.Closed_shrublands:
				case LandCover.LandCoverType.Open_shrublands:
					num = ((facility.Category == Facility._FacilityCategory.Mobile_Personnel) ? ((float)(int)Math.Round((double)num * 0.6)) : ((float)(int)Math.Round((double)num * 0.5 * (double)((num3 + 1f) / 2f))));
					break;
				case LandCover.LandCoverType.Woody_savannas:
				case LandCover.LandCoverType.Savannas:
					if (facility.Category != Facility._FacilityCategory.Mobile_Personnel)
					{
						num = (int)Math.Round((double)num * 0.7);
					}
					break;
				case LandCover.LandCoverType.Permanent_wetlands:
					num = (int)Math.Round((double)num * 0.1 * (double)num3);
					break;
				case LandCover.LandCoverType.UrbanAndBuiltUp:
				case LandCover.LandCoverType.Urban_CloseInnerCity:
				case LandCover.LandCoverType.Urban_SpacedHighRise:
				case LandCover.LandCoverType.Urban_AttachedHouses:
				case LandCover.LandCoverType.Urban_CloseIndustrial:
				case LandCover.LandCoverType.Urban_SpacedApartments:
				case LandCover.LandCoverType.Urban_DetachedHouses:
				case LandCover.LandCoverType.Urban_SpacedIndustrial:
				case LandCover.LandCoverType.Urban_ShantyTown:
					switch (facility.Category)
					{
					case Facility._FacilityCategory.Mobile_Personnel:
						num = (int)Math.Round((double)num * 1.05);
						break;
					case Facility._FacilityCategory.Mobile_Vehicules_Tracked:
						num = (int)Math.Round(num * 1f);
						break;
					case Facility._FacilityCategory.Mobile_Vehicules_HalfTrack:
						num = (int)Math.Round((double)num * 1.1);
						break;
					case Facility._FacilityCategory.Mobile_Vehicule_Wheeled:
						num = (int)Math.Round((double)num * 1.4);
						break;
					}
					break;
				case LandCover.LandCoverType.Croplands:
				case LandCover.LandCoverType.CroplandNaturalVegetationMosaic:
					num = ((facility.Category == Facility._FacilityCategory.Mobile_Personnel) ? ((float)(int)Math.Round((double)num * 0.85)) : ((float)(int)Math.Round((double)num * 0.7 * (double)((num3 + 1f) / 2f))));
					break;
				case LandCover.LandCoverType.SnowAndIce:
					num = (int)Math.Round((double)num * 0.2 * (double)num3);
					break;
				case LandCover.LandCoverType.Grasslands:
				case LandCover.LandCoverType.BarrenOrSparselyVegetated:
					break;
				}
			}
			if (bool_0 && num < 1f && num > 0f)
			{
				num = 1f;
			}
			return (int)Math.Round(num);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100559", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	public override int GetMaximumSpeed(float float_0, ActiveUnit.Throttle throttle_0, bool bool_0, bool bool_1 = true)
	{
		float num = base.GetMaximumSpeed(float_0, throttle_0, bool_0: false);
		if (num == 0f)
		{
			return 0;
		}
		float val = GetMaximumSpeedAtThisLocation(myUnit.GetLatitude(), myUnit.GetLongitude());
		return (int)Math.Round(Math.Min(num, val));
	}

	public override void Move(float float_0, bool bool_0, bool bool_1, DateTime dateTime_0)
	{
		try
		{
			if (myUnit.IsFixedFacility)
			{
				myUnit.Kinematics.ExportLocationEvent(myUnit.Kinematics.PerformOutOfSequenceExportLocation);
				return;
			}
			myUnit.UpdateSettlingOnPosition(float_0);
			try
			{
				if (myUnit.AI.HoldPosition)
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
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
				else
				{
					myUnit.DesiredSpeed = Math.Min(myUnit.DesiredSpeed, myUnit.Kinematics.GetMaximumSpeed(0f, myUnit.ThrottleSetting, bool_0: false));
				}
				float num = GetMaximumSpeed(myUnit.GetCurrentAltitude(), myUnit.ThrottleSetting, bool_0: true);
				if ((myUnit.IsShip || myUnit.IsSubmarine) && GeoPoint.GetIsInCanal(myUnit.GetLatitude(), myUnit.GetLongitude()))
				{
					num = 8f;
				}
				if (myUnit.IsOutOfFuel)
				{
					if (myUnit.IsWeapon && myUnit.SupportsAttitude_Pitch)
					{
						if (myUnit.Attitude_Pitch > ((Weapon)myUnit).MoveDescriptor())
						{
							num = 0f;
						}
					}
					else
					{
						num = 0f;
					}
				}
				if (myUnit.DesiredSpeed > num)
				{
					myUnit.DesiredSpeed = num;
				}
				double num2 = myUnit.CurrentHeading;
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
				double num3 = (double)Math.Abs(MathFunctions.DeleteRequest((float)num2, myUnit.CurrentHeading)) * (double)(1f / float_0);
				CalcTurnDeceleration(num3, float_0);
				bool flag = false;
				if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation && myUnit.Navigator.HasFlightPlan && (!(myUnit.IsGroupWingman() & (myUnit.GetParentGroup() != null)) || myUnit.GetParentGroup().GroupLead == null || (int)Math.Round(myUnit.CurrentSpeed) == (int)Math.Round(myUnit.GetParentGroup().GroupLead.CurrentSpeed)) && (int)Math.Round(num2) != (int)Math.Round(myUnit.CurrentHeading))
				{
					if (myUnit.Navigator.PreviousWaypointType.HasValue)
					{
						int? num4 = (int?)myUnit.Navigator.PreviousWaypointType;
						bool? flag2 = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == 15) : null);
						if (!((!flag2) ?? flag2).GetValueOrDefault())
						{
							goto IL_0508;
						}
					}
					flag = true;
				}
				goto IL_0508;
				IL_0508:
				if (!flag && myUnit.CurrentSpeed != myUnit.DesiredSpeed)
				{
					GoToDesiredSpeed(float_0, (float)num3);
				}
				myUnit.SetCurrentAltitude(bool_0: false, myUnit.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, myUnit.ParentScen));
				if (!bool_1)
				{
					myUnit.Kinematics.ExportLocationEvent(myUnit.Kinematics.PerformOutOfSequenceExportLocation);
				}
				Module_Unit.FlushTokenizer(myUnit, float_0);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100197", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
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
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100560", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
