using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class Weapon_Kinematics : ActiveUnit_Kinematics
{
	private Dictionary<int, float> m_RefReader;

	private Dictionary<int, float> errorReader;

	private Dictionary<int, float> codeReader;

	private Dictionary<int, float> _ConnectionReader;

	private Weapon _ContextReader;

	private AltBand statusReader;

	protected Weapon myWeapon
	{
		get
		{
			if (_ContextReader == null)
			{
				_ContextReader = (Weapon)myUnit;
			}
			return _ContextReader;
		}
	}

	public Weapon_Kinematics(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
		m_RefReader = new Dictionary<int, float>();
		errorReader = new Dictionary<int, float>();
		codeReader = new Dictionary<int, float>();
		_ConnectionReader = new Dictionary<int, float>();
		statusReader = null;
	}

	public int CalculateBoostPhaseDuration()
	{
		switch (myWeapon.Propulsion[0].Type)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return 5;
		case Engine.EngineType.Rocket_BoostCoast:
		case Engine.EngineType.Rocket_LongBurn:
		case Engine.EngineType.Ramjet:
		{
			float maxRange_NoTargetType = myWeapon.MaxRange_NoTargetType;
			if (maxRange_NoTargetType < 10f)
			{
				return 3;
			}
			if (maxRange_NoTargetType < 20f)
			{
				return 5;
			}
			if (maxRange_NoTargetType < 50f)
			{
				return 15;
			}
			return 30;
		}
		case Engine.EngineType.Turbojet:
		case Engine.EngineType.Turbofan:
			return 5;
		}
	}

	internal void IncludeDescriptor(ActiveUnit activeUnit_0, Contact contact_0)
	{
		if (!myWeapon.IsAAW || myWeapon.CruiseAltitude_ASL == 0f || (!contact_0.IsAircraftContact && contact_0.Type != Contact_Base.ContactType.Missile))
		{
			return;
		}
		if (contact_0.ActualUnit.IsBallisticMissile && contact_0.mapperObserver.Length != 0)
		{
			float val = contact_0.mapperObserver.Select((TrajectoryPoint theTP) => theTP.Altitude).Max();
			myWeapon.CruiseAltitude_ASL = Math.Min(val, GetMaximumAltitude());
			return;
		}
		float num = contact_0.GetCurrentAltitude() - activeUnit_0.GetCurrentAltitude();
		if ((double)num <= (double)myWeapon.CruiseAltitude_ASL * 0.5)
		{
			Geopoint_Struct geopoint_Struct_ = myWeapon.Navigator.ComputeInterceptPoint_BruteForce((float)((double)GetMaximumSpeed() * 0.5), contact_0, null);
			double num2 = (double)Module_Unit.RangeToPoint_Horiz(myWeapon, geopoint_Struct_) * 1852.0;
			double double_ = Math.Atan((double)num / num2 + Math.Sqrt(Math.Pow(num, 2.0) / Math.Pow(num2, 2.0) + 1.0)) * 57.2957795130823;
			double num3 = num2 * Math2.RemoveClass(double_) / 4.0 + (double)activeUnit_0.GetCurrentAltitude();
			float maximumAltitude = myWeapon.Kinematics.GetMaximumAltitude();
			if (num3 > (double)maximumAltitude)
			{
				num3 = maximumAltitude - 1f;
			}
			myWeapon.CruiseAltitude_ASL = (float)num3;
		}
	}

	public override void Loiter(float float_0, bool bool_0 = false, bool bool_1 = false)
	{
		if (myWeapon.AI.PrimaryTarget != null && (myWeapon.Navigator.PlottedCourse == null || myWeapon.Navigator.PlottedCourse.Count() == 0))
		{
			myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(Module_Unit.BearingToUnit_True(myUnit, myUnit.AI.PrimaryTarget) + 3f * float_0));
		}
		else
		{
			myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.UpdateClass(myUnit.CurrentHeading + 3f * float_0));
		}
		if (myWeapon.CanParachuteLoiter)
		{
			myWeapon.DeployLoiterParachute();
		}
		else if (myWeapon.IsParachuteLoitering)
		{
			myWeapon.CurrentSpeed = 97.192f;
			myWeapon.DesiredSpeed = myWeapon.CurrentSpeed;
			myWeapon.DesiredAltitude = myWeapon.GetCurrentAltitude() - 50f * float_0;
		}
		else if (myUnit.Kinematics.CanApplyLoiterThrottle())
		{
			myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
		}
		else
		{
			myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
		}
	}

	public override float TurnRate()
	{
		switch (((Weapon)myUnit).Type)
		{
		default:
		{
			float num = Physics.CompareStub(myUnit.GetCurrentAltitude(), myUnit.CurrentSpeed);
			if (num < 1f)
			{
				return 60f;
			}
			if (num <= 1f)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new NotImplementedException();
			}
			return 30f;
		}
		case Weapon._WeaponType.Torpedo:
			return 10f;
		case Weapon._WeaponType.GuidedWeapon:
			if (((Weapon)myUnit).IsAAW)
			{
				return 60f;
			}
			return 30f;
		}
	}

	private float SearchDescriptor(float float_0)
	{
		Weapon weapon = myWeapon;
		if (weapon.UsesBoostCoastModel.Value && weapon.TotalBurnTime < 5)
		{
			return float_0 / (float)weapon.TotalBurnTime;
		}
		return float_0 / 5f;
	}

	private float EnableDescriptor(float float_0)
	{
		bool flag = false;
		if (myUnit.IsTorpedo)
		{
			foreach (Engine item in myUnit.Propulsion)
			{
				if (item.Type == Engine.EngineType.Torpedo_Electric)
				{
					flag = true;
					break;
				}
			}
		}
		if (flag)
		{
			return myUnit.DesiredSpeed;
		}
		return (float)(0.065 * (double)myUnit.DesiredSpeed);
	}

	public override float Acceleration_Actual(ActiveUnit.Throttle throttle_0, float float_0, float float_1)
	{
		if (myWeapon.IsMissile)
		{
			return SearchDescriptor(float_1);
		}
		return EnableDescriptor(float_1);
	}

	public void GoToDesiredSpeed(float float_0, float float_1, float float_2)
	{
		try
		{
			float num = Acceleration_Actual(myUnit.ThrottleSetting, myUnit.GetCurrentAltitude(), float_2) * float_0;
			if (myUnit.CurrentSpeed < myUnit.DesiredSpeed)
			{
				myUnit.CurrentSpeed += num;
				if ((int)Math.Round(myUnit.CurrentSpeed) > (int)Math.Round(myUnit.DesiredSpeed))
				{
					myUnit.CurrentSpeed = myUnit.DesiredSpeed;
				}
			}
			if (myUnit.CurrentSpeed > myUnit.DesiredSpeed)
			{
				double num2 = 0.0;
				num2 = ((float_2 == 0f) ? (-4.905 * Math.Pow(float_0, 2.0)) : ((double)(2f * num * (myUnit.CurrentSpeed / float_2))));
				myUnit.CurrentSpeed = (float)((double)myUnit.CurrentSpeed - num2);
				if ((int)Math.Round(myUnit.CurrentSpeed) < (int)Math.Round(myUnit.DesiredSpeed))
				{
					myUnit.CurrentSpeed = myUnit.DesiredSpeed;
				}
			}
			if (myUnit.CurrentSpeed < 0f)
			{
				myUnit.CurrentSpeed = 0f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100980", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override float PitchRate_Negative()
	{
		if (myWeapon.Type != Weapon._WeaponType.RV && myWeapon.Type != Weapon._WeaponType.BallisticMissile)
		{
			float num = (((Weapon)myUnit).IsAAW ? 60f : 30f);
			if (myWeapon.Flags.AttitudeControl == Weapon.WeaponFlags.AttitudeControlEnum.Aerodynamic)
			{
				float maximumAltitude = myWeapon.Kinematics.GetMaximumAltitude();
				if (maximumAltitude <= 0f)
				{
					num = ((myWeapon.GetCurrentAltitude() <= 50000f) ? ((float)((double)num * (1.0 - Math.Pow(myWeapon.GetCurrentAltitude() / 50000f, 0.800000011920929)))) : 0f);
				}
				else
				{
					double num2 = myWeapon.GetCurrentAltitude() / maximumAltitude;
					num = (float)((double)num * (0.25 + 0.75 * (1.0 - num2)));
				}
			}
			return num;
		}
		return 2f;
	}

	public override float PitchRate_Positive()
	{
		if (myWeapon.Type != Weapon._WeaponType.RV && myWeapon.Type != Weapon._WeaponType.BallisticMissile)
		{
			float num = (((Weapon)myUnit).IsAAW ? 60f : 30f);
			if (myWeapon.Flags.AttitudeControl == Weapon.WeaponFlags.AttitudeControlEnum.Aerodynamic)
			{
				float maximumAltitude = myWeapon.Kinematics.GetMaximumAltitude();
				double num2 = 0.0;
				if (maximumAltitude != 0f)
				{
					num2 = myWeapon.GetCurrentAltitude() / maximumAltitude;
				}
				num = (float)((double)num * (0.25 + 0.75 * (1.0 - num2)));
			}
			return num;
		}
		return 2f;
	}

	public override float RollRate()
	{
		return 25f;
	}

	private void ChangeDescriptor()
	{
		float num = myWeapon.FindReponse();
		if (myWeapon.Altitude_old == myWeapon.GetCurrentAltitude())
		{
			return;
		}
		float num2 = (float)((double)(myWeapon.GetCurrentAltitude() - myWeapon.Altitude_old) * 9.81 * (double)num);
		double num3 = 0.5 * (double)num * Math.Pow((double)myWeapon.CurrentSpeed * 0.514444, 2.0);
		num3 -= (double)num2;
		double num4 = Math.Sqrt(2.0 * Math.Abs(num3) / (double)num) * 1.94384;
		myWeapon.CurrentSpeed = (float)num4;
		if (num2 < 0f)
		{
			float val = GetMaximumSpeed(myWeapon.GetCurrentAltitude());
			float val2 = Module_Weapon.CollectTokenizer(myWeapon);
			if (myWeapon.CurrentSpeed > Math.Max(val, val2))
			{
				myWeapon.CurrentSpeed = Math.Max(val, val2);
			}
		}
	}

	protected void SpeedChangeDueToDrag(float float_0)
	{
		float num = myWeapon.FindReponse();
		if (Math2.VerifyClass(myWeapon.Latitude_old, myWeapon.Longitude_old, myWeapon.GetLatitude(), myWeapon.GetLongitude()) == 0f)
		{
			return;
		}
		Weather.TAtmosphere tAtmosphere = Weather.VisitDescriptor(Weather.TAtmosphereType.atm_ITU_R_Ref_Std, (int)Math.Round(myWeapon.GetCurrentAltitude()), myWeapon.WeatherAtMyLocation.GetActualTemp_CurrentScenarioTime(myWeapon.ParentScen, myWeapon.GetLatitude(), myWeapon.GetLongitude(), myWeapon.GetCurrentAltitude()));
		double num2 = tAtmosphere.Pressure * 100.0 / (287.058 * tAtmosphere.Temperature) + tAtmosphere.Rho / 1000.0;
		double x = (double)Math.Abs(myWeapon.CurrentSpeed) * 0.514444;
		double num3 = Math.PI * Math.Pow(myWeapon.Diameter / 2f, 2.0);
		switch (myWeapon.Type)
		{
		default:
			num3 *= 1.2;
			break;
		case Weapon._WeaponType.RV:
			if (myWeapon.HasTerminalGuidance)
			{
				num3 *= 1.2;
			}
			break;
		case Weapon._WeaponType.Rocket:
		case Weapon._WeaponType.IronBomb:
			num3 *= 1.1;
			break;
		}
		double num4 = myWeapon.RemoveReponse();
		float num5 = Math.Abs(myWeapon.DesiredPitch - myWeapon.Attitude_Pitch);
		if (num5 >= 1f)
		{
			num4 = ((num5 < 5f) ? (num4 * 1.2) : ((num5 < 10f) ? (num4 * 1.3) : ((num5 < 20f) ? (num4 * 1.5) : (num4 * 2.0))));
		}
		float num6 = Math.Abs(MathFunctions.DeleteRequest(myWeapon.DesiredHeading, myWeapon.CurrentHeading));
		if (num6 >= 1f)
		{
			num4 = ((num6 < 5f) ? (num4 * 1.2) : ((num6 < 10f) ? (num4 * 1.3) : ((num6 < 20f) ? (num4 * 1.5) : (num4 * 2.0))));
		}
		if (myWeapon.AI.TerminalDive && myWeapon.TimeSinceLaunch > (float)myWeapon.TotalBurnTime && myWeapon.DesiredPitch > myWeapon.MoveDescriptor() && myWeapon.Attitude_Pitch > myWeapon.MoveDescriptor())
		{
			num4 *= (double)Math.Abs(2f + (myWeapon.Attitude_Pitch - myWeapon.MoveDescriptor()) / 5f);
		}
		double num7 = 0.5 * num2 * Math.Pow(x, 2.0) * num4 * num3 / (double)num * (double)float_0 * 1.94384;
		myWeapon.CurrentSpeed = (float)((double)myWeapon.CurrentSpeed - num7);
	}

	internal int InitDescriptor(float float_0)
	{
		return (int)Math.Round((double)GetMaximumSpeed(float_0) / 5.0);
	}

	protected void Move_BoostCoast(float float_0, bool bool_0, bool bool_1)
	{
		if (!bool_1)
		{
			_ = myWeapon.CurrentAltitude_AGL;
		}
		if (myWeapon.SupportsAttitude_Pitch)
		{
			AdjustAttitude_Pitch(float_0);
		}
		if ((myWeapon.IsReEntryVehicle & !myWeapon.IsHGV) || (myWeapon.IsBallisticMissile & !myWeapon.IsHGV))
		{
			bool_0 = false;
		}
		ChangeAltitude(float_0, myUnit.DesiredAltitude, null, !myWeapon.IsBallisticMissile && !myWeapon.IsReEntryVehicle);
		double num = myUnit.CurrentHeading;
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
		ChangeDescriptor();
		SpeedChangeDueToDrag(float_0);
		double double_ = (double)Math.Abs(MathFunctions.DeleteRequest((float)num, myUnit.CurrentHeading)) * (double)(1f / float_0);
		CalcTurnDeceleration(double_, float_0);
		if (bool_0 && (myWeapon.IsMissile || myWeapon.IsDecoy) && myWeapon.GetCurrentAltitude() < 9000f && (!myWeapon.IsAAW || !myWeapon.IsASAT))
		{
			if (myWeapon.SupportsAttitude_Pitch && (Information.IsNothing(myWeapon.AI.PrimaryTarget) || myWeapon.AI.PrimaryTarget is AimpointContact) && myWeapon.Attitude_Pitch < -10f)
			{
				if (myWeapon.CurrentAltitude_AGL <= 0f)
				{
					Weapon weapon = myWeapon;
					double latitude = myWeapon.GetLatitude();
					double longitude = myWeapon.GetLongitude();
					float currentAltitude = myWeapon.GetCurrentAltitude();
					LockRandom lockRandom_ = GameGeneral.LockRandom_0;
					weapon.Detonate(latitude, longitude, currentAltitude, ref lockRandom_, bool_0: true);
				}
			}
			else
			{
				float value = myWeapon.MinimumSafeHeight.Value;
				if (myUnit.GetCurrentAltitude() < value)
				{
					myUnit.SetCurrentAltitude(bool_0: false, value);
				}
			}
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
		if (!bool_1)
		{
			if (myWeapon.IsTorpedo && myUnit.IsUnderground)
			{
				Weapon weapon2 = myWeapon;
				double latitude_old = myUnit.Latitude_old;
				double longitude_old = myUnit.Longitude_old;
				float currentAltitude2 = myWeapon.GetCurrentAltitude();
				LockRandom lockRandom_2 = GameGeneral.LockRandom_0;
				weapon2.Detonate(latitude_old, longitude_old, currentAltitude2, ref lockRandom_2, bool_0: true);
			}
			if (myWeapon.CurrentAltitude_AGL <= 0f && myWeapon.Attitude_Pitch <= 0f && (myWeapon.IsBallisticMissile || myWeapon.IsReEntryVehicle) && !myWeapon.clientReader && !myWeapon.dicReader)
			{
				Weapon weapon3 = myWeapon;
				double latitude2 = myWeapon.GetLatitude();
				double longitude2 = myWeapon.GetLongitude();
				float float_ = Math.Max(0, (int)Terrain.GetElevation(myUnit.GetLatitude(), myUnit.GetLongitude(), bool_0: false, myUnit.ParentScen));
				LockRandom lockRandom_3 = GameGeneral.LockRandom_0;
				weapon3.Detonate(latitude2, longitude2, float_, ref lockRandom_3, bool_0: true);
			}
		}
	}

	public override void Move(float float_0, bool bool_0, bool bool_1, DateTime dateTime_0)
	{
		myWeapon.TimeSinceLaunch += float_0;
		if (myWeapon.Type == Weapon._WeaponType.Sonobuoy)
		{
			return;
		}
		if (myWeapon.UsesBoostCoastModel.Value && myWeapon.TimeSinceLaunch > (float)myWeapon.TotalBurnTime)
		{
			Move_BoostCoast(float_0, bool_0, bool_1);
			return;
		}
		try
		{
			if (myWeapon.IsPalletWeapon & (myWeapon.Attitude_Pitch == myWeapon.DesiredPitch))
			{
				myWeapon.Kinematics.Loiter(float_0);
			}
			if (!bool_1)
			{
				_ = myWeapon.CurrentAltitude_AGL;
			}
			if (myWeapon.SupportsAttitude_Pitch)
			{
				AdjustAttitude_Pitch(float_0);
			}
			if ((myWeapon.IsReEntryVehicle & !myWeapon.IsHGV) || (myWeapon.IsBallisticMissile & !myWeapon.IsHGV))
			{
				bool_0 = false;
			}
			if (myUnit.DesiredSpeed < 0f)
			{
				myUnit.DesiredSpeed = 0f - myUnit.DesiredSpeed;
			}
			if (myWeapon.Type == Weapon._WeaponType.Torpedo)
			{
				if (myUnit.DesiredAltitude > 0f)
				{
					myUnit.DesiredAltitude = 0f;
				}
				if (myUnit.GetCurrentAltitude() > 0f)
				{
					myUnit.SetCurrentAltitude(bool_0: false, 0f);
				}
			}
			ChangeAltitude(float_0, myUnit.DesiredAltitude, null, !myWeapon.IsBallisticMissile && !myWeapon.IsReEntryVehicle);
			if (myWeapon.Type == Weapon._WeaponType.Torpedo && myUnit.CurrentAltitude_AGL != 0f && myUnit.GetCurrentAltitude() < (float)myUnit.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, myUnit.ParentScen))
			{
				if (myUnit.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, myUnit.ParentScen) < -1)
				{
					myUnit.SetCurrentAltitude(bool_0: false, myUnit.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, myUnit.ParentScen) + 1);
				}
				else
				{
					myUnit.SetCurrentAltitude(bool_0: false, -1f);
				}
			}
			float num = GetMaximumSpeed(myUnit.GetCurrentAltitude(), myUnit.ThrottleSetting, bool_0: true);
			if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				myUnit.DesiredSpeed = myUnit.Kinematics.DesiredSpeedOverride.Value;
			}
			else
			{
				myUnit.DesiredSpeed = num;
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
			if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation && myUnit.Navigator.HasFlightPlan && (!myUnit.IsGroupWingman() || myUnit.GetParentGroup() == null || myUnit.GetParentGroup().GroupLead == null || (int)Math.Round(myUnit.CurrentSpeed) == (int)Math.Round(myUnit.GetParentGroup().GroupLead.CurrentSpeed)) && (int)Math.Round(num2) != (int)Math.Round(myUnit.CurrentHeading))
			{
				if (myUnit.Navigator.PreviousWaypointType.HasValue)
				{
					int? num4 = (int?)myUnit.Navigator.PreviousWaypointType;
					bool? flag2 = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == 15) : null);
					if (!((!flag2) ?? flag2).GetValueOrDefault())
					{
						goto IL_0741;
					}
				}
				flag = true;
			}
			goto IL_0741;
			IL_0741:
			if (!flag && myUnit.CurrentSpeed != myUnit.DesiredSpeed)
			{
				GoToDesiredSpeed(float_0, (float)num3, num);
			}
			if (bool_0 && (myWeapon.IsMissile || myWeapon.IsDecoy) && myWeapon.GetCurrentAltitude() < (float)Terrain.GlobalMaxTerrainElevation && (!myWeapon.IsAAW || !myWeapon.IsASAT))
			{
				if (myWeapon.SupportsAttitude_Pitch && ((myWeapon.AI.PrimaryTarget == null && !myWeapon.Flags.LoiterCapability) || myWeapon.AI.PrimaryTarget is AimpointContact) && myWeapon.Attitude_Pitch < -10f)
				{
					if (myWeapon.CurrentAltitude_AGL <= 0f)
					{
						myWeapon.SetCurrentAltitude(bool_0: false, 0f - myWeapon.CurrentAltitude_AGL);
						if (!myWeapon.clientReader && !myWeapon.dicReader)
						{
							Weapon weapon = myWeapon;
							double latitude = myWeapon.GetLatitude();
							double longitude = myWeapon.GetLongitude();
							float currentAltitude = myWeapon.GetCurrentAltitude();
							LockRandom lockRandom_ = GameGeneral.LockRandom_0;
							weapon.Detonate(latitude, longitude, currentAltitude, ref lockRandom_, bool_0: true);
						}
					}
				}
				else
				{
					float value = myWeapon.MinimumSafeHeight.Value;
					if (myUnit.GetCurrentAltitude() < value)
					{
						myUnit.SetCurrentAltitude(bool_0: false, value);
					}
				}
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
			if (!bool_1)
			{
				if (myWeapon.IsTorpedo && myUnit.IsUnderground)
				{
					Weapon weapon2 = myWeapon;
					double latitude_old = myUnit.Latitude_old;
					double longitude_old = myUnit.Longitude_old;
					float currentAltitude2 = myWeapon.GetCurrentAltitude();
					LockRandom lockRandom_2 = GameGeneral.LockRandom_0;
					weapon2.Detonate(latitude_old, longitude_old, currentAltitude2, ref lockRandom_2, bool_0: true);
				}
				bool isAerospaceUnit = myWeapon.IsAerospaceUnit;
				if (myWeapon.GetCurrentAltitude() <= 0f && isAerospaceUnit)
				{
					if (!myWeapon.clientReader && !myWeapon.dicReader)
					{
						myUnit.AddMessage("武器：" + myUnit.Name + " has splashed into water", "武器问题", LoggedMessage.MessageType.WeaponEndgame, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						Weapon weapon3 = myWeapon;
						double latitude2 = myWeapon.GetLatitude();
						double longitude2 = myWeapon.GetLongitude();
						float float_ = Math.Max(0, (int)Terrain.GetElevation(myUnit.GetLatitude(), myUnit.GetLongitude(), bool_0: false, myUnit.ParentScen));
						LockRandom lockRandom_3 = GameGeneral.LockRandom_0;
						weapon3.Detonate(latitude2, longitude2, float_, ref lockRandom_3, bool_0: true);
					}
				}
				else if (myWeapon.CurrentAltitude_AGL <= 0f && myWeapon.Attitude_Pitch <= 0f && (myWeapon.IsBallisticMissile || myWeapon.IsReEntryVehicle) && !myWeapon.clientReader && !myWeapon.dicReader)
				{
					myUnit.AddMessage("武器：" + myUnit.Name + "已经撞入地下", "武器问题", LoggedMessage.MessageType.WeaponEndgame, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					Weapon weapon4 = myWeapon;
					double latitude3 = myWeapon.GetLatitude();
					double longitude3 = myWeapon.GetLongitude();
					float float_2 = Math.Max(0, (int)Terrain.GetElevation(myUnit.GetLatitude(), myUnit.GetLongitude(), bool_0: false, myUnit.ParentScen));
					LockRandom lockRandom_4 = GameGeneral.LockRandom_0;
					weapon4.Detonate(latitude3, longitude3, float_2, ref lockRandom_4, bool_0: true);
				}
			}
			Module_Unit.FlushTokenizer(myUnit, float_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100981", "");
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
			if (float_0 <= 0f)
			{
				return 0f;
			}
			if (myWeapon.CalculateReponse())
			{
				return (float)(Math.Max((double)myWeapon.CurrentSpeed * 0.514444, GetClimbRate_Nominal()) * Math2.FillClass(float_0));
			}
			return (float)((double)myWeapon.CurrentSpeed * 0.514444 * Math2.FillClass(float_0));
		}
		return GetClimbRate_Nominal();
	}

	public override void CalcTurnDeceleration(double double_0, float float_0)
	{
		try
		{
			if ((int)Math.Round(Math.Abs(myUnit.CurrentHeading - myUnit.DesiredHeading)) <= 5)
			{
				return;
			}
			double num = 0.0;
			switch (((Weapon)myUnit).Type)
			{
			case Weapon._WeaponType.Torpedo:
				if (double_0 > 25.0)
				{
					num = 1f * float_0;
				}
				if (double_0 > 45.0)
				{
					num = 2f * float_0;
				}
				break;
			case Weapon._WeaponType.GuidedWeapon:
				if (double_0 > 25.0)
				{
					num = 5f * float_0;
				}
				if (double_0 > 45.0)
				{
					num = 10f * float_0;
				}
				break;
			}
			myUnit.CurrentSpeed = (float)Math.Max((double)myUnit.CurrentSpeed - num, 0.0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101330", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override float DiveRate_Nominal()
	{
		if (((Weapon)myUnit).Type == Weapon._WeaponType.GuidedWeapon)
		{
			return Math.Max(100f, GetClimbRate_Nominal());
		}
		return GetClimbRate_Nominal();
	}

	public override float DiveRate_Actual(float float_0)
	{
		if (myUnit.SupportsAttitude_Pitch)
		{
			if (float_0 < 0f)
			{
				if (myWeapon.CalculateReponse())
				{
					return (float)(Math.Max((double)myWeapon.CurrentSpeed * 0.514444, DiveRate_Nominal()) * Math.Abs(Math2.FillClass(float_0)));
				}
				return (float)((double)myWeapon.CurrentSpeed * 0.514444 * Math.Abs(Math2.FillClass(float_0)));
			}
			return 0f;
		}
		return DiveRate_Nominal();
	}

	private int CheckDescriptor(ActiveUnit.Throttle throttle_0, bool bool_0)
	{
		AltBand altBand = null;
		Engine engine = null;
		float currentAltitude = myUnit.GetCurrentAltitude();
		try
		{
			if (float.IsNaN(currentAltitude))
			{
				return 0;
			}
			if (throttle_0 == ActiveUnit.Throttle.FullStop)
			{
				return 0;
			}
			if (myUnit.Propulsion.Count == 0)
			{
				return 0;
			}
			if (statusReader == null || currentAltitude > statusReader.MaxAlt || currentAltitude < statusReader.MinAlt)
			{
				statusReader = GetCurrentAltBand_CurrentAltitude(currentAltitude, null, bool_0);
			}
			if (statusReader == null)
			{
				return 0;
			}
			if (myUnit.Propulsion.Count <= 0)
			{
				return 0;
			}
			engine = myUnit.Propulsion[0];
			if (engine == null)
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
				num = statusReader.Speed_Loiter;
				break;
			case ActiveUnit.Throttle.Cruise:
				num = ((statusReader.Speed_Cruise <= 0) ? ((float)statusReader.Speed_Loiter) : ((float)statusReader.Speed_Cruise));
				break;
			case ActiveUnit.Throttle.Full:
				num = (statusReader.Speed_Full.HasValue ? ((float)statusReader.Speed_Full.Value) : ((float)statusReader.Speed_Cruise));
				break;
			case ActiveUnit.Throttle.Flank:
				num = (statusReader.Speed_Flank.HasValue ? ((float)statusReader.Speed_Flank.Value) : (statusReader.Speed_Full.HasValue ? ((float)statusReader.Speed_Full.Value) : ((float)statusReader.Speed_Cruise)));
				break;
			}
			float num2 = (int)Math.Round(num);
			if (statusReader != HighestAltBand(engine))
			{
				float num3 = float.MaxValue;
				AltBand[] array = altBands;
				AltBand[] array2 = array;
				foreach (AltBand altBand2 in array2)
				{
					if (altBand2.MinAlt >= statusReader.MaxAlt && altBand2.MaxAlt < num3)
					{
						altBand = altBand2;
					}
				}
				if (altBand != null)
				{
					float num4 = 0f;
					switch (throttle_0)
					{
					case ActiveUnit.Throttle.FullStop:
						num4 = 0f;
						break;
					case ActiveUnit.Throttle.Loiter:
						num4 = altBand.Speed_Loiter;
						break;
					case ActiveUnit.Throttle.Cruise:
						num4 = altBand.Speed_Cruise;
						break;
					case ActiveUnit.Throttle.Full:
						num4 = (altBand.Speed_Full.HasValue ? ((float)altBand.Speed_Full.Value) : ((float)altBand.Speed_Cruise));
						break;
					case ActiveUnit.Throttle.Flank:
						num4 = (altBand.Speed_Flank.HasValue ? ((float)altBand.Speed_Flank.Value) : (altBand.Speed_Full.HasValue ? ((float)altBand.Speed_Full.Value) : ((float)altBand.Speed_Cruise)));
						break;
					}
					num2 = (int)Math.Round(num4 + (currentAltitude - altBand.MinAlt) * (num - num4) / (statusReader.MinAlt - altBand.MinAlt));
				}
			}
			return (int)Math.Round(num2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10021343534653412323", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	internal float ConcatDescriptor()
	{
		if (myWeapon.IsAAW)
		{
			if (myWeapon.CalculateReponse())
			{
				return 0.9f;
			}
			if (myWeapon.MaxAirRange <= 15f)
			{
				return 0.8f;
			}
			if (myWeapon.Propulsion.Count <= 0)
			{
				return 0.55f;
			}
			Engine.EngineType type = myWeapon.Propulsion.First().Type;
			if (type == Engine.EngineType.Turbojet || (uint)(type - 5004) <= 1u)
			{
				return 0.75f;
			}
		}
		if (!myWeapon.IsASuW_Land && !myWeapon.IsASuW_Naval)
		{
			return 0.5f;
		}
		return 0.6f;
	}

	public override int GetMaximumSpeed(float float_0, ActiveUnit.Throttle throttle_0, bool bool_0, bool bool_1 = true)
	{
		AltBand altBand = null;
		AltBand altBand2 = null;
		Engine engine = null;
		try
		{
			if (float.IsNaN(float_0))
			{
				return 0;
			}
			if (throttle_0 == ActiveUnit.Throttle.FullStop)
			{
				return 0;
			}
			if (myUnit.Propulsion.Count == 0)
			{
				return 0;
			}
			altBand = GetCurrentAltBand_CurrentAltitude(float_0, null, bool_0);
			if (altBand == null)
			{
				return 0;
			}
			if (myUnit.Propulsion.Count <= 0)
			{
				return 0;
			}
			engine = myUnit.Propulsion[0];
			if (engine == null)
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
			float num2 = (int)Math.Round(num);
			if (altBand != HighestAltBand(engine))
			{
				float num3 = float.MaxValue;
				AltBand[] array = altBands;
				AltBand[] array2 = array;
				foreach (AltBand altBand3 in array2)
				{
					if (altBand3.MinAlt >= altBand.MaxAlt && altBand3.MaxAlt < num3)
					{
						altBand2 = altBand3;
					}
				}
				if (altBand2 != null)
				{
					float num4 = 0f;
					switch (throttle_0)
					{
					case ActiveUnit.Throttle.FullStop:
						num4 = 0f;
						break;
					case ActiveUnit.Throttle.Loiter:
						num4 = altBand2.Speed_Loiter;
						break;
					case ActiveUnit.Throttle.Cruise:
						num4 = altBand2.Speed_Cruise;
						break;
					case ActiveUnit.Throttle.Full:
						num4 = (altBand2.Speed_Full.HasValue ? ((float)altBand2.Speed_Full.Value) : ((float)altBand2.Speed_Cruise));
						break;
					case ActiveUnit.Throttle.Flank:
						num4 = (altBand2.Speed_Flank.HasValue ? ((float)altBand2.Speed_Flank.Value) : (altBand2.Speed_Full.HasValue ? ((float)altBand2.Speed_Full.Value) : ((float)altBand2.Speed_Cruise)));
						break;
					}
					num2 = (int)Math.Round(num4 + (float_0 - altBand2.MinAlt) * (num - num4) / (altBand.MinAlt - altBand2.MinAlt));
				}
			}
			return (int)Math.Round(num2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100982", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	public override void ChangeAltitude(float float_0, float float_1, float? nullable_0, bool bool_0)
	{
		try
		{
			if (Module_Unit.AwakeTokenizer(myUnit))
			{
				myUnit.SetCurrentAltitude(bool_0: false, myUnit.GetCurrentAltitude() + myUnit._ErrorItem * float_0);
				return;
			}
			_ = (myUnit.GetCurrentAltitude() - myUnit.Altitude_old) / float_0;
			myUnit.Altitude_old = myUnit.GetCurrentAltitude();
			float currentAltitude = myUnit.GetCurrentAltitude();
			if (myWeapon.IsReEntryVehicle && myUnit.DesiredAltitude > myUnit.GetCurrentAltitude())
			{
				myUnit.DesiredAltitude = Math.Min(myUnit.GetCurrentAltitude() - 1f, myUnit.DesiredAltitude);
			}
			float attitude_Pitch = myUnit.Attitude_Pitch;
			float num = ClimbRate_Actual(attitude_Pitch) * float_0;
			float num2 = DiveRate_Actual(attitude_Pitch) * float_0;
			if (nullable_0.HasValue && (nullable_0.HasValue ? new bool?(float_1 < nullable_0.GetValueOrDefault()) : null).GetValueOrDefault())
			{
				float_1 = nullable_0.Value;
			}
			if (myUnit.GetCurrentAltitude() < float_1)
			{
				currentAltitude = (myUnit.SupportsAttitude_Pitch ? (myUnit.GetCurrentAltitude() + num) : ((float_1 - myUnit.GetCurrentAltitude() <= num) ? float_1 : (myUnit.GetCurrentAltitude() + num)));
				myUnit.SetCurrentAltitude(bool_0, currentAltitude);
			}
			else if (myUnit.GetCurrentAltitude() <= float_1)
			{
				if (myUnit.GetCurrentAltitude() - float_1 == 0f)
				{
					myUnit.DesiredPitch = 0f;
				}
				if (myUnit.Attitude_Pitch < 0f && nullable_0.HasValue)
				{
					float currentAltitude2 = myUnit.GetCurrentAltitude();
					if ((nullable_0.HasValue ? new bool?(currentAltitude2 <= nullable_0.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						myUnit.Attitude_Pitch = 0f;
					}
				}
			}
			else
			{
				currentAltitude = (myUnit.SupportsAttitude_Pitch ? (myUnit.GetCurrentAltitude() - num2) : ((myUnit.GetCurrentAltitude() - float_1 <= num2) ? float_1 : (myUnit.GetCurrentAltitude() - num2)));
				if (nullable_0.HasValue && (nullable_0.HasValue ? new bool?(currentAltitude <= nullable_0.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					myUnit.Attitude_Pitch = 0f;
				}
				if (currentAltitude > 5000f && Operators.CompareString(myWeapon.Name, "RIM-162B ESSM #4660", TextCompare: false) == 0)
				{
					Debugger.Break();
				}
				myUnit.SetCurrentAltitude(bool_0, currentAltitude);
			}
			if (((Weapon)myUnit).IsPalletWeapon || myUnit.IsBallisticMissile)
			{
				return;
			}
			float maximumAltitude = GetMaximumAltitude();
			float minimumAltitude = GetMinimumAltitude();
			if (myUnit.GetCurrentAltitude() <= maximumAltitude)
			{
				if (myUnit.GetCurrentAltitude() < minimumAltitude)
				{
					myUnit.SetCurrentAltitude(bool_0, minimumAltitude);
					if (myUnit.Attitude_Pitch < 0f)
					{
						myUnit.Attitude_Pitch = 0f;
					}
				}
			}
			else
			{
				myUnit.SetCurrentAltitude(bool_0, maximumAltitude);
				if (myUnit.Attitude_Pitch > 0f)
				{
					myUnit.Attitude_Pitch = 0f;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 103459604287690345896708356790", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
