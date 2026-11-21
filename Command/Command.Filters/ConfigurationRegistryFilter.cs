using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using CSMaterial;
using Command.Messages;
using Command.Tacview;
using Command.Tasks;
using Command_Core;
using DarkUI.Collections;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace Command.Filters;

[StandardModule]
internal sealed class ConfigurationRegistryFilter
{
	public static EventExporter_TacviewPipe _RecordExporter;

	[AccessedThroughProperty("Clients")]
	[CompilerGenerated]
	private static ObservableList<TacviewClient> _ExceptionExporter;

	public static readonly object m_AttrExporter;

	public static Dictionary<string, float> _VisitorExporter;

	public static float exporterExporter;

	[SpecialName]
	[CompilerGenerated]
	public static ObservableList<TacviewClient> PublishInterruptibleMap()
	{
		return _ExceptionExporter;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	public static void AwakeInterruptibleMap(ObservableList<TacviewClient> observableList_0)
	{
		EventHandler<ObservableListModified<TacviewClient>> value = PrintInterruptibleMap;
		EventHandler<ObservableListModified<TacviewClient>> value2 = DefineInterruptibleMap;
		ObservableList<TacviewClient> exceptionExporter = _ExceptionExporter;
		if (exceptionExporter != null)
		{
			exceptionExporter.ItemsAdded -= value;
			exceptionExporter.ItemsRemoved -= value2;
		}
		_ExceptionExporter = observableList_0;
		exceptionExporter = _ExceptionExporter;
		if (exceptionExporter != null)
		{
			exceptionExporter.ItemsAdded += value;
			exceptionExporter.ItemsRemoved += value2;
		}
	}

	static ConfigurationRegistryFilter()
	{
		m_AttrExporter = RuntimeHelpers.GetObjectValue(new object());
		_VisitorExporter = new Dictionary<string, float>();
		exporterExporter = 3f;
		AwakeInterruptibleMap(new ObservableList<TacviewClient>());
		MapProfile.GodsEyeStatusChanged += RestartInterruptibleMap;
		Scenario.CurrentSideChanged += ReflectInterruptibleMap;
		VisitInterruptibleMap();
	}

	private static void ReflectInterruptibleMap(object object_0)
	{
		if (object_0 == Client.CurrentScenario)
		{
			ResolveInterruptibleMap();
		}
	}

	private static void VisitInterruptibleMap()
	{
		_RecordExporter = new EventExporter_TacviewPipe(IEventExporter.EventExporterRunMode.Interactive);
		Exporter_General.EventExporters_Interactive.Add(_RecordExporter);
		_RecordExporter.PipeTelemetryToTacview += TestInterruptibleMap;
		_RecordExporter.Start();
	}

	private static void RestartInterruptibleMap(object object_0)
	{
		if (object_0 == Client.CurrentMapProfile)
		{
			ResolveInterruptibleMap();
		}
	}

	public static void TestInterruptibleMap(List<Tuple<string, IEventExporter.EventExportNotification>> list_0)
	{
		foreach (TacviewClient item in _ExceptionExporter)
		{
			item.EventQueue.Enqueue(list_0);
		}
	}

	public static byte[] StopInterruptibleMap(object object_0)
	{
		return ((IEnumerable<int>)object_0).Select((int F) => (byte)F).ToArray();
	}

	public static void CancelInterruptibleMap()
	{
		string path = (Environment.Is64BitOperatingSystem ? "Tacview64.exe" : "Tacview.exe");
		RegistryKey registryKey = ItemExporter.RegisterInterruptibleMap.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 1174860");
		if (registryKey == null)
		{
			registryKey = ItemExporter.RegisterInterruptibleMap.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Raia Software\\Tacview\\Local");
			if (registryKey != null)
			{
				string directoryName = Path.GetDirectoryName(Conversions.ToString(registryKey.GetValue("Tacview-x64")));
				SimConfiguration.DefaultGamePreferences.TacviewExePath = Path.Combine(directoryName, path);
			}
		}
		else
		{
			string path2 = Conversions.ToString(registryKey.GetValue("InstallLocation"));
			SimConfiguration.DefaultGamePreferences.TacviewExePath = Path.Combine(path2, path);
		}
	}

	public static Process VerifyInterruptibleMap(string string_0, string string_1, IntPtr intptr_0)
	{
		new Stopwatch().Start();
		ProcessStartInfo processStartInfo = new ProcessStartInfo(string_0);
		processStartInfo.CreateNoWindow = true;
		processStartInfo.UseShellExecute = false;
		Process process = new Process();
		process.StartInfo = processStartInfo;
		process.StartInfo.Arguments = string_1;
		process.Start();
		return process;
	}

	public static void ListInterruptibleMap()
	{
		ResolveInterruptibleMap();
	}

	private static void ResolveInterruptibleMap()
	{
		_RecordExporter.DestroyCache();
		int count = _ExceptionExporter.Count;
		foreach (TacviewClient item in _ExceptionExporter.ToList())
		{
			item.Close();
		}
		if (count != 0)
		{
			AssetInterruptibleMap();
		}
	}

	public static void PostInterruptibleMap()
	{
		if (Client.SelectedUnit == null || !_ExceptionExporter.Any())
		{
			return;
		}
		Module_Unit.Unit unit;
		if (Client.SelectedUnit.IsGroup)
		{
			unit = ((Group)Client.SelectedUnit).Units.Values.ElementAtOrDefault(0);
		}
		else if (Client.SelectedUnit.IsActiveUnit)
		{
			unit = (ActiveUnit)Client.SelectedUnit;
		}
		else
		{
			if (!Client.SelectedUnit.DisableWriter())
			{
				return;
			}
			unit = (Contact)Client.SelectedUnit;
		}
		if (_ExceptionExporter[0].utilsExporter)
		{
			_ExceptionExporter[0].FocusCameraOnUnit(unit.ObjectID);
			return;
		}
		if (unit.IsActiveUnit)
		{
			_ExceptionExporter[0].FocusCameraOnUnit(unit.ObjectID, (int)Math.Round(2f * ((ActiveUnit)unit).Length));
		}
		else
		{
			_ExceptionExporter[0].FocusCameraOnUnit(unit.ObjectID);
		}
		_ExceptionExporter[0].utilsExporter = true;
	}

	public static void RunInterruptibleMap()
	{
		if (Client.SelectedUnit != null && !Client.SelectedUnit.IsGroup && Client.SelectedUnit.IsActiveUnit && ((ActiveUnit)Client.SelectedUnit).AI.PrimaryTarget != null)
		{
			_ExceptionExporter[0].FocusCameraOnUnit_Dogfight(Client.SelectedUnit.ObjectID, ((ActiveUnit)Client.SelectedUnit).AI.PrimaryTarget.ActualUnit.ObjectID);
		}
	}

	public static bool StartInterruptibleMap()
	{
		FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(SimConfiguration.DefaultGamePreferences.TacviewExePath);
		if (versionInfo.FileMajorPart >= 1 && ((versionInfo.FileMinorPart == 8 && versionInfo.FileBuildPart >= 7) || versionInfo.FileMinorPart > 8))
		{
			return true;
		}
		return false;
	}

	public static void AssetInterruptibleMap()
	{
		if (OSVersionInfo.MajorVersion >= 10 && !ExpressionCollectionTask.DestroyInterruptibleSchema(SimConfiguration.DefaultGamePreferences.TacviewExePath))
		{
			DarkMessageBox.ShowError("It appears that the Tacview executable you have specified is invalid. Please use a valid executable. For assistance please contact MatrixGames or Raia Software.", "Invalid Tacview exe!");
			return;
		}
		FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(SimConfiguration.DefaultGamePreferences.TacviewExePath);
		if (versionInfo.FileMajorPart <= 1 && versionInfo.FileMinorPart <= 8 && versionInfo.FileBuildPart < 1)
		{
			DarkMessageBox.ShowError("It appears that you are using an older version of Tacview (" + Conversions.ToString(versionInfo.FileMajorPart) + "." + Conversions.ToString(versionInfo.FileMinorPart) + "." + Conversions.ToString(versionInfo.FileBuildPart) + "). Please download & install at least version 1.8.1. For assistance please contact MatrixGames or Raia Software.", "Out-of-date Tacview version!");
		}
		else if (!_ExceptionExporter.Any())
		{
			TacviewClient.Factory();
		}
	}

	private static void PrintInterruptibleMap(object object_0, ObservableListModified<TacviewClient> observableListModified_0)
	{
		_RecordExporter.PipeClientsPresent = true;
	}

	private static void DefineInterruptibleMap(object object_0, ObservableListModified<TacviewClient> observableListModified_0)
	{
		if (_ExceptionExporter.Count == 0)
		{
			_RecordExporter.PipeClientsPresent = false;
			_RecordExporter.DestroyCache();
		}
		else
		{
			_RecordExporter.PipeClientsPresent = true;
		}
	}
}
