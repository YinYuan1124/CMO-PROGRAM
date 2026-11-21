using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class AcknowledgeReliablePdu : SimulationManagementWithReliabilityFamilyPdu, IEquatable<AcknowledgeReliablePdu>
{
	private ushort ushort_1;

	private ushort ushort_2;

	private uint uint_1;

	[XmlElement(Type = typeof(ushort), ElementName = "acknowledgeFlag")]
	public ushort AcknowledgeFlag
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

	[XmlElement(Type = typeof(ushort), ElementName = "responseFlag")]
	public ushort ResponseFlag
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

	public AcknowledgeReliablePdu()
	{
		base.PduType = 55;
	}

	public static bool operator !=(AcknowledgeReliablePdu acknowledgeReliablePdu_0, AcknowledgeReliablePdu acknowledgeReliablePdu_1)
	{
		return !(acknowledgeReliablePdu_0 == acknowledgeReliablePdu_1);
	}

	public static bool operator ==(AcknowledgeReliablePdu acknowledgeReliablePdu_0, AcknowledgeReliablePdu acknowledgeReliablePdu_1)
	{
		if ((object)acknowledgeReliablePdu_0 == acknowledgeReliablePdu_1)
		{
			return true;
		}
		if ((object)acknowledgeReliablePdu_0 != null && (object)acknowledgeReliablePdu_1 != null)
		{
			return acknowledgeReliablePdu_0.Equals(acknowledgeReliablePdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + 2 + 2 + 4;
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
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
				dataOutputStream_0.WriteUnsignedShort(ushort_2);
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
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
				ushort_2 = dataInputStream_0.ReadUnsignedShort();
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
		stringBuilder_0.AppendLine("<AcknowledgeReliablePdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<acknowledgeFlag type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</acknowledgeFlag>");
			stringBuilder_0.AppendLine("<responseFlag type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</responseFlag>");
			stringBuilder_0.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			stringBuilder_0.AppendLine("</AcknowledgeReliablePdu>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as AcknowledgeReliablePdu;
	}

	public bool Equals(AcknowledgeReliablePdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((SimulationManagementWithReliabilityFamilyPdu)other);
			if (ushort_1 != other.ushort_1)
			{
				flag = false;
			}
			if (ushort_2 != other.ushort_2)
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
		return smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ ushort_1.GetHashCode()) ^ ushort_2.GetHashCode()) ^ uint_1.GetHashCode();
	}
}
