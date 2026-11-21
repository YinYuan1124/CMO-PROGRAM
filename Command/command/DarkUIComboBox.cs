using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DefaultEvent("SelectedIndexChanged")]
public sealed class DarkUIComboBox : ComboBox
{
	private StringFormat _UtilsValue;

	public DarkUIComboBox()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		BackColor = Color.Transparent;
		base.DrawMode = DrawMode.OwnerDrawFixed;
		DoubleBuffered = true;
		base.DropDownStyle = ComboBoxStyle.DropDownList;
		Font = new Font(Client.CommandDefaultFont.FontFamily, 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		_UtilsValue = new StringFormat(StringFormatFlags.NoWrap, 0);
		UpdateStyles();
	}

	protected override void OnDrawItem(DrawItemEventArgs e)
	{
		Graphics graphics = e.Graphics;
		graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		try
		{
			using LinearGradientBrush brush = new LinearGradientBrush(e.Graphics.ClipBounds, Color.FromArgb(48, 48, 48), Color.FromArgb(64, 64, 64), 270f);
			using SolidBrush brush2 = new SolidBrush(((e.State & DrawItemState.Selected) == 0) ? Color.FromArgb(189, 189, 189) : Color.White);
			using Font font = new Font(Font.Name, Font.Size + 2f);
			graphics.FillRectangle(brush, e.Bounds);
			if (e.Index != -1)
			{
				graphics.DrawString(GetItemText(RuntimeHelpers.GetObjectValue(base.Items[e.Index])), font, brush2, e.Bounds, HelperMethods.SetPosition(StringAlignment.Near));
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		Rectangle rectangle_ = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
		using (Pen pen = new Pen(Color.FromArgb(20, Color.White)))
		{
			using SolidBrush brush_ = new SolidBrush(Color.FromArgb(31, 31, 31));
			using LinearGradientBrush brush_2 = new LinearGradientBrush(new Rectangle(base.Width - 29, 0, 30, base.Height - 1), Color.FromArgb(48, 48, 48), Color.FromArgb(64, 64, 64), 270f);
			HelperMethods.FillRoundedPath(graphics, brush_, rectangle_, 1);
			HelperMethods.FillRoundedPath(graphics, brush_2, new Rectangle(base.Width - 29, 0, 30, base.Height - 1), 1, bool_0: false, bool_1: true, bool_2: false);
			graphics.DrawLine(pen, base.Width - 28, 1, base.Width - 28 + base.Width, 1);
			HelperMethods.DrawRoundedPath(graphics, Color.FromArgb(22, 22, 22), 1f, rectangle_, 2);
		}
		graphics.SmoothingMode = SmoothingMode.AntiAlias;
		HelperMethods.DrawTriangle(graphics, Color.FromArgb(192, 192, 192), 2, new Point(base.Width - 20, 10), new Point(base.Width - 16, 14), new Point(base.Width - 16, 14), new Point(base.Width - 12, 10), new Point(base.Width - 16, 15), new Point(base.Width - 16, 14));
		graphics.SmoothingMode = SmoothingMode.AntiAlias;
		using SolidBrush brush = new SolidBrush(Color.FromArgb(168, 168, 168));
		using Font font = new Font(Font.Name, Font.Size + 2f);
		graphics.DrawString(Text, font, brush, new Rectangle(3, 1, base.Width - 27, base.Height - 1), _UtilsValue);
	}
}
