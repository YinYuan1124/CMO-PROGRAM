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
public class Vector3Double
{
	private double double_0;

	private double double_1;

	private double double_2;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(double), ElementName = "x")]
	public double X
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	[XmlElement(Type = typeof(double), ElementName = "y")]
	public double Y
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	[XmlElement(Type = typeof(double), ElementName = "z")]
	public double Z
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
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

	public static bool operator !=(Vector3Double vector3Double_0, Vector3Double vector3Double_1)
	{
		return !(vector3Double_0 == vector3Double_1);
	}

	public static bool operator ==(Vector3Double vector3Double_0, Vector3Double vector3Double_1)
	{
		if ((object)vector3Double_0 == vector3Double_1)
		{
			return true;
		}
		if ((object)vector3Double_0 != null && (object)vector3Double_1 != null)
		{
			return vector3Double_0.Equals(vector3Double_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 24;
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
				dataOutputStream_0.WriteDouble(double_0);
				dataOutputStream_0.WriteDouble(double_1);
				dataOutputStream_0.WriteDouble(double_2);
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
				double_0 = dataInputStream_0.ReadDouble();
				double_1 = dataInputStream_0.ReadDouble();
				double_2 = dataInputStream_0.ReadDouble();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<Vector3Double>");
		try
		{
			stringBuilder_0.AppendLine("<x type=\"double\">" + double_0.ToString(CultureInfo.InvariantCulture) + "</x>");
			stringBuilder_0.AppendLine("<y type=\"double\">" + double_1.ToString(CultureInfo.InvariantCulture) + "</y>");
			stringBuilder_0.AppendLine("<z type=\"double\">" + double_2.ToString(CultureInfo.InvariantCulture) + "</z>");
			stringBuilder_0.AppendLine("</Vector3Double>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as Vector3Double;
	}

	public bool Equals(Vector3Double vector3Double_0)
	{
		bool result = true;
		if (vector3Double_0.GetType() == GetType())
		{
			if (double_0 != vector3Double_0.double_0)
			{
				result = false;
			}
			if (double_1 != vector3Double_0.double_1)
			{
				result = false;
			}
			if (double_2 != vector3Double_0.double_2)
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
		return smethod_0(smethod_0(smethod_0(0) ^ double_0.GetHashCode()) ^ double_1.GetHashCode()) ^ double_2.GetHashCode();
	}
}
