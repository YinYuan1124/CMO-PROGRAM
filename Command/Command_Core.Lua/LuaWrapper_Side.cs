using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscateType]
public sealed class LuaWrapper_Side
{
	private Side mySide;

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
	public object __obj => mySide;

	[DoNotPrune]
	public string guid => mySide.ObjectID;

	[DoNotPrune]
	public string ObjectID => guid;

	[DoNotPrune]
	public string name
	{
		get
		{
			return mySide.Name;
		}
		set
		{
			mySide.Name = value;
		}
	}

	[DoNotPrune]
	public LuaWrapper_Doctrine doctrine
	{
		get
		{
			if (mySide.Doctrine == null)
			{
				return null;
			}
			return new LuaWrapper_Doctrine(mySide.Doctrine, ScenarioContext);
		}
	}

	[DoNotPrune]
	public LuaTable units
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			foreach (ActiveUnit unit in mySide.Units)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["guid"] = unit.ObjectID;
				val2["name"] = unit.Name;
				val[num] = val2;
				num++;
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable contacts
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			foreach (Contact contacts_ in mySide.Contacts_List)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["guid"] = contacts_.ObjectID;
				val2["name"] = contacts_.Name;
				val[num] = val2;
				num++;
			}
			foreach (string key in mySide.m_InfoFacade.Keys)
			{
				if (!mySide.Contacts_List.Contains(mySide.m_InfoFacade[key]))
				{
					LuaTable val3 = LuaSandBox.Singleton().CreateTable();
					val3["guid"] = mySide.m_InfoFacade[key].ObjectID;
					val3["name"] = mySide.m_InfoFacade[key].Name;
					val[num] = val3;
					num++;
				}
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable exclusionzones
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			foreach (ExclusionZone exclusionZone in mySide.ExclusionZones)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["guid"] = exclusionZone.ObjectID;
				val2["name"] = exclusionZone.Name;
				val2["description"] = exclusionZone.Description;
				val[num] = val2;
				num++;
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable nonavzones
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			foreach (NoNavZone noNavZone in mySide.NoNavZones)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["guid"] = noNavZone.ObjectID;
				val2["name"] = noNavZone.Name;
				val2["description"] = noNavZone.Description;
				val[num] = val2;
				num++;
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable standardzones
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			foreach (Zone standardZone in mySide.StandardZones)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["guid"] = standardZone.ObjectID;
				val2["name"] = standardZone.Name;
				val2["description"] = standardZone.Description;
				val[num] = val2;
				num++;
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable customenvironmentzones
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			foreach (CustomEnvironmentZone customEnvironmentZone in mySide.CustomEnvironmentZones)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["guid"] = customEnvironmentZone.ObjectID;
				val2["name"] = customEnvironmentZone.Name;
				val2["description"] = customEnvironmentZone.Description;
				val[num] = val2;
				num++;
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable rps
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			foreach (ReferencePoint refPoint in mySide.RefPoints)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["guid"] = refPoint.ObjectID;
				val2["name"] = refPoint.Name;
				val2["longitude"] = refPoint.Longitude;
				val2["latitude"] = refPoint.Latitude;
				val2["side"] = mySide.Name;
				val2["highlighted"] = refPoint.IsHighlighted;
				val2["locked"] = refPoint.IsLocked;
				if (!Information.IsNothing(refPoint.IsRelativeTo))
				{
					val2["bearingtype"] = refPoint.BearingType;
					val2["relativeto"] = refPoint.IsRelativeTo.ObjectID;
				}
				val[num] = val2;
				num++;
			}
			return val;
		}
	}

	[DoNotPrune]
	public Side.AwarenessLevel_Enum awareness => mySide.AwarenessLevel;

	[DoNotPrune]
	public GlobalVariables.ProficiencyLevel proficiency => mySide.Proficiency;

	[DoNotPrune]
	public bool hasmines
	{
		get
		{
			foreach (UnguidedWeapon value in ScenarioContext.UnguidedWeapons.Values)
			{
				if (value.IsMine && value.GetUnitSide() == mySide)
				{
					return true;
				}
			}
			return false;
		}
	}

	[DoNotPrune]
	public LuaTable missions
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			foreach (Mission mission in mySide.Missions)
			{
				val[val.Keys.Count + 1] = new LuaWrapper_Mission(mission, ScenarioContext);
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaWrapper_Operation Operation => new LuaWrapper_Operation(ScenarioContext, mySide.Operation, mySide);

	[DoNotPrune]
	public LuaTable Chalks
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			foreach (Chalk chalk in mySide.Chalks)
			{
				val[val.Keys.Count + 1] = new LuaWrapper_Serial(ScenarioContext, chalk);
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable losses
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			foreach (KeyValuePair<string, HashSet<string>> loss in mySide.AAR.Losses)
			{
				if (loss.Value.Count != 0)
				{
					string[] array = loss.Key.ToString().Split('_');
					LuaTable val2 = LuaSandBox.Singleton().CreateTable();
					val2["type"] = array[0].ToString();
					val2["dbid"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(array[0], "Custom", TextCompare: false) == 0, 0, array[1]));
					val2["name"] = mySide.AAR.AwakeInterruptibleReg(ScenarioContext, loss);
					val2["count"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(array[0], "Custom", TextCompare: false) == 0, loss.Value.ElementAtOrDefault(0), loss.Value.Count));
					val[val.Keys.Count + 1] = val2;
				}
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable expenditures
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			foreach (KeyValuePair<int, int> expenditure in mySide.AAR.Expenditures)
			{
				ScenarioContext.Cache_Weapons_DT.Select("ID=" + Conversions.ToString(expenditure.Key));
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["type"] = "Weapon";
				val2["dbid"] = expenditure.Key;
				val2["name"] = mySide.AAR.PublishInterruptibleReg(ScenarioContext, expenditure);
				val2["count"] = expenditure.Value;
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
	}

	public LuaWrapper_Side(Side side_0, Scenario scenario_0)
	{
		mySide = side_0;
		ScenarioContext = scenario_0;
	}

	[DoNotPrune]
	public LuaTable unitsInArea(LuaTable luaTable_0)
	{
		UnitFilterObject unitFilterObject = null;
		List<ReferencePoint> list = new List<ReferencePoint>();
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		foreach (string key in dictionary_.Keys)
		{
			if (Operators.CompareString(key, "TARGETFILTER", TextCompare: false) == 0)
			{
				unitFilterObject = CreateTargetTrigger(ref dictionary_, ScenarioContext);
				unitFilterObject.TargetSide = mySide.ObjectID;
			}
			else
			{
				if (Operators.CompareString(key, "AREA", TextCompare: false) != 0)
				{
					continue;
				}
				list.Clear();
				foreach (object item in LuaUtility.ToArray(((LuaTable)dictionary_["AREA"]).GetEnumerator()))
				{
					object Local_o = RuntimeHelpers.GetObjectValue(item);
					ReferencePoint referencePoint = null;
					if (Information.IsNothing(mySide.RefPoints.FirstOrDefault((ReferencePoint s) => Operators.CompareString(s.Name, Local_o.ToString(), TextCompare: false) == 0)))
					{
						if (Information.IsNothing(mySide.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o.ToString(), StringComparison.OrdinalIgnoreCase))))
						{
							if (Information.IsNothing(mySide.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase))))
							{
								if (!Information.IsNothing(mySide.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase))))
								{
									referencePoint = mySide.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase));
								}
							}
							else
							{
								referencePoint = mySide.RefPoints.First((ReferencePoint s) => string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase));
							}
						}
						else
						{
							referencePoint = mySide.RefPoints.First((ReferencePoint s) => string.Equals(s.Name, Local_o.ToString(), StringComparison.OrdinalIgnoreCase));
						}
					}
					else
					{
						referencePoint = mySide.RefPoints.First((ReferencePoint s) => Operators.CompareString(s.Name, Local_o.ToString(), TextCompare: false) == 0);
					}
					if (!Information.IsNothing(referencePoint))
					{
						list.Add(referencePoint);
					}
				}
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		foreach (ActiveUnit unit in mySide.Units)
		{
			if (!Information.IsNothing(unit) && (unitFilterObject == null || unitFilterObject.MatchesThisUnit(unit)) && unit.GetIsInsideThisArea(list, ScenarioContext, bool_0: false))
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["guid"] = unit.ObjectID;
				val2["name"] = unit.Name;
				val[val.Keys.Count + 1] = val2;
			}
		}
		return val;
	}

	[DoNotPrune]
	public LuaTable unitsBy(string string_0, int? nullable_0 = 0, int? nullable_1 = 0)
	{
		GlobalVariables.ActiveUnitType activeUnitType = GlobalVariables.ActiveUnitType.None;
		if (string_0 != null)
		{
			byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.ActiveUnitType));
			int num = 0;
			while (num < array.Length)
			{
				byte b = array[num];
				if (!string.Equals(string_0, b.ToString(), StringComparison.OrdinalIgnoreCase))
				{
					GlobalVariables.ActiveUnitType activeUnitType2 = (GlobalVariables.ActiveUnitType)b;
					if (!string.Equals(string_0, activeUnitType2.ToString(), StringComparison.OrdinalIgnoreCase))
					{
						num = checked(num + 1);
						continue;
					}
				}
				activeUnitType = (GlobalVariables.ActiveUnitType)b;
				break;
			}
			if (activeUnitType == GlobalVariables.ActiveUnitType.None)
			{
				return null;
			}
			if (!nullable_0.HasValue)
			{
				nullable_0 = 0;
			}
			if (!nullable_1.HasValue)
			{
				nullable_1 = 0;
			}
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			int num2 = 1;
			foreach (ActiveUnit item in new List<ActiveUnit>(mySide.Units))
			{
				byte b2 = (byte)activeUnitType;
				byte? b3 = (byte?)item?.UnitType;
				if (!(b3.HasValue ? new bool?(b2 == b3.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					continue;
				}
				int? num3 = nullable_0;
				if (!(num3.HasValue ? new bool?(num3.GetValueOrDefault() != 0) : null).GetValueOrDefault())
				{
					num3 = nullable_1;
					if (!(num3.HasValue ? new bool?(num3.GetValueOrDefault() != 0) : null).GetValueOrDefault())
					{
						goto IL_03b9;
					}
				}
				num3 = nullable_0;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() != 0) : null).GetValueOrDefault())
				{
					switch (item.UnitType)
					{
					case GlobalVariables.ActiveUnitType.Aircraft:
						if ((int)((Aircraft)item).Category != nullable_0.Value)
						{
							continue;
						}
						break;
					case GlobalVariables.ActiveUnitType.Ship:
						if (((Ship)item).Category != (Ship._ShipCategory)nullable_0.Value)
						{
							continue;
						}
						break;
					case GlobalVariables.ActiveUnitType.Submarine:
						if (((Submarine)item).Category != (Submarine._SubmarineCategory)nullable_0.Value)
						{
							continue;
						}
						break;
					case GlobalVariables.ActiveUnitType.Facility:
						if (item.IsFixedFacility)
						{
							if ((int)((Facility)item).Category != nullable_0.Value)
							{
								continue;
							}
						}
						else if (((Facility)item).EnableBridge() != (IMobileGroundUnit._MobileUnitCategory)nullable_0.Value)
						{
							continue;
						}
						break;
					case GlobalVariables.ActiveUnitType.Satellite:
						if (((Satellite)item).Category != (Satellite._SatelliteCategory)nullable_0.Value)
						{
							continue;
						}
						break;
					}
				}
				num3 = nullable_1;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() != 0) : null).GetValueOrDefault() && item.SubType != nullable_1.Value)
				{
					continue;
				}
				goto IL_03b9;
				IL_03b9:
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["guid"] = item.ObjectID;
				val2["name"] = item.Name;
				val[num2] = val2;
				num2++;
			}
			if (val.Keys.Count > 0)
			{
				return val;
			}
			return null;
		}
		return units;
	}

	[DoNotPrune]
	public LuaTable contactsBy(string string_0)
	{
		GlobalVariables.ActiveUnitType activeUnitType = GlobalVariables.ActiveUnitType.None;
		if (string_0 != null)
		{
			byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.ActiveUnitType));
			int num = 0;
			while (num < array.Length)
			{
				byte b = array[num];
				if (!string.Equals(string_0, b.ToString(), StringComparison.OrdinalIgnoreCase))
				{
					GlobalVariables.ActiveUnitType activeUnitType2 = (GlobalVariables.ActiveUnitType)b;
					if (!string.Equals(string_0, activeUnitType2.ToString(), StringComparison.OrdinalIgnoreCase))
					{
						num = checked(num + 1);
						continue;
					}
				}
				activeUnitType = (GlobalVariables.ActiveUnitType)b;
				break;
			}
		}
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		int num2 = 1;
		foreach (Contact contacts_ in mySide.Contacts_List)
		{
			if (activeUnitType == GlobalVariables.ActiveUnitType.None || activeUnitType == contacts_.ActualUnit.UnitType)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["guid"] = contacts_.ObjectID;
				val2["name"] = contacts_.Name;
				val[num2] = val2;
				num2++;
			}
			foreach (string key in mySide.m_InfoFacade.Keys)
			{
				if (!mySide.Contacts_List.Contains(mySide.m_InfoFacade[key]))
				{
					LuaTable val3 = LuaSandBox.Singleton().CreateTable();
					val3["guid"] = mySide.m_InfoFacade[key].ObjectID;
					val3["name"] = mySide.m_InfoFacade[key].Name;
					val[num2] = val3;
					num2++;
				}
			}
		}
		if (val.Keys.Count <= 0)
		{
			return null;
		}
		return val;
	}

	[DoNotPrune]
	public LuaWrapper_Zone getexclusionzone(string string_0)
	{
		Zone zone = null;
		foreach (ExclusionZone exclusionZone in mySide.ExclusionZones)
		{
			if (Operators.CompareString(exclusionZone.ObjectID, string_0, TextCompare: false) == 0 || Operators.CompareString(exclusionZone.Name, string_0, TextCompare: false) == 0 || Operators.CompareString(exclusionZone.Description, string_0, TextCompare: false) == 0)
			{
				zone = exclusionZone;
				break;
			}
		}
		if (Information.IsNothing(zone))
		{
			throw new LuaError("不存在具有此名称或ID的封锁区。");
		}
		return new LuaWrapper_Zone(zone, ScenarioContext, mySide);
	}

	[DoNotPrune]
	public LuaWrapper_Zone getnonavzone(string string_0)
	{
		Zone zone = null;
		foreach (NoNavZone noNavZone in mySide.NoNavZones)
		{
			if (Operators.CompareString(noNavZone.ObjectID, string_0, TextCompare: false) == 0 || Operators.CompareString(noNavZone.Name, string_0, TextCompare: false) == 0 || Operators.CompareString(noNavZone.Description, string_0, TextCompare: false) == 0)
			{
				zone = noNavZone;
				break;
			}
		}
		if (Information.IsNothing(zone))
		{
			throw new LuaError("不存在具有此名称或ID的禁航区域。");
		}
		return new LuaWrapper_Zone(zone, ScenarioContext, mySide);
	}

	[DoNotPrune]
	public LuaWrapper_Zone getstandardzone(string string_0)
	{
		Zone zone = null;
		foreach (Zone standardZone in mySide.StandardZones)
		{
			if (Operators.CompareString(standardZone.ObjectID, string_0, TextCompare: false) == 0 || Operators.CompareString(standardZone.Name, string_0, TextCompare: false) == 0 || Operators.CompareString(standardZone.Description, string_0, TextCompare: false) == 0)
			{
				zone = standardZone;
				break;
			}
		}
		if (Information.IsNothing(zone))
		{
			throw new LuaError("不存在具有此名称或ID的禁航区域。");
		}
		return new LuaWrapper_Zone(zone, ScenarioContext, mySide);
	}

	[DoNotPrune]
	public LuaWrapper_Zone getcustomenvironmentzone(string string_0)
	{
		if (mySide == ScenarioContext.GetNatureSide())
		{
			Zone zone = null;
			foreach (CustomEnvironmentZone customEnvironmentZone in mySide.CustomEnvironmentZones)
			{
				if (Operators.CompareString(customEnvironmentZone.ObjectID, string_0, TextCompare: false) == 0 || Operators.CompareString(customEnvironmentZone.Name, string_0, TextCompare: false) == 0 || Operators.CompareString(customEnvironmentZone.Description, string_0, TextCompare: false) == 0)
				{
					zone = customEnvironmentZone;
					break;
				}
			}
			if (Information.IsNothing(zone))
			{
				throw new LuaError("No custom environment zone exists with this name or ID.");
			}
			return new LuaWrapper_Zone(zone, ScenarioContext, mySide);
		}
		throw new LuaError("Only the scenario-designated 'nature' side may have custom environment zones.");
	}

	[DoNotPrune]
	public LuaWrapper_Contact AddOrUpdateContact(LuaTable luaTable_0)
	{
		return LuaSide.AddOrUpdateContact(mySide, ScenarioContext, luaTable_0);
	}

	[DoNotPrune]
	public override string ToString()
	{
		return string.Concat("side {\r\n guid = '" + guid + "', \r\n name = '" + name + "', \r\n units = '" + units.ToString() + "', \r\n contacts = '" + contacts.ToString() + "', \r\n Chalks = '" + Chalks.ToString() + "', \r\n", "}");
	}

	private UnitFilterObject CreateTargetTrigger(ref Dictionary<string, object> dictionary_0, Scenario scenario_0)
	{
		UnitFilterObject unitFilterObject = new UnitFilterObject();
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)dictionary_0["TARGETFILTER"]).GetEnumerator());
		foreach (string key in dictionary.Keys)
		{
			string text = dictionary[key].ToString();
			switch (key.ToUpper())
			{
			case "TARGETTYPE":
			{
				byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.ActiveUnitType));
				int num = 0;
				while (num < array.Length)
				{
					byte b = array[num];
					if (!string.Equals(text, b.ToString(), StringComparison.OrdinalIgnoreCase))
					{
						GlobalVariables.ActiveUnitType activeUnitType = (GlobalVariables.ActiveUnitType)b;
						if (!string.Equals(text, activeUnitType.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							num = checked(num + 1);
							continue;
						}
					}
					unitFilterObject.TargetType = (GlobalVariables.ActiveUnitType)b;
					break;
				}
				if (unitFilterObject.TargetType == GlobalVariables.ActiveUnitType.None)
				{
					throw new LuaError("TargetFilter.Type出错！");
				}
				break;
			}
			case "TARGETSUBTYPE":
				unitFilterObject.TargetSubType = Conversions.ToInteger(text);
				break;
			case "SPECIFICUNITCLASS":
				unitFilterObject.SpecificUnitClass = Conversions.ToInteger(text);
				break;
			}
		}
		return unitFilterObject;
	}
}
