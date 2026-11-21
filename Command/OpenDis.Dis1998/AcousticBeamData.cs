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
[XmlInclude(typeof(AcousticBeamFundamentalParameter))]
public class AcousticBeamData
{
	private ushort ushort_0;

	private byte byte_0;

	private ushort ushort_1;

	private AcousticBeamFundamentalParameter acousticBeamFundamentalParameter_0 = new AcousticBeamFundamentalParameter();

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(ushort), ElementName = "beamDataLength")]
	public ushort BeamDataLength
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

	[XmlElement(Type = typeof(byte), ElementName = "beamIDNumber")]
	public byte BeamIDNumber
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

	[XmlElement(Type = typeof(ushort), ElementName = "pad2")]
	public ushort Pad2
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

	[XmlElement(Type = typeof(AcousticBeamFundamentalParameter), ElementName = "fundamentalDataParameters")]
	public AcousticBeamFundamentalParameter FundamentalDataParameters
	{
		get
		{
			return acousticBeamFundamentalParameter_0;
		}
		set
		{
			acousticBeamFundamentalParameter_0 = value;
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

	public static bool operator !=(AcousticBeamData acousticBeamData_0, AcousticBeamData acousticBeamData_1)
	{
		return !(acousticBeamData_0 == acousticBeamData_1);
	}

	public static bool operator ==(AcousticBeamData acousticBeamData_0, AcousticBeamData acousticBeamData_1)
	{
		if ((object)acousticBeamData_0 == acousticBeamData_1)
		{
			return true;
		}
		if ((object)acousticBeamData_0 != null && (object)acousticBeamData_1 != null)
		{
			return acousticBeamData_0.Equals(acousticBeamData_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 5 + acousticBeamFundamentalParameter_0.GetMarshalledSize();
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
			dataOutputStream_0.WriteUnsignedByte(byte_0);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			acousticBeamFundamentalParameter_0.Marshal(dataOutputStream_0);
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
			byte_0 = dataInputStream_0.ReadUnsignedByte();
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			acousticBeamFundamentalParameter_0.Unmarshal(dataInputStream_0);
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
		stringBuilder_0.AppendLine("<AcousticBeamData>");
		try
		{
			stringBuilder_0.AppendLine("<beamDataLength type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</beamDataLength>");
			stringBuilder_0.AppendLine("<beamIDNumber type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</beamIDNumber>");
			stringBuilder_0.AppendLine("<pad2 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			stringBuilder_0.AppendLine("<fundamentalDataParameters>");
			acousticBeamFundamentalParameter_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</fundamentalDataParameters>");
			stringBuilder_0.AppendLine("</AcousticBeamData>");
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
		return this == obj as AcousticBeamData;
	}

	public bool Equals(AcousticBeamData acousticBeamData_0)
	{
		bool result = true;
		if (acousticBeamData_0.GetType() == GetType())
		{
			if (ushort_0 != acousticBeamData_0.ushort_0)
			{
				result = false;
			}
			if (byte_0 != acousticBeamData_0.byte_0)
			{
				result = false;
			}
			if (ushort_1 != acousticBeamData_0.ushort_1)
			{
				result = false;
			}
			if (!acousticBeamFundamentalParameter_0.Equals(acousticBeamData_0.acousticBeamFundamentalParameter_0))
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
		return smethod_0(smethod_0(smethod_0(smethod_0(0) ^ ushort_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ acousticBeamFundamentalParameter_0.GetHashCode();
	}
}
