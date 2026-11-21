using System;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Docking;

namespace DarkUI.Win32;

public sealed class DockResizeFilter : IMessageFilter
{
	private DarkDockPanel _QueueObject;

	private Timer _RegObject;

	private bool m_ParamObject;

	private Point _PageObject;

	private DarkDockSplitter rulesObject;

	public DockResizeFilter(DarkDockPanel darkDockPanel_0)
	{
		_QueueObject = darkDockPanel_0;
		_RegObject = new Timer();
		_RegObject.Interval = 1;
		_RegObject.Tick += ForgotDispatcher;
	}

	public bool PreFilterMessage(ref Message m)
	{
		if (m.Msg != 512 && m.Msg != 513 && m.Msg != 514 && m.Msg != 515 && m.Msg != 516 && m.Msg != 517 && m.Msg != 518)
		{
			return false;
		}
		if (m.Msg == 514 && m_ParamObject)
		{
			OrderDispatcher();
			return true;
		}
		if (m.Msg == 514 && !m_ParamObject)
		{
			return false;
		}
		if (m_ParamObject)
		{
			Cursor.Current = rulesObject.ResizeCursor;
		}
		if (m.Msg == 512 && !m_ParamObject && _QueueObject.MouseButtonState != 0)
		{
			return false;
		}
		Control control = Control.FromHandle(m.HWnd);
		if (control == null)
		{
			return false;
		}
		if (control != _QueueObject && !_QueueObject.Contains(control))
		{
			return false;
		}
		ManageDispatcher();
		if (m.Msg == 513)
		{
			DarkDockSplitter darkDockSplitter = RegisterDispatcher();
			if (darkDockSplitter != null)
			{
				CollectDispatcher(darkDockSplitter);
				return true;
			}
		}
		if (RegisterDispatcher() == null)
		{
			if (m_ParamObject)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	private void ForgotDispatcher(object sender, EventArgs e)
	{
		if (_QueueObject.MouseButtonState == MouseButtons.Left)
		{
			Point point_ = new Point(_PageObject.X - Cursor.Position.X, _PageObject.Y - Cursor.Position.Y);
			rulesObject.UpdateOverlay(point_);
		}
		else
		{
			OrderDispatcher();
		}
	}

	private void CollectDispatcher(DarkDockSplitter darkDockSplitter_0)
	{
		rulesObject = darkDockSplitter_0;
		Cursor.Current = rulesObject.ResizeCursor;
		_PageObject = Cursor.Position;
		m_ParamObject = true;
		rulesObject.ShowOverlay();
		_RegObject.Start();
	}

	private void OrderDispatcher()
	{
		_RegObject.Stop();
		rulesObject.HideOverlay();
		Point point_ = new Point(_PageObject.X - Cursor.Position.X, _PageObject.Y - Cursor.Position.Y);
		rulesObject.Move(point_);
		m_ParamObject = false;
	}

	private DarkDockSplitter RegisterDispatcher()
	{
		foreach (DarkDockSplitter splitter in _QueueObject.Splitters)
		{
			if (splitter.Bounds.Contains(Cursor.Position))
			{
				return splitter;
			}
		}
		return null;
	}

	private void ManageDispatcher()
	{
		if (!m_ParamObject)
		{
			DarkDockSplitter darkDockSplitter = RegisterDispatcher();
			if (darkDockSplitter != null)
			{
				Cursor.Current = darkDockSplitter.ResizeCursor;
			}
		}
	}

	private void RevertDispatcher()
	{
		Cursor.Current = Cursors.Default;
		ManageDispatcher();
	}
}
