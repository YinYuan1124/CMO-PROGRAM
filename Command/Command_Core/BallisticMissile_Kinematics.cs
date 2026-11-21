using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class BallisticMissile_Kinematics : Weapon_Kinematics
{
	private BallisticMissile _StatusObserver;

	public BallisticMissile_Kinematics(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}

	private BallisticMissile RevertReader()
	{
		if (_StatusObserver == null)
		{
			_StatusObserver = (BallisticMissile)myUnit;
		}
		return _StatusObserver;
	}

	internal bool CountProperty()
	{
		if (BallisticTrajectory == null)
		{
			return false;
		}
		return BallisticTrajectory.CurrentRecord.TA > Math.PI / 2.0 + BallisticTrajectory.EndTA / 2.0;
	}

	public static TrajectoryPoint[] EstimatedFuturePathOfBallisticTarget(Contact contact_0, Scenario scenario_0)
	{
		if (contact_0.ActualUnit == null)
		{
			return new TrajectoryPoint[0];
		}
		return EstimatedFutureBallisticPath(contact_0.ActualUnit, contact_0.GetLatitude(), contact_0.GetLongitude(), contact_0.ActualUnit.AI.PrimaryTarget, scenario_0);
	}

	public static TrajectoryPoint[] EstimatedFutureBallisticPath(ActiveUnit activeUnit_0, double double_0, double double_1, Contact contact_0, Scenario scenario_0)
	{
		if (activeUnit_0 is BallisticMissile)
		{
			BallisticMissile ballisticMissile = (BallisticMissile)activeUnit_0;
			if (ballisticMissile.Kinematics.BallisticTrajectory != null)
			{
				contact_0 = new AimpointContact(ballisticMissile.Kinematics.BallisticTrajectory.Target.lat * 180.0 / Math.PI, ballisticMissile.Kinematics.BallisticTrajectory.Target.lon * 180.0 / Math.PI);
			}
		}
		Weapon newWeapon = Weapon.GetNewWeapon(ref activeUnit_0.ParentScen, activeUnit_0.DBID, bool_0: true);
		newWeapon._FacadeReader = true;
		newWeapon.AI.PrimaryTarget = contact_0;
		newWeapon.SetCurrentAltitude(bool_0: false, activeUnit_0.GetCurrentAltitude());
		newWeapon.CurrentSpeed = activeUnit_0.CurrentSpeed;
		newWeapon.CurrentHeading = activeUnit_0.CurrentHeading;
		newWeapon.SetLongitude(null, double_1);
		newWeapon.SetLatitude(null, double_0);
		newWeapon.Attitude_Pitch = activeUnit_0.Attitude_Pitch;
		bool flag = false;
		if (activeUnit_0.IsWeapon & ((Weapon)activeUnit_0).IsHGV)
		{
			flag = true;
		}
		if (activeUnit_0.IsBallisticMissile && !flag)
		{
			newWeapon.TimeSinceBurnout = ((Weapon)activeUnit_0).TimeSinceBurnout;
			newWeapon.TimeSinceLaunch = ((Weapon)activeUnit_0).TimeSinceLaunch;
		}
		Weapon weapon = (Weapon)activeUnit_0;
		newWeapon.LaunchPoint = new GeoPoint();
		if (weapon.LaunchPoint == null)
		{
			newWeapon.LaunchPoint.Longitude = double_1;
			newWeapon.LaunchPoint.Latitude = double_0;
			newWeapon.LaunchPoint.Altitude = activeUnit_0.GetCurrentAltitude();
		}
		else
		{
			newWeapon.LaunchPoint.Longitude = weapon.LaunchPoint.Longitude;
			newWeapon.LaunchPoint.Latitude = weapon.LaunchPoint.Latitude;
			newWeapon.LaunchPoint.Altitude = weapon.LaunchPoint.Altitude;
		}
		newWeapon.FiringParent = weapon.FiringParent;
		newWeapon.Navigator.ClearPlottedCourse();
		Waypoint[] plottedCourse = weapon.Navigator.PlottedCourse;
		Waypoint[] array = plottedCourse;
		foreach (Waypoint waypoint_ in array)
		{
			newWeapon.Navigator.AddWaypoint(waypoint_);
		}
		float num = 1f;
		int capacity = (int)Math.Round(newWeapon.Fuel_ReadOnly[0].CurrentQuantity);
		newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
		_ = scenario_0.Time;
		DateTime dateTime_ = scenario_0.Time;
		long num2 = (long)Math.Round((86400.0 + scenario_0.Duration.TotalSeconds) / 1.0);
		int num3 = 0;
		if (newWeapon is BallisticMissile)
		{
			BallisticMissile_Kinematics ballisticMissile_Kinematics = (BallisticMissile_Kinematics)newWeapon.Kinematics;
			if (ballisticMissile_Kinematics.BallisticTrajectory == null)
			{
				ballisticMissile_Kinematics.CustomizeProperty();
				if (ballisticMissile_Kinematics.BallisticTrajectory == null)
				{
					return new TrajectoryPoint[0];
				}
			}
		}
		List<TrajectoryPoint> list = new List<TrajectoryPoint>(capacity);
		bool flag2 = newWeapon.IsWeapon && newWeapon.IsHGV;
		do
		{
			dateTime_ = dateTime_.AddSeconds(num);
			newWeapon.AI.DetermineDesiredAttitudeAndThrottle(num);
			newWeapon.Kinematics.Move(num, bool_0: false, bool_1: true, DateTime.MinValue);
			list.Add(new TrajectoryPoint(newWeapon.GetLongitude(), newWeapon.GetLatitude(), newWeapon.GetCurrentAltitude(), dateTime_));
			if ((flag2 && Module_Unit.MapTokenizer(newWeapon)) || newWeapon.GetCurrentAltitude() == 0f || (newWeapon.GetCurrentAltitude() < (float)Terrain.GlobalMaxTerrainElevation && newWeapon.GetCurrentAltitude() < (float)Terrain.GetElevation(newWeapon.GetLatitude(), newWeapon.GetLongitude(), bool_0: false, scenario_0)) || (newWeapon.Attitude_Pitch < 0f && newWeapon.GetCurrentAltitude() <= newWeapon.ImpactAltitude + 10f) || (newWeapon.IsNuke.Value && newWeapon.Navigator.HasPlottedCourse() && newWeapon.Navigator.PlottedCourse.First().Altitude > 9000f && Module_Unit.RangeToPoint_Horiz(newWeapon, newWeapon.Navigator.PlottedCourse.First().Latitude, newWeapon.Navigator.PlottedCourse.First().Longitude) <= Module_Unit.CalcTokenizer(newWeapon) / 3600f))
			{
				break;
			}
			num3++;
		}
		while (num3 <= num2);
		return list.ToArray();
	}

	private void CustomizeProperty()
	{
		int num = 60;
		Contact contact = base.myWeapon.AI.PrimaryTarget;
		if (contact == null)
		{
			if (base.myWeapon.FiringParent != null && base.myWeapon.GetUnitSide() != null)
			{
				foreach (WeaponSalvo weaponSalvo in base.myWeapon.GetUnitSide().GetWeaponSalvos())
				{
					if (weaponSalvo.ShootersList.Where((WeaponSalvo.Shooter shooter_0) => Operators.CompareString(shooter_0.ShooterObjectID, base.myWeapon.FiringParent.ObjectID, TextCompare: false) == 0).FirstOrDefault() != null)
					{
						contact = weaponSalvo.Target;
					}
				}
			}
			if (contact == null)
			{
				Weapon weapon = base.myWeapon;
				double latitude = base.myWeapon.GetLatitude();
				double longitude = base.myWeapon.GetLongitude();
				float currentAltitude = base.myWeapon.GetCurrentAltitude();
				LockRandom lockRandom_ = GameGeneral.LockRandom_0;
				weapon.Detonate(latitude, longitude, currentAltitude, ref lockRandom_, bool_0: true);
				return;
			}
		}
		double num2 = Math.Max(base.myWeapon.MaxSurfaceRange, base.myWeapon.MaxLandRange);
		if (base.myWeapon.Navigator.PlottedCourse.Count() > 0 && contact.SpeedIsKnown && contact.CurrentSpeed > 0f)
		{
			float num3 = Module_Unit.BearingToPoint_True(base.myWeapon, base.myWeapon.Navigator.PlottedCourse[0].Latitude, base.myWeapon.Navigator.PlottedCourse[0].Longitude);
			Geopoint_Struct geopoint_Struct = MathFunctions.Intersection(base.myWeapon.GetLatitude(), base.myWeapon.GetLongitude(), num3, contact.GetLatitude(), contact.GetLongitude(), contact.CurrentHeading);
			if (!geopoint_Struct.HasZeroCoords)
			{
				contact = new AimpointContact(geopoint_Struct.Latitude, geopoint_Struct.Longitude);
			}
		}
		if (base.myWeapon.InterruptReponse())
		{
			double val = Math.Max(base.myWeapon.MinSurfaceRange, base.myWeapon.MinLandRange);
			double num4 = Math.Max(num2 / 6.0, val);
			double double_ = Math.Max(Module_Unit.RangeToUnit_Horiz(base.myWeapon, contact) / 3f, val);
			float float_ = Module_Unit.BearingToUnit_True(base.myWeapon, contact);
			if (double_ > num4)
			{
				double_ = num4;
			}
			GeoPoint launchPoint = base.myWeapon.LaunchPoint;
			double double_2 = launchPoint.Longitude;
			GeoPoint launchPoint2 = base.myWeapon.LaunchPoint;
			double double_3 = launchPoint2.Latitude;
			double double_4 = 0.0;
			double double_5 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(ref double_2, ref double_3, ref double_4, ref double_5, ref double_, ref float_);
			launchPoint2.Latitude = double_3;
			launchPoint.Longitude = double_2;
			contact = new AimpointContact(double_5, double_4);
			num2 = num4;
		}
		BallisticTrajectory = BallisticTrajectory.Factory(base.myWeapon.LaunchPoint, contact, num2, bool_0: true, num);
	}

	public override void Move(float float_0, bool bool_0, bool bool_1, DateTime dateTime_0)
	{
		try
		{
			base.myWeapon.TimeSinceLaunch = base.myWeapon.TimeSinceLaunch + float_0;
			if (!RevertReader().IsPerformingTerminalManeuvers && myUnit.Sensors_ReadOnly().Count() > 0 && Module_Unit.MapTokenizer(myUnit) && Module_Unit.RangeToUnit_Horiz(RevertReader(), base.myWeapon.AI.PrimaryTarget) < Module_Unit.RangeToPoint_Horiz(RevertReader(), RevertReader().LaunchPoint) && myUnit.Attitude_Pitch < 0f)
			{
				RevertReader().IsPerformingTerminalManeuvers = true;
				base.myWeapon.Type = Weapon._WeaponType.RV;
			}
			if (RevertReader().IsPerformingTerminalManeuvers)
			{
				Move_BoostCoast(float_0, bool_0, bool_1);
				return;
			}
			if (BallisticTrajectory == null)
			{
				CustomizeProperty();
			}
			BallisticTrajectory.BallisticResult ballisticResult_ = BallisticTrajectory.MoveProperty(base.myWeapon.TimeSinceLaunch);
			myUnit.BallisticMovement(ballisticResult_, float_0, bool_1);
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
				if (base.myWeapon.CurrentAltitude_AGL <= 0f && base.myWeapon.Attitude_Pitch <= 0f && !base.myWeapon.clientReader && !base.myWeapon.dicReader)
				{
					Weapon weapon = base.myWeapon;
					double latitude = base.myWeapon.GetLatitude();
					double longitude = base.myWeapon.GetLongitude();
					float float_ = Math.Max(0, (int)Terrain.GetElevation(myUnit.GetLatitude(), myUnit.GetLongitude(), bool_0: false, myUnit.ParentScen));
					LockRandom lockRandom_ = GameGeneral.LockRandom_0;
					weapon.Detonate(latitude, longitude, float_, ref lockRandom_, bool_0: true);
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

	[CompilerGenerated]
	private bool CloneProperty(WeaponSalvo.Shooter shooter_0)
	{
		return Operators.CompareString(shooter_0.ShooterObjectID, base.myWeapon.FiringParent.ObjectID, TextCompare: false) == 0;
	}
}
