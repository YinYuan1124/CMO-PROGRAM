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
[XmlInclude(typeof(FourByteChunk))]
[XmlRoot]
public class RecordQueryReliablePdu : SimulationManagementWithReliabilityFamilyPdu, IEquatable<RecordQueryReliablePdu>
{
	private uint uint_1;

	private byte byte_4;

	private ushort ushort_1;

	private byte byte_5;

	private ushort ushort_2;

	private uint uint_2;

	private uint uint_3;

	private List<FourByteChunk> list_0 = new List<FourByteChunk>();

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
			return byte_5;
		}
		set
		{
			byte_5 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "eventType")]
	public ushort EventType
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

	[XmlElement(Type = typeof(uint), ElementName = "time")]
	public uint Time
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "numberOfRecords")]
	public uint NumberOfRecords
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	[XmlElement(ElementName = "recordIDsList", Type = typeof(List<FourByteChunk>))]
	public List<FourByteChunk> List_0 => list_0;

	public RecordQueryReliablePdu()
	{
		base.PduType = 63;
	}

	public static bool operator !=(RecordQueryReliablePdu recordQueryReliablePdu_0, RecordQueryReliablePdu recordQueryReliablePdu_1)
	{
		return !(recordQueryReliablePdu_0 == recordQueryReliablePdu_1);
	}

	public static bool operator ==(RecordQueryReliablePdu recordQueryReliablePdu_0, RecordQueryReliablePdu recordQueryReliablePdu_1)
	{
		if ((object)recordQueryReliablePdu_0 == recordQueryReliablePdu_1)
		{
			return true;
		}
		if ((object)recordQueryReliablePdu_0 != null && (object)recordQueryReliablePdu_1 != null)
		{
			return recordQueryReliablePdu_0.Equals(recordQueryReliablePdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += 4;
		num++;
		num += 2;
		num++;
		num += 2;
		num += 4;
		num += 4;
		for (int i = 0; i < list_0.Count; i++)
		{
			FourByteChunk fourByteChunk = list_0[i];
			num += fourByteChunk.GetMarshalledSize();
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
			dataOutputStream_0.WriteUnsignedInt(uint_1);
			dataOutputStream_0.WriteUnsignedByte(byte_4);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			dataOutputStream_0.WriteUnsignedByte(byte_5);
			dataOutputStream_0.WriteUnsignedShort(ushort_2);
			dataOutputStream_0.WriteUnsignedInt(uint_2);
			dataOutputStream_0.WriteUnsignedInt((uint)list_0.Count);
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
			uint_1 = dataInputStream_0.ReadUnsignedInt();
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			ushort_2 = dataInputStream_0.ReadUnsignedShort();
			uint_2 = dataInputStream_0.ReadUnsignedInt();
			uint_3 = dataInputStream_0.ReadUnsignedInt();
			for (int i = 0; i < NumberOfRecords; i++)
			{
				FourByteChunk fourByteChunk = new FourByteChunk();
				fourByteChunk.Unmarshal(dataInputStream_0);
				list_0.Add(fourByteChunk);
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
		stringBuilder_0.AppendLine("<RecordQueryReliablePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			stringBuilder_0.AppendLine("<requiredReliabilityService type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</requiredReliabilityService>");
			stringBuilder_0.AppendLine("<pad1 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</pad1>");
			stringBuilder_0.AppendLine("<pad2 type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			stringBuilder_0.AppendLine("<eventType type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</eventType>");
			stringBuilder_0.AppendLine("<time type=\"uint\">" + uint_2.ToString(CultureInfo.InvariantCulture) + "</time>");
			stringBuilder_0.AppendLine("<recordIDs type=\"uint\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</recordIDs>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<recordIDs" + i.ToString(CultureInfo.InvariantCulture) + " type=\"FourByteChunk\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</recordIDs" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</RecordQueryReliablePdu>");
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
		return this == obj as RecordQueryReliablePdu;
	}

	public bool Equals(RecordQueryReliablePdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((SimulationManagementWithReliabilityFamilyPdu)other);
			if (uint_1 != other.uint_1)
			{
				flag = false;
			}
			if (byte_4 != other.byte_4)
			{
				flag = false;
			}
			if (ushort_1 != other.ushort_1)
			{
				flag = false;
			}
			if (byte_5 != other.byte_5)
			{
				flag = false;
			}
			if (ushort_2 != other.ushort_2)
			{
				flag = false;
			}
			if (uint_2 != other.uint_2)
			{
				flag = false;
			}
			if (uint_3 != other.uint_3)
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
		num = smethod_2(num) ^ uint_1.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ ushort_1.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ ushort_2.GetHashCode();
		num = smethod_2(num) ^ uint_2.GetHashCode();
		num = smethod_2(num) ^ uint_3.GetHashCode();
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
