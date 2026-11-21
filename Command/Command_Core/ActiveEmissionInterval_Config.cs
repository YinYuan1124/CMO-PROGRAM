using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class ActiveEmissionInterval_Config
{
	public Alertlevels Defcon;

	public bool UseEmissionInterval;

	public bool WakeWhenDetectingThreat;

	public float SleepModeDelay;

	public float EmissionInterval;

	public float EmissionIntervalVariation;

	public float EmissionDuration;

	public bool FollowWRAforWakeBehavior;

	public Dictionary<Misc.PostureStance, bool> Wake_IncludesContactStance;

	public Dictionary<Contact_Base.IdentificationStatus, bool> Wake_IncludesContactID;

	public ActiveEmissionInterval_Config(Alertlevels alertlevels_0, bool bool_0 = true)
	{
		Wake_IncludesContactStance = new Dictionary<Misc.PostureStance, bool>();
		Wake_IncludesContactID = new Dictionary<Contact_Base.IdentificationStatus, bool>();
		Defcon = alertlevels_0;
		UseEmissionInterval = false;
		WakeWhenDetectingThreat = true;
		SleepModeDelay = 0f;
		EmissionInterval = 0f;
		EmissionDuration = 0f;
		EmissionIntervalVariation = 0f;
		Initialise(bool_0);
	}

	public ActiveEmissionInterval_Config(bool bool_0, bool bool_1, bool bool_2, float float_0, float float_1, float float_2)
	{
		Wake_IncludesContactStance = new Dictionary<Misc.PostureStance, bool>();
		Wake_IncludesContactID = new Dictionary<Contact_Base.IdentificationStatus, bool>();
		UseEmissionInterval = bool_0;
		WakeWhenDetectingThreat = bool_2;
		SleepModeDelay = float_0;
		EmissionInterval = float_1;
		EmissionIntervalVariation = float_2;
		Initialise();
	}

	public void Initialise(bool bool_0 = true)
	{
		Array values = Enum.GetValues(typeof(Misc.PostureStance));
		IEnumerator enumerator = null;
		try
		{
			enumerator = values.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
				Wake_IncludesContactStance.Add((Misc.PostureStance)Conversions.ToByte(objectValue), value: false);
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		Enum.GetValues(typeof(Contact_Base.IdentificationStatus));
		IEnumerator enumerator2 = null;
		try
		{
			enumerator2 = values.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				object objectValue2 = RuntimeHelpers.GetObjectValue(enumerator2.Current);
				Wake_IncludesContactID.Add((Contact_Base.IdentificationStatus)Conversions.ToShort(objectValue2), value: false);
			}
		}
		finally
		{
			if (enumerator2 is IDisposable)
			{
				(enumerator2 as IDisposable).Dispose();
			}
		}
		EmissionInterval = 30f;
		EmissionDuration = 30f;
		if (bool_0)
		{
			Wake_IncludesContactStance[Misc.PostureStance.Hostile] = true;
			Wake_IncludesContactStance[Misc.PostureStance.Neutral] = true;
			Wake_IncludesContactStance[Misc.PostureStance.Unfriendly] = true;
			Wake_IncludesContactStance[Misc.PostureStance.Unknown] = true;
			Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownClass] = true;
			Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownDomain] = true;
			Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownType] = true;
			Wake_IncludesContactID[Contact_Base.IdentificationStatus.PreciseID] = true;
			Wake_IncludesContactID[Contact_Base.IdentificationStatus.Unknown] = true;
		}
	}
}
