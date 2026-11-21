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
public sealed class LuaWrapper_Flight
{
	private Mission.Flight flight_0;

	private Scenario scenario_0;

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
	public object __obj => flight_0;

	[DoNotPrune]
	public string guid => flight_0.ObjectID;

	[DoNotPrune]
	public string name
	{
		get
		{
			return flight_0.Callsign;
		}
		set
		{
			flight_0.Callsign = value;
		}
	}

	[DoNotPrune]
	public LuaTable course
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			Waypoint[] flightPlan = flight_0.FlightPlan;
			Waypoint[] array = flightPlan;
			foreach (Waypoint waypoint_ in array)
			{
				val[val.Keys.Count + 1] = new LuaWrapper_Waypoint(waypoint_, scenario_0);
			}
			return val;
		}
		set
		{
			throw new LuaError("无法设置此属性。请使用ScenEdit_Set。");
		}
	}

	public LuaWrapper_Flight(Mission.Flight flight_1, Scenario scenario_1)
	{
		flight_0 = flight_1;
		scenario_0 = scenario_1;
	}

	[DoNotPrune]
	public override string ToString()
	{
		return string.Concat("flight {\r\n guid = '" + guid + "', \r\n name = '" + name + "', \r\n course = '" + course.ToString() + "', \r\n", "}");
	}
}
