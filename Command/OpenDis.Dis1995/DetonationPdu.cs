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
[XmlInclude(typeof(EventID))]
[XmlRoot]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(BurstDescriptor))]
[XmlInclude(typeof(ArticulationParameter))]
[XmlInclude(typeof(Vector3Double))]
public class DetonationPdu : Warfare, IEquatable<DetonationPdu>
{
	private EntityID entityID_2 = new EntityID();

	private EventID eventID_0 = new EventID();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private Vector3Double vector3Double_0 = new Vector3Double();

	private BurstDescriptor burstDescriptor_0 = new BurstDescriptor();

	private byte byte_4;

	private byte byte_5;

	private short short_1;

	private List<ArticulationParameter> list_0 = new List<ArticulationParameter>();

	[XmlElement(Type = typeof(EntityID), ElementName = "munitionID")]
	public EntityID MunitionID
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "velocity")]
	public Vector3Float Velocity
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "locationInWorldCoordinates")]
	public Vector3Double LocationInWorldCoordinates
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

	[XmlElement(Type = typeof(BurstDescriptor), ElementName = "burstDescriptor")]
	public BurstDescriptor BurstDescriptor
	{
		get
		{
			return burstDescriptor_0;
		}
		set
		{
			burstDescriptor_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "detonationResult")]
	public byte DetonationResult
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfArticulationParameters")]
	public byte NumberOfArticulationParameters
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

	[XmlElement(Type = typeof(short), ElementName = "pad")]
	public short Pad
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

	[XmlElement(ElementName = "articulationParametersList", Type = typeof(List<ArticulationParameter>))]
	public List<ArticulationParameter> ArticulationParameters => list_0;

	public DetonationPdu()
	{
		base.PduType = 3;
	}

	public static bool operator !=(DetonationPdu detonationPdu_0, DetonationPdu detonationPdu_1)
	{
		return !(detonationPdu_0 == detonationPdu_1);
	}

	public static bool operator ==(DetonationPdu detonationPdu_0, DetonationPdu detonationPdu_1)
	{
		if ((object)detonationPdu_0 == detonationPdu_1)
		{
			return true;
		}
		if ((object)detonationPdu_0 != null && (object)detonationPdu_1 != null)
		{
			return detonationPdu_0.Equals(detonationPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_2.GetMarshalledSize();
		num += eventID_0.GetMarshalledSize();
		num += vector3Float_0.GetMarshalledSize();
		num += vector3Double_0.GetMarshalledSize();
		num += burstDescriptor_0.GetMarshalledSize();
		num++;
		num++;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			ArticulationParameter articulationParameter = list_0[i];
			num += articulationParameter.GetMarshalledSize();
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
			eventID_0.Marshal(dataOutputStream_0);
			vector3Float_0.Marshal(dataOutputStream_0);
			vector3Double_0.Marshal(dataOutputStream_0);
			burstDescriptor_0.Marshal(dataOutputStream_0);
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
			entityID_2.Unmarshal(dataInputStream_0);
			eventID_0.Unmarshal(dataInputStream_0);
			vector3Float_0.Unmarshal(dataInputStream_0);
			vector3Double_0.Unmarshal(dataInputStream_0);
			burstDescriptor_0.Unmarshal(dataInputStream_0);
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			short_1 = dataInputStream_0.ReadShort();
			for (int i = 0; i < NumberOfArticulationParameters; i++)
			{
				ArticulationParameter articulationParameter = new ArticulationParameter();
				articulationParameter.Unmarshal(dataInputStream_0);
				list_0.Add(articulationParameter);
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
		stringBuilder_0.AppendLine("<DetonationPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<munitionID>");
			entityID_2.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</munitionID>");
			stringBuilder_0.AppendLine("<eventID>");
			eventID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</eventID>");
			stringBuilder_0.AppendLine("<velocity>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</velocity>");
			stringBuilder_0.AppendLine("<locationInWorldCoordinates>");
			vector3Double_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</locationInWorldCoordinates>");
			stringBuilder_0.AppendLine("<burstDescriptor>");
			burstDescriptor_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</burstDescriptor>");
			stringBuilder_0.AppendLine("<detonationResult type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</detonationResult>");
			stringBuilder_0.AppendLine("<articulationParameters type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</articulationParameters>");
			stringBuilder_0.AppendLine("<pad type=\"short\">" + short_1.ToString(CultureInfo.InvariantCulture) + "</pad>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<articulationParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"ArticulationParameter\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</articulationParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</DetonationPdu>");
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
		return this == obj as DetonationPdu;
	}

	public bool Equals(DetonationPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((Warfare)other);
			if (!entityID_2.Equals(other.entityID_2))
			{
				flag = false;
			}
			if (!eventID_0.Equals(other.eventID_0))
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
			if (!burstDescriptor_0.Equals(other.burstDescriptor_0))
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
		num = smethod_2(num) ^ entityID_2.GetHashCode();
		num = smethod_2(num) ^ eventID_0.GetHashCode();
		num = smethod_2(num) ^ vector3Float_0.GetHashCode();
		num = smethod_2(num) ^ vector3Double_0.GetHashCode();
		num = smethod_2(num) ^ burstDescriptor_0.GetHashCode();
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
