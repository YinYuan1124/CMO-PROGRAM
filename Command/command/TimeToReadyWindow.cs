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
public sealed class TimeToReadyWindow : DarkSecondaryFormBase
{
	private IContainer m_ImporterAttr;

	[AccessedThroughProperty("MaskedTextBox1")]
	[CompilerGenerated]
	private DarkMaskedTextBox repositoryAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel bridgeAttr;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton invocationAttr;

	public List<ActiveUnit> SelectedUnits;

	internal DarkMaskedTextBox MaskedTextBox1
	{
		[CompilerGenerated]
		get
		{
			return repositoryAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			repositoryAttr = value;
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return bridgeAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			bridgeAttr = value;
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return invocationAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ChangeInterruptibleVisitor;
			DarkUIButton darkUIButton = invocationAttr;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			invocationAttr = value;
			darkUIButton = invocationAttr;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	public TimeToReadyWindow()
	{
		base.Shown += EnableInterruptibleVisitor;
		base.KeyDown += InitInterruptibleVisitor;
		base.FormClosing += CheckInterruptibleVisitor;
		base.Load += ConcatInterruptibleVisitor;
		SelectedUnits = new List<ActiveUnit>();
		SearchInterruptibleVisitor();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_ImporterAttr != null)
			{
				m_ImporterAttr.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void SearchInterruptibleVisitor()
	{
		MaskedTextBox1 = new DarkMaskedTextBox();
		Label1 = new DarkLabel();
		Button1 = new DarkUIButton();
		SuspendLayout();
		MaskedTextBox1.BackColor = Color.FromArgb(31, 31, 31);
		MaskedTextBox1.BorderStyle = BorderStyle.FixedSingle;
		MaskedTextBox1.ForeColor = Color.FromArgb(220, 220, 220);
		MaskedTextBox1.Location = new Point(105, 6);
		MaskedTextBox1.Mask = "00:00:00";
		MaskedTextBox1.Name = "MaskedTextBox1";
		MaskedTextBox1.Size = new Size(86, 23);
		MaskedTextBox1.TabIndex = 0;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(3, 9);
		Label1.Name = "Label1";
		Label1.Size = new Size(96, 15);
		Label1.TabIndex = 1;
		Label1.Text = "天：小时：分钟";
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(197, 6);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(81, 23);
		Button1.TabIndex = 2;
		Button1.Text = "确定";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(284, 31);
		base.Controls.Add(Button1);
		base.Controls.Add(Label1);
		base.Controls.Add(MaskedTextBox1);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "TimeToReadyWindow";
		base.ShowIcon = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "就绪时间";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void EnableInterruptibleVisitor(object sender, EventArgs e)
	{
		if (SelectedUnits.Count == 0)
		{
			Close();
		}
	}

	private void ChangeInterruptibleVisitor(object sender, EventArgs e)
	{
		List<string> list = MaskedTextBox1.Text.Replace(".", ":").Split(Conversions.ToCharArrayRankOne(":")).ToList();
		if (!(Versioned.IsNumeric(list[0]) & Versioned.IsNumeric(list[1]) & Versioned.IsNumeric(list[2])))
		{
			return;
		}
		TimeSpan timeSpan = new TimeSpan(Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2]), 0);
		foreach (ActiveUnit selectedUnit in SelectedUnits)
		{
			if (selectedUnit.IsAircraft)
			{
				((Aircraft_AirOps)selectedUnit.AirOps).ConditionTimer = (float)timeSpan.TotalSeconds;
				if (((Aircraft_AirOps)selectedUnit.AirOps).ConditionTimer <= 0f)
				{
					if (((Aircraft_AirOps)selectedUnit.AirOps).Condition == Aircraft_AirOps._AirOpsCondition.Readying)
					{
						((Aircraft_AirOps)selectedUnit.AirOps).Condition = Aircraft_AirOps._AirOpsCondition.Parked;
					}
				}
				else if (((Aircraft_AirOps)selectedUnit.AirOps).Condition == Aircraft_AirOps._AirOpsCondition.Parked)
				{
					((Aircraft_AirOps)selectedUnit.AirOps).Condition = Aircraft_AirOps._AirOpsCondition.Readying;
				}
			}
			else
			{
				selectedUnit.DockingOps.ConditionTimer = (float)timeSpan.TotalSeconds;
			}
		}
		if (!Information.IsNothing(ItemExporter.ConnectInterruptibleTemplate.AirOps) && ItemExporter.ConnectInterruptibleTemplate.AirOps.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.AirOps.RefreshAll();
		}
		if (!Information.IsNothing(ItemExporter.ConnectInterruptibleTemplate.DockingOps) && ItemExporter.ConnectInterruptibleTemplate.DockingOps.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.DockingOps.RefreshAll();
		}
		Close();
	}

	private void InitInterruptibleVisitor(object sender, KeyEventArgs e)
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

	private void CheckInterruptibleVisitor(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void ConcatInterruptibleVisitor(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}
}
