using System.Windows.Forms;

namespace Command;

public sealed class MaintainScrollPosition
{
	private static int _BaseConnection;

	private static int _PolicyConnection;

	public void method_0(DataGridView dataGridView_0)
	{
		_BaseConnection = dataGridView_0.FirstDisplayedScrollingRowIndex;
	}

	public void method_1(DataGridView dataGridView_0)
	{
		dataGridView_0.FirstDisplayedScrollingRowIndex = _BaseConnection;
	}

	public void method_2(DataGridView dataGridView_0)
	{
		_PolicyConnection = dataGridView_0.FirstDisplayedScrollingColumnIndex;
	}

	public void method_3(DataGridView dataGridView_0)
	{
		dataGridView_0.FirstDisplayedScrollingColumnIndex = _PolicyConnection;
	}
}
