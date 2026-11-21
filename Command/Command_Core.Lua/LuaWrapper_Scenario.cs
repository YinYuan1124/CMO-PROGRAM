using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPruneType]
[DoNotObfuscateType]
[DoNotPrune]
public sealed class LuaWrapper_Scenario
{
	private Scenario ScenarioContext;

	private byte mode;

	private byte status;

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
	public object __obj => ScenarioContext;

	[DoNotPrune]
	public string guid => ScenarioContext.ObjectID;

	[DoNotPrune]
	public string Duration => ScenarioContext.Duration.ToString();

	[DoNotPrune]
	public long DurationNum => (long)Math.Round(ScenarioContext.Duration.TotalSeconds);

	[DoNotPrune]
	public string StartTime => ScenarioContext.StartTime.ToString();

	[DoNotPrune]
	public long StartTimeNum => (long)Math.Round((ScenarioContext.StartTime - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds);

	[DoNotPrune]
	public string CurrentTime => ScenarioContext.Time.ToString();

	[DoNotPrune]
	public long CurrentTimeNum => (long)Math.Round((ScenarioContext.Time - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds);

	[DoNotPrune]
	public string DBUsed
	{
		get
		{
			string dBUsed = ScenarioContext.DBUsed;
			DBOps.DBFileCheckResult dbfileCheckResult_ = DBOps.DBFileCheckResult.Undefined;
			DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(dBUsed, ref dbfileCheckResult_);
			if (dBRecordByHash == null)
			{
				return ScenarioContext.DBUsed;
			}
			return dBRecordByHash.FileName;
		}
	}

	[DoNotPrune]
	public short Complexity => ScenarioContext.Meta_Complexity;

	[DoNotPrune]
	public short Difficulty => ScenarioContext.Meta_Difficulty;

	[DoNotPrune]
	public string ScenSetting => ScenarioContext.Meta_ScenSetting;

	[DoNotPrune]
	public int ScenDate => (short)ScenarioContext.StartTime.Year;

	[DoNotPrune]
	public string Title
	{
		get
		{
			return ScenarioContext.Title;
		}
		set
		{
			ScenarioContext.Title = value;
		}
	}

	[DoNotPrune]
	public string ContentTag => ScenarioContext.ContentTag;

	[DoNotPrune]
	public string CampaignID
	{
		get
		{
			if (string.IsNullOrEmpty(ScenarioContext.CampaignID))
			{
				return null;
			}
			return ScenarioContext.CampaignID;
		}
	}

	[DoNotPrune]
	public string CampaignSessionID
	{
		get
		{
			if (string.IsNullOrEmpty(ScenarioContext.CampaignSessionID))
			{
				return null;
			}
			return ScenarioContext.CampaignSessionID;
		}
	}

	[DoNotPrune]
	public int CampaignScore
	{
		get
		{
			if (string.IsNullOrEmpty(ScenarioContext.CampaignID))
			{
				return 0;
			}
			return ScenarioContext.CampaignScore;
		}
	}

	[DoNotPrune]
	public bool InCampaignMode => ScenarioContext.IsRunningInCampaignMode;

	[DoNotPrune]
	public byte GameMode
	{
		get
		{
			return mode;
		}
		set
		{
			if (mode == 0)
			{
				mode = value;
			}
		}
	}

	[DoNotPrune]
	public byte GameStatus
	{
		get
		{
			return status;
		}
		set
		{
			if (Operators.CompareString(Status, null, TextCompare: false) == 0)
			{
				status = value;
			}
		}
	}

	[DoNotPrune]
	public string FileName => ScenarioContext.FileName;

	[DoNotPrune]
	public string FileNamePath => ScenarioContext.FileNamePath;

	[DoNotPrune]
	public string SaveVersion => ScenarioContext.GameVersion;

	[DoNotPrune]
	public int Sides => ScenarioContext.Sides_ReadOnly.Count();

	[DoNotPrune]
	public bool HasStarted => ScenarioContext.HasStarted;

	[DoNotPrune]
	public string Status
	{
		get
		{
			if (ScenarioContext.GameContext != null)
			{
				switch (ScenarioContext.GameContext.Status)
				{
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return "Undefined";
				case Game._GameStatus.Running:
					return "Running";
				case Game._GameStatus.Paused:
					return "Paused";
				}
			}
			return "Undefined";
		}
	}

	[DoNotPrune]
	public string PlayerSide
	{
		get
		{
			Side currentSide = ScenarioContext.GetCurrentSide();
			if (currentSide == null)
			{
				return string.Empty;
			}
			return currentSide.ObjectID;
		}
	}

	[DoNotPrune]
	public int TimeCompression => ScenarioContext.TimeCompression_SimSeconds;

	public LuaWrapper_Scenario(Scenario scenario_0)
	{
		mode = 0;
		status = 0;
		ScenarioContext = scenario_0;
	}

	[DoNotPrune]
	public bool ResetLossExp()
	{
		Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side obj in array)
		{
			obj.AAR.Losses.Clear();
			obj.AAR.Expenditures.Clear();
		}
		return true;
	}

	[DoNotPrune]
	public bool ResetScore()
	{
		Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side obj in array)
		{
			obj.SetTotalScore(ScenarioContext, null, 0);
			obj.ScoringLog.Clear();
		}
		return true;
	}

	[DoNotPrune]
	public override string ToString()
	{
		return "scenario {\r\n FileName = '" + FileName + "', \r\n Title = '" + Title + "', \r\n ScenSetting = '" + ScenSetting + "', \r\n ScenDate = '" + ScenDate + "', \r\n Difficulty = '" + Difficulty + "', \r\n Complexity = '" + Complexity + "', \r\n StartTime = '" + StartTime + "', \r\n Duration = '" + Duration + "', \r\n CurrentTime = '" + CurrentTime + "', \r\n DBUsed = '" + DBUsed + "', \r\n SaveVersion = '" + SaveVersion + "', \r\n CampaignScore = '" + CampaignScore + "', \r\n CampaignSessionID = '" + CampaignSessionID + "', \r\n CampaignID = '" + CampaignID + "', \r\n InCampaignMode = '" + InCampaignMode + "', \r\n ContentTag = '" + ContentTag + "', \r\n StartTimeNum = '" + StartTimeNum + "', \r\n DurationNum = '" + DurationNum + "', \r\n CurrentTimeNum = '" + CurrentTimeNum + "', \r\n guid = '" + guid + "', \r\n PlayerSide = '" + PlayerSide + "', \r\n HasStarted = '" + HasStarted + "', \r\n Status = '" + Status + "', \r\n TimeCompression = '" + TimeCompression + "', \r\n GameMode = '" + GameMode + "', \r\n GameStatus = '" + GameStatus + "', \r\n}";
	}
}
