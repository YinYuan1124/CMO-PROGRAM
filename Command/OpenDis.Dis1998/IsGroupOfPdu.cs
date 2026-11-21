#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(VariableDatum))]
public class IsGroupOfPdu : EntityManagementFamilyPdu, IEquatable<IsGroupOfPdu>
{
	private EntityID entityID_0 = new EntityID();

	private byte byte_4;

	private byte byte_5;

	private uint uint_1;

	private double double_0;

	private double double_1;

	private List<VariableDatum> list_0 = new List<VariableDatum>();

	[XmlElement(Type = typeof(EntityID), ElementName = "groupEntityID")]
	public EntityID GroupEntityID
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

	[XmlElement(Type = typeof(byte), ElementName = "groupedEntityCategory")]
	public byte GroupedEntityCategory
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfGroupedEntities")]
	public byte NumberOfGroupedEntities
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

	[XmlElement(Type = typeof(double), ElementName = "latitude")]
	public double Latitude
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

	[XmlElement(Type = typeof(double), ElementName = "longitude")]
	public double Longitude
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	[XmlElement(ElementName = "groupedEntityDescriptionsList", Type = typeof(List<VariableDatum>))]
	public List<VariableDatum> GroupedEntityDescriptions => list_0;

	public IsGroupOfPdu()
	{
		base.PduType = 34;
	}

	public static bool operator !=(IsGroupOfPdu isGroupOfPdu_0, IsGroupOfPdu isGroupOfPdu_1)
	{
		return !(isGroupOfPdu_0 == isGroupOfPdu_1);
	}

	public static bool operator ==(IsGroupOfPdu isGroupOfPdu_0, IsGroupOfPdu isGroupOfPdu_1)
	{
		if ((object)isGroupOfPdu_0 == isGroupOfPdu_1)
		{
			return true;
		}
		if ((object)isGroupOfPdu_0 != null && (object)isGroupOfPdu_1 != null)
		{
			return isGroupOfPdu_0.Equals(isGroupOfPdu_1);
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
		num += 4;
		num += 8;
		num += 8;
		for (int i = 0; i < list_0.Count; i++)
		{
			VariableDatum variableDatum = list_0[i];
			num += variableDatum.GetMarshalledSize();
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
			dataOutputStream_0.WriteUnsignedByte(byte_4);
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			dataOutputStream_0.WriteUnsignedInt(uint_1);
			dataOutputStream_0.WriteDouble(double_0);
			dataOutputStream_0.WriteDouble(double_1);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dataOutputStream_0);
			}
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
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			uint_1 = dataInputStream_0.ReadUnsignedInt();
			double_0 = dataInputStream_0.ReadDouble();
			double_1 = dataInputStream_0.ReadDouble();
			for (int i = 0; i < NumberOfGroupedEntities; i++)
			{
				VariableDatum variableDatum = new VariableDatum();
				variableDatum.Unmarshal(dataInputStream_0);
				list_0.Add(variableDatum);
			}
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
		stringBuilder_0.AppendLine("<IsGroupOfPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<groupEntityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</groupEntityID>");
			stringBuilder_0.AppendLine("<groupedEntityCategory type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</groupedEntityCategory>");
			stringBuilder_0.AppendLine("<groupedEntityDescriptions type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</groupedEntityDescriptions>");
			stringBuilder_0.AppendLine("<pad2 type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			stringBuilder_0.AppendLine("<latitude type=\"double\">" + double_0.ToString(CultureInfo.InvariantCulture) + "</latitude>");
			stringBuilder_0.AppendLine("<longitude type=\"double\">" + double_1.ToString(CultureInfo.InvariantCulture) + "</longitude>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<groupedEntityDescriptions" + i.ToString(CultureInfo.InvariantCulture) + " type=\"VariableDatum\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</groupedEntityDescriptions" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</IsGroupOfPdu>");
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
		return this == obj as IsGroupOfPdu;
	}

	public bool Equals(IsGroupOfPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((EntityManagementFamilyPdu)other);
			if (!entityID_0.Equals(other.entityID_0))
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
			if (uint_1 != other.uint_1)
			{
				flag = false;
			}
			if (double_0 != other.double_0)
			{
				flag = false;
			}
			if (double_1 != other.double_1)
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

	private static int smethod_2(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_2(0) ^ base.GetHashCode();
		num = smethod_2(num) ^ entityID_0.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ uint_1.GetHashCode();
		num = smethod_2(num) ^ double_0.GetHashCode();
		num = smethod_2(num) ^ double_1.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}
}
