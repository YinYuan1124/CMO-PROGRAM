using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class MessageLogWindow_RawText : DarkSecondaryFormBase
{
	private IContainer producerConnection;

	[AccessedThroughProperty("WebBrowser1")]
	[CompilerGenerated]
	private WebBrowser procConnection;

	[AccessedThroughProperty("TSTB_Filter")]
	[CompilerGenerated]
	private DarkUITextBox structContext;

	[AccessedThroughProperty("DarkUIButton1")]
	[CompilerGenerated]
	private DarkUIButton merchantContext;

	[AccessedThroughProperty("DarkLabel1")]
	[CompilerGenerated]
	private DarkLabel callbackContext;

	private long decoratorContext;

	private bool _ProcessContext;

	internal WebBrowser WebBrowser1
	{
		[CompilerGenerated]
		get
		{
			return procConnection;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			procConnection = value;
		}
	}

	internal DarkUITextBox TSTB_Filter
	{
		[CompilerGenerated]
		get
		{
			return structContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = ValidateInterruptibleRegistry;
			EventHandler value3 = GetInterruptibleRegistry;
			EventHandler value4 = WriteInterruptibleRegistry;
			DarkUITextBox darkUITextBox = structContext;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
				darkUITextBox.Enter -= value3;
				darkUITextBox.Leave -= value4;
			}
			structContext = value;
			darkUITextBox = structContext;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
				darkUITextBox.Enter += value3;
				darkUITextBox.Leave += value4;
			}
		}
	}

	internal DarkUIButton DarkUIButton1
	{
		[CompilerGenerated]
		get
		{
			return merchantContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NewInterruptibleRegistry;
			DarkUIButton darkUIButton = merchantContext;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			merchantContext = value;
			darkUIButton = merchantContext;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkLabel DarkLabel1
	{
		[CompilerGenerated]
		get
		{
			return callbackContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			callbackContext = value;
		}
	}

	public MessageLogWindow_RawText()
	{
		base.FormClosing += SelectInterruptibleRegistry;
		base.Load += CallInterruptibleRegistry;
		base.Resize += LogoutInterruptibleRegistry;
		base.Shown += ViewInterruptibleRegistry;
		base.KeyDown += LoginInterruptibleRegistry;
		_ProcessContext = true;
		PatchInterruptibleRegistry();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && producerConnection != null)
			{
				producerConnection.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PatchInterruptibleRegistry()
	{
		WebBrowser1 = new WebBrowser();
		TSTB_Filter = new DarkUITextBox();
		DarkUIButton1 = new DarkUIButton();
		DarkLabel1 = new DarkLabel();
		SuspendLayout();
		WebBrowser1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		WebBrowser1.Location = new Point(0, 32);
		WebBrowser1.Margin = new Padding(0);
		WebBrowser1.MinimumSize = new Size(20, 20);
		WebBrowser1.Name = "WebBrowser1";
		WebBrowser1.Size = new Size(1040, 700);
		WebBrowser1.TabIndex = 24;
		TSTB_Filter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TSTB_Filter.AutoCompleteCustomSource = null;
		TSTB_Filter.AutoCompleteMode = AutoCompleteMode.None;
		TSTB_Filter.AutoCompleteSource = AutoCompleteSource.None;
		TSTB_Filter.BackColor = Color.Transparent;
		TSTB_Filter.ForeColor = Color.FromArgb(189, 189, 189);
		TSTB_Filter.Image = null;
		TSTB_Filter.Lines = null;
		TSTB_Filter.Location = new Point(47, 5);
		TSTB_Filter.MaxLength = 32767;
		TSTB_Filter.Multiline = false;
		TSTB_Filter.Name = "TSTB_Filter";
		TSTB_Filter.ReadOnly = false;
		TSTB_Filter.ScrollBars = ScrollBars.None;
		TSTB_Filter.SelectionStart = 0;
		TSTB_Filter.Size = new Size(813, 24);
		TSTB_Filter.TabIndex = 26;
		TSTB_Filter.TextAlign = HorizontalAlignment.Left;
		TSTB_Filter.UseSystemPasswordChar = false;
		TSTB_Filter.WatermarkText = "";
		DarkUIButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		DarkUIButton1.BackColor = Color.Transparent;
		DarkUIButton1.DialogResult = DialogResult.None;
		DarkUIButton1.ForeColor = SystemColors.Control;
		DarkUIButton1.Location = new Point(871, 5);
		DarkUIButton1.Name = "DarkUIButton1";
		DarkUIButton1.RoundRadius = 0;
		DarkUIButton1.Size = new Size(162, 23);
		DarkUIButton1.TabIndex = 27;
		DarkUIButton1.Text = "切换到交互视图";
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(5, 9);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(36, 15);
		DarkLabel1.TabIndex = 28;
		DarkLabel1.Text = "过滤：";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(1040, 732);
		base.Controls.Add(DarkLabel1);
		base.Controls.Add(DarkUIButton1);
		base.Controls.Add(TSTB_Filter);
		base.Controls.Add(WebBrowser1);
		base.KeyPreview = true;
		base.Name = "MessageLogWindow";
		MinimumSize = new Size(200, 200);
		base.ShowIcon = false;
		Text = "消息日志 - 纯文本";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void SelectInterruptibleRegistry(object sender, FormClosingEventArgs e)
	{
		if (ItemExporter.ConnectInterruptibleTemplate.MainForm.gclass5_0 == null && ((e.CloseReason == CloseReason.UserClosing) & !Client.infoClass))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlViewModel.LogCollapsed = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.ShowEmbeddedMessageLog();
		}
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void CallInterruptibleRegistry(object sender, EventArgs e)
	{
		_ProcessContext = true;
	}

	private void LogoutInterruptibleRegistry(object sender, EventArgs e)
	{
		RefreshWindow(bool_0: false);
	}

	private void ViewInterruptibleRegistry(object sender, EventArgs e)
	{
		Client.MustRefreshMainForm = true;
		RefreshWindow(bool_0: false);
	}

	public void MessageLogWindowClear()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<div style='margin:-20 -10 -10 -10; padding:10 5 5 5;font-family:Verdana;height:" + Conversions.ToString(WebBrowser1.Height) + ";background-color:black;font-size:9pt;'></div>");
		string string_ = stringBuilder.ToString();
		InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, string_);
	}

	public void RefreshWindow(bool bool_0)
	{
		if (Information.IsNothing(Client.CurrentSide))
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<div style='margin:-20 -10 -10 -10; padding:10 5 5 5;font-family:Verdana;height:" + Conversions.ToString(WebBrowser1.Height) + ";background-color:#333333;font-size:9pt;'>");
			stringBuilder.Append("</div>");
			string string_ = stringBuilder.ToString();
			InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, string_);
			return;
		}
		List<LoggedMessage> list = (from theM in Client.CurrentSide.GetMessageLog_Hybrid(Client.CurrentScenario)
			orderby theM.Timestamp descending, theM.Increment descending
			select theM).ToList();
		if (bool_0 && list.Count > 0)
		{
			if (decoratorContext == list[0].Increment)
			{
				return;
			}
			decoratorContext = list[0].Increment;
		}
		if (!string.IsNullOrEmpty(TSTB_Filter.Text))
		{
			list = list.Where((LoggedMessage loggedMessage_0) => loggedMessage_0.Text.ToLower().Contains(TSTB_Filter.Text.ToLower())).ToList();
		}
		StringBuilder stringBuilder2 = new StringBuilder();
		stringBuilder2.Append("<div style='margin:-20 -10 -10 -10; padding:10 5 5 5;font-family:Verdana;height:" + Conversions.ToString(WebBrowser1.Height) + ";background-color:#333333;font-size:9pt;'>");
		foreach (LoggedMessage item in list)
		{
			string text = "";
			if (item.Side != null)
			{
				text = item.Side.ObjectID;
			}
			Color messageColor = item.MessageColor;
			if (item.GetMessageFont(Font).Style == FontStyle.Italic)
			{
				stringBuilder2.Append("<i>");
			}
			stringBuilder2.Append("<div style='color:#" + messageColor.R.ToString("X2") + messageColor.G.ToString("X2") + messageColor.B.ToString("X2") + "'>");
			stringBuilder2.Append(item.Timestamp.ToLongTimeString());
			if (!string.IsNullOrEmpty(text) && Operators.CompareString(text, Client.CurrentSide.ObjectID, TextCompare: true) != 0)
			{
				stringBuilder2.Append(" - [").Append(item.Side.Name).Append("] ")
					.Append(item.Text);
			}
			else
			{
				stringBuilder2.Append(" - ").Append(item.Text);
			}
			stringBuilder2.Append("</div>");
			if (item.GetMessageFont(Font).Style == FontStyle.Italic)
			{
				stringBuilder2.Append("</i>");
			}
			stringBuilder2.Append("<br/>");
		}
		stringBuilder2.Append("</div>");
		string string_2 = stringBuilder2.ToString();
		InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, string_2);
	}

	private void ValidateInterruptibleRegistry(object object_0)
	{
		RefreshWindow(bool_0: false);
	}

	private void LoginInterruptibleRegistry(object sender, KeyEventArgs e)
	{
		if (_ProcessContext)
		{
			if ((e.KeyValue == 13 || e.KeyValue == 27) && base.Visible)
			{
				Select();
			}
			if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}
	}

	private void GetInterruptibleRegistry(object sender, EventArgs e)
	{
		_ProcessContext = false;
	}

	private void WriteInterruptibleRegistry(object sender, EventArgs e)
	{
		_ProcessContext = true;
		Select();
	}

	private void NewInterruptibleRegistry(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.OpenMessageLogWindowWPF(base.Left, base.Top, base.Width, base.Height);
		Hide();
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		if (_ProcessContext)
		{
			Client.HandleGlobalHotkeys(keyData);
			return true;
		}
		return base.ProcessCmdKey(ref m, keyData);
	}

	[CompilerGenerated]
	private bool PushInterruptibleRegistry(LoggedMessage loggedMessage_0)
	{
		return loggedMessage_0.Text.ToLower().Contains(TSTB_Filter.Text.ToLower());
	}
}
