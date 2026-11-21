using System;

namespace Command_Core;

public sealed class Str_TemporaryEmission
{
	public DateTime TerminationDate;

	public float SignatureMultiplier;

	public float SignatureAbsoluteIncrease;

	public int Duration;

	public Str_TemporaryEmission(float float_0, float float_1, int int_0, ActiveUnit activeUnit_0)
	{
		SignatureMultiplier = float_0;
		TerminationDate = activeUnit_0.ParentScen.Time;
		TerminationDate.AddSeconds(int_0);
		if (SignatureMultiplier < -1f)
		{
			SignatureMultiplier = 0f;
		}
	}

	internal bool SetSpecification(DateTime dateTime_0)
	{
		if (DateTime.Compare(TerminationDate, dateTime_0) <= 0)
		{
			return false;
		}
		return true;
	}
}
