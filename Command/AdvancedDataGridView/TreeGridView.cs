using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
namespace AdvancedDataGridView;

[Docking(DockingBehavior.Ask)]
[ComplexBindingProperties]
//[Designer(typeof(ControlDesigner))]
[DesignerCategory("code")]
public class TreeGridView : DataGridView
{
	private static class AttributePrototype
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(HandleRef handleRef_0, int int_0, IntPtr intptr_0, IntPtr intptr_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		public static extern IntPtr SendMessage_1(HandleRef handleRef_0, int int_0, int int_1, int int_2);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool PostMessage(HandleRef handleRef_0, int int_0, IntPtr intptr_0, IntPtr intptr_1);
	}

	private int wrapperRegistry;

	private TreeGridNode observerRegistry;

	private TreeGridColumn m_IssuerRegistry;

	private bool m_ClientRegistry;

	internal ImageList dicRegistry;

	private bool consumerRegistry;

	internal bool _FacadeRegistry;

	private Control m_ProxyRegistry;

	private bool m_ReaderRegistry = true;

	private bool _PropertyRegistry;

	[CompilerGenerated]
	private ExpandingEventHandler importerRegistry;

	[CompilerGenerated]
	private ExpandedEventHandler m_RepositoryRegistry;

	[CompilerGenerated]
	private CollapsingEventHandler _BridgeRegistry;

