using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using DarkUI.Collections;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkFilterTreeNode
{
	[CompilerGenerated]
	private EventHandler<ObservableListModified<DarkFilterTreeNode>> _MockParameter;

	[CompilerGenerated]
	private EventHandler<ObservableListModified<DarkFilterTreeNode>> _TagParameter;

	[CompilerGenerated]
	private EventHandler fieldParameter;

	[CompilerGenerated]
	private EventHandler m_QueueParameter;

	[CompilerGenerated]
	private EventHandler m_RegParameter;

	private string paramParameter;

	private bool _PageParameter;

	private DarkFilterTreeView _RulesParameter;

	private DarkFilterTreeNode _MethodParameter;

	private ObservableList<DarkFilterTreeNode> _ServiceParameter;

	private bool m_SystemParameter;

	[CompilerGenerated]
	private Rectangle m_BaseParameter;

	[CompilerGenerated]
	private Rectangle m_PolicyParameter;

	[CompilerGenerated]
	private Rectangle m_BroadcasterParameter;

	[CompilerGenerated]
	private bool m_PrinterParameter;

	[CompilerGenerated]
	private Bitmap m_ParserParameter;

	[CompilerGenerated]
	private Bitmap m_AlgoParameter;

	[CompilerGenerated]
	private bool databaseParameter;

	[CompilerGenerated]
	private int annotationParameter;

	[CompilerGenerated]
	private Color iteratorParameter;

	public string Text
	{
		get
		{
			return paramParameter;
		}
		set
		{
			if (paramParameter != value)
			{
				paramParameter = value;
				OrderConfig();
			}
		}
	}

	public Rectangle ExpandArea
	{
		[CompilerGenerated]
		get
		{
			return m_BaseParameter;
		}
		[CompilerGenerated]
		set
		{
			m_BaseParameter = value;
		}
	}

	public Rectangle IconArea
	{
		[CompilerGenerated]
		get
		{
			return m_PolicyParameter;
		}
		[CompilerGenerated]
		set
		{
			m_PolicyParameter = value;
		}
	}

	public Rectangle TextArea
	{
		[CompilerGenerated]
		get
		{
			return m_BroadcasterParameter;
		}
		[CompilerGenerated]
		set
		{
			m_BroadcasterParameter = value;
		}
	}

	public Rectangle FullArea { get; set; }

	public bool ExpandAreaHot
	{
		[CompilerGenerated]
		get
		{
			return m_PrinterParameter;
		}
		[CompilerGenerated]
		set
		{
			m_PrinterParameter = value;
		}
	}

	public Bitmap Icon
	{
		[CompilerGenerated]
		get
		{
			return m_ParserParameter;
		}
		[CompilerGenerated]
		set
		{
			m_ParserParameter = value;
		}
	}

	public Bitmap ExpandedIcon
	{
		[CompilerGenerated]
		get
		{
			return m_AlgoParameter;
		}
		[CompilerGenerated]
		set
		{
			m_AlgoParameter = value;
		}
	}

	public bool Expanded
	{
		get
		{
			return m_SystemParameter;
		}
		set
		{
			if (m_SystemParameter == value || (value && Nodes.Count == 0))
			{
				return;
			}
			m_SystemParameter = value;
			if (m_SystemParameter)
			{
				if (m_QueueParameter != null)
				{
					m_QueueParameter(this, null);
				}
			}
			else if (m_RegParameter != null)
			{
				m_RegParameter(this, null);
			}
			ParentTree?.UpdateNodes();
		}
	}

	public ObservableList<DarkFilterTreeNode> Nodes
	{
		get
		{
			return _ServiceParameter;
		}
		set
		{
			if (_ServiceParameter != null)
			{
				_ServiceParameter.ItemsAdded -= RegisterConfig;
				_ServiceParameter.ItemsRemoved -= ManageConfig;
			}
			_ServiceParameter = value;
			_ServiceParameter.ItemsAdded += RegisterConfig;
			_ServiceParameter.ItemsRemoved += ManageConfig;
		}
	}

	public bool IsRoot
	{
		get
		{
			return _PageParameter;
		}
		set
		{
			_PageParameter = value;
		}
	}

	public DarkFilterTreeView ParentTree
	{
		get
		{
			return _RulesParameter;
		}
		set
		{
			if (_RulesParameter == value)
			{
				return;
			}
			_RulesParameter = value;
			foreach (DarkFilterTreeNode node in Nodes)
			{
				node.ParentTree = _RulesParameter;
			}
		}
	}

	public DarkFilterTreeNode ParentNode
	{
		get
		{
			return _MethodParameter;
		}
		set
		{
			_MethodParameter = value;
		}
	}

	public bool Odd
	{
		[CompilerGenerated]
		get
		{
			return databaseParameter;
		}
		[CompilerGenerated]
		set
		{
			databaseParameter = value;
		}
	}

	public object NodeType { get; set; }

	public object Tag { get; set; }

	public string FullPath
	{
		get
		{
			DarkFilterTreeNode parentNode = ParentNode;
			string text = Text;
			while (parentNode != null)
			{
				text = string.Format("{0}{1}{2}", parentNode.Text, "\\", text);
				parentNode = parentNode.ParentNode;
			}
			return text;
		}
	}

	public DarkFilterTreeNode PrevVisibleNode { get; set; }

	public DarkFilterTreeNode NextVisibleNode { get; set; }

	public int VisibleIndex
	{
		[CompilerGenerated]
		get
		{
			return annotationParameter;
		}
		[CompilerGenerated]
		set
		{
			annotationParameter = value;
		}
	}

	public Color ForeColor
	{
		[CompilerGenerated]
		get
		{
			return iteratorParameter;
		}
		[CompilerGenerated]
		set
		{
			iteratorParameter = value;
		}
	}

	public Font Font { get; set; }

	public event EventHandler<ObservableListModified<DarkFilterTreeNode>> ItemsAdded
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ObservableListModified<DarkFilterTreeNode>> eventHandler = _MockParameter;
			EventHandler<ObservableListModified<DarkFilterTreeNode>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<DarkFilterTreeNode>> value2 = (EventHandler<ObservableListModified<DarkFilterTreeNode>>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _MockParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ObservableListModified<DarkFilterTreeNode>> eventHandler = _MockParameter;
			EventHandler<ObservableListModified<DarkFilterTreeNode>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<DarkFilterTreeNode>> value2 = (EventHandler<ObservableListModified<DarkFilterTreeNode>>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _MockParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<ObservableListModified<DarkFilterTreeNode>> ItemsRemoved
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ObservableListModified<DarkFilterTreeNode>> eventHandler = _TagParameter;
			EventHandler<ObservableListModified<DarkFilterTreeNode>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<DarkFilterTreeNode>> value2 = (EventHandler<ObservableListModified<DarkFilterTreeNode>>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _TagParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ObservableListModified<DarkFilterTreeNode>> eventHandler = _TagParameter;
			EventHandler<ObservableListModified<DarkFilterTreeNode>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<DarkFilterTreeNode>> value2 = (EventHandler<ObservableListModified<DarkFilterTreeNode>>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _TagParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler TextChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = fieldParameter;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref fieldParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = fieldParameter;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref fieldParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler NodeExpanded
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = m_QueueParameter;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_QueueParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = m_QueueParameter;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_QueueParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler NodeCollapsed
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = m_RegParameter;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_RegParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = m_RegParameter;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_RegParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public bool IsNodeAncestor(DarkFilterTreeNode darkFilterTreeNode_0)
	{
		DarkFilterTreeNode parentNode = ParentNode;
		while (true)
		{
			if (parentNode != null)
			{
				if (parentNode == darkFilterTreeNode_0)
				{
					break;
				}
				parentNode = parentNode.ParentNode;
				continue;
			}
			return false;
		}
		return true;
	}

	public DarkFilterTreeNode()
	{
		Nodes = new ObservableList<DarkFilterTreeNode>();
		ForeColor = Colors.LightText;
	}

	public DarkFilterTreeNode(string string_0)
		: this()
	{
		Text = string_0;
	}

	public void Remove()
	{
		if (ParentNode == null)
		{
			ParentTree.Nodes.Remove(this);
		}
		else
		{
			ParentNode.Nodes.Remove(this);
		}
	}

	public void EnsureVisible()
	{
		for (DarkFilterTreeNode parentNode = ParentNode; parentNode != null; parentNode = parentNode.ParentNode)
		{
			parentNode.Expanded = true;
		}
	}

	private void OrderConfig()
	{
		if (ParentTree != null && ParentTree.TreeViewNodeSorter != null)
		{
			if (ParentNode == null)
			{
				ParentTree.Nodes.Sort(ParentTree.TreeViewNodeSorter);
			}
			else
			{
				ParentNode.Nodes.Sort(ParentTree.TreeViewNodeSorter);
			}
		}
		if (fieldParameter != null)
		{
			fieldParameter(this, null);
		}
	}

	private void RegisterConfig(object object_0, ObservableListModified<DarkFilterTreeNode> observableListModified_0)
	{
		foreach (DarkFilterTreeNode item in observableListModified_0.Items)
		{
			item.ParentNode = this;
			item.ParentTree = ParentTree;
		}
		if (ParentTree != null && ParentTree.TreeViewNodeSorter != null)
		{
			Nodes.Sort(ParentTree.TreeViewNodeSorter);
		}
		if (_MockParameter != null)
		{
			_MockParameter(this, observableListModified_0);
		}
	}

	private void ManageConfig(object object_0, ObservableListModified<DarkFilterTreeNode> observableListModified_0)
	{
		if (Nodes.Count == 0)
		{
			Expanded = false;
		}
		if (_TagParameter != null)
		{
			_TagParameter(this, observableListModified_0);
		}
	}
}
