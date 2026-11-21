#define TRACE
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(Vector3Double))]
[XmlRoot]
public class AntennaLocation
{
	private Vector3Double vector3Double_0 = new Vector3Double();

	private Vector3Float vector3Float_0 = new Vector3Float();

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(Vector3Double), ElementName = "antennaLocation")]
	public Vector3Double AntennaLocation_
	{
		get
		{
			return vector3Double_0;
		}
		set
		{
			vector3Double_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "relativeAntennaLocation")]
	public Vector3Float RelativeAntennaLocation
	{
		get
		{
			return vector3Float_0;
		}
		set
		{
			vector3Float_0 = value;
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

	public static bool operator !=(AntennaLocation antennaLocation_0, AntennaLocation antennaLocation_1)
	{
		return !(antennaLocation_0 == antennaLocation_1);
	}

	public static bool operator ==(AntennaLocation antennaLocation_0, AntennaLocation antennaLocation_1)
	{
		if ((object)antennaLocation_0 == antennaLocation_1)
		{
			return true;
		}
		if ((object)antennaLocation_0 != null && (object)antennaLocation_1 != null)
		{
			return antennaLocation_0.Equals(antennaLocation_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return vector3Double_0.GetMarshalledSize() + vector3Float_0.GetMarshalledSize();
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
			vector3Double_0.Marshal(dataOutputStream_0);
			vector3Float_0.Marshal(dataOutputStream_0);
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
			vector3Double_0.Unmarshal(dataInputStream_0);
			vector3Float_0.Unmarshal(dataInputStream_0);
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
		stringBuilder_0.AppendLine("<AntennaLocation>");
		try
		{
			stringBuilder_0.AppendLine("<antennaLocation>");
			vector3Double_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</antennaLocation>");
			stringBuilder_0.AppendLine("<relativeAntennaLocation>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</relativeAntennaLocation>");
			stringBuilder_0.AppendLine("</AntennaLocation>");
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
		return this == obj as AntennaLocation;
	}

	public bool Equals(AntennaLocation antennaLocation_0)
	{
		bool result = true;
		if (antennaLocation_0.GetType() == GetType())
		{
			if (!vector3Double_0.Equals(antennaLocation_0.vector3Double_0))
			{
				result = false;
			}
			if (!vector3Float_0.Equals(antennaLocation_0.vector3Float_0))
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
		return smethod_0(smethod_0(0) ^ vector3Double_0.GetHashCode()) ^ vector3Float_0.GetHashCode();
	}
}
