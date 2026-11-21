using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace DarkUI.Docking;

public sealed class DockRegionState
{
	[CompilerGenerated]
	private DarkDockArea m_StatusParameter;

	public DarkDockArea Area
	{
		[CompilerGenerated]
		get
		{
			return m_StatusParameter;
		}
		[CompilerGenerated]
		set
		{
			m_StatusParameter = value;
		}
	}

	public Size Size { get; set; }

	public List<DockGroupState> Groups { get; set; }

	public DockRegionState()
	{
		Groups = new List<DockGroupState>();
	}

	public DockRegionState(DarkDockArea darkDockArea_0)
		: this()
	{
		Area = darkDockArea_0;
	}

	public DockRegionState(DarkDockArea darkDockArea_0, Size size_0)
		: this(darkDockArea_0)
	{
		Size = size_0;
	}
}
