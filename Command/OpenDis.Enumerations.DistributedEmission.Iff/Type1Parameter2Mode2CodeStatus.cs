using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.Iff;

[Serializable]
public struct Type1Parameter2Mode2CodeStatus
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

	private byte byte_2;

	private byte byte_3;

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

	public byte CodeElement3
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
		}
	}

	public byte CodeElement4
	{
		get
		{
			return byte_3;
		}
		set
		{
			byte_3 = value;
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

	public static bool operator !=(Type1Parameter2Mode2CodeStatus type1Parameter2Mode2CodeStatus_0, Type1Parameter2Mode2CodeStatus type1Parameter2Mode2CodeStatus_1)
	{
		return !(type1Parameter2Mode2CodeStatus_0 == type1Parameter2Mode2CodeStatus_1);
	}

	public static bool operator ==(Type1Parameter2Mode2CodeStatus type1Parameter2Mode2CodeStatus_0, Type1Parameter2Mode2CodeStatus type1Parameter2Mode2CodeStatus_1)
	{
		if ((object)type1Parameter2Mode2CodeStatus_0 == (object)type1Parameter2Mode2CodeStatus_1)
		{
			return true;
		}
		if ((object)type1Parameter2Mode2CodeStatus_0 != null && (object)type1Parameter2Mode2CodeStatus_1 != null)
		{
			return type1Parameter2Mode2CodeStatus_0.Equals(type1Parameter2Mode2CodeStatus_1);
		}
		return false;
	}

	public static explicit operator ushort(Type1Parameter2Mode2CodeStatus type1Parameter2Mode2CodeStatus_0)
	{
		return type1Parameter2Mode2CodeStatus_0.ToUInt16();
	}

	public static explicit operator Type1Parameter2Mode2CodeStatus(ushort ushort_0)
	{
		return smethod_0(ushort_0);
	}

	public static Type1Parameter2Mode2CodeStatus FromByteArray(byte[] byte_4, int int_0)
	{
		if (byte_4 == null)
		{
			throw new ArgumentNullException("array");
		}
		if (int_0 < 0 || int_0 > byte_4.Length - 1 || int_0 + 2 > byte_4.Length - 1)
		{
			throw new IndexOutOfRangeException();
		}
		return smethod_0(BitConverter.ToUInt16(byte_4, int_0));
	}

	public static Type1Parameter2Mode2CodeStatus smethod_0(ushort ushort_0)
	{
		Type1Parameter2Mode2CodeStatus result = default(Type1Parameter2Mode2CodeStatus);
		uint num = ushort_0 & 7u;
		result.CodeElement1 = (byte)num;
		uint num2 = (uint)(ushort_0 & 0x38) >> 3;
		result.CodeElement2 = (byte)num2;
		uint num3 = (uint)(ushort_0 & 0x1C0) >> 6;
		result.CodeElement3 = (byte)num3;
		uint num4 = (uint)(ushort_0 & 0xE00) >> 9;
		result.CodeElement4 = (byte)num4;
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
		if (obj is Type1Parameter2Mode2CodeStatus)
		{
			return Equals((Type1Parameter2Mode2CodeStatus)obj);
		}
		return false;
	}

	public bool Equals(Type1Parameter2Mode2CodeStatus type1Parameter2Mode2CodeStatus_0)
	{
		if ((object)type1Parameter2Mode2CodeStatus_0 == null)
		{
			return false;
		}
		if (CodeElement1 == type1Parameter2Mode2CodeStatus_0.CodeElement1 && CodeElement2 == type1Parameter2Mode2CodeStatus_0.CodeElement2 && CodeElement3 == type1Parameter2Mode2CodeStatus_0.CodeElement3 && CodeElement4 == type1Parameter2Mode2CodeStatus_0.CodeElement4 && Status == type1Parameter2Mode2CodeStatus_0.Status && Damage == type1Parameter2Mode2CodeStatus_0.Damage)
		{
			return Malfunction == type1Parameter2Mode2CodeStatus_0.Malfunction;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt16());
	}

	public ushort ToUInt16()
	{
		return (ushort)((ushort)((ushort)((ushort)((ushort)((ushort)((ushort)(0u | CodeElement1) | (ushort)(CodeElement2 << 3)) | (ushort)(CodeElement3 << 6)) | (ushort)(CodeElement4 << 9)) | (ushort)((uint)Status << 13)) | (ushort)((uint)Damage << 14)) | (ushort)((uint)Malfunction << 15));
	}

	public override int GetHashCode()
	{
		return ((((((493 + CodeElement1.GetHashCode()) * 29 + CodeElement2.GetHashCode()) * 29 + CodeElement3.GetHashCode()) * 29 + CodeElement4.GetHashCode()) * 29 + Status.GetHashCode()) * 29 + Damage.GetHashCode()) * 29 + Malfunction.GetHashCode();
	}
}
