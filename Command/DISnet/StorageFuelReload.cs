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
public class StorageFuelReload
{
	private uint uint_0;

	private uint uint_1;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	private byte byte_4;

	private byte byte_5;

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

	[XmlElement(Type = typeof(byte), ElementName = "standardQuantityReloadTime")]
	public byte StandardQuantityReloadTime
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

	[XmlElement(Type = typeof(byte), ElementName = "maximumQuantityReloadTime")]
	public byte MaximumQuantityReloadTime
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

	[XmlElement(Type = typeof(byte), ElementName = "fuelMeasurementUnits")]
	public byte FuelMeasurementUnits
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

	[XmlElement(Type = typeof(byte), ElementName = "fuelType")]
	public byte FuelType
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

	[XmlElement(Type = typeof(byte), ElementName = "fuelLocation")]
	public byte FuelLocation
	{
		get
		{
			return byte_4;
		}
		set
		{
			byte_4 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "padding")]
	public byte Padding
	{
		get
		{
			return byte_5;
		}
		set
		{
			byte_5 = value;
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

	public static bool operator !=(StorageFuelReload storageFuelReload_0, StorageFuelReload storageFuelReload_1)
	{
		return !(storageFuelReload_0 == storageFuelReload_1);
	}

	public static bool operator ==(StorageFuelReload storageFuelReload_0, StorageFuelReload storageFuelReload_1)
	{
		if ((object)storageFuelReload_0 == storageFuelReload_1)
		{
			return true;
		}
		if ((object)storageFuelReload_0 != null && (object)storageFuelReload_1 != null)
		{
			return storageFuelReload_0.Equals(storageFuelReload_1);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 14;
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
				dataOutputStream_0.WriteUnsignedByte(byte_0);
				dataOutputStream_0.WriteUnsignedByte(byte_1);
				dataOutputStream_0.WriteUnsignedByte(byte_2);
				dataOutputStream_0.WriteUnsignedByte(byte_3);
				dataOutputStream_0.WriteUnsignedByte(byte_4);
				dataOutputStream_0.WriteUnsignedByte(byte_5);
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
				byte_0 = dataInputStream_0.ReadUnsignedByte();
				byte_1 = dataInputStream_0.ReadUnsignedByte();
				byte_2 = dataInputStream_0.ReadUnsignedByte();
				byte_3 = dataInputStream_0.ReadUnsignedByte();
				byte_4 = dataInputStream_0.ReadUnsignedByte();
				byte_5 = dataInputStream_0.ReadUnsignedByte();
			}
			catch (Exception exception_)
			{
				OnException(exception_);
			}
		}
	}

	public virtual void Reflection(StringBuilder stringBuilder_0)
	{
		stringBuilder_0.AppendLine("<StorageFuelReload>");
		try
		{
			stringBuilder_0.AppendLine("<standardQuantity type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</standardQuantity>");
			stringBuilder_0.AppendLine("<maximumQuantity type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</maximumQuantity>");
			stringBuilder_0.AppendLine("<standardQuantityReloadTime type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</standardQuantityReloadTime>");
			stringBuilder_0.AppendLine("<maximumQuantityReloadTime type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</maximumQuantityReloadTime>");
			stringBuilder_0.AppendLine("<fuelMeasurementUnits type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</fuelMeasurementUnits>");
			stringBuilder_0.AppendLine("<fuelType type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</fuelType>");
			stringBuilder_0.AppendLine("<fuelLocation type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</fuelLocation>");
			stringBuilder_0.AppendLine("<padding type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</padding>");
			stringBuilder_0.AppendLine("</StorageFuelReload>");
		}
		catch (Exception exception_)
		{
			OnException(exception_);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as StorageFuelReload;
	}

	public bool Equals(StorageFuelReload storageFuelReload_0)
	{
		bool result = true;
		if (storageFuelReload_0.GetType() == GetType())
		{
			if (uint_0 != storageFuelReload_0.uint_0)
			{
				result = false;
			}
			if (uint_1 != storageFuelReload_0.uint_1)
			{
				result = false;
			}
			if (byte_0 != storageFuelReload_0.byte_0)
			{
				result = false;
			}
			if (byte_1 != storageFuelReload_0.byte_1)
			{
				result = false;
			}
			if (byte_2 != storageFuelReload_0.byte_2)
			{
				result = false;
			}
			if (byte_3 != storageFuelReload_0.byte_3)
			{
				result = false;
			}
			if (byte_4 != storageFuelReload_0.byte_4)
			{
				result = false;
			}
			if (byte_5 != storageFuelReload_0.byte_5)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ uint_1.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ byte_3.GetHashCode()) ^ byte_4.GetHashCode()) ^ byte_5.GetHashCode();
	}
}
