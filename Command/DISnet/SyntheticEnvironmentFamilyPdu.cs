using System;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class SyntheticEnvironmentFamilyPdu : Pdu, IEquatable<SyntheticEnvironmentFamilyPdu>
{
	public SyntheticEnvironmentFamilyPdu()
	{
		base.ProtocolFamily = 9;
	}

	public static bool operator !=(SyntheticEnvironmentFamilyPdu syntheticEnvironmentFamilyPdu_0, SyntheticEnvironmentFamilyPdu syntheticEnvironmentFamilyPdu_1)
	{
		return !(syntheticEnvironmentFamilyPdu_0 == syntheticEnvironmentFamilyPdu_1);
	}

	public static bool operator ==(SyntheticEnvironmentFamilyPdu syntheticEnvironmentFamilyPdu_0, SyntheticEnvironmentFamilyPdu syntheticEnvironmentFamilyPdu_1)
	{
		if ((object)syntheticEnvironmentFamilyPdu_0 == syntheticEnvironmentFamilyPdu_1)
		{
			return true;
		}
		if ((object)syntheticEnvironmentFamilyPdu_0 != null && (object)syntheticEnvironmentFamilyPdu_1 != null)
		{
			return syntheticEnvironmentFamilyPdu_0.Equals(syntheticEnvironmentFamilyPdu_1);
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
		stringBuilder_0.AppendLine("<SyntheticEnvironmentFamilyPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("</SyntheticEnvironmentFamilyPdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as SyntheticEnvironmentFamilyPdu;
	}

	public bool Equals(SyntheticEnvironmentFamilyPdu other)
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
