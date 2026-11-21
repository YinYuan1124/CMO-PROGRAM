#define TRACE
using System;
using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlRoot]
public class EntityInformationPdu : Pdu, IEquatable<EntityInformationPdu>
{
	public EntityInformationPdu()
	{
		base.ProtocolFamily = 1;
	}

	public static bool operator !=(EntityInformationPdu entityInformationPdu_0, EntityInformationPdu entityInformationPdu_1)
	{
		return !(entityInformationPdu_0 == entityInformationPdu_1);
	}

	public static bool operator ==(EntityInformationPdu entityInformationPdu_0, EntityInformationPdu entityInformationPdu_1)
	{
		if ((object)entityInformationPdu_0 == entityInformationPdu_1)
		{
			return true;
		}
		if ((object)entityInformationPdu_0 != null && (object)entityInformationPdu_1 != null)
		{
			return entityInformationPdu_0.Equals(entityInformationPdu_1);
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
		stringBuilder_0.AppendLine("<EntityInformationPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("</EntityInformationPdu>");
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
		return this == obj as EntityInformationPdu;
	}

	public bool Equals(EntityInformationPdu other)
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
