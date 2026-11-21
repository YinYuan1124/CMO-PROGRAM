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

public class DarkFilterTreeView : DarkScrollView
{
	public delegate void AfterNodeExpandDelegate(DarkFilterTreeView tree, DarkFilterTreeNode Node);

	public delegate void AfterNodeCollapseDelegate(DarkFilterTreeView tree, DarkFilterTreeNode Node);

	internal string roleParameter;

	[CompilerGenerated]
	private EventHandler m_FactoryParameter;

	[CompilerGenerated]
	private AfterNodeExpandDelegate attributeParameter;

	[CompilerGenerated]
	private AfterNodeCollapseDelegate eventParameter;

	private bool globalParameter;

	private readonly int workerParameter = 16;

	private readonly int accountParameter = 16;

	private int _StateParameter = 20;

	private int authenticationParameter = 20;

	private ObservableList<DarkFilterTreeNode> m_ParamsParameter;

	private ObservableCollection<DarkFilterTreeNode> infoParameter;

	private DarkFilterTreeNode helperParameter;

	private DarkFilterTreeNode mapperParameter;

	private Bitmap _ManagerParameter;

	private Bitmap getterParameter;

	private Bitmap _ProducerParameter;

	private Bitmap m_ProcParameter;

	private Bitmap m_StructExpression;

	private Bitmap m_MerchantExpression;

	private DarkFilterTreeNode callbackExpression;

	private DarkFilterTreeNode decoratorExpression;

	private bool processExpression;

	private List<DarkFilterTreeNode> m_ThreadExpression;

	private Point m_RuleExpression;

	[CompilerGenerated]
	private int collectionExpression;

