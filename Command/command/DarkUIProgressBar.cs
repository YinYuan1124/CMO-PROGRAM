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

[DefaultEvent("ValueChanged")]
[DefaultProperty("Value")]
public sealed class DarkUIProgressBar : Control
{
	public delegate void ValueChangedEventHandler(object sender);

	private int _CreatorValue;

	private int _TemplateValue;

	private bool m_MappingValue;

	[CompilerGenerated]
	private ValueChangedEventHandler m_MockValue;

	private bool m_TagValue;

	private bool fieldValue;

	private Color m_QueueValue;

	[Description("Gets or sets the current position of the progressbar.")]
	[Category("Custom")]
	public int Value
	{
		get
		{
			if (_TemplateValue < 0)
			{
				return 0;
			}
			return _TemplateValue;
		}
		set
		{
			if (value > Maximum)
			{
				value = Maximum;
			}
			_TemplateValue = value;
			if (m_MockValue != null)
			{
				m_MockValue?.Invoke(this);
			}
			Invalidate();
		}
	}

	[Category("Custom")]
	[Description("Gets or sets the maximum value of the progressbar.")]
	public int Maximum
	{
		get
		{
			return _CreatorValue;
		}
		set
		{
			if (value < _TemplateValue)
			{
				_TemplateValue = value;
			}
			_CreatorValue = value;
			Invalidate();
		}
	}

	[Description("Gets or sets the whether the progressbar line be shown or not.")]
	[Category("Custom")]
	public bool ShowProgressLines
	{
		get
		{
			return m_MappingValue;
		}
		set
		{
			m_MappingValue = value;
			Invalidate();
		}
	}

	[Description("Gets or sets the whether the progressbar value be shown or not.")]
	[Category("Custom")]
	public bool ShowProgressValue
	{
		get
		{
			return m_TagValue;
		}
		set
		{
			m_TagValue = value;
			Invalidate();
		}
	}

	[Description("Gets or sets the color used to draw the bar. Set to 'Transparent' for default texture.")]
	[Category("Custom")]
	public Color CustomForeColor
	{
		get
		{
			return m_QueueValue;
		}
		set
		{
			m_QueueValue = value;
			Invalidate();
		}
	}

	[Category("Custom")]
	[Description("Gets or sets whether to display the control's text.")]
	public bool ShowText
	{
		get
		{
			return fieldValue;
		}
		set
		{
			fieldValue = value;
			Invalidate();
		}
	}

	public event ValueChangedEventHandler ValueChanged
	{
		[CompilerGenerated]
		add
		{
			ValueChangedEventHandler valueChangedEventHandler = m_MockValue;
			ValueChangedEventHandler valueChangedEventHandler2;
			do
			{
				valueChangedEventHandler2 = valueChangedEventHandler;
				ValueChangedEventHandler value2 = (ValueChangedEventHandler)Delegate.Combine(valueChangedEventHandler2, value);
				valueChangedEventHandler = Interlocked.CompareExchange(ref m_MockValue, value2, valueChangedEventHandler2);
			}
			while ((object)valueChangedEventHandler != valueChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ValueChangedEventHandler valueChangedEventHandler = m_MockValue;
			ValueChangedEventHandler valueChangedEventHandler2;
			do
			{
				valueChangedEventHandler2 = valueChangedEventHandler;
				ValueChangedEventHandler value2 = (ValueChangedEventHandler)Delegate.Remove(valueChangedEventHandler2, value);
				valueChangedEventHandler = Interlocked.CompareExchange(ref m_MockValue, value2, valueChangedEventHandler2);
			}
			while ((object)valueChangedEventHandler != valueChangedEventHandler2);
		}
	}

	public DarkUIProgressBar()
	{
		_CreatorValue = 100;
		_TemplateValue = 0;
		m_MappingValue = true;
		m_TagValue = true;
		fieldValue = false;
		m_QueueValue = Color.Transparent;
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		DoubleBuffered = true;
		BackColor = Color.Transparent;
		UpdateStyles();
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		GraphicsPath graphicsPath = new GraphicsPath();
		int num = Convert.ToInt32((double)Value / (double)Maximum * (double)base.Width);
		Rectangle rectangle = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
		using (LinearGradientBrush brush = new LinearGradientBrush(rectangle, Color.FromArgb(29, 29, 29), Color.FromArgb(41, 41, 41), 90f))
		{
			graphics.FillPath(brush, HelperMethods.RoundRec(rectangle, 2));
		}
		if (num != 0)
		{
			if (m_QueueValue == Color.Transparent)
			{
				using LinearGradientBrush brush2 = new LinearGradientBrush(new Rectangle(rectangle.X, rectangle.Y, num - 1, rectangle.Height), Color.FromArgb(48, 48, 48), Color.FromArgb(64, 64, 64), 270f);
				using Pen pen2 = new Pen(Color.FromArgb(20, Color.White));
				graphics.FillPath(brush2, HelperMethods.RoundRec(new Rectangle(rectangle.X, rectangle.Y, num - 1, rectangle.Height), 2));
				using (Pen pen = new Pen(Color.FromArgb(50, 50, 50), 20f))
				{
					if (ShowProgressLines)
					{
						graphics.SmoothingMode = SmoothingMode.AntiAlias;
						int num2 = Convert.ToInt32((double)(base.Width - 20) * ((double)Value / (double)Maximum));
						for (int i = 9; i <= num2; i += 45)
						{
							graphics.DrawLine(pen, new Point(i, Convert.ToInt32(base.Height / 2 - base.Height)), new Point(i - base.Height, Convert.ToInt32(base.Height / 2 + base.Height)));
						}
					}
				}
				graphics.DrawLine(pen2, rectangle.X, 1, num - 2, 1);
			}
			else
			{
				using SolidBrush brush3 = new SolidBrush(m_QueueValue);
				graphics.FillPath(brush3, HelperMethods.RoundRec(new Rectangle(rectangle.X, rectangle.Y, num - 1, rectangle.Height), 2));
			}
		}
		using (SolidBrush brush4 = new SolidBrush(ForeColor))
		{
			if (ShowProgressValue)
			{
				graphics.DrawString(Conversions.ToString(Value) + "%", Font, brush4, new Rectangle(0, 1, base.Width, base.Height), HelperMethods.SetPosition());
			}
			if (ShowText && !string.IsNullOrEmpty(Text))
			{
				graphics.DrawString(Text, Font, brush4, new Rectangle(0, 1, base.Width, base.Height), HelperMethods.SetPosition(StringAlignment.Near));
			}
		}
		using (Pen pen3 = new Pen(Color.FromArgb(22, 22, 22)))
		{
			graphics.DrawPath(pen3, HelperMethods.RoundRec(rectangle, 2));
		}
		graphicsPath.Dispose();
	}
}
