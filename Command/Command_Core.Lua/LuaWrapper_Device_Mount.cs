using System;
using System.Collections.Generic;
using System.Reflection;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotObfuscateType]
[DoNotPruneType]
[DoNotPrune]
public sealed class LuaWrapper_Device_Mount
{
	protected Scenario ScenarioContext;

	protected Mount theMount;

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
	public object __obj => theMount;

	[DoNotPrune]
	public int dbid => theMount.DBID;

	[DoNotPrune]
	public string name => theMount.Name;

	[DoNotPrune]
	public string guid => theMount.ObjectID;

	[DoNotPrune]
	public int armor => (int)theMount.ArmorRating;

	[DoNotPrune]
	public int rof => theMount.ROF;

	[DoNotPrune]
	public int capacity => theMount.MaxCapacity;

	[DoNotPrune]
	public LuaTable weapons
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			foreach (WeaponRec mountWeapon in theMount.MountWeapons)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["wpn_guid"] = mountWeapon.ObjectID;
				val2["wpn_current"] = mountWeapon.CurrentLoad;
				val2["wpn_maxcap"] = mountWeapon.MaxLoad;
				val2["wpn_default"] = mountWeapon.DefaultLoad;
				val2["wpn_dbid"] = mountWeapon.int_0;
				val2["wpn_name"] = mountWeapon.GetReferenceWeapon(ScenarioContext).Name;
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
	}

	public LuaWrapper_Device_Mount(Mount mount_0, Scenario scenario_0)
	{
		ScenarioContext = scenario_0;
		theMount = mount_0;
	}

	[DoNotPrune]
	public override string ToString()
	{
		string text = "mount {\r\n name = '" + name + "', \r\n dbid = '" + dbid + "', \r\n";
		if (theMount.MountWeapons != null)
		{
			text = text + " weapons = '" + theMount.MountWeapons.Count + "', \r\n";
		}
		return text + "}";
	}

	[DoNotPrune]
	public int setExactWeaponQuantity(string string_0, int int_0)
	{
		int num = int_0;
		foreach (WeaponRec mountWeapon in theMount.MountWeapons)
		{
			if (Operators.CompareString(mountWeapon.ObjectID, string_0, TextCompare: false) == 0)
			{
				if (num < 0)
				{
					num = 0;
				}
				if ((double)num / (double)mountWeapon.Multiple > (double)mountWeapon.MaxLoad)
				{
					num = mountWeapon.MaxLoad;
				}
				mountWeapon.CurrentLoad = 0;
				Mount mount = theMount;
				int int_ = 0;
				int int_2 = 0;
				int num2 = mount.RegisterTokenizer(ref int_, ref int_2);
				if ((double)num / (double)mountWeapon.Multiple > (double)(theMount.MaxCapacity - num2))
				{
					num = theMount.MaxCapacity - num2 * mountWeapon.Multiple;
				}
				mountWeapon.CurrentLoad = num;
				return mountWeapon.CurrentLoad;
			}
		}
		return 0;
	}
}
