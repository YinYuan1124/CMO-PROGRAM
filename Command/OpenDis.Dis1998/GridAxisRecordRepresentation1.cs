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
[XmlInclude(typeof(TwoByteChunk))]
public class GridAxisRecordRepresentation1 : GridAxisRecord, IEquatable<GridAxisRecordRepresentation1>
{
	private float float_0;

	private float float_1;

	private ushort ushort_2;

	private List<TwoByteChunk> list_0 = new List<TwoByteChunk>();

	[XmlElement(Type = typeof(float), ElementName = "fieldScale")]
	public float FieldScale
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "fieldOffset")]
	public float FieldOffset
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfValues")]
	public ushort NumberOfValues
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

	[XmlElement(ElementName = "dataValuesList", Type = typeof(List<TwoByteChunk>))]
	public List<TwoByteChunk> DataValues => list_0;

	public static bool operator !=(GridAxisRecordRepresentation1 gridAxisRecordRepresentation1_0, GridAxisRecordRepresentation1 gridAxisRecordRepresentation1_1)
	{
		return !(gridAxisRecordRepresentation1_0 == gridAxisRecordRepresentation1_1);
	}

	public static bool operator ==(GridAxisRecordRepresentation1 gridAxisRecordRepresentation1_0, GridAxisRecordRepresentation1 gridAxisRecordRepresentation1_1)
	{
		if ((object)gridAxisRecordRepresentation1_0 == gridAxisRecordRepresentation1_1)
		{
			return true;
		}
		if ((object)gridAxisRecordRepresentation1_0 != null && (object)gridAxisRecordRepresentation1_1 != null)
		{
			return gridAxisRecordRepresentation1_0.Equals(gridAxisRecordRepresentation1_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += 4;
		num += 4;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			TwoByteChunk twoByteChunk = list_0[i];
			num += twoByteChunk.GetMarshalledSize();
		}
		return num;
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
			dataOutputStream_0.WriteFloat(float_0);
			dataOutputStream_0.WriteFloat(float_1);
			dataOutputStream_0.WriteUnsignedShort((ushort)list_0.Count);
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
			float_0 = dataInputStream_0.ReadFloat();
			float_1 = dataInputStream_0.ReadFloat();
			ushort_2 = dataInputStream_0.ReadUnsignedShort();
			for (int i = 0; i < NumberOfValues; i++)
			{
				TwoByteChunk twoByteChunk = new TwoByteChunk();
				twoByteChunk.Unmarshal(dataInputStream_0);
				list_0.Add(twoByteChunk);
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
		stringBuilder_0.AppendLine("<GridAxisRecordRepresentation1>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<fieldScale type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</fieldScale>");
			stringBuilder_0.AppendLine("<fieldOffset type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</fieldOffset>");
			stringBuilder_0.AppendLine("<dataValues type=\"ushort\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</dataValues>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<dataValues" + i.ToString(CultureInfo.InvariantCulture) + " type=\"TwoByteChunk\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</dataValues" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</GridAxisRecordRepresentation1>");
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
		return this == obj as GridAxisRecordRepresentation1;
	}

	public bool Equals(GridAxisRecordRepresentation1 other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((GridAxisRecord)other);
			if (float_0 != other.float_0)
			{
				flag = false;
			}
			if (float_1 != other.float_1)
			{
				flag = false;
			}
			if (ushort_2 != other.ushort_2)
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

	private static int smethod_1(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_1(0) ^ base.GetHashCode();
		num = smethod_1(num) ^ float_0.GetHashCode();
		num = smethod_1(num) ^ float_1.GetHashCode();
		num = smethod_1(num) ^ ushort_2.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_1(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}
}
