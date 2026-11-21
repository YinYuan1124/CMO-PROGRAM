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
public class EngineFuelReload
{
	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	private byte yDuExTrmIx8;

	private byte byte_0;

	private byte byte_1;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "standardQuantity")]
	public uint StandardQuantity
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

	[XmlElement(Type = typeof(uint), ElementName = "maximumQuantity")]
	public uint MaximumQuantity
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "standardQuantityReloadTime")]
	public uint StandardQuantityReloadTime
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "maximumQuantityReloadTime")]
	public uint MaximumQuantityReloadTime
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "fuelMeasurmentUnits")]
	public byte FuelMeasurmentUnits
	{
		get
		{
			return yDuExTrmIx8;
		}
		set
		{
			yDuExTrmIx8 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "fuelLocation")]
	public byte FuelLocation
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

	[XmlElement(Type = typeof(byte), ElementName = "padding")]
	public byte Padding
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

	public static bool operator !=(EngineFuelReload engineFuelReload_0, EngineFuelReload engineFuelReload_1)
	{
		return !(engineFuelReload_0 == engineFuelReload_1);
	}

	public static bool operator ==(EngineFuelReload engineFuelReload_0, EngineFuelReload engineFuelReload_1)
	{
		if ((object)engineFuelReload_0 == engineFuelReload_1)
		{
			return true;
		}
		if ((object)engineFuelReload_0 != null && (object)engineFuelReload_1 != null)
		{
			return engineFuelReload_0.Equals(engineFuelReload_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 19;
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
				dataOutputStream_0.WriteUnsignedInt(uint_1);
				dataOutputStream_0.WriteUnsignedInt(uint_2);
				dataOutputStream_0.WriteUnsignedInt(uint_3);
				dataOutputStream_0.WriteUnsignedByte(yDuExTrmIx8);
				dataOutputStream_0.WriteUnsignedByte(byte_0);
				dataOutputStream_0.WriteUnsignedByte(byte_1);
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
				uint_1 = dataInputStream_0.ReadUnsignedInt();
				uint_2 = dataInputStream_0.ReadUnsignedInt();
				uint_3 = dataInputStream_0.ReadUnsignedInt();
				yDuExTrmIx8 = dataInputStream_0.ReadUnsignedByte();
				byte_0 = dataInputStream_0.ReadUnsignedByte();
				byte_1 = dataInputStream_0.ReadUnsignedByte();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<EngineFuelReload>");
		try
		{
			stringBuilder_0.AppendLine("<standardQuantity type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</standardQuantity>");
			stringBuilder_0.AppendLine("<maximumQuantity type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</maximumQuantity>");
			stringBuilder_0.AppendLine("<standardQuantityReloadTime type=\"uint\">" + uint_2.ToString(CultureInfo.InvariantCulture) + "</standardQuantityReloadTime>");
			stringBuilder_0.AppendLine("<maximumQuantityReloadTime type=\"uint\">" + uint_3.ToString(CultureInfo.InvariantCulture) + "</maximumQuantityReloadTime>");
			stringBuilder_0.AppendLine("<fuelMeasurmentUnits type=\"byte\">" + yDuExTrmIx8.ToString(CultureInfo.InvariantCulture) + "</fuelMeasurmentUnits>");
			stringBuilder_0.AppendLine("<fuelLocation type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</fuelLocation>");
			stringBuilder_0.AppendLine("<padding type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</padding>");
			stringBuilder_0.AppendLine("</EngineFuelReload>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EngineFuelReload;
	}

	public bool Equals(EngineFuelReload engineFuelReload_0)
	{
		bool result = true;
		if (engineFuelReload_0.GetType() == GetType())
		{
			if (uint_0 != engineFuelReload_0.uint_0)
			{
				result = false;
			}
			if (uint_1 != engineFuelReload_0.uint_1)
			{
				result = false;
			}
			if (uint_2 != engineFuelReload_0.uint_2)
			{
				result = false;
			}
			if (uint_3 != engineFuelReload_0.uint_3)
			{
				result = false;
			}
			if (yDuExTrmIx8 != engineFuelReload_0.yDuExTrmIx8)
			{
				result = false;
			}
			if (byte_0 != engineFuelReload_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != engineFuelReload_0.byte_1)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ uint_1.GetHashCode()) ^ uint_2.GetHashCode()) ^ uint_3.GetHashCode()) ^ yDuExTrmIx8.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode();
	}
}
