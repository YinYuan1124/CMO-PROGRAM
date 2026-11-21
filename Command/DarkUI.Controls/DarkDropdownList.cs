using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Command.Lists;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkDropdownList : Control
{
	[CompilerGenerated]
	private EventHandler _RecordParameter;

	private DarkControlState exceptionParameter;

	private ObservableCollection<DarkDropdownItem> _AttrParameter = new ObservableCollection<DarkDropdownItem>();

	private DarkDropdownItem visitorParameter;

	private DarkContextMenu m_ExporterParameter = new DarkContextMenu();

	private bool m_PrototypeParameter;

	private bool comparatorParameter = true;

	private int itemParameter = 22;

	private int m_SetterParameter = 130;

	private readonly int _CreatorParameter = 16;

	private ToolStripDropDownDirection m_TemplateParameter = ToolStripDropDownDirection.Default;

	private bool _MappingParameter = true;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public ObservableCollection<DarkDropdownItem> Items => _AttrParameter;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DarkDropdownItem SelectedItem
	{
		get
		{
			return visitorParameter;
		}
		set
		{
			visitorParameter = value;
			_RecordParameter?.Invoke(this, new EventArgs());
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int SelectedIndex
	{
		get
		{
			return Items.IndexOf(visitorParameter);
		}
		set
		{
			visitorParameter = Items[value];
			_RecordParameter?.Invoke(this, new EventArgs());
		}
	}

	[Description("Determines whether a border is drawn around the control.")]
	[DefaultValue(true)]
	[Category("Appearance")]
	public bool ShowBorder
	{
		get
		{
			return comparatorParameter;
		}
		set
		{
			comparatorParameter = value;
			Invalidate();
		}
	}

	protected override Size DefaultSize => new Size(100, 26);

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public DarkControlState ControlState => exceptionParameter;

	[Category("Appearance")]
	[DefaultValue(22)]
	[Description("Determines the height of the individual list view items.")]
	public int ItemHeight
	{
		get
		{
			return itemParameter;
		}
		set
		{
			itemParameter = value;
			ResizeMenu(bool_0: true, bool_1: true);
		}
	}

	[Category("Appearance")]
	[Description("Determines the maximum height of the dropdown panel.")]
	[DefaultValue(130)]
	public int MaxHeight
	{
		get
		{
			return m_SetterParameter;
		}
		set
		{
			m_SetterParameter = value;
			ResizeMenu(bool_0: true, bool_1: true);
		}
	}

	[Category("Behavior")]
	[Description("Determines what location the dropdown list appears.")]
	[DefaultValue(ToolStripDropDownDirection.Default)]
	public ToolStripDropDownDirection DropdownDirection
	{
		get
		{
			return m_TemplateParameter;
		}
		set
		{
			m_TemplateParameter = value;
		}
	}

	[Description("Auto-resize menu after each item addition/removal (can be slow with lots of items)")]
	[Category("Behavior")]
	[DefaultValue(true)]
	public bool AutoResizeOnItemChange
	{
		get
		{
			return _MappingParameter;
		}
		set
		{
			_MappingParameter = value;
		}
	}

	public event EventHandler SelectedItemChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = _RecordParameter;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _RecordParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = _RecordParameter;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _RecordParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public DarkDropdownList()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.OptimizedDoubleBuffer, value: true);
		m_ExporterParameter.AutoSize = false;
		m_ExporterParameter.Closed += CollectConfig;
		Items.CollectionChanged += RateConfig;
		SelectedItemChanged += ForgotConfig;
		SortConfig(DarkControlState.Normal);
	}

	private ToolStripMenuItem MapConfig(DarkDropdownItem darkDropdownItem_0)
	{
		foreach (ToolStripMenuItem item in m_ExporterParameter.Items)
		{
			if ((DarkDropdownItem)item.Tag == darkDropdownItem_0)
			{
				return item;
			}
		}
		return null;
	}

	private void SortConfig(DarkControlState darkControlState_0)
	{
		if (!m_PrototypeParameter && exceptionParameter != darkControlState_0)
		{
			exceptionParameter = darkControlState_0;
			Invalidate();
		}
	}

	private void CalcConfig()
	{
		if (!m_ExporterParameter.Visible)
		{
			SortConfig(DarkControlState.Pressed);
			m_PrototypeParameter = true;
			Point position = new Point(0, base.ClientRectangle.Bottom);
			if (m_TemplateParameter == ToolStripDropDownDirection.AboveLeft || m_TemplateParameter == ToolStripDropDownDirection.AboveRight)
			{
				position.Y = 0;
			}
			m_ExporterParameter.Show(this, position, m_TemplateParameter);
			if (SelectedItem != null)
			{
				MapConfig(SelectedItem).Select();
			}
		}
	}

	public void PopulateSelections(string[] string_0)
	{
		Items.Clear();
		int num = 0;
		foreach (string text in string_0)
		{
			DarkDropdownItem darkDropdownItem = new DarkDropdownItem();
			darkDropdownItem.Text = text;
			darkDropdownItem.Value = Convert.ToString(num);
			Items.Add(darkDropdownItem);
		}
	}

	public void ResizeMenu(bool bool_0, bool bool_1)
	{
		if (!(bool_0 || bool_1))
		{
			return;
		}
		int num = base.ClientRectangle.Width;
		int num2 = m_ExporterParameter.Items.Count * itemParameter + 4;
		if (num2 > m_SetterParameter)
		{
			num2 = m_SetterParameter;
		}
		if (bool_0)
		{
			foreach (ToolStripMenuItem item in m_ExporterParameter.Items)
			{
				if (!item.AutoSize)
				{
					item.AutoSize = true;
				}
				if (item.Size.Width > num)
				{
					num = item.Size.Width;
				}
				item.AutoSize = false;
			}
		}
		foreach (ToolStripMenuItem item2 in m_ExporterParameter.Items)
		{
			item2.Size = new Size(num - 1, itemParameter);
		}
		if (bool_0 && bool_1)
		{
			m_ExporterParameter.Size = new Size(num, num2);
		}
		else if (!bool_0 && bool_1)
		{
			m_ExporterParameter.Size = new Size(m_ExporterParameter.Size.Width, num2);
		}
		else if (bool_0 && !bool_1)
		{
			m_ExporterParameter.Size = new Size(num, m_ExporterParameter.Size.Height);
		}
	}

	private void RateConfig(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Add)
		{
			foreach (DarkDropdownItem newItem in e.NewItems)
			{
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(newItem.Text)
				{
					Image = newItem.Icon,
					AutoSize = false,
					Height = itemParameter,
					Font = Font,
					Tag = newItem,
					TextAlign = ContentAlignment.MiddleLeft
				};
				m_ExporterParameter.Items.Add(toolStripMenuItem);
				toolStripMenuItem.Click += FlushConfig;
				if (SelectedItem == null)
				{
					SelectedItem = newItem;
				}
			}
		}
		if (e.Action == NotifyCollectionChangedAction.Remove)
		{
			foreach (DarkDropdownItem oldItem in e.OldItems)
			{
				foreach (ToolStripMenuItem item in m_ExporterParameter.Items)
				{
					if ((DarkDropdownItem)item.Tag == oldItem)
					{
						m_ExporterParameter.Items.Remove(item);
					}
				}
			}
		}
		if (_MappingParameter)
		{
			ResizeMenu(bool_0: true, bool_1: true);
		}
	}

	private void FlushConfig(object sender, EventArgs e)
	{
		if (sender is ToolStripMenuItem toolStripMenuItem)
		{
			DarkDropdownItem darkDropdownItem = (DarkDropdownItem)toolStripMenuItem.Tag;
			if (visitorParameter != darkDropdownItem)
			{
				SelectedItem = darkDropdownItem;
			}
		}
	}

	private void ForgotConfig(object sender, EventArgs e)
	{
		foreach (ToolStripMenuItem item in m_ExporterParameter.Items)
		{
			if ((DarkDropdownItem)item.Tag == SelectedItem)
			{
				item.BackColor = Colors.DarkBlueBackground;
				item.Font = new Font(Font, FontStyle.Bold);
			}
			else
			{
				item.BackColor = Colors.GreyBackground;
				item.Font = new Font(Font, FontStyle.Regular);
			}
		}
		Invalidate();
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		ResizeMenu(bool_0: true, bool_1: true);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		if (e.Button == MouseButtons.Left)
		{
			if (base.ClientRectangle.Contains(e.Location))
			{
				SortConfig(DarkControlState.Pressed);
			}
			else
			{
				SortConfig(DarkControlState.Hover);
			}
		}
		else
		{
			SortConfig(DarkControlState.Hover);
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		CalcConfig();
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
		SortConfig(DarkControlState.Normal);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		SortConfig(DarkControlState.Normal);
	}

	protected override void OnMouseCaptureChanged(EventArgs e)
	{
		base.OnMouseCaptureChanged(e);
		Point position = Cursor.Position;
		if (!base.ClientRectangle.Contains(position))
		{
			SortConfig(DarkControlState.Normal);
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
		Point position = Cursor.Position;
		if (base.ClientRectangle.Contains(position))
		{
			SortConfig(DarkControlState.Hover);
		}
		else
		{
			SortConfig(DarkControlState.Normal);
		}
	}

	protected override void OnKeyDown(KeyEventArgs ke)
	{
		base.OnKeyDown(ke);
		if (ke.KeyCode == Keys.Space)
		{
			CalcConfig();
		}
	}

	private void CollectConfig(object sender, ToolStripDropDownClosedEventArgs e)
	{
		m_PrototypeParameter = false;
		if (base.ClientRectangle.Contains(Control.MousePosition))
		{
			SortConfig(DarkControlState.Hover);
		}
		else
		{
			SortConfig(DarkControlState.Normal);
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		using (SolidBrush brush = new SolidBrush(Colors.MediumBackground))
		{
			graphics.FillRectangle(brush, base.ClientRectangle);
		}
		if (ControlState == DarkControlState.Normal && ShowBorder)
		{
			using Pen pen = new Pen(Colors.LightBorder, 1f);
			Rectangle rect = new Rectangle(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width - 1, base.ClientRectangle.Height - 1);
			graphics.DrawRectangle(pen, rect);
		}
		if (ControlState == DarkControlState.Hover)
		{
			using (SolidBrush brush2 = new SolidBrush(Colors.DarkBorder))
			{
				graphics.FillRectangle(brush2, base.ClientRectangle);
			}
			using (SolidBrush brush3 = new SolidBrush(Colors.DarkBackground))
			{
				Rectangle rect2 = new Rectangle(base.ClientRectangle.Right - VisitorObject.small_arrow.Width - 8, base.ClientRectangle.Top, VisitorObject.small_arrow.Width + 8, base.ClientRectangle.Height);
				graphics.FillRectangle(brush3, rect2);
			}
			using Pen pen2 = new Pen(Colors.BlueSelection, 1f);
			Rectangle rect3 = new Rectangle(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width - 1 - VisitorObject.small_arrow.Width - 8, base.ClientRectangle.Height - 1);
			graphics.DrawRectangle(pen2, rect3);
		}
		if (ControlState == DarkControlState.Pressed)
		{
			using (SolidBrush brush4 = new SolidBrush(Colors.DarkBorder))
			{
				graphics.FillRectangle(brush4, base.ClientRectangle);
			}
			using SolidBrush brush5 = new SolidBrush(Colors.BlueSelection);
			Rectangle rect4 = new Rectangle(base.ClientRectangle.Right - VisitorObject.small_arrow.Width - 8, base.ClientRectangle.Top, VisitorObject.small_arrow.Width + 8, base.ClientRectangle.Height);
			graphics.FillRectangle(brush5, rect4);
		}
		using (Bitmap bitmap = VisitorObject.small_arrow)
		{
			graphics.DrawImageUnscaled(bitmap, base.ClientRectangle.Right - bitmap.Width - 4, base.ClientRectangle.Top + base.ClientRectangle.Height / 2 - bitmap.Height / 2);
		}
		if (SelectedItem == null)
		{
			return;
		}
		bool flag;
		if (flag = SelectedItem.Icon != null)
		{
			graphics.DrawImageUnscaled(SelectedItem.Icon, new Point(base.ClientRectangle.Left + 5, base.ClientRectangle.Top + base.ClientRectangle.Height / 2 - _CreatorParameter / 2));
		}
		using SolidBrush brush6 = new SolidBrush(Colors.LightText);
		StringFormat format = new StringFormat
		{
			Alignment = StringAlignment.Near,
			LineAlignment = StringAlignment.Center
		};
		Rectangle rectangle = new Rectangle(base.ClientRectangle.Left + 2, base.ClientRectangle.Top, base.ClientRectangle.Width - 16, base.ClientRectangle.Height);
		if (flag)
		{
			rectangle.X += _CreatorParameter + 7;
			rectangle.Width -= _CreatorParameter + 7;
		}
		graphics.DrawString(SelectedItem.Text, Font, brush6, rectangle, format);
	}
}
