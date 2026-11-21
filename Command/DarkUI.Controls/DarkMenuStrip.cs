using System.Windows.Forms;
using DarkUI.Renderers;

namespace DarkUI.Controls;

public sealed class DarkMenuStrip : MenuStrip
{
	public DarkMenuStrip()
	{
		base.Renderer = new DarkMenuRenderer();
		base.Padding = new Padding(3, 2, 0, 2);
	}
}
