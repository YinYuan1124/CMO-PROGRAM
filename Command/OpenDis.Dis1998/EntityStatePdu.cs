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
[XmlInclude(typeof(DeadReckoningParameter))]
[XmlInclude(typeof(Marking))]
[XmlRoot]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(Orientation))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(ArticulationParameter))]
public class EntityStatePdu : EntityInformationFamilyPdu, IEquatable<EntityStatePdu>
{
	private EntityID entityID_0 = new EntityID();

	private byte byte_4;

	private byte byte_5;

	private EntityType entityType_0 = new EntityType();

	private EntityType entityType_1 = new EntityType();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private Vector3Double vector3Double_0 = new Vector3Double();

	private Orientation orientation_0 = new Orientation();

	private int int_0;

	private DeadReckoningParameter deadReckoningParameter_0 = new DeadReckoningParameter();

	private Marking marking_0 = new Marking();

	private int int_1;

	private List<ArticulationParameter> list_0 = new List<ArticulationParameter>();

	[XmlElement(Type = typeof(EntityID), ElementName = "entityID")]
	public EntityID EntityID
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

	[XmlElement(Type = typeof(byte), ElementName = "forceId")]
	public byte ForceId
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfArticulationParameters")]
	public byte NumberOfArticulationParameters
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

	[XmlElement(Type = typeof(EntityType), ElementName = "entityType")]
	public EntityType EntityType
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

