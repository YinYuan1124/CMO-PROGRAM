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
[XmlInclude(typeof(Point))]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(Orientation))]
[XmlRoot]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(Vector3Double))]
public class MinefieldStatePdu : MinefieldFamilyPdu, IEquatable<MinefieldStatePdu>
{
	private EntityID entityID_0 = new EntityID();

	private ushort ushort_1;

	private byte byte_4;

	private byte byte_5;

	private EntityType entityType_0 = new EntityType();

	private ushort ushort_2;

	private Vector3Double vector3Double_0 = new Vector3Double();

	private Orientation orientation_0 = new Orientation();

	private ushort ushort_3;

	private ushort ushort_4;

	private List<Point> list_0 = new List<Point>();

	private List<EntityType> list_1 = new List<EntityType>();

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

	[XmlElement(Type = typeof(ushort), ElementName = "minefieldSequence")]
	public ushort MinefieldSequence
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

	[XmlElement(Type = typeof(byte), ElementName = "forceID")]
	public byte ForceID
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

	[XmlElement(Type = typeof(EntityType), ElementName = "minefieldType")]
	public EntityType MinefieldType
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

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfMineTypes")]
	public ushort NumberOfMineTypes
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "minefieldLocation")]
	public Vector3Double MinefieldLocation
	{
		get
		{
			return vector3Double_0;
		}
		set
		{
			vector3Double_0 = value;
		}
	}

	[XmlElement(Type = typeof(Orientation), ElementName = "minefieldOrientation")]
	public Orientation MinefieldOrientation
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

	[XmlElement(Type = typeof(ushort), ElementName = "appearance")]
	public ushort Appearance
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

	[XmlElement(Type = typeof(ushort), ElementName = "protocolMode")]
	public ushort ProtocolMode
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

	[XmlElement(ElementName = "perimeterPointsList", Type = typeof(List<Point>))]
	public List<Point> PerimeterPoints => list_0;

	[XmlElement(ElementName = "mineTypeList", Type = typeof(List<EntityType>))]
	public List<EntityType> MineType => list_1;

	public MinefieldStatePdu()
	{
		base.PduType = 37;
	}

	public static bool operator !=(MinefieldStatePdu minefieldStatePdu_0, MinefieldStatePdu minefieldStatePdu_1)
	{
		return !(minefieldStatePdu_0 == minefieldStatePdu_1);
	}

	public static bool operator ==(MinefieldStatePdu minefieldStatePdu_0, MinefieldStatePdu minefieldStatePdu_1)
	{
		if ((object)minefieldStatePdu_0 == minefieldStatePdu_1)
		{
			return true;
		}
		if ((object)minefieldStatePdu_0 != null && (object)minefieldStatePdu_1 != null)
		{
			return minefieldStatePdu_0.Equals(minefieldStatePdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num += 2;
		num++;
		num++;
		num += entityType_0.GetMarshalledSize();
		num += 2;
		num += vector3Double_0.GetMarshalledSize();
		num += orientation_0.GetMarshalledSize();
		num += 2;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			Point point = list_0[i];
			num += point.GetMarshalledSize();
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			EntityType entityType = list_1[j];
			num += entityType.GetMarshalledSize();
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
			dataOutputStream_0.WriteUnsignedByte(byte_4);
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			entityType_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedShort((ushort)list_1.Count);
			vector3Double_0.Marshal(dataOutputStream_0);
			orientation_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedShort(ushort_3);
			dataOutputStream_0.WriteUnsignedShort(ushort_4);
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
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			entityType_0.Unmarshal(dataInputStream_0);
			ushort_2 = dataInputStream_0.ReadUnsignedShort();
			vector3Double_0.Unmarshal(dataInputStream_0);
			orientation_0.Unmarshal(dataInputStream_0);
			ushort_3 = dataInputStream_0.ReadUnsignedShort();
			ushort_4 = dataInputStream_0.ReadUnsignedShort();
			for (int i = 0; i < NumberOfPerimeterPoints; i++)
			{
				Point point = new Point();
				point.Unmarshal(dataInputStream_0);
				list_0.Add(point);
			}
			for (int j = 0; j < NumberOfMineTypes; j++)
			{
				EntityType entityType = new EntityType();
				entityType.Unmarshal(dataInputStream_0);
				list_1.Add(entityType);
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
		stringBuilder_0.AppendLine("<MinefieldStatePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<minefieldID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</minefieldID>");
			stringBuilder_0.AppendLine("<minefieldSequence type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</minefieldSequence>");
			stringBuilder_0.AppendLine("<forceID type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</forceID>");
			stringBuilder_0.AppendLine("<perimeterPoints type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</perimeterPoints>");
			stringBuilder_0.AppendLine("<minefieldType>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</minefieldType>");
			stringBuilder_0.AppendLine("<mineType type=\"ushort\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</mineType>");
			stringBuilder_0.AppendLine("<minefieldLocation>");
			vector3Double_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</minefieldLocation>");
			stringBuilder_0.AppendLine("<minefieldOrientation>");
			orientation_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</minefieldOrientation>");
			stringBuilder_0.AppendLine("<appearance type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</appearance>");
			stringBuilder_0.AppendLine("<protocolMode type=\"ushort\">" + ushort_4.ToString(CultureInfo.InvariantCulture) + "</protocolMode>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<perimeterPoints" + i.ToString(CultureInfo.InvariantCulture) + " type=\"Point\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</perimeterPoints" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				stringBuilder_0.AppendLine("<mineType" + j.ToString(CultureInfo.InvariantCulture) + " type=\"EntityType\">");
				list_1[j].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</mineType" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</MinefieldStatePdu>");
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
		return this == obj as MinefieldStatePdu;
	}

	public bool Equals(MinefieldStatePdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((MinefieldFamilyPdu)other);
			if (!entityID_0.Equals(other.entityID_0))
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
			if (!entityType_0.Equals(other.entityType_0))
			{
				flag = false;
			}
			if (ushort_2 != other.ushort_2)
			{
				flag = false;
			}
			if (!vector3Double_0.Equals(other.vector3Double_0))
			{
				flag = false;
			}
			if (!orientation_0.Equals(other.orientation_0))
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
		num = smethod_2(num) ^ ushort_1.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ entityType_0.GetHashCode();
		num = smethod_2(num) ^ ushort_2.GetHashCode();
		num = smethod_2(num) ^ vector3Double_0.GetHashCode();
		num = smethod_2(num) ^ orientation_0.GetHashCode();
		num = smethod_2(num) ^ ushort_3.GetHashCode();
		num = smethod_2(num) ^ ushort_4.GetHashCode();
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
