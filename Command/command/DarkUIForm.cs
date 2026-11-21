using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Command;

public sealed class DarkUIForm : ContainerControl
{
	public enum TitlePostion
	{
		Left,
		Center,
		Right
	}

	private bool m_RecordValue;

	private Point exceptionValue;

	private int _AttrValue;

	public DarkUIForm()
	{
		m_RecordValue = false;
		exceptionValue = new Point(-1, -1);
		_AttrValue = 40;
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		UpdateStyles();
		DoubleBuffered = true;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
		graphics.CompositingQuality = CompositingQuality.HighQuality;
		Rectangle rect = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
		Rectangle rectangle = new Rectangle(0, 0, base.Width - 1, 40);
		using (SolidBrush brush = new SolidBrush(Color.FromArgb(39, 39, 39)))
		{
			using LinearGradientBrush brush2 = new LinearGradientBrush(rectangle, Color.FromArgb(64, 64, 64), Color.FromArgb(48, 48, 48), 90f);
			using Pen pen = new Pen(Color.FromArgb(22, 22, 22));
			using Pen pen2 = new Pen(Color.FromArgb(15, 255, 255, 255));
			graphics.FillRectangle(brush, rect);
			graphics.FillRectangle(brush2, rectangle);
			graphics.DrawLine(pen, 0, 40, base.Width - 2, 40);
			graphics.DrawLine(pen2, 0, 41, base.Width - 2, 41);
			graphics.DrawRectangle(pen, rect);
		}
		if (FindForm().ShowIcon && FindForm().Icon != null)
		{
			graphics.DrawIcon(FindForm().Icon, new Rectangle(5, 10, 20, 20));
		}
		graphics.DrawString(Text, Font, Brushes.White, rectangle, HelperMethods.SetPosition());
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if ((e.Button == MouseButtons.Left) & new Rectangle(0, 0, base.Width, _AttrValue).Contains(e.Location))
		{
			m_RecordValue = true;
			exceptionValue = e.Location;
		}
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
		m_RecordValue = false;
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		int num = Control.MousePosition.X;
		int num2 = Control.MousePosition.Y;
		int num3 = exceptionValue.X;
		int num4 = exceptionValue.Y;
		if (m_RecordValue)
		{
			base.Parent.Location = new Point(num - num3, num2 - num4);
		}
		Focus();
	}

	protected override void OnCreateControl()
	{
		base.OnCreateControl();
		base.ParentForm.FormBorderStyle = FormBorderStyle.None;
		base.ParentForm.Dock = DockStyle.None;
		Dock = DockStyle.Fill;
		Invalidate();
	}
}
