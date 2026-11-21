#define TRACE
using System;
using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlRoot]
public class DistributedEmissionsFamilyPdu : Pdu, IEquatable<DistributedEmissionsFamilyPdu>
{
	public DistributedEmissionsFamilyPdu()
	{
		base.ProtocolFamily = 6;
	}

	public static bool operator !=(DistributedEmissionsFamilyPdu distributedEmissionsFamilyPdu_0, DistributedEmissionsFamilyPdu distributedEmissionsFamilyPdu_1)
	{
		return !(distributedEmissionsFamilyPdu_0 == distributedEmissionsFamilyPdu_1);
	}

	public static bool operator ==(DistributedEmissionsFamilyPdu distributedEmissionsFamilyPdu_0, DistributedEmissionsFamilyPdu distributedEmissionsFamilyPdu_1)
	{
		if ((object)distributedEmissionsFamilyPdu_0 == distributedEmissionsFamilyPdu_1)
		{
			return true;
		}
		if ((object)distributedEmissionsFamilyPdu_0 != null && (object)distributedEmissionsFamilyPdu_1 != null)
		{
			return distributedEmissionsFamilyPdu_0.Equals(distributedEmissionsFamilyPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize();
	}

	public new virtual void MarshalAutoLengthSet(DataOutputStream dataOutputStream_0)
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
		stringBuilder_0.AppendLine("<DistributedEmissionsFamilyPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("</DistributedEmissionsFamilyPdu>");
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
		return this == obj as DistributedEmissionsFamilyPdu;
	}

	public bool Equals(DistributedEmissionsFamilyPdu other)
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
