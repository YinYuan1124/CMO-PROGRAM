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
[XmlInclude(typeof(ClockTime))]
public class StopFreezeReliablePdu : SimulationManagementWithReliabilityFamilyPdu, IEquatable<StopFreezeReliablePdu>
{
	private ClockTime clockTime_0 = new ClockTime();

	private byte byte_4;

	private byte byte_5;

	private byte byte_6;

	private byte byte_7;

	private uint uint_1;

	[XmlElement(Type = typeof(ClockTime), ElementName = "realWorldTime")]
	public ClockTime RealWorldTime
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

	[XmlElement(Type = typeof(byte), ElementName = "reason")]
	public byte Reason
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

	[XmlElement(Type = typeof(byte), ElementName = "frozenBehavior")]
	public byte FrozenBehavior
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

	[XmlElement(Type = typeof(byte), ElementName = "requiredReliablityService")]
	public byte RequiredReliablityService
	{
		get
		{
			return byte_6;
		}
		set
		{
			byte_6 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "pad1")]
	public byte Pad1
	{
		get
		{
			return byte_7;
		}
		set
		{
			byte_7 = value;
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

	public StopFreezeReliablePdu()
	{
		base.PduType = 54;
	}

	public static bool operator !=(StopFreezeReliablePdu stopFreezeReliablePdu_0, StopFreezeReliablePdu stopFreezeReliablePdu_1)
	{
		return !(stopFreezeReliablePdu_0 == stopFreezeReliablePdu_1);
	}

	public static bool operator ==(StopFreezeReliablePdu stopFreezeReliablePdu_0, StopFreezeReliablePdu stopFreezeReliablePdu_1)
	{
		if ((object)stopFreezeReliablePdu_0 == stopFreezeReliablePdu_1)
		{
			return true;
		}
		if ((object)stopFreezeReliablePdu_0 != null && (object)stopFreezeReliablePdu_1 != null)
		{
			return stopFreezeReliablePdu_0.Equals(stopFreezeReliablePdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + clockTime_0.GetMarshalledSize() + 1 + 1 + 1 + 1 + 4;
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
			clockTime_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedByte(byte_4);
			dataOutputStream_0.WriteUnsignedByte(byte_5);
			dataOutputStream_0.WriteUnsignedByte(byte_6);
			dataOutputStream_0.WriteUnsignedByte(byte_7);
			dataOutputStream_0.WriteUnsignedInt(uint_1);
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
			clockTime_0.Unmarshal(dataInputStream_0);
			byte_4 = dataInputStream_0.ReadUnsignedByte();
			byte_5 = dataInputStream_0.ReadUnsignedByte();
			byte_6 = dataInputStream_0.ReadUnsignedByte();
			byte_7 = dataInputStream_0.ReadUnsignedByte();
			uint_1 = dataInputStream_0.ReadUnsignedInt();
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
		stringBuilder_0.AppendLine("<StopFreezeReliablePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<realWorldTime>");
			clockTime_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</realWorldTime>");
			stringBuilder_0.AppendLine("<reason type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</reason>");
			stringBuilder_0.AppendLine("<frozenBehavior type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</frozenBehavior>");
			stringBuilder_0.AppendLine("<requiredReliablityService type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</requiredReliablityService>");
			stringBuilder_0.AppendLine("<pad1 type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</pad1>");
			stringBuilder_0.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			stringBuilder_0.AppendLine("</StopFreezeReliablePdu>");
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
		return this == obj as StopFreezeReliablePdu;
	}

	public bool Equals(StopFreezeReliablePdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((SimulationManagementWithReliabilityFamilyPdu)other);
			if (!clockTime_0.Equals(other.clockTime_0))
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
			if (byte_6 != other.byte_6)
			{
				flag = false;
			}
			if (byte_7 != other.byte_7)
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

	private static int smethod_2(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(0) ^ base.GetHashCode()) ^ clockTime_0.GetHashCode()) ^ byte_4.GetHashCode()) ^ byte_5.GetHashCode()) ^ byte_6.GetHashCode()) ^ byte_7.GetHashCode()) ^ uint_1.GetHashCode();
	}
}
