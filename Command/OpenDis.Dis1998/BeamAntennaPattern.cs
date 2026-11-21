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
[XmlInclude(typeof(Orientation))]
public class BeamAntennaPattern
{
	private Orientation orientation_0 = new Orientation();

	private float float_0;

	private float float_1;

	private short short_0;

	private byte byte_0;

	private float float_2;

	private float float_3;

	private float float_4;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(Orientation), ElementName = "beamDirection")]
	public Orientation BeamDirection
	{
		get
		{
			return orientation_0;
		}
		set
		{
			orientation_0 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "azimuthBeamwidth")]
	public float AzimuthBeamwidth
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

	[XmlElement(Type = typeof(float), ElementName = "referenceSystem")]
	public float ReferenceSystem
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

	[XmlElement(Type = typeof(short), ElementName = "padding1")]
	public short Padding1
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

	[XmlElement(Type = typeof(byte), ElementName = "padding2")]
	public byte Padding2
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

	[XmlElement(Type = typeof(float), ElementName = "ez")]
	public float Ez
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

	[XmlElement(Type = typeof(float), ElementName = "ex")]
	public float Ex
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

	[XmlElement(Type = typeof(float), ElementName = "phase")]
	public float Phase
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

	public static bool operator !=(BeamAntennaPattern beamAntennaPattern_0, BeamAntennaPattern beamAntennaPattern_1)
	{
		return !(beamAntennaPattern_0 == beamAntennaPattern_1);
	}

	public static bool operator ==(BeamAntennaPattern beamAntennaPattern_0, BeamAntennaPattern beamAntennaPattern_1)
	{
		if ((object)beamAntennaPattern_0 == beamAntennaPattern_1)
		{
			return true;
		}
		if ((object)beamAntennaPattern_0 != null && (object)beamAntennaPattern_1 != null)
		{
			return beamAntennaPattern_0.Equals(beamAntennaPattern_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return orientation_0.GetMarshalledSize() + 4 + 4 + 2 + 1 + 4 + 4 + 4;
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
			orientation_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteFloat(float_0);
			dataOutputStream_0.WriteFloat(float_1);
			dataOutputStream_0.WriteShort(short_0);
			dataOutputStream_0.WriteByte(byte_0);
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
			orientation_0.Unmarshal(dataInputStream_0);
			float_0 = dataInputStream_0.ReadFloat();
			float_1 = dataInputStream_0.ReadFloat();
			short_0 = dataInputStream_0.ReadShort();
			byte_0 = dataInputStream_0.ReadByte();
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
		stringBuilder_0.AppendLine("<BeamAntennaPattern>");
		try
		{
			stringBuilder_0.AppendLine("<beamDirection>");
			orientation_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</beamDirection>");
			stringBuilder_0.AppendLine("<azimuthBeamwidth type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</azimuthBeamwidth>");
			stringBuilder_0.AppendLine("<referenceSystem type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</referenceSystem>");
			stringBuilder_0.AppendLine("<padding1 type=\"short\">" + short_0.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			stringBuilder_0.AppendLine("<padding2 type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			stringBuilder_0.AppendLine("<ez type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</ez>");
			stringBuilder_0.AppendLine("<ex type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</ex>");
			stringBuilder_0.AppendLine("<phase type=\"float\">" + float_4.ToString(CultureInfo.InvariantCulture) + "</phase>");
			stringBuilder_0.AppendLine("</BeamAntennaPattern>");
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
		return this == obj as BeamAntennaPattern;
	}

	public bool Equals(BeamAntennaPattern beamAntennaPattern_0)
	{
		bool result = true;
		if (beamAntennaPattern_0.GetType() == GetType())
		{
			if (!orientation_0.Equals(beamAntennaPattern_0.orientation_0))
			{
				result = false;
			}
			if (float_0 != beamAntennaPattern_0.float_0)
			{
				result = false;
			}
			if (float_1 != beamAntennaPattern_0.float_1)
			{
				result = false;
			}
			if (short_0 != beamAntennaPattern_0.short_0)
			{
				result = false;
			}
			if (byte_0 != beamAntennaPattern_0.byte_0)
			{
				result = false;
			}
			if (float_2 != beamAntennaPattern_0.float_2)
			{
				result = false;
			}
			if (float_3 != beamAntennaPattern_0.float_3)
			{
				result = false;
			}
			if (float_4 != beamAntennaPattern_0.float_4)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ orientation_0.GetHashCode()) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ short_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ float_2.GetHashCode()) ^ float_3.GetHashCode()) ^ float_4.GetHashCode();
	}
}
