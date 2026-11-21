using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Command.Filters;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.Tacview;

public sealed class TacviewClient
{
	[CompilerGenerated]
	private sealed class ProcessTemplate
	{
		public Tuple<string, IEventExporter.EventExportNotification> tuple_0;

		internal bool ManageInterruptibleMethod(Side theSide)
		{
			return Operators.CompareString(theSide.Name, tuple_0.Item2.EventParameters["ObserverSide"].Value.ToString(), TextCompare: true) == 0;
		}
	}

	public int FormHeight;

	public int FormWidth;

	internal bool utilsExporter;

	public static string TacviewTimeSeparator;

	public string Id;

	private bool m_PredicateExporter;

	private bool singletonExporter;

	public HashSet<string> CacheSentHashset;

	public Thread myDedicatedThread;

	public Process ManagerProcess;

	public ConcurrentQueue<List<Tuple<string, IEventExporter.EventExportNotification>>> EventQueue;

	public string SideID;

	public bool GodsEye;

	public Process TacviewProcess;

	public AnonymousPipeServerStream pipeRead_Telemetry;

	public AnonymousPipeServerStream pipeWrite_Telemetry;

	public AnonymousPipeServerStream pipeRead_Control;

	public AnonymousPipeServerStream pipeWrite_Control;

	public StreamWriter pipeStreamWriter_Telemetry;

	public StreamWriter pipeStreamWriter_Control;

	static TacviewClient()
	{
		TacviewTimeSeparator = ":";
	}

