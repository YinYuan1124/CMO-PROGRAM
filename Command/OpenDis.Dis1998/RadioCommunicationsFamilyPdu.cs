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
public class RadioCommunicationsFamilyPdu : Pdu, IEquatable<RadioCommunicationsFamilyPdu>
{
	private EntityID entityID_0 = new EntityID();

	private ushort ushort_1;

	[XmlElement(Type = typeof(EntityID), ElementName = "entityId")]
	public EntityID EntityId
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

	[XmlElement(Type = typeof(ushort), ElementName = "radioId")]
	public ushort RadioId
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

	public RadioCommunicationsFamilyPdu()
	{
		base.ProtocolFamily = 4;
	}

	public static bool operator !=(RadioCommunicationsFamilyPdu radioCommunicationsFamilyPdu_0, RadioCommunicationsFamilyPdu radioCommunicationsFamilyPdu_1)
	{
		return !(radioCommunicationsFamilyPdu_0 == radioCommunicationsFamilyPdu_1);
	}

	public static bool operator ==(RadioCommunicationsFamilyPdu radioCommunicationsFamilyPdu_0, RadioCommunicationsFamilyPdu radioCommunicationsFamilyPdu_1)
	{
		if ((object)radioCommunicationsFamilyPdu_0 == radioCommunicationsFamilyPdu_1)
		{
			return true;
		}
		if ((object)radioCommunicationsFamilyPdu_0 != null && (object)radioCommunicationsFamilyPdu_1 != null)
		{
			return radioCommunicationsFamilyPdu_0.Equals(radioCommunicationsFamilyPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + 2;
	}

	public new virtual void MarshalAutoLengthSet(DataOutputStream dataOutputStream_0)
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
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
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
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
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
		stringBuilder_0.AppendLine("<RadioCommunicationsFamilyPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<entityId>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityId>");
			stringBuilder_0.AppendLine("<radioId type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</radioId>");
			stringBuilder_0.AppendLine("</RadioCommunicationsFamilyPdu>");
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
		return this == obj as RadioCommunicationsFamilyPdu;
	}

	public bool Equals(RadioCommunicationsFamilyPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((Pdu)other);
			if (!entityID_0.Equals(other.entityID_0))
			{
				flag = false;
			}
			if (ushort_1 != other.ushort_1)
			{
				flag = false;
			}
			return flag;
		}
		return false;
	}

	private static int smethod_1(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_1(smethod_1(smethod_1(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ ushort_1.GetHashCode();
	}
}
