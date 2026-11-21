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
public class BeamData
{
	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(float), ElementName = "beamAzimuthCenter")]
	public float BeamAzimuthCenter
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

	[XmlElement(Type = typeof(float), ElementName = "beamAzimuthSweep")]
	public float BeamAzimuthSweep
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "beamElevationCenter")]
	public float BeamElevationCenter
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "beamElevationSweep")]
	public float BeamElevationSweep
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "beamSweepSync")]
	public float BeamSweepSync
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
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

	public static bool operator !=(BeamData beamData_0, BeamData beamData_1)
	{
		return !(beamData_0 == beamData_1);
	}

	public static bool operator ==(BeamData beamData_0, BeamData beamData_1)
	{
		if ((object)beamData_0 == beamData_1)
		{
			return true;
		}
		if ((object)beamData_0 != null && (object)beamData_1 != null)
		{
			return beamData_0.Equals(beamData_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 20;
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
			dataOutputStream_0.WriteFloat(float_0);
			dataOutputStream_0.WriteFloat(float_1);
			dataOutputStream_0.WriteFloat(float_2);
			dataOutputStream_0.WriteFloat(float_3);
			dataOutputStream_0.WriteFloat(float_4);
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
			float_0 = dataInputStream_0.ReadFloat();
			float_1 = dataInputStream_0.ReadFloat();
			float_2 = dataInputStream_0.ReadFloat();
			float_3 = dataInputStream_0.ReadFloat();
			float_4 = dataInputStream_0.ReadFloat();
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
		stringBuilder_0.AppendLine("<BeamData>");
		try
		{
			stringBuilder_0.AppendLine("<beamAzimuthCenter type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</beamAzimuthCenter>");
			stringBuilder_0.AppendLine("<beamAzimuthSweep type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</beamAzimuthSweep>");
			stringBuilder_0.AppendLine("<beamElevationCenter type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</beamElevationCenter>");
			stringBuilder_0.AppendLine("<beamElevationSweep type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</beamElevationSweep>");
			stringBuilder_0.AppendLine("<beamSweepSync type=\"float\">" + float_4.ToString(CultureInfo.InvariantCulture) + "</beamSweepSync>");
			stringBuilder_0.AppendLine("</BeamData>");
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
		return this == obj as BeamData;
	}

	public bool Equals(BeamData beamData_0)
	{
		bool result = true;
		if (beamData_0.GetType() == GetType())
		{
			if (float_0 != beamData_0.float_0)
			{
				result = false;
			}
			if (float_1 != beamData_0.float_1)
			{
				result = false;
			}
			if (float_2 != beamData_0.float_2)
			{
				result = false;
			}
			if (float_3 != beamData_0.float_3)
			{
				result = false;
			}
			if (float_4 != beamData_0.float_4)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode()) ^ float_3.GetHashCode()) ^ float_4.GetHashCode();
	}
}
