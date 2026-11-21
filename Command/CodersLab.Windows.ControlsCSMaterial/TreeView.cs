using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace CodersLab.Windows.ControlsCSMaterial;

[ToolboxItem(true)]
public sealed class TreeView : System.Windows.Forms.TreeView
{
	[CompilerGenerated]
	private TreeViewEventHandler decoratorListener;

	[CompilerGenerated]
	private TreeViewEventHandler m_ProcessListener;

	[CompilerGenerated]
	private EventHandler m_ThreadListener;

	private Container m_RuleListener;

	private bool collectionListener;

	private Hashtable instanceListener = new Hashtable();

	private bool _ObjectListener;

	private Hashtable parameterListener = new Hashtable();

	private TreeNode m_ExpressionListener;

	private bool _DispatcherListener;

	private TreeNode m_ListenerListener;

	private TreeNode configListener;

	private int registryListener;

	private TreeViewSelectionMode definitionListener;

	private Color _ValListener = SystemColors.Highlight;

	private bool m_WrapperListener;

	private TreeNode _ObserverListener;

	private TreeNode _IssuerListener;

	public new TreeNode SelectedNode
	{
		get
		{
			if (!collectionListener)
			{
				throw new NotSupportedException("Use SelectedNodes instead of SelectedNode.");
			}
			return base.SelectedNode;
		}
		set
		{
			if (!collectionListener)
			{
				throw new NotSupportedException("Use SelectedNodes instead of SelectedNode.");
			}
			base.SelectedNode = value;
		}
	}

	public TreeViewSelectionMode SelectionMode
	{
		get
		{
			return definitionListener;
		}
		set
		{
			definitionListener = value;
		}
	}

	public Color SelectionBackColor
	{
		get
		{
			return _ValListener;
		}
		set
		{
			_ValListener = value;
		}
	}

	public NodesCollection SelectedNodes
	{
		get
		{
			NodesCollection nodesCollection = new NodesCollection();
			foreach (TreeNode value in instanceListener.Values)
			{
				nodesCollection.Add(value);
			}
			nodesCollection.PushWrapper += FindWrapper;
			nodesCollection.InitWrapper += SetWrapper;
			nodesCollection.IncludeWrapper += FillWrapper;
			nodesCollection.RemoveWrapper += CalculateWrapper;
			return nodesCollection;
		}
	}

