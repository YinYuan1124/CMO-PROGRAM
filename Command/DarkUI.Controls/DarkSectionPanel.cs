using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkSectionPanel : Panel
{
	private string _UtilsExpression;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Padding Padding => base.Padding;

	[Description("The section header text associated with this control.")]
	[Category("Appearance")]
	public string SectionHeader
	{
		get
		{
			return _UtilsExpression;
		}
		set
		{
			_UtilsExpression = value;
			Invalidate();
		}
	}

	public DarkSectionPanel()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, value: true);
		base.Padding = new Padding(1, 25, 1, 1);
	}

	protected override void OnEnter(EventArgs e)
	{
		base.OnEnter(e);
		Invalidate();
	}

	protected override void OnLeave(EventArgs e)
	{
		base.OnLeave(e);
		Invalidate();
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (base.Controls.Count > 0)
		{
			base.Controls[0].Focus();
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		Rectangle clientRectangle = base.ClientRectangle;
		using (SolidBrush brush = new SolidBrush(Colors.GreyBackground))
		{
			graphics.FillRectangle(brush, clientRectangle);
		}
		Color color = (base.ContainsFocus ? Colors.BlueBackground : Colors.HeaderBackground);
		Color color2 = (base.ContainsFocus ? Colors.DarkBlueBorder : Colors.DarkBorder);
		Color color3 = (base.ContainsFocus ? Colors.LightBlueBorder : Colors.LightBorder);
		using (SolidBrush brush2 = new SolidBrush(color))
		{
			Rectangle rect = new Rectangle(0, 0, clientRectangle.Width, 25);
			graphics.FillRectangle(brush2, rect);
		}
		using (Pen pen = new Pen(color2))
		{
			graphics.DrawLine(pen, clientRectangle.Left, 0, clientRectangle.Right, 0);
			graphics.DrawLine(pen, clientRectangle.Left, 24, clientRectangle.Right, 24);
		}
		using (Pen pen2 = new Pen(color3))
		{
			graphics.DrawLine(pen2, clientRectangle.Left, 1, clientRectangle.Right, 1);
		}
		int num = 3;
		using (SolidBrush brush3 = new SolidBrush(Colors.LightText))
		{
			Rectangle rectangle = new Rectangle(num, 0, clientRectangle.Width - 4 - num, 25);
			StringFormat format = new StringFormat
			{
				Alignment = StringAlignment.Near,
				LineAlignment = StringAlignment.Center,
				FormatFlags = StringFormatFlags.NoWrap,
				Trimming = StringTrimming.EllipsisCharacter
			};
			graphics.DrawString(SectionHeader, Font, brush3, rectangle, format);
		}
		using Pen pen3 = new Pen(Colors.DarkBorder, 1f);
		Rectangle rect2 = new Rectangle(clientRectangle.Left, clientRectangle.Top, clientRectangle.Width - 1, clientRectangle.Height - 1);
		graphics.DrawRectangle(pen3, rect2);
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
	}
}
