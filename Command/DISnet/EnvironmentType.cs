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
public class EnvironmentType
{
	private byte byte_0;

	private byte byte_1;

	private ushort ushort_0;

	private byte byte_2;

	private byte byte_3;

	private byte byte_4;

	private byte byte_5;

	[CompilerGenerated]
	private Action<Exception> action_0;

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

	[XmlElement(Type = typeof(ushort), ElementName = "entityClass")]
	public ushort EntityClass
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

	[XmlElement(Type = typeof(byte), ElementName = "specific")]
	public byte Specific
	{
		get
		{
			return byte_4;
		}
		set
		{
			byte_4 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "extra")]
	public byte Extra
	{
		get
		{
			return byte_5;
		}
		set
		{
			byte_5 = value;
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

	public static bool operator !=(EnvironmentType environmentType_0, EnvironmentType environmentType_1)
	{
		return !(environmentType_0 == environmentType_1);
	}

	public static bool operator ==(EnvironmentType environmentType_0, EnvironmentType environmentType_1)
	{
		if ((object)environmentType_0 == environmentType_1)
		{
			return true;
		}
		if ((object)environmentType_0 != null && (object)environmentType_1 != null)
		{
			return environmentType_0.Equals(environmentType_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 8;
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
				dataOutputStream_0.WriteUnsignedByte(byte_2);
				dataOutputStream_0.WriteUnsignedByte(byte_3);
				dataOutputStream_0.WriteUnsignedByte(byte_4);
				dataOutputStream_0.WriteUnsignedByte(byte_5);
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
				byte_2 = dataInputStream_0.ReadUnsignedByte();
				byte_3 = dataInputStream_0.ReadUnsignedByte();
				byte_4 = dataInputStream_0.ReadUnsignedByte();
				byte_5 = dataInputStream_0.ReadUnsignedByte();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<EnvironmentType>");
		try
		{
			stringBuilder_0.AppendLine("<entityKind type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</entityKind>");
			stringBuilder_0.AppendLine("<domain type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</domain>");
			stringBuilder_0.AppendLine("<entityClass type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</entityClass>");
			stringBuilder_0.AppendLine("<category type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</category>");
			stringBuilder_0.AppendLine("<subcategory type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</subcategory>");
			stringBuilder_0.AppendLine("<specific type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</specific>");
			stringBuilder_0.AppendLine("<extra type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</extra>");
			stringBuilder_0.AppendLine("</EnvironmentType>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EnvironmentType;
	}

	public bool Equals(EnvironmentType environmentType_0)
	{
		bool result = true;
		if (environmentType_0.GetType() == GetType())
		{
			if (byte_0 != environmentType_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != environmentType_0.byte_1)
			{
				result = false;
			}
			if (ushort_0 != environmentType_0.ushort_0)
			{
				result = false;
			}
			if (byte_2 != environmentType_0.byte_2)
			{
				result = false;
			}
			if (byte_3 != environmentType_0.byte_3)
			{
				result = false;
			}
			if (byte_4 != environmentType_0.byte_4)
			{
				result = false;
			}
			if (byte_5 != environmentType_0.byte_5)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ ushort_0.GetHashCode()) ^ byte_2.GetHashCode()) ^ byte_3.GetHashCode()) ^ byte_4.GetHashCode()) ^ byte_5.GetHashCode();
	}
}
