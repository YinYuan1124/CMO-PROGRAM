using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Command.WinFormControls;

public sealed class TextProgressBar : ProgressBar
{
	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
			{
				createParams.ExStyle |= 33554432;
			}
			return createParams;
		}
	}

	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
			Refresh();
		}
	}

	protected override void WndProc(ref Message m)
	{
		base.WndProc(ref m);
		if (m.Msg != 15)
		{
			return;
		}
		using Graphics graphics = CreateGraphics();
		using SolidBrush brush = new SolidBrush(ForeColor);
		SizeF sizeF = graphics.MeasureString(Text, SystemFonts.DefaultFont);
		graphics.DrawString(Text, SystemFonts.DefaultFont, brush, ((float)base.Width - sizeF.Width) / 2f, ((float)base.Height - sizeF.Height) / 2f);
	}
}
