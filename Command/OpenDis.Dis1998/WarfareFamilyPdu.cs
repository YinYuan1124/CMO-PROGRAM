#define TRACE
using System;
using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class WarfareFamilyPdu : Pdu, IEquatable<WarfareFamilyPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	[XmlElement(Type = typeof(EntityID), ElementName = "firingEntityID")]
	public EntityID FiringEntityID
	{
		get
		{
			return entityID_0;
		}
		set
		{
			entityID_0 = value;
		}
	}

	[XmlElement(Type = typeof(EntityID), ElementName = "targetEntityID")]
	public EntityID TargetEntityID
	{
		get
		{
			return entityID_1;
		}
		set
		{
			entityID_1 = value;
		}
	}

	public WarfareFamilyPdu()
	{
		base.ProtocolFamily = 2;
	}

	public static bool operator !=(WarfareFamilyPdu warfareFamilyPdu_0, WarfareFamilyPdu warfareFamilyPdu_1)
	{
		return !(warfareFamilyPdu_0 == warfareFamilyPdu_1);
	}

	public static bool operator ==(WarfareFamilyPdu warfareFamilyPdu_0, WarfareFamilyPdu warfareFamilyPdu_1)
	{
		if ((object)warfareFamilyPdu_0 == warfareFamilyPdu_1)
		{
			return true;
		}
		if ((object)warfareFamilyPdu_0 != null && (object)warfareFamilyPdu_1 != null)
		{
			return warfareFamilyPdu_0.Equals(warfareFamilyPdu_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + entityID_1.GetMarshalledSize();
	}

	public new virtual void MarshalAutoLengthSet(DataOutputStream dataOutputStream_0)
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
			entityID_0.Marshal(dataOutputStream_0);
			entityID_1.Marshal(dataOutputStream_0);
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
			entityID_0.Unmarshal(dataInputStream_0);
			entityID_1.Unmarshal(dataInputStream_0);
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
		stringBuilder_0.AppendLine("<WarfareFamilyPdu>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<firingEntityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</firingEntityID>");
			stringBuilder_0.AppendLine("<targetEntityID>");
			entityID_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</targetEntityID>");
			stringBuilder_0.AppendLine("</WarfareFamilyPdu>");
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
		return this == obj as WarfareFamilyPdu;
	}

	public bool Equals(WarfareFamilyPdu other)
	{
		bool flag = true;
		if (other.GetType() == GetType())
		{
			flag = Equals((Pdu)other);
			if (!entityID_0.Equals(other.entityID_0))
			{
				flag = false;
			}
			if (!entityID_1.Equals(other.entityID_1))
			{
				flag = false;
			}
			return flag;
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
		return smethod_1(smethod_1(smethod_1(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ entityID_1.GetHashCode();
	}
}
