using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Appearance;

[Serializable]
public struct LandPlatformAppearance
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

	[Description("Describes characteristics of fire-power kill")]
	public enum FirePowerValue : uint
	{
		NoFirePowerKill,
		FirePowerKill
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

	[Description("Describes the size of the dust cloud trailing effect for the Effects entity")]
	public enum TrailingEffectsValue : uint
	{
		None,
		Small,
		Medium,
		Large
	}

	[Description("Describes the state of the primary hatch")]
	public enum HatchValue : uint
	{
		NotApplicable,
		PrimaryHatchIsClosed,
		PrimaryHatchIsPopped,
		PrimaryHatchIsPoppedAndAPersonIsVisibleUnderHatch,
		PrimaryHatchIsOpen,
		PrimaryHatchIsOpenAndPersonIsVisible,
		Unknown
	}

	[Description("Describes whether Head Lights are on or off.")]
	public enum HeadLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether Tail Lights are on or off.")]
	public enum TailLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether Brake Lights are on or off.")]
	public enum BrakeLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether flames are rising from an entity")]
	public enum FlamingValue : uint
	{
		Off,
		On
	}

	[Description("Describes the elevated status of the platform's primary launcher")]
	public enum LauncherValue : uint
	{
		Off,
		On
	}

	[Description("Describes the type of camouflage")]
	public enum CamouflageTypeValue : uint
	{
		DesertCamouflage,
		WinterCamouflage,
		ForestCamouflage,
		Unknown
	}

	[Description("Describes the type of concealment")]
	public enum ConcealedValue : uint
	{
		NotConcealed,
		EntityInAPreparedConcealedPositionWithNettingEtc
	}

	[Description("Describes the frozen status of a Land Entity")]
	public enum FrozenStatusValue : uint
	{
		NotFrozen,
		FrozenFrozenEntitiesShouldNotBeDeadReckonedIEShouldBeDisplayedAsFixedAtTheCurrentLocationEvenIfNonZeroVelocityAccelerationOrRotationDataReceivedFromTheFrozenEntity
	}

	[Description("Describes the power-plant status of platform")]
	public enum PowerPlantStatusValue : uint
	{
		PowerPlantOff,
		PowerPlantOn
	}

	[Description("Describes the state of a Land Entity")]
	public enum StateValue : uint
	{
		Active,
		Deactivated
	}

	[Description("Describes the status of a tent extension")]
	public enum TentValue : uint
	{
		NotExtended,
		Extended
	}

	[Description("Describes the status of a ramp")]
	public enum RampValue : uint
	{
		Up,
		Down
	}

	[Description("Describes whether Blackout Lights are on or off.")]
	public enum BlackoutLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether Blackout Brake Lights are on or off.")]
	public enum BlackoutBrakeLightsValue : uint
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

	[Description("Describes the surrender state of the vehicle occupants")]
	public enum SurrenderStateValue : uint
	{
		NotSurrendered,
		Surrender
	}

	[Description("Describes if the entity is Masked / Cloaked or Not")]
	public enum MaskedCloakedValue : uint
	{
		NotMaskedNotCloaked,
		MaskedCloaked
	}

	private PaintSchemeValue paintSchemeValue_0;

	private MobilityValue mobilityValue_0;

	private FirePowerValue firePowerValue_0;

	private DamageValue damageValue_0;

	private SmokeValue smokeValue_0;

	private TrailingEffectsValue trailingEffectsValue_0;

	private HatchValue hatchValue_0;

	private HeadLightsValue headLightsValue_0;

	private TailLightsValue tailLightsValue_0;

	private BrakeLightsValue brakeLightsValue_0;

	private FlamingValue flamingValue_0;

	private LauncherValue launcherValue_0;

	private CamouflageTypeValue camouflageTypeValue_0;

	private ConcealedValue concealedValue_0;

	private FrozenStatusValue frozenStatusValue_0;

	private PowerPlantStatusValue powerPlantStatusValue_0;

	private StateValue stateValue_0;

	private TentValue tentValue_0;

	private RampValue rampValue_0;

	private BlackoutLightsValue blackoutLightsValue_0;

	private BlackoutBrakeLightsValue blackoutBrakeLightsValue_0;

	private SpotLightsValue spotLightsValue_0;

	private InteriorLightsValue interiorLightsValue_0;

	private SurrenderStateValue surrenderStateValue_0;

	private MaskedCloakedValue maskedCloakedValue_0;

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

	public FirePowerValue FirePower
	{
		get
		{
			return firePowerValue_0;
		}
		set
		{
			firePowerValue_0 = value;
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

	public HeadLightsValue HeadLights
	{
		get
		{
			return headLightsValue_0;
		}
		set
		{
			headLightsValue_0 = value;
		}
	}

	public TailLightsValue TailLights
	{
		get
		{
			return tailLightsValue_0;
		}
		set
		{
			tailLightsValue_0 = value;
		}
	}

	public BrakeLightsValue BrakeLights
	{
		get
		{
			return brakeLightsValue_0;
		}
		set
		{
			brakeLightsValue_0 = value;
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

	public LauncherValue Launcher
	{
		get
		{
			return launcherValue_0;
		}
		set
		{
			launcherValue_0 = value;
		}
	}

	public CamouflageTypeValue CamouflageType
	{
		get
		{
			return camouflageTypeValue_0;
		}
		set
		{
			camouflageTypeValue_0 = value;
		}
	}

	public ConcealedValue Concealed
	{
		get
		{
			return concealedValue_0;
		}
		set
		{
			concealedValue_0 = value;
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

	public TentValue Tent
	{
		get
		{
			return tentValue_0;
		}
		set
		{
			tentValue_0 = value;
		}
	}

	public RampValue Ramp
	{
		get
		{
			return rampValue_0;
		}
		set
		{
			rampValue_0 = value;
		}
	}

	public BlackoutLightsValue BlackoutLights
	{
		get
		{
			return blackoutLightsValue_0;
		}
		set
		{
			blackoutLightsValue_0 = value;
		}
	}

	public BlackoutBrakeLightsValue BlackoutBrakeLights
	{
		get
		{
			return blackoutBrakeLightsValue_0;
		}
		set
		{
			blackoutBrakeLightsValue_0 = value;
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

	public SurrenderStateValue SurrenderState
	{
		get
		{
			return surrenderStateValue_0;
		}
		set
		{
			surrenderStateValue_0 = value;
		}
	}

	public MaskedCloakedValue MaskedCloaked
	{
		get
		{
			return maskedCloakedValue_0;
		}
		set
		{
			maskedCloakedValue_0 = value;
		}
	}

	public static bool operator !=(LandPlatformAppearance landPlatformAppearance_0, LandPlatformAppearance landPlatformAppearance_1)
	{
		return !(landPlatformAppearance_0 == landPlatformAppearance_1);
	}

	public static bool operator ==(LandPlatformAppearance landPlatformAppearance_0, LandPlatformAppearance landPlatformAppearance_1)
	{
		if ((object)landPlatformAppearance_0 == (object)landPlatformAppearance_1)
		{
			return true;
		}
		if ((object)landPlatformAppearance_0 != null && (object)landPlatformAppearance_1 != null)
		{
			return landPlatformAppearance_0.Equals(landPlatformAppearance_1);
		}
		return false;
	}

	public static explicit operator uint(LandPlatformAppearance landPlatformAppearance_0)
	{
		return landPlatformAppearance_0.ToUInt32();
	}

	public static explicit operator LandPlatformAppearance(uint uint_0)
	{
		return smethod_0(uint_0);
	}

	public static LandPlatformAppearance FromByteArray(byte[] byte_0, int int_0)
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

	public static LandPlatformAppearance smethod_0(uint uint_0)
	{
		LandPlatformAppearance result = default(LandPlatformAppearance);
		result.PaintScheme = (PaintSchemeValue)(uint_0 & 1u);
		result.Mobility = (MobilityValue)((uint_0 & 2) >> 1);
		result.FirePower = (FirePowerValue)((uint_0 & 4) >> 2);
		result.Damage = (DamageValue)((uint_0 & 0x18) >> 3);
		result.Smoke = (SmokeValue)((uint_0 & 0x60) >> 5);
		result.TrailingEffects = (TrailingEffectsValue)((uint_0 & 0x180) >> 7);
		result.Hatch = (HatchValue)((uint_0 & 0xE00) >> 9);
		result.HeadLights = (HeadLightsValue)((uint_0 & 0x1000) >> 12);
		result.TailLights = (TailLightsValue)((uint_0 & 0x2000) >> 13);
		result.BrakeLights = (BrakeLightsValue)((uint_0 & 0x4000) >> 14);
		result.Flaming = (FlamingValue)((uint_0 & 0x8000) >> 15);
		result.Launcher = (LauncherValue)((uint_0 & 0x10000) >> 16);
		result.CamouflageType = (CamouflageTypeValue)((uint_0 & 0x60000) >> 17);
		result.Concealed = (ConcealedValue)((uint_0 & 0x80000) >> 19);
		result.FrozenStatus = (FrozenStatusValue)((uint_0 & 0x200000) >> 21);
		result.PowerPlantStatus = (PowerPlantStatusValue)((uint_0 & 0x400000) >> 22);
		result.State = (StateValue)((uint_0 & 0x800000) >> 23);
		result.Tent = (TentValue)((uint_0 & 0x1000000) >> 24);
		result.Ramp = (RampValue)((uint_0 & 0x2000000) >> 25);
		result.BlackoutLights = (BlackoutLightsValue)((uint_0 & 0x4000000) >> 26);
		result.BlackoutBrakeLights = (BlackoutBrakeLightsValue)((uint_0 & 0x8000000) >> 27);
		result.SpotLights = (SpotLightsValue)((uint_0 & 0x10000000) >> 28);
		result.InteriorLights = (InteriorLightsValue)((uint_0 & 0x20000000) >> 29);
		result.SurrenderState = (SurrenderStateValue)((uint_0 & 0x40000000) >> 30);
		result.MaskedCloaked = (MaskedCloakedValue)((uint_0 & 0x80000000u) >> 31);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is LandPlatformAppearance)
		{
			return Equals((LandPlatformAppearance)obj);
		}
		return false;
	}

	public bool Equals(LandPlatformAppearance landPlatformAppearance_0)
	{
		if ((object)landPlatformAppearance_0 == null)
		{
			return false;
		}
		if (PaintScheme == landPlatformAppearance_0.PaintScheme && Mobility == landPlatformAppearance_0.Mobility && FirePower == landPlatformAppearance_0.FirePower && Damage == landPlatformAppearance_0.Damage && Smoke == landPlatformAppearance_0.Smoke && TrailingEffects == landPlatformAppearance_0.TrailingEffects && Hatch == landPlatformAppearance_0.Hatch && HeadLights == landPlatformAppearance_0.HeadLights && TailLights == landPlatformAppearance_0.TailLights && BrakeLights == landPlatformAppearance_0.BrakeLights && Flaming == landPlatformAppearance_0.Flaming && Launcher == landPlatformAppearance_0.Launcher && CamouflageType == landPlatformAppearance_0.CamouflageType && Concealed == landPlatformAppearance_0.Concealed && FrozenStatus == landPlatformAppearance_0.FrozenStatus && PowerPlantStatus == landPlatformAppearance_0.PowerPlantStatus && State == landPlatformAppearance_0.State && Tent == landPlatformAppearance_0.Tent && Ramp == landPlatformAppearance_0.Ramp && BlackoutLights == landPlatformAppearance_0.BlackoutLights && BlackoutBrakeLights == landPlatformAppearance_0.BlackoutBrakeLights && SpotLights == landPlatformAppearance_0.SpotLights && InteriorLights == landPlatformAppearance_0.InteriorLights && SurrenderState == landPlatformAppearance_0.SurrenderState)
		{
			return MaskedCloaked == landPlatformAppearance_0.MaskedCloaked;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return (uint)(PaintSchemeValue.UniformColor | PaintScheme) | ((uint)Mobility << 1) | ((uint)FirePower << 2) | ((uint)Damage << 3) | ((uint)Smoke << 5) | ((uint)TrailingEffects << 7) | ((uint)Hatch << 9) | ((uint)HeadLights << 12) | ((uint)TailLights << 13) | ((uint)BrakeLights << 14) | ((uint)Flaming << 15) | ((uint)Launcher << 16) | ((uint)CamouflageType << 17) | ((uint)Concealed << 19) | ((uint)FrozenStatus << 21) | ((uint)PowerPlantStatus << 22) | ((uint)State << 23) | ((uint)Tent << 24) | ((uint)Ramp << 25) | ((uint)BlackoutLights << 26) | ((uint)BlackoutBrakeLights << 27) | ((uint)SpotLights << 28) | ((uint)InteriorLights << 29) | ((uint)SurrenderState << 30) | ((uint)MaskedCloaked << 31);
	}

	public override int GetHashCode()
	{
		return ((((((((((((((((((((((((493 + PaintScheme.GetHashCode()) * 29 + Mobility.GetHashCode()) * 29 + FirePower.GetHashCode()) * 29 + Damage.GetHashCode()) * 29 + Smoke.GetHashCode()) * 29 + TrailingEffects.GetHashCode()) * 29 + Hatch.GetHashCode()) * 29 + HeadLights.GetHashCode()) * 29 + TailLights.GetHashCode()) * 29 + BrakeLights.GetHashCode()) * 29 + Flaming.GetHashCode()) * 29 + Launcher.GetHashCode()) * 29 + CamouflageType.GetHashCode()) * 29 + Concealed.GetHashCode()) * 29 + FrozenStatus.GetHashCode()) * 29 + PowerPlantStatus.GetHashCode()) * 29 + State.GetHashCode()) * 29 + Tent.GetHashCode()) * 29 + Ramp.GetHashCode()) * 29 + BlackoutLights.GetHashCode()) * 29 + BlackoutBrakeLights.GetHashCode()) * 29 + SpotLights.GetHashCode()) * 29 + InteriorLights.GetHashCode()) * 29 + SurrenderState.GetHashCode()) * 29 + MaskedCloaked.GetHashCode();
	}
}
