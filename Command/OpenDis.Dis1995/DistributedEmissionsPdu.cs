#define TRACE
using System;
using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlRoot]
public class DistributedEmissionsPdu : Pdu, IEquatable<DistributedEmissionsPdu>
{
	public DistributedEmissionsPdu()
	{
		base.ProtocolFamily = 6;
	}

	public static bool operator !=(DistributedEmissionsPdu distributedEmissionsPdu_0, DistributedEmissionsPdu distributedEmissionsPdu_1)
	{
		return !(distributedEmissionsPdu_0 == distributedEmissionsPdu_1);
	}

	public static bool operator ==(DistributedEmissionsPdu distributedEmissionsPdu_0, DistributedEmissionsPdu distributedEmissionsPdu_1)
	{
		if ((object)distributedEmissionsPdu_0 == distributedEmissionsPdu_1)
		{
			return true;
		}
		if ((object)distributedEmissionsPdu_0 != null && (object)distributedEmissionsPdu_1 != null)
		{
			return distributedEmissionsPdu_0.Equals(distributedEmissionsPdu_1);
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
		stringBuilder_0.AppendLine("<DistributedEmissionsPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("</DistributedEmissionsPdu>");
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
		return this == obj as DistributedEmissionsPdu;
	}

	public bool Equals(DistributedEmissionsPdu other)
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
