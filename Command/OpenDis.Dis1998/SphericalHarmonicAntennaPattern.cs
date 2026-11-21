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
public class SphericalHarmonicAntennaPattern
{
	private byte byte_0;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(byte), ElementName = "order")]
	public byte Order
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

	public static bool operator !=(SphericalHarmonicAntennaPattern sphericalHarmonicAntennaPattern_0, SphericalHarmonicAntennaPattern sphericalHarmonicAntennaPattern_1)
	{
		return !(sphericalHarmonicAntennaPattern_0 == sphericalHarmonicAntennaPattern_1);
	}

	public static bool operator ==(SphericalHarmonicAntennaPattern sphericalHarmonicAntennaPattern_0, SphericalHarmonicAntennaPattern sphericalHarmonicAntennaPattern_1)
	{
		if ((object)sphericalHarmonicAntennaPattern_0 == sphericalHarmonicAntennaPattern_1)
		{
			return true;
		}
		if ((object)sphericalHarmonicAntennaPattern_0 != null && (object)sphericalHarmonicAntennaPattern_1 != null)
		{
			return sphericalHarmonicAntennaPattern_0.Equals(sphericalHarmonicAntennaPattern_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 1;
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
			dataOutputStream_0.WriteByte(byte_0);
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
			byte_0 = dataInputStream_0.ReadByte();
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
		stringBuilder_0.AppendLine("<SphericalHarmonicAntennaPattern>");
		try
		{
			stringBuilder_0.AppendLine("<order type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</order>");
			stringBuilder_0.AppendLine("</SphericalHarmonicAntennaPattern>");
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
		return this == obj as SphericalHarmonicAntennaPattern;
	}

	public bool Equals(SphericalHarmonicAntennaPattern sphericalHarmonicAntennaPattern_0)
	{
		bool result = true;
		if (sphericalHarmonicAntennaPattern_0.GetType() == GetType())
		{
			if (byte_0 != sphericalHarmonicAntennaPattern_0.byte_0)
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
		return smethod_0(0) ^ byte_0.GetHashCode();
	}
}
