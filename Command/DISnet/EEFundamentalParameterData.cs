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
public class EEFundamentalParameterData
{
	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(float), ElementName = "frequency")]
	public float Frequency
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "frequencyRange")]
	public float FrequencyRange
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "effectiveRadiatedPower")]
	public float EffectiveRadiatedPower
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "pulseRepetitionFrequency")]
	public float PulseRepetitionFrequency
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "pulseWidth")]
	public float PulseWidth
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
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

	public static bool operator !=(EEFundamentalParameterData eefundamentalParameterData_0, EEFundamentalParameterData eefundamentalParameterData_1)
	{
		return !(eefundamentalParameterData_0 == eefundamentalParameterData_1);
	}

	public static bool operator ==(EEFundamentalParameterData eefundamentalParameterData_0, EEFundamentalParameterData eefundamentalParameterData_1)
	{
		if ((object)eefundamentalParameterData_0 == eefundamentalParameterData_1)
		{
			return true;
		}
		if ((object)eefundamentalParameterData_0 != null && (object)eefundamentalParameterData_1 != null)
		{
			return eefundamentalParameterData_0.Equals(eefundamentalParameterData_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 20;
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
				dataOutputStream_0.WriteFloat(float_0);
				dataOutputStream_0.WriteFloat(float_1);
				dataOutputStream_0.WriteFloat(float_2);
				dataOutputStream_0.WriteFloat(float_3);
				dataOutputStream_0.WriteFloat(float_4);
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
				float_0 = dataInputStream_0.ReadFloat();
				float_1 = dataInputStream_0.ReadFloat();
				float_2 = dataInputStream_0.ReadFloat();
				float_3 = dataInputStream_0.ReadFloat();
				float_4 = dataInputStream_0.ReadFloat();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<EEFundamentalParameterData>");
		try
		{
			stringBuilder_0.AppendLine("<frequency type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</frequency>");
			stringBuilder_0.AppendLine("<frequencyRange type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</frequencyRange>");
			stringBuilder_0.AppendLine("<effectiveRadiatedPower type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</effectiveRadiatedPower>");
			stringBuilder_0.AppendLine("<pulseRepetitionFrequency type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</pulseRepetitionFrequency>");
			stringBuilder_0.AppendLine("<pulseWidth type=\"float\">" + float_4.ToString(CultureInfo.InvariantCulture) + "</pulseWidth>");
			stringBuilder_0.AppendLine("</EEFundamentalParameterData>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EEFundamentalParameterData;
	}

	public bool Equals(EEFundamentalParameterData eefundamentalParameterData_0)
	{
		bool result = true;
		if (eefundamentalParameterData_0.GetType() == GetType())
		{
			if (float_0 != eefundamentalParameterData_0.float_0)
			{
				result = false;
			}
			if (float_1 != eefundamentalParameterData_0.float_1)
			{
				result = false;
			}
			if (float_2 != eefundamentalParameterData_0.float_2)
			{
				result = false;
			}
			if (float_3 != eefundamentalParameterData_0.float_3)
			{
				result = false;
			}
			if (float_4 != eefundamentalParameterData_0.float_4)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode()) ^ float_3.GetHashCode()) ^ float_4.GetHashCode();
	}
}
