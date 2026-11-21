using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class ChangeOptions
{
	[CompilerGenerated]
	private Action<Exception> action_0;

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

	public static bool operator !=(ChangeOptions changeOptions_0, ChangeOptions changeOptions_1)
	{
		return !(changeOptions_0 == changeOptions_1);
	}

	public static bool operator ==(ChangeOptions changeOptions_0, ChangeOptions changeOptions_1)
	{
		if ((object)changeOptions_0 == changeOptions_1)
		{
			return true;
		}
		if ((object)changeOptions_0 != null && (object)changeOptions_1 != null)
		{
			return changeOptions_0.Equals(changeOptions_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 0;
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
	}

	public virtual void Unmarshal(DataInputStream dataInputStream_0)
	{
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<ChangeOptions>");
		try
		{
			stringBuilder_0.AppendLine("</ChangeOptions>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as ChangeOptions;
	}

	public bool Equals(ChangeOptions changeOptions_0)
	{
		bool result = true;
		if (changeOptions_0.GetType() == GetType())
		{
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
		return 0;
	}
}
