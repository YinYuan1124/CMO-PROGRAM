using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic.CompilerServices;

namespace OpenDis.Common;

[DesignerGenerated]
internal class ExpressionPublisher : Form
{
	private Container m_DispatcherPublisher;

	[AccessedThroughProperty("Chart1")]
	[CompilerGenerated]
	private Chart listenerPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private Timer m_ConfigPublisher;

	internal virtual Chart Chart1
	{
		[CompilerGenerated]
		get
		{
			return listenerPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			listenerPublisher = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual Timer VerifyInterruptibleAlgo()
	{
		return m_ConfigPublisher;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void ListInterruptibleAlgo(Timer timer_0)
	{
		m_ConfigPublisher = timer_0;
	}

	public ExpressionPublisher()
	{
		RestartInterruptibleTests();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_DispatcherPublisher != null)
			{
				((IDisposable)m_DispatcherPublisher).Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void RestartInterruptibleTests()
	{
		m_DispatcherPublisher = new Container();
		ChartArea chartArea = new ChartArea();
		Legend legend = new Legend();
		Chart1 = new Chart();
		ListInterruptibleAlgo(new Timer(m_DispatcherPublisher));
		((ISupportInitialize)Chart1).BeginInit();
		SuspendLayout();
		chartArea.Name = "ChartArea1";
		Chart1.ChartAreas.Add(chartArea);
		Chart1.Dock = DockStyle.Fill;
		legend.Name = "Legend1";
		Chart1.Legends.Add(legend);
		Chart1.Location = new Point(0, 0);
		Chart1.Name = "Chart1";
		Chart1.Size = new Size(213, 99);
		Chart1.TabIndex = 0;
		Chart1.Text = "Chart1";
		VerifyInterruptibleAlgo().Enabled = true;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(213, 99);
		base.Controls.Add(Chart1);
		base.Name = "MultiplayerTimings";
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "MultiplayerTimings";
		((ISupportInitialize)Chart1).EndInit();
		ResumeLayout(performLayout: false);
	}
}
