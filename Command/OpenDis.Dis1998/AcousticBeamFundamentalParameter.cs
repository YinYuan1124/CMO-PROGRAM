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
public class AcousticBeamFundamentalParameter
{
	private ushort ushort_0;

	private ushort ushort_1;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(ushort), ElementName = "activeEmissionParameterIndex")]
	public ushort ActiveEmissionParameterIndex
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

	[XmlElement(Type = typeof(ushort), ElementName = "scanPattern")]
	public ushort ScanPattern
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

	[XmlElement(Type = typeof(float), ElementName = "beamCenterAzimuth")]
	public float BeamCenterAzimuth
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

	[XmlElement(Type = typeof(float), ElementName = "azimuthalBeamwidth")]
	public float AzimuthalBeamwidth
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

	[XmlElement(Type = typeof(float), ElementName = "beamCenterDE")]
	public float BeamCenterDE
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

	[XmlElement(Type = typeof(float), ElementName = "deBeamwidth")]
	public float DeBeamwidth
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

	public static bool operator !=(AcousticBeamFundamentalParameter acousticBeamFundamentalParameter_0, AcousticBeamFundamentalParameter acousticBeamFundamentalParameter_1)
	{
		return !(acousticBeamFundamentalParameter_0 == acousticBeamFundamentalParameter_1);
	}

	public static bool operator ==(AcousticBeamFundamentalParameter acousticBeamFundamentalParameter_0, AcousticBeamFundamentalParameter acousticBeamFundamentalParameter_1)
	{
		if ((object)acousticBeamFundamentalParameter_0 == acousticBeamFundamentalParameter_1)
		{
			return true;
		}
		if ((object)acousticBeamFundamentalParameter_0 != null && (object)acousticBeamFundamentalParameter_1 != null)
		{
			return acousticBeamFundamentalParameter_0.Equals(acousticBeamFundamentalParameter_1);
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
			dataOutputStream_0.WriteUnsignedShort(ushort_0);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			dataOutputStream_0.WriteFloat(float_0);
			dataOutputStream_0.WriteFloat(float_1);
			dataOutputStream_0.WriteFloat(float_2);
			dataOutputStream_0.WriteFloat(float_3);
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
			float_0 = dataInputStream_0.ReadFloat();
			float_1 = dataInputStream_0.ReadFloat();
			float_2 = dataInputStream_0.ReadFloat();
			float_3 = dataInputStream_0.ReadFloat();
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
		stringBuilder_0.AppendLine("<AcousticBeamFundamentalParameter>");
		try
		{
			stringBuilder_0.AppendLine("<activeEmissionParameterIndex type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</activeEmissionParameterIndex>");
			stringBuilder_0.AppendLine("<scanPattern type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</scanPattern>");
			stringBuilder_0.AppendLine("<beamCenterAzimuth type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</beamCenterAzimuth>");
			stringBuilder_0.AppendLine("<azimuthalBeamwidth type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</azimuthalBeamwidth>");
			stringBuilder_0.AppendLine("<beamCenterDE type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</beamCenterDE>");
			stringBuilder_0.AppendLine("<deBeamwidth type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</deBeamwidth>");
			stringBuilder_0.AppendLine("</AcousticBeamFundamentalParameter>");
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
		return this == obj as AcousticBeamFundamentalParameter;
	}

	public bool Equals(AcousticBeamFundamentalParameter acousticBeamFundamentalParameter_0)
	{
		bool result = true;
		if (acousticBeamFundamentalParameter_0.GetType() == GetType())
		{
			if (ushort_0 != acousticBeamFundamentalParameter_0.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != acousticBeamFundamentalParameter_0.ushort_1)
			{
				result = false;
			}
			if (float_0 != acousticBeamFundamentalParameter_0.float_0)
			{
				result = false;
			}
			if (float_1 != acousticBeamFundamentalParameter_0.float_1)
			{
				result = false;
			}
			if (float_2 != acousticBeamFundamentalParameter_0.float_2)
			{
				result = false;
			}
			if (float_3 != acousticBeamFundamentalParameter_0.float_3)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode()) ^ float_3.GetHashCode();
	}
}
