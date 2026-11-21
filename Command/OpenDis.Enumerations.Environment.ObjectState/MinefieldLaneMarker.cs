using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
public struct MinefieldLaneMarker
{
	[Description("Describes the side of the lane marker which is visible.")]
	public enum VisibleSideValue : uint
	{
		LeftSideIsVisible,
		RightSideIsVisible,
		BothSidesAreVisible,
		Unknown
	}

	private VisibleSideValue visibleSideValue_0;

	public VisibleSideValue VisibleSide
	{
		get
		{
			return visibleSideValue_0;
		}
		set
		{
			visibleSideValue_0 = value;
		}
	}

	public static bool operator !=(MinefieldLaneMarker minefieldLaneMarker_0, MinefieldLaneMarker minefieldLaneMarker_1)
	{
		return !(minefieldLaneMarker_0 == minefieldLaneMarker_1);
	}

	public static bool operator ==(MinefieldLaneMarker minefieldLaneMarker_0, MinefieldLaneMarker minefieldLaneMarker_1)
	{
		if ((object)minefieldLaneMarker_0 == (object)minefieldLaneMarker_1)
		{
			return true;
		}
		if ((object)minefieldLaneMarker_0 != null && (object)minefieldLaneMarker_1 != null)
		{
			return minefieldLaneMarker_0.Equals(minefieldLaneMarker_1);
		}
		return false;
	}

	public static explicit operator uint(MinefieldLaneMarker minefieldLaneMarker_0)
	{
		return minefieldLaneMarker_0.ToUInt32();
	}

	public static explicit operator MinefieldLaneMarker(uint uint_0)
	{
		return smethod_0(uint_0);
	}

	public static MinefieldLaneMarker FromByteArray(byte[] byte_0, int int_0)
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

	public static MinefieldLaneMarker smethod_0(uint uint_0)
	{
		MinefieldLaneMarker result = default(MinefieldLaneMarker);
		result.VisibleSide = (VisibleSideValue)((uint_0 & 0x30000) >> 16);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is MinefieldLaneMarker)
		{
			return Equals((MinefieldLaneMarker)obj);
		}
		return false;
	}

	public bool Equals(MinefieldLaneMarker minefieldLaneMarker_0)
	{
		if ((object)minefieldLaneMarker_0 == null)
		{
			return false;
		}
		return VisibleSide == minefieldLaneMarker_0.VisibleSide;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return 0u | ((uint)VisibleSide << 16);
	}

	public override int GetHashCode()
	{
		return 493 + VisibleSide.GetHashCode();
	}
}
