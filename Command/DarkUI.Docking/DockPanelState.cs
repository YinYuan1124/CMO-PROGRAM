using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DarkUI.Docking;

public sealed class DockPanelState
{
	[CompilerGenerated]
	private List<DockRegionState> contextParameter;

	public List<DockRegionState> Regions
	{
		[CompilerGenerated]
		get
		{
			return contextParameter;
		}
		[CompilerGenerated]
		set
		{
			contextParameter = value;
		}
	}

	public DockPanelState()
	{
		Regions = new List<DockRegionState>();
	}
}
