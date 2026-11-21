using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
public struct GeneralAppearance
{
	[Description("Describes the damaged appearance of the object")]
	public enum DamageValue : uint
	{
		NoDamage,
		Damaged,
		Destroyed,
		Unknown
	}

	[Description("Describes whether the object was predistributed")]
	public enum PredistributedValue : uint
	{
		ObjectCreatedDuringTheExercise,
		ObjectPredistributedPriorToExerciseStart
	}

	[Description("Describes the state of the object")]
	public enum StateValue : uint
	{
		Active,
		Deactivated
	}

	[Description("Describes whether smoke is rising from an object")]
	public enum SmokingValue : uint
	{
		None,
		SmokePresent
	}

	[Description("Describes whether flames are rising from an object")]
	public enum FlamingValue : uint
	{
		None,
		FlamesPresent
	}

	private byte byte_0;

	private DamageValue damageValue_0;

	private PredistributedValue predistributedValue_0;

	private StateValue stateValue_0;

	private SmokingValue smokingValue_0;

	private FlamingValue flamingValue_0;

	public byte PercentComplete
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

	public DamageValue Damage
	{
		get
		{
			return damageValue_0;
		}
		set
		{
			damageValue_0 = value;
		}
	}

	public PredistributedValue Predistributed
	{
		get
		{
			return predistributedValue_0;
		}
		set
		{
			predistributedValue_0 = value;
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

	public SmokingValue Smoking
	{
		get
		{
			return smokingValue_0;
		}
		set
		{
			smokingValue_0 = value;
		}
	}

	public FlamingValue Flaming
	{
		get
		{
			return flamingValue_0;
		}
		set
		{
			flamingValue_0 = value;
		}
	}

	public static bool operator !=(GeneralAppearance generalAppearance_0, GeneralAppearance generalAppearance_1)
	{
		return !(generalAppearance_0 == generalAppearance_1);
	}

	public static bool operator ==(GeneralAppearance generalAppearance_0, GeneralAppearance generalAppearance_1)
	{
		if ((object)generalAppearance_0 == (object)generalAppearance_1)
		{
			return true;
		}
		if ((object)generalAppearance_0 != null && (object)generalAppearance_1 != null)
		{
			return generalAppearance_0.Equals(generalAppearance_1);
		}
		return false;
	}

	public static explicit operator ushort(GeneralAppearance generalAppearance_0)
	{
		return generalAppearance_0.ToUInt16();
	}

	public static explicit operator GeneralAppearance(ushort ushort_0)
	{
		return smethod_0(ushort_0);
	}

	public static GeneralAppearance FromByteArray(byte[] byte_1, int int_0)
	{
		if (byte_1 == null)
		{
			throw new ArgumentNullException("array");
		}
		if (int_0 < 0 || int_0 > byte_1.Length - 1 || int_0 + 2 > byte_1.Length - 1)
		{
			throw new IndexOutOfRangeException();
		}
		return smethod_0(BitConverter.ToUInt16(byte_1, int_0));
	}

	public static GeneralAppearance smethod_0(ushort ushort_0)
	{
		GeneralAppearance result = default(GeneralAppearance);
		uint num = ushort_0 & 0xFFu;
		result.PercentComplete = (byte)num;
		result.Damage = (DamageValue)((uint)(ushort_0 & 0x300) >> 8);
		result.Predistributed = (PredistributedValue)((uint)(ushort_0 & 0x400) >> 10);
		result.State = (StateValue)((uint)(ushort_0 & 0x800) >> 11);
		result.Smoking = (SmokingValue)((uint)(ushort_0 & 0x1000) >> 12);
		result.Flaming = (FlamingValue)((uint)(ushort_0 & 0x2000) >> 13);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is GeneralAppearance)
		{
			return Equals((GeneralAppearance)obj);
		}
		return false;
	}

	public bool Equals(GeneralAppearance generalAppearance_0)
	{
		if ((object)generalAppearance_0 == null)
		{
			return false;
		}
		if (PercentComplete == generalAppearance_0.PercentComplete && Damage == generalAppearance_0.Damage && Predistributed == generalAppearance_0.Predistributed && State == generalAppearance_0.State && Smoking == generalAppearance_0.Smoking)
		{
			return Flaming == generalAppearance_0.Flaming;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt16());
	}

	public ushort ToUInt16()
	{
		return (ushort)((ushort)((ushort)((ushort)((ushort)((ushort)(0u | PercentComplete) | (ushort)((uint)Damage << 8)) | (ushort)((uint)Predistributed << 10)) | (ushort)((uint)State << 11)) | (ushort)((uint)Smoking << 12)) | (ushort)((uint)Flaming << 13));
	}

	public override int GetHashCode()
	{
		return (((((493 + PercentComplete.GetHashCode()) * 29 + Damage.GetHashCode()) * 29 + Predistributed.GetHashCode()) * 29 + State.GetHashCode()) * 29 + Smoking.GetHashCode()) * 29 + Flaming.GetHashCode();
	}
}
