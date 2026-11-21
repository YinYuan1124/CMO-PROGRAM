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
public class Pdu : PduBase, IPdu
{
	private byte byte_0 = 5;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	private uint uint_0;

	private ushort ushort_0;

	private short short_0;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(byte), ElementName = "protocolVersion")]
	public byte ProtocolVersion
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

	[XmlElement(Type = typeof(byte), ElementName = "exerciseID")]
	public byte ExerciseID
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

	[XmlElement(Type = typeof(byte), ElementName = "pduType")]
	public byte PduType
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

	[XmlElement(Type = typeof(byte), ElementName = "protocolFamily")]
	public byte ProtocolFamily
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

	[XmlElement(Type = typeof(uint), ElementName = "timestamp")]
	public uint Timestamp
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

	[XmlElement(Type = typeof(ushort), ElementName = "length")]
	public ushort Length
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

	[XmlElement(Type = typeof(short), ElementName = "padding")]
	public short Padding
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

	public static bool operator !=(Pdu pdu_0, Pdu pdu_1)
	{
		return !(pdu_0 == pdu_1);
	}

	public static bool operator ==(Pdu pdu_0, Pdu pdu_1)
	{
		if ((object)pdu_0 == pdu_1)
		{
			return true;
		}
		if ((object)pdu_0 != null && (object)pdu_1 != null)
		{
			return pdu_0.Equals(pdu_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 12;
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
			dataOutputStream_0.WriteUnsignedInt(uint_0);
			dataOutputStream_0.WriteUnsignedShort(ushort_0);
			dataOutputStream_0.WriteShort(short_0);
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
			uint_0 = dataInputStream_0.ReadUnsignedInt();
			ushort_0 = dataInputStream_0.ReadUnsignedShort();
			short_0 = dataInputStream_0.ReadShort();
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
		stringBuilder_0.AppendLine("<Pdu>");
		try
		{
			stringBuilder_0.AppendLine("<protocolVersion type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</protocolVersion>");
			stringBuilder_0.AppendLine("<exerciseID type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</exerciseID>");
			stringBuilder_0.AppendLine("<pduType type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</pduType>");
			stringBuilder_0.AppendLine("<protocolFamily type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</protocolFamily>");
			stringBuilder_0.AppendLine("<timestamp type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</timestamp>");
			stringBuilder_0.AppendLine("<length type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</length>");
			stringBuilder_0.AppendLine("<padding type=\"short\">" + short_0.ToString(CultureInfo.InvariantCulture) + "</padding>");
			stringBuilder_0.AppendLine("</Pdu>");
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
		return this == obj as Pdu;
	}

	public bool Equals(Pdu pdu_0)
	{
		bool result = true;
		if (pdu_0.GetType() == GetType())
		{
			if (byte_0 != pdu_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != pdu_0.byte_1)
			{
				result = false;
			}
			if (byte_2 != pdu_0.byte_2)
			{
				result = false;
			}
			if (byte_3 != pdu_0.byte_3)
			{
				result = false;
			}
			if (uint_0 != pdu_0.uint_0)
			{
				result = false;
			}
			if (ushort_0 != pdu_0.ushort_0)
			{
				result = false;
			}
			if (short_0 != pdu_0.short_0)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ byte_3.GetHashCode()) ^ uint_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ short_0.GetHashCode();
	}
}
