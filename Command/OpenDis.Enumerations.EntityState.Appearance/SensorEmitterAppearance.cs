using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Appearance;

[Serializable]
public struct SensorEmitterAppearance
{
	[Description("Describes the paint scheme of an entity")]
	public enum PaintSchemeValue : uint
	{
		UniformColor,
		Camouflage
	}

	[Description("Describes characteristics of mobility kill")]
	public enum MobilityValue : uint
	{
		NoMobilityKill,
		MobilityKill
	}

	[Description("Describes characteristics of mission kill (e.g. damaged antenna)")]
	public enum MissionValue : uint
	{
		NoMissionKill,
		MissionKill
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

	[Description("Describes the size of the dust cloud trailing effect for the Sensor/Emitter entity")]
	public enum TrailingEffectsValue : uint
	{
		None,
		Small,
		Medium,
		Large
	}

	[Description("Describes the status of lights on the sensor")]
	public enum LightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether flames are rising from the entity")]
	public enum FlamingValue : uint
	{
		None,
		FlamesPresent
	}

	[Description("Describes the elevated status of the sensor's antenna")]
	public enum AntennaValue : uint
	{
		NotRaised,
		Raised
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

	[Description("Describes the frozen status of an entity")]
	public enum FrozenStatusValue : uint
	{
		NotFrozen,
		FrozenFrozenEntitiesShouldNotBeDeadReckonedIETheyShouldBeDisplayedAsFixedAtTheCurrentLocationEvenIfNonzeroVelocityAccelerationOrRotationDataIsReceivedFromTheFrozenEntity
	}

	[Description("Describes the power-plant status of the sensor")]
	public enum PowerPlantStatusValue : uint
	{
		PowerPlantOff,
		PowerPlantOn
	}

	[Description("Describes the state of an entity")]
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

	[Description("Describes whether Blackout Lights are on or off.")]
	public enum BlackoutLightsValue : uint
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

	private MissionValue missionValue_0;

	private DamageValue damageValue_0;

	private SmokeValue smokeValue_0;

	private TrailingEffectsValue trailingEffectsValue_0;

	private LightsValue lightsValue_0;

	private FlamingValue flamingValue_0;

	private AntennaValue antennaValue_0;

	private CamouflageTypeValue camouflageTypeValue_0;

	private ConcealedValue concealedValue_0;

	private FrozenStatusValue frozenStatusValue_0;

	private PowerPlantStatusValue powerPlantStatusValue_0;

	private StateValue stateValue_0;

	private TentValue tentValue_0;

	private BlackoutLightsValue blackoutLightsValue_0;

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

