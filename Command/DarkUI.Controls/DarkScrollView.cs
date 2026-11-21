using System.Drawing;
using System.Windows.Forms;

namespace DarkUI.Controls;

public abstract class DarkScrollView : DarkScrollBase
{
	protected DarkScrollView()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, value: true);
	}

	protected abstract void PaintContent(Graphics graphics_0);

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		using (SolidBrush brush = new SolidBrush(BackColor))
		{
			graphics.FillRectangle(brush, base.ClientRectangle);
		}
		graphics.TranslateTransform(base.Viewport.Left * -1, base.Viewport.Top * -1);
		PaintContent(graphics);
		graphics.TranslateTransform(base.Viewport.Left, base.Viewport.Top);
		if (_vScrollBar.Visible && _hScrollBar.Visible)
		{
			using (SolidBrush brush2 = new SolidBrush(BackColor))
			{
				Rectangle rect = new Rectangle(_hScrollBar.Right, _vScrollBar.Bottom, _vScrollBar.Width, _hScrollBar.Height);
				graphics.FillRectangle(brush2, rect);
			}
		}
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
	}
}
