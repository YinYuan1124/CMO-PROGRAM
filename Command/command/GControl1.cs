using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace Command;

public sealed class GControl1 : Control
{
	public delegate void ValueChangedEventHandler();

	private int visitorValue;

	private int m_ExporterValue;

	private int prototypeValue;

	private int comparatorValue;

	private int _ItemValue;

	[CompilerGenerated]
	private ValueChangedEventHandler setterValue;

	[Description("Gets or sets the current number of the NumericUpDown.")]
	[Category("Custom")]
	public int Value
	{
		get
		{
			return prototypeValue;
		}
		set
		{
			bool num = value != prototypeValue;
			if ((value <= Maximum) & (value >= Minimum))
			{
				prototypeValue = value;
			}
			if (value > Maximum)
			{
				prototypeValue = Maximum;
			}
			Invalidate();
			if (num)
			{
				setterValue?.Invoke();
			}
		}
	}

	[Category("Custom")]
	[Description("Gets or sets the maximum number of the NumericUpDown.")]
	public int Maximum
	{
		get
		{
			return comparatorValue;
		}
		set
		{
			if (value > Minimum)
			{
				comparatorValue = value;
			}
			if (value > comparatorValue)
			{
				value = comparatorValue;
			}
			Invalidate();
		}
	}

	[Description("Gets or sets the minimum number of the NumericUpDown.")]
	[Category("Custom")]
	public int Minimum
	{
		get
		{
			return _ItemValue;
		}
		set
		{
			if (value < Maximum)
			{
				_ItemValue = value;
			}
			if (value < _ItemValue)
			{
				value = _ItemValue;
			}
			Invalidate();
		}
	}

	public event ValueChangedEventHandler ValueChanged
	{
		[CompilerGenerated]
		add
		{
			ValueChangedEventHandler valueChangedEventHandler = setterValue;
			ValueChangedEventHandler valueChangedEventHandler2;
			do
			{
				valueChangedEventHandler2 = valueChangedEventHandler;
				ValueChangedEventHandler value2 = (ValueChangedEventHandler)Delegate.Combine(valueChangedEventHandler2, value);
				valueChangedEventHandler = Interlocked.CompareExchange(ref setterValue, value2, valueChangedEventHandler2);
			}
			while ((object)valueChangedEventHandler != valueChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ValueChangedEventHandler valueChangedEventHandler = setterValue;
			ValueChangedEventHandler valueChangedEventHandler2;
			do
			{
				valueChangedEventHandler2 = valueChangedEventHandler;
				ValueChangedEventHandler value2 = (ValueChangedEventHandler)Delegate.Remove(valueChangedEventHandler2, value);
				valueChangedEventHandler = Interlocked.CompareExchange(ref setterValue, value2, valueChangedEventHandler2);
			}
			while ((object)valueChangedEventHandler != valueChangedEventHandler2);
		}
	}

	public GControl1()
	{
		visitorValue = 0;
		m_ExporterValue = 0;
		prototypeValue = 0;
		comparatorValue = 100;
		_ItemValue = 0;
		SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		DoubleBuffered = true;
		UpdateStyles();
		BackColor = Color.Transparent;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		Rectangle rect = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
		using (SolidBrush brush = new SolidBrush(Color.FromArgb(31, 31, 31)))
		{
			using LinearGradientBrush brush2 = new LinearGradientBrush(rect, Color.FromArgb(48, 48, 48), Color.FromArgb(64, 64, 64), 270f);
			using Pen pen = new Pen(Color.FromArgb(22, 22, 22));
			using Pen pen2 = new Pen(Color.FromArgb(20, Color.White));
			graphics.FillRectangle(brush, rect);
			graphics.FillPath(brush2, HelperMethods.RoundRec(new Rectangle(base.Width - 25, 0, 24, base.Height - 1), 2));
			graphics.DrawLine(pen, new Point(base.Width - 25, 1), new Point(base.Width - 25, base.Height - 2));
			graphics.DrawLine(pen, new Point(base.Width - 25, 13), new Point(base.Width - 1, 13));
			graphics.DrawLine(pen2, base.Width - 24, 1, base.Width - 24 + base.Width, 1);
		}
		graphics.SmoothingMode = SmoothingMode.AntiAlias;
		using (GraphicsPath graphicsPath = new GraphicsPath())
		{
			using SolidBrush brush3 = new SolidBrush((Value == Maximum) ? Color.FromArgb(22, 22, 22) : Color.FromArgb(192, 192, 192));
			graphicsPath.AddLine(base.Width - 17, 9, base.Width - 2, 9);
			graphicsPath.AddLine(base.Width - 9, 9, base.Width - 13, 4);
			graphicsPath.CloseFigure();
			graphics.FillPath(brush3, graphicsPath);
		}
		using (GraphicsPath graphicsPath2 = new GraphicsPath())
		{
			using SolidBrush brush4 = new SolidBrush((Value <= Minimum) ? Color.FromArgb(22, 22, 22) : Color.FromArgb(192, 192, 192));
			graphicsPath2.AddLine(base.Width - 17, 17, base.Width - 2, 17);
			graphicsPath2.AddLine(base.Width - 9, 17, base.Width - 13, 22);
			graphicsPath2.CloseFigure();
			graphics.FillPath(brush4, graphicsPath2);
		}
		graphics.SmoothingMode = SmoothingMode.Default;
		using (SolidBrush brush5 = new SolidBrush(Color.FromArgb(207, 207, 207)))
		{
			graphics.DrawString(Value.ToString(), Font, brush5, new Rectangle(0, 0, base.Width - 18, base.Height), HelperMethods.SetPosition());
		}
		using Pen pen3 = new Pen(Color.FromArgb(22, 22, 22));
		graphics.DrawRectangle(pen3, rect);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		visitorValue = e.Location.X;
		m_ExporterValue = e.Location.Y;
		Invalidate();
		if (e.X < base.Width - 25)
		{
			Cursor = Cursors.IBeam;
		}
		else
		{
			Cursor = Cursors.Hand;
		}
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		base.Height = 26;
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		OnMouseClick(e);
		if (visitorValue > base.Width - 17 && visitorValue < base.Width - 3)
		{
			if (m_ExporterValue < 13)
			{
				if (Value + 1 <= Maximum)
				{
					Value++;
				}
			}
			else if (Value - 1 >= Minimum)
			{
				Value--;
			}
		}
		Invalidate();
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		switch (keyData)
		{
		default:
			return base.ProcessCmdKey(ref m, keyData);
		case Keys.Back:
		case Keys.Up:
			if (Value + 1 <= Maximum)
			{
				Value++;
			}
			Invalidate();
			return true;
		case Keys.Next:
		case Keys.Down:
			if (Value - 1 >= Minimum)
			{
				Value--;
			}
			Invalidate();
			return true;
		}
	}
}
