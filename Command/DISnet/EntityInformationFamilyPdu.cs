using System;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class EntityInformationFamilyPdu : Pdu, IEquatable<EntityInformationFamilyPdu>
{
	public EntityInformationFamilyPdu()
	{
		base.ProtocolFamily = 1;
	}

	public static bool operator !=(EntityInformationFamilyPdu entityInformationFamilyPdu_0, EntityInformationFamilyPdu entityInformationFamilyPdu_1)
	{
		return !(entityInformationFamilyPdu_0 == entityInformationFamilyPdu_1);
	}

	public static bool operator ==(EntityInformationFamilyPdu entityInformationFamilyPdu_0, EntityInformationFamilyPdu entityInformationFamilyPdu_1)
	{
		if ((object)entityInformationFamilyPdu_0 == entityInformationFamilyPdu_1)
		{
			return true;
		}
		if ((object)entityInformationFamilyPdu_0 != null && (object)entityInformationFamilyPdu_1 != null)
		{
			return entityInformationFamilyPdu_0.Equals(entityInformationFamilyPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize();
	}

	public virtual void MarshalAutoLengthSet(DataOutputStream dataOutputStream_0)
	{
		base.Length = (ushort)GetMarshalledSize();
		Marshal(dataOutputStream_0);
	}

	public override void Marshal(DataOutputStream dataOutputStream_0)
	{
		base.Marshal(dataOutputStream_0);
	}

	public override void Unmarshal(DataInputStream dataInputStream_0)
	{
		base.Unmarshal(dataInputStream_0);
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<EntityInformationFamilyPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("</EntityInformationFamilyPdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EntityInformationFamilyPdu;
	}

	public bool Equals(EntityInformationFamilyPdu other)
	{
		if (other.GetType() == GetType())
		{
			return Equals((Pdu)other);
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
		return smethod_2(0) ^ base.GetHashCode();
	}
}
