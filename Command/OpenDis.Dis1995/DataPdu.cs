#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlInclude(typeof(FixedDatum))]
[XmlInclude(typeof(VariableDatum))]
[XmlRoot]
public class DataPdu : SimulationManagementPdu, IEquatable<DataPdu>
{
	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	private uint uint_4;

	private List<FixedDatum> list_0 = new List<FixedDatum>();

	private List<VariableDatum> list_1 = new List<VariableDatum>();

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

	[XmlElement(Type = typeof(uint), ElementName = "padding1")]
	public uint Padding1
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

	[XmlElement(Type = typeof(uint), ElementName = "fixedDatumRecordCount")]
	public uint FixedDatumRecordCount
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

	[XmlElement(Type = typeof(uint), ElementName = "variableDatumRecordCount")]
	public uint VariableDatumRecordCount
	{
		get
		{
			return uint_4;
		}
		set
		{
			uint_4 = value;
		}
	}

	[XmlElement(ElementName = "fixedDatumsList", Type = typeof(List<FixedDatum>))]
	public List<FixedDatum> FixedDatums => list_0;

	[XmlElement(ElementName = "variableDatumsList", Type = typeof(List<VariableDatum>))]
	public List<VariableDatum> VariableDatums => list_1;

	public DataPdu()
	{
		base.PduType = 20;
	}

	public static bool operator !=(DataPdu dataPdu_0, DataPdu dataPdu_1)
	{
		return !(dataPdu_0 == dataPdu_1);
	}

	public static bool operator ==(DataPdu dataPdu_0, DataPdu dataPdu_1)
	{
		if ((object)dataPdu_0 == dataPdu_1)
		{
			return true;
		}
		if ((object)dataPdu_0 != null && (object)dataPdu_1 != null)
		{
			return dataPdu_0.Equals(dataPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += 4;
		num += 4;
		num += 4;
		num += 4;
		for (int i = 0; i < list_0.Count; i++)
		{
			FixedDatum fixedDatum = list_0[i];
			num += fixedDatum.GetMarshalledSize();
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			VariableDatum variableDatum = list_1[j];
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
			dataOutputStream_0.WriteUnsignedInt(uint_1);
			dataOutputStream_0.WriteUnsignedInt(uint_2);
			dataOutputStream_0.WriteUnsignedInt((uint)list_0.Count);
			dataOutputStream_0.WriteUnsignedInt((uint)list_1.Count);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dataOutputStream_0);
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				list_1[j].Marshal(dataOutputStream_0);
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
			uint_2 = dataInputStream_0.ReadUnsignedInt();
			uint_3 = dataInputStream_0.ReadUnsignedInt();
			uint_4 = dataInputStream_0.ReadUnsignedInt();
			for (int i = 0; i < FixedDatumRecordCount; i++)
			{
				FixedDatum fixedDatum = new FixedDatum();
				fixedDatum.Unmarshal(dataInputStream_0);
				list_0.Add(fixedDatum);
			}
			for (int j = 0; j < VariableDatumRecordCount; j++)
			{
				VariableDatum variableDatum = new VariableDatum();
				variableDatum.Unmarshal(dataInputStream_0);
				list_1.Add(variableDatum);
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
		stringBuilder_0.AppendLine("<DataPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			stringBuilder_0.AppendLine("<padding1 type=\"uint\">" + uint_2.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			stringBuilder_0.AppendLine("<fixedDatums type=\"uint\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</fixedDatums>");
			stringBuilder_0.AppendLine("<variableDatums type=\"uint\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</variableDatums>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<fixedDatums" + i.ToString(CultureInfo.InvariantCulture) + " type=\"FixedDatum\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</fixedDatums" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				stringBuilder_0.AppendLine("<variableDatums" + j.ToString(CultureInfo.InvariantCulture) + " type=\"VariableDatum\">");
				list_1[j].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</variableDatums" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</DataPdu>");
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
		return this == obj as DataPdu;
	}

	public bool Equals(DataPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((SimulationManagementPdu)other);
			if (uint_1 != other.uint_1)
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
			if (uint_4 != other.uint_4)
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
			if (list_1.Count != other.list_1.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int j = 0; j < list_1.Count; j++)
				{
					if (!list_1[j].Equals(other.list_1[j]))
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
		num = smethod_2(num) ^ uint_2.GetHashCode();
		num = smethod_2(num) ^ uint_3.GetHashCode();
		num = smethod_2(num) ^ uint_4.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		if (list_1.Count > 0)
		{
			for (int j = 0; j < list_1.Count; j++)
			{
				num = smethod_2(num) ^ list_1[j].GetHashCode();
			}
		}
		return num;
	}
}
