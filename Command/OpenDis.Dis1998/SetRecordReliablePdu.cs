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
[XmlInclude(typeof(RecordSet))]
public class SetRecordReliablePdu : SimulationManagementWithReliabilityFamilyPdu, IEquatable<SetRecordReliablePdu>
{
	private uint uint_1;

	private byte byte_4;

	private ushort ushort_1;

	private byte byte_5;

	private uint uint_2;

	private List<RecordSet> list_0 = new List<RecordSet>();

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

	[XmlElement(Type = typeof(uint), ElementName = "numberOfRecordSets")]
	public uint NumberOfRecordSets
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

	[XmlElement(ElementName = "recordSetsList", Type = typeof(List<RecordSet>))]
	public List<RecordSet> RecordSets => list_0;

	public SetRecordReliablePdu()
	{
		base.PduType = 64;
	}

	public static bool operator !=(SetRecordReliablePdu setRecordReliablePdu_0, SetRecordReliablePdu setRecordReliablePdu_1)
	{
		return !(setRecordReliablePdu_0 == setRecordReliablePdu_1);
	}

	public static bool operator ==(SetRecordReliablePdu setRecordReliablePdu_0, SetRecordReliablePdu setRecordReliablePdu_1)
	{
		if ((object)setRecordReliablePdu_0 == setRecordReliablePdu_1)
		{
			return true;
		}
		if ((object)setRecordReliablePdu_0 != null && (object)setRecordReliablePdu_1 != null)
		{
			return setRecordReliablePdu_0.Equals(setRecordReliablePdu_1);
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
		num += 4;
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
			dataOutputStream_0.WriteUnsignedInt(uint_1);
			dataOutputStream_0.WriteUnsignedByte(byte_4);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			dataOutputStream_0.WriteUnsignedByte(byte_5);
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
			uint_2 = dataInputStream_0.ReadUnsignedInt();
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
		stringBuilder_0.AppendLine("<SetRecordReliablePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			stringBuilder_0.AppendLine("<requiredReliabilityService type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</requiredReliabilityService>");
			stringBuilder_0.AppendLine("<pad1 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</pad1>");
			stringBuilder_0.AppendLine("<pad2 type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			stringBuilder_0.AppendLine("<recordSets type=\"uint\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</recordSets>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<recordSets" + i.ToString(CultureInfo.InvariantCulture) + " type=\"RecordSet\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</recordSets" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</SetRecordReliablePdu>");
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
		return this == obj as SetRecordReliablePdu;
	}

	public bool Equals(SetRecordReliablePdu other)
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
			if (uint_2 != other.uint_2)
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
		num = smethod_2(num) ^ uint_2.GetHashCode();
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
