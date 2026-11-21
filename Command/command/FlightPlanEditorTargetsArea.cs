using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanEditorTargetsArea : CommandSecondaryFormBase
{
	private IContainer m_ComparatorTask;

	[field: AccessedThroughProperty("AreaEditor_PatrolArea")]
	internal AreaEditor AreaEditor_PatrolArea
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public FlightPlanEditorTargetsArea()
	{
		ViewPrinter();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_ComparatorTask != null)
			{
				m_ComparatorTask.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ViewPrinter()
	{
		AreaEditor_PatrolArea = new AreaEditor();
		SuspendLayout();
		AreaEditor_PatrolArea.Location = new Point(28, 40);
		AreaEditor_PatrolArea.Name = "AreaEditor_PatrolArea";
		AreaEditor_PatrolArea.Size = new Size(351, 124);
		AreaEditor_PatrolArea.TabIndex = 4;
		AreaEditor_PatrolArea.Title = null;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(832, 442);
		base.Controls.Add(AreaEditor_PatrolArea);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FlightPlanEditorTargetsArea";
		base.ShowIcon = false;
		Text = "FlightPlanEditorTargetsArea";
		ResumeLayout(performLayout: false);
	}
}
