#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(ObjectType))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(Orientation))]
[XmlInclude(typeof(SimulationAddress))]
public class PointObjectStatePdu : SyntheticEnvironmentFamilyPdu, IEquatable<PointObjectStatePdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private ushort ushort_1;

	private byte byte_4;

	private byte byte_5;

	private ObjectType objectType_0 = new ObjectType();

	private Vector3Double vector3Double_0 = new Vector3Double();

	private Orientation rJwEuaDyDq0 = new Orientation();

	private double double_0;

	private SimulationAddress simulationAddress_0 = new SimulationAddress();

	private SimulationAddress simulationAddress_1 = new SimulationAddress();

	private uint uint_1;

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
			return byte_4;
		}
		set
		{
			byte_4 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "modifications")]
	public byte Modifications
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "objectLocation")]
	public Vector3Double ObjectLocation
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

	[XmlElement(Type = typeof(Orientation), ElementName = "objectOrientation")]
	public Orientation ObjectOrientation
	{
		get
		{
			return rJwEuaDyDq0;
		}
		set
		{
			rJwEuaDyDq0 = value;
		}
	}

	[XmlElement(Type = typeof(double), ElementName = "objectAppearance")]
	public double ObjectAppearance
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
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

	[XmlElement(Type = typeof(uint), ElementName = "pad2")]
	public uint Pad2
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

	public PointObjectStatePdu()
	{
		base.PduType = 43;
	}

	public static bool operator !=(PointObjectStatePdu pointObjectStatePdu_0, PointObjectStatePdu pointObjectStatePdu_1)
	{
		return !(pointObjectStatePdu_0 == pointObjectStatePdu_1);
	}

	public static bool operator ==(PointObjectStatePdu pointObjectStatePdu_0, PointObjectStatePdu pointObjectStatePdu_1)
	{
		if ((object)pointObjectStatePdu_0 == pointObjectStatePdu_1)
		{
			return true;
		}
		if ((object)pointObjectStatePdu_0 != null && (object)pointObjectStatePdu_1 != null)
		{
			return pointObjectStatePdu_0.Equals(pointObjectStatePdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + entityID_1.GetMarshalledSize() + 2 + 1 + 1 + objectType_0.GetMarshalledSize() + vector3Double_0.GetMarshalledSize() + rJwEuaDyDq0.GetMarshalledSize() + 8 + simulationAddress_0.GetMarshalledSize() + simulationAddress_1.GetMarshalledSize() + 4;
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
			dataOutputStream_0.WriteUnsignedByte(byte_4);
			dataOutputStream_0.WriteUnsignedByte(byte_5);
			objectType_0.Marshal(dataOutputStream_0);
			vector3Double_0.Marshal(dataOutputStream_0);
			rJwEuaDyDq0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteDouble(double_0);
			simulationAddress_0.Marshal(dataOutputStream_0);
			simulationAddress_1.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedInt(uint_1);
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
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			objectType_0.Unmarshal(dataInputStream_0);
			vector3Double_0.Unmarshal(dataInputStream_0);
			rJwEuaDyDq0.Unmarshal(dataInputStream_0);
			double_0 = dataInputStream_0.ReadDouble();
			simulationAddress_0.Unmarshal(dataInputStream_0);
			simulationAddress_1.Unmarshal(dataInputStream_0);
			uint_1 = dataInputStream_0.ReadUnsignedInt();
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
		stringBuilder_0.AppendLine("<PointObjectStatePdu>");
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
			stringBuilder_0.AppendLine("<forceID type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</forceID>");
			stringBuilder_0.AppendLine("<modifications type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</modifications>");
			stringBuilder_0.AppendLine("<objectType>");
			objectType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</objectType>");
			stringBuilder_0.AppendLine("<objectLocation>");
			vector3Double_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</objectLocation>");
			stringBuilder_0.AppendLine("<objectOrientation>");
			rJwEuaDyDq0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</objectOrientation>");
			stringBuilder_0.AppendLine("<objectAppearance type=\"double\">" + double_0.ToString(CultureInfo.InvariantCulture) + "</objectAppearance>");
			stringBuilder_0.AppendLine("<requesterID>");
			simulationAddress_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</requesterID>");
			stringBuilder_0.AppendLine("<receivingID>");
			simulationAddress_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</receivingID>");
			stringBuilder_0.AppendLine("<pad2 type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			stringBuilder_0.AppendLine("</PointObjectStatePdu>");
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
		return this == obj as PointObjectStatePdu;
	}

	public bool Equals(PointObjectStatePdu other)
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
			if (byte_4 != other.byte_4)
			{
				flag = false;
			}
			if (byte_5 != other.byte_5)
			{
				flag = false;
			}
			if (!objectType_0.Equals(other.objectType_0))
			{
				flag = false;
			}
			if (!vector3Double_0.Equals(other.vector3Double_0))
			{
				flag = false;
			}
			if (!rJwEuaDyDq0.Equals(other.rJwEuaDyDq0))
			{
				flag = false;
			}
			if (double_0 != other.double_0)
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
			if (uint_1 != other.uint_1)
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
		return smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ entityID_1.GetHashCode()) ^ ushort_1.GetHashCode()) ^ byte_4.GetHashCode()) ^ byte_5.GetHashCode()) ^ objectType_0.GetHashCode()) ^ vector3Double_0.GetHashCode()) ^ rJwEuaDyDq0.GetHashCode()) ^ double_0.GetHashCode()) ^ simulationAddress_0.GetHashCode()) ^ simulationAddress_1.GetHashCode()) ^ uint_1.GetHashCode();
	}
}
