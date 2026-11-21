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
public class VariableDatum
{
	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "variableDatumID")]
	public uint VariableDatumID
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

	[XmlElement(Type = typeof(uint), ElementName = "variableDatumLength")]
	public uint VariableDatumLength
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

	[XmlElement(Type = typeof(uint), ElementName = "variableDatumBits")]
	public uint VariableDatumBits
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "padding")]
	public uint Padding
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
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

	public static bool operator !=(VariableDatum variableDatum_0, VariableDatum variableDatum_1)
	{
		return !(variableDatum_0 == variableDatum_1);
	}

	public static bool operator ==(VariableDatum variableDatum_0, VariableDatum variableDatum_1)
	{
		if ((object)variableDatum_0 == variableDatum_1)
		{
			return true;
		}
		if ((object)variableDatum_0 != null && (object)variableDatum_1 != null)
		{
			return variableDatum_0.Equals(variableDatum_1);
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
				dataOutputStream_0.WriteUnsignedInt(uint_0);
				dataOutputStream_0.WriteUnsignedInt(uint_1);
				dataOutputStream_0.WriteUnsignedInt(uint_2);
				dataOutputStream_0.WriteUnsignedInt(uint_3);
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
				uint_2 = dataInputStream_0.ReadUnsignedInt();
				uint_3 = dataInputStream_0.ReadUnsignedInt();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<VariableDatum>");
		try
		{
			stringBuilder_0.AppendLine("<variableDatumID type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</variableDatumID>");
			stringBuilder_0.AppendLine("<variableDatumLength type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</variableDatumLength>");
			stringBuilder_0.AppendLine("<variableDatumBits type=\"uint\">" + uint_2.ToString(CultureInfo.InvariantCulture) + "</variableDatumBits>");
			stringBuilder_0.AppendLine("<padding type=\"uint\">" + uint_3.ToString(CultureInfo.InvariantCulture) + "</padding>");
			stringBuilder_0.AppendLine("</VariableDatum>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as VariableDatum;
	}

	public bool Equals(VariableDatum variableDatum_0)
	{
		bool result = true;
		if (variableDatum_0.GetType() == GetType())
		{
			if (uint_0 != variableDatum_0.uint_0)
			{
				result = false;
			}
			if (uint_1 != variableDatum_0.uint_1)
			{
				result = false;
			}
			if (uint_2 != variableDatum_0.uint_2)
			{
				result = false;
			}
			if (uint_3 != variableDatum_0.uint_3)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ uint_1.GetHashCode()) ^ uint_2.GetHashCode()) ^ uint_3.GetHashCode();
	}
}
