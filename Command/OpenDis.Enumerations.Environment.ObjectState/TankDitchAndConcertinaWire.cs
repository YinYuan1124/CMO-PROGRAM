using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
public struct TankDitchAndConcertinaWire
{
	[Description("Describes the breached appearance of the object")]
	public enum BreachValue : uint
	{
		NoBreaching,
		SlightBreaching,
		ModerateBreached,
		Cleared
	}

	[Description("Each bit indicates whether its associated segment is breached or not. Bit 40+i indicates whether the portion of the segment beginning at the segment origin + (i*Breach Length) and extending i* Breach Length meters is breached or not. For each bit:")]
	public enum BreachLocationValue : uint
	{
		AssociatedPortionOfSegmentIsNotBreached,
		AssociatedPortionOfSegmentIsBreached
	}

	private BreachValue breachValue_0;

	private byte byte_0;

	private BreachLocationValue breachLocationValue_0;

	public BreachValue Breach
	{
		get
		{
			return breachValue_0;
		}
		set
		{
			breachValue_0 = value;
		}
	}

	public byte BreachLength
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

	public BreachLocationValue BreachLocation
	{
		get
		{
			return breachLocationValue_0;
		}
		set
		{
			breachLocationValue_0 = value;
		}
	}

	public static bool operator !=(TankDitchAndConcertinaWire tankDitchAndConcertinaWire_0, TankDitchAndConcertinaWire tankDitchAndConcertinaWire_1)
	{
		return !(tankDitchAndConcertinaWire_0 == tankDitchAndConcertinaWire_1);
	}

	public static bool operator ==(TankDitchAndConcertinaWire tankDitchAndConcertinaWire_0, TankDitchAndConcertinaWire tankDitchAndConcertinaWire_1)
	{
		if ((object)tankDitchAndConcertinaWire_0 == (object)tankDitchAndConcertinaWire_1)
		{
			return true;
		}
		if ((object)tankDitchAndConcertinaWire_0 != null && (object)tankDitchAndConcertinaWire_1 != null)
		{
			return tankDitchAndConcertinaWire_0.Equals(tankDitchAndConcertinaWire_1);
		}
		return false;
	}

	public static explicit operator uint(TankDitchAndConcertinaWire tankDitchAndConcertinaWire_0)
	{
		return tankDitchAndConcertinaWire_0.ToUInt32();
	}

	public static explicit operator TankDitchAndConcertinaWire(uint uint_0)
	{
		return smethod_0(uint_0);
	}

	public static TankDitchAndConcertinaWire FromByteArray(byte[] byte_1, int int_0)
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

	public static TankDitchAndConcertinaWire smethod_0(uint uint_0)
	{
		TankDitchAndConcertinaWire result = default(TankDitchAndConcertinaWire);
		result.Breach = (BreachValue)((uint_0 & 0x30000) >> 16);
		uint num = uint_0 & 0xFFu;
		result.BreachLength = (byte)num;
		result.BreachLocation = (BreachLocationValue)((uint_0 & 0xFF00) >> 8);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is TankDitchAndConcertinaWire)
		{
			return Equals((TankDitchAndConcertinaWire)obj);
		}
		return false;
	}

	public bool Equals(TankDitchAndConcertinaWire tankDitchAndConcertinaWire_0)
	{
		if ((object)tankDitchAndConcertinaWire_0 == null)
		{
			return false;
		}
		if (Breach == tankDitchAndConcertinaWire_0.Breach && BreachLength == tankDitchAndConcertinaWire_0.BreachLength)
		{
			return BreachLocation == tankDitchAndConcertinaWire_0.BreachLocation;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return 0u | ((uint)Breach << 16) | BreachLength | ((uint)BreachLocation << 8);
	}

	public override int GetHashCode()
	{
		return ((493 + Breach.GetHashCode()) * 29 + BreachLength.GetHashCode()) * 29 + BreachLocation.GetHashCode();
	}
}