	public event TreeViewEventHandler AfterDeselect
	{
		[CompilerGenerated]
		add
		{
			TreeViewEventHandler treeViewEventHandler = decoratorListener;
			TreeViewEventHandler treeViewEventHandler2;
			do
			{
				treeViewEventHandler2 = treeViewEventHandler;
				TreeViewEventHandler value2 = (TreeViewEventHandler)Delegate.Combine(treeViewEventHandler2, value);
				treeViewEventHandler = Interlocked.CompareExchange(ref decoratorListener, value2, treeViewEventHandler2);
			}
			while ((object)treeViewEventHandler != treeViewEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TreeViewEventHandler treeViewEventHandler = decoratorListener;
			TreeViewEventHandler treeViewEventHandler2;
			do
			{
				treeViewEventHandler2 = treeViewEventHandler;
				TreeViewEventHandler value2 = (TreeViewEventHandler)Delegate.Remove(treeViewEventHandler2, value);
				treeViewEventHandler = Interlocked.CompareExchange(ref decoratorListener, value2, treeViewEventHandler2);
			}
			while ((object)treeViewEventHandler != treeViewEventHandler2);
		}
	}

	public event TreeViewEventHandler BeforeDeselect
	{
		[CompilerGenerated]
		add
		{
			TreeViewEventHandler treeViewEventHandler = m_ProcessListener;
			TreeViewEventHandler treeViewEventHandler2;
			do
			{
				treeViewEventHandler2 = treeViewEventHandler;
				TreeViewEventHandler value2 = (TreeViewEventHandler)Delegate.Combine(treeViewEventHandler2, value);
				treeViewEventHandler = Interlocked.CompareExchange(ref m_ProcessListener, value2, treeViewEventHandler2);
			}
			while ((object)treeViewEventHandler != treeViewEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TreeViewEventHandler treeViewEventHandler = m_ProcessListener;
			TreeViewEventHandler treeViewEventHandler2;
			do
			{
				treeViewEventHandler2 = treeViewEventHandler;
				TreeViewEventHandler value2 = (TreeViewEventHandler)Delegate.Remove(treeViewEventHandler2, value);
				treeViewEventHandler = Interlocked.CompareExchange(ref m_ProcessListener, value2, treeViewEventHandler2);
			}
			while ((object)treeViewEventHandler != treeViewEventHandler2);
		}
	}

	public event EventHandler SelectionsChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = m_ThreadListener;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_ThreadListener, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = m_ThreadListener;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_ThreadListener, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public TreeView()
	{
		ResolveWrapper();
		SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
		SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
		UpdateStyles();
	}

	protected void OnAfterDeselect(TreeNode treeNode_0)
	{
		if (decoratorListener != null)
		{
			decoratorListener(this, new TreeViewEventArgs(treeNode_0));
		}
	}

	protected void OnBeforeDeselect(TreeNode treeNode_0)
	{
		if (m_ProcessListener != null)
		{
			m_ProcessListener(this, new TreeViewEventArgs(treeNode_0));
		}
	}

	protected void OnSelectionsChanged()
	{
		if (_ObjectListener && m_ThreadListener != null)
		{
			m_ThreadListener(this, new EventArgs());
		}
	}

	private void FindWrapper(TreeNode treeNode_0)
	{
		_ObjectListener = false;
		InsertWrapper(treeNode_0, bool_0: true, TreeViewAction.Unknown);
		OnSelectionsChanged();
	}

	private void SetWrapper(TreeNode treeNode_0)
	{
		_ObjectListener = false;
		InsertWrapper(treeNode_0, bool_0: true, TreeViewAction.Unknown);
		OnSelectionsChanged();
	}

	private void FillWrapper(TreeNode treeNode_0)
	{
		_ObjectListener = false;
		InsertWrapper(treeNode_0, bool_0: false, TreeViewAction.Unknown);
		OnSelectionsChanged();
		if (configListener == treeNode_0)
		{
			configListener = null;
		}
	}

	private void CalculateWrapper(object sender, EventArgs e)
	{
		_ObjectListener = false;
		PopWrapper(TreeViewAction.Unknown);
		OnSelectionsChanged();
	}

	private void PopWrapper(TreeViewAction treeViewAction_0)
	{
		ReadWrapper(null, treeViewAction_0);
	}

	private void InstantiateWrapper(int int_0, TreeViewAction treeViewAction_0)
	{
		ArrayList arrayList = new ArrayList();
		foreach (TreeNode value in instanceListener.Values)
		{
			if (GetNodeLevel(value) != int_0)
			{
				arrayList.Add(value);
			}
		}
		foreach (TreeNode item in arrayList)
		{
			InsertWrapper(item, bool_0: false, treeViewAction_0);
		}
	}

	private void CreateWrapper(TreeNode treeNode_0, TreeViewAction treeViewAction_0)
	{
		ArrayList arrayList = new ArrayList();
		foreach (TreeNode value in instanceListener.Values)
		{
			if (value.Parent != treeNode_0)
			{
				arrayList.Add(value);
			}
		}
		foreach (TreeNode item in arrayList)
		{
			InsertWrapper(item, bool_0: false, treeViewAction_0);
		}
	}

	private void CompareWrapper(TreeNode treeNode_0, TreeViewAction treeViewAction_0)
	{
		ArrayList arrayList = new ArrayList();
		foreach (TreeNode value in instanceListener.Values)
		{
			if (!TestWrapper(value, treeNode_0))
			{
				arrayList.Add(value);
			}
		}
		foreach (TreeNode item in arrayList)
		{
			InsertWrapper(item, bool_0: false, treeViewAction_0);
		}
	}

	private void ReadWrapper(TreeNode treeNode_0, TreeViewAction treeViewAction_0)
	{
		ArrayList arrayList = new ArrayList();
		foreach (TreeNode value in instanceListener.Values)
		{
			if (treeNode_0 == null)
			{
				arrayList.Add(value);
			}
			else if (treeNode_0 != null && value != treeNode_0)
			{
				arrayList.Add(value);
			}
		}
		foreach (TreeNode item in arrayList)
		{
			InsertWrapper(item, bool_0: false, treeViewAction_0);
		}
	}

	protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
	{
		e.Cancel = true;
	}

	private bool DisableWrapper(TreeNode treeNode_0)
	{
		if (treeNode_0 == null)
		{
			return false;
		}
		return instanceListener.ContainsKey(treeNode_0.GetHashCode());
	}

	private void UpdateWrapper(TreeNode treeNode_0)
	{
		if (treeNode_0 != null && !parameterListener.ContainsKey(treeNode_0.GetHashCode()))
		{
			parameterListener.Add(treeNode_0.GetHashCode(), new Color[2] { treeNode_0.BackColor, treeNode_0.ForeColor });
		}
	}

	private bool InsertWrapper(TreeNode treeNode_0, bool bool_0, TreeViewAction treeViewAction_0)
	{
		bool result = false;
		if (treeNode_0 == null)
		{
			return false;
		}
		if (bool_0)
		{
			if (!DisableWrapper(treeNode_0))
			{
				TreeViewCancelEventArgs treeViewCancelEventArgs = new TreeViewCancelEventArgs(treeNode_0, cancel: false, treeViewAction_0);
				base.OnBeforeSelect(treeViewCancelEventArgs);
				if (treeViewCancelEventArgs.Cancel)
				{
					return false;
				}
				UpdateWrapper(treeNode_0);
				treeNode_0.BackColor = SelectionBackColor;
				treeNode_0.ForeColor = BackColor;
				instanceListener.Add(treeNode_0.GetHashCode(), treeNode_0);
				result = true;
				_ObjectListener = true;
				base.OnAfterSelect(new TreeViewEventArgs(treeNode_0, treeViewAction_0));
			}
			m_ListenerListener = treeNode_0;
		}
		else if (DisableWrapper(treeNode_0))
		{
			OnBeforeDeselect(treeNode_0);
			Color[] array = (Color[])parameterListener[treeNode_0.GetHashCode()];
			if (array != null)
			{
				instanceListener.Remove(treeNode_0.GetHashCode());
				_ObjectListener = true;
				parameterListener.Remove(treeNode_0.GetHashCode());
				treeNode_0.BackColor = array[0];
				treeNode_0.ForeColor = array[1];
			}
			OnAfterDeselect(treeNode_0);
		}
		return result;
	}

	private void PrepareWrapper(TreeNode treeNode_0, TreeNode treeNode_1, TreeViewAction treeViewAction_0)
	{
		TreeNode treeNode = null;
		TreeNode treeNode2 = null;
		if (treeNode_0.Bounds.Y < treeNode_1.Bounds.Y)
		{
			treeNode = treeNode_0;
			treeNode2 = treeNode_1;
		}
		else
		{
			treeNode = treeNode_1;
			treeNode2 = treeNode_0;
		}
		InsertWrapper(treeNode, bool_0: true, treeViewAction_0);
		TreeNode treeNode3 = treeNode;
		while (treeNode3 != treeNode2)
		{
			treeNode3 = treeNode3.NextVisibleNode;
			if (treeNode3 != null)
			{
				InsertWrapper(treeNode3, bool_0: true, treeViewAction_0);
			}
		}
		InsertWrapper(treeNode2, bool_0: true, treeViewAction_0);
	}

	private void ReflectWrapper(TreeNode treeNode_0, TreeNode treeNode_1, TreeViewAction treeViewAction_0)
	{
		TreeNode treeNode = null;
		TreeNode treeNode2 = null;
		if (treeNode_0.Bounds.Y < treeNode_1.Bounds.Y)
		{
			treeNode = treeNode_0;
			treeNode2 = treeNode_1;
		}
		else
		{
			treeNode = treeNode_1;
			treeNode2 = treeNode_0;
		}
		TreeNode treeNode3 = treeNode;
		while (treeNode3 != null)
		{
			treeNode3 = treeNode3.PrevVisibleNode;
			if (treeNode3 != null)
			{
				InsertWrapper(treeNode3, bool_0: false, treeViewAction_0);
			}
		}
		treeNode3 = treeNode2;
		while (treeNode3 != null)
		{
			treeNode3 = treeNode3.NextVisibleNode;
			if (treeNode3 != null)
			{
				InsertWrapper(treeNode3, bool_0: false, treeViewAction_0);
			}
		}
	}

	private void VisitWrapper(TreeNode treeNode_0, TreeViewAction treeViewAction_0)
	{
		InsertWrapper(treeNode_0, bool_0: false, treeViewAction_0);
		foreach (TreeNode node in treeNode_0.Nodes)
		{
			VisitWrapper(node, treeViewAction_0);
		}
	}

	private bool RestartWrapper(TreeNode treeNode_0, MouseEventArgs mouseEventArgs_0)
	{
		if (treeNode_0 == null)
		{
			return false;
		}
		int num = treeNode_0.Bounds.X + treeNode_0.Bounds.Width;
		if (treeNode_0 == null)
		{
			return false;
		}
		return mouseEventArgs_0.X < num;
	}

	public int GetNodeLevel(TreeNode treeNode_0)
	{
		int num = 0;
		while ((treeNode_0 = treeNode_0.Parent) != null)
		{
			num++;
		}
		return num;
	}

	private bool TestWrapper(TreeNode treeNode_0, TreeNode treeNode_1)
	{
		bool result = false;
		TreeNode treeNode = treeNode_0;
		while (treeNode != null)
		{
			if (treeNode != treeNode_1)
			{
				treeNode = treeNode.Parent;
				continue;
			}
			result = true;
			break;
		}
		return result;
	}

	public TreeNode GetRootParent(TreeNode treeNode_0)
	{
		TreeNode treeNode = treeNode_0;
		while (treeNode.Parent != null)
		{
			treeNode = treeNode.Parent;
		}
		return treeNode;
	}

	private int StopWrapper()
	{
		int num = 0;
		for (TreeNode treeNode = base.Nodes[0]; treeNode != null; treeNode = treeNode.NextVisibleNode)
		{
			if (treeNode.IsVisible)
			{
				num++;
			}
		}
		return num;
	}

	private TreeNode CancelWrapper()
	{
		TreeNode treeNode = base.Nodes[0];
		while (treeNode.NextVisibleNode != null)
		{
			treeNode = treeNode.NextVisibleNode;
		}
		return treeNode;
	}

	private TreeNode VerifyWrapper(TreeNode treeNode_0, bool bool_0, int int_0)
	{
		int i = 0;
		TreeNode treeNode = treeNode_0;
		for (; i < int_0; i++)
		{
			if (bool_0)
			{
				if (treeNode.NextVisibleNode == null)
				{
					break;
				}
				treeNode = treeNode.NextVisibleNode;
			}
			else
			{
				if (treeNode.PrevVisibleNode == null)
				{
					break;
				}
				treeNode = treeNode.PrevVisibleNode;
			}
		}
		return treeNode;
	}

	private void ListWrapper(TreeNode treeNode_0, bool bool_0)
	{
		Graphics graphics = CreateGraphics();
		Rectangle rectangle = new Rectangle(treeNode_0.Bounds.X, treeNode_0.Bounds.Y, treeNode_0.Bounds.Width, treeNode_0.Bounds.Height);
		if (bool_0)
		{
			Invalidate(rectangle, invalidateChildren: false);
			Update();
			if (treeNode_0.BackColor != SelectionBackColor)
			{
				graphics.DrawRectangle(new Pen(new SolidBrush(SelectionBackColor), 1f), rectangle);
			}
		}
		else
		{
			if (treeNode_0.BackColor != SelectionBackColor)
			{
				graphics.DrawRectangle(new Pen(new SolidBrush(BackColor), 1f), m_ListenerListener.Bounds.X, m_ListenerListener.Bounds.Y, m_ListenerListener.Bounds.Width, m_ListenerListener.Bounds.Height);
			}
			Invalidate(rectangle, invalidateChildren: false);
			Update();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && m_RuleListener != null)
		{
			m_RuleListener.Dispose();
		}
		base.Dispose(disposing);
	}

	private void ResolveWrapper()
	{
		m_RuleListener = new Container();
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		if (!m_WrapperListener)
		{
			TreeNode nodeAt = GetNodeAt(mevent.X, mevent.Y);
			if (RestartWrapper(nodeAt, mevent))
			{
				AssetWrapper(m_ListenerListener, nodeAt, mevent, Control.ModifierKeys, TreeViewAction.ByMouse, bool_0: true);
			}
		}
		m_WrapperListener = false;
		base.OnMouseUp(mevent);
	}

	private bool PostWrapper(TreeNode treeNode_0, MouseEventArgs mouseEventArgs_0)
	{
		int nodeLevel = GetNodeLevel(treeNode_0);
		bool result = false;
		if (mouseEventArgs_0.X < 20 + nodeLevel * 20)
		{
			result = true;
		}
		return result;
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		_IssuerListener = null;
		registryListener = e.Clicks;
		TreeNode nodeAt = GetNodeAt(e.X, e.Y);
		if (nodeAt != null)
		{
			UpdateWrapper(nodeAt);
			if (!PostWrapper(nodeAt, e) && nodeAt != null && RestartWrapper(nodeAt, e) && !DisableWrapper(nodeAt))
			{
				_ObserverListener = nodeAt;
				new Thread(RunWrapper).Start();
				m_WrapperListener = true;
				AssetWrapper(m_ListenerListener, nodeAt, e, Control.ModifierKeys, TreeViewAction.ByMouse, bool_0: true);
			}
			base.OnMouseDown(e);
		}
	}

	private void RunWrapper()
	{
		if (base.InvokeRequired)
		{
			Invoke((MethodInvoker)delegate
			{
				RunWrapper();
			});
			return;
		}
		TreeNode observerListener = _ObserverListener;
		if (!DisableWrapper(observerListener))
		{
			observerListener.BackColor = SelectionBackColor;
			observerListener.ForeColor = BackColor;
			Invalidate();
			Refresh();
			Application.DoEvents();
			Thread.Sleep(200);
		}
		if (!DisableWrapper(observerListener))
		{
			observerListener.BackColor = BackColor;
			observerListener.ForeColor = ForeColor;
		}
	}

	private void StartWrapper()
	{
		Thread.Sleep(200);
		if (_DispatcherListener)
		{
			_DispatcherListener = false;
			return;
		}
		collectionListener = true;
		SelectedNode = m_ExpressionListener;
		collectionListener = false;
		m_ExpressionListener.BeginEdit();
	}

	private void AssetWrapper(TreeNode treeNode_0, TreeNode treeNode_1, MouseEventArgs mouseEventArgs_0, Keys keys_0, TreeViewAction treeViewAction_0, bool bool_0)
	{
		_ObjectListener = false;
		if (mouseEventArgs_0.Button == MouseButtons.Left)
		{
			_DispatcherListener = registryListener == 2;
			TreeNode treeNode = null;
			if ((keys_0 & Keys.Control) == 0 && (keys_0 & Keys.Shift) == 0)
			{
				configListener = treeNode_1;
				int count = SelectedNodes.Count;
				if (_DispatcherListener)
				{
					base.OnMouseDown(mouseEventArgs_0);
					return;
				}
				if (!PostWrapper(treeNode_1, mouseEventArgs_0))
				{
					bool flag = false;
					if (DisableWrapper(treeNode_1))
					{
						flag = true;
					}
					ReadWrapper(treeNode_1, treeViewAction_0);
					InsertWrapper(treeNode_1, bool_0: true, treeViewAction_0);
					if (flag && base.LabelEdit && bool_0 && !_DispatcherListener && count <= 1)
					{
						m_ExpressionListener = treeNode_1;
						new Thread(StartWrapper).Start();
					}
				}
			}
			else if ((keys_0 & Keys.Control) != 0 && (keys_0 & Keys.Shift) == 0)
			{
				configListener = null;
				if (DisableWrapper(treeNode_1))
				{
					InsertWrapper(treeNode_1, bool_0: false, treeViewAction_0);
				}
				else
				{
					switch (definitionListener)
					{
					case TreeViewSelectionMode.SingleSelect:
						ReadWrapper(treeNode_1, treeViewAction_0);
						break;
					case TreeViewSelectionMode.MultiSelectSameRootBranch:
					{
						TreeNode rootParent2 = GetRootParent(treeNode_1);
						CompareWrapper(rootParent2, treeViewAction_0);
						break;
					}
					case TreeViewSelectionMode.MultiSelectSameLevel:
						InstantiateWrapper(GetNodeLevel(treeNode_1), treeViewAction_0);
						break;
					case TreeViewSelectionMode.MultiSelectSameLevelAndRootBranch:
					{
						TreeNode rootParent = GetRootParent(treeNode_1);
						CompareWrapper(rootParent, treeViewAction_0);
						InstantiateWrapper(GetNodeLevel(treeNode_1), treeViewAction_0);
						break;
					}
					case TreeViewSelectionMode.MultiSelectSameParent:
					{
						TreeNode treeNode_2 = treeNode_1.Parent;
						CreateWrapper(treeNode_2, treeViewAction_0);
						break;
					}
					}
					InsertWrapper(treeNode_1, bool_0: true, treeViewAction_0);
				}
			}
			else if ((keys_0 & Keys.Control) == 0 && (keys_0 & Keys.Shift) != 0)
			{
				if (treeNode_0 == null)
				{
					ReadWrapper(treeNode_1, treeViewAction_0);
					InsertWrapper(treeNode_1, bool_0: true, treeViewAction_0);
				}
				else
				{
					if (configListener == null)
					{
						configListener = treeNode_0;
					}
					switch (definitionListener)
					{
					case TreeViewSelectionMode.SingleSelect:
						ReadWrapper(treeNode_1, treeViewAction_0);
						InsertWrapper(treeNode_1, bool_0: true, treeViewAction_0);
						break;
					case TreeViewSelectionMode.MultiSelect:
						PrepareWrapper(configListener, treeNode_1, treeViewAction_0);
						ReflectWrapper(configListener, treeNode_1, treeViewAction_0);
						break;
					case TreeViewSelectionMode.MultiSelectSameRootBranch:
					{
						TreeNode rootParent5 = GetRootParent(treeNode_0);
						treeNode = treeNode_0;
						while (treeNode != null && treeNode != treeNode_1)
						{
							treeNode = ((treeNode_0.Bounds.Y <= treeNode_1.Bounds.Y) ? treeNode.NextVisibleNode : treeNode.PrevVisibleNode);
							if (treeNode != null && GetRootParent(treeNode) == rootParent5)
							{
								InsertWrapper(treeNode, bool_0: true, treeViewAction_0);
							}
						}
						CompareWrapper(rootParent5, treeViewAction_0);
						ReflectWrapper(configListener, treeNode_1, treeViewAction_0);
						break;
					}
					case TreeViewSelectionMode.MultiSelectSameLevel:
					{
						int nodeLevel = GetNodeLevel(treeNode_0);
						treeNode = treeNode_0;
						while (treeNode != null && treeNode != treeNode_1)
						{
							treeNode = ((treeNode_0.Bounds.Y <= treeNode_1.Bounds.Y) ? treeNode.NextVisibleNode : treeNode.PrevVisibleNode);
							if (treeNode != null && GetNodeLevel(treeNode) == nodeLevel)
							{
								InsertWrapper(treeNode, bool_0: true, treeViewAction_0);
							}
						}
						InstantiateWrapper(nodeLevel, treeViewAction_0);
						ReflectWrapper(configListener, treeNode_1, treeViewAction_0);
						break;
					}
					case TreeViewSelectionMode.MultiSelectSameLevelAndRootBranch:
					{
						TreeNode rootParent3 = GetRootParent(treeNode_0);
						int nodeLevel2 = GetNodeLevel(treeNode_0);
						treeNode = treeNode_0;
						while (treeNode != null && treeNode != treeNode_1)
						{
							treeNode = ((treeNode_0.Bounds.Y <= treeNode_1.Bounds.Y) ? treeNode.NextVisibleNode : treeNode.PrevVisibleNode);
							if (treeNode != null)
							{
								int nodeLevel3 = GetNodeLevel(treeNode);
								TreeNode rootParent4 = GetRootParent(treeNode);
								if (nodeLevel3 == nodeLevel2 && rootParent4 == rootParent3)
								{
									InsertWrapper(treeNode, bool_0: true, treeViewAction_0);
								}
							}
						}
						CompareWrapper(rootParent3, treeViewAction_0);
						InstantiateWrapper(nodeLevel2, treeViewAction_0);
						ReflectWrapper(configListener, treeNode_1, treeViewAction_0);
						break;
					}
					case TreeViewSelectionMode.MultiSelectSameParent:
					{
						TreeNode treeNode2 = treeNode_0.Parent;
						treeNode = treeNode_0;
						while (treeNode != null && treeNode != treeNode_1)
						{
							treeNode = ((treeNode_0.Bounds.Y <= treeNode_1.Bounds.Y) ? treeNode.NextVisibleNode : treeNode.PrevVisibleNode);
							if (treeNode != null && treeNode.Parent == treeNode2)
							{
								InsertWrapper(treeNode, bool_0: true, treeViewAction_0);
							}
						}
						CreateWrapper(treeNode2, treeViewAction_0);
						ReflectWrapper(configListener, treeNode_1, treeViewAction_0);
						break;
					}
					}
				}
			}
			else if ((keys_0 & Keys.Control) != 0 && (keys_0 & Keys.Shift) != 0)
			{
				switch (definitionListener)
				{
				case TreeViewSelectionMode.SingleSelect:
					ReadWrapper(treeNode_1, treeViewAction_0);
					InsertWrapper(treeNode_1, bool_0: true, treeViewAction_0);
					break;
				case TreeViewSelectionMode.MultiSelect:
					treeNode = treeNode_0;
					while (treeNode != null && treeNode != treeNode_1)
					{
						treeNode = ((treeNode_0.Bounds.Y <= treeNode_1.Bounds.Y) ? treeNode.NextVisibleNode : treeNode.PrevVisibleNode);
						if (treeNode != null)
						{
							InsertWrapper(treeNode, bool_0: true, treeViewAction_0);
						}
					}
					break;
				case TreeViewSelectionMode.MultiSelectSameRootBranch:
				{
					TreeNode rootParent8 = GetRootParent(treeNode_0);
					treeNode = treeNode_0;
					while (treeNode != null && treeNode != treeNode_1)
					{
						treeNode = ((treeNode_0.Bounds.Y <= treeNode_1.Bounds.Y) ? treeNode.NextVisibleNode : treeNode.PrevVisibleNode);
						if (treeNode != null && GetRootParent(treeNode) == rootParent8)
						{
							InsertWrapper(treeNode, bool_0: true, treeViewAction_0);
						}
					}
					CompareWrapper(rootParent8, treeViewAction_0);
					break;
				}
				case TreeViewSelectionMode.MultiSelectSameLevel:
				{
					int nodeLevel4 = GetNodeLevel(treeNode_0);
					treeNode = treeNode_0;
					while (treeNode != null && treeNode != treeNode_1)
					{
						treeNode = ((treeNode_0.Bounds.Y <= treeNode_1.Bounds.Y) ? treeNode.NextVisibleNode : treeNode.PrevVisibleNode);
						if (treeNode != null && GetNodeLevel(treeNode) == nodeLevel4)
						{
							InsertWrapper(treeNode, bool_0: true, treeViewAction_0);
						}
					}
					InstantiateWrapper(nodeLevel4, treeViewAction_0);
					break;
				}
				case TreeViewSelectionMode.MultiSelectSameLevelAndRootBranch:
				{
					TreeNode rootParent6 = GetRootParent(treeNode_0);
					int nodeLevel5 = GetNodeLevel(treeNode_0);
					treeNode = treeNode_0;
					while (treeNode != null && treeNode != treeNode_1)
					{
						treeNode = ((treeNode_0.Bounds.Y <= treeNode_1.Bounds.Y) ? treeNode.NextVisibleNode : treeNode.PrevVisibleNode);
						if (treeNode != null)
						{
							int nodeLevel6 = GetNodeLevel(treeNode);
							TreeNode rootParent7 = GetRootParent(treeNode);
							if (nodeLevel6 == nodeLevel5 && rootParent7 == rootParent6)
							{
								InsertWrapper(treeNode, bool_0: true, treeViewAction_0);
							}
						}
					}
					CompareWrapper(rootParent6, treeViewAction_0);
					InstantiateWrapper(nodeLevel5, treeViewAction_0);
					break;
				}
				case TreeViewSelectionMode.MultiSelectSameParent:
				{
					TreeNode treeNode3 = treeNode_0.Parent;
					treeNode = treeNode_0;
					while (treeNode != null && treeNode != treeNode_1)
					{
						treeNode = ((treeNode_0.Bounds.Y <= treeNode_1.Bounds.Y) ? treeNode.NextVisibleNode : treeNode.PrevVisibleNode);
						if (treeNode != null && treeNode.Parent == treeNode3)
						{
							InsertWrapper(treeNode, bool_0: true, treeViewAction_0);
						}
					}
					CreateWrapper(treeNode3, treeViewAction_0);
					break;
				}
				}
			}
		}
		else if (mouseEventArgs_0.Button == MouseButtons.Right && !DisableWrapper(treeNode_1))
		{
			PopWrapper(treeViewAction_0);
			InsertWrapper(treeNode_1, bool_0: true, treeViewAction_0);
		}
		OnSelectionsChanged();
	}

	protected override void OnBeforeLabelEdit(NodeLabelEditEventArgs e)
	{
		_ObjectListener = false;
		InsertWrapper(e.Node, bool_0: true, TreeViewAction.ByMouse);
		ReadWrapper(e.Node, TreeViewAction.ByMouse);
		OnSelectionsChanged();
		base.OnBeforeLabelEdit(e);
	}

	protected override void OnKeyDown(KeyEventArgs ke)
	{
		Keys keys_ = Keys.None;
		Keys modifiers = ke.Modifiers;
		if (modifiers != Keys.Shift && modifiers != Keys.Control && modifiers != (Keys.Shift | Keys.Control))
		{
			_IssuerListener = null;
		}
		else
		{
			keys_ = Keys.Shift;
			if (_IssuerListener == null)
			{
				_IssuerListener = m_ListenerListener;
			}
		}
		int num = 0;
		TreeNode treeNode = null;
		switch (ke.KeyCode)
		{
		default:
			base.OnKeyDown(ke);
			return;
		case Keys.Prior:
			num = StopWrapper();
			treeNode = VerifyWrapper(m_ListenerListener, bool_0: false, num);
			break;
		case Keys.Next:
			num = StopWrapper();
			treeNode = VerifyWrapper(m_ListenerListener, bool_0: true, num);
			break;
		case Keys.End:
			treeNode = CancelWrapper();
			break;
		case Keys.Home:
			treeNode = base.Nodes[0];
			break;
		case Keys.Left:
			if (m_ListenerListener.IsExpanded)
			{
				m_ListenerListener.Collapse();
			}
			else
			{
				treeNode = m_ListenerListener.Parent;
			}
			break;
		case Keys.Up:
			treeNode = m_ListenerListener.PrevVisibleNode;
			break;
		case Keys.Right:
			if (m_ListenerListener.IsExpanded)
			{
				if (m_ListenerListener.Nodes != null)
				{
					treeNode = m_ListenerListener.Nodes[0];
				}
			}
			else
			{
				m_ListenerListener.Expand();
			}
			break;
		case Keys.Down:
			treeNode = m_ListenerListener.NextVisibleNode;
			break;
		}
		if (treeNode != null)
		{
			ListWrapper(m_ListenerListener, bool_0: false);
			AssetWrapper(_IssuerListener, treeNode, new MouseEventArgs(MouseButtons.Left, 1, Cursor.Position.X, Cursor.Position.Y, 0), keys_, TreeViewAction.ByKeyboard, bool_0: false);
			m_ListenerListener = treeNode;
			ListWrapper(m_ListenerListener, bool_0: true);
		}
		if (m_ListenerListener != null)
		{
			TreeNode treeNode2 = null;
			switch (ke.KeyCode)
			{
			case Keys.Prior:
				treeNode2 = VerifyWrapper(m_ListenerListener, bool_0: false, num - 2);
				break;
			case Keys.Next:
				treeNode2 = VerifyWrapper(m_ListenerListener, bool_0: true, num - 2);
				break;
			case Keys.End:
			case Keys.Home:
				treeNode2 = m_ListenerListener;
				break;
			case Keys.Left:
			case Keys.Up:
				treeNode2 = VerifyWrapper(m_ListenerListener, bool_0: false, 5);
				break;
			case Keys.Right:
			case Keys.Down:
				treeNode2 = VerifyWrapper(m_ListenerListener, bool_0: true, 5);
				break;
			}
			treeNode2?.EnsureVisible();
		}
		base.OnKeyDown(ke);
	}

	protected override void OnAfterCollapse(TreeViewEventArgs e)
	{
		_ObjectListener = false;
		bool flag = false;
		foreach (TreeNode node in e.Node.Nodes)
		{
			if (DisableWrapper(node))
			{
				flag = true;
			}
			VisitWrapper(node, TreeViewAction.Collapse);
		}
		if (flag)
		{
			InsertWrapper(e.Node, bool_0: true, TreeViewAction.Collapse);
		}
		OnSelectionsChanged();
		base.OnAfterCollapse(e);
	}

	protected override void OnItemDrag(ItemDragEventArgs e)
	{
		e = new ItemDragEventArgs(MouseButtons.Left, SelectedNodes);
		base.OnItemDrag(e);
	}

	[CompilerGenerated]
	private void PrintWrapper()
	{
		RunWrapper();
	}
}
