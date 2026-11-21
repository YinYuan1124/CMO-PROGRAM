using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(SimulationAddress))]
[XmlRoot]
public class AttributePdu : EntityInformationFamilyPdu, IEquatable<AttributePdu>
{
	private SimulationAddress simulationAddress_0 = new SimulationAddress();

	private int int_0;

	private short short_0;

	private byte byte_5;

	private byte byte_6;

	private uint uint_1;

	private byte byte_7;

	private byte byte_8;

	private ushort ushort_1;

	[XmlElement(Type = typeof(SimulationAddress), ElementName = "originatingSimulationAddress")]
	public SimulationAddress OriginatingSimulationAddress
	{
		get
		{
			return simulationAddress_0;
		}
		set
		{
			simulationAddress_0 = value;
		}
	}

	[XmlElement(Type = typeof(int), ElementName = "padding1")]
	public int Padding1
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

	[XmlElement(Type = typeof(short), ElementName = "padding2")]
	public short Padding2
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

	[XmlElement(Type = typeof(byte), ElementName = "attributeRecordPduType")]
	public byte AttributeRecordPduType
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

	[XmlElement(Type = typeof(byte), ElementName = "attributeRecordProtocolVersion")]
	public byte AttributeRecordProtocolVersion
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

	[XmlElement(Type = typeof(uint), ElementName = "masterAttributeRecordType")]
	public uint MasterAttributeRecordType
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

	[XmlElement(Type = typeof(byte), ElementName = "actionCode")]
	public byte ActionCode
	{
		get
		{
			return byte_7;
		}
		set
		{
			byte_7 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "padding3")]
	public byte Padding3
	{
		get
		{
			return byte_8;
		}
		set
		{
			byte_8 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "numberAttributeRecordSet")]
	public ushort NumberAttributeRecordSet
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

	public static bool operator !=(AttributePdu attributePdu_0, AttributePdu attributePdu_1)
	{
		return !(attributePdu_0 == attributePdu_1);
	}

	public static bool operator ==(AttributePdu attributePdu_0, AttributePdu attributePdu_1)
	{
		if ((object)attributePdu_0 == attributePdu_1)
		{
			return true;
		}
		if ((object)attributePdu_0 != null && (object)attributePdu_1 != null)
		{
			return attributePdu_0.Equals(attributePdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + simulationAddress_0.GetMarshalledSize() + 4 + 2 + 1 + 1 + 4 + 1 + 1 + 2;
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
				simulationAddress_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteInt(int_0);
				dataOutputStream_0.WriteShort(short_0);
				dataOutputStream_0.WriteUnsignedByte(byte_5);
				dataOutputStream_0.WriteUnsignedByte(byte_6);
				dataOutputStream_0.WriteUnsignedInt(uint_1);
				dataOutputStream_0.WriteUnsignedByte(byte_7);
				dataOutputStream_0.WriteByte(byte_8);
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
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
				simulationAddress_0.Unmarshal(dataInputStream_0);
				int_0 = dataInputStream_0.ReadInt();
				short_0 = dataInputStream_0.ReadShort();
				byte_5 = dataInputStream_0.ReadUnsignedByte();
				byte_6 = dataInputStream_0.ReadUnsignedByte();
				uint_1 = dataInputStream_0.ReadUnsignedInt();
				byte_7 = dataInputStream_0.ReadUnsignedByte();
				byte_8 = dataInputStream_0.ReadByte();
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<AttributePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<originatingSimulationAddress>");
			simulationAddress_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</originatingSimulationAddress>");
			stringBuilder_0.AppendLine("<padding1 type=\"int\">" + int_0.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			stringBuilder_0.AppendLine("<padding2 type=\"short\">" + short_0.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			stringBuilder_0.AppendLine("<attributeRecordPduType type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</attributeRecordPduType>");
			stringBuilder_0.AppendLine("<attributeRecordProtocolVersion type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</attributeRecordProtocolVersion>");
			stringBuilder_0.AppendLine("<masterAttributeRecordType type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</masterAttributeRecordType>");
			stringBuilder_0.AppendLine("<actionCode type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</actionCode>");
			stringBuilder_0.AppendLine("<padding3 type=\"byte\">" + byte_8.ToString(CultureInfo.InvariantCulture) + "</padding3>");
			stringBuilder_0.AppendLine("<numberAttributeRecordSet type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</numberAttributeRecordSet>");
			stringBuilder_0.AppendLine("</AttributePdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as AttributePdu;
	}

	public bool Equals(AttributePdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((EntityInformationFamilyPdu)other);
			if (!simulationAddress_0.Equals(other.simulationAddress_0))
			{
				flag = false;
			}
			if (int_0 != other.int_0)
			{
				flag = false;
			}
			if (short_0 != other.short_0)
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
			if (uint_1 != other.uint_1)
			{
				flag = false;
			}
			if (byte_7 != other.byte_7)
			{
				flag = false;
			}
			if (byte_8 != other.byte_8)
			{
				flag = false;
			}
			if (ushort_1 != other.ushort_1)
			{
				flag = false;
			}
			return flag;
		}
		return false;
	}

	private static int smethod_3(int int_1)
	{
		int_1 <<= 5 + int_1;
		return int_1;
	}

	public override int GetHashCode()
	{
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ simulationAddress_0.GetHashCode()) ^ int_0.GetHashCode()) ^ short_0.GetHashCode()) ^ byte_5.GetHashCode()) ^ byte_6.GetHashCode()) ^ uint_1.GetHashCode()) ^ byte_7.GetHashCode()) ^ byte_8.GetHashCode()) ^ ushort_1.GetHashCode();
	}
}
