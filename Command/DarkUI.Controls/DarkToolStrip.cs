using System.Drawing;
using System.Windows.Forms;
using DarkUI.Renderers;

namespace DarkUI.Controls;

public sealed class DarkToolStrip : ToolStrip
{
	public DarkToolStrip()
	{
		base.Renderer = new DarkToolStripRenderer();
		base.Padding = new Padding(5, 0, 1, 0);
		AutoSize = false;
		base.Size = new Size(1, 28);
	}
}
