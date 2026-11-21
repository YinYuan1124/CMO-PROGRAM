using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
public struct AirBurstAndGroundBurst
{
	[Description("Describes the chemical content of the smoke")]
	public enum ChemicalValue : uint
	{
		Other,
		Hydrochloric,
		WhitePhosphorous,
		RedPhosphorous
	}

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

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

	public byte Size
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

	public byte Height
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

	public byte NumOfBursts
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

	public static bool operator !=(AirBurstAndGroundBurst airBurstAndGroundBurst_0, AirBurstAndGroundBurst airBurstAndGroundBurst_1)
	{
		return !(airBurstAndGroundBurst_0 == airBurstAndGroundBurst_1);
	}

	public static bool operator ==(AirBurstAndGroundBurst airBurstAndGroundBurst_0, AirBurstAndGroundBurst airBurstAndGroundBurst_1)
	{
		if ((object)airBurstAndGroundBurst_0 == (object)airBurstAndGroundBurst_1)
		{
			return true;
		}
		if ((object)airBurstAndGroundBurst_0 != null && (object)airBurstAndGroundBurst_1 != null)
		{
			return airBurstAndGroundBurst_0.Equals(airBurstAndGroundBurst_1);
		}
		return false;
	}

	public static explicit operator uint(AirBurstAndGroundBurst airBurstAndGroundBurst_0)
	{
		return airBurstAndGroundBurst_0.ToUInt32();
	}

	public static explicit operator AirBurstAndGroundBurst(uint uint_0)
	{
		return smethod_0(uint_0);
	}

	public static AirBurstAndGroundBurst FromByteArray(byte[] byte_4, int int_0)
	{
		if (byte_4 == null)
		{
			throw new ArgumentNullException("array");
		}
		if (int_0 < 0 || int_0 > byte_4.Length - 1 || int_0 + 4 > byte_4.Length - 1)
		{
			throw new IndexOutOfRangeException();
		}
		return smethod_0(BitConverter.ToUInt32(byte_4, int_0));
	}

	public static AirBurstAndGroundBurst smethod_0(uint uint_0)
	{
		AirBurstAndGroundBurst result = default(AirBurstAndGroundBurst);
		uint num = (uint_0 & 0xFF0000) >> 16;
		result.Opacity = (byte)num;
		uint num2 = (uint_0 & 0xFF000000u) >> 24;
		result.Size = (byte)num2;
		uint num3 = uint_0 & 0xFFu;
		result.Height = (byte)num3;
		uint num4 = (uint_0 & 0x3F00) >> 8;
		result.NumOfBursts = (byte)num4;
		result.Chemical = (ChemicalValue)((uint_0 & 0xC000) >> 14);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is AirBurstAndGroundBurst)
		{
			return Equals((AirBurstAndGroundBurst)obj);
		}
		return false;
	}

	public bool Equals(AirBurstAndGroundBurst airBurstAndGroundBurst_0)
	{
		if ((object)airBurstAndGroundBurst_0 == null)
		{
			return false;
		}
		if (Opacity == airBurstAndGroundBurst_0.Opacity && Size == airBurstAndGroundBurst_0.Size && Height == airBurstAndGroundBurst_0.Height && NumOfBursts == airBurstAndGroundBurst_0.NumOfBursts)
		{
			return Chemical == airBurstAndGroundBurst_0.Chemical;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return 0u | (uint)(Opacity << 16) | (uint)(Size << 24) | Height | (uint)(NumOfBursts << 8) | ((uint)Chemical << 14);
	}

	public override int GetHashCode()
	{
		return ((((493 + Opacity.GetHashCode()) * 29 + Size.GetHashCode()) * 29 + Height.GetHashCode()) * 29 + NumOfBursts.GetHashCode()) * 29 + Chemical.GetHashCode();
	}
}
