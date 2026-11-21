using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public struct RadioSignalEncoding
{
	[Description("Encoding type")]
	public enum EncodingTypeValue : uint
	{
		_8BitMuLaw = 1u,
		const_1,
		ADPCMPerCCITTG721,
		_16BitLinearPCM,
		_8BitLinearPCM,
		const_5
	}

	[Description("Encoding class")]
	public enum EncodingClassValue : uint
	{
		EncodedAudio,
		RawBinaryData,
		ApplicationSpecificData,
		DatabaseIndex
	}

	private EncodingTypeValue encodingTypeValue_0;

	private EncodingClassValue encodingClassValue_0;

	public EncodingTypeValue EncodingType
	{
		get
		{
			return encodingTypeValue_0;
		}
		set
		{
			encodingTypeValue_0 = value;
		}
	}

	public EncodingClassValue EncodingClass
	{
		get
		{
			return encodingClassValue_0;
		}
		set
		{
			encodingClassValue_0 = value;
		}
	}

	public static bool operator !=(RadioSignalEncoding radioSignalEncoding_0, RadioSignalEncoding radioSignalEncoding_1)
	{
		return !(radioSignalEncoding_0 == radioSignalEncoding_1);
	}

	public static bool operator ==(RadioSignalEncoding radioSignalEncoding_0, RadioSignalEncoding radioSignalEncoding_1)
	{
		if ((object)radioSignalEncoding_0 == (object)radioSignalEncoding_1)
		{
			return true;
		}
		if ((object)radioSignalEncoding_0 != null && (object)radioSignalEncoding_1 != null)
		{
			return radioSignalEncoding_0.Equals(radioSignalEncoding_1);
		}
		return false;
	}

	public static explicit operator ushort(RadioSignalEncoding radioSignalEncoding_0)
	{
		return radioSignalEncoding_0.ToUInt16();
	}

	public static explicit operator RadioSignalEncoding(ushort ushort_0)
	{
		return smethod_0(ushort_0);
	}

	public static RadioSignalEncoding FromByteArray(byte[] byte_0, int int_0)
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

	public static RadioSignalEncoding smethod_0(ushort ushort_0)
	{
		RadioSignalEncoding result = default(RadioSignalEncoding);
		result.EncodingType = (EncodingTypeValue)(ushort_0 & 0x3FFF);
		result.EncodingClass = (EncodingClassValue)((uint)(ushort_0 & 0xC000) >> 14);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is RadioSignalEncoding)
		{
			return Equals((RadioSignalEncoding)obj);
		}
		return false;
	}

	public bool Equals(RadioSignalEncoding radioSignalEncoding_0)
	{
		if ((object)radioSignalEncoding_0 == null)
		{
			return false;
		}
		if (EncodingType == radioSignalEncoding_0.EncodingType)
		{
			return EncodingClass == radioSignalEncoding_0.EncodingClass;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt16());
	}

	public ushort ToUInt16()
	{
		return (ushort)((ushort)(0u | (ushort)EncodingType) | (ushort)((uint)EncodingClass << 14));
	}

	public override int GetHashCode()
	{
		return (493 + EncodingType.GetHashCode()) * 29 + EncodingClass.GetHashCode();
	}
}
