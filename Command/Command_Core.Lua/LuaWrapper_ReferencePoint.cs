using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscateType]
public sealed class LuaWrapper_ReferencePoint
{
	private ReferencePoint rp;

	private Scenario ScenarioContext;

	private Side mySide;

	[DoNotPrune]
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
	public object __obj => rp;

	[DoNotPrune]
	public string name
	{
		get
		{
			return rp.Name;
		}
		set
		{
			rp.Name = value;
		}
	}

	[DoNotPrune]
	public object latitude
	{
		get
		{
			return rp.Latitude;
		}
		set
		{
			double? num = LuaUtility.QueryLatitudeObject(RuntimeHelpers.GetObjectValue(value));
			if (!num.HasValue)
			{
				throw new LuaError("不能为纬度传递零。");
			}
			rp.Latitude = num.Value;
		}
	}

	[DoNotPrune]
	public object longitude
	{
		get
		{
			return rp.Longitude;
		}
		set
		{
			double? num = LuaUtility.QueryLongitudeObject(RuntimeHelpers.GetObjectValue(value));
			if (!num.HasValue)
			{
				throw new LuaError("不能为经度传递零。");
			}
			rp.Longitude = num.Value;
		}
	}

	[DoNotPrune]
	public string guid => rp.ObjectID;

	[DoNotPrune]
	public string side => mySide.Name;

	[DoNotPrune]
	public bool highlighted
	{
		get
		{
			return rp.IsHighlighted;
		}
		set
		{
			rp.IsHighlighted = value;
		}
	}

	[DoNotPrune]
	public bool locked
	{
		get
		{
			return rp.IsLocked;
		}
		set
		{
			rp.IsLocked = value;
		}
	}

	[DoNotPrune]
	public string color
	{
		get
		{
			return rp.color.ToArgb().ToString();
		}
		set
		{
			Color color = Color.FromName(value);
			if (color.IsKnownColor)
			{
				rp.color = color;
				return;
			}
			try
			{
				rp.color = ColorTranslator.FromHtml("#" + value);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public ReferencePoint.OrientationType bearingtype
	{
		get
		{
			if (rp.IsRelativeTo == null)
			{
				return ReferencePoint.OrientationType.Fixed;
			}
			return rp.BearingType;
		}
		set
		{
			if (rp.IsRelativeTo != null)
			{
				ReferencePoint.OrientationType result = ReferencePoint.OrientationType.Fixed;
				if (Enum.TryParse<ReferencePoint.OrientationType>(Conversions.ToString((byte)value), ignoreCase: true, out result) && Enum.IsDefined(typeof(ReferencePoint.OrientationType), result))
				{
					rp.BearingType = value;
				}
			}
		}
	}

	[DoNotPrune]
	public float relativeBearing
	{
		get
		{
			if (rp.IsRelativeTo == null)
			{
				return 0f;
			}
			return rp.RelativeBearing;
		}
		set
		{
			if (rp.IsRelativeTo != null && value >= 0f && value <= 360f)
			{
				rp.RelativeBearing = value;
			}
		}
	}

	[DoNotPrune]
	public float relativeDistance
	{
		get
		{
			if (rp.IsRelativeTo == null)
			{
				return 0f;
			}
			return rp.RelativeDistance;
		}
		set
		{
			if (rp.IsRelativeTo != null)
			{
				rp.RelativeDistance = value;
			}
		}
	}

	[DoNotPrune]
	public ScenarioObject relativeto
	{
		get
		{
			return rp.IsRelativeTo;
		}
		set
		{
			rp.IsRelativeTo = value;
		}
	}

	public LuaWrapper_ReferencePoint(ReferencePoint referencePoint_0, Side side_0, Scenario scenario_0)
	{
		rp = referencePoint_0;
		ScenarioContext = scenario_0;
		mySide = side_0;
	}

	[DoNotPrune]
	public override string ToString()
	{
		string text = "{\r\n name = '" + name + "', \r\n latitude = '" + latitude.ToString() + "', \r\n longitude = '" + longitude.ToString() + "', \r\n guid = '" + guid.ToString() + "', \r\n side = '" + side + "', \r\n highlighted = '" + highlighted + "', \r\n locked = '" + locked + "', \r\n";
		if (relativeto != null)
		{
			text = text + " bearingtype = '" + bearingtype.ToString() + "', \r\n relativeto = '" + relativeto.Name + "', \r\n";
		}
		return text + "}";
	}

	[DoNotPrune]
	public LuaTable toTable()
	{
		LuaSandBox.Singleton().CreateTable();
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		val["name"] = name;
		val["guid"] = guid;
		val["longitude"] = RuntimeHelpers.GetObjectValue(longitude);
		val["latitude"] = RuntimeHelpers.GetObjectValue(latitude);
		val["highlighted"] = highlighted;
		val["locked"] = locked;
		val["side"] = side;
		if (!Information.IsNothing(relativeto))
		{
			val["bearingtype"] = bearingtype;
			val["relativeto"] = relativeto.ObjectID;
		}
		val["color"] = color.ToString();
		return val;
	}
}
