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
public class Attribute
{
	private uint uint_0;

	private byte byte_0;

	private ulong ulong_0;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "recordType")]
	public uint RecordType
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

	[XmlElement(Type = typeof(byte), ElementName = "recordLength")]
	public byte RecordLength
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

	[XmlElement(Type = typeof(ulong), ElementName = "recordSpecificFields")]
	public ulong RecordSpecificFields
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

	public static bool operator !=(Attribute attribute_0, Attribute attribute_1)
	{
		return !(attribute_0 == attribute_1);
	}

	public static bool operator ==(Attribute attribute_0, Attribute attribute_1)
	{
		if ((object)attribute_0 == attribute_1)
		{
			return true;
		}
		if ((object)attribute_0 != null && (object)attribute_1 != null)
		{
			return attribute_0.Equals(attribute_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 13;
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
				dataOutputStream_0.WriteUnsignedByte(byte_0);
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
				uint_0 = dataInputStream_0.ReadUnsignedInt();
				byte_0 = dataInputStream_0.ReadUnsignedByte();
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
		stringBuilder_0.AppendLine("<Attribute>");
		try
		{
			stringBuilder_0.AppendLine("<recordType type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			stringBuilder_0.AppendLine("<recordLength type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
			stringBuilder_0.AppendLine("<recordSpecificFields type=\"ulong\">" + ulong_0.ToString(CultureInfo.InvariantCulture) + "</recordSpecificFields>");
			stringBuilder_0.AppendLine("</Attribute>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as Attribute;
	}

	public bool Equals(Attribute attribute_0)
	{
		bool result = true;
		if (attribute_0.GetType() == GetType())
		{
			if (uint_0 != attribute_0.uint_0)
			{
				result = false;
			}
			if (byte_0 != attribute_0.byte_0)
			{
				result = false;
			}
			if (ulong_0 != attribute_0.ulong_0)
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
		return smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ ulong_0.GetHashCode();
	}
}
