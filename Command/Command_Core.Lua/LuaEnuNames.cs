using System;
using System.Collections.Generic;
using System.Reflection;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPruneType]
[DoNotObfuscateType]
[DoNotPrune]
public sealed class LuaEnuNames
{
	public object fields
	{
		get
		{
			Type type = GetType();
			int num = 0;
			PropertyInfo[] properties = type.GetProperties();
			MethodInfo[] methods = type.GetMethods();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			PropertyInfo[] array = properties;
			PropertyInfo[] array3 = array;
			MethodInfo[] array2;
			foreach (PropertyInfo propertyInfo in array3)
			{
				if (propertyInfo.Name.StartsWith("__") || propertyInfo.Name.StartsWith("fields"))
				{
					continue;
				}
				string text = "";
				bool flag = false;
				if (propertyInfo.MemberType == MemberTypes.Method)
				{
					text = ":";
				}
				else if (propertyInfo.MemberType == MemberTypes.Property)
				{
					text = ".";
				}
				array2 = methods;
				MethodInfo[] array4 = array2;
				foreach (MethodInfo obj in array4)
				{
					string right = "set_" + propertyInfo.Name;
					if (Operators.CompareString(obj.Name, right, TextCompare: false) == 0)
					{
						flag = true;
					}
				}
				num++;
				dictionary.Add("property_" + num, text + propertyInfo.Name + " , " + propertyInfo.PropertyType.Name + " , " + flag);
			}
			num = 0;
			array2 = methods;
			MethodInfo[] array5 = array2;
			foreach (MethodInfo methodInfo in array5)
			{
				if (!methodInfo.Name.StartsWith("get_") && !methodInfo.Name.StartsWith("set_") && !methodInfo.Name.StartsWith("ToString") && !methodInfo.IsHideBySig)
				{
					string text2 = "";
					if (methodInfo.MemberType == MemberTypes.Method)
					{
						text2 = ":";
					}
					else if (methodInfo.MemberType == MemberTypes.Property)
					{
						text2 = ".";
					}
					num++;
					dictionary.Add("method_" + num, text2 + methodInfo.Name + " , " + methodInfo.ReturnType.ToString());
				}
			}
			if (dictionary.Count == 0)
			{
				return null;
			}
			LuaUtility.FromDict(dictionary, val);
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable Condition_Air
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			byte[] array = (byte[])Enum.GetValues(typeof(Aircraft_AirOps._AirOpsCondition));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				byte b = array[i];
				string text = b.ToString();
				Aircraft_AirOps._AirOpsCondition airOpsCondition = (Aircraft_AirOps._AirOpsCondition)b;
				val[text] = airOpsCondition.ToString();
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable Condition_Dock
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			byte[] array = (byte[])Enum.GetValues(typeof(ActiveUnit_DockingOps._DockingOpsCondition));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				byte b = array[i];
				string text = b.ToString();
				ActiveUnit_DockingOps._DockingOpsCondition dockingOpsCondition = (ActiveUnit_DockingOps._DockingOpsCondition)b;
				val[text] = dockingOpsCondition.ToString();
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable Throttle
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			byte[] array = (byte[])Enum.GetValues(typeof(ActiveUnit.Throttle));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				byte b = array[i];
				string text = b.ToString();
				ActiveUnit.Throttle throttle = (ActiveUnit.Throttle)b;
				val[text] = throttle.ToString();
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable Depth
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			byte[] array = (byte[])Enum.GetValues(typeof(ActiveUnit_AI.SubmarineDepthPreset));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				byte b = array[i];
				string text = b.ToString();
				ActiveUnit_AI.SubmarineDepthPreset submarineDepthPreset = (ActiveUnit_AI.SubmarineDepthPreset)b;
				val[text] = submarineDepthPreset.ToString();
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable Altitude
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			byte[] array = (byte[])Enum.GetValues(typeof(ActiveUnit_AI.AircraftAltitudePreset));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				byte b = array[i];
				string text = b.ToString();
				ActiveUnit_AI.AircraftAltitudePreset aircraftAltitudePreset = (ActiveUnit_AI.AircraftAltitudePreset)b;
				val[text] = aircraftAltitudePreset.ToString();
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable ContactType
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			byte[] array = (byte[])Enum.GetValues(typeof(Contact_Base.ContactType));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				byte b = array[i];
				string text = b.ToString();
				Contact_Base.ContactType contactType = (Contact_Base.ContactType)b;
				val[text] = contactType.ToString();
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable Proficiency
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			int[] array = (int[])Enum.GetValues(typeof(GlobalVariables.ProficiencyLevel));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				int num = array[i];
				string text = num.ToString();
				GlobalVariables.ProficiencyLevel proficiencyLevel = (GlobalVariables.ProficiencyLevel)num;
				val[text] = proficiencyLevel.ToString();
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable PatrolType
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.PatrolType));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				byte b = array[i];
				string text = b.ToString();
				GlobalVariables.PatrolType patrolType = (GlobalVariables.PatrolType)b;
				val[text] = patrolType.ToString();
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable StrikeType
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			int[] array = (int[])Enum.GetValues(typeof(Strike.StrikeType));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				int num = array[i];
				string text = num.ToString();
				Strike.StrikeType strikeType = (Strike.StrikeType)num;
				val[text] = strikeType.ToString();
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable UnitType
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.ActiveUnitType));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				byte b = array[i];
				string text = b.ToString();
				GlobalVariables.ActiveUnitType activeUnitType = (GlobalVariables.ActiveUnitType)b;
				val[text] = activeUnitType.ToString();
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable FuelType
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			short[] array = (short[])Enum.GetValues(typeof(FuelRec._FuelType));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				short num = array[i];
				string text = num.ToString();
				FuelRec._FuelType fuelType = (FuelRec._FuelType)num;
				val[text] = fuelType.ToString();
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable FuelState
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			short[] array = (short[])Enum.GetValues(typeof(FuelRec._FuelType));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				short num = array[i];
				string text = num.ToString();
				FuelRec._FuelType fuelType = (FuelRec._FuelType)num;
				val[text] = fuelType.ToString();
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable guidanceType
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			byte[] array = (byte[])Enum.GetValues(typeof(Weapon.WeaponGuidanceType));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				byte b = array[i];
				string text = b.ToString();
				Weapon.WeaponGuidanceType weaponGuidanceType = (Weapon.WeaponGuidanceType)b;
				val[text] = weaponGuidanceType.ToString();
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable sensorType
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			short[] array = (short[])Enum.GetValues(typeof(Sensor.Sensor_Type));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				short num = array[i];
				string text = num.ToString();
				Sensor.Sensor_Type sensor_Type = (Sensor.Sensor_Type)num;
				val[text] = sensor_Type.ToString();
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable sensorRole
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			long[] array = (long[])Enum.GetValues(typeof(Sensor.Sensor_Role));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				long num = array[i];
				string text = num.ToString();
				Sensor.Sensor_Role sensor_Role = (Sensor.Sensor_Role)num;
				val[text] = sensor_Role.ToString();
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable warheadType
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			int[] array = (int[])Enum.GetValues(typeof(Warhead.WarheadType));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				int num = array[i];
				string text = num.ToString();
				Warhead.WarheadType warheadType = (Warhead.WarheadType)num;
				val[text] = warheadType.ToString();
			}
			return val;
		}
	}

	[DoNotPrune]
	internal LuaTable Doctrine(string string_0)
	{
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		switch (string_0.ToLower())
		{
		case "wratargettype":
		{
			int[] array4 = (int[])Enum.GetValues(typeof(Doctrine._WRA_WeaponTargetType));
			for (int l = 0; l < array4.Length; l = checked(l + 1))
			{
				int num3 = array4[l];
				string text4 = num3.ToString();
				Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = (Doctrine._WRA_WeaponTargetType)num3;
				val[text4] = wRA_WeaponTargetType.ToString();
			}
			break;
		}
		case "weaponstate":
		{
			int[] array2 = (int[])Enum.GetValues(typeof(Doctrine._WeaponState));
			for (int j = 0; j < array2.Length; j = checked(j + 1))
			{
				int num = array2[j];
				string text2 = num.ToString();
				Doctrine._WeaponState weaponState = (Doctrine._WeaponState)num;
				val[text2] = weaponState.ToString();
			}
			break;
		}
		case "rechargebattery":
		{
			int[] array3 = (int[])Enum.GetValues(typeof(Doctrine._RechargeBatteryPercentage));
			for (int k = 0; k < array3.Length; k = checked(k + 1))
			{
				int num2 = array3[k];
				string text3 = num2.ToString();
				Doctrine._RechargeBatteryPercentage rechargeBatteryPercentage = (Doctrine._RechargeBatteryPercentage)num2;
				val[text3] = rechargeBatteryPercentage.ToString();
			}
			break;
		}
		case "fuelstate":
		{
			byte[] array = (byte[])Enum.GetValues(typeof(Doctrine._FuelState));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				byte b = array[i];
				string text = b.ToString();
				Doctrine._FuelState fuelState = (Doctrine._FuelState)b;
				val[text] = fuelState.ToString();
			}
			break;
		}
		}
		return val;
	}
}
