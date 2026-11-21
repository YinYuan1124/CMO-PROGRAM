using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Information.Minefield;

[Serializable]
public struct ProtocolMode
{
	[Description("Protocol Mode")]
	public enum ProtocolModeValue : uint
	{
		HeartbeatMode,
		QRPMode,
		Unknown
	}

	private ProtocolModeValue protocolModeValue_0;

	public ProtocolModeValue Value
	{
		get
		{
			return protocolModeValue_0;
		}
		set
		{
			protocolModeValue_0 = value;
		}
	}

	public static bool operator !=(ProtocolMode protocolMode_0, ProtocolMode protocolMode_1)
	{
		return !(protocolMode_0 == protocolMode_1);
	}

	public static bool operator ==(ProtocolMode protocolMode_0, ProtocolMode protocolMode_1)
	{
		if ((object)protocolMode_0 == (object)protocolMode_1)
		{
			return true;
		}
		if ((object)protocolMode_0 != null && (object)protocolMode_1 != null)
		{
			return protocolMode_0.Equals(protocolMode_1);
		}
		return false;
	}

	public static explicit operator uint(ProtocolMode protocolMode_0)
	{
		return protocolMode_0.ToUInt32();
	}

	public static explicit operator ProtocolMode(uint uint_0)
	{
		return smethod_0(uint_0);
	}

	public static ProtocolMode FromByteArray(byte[] byte_0, int int_0)
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

	public static ProtocolMode smethod_0(uint uint_0)
	{
		ProtocolMode result = default(ProtocolMode);
		result.Value = (ProtocolModeValue)(uint_0 & 3u);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is ProtocolMode)
		{
			return Equals((ProtocolMode)obj);
		}
		return false;
	}

	public bool Equals(ProtocolMode protocolMode_0)
	{
		if ((object)protocolMode_0 == null)
		{
			return false;
		}
		return Value == protocolMode_0.Value;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return (uint)(ProtocolModeValue.HeartbeatMode | Value);
	}

	public override int GetHashCode()
	{
		return 493 + Value.GetHashCode();
	}
}
