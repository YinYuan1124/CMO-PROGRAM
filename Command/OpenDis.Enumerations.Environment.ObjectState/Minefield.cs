using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
public struct Minefield
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

	private int int_0;

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

	public int MineCount
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public static bool operator !=(Minefield minefield_0, Minefield minefield_1)
	{
		return !(minefield_0 == minefield_1);
	}

	public static bool operator ==(Minefield minefield_0, Minefield minefield_1)
	{
		if ((object)minefield_0 == (object)minefield_1)
		{
			return true;
		}
		if ((object)minefield_0 != null && (object)minefield_1 != null)
		{
			return minefield_0.Equals(minefield_1);
		}
		return false;
	}

	public static explicit operator uint(Minefield minefield_0)
	{
		return minefield_0.ToUInt32();
	}

	public static explicit operator Minefield(uint uint_0)
	{
		return smethod_0(uint_0);
	}

	public static Minefield FromByteArray(byte[] byte_0, int int_1)
	{
		if (byte_0 == null)
		{
			throw new ArgumentNullException("array");
		}
		if (int_1 < 0 || int_1 > byte_0.Length - 1 || int_1 + 4 > byte_0.Length - 1)
		{
			throw new IndexOutOfRangeException();
		}
		return smethod_0(BitConverter.ToUInt32(byte_0, int_1));
	}

	public static Minefield smethod_0(uint uint_0)
	{
		Minefield result = default(Minefield);
		result.Breach = (BreachValue)((uint_0 & 0x30000) >> 16);
		result.MineCount = (int)((uint_0 & 0x80000000u) >> 31);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is Minefield)
		{
			return Equals((Minefield)obj);
		}
		return false;
	}

	public bool Equals(Minefield minefield_0)
	{
		if ((object)minefield_0 == null)
		{
			return false;
		}
		if (Breach == minefield_0.Breach)
		{
			return MineCount == minefield_0.MineCount;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return 0u | ((uint)Breach << 16) | (uint)(MineCount << 31);
	}

	public override int GetHashCode()
	{
		return (493 + Breach.GetHashCode()) * 29 + MineCount.GetHashCode();
	}
}
