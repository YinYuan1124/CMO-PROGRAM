using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic;

[Serializable]
public struct PropulsionPlantConfiguration
{
	[Description("Run internal simulation clock.")]
	public enum ConfigurationValue : uint
	{
		Other,
		DieselElectric,
		Diesel,
		Battery,
		TurbineReduction,
		Unknown,
		Steam,
		GasTurbine,
		Unknown2
	}

	[Description("Hull Mounted Masker status")]
	public enum HullMountedMaskerValue : uint
	{
		Off,
		On
	}

	private ConfigurationValue configurationValue_0;

	private HullMountedMaskerValue hullMountedMaskerValue_0;

	public ConfigurationValue Configuration
	{
		get
		{
			return configurationValue_0;
		}
		set
		{
			configurationValue_0 = value;
		}
	}

	public HullMountedMaskerValue HullMountedMasker
	{
		get
		{
			return hullMountedMaskerValue_0;
		}
		set
		{
			hullMountedMaskerValue_0 = value;
		}
	}

	public static bool operator !=(PropulsionPlantConfiguration propulsionPlantConfiguration_0, PropulsionPlantConfiguration propulsionPlantConfiguration_1)
	{
		return !(propulsionPlantConfiguration_0 == propulsionPlantConfiguration_1);
	}

	public static bool operator ==(PropulsionPlantConfiguration propulsionPlantConfiguration_0, PropulsionPlantConfiguration propulsionPlantConfiguration_1)
	{
		if ((object)propulsionPlantConfiguration_0 == (object)propulsionPlantConfiguration_1)
		{
			return true;
		}
		if ((object)propulsionPlantConfiguration_0 != null && (object)propulsionPlantConfiguration_1 != null)
		{
			return propulsionPlantConfiguration_0.Equals(propulsionPlantConfiguration_1);
		}
		return false;
	}

	public static explicit operator uint(PropulsionPlantConfiguration propulsionPlantConfiguration_0)
	{
		return propulsionPlantConfiguration_0.ToUInt32();
	}

	public static explicit operator PropulsionPlantConfiguration(uint uint_0)
	{
		return smethod_0(uint_0);
	}

	public static PropulsionPlantConfiguration FromByteArray(byte[] byte_0, int int_0)
	{
		if (byte_0 == null)
		{
			throw new ArgumentNullException("array");
		}
		if (int_0 < 0 || int_0 > byte_0.Length - 1 || int_0 + 4 > byte_0.Length - 1)
		{
			throw new IndexOutOfRangeException();
		}
		return smethod_0(BitConverter.ToUInt32(byte_0, int_0));
	}

	public static PropulsionPlantConfiguration smethod_0(uint uint_0)
	{
		PropulsionPlantConfiguration result = default(PropulsionPlantConfiguration);
		result.Configuration = (ConfigurationValue)(uint_0 & 0x7Fu);
		result.HullMountedMasker = (HullMountedMaskerValue)((uint_0 & 0x80) >> 7);
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is PropulsionPlantConfiguration)
		{
			return Equals((PropulsionPlantConfiguration)obj);
		}
		return false;
	}

	public bool Equals(PropulsionPlantConfiguration propulsionPlantConfiguration_0)
	{
		if ((object)propulsionPlantConfiguration_0 == null)
		{
			return false;
		}
		if (Configuration == propulsionPlantConfiguration_0.Configuration)
		{
			return HullMountedMasker == propulsionPlantConfiguration_0.HullMountedMasker;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return (uint)(ConfigurationValue.Other | Configuration) | ((uint)HullMountedMasker << 7);
	}

	public override int GetHashCode()
	{
		return (493 + Configuration.GetHashCode()) * 29 + HullMountedMasker.GetHashCode();
	}
}
