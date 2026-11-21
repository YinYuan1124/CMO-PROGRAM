using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(DirectedEnergyDamage))]
public class EntityDamageStatusPdu : WarfareFamilyPdu, IEquatable<EntityDamageStatusPdu>
{
	private EntityID entityID_2 = new EntityID();

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private List<DirectedEnergyDamage> list_0 = new List<DirectedEnergyDamage>();

	[XmlElement(Type = typeof(EntityID), ElementName = "damagedEntityID")]
	public EntityID DamagedEntityID
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding1")]
	public ushort Padding1
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding2")]
	public ushort Padding2
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

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfDamageDescription")]
	public ushort NumberOfDamageDescription
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

	[XmlElement(ElementName = "damageDescriptionRecordsList", Type = typeof(List<DirectedEnergyDamage>))]
	public List<DirectedEnergyDamage> DamageDescriptionRecords => list_0;

	public EntityDamageStatusPdu()
	{
		base.PduType = 69;
	}

	public static bool operator !=(EntityDamageStatusPdu entityDamageStatusPdu_0, EntityDamageStatusPdu entityDamageStatusPdu_1)
	{
		return !(entityDamageStatusPdu_0 == entityDamageStatusPdu_1);
	}

	public static bool operator ==(EntityDamageStatusPdu entityDamageStatusPdu_0, EntityDamageStatusPdu entityDamageStatusPdu_1)
	{
		if ((object)entityDamageStatusPdu_0 == entityDamageStatusPdu_1)
		{
			return true;
		}
		if ((object)entityDamageStatusPdu_0 != null && (object)entityDamageStatusPdu_1 != null)
		{
			return entityDamageStatusPdu_0.Equals(entityDamageStatusPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_2.GetMarshalledSize();
		num += 2;
		num += 2;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			DirectedEnergyDamage directedEnergyDamage = list_0[i];
			num += directedEnergyDamage.GetMarshalledSize();
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
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			dataOutputStream_0.WriteUnsignedShort(ushort_2);
			dataOutputStream_0.WriteUnsignedShort((ushort)list_0.Count);
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
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			ushort_2 = dataInputStream_0.ReadUnsignedShort();
			ushort_3 = dataInputStream_0.ReadUnsignedShort();
			for (int i = 0; i < NumberOfDamageDescription; i++)
			{
				DirectedEnergyDamage directedEnergyDamage = new DirectedEnergyDamage();
				directedEnergyDamage.Unmarshal(dataInputStream_0);
				list_0.Add(directedEnergyDamage);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<EntityDamageStatusPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<damagedEntityID>");
			entityID_2.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</damagedEntityID>");
			stringBuilder_0.AppendLine("<padding1 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			stringBuilder_0.AppendLine("<padding2 type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			stringBuilder_0.AppendLine("<damageDescriptionRecords type=\"ushort\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</damageDescriptionRecords>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<damageDescriptionRecords" + i.ToString(CultureInfo.InvariantCulture) + " type=\"DirectedEnergyDamage\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</damageDescriptionRecords" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</EntityDamageStatusPdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EntityDamageStatusPdu;
	}

	public bool Equals(EntityDamageStatusPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((WarfareFamilyPdu)other);
			if (!entityID_2.Equals(other.entityID_2))
			{
				flag = false;
			}
			if (ushort_1 != other.ushort_1)
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
		num = smethod_3(num) ^ ushort_1.GetHashCode();
		num = smethod_3(num) ^ ushort_2.GetHashCode();
		num = smethod_3(num) ^ ushort_3.GetHashCode();
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
