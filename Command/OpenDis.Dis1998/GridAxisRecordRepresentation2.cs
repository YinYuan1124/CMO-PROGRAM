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
public class GridAxisRecordRepresentation2 : GridAxisRecord, IEquatable<GridAxisRecordRepresentation2>
{
	private ushort ushort_2;

	private List<FourByteChunk> list_0 = new List<FourByteChunk>();

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

	[XmlElement(ElementName = "dataValuesList", Type = typeof(List<FourByteChunk>))]
	public List<FourByteChunk> DataValues => list_0;

	public static bool operator !=(GridAxisRecordRepresentation2 gridAxisRecordRepresentation2_0, GridAxisRecordRepresentation2 gridAxisRecordRepresentation2_1)
	{
		return !(gridAxisRecordRepresentation2_0 == gridAxisRecordRepresentation2_1);
	}

	public static bool operator ==(GridAxisRecordRepresentation2 gridAxisRecordRepresentation2_0, GridAxisRecordRepresentation2 gridAxisRecordRepresentation2_1)
	{
		if ((object)gridAxisRecordRepresentation2_0 == gridAxisRecordRepresentation2_1)
		{
			return true;
		}
		if ((object)gridAxisRecordRepresentation2_0 != null && (object)gridAxisRecordRepresentation2_1 != null)
		{
			return gridAxisRecordRepresentation2_0.Equals(gridAxisRecordRepresentation2_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			FourByteChunk fourByteChunk = list_0[i];
			num += fourByteChunk.GetMarshalledSize();
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
			ushort_2 = dataInputStream_0.ReadUnsignedShort();
			for (int i = 0; i < NumberOfValues; i++)
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
		stringBuilder_0.AppendLine("<GridAxisRecordRepresentation2>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<dataValues type=\"ushort\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</dataValues>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<dataValues" + i.ToString(CultureInfo.InvariantCulture) + " type=\"FourByteChunk\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</dataValues" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</GridAxisRecordRepresentation2>");
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
		return this == obj as GridAxisRecordRepresentation2;
	}

	public bool Equals(GridAxisRecordRepresentation2 other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((GridAxisRecord)other);
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