	public MissionValue Mission
	{
		get
		{
			return missionValue_0;
		}
		set
		{
			missionValue_0 = value;
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

	public LightsValue Lights
	{
		get
		{
			return lightsValue_0;
		}
		set
		{
			lightsValue_0 = value;
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

	public AntennaValue Antenna
	{
		get
		{
			return antennaValue_0;
		}
		set
		{
			antennaValue_0 = value;
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

	public static bool operator !=(SensorEmitterAppearance sensorEmitterAppearance_0, SensorEmitterAppearance sensorEmitterAppearance_1)
	{
		return !(sensorEmitterAppearance_0 == sensorEmitterAppearance_1);
	}

	public static bool operator ==(SensorEmitterAppearance sensorEmitterAppearance_0, SensorEmitterAppearance sensorEmitterAppearance_1)
	{
		if ((object)sensorEmitterAppearance_0 == (object)sensorEmitterAppearance_1)
		{
			return true;
		}
		if ((object)sensorEmitterAppearance_0 != null && (object)sensorEmitterAppearance_1 != null)
		{
			return sensorEmitterAppearance_0.Equals(sensorEmitterAppearance_1);
		}
		return false;
	}

	public static explicit operator uint(SensorEmitterAppearance sensorEmitterAppearance_0)
	{
		return sensorEmitterAppearance_0.ToUInt32();
	}

	public static explicit operator SensorEmitterAppearance(uint uint_0)
	{
		return smethod_0(uint_0);
	}

	public static SensorEmitterAppearance FromByteArray(byte[] byte_0, int int_0)
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

	public static SensorEmitterAppearance smethod_0(uint uint_0)
	{
		SensorEmitterAppearance result = default(SensorEmitterAppearance);
		result.PaintScheme = (PaintSchemeValue)(uint_0 & 1u);
		result.Mobility = (MobilityValue)((uint_0 & 2) >> 1);
		result.Mission = (MissionValue)((uint_0 & 4) >> 2);
		result.Damage = (DamageValue)((uint_0 & 0x18) >> 3);
		result.Smoke = (SmokeValue)((uint_0 & 0x60) >> 5);
		result.TrailingEffects = (TrailingEffectsValue)((uint_0 & 0x180) >> 7);
		result.Lights = (LightsValue)((uint_0 & 0x1000) >> 12);
		result.Flaming = (FlamingValue)((uint_0 & 0x8000) >> 15);
		result.Antenna = (AntennaValue)((uint_0 & 0x10000) >> 16);
		result.CamouflageType = (CamouflageTypeValue)((uint_0 & 0x60000) >> 17);
		result.Concealed = (ConcealedValue)((uint_0 & 0x80000) >> 19);
		result.FrozenStatus = (FrozenStatusValue)((uint_0 & 0x200000) >> 21);
		result.PowerPlantStatus = (PowerPlantStatusValue)((uint_0 & 0x400000) >> 22);
		result.State = (StateValue)((uint_0 & 0x800000) >> 23);
		result.Tent = (TentValue)((uint_0 & 0x1000000) >> 24);
		result.BlackoutLights = (BlackoutLightsValue)((uint_0 & 0x4000000) >> 26);
		result.InteriorLights = (InteriorLightsValue)((uint_0 & 0x20000000) >> 29);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is SensorEmitterAppearance)
		{
			return Equals((SensorEmitterAppearance)obj);
		}
		return false;
	}

	public bool Equals(SensorEmitterAppearance sensorEmitterAppearance_0)
	{
		if ((object)sensorEmitterAppearance_0 == null)
		{
			return false;
		}
		if (PaintScheme == sensorEmitterAppearance_0.PaintScheme && Mobility == sensorEmitterAppearance_0.Mobility && Mission == sensorEmitterAppearance_0.Mission && Damage == sensorEmitterAppearance_0.Damage && Smoke == sensorEmitterAppearance_0.Smoke && TrailingEffects == sensorEmitterAppearance_0.TrailingEffects && Lights == sensorEmitterAppearance_0.Lights && Flaming == sensorEmitterAppearance_0.Flaming && Antenna == sensorEmitterAppearance_0.Antenna && CamouflageType == sensorEmitterAppearance_0.CamouflageType && Concealed == sensorEmitterAppearance_0.Concealed && FrozenStatus == sensorEmitterAppearance_0.FrozenStatus && PowerPlantStatus == sensorEmitterAppearance_0.PowerPlantStatus && State == sensorEmitterAppearance_0.State && Tent == sensorEmitterAppearance_0.Tent && BlackoutLights == sensorEmitterAppearance_0.BlackoutLights)
		{
			return InteriorLights == sensorEmitterAppearance_0.InteriorLights;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return (uint)(PaintSchemeValue.UniformColor | PaintScheme) | ((uint)Mobility << 1) | ((uint)Mission << 2) | ((uint)Damage << 3) | ((uint)Smoke << 5) | ((uint)TrailingEffects << 7) | ((uint)Lights << 12) | ((uint)Flaming << 15) | ((uint)Antenna << 16) | ((uint)CamouflageType << 17) | ((uint)Concealed << 19) | ((uint)FrozenStatus << 21) | ((uint)PowerPlantStatus << 22) | ((uint)State << 23) | ((uint)Tent << 24) | ((uint)BlackoutLights << 26) | ((uint)InteriorLights << 29);
	}

	public override int GetHashCode()
	{
		return ((((((((((((((((493 + PaintScheme.GetHashCode()) * 29 + Mobility.GetHashCode()) * 29 + Mission.GetHashCode()) * 29 + Damage.GetHashCode()) * 29 + Smoke.GetHashCode()) * 29 + TrailingEffects.GetHashCode()) * 29 + Lights.GetHashCode()) * 29 + Flaming.GetHashCode()) * 29 + Antenna.GetHashCode()) * 29 + CamouflageType.GetHashCode()) * 29 + Concealed.GetHashCode()) * 29 + FrozenStatus.GetHashCode()) * 29 + PowerPlantStatus.GetHashCode()) * 29 + State.GetHashCode()) * 29 + Tent.GetHashCode()) * 29 + BlackoutLights.GetHashCode()) * 29 + InteriorLights.GetHashCode();
	}
}
