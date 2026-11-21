using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using DarkUI.Config;

namespace Command;

public sealed class DarkUIButton : Control, IButtonControl
{
	private HelperMethods.MouseMode _ResolverValue;

	private int publisherValue;

	private DialogResult serverValue;

	[Category("Custom")]
	[Description("Gets or sets a value indicating whether the control can Rounded in corners.")]
	public int RoundRadius
	{
		get
		{
			return publisherValue;
		}
		set
		{
			publisherValue = value;
			Invalidate();
		}
	}

	public DialogResult DialogResult
	{
		get
		{
			return serverValue;
		}
		set
		{
			serverValue = value;
		}
	}

	public DarkUIButton()
	{
		publisherValue = 0;
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		DoubleBuffered = true;
		BackColor = Color.Transparent;
		ForeColor = SystemColors.Control;
		UpdateStyles();
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		Rectangle rectangle = new Rectangle(0, 0, base.Width - 1, base.Height - 2);
		Rectangle rectangle2 = new Rectangle(0, 1, base.Width - 1, base.Height - 2);
		if (RoundRadius <= 0)
		{
			graphicsPath.AddRectangle(rectangle);
			graphicsPath2.AddRectangle(rectangle2);
		}
		else
		{
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphicsPath = HelperMethods.RoundRec(rectangle, RoundRadius);
			graphicsPath2 = HelperMethods.RoundRec(rectangle2, RoundRadius);
		}
		graphicsPath.CloseFigure();
		graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		if (base.Enabled)
		{
			switch (_ResolverValue)
			{
			case HelperMethods.MouseMode.Normal:
			{
				using (LinearGradientBrush brush5 = new LinearGradientBrush(rectangle, Color.FromArgb(48, 48, 48), Color.FromArgb(64, 64, 64), 270f))
				{
					using Pen pen6 = new Pen(Color.FromArgb(22, 22, 22));
					using Pen pen5 = new Pen(Color.FromArgb(30, Color.White));
					using SolidBrush brush6 = new SolidBrush(ForeColor);
					graphics.FillPath(brush5, graphicsPath);
					graphics.DrawPath(pen5, graphicsPath2);
					graphics.DrawPath(pen6, graphicsPath);
					graphics.DrawString(Text, Font, brush6, new Rectangle(0, 0, base.Width, base.Height), HelperMethods.SetPosition());
				}
				break;
			}
			case HelperMethods.MouseMode.Hovered:
			{
				Cursor = Cursors.Hand;
				using (LinearGradientBrush brush3 = new LinearGradientBrush(rectangle, Color.FromArgb(29, 29, 29), Color.FromArgb(41, 41, 41), 270f))
				{
					using Pen pen4 = new Pen(Color.FromArgb(22, 22, 22));
					using Pen pen3 = new Pen(Color.FromArgb(30, Color.White));
					using SolidBrush brush4 = new SolidBrush(ForeColor);
					graphics.FillPath(brush3, graphicsPath);
					graphics.DrawPath(pen3, graphicsPath2);
					graphics.DrawPath(pen4, graphicsPath);
					graphics.DrawString(Text, Font, brush4, new Rectangle(0, 0, base.Width, base.Height), HelperMethods.SetPosition());
				}
				break;
			}
			case HelperMethods.MouseMode.Pushed:
			{
				using (LinearGradientBrush brush = new LinearGradientBrush(rectangle, Color.FromArgb(48, 48, 48), Color.FromArgb(64, 64, 64), 270f))
				{
					using Pen pen2 = new Pen(Color.FromArgb(22, 22, 22));
					using Pen pen = new Pen(Color.FromArgb(30, Color.White));
					using SolidBrush brush2 = new SolidBrush(ForeColor);
					graphics.FillPath(brush, graphicsPath);
					graphics.DrawPath(pen, graphicsPath2);
					graphics.DrawPath(pen2, graphicsPath);
					graphics.DrawString(Text, Font, brush2, new Rectangle(0, 0, base.Width, base.Height), HelperMethods.SetPosition());
				}
				break;
			}
			}
		}
		else
		{
			Color disabledText = Colors.DisabledText;
			using SolidBrush brush7 = new SolidBrush(Colors.DarkGreySelection);
			using Pen pen8 = new Pen(Color.FromArgb(22, 22, 22));
			using Pen pen7 = new Pen(Color.FromArgb(30, Color.White));
			using SolidBrush brush8 = new SolidBrush(disabledText);
			graphics.FillPath(brush7, graphicsPath);
			graphics.DrawPath(pen7, graphicsPath2);
			graphics.DrawPath(pen8, graphicsPath);
			graphics.DrawString(Text, Font, brush8, new Rectangle(0, 0, base.Width, base.Height), HelperMethods.SetPosition());
		}
		graphicsPath.Dispose();
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
		_ResolverValue = HelperMethods.MouseMode.Hovered;
		Invalidate();
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseUp(e);
		_ResolverValue = HelperMethods.MouseMode.Pushed;
		Invalidate();
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		base.OnMouseEnter(e);
		_ResolverValue = HelperMethods.MouseMode.Hovered;
		Invalidate();
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseEnter(e);
		_ResolverValue = HelperMethods.MouseMode.Normal;
		Invalidate();
	}

	public void NotifyDefault(bool value)
	{
	}

	public void PerformClick()
	{
	}
}
