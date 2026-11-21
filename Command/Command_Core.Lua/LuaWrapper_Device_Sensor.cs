using System;
using System.Collections.Generic;
using System.Reflection;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscateType]
public sealed class LuaWrapper_Device_Sensor
{
	protected Scenario ScenarioContext;

	protected Sensor theSensor;

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
	public object __obj => theSensor;

	[DoNotPrune]
	public int dbid => theSensor.DBID;

	[DoNotPrune]
	public string name => theSensor.Name;

	[DoNotPrune]
	public string guid => theSensor.ObjectID;

	[DoNotPrune]
	public short type => (short)theSensor.Type;

	[DoNotPrune]
	public long role => (long)theSensor.Role;

	[DoNotPrune]
	public LuaTable ranges
	{
		get
		{
			LuaTable obj = LuaSandBox.Singleton().CreateTable();
			obj["min"] = theSensor.minRange;
			obj["max"] = theSensor.maxRange;
			return obj;
		}
	}

	[DoNotPrune]
	public int scaninterval => theSensor.ScanInterval;

	[DoNotPrune]
	public LuaTable altitudes
	{
		get
		{
			LuaTable obj = LuaSandBox.Singleton().CreateTable();
			obj["min"] = theSensor.MinAltitude_ASL;
			obj["max"] = theSensor.MaxAltitude_ASL;
			return obj;
		}
	}

	public float MaxElevationAngle
	{
		get
		{
			return theSensor.MaxElevationAngle;
		}
		set
		{
			theSensor.MaxElevationAngle = value;
		}
	}

	public float MinElevationAngle
	{
		get
		{
			return theSensor.MinElevationAngle;
		}
		set
		{
			theSensor.MinElevationAngle = value;
		}
	}

	public LuaWrapper_Device_Sensor(Sensor sensor_0, Scenario scenario_0)
	{
		ScenarioContext = scenario_0;
		theSensor = sensor_0;
	}

	[DoNotPrune]
	public LuaTable RangeAgainstTarget(LuaWrapper_ActiveUnit_SE luaWrapper_ActiveUnit_SE_0, LuaWrapper_ActiveUnit_SE luaWrapper_ActiveUnit_SE_1)
	{
		LuaTable obj = LuaSandBox.Singleton().CreateTable();
		obj["maxIR"] = theSensor.ResetWriter(luaWrapper_ActiveUnit_SE_0.au, luaWrapper_ActiveUnit_SE_1.au);
		obj["maxVisual"] = theSensor.QueryWriter(luaWrapper_ActiveUnit_SE_0.au, luaWrapper_ActiveUnit_SE_1.au, bool_0: true, bool_1: true, bool_2: true);
		return obj;
	}

	[DoNotPrune]
	public object IsPreciseCheck(LuaWrapper_ActiveUnit_SE luaWrapper_ActiveUnit_SE_0, LuaWrapper_ActiveUnit_SE luaWrapper_ActiveUnit_SE_1)
	{
		float float_ = Module_Unit.RangeToUnit_Slant(luaWrapper_ActiveUnit_SE_0.au, luaWrapper_ActiveUnit_SE_1.au);
		object obj = theSensor.GetIsPrecise(float_);
		Conversions.ToBoolean(obj);
		return obj;
	}

	[DoNotPrune]
	public override string ToString()
	{
		return "sensor {\r\n name = '" + name + "', \r\n dbid = '" + dbid + "', \r\n}";
	}
}
