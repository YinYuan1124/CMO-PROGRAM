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
public class EulerAngles
{
	private float float_0;

	private float float_1;

	private float float_2;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(float), ElementName = "psi")]
	public float Psi
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

	[XmlElement(Type = typeof(float), ElementName = "theta")]
	public float Theta
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

	[XmlElement(Type = typeof(float), ElementName = "phi")]
	public float Phi
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

	public static bool operator !=(EulerAngles eulerAngles_0, EulerAngles eulerAngles_1)
	{
		return !(eulerAngles_0 == eulerAngles_1);
	}

	public static bool operator ==(EulerAngles eulerAngles_0, EulerAngles eulerAngles_1)
	{
		if ((object)eulerAngles_0 == eulerAngles_1)
		{
			return true;
		}
		if ((object)eulerAngles_0 != null && (object)eulerAngles_1 != null)
		{
			return eulerAngles_0.Equals(eulerAngles_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 12;
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
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<EulerAngles>");
		try
		{
			stringBuilder_0.AppendLine("<psi type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</psi>");
			stringBuilder_0.AppendLine("<theta type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</theta>");
			stringBuilder_0.AppendLine("<phi type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</phi>");
			stringBuilder_0.AppendLine("</EulerAngles>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EulerAngles;
	}

	public bool Equals(EulerAngles eulerAngles_0)
	{
		bool result = true;
		if (eulerAngles_0.GetType() == GetType())
		{
			if (float_0 != eulerAngles_0.float_0)
			{
				result = false;
			}
			if (float_1 != eulerAngles_0.float_1)
			{
				result = false;
			}
			if (float_2 != eulerAngles_0.float_2)
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
		return smethod_0(smethod_0(smethod_0(0) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode();
	}
}
