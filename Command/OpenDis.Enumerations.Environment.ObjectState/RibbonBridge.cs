using System;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
public struct RibbonBridge
{
	private byte byte_0;

	public byte NumOfSegments
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

	public static bool operator !=(RibbonBridge ribbonBridge_0, RibbonBridge ribbonBridge_1)
	{
		return !(ribbonBridge_0 == ribbonBridge_1);
	}

	public static bool operator ==(RibbonBridge ribbonBridge_0, RibbonBridge ribbonBridge_1)
	{
		if ((object)ribbonBridge_0 == (object)ribbonBridge_1)
		{
			return true;
		}
		if ((object)ribbonBridge_0 != null && (object)ribbonBridge_1 != null)
		{
			return ribbonBridge_0.Equals(ribbonBridge_1);
		}
		return false;
	}

	public static explicit operator uint(RibbonBridge ribbonBridge_0)
	{
		return ribbonBridge_0.ToUInt32();
	}

	public static explicit operator RibbonBridge(uint uint_0)
	{
		return smethod_0(uint_0);
	}

	public static RibbonBridge FromByteArray(byte[] byte_1, int int_0)
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

	public static RibbonBridge smethod_0(uint uint_0)
	{
		RibbonBridge result = default(RibbonBridge);
		uint num = (uint_0 & 0xFF0000) >> 16;
		result.NumOfSegments = (byte)num;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is RibbonBridge)
		{
			return Equals((RibbonBridge)obj);
		}
		return false;
	}

	public bool Equals(RibbonBridge ribbonBridge_0)
	{
		if ((object)ribbonBridge_0 == null)
		{
			return false;
		}
		return NumOfSegments == ribbonBridge_0.NumOfSegments;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return 0u | (uint)(NumOfSegments << 16);
	}

	public override int GetHashCode()
	{
		return 493 + NumOfSegments.GetHashCode();
	}
}
