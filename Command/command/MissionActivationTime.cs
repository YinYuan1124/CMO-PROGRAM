using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class MissionActivationTime : DarkSecondaryFormBase
{
	private IContainer poolContext;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker2")]
	private DarkMaskedTextBox m_FilterContext;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private DarkLabel testsContext;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton m_InterpreterContext;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel m_ContainerContext;

	public Mission TheMission;

	[field: AccessedThroughProperty("DateTimePicker1")]
	internal DarkMaskedTextBox DateTimePicker1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkMaskedTextBox DateTimePicker2
	{
		[CompilerGenerated]
		get
		{
			return m_FilterContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_FilterContext = value;
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return testsContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			testsContext = value;
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return m_InterpreterContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DisableInterruptibleDefinition;
			DarkUIButton interpreterContext = m_InterpreterContext;
			if (interpreterContext != null)
			{
				interpreterContext.Click -= value2;
			}
			m_InterpreterContext = value;
			interpreterContext = m_InterpreterContext;
			if (interpreterContext != null)
			{
				interpreterContext.Click += value2;
			}
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_ContainerContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ContainerContext = value;
		}
	}

	public MissionActivationTime()
	{
		base.FormClosed += InstantiateInterruptibleDefinition;
		base.Load += ReadInterruptibleDefinition;
		base.KeyDown += UpdateInterruptibleDefinition;
		base.FormClosing += InsertInterruptibleDefinition;
		PopInterruptibleDefinition();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && poolContext != null)
			{
				poolContext.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PopInterruptibleDefinition()
	{
		DateTimePicker1 = new DarkMaskedTextBox();
		DateTimePicker2 = new DarkMaskedTextBox();
		Label2 = new DarkLabel();
		Button1 = new DarkUIButton();
		Label1 = new DarkLabel();
		SuspendLayout();
		DateTimePicker1.BackColor = Color.FromArgb(31, 31, 31);
		DateTimePicker1.BorderStyle = BorderStyle.FixedSingle;
		DateTimePicker1.ForeColor = Color.FromArgb(220, 220, 220);
		DateTimePicker1.Location = new Point(198, 43);
		DateTimePicker1.Name = "DateTimePicker1";
		DateTimePicker1.Size = new Size(231, 23);
		DateTimePicker1.TabIndex = 2;
		DateTimePicker2.BackColor = Color.FromArgb(31, 31, 31);
		DateTimePicker2.BorderStyle = BorderStyle.FixedSingle;
		DateTimePicker2.ForeColor = Color.FromArgb(220, 220, 220);
		DateTimePicker2.Location = new Point(198, 67);
		DateTimePicker2.Name = "DateTimePicker2";
		DateTimePicker2.Size = new Size(231, 23);
		DateTimePicker2.TabIndex = 3;
		Label2.AutoSize = true;
		Label2.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(13, 13);
		Label2.Name = "Label2";
		Label2.Size = new Size(41, 13);
		Label2.TabIndex = 10;
		Label2.Text = "Label2";
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 12f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(439, 42);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(86, 48);
		Button1.TabIndex = 11;
		Button1.Text = "设置";
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(13, 47);
		Label1.Name = "Label1";
		Label1.Size = new Size(160, 13);
		Label1.TabIndex = 12;
		Label1.Text = "Start at this date and time (Zulu):";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(541, 99);
		base.Controls.Add(Label1);
		base.Controls.Add(Button1);
		base.Controls.Add(Label2);
		base.Controls.Add(DateTimePicker2);
		base.Controls.Add(DateTimePicker1);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "MissionActivationTime";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "Mission Activation Time";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void InstantiateInterruptibleDefinition(object sender, FormClosedEventArgs e)
	{
		if (Client.MissionEditorWindow.Visible)
		{
			Client.MissionEditorWindow.RefreshMissions();
		}
		Mission.StartTimeChanged -= CompareInterruptibleDefinition;
	}

	private void CreateInterruptibleDefinition()
	{
		if (TheMission.StartTime.HasValue)
		{
			if (TheMission.IsActive)
			{
				Label2.Text = "任务已经激活（开始时间：" + TheMission.StartTime.Value.ToShortDateString() + " - " + TheMission.StartTime.Value.ToLongTimeString() + " Zulu)";
			}
			else
			{
				Label2.Text = "Mission is set to start at: " + TheMission.StartTime.Value.ToShortDateString() + " - " + TheMission.StartTime.Value.ToLongTimeString() + " Zulu";
			}
		}
		else if (TheMission.IsActive)
		{
			Label2.Text = "Mission is already active.";
		}
		else
		{
			Label2.Text = "Mission is not active.";
		}
	}

	private void CompareInterruptibleDefinition(Mission mission_0)
	{
		if (mission_0 == TheMission)
		{
			CreateInterruptibleDefinition();
		}
	}

	private void ReadInterruptibleDefinition(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		CreateInterruptibleDefinition();
		Mission.StartTimeChanged += CompareInterruptibleDefinition;
		DateTimePicker1.Enabled = true;
		DateTimePicker2.Enabled = true;
		if (TheMission.StartTime.HasValue)
		{
			DateTime dateTime_ = TheMission.StartTime.Value;
			string string_ = null;
			GameGeneral.PaddedTimeString(ref dateTime_, ref string_);
			string string_2 = null;
			GameGeneral.PaddedDateString(ref dateTime_, ref string_2, bool_1: false);
			DateTimePicker1.Text = string_2;
			DateTimePicker2.Text = string_;
		}
		else
		{
			DateTime dateTime_2 = Client.CurrentScenario.Time;
			string string_3 = null;
			GameGeneral.PaddedTimeString(ref dateTime_2, ref string_3);
			string string_4 = null;
			GameGeneral.PaddedDateString(ref dateTime_2, ref string_4, bool_1: false);
			DateTimePicker1.Text = string_4;
			DateTimePicker2.Text = string_3;
		}
	}

	private void DisableInterruptibleDefinition(object sender, EventArgs e)
	{
		List<string> list = DateTimePicker2.Text.Split(':').ToList();
		if (!(Versioned.IsNumeric(list[0]) & Versioned.IsNumeric(list[1]) & Versioned.IsNumeric(list[2])))
		{
			return;
		}
		List<string> list2 = DateTimePicker1.Text.Split('-').ToList();
		if (!(Versioned.IsNumeric(list2[0]) & Versioned.IsNumeric(list2[1]) & Versioned.IsNumeric(list2[2])))
		{
			return;
		}
		TheMission.StartTime_Set(new DateTime(Conversions.ToInteger(list2[0]), Conversions.ToInteger(list2[1]), Conversions.ToInteger(list2[2]), Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2])), Client.CurrentScenario);
		DateTime? startTime = TheMission.StartTime;
		DateTime time = Client.CurrentScenario.Time;
		if ((startTime.HasValue ? new bool?(DateTime.Compare(startTime.GetValueOrDefault(), time) > 0) : null).GetValueOrDefault())
		{
			TheMission.SetStatus(Client.CurrentScenario, Mission.MissionStatus.Inactive);
			if (!Information.IsNothing(Client.MissionEditorWindow))
			{
				Client.MissionEditorWindow.RefreshMissions();
			}
		}
	}

	private void UpdateInterruptibleDefinition(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void InsertInterruptibleDefinition(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}
}
