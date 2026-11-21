using System.Drawing;
using System.Windows.Forms;

namespace OpenDis.Database;

internal class ValueDecoratorEntry : Form
{
	protected override bool ShowWithoutActivation => true;

	public ValueDecoratorEntry(Color color_0, double double_0 = 0.6)
	{
		base.StartPosition = FormStartPosition.Manual;
		base.FormBorderStyle = FormBorderStyle.None;
		base.Size = new Size(1, 1);
		base.ShowInTaskbar = false;
		base.AllowTransparency = true;
		base.Opacity = double_0;
		BackColor = color_0;
	}
}
