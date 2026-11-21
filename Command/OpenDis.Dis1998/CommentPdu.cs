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
[XmlInclude(typeof(VariableDatum))]
[XmlInclude(typeof(FixedDatum))]
[XmlRoot]
public class CommentPdu : SimulationManagementFamilyPdu, IEquatable<CommentPdu>
{
	private uint uint_1;

	private uint uint_2;

	private List<FixedDatum> list_0 = new List<FixedDatum>();

	private List<VariableDatum> list_1 = new List<VariableDatum>();

	[XmlElement(Type = typeof(uint), ElementName = "numberOfFixedDatumRecords")]
	public uint NumberOfFixedDatumRecords
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

	[XmlElement(Type = typeof(uint), ElementName = "numberOfVariableDatumRecords")]
	public uint NumberOfVariableDatumRecords
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

	[XmlElement(ElementName = "fixedDatumsList", Type = typeof(List<FixedDatum>))]
	public List<FixedDatum> FixedDatums => list_0;

	[XmlElement(ElementName = "variableDatumsList", Type = typeof(List<VariableDatum>))]
	public List<VariableDatum> VariableDatums => list_1;

	public CommentPdu()
	{
		base.PduType = 22;
	}

	public static bool operator !=(CommentPdu commentPdu_0, CommentPdu commentPdu_1)
	{
		return !(commentPdu_0 == commentPdu_1);
	}

	public static bool operator ==(CommentPdu commentPdu_0, CommentPdu commentPdu_1)
	{
		if ((object)commentPdu_0 == commentPdu_1)
		{
			return true;
		}
		if ((object)commentPdu_0 != null && (object)commentPdu_1 != null)
		{
			return commentPdu_0.Equals(commentPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
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
			for (int i = 0; i < NumberOfFixedDatumRecords; i++)
			{
				FixedDatum fixedDatum = new FixedDatum();
				fixedDatum.Unmarshal(dataInputStream_0);
				list_0.Add(fixedDatum);
			}
			for (int j = 0; j < NumberOfVariableDatumRecords; j++)
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
		stringBuilder_0.AppendLine("<CommentPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
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
			stringBuilder_0.AppendLine("</CommentPdu>");
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
		return this == obj as CommentPdu;
	}

	public bool Equals(CommentPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((SimulationManagementFamilyPdu)other);
			if (uint_1 != other.uint_1)
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
