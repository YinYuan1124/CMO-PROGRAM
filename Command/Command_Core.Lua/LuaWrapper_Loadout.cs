using System;
using System.Collections.Generic;
using System.Reflection;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscateType]
public sealed class LuaWrapper_Loadout
{
	protected Scenario ScenarioContext;

	protected Loadout LoadOut;

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
				dictionary.Add("property_" + num, text + propertyInfo.Name + " , " + propertyInfo.PropertyType.Name + " , " + flag + " , " + propertyInfo.CanRead);
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
	public object __obj => LoadOut;

	[DoNotPrune]
	public int dbid => LoadOut.DBID;

	[DoNotPrune]
	public string name => LoadOut.Name;

	[DoNotPrune]
	public LuaTable roles
	{
		get
		{
			LuaTable obj = LuaSandBox.Singleton().CreateTable();
			obj["role"] = (int)LoadOut.Role;
			obj["TOD"] = (short)LoadOut.TimeOfDay;
			obj["weather"] = (short)LoadOut.Weather;
			return obj;
		}
	}

	[DoNotPrune]
	public LuaTable weapons
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			WeaponRec[] array = LoadOut.Weapons;
			WeaponRec[] array2 = array;
			foreach (WeaponRec weaponRec in array2)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["wpn_guid"] = weaponRec.ObjectID;
				val2["wpn_current"] = weaponRec.CurrentLoad;
				val2["wpn_maxcap"] = weaponRec.MaxLoad;
				val2["wpn_default"] = weaponRec.DefaultLoad;
				val2["wpn_dbid"] = weaponRec.int_0;
				val2["wpn_name"] = weaponRec.GetReferenceWeapon(ScenarioContext).Name;
				val2["wpn_type"] = (int)DBFunctions.GetWeaponType(weaponRec.int_0, ScenarioContext);
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
	}

	public LuaWrapper_Loadout(Loadout loadout_0, Scenario scenario_0)
	{
		LoadOut = loadout_0;
		ScenarioContext = scenario_0;
	}

	[DoNotPrune]
	public override string ToString()
	{
		return "loadout {\r\n name = '" + name + "', \r\n dbid = '" + dbid + "', \r\n roles = '{" + LoadOut.Role.ToString() + "," + LoadOut.TimeOfDay.ToString() + "," + LoadOut.Weather.ToString() + "}\r\n weapons = '" + weapons.ToString() + "', \r\n}";
	}

	[DoNotPrune]
	public int setExactWeaponQuantity(string string_0, int int_0)
	{
		int num = int_0;
		WeaponRec[] array = LoadOut.Weapons;
		WeaponRec[] array2 = array;
		foreach (WeaponRec weaponRec in array2)
		{
			if (Operators.CompareString(weaponRec.ObjectID, string_0, TextCompare: false) != 0)
			{
				continue;
			}
			if (num < 0)
			{
				num = 0;
			}
			if ((double)num / (double)weaponRec.Multiple > (double)weaponRec.MaxLoad)
			{
				num = weaponRec.MaxLoad;
			}
			if (weaponRec.ParentMount != null)
			{
				weaponRec.CurrentLoad = 0;
				Mount parentMount = weaponRec.ParentMount;
				int int_ = 0;
				int int_2 = 0;
				int num2 = parentMount.RegisterTokenizer(ref int_, ref int_2);
				if ((double)num / (double)weaponRec.Multiple > (double)(weaponRec.ParentMount.MaxCapacity - num2))
				{
					num = weaponRec.ParentMount.MaxCapacity - num2 * weaponRec.Multiple;
				}
			}
			if (num < 0)
			{
				num = 0;
			}
			weaponRec.CurrentLoad = num;
			return weaponRec.CurrentLoad;
		}
		return 0;
	}
}
