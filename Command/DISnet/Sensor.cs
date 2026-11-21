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
public class Sensor
{
	private byte byte_0;

	private byte byte_1;

	private ushort ushort_0;

	private uint uint_0;

	private ushort ushort_1;

	private ushort ushort_2;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(byte), ElementName = "sensorTypeSource")]
	public byte SensorTypeSource
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

	[XmlElement(Type = typeof(byte), ElementName = "sensorOnOffStatus")]
	public byte SensorOnOffStatus
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

	[XmlElement(Type = typeof(ushort), ElementName = "sensorType")]
	public ushort SensorType
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

	[XmlElement(Type = typeof(uint), ElementName = "station")]
	public uint Station
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

	[XmlElement(Type = typeof(ushort), ElementName = "quantity")]
	public ushort Quantity
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding")]
	public ushort Padding
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

	public static bool operator !=(Sensor sensor_0, Sensor sensor_1)
	{
		return !(sensor_0 == sensor_1);
	}

	public static bool operator ==(Sensor sensor_0, Sensor sensor_1)
	{
		if ((object)sensor_0 == sensor_1)
		{
			return true;
		}
		if ((object)sensor_0 != null && (object)sensor_1 != null)
		{
			return sensor_0.Equals(sensor_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 12;
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
				dataOutputStream_0.WriteUnsignedShort(ushort_0);
				dataOutputStream_0.WriteUnsignedInt(uint_0);
				dataOutputStream_0.WriteUnsignedShort(ushort_1);
				dataOutputStream_0.WriteUnsignedShort(ushort_2);
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
				ushort_0 = dataInputStream_0.ReadUnsignedShort();
				uint_0 = dataInputStream_0.ReadUnsignedInt();
				ushort_1 = dataInputStream_0.ReadUnsignedShort();
				ushort_2 = dataInputStream_0.ReadUnsignedShort();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<Sensor>");
		try
		{
			stringBuilder_0.AppendLine("<sensorTypeSource type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</sensorTypeSource>");
			stringBuilder_0.AppendLine("<sensorOnOffStatus type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</sensorOnOffStatus>");
			stringBuilder_0.AppendLine("<sensorType type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</sensorType>");
			stringBuilder_0.AppendLine("<station type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</station>");
			stringBuilder_0.AppendLine("<quantity type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</quantity>");
			stringBuilder_0.AppendLine("<padding type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</padding>");
			stringBuilder_0.AppendLine("</Sensor>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as Sensor;
	}

	public bool Equals(Sensor sensor_0)
	{
		bool result = true;
		if (sensor_0.GetType() == GetType())
		{
			if (byte_0 != sensor_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != sensor_0.byte_1)
			{
				result = false;
			}
			if (ushort_0 != sensor_0.ushort_0)
			{
				result = false;
			}
			if (uint_0 != sensor_0.uint_0)
			{
				result = false;
			}
			if (ushort_1 != sensor_0.ushort_1)
			{
				result = false;
			}
			if (ushort_2 != sensor_0.ushort_2)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ ushort_0.GetHashCode()) ^ uint_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ ushort_2.GetHashCode();
	}
}
