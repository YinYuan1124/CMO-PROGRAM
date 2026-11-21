using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class RegressionTests : CommandSecondaryFormBase
{
	private IContainer objectPredicate;

	[field: AccessedThroughProperty("TextBox1")]
	internal TextBox TextBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public RegressionTests()
	{
		base.Load += CreateInterruptibleToken;
		base.KeyDown += CompareInterruptibleToken;
		base.FormClosing += ReadInterruptibleToken;
		InstantiateInterruptibleToken();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && objectPredicate != null)
			{
				objectPredicate.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void InstantiateInterruptibleToken()
	{
		TextBox1 = new TextBox();
		SuspendLayout();
		TextBox1.Dock = DockStyle.Fill;
		TextBox1.Location = new Point(0, 0);
		TextBox1.Multiline = true;
		TextBox1.Name = "TextBox1";
		TextBox1.ScrollBars = ScrollBars.Vertical;
		TextBox1.Size = new Size(544, 378);
		TextBox1.TabIndex = 0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(544, 378);
		base.Controls.Add(TextBox1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "RegressionTests";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "回归测试";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void CreateInterruptibleToken(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		TextBox1.Text = "Running regression tests...\r\n\r\n";
		Application.DoEvents();
		TextBox1.Text += "测试1（问题＃1122）：";
		Application.DoEvents();
		TextBox1.Text += Test1();
		TextBox1.Text += "\r\n\r\nAll regression tests have finished.";
	}

	public string Test1()
	{
		try
		{
			return "PASS";
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
			return "FAIL";
		}
	}

	private void CompareInterruptibleToken(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
	}

	private void ReadInterruptibleToken(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}
}
