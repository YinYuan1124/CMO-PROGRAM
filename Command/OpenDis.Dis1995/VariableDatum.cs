#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlInclude(typeof(EightByteChunk))]
[XmlRoot]
public class VariableDatum
{
	private uint uint_0;

	private uint uint_1;

	private List<EightByteChunk> list_0 = new List<EightByteChunk>();

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(uint), ElementName = "variableDatumID")]
	public uint VariableDatumID
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

	[XmlElement(Type = typeof(uint), ElementName = "variableDatumLength")]
	public uint VariableDatumLength
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	[XmlElement(ElementName = "variableDatumsList", Type = typeof(List<EightByteChunk>))]
	public List<EightByteChunk> VariableDatums => list_0;

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

	public static bool operator !=(VariableDatum variableDatum_0, VariableDatum variableDatum_1)
	{
		return !(variableDatum_0 == variableDatum_1);
	}

	public static bool operator ==(VariableDatum variableDatum_0, VariableDatum variableDatum_1)
	{
		if ((object)variableDatum_0 == variableDatum_1)
		{
			return true;
		}
		if ((object)variableDatum_0 != null && (object)variableDatum_1 != null)
		{
			return variableDatum_0.Equals(variableDatum_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		int num = 0;
		num = 4;
		num = 8;
		for (int i = 0; i < list_0.Count; i++)
		{
			EightByteChunk eightByteChunk = list_0[i];
			num += eightByteChunk.GetMarshalledSize();
		}
		return num;
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
			dataOutputStream_0.WriteUnsignedInt(uint_0);
			dataOutputStream_0.WriteUnsignedInt((uint)list_0.Count);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dataOutputStream_0);
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
			uint_0 = dataInputStream_0.ReadUnsignedInt();
			uint_1 = dataInputStream_0.ReadUnsignedInt();
			for (int i = 0; i < VariableDatumLength; i++)
			{
				EightByteChunk eightByteChunk = new EightByteChunk();
				eightByteChunk.Unmarshal(dataInputStream_0);
				list_0.Add(eightByteChunk);
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
		stringBuilder_0.AppendLine("<VariableDatum>");
		try
		{
			stringBuilder_0.AppendLine("<variableDatumID type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</variableDatumID>");
			stringBuilder_0.AppendLine("<variableDatums type=\"uint\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</variableDatums>");
			for (int i = 0; i < list_0.Count; i++)
			{
				stringBuilder_0.AppendLine("<variableDatums" + i.ToString(CultureInfo.InvariantCulture) + " type=\"EightByteChunk\">");
				list_0[i].Reflection(stringBuilder_0);
				stringBuilder_0.AppendLine("</variableDatums" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</VariableDatum>");
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
		return this == obj as VariableDatum;
	}

	public bool Equals(VariableDatum variableDatum_0)
	{
		bool flag = true;
		if (variableDatum_0.GetType() == GetType())
		{
			if (uint_0 != variableDatum_0.uint_0)
			{
				flag = false;
			}
			if (uint_1 != variableDatum_0.uint_1)
			{
				flag = false;
			}
			if (list_0.Count != variableDatum_0.list_0.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < list_0.Count; i++)
				{
					if (!list_0[i].Equals(variableDatum_0.list_0[i]))
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
		num = smethod_0(0) ^ uint_0.GetHashCode();
		num = smethod_0(num) ^ uint_1.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_0(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}
}
