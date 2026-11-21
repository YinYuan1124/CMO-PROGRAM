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
public class VariableParameter
{
	private byte byte_0;

	private double OuqEjIkfdvc;

	private uint uint_0;

	private ushort ushort_0;

	private byte byte_1;

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

	[XmlElement(Type = typeof(double), ElementName = "variableParameterFields1")]
	public double VariableParameterFields1
	{
		get
		{
			return OuqEjIkfdvc;
		}
		set
		{
			OuqEjIkfdvc = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "variableParameterFields2")]
	public uint VariableParameterFields2
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

	[XmlElement(Type = typeof(ushort), ElementName = "variableParameterFields3")]
	public ushort VariableParameterFields3
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

	[XmlElement(Type = typeof(byte), ElementName = "variableParameterFields4")]
	public byte VariableParameterFields4
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

	public static bool operator !=(VariableParameter variableParameter_0, VariableParameter variableParameter_1)
	{
		return !(variableParameter_0 == variableParameter_1);
	}

	public static bool operator ==(VariableParameter variableParameter_0, VariableParameter variableParameter_1)
	{
		if ((object)variableParameter_0 == variableParameter_1)
		{
			return true;
		}
		if ((object)variableParameter_0 != null && (object)variableParameter_1 != null)
		{
			return variableParameter_0.Equals(variableParameter_1);
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
				dataOutputStream_0.WriteDouble(OuqEjIkfdvc);
				dataOutputStream_0.WriteUnsignedInt(uint_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
				dataOutputStream_0.WriteUnsignedByte(byte_1);
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
				OuqEjIkfdvc = dataInputStream_0.ReadDouble();
				uint_0 = dataInputStream_0.ReadUnsignedInt();
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
				byte_1 = dataInputStream_0.ReadUnsignedByte();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<VariableParameter>");
		try
		{
			stringBuilder_0.AppendLine("<recordType type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			stringBuilder_0.AppendLine("<variableParameterFields1 type=\"double\">" + OuqEjIkfdvc.ToString(CultureInfo.InvariantCulture) + "</variableParameterFields1>");
			stringBuilder_0.AppendLine("<variableParameterFields2 type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</variableParameterFields2>");
			stringBuilder_0.AppendLine("<variableParameterFields3 type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</variableParameterFields3>");
			stringBuilder_0.AppendLine("<variableParameterFields4 type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</variableParameterFields4>");
			stringBuilder_0.AppendLine("</VariableParameter>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as VariableParameter;
	}

	public bool Equals(VariableParameter variableParameter_0)
	{
		bool result = true;
		if (variableParameter_0.GetType() == GetType())
		{
			if (byte_0 != variableParameter_0.byte_0)
			{
				result = false;
			}
			if (OuqEjIkfdvc != variableParameter_0.OuqEjIkfdvc)
			{
				result = false;
			}
			if (uint_0 != variableParameter_0.uint_0)
			{
				result = false;
			}
			if (ushort_0 != variableParameter_0.ushort_0)
			{
				result = false;
			}
			if (byte_1 != variableParameter_0.byte_1)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ OuqEjIkfdvc.GetHashCode()) ^ uint_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ byte_1.GetHashCode();
	}
}
