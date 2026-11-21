using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace Command;

[DesignerGenerated]
public sealed class MainSplash : Form
{
	private IContainer serviceConnection;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private Label m_CandidateConnection;

	[field: AccessedThroughProperty("PictureBox1")]
	internal PictureBox PictureBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal Label Label1
	{
		[CompilerGenerated]
		get
		{
			return m_CandidateConnection;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CandidateConnection = value;
		}
	}

	public MainSplash()
	{
		base.Shown += VerifyInterruptibleConfig;
		CancelInterruptibleConfig();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && serviceConnection != null)
			{
				serviceConnection.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CancelInterruptibleConfig()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(MainSplash));
		PictureBox1 = new PictureBox();
		Label1 = new Label();
		((ISupportInitialize)PictureBox1).BeginInit();
		SuspendLayout();
		PictureBox1.Dock = DockStyle.Fill;
		PictureBox1.Image = componentResourceManager.GetObject("PictureBox1.Image");
		PictureBox1.Location = new Point(0, 0);
		PictureBox1.Name = "PictureBox1";
		PictureBox1.Size = new Size(483, 292);
		PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
		PictureBox1.TabIndex = 6;
		PictureBox1.TabStop = false;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.Red;
		Label1.Location = new Point(12, 9);
		Label1.Name = "Label1";
		Label1.Size = new Size(10, 13);
		Label1.TabIndex = 7;
		Label1.Text = " ";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(483, 292);
		base.ControlBox = false;
		base.Controls.Add(Label1);
		base.Controls.Add(PictureBox1);
		base.FormBorderStyle = FormBorderStyle.None;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "MainSplash";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "指挥 - 现代海空行动";
		((ISupportInitialize)PictureBox1).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void VerifyInterruptibleConfig(object sender, EventArgs e)
	{
		base.Visible = false;
		try
		{
			GameGeneral.WriteLogDebugInfoToFile("Discovering DPI");
			if (Client._StateClass == 0f)
			{
				GameGeneral.WriteLogDebugInfoToFile("DPI_scale = 0");
				InterpreterObjectListener.CountInterruptibleFilter(this);
			}
			if (Client._StateClass == 1f)
			{
				base.AutoScaleMode = AutoScaleMode.None;
			}
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				GameGeneral.WriteLogDebugInfoToFile("显示启动画面。");
			}
			Application.DoEvents();
			if (Client._StateClass > 1f)
			{
				GameGeneral.WriteLogDebugInfoToFile("AdjustForHighDPI");
				AdjustForHighDPI();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			GameGeneral.WriteLogDebugInfoToFile("EXCEPTION during DPI");
			ProjectData.ClearProjectError();
		}
		Label1.Visible = false;
		try
		{
			GameGeneral.WriteLogDebugInfoToFile("Loading splash image");
			PictureBox1.Image = Image.FromFile(Path.Combine(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath, "Symbols\\splash.jpg"));
			InterpreterObjectListener.exporterResolver = (Bitmap)PictureBox1.Image;
			GameGeneral.WriteLogDebugInfoToFile("Splash image loaded");
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			GameGeneral.WriteLogDebugInfoToFile("EXCEPTION on SPLASH loading");
			ProjectData.ClearProjectError();
		}
		try
		{
			GameGeneral.WriteLogDebugInfoToFile("Client.Initalize");
			Client.Initialize();
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			GameGeneral.WriteLogDebugInfoToFile("Client.Initalize FAILED");
			ProjectData.ClearProjectError();
		}
		Application.DoEvents();
		Client.CurrentUserAction = Client.UserAction.None;
		if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
		{
			GameGeneral.WriteLogDebugInfoToFile("等待地形加载。");
		}
		while (!Terrain.TerrainHasLoaded)
		{
			Thread.Sleep(100);
		}
		if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
		{
			GameGeneral.WriteLogDebugInfoToFile("地形加载完毕。");
		}
		Application.DoEvents();
	}

	public void AdjustForHighDPI()
	{
		string text = Path.Combine(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath, Process.GetCurrentProcess().ProcessName + ".exe");
		if (!FileExistsNative.FileExistsFast(text))
		{
			DarkMessageBox.ShowError("File Command.exe not found on this folder. Please run this tool inside the same folder that Command.exe is located. Press any key to exit.", "File not found");
			Environment.Exit(0);
		}
		if (!ListInterruptibleConfig(Registry.CurrentUser, "Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers"))
		{
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers");
		}
		string text2 = Conversions.ToString(ItemExporter.RegisterInterruptibleMap.Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers", text, string.Empty));
		if (text2.Contains("~ DPIUNAWARE"))
		{
			return;
		}
		bool flag = false;
		try
		{
			ItemExporter.RegisterInterruptibleMap.Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers", text, text2 + " ~ DPIUNAWARE");
			text2 = Conversions.ToString(ItemExporter.RegisterInterruptibleMap.Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers", text, string.Empty));
			flag = text2.Contains("~ DPIUNAWARE");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			flag = false;
			ProjectData.ClearProjectError();
		}
		if (flag)
		{
			string path = Path.Combine(GameGeneral.TempPath, "instance");
			if (Directory.Exists(path))
			{
				Directory.Delete(path, recursive: true);
			}
			try
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo(text);
				processStartInfo.CreateNoWindow = false;
				processStartInfo.UseShellExecute = false;
				Process process = new Process();
				process.StartInfo = processStartInfo;
				process.Start();
				Environment.Exit(0);
				return;
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
				return;
			}
		}
		MessageBox.Show("CAUTION! Your system appears to be using a high-DPI desktop setting (e.g. an ultra-high resolution monitor). This program needs an extra configuration step in order to run without issues in such a setting.\r\n\r\nClick on the 'Help' button to navigate to our dedicated instructions for this.\r\n\r\nWe apologize for the inconvenience!", "High-DPI settings detected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, "http://www.matrixgames.com/forums/tm.asp?m=4190908", "keyword");
	}

	private bool ListInterruptibleConfig(RegistryKey registryKey_0, string string_0)
	{
		return registryKey_0.OpenSubKey(string_0) != null;
	}
}
