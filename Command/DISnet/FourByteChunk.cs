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
public class FourByteChunk
{
	private byte[] byte_0 = new byte[4];

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlArray(ElementName = "otherParameters")]
	public byte[] OtherParameters
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

	public static bool operator !=(FourByteChunk fourByteChunk_0, FourByteChunk fourByteChunk_1)
	{
		return !(fourByteChunk_0 == fourByteChunk_1);
	}

	public static bool operator ==(FourByteChunk fourByteChunk_0, FourByteChunk fourByteChunk_1)
	{
		if ((object)fourByteChunk_0 == fourByteChunk_1)
		{
			return true;
		}
		if ((object)fourByteChunk_0 != null && (object)fourByteChunk_1 != null)
		{
			return fourByteChunk_0.Equals(fourByteChunk_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 4;
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
		if (dataOutputStream_0 == null)
		{
			return;
		}
		try
		{
			for (int i = 0; i < byte_0.Length; i++)
			{
				dataOutputStream_0.WriteByte(byte_0[i]);
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public virtual void Unmarshal(DataInputStream dataInputStream_0)
	{
		if (dataInputStream_0 == null)
		{
			return;
		}
		try
		{
			for (int i = 0; i < byte_0.Length; i++)
			{
				byte_0[i] = dataInputStream_0.ReadByte();
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<FourByteChunk>");
		try
		{
			for (int i = 0; i < byte_0.Length; i++)
			{
				stringBuilder_0.AppendLine("<otherParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + byte_0[i] + "</otherParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</FourByteChunk>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as FourByteChunk;
	}

	public bool Equals(FourByteChunk fourByteChunk_0)
	{
		bool flag = true;
		if (fourByteChunk_0.GetType() == GetType())
		{
			if (fourByteChunk_0.byte_0.Length != 4)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < 4; i++)
				{
					if (byte_0[i] != fourByteChunk_0.byte_0[i])
					{
						flag = false;
					}
				}
			}
			return flag;
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
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			num = smethod_0(num) ^ byte_0[i].GetHashCode();
		}
		return num;
	}
}
