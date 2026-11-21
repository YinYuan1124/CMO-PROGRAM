using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

[DefaultEvent("Click")]
[ToolboxBitmap(typeof(Button))]
public sealed class DarkButton : Button
{
	private DarkButtonStyle m_ConfigurationParameter;

	private DarkControlState m_TokenParameter;

	private bool m_IndexerParameter;

	private bool _ResolverParameter;

	private int _PublisherParameter = Consts.Padding / 2;

	private int _ServerParameter = 5;

	public new string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
			Invalidate();
		}
	}

	public new bool Enabled
	{
		get
		{
			return base.Enabled;
		}
		set
		{
			base.Enabled = value;
			Invalidate();
		}
	}

	[Category("Appearance")]
	[Description("Determines the style of the button.")]
	[DefaultValue(DarkButtonStyle.Normal)]
	public DarkButtonStyle ButtonStyle
	{
		get
		{
			return m_ConfigurationParameter;
		}
		set
		{
			m_ConfigurationParameter = value;
			Invalidate();
		}
	}

	[Category("Appearance")]
	[Description("Determines the amount of padding between the image and text.")]
	[DefaultValue(5)]
	public int ImagePadding
	{
		get
		{
			return _ServerParameter;
		}
		set
		{
			_ServerParameter = value;
			Invalidate();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new bool AutoEllipsis => false;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DarkControlState ButtonState => m_TokenParameter;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new ContentAlignment ImageAlign => base.ImageAlign;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new bool FlatAppearance => false;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new FlatStyle FlatStyle => base.FlatStyle;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new ContentAlignment TextAlign => base.TextAlign;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new bool UseCompatibleTextRendering => false;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new bool UseVisualStyleBackColor => false;

	public DarkButton()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, value: true);
		base.UseVisualStyleBackColor = false;
		base.UseCompatibleTextRendering = false;
		QueryConfig(DarkControlState.Normal);
		base.Padding = new Padding(_PublisherParameter);
		ForeColor = Colors.LightText;
	}

	private void QueryConfig(DarkControlState darkControlState_0)
	{
		if (m_TokenParameter != darkControlState_0)
		{
			m_TokenParameter = darkControlState_0;
			Invalidate();
		}
	}

	protected override void OnCreateControl()
	{
		base.OnCreateControl();
		Form form = FindForm();
		if (form != null && form.AcceptButton == this)
		{
			m_IndexerParameter = true;
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		if (_ResolverParameter)
		{
			return;
		}
		if (e.Button == MouseButtons.Left)
		{
			if (base.ClientRectangle.Contains(e.Location))
			{
				QueryConfig(DarkControlState.Pressed);
			}
			else
			{
				QueryConfig(DarkControlState.Hover);
			}
		}
		else
		{
			QueryConfig(DarkControlState.Hover);
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (base.ClientRectangle.Contains(e.Location))
		{
			QueryConfig(DarkControlState.Pressed);
		}
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
		if (!_ResolverParameter)
		{
			QueryConfig(DarkControlState.Normal);
		}
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		if (!_ResolverParameter)
		{
			QueryConfig(DarkControlState.Normal);
		}
	}

	protected override void OnMouseCaptureChanged(EventArgs e)
	{
		base.OnMouseCaptureChanged(e);
		if (!_ResolverParameter)
		{
			Point position = Cursor.Position;
			if (!base.ClientRectangle.Contains(position))
			{
				QueryConfig(DarkControlState.Normal);
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
		_ResolverParameter = false;
		Point position = Cursor.Position;
		if (base.ClientRectangle.Contains(position))
		{
			QueryConfig(DarkControlState.Hover);
		}
		else
		{
			QueryConfig(DarkControlState.Normal);
		}
	}

	protected override void OnKeyDown(KeyEventArgs ke)
	{
		base.OnKeyDown(ke);
		if (ke.KeyCode == Keys.Space)
		{
			_ResolverParameter = true;
			QueryConfig(DarkControlState.Pressed);
		}
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		base.OnKeyUp(e);
		if (e.KeyCode == Keys.Space)
		{
			_ResolverParameter = false;
			Point position = Cursor.Position;
			if (base.ClientRectangle.Contains(position))
			{
				QueryConfig(DarkControlState.Hover);
			}
			else
			{
				QueryConfig(DarkControlState.Normal);
			}
		}
	}

	public override void NotifyDefault(bool value)
	{
		base.NotifyDefault(value);
		if (base.DesignMode)
		{
			m_IndexerParameter = value;
			Invalidate();
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		Rectangle rect = new Rectangle(0, 0, base.ClientSize.Width, base.ClientSize.Height);
		Color color = ForeColor;
		Color color2 = Colors.GreySelection;
		Color color3 = (m_IndexerParameter ? Colors.DarkBlueBackground : Colors.LightBackground);
		if (Enabled)
		{
			if (ButtonStyle == DarkButtonStyle.Normal)
			{
				if (Focused && base.TabStop)
				{
					color2 = Colors.BlueHighlight;
				}
				switch (ButtonState)
				{
				case DarkControlState.Pressed:
					color3 = (m_IndexerParameter ? Colors.DarkBackground : Colors.DarkBackground);
					break;
				case DarkControlState.Hover:
					color3 = (m_IndexerParameter ? Colors.BlueBackground : Colors.LighterBackground);
					break;
				}
			}
			else if (ButtonStyle == DarkButtonStyle.Flat)
			{
				switch (ButtonState)
				{
				case DarkControlState.Normal:
					color3 = Colors.GreyBackground;
					break;
				case DarkControlState.Hover:
					color3 = Colors.MediumBackground;
					break;
				case DarkControlState.Pressed:
					color3 = Colors.DarkBackground;
					break;
				}
			}
		}
		else
		{
			color = Colors.DisabledText;
			color3 = Colors.DarkGreySelection;
		}
		using (SolidBrush brush = new SolidBrush(color3))
		{
			graphics.FillRectangle(brush, rect);
		}
		if (ButtonStyle == DarkButtonStyle.Normal)
		{
			using Pen pen = new Pen(color2, 1f);
			Rectangle rect2 = new Rectangle(rect.Left, rect.Top, rect.Width - 1, rect.Height - 1);
			graphics.DrawRectangle(pen, rect2);
		}
		int num = 0;
		int num2 = 0;
		if (base.Image != null)
		{
			SizeF sizeF = graphics.MeasureString(Text, Font, rect.Size);
			int num3 = base.ClientSize.Width / 2 - base.Image.Size.Width / 2;
			int num4 = base.ClientSize.Height / 2 - base.Image.Size.Height / 2;
			switch (base.TextImageRelation)
			{
			case TextImageRelation.TextBeforeImage:
				num3 += (int)sizeF.Width;
				break;
			case TextImageRelation.ImageAboveText:
				num2 = base.Image.Size.Height / 2 + ImagePadding / 2;
				num4 -= (int)(sizeF.Height / 2f) + ImagePadding / 2;
				break;
			case TextImageRelation.TextAboveImage:
				num2 = (base.Image.Size.Height / 2 + ImagePadding / 2) * -1;
				num4 += (int)(sizeF.Height / 2f) + ImagePadding / 2;
				break;
			case TextImageRelation.ImageBeforeText:
				num = base.Image.Size.Width + ImagePadding * 2;
				num3 = ImagePadding;
				break;
			}
			graphics.DrawImageUnscaled(base.Image, num3, num4);
		}
		using SolidBrush brush2 = new SolidBrush(color);
		Rectangle rectangle = new Rectangle(rect.Left + num + base.Padding.Left, rect.Top + num2 + base.Padding.Top, rect.Width - base.Padding.Horizontal, rect.Height - base.Padding.Vertical);
		StringFormat format = new StringFormat
		{
			LineAlignment = StringAlignment.Center,
			Alignment = StringAlignment.Center,
			Trimming = StringTrimming.EllipsisCharacter
		};
		graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		graphics.DrawString(Text, Font, brush2, rectangle, format);
	}
}
