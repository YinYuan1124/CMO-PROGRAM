using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkToolStripItem : ToolStripItem
{
	public DarkToolStripItem()
	{
		BackColor = Colors.GreyBackground;
		ForeColor = Colors.LightText;
	}
}
