using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Docking;

[ToolboxItem(false)]
public sealed class DarkDockRegion : Panel
{
	private List<DarkDockGroup> _ObjectParameter;

	private Form _ParameterParameter;

	private DarkDockSplitter expressionParameter;

	[CompilerGenerated]
	private DarkDockPanel m_DispatcherParameter;

	[CompilerGenerated]
	private DarkDockArea listenerParameter;

	public DarkDockPanel DockPanel
	{
		[CompilerGenerated]
		get
		{
			return m_DispatcherParameter;
		}
		[CompilerGenerated]
		private set
		{
			m_DispatcherParameter = value;
		}
	}

	public DarkDockArea DockArea
	{
		[CompilerGenerated]
		get
		{
			return listenerParameter;
		}
		[CompilerGenerated]
		private set
		{
			listenerParameter = value;
		}
	}

	public DarkDockContent ActiveDocument
	{
		get
		{
			if (DockArea == DarkDockArea.Document && _ObjectParameter.Count != 0)
			{
				return _ObjectParameter[0].VisibleContent;
			}
			return null;
		}
	}

	public List<DarkDockGroup> Groups => _ObjectParameter.ToList();

	public DarkDockRegion(DarkDockPanel darkDockPanel_0, DarkDockArea darkDockArea_0)
	{
		_ObjectParameter = new List<DarkDockGroup>();
		DockPanel = darkDockPanel_0;
		DockArea = darkDockArea_0;
		VerifyListener();
	}

	internal void UpdateListener(DarkDockContent darkDockContent_0)
	{
		InsertListener(darkDockContent_0, null);
	}

	internal void InsertListener(DarkDockContent darkDockContent_0, DarkDockGroup darkDockGroup_0)
	{
		if (darkDockGroup_0 == null)
		{
			darkDockGroup_0 = ((DockArea != DarkDockArea.Document || _ObjectParameter.Count <= 0) ? VisitListener() : _ObjectParameter[0]);
		}
		darkDockContent_0.DockRegion = this;
		darkDockGroup_0.AddContent(darkDockContent_0);
		if (!base.Visible)
		{
			base.Visible = true;
			ListListener();
		}
		StopListener();
	}

	internal void PrepareListener(DarkDockContent darkDockContent_0, DarkDockGroup darkDockGroup_0, DockInsertType dockInsertType_0)
	{
		int num = darkDockGroup_0.Order;
		if (dockInsertType_0 == DockInsertType.After)
		{
			num++;
		}
		DarkDockGroup darkDockGroup = RestartListener(num);
		darkDockContent_0.DockRegion = this;
		darkDockGroup.AddContent(darkDockContent_0);
		if (!base.Visible)
		{
			base.Visible = true;
			ListListener();
		}
		StopListener();
	}

	internal void ReflectListener(DarkDockContent darkDockContent_0)
	{
		darkDockContent_0.DockRegion = null;
		DarkDockGroup dockGroup = darkDockContent_0.DockGroup;
		dockGroup.RemoveContent(darkDockContent_0);
		darkDockContent_0.DockArea = DarkDockArea.None;
		if (dockGroup.ContentCount == 0)
		{
			TestListener(dockGroup);
		}
		if (_ObjectParameter.Count == 0 && DockArea != DarkDockArea.Document)
		{
			base.Visible = false;
			ResolveListener();
		}
		StopListener();
	}

	public List<DarkDockContent> GetContents()
	{
		List<DarkDockContent> list = new List<DarkDockContent>();
		foreach (DarkDockGroup item in _ObjectParameter)
		{
			list.AddRange(item.GetContents());
		}
		return list;
	}

	private DarkDockGroup VisitListener()
	{
		int num = 0;
		if (_ObjectParameter.Count >= 1)
		{
			num = -1;
			foreach (DarkDockGroup item in _ObjectParameter)
			{
				if (item.Order >= num)
				{
					num = item.Order + 1;
				}
			}
		}
		DarkDockGroup darkDockGroup = new DarkDockGroup(DockPanel, this, num);
		_ObjectParameter.Add(darkDockGroup);
		base.Controls.Add(darkDockGroup);
		return darkDockGroup;
	}

	private DarkDockGroup RestartListener(int int_0)
	{
		foreach (DarkDockGroup item in _ObjectParameter)
		{
			if (item.Order >= int_0)
			{
				item.Order++;
			}
		}
		DarkDockGroup darkDockGroup = new DarkDockGroup(DockPanel, this, int_0);
		_ObjectParameter.Add(darkDockGroup);
		base.Controls.Add(darkDockGroup);
		return darkDockGroup;
	}

	private void TestListener(DarkDockGroup darkDockGroup_0)
	{
		int order = darkDockGroup_0.Order;
		_ObjectParameter.Remove(darkDockGroup_0);
		base.Controls.Remove(darkDockGroup_0);
		foreach (DarkDockGroup item in _ObjectParameter)
		{
			if (item.Order > order)
			{
				item.Order--;
			}
		}
	}

