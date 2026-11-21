using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class RecordSpecificationElement
{
	private uint uint_0;

	private uint uint_1;

	private ushort ushort_0;

	private ushort HkgEavsfUsR;

	private ushort ushort_1;

	private byte byte_0;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "recordID")]
	public uint RecordID
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

	[XmlElement(Type = typeof(uint), ElementName = "recordSetSerialNumber")]
	public uint RecordSetSerialNumber
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

	[XmlElement(Type = typeof(ushort), ElementName = "recordLength")]
	public ushort RecordLength
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

	[XmlElement(Type = typeof(ushort), ElementName = "recordCount")]
	public ushort RecordCount
	{
		get
		{
			return HkgEavsfUsR;
		}
		set
		{
			HkgEavsfUsR = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "recordValues")]
	public ushort RecordValues
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

	[XmlElement(Type = typeof(byte), ElementName = "pad4")]
	public byte Pad4
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

	public event Action<Exception> Exception
	{
		[CompilerGenerated]
		add
		{
			Action<Exception> action = action_0;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<Exception> action = action_0;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static bool operator !=(RecordSpecificationElement recordSpecificationElement_0, RecordSpecificationElement recordSpecificationElement_1)
	{
		return !(recordSpecificationElement_0 == recordSpecificationElement_1);
	}

	public static bool operator ==(RecordSpecificationElement recordSpecificationElement_0, RecordSpecificationElement recordSpecificationElement_1)
	{
		if ((object)recordSpecificationElement_0 == recordSpecificationElement_1)
		{
			return true;
		}
		if ((object)recordSpecificationElement_0 != null && (object)recordSpecificationElement_1 != null)
		{
			return recordSpecificationElement_0.Equals(recordSpecificationElement_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 15;
	}

	protected void OnException(Exception exception_0)
	{
		if (action_0 != null)
		{
			action_0(exception_0);
		}
	}

	public virtual void Marshal(DataOutputStream dataOutputStream_0)
	{
		if (dataOutputStream_0 != null)
		{
			try
			{
				dataOutputStream_0.WriteUnsignedInt(uint_0);
				dataOutputStream_0.WriteUnsignedInt(uint_1);
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
				dataOutputStream_0.WriteUnsignedShort(HkgEavsfUsR);
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
				dataOutputStream_0.WriteUnsignedByte(byte_0);
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Unmarshal(DataInputStream dataInputStream_0)
	{
		if (dataInputStream_0 != null)
		{
			try
			{
				uint_0 = dataInputStream_0.ReadUnsignedInt();
				uint_1 = dataInputStream_0.ReadUnsignedInt();
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
				HkgEavsfUsR = dataInputStream_0.ReadUnsignedShort();
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
				byte_0 = dataInputStream_0.ReadUnsignedByte();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<RecordSpecificationElement>");
		try
		{
			stringBuilder_0.AppendLine("<recordID type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</recordID>");
			stringBuilder_0.AppendLine("<recordSetSerialNumber type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</recordSetSerialNumber>");
			stringBuilder_0.AppendLine("<recordLength type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
			stringBuilder_0.AppendLine("<recordCount type=\"ushort\">" + HkgEavsfUsR.ToString(CultureInfo.InvariantCulture) + "</recordCount>");
			stringBuilder_0.AppendLine("<recordValues type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</recordValues>");
			stringBuilder_0.AppendLine("<pad4 type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</pad4>");
			stringBuilder_0.AppendLine("</RecordSpecificationElement>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as RecordSpecificationElement;
	}

	public bool Equals(RecordSpecificationElement recordSpecificationElement_0)
	{
		bool result = true;
		if (recordSpecificationElement_0.GetType() == GetType())
		{
			if (uint_0 != recordSpecificationElement_0.uint_0)
			{
				result = false;
			}
			if (uint_1 != recordSpecificationElement_0.uint_1)
			{
				result = false;
			}
			if (ushort_0 != recordSpecificationElement_0.ushort_0)
			{
				result = false;
			}
			if (HkgEavsfUsR != recordSpecificationElement_0.HkgEavsfUsR)
			{
				result = false;
			}
			if (ushort_1 != recordSpecificationElement_0.ushort_1)
			{
				result = false;
			}
			if (byte_0 != recordSpecificationElement_0.byte_0)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ uint_1.GetHashCode()) ^ ushort_0.GetHashCode()) ^ HkgEavsfUsR.GetHashCode()) ^ ushort_1.GetHashCode()) ^ byte_0.GetHashCode();
	}
}
