using System.ComponentModel;

namespace AdvancedDataGridView;

public sealed class ExpandingEventArgs : CancelEventArgs
{
	private TreeGridNode _GlobalConfig;

	public TreeGridNode Node => _GlobalConfig;

	private ExpandingEventArgs()
	{
	}

	public ExpandingEventArgs(TreeGridNode treeGridNode_0)
	{
		_GlobalConfig = treeGridNode_0;
	}
}
