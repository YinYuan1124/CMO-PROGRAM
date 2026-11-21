using System.Drawing;
using System.Windows.Forms;

namespace AdvancedDataGridView;

public sealed class TreeGridColumn : DataGridViewTextBoxColumn
{
	internal Image m_ManagerConfig;

	public Image DefaultNodeImage
	{
		get
		{
			return m_ManagerConfig;
		}
		set
		{
			m_ManagerConfig = value;
		}
	}

	public TreeGridColumn()
	{
		CellTemplate = new TreeGridCell();
	}

	public override object Clone()
	{
		TreeGridColumn obj = (TreeGridColumn)base.Clone();
		obj.m_ManagerConfig = m_ManagerConfig;
		return obj;
	}
}
