#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(RecordSet))]
public class TransferControlRequestPdu : EntityManagementFamilyPdu, IEquatable<TransferControlRequestPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private uint uint_1;

	private byte byte_4;

	private byte byte_5;

	private EntityID entityID_2 = new EntityID();

	private byte byte_6;

	private List<RecordSet> list_0 = new List<RecordSet>();

	[XmlElement(Type = typeof(EntityID), ElementName = "orginatingEntityID")]
	public EntityID OrginatingEntityID
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

	[XmlElement(Type = typeof(EntityID), ElementName = "recevingEntityID")]
	public EntityID RecevingEntityID
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

	[XmlElement(Type = typeof(byte), ElementName = "requiredReliabilityService")]
	public byte RequiredReliabilityService
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

	[XmlElement(Type = typeof(byte), ElementName = "tranferType")]
	public byte TranferType
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

	[XmlElement(Type = typeof(EntityID), ElementName = "transferEntityID")]
	public EntityID TransferEntityID
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfRecordSets")]
	public byte NumberOfRecordSets
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

	[XmlElement(ElementName = "recordSetsList", Type = typeof(List<RecordSet>))]
	public List<RecordSet> RecordSets => list_0;

	public TransferControlRequestPdu()
	{
		base.PduType = 35;
	}

	public static bool operator !=(TransferControlRequestPdu transferControlRequestPdu_0, TransferControlRequestPdu transferControlRequestPdu_1)
	{
		return !(transferControlRequestPdu_0 == transferControlRequestPdu_1);
	}

	public static bool operator ==(TransferControlRequestPdu transferControlRequestPdu_0, TransferControlRequestPdu transferControlRequestPdu_1)
	{
		if ((object)transferControlRequestPdu_0 == transferControlRequestPdu_1)
		{
			return true;
		}
		if ((object)transferControlRequestPdu_0 != null && (object)transferControlRequestPdu_1 != null)
		{
			return transferControlRequestPdu_0.Equals(transferControlRequestPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num += entityID_1.GetMarshalledSize();
		num += 4;
		num++;
		num++;
		num += entityID_2.GetMarshalledSize();
		num++;
		for (int i = 0; i < list_0.Count; i++)
		{
			RecordSet recordSet = list_0[i];
			num += recordSet.GetMarshalledSize();
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
			dataOutputStream_0.WriteUnsignedInt(uint_1);
			dataOutputStream_0.WriteUnsignedByte(byte_4);
			dataOutputStream_0.WriteUnsignedByte(byte_5);
			entityID_2.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dataOutputStream_0);
			}
		}
		catch (Exception ex)
		{
			if (PduBase.TraceExceptions)
			{
				Trace.WriteLine(ex);
				Trace.Flush();
			}
			RaiseExceptionOccured(ex);
			if (PduBase.ThrowExceptions)
			{
				throw ex;
			}
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
			uint_1 = dataInputStream_0.ReadUnsignedInt();
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			entityID_2.Unmarshal(dataInputStream_0);
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			for (int i = 0; i < NumberOfRecordSets; i++)
			{
				RecordSet recordSet = new RecordSet();
				recordSet.Unmarshal(dataInputStream_0);
				list_0.Add(recordSet);
			}
		}
		catch (Exception ex)
		{
			if (PduBase.TraceExceptions)
			{
				Trace.WriteLine(ex);
				Trace.Flush();
			}
			RaiseExceptionOccured(ex);
			if (PduBase.ThrowExceptions)
			{
				throw ex;
			}
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<TransferControlRequestPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<orginatingEntityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</orginatingEntityID>");
			stringBuilder_0.AppendLine("<recevingEntityID>");
			entityID_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</recevingEntityID>");
			stringBuilder_0.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			stringBuilder_0.AppendLine("<requiredReliabilityService type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</requiredReliabilityService>");
			stringBuilder_0.AppendLine("<tranferType type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</tranferType>");
			stringBuilder_0.AppendLine("<transferEntityID>");
			entityID_2.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</transferEntityID>");
			stringBuilder_0.AppendLine("<recordSets type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</recordSets>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<recordSets" + i.ToString(CultureInfo.InvariantCulture) + " type=\"RecordSet\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</recordSets" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</TransferControlRequestPdu>");
		}
		catch (Exception ex)
		{
			if (PduBase.TraceExceptions)
			{
				Trace.WriteLine(ex);
				Trace.Flush();
			}
			RaiseExceptionOccured(ex);
			if (PduBase.ThrowExceptions)
			{
				throw ex;
			}
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as TransferControlRequestPdu;
	}

	public bool Equals(TransferControlRequestPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((EntityManagementFamilyPdu)other);
			if (!entityID_0.Equals(other.entityID_0))
			{
				flag = false;
			}
			if (!entityID_1.Equals(other.entityID_1))
			{
				flag = false;
			}
			if (uint_1 != other.uint_1)
			{
				flag = false;
			}
			if (byte_4 != other.byte_4)
			{
				flag = false;
			}
			if (byte_5 != other.byte_5)
			{
				flag = false;
			}
			if (!entityID_2.Equals(other.entityID_2))
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

	private static int smethod_2(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_2(0) ^ base.GetHashCode();
		num = smethod_2(num) ^ entityID_0.GetHashCode();
		num = smethod_2(num) ^ entityID_1.GetHashCode();
		num = smethod_2(num) ^ uint_1.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ entityID_2.GetHashCode();
		num = smethod_2(num) ^ byte_6.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}
}
