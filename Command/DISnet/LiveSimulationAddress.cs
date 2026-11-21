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
public class LiveSimulationAddress
{
	private byte byte_0;

	private ushort ushort_0;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(byte), ElementName = "liveSiteNumber")]
	public byte LiveSiteNumber
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "liveApplicationNumber")]
	public ushort LiveApplicationNumber
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

	public static bool operator !=(LiveSimulationAddress liveSimulationAddress_0, LiveSimulationAddress liveSimulationAddress_1)
	{
		return !(liveSimulationAddress_0 == liveSimulationAddress_1);
	}

	public static bool operator ==(LiveSimulationAddress liveSimulationAddress_0, LiveSimulationAddress liveSimulationAddress_1)
	{
		if ((object)liveSimulationAddress_0 == liveSimulationAddress_1)
		{
			return true;
		}
		if ((object)liveSimulationAddress_0 != null && (object)liveSimulationAddress_1 != null)
		{
			return liveSimulationAddress_0.Equals(liveSimulationAddress_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 3;
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
				dataOutputStream_0.WriteUnsignedByte(byte_0);
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
				byte_0 = dataInputStream_0.ReadUnsignedByte();
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
		stringBuilder_0.AppendLine("<LiveSimulationAddress>");
		try
		{
			stringBuilder_0.AppendLine("<liveSiteNumber type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</liveSiteNumber>");
			stringBuilder_0.AppendLine("<liveApplicationNumber type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</liveApplicationNumber>");
			stringBuilder_0.AppendLine("</LiveSimulationAddress>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as LiveSimulationAddress;
	}

	public bool Equals(LiveSimulationAddress liveSimulationAddress_0)
	{
		bool result = true;
		if (liveSimulationAddress_0.GetType() == GetType())
		{
			if (byte_0 != liveSimulationAddress_0.byte_0)
			{
				result = false;
			}
			if (ushort_0 != liveSimulationAddress_0.ushort_0)
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
		return smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ ushort_0.GetHashCode();
	}
}
