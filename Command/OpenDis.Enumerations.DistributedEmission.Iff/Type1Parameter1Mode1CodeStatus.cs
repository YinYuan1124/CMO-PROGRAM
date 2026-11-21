using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.Iff;

[Serializable]
public struct Type1Parameter1Mode1CodeStatus
{
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

	private byte byte_0;

	private byte byte_1;

	private StatusValue statusValue_0;

	private DamageValue damageValue_0;

	private MalfunctionValue malfunctionValue_0;

	public byte CodeElement1
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public byte CodeElement2
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
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

	public static bool operator !=(Type1Parameter1Mode1CodeStatus type1Parameter1Mode1CodeStatus_0, Type1Parameter1Mode1CodeStatus type1Parameter1Mode1CodeStatus_1)
	{
		return !(type1Parameter1Mode1CodeStatus_0 == type1Parameter1Mode1CodeStatus_1);
	}

	public static bool operator ==(Type1Parameter1Mode1CodeStatus type1Parameter1Mode1CodeStatus_0, Type1Parameter1Mode1CodeStatus type1Parameter1Mode1CodeStatus_1)
	{
		if ((object)type1Parameter1Mode1CodeStatus_0 == (object)type1Parameter1Mode1CodeStatus_1)
		{
			return true;
		}
		if ((object)type1Parameter1Mode1CodeStatus_0 != null && (object)type1Parameter1Mode1CodeStatus_1 != null)
		{
			return type1Parameter1Mode1CodeStatus_0.Equals(type1Parameter1Mode1CodeStatus_1);
		}
		return false;
	}

	public static explicit operator ushort(Type1Parameter1Mode1CodeStatus type1Parameter1Mode1CodeStatus_0)
	{
		return type1Parameter1Mode1CodeStatus_0.ToUInt16();
	}

	public static explicit operator Type1Parameter1Mode1CodeStatus(ushort ushort_0)
	{
		return smethod_0(ushort_0);
	}

	public static Type1Parameter1Mode1CodeStatus FromByteArray(byte[] byte_2, int int_0)
	{
		if (byte_2 == null)
		{
			throw new ArgumentNullException("array");
		}
		if (int_0 < 0 || int_0 > byte_2.Length - 1 || int_0 + 2 > byte_2.Length - 1)
		{
			throw new IndexOutOfRangeException();
		}
		return smethod_0(BitConverter.ToUInt16(byte_2, int_0));
	}

	public static Type1Parameter1Mode1CodeStatus smethod_0(ushort ushort_0)
	{
		Type1Parameter1Mode1CodeStatus result = default(Type1Parameter1Mode1CodeStatus);
		uint num = ushort_0 & 7u;
		result.CodeElement1 = (byte)num;
		uint num2 = (uint)(ushort_0 & 0x38) >> 3;
		result.CodeElement2 = (byte)num2;
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
		if (obj is Type1Parameter1Mode1CodeStatus)
		{
			return Equals((Type1Parameter1Mode1CodeStatus)obj);
		}
		return false;
	}

	public bool Equals(Type1Parameter1Mode1CodeStatus type1Parameter1Mode1CodeStatus_0)
	{
		if ((object)type1Parameter1Mode1CodeStatus_0 == null)
		{
			return false;
		}
		if (CodeElement1 == type1Parameter1Mode1CodeStatus_0.CodeElement1 && CodeElement2 == type1Parameter1Mode1CodeStatus_0.CodeElement2 && Status == type1Parameter1Mode1CodeStatus_0.Status && Damage == type1Parameter1Mode1CodeStatus_0.Damage)
		{
			return Malfunction == type1Parameter1Mode1CodeStatus_0.Malfunction;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt16());
	}

	public ushort ToUInt16()
	{
		return (ushort)((ushort)((ushort)((ushort)((ushort)(0u | CodeElement1) | (ushort)(CodeElement2 << 3)) | (ushort)((uint)Status << 13)) | (ushort)((uint)Damage << 14)) | (ushort)((uint)Malfunction << 15));
	}

	public override int GetHashCode()
	{
		return ((((493 + CodeElement1.GetHashCode()) * 29 + CodeElement2.GetHashCode()) * 29 + Status.GetHashCode()) * 29 + Damage.GetHashCode()) * 29 + Malfunction.GetHashCode();
	}
}
