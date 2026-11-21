using System.Windows.Forms;

namespace Command;

public sealed class DoubleBufferedDataGridView : DataGridView
{
	public DoubleBufferedDataGridView()
	{
		DoubleBuffered = true;
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
	}
}
