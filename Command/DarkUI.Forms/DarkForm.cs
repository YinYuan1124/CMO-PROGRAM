using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Forms;

public class DarkForm : Form
{
	private bool m_IdentifierObject;

	[Category("Appearance")]
	[Description("Determines whether a single pixel border should be rendered around the form.")]
	[DefaultValue(false)]
	public bool FlatBorder
	{
		get
		{
			return m_IdentifierObject;
		}
		set
		{
			m_IdentifierObject = value;
			Invalidate();
		}
	}

	public void D_Scale(SizeF sizeF_0)
	{
		Scale(sizeF_0);
	}

	public DarkForm()
	{
		BackColor = Colors.GreyBackground;
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
		base.OnPaintBackground(e);
		if (m_IdentifierObject)
		{
			Graphics graphics = e.Graphics;
			using Pen pen = new Pen(Colors.DarkBorder);
			Rectangle rect = new Rectangle(base.ClientRectangle.Location, new Size(base.ClientRectangle.Width - 1, base.ClientRectangle.Height - 1));
			graphics.DrawRectangle(pen, rect);
		}
	}
}
