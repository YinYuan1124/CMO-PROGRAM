using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.Iff;

[Serializable]
public struct Type5Parameter1RRBResponse
{
	[Description("Power Reduction")]
	public enum PowerReductionValue : uint
	{
		Off,
		On
	}

	[Description("Radar Enhancement")]
	public enum RadarEnhancementValue : uint
	{
		Off,
		On
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

	private byte byte_0;

	private PowerReductionValue powerReductionValue_0;

	private RadarEnhancementValue radarEnhancementValue_0;

	private StatusValue statusValue_0;

	private DamageValue damageValue_0;

	private MalfunctionValue malfunctionValue_0;

	public byte Code
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

	public PowerReductionValue PowerReduction
	{
		get
		{
			return powerReductionValue_0;
		}
		set
		{
			powerReductionValue_0 = value;
		}
	}

	public RadarEnhancementValue RadarEnhancement
	{
		get
		{
			return radarEnhancementValue_0;
		}
		set
		{
			radarEnhancementValue_0 = value;
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

	public static bool operator !=(Type5Parameter1RRBResponse type5Parameter1RRBResponse_0, Type5Parameter1RRBResponse type5Parameter1RRBResponse_1)
	{
		return !(type5Parameter1RRBResponse_0 == type5Parameter1RRBResponse_1);
	}

	public static bool operator ==(Type5Parameter1RRBResponse type5Parameter1RRBResponse_0, Type5Parameter1RRBResponse type5Parameter1RRBResponse_1)
	{
		if ((object)type5Parameter1RRBResponse_0 == (object)type5Parameter1RRBResponse_1)
		{
			return true;
		}
		if ((object)type5Parameter1RRBResponse_0 != null && (object)type5Parameter1RRBResponse_1 != null)
		{
			return type5Parameter1RRBResponse_0.Equals(type5Parameter1RRBResponse_1);
		}
		return false;
	}

	public static explicit operator ushort(Type5Parameter1RRBResponse type5Parameter1RRBResponse_0)
	{
		return type5Parameter1RRBResponse_0.ToUInt16();
	}

	public static explicit operator Type5Parameter1RRBResponse(ushort ushort_0)
	{
		return smethod_0(ushort_0);
	}

	public static Type5Parameter1RRBResponse FromByteArray(byte[] byte_1, int int_0)
	{
		if (byte_1 == null)
		{
			throw new ArgumentNullException("array");
		}
		if (int_0 < 0 || int_0 > byte_1.Length - 1 || int_0 + 2 > byte_1.Length - 1)
		{
			throw new IndexOutOfRangeException();
		}
		return smethod_0(BitConverter.ToUInt16(byte_1, int_0));
	}

	public static Type5Parameter1RRBResponse smethod_0(ushort ushort_0)
	{
		Type5Parameter1RRBResponse result = default(Type5Parameter1RRBResponse);
		uint num = ushort_0 & 0x1Fu;
		result.Code = (byte)num;
		result.PowerReduction = (PowerReductionValue)((uint)(ushort_0 & 0x800) >> 11);
		result.RadarEnhancement = (RadarEnhancementValue)((uint)(ushort_0 & 0x1000) >> 12);
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
		if (obj is Type5Parameter1RRBResponse)
		{
			return Equals((Type5Parameter1RRBResponse)obj);
		}
		return false;
	}

	public bool Equals(Type5Parameter1RRBResponse type5Parameter1RRBResponse_0)
	{
		if ((object)type5Parameter1RRBResponse_0 == null)
		{
			return false;
		}
		if (Code == type5Parameter1RRBResponse_0.Code && PowerReduction == type5Parameter1RRBResponse_0.PowerReduction && RadarEnhancement == type5Parameter1RRBResponse_0.RadarEnhancement && Status == type5Parameter1RRBResponse_0.Status && Damage == type5Parameter1RRBResponse_0.Damage)
		{
			return Malfunction == type5Parameter1RRBResponse_0.Malfunction;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt16());
	}

	public ushort ToUInt16()
	{
		return (ushort)((ushort)((ushort)((ushort)((ushort)((ushort)(0u | Code) | (ushort)((uint)PowerReduction << 11)) | (ushort)((uint)RadarEnhancement << 12)) | (ushort)((uint)Status << 13)) | (ushort)((uint)Damage << 14)) | (ushort)((uint)Malfunction << 15));
	}

	public override int GetHashCode()
	{
		return (((((493 + Code.GetHashCode()) * 29 + PowerReduction.GetHashCode()) * 29 + RadarEnhancement.GetHashCode()) * 29 + Status.GetHashCode()) * 29 + Damage.GetHashCode()) * 29 + Malfunction.GetHashCode();
	}
}
