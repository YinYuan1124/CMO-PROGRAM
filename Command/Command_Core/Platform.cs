using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Command_Core;

public abstract class Platform : ActiveUnit
{
	public delegate void PlatformMagazinesAddedEventHandler(string UnitObjectID, string NewMagObjectID);

	public delegate void PlatformMagazinesRemovedEventHandler(string UnitObjectID, string RemovedMagObjectID);

	public int Crew;

	public Magazine[] Magazines;

	public int AirThreat;

	public int SurfaceThreat;

	public int SubThreat;

	public int StrikeThreat;

	public bool HasLostControlPulse_CACHED;

	[CompilerGenerated]
	private static PlatformMagazinesAddedEventHandler m_ParamsConsumer;

	[CompilerGenerated]
	private static PlatformMagazinesRemovedEventHandler infoConsumer;

	public abstract float FlatSurfaceArea_m2 { get; }

	public abstract bool RepresentsMobileGroundUnit { get; }

	public static event PlatformMagazinesAddedEventHandler PlatformMagazinesAdded
	{
		[CompilerGenerated]
		add
		{
			PlatformMagazinesAddedEventHandler platformMagazinesAddedEventHandler = m_ParamsConsumer;
			PlatformMagazinesAddedEventHandler platformMagazinesAddedEventHandler2;
			do
			{
				platformMagazinesAddedEventHandler2 = platformMagazinesAddedEventHandler;
				PlatformMagazinesAddedEventHandler value2 = (PlatformMagazinesAddedEventHandler)Delegate.Combine(platformMagazinesAddedEventHandler2, value);
				platformMagazinesAddedEventHandler = Interlocked.CompareExchange(ref m_ParamsConsumer, value2, platformMagazinesAddedEventHandler2);
			}
			while ((object)platformMagazinesAddedEventHandler != platformMagazinesAddedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PlatformMagazinesAddedEventHandler platformMagazinesAddedEventHandler = m_ParamsConsumer;
			PlatformMagazinesAddedEventHandler platformMagazinesAddedEventHandler2;
			do
			{
				platformMagazinesAddedEventHandler2 = platformMagazinesAddedEventHandler;
				PlatformMagazinesAddedEventHandler value2 = (PlatformMagazinesAddedEventHandler)Delegate.Remove(platformMagazinesAddedEventHandler2, value);
				platformMagazinesAddedEventHandler = Interlocked.CompareExchange(ref m_ParamsConsumer, value2, platformMagazinesAddedEventHandler2);
			}
			while ((object)platformMagazinesAddedEventHandler != platformMagazinesAddedEventHandler2);
		}
	}

	public static event PlatformMagazinesRemovedEventHandler PlatformMagazinesRemoved
	{
		[CompilerGenerated]
		add
		{
			PlatformMagazinesRemovedEventHandler platformMagazinesRemovedEventHandler = infoConsumer;
			PlatformMagazinesRemovedEventHandler platformMagazinesRemovedEventHandler2;
			do
			{
				platformMagazinesRemovedEventHandler2 = platformMagazinesRemovedEventHandler;
				PlatformMagazinesRemovedEventHandler value2 = (PlatformMagazinesRemovedEventHandler)Delegate.Combine(platformMagazinesRemovedEventHandler2, value);
				platformMagazinesRemovedEventHandler = Interlocked.CompareExchange(ref infoConsumer, value2, platformMagazinesRemovedEventHandler2);
			}
			while ((object)platformMagazinesRemovedEventHandler != platformMagazinesRemovedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PlatformMagazinesRemovedEventHandler platformMagazinesRemovedEventHandler = infoConsumer;
			PlatformMagazinesRemovedEventHandler platformMagazinesRemovedEventHandler2;
			do
			{
				platformMagazinesRemovedEventHandler2 = platformMagazinesRemovedEventHandler;
				PlatformMagazinesRemovedEventHandler value2 = (PlatformMagazinesRemovedEventHandler)Delegate.Remove(platformMagazinesRemovedEventHandler2, value);
				platformMagazinesRemovedEventHandler = Interlocked.CompareExchange(ref infoConsumer, value2, platformMagazinesRemovedEventHandler2);
			}
			while ((object)platformMagazinesRemovedEventHandler != platformMagazinesRemovedEventHandler2);
		}
	}

	public Platform(ref Scenario scenario_0, string string_0 = null)
		: base(ref scenario_0, string_0)
	{
		Magazines = new Magazine[0];
	}

	public bool HasLostControl()
	{
		HasLostControlPulse_CACHED = IsBlinded();
		return HasLostControlPulse_CACHED;
	}

	public bool IsBlinded()
	{
		if (Crew <= 0)
		{
			return false;
		}
		if (base.TemporaryBlindness <= 0f)
		{
			return !Sensory.HasEyeballOperating;
		}
		return true;
	}

	public void AssignToPatrol(Patrol patrol_0)
	{
		Status = _ActiveUnitStatus.OnPatrol;
		Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
		Set_AssignedMissionOrPackage(patrol_0, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
		if (IsAircraft && GetParentGroup() != patrol_0.GetParentGroup(ParentScen))
		{
			SetParentGroup(bool_0: false, patrol_0.GetParentGroup(ParentScen));
		}
	}

	public void RelieveFromPatrol()
	{
		Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
		Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
		Status = _ActiveUnitStatus.Unassigned;
	}

	public void AddSharedMagazine(Magazine magazine_0, bool bool_0 = true)
	{
		ArrayExtensions.Add(ref Magazines, magazine_0);
		magazine_0.ParentPlatform = this;
		if (bool_0)
		{
			m_ParamsConsumer?.Invoke(ObjectID, magazine_0.ObjectID);
		}
	}

	public void RemoveSharedMagazine(Magazine magazine_0)
	{
		ArrayExtensions.Remove(ref Magazines, magazine_0);
		magazine_0.ParentPlatform = null;
		infoConsumer?.Invoke(ObjectID, magazine_0.ObjectID);
	}

	public void ResolveDamageFromDazzler(float float_0)
	{
		if (Crew > 0)
		{
			base.TemporaryBlindness += (float_0 + 0.05f) * 240f;
		}
	}
}
