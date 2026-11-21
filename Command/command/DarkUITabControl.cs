using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using DarkUI.Config;

namespace Command;

public sealed class DarkUITabControl : TabControl
{
	public DarkUITabControl()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		DoubleBuffered = true;
		base.SizeMode = TabSizeMode.Normal;
		Dock = DockStyle.None;
		base.ItemSize = new Size(80, 20);
		base.Alignment = TabAlignment.Top;
		UpdateStyles();
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		graphics.SmoothingMode = SmoothingMode.AntiAlias;
		graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		graphics.Clear(Color.FromArgb(39, 39, 39));
		Cursor = Cursors.Hand;
		int num = 0;
		int num2 = base.TabCount - 1;
		for (int i = 0; i <= num2; i++)
		{
			if (!base.TabPages[i].Enabled)
			{
				continue;
			}
			Rectangle tabRect = GetTabRect(i);
			if (tabRect.Width == 0 || tabRect.Height == 0)
			{
				continue;
			}
			if (i == base.TabCount - 1)
			{
				using LinearGradientBrush brush_ = new LinearGradientBrush(tabRect, Color.FromArgb(29, 29, 29), Color.FromArgb(41, 41, 41), 270f);
				HelperMethods.FillRoundedPath(graphics, brush_, tabRect, 2, bool_0: false, bool_1: true, bool_2: false);
			}
			else if (i == 0)
			{
				using LinearGradientBrush brush_2 = new LinearGradientBrush(tabRect, Color.FromArgb(29, 29, 29), Color.FromArgb(41, 41, 41), 270f);
				HelperMethods.FillRoundedPath(graphics, brush_2, new Rectangle(tabRect.X, tabRect.Y, tabRect.Width, tabRect.Height), 2, bool_0: true, bool_1: false, bool_2: true, bool_3: false);
			}
			else
			{
				using LinearGradientBrush brush = new LinearGradientBrush(tabRect, Color.FromArgb(29, 29, 29), Color.FromArgb(41, 41, 41), 270f);
				graphics.FillRectangle(brush, tabRect);
			}
		}
		int num3 = base.TabCount - 1;
		for (int j = 0; j <= num3; j++)
		{
			if (!base.TabPages[j].Enabled)
			{
				continue;
			}
			Rectangle tabRect2 = GetTabRect(j);
			num += tabRect2.Width;
			if (base.SelectedIndex == j)
			{
				using (LinearGradientBrush brush2 = new LinearGradientBrush(tabRect2, Color.FromArgb(48, 48, 48), Color.FromArgb(64, 64, 64), 270f))
				{
					if (j == base.TabCount - 1)
					{
						graphics.FillPath(brush2, HelperMethods.RoundRec(new Rectangle(tabRect2.X + 1, tabRect2.Y, tabRect2.Width - 1, tabRect2.Height - 1), 2, bool_0: false, bool_1: true, bool_2: false));
					}
					else if (j == 0)
					{
						graphics.FillPath(brush2, HelperMethods.RoundRec(new Rectangle(tabRect2.X, tabRect2.Y, tabRect2.Width, tabRect2.Height), 2, bool_0: true, bool_1: false, bool_2: true, bool_3: false));
					}
					else
					{
						graphics.FillRectangle(brush2, new Rectangle(tabRect2.X + 1, tabRect2.Y, tabRect2.Width - 1, tabRect2.Height));
					}
				}
				using SolidBrush brush3 = new SolidBrush(Color.White);
				graphics.DrawString(base.TabPages[j].Text, Font, brush3, tabRect2, HelperMethods.SetPosition());
			}
			else
			{
				using SolidBrush brush4 = new SolidBrush(Color.FromArgb(168, 168, 168));
				graphics.DrawString(base.TabPages[j].Text, Font, brush4, tabRect2, HelperMethods.SetPosition());
			}
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		int num = base.TabCount - 1;
		for (int i = 0; i <= num; i++)
		{
			if (GetTabRect(i).Contains(e.Location))
			{
				Cursor = Cursors.Hand;
				Invalidate();
			}
			else
			{
				Cursor = Cursors.Arrow;
				Invalidate();
			}
		}
	}

	protected override void OnCreateControl()
	{
		base.OnCreateControl();
		IEnumerator enumerator = null;
		try
		{
			enumerator = base.TabPages.GetEnumerator();
			while (enumerator.MoveNext())
			{
				((TabPage)enumerator.Current).BackColor = Colors.GreyBackground;
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
	}

	protected override void OnSelecting(TabControlCancelEventArgs e)
	{
		base.OnSelecting(e);
		if (e.TabPage != null && !e.TabPage.Enabled)
		{
			e.Cancel = true;
		}
	}

	internal void ValidateServer()
	{
		IEnumerator enumerator = null;
		try
		{
			enumerator = base.TabPages.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TabPage tabPage = (TabPage)enumerator.Current;
				if (tabPage.Enabled)
				{
					tabPage.Parent = this;
				}
				else
				{
					tabPage.Parent = null;
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
	}

	public void HideNonSelectedTabs()
	{
		IEnumerator enumerator = null;
		try
		{
			enumerator = base.TabPages.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TabPage tabPage = (TabPage)enumerator.Current;
				if (tabPage == base.SelectedTab)
				{
					tabPage.Parent = this;
				}
				else
				{
					tabPage.Parent = null;
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
	}
}
