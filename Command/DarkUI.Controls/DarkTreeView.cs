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
using Command.Listeners;
using DarkUI.Collections;
using DarkUI.Config;
using DarkUI.Forms;
using OpenDis.Producers;

namespace DarkUI.Controls;

public class DarkTreeView : DarkScrollView
{
	public delegate void AfterNodeExpandDelegate(DarkTreeView tree, DarkTreeNode Node);

	public delegate void AfterNodeCollapseDelegate(DarkTreeView tree, DarkTreeNode Node);

	[CompilerGenerated]
	private EventHandler _BaseExpression;

	[CompilerGenerated]
	private AfterNodeExpandDelegate _PolicyExpression;

	[CompilerGenerated]
	private AfterNodeCollapseDelegate broadcasterExpression;

	private bool m_IdentifierExpression;

	private readonly int m_PrinterExpression = 16;

	private readonly int m_ParserExpression = 16;

	private int m_AlgoExpression = 20;

	private int _DatabaseExpression = 20;

	private ObservableList<DarkTreeNode> interceptorExpression;

	private ObservableCollection<DarkTreeNode> _MessageExpression;

	private DarkTreeNode m_ProductExpression;

	private DarkTreeNode m_AnnotationExpression;

	private Bitmap _IteratorExpression;

	private Bitmap initializerExpression;

	private Bitmap roleExpression;

	private Bitmap _FactoryExpression;

	private Bitmap _AttributeExpression;

	private Bitmap m_EventExpression;

	private DarkTreeNode m_GlobalExpression;

	private DarkTreeNode m_WorkerExpression;

	private bool m_AccountExpression;

	private List<DarkTreeNode> stateExpression;

	private Point m_AuthenticationExpression;

	[CompilerGenerated]
	private bool m_ParamsExpression;

	[CompilerGenerated]
	private bool m_HelperExpression;

	[CompilerGenerated]
	private int mapperExpression;

