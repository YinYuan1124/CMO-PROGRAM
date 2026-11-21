using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkListView : DarkScrollView
{
	[CompilerGenerated]
	private EventHandler _ClientExpression;

	[CompilerGenerated]
	private EventHandler m_DicExpression;

	private int m_ConsumerExpression = 20;

	private bool _FacadeExpression;

	private readonly int m_ProxyExpression = 16;

	private ObservableCollection<DarkListItem> readerExpression;

	private List<int> _PropertyExpression;

	private int importerExpression = -1;

	private int _RepositoryExpression = -1;

	private bool _BridgeExpression = true;

	public float[] tabStops;

	[CompilerGenerated]
	private bool classExpression;

	[CompilerGenerated]
	private EventHandler _RequestExpression;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ObservableCollection<DarkListItem> Items
	{
		get
		{
			return readerExpression;
		}
		set
		{
			if (readerExpression != null)
			{
				readerExpression.CollectionChanged -= CheckRegistry;
			}
			readerExpression = value;
			readerExpression.CollectionChanged += CheckRegistry;
			FindRegistry();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public List<int> SelectedIndices => _PropertyExpression;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public List<DarkListItem> SelectedItems
	{
		get
		{
			List<DarkListItem> list = new List<DarkListItem>();
			foreach (int selectedIndex in SelectedIndices)
			{
				list.Add(Items[selectedIndex]);
			}
			return list;
		}
	}

	[DefaultValue(20)]
	[Category("Appearance")]
	[Description("Determines the height of the individual list view items.")]
	public int ItemHeight
	{
		get
		{
			return m_ConsumerExpression;
		}
		set
		{
			m_ConsumerExpression = value;
			FindRegistry();
		}
	}

	[Description("Determines whether multiple list view items can be selected at once.")]
	[Category("Behaviour")]
	[DefaultValue(false)]
	public bool MultiSelect
	{
		get
		{
			return _FacadeExpression;
		}
		set
		{
			_FacadeExpression = value;
		}
	}

	[Description("Auto-resize list after each item addition/removal (can be slow with lots of items)")]
	[Category("Behavior")]
	[DefaultValue(true)]
	public bool AutoResizeOnItemChange
	{
		get
		{
			return _BridgeExpression;
		}
		set
		{
			_BridgeExpression = value;
		}
	}

	[Category("Appearance")]
	[Description("Determines whether icons are rendered with the list items.")]
	[DefaultValue(false)]
	public bool ShowIcons
	{
		[CompilerGenerated]
		get
		{
			return classExpression;
		}
		[CompilerGenerated]
		set
		{
			classExpression = value;
		}
	}

	public List<KeyValuePair<string, string>> RelatedInfos { get; set; }

	public event EventHandler SelectedIndicesChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = _ClientExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _ClientExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = _ClientExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _ClientExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler DrawListItem
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = m_DicExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_DicExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = m_DicExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_DicExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler ContextMenuItem_Click
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = _RequestExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _RequestExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = _RequestExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _RequestExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public DarkListView()
	{
		Items = new ObservableCollection<DarkListItem>();
		_PropertyExpression = new List<int>();
	}

	private void CheckRegistry(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (base.IsDisposed)
		{
			return;
		}
		if (e.NewItems != null)
		{
			using (Graphics graphics_ = CreateGraphics())
			{
				foreach (DarkListItem newItem in e.NewItems)
				{
					newItem.TextChanged += ConcatRegistry;
					FillRegistry(newItem, graphics_);
				}
			}
			if (e.NewStartingIndex < Items.Count - 1)
			{
				for (int i = e.NewStartingIndex; i <= Items.Count - 1; i++)
				{
					CalculateRegistry(Items[i], i);
				}
			}
		}
		if (e.OldItems != null)
		{
			foreach (DarkListItem oldItem in e.OldItems)
			{
				oldItem.TextChanged -= ConcatRegistry;
			}
			if (e.OldStartingIndex < Items.Count - 1)
			{
				for (int j = e.OldStartingIndex; j <= Items.Count - 1; j++)
				{
					CalculateRegistry(Items[j], j);
				}
			}
		}
		if (Items.Count == 0 && _PropertyExpression.Count > 0)
		{
			_PropertyExpression.Clear();
			if (_ClientExpression != null)
			{
				_ClientExpression(this, null);
			}
		}
		if (_BridgeExpression)
		{
			UpdateContentSize();
		}
	}

	private void ConcatRegistry(object sender, EventArgs e)
	{
		DarkListItem darkListItem = (DarkListItem)sender;
		SetRegistry(darkListItem);
		PopRegistry(darkListItem);
		Invalidate();
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (Items.Count == 0 || (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right))
		{
			return;
		}
		if (e.Button == MouseButtons.Right && RelatedInfos != null && SelectedItems != null && SelectedItems.Count == 1)
		{
			DarkContextMenu darkContextMenu = new DarkContextMenu();
			foreach (KeyValuePair<string, string> relatedInfo in RelatedInfos)
			{
				bool flag = false;
				if (!(relatedInfo.Key == SelectedItems.First().Tag.ToString()))
				{
					continue;
				}
				foreach (ToolStripMenuItem item in darkContextMenu.Items)
				{
					if (item.Text == relatedInfo.Value)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(relatedInfo.Value);
					toolStripMenuItem.Tag = relatedInfo.Value;
					darkContextMenu.Items.Add(toolStripMenuItem);
					toolStripMenuItem.Click += InterruptRegistry;
				}
			}
			darkContextMenu.Show(this, new Point(e.X, e.Y));
		}
		Point offsetMousePosition = base.OffsetMousePosition;
		List<int> source = InstantiateRegistry().ToList();
		int num = source.Min();
		int num2 = source.Max();
		int num3 = Math.Max(base.ContentSize.Width, base.Viewport.Width);
		for (int i = num; i <= num2; i++)
		{
			if (new Rectangle(0, i * ItemHeight, num3, ItemHeight).Contains(offsetMousePosition))
			{
				if (MultiSelect && Control.ModifierKeys == Keys.Shift)
				{
					RemoveRegistry(i);
				}
				else if (MultiSelect && Control.ModifierKeys == Keys.Control)
				{
					ToggleItem(i);
				}
				else
				{
					SelectItem(i);
				}
			}
		}
	}

	private void InterruptRegistry(object sender, EventArgs e)
	{
		_RequestExpression?.Invoke(sender, e);
	}

	protected override void OnKeyDown(KeyEventArgs ke)
	{
		base.OnKeyDown(ke);
		if (Items.Count == 0)
		{
			return;
		}
		if (MultiSelect && Control.ModifierKeys == Keys.Shift)
		{
			if (ke.KeyCode == Keys.Up)
			{
				if (_RepositoryExpression - 1 >= 0)
				{
					RemoveRegistry(_RepositoryExpression - 1);
					EnsureVisible();
					ke.Handled = base.HandlesEvents;
				}
			}
			else if (ke.KeyCode == Keys.Down && _RepositoryExpression + 1 <= Items.Count - 1)
			{
				RemoveRegistry(_RepositoryExpression + 1);
				ke.Handled = base.HandlesEvents;
			}
		}
		else if (ke.KeyCode == Keys.Up)
		{
			if (_RepositoryExpression - 1 >= 0)
			{
				SelectItem(_RepositoryExpression - 1);
			}
			ke.Handled = base.HandlesEvents;
		}
		else if (ke.KeyCode == Keys.Down)
		{
			if (_RepositoryExpression + 1 <= Items.Count - 1)
			{
				SelectItem(_RepositoryExpression + 1);
			}
			ke.Handled = base.HandlesEvents;
		}
		if (Control.ModifierKeys != Keys.Shift)
		{
			EnsureVisible();
		}
	}

	public int GetItemIndex(DarkListItem darkListItem_0)
	{
		return Items.IndexOf(darkListItem_0);
	}

	public void SelectItem(int int_0, bool bool_0 = true)
	{
		if (int_0 >= 0 && int_0 <= Items.Count - 1)
		{
			_PropertyExpression.Clear();
			_PropertyExpression.Add(int_0);
			if (_ClientExpression != null)
			{
				_ClientExpression(this, null);
			}
			importerExpression = int_0;
			_RepositoryExpression = int_0;
			Invalidate();
		}
		else if (bool_0)
		{
			throw new IndexOutOfRangeException($"Value '{int_0}' is outside of valid range.");
		}
	}

	public void SelectItems(IEnumerable<int> ienumerable_0)
	{
		_PropertyExpression.Clear();
		List<int> list = ienumerable_0.ToList();
		foreach (int item in list)
		{
			if (item >= 0 && item <= Items.Count - 1)
			{
				_PropertyExpression.Add(item);
				continue;
			}
			throw new IndexOutOfRangeException($"Value '{item}' is outside of valid range.");
		}
		if (_ClientExpression != null)
		{
			_ClientExpression(this, null);
		}
		importerExpression = list[list.Count - 1];
		_RepositoryExpression = list[list.Count - 1];
		Invalidate();
	}

	public void ToggleItem(int int_0)
	{
		if (_PropertyExpression.Contains(int_0))
		{
			_PropertyExpression.Remove(int_0);
			if (importerExpression == int_0 && _RepositoryExpression == int_0)
			{
				if (_PropertyExpression.Count <= 0)
				{
					importerExpression = -1;
					_RepositoryExpression = -1;
				}
				else
				{
					importerExpression = _PropertyExpression[0];
					_RepositoryExpression = _PropertyExpression[0];
				}
			}
			if (importerExpression == int_0)
			{
				if (_RepositoryExpression < int_0)
				{
					importerExpression = int_0 - 1;
				}
				else if (_RepositoryExpression <= int_0)
				{
					importerExpression = _RepositoryExpression;
				}
				else
				{
					importerExpression = int_0 + 1;
				}
			}
			if (_RepositoryExpression == int_0)
			{
				if (importerExpression < int_0)
				{
					_RepositoryExpression = int_0 - 1;
				}
				else if (importerExpression <= int_0)
				{
					_RepositoryExpression = importerExpression;
				}
				else
				{
					_RepositoryExpression = int_0 + 1;
				}
			}
		}
		else
		{
			_PropertyExpression.Add(int_0);
			importerExpression = int_0;
			_RepositoryExpression = int_0;
		}
		if (_ClientExpression != null)
		{
			_ClientExpression(this, null);
		}
		Invalidate();
	}

	public void SelectItems(int int_0, int int_1)
	{
		_PropertyExpression.Clear();
		if (int_0 == int_1)
		{
			_PropertyExpression.Add(int_0);
		}
		if (int_0 < int_1)
		{
			for (int i = int_0; i <= int_1; i++)
			{
				_PropertyExpression.Add(i);
			}
		}
		else if (int_0 > int_1)
		{
			for (int num = int_0; num >= int_1; num--)
			{
				_PropertyExpression.Add(num);
			}
		}
		if (_ClientExpression != null)
		{
			_ClientExpression(this, null);
		}
		Invalidate();
	}

	private void RemoveRegistry(int int_0)
	{
		_RepositoryExpression = int_0;
		SelectItems(importerExpression, int_0);
	}

	private void FindRegistry()
	{
		using (Graphics graphics_ = CreateGraphics())
		{
			for (int i = 0; i <= Items.Count - 1; i++)
			{
				DarkListItem darkListItem_ = Items[i];
				FillRegistry(darkListItem_, graphics_);
				CalculateRegistry(darkListItem_, i);
			}
		}
		UpdateContentSize();
	}

	private void SetRegistry(DarkListItem darkListItem_0)
	{
		using Graphics graphics_ = CreateGraphics();
		FillRegistry(darkListItem_0, graphics_);
	}

	private void FillRegistry(DarkListItem darkListItem_0, Graphics graphics_0)
	{
		SizeF sizeF = graphics_0.MeasureString(darkListItem_0.Text, Font);
		sizeF.Width++;
		if (ShowIcons)
		{
			sizeF.Width += m_ProxyExpression + 8;
		}
		darkListItem_0.Area = new Rectangle(darkListItem_0.Area.Left, darkListItem_0.Area.Top, (int)sizeF.Width, darkListItem_0.Area.Height);
	}

	private void CalculateRegistry(DarkListItem darkListItem_0, int int_0)
	{
		darkListItem_0.Area = new Rectangle(2, int_0 * ItemHeight, darkListItem_0.Area.Width, ItemHeight);
	}

	public void UpdateContentSize()
	{
		int num = 0;
		foreach (DarkListItem item in Items)
		{
			if (item.Area.Right + 1 > num)
			{
				num = item.Area.Right + 1;
			}
		}
		int num2 = num;
		int num3 = Items.Count * ItemHeight;
		if (base.ContentSize.Width != num2 || base.ContentSize.Height != num3)
		{
			base.ContentSize = new Size(num2, num3);
			Invalidate();
		}
	}

	private void PopRegistry(DarkListItem darkListItem_0)
	{
		int num = darkListItem_0.Area.Right + 1;
		if (num == base.ContentSize.Width)
		{
			UpdateContentSize();
		}
		else if (num > base.ContentSize.Width)
		{
			base.ContentSize = new Size(num, base.ContentSize.Height);
			Invalidate();
		}
	}

	public void EnsureVisible()
	{
		if (SelectedIndices.Count != 0)
		{
			int num = -1;
			num = (MultiSelect ? (_RepositoryExpression * ItemHeight) : (SelectedIndices[0] * ItemHeight));
			int num2 = num + ItemHeight;
			if (num < base.Viewport.Top)
			{
				method_0(num);
			}
			if (num2 > base.Viewport.Bottom)
			{
				method_0(num2 - base.Viewport.Height);
			}
		}
	}

	private IEnumerable<int> InstantiateRegistry()
	{
		int num = base.Viewport.Top / ItemHeight - 1;
		if (num < 0)
		{
			num = 0;
		}
		int num2 = (base.Viewport.Top + base.Viewport.Height) / ItemHeight + 1;
		if (num2 > Items.Count)
		{
			num2 = Items.Count;
		}
		return Enumerable.Range(num, num2 - num);
	}

	private IEnumerable<DarkListItem> CreateRegistry()
	{
		return (from int_0 in InstantiateRegistry()
			select Items[int_0]).ToList();
	}

	protected override void PaintContent(Graphics graphics_0)
	{
		List<int> list = InstantiateRegistry().ToList();
		if (list.Count == 0)
		{
			return;
		}
		int num = list.Min();
		int num2 = list.Max();
		for (int i = num; i <= num2; i++)
		{
			int num3 = Math.Max(base.ContentSize.Width, base.Viewport.Width);
			Rectangle rect = new Rectangle(0, i * ItemHeight, num3, ItemHeight);
			Color color = ((i % 2 == 0) ? Colors.HeaderBackground : Colors.GreyBackground);
			if (SelectedIndices.Count > 0 && SelectedIndices.Contains(i))
			{
				color = (Focused ? Colors.BlueSelection : Colors.GreySelection);
			}
			if (m_DicExpression == null)
			{
				using (SolidBrush brush = new SolidBrush(color))
				{
					graphics_0.FillRectangle(brush, rect);
				}
				if (ShowIcons && Items[i].Icon != null)
				{
					graphics_0.DrawImageUnscaled(Items[i].Icon, new Point(rect.Left + 5, rect.Top + rect.Height / 2 - m_ProxyExpression / 2));
				}
				using SolidBrush brush2 = new SolidBrush(Items[i].TextColor);
				StringFormat stringFormat = new StringFormat
				{
					Alignment = StringAlignment.Near,
					LineAlignment = StringAlignment.Center
				};
				Font font = new Font(Font, Items[i].FontStyle);
				Rectangle rectangle = new Rectangle(rect.Left + 2, rect.Top, rect.Width, rect.Height);
				if (ShowIcons)
				{
					rectangle.X += m_ProxyExpression + 8;
				}
				graphics_0.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				if (tabStops != null && Items[i].Text != null)
				{
					stringFormat.FormatFlags = StringFormatFlags.NoWrap;
					stringFormat.Trimming = StringTrimming.EllipsisWord;
					stringFormat.Alignment = StringAlignment.Near;
					string[] array = Items[i].Text.Split('\t');
					Rectangle rectangle2 = rectangle;
					for (int j = 0; j < array.Length; j++)
					{
						if (j > tabStops.Length)
						{
							continue;
						}
						string s = array[j];
						if (j == 0)
						{
							rectangle2.Width = (int)tabStops[j];
						}
						else
						{
							rectangle2.Offset((int)tabStops[j - 1], 0);
							if (j == tabStops.Length)
							{
								rectangle2.Width = rectangle.Width - rectangle2.X;
							}
							else
							{
								rectangle2.Width = (int)tabStops[j];
							}
						}
						graphics_0.DrawString(s, font, brush2, rectangle2, stringFormat);
					}
				}
				else
				{
					graphics_0.DrawString(Items[i].Text, font, brush2, rectangle, stringFormat);
				}
			}
			else
			{
				DrawDarkListViewListItemEventArgs drawDarkListViewListItemEventArgs = new DrawDarkListViewListItemEventArgs();
				drawDarkListViewListItemEventArgs.m_index = i;
				drawDarkListViewListItemEventArgs.m_rect = rect;
				drawDarkListViewListItemEventArgs.m_item = Items[i];
				drawDarkListViewListItemEventArgs.m_selected = color == Colors.GreySelection;
				drawDarkListViewListItemEventArgs.m_graphics = graphics_0;
				m_DicExpression(this, drawDarkListViewListItemEventArgs);
			}
		}
	}

	[CompilerGenerated]
	private DarkListItem CompareRegistry(int int_0)
	{
		return Items[int_0];
	}
}
