using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using Command;
using Command.Bridges;
using Command.Filters;
using Command.Messages;
using Command.Tacview;
using Command_Core;
using DarkUI.Forms;
using Magic.Samples.DisplaySettings;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;

namespace OpenDis.Candidates;

[EditorBrowsable(EditorBrowsableState.Never)]
[GeneratedCode("MyTemplate", "11.0.0.0")]
internal class AdapterCallbackCandidate : WindowsFormsApplicationBase
{
	[Flags]
	public enum EXECUTION_STATE : uint
	{
		ES_AWAYMODE_REQUIRED = 0x40u,
		ES_CONTINUOUS = 0x80000000u,
		ES_DISPLAY_REQUIRED = 2u,
		ES_SYSTEM_REQUIRED = 1u
	}

	[CompilerGenerated]
	private sealed class ThreadTemplate
	{
		public TacviewClient Local_tvc;

		internal void RevertInterruptibleMethod()
		{
			Local_tvc.Close();
		}
	}

	public static CultureInfo prototypeExporter;

	[SpecialName]
	protected static bool ForgotInterruptibleMap()
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.NoOptimization)]
	[STAThread]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static void Main(string[] args)
	{
		global::Command.Localization.InitializeFromConfig();
		global::Command.Localization.HookOpenForms();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		ItemExporter.RevertInterruptibleMap.Run(args);
	}

	private void ResetInterruptibleMap(object sender, NetworkAvailableEventArgs e)
	{
	}

	private void MapInterruptibleMap(object sender, EventArgs e)
	{
		SortInterruptibleMap();
	}

	public void SortInterruptibleMap()
	{
		Client.ShutdownCleanup();
		SimConfiguration.SaveSettings(WindowPlacement.WindowPlacementSettings, Client.RecentFilenames);
		Terrain.CleanUp();
		CommandSteam.CloseSteamConnection();
		if (RecordThreadBridge.InvokeInterruptibleConnection())
		{
			RecordThreadBridge.PushInterruptibleConnection();
		}
		if (Client.systemClass.Height > 0)
		{
			DisplayManager.SetDisplaySettings(Client.systemClass);
		}
		if (Directory.Exists(GameGeneral.TempPath))
		{
			try
			{
				Misc.DeleteEverythingInDirectory(GameGeneral.TempPath);
				Directory.Delete(GameGeneral.TempPath);
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
		if (ConfigurationRegistryFilter.PublishInterruptibleMap().Count > 0)
		{
			foreach (TacviewClient item in ConfigurationRegistryFilter.PublishInterruptibleMap().ToList())
			{
				TacviewClient Local_tvc = item;
				try
				{
					Task.Factory.StartNew(delegate
					{
						Local_tvc.Close();
					});
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
			}
			Thread.Sleep(1000);
		}
		SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
		Environment.Exit(0);
	}

	[DllImport("kernel32.dll")]
	private static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE execution_STATE_0);

	private void RateInterruptibleMap(object sender, StartupEventArgs e)
	{
		SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_SYSTEM_REQUIRED);
		SystemEvents.PowerModeChanged += FlushInterruptibleMap;
		try
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\WOW6432Node\\Matrix Games\\CMO2");
			if (registryKey != null)
			{
				GameGeneral.TopLevelWritablePath = Conversions.ToString(registryKey.GetValue("TopLevelWritablePath"));
				registryKey.Close();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		try
		{
			if (FileExistsNative.FileExistsFast(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "\\WritableRoot.txt"))
			{
				string text = File.ReadAllText(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "\\WritableRoot.txt");
				if (Directory.Exists(text))
				{
					GameGeneral.TopLevelWritablePath = text;
				}
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
		if (!Directory.Exists(Path.Combine(GameGeneral.GISFolderPath, "LandCover")))
		{
			DarkMessageBox.ShowError("地形地貌数据文件未找到！请检查GIS/LandCover目录，程序将退出...", "1328.18 - Error");
			Environment.Exit(0);
		}
		GameGeneral.WriteLogDebugInfoToFile("\r\n--------------- Starting new GUI-client session - " + DateTime.Now.ToString() + " Build 1328.18 -----------------");
		try
		{
			prototypeExporter = Thread.CurrentThread.CurrentCulture;
			try
			{
				string text2 = Environment.NewLine + "User's machine " + Environment.NewLine;
				text2 = text2 + "Machine's name : " + Environment.MachineName + Environment.NewLine;
				text2 = text2 + "Thread's culture : " + prototypeExporter.Name + Environment.NewLine;
				text2 = text2 + "Installed culture : " + ItemExporter.RegisterInterruptibleMap.Info.InstalledUICulture.Name + Environment.NewLine;
				text2 = text2 + "Available virtual memory : " + ((double)ItemExporter.RegisterInterruptibleMap.Info.AvailableVirtualMemory / 1000000.0).ToString("#.#") + "Mo" + Environment.NewLine;
				text2 = text2 + "Available RAM : " + ((double)ItemExporter.RegisterInterruptibleMap.Info.AvailablePhysicalMemory / 1000000.0).ToString("#.#") + "Mo" + Environment.NewLine;
				text2 = text2 + "Total virtual memory : " + ((double)ItemExporter.RegisterInterruptibleMap.Info.TotalVirtualMemory / 1000000.0).ToString("#.#") + "Mo" + Environment.NewLine;
				text2 = text2 + "Total RAM : " + ((double)ItemExporter.RegisterInterruptibleMap.Info.TotalPhysicalMemory / 1000000.0).ToString("#.#") + "Mo" + Environment.NewLine;
				text2 = text2 + "OS name : " + ItemExporter.RegisterInterruptibleMap.Info.OSFullName + Environment.NewLine;
				text2 = text2 + "OS platform : " + ItemExporter.RegisterInterruptibleMap.Info.OSPlatform + Environment.NewLine;
				text2 = text2 + "OS version : " + ItemExporter.RegisterInterruptibleMap.Info.OSVersion + Environment.NewLine;
				text2 = (new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) ? (text2 + ">>Running as administrator. <<" + Environment.NewLine) : (text2 + ">>Not running as administrator ! <<" + Environment.NewLine));
				GameGeneral.WriteLogDebugInfoToFile(text2);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200575UMI", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			Client.MainThreadDispatcher = Dispatcher.CurrentDispatcher;
			ItemExporter.RevertInterruptibleMap.DoEvents();
			StartGameMenuWindow.ShowStartWindow();
			ItemExporter.RevertInterruptibleMap.DoEvents();
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			ProjectData.ClearProjectError();
		}
		try
		{
			try
			{
				if (!Directory.Exists(GameGeneral.ConfigFolderPath))
				{
					Directory.CreateDirectory(GameGeneral.ConfigFolderPath);
				}
			}
			catch (Exception ex12)
			{
				ProjectData.SetProjectError(ex12);
				Exception ex23 = ex12;
				DarkMessageBox.ShowError("Error found during alpha1 application startup. Error details: " + ex23.Message, "1328.18 - Error in Application_Startup!");
				throw;
			}
			try
			{
				Client.RunningInSteamMode = ItemExporter.RevertInterruptibleMap.Info.DirectoryPath.Contains("steamapps\\common");
				if (FileExistsNative.FileExistsFast(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "\\force_steam"))
				{
					Client.RunningInSteamMode = true;
				}
			}
			catch (Exception ex28)
			{
				ProjectData.SetProjectError(ex28);
				Exception ex29 = ex28;
				DarkMessageBox.ShowError("Error found during alpha3 application startup. Error details: " + ex29.Message, "1328.18 - Error in Application_Startup!");
				throw;
			}
			try
			{
				if (Client.RunningInSteamMode)
				{
					CommandSteam.OpenSteamConnection();
					if (!CommandSteam.steamOnline)
					{
						DarkMessageBox.ShowError("您似乎在Steam模式下运行Command，但Steam客户端似乎没有运行。在启动Command之前，请确保Steam客户端正在运行。推演现在将退出。", "1328.18 - Steam client Not running!");
						SortInterruptibleMap();
					}
				}
			}
			catch (Exception ex30)
			{
				ProjectData.SetProjectError(ex30);
				Exception ex31 = ex30;
				DarkMessageBox.ShowError("Error found during alpha4 application startup. Error details:  " + ex31.Message, "1328.18 - Error in Application_Startup!");
				throw;
			}
			try
			{
				if (Directory.Exists(GameGeneral.TempPath))
				{
					try
					{
						Misc.DeleteEverythingInDirectory(GameGeneral.TempPath);
						Directory.Delete(GameGeneral.TempPath);
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
			catch (Exception ex32)
			{
				ProjectData.SetProjectError(ex32);
				Exception ex33 = ex32;
				DarkMessageBox.ShowError("Error found during alpha5 application startup. Error details: " + ex33.Message, "1328.18 - Error in Application_Startup!");
				throw;
			}
			try
			{
				if (!Directory.Exists(GameGeneral.TempPath))
				{
					Directory.CreateDirectory(GameGeneral.TempPath);
				}
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex3 = ex2;
				DarkMessageBox.ShowError("Error found during alpha6 application startup. Error details: " + ex3.Message, "1328.18 - Error in Application_Startup!");
				throw;
			}
			try
			{
				Process.GetCurrentProcess().PriorityBoostEnabled = true;
				Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
			}
			catch (Exception ex4)
			{
				ProjectData.SetProjectError(ex4);
				Exception exception_2 = ex4;
				exception_2?.Data.Add("Error at 200358", exception_2.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.AboveNormal;
				ProjectData.ClearProjectError();
			}
			try
			{
				Client.ConsolidateConfigFiles();
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				DarkMessageBox.ShowError("Error found during beta7 application startup. Error details: " + ex6.Message, "1328.18 - Error in Application_Startup!");
				throw;
			}
			try
			{
				if (SimConfiguration.DefaultGamePreferences == null)
				{
					SimConfiguration.LoadSettings(ref WindowPlacement.WindowPlacementSettings, ref Client.RecentFilenames);
					if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
					{
						GameGeneral.WriteLogDebugInfoToFile("成功加载了Sim Configuration。");
					}
				}
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception ex8 = ex7;
				DarkMessageBox.ShowError("Error found during beta-1 application startup. Error details: " + ex8.Message, "1328.18 - Error in Application_Startup!");
				SimConfiguration.CreateDefaultSettings();
				Dictionary<string, Tuple<int, int, int, int>> dictionary_ = null;
				SimConfiguration.LoadSettings(ref dictionary_, ref Client.RecentFilenames);
				ProjectData.ClearProjectError();
			}
			try
			{
				Process[] processes = Process.GetProcesses();
				string processName = Process.GetCurrentProcess().ProcessName;
				DateTime startTime = Process.GetCurrentProcess().StartTime;
				Process[] array = processes;
				Process[] array2 = array;
				foreach (Process process in array2)
				{
					if (Operators.CompareString(process.ProcessName, processName, TextCompare: true) == 0)
					{
						DateTime.Compare(process.StartTime, startTime);
					}
				}
			}
			catch (Exception ex9)
			{
				ProjectData.SetProjectError(ex9);
				Exception ex10 = ex9;
				if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
				{
					GameGeneral.WriteLogDebugInfoToFile("Error found during beta4 application startup. Error details: " + ex10.Message);
				}
				ProjectData.ClearProjectError();
			}
			try
			{
				StartGameMenuWindow.UpdateStartWindow();
			}
			catch (Exception projectError5)
			{
				ProjectData.SetProjectError(projectError5);
				ProjectData.ClearProjectError();
			}
			try
			{
				if (Screen.PrimaryScreen.BitsPerPixel != 32)
				{
					DarkMessageBox.ShowError("请将屏幕的颜色深度设置为32位，然后重新启动Command。", "1328.18 - Error");
					SortInterruptibleMap();
				}
			}
			catch (Exception ex11)
			{
				ProjectData.SetProjectError(ex11);
				Exception ex13 = ex11;
				DarkMessageBox.ShowError("Error found during beta6 application startup. Error details: " + ex13.Message, "1328.18 - Error in Application_Startup!");
				throw;
			}
			try
			{
				if (SimConfiguration.DefaultGamePreferences == null)
				{
					SimConfiguration.LoadSettings(ref WindowPlacement.WindowPlacementSettings, ref Client.RecentFilenames);
					if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
					{
						GameGeneral.WriteLogDebugInfoToFile("成功加载了Sim Configuration。");
					}
				}
			}
			catch (Exception ex14)
			{
				ProjectData.SetProjectError(ex14);
				Exception ex15 = ex14;
				DarkMessageBox.ShowError("Error found during gamma1 application startup. Error details: " + ex15.Message, "1328.18 - Error in Application_Startup!");
				throw;
			}
			if (GameGeneral.bool_0)
			{
				if (FileExistsNative.FileExistsFast(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "\\Multiplayer\\Player.bin"))
				{
					try
					{
						File.Delete(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "\\Multiplayer\\Player.bin");
					}
					catch (Exception ex16)
					{
						ProjectData.SetProjectError(ex16);
						Exception ex17 = ex16;
						DarkMessageBox.ShowError("Unable to delete file \\Multiplayer\\Player.bin. Error details: " + ex17.Message, "Application_Startup出错！");
						ProjectData.ClearProjectError();
					}
				}
				if (FileExistsNative.FileExistsFast(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "\\Multiplayer\\Multiplayer.bin"))
				{
					try
					{
						File.Delete(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "\\Multiplayer\\Multiplayer.bin");
					}
					catch (Exception ex18)
					{
						ProjectData.SetProjectError(ex18);
						Exception ex19 = ex18;
						DarkMessageBox.ShowError("Unable to delete file \\Multiplayer\\Multiplayer.bin. Error details: " + ex19.Message, "Application_Startup出错！");
						ProjectData.ClearProjectError();
					}
				}
			}
			try
			{
				CustomExceptionHandler targetObject = new CustomExceptionHandler();
				ItemExporter.RevertInterruptibleMap.UnhandledException += targetObject.OnThreadException;
			}
			catch (Exception ex20)
			{
				ProjectData.SetProjectError(ex20);
				Exception ex21 = ex20;
				DarkMessageBox.ShowError("Error found during gamma3 application startup. Error details: " + ex21.Message, "1328.18 - Error in Application_Startup!");
				throw;
			}
			try
			{
				ItemExporter.ConnectInterruptibleTemplate.MainSplash.Show();
			}
			catch (Exception ex22)
			{
				ProjectData.SetProjectError(ex22);
				Exception ex24 = ex22;
				DarkMessageBox.ShowError("Error found during gamma4 application startup. Error details: " + ex24.Message, "1328.18 - Error in Application_Startup!");
				throw;
			}
			try
			{
				Task.Run(delegate
				{
					ItemExporter.RevertInterruptibleMap.DoEvents();
				});
			}
			catch (Exception ex25)
			{
				ProjectData.SetProjectError(ex25);
				Exception ex26 = ex25;
				DarkMessageBox.ShowError("Error found during gamma5 application startup. Error details: " + ex26.Message, "1328.18 - Error in Application_Startup!");
				throw;
			}
		}
		catch (Exception ex27)
		{
			ProjectData.SetProjectError(ex27);
			Exception exception_3 = ex27;
			exception_3?.Data.Add("Error at 200575", exception_3.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			DarkMessageBox.ShowError("应用程序启动时发现错误。错误详情：" + exception_3.Message, "1328.18 - Error in Application_Startup!");
			ProjectData.ClearProjectError();
		}
	}

	private void FlushInterruptibleMap(object sender, PowerModeChangedEventArgs e)
	{
		if (e.Mode == PowerModes.Suspend)
		{
			base.MainForm.WindowState = FormWindowState.Minimized;
		}
	}

	[DebuggerStepThrough]
	public AdapterCallbackCandidate()
		: base(AuthenticationMode.Windows)
	{
		base.NetworkAvailabilityChanged += ResetInterruptibleMap;
		base.Shutdown += MapInterruptibleMap;
		base.Startup += RateInterruptibleMap;
		base.IsSingleInstance = false;
		base.EnableVisualStyles = true;
		base.SaveMySettingsOnExit = true;
		base.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
	}

	[DebuggerStepThrough]
	protected override void OnCreateMainForm()
	{
		base.MainForm = ItemExporter.ConnectInterruptibleTemplate.MainForm;
	}
}
