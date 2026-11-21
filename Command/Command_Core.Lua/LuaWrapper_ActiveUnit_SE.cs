using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPruneType]
[DoNotObfuscateType]
[DoNotPrune]
public sealed class LuaWrapper_ActiveUnit_SE : LuaWrapper_ActiveUnit
{
	[DoNotPrune]
	public override double latitude
	{
		get
		{
			return au.GetLatitude();
		}
		set
		{
			double? num = LuaUtility.QueryLatitudeObject(value);
			if (!num.HasValue)
			{
				throw new LuaError("不能为纬度传递零。");
			}
			au.Teleport(ref au.ParentScen, au.GetLongitude(), num.Value);
		}
	}

	[DoNotPrune]
	public override double longitude
	{
		get
		{
			return au.GetLongitude();
		}
		set
		{
			double? num = LuaUtility.QueryLongitudeObject(value);
			if (!num.HasValue)
			{
				throw new LuaError("不能为经度传递零。");
			}
			au.Teleport(ref au.ParentScen, num.Value, au.GetLatitude());
		}
	}

	[DoNotPrune]
	public override bool autodetectable
	{
		get
		{
			return au.GetIsAutoDetectable(null);
		}
		set
		{
			au.SetIsAutoDetectable(null, value);
			if (value)
			{
				au.GetUnitSide().ProcessAutoDetectableUnits(ScenarioContext, ScenarioContext.GameResolution);
			}
		}
	}

