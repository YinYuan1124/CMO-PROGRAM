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
public class AggregateMarking
{
	private byte byte_0;

	private byte[] byte_1 = new byte[31];

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(byte), ElementName = "characterSet")]
	public byte CharacterSet
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

	[XmlArray(ElementName = "characters")]
	public byte[] Characters
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
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

	public static bool operator !=(AggregateMarking aggregateMarking_0, AggregateMarking aggregateMarking_1)
	{
		return !(aggregateMarking_0 == aggregateMarking_1);
	}

	public static bool operator ==(AggregateMarking aggregateMarking_0, AggregateMarking aggregateMarking_1)
	{
		if ((object)aggregateMarking_0 == aggregateMarking_1)
		{
			return true;
		}
		if ((object)aggregateMarking_0 != null && (object)aggregateMarking_1 != null)
		{
			return aggregateMarking_0.Equals(aggregateMarking_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 32;
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
			dataOutputStream_0.WriteUnsignedByte(byte_0);
			for (int i = 0; i < byte_1.Length; i++)
			{
				dataOutputStream_0.WriteUnsignedByte(byte_1[i]);
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
			byte_0 = dataInputStream_0.ReadUnsignedByte();
			for (int i = 0; i < byte_1.Length; i++)
			{
				byte_1[i] = dataInputStream_0.ReadUnsignedByte();
			}
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<AggregateMarking>");
		try
		{
			stringBuilder_0.AppendLine("<characterSet type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</characterSet>");
			for (int i = 0; i < byte_1.Length; i++)
			{
				stringBuilder_0.AppendLine("<characters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + byte_1[i] + "</characters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</AggregateMarking>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as AggregateMarking;
	}

	public bool Equals(AggregateMarking aggregateMarking_0)
	{
		bool flag = true;
		if (aggregateMarking_0.GetType() == GetType())
		{
			if (byte_0 != aggregateMarking_0.byte_0)
			{
				flag = false;
			}
			if (aggregateMarking_0.byte_1.Length != 31)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < 31; i++)
				{
					if (byte_1[i] != aggregateMarking_0.byte_1[i])
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
		num = smethod_0(0) ^ byte_0.GetHashCode();
		for (int i = 0; i < 31; i++)
		{
			num = smethod_0(num) ^ byte_1[i].GetHashCode();
		}
		return num;
	}
}
