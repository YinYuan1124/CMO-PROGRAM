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
[XmlRoot]
[XmlInclude(typeof(EntityType))]
public class BurstDescriptor
{
	private EntityType entityType_0 = new EntityType();

	private ushort ushort_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(EntityType), ElementName = "munition")]
	public EntityType Munition
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

	[XmlElement(Type = typeof(ushort), ElementName = "warhead")]
	public ushort Warhead
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "fuse")]
	public ushort Fuse
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

	[XmlElement(Type = typeof(ushort), ElementName = "quantity")]
	public ushort Quantity
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

	[XmlElement(Type = typeof(ushort), ElementName = "rate")]
	public ushort Rate
	{
		get
		{
			return ushort_3;
		}
		set
		{
			ushort_3 = value;
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

	public static bool operator !=(BurstDescriptor burstDescriptor_0, BurstDescriptor burstDescriptor_1)
	{
		return !(burstDescriptor_0 == burstDescriptor_1);
	}

	public static bool operator ==(BurstDescriptor burstDescriptor_0, BurstDescriptor burstDescriptor_1)
	{
		if ((object)burstDescriptor_0 == burstDescriptor_1)
		{
			return true;
		}
		if ((object)burstDescriptor_0 != null && (object)burstDescriptor_1 != null)
		{
			return burstDescriptor_0.Equals(burstDescriptor_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return entityType_0.GetMarshalledSize() + 2 + 2 + 2 + 2;
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
			dataOutputStream_0.WriteUnsignedShort(ushort_0);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			dataOutputStream_0.WriteUnsignedShort(ushort_2);
			dataOutputStream_0.WriteUnsignedShort(ushort_3);
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
			ushort_0 = dataInputStream_0.ReadUnsignedShort();
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			ushort_2 = dataInputStream_0.ReadUnsignedShort();
			ushort_3 = dataInputStream_0.ReadUnsignedShort();
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
		stringBuilder_0.AppendLine("<BurstDescriptor>");
		try
		{
			stringBuilder_0.AppendLine("<munition>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</munition>");
			stringBuilder_0.AppendLine("<warhead type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</warhead>");
			stringBuilder_0.AppendLine("<fuse type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</fuse>");
			stringBuilder_0.AppendLine("<quantity type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</quantity>");
			stringBuilder_0.AppendLine("<rate type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</rate>");
			stringBuilder_0.AppendLine("</BurstDescriptor>");
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
		return this == obj as BurstDescriptor;
	}

	public bool Equals(BurstDescriptor burstDescriptor_0)
	{
		bool result = true;
		if (burstDescriptor_0.GetType() == GetType())
		{
			if (!entityType_0.Equals(burstDescriptor_0.entityType_0))
			{
				result = false;
			}
			if (ushort_0 != burstDescriptor_0.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != burstDescriptor_0.ushort_1)
			{
				result = false;
			}
			if (ushort_2 != burstDescriptor_0.ushort_2)
			{
				result = false;
			}
			if (ushort_3 != burstDescriptor_0.ushort_3)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ entityType_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ ushort_2.GetHashCode()) ^ ushort_3.GetHashCode();
	}
}
