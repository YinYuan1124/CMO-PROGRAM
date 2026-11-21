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
public class ShaftRPMs
{
	private short short_0;

	private short short_1;

	private float float_0;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(short), ElementName = "currentShaftRPMs")]
	public short CurrentShaftRPMs
	{
		get
		{
			return short_0;
		}
		set
		{
			short_0 = value;
		}
	}

	[XmlElement(Type = typeof(short), ElementName = "orderedShaftRPMs")]
	public short OrderedShaftRPMs
	{
		get
		{
			return short_1;
		}
		set
		{
			short_1 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "shaftRPMRateOfChange")]
	public float Single_0
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
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

	public static bool operator !=(ShaftRPMs shaftRPMs_0, ShaftRPMs shaftRPMs_1)
	{
		return !(shaftRPMs_0 == shaftRPMs_1);
	}

	public static bool operator ==(ShaftRPMs shaftRPMs_0, ShaftRPMs shaftRPMs_1)
	{
		if ((object)shaftRPMs_0 == shaftRPMs_1)
		{
			return true;
		}
		if ((object)shaftRPMs_0 != null && (object)shaftRPMs_1 != null)
		{
			return shaftRPMs_0.Equals(shaftRPMs_1);
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
			dataOutputStream_0.WriteShort(short_0);
			dataOutputStream_0.WriteShort(short_1);
			dataOutputStream_0.WriteFloat(float_0);
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
			short_0 = dataInputStream_0.ReadShort();
			short_1 = dataInputStream_0.ReadShort();
			float_0 = dataInputStream_0.ReadFloat();
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
		stringBuilder_0.AppendLine("<ShaftRPMs>");
		try
		{
			stringBuilder_0.AppendLine("<currentShaftRPMs type=\"short\">" + short_0.ToString(CultureInfo.InvariantCulture) + "</currentShaftRPMs>");
			stringBuilder_0.AppendLine("<orderedShaftRPMs type=\"short\">" + short_1.ToString(CultureInfo.InvariantCulture) + "</orderedShaftRPMs>");
			stringBuilder_0.AppendLine("<shaftRPMRateOfChange type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</shaftRPMRateOfChange>");
			stringBuilder_0.AppendLine("</ShaftRPMs>");
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
		return this == obj as ShaftRPMs;
	}

	public bool Equals(ShaftRPMs shaftRPMs_0)
	{
		bool result = true;
		if (shaftRPMs_0.GetType() == GetType())
		{
			if (short_0 != shaftRPMs_0.short_0)
			{
				result = false;
			}
			if (short_1 != shaftRPMs_0.short_1)
			{
				result = false;
			}
			if (float_0 != shaftRPMs_0.float_0)
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
		return smethod_0(smethod_0(smethod_0(0) ^ short_0.GetHashCode()) ^ short_1.GetHashCode()) ^ float_0.GetHashCode();
	}
}
