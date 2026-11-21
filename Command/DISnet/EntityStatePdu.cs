using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EntityType))]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(EntityMarking))]
[XmlInclude(typeof(DeadReckoningParameters))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(VariableParameter))]
[XmlInclude(typeof(EulerAngles))]
public class EntityStatePdu : EntityInformationFamilyPdu, IEquatable<EntityStatePdu>
{
	private EntityID entityID_0 = new EntityID();

	private byte byte_5;

	private byte byte_6;

	private EntityType entityType_0 = new EntityType();

	private EntityType entityType_1 = new EntityType();

	private Vector3Float rmxExypEgjH = new Vector3Float();

	private Vector3Double vector3Double_0 = new Vector3Double();

	private EulerAngles eulerAngles_0 = new EulerAngles();

	private uint uint_1;

	private DeadReckoningParameters deadReckoningParameters_0 = new DeadReckoningParameters();

	private EntityMarking entityMarking_0 = new EntityMarking();

	private uint uint_2;

	private List<VariableParameter> list_0 = new List<VariableParameter>();

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
			return rmxExypEgjH;
		}
		set
		{
			rmxExypEgjH = value;
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

	[XmlElement(Type = typeof(EulerAngles), ElementName = "entityOrientation")]
	public EulerAngles EntityOrientation
	{
		get
		{
			return eulerAngles_0;
		}
		set
		{
			eulerAngles_0 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "entityAppearance")]
	public uint EntityAppearance
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

	[XmlElement(Type = typeof(DeadReckoningParameters), ElementName = "deadReckoningParameters")]
	public DeadReckoningParameters DeadReckoningParameters
	{
		get
		{
			return deadReckoningParameters_0;
		}
		set
		{
			deadReckoningParameters_0 = value;
		}
	}

	[XmlElement(Type = typeof(EntityMarking), ElementName = "marking")]
	public EntityMarking Marking
	{
		get
		{
			return entityMarking_0;
		}
		set
		{
			entityMarking_0 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "capabilities")]
	public uint Capabilities
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

	[XmlElement(ElementName = "variableParametersList", Type = typeof(List<VariableParameter>))]
	public List<VariableParameter> VariableParameters => list_0;

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
		num += rmxExypEgjH.GetMarshalledSize();
		num += vector3Double_0.GetMarshalledSize();
		num += eulerAngles_0.GetMarshalledSize();
		num += 4;
		num += deadReckoningParameters_0.GetMarshalledSize();
		num += entityMarking_0.GetMarshalledSize();
		num += 4;
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
			entityID_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedByte(byte_5);
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			entityType_0.Marshal(dataOutputStream_0);
			entityType_1.Marshal(dataOutputStream_0);
			rmxExypEgjH.Marshal(dataOutputStream_0);
			vector3Double_0.Marshal(dataOutputStream_0);
			eulerAngles_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedInt(uint_1);
			deadReckoningParameters_0.Marshal(dataOutputStream_0);
			entityMarking_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedInt(uint_2);
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
			entityID_0.Unmarshal(dataInputStream_0);
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			entityType_0.Unmarshal(dataInputStream_0);
			entityType_1.Unmarshal(dataInputStream_0);
			rmxExypEgjH.Unmarshal(dataInputStream_0);
			vector3Double_0.Unmarshal(dataInputStream_0);
			eulerAngles_0.Unmarshal(dataInputStream_0);
			uint_1 = dataInputStream_0.ReadUnsignedInt();
			deadReckoningParameters_0.Unmarshal(dataInputStream_0);
			entityMarking_0.Unmarshal(dataInputStream_0);
			uint_2 = dataInputStream_0.ReadUnsignedInt();
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
		stringBuilder_0.AppendLine("<EntityStatePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<entityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityID>");
			stringBuilder_0.AppendLine("<forceId type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</forceId>");
			stringBuilder_0.AppendLine("<variableParameters type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</variableParameters>");
			stringBuilder_0.AppendLine("<entityType>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityType>");
			stringBuilder_0.AppendLine("<alternativeEntityType>");
			entityType_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</alternativeEntityType>");
			stringBuilder_0.AppendLine("<entityLinearVelocity>");
			rmxExypEgjH.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityLinearVelocity>");
			stringBuilder_0.AppendLine("<entityLocation>");
			vector3Double_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityLocation>");
			stringBuilder_0.AppendLine("<entityOrientation>");
			eulerAngles_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityOrientation>");
			stringBuilder_0.AppendLine("<entityAppearance type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</entityAppearance>");
			stringBuilder_0.AppendLine("<deadReckoningParameters>");
			deadReckoningParameters_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</deadReckoningParameters>");
			stringBuilder_0.AppendLine("<marking>");
			entityMarking_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</marking>");
			stringBuilder_0.AppendLine("<capabilities type=\"uint\">" + uint_2.ToString(CultureInfo.InvariantCulture) + "</capabilities>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<variableParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"VariableParameter\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</variableParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</EntityStatePdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
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
			if (byte_5 != other.byte_5)
			{
				flag = false;
			}
			if (byte_6 != other.byte_6)
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
			if (!rmxExypEgjH.Equals(other.rmxExypEgjH))
			{
				flag = false;
			}
			if (!vector3Double_0.Equals(other.vector3Double_0))
			{
				flag = false;
			}
			if (!eulerAngles_0.Equals(other.eulerAngles_0))
			{
				flag = false;
			}
			if (uint_1 != other.uint_1)
			{
				flag = false;
			}
			if (!deadReckoningParameters_0.Equals(other.deadReckoningParameters_0))
			{
				flag = false;
			}
			if (!entityMarking_0.Equals(other.entityMarking_0))
			{
				flag = false;
			}
			if (uint_2 != other.uint_2)
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
		num = smethod_3(num) ^ entityID_0.GetHashCode();
		num = smethod_3(num) ^ byte_5.GetHashCode();
		num = smethod_3(num) ^ byte_6.GetHashCode();
		num = smethod_3(num) ^ entityType_0.GetHashCode();
		num = smethod_3(num) ^ entityType_1.GetHashCode();
		num = smethod_3(num) ^ rmxExypEgjH.GetHashCode();
		num = smethod_3(num) ^ vector3Double_0.GetHashCode();
		num = smethod_3(num) ^ eulerAngles_0.GetHashCode();
		num = smethod_3(num) ^ uint_1.GetHashCode();
		num = smethod_3(num) ^ deadReckoningParameters_0.GetHashCode();
		num = smethod_3(num) ^ entityMarking_0.GetHashCode();
		num = smethod_3(num) ^ uint_2.GetHashCode();
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
