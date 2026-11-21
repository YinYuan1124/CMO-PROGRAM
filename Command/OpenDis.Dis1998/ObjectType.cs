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
public class ObjectType
{
	private byte byte_0;

	private byte byte_1;

	private ushort ushort_0;

	private byte byte_2;

	private byte byte_3;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(byte), ElementName = "entityKind")]
	public byte EntityKind
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

	[XmlElement(Type = typeof(byte), ElementName = "domain")]
	public byte Domain
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

	[XmlElement(Type = typeof(ushort), ElementName = "country")]
	public ushort Country
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

	[XmlElement(Type = typeof(byte), ElementName = "category")]
	public byte Category
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

	[XmlElement(Type = typeof(byte), ElementName = "subcategory")]
	public byte Subcategory
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

	public static bool operator !=(ObjectType objectType_0, ObjectType objectType_1)
	{
		return !(objectType_0 == objectType_1);
	}

	public static bool operator ==(ObjectType objectType_0, ObjectType objectType_1)
	{
		if ((object)objectType_0 == objectType_1)
		{
			return true;
		}
		if ((object)objectType_0 != null && (object)objectType_1 != null)
		{
			return objectType_0.Equals(objectType_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 6;
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
			dataOutputStream_0.WriteUnsignedByte(byte_2);
			dataOutputStream_0.WriteUnsignedByte(byte_3);
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
			byte_2 = dataInputStream_0.ReadUnsignedByte();
			byte_3 = dataInputStream_0.ReadUnsignedByte();
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
		stringBuilder_0.AppendLine("<ObjectType>");
		try
		{
			stringBuilder_0.AppendLine("<entityKind type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</entityKind>");
			stringBuilder_0.AppendLine("<domain type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</domain>");
			stringBuilder_0.AppendLine("<country type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</country>");
			stringBuilder_0.AppendLine("<category type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</category>");
			stringBuilder_0.AppendLine("<subcategory type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</subcategory>");
			stringBuilder_0.AppendLine("</ObjectType>");
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
		return this == obj as ObjectType;
	}

	public bool Equals(ObjectType objectType_0)
	{
		bool result = true;
		if (objectType_0.GetType() == GetType())
		{
			if (byte_0 != objectType_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != objectType_0.byte_1)
			{
				result = false;
			}
			if (ushort_0 != objectType_0.ushort_0)
			{
				result = false;
			}
			if (byte_2 != objectType_0.byte_2)
			{
				result = false;
			}
			if (byte_3 != objectType_0.byte_3)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ ushort_0.GetHashCode()) ^ byte_2.GetHashCode()) ^ byte_3.GetHashCode();
	}
}
