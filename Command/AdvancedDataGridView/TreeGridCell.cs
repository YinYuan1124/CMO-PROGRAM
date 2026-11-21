using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AdvancedDataGridView;

public class TreeGridCell : DataGridViewTextBoxCell
{
	private int _WorkerConfig;

	private int _AccountConfig;

	internal bool stateConfig;

	private Padding authenticationConfig;

	private int paramsConfig;

	private int _InfoConfig;

	private int m_HelperConfig;

	private Rectangle m_MapperConfig;

	public int Level => OwningNode?.Level ?? (-1);

	protected virtual int GlyphMargin => (Level - 1) * 20 + 5;

	protected virtual int GlyphOffset => (Level - 1) * 20;

	public TreeGridNode OwningNode => base.OwningRow as TreeGridNode;

	public TreeGridCell()
	{
		_WorkerConfig = 15;
		_AccountConfig = 0;
		stateConfig = false;
	}

	public override object Clone()
	{
		TreeGridCell obj = (TreeGridCell)base.Clone();
		obj._WorkerConfig = _WorkerConfig;
		obj._AccountConfig = _AccountConfig;
		return obj;
	}

	protected internal virtual void UnSited()
	{
		stateConfig = false;
		base.Style.Padding = authenticationConfig;
	}

	protected internal virtual void Sited()
	{
		stateConfig = true;
		authenticationConfig = base.Style.Padding;
		UpdateStyle();
	}

	protected internal virtual void UpdateStyle()
	{
		if (stateConfig)
		{
			int level = Level;
			Padding padding = authenticationConfig;
			Size preferredSize;
			using (Graphics graphics = OwningNode.getterConfig.CreateGraphics())
			{
				preferredSize = GetPreferredSize(graphics, base.InheritedStyle, base.RowIndex, new Size(0, 0));
			}
			Image image = OwningNode.Image;
			if (image == null)
			{
				paramsConfig = _WorkerConfig;
				_InfoConfig = 0;
			}
			else
			{
				paramsConfig = image.Width + 2;
				_InfoConfig = image.Height + 2;
			}
			if (preferredSize.Height < _InfoConfig)
			{
				base.Style.Padding = new Padding(padding.Left + level * 20 + paramsConfig + 5, padding.Top + _InfoConfig / 2, padding.Right, padding.Bottom + _InfoConfig / 2);
				m_HelperConfig = 2;
			}
			else
			{
				base.Style.Padding = new Padding(padding.Left + level * 20 + paramsConfig + 5, padding.Top, padding.Right, padding.Bottom);
			}
			_AccountConfig = (level - 1) * _WorkerConfig + paramsConfig + 5;
		}
	}

	protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
	{
		TreeGridNode owningNode = OwningNode;
		if (owningNode == null)
		{
			return;
		}
		Image image = owningNode.Image;
		if (_InfoConfig == 0 && image != null)
		{
			UpdateStyle();
		}
		base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
		Rectangle rectangle = new Rectangle(cellBounds.X + GlyphMargin, cellBounds.Y, 20, cellBounds.Height - 1);
		_ = rectangle.Width / 2;
		_ = Level;
		if (image != null)
		{
			Point point = ((_InfoConfig <= cellBounds.Height) ? new Point(rectangle.X + _WorkerConfig, cellBounds.Height / 2 - _InfoConfig / 2 + cellBounds.Y) : new Point(rectangle.X + _WorkerConfig, cellBounds.Y + m_HelperConfig));
			GraphicsContainer container = graphics.BeginContainer();
			graphics.SetClip(cellBounds);
			graphics.DrawImageUnscaled(image, point);
			graphics.EndContainer(container);
		}
		if (owningNode.getterConfig.ShowLines)
		{
			using Pen pen = new Pen(SystemBrushes.ControlDark, 1f);
			pen.DashStyle = DashStyle.Dot;
			bool isLastSibling = owningNode.IsLastSibling;
			bool isFirstSibling = owningNode.IsFirstSibling;
			if (owningNode.Level == 1)
			{
				if (isFirstSibling && isLastSibling)
				{
					graphics.DrawLine(pen, rectangle.X + 4, cellBounds.Top + cellBounds.Height / 2, rectangle.Right, cellBounds.Top + cellBounds.Height / 2);
				}
				else if (isLastSibling)
				{
					graphics.DrawLine(pen, rectangle.X + 4, cellBounds.Top + cellBounds.Height / 2, rectangle.Right, cellBounds.Top + cellBounds.Height / 2);
					graphics.DrawLine(pen, rectangle.X + 4, cellBounds.Top, rectangle.X + 4, cellBounds.Top + cellBounds.Height / 2);
				}
				else if (isFirstSibling)
				{
					graphics.DrawLine(pen, rectangle.X + 4, cellBounds.Top + cellBounds.Height / 2, rectangle.Right, cellBounds.Top + cellBounds.Height / 2);
					graphics.DrawLine(pen, rectangle.X + 4, cellBounds.Top + cellBounds.Height / 2, rectangle.X + 4, cellBounds.Bottom);
				}
				else
				{
					graphics.DrawLine(pen, rectangle.X + 4, cellBounds.Top + cellBounds.Height / 2, rectangle.Right, cellBounds.Top + cellBounds.Height / 2);
					graphics.DrawLine(pen, rectangle.X + 4, cellBounds.Top, rectangle.X + 4, cellBounds.Bottom);
				}
			}
			else
			{
				if (isLastSibling)
				{
					graphics.DrawLine(pen, rectangle.X + 4, cellBounds.Top + cellBounds.Height / 2, rectangle.Right, cellBounds.Top + cellBounds.Height / 2);
					graphics.DrawLine(pen, rectangle.X + 4, cellBounds.Top, rectangle.X + 4, cellBounds.Top + cellBounds.Height / 2);
				}
				else
				{
					graphics.DrawLine(pen, rectangle.X + 4, cellBounds.Top + cellBounds.Height / 2, rectangle.Right, cellBounds.Top + cellBounds.Height / 2);
					graphics.DrawLine(pen, rectangle.X + 4, cellBounds.Top, rectangle.X + 4, cellBounds.Bottom);
				}
				TreeGridNode parent = owningNode.Parent;
				int num = rectangle.X + 4 - 20;
				while (!parent._MerchantRegistry)
				{
					if (parent.HasChildren && !parent.IsLastSibling)
					{
						graphics.DrawLine(pen, num, cellBounds.Top, num, cellBounds.Bottom);
					}
					parent = parent.Parent;
					num -= 20;
				}
			}
		}
		if (owningNode.HasChildren || owningNode.getterConfig.VirtualNodes)
		{
			if (owningNode.structRegistry)
			{
				Bitmap image2 = new Bitmap(Application.StartupPath + "\\Symbols\\Menu\\Minus.png");
				graphics.DrawImage(image2, rectangle.X, rectangle.Y + rectangle.Height / 2 - 4, 10, 10);
			}
			else
			{
				Bitmap image3 = new Bitmap(Application.StartupPath + "\\Symbols\\Menu\\Plus.png");
				graphics.DrawImage(image3, rectangle.X, rectangle.Y + rectangle.Height / 2 - 4, 10, 10);
			}
		}
	}

	protected override void OnMouseUp(DataGridViewCellMouseEventArgs e)
	{
		base.OnMouseUp(e);
		TreeGridNode owningNode = OwningNode;
		if (owningNode != null)
		{
			owningNode.getterConfig._FacadeRegistry = false;
		}
	}

	protected override void OnMouseDown(DataGridViewCellMouseEventArgs e)
	{
		if (e.Location.X <= base.InheritedStyle.Padding.Left)
		{
			TreeGridNode owningNode = OwningNode;
			if (owningNode != null)
			{
				owningNode.getterConfig._FacadeRegistry = true;
				if (owningNode.structRegistry)
				{
					owningNode.Collapse();
				}
				else
				{
					owningNode.Expand();
				}
			}
		}
		else
		{
			base.OnMouseDown(e);
		}
	}
}
