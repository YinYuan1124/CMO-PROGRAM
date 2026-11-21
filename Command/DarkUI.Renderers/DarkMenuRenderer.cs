using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Renderers;

public class DarkMenuRenderer : ToolStripRenderer
{
	protected override void Initialize(ToolStrip toolStrip)
	{
		base.Initialize(toolStrip);
		toolStrip.BackColor = Colors.GreyBackground;
		toolStrip.ForeColor = Colors.LightText;
	}

	protected override void InitializeItem(ToolStripItem item)
	{
		base.InitializeItem(item);
		item.BackColor = Colors.GreyBackground;
		item.ForeColor = Colors.LightText;
		if (item.GetType() == typeof(ToolStripSeparator))
		{
			item.Margin = new Padding(0, 0, 0, 1);
		}
	}

	protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
	{
		Graphics graphics = e.Graphics;
		using SolidBrush brush = new SolidBrush(Colors.GreyBackground);
		graphics.FillRectangle(brush, e.AffectedBounds);
	}

	protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
	{
		Graphics graphics = e.Graphics;
		Rectangle rect = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
		using Pen pen = new Pen(Colors.LightBorder);
		graphics.DrawRectangle(pen, rect);
	}

	protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
	{
		Graphics graphics = e.Graphics;
		Rectangle rect = new Rectangle(e.ImageRectangle.Left - 2, e.ImageRectangle.Top - 2, e.ImageRectangle.Width + 4, e.ImageRectangle.Height + 4);
		using (SolidBrush brush = new SolidBrush(Colors.LightBorder))
		{
			graphics.FillRectangle(brush, rect);
		}
		using (Pen pen = new Pen(Colors.BlueHighlight))
		{
			Rectangle rect2 = new Rectangle(rect.Left, rect.Top, rect.Width - 1, rect.Height - 1);
			graphics.DrawRectangle(pen, rect2);
		}
		if (e.Item.ImageIndex == -1 && string.IsNullOrEmpty(e.Item.ImageKey) && e.Item.Image == null)
		{
			graphics.DrawImageUnscaled(MenuIcons.tick, new Point(e.ImageRectangle.Left, e.ImageRectangle.Top));
		}
	}

	protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
	{
		Graphics graphics = e.Graphics;
		Rectangle rect = new Rectangle(1, 3, e.Item.Width, 1);
		using SolidBrush brush = new SolidBrush(Colors.LightBorder);
		graphics.FillRectangle(brush, rect);
	}

	protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
	{
		e.ArrowColor = Colors.LightText;
		e.ArrowRectangle = new Rectangle(new Point(e.ArrowRectangle.Left, e.ArrowRectangle.Top - 1), e.ArrowRectangle.Size);
		base.OnRenderArrow(e);
	}

	protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
	{
		Graphics graphics = e.Graphics;
		e.Item.ForeColor = (e.Item.Enabled ? Colors.LightText : Colors.DisabledText);
		if (!e.Item.Enabled)
		{
			return;
		}
		Color color = (e.Item.Selected ? Colors.GreyHighlight : e.Item.BackColor);
		Rectangle rect = new Rectangle(2, 0, e.Item.Width - 3, e.Item.Height);
		using (SolidBrush brush = new SolidBrush(color))
		{
			graphics.FillRectangle(brush, rect);
		}
		if (!(e.Item.GetType() == typeof(ToolStripMenuItem)) || !((ToolStripMenuItem)e.Item).DropDown.Visible || e.Item.IsOnDropDown)
		{
			return;
		}
		using SolidBrush brush2 = new SolidBrush(Colors.GreySelection);
		graphics.FillRectangle(brush2, rect);
	}
}
