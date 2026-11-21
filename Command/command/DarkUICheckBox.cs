using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DefaultEvent("CheckedChanged")]
[DefaultProperty("Checked")]
public sealed class DarkUICheckBox : Control
{
	public delegate void CheckedChangedEventHandler(object sender);

	private bool adapterValue;

	[CompilerGenerated]
	private CheckedChangedEventHandler schemaValue;

	[Description("Gets or sets a value indicating whether the control is checked.")]
	[Category("Custom")]
	public bool Checked
	{
		get
		{
			return adapterValue;
		}
		set
		{
			adapterValue = value;
			if (schemaValue != null)
			{
				schemaValue?.Invoke(this);
			}
			Invalidate();
		}
	}

	public event CheckedChangedEventHandler CheckedChanged
	{
		[CompilerGenerated]
		add
		{
			CheckedChangedEventHandler checkedChangedEventHandler = schemaValue;
			CheckedChangedEventHandler checkedChangedEventHandler2;
			do
			{
				checkedChangedEventHandler2 = checkedChangedEventHandler;
				CheckedChangedEventHandler value2 = (CheckedChangedEventHandler)Delegate.Combine(checkedChangedEventHandler2, value);
				checkedChangedEventHandler = Interlocked.CompareExchange(ref schemaValue, value2, checkedChangedEventHandler2);
			}
			while ((object)checkedChangedEventHandler != checkedChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CheckedChangedEventHandler checkedChangedEventHandler = schemaValue;
			CheckedChangedEventHandler checkedChangedEventHandler2;
			do
			{
				checkedChangedEventHandler2 = checkedChangedEventHandler;
				CheckedChangedEventHandler value2 = (CheckedChangedEventHandler)Delegate.Remove(checkedChangedEventHandler2, value);
				checkedChangedEventHandler = Interlocked.CompareExchange(ref schemaValue, value2, checkedChangedEventHandler2);
			}
			while ((object)checkedChangedEventHandler != checkedChangedEventHandler2);
		}
	}

	public DarkUICheckBox()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		DoubleBuffered = true;
		Cursor = Cursors.Hand;
		BackColor = Color.Transparent;
		ForeColor = Color.FromArgb(209, 209, 209);
		UpdateStyles();
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		Rectangle rectangle = new Rectangle(1, 0, 18, 17);
		try
		{
			using LinearGradientBrush brush_ = new LinearGradientBrush(rectangle, Color.FromArgb(48, 48, 48), Color.FromArgb(64, 64, 64), 270f);
			using Pen pen = new Pen(Color.FromArgb(22, 22, 22));
			using Pen pen3 = new Pen(Color.FromArgb(189, 189, 189), 2f);
			using Pen pen2 = new Pen(Color.FromArgb(30, Color.White));
			using SolidBrush brush = new SolidBrush(Color.FromArgb(209, 209, 209));
			HelperMethods.FillRoundedPath(graphics, brush_, rectangle, 2);
			HelperMethods.DrawRoundedPath(graphics, pen.Color, 1f, new Rectangle(0, 0, 18, 17), 2);
			graphics.DrawLine(pen2, 3, 1, 15, 1);
			graphics.DrawString(Text, Font, brush, new Rectangle(19, 3, base.Width, base.Height - 4), HelperMethods.SetPosition(StringAlignment.Near));
			if (Checked)
			{
				graphics.DrawLines(pen3, new Point[3]
				{
					new Point(4, 8),
					new Point(7, 11),
					new Point(14, 4)
				});
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	protected override void OnClick(EventArgs e)
	{
		adapterValue = !Checked;
		if (schemaValue != null)
		{
			schemaValue?.Invoke(this);
		}
		base.OnClick(e);
		Invalidate();
	}

	protected override void OnTextChanged(EventArgs e)
	{
		Invalidate();
		base.OnTextChanged(e);
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		base.Height = 18;
		Invalidate();
	}
}
