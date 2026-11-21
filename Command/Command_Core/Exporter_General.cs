using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using DarkUI.Collections;
using Microsoft.VisualBasic.CompilerServices;
using Nini.Config;

namespace Command_Core;

[StandardModule]
public sealed class Exporter_General
{
	[AccessedThroughProperty("EventExporters_Interactive")]
	[CompilerGenerated]
	private static ObservableList<IEventExporter> _MockClient;

	[AccessedThroughProperty("EventExporters_MonteCarlo")]
	[CompilerGenerated]
	private static ObservableList<IEventExporter> _TagClient;

	public static string CurrentInteractiveOutputPath;

	public static Dictionary<string, string> HeaderSummaries;

	public static ObservableList<IEventExporter> EventExporters_Interactive
	{
		[CompilerGenerated]
		get
		{
			return _MockClient;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<IEventExporter>> value2 = SetupBridge;
			EventHandler<ObservableListModified<IEventExporter>> value3 = ExcludeBridge;
			ObservableList<IEventExporter> mockClient = _MockClient;
			if (mockClient != null)
			{
				mockClient.ItemsAdded -= value2;
				mockClient.ItemsRemoved -= value3;
			}
			_MockClient = value;
			mockClient = _MockClient;
			if (mockClient != null)
			{
				mockClient.ItemsAdded += value2;
				mockClient.ItemsRemoved += value3;
			}
		}
	}

	public static ObservableList<IEventExporter> EventExporters_MonteCarlo
	{
		[CompilerGenerated]
		get
		{
			return _TagClient;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<IEventExporter>> value2 = PushBridge;
			EventHandler<ObservableListModified<IEventExporter>> value3 = InvokeBridge;
			ObservableList<IEventExporter> tagClient = _TagClient;
			if (tagClient != null)
			{
				tagClient.ItemsRemoved -= value2;
				tagClient.ItemsAdded -= value3;
			}
			_TagClient = value;
			tagClient = _TagClient;
			if (tagClient != null)
			{
				tagClient.ItemsRemoved += value2;
				tagClient.ItemsAdded += value3;
			}
		}
	}

	public static string EventExporter_ConfigFileName => Path.Combine(GameGeneral.ConfigFolderPath, "EventExport.ini");

	public static string EventExporter_ResultsRoot_Interactive
	{
		get
		{
			if (FileExistsNative.FileExistsFast(EventExporter_ConfigFileName))
			{
				string text = new IniConfigSource(EventExporter_ConfigFileName).Configs["General"].Get("OutputRoot", string.Empty);
				if (Operators.CompareString(text, string.Empty, TextCompare: false) != 0 && Misc.RemoveRequest(text))
				{
					return Path.Combine(text, "Analysis_Int");
				}
				return Path.Combine(GameGeneral.TopLevelWritablePath, "Analysis_Int");
			}
			return Path.Combine(GameGeneral.TopLevelWritablePath, "Analysis_Int");
		}
		set
		{
			IniConfigSource iniConfigSource = new IniConfigSource(EventExporter_ConfigFileName);
			iniConfigSource.Configs["General"].Set("OutputRoot", value);
			iniConfigSource.Save();
		}
	}

	public static bool EventExporter_PartitionOutputs
	{
		get
		{
			if (FileExistsNative.FileExistsFast(EventExporter_ConfigFileName))
			{
				return new IniConfigSource(EventExporter_ConfigFileName).Configs["General"].GetBoolean("OutputSeparated", bool_0: false);
			}
			return false;
		}
		set
		{
			IniConfigSource iniConfigSource = new IniConfigSource(EventExporter_ConfigFileName);
			iniConfigSource.Configs["General"].Set("OutputSeparated", value);
			iniConfigSource.Save();
		}
	}

	public static bool SaveEndStateXML
	{
		get
		{
			return new IniConfigSource(EventExporter_ConfigFileName).Configs["General"].GetBoolean("SaveEndStateXML", bool_0: true);
		}
		set
		{
			IniConfigSource iniConfigSource = new IniConfigSource(EventExporter_ConfigFileName);
			iniConfigSource.Configs["General"].Set("SaveEndStateXML", value);
			iniConfigSource.Save();
		}
	}

	public static string EventExporter_OutputRoot_MonteCarlo => Path.Combine(GameGeneral.TopLevelWritablePath, "Analysis_MC");

