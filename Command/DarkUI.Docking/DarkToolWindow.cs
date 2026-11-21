using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;
using OpenDis.Database;

namespace DarkUI.Docking;

[ToolboxItem(false)]
public sealed class DarkToolWindow : DarkDockContent
{
	private Rectangle m_ReponseParameter;

	private bool descriptorParameter;

	private bool _PoolParameter;

	private Rectangle taskParameter;

	private bool m_FilterParameter;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new Padding Padding => base.Padding;

	public DarkToolWindow()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, value: true);
		BackColor = Colors.GreyBackground;
		base.Padding = new Padding(0, 25, 0, 0);
		InterruptConfig();
	}

	private bool ConcatConfig()
	{
		if (base.DockPanel == null)
		{
			return false;
		}
		return base.DockPanel.ActiveContent == this;
	}

	private void InterruptConfig()
	{
		taskParameter = new Rectangle
		{
			X = base.ClientRectangle.Left,
			Y = base.ClientRectangle.Top,
			Width = base.ClientRectangle.Width,
			Height = 25
		};
		m_ReponseParameter = new Rectangle
		{
			X = base.ClientRectangle.Right - RequestDecoratorEntry.tw_close.Width - 5 - 3,
			Y = base.ClientRectangle.Top + 12 - RequestDecoratorEntry.tw_close.Height / 2,
			Width = RequestDecoratorEntry.tw_close.Width,
			Height = RequestDecoratorEntry.tw_close.Height
		};
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		InterruptConfig();
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		if (!m_ReponseParameter.Contains(e.Location) && !_PoolParameter)
		{
			if (descriptorParameter)
			{
				descriptorParameter = false;
				Invalidate();
			}
			if (m_FilterParameter)
			{
				base.DockPanel.DragContent(this);
			}
		}
		else if (!descriptorParameter)
		{
			descriptorParameter = true;
			Invalidate();
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (m_ReponseParameter.Contains(e.Location))
		{
			_PoolParameter = true;
			descriptorParameter = true;
			Invalidate();
		}
		else if (taskParameter.Contains(e.Location))
		{
			m_FilterParameter = true;
		}
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
		if (m_ReponseParameter.Contains(mevent.Location) && _PoolParameter)
		{
			Close();
		}
		_PoolParameter = false;
		descriptorParameter = false;
		m_FilterParameter = false;
		Invalidate();
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		using (SolidBrush brush = new SolidBrush(Colors.GreyBackground))
		{
			graphics.FillRectangle(brush, base.ClientRectangle);
		}
		bool flag;
		Color color = ((flag = ConcatConfig()) ? Colors.BlueBackground : Colors.HeaderBackground);
		Color color2 = (flag ? Colors.DarkBlueBorder : Colors.DarkBorder);
		Color color3 = (flag ? Colors.LightBlueBorder : Colors.LightBorder);
		using (SolidBrush brush2 = new SolidBrush(color))
		{
			Rectangle rect = new Rectangle(0, 0, base.ClientRectangle.Width, 25);
			graphics.FillRectangle(brush2, rect);
		}
		using (Pen pen = new Pen(color2))
		{
			graphics.DrawLine(pen, base.ClientRectangle.Left, 0, base.ClientRectangle.Right, 0);
			graphics.DrawLine(pen, base.ClientRectangle.Left, 24, base.ClientRectangle.Right, 24);
		}
		using (Pen pen2 = new Pen(color3))
		{
			graphics.DrawLine(pen2, base.ClientRectangle.Left, 1, base.ClientRectangle.Right, 1);
		}
		int num = 2;
		if (base.Icon != null)
		{
			graphics.DrawImageUnscaled(base.Icon, base.ClientRectangle.Left + 5, base.ClientRectangle.Top + 12 - base.Icon.Height / 2 + 1);
			num = base.Icon.Width + 8;
		}
		using (SolidBrush brush3 = new SolidBrush(Colors.LightText))
		{
			Rectangle rectangle = new Rectangle(num, 0, base.ClientRectangle.Width - 4 - num, 25);
			StringFormat format = new StringFormat
			{
				Alignment = StringAlignment.Near,
				LineAlignment = StringAlignment.Center,
				FormatFlags = StringFormatFlags.NoWrap,
				Trimming = StringTrimming.EllipsisCharacter
			};
			graphics.DrawString(base.DockText, Font, brush3, rectangle, format);
		}
		Bitmap image = (descriptorParameter ? RequestDecoratorEntry.tw_close_selected : RequestDecoratorEntry.tw_close);
		if (flag)
		{
			image = (descriptorParameter ? RequestDecoratorEntry.tw_active_close_selected : RequestDecoratorEntry.tw_active_close);
		}
		graphics.DrawImageUnscaled(image, m_ReponseParameter.Left, m_ReponseParameter.Top);
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
	}
}
