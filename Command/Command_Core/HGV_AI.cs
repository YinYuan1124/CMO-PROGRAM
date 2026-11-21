using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class HGV_AI : Weapon_AI
{
	public HGV_AI(Weapon weapon_0)
		: base(weapon_0)
	{
	}

	public override void ManouverTowardsTarget(float float_0)
	{
		if (PrimaryTarget == null)
		{
			return;
		}
		try
		{
			_ = m_EventVal.CurrentHeading;
			float num = Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude());
			if (m_EventVal.CurrentHeading != num)
			{
				float relativeBearing = MathFunctions.GetRelativeBearing(m_EventVal.CurrentHeading, Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude()));
				if (!(315f <= relativeBearing) && !(relativeBearing <= 45f) && m_EventVal.CurrentSpeed > PrimaryTarget.CurrentSpeed)
				{
					Manouver_PurePursuit(float_0, 0f, 0f);
					return;
				}
				if (PrimaryTarget.CurrentSpeed == 0f)
				{
					Manouver_PurePursuit(float_0, 0f, 0f);
					return;
				}
				float? nullable_ = m_EventVal.CurrentSpeed;
				bool bool_ = false;
				Manouver_InterceptCourse(float_0, nullable_, ref bool_);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100969", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CalcInvocation()
	{
		if (myWeapon().Navigator.HasPlottedCourse() && myWeapon().Navigator.PlottedCourse[0].Type == Waypoint.WaypointType.TerminalPoint)
		{
			float num = (float)((double)Module_Unit.RangeToPoint_Horiz(myWeapon(), myWeapon().Navigator.PlottedCourse[0]) * 1852.0);
			if ((base.TerminalDive || num <= myWeapon().GetCurrentAltitude()) && PrimaryTarget != null)
			{
				myWeapon().DesiredAltitude = PrimaryTarget.GetCurrentAltitude();
				base.TerminalDive = true;
			}
			else
			{
				myWeapon().DesiredAltitude = (float)((double)myWeapon().CruiseAltitude_ASL * 0.8);
			}
			double num2 = 0.0;
			if (myWeapon().Sensors_Cached != null && myWeapon().Sensors_Cached.Count() > 0)
			{
				num2 = (double)myWeapon().Sensors_Cached.FirstOrDefault().maxRange * 1.5 * 1852.0;
			}
			double num3 = (0.0 - Math.Atan2(myWeapon().GetCurrentAltitude() - myWeapon().DesiredAltitude, (double)num + num2)) * 57.2957795130823;
			myWeapon().DesiredPitch = (float)num3;
		}
		else if (PrimaryTarget == null)
		{
			myWeapon().DesiredPitch = -2f;
		}
		else
		{
			float num4 = (float)((double)Module_Unit.RangeToUnit_Horiz(myWeapon(), PrimaryTarget) * 1852.0);
			if ((base.TerminalDive || num4 <= myWeapon().GetCurrentAltitude()) && PrimaryTarget != null)
			{
				myWeapon().DesiredAltitude = PrimaryTarget.GetCurrentAltitude();
				base.TerminalDive = true;
			}
			else
			{
				myWeapon().DesiredAltitude = (float)((double)myWeapon().CruiseAltitude_ASL * 0.8);
			}
			double num5 = (0.0 - Math.Atan2(myWeapon().GetCurrentAltitude() - myWeapon().DesiredAltitude, num4)) * 57.2957795130823;
			myWeapon().DesiredPitch = (float)num5;
		}
	}

	private void RateInvocation(float float_0)
	{
		try
		{
			DetermineDesiredImpactAltitude();
			if (!Module_Unit.MapTokenizer(myWeapon()) || !(myWeapon().GetCurrentAltitude() <= myWeapon().CruiseAltitude_ASL))
			{
				return;
			}
			CalcInvocation();
			if ((double)myWeapon().GetCurrentAltitude() > (double)myWeapon().CruiseAltitude_ASL * 1.2 && myWeapon().LaunchPoint != null && (double)Module_Unit.RangeToPoint_Horiz(m_EventVal, myWeapon().LaunchPoint) < 539.9568034557235)
			{
				myWeapon().DesiredAltitude = myWeapon().CruiseAltitude_ASL;
				if (myWeapon().DesiredPitch > -30f)
				{
					myWeapon().DesiredPitch = -30f;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100319757711", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void FlushInvocation(float float_0, float float_1)
	{
		if (!base.TerminalDive)
		{
			base.TerminalDive = true;
		}
		if (float_0 < 0f)
		{
			if (Math.Abs(float_0) <= m_EventVal.Kinematics.DiveRate_Nominal())
			{
				m_EventVal.DesiredAltitude = PrimaryTarget.GetCurrentAltitude();
			}
			else
			{
				m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude() - float_1 * m_EventVal.Kinematics.DiveRate_Nominal();
			}
		}
		else if (Math.Abs(float_0) <= m_EventVal.Kinematics.GetClimbRate_Nominal())
		{
			m_EventVal.DesiredAltitude = PrimaryTarget.GetCurrentAltitude();
		}
		else
		{
			m_EventVal.DesiredAltitude = m_EventVal.GetCurrentAltitude() + float_1 * m_EventVal.Kinematics.GetClimbRate_Nominal();
		}
	}

	public override void DetermineDesiredAttitudeAndThrottle(float float_0, bool bool_0 = true)
	{
		try
		{
			if (!myWeapon()._FacadeReader)
			{
				Weapon weapon_ = myWeapon();
				if (!ReadClient(ref weapon_))
				{
					if (m_EventVal.Navigator.HasNonPathfindPlottedCourse())
					{
						m_EventVal.Navigator.FollowPlottedCourse(float_0);
					}
					goto IL_0061;
				}
			}
			ManouverTowardsTarget(float_0);
			goto IL_0061;
			IL_0061:
			RateInvocation(float_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100970", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
