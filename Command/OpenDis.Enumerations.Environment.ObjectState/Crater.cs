using System;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
public struct Crater
{
	private byte byte_0;

	public byte Size
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

	public static bool operator !=(Crater crater_0, Crater crater_1)
	{
		return !(crater_0 == crater_1);
	}

	public static bool operator ==(Crater crater_0, Crater crater_1)
	{
		if ((object)crater_0 == (object)crater_1)
		{
			return true;
		}
		if ((object)crater_0 != null && (object)crater_1 != null)
		{
			return crater_0.Equals(crater_1);
		}
		return false;
	}

	public static explicit operator uint(Crater crater_0)
	{
		return crater_0.ToUInt32();
	}

	public static explicit operator Crater(uint uint_0)
	{
		return smethod_0(uint_0);
	}

	public static Crater FromByteArray(byte[] byte_1, int int_0)
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

	public static Crater smethod_0(uint uint_0)
	{
		Crater result = default(Crater);
		uint num = (uint_0 & 0xFF0000) >> 16;
		result.Size = (byte)num;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is Crater)
		{
			return Equals((Crater)obj);
		}
		return false;
	}

	public bool Equals(Crater crater_0)
	{
		if ((object)crater_0 == null)
		{
			return false;
		}
		return Size == crater_0.Size;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return 0u | (uint)(Size << 16);
	}

	public override int GetHashCode()
	{
		return 493 + Size.GetHashCode();
	}
}
