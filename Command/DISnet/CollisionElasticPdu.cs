using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EventIdentifier))]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
[XmlInclude(typeof(Vector3Float))]
public class CollisionElasticPdu : EntityInformationFamilyPdu, IEquatable<CollisionElasticPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private EventIdentifier eventIdentifier_0 = new EventIdentifier();

	private short short_0;

	private Vector3Float vector3Float_0 = new Vector3Float();

	private float float_0;

	private Vector3Float vector3Float_1 = new Vector3Float();

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	private float float_6;

	private Vector3Float vector3Float_2 = new Vector3Float();

	private float float_7;

	[XmlElement(Type = typeof(EntityID), ElementName = "issuingEntityID")]
	public EntityID IssuingEntityID
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

	[XmlElement(Type = typeof(EntityID), ElementName = "collidingEntityID")]
	public EntityID CollidingEntityID
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

	[XmlElement(Type = typeof(EventIdentifier), ElementName = "collisionEventID")]
	public EventIdentifier CollisionEventID
	{
		get
		{
			return eventIdentifier_0;
		}
		set
		{
			eventIdentifier_0 = value;
		}
	}

	[XmlElement(Type = typeof(short), ElementName = "pad")]
	public short Pad
	{
		get
		{
			return short_0;
		}
		set
		{
			short_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "contactVelocity")]
	public Vector3Float ContactVelocity
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

	[XmlElement(Type = typeof(float), ElementName = "mass")]
	public float Mass
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "locationOfImpact")]
	public Vector3Float LocationOfImpact
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

	[XmlElement(Type = typeof(float), ElementName = "collisionIntermediateResultXX")]
	public float CollisionIntermediateResultXX
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

	[XmlElement(Type = typeof(float), ElementName = "collisionIntermediateResultXY")]
	public float CollisionIntermediateResultXY
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "collisionIntermediateResultXZ")]
	public float CollisionIntermediateResultXZ
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "collisionIntermediateResultYY")]
	public float CollisionIntermediateResultYY
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "collisionIntermediateResultYZ")]
	public float CollisionIntermediateResultYZ
	{
		get
		{
			return float_5;
		}
		set
		{
			float_5 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "collisionIntermediateResultZZ")]
	public float CollisionIntermediateResultZZ
	{
		get
		{
			return float_6;
		}
		set
		{
			float_6 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "unitSurfaceNormal")]
	public Vector3Float UnitSurfaceNormal
	{
		get
		{
			return vector3Float_2;
		}
		set
		{
			vector3Float_2 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "coefficientOfRestitution")]
	public float CoefficientOfRestitution
	{
		get
		{
			return float_7;
		}
		set
		{
			float_7 = value;
		}
	}

	public CollisionElasticPdu()
	{
		base.PduType = 66;
		base.ProtocolFamily = 1;
	}

	public static bool operator !=(CollisionElasticPdu collisionElasticPdu_0, CollisionElasticPdu collisionElasticPdu_1)
	{
		return !(collisionElasticPdu_0 == collisionElasticPdu_1);
	}

	public static bool operator ==(CollisionElasticPdu collisionElasticPdu_0, CollisionElasticPdu collisionElasticPdu_1)
	{
		if ((object)collisionElasticPdu_0 == collisionElasticPdu_1)
		{
			return true;
		}
		if ((object)collisionElasticPdu_0 != null && (object)collisionElasticPdu_1 != null)
		{
			return collisionElasticPdu_0.Equals(collisionElasticPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + entityID_1.GetMarshalledSize() + eventIdentifier_0.GetMarshalledSize() + 2 + vector3Float_0.GetMarshalledSize() + 4 + vector3Float_1.GetMarshalledSize() + 4 + 4 + 4 + 4 + 4 + 4 + vector3Float_2.GetMarshalledSize() + 4;
	}

	public override void MarshalAutoLengthSet(DataOutputStream dataOutputStream_0)
	{
		base.Length = (ushort)GetMarshalledSize();
		Marshal(dataOutputStream_0);
	}

	public override void Marshal(DataOutputStream dataOutputStream_0)
	{
		base.Marshal(dataOutputStream_0);
		if (dataOutputStream_0 != null)
		{
			try
			{
				entityID_0.Marshal(dataOutputStream_0);
				entityID_1.Marshal(dataOutputStream_0);
				eventIdentifier_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteShort(short_0);
				vector3Float_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteFloat(float_0);
				vector3Float_1.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteFloat(float_1);
				dataOutputStream_0.WriteFloat(float_2);
				dataOutputStream_0.WriteFloat(float_3);
				dataOutputStream_0.WriteFloat(float_4);
				dataOutputStream_0.WriteFloat(float_5);
				dataOutputStream_0.WriteFloat(float_6);
				vector3Float_2.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteFloat(float_7);
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public override void Unmarshal(DataInputStream dataInputStream_0)
	{
		base.Unmarshal(dataInputStream_0);
		if (dataInputStream_0 != null)
		{
			try
			{
				entityID_0.Unmarshal(dataInputStream_0);
				entityID_1.Unmarshal(dataInputStream_0);
				eventIdentifier_0.Unmarshal(dataInputStream_0);
				short_0 = dataInputStream_0.ReadShort();
				vector3Float_0.Unmarshal(dataInputStream_0);
				float_0 = dataInputStream_0.ReadFloat();
				vector3Float_1.Unmarshal(dataInputStream_0);
				float_1 = dataInputStream_0.ReadFloat();
				float_2 = dataInputStream_0.ReadFloat();
				float_3 = dataInputStream_0.ReadFloat();
				float_4 = dataInputStream_0.ReadFloat();
				float_5 = dataInputStream_0.ReadFloat();
				float_6 = dataInputStream_0.ReadFloat();
				vector3Float_2.Unmarshal(dataInputStream_0);
				float_7 = dataInputStream_0.ReadFloat();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<CollisionElasticPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<issuingEntityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</issuingEntityID>");
			stringBuilder_0.AppendLine("<collidingEntityID>");
			entityID_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</collidingEntityID>");
			stringBuilder_0.AppendLine("<collisionEventID>");
			eventIdentifier_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</collisionEventID>");
			stringBuilder_0.AppendLine("<pad type=\"short\">" + short_0.ToString(CultureInfo.InvariantCulture) + "</pad>");
			stringBuilder_0.AppendLine("<contactVelocity>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</contactVelocity>");
			stringBuilder_0.AppendLine("<mass type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</mass>");
			stringBuilder_0.AppendLine("<locationOfImpact>");
			vector3Float_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</locationOfImpact>");
			stringBuilder_0.AppendLine("<collisionIntermediateResultXX type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</collisionIntermediateResultXX>");
			stringBuilder_0.AppendLine("<collisionIntermediateResultXY type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</collisionIntermediateResultXY>");
			stringBuilder_0.AppendLine("<collisionIntermediateResultXZ type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</collisionIntermediateResultXZ>");
			stringBuilder_0.AppendLine("<collisionIntermediateResultYY type=\"float\">" + float_4.ToString(CultureInfo.InvariantCulture) + "</collisionIntermediateResultYY>");
			stringBuilder_0.AppendLine("<collisionIntermediateResultYZ type=\"float\">" + float_5.ToString(CultureInfo.InvariantCulture) + "</collisionIntermediateResultYZ>");
			stringBuilder_0.AppendLine("<collisionIntermediateResultZZ type=\"float\">" + float_6.ToString(CultureInfo.InvariantCulture) + "</collisionIntermediateResultZZ>");
			stringBuilder_0.AppendLine("<unitSurfaceNormal>");
			vector3Float_2.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</unitSurfaceNormal>");
			stringBuilder_0.AppendLine("<coefficientOfRestitution type=\"float\">" + float_7.ToString(CultureInfo.InvariantCulture) + "</coefficientOfRestitution>");
			stringBuilder_0.AppendLine("</CollisionElasticPdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as CollisionElasticPdu;
	}

	public bool Equals(CollisionElasticPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((EntityInformationFamilyPdu)other);
			if (!entityID_0.Equals(other.entityID_0))
			{
				flag = false;
			}
			if (!entityID_1.Equals(other.entityID_1))
			{
				flag = false;
			}
			if (!eventIdentifier_0.Equals(other.eventIdentifier_0))
			{
				flag = false;
			}
			if (short_0 != other.short_0)
			{
				flag = false;
			}
			if (!vector3Float_0.Equals(other.vector3Float_0))
			{
				flag = false;
			}
			if (float_0 != other.float_0)
			{
				flag = false;
			}
			if (!vector3Float_1.Equals(other.vector3Float_1))
			{
				flag = false;
			}
			if (float_1 != other.float_1)
			{
				flag = false;
			}
			if (float_2 != other.float_2)
			{
				flag = false;
			}
			if (float_3 != other.float_3)
			{
				flag = false;
			}
			if (float_4 != other.float_4)
			{
				flag = false;
			}
			if (float_5 != other.float_5)
			{
				flag = false;
			}
			if (float_6 != other.float_6)
			{
				flag = false;
			}
			if (!vector3Float_2.Equals(other.vector3Float_2))
			{
				flag = false;
			}
			if (float_7 != other.float_7)
			{
				flag = false;
			}
			return flag;
		}
		return false;
	}

	private static int smethod_3(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ entityID_1.GetHashCode()) ^ eventIdentifier_0.GetHashCode()) ^ short_0.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ float_0.GetHashCode()) ^ vector3Float_1.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode()) ^ float_3.GetHashCode()) ^ float_4.GetHashCode()) ^ float_5.GetHashCode()) ^ float_6.GetHashCode()) ^ vector3Float_2.GetHashCode()) ^ float_7.GetHashCode();
	}
}
