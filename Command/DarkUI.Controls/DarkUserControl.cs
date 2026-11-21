using System.ComponentModel;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public class DarkUserControl : UserControl
{
	private IContainer m_GetterExpression;

	public DarkUserControl()
	{
		NewDefinition();
		BackColor = Colors.GreyBackground;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && m_GetterExpression != null)
		{
			m_GetterExpression.Dispose();
		}
		base.Dispose(disposing);
	}

	private void NewDefinition()
	{
		m_GetterExpression = new Container();
	}
}
