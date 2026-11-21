using System;
using System.Collections.Generic;
using System.Reflection;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPrune]
[DoNotObfuscateType]
[DoNotPruneType]
public sealed class LuaWrapper_Geopoint
{
	private GeoPoint myGP;

	private Scenario ScenarioContext;

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
	public string objectid => myGP.ObjectID;

	[DoNotPrune]
	public string name
	{
		get
		{
			return myGP.Name;
		}
		set
		{
			myGP.Name = value;
		}
	}

	[DoNotPrune]
	public double latitude
	{
		get
		{
			return myGP.Latitude;
		}
		set
		{
			double? num = LuaUtility.QueryLatitudeObject(value);
			if (!num.HasValue)
			{
				throw new LuaError("不能为纬度传递零。");
			}
			myGP.Latitude = num.Value;
		}
	}

	[DoNotPrune]
	public double longitude
	{
		get
		{
			return myGP.Longitude;
		}
		set
		{
			double? num = LuaUtility.QueryLongitudeObject(value);
			if (!num.HasValue)
			{
				throw new LuaError("不能为经度传递零。");
			}
			myGP.Longitude = num.Value;
		}
	}

	[DoNotPrune]
	public float altitude
	{
		get
		{
			return myGP.Altitude;
		}
		set
		{
			myGP.Altitude = value;
		}
	}

	public LuaWrapper_Geopoint(GeoPoint geoPoint_0, Scenario scenario_0)
	{
		myGP = geoPoint_0;
		ScenarioContext = scenario_0;
	}
}
