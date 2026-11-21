using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotObfuscateType]
[DoNotPruneType]
[DoNotPrune]
public sealed class LuaWrapper_Waypoint
{
	private Waypoint waypoint_0;

	private Scenario scenario_0;

	[DoNotPrune]
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
	public string objectid => waypoint_0.ObjectID;

	[DoNotPrune]
	public string guid => waypoint_0.ObjectID;

	[DoNotPrune]
	public string name
	{
		get
		{
			return waypoint_0.Name;
		}
		set
		{
			waypoint_0.Name = value;
		}
	}

	[DoNotPrune]
	public double latitude
	{
		get
		{
			return waypoint_0.Latitude;
		}
		set
		{
			double? num = LuaUtility.QueryLatitudeObject(value);
			if (!num.HasValue)
			{
				throw new LuaError("不能为纬度传递零。");
			}
			waypoint_0.Latitude = num.Value;
		}
	}

	[DoNotPrune]
	public double longitude
	{
		get
		{
			return waypoint_0.Longitude;
		}
		set
		{
			double? num = LuaUtility.QueryLongitudeObject(value);
			if (!num.HasValue)
			{
				throw new LuaError("不能为经度传递零。");
			}
			waypoint_0.Longitude = num.Value;
		}
	}

	[DoNotPrune]
	public float altitude
	{
		get
		{
			return waypoint_0.Altitude;
		}
		set
		{
			waypoint_0.Altitude = value;
		}
	}

	[DoNotPrune]
	public object type
	{
		get
		{
			return waypoint_0.Type.ToString();
		}
		set
		{
			Waypoint.WaypointType result = Waypoint.WaypointType.ManualPlottedCourseWaypoint;
			if (Enum.TryParse<Waypoint.WaypointType>(Conversions.ToString(value), ignoreCase: true, out result) && Enum.IsDefined(typeof(Waypoint.WaypointType), result))
			{
				waypoint_0.Type = result;
			}
		}
	}

	[DoNotPrune]
	public float? altitudeDesired
	{
		get
		{
			if (!waypoint_0.TerrainFollowing)
			{
				return waypoint_0.DesiredAltitude.HasValue ? waypoint_0.DesiredAltitude.Value : 0f;
			}
			return waypoint_0.DesiredAltitude_TerrainFollowing.HasValue ? waypoint_0.DesiredAltitude_TerrainFollowing.Value : 0f;
		}
		set
		{
			if (value.HasValue)
			{
				float? num = LuaUtility.QueryAltitudeObject(value);
				if ((object)num.GetType() == typeof(float))
				{
					if (waypoint_0.TerrainFollowing)
					{
						waypoint_0.DesiredAltitude_TerrainFollowing = num.Value;
					}
					else
					{
						waypoint_0.DesiredAltitude = num.Value;
					}
					waypoint_0.DesiredAltitudeOverride = true;
				}
			}
			else
			{
				waypoint_0.DesiredAltitude = null;
				waypoint_0.DesiredAltitude_TerrainFollowing = null;
				waypoint_0.DesiredAltitudeOverride = false;
			}
		}
	}

	[DoNotPrune]
	public float? speedDesired
	{
		get
		{
			return waypoint_0.DesiredSpeed.HasValue ? waypoint_0.DesiredSpeed.Value : 0f;
		}
		set
		{
			if (value.HasValue)
			{
				float value2 = value.Value;
				waypoint_0.DesiredSpeed = value2;
				waypoint_0.DesiredSpeedOverride = value2;
			}
			else
			{
				waypoint_0.DesiredSpeed = null;
				waypoint_0.DesiredSpeedOverride = null;
			}
		}
	}

	[DoNotPrune]
	public string description
	{
		get
		{
			return waypoint_0.Description;
		}
		set
		{
			waypoint_0.Description = value;
		}
	}

	[DoNotPrune]
	public bool TF
	{
		get
		{
			return waypoint_0.TerrainFollowing;
		}
		set
		{
			bool terrainFollowing = waypoint_0.TerrainFollowing;
			waypoint_0.TerrainFollowing = value;
			if (value != terrainFollowing)
			{
				if (waypoint_0.TerrainFollowing)
				{
					waypoint_0.DesiredAltitude_TerrainFollowing = waypoint_0.DesiredAltitude;
					waypoint_0.DesiredAltitude = null;
				}
				else
				{
					waypoint_0.DesiredAltitude = waypoint_0.DesiredAltitude_TerrainFollowing;
					waypoint_0.DesiredAltitude_TerrainFollowing = null;
				}
			}
		}
	}

	[DoNotPrune]
	public int TFType
	{
		get
		{
			return (int)waypoint_0.TerrainFollowingType;
		}
		set
		{
			waypoint_0.TerrainFollowingType = (ActiveUnit.TerrainFollowMode)value;
		}
	}

	[DoNotPrune]
	public object presetAltitude
	{
		get
		{
			if (waypoint_0.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.None)
			{
				return null;
			}
			return waypoint_0.AltitudePreset;
		}
		set
		{
			float? num = LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(value));
			if (num.HasValue)
			{
				waypoint_0.AltitudePreset = (ActiveUnit_AI.AircraftAltitudePreset)Math.Round(num.Value);
			}
		}
	}

	[DoNotPrune]
	public object presetDepth
	{
		get
		{
			if (waypoint_0.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.None)
			{
				return null;
			}
			return waypoint_0.DepthPreset;
		}
		set
		{
			float? num = LuaUtility.QueryDepthObject(RuntimeHelpers.GetObjectValue(value));
			if (num.HasValue)
			{
				waypoint_0.DepthPreset = (ActiveUnit_AI.SubmarineDepthPreset)Math.Round(num.Value);
			}
		}
	}

	[DoNotPrune]
	public object presetThrottle
	{
		get
		{
			if (waypoint_0.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				return null;
			}
			return waypoint_0.ThrottlePreset;
		}
		set
		{
			if (Operators.CompareString(Conversions.ToString(value), "5", TextCompare: false) != 0 && Operators.CompareString(Conversions.ToString(value).ToLower(), "none", TextCompare: false) != 0)
			{
				ActiveUnit.Throttle? throttle = LuaUtility.QueryThrottleObject(Conversions.ToString(value));
				if (throttle.HasValue)
				{
					waypoint_0.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)throttle.Value;
				}
			}
			else
			{
				waypoint_0.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			}
		}
	}

	public LuaWrapper_Waypoint(Waypoint waypoint_1, Scenario scenario_1)
	{
		waypoint_0 = waypoint_1;
		scenario_0 = scenario_1;
	}

	[DoNotPrune]
	public override string ToString()
	{
		return string.Concat("waypoint {\r\n type = '" + type.ToString() + "', \r\n name = '" + name + "', \r\n description = '" + description + "', \r\n guid = '" + guid.ToString() + "', \r\n latitude = '" + latitude + "', \r\n longitude = '" + longitude + "', \r\n altitude = '" + altitude + "', \r\n", "}");
	}
}