	[CompilerGenerated]
	private IComparer<DarkFilterTreeNode> expressionExpression;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public ObservableList<DarkFilterTreeNode> Nodes
	{
		get
		{
			return m_ParamsParameter;
		}
		set
		{
			if (m_ParamsParameter != null)
			{
				m_ParamsParameter.ItemsAdded -= RevertConfig;
				m_ParamsParameter.ItemsRemoved -= CountRegistry;
				foreach (DarkFilterTreeNode item in m_ParamsParameter)
				{
					PatchRegistry(item);
				}
			}
			m_ParamsParameter = value;
			m_ParamsParameter.ItemsAdded += RevertConfig;
			m_ParamsParameter.ItemsRemoved += CountRegistry;
			foreach (DarkFilterTreeNode item2 in m_ParamsParameter)
			{
				ComputeRegistry(item2);
			}
			UpdateNodes();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public ObservableCollection<DarkFilterTreeNode> SelectedNodes => infoParameter;

	[DefaultValue(20)]
	[Description("Determines the height of tree nodes.")]
	[Category("Appearance")]
	public int ItemHeight
	{
		get
		{
			return _StateParameter;
		}
		set
		{
			_StateParameter = value;
			base.MaxDragChange = _StateParameter;
			UpdateNodes();
		}
	}

	[Category("Appearance")]
	[DefaultValue(20)]
	[Description("Determines the amount of horizontal space given by parent node.")]
	public int Indent
	{
		get
		{
			return authenticationParameter;
		}
		set
		{
			authenticationParameter = value;
			UpdateNodes();
		}
	}

	[Description("Determines whether multiple tree nodes can be selected at once.")]
	[DefaultValue(false)]
	[Category("Behavior")]
	public bool MultiSelect { get; set; }

	[Category("Behavior")]
	[DefaultValue(false)]
	[Description("Determines whether nodes can be moved within this tree view.")]
	public bool AllowMoveNodes { get; set; }

	[DefaultValue(false)]
	[Category("Appearance")]
	[Description("Determines whether icons are rendered with the tree nodes.")]
	public bool ShowIcons { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int VisibleNodeCount
	{
		[CompilerGenerated]
		get
		{
			return collectionExpression;
		}
		[CompilerGenerated]
		private set
		{
			collectionExpression = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IComparer<DarkFilterTreeNode> TreeViewNodeSorter
	{
		[CompilerGenerated]
		get
		{
			return expressionExpression;
		}
		[CompilerGenerated]
		set
		{
			expressionExpression = value;
		}
	}

	public event EventHandler SelectedNodesChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = m_FactoryParameter;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_FactoryParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = m_FactoryParameter;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_FactoryParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event AfterNodeExpandDelegate AfterNodeExpand
	{
		[CompilerGenerated]
		add
		{
			AfterNodeExpandDelegate afterNodeExpandDelegate = attributeParameter;
			AfterNodeExpandDelegate afterNodeExpandDelegate2;
			do
			{
				afterNodeExpandDelegate2 = afterNodeExpandDelegate;
				AfterNodeExpandDelegate value2 = (AfterNodeExpandDelegate)Delegate.Combine(afterNodeExpandDelegate2, value);
				afterNodeExpandDelegate = Interlocked.CompareExchange(ref attributeParameter, value2, afterNodeExpandDelegate2);
			}
			while ((object)afterNodeExpandDelegate != afterNodeExpandDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			AfterNodeExpandDelegate afterNodeExpandDelegate = attributeParameter;
			AfterNodeExpandDelegate afterNodeExpandDelegate2;
			do
			{
				afterNodeExpandDelegate2 = afterNodeExpandDelegate;
				AfterNodeExpandDelegate value2 = (AfterNodeExpandDelegate)Delegate.Remove(afterNodeExpandDelegate2, value);
				afterNodeExpandDelegate = Interlocked.CompareExchange(ref attributeParameter, value2, afterNodeExpandDelegate2);
			}
			while ((object)afterNodeExpandDelegate != afterNodeExpandDelegate2);
		}
	}

	public event AfterNodeCollapseDelegate AfterNodeCollapse
	{
		[CompilerGenerated]
		add
		{
			AfterNodeCollapseDelegate afterNodeCollapseDelegate = eventParameter;
			AfterNodeCollapseDelegate afterNodeCollapseDelegate2;
			do
			{
				afterNodeCollapseDelegate2 = afterNodeCollapseDelegate;
				AfterNodeCollapseDelegate value2 = (AfterNodeCollapseDelegate)Delegate.Combine(afterNodeCollapseDelegate2, value);
				afterNodeCollapseDelegate = Interlocked.CompareExchange(ref eventParameter, value2, afterNodeCollapseDelegate2);
			}
			while ((object)afterNodeCollapseDelegate != afterNodeCollapseDelegate2);
		}
		[CompilerGenerated]
		remove
		{
			AfterNodeCollapseDelegate afterNodeCollapseDelegate = eventParameter;
			AfterNodeCollapseDelegate afterNodeCollapseDelegate2;
			do
			{
				afterNodeCollapseDelegate2 = afterNodeCollapseDelegate;
				AfterNodeCollapseDelegate value2 = (AfterNodeCollapseDelegate)Delegate.Remove(afterNodeCollapseDelegate2, value);
				afterNodeCollapseDelegate = Interlocked.CompareExchange(ref eventParameter, value2, afterNodeCollapseDelegate2);
			}
			while ((object)afterNodeCollapseDelegate != afterNodeCollapseDelegate2);
		}
	}

	public void SetFilterString(string string_0)
	{
		roleParameter = string_0;
		UpdateNodes();
		Invalidate();
	}

	public DarkFilterTreeView()
	{
		Nodes = new ObservableList<DarkFilterTreeNode>();
		infoParameter = new ObservableCollection<DarkFilterTreeNode>();
		infoParameter.CollectionChanged += ConnectRegistry;
		base.MaxDragChange = _StateParameter;
		LogoutRegistry();
	}

	protected override void Dispose(bool disposing)
	{
		if (!globalParameter)
		{
			ViewRegistry();
			if (m_FactoryParameter != null)
			{
				m_FactoryParameter = null;
			}
			if (attributeParameter != null)
			{
				attributeParameter = null;
			}
			if (eventParameter != null)
			{
				attributeParameter = null;
			}
			if (m_ParamsParameter != null)
			{
				m_ParamsParameter.Dispose();
			}
			if (infoParameter != null)
			{
				infoParameter.CollectionChanged -= ConnectRegistry;
			}
			globalParameter = true;
		}
		base.Dispose(disposing);
	}

	private void RevertConfig(object object_0, ObservableListModified<DarkFilterTreeNode> observableListModified_0)
	{
		foreach (DarkFilterTreeNode item in observableListModified_0.Items)
		{
			item.ParentTree = this;
			item.IsRoot = true;
			ComputeRegistry(item);
		}
		if (TreeViewNodeSorter != null)
		{
			Nodes.Sort(TreeViewNodeSorter);
		}
		UpdateNodes();
	}

	private void CountRegistry(object object_0, ObservableListModified<DarkFilterTreeNode> observableListModified_0)
	{
		foreach (DarkFilterTreeNode item in observableListModified_0.Items)
		{
			item.ParentTree = this;
			item.IsRoot = true;
			ComputeRegistry(item);
		}
		UpdateNodes();
	}

	private void CustomizeRegistry(object object_0, ObservableListModified<DarkFilterTreeNode> observableListModified_0)
	{
		foreach (DarkFilterTreeNode item in observableListModified_0.Items)
		{
			ComputeRegistry(item);
		}
		UpdateNodes();
	}

	private void CloneRegistry(object object_0, ObservableListModified<DarkFilterTreeNode> observableListModified_0)
	{
		foreach (DarkFilterTreeNode item in observableListModified_0.Items)
		{
			if (SelectedNodes.Contains(item))
			{
				SelectedNodes.Remove(item);
			}
			PatchRegistry(item);
		}
		UpdateNodes();
	}

	private void ConnectRegistry(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (m_FactoryParameter != null)
		{
			m_FactoryParameter(this, null);
		}
	}

	private void MoveRegistry(object sender, EventArgs e)
	{
		UpdateNodes();
	}

	private void DeleteRegistry(object sender, EventArgs e)
	{
		UpdateNodes();
		if (attributeParameter != null)
		{
			attributeParameter(this, (DarkFilterTreeNode)sender);
		}
	}

	private void AddRegistry(object sender, EventArgs e)
	{
		UpdateNodes();
		if (eventParameter != null)
		{
			eventParameter(this, (DarkFilterTreeNode)sender);
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (processExpression && base.OffsetMousePosition != m_RuleExpression)
		{
			StartDrag();
			ExcludeRegistry();
			return;
		}
		if (base.IsDragging && decoratorExpression != null && !GetNodeFullRowArea(decoratorExpression).Contains(base.OffsetMousePosition))
		{
			decoratorExpression = null;
			Invalidate();
		}
		ValidateRegistry();
		if (base.IsDragging)
		{
			ExcludeRegistry();
		}
		base.OnMouseMove(e);
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		ValidateRegistry();
		base.OnMouseWheel(e);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
		{
			foreach (DarkFilterTreeNode node in Nodes)
			{
				WriteRegistry(node, base.OffsetMousePosition, e.Button);
			}
		}
		base.OnMouseDown(e);
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		if (base.IsDragging)
		{
			IncludeRegistry();
		}
		if (processExpression)
		{
			if (callbackExpression != null)
			{
				Point ruleExpression = m_RuleExpression;
				if (base.OffsetMousePosition == ruleExpression)
				{
					SelectNode(callbackExpression);
				}
			}
			processExpression = false;
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
			foreach (DarkFilterTreeNode node in Nodes)
			{
				NewRegistry(node, base.OffsetMousePosition);
			}
		}
		base.OnMouseDoubleClick(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		foreach (DarkFilterTreeNode node in Nodes)
		{
			LoginRegistry(node);
		}
	}

	protected override void OnKeyDown(KeyEventArgs ke)
	{
		base.OnKeyDown(ke);
		if (base.IsDragging || Nodes.Count == 0 || (ke.KeyCode != Keys.Down && ke.KeyCode != Keys.Up && ke.KeyCode != Keys.Left && ke.KeyCode != Keys.Right))
		{
			return;
		}
		if (mapperParameter == null)
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
					if (mapperParameter.PrevVisibleNode != null)
					{
						PushRegistry(mapperParameter.PrevVisibleNode);
						EnsureVisible();
					}
				}
				else if (ke.KeyCode == Keys.Down && mapperParameter.NextVisibleNode != null)
				{
					PushRegistry(mapperParameter.NextVisibleNode);
					EnsureVisible();
				}
			}
			else if (ke.KeyCode == Keys.Up)
			{
				if (mapperParameter.PrevVisibleNode != null)
				{
					SelectNode(mapperParameter.PrevVisibleNode);
					EnsureVisible();
				}
			}
			else if (ke.KeyCode == Keys.Down && mapperParameter.NextVisibleNode != null)
			{
				SelectNode(mapperParameter.NextVisibleNode);
				EnsureVisible();
			}
		}
		if (ke.KeyCode != Keys.Left && ke.KeyCode != Keys.Right)
		{
			return;
		}
		if (ke.KeyCode == Keys.Left)
		{
			if (mapperParameter.Expanded && mapperParameter.Nodes.Count > 0)
			{
				mapperParameter.Expanded = false;
			}
			else if (mapperParameter.ParentNode != null)
			{
				SelectNode(mapperParameter.ParentNode);
				EnsureVisible();
			}
		}
		else
		{
			if (ke.KeyCode != Keys.Right)
			{
				return;
			}
			if (mapperParameter.Expanded)
			{
				if (mapperParameter.Nodes.Count > 0)
				{
					SelectNode(mapperParameter.Nodes[0]);
					EnsureVisible();
				}
			}
			else
			{
				mapperParameter.Expanded = true;
			}
		}
	}

	private void DestroyRegistry(object sender, EventArgs e)
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

	private void ComputeRegistry(DarkFilterTreeNode darkFilterTreeNode_0)
	{
		darkFilterTreeNode_0.Nodes.ItemsAdded += CustomizeRegistry;
		darkFilterTreeNode_0.Nodes.ItemsRemoved += CloneRegistry;
		darkFilterTreeNode_0.TextChanged += MoveRegistry;
		darkFilterTreeNode_0.NodeExpanded += DeleteRegistry;
		darkFilterTreeNode_0.NodeCollapsed += AddRegistry;
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_0.Nodes)
		{
			ComputeRegistry(node);
		}
	}

	private void PatchRegistry(DarkFilterTreeNode darkFilterTreeNode_0)
	{
		darkFilterTreeNode_0.Nodes.ItemsAdded -= CustomizeRegistry;
		darkFilterTreeNode_0.Nodes.ItemsRemoved -= CloneRegistry;
		darkFilterTreeNode_0.TextChanged -= MoveRegistry;
		darkFilterTreeNode_0.NodeExpanded -= DeleteRegistry;
		darkFilterTreeNode_0.NodeCollapsed -= AddRegistry;
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_0.Nodes)
		{
			PatchRegistry(node);
		}
	}

	public void UpdateNodes()
	{
		Dictionary<DarkFilterTreeNode, bool> dictionary_ = new Dictionary<DarkFilterTreeNode, bool>();
		if (base.IsDragging || Nodes.Count == 0)
		{
			return;
		}
		int int_ = 0;
		bool bool_ = false;
		int int_2 = 0;
		DarkFilterTreeNode darkFilterTreeNode_ = null;
		base.ContentSize = new Size(0, 0);
		using (Graphics graphics_ = CreateGraphics())
		{
			for (int i = 0; i <= Nodes.Count - 1; i++)
			{
				DarkFilterTreeNode darkFilterTreeNode_2 = Nodes[i];
				SelectRegistry(darkFilterTreeNode_2, ref darkFilterTreeNode_, 0, ref int_, ref bool_, ref int_2, dictionary_, graphics_);
			}
		}
		base.ContentSize = new Size(base.ContentSize.Width, int_);
		VisibleNodeCount = int_2;
		Invalidate();
	}

	private void SelectRegistry(DarkFilterTreeNode darkFilterTreeNode_0, ref DarkFilterTreeNode darkFilterTreeNode_1, int int_0, ref int int_1, ref bool bool_0, ref int int_2, Dictionary<DarkFilterTreeNode, bool> dictionary_0, Graphics graphics_0)
	{
		CallRegistry(darkFilterTreeNode_0, int_1, int_0, graphics_0);
		int_1 += ItemHeight;
		darkFilterTreeNode_0.Odd = bool_0;
		bool_0 = !bool_0;
		darkFilterTreeNode_0.VisibleIndex = int_2;
		int_2++;
		darkFilterTreeNode_0.PrevVisibleNode = darkFilterTreeNode_1;
		if (darkFilterTreeNode_1 != null)
		{
			darkFilterTreeNode_1.NextVisibleNode = darkFilterTreeNode_0;
		}
		darkFilterTreeNode_1 = darkFilterTreeNode_0;
		if (!darkFilterTreeNode_0.Expanded)
		{
			return;
		}
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_0.Nodes)
		{
			SelectRegistry(node, ref darkFilterTreeNode_1, int_0 + Indent, ref int_1, ref bool_0, ref int_2, dictionary_0, graphics_0);
		}
	}

	private void CallRegistry(DarkFilterTreeNode darkFilterTreeNode_0, int int_0, int int_1, Graphics graphics_0)
	{
		int num = int_0 + ItemHeight / 2 - workerParameter / 2;
		darkFilterTreeNode_0.ExpandArea = new Rectangle(int_1 + 3, num, workerParameter, workerParameter);
		int num2 = int_0 + ItemHeight / 2 - accountParameter / 2;
		if (ShowIcons)
		{
			darkFilterTreeNode_0.IconArea = new Rectangle(darkFilterTreeNode_0.ExpandArea.Right + 2, num2, accountParameter, accountParameter);
		}
		else
		{
			darkFilterTreeNode_0.IconArea = new Rectangle(darkFilterTreeNode_0.ExpandArea.Right, num2, 0, 0);
		}
		int num3 = (int)((double)graphics_0.MeasureString(darkFilterTreeNode_0.Text, Font).Width * 1.5);
		darkFilterTreeNode_0.TextArea = new Rectangle(darkFilterTreeNode_0.IconArea.Right + 2, int_0, num3 + 1, ItemHeight);
		darkFilterTreeNode_0.FullArea = new Rectangle(int_1, int_0, darkFilterTreeNode_0.TextArea.Right - int_1, ItemHeight);
		if (base.ContentSize.Width < darkFilterTreeNode_0.TextArea.Right + 2)
		{
			base.ContentSize = new Size(darkFilterTreeNode_0.TextArea.Right + 2, base.ContentSize.Height);
		}
	}

	private void LogoutRegistry()
	{
		ViewRegistry();
		_ManagerParameter = PrototypeObject.node_closed_empty.ViewListener(Colors.LightText);
		getterParameter = PrototypeObject.node_closed_empty.ViewListener(Colors.BlueHighlight);
		_ProducerParameter = PrototypeObject.node_closed_full.ViewListener(Colors.LightText);
		m_ProcParameter = PrototypeObject.node_open.ViewListener(Colors.LightText);
		m_StructExpression = PrototypeObject.node_open.ViewListener(Colors.BlueHighlight);
		m_MerchantExpression = PrototypeObject.node_open_empty.ViewListener(Colors.LightText);
	}

	private void ViewRegistry()
	{
		if (_ManagerParameter != null)
		{
			_ManagerParameter.Dispose();
		}
		if (getterParameter != null)
		{
			getterParameter.Dispose();
		}
		if (_ProducerParameter != null)
		{
			_ProducerParameter.Dispose();
		}
		if (m_ProcParameter != null)
		{
			m_ProcParameter.Dispose();
		}
		if (m_StructExpression != null)
		{
			m_StructExpression.Dispose();
		}
		if (m_MerchantExpression != null)
		{
			m_MerchantExpression.Dispose();
		}
	}

	private void ValidateRegistry()
	{
		if (base.ClientRectangle.Contains(PointToClient(Control.MousePosition)))
		{
			foreach (DarkFilterTreeNode node in Nodes)
			{
				GetRegistry(node, base.OffsetMousePosition);
			}
			return;
		}
		if (base.IsDragging && decoratorExpression != null)
		{
			decoratorExpression = null;
			Invalidate();
		}
	}

	private void LoginRegistry(DarkFilterTreeNode darkFilterTreeNode_0)
	{
		darkFilterTreeNode_0.ExpandAreaHot = false;
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_0.Nodes)
		{
			LoginRegistry(node);
		}
		Invalidate();
	}

	private void GetRegistry(DarkFilterTreeNode darkFilterTreeNode_0, Point point_0)
	{
		if (base.IsDragging)
		{
			if (GetNodeFullRowArea(darkFilterTreeNode_0).Contains(base.OffsetMousePosition))
			{
				DarkFilterTreeNode darkFilterTreeNode = (m_ThreadExpression.Contains(darkFilterTreeNode_0) ? null : darkFilterTreeNode_0);
				if (decoratorExpression != darkFilterTreeNode)
				{
					decoratorExpression = darkFilterTreeNode;
					Invalidate();
				}
			}
		}
		else
		{
			bool flag = darkFilterTreeNode_0.ExpandArea.Contains(point_0);
			if (darkFilterTreeNode_0.ExpandAreaHot != flag)
			{
				darkFilterTreeNode_0.ExpandAreaHot = flag;
				Invalidate();
			}
		}
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_0.Nodes)
		{
			GetRegistry(node, point_0);
		}
	}

