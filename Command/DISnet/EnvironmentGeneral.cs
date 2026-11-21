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
public class EnvironmentGeneral
{
	private uint uint_0;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	private byte byte_4;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "environmentType")]
	public uint EnvironmentType
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

	[XmlElement(Type = typeof(byte), ElementName = "length")]
	public byte Length
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

	[XmlElement(Type = typeof(byte), ElementName = "index")]
	public byte Index
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

	[XmlElement(Type = typeof(byte), ElementName = "padding1")]
	public byte Padding1
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

	[XmlElement(Type = typeof(byte), ElementName = "geometry")]
	public byte Geometry
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

	[XmlElement(Type = typeof(byte), ElementName = "padding2")]
	public byte Padding2
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

	public static bool operator !=(EnvironmentGeneral environmentGeneral_0, EnvironmentGeneral environmentGeneral_1)
	{
		return !(environmentGeneral_0 == environmentGeneral_1);
	}

	public static bool operator ==(EnvironmentGeneral environmentGeneral_0, EnvironmentGeneral environmentGeneral_1)
	{
		if ((object)environmentGeneral_0 == environmentGeneral_1)
		{
			return true;
		}
		if ((object)environmentGeneral_0 != null && (object)environmentGeneral_1 != null)
		{
			return environmentGeneral_0.Equals(environmentGeneral_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 9;
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
				dataOutputStream_0.WriteUnsignedByte(byte_1);
				dataOutputStream_0.WriteUnsignedByte(byte_2);
				dataOutputStream_0.WriteUnsignedByte(byte_3);
				dataOutputStream_0.WriteUnsignedByte(byte_4);
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
				byte_1 = dataInputStream_0.ReadUnsignedByte();
				byte_2 = dataInputStream_0.ReadUnsignedByte();
				byte_3 = dataInputStream_0.ReadUnsignedByte();
				byte_4 = dataInputStream_0.ReadUnsignedByte();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<EnvironmentGeneral>");
		try
		{
			stringBuilder_0.AppendLine("<environmentType type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</environmentType>");
			stringBuilder_0.AppendLine("<length type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</length>");
			stringBuilder_0.AppendLine("<index type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</index>");
			stringBuilder_0.AppendLine("<padding1 type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			stringBuilder_0.AppendLine("<geometry type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</geometry>");
			stringBuilder_0.AppendLine("<padding2 type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			stringBuilder_0.AppendLine("</EnvironmentGeneral>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EnvironmentGeneral;
	}

	public bool Equals(EnvironmentGeneral environmentGeneral_0)
	{
		bool result = true;
		if (environmentGeneral_0.GetType() == GetType())
		{
			if (uint_0 != environmentGeneral_0.uint_0)
			{
				result = false;
			}
			if (byte_0 != environmentGeneral_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != environmentGeneral_0.byte_1)
			{
				result = false;
			}
			if (byte_2 != environmentGeneral_0.byte_2)
			{
				result = false;
			}
			if (byte_3 != environmentGeneral_0.byte_3)
			{
				result = false;
			}
			if (byte_4 != environmentGeneral_0.byte_4)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ byte_3.GetHashCode()) ^ byte_4.GetHashCode();
	}
}
