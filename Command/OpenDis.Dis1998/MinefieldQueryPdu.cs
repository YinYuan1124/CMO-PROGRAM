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
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(Point))]
[XmlRoot]
[XmlInclude(typeof(TwoByteChunk))]
[XmlInclude(typeof(EntityID))]
public class MinefieldQueryPdu : MinefieldFamilyPdu, IEquatable<MinefieldQueryPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private byte byte_4;

	private byte byte_5;

	private byte byte_6;

	private byte byte_7;

	private uint uint_1;

	private EntityType entityType_0 = new EntityType();

	private List<Point> list_0 = new List<Point>();

	private List<TwoByteChunk> list_1 = new List<TwoByteChunk>();

	[XmlElement(Type = typeof(EntityID), ElementName = "minefieldID")]
	public EntityID MinefieldID
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

	[XmlElement(Type = typeof(EntityID), ElementName = "requestingEntityID")]
	public EntityID RequestingEntityID
	{
		get
		{
			return entityID_1;
		}
		set
		{
			entityID_1 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "requestID")]
	public byte RequestID
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfPerimeterPoints")]
	public byte NumberOfPerimeterPoints
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfSensorTypes")]
	public byte NumberOfSensorTypes
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

	[XmlElement(Type = typeof(uint), ElementName = "dataFilter")]
	public uint DataFilter
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

	[XmlElement(Type = typeof(EntityType), ElementName = "requestedMineType")]
	public EntityType RequestedMineType
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

	[XmlElement(ElementName = "requestedPerimeterPointsList", Type = typeof(List<Point>))]
	public List<Point> RequestedPerimeterPoints => list_0;

	[XmlElement(ElementName = "sensorTypesList", Type = typeof(List<TwoByteChunk>))]
	public List<TwoByteChunk> SensorTypes => list_1;

	public MinefieldQueryPdu()
	{
		base.PduType = 38;
	}

	public static bool operator !=(MinefieldQueryPdu minefieldQueryPdu_0, MinefieldQueryPdu minefieldQueryPdu_1)
	{
		return !(minefieldQueryPdu_0 == minefieldQueryPdu_1);
	}

	public static bool operator ==(MinefieldQueryPdu minefieldQueryPdu_0, MinefieldQueryPdu minefieldQueryPdu_1)
	{
		if ((object)minefieldQueryPdu_0 == minefieldQueryPdu_1)
		{
			return true;
		}
		if ((object)minefieldQueryPdu_0 != null && (object)minefieldQueryPdu_1 != null)
		{
			return minefieldQueryPdu_0.Equals(minefieldQueryPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num += entityID_1.GetMarshalledSize();
		num++;
		num++;
		num++;
		num++;
		num += 4;
		num += entityType_0.GetMarshalledSize();
		for (int i = 0; i < list_0.Count; i++)
		{
			Point point = list_0[i];
			num += point.GetMarshalledSize();
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			TwoByteChunk twoByteChunk = list_1[j];
			num += twoByteChunk.GetMarshalledSize();
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
			entityID_1.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedByte(byte_4);
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			dataOutputStream_0.WriteUnsignedByte(byte_6);
			dataOutputStream_0.WriteUnsignedByte((byte)list_1.Count);
			dataOutputStream_0.WriteUnsignedInt(uint_1);
			entityType_0.Marshal(dataOutputStream_0);
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
			entityID_0.Unmarshal(dataInputStream_0);
			entityID_1.Unmarshal(dataInputStream_0);
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			byte_7 = dataInputStream_0.ReadUnsignedByte();
			uint_1 = dataInputStream_0.ReadUnsignedInt();
			entityType_0.Unmarshal(dataInputStream_0);
			for (int i = 0; i < NumberOfPerimeterPoints; i++)
			{
				Point point = new Point();
				point.Unmarshal(dataInputStream_0);
				list_0.Add(point);
			}
			for (int j = 0; j < NumberOfSensorTypes; j++)
			{
				TwoByteChunk twoByteChunk = new TwoByteChunk();
				twoByteChunk.Unmarshal(dataInputStream_0);
				list_1.Add(twoByteChunk);
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
		stringBuilder_0.AppendLine("<MinefieldQueryPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<minefieldID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</minefieldID>");
			stringBuilder_0.AppendLine("<requestingEntityID>");
			entityID_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</requestingEntityID>");
			stringBuilder_0.AppendLine("<requestID type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			stringBuilder_0.AppendLine("<requestedPerimeterPoints type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</requestedPerimeterPoints>");
			stringBuilder_0.AppendLine("<pad2 type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			stringBuilder_0.AppendLine("<sensorTypes type=\"byte\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</sensorTypes>");
			stringBuilder_0.AppendLine("<dataFilter type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</dataFilter>");
			stringBuilder_0.AppendLine("<requestedMineType>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</requestedMineType>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<requestedPerimeterPoints" + i.ToString(CultureInfo.InvariantCulture) + " type=\"Point\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</requestedPerimeterPoints" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				stringBuilder_0.AppendLine("<sensorTypes" + j.ToString(CultureInfo.InvariantCulture) + " type=\"TwoByteChunk\">");
				list_1[j].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</sensorTypes" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</MinefieldQueryPdu>");
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
		return this == obj as MinefieldQueryPdu;
	}

	public bool Equals(MinefieldQueryPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((MinefieldFamilyPdu)other);
			if (!entityID_0.Equals(other.entityID_0))
			{
				flag = false;
			}
			if (!entityID_1.Equals(other.entityID_1))
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
			if (byte_6 != other.byte_6)
			{
				flag = false;
			}
			if (byte_7 != other.byte_7)
			{
				flag = false;
			}
			if (uint_1 != other.uint_1)
			{
				flag = false;
			}
			if (!entityType_0.Equals(other.entityType_0))
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
		num = smethod_2(num) ^ entityID_0.GetHashCode();
		num = smethod_2(num) ^ entityID_1.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ byte_6.GetHashCode();
		num = smethod_2(num) ^ byte_7.GetHashCode();
		num = smethod_2(num) ^ uint_1.GetHashCode();
		num = smethod_2(num) ^ entityType_0.GetHashCode();
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
