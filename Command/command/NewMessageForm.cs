using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class NewMessageForm : DarkSecondaryFormBase
{
	private IContainer m_RequestPublisher;

	[AccessedThroughProperty("ToolStripButton1")]
	[CompilerGenerated]
	private ToolStripButton _TokenizerPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripButton2")]
	private ToolStripButton _StubPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("PopupOptions")]
	private ToolStripButton m_WriterPublisher;

	[AccessedThroughProperty("TSB_PrevMessage")]
	[CompilerGenerated]
	private ToolStripButton _SpecificationPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_NextMessage")]
	private ToolStripButton _WatcherPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("WebBrowser1")]
	private WebBrowser reponsePublisher;

	[AccessedThroughProperty("ToolStripButton4")]
	[CompilerGenerated]
	private ToolStripButton _DescriptorPublisher;

	[AccessedThroughProperty("Messages")]
	[CompilerGenerated]
	private ObservableCollection<LoggedMessage> m_PoolPublisher;

	private LoggedMessage taskPublisher;

	[field: AccessedThroughProperty("ToolStrip1")]
	internal DarkToolStrip ToolStrip1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripButton ToolStripButton1
	{
		[CompilerGenerated]
		get
		{
			return _TokenizerPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CustomizeInterruptibleInterpreter;
			ToolStripButton tokenizerPublisher = _TokenizerPublisher;
			if (tokenizerPublisher != null)
			{
				tokenizerPublisher.Click -= value2;
			}
			_TokenizerPublisher = value;
			tokenizerPublisher = _TokenizerPublisher;
			if (tokenizerPublisher != null)
			{
				tokenizerPublisher.Click += value2;
			}
		}
	}

	internal ToolStripButton ToolStripButton2
	{
		[CompilerGenerated]
		get
		{
			return _StubPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CloneInterruptibleInterpreter;
			ToolStripButton stubPublisher = _StubPublisher;
			if (stubPublisher != null)
			{
				stubPublisher.Click -= value2;
			}
			_StubPublisher = value;
			stubPublisher = _StubPublisher;
			if (stubPublisher != null)
			{
				stubPublisher.Click += value2;
			}
		}
	}

	internal ToolStripButton PopupOptions
	{
		[CompilerGenerated]
		get
		{
			return m_WriterPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConnectInterruptibleInterpreter;
			ToolStripButton writerPublisher = m_WriterPublisher;
			if (writerPublisher != null)
			{
				writerPublisher.Click -= value2;
			}
			m_WriterPublisher = value;
			writerPublisher = m_WriterPublisher;
			if (writerPublisher != null)
			{
				writerPublisher.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_PrevMessage
	{
		[CompilerGenerated]
		get
		{
			return _SpecificationPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AddInterruptibleInterpreter;
			ToolStripButton specificationPublisher = _SpecificationPublisher;
			if (specificationPublisher != null)
			{
				specificationPublisher.Click -= value2;
			}
			_SpecificationPublisher = value;
			specificationPublisher = _SpecificationPublisher;
			if (specificationPublisher != null)
			{
				specificationPublisher.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_NextMessage
	{
		[CompilerGenerated]
		get
		{
			return _WatcherPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyInterruptibleInterpreter;
			ToolStripButton watcherPublisher = _WatcherPublisher;
			if (watcherPublisher != null)
			{
				watcherPublisher.Click -= value2;
			}
			_WatcherPublisher = value;
			watcherPublisher = _WatcherPublisher;
			if (watcherPublisher != null)
			{
				watcherPublisher.Click += value2;
			}
		}
	}

	internal WebBrowser WebBrowser1
	{
		[CompilerGenerated]
		get
		{
			return reponsePublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PreviewKeyDownEventHandler value2 = PatchInterruptibleInterpreter;
			WebBrowser webBrowser = reponsePublisher;
			if (webBrowser != null)
			{
				webBrowser.PreviewKeyDown -= value2;
			}
			reponsePublisher = value;
			webBrowser = reponsePublisher;
			if (webBrowser != null)
			{
				webBrowser.PreviewKeyDown += value2;
			}
		}
	}

	internal ToolStripButton ToolStripButton4
	{
		[CompilerGenerated]
		get
		{
			return _DescriptorPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MoveInterruptibleInterpreter;
			ToolStripButton descriptorPublisher = _DescriptorPublisher;
			if (descriptorPublisher != null)
			{
				descriptorPublisher.Click -= value2;
			}
			_DescriptorPublisher = value;
			descriptorPublisher = _DescriptorPublisher;
			if (descriptorPublisher != null)
			{
				descriptorPublisher.Click += value2;
			}
		}
	}

	public ObservableCollection<LoggedMessage> Messages
	{
		[CompilerGenerated]
		get
		{
			return m_PoolPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NotifyCollectionChangedEventHandler value2 = DeleteInterruptibleInterpreter;
			ObservableCollection<LoggedMessage> poolPublisher = m_PoolPublisher;
			if (poolPublisher != null)
			{
				poolPublisher.CollectionChanged -= value2;
			}
			m_PoolPublisher = value;
			poolPublisher = m_PoolPublisher;
			if (poolPublisher != null)
			{
				poolPublisher.CollectionChanged += value2;
			}
		}
	}

	public NewMessageForm()
	{
		base.FormClosing += RegisterInterruptibleTests;
		base.Load += ManageInterruptibleTests;
		base.KeyDown += ComputeInterruptibleInterpreter;
		Messages = new ObservableCollection<LoggedMessage>();
		OrderInterruptibleTests();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_RequestPublisher != null)
			{
				m_RequestPublisher.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void OrderInterruptibleTests()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(NewMessageForm));
		ToolStrip1 = new DarkToolStrip();
		TSB_PrevMessage = new ToolStripButton();
		TSB_NextMessage = new ToolStripButton();
		ToolStripButton1 = new ToolStripButton();
		ToolStripButton2 = new ToolStripButton();
		PopupOptions = new ToolStripButton();
		WebBrowser1 = new WebBrowser();
		ToolStripButton4 = new ToolStripButton();
		ToolStrip1.SuspendLayout();
		SuspendLayout();
		ToolStrip1.AutoSize = false;
		ToolStrip1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStrip1.Dock = DockStyle.Bottom;
		ToolStrip1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStrip1.GripStyle = ToolStripGripStyle.Hidden;
		ToolStrip1.Items.AddRange(new ToolStripItem[6] { TSB_PrevMessage, TSB_NextMessage, ToolStripButton1, ToolStripButton2, ToolStripButton4, PopupOptions });
		ToolStrip1.Location = new Point(0, 167);
		ToolStrip1.Name = "ToolStrip1";
		ToolStrip1.Padding = new Padding(5, 0, 1, 0);
		ToolStrip1.Size = new Size(565, 25);
		ToolStrip1.Stretch = true;
		ToolStrip1.TabIndex = 4;
		ToolStrip1.Text = "ToolStrip1";
		TSB_PrevMessage.BackColor = Color.FromArgb(60, 63, 65);
		TSB_PrevMessage.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_PrevMessage.Image = componentResourceManager.GetObject("TSB_PrevMessage.Image");
		TSB_PrevMessage.ImageTransparentColor = Color.Magenta;
		TSB_PrevMessage.Name = "TSB_PrevMessage";
		TSB_PrevMessage.Size = new Size(72, 22);
		TSB_PrevMessage.Text = "上一个";
		TSB_NextMessage.BackColor = Color.FromArgb(60, 63, 65);
		TSB_NextMessage.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_NextMessage.Image = componentResourceManager.GetObject("TSB_NextMessage.Image");
		TSB_NextMessage.ImageTransparentColor = Color.Magenta;
		TSB_NextMessage.Name = "TSB_NextMessage";
		TSB_NextMessage.Size = new Size(52, 22);
		TSB_NextMessage.Text = "下一个";
		ToolStripButton1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripButton1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripButton1.Image = componentResourceManager.GetObject("ToolStripButton1.Image");
		ToolStripButton1.ImageTransparentColor = Color.Magenta;
		ToolStripButton1.Name = "ToolStripButton1";
		ToolStripButton1.Size = new Size(119, 22);
		ToolStripButton1.Text = "跳转到位置";
		ToolStripButton2.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripButton2.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripButton2.Image = componentResourceManager.GetObject("ToolStripButton2.Image");
		ToolStripButton2.ImageTransparentColor = Color.Magenta;
		ToolStripButton2.Name = "ToolStripButton2";
		ToolStripButton2.Size = new Size(56, 22);
		ToolStripButton2.Text = "关闭";
		PopupOptions.BackColor = Color.FromArgb(60, 63, 65);
		PopupOptions.ForeColor = Color.FromArgb(220, 220, 220);
		PopupOptions.Image = componentResourceManager.GetObject("PopupOptions.Image");
		PopupOptions.ImageTransparentColor = Color.Magenta;
		PopupOptions.Name = "PopupOptions";
		PopupOptions.Size = new Size(112, 22);
		PopupOptions.Text = "Pop-up Options";
		WebBrowser1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		WebBrowser1.Location = new Point(0, -1);
		WebBrowser1.MinimumSize = new Size(20, 20);
		WebBrowser1.Name = "WebBrowser1";
		WebBrowser1.Size = new Size(565, 165);
		WebBrowser1.TabIndex = 16;
		ToolStripButton4.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripButton4.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripButton4.Image = componentResourceManager.GetObject("ToolStripButton4.Image");
		ToolStripButton4.ImageTransparentColor = Color.Magenta;
		ToolStripButton4.Name = "ToolStripButton4";
		ToolStripButton4.Size = new Size(112, 22);
		ToolStripButton4.Text = "关闭+恢复";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(565, 192);
		base.Controls.Add(WebBrowser1);
		base.Controls.Add(ToolStrip1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "NewMessageForm";
		base.ShowIcon = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "新消息";
		ToolStrip1.ResumeLayout(performLayout: false);
		ToolStrip1.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	private void RegisterInterruptibleTests(object sender, FormClosingEventArgs e)
	{
		try
		{
			Client.OpenMessageWindows.Remove(Messages[0].Type);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200393", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void ManageInterruptibleTests(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		if (Messages.Count == 0)
		{
			Close();
		}
		taskPublisher = Messages[0];
		CountInterruptibleInterpreter(taskPublisher);
		TSB_PrevMessage.Enabled = false;
		TSB_NextMessage.Enabled = Messages.Count > 1;
		BringToFront();
	}

	private bool RevertInterruptibleTests(WebBrowser webBrowser_0, ref string string_0, string string_1)
	{
		bool flag = false;
		if (string_0.Contains("[LOADDOC"))
		{
			int num = Strings.InStr(string_0, "[LOADDOC", CompareMethod.Text) + "[LOADDOC".Length - 1;
			int num2 = Strings.InStr(num, string_0, "]", CompareMethod.Text);
			int num3 = Strings.InStr(string_0, "[/LOADDOC]", CompareMethod.Text);
			int num4 = 0;
			int num5 = 0;
			string text = string_0.Substring(num2, string_0.Length - num2 - (string_0.Length - num3 + 1));
			if (num2 - num > 1)
			{
				string text2 = string_0.Substring(num, num2 - num);
				int result;
				if (text2.Contains("SizeX="))
				{
					num = Strings.InStr(text2, "SizeX=", CompareMethod.Text) + 6 - 1;
					for (num3 = num; num3 < text2.Length && Versioned.IsNumeric(text2.Substring(num3, 1)); num3++)
					{
					}
					if (int.TryParse(text2.Substring(num, num3 - num), out result))
					{
						num4 = result;
					}
				}
				if (text2.Contains("SizeY="))
				{
					num = Strings.InStr(text2, "SizeY=", CompareMethod.Text) + 6 - 1;
					for (num3 = num; num3 < text2.Length && Versioned.IsNumeric(text2.Substring(num3, 1)); num3++)
					{
					}
					if (int.TryParse(text2.Substring(num, num3 - num), out result))
					{
						num5 = result;
					}
				}
			}
			if (!string.IsNullOrEmpty(GameGeneral.AttachmentRepoPath) && FileExistsNative.FileExistsFast(Path.Combine(GameGeneral.AttachmentRepoPath, text)))
			{
				webBrowser_0.Navigate(Path.Combine(GameGeneral.AttachmentRepoPath, text));
				flag = true;
			}
			else
			{
				string fileName = Path.GetFileName(text);
				if (!string.IsNullOrEmpty(string_1) && FileExistsNative.FileExistsFast(Path.Combine(string_1, fileName)))
				{
					webBrowser_0.Navigate(Path.Combine(string_1, fileName));
					flag = true;
				}
			}
			string_0 = Path.GetFileName(text);
			if (flag)
			{
				if (num4 > 0)
				{
					base.Width = num4;
				}
				if (num5 > 0)
				{
					base.Height = num5;
				}
				if (num4 + num5 > 0)
				{
					CenterToScreen();
				}
			}
			else
			{
				string_0 = "SCENARIO ATTACHMENT NOT FOUND: " + string_0;
			}
		}
		return flag;
	}

	private void CountInterruptibleInterpreter(LoggedMessage loggedMessage_0)
	{
		loggedMessage_0.Text = loggedMessage_0.Text.Replace("\ufffd", Conversions.ToString(Strings.Chr(176)));
		if (loggedMessage_0.Type == LoggedMessage.MessageType.SpecialMessage && RevertInterruptibleTests(WebBrowser1, ref loggedMessage_0.Text, Path.GetDirectoryName(Client._PolicyClass)))
		{
			loggedMessage_0.Text = "Displayed scenario attachment " + loggedMessage_0.Text;
		}
		else
		{
			InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, "<span style='font:Arial'>" + loggedMessage_0.Text + "<span>");
		}
		if (loggedMessage_0.Location.HasValue && ((loggedMessage_0.Location.Value.Latitude != 0.0) | (loggedMessage_0.Location.Value.Longitude != 0.0)))
		{
			ToolStripButton1.Visible = true;
		}
		else
		{
			ToolStripButton1.Visible = false;
		}
		TSB_PrevMessage.Enabled = Messages.IndexOf(taskPublisher) != 0;
		TSB_NextMessage.Enabled = Messages.IndexOf(taskPublisher) != Messages.Count - 1;
		BringToFront();
		if (loggedMessage_0.ForceMapRecentre)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, loggedMessage_0.Location.Value.DisableInvocation());
		}
	}

	private void CustomizeInterruptibleInterpreter(object sender, EventArgs e)
	{
		if (taskPublisher.Location.HasValue && ((taskPublisher.Location.Value.Latitude != 0.0) | (taskPublisher.Location.Value.Longitude != 0.0)))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, taskPublisher.Location.Value.DisableInvocation());
		}
	}

	private void CloneInterruptibleInterpreter(object sender, EventArgs e)
	{
		Close();
	}

	private void ConnectInterruptibleInterpreter(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.Options.TabControl1.SelectTab(2);
		ItemExporter.ConnectInterruptibleTemplate.Options.Show();
	}

	private void MoveInterruptibleInterpreter(object sender, EventArgs e)
	{
		Client.CurrentGame.Run();
		Close();
	}

	private void DeleteInterruptibleInterpreter(object sender, NotifyCollectionChangedEventArgs e)
	{
		Text = Conversions.ToString(Messages.Count) + "新消息的类型：" + Misc.ToEnglishString(((LoggedMessage)e.NewItems[0]).Type);
	}

	private void AddInterruptibleInterpreter(object sender, EventArgs e)
	{
		if (Messages.IndexOf(taskPublisher) != 0)
		{
			taskPublisher = Messages[Messages.IndexOf(taskPublisher) - 1];
			CountInterruptibleInterpreter(taskPublisher);
		}
	}

	private void DestroyInterruptibleInterpreter(object sender, EventArgs e)
	{
		if (Messages.IndexOf(taskPublisher) != Messages.Count - 1)
		{
			taskPublisher = Messages[Messages.IndexOf(taskPublisher) + 1];
			CountInterruptibleInterpreter(taskPublisher);
		}
	}

	private void ComputeInterruptibleInterpreter(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Client.CurrentGame.Run();
			Close();
		}
		else if (e.KeyCode == Keys.F12 && base.Visible)
		{
			Close();
			Client.CurrentGame.Run();
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void PatchInterruptibleInterpreter(object sender, PreviewKeyDownEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Client.CurrentGame.Run();
			Close();
		}
		else if (e.KeyCode == Keys.F12 && base.Visible)
		{
			Close();
			Client.CurrentGame.Run();
		}
		else
		{
			KeyEventArgs e2 = new KeyEventArgs(e.KeyCode);
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e2);
		}
	}
}
