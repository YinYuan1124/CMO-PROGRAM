using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FixedFacilityOrientation : DarkSecondaryFormBase
{
	private IContainer _FactoryList;

	[AccessedThroughProperty("TrackBar1")]
	[CompilerGenerated]
	private TrackBar m_AttributeList;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel m_EventList;

	[AccessedThroughProperty("TrackBarPierSize")]
	[CompilerGenerated]
	private TrackBar globalList;

	[AccessedThroughProperty("DarkLabel2")]
	[CompilerGenerated]
	private DarkLabel m_WorkerList;

	[AccessedThroughProperty("DarkLabel1")]
	[CompilerGenerated]
	private DarkLabel m_AccountList;

	[AccessedThroughProperty("PierSizeLabel")]
	[CompilerGenerated]
	private DarkLabel stateList;

	public ActiveUnit SelectedUnit;

	internal TrackBar TrackBar1
	{
		[CompilerGenerated]
		get
		{
			return m_AttributeList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PushSystem;
			TrackBar attributeList = m_AttributeList;
			if (attributeList != null)
			{
				attributeList.ValueChanged -= value2;
			}
			m_AttributeList = value;
			attributeList = m_AttributeList;
			if (attributeList != null)
			{
				attributeList.ValueChanged += value2;
			}
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_EventList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_EventList = value;
		}
	}

	internal TrackBar TrackBarPierSize
	{
		[CompilerGenerated]
		get
		{
			return globalList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ExcludeSystem;
			TrackBar trackBar = globalList;
			if (trackBar != null)
			{
				trackBar.ValueChanged -= value2;
			}
			globalList = value;
			trackBar = globalList;
			if (trackBar != null)
			{
				trackBar.ValueChanged += value2;
			}
		}
	}

	internal DarkLabel DarkLabel2
	{
		[CompilerGenerated]
		get
		{
			return m_WorkerList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_WorkerList = value;
		}
	}

	internal DarkLabel DarkLabel1
	{
		[CompilerGenerated]
		get
		{
			return m_AccountList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AccountList = value;
		}
	}

	internal DarkLabel PierSizeLabel
	{
		[CompilerGenerated]
		get
		{
			return stateList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			stateList = value;
		}
	}

	public FixedFacilityOrientation()
	{
		base.Load += NewSystem;
		base.KeyDown += InvokeSystem;
		base.FormClosing += SetupSystem;
		WriteSystem();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _FactoryList != null)
			{
				_FactoryList.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void WriteSystem()
	{
		TrackBar1 = new TrackBar();
		Label1 = new DarkLabel();
		TrackBarPierSize = new TrackBar();
		DarkLabel2 = new DarkLabel();
		DarkLabel1 = new DarkLabel();
		PierSizeLabel = new DarkLabel();
		((ISupportInitialize)TrackBar1).BeginInit();
		((ISupportInitialize)TrackBarPierSize).BeginInit();
		SuspendLayout();
		TrackBar1.Location = new Point(7, 31);
		TrackBar1.Maximum = 359;
		TrackBar1.Name = "TrackBar1";
		TrackBar1.Size = new Size(210, 45);
		TrackBar1.TabIndex = 0;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(223, 31);
		Label1.Name = "Label1";
		Label1.Size = new Size(50, 15);
		Label1.TabIndex = 1;
		Label1.Text = "当前：";
		TrackBarPierSize.Location = new Point(7, 97);
		TrackBarPierSize.Maximum = 150;
		TrackBarPierSize.Minimum = 1;
		TrackBarPierSize.Name = "TrackBarPierSize";
		TrackBarPierSize.Size = new Size(210, 45);
		TrackBarPierSize.TabIndex = 2;
		TrackBarPierSize.Value = 1;
		DarkLabel2.AutoSize = true;
		DarkLabel2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel2.Location = new Point(8, 79);
		DarkLabel2.Name = "DarkLabel2";
		DarkLabel2.Size = new Size(206, 15);
		DarkLabel2.TabIndex = 4;
		DarkLabel2.Text = "Pier size (Zone unrestricted by terrain)";
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(8, 13);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(67, 15);
		DarkLabel1.TabIndex = 5;
		DarkLabel1.Text = "Orientation";
		PierSizeLabel.AutoSize = true;
		PierSizeLabel.ForeColor = Color.FromArgb(220, 220, 220);
		PierSizeLabel.Location = new Point(223, 97);
		PierSizeLabel.Name = "PierSizeLabel";
		PierSizeLabel.Size = new Size(50, 15);
		PierSizeLabel.TabIndex = 6;
		PierSizeLabel.Text = "当前：";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(304, 140);
		base.Controls.Add(PierSizeLabel);
		base.Controls.Add(DarkLabel1);
		base.Controls.Add(DarkLabel2);
		base.Controls.Add(TrackBarPierSize);
		base.Controls.Add(Label1);
		base.Controls.Add(TrackBar1);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		MaximumSize = new Size(320, 179);
		base.MinimizeBox = false;
		MinimumSize = new Size(320, 179);
		base.Name = "FixedFacilityOrientation";
		base.ShowIcon = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "Set orientation & pier size for unit";
		((ISupportInitialize)TrackBar1).EndInit();
		((ISupportInitialize)TrackBarPierSize).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void NewSystem(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		TrackBar1.Value = (int)Math.Round(SelectedUnit.CurrentHeading);
		if (SelectedUnit.HasDockFacilities)
		{
			Text = "Set orientation & pier size for unit";
			TrackBarPierSize.Value = (int)Math.Round(SelectedUnit.DockingOps.PierLaneLength * 10f);
			TrackBarPierSize.Visible = true;
			PierSizeLabel.Visible = true;
		}
		else
		{
			Text = "设置固定设施的方向";
			TrackBarPierSize.Visible = false;
			PierSizeLabel.Visible = false;
		}
	}

	private void PushSystem(object sender, EventArgs e)
	{
		SelectedUnit.CurrentHeading = TrackBar1.Value;
		SelectedUnit.SetDesiredHeading(ActiveUnit.TurnRate.Max, TrackBar1.Value);
		Label1.Text = "当前：" + Conversions.ToString(TrackBar1.Value);
		Client.MustRefreshMainForm = true;
	}

	private void InvokeSystem(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void SetupSystem(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void ExcludeSystem(object sender, EventArgs e)
	{
		SelectedUnit.CurrentHeading = TrackBar1.Value;
		SelectedUnit.SetDesiredHeading(ActiveUnit.TurnRate.Max, TrackBar1.Value);
		SelectedUnit.DockingOps.PierLaneLength = (float)TrackBarPierSize.Value / 10f;
		PierSizeLabel.Text = SelectedUnit.DockingOps.PierLaneLength + "海里";
		Client.MustRefreshMainForm = true;
	}
}
