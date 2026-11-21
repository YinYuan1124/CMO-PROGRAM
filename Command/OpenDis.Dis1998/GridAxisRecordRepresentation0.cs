#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(OneByteChunk))]
public class GridAxisRecordRepresentation0 : GridAxisRecord, IEquatable<GridAxisRecordRepresentation0>
{
	private ushort ushort_2;

	private byte[] byte_0;

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfBytes")]
	public ushort NumberOfBytes
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

	[XmlElement(ElementName = "dataValuesList", DataType = "hexBinary")]
	public byte[] DataValues
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public static bool operator !=(GridAxisRecordRepresentation0 gridAxisRecordRepresentation0_0, GridAxisRecordRepresentation0 gridAxisRecordRepresentation0_1)
	{
		return !(gridAxisRecordRepresentation0_0 == gridAxisRecordRepresentation0_1);
	}

	public static bool operator ==(GridAxisRecordRepresentation0 gridAxisRecordRepresentation0_0, GridAxisRecordRepresentation0 gridAxisRecordRepresentation0_1)
	{
		if ((object)gridAxisRecordRepresentation0_0 == gridAxisRecordRepresentation0_1)
		{
			return true;
		}
		if ((object)gridAxisRecordRepresentation0_0 != null && (object)gridAxisRecordRepresentation0_1 != null)
		{
			return gridAxisRecordRepresentation0_0.Equals(gridAxisRecordRepresentation0_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + 2 + byte_0.Length;
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
			dataOutputStream_0.WriteUnsignedShort((ushort)byte_0.Length);
			dataOutputStream_0.WriteByte(byte_0);
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
			byte_0 = dataInputStream_0.ReadByteArray(ushort_2);
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
		stringBuilder_0.AppendLine("<GridAxisRecordRepresentation0>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<dataValues type=\"ushort\">" + byte_0.Length.ToString(CultureInfo.InvariantCulture) + "</dataValues>");
			stringBuilder_0.AppendLine("<dataValues type=\"byte[]\">");
			byte[] array = byte_0;
			byte[] array2 = array;
			foreach (byte b in array2)
			{
				stringBuilder_0.Append(b.ToString("X2", CultureInfo.InvariantCulture));
			}
			stringBuilder_0.AppendLine("</dataValues>");
			stringBuilder_0.AppendLine("</GridAxisRecordRepresentation0>");
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
		return this == obj as GridAxisRecordRepresentation0;
	}

	public bool Equals(GridAxisRecordRepresentation0 other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((GridAxisRecord)other);
			if (ushort_2 != other.ushort_2)
			{
				flag = false;
			}
			if (!byte_0.Equals(other.byte_0))
			{
				flag = false;
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
		if (byte_0.Length != 0)
		{
			for (int i = 0; i < byte_0.Length; i++)
			{
				num = smethod_1(num) ^ byte_0[i].GetHashCode();
			}
		}
		return num;
	}
}
