using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkDataGridView : DataGridView
{
	public DarkDataGridView()
	{
		DoubleBuffered = true;
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		UpdateStyles();
		base.Padding = new Padding(2, 2, 2, 2);
		base.BorderStyle = BorderStyle.None;
		base.BackgroundColor = Colors.GreyBackground;
		base.DefaultCellStyle = new DataGridViewCellStyle
		{
			Alignment = DataGridViewContentAlignment.MiddleLeft,
			BackColor = Colors.GreyBackground,
			Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0),
			ForeColor = Color.LightGray,
			SelectionBackColor = Colors.BlueSelection,
			SelectionForeColor = Colors.GreyHighlight,
			WrapMode = DataGridViewTriState.False
		};
		base.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
		{
			Alignment = DataGridViewContentAlignment.MiddleLeft,
			BackColor = Colors.BlueBackground,
			Font = new Font("Segoe UI", 8f),
			ForeColor = Color.LightGray,
			SelectionBackColor = Colors.BlueSelection,
			SelectionForeColor = Colors.GreyHighlight,
			WrapMode = DataGridViewTriState.True
		};
		base.RowsDefaultCellStyle = new DataGridViewCellStyle
		{
			BackColor = Colors.GreyBackground,
			ForeColor = Color.LightGray,
			SelectionBackColor = Colors.BlueSelection,
			SelectionForeColor = Color.LightGray
		};
		base.EnableHeadersVisualStyles = false;
		base.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		base.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		base.BorderStyle = BorderStyle.None;
		base.AllowUserToOrderColumns = true;
	}
}
