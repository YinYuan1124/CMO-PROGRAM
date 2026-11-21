using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanEditorWaypointDetails : DarkSecondaryFormBase
{
	private IContainer paramTask;

	[AccessedThroughProperty("TabControl_FlightPlanEditor_WaypointDetails")]
	[CompilerGenerated]
	private DarkUITabControl m_PageTask;

	[AccessedThroughProperty("TabPage1")]
	[CompilerGenerated]
	private TabPage rulesTask;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage2")]
	private TabPage m_MethodTask;

	internal DarkUITabControl TabControl_FlightPlanEditor_WaypointDetails
	{
		[CompilerGenerated]
		get
		{
			return m_PageTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PageTask = value;
		}
	}

	internal TabPage TabPage1
	{
		[CompilerGenerated]
		get
		{
			return rulesTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rulesTask = value;
		}
	}

	internal TabPage TabPage2
	{
		[CompilerGenerated]
		get
		{
			return m_MethodTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MethodTask = value;
		}
	}

	[field: AccessedThroughProperty("TabPage3")]
	internal TabPage TabPage3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public FlightPlanEditorWaypointDetails()
	{
		base.FormClosed += FillPrinter;
		base.FormClosing += CalculatePrinter;
		base.KeyDown += PopPrinter;
		SetPrinter();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && paramTask != null)
			{
				paramTask.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void SetPrinter()
	{
		TabControl_FlightPlanEditor_WaypointDetails = new DarkUITabControl();
		TabPage1 = new TabPage();
		TabPage2 = new TabPage();
		TabPage3 = new TabPage();
		TabControl_FlightPlanEditor_WaypointDetails.SuspendLayout();
		SuspendLayout();
		TabControl_FlightPlanEditor_WaypointDetails.Controls.Add(TabPage1);
		TabControl_FlightPlanEditor_WaypointDetails.Controls.Add(TabPage2);
		TabControl_FlightPlanEditor_WaypointDetails.Controls.Add(TabPage3);
		TabControl_FlightPlanEditor_WaypointDetails.Cursor = Cursors.Hand;
		TabControl_FlightPlanEditor_WaypointDetails.Dock = DockStyle.Fill;
		TabControl_FlightPlanEditor_WaypointDetails.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		TabControl_FlightPlanEditor_WaypointDetails.ItemSize = new Size(80, 20);
		TabControl_FlightPlanEditor_WaypointDetails.Location = new Point(0, 0);
		TabControl_FlightPlanEditor_WaypointDetails.Name = "TabControl_FlightPlanEditor_WaypointDetails";
		TabControl_FlightPlanEditor_WaypointDetails.SelectedIndex = 0;
		TabControl_FlightPlanEditor_WaypointDetails.Size = new Size(832, 387);
		TabControl_FlightPlanEditor_WaypointDetails.TabIndex = 0;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Location = new Point(4, 24);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(824, 359);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "目标";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		TabPage2.Location = new Point(4, 24);
		TabPage2.Name = "TabPage2";
		TabPage2.Padding = new Padding(3);
		TabPage2.Size = new Size(824, 359);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "Weapon Release";
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		TabPage3.Location = new Point(4, 24);
		TabPage3.Name = "TabPage3";
		TabPage3.Padding = new Padding(3);
		TabPage3.Size = new Size(824, 359);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "巡逻";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(832, 387);
		base.Controls.Add(TabControl_FlightPlanEditor_WaypointDetails);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FlightPlanEditorWaypointDetails";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "FlightPlanEditorWaypointDetails";
		TabControl_FlightPlanEditor_WaypointDetails.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	private void FillPrinter(object sender, FormClosedEventArgs e)
	{
	}

	private void CalculatePrinter(object sender, FormClosingEventArgs e)
	{
		Hide();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void PopPrinter(object sender, KeyEventArgs e)
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
}
