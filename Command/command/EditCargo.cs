using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditCargo : DarkSecondaryFormBase
{
	private IContainer writerWatcher;

	[AccessedThroughProperty("ElementHost1")]
	[CompilerGenerated]
	private ElementHost m_SpecificationWatcher;

	internal EditCargoControl _WatcherWatcher;

	public ActiveUnit SelectedHost;

	private Keys[] reponseWatcher;

	internal ElementHost ElementHost1
	{
		[CompilerGenerated]
		get
		{
			return m_SpecificationWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SpecificationWatcher = value;
		}
	}

	public EditCargo()
	{
		base.Load += ChangeMapping;
		reponseWatcher = new Keys[1] { Keys.Escape };
		EnableMapping();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && writerWatcher != null)
			{
				writerWatcher.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void EnableMapping()
	{
		ElementHost1 = new ElementHost();
		_WatcherWatcher = new EditCargoControl();
		SuspendLayout();
		ElementHost1.Dock = DockStyle.Fill;
		ElementHost1.Location = new Point(0, 0);
		ElementHost1.Name = "ElementHost1";
		ElementHost1.Size = new Size(746, 328);
		ElementHost1.TabIndex = 0;
		ElementHost1.Text = "ElementHost1";
		ElementHost1.Child = _WatcherWatcher;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(746, 328);
		base.Controls.Add(ElementHost1);
		base.Name = "EditCargo";
		Text = "修改货物";
		ResumeLayout(performLayout: false);
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] array = reponseWatcher;
		Keys[] array2 = array;
		foreach (Keys keys in array2)
		{
			if (keyData == keys)
			{
				Close();
				return true;
			}
		}
		return false;
	}

	private void ChangeMapping(object sender, EventArgs e)
	{
		if (SelectedHost is Group)
		{
			DarkMessageBox.ShowError("请选择一个单元，而不是一个编组。", "Error");
			Close();
		}
		else
		{
			((EditCargoControl)ElementHost1.Child).DataContext = new EditCargoViewModel(this, (EditCargoControl)ElementHost1.Child, SelectedHost);
		}
	}
}
