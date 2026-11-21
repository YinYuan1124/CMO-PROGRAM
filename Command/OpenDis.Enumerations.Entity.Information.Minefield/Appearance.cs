using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Information.Minefield;

[Serializable]
public struct Appearance
{
	[Description("Identifies the type of minefield")]
	public enum MinefieldTypeValue : uint
	{
		MixedAntiPersonnelAndAntiTankMinefield,
		PureAntiPersonnelMinefield,
		PureAntiTankMinefield,
		Unknown
	}

	[Description("Identifies the active status of the minefield")]
	public enum ActiveStatusValue : uint
	{
		Active,
		Inactive
	}

	[Description("Identifies whether the minefield has an active lane")]
	public enum LaneValue : uint
	{
		MinefieldHasActiveLane,
		MinefieldHasAnInactiveLane
	}

	[Description("Describes the state of the minefield")]
	public enum StateValue : uint
	{
		Active,
		Deactivated
	}

	private MinefieldTypeValue minefieldTypeValue_0;

	private ActiveStatusValue activeStatusValue_0;

	private LaneValue laneValue_0;

	private StateValue stateValue_0;

	public MinefieldTypeValue MinefieldType
	{
		get
		{
			return minefieldTypeValue_0;
		}
		set
		{
			minefieldTypeValue_0 = value;
		}
	}

	public ActiveStatusValue ActiveStatus
	{
		get
		{
			return activeStatusValue_0;
		}
		set
		{
			activeStatusValue_0 = value;
		}
	}

	public LaneValue Lane
	{
		get
		{
			return laneValue_0;
		}
		set
		{
			laneValue_0 = value;
		}
	}

	public StateValue State
	{
		get
		{
			return stateValue_0;
		}
		set
		{
			stateValue_0 = value;
		}
	}

	public static bool operator !=(Appearance appearance_0, Appearance appearance_1)
	{
		return !(appearance_0 == appearance_1);
	}

	public static bool operator ==(Appearance appearance_0, Appearance appearance_1)
	{
		if ((object)appearance_0 == (object)appearance_1)
		{
			return true;
		}
		if ((object)appearance_0 != null && (object)appearance_1 != null)
		{
			return appearance_0.Equals(appearance_1);
		}
		return false;
	}

	public static explicit operator ushort(Appearance appearance_0)
	{
		return appearance_0.ToUInt16();
	}

	public static explicit operator Appearance(ushort ushort_0)
	{
		return smethod_0(ushort_0);
	}

	public static Appearance FromByteArray(byte[] byte_0, int int_0)
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

	public static Appearance smethod_0(ushort ushort_0)
	{
		Appearance result = default(Appearance);
		result.MinefieldType = (MinefieldTypeValue)(ushort_0 & 3);
		result.ActiveStatus = (ActiveStatusValue)((uint)(ushort_0 & 4) >> 2);
		result.Lane = (LaneValue)((uint)(ushort_0 & 8) >> 3);
		result.State = (StateValue)((uint)(ushort_0 & 0x2000) >> 13);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is Appearance)
		{
			return Equals((Appearance)obj);
		}
		return false;
	}

	public bool Equals(Appearance appearance_0)
	{
		if ((object)appearance_0 == null)
		{
			return false;
		}
		if (MinefieldType == appearance_0.MinefieldType && ActiveStatus == appearance_0.ActiveStatus && Lane == appearance_0.Lane)
		{
			return State == appearance_0.State;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt16());
	}

	public ushort ToUInt16()
	{
		return (ushort)((ushort)((ushort)((ushort)(0u | (ushort)MinefieldType) | (ushort)((uint)ActiveStatus << 2)) | (ushort)((uint)Lane << 3)) | (ushort)((uint)State << 13));
	}

	public override int GetHashCode()
	{
		return (((493 + MinefieldType.GetHashCode()) * 29 + ActiveStatus.GetHashCode()) * 29 + Lane.GetHashCode()) * 29 + State.GetHashCode();
	}
}
