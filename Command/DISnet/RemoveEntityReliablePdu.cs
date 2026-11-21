using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class RemoveEntityReliablePdu : SimulationManagementWithReliabilityFamilyPdu, IEquatable<RemoveEntityReliablePdu>
{
	private byte byte_5;

	private ushort ushort_1;

	private byte byte_6;

	private uint uint_1;

	[XmlElement(Type = typeof(byte), ElementName = "requiredReliabilityService")]
	public byte RequiredReliabilityService
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

	[XmlElement(Type = typeof(ushort), ElementName = "pad1")]
	public ushort Pad1
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

	[XmlElement(Type = typeof(byte), ElementName = "pad2")]
	public byte Pad2
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

	public RemoveEntityReliablePdu()
	{
		base.PduType = 52;
	}

	public static bool operator !=(RemoveEntityReliablePdu removeEntityReliablePdu_0, RemoveEntityReliablePdu removeEntityReliablePdu_1)
	{
		return !(removeEntityReliablePdu_0 == removeEntityReliablePdu_1);
	}

	public static bool operator ==(RemoveEntityReliablePdu removeEntityReliablePdu_0, RemoveEntityReliablePdu removeEntityReliablePdu_1)
	{
		if ((object)removeEntityReliablePdu_0 == removeEntityReliablePdu_1)
		{
			return true;
		}
		if ((object)removeEntityReliablePdu_0 != null && (object)removeEntityReliablePdu_1 != null)
		{
			return removeEntityReliablePdu_0.Equals(removeEntityReliablePdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + 1 + 2 + 1 + 4;
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
				dataOutputStream_0.WriteUnsignedByte(byte_5);
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
				dataOutputStream_0.WriteUnsignedByte(byte_6);
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
				byte_5 = dataInputStream_0.ReadUnsignedByte();
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
				byte_6 = dataInputStream_0.ReadUnsignedByte();
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
		stringBuilder_0.AppendLine("<RemoveEntityReliablePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<requiredReliabilityService type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</requiredReliabilityService>");
			stringBuilder_0.AppendLine("<pad1 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</pad1>");
			stringBuilder_0.AppendLine("<pad2 type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			stringBuilder_0.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			stringBuilder_0.AppendLine("</RemoveEntityReliablePdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as RemoveEntityReliablePdu;
	}

	public bool Equals(RemoveEntityReliablePdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((SimulationManagementWithReliabilityFamilyPdu)other);
			if (byte_5 != other.byte_5)
			{
				flag = false;
			}
			if (ushort_1 != other.ushort_1)
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
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ byte_5.GetHashCode()) ^ ushort_1.GetHashCode()) ^ byte_6.GetHashCode()) ^ uint_1.GetHashCode();
	}
}
