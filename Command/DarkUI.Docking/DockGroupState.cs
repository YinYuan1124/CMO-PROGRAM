using System.Collections.Generic;

namespace DarkUI.Docking;

public sealed class DockGroupState
{
	public List<string> Contents { get; set; }

	public string VisibleContent { get; set; }

	public DockGroupState()
	{
		Contents = new List<string>();
	}
}
