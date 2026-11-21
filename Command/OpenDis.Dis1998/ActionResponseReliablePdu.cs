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
[XmlInclude(typeof(FixedDatum))]
[XmlInclude(typeof(VariableDatum))]
public class ActionResponseReliablePdu : SimulationManagementWithReliabilityFamilyPdu, IEquatable<ActionResponseReliablePdu>
{
	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	private uint uint_4;

	private List<FixedDatum> dtgEiBxphce = new List<FixedDatum>();

	private List<VariableDatum> list_0 = new List<VariableDatum>();

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

	[XmlElement(Type = typeof(uint), ElementName = "responseStatus")]
	public uint ResponseStatus
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

	[XmlElement(Type = typeof(uint), ElementName = "numberOfFixedDatumRecords")]
	public uint NumberOfFixedDatumRecords
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

	[XmlElement(Type = typeof(uint), ElementName = "numberOfVariableDatumRecords")]
	public uint NumberOfVariableDatumRecords
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

	[XmlElement(ElementName = "fixedDatumRecordsList", Type = typeof(List<FixedDatum>))]
	public List<FixedDatum> FixedDatumRecords => dtgEiBxphce;

	[XmlElement(ElementName = "variableDatumRecordsList", Type = typeof(List<VariableDatum>))]
	public List<VariableDatum> VariableDatumRecords => list_0;

	public ActionResponseReliablePdu()
	{
		base.PduType = 57;
	}

	public static bool operator !=(ActionResponseReliablePdu actionResponseReliablePdu_0, ActionResponseReliablePdu actionResponseReliablePdu_1)
	{
		return !(actionResponseReliablePdu_0 == actionResponseReliablePdu_1);
	}

	public static bool operator ==(ActionResponseReliablePdu actionResponseReliablePdu_0, ActionResponseReliablePdu actionResponseReliablePdu_1)
	{
		if ((object)actionResponseReliablePdu_0 == actionResponseReliablePdu_1)
		{
			return true;
		}
		if ((object)actionResponseReliablePdu_0 != null && (object)actionResponseReliablePdu_1 != null)
		{
			return actionResponseReliablePdu_0.Equals(actionResponseReliablePdu_1);
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
		for (int i = 0; i < dtgEiBxphce.Count; i++)
		{
			FixedDatum fixedDatum = dtgEiBxphce[i];
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
			dataOutputStream_0.WriteUnsignedInt(uint_1);
			dataOutputStream_0.WriteUnsignedInt(uint_2);
			dataOutputStream_0.WriteUnsignedInt((uint)dtgEiBxphce.Count);
			dataOutputStream_0.WriteUnsignedInt((uint)list_0.Count);
			for (int i = 0; i < dtgEiBxphce.Count; i++)
			{
				dtgEiBxphce[i].Marshal(dataOutputStream_0);
			}
			for (int j = 0; j < list_0.Count; j++)
			{
				list_0[j].Marshal(dataOutputStream_0);
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
			for (int i = 0; i < NumberOfFixedDatumRecords; i++)
			{
				FixedDatum fixedDatum = new FixedDatum();
				fixedDatum.Unmarshal(dataInputStream_0);
				dtgEiBxphce.Add(fixedDatum);
			}
			for (int j = 0; j < NumberOfVariableDatumRecords; j++)
			{
				VariableDatum variableDatum = new VariableDatum();
				variableDatum.Unmarshal(dataInputStream_0);
				list_0.Add(variableDatum);
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
		stringBuilder_0.AppendLine("<ActionResponseReliablePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			stringBuilder_0.AppendLine("<responseStatus type=\"uint\">" + uint_2.ToString(CultureInfo.InvariantCulture) + "</responseStatus>");
			stringBuilder_0.AppendLine("<fixedDatumRecords type=\"uint\">" + dtgEiBxphce.Count.ToString(CultureInfo.InvariantCulture) + "</fixedDatumRecords>");
			stringBuilder_0.AppendLine("<variableDatumRecords type=\"uint\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</variableDatumRecords>");
			for (int i = 0; i < dtgEiBxphce.Count; i++)
			{
				stringBuilder_0.AppendLine("<fixedDatumRecords" + i.ToString(CultureInfo.InvariantCulture) + " type=\"FixedDatum\">");
				dtgEiBxphce[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</fixedDatumRecords" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_0.Count; j++)
			{
				stringBuilder_0.AppendLine("<variableDatumRecords" + j.ToString(CultureInfo.InvariantCulture) + " type=\"VariableDatum\">");
				list_0[j].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</variableDatumRecords" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</ActionResponseReliablePdu>");
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
		return this == obj as ActionResponseReliablePdu;
	}

	public bool Equals(ActionResponseReliablePdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((SimulationManagementWithReliabilityFamilyPdu)other);
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
			if (dtgEiBxphce.Count != other.dtgEiBxphce.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < dtgEiBxphce.Count; i++)
				{
					if (!dtgEiBxphce[i].Equals(other.dtgEiBxphce[i]))
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
		if (dtgEiBxphce.Count > 0)
		{
			for (int i = 0; i < dtgEiBxphce.Count; i++)
			{
				num = smethod_2(num) ^ dtgEiBxphce[i].GetHashCode();
			}
		}
		if (list_0.Count > 0)
		{
			for (int j = 0; j < list_0.Count; j++)
			{
				num = smethod_2(num) ^ list_0[j].GetHashCode();
			}
		}
		return num;
	}
}
