using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class CreateEntityPdu : SimulationManagementFamilyPdu, IEquatable<CreateEntityPdu>
{
	private EntityID entityID_2 = new EntityID();

	private EntityID entityID_3 = new EntityID();

	private uint uint_1;

	[XmlElement(Type = typeof(EntityID), ElementName = "originatingID")]
	public EntityID OriginatingID
	{
		get
		{
			return entityID_2;
		}
		set
		{
			entityID_2 = value;
		}
	}

	[XmlElement(Type = typeof(EntityID), ElementName = "receivingID")]
	public EntityID ReceivingID
	{
		get
		{
			return entityID_3;
		}
		set
		{
			entityID_3 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "requestID")]
	public uint RequestID
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

	public CreateEntityPdu()
	{
		base.PduType = 11;
	}

	public static bool operator !=(CreateEntityPdu createEntityPdu_0, CreateEntityPdu createEntityPdu_1)
	{
		return !(createEntityPdu_0 == createEntityPdu_1);
	}

	public static bool operator ==(CreateEntityPdu createEntityPdu_0, CreateEntityPdu createEntityPdu_1)
	{
		if ((object)createEntityPdu_0 == createEntityPdu_1)
		{
			return true;
		}
		if ((object)createEntityPdu_0 != null && (object)createEntityPdu_1 != null)
		{
			return createEntityPdu_0.Equals(createEntityPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_2.GetMarshalledSize() + entityID_3.GetMarshalledSize() + 4;
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
				entityID_2.Marshal(dataOutputStream_0);
				entityID_3.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedInt(uint_1);
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
				entityID_2.Unmarshal(dataInputStream_0);
				entityID_3.Unmarshal(dataInputStream_0);
				uint_1 = dataInputStream_0.ReadUnsignedInt();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<CreateEntityPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<originatingID>");
			entityID_2.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</originatingID>");
			stringBuilder_0.AppendLine("<receivingID>");
			entityID_3.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</receivingID>");
			stringBuilder_0.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			stringBuilder_0.AppendLine("</CreateEntityPdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as CreateEntityPdu;
	}

	public bool Equals(CreateEntityPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((SimulationManagementFamilyPdu)other);
			if (!entityID_2.Equals(other.entityID_2))
			{
				flag = false;
			}
			if (!entityID_3.Equals(other.entityID_3))
			{
				flag = false;
			}
			if (uint_1 != other.uint_1)
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
		return smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ entityID_2.GetHashCode()) ^ entityID_3.GetHashCode()) ^ uint_1.GetHashCode();
	}
}
