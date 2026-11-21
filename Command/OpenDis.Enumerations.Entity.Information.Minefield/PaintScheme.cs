using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Information.Minefield;

[Serializable]
public struct PaintScheme
{
	[Description("Identifies the algae build-up on the mine")]
	public enum AlgaeValue : uint
	{
		None,
		Light,
		Moderate,
		Heavy
	}

	[Description("Identifies the paint scheme of the mine")]
	public enum PaintSchemeValue : uint
	{
		Other,
		Standard,
		CamouflageDesert,
		CamouflageJungle,
		CamouflageSnow,
		CamouflageGravel,
		CamouflagePavement,
		CamouflageSand,
		NaturalWood,
		Clear,
		Red,
		Blue,
		Green,
		Olive,
		White,
		Tan,
		Black,
		Yellow,
		Brown
	}

	private AlgaeValue algaeValue_0;

	private PaintSchemeValue paintSchemeValue_0;

	public AlgaeValue Algae
	{
		get
		{
			return algaeValue_0;
		}
		set
		{
			algaeValue_0 = value;
		}
	}

	public PaintSchemeValue Value
	{
		get
		{
			return paintSchemeValue_0;
		}
		set
		{
			paintSchemeValue_0 = value;
		}
	}

	public static bool operator !=(PaintScheme paintScheme_0, PaintScheme paintScheme_1)
	{
		return !(paintScheme_0 == paintScheme_1);
	}

	public static bool operator ==(PaintScheme paintScheme_0, PaintScheme paintScheme_1)
	{
		if ((object)paintScheme_0 == (object)paintScheme_1)
		{
			return true;
		}
		if ((object)paintScheme_0 != null && (object)paintScheme_1 != null)
		{
			return paintScheme_0.Equals(paintScheme_1);
		}
		return false;
	}

	public static explicit operator byte(PaintScheme paintScheme_0)
	{
		return paintScheme_0.ToByte();
	}

	public static explicit operator PaintScheme(byte byte_0)
	{
		return FromByte(byte_0);
	}

	public static PaintScheme FromByteArray(byte[] byte_0, int int_0)
	{
		if (byte_0 == null)
		{
			throw new ArgumentNullException("array");
		}
		if (int_0 < 0 || int_0 > byte_0.Length - 1 || int_0 + 1 > byte_0.Length - 1)
		{
			throw new IndexOutOfRangeException();
		}
		return FromByte(byte_0[int_0]);
	}

	public static PaintScheme FromByte(byte byte_0)
	{
		PaintScheme result = default(PaintScheme);
		result.Algae = (AlgaeValue)(byte_0 & 3);
		result.Value = (PaintSchemeValue)((uint)(byte_0 & 0xFC) >> 2);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is PaintScheme)
		{
			return Equals((PaintScheme)obj);
		}
		return false;
	}

	public bool Equals(PaintScheme paintScheme_0)
	{
		if ((object)paintScheme_0 == null)
		{
			return false;
		}
		if (Algae == paintScheme_0.Algae)
		{
			return Value == paintScheme_0.Value;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToByte());
	}

	public byte ToByte()
	{
		return (byte)((byte)(0u | (byte)Algae) | (byte)((uint)Value << 2));
	}

	public override int GetHashCode()
	{
		return (493 + Algae.GetHashCode()) * 29 + Value.GetHashCode();
	}
}
