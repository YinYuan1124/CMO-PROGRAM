using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.Iff;

[Serializable]
public struct Type1Parameter5ModeCCodeStatus
{
	[Description("Negative Altitude")]
	public enum NegativeAltitudeValue : uint
	{
		PositiveAltitudeAboveMeanSeaLevelIndicatorIfModeCAltitudeIsContainedInBits111,
		NegativeAltitudeBelowMeanSeaLevelIndicatorIfModeCAltitudeIsContainedInBits111OrAlternateMode5IfAltitudeBits1112047
	}

	[Description("Mode C altitude")]
	public enum GEnum1 : uint
	{
		ActualModeCAltitudeInTheRange0126000FeetIn100FootIncrementsBit0NegativePositiveIndicatorMustBeSetAppropriately = 0u,
		NotActualModeCAltitudeValueUseAlternateMode5Bits0114095IEAll1S = 2047u
	}

	[Description("Status")]
	public enum StatusValue : uint
	{
		Off,
		On
	}

	[Description("Damage")]
	public enum DamageValue : uint
	{
		NoDamage,
		Damage
	}

	[Description("Malfunction")]
	public enum MalfunctionValue : uint
	{
		NoMalfunction,
		Malfunction
	}

	private NegativeAltitudeValue negativeAltitudeValue_0;

	private GEnum1 genum1_0;

	private StatusValue statusValue_0;

	private DamageValue damageValue_0;

	private MalfunctionValue malfunctionValue_0;

	public NegativeAltitudeValue NegativeAltitude
	{
		get
		{
			return negativeAltitudeValue_0;
		}
		set
		{
			negativeAltitudeValue_0 = value;
		}
	}

	public GEnum1 ModeCAltitude
	{
		get
		{
			return genum1_0;
		}
		set
		{
			genum1_0 = value;
		}
	}

	public StatusValue Status
	{
		get
		{
			return statusValue_0;
		}
		set
		{
			statusValue_0 = value;
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

	public MalfunctionValue Malfunction
	{
		get
		{
			return malfunctionValue_0;
		}
		set
		{
			malfunctionValue_0 = value;
		}
	}

	public static bool operator !=(Type1Parameter5ModeCCodeStatus type1Parameter5ModeCCodeStatus_0, Type1Parameter5ModeCCodeStatus type1Parameter5ModeCCodeStatus_1)
	{
		return !(type1Parameter5ModeCCodeStatus_0 == type1Parameter5ModeCCodeStatus_1);
	}

	public static bool operator ==(Type1Parameter5ModeCCodeStatus type1Parameter5ModeCCodeStatus_0, Type1Parameter5ModeCCodeStatus type1Parameter5ModeCCodeStatus_1)
	{
		if ((object)type1Parameter5ModeCCodeStatus_0 == (object)type1Parameter5ModeCCodeStatus_1)
		{
			return true;
		}
		if ((object)type1Parameter5ModeCCodeStatus_0 != null && (object)type1Parameter5ModeCCodeStatus_1 != null)
		{
			return type1Parameter5ModeCCodeStatus_0.Equals(type1Parameter5ModeCCodeStatus_1);
		}
		return false;
	}

	public static explicit operator ushort(Type1Parameter5ModeCCodeStatus type1Parameter5ModeCCodeStatus_0)
	{
		return type1Parameter5ModeCCodeStatus_0.ToUInt16();
	}

	public static explicit operator Type1Parameter5ModeCCodeStatus(ushort ushort_0)
	{
		return smethod_0(ushort_0);
	}

	public static Type1Parameter5ModeCCodeStatus FromByteArray(byte[] byte_0, int int_0)
	{
		if (byte_0 == null)
		{
			throw new ArgumentNullException("array");
		}
		if (int_0 < 0 || int_0 > byte_0.Length - 1 || int_0 + 2 > byte_0.Length - 1)
		{
			throw new IndexOutOfRangeException();
		}
		return smethod_0(BitConverter.ToUInt16(byte_0, int_0));
	}

	public static Type1Parameter5ModeCCodeStatus smethod_0(ushort ushort_0)
	{
		Type1Parameter5ModeCCodeStatus result = default(Type1Parameter5ModeCCodeStatus);
		result.NegativeAltitude = (NegativeAltitudeValue)(ushort_0 & 1);
		result.ModeCAltitude = (GEnum1)((uint)(ushort_0 & 0xFFE) >> 1);
		result.Status = (StatusValue)((uint)(ushort_0 & 0x2000) >> 13);
		result.Damage = (DamageValue)((uint)(ushort_0 & 0x4000) >> 14);
		result.Malfunction = (MalfunctionValue)((uint)(ushort_0 & 0x8000) >> 15);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is Type1Parameter5ModeCCodeStatus)
		{
			return Equals((Type1Parameter5ModeCCodeStatus)obj);
		}
		return false;
	}

	public bool Equals(Type1Parameter5ModeCCodeStatus type1Parameter5ModeCCodeStatus_0)
	{
		if ((object)type1Parameter5ModeCCodeStatus_0 == null)
		{
			return false;
		}
		if (NegativeAltitude == type1Parameter5ModeCCodeStatus_0.NegativeAltitude && ModeCAltitude == type1Parameter5ModeCCodeStatus_0.ModeCAltitude && Status == type1Parameter5ModeCCodeStatus_0.Status && Damage == type1Parameter5ModeCCodeStatus_0.Damage)
		{
			return Malfunction == type1Parameter5ModeCCodeStatus_0.Malfunction;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt16());
	}

	public ushort ToUInt16()
	{
		return (ushort)((ushort)((ushort)((ushort)((ushort)(0u | (ushort)NegativeAltitude) | (ushort)((uint)ModeCAltitude << 1)) | (ushort)((uint)Status << 13)) | (ushort)((uint)Damage << 14)) | (ushort)((uint)Malfunction << 15));
	}

	public override int GetHashCode()
	{
		return ((((493 + NegativeAltitude.GetHashCode()) * 29 + ModeCAltitude.GetHashCode()) * 29 + Status.GetHashCode()) * 29 + Damage.GetHashCode()) * 29 + Malfunction.GetHashCode();
	}
}
