using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(OneByteChunk))]
[XmlInclude(typeof(EntityID))]
public class IntercomSignalPdu : RadioCommunicationsFamilyPdu, IEquatable<IntercomSignalPdu>
{
	private EntityID entityID_1 = new EntityID();

	private ushort ushort_2;

	private ushort ushort_3;

	private ushort ushort_4;

	private uint uint_1;

	private ushort ushort_5;

	private ushort ushort_6;

	private byte[] byte_5;

	[XmlElement(Type = typeof(EntityID), ElementName = "entityID")]
	public EntityID EntityID
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

	[XmlElement(Type = typeof(ushort), ElementName = "communicationsDeviceID")]
	public ushort CommunicationsDeviceID
	{
		get
		{
			return ushort_2;
		}
		set
		{
			ushort_2 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "encodingScheme")]
	public ushort EncodingScheme
	{
		get
		{
			return ushort_3;
		}
		set
		{
			ushort_3 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "tdlType")]
	public ushort TdlType
	{
		get
		{
			return ushort_4;
		}
		set
		{
			ushort_4 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "sampleRate")]
	public uint SampleRate
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

	[XmlElement(Type = typeof(ushort), ElementName = "dataLength")]
	public ushort DataLength
	{
		get
		{
			return ushort_5;
		}
		set
		{
			ushort_5 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "samples")]
	public ushort Samples
	{
		get
		{
			return ushort_6;
		}
		set
		{
			ushort_6 = value;
		}
	}

	[XmlElement(ElementName = "dataList", DataType = "hexBinary")]
	public byte[] Data
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

	public IntercomSignalPdu()
	{
		base.PduType = 31;
	}

	public static bool operator !=(IntercomSignalPdu intercomSignalPdu_0, IntercomSignalPdu intercomSignalPdu_1)
	{
		return !(intercomSignalPdu_0 == intercomSignalPdu_1);
	}

	public static bool operator ==(IntercomSignalPdu intercomSignalPdu_0, IntercomSignalPdu intercomSignalPdu_1)
	{
		if ((object)intercomSignalPdu_0 == intercomSignalPdu_1)
		{
			return true;
		}
		if ((object)intercomSignalPdu_0 != null && (object)intercomSignalPdu_1 != null)
		{
			return intercomSignalPdu_0.Equals(intercomSignalPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_1.GetMarshalledSize() + 2 + 2 + 2 + 4 + 2 + 2 + byte_5.Length;
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
				entityID_1.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_2);
				dataOutputStream_0.WriteUnsignedShort(ushort_3);
				dataOutputStream_0.WriteUnsignedShort(ushort_4);
				dataOutputStream_0.WriteUnsignedInt(uint_1);
				dataOutputStream_0.WriteUnsignedShort((ushort)byte_5.Length);
				dataOutputStream_0.WriteUnsignedShort(ushort_6);
				dataOutputStream_0.WriteByte(byte_5);
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
				entityID_1.Unmarshal(dataInputStream_0);
				ushort_2 = dataInputStream_0.ReadUnsignedShort();
				ushort_3 = dataInputStream_0.ReadUnsignedShort();
				ushort_4 = dataInputStream_0.ReadUnsignedShort();
				uint_1 = dataInputStream_0.ReadUnsignedInt();
				ushort_5 = dataInputStream_0.ReadUnsignedShort();
				ushort_6 = dataInputStream_0.ReadUnsignedShort();
				byte_5 = dataInputStream_0.ReadByteArray(ushort_5);
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<IntercomSignalPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<entityID>");
			entityID_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityID>");
			stringBuilder_0.AppendLine("<communicationsDeviceID type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</communicationsDeviceID>");
			stringBuilder_0.AppendLine("<encodingScheme type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</encodingScheme>");
			stringBuilder_0.AppendLine("<tdlType type=\"ushort\">" + ushort_4.ToString(CultureInfo.InvariantCulture) + "</tdlType>");
			stringBuilder_0.AppendLine("<sampleRate type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</sampleRate>");
			stringBuilder_0.AppendLine("<data type=\"ushort\">" + byte_5.Length.ToString(CultureInfo.InvariantCulture) + "</data>");
			stringBuilder_0.AppendLine("<samples type=\"ushort\">" + ushort_6.ToString(CultureInfo.InvariantCulture) + "</samples>");
			stringBuilder_0.AppendLine("<data type=\"byte[]\">");
			byte[] array = byte_5;
			byte[] array2 = array;
			foreach (byte b in array2)
			{
				stringBuilder_0.Append(b.ToString("X2", CultureInfo.InvariantCulture));
			}
			stringBuilder_0.AppendLine("</data>");
			stringBuilder_0.AppendLine("</IntercomSignalPdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as IntercomSignalPdu;
	}

	public bool Equals(IntercomSignalPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((RadioCommunicationsFamilyPdu)other);
			if (!entityID_1.Equals(other.entityID_1))
			{
				flag = false;
			}
			if (ushort_2 != other.ushort_2)
			{
				flag = false;
			}
			if (ushort_3 != other.ushort_3)
			{
				flag = false;
			}
			if (ushort_4 != other.ushort_4)
			{
				flag = false;
			}
			if (uint_1 != other.uint_1)
			{
				flag = false;
			}
			if (ushort_5 != other.ushort_5)
			{
				flag = false;
			}
			if (ushort_6 != other.ushort_6)
			{
				flag = false;
			}
			if (!byte_5.Equals(other.byte_5))
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
		int num = 0;
		num = smethod_3(0) ^ base.GetHashCode();
		num = smethod_3(num) ^ entityID_1.GetHashCode();
		num = smethod_3(num) ^ ushort_2.GetHashCode();
		num = smethod_3(num) ^ ushort_3.GetHashCode();
		num = smethod_3(num) ^ ushort_4.GetHashCode();
		num = smethod_3(num) ^ uint_1.GetHashCode();
		num = smethod_3(num) ^ ushort_5.GetHashCode();
		num = smethod_3(num) ^ ushort_6.GetHashCode();
		if (byte_5.Length != 0)
		{
			for (int i = 0; i < byte_5.Length; i++)
			{
				num = smethod_3(num) ^ byte_5[i].GetHashCode();
			}
		}
		return num;
	}
}
