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
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(ElectronicEmissionSystemData))]
[XmlRoot]
[XmlInclude(typeof(EventID))]
public class ElectronicEmissionsPdu : DistributedEmissionsFamilyPdu, IEquatable<ElectronicEmissionsPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EventID eventID_0 = new EventID();

	private byte byte_4;

	private byte byte_5;

	private ushort ushort_1;

	private List<ElectronicEmissionSystemData> list_0 = new List<ElectronicEmissionSystemData>();

	[XmlElement(Type = typeof(EntityID), ElementName = "emittingEntityID")]
	public EntityID EmittingEntityID
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

	[XmlElement(Type = typeof(EventID), ElementName = "eventID")]
	public EventID EventID
	{
		get
		{
			return eventID_0;
		}
		set
		{
			eventID_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "stateUpdateIndicator")]
	public byte StateUpdateIndicator
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfSystems")]
	public byte NumberOfSystems
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

	[XmlElement(Type = typeof(ushort), ElementName = "paddingForEmissionsPdu")]
	public ushort PaddingForEmissionsPdu
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

	[XmlElement(ElementName = "systemsList", Type = typeof(List<ElectronicEmissionSystemData>))]
	public List<ElectronicEmissionSystemData> Systems => list_0;

	public ElectronicEmissionsPdu()
	{
		base.PduType = 23;
	}

	public static bool operator !=(ElectronicEmissionsPdu electronicEmissionsPdu_0, ElectronicEmissionsPdu electronicEmissionsPdu_1)
	{
		return !(electronicEmissionsPdu_0 == electronicEmissionsPdu_1);
	}

	public static bool operator ==(ElectronicEmissionsPdu electronicEmissionsPdu_0, ElectronicEmissionsPdu electronicEmissionsPdu_1)
	{
		if ((object)electronicEmissionsPdu_0 == electronicEmissionsPdu_1)
		{
			return true;
		}
		if ((object)electronicEmissionsPdu_0 != null && (object)electronicEmissionsPdu_1 != null)
		{
			return electronicEmissionsPdu_0.Equals(electronicEmissionsPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num += eventID_0.GetMarshalledSize();
		num++;
		num++;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			ElectronicEmissionSystemData electronicEmissionSystemData = list_0[i];
			num += electronicEmissionSystemData.GetMarshalledSize();
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
			eventID_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedByte(byte_4);
			dataOutputStream_0.WriteUnsignedByte((byte)list_0.Count);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
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
			eventID_0.Unmarshal(dataInputStream_0);
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			for (int i = 0; i < NumberOfSystems; i++)
			{
				ElectronicEmissionSystemData electronicEmissionSystemData = new ElectronicEmissionSystemData();
				electronicEmissionSystemData.Unmarshal(dataInputStream_0);
				list_0.Add(electronicEmissionSystemData);
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
		stringBuilder_0.AppendLine("<ElectronicEmissionsPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<emittingEntityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</emittingEntityID>");
			stringBuilder_0.AppendLine("<eventID>");
			eventID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</eventID>");
			stringBuilder_0.AppendLine("<stateUpdateIndicator type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</stateUpdateIndicator>");
			stringBuilder_0.AppendLine("<systems type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</systems>");
			stringBuilder_0.AppendLine("<paddingForEmissionsPdu type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</paddingForEmissionsPdu>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<systems" + i.ToString(CultureInfo.InvariantCulture) + " type=\"ElectronicEmissionSystemData\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</systems" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</ElectronicEmissionsPdu>");
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
		return this == obj as ElectronicEmissionsPdu;
	}

	public bool Equals(ElectronicEmissionsPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((DistributedEmissionsFamilyPdu)other);
			if (!entityID_0.Equals(other.entityID_0))
			{
				flag = false;
			}
			if (!eventID_0.Equals(other.eventID_0))
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
		num = smethod_2(num) ^ eventID_0.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ ushort_1.GetHashCode();
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
