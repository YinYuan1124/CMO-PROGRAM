using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Appearance;

[Serializable]
public struct AirPlatformAppearance
{
	[Description("Describes the paint scheme of an entity")]
	public enum PaintSchemeValue : uint
	{
		UniformColor,
		Camouflage
	}

	[Description("Describes characteristics of Propulsion kill")]
	public enum PropulsionValue : uint
	{
		NoPropulsionKill,
		PropulsionKill
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

	[Description("Describes the size of the contrails or ionization trailing effects from an entity")]
	public enum TrailingEffectsValue : uint
	{
		None,
		Small,
		Medium,
		Large
	}

	[Description("Describes the state of the canopy")]
	public enum CanopyValue : uint
	{
		NotApplicable = 0u,
		CanopyIsClosed = 1u,
		Unknown = 2u,
		CanopyIsOpen = 4u,
		Unknown2 = 5u
	}

	[Description("Describes whether Landing Lights are on or off.")]
	public enum LandingLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether Navigation Lights are on or off.")]
	public enum NavigationLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether Anti-Collision Lights are on or off.")]
	public enum AntiCollisionLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether flames are trailing from an entity")]
	public enum FlamingValue : uint
	{
		None,
		FlamesPresent
	}

	[Description("Describes the status of an air platform's afterburner")]
	public enum AfterburnerValue : uint
	{
		AfterburnerNotOn,
		AfterburnerOn
	}

	[Description("Describes the frozen status of a air platform")]
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

	[Description("Describes the state of a air platform")]
	public enum StateValue : uint
	{
		Active,
		Deactivated
	}

	[Description("Describes whether Formation Lights are on or off.")]
	public enum FormationLightsValue : uint
	{
		Off,
		On
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

	private PropulsionValue propulsionValue_0;

	private DamageValue damageValue_0;

	private SmokeValue smokeValue_0;

	private TrailingEffectsValue trailingEffectsValue_0;

	private CanopyValue canopyValue_0;

	private LandingLightsValue landingLightsValue_0;

	private NavigationLightsValue navigationLightsValue_0;

	private AntiCollisionLightsValue antiCollisionLightsValue_0;

	private FlamingValue flamingValue_0;

	private AfterburnerValue afterburnerValue_0;

	private FrozenStatusValue frozenStatusValue_0;

	private PowerPlantStatusValue powerPlantStatusValue_0;

	private StateValue stateValue_0;

	private FormationLightsValue formationLightsValue_0;

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

