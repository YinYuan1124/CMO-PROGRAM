using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkMaskedTextBox : MaskedTextBox
{
	public DarkMaskedTextBox()
	{
		BackColor = Color.FromArgb(31, 31, 31);
		ForeColor = Colors.LightText;
		base.Padding = new Padding(2, 2, 2, 2);
		base.BorderStyle = BorderStyle.FixedSingle;
	}
}
