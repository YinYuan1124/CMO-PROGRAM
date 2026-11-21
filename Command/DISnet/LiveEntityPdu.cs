using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class LiveEntityPdu : PduSuperclass, IEquatable<LiveEntityPdu>
{
	private ushort ushort_1;

	private byte byte_3;

	[XmlElement(Type = typeof(ushort), ElementName = "subprotocolNumber")]
	public ushort SubprotocolNumber
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

	[XmlElement(Type = typeof(byte), ElementName = "padding")]
	public byte Padding
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

	public static bool operator !=(LiveEntityPdu liveEntityPdu_0, LiveEntityPdu liveEntityPdu_1)
	{
		return !(liveEntityPdu_0 == liveEntityPdu_1);
	}

	public static bool operator ==(LiveEntityPdu liveEntityPdu_0, LiveEntityPdu liveEntityPdu_1)
	{
		if ((object)liveEntityPdu_0 == liveEntityPdu_1)
		{
			return true;
		}
		if ((object)liveEntityPdu_0 != null && (object)liveEntityPdu_1 != null)
		{
			return liveEntityPdu_0.Equals(liveEntityPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + 2 + 1;
	}

	public override void Marshal(DataOutputStream dataOutputStream_0)
	{
		base.Marshal(dataOutputStream_0);
		if (dataOutputStream_0 != null)
		{
			try
			{
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
				dataOutputStream_0.WriteUnsignedByte(byte_3);
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
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
				byte_3 = dataInputStream_0.ReadUnsignedByte();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<LiveEntityPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<subprotocolNumber type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</subprotocolNumber>");
			stringBuilder_0.AppendLine("<padding type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</padding>");
			stringBuilder_0.AppendLine("</LiveEntityPdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as LiveEntityPdu;
	}

	public bool Equals(LiveEntityPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((PduSuperclass)other);
			if (ushort_1 != other.ushort_1)
			{
				flag = false;
			}
			if (byte_3 != other.byte_3)
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
		return smethod_1(smethod_1(smethod_1(0) ^ base.GetHashCode()) ^ ushort_1.GetHashCode()) ^ byte_3.GetHashCode();
	}
}
