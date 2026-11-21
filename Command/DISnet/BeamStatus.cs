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
public class BeamStatus
{
	private byte byte_0;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(byte), ElementName = "beamState")]
	public byte BeamState
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

	public static bool operator !=(BeamStatus beamStatus_0, BeamStatus beamStatus_1)
	{
		return !(beamStatus_0 == beamStatus_1);
	}

	public static bool operator ==(BeamStatus beamStatus_0, BeamStatus beamStatus_1)
	{
		if ((object)beamStatus_0 == beamStatus_1)
		{
			return true;
		}
		if ((object)beamStatus_0 != null && (object)beamStatus_1 != null)
		{
			return beamStatus_0.Equals(beamStatus_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 1;
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
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<BeamStatus>");
		try
		{
			stringBuilder_0.AppendLine("<beamState type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</beamState>");
			stringBuilder_0.AppendLine("</BeamStatus>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as BeamStatus;
	}

	public bool Equals(BeamStatus beamStatus_0)
	{
		bool result = true;
		if (beamStatus_0.GetType() == GetType())
		{
			if (byte_0 != beamStatus_0.byte_0)
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
		return smethod_0(0) ^ byte_0.GetHashCode();
	}
}
