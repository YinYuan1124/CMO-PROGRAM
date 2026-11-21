#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlRoot]
public class SignalPdu : RadioCommunicationsPdu, IEquatable<SignalPdu>
{
	private ushort ushort_2;

	private ushort ushort_3;

	private uint uint_1;

	private short short_1;

	private short short_2;

	[XmlElement(Type = typeof(ushort), ElementName = "encodingScheme")]
	public ushort EncodingScheme
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

	[XmlElement(Type = typeof(ushort), ElementName = "tdlType")]
	public ushort TdlType
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

	[XmlElement(Type = typeof(uint), ElementName = "sampleRate")]
	public uint SampleRate
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

	[XmlElement(Type = typeof(short), ElementName = "dataLength")]
	public short DataLength
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

	[XmlElement(Type = typeof(short), ElementName = "samples")]
	public short Samples
	{
		get
		{
			return short_2;
		}
		set
		{
			short_2 = value;
		}
	}

	public SignalPdu()
	{
		base.PduType = 26;
	}

	public static bool operator !=(SignalPdu signalPdu_0, SignalPdu signalPdu_1)
	{
		return !(signalPdu_0 == signalPdu_1);
	}

	public static bool operator ==(SignalPdu signalPdu_0, SignalPdu signalPdu_1)
	{
		if ((object)signalPdu_0 == signalPdu_1)
		{
			return true;
		}
		if ((object)signalPdu_0 != null && (object)signalPdu_1 != null)
		{
			return signalPdu_0.Equals(signalPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + 2 + 2 + 4 + 2 + 2;
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
			dataOutputStream_0.WriteUnsignedInt(uint_1);
			dataOutputStream_0.WriteShort(short_1);
			dataOutputStream_0.WriteShort(short_2);
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
			uint_1 = dataInputStream_0.ReadUnsignedInt();
			short_1 = dataInputStream_0.ReadShort();
			short_2 = dataInputStream_0.ReadShort();
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
		stringBuilder_0.AppendLine("<SignalPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<encodingScheme type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</encodingScheme>");
			stringBuilder_0.AppendLine("<tdlType type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</tdlType>");
			stringBuilder_0.AppendLine("<sampleRate type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</sampleRate>");
			stringBuilder_0.AppendLine("<dataLength type=\"short\">" + short_1.ToString(CultureInfo.InvariantCulture) + "</dataLength>");
			stringBuilder_0.AppendLine("<samples type=\"short\">" + short_2.ToString(CultureInfo.InvariantCulture) + "</samples>");
			stringBuilder_0.AppendLine("</SignalPdu>");
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
		return this == obj as SignalPdu;
	}

	public bool Equals(SignalPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((RadioCommunicationsPdu)other);
			if (ushort_2 != other.ushort_2)
			{
				flag = false;
			}
			if (ushort_3 != other.ushort_3)
			{
				flag = false;
			}
			if (uint_1 != other.uint_1)
			{
				flag = false;
			}
			if (short_1 != other.short_1)
			{
				flag = false;
			}
			if (short_2 != other.short_2)
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
		return smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(0) ^ base.GetHashCode()) ^ ushort_2.GetHashCode()) ^ ushort_3.GetHashCode()) ^ uint_1.GetHashCode()) ^ short_1.GetHashCode()) ^ short_2.GetHashCode();
	}
}
