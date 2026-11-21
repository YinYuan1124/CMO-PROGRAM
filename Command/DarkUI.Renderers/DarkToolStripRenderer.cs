using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;
using OpenDis.Producers;

namespace DarkUI.Renderers;

public class DarkToolStripRenderer : DarkMenuRenderer
{
	protected override void InitializeItem(ToolStripItem item)
	{
		base.InitializeItem(item);
		if (item.GetType() == typeof(ToolStripSeparator) && !((ToolStripSeparator)item).IsOnDropDown)
		{
			item.Margin = new Padding(0, 0, 2, 0);
		}
		if (item.GetType() == typeof(ToolStripButton))
		{
			item.AutoSize = false;
			item.Size = new Size(24, 24);
		}
	}

	protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
	{
		base.OnRenderToolStripBackground(e);
		Graphics graphics = e.Graphics;
		if (e.ToolStrip.GetType() == typeof(ToolStripOverflow))
		{
			using (Pen pen = new Pen(Colors.GreyBackground))
			{
				Rectangle rect = new Rectangle(e.AffectedBounds.Left, e.AffectedBounds.Top, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1);
				graphics.DrawRectangle(pen, rect);
			}
		}
	}

	protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
	{
		if (e.ToolStrip.GetType() != typeof(ToolStrip))
		{
			base.OnRenderToolStripBorder(e);
		}
	}

	protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
	{
		Graphics graphics = e.Graphics;
		Rectangle rect = new Rectangle(0, 1, e.Item.Width, e.Item.Height - 2);
		if (e.Item.Selected || e.Item.Pressed)
		{
			using SolidBrush brush = new SolidBrush(Colors.GreySelection);
			graphics.FillRectangle(brush, rect);
		}
		if (!(e.Item.GetType() == typeof(ToolStripButton)))
		{
			return;
		}
		ToolStripButton toolStripButton = (ToolStripButton)e.Item;
		if (toolStripButton.Checked)
		{
			using SolidBrush brush2 = new SolidBrush(Colors.GreySelection);
			graphics.FillRectangle(brush2, rect);
		}
		if (!toolStripButton.Checked || !toolStripButton.Selected)
		{
			return;
		}
		Rectangle rect2 = new Rectangle(rect.Left, rect.Top, rect.Width - 1, rect.Height - 1);
		using Pen pen = new Pen(Colors.GreyHighlight);
		graphics.DrawRectangle(pen, rect2);
	}

	protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
	{
		Graphics graphics = e.Graphics;
		Rectangle rect = new Rectangle(0, 1, e.Item.Width, e.Item.Height - 2);
		if (e.Item.Selected || e.Item.Pressed)
		{
			using (SolidBrush brush = new SolidBrush(Colors.GreySelection))
			{
				graphics.FillRectangle(brush, rect);
			}
		}
	}

	protected override void OnRenderGrip(ToolStripGripRenderEventArgs e)
	{
		if (e.GripStyle != 0)
		{
			Graphics graphics = e.Graphics;
			using Bitmap image = MenuIcons.grip.ViewListener(Colors.LightBorder);
			graphics.DrawImageUnscaled(image, new Point(e.AffectedBounds.Left, e.AffectedBounds.Top));
		}
	}

	protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
	{
		Graphics graphics = e.Graphics;
		if (!((ToolStripSeparator)e.Item).IsOnDropDown)
		{
			Rectangle rectangle = new Rectangle(3, 3, 2, e.Item.Height - 4);
			using (Pen pen = new Pen(Colors.DarkBorder))
			{
				graphics.DrawLine(pen, rectangle.Left, rectangle.Top, rectangle.Left, rectangle.Height);
			}
			using Pen pen2 = new Pen(Colors.LightBorder);
			graphics.DrawLine(pen2, rectangle.Left + 1, rectangle.Top, rectangle.Left + 1, rectangle.Height);
			return;
		}
		base.OnRenderSeparator(e);
	}

	protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
	{
		Graphics graphics = e.Graphics;
		if (e.Image != null)
		{
			if (e.Item.Enabled)
			{
				graphics.DrawImageUnscaled(e.Image, new Point(e.ImageRectangle.Left, e.ImageRectangle.Top));
			}
			else
			{
				ControlPaint.DrawImageDisabled(graphics, e.Image, e.ImageRectangle.Left, e.ImageRectangle.Top, Color.Transparent);
			}
		}
	}

	protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
	{
	}
}
