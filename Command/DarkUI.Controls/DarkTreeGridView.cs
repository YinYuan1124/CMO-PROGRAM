using System.Drawing;
using System.Windows.Forms;
using AdvancedDataGridView;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkTreeGridView : TreeGridView
{
	public DarkTreeGridView()
	{
		BackColor = Colors.DarkBackground;
		ForeColor = Colors.LightText;
		base.BackgroundColor = Colors.DarkBackground;
		base.BorderStyle = BorderStyle.FixedSingle;
		base.DefaultCellStyle = new DataGridViewCellStyle
		{
			BackColor = Colors.GreyBackground,
			Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0),
			ForeColor = Color.LightGray
		};
		base.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
		{
			Alignment = DataGridViewContentAlignment.MiddleLeft,
			BackColor = Colors.BlueBackground,
			Font = new Font("Segoe UI", 8.25f),
			ForeColor = Color.LightGray,
			SelectionBackColor = Colors.BlueSelection,
			SelectionForeColor = Colors.GreyHighlight,
			WrapMode = DataGridViewTriState.True
		};
		base.EnableHeadersVisualStyles = false;
		base.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		base.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		base.BorderStyle = BorderStyle.None;
	}

	public void ExpandAllItems()
	{
		foreach (TreeGridNode node in base.Nodes)
		{
			node.Expand();
		}
	}

	public void CollapseAllItem()
	{
		foreach (TreeGridNode item in base.Nodes.registryRegistry)
		{
			item.Collapse();
		}
	}
}