	public static string ACMIHeaderString(Scenario scenario_0)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			string timeSeparator = CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator;
			stringBuilder.Append("FileType=text/acmi/tacview").Append("\r\n");
			stringBuilder.Append("FileVersion=2.2").Append("\r\n");
			if (Operators.CompareString(timeSeparator, TacviewTimeSeparator, TextCompare: true) == 0)
			{
				stringBuilder.Append("0,ReferenceTime=" + scenario_0.ZeroHour.ToString("yyyy-MM-ddThh:mm:ss")).Append("Z").Append("\r\n");
			}
			else
			{
				string text = scenario_0.ZeroHour.ToString("hh:mm:ss");
				text = text.Replace(timeSeparator, TacviewTimeSeparator);
				stringBuilder.Append("0,ReferenceTime=" + scenario_0.ZeroHour.ToString("yyyy-MM-ddT")).Append(text).Append("Z")
					.Append("\r\n");
			}
			return stringBuilder.ToString();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public static void DumpCurrentState(Scenario scenario_0)
	{
		try
		{
			if (Client.CurrentMapProfile.GodsEye)
			{
				foreach (ActiveUnit item in new List<ActiveUnit>(scenario_0.ActiveUnits_List))
				{
					if (!item.IsGroup && item.IsOperating())
					{
						item.Kinematics.ExportLocationEvent(bool_0: true);
					}
				}
				return;
			}
			if (Client.CurrentSide == null)
			{
				return;
			}
			foreach (ActiveUnit item2 in Client.CurrentSide.GetFriendlyUnits_OperativeOnly(Client.CurrentScenario))
			{
				if (!item2.IsGroup && item2.IsOperating())
				{
					item2.Kinematics.ExportLocationEvent(bool_0: true);
				}
			}
			foreach (Contact contacts_ in Client.CurrentSide.Contacts_List)
			{
				ActiveUnit_Sensory.ExportContactLocationEvent(contacts_, Client.CurrentSide, Client.CurrentScenario);
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

	public static void RefreshContactsOfCurrentSide()
	{
		if (Client.CurrentMapProfile.GodsEye || Client.CurrentSide == null)
		{
			return;
		}
		foreach (Contact contacts_ in Client.CurrentSide.Contacts_List)
		{
			ActiveUnit_Sensory.ExportContactLocationEvent(contacts_, Client.CurrentSide, Client.CurrentScenario);
		}
	}

	public void Close()
	{
		try
		{
			TacviewProcess.Kill();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		try
		{
			ManagerProcess.Kill();
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
		try
		{
			pipeWrite_Telemetry.Close();
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			ProjectData.ClearProjectError();
		}
		try
		{
			pipeRead_Telemetry.Close();
		}
		catch (Exception projectError4)
		{
			ProjectData.SetProjectError(projectError4);
			ProjectData.ClearProjectError();
		}
		try
		{
			pipeWrite_Control.Close();
		}
		catch (Exception projectError5)
		{
			ProjectData.SetProjectError(projectError5);
			ProjectData.ClearProjectError();
		}
		try
		{
			pipeRead_Control.Close();
		}
		catch (Exception projectError6)
		{
			ProjectData.SetProjectError(projectError6);
			ProjectData.ClearProjectError();
		}
		ConfigurationRegistryFilter.PublishInterruptibleMap().Remove(this);
	}

	private TacviewClient()
	{
		m_PredicateExporter = false;
		singletonExporter = false;
		CacheSentHashset = new HashSet<string>();
		EventQueue = new ConcurrentQueue<List<Tuple<string, IEventExporter.EventExportNotification>>>();
		pipeRead_Telemetry = new AnonymousPipeServerStream(PipeDirection.In, HandleInheritability.Inheritable);
		pipeWrite_Telemetry = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable, 104857600);
		pipeRead_Control = new AnonymousPipeServerStream(PipeDirection.In, HandleInheritability.Inheritable);
		pipeWrite_Control = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable);
		pipeStreamWriter_Telemetry = new StreamWriter(pipeWrite_Telemetry);
		pipeStreamWriter_Control = new StreamWriter(pipeWrite_Control);
	}

	public void Resize()
	{
		try
		{
			RECT rect_ = default(RECT);
			GetWindowRect(ManagerProcess.MainWindowHandle, ref rect_);
			FormWidth = rect_.Right - rect_.Left + 1;
			FormHeight = rect_.Bottom - rect_.Top + 1;
			pipeStreamWriter_Control.Write("Tacview.UI.SetWindowPosition(0, 0, " + Conversions.ToString(FormWidth) + ", " + Conversions.ToString(FormHeight) + ")\0");
			pipeStreamWriter_Control.Flush();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	[DllImport("user32.dll")]
	private static extern bool GetWindowRect(IntPtr intptr_0, ref RECT rect_0);

	public static TacviewClient Factory()
	{
		Exporter_General.EventExporters_Interactive.Where((IEventExporter theExp) => theExp.ExporterType == IEventExporter.EventExporterType.TacviewPipe).FirstOrDefault().IsOperating = true;
		object attrExporter = ConfigurationRegistryFilter.m_AttrExporter;
		ObjectFlowControl.CheckForSyncLockOnValueType(attrExporter);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(attrExporter, ref lockTaken);
			TacviewClient tacviewClient = new TacviewClient();
			ConfigurationRegistryFilter.PublishInterruptibleMap().Add(tacviewClient);
			tacviewClient.Id = "tvc-" + Guid.NewGuid().ToString().Substring(0, 4);
			if (Client.CurrentScenario.GetCurrentSide() == null)
			{
				tacviewClient.SideID = "";
			}
			else
			{
				tacviewClient.SideID = Client.CurrentScenario.GetCurrentSide().ObjectID;
			}
			tacviewClient.GodsEye = Client.CurrentMapProfile.GodsEye;
			tacviewClient.ManagerProcess = ConfigurationRegistryFilter.VerifyInterruptibleMap("CommandTacviewManager.exe", "", IntPtr.Zero);
			while (tacviewClient.ManagerProcess.MainWindowHandle == IntPtr.Zero)
			{
				Thread.Sleep(10);
			}
			RECT rect_ = default(RECT);
			GetWindowRect(tacviewClient.ManagerProcess.MainWindowHandle, ref rect_);
			tacviewClient.FormWidth = rect_.Right - rect_.Left + 1;
			tacviewClient.FormHeight = rect_.Bottom - rect_.Top + 1;
			string text = Conversions.ToInteger(tacviewClient.pipeWrite_Telemetry.GetClientHandleAsString()).ToString("X");
			string text2 = Conversions.ToInteger(tacviewClient.pipeRead_Telemetry.GetClientHandleAsString()).ToString("X");
			string text3 = Conversions.ToInteger(tacviewClient.pipeWrite_Control.GetClientHandleAsString()).ToString("X");
			string text4 = Conversions.ToInteger(tacviewClient.pipeRead_Control.GetClientHandleAsString()).ToString("X");
			string string_ = "/RealTimeTelemetryPipe:" + text + ":" + text2 + " /LuaPipe:" + text3 + ":" + text4 + " /ReadOnly:true " + (ConfigurationRegistryFilter.StartInterruptibleMap() ? "/MaxFrameRate:30 " : string.Empty) + "/ResourceFolder:\"" + GameGeneral.ResourcesFolderPath + "\\Tacview\\\"";
			tacviewClient.TacviewProcess = ConfigurationRegistryFilter.VerifyInterruptibleMap(SimConfiguration.DefaultGamePreferences.TacviewExePath, string_, tacviewClient.ManagerProcess.MainWindowHandle);
			tacviewClient.pipeRead_Telemetry.DisposeLocalCopyOfClientHandle();
			tacviewClient.pipeWrite_Telemetry.DisposeLocalCopyOfClientHandle();
			tacviewClient.pipeRead_Control.DisposeLocalCopyOfClientHandle();
			tacviewClient.pipeWrite_Control.DisposeLocalCopyOfClientHandle();
			string empty = string.Empty;
			empty += "XtraLib.Stream.0\n";
			empty += "Tacview.RealTimeTelemetry.0\n";
			empty += "CMANO host\n\0";
			tacviewClient.pipeStreamWriter_Telemetry.Write(empty);
			tacviewClient.pipeStreamWriter_Telemetry.Flush();
			string empty2 = string.Empty;
			empty2 += "XtraLib.Stream.0\n";
			empty2 += "Tacview.Lua.0\n";
			empty2 += "CMANO host\n\0";
			tacviewClient.pipeStreamWriter_Control.Write(empty2);
			tacviewClient.pipeStreamWriter_Control.Write("Tacview = require('Tacview180')\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.UI.SetWindowParent(" + Conversions.ToString((int)tacviewClient.ManagerProcess.MainWindowHandle) + ")\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.UI.EnterReadMode(true)\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.Settings.SetBoolean(\"UI.View.Overlay.Visible\", false)\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.Settings.SetBoolean(\"UI.View.Grid.Visible\", false)\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.Settings.SetBoolean(\"UI.View.Objects.Direction.Visible\", false)\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.Settings.SetBoolean(\"UI.View.Objects.Height.Visible\", false)\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.Settings.SetBoolean(\"UI.View.Objects.Labels.Visible\", true)\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.Settings.SetString(\"UI.View.Camera.Mode\", \"External\")\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.Settings.SetString(\"UI.View.Terrain.Mode\", \"Full3D\")\0");
			tacviewClient.pipeStreamWriter_Control.Write("Tacview.UI.SetWindowPosition(0, 0, " + Conversions.ToString(tacviewClient.FormWidth) + ", " + Conversions.ToString(tacviewClient.FormHeight) + ")\0");
			tacviewClient.pipeStreamWriter_Control.Flush();
			tacviewClient.myDedicatedThread = new Thread(tacviewClient.StartDedicatedExportThread);
			tacviewClient.myDedicatedThread.Name = tacviewClient.Id + " Thread";
			tacviewClient.myDedicatedThread.Priority = ThreadPriority.Normal;
			tacviewClient.myDedicatedThread.Start();
			tacviewClient.DisableInterruptibleMap(ACMIHeaderString(Client.CurrentScenario));
			DumpCurrentState(Client.CurrentScenario);
			return null;
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(attrExporter);
			}
		}
	}

	private void DisableInterruptibleMap(string string_0)
	{
		try
		{
			if (pipeWrite_Telemetry.IsConnected)
			{
				pipeStreamWriter_Telemetry.Write(string_0 + "\r\n");
				pipeStreamWriter_Telemetry.Flush();
			}
			else if (!m_PredicateExporter)
			{
				DarkMessageBox.ShowError("Tacview has disconnected from Command.", "Tacview disconnected");
				m_PredicateExporter = true;
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

	private void UpdateInterruptibleMap(string string_0)
	{
		try
		{
			if (pipeWrite_Control.IsConnected)
			{
				pipeStreamWriter_Control.Write(string_0 + "\0");
				pipeStreamWriter_Control.Flush();
			}
			else if (!m_PredicateExporter)
			{
				DarkMessageBox.ShowError("Tacview has disconnected from Command.", "Tacview disconnected");
				m_PredicateExporter = true;
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

	public void StartDedicatedExportThread()
	{
		int num = 1;
		while (true)
		{
			num++;
			InsertInterruptibleMap();
			Thread.Sleep(50);
			if (num % 20 == 0)
			{
				num = 1;
				try
				{
					Resize();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				if (ManagerProcess.HasExited)
				{
					break;
				}
			}
		}
		Close();
	}

	private void InsertInterruptibleMap()
	{
		try
		{
			List<Tuple<string, IEventExporter.EventExportNotification>> result = new List<Tuple<string, IEventExporter.EventExportNotification>>(EventQueue.Count * 2);
			while (EventQueue.Count > 0)
			{
				EventQueue.TryDequeue(out result);
				foreach (Tuple<string, IEventExporter.EventExportNotification> item in result)
				{
					PrepareInterruptibleMap(item);
					try
					{
						if (item.Item2.EventType != IEventExporter.ExportedEventType.UnitDestroyed)
						{
							continue;
						}
						if (ConfigurationRegistryFilter._VisitorExporter == null)
						{
							ConfigurationRegistryFilter._VisitorExporter = new Dictionary<string, float>();
						}
						if (ConfigurationRegistryFilter._VisitorExporter.ContainsKey(item.Item1))
						{
							if (ConfigurationRegistryFilter._VisitorExporter[item.Item1] < ConfigurationRegistryFilter.exporterExporter)
							{
								ConfigurationRegistryFilter._VisitorExporter[item.Item1] += 1f;
								List<Tuple<string, IEventExporter.EventExportNotification>> list = new List<Tuple<string, IEventExporter.EventExportNotification>>();
								list.Add(item);
								EventQueue.Enqueue(list);
							}
							else
							{
								ConfigurationRegistryFilter._VisitorExporter.Remove(item.Item1);
							}
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
			}
			if (!singletonExporter && Client.SelectedUnit != null)
			{
				FocusCameraOnUnit(Client.SelectedUnit.ObjectID);
				singletonExporter = true;
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void FocusCameraOnUnit(string string_0, int int_0 = 0)
	{
		try
		{
			if (ConfigurationRegistryFilter._RecordExporter.DeclaredUnits.Count != 0 && ConfigurationRegistryFilter._RecordExporter.DeclaredUnits.TryGetValue(string_0, out var value))
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("local objectHandle = Tacview.Telemetry.GetCurrentObjectHandle(0x").Append(value).Append(")")
					.Append("\r\n");
				stringBuilder.Append("Tacview.Context.SetSelectedObject(0, objectHandle)").Append("\r\n");
				stringBuilder.Append("Tacview.Settings.SetString(\"UI.View.Camera.Mode\", \"External\")").Append("\r\n");
				if (int_0 != 0)
				{
					stringBuilder.Append("Tacview.Context.Camera.SetRangeToTarget( ").Append(int_0).Append(" )")
						.Append("\r\n");
				}
				string string_ = stringBuilder.ToString();
				UpdateInterruptibleMap(string_);
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

	public void FocusCameraOnUnit_Dogfight(string string_0, string string_1)
	{
		try
		{
			if (ConfigurationRegistryFilter._RecordExporter.DeclaredUnits.Count != 0 && ConfigurationRegistryFilter._RecordExporter.DeclaredUnits.TryGetValue(string_0, out var value) && ConfigurationRegistryFilter._RecordExporter.DeclaredUnits.TryGetValue(string_1, out var value2))
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("local objectHandle = Tacview.Telemetry.GetCurrentObjectHandle(0x").Append(value).Append(")")
					.Append("\r\n");
				stringBuilder.Append("Tacview.Context.SetSelectedObject(0, objectHandle)").Append("\r\n");
				stringBuilder.Append("local objectHandle = Tacview.Telemetry.GetCurrentObjectHandle(0x").Append(value2).Append(")")
					.Append("\r\n");
				stringBuilder.Append("Tacview.Context.SetSelectedObject(1, objectHandle)").Append("\r\n");
				stringBuilder.Append("Tacview.Settings.SetString(\"UI.View.Camera.Mode\", \"External\")").Append("\r\n");
				stringBuilder.Append("Tacview.Settings.SetString(\"UI.View.Camera.Dogfight.Mode\", \"LookAt\")").Append("\r\n");
				stringBuilder.Append("Tacview.Settings.SetBoolean(\"UI.View.Camera.Dogfight.Enabled\", true)").Append("\r\n");
				stringBuilder.Append("local roll = 10").Append("\r\n");
				stringBuilder.Append("local pitch = 10").Append("\r\n");
				stringBuilder.Append("local yaw = 45").Append("\r\n");
				stringBuilder.Append("Tacview.Context.Camera.SetRotation( math.rad(roll) , math.rad(pitch) , math.rad(yaw) )").Append("\r\n");
				string string_2 = stringBuilder.ToString();
				UpdateInterruptibleMap(string_2);
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

	private void PrepareInterruptibleMap(Tuple<string, IEventExporter.EventExportNotification> tuple_0)
	{
		try
		{
			string text = null;
			switch (tuple_0.Item2.EventType)
			{
			case IEventExporter.ExportedEventType.WeaponFired:
				text = Conversions.ToString(tuple_0.Item2.EventParameters["WeaponID"].Value);
				break;
			case IEventExporter.ExportedEventType.WeaponEndgame:
				text = Conversions.ToString(tuple_0.Item2.EventParameters["WeaponID"].Value);
				break;
			case IEventExporter.ExportedEventType.UnitDestroyed:
				text = Conversions.ToString(tuple_0.Item2.EventParameters["UnitID"].Value);
				break;
			case IEventExporter.ExportedEventType.UnitPositions:
				text = Conversions.ToString(tuple_0.Item2.EventParameters["UnitID"].Value);
				if (!Client.CurrentMapProfile.GodsEye && Client.CurrentSide != null)
				{
					List<ActiveUnit> list = Client.CurrentSide.GetFriendlyUnits_OperativeOnly(Client.CurrentScenario).ToList();
					ActiveUnit item = Client.CurrentScenario.ActiveUnits[text];
					if (!list.Contains(item))
					{
						return;
					}
				}
				break;
			case IEventExporter.ExportedEventType.WeaponImpact:
				text = Conversions.ToString(tuple_0.Item2.EventParameters["UnitID"].Value);
				break;
			case IEventExporter.ExportedEventType.Explosion:
				text = Conversions.ToString(tuple_0.Item2.EventParameters["ExplosionID"].Value);
				break;
			case IEventExporter.ExportedEventType.AirOps:
				text = Conversions.ToString(tuple_0.Item2.EventParameters["UnitID"].Value);
				break;
			case IEventExporter.ExportedEventType.DockingOps:
				text = Conversions.ToString(tuple_0.Item2.EventParameters["UnitID"].Value);
				break;
			case IEventExporter.ExportedEventType.WaterSplash:
				text = Conversions.ToString(tuple_0.Item2.EventParameters["UnitID"].Value);
				break;
			case IEventExporter.ExportedEventType.ContactPositions:
			{
				Side side = null;
				side = Client.CurrentScenario.Sides_ReadOnly.Where((Side theSide) => Operators.CompareString(theSide.Name, tuple_0.Item2.EventParameters["ObserverSide"].Value.ToString(), TextCompare: true) == 0).FirstOrDefault();
				if (side == null)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return;
				}
				if (side == Client.CurrentSide)
				{
					text = Conversions.ToString(tuple_0.Item2.EventParameters["ContactID"].Value);
					break;
				}
				return;
			}
			}
			if (!CacheSentHashset.Contains(text))
			{
				CacheSentHashset.Add(text);
				if (ConfigurationRegistryFilter._RecordExporter.NewUnitCache.ContainsKey(text))
				{
					DisableInterruptibleMap(ConfigurationRegistryFilter._RecordExporter.NewUnitCache[text]);
				}
			}
			DisableInterruptibleMap(tuple_0.Item1);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			DisableInterruptibleMap(tuple_0.Item1);
			ProjectData.ClearProjectError();
		}
	}

	public override string ToString()
	{
		return Id;
	}
}
