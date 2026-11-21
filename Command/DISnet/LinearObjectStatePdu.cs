using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(SimulationAddress))]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(ObjectType))]
[XmlRoot]
[XmlInclude(typeof(LinearSegmentParameter))]
public class LinearObjectStatePdu : SyntheticEnvironmentFamilyPdu, IEquatable<LinearObjectStatePdu>
{
	private EntityID sTaEgDtrtiQ = new EntityID();

	private EntityID entityID_0 = new EntityID();

	private ushort ushort_1;

	private byte byte_5;

	private byte byte_6;

	private SimulationAddress simulationAddress_0 = new SimulationAddress();

	private SimulationAddress simulationAddress_1 = new SimulationAddress();

	private ObjectType objectType_0 = new ObjectType();

	private List<LinearSegmentParameter> list_0 = new List<LinearSegmentParameter>();

	[XmlElement(Type = typeof(EntityID), ElementName = "objectID")]
	public EntityID ObjectID
	{
		get
		{
			return sTaEgDtrtiQ;
		}
		set
		{
			sTaEgDtrtiQ = value;
		}
	}

	[XmlElement(Type = typeof(EntityID), ElementName = "referencedObjectID")]
	public EntityID ReferencedObjectID
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

	[XmlElement(Type = typeof(ushort), ElementName = "updateNumber")]
	public ushort UpdateNumber
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

	[XmlElement(Type = typeof(byte), ElementName = "forceID")]
	public byte ForceID
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfSegments")]
	public byte NumberOfSegments
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

	[XmlElement(Type = typeof(SimulationAddress), ElementName = "requesterID")]
	public SimulationAddress RequesterID
	{
		get
		{
			return simulationAddress_0;
		}
		set
		{
			simulationAddress_0 = value;
		}
	}

	[XmlElement(Type = typeof(SimulationAddress), ElementName = "receivingID")]
	public SimulationAddress ReceivingID
	{
		get
		{
			return simulationAddress_1;
		}
		set
		{
			simulationAddress_1 = value;
		}
	}

	[XmlElement(Type = typeof(ObjectType), ElementName = "objectType")]
	public ObjectType ObjectType
	{
		get
		{
			return objectType_0;
		}
		set
		{
			objectType_0 = value;
		}
	}

	[XmlElement(ElementName = "linearSegmentParametersList", Type = typeof(List<LinearSegmentParameter>))]
	public List<LinearSegmentParameter> LinearSegmentParameters => list_0;

	public LinearObjectStatePdu()
	{
		base.PduType = 44;
	}

	public static bool operator !=(LinearObjectStatePdu linearObjectStatePdu_0, LinearObjectStatePdu linearObjectStatePdu_1)
	{
		return !(linearObjectStatePdu_0 == linearObjectStatePdu_1);
	}

	public static bool operator ==(LinearObjectStatePdu linearObjectStatePdu_0, LinearObjectStatePdu linearObjectStatePdu_1)
	{
		if ((object)linearObjectStatePdu_0 == linearObjectStatePdu_1)
		{
			return true;
		}
		if ((object)linearObjectStatePdu_0 != null && (object)linearObjectStatePdu_1 != null)
		{
			return linearObjectStatePdu_0.Equals(linearObjectStatePdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += sTaEgDtrtiQ.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num += 2;
		num++;
		num++;
		num += simulationAddress_0.GetMarshalledSize();
		num += simulationAddress_1.GetMarshalledSize();
		num += objectType_0.GetMarshalledSize();
		for (int i = 0; i < list_0.Count; i++)
		{
			LinearSegmentParameter linearSegmentParameter = list_0[i];
			num += linearSegmentParameter.GetMarshalledSize();
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
			sTaEgDtrtiQ.Marshal(dataOutputStream_0);
			entityID_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			dataOutputStream_0.WriteUnsignedByte(byte_5);
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			simulationAddress_0.Marshal(dataOutputStream_0);
			simulationAddress_1.Marshal(dataOutputStream_0);
			objectType_0.Marshal(dataOutputStream_0);
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
			sTaEgDtrtiQ.Unmarshal(dataInputStream_0);
			entityID_0.Unmarshal(dataInputStream_0);
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			simulationAddress_0.Unmarshal(dataInputStream_0);
			simulationAddress_1.Unmarshal(dataInputStream_0);
			objectType_0.Unmarshal(dataInputStream_0);
			for (int i = 0; i < NumberOfSegments; i++)
			{
				LinearSegmentParameter linearSegmentParameter = new LinearSegmentParameter();
				linearSegmentParameter.Unmarshal(dataInputStream_0);
				list_0.Add(linearSegmentParameter);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<LinearObjectStatePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<objectID>");
			sTaEgDtrtiQ.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</objectID>");
			stringBuilder_0.AppendLine("<referencedObjectID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</referencedObjectID>");
			stringBuilder_0.AppendLine("<updateNumber type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</updateNumber>");
			stringBuilder_0.AppendLine("<forceID type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</forceID>");
			stringBuilder_0.AppendLine("<linearSegmentParameters type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</linearSegmentParameters>");
			stringBuilder_0.AppendLine("<requesterID>");
			simulationAddress_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</requesterID>");
			stringBuilder_0.AppendLine("<receivingID>");
			simulationAddress_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</receivingID>");
			stringBuilder_0.AppendLine("<objectType>");
			objectType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</objectType>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<linearSegmentParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"LinearSegmentParameter\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</linearSegmentParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</LinearObjectStatePdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as LinearObjectStatePdu;
	}

	public bool Equals(LinearObjectStatePdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((SyntheticEnvironmentFamilyPdu)other);
			if (!sTaEgDtrtiQ.Equals(other.sTaEgDtrtiQ))
			{
				flag = false;
			}
			if (!entityID_0.Equals(other.entityID_0))
			{
				flag = false;
			}
			if (ushort_1 != other.ushort_1)
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
			if (!simulationAddress_0.Equals(other.simulationAddress_0))
			{
				flag = false;
			}
			if (!simulationAddress_1.Equals(other.simulationAddress_1))
			{
				flag = false;
			}
			if (!objectType_0.Equals(other.objectType_0))
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
		num = smethod_3(num) ^ sTaEgDtrtiQ.GetHashCode();
		num = smethod_3(num) ^ entityID_0.GetHashCode();
		num = smethod_3(num) ^ ushort_1.GetHashCode();
		num = smethod_3(num) ^ byte_5.GetHashCode();
		num = smethod_3(num) ^ byte_6.GetHashCode();
		num = smethod_3(num) ^ simulationAddress_0.GetHashCode();
		num = smethod_3(num) ^ simulationAddress_1.GetHashCode();
		num = smethod_3(num) ^ objectType_0.GetHashCode();
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
