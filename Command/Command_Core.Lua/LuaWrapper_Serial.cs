using System;
using System.Collections.Generic;
using System.Reflection;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotObfuscateType]
[DoNotPrune]
[DoNotPruneType]
public class LuaWrapper_Serial
{
	protected Scenario ScenarioContext;

	private Chalk chalk_0;

	private Side side_0;

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
	public int ID
	{
		get
		{
			return chalk_0.ID;
		}
		set
		{
			chalk_0.ID = value;
		}
	}

	[DoNotPrune]
	public string AssociatedMothership => chalk_0.AssociatedMothership.ObjectID;

	[DoNotPrune]
	public CargoType LargestCargoType => chalk_0.DestroyImporter();

	[DoNotPrune]
	public float Mass => chalk_0.ComputeImporter();

	[DoNotPrune]
	public float Area => chalk_0.PatchImporter();

	[DoNotPrune]
	public float PAX => chalk_0.SelectImporter();

	public LuaWrapper_Serial(Scenario scenario_0, Chalk chalk_1)
	{
		ScenarioContext = scenario_0;
		chalk_0 = chalk_1;
		side_0 = chalk_1.AssociatedMothership.GetUnitSide();
	}

	[DoNotPrune]
	public override string ToString()
	{
		return string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat("Serial/Chalk {\r\n AssociatedMothership = '" + AssociatedMothership, " ID = '", ID.ToString()), " LargestCargoType = '", LargestCargoType.ToString()), " Mass = '", Mass.ToString()), " Area = '", Area.ToString()), " PAX = '", PAX.ToString()), "\r\n"), "}");
	}
}
