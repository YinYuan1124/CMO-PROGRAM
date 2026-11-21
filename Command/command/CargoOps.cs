using System;
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
public sealed class CargoOps : DarkSecondaryFormBase
{
	private IContainer _BaseInvocation;

	[AccessedThroughProperty("ElementHost1")]
	[CompilerGenerated]
	private ElementHost m_PolicyInvocation;

	internal CargoOpsControl broadcasterInvocation;

	public ActiveUnit SelectedHost;

	public ActiveUnit SelectedTarget;

	internal ElementHost ElementHost1
	{
		[CompilerGenerated]
		get
		{
			return m_PolicyInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PolicyInvocation = value;
		}
	}

	public CargoOps()
	{
		base.Load += PrepareProccesor;
		InsertProccesor();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _BaseInvocation != null)
			{
				_BaseInvocation.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void InsertProccesor()
	{
		ElementHost1 = new ElementHost();
		broadcasterInvocation = new CargoOpsControl();
		SuspendLayout();
		ElementHost1.Dock = DockStyle.Fill;
		ElementHost1.Location = new Point(0, 0);
		ElementHost1.Name = "ElementHost1";
		ElementHost1.Size = new Size(784, 261);
		ElementHost1.TabIndex = 0;
		ElementHost1.Text = "ElementHost1";
		ElementHost1.Child = broadcasterInvocation;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(784, 261);
		base.Controls.Add(ElementHost1);
		base.Name = "CargoOps";
		Text = "货物对话框";
		ResumeLayout(performLayout: false);
	}

	private void PrepareProccesor(object sender, EventArgs e)
	{
		((CargoOpsControl)ElementHost1.Child).DataContext = new CargoOpsViewModel(this, SelectedHost, SelectedTarget);
	}
}