	[CompilerGenerated]
	private IComparer<DarkTreeNode> managerExpression;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ObservableList<DarkTreeNode> Nodes
	{
		get
		{
			return interceptorExpression;
		}
		set
		{
			if (interceptorExpression != null)
			{
				interceptorExpression.ItemsAdded -= delegate(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
				{
					foreach (DarkTreeNode current4 in observableListModified_0.Items)
					{
						current4.ParentTree = this;
						current4.IsRoot = true;
						RateRegistry(current4);
					}
					if (TreeViewNodeSorter != null)
					{
						Nodes.Sort(TreeViewNodeSorter);
					}
					UpdateNodes();
				};
				interceptorExpression.ItemsRemoved -= delegate(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
				{
					foreach (DarkTreeNode current3 in observableListModified_0.Items)
					{
						current3.ParentTree = this;
						current3.IsRoot = true;
						RateRegistry(current3);
					}
					UpdateNodes();
				};
				interceptorExpression.ItemsCleared -= DefineRegistry;
				foreach (DarkTreeNode item3 in interceptorExpression)
				{
					FlushRegistry(item3);
				}
			}
			interceptorExpression = value;
			interceptorExpression.ItemsAdded += delegate(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
			{
				foreach (DarkTreeNode current2 in observableListModified_0.Items)
				{
					current2.ParentTree = this;
					current2.IsRoot = true;
					RateRegistry(current2);
				}
				if (TreeViewNodeSorter != null)
				{
					Nodes.Sort(TreeViewNodeSorter);
				}
				UpdateNodes();
			};
			interceptorExpression.ItemsRemoved += delegate(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
			{
				foreach (DarkTreeNode current in observableListModified_0.Items)
				{
					current.ParentTree = this;
					current.IsRoot = true;
					RateRegistry(current);
				}
				UpdateNodes();
			};
			interceptorExpression.ItemsCleared += DefineRegistry;
			foreach (DarkTreeNode item4 in interceptorExpression)
			{
				RateRegistry(item4);
			}
			UpdateNodes();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ObservableCollection<DarkTreeNode> SelectedNodes => _MessageExpression;

	[Description("Determines the height of tree nodes.")]
	[Category("Appearance")]
	[DefaultValue(20)]
	public int ItemHeight
	{
		get
		{
			return m_AlgoExpression;
		}
		set
		{
			m_AlgoExpression = value;
			base.MaxDragChange = m_AlgoExpression;
			UpdateNodes();
		}
	}

	[DefaultValue(20)]
	[Category("Appearance")]
	[Description("Determines the amount of horizontal space given by parent node.")]
	public int Indent
	{
		get
		{
			return _DatabaseExpression;
		}
		set
		{
			_DatabaseExpression = value;
			UpdateNodes();
		}
	}

	[Description("Determines whether multiple tree nodes can be selected at once.")]
	[DefaultValue(false)]
	[Category("Behavior")]
	public bool MultiSelect
	{
		[CompilerGenerated]
		get
		{
			return m_ParamsExpression;
		}
		[CompilerGenerated]
		set
		{
			m_ParamsExpression = value;
		}
	}

	[Category("Behavior")]
	[Description("Determines whether nodes can be moved within this tree view.")]
	[DefaultValue(false)]
	public bool AllowMoveNodes { get; set; }

	[Description("Determines whether icons are rendered with the tree nodes.")]
	[DefaultValue(false)]
	[Category("Appearance")]
	public bool ShowIcons
	{
		[CompilerGenerated]
		get
		{
			return m_HelperExpression;
		}
		[CompilerGenerated]
		set
		{
			m_HelperExpression = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int VisibleNodeCount
	{
		[CompilerGenerated]
		get
		{
			return mapperExpression;
		}
		[CompilerGenerated]
		private set
		{
			mapperExpression = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public IComparer<DarkTreeNode> TreeViewNodeSorter
	{
		[CompilerGenerated]
		get
		{
			return managerExpression;
		}
		[CompilerGenerated]
		set
		{
			managerExpression = value;
		}
	}

	public event EventHandler SelectedNodesChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = _BaseExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _BaseExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = _BaseExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _BaseExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event AfterNodeExpandDelegate AfterNodeExpand
	{
		[CompilerGenerated]
		add
		{
			AfterNodeExpandDelegate afterNodeExpandDelegate = _PolicyExpression;
			AfterNodeExpandDelegate afterNodeExpandDelegate2;
			do
			{
				afterNodeExpandDelegate2 = afterNodeExpandDelegate;
				AfterNodeExpandDelegate value2 = (AfterNodeExpandDelegate)Delegate.Combine(afterNodeExpandDelegate2, value);
				afterNodeExpandDelegate = Interlocked.CompareExchange(ref _PolicyExpression, value2, afterNodeExpandDelegate2);
			}
			while ((object)afterNodeExpandDelegate != afterNodeExpandDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			AfterNodeExpandDelegate afterNodeExpandDelegate = _PolicyExpression;
			AfterNodeExpandDelegate afterNodeExpandDelegate2;
			do
			{
				afterNodeExpandDelegate2 = afterNodeExpandDelegate;
				AfterNodeExpandDelegate value2 = (AfterNodeExpandDelegate)Delegate.Remove(afterNodeExpandDelegate2, value);
				afterNodeExpandDelegate = Interlocked.CompareExchange(ref _PolicyExpression, value2, afterNodeExpandDelegate2);
			}
			while ((object)afterNodeExpandDelegate != afterNodeExpandDelegate2);
		}
	}

	public event AfterNodeCollapseDelegate AfterNodeCollapse
	{
		[CompilerGenerated]
		add
		{
			AfterNodeCollapseDelegate afterNodeCollapseDelegate = broadcasterExpression;
			AfterNodeCollapseDelegate afterNodeCollapseDelegate2;
			do
			{
				afterNodeCollapseDelegate2 = afterNodeCollapseDelegate;
				AfterNodeCollapseDelegate value2 = (AfterNodeCollapseDelegate)Delegate.Combine(afterNodeCollapseDelegate2, value);
				afterNodeCollapseDelegate = Interlocked.CompareExchange(ref broadcasterExpression, value2, afterNodeCollapseDelegate2);
			}
			while ((object)afterNodeCollapseDelegate != afterNodeCollapseDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			AfterNodeCollapseDelegate afterNodeCollapseDelegate = broadcasterExpression;
			AfterNodeCollapseDelegate afterNodeCollapseDelegate2;
			do
			{
				afterNodeCollapseDelegate2 = afterNodeCollapseDelegate;
				AfterNodeCollapseDelegate value2 = (AfterNodeCollapseDelegate)Delegate.Remove(afterNodeCollapseDelegate2, value);
				afterNodeCollapseDelegate = Interlocked.CompareExchange(ref broadcasterExpression, value2, afterNodeCollapseDelegate2);
			}
			while ((object)afterNodeCollapseDelegate != afterNodeCollapseDelegate2);
		}
	}

	public DarkTreeView()
	{
		Nodes = new ObservableList<DarkTreeNode>();
		_MessageExpression = new ObservableCollection<DarkTreeNode>();
		_MessageExpression.CollectionChanged += QueryRegistry;
		base.MaxDragChange = m_AlgoExpression;
		OrderRegistry();
	}

	protected override void Dispose(bool disposing)
	{
		if (!m_IdentifierExpression)
		{
			RegisterRegistry();
			if (_BaseExpression != null)
			{
				_BaseExpression = null;
			}
			if (_PolicyExpression != null)
			{
				_PolicyExpression = null;
			}
			if (broadcasterExpression != null)
			{
				_PolicyExpression = null;
			}
			if (interceptorExpression != null)
			{
				interceptorExpression.Dispose();
			}
			if (_MessageExpression != null)
			{
				_MessageExpression.CollectionChanged -= QueryRegistry;
			}
			m_IdentifierExpression = true;
		}
		base.Dispose(disposing);
	}

	private void AssetRegistry(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
	{
		foreach (DarkTreeNode item in observableListModified_0.Items)
		{
			item.ParentTree = this;
			item.IsRoot = true;
			RateRegistry(item);
		}
		if (TreeViewNodeSorter != null)
		{
			Nodes.Sort(TreeViewNodeSorter);
		}
		UpdateNodes();
	}

	private void PrintRegistry(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
	{
		foreach (DarkTreeNode item in observableListModified_0.Items)
		{
			item.ParentTree = this;
			item.IsRoot = true;
			RateRegistry(item);
		}
		UpdateNodes();
	}

	private void DefineRegistry(object object_0, object object_1)
	{
		_MessageExpression.Clear();
	}

	private void PublishRegistry(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
	{
		foreach (DarkTreeNode item in observableListModified_0.Items)
		{
			RateRegistry(item);
		}
		UpdateNodes();
	}

	private void AwakeRegistry(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
	{
		foreach (DarkTreeNode item in observableListModified_0.Items)
		{
			if (SelectedNodes.Contains(item))
			{
				SelectedNodes.Remove(item);
			}
			FlushRegistry(item);
		}
		UpdateNodes();
	}

	private void QueryRegistry(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (_BaseExpression != null)
		{
			_BaseExpression(this, null);
		}
	}

	private void ResetRegistry(object sender, EventArgs e)
	{
		UpdateNodes();
	}

	private void MapRegistry(object sender, EventArgs e)
	{
		UpdateNodes();
		if (_PolicyExpression != null)
		{
			_PolicyExpression(this, (DarkTreeNode)sender);
		}
	}

	private void SortRegistry(object sender, EventArgs e)
	{
		UpdateNodes();
		if (broadcasterExpression != null)
		{
			broadcasterExpression(this, (DarkTreeNode)sender);
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (m_AccountExpression && base.OffsetMousePosition != m_AuthenticationExpression)
		{
			StartDrag();
			AddDefinition();
			return;
		}
		if (base.IsDragging && m_WorkerExpression != null && !GetNodeFullRowArea(m_WorkerExpression).Contains(base.OffsetMousePosition))
		{
			m_WorkerExpression = null;
			Invalidate();
		}
		ManageRegistry();
		if (base.IsDragging)
		{
			AddDefinition();
		}
		base.OnMouseMove(e);
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		ManageRegistry();
		base.OnMouseWheel(e);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
		{
			foreach (DarkTreeNode item in Nodes.ToList())
			{
				CustomizeDefinition(item, base.OffsetMousePosition, e.Button);
			}
		}
		base.OnMouseDown(e);
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		if (base.IsDragging)
		{
			DestroyDefinition();
		}
		if (m_AccountExpression)
		{
			if (m_GlobalExpression != null)
			{
				Point authenticationExpression = m_AuthenticationExpression;
				if (base.OffsetMousePosition == authenticationExpression)
				{
					SelectNode(m_GlobalExpression);
				}
			}
			m_AccountExpression = false;
		}
		base.OnMouseUp(mevent);
	}

	protected override void OnMouseDoubleClick(MouseEventArgs e)
	{
		if (Control.ModifierKeys == Keys.Control)
		{
			return;
		}
		if (e.Button == MouseButtons.Left)
		{
			foreach (DarkTreeNode node in Nodes)
			{
				CloneDefinition(node, base.OffsetMousePosition);
			}
		}
		base.OnMouseDoubleClick(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		foreach (DarkTreeNode node in Nodes)
		{
			RevertRegistry(node);
		}
	}

	protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
	{
		base.OnPreviewKeyDown(e);
	}

	protected override void OnKeyDown(KeyEventArgs ke)
	{
		base.OnKeyDown(ke);
		if (base.IsDragging || Nodes.Count == 0 || (ke.KeyCode != Keys.Down && ke.KeyCode != Keys.Up && ke.KeyCode != Keys.Left && ke.KeyCode != Keys.Right))
		{
			return;
		}
		if (m_AnnotationExpression == null)
		{
			if (Nodes.Count > 0)
			{
				SelectNode(Nodes[0]);
			}
			return;
		}
		if (ke.KeyCode == Keys.Down || ke.KeyCode == Keys.Up)
		{
			if (MultiSelect && Control.ModifierKeys == Keys.Shift)
			{
				if (ke.KeyCode == Keys.Up)
				{
					if (m_AnnotationExpression.PrevVisibleNode != null)
					{
						ConnectDefinition(m_AnnotationExpression.PrevVisibleNode);
						EnsureVisible();
						ke.Handled = base.HandlesEvents;
					}
				}
				else if (ke.KeyCode == Keys.Down && m_AnnotationExpression.NextVisibleNode != null)
				{
					ConnectDefinition(m_AnnotationExpression.NextVisibleNode);
					EnsureVisible();
					ke.Handled = base.HandlesEvents;
				}
			}
			else if (ke.KeyCode == Keys.Up)
			{
				if (m_AnnotationExpression.PrevVisibleNode != null)
				{
					SelectNode(m_AnnotationExpression.PrevVisibleNode);
					EnsureVisible();
					ke.Handled = base.HandlesEvents;
				}
			}
			else if (ke.KeyCode == Keys.Down && m_AnnotationExpression.NextVisibleNode != null)
			{
				SelectNode(m_AnnotationExpression.NextVisibleNode);
				EnsureVisible();
				ke.Handled = base.HandlesEvents;
			}
		}
		if (ke.KeyCode != Keys.Left && ke.KeyCode != Keys.Right)
		{
			return;
		}
		if (ke.KeyCode == Keys.Left)
		{
			if (m_AnnotationExpression.Expanded && m_AnnotationExpression.Nodes.Count > 0)
			{
				m_AnnotationExpression.Expanded = false;
			}
			else if (m_AnnotationExpression.ParentNode != null)
			{
				SelectNode(m_AnnotationExpression.ParentNode);
				EnsureVisible();
				ke.Handled = base.HandlesEvents;
			}
		}
		else
		{
			if (ke.KeyCode != Keys.Right)
			{
				return;
			}
			if (m_AnnotationExpression.Expanded)
			{
				if (m_AnnotationExpression.Nodes.Count > 0)
				{
					SelectNode(m_AnnotationExpression.Nodes[0]);
					EnsureVisible();
					ke.Handled = base.HandlesEvents;
				}
			}
			else
			{
				m_AnnotationExpression.Expanded = true;
			}
		}
	}

	private void CalcRegistry(object sender, EventArgs e)
	{
		if (base.IsDragging)
		{
			if (Control.MouseButtons == MouseButtons.Left)
			{
				Point point = PointToClient(Control.MousePosition);
				if (_vScrollBar.Visible)
				{
					if (point.Y < base.ClientRectangle.Top)
					{
						int num = (point.Y - base.ClientRectangle.Top) * -1;
						if (num > ItemHeight)
						{
							num = ItemHeight;
						}
						_vScrollBar.Value -= num;
					}
					if (point.Y > base.ClientRectangle.Bottom)
					{
						int num2 = point.Y - base.ClientRectangle.Bottom;
						if (num2 > ItemHeight)
						{
							num2 = ItemHeight;
						}
						_vScrollBar.Value += num2;
					}
				}
				if (!_hScrollBar.Visible)
				{
					return;
				}
				if (point.X < base.ClientRectangle.Left)
				{
					int num3 = (point.X - base.ClientRectangle.Left) * -1;
					if (num3 > ItemHeight)
					{
						num3 = ItemHeight;
					}
					_hScrollBar.Value -= num3;
				}
				if (point.X > base.ClientRectangle.Right)
				{
					int num4 = point.X - base.ClientRectangle.Right;
					if (num4 > ItemHeight)
					{
						num4 = ItemHeight;
					}
					_hScrollBar.Value += num4;
				}
			}
			else
			{
				StopDrag();
			}
		}
		else
		{
			StopDrag();
		}
	}

	private void RateRegistry(DarkTreeNode darkTreeNode_0)
	{
		darkTreeNode_0.Nodes.ItemsAdded += delegate(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
		{
			foreach (DarkTreeNode current2 in observableListModified_0.Items)
			{
				RateRegistry(current2);
			}
			UpdateNodes();
		};
		darkTreeNode_0.Nodes.ItemsRemoved += delegate(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
		{
			foreach (DarkTreeNode current in observableListModified_0.Items)
			{
				if (SelectedNodes.Contains(current))
				{
					SelectedNodes.Remove(current);
				}
				FlushRegistry(current);
			}
			UpdateNodes();
		};
		darkTreeNode_0.TextChanged += ResetRegistry;
		darkTreeNode_0.NodeExpanded += MapRegistry;
		darkTreeNode_0.NodeCollapsed += SortRegistry;
		foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
		{
			RateRegistry(node);
		}
	}

	private void FlushRegistry(DarkTreeNode darkTreeNode_0)
	{
		darkTreeNode_0.Nodes.ItemsAdded -= delegate(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
		{
			foreach (DarkTreeNode current2 in observableListModified_0.Items)
			{
				RateRegistry(current2);
			}
			UpdateNodes();
		};
		darkTreeNode_0.Nodes.ItemsRemoved -= delegate(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
		{
			foreach (DarkTreeNode current in observableListModified_0.Items)
			{
				if (SelectedNodes.Contains(current))
				{
					SelectedNodes.Remove(current);
				}
				FlushRegistry(current);
			}
			UpdateNodes();
		};
		darkTreeNode_0.TextChanged -= ResetRegistry;
		darkTreeNode_0.NodeExpanded -= MapRegistry;
		darkTreeNode_0.NodeCollapsed -= SortRegistry;
		foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
		{
			FlushRegistry(node);
		}
	}

	public void UpdateNodes()
	{
		if (base.IsDragging || Nodes.Count == 0)
		{
			return;
		}
		int int_ = 0;
		bool bool_ = false;
		int int_2 = 0;
		DarkTreeNode darkTreeNode_ = null;
		base.ContentSize = new Size(0, 0);
		using (Graphics graphics_ = CreateGraphics())
		{
			for (int i = 0; i <= Nodes.Count - 1; i++)
			{
				DarkTreeNode darkTreeNode_2 = Nodes[i];
				ForgotRegistry(darkTreeNode_2, ref darkTreeNode_, 0, ref int_, ref bool_, ref int_2, graphics_);
			}
		}
		base.ContentSize = new Size(base.ContentSize.Width, int_);
		VisibleNodeCount = int_2;
		Invalidate();
	}

	private void ForgotRegistry(DarkTreeNode darkTreeNode_0, ref DarkTreeNode darkTreeNode_1, int int_0, ref int int_1, ref bool bool_0, ref int int_2, Graphics graphics_0)
	{
		CollectRegistry(darkTreeNode_0, int_1, int_0, graphics_0);
		int_1 += ItemHeight;
		darkTreeNode_0.Odd = bool_0;
		bool_0 = !bool_0;
		darkTreeNode_0.VisibleIndex = int_2;
		int_2++;
		darkTreeNode_0.PrevVisibleNode = darkTreeNode_1;
		if (darkTreeNode_1 != null)
		{
			darkTreeNode_1.NextVisibleNode = darkTreeNode_0;
		}
		darkTreeNode_1 = darkTreeNode_0;
		if (!darkTreeNode_0.Expanded)
		{
			return;
		}
		foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
		{
			ForgotRegistry(node, ref darkTreeNode_1, int_0 + Indent, ref int_1, ref bool_0, ref int_2, graphics_0);
		}
	}

	private void CollectRegistry(DarkTreeNode darkTreeNode_0, int int_0, int int_1, Graphics graphics_0)
	{
		int num = int_0 + ItemHeight / 2 - m_PrinterExpression / 2;
		darkTreeNode_0.ExpandArea = new Rectangle(int_1 + 3, num, m_PrinterExpression, m_PrinterExpression);
		int num2 = int_0 + ItemHeight / 2 - m_ParserExpression / 2;
		if (ShowIcons)
		{
			darkTreeNode_0.IconArea = new Rectangle(darkTreeNode_0.ExpandArea.Right + 2, num2, m_ParserExpression, m_ParserExpression);
		}
		else
		{
			darkTreeNode_0.IconArea = new Rectangle(darkTreeNode_0.ExpandArea.Right, num2, 0, 0);
		}
		int num3 = (int)((double)graphics_0.MeasureString(darkTreeNode_0.Text, Font).Width * 1.5);
		darkTreeNode_0.TextArea = new Rectangle(darkTreeNode_0.IconArea.Right + 2, int_0, num3 + 1, ItemHeight);
		darkTreeNode_0.FullArea = new Rectangle(int_1, int_0, darkTreeNode_0.TextArea.Right - int_1, ItemHeight);
		if (base.ContentSize.Width < darkTreeNode_0.TextArea.Right + 2)
		{
			base.ContentSize = new Size(darkTreeNode_0.TextArea.Right + 2, base.ContentSize.Height);
		}
	}

	private void OrderRegistry()
	{
		RegisterRegistry();
		_IteratorExpression = PrototypeObject.node_closed_empty.ViewListener(Colors.LightText);
		initializerExpression = PrototypeObject.node_closed_empty.ViewListener(Colors.BlueHighlight);
		roleExpression = PrototypeObject.node_closed_full.ViewListener(Colors.LightText);
		_FactoryExpression = PrototypeObject.node_open.ViewListener(Colors.LightText);
		_AttributeExpression = PrototypeObject.node_open.ViewListener(Colors.BlueHighlight);
		m_EventExpression = PrototypeObject.node_open_empty.ViewListener(Colors.LightText);
	}

	private void RegisterRegistry()
	{
		if (_IteratorExpression != null)
		{
			_IteratorExpression.Dispose();
		}
		if (initializerExpression != null)
		{
			initializerExpression.Dispose();
		}
		if (roleExpression != null)
		{
			roleExpression.Dispose();
		}
		if (_FactoryExpression != null)
		{
			_FactoryExpression.Dispose();
		}
		if (_AttributeExpression != null)
		{
			_AttributeExpression.Dispose();
		}
		if (m_EventExpression != null)
		{
			m_EventExpression.Dispose();
		}
	}

	private void ManageRegistry()
	{
		if (base.ClientRectangle.Contains(PointToClient(Control.MousePosition)))
		{
			foreach (DarkTreeNode node in Nodes)
			{
				CountDefinition(node, base.OffsetMousePosition);
			}
			return;
		}
		if (base.IsDragging && m_WorkerExpression != null)
		{
			m_WorkerExpression = null;
			Invalidate();
		}
	}

	private void RevertRegistry(DarkTreeNode darkTreeNode_0)
	{
		darkTreeNode_0.ExpandAreaHot = false;
		foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
		{
			RevertRegistry(node);
		}
		Invalidate();
	}

	private void CountDefinition(DarkTreeNode darkTreeNode_0, Point point_0)
	{
		if (base.IsDragging)
		{
			if (GetNodeFullRowArea(darkTreeNode_0).Contains(base.OffsetMousePosition))
			{
				DarkTreeNode darkTreeNode = (stateExpression.Contains(darkTreeNode_0) ? null : darkTreeNode_0);
				if (m_WorkerExpression != darkTreeNode)
				{
					m_WorkerExpression = darkTreeNode;
					Invalidate();
				}
			}
		}
		else
		{
			bool flag = darkTreeNode_0.ExpandArea.Contains(point_0);
			if (darkTreeNode_0.ExpandAreaHot != flag)
			{
				darkTreeNode_0.ExpandAreaHot = flag;
				Invalidate();
			}
		}
		foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
		{
			CountDefinition(node, point_0);
		}
	}

	private void CustomizeDefinition(DarkTreeNode darkTreeNode_0, Point point_0, MouseButtons mouseButtons_0)
	{
		if (GetNodeFullRowArea(darkTreeNode_0).Contains(point_0))
		{
			if (darkTreeNode_0.ExpandArea.Contains(point_0))
			{
				if (mouseButtons_0 == MouseButtons.Left)
				{
					darkTreeNode_0.Expanded = !darkTreeNode_0.Expanded;
				}
			}
			else
			{
				switch (mouseButtons_0)
				{
				case MouseButtons.Right:
					if ((!MultiSelect || Control.ModifierKeys != Keys.Shift) && (!MultiSelect || Control.ModifierKeys != Keys.Control) && !SelectedNodes.Contains(darkTreeNode_0))
					{
						SelectNode(darkTreeNode_0);
					}
					return;
				case MouseButtons.Left:
					if (MultiSelect && Control.ModifierKeys == Keys.Shift)
					{
						ConnectDefinition(darkTreeNode_0);
						return;
					}
					if (MultiSelect && Control.ModifierKeys == Keys.Control)
					{
						ToggleNode(darkTreeNode_0);
						return;
					}
					if (!SelectedNodes.Contains(darkTreeNode_0))
					{
						SelectNode(darkTreeNode_0);
					}
					m_AuthenticationExpression = base.OffsetMousePosition;
					m_AccountExpression = true;
					m_GlobalExpression = darkTreeNode_0;
					return;
				}
			}
		}
		if (!darkTreeNode_0.Expanded)
		{
			return;
		}
		foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
		{
			CustomizeDefinition(node, point_0, mouseButtons_0);
		}
	}

	private void CloneDefinition(DarkTreeNode darkTreeNode_0, Point point_0)
	{
		if (GetNodeFullRowArea(darkTreeNode_0).Contains(point_0))
		{
			if (!darkTreeNode_0.ExpandArea.Contains(point_0))
			{
				darkTreeNode_0.Expanded = !darkTreeNode_0.Expanded;
			}
		}
		else
		{
			if (!darkTreeNode_0.Expanded)
			{
				return;
			}
			foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
			{
				CloneDefinition(node, point_0);
			}
		}
	}

	public void SelectNode(DarkTreeNode darkTreeNode_0)
	{
		_MessageExpression.Clear();
		_MessageExpression.Add(darkTreeNode_0);
		m_ProductExpression = darkTreeNode_0;
		m_AnnotationExpression = darkTreeNode_0;
		Invalidate();
	}

	public void SelectNodes(DarkTreeNode darkTreeNode_0, DarkTreeNode darkTreeNode_1)
	{
		List<DarkTreeNode> list = new List<DarkTreeNode>();
		if (darkTreeNode_0 == darkTreeNode_1)
		{
			list.Add(darkTreeNode_0);
		}
		if (darkTreeNode_0.VisibleIndex < darkTreeNode_1.VisibleIndex)
		{
			DarkTreeNode darkTreeNode = darkTreeNode_0;
			list.Add(darkTreeNode);
			while (darkTreeNode != darkTreeNode_1 && darkTreeNode != null)
			{
				darkTreeNode = darkTreeNode.NextVisibleNode;
				list.Add(darkTreeNode);
			}
		}
		else if (darkTreeNode_0.VisibleIndex > darkTreeNode_1.VisibleIndex)
		{
			DarkTreeNode darkTreeNode2 = darkTreeNode_0;
			list.Add(darkTreeNode2);
			while (darkTreeNode2 != darkTreeNode_1 && darkTreeNode2 != null)
			{
				darkTreeNode2 = darkTreeNode2.PrevVisibleNode;
				list.Add(darkTreeNode2);
			}
		}
		SelectNodes(list, bool_0: false);
	}

	public void SelectNodes(List<DarkTreeNode> list_0, bool bool_0 = true)
	{
		_MessageExpression.Clear();
		foreach (DarkTreeNode item in list_0)
		{
			_MessageExpression.Add(item);
		}
		if (bool_0 && _MessageExpression.Count > 0)
		{
			m_ProductExpression = _MessageExpression[_MessageExpression.Count - 1];
			m_AnnotationExpression = _MessageExpression[_MessageExpression.Count - 1];
		}
		Invalidate();
	}

	private void ConnectDefinition(DarkTreeNode darkTreeNode_0)
	{
		m_AnnotationExpression = darkTreeNode_0;
		SelectNodes(m_ProductExpression, m_AnnotationExpression);
	}

	public void ToggleNode(DarkTreeNode darkTreeNode_0)
	{
		if (_MessageExpression.Contains(darkTreeNode_0))
		{
			_MessageExpression.Remove(darkTreeNode_0);
			if (m_ProductExpression == darkTreeNode_0 && m_AnnotationExpression == darkTreeNode_0)
			{
				if (_MessageExpression.Count <= 0)
				{
					m_ProductExpression = null;
					m_AnnotationExpression = null;
				}
				else
				{
					m_ProductExpression = _MessageExpression[0];
					m_AnnotationExpression = _MessageExpression[0];
				}
			}
			if (m_ProductExpression == darkTreeNode_0)
			{
				if (m_AnnotationExpression.VisibleIndex < darkTreeNode_0.VisibleIndex)
				{
					m_ProductExpression = darkTreeNode_0.PrevVisibleNode;
				}
				else if (m_AnnotationExpression.VisibleIndex <= darkTreeNode_0.VisibleIndex)
				{
					m_ProductExpression = m_AnnotationExpression;
				}
				else
				{
					m_ProductExpression = darkTreeNode_0.NextVisibleNode;
				}
			}
			if (m_AnnotationExpression == darkTreeNode_0)
			{
				if (m_ProductExpression.VisibleIndex < darkTreeNode_0.VisibleIndex)
				{
					m_AnnotationExpression = darkTreeNode_0.PrevVisibleNode;
				}
				else if (m_ProductExpression.VisibleIndex <= darkTreeNode_0.VisibleIndex)
				{
					m_AnnotationExpression = m_ProductExpression;
				}
				else
				{
					m_AnnotationExpression = darkTreeNode_0.NextVisibleNode;
				}
			}
		}
		else
		{
			_MessageExpression.Add(darkTreeNode_0);
			m_ProductExpression = darkTreeNode_0;
			m_AnnotationExpression = darkTreeNode_0;
		}
		Invalidate();
	}

	public Rectangle GetNodeFullRowArea(DarkTreeNode darkTreeNode_0)
	{
		if (darkTreeNode_0.ParentNode != null && !darkTreeNode_0.ParentNode.Expanded)
		{
			return new Rectangle(-1, -1, -1, -1);
		}
		int num = Math.Max(base.ContentSize.Width, base.Viewport.Width);
		return new Rectangle(0, darkTreeNode_0.FullArea.Top, num, ItemHeight);
	}

	public void EnsureVisible()
	{
		if (SelectedNodes.Count == 0)
		{
			return;
		}
		foreach (DarkTreeNode selectedNode in SelectedNodes)
		{
			selectedNode.EnsureVisible();
		}
		int num = -1;
		num = (MultiSelect ? m_AnnotationExpression.FullArea.Top : SelectedNodes[0].FullArea.Top);
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

	public void Sort()
	{
		if (TreeViewNodeSorter == null)
		{
			return;
		}
		Nodes.Sort(TreeViewNodeSorter);
		foreach (DarkTreeNode node in Nodes)
		{
			MoveDefinition(node);
		}
	}

	private void MoveDefinition(DarkTreeNode darkTreeNode_0)
	{
		darkTreeNode_0.Nodes.Sort(TreeViewNodeSorter);
		foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
		{
			MoveDefinition(node);
		}
	}

	public DarkTreeNode FindNode(string string_0)
	{
		foreach (DarkTreeNode node in Nodes)
		{
			DarkTreeNode darkTreeNode = DeleteDefinition(node, string_0);
			if (darkTreeNode != null)
			{
				return darkTreeNode;
			}
		}
		return null;
	}

	private DarkTreeNode DeleteDefinition(DarkTreeNode darkTreeNode_0, string string_0, bool bool_0 = true)
	{
		if (darkTreeNode_0.FullPath == string_0)
		{
			return darkTreeNode_0;
		}
		foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
		{
			if (!(node.FullPath == string_0))
			{
				if (bool_0)
				{
					DarkTreeNode darkTreeNode = DeleteDefinition(node, string_0);
					if (darkTreeNode != null)
					{
						return darkTreeNode;
					}
				}
				continue;
			}
			return node;
		}
		return null;
	}

	protected override void StartDrag()
	{
		if (AllowMoveNodes)
		{
			stateExpression = new List<DarkTreeNode>();
			foreach (DarkTreeNode selectedNode in SelectedNodes)
			{
				stateExpression.Add(selectedNode);
			}
			foreach (DarkTreeNode item in stateExpression.ToList())
			{
				if (item.ParentNode != null && stateExpression.Contains(item.ParentNode))
				{
					stateExpression.Remove(item);
				}
			}
			m_AccountExpression = false;
			Cursor = Cursors.SizeAll;
			base.StartDrag();
		}
		else
		{
			m_AccountExpression = false;
		}
	}

	private void AddDefinition()
	{
		if (!AllowMoveNodes)
		{
			return;
		}
		DarkTreeNode darkTreeNode = m_WorkerExpression;
		if (darkTreeNode == null)
		{
			if (Cursor != Cursors.No)
			{
				Cursor = Cursors.No;
			}
			return;
		}
		if (ForceDropToParent(darkTreeNode))
		{
			darkTreeNode = darkTreeNode.ParentNode;
		}
		if (CanMoveNodes(stateExpression, darkTreeNode))
		{
			if (Cursor != Cursors.SizeAll)
			{
				Cursor = Cursors.SizeAll;
			}
		}
		else if (Cursor != Cursors.No)
		{
			Cursor = Cursors.No;
		}
	}

	private void DestroyDefinition()
	{
		if (!AllowMoveNodes)
		{
			return;
		}
		DarkTreeNode darkTreeNode = m_WorkerExpression;
		if (darkTreeNode == null)
		{
			StopDrag();
			return;
		}
		if (ForceDropToParent(darkTreeNode))
		{
			darkTreeNode = darkTreeNode.ParentNode;
		}
		if (CanMoveNodes(stateExpression, darkTreeNode, bool_0: true))
		{
			List<DarkTreeNode> list = SelectedNodes.ToList();
			MoveNodes(stateExpression, darkTreeNode);
			foreach (DarkTreeNode item in stateExpression)
			{
				if (item.ParentNode == null)
				{
					Nodes.Remove(item);
				}
				else
				{
					item.ParentNode.Nodes.Remove(item);
				}
				darkTreeNode.Nodes.Add(item);
			}
			if (TreeViewNodeSorter != null)
			{
				darkTreeNode.Nodes.Sort(TreeViewNodeSorter);
			}
			darkTreeNode.Expanded = true;
			NodesMoved(stateExpression);
			foreach (DarkTreeNode item2 in list)
			{
				_MessageExpression.Add(item2);
			}
		}
		StopDrag();
		UpdateNodes();
	}

	protected override void StopDrag()
	{
		stateExpression = null;
		m_WorkerExpression = null;
		Cursor = Cursors.Default;
		Invalidate();
		base.StopDrag();
	}

	protected virtual bool ForceDropToParent(DarkTreeNode darkTreeNode_0)
	{
		return false;
	}

	protected virtual bool CanMoveNodes(List<DarkTreeNode> list_0, DarkTreeNode darkTreeNode_0, bool bool_0 = false)
	{
		if (darkTreeNode_0 == null)
		{
			return false;
		}
		foreach (DarkTreeNode item in list_0)
		{
			if (item != darkTreeNode_0)
			{
				if (item.ParentNode == null || item.ParentNode != darkTreeNode_0)
				{
					DarkTreeNode parentNode = darkTreeNode_0.ParentNode;
					while (parentNode != null)
					{
						if (item != parentNode)
						{
							parentNode = parentNode.ParentNode;
							continue;
						}
						if (bool_0)
						{
							DarkMessageBox.ShowError("Cannot move " + item.Text + ". The destination folder is a subfolder of the source folder.", Application.ProductName);
						}
						return false;
					}
					continue;
				}
				if (bool_0)
				{
					DarkMessageBox.ShowError("Cannot move " + item.Text + ". The destination folder is the same as the source folder.", Application.ProductName);
				}
				return false;
			}
			if (bool_0)
			{
				DarkMessageBox.ShowError("Cannot move " + item.Text + ". The destination folder is the same as the source folder.", Application.ProductName);
			}
			return false;
		}
		return true;
	}

	protected virtual void MoveNodes(List<DarkTreeNode> list_0, DarkTreeNode darkTreeNode_0)
	{
	}

	protected virtual void NodesMoved(List<DarkTreeNode> list_0)
	{
	}

	protected override void PaintContent(Graphics graphics_0)
	{
		foreach (DarkTreeNode node in Nodes)
		{
			ComputeDefinition(node, graphics_0);
		}
	}

	private void ComputeDefinition(DarkTreeNode darkTreeNode_0, Graphics graphics_0)
	{
		Rectangle nodeFullRowArea = GetNodeFullRowArea(darkTreeNode_0);
		Color color = (darkTreeNode_0.Odd ? Colors.HeaderBackground : Colors.GreyBackground);
		if (SelectedNodes.Count > 0 && SelectedNodes.Contains(darkTreeNode_0))
		{
			color = (Focused ? Colors.BlueSelection : Colors.GreySelection);
		}
		if (base.IsDragging && m_WorkerExpression == darkTreeNode_0)
		{
			color = (Focused ? Colors.BlueSelection : Colors.GreySelection);
		}
		using (SolidBrush brush = new SolidBrush(color))
		{
			graphics_0.FillRectangle(brush, nodeFullRowArea);
		}
		if (darkTreeNode_0.Nodes.Count > 0)
		{
			Point point = new Point(darkTreeNode_0.ExpandArea.Location.X - 1, darkTreeNode_0.ExpandArea.Location.Y - 1);
			Bitmap image = _FactoryExpression;
			if (darkTreeNode_0.Expanded && !darkTreeNode_0.ExpandAreaHot)
			{
				image = _FactoryExpression;
			}
			else if (darkTreeNode_0.Expanded && darkTreeNode_0.ExpandAreaHot && !SelectedNodes.Contains(darkTreeNode_0))
			{
				image = _AttributeExpression;
			}
			else if (darkTreeNode_0.Expanded && darkTreeNode_0.ExpandAreaHot && SelectedNodes.Contains(darkTreeNode_0))
			{
				image = m_EventExpression;
			}
			else if (!darkTreeNode_0.Expanded && !darkTreeNode_0.ExpandAreaHot)
			{
				image = _IteratorExpression;
			}
			else if (!darkTreeNode_0.Expanded && darkTreeNode_0.ExpandAreaHot && !SelectedNodes.Contains(darkTreeNode_0))
			{
				image = initializerExpression;
			}
			else if (!darkTreeNode_0.Expanded && darkTreeNode_0.ExpandAreaHot && SelectedNodes.Contains(darkTreeNode_0))
			{
				image = roleExpression;
			}
			graphics_0.DrawImageUnscaled(image, point);
		}
		if (ShowIcons && darkTreeNode_0.Icon != null)
		{
			if (darkTreeNode_0.Expanded && darkTreeNode_0.ExpandedIcon != null)
			{
				graphics_0.DrawImageUnscaled(darkTreeNode_0.ExpandedIcon, darkTreeNode_0.IconArea.Location);
			}
			else
			{
				graphics_0.DrawImageUnscaled(darkTreeNode_0.Icon, darkTreeNode_0.IconArea.Location);
			}
		}
		graphics_0.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		using (SolidBrush brush2 = new SolidBrush(darkTreeNode_0.ForeColor))
		{
			StringFormat format = new StringFormat
			{
				Alignment = StringAlignment.Near,
				LineAlignment = StringAlignment.Center
			};
			if (darkTreeNode_0.Font == null)
			{
				graphics_0.DrawString(darkTreeNode_0.Text, Font, brush2, darkTreeNode_0.TextArea, format);
			}
			else
			{
				graphics_0.DrawString(darkTreeNode_0.Text, darkTreeNode_0.Font, brush2, darkTreeNode_0.TextArea, format);
			}
		}
		if (!darkTreeNode_0.Expanded)
		{
			return;
		}
		foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
		{
			ComputeDefinition(node, graphics_0);
		}
	}

	[CompilerGenerated]
	private void PatchDefinition(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
	{
		foreach (DarkTreeNode item in observableListModified_0.Items)
		{
			item.ParentTree = this;
			item.IsRoot = true;
			RateRegistry(item);
		}
		if (TreeViewNodeSorter != null)
		{
			Nodes.Sort(TreeViewNodeSorter);
		}
		UpdateNodes();
	}

	[CompilerGenerated]
	private void SelectDefinition(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
	{
		foreach (DarkTreeNode item in observableListModified_0.Items)
		{
			item.ParentTree = this;
			item.IsRoot = true;
			RateRegistry(item);
		}
		UpdateNodes();
	}

	[CompilerGenerated]
	private void CallDefinition(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
	{
		foreach (DarkTreeNode item in observableListModified_0.Items)
		{
			item.ParentTree = this;
			item.IsRoot = true;
			RateRegistry(item);
		}
		if (TreeViewNodeSorter != null)
		{
			Nodes.Sort(TreeViewNodeSorter);
		}
		UpdateNodes();
	}

	[CompilerGenerated]
	private void LogoutDefinition(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
	{
		foreach (DarkTreeNode item in observableListModified_0.Items)
		{
			item.ParentTree = this;
			item.IsRoot = true;
			RateRegistry(item);
		}
		UpdateNodes();
	}

	[CompilerGenerated]
	private void ViewDefinition(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
	{
		foreach (DarkTreeNode item in observableListModified_0.Items)
		{
			RateRegistry(item);
		}
		UpdateNodes();
	}

	[CompilerGenerated]
	private void ValidateDefinition(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
	{
		foreach (DarkTreeNode item in observableListModified_0.Items)
		{
			if (SelectedNodes.Contains(item))
			{
				SelectedNodes.Remove(item);
			}
			FlushRegistry(item);
		}
		UpdateNodes();
	}

	[CompilerGenerated]
	private void LoginDefinition(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
	{
		foreach (DarkTreeNode item in observableListModified_0.Items)
		{
			RateRegistry(item);
		}
		UpdateNodes();
	}

	[CompilerGenerated]
	private void GetDefinition(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
	{
		foreach (DarkTreeNode item in observableListModified_0.Items)
		{
			if (SelectedNodes.Contains(item))
			{
				SelectedNodes.Remove(item);
			}
			FlushRegistry(item);
		}
		UpdateNodes();
	}
}
