#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
[XmlInclude(typeof(SupplyQuantity))]
public class ServiceRequestPdu : LogisticsPdu, IEquatable<ServiceRequestPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private byte byte_4;

	private byte byte_5;

	private short short_1;

	private List<SupplyQuantity> list_0 = new List<SupplyQuantity>();

	[XmlElement(Type = typeof(EntityID), ElementName = "requestingEntityID")]
	public EntityID RequestingEntityID
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

	[XmlElement(Type = typeof(EntityID), ElementName = "servicingEntityID")]
	public EntityID ServicingEntityID
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

	[XmlElement(Type = typeof(byte), ElementName = "serviceTypeRequested")]
	public byte ServiceTypeRequested
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfSupplyTypes")]
	public byte NumberOfSupplyTypes
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

	[XmlElement(Type = typeof(short), ElementName = "serviceRequestPadding")]
	public short ServiceRequestPadding
	{
		get
		{
			return short_1;
		}
		set
		{
			short_1 = value;
		}
	}

	[XmlElement(ElementName = "suppliesList", Type = typeof(List<SupplyQuantity>))]
	public List<SupplyQuantity> Supplies => list_0;

	public ServiceRequestPdu()
	{
		base.PduType = 5;
	}

	public static bool operator !=(ServiceRequestPdu serviceRequestPdu_0, ServiceRequestPdu serviceRequestPdu_1)
	{
		return !(serviceRequestPdu_0 == serviceRequestPdu_1);
	}

	public static bool operator ==(ServiceRequestPdu serviceRequestPdu_0, ServiceRequestPdu serviceRequestPdu_1)
	{
		if ((object)serviceRequestPdu_0 == serviceRequestPdu_1)
		{
			return true;
		}
		if ((object)serviceRequestPdu_0 != null && (object)serviceRequestPdu_1 != null)
		{
			return serviceRequestPdu_0.Equals(serviceRequestPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num += entityID_1.GetMarshalledSize();
		num++;
		num++;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			SupplyQuantity supplyQuantity = list_0[i];
			num += supplyQuantity.GetMarshalledSize();
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
			dataOutputStream_0.WriteUnsignedByte(byte_4);
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			dataOutputStream_0.WriteShort(short_1);
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
			entityID_1.Unmarshal(dataInputStream_0);
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			short_1 = dataInputStream_0.ReadShort();
			for (int i = 0; i < NumberOfSupplyTypes; i++)
			{
				SupplyQuantity supplyQuantity = new SupplyQuantity();
				supplyQuantity.Unmarshal(dataInputStream_0);
				list_0.Add(supplyQuantity);
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
		stringBuilder_0.AppendLine("<ServiceRequestPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<requestingEntityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</requestingEntityID>");
			stringBuilder_0.AppendLine("<servicingEntityID>");
			entityID_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</servicingEntityID>");
			stringBuilder_0.AppendLine("<serviceTypeRequested type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</serviceTypeRequested>");
			stringBuilder_0.AppendLine("<supplies type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</supplies>");
			stringBuilder_0.AppendLine("<serviceRequestPadding type=\"short\">" + short_1.ToString(CultureInfo.InvariantCulture) + "</serviceRequestPadding>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<supplies" + i.ToString(CultureInfo.InvariantCulture) + " type=\"SupplyQuantity\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</supplies" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</ServiceRequestPdu>");
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
		return this == obj as ServiceRequestPdu;
	}

	public bool Equals(ServiceRequestPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((LogisticsPdu)other);
			if (!entityID_0.Equals(other.entityID_0))
			{
				flag = false;
			}
			if (!entityID_1.Equals(other.entityID_1))
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
			if (short_1 != other.short_1)
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
		num = smethod_2(num) ^ entityID_1.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ short_1.GetHashCode();
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
