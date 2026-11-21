using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
public struct ExhaustSmoke
{
	[Description("Describes whether the smoke is attached to the vehicle")]
	public enum AttachedValue : uint
	{
		NotAttached,
		Attached
	}

	[Description("Describes the chemical content of the smoke")]
	public enum ChemicalValue : uint
	{
		Other,
		Hydrochloric,
		WhitePhosphorous,
		RedPhosphorous
	}

	private byte byte_0;

	private AttachedValue attachedValue_0;

	private ChemicalValue chemicalValue_0;

	public byte Opacity
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

	public AttachedValue Attached
	{
		get
		{
			return attachedValue_0;
		}
		set
		{
			attachedValue_0 = value;
		}
	}

	public ChemicalValue Chemical
	{
		get
		{
			return chemicalValue_0;
		}
		set
		{
			chemicalValue_0 = value;
		}
	}

	public static bool operator !=(ExhaustSmoke exhaustSmoke_0, ExhaustSmoke exhaustSmoke_1)
	{
		return !(exhaustSmoke_0 == exhaustSmoke_1);
	}

	public static bool operator ==(ExhaustSmoke exhaustSmoke_0, ExhaustSmoke exhaustSmoke_1)
	{
		if ((object)exhaustSmoke_0 == (object)exhaustSmoke_1)
		{
			return true;
		}
		if ((object)exhaustSmoke_0 != null && (object)exhaustSmoke_1 != null)
		{
			return exhaustSmoke_0.Equals(exhaustSmoke_1);
		}
		return false;
	}

	public static explicit operator uint(ExhaustSmoke exhaustSmoke_0)
	{
		return exhaustSmoke_0.ToUInt32();
	}

	public static explicit operator ExhaustSmoke(uint uint_0)
	{
		return smethod_0(uint_0);
	}

	public static ExhaustSmoke FromByteArray(byte[] byte_1, int int_0)
	{
		if (byte_1 == null)
		{
			throw new ArgumentNullException("array");
		}
		if (int_0 < 0 || int_0 > byte_1.Length - 1 || int_0 + 4 > byte_1.Length - 1)
		{
			throw new IndexOutOfRangeException();
		}
		return smethod_0(BitConverter.ToUInt32(byte_1, int_0));
	}

	public static ExhaustSmoke smethod_0(uint uint_0)
	{
		ExhaustSmoke result = default(ExhaustSmoke);
		uint num = (uint_0 & 0xFF0000) >> 16;
		result.Opacity = (byte)num;
		result.Attached = (AttachedValue)((uint_0 & 0x1000000) >> 24);
		result.Chemical = (ChemicalValue)((uint_0 & 0x6000000) >> 25);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is ExhaustSmoke)
		{
			return Equals((ExhaustSmoke)obj);
		}
		return false;
	}

	public bool Equals(ExhaustSmoke exhaustSmoke_0)
	{
		if ((object)exhaustSmoke_0 == null)
		{
			return false;
		}
		if (Opacity == exhaustSmoke_0.Opacity && Attached == exhaustSmoke_0.Attached)
		{
			return Chemical == exhaustSmoke_0.Chemical;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return 0u | (uint)(Opacity << 16) | ((uint)Attached << 24) | ((uint)Chemical << 25);
	}

	public override int GetHashCode()
	{
		return ((493 + Opacity.GetHashCode()) * 29 + Attached.GetHashCode()) * 29 + Chemical.GetHashCode();
	}
}
