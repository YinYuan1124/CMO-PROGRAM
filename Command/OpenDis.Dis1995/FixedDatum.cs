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
public class FixedDatum
{
	private uint LFUESDCCCZL;

	private uint uint_0;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(uint), ElementName = "fixedDatumID")]
	public uint FixedDatumID
	{
		get
		{
			return LFUESDCCCZL;
		}
		set
		{
			LFUESDCCCZL = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "fixedDatumValue")]
	public uint FixedDatumValue
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

	public static bool operator !=(FixedDatum fixedDatum_0, FixedDatum fixedDatum_1)
	{
		return !(fixedDatum_0 == fixedDatum_1);
	}

	public static bool operator ==(FixedDatum fixedDatum_0, FixedDatum fixedDatum_1)
	{
		if ((object)fixedDatum_0 == fixedDatum_1)
		{
			return true;
		}
		if ((object)fixedDatum_0 != null && (object)fixedDatum_1 != null)
		{
			return fixedDatum_0.Equals(fixedDatum_1);
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
			dataOutputStream_0.WriteUnsignedInt(LFUESDCCCZL);
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
			LFUESDCCCZL = dataInputStream_0.ReadUnsignedInt();
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
		stringBuilder_0.AppendLine("<FixedDatum>");
		try
		{
			stringBuilder_0.AppendLine("<fixedDatumID type=\"uint\">" + LFUESDCCCZL.ToString(CultureInfo.InvariantCulture) + "</fixedDatumID>");
			stringBuilder_0.AppendLine("<fixedDatumValue type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</fixedDatumValue>");
			stringBuilder_0.AppendLine("</FixedDatum>");
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
		return this == obj as FixedDatum;
	}

	public bool Equals(FixedDatum fixedDatum_0)
	{
		bool result = true;
		if (fixedDatum_0.GetType() == GetType())
		{
			if (LFUESDCCCZL != fixedDatum_0.LFUESDCCCZL)
			{
				result = false;
			}
			if (uint_0 != fixedDatum_0.uint_0)
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
		return smethod_0(smethod_0(0) ^ LFUESDCCCZL.GetHashCode()) ^ uint_0.GetHashCode();
	}
}
