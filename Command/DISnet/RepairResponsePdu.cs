using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class RepairResponsePdu : LogisticsFamilyPdu, IEquatable<RepairResponsePdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private byte byte_5;

	private short short_0;

	private byte byte_6;

	[XmlElement(Type = typeof(EntityID), ElementName = "receivingEntityID")]
	public EntityID ReceivingEntityID
	{
		get
		{
			return entityID_0;
		}
		set
		{
			entityID_0 = value;
		}
	}

	[XmlElement(Type = typeof(EntityID), ElementName = "repairingEntityID")]
	public EntityID RepairingEntityID
	{
		get
		{
			return entityID_1;
		}
		set
		{
			entityID_1 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "repairResult")]
	public byte RepairResult
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

	[XmlElement(Type = typeof(byte), ElementName = "padding2")]
	public byte Padding2
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

	public RepairResponsePdu()
	{
		base.PduType = 10;
	}

	public static bool operator !=(RepairResponsePdu repairResponsePdu_0, RepairResponsePdu repairResponsePdu_1)
	{
		return !(repairResponsePdu_0 == repairResponsePdu_1);
	}

	public static bool operator ==(RepairResponsePdu repairResponsePdu_0, RepairResponsePdu repairResponsePdu_1)
	{
		if ((object)repairResponsePdu_0 == repairResponsePdu_1)
		{
			return true;
		}
		if ((object)repairResponsePdu_0 != null && (object)repairResponsePdu_1 != null)
		{
			return repairResponsePdu_0.Equals(repairResponsePdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + entityID_1.GetMarshalledSize() + 1 + 2 + 1;
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
				entityID_0.Marshal(dataOutputStream_0);
				entityID_1.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedByte(byte_5);
				dataOutputStream_0.WriteShort(short_0);
				dataOutputStream_0.WriteByte(byte_6);
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
				entityID_0.Unmarshal(dataInputStream_0);
				entityID_1.Unmarshal(dataInputStream_0);
				byte_5 = dataInputStream_0.ReadUnsignedByte();
				short_0 = dataInputStream_0.ReadShort();
				byte_6 = dataInputStream_0.ReadByte();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<RepairResponsePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<receivingEntityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</receivingEntityID>");
			stringBuilder_0.AppendLine("<repairingEntityID>");
			entityID_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</repairingEntityID>");
			stringBuilder_0.AppendLine("<repairResult type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</repairResult>");
			stringBuilder_0.AppendLine("<padding1 type=\"short\">" + short_0.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			stringBuilder_0.AppendLine("<padding2 type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			stringBuilder_0.AppendLine("</RepairResponsePdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as RepairResponsePdu;
	}

	public bool Equals(RepairResponsePdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((LogisticsFamilyPdu)other);
			if (!entityID_0.Equals(other.entityID_0))
			{
				flag = false;
			}
			if (!entityID_1.Equals(other.entityID_1))
			{
				flag = false;
			}
			if (byte_5 != other.byte_5)
			{
				flag = false;
			}
			if (short_0 != other.short_0)
			{
				flag = false;
			}
			if (byte_6 != other.byte_6)
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
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ entityID_1.GetHashCode()) ^ byte_5.GetHashCode()) ^ short_0.GetHashCode()) ^ byte_6.GetHashCode();
	}
}
