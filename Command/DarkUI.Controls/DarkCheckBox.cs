using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkCheckBox : CheckBox
{
	private DarkControlState m_AdapterParameter;

	private bool m_SchemaParameter;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new Appearance Appearance => base.Appearance;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new bool AutoEllipsis => base.AutoEllipsis;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new Image BackgroundImage => base.BackgroundImage;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new ImageLayout BackgroundImageLayout => base.BackgroundImageLayout;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new bool FlatAppearance => false;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new FlatStyle FlatStyle => base.FlatStyle;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new Image Image => base.Image;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new ContentAlignment ImageAlign => base.ImageAlign;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new int ImageIndex => base.ImageIndex;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new string ImageKey => base.ImageKey;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new ImageList ImageList => base.ImageList;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new ContentAlignment TextAlign => base.TextAlign;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new TextImageRelation TextImageRelation => base.TextImageRelation;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new bool ThreeState
	{
		get
		{
			return base.ThreeState;
		}
		set
		{
			base.ThreeState = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new bool UseCompatibleTextRendering => false;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new bool UseVisualStyleBackColor => false;

	public DarkCheckBox()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, value: true);
	}

	private void ResetConfig(DarkControlState darkControlState_0)
	{
		if (m_AdapterParameter != darkControlState_0)
		{
			m_AdapterParameter = darkControlState_0;
			Invalidate();
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		if (m_SchemaParameter)
		{
			return;
		}
		if (e.Button == MouseButtons.Left)
		{
			if (base.ClientRectangle.Contains(e.Location))
			{
				ResetConfig(DarkControlState.Pressed);
			}
			else
			{
				ResetConfig(DarkControlState.Hover);
			}
		}
		else
		{
			ResetConfig(DarkControlState.Hover);
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (base.ClientRectangle.Contains(e.Location))
		{
			ResetConfig(DarkControlState.Pressed);
		}
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
		if (!m_SchemaParameter)
		{
			ResetConfig(DarkControlState.Normal);
		}
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		if (!m_SchemaParameter)
		{
			ResetConfig(DarkControlState.Normal);
		}
	}

	protected override void OnMouseCaptureChanged(EventArgs e)
	{
		base.OnMouseCaptureChanged(e);
		if (!m_SchemaParameter)
		{
			Point position = Cursor.Position;
			if (!base.ClientRectangle.Contains(position))
			{
				ResetConfig(DarkControlState.Normal);
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
		m_SchemaParameter = false;
		Point position = Cursor.Position;
		if (base.ClientRectangle.Contains(position))
		{
			ResetConfig(DarkControlState.Hover);
		}
		else
		{
			ResetConfig(DarkControlState.Normal);
		}
	}

	protected override void OnKeyDown(KeyEventArgs ke)
	{
		base.OnKeyDown(ke);
		if (ke.KeyCode == Keys.Space)
		{
			m_SchemaParameter = true;
			ResetConfig(DarkControlState.Pressed);
		}
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		base.OnKeyUp(e);
		if (e.KeyCode == Keys.Space)
		{
			m_SchemaParameter = false;
			Point position = Cursor.Position;
			if (base.ClientRectangle.Contains(position))
			{
				ResetConfig(DarkControlState.Hover);
			}
			else
			{
				ResetConfig(DarkControlState.Normal);
			}
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		Rectangle rect = new Rectangle(0, 0, base.ClientSize.Width, base.ClientSize.Height);
		int checkBoxSize = Consts.CheckBoxSize;
		Color color = Colors.LightText;
		Color color2 = Colors.LightText;
		Color color3 = Color.Transparent;
		if (base.Enabled)
		{
			if (Focused)
			{
				color2 = Colors.BlueHighlight;
				color3 = Colors.BlueSelection;
			}
			if (m_AdapterParameter == DarkControlState.Hover)
			{
				color2 = Colors.BlueHighlight;
				color3 = Colors.BlueSelection;
			}
			else if (m_AdapterParameter == DarkControlState.Pressed)
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
		using (Pen pen = new Pen(color2))
		{
			Rectangle rect2 = new Rectangle(0, rect.Height / 2 - checkBoxSize / 2, checkBoxSize, checkBoxSize);
			graphics.DrawRectangle(pen, rect2);
		}
		if (base.Checked)
		{
			if (ThreeState && base.CheckState == CheckState.Indeterminate)
			{
				using SolidBrush brush2 = new SolidBrush(color3);
				Rectangle rect3 = new Rectangle(2, rect.Height / 2 - (checkBoxSize - 4) / 2, checkBoxSize - 3, checkBoxSize - 3);
				graphics.FillRectangle(brush2, rect3);
			}
			else
			{
				using Pen pen2 = new Pen(Color.FromArgb(189, 189, 189), 2f);
				Rectangle rectangle = new Rectangle(0, rect.Height / 2 - checkBoxSize / 2, checkBoxSize, checkBoxSize);
				graphics.DrawLines(pen2, new Point[3]
				{
					new Point(rectangle.Left + 2, rectangle.Top + 6),
					new Point(rectangle.Left + 5, rectangle.Top + 9),
					new Point(rectangle.Left + 12, rectangle.Top + 2)
				});
			}
		}
		using (new SolidBrush(color))
		{
			new StringFormat
			{
				LineAlignment = StringAlignment.Center,
				Alignment = StringAlignment.Near
			};
			TextRenderer.DrawText(bounds: new Rectangle(checkBoxSize + 4, 2, rect.Width - checkBoxSize, rect.Height), dc: graphics, text: Text, font: Font, foreColor: color, flags: TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak);
		}
	}
}
