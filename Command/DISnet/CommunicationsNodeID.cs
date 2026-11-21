using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class CommunicationsNodeID
{
	private EntityID entityID_0 = new EntityID();

	private ushort ushort_0;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(EntityID), ElementName = "entityID")]
	public EntityID EntityID
	{
		get
		{
			return entityID_0;
		}
		set
		{
			entityID_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "elementID")]
	public ushort ElementID
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

	public static bool operator !=(CommunicationsNodeID communicationsNodeID_0, CommunicationsNodeID communicationsNodeID_1)
	{
		return !(communicationsNodeID_0 == communicationsNodeID_1);
	}

	public static bool operator ==(CommunicationsNodeID communicationsNodeID_0, CommunicationsNodeID communicationsNodeID_1)
	{
		if ((object)communicationsNodeID_0 == communicationsNodeID_1)
		{
			return true;
		}
		if ((object)communicationsNodeID_0 != null && (object)communicationsNodeID_1 != null)
		{
			return communicationsNodeID_0.Equals(communicationsNodeID_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return entityID_0.GetMarshalledSize() + 2;
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
				entityID_0.Marshal(dataOutputStream_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
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
				entityID_0.Unmarshal(dataInputStream_0);
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<CommunicationsNodeID>");
		try
		{
			stringBuilder_0.AppendLine("<entityID>");
			entityID_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityID>");
			stringBuilder_0.AppendLine("<elementID type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</elementID>");
			stringBuilder_0.AppendLine("</CommunicationsNodeID>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as CommunicationsNodeID;
	}

	public bool Equals(CommunicationsNodeID communicationsNodeID_0)
	{
		bool result = true;
		if (communicationsNodeID_0.GetType() == GetType())
		{
			if (!entityID_0.Equals(communicationsNodeID_0.entityID_0))
			{
				result = false;
			}
			if (ushort_0 != communicationsNodeID_0.ushort_0)
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
		return smethod_0(smethod_0(0) ^ entityID_0.GetHashCode()) ^ ushort_0.GetHashCode();
	}
}
