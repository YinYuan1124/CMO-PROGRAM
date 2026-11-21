using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class Form1 : Form
{
	private IContainer _GlobalFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("PictureBox1")]
	private PictureBox workerFilter;

	internal PictureBox PictureBox1
	{
		[CompilerGenerated]
		get
		{
			return workerFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			workerFilter = value;
		}
	}

	public Form1()
	{
		base.Shown += ForgotInterceptor;
		CollectInterceptor();
	}

	private void ForgotInterceptor(object sender, EventArgs e)
	{
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _GlobalFilter != null)
			{
				_GlobalFilter.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CollectInterceptor()
	{
		PictureBox1 = new PictureBox();
		((ISupportInitialize)PictureBox1).BeginInit();
		SuspendLayout();
		PictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
		PictureBox1.Location = new Point(50, 61);
		PictureBox1.Name = "PictureBox1";
		PictureBox1.Size = new Size(439, 313);
		PictureBox1.TabIndex = 0;
		PictureBox1.TabStop = false;
		base.AutoScaleMode = AutoScaleMode.Inherit;
		BackColor = SystemColors.ControlDark;
		base.ClientSize = new Size(1139, 663);
		base.Controls.Add(PictureBox1);
		base.Name = "Form1";
		Text = "Form1";
		((ISupportInitialize)PictureBox1).EndInit();
		ResumeLayout(performLayout: false);
	}
}
