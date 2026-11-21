using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkToolStripMenuItem : ToolStripMenuItem
{
	public DarkToolStripMenuItem()
	{
		BackColor = Colors.GreyBackground;
		ForeColor = Colors.LightText;
	}

	public DarkToolStripMenuItem(Color color_0)
	{
		BackColor = Colors.GreyBackground;
		ForeColor = color_0;
	}
}
