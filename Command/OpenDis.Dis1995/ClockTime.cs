#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlRoot]
public class ClockTime
{
	private int int_0;

	private uint uint_0;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(int), ElementName = "hour")]
	public int Hour
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "timePastHour")]
	public uint TimePastHour
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
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

	public static bool operator !=(ClockTime clockTime_0, ClockTime clockTime_1)
	{
		return !(clockTime_0 == clockTime_1);
	}

	public static bool operator ==(ClockTime clockTime_0, ClockTime clockTime_1)
	{
		if ((object)clockTime_0 == clockTime_1)
		{
			return true;
		}
		if ((object)clockTime_0 != null && (object)clockTime_1 != null)
		{
			return clockTime_0.Equals(clockTime_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 8;
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
			dataOutputStream_0.WriteInt(int_0);
			dataOutputStream_0.WriteUnsignedInt(uint_0);
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
			int_0 = dataInputStream_0.ReadInt();
			uint_0 = dataInputStream_0.ReadUnsignedInt();
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
		stringBuilder_0.AppendLine("<ClockTime>");
		try
		{
			stringBuilder_0.AppendLine("<hour type=\"int\">" + int_0.ToString(CultureInfo.InvariantCulture) + "</hour>");
			stringBuilder_0.AppendLine("<timePastHour type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</timePastHour>");
			stringBuilder_0.AppendLine("</ClockTime>");
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
		return this == obj as ClockTime;
	}

	public bool Equals(ClockTime clockTime_0)
	{
		bool result = true;
		if (clockTime_0.GetType() == GetType())
		{
			if (int_0 != clockTime_0.int_0)
			{
				result = false;
			}
			if (uint_0 != clockTime_0.uint_0)
			{
				result = false;
			}
			return result;
		}
		return false;
	}

	private static int smethod_0(int int_1)
	{
		int_1 <<= 5 + int_1;
		return int_1;
	}

	public override int GetHashCode()
	{
		return smethod_0(smethod_0(0) ^ int_0.GetHashCode()) ^ uint_0.GetHashCode();
	}
}
