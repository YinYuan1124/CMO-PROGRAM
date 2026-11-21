using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.Iff;

[Serializable]
public struct Type1Parameter4Mode4CodeStatus
{
	[Description("Code element 1")]
	public enum CodeElement1Value : uint
	{
		PseudoCryptoValue = 0u,
		NoPseudoCryptoValueUseAlternateMode4Value = 4095u
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

	private CodeElement1Value codeElement1Value_0;

	private StatusValue statusValue_0;

	private DamageValue damageValue_0;

	private MalfunctionValue malfunctionValue_0;

	public CodeElement1Value CodeElement1
	{
		get
		{
			return codeElement1Value_0;
		}
		set
		{
			codeElement1Value_0 = value;
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

	public static bool operator !=(Type1Parameter4Mode4CodeStatus type1Parameter4Mode4CodeStatus_0, Type1Parameter4Mode4CodeStatus type1Parameter4Mode4CodeStatus_1)
	{
		return !(type1Parameter4Mode4CodeStatus_0 == type1Parameter4Mode4CodeStatus_1);
	}

	public static bool operator ==(Type1Parameter4Mode4CodeStatus type1Parameter4Mode4CodeStatus_0, Type1Parameter4Mode4CodeStatus type1Parameter4Mode4CodeStatus_1)
	{
		if ((object)type1Parameter4Mode4CodeStatus_0 == (object)type1Parameter4Mode4CodeStatus_1)
		{
			return true;
		}
		if ((object)type1Parameter4Mode4CodeStatus_0 != null && (object)type1Parameter4Mode4CodeStatus_1 != null)
		{
			return type1Parameter4Mode4CodeStatus_0.Equals(type1Parameter4Mode4CodeStatus_1);
		}
		return false;
	}

	public static explicit operator ushort(Type1Parameter4Mode4CodeStatus type1Parameter4Mode4CodeStatus_0)
	{
		return type1Parameter4Mode4CodeStatus_0.ToUInt16();
	}

	public static explicit operator Type1Parameter4Mode4CodeStatus(ushort ushort_0)
	{
		return smethod_0(ushort_0);
	}

	public static Type1Parameter4Mode4CodeStatus FromByteArray(byte[] byte_0, int int_0)
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

	public static Type1Parameter4Mode4CodeStatus smethod_0(ushort ushort_0)
	{
		Type1Parameter4Mode4CodeStatus result = default(Type1Parameter4Mode4CodeStatus);
		result.CodeElement1 = (CodeElement1Value)(ushort_0 & 0xFFF);
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
		if (obj is Type1Parameter4Mode4CodeStatus)
		{
			return Equals((Type1Parameter4Mode4CodeStatus)obj);
		}
		return false;
	}

	public bool Equals(Type1Parameter4Mode4CodeStatus type1Parameter4Mode4CodeStatus_0)
	{
		if ((object)type1Parameter4Mode4CodeStatus_0 == null)
		{
			return false;
		}
		if (CodeElement1 == type1Parameter4Mode4CodeStatus_0.CodeElement1 && Status == type1Parameter4Mode4CodeStatus_0.Status && Damage == type1Parameter4Mode4CodeStatus_0.Damage)
		{
			return Malfunction == type1Parameter4Mode4CodeStatus_0.Malfunction;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt16());
	}

	public ushort ToUInt16()
	{
		return (ushort)((ushort)((ushort)((ushort)(0u | (ushort)CodeElement1) | (ushort)((uint)Status << 13)) | (ushort)((uint)Damage << 14)) | (ushort)((uint)Malfunction << 15));
	}

	public override int GetHashCode()
	{
		return (((493 + CodeElement1.GetHashCode()) * 29 + Status.GetHashCode()) * 29 + Damage.GetHashCode()) * 29 + Malfunction.GetHashCode();
	}
}
