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
public class AttachedParts
{
	private byte byte_0 = 1;

	private byte byte_1;

	private ushort ushort_0;

	private uint uint_0;

	private ulong ulong_0;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(byte), ElementName = "recordType")]
	public byte RecordType
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

	[XmlElement(Type = typeof(byte), ElementName = "detachedIndicator")]
	public byte DetachedIndicator
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

	[XmlElement(Type = typeof(uint), ElementName = "parameterType")]
	public uint ParameterType
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

	[XmlElement(Type = typeof(ulong), ElementName = "parameterValue")]
	public ulong ParameterValue
	{
		get
		{
			return ulong_0;
		}
		set
		{
			ulong_0 = value;
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

	public static bool operator !=(AttachedParts attachedParts_0, AttachedParts attachedParts_1)
	{
		return !(attachedParts_0 == attachedParts_1);
	}

	public static bool operator ==(AttachedParts attachedParts_0, AttachedParts attachedParts_1)
	{
		if ((object)attachedParts_0 == attachedParts_1)
		{
			return true;
		}
		if ((object)attachedParts_0 != null && (object)attachedParts_1 != null)
		{
			return attachedParts_0.Equals(attachedParts_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 16;
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
				dataOutputStream_0.WriteUnsignedByte(byte_0);
				dataOutputStream_0.WriteUnsignedByte(byte_1);
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
				dataOutputStream_0.WriteUnsignedInt(uint_0);
				dataOutputStream_0.WriteUnsignedLong(ulong_0);
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
				byte_0 = dataInputStream_0.ReadUnsignedByte();
				byte_1 = dataInputStream_0.ReadUnsignedByte();
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
				uint_0 = dataInputStream_0.ReadUnsignedInt();
				ulong_0 = dataInputStream_0.ReadUnsignedLong();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<AttachedParts>");
		try
		{
			stringBuilder_0.AppendLine("<recordType type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			stringBuilder_0.AppendLine("<detachedIndicator type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</detachedIndicator>");
			stringBuilder_0.AppendLine("<partAttachedTo type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</partAttachedTo>");
			stringBuilder_0.AppendLine("<parameterType type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</parameterType>");
			stringBuilder_0.AppendLine("<parameterValue type=\"ulong\">" + ulong_0.ToString(CultureInfo.InvariantCulture) + "</parameterValue>");
			stringBuilder_0.AppendLine("</AttachedParts>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as AttachedParts;
	}

	public bool Equals(AttachedParts attachedParts_0)
	{
		bool result = true;
		if (attachedParts_0.GetType() == GetType())
		{
			if (byte_0 != attachedParts_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != attachedParts_0.byte_1)
			{
				result = false;
			}
			if (ushort_0 != attachedParts_0.ushort_0)
			{
				result = false;
			}
			if (uint_0 != attachedParts_0.uint_0)
			{
				result = false;
			}
			if (ulong_0 != attachedParts_0.ulong_0)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ ushort_0.GetHashCode()) ^ uint_0.GetHashCode()) ^ ulong_0.GetHashCode();
	}
}
