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
public sealed class LuaWrapper_Facility
{
	protected DockFacility dock;

	protected AirFacility air;

	protected Scenario ScenarioContext;

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
	public object __au
	{
		get
		{
			if (air == null)
			{
				if (dock == null)
				{
					return null;
				}
				return dock;
			}
			return air;
		}
	}

	[DoNotPrune]
	public string guid
	{
		get
		{
			if (air == null)
			{
				if (dock == null)
				{
					return null;
				}
				return dock.ObjectID;
			}
			return air.ObjectID;
		}
	}

	[DoNotPrune]
	public int dbid
	{
		get
		{
			if (air == null)
			{
				if (dock == null)
				{
					return 0;
				}
				return dock.DBID;
			}
			return air.DBID;
		}
	}

	[DoNotPrune]
	public string name
	{
		get
		{
			if (air == null)
			{
				if (dock == null)
				{
					return null;
				}
				return dock.Name;
			}
			return air.Name;
		}
	}

	[DoNotPrune]
	public int type
	{
		get
		{
			if (air == null)
			{
				if (dock == null)
				{
					return 0;
				}
				return (int)dock.Type;
			}
			return (int)air.AirFacType;
		}
	}

	[DoNotPrune]
	public int capacity
	{
		get
		{
			if (air == null)
			{
				if (dock == null)
				{
					return 0;
				}
				return dock.Capacity;
			}
			return air.Capacity;
		}
		set
		{
			if (air == null)
			{
				if (dock != null)
				{
					dock.Capacity = (byte)value;
				}
			}
			else
			{
				air.Capacity = value;
			}
		}
	}

	[DoNotPrune]
	public string status
	{
		get
		{
			if (air == null)
			{
				if (dock == null)
				{
					return null;
				}
				return dock.Status.ToString();
			}
			return air.Status.ToString();
		}
	}

	public LuaWrapper_Facility(object object_0, Scenario scenario_0)
	{
		dock = null;
		air = null;
		if ((object)object_0.GetType() == typeof(AirFacility))
		{
			air = (AirFacility)object_0;
		}
		else if ((object)object_0.GetType() == typeof(DockFacility))
		{
			dock = (DockFacility)object_0;
		}
		ScenarioContext = scenario_0;
	}
}
