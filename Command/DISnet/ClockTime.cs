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
public class ClockTime
{
	private uint uint_0;

	private uint uint_1;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "hour")]
	public uint Hour
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

	[XmlElement(Type = typeof(uint), ElementName = "timePastHour")]
	public uint TimePastHour
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

	public static bool operator !=(ClockTime clockTime_0, ClockTime clockTime_1)
	{
		return !(clockTime_0 == clockTime_1);
	}

	public static bool operator ==(ClockTime clockTime_0, ClockTime clockTime_1)
	{
		if ((object)clockTime_0 == clockTime_1)
		{
			return true;
		}
		if ((object)clockTime_0 != null && (object)clockTime_1 != null)
		{
			return clockTime_0.Equals(clockTime_1);
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
		stringBuilder_0.AppendLine("<ClockTime>");
		try
		{
			stringBuilder_0.AppendLine("<hour type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</hour>");
			stringBuilder_0.AppendLine("<timePastHour type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</timePastHour>");
			stringBuilder_0.AppendLine("</ClockTime>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as ClockTime;
	}

	public bool Equals(ClockTime clockTime_0)
	{
		bool result = true;
		if (clockTime_0.GetType() == GetType())
		{
			if (uint_0 != clockTime_0.uint_0)
			{
				result = false;
			}
			if (uint_1 != clockTime_0.uint_1)
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
