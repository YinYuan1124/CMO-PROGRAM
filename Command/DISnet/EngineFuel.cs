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
public class EngineFuel
{
	private uint uint_0;

	private byte nolEeCqBnRq;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "fuelQuantity")]
	public uint FuelQuantity
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

	[XmlElement(Type = typeof(byte), ElementName = "fuelMeasurementUnits")]
	public byte FuelMeasurementUnits
	{
		get
		{
			return nolEeCqBnRq;
		}
		set
		{
			nolEeCqBnRq = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "fuelType")]
	public byte FuelType
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

	[XmlElement(Type = typeof(byte), ElementName = "fuelLocation")]
	public byte FuelLocation
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

	[XmlElement(Type = typeof(byte), ElementName = "padding")]
	public byte Padding
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

	public static bool operator !=(EngineFuel engineFuel_0, EngineFuel engineFuel_1)
	{
		return !(engineFuel_0 == engineFuel_1);
	}

	public static bool operator ==(EngineFuel engineFuel_0, EngineFuel engineFuel_1)
	{
		if ((object)engineFuel_0 == engineFuel_1)
		{
			return true;
		}
		if ((object)engineFuel_0 != null && (object)engineFuel_1 != null)
		{
			return engineFuel_0.Equals(engineFuel_1);
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
				dataOutputStream_0.WriteUnsignedInt(uint_0);
				dataOutputStream_0.WriteUnsignedByte(nolEeCqBnRq);
				dataOutputStream_0.WriteUnsignedByte(byte_0);
				dataOutputStream_0.WriteUnsignedByte(byte_1);
				dataOutputStream_0.WriteUnsignedByte(byte_2);
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
				uint_0 = dataInputStream_0.ReadUnsignedInt();
				nolEeCqBnRq = dataInputStream_0.ReadUnsignedByte();
				byte_0 = dataInputStream_0.ReadUnsignedByte();
				byte_1 = dataInputStream_0.ReadUnsignedByte();
				byte_2 = dataInputStream_0.ReadUnsignedByte();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<EngineFuel>");
		try
		{
			stringBuilder_0.AppendLine("<fuelQuantity type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</fuelQuantity>");
			stringBuilder_0.AppendLine("<fuelMeasurementUnits type=\"byte\">" + nolEeCqBnRq.ToString(CultureInfo.InvariantCulture) + "</fuelMeasurementUnits>");
			stringBuilder_0.AppendLine("<fuelType type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</fuelType>");
			stringBuilder_0.AppendLine("<fuelLocation type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</fuelLocation>");
			stringBuilder_0.AppendLine("<padding type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</padding>");
			stringBuilder_0.AppendLine("</EngineFuel>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EngineFuel;
	}

	public bool Equals(EngineFuel engineFuel_0)
	{
		bool result = true;
		if (engineFuel_0.GetType() == GetType())
		{
			if (uint_0 != engineFuel_0.uint_0)
			{
				result = false;
			}
			if (nolEeCqBnRq != engineFuel_0.nolEeCqBnRq)
			{
				result = false;
			}
			if (byte_0 != engineFuel_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != engineFuel_0.byte_1)
			{
				result = false;
			}
			if (byte_2 != engineFuel_0.byte_2)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ nolEeCqBnRq.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode();
	}
}
