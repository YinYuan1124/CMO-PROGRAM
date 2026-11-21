#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class ReceiverPdu : RadioCommunicationsFamilyPdu, IEquatable<ReceiverPdu>
{
	private ushort ushort_2;

	private ushort ushort_3;

	private float float_0;

	private EntityID entityID_1 = new EntityID();

	private ushort ushort_4;

	[XmlElement(Type = typeof(ushort), ElementName = "receiverState")]
	public ushort ReceiverState
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

	[XmlElement(Type = typeof(float), ElementName = "receivedPoser")]
	public float ReceivedPoser
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

	[XmlElement(Type = typeof(EntityID), ElementName = "transmitterEntityId")]
	public EntityID TransmitterEntityId
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

	[XmlElement(Type = typeof(ushort), ElementName = "transmitterRadioId")]
	public ushort TransmitterRadioId
	{
		get
		{
			return ushort_4;
		}
		set
		{
			ushort_4 = value;
		}
	}

	public ReceiverPdu()
	{
		base.PduType = 27;
	}

	public static bool operator !=(ReceiverPdu receiverPdu_0, ReceiverPdu receiverPdu_1)
	{
		return !(receiverPdu_0 == receiverPdu_1);
	}

	public static bool operator ==(ReceiverPdu receiverPdu_0, ReceiverPdu receiverPdu_1)
	{
		if ((object)receiverPdu_0 == receiverPdu_1)
		{
			return true;
		}
		if ((object)receiverPdu_0 != null && (object)receiverPdu_1 != null)
		{
			return receiverPdu_0.Equals(receiverPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + 2 + 2 + 4 + entityID_1.GetMarshalledSize() + 2;
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
			dataOutputStream_0.WriteUnsignedShort(ushort_2);
			dataOutputStream_0.WriteUnsignedShort(ushort_3);
			dataOutputStream_0.WriteFloat(float_0);
			entityID_1.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedShort(ushort_4);
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
			ushort_2 = dataInputStream_0.ReadUnsignedShort();
			ushort_3 = dataInputStream_0.ReadUnsignedShort();
			float_0 = dataInputStream_0.ReadFloat();
			entityID_1.Unmarshal(dataInputStream_0);
			ushort_4 = dataInputStream_0.ReadUnsignedShort();
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
		stringBuilder_0.AppendLine("<ReceiverPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<receiverState type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</receiverState>");
			stringBuilder_0.AppendLine("<padding1 type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			stringBuilder_0.AppendLine("<receivedPoser type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</receivedPoser>");
			stringBuilder_0.AppendLine("<transmitterEntityId>");
			entityID_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</transmitterEntityId>");
			stringBuilder_0.AppendLine("<transmitterRadioId type=\"ushort\">" + ushort_4.ToString(CultureInfo.InvariantCulture) + "</transmitterRadioId>");
			stringBuilder_0.AppendLine("</ReceiverPdu>");
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
		return this == obj as ReceiverPdu;
	}

	public bool Equals(ReceiverPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((RadioCommunicationsFamilyPdu)other);
			if (ushort_2 != other.ushort_2)
			{
				flag = false;
			}
			if (ushort_3 != other.ushort_3)
			{
				flag = false;
			}
			if (float_0 != other.float_0)
			{
				flag = false;
			}
			if (!entityID_1.Equals(other.entityID_1))
			{
				flag = false;
			}
			if (ushort_4 != other.ushort_4)
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
		return smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(0) ^ base.GetHashCode()) ^ ushort_2.GetHashCode()) ^ ushort_3.GetHashCode()) ^ float_0.GetHashCode()) ^ entityID_1.GetHashCode()) ^ ushort_4.GetHashCode();
	}
}
