using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class RepairCompletePdu : LogisticsFamilyPdu, IEquatable<RepairCompletePdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private ushort ushort_1;

	private short short_0;

	[XmlElement(Type = typeof(EntityID), ElementName = "receivingEntityID")]
	public EntityID ReceivingEntityID
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

	[XmlElement(Type = typeof(EntityID), ElementName = "repairingEntityID")]
	public EntityID RepairingEntityID
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

	[XmlElement(Type = typeof(ushort), ElementName = "repair")]
	public ushort Repair
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

	[XmlElement(Type = typeof(short), ElementName = "padding4")]
	public short Padding4
	{
		get
		{
			return short_0;
		}
		set
		{
			short_0 = value;
		}
	}

	public RepairCompletePdu()
	{
		base.PduType = 9;
	}

	public static bool operator !=(RepairCompletePdu repairCompletePdu_0, RepairCompletePdu repairCompletePdu_1)
	{
		return !(repairCompletePdu_0 == repairCompletePdu_1);
	}

	public static bool operator ==(RepairCompletePdu repairCompletePdu_0, RepairCompletePdu repairCompletePdu_1)
	{
		if ((object)repairCompletePdu_0 == repairCompletePdu_1)
		{
			return true;
		}
		if ((object)repairCompletePdu_0 != null && (object)repairCompletePdu_1 != null)
		{
			return repairCompletePdu_0.Equals(repairCompletePdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + entityID_1.GetMarshalledSize() + 2 + 2;
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
				entityID_1.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
				dataOutputStream_0.WriteShort(short_0);
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
				entityID_1.Unmarshal(dataInputStream_0);
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
				short_0 = dataInputStream_0.ReadShort();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<RepairCompletePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<receivingEntityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</receivingEntityID>");
			stringBuilder_0.AppendLine("<repairingEntityID>");
			entityID_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</repairingEntityID>");
			stringBuilder_0.AppendLine("<repair type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</repair>");
			stringBuilder_0.AppendLine("<padding4 type=\"short\">" + short_0.ToString(CultureInfo.InvariantCulture) + "</padding4>");
			stringBuilder_0.AppendLine("</RepairCompletePdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as RepairCompletePdu;
	}

	public bool Equals(RepairCompletePdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((LogisticsFamilyPdu)other);
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
			if (short_0 != other.short_0)
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
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ entityID_1.GetHashCode()) ^ ushort_1.GetHashCode()) ^ short_0.GetHashCode();
	}
}
