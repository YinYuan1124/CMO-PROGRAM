using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Appearance;

[Serializable]
public struct SurfacePlatformAppearance
{
	[Description("Describes the paint scheme of an entity")]
	public enum PaintSchemeValue : uint
	{
		UniformColor,
		Camouflage
	}

	[Description("Describes characteristics of mobility kills")]
	public enum MobilityValue : uint
	{
		NoMobilityKill,
		MobilityKill
	}

	[Description("Describes the damaged appearance of an entity")]
	public enum DamageValue : uint
	{
		NoDamage,
		SlightDamage,
		ModerateDamage,
		Destroyed
	}

	[Description("Describes status or location of smoke emanating from an entity")]
	public enum SmokeValue : uint
	{
		NotSmoking,
		SmokePlumeRisingFromTheEntity,
		EntityIsEmittingEngineSmoke,
		EntityIsEmittingEngineSmokeAndSmokePlumeIsRisingFromTheEntity
	}

	[Description("Describes the size of the wake trailing effect for the entity.")]
	public enum TrailingEffectsValue : uint
	{
		None,
		Small,
		Medium,
		Large
	}

	[Description("Describes whether Running Lights are on or off.")]
	public enum RunningLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether flames are rising from an entity")]
	public enum FlamingValue : uint
	{
		None,
		FlamesPresent
	}

	[Description("Describes the frozen status of a Surface platform")]
	public enum FrozenStatusValue : uint
	{
		NotFrozen,
		FrozenFrozenEntitiesShouldNotBeDeadReckonedIETheyShouldBeDisplayedAsFixedAtTheCurrentLocationEvenIfNonzeroVelocityAccelerationOrRotationDataIsReceivedFromTheFrozenEntity
	}

	[Description("Describes the power-plant status of platform")]
	public enum PowerPlantStatusValue : uint
	{
		PowerPlantOff,
		PowerPlantOn
	}

	[Description("Describes the state of a Surface platform")]
	public enum StateValue : uint
	{
		Active,
		Deactivated
	}

	[Description("Describes whether Spot Lights are on or off.")]
	public enum SpotLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether Interior Lights are on or off.")]
	public enum InteriorLightsValue : uint
	{
		Off,
		On
	}

	private PaintSchemeValue paintSchemeValue_0;

	private MobilityValue mobilityValue_0;

	private DamageValue damageValue_0;

	private SmokeValue smokeValue_0;

	private TrailingEffectsValue trailingEffectsValue_0;

	private RunningLightsValue runningLightsValue_0;

	private FlamingValue flamingValue_0;

	private FrozenStatusValue frozenStatusValue_0;

	private PowerPlantStatusValue powerPlantStatusValue_0;

	private StateValue stateValue_0;

	private SpotLightsValue spotLightsValue_0;

	private InteriorLightsValue interiorLightsValue_0;

	public PaintSchemeValue PaintScheme
	{
		get
		{
			return paintSchemeValue_0;
		}
		set
		{
			paintSchemeValue_0 = value;
		}
	}

	public MobilityValue Mobility
	{
		get
		{
			return mobilityValue_0;
		}
		set
		{
			mobilityValue_0 = value;
		}
	}

	public DamageValue Damage
	{
		get
		{
			return damageValue_0;
		}
		set
		{
			damageValue_0 = value;
		}
	}

	public SmokeValue Smoke
	{
		get
		{
			return smokeValue_0;
		}
		set
		{
			smokeValue_0 = value;
		}
	}

	public TrailingEffectsValue TrailingEffects
	{
		get
		{
			return trailingEffectsValue_0;
		}
		set
		{
			trailingEffectsValue_0 = value;
		}
	}

	public RunningLightsValue RunningLights
	{
		get
		{
			return runningLightsValue_0;
		}
		set
		{
			runningLightsValue_0 = value;
		}
	}

	public FlamingValue Flaming
	{
		get
		{
			return flamingValue_0;
		}
		set
		{
			flamingValue_0 = value;
		}
	}

	public FrozenStatusValue FrozenStatus
	{
		get
		{
			return frozenStatusValue_0;
		}
		set
		{
			frozenStatusValue_0 = value;
		}
	}

	public PowerPlantStatusValue PowerPlantStatus
	{
		get
		{
			return powerPlantStatusValue_0;
		}
		set
		{
			powerPlantStatusValue_0 = value;
		}
	}

	public StateValue State
	{
		get
		{
			return stateValue_0;
		}
		set
		{
			stateValue_0 = value;
		}
	}

	public SpotLightsValue SpotLights
	{
		get
		{
			return spotLightsValue_0;
		}
		set
		{
			spotLightsValue_0 = value;
		}
	}

	public InteriorLightsValue InteriorLights
	{
		get
		{
			return interiorLightsValue_0;
		}
		set
		{
			interiorLightsValue_0 = value;
		}
	}

