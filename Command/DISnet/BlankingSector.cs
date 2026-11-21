using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class BlankingSector
{
	private uint uint_0 = 3500u;

	private ushort ushort_0;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "recordType")]
	public uint RecordType
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "recordLength")]
	public ushort RecordLength
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "emitterNumber")]
	public byte EmitterNumber
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

	[XmlElement(Type = typeof(byte), ElementName = "beamNumber")]
	public byte BeamNumber
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

	[XmlElement(Type = typeof(byte), ElementName = "stateIndicator")]
	public byte StateIndicator
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

	[XmlElement(Type = typeof(float), ElementName = "leftAzimuth")]
	public float LeftAzimuth
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "rightAzimuth")]
	public float RightAzimuth
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "lowerElevation")]
	public float LowerElevation
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "upperElevation")]
	public float UpperElevation
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "residualPower")]
	public float ResidualPower
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
		}
	}

	public event Action<Exception> Exception
	{
		[CompilerGenerated]
		add
		{
			Action<Exception> action = action_0;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<Exception> action = action_0;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static bool operator !=(BlankingSector blankingSector_0, BlankingSector blankingSector_1)
	{
		return !(blankingSector_0 == blankingSector_1);
	}

	public static bool operator ==(BlankingSector blankingSector_0, BlankingSector blankingSector_1)
	{
		if ((object)blankingSector_0 == blankingSector_1)
		{
			return true;
		}
		if ((object)blankingSector_0 != null && (object)blankingSector_1 != null)
		{
			return blankingSector_0.Equals(blankingSector_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 29;
	}

	protected void OnException(Exception exception_0)
	{
		if (action_0 != null)
		{
			action_0(exception_0);
		}
	}

	public virtual void Marshal(DataOutputStream dataOutputStream_0)
	{
		if (dataOutputStream_0 != null)
		{
			try
			{
				dataOutputStream_0.WriteUnsignedInt(uint_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
				dataOutputStream_0.WriteUnsignedByte(byte_0);
				dataOutputStream_0.WriteUnsignedByte(byte_1);
				dataOutputStream_0.WriteUnsignedByte(byte_2);
				dataOutputStream_0.WriteFloat(float_0);
				dataOutputStream_0.WriteFloat(float_1);
				dataOutputStream_0.WriteFloat(float_2);
				dataOutputStream_0.WriteFloat(float_3);
				dataOutputStream_0.WriteFloat(float_4);
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Unmarshal(DataInputStream dataInputStream_0)
	{
		if (dataInputStream_0 != null)
		{
			try
			{
				uint_0 = dataInputStream_0.ReadUnsignedInt();
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
				byte_0 = dataInputStream_0.ReadUnsignedByte();
				byte_1 = dataInputStream_0.ReadUnsignedByte();
				byte_2 = dataInputStream_0.ReadUnsignedByte();
				float_0 = dataInputStream_0.ReadFloat();
				float_1 = dataInputStream_0.ReadFloat();
				float_2 = dataInputStream_0.ReadFloat();
				float_3 = dataInputStream_0.ReadFloat();
				float_4 = dataInputStream_0.ReadFloat();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<BlankingSector>");
		try
		{
			stringBuilder_0.AppendLine("<recordType type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			stringBuilder_0.AppendLine("<recordLength type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
			stringBuilder_0.AppendLine("<emitterNumber type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</emitterNumber>");
			stringBuilder_0.AppendLine("<beamNumber type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</beamNumber>");
			stringBuilder_0.AppendLine("<stateIndicator type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</stateIndicator>");
			stringBuilder_0.AppendLine("<leftAzimuth type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</leftAzimuth>");
			stringBuilder_0.AppendLine("<rightAzimuth type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</rightAzimuth>");
			stringBuilder_0.AppendLine("<lowerElevation type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</lowerElevation>");
			stringBuilder_0.AppendLine("<upperElevation type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</upperElevation>");
			stringBuilder_0.AppendLine("<residualPower type=\"float\">" + float_4.ToString(CultureInfo.InvariantCulture) + "</residualPower>");
			stringBuilder_0.AppendLine("</BlankingSector>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as BlankingSector;
	}

	public bool Equals(BlankingSector blankingSector_0)
	{
		bool result = true;
		if (blankingSector_0.GetType() == GetType())
		{
			if (uint_0 != blankingSector_0.uint_0)
			{
				result = false;
			}
			if (ushort_0 != blankingSector_0.ushort_0)
			{
				result = false;
			}
			if (byte_0 != blankingSector_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != blankingSector_0.byte_1)
			{
				result = false;
			}
			if (byte_2 != blankingSector_0.byte_2)
			{
				result = false;
			}
			if (float_0 != blankingSector_0.float_0)
			{
				result = false;
			}
			if (float_1 != blankingSector_0.float_1)
			{
				result = false;
			}
			if (float_2 != blankingSector_0.float_2)
			{
				result = false;
			}
			if (float_3 != blankingSector_0.float_3)
			{
				result = false;
			}
			if (float_4 != blankingSector_0.float_4)
			{
				result = false;
			}
			return result;
		}
		return false;
	}

	private static int smethod_0(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode()) ^ float_3.GetHashCode()) ^ float_4.GetHashCode();
	}
}
