using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Recorder
{
	public static bool SnapshotProcessingIsInProgress;

	public static string VCR_ScratchFilePath => GameGeneral.TempPath;

	[SpecialName]
	private static string GetRecordingsPath()
	{
		return Path.Combine(GameGeneral.TopLevelWritablePath, "Recordings" + Conversions.ToString(Path.DirectorySeparatorChar));
	}

	public static RecorderTape CreateNewTape(string string_0, string string_1)
	{
		try
		{
			string text = (string.IsNullOrEmpty(string_1) ? Guid.NewGuid().ToString() : string_1);
			RecorderTape recorderTape = new RecorderTape();
			if (string.IsNullOrEmpty(string_0))
			{
				File.Copy(GetRecordingsPath() + "Sample.rec", GetRecordingsPath() + text + ".rec");
				recorderTape.FileName = GetRecordingsPath() + text + ".rec";
			}
			else
			{
				File.Copy(GetRecordingsPath() + "Sample.rec", Path.Combine(string_0, text) + ".rec");
				recorderTape.FileName = Path.Combine(string_0, text) + ".rec";
			}
			recorderTape.CreationTime = DateAndTime.Now;
			return recorderTape;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101125", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			RecorderTape result = new RecorderTape();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static string FilenameOfMostRecentTape()
	{
		IEnumerable<string> source = from theF in Directory.GetFiles(GetRecordingsPath())
			select (theF) into theF
			where Operators.CompareString(theF, "Sample.rec", TextCompare: false) != 0
			orderby Directory.GetLastWriteTimeUtc(theF) descending
			select theF;
		if (source.Count() <= 0)
		{
			return null;
		}
		return source.ElementAtOrDefault(0);
	}

	public static RecorderTape GetTape(string string_0)
	{
		try
		{
			RecorderTape recorderTape = new RecorderTape();
			recorderTape.FileName = string_0;
			SQLiteDataReader val = new SQLiteHelper(new SQLiteConnection("Data Source=" + string_0 + ";Version=3")).DestroySpecification("SELECT ID, ScenarioTime from Snapshots order by ID ASC");
			while (((DbDataReader)val).Read())
			{
				recorderTape.SnapshotList.Add(new Tuple<int, DateTime>(Conversions.ToInteger(((DbDataReader)val)["ID"]), DateTime.FromBinary(Conversions.ToLong(((DbDataReader)val)["ScenarioTime"]))));
			}
			((DbDataReader)val).Close();
			return recorderTape;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101126", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			RecorderTape result = new RecorderTape();
			ProjectData.ClearProjectError();
			return result;
		}
	}
}
