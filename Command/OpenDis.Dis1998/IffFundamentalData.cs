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
public class IffFundamentalData
{
	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	private ushort ushort_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private ushort ushort_4;

	private ushort ushort_5;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(byte), ElementName = "systemStatus")]
	public byte SystemStatus
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

	[XmlElement(Type = typeof(byte), ElementName = "alternateParameter4")]
	public byte AlternateParameter4
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

	[XmlElement(Type = typeof(byte), ElementName = "informationLayers")]
	public byte InformationLayers
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "modifier")]
	public byte Modifier
	{
		get
		{
			return byte_3;
		}
		set
		{
			byte_3 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "parameter1")]
	public ushort Parameter1
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

	[XmlElement(Type = typeof(ushort), ElementName = "parameter2")]
	public ushort Parameter2
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

	[XmlElement(Type = typeof(ushort), ElementName = "parameter3")]
	public ushort Parameter3
	{
		get
		{
			return ushort_2;
		}
		set
		{
			ushort_2 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "parameter4")]
	public ushort Parameter4
	{
		get
		{
			return ushort_3;
		}
		set
		{
			ushort_3 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "parameter5")]
	public ushort Parameter5
	{
		get
		{
			return ushort_4;
		}
		set
		{
			ushort_4 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "parameter6")]
	public ushort Parameter6
	{
		get
		{
			return ushort_5;
		}
		set
		{
			ushort_5 = value;
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

	public static bool operator !=(IffFundamentalData iffFundamentalData_0, IffFundamentalData iffFundamentalData_1)
	{
		return !(iffFundamentalData_0 == iffFundamentalData_1);
	}

	public static bool operator ==(IffFundamentalData iffFundamentalData_0, IffFundamentalData iffFundamentalData_1)
	{
		if ((object)iffFundamentalData_0 == iffFundamentalData_1)
		{
			return true;
		}
		if ((object)iffFundamentalData_0 != null && (object)iffFundamentalData_1 != null)
		{
			return iffFundamentalData_0.Equals(iffFundamentalData_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 16;
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
			dataOutputStream_0.WriteUnsignedByte(byte_0);
			dataOutputStream_0.WriteUnsignedByte(byte_1);
			dataOutputStream_0.WriteUnsignedByte(byte_2);
			dataOutputStream_0.WriteUnsignedByte(byte_3);
			dataOutputStream_0.WriteUnsignedShort(ushort_0);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			dataOutputStream_0.WriteUnsignedShort(ushort_2);
			dataOutputStream_0.WriteUnsignedShort(ushort_3);
			dataOutputStream_0.WriteUnsignedShort(ushort_4);
			dataOutputStream_0.WriteUnsignedShort(ushort_5);
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
			byte_0 = dataInputStream_0.ReadUnsignedByte();
			byte_1 = dataInputStream_0.ReadUnsignedByte();
			byte_2 = dataInputStream_0.ReadUnsignedByte();
			byte_3 = dataInputStream_0.ReadUnsignedByte();
			ushort_0 = dataInputStream_0.ReadUnsignedShort();
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			ushort_2 = dataInputStream_0.ReadUnsignedShort();
			ushort_3 = dataInputStream_0.ReadUnsignedShort();
			ushort_4 = dataInputStream_0.ReadUnsignedShort();
			ushort_5 = dataInputStream_0.ReadUnsignedShort();
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
		stringBuilder_0.AppendLine("<IffFundamentalData>");
		try
		{
			stringBuilder_0.AppendLine("<systemStatus type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</systemStatus>");
			stringBuilder_0.AppendLine("<alternateParameter4 type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</alternateParameter4>");
			stringBuilder_0.AppendLine("<informationLayers type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</informationLayers>");
			stringBuilder_0.AppendLine("<modifier type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</modifier>");
			stringBuilder_0.AppendLine("<parameter1 type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</parameter1>");
			stringBuilder_0.AppendLine("<parameter2 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</parameter2>");
			stringBuilder_0.AppendLine("<parameter3 type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</parameter3>");
			stringBuilder_0.AppendLine("<parameter4 type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</parameter4>");
			stringBuilder_0.AppendLine("<parameter5 type=\"ushort\">" + ushort_4.ToString(CultureInfo.InvariantCulture) + "</parameter5>");
			stringBuilder_0.AppendLine("<parameter6 type=\"ushort\">" + ushort_5.ToString(CultureInfo.InvariantCulture) + "</parameter6>");
			stringBuilder_0.AppendLine("</IffFundamentalData>");
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
		return this == obj as IffFundamentalData;
	}

	public bool Equals(IffFundamentalData iffFundamentalData_0)
	{
		bool result = true;
		if (iffFundamentalData_0.GetType() == GetType())
		{
			if (byte_0 != iffFundamentalData_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != iffFundamentalData_0.byte_1)
			{
				result = false;
			}
			if (byte_2 != iffFundamentalData_0.byte_2)
			{
				result = false;
			}
			if (byte_3 != iffFundamentalData_0.byte_3)
			{
				result = false;
			}
			if (ushort_0 != iffFundamentalData_0.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != iffFundamentalData_0.ushort_1)
			{
				result = false;
			}
			if (ushort_2 != iffFundamentalData_0.ushort_2)
			{
				result = false;
			}
			if (ushort_3 != iffFundamentalData_0.ushort_3)
			{
				result = false;
			}
			if (ushort_4 != iffFundamentalData_0.ushort_4)
			{
				result = false;
			}
			if (ushort_5 != iffFundamentalData_0.ushort_5)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ byte_3.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ ushort_2.GetHashCode()) ^ ushort_3.GetHashCode()) ^ ushort_4.GetHashCode()) ^ ushort_5.GetHashCode();
	}
}
