using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(ClockTime))]
[XmlInclude(typeof(EntityID))]
public class StartResumePdu : SimulationManagementFamilyPdu, IEquatable<StartResumePdu>
{
	private EntityID entityID_2 = new EntityID();

	private EntityID entityID_3 = new EntityID();

	private ClockTime PWQEIVPWMRS = new ClockTime();

	private ClockTime clockTime_0 = new ClockTime();

	private uint uint_1;

	[XmlElement(Type = typeof(EntityID), ElementName = "originatingID")]
	public EntityID OriginatingID
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

	[XmlElement(Type = typeof(EntityID), ElementName = "receivingID")]
	public EntityID ReceivingID
	{
		get
		{
			return entityID_3;
		}
		set
		{
			entityID_3 = value;
		}
	}

	[XmlElement(Type = typeof(ClockTime), ElementName = "realWorldTime")]
	public ClockTime RealWorldTime
	{
		get
		{
			return PWQEIVPWMRS;
		}
		set
		{
			PWQEIVPWMRS = value;
		}
	}

	[XmlElement(Type = typeof(ClockTime), ElementName = "simulationTime")]
	public ClockTime SimulationTime
	{
		get
		{
			return clockTime_0;
		}
		set
		{
			clockTime_0 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "requestID")]
	public uint RequestID
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

	public StartResumePdu()
	{
		base.PduType = 13;
	}

	public static bool operator !=(StartResumePdu startResumePdu_0, StartResumePdu startResumePdu_1)
	{
		return !(startResumePdu_0 == startResumePdu_1);
	}

	public static bool operator ==(StartResumePdu startResumePdu_0, StartResumePdu startResumePdu_1)
	{
		if ((object)startResumePdu_0 == startResumePdu_1)
		{
			return true;
		}
		if ((object)startResumePdu_0 != null && (object)startResumePdu_1 != null)
		{
			return startResumePdu_0.Equals(startResumePdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_2.GetMarshalledSize() + entityID_3.GetMarshalledSize() + PWQEIVPWMRS.GetMarshalledSize() + clockTime_0.GetMarshalledSize() + 4;
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
				entityID_2.Marshal(dataOutputStream_0);
				entityID_3.Marshal(dataOutputStream_0);
				PWQEIVPWMRS.Marshal(dataOutputStream_0);
				clockTime_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedInt(uint_1);
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
				entityID_2.Unmarshal(dataInputStream_0);
				entityID_3.Unmarshal(dataInputStream_0);
				PWQEIVPWMRS.Unmarshal(dataInputStream_0);
				clockTime_0.Unmarshal(dataInputStream_0);
				uint_1 = dataInputStream_0.ReadUnsignedInt();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<StartResumePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<originatingID>");
			entityID_2.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</originatingID>");
			stringBuilder_0.AppendLine("<receivingID>");
			entityID_3.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</receivingID>");
			stringBuilder_0.AppendLine("<realWorldTime>");
			PWQEIVPWMRS.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</realWorldTime>");
			stringBuilder_0.AppendLine("<simulationTime>");
			clockTime_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</simulationTime>");
			stringBuilder_0.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			stringBuilder_0.AppendLine("</StartResumePdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as StartResumePdu;
	}

	public bool Equals(StartResumePdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((SimulationManagementFamilyPdu)other);
			if (!entityID_2.Equals(other.entityID_2))
			{
				flag = false;
			}
			if (!entityID_3.Equals(other.entityID_3))
			{
				flag = false;
			}
			if (!PWQEIVPWMRS.Equals(other.PWQEIVPWMRS))
			{
				flag = false;
			}
			if (!clockTime_0.Equals(other.clockTime_0))
			{
				flag = false;
			}
			if (uint_1 != other.uint_1)
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
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ entityID_2.GetHashCode()) ^ entityID_3.GetHashCode()) ^ PWQEIVPWMRS.GetHashCode()) ^ clockTime_0.GetHashCode()) ^ uint_1.GetHashCode();
	}
}
