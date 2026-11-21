using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Torpedo_AI : Weapon_AI
{
	public override Contact PrimaryTarget
	{
		get
		{
			return _PrimaryTarget;
		}
		set
		{
			try
			{
				if (value != _PrimaryTarget && !Information.IsNothing(_PrimaryTarget) && value == null)
				{
					_LastKnownTargetLocation = new GeoPoint(_PrimaryTarget.GetLongitude(), _PrimaryTarget.GetLatitude(), _PrimaryTarget.GetCurrentAltitude());
				}
				_PrimaryTarget = value;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100965", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public Torpedo_AI(Weapon weapon_0)
		: base(weapon_0)
	{
	}

	public override void DetermineDesiredAttitudeAndThrottle(float float_0, bool bool_0 = true)
	{
		try
		{
			if (!(myWeapon().BlindTime <= 0f) || !(myWeapon().AddDescriptor() <= 0f))
			{
				return;
			}
			Weapon weapon_ = myWeapon();
			if (ReadClient(ref weapon_))
			{
				DetermineDesiredAltitude(float_0);
				if (!Information.IsNothing(PrimaryTarget) && PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint && PrimaryTarget.Type != Contact_Base.ContactType.ActivationPoint)
				{
					PrimaryTarget_LastKnown_Lat = PrimaryTarget.GetLatitude();
					PrimaryTarget_LastKnown_Lon = PrimaryTarget.GetLongitude();
					PrimaryTarget_LastKnown_Altitude = PrimaryTarget.GetCurrentAltitude();
				}
				if (m_EventVal.Navigator.HasNonPathfindPlottedCourse() && !Information.IsNothing(myWeapon().DataLinkParent))
				{
					if (PrimaryTarget.SpeedIsKnown && PrimaryTarget.CurrentSpeed > 0f)
					{
						switch (myWeapon().Guidance)
						{
						case Weapon.WeaponGuidanceType.Datalink_Plus_SemiActive:
						case Weapon.WeaponGuidanceType.DataLink_Plus_Passive:
						case Weapon.WeaponGuidanceType.Datalink_Plus_Active:
						case Weapon.WeaponGuidanceType.SemiActive_Plus_Active:
							((Weapon_Navigator)m_EventVal.Navigator).CalculateDescriptor(m_EventVal.Kinematics.GetMaximumSpeed(m_EventVal.GetCurrentAltitude(), m_EventVal.MaxPossibleThrottleSetting, bool_0: false), !Information.IsNothing(myWeapon().DataLinkParent) && myWeapon().DataLinkParent.IsAircraft);
							break;
						}
					}
					m_EventVal.Navigator.FollowPlottedCourse(float_0);
					if (Module_Unit.RangeToUnit_Horiz(myWeapon(), PrimaryTarget.ActualUnit) < 2f)
					{
						FindWatcher();
					}
				}
				else if (m_EventVal.Navigator.HasPlottedCourse())
				{
					m_EventVal.Navigator.FollowPlottedCourse(float_0);
				}
				else
				{
					if (!Information.IsNothing(PrimaryTarget) && PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint)
					{
						return;
					}
					if (myWeapon().Guidance == Weapon.WeaponGuidanceType.Inertial)
					{
						if (!Information.IsNothing(PrimaryTarget))
						{
							myWeapon().Navigator.AddWaypoint(new Waypoint(PrimaryTarget.GetLongitude(), PrimaryTarget.GetLatitude(), 0f, Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
						}
						return;
					}
					ManouverTowardsTarget(float_0);
					if (Module_Unit.RangeToUnit_Horiz(myWeapon(), PrimaryTarget.ActualUnit) < 2f)
					{
						FindWatcher();
					}
				}
			}
			else if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
			{
				m_EventVal.Navigator.FollowPlottedCourse(float_0);
				DetermineDesiredAltitude(float_0);
			}
			else
			{
				if (myWeapon().Guidance == Weapon.WeaponGuidanceType.Inertial)
				{
					return;
				}
				if (myWeapon().Flags.SearchPattern)
				{
					if (PrimaryTarget != null && PrimaryTarget.ActualUnit != null && !PrimaryTarget.ActualUnit.IsFixedFacility)
					{
						if (myWeapon().SearchPatternType == Weapon.WeaponSearchPatternType.Circle)
						{
							CircleSearch(float_0);
						}
						else if (myWeapon().SearchPatternType == Weapon.WeaponSearchPatternType.Snake)
						{
							SnakeSearch();
						}
						else
						{
							m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, m_EventVal.CurrentHeading);
						}
					}
					else if (myWeapon().ValidTargets.Mine)
					{
						SnakeSearch();
					}
					else if (!myWeapon().Navigator.HasPlottedCourse() && myWeapon().Flags.SearchPattern && myWeapon().SearchPatternType == Weapon.WeaponSearchPatternType.Circle)
					{
						CircleSearch(float_0);
					}
					else if (!myWeapon().Navigator.HasPlottedCourse() && myWeapon().Flags.SearchPattern && myWeapon().SearchPatternType == Weapon.WeaponSearchPatternType.Snake)
					{
						SnakeSearch();
					}
					else if (!Information.IsNothing(PrimaryTarget) && !Information.IsNothing(PrimaryTarget.ActualUnit) && PrimaryTarget.ActualUnit.IsFixedFacility)
					{
						m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, BearingToUnit_True(PrimaryTarget));
					}
					else
					{
						m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, m_EventVal.CurrentHeading);
					}
				}
				else if (Information.IsNothing(PrimaryTarget))
				{
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, m_EventVal.CurrentHeading);
				}
				else if (Information.IsNothing(PrimaryTarget.ActualUnit))
				{
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, BearingToUnit_True(PrimaryTarget));
				}
				else if (myWeapon().clientReader)
				{
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, m_EventVal.CurrentHeading);
				}
				else
				{
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, BearingToUnit_NextSecond(PrimaryTarget.ActualUnit));
				}
				DetermineDesiredAltitude(float_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10398777441", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool GuidanceLogic_DestroyedOrVanishedPrimaryTarget(float float_0)
	{
		try
		{
			if (!myWeapon().myTargetDoesNotExist() && !PrimaryTarget.GetIsDestroyed(myWeapon().ParentScen))
			{
				if (PrimaryTarget.Age > 30f && PrimaryTarget.IsAir_Missile_Orbital_Contact && !myWeapon().Navigator.HasNonPathfindPlottedCourse())
				{
					if (!myWeapon().HasGoneAutonomous)
					{
						myWeapon().StopReponse(bool_0: true, bool_1: true);
						myWeapon().AddMessage("武器：" + myWeapon().Name + "没有收到来自父单元的确切目标更新...自主决策。", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(myWeapon().GetLongitude(), myWeapon().GetLatitude()));
					}
					return true;
				}
				if (!(PrimaryTarget.Age <= 1200f) && !myWeapon().Navigator.HasNonPathfindPlottedCourse() && !myWeapon().HasGoneAutonomous)
				{
					myWeapon().StopReponse(bool_0: true, bool_1: true);
					myWeapon().AddMessage("武器：" + myWeapon().Name + "没有收到来自父单元的确切目标更新...自主决策。", "武器问题", LoggedMessage.MessageType.WeaponLogic, 10, bool_0: false, new Geopoint_Struct(myWeapon().GetLongitude(), myWeapon().GetLatitude()));
					return true;
				}
				return false;
			}
			if (myWeapon().Navigator.HasNonPathfindPlottedCourse())
			{
				myWeapon().DatalinkRetargetTime = 0f;
				return false;
			}
			float float_ = 60f;
			if (myWeapon().DataLinkParent != null)
			{
				float_ = 180f;
			}
			myWeapon().AttemptRetargeting_Datalink(float_0, float_);
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100935", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private void FindWatcher()
	{
		try
		{
			if ((int)m_EventVal.MaxPossibleThrottleSetting <= 2 || (int)m_EventVal.ThrottleSetting >= 3)
			{
				return;
			}
			float num = m_EventVal.FuelConsumption(ActiveUnit.Throttle.Cruise, null, null, null, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false);
			if (num <= 0f)
			{
				num = 1f;
			}
			float num2 = m_EventVal.FuelConsumption(ActiveUnit.Throttle.Full, null, null, null, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false);
			if (num2 <= 0f)
			{
				num2 = 1f;
			}
			float num3 = 0f;
			foreach (FuelRec item in m_EventVal.Fuel_ReadOnly)
			{
				num3 += item.CurrentQuantity;
			}
			float num4 = 0.75f;
			num3 = num3 * (num / num2) * num4;
			if (m_EventVal.ETA_To_Location(Module_Unit.ClosureSpeed(m_EventVal, PrimaryTarget, m_EventVal.Kinematics.GetMaximumSpeed(m_EventVal.GetCurrentAltitude(), ActiveUnit.Throttle.Full, bool_0: false), m_EventVal.CurrentHeading), Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget)) < num3)
			{
				m_EventVal.SetThrottle(ActiveUnit.Throttle.Full);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100972", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected override void SnakeSearch()
	{
		try
		{
			MaxSnakeAngle = 15;
			if (Information.IsNothing(SnakeAxis))
			{
				if (Information.IsNothing(PrimaryTarget))
				{
					SnakeAxis = m_EventVal.CurrentHeading;
				}
				else
				{
					SnakeAxis = Math2.PublishClass(myWeapon().GetLatitude(), myWeapon().GetLongitude(), PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude());
				}
			}
			if (Information.IsNothing(SnakeDirection))
			{
				SnakeDirection = (_SnakeDirection)GameGeneral.LockRandom_0.Next(0, 1);
			}
			float float_ = Math2.UpdateClass(SnakeAxis.Value - (float)MaxSnakeAngle);
			float float_2 = Math2.UpdateClass(SnakeAxis.Value + (float)MaxSnakeAngle);
			_SnakeDirection? snakeDirection = SnakeDirection;
			byte? b = (byte?)snakeDirection;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				if (Math.Abs(MathFunctions.DeleteRequest(m_EventVal.CurrentHeading, SnakeAxis.Value)) < (float)MaxSnakeAngle)
				{
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, float_);
					return;
				}
				SnakeDirection = _SnakeDirection.Right;
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, float_2);
				return;
			}
			b = (byte?)snakeDirection;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				if (Math.Abs(MathFunctions.DeleteRequest(m_EventVal.CurrentHeading, SnakeAxis.Value)) < (float)MaxSnakeAngle)
				{
					m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, float_2);
					return;
				}
				SnakeDirection = _SnakeDirection.Left;
				m_EventVal.SetDesiredHeading(ActiveUnit.TurnRate.Max, float_);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100968", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void DetermineDesiredAltitude(float float_0)
	{
		try
		{
			if (!myWeapon().Navigator.HasPlottedCourse())
			{
				if (Information.IsNothing(PrimaryTarget))
				{
					if (myWeapon().Flags.SearchPattern && myWeapon().SearchPatternType == Weapon.WeaponSearchPatternType.Circle)
					{
						myWeapon().DesiredAltitude += -2f * float_0;
					}
				}
				else
				{
					Weapon weapon_ = myWeapon();
					if (!ReadClient(ref weapon_) && myWeapon().Flags.SearchPattern && myWeapon().SearchPatternType == Weapon.WeaponSearchPatternType.Circle)
					{
						if (PrimaryTarget.AltitudeIsKnown && (double)myWeapon().GetCurrentAltitude() > (double)PrimaryTarget.GetCurrentAltitude() * 0.7)
						{
							myWeapon().DesiredAltitude = PrimaryTarget.GetCurrentAltitude();
						}
						else if (!PrimaryTarget.AltitudeIsKnown && myWeapon().GetCurrentAltitude() > -40f)
						{
							myWeapon().DesiredAltitude = -40f;
						}
						else
						{
							myWeapon().DesiredAltitude += -2f * float_0;
						}
					}
					else if (PrimaryTarget.AltitudeIsKnown)
					{
						if (Information.IsNothing(PrimaryTarget))
						{
							return;
						}
						Geopoint_Struct geopoint_Struct_ = default(Geopoint_Struct);
						float num;
						if (PrimaryTarget.CurrentSpeed == 0f)
						{
							num = Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget);
						}
						else
						{
							float float_ = (myWeapon().SupportsAttitude_Pitch ? ((float)((double)myWeapon().Kinematics.GetMaximumSpeed() * 0.5)) : ((float)myWeapon().Kinematics.GetMaximumSpeed()));
							geopoint_Struct_ = myWeapon().Navigator.ComputeInterceptPoint_BruteForce(float_, PrimaryTarget, null);
							num = (geopoint_Struct_.HasZeroCoords ? Module_Unit.RangeToUnit_Horiz(m_EventVal, PrimaryTarget) : Module_Unit.RangeToPoint_Horiz(myWeapon(), geopoint_Struct_));
						}
						if (myWeapon().SupportsAttitude_Pitch)
						{
							myWeapon().DesiredAltitude = PrimaryTarget.GetCurrentAltitude();
							if (geopoint_Struct_.HasZeroCoords)
							{
								CalculateDesiredPitch(PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude(), PrimaryTarget.GetCurrentAltitude());
							}
							else
							{
								CalculateDesiredPitch(geopoint_Struct_.Latitude, geopoint_Struct_.Longitude, geopoint_Struct_.Altitude);
							}
						}
						else
						{
							float num2 = m_EventVal.CurrentSpeed * float_0 / 3600f;
							float num3 = PrimaryTarget.GetCurrentAltitude() - m_EventVal.GetCurrentAltitude();
							if (num3 < 0f)
							{
								m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude() - num2 * Math.Abs(num3) / num;
							}
							else
							{
								m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude() + num2 * Math.Abs(num3) / num;
							}
						}
					}
				}
			}
			if (m_EventVal.DesiredAltitude > -10f)
			{
				myWeapon().DesiredAltitude = -10f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
