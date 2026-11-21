using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Command_Core.SmartAssembly.Attributes;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscateType]
public sealed class LuaWrapper_Zone
{
	private Zone myZone;

	private Scenario ScenarioContext;

	private Side mySide;

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
	public object __obj => myZone;

	[DoNotPrune]
	public string type => myZone.GetType().ToString();

	[DoNotPrune]
	public string guid => myZone.ObjectID;

	[DoNotPrune]
	public string objectid => guid;

	[DoNotPrune]
	public string name
	{
		get
		{
			return myZone.Name;
		}
		set
		{
			myZone.Name = value;
		}
	}

	[DoNotPrune]
	public string description
	{
		get
		{
			return myZone.Description;
		}
		set
		{
			myZone.Description = value;
		}
	}

	[DoNotPrune]
	public object isactive
	{
		get
		{
			return myZone.IsActive;
		}
		set
		{
			try
			{
				myZone.IsActive = Conversions.ToBoolean(value);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				throw new LuaError(ex.Message);
			}
		}
	}

	[DoNotPrune]
	public object islocked
	{
		get
		{
			if (myZone.GetType() == typeof(NoNavZone))
			{
				return ((NoNavZone)myZone).IsLocked;
			}
			return null;
		}
		set
		{
			try
			{
				if (myZone.GetType() == typeof(NoNavZone))
				{
					((NoNavZone)myZone).IsLocked = Conversions.ToBoolean(value);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				throw new LuaError(ex.Message);
			}
		}
	}

	[DoNotPrune]
	public object markas
	{
		get
		{
			if (myZone.GetType() == typeof(ExclusionZone))
			{
				return ((ExclusionZone)myZone).MarkViolatorAs.ToString();
			}
			return null;
		}
		set
		{
			Misc.PostureStance markViolatorAs = Misc.PostureStance.Neutral;
			switch (Conversions.ToString(value).ToLower())
			{
			case "hostile":
			case "3":
				markViolatorAs = Misc.PostureStance.Hostile;
				break;
			case "unfriendly":
			case "2":
				markViolatorAs = Misc.PostureStance.Unfriendly;
				break;
			case "1":
			case "friendly":
				markViolatorAs = Misc.PostureStance.Friendly;
				break;
			case "4":
			case "unknown":
				markViolatorAs = Misc.PostureStance.Unknown;
				break;
			case "0":
			case "neutral":
				markViolatorAs = Misc.PostureStance.Neutral;
				break;
			}
			try
			{
				if (myZone.GetType() == typeof(ExclusionZone))
				{
					((ExclusionZone)myZone).MarkViolatorAs = markViolatorAs;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				throw new LuaError(ex.Message);
			}
		}
	}

