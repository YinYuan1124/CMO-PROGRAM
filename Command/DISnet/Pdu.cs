using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class Pdu : PduSuperclass, IEquatable<Pdu>
{
	private byte byte_3;

	private byte byte_4;

	[XmlElement(Type = typeof(byte), ElementName = "pduStatus")]
	public byte PduStatus
	{
		get
		{
			return byte_3;
		}
		set
		{
			byte_3 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "padding")]
	public byte Padding
	{
		get
		{
			return byte_4;
		}
		set
		{
			byte_4 = value;
		}
	}

	public static bool operator !=(Pdu pdu_0, Pdu pdu_1)
	{
		return !(pdu_0 == pdu_1);
	}

	public static bool operator ==(Pdu pdu_0, Pdu pdu_1)
	{
		if ((object)pdu_0 == pdu_1)
		{
			return true;
		}
		if ((object)pdu_0 != null && (object)pdu_1 != null)
		{
			return pdu_0.Equals(pdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + 1 + 1;
	}

	public override void Marshal(DataOutputStream dataOutputStream_0)
	{
		base.Marshal(dataOutputStream_0);
		if (dataOutputStream_0 != null)
		{
			try
			{
				dataOutputStream_0.WriteUnsignedByte(byte_3);
				dataOutputStream_0.WriteUnsignedByte(byte_4);
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
				byte_3 = dataInputStream_0.ReadUnsignedByte();
				byte_4 = dataInputStream_0.ReadUnsignedByte();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<Pdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<pduStatus type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</pduStatus>");
			stringBuilder_0.AppendLine("<padding type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</padding>");
			stringBuilder_0.AppendLine("</Pdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as Pdu;
	}

	public bool Equals(Pdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((PduSuperclass)other);
			if (byte_3 != other.byte_3)
			{
				flag = false;
			}
			if (byte_4 != other.byte_4)
			{
				flag = false;
			}
			return flag;
		}
		return false;
	}

	private static int smethod_1(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_1(smethod_1(smethod_1(0) ^ base.GetHashCode()) ^ byte_3.GetHashCode()) ^ byte_4.GetHashCode();
	}
}
