namespace AdvancedDataGridView;

public class TreeGridNodeEventBase
{
	private TreeGridNode m_ValRegistry;

	public TreeGridNode Node => m_ValRegistry;

	public TreeGridNodeEventBase(TreeGridNode treeGridNode_0)
	{
		m_ValRegistry = treeGridNode_0;
	}
}