	[CompilerGenerated]
	private CollapsedEventHandler invocationRegistry;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new object DataSource
	{
		get
		{
			return null;
		}
		set
		{
			throw new NotSupportedException("The TreeGridView does not support databinding");
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public new object DataMember
	{
		get
		{
			return null;
		}
		set
		{
			throw new NotSupportedException("The TreeGridView does not support databinding");
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataGridViewRowCollection Rows => base.Rows;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new bool VirtualMode
	{
		get
		{
			return false;
		}
		set
		{
			throw new NotSupportedException("The TreeGridView does not support virtual mode");
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new DataGridViewRow RowTemplate
	{
		get
		{
			return base.RowTemplate;
		}
		set
		{
			base.RowTemplate = value;
		}
	}

	[Description("The collection of root nodes in the treelist.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
	[Category("Data")]
	public TreeGridNodeCollection Nodes => observerRegistry.Nodes;

	public new TreeGridNode CurrentRow => base.CurrentRow as TreeGridNode;

	[Description("Causes nodes to always show as expandable. Use the NodeExpanding event to add nodes.")]
	[DefaultValue(false)]
	public bool VirtualNodes
	{
		get
		{
			return _PropertyRegistry;
		}
		set
		{
			_PropertyRegistry = value;
		}
	}

	public TreeGridNode CurrentNode => CurrentRow;

	[DefaultValue(true)]
	public bool ShowLines
	{
		get
		{
			return m_ReaderRegistry;
		}
		set
		{
			if (value != m_ReaderRegistry)
			{
				m_ReaderRegistry = value;
				Invalidate();
			}
		}
	}

	public ImageList ImageList
	{
		get
		{
			return dicRegistry;
		}
		set
		{
			dicRegistry = value;
		}
	}

	public new int RowCount
	{
		get
		{
			return Nodes.Count;
		}
		set
		{
			for (int i = 0; i < value; i++)
			{
				Nodes.Add(new TreeGridNode());
			}
		}
	}

	public event ExpandingEventHandler NodeExpanding
	{
		[CompilerGenerated]
		add
		{
			ExpandingEventHandler expandingEventHandler = importerRegistry;
			ExpandingEventHandler expandingEventHandler2;
			do
			{
				expandingEventHandler2 = expandingEventHandler;
				ExpandingEventHandler value2 = (ExpandingEventHandler)Delegate.Combine(expandingEventHandler2, value);
				expandingEventHandler = Interlocked.CompareExchange(ref importerRegistry, value2, expandingEventHandler2);
			}
			while ((object)expandingEventHandler != expandingEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ExpandingEventHandler expandingEventHandler = importerRegistry;
			ExpandingEventHandler expandingEventHandler2;
			do
			{
				expandingEventHandler2 = expandingEventHandler;
				ExpandingEventHandler value2 = (ExpandingEventHandler)Delegate.Remove(expandingEventHandler2, value);
				expandingEventHandler = Interlocked.CompareExchange(ref importerRegistry, value2, expandingEventHandler2);
			}
			while ((object)expandingEventHandler != expandingEventHandler2);
		}
	}

	public event ExpandedEventHandler NodeExpanded
	{
		[CompilerGenerated]
		add
		{
			ExpandedEventHandler expandedEventHandler = m_RepositoryRegistry;
			ExpandedEventHandler expandedEventHandler2;
			do
			{
				expandedEventHandler2 = expandedEventHandler;
				ExpandedEventHandler value2 = (ExpandedEventHandler)Delegate.Combine(expandedEventHandler2, value);
				expandedEventHandler = Interlocked.CompareExchange(ref m_RepositoryRegistry, value2, expandedEventHandler2);
			}
			while ((object)expandedEventHandler != expandedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ExpandedEventHandler expandedEventHandler = m_RepositoryRegistry;
			ExpandedEventHandler expandedEventHandler2;
			do
			{
				expandedEventHandler2 = expandedEventHandler;
				ExpandedEventHandler value2 = (ExpandedEventHandler)Delegate.Remove(expandedEventHandler2, value);
				expandedEventHandler = Interlocked.CompareExchange(ref m_RepositoryRegistry, value2, expandedEventHandler2);
			}
			while ((object)expandedEventHandler != expandedEventHandler2);
		}
	}

	public event CollapsingEventHandler NodeCollapsing
	{
		[CompilerGenerated]
		add
		{
			CollapsingEventHandler collapsingEventHandler = _BridgeRegistry;
			CollapsingEventHandler collapsingEventHandler2;
			do
			{
				collapsingEventHandler2 = collapsingEventHandler;
				CollapsingEventHandler value2 = (CollapsingEventHandler)Delegate.Combine(collapsingEventHandler2, value);
				collapsingEventHandler = Interlocked.CompareExchange(ref _BridgeRegistry, value2, collapsingEventHandler2);
			}
			while ((object)collapsingEventHandler != collapsingEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CollapsingEventHandler collapsingEventHandler = _BridgeRegistry;
			CollapsingEventHandler collapsingEventHandler2;
			do
			{
				collapsingEventHandler2 = collapsingEventHandler;
				CollapsingEventHandler value2 = (CollapsingEventHandler)Delegate.Remove(collapsingEventHandler2, value);
				collapsingEventHandler = Interlocked.CompareExchange(ref _BridgeRegistry, value2, collapsingEventHandler2);
			}
			while ((object)collapsingEventHandler != collapsingEventHandler2);
		}
	}

	public event CollapsedEventHandler NodeCollapsed
	{
		[CompilerGenerated]
		add
		{
			CollapsedEventHandler collapsedEventHandler = invocationRegistry;
			CollapsedEventHandler collapsedEventHandler2;
			do
			{
				collapsedEventHandler2 = collapsedEventHandler;
				CollapsedEventHandler value2 = (CollapsedEventHandler)Delegate.Combine(collapsedEventHandler2, value);
				collapsedEventHandler = Interlocked.CompareExchange(ref invocationRegistry, value2, collapsedEventHandler2);
			}
			while ((object)collapsedEventHandler != collapsedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CollapsedEventHandler collapsedEventHandler = invocationRegistry;
			CollapsedEventHandler collapsedEventHandler2;
			do
			{
				collapsedEventHandler2 = collapsedEventHandler;
				CollapsedEventHandler value2 = (CollapsedEventHandler)Delegate.Remove(collapsedEventHandler2, value);
				collapsedEventHandler = Interlocked.CompareExchange(ref invocationRegistry, value2, collapsedEventHandler2);
			}
			while ((object)collapsedEventHandler != collapsedEventHandler2);
		}
	}

	public TreeGridView()
	{
		base.EditMode = DataGridViewEditMode.EditProgrammatically;
		RowTemplate = new TreeGridNode();
		base.AllowUserToAddRows = false;
		base.AllowUserToDeleteRows = false;
		observerRegistry = new TreeGridNode(this);
		observerRegistry._MerchantRegistry = true;
		base.Rows.CollectionChanged += delegate
		{
		};
	}

	protected override void OnKeyDown(KeyEventArgs ke)
	{
		base.OnKeyDown(ke);
		if (ke.Handled)
		{
			return;
		}
		if (ke.KeyCode == Keys.F2 && base.CurrentCellAddress.X > -1 && base.CurrentCellAddress.Y > -1)
		{
			if (!base.CurrentCell.Displayed)
			{
				base.FirstDisplayedScrollingRowIndex = base.CurrentCellAddress.Y;
			}
			base.SelectionMode = DataGridViewSelectionMode.CellSelect;
			BeginEdit(selectAll: true);
		}
		else if (ke.KeyCode == Keys.Return && !base.IsCurrentCellInEditMode)
		{
			base.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			base.CurrentCell.OwningRow.Selected = true;
		}
	}

	[Description("Returns the TreeGridNode for the given DataGridViewRow")]
	public TreeGridNode GetNodeForRow(DataGridViewRow dataGridViewRow_0)
	{
		return dataGridViewRow_0 as TreeGridNode;
	}

	[Description("Returns the TreeGridNode for the given DataGridViewRow")]
	public TreeGridNode GetNodeForRow(int int_0)
	{
		return GetNodeForRow(base.Rows[int_0]);
	}

	protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
	{
		base.OnRowsAdded(e);
		if (base.Rows[e.RowIndex] is TreeGridNode treeGridNode)
		{
			treeGridNode.Sited();
		}
	}

	protected internal void UnSiteAll()
	{
		UnSiteNode(observerRegistry);
	}

	protected internal virtual void UnSiteNode(TreeGridNode treeGridNode_0)
	{
		try
		{
			if (!treeGridNode_0.IsSited && !treeGridNode_0._MerchantRegistry)
			{
				return;
			}
			foreach (TreeGridNode node in treeGridNode_0.Nodes)
			{
				UnSiteNode(node);
			}
			if (!treeGridNode_0._MerchantRegistry)
			{
				base.Rows.Remove(treeGridNode_0);
				treeGridNode_0.UnSited();
			}
		}
		catch
		{
		}
	}

	protected internal virtual bool CollapseNode(TreeGridNode treeGridNode_0)
	{
		if (treeGridNode_0.structRegistry)
		{
			CollapsingEventArgs collapsingEventArgs = new CollapsingEventArgs(treeGridNode_0);
			OnNodeCollapsing(collapsingEventArgs);
			if (!collapsingEventArgs.Cancel)
			{
				ConcatObserver(bool_0: true);
				SuspendLayout();
				consumerRegistry = true;
				treeGridNode_0.structRegistry = false;
				foreach (TreeGridNode node in treeGridNode_0.Nodes)
				{
					UnSiteNode(node);
				}
				CollapsedEventArgs collapsedEventArgs_ = new CollapsedEventArgs(treeGridNode_0);
				OnNodeCollapsed(collapsedEventArgs_);
				consumerRegistry = false;
				ConcatObserver(bool_0: false);
				ResumeLayout(performLayout: true);
				InvalidateCell(treeGridNode_0.Cells[0]);
			}
			return !collapsingEventArgs.Cancel;
		}
		return false;
	}

	protected internal virtual void SiteNode(TreeGridNode treeGridNode_0)
	{
		int num = -1;
		treeGridNode_0.getterConfig = this;
		TreeGridNode treeGridNode = ((treeGridNode_0.Parent != null && !treeGridNode_0.Parent._MerchantRegistry) ? ((treeGridNode_0.Index <= 0) ? treeGridNode_0.Parent : treeGridNode_0.Parent.Nodes[treeGridNode_0.Index - 1]) : ((treeGridNode_0.Index <= 0) ? null : treeGridNode_0.Parent.Nodes[treeGridNode_0.Index - 1]));
		if (treeGridNode == null)
		{
			num = 0;
		}
		else
		{
			while (treeGridNode.Level >= treeGridNode_0.Level && treeGridNode.RowIndex < base.Rows.Count - 1)
			{
				treeGridNode = base.Rows[treeGridNode.RowIndex + 1] as TreeGridNode;
			}
			num = ((treeGridNode == treeGridNode_0.Parent) ? (treeGridNode.RowIndex + 1) : ((treeGridNode.Level < treeGridNode_0.Level) ? treeGridNode.RowIndex : (treeGridNode.RowIndex + 1)));
		}
		SiteNode(treeGridNode_0, num);
		if (!treeGridNode_0.structRegistry)
		{
			return;
		}
		foreach (TreeGridNode node in treeGridNode_0.Nodes)
		{
			SiteNode(node);
		}
	}

	protected internal virtual void SiteNode(TreeGridNode treeGridNode_0, int int_0)
	{
		if (int_0 < base.Rows.Count)
		{
			base.Rows.Insert(int_0, treeGridNode_0);
		}
		else
		{
			base.Rows.Add(treeGridNode_0);
		}
	}

	protected internal virtual bool ExpandNode(TreeGridNode treeGridNode_0)
	{
		if (treeGridNode_0.structRegistry && !_PropertyRegistry)
		{
			return false;
		}
		ExpandingEventArgs expandingEventArgs = new ExpandingEventArgs(treeGridNode_0);
		OnNodeExpanding(expandingEventArgs);
		if (!expandingEventArgs.Cancel)
		{
			ConcatObserver(bool_0: true);
			SuspendLayout();
			consumerRegistry = true;
			treeGridNode_0.structRegistry = true;
			foreach (TreeGridNode node in treeGridNode_0.Nodes)
			{
				SiteNode(node);
			}
			ExpandedEventArgs expandedEventArgs_ = new ExpandedEventArgs(treeGridNode_0);
			OnNodeExpanded(expandedEventArgs_);
			consumerRegistry = false;
			ConcatObserver(bool_0: false);
			ResumeLayout(performLayout: true);
			InvalidateCell(treeGridNode_0.Cells[0]);
		}
		return !expandingEventArgs.Cancel;
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
		_FacadeRegistry = false;
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (!_FacadeRegistry)
		{
			base.OnMouseMove(e);
		}
	}

	protected virtual void OnNodeExpanding(ExpandingEventArgs expandingEventArgs_0)
	{
		if (importerRegistry != null)
		{
			importerRegistry(this, expandingEventArgs_0);
		}
	}

	protected virtual void OnNodeExpanded(ExpandedEventArgs expandedEventArgs_0)
	{
		if (m_RepositoryRegistry != null)
		{
			m_RepositoryRegistry(this, expandedEventArgs_0);
		}
	}

	protected virtual void OnNodeCollapsing(CollapsingEventArgs collapsingEventArgs_0)
	{
		if (_BridgeRegistry != null)
		{
			_BridgeRegistry(this, collapsingEventArgs_0);
		}
	}

	protected virtual void OnNodeCollapsed(CollapsedEventArgs collapsedEventArgs_0)
	{
		if (invocationRegistry != null)
		{
			invocationRegistry(this, collapsedEventArgs_0);
		}
	}

	protected override void Dispose(bool disposing)
	{
		m_ClientRegistry = true;
		base.Dispose(base.Disposing);
		UnSiteAll();
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		m_ProxyRegistry = new Control();
		m_ProxyRegistry.Visible = false;
		m_ProxyRegistry.Enabled = false;
		m_ProxyRegistry.TabStop = false;
		base.Controls.Add(m_ProxyRegistry);
	}

	protected override void OnRowEnter(DataGridViewCellEventArgs e)
	{
		base.OnRowEnter(e);
		if (base.SelectionMode == DataGridViewSelectionMode.CellSelect || (base.SelectionMode == DataGridViewSelectionMode.FullRowSelect && !base.Rows[e.RowIndex].Selected))
		{
			base.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			base.Rows[e.RowIndex].Selected = true;
		}
	}

	private void ConcatObserver(bool bool_0)
	{
		if (!consumerRegistry)
		{
			if (bool_0)
			{
				base.VerticalScrollBar.Parent = m_ProxyRegistry;
			}
			else
			{
				base.VerticalScrollBar.Parent = this;
			}
		}
	}

	protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
	{
		if (typeof(TreeGridColumn).IsAssignableFrom(e.Column.GetType()) && m_IssuerRegistry == null)
		{
			m_IssuerRegistry = (TreeGridColumn)e.Column;
		}
		e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
		base.OnColumnAdded(e);
	}
}
