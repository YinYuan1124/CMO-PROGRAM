using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EntityType))]
[XmlRoot]
public class IffDataSpecification
{
	private EntityType entityType_0 = new EntityType();

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(EntityType), ElementName = "numberOfIffDataRecords")]
	public EntityType NumberOfIffDataRecords
	{
		get
		{
			return entityType_0;
		}
		set
		{
			entityType_0 = value;
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

	public static bool operator !=(IffDataSpecification iffDataSpecification_0, IffDataSpecification iffDataSpecification_1)
	{
		return !(iffDataSpecification_0 == iffDataSpecification_1);
	}

	public static bool operator ==(IffDataSpecification iffDataSpecification_0, IffDataSpecification iffDataSpecification_1)
	{
		if ((object)iffDataSpecification_0 == iffDataSpecification_1)
		{
			return true;
		}
		if ((object)iffDataSpecification_0 != null && (object)iffDataSpecification_1 != null)
		{
			return iffDataSpecification_0.Equals(iffDataSpecification_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return entityType_0.GetMarshalledSize();
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
				entityType_0.Marshal(dataOutputStream_0);
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
				entityType_0.Unmarshal(dataInputStream_0);
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<IffDataSpecification>");
		try
		{
			stringBuilder_0.AppendLine("<numberOfIffDataRecords>");
			entityType_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</numberOfIffDataRecords>");
			stringBuilder_0.AppendLine("</IffDataSpecification>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as IffDataSpecification;
	}

	public bool Equals(IffDataSpecification iffDataSpecification_0)
	{
		bool result = true;
		if (iffDataSpecification_0.GetType() == GetType())
		{
			if (!entityType_0.Equals(iffDataSpecification_0.entityType_0))
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
		return smethod_0(0) ^ entityType_0.GetHashCode();
	}
}
