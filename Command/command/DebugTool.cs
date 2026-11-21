using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class DebugTool : Form
{
	private IContainer dicTokenizer;

	[AccessedThroughProperty("CB_DetailedSensorReport")]
	[CompilerGenerated]
	private DarkCheckBox m_ConsumerTokenizer;

	internal virtual DarkCheckBox CB_DetailedSensorReport
	{
		[CompilerGenerated]
		get
		{
			return m_ConsumerTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PostServer;
			DarkCheckBox consumerTokenizer = m_ConsumerTokenizer;
			if (consumerTokenizer != null)
			{
				consumerTokenizer.CheckedChanged -= value2;
			}
			m_ConsumerTokenizer = value;
			consumerTokenizer = m_ConsumerTokenizer;
			if (consumerTokenizer != null)
			{
				consumerTokenizer.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TB_DetailedSensorReport")]
	internal virtual RichTextBox TB_DetailedSensorReport
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public DebugTool()
	{
		base.Load += RunServer;
		ResolveServer();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && dicTokenizer != null)
			{
				dicTokenizer.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ResolveServer()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(DebugTool));
		TB_DetailedSensorReport = new RichTextBox();
		CB_DetailedSensorReport = new DarkCheckBox();
		SuspendLayout();
		TB_DetailedSensorReport.BackColor = SystemColors.ControlDarkDark;
		TB_DetailedSensorReport.ForeColor = SystemColors.Info;
		TB_DetailedSensorReport.Location = new Point(12, 35);
		TB_DetailedSensorReport.Name = "TB_DetailedSensorReport";
		TB_DetailedSensorReport.ReadOnly = true;
		TB_DetailedSensorReport.Size = new Size(328, 102);
		TB_DetailedSensorReport.TabIndex = 1;
		TB_DetailedSensorReport.Text = componentResourceManager.GetString("TB_DetailedSensorReport.Text");
		CB_DetailedSensorReport.AutoSize = true;
		CB_DetailedSensorReport.Location = new Point(12, 12);
		CB_DetailedSensorReport.Name = "CB_DetailedSensorReport";
		CB_DetailedSensorReport.Size = new Size(129, 17);
		CB_DetailedSensorReport.TabIndex = 0;
		CB_DetailedSensorReport.Text = "Detailed sensor report";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(60, 63, 65);
		base.ClientSize = new Size(352, 149);
		base.Controls.Add(TB_DetailedSensorReport);
		base.Controls.Add(CB_DetailedSensorReport);
		base.Name = "DebugTool";
		Text = "DebugTool";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void PostServer(object sender, EventArgs e)
	{
		GameGeneral.ReportCompleteSensorDetectionAttempt = CB_DetailedSensorReport.Checked;
	}

	private void RunServer(object sender, EventArgs e)
	{
		CB_DetailedSensorReport.Visible = false;
		TB_DetailedSensorReport.Visible = false;
	}
}
