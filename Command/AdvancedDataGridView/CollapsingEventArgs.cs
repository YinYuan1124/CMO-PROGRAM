using System.ComponentModel;

namespace AdvancedDataGridView;

public sealed class CollapsingEventArgs : CancelEventArgs
{
	private TreeGridNode _EventConfig;

	public TreeGridNode Node => _EventConfig;

	private CollapsingEventArgs()
	{
	}

	public CollapsingEventArgs(TreeGridNode treeGridNode_0)
	{
		_EventConfig = treeGridNode_0;
	}
}
