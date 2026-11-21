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
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(Vector3Float))]
[XmlRoot]
[XmlInclude(typeof(TwoByteChunk))]
public class MinefieldDataPdu : MinefieldFamilyPdu, IEquatable<MinefieldDataPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private ushort ushort_1;

	private byte byte_4;

	private byte byte_5;

	private byte byte_6;

	private byte uvgEpyhVlPK;

	private byte byte_7;

	private byte byte_8;

	private uint uint_1;

	private EntityType entityType_0 = new EntityType();

	private List<TwoByteChunk> list_0 = new List<TwoByteChunk>();

	private byte byte_9;

	private List<Vector3Float> list_1 = new List<Vector3Float>();

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

	[XmlElement(Type = typeof(ushort), ElementName = "minefieldSequenceNumbeer")]
	public ushort MinefieldSequenceNumbeer
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

	[XmlElement(Type = typeof(byte), ElementName = "pduSequenceNumber")]
	public byte PduSequenceNumber
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfPdus")]
	public byte NumberOfPdus
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfMinesInThisPdu")]
	public byte NumberOfMinesInThisPdu
	{
		get
		{
			return uvgEpyhVlPK;
		}
		set
		{
			uvgEpyhVlPK = value;
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

	[XmlElement(Type = typeof(byte), ElementName = "pad2")]
	public byte Pad2
	{
		get
		{
			return byte_8;
		}
		set
		{
			byte_8 = value;
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

	[XmlElement(Type = typeof(EntityType), ElementName = "mineType")]
	public EntityType MineType
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

	[XmlElement(ElementName = "sensorTypesList", Type = typeof(List<TwoByteChunk>))]
	public List<TwoByteChunk> SensorTypes => list_0;

	[XmlElement(Type = typeof(byte), ElementName = "pad3")]
	public byte Pad3
	{
		get
		{
			return byte_9;
		}
		set
		{
			byte_9 = value;
		}
	}

	[XmlElement(ElementName = "mineLocationList", Type = typeof(List<Vector3Float>))]
	public List<Vector3Float> MineLocation => list_1;

	public MinefieldDataPdu()
	{
		base.PduType = 39;
	}

	public static bool operator !=(MinefieldDataPdu minefieldDataPdu_0, MinefieldDataPdu minefieldDataPdu_1)
	{
		return !(minefieldDataPdu_0 == minefieldDataPdu_1);
	}

	public static bool operator ==(MinefieldDataPdu minefieldDataPdu_0, MinefieldDataPdu minefieldDataPdu_1)
	{
		if ((object)minefieldDataPdu_0 == minefieldDataPdu_1)
		{
			return true;
		}
		if ((object)minefieldDataPdu_0 != null && (object)minefieldDataPdu_1 != null)
		{
			return minefieldDataPdu_0.Equals(minefieldDataPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num += entityID_1.GetMarshalledSize();
		num += 2;
		num++;
		num++;
		num++;
		num++;
		num++;
		num++;
		num += 4;
		num += entityType_0.GetMarshalledSize();
		for (int i = 0; i < list_0.Count; i++)
		{
			TwoByteChunk twoByteChunk = list_0[i];
			num += twoByteChunk.GetMarshalledSize();
		}
		num++;
		for (int j = 0; j < list_1.Count; j++)
		{
			Vector3Float vector3Float = list_1[j];
			num += vector3Float.GetMarshalledSize();
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
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			dataOutputStream_0.WriteUnsignedByte(byte_4);
			dataOutputStream_0.WriteUnsignedByte(byte_5);
			dataOutputStream_0.WriteUnsignedByte(byte_6);
			dataOutputStream_0.WriteUnsignedByte((byte)list_1.Count);
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			dataOutputStream_0.WriteUnsignedByte(byte_8);
			dataOutputStream_0.WriteUnsignedInt(uint_1);
			entityType_0.Marshal(dataOutputStream_0);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dataOutputStream_0);
			}
			dataOutputStream_0.WriteUnsignedByte(byte_9);
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
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			uvgEpyhVlPK = dataInputStream_0.ReadUnsignedByte();
			byte_7 = dataInputStream_0.ReadUnsignedByte();
			byte_8 = dataInputStream_0.ReadUnsignedByte();
			uint_1 = dataInputStream_0.ReadUnsignedInt();
			entityType_0.Unmarshal(dataInputStream_0);
			for (int i = 0; i < NumberOfSensorTypes; i++)
			{
				TwoByteChunk twoByteChunk = new TwoByteChunk();
				twoByteChunk.Unmarshal(dataInputStream_0);
				list_0.Add(twoByteChunk);
			}
			byte_9 = dataInputStream_0.ReadUnsignedByte();
			for (int j = 0; j < NumberOfMinesInThisPdu; j++)
			{
				Vector3Float vector3Float = new Vector3Float();
				vector3Float.Unmarshal(dataInputStream_0);
				list_1.Add(vector3Float);
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
		stringBuilder_0.AppendLine("<MinefieldDataPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<minefieldID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</minefieldID>");
			stringBuilder_0.AppendLine("<requestingEntityID>");
			entityID_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</requestingEntityID>");
			stringBuilder_0.AppendLine("<minefieldSequenceNumbeer type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</minefieldSequenceNumbeer>");
			stringBuilder_0.AppendLine("<requestID type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			stringBuilder_0.AppendLine("<pduSequenceNumber type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</pduSequenceNumber>");
			stringBuilder_0.AppendLine("<numberOfPdus type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</numberOfPdus>");
			stringBuilder_0.AppendLine("<mineLocation type=\"byte\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</mineLocation>");
			stringBuilder_0.AppendLine("<sensorTypes type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</sensorTypes>");
			stringBuilder_0.AppendLine("<pad2 type=\"byte\">" + byte_8.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			stringBuilder_0.AppendLine("<dataFilter type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</dataFilter>");
			stringBuilder_0.AppendLine("<mineType>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</mineType>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<sensorTypes" + i.ToString(CultureInfo.InvariantCulture) + " type=\"TwoByteChunk\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</sensorTypes" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("<pad3 type=\"byte\">" + byte_9.ToString(CultureInfo.InvariantCulture) + "</pad3>");
			for (int j = 0; j < list_1.Count; j++)
			{
				stringBuilder_0.AppendLine("<mineLocation" + j.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Float\">");
				list_1[j].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</mineLocation" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</MinefieldDataPdu>");
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
		return this == obj as MinefieldDataPdu;
	}

	public bool Equals(MinefieldDataPdu other)
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
			if (ushort_1 != other.ushort_1)
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
			if (uvgEpyhVlPK != other.uvgEpyhVlPK)
			{
				flag = false;
			}
			if (byte_7 != other.byte_7)
			{
				flag = false;
			}
			if (byte_8 != other.byte_8)
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
			if (byte_9 != other.byte_9)
			{
				flag = false;
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
		num = smethod_2(num) ^ ushort_1.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ byte_6.GetHashCode();
		num = smethod_2(num) ^ uvgEpyhVlPK.GetHashCode();
		num = smethod_2(num) ^ byte_7.GetHashCode();
		num = smethod_2(num) ^ byte_8.GetHashCode();
		num = smethod_2(num) ^ uint_1.GetHashCode();
		num = smethod_2(num) ^ entityType_0.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		num = smethod_2(num) ^ byte_9.GetHashCode();
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
