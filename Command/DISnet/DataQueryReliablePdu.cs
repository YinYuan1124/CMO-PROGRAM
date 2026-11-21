using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(VariableDatum))]
[XmlInclude(typeof(FixedDatum))]
public class DataQueryReliablePdu : SimulationManagementWithReliabilityFamilyPdu, IEquatable<DataQueryReliablePdu>
{
	private byte byte_5;

	private ushort ushort_1;

	private byte byte_6;

	private uint uint_1;

	private uint aHbAzytlOdY;

	private uint uint_2;

	private uint uint_3;

	private List<FixedDatum> pckAzlXehjH = new List<FixedDatum>();

	private List<VariableDatum> list_0 = new List<VariableDatum>();

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

	[XmlElement(Type = typeof(uint), ElementName = "timeInterval")]
	public uint TimeInterval
	{
		get
		{
			return aHbAzytlOdY;
		}
		set
		{
			aHbAzytlOdY = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "numberOfFixedDatumRecords")]
	public uint NumberOfFixedDatumRecords
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

	[XmlElement(Type = typeof(uint), ElementName = "numberOfVariableDatumRecords")]
	public uint NumberOfVariableDatumRecords
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

	[XmlElement(ElementName = "fixedDatumRecordsList", Type = typeof(List<FixedDatum>))]
	public List<FixedDatum> FixedDatumRecords => pckAzlXehjH;

	[XmlElement(ElementName = "variableDatumRecordsList", Type = typeof(List<VariableDatum>))]
	public List<VariableDatum> VariableDatumRecords => list_0;

	public DataQueryReliablePdu()
	{
		base.PduType = 58;
	}

	public static bool operator !=(DataQueryReliablePdu dataQueryReliablePdu_0, DataQueryReliablePdu dataQueryReliablePdu_1)
	{
		return !(dataQueryReliablePdu_0 == dataQueryReliablePdu_1);
	}

	public static bool operator ==(DataQueryReliablePdu dataQueryReliablePdu_0, DataQueryReliablePdu dataQueryReliablePdu_1)
	{
		if ((object)dataQueryReliablePdu_0 == dataQueryReliablePdu_1)
		{
			return true;
		}
		if ((object)dataQueryReliablePdu_0 != null && (object)dataQueryReliablePdu_1 != null)
		{
			return dataQueryReliablePdu_0.Equals(dataQueryReliablePdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num++;
		num += 2;
		num++;
		num += 4;
		num += 4;
		num += 4;
		num += 4;
		for (int i = 0; i < pckAzlXehjH.Count; i++)
		{
			FixedDatum fixedDatum = pckAzlXehjH[i];
			num += fixedDatum.GetMarshalledSize();
		}
		for (int j = 0; j < list_0.Count; j++)
		{
			VariableDatum variableDatum = list_0[j];
			num += variableDatum.GetMarshalledSize();
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
			dataOutputStream_0.WriteUnsignedByte(byte_5);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			dataOutputStream_0.WriteUnsignedByte(byte_6);
			dataOutputStream_0.WriteUnsignedInt(uint_1);
			dataOutputStream_0.WriteUnsignedInt(aHbAzytlOdY);
			dataOutputStream_0.WriteUnsignedInt((uint)pckAzlXehjH.Count);
			dataOutputStream_0.WriteUnsignedInt((uint)list_0.Count);
			for (int i = 0; i < pckAzlXehjH.Count; i++)
			{
				pckAzlXehjH[i].Marshal(dataOutputStream_0);
			}
			for (int j = 0; j < list_0.Count; j++)
			{
				list_0[j].Marshal(dataOutputStream_0);
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
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			uint_1 = dataInputStream_0.ReadUnsignedInt();
			aHbAzytlOdY = dataInputStream_0.ReadUnsignedInt();
			uint_2 = dataInputStream_0.ReadUnsignedInt();
			uint_3 = dataInputStream_0.ReadUnsignedInt();
			for (int i = 0; i < NumberOfFixedDatumRecords; i++)
			{
				FixedDatum fixedDatum = new FixedDatum();
				fixedDatum.Unmarshal(dataInputStream_0);
				pckAzlXehjH.Add(fixedDatum);
			}
			for (int j = 0; j < NumberOfVariableDatumRecords; j++)
			{
				VariableDatum variableDatum = new VariableDatum();
				variableDatum.Unmarshal(dataInputStream_0);
				list_0.Add(variableDatum);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<DataQueryReliablePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<requiredReliabilityService type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</requiredReliabilityService>");
			stringBuilder_0.AppendLine("<pad1 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</pad1>");
			stringBuilder_0.AppendLine("<pad2 type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			stringBuilder_0.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			stringBuilder_0.AppendLine("<timeInterval type=\"uint\">" + aHbAzytlOdY.ToString(CultureInfo.InvariantCulture) + "</timeInterval>");
			stringBuilder_0.AppendLine("<fixedDatumRecords type=\"uint\">" + pckAzlXehjH.Count.ToString(CultureInfo.InvariantCulture) + "</fixedDatumRecords>");
			stringBuilder_0.AppendLine("<variableDatumRecords type=\"uint\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</variableDatumRecords>");
			for (int i = 0; i < pckAzlXehjH.Count; i++)
			{
				stringBuilder_0.AppendLine("<fixedDatumRecords" + i.ToString(CultureInfo.InvariantCulture) + " type=\"FixedDatum\">");
				pckAzlXehjH[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</fixedDatumRecords" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_0.Count; j++)
			{
				stringBuilder_0.AppendLine("<variableDatumRecords" + j.ToString(CultureInfo.InvariantCulture) + " type=\"VariableDatum\">");
				list_0[j].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</variableDatumRecords" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</DataQueryReliablePdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as DataQueryReliablePdu;
	}

	public bool Equals(DataQueryReliablePdu other)
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
			if (aHbAzytlOdY != other.aHbAzytlOdY)
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
			if (pckAzlXehjH.Count != other.pckAzlXehjH.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < pckAzlXehjH.Count; i++)
				{
					if (!pckAzlXehjH[i].Equals(other.pckAzlXehjH[i]))
					{
						flag = false;
					}
				}
			}
			if (list_0.Count != other.list_0.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int j = 0; j < list_0.Count; j++)
				{
					if (!list_0[j].Equals(other.list_0[j]))
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
		num = smethod_3(num) ^ byte_5.GetHashCode();
		num = smethod_3(num) ^ ushort_1.GetHashCode();
		num = smethod_3(num) ^ byte_6.GetHashCode();
		num = smethod_3(num) ^ uint_1.GetHashCode();
		num = smethod_3(num) ^ aHbAzytlOdY.GetHashCode();
		num = smethod_3(num) ^ uint_2.GetHashCode();
		num = smethod_3(num) ^ uint_3.GetHashCode();
		if (pckAzlXehjH.Count > 0)
		{
			for (int i = 0; i < pckAzlXehjH.Count; i++)
			{
				num = smethod_3(num) ^ pckAzlXehjH[i].GetHashCode();
			}
		}
		if (list_0.Count > 0)
		{
			for (int j = 0; j < list_0.Count; j++)
			{
				num = smethod_3(num) ^ list_0[j].GetHashCode();
			}
		}
		return num;
	}
}
