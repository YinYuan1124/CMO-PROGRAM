using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(Vector3Double))]
[XmlRoot]
public class DesignatorPdu : DistributedEmissionsFamilyPdu, IEquatable<DesignatorPdu>
{
	private EntityID entityID_0 = new EntityID();

	private ushort ushort_1;

	private EntityID entityID_1 = new EntityID();

	private ushort ushort_2;

	private float float_0;

	private float float_1;

	private Vector3Float vector3Float_0 = new Vector3Float();

	private Vector3Double vector3Double_0 = new Vector3Double();

	private byte byte_5;

	private ushort ushort_3;

	private byte byte_6;

	private Vector3Float vector3Float_1 = new Vector3Float();

	[XmlElement(Type = typeof(EntityID), ElementName = "designatingEntityID")]
	public EntityID DesignatingEntityID
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

	[XmlElement(Type = typeof(ushort), ElementName = "codeName")]
	public ushort CodeName
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

	[XmlElement(Type = typeof(EntityID), ElementName = "designatedEntityID")]
	public EntityID DesignatedEntityID
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

	[XmlElement(Type = typeof(ushort), ElementName = "designatorCode")]
	public ushort DesignatorCode
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

	[XmlElement(Type = typeof(float), ElementName = "designatorPower")]
	public float DesignatorPower
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

	[XmlElement(Type = typeof(float), ElementName = "designatorWavelength")]
	public float DesignatorWavelength
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "designatorSpotWrtDesignated")]
	public Vector3Float DesignatorSpotWrtDesignated
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "designatorSpotLocation")]
	public Vector3Double DesignatorSpotLocation
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

	[XmlElement(Type = typeof(byte), ElementName = "deadReckoningAlgorithm")]
	public byte DeadReckoningAlgorithm
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding1")]
	public ushort Padding1
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

	[XmlElement(Type = typeof(byte), ElementName = "padding2")]
	public byte Padding2
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "entityLinearAcceleration")]
	public Vector3Float EntityLinearAcceleration
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

	public DesignatorPdu()
	{
		base.PduType = 24;
	}

	public static bool operator !=(DesignatorPdu designatorPdu_0, DesignatorPdu designatorPdu_1)
	{
		return !(designatorPdu_0 == designatorPdu_1);
	}

	public static bool operator ==(DesignatorPdu designatorPdu_0, DesignatorPdu designatorPdu_1)
	{
		if ((object)designatorPdu_0 == designatorPdu_1)
		{
			return true;
		}
		if ((object)designatorPdu_0 != null && (object)designatorPdu_1 != null)
		{
			return designatorPdu_0.Equals(designatorPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + 2 + entityID_1.GetMarshalledSize() + 2 + 4 + 4 + vector3Float_0.GetMarshalledSize() + vector3Double_0.GetMarshalledSize() + 1 + 2 + 1 + vector3Float_1.GetMarshalledSize();
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
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
				entityID_1.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_2);
				dataOutputStream_0.WriteFloat(float_0);
				dataOutputStream_0.WriteFloat(float_1);
				vector3Float_0.Marshal(dataOutputStream_0);
				vector3Double_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteByte(byte_5);
				dataOutputStream_0.WriteUnsignedShort(ushort_3);
				dataOutputStream_0.WriteByte(byte_6);
				vector3Float_1.Marshal(dataOutputStream_0);
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
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
				entityID_1.Unmarshal(dataInputStream_0);
				ushort_2 = dataInputStream_0.ReadUnsignedShort();
				float_0 = dataInputStream_0.ReadFloat();
				float_1 = dataInputStream_0.ReadFloat();
				vector3Float_0.Unmarshal(dataInputStream_0);
				vector3Double_0.Unmarshal(dataInputStream_0);
				byte_5 = dataInputStream_0.ReadByte();
				ushort_3 = dataInputStream_0.ReadUnsignedShort();
				byte_6 = dataInputStream_0.ReadByte();
				vector3Float_1.Unmarshal(dataInputStream_0);
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<DesignatorPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<designatingEntityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</designatingEntityID>");
			stringBuilder_0.AppendLine("<codeName type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</codeName>");
			stringBuilder_0.AppendLine("<designatedEntityID>");
			entityID_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</designatedEntityID>");
			stringBuilder_0.AppendLine("<designatorCode type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</designatorCode>");
			stringBuilder_0.AppendLine("<designatorPower type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</designatorPower>");
			stringBuilder_0.AppendLine("<designatorWavelength type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</designatorWavelength>");
			stringBuilder_0.AppendLine("<designatorSpotWrtDesignated>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</designatorSpotWrtDesignated>");
			stringBuilder_0.AppendLine("<designatorSpotLocation>");
			vector3Double_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</designatorSpotLocation>");
			stringBuilder_0.AppendLine("<deadReckoningAlgorithm type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</deadReckoningAlgorithm>");
			stringBuilder_0.AppendLine("<padding1 type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			stringBuilder_0.AppendLine("<padding2 type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			stringBuilder_0.AppendLine("<entityLinearAcceleration>");
			vector3Float_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityLinearAcceleration>");
			stringBuilder_0.AppendLine("</DesignatorPdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as DesignatorPdu;
	}

	public bool Equals(DesignatorPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((DistributedEmissionsFamilyPdu)other);
			if (!entityID_0.Equals(other.entityID_0))
			{
				flag = false;
			}
			if (ushort_1 != other.ushort_1)
			{
				flag = false;
			}
			if (!entityID_1.Equals(other.entityID_1))
			{
				flag = false;
			}
			if (ushort_2 != other.ushort_2)
			{
				flag = false;
			}
			if (float_0 != other.float_0)
			{
				flag = false;
			}
			if (float_1 != other.float_1)
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
			if (byte_5 != other.byte_5)
			{
				flag = false;
			}
			if (ushort_3 != other.ushort_3)
			{
				flag = false;
			}
			if (byte_6 != other.byte_6)
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

	private static int smethod_3(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ entityID_1.GetHashCode()) ^ ushort_2.GetHashCode()) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ vector3Double_0.GetHashCode()) ^ byte_5.GetHashCode()) ^ ushort_3.GetHashCode()) ^ byte_6.GetHashCode()) ^ vector3Float_1.GetHashCode();
	}
}
