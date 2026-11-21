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
public class VariableTransmitterParameters
{
	private uint uint_0 = 4u;

	private uint uint_1 = 4u;

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

	[XmlElement(Type = typeof(uint), ElementName = "recordLength")]
	public uint RecordLength
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

	public static bool operator !=(VariableTransmitterParameters variableTransmitterParameters_0, VariableTransmitterParameters variableTransmitterParameters_1)
	{
		return !(variableTransmitterParameters_0 == variableTransmitterParameters_1);
	}

	public static bool operator ==(VariableTransmitterParameters variableTransmitterParameters_0, VariableTransmitterParameters variableTransmitterParameters_1)
	{
		if ((object)variableTransmitterParameters_0 == variableTransmitterParameters_1)
		{
			return true;
		}
		if ((object)variableTransmitterParameters_0 != null && (object)variableTransmitterParameters_1 != null)
		{
			return variableTransmitterParameters_0.Equals(variableTransmitterParameters_1);
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
				dataOutputStream_0.WriteUnsignedInt(uint_0);
				dataOutputStream_0.WriteUnsignedInt(uint_1);
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
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<VariableTransmitterParameters>");
		try
		{
			stringBuilder_0.AppendLine("<recordType type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			stringBuilder_0.AppendLine("<recordLength type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
			stringBuilder_0.AppendLine("</VariableTransmitterParameters>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as VariableTransmitterParameters;
	}

	public bool Equals(VariableTransmitterParameters variableTransmitterParameters_0)
	{
		bool result = true;
		if (variableTransmitterParameters_0.GetType() == GetType())
		{
			if (uint_0 != variableTransmitterParameters_0.uint_0)
			{
				result = false;
			}
			if (uint_1 != variableTransmitterParameters_0.uint_1)
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
		return smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ uint_1.GetHashCode();
	}
}
