using System.Windows.Forms;
using DarkUI.Renderers;

namespace DarkUI.Controls;

public sealed class DarkContextMenu : ContextMenuStrip
{
	public DarkContextMenu()
	{
		base.Renderer = new DarkMenuRenderer();
	}
}
