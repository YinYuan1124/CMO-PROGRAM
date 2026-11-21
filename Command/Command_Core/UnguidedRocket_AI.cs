using System;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class UnguidedRocket_AI : Weapon_AI
{
	public UnguidedRocket_AI(Weapon weapon_0)
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
			float relativeBearing = MathFunctions.GetRelativeBearing(m_EventVal.CurrentHeading, Math2.PublishClass(m_EventVal.GetLatitude(), m_EventVal.GetLongitude(), PrimaryTarget.GetLatitude(), PrimaryTarget.GetLongitude()));
			if (!(315f <= relativeBearing) && !(relativeBearing <= 45f) && m_EventVal.CurrentSpeed > PrimaryTarget.CurrentSpeed)
			{
				Manouver_PurePursuit(float_0, 0f, 0f);
				return;
			}
			if (myWeapon().Guidance == Weapon.WeaponGuidanceType.BeamRiding)
			{
				Manouver_PurePursuit(float_0, 0f, 0f);
				return;
			}
			float? nullable_ = m_EventVal.CurrentSpeed;
			bool bool_ = false;
			Manouver_InterceptCourse(float_0, nullable_, ref bool_);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 1002343214523463564", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
