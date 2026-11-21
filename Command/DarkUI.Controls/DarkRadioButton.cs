using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkRadioButton : RadioButton
{
	private DarkControlState m_ValueExpression;

	private bool tokenizerExpression;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new Appearance Appearance => base.Appearance;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new bool AutoEllipsis => base.AutoEllipsis;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Image BackgroundImage => base.BackgroundImage;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new ImageLayout BackgroundImageLayout => base.BackgroundImageLayout;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new bool FlatAppearance => false;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new FlatStyle FlatStyle => base.FlatStyle;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Image Image => base.Image;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new ContentAlignment ImageAlign => base.ImageAlign;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new int ImageIndex => base.ImageIndex;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new string ImageKey => base.ImageKey;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new ImageList ImageList => base.ImageList;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new ContentAlignment TextAlign => base.TextAlign;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new TextImageRelation TextImageRelation => base.TextImageRelation;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new bool UseCompatibleTextRendering => false;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new bool UseVisualStyleBackColor => false;

	public DarkRadioButton()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, value: true);
	}

	private void ReadRegistry(DarkControlState darkControlState_0)
	{
		if (m_ValueExpression != darkControlState_0)
		{
			m_ValueExpression = darkControlState_0;
			Invalidate();
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		if (tokenizerExpression)
		{
			return;
		}
		if (e.Button == MouseButtons.Left)
		{
			if (base.ClientRectangle.Contains(e.Location))
			{
				ReadRegistry(DarkControlState.Pressed);
			}
			else
			{
				ReadRegistry(DarkControlState.Hover);
			}
		}
		else
		{
			ReadRegistry(DarkControlState.Hover);
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (base.ClientRectangle.Contains(e.Location))
		{
			ReadRegistry(DarkControlState.Pressed);
		}
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
		if (!tokenizerExpression)
		{
			ReadRegistry(DarkControlState.Normal);
		}
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		if (!tokenizerExpression)
		{
			ReadRegistry(DarkControlState.Normal);
		}
	}

	protected override void OnMouseCaptureChanged(EventArgs e)
	{
		base.OnMouseCaptureChanged(e);
		if (!tokenizerExpression)
		{
			Point position = Cursor.Position;
			if (!base.ClientRectangle.Contains(position))
			{
				ReadRegistry(DarkControlState.Normal);
			}
		}
	}

	protected override void OnGotFocus(EventArgs e)
	{
		base.OnGotFocus(e);
		Invalidate();
	}

	protected override void OnLostFocus(EventArgs e)
	{
		base.OnLostFocus(e);
		tokenizerExpression = false;
		Point position = Cursor.Position;
		if (base.ClientRectangle.Contains(position))
		{
			ReadRegistry(DarkControlState.Hover);
		}
		else
		{
			ReadRegistry(DarkControlState.Normal);
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		Rectangle rect = new Rectangle(0, 0, base.ClientSize.Width, base.ClientSize.Height);
		int radioButtonSize = Consts.RadioButtonSize;
		Color color = Colors.LightText;
		Color color2 = Colors.LightText;
		Color color3 = Colors.LightestBackground;
		if (base.Enabled)
		{
			if (Focused)
			{
				color2 = Colors.BlueHighlight;
				color3 = Colors.BlueSelection;
			}
			if (m_ValueExpression == DarkControlState.Hover)
			{
				color2 = Colors.BlueHighlight;
				color3 = Colors.BlueSelection;
			}
			else if (m_ValueExpression == DarkControlState.Pressed)
			{
				color2 = Colors.GreyHighlight;
				color3 = Colors.GreySelection;
			}
		}
		else
		{
			color = Colors.DisabledText;
			color2 = Colors.GreyHighlight;
			color3 = Colors.GreySelection;
		}
		using (SolidBrush brush = new SolidBrush(Colors.GreyBackground))
		{
			graphics.FillRectangle(brush, rect);
		}
		graphics.SmoothingMode = SmoothingMode.HighQuality;
		using (Pen pen = new Pen(color2))
		{
			Rectangle rect2 = new Rectangle(0, rect.Height / 2 - radioButtonSize / 2, radioButtonSize, radioButtonSize);
			graphics.DrawEllipse(pen, rect2);
		}
		if (base.Checked)
		{
			using SolidBrush brush2 = new SolidBrush(color3);
			Rectangle rect3 = new Rectangle(3, rect.Height / 2 - (radioButtonSize - 7) / 2 - 1, radioButtonSize - 6, radioButtonSize - 6);
			graphics.FillEllipse(brush2, rect3);
		}
		graphics.SmoothingMode = SmoothingMode.Default;
		using SolidBrush brush3 = new SolidBrush(color);
		StringFormat format = new StringFormat
		{
			LineAlignment = StringAlignment.Center,
			Alignment = StringAlignment.Near
		};
		graphics.DrawString(layoutRectangle: new Rectangle(radioButtonSize + 4, 0, rect.Width - radioButtonSize, rect.Height), s: Text, font: Font, brush: brush3, format: format);
	}
}