	public static bool AutoStartExporter
	{
		get
		{
			if (FileExistsNative.FileExistsFast(EventExporter_ConfigFileName))
			{
				IniConfigSource iniConfigSource = new IniConfigSource(EventExporter_ConfigFileName);
				if (iniConfigSource.Configs["General"].Get("AutoStartExporter") == null)
				{
					iniConfigSource.Configs["General"].Set("AutoStartExporter", true);
					return true;
				}
				return iniConfigSource.Configs["General"].GetBoolean("AutoStartExporter");
			}
			return false;
		}
		set
		{
			if (FileExistsNative.FileExistsFast(EventExporter_ConfigFileName))
			{
				new IniConfigSource(EventExporter_ConfigFileName).Configs["General"].Set("AutoStartExporter", value);
			}
		}
	}

	static Exporter_General()
	{
		EventExporters_Interactive = new ObservableList<IEventExporter>();
		EventExporters_MonteCarlo = new ObservableList<IEventExporter>();
		CurrentInteractiveOutputPath = string.Empty;
		HeaderSummaries = new Dictionary<string, string>();
	}

	internal static bool ViewBridge()
	{
		if (_TagClient.Count <= 0)
		{
			return _MockClient.Count > 0;
		}
		return true;
	}

	internal static string ValidateBridge()
	{
		if (_TagClient.Count <= 0)
		{
			if (_MockClient.Count > 0 && (_MockClient.Count > 1 || !(_MockClient[0] is EventExporter_TacviewPipe)))
			{
				return CurrentInteractiveOutputPath;
			}
			return "";
		}
		return EventExporter_OutputRoot_MonteCarlo;
	}

	internal static string LoginBridge(Scenario scenario_0, DateTime dateTime_0)
	{
		if (EventExporter_PartitionOutputs && scenario_0 != null)
		{
			string path = (string.IsNullOrEmpty(scenario_0.Title) ? "Untitled" : Misc.ReplaceIllegalCharacters(scenario_0.Title, "_")) + " - " + dateTime_0.ToString("MMMM dd, yyyy - HH.mm");
			return Path.Combine(EventExporter_ResultsRoot_Interactive, path);
		}
		return string.Empty;
	}