	public PropulsionValue Propulsion
	{
		get
		{
			return propulsionValue_0;
		}
		set
		{
			propulsionValue_0 = value;
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

	public CanopyValue Canopy
	{
		get
		{
			return canopyValue_0;
		}
		set
		{
			canopyValue_0 = value;
		}
	}

	public LandingLightsValue LandingLights
	{
		get
		{
			return landingLightsValue_0;
		}
		set
		{
			landingLightsValue_0 = value;
		}
	}

	public NavigationLightsValue NavigationLights
	{
		get
		{
			return navigationLightsValue_0;
		}
		set
		{
			navigationLightsValue_0 = value;
		}
	}

	public AntiCollisionLightsValue AntiCollisionLights
	{
		get
		{
			return antiCollisionLightsValue_0;
		}
		set
		{
			antiCollisionLightsValue_0 = value;
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

	public AfterburnerValue Afterburner
	{
		get
		{
			return afterburnerValue_0;
		}
		set
		{
			afterburnerValue_0 = value;
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

	public FormationLightsValue FormationLights
	{
		get
		{
			return formationLightsValue_0;
		}
		set
		{
			formationLightsValue_0 = value;
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

	public static bool operator !=(AirPlatformAppearance airPlatformAppearance_0, AirPlatformAppearance airPlatformAppearance_1)
	{
		return !(airPlatformAppearance_0 == airPlatformAppearance_1);
	}

	public static bool operator ==(AirPlatformAppearance airPlatformAppearance_0, AirPlatformAppearance airPlatformAppearance_1)
	{
		if ((object)airPlatformAppearance_0 == (object)airPlatformAppearance_1)
		{
			return true;
		}
		if ((object)airPlatformAppearance_0 != null && (object)airPlatformAppearance_1 != null)
		{
			return airPlatformAppearance_0.Equals(airPlatformAppearance_1);
		}
		return false;
	}

	public static explicit operator uint(AirPlatformAppearance airPlatformAppearance_0)
	{
		return airPlatformAppearance_0.ToUInt32();
	}

	public static explicit operator AirPlatformAppearance(uint uint_0)
	{
		return smethod_0(uint_0);
	}

	public static AirPlatformAppearance FromByteArray(byte[] byte_0, int int_0)
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

	public static AirPlatformAppearance smethod_0(uint uint_0)
	{
		AirPlatformAppearance result = default(AirPlatformAppearance);
		result.PaintScheme = (PaintSchemeValue)(uint_0 & 1u);
		result.Propulsion = (PropulsionValue)((uint_0 & 2) >> 1);
		result.Damage = (DamageValue)((uint_0 & 0x18) >> 3);
		result.Smoke = (SmokeValue)((uint_0 & 0x60) >> 5);
		result.TrailingEffects = (TrailingEffectsValue)((uint_0 & 0x180) >> 7);
		result.Canopy = (CanopyValue)((uint_0 & 0xE00) >> 9);
		result.LandingLights = (LandingLightsValue)((uint_0 & 0x1000) >> 12);
		result.NavigationLights = (NavigationLightsValue)((uint_0 & 0x2000) >> 13);
		result.AntiCollisionLights = (AntiCollisionLightsValue)((uint_0 & 0x4000) >> 14);
		result.Flaming = (FlamingValue)((uint_0 & 0x8000) >> 15);
		result.Afterburner = (AfterburnerValue)((uint_0 & 0x10000) >> 16);
		result.FrozenStatus = (FrozenStatusValue)((uint_0 & 0x200000) >> 21);
		result.PowerPlantStatus = (PowerPlantStatusValue)((uint_0 & 0x400000) >> 22);
		result.State = (StateValue)((uint_0 & 0x800000) >> 23);
		result.FormationLights = (FormationLightsValue)((uint_0 & 0x1000000) >> 24);
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
		if (obj is AirPlatformAppearance)
		{
			return Equals((AirPlatformAppearance)obj);
		}
		return false;
	}

	public bool Equals(AirPlatformAppearance airPlatformAppearance_0)
	{
		if ((object)airPlatformAppearance_0 == null)
		{
			return false;
		}
		if (PaintScheme == airPlatformAppearance_0.PaintScheme && Propulsion == airPlatformAppearance_0.Propulsion && Damage == airPlatformAppearance_0.Damage && Smoke == airPlatformAppearance_0.Smoke && TrailingEffects == airPlatformAppearance_0.TrailingEffects && Canopy == airPlatformAppearance_0.Canopy && LandingLights == airPlatformAppearance_0.LandingLights && NavigationLights == airPlatformAppearance_0.NavigationLights && AntiCollisionLights == airPlatformAppearance_0.AntiCollisionLights && Flaming == airPlatformAppearance_0.Flaming && Afterburner == airPlatformAppearance_0.Afterburner && FrozenStatus == airPlatformAppearance_0.FrozenStatus && PowerPlantStatus == airPlatformAppearance_0.PowerPlantStatus && State == airPlatformAppearance_0.State && FormationLights == airPlatformAppearance_0.FormationLights && SpotLights == airPlatformAppearance_0.SpotLights)
		{
			return InteriorLights == airPlatformAppearance_0.InteriorLights;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return (uint)(PaintSchemeValue.UniformColor | PaintScheme) | ((uint)Propulsion << 1) | ((uint)Damage << 3) | ((uint)Smoke << 5) | ((uint)TrailingEffects << 7) | ((uint)Canopy << 9) | ((uint)LandingLights << 12) | ((uint)NavigationLights << 13) | ((uint)AntiCollisionLights << 14) | ((uint)Flaming << 15) | ((uint)Afterburner << 16) | ((uint)FrozenStatus << 21) | ((uint)PowerPlantStatus << 22) | ((uint)State << 23) | ((uint)FormationLights << 24) | ((uint)SpotLights << 28) | ((uint)InteriorLights << 29);
	}

	public override int GetHashCode()
	{
		return ((((((((((((((((493 + PaintScheme.GetHashCode()) * 29 + Propulsion.GetHashCode()) * 29 + Damage.GetHashCode()) * 29 + Smoke.GetHashCode()) * 29 + TrailingEffects.GetHashCode()) * 29 + Canopy.GetHashCode()) * 29 + LandingLights.GetHashCode()) * 29 + NavigationLights.GetHashCode()) * 29 + AntiCollisionLights.GetHashCode()) * 29 + Flaming.GetHashCode()) * 29 + Afterburner.GetHashCode()) * 29 + FrozenStatus.GetHashCode()) * 29 + PowerPlantStatus.GetHashCode()) * 29 + State.GetHashCode()) * 29 + FormationLights.GetHashCode()) * 29 + SpotLights.GetHashCode()) * 29 + InteriorLights.GetHashCode();
	}
}
