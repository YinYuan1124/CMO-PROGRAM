using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.CompilerServices;
using Command_Core.Lua;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core;

[StandardModule]
public sealed class LuaImportExport
{
	public static int ScenEdit_ImportInst(string string_0, string string_1, Scenario scenario_0)
	{
		Side side = null;
		side = PrivateMethods.ValidateSide(string_0, scenario_0);
		if (Information.IsNothing(side))
		{
			return 0;
		}
		string_1 = string_1.Replace("..", "");
		return scenario_0.ImportUnitsFromFile(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "ImportExport" + Conversions.ToString(Path.DirectorySeparatorChar) + string_1, side).Count;
	}

	public static int ScenEdit_ExportInst(string string_0, LuaTable luaTable_0, LuaTable luaTable_1, Scenario scenario_0)
	{
		Side side = null;
		Collection<ActiveUnit> collection = new Collection<ActiveUnit>();
		side = PrivateMethods.ValidateSide(string_0, scenario_0);
		if (Information.IsNothing(side))
		{
			return 0;
		}
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(luaTable_1.GetEnumerator());
		LuaUtility.ParseUnitDict(ref dictionary_);
		string text = "";
		string string_ = "";
		string string_2 = "";
		string string_3 = "";
		if (dictionary_.ContainsKey("FILENAME"))
		{
			try
			{
				text = Conversions.ToString(dictionary_["FILENAME"]);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("文件名必须是一个字符串");
			}
			if (dictionary_.ContainsKey("NAME"))
			{
				try
				{
					string_ = Conversions.ToString(dictionary_["NAME"]);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					throw new LuaError("名称必须是一个字符串");
				}
			}
			if (dictionary_.ContainsKey("COMMENT"))
			{
				try
				{
					string_2 = Conversions.ToString(dictionary_["COMMENT"]);
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					throw new LuaError("comment必须是一个字符串");
				}
			}
			text = text.Replace("..", "");
			text = GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "ImportExport" + Conversions.ToString(Path.DirectorySeparatorChar) + text;
			foreach (object item2 in LuaUtility.ToArray(luaTable_0.GetEnumerator()))
			{
				ActiveUnit item = PrivateMethods.ValidateAUBySide(Conversions.ToString(RuntimeHelpers.GetObjectValue(item2)), side);
				collection.Add(item);
			}
			scenario_0.ExportUnitsToFile(text, string_, string_2, string_3, side, collection);
			return collection.Count;
		}
		throw new LuaError("no filename key defined");
	}
}
