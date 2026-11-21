using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkRichTextBox : RichTextBox
{
	public DarkRichTextBox()
	{
		ForeColor = Colors.LightText;
		BackColor = Colors.GreyBackground;
	}
}
