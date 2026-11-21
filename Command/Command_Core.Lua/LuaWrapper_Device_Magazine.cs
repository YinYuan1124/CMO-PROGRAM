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
public sealed class LuaWrapper_Device_Magazine
{
	internal Magazine mag;

	protected Scenario ScenarioContext;

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
	public object __obj => mag;

	[DoNotPrune]
	public string guid => mag.ObjectID;

	[DoNotPrune]
	public string parentunitguid
	{
		get
		{
			if (mag.ParentPlatform == null)
			{
				return null;
			}
			return mag.ParentPlatform.ObjectID;
		}
	}

	[DoNotPrune]
	public int dbid => mag.DBID;

	[DoNotPrune]
	public string name => mag.Name;

	[DoNotPrune]
	public int armor => (int)mag.Armor;

	[DoNotPrune]
	public int rof => mag.ROF;

	[DoNotPrune]
	public int capacity => mag.Capacity;

	[DoNotPrune]
	public bool isaviationmagazine => mag.IsAviationMag;

	[DoNotPrune]
	public LuaTable weapons
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			foreach (WeaponRec weapon in mag.Weapons)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["wpn_guid"] = weapon.ObjectID;
				val2["wpn_current"] = weapon.CurrentLoad;
				val2["wpn_maxcap"] = weapon.MaxLoad;
				val2["wpn_default"] = weapon.DefaultLoad;
				val2["wpn_dbid"] = weapon.int_0;
				val2["wpn_name"] = weapon.GetReferenceWeapon(ScenarioContext).Name;
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
	}

	public LuaWrapper_Device_Magazine(Magazine magazine_0, Scenario scenario_0)
	{
		mag = magazine_0;
		ScenarioContext = scenario_0;
	}

	[DoNotPrune]
	public override string ToString()
	{
		string text = "magazine {\r\n name = '" + name + "', \r\n dbid = '" + dbid + "', \r\n guid = '" + guid.ToString() + "', \r\n armor = '" + armor + "', \r\n rof = '" + rof + "', \r\n capacity = '" + capacity + "', \r\n isaviationmagazine = '" + isaviationmagazine + "', \r\n";
		if (mag.Weapons != null)
		{
			text = text + " weapons = '" + mag.Weapons.Count + "', \r\n";
		}
		return text + "}";
	}

	[DoNotPrune]
	public int setExactWeaponQuantity(string string_0, int int_0)
	{
		int num = int_0;
		foreach (WeaponRec weapon in mag.Weapons)
		{
			if (Operators.CompareString(weapon.ObjectID, string_0, TextCompare: false) == 0)
			{
				if (num < 0)
				{
					num = 0;
				}
				if ((double)num / (double)weapon.Multiple > (double)weapon.MaxLoad)
				{
					num = weapon.MaxLoad;
				}
				weapon.CurrentLoad = 0;
				Magazine magazine = mag;
				int int_ = 0;
				int int_2 = 0;
				int num2 = magazine.InitClass(ref int_, ref int_2);
				if ((double)num / (double)weapon.Multiple > (double)(mag.Capacity - num2))
				{
					num = mag.Capacity - num2 * weapon.Multiple;
				}
				if (num < 0)
				{
					num = 0;
				}
				weapon.CurrentLoad = num;
				return weapon.CurrentLoad;
			}
		}
		return 0;
	}
}
