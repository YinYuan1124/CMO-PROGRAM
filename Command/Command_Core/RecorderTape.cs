using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class RecorderTape
{
	public string FileName;

	public DateTime CreationTime;

	public Queue<Tuple<DateTime, string>> UnsavedSnapshots;

	public List<Tuple<int, DateTime>> SnapshotList;

	public long LastSnapshotDateTime;

	public RecorderTape()
	{
		UnsavedSnapshots = new Queue<Tuple<DateTime, string>>();
		SnapshotList = new List<Tuple<int, DateTime>>();
	}

	public void QueueSnapshotToSave(DateTime dateTime_0, MemoryTributary memoryTributary_0, bool bool_0 = true)
	{
		LastSnapshotDateTime = dateTime_0.ToBinary();
		NewWriter(dateTime_0, memoryTributary_0);
		if (bool_0)
		{
			memoryTributary_0.Dispose();
			memoryTributary_0 = null;
		}
		if (UnsavedSnapshots.Count > 0 && !Recorder.SnapshotProcessingIsInProgress)
		{
			ProcessUnsavedSnapshots();
		}
	}

	private void NewWriter(DateTime dateTime_0, Stream stream_0)
	{
		string text = Guid.NewGuid().ToString();
		ScenContainer scenContainer = new ScenContainer();
		scenContainer.BuildNumber = "1328.18";
		scenContainer.Version = GameGeneral.ProgramTitle;
		scenContainer.AttachAndCompressScenarioObject(stream_0);
		if (!Directory.Exists(Recorder.VCR_ScratchFilePath))
		{
			Directory.CreateDirectory(Recorder.VCR_ScratchFilePath);
		}
		scenContainer.SaveToFile(Recorder.VCR_ScratchFilePath + "\\" + text);
		UnsavedSnapshots.Enqueue(new Tuple<DateTime, string>(dateTime_0, text));
	}

	private string PushWriter(string string_0)
	{
		return ScenContainer.LoadFromFile(Recorder.VCR_ScratchFilePath + "\\" + string_0).ToString();
	}

	private void InvokeWriter(string string_0)
	{
		File.Delete(Recorder.VCR_ScratchFilePath + "\\" + string_0);
	}

	public void ProcessUnsavedSnapshots()
	{
		Recorder.SnapshotProcessingIsInProgress = true;
		while (UnsavedSnapshots.Count > 0)
		{
			Tuple<DateTime, string> tuple = UnsavedSnapshots.Dequeue();
			DateTime item = tuple.Item1;
			string string_;
			try
			{
				string_ = PushWriter(tuple.Item2);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200100", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				break;
			}
			SetupWriter(item, string_);
			InvokeWriter(tuple.Item2);
			tuple = null;
			string_ = null;
		}
		Recorder.SnapshotProcessingIsInProgress = false;
	}

	private void SetupWriter(DateTime dateTime_0, string string_0)
	{
		SQLiteConnection val = new SQLiteConnection("Data Source=" + FileName + ";Version=3");
		val.Open();
		SQLiteCommand val2 = new SQLiteCommand(val);
		val2.CommandText = "INSERT INTO Snapshots (ScenarioTime, ScenarioObject) Values (" + dateTime_0.ToBinary() + ", @theString)";
		val2.Parameters.AddWithValue("@theString", string_0);
		val2.ExecuteNonQuery();
		val.Close();
	}

	public Scenario GetSnapshot(int int_0, Action<double> action_0)
	{
		if (action_0 == null)
		{
			action_0 = delegate
			{
			};
		}
		ScenContainer scenContainer = ScenContainer.FromXML(new SQLiteHelper(new SQLiteConnection("Data Source=" + FileName + ";Version=3")).SelectSpecification("SELECT ScenarioObject from Snapshots where ID = " + Conversions.ToString(int_0)));
		string string_ = "";
		return scenContainer.GetScenarioObject(ref string_, action_0, bool_0: false);
	}
}
