using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace CodersLab.Windows.ControlsCSMaterial;

public sealed class NodesCollection : CollectionBase
{
	[CompilerGenerated]
	private TreeNodeEventHandler m_ProcDispatcher;

	[CompilerGenerated]
	private TreeNodeEventHandler _StructListener;

	[CompilerGenerated]
	private TreeNodeEventHandler merchantListener;

	[CompilerGenerated]
	private EventHandler callbackListener;

	public TreeNode this[int int_0] => (TreeNode)base.List[int_0];

	internal event TreeNodeEventHandler PushWrapper
	{
		[CompilerGenerated]
		add
		{
			TreeNodeEventHandler treeNodeEventHandler = m_ProcDispatcher;
			TreeNodeEventHandler treeNodeEventHandler2;
			do
			{
				treeNodeEventHandler2 = treeNodeEventHandler;
				TreeNodeEventHandler value2 = (TreeNodeEventHandler)Delegate.Combine(treeNodeEventHandler2, value);
				treeNodeEventHandler = Interlocked.CompareExchange(ref m_ProcDispatcher, value2, treeNodeEventHandler2);
			}
			while ((object)treeNodeEventHandler != treeNodeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TreeNodeEventHandler treeNodeEventHandler = m_ProcDispatcher;
			TreeNodeEventHandler treeNodeEventHandler2;
			do
			{
				treeNodeEventHandler2 = treeNodeEventHandler;
				TreeNodeEventHandler value2 = (TreeNodeEventHandler)Delegate.Remove(treeNodeEventHandler2, value);
				treeNodeEventHandler = Interlocked.CompareExchange(ref m_ProcDispatcher, value2, treeNodeEventHandler2);
			}
			while ((object)treeNodeEventHandler != treeNodeEventHandler2);
		}
	}

	internal event TreeNodeEventHandler IncludeWrapper
	{
		[CompilerGenerated]
		add
		{
			TreeNodeEventHandler treeNodeEventHandler = _StructListener;
			TreeNodeEventHandler treeNodeEventHandler2;
			do
			{
				treeNodeEventHandler2 = treeNodeEventHandler;
				TreeNodeEventHandler value2 = (TreeNodeEventHandler)Delegate.Combine(treeNodeEventHandler2, value);
				treeNodeEventHandler = Interlocked.CompareExchange(ref _StructListener, value2, treeNodeEventHandler2);
			}
			while ((object)treeNodeEventHandler != treeNodeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TreeNodeEventHandler treeNodeEventHandler = _StructListener;
			TreeNodeEventHandler treeNodeEventHandler2;
			do
			{
				treeNodeEventHandler2 = treeNodeEventHandler;
				TreeNodeEventHandler value2 = (TreeNodeEventHandler)Delegate.Remove(treeNodeEventHandler2, value);
				treeNodeEventHandler = Interlocked.CompareExchange(ref _StructListener, value2, treeNodeEventHandler2);
			}
			while ((object)treeNodeEventHandler != treeNodeEventHandler2);
		}
	}

	internal event TreeNodeEventHandler InitWrapper
	{
		[CompilerGenerated]
		add
		{
			TreeNodeEventHandler treeNodeEventHandler = merchantListener;
			TreeNodeEventHandler treeNodeEventHandler2;
			do
			{
				treeNodeEventHandler2 = treeNodeEventHandler;
				TreeNodeEventHandler value2 = (TreeNodeEventHandler)Delegate.Combine(treeNodeEventHandler2, value);
				treeNodeEventHandler = Interlocked.CompareExchange(ref merchantListener, value2, treeNodeEventHandler2);
			}
			while ((object)treeNodeEventHandler != treeNodeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TreeNodeEventHandler treeNodeEventHandler = merchantListener;
			TreeNodeEventHandler treeNodeEventHandler2;
			do
			{
				treeNodeEventHandler2 = treeNodeEventHandler;
				TreeNodeEventHandler value2 = (TreeNodeEventHandler)Delegate.Remove(treeNodeEventHandler2, value);
				treeNodeEventHandler = Interlocked.CompareExchange(ref merchantListener, value2, treeNodeEventHandler2);
			}
			while ((object)treeNodeEventHandler != treeNodeEventHandler2);
		}
	}

	internal event EventHandler RemoveWrapper
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = callbackListener;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref callbackListener, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = callbackListener;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref callbackListener, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public int Add(TreeNode treeNode_0)
	{
		if (m_ProcDispatcher != null)
		{
			m_ProcDispatcher(treeNode_0);
		}
		return base.List.Add(treeNode_0);
	}

	public void Insert(int int_0, TreeNode treeNode_0)
	{
		if (merchantListener != null)
		{
			merchantListener(treeNode_0);
		}
		base.List.Add(treeNode_0);
	}

	public void Remove(TreeNode treeNode_0)
	{
		if (_StructListener != null)
		{
			_StructListener(treeNode_0);
		}
		base.List.Remove(treeNode_0);
	}

	public bool Contains(TreeNode treeNode_0)
	{
		return base.List.Contains(treeNode_0);
	}

	public int IndexOf(TreeNode treeNode_0)
	{
		return base.List.IndexOf(treeNode_0);
	}

	protected override void OnClear()
	{
		if (callbackListener != null)
		{
			callbackListener(this, EventArgs.Empty);
		}
		base.OnClear();
	}
}
