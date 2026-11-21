using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class RealismDialog : Form
{
	private IContainer getterSchema;

	internal RealismDialogControl _ProcSchema;

	[field: AccessedThroughProperty("ElementHost1")]
	internal ElementHost ElementHost1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public RealismDialog()
	{
		SearchInterruptibleStatus();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && getterSchema != null)
			{
				getterSchema.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void SearchInterruptibleStatus()
	{
		ElementHost1 = new ElementHost();
		_ProcSchema = new RealismDialogControl();
		SuspendLayout();
		ElementHost1.Dock = DockStyle.Fill;
		ElementHost1.Location = new Point(0, 0);
		ElementHost1.Name = "ElementHost1";
		ElementHost1.Size = new Size(475, 468);
		ElementHost1.TabIndex = 0;
		ElementHost1.Text = "ElementHost1";
		ElementHost1.Child = _ProcSchema;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(475, 468);
		base.Controls.Add(ElementHost1);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "RealismDialog";
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "想定选项";
		base.TopMost = true;
		ResumeLayout(performLayout: false);
	}

	public void SetScenario(Scenario scenario_0)
	{
		((RealismDialogControl)ElementHost1.Child).DataContext = new RealismDialogViewModel(this, scenario_0);
	}
}
