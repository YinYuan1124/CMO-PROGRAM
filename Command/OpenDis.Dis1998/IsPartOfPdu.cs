#define TRACE
using System;
using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlInclude(typeof(Relationship))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(EntityType))]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(NamedLocation))]
public class IsPartOfPdu : EntityManagementFamilyPdu, IEquatable<IsPartOfPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private Relationship relationship_0 = new Relationship();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private NamedLocation namedLocation_0 = new NamedLocation();

	private EntityType entityType_0 = new EntityType();

	[XmlElement(Type = typeof(EntityID), ElementName = "orginatingEntityID")]
	public EntityID OrginatingEntityID
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

	[XmlElement(Type = typeof(EntityID), ElementName = "receivingEntityID")]
	public EntityID ReceivingEntityID
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

	[XmlElement(Type = typeof(Relationship), ElementName = "relationship")]
	public Relationship Relationship
	{
		get
		{
			return relationship_0;
		}
		set
		{
			relationship_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "partLocation")]
	public Vector3Float PartLocation
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

	[XmlElement(Type = typeof(NamedLocation), ElementName = "namedLocationID")]
	public NamedLocation NamedLocationID
	{
		get
		{
			return namedLocation_0;
		}
		set
		{
			namedLocation_0 = value;
		}
	}

	[XmlElement(Type = typeof(EntityType), ElementName = "partEntityType")]
	public EntityType PartEntityType
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

	public IsPartOfPdu()
	{
		base.PduType = 36;
	}

	public static bool operator !=(IsPartOfPdu isPartOfPdu_0, IsPartOfPdu isPartOfPdu_1)
	{
		return !(isPartOfPdu_0 == isPartOfPdu_1);
	}

	public static bool operator ==(IsPartOfPdu isPartOfPdu_0, IsPartOfPdu isPartOfPdu_1)
	{
		if ((object)isPartOfPdu_0 == isPartOfPdu_1)
		{
			return true;
		}
		if ((object)isPartOfPdu_0 != null && (object)isPartOfPdu_1 != null)
		{
			return isPartOfPdu_0.Equals(isPartOfPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + entityID_1.GetMarshalledSize() + relationship_0.GetMarshalledSize() + vector3Float_0.GetMarshalledSize() + namedLocation_0.GetMarshalledSize() + entityType_0.GetMarshalledSize();
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
			relationship_0.Marshal(dataOutputStream_0);
			vector3Float_0.Marshal(dataOutputStream_0);
			namedLocation_0.Marshal(dataOutputStream_0);
			entityType_0.Marshal(dataOutputStream_0);
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
			relationship_0.Unmarshal(dataInputStream_0);
			vector3Float_0.Unmarshal(dataInputStream_0);
			namedLocation_0.Unmarshal(dataInputStream_0);
			entityType_0.Unmarshal(dataInputStream_0);
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
		stringBuilder_0.AppendLine("<IsPartOfPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<orginatingEntityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</orginatingEntityID>");
			stringBuilder_0.AppendLine("<receivingEntityID>");
			entityID_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</receivingEntityID>");
			stringBuilder_0.AppendLine("<relationship>");
			relationship_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</relationship>");
			stringBuilder_0.AppendLine("<partLocation>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</partLocation>");
			stringBuilder_0.AppendLine("<namedLocationID>");
			namedLocation_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</namedLocationID>");
			stringBuilder_0.AppendLine("<partEntityType>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</partEntityType>");
			stringBuilder_0.AppendLine("</IsPartOfPdu>");
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
		return this == obj as IsPartOfPdu;
	}

	public bool Equals(IsPartOfPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((EntityManagementFamilyPdu)other);
			if (!entityID_0.Equals(other.entityID_0))
			{
				flag = false;
			}
			if (!entityID_1.Equals(other.entityID_1))
			{
				flag = false;
			}
			if (!relationship_0.Equals(other.relationship_0))
			{
				flag = false;
			}
			if (!vector3Float_0.Equals(other.vector3Float_0))
			{
				flag = false;
			}
			if (!namedLocation_0.Equals(other.namedLocation_0))
			{
				flag = false;
			}
			if (!entityType_0.Equals(other.entityType_0))
			{
				flag = false;
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
		return smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ entityID_1.GetHashCode()) ^ relationship_0.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ namedLocation_0.GetHashCode()) ^ entityType_0.GetHashCode();
	}
}
