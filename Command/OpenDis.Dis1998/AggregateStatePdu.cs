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
[XmlInclude(typeof(Orientation))]
[XmlInclude(typeof(VariableDatum))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(AggregateID))]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(AggregateMarking))]
[XmlRoot]
public class AggregateStatePdu : EntityManagementFamilyPdu, IEquatable<AggregateStatePdu>
{
	private EntityID entityID_0 = new EntityID();

	private byte byte_4;

	private byte byte_5;

	private EntityType entityType_0 = new EntityType();

	private uint uint_1;

	private AggregateMarking aggregateMarking_0 = new AggregateMarking();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private Orientation orientation_0 = new Orientation();

	private Vector3Double vector3Double_0 = new Vector3Double();

	private Vector3Float vector3Float_1 = new Vector3Float();

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private ushort ushort_4;

	private List<AggregateID> list_0 = new List<AggregateID>();

	private List<EntityID> list_1 = new List<EntityID>();

	private byte byte_6;

	private List<EntityType> list_2 = new List<EntityType>();

	private List<EntityType> list_3 = new List<EntityType>();

	private uint uint_2;

	private List<VariableDatum> list_4 = new List<VariableDatum>();

	[XmlElement(Type = typeof(EntityID), ElementName = "aggregateID")]
	public EntityID AggregateID
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

	[XmlElement(Type = typeof(byte), ElementName = "aggregateState")]
	public byte AggregateState
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

	[XmlElement(Type = typeof(EntityType), ElementName = "aggregateType")]
	public EntityType AggregateType
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

	[XmlElement(Type = typeof(uint), ElementName = "formation")]
	public uint Formation
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

