using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscateType]
public sealed class LuaWrapper_Doctrine
{
	protected Doctrine doc;

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
	public object __obj => doc;

	[DoNotPrune]
	public LuaTable TargetPriority
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (doc != null && ScenarioContext != null)
			{
				List<Doctrine.PriorityTargetEntry> priorityTargetList = doc.PriorityTargetList;
				if (priorityTargetList != null && priorityTargetList.Count > 0)
				{
					foreach (Doctrine.PriorityTargetEntry item in priorityTargetList)
					{
						LuaTable val2 = LuaSandBox.Singleton().CreateTable();
						val2["type"] = (int)item.Type;
						if (item.SubType < Doctrine.PriorityTargetEntry.FACILITY_SUBTYPE_OFFSET_INDEX)
						{
							val2["subtype"] = item.SubType;
							val2["isfixedfacilitysubtype"] = false;
						}
						else
						{
							val2["subtype"] = item.SubType - Doctrine.PriorityTargetEntry.FACILITY_SUBTYPE_OFFSET_INDEX;
							val2["isfixedfacilitysubtype"] = true;
						}
						val2["dbid"] = item.DBID;
						val2["priority"] = (int)item.Priority;
						val[val.Keys.Count + 1] = val2;
					}
					return val;
				}
			}
			return val;
		}
	}

	public LuaWrapper_Doctrine(Doctrine doctrine_0, Scenario scenario_0)
	{
		doc = doctrine_0;
		ScenarioContext = scenario_0;
	}

	[DoNotPrune]
	public LuaTable method_0(string string_0)
	{
		return LuaSandBox.Singleton().CreateTable();
	}

	public LuaTable deleteTargetPriorityEntry(int int_0)
	{
		if (doc != null && ScenarioContext != null)
		{
			doc.DeletePriorityTargetListEntry(int_0);
		}
		return TargetPriority;
	}

	public LuaTable addTargetPriorityEntry(int int_0, int int_1, bool bool_0, int int_2, int int_3)
	{
		if (doc != null && ScenarioContext != null)
		{
			if (int_0 == 0)
			{
				throw new LuaError("Invalid unit type for Target Priority entry.");
			}
			GlobalVariables.ActiveUnitType activeUnitType = (GlobalVariables.ActiveUnitType)int_0;
			if (int_1 != 0)
			{
				bool flag = false;
				switch (activeUnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
				{
					IEnumerator enumerator6 = null;
					try
					{
						enumerator6 = Enum.GetValues(typeof(Aircraft._AircraftType)).GetEnumerator();
						while (enumerator6.MoveNext())
						{
							if (Conversions.ToInteger(enumerator6.Current) == int_1)
							{
								flag = true;
								break;
							}
						}
					}
					finally
					{
						if (enumerator6 is IDisposable)
						{
							(enumerator6 as IDisposable).Dispose();
						}
					}
					break;
				}
				case GlobalVariables.ActiveUnitType.Ship:
				{
					IEnumerator enumerator5 = null;
					try
					{
						enumerator5 = Enum.GetValues(typeof(Ship._ShipType)).GetEnumerator();
						while (enumerator5.MoveNext())
						{
							if (Conversions.ToInteger(enumerator5.Current) == int_1)
							{
								flag = true;
								break;
							}
						}
					}
					finally
					{
						if (enumerator5 is IDisposable)
						{
							(enumerator5 as IDisposable).Dispose();
						}
					}
					break;
				}
				case GlobalVariables.ActiveUnitType.Submarine:
				{
					IEnumerator enumerator2 = null;
					try
					{
						enumerator2 = Enum.GetValues(typeof(Submarine._SubmarineType)).GetEnumerator();
						while (enumerator2.MoveNext())
						{
							if (Conversions.ToInteger(enumerator2.Current) == int_1)
							{
								flag = true;
								break;
							}
						}
					}
					finally
					{
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
					break;
				}
				case GlobalVariables.ActiveUnitType.Facility:
				{
					if (bool_0)
					{
						IEnumerator enumerator3 = null;
						try
						{
							enumerator3 = Enum.GetValues(typeof(Facility._FacilityCategory)).GetEnumerator();
							while (enumerator3.MoveNext())
							{
								if (Conversions.ToShort(enumerator3.Current) == int_1)
								{
									flag = true;
									break;
								}
							}
						}
						finally
						{
							if (enumerator3 is IDisposable)
							{
								(enumerator3 as IDisposable).Dispose();
							}
						}
						break;
					}
					IEnumerator enumerator4 = null;
					try
					{
						enumerator4 = Enum.GetValues(typeof(IMobileGroundUnit._MobileUnitCategory)).GetEnumerator();
						while (enumerator4.MoveNext())
						{
							if (Conversions.ToInteger(enumerator4.Current) == int_1)
							{
								flag = true;
								break;
							}
						}
					}
					finally
					{
						if (enumerator4 is IDisposable)
						{
							(enumerator4 as IDisposable).Dispose();
						}
					}
					break;
				}
				case GlobalVariables.ActiveUnitType.Weapon:
					if (int_1 == 2001)
					{
						flag = true;
					}
					break;
				default:
					throw new LuaError("Invalid unit type for Target Priority entry.");
				case GlobalVariables.ActiveUnitType.Vehicle:
				{
					IEnumerator enumerator = null;
					try
					{
						enumerator = Enum.GetValues(typeof(IMobileGroundUnit._MobileUnitCategory)).GetEnumerator();
						while (enumerator.MoveNext())
						{
							if (Conversions.ToInteger(enumerator.Current) == int_1)
							{
								flag = true;
								break;
							}
						}
					}
					finally
					{
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					break;
				}
				}
				if (!flag)
				{
					throw new LuaError("Invalid unit sub-type for Target Priority entry.");
				}
				if (bool_0)
				{
					int_1 += Doctrine.PriorityTargetEntry.FACILITY_SUBTYPE_OFFSET_INDEX;
				}
			}
			if (doc.PriorityTargetList == null || doc.PriorityTargetList.Count == 0)
			{
				doc.CreatePriorityTargetList();
			}
			doc.AddPriorityTargetListEntry(activeUnitType, int_1, int_2, int_3);
			doc.SortPriorityTargetList();
		}
		return TargetPriority;
	}
}
