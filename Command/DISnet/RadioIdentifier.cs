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
public class RadioIdentifier
{
	private ushort ushort_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(ushort), ElementName = "siteNumber")]
	public ushort SiteNumber
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

	[XmlElement(Type = typeof(ushort), ElementName = "applicationNumber")]
	public ushort ApplicationNumber
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

	[XmlElement(Type = typeof(ushort), ElementName = "referenceNumber")]
	public ushort ReferenceNumber
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

	[XmlElement(Type = typeof(ushort), ElementName = "radioNumber")]
	public ushort RadioNumber
	{
		get
		{
			return ushort_3;
		}
		set
		{
			ushort_3 = value;
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

	public static bool operator !=(RadioIdentifier radioIdentifier_0, RadioIdentifier radioIdentifier_1)
	{
		return !(radioIdentifier_0 == radioIdentifier_1);
	}

	public static bool operator ==(RadioIdentifier radioIdentifier_0, RadioIdentifier radioIdentifier_1)
	{
		if ((object)radioIdentifier_0 == radioIdentifier_1)
		{
			return true;
		}
		if ((object)radioIdentifier_0 != null && (object)radioIdentifier_1 != null)
		{
			return radioIdentifier_0.Equals(radioIdentifier_1);
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
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
				dataOutputStream_0.WriteUnsignedShort(ushort_2);
				dataOutputStream_0.WriteUnsignedShort(ushort_3);
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
				ushort_3 = dataInputStream_0.ReadUnsignedShort();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<RadioIdentifier>");
		try
		{
			stringBuilder_0.AppendLine("<siteNumber type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</siteNumber>");
			stringBuilder_0.AppendLine("<applicationNumber type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</applicationNumber>");
			stringBuilder_0.AppendLine("<referenceNumber type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</referenceNumber>");
			stringBuilder_0.AppendLine("<radioNumber type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</radioNumber>");
			stringBuilder_0.AppendLine("</RadioIdentifier>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as RadioIdentifier;
	}

	public bool Equals(RadioIdentifier radioIdentifier_0)
	{
		bool result = true;
		if (radioIdentifier_0.GetType() == GetType())
		{
			if (ushort_0 != radioIdentifier_0.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != radioIdentifier_0.ushort_1)
			{
				result = false;
			}
			if (ushort_2 != radioIdentifier_0.ushort_2)
			{
				result = false;
			}
			if (ushort_3 != radioIdentifier_0.ushort_3)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(0) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ ushort_2.GetHashCode()) ^ ushort_3.GetHashCode();
	}
}
