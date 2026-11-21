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
public class IFFFundamentalParameterData
{
	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private uint uint_0;

	private byte byte_0;

	private byte[] byte_1 = new byte[3];

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(float), ElementName = "erp")]
	public float Erp
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "frequency")]
	public float Frequency
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "pgrf")]
	public float Pgrf
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "pulseWidth")]
	public float PulseWidth
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "burstLength")]
	public uint BurstLength
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

	[XmlElement(Type = typeof(byte), ElementName = "applicableModes")]
	public byte ApplicableModes
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

	[XmlArray(ElementName = "systemSpecificData")]
	public byte[] SystemSpecificData
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

	public static bool operator !=(IFFFundamentalParameterData ifffundamentalParameterData_0, IFFFundamentalParameterData ifffundamentalParameterData_1)
	{
		return !(ifffundamentalParameterData_0 == ifffundamentalParameterData_1);
	}

	public static bool operator ==(IFFFundamentalParameterData ifffundamentalParameterData_0, IFFFundamentalParameterData ifffundamentalParameterData_1)
	{
		if ((object)ifffundamentalParameterData_0 == ifffundamentalParameterData_1)
		{
			return true;
		}
		if ((object)ifffundamentalParameterData_0 != null && (object)ifffundamentalParameterData_1 != null)
		{
			return ifffundamentalParameterData_0.Equals(ifffundamentalParameterData_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 24;
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
			dataOutputStream_0.WriteFloat(float_0);
			dataOutputStream_0.WriteFloat(float_1);
			dataOutputStream_0.WriteFloat(float_2);
			dataOutputStream_0.WriteFloat(float_3);
			dataOutputStream_0.WriteUnsignedInt(uint_0);
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
			float_0 = dataInputStream_0.ReadFloat();
			float_1 = dataInputStream_0.ReadFloat();
			float_2 = dataInputStream_0.ReadFloat();
			float_3 = dataInputStream_0.ReadFloat();
			uint_0 = dataInputStream_0.ReadUnsignedInt();
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
		stringBuilder_0.AppendLine("<IFFFundamentalParameterData>");
		try
		{
			stringBuilder_0.AppendLine("<erp type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</erp>");
			stringBuilder_0.AppendLine("<frequency type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</frequency>");
			stringBuilder_0.AppendLine("<pgrf type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</pgrf>");
			stringBuilder_0.AppendLine("<pulseWidth type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</pulseWidth>");
			stringBuilder_0.AppendLine("<burstLength type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</burstLength>");
			stringBuilder_0.AppendLine("<applicableModes type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</applicableModes>");
			for (int i = 0; i < byte_1.Length; i++)
			{
				stringBuilder_0.AppendLine("<systemSpecificData" + i.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + byte_1[i] + "</systemSpecificData" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			stringBuilder_0.AppendLine("</IFFFundamentalParameterData>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as IFFFundamentalParameterData;
	}

	public bool Equals(IFFFundamentalParameterData ifffundamentalParameterData_0)
	{
		bool flag = true;
		if (ifffundamentalParameterData_0.GetType() == GetType())
		{
			if (float_0 != ifffundamentalParameterData_0.float_0)
			{
				flag = false;
			}
			if (float_1 != ifffundamentalParameterData_0.float_1)
			{
				flag = false;
			}
			if (float_2 != ifffundamentalParameterData_0.float_2)
			{
				flag = false;
			}
			if (float_3 != ifffundamentalParameterData_0.float_3)
			{
				flag = false;
			}
			if (uint_0 != ifffundamentalParameterData_0.uint_0)
			{
				flag = false;
			}
			if (byte_0 != ifffundamentalParameterData_0.byte_0)
			{
				flag = false;
			}
			if (ifffundamentalParameterData_0.byte_1.Length != 3)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < 3; i++)
				{
					if (byte_1[i] != ifffundamentalParameterData_0.byte_1[i])
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
		num = smethod_0(0) ^ float_0.GetHashCode();
		num = smethod_0(num) ^ float_1.GetHashCode();
		num = smethod_0(num) ^ float_2.GetHashCode();
		num = smethod_0(num) ^ float_3.GetHashCode();
		num = smethod_0(num) ^ uint_0.GetHashCode();
		num = smethod_0(num) ^ byte_0.GetHashCode();
		for (int i = 0; i < 3; i++)
		{
			num = smethod_0(num) ^ byte_1[i].GetHashCode();
		}
		return num;
	}
}
