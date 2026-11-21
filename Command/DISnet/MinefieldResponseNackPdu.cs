using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EightByteChunk))]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
public class MinefieldResponseNackPdu : MinefieldFamilyPdu, IEquatable<MinefieldResponseNackPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private byte byte_5;

	private byte byte_6;

	private List<EightByteChunk> list_0 = new List<EightByteChunk>();

	[XmlElement(Type = typeof(EntityID), ElementName = "minefieldID")]
	public EntityID MinefieldID
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

	[XmlElement(Type = typeof(EntityID), ElementName = "requestingEntityID")]
	public EntityID RequestingEntityID
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

	[XmlElement(Type = typeof(byte), ElementName = "requestID")]
	public byte RequestID
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfMissingPdus")]
	public byte NumberOfMissingPdus
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

	[XmlElement(ElementName = "missingPduSequenceNumbersList", Type = typeof(List<EightByteChunk>))]
	public List<EightByteChunk> MissingPduSequenceNumbers => list_0;

	public MinefieldResponseNackPdu()
	{
		base.PduType = 40;
	}

	public static bool operator !=(MinefieldResponseNackPdu minefieldResponseNackPdu_0, MinefieldResponseNackPdu minefieldResponseNackPdu_1)
	{
		return !(minefieldResponseNackPdu_0 == minefieldResponseNackPdu_1);
	}

	public static bool operator ==(MinefieldResponseNackPdu minefieldResponseNackPdu_0, MinefieldResponseNackPdu minefieldResponseNackPdu_1)
	{
		if ((object)minefieldResponseNackPdu_0 == minefieldResponseNackPdu_1)
		{
			return true;
		}
		if ((object)minefieldResponseNackPdu_0 != null && (object)minefieldResponseNackPdu_1 != null)
		{
			return minefieldResponseNackPdu_0.Equals(minefieldResponseNackPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num += entityID_1.GetMarshalledSize();
		num++;
		num++;
		for (int i = 0; i < list_0.Count; i++)
		{
			EightByteChunk eightByteChunk = list_0[i];
			num += eightByteChunk.GetMarshalledSize();
		}
		return num;
	}

	public override void MarshalAutoLengthSet(DataOutputStream dataOutputStream_0)
	{
		base.Length = (ushort)GetMarshalledSize();
		Marshal(dataOutputStream_0);
	}

	public override void Marshal(DataOutputStream dataOutputStream_0)
	{
		base.Marshal(dataOutputStream_0);
		if (dataOutputStream_0 == null)
		{
			return;
		}
		try
		{
			entityID_0.Marshal(dataOutputStream_0);
			entityID_1.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedByte(byte_5);
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dataOutputStream_0);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override void Unmarshal(DataInputStream dataInputStream_0)
	{
		base.Unmarshal(dataInputStream_0);
		if (dataInputStream_0 == null)
		{
			return;
		}
		try
		{
			entityID_0.Unmarshal(dataInputStream_0);
			entityID_1.Unmarshal(dataInputStream_0);
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			for (int i = 0; i < NumberOfMissingPdus; i++)
			{
				EightByteChunk eightByteChunk = new EightByteChunk();
				eightByteChunk.Unmarshal(dataInputStream_0);
				list_0.Add(eightByteChunk);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<MinefieldResponseNackPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<minefieldID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</minefieldID>");
			stringBuilder_0.AppendLine("<requestingEntityID>");
			entityID_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</requestingEntityID>");
			stringBuilder_0.AppendLine("<requestID type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			stringBuilder_0.AppendLine("<missingPduSequenceNumbers type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</missingPduSequenceNumbers>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<missingPduSequenceNumbers" + i.ToString(CultureInfo.InvariantCulture) + " type=\"EightByteChunk\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</missingPduSequenceNumbers" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</MinefieldResponseNackPdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as MinefieldResponseNackPdu;
	}

	public bool Equals(MinefieldResponseNackPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((MinefieldFamilyPdu)other);
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
			if (byte_6 != other.byte_6)
			{
				flag = false;
			}
			if (list_0.Count != other.list_0.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < list_0.Count; i++)
				{
					if (!list_0[i].Equals(other.list_0[i]))
					{
						flag = false;
					}
				}
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
		num = smethod_3(num) ^ entityID_0.GetHashCode();
		num = smethod_3(num) ^ entityID_1.GetHashCode();
		num = smethod_3(num) ^ byte_5.GetHashCode();
		num = smethod_3(num) ^ byte_6.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_3(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}
}
