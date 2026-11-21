using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Appearance;

[Serializable]
public struct EnvironmentalAppearance
{
	[Description("Describes the density of the environmentals")]
	public enum DensityValue : uint
	{
		Clear,
		Hazy,
		Dense,
		VeryDense,
		Opaque,
		Unknown
	}

	[Description("Describes the frozen status of a environmental object")]
	public enum FrozenStatusValue : uint
	{
		NotFrozen,
		FrozenFrozenEntitiesShouldNotBeDeadReckonedIETheyShouldBeDisplayedAsFixedAtTheCurrentLocationEvenIfNonzeroVelocityAccelerationOrRotationDataIsReceivedFromTheFrozenEntity
	}

	[Description("Describes the state of a environmental object")]
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

	private DensityValue densityValue_0;

	private FrozenStatusValue frozenStatusValue_0;

	private StateValue stateValue_0;

	private MaskedCloakedValue maskedCloakedValue_0;

	public DensityValue Density
	{
		get
		{
			return densityValue_0;
		}
		set
		{
			densityValue_0 = value;
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

	public static bool operator !=(EnvironmentalAppearance environmentalAppearance_0, EnvironmentalAppearance environmentalAppearance_1)
	{
		return !(environmentalAppearance_0 == environmentalAppearance_1);
	}

	public static bool operator ==(EnvironmentalAppearance environmentalAppearance_0, EnvironmentalAppearance environmentalAppearance_1)
	{
		if ((object)environmentalAppearance_0 == (object)environmentalAppearance_1)
		{
			return true;
		}
		if ((object)environmentalAppearance_0 != null && (object)environmentalAppearance_1 != null)
		{
			return environmentalAppearance_0.Equals(environmentalAppearance_1);
		}
		return false;
	}

	public static explicit operator uint(EnvironmentalAppearance environmentalAppearance_0)
	{
		return environmentalAppearance_0.ToUInt32();
	}

	public static explicit operator EnvironmentalAppearance(uint uint_0)
	{
		return smethod_0(uint_0);
	}

	public static EnvironmentalAppearance FromByteArray(byte[] byte_0, int int_0)
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

	public static EnvironmentalAppearance smethod_0(uint uint_0)
	{
		EnvironmentalAppearance result = default(EnvironmentalAppearance);
		result.Density = (DensityValue)((uint_0 & 0xF0000) >> 16);
		result.FrozenStatus = (FrozenStatusValue)((uint_0 & 0x200000) >> 21);
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
		if (obj is EnvironmentalAppearance)
		{
			return Equals((EnvironmentalAppearance)obj);
		}
		return false;
	}

	public bool Equals(EnvironmentalAppearance environmentalAppearance_0)
	{
		if ((object)environmentalAppearance_0 == null)
		{
			return false;
		}
		if (Density == environmentalAppearance_0.Density && FrozenStatus == environmentalAppearance_0.FrozenStatus && State == environmentalAppearance_0.State)
		{
			return MaskedCloaked == environmentalAppearance_0.MaskedCloaked;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return 0u | ((uint)Density << 16) | ((uint)FrozenStatus << 21) | ((uint)State << 23) | ((uint)MaskedCloaked << 31);
	}

	public override int GetHashCode()
	{
		return (((493 + Density.GetHashCode()) * 29 + FrozenStatus.GetHashCode()) * 29 + State.GetHashCode()) * 29 + MaskedCloaked.GetHashCode();
	}
}
