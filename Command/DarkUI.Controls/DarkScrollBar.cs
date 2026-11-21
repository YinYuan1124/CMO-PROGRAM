using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Command.Mocks;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkScrollBar : Control
{
	private DarkScrollOrientation _StubExpression;

	private int m_WriterExpression;

	private int specificationExpression;

	private int m_WatcherExpression = 100;

	private int m_ReponseExpression;

	private Rectangle m_DescriptorExpression;

	private float poolExpression;

	private Rectangle taskExpression;

	private Rectangle m_FilterExpression;

	private Rectangle _TestsExpression;

	private bool _InterpreterExpression;

	private bool containerExpression;

	private bool m_ComposerExpression;

	private bool _ModelExpression;

	private bool m_AdvisorExpression;

	private bool _CustomerExpression;

	private bool m_SerializerExpression;

	private int m_RefExpression;

	private Point m_ErrorExpression;

	private Timer _CodeExpression;

	[Description("The orientation type of the scrollbar.")]
	[DefaultValue(DarkScrollOrientation.Vertical)]
	[Category("Behavior")]
	public DarkScrollOrientation ScrollOrientation
	{
		get
		{
			return _StubExpression;
		}
		set
		{
			_StubExpression = value;
			UpdateScrollBar();
		}
	}

	[Category("Behavior")]
	[Description("The value that the scroll thumb position represents.")]
	[DefaultValue(0)]
	public int Value
	{
		get
		{
			return m_WriterExpression;
		}
		set
		{
			if (value < Minimum)
			{
				value = Minimum;
			}
			int num = Maximum - ViewSize;
			if (value > num)
			{
				value = num;
			}
			if (m_WriterExpression != value)
			{
				m_WriterExpression = value;
				UpdateRegistry(bool_0: true);
				if (this.ValueChanged != null)
				{
					this.ValueChanged(this, new ScrollValueEventArgs(Value));
				}
			}
		}
	}

	[Category("Behavior")]
	[DefaultValue(0)]
	[Description("The lower limit value of the scrollable range.")]
	public int Minimum
	{
		get
		{
			return specificationExpression;
		}
		set
		{
			specificationExpression = value;
			UpdateScrollBar();
		}
	}

	[DefaultValue(100)]
	[Category("Behavior")]
	[Description("The upper limit value of the scrollable range.")]
	public int Maximum
	{
		get
		{
			return m_WatcherExpression;
		}
		set
		{
			m_WatcherExpression = value;
			UpdateScrollBar();
		}
	}

	[Description("The view size for the scrollable area.")]
	[DefaultValue(0)]
	[Category("Behavior")]
	public int ViewSize
	{
		get
		{
			return m_ReponseExpression;
		}
		set
		{
			m_ReponseExpression = value;
			UpdateScrollBar();
		}
	}

	public new bool Visible
	{
		get
		{
			return base.Visible;
		}
		set
		{
			if (base.Visible != value)
			{
				base.Visible = value;
			}
		}
	}

	public event EventHandler<ScrollValueEventArgs> ValueChanged;

	public DarkScrollBar()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, value: true);
		SetStyle(ControlStyles.Selectable, value: false);
		_CodeExpression = new Timer();
		_CodeExpression.Interval = 1;
		_CodeExpression.Tick += DisableRegistry;
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		UpdateScrollBar();
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (taskExpression.Contains(e.Location) && e.Button == MouseButtons.Left)
		{
			m_SerializerExpression = true;
			m_ErrorExpression = e.Location;
			if (_StubExpression == DarkScrollOrientation.Vertical)
			{
				m_RefExpression = taskExpression.Top;
			}
			else
			{
				m_RefExpression = taskExpression.Left;
			}
			Invalidate();
		}
		else if (m_FilterExpression.Contains(e.Location) && e.Button == MouseButtons.Left)
		{
			m_AdvisorExpression = true;
			_CodeExpression.Enabled = true;
			Invalidate();
		}
		else if (_TestsExpression.Contains(e.Location) && e.Button == MouseButtons.Left)
		{
			_CustomerExpression = true;
			_CodeExpression.Enabled = true;
			Invalidate();
		}
		else
		{
			if (!m_DescriptorExpression.Contains(e.Location) || e.Button != MouseButtons.Left)
			{
				return;
			}
			if (_StubExpression == DarkScrollOrientation.Vertical)
			{
				if (!new Rectangle(taskExpression.Left, m_DescriptorExpression.Top, taskExpression.Width, m_DescriptorExpression.Height).Contains(e.Location))
				{
					return;
				}
			}
			else if (_StubExpression == DarkScrollOrientation.Horizontal && !new Rectangle(m_DescriptorExpression.Left, taskExpression.Top, m_DescriptorExpression.Width, taskExpression.Height).Contains(e.Location))
			{
				return;
			}
			if (_StubExpression == DarkScrollOrientation.Vertical)
			{
				int num = e.Location.Y;
				num -= m_FilterExpression.Bottom - 1;
				num -= taskExpression.Height / 2;
				ScrollToPhysical(num);
			}
			else
			{
				int num2 = e.Location.X;
				num2 -= m_FilterExpression.Right - 1;
				num2 -= taskExpression.Width / 2;
				ScrollToPhysical(num2);
			}
			m_SerializerExpression = true;
			m_ErrorExpression = e.Location;
			_InterpreterExpression = true;
			if (_StubExpression == DarkScrollOrientation.Vertical)
			{
				m_RefExpression = taskExpression.Top;
			}
			else
			{
				m_RefExpression = taskExpression.Left;
			}
			Invalidate();
		}
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
		m_SerializerExpression = false;
		_ModelExpression = false;
		m_AdvisorExpression = false;
		_CustomerExpression = false;
		Invalidate();
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		if (!m_SerializerExpression)
		{
			bool flag = taskExpression.Contains(e.Location);
			if (_InterpreterExpression != flag)
			{
				_InterpreterExpression = flag;
				Invalidate();
			}
			bool flag2 = m_FilterExpression.Contains(e.Location);
			if (containerExpression != flag2)
			{
				containerExpression = flag2;
				Invalidate();
			}
			bool flag3 = _TestsExpression.Contains(e.Location);
			if (m_ComposerExpression != flag3)
			{
				m_ComposerExpression = flag3;
				Invalidate();
			}
		}
		if (!m_SerializerExpression)
		{
			return;
		}
		if (e.Button == MouseButtons.Left)
		{
			Point point = new Point(e.Location.X - m_ErrorExpression.X, e.Location.Y - m_ErrorExpression.Y);
			if (_StubExpression == DarkScrollOrientation.Vertical)
			{
				int int_ = m_RefExpression - m_DescriptorExpression.Top + point.Y;
				ScrollToPhysical(int_);
			}
			else if (_StubExpression == DarkScrollOrientation.Horizontal)
			{
				int int_2 = m_RefExpression - m_DescriptorExpression.Left + point.X;
				ScrollToPhysical(int_2);
			}
			UpdateScrollBar();
		}
		else
		{
			OnMouseUp(null);
		}
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		_InterpreterExpression = false;
		containerExpression = false;
		m_ComposerExpression = false;
		Invalidate();
	}

	private void DisableRegistry(object sender, EventArgs e)
	{
		if (!m_AdvisorExpression && !_CustomerExpression)
		{
			_CodeExpression.Enabled = false;
		}
		else if (m_AdvisorExpression)
		{
			ScrollBy(-1);
		}
		else if (_CustomerExpression)
		{
			ScrollBy(1);
		}
	}

	public void ScrollTo(int int_0)
	{
		Value = int_0;
	}

	public void ScrollToPhysical(int int_0)
	{
		int num = ((_StubExpression == DarkScrollOrientation.Vertical) ? (m_DescriptorExpression.Height - taskExpression.Height) : (m_DescriptorExpression.Width - taskExpression.Width));
		float num2 = (float)int_0 / (float)num;
		int num3 = Maximum - ViewSize;
		Value = (int)(num2 * (float)num3);
	}

	public void ScrollBy(int int_0)
	{
		int int_ = Value + int_0;
		ScrollTo(int_);
	}

	public void ScrollByPhysical(int int_0)
	{
		int int_ = ((_StubExpression == DarkScrollOrientation.Vertical) ? (taskExpression.Top - m_DescriptorExpression.Top) : (taskExpression.Left - m_DescriptorExpression.Left)) - int_0;
		ScrollToPhysical(int_);
	}

	public void UpdateScrollBar()
	{
		Rectangle clientRectangle = base.ClientRectangle;
		if (_StubExpression == DarkScrollOrientation.Vertical)
		{
			m_FilterExpression = new Rectangle(clientRectangle.Left, clientRectangle.Top, Consts.ArrowButtonSize, Consts.ArrowButtonSize);
			_TestsExpression = new Rectangle(clientRectangle.Left, clientRectangle.Bottom - Consts.ArrowButtonSize, Consts.ArrowButtonSize, Consts.ArrowButtonSize);
		}
		else if (_StubExpression == DarkScrollOrientation.Horizontal)
		{
			m_FilterExpression = new Rectangle(clientRectangle.Left, clientRectangle.Top, Consts.ArrowButtonSize, Consts.ArrowButtonSize);
			_TestsExpression = new Rectangle(clientRectangle.Right - Consts.ArrowButtonSize, clientRectangle.Top, Consts.ArrowButtonSize, Consts.ArrowButtonSize);
		}
		if (_StubExpression == DarkScrollOrientation.Vertical)
		{
			m_DescriptorExpression = new Rectangle(clientRectangle.Left, clientRectangle.Top + Consts.ArrowButtonSize, clientRectangle.Width, clientRectangle.Height - Consts.ArrowButtonSize * 2);
		}
		else if (_StubExpression == DarkScrollOrientation.Horizontal)
		{
			m_DescriptorExpression = new Rectangle(clientRectangle.Left + Consts.ArrowButtonSize, clientRectangle.Top, clientRectangle.Width - Consts.ArrowButtonSize * 2, clientRectangle.Height);
		}
		UpdateRegistry();
		Invalidate();
	}

	private void UpdateRegistry(bool bool_0 = false)
	{
		if (ViewSize >= Maximum)
		{
			return;
		}
		int num = Maximum - ViewSize;
		if (Value > num)
		{
			Value = num;
		}
		poolExpression = (float)ViewSize / (float)Maximum;
		int num2 = Maximum - ViewSize;
		float num3 = (float)Value / (float)num2;
		if (_StubExpression == DarkScrollOrientation.Vertical)
		{
			int num4 = (int)((float)m_DescriptorExpression.Height * poolExpression);
			if (num4 < Consts.MinimumThumbSize)
			{
				num4 = Consts.MinimumThumbSize;
			}
			int num5 = (int)((float)(m_DescriptorExpression.Height - num4) * num3);
			taskExpression = new Rectangle(m_DescriptorExpression.Left + 3, m_DescriptorExpression.Top + num5, Consts.ScrollBarSize - 6, num4);
		}
		else if (_StubExpression == DarkScrollOrientation.Horizontal)
		{
			int num6 = (int)((float)m_DescriptorExpression.Width * poolExpression);
			if (num6 < Consts.MinimumThumbSize)
			{
				num6 = Consts.MinimumThumbSize;
			}
			int num7 = (int)((float)(m_DescriptorExpression.Width - num6) * num3);
			taskExpression = new Rectangle(m_DescriptorExpression.Left + num7, m_DescriptorExpression.Top + 3, num6, Consts.ScrollBarSize - 6);
		}
		if (bool_0)
		{
			Invalidate();
			Update();
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		Bitmap bitmap = (containerExpression ? ExporterObject.scrollbar_arrow_hot : ExporterObject.scrollbar_arrow_standard);
		if (m_AdvisorExpression)
		{
			bitmap = ExporterObject.scrollbar_arrow_clicked;
		}
		if (!base.Enabled)
		{
			bitmap = ExporterObject.scrollbar_arrow_disabled;
		}
		if (_StubExpression == DarkScrollOrientation.Vertical)
		{
			bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
		}
		else if (_StubExpression == DarkScrollOrientation.Horizontal)
		{
			bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
		}
		graphics.DrawImageUnscaled(bitmap, m_FilterExpression.Left + m_FilterExpression.Width / 2 - bitmap.Width / 2, m_FilterExpression.Top + m_FilterExpression.Height / 2 - bitmap.Height / 2);
		Bitmap bitmap2 = (m_ComposerExpression ? ExporterObject.scrollbar_arrow_hot : ExporterObject.scrollbar_arrow_standard);
		if (_CustomerExpression)
		{
			bitmap2 = ExporterObject.scrollbar_arrow_clicked;
		}
		if (!base.Enabled)
		{
			bitmap2 = ExporterObject.scrollbar_arrow_disabled;
		}
		if (_StubExpression == DarkScrollOrientation.Horizontal)
		{
			bitmap2.RotateFlip(RotateFlipType.Rotate270FlipNone);
		}
		graphics.DrawImageUnscaled(bitmap2, _TestsExpression.Left + _TestsExpression.Width / 2 - bitmap2.Width / 2, _TestsExpression.Top + _TestsExpression.Height / 2 - bitmap2.Height / 2);
		if (base.Enabled)
		{
			Color color = (_InterpreterExpression ? Colors.GreyHighlight : Colors.GreySelection);
			if (m_SerializerExpression)
			{
				color = Colors.ActiveControl;
			}
			using SolidBrush brush = new SolidBrush(color);
			graphics.FillRectangle(brush, taskExpression);
		}
	}
}
