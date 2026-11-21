using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Filter;
using DarkUI.Config;
using OpenDis.Database;
using OpenDis.Producers;

namespace DarkUI.Docking;

[ToolboxItem(false)]
public sealed class DarkDockGroup : Panel
{
	private List<DarkDockContent> workerObject = new List<DarkDockContent>();

	private Dictionary<DarkDockContent, DicParameter> m_AccountObject = new Dictionary<DarkDockContent, DicParameter>();

	private DecoratorProcessProducer _StateObject;

	private DicParameter m_AuthenticationObject;

	[CompilerGenerated]
	private DarkDockRegion m_InfoObject;

	public DarkDockPanel DockPanel { get; private set; }

	public DarkDockRegion DockRegion
	{
		[CompilerGenerated]
		get
		{
			return m_InfoObject;
		}
		[CompilerGenerated]
		private set
		{
			m_InfoObject = value;
		}
	}

	public DarkDockArea DockArea { get; private set; }

	public DarkDockContent VisibleContent { get; private set; }

	public int Order { get; set; }

	public int ContentCount => workerObject.Count;

	public DarkDockGroup(DarkDockPanel darkDockPanel_0, DarkDockRegion darkDockRegion_0, int int_0)
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, value: true);
		DockPanel = darkDockPanel_0;
		DockRegion = darkDockRegion_0;
		DockArea = darkDockRegion_0.DockArea;
		Order = int_0;
		_StateObject = new DecoratorProcessProducer(DockArea);
		DockPanel.ActiveContentChanged += ChangeListener;
	}

	public void AddContent(DarkDockContent darkDockContent_0)
	{
		darkDockContent_0.DockGroup = this;
		darkDockContent_0.Dock = DockStyle.Fill;
		darkDockContent_0.Order = 0;
		if (workerObject.Count > 0)
		{
			int num = -1;
			foreach (DarkDockContent item in workerObject)
			{
				if (item.Order >= num)
				{
					num = item.Order + 1;
				}
			}
			darkDockContent_0.Order = num;
		}
		workerObject.Add(darkDockContent_0);
		base.Controls.Add(darkDockContent_0);
		darkDockContent_0.DockTextChanged += InitListener;
		m_AccountObject.Add(darkDockContent_0, new DicParameter(darkDockContent_0));
		if (VisibleContent == null)
		{
			darkDockContent_0.Visible = true;
			VisibleContent = darkDockContent_0;
		}
		else
		{
			darkDockContent_0.Visible = false;
		}
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(darkDockContent_0.DockText);
		toolStripMenuItem.Tag = darkDockContent_0;
		toolStripMenuItem.Click += EnableListener;
		toolStripMenuItem.Image = darkDockContent_0.Icon;
		_StateObject.ConnectConfig(toolStripMenuItem);
		SetupListener();
	}

	public void RemoveContent(DarkDockContent darkDockContent_0)
	{
		darkDockContent_0.DockGroup = null;
		int order = darkDockContent_0.Order;
		workerObject.Remove(darkDockContent_0);
		base.Controls.Remove(darkDockContent_0);
		foreach (DarkDockContent item in workerObject)
		{
			if (item.Order > order)
			{
				item.Order--;
			}
		}
		darkDockContent_0.DockTextChanged -= InitListener;
		if (m_AccountObject.ContainsKey(darkDockContent_0))
		{
			m_AccountObject.Remove(darkDockContent_0);
		}
		if (VisibleContent == darkDockContent_0)
		{
			VisibleContent = null;
			if (workerObject.Count > 0)
			{
				DarkDockContent darkDockContent = workerObject[0];
				darkDockContent.Visible = true;
				VisibleContent = darkDockContent;
			}
		}
		ToolStripMenuItem toolStripMenuItem = _StateObject.DeleteConfig(darkDockContent_0);
		toolStripMenuItem.Click -= EnableListener;
		_StateObject.MoveConfig(toolStripMenuItem);
		SetupListener();
	}

	public List<DarkDockContent> GetContents()
	{
		return workerObject.OrderBy((DarkDockContent c) => c.Order).ToList();
	}

	private void SetupListener()
	{
		if (DockArea == DarkDockArea.Document)
		{
			_StateObject.Visible = workerObject.Count > 0;
		}
		else
		{
			_StateObject.Visible = workerObject.Count > 1;
		}
		int num = 0;
		switch (DockArea)
		{
		case DarkDockArea.Document:
			num = (_StateObject.Visible ? 24 : 0);
			base.Padding = new Padding(0, num, 0, 0);
			_StateObject.CallConfig(new Rectangle(base.Padding.Left, 0, base.ClientRectangle.Width - base.Padding.Horizontal, num));
			break;
		case DarkDockArea.Left:
		case DarkDockArea.Right:
			num = (_StateObject.Visible ? 21 : 0);
			base.Padding = new Padding(0, 0, 0, num);
			_StateObject.CallConfig(new Rectangle(base.Padding.Left, base.ClientRectangle.Bottom - num, base.ClientRectangle.Width - base.Padding.Horizontal, num));
			break;
		case DarkDockArea.Bottom:
			num = (_StateObject.Visible ? 21 : 0);
			base.Padding = new Padding(1, 0, 0, num);
			_StateObject.CallConfig(new Rectangle(base.Padding.Left, base.ClientRectangle.Bottom - num, base.ClientRectangle.Width - base.Padding.Horizontal, num));
			break;
		}
		if (DockArea == DarkDockArea.Document)
		{
			_StateObject.ValidateConfig(new Rectangle(_StateObject.SelectConfig().Right - 24, 0, 24, 24));
		}
		ExcludeListener();
		EnsureVisible();
	}

	private void ExcludeListener()
	{
		if (!_StateObject.Visible)
		{
			return;
		}
		SuspendLayout();
		int num = RequestDecoratorEntry.close.Width;
		int num2 = 0;
		IOrderedEnumerable<DarkDockContent> orderedEnumerable = workerObject.OrderBy((DarkDockContent c) => c.Order);
		foreach (DarkDockContent item in orderedEnumerable)
		{
			DicParameter dicParameter = m_AccountObject[item];
			int num3;
			using (Graphics graphics_ = CreateGraphics())
			{
				num3 = dicParameter.PrintListener(graphics_, Font);
			}
			if (DockArea == DarkDockArea.Document)
			{
				num3 += 5;
				num3 += num;
				if (dicParameter.DefineListener().Icon != null)
				{
					num3 += dicParameter.DefineListener().Icon.Width + 5;
				}
			}
			dicParameter.CountConfig(bool_0: true);
			num3++;
			int num4 = ((DockArea != DarkDockArea.Document) ? (base.ClientRectangle.Height - 21) : 0);
			int num5 = ((DockArea == DarkDockArea.Document) ? 24 : 21);
			Rectangle rectangle2 = new Rectangle(_StateObject.SelectConfig().Left + num2, num4, num3, num5);
			dicParameter.ResetListener(rectangle2);
			num2 += num3;
		}
		if (DockArea != DarkDockArea.Document && num2 > _StateObject.SelectConfig().Width)
		{
			int num6 = num2 - _StateObject.SelectConfig().Width;
			DicParameter dicParameter2 = m_AccountObject[orderedEnumerable.Last()];
			Rectangle rectangle3 = dicParameter2.QueryListener();
			dicParameter2.ResetListener(new Rectangle(rectangle3.Left, rectangle3.Top, rectangle3.Width - 1, rectangle3.Height));
			dicParameter2.CountConfig(bool_0: false);
			int num7 = 1;
			while (num7 < num6)
			{
				int num8 = m_AccountObject.Values.OrderByDescending((DicParameter tab) => tab.QueryListener().Width).First().QueryListener()
					.Width;
				foreach (DarkDockContent item2 in orderedEnumerable)
				{
					DicParameter dicParameter3 = m_AccountObject[item2];
					if (num7 < num6)
					{
						if (dicParameter3.QueryListener().Width >= num8)
						{
							Rectangle rectangle4 = dicParameter3.QueryListener();
							dicParameter3.ResetListener(new Rectangle(rectangle4.Left, rectangle4.Top, rectangle4.Width - 1, rectangle4.Height));
							num7++;
						}
						continue;
					}
					break;
				}
			}
			int num9 = 0;
			foreach (DarkDockContent item3 in orderedEnumerable)
			{
				DicParameter dicParameter4 = m_AccountObject[item3];
				Rectangle rectangle5 = dicParameter4.QueryListener();
				dicParameter4.ResetListener(new Rectangle(_StateObject.SelectConfig().Left + num9, rectangle5.Top, rectangle5.Width, rectangle5.Height));
				num9 += rectangle5.Width;
			}
		}
		if (DockArea == DarkDockArea.Document)
		{
			foreach (DarkDockContent item4 in orderedEnumerable)
			{
				DicParameter dicParameter5 = m_AccountObject[item4];
				Rectangle rectangle = new Rectangle(dicParameter5.QueryListener().Right - 7 - num - 1, dicParameter5.QueryListener().Top + dicParameter5.QueryListener().Height / 2 - num / 2 - 1, num, num);
				dicParameter5.CalcListener(rectangle);
			}
		}
		num2 = 0;
		foreach (DarkDockContent item5 in orderedEnumerable)
		{
			DicParameter dicParameter6 = m_AccountObject[item5];
			num2 += dicParameter6.QueryListener().Width;
		}
		_StateObject.ExcludeConfig(num2);
		ResumeLayout();
		Invalidate();
	}

	public void EnsureVisible()
	{
		if (DockArea != DarkDockArea.Document || VisibleContent == null)
		{
			return;
		}
		int num = base.ClientRectangle.Width - base.Padding.Horizontal - _StateObject.ViewConfig().Width;
		Rectangle rectangle = new Rectangle(base.Padding.Left, 0, num, 0);
		DicParameter dicParameter = m_AccountObject[VisibleContent];
		if (dicParameter.QueryListener().IsEmpty)
		{
			return;
		}
		if (SearchListener(dicParameter.QueryListener()).Left < rectangle.Left)
		{
			_StateObject.Offset = dicParameter.QueryListener().Left;
		}
		else if (SearchListener(dicParameter.QueryListener()).Right > rectangle.Right)
		{
			_StateObject.Offset = dicParameter.QueryListener().Right - num;
		}
		if (_StateObject.SetupConfig() < rectangle.Width)
		{
			_StateObject.Offset = 0;
		}
		if (_StateObject.SetupConfig() > rectangle.Width)
		{
			IOrderedEnumerable<DarkDockContent> source = workerObject.OrderBy((DarkDockContent x) => x.Order);
			DicParameter dicParameter2 = m_AccountObject[source.Last()];
			if (dicParameter2 != null && SearchListener(dicParameter2.QueryListener()).Right < rectangle.Right)
			{
				_StateObject.Offset = dicParameter2.QueryListener().Right - num;
			}
		}
		Invalidate();
	}

	public void SetVisibleContent(DarkDockContent darkDockContent_0)
	{
		if (!workerObject.Contains(darkDockContent_0) || VisibleContent == darkDockContent_0)
		{
			return;
		}
		VisibleContent = darkDockContent_0;
		darkDockContent_0.Visible = true;
		foreach (DarkDockContent item in workerObject)
		{
			if (item != darkDockContent_0)
			{
				item.Visible = false;
			}
		}
		Invalidate();
	}

	private Point IncludeListener(Point point_0)
	{
		return new Point(point_0.X - _StateObject.Offset, point_0.Y);
	}

	private Rectangle SearchListener(Rectangle rectangle_0)
	{
		return new Rectangle(IncludeListener(rectangle_0.Location), rectangle_0.Size);
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		SetupListener();
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		if (m_AuthenticationObject == null)
		{
			if (_StateObject.ViewConfig().Contains(e.Location))
			{
				_StateObject.WriteConfig(bool_0: true);
				foreach (DicParameter value in m_AccountObject.Values)
				{
					value.ForgotListener(bool_0: false);
				}
				Invalidate();
				return;
			}
			_StateObject.WriteConfig(bool_0: false);
			{
				foreach (DicParameter value2 in m_AccountObject.Values)
				{
					bool flag = SearchListener(value2.QueryListener()).Contains(e.Location);
					if (value2.FlushListener() != flag)
					{
						value2.ForgotListener(flag);
						Invalidate();
					}
					bool flag2 = SearchListener(value2.SortListener()).Contains(e.Location);
					if (value2.OrderListener() != flag2)
					{
						value2.RegisterListener(flag2);
						Invalidate();
					}
				}
				return;
			}
		}
		int num = e.Location.X + _StateObject.Offset;
		if (num < m_AuthenticationObject.QueryListener().Left)
		{
			if (m_AuthenticationObject.DefineListener().Order <= 0)
			{
				return;
			}
			List<DicParameter> list = m_AccountObject.Values.Where((DicParameter dicParameter_0) => dicParameter_0.DefineListener().Order == m_AuthenticationObject.DefineListener().Order - 1).ToList();
			if (list.Count != 0)
			{
				DicParameter dicParameter = list.First();
				if (dicParameter != null)
				{
					int order = m_AuthenticationObject.DefineListener().Order;
					m_AuthenticationObject.DefineListener().Order = order - 1;
					dicParameter.DefineListener().Order = order;
					ExcludeListener();
					EnsureVisible();
					_StateObject.AddConfig();
				}
			}
		}
		else
		{
			if (num <= m_AuthenticationObject.QueryListener().Right)
			{
				return;
			}
			int count = workerObject.Count;
			if (m_AuthenticationObject.DefineListener().Order >= count)
			{
				return;
			}
			List<DicParameter> list2 = m_AccountObject.Values.Where((DicParameter dicParameter_0) => dicParameter_0.DefineListener().Order == m_AuthenticationObject.DefineListener().Order + 1).ToList();
			if (list2.Count != 0)
			{
				DicParameter dicParameter2 = list2.First();
				if (dicParameter2 != null)
				{
					int order2 = m_AuthenticationObject.DefineListener().Order;
					m_AuthenticationObject.DefineListener().Order = order2 + 1;
					dicParameter2.DefineListener().Order = order2;
					ExcludeListener();
					EnsureVisible();
					_StateObject.AddConfig();
				}
			}
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (_StateObject.ViewConfig().Contains(e.Location))
		{
			_StateObject.WriteConfig(bool_0: true);
			return;
		}
		foreach (DicParameter value in m_AccountObject.Values)
		{
			if (SearchListener(value.QueryListener()).Contains(e.Location))
			{
				if (e.Button == MouseButtons.Middle)
				{
					value.DefineListener().Close();
					return;
				}
				if (SearchListener(value.SortListener()).Contains(e.Location))
				{
					_StateObject.InitConfig(value);
					return;
				}
				DockPanel.ActiveContent = value.DefineListener();
				EnsureVisible();
				m_AuthenticationObject = value;
				return;
			}
		}
		if (VisibleContent != null)
		{
			DockPanel.ActiveContent = VisibleContent;
		}
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
		m_AuthenticationObject = null;
		if (_StateObject.ViewConfig().Contains(mevent.Location))
		{
			if (_StateObject.GetConfig())
			{
				_StateObject.CloneConfig(this, new Point(_StateObject.ViewConfig().Left, _StateObject.ViewConfig().Bottom - 2));
			}
		}
		else if (_StateObject.ChangeConfig() != null && SearchListener(_StateObject.ChangeConfig().SortListener()).Contains(mevent.Location))
		{
			_StateObject.ChangeConfig().DefineListener().Close();
		}
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		foreach (DicParameter value in m_AccountObject.Values)
		{
			value.ForgotListener(bool_0: false);
		}
		Invalidate();
	}

	private void EnableListener(object sender, EventArgs e)
	{
		if (sender is ToolStripMenuItem { Tag: DarkDockContent activeContent })
		{
			DockPanel.ActiveContent = activeContent;
		}
	}

	private void ChangeListener(object sender, DockContentEventArgs e)
	{
		if (!workerObject.Contains(e.Content))
		{
			return;
		}
		if (e.Content == VisibleContent)
		{
			VisibleContent.Focus();
			return;
		}
		VisibleContent = e.Content;
		foreach (DarkDockContent item in workerObject)
		{
			item.Visible = item == VisibleContent;
		}
		VisibleContent.Focus();
		EnsureVisible();
		Invalidate();
	}

	private void InitListener(object sender, EventArgs e)
	{
		ExcludeListener();
	}

	public void Redraw()
	{
		Invalidate();
		foreach (DarkDockContent item in workerObject)
		{
			item.Invalidate();
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		using (SolidBrush brush = new SolidBrush(Colors.GreyBackground))
		{
			graphics.FillRectangle(brush, base.ClientRectangle);
		}
		if (!_StateObject.Visible)
		{
			return;
		}
		using (SolidBrush brush2 = new SolidBrush(Colors.MediumBackground))
		{
			graphics.FillRectangle(brush2, _StateObject.SelectConfig());
		}
		foreach (DicParameter value in m_AccountObject.Values)
		{
			if (DockArea == DarkDockArea.Document)
			{
				CheckListener(graphics, value);
			}
			else
			{
				ConcatListener(graphics, value);
			}
		}
		if (DockArea != DarkDockArea.Document)
		{
			return;
		}
		using (SolidBrush brush3 = new SolidBrush((DockPanel.ActiveGroup == this) ? Colors.BlueSelection : Colors.GreySelection))
		{
			Rectangle rect = new Rectangle(_StateObject.SelectConfig().Left, _StateObject.SelectConfig().Bottom - 2, _StateObject.SelectConfig().Width, 2);
			graphics.FillRectangle(brush3, rect);
		}
		Rectangle rect2 = new Rectangle(_StateObject.ViewConfig().Left, _StateObject.ViewConfig().Top, _StateObject.ViewConfig().Width, _StateObject.ViewConfig().Height - 2);
		using (SolidBrush brush4 = new SolidBrush(Colors.MediumBackground))
		{
			graphics.FillRectangle(brush4, rect2);
		}
		using Bitmap bitmap = RequestDecoratorEntry.arrow;
		graphics.DrawImageUnscaled(bitmap, rect2.Left + rect2.Width / 2 - bitmap.Width / 2, rect2.Top + rect2.Height / 2 - bitmap.Height / 2 + 1);
	}

	private void CheckListener(Graphics graphics_0, DicParameter dicParameter_0)
	{
		Rectangle rect = SearchListener(dicParameter_0.QueryListener());
		bool flag = VisibleContent == dicParameter_0.DefineListener();
		bool flag2 = DockPanel.ActiveGroup == this;
		Color color = (flag ? Colors.BlueSelection : Colors.DarkBackground);
		if (!flag2)
		{
			color = (flag ? Colors.GreySelection : Colors.DarkBackground);
		}
		if (dicParameter_0.FlushListener() && !flag)
		{
			color = Colors.MediumBackground;
		}
		using (SolidBrush brush = new SolidBrush(color))
		{
			graphics_0.FillRectangle(brush, rect);
		}
		if (dicParameter_0.RevertListener())
		{
			using Pen pen = new Pen(Colors.DarkBorder);
			graphics_0.DrawLine(pen, rect.Right - 1, rect.Top, rect.Right - 1, rect.Bottom);
		}
		int num = 0;
		if (dicParameter_0.DefineListener().Icon != null)
		{
			graphics_0.DrawImageUnscaled(dicParameter_0.DefineListener().Icon, rect.Left + 5, rect.Top + 4);
			num += dicParameter_0.DefineListener().Icon.Width + 2;
		}
		StringFormat format = new StringFormat
		{
			Alignment = StringAlignment.Near,
			LineAlignment = StringAlignment.Center,
			FormatFlags = StringFormatFlags.NoWrap,
			Trimming = StringTrimming.EllipsisCharacter
		};
		using (SolidBrush brush2 = new SolidBrush(flag ? Colors.LightText : Colors.DisabledText))
		{
			Rectangle rectangle = new Rectangle(rect.Left + 5 + num, rect.Top, rect.Width - dicParameter_0.SortListener().Width - 7 - 5 - num, rect.Height);
			graphics_0.DrawString(dicParameter_0.DefineListener().DockText, Font, brush2, rectangle, format);
		}
		Bitmap image = (dicParameter_0.OrderListener() ? RequestDecoratorEntry.inactive_close_selected : RequestDecoratorEntry.inactive_close);
		if (flag)
		{
			image = (flag2 ? (dicParameter_0.OrderListener() ? RequestDecoratorEntry.close_selected : RequestDecoratorEntry.close) : (dicParameter_0.OrderListener() ? RequestDecoratorEntry.close_selected : RequestDecoratorEntry.active_inactive_close));
		}
		Rectangle rectangle2 = SearchListener(dicParameter_0.SortListener());
		graphics_0.DrawImageUnscaled(image, rectangle2.Left, rectangle2.Top);
	}

	private void ConcatListener(Graphics graphics_0, DicParameter dicParameter_0)
	{
		Rectangle rect = dicParameter_0.QueryListener();
		bool flag;
		Color color = ((flag = VisibleContent == dicParameter_0.DefineListener()) ? Colors.GreyBackground : Colors.DarkBackground);
		if (dicParameter_0.FlushListener() && !flag)
		{
			color = Colors.MediumBackground;
		}
		using (SolidBrush brush = new SolidBrush(color))
		{
			graphics_0.FillRectangle(brush, rect);
		}
		if (dicParameter_0.RevertListener())
		{
			using Pen pen = new Pen(Colors.DarkBorder);
			graphics_0.DrawLine(pen, rect.Right - 1, rect.Top, rect.Right - 1, rect.Bottom);
		}
		StringFormat format = new StringFormat
		{
			Alignment = StringAlignment.Near,
			LineAlignment = StringAlignment.Center,
			FormatFlags = StringFormatFlags.NoWrap,
			Trimming = StringTrimming.EllipsisCharacter
		};
		using SolidBrush brush2 = new SolidBrush(flag ? Colors.BlueHighlight : Colors.DisabledText);
		graphics_0.DrawString(layoutRectangle: new Rectangle(rect.Left + 5, rect.Top, rect.Width - 5, rect.Height), s: dicParameter_0.DefineListener().DockText, font: Font, brush: brush2, format: format);
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
	}

	[CompilerGenerated]
	private bool InterruptListener(DicParameter dicParameter_0)
	{
		return dicParameter_0.DefineListener().Order == m_AuthenticationObject.DefineListener().Order - 1;
	}

	[CompilerGenerated]
	private bool RemoveListener(DicParameter dicParameter_0)
	{
		return dicParameter_0.DefineListener().Order == m_AuthenticationObject.DefineListener().Order + 1;
	}
}
