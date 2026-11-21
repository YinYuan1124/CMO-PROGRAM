using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class LuaSAO
{
	public static bool ScenEdit_UseAttachment(string string_0, Scenario scenario_0)
	{
		bool result = false;
		try
		{
			if (Information.IsNothing(scenario_0))
			{
				string[] directories = Directory.GetDirectories(GameGeneral.AttachmentRepoPath);
				string[] array = directories;
				foreach (string text in array)
				{
					if (Operators.CompareString(Path.GetFileName(text), string_0, TextCompare: false) == 0)
					{
						ScenAttachmentObject scenAttachmentObject = ScenAttachmentObject.ReadFromFolder(text);
						if (!Information.IsNothing(scenAttachmentObject))
						{
							scenAttachmentObject.UseAttachment(null);
							result = true;
						}
						break;
					}
				}
			}
			else
			{
				foreach (ScenAttachmentObject value in scenario_0.ScenAttachments.Values)
				{
					if (Operators.CompareString(value.ObjectID, string_0, TextCompare: false) == 0 || Operators.CompareString(value.Name, string_0, TextCompare: false) == 0)
					{
						value.UseAttachment(scenario_0);
						result = true;
						break;
					}
				}
			}
			return result;
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

	public static bool ScenEdit_UseAttachmentOnSide(string string_0, string string_1, Scenario scenario_0)
	{
		bool result = false;
		try
		{
			Side side = null;
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side2 in array)
			{
				if (Operators.CompareString(side2.Name, string_1, TextCompare: false) == 0 || Operators.CompareString(side2.ObjectID, string_1, TextCompare: false) == 0)
				{
					side = side2;
					break;
				}
			}
			if (side == null)
			{
				throw new LuaError("未知的分方" + string_1 + " for " + string_0);
			}
			foreach (ScenAttachmentObject value in scenario_0.ScenAttachments.Values)
			{
				if (Operators.CompareString(value.ObjectID, string_0, TextCompare: false) == 0 || Operators.CompareString(value.Name, string_0, TextCompare: false) == 0)
				{
					value.UseAttachmentOnSide(scenario_0, side);
					result = true;
					break;
				}
			}
			return result;
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
