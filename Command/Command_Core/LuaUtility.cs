using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Command_Core.Lua;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core;

[StandardModule]
public sealed class LuaUtility
{
	public static List<object> ToArray(IDictionaryEnumerator idictionaryEnumerator_0)
	{
		List<Tuple<int, object>> list = new List<Tuple<int, object>>();
		while (idictionaryEnumerator_0.MoveNext())
		{
			int item = Conversions.ToInteger(idictionaryEnumerator_0.Key);
			list.Add(new Tuple<int, object>(item, RuntimeHelpers.GetObjectValue(idictionaryEnumerator_0.Value)));
		}
		return (from s in list
			orderby s.Item1
			select s.Item2).ToList();
	}

	public static Dictionary<string, object> ToDictUpper(IDictionaryEnumerator idictionaryEnumerator_0)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		while (idictionaryEnumerator_0.MoveNext())
		{
			string text = Conversions.ToString(idictionaryEnumerator_0.Key).ToUpper();
			if (Operators.CompareString(text, "LAT", TextCompare: false) == 0)
			{
				text = "LATITUDE";
			}
			if (Operators.CompareString(text, "LON", TextCompare: false) == 0)
			{
				text = "LONGITUDE";
			}
			if (Operators.CompareString(text, "LONG", TextCompare: false) == 0)
			{
				text = "LONGITUDE";
			}
			if (Operators.CompareString(text, "ALT", TextCompare: false) == 0)
			{
				text = "ALTITUDE";
			}
			if (Operators.CompareString(text, "OBJECTID", TextCompare: false) == 0)
			{
				text = "GUID";
			}
			dictionary[text] = RuntimeHelpers.GetObjectValue(idictionaryEnumerator_0.Value);
		}
		return dictionary;
	}

	public static Dictionary<string, object> ToDictLower(IDictionaryEnumerator idictionaryEnumerator_0)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		while (idictionaryEnumerator_0.MoveNext())
		{
			string key = Conversions.ToString(idictionaryEnumerator_0.Key).ToLower();
			dictionary[key] = RuntimeHelpers.GetObjectValue(idictionaryEnumerator_0.Value);
		}
		return dictionary;
	}

	public static void FromDict(Dictionary<string, object> dictionary_0, LuaTable luaTable_0)
	{
		IDictionaryEnumerator dictionaryEnumerator = dictionary_0.GetEnumerator();
		while (dictionaryEnumerator.MoveNext())
		{
			luaTable_0[Conversions.ToString(dictionaryEnumerator.Key).ToLower()] = RuntimeHelpers.GetObjectValue(dictionaryEnumerator.Value);
		}
	}

	public static void FromList(IEnumerable<object> ienumerable_0, LuaTable luaTable_0)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			luaTable_0[luaTable_0.Keys.Count + 1] = RuntimeHelpers.GetObjectValue(enumerator.Current);
		}
	}

	public static bool ParseUnitDict(ref Dictionary<string, object> dictionary_0)
	{
		IDictionaryEnumerator dictionaryEnumerator = new Dictionary<string, object>(dictionary_0).GetEnumerator();
		while (dictionaryEnumerator.MoveNext())
		{
			string text = Conversions.ToString(dictionaryEnumerator.Key).ToUpper();
			RuntimeHelpers.GetObjectValue(dictionaryEnumerator.Value);
			if (Operators.CompareString(text, "UNIT", TextCompare: false) == 0)
			{
				text = "UNITNAME";
			}
			if (Operators.CompareString(text, "NAME", TextCompare: false) == 0)
			{
				text = "UNITNAME";
			}
			if (Operators.CompareString(text, "UNITNAMEORID", TextCompare: false) == 0)
			{
				text = "UNITNAME";
			}
			if (Operators.CompareString(text, "FROMUNIT", TextCompare: false) == 0)
			{
				text = "FROMUNITNAME";
			}
			if (Operators.CompareString(text, "FROMNAME", TextCompare: false) == 0)
			{
				text = "FROMUNITNAME";
			}
			if (Operators.CompareString(text, "FROMUNITNAMEORID", TextCompare: false) == 0)
			{
				text = "FROMUNITNAME";
			}
			if (Operators.CompareString(text, "TOUNIT", TextCompare: false) == 0)
			{
				text = "TOUNITNAME";
			}
			if (Operators.CompareString(text, "TONAME", TextCompare: false) == 0)
			{
				text = "TOUNITNAME";
			}
			if (Operators.CompareString(text, "TOUNITNAMEORID", TextCompare: false) == 0)
			{
				text = "TOUNITNAME";
			}
			dictionary_0[text] = RuntimeHelpers.GetObjectValue(dictionaryEnumerator.Value);
		}
		return true;
	}

	public static bool ParseSideDict(ref Dictionary<string, object> dictionary_0)
	{
		IDictionaryEnumerator dictionaryEnumerator = new Dictionary<string, object>(dictionary_0).GetEnumerator();
		while (dictionaryEnumerator.MoveNext())
		{
			string text = Conversions.ToString(dictionaryEnumerator.Key).ToUpper();
			RuntimeHelpers.GetObjectValue(dictionaryEnumerator.Value);
			if (Operators.CompareString(text, "NAME", TextCompare: false) == 0)
			{
				text = "SIDE";
			}
			dictionary_0[text] = RuntimeHelpers.GetObjectValue(dictionaryEnumerator.Value);
		}
		return true;
	}

	public static double DMS_To_DecimalDegrees(double double_0, double double_1, double double_2)
	{
		return double_0 + double_1 / 60.0 + double_2 / 3600.0;
	}

	public static double ParseLatitudeString(string string_0)
	{
		try
		{
			string left = string_0.Substring(0, 1).ToUpper();
			if (Operators.CompareString(left, "S", TextCompare: false) == 0 || Operators.CompareString(left, "N", TextCompare: false) == 0)
			{
				string_0 = string_0.Substring(1, string_0.Length - 1);
			}
			List<string> list = (from s in string_0.Split('.')
				select s.Trim()).ToList();
			double num4;
			switch (list.Count)
			{
			default:
				throw new LuaError("纬度'" + string_0 + "'很难理解（给出的数字太多）。纬度字符串的示例是'N 60.20.10'。");
			case 1:
				num4 = Conversions.ToInteger(string_0);
				goto IL_017c;
			case 2:
				num4 = XmlConvert.ToDouble(string_0);
				goto IL_017c;
			case 3:
				{
					double num = XmlConvert.ToDouble(list[0]);
					double num2 = XmlConvert.ToDouble(list[1]);
					double num3 = XmlConvert.ToDouble(list[2]);
					if (num < 0.0 || num2 < 0.0 || !(num3 >= 0.0))
					{
						break;
					}
					if (num2 < 60.0 && num3 < 60.0)
					{
						num4 = DMS_To_DecimalDegrees(num, num2, num3);
						goto IL_017c;
					}
					throw new LuaError("纬度'" + string_0 + "'很难理解（分钟或秒数大于或等于60）。纬度字符串的示例是'N 60.20.10'。");
				}
				IL_017c:
				if (Operators.CompareString(left, "S", TextCompare: false) == 0)
				{
					num4 = 0.0 - num4;
				}
				return num4;
			}
			throw new LuaError("纬度'" + string_0 + "'很难理解（负数！）。纬度字符串的示例是'N 60.20.10'。");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw new LuaError("纬度'" + string_0 + "'很难理解。纬度字符串的示例是'N 60.20.10'。");
		}
	}

	public static double ParseLongitudeString(string string_0)
	{
		try
		{
			string left = string_0.Substring(0, 1).ToUpper();
			if (Operators.CompareString(left, "E", TextCompare: false) == 0 || Operators.CompareString(left, "W", TextCompare: false) == 0)
			{
				string_0 = string_0.Substring(1, string_0.Length - 1);
			}
			List<string> list = (from s in string_0.Split('.')
				select s.Trim()).ToList();
			double num4;
			switch (list.Count)
			{
			default:
				throw new LuaError("经度'" + string_0 + "'很难理解（给出的数字太多）。经度字符串的例子是'E 60.20.10'。");
			case 1:
				num4 = Conversions.ToInteger(string_0);
				goto IL_017c;
			case 2:
				num4 = XmlConvert.ToDouble(string_0);
				goto IL_017c;
			case 3:
				{
					double num = XmlConvert.ToDouble(list[0]);
					double num2 = XmlConvert.ToDouble(list[1]);
					double num3 = XmlConvert.ToDouble(list[2]);
					if (num < 0.0 || num2 < 0.0 || !(num3 >= 0.0))
					{
						break;
					}
					if (num2 < 60.0 && num3 < 60.0)
					{
						num4 = DMS_To_DecimalDegrees(num, num2, num3);
						goto IL_017c;
					}
					throw new LuaError("经度'" + string_0 + "'很难理解（分钟或秒数大于或等于60）。经度字符串的例子是'E 60.20.10'。");
				}
				IL_017c:
				if (Operators.CompareString(left, "W", TextCompare: false) == 0)
				{
					num4 = 0.0 - num4;
				}
				return num4;
			}
			throw new LuaError("经度'" + string_0 + "'很难理解（负数！）。经度字符串的例子是'E 60.20.10'。");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw new LuaError("经度'" + string_0 + "'很难理解。经度字符串的例子是'E 60.20.10'。");
		}
	}

	public static bool? ParseBoolean(object object_0)
	{
		if (object_0 == null)
		{
			return null;
		}
		try
		{
			if (object_0 is string)
			{
				if (Operators.CompareString(Conversions.ToString(object_0).ToLower(), "inherit", TextCompare: false) == 0)
				{
					return null;
				}
				return bool.Parse(Conversions.ToString(object_0).ToLower().Replace("yes", "true")
					.Replace("no", "false")
					.Replace("true", "true")
					.Replace("false", "false"));
			}
			if (object_0 is int)
			{
				return Conversions.ToInteger(object_0) != 0;
			}
			if (object_0 is bool)
			{
				return (bool?)object_0;
			}
			if (object_0 is double)
			{
				return Conversions.ToDouble(object_0) != 0.0;
			}
			if (!(object_0 is long))
			{
				throw new LuaError("Lua无法理解'" + object_0.ToString() + "' as a true/false value. Please use 1 or 0.");
			}
			return Conversions.ToLong(object_0) != 0;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw new LuaError("Lua无法理解'" + object_0.ToString() + "' as a true/false value. Please use 1 or 0.");
		}
	}

	public static double? QueryLatitude(Dictionary<string, object> dictionary_0)
	{
		object obj = null;
		if (dictionary_0.ContainsKey("LATITUDE"))
		{
			obj = RuntimeHelpers.GetObjectValue(dictionary_0["LATITUDE"]);
		}
		return QueryLatitudeObject(RuntimeHelpers.GetObjectValue(obj));
	}

	public static double? QueryLatitudeObject(object object_0)
	{
		double? result;
		if (object_0 == null)
		{
			result = null;
		}
		else
		{
			double value = 0.0;
			if (object_0 is string)
			{
				value = ParseLatitudeString(Conversions.ToString(object_0));
			}
			else if (object_0 is double)
			{
				value = Conversions.ToDouble(object_0);
			}
			else if (object_0 is int)
			{
				value = Conversions.ToDouble(object_0);
			}
			else if (object_0 is long)
			{
				value = Conversions.ToDouble(object_0);
			}
			result = value;
		}
		return result;
	}

	public static double? QueryLongitude(Dictionary<string, object> dictionary_0)
	{
		object obj = null;
		if (dictionary_0.ContainsKey("LONGITUDE"))
		{
			obj = RuntimeHelpers.GetObjectValue(dictionary_0["LONGITUDE"]);
		}
		return QueryLongitudeObject(RuntimeHelpers.GetObjectValue(obj));
	}

	public static double? QueryLongitudeObject(object object_0)
	{
		double? result;
		if (object_0 == null)
		{
			result = null;
		}
		else
		{
			double value = 0.0;
			if (object_0 is string)
			{
				value = ParseLongitudeString(Conversions.ToString(object_0));
			}
			else if (object_0 is double)
			{
				value = Conversions.ToDouble(object_0);
			}
			else if (object_0 is int)
			{
				value = Conversions.ToDouble(object_0);
			}
			else if (object_0 is long)
			{
				value = Conversions.ToDouble(object_0);
			}
			result = value;
		}
		return result;
	}

	public static Side QuerySideObject(object object_0, Scenario scenario_0)
	{
		try
		{
			if (scenario_0.Sides_ReadOnly.Length == 0)
			{
				return null;
			}
			if (object_0 is string)
			{
				string text = Conversions.ToString(object_0);
				if (Operators.CompareString(text.ToUpper(), "PlayerSide".ToUpper(), TextCompare: false) == 0)
				{
					return scenario_0.GetCurrentSide();
				}
				Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
				Side[] array = sides_ReadOnly;
				foreach (Side side in array)
				{
					if (string.Equals(side.Name, text, StringComparison.OrdinalIgnoreCase) || string.Equals(side.ObjectID, text, StringComparison.OrdinalIgnoreCase))
					{
						return side;
					}
				}
				return null;
			}
			return null;
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

	public static Side QuerySide(Dictionary<string, object> dictionary_0, Scenario scenario_0)
	{
		try
		{
			if (dictionary_0.ContainsKey("SIDE"))
			{
				return QuerySideObject(RuntimeHelpers.GetObjectValue(dictionary_0["SIDE"]), scenario_0);
			}
			if (!dictionary_0.ContainsKey("SIDENAME"))
			{
				throw new LuaError("缺少'分方'请选择PlayerSide之一，" + string.Join(", ", scenario_0.Sides_ReadOnly.Select((Side s) => s.Name)));
			}
			return QuerySideObject(RuntimeHelpers.GetObjectValue(dictionary_0["SIDENAME"]), scenario_0);
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

	public static Side QuerySensorSide(Dictionary<string, object> dictionary_0, Scenario scenario_0)
	{
		if (dictionary_0.ContainsKey("SENSORSIDE"))
		{
			return QuerySideObject(RuntimeHelpers.GetObjectValue(dictionary_0["SENSORSIDE"]), scenario_0);
		}
		if (!dictionary_0.ContainsKey("SENSORSIDENAME"))
		{
			throw new LuaError("Missing 'SensorSide' please choose one of PlayerSide, " + string.Join(", ", scenario_0.Sides_ReadOnly.Select((Side s) => s.Name)));
		}
		return QuerySideObject(RuntimeHelpers.GetObjectValue(dictionary_0["SENSORSIDENAME"]), scenario_0);
	}

	public static Side QueryTargetSide(Dictionary<string, object> dictionary_0, Scenario scenario_0)
	{
		if (dictionary_0.ContainsKey("TARGESIDE"))
		{
			return QuerySideObject(RuntimeHelpers.GetObjectValue(dictionary_0["TARGESIDE"]), scenario_0);
		}
		if (!dictionary_0.ContainsKey("TARGESIDENAME"))
		{
			throw new LuaError("Missing 'TargetSide' please choose one of PlayerSide, " + string.Join(", ", scenario_0.Sides_ReadOnly.Select((Side s) => s.Name)));
		}
		return QuerySideObject(RuntimeHelpers.GetObjectValue(dictionary_0["TARGESIDENAME"]), scenario_0);
	}

	public static Side QuerySideOrFail(Dictionary<string, object> dictionary_0, Scenario scenario_0)
	{
		return QuerySide(dictionary_0, scenario_0) ?? throw new LuaError("分方'" + Conversions.ToString(dictionary_0["SIDE"]) + "'不存在请选择PlayerSide之一，" + string.Join(", ", scenario_0.Sides_ReadOnly.Select((Side s) => s.Name)));
	}

	public static ActiveUnit_AI.AircraftAltitudePreset? QueryAltitudePresetObject(object object_0)
	{
		ActiveUnit_AI.AircraftAltitudePreset? result;
		if (object_0 is string)
		{
			string text = Conversions.ToString(object_0).ToUpper();
			text.Replace("-", "");
			ActiveUnit_AI.AircraftAltitudePreset aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
			switch (text)
			{
			case "HIGH25000":
				aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_5;
				goto IL_02a5;
			case "HIGH36000":
			case "HIGH":
				aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_6;
				goto IL_02a5;
			case "MIN":
			case "MINALTITUDE":
			case "MINALT":
				aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MinAltitude;
				goto IL_02a5;
			case "LOW2000":
				aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low2000;
				goto IL_02a5;
			case "MED":
			case "MEDIUM12000":
			case "MED12000":
				aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_4;
				goto IL_02a5;
			case "MAX":
			case "MAXALT":
			case "MAXALTITUDE":
				aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude;
				goto IL_02a5;
			default:
				result = null;
				break;
			case "LOW1000":
			case "LOW":
				{
					aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low1000;
					goto IL_02a5;
				}
				IL_02a5:
				result = aircraftAltitudePreset;
				break;
			}
		}
		else
		{
			result = null;
		}
		return result;
	}

	public static float? QueryAltitudeObject(object object_0)
	{
		float value = 0f;
		string text;
		float? result2;
		if (object_0 is string)
		{
			text = Conversions.ToString(object_0).ToUpper();
			text.Replace("-", "");
			if (!float.TryParse(text, out var _))
			{
				ActiveUnit_AI.AircraftAltitudePreset aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
				switch (text)
				{
				case "HIGH25000":
					aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_5;
					goto IL_02eb;
				case "HIGH36000":
				case "HIGH":
					aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_6;
					goto IL_02eb;
				case "MIN":
				case "MINALTITUDE":
				case "MINALT":
					aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MinAltitude;
					goto IL_02eb;
				case "LOW2000":
					aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low2000;
					goto IL_02eb;
				case "MED":
				case "MEDIUM12000":
				case "MED12000":
					aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_4;
					goto IL_02eb;
				case "MAX":
				case "MAXALT":
				case "MAXALTITUDE":
					aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude;
					goto IL_02eb;
				default:
					if (text.Contains("FT"))
					{
						break;
					}
					if (text.Contains("M"))
					{
						goto IL_0415;
					}
					goto IL_02eb;
				case "LOW1000":
				case "LOW":
					{
						aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low1000;
						goto IL_02eb;
					}
					IL_02eb:
					value = (int)aircraftAltitudePreset;
					goto IL_040a;
				}
				value = float.Parse(text.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture) * 0.3048f;
				result2 = value;
				goto IL_044f;
			}
			value = (text.Contains("FT") ? (float.Parse(text.Replace("FT", "").Replace("M", "").Trim()) * 0.3048f) : float.Parse(text.Replace("FT", "").Replace("M", "").Trim()));
		}
		else if (object_0 is double)
		{
			value = Conversions.ToSingle(object_0);
		}
		else if (object_0 is float)
		{
			value = Conversions.ToSingle(object_0);
		}
		else if (object_0 is int)
		{
			value = Conversions.ToSingle(object_0);
		}
		else if (object_0 is long)
		{
			value = Conversions.ToSingle(object_0);
		}
		goto IL_040a;
		IL_0415:
		value = float.Parse(text.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture);
		result2 = value;
		goto IL_044f;
		IL_040a:
		result2 = value;
		goto IL_044f;
		IL_044f:
		return result2;
	}

	public static float? QueryAltitude(Dictionary<string, object> dictionary_0)
	{
		object obj = null;
		if (dictionary_0.ContainsKey("ALTITUDE"))
		{
			obj = RuntimeHelpers.GetObjectValue(dictionary_0["ALTITUDE"]);
		}
		else if (dictionary_0.ContainsKey("ALT"))
		{
			obj = RuntimeHelpers.GetObjectValue(dictionary_0["ALT"]);
		}
		if (obj == null)
		{
			return null;
		}
		return QueryAltitudeObject(RuntimeHelpers.GetObjectValue(obj));
	}

	public static ActiveUnit_AI.SubmarineDepthPreset? QueryDepthPresetObject(object object_0)
	{
		ActiveUnit_AI.SubmarineDepthPreset? result;
		if (object_0 is string)
		{
			string text = Conversions.ToString(object_0).ToUpper();
			text.Replace("-", "");
			ActiveUnit_AI.SubmarineDepthPreset submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
			switch (text)
			{
			case "PERISCOPE":
				submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
				goto IL_0196;
			case "SURFACE":
				submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Surface;
				goto IL_0196;
			case "MAX":
			case "MAXDEPTH":
				submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.MaxDepth;
				goto IL_0196;
			case "OVER":
			case "OVERLAYER":
				submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.OverLayer;
				goto IL_0196;
			case "SHALLOW":
				submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Shallow;
				goto IL_0196;
			default:
				result = null;
				break;
			case "UNDER":
			case "UNDERLAYER":
				{
					submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.UnderLayer;
					goto IL_0196;
				}
				IL_0196:
				result = submarineDepthPreset;
				break;
			}
		}
		else
		{
			result = null;
		}
		return result;
	}

	public static float? QueryDepthObject(object object_0)
	{
		float value = 0f;
		string text;
		float? result2;
		if (object_0 is string)
		{
			text = Conversions.ToString(object_0).ToUpper();
			text.Replace("-", "");
			if (!float.TryParse(text, out var _))
			{
				ActiveUnit_AI.SubmarineDepthPreset submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
				switch (text)
				{
				case "PERISCOPE":
					submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
					goto IL_01db;
				case "SURFACE":
					submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Surface;
					goto IL_01db;
				case "MAX":
				case "MAXDEPTH":
					submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.MaxDepth;
					goto IL_01db;
				case "OVER":
				case "OVERLAYER":
					submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.OverLayer;
					goto IL_01db;
				case "SHALLOW":
					submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Shallow;
					goto IL_01db;
				default:
					if (text.Contains("FT"))
					{
						break;
					}
					if (text.Contains("M"))
					{
						goto IL_034c;
					}
					goto IL_01db;
				case "UNDER":
				case "UNDERLAYER":
					{
						submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.UnderLayer;
						goto IL_01db;
					}
					IL_01db:
					value = (int)submarineDepthPreset;
					goto IL_0341;
				}
				value = float.Parse(text.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture) * 0.3048f;
				result2 = Math.Abs(value) * -1f;
				goto IL_0391;
			}
			value = (text.Contains("FT") ? (float.Parse(text.Replace("FT", "").Replace("M", "").Trim()) * 0.3048f) : float.Parse(text.Replace("FT", "").Replace("M", "").Trim()));
			value = Math.Abs(value) * -1f;
		}
		else if (object_0 is double)
		{
			value = Math.Abs(Conversions.ToSingle(object_0)) * -1f;
		}
		else if (object_0 is float)
		{
			value = Math.Abs(Conversions.ToSingle(object_0)) * -1f;
		}
		else if (object_0 is int)
		{
			value = Math.Abs(Conversions.ToSingle(object_0)) * -1f;
		}
		else if (object_0 is long)
		{
			value = Math.Abs(Conversions.ToSingle(object_0)) * -1f;
		}
		goto IL_0341;
		IL_0391:
		return result2;
		IL_034c:
		value = float.Parse(text.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture);
		result2 = Math.Abs(value) * -1f;
		goto IL_0391;
		IL_0341:
		result2 = value;
		goto IL_0391;
	}

	public static float? QueryDepth(Dictionary<string, object> dictionary_0)
	{
		object obj = null;
		if (dictionary_0.ContainsKey("DEPTH"))
		{
			obj = RuntimeHelpers.GetObjectValue(dictionary_0["DEPTH"]);
		}
		if (obj == null)
		{
			return null;
		}
		return QueryDepthObject(RuntimeHelpers.GetObjectValue(obj));
	}

	public static ActiveUnit.Throttle? QueryThrottle(Dictionary<string, object> dictionary_0)
	{
		if (dictionary_0.ContainsKey("THROTTLE"))
		{
			return QueryThrottleObject(Conversions.ToString(dictionary_0["THROTTLE"]));
		}
		return null;
	}

	public static ActiveUnit.Throttle? QueryThrottleObject(string string_0)
	{
		ActiveUnit.Throttle throttle = ActiveUnit.Throttle.FullStop;
		switch (string_0.ToLower())
		{
		case "0":
		case "hover":
		case "fullstop":
		case "stop":
			throttle = ActiveUnit.Throttle.FullStop;
			break;
		case "2":
		case "cruise":
			throttle = ActiveUnit.Throttle.Cruise;
			break;
		case "4":
		case "flank":
		case "afterburner":
			throttle = ActiveUnit.Throttle.Flank;
			break;
		case "military":
		case "3":
		case "full":
			throttle = ActiveUnit.Throttle.Full;
			break;
		default:
			throw new LuaError("油门无效" + string_0);
		case "1":
		case "loiter":
		case "creep":
			throttle = ActiveUnit.Throttle.Loiter;
			break;
		}
		return throttle;
	}

	public static Group QueryGroupObject(object object_0, Side side_0, Scenario scenario_0)
	{
		if (object_0 is string)
		{
			string text = Conversions.ToString(object_0);
			if (scenario_0.ActiveUnits.ContainsKey(text))
			{
				ActiveUnit activeUnit = scenario_0.ActiveUnits[text];
				if (activeUnit is Group)
				{
					return (Group)activeUnit;
				}
				throw new LuaError("无法理解'" + object_0.ToString() + "' 作为一个编队。这是guid'" + activeUnit.Name + "'这不是一个编队。");
			}
			return (Group)side_0.Units.FirstOrDefault((ActiveUnit s) => s.IsGroup && string.Equals(s.Name, text, StringComparison.OrdinalIgnoreCase));
		}
		throw new LuaError("无法理解'" + object_0.ToString() + "' 作为一个编队。");
	}

	public static Group QueryGroup(Dictionary<string, object> dictionary_0, Side side_0, Scenario scenario_0)
	{
		object obj = null;
		if (dictionary_0.ContainsKey("GROUP"))
		{
			obj = RuntimeHelpers.GetObjectValue(dictionary_0["GROUP"]);
		}
		if (obj == null)
		{
			return null;
		}
		return QueryGroupObject(RuntimeHelpers.GetObjectValue(obj), side_0, scenario_0);
	}

	public static string QueryUnit(Dictionary<string, object> dictionary_0, Scenario scenario_0)
	{
		ActiveUnit activeUnit = null;
		Side side = null;
		ParseUnitDict(ref dictionary_0);
		if (dictionary_0.ContainsKey("GUID"))
		{
			string text3;
			try
			{
				text3 = Conversions.ToString(dictionary_0["GUID"]);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("Guid必须是一个字符串");
			}
			try
			{
				activeUnit = scenario_0.ActiveUnits[text3];
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				string result = "找不到guid" + text3;
				ProjectData.ClearProjectError();
				return result;
			}
			if (activeUnit == null)
			{
				dictionary_0.Remove("GUID");
			}
		}
		else if (dictionary_0.ContainsKey("UNITNAME"))
		{
			string text2;
			try
			{
				text2 = Conversions.ToString(dictionary_0["UNITNAME"]);
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				throw new LuaError("名称必须是字符串");
			}
			if (dictionary_0.ContainsKey("SIDE"))
			{
				string text4;
				try
				{
					text4 = Conversions.ToString(dictionary_0["SIDE"]);
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					throw new LuaError("分方必须是一个字符串");
				}
				try
				{
					side = QuerySide(dictionary_0, scenario_0);
				}
				catch (Exception projectError5)
				{
					ProjectData.SetProjectError(projectError5);
					string result2 = "找不到分方'" + text4 + "'";
					ProjectData.ClearProjectError();
					return result2;
				}
				try
				{
					activeUnit = side.Units.First((ActiveUnit s) => string.Equals(s.Name, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text2, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception projectError6)
				{
					ProjectData.SetProjectError(projectError6);
					string result3 = "找不到单元'" + text2 + "' 分方 '" + text4 + "'";
					ProjectData.ClearProjectError();
					return result3;
				}
				dictionary_0["GUID"] = activeUnit.ObjectID;
			}
			else
			{
				try
				{
					activeUnit = scenario_0.ActiveUnits_List.First((ActiveUnit s) => string.Equals(s.Name, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text2, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception projectError7)
				{
					ProjectData.SetProjectError(projectError7);
					string result4 = "找不到单元'" + text2 + "'";
					ProjectData.ClearProjectError();
					return result4;
				}
				dictionary_0["GUID"] = activeUnit.ObjectID;
				dictionary_0["SIDE"] = activeUnit.GetUnitSide().Name;
			}
		}
		return "";
	}

	public static bool QueryBaseUnit(Dictionary<string, object> dictionary_0, Scenario scenario_0)
	{
		ActiveUnit activeUnit = null;
		Side side = null;
		if (dictionary_0.ContainsKey("BASE"))
		{
			side = QuerySideOrFail(dictionary_0, scenario_0);
			string text = "";
			try
			{
				text = Conversions.ToString(dictionary_0["BASE"]);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("Base必须是一个字符串");
			}
			try
			{
				activeUnit = scenario_0.ActiveUnits[text];
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
				return false;
			}
			if (side != null && activeUnit != null && !string.Equals(activeUnit.GetUnitSide().ObjectID, side.ObjectID, StringComparison.OrdinalIgnoreCase))
			{
				activeUnit = null;
			}
			if (activeUnit == null)
			{
				try
				{
					activeUnit = scenario_0.ActiveUnits_List.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, text, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					ProjectData.ClearProjectError();
					return false;
				}
			}
			if (activeUnit == null)
			{
				dictionary_0.Remove("BASE");
				return false;
			}
			dictionary_0["BASE"] = activeUnit.ObjectID;
		}
		return true;
	}

	internal static ActiveUnit ValidAsUnit(string string_0, Scenario scenario_0, ref Side side_0)
	{
		ActiveUnit result = null;
		try
		{
			if (side_0 == null)
			{
				result = scenario_0.ActiveUnits_List.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, string_0, StringComparison.OrdinalIgnoreCase));
				return result;
			}
			result = side_0.Units.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, string_0, StringComparison.OrdinalIgnoreCase));
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal static Contact ValidAsContact(string string_0, Scenario scenario_0, ref Side side_0)
	{
		Contact contact = null;
		bool flag = false;
		try
		{
			if (side_0 == null)
			{
				Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
				Side[] array = sides_ReadOnly;
				foreach (Side side in array)
				{
					if (!flag)
					{
						foreach (Contact contacts_ in side.Contacts_List)
						{
							if (string.Equals(contacts_.ObjectID, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(contacts_.Name, string_0, StringComparison.OrdinalIgnoreCase))
							{
								contact = contacts_;
								flag = true;
								break;
							}
						}
						if (contact != null)
						{
							continue;
						}
						foreach (string key in side.m_InfoFacade.Keys)
						{
							Contact contact2 = side.m_InfoFacade[key];
							if (string.Equals(contact2.ObjectID, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(contact2.Name, string_0, StringComparison.OrdinalIgnoreCase))
							{
								contact = contact2;
								flag = true;
								break;
							}
						}
						continue;
					}
					return contact;
				}
				return contact;
			}
			foreach (Contact contacts_2 in side_0.Contacts_List)
			{
				if (string.Equals(contacts_2.ObjectID, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(contacts_2.Name, string_0, StringComparison.OrdinalIgnoreCase))
				{
					contact = contacts_2;
					flag = true;
					break;
				}
			}
			if (contact == null)
			{
				foreach (string key2 in side_0.m_InfoFacade.Keys)
				{
					Contact contact3 = side_0.m_InfoFacade[key2];
					if (string.Equals(contact3.ObjectID, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(contact3.Name, string_0, StringComparison.OrdinalIgnoreCase))
					{
						contact = contact3;
						flag = true;
						return contact;
					}
				}
				return contact;
			}
			return contact;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
			return contact;
		}
	}

	internal static long ParseDateAsSeconds(string string_0)
	{
		double a = 0.0;
		string[] array = Strings.Split(string_0, ":");
		if (array.Count() == 4)
		{
			int num = array.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				if (array[i] == "")
				{
					array[i] = "0";
				}
			}
			a = new TimeSpan(Conversions.ToInteger(array[0]), Conversions.ToInteger(array[1]), Conversions.ToInteger(array[2]), Conversions.ToInteger(array[3])).TotalSeconds;
		}
		return (long)Math.Round(a);
	}

	internal static (int DayValue, int MonthValue, int YearValue) ParseDate_DDMMYYYY(string string_0)
	{
		string value = string.Empty;
		if (string_0.Contains(":"))
		{
			value = ":";
		}
		else if (string_0.Contains("."))
		{
			value = ".";
		}
		if (string.IsNullOrEmpty(value))
		{
			throw new LuaError("解析提供的日期值时出错：" + string_0 + " - 分隔符必须是（.）或（:)");
		}
		int item;
		int item2;
		int item3;
		try
		{
			item = Conversions.ToInteger(string_0.Split(Conversions.ToChar(value))[0]);
			item2 = Conversions.ToInteger(string_0.Split(Conversions.ToChar(value))[1]);
			item3 = Conversions.ToInteger(string_0.Split(Conversions.ToChar(value))[2]);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new LuaError("解析提供的日期值时出错：" + string_0 + " - 错误：" + ex2.Message);
		}
		return (DayValue: item, MonthValue: item2, YearValue: item3);
	}

	internal static (int DayValue, int MonthValue, int YearValue) ParseDate_MMDDYYYY(string string_0)
	{
		string value = string.Empty;
		if (string_0.Contains(":"))
		{
			value = ":";
		}
		else if (string_0.Contains("."))
		{
			value = ".";
		}
		if (string.IsNullOrEmpty(value))
		{
			throw new LuaError("解析提供的日期值时出错：" + string_0 + " - 分隔符必须是（.）或（:)");
		}
		int item;
		int item2;
		int item3;
		try
		{
			item = Conversions.ToInteger(string_0.Split(Conversions.ToChar(value))[0]);
			item2 = Conversions.ToInteger(string_0.Split(Conversions.ToChar(value))[1]);
			item3 = Conversions.ToInteger(string_0.Split(Conversions.ToChar(value))[2]);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new LuaError("解析提供的日期值时出错：" + string_0 + " - 错误：" + ex2.Message);
		}
		return (DayValue: item2, MonthValue: item, YearValue: item3);
	}

	internal static (int DayValue, int MonthValue, int YearValue) ParseDate_YYYYMMDD(string string_0)
	{
		string value = string.Empty;
		if (string_0.Contains(":"))
		{
			value = ":";
		}
		else if (string_0.Contains("."))
		{
			value = ".";
		}
		if (string.IsNullOrEmpty(value))
		{
			throw new LuaError("解析提供的日期值时出错：" + string_0 + " - 分隔符必须是（.）或（:)");
		}
		int item;
		int item2;
		int item3;
		try
		{
			item = Conversions.ToInteger(string_0.Split(Conversions.ToChar(value))[0]);
			item2 = Conversions.ToInteger(string_0.Split(Conversions.ToChar(value))[1]);
			item3 = Conversions.ToInteger(string_0.Split(Conversions.ToChar(value))[2]);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new LuaError("解析提供的日期值时出错：" + string_0 + " - 错误：" + ex2.Message);
		}
		return (DayValue: item3, MonthValue: item2, YearValue: item);
	}

	internal static (int HourValue, int MinuteValue, int SecondValue) ParseTime_HHMMSS(string string_0)
	{
		string value = string.Empty;
		if (string_0.Contains(":"))
		{
			value = ":";
		}
		else if (string_0.Contains("."))
		{
			value = ".";
		}
		if (string.IsNullOrEmpty(value))
		{
			throw new LuaError("解析提供的时间值时出错：" + string_0 + " - 分隔符必须是（.）或（:)");
		}
		int item;
		int item2;
		int item3;
		try
		{
			item = Conversions.ToInteger(string_0.Split(Conversions.ToChar(value))[0]);
			item2 = Conversions.ToInteger(string_0.Split(Conversions.ToChar(value))[1]);
			item3 = Conversions.ToInteger(string_0.Split(Conversions.ToChar(value))[2]);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new LuaError("解析提供的时间值时出错：" + string_0 + " - 错误：" + ex2.Message);
		}
		return (HourValue: item, MinuteValue: item2, SecondValue: item3);
	}

	internal static (int HourValue, int MinuteValue, int SecondValue) ParseTime_Duration(string string_0)
	{
		string value = string.Empty;
		if (string_0.Contains(":"))
		{
			value = ":";
		}
		if (string.IsNullOrEmpty(value))
		{
			throw new LuaError("Error in parsing provided duration value: " + string_0 + " - The delimiter must be (:) in format days:hour:min");
		}
		float num;
		float num2;
		float num3;
		try
		{
			num = Conversions.ToSingle(string_0.Split(Conversions.ToChar(value))[0]);
			num2 = Conversions.ToSingle(string_0.Split(Conversions.ToChar(value))[1]);
			num3 = Conversions.ToSingle(string_0.Split(Conversions.ToChar(value))[2]);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new LuaError("Error in parsing provided duration value: " + string_0 + " - 错误：" + ex2.Message);
		}
		return (HourValue: (int)Math.Round(num * 24f + num2), MinuteValue: (int)Math.Round(num3), SecondValue: 0);
	}

	internal static string LuaInterpret(object object_0)
	{
		if (object_0 is object[])
		{
			string text = "";
			bool flag = true;
			object[] array = (object[])object_0;
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				object objectValue = RuntimeHelpers.GetObjectValue(array[i]);
				if (flag)
				{
					flag = false;
				}
				else
				{
					text += ",";
				}
				text += LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue));
			}
			return text;
		}
		if (object_0 is string)
		{
			return Conversions.ToString(object_0);
		}
		if (object_0 is double)
		{
			return Conversions.ToString(object_0);
		}
		if (object_0 is bool)
		{
			if (Conversions.ToBoolean(object_0))
			{
				return "'Yes'";
			}
			return "'No'";
		}
		if (object_0 is LuaTable)
		{
			IDictionaryEnumerator enumerator = ((LuaTable)object_0).GetEnumerator();
			string text2 = "{";
			bool flag2 = true;
			while (enumerator.MoveNext())
			{
				if (flag2)
				{
					flag2 = false;
				}
				else
				{
					text2 += ",";
				}
				text2 = ((enumerator.Key is string) ? (text2 + " " + enumerator.Key.ToString() + " = ") : (text2 + " [" + enumerator.Key.ToString() + "] = "));
				text2 = ((enumerator.Value is string) ? (text2 + "'" + LuaInterpret(RuntimeHelpers.GetObjectValue(enumerator.Value)) + "'") : ((enumerator.Value is LuaFunction) ? (text2 + enumerator.Value.ToString()) : ((enumerator.Value is LuaTable) ? ((((LuaTable)enumerator.Value).Keys.Count <= 50) ? (text2 + LuaInterpret(RuntimeHelpers.GetObjectValue(enumerator.Value))) : (text2 + enumerator.Value.ToString())) : (text2 + LuaInterpret(RuntimeHelpers.GetObjectValue(enumerator.Value))))));
			}
			return text2 + " }";
		}
		if (object_0 == null)
		{
			return "nil";
		}
		return object_0.ToString();
	}

	public static void AddToLuaHistoryFile(ref string string_0, ref object object_0, bool bool_0 = false)
	{
		try
		{
			if (!LuaSandBox._lua_console & !LuaSandBox._lua_event)
			{
				return;
			}
			string text = null;
			if ((object)object_0.GetType() == typeof(string))
			{
				text = Conversions.ToString(object_0);
			}
			else
			{
				Exception ex = (Exception)object_0;
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("异常：").Append(ex.Message).Append("\r\n")
					.Append("堆栈跟踪：")
					.Append(ex.StackTrace)
					.Append("\r\n");
				if (!Information.IsNothing(ex.InnerException))
				{
					stringBuilder.Append("内部异常：").Append(ex.InnerException.Message).Append("\r\n")
						.Append("内部堆栈跟踪：")
						.Append(ex.InnerException.StackTrace)
						.Append("\r\n");
				}
				if (ex.Data.Count > 0)
				{
					stringBuilder.Append("调用堆栈和错误详细信息：");
					IDictionaryEnumerator enumerator = ex.Data.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object current = enumerator.Current;
						DictionaryEntry dictionaryEntry = ((current == null) ? default(DictionaryEntry) : ((DictionaryEntry)current));
						stringBuilder.Append("\r\n").Append(Conversions.ToString(dictionaryEntry.Key)).Append(", ")
							.Append(Conversions.ToString(dictionaryEntry.Value));
					}
				}
				text = stringBuilder.ToString();
			}
			StringBuilder stringBuilder2 = new StringBuilder();
			if (bool_0)
			{
				stringBuilder2.Append(DateAndTime.Now).Append(" -- B").Append("1328.18")
					.Append(" -- ")
					.Append("\r\n");
			}
			if (string_0.Length > 0)
			{
				stringBuilder2.Append(string_0).Append("\r\n");
			}
			if (text.Length > 0)
			{
				stringBuilder2.Append(text).Append("\r\n");
			}
			try
			{
				string text2 = DateAndTime.Now.Year + "-" + Strings.Right("00" + DateAndTime.Now.Month, 2) + "-" + Strings.Right("00" + DateAndTime.Now.Day, 2);
				StreamWriter streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "LuaHistory_" + text2 + ".txt");
				streamWriter.Write(stringBuilder2.ToString());
				streamWriter.Close();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
