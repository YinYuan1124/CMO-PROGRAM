using System.ComponentModel;
using DarkUI.Config;

namespace DarkUI.Docking;

[ToolboxItem(false)]
public sealed class DarkDocument : DarkDockContent
{
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new DarkDockArea DefaultDockArea => base.DefaultDockArea;

	public DarkDocument()
	{
		BackColor = Colors.GreyBackground;
		base.DefaultDockArea = DarkDockArea.Document;
	}
}
