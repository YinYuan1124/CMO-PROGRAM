using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[StandardModule]
internal sealed class LuaReferencePoint
{
	public static LuaWrapper_ReferencePoint ScenEdit_AddReferencePoint(LuaTable luaTable_0, Scenario scenario_0)
	{
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		Module_Unit.Unit unit = null;
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		ReferencePoint referencePoint = null;
		Side side = LuaUtility.QuerySideOrFail(dictionary, scenario_0);
		if (dictionary.ContainsKey("RELATIVETO"))
		{
			string text = Conversions.ToString(dictionary["RELATIVETO"]);
			unit = PrivateMethods.ValidateAUBySide(text, side);
			if (unit == null)
			{
				throw new LuaError("缺少单元" + text + "从相对方位");
			}
		}
		if (dictionary.ContainsKey("AREA"))
		{
			foreach (LuaTable item in LuaUtility.ToArray(((LuaTable)dictionary["AREA"]).GetEnumerator()))
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				Dictionary<string, object> dictionary2 = LuaUtility.ToDictUpper(item.GetEnumerator());
				referencePoint = ParseReferencePoint(dictionary2, dictionary, scenario_0, unit);
				if (!Information.IsNothing(referencePoint))
				{
					side.RefPoints.Add(referencePoint);
					dictionary2["GUID"] = referencePoint.ObjectID;
					LuaUtility.FromDict(dictionary2, val2);
					val[val.Keys.Count.ToString()] = val2;
					continue;
				}
				throw new LuaError("无法创建参考点");
			}
			dictionary["AREA"] = val;
		}
		else
		{
			referencePoint = ParseReferencePoint(dictionary, null, scenario_0, unit);
			if (Information.IsNothing(referencePoint))
			{
				throw new LuaError("无法创建参考点");
			}
			side.RefPoints.Add(referencePoint);
			dictionary["GUID"] = referencePoint.ObjectID;
		}
		return new LuaWrapper_ReferencePoint(referencePoint, side, scenario_0);
	}

	public static LuaWrapper_ReferencePoint ScenEdit_SetReferencePoint(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		ReferencePoint referencePoint = null;
		List<ReferencePoint> list = new List<ReferencePoint>();
		string Local_nameGUID = null;
		if (dictionary.ContainsKey("GUID"))
		{
			Local_nameGUID = Conversions.ToString(dictionary["GUID"]).ToUpper();
		}
		else if (dictionary.ContainsKey("NAME"))
		{
			Local_nameGUID = Conversions.ToString(dictionary["NAME"]).ToUpper();
		}
		Side side = LuaUtility.QuerySideOrFail(dictionary, scenario_0);
		if (Information.IsNothing(Local_nameGUID) && !dictionary.ContainsKey("AREA"))
		{
			throw new LuaError("需要定义分方和名称来修改参考点。或分方和Guid。或者一组参考点");
		}
		Module_Unit.Unit unit = null;
		bool? flag = null;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		ReferencePoint.OrientationType? orientationType = null;
		Color? color = null;
		if (dictionary.ContainsKey("HIGHLIGHTED"))
		{
			bool? flag5 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary["HIGHLIGHTED"]));
			if (flag5.HasValue)
			{
				flag = flag5.Value;
			}
		}
		else if (dictionary.ContainsKey("TOGGLEHIGHLIGHTED") && LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary["TOGGLEHIGHLIGHTED"])).GetValueOrDefault())
		{
			flag2 = true;
		}
		if (dictionary.ContainsKey("LOCKED"))
		{
			flag3 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary["LOCKED"])).Value;
		}
		if (dictionary.ContainsKey("BEARINGTYPE") && Enum.TryParse<ReferencePoint.OrientationType>(Conversions.ToString(dictionary["BEARINGTYPE"]), ignoreCase: true, out var result) && Enum.IsDefined(typeof(ReferencePoint.OrientationType), result))
		{
			orientationType = result;
		}
		if (dictionary.ContainsKey("CLEAR"))
		{
			bool? flag6 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary["CLEAR"]));
			if (flag6.HasValue)
			{
				flag4 = flag6.Value;
			}
		}
		if (dictionary.ContainsKey("RELATIVETO"))
		{
			string text = Conversions.ToString(dictionary["RELATIVETO"]);
			if (Operators.CompareString(text.ToLower(), "none", TextCompare: false) == 0)
			{
				flag4 = true;
			}
			else
			{
				unit = PrivateMethods.ValidateAUBySide(text, side);
				if (unit == null)
				{
					throw new LuaError("缺少单元" + text + "从相对方位");
				}
			}
		}
		if (dictionary.ContainsKey("COLOR"))
		{
			string text2 = Conversions.ToString(dictionary["COLOR"]);
			Color value = Color.FromName(text2);
			if (value.IsKnownColor)
			{
				color = value;
			}
			else
			{
				try
				{
					color = ColorTranslator.FromHtml("#" + text2);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
		}
		if (Information.IsNothing(Local_nameGUID))
		{
			if (!dictionary.ContainsKey("AREA"))
			{
				throw new LuaError("需要定义分方和名称来修改参考点。或分方和Guid。或者一组参考点");
			}
			foreach (object item in LuaUtility.ToArray(((LuaTable)dictionary["AREA"]).GetEnumerator()))
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				string Local_o_name = null;
				ReferencePoint referencePoint2 = null;
				if (objectValue.GetType() == typeof(LuaTable))
				{
					Dictionary<string, object> dictionary2 = LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator());
					if (dictionary2.ContainsKey("GUID"))
					{
						Local_o_name = Conversions.ToString(dictionary2["GUID"]).ToUpper();
					}
					else if (dictionary2.ContainsKey("NAME"))
					{
						Local_o_name = Conversions.ToString(dictionary2["NAME"]).ToUpper();
					}
					referencePoint2 = side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
					if (Information.IsNothing(referencePoint2))
					{
						foreach (NoNavZone noNavZone in side.NoNavZones)
						{
							referencePoint2 = noNavZone.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
							if (!Information.IsNothing(referencePoint2))
							{
								break;
							}
						}
					}
					if (Information.IsNothing(referencePoint2))
					{
						foreach (ExclusionZone exclusionZone in side.ExclusionZones)
						{
							referencePoint2 = exclusionZone.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
							if (!Information.IsNothing(referencePoint2))
							{
								break;
							}
						}
					}
					if (!Information.IsNothing(referencePoint2))
					{
						double? num = null;
						double? num2 = null;
						double? num3 = null;
						double? num4 = null;
						if (dictionary2.ContainsKey("BEARING") && dictionary2.ContainsKey("DISTANCE"))
						{
							if (Information.IsNothing(unit))
							{
								throw new LuaError("没有为相对方位定义单元");
							}
							num3 = Conversions.ToDouble(dictionary2["BEARING"]);
							num4 = Conversions.ToDouble(dictionary2["DISTANCE"]);
							Geodesic_Vincenty.TCoord tcoord_ = new Geodesic_Vincenty.TCoord(unit.GetLatitude(), unit.GetLongitude());
							Geodesic_Vincenty.TCoord tcoord_2 = default(Geodesic_Vincenty.TCoord);
							Geodesic_Vincenty.fw_vincenty_wgs84(ref tcoord_, ref tcoord_2, num3.Value, num4.Value);
							num = tcoord_2.Lat;
							num2 = tcoord_2.Lon;
						}
						else
						{
							num = LuaUtility.QueryLatitude(dictionary2);
							num2 = LuaUtility.QueryLongitude(dictionary2);
						}
						if (!Information.IsNothing(num))
						{
							referencePoint2.Latitude = num.Value;
						}
						if (!Information.IsNothing(num2))
						{
							referencePoint2.Longitude = num2.Value;
						}
						if (dictionary2.ContainsKey("HIGHLIGHTED"))
						{
							bool? flag7 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary2["HIGHLIGHTED"]));
							if (flag7.HasValue)
							{
								referencePoint2.IsHighlighted = flag7.Value;
							}
							if (dictionary2.ContainsKey("LOCKED"))
							{
								referencePoint2.IsLocked = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary2["LOCKED"])).Value;
							}
							if (dictionary2.ContainsKey("COLOR"))
							{
								Color color2 = Color.FromName(Conversions.ToString(dictionary["COLOR"]));
								if (color2.IsKnownColor)
								{
									referencePoint2.color = color2;
								}
								else
								{
									try
									{
										referencePoint2.color = ColorTranslator.FromHtml("#" + Conversions.ToString(dictionary["COLOR"]));
									}
									catch (Exception projectError2)
									{
										ProjectData.SetProjectError(projectError2);
										ProjectData.ClearProjectError();
									}
								}
							}
							if (!Information.IsNothing(unit))
							{
								if (dictionary2.ContainsKey("RELATIVETO") && Information.IsNothing(orientationType) && dictionary2.ContainsKey("BEARINGTYPE") && Enum.TryParse<ReferencePoint.OrientationType>(Conversions.ToString(dictionary["BEARINGTYPE"]), ignoreCase: true, out var result2) && Enum.IsDefined(typeof(ReferencePoint.OrientationType), result2))
								{
									referencePoint2.BearingType = result2;
								}
								referencePoint2.IsRelativeTo = unit;
								referencePoint2.AdjustForRelativeHooking();
							}
						}
					}
				}
				else
				{
					Local_o_name = objectValue.ToString().ToUpper();
					referencePoint2 = side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
					if (Information.IsNothing(referencePoint2))
					{
						foreach (NoNavZone noNavZone2 in side.NoNavZones)
						{
							referencePoint2 = noNavZone2.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
							if (!Information.IsNothing(referencePoint2))
							{
								break;
							}
						}
					}
					if (Information.IsNothing(referencePoint2))
					{
						foreach (ExclusionZone exclusionZone2 in side.ExclusionZones)
						{
							referencePoint2 = exclusionZone2.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
							if (!Information.IsNothing(referencePoint2))
							{
								break;
							}
						}
					}
				}
				if (!Information.IsNothing(referencePoint2))
				{
					list.Add(referencePoint2);
				}
			}
		}
		else
		{
			referencePoint = side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_nameGUID, StringComparison.OrdinalIgnoreCase));
			if (Information.IsNothing(referencePoint))
			{
				foreach (NoNavZone noNavZone3 in side.NoNavZones)
				{
					referencePoint = noNavZone3.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_nameGUID, StringComparison.OrdinalIgnoreCase));
					if (!Information.IsNothing(referencePoint))
					{
						break;
					}
				}
			}
			if (Information.IsNothing(referencePoint))
			{
				foreach (ExclusionZone exclusionZone3 in side.ExclusionZones)
				{
					referencePoint = exclusionZone3.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_nameGUID, StringComparison.OrdinalIgnoreCase));
					if (!Information.IsNothing(referencePoint))
					{
						break;
					}
				}
			}
		}
		if (list.Count == 0 && referencePoint == null)
		{
			throw new LuaError("需要定义分方和名称来修改参考点。或分方和Guid。或者一组参考点");
		}
		if (referencePoint != null)
		{
			if (dictionary.ContainsKey("NEWNAME"))
			{
				string text3 = Conversions.ToString(dictionary["NEWNAME"]);
				if (Operators.CompareString(referencePoint.Name, text3, TextCompare: false) != 0)
				{
					referencePoint.Name = text3;
				}
			}
			double? num5 = LuaUtility.QueryLatitude(dictionary);
			if (num5.HasValue)
			{
				referencePoint.Latitude = num5.Value;
			}
			double? num6 = LuaUtility.QueryLongitude(dictionary);
			if (num6.HasValue)
			{
				referencePoint.Longitude = num6.Value;
			}
		}
		if (referencePoint != null)
		{
			list.Add(referencePoint);
			referencePoint = null;
		}
		foreach (ReferencePoint item2 in list)
		{
			if (!Information.IsNothing(flag))
			{
				bool? flag8 = flag;
				flag8 = flag8;
				if (flag8.GetValueOrDefault())
				{
					item2.IsHighlighted = flag.Value;
				}
			}
			if (!Information.IsNothing(flag2) && flag2)
			{
				item2.IsHighlighted = !item2.IsHighlighted;
			}
			if (!Information.IsNothing(flag3) && flag3)
			{
				item2.IsLocked = flag3;
			}
			if (color.HasValue)
			{
				item2.color = color.Value;
			}
			if (!Information.IsNothing(flag4) && flag4)
			{
				item2.IsRelativeTo = null;
				item2.BearingType = ReferencePoint.OrientationType.Fixed;
				item2.RelativeBearing = 0f;
				item2.RelativeDistance = 0f;
			}
			if (orientationType.HasValue)
			{
				item2.BearingType = orientationType.Value;
				if (unit != null)
				{
					item2.IsRelativeTo = unit;
					item2.AdjustForRelativeHooking();
				}
			}
		}
		referencePoint = list.First();
		return new LuaWrapper_ReferencePoint(referencePoint, side, scenario_0);
	}

	public static LuaWrapper_ReferencePoint ScenEdit_GetReferencePoint(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		ReferencePoint referencePoint = null;
		string Local_nameGUID = null;
		Side side = LuaUtility.QuerySideOrFail(dictionary, scenario_0);
		if (dictionary.ContainsKey("GUID"))
		{
			Local_nameGUID = Conversions.ToString(dictionary["GUID"]).ToUpper();
		}
		else if (dictionary.ContainsKey("NAME"))
		{
			Local_nameGUID = Conversions.ToString(dictionary["NAME"]).ToUpper();
		}
		if (Information.IsNothing(Local_nameGUID) && !dictionary.ContainsKey("AREA"))
		{
			throw new LuaError("需要定义Side和Name来修改RP。或分方和Guid");
		}
		referencePoint = side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_nameGUID, StringComparison.OrdinalIgnoreCase));
		if (Information.IsNothing(referencePoint))
		{
			foreach (NoNavZone noNavZone in side.NoNavZones)
			{
				referencePoint = noNavZone.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_nameGUID, StringComparison.OrdinalIgnoreCase));
				if (!Information.IsNothing(referencePoint))
				{
					break;
				}
			}
		}
		if (Information.IsNothing(referencePoint))
		{
			foreach (ExclusionZone exclusionZone in side.ExclusionZones)
			{
				referencePoint = exclusionZone.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_nameGUID, StringComparison.OrdinalIgnoreCase));
				if (!Information.IsNothing(referencePoint))
				{
					break;
				}
			}
		}
		if (referencePoint == null)
		{
			throw new LuaError("找不到RP。");
		}
		return new LuaWrapper_ReferencePoint(referencePoint, side, scenario_0);
	}

	public static LuaTable ScenEdit_GetReferencePoints(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		ReferencePoint referencePoint = null;
		List<ReferencePoint> list = new List<ReferencePoint>();
		string Local_nameGUID = null;
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		Side side = LuaUtility.QuerySideOrFail(dictionary, scenario_0);
		if (dictionary.ContainsKey("GUID"))
		{
			Local_nameGUID = Conversions.ToString(dictionary["GUID"]).ToUpper();
		}
		else if (dictionary.ContainsKey("NAME"))
		{
			Local_nameGUID = Conversions.ToString(dictionary["NAME"]).ToUpper();
		}
		if (Information.IsNothing(Local_nameGUID) && !dictionary.ContainsKey("AREA"))
		{
			throw new LuaError("需要定义分方和名称来修改参考点。或分方和Guid。或者一组参考点");
		}
		if (Information.IsNothing(Local_nameGUID))
		{
			if (!dictionary.ContainsKey("AREA"))
			{
				throw new LuaError("需要定义分方和名称来修改参考点。或分方和Guid。或者一组参考点");
			}
			foreach (object item in LuaUtility.ToArray(((LuaTable)dictionary["AREA"]).GetEnumerator()))
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				string Local_o_name = null;
				ReferencePoint referencePoint2 = null;
				if (objectValue.GetType() == typeof(LuaTable))
				{
					Dictionary<string, object> dictionary2 = LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator());
					if (dictionary2.ContainsKey("GUID"))
					{
						Local_o_name = Conversions.ToString(dictionary2["GUID"]).ToUpper();
					}
					else if (dictionary.ContainsKey("NAME"))
					{
						Local_o_name = Conversions.ToString(dictionary2["NAME"]).ToUpper();
					}
					referencePoint2 = side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
					if (Information.IsNothing(referencePoint2))
					{
						foreach (NoNavZone noNavZone in side.NoNavZones)
						{
							referencePoint2 = noNavZone.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
							if (!Information.IsNothing(referencePoint2))
							{
								break;
							}
						}
					}
					if (Information.IsNothing(referencePoint2))
					{
						foreach (ExclusionZone exclusionZone in side.ExclusionZones)
						{
							referencePoint2 = exclusionZone.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
							if (!Information.IsNothing(referencePoint2))
							{
								break;
							}
						}
					}
				}
				else
				{
					Local_o_name = objectValue.ToString();
					referencePoint2 = side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
					if (Information.IsNothing(referencePoint2))
					{
						foreach (NoNavZone noNavZone2 in side.NoNavZones)
						{
							referencePoint2 = noNavZone2.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
							if (!Information.IsNothing(referencePoint2))
							{
								break;
							}
						}
					}
					if (Information.IsNothing(referencePoint2))
					{
						foreach (ExclusionZone exclusionZone2 in side.ExclusionZones)
						{
							referencePoint2 = exclusionZone2.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_o_name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_o_name, StringComparison.OrdinalIgnoreCase));
							if (!Information.IsNothing(referencePoint2))
							{
								break;
							}
						}
					}
				}
				if (!Information.IsNothing(referencePoint2))
				{
					list.Add(referencePoint2);
				}
			}
		}
		else
		{
			referencePoint = side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_nameGUID, StringComparison.OrdinalIgnoreCase));
			if (Information.IsNothing(referencePoint))
			{
				foreach (NoNavZone noNavZone3 in side.NoNavZones)
				{
					referencePoint = noNavZone3.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_nameGUID, StringComparison.OrdinalIgnoreCase));
					if (!Information.IsNothing(referencePoint))
					{
						break;
					}
				}
			}
			if (Information.IsNothing(referencePoint))
			{
				foreach (ExclusionZone exclusionZone3 in side.ExclusionZones)
				{
					referencePoint = exclusionZone3.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_nameGUID, StringComparison.OrdinalIgnoreCase));
					if (!Information.IsNothing(referencePoint))
					{
						break;
					}
				}
			}
		}
		if (list.Count == 0 && referencePoint == null)
		{
			throw new LuaError("需要定义分方和名称来修改参考点。或分方和Guid。或者一组参考点");
		}
		LuaSandBox.Singleton().CreateTable();
		int num = 1;
		foreach (ReferencePoint Local_theRP in list)
		{
			LuaTable val2 = LuaSandBox.Singleton().CreateTable();
			val2["name"] = Local_theRP.Name;
			val2["latitude"] = Local_theRP.Latitude.ToString();
			val2["longitude"] = Local_theRP.Longitude.ToString();
			val2["guid"] = Local_theRP.ObjectID.ToString();
			val2["side"] = scenario_0.Sides_ReadOnly.First((Side s) => s.RefPoints.Contains(Local_theRP)).Name;
			val2["highlighted"] = Local_theRP.IsHighlighted.ToString();
			val2["locked"] = Local_theRP.IsLocked.ToString();
			if (Local_theRP.IsRelativeTo != null)
			{
				val2["bearingtype"] = Local_theRP.BearingType.ToString();
				val2["relativeto"] = Local_theRP.IsRelativeTo.Name;
			}
			val[num] = val2;
			num++;
		}
		return val;
	}

	public static bool ScenEdit_DeleteReferencePoint(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		Zone zone = null;
		string Local_nameGUID = null;
		Side side = LuaUtility.QuerySideOrFail(dictionary, scenario_0);
		if (dictionary.ContainsKey("GUID"))
		{
			Local_nameGUID = Conversions.ToString(dictionary["GUID"]).ToUpper();
		}
		else if (dictionary.ContainsKey("NAME"))
		{
			Local_nameGUID = Conversions.ToString(dictionary["NAME"]).ToUpper();
		}
		if (Information.IsNothing(Local_nameGUID))
		{
			throw new LuaError("需要定义Side和Name来修改RP。或分方和Guid");
		}
		ReferencePoint referencePoint = side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_nameGUID, StringComparison.OrdinalIgnoreCase));
		if (Information.IsNothing(referencePoint))
		{
			foreach (NoNavZone noNavZone in side.NoNavZones)
			{
				referencePoint = noNavZone.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_nameGUID, StringComparison.OrdinalIgnoreCase));
				if (!Information.IsNothing(referencePoint))
				{
					zone = noNavZone;
					break;
				}
			}
		}
		if (Information.IsNothing(referencePoint))
		{
			foreach (ExclusionZone exclusionZone in side.ExclusionZones)
			{
				referencePoint = exclusionZone.Area.FirstOrDefault((ReferencePoint s) => string.Equals(s.ObjectID, Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, Local_nameGUID, StringComparison.OrdinalIgnoreCase));
				if (!Information.IsNothing(referencePoint))
				{
					zone = exclusionZone;
					break;
				}
			}
		}
		if (Information.IsNothing(referencePoint))
		{
			return false;
		}
		if (Information.IsNothing(zone))
		{
			side.RefPoints.Remove(referencePoint);
			return true;
		}
		zone.Area.Remove(referencePoint);
		return true;
	}

	public static ReferencePoint ParseReferencePoint(Dictionary<string, object> dictionary_0, Dictionary<string, object> dictionary_1, Scenario scenario_0, Module_Unit.Unit unit_0 = null)
	{
		string text = "";
		double? num = null;
		double? num2 = null;
		double? num3 = null;
		double? num4 = null;
		ReferencePoint referencePoint = null;
		if (dictionary_0.ContainsKey("NAME"))
		{
			text = Conversions.ToString(dictionary_0["NAME"]);
		}
		else
		{
			scenario_0.UnitsAutoIncrement++;
			text = "RP-" + Conversions.ToString(scenario_0.UnitsAutoIncrement);
		}
		if (dictionary_0.ContainsKey("BEARING") && dictionary_0.ContainsKey("DISTANCE"))
		{
			if (Information.IsNothing(unit_0))
			{
				throw new LuaError("没有为相对方位定义单元");
			}
			num3 = Conversions.ToDouble(dictionary_0["BEARING"]);
			num4 = Conversions.ToDouble(dictionary_0["DISTANCE"]);
			Geodesic_Vincenty.TCoord tcoord_ = new Geodesic_Vincenty.TCoord(unit_0.GetLatitude(), unit_0.GetLongitude());
			Geodesic_Vincenty.TCoord tcoord_2 = default(Geodesic_Vincenty.TCoord);
			Geodesic_Vincenty.fw_vincenty_wgs84(ref tcoord_, ref tcoord_2, num3.Value, num4.Value);
			num = tcoord_2.Lat;
			num2 = tcoord_2.Lon;
		}
		else if (!Information.IsNothing(dictionary_1) && dictionary_1.ContainsKey("BEARING") && dictionary_1.ContainsKey("DISTANCE"))
		{
			if (Information.IsNothing(unit_0))
			{
				throw new LuaError("没有为相对方位定义单元");
			}
			num3 = Conversions.ToDouble(dictionary_1["BEARING"]);
			num4 = Conversions.ToDouble(dictionary_1["DISTANCE"]);
			Geodesic_Vincenty.TCoord tcoord_3 = new Geodesic_Vincenty.TCoord(unit_0.GetLatitude(), unit_0.GetLongitude());
			Geodesic_Vincenty.TCoord tcoord_4 = default(Geodesic_Vincenty.TCoord);
			Geodesic_Vincenty.fw_vincenty_wgs84(ref tcoord_3, ref tcoord_4, num3.Value, num4.Value);
			num = tcoord_4.Lat;
			num2 = tcoord_4.Lon;
		}
		else
		{
			num = LuaUtility.QueryLatitude(dictionary_0);
			num2 = LuaUtility.QueryLongitude(dictionary_0);
		}
		if (!Information.IsNothing(num) && !Information.IsNothing(num2))
		{
			referencePoint = new ReferencePoint();
			referencePoint.Longitude = num2.Value;
			referencePoint.Latitude = num.Value;
			referencePoint.Name = text;
			referencePoint.color = Color.White;
			if (dictionary_0.ContainsKey("HIGHLIGHTED"))
			{
				bool? flag = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_0["HIGHLIGHTED"]));
				if (flag.HasValue)
				{
					referencePoint.IsHighlighted = flag.Value;
				}
			}
			else if (!Information.IsNothing(dictionary_1) && dictionary_1.ContainsKey("HIGHLIGHTED"))
			{
				bool? flag2 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_1["HIGHLIGHTED"]));
				if (flag2.HasValue)
				{
					referencePoint.IsHighlighted = flag2.Value;
				}
			}
			if (dictionary_0.ContainsKey("LOCKED"))
			{
				referencePoint.IsLocked = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_0["LOCKED"])).Value;
			}
			else if (!Information.IsNothing(dictionary_1) && dictionary_1.ContainsKey("LOCKED"))
			{
				referencePoint.IsLocked = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary_1["LOCKED"])).Value;
			}
			if (dictionary_0.ContainsKey("COLOR"))
			{
				Color color = Color.FromName(Conversions.ToString(dictionary_0["COLOR"]));
				if (color.IsKnownColor)
				{
					referencePoint.color = color;
				}
				else
				{
					try
					{
						referencePoint.color = ColorTranslator.FromHtml("#" + Conversions.ToString(dictionary_0["COLOR"]));
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
			}
			else if (!Information.IsNothing(dictionary_1) && dictionary_1.ContainsKey("COLOR"))
			{
				Color color2 = Color.FromName(Conversions.ToString(dictionary_1["COLOR"]));
				if (color2.IsKnownColor)
				{
					referencePoint.color = color2;
				}
				else
				{
					try
					{
						referencePoint.color = ColorTranslator.FromHtml("#" + Conversions.ToString(dictionary_1["COLOR"]));
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						ProjectData.ClearProjectError();
					}
				}
			}
			if (!Information.IsNothing(unit_0))
			{
				if (dictionary_0.ContainsKey("RELATIVETO") || (!Information.IsNothing(dictionary_1) && dictionary_1.ContainsKey("RELATIVETO")))
				{
					ReferencePoint.OrientationType result2;
					if (dictionary_0.ContainsKey("BEARINGTYPE"))
					{
						if (Enum.TryParse<ReferencePoint.OrientationType>(Conversions.ToString(dictionary_0["BEARINGTYPE"]), ignoreCase: true, out var result) && Enum.IsDefined(typeof(ReferencePoint.OrientationType), result))
						{
							referencePoint.BearingType = result;
						}
					}
					else if (!Information.IsNothing(dictionary_1) && dictionary_1.ContainsKey("BEARINGTYPE") && Enum.TryParse<ReferencePoint.OrientationType>(Conversions.ToString(dictionary_1["BEARINGTYPE"]), ignoreCase: true, out result2) && Enum.IsDefined(typeof(ReferencePoint.OrientationType), result2))
					{
						referencePoint.BearingType = result2;
					}
				}
				referencePoint.IsRelativeTo = unit_0;
				referencePoint.AdjustForRelativeHooking();
			}
			return referencePoint;
		}
		throw new LuaError("No longitude/latitude setting");
	}
}
