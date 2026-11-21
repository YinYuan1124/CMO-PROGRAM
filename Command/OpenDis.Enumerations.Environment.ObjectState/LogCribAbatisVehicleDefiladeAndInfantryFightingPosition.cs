using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
public struct LogCribAbatisVehicleDefiladeAndInfantryFightingPosition
{
	[Description("Describes the breached appearance of the object")]
	public enum BreachValue : uint
	{
		NoBreaching,
		Breached,
		Cleared,
		Unknown
	}

	private BreachValue breachValue_0;

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

	public static bool operator !=(LogCribAbatisVehicleDefiladeAndInfantryFightingPosition logCribAbatisVehicleDefiladeAndInfantryFightingPosition_0, LogCribAbatisVehicleDefiladeAndInfantryFightingPosition logCribAbatisVehicleDefiladeAndInfantryFightingPosition_1)
	{
		return !(logCribAbatisVehicleDefiladeAndInfantryFightingPosition_0 == logCribAbatisVehicleDefiladeAndInfantryFightingPosition_1);
	}

	public static bool operator ==(LogCribAbatisVehicleDefiladeAndInfantryFightingPosition logCribAbatisVehicleDefiladeAndInfantryFightingPosition_0, LogCribAbatisVehicleDefiladeAndInfantryFightingPosition logCribAbatisVehicleDefiladeAndInfantryFightingPosition_1)
	{
		if ((object)logCribAbatisVehicleDefiladeAndInfantryFightingPosition_0 == (object)logCribAbatisVehicleDefiladeAndInfantryFightingPosition_1)
		{
			return true;
		}
		if ((object)logCribAbatisVehicleDefiladeAndInfantryFightingPosition_0 != null && (object)logCribAbatisVehicleDefiladeAndInfantryFightingPosition_1 != null)
		{
			return logCribAbatisVehicleDefiladeAndInfantryFightingPosition_0.Equals(logCribAbatisVehicleDefiladeAndInfantryFightingPosition_1);
		}
		return false;
	}

	public static explicit operator uint(LogCribAbatisVehicleDefiladeAndInfantryFightingPosition logCribAbatisVehicleDefiladeAndInfantryFightingPosition_0)
	{
		return logCribAbatisVehicleDefiladeAndInfantryFightingPosition_0.ToUInt32();
	}

	public static explicit operator LogCribAbatisVehicleDefiladeAndInfantryFightingPosition(uint uint_0)
	{
		return smethod_0(uint_0);
	}

	public static LogCribAbatisVehicleDefiladeAndInfantryFightingPosition FromByteArray(byte[] byte_0, int int_0)
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

	public static LogCribAbatisVehicleDefiladeAndInfantryFightingPosition smethod_0(uint uint_0)
	{
		LogCribAbatisVehicleDefiladeAndInfantryFightingPosition result = default(LogCribAbatisVehicleDefiladeAndInfantryFightingPosition);
		result.Breach = (BreachValue)((uint_0 & 0x30000) >> 16);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is LogCribAbatisVehicleDefiladeAndInfantryFightingPosition)
		{
			return Equals((LogCribAbatisVehicleDefiladeAndInfantryFightingPosition)obj);
		}
		return false;
	}

	public bool Equals(LogCribAbatisVehicleDefiladeAndInfantryFightingPosition logCribAbatisVehicleDefiladeAndInfantryFightingPosition_0)
	{
		if ((object)logCribAbatisVehicleDefiladeAndInfantryFightingPosition_0 == null)
		{
			return false;
		}
		return Breach == logCribAbatisVehicleDefiladeAndInfantryFightingPosition_0.Breach;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return 0u | ((uint)Breach << 16);
	}

	public override int GetHashCode()
	{
		return 493 + Breach.GetHashCode();
	}
}
