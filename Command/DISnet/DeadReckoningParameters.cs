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
[XmlInclude(typeof(Vector3Float))]
public class DeadReckoningParameters
{
	private byte byte_0;

	private byte[] byte_1 = new byte[15];

	private Vector3Float vector3Float_0 = new Vector3Float();

	private Vector3Float vector3Float_1 = new Vector3Float();

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(byte), ElementName = "deadReckoningAlgorithm")]
	public byte DeadReckoningAlgorithm
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

	[XmlArray(ElementName = "parameters")]
	public byte[] Parameters
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "entityLinearAcceleration")]
	public Vector3Float EntityLinearAcceleration
	{
		get
		{
			return vector3Float_0;
		}
		set
		{
			vector3Float_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "entityAngularVelocity")]
	public Vector3Float EntityAngularVelocity
	{
		get
		{
			return vector3Float_1;
		}
		set
		{
			vector3Float_1 = value;
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

	public static bool operator !=(DeadReckoningParameters deadReckoningParameters_0, DeadReckoningParameters deadReckoningParameters_1)
	{
		return !(deadReckoningParameters_0 == deadReckoningParameters_1);
	}

	public static bool operator ==(DeadReckoningParameters deadReckoningParameters_0, DeadReckoningParameters deadReckoningParameters_1)
	{
		if ((object)deadReckoningParameters_0 == deadReckoningParameters_1)
		{
			return true;
		}
		if ((object)deadReckoningParameters_0 != null && (object)deadReckoningParameters_1 != null)
		{
			return deadReckoningParameters_0.Equals(deadReckoningParameters_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 16 + vector3Float_0.GetMarshalledSize() + vector3Float_1.GetMarshalledSize();
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
			vector3Float_0.Marshal(dataOutputStream_0);
			vector3Float_1.Marshal(dataOutputStream_0);
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
			vector3Float_0.Unmarshal(dataInputStream_0);
			vector3Float_1.Unmarshal(dataInputStream_0);
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<DeadReckoningParameters>");
		try
		{
			stringBuilder_0.AppendLine("<deadReckoningAlgorithm type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</deadReckoningAlgorithm>");
			for (int i = 0; i < byte_1.Length; i++)
			{
				stringBuilder_0.AppendLine("<parameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + byte_1[i] + "</parameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("<entityLinearAcceleration>");
			vector3Float_0.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityLinearAcceleration>");
			stringBuilder_0.AppendLine("<entityAngularVelocity>");
			vector3Float_1.Reflection(stringBuilder_0);
			stringBuilder_0.AppendLine("</entityAngularVelocity>");
			stringBuilder_0.AppendLine("</DeadReckoningParameters>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as DeadReckoningParameters;
	}

	public bool Equals(DeadReckoningParameters deadReckoningParameters_0)
	{
		bool flag = true;
		if (deadReckoningParameters_0.GetType() == GetType())
		{
			if (byte_0 != deadReckoningParameters_0.byte_0)
			{
				flag = false;
			}
			if (deadReckoningParameters_0.byte_1.Length != 15)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < 15; i++)
				{
					if (byte_1[i] != deadReckoningParameters_0.byte_1[i])
					{
						flag = false;
					}
				}
			}
			if (!vector3Float_0.Equals(deadReckoningParameters_0.vector3Float_0))
			{
				flag = false;
			}
			if (!vector3Float_1.Equals(deadReckoningParameters_0.vector3Float_1))
			{
				flag = false;
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
		for (int i = 0; i < 15; i++)
		{
			num = smethod_0(num) ^ byte_1[i].GetHashCode();
		}
		num = smethod_0(num) ^ vector3Float_0.GetHashCode();
		return smethod_0(num) ^ vector3Float_1.GetHashCode();
	}
}