	private void WriteRegistry(DarkFilterTreeNode darkFilterTreeNode_0, Point point_0, MouseButtons mouseButtons_0)
	{
		if (GetNodeFullRowArea(darkFilterTreeNode_0).Contains(point_0))
		{
			if (darkFilterTreeNode_0.ExpandArea.Contains(point_0))
			{
				if (mouseButtons_0 == MouseButtons.Left)
				{
					darkFilterTreeNode_0.Expanded = !darkFilterTreeNode_0.Expanded;
				}
			}
			else
			{
				switch (mouseButtons_0)
				{
				case MouseButtons.Right:
					if ((!MultiSelect || Control.ModifierKeys != Keys.Shift) && (!MultiSelect || Control.ModifierKeys != Keys.Control) && !SelectedNodes.Contains(darkFilterTreeNode_0))
					{
						SelectNode(darkFilterTreeNode_0);
					}
					return;
				case MouseButtons.Left:
					if (MultiSelect && Control.ModifierKeys == Keys.Shift)
					{
						PushRegistry(darkFilterTreeNode_0);
						return;
					}
					if (MultiSelect && Control.ModifierKeys == Keys.Control)
					{
						ToggleNode(darkFilterTreeNode_0);
						return;
					}
					if (!SelectedNodes.Contains(darkFilterTreeNode_0))
					{
						SelectNode(darkFilterTreeNode_0);
					}
					m_RuleExpression = base.OffsetMousePosition;
					processExpression = true;
					callbackExpression = darkFilterTreeNode_0;
					return;
				}
			}
		}
		if (!darkFilterTreeNode_0.Expanded)
		{
			return;
		}
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_0.Nodes)
		{
			WriteRegistry(node, point_0, mouseButtons_0);
		}
	}

	private void NewRegistry(DarkFilterTreeNode darkFilterTreeNode_0, Point point_0)
	{
		if (GetNodeFullRowArea(darkFilterTreeNode_0).Contains(point_0))
		{
			if (!darkFilterTreeNode_0.ExpandArea.Contains(point_0))
			{
				darkFilterTreeNode_0.Expanded = !darkFilterTreeNode_0.Expanded;
			}
		}
		else
		{
			if (!darkFilterTreeNode_0.Expanded)
			{
				return;
			}
			foreach (DarkFilterTreeNode node in darkFilterTreeNode_0.Nodes)
			{
				NewRegistry(node, point_0);
			}
		}
	}

	public void SelectNode(DarkFilterTreeNode darkFilterTreeNode_0)
	{
		infoParameter.Clear();
		infoParameter.Add(darkFilterTreeNode_0);
		helperParameter = darkFilterTreeNode_0;
		mapperParameter = darkFilterTreeNode_0;
		Invalidate();
	}

	public void SelectNodes(DarkFilterTreeNode darkFilterTreeNode_0, DarkFilterTreeNode darkFilterTreeNode_1)
	{
		List<DarkFilterTreeNode> list = new List<DarkFilterTreeNode>();
		if (darkFilterTreeNode_0 == darkFilterTreeNode_1)
		{
			list.Add(darkFilterTreeNode_0);
		}
		if (darkFilterTreeNode_0.VisibleIndex < darkFilterTreeNode_1.VisibleIndex)
		{
			DarkFilterTreeNode darkFilterTreeNode = darkFilterTreeNode_0;
			list.Add(darkFilterTreeNode);
			while (darkFilterTreeNode != darkFilterTreeNode_1 && darkFilterTreeNode != null)
			{
				darkFilterTreeNode = darkFilterTreeNode.NextVisibleNode;
				list.Add(darkFilterTreeNode);
			}
		}
		else if (darkFilterTreeNode_0.VisibleIndex > darkFilterTreeNode_1.VisibleIndex)
		{
			DarkFilterTreeNode darkFilterTreeNode2 = darkFilterTreeNode_0;
			list.Add(darkFilterTreeNode2);
			while (darkFilterTreeNode2 != darkFilterTreeNode_1 && darkFilterTreeNode2 != null)
			{
				darkFilterTreeNode2 = darkFilterTreeNode2.PrevVisibleNode;
				list.Add(darkFilterTreeNode2);
			}
		}
		SelectNodes(list, bool_0: false);
	}

	public void SelectNodes(List<DarkFilterTreeNode> list_0, bool bool_0 = true)
	{
		infoParameter.Clear();
		foreach (DarkFilterTreeNode item in list_0)
		{
			infoParameter.Add(item);
		}
		if (bool_0 && infoParameter.Count > 0)
		{
			helperParameter = infoParameter[infoParameter.Count - 1];
			mapperParameter = infoParameter[infoParameter.Count - 1];
		}
		Invalidate();
	}

	private void PushRegistry(DarkFilterTreeNode darkFilterTreeNode_0)
	{
		mapperParameter = darkFilterTreeNode_0;
		SelectNodes(helperParameter, mapperParameter);
	}

	public void ToggleNode(DarkFilterTreeNode darkFilterTreeNode_0)
	{
		if (infoParameter.Contains(darkFilterTreeNode_0))
		{
			infoParameter.Remove(darkFilterTreeNode_0);
			if (helperParameter == darkFilterTreeNode_0 && mapperParameter == darkFilterTreeNode_0)
			{
				if (infoParameter.Count <= 0)
				{
					helperParameter = null;
					mapperParameter = null;
				}
				else
				{
					helperParameter = infoParameter[0];
					mapperParameter = infoParameter[0];
				}
			}
			if (helperParameter == darkFilterTreeNode_0)
			{
				if (mapperParameter.VisibleIndex < darkFilterTreeNode_0.VisibleIndex)
				{
					helperParameter = darkFilterTreeNode_0.PrevVisibleNode;
				}
				else if (mapperParameter.VisibleIndex <= darkFilterTreeNode_0.VisibleIndex)
				{
					helperParameter = mapperParameter;
				}
				else
				{
					helperParameter = darkFilterTreeNode_0.NextVisibleNode;
				}
			}
			if (mapperParameter == darkFilterTreeNode_0)
			{
				if (helperParameter.VisibleIndex < darkFilterTreeNode_0.VisibleIndex)
				{
					mapperParameter = darkFilterTreeNode_0.PrevVisibleNode;
				}
				else if (helperParameter.VisibleIndex <= darkFilterTreeNode_0.VisibleIndex)
				{
					mapperParameter = helperParameter;
				}
				else
				{
					mapperParameter = darkFilterTreeNode_0.NextVisibleNode;
				}
			}
		}
		else
		{
			infoParameter.Add(darkFilterTreeNode_0);
			helperParameter = darkFilterTreeNode_0;
			mapperParameter = darkFilterTreeNode_0;
		}
		Invalidate();
	}

	public Rectangle GetNodeFullRowArea(DarkFilterTreeNode darkFilterTreeNode_0)
	{
		if (darkFilterTreeNode_0.ParentNode != null && !darkFilterTreeNode_0.ParentNode.Expanded)
		{
			return new Rectangle(-1, -1, -1, -1);
		}
		int num = Math.Max(base.ContentSize.Width, base.Viewport.Width);
		return new Rectangle(0, darkFilterTreeNode_0.FullArea.Top, num, ItemHeight);
	}

	public void EnsureVisible()
	{
		if (SelectedNodes.Count == 0)
		{
			return;
		}
		foreach (DarkFilterTreeNode selectedNode in SelectedNodes)
		{
			selectedNode.EnsureVisible();
		}
		int num = -1;
		num = (MultiSelect ? mapperParameter.FullArea.Top : SelectedNodes[0].FullArea.Top);
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
		foreach (DarkFilterTreeNode node in Nodes)
		{
			InvokeRegistry(node);
		}
	}

	private void InvokeRegistry(DarkFilterTreeNode darkFilterTreeNode_0)
	{
		darkFilterTreeNode_0.Nodes.Sort(TreeViewNodeSorter);
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_0.Nodes)
		{
			InvokeRegistry(node);
		}
	}

	public DarkFilterTreeNode FindNode(string string_0)
	{
		foreach (DarkFilterTreeNode node in Nodes)
		{
			DarkFilterTreeNode darkFilterTreeNode = SetupRegistry(node, string_0);
			if (darkFilterTreeNode != null)
			{
				return darkFilterTreeNode;
			}
		}
		return null;
	}

	private DarkFilterTreeNode SetupRegistry(DarkFilterTreeNode darkFilterTreeNode_0, string string_0, bool bool_0 = true)
	{
		if (darkFilterTreeNode_0.FullPath == string_0)
		{
			return darkFilterTreeNode_0;
		}
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_0.Nodes)
		{
			if (!(node.FullPath == string_0))
			{
				if (bool_0)
				{
					DarkFilterTreeNode darkFilterTreeNode = SetupRegistry(node, string_0);
					if (darkFilterTreeNode != null)
					{
						return darkFilterTreeNode;
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
			m_ThreadExpression = new List<DarkFilterTreeNode>();
			foreach (DarkFilterTreeNode selectedNode in SelectedNodes)
			{
				m_ThreadExpression.Add(selectedNode);
			}
			foreach (DarkFilterTreeNode item in m_ThreadExpression.ToList())
			{
				if (item.ParentNode != null && m_ThreadExpression.Contains(item.ParentNode))
				{
					m_ThreadExpression.Remove(item);
				}
			}
			processExpression = false;
			Cursor = Cursors.SizeAll;
			base.StartDrag();
		}
		else
		{
			processExpression = false;
		}
	}

	private void ExcludeRegistry()
	{
		if (!AllowMoveNodes)
		{
			return;
		}
		DarkFilterTreeNode parentNode = decoratorExpression;
		if (parentNode == null)
		{
			if (Cursor != Cursors.No)
			{
				Cursor = Cursors.No;
			}
			return;
		}
		if (ForceDropToParent(parentNode))
		{
			parentNode = parentNode.ParentNode;
		}
		if (CanMoveNodes(m_ThreadExpression, parentNode))
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

	private void IncludeRegistry()
	{
		if (!AllowMoveNodes)
		{
			return;
		}
		DarkFilterTreeNode parentNode = decoratorExpression;
		if (parentNode == null)
		{
			StopDrag();
			return;
		}
		if (ForceDropToParent(parentNode))
		{
			parentNode = parentNode.ParentNode;
		}
		if (CanMoveNodes(m_ThreadExpression, parentNode, bool_0: true))
		{
			List<DarkFilterTreeNode> list = SelectedNodes.ToList();
			MoveNodes(m_ThreadExpression, parentNode);
			foreach (DarkFilterTreeNode item in m_ThreadExpression)
			{
				if (item.ParentNode == null)
				{
					Nodes.Remove(item);
				}
				else
				{
					item.ParentNode.Nodes.Remove(item);
				}
				parentNode.Nodes.Add(item);
			}
			if (TreeViewNodeSorter != null)
			{
				parentNode.Nodes.Sort(TreeViewNodeSorter);
			}
			parentNode.Expanded = true;
			NodesMoved(m_ThreadExpression);
			foreach (DarkFilterTreeNode item2 in list)
			{
				infoParameter.Add(item2);
			}
		}
		StopDrag();
		UpdateNodes();
	}

	protected override void StopDrag()
	{
		m_ThreadExpression = null;
		decoratorExpression = null;
		Cursor = Cursors.Default;
		Invalidate();
		base.StopDrag();
	}

	protected virtual bool ForceDropToParent(DarkFilterTreeNode darkFilterTreeNode_0)
	{
		return false;
	}

	protected virtual bool CanMoveNodes(List<DarkFilterTreeNode> list_0, DarkFilterTreeNode darkFilterTreeNode_0, bool bool_0 = false)
	{
		if (darkFilterTreeNode_0 == null)
		{
			return false;
		}
		foreach (DarkFilterTreeNode item in list_0)
		{
			if (item != darkFilterTreeNode_0)
			{
				if (item.ParentNode == null || item.ParentNode != darkFilterTreeNode_0)
				{
					DarkFilterTreeNode parentNode = darkFilterTreeNode_0.ParentNode;
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

	protected virtual void MoveNodes(List<DarkFilterTreeNode> list_0, DarkFilterTreeNode darkFilterTreeNode_0)
	{
	}

	protected virtual void NodesMoved(List<DarkFilterTreeNode> list_0)
	{
	}

	protected override void PaintContent(Graphics graphics_0)
	{
		Dictionary<DarkFilterTreeNode, bool> dictionary_ = new Dictionary<DarkFilterTreeNode, bool>();
		foreach (DarkFilterTreeNode node in Nodes)
		{
			EnableRegistry(node, graphics_0, dictionary_);
		}
	}

	private bool SearchRegistry(DarkFilterTreeNode darkFilterTreeNode_0, Dictionary<DarkFilterTreeNode, bool> dictionary_0)
	{
		if (string.IsNullOrWhiteSpace(roleParameter))
		{
			return false;
		}
		if (dictionary_0.ContainsKey(darkFilterTreeNode_0))
		{
			return dictionary_0[darkFilterTreeNode_0];
		}
		if (darkFilterTreeNode_0.Text.ToLower().Contains(roleParameter.ToLower()))
		{
			dictionary_0[darkFilterTreeNode_0] = true;
			return true;
		}
		dictionary_0[darkFilterTreeNode_0] = false;
		return false;
	}

	private void EnableRegistry(DarkFilterTreeNode darkFilterTreeNode_0, Graphics graphics_0, Dictionary<DarkFilterTreeNode, bool> dictionary_0)
	{
		bool num = SearchRegistry(darkFilterTreeNode_0, dictionary_0);
		Rectangle nodeFullRowArea = GetNodeFullRowArea(darkFilterTreeNode_0);
		Color color = (darkFilterTreeNode_0.Odd ? Colors.HeaderBackground : Colors.GreyBackground);
		if (SelectedNodes.Count > 0 && SelectedNodes.Contains(darkFilterTreeNode_0))
		{
			color = (Focused ? Colors.BlueSelection : Colors.GreySelection);
		}
		if (base.IsDragging && decoratorExpression == darkFilterTreeNode_0)
		{
			color = (Focused ? Colors.BlueSelection : Colors.GreySelection);
		}
		if (num)
		{
			color = Color.DarkGreen;
		}
		using (SolidBrush brush = new SolidBrush(color))
		{
			graphics_0.FillRectangle(brush, nodeFullRowArea);
		}
		if (darkFilterTreeNode_0.Nodes.Count > 0)
		{
			Point point = new Point(darkFilterTreeNode_0.ExpandArea.Location.X - 1, darkFilterTreeNode_0.ExpandArea.Location.Y - 1);
			Bitmap image = m_ProcParameter;
			if (darkFilterTreeNode_0.Expanded && !darkFilterTreeNode_0.ExpandAreaHot)
			{
				image = m_ProcParameter;
			}
			else if (darkFilterTreeNode_0.Expanded && darkFilterTreeNode_0.ExpandAreaHot && !SelectedNodes.Contains(darkFilterTreeNode_0))
			{
				image = m_StructExpression;
			}
			else if (darkFilterTreeNode_0.Expanded && darkFilterTreeNode_0.ExpandAreaHot && SelectedNodes.Contains(darkFilterTreeNode_0))
			{
				image = m_MerchantExpression;
			}
			else if (!darkFilterTreeNode_0.Expanded && !darkFilterTreeNode_0.ExpandAreaHot)
			{
				image = _ManagerParameter;
			}
			else if (!darkFilterTreeNode_0.Expanded && darkFilterTreeNode_0.ExpandAreaHot && !SelectedNodes.Contains(darkFilterTreeNode_0))
			{
				image = getterParameter;
			}
			else if (!darkFilterTreeNode_0.Expanded && darkFilterTreeNode_0.ExpandAreaHot && SelectedNodes.Contains(darkFilterTreeNode_0))
			{
				image = _ProducerParameter;
			}
			graphics_0.DrawImageUnscaled(image, point);
		}
		if (ShowIcons && darkFilterTreeNode_0.Icon != null)
		{
			if (darkFilterTreeNode_0.Expanded && darkFilterTreeNode_0.ExpandedIcon != null)
			{
				graphics_0.DrawImageUnscaled(darkFilterTreeNode_0.ExpandedIcon, darkFilterTreeNode_0.IconArea.Location);
			}
			else
			{
				graphics_0.DrawImageUnscaled(darkFilterTreeNode_0.Icon, darkFilterTreeNode_0.IconArea.Location);
			}
		}
		graphics_0.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		using (SolidBrush brush2 = new SolidBrush(darkFilterTreeNode_0.ForeColor))
		{
			StringFormat format = new StringFormat
			{
				Alignment = StringAlignment.Near,
				LineAlignment = StringAlignment.Center
			};
			if (darkFilterTreeNode_0.Font == null)
			{
				graphics_0.DrawString(darkFilterTreeNode_0.Text, Font, brush2, darkFilterTreeNode_0.TextArea, format);
			}
			else
			{
				graphics_0.DrawString(darkFilterTreeNode_0.Text, darkFilterTreeNode_0.Font, brush2, darkFilterTreeNode_0.TextArea, format);
			}
		}
		if (!darkFilterTreeNode_0.Expanded)
		{
			return;
		}
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_0.Nodes)
		{
			EnableRegistry(node, graphics_0, dictionary_0);
		}
	}

	public void ExpandAllItems()
	{
		foreach (DarkFilterTreeNode node in Nodes)
		{
			node.Expanded = true;
		}
	}

	public void CollapseAllItem()
	{
		foreach (DarkFilterTreeNode node in Nodes)
		{
			node.Expanded = false;
		}
	}
}