	[DoNotPrune]
	public override object altitude
	{
		get
		{
			return au.GetCurrentAltitude(bool_0: true);
		}
		set
		{
			au.SetCurrentAltitude(bool_0: true, LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(value)).Value);
		}
	}

	[DoNotPrune]
	public override object speed
	{
		get
		{
			return au.CurrentSpeed;
		}
		set
		{
			float num = Conversions.ToSingle(value);
			if (num > (float)au.Kinematics.GetMaximumSpeed(au.GetCurrentAltitude(), au.ThrottleSetting, bool_0: false))
			{
				num = au.Kinematics.GetMaximumSpeed(au.GetCurrentAltitude(), au.ThrottleSetting, bool_0: false);
			}
			au.CurrentSpeed = num;
		}
	}

	[DoNotPrune]
	public override object manualAltitude
	{
		get
		{
			if (au.Kinematics.DesiredAltitudeOverride)
			{
				return au.DesiredAltitude;
			}
			return null;
		}
		set
		{
			switch (Conversions.ToString(value).ToUpper())
			{
			case "OFF":
				au.Kinematics.DesiredAltitudeOverride = false;
				return;
			case "DESIRED":
				_ = au.DesiredAltitude;
				au.Kinematics.DesiredAltitudeOverride = true;
				return;
			case "CURRENT":
				au.GetCurrentAltitude();
				au.Kinematics.DesiredAltitudeOverride = true;
				return;
			}
			if (au.IsSubmarine)
			{
				ActiveUnit_AI.SubmarineDepthPreset? submarineDepthPreset = LuaUtility.QueryDepthPresetObject(Conversions.ToString(value));
				if (submarineDepthPreset.HasValue)
				{
					((Submarine)au).AI.DepthPreset = submarineDepthPreset.Value;
					((Submarine)au).AI.FollowDepthPreset(bool_0: false);
					au.Kinematics.DesiredAltitudeOverride = true;
				}
				else
				{
					float? num = LuaUtility.QueryDepthObject(Conversions.ToString(value));
					au.DesiredAltitude = num.Value;
					((Submarine)au).AI.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
					au.Kinematics.DesiredAltitudeOverride = true;
				}
			}
			else if (au.IsAircraft)
			{
				ActiveUnit_AI.AircraftAltitudePreset? aircraftAltitudePreset = LuaUtility.QueryAltitudePresetObject(Conversions.ToString(value));
				if (aircraftAltitudePreset.HasValue)
				{
					((Aircraft)au).AI.AltitudePreset = aircraftAltitudePreset.Value;
					((Aircraft)au).AI.FollowAltitudePreset();
					au.Kinematics.DesiredAltitudeOverride = true;
				}
				else
				{
					float? num2 = LuaUtility.QueryAltitudeObject(Conversions.ToString(value));
					au.DesiredAltitude = num2.Value;
					((Aircraft)au).AI.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
					au.Kinematics.DesiredAltitudeOverride = true;
				}
			}
			else
			{
				float? num3 = LuaUtility.QueryAltitudeObject(Conversions.ToString(value));
				au.DesiredAltitude = num3.Value;
				au.Kinematics.DesiredAltitudeOverride = true;
			}
		}
	}

	[DoNotPrune]
	public override object manualSpeed
	{
		get
		{
			if (au.Kinematics.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				return au.Kinematics.DesiredSpeedOverride;
			}
			return au.DesiredSpeed;
		}
		set
		{
			float num = 0f;
			switch (Conversions.ToString(value).ToUpper())
			{
			default:
			{
				float? num2 = null;
				try
				{
					num2 = float.Parse(Conversions.ToString(value));
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				if (num2.HasValue)
				{
					au.Kinematics.DesiredSpeedOverride = num2.Value;
					au.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				}
				break;
			}
			case "OFF":
				au.Kinematics.DesiredSpeedOverride = null;
				break;
			case "DESIRED":
				num = au.DesiredSpeed;
				au.Kinematics.DesiredSpeedOverride = num;
				break;
			case "CURRENT":
				num = au.CurrentSpeed;
				au.Kinematics.DesiredSpeedOverride = num;
				break;
			}
			float? desiredSpeedOverride = au.Kinematics.DesiredSpeedOverride;
			if (!desiredSpeedOverride.HasValue)
			{
				return;
			}
			if (au.IsGroup && ((Group)au).GroupLead != null)
			{
				ActiveUnit activeUnit = ((Group)au).GroupLead;
				activeUnit.SetThrottle(activeUnit.Kinematics.GetThrottleSuitableForThisSpeed(au.GetCurrentAltitude(), desiredSpeedOverride.Value));
				au.ThrottleSetting = activeUnit.ThrottleSetting;
				float? num3 = desiredSpeedOverride;
				float num4 = activeUnit.Kinematics.GetMaximumSpeed(activeUnit.GetCurrentAltitude(), activeUnit.ThrottleSetting, bool_0: false);
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() > num4) : null).GetValueOrDefault())
				{
					au.Kinematics.DesiredSpeedOverride = activeUnit.Kinematics.GetMaximumSpeed(activeUnit.GetCurrentAltitude(), activeUnit.ThrottleSetting, bool_0: false);
				}
			}
			else
			{
				au.SetThrottle(au.Kinematics.GetThrottleSuitableForThisSpeed(au.GetCurrentAltitude(), desiredSpeedOverride.Value));
				float? num5 = desiredSpeedOverride;
				float num6 = au.Kinematics.GetMaximumSpeed(au.GetCurrentAltitude(), au.ThrottleSetting, bool_0: false);
				if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() > num6) : null).GetValueOrDefault())
				{
					au.Kinematics.DesiredSpeedOverride = au.Kinematics.GetMaximumSpeed(au.GetCurrentAltitude(), au.ThrottleSetting, bool_0: false);
				}
			}
		}
	}

	[DoNotPrune]
	public object manualThrottle
	{
		get
		{
			if (au.Kinematics.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				return au.Kinematics.DesiredSpeedOverride;
			}
			return au.Kinematics.ThrottlePreset;
		}
		set
		{
			float num = 0f;
			switch (Conversions.ToString(value).ToUpper())
			{
			case "OFF":
				au.Kinematics.DesiredSpeedOverride = null;
				return;
			case "DESIRED":
				num = au.DesiredSpeed;
				au.Kinematics.DesiredSpeedOverride = num;
				return;
			case "CURRENT":
				num = au.CurrentSpeed;
				au.Kinematics.DesiredSpeedOverride = num;
				return;
			}
			if (Enum.TryParse<ActiveUnit_Kinematics.UnitThrottlePreset>(Conversions.ToString(value), ignoreCase: true, out var result) && Enum.IsDefined(typeof(ActiveUnit_Kinematics.UnitThrottlePreset), result))
			{
				au.Kinematics.ThrottlePreset = result;
				if (au.IsGroup && ((Group)au).GroupLead != null)
				{
					ActiveUnit activeUnit = ((Group)au).GroupLead;
					au.Kinematics.DesiredSpeedOverride = activeUnit.Kinematics.GetMaximumSpeed(au.GetCurrentAltitude(), (ActiveUnit.Throttle)au.Kinematics.ThrottlePreset, bool_0: false);
				}
				else
				{
					au.Kinematics.DesiredSpeedOverride = au.Kinematics.GetMaximumSpeed(au.GetCurrentAltitude(), (ActiveUnit.Throttle)au.Kinematics.ThrottlePreset, bool_0: false);
				}
			}
		}
	}

	[DoNotPrune]
	public override object throttle
	{
		get
		{
			return au.ThrottleSetting;
		}
		set
		{
			au.SetThrottle(LuaUtility.QueryThrottleObject(Conversions.ToString(value)).Value);
		}
	}

	[DoNotPrune]
	public override LuaTable course
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			Waypoint[] plottedCourse = au.Navigator.PlottedCourse;
			Waypoint[] array = plottedCourse;
			foreach (Waypoint waypoint in array)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["GUID"] = waypoint.ObjectID;
				val2["latitude"] = waypoint.Latitude;
				val2["longitude"] = waypoint.Longitude;
				if (waypoint.AltitudePreset != 0)
				{
					val2["PresetAltitude"] = waypoint.AltitudePreset.ToString();
				}
				if (waypoint.DepthPreset != 0)
				{
					val2["PresetDepth"] = waypoint.DepthPreset.ToString();
				}
				if (waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
				{
					val2["PresetThrottle"] = waypoint.ThrottlePreset.ToString();
				}
				if (waypoint.DesiredAltitude.HasValue)
				{
					val2["DesiredAltitude"] = waypoint.DesiredAltitude.ToString();
				}
				if (waypoint.DesiredAltitude_TerrainFollowing.HasValue)
				{
					val2["DesiredAltitudeTF"] = waypoint.DesiredAltitude_TerrainFollowing.ToString();
				}
				if (waypoint.DesiredSpeed.HasValue)
				{
					val2["DesiredSpeed"] = waypoint.DesiredSpeed.ToString();
				}
				if (waypoint.TerrainFollowing)
				{
					val2["TF"] = waypoint.TerrainFollowing.ToString();
				}
				val2["Description"] = waypoint.Description;
				val2["TypeOf"] = waypoint.Type.ToString();
				val2["WayPoint"] = new LuaWrapper_Waypoint(waypoint, ScenarioContext);
				val[num] = val2;
				num++;
			}
			return val;
		}
		set
		{
			if (value == null)
			{
				au.Navigator.ClearPlottedCourse();
				return;
			}
			au.Navigator.ClearPlottedCourse();
			foreach (object item in LuaUtility.ToArray(value.GetEnumerator()))
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				if (objectValue is LuaTable)
				{
					Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator());
					double? num = LuaUtility.QueryLongitude(dictionary);
					double? num2 = LuaUtility.QueryLatitude(dictionary);
					if (!(!num.HasValue | !num.HasValue))
					{
						double? num3 = num;
						bool? flag = (num3.HasValue ? new bool?(num3.GetValueOrDefault() == 0.0) : null);
						num3 = num;
						bool? flag2 = (num3.HasValue ? new bool?(num3.GetValueOrDefault() == 0.0) : null);
						if (!(flag.GetValueOrDefault() ? new bool?(true) : ((!flag2.HasValue) ? null : (flag2.GetValueOrDefault() | flag))).GetValueOrDefault())
						{
							au.Navigator.AddWaypoint(num2.Value, num.Value, 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
							if (au.Navigator.PlottedCourse == null)
							{
								continue;
							}
							Waypoint waypoint = au.Navigator.PlottedCourse.Last();
							if (dictionary.ContainsKey("TYPEOF"))
							{
								string value2 = Conversions.ToString(dictionary["TYPEOF"]);
								Waypoint.WaypointType result = Waypoint.WaypointType.ManualPlottedCourseWaypoint;
								if (Enum.TryParse<Waypoint.WaypointType>(value2, out result) & Enum.IsDefined(typeof(Waypoint.WaypointType), result))
								{
									waypoint.Type = result;
								}
							}
							if (dictionary.ContainsKey("PRESETALTITUDE"))
							{
								float? num4 = LuaUtility.QueryAltitudeObject(Conversions.ToString(dictionary["PRESETALTITUDE"]));
								if (num4.HasValue)
								{
									waypoint.AltitudePreset = (ActiveUnit_AI.AircraftAltitudePreset)Math.Round(num4.Value);
								}
							}
							if (dictionary.ContainsKey("PRESETDEPTH"))
							{
								float? num5 = LuaUtility.QueryDepthObject(Conversions.ToString(dictionary["PRESETDEPTH"]));
								if (num5.HasValue)
								{
									waypoint.DepthPreset = (ActiveUnit_AI.SubmarineDepthPreset)Math.Round(num5.Value);
								}
							}
							if (dictionary.ContainsKey("PRESETTHROTTLE"))
							{
								string text = Conversions.ToString(dictionary["PRESETTHROTTLE"]);
								if (Operators.CompareString(text, "5", TextCompare: false) != 0 && Operators.CompareString(text.ToLower(), "none", TextCompare: false) != 0)
								{
									ActiveUnit.Throttle? throttle = LuaUtility.QueryThrottleObject(text);
									if (throttle.HasValue)
									{
										waypoint.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)throttle.Value;
									}
								}
								else
								{
									waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
								}
							}
							if (dictionary.ContainsKey("TF"))
							{
								bool? flag3 = LuaUtility.ParseBoolean(Conversions.ToString(dictionary["TF"]));
								if (flag3.HasValue)
								{
									waypoint.TerrainFollowing = flag3.Value;
								}
							}
							if (dictionary.ContainsKey("DESIREDALTITUDE"))
							{
								float? num6 = LuaUtility.QueryAltitudeObject(Conversions.ToString(dictionary["DESIREDALTITUDE"]));
								if ((object)num6.GetType() == typeof(float))
								{
									waypoint.DesiredAltitude = num6.Value;
									waypoint.DesiredAltitudeOverride = true;
								}
							}
							if (dictionary.ContainsKey("DESIREDALTITUDETF"))
							{
								float? num7 = LuaUtility.QueryAltitudeObject(Conversions.ToString(dictionary["DESIREDALTITUDETF"]));
								if ((object)num7.GetType() == typeof(float))
								{
									waypoint.DesiredAltitude_TerrainFollowing = num7.Value;
								}
							}
							if (dictionary.ContainsKey("DESIREDSPEED"))
							{
								float num8 = Conversions.ToSingle(Conversions.ToString(dictionary["DESIREDSPEED"]));
								int maximumSpeed = au.Kinematics.GetMaximumSpeed();
								if ((maximumSpeed == 0) & au.IsGroup)
								{
									maximumSpeed = ((Group)au).Kinematics.GetMaximumSpeed(waypoint.Altitude);
								}
								if (num8 > (float)maximumSpeed)
								{
									num8 = maximumSpeed;
								}
								waypoint.DesiredSpeed = num8;
								waypoint.DesiredSpeedOverride = num8;
							}
							if (dictionary.ContainsKey("DESCRIPTION"))
							{
								waypoint.Description = Conversions.ToString(dictionary["DESCRIPTION"]);
							}
							continue;
						}
						throw new LuaError("路径对象" + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue)) + "纬度或经度不能为0。");
					}
					throw new LuaError("路径对象" + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue)) + "需要纬度或经度。");
				}
				throw new LuaError("Error at " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue)));
			}
		}
	}

	[DoNotPrune]
	public override LuaTable fuel
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			foreach (FuelRec item in au.Fuel_ReadOnly)
			{
				if (val[Convert.ToInt32((short)item.FuelType)] == null)
				{
					LuaTable val2 = LuaSandBox.Singleton().CreateTable();
					val2["current"] = item.CurrentQuantity;
					val2["max"] = item.MaxQuantity;
					val2["name"] = item.FuelType.ToString();
					val2["type"] = Convert.ToInt32((short)item.FuelType);
					val[Convert.ToInt32((short)item.FuelType)] = val2;
				}
				else
				{
					LuaTable val3 = (LuaTable)val[Convert.ToInt32((short)item.FuelType)];
					val3["current"] = Conversions.ToSingle(val3["current"]) + item.CurrentQuantity;
					val3["max"] = Conversions.ToSingle(val3["max"]) + (float)item.MaxQuantity;
				}
			}
			return val;
		}
		set
		{
			try
			{
				IEnumerator enumerator = null;
				try
				{
					enumerator = value.Keys.GetEnumerator();
					while (enumerator.MoveNext())
					{
						double num = Conversions.ToDouble(enumerator.Current);
						float num2 = Conversions.ToSingle(((LuaTable)value[num])["current"]);
						if (au.IsAircraft)
						{
							((Aircraft)au).FuelCapacitySet(num2);
							continue;
						}
						foreach (FuelRec item in au.Fuel_ReadOnly)
						{
							if ((double)item.FuelType == num)
							{
								float val = Math.Min(item.MaxQuantity, num2);
								float num5 = (item.CurrentQuantity = Math.Max(0f, val));
								float num3 = num5;
								val = num3;
								num2 -= val;
							}
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
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("设置燃油时出错。");
			}
		}
	}

	[DoNotPrune]
	public override object group
	{
		get
		{
			if ((au.GetParentGroup() != null) | au.IsGroup)
			{
				if (au.GetParentGroup() == null)
				{
					return new LuaWrapper_Group((Group)au, ScenarioContext);
				}
				return new LuaWrapper_Group(au.GetParentGroup(), ScenarioContext);
			}
			return null;
		}
		set
		{
			try
			{
				if (au.UnitType == GlobalVariables.ActiveUnitType.None)
				{
					throw new LuaError("无法更改组中的组。");
				}
				if (Operators.CompareString(Conversions.ToString(value).ToLower(), "none", TextCompare: false) == 0)
				{
					au.SetParentGroup(bool_0: false, null);
					return;
				}
				Group group = LuaUtility.QueryGroupObject(RuntimeHelpers.GetObjectValue(value), au.GetUnitSide(), ScenarioContext);
				if (group == null)
				{
					List<ActiveUnit> list = new List<ActiveUnit>();
					list.Add(au);
					ref Scenario scenarioContext = ref ScenarioContext;
					ActiveUnit activeUnit;
					Side side_ = (activeUnit = au).GetUnitSide();
					Group obj = new Group(ref scenarioContext, ref side_, list);
					activeUnit.SetUnitSide(bool_0: false, side_);
					Group group2 = obj;
					group2.Name = Conversions.ToString(value);
					au.SetParentGroup(bool_0: false, group2);
				}
				else
				{
					au.SetParentGroup(bool_0: false, group);
				}
			}
			catch (LuaError projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	[DoNotPrune]
	public object groupLead
	{
		get
		{
			if ((au.GetParentGroup() != null) | au.IsGroup)
			{
				if (au.GetParentGroup() == null)
				{
					return new LuaWrapper_ActiveUnit_SE(au, ScenarioContext);
				}
				return new LuaWrapper_ActiveUnit_SE(au.GetParentGroup().GroupLead, ScenarioContext);
			}
			return null;
		}
		set
		{
			try
			{
				if ((au.GetParentGroup() != null) | au.IsGroup)
				{
					ActiveUnit activeUnit = PrivateMethods.smethod_0(Conversions.ToString(value), ScenarioContext);
					if (activeUnit == null)
					{
						throw new LuaError("Invalid group lead.");
					}
					if (au.GetParentGroup() == null)
					{
						((Group)au).SetGroupLead(activeUnit);
					}
					else
					{
						au.GetParentGroup().SetGroupLead(activeUnit);
					}
				}
			}
			catch (LuaError projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	[DoNotPrune]
	public override LuaTable formation
	{
		get
		{
			if (au.GetParentGroup() == null)
			{
				if (au.IsGroup)
				{
					Group group = (Group)au;
					ActiveUnit activeUnit = group.GroupLead;
					LuaTable obj = LuaSandBox.Singleton().CreateTable();
					obj["lead"] = activeUnit.ObjectID;
					obj["name"] = group.LastFormationSet;
					obj["spacing"] = group.LastFormationSpacing;
					obj["spacing_unit"] = group.LastFormationSpacingUnits;
					return obj;
				}
				return null;
			}
			ActiveUnit activeUnit_ = au.GetParentGroup().GroupLead;
			LuaTable obj2 = LuaSandBox.Singleton().CreateTable();
			ActiveUnit_Navigator.FormationStation unitFormationStation = au.Navigator.UnitFormationStation;
			obj2["guid"] = au.ObjectID;
			obj2["bearing"] = unitFormationStation.Bearing;
			obj2["type"] = unitFormationStation.BearingType.ToString();
			obj2["distance"] = unitFormationStation.Distance;
			obj2["sprint"] = au.Navigator.SprintDrift.ToString();
			Tuple<double, double> latitudeAndLongitude = unitFormationStation.GetLatitudeAndLongitude(au, activeUnit_);
			obj2["latitude"] = latitudeAndLongitude.Item1;
			obj2["longitude"] = latitudeAndLongitude.Item2;
			return obj2;
		}
		set
		{
			try
			{
				if (au.GetParentGroup() == null)
				{
					if (!au.IsGroup)
					{
						return;
					}
					Group obj = (Group)au;
					ActiveUnit activeUnit = obj.GroupLead;
					float num = obj.LastFormationSpacing;
					float float_ = activeUnit.DesiredHeading;
					string string_ = "";
					byte int_ = obj.LastFormationSpacingUnits;
					bool bool_ = false;
					IEnumerator enumerator = null;
					try
					{
						enumerator = value.Keys.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
							switch (objectValue.ToString().ToLower())
							{
							case "transpose":
								if (LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value[RuntimeHelpers.GetObjectValue(objectValue)])).HasValue)
								{
									bool_ = Conversions.ToBoolean(value[RuntimeHelpers.GetObjectValue(objectValue)]);
								}
								break;
							case "spacing_unit":
								int_ = Conversions.ToByte(value[RuntimeHelpers.GetObjectValue(objectValue)]);
								break;
							case "spacing":
								num = Conversions.ToSingle(value[RuntimeHelpers.GetObjectValue(objectValue)]);
								break;
							case "name":
								string_ = Conversions.ToString(value[RuntimeHelpers.GetObjectValue(objectValue)]);
								break;
							case "bearing":
								float_ = Conversions.ToSingle(value[RuntimeHelpers.GetObjectValue(objectValue)]);
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
					if (num == 0f)
					{
						num = 1f;
					}
					StandardFormation.SetFormation(au, string_, float_, num, int_, bool_);
					return;
				}
				ActiveUnit activeUnit2 = au.GetParentGroup().GroupLead;
				ActiveUnit_Navigator.FormationStation unitFormationStation = au.Navigator.UnitFormationStation;
				bool flag = false;
				IEnumerator enumerator2 = null;
				try
				{
					enumerator2 = value.Keys.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						object objectValue2 = RuntimeHelpers.GetObjectValue(enumerator2.Current);
						switch (objectValue2.ToString().ToLower())
						{
						case "type":
						{
							ReferencePoint.OrientationType result = ReferencePoint.OrientationType.Fixed;
							if (Enum.TryParse<ReferencePoint.OrientationType>(Conversions.ToString(value[RuntimeHelpers.GetObjectValue(objectValue2)]), ignoreCase: true, out result) && Enum.IsDefined(typeof(ReferencePoint.OrientationType), result))
							{
								unitFormationStation.BearingType = result;
							}
							break;
						}
						case "transpose":
							if (LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value[RuntimeHelpers.GetObjectValue(objectValue2)])).HasValue)
							{
								flag = Conversions.ToBoolean(value[RuntimeHelpers.GetObjectValue(objectValue2)]);
							}
							break;
						case "sprint":
						{
							bool? flag2 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value[RuntimeHelpers.GetObjectValue(objectValue2)]));
							if (flag2.HasValue)
							{
								au.Navigator.SprintDrift = flag2.Value;
							}
							break;
						}
						case "distance":
						{
							float num3 = Conversions.ToSingle(value[RuntimeHelpers.GetObjectValue(objectValue2)]);
							if (num3 > 0f)
							{
								unitFormationStation.Distance = num3;
							}
							break;
						}
						case "bearing":
						{
							float num2 = Conversions.ToSingle(value[RuntimeHelpers.GetObjectValue(objectValue2)]);
							if (num2 >= 0f && num2 < 360f)
							{
								unitFormationStation.Bearing = num2;
							}
							break;
						}
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
				if (unitFormationStation != null)
				{
					Geodesic_Vincenty.TCoord tcoord_ = new Geodesic_Vincenty.TCoord(activeUnit2.GetLatitude(), activeUnit2.GetLongitude());
					Geodesic_Vincenty.TCoord tcoord_2 = default(Geodesic_Vincenty.TCoord);
					Geodesic_Vincenty.fw_vincenty_wgs84(ref tcoord_, ref tcoord_2, unitFormationStation.Bearing, unitFormationStation.Distance);
					double lat = tcoord_2.Lat;
					double lon = tcoord_2.Lon;
					if (flag)
					{
						Tuple<double, double> validatedLatitudeAndLongitude = au.Navigator.UnitFormationStation.GetValidatedLatitudeAndLongitude(au, activeUnit2);
						au.Teleport(ref au.ParentScen, validatedLatitudeAndLongitude.Item2, validatedLatitudeAndLongitude.Item1);
					}
					else
					{
						au.Navigator.ClearPlottedCourse();
						au.Navigator.CalculateFormationStationRelativeData(lon, lat, bool_1: true);
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("设置队形错误。");
			}
		}
	}

	[DoNotPrune]
	public override object heading
	{
		get
		{
			return au.CurrentHeading;
		}
		set
		{
			float result = 0f;
			try
			{
				if (float.TryParse(Conversions.ToString(value), out result))
				{
					au.CurrentHeading = result;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public override LuaTable OODA
	{
		get
		{
			LuaTable obj = LuaSandBox.Singleton().CreateTable();
			obj["detection"] = au.m_TokenVal;
			obj["targeting"] = au._IndexerVal;
			obj["evasion"] = au._ResolverVal;
			return obj;
		}
		set
		{
			try
			{
				IEnumerator enumerator = null;
				try
				{
					enumerator = value.Keys.GetEnumerator();
					while (enumerator.MoveNext())
					{
						string text = Conversions.ToString(enumerator.Current);
						short num = Conversions.ToShort(value[text]);
						switch (text)
						{
						case "targeting":
							au._IndexerVal = num;
							break;
						case "evasion":
							au._ResolverVal = num;
							break;
						case "detection":
							au.m_TokenVal = num;
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
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("设置OODA时出错。");
			}
		}
	}

	[DoNotPrune]
	public override LuaWrapper_ActiveUnit @base
	{
		get
		{
			LuaWrapper_ActiveUnit result = null;
			switch (base.type)
			{
			case "Ship":
			case "Submarine":
			{
				if (au.DockingOps == null)
				{
					break;
				}
				ActiveUnit_DockingOps dockingOps = au.DockingOps;
				if (dockingOps.CurrentHostUnit == null)
				{
					if (dockingOps.ActualDestinationHost != null)
					{
						result = new LuaWrapper_ActiveUnit(dockingOps.ActualDestinationHost, ScenarioContext);
					}
				}
				else
				{
					result = new LuaWrapper_ActiveUnit(dockingOps.CurrentHostUnit, ScenarioContext);
				}
				break;
			}
			case "Aircraft":
			{
				if (au.AirOps == null)
				{
					break;
				}
				Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)au.AirOps;
				if (aircraft_AirOps.CurrentHostUnit == null)
				{
					if (aircraft_AirOps.ActualDestinationHost != null)
					{
						result = new LuaWrapper_ActiveUnit(aircraft_AirOps.ActualDestinationHost, ScenarioContext);
					}
				}
				else
				{
					result = new LuaWrapper_ActiveUnit(aircraft_AirOps.CurrentHostUnit, ScenarioContext);
				}
				break;
			}
			}
			return result;
		}
		set
		{
			switch (base.type)
			{
			case "Ship":
			case "Submarine":
			{
				if (au.DockingOps == null)
				{
					break;
				}
				ActiveUnit_DockingOps dockingOps = au.DockingOps;
				if (value == null)
				{
					dockingOps.PickNewAssignedHost_Nearest();
					break;
				}
				ActiveUnit activeUnit_2 = PrivateMethods.smethod_0(value.guid, ScenarioContext);
				if (Operators.CompareString(dockingOps.ThisUnitCanHostMe(activeUnit_2), "OK", TextCompare: false) == 0)
				{
					dockingOps.SetAssignedHostUnit(bool_0: false, activeUnit_2);
				}
				break;
			}
			case "Aircraft":
			{
				if (au.AirOps == null)
				{
					break;
				}
				Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)au.AirOps;
				if (value == null)
				{
					aircraft_AirOps.PickNewAssignedHost_Nearest();
					break;
				}
				ActiveUnit activeUnit_ = PrivateMethods.smethod_0(value.guid, ScenarioContext);
				if (Operators.CompareString(aircraft_AirOps.ThisUnitCanHostMe(activeUnit_), "OK", TextCompare: false) == 0)
				{
					aircraft_AirOps.SetAssignedHostUnit(bool_0: false, activeUnit_);
				}
				break;
			}
			}
		}
	}

	[DoNotPrune]
	public override bool sprintDrift
	{
		get
		{
			if (au.Navigator == null)
			{
				return false;
			}
			return au.Navigator.SprintDrift;
		}
		set
		{
			if (au.Navigator != null)
			{
				au.Navigator.SprintDrift = value;
			}
		}
	}

	[DoNotPrune]
	public bool avoidCavitation
	{
		get
		{
			if (au.Navigator == null)
			{
				return false;
			}
			return au.Navigator.AvoidCavitation;
		}
		set
		{
			if (au.Navigator == null)
			{
				return;
			}
			if (au.IsGroup && ((Group)au).Units.Count > 0)
			{
				foreach (ActiveUnit value2 in ((Group)au).Units.Values)
				{
					value2.Navigator.AvoidCavitation = value;
				}
			}
			au.Navigator.AvoidCavitation = value;
		}
	}

	[DoNotPrune]
	public bool AI_EvaluateTargets_enabled
	{
		get
		{
			return au.AI.EvaluateTargets_Enabled;
		}
		set
		{
			au.AI.EvaluateTargets_Enabled = value;
		}
	}

	[DoNotPrune]
	public bool AI_DeterminePrimaryTarget_enabled
	{
		get
		{
			return au.AI.DeterminePrimaryTarget_Enabled;
		}
		set
		{
			au.AI.DeterminePrimaryTarget_Enabled = value;
		}
	}

	[DoNotPrune]
	public bool Boolean_0
	{
		get
		{
			return au.Sensory.Boolean_0;
		}
		set
		{
			au.Sensory.Boolean_0 = value;
		}
	}

	[DoNotPrune]
	public override LuaTable sensors
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			Sensor[] array = au.Sensors_ReadOnly();
			Sensor[] array2 = array;
			foreach (Sensor sensor in array2)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["sensor_dbid"] = sensor.DBID;
				val2["sensor_guid"] = sensor.ObjectID;
				val2["sensor_name"] = sensor.Name;
				val2["sensor_type"] = (short)sensor.Type;
				val2["sensor_role"] = (long)sensor.Role;
				val2["sensor_maxrange"] = sensor.maxRange;
				val2["sensor_status"] = sensor.Status.ToString();
				val2["sensor_isactive"] = sensor.IsActive;
				if (sensor.Status != 0)
				{
					val2["sensor_statusR"] = sensor.ReasonForInoperative;
					val2["sensor_damage"] = sensor.DamageSeverity.ToString();
				}
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
		set
		{
			string b = null;
			PlatformComponent._ComponentStatus? componentStatus = null;
			bool? flag = null;
			try
			{
				IEnumerator enumerator = null;
				try
				{
					enumerator = value.Keys.GetEnumerator();
					while (enumerator.MoveNext())
					{
						string text = Conversions.ToString(enumerator.Current);
						switch (text)
						{
						case "sensor_status":
						{
							Enum.TryParse<PlatformComponent._ComponentStatus>(Conversions.ToString(value[text]), out var result);
							Enum.IsDefined(typeof(PlatformComponent._ComponentStatus), result);
							componentStatus = result;
							break;
						}
						case "sensor_isactive":
							flag = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value[text]));
							break;
						case "sensor_guid":
							b = Conversions.ToString(value[text]);
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
				Sensor[] array = au.Sensors_ReadOnly();
				Sensor[] array2 = array;
				foreach (Sensor sensor in array2)
				{
					if (!string.Equals(sensor.ObjectID, b, StringComparison.OrdinalIgnoreCase))
					{
						continue;
					}
					if (flag.HasValue)
					{
						if (flag.GetValueOrDefault())
						{
							sensor.GoActive();
						}
						else
						{
							sensor.GoPassive();
						}
					}
					if (componentStatus.HasValue)
					{
						byte? b2 = (byte?)componentStatus;
						if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
						{
							sensor.MakeOperational(bool_0: false);
						}
						b2 = (byte?)componentStatus;
						if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null).GetValueOrDefault())
						{
							sensor.Destroy(au.GetUnitSide(), bool_0: true, bool_1: false);
						}
						b2 = (byte?)componentStatus;
						if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null).GetValueOrDefault())
						{
							sensor.Damage(PlatformComponent._DamageSeverityFactor.Light);
						}
					}
					break;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("Error setting sensor.");
			}
		}
	}

	[DoNotPrune]
	public override LuaTable components
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (au.OrderIssuer().Count <= 0)
			{
				return val;
			}
			foreach (PlatformComponent item in au.OrderIssuer())
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["comp_guid"] = item.ObjectID;
				val2["comp_dbid"] = item.DBID;
				val2["comp_name"] = item.Name;
				val2["comp_type"] = item.GetType().Name;
				val2["comp_status"] = item.Status.ToString();
				if (item.Status != 0)
				{
					val2["comp_damage"] = item.DamageSeverity.ToString();
					val2["comp_statusR"] = item.ReasonForInoperative;
				}
				if (item.GetType() == typeof(Cargo))
				{
					val2["comp_name"] = ((Cargo)item).CargoObjectName;
					val2["comp_type"] = (int)((Cargo)item).CurrentType;
					val2["comp_dbid"] = ((Cargo)item).CargoObjectDBID;
					val2["comp_guid"] = ((Cargo)item).CargoObjectID;
				}
				if (item.GetType() == typeof(CommDevice))
				{
					val2["comp_comms_jammed"] = ((CommDevice)item).IsJammed;
				}
				else if (item.GetType() == typeof(Sensor))
				{
					val2["comp_sensor_jammed"] = ((Sensor)item).IsNeutralized;
				}
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
		set
		{
			string b = null;
			PlatformComponent._ComponentStatus? componentStatus = null;
			bool? flag = null;
			bool? isNeutralized = null;
			bool? flag2 = null;
			try
			{
				IEnumerator enumerator = null;
				try
				{
					enumerator = value.Keys.GetEnumerator();
					while (enumerator.MoveNext())
					{
						string text = Conversions.ToString(enumerator.Current);
						switch (text)
						{
						case "comp_status":
						{
							if (Enum.TryParse<PlatformComponent._ComponentStatus>(Conversions.ToString(value[text]), out var result) & Enum.IsDefined(typeof(PlatformComponent._ComponentStatus), result))
							{
								componentStatus = result;
							}
							break;
						}
						case "comp_sensor_jammed":
							isNeutralized = LuaUtility.ParseBoolean(Conversions.ToString(value[text]));
							break;
						case "comp_guid":
							b = Conversions.ToString(value[text]);
							break;
						case "comp_comms_jammed":
							flag2 = LuaUtility.ParseBoolean(Conversions.ToString(value[text]));
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
				Sensor[] array = au.Sensors_ReadOnly();
				Sensor[] array2 = array;
				foreach (Sensor sensor in array2)
				{
					if (!string.Equals(sensor.ObjectID, b, StringComparison.OrdinalIgnoreCase))
					{
						continue;
					}
					if (flag.HasValue)
					{
						if (flag.GetValueOrDefault())
						{
							sensor.GoActive();
						}
						else
						{
							sensor.GoPassive();
						}
					}
					if (componentStatus.HasValue)
					{
						byte? b2 = (byte?)componentStatus;
						if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
						{
							sensor.MakeOperational(bool_0: false);
						}
						b2 = (byte?)componentStatus;
						if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null).GetValueOrDefault())
						{
							sensor.Destroy(au.GetUnitSide(), bool_0: true, bool_1: false);
						}
						b2 = (byte?)componentStatus;
						if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null).GetValueOrDefault())
						{
							sensor.Damage(PlatformComponent._DamageSeverityFactor.Light);
						}
					}
					if (isNeutralized.HasValue)
					{
						sensor.IsNeutralized = isNeutralized;
					}
					return;
				}
				foreach (PlatformComponent item in au.OrderIssuer())
				{
					if (string.Equals(item.ObjectID, b, StringComparison.OrdinalIgnoreCase) && flag2.HasValue && item.GetType() == typeof(CommDevice))
					{
						((CommDevice)item).IsJammed = flag2.Value;
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("Error setting component.");
			}
		}
	}

	[DoNotPrune]
	public bool SAR_enabled
	{
		get
		{
			return au.EligibleForSAR;
		}
		set
		{
			au.EligibleForSAR = value;
		}
	}

	[DoNotPrune]
	public bool beingPickedUp
	{
		get
		{
			return au.IsBeingPickedUp;
		}
		set
		{
			au.IsBeingPickedUp = value;
		}
	}

	[DoNotPrune]
	public LuaWrapper_ActiveUnit pickUpTarget
	{
		get
		{
			LuaWrapper_ActiveUnit result = null;
			if (au.AI != null && au.AI.PrimaryPickupTarget != null)
			{
				return new LuaWrapper_ActiveUnit(au.AI.PrimaryPickupTarget, ScenarioContext);
			}
			return result;
		}
		set
		{
			if (value == null)
			{
				au.AI.ClearManualOrders();
			}
			else
			{
				ActiveUnit activeUnit = PrivateMethods.smethod_0(value.guid, ScenarioContext);
				if (activeUnit != null)
				{
					au.AI.PrimaryPickupTarget = activeUnit;
				}
			}
			au.Navigator.PlotCourseToPickupPoint();
		}
	}

	[DoNotPrune]
	public new object readytime
	{
		get
		{
			if ((object)au.GetType() == typeof(Aircraft))
			{
				return Misc.UpdateRequest((long)Math.Round(((Aircraft)au).AirOps.ConditionTimer), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true);
			}
			if (au.DockingOps == null)
			{
				return null;
			}
			return Misc.UpdateRequest((long)Math.Round(au.DockingOps.ConditionTimer), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true);
		}
		set
		{
			if ((object)au.GetType() == typeof(Aircraft))
			{
				if (((Aircraft)au).NewFacade() | (((Aircraft)au).AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying))
				{
					((Aircraft)au).AirOps.ConditionTimer = Conversions.ToLong(value);
					if (((Aircraft)au).AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying)
					{
						((Aircraft)au).AirOps._ValueObserver = Conversions.ToLong(value);
					}
				}
			}
			else if (au.DockingOps != null)
			{
				au.DockingOps.ConditionTimer = Conversions.ToLong(value);
			}
		}
	}

	[DoNotPrune]
	public object loadoutreadytime
	{
		get
		{
			if ((object)au.GetType() == typeof(Aircraft) && ((Aircraft)au).Loadout != null)
			{
				return Misc.UpdateRequest(((Aircraft)au).Loadout.ReadyTime, Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true);
			}
			return null;
		}
		set
		{
			if ((object)au.GetType() == typeof(Aircraft) && (((Aircraft)au).NewFacade() | (((Aircraft)au).AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying)))
			{
				((Aircraft)au).Loadout.ReadyTime = Conversions.ToInteger(value);
			}
		}
	}

	[DoNotPrune]
	public object readytime_v
	{
		get
		{
			if ((object)au.GetType() == typeof(Aircraft))
			{
				return (long)Math.Round(((Aircraft)au).AirOps.ConditionTimer);
			}
			if (au.DockingOps == null)
			{
				return null;
			}
			return (long)Math.Round(au.DockingOps.ConditionTimer);
		}
		set
		{
			if ((object)au.GetType() == typeof(Aircraft))
			{
				if (((Aircraft)au).NewFacade() | (((Aircraft)au).AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying))
				{
					((Aircraft)au).AirOps.ConditionTimer = Conversions.ToLong(value);
				}
			}
			else if (au.DockingOps != null)
			{
				au.DockingOps.ConditionTimer = Conversions.ToLong(value);
			}
		}
	}

	[DoNotPrune]
	public bool unassign
	{
		set
		{
			if (value)
			{
				au.ComputeClient(ref au);
			}
		}
	}

	[DoNotPrune]
	public float oldDamagePercent
	{
		set
		{
			if (value > 100f)
			{
				value = 100f;
			}
			if (value < 0f)
			{
				value = 0f;
			}
			if (value >= 0f && value <= 100f)
			{
				au.utilsVal = value;
			}
		}
	}

	[DoNotPrune]
	public new object desiredheading
	{
		get
		{
			return au.DesiredHeading;
		}
		set
		{
			float result = 0f;
			try
			{
				if (float.TryParse(Conversions.ToString(value), out result))
				{
					au.SetDesiredHeading(ActiveUnit.TurnRate.Max, result);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public float desiredRoll
	{
		get
		{
			return au.DesiredRoll;
		}
		set
		{
			float result = 0f;
			try
			{
				if (float.TryParse(Conversions.ToString(value), out result))
				{
					au.DesiredRoll = result;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public float desiredPitch
	{
		get
		{
			if (au.SupportsAttitude_Pitch)
			{
				return au.DesiredPitch;
			}
			return 0f;
		}
		set
		{
			float result = 0f;
			try
			{
				if (au.SupportsAttitude_Pitch && float.TryParse(Conversions.ToString(value), out result))
				{
					au.DesiredPitch = result;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public new float roll
	{
		get
		{
			return au.Attitude_Roll;
		}
		set
		{
			float result = 0f;
			try
			{
				if (float.TryParse(Conversions.ToString(value), out result))
				{
					au.Attitude_Roll = result;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public new float pitch
	{
		get
		{
			if (au.SupportsAttitude_Pitch)
			{
				return au.Attitude_Pitch;
			}
			return 0f;
		}
		set
		{
			float result = 0f;
			try
			{
				if (au.SupportsAttitude_Pitch && float.TryParse(Conversions.ToString(value), out result))
				{
					au.Attitude_Pitch = result;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public object target
	{
		get
		{
			if (au.AI.PrimaryTarget == null)
			{
				return null;
			}
			return new LuaWrapper_Contact(au.AI.PrimaryTarget, ScenarioContext, au.GetUnitSide());
		}
		set
		{
			string text = null;
			Contact contact = null;
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)value).GetEnumerator());
			if (dictionary.ContainsKey("GUID"))
			{
				try
				{
					text = Conversions.ToString(dictionary["GUID"]);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					throw new LuaError("guid必须是一个字符串");
				}
			}
			if (Operators.CompareString(text.ToLower(), "none", TextCompare: false) == 0)
			{
				au.AI.DropTarget(au.AI.PrimaryTarget);
				au.AI.DeterminePrimaryTarget_Enabled = true;
			}
			else
			{
				if (string.IsNullOrEmpty(text))
				{
					return;
				}
				contact = PrivateMethods.ValidateContactBySceanrio(text, ScenarioContext);
				if (contact == null)
				{
					ActiveUnit activeUnit = PrivateMethods.smethod_0(text, ScenarioContext);
					if (activeUnit != null)
					{
						Side unitSide = au.GetUnitSide();
						foreach (Contact contacts_ in unitSide.Contacts_List)
						{
							if (Operators.CompareString(contacts_.ActualUnit.ObjectID, activeUnit.ObjectID, TextCompare: false) == 0)
							{
								contact = contacts_;
								break;
							}
						}
						foreach (string key in unitSide.m_InfoFacade.Keys)
						{
							if (Operators.CompareString(key, activeUnit.ObjectID, TextCompare: false) == 0 && !unitSide.Contacts_List.Contains(unitSide.m_InfoFacade[key]))
							{
								contact = unitSide.m_InfoFacade[key];
								break;
							}
						}
					}
				}
				if (contact == null)
				{
					double num = 0.0;
					new List<Waypoint>();
					if (Operators.CompareString(text.ToUpper(), "BOL", TextCompare: false) == 0)
					{
						string string_ = null;
						if (dictionary.ContainsKey("LATITUDE"))
						{
							string_ = Conversions.ToString(dictionary["LATITUDE"]);
						}
						double double_ = LuaUtility.ParseLatitudeString(string_);
						string_ = "";
						if (dictionary.ContainsKey("LONGITUDE"))
						{
							string_ = Conversions.ToString(dictionary["LONGITUDE"]);
						}
						num = LuaUtility.ParseLongitudeString(string_);
						contact = new ActivationPointContact(double_, num);
					}
				}
				if (contact != null)
				{
					au.AI.PrimaryTarget = contact;
					if (contact.Type != Contact_Base.ContactType.ActivationPoint)
					{
						au.AI.DeterminePrimaryTarget_Enabled = false;
					}
				}
			}
		}
	}

	public LuaWrapper_ActiveUnit_SE(ActiveUnit activeUnit_0, Scenario scenario_0)
		: base(activeUnit_0, scenario_0)
	{
	}

	public LuaWrapper_ActiveUnit_SE(UnguidedWeapon unguidedWeapon_0, Scenario scenario_0)
		: base(unguidedWeapon_0, scenario_0)
	{
	}

	[DoNotPrune]
	public void updateorbit(LuaTable luaTable_0)
	{
		if (au.IsSatellite)
		{
			Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			LuaUtility.ParseUnitDict(ref dictionary_);
			if (dictionary_.ContainsKey("TLE"))
			{
				string text = Conversions.ToString(dictionary_["TLE"]);
				try
				{
					string[] orbit_OT = text.Split('\n');
					((Satellite)au).Kinematics.SetOrbit_OT(orbit_OT);
					return;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					throw new LuaError(ex.Message);
				}
			}
			return;
		}
		throw new LuaError("单元：" + au.Name + "不是卫星！");
	}

	[DoNotPrune]
	public void delete()
	{
		ScenarioContext.DeleteUnitImmediately(au.ObjectID, bool_0: true, "Deleted via Lua command.");
	}

	[DoNotPrune]
	public bool RTB(bool bool_0)
	{
		bool result = false;
		if (bool_0)
		{
			switch (base.type)
			{
			case "Ship":
			case "Submarine":
				if (au.DockingOps != null)
				{
					result = au.DockingOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
				}
				break;
			case "Aircraft":
				if (au.AirOps != null)
				{
					result = ((Aircraft)au).AirOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
				}
				break;
			}
		}
		else
		{
			switch (base.type)
			{
			case "Ship":
			case "Submarine":
				au.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				break;
			case "Aircraft":
				au.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				break;
			}
		}
		return result;
	}

	[DoNotPrune]
	public bool Launch(bool bool_0)
	{
		bool result = false;
		if (bool_0)
		{
			switch (base.type)
			{
			case "Ship":
			case "Submarine":
				if (au.DockingOps != null && au.IsParkedAndReady())
				{
					au.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.DeployingUnderway;
					result = true;
				}
				break;
			case "Aircraft":
			{
				Aircraft aircraft = (Aircraft)au;
				if (au.AirOps != null && aircraft.PushFacade())
				{
					aircraft.AirOps.AttemptToMoveToRunway(bool_0: true);
					result = true;
				}
				break;
			}
			}
		}
		else
		{
			switch (base.type)
			{
			case "Ship":
			case "Submarine":
				if (au.DockingOps != null && au.DockingOps.IsDeploying)
				{
					au.DockingOps.AttemptToStartDocking(au.DockingOps.CurrentHostUnit, bool_0: true);
					result = true;
				}
				break;
			case "Aircraft":
			{
				if (au.AirOps == null)
				{
					break;
				}
				Aircraft aircraft2 = (Aircraft)au;
				if (aircraft2.AirOps.IsTakingOff)
				{
					aircraft2.AirOps.AttemptToPark(bool_0: true, bool_1: false, bool_2: true);
					if (aircraft2.Navigator.HasFlight)
					{
						aircraft2.Navigator.GetFlight().SetStatus(ScenarioContext, Mission._FlightStatus.None);
					}
					result = true;
				}
				break;
			}
			}
			if (au.IsGroupMember())
			{
				au.SetParentGroup(bool_0: false, null);
			}
		}
		return result;
	}

	[DoNotPrune]
	public override string ToString()
	{
		string text = "unit {\r\n type = '" + base.type + "', \r\n subtype = '" + base.subtype + "', \r\n name = '" + base.name + "', \r\n side = '" + base.side + "', \r\n guid = '" + base.guid.ToString() + "', \r\n class = '" + base.classname.ToString() + "', \r\n proficiency = '" + proficiency + "', \r\n latitude = '" + latitude + "', \r\n longitude = '" + longitude + "', \r\n altitude = '" + altitude.ToString() + "', \r\n heading = '" + heading.ToString() + "', \r\n speed = '" + speed.ToString() + "', \r\n throttle = '" + ((ActiveUnit.Throttle)Conversions.ToByte(throttle)).ToString() + "', \r\n autodetectable = '" + autodetectable + "', \r\n";
		if (@base != null)
		{
			text = text + " base = '" + @base.name + "', \r\n";
		}
		if ((group != null) & !au.IsGroup)
		{
			LuaWrapper_Group luaWrapper_Group = (LuaWrapper_Group)group;
			text = text + " group = '" + luaWrapper_Group.name + "', \r\n";
		}
		if (base.mission != null)
		{
			LuaWrapper_Mission luaWrapper_Mission = (LuaWrapper_Mission)base.mission;
			text = text + " mission = '" + luaWrapper_Mission.name + "', \r\n";
		}
		if (Operators.CompareString(base.type, "None", TextCompare: false) != 0)
		{
			try
			{
				if (au.Mounts != null)
				{
					text = text + " mounts = '" + au.Mounts.Count + "', \r\n";
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			try
			{
				if (au.TotalMagazines != null)
				{
					text = text + " magazines = '" + au.TotalMagazines.Count() + "', \r\n";
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
		}
		text = text + " unitstate = '" + au.Status.ToString() + "', \r\n";
		text = text + " fuelstate = '" + au.FuelState.ToString() + "', \r\n";
		text = text + " weaponstate = '" + au.WeaponState.ToString() + "', \r\n";
		text = text + " AllowMultiMission = '" + au.AllowMultiMission + "', \r\n";
		text = text + " AssignedMissionsQueue = '" + base.AssignedMissionsQueue.ToString() + "', \r\n";
		text = text + " Decoy = '" + au.IsDecoy + "', \r\n";
		return text + "}";
	}

	public LuaWrapper_Cargo createUnitCargo(int int_0, int int_1, string string_0 = "")
	{
		bool flag = !string.IsNullOrEmpty(string_0);
		string text = string_0;
		ICargoHost cargoHost = (ICargoHost)au;
		Cargo cargo = null;
		if (cargoHost == null)
		{
			return null;
		}
		switch (int_0)
		{
		case 1:
		{
			Mount mount = DBFunctions.GetMount(int_1, ref ScenarioContext);
			if (cargoHost.CanLoad(mount))
			{
				cargo = new Cargo(au, mount);
				cargoHost.Add(cargo);
			}
			break;
		}
		case 2:
		{
			Vehicle vehicle = null;
			if (flag)
			{
				vehicle = ScenarioContext.AddNewVehicle(au.GetUnitSide(), int_1, string_0, au.GetLongitude(), au.GetLatitude(), bool_0: true);
			}
			else
			{
				SQLiteConnection sqliteConnection_2 = ScenarioContext.DBConnection;
				text = DBFunctions.GetVehicleName(int_1, ref sqliteConnection_2);
				text = text + " #" + Conversions.ToString(ScenarioContext.UnitsAutoIncrement);
				vehicle = ScenarioContext.AddNewVehicle(au.GetUnitSide(), int_1, text, au.GetLongitude(), au.GetLatitude(), bool_0: true);
			}
			if (vehicle == null)
			{
				return null;
			}
			bool flag2;
			if (cargoHost.CanLoad(vehicle) | (flag2 = cargoHost.CanTow(vehicle)))
			{
				cargo = new Cargo(au, vehicle);
				if (flag2)
				{
					cargo.StorageType = Cargo.CargoStorageType.TowedExternal;
				}
				vehicle.DockingOps.LoadIntoCargo(au);
				cargoHost.Add(cargo);
			}
			else
			{
				ScenarioContext.DeleteUnitImmediately(vehicle.ObjectID, bool_0: true, "Failed to load into cargo.");
			}
			break;
		}
		case 3:
		{
			Facility facility = null;
			if (flag)
			{
				facility = ScenarioContext.AddNewFacility(au.GetUnitSide(), int_1, string_0, au.GetLongitude(), au.GetLatitude(), bool_0: true);
			}
			else
			{
				SQLiteConnection sqliteConnection_ = ScenarioContext.DBConnection;
				text = DBFunctions.GetFacilityName(int_1, ref sqliteConnection_);
				text = text + " #" + Conversions.ToString(ScenarioContext.UnitsAutoIncrement);
				facility = ScenarioContext.AddNewFacility(au.GetUnitSide(), int_1, text, au.GetLongitude(), au.GetLatitude(), bool_0: true);
			}
			if (facility == null)
			{
				return null;
			}
			if (cargoHost.CanLoad(facility))
			{
				cargo = new Cargo(au, facility);
				facility.DockingOps.LoadIntoCargo(au);
				cargoHost.Add(cargo);
			}
			else
			{
				ScenarioContext.DeleteUnitImmediately(facility.ObjectID, bool_0: true, "Failed to load into cargo.");
			}
			break;
		}
		case 4:
		{
			CargoContainer cargoContainer = DBFunctions.GetCargoContainer(int_1, ref ScenarioContext);
			if (cargoHost.CanLoad(cargoContainer))
			{
				cargo = new Cargo(au, cargoContainer, cargoHost);
				cargoHost.Add(cargo);
			}
			break;
		}
		}
		if (cargo == null)
		{
			return null;
		}
		return new LuaWrapper_Cargo(cargo, ScenarioContext);
	}

	public bool deleteUnitCargo(string string_0)
	{
		Cargo[] onboardCargo = au.OnboardCargo;
		Cargo[] array = onboardCargo;
		foreach (Cargo cargo in array)
		{
			if (Operators.CompareString(cargo.CargoObjectID, string_0, TextCompare: false) == 0)
			{
				ArrayExtensions.Remove(ref au.OnboardCargo, cargo);
				ActiveUnit cargoObjectActiveUnit = cargo.CargoObjectActiveUnit;
				if (cargoObjectActiveUnit != null)
				{
					ScenarioContext.DeleteUnitImmediately(cargoObjectActiveUnit.ObjectID, bool_0: true, "Unit was deleted while editing cargo.");
				}
				return true;
			}
		}
		return false;
	}

	public LuaWrapper_Device_Sensor GetSensor(string string_0)
	{
		Sensor[] array = au.Sensors_ReadOnly();
		int num = 0;
		Sensor sensor;
		while (true)
		{
			if (num < array.Length)
			{
				sensor = array[num];
				if (Operators.CompareString(sensor.ObjectID, string_0, TextCompare: false) == 0)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return new LuaWrapper_Device_Sensor(sensor, ScenarioContext);
	}
}
