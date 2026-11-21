#define TRACE
using System;
using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class Warfare : Pdu, IEquatable<Warfare>
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

	public Warfare()
	{
		base.ProtocolFamily = 2;
	}

	public static bool operator !=(Warfare warfare_0, Warfare warfare_1)
	{
		return !(warfare_0 == warfare_1);
	}

	public static bool operator ==(Warfare warfare_0, Warfare warfare_1)
	{
		if ((object)warfare_0 == warfare_1)
		{
			return true;
		}
		if ((object)warfare_0 != null && (object)warfare_1 != null)
		{
			return warfare_0.Equals(warfare_1);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + entityID_1.GetMarshalledSize();
	}

	public virtual void MarshalAutoLengthSet(DataOutputStream dataOutputStream_0)
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
		stringBuilder_0.AppendLine("<Warfare>");
		base.Reflection(stringBuilder_0);
		try
		{
			stringBuilder_0.AppendLine("<firingEntityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</firingEntityID>");
			stringBuilder_0.AppendLine("<targetEntityID>");
			entityID_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</targetEntityID>");
			stringBuilder_0.AppendLine("</Warfare>");
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
		return this == obj as Warfare;
	}

	public bool Equals(Warfare other)
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
