using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(MunitionDescriptor))]
[XmlInclude(typeof(VariableParameter))]
[XmlInclude(typeof(EventIdentifier))]
public class DetonationPdu : WarfareFamilyPdu, IEquatable<DetonationPdu>
{
	private EntityID entityID_2 = new EntityID();

	private EventIdentifier eventIdentifier_0 = new EventIdentifier();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private Vector3Double vector3Double_0 = new Vector3Double();

	private MunitionDescriptor munitionDescriptor_0 = new MunitionDescriptor();

	private Vector3Float vector3Float_1 = new Vector3Float();

	private byte byte_5;

	private byte byte_6;

	private ushort ushort_1;

	private List<VariableParameter> list_0 = new List<VariableParameter>();

	[XmlElement(Type = typeof(EntityID), ElementName = "explodingEntityID")]
	public EntityID ExplodingEntityID
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "locationOfEntityCoordinates")]
	public Vector3Float LocationOfEntityCoordinates
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

	[XmlElement(Type = typeof(byte), ElementName = "detonationResult")]
	public byte DetonationResult
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfVariableParameters")]
	public byte NumberOfVariableParameters
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

	[XmlElement(Type = typeof(ushort), ElementName = "pad")]
	public ushort Pad
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

	[XmlElement(ElementName = "variableParametersList", Type = typeof(List<VariableParameter>))]
	public List<VariableParameter> VariableParameters => list_0;

	public DetonationPdu()
	{
		base.PduType = 3;
	}

	public static bool operator !=(DetonationPdu detonationPdu_0, DetonationPdu detonationPdu_1)
	{
		return !(detonationPdu_0 == detonationPdu_1);
	}

	public static bool operator ==(DetonationPdu detonationPdu_0, DetonationPdu detonationPdu_1)
	{
		if ((object)detonationPdu_0 == detonationPdu_1)
		{
			return true;
		}
		if ((object)detonationPdu_0 != null && (object)detonationPdu_1 != null)
		{
			return detonationPdu_0.Equals(detonationPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_2.GetMarshalledSize();
		num += eventIdentifier_0.GetMarshalledSize();
		num += vector3Float_0.GetMarshalledSize();
		num += vector3Double_0.GetMarshalledSize();
		num += munitionDescriptor_0.GetMarshalledSize();
		num += vector3Float_1.GetMarshalledSize();
		num++;
		num++;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			VariableParameter variableParameter = list_0[i];
			num += variableParameter.GetMarshalledSize();
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
			entityID_2.Marshal(dataOutputStream_0);
			eventIdentifier_0.Marshal(dataOutputStream_0);
			vector3Float_0.Marshal(dataOutputStream_0);
			vector3Double_0.Marshal(dataOutputStream_0);
			munitionDescriptor_0.Marshal(dataOutputStream_0);
			vector3Float_1.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedByte(byte_5);
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dataOutputStream_0);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
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
			entityID_2.Unmarshal(dataInputStream_0);
			eventIdentifier_0.Unmarshal(dataInputStream_0);
			vector3Float_0.Unmarshal(dataInputStream_0);
			vector3Double_0.Unmarshal(dataInputStream_0);
			munitionDescriptor_0.Unmarshal(dataInputStream_0);
			vector3Float_1.Unmarshal(dataInputStream_0);
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			for (int i = 0; i < NumberOfVariableParameters; i++)
			{
				VariableParameter variableParameter = new VariableParameter();
				variableParameter.Unmarshal(dataInputStream_0);
				list_0.Add(variableParameter);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<DetonationPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<explodingEntityID>");
			entityID_2.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</explodingEntityID>");
			stringBuilder_0.AppendLine("<eventID>");
			eventIdentifier_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</eventID>");
			stringBuilder_0.AppendLine("<velocity>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</velocity>");
			stringBuilder_0.AppendLine("<locationInWorldCoordinates>");
			vector3Double_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</locationInWorldCoordinates>");
			stringBuilder_0.AppendLine("<descriptor>");
			munitionDescriptor_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</descriptor>");
			stringBuilder_0.AppendLine("<locationOfEntityCoordinates>");
			vector3Float_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</locationOfEntityCoordinates>");
			stringBuilder_0.AppendLine("<detonationResult type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</detonationResult>");
			stringBuilder_0.AppendLine("<variableParameters type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</variableParameters>");
			stringBuilder_0.AppendLine("<pad type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</pad>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<variableParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"VariableParameter\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</variableParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</DetonationPdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as DetonationPdu;
	}

	public bool Equals(DetonationPdu other)
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
			if (!vector3Float_0.Equals(other.vector3Float_0))
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
			if (!vector3Float_1.Equals(other.vector3Float_1))
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
			if (ushort_1 != other.ushort_1)
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

	private static int smethod_3(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_3(0) ^ base.GetHashCode();
		num = smethod_3(num) ^ entityID_2.GetHashCode();
		num = smethod_3(num) ^ eventIdentifier_0.GetHashCode();
		num = smethod_3(num) ^ vector3Float_0.GetHashCode();
		num = smethod_3(num) ^ vector3Double_0.GetHashCode();
		num = smethod_3(num) ^ munitionDescriptor_0.GetHashCode();
		num = smethod_3(num) ^ vector3Float_1.GetHashCode();
		num = smethod_3(num) ^ byte_5.GetHashCode();
		num = smethod_3(num) ^ byte_6.GetHashCode();
		num = smethod_3(num) ^ ushort_1.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_3(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}
}