	public static void ClearEventExporter_Interactive()
	{
		if (_MockClient.Count != 0)
		{
			int num = _MockClient.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				RemoveExporter(i);
			}
			_MockClient.Clear();
		}
	}

	internal static IEventExporter.EventExportOutputRate GetBridge(string string_0)
	{
		switch (string_0.ToUpper())
		{
		case "1HOUR":
			return IEventExporter.EventExportOutputRate.Hourx1;
		case "1MINUTE":
			return IEventExporter.EventExportOutputRate.Minutex1;
		case "6HOUR":
		case "6HOURS":
			return IEventExporter.EventExportOutputRate.Hourx6;
		case "12HOURS":
		case "12HOUR":
			return IEventExporter.EventExportOutputRate.Hourx12;
		case "CONTINUOUS":
			return IEventExporter.EventExportOutputRate.Continuous;
		case "30SECONDS":
		case "30SECOND":
			return IEventExporter.EventExportOutputRate.const_6;
		case "1SECOND":
			return IEventExporter.EventExportOutputRate.Secondx1;
		case "MATCHSIMSPEED":
			return IEventExporter.EventExportOutputRate.SimSpeed;
		case "24HOUR":
		case "24HOURS":
			return IEventExporter.EventExportOutputRate.Hourx24;
		case "15MINUTES":
		case "15MINUTE":
			return IEventExporter.EventExportOutputRate.const_9;
		case "2SECOND":
		case "2SECONDS":
			return IEventExporter.EventExportOutputRate.Secondx2;
		case "5SECOND":
		case "5SECONDS":
			return IEventExporter.EventExportOutputRate.Secondx5;
		case "15SECOND":
		case "15SECONDS":
			return IEventExporter.EventExportOutputRate.const_5;
		case "5MINUTES":
		case "5MINUTE":
			return IEventExporter.EventExportOutputRate.Minutex5;
		default:
			return IEventExporter.EventExportOutputRate.Unknown;
		case "30MINUTES":
		case "30MINUTE":
			return IEventExporter.EventExportOutputRate.const_10;
		}
	}

	public static void SetEventOutputRate(IEventExporter.ExportedEventType exportedEventType_0, IEventExporter.EventExportOutputRate eventExportOutputRate_0)
	{
		foreach (IEventExporter item in _MockClient)
		{
			item.SetOutputRate(exportedEventType_0, eventExportOutputRate_0);
		}
		foreach (IEventExporter item2 in _TagClient)
		{
			item2.SetOutputRate(exportedEventType_0, eventExportOutputRate_0);
		}
	}

	public static void StartEventExporters_Interactive(Scenario scenario_0, bool bool_0 = false)
	{
		try
		{
			if (!bool_0)
			{
				ClearEventExporter_Interactive();
			}
			if (!FileExistsNative.FileExistsFast(EventExporter_ConfigFileName))
			{
				return;
			}
			if (scenario_0 == null)
			{
				CurrentInteractiveOutputPath = EventExporter_ResultsRoot_Interactive;
			}
			else
			{
				CurrentInteractiveOutputPath = LoginBridge(scenario_0, DateTime.Now);
			}
			if (string.IsNullOrEmpty(CurrentInteractiveOutputPath))
			{
				CurrentInteractiveOutputPath = EventExporter_ResultsRoot_Interactive;
			}
			if (!Directory.Exists(CurrentInteractiveOutputPath))
			{
				Directory.CreateDirectory(CurrentInteractiveOutputPath);
			}
			if (HeaderSummaries.Count == 0)
			{
				NewBridge();
			}
			Dictionary<IEventExporter.EventExporterType, IEventExporter.EventExporterType> dictionary = new Dictionary<IEventExporter.EventExporterType, IEventExporter.EventExporterType>();
			if (!FileExistsNative.FileExistsFast(EventExporter_ConfigFileName))
			{
				return;
			}
			string[] array = new IniConfigSource(EventExporter_ConfigFileName).Configs["General"].Get("ActiveExporter").ToString().Split(Conversions.ToCharArrayRankOne(","));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				if (Operators.CompareString(array[i].Trim(), "Tacview2x", TextCompare: false) == 0 && !dictionary.ContainsKey(IEventExporter.EventExporterType.const_5))
				{
					dictionary.Add(IEventExporter.EventExporterType.const_5, IEventExporter.EventExporterType.const_5);
				}
			}
			Dictionary<IEventExporter.EventExporterType, int> dictionary2 = new Dictionary<IEventExporter.EventExporterType, int>();
			foreach (IEventExporter item in _MockClient)
			{
				dictionary2.Add(item.ExporterType, 0);
			}
			foreach (KeyValuePair<IEventExporter.EventExporterType, IEventExporter.EventExporterType> item2 in dictionary)
			{
				if (!dictionary2.ContainsKey(item2.Key))
				{
					WriteBridge(item2.Key, IEventExporter.EventExporterRunMode.Interactive, CurrentInteractiveOutputPath);
				}
			}
			if (_MockClient.Count <= 0)
			{
				return;
			}
			for (int j = _MockClient.Count - 1; j >= 0; j += -1)
			{
				if (!dictionary.ContainsKey(_MockClient.ElementAt(j).ExporterType))
				{
					RemoveExporter(j);
				}
			}
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

	public static void RemoveExporter(int int_0)
	{
		if (int_0 >= _MockClient.Count - 1)
		{
			_MockClient.ElementAt(int_0);
			_MockClient.RemoveAt(int_0);
		}
	}

	private static void WriteBridge(IEventExporter.EventExporterType eventExporterType_0, IEventExporter.EventExporterRunMode eventExporterRunMode_0, string string_0)
	{
		switch (eventExporterType_0)
		{
		case IEventExporter.EventExporterType.TacviewPipe:
			_MockClient.Add(new EventExporter_TacviewPipe(eventExporterRunMode_0));
			break;
		case IEventExporter.EventExporterType.const_5:
			_MockClient.Add(new EventExporter_Tacview2x(eventExporterRunMode_0, string_0));
			break;
		}
	}

	public static void StartEventExporters_MonteCarlo()
	{
		if (HeaderSummaries.Count == 0)
		{
			NewBridge();
		}
		if (!FileExistsNative.FileExistsFast(EventExporter_ConfigFileName))
		{
			return;
		}
		string[] array = new IniConfigSource(EventExporter_ConfigFileName).Configs["General"].Get("ActiveExporter").ToString().Split(Conversions.ToCharArrayRankOne(","));
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			if (Operators.CompareString(array[i].Trim(), "Tacview2x", TextCompare: false) == 0)
			{
				_TagClient.Add(new EventExporter_Tacview2x(IEventExporter.EventExporterRunMode.NonInteractive, EventExporter_OutputRoot_MonteCarlo));
			}
		}
	}

	private static void NewBridge()
	{
	}

	private static void PushBridge(object object_0, ObservableListModified<IEventExporter> observableListModified_0)
	{
	}

	private static void InvokeBridge(object object_0, ObservableListModified<IEventExporter> observableListModified_0)
	{
	}

	private static void SetupBridge(object object_0, ObservableListModified<IEventExporter> observableListModified_0)
	{
	}

	private static void ExcludeBridge(object object_0, ObservableListModified<IEventExporter> observableListModified_0)
	{
	}
}