	[XmlElement(Type = typeof(AggregateMarking), ElementName = "aggregateMarking")]
	public AggregateMarking AggregateMarking
	{
		get
		{
			return aggregateMarking_0;
		}
		set
		{
			aggregateMarking_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "dimensions")]
	public Vector3Float Dimensions
	{
		get
		{
			return vector3Float_0;
		}
		set
		{
			vector3Float_0 = value;
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "centerOfMass")]
	public Vector3Double CenterOfMass
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "velocity")]
	public Vector3Float Velocity
	{
		get
		{
			return vector3Float_1;
		}
		set
		{
			vector3Float_1 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfDisAggregates")]
	public ushort NumberOfDisAggregates
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

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfDisEntities")]
	public ushort NumberOfDisEntities
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

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfSilentAggregateTypes")]
	public ushort NumberOfSilentAggregateTypes
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

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfSilentEntityTypes")]
	public ushort NumberOfSilentEntityTypes
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

	[XmlElement(ElementName = "aggregateIDListList", Type = typeof(List<AggregateID>))]
	public List<AggregateID> AggregateIDList => list_0;

	[XmlElement(ElementName = "entityIDListList", Type = typeof(List<EntityID>))]
	public List<EntityID> EntityIDList => list_1;

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

	[XmlElement(ElementName = "silentAggregateSystemListList", Type = typeof(List<EntityType>))]
	public List<EntityType> SilentAggregateSystemList => list_2;

	[XmlElement(ElementName = "silentEntitySystemListList", Type = typeof(List<EntityType>))]
	public List<EntityType> SilentEntitySystemList => list_3;

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

	[XmlElement(ElementName = "variableDatumListList", Type = typeof(List<VariableDatum>))]
	public List<VariableDatum> VariableDatumList => list_4;

	public AggregateStatePdu()
	{
		base.PduType = 33;
	}

	public static bool operator !=(AggregateStatePdu aggregateStatePdu_0, AggregateStatePdu aggregateStatePdu_1)
	{
		return !(aggregateStatePdu_0 == aggregateStatePdu_1);
	}

	public static bool operator ==(AggregateStatePdu aggregateStatePdu_0, AggregateStatePdu aggregateStatePdu_1)
	{
		if ((object)aggregateStatePdu_0 == aggregateStatePdu_1)
		{
			return true;
		}
		if ((object)aggregateStatePdu_0 != null && (object)aggregateStatePdu_1 != null)
		{
			return aggregateStatePdu_0.Equals(aggregateStatePdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num++;
		num++;
		num += entityType_0.GetMarshalledSize();
		num += 4;
		num += aggregateMarking_0.GetMarshalledSize();
		num += vector3Float_0.GetMarshalledSize();
		num += orientation_0.GetMarshalledSize();
		num += vector3Double_0.GetMarshalledSize();
		num += vector3Float_1.GetMarshalledSize();
		num += 2;
		num += 2;
		num += 2;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			AggregateID aggregateID = list_0[i];
			num += aggregateID.GetMarshalledSize();
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			EntityID entityID = list_1[j];
			num += entityID.GetMarshalledSize();
		}
		num++;
		for (int k = 0; k < list_2.Count; k++)
		{
			EntityType entityType = list_2[k];
			num += entityType.GetMarshalledSize();
		}
		for (int l = 0; l < list_3.Count; l++)
		{
			EntityType entityType2 = list_3[l];
			num += entityType2.GetMarshalledSize();
		}
		num += 4;
		for (int m = 0; m < list_4.Count; m++)
		{
			VariableDatum variableDatum = list_4[m];
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
			entityID_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedByte(byte_4);
			dataOutputStream_0.WriteUnsignedByte(byte_5);
			entityType_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedInt(uint_1);
			aggregateMarking_0.Marshal(dataOutputStream_0);
			vector3Float_0.Marshal(dataOutputStream_0);
			orientation_0.Marshal(dataOutputStream_0);
			vector3Double_0.Marshal(dataOutputStream_0);
			vector3Float_1.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedShort((ushort)list_0.Count);
			dataOutputStream_0.WriteUnsignedShort((ushort)list_1.Count);
			dataOutputStream_0.WriteUnsignedShort((ushort)list_2.Count);
			dataOutputStream_0.WriteUnsignedShort((ushort)list_3.Count);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dataOutputStream_0);
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				list_1[j].Marshal(dataOutputStream_0);
			}
			dataOutputStream_0.WriteUnsignedByte(byte_6);
			for (int k = 0; k < list_2.Count; k++)
			{
				list_2[k].Marshal(dataOutputStream_0);
			}
			for (int l = 0; l < list_3.Count; l++)
			{
				list_3[l].Marshal(dataOutputStream_0);
			}
			dataOutputStream_0.WriteUnsignedInt((uint)list_4.Count);
			for (int m = 0; m < list_4.Count; m++)
			{
				list_4[m].Marshal(dataOutputStream_0);
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
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			entityType_0.Unmarshal(dataInputStream_0);
			uint_1 = dataInputStream_0.ReadUnsignedInt();
			aggregateMarking_0.Unmarshal(dataInputStream_0);
			vector3Float_0.Unmarshal(dataInputStream_0);
			orientation_0.Unmarshal(dataInputStream_0);
			vector3Double_0.Unmarshal(dataInputStream_0);
			vector3Float_1.Unmarshal(dataInputStream_0);
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			ushort_2 = dataInputStream_0.ReadUnsignedShort();
			ushort_3 = dataInputStream_0.ReadUnsignedShort();
			ushort_4 = dataInputStream_0.ReadUnsignedShort();
			for (int i = 0; i < NumberOfDisAggregates; i++)
			{
				AggregateID aggregateID = new AggregateID();
				aggregateID.Unmarshal(dataInputStream_0);
				list_0.Add(aggregateID);
			}
			for (int j = 0; j < NumberOfDisEntities; j++)
			{
				EntityID entityID = new EntityID();
				entityID.Unmarshal(dataInputStream_0);
				list_1.Add(entityID);
			}
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			for (int k = 0; k < NumberOfSilentAggregateTypes; k++)
			{
				EntityType entityType = new EntityType();
				entityType.Unmarshal(dataInputStream_0);
				list_2.Add(entityType);
			}
			for (int l = 0; l < NumberOfSilentEntityTypes; l++)
			{
				EntityType entityType2 = new EntityType();
				entityType2.Unmarshal(dataInputStream_0);
				list_3.Add(entityType2);
			}
			uint_2 = dataInputStream_0.ReadUnsignedInt();
			for (int m = 0; m < NumberOfVariableDatumRecords; m++)
			{
				VariableDatum variableDatum = new VariableDatum();
				variableDatum.Unmarshal(dataInputStream_0);
				list_4.Add(variableDatum);
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
		stringBuilder_0.AppendLine("<AggregateStatePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<aggregateID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</aggregateID>");
			stringBuilder_0.AppendLine("<forceID type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</forceID>");
			stringBuilder_0.AppendLine("<aggregateState type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</aggregateState>");
			stringBuilder_0.AppendLine("<aggregateType>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</aggregateType>");
			stringBuilder_0.AppendLine("<formation type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</formation>");
			stringBuilder_0.AppendLine("<aggregateMarking>");
			aggregateMarking_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</aggregateMarking>");
			stringBuilder_0.AppendLine("<dimensions>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</dimensions>");
			stringBuilder_0.AppendLine("<orientation>");
			orientation_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</orientation>");
			stringBuilder_0.AppendLine("<centerOfMass>");
			vector3Double_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</centerOfMass>");
			stringBuilder_0.AppendLine("<velocity>");
			vector3Float_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</velocity>");
			stringBuilder_0.AppendLine("<aggregateIDList type=\"ushort\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</aggregateIDList>");
			stringBuilder_0.AppendLine("<entityIDList type=\"ushort\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</entityIDList>");
			stringBuilder_0.AppendLine("<silentAggregateSystemList type=\"ushort\">" + list_2.Count.ToString(CultureInfo.InvariantCulture) + "</silentAggregateSystemList>");
			stringBuilder_0.AppendLine("<silentEntitySystemList type=\"ushort\">" + list_3.Count.ToString(CultureInfo.InvariantCulture) + "</silentEntitySystemList>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<aggregateIDList" + i.ToString(CultureInfo.InvariantCulture) + " type=\"AggregateID\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</aggregateIDList" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				stringBuilder_0.AppendLine("<entityIDList" + j.ToString(CultureInfo.InvariantCulture) + " type=\"EntityID\">");
				list_1[j].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</entityIDList" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("<pad2 type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			for (int k = 0; k < list_2.Count; k++)
			{
				stringBuilder_0.AppendLine("<silentAggregateSystemList" + k.ToString(CultureInfo.InvariantCulture) + " type=\"EntityType\">");
				list_2[k].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</silentAggregateSystemList" + k.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int l = 0; l < list_3.Count; l++)
			{
				stringBuilder_0.AppendLine("<silentEntitySystemList" + l.ToString(CultureInfo.InvariantCulture) + " type=\"EntityType\">");
				list_3[l].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</silentEntitySystemList" + l.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("<variableDatumList type=\"uint\">" + list_4.Count.ToString(CultureInfo.InvariantCulture) + "</variableDatumList>");
			for (int m = 0; m < list_4.Count; m++)
			{
				stringBuilder_0.AppendLine("<variableDatumList" + m.ToString(CultureInfo.InvariantCulture) + " type=\"VariableDatum\">");
				list_4[m].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</variableDatumList" + m.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</AggregateStatePdu>");
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
		return this == obj as AggregateStatePdu;
	}

	public bool Equals(AggregateStatePdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((EntityManagementFamilyPdu)other);
			if (!entityID_0.Equals(other.entityID_0))
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
			if (uint_1 != other.uint_1)
			{
				flag = false;
			}
			if (!aggregateMarking_0.Equals(other.aggregateMarking_0))
			{
				flag = false;
			}
			if (!vector3Float_0.Equals(other.vector3Float_0))
			{
				flag = false;
			}
			if (!orientation_0.Equals(other.orientation_0))
			{
				flag = false;
			}
			if (!vector3Double_0.Equals(other.vector3Double_0))
			{
				flag = false;
			}
			if (!vector3Float_1.Equals(other.vector3Float_1))
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
			if (byte_6 != other.byte_6)
			{
				flag = false;
			}
			if (list_2.Count != other.list_2.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int k = 0; k < list_2.Count; k++)
				{
					if (!list_2[k].Equals(other.list_2[k]))
					{
						flag = false;
					}
				}
			}
			if (list_3.Count != other.list_3.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int l = 0; l < list_3.Count; l++)
				{
					if (!list_3[l].Equals(other.list_3[l]))
					{
						flag = false;
					}
				}
			}
			if (uint_2 != other.uint_2)
			{
				flag = false;
			}
			if (list_4.Count != other.list_4.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int m = 0; m < list_4.Count; m++)
				{
					if (!list_4[m].Equals(other.list_4[m]))
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
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ entityType_0.GetHashCode();
		num = smethod_2(num) ^ uint_1.GetHashCode();
		num = smethod_2(num) ^ aggregateMarking_0.GetHashCode();
		num = smethod_2(num) ^ vector3Float_0.GetHashCode();
		num = smethod_2(num) ^ orientation_0.GetHashCode();
		num = smethod_2(num) ^ vector3Double_0.GetHashCode();
		num = smethod_2(num) ^ vector3Float_1.GetHashCode();
		num = smethod_2(num) ^ ushort_1.GetHashCode();
		num = smethod_2(num) ^ ushort_2.GetHashCode();
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
		num = smethod_2(num) ^ byte_6.GetHashCode();
		if (list_2.Count > 0)
		{
			for (int k = 0; k < list_2.Count; k++)
			{
				num = smethod_2(num) ^ list_2[k].GetHashCode();
			}
		}
		if (list_3.Count > 0)
		{
			for (int l = 0; l < list_3.Count; l++)
			{
				num = smethod_2(num) ^ list_3[l].GetHashCode();
			}
		}
		num = smethod_2(num) ^ uint_2.GetHashCode();
		if (list_4.Count > 0)
		{
			for (int m = 0; m < list_4.Count; m++)
			{
				num = smethod_2(num) ^ list_4[m].GetHashCode();
			}
		}
		return num;
	}
}
