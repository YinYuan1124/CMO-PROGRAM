using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPruneType]
[DoNotObfuscateType]
[DoNotPrune]
public sealed class LuaWrapper_Event
{
	protected SimEvent ev;

	protected Scenario ScenarioContext;

	protected int level;

	protected bool bool_0;

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
	public object __obj => ev;

	[DoNotPrune]
	public LuaTable details
	{
		get
		{
			try
			{
				HashSet<string> hashSet_ = new HashSet<string>();
				LuaTable val = LuaSandBox.Singleton().CreateTable();
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				if (level == 0 || level == 1)
				{
					foreach (EventTrigger trigger in ev.Triggers)
					{
						EventTrigger eventTrigger_ = trigger;
						LuaTable val3 = LuaSandBox.Singleton().CreateTable();
						XmlDocument xmlDocument_ = new XmlDocument();
						StringWriter stringWriter = new StringWriter(new StringBuilder());
						LuaEvent.AddUnitToSerialized(ref eventTrigger_, hashSet_);
						using (XmlWriter xmlWriter = new XmlTextWriter(stringWriter))
						{
							eventTrigger_.ToXML(xmlWriter, hashSet_, ScenarioContext);
							xmlWriter.Flush();
						}
						xmlDocument_.LoadXml(stringWriter.ToString());
						if (bool_0)
						{
							val3["xml"] = xmlDocument_.InnerXml;
						}
						val3[eventTrigger_.Type.ToString()] = LuaEvent.ParseXMLtoTable(ref xmlDocument_);
						val2[val2.Keys.Count + 1] = val3;
					}
					val["triggers"] = val2;
				}
				val2 = LuaSandBox.Singleton().CreateTable();
				if (level == 0 || level == 2)
				{
					foreach (EventCondition condition in ev.Conditions)
					{
						LuaTable val4 = LuaSandBox.Singleton().CreateTable();
						XmlDocument xmlDocument_2 = new XmlDocument();
						StringWriter stringWriter2 = new StringWriter(new StringBuilder());
						using (XmlWriter xmlWriter2 = new XmlTextWriter(stringWriter2))
						{
							condition.ToXML(xmlWriter2, hashSet_, ScenarioContext);
							xmlWriter2.Flush();
						}
						xmlDocument_2.LoadXml(stringWriter2.ToString());
						if (bool_0)
						{
							val4["xml"] = xmlDocument_2.InnerXml;
						}
						val4[condition.Type.ToString()] = LuaEvent.ParseXMLtoTable(ref xmlDocument_2);
						val2[val2.Keys.Count + 1] = val4;
					}
					val["conditions"] = val2;
				}
				val2 = LuaSandBox.Singleton().CreateTable();
				if (level == 0 || level == 3)
				{
					foreach (EventAction action in ev.Actions)
					{
						LuaTable val5 = LuaSandBox.Singleton().CreateTable();
						val5["type"] = action.Type.ToString();
						XmlDocument xmlDocument_3 = new XmlDocument();
						StringWriter stringWriter3 = new StringWriter(new StringBuilder());
						using (XmlWriter xmlWriter3 = new XmlTextWriter(stringWriter3))
						{
							action.ToXML(xmlWriter3, hashSet_, ScenarioContext);
							xmlWriter3.Flush();
						}
						xmlDocument_3.LoadXml(stringWriter3.ToString());
						if (bool_0)
						{
							val5["xml"] = xmlDocument_3.InnerXml;
						}
						val5[action.Type.ToString()] = LuaEvent.ParseXMLtoTable(ref xmlDocument_3);
						val2[val2.Keys.Count + 1] = val5;
					}
					val["actions"] = val2;
				}
				if (level == 0 || level == 4)
				{
					val["name"] = ev.Name;
					val["guid"] = ev.ObjectID;
					val["description"] = ev.Description;
					val["isActive"] = ev.IsActive;
					val["isShown"] = ev.IsShown;
					val["isRepeatable"] = ev.IsRepeatable;
					val["probability"] = ev.Probability;
				}
				return val;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	[DoNotPrune]
	public string guid => ev.ObjectID;

	[DoNotPrune]
	public string description
	{
		get
		{
			return ev.Description;
		}
		set
		{
			ev.Description = value;
		}
	}

	[DoNotPrune]
	public string name => ev.Name;

	[DoNotPrune]
	public object isActive
	{
		get
		{
			return ev.IsActive;
		}
		set
		{
			ev.IsActive = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value)).Value;
		}
	}

	[DoNotPrune]
	public object isShown
	{
		get
		{
			return ev.IsShown.ToString();
		}
		set
		{
			ev.IsShown = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value)).Value;
		}
	}

	[DoNotPrune]
	public object isRepeatable
	{
		get
		{
			return ev.IsRepeatable.ToString();
		}
		set
		{
			ev.IsRepeatable = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value)).Value;
		}
	}

	[DoNotPrune]
	public string probability
	{
		get
		{
			return ev.Probability.ToString();
		}
		set
		{
			short result = 0;
			short.TryParse(value, out result);
			if (result >= 0 && result <= 100)
			{
				ev.Probability = result;
			}
		}
	}

	[DoNotPrune]
	public LuaTable triggers
	{
		get
		{
			HashSet<string> hashSet_ = new HashSet<string>();
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			foreach (EventTrigger trigger in ev.Triggers)
			{
				EventTrigger eventTrigger_ = trigger;
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				XmlDocument xmlDocument_ = new XmlDocument();
				StringWriter stringWriter = new StringWriter(new StringBuilder());
				LuaEvent.AddUnitToSerialized(ref eventTrigger_, hashSet_);
				using (XmlWriter xmlWriter = new XmlTextWriter(stringWriter))
				{
					eventTrigger_.ToXML(xmlWriter, hashSet_, ScenarioContext);
					xmlWriter.Flush();
				}
				xmlDocument_.LoadXml(stringWriter.ToString());
				if (bool_0)
				{
					val2["xml"] = xmlDocument_.InnerXml;
				}
				val2[eventTrigger_.Type.ToString()] = LuaEvent.ParseXMLtoTable(ref xmlDocument_);
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable conditions
	{
		get
		{
			HashSet<string> hashSet_ = new HashSet<string>();
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			foreach (EventCondition condition in ev.Conditions)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				XmlDocument xmlDocument_ = new XmlDocument();
				StringWriter stringWriter = new StringWriter(new StringBuilder());
				using (XmlWriter xmlWriter = new XmlTextWriter(stringWriter))
				{
					condition.ToXML(xmlWriter, hashSet_, ScenarioContext);
					xmlWriter.Flush();
				}
				xmlDocument_.LoadXml(stringWriter.ToString());
				if (bool_0)
				{
					val2["xml"] = xmlDocument_.InnerXml;
				}
				val2[condition.Type.ToString()] = LuaEvent.ParseXMLtoTable(ref xmlDocument_);
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable actions
	{
		get
		{
			HashSet<string> hashSet_ = new HashSet<string>();
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			foreach (EventAction action in ev.Actions)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["type"] = action.Type.ToString();
				XmlDocument xmlDocument_ = new XmlDocument();
				StringWriter stringWriter = new StringWriter(new StringBuilder());
				using (XmlWriter xmlWriter = new XmlTextWriter(stringWriter))
				{
					action.ToXML(xmlWriter, hashSet_, ScenarioContext);
					xmlWriter.Flush();
				}
				xmlDocument_.LoadXml(stringWriter.ToString());
				if (bool_0)
				{
					val2["xml"] = xmlDocument_.InnerXml;
				}
				val2[action.Type.ToString()] = LuaEvent.ParseXMLtoTable(ref xmlDocument_);
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
	}

	public LuaWrapper_Event(SimEvent simEvent_0, int int_0, bool bool_1, Scenario scenario_0)
	{
		ev = simEvent_0;
		ScenarioContext = scenario_0;
		level = int_0;
		bool_0 = bool_1;
	}
}
