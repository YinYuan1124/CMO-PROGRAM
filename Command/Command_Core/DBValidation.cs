using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class DBValidation
{
	internal static int ManageImporter(int int_0, Scenario scenario_0, bool bool_0)
	{
		Weapon newWeapon = Weapon.GetNewWeapon(ref scenario_0, int_0, bool_0: true);
		ActiveUnit activeUnit;
		if (bool_0)
		{
			Aircraft aircraft = new Aircraft(ref scenario_0);
			aircraft.SetLongitude(null, 0.0);
			aircraft.SetLatitude(null, -60.0);
			aircraft.SetCurrentAltitude(bool_1: false, 10000f);
			aircraft.CurrentSpeed = 660f;
			activeUnit = aircraft;
		}
		else
		{
			Ship ship = new Ship(ref scenario_0);
			ship.SetLongitude(null, 0.0);
			ship.SetLatitude(null, -60.0);
			ship.SetCurrentAltitude(bool_0: false, 0f);
			ship.CurrentSpeed = 0f;
			activeUnit = ship;
		}
		List<int> list = new List<int>();
		if (newWeapon.CalculateReponse())
		{
			float float_ = (float)((double)newWeapon.MaxAirRange * 0.75);
			float num = (bool_0 ? (activeUnit.GetCurrentAltitude() + newWeapon.SnapUpDown) : newWeapon.MaxTargetAlt_ASL);
			float maximumAltitude = newWeapon.Kinematics.GetMaximumAltitude();
			if (num > maximumAltitude)
			{
				num = maximumAltitude - 1f;
			}
			float num2 = 0f;
			double double_ = 0.0;
			double double_2 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(activeUnit.GetLongitude(), activeUnit.GetLatitude(), ref double_, ref double_2, float_, 90);
			Aircraft aircraft2 = new Aircraft(ref scenario_0);
			aircraft2.SetLongitude(null, double_);
			aircraft2.SetLatitude(null, double_2);
			aircraft2.CurrentHeading = num2;
			aircraft2.CurrentSpeed = 0f;
			aircraft2.SetCurrentAltitude(bool_1: false, num);
			int value = RevertImporter(scenario_0, int_0, activeUnit, activeUnit.GetLongitude(), activeUnit.GetLatitude(), activeUnit.GetCurrentAltitude(), (int)Math.Round(activeUnit.CurrentSpeed), aircraft2, double_, double_2, num2, bool_0: true, 0, bool_1: true, aircraft2.GetCurrentAltitude(), bool_2: true, activeUnit.CurrentHeading).Value;
			list.Add(value);
		}
		float num3 = 0f;
		if (newWeapon.ValidTargets.Aircraft)
		{
			num3 = 0.15f;
			float maxAirRange = newWeapon.MaxAirRange;
			float float_2 = ((newWeapon.MaxTargetAlt_ASL < 10972.8f) ? (36000f * newWeapon.MaxTargetAlt_ASL) : 10972.8f);
			float num4 = 270f;
			double double_3 = 0.0;
			double double_4 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(activeUnit.GetLongitude(), activeUnit.GetLatitude(), ref double_3, ref double_4, maxAirRange, 90);
			Aircraft aircraft3 = new Aircraft(ref scenario_0);
			aircraft3.SetLongitude(null, double_3);
			aircraft3.SetLatitude(null, double_4);
			aircraft3.CurrentHeading = num4;
			aircraft3.CurrentSpeed = 660f;
			aircraft3.SetCurrentAltitude(bool_1: false, float_2);
			int value2 = RevertImporter(scenario_0, int_0, activeUnit, activeUnit.GetLongitude(), activeUnit.GetLatitude(), activeUnit.GetCurrentAltitude(), (int)Math.Round(activeUnit.CurrentSpeed), aircraft3, double_3, double_4, num4, bool_0: true, 660, bool_1: true, aircraft3.GetCurrentAltitude(), bool_2: true, activeUnit.CurrentHeading).Value;
			list.Add(value2);
		}
		if (newWeapon.IsASuW_Land || newWeapon.IsASuW_Naval || newWeapon.PrepareReponse())
		{
			num3 = 0.2f;
			float float_3 = Math.Max(Math.Max(newWeapon.MaxSurfaceRange, newWeapon.MaxLandRange), newWeapon.MaxSubsurfaceRange);
			float num5 = 0f;
			double double_5 = 0.0;
			double double_6 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(activeUnit.GetLongitude(), activeUnit.GetLatitude(), ref double_5, ref double_6, float_3, 90);
			Ship ship2 = new Ship(ref scenario_0);
			ship2.SetLongitude(null, double_5);
			ship2.SetLatitude(null, double_6);
			ship2.CurrentHeading = num5;
			ship2.CurrentSpeed = 0f;
			ship2.SetCurrentAltitude(bool_0: false, Math.Max(0, (int)Terrain.GetElevation(ship2.GetLatitude(), ship2.GetLongitude(), bool_0: false, scenario_0)));
			int value3 = RevertImporter(scenario_0, int_0, activeUnit, activeUnit.GetLongitude(), activeUnit.GetLatitude(), activeUnit.GetCurrentAltitude(), (int)Math.Round(activeUnit.CurrentSpeed), ship2, double_5, double_6, num5, bool_0: true, 0, bool_1: true, ship2.GetCurrentAltitude(), bool_2: true, activeUnit.CurrentHeading).Value;
			list.Add(value3);
		}
		return (int)Math.Round((float)list.Max() * (1f + num3));
	}

	private static int? RevertImporter(Scenario scenario_0, int int_0, object object_0, double double_0, double double_1, float float_0, int int_1, ActiveUnit activeUnit_0, double double_2, double double_3, float float_1, bool bool_0, int int_2, bool bool_1, float float_2, bool bool_2, float float_3 = 0f, ActiveUnit.Throttle throttle_0 = ActiveUnit.Throttle.Cruise, ArrayList arrayList_0 = null, ArrayList arrayList_1 = null)
	{
		int? result = null;
		try
		{
			Weapon newWeapon = Weapon.GetNewWeapon(ref scenario_0, int_0, bool_0: true);
			newWeapon._FacadeReader = true;
			newWeapon.FiringParent = (ActiveUnit)object_0;
			if (newWeapon.Flags.SearchPattern)
			{
				newWeapon.Flags.SearchPattern = false;
			}
			newWeapon.SetLongitude(null, double_0);
			newWeapon.SetLatitude(null, double_1);
			newWeapon.SetCurrentAltitude(bool_0: false, float_0);
			newWeapon.CurrentSpeed = int_1;
			if ((int)throttle_0 <= (int)newWeapon.MaxPossibleThrottleSetting)
			{
				newWeapon.SetThrottle(throttle_0);
			}
			else
			{
				newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
			}
			if (float_3 <= 0f)
			{
				newWeapon.CurrentHeading = Math2.PublishClass(double_1, double_0, double_3, double_2);
			}
			else
			{
				newWeapon.CurrentHeading = float_3;
			}
			newWeapon.Fuel_ReadOnly[0].CurrentQuantity = 2.1474836E+09f;
			newWeapon.LaunchPoint = new GeoPoint(newWeapon.GetLongitude(), newWeapon.GetLatitude(), newWeapon.GetCurrentAltitude());
			Contact contact = new Contact(activeUnit_0);
			contact.SetCurrentAltitude(bool_0: false, float_2);
			contact.AltitudeIsKnown = bool_2;
			contact.CurrentSpeed = int_2;
			contact.SpeedIsKnown = bool_1;
			contact.CurrentHeading = float_1;
			contact.HeadingIsKnown = bool_0;
			contact.SetLongitude(null, double_2);
			contact.SetLatitude(null, double_3);
			newWeapon.AI.PrimaryTarget = contact;
			if ((newWeapon.Is_LOAL_capable || newWeapon.Guidance == Weapon.WeaponGuidanceType.Inertial) && !newWeapon.Navigator.CalculateDescriptor(newWeapon.Kinematics.GetMaximumSpeed(contact.GetCurrentAltitude(), throttle_0, bool_0: false), bool_1: false))
			{
				result = null;
				return result;
			}
			newWeapon.FuelConsumption(newWeapon.ThrottleSetting, null, null, null, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false);
			float num = 0f;
			bool flag = false;
			do
			{
				if (contact.CurrentSpeed != 0f)
				{
					double longitude = contact.GetLongitude();
					double latitude = contact.GetLatitude();
					Contact contact2 = contact;
					bool? nullable_ = null;
					double double_4 = contact2.GetLongitude(nullable_);
					Contact contact3 = contact;
					bool? nullable_2 = null;
					double double_5 = contact3.GetLatitude(nullable_2);
					Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_4, ref double_5, contact.CurrentSpeed * 1f / 3600f, contact.CurrentHeading);
					contact3.SetLatitude(nullable_2, double_5);
					contact2.SetLongitude(nullable_, double_4);
					activeUnit_0.SetLongitude(null, contact.GetLongitude());
					activeUnit_0.SetLatitude(null, contact.GetLatitude());
				}
				newWeapon.AI.DetermineDesiredAttitudeAndThrottle(1f);
				if ((int)throttle_0 <= (int)newWeapon.MaxPossibleThrottleSetting)
				{
					newWeapon.SetThrottle(throttle_0);
				}
				else
				{
					newWeapon.SetThrottle(newWeapon.MaxPossibleThrottleSetting);
				}
				newWeapon.Kinematics.Move(1f, bool_0: false, bool_1: true, scenario_0.Time.AddSeconds(num));
				arrayList_0?.Add(Math2.VerifyClass(newWeapon.LaunchPoint.Latitude, newWeapon.LaunchPoint.Longitude, newWeapon.GetLatitude(), newWeapon.GetLongitude()));
				arrayList_1?.Add(newWeapon.GetCurrentAltitude());
				bool flag2 = false;
				if (Module_Unit.RangeToUnit_Horiz((Module_Unit.Unit)object_0, contact) < Module_Unit.RangeToUnit_Horiz((Module_Unit.Unit)object_0, newWeapon))
				{
					flag2 = true;
				}
				if (!flag2 && !newWeapon.AboutToImpact_Contact(1f))
				{
					num += 1f;
					continue;
				}
				double longitude2 = contact.GetLongitude();
				double latitude2 = contact.GetLatitude();
				Contact contact4 = contact;
				bool? nullable_3 = null;
				double double_6 = contact4.GetLongitude(nullable_3);
				Contact contact5 = contact;
				bool? nullable_4 = null;
				double double_7 = contact5.GetLatitude(nullable_4);
				Geodesic_EdWilliams.CalcPoint_Williams(longitude2, latitude2, ref double_6, ref double_7, contact.CurrentSpeed * 1f / 3600f, contact.CurrentHeading);
				contact5.SetLatitude(nullable_4, double_7);
				contact4.SetLongitude(nullable_3, double_6);
				newWeapon.SetLatitude(null, contact.GetLatitude());
				newWeapon.SetLongitude(null, contact.GetLongitude());
				newWeapon.SetCurrentAltitude(bool_0: false, contact.GetCurrentAltitude());
				flag = true;
				break;
			}
			while (num <= 2.1474836E+09f);
			contact = null;
			if (flag)
			{
				result = (int)Math.Round(num + 1f);
				return result;
			}
			result = int.MaxValue;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100324566221", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal static (int BurnTime, int FlightEndurance) CountRepository(int int_0, Scenario scenario_0, bool bool_0)
	{
		Weapon newWeapon = Weapon.GetNewWeapon(ref scenario_0, int_0, bool_0: true);
		ActiveUnit activeUnit;
		if (bool_0)
		{
			Aircraft aircraft = new Aircraft(ref scenario_0);
			aircraft.SetLongitude(null, 0.0);
			aircraft.SetLatitude(null, -60.0);
			aircraft.SetCurrentAltitude(bool_1: false, 10972.8f);
			aircraft.CurrentSpeed = 660f;
			activeUnit = aircraft;
		}
		else
		{
			Ship ship = new Ship(ref scenario_0);
			ship.SetLongitude(null, 0.0);
			ship.SetLatitude(null, -60.0);
			ship.SetCurrentAltitude(bool_0: false, 0f);
			ship.CurrentSpeed = 0f;
			activeUnit = ship;
		}
		if (newWeapon.IsAAW)
		{
			float maxAirRange = newWeapon.MaxAirRange;
			Aircraft aircraft2 = new Aircraft(ref scenario_0);
			float num = 10972.8f;
			float maximumAltitude = newWeapon.Kinematics.GetMaximumAltitude();
			if (num > maximumAltitude)
			{
				num = maximumAltitude - 1f;
			}
			if (newWeapon.MaxTargetAlt_ASL != 0f && newWeapon.MaxTargetAlt_ASL < num)
			{
				num = newWeapon.MaxTargetAlt_ASL - 1f;
			}
			if (newWeapon.SnapUpDown != 0f)
			{
				int num2 = (int)Math.Round(activeUnit.GetCurrentAltitude() + newWeapon.SnapUpDown);
				if ((float)num2 < num)
				{
					num = num2 - 1;
				}
			}
			maxAirRange = newWeapon.MaxAirRange;
			float num3 = 270f;
			double double_ = 0.0;
			double double_2 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(activeUnit.GetLongitude(), activeUnit.GetLatitude(), ref double_, ref double_2, maxAirRange, 90);
			aircraft2.SetLongitude(null, double_);
			aircraft2.SetLatitude(null, double_2);
			aircraft2.CurrentHeading = num3;
			aircraft2.CurrentSpeed = 660f;
			aircraft2.SetCurrentAltitude(bool_1: false, num);
			(int, int) tuple = CustomizeRepository(scenario_0, int_0, activeUnit, activeUnit.GetLongitude(), activeUnit.GetLatitude(), activeUnit.GetCurrentAltitude(), (int)Math.Round(activeUnit.CurrentSpeed), aircraft2, double_, double_2, num3, bool_0: true, 660, bool_1: true, aircraft2.GetCurrentAltitude(), bool_2: true, 0f, Contact_Base.ContactType.Air, activeUnit.CurrentHeading);
			maxAirRange = (newWeapon.CalculateReponse() ? ((float)((double)newWeapon.MaxAirRange * 0.75)) : (newWeapon.MaxAirRange / 10f));
			num = maximumAltitude - 1f;
			if (newWeapon.MaxTargetAlt_ASL != 0f && newWeapon.MaxTargetAlt_ASL < num)
			{
				num = newWeapon.MaxTargetAlt_ASL - 1f;
			}
			if (newWeapon.SnapUpDown != 0f)
			{
				int num4 = (int)Math.Round(activeUnit.GetCurrentAltitude() + newWeapon.SnapUpDown);
				if ((float)num4 < num)
				{
					num = num4 - 1;
				}
			}
			num3 = 270f;
			Geodesic_EdWilliams.CalcPoint_Williams(activeUnit.GetLongitude(), activeUnit.GetLatitude(), ref double_, ref double_2, maxAirRange, 90);
			aircraft2 = new Aircraft(ref scenario_0);
			aircraft2.SetLongitude(null, double_);
			aircraft2.SetLatitude(null, double_2);
			aircraft2.CurrentHeading = num3;
			aircraft2.CurrentSpeed = 0f;
			aircraft2.SetCurrentAltitude(bool_1: false, num);
			(int, int) tuple2 = CustomizeRepository(scenario_0, int_0, activeUnit, activeUnit.GetLongitude(), activeUnit.GetLatitude(), activeUnit.GetCurrentAltitude(), (int)Math.Round(activeUnit.CurrentSpeed), aircraft2, double_, double_2, num3, bool_0: true, 0, bool_1: true, aircraft2.GetCurrentAltitude(), bool_2: true, 0f, Contact_Base.ContactType.Air, activeUnit.CurrentHeading);
			return (BurnTime: Math.Max(tuple.Item1, tuple2.Item1), FlightEndurance: Math.Max(tuple.Item2, tuple2.Item2));
		}
		float float_ = Math.Max(Math.Max(newWeapon.MaxSurfaceRange, newWeapon.MaxLandRange), newWeapon.MaxSubsurfaceRange);
		float num5 = 0f;
		double double_3 = 0.0;
		double double_4 = 0.0;
		Geodesic_EdWilliams.CalcPoint_Williams(activeUnit.GetLongitude(), activeUnit.GetLatitude(), ref double_3, ref double_4, float_, 90);
		Ship ship2 = new Ship(ref scenario_0);
		ship2.SetLongitude(null, double_3);
		ship2.SetLatitude(null, double_4);
		ship2.CurrentHeading = num5;
		ship2.CurrentSpeed = 0f;
		ship2.SetCurrentAltitude(bool_0: false, Math.Max(0, (int)Terrain.GetElevation(ship2.GetLatitude(), ship2.GetLongitude(), bool_0: false, scenario_0)));
		return CustomizeRepository(scenario_0, int_0, activeUnit, activeUnit.GetLongitude(), activeUnit.GetLatitude(), activeUnit.GetCurrentAltitude(), (int)Math.Round(activeUnit.CurrentSpeed), ship2, double_3, double_4, num5, bool_0: true, 0, bool_1: true, ship2.GetCurrentAltitude(), bool_2: true, 0f, Contact_Base.ContactType.Surface, activeUnit.CurrentHeading);
	}

	private static (int, int) CustomizeRepository(Scenario scenario_0, int int_0, ActiveUnit activeUnit_0, double double_0, double double_1, float float_0, int int_1, object object_0, double double_2, double double_3, float float_1, bool bool_0, int int_2, bool bool_1, float float_2, bool bool_2, float float_3, Contact_Base.ContactType contactType_0, float float_4 = 0f, ActiveUnit.Throttle throttle_0 = ActiveUnit.Throttle.Cruise, int? nullable_0 = null, bool bool_3 = false)
	{
		Weapon weapon = scenario_0.Cache_GetWeapon(int_0);
		(int, int) result = default((int, int));
		try
		{
			double num = (float)weapon.Kinematics.GetMaximumSpeed() * weapon.Kinematics.ConcatDescriptor();
			int num2 = Math.Max(1, (int)Math.Round(weapon.MaxRange_NoTargetType / 10f));
			float num3 = 0f;
			GeoPoint geoPoint_ = null;
			string string_ = null;
			while (true)
			{
				if (!nullable_0.HasValue || !(nullable_0.HasValue ? new bool?(num2 >= nullable_0.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					int int_3 = num2;
					float float_5 = 0f;
					Tuple<ActiveUnit_Weaponry.DLZResultEnum, float> tuple = ActiveUnit_Weaponry.TargetIsWithinDLZ_BoostCoast(scenario_0, int_0, activeUnit_0, double_0, double_1, float_0, int_1, double_2, double_3, float_1, bool_0, int_2, bool_1, float_2, bool_2, float_3, contactType_0, ref geoPoint_, ref string_, bool_4: true, bool_5: false, float_4, throttle_0, int_3, null, null, ref float_5, null, null, ActiveUnit_Weaponry.AssumedDLZTargetBehavior.ContinuesAsCurrent, bool_3);
					if (tuple.Item1 == ActiveUnit_Weaponry.DLZResultEnum.Success)
					{
						if (weapon.IsAAW)
						{
							float num4 = geoPoint_.RangeToPoint_Slant(new Geopoint_Struct(double_0, double_1, float_0));
							num3 = tuple.Item2;
							if ((double)(num4 / (num3 / 3600f)) >= num || (float)num2 >= num3)
							{
								break;
							}
						}
						else
						{
							float num5 = geoPoint_.RangeToPoint_Slant(new Geopoint_Struct(double_0, double_1, float_0));
							num3 = tuple.Item2;
							if ((double)(num5 / (num3 / 3600f)) >= num || (float)num2 >= num3)
							{
								break;
							}
						}
					}
					num2++;
					continue;
				}
				result = (num2, (int)Math.Round(num3));
				return result;
			}
			result = ((int)Math.Round((double)num2 * 1.2), (int)Math.Round(num3));
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100324566221", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}
}
