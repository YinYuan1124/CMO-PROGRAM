#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlInclude(typeof(EntityType))]
[XmlRoot]
public class SupplyQuantity
{
	private EntityType entityType_0 = new EntityType();

	private byte byte_0;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(EntityType), ElementName = "supplyType")]
	public EntityType SupplyType
	{
		get
		{
			return entityType_0;
		}
		set
		{
			entityType_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "quantity")]
	public byte Quantity
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public event EventHandler<PduExceptionEventArgs> ExceptionOccured
	{
		[CompilerGenerated]
		add
		{
			EventHandler<PduExceptionEventArgs> eventHandler = eventHandler_0;
			EventHandler<PduExceptionEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PduExceptionEventArgs> value2 = (EventHandler<PduExceptionEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<PduExceptionEventArgs> eventHandler = eventHandler_0;
			EventHandler<PduExceptionEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PduExceptionEventArgs> value2 = (EventHandler<PduExceptionEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public static bool operator !=(SupplyQuantity supplyQuantity_0, SupplyQuantity supplyQuantity_1)
	{
		return !(supplyQuantity_0 == supplyQuantity_1);
	}

	public static bool operator ==(SupplyQuantity supplyQuantity_0, SupplyQuantity supplyQuantity_1)
	{
		if ((object)supplyQuantity_0 == supplyQuantity_1)
		{
			return true;
		}
		if ((object)supplyQuantity_0 != null && (object)supplyQuantity_1 != null)
		{
			return supplyQuantity_0.Equals(supplyQuantity_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return entityType_0.GetMarshalledSize() + 1;
	}

	protected void RaiseExceptionOccured(Exception exception_0)
	{
		if (PduBase.FireExceptionEvents && eventHandler_0 != null)
		{
			eventHandler_0(this, new PduExceptionEventArgs(exception_0));
		}
	}

	public virtual void Marshal(DataOutputStream dataOutputStream_0)
	{
		if (dataOutputStream_0 == null)
		{
			return;
		}
		try
		{
			entityType_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedByte(byte_0);
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

	public virtual void Unmarshal(DataInputStream dataInputStream_0)
	{
		if (dataInputStream_0 == null)
		{
			return;
		}
		try
		{
			entityType_0.Unmarshal(dataInputStream_0);
			byte_0 = dataInputStream_0.ReadUnsignedByte();
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

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<SupplyQuantity>");
		try
		{
			stringBuilder_0.AppendLine("<supplyType>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</supplyType>");
			stringBuilder_0.AppendLine("<quantity type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</quantity>");
			stringBuilder_0.AppendLine("</SupplyQuantity>");
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
		return this == obj as SupplyQuantity;
	}

	public bool Equals(SupplyQuantity supplyQuantity_0)
	{
		bool result = true;
		if (supplyQuantity_0.GetType() == GetType())
		{
			if (!entityType_0.Equals(supplyQuantity_0.entityType_0))
			{
				result = false;
			}
			if (byte_0 != supplyQuantity_0.byte_0)
			{
				result = false;
			}
			return result;
		}
		return false;
	}

	private static int smethod_0(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_0(smethod_0(0) ^ entityType_0.GetHashCode()) ^ byte_0.GetHashCode();
	}
}
