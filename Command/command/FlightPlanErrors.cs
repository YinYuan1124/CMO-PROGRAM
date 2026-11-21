using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Command.Messages;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanErrors : DarkSecondaryFormBase
{
	private IContainer m_ProcessFilter;

	public const int SW_SHOWNA = 8;

	[field: AccessedThroughProperty("DarkTextBox1")]
	internal DarkTextBox DarkTextBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public FlightPlanErrors()
	{
		base.FormClosing += CallParser;
		base.FormClosed += LogoutParser;
		base.KeyDown += ViewParser;
		base.Shown += ValidateParser;
		base.Load += LoginParser;
		SelectParser();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_ProcessFilter != null)
			{
				m_ProcessFilter.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void SelectParser()
	{
		DarkTextBox1 = new DarkTextBox();
		SuspendLayout();
		DarkTextBox1.BackColor = Color.FromArgb(69, 73, 74);
		DarkTextBox1.BorderStyle = BorderStyle.FixedSingle;
		DarkTextBox1.Dock = DockStyle.Fill;
		DarkTextBox1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkTextBox1.Location = new Point(0, 0);
		DarkTextBox1.Multiline = true;
		DarkTextBox1.Name = "DarkTextBox1";
		DarkTextBox1.Size = new Size(1312, 558);
		DarkTextBox1.TabIndex = 0;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(1312, 558);
		base.Controls.Add(DarkTextBox1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FlightPlanErrors";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "编队任务错误";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void CallParser(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		Hide();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void LogoutParser(object sender, FormClosedEventArgs e)
	{
	}

	private void ViewParser(object sender, KeyEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void ValidateParser(object sender, EventArgs e)
	{
	}

	private void LoginParser(object sender, EventArgs e)
	{
	}

	public void RefreshForm()
	{
		DarkTextBox1.Clear();
		DarkTextBox1.Text = Client.CurrentScenario.GetConcatenated_MDSP_Errors("", "");
		Client.FlightPlanErrorsWindow.Invalidate();
	}

	[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern int ShowWindow(IntPtr intptr_0, int int_0);
}
