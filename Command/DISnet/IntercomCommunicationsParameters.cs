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
public class IntercomCommunicationsParameters
{
	private ushort ushort_0;

	private ushort ushort_1;

	private uint uint_0;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(ushort), ElementName = "recordType")]
	public ushort RecordType
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

	[XmlElement(Type = typeof(ushort), ElementName = "recordLength")]
	public ushort RecordLength
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

	[XmlElement(Type = typeof(uint), ElementName = "recordSpecificField")]
	public uint RecordSpecificField
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

	public static bool operator !=(IntercomCommunicationsParameters intercomCommunicationsParameters_0, IntercomCommunicationsParameters intercomCommunicationsParameters_1)
	{
		return !(intercomCommunicationsParameters_0 == intercomCommunicationsParameters_1);
	}

	public static bool operator ==(IntercomCommunicationsParameters intercomCommunicationsParameters_0, IntercomCommunicationsParameters intercomCommunicationsParameters_1)
	{
		if ((object)intercomCommunicationsParameters_0 == intercomCommunicationsParameters_1)
		{
			return true;
		}
		if ((object)intercomCommunicationsParameters_0 != null && (object)intercomCommunicationsParameters_1 != null)
		{
			return intercomCommunicationsParameters_0.Equals(intercomCommunicationsParameters_1);
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
				dataOutputStream_0.WriteUnsignedInt(uint_0);
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
				uint_0 = dataInputStream_0.ReadUnsignedInt();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<IntercomCommunicationsParameters>");
		try
		{
			stringBuilder_0.AppendLine("<recordType type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			stringBuilder_0.AppendLine("<recordLength type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
			stringBuilder_0.AppendLine("<recordSpecificField type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</recordSpecificField>");
			stringBuilder_0.AppendLine("</IntercomCommunicationsParameters>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as IntercomCommunicationsParameters;
	}

	public bool Equals(IntercomCommunicationsParameters intercomCommunicationsParameters_0)
	{
		bool result = true;
		if (intercomCommunicationsParameters_0.GetType() == GetType())
		{
			if (ushort_0 != intercomCommunicationsParameters_0.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != intercomCommunicationsParameters_0.ushort_1)
			{
				result = false;
			}
			if (uint_0 != intercomCommunicationsParameters_0.uint_0)
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
		return smethod_0(smethod_0(smethod_0(0) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ uint_0.GetHashCode();
	}
}
