using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using DarkUI.Collections;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkTreeNode
{
	[CompilerGenerated]
	private EventHandler<ObservableListModified<DarkTreeNode>> m_PredicateExpression;

	[CompilerGenerated]
	private EventHandler<ObservableListModified<DarkTreeNode>> _SingletonExpression;

	[CompilerGenerated]
	private EventHandler m_RecordExpression;

	[CompilerGenerated]
	private EventHandler m_ExceptionExpression;

	[CompilerGenerated]
	private EventHandler attrExpression;

	private string m_VisitorExpression;

	private bool exporterExpression;

	private DarkTreeView prototypeExpression;

	private DarkTreeNode comparatorExpression;

	private ObservableList<DarkTreeNode> _ItemExpression;

	private bool m_SetterExpression;

	[CompilerGenerated]
	private object creatorExpression;

	[CompilerGenerated]
	private Rectangle m_TemplateExpression;

	[CompilerGenerated]
	private Rectangle m_MappingExpression;

	[CompilerGenerated]
	private Rectangle mockExpression;

	[CompilerGenerated]
	private Rectangle m_TagExpression;

	[CompilerGenerated]
	private bool m_FieldExpression;

	[CompilerGenerated]
	private Bitmap m_QueueExpression;

	[CompilerGenerated]
	private bool m_ParamExpression;

	[CompilerGenerated]
	private object pageExpression;

	[CompilerGenerated]
	private DarkTreeNode rulesExpression;

	[CompilerGenerated]
	private DarkTreeNode methodExpression;

	[CompilerGenerated]
	private int m_ServiceExpression;

	[CompilerGenerated]
	private Font candidateExpression;

	public string Text
	{
		get
		{
			return m_VisitorExpression;
		}
		set
		{
			if (m_VisitorExpression != value)
			{
				m_VisitorExpression = value;
				PostRegistry();
			}
		}
	}

	public Rectangle ExpandArea
	{
		[CompilerGenerated]
		get
		{
			return m_TemplateExpression;
		}
		[CompilerGenerated]
		set
		{
			m_TemplateExpression = value;
		}
	}

	public Rectangle IconArea
	{
		[CompilerGenerated]
		get
		{
			return m_MappingExpression;
		}
		[CompilerGenerated]
		set
		{
			m_MappingExpression = value;
		}
	}

	public Rectangle TextArea
	{
		[CompilerGenerated]
		get
		{
			return mockExpression;
		}
		[CompilerGenerated]
		set
		{
			mockExpression = value;
		}
	}

	public Rectangle FullArea
	{
		[CompilerGenerated]
		get
		{
			return m_TagExpression;
		}
		[CompilerGenerated]
		set
		{
			m_TagExpression = value;
		}
	}

	public bool ExpandAreaHot
	{
		[CompilerGenerated]
		get
		{
			return m_FieldExpression;
		}
		[CompilerGenerated]
		set
		{
			m_FieldExpression = value;
		}
	}

	public Bitmap Icon
	{
		[CompilerGenerated]
		get
		{
			return m_QueueExpression;
		}
		[CompilerGenerated]
		set
		{
			m_QueueExpression = value;
		}
	}

	public Bitmap ExpandedIcon { get; set; }

	public bool Expanded
	{
		get
		{
			return m_SetterExpression;
		}
		set
		{
			if (m_SetterExpression == value || (value && Nodes.Count == 0))
			{
				return;
			}
			m_SetterExpression = value;
			if (m_SetterExpression)
			{
				if (m_ExceptionExpression != null)
				{
					m_ExceptionExpression(this, null);
				}
			}
			else if (attrExpression != null)
			{
				attrExpression(this, null);
			}
			ParentTree?.UpdateNodes();
		}
	}

	public ObservableList<DarkTreeNode> Nodes
	{
		get
		{
			return _ItemExpression;
		}
		set
		{
			if (_ItemExpression != null)
			{
				_ItemExpression.ItemsAdded -= RunRegistry;
				_ItemExpression.ItemsRemoved -= StartRegistry;
			}
			_ItemExpression = value;
			_ItemExpression.ItemsAdded += RunRegistry;
			_ItemExpression.ItemsRemoved += StartRegistry;
		}
	}

	public bool IsRoot
	{
		get
		{
			return exporterExpression;
		}
		set
		{
			exporterExpression = value;
		}
	}

	public DarkTreeView ParentTree
	{
		get
		{
			return prototypeExpression;
		}
		set
		{
			if (prototypeExpression == value)
			{
				return;
			}
			prototypeExpression = value;
			foreach (DarkTreeNode node in Nodes)
			{
				node.ParentTree = prototypeExpression;
			}
		}
	}

	public DarkTreeNode ParentNode
	{
		get
		{
			return comparatorExpression;
		}
		set
		{
			comparatorExpression = value;
		}
	}

	public bool Odd
	{
		[CompilerGenerated]
		get
		{
			return m_ParamExpression;
		}
		[CompilerGenerated]
		set
		{
			m_ParamExpression = value;
		}
	}

	public object NodeType
	{
		[CompilerGenerated]
		get
		{
			return creatorExpression;
		}
		[CompilerGenerated]
		set
		{
			creatorExpression = value;
		}
	}

	public object Tag
	{
		[CompilerGenerated]
		get
		{
			return pageExpression;
		}
		[CompilerGenerated]
		set
		{
			pageExpression = value;
		}
	}

	public string FullPath
	{
		get
		{
			DarkTreeNode parentNode = ParentNode;
			string text = Text;
			while (parentNode != null)
			{
				text = string.Format("{0}{1}{2}", parentNode.Text, "\\", text);
				parentNode = parentNode.ParentNode;
			}
			return text;
		}
	}

	public DarkTreeNode PrevVisibleNode
	{
		[CompilerGenerated]
		get
		{
			return rulesExpression;
		}
		[CompilerGenerated]
		set
		{
			rulesExpression = value;
		}
	}

	public DarkTreeNode NextVisibleNode
	{
		[CompilerGenerated]
		get
		{
			return methodExpression;
		}
		[CompilerGenerated]
		set
		{
			methodExpression = value;
		}
	}

	public int VisibleIndex
	{
		[CompilerGenerated]
		get
		{
			return m_ServiceExpression;
		}
		[CompilerGenerated]
		set
		{
			m_ServiceExpression = value;
		}
	}

	public Color ForeColor { get; set; }

	public Font Font
	{
		[CompilerGenerated]
		get
		{
			return candidateExpression;
		}
		[CompilerGenerated]
		set
		{
			candidateExpression = value;
		}
	}

	public event EventHandler<ObservableListModified<DarkTreeNode>> ItemsAdded
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ObservableListModified<DarkTreeNode>> eventHandler = m_PredicateExpression;
			EventHandler<ObservableListModified<DarkTreeNode>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<DarkTreeNode>> value2 = (EventHandler<ObservableListModified<DarkTreeNode>>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_PredicateExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ObservableListModified<DarkTreeNode>> eventHandler = m_PredicateExpression;
			EventHandler<ObservableListModified<DarkTreeNode>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<DarkTreeNode>> value2 = (EventHandler<ObservableListModified<DarkTreeNode>>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_PredicateExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<ObservableListModified<DarkTreeNode>> ItemsRemoved
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ObservableListModified<DarkTreeNode>> eventHandler = _SingletonExpression;
			EventHandler<ObservableListModified<DarkTreeNode>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<DarkTreeNode>> value2 = (EventHandler<ObservableListModified<DarkTreeNode>>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _SingletonExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ObservableListModified<DarkTreeNode>> eventHandler = _SingletonExpression;
			EventHandler<ObservableListModified<DarkTreeNode>> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ObservableListModified<DarkTreeNode>> value2 = (EventHandler<ObservableListModified<DarkTreeNode>>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _SingletonExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler TextChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = m_RecordExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_RecordExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = m_RecordExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_RecordExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler NodeExpanded
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = m_ExceptionExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_ExceptionExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = m_ExceptionExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_ExceptionExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler NodeCollapsed
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = attrExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref attrExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = attrExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref attrExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public bool IsNodeAncestor(DarkTreeNode darkTreeNode_0)
	{
		DarkTreeNode parentNode = ParentNode;
		while (true)
		{
			if (parentNode != null)
			{
				if (parentNode == darkTreeNode_0)
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

	public DarkTreeNode()
	{
		Nodes = new ObservableList<DarkTreeNode>();
		ForeColor = Colors.LightText;
	}

	public DarkTreeNode(string string_0)
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
		for (DarkTreeNode parentNode = ParentNode; parentNode != null; parentNode = parentNode.ParentNode)
		{
			parentNode.Expanded = true;
		}
	}

	private void PostRegistry()
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
		if (m_RecordExpression != null)
		{
			m_RecordExpression(this, null);
		}
	}

	private void RunRegistry(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
	{
		foreach (DarkTreeNode item in observableListModified_0.Items)
		{
			item.ParentNode = this;
			item.ParentTree = ParentTree;
		}
		if (ParentTree != null && ParentTree.TreeViewNodeSorter != null)
		{
			Nodes.Sort(ParentTree.TreeViewNodeSorter);
		}
		if (m_PredicateExpression != null)
		{
			m_PredicateExpression(this, observableListModified_0);
		}
	}

	private void StartRegistry(object object_0, ObservableListModified<DarkTreeNode> observableListModified_0)
	{
		if (Nodes.Count == 0)
		{
			Expanded = false;
		}
		if (_SingletonExpression != null)
		{
			_SingletonExpression(this, observableListModified_0);
		}
	}
}
