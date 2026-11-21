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
[XmlInclude(typeof(EntityID))]
public class TrackJamTarget
{
	private EntityID entityID_0 = new EntityID();

	private byte byte_0;

	private byte byte_1;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(EntityID), ElementName = "trackJam")]
	public EntityID TrackJam
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

	[XmlElement(Type = typeof(byte), ElementName = "emitterID")]
	public byte EmitterID
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

	[XmlElement(Type = typeof(byte), ElementName = "beamID")]
	public byte BeamID
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
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

	public static bool operator !=(TrackJamTarget trackJamTarget_0, TrackJamTarget trackJamTarget_1)
	{
		return !(trackJamTarget_0 == trackJamTarget_1);
	}

	public static bool operator ==(TrackJamTarget trackJamTarget_0, TrackJamTarget trackJamTarget_1)
	{
		if ((object)trackJamTarget_0 == trackJamTarget_1)
		{
			return true;
		}
		if ((object)trackJamTarget_0 != null && (object)trackJamTarget_1 != null)
		{
			return trackJamTarget_0.Equals(trackJamTarget_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return entityID_0.GetMarshalledSize() + 1 + 1;
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
			entityID_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedByte(byte_0);
			dataOutputStream_0.WriteUnsignedByte(byte_1);
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
			entityID_0.Unmarshal(dataInputStream_0);
			byte_0 = dataInputStream_0.ReadUnsignedByte();
			byte_1 = dataInputStream_0.ReadUnsignedByte();
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
		stringBuilder_0.AppendLine("<TrackJamTarget>");
		try
		{
			stringBuilder_0.AppendLine("<trackJam>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</trackJam>");
			stringBuilder_0.AppendLine("<emitterID type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</emitterID>");
			stringBuilder_0.AppendLine("<beamID type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</beamID>");
			stringBuilder_0.AppendLine("</TrackJamTarget>");
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
		return this == obj as TrackJamTarget;
	}

	public bool Equals(TrackJamTarget trackJamTarget_0)
	{
		bool result = true;
		if (trackJamTarget_0.GetType() == GetType())
		{
			if (!entityID_0.Equals(trackJamTarget_0.entityID_0))
			{
				result = false;
			}
			if (byte_0 != trackJamTarget_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != trackJamTarget_0.byte_1)
			{
				result = false;
			}
			return result;
		}
		return false;
	}

	private static int nlaEnTommAy(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return nlaEnTommAy(nlaEnTommAy(nlaEnTommAy(0) ^ entityID_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode();
	}
}
