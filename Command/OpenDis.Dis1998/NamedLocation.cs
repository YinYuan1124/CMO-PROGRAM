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
public class NamedLocation
{
	private ushort ushort_0;

	private ushort ushort_1;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(ushort), ElementName = "stationName")]
	public ushort StationName
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

	[XmlElement(Type = typeof(ushort), ElementName = "stationNumber")]
	public ushort StationNumber
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

	public static bool operator !=(NamedLocation namedLocation_0, NamedLocation namedLocation_1)
	{
		return !(namedLocation_0 == namedLocation_1);
	}

	public static bool operator ==(NamedLocation namedLocation_0, NamedLocation namedLocation_1)
	{
		if ((object)namedLocation_0 == namedLocation_1)
		{
			return true;
		}
		if ((object)namedLocation_0 != null && (object)namedLocation_1 != null)
		{
			return namedLocation_0.Equals(namedLocation_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 4;
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
			dataOutputStream_0.WriteUnsignedShort(ushort_0);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
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
			ushort_0 = dataInputStream_0.ReadUnsignedShort();
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
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
		stringBuilder_0.AppendLine("<NamedLocation>");
		try
		{
			stringBuilder_0.AppendLine("<stationName type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</stationName>");
			stringBuilder_0.AppendLine("<stationNumber type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</stationNumber>");
			stringBuilder_0.AppendLine("</NamedLocation>");
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
		return this == obj as NamedLocation;
	}

	public bool Equals(NamedLocation namedLocation_0)
	{
		bool result = true;
		if (namedLocation_0.GetType() == GetType())
		{
			if (ushort_0 != namedLocation_0.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != namedLocation_0.ushort_1)
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
		return smethod_0(smethod_0(0) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode();
	}
}
