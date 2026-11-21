using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Command.Tasks;
using DarkUI.Config;
using DarkUI.Docking;
using OpenDis.Candidates;
using OpenDis.Database;

namespace DarkUI.Win32;

public sealed class DockContentDragFilter : IMessageFilter
{
	private DarkDockPanel m_ComparatorObject;

	private DarkDockContent m_ItemObject;

	private ValueDecoratorEntry setterObject;

	private bool m_CreatorObject;

	private DarkDockRegion m_TemplateObject;

	private DarkDockGroup _MappingObject;

	private DockInsertType m_MockObject;

	private Dictionary<DarkDockRegion, TokenCallbackCandidate> tagObject = new Dictionary<DarkDockRegion, TokenCallbackCandidate>();

	private Dictionary<DarkDockGroup, InstanceCollectionTask> _FieldObject = new Dictionary<DarkDockGroup, InstanceCollectionTask>();

	public DockContentDragFilter(DarkDockPanel darkDockPanel_0)
	{
		m_ComparatorObject = darkDockPanel_0;
		setterObject = new ValueDecoratorEntry(Colors.BlueSelection);
	}

	public bool PreFilterMessage(ref Message m)
	{
		if (m_CreatorObject)
		{
			if (m.Msg != 512 && m.Msg != 513 && m.Msg != 514 && m.Msg != 515 && m.Msg != 516 && m.Msg != 517 && m.Msg != 518)
			{
				return false;
			}
			if (m.Msg == 512)
			{
				FlushDispatcher();
				return false;
			}
			if (m.Msg == 514)
			{
				if (m_TemplateObject == null)
				{
					if (_MappingObject != null)
					{
						m_ComparatorObject.RemoveContent(m_ItemObject);
						switch (m_MockObject)
						{
						case DockInsertType.Before:
						case DockInsertType.After:
							m_ComparatorObject.InsertContent(m_ItemObject, _MappingObject, m_MockObject);
							break;
						case DockInsertType.None:
							m_ComparatorObject.AddContent(m_ItemObject, _MappingObject);
							break;
						}
					}
				}
				else
				{
					m_ComparatorObject.RemoveContent(m_ItemObject);
					m_ItemObject.DockArea = m_TemplateObject.DockArea;
					m_ComparatorObject.AddContent(m_ItemObject);
				}
				CalcDispatcher();
				return false;
			}
			return true;
		}
		return false;
	}

	public void StartDrag(DarkDockContent darkDockContent_0)
	{
		tagObject = new Dictionary<DarkDockRegion, TokenCallbackCandidate>();
		_FieldObject = new Dictionary<DarkDockGroup, InstanceCollectionTask>();
		foreach (DarkDockRegion value3 in m_ComparatorObject.Regions.Values)
		{
			if (value3.DockArea == DarkDockArea.Document)
			{
				continue;
			}
			if (value3.Visible)
			{
				foreach (DarkDockGroup group in value3.Groups)
				{
					InstanceCollectionTask value = new InstanceCollectionTask(m_ComparatorObject, group);
					_FieldObject.Add(group, value);
				}
			}
			else
			{
				TokenCallbackCandidate value2 = new TokenCallbackCandidate(m_ComparatorObject, value3);
				tagObject.Add(value3, value2);
			}
		}
		m_ItemObject = darkDockContent_0;
		m_CreatorObject = true;
	}

	private void CalcDispatcher()
	{
		Cursor.Current = Cursors.Default;
		setterObject.Hide();
		m_ItemObject = null;
		m_CreatorObject = false;
	}

	private void RateDispatcher(Rectangle rectangle_0)
	{
		Cursor.Current = Cursors.SizeAll;
		setterObject.SuspendLayout();
		setterObject.Size = new Size(rectangle_0.Width, rectangle_0.Height);
		setterObject.Location = new Point(rectangle_0.X, rectangle_0.Y);
		setterObject.ResumeLayout();
		if (!setterObject.Visible)
		{
			setterObject.Show();
			setterObject.BringToFront();
		}
	}

	private void FlushDispatcher()
	{
		Point position = Cursor.Position;
		m_MockObject = DockInsertType.None;
		m_TemplateObject = null;
		_MappingObject = null;
		foreach (TokenCallbackCandidate value in tagObject.Values)
		{
			if (value.CreateConfig().Contains(position))
			{
				m_MockObject = DockInsertType.None;
				m_TemplateObject = value.PrepareConfig();
				RateDispatcher(value.DisableConfig());
				return;
			}
		}
		foreach (InstanceCollectionTask value2 in _FieldObject.Values)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			if (value2.ResolveConfig().RestartConfig() == m_ItemObject.DockGroup)
			{
				flag2 = true;
			}
			if (value2.ResolveConfig().RestartConfig().DockRegion == m_ItemObject.DockRegion)
			{
				flag = true;
			}
			if (m_ItemObject.DockGroup.ContentCount > 1)
			{
				flag3 = true;
			}
			if (!flag2 || flag3)
			{
				bool flag4 = false;
				bool flag5 = false;
				if (flag && !flag3)
				{
					if (value2.StartConfig().RestartConfig().Order == m_ItemObject.DockGroup.Order + 1)
					{
						flag4 = true;
					}
					if (value2.DefineConfig().RestartConfig().Order == m_ItemObject.DockGroup.Order - 1)
					{
						flag5 = true;
					}
				}
				if (!flag4 && value2.StartConfig().CreateConfig().Contains(position))
				{
					m_MockObject = DockInsertType.Before;
					_MappingObject = value2.StartConfig().RestartConfig();
					RateDispatcher(value2.StartConfig().DisableConfig());
					return;
				}
				if (!flag5 && value2.DefineConfig().CreateConfig().Contains(position))
				{
					m_MockObject = DockInsertType.After;
					_MappingObject = value2.DefineConfig().RestartConfig();
					RateDispatcher(value2.DefineConfig().DisableConfig());
					return;
				}
			}
			if (!flag2 && value2.ResolveConfig().CreateConfig().Contains(position))
			{
				m_MockObject = DockInsertType.None;
				_MappingObject = value2.ResolveConfig().RestartConfig();
				RateDispatcher(value2.ResolveConfig().DisableConfig());
				return;
			}
		}
		if (setterObject.Visible)
		{
			setterObject.Hide();
		}
		Cursor.Current = Cursors.No;
	}
}
