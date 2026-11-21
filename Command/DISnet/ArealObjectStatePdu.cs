using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(SimulationAddress))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(Vector3Double))]
[XmlRoot]
public class ArealObjectStatePdu : SyntheticEnvironmentFamilyPdu, IEquatable<ArealObjectStatePdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private ushort ushort_1;

	private byte byte_5;

	private byte byte_6;

	private EntityType entityType_0 = new EntityType();

	private uint uint_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private SimulationAddress simulationAddress_0 = new SimulationAddress();

	private SimulationAddress simulationAddress_1 = new SimulationAddress();

	private List<Vector3Double> list_0 = new List<Vector3Double>();

	[XmlElement(Type = typeof(EntityID), ElementName = "objectID")]
	public EntityID ObjectID
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

	[XmlElement(Type = typeof(EntityID), ElementName = "referencedObjectID")]
	public EntityID ReferencedObjectID
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

	[XmlElement(Type = typeof(byte), ElementName = "modifications")]
	public byte Modifications
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

	[XmlElement(Type = typeof(EntityType), ElementName = "objectType")]
	public EntityType ObjectType
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

	[XmlElement(Type = typeof(uint), ElementName = "specificObjectAppearance")]
	public uint SpecificObjectAppearance
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

	[XmlElement(Type = typeof(ushort), ElementName = "generalObjectAppearance")]
	public ushort GeneralObjectAppearance
	{
		get
		{
			return ushort_2;
		}
		set
		{
			ushort_2 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfPoints")]
	public ushort NumberOfPoints
	{
		get
		{
			return ushort_3;
		}
		set
		{
			ushort_3 = value;
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

	[XmlElement(ElementName = "objectLocationList", Type = typeof(List<Vector3Double>))]
	public List<Vector3Double> ObjectLocation => list_0;

	public ArealObjectStatePdu()
	{
		base.PduType = 45;
	}

	public static bool operator !=(ArealObjectStatePdu arealObjectStatePdu_0, ArealObjectStatePdu arealObjectStatePdu_1)
	{
		return !(arealObjectStatePdu_0 == arealObjectStatePdu_1);
	}

	public static bool operator ==(ArealObjectStatePdu arealObjectStatePdu_0, ArealObjectStatePdu arealObjectStatePdu_1)
	{
		if ((object)arealObjectStatePdu_0 == arealObjectStatePdu_1)
		{
			return true;
		}
		if ((object)arealObjectStatePdu_0 != null && (object)arealObjectStatePdu_1 != null)
		{
			return arealObjectStatePdu_0.Equals(arealObjectStatePdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num += entityID_1.GetMarshalledSize();
		num += 2;
		num++;
		num++;
		num += entityType_0.GetMarshalledSize();
		num += 4;
		num += 2;
		num += 2;
		num += simulationAddress_0.GetMarshalledSize();
		num += simulationAddress_1.GetMarshalledSize();
		for (int i = 0; i < list_0.Count; i++)
		{
			Vector3Double vector3Double = list_0[i];
			num += vector3Double.GetMarshalledSize();
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
			entityID_1.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			dataOutputStream_0.WriteUnsignedByte(byte_5);
			dataOutputStream_0.WriteUnsignedByte(byte_6);
			entityType_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedInt(uint_1);
			dataOutputStream_0.WriteUnsignedShort(ushort_2);
			dataOutputStream_0.WriteUnsignedShort((ushort)list_0.Count);
			simulationAddress_0.Marshal(dataOutputStream_0);
			simulationAddress_1.Marshal(dataOutputStream_0);
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
			entityID_1.Unmarshal(dataInputStream_0);
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			entityType_0.Unmarshal(dataInputStream_0);
			uint_1 = dataInputStream_0.ReadUnsignedInt();
			ushort_2 = dataInputStream_0.ReadUnsignedShort();
			ushort_3 = dataInputStream_0.ReadUnsignedShort();
			simulationAddress_0.Unmarshal(dataInputStream_0);
			simulationAddress_1.Unmarshal(dataInputStream_0);
			for (int i = 0; i < NumberOfPoints; i++)
			{
				Vector3Double vector3Double = new Vector3Double();
				vector3Double.Unmarshal(dataInputStream_0);
				list_0.Add(vector3Double);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<ArealObjectStatePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<objectID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</objectID>");
			stringBuilder_0.AppendLine("<referencedObjectID>");
			entityID_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</referencedObjectID>");
			stringBuilder_0.AppendLine("<updateNumber type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</updateNumber>");
			stringBuilder_0.AppendLine("<forceID type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</forceID>");
			stringBuilder_0.AppendLine("<modifications type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</modifications>");
			stringBuilder_0.AppendLine("<objectType>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</objectType>");
			stringBuilder_0.AppendLine("<specificObjectAppearance type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</specificObjectAppearance>");
			stringBuilder_0.AppendLine("<generalObjectAppearance type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</generalObjectAppearance>");
			stringBuilder_0.AppendLine("<objectLocation type=\"ushort\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</objectLocation>");
			stringBuilder_0.AppendLine("<requesterID>");
			simulationAddress_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</requesterID>");
			stringBuilder_0.AppendLine("<receivingID>");
			simulationAddress_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</receivingID>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<objectLocation" + i.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Double\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</objectLocation" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</ArealObjectStatePdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as ArealObjectStatePdu;
	}

	public bool Equals(ArealObjectStatePdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((SyntheticEnvironmentFamilyPdu)other);
			if (!entityID_0.Equals(other.entityID_0))
			{
				flag = false;
			}
			if (!entityID_1.Equals(other.entityID_1))
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
			if (!entityType_0.Equals(other.entityType_0))
			{
				flag = false;
			}
			if (uint_1 != other.uint_1)
			{
				flag = false;
			}
			if (ushort_2 != other.ushort_2)
			{
				flag = false;
			}
			if (ushort_3 != other.ushort_3)
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
		num = smethod_3(num) ^ entityID_1.GetHashCode();
		num = smethod_3(num) ^ ushort_1.GetHashCode();
		num = smethod_3(num) ^ byte_5.GetHashCode();
		num = smethod_3(num) ^ byte_6.GetHashCode();
		num = smethod_3(num) ^ entityType_0.GetHashCode();
		num = smethod_3(num) ^ uint_1.GetHashCode();
		num = smethod_3(num) ^ ushort_2.GetHashCode();
		num = smethod_3(num) ^ ushort_3.GetHashCode();
		num = smethod_3(num) ^ simulationAddress_0.GetHashCode();
		num = smethod_3(num) ^ simulationAddress_1.GetHashCode();
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
