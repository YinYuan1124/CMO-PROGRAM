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
public class AggregateMarking
{
	private byte flkEirEekcV;

	private byte[] byte_0 = new byte[31];

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(byte), ElementName = "characterSet")]
	public byte CharacterSet
	{
		get
		{
			return flkEirEekcV;
		}
		set
		{
			flkEirEekcV = value;
		}
	}

	[XmlArray(ElementName = "characters")]
	public byte[] Characters
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

	public static bool operator !=(AggregateMarking aggregateMarking_0, AggregateMarking aggregateMarking_1)
	{
		return !(aggregateMarking_0 == aggregateMarking_1);
	}

	public static bool operator ==(AggregateMarking aggregateMarking_0, AggregateMarking aggregateMarking_1)
	{
		if ((object)aggregateMarking_0 == aggregateMarking_1)
		{
			return true;
		}
		if ((object)aggregateMarking_0 != null && (object)aggregateMarking_1 != null)
		{
			return aggregateMarking_0.Equals(aggregateMarking_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 32;
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
			dataOutputStream_0.WriteUnsignedByte(flkEirEekcV);
			for (int i = 0; i < byte_0.Length; i++)
			{
				dataOutputStream_0.WriteByte(byte_0[i]);
			}
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
			flkEirEekcV = dataInputStream_0.ReadUnsignedByte();
			for (int i = 0; i < byte_0.Length; i++)
			{
				byte_0[i] = dataInputStream_0.ReadByte();
			}
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
		stringBuilder_0.AppendLine("<AggregateMarking>");
		try
		{
			stringBuilder_0.AppendLine("<characterSet type=\"byte\">" + flkEirEekcV.ToString(CultureInfo.InvariantCulture) + "</characterSet>");
			for (int i = 0; i < byte_0.Length; i++)
			{
				stringBuilder_0.AppendLine("<characters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + byte_0[i] + "</characters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</AggregateMarking>");
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
		return this == obj as AggregateMarking;
	}

	public bool Equals(AggregateMarking aggregateMarking_0)
	{
		bool flag = true;
		if (aggregateMarking_0.GetType() == GetType())
		{
			if (flkEirEekcV != aggregateMarking_0.flkEirEekcV)
			{
				flag = false;
			}
			if (aggregateMarking_0.byte_0.Length != 31)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < 31; i++)
				{
					if (byte_0[i] != aggregateMarking_0.byte_0[i])
					{
						flag = false;
					}
				}
			}
			return flag;
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
		int num = 0;
		num = smethod_0(0) ^ flkEirEekcV.GetHashCode();
		for (int i = 0; i < 31; i++)
		{
			num = smethod_0(num) ^ byte_0[i].GetHashCode();
		}
		return num;
	}
}
