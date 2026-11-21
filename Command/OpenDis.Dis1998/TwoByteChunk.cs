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
public class TwoByteChunk
{
	private byte[] byte_0 = new byte[2];

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlArray(ElementName = "otherParameters")]
	public byte[] OtherParameters
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

	public static bool operator !=(TwoByteChunk twoByteChunk_0, TwoByteChunk twoByteChunk_1)
	{
		return !(twoByteChunk_0 == twoByteChunk_1);
	}

	public static bool operator ==(TwoByteChunk twoByteChunk_0, TwoByteChunk twoByteChunk_1)
	{
		if ((object)twoByteChunk_0 == twoByteChunk_1)
		{
			return true;
		}
		if ((object)twoByteChunk_0 != null && (object)twoByteChunk_1 != null)
		{
			return twoByteChunk_0.Equals(twoByteChunk_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 2;
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
		stringBuilder_0.AppendLine("<TwoByteChunk>");
		try
		{
			for (int i = 0; i < byte_0.Length; i++)
			{
				stringBuilder_0.AppendLine("<otherParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + byte_0[i] + "</otherParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</TwoByteChunk>");
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
		return this == obj as TwoByteChunk;
	}

	public bool Equals(TwoByteChunk twoByteChunk_0)
	{
		bool flag = true;
		if (twoByteChunk_0.GetType() == GetType())
		{
			if (twoByteChunk_0.byte_0.Length != 2)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < 2; i++)
				{
					if (byte_0[i] != twoByteChunk_0.byte_0[i])
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
		for (int i = 0; i < 2; i++)
		{
			num = smethod_0(num) ^ byte_0[i].GetHashCode();
		}
		return num;
	}
}
