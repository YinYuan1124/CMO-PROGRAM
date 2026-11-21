using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace AdvancedDataGridView;

[ToolboxItem(false)]
[DesignTimeVisible(false)]
public class TreeGridNode : DataGridViewRow
{
	internal TreeGridView getterConfig;

	internal TreeGridNode _ProducerConfig;

	internal TreeGridNodeCollection _ProcConfig;

	internal bool structRegistry;

	internal bool _MerchantRegistry;

	internal bool m_CallbackRegistry;

	internal bool decoratorRegistry;

	internal bool processRegistry;

	internal Image _ThreadRegistry;

	internal int _RuleRegistry;

	private Random collectionRegistry = new Random();

	public int UniqueValue = -1;

	private TreeGridCell instanceRegistry;

	private TreeGridNodeCollection objectRegistry;

	private int m_ParameterRegistry;

	private int expressionRegistry;

	private bool _DispatcherRegistry;

	private ISite m_ListenerRegistry;

	private EventHandler _ConfigRegistry;

	public bool IsExpanded => structRegistry;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Description("Represents the index of this row in the Grid. Advanced usage.")]
	[Browsable(false)]
	public int RowIndex => base.Index;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new int Index
	{
		get
		{
			if (m_ParameterRegistry == -1)
			{
				m_ParameterRegistry = _ProcConfig.IndexOf(this);
			}
			return m_ParameterRegistry;
		}
		internal set
		{
			m_ParameterRegistry = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public ImageList ImageList
	{
		get
		{
			if (getterConfig == null)
			{
				return null;
			}
			return getterConfig.ImageList;
		}
	}

	[Description("...")]
	[Category("Appearance")]
	[Editor("System.Windows.Forms.Design.ImageIndexEditor", typeof(UITypeEditor))]
	[TypeConverter(typeof(ImageIndexConverter))]
	[DefaultValue(-1)]
	public int ImageIndex
	{
		get
		{
			return _RuleRegistry;
		}
		set
		{
			_RuleRegistry = value;
			if (_RuleRegistry != -1)
			{
				_ThreadRegistry = null;
			}
			if (m_CallbackRegistry)
			{
				instanceRegistry.UpdateStyle();
				if (Displayed)
				{
					getterConfig.InvalidateRow(RowIndex);
				}
			}
		}
	}

	public Image Image
	{
		get
		{
			if (_ThreadRegistry == null && _RuleRegistry != -1)
			{
				if (ImageList != null && _RuleRegistry < ImageList.Images.Count)
				{
					return ImageList.Images[_RuleRegistry];
				}
				return null;
			}
			return _ThreadRegistry;
		}
		set
		{
			_ThreadRegistry = value;
			if (_ThreadRegistry != null)
			{
				_RuleRegistry = -1;
			}
			if (m_CallbackRegistry)
			{
				instanceRegistry.UpdateStyle();
				if (Displayed)
				{
					getterConfig.InvalidateRow(RowIndex);
				}
			}
		}
	}

	[Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Category("Data")]
	[Description("The collection of root nodes in the treelist.")]
	public TreeGridNodeCollection Nodes
	{
		get
		{
			if (objectRegistry == null)
			{
				objectRegistry = new TreeGridNodeCollection(this);
			}
			return objectRegistry;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataGridViewCellCollection Cells
	{
		get
		{
			if (!_DispatcherRegistry && base.DataGridView == null)
			{
				if (getterConfig == null)
				{
					return null;
				}
				CreateCells(getterConfig);
				_DispatcherRegistry = true;
			}
			return base.Cells;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int Level
	{
		get
		{
			if (expressionRegistry == -1)
			{
				int num = 0;
				for (TreeGridNode parent = Parent; parent != null; parent = parent.Parent)
				{
					num++;
				}
				expressionRegistry = num;
			}
			return expressionRegistry;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public TreeGridNode Parent => _ProducerConfig;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual bool HasChildren
	{
		get
		{
			if (objectRegistry == null)
			{
				return false;
			}
			return Nodes.Count != 0;
		}
	}

	[Browsable(false)]
	public bool IsSited => m_CallbackRegistry;

	[Browsable(false)]
	public bool IsFirstSibling => Index == 0;

	[Browsable(false)]
	public bool IsLastSibling
	{
		get
		{
			TreeGridNode parent = Parent;
			if (parent != null && parent.HasChildren)
			{
				return Index == parent.Nodes.Count - 1;
			}
			return true;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ISite Site
	{
		get
		{
			return m_ListenerRegistry;
		}
		set
		{
			m_ListenerRegistry = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public event EventHandler Disposed
	{
		add
		{
			_ConfigRegistry = (EventHandler)Delegate.Combine(_ConfigRegistry, value);
		}
		remove
		{
			_ConfigRegistry = (EventHandler)Delegate.Remove(_ConfigRegistry, value);
		}
	}

	internal TreeGridNode(TreeGridView treeGridView_0)
		: this()
	{
		getterConfig = treeGridView_0;
		structRegistry = true;
	}

	public TreeGridNode()
	{
		m_ParameterRegistry = -1;
		expressionRegistry = -1;
		structRegistry = false;
		UniqueValue = collectionRegistry.Next();
		m_CallbackRegistry = false;
		decoratorRegistry = false;
		processRegistry = false;
		_RuleRegistry = -1;
	}

	public override object Clone()
	{
		TreeGridNode treeGridNode = (TreeGridNode)base.Clone();
		treeGridNode.UniqueValue = -1;
		treeGridNode.expressionRegistry = expressionRegistry;
		treeGridNode.getterConfig = getterConfig;
		treeGridNode._ProducerConfig = Parent;
		treeGridNode._RuleRegistry = _RuleRegistry;
		if (treeGridNode._RuleRegistry == -1)
		{
			treeGridNode.Image = Image;
		}
		treeGridNode.structRegistry = structRegistry;
		return treeGridNode;
	}

	protected internal virtual void UnSited()
	{
		foreach (DataGridViewCell cell in Cells)
		{
			if (cell is TreeGridCell treeGridCell)
			{
				treeGridCell.UnSited();
			}
		}
		m_CallbackRegistry = false;
	}

	protected internal virtual void Sited()
	{
		m_CallbackRegistry = true;
		_DispatcherRegistry = true;
		foreach (DataGridViewCell cell in Cells)
		{
			if (cell is TreeGridCell treeGridCell)
			{
				treeGridCell.Sited();
			}
		}
	}

	private bool SearchObserver()
	{
		if (_RuleRegistry == -1)
		{
			return false;
		}
		return _ThreadRegistry == null;
	}

	private bool EnableObserver()
	{
		if (_RuleRegistry == -1)
		{
			return _ThreadRegistry != null;
		}
		return false;
	}

	protected override DataGridViewCellCollection CreateCellsInstance()
	{
		DataGridViewCellCollection dataGridViewCellCollection = base.CreateCellsInstance();
		dataGridViewCellCollection.CollectionChanged += ChangeObserver;
		return dataGridViewCellCollection;
	}

	private void ChangeObserver(object sender, CollectionChangeEventArgs e)
	{
		if (instanceRegistry != null || (e.Action != CollectionChangeAction.Add && e.Action != CollectionChangeAction.Refresh))
		{
			return;
		}
		TreeGridCell treeGridCell = null;
		if (e.Element == null)
		{
			foreach (DataGridViewCell cell in base.Cells)
			{
				if (cell.GetType().IsAssignableFrom(typeof(TreeGridCell)))
				{
					treeGridCell = (TreeGridCell)cell;
					break;
				}
			}
		}
		else
		{
			treeGridCell = e.Element as TreeGridCell;
		}
		if (treeGridCell != null)
		{
			instanceRegistry = treeGridCell;
		}
	}

	public virtual bool Collapse()
	{
		return getterConfig.CollapseNode(this);
	}

	public virtual bool Expand()
	{
		if (getterConfig == null)
		{
			structRegistry = true;
			return true;
		}
		return getterConfig.ExpandNode(this);
	}

	protected internal virtual bool InsertChildNode(int int_0, TreeGridNode treeGridNode_0)
	{
		treeGridNode_0._ProducerConfig = this;
		treeGridNode_0.getterConfig = getterConfig;
		if (getterConfig != null)
		{
			InitObserver(treeGridNode_0);
		}
		if ((m_CallbackRegistry || _MerchantRegistry) && structRegistry)
		{
			getterConfig.SiteNode(treeGridNode_0);
		}
		return true;
	}

	protected internal virtual bool InsertChildNodes(int int_0, params TreeGridNode[] nodes)
	{
		foreach (TreeGridNode treeGridNode_ in nodes)
		{
			InsertChildNode(int_0, treeGridNode_);
		}
		return true;
	}

	protected internal virtual bool AddChildNode(TreeGridNode treeGridNode_0)
	{
		treeGridNode_0._ProducerConfig = this;
		treeGridNode_0.getterConfig = getterConfig;
		if (getterConfig != null)
		{
			InitObserver(treeGridNode_0);
		}
		if ((m_CallbackRegistry || _MerchantRegistry) && structRegistry && !treeGridNode_0.m_CallbackRegistry)
		{
			getterConfig.SiteNode(treeGridNode_0);
		}
		return true;
	}

	protected internal virtual bool AddChildNodes(params TreeGridNode[] nodes)
	{
		foreach (TreeGridNode treeGridNode_ in nodes)
		{
			AddChildNode(treeGridNode_);
		}
		return true;
	}

	protected internal virtual bool RemoveChildNode(TreeGridNode treeGridNode_0)
	{
		if ((_MerchantRegistry || m_CallbackRegistry) && structRegistry)
		{
			getterConfig.UnSiteNode(treeGridNode_0);
		}
		foreach (TreeGridNode node in Nodes)
		{
			node.m_ParameterRegistry = -1;
		}
		treeGridNode_0.getterConfig = null;
		treeGridNode_0._ProducerConfig = null;
		return true;
	}

	protected internal virtual bool ClearNodes()
	{
		if (HasChildren)
		{
			for (int num = Nodes.Count - 1; num >= 0; num--)
			{
				Nodes.RemoveAt(num);
			}
		}
		return true;
	}

	private void InitObserver(TreeGridNode treeGridNode_0)
	{
		if (!treeGridNode_0.HasChildren)
		{
			return;
		}
		foreach (TreeGridNode node in treeGridNode_0.Nodes)
		{
			node.getterConfig = treeGridNode_0.getterConfig;
			InitObserver(node);
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(36);
		stringBuilder.Append("TreeGridNode { Index=");
		stringBuilder.Append(RowIndex.ToString(CultureInfo.CurrentCulture));
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}
}
