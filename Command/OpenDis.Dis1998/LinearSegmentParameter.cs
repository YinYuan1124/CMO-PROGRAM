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
[XmlInclude(typeof(Orientation))]
[XmlInclude(typeof(Vector3Double))]
[XmlRoot]
[XmlInclude(typeof(SixByteChunk))]
public class LinearSegmentParameter
{
	private byte byte_0;

	private SixByteChunk sixByteChunk_0 = new SixByteChunk();

	private Vector3Double vector3Double_0 = new Vector3Double();

	private Orientation orientation_0 = new Orientation();

	private ushort ushort_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private uint uint_0;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(byte), ElementName = "segmentNumber")]
	public byte SegmentNumber
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

	[XmlElement(Type = typeof(SixByteChunk), ElementName = "segmentAppearance")]
	public SixByteChunk SegmentAppearance
	{
		get
		{
			return sixByteChunk_0;
		}
		set
		{
			sixByteChunk_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Double), ElementName = "location")]
	public Vector3Double Location
	{
		get
		{
			return vector3Double_0;
		}
		set
		{
			vector3Double_0 = value;
		}
	}

	[XmlElement(Type = typeof(Orientation), ElementName = "orientation")]
	public Orientation Orientation
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

	[XmlElement(Type = typeof(ushort), ElementName = "segmentLength")]
	public ushort SegmentLength
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

	[XmlElement(Type = typeof(ushort), ElementName = "segmentWidth")]
	public ushort SegmentWidth
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

	[XmlElement(Type = typeof(ushort), ElementName = "segmentHeight")]
	public ushort SegmentHeight
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

	[XmlElement(Type = typeof(ushort), ElementName = "segmentDepth")]
	public ushort SegmentDepth
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

	[XmlElement(Type = typeof(uint), ElementName = "pad1")]
	public uint Pad1
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

	public static bool operator !=(LinearSegmentParameter linearSegmentParameter_0, LinearSegmentParameter linearSegmentParameter_1)
	{
		return !(linearSegmentParameter_0 == linearSegmentParameter_1);
	}

	public static bool operator ==(LinearSegmentParameter linearSegmentParameter_0, LinearSegmentParameter linearSegmentParameter_1)
	{
		if ((object)linearSegmentParameter_0 == linearSegmentParameter_1)
		{
			return true;
		}
		if ((object)linearSegmentParameter_0 != null && (object)linearSegmentParameter_1 != null)
		{
			return linearSegmentParameter_0.Equals(linearSegmentParameter_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 1 + sixByteChunk_0.GetMarshalledSize() + vector3Double_0.GetMarshalledSize() + orientation_0.GetMarshalledSize() + 2 + 2 + 2 + 2 + 4;
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
			sixByteChunk_0.Marshal(dataOutputStream_0);
			vector3Double_0.Marshal(dataOutputStream_0);
			orientation_0.Marshal(dataOutputStream_0);
			dataOutputStream_0.WriteUnsignedShort(ushort_0);
			dataOutputStream_0.WriteUnsignedShort(ushort_1);
			dataOutputStream_0.WriteUnsignedShort(ushort_2);
			dataOutputStream_0.WriteUnsignedShort(ushort_3);
			dataOutputStream_0.WriteUnsignedInt(uint_0);
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
			sixByteChunk_0.Unmarshal(dataInputStream_0);
			vector3Double_0.Unmarshal(dataInputStream_0);
			orientation_0.Unmarshal(dataInputStream_0);
			ushort_0 = dataInputStream_0.ReadUnsignedShort();
			ushort_1 = dataInputStream_0.ReadUnsignedShort();
			ushort_2 = dataInputStream_0.ReadUnsignedShort();
			ushort_3 = dataInputStream_0.ReadUnsignedShort();
			uint_0 = dataInputStream_0.ReadUnsignedInt();
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
		stringBuilder_0.AppendLine("<LinearSegmentParameter>");
		try
		{
			stringBuilder_0.AppendLine("<segmentNumber type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</segmentNumber>");
			stringBuilder_0.AppendLine("<segmentAppearance>");
			sixByteChunk_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</segmentAppearance>");
			stringBuilder_0.AppendLine("<location>");
			vector3Double_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</location>");
			stringBuilder_0.AppendLine("<orientation>");
			orientation_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</orientation>");
			stringBuilder_0.AppendLine("<segmentLength type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</segmentLength>");
			stringBuilder_0.AppendLine("<segmentWidth type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</segmentWidth>");
			stringBuilder_0.AppendLine("<segmentHeight type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</segmentHeight>");
			stringBuilder_0.AppendLine("<segmentDepth type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</segmentDepth>");
			stringBuilder_0.AppendLine("<pad1 type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</pad1>");
			stringBuilder_0.AppendLine("</LinearSegmentParameter>");
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
		return this == obj as LinearSegmentParameter;
	}

	public bool Equals(LinearSegmentParameter linearSegmentParameter_0)
	{
		bool result = true;
		if (linearSegmentParameter_0.GetType() == GetType())
		{
			if (byte_0 != linearSegmentParameter_0.byte_0)
			{
				result = false;
			}
			if (!sixByteChunk_0.Equals(linearSegmentParameter_0.sixByteChunk_0))
			{
				result = false;
			}
			if (!vector3Double_0.Equals(linearSegmentParameter_0.vector3Double_0))
			{
				result = false;
			}
			if (!orientation_0.Equals(linearSegmentParameter_0.orientation_0))
			{
				result = false;
			}
			if (ushort_0 != linearSegmentParameter_0.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != linearSegmentParameter_0.ushort_1)
			{
				result = false;
			}
			if (ushort_2 != linearSegmentParameter_0.ushort_2)
			{
				result = false;
			}
			if (ushort_3 != linearSegmentParameter_0.ushort_3)
			{
				result = false;
			}
			if (uint_0 != linearSegmentParameter_0.uint_0)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ sixByteChunk_0.GetHashCode()) ^ vector3Double_0.GetHashCode()) ^ orientation_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ ushort_2.GetHashCode()) ^ ushort_3.GetHashCode()) ^ uint_0.GetHashCode();
	}
}
