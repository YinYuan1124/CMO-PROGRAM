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
public class FundamentalOperationalData
{
	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	private ushort ushort_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private ushort ushort_4;

	private ushort ushort_5;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(byte), ElementName = "systemStatus")]
	public byte SystemStatus
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

	[XmlElement(Type = typeof(byte), ElementName = "dataField1")]
	public byte DataField1
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

	[XmlElement(Type = typeof(byte), ElementName = "informationLayers")]
	public byte InformationLayers
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "dataField2")]
	public byte DataField2
	{
		get
		{
			return byte_3;
		}
		set
		{
			byte_3 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "parameter1")]
	public ushort Parameter1
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

	[XmlElement(Type = typeof(ushort), ElementName = "parameter2")]
	public ushort Parameter2
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

	[XmlElement(Type = typeof(ushort), ElementName = "parameter3")]
	public ushort Parameter3
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

	[XmlElement(Type = typeof(ushort), ElementName = "parameter4")]
	public ushort Parameter4
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

	[XmlElement(Type = typeof(ushort), ElementName = "parameter5")]
	public ushort Parameter5
	{
		get
		{
			return ushort_4;
		}
		set
		{
			ushort_4 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "parameter6")]
	public ushort Parameter6
	{
		get
		{
			return ushort_5;
		}
		set
		{
			ushort_5 = value;
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

	public static bool operator !=(FundamentalOperationalData fundamentalOperationalData_0, FundamentalOperationalData fundamentalOperationalData_1)
	{
		return !(fundamentalOperationalData_0 == fundamentalOperationalData_1);
	}

	public static bool operator ==(FundamentalOperationalData fundamentalOperationalData_0, FundamentalOperationalData fundamentalOperationalData_1)
	{
		if ((object)fundamentalOperationalData_0 == fundamentalOperationalData_1)
		{
			return true;
		}
		if ((object)fundamentalOperationalData_0 != null && (object)fundamentalOperationalData_1 != null)
		{
			return fundamentalOperationalData_0.Equals(fundamentalOperationalData_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 16;
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
				dataOutputStream_0.WriteUnsignedByte(byte_1);
				dataOutputStream_0.WriteUnsignedByte(byte_2);
				dataOutputStream_0.WriteUnsignedByte(byte_3);
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
				dataOutputStream_0.WriteUnsignedShort(ushort_2);
				dataOutputStream_0.WriteUnsignedShort(ushort_3);
				dataOutputStream_0.WriteUnsignedShort(ushort_4);
				dataOutputStream_0.WriteUnsignedShort(ushort_5);
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
				byte_1 = dataInputStream_0.ReadUnsignedByte();
				byte_2 = dataInputStream_0.ReadUnsignedByte();
				byte_3 = dataInputStream_0.ReadUnsignedByte();
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
				ushort_2 = dataInputStream_0.ReadUnsignedShort();
				ushort_3 = dataInputStream_0.ReadUnsignedShort();
				ushort_4 = dataInputStream_0.ReadUnsignedShort();
				ushort_5 = dataInputStream_0.ReadUnsignedShort();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<FundamentalOperationalData>");
		try
		{
			stringBuilder_0.AppendLine("<systemStatus type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</systemStatus>");
			stringBuilder_0.AppendLine("<dataField1 type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</dataField1>");
			stringBuilder_0.AppendLine("<informationLayers type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</informationLayers>");
			stringBuilder_0.AppendLine("<dataField2 type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</dataField2>");
			stringBuilder_0.AppendLine("<parameter1 type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</parameter1>");
			stringBuilder_0.AppendLine("<parameter2 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</parameter2>");
			stringBuilder_0.AppendLine("<parameter3 type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</parameter3>");
			stringBuilder_0.AppendLine("<parameter4 type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</parameter4>");
			stringBuilder_0.AppendLine("<parameter5 type=\"ushort\">" + ushort_4.ToString(CultureInfo.InvariantCulture) + "</parameter5>");
			stringBuilder_0.AppendLine("<parameter6 type=\"ushort\">" + ushort_5.ToString(CultureInfo.InvariantCulture) + "</parameter6>");
			stringBuilder_0.AppendLine("</FundamentalOperationalData>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as FundamentalOperationalData;
	}

	public bool Equals(FundamentalOperationalData fundamentalOperationalData_0)
	{
		bool result = true;
		if (fundamentalOperationalData_0.GetType() == GetType())
		{
			if (byte_0 != fundamentalOperationalData_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != fundamentalOperationalData_0.byte_1)
			{
				result = false;
			}
			if (byte_2 != fundamentalOperationalData_0.byte_2)
			{
				result = false;
			}
			if (byte_3 != fundamentalOperationalData_0.byte_3)
			{
				result = false;
			}
			if (ushort_0 != fundamentalOperationalData_0.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != fundamentalOperationalData_0.ushort_1)
			{
				result = false;
			}
			if (ushort_2 != fundamentalOperationalData_0.ushort_2)
			{
				result = false;
			}
			if (ushort_3 != fundamentalOperationalData_0.ushort_3)
			{
				result = false;
			}
			if (ushort_4 != fundamentalOperationalData_0.ushort_4)
			{
				result = false;
			}
			if (ushort_5 != fundamentalOperationalData_0.ushort_5)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ byte_3.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ ushort_2.GetHashCode()) ^ ushort_3.GetHashCode()) ^ ushort_4.GetHashCode()) ^ ushort_5.GetHashCode();
	}
}
