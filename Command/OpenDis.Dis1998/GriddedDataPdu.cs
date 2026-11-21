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
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(GridAxisRecord))]
[XmlInclude(typeof(Orientation))]
public class GriddedDataPdu : SyntheticEnvironmentFamilyPdu, IEquatable<GriddedDataPdu>
{
	private EntityID entityID_0 = new EntityID();

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private ushort ushort_4;

	private byte byte_4;

	private byte byte_5;

	private EntityType entityType_0 = new EntityType();

	private Orientation orientation_0 = new Orientation();

	private long long_0;

	private uint uint_1;

	private byte byte_6;

	private ushort ushort_5;

	private byte byte_7;

	private List<GridAxisRecord> list_0 = new List<GridAxisRecord>();

	[XmlElement(Type = typeof(EntityID), ElementName = "environmentalSimulationApplicationID")]
	public EntityID EnvironmentalSimulationApplicationID
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

	[XmlElement(Type = typeof(ushort), ElementName = "fieldNumber")]
	public ushort FieldNumber
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

	[XmlElement(Type = typeof(ushort), ElementName = "pduNumber")]
	public ushort PduNumber
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

	[XmlElement(Type = typeof(ushort), ElementName = "pduTotal")]
	public ushort PduTotal
	{
		get
		{
			return ushort_3;
		}
		set
		{
			ushort_3 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "coordinateSystem")]
	public ushort CoordinateSystem
	{
		get
		{
			return ushort_4;
		}
		set
		{
			ushort_4 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "numberOfGridAxes")]
	public byte NumberOfGridAxes
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

	[XmlElement(Type = typeof(byte), ElementName = "constantGrid")]
	public byte ConstantGrid
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

	[XmlElement(Type = typeof(EntityType), ElementName = "environmentType")]
	public EntityType EnvironmentType
	{
		get
		{
			return entityType_0;
		}
		set
		{
			entityType_0 = value;
		}
	}

	[XmlElement(Type = typeof(Orientation), ElementName = "orientation")]
	public Orientation Orientation
	{
		get
		{
			return orientation_0;
		}
		set
		{
			orientation_0 = value;
		}
	}

	[XmlElement(Type = typeof(long), ElementName = "sampleTime")]
	public long SampleTime
	{
		get
		{
			return long_0;
		}
		set
		{
			long_0 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "totalValues")]
	public uint TotalValues
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

	[XmlElement(Type = typeof(byte), ElementName = "vectorDimension")]
	public byte VectorDimension
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding1")]
	public ushort Padding1
	{
		get
		{
			return ushort_5;
		}
		set
		{
			ushort_5 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "padding2")]
	public byte Padding2
	{
		get
		{
			return byte_7;
		}
		set
		{
			byte_7 = value;
		}
	}

	[XmlElement(ElementName = "gridDataListList", Type = typeof(List<GridAxisRecord>))]
	public List<GridAxisRecord> GridDataList => list_0;

	public GriddedDataPdu()
	{
		base.PduType = 42;
	}

	public static bool operator !=(GriddedDataPdu griddedDataPdu_0, GriddedDataPdu griddedDataPdu_1)
	{
		return !(griddedDataPdu_0 == griddedDataPdu_1);
	}

