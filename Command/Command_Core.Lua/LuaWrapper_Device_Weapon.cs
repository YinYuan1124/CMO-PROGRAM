using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscateType]
public sealed class LuaWrapper_Device_Weapon
{
	protected Scenario ScenarioContext;

	protected Weapon theWeapon;

	public object fields
	{
		get
		{
			Type obj = GetType();
			int num = 0;
			PropertyInfo[] properties = obj.GetProperties();
			MethodInfo[] methods = obj.GetMethods();
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
				foreach (MethodInfo obj2 in array4)
				{
					string right = "set_" + propertyInfo.Name;
					if (Operators.CompareString(obj2.Name, right, TextCompare: false) == 0)
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
	public object __obj => theWeapon;

	[DoNotPrune]
	public int dbid => theWeapon.DBID;

	[DoNotPrune]
	public string name => theWeapon.Name;

	[DoNotPrune]
	public int type => (int)theWeapon.UnitType;

	[DoNotPrune]
	public string guid => theWeapon.ObjectID;

	[DoNotPrune]
	public object validTargetList
	{
		get
		{
			new Dictionary<string, object>();
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (theWeapon.ValidTargets_Description.Count == 0)
			{
				return null;
			}
			LuaUtility.FromList(theWeapon.ValidTargets_Description, val);
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable OODA
	{
		get
		{
			LuaTable obj = LuaSandBox.Singleton().CreateTable();
			obj["detection"] = theWeapon.m_TokenVal;
			obj["targeting"] = theWeapon._IndexerVal;
			obj["evasion"] = theWeapon._ResolverVal;
			return obj;
		}
	}

	[DoNotPrune]
	public string classname => theWeapon.UnitClass;

	[DoNotPrune]
	public string subtype
	{
		get
		{
			if ((int)theWeapon.UnitType <= 0)
			{
				return "None";
			}
			return theWeapon.SubTypeDescription.ToString();
		}
	}

	[DoNotPrune]
	public int subtypeN
	{
		get
		{
			if ((int)theWeapon.UnitType <= 0)
			{
				return 0;
			}
			return theWeapon.SubType;
		}
	}

	[DoNotPrune]
	public int guidance => (int)theWeapon.Guidance;

	[DoNotPrune]
	public LuaTable ranges
	{
		get
		{
			LuaTable obj = LuaSandBox.Singleton().CreateTable();
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			val["min"] = theWeapon.MinAirRange;
			val["max"] = theWeapon.MaxAirRange;
			obj["air"] = val;
			val = LuaSandBox.Singleton().CreateTable();
			val["min"] = theWeapon.MinLandRange;
			val["max"] = theWeapon.MaxLandRange;
			obj["land"] = val;
			val = LuaSandBox.Singleton().CreateTable();
			val["min"] = theWeapon.MinSubsurfaceRange;
			val["max"] = theWeapon.MaxSubsurfaceRange;
			obj["subsurface"] = val;
			val = LuaSandBox.Singleton().CreateTable();
			val["min"] = theWeapon.MinSurfaceRange;
			val["max"] = theWeapon.MaxSurfaceRange;
			obj["surface"] = val;
			return obj;
		}
	}

	[DoNotPrune]
	public LuaTable launchLimits
	{
		get
		{
			LuaTable obj = LuaSandBox.Singleton().CreateTable();
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			val["min"] = theWeapon.MinLaunchAlt_AGL;
			val["max"] = theWeapon.MaxLaunchAlt_AGL;
			obj["alt_agl"] = val;
			val = LuaSandBox.Singleton().CreateTable();
			val["min"] = theWeapon.MinLaunchAlt_ASL;
			val["max"] = theWeapon.MaxLaunchAlt_ASL;
			obj["alt_asl"] = val;
			val = LuaSandBox.Singleton().CreateTable();
			val["min"] = theWeapon.MinLaunchSpeed;
			val["max"] = theWeapon.MaxLaunchSpeed;
			obj["speed"] = val;
			return obj;
		}
	}

	[DoNotPrune]
	public LuaTable targetLimits
	{
		get
		{
			LuaTable obj = LuaSandBox.Singleton().CreateTable();
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			val["min"] = theWeapon.MinTargetAlt_AGL;
			val["max"] = theWeapon.MaxTargetAlt_AGL;
			obj["alt_agl"] = val;
			val = LuaSandBox.Singleton().CreateTable();
			val["min"] = theWeapon.MinTargetAlt_ASL;
			val["max"] = theWeapon.MaxTargetAlt_ASL;
			obj["alt_asl"] = val;
			val = LuaSandBox.Singleton().CreateTable();
			val["min"] = theWeapon.MinTargetSpeed;
			val["max"] = theWeapon.MaxTargetSpeed;
			obj["speed"] = val;
			return obj;
		}
	}

	[DoNotPrune]
	public LuaTable warheads
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (theWeapon.Warheads.Count() == 0)
			{
				return val;
			}
			Warhead[] array = theWeapon.Warheads;
			Warhead[] array2 = array;
			foreach (Warhead warhead in array2)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["dbid"] = warhead.DBID;
				val2["dp"] = warhead.DP;
				val2["name"] = warhead.Name;
				val2["numof"] = warhead.NumberOfWarheads;
				val2["type"] = (int)warhead.Type;
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable sensors
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			Sensor[] array = theWeapon.Sensors_ReadOnly();
			Sensor[] array2 = array;
			foreach (Sensor sensor in array2)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["dbid"] = sensor.DBID;
				val2["name"] = sensor.Name;
				val2["type"] = (short)sensor.Type;
				val2["role"] = (long)sensor.Role;
				val2["maxrange"] = sensor.maxRange;
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable directors
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (theWeapon.Directors.Count <= 0)
			{
				return val;
			}
			foreach (int director in theWeapon.Directors)
			{
				SQLiteConnection sqliteConnection_ = ScenarioContext.DBConnection;
				Sensor sensor = DBFunctions.GetSensor(director, ref sqliteConnection_);
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["dbid"] = sensor.DBID;
				val2["name"] = sensor.Name;
				val2["type"] = (short)sensor.Type;
				val2["role"] = (long)sensor.Role;
				val2["maxrange"] = sensor.maxRange;
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
	}

	public LuaWrapper_Device_Weapon(Weapon weapon_0, Scenario scenario_0)
	{
		ScenarioContext = scenario_0;
		theWeapon = weapon_0;
	}

	[DoNotPrune]
	public override string ToString()
	{
		return "weapon {\r\n name = '" + name + "', \r\n dbid = '" + dbid + "', \r\n type = '" + type + "', \r\n subtype = '" + subtype + "', \r\n}";
	}
}
