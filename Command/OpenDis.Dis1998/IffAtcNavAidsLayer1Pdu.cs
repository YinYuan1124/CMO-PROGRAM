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
[XmlInclude(typeof(EventID))]
[XmlInclude(typeof(IffFundamentalData))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(SystemID))]
public class IffAtcNavAidsLayer1Pdu : DistributedEmissionsFamilyPdu, IEquatable<IffAtcNavAidsLayer1Pdu>
{
	private EntityID entityID_0 = new EntityID();

	private EventID eventID_0 = new EventID();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private SystemID systemID_0 = new SystemID();

	private ushort ushort_1;

	private IffFundamentalData iffFundamentalData_0 = new IffFundamentalData();

	[XmlElement(Type = typeof(EntityID), ElementName = "emittingEntityId")]
	public EntityID EmittingEntityId
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "location")]
	public Vector3Float Location
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

	[XmlElement(Type = typeof(SystemID), ElementName = "systemID")]
	public SystemID SystemID
	{
		get
		{
			return systemID_0;
		}
		set
		{
			systemID_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "pad2")]
	public ushort Pad2
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

	[XmlElement(Type = typeof(IffFundamentalData), ElementName = "fundamentalParameters")]
	public IffFundamentalData FundamentalParameters
	{
		get
		{
			return iffFundamentalData_0;
		}
		set
		{
			iffFundamentalData_0 = value;
		}
	}

	public IffAtcNavAidsLayer1Pdu()
	{
		base.PduType = 28;
	}

	public static bool operator !=(IffAtcNavAidsLayer1Pdu iffAtcNavAidsLayer1Pdu_0, IffAtcNavAidsLayer1Pdu iffAtcNavAidsLayer1Pdu_1)
	{
		return !(iffAtcNavAidsLayer1Pdu_0 == iffAtcNavAidsLayer1Pdu_1);
	}

	public static bool operator ==(IffAtcNavAidsLayer1Pdu iffAtcNavAidsLayer1Pdu_0, IffAtcNavAidsLayer1Pdu iffAtcNavAidsLayer1Pdu_1)
	{
		if ((object)iffAtcNavAidsLayer1Pdu_0 == iffAtcNavAidsLayer1Pdu_1)
		{
			return true;
		}
		if ((object)iffAtcNavAidsLayer1Pdu_0 != null && (object)iffAtcNavAidsLayer1Pdu_1 != null)
		{
			return iffAtcNavAidsLayer1Pdu_0.Equals(iffAtcNavAidsLayer1Pdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + eventID_0.GetMarshalledSize() + vector3Float_0.GetMarshalledSize() + systemID_0.GetMarshalledSize() + 2 + iffFundamentalData_0.GetMarshalledSize();
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
			vector3Float_0.Marshal(dataOutputStream_0);
			systemID_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			iffFundamentalData_0.Marshal(dataOutputStream_0);
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
			vector3Float_0.Unmarshal(dataInputStream_0);
			systemID_0.Unmarshal(dataInputStream_0);
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			iffFundamentalData_0.Unmarshal(dataInputStream_0);
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
		stringBuilder_0.AppendLine("<IffAtcNavAidsLayer1Pdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<emittingEntityId>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</emittingEntityId>");
			stringBuilder_0.AppendLine("<eventID>");
			eventID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</eventID>");
			stringBuilder_0.AppendLine("<location>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</location>");
			stringBuilder_0.AppendLine("<systemID>");
			systemID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</systemID>");
			stringBuilder_0.AppendLine("<pad2 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			stringBuilder_0.AppendLine("<fundamentalParameters>");
			iffFundamentalData_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</fundamentalParameters>");
			stringBuilder_0.AppendLine("</IffAtcNavAidsLayer1Pdu>");
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
		return this == obj as IffAtcNavAidsLayer1Pdu;
	}

	public bool Equals(IffAtcNavAidsLayer1Pdu other)
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
			if (!vector3Float_0.Equals(other.vector3Float_0))
			{
				flag = false;
			}
			if (!systemID_0.Equals(other.systemID_0))
			{
				flag = false;
			}
			if (ushort_1 != other.ushort_1)
			{
				flag = false;
			}
			if (!iffFundamentalData_0.Equals(other.iffFundamentalData_0))
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
		return smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ eventID_0.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ systemID_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ iffFundamentalData_0.GetHashCode();
	}
}
