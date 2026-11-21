using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(ClockTime))]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
public class StopFreezePdu : SimulationManagementFamilyPdu, IEquatable<StopFreezePdu>
{
	private EntityID entityID_2 = new EntityID();

	private EntityID entityID_3 = new EntityID();

	private ClockTime clockTime_0 = new ClockTime();

	private byte byte_5;

	private byte byte_6;

	private short short_0;

	private uint uint_1;

	[XmlElement(Type = typeof(EntityID), ElementName = "originatingID")]
	public EntityID OriginatingID
	{
		get
		{
			return entityID_2;
		}
		set
		{
			entityID_2 = value;
		}
	}

	[XmlElement(Type = typeof(EntityID), ElementName = "receivingID")]
	public EntityID ReceivingID
	{
		get
		{
			return entityID_3;
		}
		set
		{
			entityID_3 = value;
		}
	}

	[XmlElement(Type = typeof(ClockTime), ElementName = "realWorldTime")]
	public ClockTime RealWorldTime
	{
		get
		{
			return clockTime_0;
		}
		set
		{
			clockTime_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "reason")]
	public byte Reason
	{
		get
		{
			return byte_5;
		}
		set
		{
			byte_5 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "frozenBehavior")]
	public byte FrozenBehavior
	{
		get
		{
			return byte_6;
		}
		set
		{
			byte_6 = value;
		}
	}

	[XmlElement(Type = typeof(short), ElementName = "padding1")]
	public short Padding1
	{
		get
		{
			return short_0;
		}
		set
		{
			short_0 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "requestID")]
	public uint RequestID
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

	public StopFreezePdu()
	{
		base.PduType = 14;
	}

	public static bool operator !=(StopFreezePdu stopFreezePdu_0, StopFreezePdu stopFreezePdu_1)
	{
		return !(stopFreezePdu_0 == stopFreezePdu_1);
	}

	public static bool operator ==(StopFreezePdu stopFreezePdu_0, StopFreezePdu stopFreezePdu_1)
	{
		if ((object)stopFreezePdu_0 == stopFreezePdu_1)
		{
			return true;
		}
		if ((object)stopFreezePdu_0 != null && (object)stopFreezePdu_1 != null)
		{
			return stopFreezePdu_0.Equals(stopFreezePdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_2.GetMarshalledSize() + entityID_3.GetMarshalledSize() + clockTime_0.GetMarshalledSize() + 1 + 1 + 2 + 4;
	}

	public override void MarshalAutoLengthSet(DataOutputStream dataOutputStream_0)
	{
		base.Length = (ushort)GetMarshalledSize();
		Marshal(dataOutputStream_0);
	}

	public override void Marshal(DataOutputStream dataOutputStream_0)
	{
		base.Marshal(dataOutputStream_0);
		if (dataOutputStream_0 != null)
		{
			try
			{
				entityID_2.Marshal(dataOutputStream_0);
				entityID_3.Marshal(dataOutputStream_0);
				clockTime_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedByte(byte_5);
				dataOutputStream_0.WriteUnsignedByte(byte_6);
				dataOutputStream_0.WriteShort(short_0);
				dataOutputStream_0.WriteUnsignedInt(uint_1);
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public override void Unmarshal(DataInputStream dataInputStream_0)
	{
		base.Unmarshal(dataInputStream_0);
		if (dataInputStream_0 != null)
		{
			try
			{
				entityID_2.Unmarshal(dataInputStream_0);
				entityID_3.Unmarshal(dataInputStream_0);
				clockTime_0.Unmarshal(dataInputStream_0);
				byte_5 = dataInputStream_0.ReadUnsignedByte();
				byte_6 = dataInputStream_0.ReadUnsignedByte();
				short_0 = dataInputStream_0.ReadShort();
				uint_1 = dataInputStream_0.ReadUnsignedInt();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<StopFreezePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<originatingID>");
			entityID_2.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</originatingID>");
			stringBuilder_0.AppendLine("<receivingID>");
			entityID_3.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</receivingID>");
			stringBuilder_0.AppendLine("<realWorldTime>");
			clockTime_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</realWorldTime>");
			stringBuilder_0.AppendLine("<reason type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</reason>");
			stringBuilder_0.AppendLine("<frozenBehavior type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</frozenBehavior>");
			stringBuilder_0.AppendLine("<padding1 type=\"short\">" + short_0.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			stringBuilder_0.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			stringBuilder_0.AppendLine("</StopFreezePdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as StopFreezePdu;
	}

	public bool Equals(StopFreezePdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((SimulationManagementFamilyPdu)other);
			if (!entityID_2.Equals(other.entityID_2))
			{
				flag = false;
			}
			if (!entityID_3.Equals(other.entityID_3))
			{
				flag = false;
			}
			if (!clockTime_0.Equals(other.clockTime_0))
			{
				flag = false;
			}
			if (byte_5 != other.byte_5)
			{
				flag = false;
			}
			if (byte_6 != other.byte_6)
			{
				flag = false;
			}
			if (short_0 != other.short_0)
			{
				flag = false;
			}
			if (uint_1 != other.uint_1)
			{
				flag = false;
			}
			return flag;
		}
		return false;
	}

	private static int smethod_3(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ entityID_2.GetHashCode()) ^ entityID_3.GetHashCode()) ^ clockTime_0.GetHashCode()) ^ byte_5.GetHashCode()) ^ byte_6.GetHashCode()) ^ short_0.GetHashCode()) ^ uint_1.GetHashCode();
	}
}
