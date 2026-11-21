using System;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class LogisticsFamilyPdu : Pdu, IEquatable<LogisticsFamilyPdu>
{
	public LogisticsFamilyPdu()
	{
		base.ProtocolFamily = 3;
	}

	public static bool operator !=(LogisticsFamilyPdu logisticsFamilyPdu_0, LogisticsFamilyPdu logisticsFamilyPdu_1)
	{
		return !(logisticsFamilyPdu_0 == logisticsFamilyPdu_1);
	}

	public static bool operator ==(LogisticsFamilyPdu logisticsFamilyPdu_0, LogisticsFamilyPdu logisticsFamilyPdu_1)
	{
		if ((object)logisticsFamilyPdu_0 == logisticsFamilyPdu_1)
		{
			return true;
		}
		if ((object)logisticsFamilyPdu_0 != null && (object)logisticsFamilyPdu_1 != null)
		{
			return logisticsFamilyPdu_0.Equals(logisticsFamilyPdu_1);
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
		stringBuilder_0.AppendLine("<LogisticsFamilyPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("</LogisticsFamilyPdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as LogisticsFamilyPdu;
	}

	public bool Equals(LogisticsFamilyPdu other)
	{
		if (other.GetType() == GetType())
		{
			return Equals((Pdu)other);
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
		return smethod_2(0) ^ base.GetHashCode();
	}
}
