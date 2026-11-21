using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public abstract class DarkScrollBase : Control
{
	public readonly DarkScrollBar _vScrollBar;

	public readonly DarkScrollBar _hScrollBar;

	private Size m_ConnectionExpression;

	private Size m_ContextExpression;

	private Rectangle m_StatusExpression;

	private Point proccesorExpression;

	private int _StrategyExpression;

	private System.Windows.Forms.Timer _ConfigurationExpression;

	private int _TokenExpression = 20;

	private bool indexerExpression = true;

	private bool _PublisherExpression;

	[CompilerGenerated]
	private EventHandler _AdapterExpression;

	[CompilerGenerated]
	private EventHandler _SchemaExpression;

	[Category("Behavior")]
	[Description("Set to true to make sure key events aren't spread to the rest of the form ")]
	[DefaultValue(false)]
	public bool HandlesEvents { get; set; }

	[Description("How many PIXELS one step of the mousewheel will increment/decrement the scrollview")]
	[Category("Behavior")]
	[DefaultValue(20)]
	public int MouseWheelStep
	{
		get
		{
			return _TokenExpression;
		}
		set
		{
			_TokenExpression = value;
			Invalidate();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public Rectangle Viewport
	{
		get
		{
			return m_StatusExpression;
		}
		private set
		{
			m_StatusExpression = value;
			if (_AdapterExpression != null)
			{
				_AdapterExpression(this, null);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public Size ContentSize
	{
		get
		{
			return m_ContextExpression;
		}
		set
		{
			_PublisherExpression = value.Width != m_ContextExpression.Width || value.Height != m_ContextExpression.Height;
			m_ContextExpression = value;
			if (_PublisherExpression)
			{
				InsertRegistry();
			}
			if (_SchemaExpression != null)
			{
				_SchemaExpression(this, null);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public Point OffsetMousePosition => proccesorExpression;

	[Category("Behavior")]
	[Description("Determines the maximum scroll change when dragging.")]
	[DefaultValue(0)]
	public int MaxDragChange
	{
		get
		{
			return _StrategyExpression;
		}
		set
		{
			_StrategyExpression = value;
			Invalidate();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public bool IsDragging { get; private set; }

	[DefaultValue(true)]
	[Category("Behavior")]
	[Description("Determines whether scrollbars will remain visible when disabled.")]
	public bool HideScrollBars
	{
		get
		{
			return indexerExpression;
		}
		set
		{
			indexerExpression = value;
			InsertRegistry();
		}
	}

	public event EventHandler ViewportChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = _AdapterExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _AdapterExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = _AdapterExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _AdapterExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler ContentSizeChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = _SchemaExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _SchemaExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = _SchemaExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _SchemaExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	protected DarkScrollBase()
	{
		SetStyle(ControlStyles.Selectable | ControlStyles.UserMouse, value: true);
		_vScrollBar = new DarkScrollBar
		{
			ScrollOrientation = DarkScrollOrientation.Vertical
		};
		_hScrollBar = new DarkScrollBar
		{
			ScrollOrientation = DarkScrollOrientation.Horizontal
		};
		base.Controls.Add(_vScrollBar);
		base.Controls.Add(_hScrollBar);
		_vScrollBar.ValueChanged += delegate
		{
			VisitRegistry();
		};
		_hScrollBar.ValueChanged += delegate
		{
			VisitRegistry();
		};
		_vScrollBar.MouseDown += delegate
		{
			Select();
		};
		_hScrollBar.MouseDown += delegate
		{
			Select();
		};
		_ConfigurationExpression = new System.Windows.Forms.Timer();
		_ConfigurationExpression.Interval = 1;
		_ConfigurationExpression.Tick += RestartRegistry;
	}

	private void InsertRegistry()
	{
		if (_vScrollBar.Maximum != ContentSize.Height)
		{
			_vScrollBar.Maximum = ContentSize.Height;
		}
		if (_hScrollBar.Maximum != ContentSize.Width)
		{
			_hScrollBar.Maximum = ContentSize.Width;
		}
		int scrollBarSize = Consts.ScrollBarSize;
		_vScrollBar.Location = new Point(base.ClientSize.Width - scrollBarSize, 0);
		_vScrollBar.Size = new Size(scrollBarSize, base.ClientSize.Height);
		_hScrollBar.Location = new Point(0, base.ClientSize.Height - scrollBarSize);
		_hScrollBar.Size = new Size(base.ClientSize.Width, scrollBarSize);
		if (!base.DesignMode)
		{
			ReflectRegistry();
			PrepareRegistry();
			ReflectRegistry();
			PrepareRegistry();
			if (_vScrollBar.Visible)
			{
				_hScrollBar.Width -= scrollBarSize;
			}
			if (_hScrollBar.Visible)
			{
				_vScrollBar.Height -= scrollBarSize;
			}
			_vScrollBar.ViewSize = m_ConnectionExpression.Height;
			_hScrollBar.ViewSize = m_ConnectionExpression.Width;
			VisitRegistry();
		}
	}

	private void PrepareRegistry()
	{
		bool flag = m_ConnectionExpression.Height < ContentSize.Height;
		bool flag2 = m_ConnectionExpression.Width < ContentSize.Width;
		if (_vScrollBar.Enabled != flag)
		{
			_vScrollBar.Enabled = flag;
		}
		if (_hScrollBar.Enabled != flag2)
		{
			_hScrollBar.Enabled = flag2;
		}
		if (indexerExpression)
		{
			_vScrollBar.Visible = _vScrollBar.Enabled;
			_hScrollBar.Visible = _hScrollBar.Enabled;
		}
	}

	private void ReflectRegistry()
	{
		int scrollBarSize = Consts.ScrollBarSize;
		m_ConnectionExpression = new Size(base.ClientSize.Width, base.ClientSize.Height);
		if (_vScrollBar.Visible)
		{
			m_ConnectionExpression.Width -= scrollBarSize;
		}
		if (_hScrollBar.Visible)
		{
			m_ConnectionExpression.Height -= scrollBarSize;
		}
	}

	private void VisitRegistry()
	{
		if (!base.IsDisposed)
		{
			int num = 0;
			int num2 = 0;
			int num3 = base.ClientSize.Width;
			int num4 = base.ClientSize.Height;
			if (_hScrollBar.Visible)
			{
				num = _hScrollBar.Value;
				num4 -= _hScrollBar.Height;
			}
			if (_vScrollBar.Visible)
			{
				num2 = _vScrollBar.Value;
				num3 -= _vScrollBar.Width;
			}
			Viewport = new Rectangle(num, num2, num3, num4);
			Point point = PointToClient(Control.MousePosition);
			proccesorExpression = new Point(point.X + Viewport.Left, point.Y + Viewport.Top);
			Invalidate();
		}
	}

	public void ScrollTo(Point point_0)
	{
		method_1(point_0.X);
		method_0(point_0.Y);
	}

	public void method_0(int int_0, bool bool_0 = false)
	{
		if (_vScrollBar.Visible || bool_0)
		{
			_vScrollBar.Value = int_0;
		}
	}

	public void method_1(int int_0)
	{
		if (_hScrollBar.Visible)
		{
			_hScrollBar.Value = int_0;
		}
	}

	protected virtual void StartDrag()
	{
		IsDragging = true;
		_ConfigurationExpression.Start();
	}

	protected virtual void StopDrag()
	{
		IsDragging = false;
		_ConfigurationExpression.Stop();
	}

	public Point PointToView(Point point_0)
	{
		return new Point(point_0.X - Viewport.Left, point_0.Y - Viewport.Top);
	}

	public Rectangle RectangleToView(Rectangle rectangle_0)
	{
		return new Rectangle(new Point(rectangle_0.Left - Viewport.Left, rectangle_0.Top - Viewport.Top), rectangle_0.Size);
	}

	protected override void OnCreateControl()
	{
		base.OnCreateControl();
		InsertRegistry();
	}

	protected override void OnGotFocus(EventArgs e)
	{
		base.OnGotFocus(e);
		Invalidate();
	}

	protected override void OnLostFocus(EventArgs e)
	{
		base.OnLostFocus(e);
		Invalidate();
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		InsertRegistry();
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		proccesorExpression = new Point(e.X + Viewport.Left, e.Y + Viewport.Top);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (e.Button == MouseButtons.Right)
		{
			Select();
		}
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		base.OnMouseWheel(e);
		bool flag = false;
		if (_hScrollBar.Visible && Control.ModifierKeys == Keys.Control)
		{
			flag = true;
		}
		if (_hScrollBar.Visible && !_vScrollBar.Visible)
		{
			flag = true;
		}
		if (flag)
		{
			if (e.Delta <= 0)
			{
				if (e.Delta < 0)
				{
					_hScrollBar.ScrollByPhysical(-MouseWheelStep);
				}
			}
			else
			{
				_hScrollBar.ScrollByPhysical(MouseWheelStep);
			}
		}
		else if (e.Delta <= 0)
		{
			if (e.Delta < 0)
			{
				_vScrollBar.ScrollByPhysical(-MouseWheelStep);
			}
		}
		else
		{
			_vScrollBar.ScrollByPhysical(MouseWheelStep);
		}
	}

	protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
	{
		base.OnPreviewKeyDown(e);
		switch (e.KeyCode)
		{
		case Keys.Next:
			method_0(_vScrollBar.Value + m_ConnectionExpression.Height);
			e.IsInputKey = true;
			break;
		case Keys.End:
			method_0(m_ContextExpression.Height);
			e.IsInputKey = true;
			break;
		case Keys.Home:
			method_0(0);
			e.IsInputKey = true;
			break;
		case Keys.Right:
			break;
		case Keys.Prior:
		case Keys.Left:
		case Keys.Up:
		case Keys.Down:
			method_0(_vScrollBar.Value - m_ConnectionExpression.Height);
			e.IsInputKey = true;
			break;
		}
	}

	private void RestartRegistry(object sender, EventArgs e)
	{
		Point point = PointToClient(Control.MousePosition);
		int num = base.ClientRectangle.Right;
		int num2 = base.ClientRectangle.Bottom;
		if (_vScrollBar.Visible)
		{
			num = _vScrollBar.Left;
		}
		if (_hScrollBar.Visible)
		{
			num2 = _hScrollBar.Top;
		}
		if (_vScrollBar.Visible)
		{
			if (point.Y < base.ClientRectangle.Top)
			{
				int num3 = (point.Y - base.ClientRectangle.Top) * -1;
				if (MaxDragChange > 0 && num3 > MaxDragChange)
				{
					num3 = MaxDragChange;
				}
				_vScrollBar.Value -= num3;
			}
			if (point.Y > num2)
			{
				int num4 = point.Y - num2;
				if (MaxDragChange > 0 && num4 > MaxDragChange)
				{
					num4 = MaxDragChange;
				}
				_vScrollBar.Value += num4;
			}
		}
		if (!_hScrollBar.Visible)
		{
			return;
		}
		if (point.X < base.ClientRectangle.Left)
		{
			int num5 = (point.X - base.ClientRectangle.Left) * -1;
			if (MaxDragChange > 0 && num5 > MaxDragChange)
			{
				num5 = MaxDragChange;
			}
			_hScrollBar.Value -= num5;
		}
		if (point.X > num)
		{
			int num6 = point.X - num;
			if (MaxDragChange > 0 && num6 > MaxDragChange)
			{
				num6 = MaxDragChange;
			}
			_hScrollBar.Value += num6;
		}
	}

	[CompilerGenerated]
	private void TestRegistry(object sender, ScrollValueEventArgs e)
	{
		VisitRegistry();
	}

	[CompilerGenerated]
	private void StopRegistry(object sender, ScrollValueEventArgs e)
	{
		VisitRegistry();
	}

	[CompilerGenerated]
	private void CancelRegistry(object sender, MouseEventArgs e)
	{
		Select();
	}

	[CompilerGenerated]
	private void VerifyRegistry(object sender, MouseEventArgs e)
	{
		Select();
	}
}
