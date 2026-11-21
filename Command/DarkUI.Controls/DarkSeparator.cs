using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkSeparator : Control
{
	public DarkSeparator()
	{
		SetStyle(ControlStyles.Selectable, value: false);
		Dock = DockStyle.Top;
		base.Size = new Size(1, 2);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		using (Pen pen = new Pen(Colors.DarkBorder))
		{
			graphics.DrawLine(pen, base.ClientRectangle.Left, 0, base.ClientRectangle.Right, 0);
		}
		using Pen pen2 = new Pen(Colors.LightBorder);
		graphics.DrawLine(pen2, base.ClientRectangle.Left, 1, base.ClientRectangle.Right, 1);
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
	}
}