	[XmlElement(Type = typeof(EntityType), ElementName = "alternativeEntityType")]
	public EntityType AlternativeEntityType
	{
		get
		{
			return entityType_1;
		}
		set
		{
			entityType_1 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "entityLinearVelocity")]
	public Vector3Float EntityLinearVelocity
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "entityLocation")]
	public Vector3Double EntityLocation
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

	[XmlElement(Type = typeof(Orientation), ElementName = "entityOrientation")]
	public Orientation EntityOrientation
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

	[XmlElement(Type = typeof(int), ElementName = "entityAppearance")]
	public int EntityAppearance
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	[XmlElement(Type = typeof(DeadReckoningParameter), ElementName = "deadReckoningParameters")]
	public DeadReckoningParameter DeadReckoningParameters
	{
		get
		{
			return deadReckoningParameter_0;
		}
		set
		{
			deadReckoningParameter_0 = value;
		}
	}

	[XmlElement(Type = typeof(Marking), ElementName = "marking")]
	public Marking Marking
	{
		get
		{
			return marking_0;
		}
		set
		{
			marking_0 = value;
		}
	}

	[XmlElement(Type = typeof(int), ElementName = "capabilities")]
	public int Capabilities
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	[XmlElement(ElementName = "articulationParametersList", Type = typeof(List<ArticulationParameter>))]
	public List<ArticulationParameter> ArticulationParameters => list_0;

	public EntityStatePdu()
	{
		base.PduType = 1;
	}

	public static bool operator !=(EntityStatePdu entityStatePdu_0, EntityStatePdu entityStatePdu_1)
	{
		return !(entityStatePdu_0 == entityStatePdu_1);
	}

	public static bool operator ==(EntityStatePdu entityStatePdu_0, EntityStatePdu entityStatePdu_1)
	{
		if ((object)entityStatePdu_0 == entityStatePdu_1)
		{
			return true;
		}
		if ((object)entityStatePdu_0 != null && (object)entityStatePdu_1 != null)
		{
			return entityStatePdu_0.Equals(entityStatePdu_1);
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
		num += entityType_1.GetMarshalledSize();
		num += vector3Float_0.GetMarshalledSize();
		num += vector3Double_0.GetMarshalledSize();
		num += orientation_0.GetMarshalledSize();
		num += 4;
		num += deadReckoningParameter_0.GetMarshalledSize();
		num += marking_0.GetMarshalledSize();
		num += 4;
		for (int i = 0; i < list_0.Count; i++)
		{
			ArticulationParameter articulationParameter = list_0[i];
			num += articulationParameter.GetMarshalledSize();
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
			dataOutputStream_0.WriteByte((byte)list_0.Count);
			entityType_0.Marshal(dataOutputStream_0);
			entityType_1.Marshal(dataOutputStream_0);
			vector3Float_0.Marshal(dataOutputStream_0);
			vector3Double_0.Marshal(dataOutputStream_0);
			orientation_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteInt(int_0);
			deadReckoningParameter_0.Marshal(dataOutputStream_0);
			marking_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteInt(int_1);
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
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			byte_5 = dataInputStream_0.ReadByte();
			entityType_0.Unmarshal(dataInputStream_0);
			entityType_1.Unmarshal(dataInputStream_0);
			vector3Float_0.Unmarshal(dataInputStream_0);
			vector3Double_0.Unmarshal(dataInputStream_0);
			orientation_0.Unmarshal(dataInputStream_0);
			int_0 = dataInputStream_0.ReadInt();
			deadReckoningParameter_0.Unmarshal(dataInputStream_0);
			marking_0.Unmarshal(dataInputStream_0);
			int_1 = dataInputStream_0.ReadInt();
			for (int i = 0; i < NumberOfArticulationParameters; i++)
			{
				ArticulationParameter articulationParameter = new ArticulationParameter();
				articulationParameter.Unmarshal(dataInputStream_0);
				list_0.Add(articulationParameter);
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
		stringBuilder_0.AppendLine("<EntityStatePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<entityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityID>");
			stringBuilder_0.AppendLine("<forceId type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</forceId>");
			stringBuilder_0.AppendLine("<articulationParameters type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</articulationParameters>");
			stringBuilder_0.AppendLine("<entityType>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityType>");
			stringBuilder_0.AppendLine("<alternativeEntityType>");
			entityType_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</alternativeEntityType>");
			stringBuilder_0.AppendLine("<entityLinearVelocity>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityLinearVelocity>");
			stringBuilder_0.AppendLine("<entityLocation>");
			vector3Double_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityLocation>");
			stringBuilder_0.AppendLine("<entityOrientation>");
			orientation_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityOrientation>");
			stringBuilder_0.AppendLine("<entityAppearance type=\"int\">" + int_0.ToString(CultureInfo.InvariantCulture) + "</entityAppearance>");
			stringBuilder_0.AppendLine("<deadReckoningParameters>");
			deadReckoningParameter_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</deadReckoningParameters>");
			stringBuilder_0.AppendLine("<marking>");
			marking_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</marking>");
			stringBuilder_0.AppendLine("<capabilities type=\"int\">" + int_1.ToString(CultureInfo.InvariantCulture) + "</capabilities>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<articulationParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"ArticulationParameter\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</articulationParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</EntityStatePdu>");
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
		return this == obj as EntityStatePdu;
	}

	public bool Equals(EntityStatePdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((EntityInformationFamilyPdu)other);
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
			if (!entityType_1.Equals(other.entityType_1))
			{
				flag = false;
			}
			if (!vector3Float_0.Equals(other.vector3Float_0))
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
			if (int_0 != other.int_0)
			{
				flag = false;
			}
			if (!deadReckoningParameter_0.Equals(other.deadReckoningParameter_0))
			{
				flag = false;
			}
			if (!marking_0.Equals(other.marking_0))
			{
				flag = false;
			}
			if (int_1 != other.int_1)
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

	private static int smethod_2(int int_2)
	{
		int_2 <<= 5 + int_2;
		return int_2;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_2(0) ^ base.GetHashCode();
		num = smethod_2(num) ^ entityID_0.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ entityType_0.GetHashCode();
		num = smethod_2(num) ^ entityType_1.GetHashCode();
		num = smethod_2(num) ^ vector3Float_0.GetHashCode();
		num = smethod_2(num) ^ vector3Double_0.GetHashCode();
		num = smethod_2(num) ^ orientation_0.GetHashCode();
		num = smethod_2(num) ^ int_0.GetHashCode();
		num = smethod_2(num) ^ deadReckoningParameter_0.GetHashCode();
		num = smethod_2(num) ^ marking_0.GetHashCode();
		num = smethod_2(num) ^ int_1.GetHashCode();
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
