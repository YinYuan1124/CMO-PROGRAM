using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Command;

public sealed class GControl0 : Control
{
	public enum Style
	{
		Close,
		Minimize,
		Maximize
	}

	private HelperMethods.MouseMode _PredicateValue;

	private Style m_SingletonValue;

	[Description("Gets or sets the type of control button.")]
	[Category("Custom")]
	public Style ControlStyle
	{
		get
		{
			return m_SingletonValue;
		}
		set
		{
			m_SingletonValue = value;
			Invalidate();
		}
	}

	public GControl0()
	{
		m_SingletonValue = Style.Close;
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		DoubleBuffered = true;
		BackColor = Color.Transparent;
		UpdateStyles();
		Anchor = AnchorStyles.Top | AnchorStyles.Right;
		base.Size = new Size(18, 18);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		graphics.SmoothingMode = SmoothingMode.AntiAlias;
		switch (_PredicateValue)
		{
		case HelperMethods.MouseMode.Normal:
		{
			using LinearGradientBrush brush3 = new LinearGradientBrush(new Rectangle(1, 1, 15, 15), Color.FromArgb(48, 48, 48), Color.FromArgb(64, 64, 64), 270f);
			using Pen pen3 = new Pen(Color.FromArgb(22, 22, 22));
			graphics.FillEllipse(brush3, new Rectangle(1, 1, 15, 15));
			graphics.DrawEllipse(pen3, new Rectangle(1, 1, 15, 15));
			break;
		}
		case HelperMethods.MouseMode.Hovered:
		{
			Cursor = Cursors.Hand;
			using LinearGradientBrush brush2 = new LinearGradientBrush(new Rectangle(1, 1, 15, 15), Color.FromArgb(29, 29, 29), Color.FromArgb(41, 41, 41), 90f);
			using Pen pen2 = new Pen(Color.FromArgb(22, 22, 22));
			graphics.FillEllipse(brush2, new Rectangle(1, 1, 15, 15));
			graphics.DrawEllipse(pen2, new Rectangle(1, 1, 15, 15));
			break;
		}
		case HelperMethods.MouseMode.Pushed:
		{
			using LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(1, 1, 15, 15), Color.FromArgb(48, 48, 48), Color.FromArgb(64, 64, 64), 270f);
			using Pen pen = new Pen(Color.FromArgb(22, 22, 22));
			graphics.FillEllipse(brush, new Rectangle(1, 1, 15, 15));
			graphics.DrawEllipse(pen, new Rectangle(1, 1, 15, 15));
			break;
		}
		}
	}

	protected override void OnClick(EventArgs e)
	{
		base.OnClick(e);
		if (ControlStyle == Style.Close)
		{
			Environment.Exit(0);
			Application.Exit();
		}
		else if (ControlStyle == Style.Minimize)
		{
			if (FindForm().WindowState == FormWindowState.Normal)
			{
				FindForm().WindowState = FormWindowState.Minimized;
			}
		}
		else if (ControlStyle == Style.Maximize)
		{
			if (FindForm().WindowState == FormWindowState.Normal)
			{
				FindForm().WindowState = FormWindowState.Maximized;
			}
			else if (FindForm().WindowState == FormWindowState.Maximized)
			{
				FindForm().WindowState = FormWindowState.Normal;
			}
		}
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		base.OnMouseEnter(e);
		_PredicateValue = HelperMethods.MouseMode.Hovered;
		Invalidate();
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
		_PredicateValue = HelperMethods.MouseMode.Hovered;
		Invalidate();
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		_PredicateValue = HelperMethods.MouseMode.Pushed;
		Invalidate();
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		_PredicateValue = HelperMethods.MouseMode.Normal;
		Invalidate();
	}
}