	private void StopListener()
	{
		DockStyle dock;
		switch (DockArea)
		{
		case DarkDockArea.Bottom:
			dock = DockStyle.Left;
			break;
		default:
			dock = DockStyle.Fill;
			break;
		case DarkDockArea.Left:
		case DarkDockArea.Right:
			dock = DockStyle.Top;
			break;
		}
		if (_ObjectParameter.Count == 1)
		{
			_ObjectParameter[0].Dock = DockStyle.Fill;
		}
		else
		{
			if (_ObjectParameter.Count <= 1)
			{
				return;
			}
			DarkDockGroup darkDockGroup = _ObjectParameter.OrderByDescending((DarkDockGroup g) => g.Order).First();
			foreach (DarkDockGroup item in _ObjectParameter.OrderByDescending((DarkDockGroup g) => g.Order))
			{
				item.SendToBack();
				if (item.Order == darkDockGroup.Order)
				{
					item.Dock = DockStyle.Fill;
				}
				else
				{
					item.Dock = dock;
				}
			}
			CancelListener();
		}
	}

	private void CancelListener()
	{
		if (_ObjectParameter.Count <= 1)
		{
			return;
		}
		Size size = new Size(0, 0);
		switch (DockArea)
		{
		default:
			return;
		case DarkDockArea.Bottom:
			size = new Size(base.ClientRectangle.Width / _ObjectParameter.Count, base.ClientRectangle.Height);
			break;
		case DarkDockArea.Left:
		case DarkDockArea.Right:
			size = new Size(base.ClientRectangle.Width, base.ClientRectangle.Height / _ObjectParameter.Count);
			break;
		}
		foreach (DarkDockGroup item in _ObjectParameter)
		{
			item.Size = size;
		}
	}

	private void VerifyListener()
	{
		MinimumSize = new Size(50, 50);
		switch (DockArea)
		{
		default:
			Dock = DockStyle.Fill;
			base.Padding = new Padding(0, 1, 0, 0);
			break;
		case DarkDockArea.Left:
			Dock = DockStyle.Left;
			base.Padding = new Padding(0, 0, 1, 0);
			base.Visible = false;
			break;
		case DarkDockArea.Right:
			Dock = DockStyle.Right;
			base.Padding = new Padding(1, 0, 0, 0);
			base.Visible = false;
			break;
		case DarkDockArea.Bottom:
			Dock = DockStyle.Bottom;
			base.Padding = new Padding(0, 0, 0, 0);
			base.Visible = false;
			break;
		}
	}

	private void ListListener()
	{
		if (expressionParameter != null && DockPanel.Splitters.Contains(expressionParameter))
		{
			DockPanel.Splitters.Remove(expressionParameter);
		}
		switch (DockArea)
		{
		default:
			return;
		case DarkDockArea.Left:
			expressionParameter = new DarkDockSplitter(DockPanel, this, DarkSplitterType.Right);
			break;
		case DarkDockArea.Right:
			expressionParameter = new DarkDockSplitter(DockPanel, this, DarkSplitterType.Left);
			break;
		case DarkDockArea.Bottom:
			expressionParameter = new DarkDockSplitter(DockPanel, this, DarkSplitterType.Top);
			break;
		}
		DockPanel.Splitters.Add(expressionParameter);
	}

	private void ResolveListener()
	{
		if (DockPanel.Splitters.Contains(expressionParameter))
		{
			DockPanel.Splitters.Remove(expressionParameter);
		}
	}

	protected override void OnCreateControl()
	{
		base.OnCreateControl();
		_ParameterParameter = FindForm();
		_ParameterParameter.ResizeEnd += PostListener;
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		CancelListener();
	}

	private void PostListener(object sender, EventArgs e)
	{
		if (expressionParameter != null)
		{
			expressionParameter.UpdateBounds();
		}
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		base.OnLayout(levent);
		if (expressionParameter != null)
		{
			expressionParameter.UpdateBounds();
		}
	}

	public void Redraw()
	{
		Invalidate();
		foreach (DarkDockGroup item in _ObjectParameter)
		{
			item.Redraw();
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		if (!base.Visible)
		{
			return;
		}
		using (SolidBrush brush = new SolidBrush(Colors.GreyBackground))
		{
			graphics.FillRectangle(brush, base.ClientRectangle);
		}
		using Pen pen = new Pen(Colors.DarkBorder);
		if (DockArea == DarkDockArea.Document)
		{
			graphics.DrawLine(pen, base.ClientRectangle.Left, 0, base.ClientRectangle.Right, 0);
		}
		if (DockArea == DarkDockArea.Right)
		{
			graphics.DrawLine(pen, base.ClientRectangle.Left, 0, base.ClientRectangle.Left, base.ClientRectangle.Height);
		}
		if (DockArea == DarkDockArea.Left)
		{
			graphics.DrawLine(pen, base.ClientRectangle.Right - 1, 0, base.ClientRectangle.Right - 1, base.ClientRectangle.Height);
		}
	}
}
