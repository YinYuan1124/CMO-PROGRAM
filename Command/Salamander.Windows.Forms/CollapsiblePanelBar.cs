using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Salamander.Windows.Forms;

public sealed class CollapsiblePanelBar : Panel, ISupportInitialize
{
	private CollapsiblePanelCollection _AdvisorCallback = new CollapsiblePanelCollection();

	private int customerCallback = 8;

	private int m_SerializerCallback = 8;

	private bool _RefCallback;

	[Browsable(false)]
	public CollapsiblePanelCollection CollapsiblePanelCollection => _AdvisorCallback;

	public int Border
	{
		get
		{
			return customerCallback;
		}
		set
		{
			customerCallback = value;
			RevertCallback(_AdvisorCallback.Count - 1);
		}
	}

	public int Spacing
	{
		get
		{
			return m_SerializerCallback;
		}
		set
		{
			m_SerializerCallback = value;
			RevertCallback(_AdvisorCallback.Count - 1);
		}
	}

	public CollapsiblePanelBar()
	{
		ManageCallback();
		BackColor = Color.CornflowerBlue;
	}

	private void ManageCallback()
	{
	}

	public void BeginInit()
	{
		_RefCallback = true;
	}

	public void EndInit()
	{
		_RefCallback = false;
	}

	private void RevertCallback(int int_0)
	{
		for (int num = int_0; num >= 0; num--)
		{
			if (num == _AdvisorCallback.Count - 1)
			{
				_AdvisorCallback.Item(num).Top = customerCallback;
			}
			else
			{
				_AdvisorCallback.Item(num).Top = _AdvisorCallback.Item(num + 1).Bottom + customerCallback;
			}
			_AdvisorCallback.Item(num).Left = m_SerializerCallback;
			_AdvisorCallback.Item(num).Width = base.Width - 2 * m_SerializerCallback;
			if (base.VScroll)
			{
				_AdvisorCallback.Item(num).Width -= SystemInformation.VerticalScrollBarWidth;
			}
		}
	}

	protected override void OnControlAdded(ControlEventArgs e)
	{
		base.OnControlAdded(e);
		if (e.Control is CollapsiblePanel)
		{
			e.Control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			if (_RefCallback)
			{
				_AdvisorCallback.Add((CollapsiblePanel)e.Control);
				_AdvisorCallback.Item(_AdvisorCallback.Count - 1).PanelStateChanged += CountDecorator;
			}
			else
			{
				_AdvisorCallback.Insert(0, (CollapsiblePanel)e.Control);
				_AdvisorCallback.Item(0).PanelStateChanged += CountDecorator;
			}
			RevertCallback(_AdvisorCallback.Count - 1);
		}
	}

	protected override void OnControlRemoved(ControlEventArgs e)
	{
		base.OnControlRemoved(e);
		if (e.Control is CollapsiblePanel)
		{
			int num = _AdvisorCallback.IndexOf((CollapsiblePanel)e.Control);
			if (-1 != num)
			{
				_AdvisorCallback.Remove(num);
				RevertCallback(_AdvisorCallback.Count - 1);
			}
		}
	}

	private void CountDecorator(object sender, PanelEventArgs e)
	{
		int num = _AdvisorCallback.IndexOf(e.CollapsiblePanel);
		if (-1 != num)
		{
			RevertCallback(--num);
		}
	}
}
