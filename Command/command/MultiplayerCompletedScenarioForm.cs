using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class MultiplayerCompletedScenarioForm : Form
{
	private IContainer m_PrototypeResolver;

	public MultiplayerCompletedScenarioForm()
	{
		CustomizeInterruptibleFilter();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_PrototypeResolver != null)
			{
				m_PrototypeResolver.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CustomizeInterruptibleFilter()
	{
		m_PrototypeResolver = new Container();
		base.AutoScaleMode = AutoScaleMode.Font;
		Text = "MultiplayerCompletedScenarioForm";
	}
}
