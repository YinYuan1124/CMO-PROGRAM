#define TRACE
using System;
using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlRoot]
public class LogisticsPdu : Pdu, IEquatable<LogisticsPdu>
{
	public LogisticsPdu()
	{
		base.ProtocolFamily = 3;
	}

	public static bool operator !=(LogisticsPdu logisticsPdu_0, LogisticsPdu logisticsPdu_1)
	{
		return !(logisticsPdu_0 == logisticsPdu_1);
	}

	public static bool operator ==(LogisticsPdu logisticsPdu_0, LogisticsPdu logisticsPdu_1)
	{
		if ((object)logisticsPdu_0 == logisticsPdu_1)
		{
			return true;
		}
		if ((object)logisticsPdu_0 != null && (object)logisticsPdu_1 != null)
		{
			return logisticsPdu_0.Equals(logisticsPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize();
	}

	public virtual void MarshalAutoLengthSet(DataOutputStream dataOutputStream_0)
	{
		base.Length = (ushort)GetMarshalledSize();
		Marshal(dataOutputStream_0);
	}

	public override void Marshal(DataOutputStream dataOutputStream_0)
	{
		base.Marshal(dataOutputStream_0);
	}

	public override void Unmarshal(DataInputStream dataInputStream_0)
	{
		base.Unmarshal(dataInputStream_0);
	}

	public override void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<LogisticsPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("</LogisticsPdu>");
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
		return this == obj as LogisticsPdu;
	}

	public bool Equals(LogisticsPdu other)
	{
		if (other.GetType() == GetType())
		{
			return Equals((Pdu)other);
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
		return smethod_1(0) ^ base.GetHashCode();
	}
}
