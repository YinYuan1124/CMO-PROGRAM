using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Appearance;

[Serializable]
public struct CulturalAppearance
{
	[Description("Describes the damaged appearance of an entity")]
	public enum DamageValue : uint
	{
		NoDamage,
		SlightDamage,
		ModerateDamage,
		Destroyed
	}

	[Description("Describes status of smoke emanating from a Cultural Features object")]
	public enum SmokeValue : uint
	{
		NotSmoking,
		SmokePlumeRisingFromTheEntity,
		Unknown
	}

	[Description("Describes whether flames are rising from a Cultural Features object")]
	public enum FlamingValue : uint
	{
		None,
		FlamesPresent
	}

	[Description("Describes the frozen status of a Cultural Features object")]
	public enum FrozenStatusValue : uint
	{
		NotFrozen,
		FrozenFrozenEntitiesShouldNotBeDeadReckonedIEShouldBeDisplayedAsFixedAtTheCurrentLocationEvenIfNonZeroVelocityAccelerationOrRotationDataReceivedFromTheFrozenEntity
	}

	[Description("Describes the Internal-Heat status")]
	public enum InternalHeatStatusValue : uint
	{
		InternalHeatOff,
		InternalHeatOn
	}

	[Description("Describes the state of a Cultural object")]
	public enum StateValue : uint
	{
		Active,
		Deactivated
	}

	[Description("Describes whether Exterior Lights are on or off.")]
	public enum ExteriorLightsValue : uint
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

	[Description("Describes if the entity is Masked / Cloaked or Not")]
	public enum MaskedCloakedValue : uint
	{
		NotMaskedNotCloaked,
		MaskedCloaked
	}

	private DamageValue damageValue_0;

	private SmokeValue smokeValue_0;

	private FlamingValue flamingValue_0;

	private FrozenStatusValue frozenStatusValue_0;

	private InternalHeatStatusValue internalHeatStatusValue_0;

	private StateValue stateValue_0;

	private ExteriorLightsValue exteriorLightsValue_0;

	private InteriorLightsValue interiorLightsValue_0;

	private MaskedCloakedValue maskedCloakedValue_0;

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

	public InternalHeatStatusValue InternalHeatStatus
	{
		get
		{
			return internalHeatStatusValue_0;
		}
		set
		{
			internalHeatStatusValue_0 = value;
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

	public ExteriorLightsValue ExteriorLights
	{
		get
		{
			return exteriorLightsValue_0;
		}
		set
		{
			exteriorLightsValue_0 = value;
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

	public static bool operator !=(CulturalAppearance culturalAppearance_0, CulturalAppearance culturalAppearance_1)
	{
		return !(culturalAppearance_0 == culturalAppearance_1);
	}

	public static bool operator ==(CulturalAppearance culturalAppearance_0, CulturalAppearance culturalAppearance_1)
	{
		if ((object)culturalAppearance_0 == (object)culturalAppearance_1)
		{
			return true;
		}
		if ((object)culturalAppearance_0 != null && (object)culturalAppearance_1 != null)
		{
			return culturalAppearance_0.Equals(culturalAppearance_1);
		}
		return false;
	}

	public static explicit operator uint(CulturalAppearance culturalAppearance_0)
	{
		return culturalAppearance_0.ToUInt32();
	}

	public static explicit operator CulturalAppearance(uint uint_0)
	{
		return smethod_0(uint_0);
	}

	public static CulturalAppearance FromByteArray(byte[] byte_0, int int_0)
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

	public static CulturalAppearance smethod_0(uint uint_0)
	{
		CulturalAppearance result = default(CulturalAppearance);
		result.Damage = (DamageValue)((uint_0 & 0x18) >> 3);
		result.Smoke = (SmokeValue)((uint_0 & 0x60) >> 5);
		result.Flaming = (FlamingValue)((uint_0 & 0x8000) >> 15);
		result.FrozenStatus = (FrozenStatusValue)((uint_0 & 0x200000) >> 21);
		result.InternalHeatStatus = (InternalHeatStatusValue)((uint_0 & 0x400000) >> 22);
		result.State = (StateValue)((uint_0 & 0x800000) >> 23);
		result.ExteriorLights = (ExteriorLightsValue)((uint_0 & 0x10000000) >> 28);
		result.InteriorLights = (InteriorLightsValue)((uint_0 & 0x20000000) >> 29);
		result.MaskedCloaked = (MaskedCloakedValue)((uint_0 & 0x80000000u) >> 31);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is CulturalAppearance)
		{
			return Equals((CulturalAppearance)obj);
		}
		return false;
	}

	public bool Equals(CulturalAppearance culturalAppearance_0)
	{
		if ((object)culturalAppearance_0 == null)
		{
			return false;
		}
		if (Damage == culturalAppearance_0.Damage && Smoke == culturalAppearance_0.Smoke && Flaming == culturalAppearance_0.Flaming && FrozenStatus == culturalAppearance_0.FrozenStatus && InternalHeatStatus == culturalAppearance_0.InternalHeatStatus && State == culturalAppearance_0.State && ExteriorLights == culturalAppearance_0.ExteriorLights && InteriorLights == culturalAppearance_0.InteriorLights)
		{
			return MaskedCloaked == culturalAppearance_0.MaskedCloaked;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return 0u | ((uint)Damage << 3) | ((uint)Smoke << 5) | ((uint)Flaming << 15) | ((uint)FrozenStatus << 21) | ((uint)InternalHeatStatus << 22) | ((uint)State << 23) | ((uint)ExteriorLights << 28) | ((uint)InteriorLights << 29) | ((uint)MaskedCloaked << 31);
	}

	public override int GetHashCode()
	{
		return ((((((((493 + Damage.GetHashCode()) * 29 + Smoke.GetHashCode()) * 29 + Flaming.GetHashCode()) * 29 + FrozenStatus.GetHashCode()) * 29 + InternalHeatStatus.GetHashCode()) * 29 + State.GetHashCode()) * 29 + ExteriorLights.GetHashCode()) * 29 + InteriorLights.GetHashCode()) * 29 + MaskedCloaked.GetHashCode();
	}
}
