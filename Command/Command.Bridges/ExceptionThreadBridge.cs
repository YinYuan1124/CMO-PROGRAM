using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.Bridges;

[DesignerGenerated]
internal class ExceptionThreadBridge : UserControl
{
	private Container m_GetterException;

	public ExceptionThreadBridge()
	{
		CalculateInterruptibleAttr();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_GetterException != null)
			{
				((IDisposable)m_GetterException).Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CalculateInterruptibleAttr()
	{
		m_GetterException = new Container();
		base.AutoScaleMode = AutoScaleMode.Inherit;
	}
}
