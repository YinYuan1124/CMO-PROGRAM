using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
[XmlInclude(typeof(EventIdentifier))]
[XmlInclude(typeof(MunitionDescriptor))]
[XmlInclude(typeof(Vector3Double))]
public class FirePdu : WarfareFamilyPdu, IEquatable<FirePdu>
{
	private EntityID entityID_2 = new EntityID();

	private EventIdentifier eventIdentifier_0 = new EventIdentifier();

	private uint uint_1;

	private Vector3Double vector3Double_0 = new Vector3Double();

	private MunitionDescriptor munitionDescriptor_0 = new MunitionDescriptor();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private float float_0;

	[XmlElement(Type = typeof(EntityID), ElementName = "munitionExpendibleID")]
	public EntityID MunitionExpendibleID
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

	[XmlElement(Type = typeof(EventIdentifier), ElementName = "eventID")]
	public EventIdentifier EventID
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

	[XmlElement(Type = typeof(uint), ElementName = "fireMissionIndex")]
	public uint FireMissionIndex
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "locationInWorldCoordinates")]
	public Vector3Double LocationInWorldCoordinates
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

	[XmlElement(Type = typeof(MunitionDescriptor), ElementName = "descriptor")]
	public MunitionDescriptor Descriptor
	{
		get
		{
			return munitionDescriptor_0;
		}
		set
		{
			munitionDescriptor_0 = value;
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

	[XmlElement(Type = typeof(float), ElementName = "range")]
	public float Range
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

	public FirePdu()
	{
		base.PduType = 2;
	}

	public static bool operator !=(FirePdu firePdu_0, FirePdu firePdu_1)
	{
		return !(firePdu_0 == firePdu_1);
	}

	public static bool operator ==(FirePdu firePdu_0, FirePdu firePdu_1)
	{
		if ((object)firePdu_0 == firePdu_1)
		{
			return true;
		}
		if ((object)firePdu_0 != null && (object)firePdu_1 != null)
		{
			return firePdu_0.Equals(firePdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_2.GetMarshalledSize() + eventIdentifier_0.GetMarshalledSize() + 4 + vector3Double_0.GetMarshalledSize() + munitionDescriptor_0.GetMarshalledSize() + vector3Float_0.GetMarshalledSize() + 4;
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
				eventIdentifier_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedInt(uint_1);
				vector3Double_0.Marshal(dataOutputStream_0);
				munitionDescriptor_0.Marshal(dataOutputStream_0);
				vector3Float_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteFloat(float_0);
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
				eventIdentifier_0.Unmarshal(dataInputStream_0);
				uint_1 = dataInputStream_0.ReadUnsignedInt();
				vector3Double_0.Unmarshal(dataInputStream_0);
				munitionDescriptor_0.Unmarshal(dataInputStream_0);
				vector3Float_0.Unmarshal(dataInputStream_0);
				float_0 = dataInputStream_0.ReadFloat();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<FirePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<munitionExpendibleID>");
			entityID_2.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</munitionExpendibleID>");
			stringBuilder_0.AppendLine("<eventID>");
			eventIdentifier_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</eventID>");
			stringBuilder_0.AppendLine("<fireMissionIndex type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</fireMissionIndex>");
			stringBuilder_0.AppendLine("<locationInWorldCoordinates>");
			vector3Double_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</locationInWorldCoordinates>");
			stringBuilder_0.AppendLine("<descriptor>");
			munitionDescriptor_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</descriptor>");
			stringBuilder_0.AppendLine("<velocity>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</velocity>");
			stringBuilder_0.AppendLine("<range type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</range>");
			stringBuilder_0.AppendLine("</FirePdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as FirePdu;
	}

	public bool Equals(FirePdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((WarfareFamilyPdu)other);
			if (!entityID_2.Equals(other.entityID_2))
			{
				flag = false;
			}
			if (!eventIdentifier_0.Equals(other.eventIdentifier_0))
			{
				flag = false;
			}
			if (uint_1 != other.uint_1)
			{
				flag = false;
			}
			if (!vector3Double_0.Equals(other.vector3Double_0))
			{
				flag = false;
			}
			if (!munitionDescriptor_0.Equals(other.munitionDescriptor_0))
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
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ entityID_2.GetHashCode()) ^ eventIdentifier_0.GetHashCode()) ^ uint_1.GetHashCode()) ^ vector3Double_0.GetHashCode()) ^ munitionDescriptor_0.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ float_0.GetHashCode();
	}
}
