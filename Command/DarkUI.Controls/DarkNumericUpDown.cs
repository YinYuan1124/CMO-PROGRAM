using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkNumericUpDown : NumericUpDown
{
	[CompilerGenerated]
	private sealed class TestProcessResolver
	{
		public Control control_0;

		public DarkNumericUpDown _003C_003E4__this;

		internal void LoginInterruptibleMock(object sender, PaintEventArgs e)
		{
			_ = e.Graphics;
			int height = control_0.Height;
			int width = control_0.Width;
			width -= 2;
			Graphics graphics = e.Graphics;
			graphics.Clear(Color.Transparent);
			Rectangle rect = new Rectangle(0, 0, width, height);
			width += 5;
			using (SolidBrush brush = new SolidBrush(Color.FromArgb(31, 31, 31)))
			{
				using LinearGradientBrush brush2 = new LinearGradientBrush(rect, Color.FromArgb(48, 48, 48), Color.FromArgb(64, 64, 64), 270f);
				using Pen pen = new Pen(Color.FromArgb(22, 22, 22));
				using Pen pen2 = new Pen(Color.FromArgb(20, Color.White));
				graphics.FillRectangle(brush, rect);
				graphics.FillPath(brush2, RoundRec(new Rectangle(width - 25, 0, 24, height - 1), 2));
				graphics.DrawLine(pen, new Point(width - 25, 1), new Point(width - 25, height - 2));
				graphics.DrawLine(pen, new Point(width - 25, 13), new Point(width - 1, 13));
				graphics.DrawLine(pen2, width - 24, 1, width - 24 + width, 1);
			}
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				using SolidBrush brush3 = new SolidBrush((_003C_003E4__this.Value == _003C_003E4__this.Maximum) ? Color.FromArgb(22, 22, 22) : Color.FromArgb(192, 192, 192));
				graphicsPath.AddLine(width - 17, 9, width - 2, 9);
				graphicsPath.AddLine(width - 9, 9, width - 13, 4);
				graphicsPath.CloseFigure();
				graphics.FillPath(brush3, graphicsPath);
			}
			using (GraphicsPath graphicsPath2 = new GraphicsPath())
			{
				using SolidBrush brush4 = new SolidBrush((_003C_003E4__this.Value <= _003C_003E4__this.Minimum) ? Color.FromArgb(22, 22, 22) : Color.FromArgb(192, 192, 192));
				graphicsPath2.AddLine(width - 17, 17, width - 2, 17);
				graphicsPath2.AddLine(width - 9, 17, width - 13, 22);
				graphicsPath2.CloseFigure();
				graphics.FillPath(brush4, graphicsPath2);
			}
			graphics.SmoothingMode = SmoothingMode.Default;
			using (SolidBrush brush5 = new SolidBrush(Color.FromArgb(207, 207, 207)))
			{
				graphics.DrawString(_003C_003E4__this.Value.ToString(), _003C_003E4__this.Font, brush5, new Rectangle(0, 0, width - 18, height), SetPosition());
			}
			using Pen pen3 = new Pen(Color.FromArgb(22, 22, 22));
			graphics.DrawRectangle(pen3, rect);
		}
	}

	public static StringFormat SetPosition(StringAlignment stringAlignment_0 = StringAlignment.Center, StringAlignment stringAlignment_1 = StringAlignment.Center)
	{
		return new StringFormat
		{
			Alignment = stringAlignment_0,
			LineAlignment = stringAlignment_1
		};
	}

	public static GraphicsPath RoundRec(Rectangle rectangle_0, int int_0, bool bool_0 = true, bool bool_1 = true, bool bool_2 = true, bool bool_3 = true)
	{
		GraphicsPath graphicsPath = new GraphicsPath(FillMode.Winding);
		if (bool_0)
		{
			graphicsPath.AddArc(rectangle_0.X, rectangle_0.Y, int_0, int_0, 180f, 90f);
		}
		else
		{
			graphicsPath.AddLine(rectangle_0.X, rectangle_0.Y, rectangle_0.X, rectangle_0.Y);
		}
		if (bool_1)
		{
			graphicsPath.AddArc(rectangle_0.Right - int_0, rectangle_0.Y, int_0, int_0, 270f, 90f);
		}
		else
		{
			graphicsPath.AddLine(rectangle_0.Right - rectangle_0.Width, rectangle_0.Y, rectangle_0.Width, rectangle_0.Y);
		}
		if (bool_3)
		{
			graphicsPath.AddArc(rectangle_0.Right - int_0, rectangle_0.Bottom - int_0, int_0, int_0, 0f, 90f);
		}
		else
		{
			graphicsPath.AddLine(rectangle_0.Right, rectangle_0.Bottom, rectangle_0.Right, rectangle_0.Bottom);
		}
		if (bool_2)
		{
			graphicsPath.AddArc(rectangle_0.X, rectangle_0.Bottom - int_0, int_0, int_0, 90f, 90f);
		}
		else
		{
			graphicsPath.AddLine(rectangle_0.X, rectangle_0.Bottom, rectangle_0.X, rectangle_0.Bottom);
		}
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public DarkNumericUpDown()
	{
		BackColor = Colors.LightBackground;
		ForeColor = Colors.LightText;
		base.Padding = new Padding(2, 2, 2, 2);
		base.BorderStyle = BorderStyle.None;
		BackColor = Colors.DarkBackground;
		foreach (Control control_0 in base.Controls)
		{
			if (control_0 is TextBox)
			{
				continue;
			}
			typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty, null, control_0, new object[1] { true });
			control_0.Paint += delegate(object sender, PaintEventArgs e)
			{
				_ = e.Graphics;
				int num = control_0.Height;
				int num2 = control_0.Width;
				num2 -= 2;
				Graphics graphics = e.Graphics;
				graphics.Clear(Color.Transparent);
				Rectangle rect = new Rectangle(0, 0, num2, num);
				num2 += 5;
				using (SolidBrush brush = new SolidBrush(Color.FromArgb(31, 31, 31)))
				{
					using LinearGradientBrush brush2 = new LinearGradientBrush(rect, Color.FromArgb(48, 48, 48), Color.FromArgb(64, 64, 64), 270f);
					using Pen pen = new Pen(Color.FromArgb(22, 22, 22));
					using Pen pen2 = new Pen(Color.FromArgb(20, Color.White));
					graphics.FillRectangle(brush, rect);
					graphics.FillPath(brush2, RoundRec(new Rectangle(num2 - 25, 0, 24, num - 1), 2));
					graphics.DrawLine(pen, new Point(num2 - 25, 1), new Point(num2 - 25, num - 2));
					graphics.DrawLine(pen, new Point(num2 - 25, 13), new Point(num2 - 1, 13));
					graphics.DrawLine(pen2, num2 - 24, 1, num2 - 24 + num2, 1);
				}
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				using (GraphicsPath graphicsPath = new GraphicsPath())
				{
					using SolidBrush brush3 = new SolidBrush((base.Value == base.Maximum) ? Color.FromArgb(22, 22, 22) : Color.FromArgb(192, 192, 192));
					graphicsPath.AddLine(num2 - 17, 9, num2 - 2, 9);
					graphicsPath.AddLine(num2 - 9, 9, num2 - 13, 4);
					graphicsPath.CloseFigure();
					graphics.FillPath(brush3, graphicsPath);
				}
				using (GraphicsPath graphicsPath2 = new GraphicsPath())
				{
					using SolidBrush brush4 = new SolidBrush((base.Value <= base.Minimum) ? Color.FromArgb(22, 22, 22) : Color.FromArgb(192, 192, 192));
					graphicsPath2.AddLine(num2 - 17, 17, num2 - 2, 17);
					graphicsPath2.AddLine(num2 - 9, 17, num2 - 13, 22);
					graphicsPath2.CloseFigure();
					graphics.FillPath(brush4, graphicsPath2);
				}
				graphics.SmoothingMode = SmoothingMode.Default;
				using (SolidBrush brush5 = new SolidBrush(Color.FromArgb(207, 207, 207)))
				{
					graphics.DrawString(base.Value.ToString(), Font, brush5, new Rectangle(0, 0, num2 - 18, num), SetPosition());
				}
				using Pen pen3 = new Pen(Color.FromArgb(22, 22, 22));
				graphics.DrawRectangle(pen3, rect);
			};
		}
	}
}
