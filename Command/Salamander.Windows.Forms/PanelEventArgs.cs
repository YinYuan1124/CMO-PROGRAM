using System;

namespace Salamander.Windows.Forms;

public sealed class PanelEventArgs : EventArgs
{
	private CollapsiblePanel _ErrorCallback;

	public CollapsiblePanel CollapsiblePanel => _ErrorCallback;

	public PanelState PanelState => _ErrorCallback.PanelState;

	public PanelEventArgs(CollapsiblePanel collapsiblePanel_0)
	{
		_ErrorCallback = collapsiblePanel_0;
	}
}
