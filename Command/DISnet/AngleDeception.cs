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
public class AngleDeception
{
	private uint uint_0 = 3501u;

	private ushort ushort_0 = 48;

	private ushort ushort_1;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private uint uint_1;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	private float float_6;

	private float float_7;

	private uint uint_2;

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

	[XmlElement(Type = typeof(ushort), ElementName = "padding")]
	public ushort Padding
	{
		get
		{
			return ushort_1;
		}
		set
		{
			ushort_1 = value;
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

	[XmlElement(Type = typeof(uint), ElementName = "padding2")]
	public uint Padding2
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "azimuthOffset")]
	public float AzimuthOffset
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

	[XmlElement(Type = typeof(float), ElementName = "azimuthWidth")]
	public float AzimuthWidth
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

	[XmlElement(Type = typeof(float), ElementName = "azimuthPullRate")]
	public float AzimuthPullRate
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

	[XmlElement(Type = typeof(float), ElementName = "azimuthPullAcceleration")]
	public float AzimuthPullAcceleration
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

	[XmlElement(Type = typeof(float), ElementName = "elevationOffset")]
	public float ElevationOffset
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

	[XmlElement(Type = typeof(float), ElementName = "elevationWidth")]
	public float ElevationWidth
	{
		get
		{
			return float_5;
		}
		set
		{
			float_5 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "elevationPullRate")]
	public float ElevationPullRate
	{
		get
		{
			return float_6;
		}
		set
		{
			float_6 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "elevationPullAcceleration")]
	public float ElevationPullAcceleration
	{
		get
		{
			return float_7;
		}
		set
		{
			float_7 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "padding3")]
	public uint Padding3
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
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

	public static bool operator !=(AngleDeception angleDeception_0, AngleDeception angleDeception_1)
	{
		return !(angleDeception_0 == angleDeception_1);
	}

	public static bool operator ==(AngleDeception angleDeception_0, AngleDeception angleDeception_1)
	{
		if ((object)angleDeception_0 == angleDeception_1)
		{
			return true;
		}
		if ((object)angleDeception_0 != null && (object)angleDeception_1 != null)
		{
			return angleDeception_0.Equals(angleDeception_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 51;
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
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
				dataOutputStream_0.WriteUnsignedByte(byte_0);
				dataOutputStream_0.WriteUnsignedByte(byte_1);
				dataOutputStream_0.WriteUnsignedByte(byte_2);
				dataOutputStream_0.WriteUnsignedInt(uint_1);
				dataOutputStream_0.WriteFloat(float_0);
				dataOutputStream_0.WriteFloat(float_1);
				dataOutputStream_0.WriteFloat(float_2);
				dataOutputStream_0.WriteFloat(float_3);
				dataOutputStream_0.WriteFloat(float_4);
				dataOutputStream_0.WriteFloat(float_5);
				dataOutputStream_0.WriteFloat(float_6);
				dataOutputStream_0.WriteFloat(float_7);
				dataOutputStream_0.WriteUnsignedInt(uint_2);
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
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
				byte_0 = dataInputStream_0.ReadUnsignedByte();
				byte_1 = dataInputStream_0.ReadUnsignedByte();
				byte_2 = dataInputStream_0.ReadUnsignedByte();
				uint_1 = dataInputStream_0.ReadUnsignedInt();
				float_0 = dataInputStream_0.ReadFloat();
				float_1 = dataInputStream_0.ReadFloat();
				float_2 = dataInputStream_0.ReadFloat();
				float_3 = dataInputStream_0.ReadFloat();
				float_4 = dataInputStream_0.ReadFloat();
				float_5 = dataInputStream_0.ReadFloat();
				float_6 = dataInputStream_0.ReadFloat();
				float_7 = dataInputStream_0.ReadFloat();
				uint_2 = dataInputStream_0.ReadUnsignedInt();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<AngleDeception>");
		try
		{
			stringBuilder_0.AppendLine("<recordType type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			stringBuilder_0.AppendLine("<recordLength type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
			stringBuilder_0.AppendLine("<padding type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</padding>");
			stringBuilder_0.AppendLine("<emitterNumber type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</emitterNumber>");
			stringBuilder_0.AppendLine("<beamNumber type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</beamNumber>");
			stringBuilder_0.AppendLine("<stateIndicator type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</stateIndicator>");
			stringBuilder_0.AppendLine("<padding2 type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			stringBuilder_0.AppendLine("<azimuthOffset type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</azimuthOffset>");
			stringBuilder_0.AppendLine("<azimuthWidth type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</azimuthWidth>");
			stringBuilder_0.AppendLine("<azimuthPullRate type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</azimuthPullRate>");
			stringBuilder_0.AppendLine("<azimuthPullAcceleration type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</azimuthPullAcceleration>");
			stringBuilder_0.AppendLine("<elevationOffset type=\"float\">" + float_4.ToString(CultureInfo.InvariantCulture) + "</elevationOffset>");
			stringBuilder_0.AppendLine("<elevationWidth type=\"float\">" + float_5.ToString(CultureInfo.InvariantCulture) + "</elevationWidth>");
			stringBuilder_0.AppendLine("<elevationPullRate type=\"float\">" + float_6.ToString(CultureInfo.InvariantCulture) + "</elevationPullRate>");
			stringBuilder_0.AppendLine("<elevationPullAcceleration type=\"float\">" + float_7.ToString(CultureInfo.InvariantCulture) + "</elevationPullAcceleration>");
			stringBuilder_0.AppendLine("<padding3 type=\"uint\">" + uint_2.ToString(CultureInfo.InvariantCulture) + "</padding3>");
			stringBuilder_0.AppendLine("</AngleDeception>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as AngleDeception;
	}

	public bool Equals(AngleDeception angleDeception_0)
	{
		bool result = true;
		if (angleDeception_0.GetType() == GetType())
		{
			if (uint_0 != angleDeception_0.uint_0)
			{
				result = false;
			}
			if (ushort_0 != angleDeception_0.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != angleDeception_0.ushort_1)
			{
				result = false;
			}
			if (byte_0 != angleDeception_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != angleDeception_0.byte_1)
			{
				result = false;
			}
			if (byte_2 != angleDeception_0.byte_2)
			{
				result = false;
			}
			if (uint_1 != angleDeception_0.uint_1)
			{
				result = false;
			}
			if (float_0 != angleDeception_0.float_0)
			{
				result = false;
			}
			if (float_1 != angleDeception_0.float_1)
			{
				result = false;
			}
			if (float_2 != angleDeception_0.float_2)
			{
				result = false;
			}
			if (float_3 != angleDeception_0.float_3)
			{
				result = false;
			}
			if (float_4 != angleDeception_0.float_4)
			{
				result = false;
			}
			if (float_5 != angleDeception_0.float_5)
			{
				result = false;
			}
			if (float_6 != angleDeception_0.float_6)
			{
				result = false;
			}
			if (float_7 != angleDeception_0.float_7)
			{
				result = false;
			}
			if (uint_2 != angleDeception_0.uint_2)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ uint_1.GetHashCode()) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode()) ^ float_3.GetHashCode()) ^ float_4.GetHashCode()) ^ float_5.GetHashCode()) ^ float_6.GetHashCode()) ^ float_7.GetHashCode()) ^ uint_2.GetHashCode();
	}
}