	public static bool operator ==(GriddedDataPdu griddedDataPdu_0, GriddedDataPdu griddedDataPdu_1)
	{
		if ((object)griddedDataPdu_0 == griddedDataPdu_1)
		{
			return true;
		}
		if ((object)griddedDataPdu_0 != null && (object)griddedDataPdu_1 != null)
		{
			return griddedDataPdu_0.Equals(griddedDataPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num += 2;
		num += 2;
		num += 2;
		num += 2;
		num++;
		num++;
		num += entityType_0.GetMarshalledSize();
		num += orientation_0.GetMarshalledSize();
		num += 8;
		num += 4;
		num++;
		num += 2;
		num++;
		for (int i = 0; i < list_0.Count; i++)
		{
			GridAxisRecord gridAxisRecord = list_0[i];
			num += gridAxisRecord.GetMarshalledSize();
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
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			dataOutputStream_0.WriteUnsignedShort(ushort_2);
			dataOutputStream_0.WriteUnsignedShort(ushort_3);
			dataOutputStream_0.WriteUnsignedShort(ushort_4);
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			dataOutputStream_0.WriteUnsignedByte(byte_5);
			entityType_0.Marshal(dataOutputStream_0);
			orientation_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteLong(long_0);
			dataOutputStream_0.WriteUnsignedInt(uint_1);
			dataOutputStream_0.WriteUnsignedByte(byte_6);
			dataOutputStream_0.WriteUnsignedShort(ushort_5);
			dataOutputStream_0.WriteUnsignedByte(byte_7);
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
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			ushort_2 = dataInputStream_0.ReadUnsignedShort();
			ushort_3 = dataInputStream_0.ReadUnsignedShort();
			ushort_4 = dataInputStream_0.ReadUnsignedShort();
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			entityType_0.Unmarshal(dataInputStream_0);
			orientation_0.Unmarshal(dataInputStream_0);
			long_0 = dataInputStream_0.ReadLong();
			uint_1 = dataInputStream_0.ReadUnsignedInt();
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			ushort_5 = dataInputStream_0.ReadUnsignedShort();
			byte_7 = dataInputStream_0.ReadUnsignedByte();
			for (int i = 0; i < NumberOfGridAxes; i++)
			{
				GridAxisRecord gridAxisRecord = new GridAxisRecord();
				gridAxisRecord.Unmarshal(dataInputStream_0);
				list_0.Add(gridAxisRecord);
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
		stringBuilder_0.AppendLine("<GriddedDataPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<environmentalSimulationApplicationID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</environmentalSimulationApplicationID>");
			stringBuilder_0.AppendLine("<fieldNumber type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</fieldNumber>");
			stringBuilder_0.AppendLine("<pduNumber type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</pduNumber>");
			stringBuilder_0.AppendLine("<pduTotal type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</pduTotal>");
			stringBuilder_0.AppendLine("<coordinateSystem type=\"ushort\">" + ushort_4.ToString(CultureInfo.InvariantCulture) + "</coordinateSystem>");
			stringBuilder_0.AppendLine("<gridDataList type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</gridDataList>");
			stringBuilder_0.AppendLine("<constantGrid type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</constantGrid>");
			stringBuilder_0.AppendLine("<environmentType>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</environmentType>");
			stringBuilder_0.AppendLine("<orientation>");
			orientation_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</orientation>");
			stringBuilder_0.AppendLine("<sampleTime type=\"long\">" + long_0.ToString(CultureInfo.InvariantCulture) + "</sampleTime>");
			stringBuilder_0.AppendLine("<totalValues type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</totalValues>");
			stringBuilder_0.AppendLine("<vectorDimension type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</vectorDimension>");
			stringBuilder_0.AppendLine("<padding1 type=\"ushort\">" + ushort_5.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			stringBuilder_0.AppendLine("<padding2 type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<gridDataList" + i.ToString(CultureInfo.InvariantCulture) + " type=\"GridAxisRecord\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</gridDataList" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</GriddedDataPdu>");
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
		return this == obj as GriddedDataPdu;
	}

	public bool Equals(GriddedDataPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((SyntheticEnvironmentFamilyPdu)other);
			if (!entityID_0.Equals(other.entityID_0))
			{
				flag = false;
			}
			if (ushort_1 != other.ushort_1)
			{
				flag = false;
			}
			if (ushort_2 != other.ushort_2)
			{
				flag = false;
			}
			if (ushort_3 != other.ushort_3)
			{
				flag = false;
			}
			if (ushort_4 != other.ushort_4)
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
			if (!entityType_0.Equals(other.entityType_0))
			{
				flag = false;
			}
			if (!orientation_0.Equals(other.orientation_0))
			{
				flag = false;
			}
			if (long_0 != other.long_0)
			{
				flag = false;
			}
			if (uint_1 != other.uint_1)
			{
				flag = false;
			}
			if (byte_6 != other.byte_6)
			{
				flag = false;
			}
			if (ushort_5 != other.ushort_5)
			{
				flag = false;
			}
			if (byte_7 != other.byte_7)
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
		num = smethod_2(num) ^ ushort_1.GetHashCode();
		num = smethod_2(num) ^ ushort_2.GetHashCode();
		num = smethod_2(num) ^ ushort_3.GetHashCode();
		num = smethod_2(num) ^ ushort_4.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ entityType_0.GetHashCode();
		num = smethod_2(num) ^ orientation_0.GetHashCode();
		num = smethod_2(num) ^ long_0.GetHashCode();
		num = smethod_2(num) ^ uint_1.GetHashCode();
		num = smethod_2(num) ^ byte_6.GetHashCode();
		num = smethod_2(num) ^ ushort_5.GetHashCode();
		num = smethod_2(num) ^ byte_7.GetHashCode();
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
