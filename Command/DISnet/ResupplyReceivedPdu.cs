using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(SupplyQuantity))]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
public class ResupplyReceivedPdu : LogisticsFamilyPdu, IEquatable<ResupplyReceivedPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private byte byte_5;

	private short short_0;

	private byte byte_6;

	private List<SupplyQuantity> list_0 = new List<SupplyQuantity>();

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

	[XmlElement(Type = typeof(EntityID), ElementName = "supplyingEntityID")]
	public EntityID SupplyingEntityID
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfSupplyTypes")]
	public byte NumberOfSupplyTypes
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

	[XmlElement(ElementName = "suppliesList", Type = typeof(List<SupplyQuantity>))]
	public List<SupplyQuantity> Supplies => list_0;

	public ResupplyReceivedPdu()
	{
		base.PduType = 7;
	}

	public static bool operator !=(ResupplyReceivedPdu resupplyReceivedPdu_0, ResupplyReceivedPdu resupplyReceivedPdu_1)
	{
		return !(resupplyReceivedPdu_0 == resupplyReceivedPdu_1);
	}

	public static bool operator ==(ResupplyReceivedPdu resupplyReceivedPdu_0, ResupplyReceivedPdu resupplyReceivedPdu_1)
	{
		if ((object)resupplyReceivedPdu_0 == resupplyReceivedPdu_1)
		{
			return true;
		}
		if ((object)resupplyReceivedPdu_0 != null && (object)resupplyReceivedPdu_1 != null)
		{
			return resupplyReceivedPdu_0.Equals(resupplyReceivedPdu_1);
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
		num += 2;
		num++;
		for (int i = 0; i < list_0.Count; i++)
		{
			SupplyQuantity supplyQuantity = list_0[i];
			num += supplyQuantity.GetMarshalledSize();
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
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			dataOutputStream_0.WriteShort(short_0);
			dataOutputStream_0.WriteByte(byte_6);
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
			short_0 = dataInputStream_0.ReadShort();
			byte_6 = dataInputStream_0.ReadByte();
			for (int i = 0; i < NumberOfSupplyTypes; i++)
			{
				SupplyQuantity supplyQuantity = new SupplyQuantity();
				supplyQuantity.Unmarshal(dataInputStream_0);
				list_0.Add(supplyQuantity);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<ResupplyReceivedPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<receivingEntityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</receivingEntityID>");
			stringBuilder_0.AppendLine("<supplyingEntityID>");
			entityID_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</supplyingEntityID>");
			stringBuilder_0.AppendLine("<supplies type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</supplies>");
			stringBuilder_0.AppendLine("<padding1 type=\"short\">" + short_0.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			stringBuilder_0.AppendLine("<padding2 type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<supplies" + i.ToString(CultureInfo.InvariantCulture) + " type=\"SupplyQuantity\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</supplies" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</ResupplyReceivedPdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as ResupplyReceivedPdu;
	}

	public bool Equals(ResupplyReceivedPdu other)
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
		num = smethod_3(num) ^ short_0.GetHashCode();
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
