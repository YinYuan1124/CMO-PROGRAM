using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Information.Minefield;

[Serializable]
public struct Fusing
{
	[Description("Identifies the type of the primary fuse")]
	public enum PrimaryValue : uint
	{
		NoFuse,
		Other,
		Pressure,
		Magnetic,
		TiltRod,
		Command,
		TripWire
	}

	[Description("Identifies the type of the secondary fuse")]
	public enum SecondaryValue : uint
	{
		NoFuse,
		Other,
		Pressure,
		Magnetic,
		TiltRod,
		Command,
		TripWire
	}

	[Description("Describes the anti-handling device status of the mine")]
	public enum AHDValue : uint
	{
		NoAntiHandlingDevice,
		AntiHandlingDevice
	}

	private PrimaryValue primaryValue_0;

	private SecondaryValue secondaryValue_0;

	private AHDValue ahdvalue_0;

	public PrimaryValue Primary
	{
		get
		{
			return primaryValue_0;
		}
		set
		{
			primaryValue_0 = value;
		}
	}

	public SecondaryValue Secondary
	{
		get
		{
			return secondaryValue_0;
		}
		set
		{
			secondaryValue_0 = value;
		}
	}

	public AHDValue AHD
	{
		get
		{
			return ahdvalue_0;
		}
		set
		{
			ahdvalue_0 = value;
		}
	}

	public static bool operator !=(Fusing fusing_0, Fusing fusing_1)
	{
		return !(fusing_0 == fusing_1);
	}

	public static bool operator ==(Fusing fusing_0, Fusing fusing_1)
	{
		if ((object)fusing_0 == (object)fusing_1)
		{
			return true;
		}
		if ((object)fusing_0 != null && (object)fusing_1 != null)
		{
			return fusing_0.Equals(fusing_1);
		}
		return false;
	}

	public static explicit operator ushort(Fusing fusing_0)
	{
		return fusing_0.ToUInt16();
	}

	public static explicit operator Fusing(ushort ushort_0)
	{
		return smethod_0(ushort_0);
	}

	public static Fusing FromByteArray(byte[] byte_0, int int_0)
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

	public static Fusing smethod_0(ushort ushort_0)
	{
		Fusing result = default(Fusing);
		result.Primary = (PrimaryValue)(ushort_0 & 0x7F);
		result.Secondary = (SecondaryValue)((uint)(ushort_0 & 0x3F80) >> 7);
		result.AHD = (AHDValue)((uint)(ushort_0 & 0x10) >> 4);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is Fusing)
		{
			return Equals((Fusing)obj);
		}
		return false;
	}

	public bool Equals(Fusing fusing_0)
	{
		if ((object)fusing_0 == null)
		{
			return false;
		}
		if (Primary == fusing_0.Primary && Secondary == fusing_0.Secondary)
		{
			return AHD == fusing_0.AHD;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt16());
	}

	public ushort ToUInt16()
	{
		return (ushort)((ushort)((ushort)(0u | (ushort)Primary) | (ushort)((uint)Secondary << 7)) | (ushort)((uint)AHD << 4));
	}

	public override int GetHashCode()
	{
		return ((493 + Primary.GetHashCode()) * 29 + Secondary.GetHashCode()) * 29 + AHD.GetHashCode();
	}
}
