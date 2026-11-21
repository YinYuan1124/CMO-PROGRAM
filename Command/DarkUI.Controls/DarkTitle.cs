using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkTitle : Label
{
	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		Rectangle rectangle = new Rectangle(0, 0, base.ClientSize.Width, base.ClientSize.Height);
		SizeF sizeF = graphics.MeasureString(Text, Font);
		using (SolidBrush brush = new SolidBrush(Colors.LightText))
		{
			graphics.DrawString(Text, Font, brush, new PointF(-2f, 0f));
		}
		using Pen pen = new Pen(Colors.GreyHighlight);
		PointF pt = new PointF(sizeF.Width + 5f, sizeF.Height / 2f);
		PointF pt2 = new PointF(rectangle.Width, sizeF.Height / 2f);
		graphics.DrawLine(pen, pt, pt2);
	}
}
