using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Appearance;

[Serializable]
public struct SubsurfacePlatformAppearance
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
		Unknown
	}

	[Description("Describes the state of the hatch")]
	public enum HatchValue : uint
	{
		NotApplicable = 0u,
		HatchIsClosed = 1u,
		Unknown = 2u,
		HatchIsOpen = 4u,
		Unknown2 = 5u
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

	[Description("Describes the frozen status of a subsurface platform")]
	public enum FrozenStatusValue : uint
	{
		NotFrozen,
		FrozenFrozenEntitiesShouldNotBeDeadReckonedIETheyShouldBeDisplayedAsFixedAtTheCurrentLocationEvenIfNonzeroVelocityAccelerationOrRotationDataIsReceivedFromTheFrozenEntity
	}

	[Description("Describes the power-plant status of a subsurface platform")]
	public enum PowerPlantStatusValue : uint
	{
		PowerPlantOff,
		PowerPlantOn
	}

	[Description("Describes the state of a subsurface platform")]
	public enum StateValue : uint
	{
		Active,
		Deactivated
	}

	private PaintSchemeValue paintSchemeValue_0;

	private MobilityValue mobilityValue_0;

	private DamageValue damageValue_0;

	private SmokeValue smokeValue_0;

	private HatchValue hatchValue_0;

	private RunningLightsValue runningLightsValue_0;

	private FlamingValue flamingValue_0;

	private FrozenStatusValue frozenStatusValue_0;

	private PowerPlantStatusValue powerPlantStatusValue_0;

	private StateValue stateValue_0;

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

	public HatchValue Hatch
	{
		get
		{
			return hatchValue_0;
		}
		set
		{
			hatchValue_0 = value;
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

	public static bool operator !=(SubsurfacePlatformAppearance subsurfacePlatformAppearance_0, SubsurfacePlatformAppearance subsurfacePlatformAppearance_1)
	{
		return !(subsurfacePlatformAppearance_0 == subsurfacePlatformAppearance_1);
	}

	public static bool operator ==(SubsurfacePlatformAppearance subsurfacePlatformAppearance_0, SubsurfacePlatformAppearance subsurfacePlatformAppearance_1)
	{
		if ((object)subsurfacePlatformAppearance_0 == (object)subsurfacePlatformAppearance_1)
		{
			return true;
		}
		if ((object)subsurfacePlatformAppearance_0 != null && (object)subsurfacePlatformAppearance_1 != null)
		{
			return subsurfacePlatformAppearance_0.Equals(subsurfacePlatformAppearance_1);
		}
		return false;
	}

	public static explicit operator uint(SubsurfacePlatformAppearance subsurfacePlatformAppearance_0)
	{
		return subsurfacePlatformAppearance_0.ToUInt32();
	}

	public static explicit operator SubsurfacePlatformAppearance(uint uint_0)
	{
		return smethod_0(uint_0);
	}

	public static SubsurfacePlatformAppearance FromByteArray(byte[] byte_0, int int_0)
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

	public static SubsurfacePlatformAppearance smethod_0(uint uint_0)
	{
		SubsurfacePlatformAppearance result = default(SubsurfacePlatformAppearance);
		result.PaintScheme = (PaintSchemeValue)(uint_0 & 1u);
		result.Mobility = (MobilityValue)((uint_0 & 2) >> 1);
		result.Damage = (DamageValue)((uint_0 & 0x18) >> 3);
		result.Smoke = (SmokeValue)((uint_0 & 0x60) >> 5);
		result.Hatch = (HatchValue)((uint_0 & 0xE00) >> 9);
		result.RunningLights = (RunningLightsValue)((uint_0 & 0x1000) >> 12);
		result.Flaming = (FlamingValue)((uint_0 & 0x8000) >> 15);
		result.FrozenStatus = (FrozenStatusValue)((uint_0 & 0x200000) >> 21);
		result.PowerPlantStatus = (PowerPlantStatusValue)((uint_0 & 0x400000) >> 22);
		result.State = (StateValue)((uint_0 & 0x800000) >> 23);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is SubsurfacePlatformAppearance)
		{
			return Equals((SubsurfacePlatformAppearance)obj);
		}
		return false;
	}

	public bool Equals(SubsurfacePlatformAppearance subsurfacePlatformAppearance_0)
	{
		if ((object)subsurfacePlatformAppearance_0 == null)
		{
			return false;
		}
		if (PaintScheme == subsurfacePlatformAppearance_0.PaintScheme && Mobility == subsurfacePlatformAppearance_0.Mobility && Damage == subsurfacePlatformAppearance_0.Damage && Smoke == subsurfacePlatformAppearance_0.Smoke && Hatch == subsurfacePlatformAppearance_0.Hatch && RunningLights == subsurfacePlatformAppearance_0.RunningLights && Flaming == subsurfacePlatformAppearance_0.Flaming && FrozenStatus == subsurfacePlatformAppearance_0.FrozenStatus && PowerPlantStatus == subsurfacePlatformAppearance_0.PowerPlantStatus)
		{
			return State == subsurfacePlatformAppearance_0.State;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return (uint)(PaintSchemeValue.UniformColor | PaintScheme) | ((uint)Mobility << 1) | ((uint)Damage << 3) | ((uint)Smoke << 5) | ((uint)Hatch << 9) | ((uint)RunningLights << 12) | ((uint)Flaming << 15) | ((uint)FrozenStatus << 21) | ((uint)PowerPlantStatus << 22) | ((uint)State << 23);
	}

	public override int GetHashCode()
	{
		return (((((((((493 + PaintScheme.GetHashCode()) * 29 + Mobility.GetHashCode()) * 29 + Damage.GetHashCode()) * 29 + Smoke.GetHashCode()) * 29 + Hatch.GetHashCode()) * 29 + RunningLights.GetHashCode()) * 29 + Flaming.GetHashCode()) * 29 + FrozenStatus.GetHashCode()) * 29 + PowerPlantStatus.GetHashCode()) * 29 + State.GetHashCode();
	}
}
