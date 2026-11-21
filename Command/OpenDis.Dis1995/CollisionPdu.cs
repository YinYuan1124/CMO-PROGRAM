#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlInclude(typeof(EventID))]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
[XmlInclude(typeof(Vector3Float))]
public class CollisionPdu : EntityInformationPdu, IEquatable<CollisionPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private EventID eventID_0 = new EventID();

	private byte byte_4;

	private byte byte_5;

	private Vector3Float vector3Float_0 = new Vector3Float();

	private float float_0;

	private Vector3Float vector3Float_1 = new Vector3Float();

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

	[XmlElement(Type = typeof(EventID), ElementName = "eventID")]
	public EventID EventID
	{
		get
		{
			return eventID_0;
		}
		set
		{
			eventID_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "collisionType")]
	public byte CollisionType
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

	[XmlElement(Type = typeof(byte), ElementName = "pad")]
	public byte Pad
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "velocity")]
	public Vector3Float Velocity
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "location")]
	public Vector3Float Location
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

	public CollisionPdu()
	{
		base.PduType = 4;
		base.ProtocolFamily = 1;
	}

	public static bool operator !=(CollisionPdu collisionPdu_0, CollisionPdu collisionPdu_1)
	{
		return !(collisionPdu_0 == collisionPdu_1);
	}

	public static bool operator ==(CollisionPdu collisionPdu_0, CollisionPdu collisionPdu_1)
	{
		if ((object)collisionPdu_0 == collisionPdu_1)
		{
			return true;
		}
		if ((object)collisionPdu_0 != null && (object)collisionPdu_1 != null)
		{
			return collisionPdu_0.Equals(collisionPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + entityID_1.GetMarshalledSize() + eventID_0.GetMarshalledSize() + 1 + 1 + vector3Float_0.GetMarshalledSize() + 4 + vector3Float_1.GetMarshalledSize();
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
			eventID_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedByte(byte_4);
			dataOutputStream_0.WriteByte(byte_5);
			vector3Float_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteFloat(float_0);
			vector3Float_1.Marshal(dataOutputStream_0);
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
			eventID_0.Unmarshal(dataInputStream_0);
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			byte_5 = dataInputStream_0.ReadByte();
			vector3Float_0.Unmarshal(dataInputStream_0);
			float_0 = dataInputStream_0.ReadFloat();
			vector3Float_1.Unmarshal(dataInputStream_0);
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
		stringBuilder_0.AppendLine("<CollisionPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<issuingEntityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</issuingEntityID>");
			stringBuilder_0.AppendLine("<collidingEntityID>");
			entityID_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</collidingEntityID>");
			stringBuilder_0.AppendLine("<eventID>");
			eventID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</eventID>");
			stringBuilder_0.AppendLine("<collisionType type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</collisionType>");
			stringBuilder_0.AppendLine("<pad type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</pad>");
			stringBuilder_0.AppendLine("<velocity>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</velocity>");
			stringBuilder_0.AppendLine("<mass type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</mass>");
			stringBuilder_0.AppendLine("<location>");
			vector3Float_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</location>");
			stringBuilder_0.AppendLine("</CollisionPdu>");
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
		return this == obj as CollisionPdu;
	}

	public bool Equals(CollisionPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((EntityInformationPdu)other);
			if (!entityID_0.Equals(other.entityID_0))
			{
				flag = false;
			}
			if (!entityID_1.Equals(other.entityID_1))
			{
				flag = false;
			}
			if (!eventID_0.Equals(other.eventID_0))
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
		return smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ entityID_1.GetHashCode()) ^ eventID_0.GetHashCode()) ^ byte_4.GetHashCode()) ^ byte_5.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ float_0.GetHashCode()) ^ vector3Float_1.GetHashCode();
	}
}