	[DoNotPrune]
	public LuaTable area
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			foreach (ReferencePoint item in myZone.Area)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["name"] = item.Name;
				val2["guid"] = item.ObjectID;
				val2["longitude"] = item.Longitude;
				val2["latitude"] = item.Latitude;
				val2["highlighted"] = item.IsHighlighted;
				val2["side"] = mySide.Name;
				val2["locked"] = item.IsLocked;
				if (!Information.IsNothing(item.IsRelativeTo))
				{
					val2["bearingtype"] = item.BearingType;
					val2["relativeto"] = item.IsRelativeTo.ObjectID;
				}
				val[num] = val2;
				num++;
			}
			return val;
		}
		set
		{
			List<ReferencePoint> list = new List<ReferencePoint>();
			Side side = null;
			Module_Unit.Unit unit = null;
			bool flag = false;
			list.Clear();
			List<object> list2 = LuaUtility.ToArray(value.GetEnumerator());
			side = mySide;
			if (side == null)
			{
				return;
			}
			foreach (object item in list2)
			{
				object Local_o = RuntimeHelpers.GetObjectValue(item);
				ReferencePoint referencePoint = null;
				if (Local_o.GetType() == typeof(LuaTable))
				{
					Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)Local_o).GetEnumerator());
					if (Information.IsNothing(unit) && dictionary.ContainsKey("RELATIVETO"))
					{
						string text = Conversions.ToString(dictionary["RELATIVETO"]);
						unit = PrivateMethods.ValidateAUBySide(text, mySide);
						if (unit == null)
						{
							throw new LuaError("缺少单元" + text + "从相对方位");
						}
					}
					if (!flag && dictionary.ContainsKey("HIDDEN") && LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary["HIDDEN"])).GetValueOrDefault())
					{
						flag = true;
					}
					referencePoint = LuaReferencePoint.ParseReferencePoint(dictionary, null, ScenarioContext, unit);
					if (!Information.IsNothing(referencePoint))
					{
						list.Add(referencePoint);
					}
					continue;
				}
				if (!Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o.ToString(), StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase))))
				{
					referencePoint = side.RefPoints.First((ReferencePoint s) => string.Equals(s.Name, Local_o.ToString(), StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase));
				}
				if (!Information.IsNothing(referencePoint))
				{
					list.Add(referencePoint);
				}
			}
			myZone.Area = list;
			foreach (ReferencePoint item2 in list)
			{
				if (flag)
				{
					if (side.RefPoints.Contains(item2))
					{
						side.RefPoints.Remove(item2);
					}
				}
				else if (!side.RefPoints.Contains(item2))
				{
					side.RefPoints.Add(item2);
				}
			}
		}
	}

	[DoNotPrune]
	public LuaTable affects
	{
		get
		{
			List<GlobalVariables.ActiveUnitType> list = new List<GlobalVariables.ActiveUnitType>();
			if (myZone.GetType() == typeof(NoNavZone))
			{
				list = ((NoNavZone)myZone).AffectedUnitTypes.ToList();
			}
			else if (myZone.GetType() == typeof(ExclusionZone))
			{
				list = ((ExclusionZone)myZone).AffectedUnitTypes.ToList();
			}
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			foreach (GlobalVariables.ActiveUnitType item in list)
			{
				val[num] = item.ToString();
				num++;
			}
			return val;
		}
		set
		{
			List<GlobalVariables.ActiveUnitType> list = new List<GlobalVariables.ActiveUnitType>();
			list.Clear();
			foreach (object item in LuaUtility.ToArray(value.GetEnumerator()))
			{
				string a = RuntimeHelpers.GetObjectValue(item).ToString();
				GlobalVariables.ActiveUnitType activeUnitType = GlobalVariables.ActiveUnitType.None;
				byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.ActiveUnitType));
				int num = 0;
				while (num < array.Length)
				{
					byte b = array[num];
					if (!string.Equals(a, b.ToString(), StringComparison.OrdinalIgnoreCase))
					{
						GlobalVariables.ActiveUnitType activeUnitType2 = (GlobalVariables.ActiveUnitType)b;
						if (!string.Equals(a, activeUnitType2.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							num = checked(num + 1);
							continue;
						}
					}
					activeUnitType = (GlobalVariables.ActiveUnitType)b;
					break;
				}
				if (activeUnitType != 0)
				{
					list.Add(activeUnitType);
				}
			}
			if (myZone.GetType() == typeof(NoNavZone))
			{
				ObservableList<GlobalVariables.ActiveUnitType> affectedUnitTypes = ((NoNavZone)myZone).AffectedUnitTypes;
				if (Information.IsNothing(list))
				{
					affectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>
					{
						GlobalVariables.ActiveUnitType.Aircraft,
						GlobalVariables.ActiveUnitType.Ship,
						GlobalVariables.ActiveUnitType.Submarine,
						GlobalVariables.ActiveUnitType.Facility
					};
				}
				else
				{
					affectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
					foreach (GlobalVariables.ActiveUnitType item2 in list)
					{
						affectedUnitTypes.Add(item2);
					}
				}
				((NoNavZone)myZone).AffectedUnitTypes = affectedUnitTypes;
			}
			else
			{
				if (!(myZone.GetType() == typeof(ExclusionZone)))
				{
					return;
				}
				ObservableList<GlobalVariables.ActiveUnitType> affectedUnitTypes2 = ((ExclusionZone)myZone).AffectedUnitTypes;
				if (Information.IsNothing(list))
				{
					affectedUnitTypes2 = new ObservableList<GlobalVariables.ActiveUnitType>
					{
						GlobalVariables.ActiveUnitType.Aircraft,
						GlobalVariables.ActiveUnitType.Ship,
						GlobalVariables.ActiveUnitType.Submarine,
						GlobalVariables.ActiveUnitType.Facility
					};
				}
				else
				{
					affectedUnitTypes2 = new ObservableList<GlobalVariables.ActiveUnitType>();
					foreach (GlobalVariables.ActiveUnitType item3 in list)
					{
						affectedUnitTypes2.Add(item3);
					}
				}
				((ExclusionZone)myZone).AffectedUnitTypes = affectedUnitTypes2;
			}
		}
	}

	[DoNotPrune]
	public string areacolor
	{
		get
		{
			return myZone.AreaColor.ToArgb().ToString();
		}
		set
		{
			Color areaColor = Color.FromName(value);
			if (areaColor.IsKnownColor)
			{
				myZone.AreaColor = areaColor;
				return;
			}
			try
			{
				myZone.AreaColor = ColorTranslator.FromHtml("#" + value);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public int landcovertype
	{
		get
		{
			if (myZone.GetType() == typeof(CustomEnvironmentZone))
			{
				return (int)((CustomEnvironmentZone)myZone).TerrainType;
			}
			return 0;
		}
		set
		{
			if (myZone.GetType() == typeof(CustomEnvironmentZone))
			{
				((CustomEnvironmentZone)myZone).TerrainType = (LandCover.LandCoverType)value;
			}
		}
	}

	[DoNotPrune]
	public bool hascustomlandcoverheight
	{
		get
		{
			if (myZone.GetType() == typeof(CustomEnvironmentZone))
			{
				return ((CustomEnvironmentZone)myZone).HasCustomTerrainHeight;
			}
			return false;
		}
	}

	[DoNotPrune]
	public int landcoverheight
	{
		get
		{
			if (myZone.GetType() == typeof(CustomEnvironmentZone))
			{
				return ((CustomEnvironmentZone)myZone).TerrainHeight;
			}
			return 0;
		}
		set
		{
			if (myZone.GetType() == typeof(CustomEnvironmentZone))
			{
				((CustomEnvironmentZone)myZone).TerrainHeight = value;
			}
		}
	}

	[DoNotPrune]
	public int thermallayerceiling
	{
		get
		{
			if (myZone.GetType() == typeof(CustomEnvironmentZone))
			{
				return ((CustomEnvironmentZone)myZone).ThermalLayerCeiling;
			}
			return 0;
		}
		set
		{
			if (myZone.GetType() == typeof(CustomEnvironmentZone))
			{
				((CustomEnvironmentZone)myZone).ThermalLayerCeiling = value;
			}
		}
	}

	[DoNotPrune]
	public int thermallayerfloor
	{
		get
		{
			if (myZone.GetType() == typeof(CustomEnvironmentZone))
			{
				return ((CustomEnvironmentZone)myZone).ThermalLayerFloor;
			}
			return 0;
		}
		set
		{
			if (myZone.GetType() == typeof(CustomEnvironmentZone))
			{
				((CustomEnvironmentZone)myZone).ThermalLayerFloor = value;
			}
		}
	}

	[DoNotPrune]
	public float thermallayerstrength
	{
		get
		{
			if (myZone.GetType() == typeof(CustomEnvironmentZone))
			{
				return ((CustomEnvironmentZone)myZone).LayerStrength;
			}
			return 0f;
		}
		set
		{
			if (myZone.GetType() == typeof(CustomEnvironmentZone))
			{
				((CustomEnvironmentZone)myZone).LayerStrength = value;
			}
		}
	}

	[DoNotPrune]
	public float convergencezoneinterval
	{
		get
		{
			if (myZone.GetType() == typeof(CustomEnvironmentZone))
			{
				return ((CustomEnvironmentZone)myZone).Single_0;
			}
			return 0f;
		}
		set
		{
			if (myZone.GetType() == typeof(CustomEnvironmentZone))
			{
				((CustomEnvironmentZone)myZone).Single_0 = value;
			}
		}
	}

	[DoNotPrune]
	public LuaTable weatherprofile
	{
		get
		{
			if (myZone.GetType() == typeof(CustomEnvironmentZone))
			{
				LuaTable obj = LuaSandBox.Singleton().CreateTable();
				CustomEnvironmentZone customEnvironmentZone = (CustomEnvironmentZone)myZone;
				obj["temp"] = customEnvironmentZone.Weather.AverageTemp;
				obj["rainfall"] = customEnvironmentZone.Weather.RainfallRate;
				obj["undercloud"] = customEnvironmentZone.Weather.FractionUnderRain;
				obj["seastate"] = customEnvironmentZone.Weather.SeaState;
				return obj;
			}
			return null;
		}
		set
		{
			if (myZone.GetType() == typeof(CustomEnvironmentZone))
			{
				CustomEnvironmentZone customEnvironmentZone = (CustomEnvironmentZone)myZone;
				Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(value.GetEnumerator());
				if (dictionary.ContainsKey("TEMP") && double.TryParse(Conversions.ToString(dictionary["TEMP"]), out var result))
				{
					customEnvironmentZone.Weather.AverageTemp = result;
				}
				if (dictionary.ContainsKey("RAINFALL") && float.TryParse(Conversions.ToString(dictionary["RAINFALL"]), out var result2))
				{
					customEnvironmentZone.Weather.RainfallRate = result2;
				}
				if (dictionary.ContainsKey("UNDERCLOUD") && float.TryParse(Conversions.ToString(dictionary["UNDERCLOUD"]), out var result3))
				{
					customEnvironmentZone.Weather.FractionUnderRain = result3;
				}
				if (dictionary.ContainsKey("SEASTATE") && int.TryParse(Conversions.ToString(dictionary["SEASTATE"]), out var result4))
				{
					customEnvironmentZone.Weather.SeaState = result4;
				}
			}
		}
	}

	public LuaWrapper_Zone(Zone zone_0, Scenario scenario_0, Side side_0)
	{
		myZone = zone_0;
		ScenarioContext = scenario_0;
		mySide = side_0;
	}

	[DoNotPrune]
	public override string ToString()
	{
		return string.Concat("zone {\r\n guid = '" + guid + "', \r\n description = '" + description + "', \r\n isactive = '" + isactive.ToString() + "', \r\n area = '" + area.ToString() + "', \r\n type = '" + myZone.GetType().ToString() + "'\r\n", "}");
	}
}
