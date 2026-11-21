using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core.LoadSave;

[StandardModule]
public sealed class LoadSave
{
	private static BinaryFormatter m_PrinterReader;

	private static FileStream m_ParserReader;

	public static void UnloadScenario(Scenario scenario_0)
	{
		if (scenario_0 != null)
		{
			scenario_0.ThreadedOpsMustStop = true;
		}
	}

	public static void SaveScenario(Scenario scenario_0, Side side_0, string string_0, bool bool_0, bool bool_1 = false)
	{
		try
		{
			if (scenario_0.Sides_ReadOnly.Length != 0)
			{
				scenario_0.GameVersion = GameGeneral.ProgramTitle;
				if (!bool_0 && side_0 == null)
				{
					scenario_0.SetCurrentSide(scenario_0.Sides_ReadOnly[0]);
				}
				ScenContainer scenContainer = new ScenContainer(scenario_0);
				scenContainer.ScenTitle = scenario_0.Title;
				scenContainer.ScenDescription = scenario_0.Description;
				scenContainer.Complexity = scenario_0.Meta_Complexity;
				scenContainer.Difficulty = scenario_0.Meta_Difficulty;
				scenContainer.ScenSetting = scenario_0.Meta_ScenSetting;
				scenContainer.ScenDate = (short)scenario_0.StartTime.Year;
				scenContainer.SaveCurrentTime = scenario_0.Time.ToBinary();
				scenContainer.CampaignID = scenario_0.CampaignID;
				scenContainer.CampaignSessionID = scenario_0.CampaignSessionID;
				if (bool_1)
				{
					scenContainer.IsCampaignCheckpoint = true;
				}
				scenContainer.SaveToFile(string_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101087", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static object EnableList(string string_0, ref long long_0)
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		object objectValue = RuntimeHelpers.GetObjectValue(new object());
		using (new FileStream(string_0, FileMode.Open, FileAccess.Read))
		{
			if (long_0 < m_ParserReader.Length)
			{
				m_ParserReader.Seek(long_0, SeekOrigin.Begin);
				objectValue = RuntimeHelpers.GetObjectValue(binaryFormatter.Deserialize(m_ParserReader));
				long_0 = m_ParserReader.Position;
				return objectValue;
			}
			return objectValue;
		}
	}

	private static void ChangeList(string string_0, object object_0)
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream fileStream = new FileStream(string_0, FileMode.Create, FileAccess.Write);
		using (fileStream)
		{
			binaryFormatter.Serialize(fileStream, object_0);
		}
	}

	public static void SaveScenario_XML(string string_0, MemoryTributary memoryTributary_0)
	{
		try
		{
			FileStream fileStream = File.Create(string_0);
			fileStream.Write(memoryTributary_0.ToArray(), 0, (int)memoryTributary_0.Position);
			fileStream.Close();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static Scenario InitList(string string_0)
	{
		new FileInfo(string_0);
		Scenario scenario = new Scenario(null);
		FileStream fileStream = new FileStream(string_0, FileMode.Open);
		Scenario result = (Scenario)new XmlSerializer(scenario.GetType()).Deserialize(fileStream);
		fileStream.Close();
		return result;
	}

	private static Scenario CheckList(string string_0)
	{
		new Scenario(null);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read);
		Scenario result = (Scenario)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		fileStream = null;
		return result;
	}
}
