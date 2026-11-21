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
public class ArticulationParameter
{
	private byte byte_0;

	private byte byte_1;

	private ushort ushort_0;

	private int int_0;

	private double double_0;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(byte), ElementName = "parameterTypeDesignator")]
	public byte ParameterTypeDesignator
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

	[XmlElement(Type = typeof(byte), ElementName = "changeIndicator")]
	public byte ChangeIndicator
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

	[XmlElement(Type = typeof(ushort), ElementName = "partAttachedTo")]
	public ushort PartAttachedTo
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

	[XmlElement(Type = typeof(int), ElementName = "parameterType")]
	public int ParameterType
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	[XmlElement(Type = typeof(double), ElementName = "parameterValue")]
	public double ParameterValue
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
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

	public static bool operator !=(ArticulationParameter articulationParameter_0, ArticulationParameter articulationParameter_1)
	{
		return !(articulationParameter_0 == articulationParameter_1);
	}

	public static bool operator ==(ArticulationParameter articulationParameter_0, ArticulationParameter articulationParameter_1)
	{
		if ((object)articulationParameter_0 == articulationParameter_1)
		{
			return true;
		}
		if ((object)articulationParameter_0 != null && (object)articulationParameter_1 != null)
		{
			return articulationParameter_0.Equals(articulationParameter_1);
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
			dataOutputStream_0.WriteUnsignedShort(ushort_0);
			dataOutputStream_0.WriteInt(int_0);
			dataOutputStream_0.WriteDouble(double_0);
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
			ushort_0 = dataInputStream_0.ReadUnsignedShort();
			int_0 = dataInputStream_0.ReadInt();
			double_0 = dataInputStream_0.ReadDouble();
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
		stringBuilder_0.AppendLine("<ArticulationParameter>");
		try
		{
			stringBuilder_0.AppendLine("<parameterTypeDesignator type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</parameterTypeDesignator>");
			stringBuilder_0.AppendLine("<changeIndicator type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</changeIndicator>");
			stringBuilder_0.AppendLine("<partAttachedTo type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</partAttachedTo>");
			stringBuilder_0.AppendLine("<parameterType type=\"int\">" + int_0.ToString(CultureInfo.InvariantCulture) + "</parameterType>");
			stringBuilder_0.AppendLine("<parameterValue type=\"double\">" + double_0.ToString(CultureInfo.InvariantCulture) + "</parameterValue>");
			stringBuilder_0.AppendLine("</ArticulationParameter>");
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
		return this == obj as ArticulationParameter;
	}

	public bool Equals(ArticulationParameter articulationParameter_0)
	{
		bool result = true;
		if (articulationParameter_0.GetType() == GetType())
		{
			if (byte_0 != articulationParameter_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != articulationParameter_0.byte_1)
			{
				result = false;
			}
			if (ushort_0 != articulationParameter_0.ushort_0)
			{
				result = false;
			}
			if (int_0 != articulationParameter_0.int_0)
			{
				result = false;
			}
			if (double_0 != articulationParameter_0.double_0)
			{
				result = false;
			}
			return result;
		}
		return false;
	}

	private static int smethod_0(int int_1)
	{
		int_1 <<= 5 + int_1;
		return int_1;
	}

	public override int GetHashCode()
	{
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ ushort_0.GetHashCode()) ^ int_0.GetHashCode()) ^ double_0.GetHashCode();
	}
}
