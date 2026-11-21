using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Appearance;

[Serializable]
public struct MunitionAppearance
{
	[Description("Describes the damaged appearance of an entity")]
	public enum DamageValue : uint
	{
		NoDamage,
		SlightDamage,
		ModerateDamage,
		Destroyed
	}

	[Description("Describes status or location of smoke and vapor emanating from an entity")]
	public enum SmokeValue : uint
	{
		NotSmoking,
		SmokeOrVaporIsEmanatingFromTheEntity,
		EntityIsEmittingMotorSmoke,
		EntityIsEmittingMotorSmokeAndSmokeOrVaporIsEmanatingFromTheEntity
	}

	[Description("Describes the size of the vapor trail trailing effect for the effectsentity")]
	public enum TrailingEffectsValue : uint
	{
		None,
		Small,
		Medium,
		Large
	}

	[Description("Describes whether flames are rising from an entity")]
	public enum FlamingValue : uint
	{
		None,
		FlamesPresent
	}

	[Description("Describes the presence of a guided munition's launch flash")]
	public enum LaunchFlashValue : uint
	{
		NoLaunchFlashPresent,
		LaunchFlashPresent
	}

	[Description("Describes the frozen status of a guided munition")]
	public enum FrozenStatusValue : uint
	{
		NotFrozen,
		FrozenFrozenEntitiesShouldNotBeDeadReckonedIETheyShouldBeDisplayedAsFixedAtTheCurrentLocationEvenIfNonzeroVelocityAccelerationOrRotationDataIsReceivedFromTheFrozenEntity
	}

	[Description("Describes the power-plant status of a guided munition")]
	public enum PowerPlantStatusValue : uint
	{
		PowerPlantOff,
		PowerPlantOn
	}

	[Description("Describes the state of a guided munition")]
	public enum StateValue : uint
	{
		Active,
		Deactivated
	}

	[Description("Describes if the entity is Masked / Cloaked or Not")]
	public enum MaskedCloakedValue : uint
	{
		NotMaskedNotCloaked,
		MaskedCloaked
	}

	private DamageValue damageValue_0;

	private SmokeValue smokeValue_0;

	private TrailingEffectsValue trailingEffectsValue_0;

	private FlamingValue flamingValue_0;

	private LaunchFlashValue launchFlashValue_0;

	private FrozenStatusValue frozenStatusValue_0;

	private PowerPlantStatusValue powerPlantStatusValue_0;

	private StateValue stateValue_0;

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

	public LaunchFlashValue LaunchFlash
	{
		get
		{
			return launchFlashValue_0;
		}
		set
		{
			launchFlashValue_0 = value;
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

	public static bool operator !=(MunitionAppearance munitionAppearance_0, MunitionAppearance munitionAppearance_1)
	{
		return !(munitionAppearance_0 == munitionAppearance_1);
	}

	public static bool operator ==(MunitionAppearance munitionAppearance_0, MunitionAppearance munitionAppearance_1)
	{
		if ((object)munitionAppearance_0 == (object)munitionAppearance_1)
		{
			return true;
		}
		if ((object)munitionAppearance_0 != null && (object)munitionAppearance_1 != null)
		{
			return munitionAppearance_0.Equals(munitionAppearance_1);
		}
		return false;
	}

	public static explicit operator uint(MunitionAppearance munitionAppearance_0)
	{
		return munitionAppearance_0.ToUInt32();
	}

	public static explicit operator MunitionAppearance(uint uint_0)
	{
		return smethod_0(uint_0);
	}

	public static MunitionAppearance FromByteArray(byte[] byte_0, int int_0)
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

	public static MunitionAppearance smethod_0(uint uint_0)
	{
		MunitionAppearance result = default(MunitionAppearance);
		result.Damage = (DamageValue)((uint_0 & 0x18) >> 3);
		result.Smoke = (SmokeValue)((uint_0 & 0x60) >> 5);
		result.TrailingEffects = (TrailingEffectsValue)((uint_0 & 0x180) >> 7);
		result.Flaming = (FlamingValue)((uint_0 & 0x8000) >> 15);
		result.LaunchFlash = (LaunchFlashValue)((uint_0 & 0x10000) >> 16);
		result.FrozenStatus = (FrozenStatusValue)((uint_0 & 0x200000) >> 21);
		result.PowerPlantStatus = (PowerPlantStatusValue)((uint_0 & 0x400000) >> 22);
		result.State = (StateValue)((uint_0 & 0x800000) >> 23);
		result.MaskedCloaked = (MaskedCloakedValue)((uint_0 & 0x80000000u) >> 31);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is MunitionAppearance)
		{
			return Equals((MunitionAppearance)obj);
		}
		return false;
	}

	public bool Equals(MunitionAppearance munitionAppearance_0)
	{
		if ((object)munitionAppearance_0 == null)
		{
			return false;
		}
		if (Damage == munitionAppearance_0.Damage && Smoke == munitionAppearance_0.Smoke && TrailingEffects == munitionAppearance_0.TrailingEffects && Flaming == munitionAppearance_0.Flaming && LaunchFlash == munitionAppearance_0.LaunchFlash && FrozenStatus == munitionAppearance_0.FrozenStatus && PowerPlantStatus == munitionAppearance_0.PowerPlantStatus && State == munitionAppearance_0.State)
		{
			return MaskedCloaked == munitionAppearance_0.MaskedCloaked;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return 0u | ((uint)Damage << 3) | ((uint)Smoke << 5) | ((uint)TrailingEffects << 7) | ((uint)Flaming << 15) | ((uint)LaunchFlash << 16) | ((uint)FrozenStatus << 21) | ((uint)PowerPlantStatus << 22) | ((uint)State << 23) | ((uint)MaskedCloaked << 31);
	}

	public override int GetHashCode()
	{
		return ((((((((493 + Damage.GetHashCode()) * 29 + Smoke.GetHashCode()) * 29 + TrailingEffects.GetHashCode()) * 29 + Flaming.GetHashCode()) * 29 + LaunchFlash.GetHashCode()) * 29 + FrozenStatus.GetHashCode()) * 29 + PowerPlantStatus.GetHashCode()) * 29 + State.GetHashCode()) * 29 + MaskedCloaked.GetHashCode();
	}
}
