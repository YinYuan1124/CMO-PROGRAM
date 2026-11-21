using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class UnitMessageLog : DarkSecondaryFormBase
{
	private IContainer interceptorAttr;

	[AccessedThroughProperty("WebBrowser1")]
	[CompilerGenerated]
	private WebBrowser m_MessageAttr;

	[AccessedThroughProperty("ToolStrip1")]
	[CompilerGenerated]
	private DarkToolStrip m_ProductAttr;

	[AccessedThroughProperty("ToolStripLabel1")]
	[CompilerGenerated]
	private ToolStripLabel m_AnnotationAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("TSTB_Filter")]
	private ToolStripTextBox iteratorAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkUITabControl1")]
	private DarkUITabControl m_InitializerAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage1")]
	private TabPage roleAttr;

	[AccessedThroughProperty("TabPage3")]
	[CompilerGenerated]
	private TabPage m_EventAttr;

	private long _WorkerAttr;

	private bool accountAttr;

	public string SelectedUnitID;

	internal WebBrowser WebBrowser1
	{
		[CompilerGenerated]
		get
		{
			return m_MessageAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MessageAttr = value;
		}
	}

	internal DarkToolStrip ToolStrip1
	{
		[CompilerGenerated]
		get
		{
			return m_ProductAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProductAttr = value;
		}
	}

	internal ToolStripLabel ToolStripLabel1
	{
		[CompilerGenerated]
		get
		{
			return m_AnnotationAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AnnotationAttr = value;
		}
	}

	internal ToolStripTextBox TSTB_Filter
	{
		[CompilerGenerated]
		get
		{
			return iteratorAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InvokeInterruptibleComparator;
			EventHandler value3 = ExcludeInterruptibleComparator;
			EventHandler value4 = IncludeInterruptibleComparator;
			ToolStripTextBox toolStripTextBox = iteratorAttr;
			if (toolStripTextBox != null)
			{
				toolStripTextBox.TextChanged -= value2;
				toolStripTextBox.Enter -= value3;
				toolStripTextBox.Leave -= value4;
			}
			iteratorAttr = value;
			toolStripTextBox = iteratorAttr;
			if (toolStripTextBox != null)
			{
				toolStripTextBox.TextChanged += value2;
				toolStripTextBox.Enter += value3;
				toolStripTextBox.Leave += value4;
			}
		}
	}

	internal DarkUITabControl DarkUITabControl1
	{
		[CompilerGenerated]
		get
		{
			return m_InitializerAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SearchInterruptibleComparator;
			DarkUITabControl initializerAttr = m_InitializerAttr;
			if (initializerAttr != null)
			{
				initializerAttr.SelectedIndexChanged -= value2;
			}
			m_InitializerAttr = value;
			initializerAttr = m_InitializerAttr;
			if (initializerAttr != null)
			{
				initializerAttr.SelectedIndexChanged += value2;
			}
		}
	}

	internal TabPage TabPage1
	{
		[CompilerGenerated]
		get
		{
			return roleAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			roleAttr = value;
		}
	}

	[field: AccessedThroughProperty("TabPage2")]
	internal TabPage TabPage2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabPage5")]
	internal TabPage TabPage5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TabPage TabPage3
	{
		[CompilerGenerated]
		get
		{
			return m_EventAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_EventAttr = value;
		}
	}

	[field: AccessedThroughProperty("TabPage4")]
	internal TabPage TabPage4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && interceptorAttr != null)
			{
				interceptorAttr.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void LogoutInterruptibleComparator()
	{
		WebBrowser1 = new WebBrowser();
		ToolStrip1 = new DarkToolStrip();
		ToolStripLabel1 = new ToolStripLabel();
		TSTB_Filter = new ToolStripTextBox();
		DarkUITabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		TabPage5 = new TabPage();
		TabPage2 = new TabPage();
		TabPage3 = new TabPage();
		TabPage4 = new TabPage();
		ToolStrip1.SuspendLayout();
		DarkUITabControl1.SuspendLayout();
		SuspendLayout();
		WebBrowser1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		WebBrowser1.Location = new Point(0, 55);
		WebBrowser1.Margin = new Padding(0);
		WebBrowser1.MinimumSize = new Size(20, 20);
		WebBrowser1.Name = "WebBrowser1";
		WebBrowser1.Size = new Size(643, 295);
		WebBrowser1.TabIndex = 24;
		ToolStrip1.AutoSize = false;
		ToolStrip1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStrip1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStrip1.GripStyle = ToolStripGripStyle.Hidden;
		ToolStrip1.Items.AddRange(new ToolStripItem[2] { ToolStripLabel1, TSTB_Filter });
		ToolStrip1.Location = new Point(0, 0);
		ToolStrip1.Name = "ToolStrip1";
		ToolStrip1.Padding = new Padding(5, 0, 1, 0);
		ToolStrip1.Size = new Size(643, 25);
		ToolStrip1.TabIndex = 25;
		ToolStrip1.Text = "ToolStrip1";
		ToolStripLabel1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripLabel1.Name = "ToolStripLabel1";
		ToolStripLabel1.Size = new Size(36, 22);
		ToolStripLabel1.Text = "过滤：";
		TSTB_Filter.BackColor = Color.FromArgb(60, 63, 65);
		TSTB_Filter.ForeColor = Color.FromArgb(220, 220, 220);
		TSTB_Filter.Name = "TSTB_Filter";
		TSTB_Filter.Size = new Size(500, 25);
		DarkUITabControl1.Controls.Add(TabPage1);
		DarkUITabControl1.Controls.Add(TabPage5);
		DarkUITabControl1.Controls.Add(TabPage2);
		DarkUITabControl1.Controls.Add(TabPage3);
		DarkUITabControl1.Controls.Add(TabPage4);
		DarkUITabControl1.Cursor = Cursors.Hand;
		DarkUITabControl1.Font = new Font("Segoe UI", 8f);
		DarkUITabControl1.ItemSize = new Size(80, 20);
		DarkUITabControl1.Location = new Point(0, 27);
		DarkUITabControl1.Name = "DarkUITabControl1";
		DarkUITabControl1.SelectedIndex = 0;
		DarkUITabControl1.Size = new Size(1040, 25);
		DarkUITabControl1.TabIndex = 26;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Location = new Point(4, 24);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(1032, 0);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "传感器 & 目标";
		TabPage5.BackColor = Color.FromArgb(60, 63, 65);
		TabPage5.Location = new Point(4, 24);
		TabPage5.Name = "TabPage5";
		TabPage5.Size = new Size(1032, 0);
		TabPage5.TabIndex = 4;
		TabPage5.Text = "武器";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		TabPage2.Location = new Point(4, 24);
		TabPage2.Name = "TabPage2";
		TabPage2.Padding = new Padding(3);
		TabPage2.Size = new Size(1032, 0);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "成员AI";
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		TabPage3.Location = new Point(4, 24);
		TabPage3.Name = "TabPage3";
		TabPage3.Size = new Size(1032, 0);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "损伤";
		TabPage4.BackColor = Color.FromArgb(60, 63, 65);
		TabPage4.Location = new Point(4, 24);
		TabPage4.Name = "TabPage4";
		TabPage4.Size = new Size(1032, 0);
		TabPage4.TabIndex = 3;
		TabPage4.Text = "空中/停靠操作";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(643, 345);
		base.Controls.Add(DarkUITabControl1);
		base.Controls.Add(ToolStrip1);
		base.Controls.Add(WebBrowser1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "UnitMessageLog";
		base.ShowIcon = false;
		Text = "单元消息日志";
		ToolStrip1.ResumeLayout(performLayout: false);
		ToolStrip1.PerformLayout();
		DarkUITabControl1.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	private void ViewInterruptibleComparator(object sender, EventArgs e)
	{
		RefreshWindow(bool_0: false);
	}

	[DllImport("user32.dll")]
	private static extern IntPtr SetActiveWindow(IntPtr intptr_0);

	public UnitMessageLog()
	{
		base.Resize += ViewInterruptibleComparator;
		base.FormClosing += LoginInterruptibleComparator;
		base.Load += GetInterruptibleComparator;
		base.Resize += WriteInterruptibleComparator;
		base.Shown += NewInterruptibleComparator;
		base.KeyDown += SetupInterruptibleComparator;
		LogoutInterruptibleComparator();
		SetStyle(ControlStyles.Selectable, value: false);
	}

	private void LoginInterruptibleComparator(object sender, FormClosingEventArgs e)
	{
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void GetInterruptibleComparator(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}

	private void WriteInterruptibleComparator(object sender, EventArgs e)
	{
		RefreshWindow(bool_0: false);
	}

	private void NewInterruptibleComparator(object sender, EventArgs e)
	{
		Client.MustRefreshMainForm = true;
		ActiveUnit activeUnit = Client.CurrentScenario.ActiveUnits[SelectedUnitID];
		if (activeUnit != null)
		{
			Text = "单元消息日志：" + activeUnit.Name;
		}
		RefreshWindow(bool_0: false);
	}

	public void UnitMessageLogClear()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<div style='margin:-20 -10 -10 -10; padding:10 5 5 5;font-family:Verdana;height:" + Conversions.ToString(WebBrowser1.Height) + ";background-color:black;font-size:9pt;'></div>");
		string string_ = stringBuilder.ToString();
		InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, string_);
	}

	private bool PushInterruptibleComparator(LoggedMessage.MessageType messageType_0)
	{
		switch (messageType_0)
		{
		case LoggedMessage.MessageType.None:
			return false;
		case LoggedMessage.MessageType.UnitLost:
		case LoggedMessage.MessageType.UnitDamage:
			return DarkUITabControl1.SelectedIndex == 3;
		case LoggedMessage.MessageType.UI:
			return false;
		case LoggedMessage.MessageType.UnitAI:
			return DarkUITabControl1.SelectedIndex == 2;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return false;
		case LoggedMessage.MessageType.EventEngine:
			return false;
		case LoggedMessage.MessageType.AirOps:
		case LoggedMessage.MessageType.DockingOps:
			return DarkUITabControl1.SelectedIndex == 4;
		case LoggedMessage.MessageType.SpecialMessage:
			return false;
		case LoggedMessage.MessageType.NewContact:
		case LoggedMessage.MessageType.ContactChange:
		case LoggedMessage.MessageType.NewWeaponContact:
		case LoggedMessage.MessageType.NewMineContact:
		case LoggedMessage.MessageType.CommsIsolatedMessage:
		case LoggedMessage.MessageType.NewAirContact:
		case LoggedMessage.MessageType.NewSurfaceContact:
		case LoggedMessage.MessageType.NewUnderwaterContact:
		case LoggedMessage.MessageType.NewGroundContact:
			return DarkUITabControl1.SelectedIndex == 0;
		case LoggedMessage.MessageType.WeaponEndgame:
		case LoggedMessage.MessageType.WeaponDamage:
		case LoggedMessage.MessageType.PointDefence:
		case LoggedMessage.MessageType.WeaponLogic:
		case LoggedMessage.MessageType.UnguidedWeaponModifiers:
			return DarkUITabControl1.SelectedIndex == 1;
		}
	}

	public void RefreshWindow(bool bool_0, bool bool_1 = false)
	{
		if (!base.Visible)
		{
			return;
		}
		if (Client.CurrentSide == null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<div style='margin:-20 -10 -10 -10; padding:10 5 5 5;font-family:Verdana;height:" + Conversions.ToString(WebBrowser1.Height) + ";background-color:black;font-size:9pt;'>");
			stringBuilder.Append("</div>");
			string string_ = stringBuilder.ToString();
			InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, string_);
			return;
		}
		List<LoggedMessage> list = (from loggedMessage_0 in Client.CurrentSide.GetMessageLog_Hybrid(Client.CurrentScenario)
			where Operators.CompareString(loggedMessage_0.ReporterID, SelectedUnitID, TextCompare: true) == 0 && PushInterruptibleComparator(loggedMessage_0.Type)
			select loggedMessage_0 into theM
			orderby theM.Timestamp descending, theM.Increment descending
			select theM).ToList();
		if (bool_0)
		{
			if (list.Count <= 0 || _WorkerAttr == list[0].Increment)
			{
				return;
			}
			_WorkerAttr = list[0].Increment;
		}
		if (!string.IsNullOrEmpty(TSTB_Filter.Text))
		{
			list = list.Where((LoggedMessage loggedMessage_0) => loggedMessage_0.Text.ToLower().Contains(TSTB_Filter.Text.ToLower())).ToList();
		}
		StringBuilder stringBuilder2 = new StringBuilder();
		stringBuilder2.Append("<div style='margin:-20 -10 -10 -10; padding:10 5 5 5;font-family:Verdana;height:" + Conversions.ToString(WebBrowser1.Height) + ";background-color:black;font-size:9pt;'>");
		foreach (LoggedMessage item in list)
		{
			string text = "";
			if (item.Side != null)
			{
				text = item.Side.ObjectID;
			}
			string value = ((string.IsNullOrEmpty(text) || Operators.CompareString(text, Client.CurrentSide.ObjectID, TextCompare: true) == 0) ? (item.Timestamp.ToLongTimeString() + " - " + StripHTML.RemoveSpecification(item.Text)) : (item.Timestamp.ToLongTimeString() + " - [" + item.Side.Name + "] " + StripHTML.RemoveSpecification(item.Text)));
			Color messageColor = item.MessageColor;
			if (item.GetMessageFont(Font).Style == FontStyle.Italic)
			{
				stringBuilder2.Append("<i>");
			}
			stringBuilder2.Append("<div style='color:#" + messageColor.R.ToString("X2") + messageColor.G.ToString("X2") + messageColor.B.ToString("X2") + "'>");
			stringBuilder2.Append(value);
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
		if (!accountAttr)
		{
			ToolStrip1.Select();
		}
	}

	private void InvokeInterruptibleComparator(object sender, EventArgs e)
	{
		RefreshWindow(bool_0: false);
	}

	private void SetupInterruptibleComparator(object sender, KeyEventArgs e)
	{
		if (accountAttr)
		{
			if ((e.KeyValue == 13 || e.KeyValue == 27) && base.Visible)
			{
				ToolStrip1.Select();
			}
			if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}
		if (!accountAttr)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void ExcludeInterruptibleComparator(object sender, EventArgs e)
	{
		accountAttr = true;
	}

	private void IncludeInterruptibleComparator(object sender, EventArgs e)
	{
		accountAttr = false;
		ToolStrip1.Select();
	}

	private void SearchInterruptibleComparator(object sender, EventArgs e)
	{
		RefreshWindow(bool_0: false);
	}

	[CompilerGenerated]
	private bool EnableInterruptibleComparator(LoggedMessage loggedMessage_0)
	{
		if (Operators.CompareString(loggedMessage_0.ReporterID, SelectedUnitID, TextCompare: true) == 0)
		{
			return PushInterruptibleComparator(loggedMessage_0.Type);
		}
		return false;
	}

	[CompilerGenerated]
	private bool ChangeInterruptibleComparator(LoggedMessage loggedMessage_0)
	{
		return loggedMessage_0.Text.ToLower().Contains(TSTB_Filter.Text.ToLower());
	}
}
