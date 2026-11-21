using System;
using System.Collections.Generic;
using System.Reflection;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPruneType]
[DoNotObfuscateType]
[DoNotPrune]
public sealed class LuaWrapper_Group
{
	protected Group au;

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
	public LuaWrapper_Doctrine doctrine
	{
		get
		{
			if (au.Doctrine == null)
			{
				return null;
			}
			return new LuaWrapper_Doctrine(au.Doctrine, ScenarioContext);
		}
	}

	[DoNotPrune]
	public object __obj => au;

	[DoNotPrune]
	public string type => au.Type.ToString();

	[DoNotPrune]
	public string guid => au.ObjectID;

	[DoNotPrune]
	public string name
	{
		get
		{
			return au.Name;
		}
		set
		{
			au.Name = value;
		}
	}

	[DoNotPrune]
	public string side => au.GetUnitSide().Name;

	[DoNotPrune]
	public string lead
	{
		get
		{
			return au.GroupLead.ObjectID;
		}
		set
		{
			Scenario scenarioContext = ScenarioContext;
			Group group;
			Side side_ = (group = au).GetUnitSide();
			ActiveUnit activeUnit = LuaUtility.ValidAsUnit(value, scenarioContext, ref side_);
			group.SetUnitSide(bool_0: false, side_);
			ActiveUnit activeUnit2 = activeUnit;
			if (Information.IsNothing(activeUnit2))
			{
				return;
			}
			foreach (ActiveUnit value2 in au.Units.Values)
			{
				if (value2 == activeUnit2)
				{
					au.SetGroupLead(activeUnit2);
					break;
				}
			}
		}
	}

	[DoNotPrune]
	public bool leadSlowsDown
	{
		get
		{
			return au.Kinematics.LeadAllowedToSlowDown;
		}
		set
		{
			au.Kinematics.LeadAllowedToSlowDown = value;
		}
	}

	[DoNotPrune]
	public LuaTable unitlist
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			new List<Module_Unit.Unit>();
			List<Module_Unit.Unit> list = au.ToList();
			int num = 1;
			foreach (Module_Unit.Unit item in list)
			{
				val[num] = item.ObjectID;
				num++;
			}
			return val;
		}
	}

	public LuaWrapper_Group(Group group_0, Scenario scenario_0)
	{
		au = group_0;
		ScenarioContext = scenario_0;
	}

	[DoNotPrune]
	public override string ToString()
	{
		return string.Concat("group {\r\n guid = '" + guid + "', \r\n name = '" + name + "', \r\n side = '" + side + "', \r\n type = '" + type.ToString() + "', \r\n unitlist = '" + unitlist.ToString() + "',\r\n", "}");
	}
}
