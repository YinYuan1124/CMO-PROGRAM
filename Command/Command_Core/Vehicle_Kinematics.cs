using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Vehicle_Kinematics : ActiveUnit_Kinematics
{
	private Vehicle getterProxy;

	public Engine ActiveEngine
	{
		get
		{
			Engine result = null;
			if (myUnit.Propulsion.Count > 0)
			{
				result = ((!ComputeReponse().IsOutOfFuel || (Module_Unit.ResetTokenizer(ComputeReponse()) && myUnit.IsOperating())) ? myUnit.Propulsion.Where((Engine theE) => theE.CanBeUsedOverland()).ElementAtOrDefault(0) : myUnit.Propulsion.Where((Engine theE) => theE.CanBeUsedOnWater()).ElementAtOrDefault(0));
			}
			return result;
		}
	}

	private Vehicle ComputeReponse()
	{
		if (getterProxy == null)
		{
			getterProxy = (Vehicle)myUnit;
		}
		return getterProxy;
	}

	public Vehicle_Kinematics(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}

	public override ActiveUnit.Throttle GetThrottleSuitableForThisSpeed(float float_0, float float_1)
	{
		try
		{
			if (myUnit.Propulsion.Count == 0)
			{
				return ActiveUnit.Throttle.FullStop;
			}
			AltBand currentAltBand_CurrentAltitude = GetCurrentAltBand_CurrentAltitude(float_0, ComputeReponse().PrimaryEngine, bool_0: false);
			if (currentAltBand_CurrentAltitude == null)
			{
				return ActiveUnit.Throttle.FullStop;
			}
			_ = ComputeReponse().PrimaryEngine.AltBands;
			int speed_Loiter = currentAltBand_CurrentAltitude.Speed_Loiter;
			int speed_Cruise = currentAltBand_CurrentAltitude.Speed_Cruise;
			int num = 0;
			if (currentAltBand_CurrentAltitude.Consumption_Full.HasValue)
			{
				num = (int)currentAltBand_CurrentAltitude.Speed_Full.Value;
			}
			if (currentAltBand_CurrentAltitude.Consumption_Flank.HasValue)
			{
				_ = currentAltBand_CurrentAltitude.Speed_Flank.Value;
			}
			if (float_1 == 0f)
			{
				return ActiveUnit.Throttle.FullStop;
			}
			if (float_1 <= (float)speed_Loiter)
			{
				return ActiveUnit.Throttle.Loiter;
			}
			if (float_1 <= (float)speed_Cruise)
			{
				return ActiveUnit.Throttle.Cruise;
			}
			if (float_1 <= (float)num)
			{
				if (currentAltBand_CurrentAltitude.Consumption_Full.HasValue)
				{
					return ActiveUnit.Throttle.Full;
				}
				return ActiveUnit.Throttle.Cruise;
			}
			if (currentAltBand_CurrentAltitude.Consumption_Flank.HasValue)
			{
				return ActiveUnit.Throttle.Flank;
			}
			return ActiveUnit.Throttle.Full;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 102435304958349056", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return ActiveUnit.Throttle.Cruise;
		}
	}

	public override float TacticalRadius()
	{
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
			if (myUnit.Propulsion.Count > 0)
			{
				Engine activeEngine = ActiveEngine;
				if (activeEngine != null && activeEngine.AltBands.Length != 0)
				{
					ActiveUnit.Throttle throttle = ActiveUnit.Throttle.Cruise;
					float num;
					if (nullable_0.HasValue)
					{
						num = nullable_0.Value;
						throttle = GetThrottleSuitableForThisSpeed(0f, nullable_0.Value);
					}
					else
					{
						num = GetMaximumSpeed(0f, throttle, bool_0: false);
					}
					double num2 = 0.0;
					float num3 = 0f;
					foreach (FuelRec item in myUnit.Fuel_ReadOnly)
					{
						if (activeEngine.CanUseThisFuelType(item.FuelType))
						{
							if (1 == 0)
							{
							}
							float num4 = throttle switch
							{
								ActiveUnit.Throttle.Cruise => activeEngine.AltBands[0].Consumption_Cruise, 
								ActiveUnit.Throttle.Full => activeEngine.AltBands[0].Consumption_Full.HasValue ? activeEngine.AltBands[0].Consumption_Full.Value : activeEngine.AltBands[0].Consumption_Cruise, 
								ActiveUnit.Throttle.Flank => activeEngine.AltBands[0].Consumption_Flank.HasValue ? activeEngine.AltBands[0].Consumption_Flank.Value : (activeEngine.AltBands[0].Consumption_Full.HasValue ? activeEngine.AltBands[0].Consumption_Full.Value : activeEngine.AltBands[0].Consumption_Cruise), 
								_ => activeEngine.AltBands[0].Consumption_Loiter, 
							};
							if (1 == 0)
							{
							}
							num3 = num4;
							num2 += (double)(item.CurrentQuantity / num3);
						}
					}
					return (float)(num2 * (double)num / 60.0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100788B", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return float.MaxValue;
		}
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

	public override int GetMaximumSpeed_Total()
	{
		try
		{
			return (int)Math.Round(PatchReponse(ComputeReponse().GetLatitude(), ComputeReponse().GetLongitude()));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 103240694", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			_ = Debugger.IsAttached;
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	internal float PatchReponse(double double_0, double double_1, bool bool_0 = true)
	{
		if (myUnit.Propulsion.Count == 0)
		{
			return 0f;
		}
		Engine engine;
		if (myUnit.IsOperating())
		{
			short elevation = Terrain.GetElevation(double_0, double_1, bool_0: false, myUnit.ParentScen);
			bool flag = elevation > 0;
			int num = -415;
			if (!flag)
			{
				bool flag2;
				if (flag2 = !Information.IsNothing(ComputeReponse().Propulsion.Where((Engine theE) => theE.CanBeUsedOnWater()).ElementAtOrDefault(0)))
				{
					flag = flag2;
				}
				else if (elevation > num && LandCover.DestroyClass(double_0, double_1, myUnit.ParentScen) != 0)
				{
					flag = true;
				}
			}
			float num2;
			if (flag)
			{
				engine = myUnit.Propulsion.Where((Engine theE) => theE.CanBeUsedOverland()).ElementAtOrDefault(0);
				num2 = engine.MaxSpeed();
				float num3 = GetMaximumSpeed();
				float num4 = Terrain.InvokeWatcher(double_0, double_1, bool_0: false, myUnit.ParentScen);
				Vehicle vehicle = ComputeReponse();
				float num5 = 1f;
				switch (ComputeReponse().TractionMode)
				{
				case Vehicle.TractionType.Wheeled:
					num5 = 0.4f;
					break;
				case Vehicle.TractionType.HalfTrack:
					num5 = 1.5f;
					break;
				case Vehicle.TractionType.Tracked:
					num5 = 2f;
					break;
				case Vehicle.TractionType.Legged:
					num5 = 0.75f;
					break;
				case Vehicle.TractionType.Undefined:
					num5 = 1f;
					break;
				}
				num3 /= 1f + num4;
				num3 /= (float)Math.Pow(1f + num4, 2.0);
				if (myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects))
				{
					switch (LandCover.DestroyClass(double_0, double_1, vehicle.ParentScen))
					{
					default:
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						num3 = 0f;
						break;
					case LandCover.LandCoverType.Water:
						num3 = (ComputeReponse().IsAmphibious ? (num3 * 0.2f) : 0.01f);
						break;
					case LandCover.LandCoverType.Evergreen_Needleleaf_forest:
					case LandCover.LandCoverType.Evergreen_Broadleaf_forest:
					case LandCover.LandCoverType.Deciduous_Needleleaf_forest:
					case LandCover.LandCoverType.Deciduous_Broadleaf_forest:
					case LandCover.LandCoverType.Mixed_forest:
						num3 = ((vehicle.TractionMode == Vehicle.TractionType.Legged) ? (num3 * 0.7f) : (num3 * 0.3f * ((num5 + 1f) / 2f)));
						break;
					case LandCover.LandCoverType.Closed_shrublands:
					case LandCover.LandCoverType.Open_shrublands:
						num3 = ((vehicle.TractionMode == Vehicle.TractionType.Legged) ? (num3 * 0.6f) : (num3 * 0.5f * ((num5 + 1f) / 2f)));
						break;
					case LandCover.LandCoverType.Woody_savannas:
					case LandCover.LandCoverType.Savannas:
						if (vehicle.TractionMode == Vehicle.TractionType.Legged)
						{
							num3 *= 0.7f;
						}
						break;
					case LandCover.LandCoverType.Permanent_wetlands:
						num3 = num3 * 0.1f * num5;
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
						switch (vehicle.TractionMode)
						{
						case Vehicle.TractionType.Wheeled:
							num3 *= 1.4f;
							break;
						case Vehicle.TractionType.HalfTrack:
							num3 *= 1.1f;
							break;
						case Vehicle.TractionType.Tracked:
							num3 *= 1f;
							break;
						case Vehicle.TractionType.Undefined:
						case Vehicle.TractionType.Legged:
							num3 *= 1.05f;
							break;
						}
						break;
					case LandCover.LandCoverType.Croplands:
					case LandCover.LandCoverType.CroplandNaturalVegetationMosaic:
						num3 = ((vehicle.TractionMode == Vehicle.TractionType.Legged) ? (num3 * 0.85f) : (num3 * 0.7f * ((num5 + 1f) / 2f)));
						break;
					case LandCover.LandCoverType.SnowAndIce:
						num3 = num3 * 0.2f * num5;
						break;
					case LandCover.LandCoverType.Grasslands:
					case LandCover.LandCoverType.BarrenOrSparselyVegetated:
						break;
					}
				}
				if (bool_0 && num3 < 1f && num3 > 0f)
				{
					num3 = 1f;
				}
				return num3;
			}
			engine = myUnit.Propulsion.Where((Engine theE) => theE.CanBeUsedOnWater()).ElementAtOrDefault(0);
			if (Information.IsNothing(engine))
			{
				return 0f;
			}
			num2 = engine.AltBands[1].MaxSpeed.Value;
			if (Weather.GetWeatherAtThisTimeAndPlace(ComputeReponse().ParentScen, double_0, double_1, 0).SeaState >= ComputeReponse().MaxSeaState)
			{
				num2 = (int)Math.Round((double)num2 * 0.5);
			}
			return num2;
		}
		engine = myUnit.Propulsion.Where((Engine theE) => theE.CanBeUsedOverland()).ElementAtOrDefault(0);
		return engine.MaxSpeed();
	}

	public override AltBand GetCurrentAltBand(float float_0, bool bool_0)
	{
		Engine activeEngine = ActiveEngine;
		if (activeEngine != null && activeEngine.AltBands.Count() > 0)
		{
			return activeEngine.AltBands[0];
		}
		return null;
	}

	public AltBand GetCurrentAltBand_CurrentAltitude_Vehicle(Engine engine_0)
	{
		try
		{
			if (engine_0 == null)
			{
				engine_0 = ActiveEngine;
			}
			if (engine_0 != null && engine_0.AltBands.Count() != 0)
			{
				return engine_0.AltBands[0];
			}
			if (Debugger.IsAttached && ComputeReponse().MobileUnitCategory != IMobileGroundUnit._MobileUnitCategory.Artillery_Towed)
			{
				Debugger.Break();
			}
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100188", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public override void Move(float float_0, bool bool_0, bool bool_1, DateTime dateTime_0)
	{
		try
		{
			myUnit.UpdateSettlingOnPosition(float_0);
			if (myUnit.AI.HoldPosition)
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
			}
			try
			{
				if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
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
				float num = PatchReponse(myUnit.GetLatitude(), myUnit.GetLongitude());
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
				if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation && myUnit.Navigator.HasFlightPlan && (!(myUnit.IsGroupWingman() & (myUnit.GetParentGroup() != null)) || Information.IsNothing(myUnit.GetParentGroup().GroupLead) || (int)Math.Round(myUnit.CurrentSpeed) == (int)Math.Round(myUnit.GetParentGroup().GroupLead.CurrentSpeed)) && (int)Math.Round(num2) != (int)Math.Round(myUnit.CurrentHeading))
				{
					if (!Information.IsNothing(myUnit.Navigator.PreviousWaypointType))
					{
						int? num4 = (int?)myUnit.Navigator.PreviousWaypointType;
						bool? flag2 = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == 15) : null);
						if (!((!flag2) ?? flag2).GetValueOrDefault())
						{
							goto IL_048f;
						}
					}
					flag = true;
				}
				goto IL_048f;
				IL_048f:
				if (!flag && myUnit.CurrentSpeed != myUnit.DesiredSpeed)
				{
					GoToDesiredSpeed(float_0, (float)num3);
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
			myUnit.SetCurrentAltitude(bool_0: false, myUnit.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, myUnit.ParentScen));
			if (!bool_1)
			{
				myUnit.Kinematics.ExportLocationEvent(myUnit.Kinematics.PerformOutOfSequenceExportLocation);
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
