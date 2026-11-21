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
[XmlInclude(typeof(ChangeOptions))]
public class SystemIdentifier
{
	private ushort ushort_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private ChangeOptions changeOptions_0 = new ChangeOptions();

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(ushort), ElementName = "systemType")]
	public ushort SystemType
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

	[XmlElement(Type = typeof(ushort), ElementName = "systemName")]
	public ushort SystemName
	{
		get
		{
			return ushort_1;
		}
		set
		{
			ushort_1 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "systemMode")]
	public ushort SystemMode
	{
		get
		{
			return ushort_2;
		}
		set
		{
			ushort_2 = value;
		}
	}

	[XmlElement(Type = typeof(ChangeOptions), ElementName = "changeOptions")]
	public ChangeOptions ChangeOptions
	{
		get
		{
			return changeOptions_0;
		}
		set
		{
			changeOptions_0 = value;
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

	public static bool operator !=(SystemIdentifier systemIdentifier_0, SystemIdentifier systemIdentifier_1)
	{
		return !(systemIdentifier_0 == systemIdentifier_1);
	}

	public static bool operator ==(SystemIdentifier systemIdentifier_0, SystemIdentifier systemIdentifier_1)
	{
		if ((object)systemIdentifier_0 == systemIdentifier_1)
		{
			return true;
		}
		if ((object)systemIdentifier_0 != null && (object)systemIdentifier_1 != null)
		{
			return systemIdentifier_0.Equals(systemIdentifier_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 6 + changeOptions_0.GetMarshalledSize();
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
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
				dataOutputStream_0.WriteUnsignedShort(ushort_2);
				changeOptions_0.Marshal(dataOutputStream_0);
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
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
				ushort_2 = dataInputStream_0.ReadUnsignedShort();
				changeOptions_0.Unmarshal(dataInputStream_0);
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<SystemIdentifier>");
		try
		{
			stringBuilder_0.AppendLine("<systemType type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</systemType>");
			stringBuilder_0.AppendLine("<systemName type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</systemName>");
			stringBuilder_0.AppendLine("<systemMode type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</systemMode>");
			stringBuilder_0.AppendLine("<changeOptions>");
			changeOptions_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</changeOptions>");
			stringBuilder_0.AppendLine("</SystemIdentifier>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as SystemIdentifier;
	}

	public bool Equals(SystemIdentifier systemIdentifier_0)
	{
		bool result = true;
		if (systemIdentifier_0.GetType() == GetType())
		{
			if (ushort_0 != systemIdentifier_0.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != systemIdentifier_0.ushort_1)
			{
				result = false;
			}
			if (ushort_2 != systemIdentifier_0.ushort_2)
			{
				result = false;
			}
			if (!changeOptions_0.Equals(systemIdentifier_0.changeOptions_0))
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
		return smethod_0(smethod_0(smethod_0(smethod_0(0) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ ushort_2.GetHashCode()) ^ changeOptions_0.GetHashCode();
	}
}
