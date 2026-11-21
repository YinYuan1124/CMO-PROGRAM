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
public class VectoringNozzleSystem
{
	private float float_0;

	private float float_1;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(float), ElementName = "horizontalDeflectionAngle")]
	public float HorizontalDeflectionAngle
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

	[XmlElement(Type = typeof(float), ElementName = "verticalDeflectionAngle")]
	public float VerticalDeflectionAngle
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

	public static bool operator !=(VectoringNozzleSystem vectoringNozzleSystem_0, VectoringNozzleSystem vectoringNozzleSystem_1)
	{
		return !(vectoringNozzleSystem_0 == vectoringNozzleSystem_1);
	}

	public static bool operator ==(VectoringNozzleSystem vectoringNozzleSystem_0, VectoringNozzleSystem vectoringNozzleSystem_1)
	{
		if ((object)vectoringNozzleSystem_0 == vectoringNozzleSystem_1)
		{
			return true;
		}
		if ((object)vectoringNozzleSystem_0 != null && (object)vectoringNozzleSystem_1 != null)
		{
			return vectoringNozzleSystem_0.Equals(vectoringNozzleSystem_1);
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
				dataOutputStream_0.WriteFloat(float_0);
				dataOutputStream_0.WriteFloat(float_1);
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
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<VectoringNozzleSystem>");
		try
		{
			stringBuilder_0.AppendLine("<horizontalDeflectionAngle type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</horizontalDeflectionAngle>");
			stringBuilder_0.AppendLine("<verticalDeflectionAngle type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</verticalDeflectionAngle>");
			stringBuilder_0.AppendLine("</VectoringNozzleSystem>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as VectoringNozzleSystem;
	}

	public bool Equals(VectoringNozzleSystem vectoringNozzleSystem_0)
	{
		bool result = true;
		if (vectoringNozzleSystem_0.GetType() == GetType())
		{
			if (float_0 != vectoringNozzleSystem_0.float_0)
			{
				result = false;
			}
			if (float_1 != vectoringNozzleSystem_0.float_1)
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
		return smethod_0(smethod_0(0) ^ float_0.GetHashCode()) ^ float_1.GetHashCode();
	}
}