	public static bool operator !=(SurfacePlatformAppearance surfacePlatformAppearance_0, SurfacePlatformAppearance surfacePlatformAppearance_1)
	{
		return !(surfacePlatformAppearance_0 == surfacePlatformAppearance_1);
	}

	public static bool operator ==(SurfacePlatformAppearance surfacePlatformAppearance_0, SurfacePlatformAppearance surfacePlatformAppearance_1)
	{
		if ((object)surfacePlatformAppearance_0 == (object)surfacePlatformAppearance_1)
		{
			return true;
		}
		if ((object)surfacePlatformAppearance_0 != null && (object)surfacePlatformAppearance_1 != null)
		{
			return surfacePlatformAppearance_0.Equals(surfacePlatformAppearance_1);
		}
		return false;
	}

	public static explicit operator uint(SurfacePlatformAppearance surfacePlatformAppearance_0)
	{
		return surfacePlatformAppearance_0.ToUInt32();
	}

	public static explicit operator SurfacePlatformAppearance(uint uint_0)
	{
		return smethod_0(uint_0);
	}

	public static SurfacePlatformAppearance FromByteArray(byte[] byte_0, int int_0)
	{
		if (byte_0 == null)
		{
			throw new ArgumentNullException("array");
		}
		if (int_0 < 0 || int_0 > byte_0.Length - 1 || int_0 + 4 > byte_0.Length - 1)
		{
			throw new IndexOutOfRangeException();
		}
		return smethod_0(BitConverter.ToUInt32(byte_0, int_0));
	}

	public static SurfacePlatformAppearance smethod_0(uint uint_0)
	{
		SurfacePlatformAppearance result = default(SurfacePlatformAppearance);
		result.PaintScheme = (PaintSchemeValue)(uint_0 & 1u);
		result.Mobility = (MobilityValue)((uint_0 & 2) >> 1);
		result.Damage = (DamageValue)((uint_0 & 0x18) >> 3);
		result.Smoke = (SmokeValue)((uint_0 & 0x60) >> 5);
		result.TrailingEffects = (TrailingEffectsValue)((uint_0 & 0x180) >> 7);
		result.RunningLights = (RunningLightsValue)((uint_0 & 0x1000) >> 12);
		result.Flaming = (FlamingValue)((uint_0 & 0x8000) >> 15);
		result.FrozenStatus = (FrozenStatusValue)((uint_0 & 0x200000) >> 21);
		result.PowerPlantStatus = (PowerPlantStatusValue)((uint_0 & 0x400000) >> 22);
		result.State = (StateValue)((uint_0 & 0x800000) >> 23);
		result.SpotLights = (SpotLightsValue)((uint_0 & 0x10000000) >> 28);
		result.InteriorLights = (InteriorLightsValue)((uint_0 & 0x20000000) >> 29);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is SurfacePlatformAppearance)
		{
			return Equals((SurfacePlatformAppearance)obj);
		}
		return false;
	}

	public bool Equals(SurfacePlatformAppearance surfacePlatformAppearance_0)
	{
		if ((object)surfacePlatformAppearance_0 == null)
		{
			return false;
		}
		if (PaintScheme == surfacePlatformAppearance_0.PaintScheme && Mobility == surfacePlatformAppearance_0.Mobility && Damage == surfacePlatformAppearance_0.Damage && Smoke == surfacePlatformAppearance_0.Smoke && TrailingEffects == surfacePlatformAppearance_0.TrailingEffects && RunningLights == surfacePlatformAppearance_0.RunningLights && Flaming == surfacePlatformAppearance_0.Flaming && FrozenStatus == surfacePlatformAppearance_0.FrozenStatus && PowerPlantStatus == surfacePlatformAppearance_0.PowerPlantStatus && State == surfacePlatformAppearance_0.State && SpotLights == surfacePlatformAppearance_0.SpotLights)
		{
			return InteriorLights == surfacePlatformAppearance_0.InteriorLights;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return (uint)(PaintSchemeValue.UniformColor | PaintScheme) | ((uint)Mobility << 1) | ((uint)Damage << 3) | ((uint)Smoke << 5) | ((uint)TrailingEffects << 7) | ((uint)RunningLights << 12) | ((uint)Flaming << 15) | ((uint)FrozenStatus << 21) | ((uint)PowerPlantStatus << 22) | ((uint)State << 23) | ((uint)SpotLights << 28) | ((uint)InteriorLights << 29);
	}

	public override int GetHashCode()
	{
		return (((((((((((493 + PaintScheme.GetHashCode()) * 29 + Mobility.GetHashCode()) * 29 + Damage.GetHashCode()) * 29 + Smoke.GetHashCode()) * 29 + TrailingEffects.GetHashCode()) * 29 + RunningLights.GetHashCode()) * 29 + Flaming.GetHashCode()) * 29 + FrozenStatus.GetHashCode()) * 29 + PowerPlantStatus.GetHashCode()) * 29 + State.GetHashCode()) * 29 + SpotLights.GetHashCode()) * 29 + InteriorLights.GetHashCode();
	}
}
