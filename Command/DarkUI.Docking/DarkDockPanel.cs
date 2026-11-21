using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using DarkUI.Config;
using DarkUI.Win32;

namespace DarkUI.Docking;

public sealed class DarkDockPanel : UserControl
{
	private List<DarkDockContent> getterObject;

	private Dictionary<DarkDockArea, DarkDockRegion> _ProducerObject;

	private DarkDockContent _ProcObject;

	private bool m_StructParameter;

	[CompilerGenerated]
	private DarkDockRegion m_MerchantParameter;

	[CompilerGenerated]
	private DarkDockGroup m_ProcessParameter;

	[CompilerGenerated]
	private List<DarkDockSplitter> threadParameter;

	[CompilerGenerated]
	private EventHandler<DockContentEventArgs> ruleParameter;

	[CompilerGenerated]
	private EventHandler<DockContentEventArgs> m_CollectionParameter;

	[CompilerGenerated]
	private EventHandler<DockContentEventArgs> _InstanceParameter;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DarkDockContent ActiveContent
	{
		get
		{
			return _ProcObject;
		}
		set
		{
			if (m_StructParameter)
			{
				return;
			}
			m_StructParameter = true;
			_ProcObject = value;
			ActiveGroup = _ProcObject.DockGroup;
			ActiveRegion = ActiveGroup.DockRegion;
			foreach (DarkDockRegion value2 in _ProducerObject.Values)
			{
				value2.Redraw();
			}
			if (ruleParameter != null)
			{
				ruleParameter(this, new DockContentEventArgs(_ProcObject));
			}
			m_StructParameter = false;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public DarkDockRegion ActiveRegion
	{
		[CompilerGenerated]
		get
		{
			return m_MerchantParameter;
		}
		[CompilerGenerated]
		internal set
		{
			m_MerchantParameter = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public DarkDockGroup ActiveGroup
	{
		[CompilerGenerated]
		get
		{
			return m_ProcessParameter;
		}
		[CompilerGenerated]
		internal set
		{
			m_ProcessParameter = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public DarkDockContent ActiveDocument => _ProducerObject[DarkDockArea.Document].ActiveDocument;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DockContentDragFilter DockContentDragFilter { get; private set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public DockResizeFilter DockResizeFilter { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public List<DarkDockSplitter> Splitters
	{
		[CompilerGenerated]
		get
		{
			return threadParameter;
		}
		[CompilerGenerated]
		private set
		{
			threadParameter = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public MouseButtons MouseButtonState => Control.MouseButtons;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public Dictionary<DarkDockArea, DarkDockRegion> Regions => _ProducerObject;

	public event EventHandler<DockContentEventArgs> ActiveContentChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler<DockContentEventArgs> eventHandler = ruleParameter;
			EventHandler<DockContentEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<DockContentEventArgs> value2 = (EventHandler<DockContentEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref ruleParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<DockContentEventArgs> eventHandler = ruleParameter;
			EventHandler<DockContentEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<DockContentEventArgs> value2 = (EventHandler<DockContentEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref ruleParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<DockContentEventArgs> ContentAdded
	{
		[CompilerGenerated]
		add
		{
			EventHandler<DockContentEventArgs> eventHandler = m_CollectionParameter;
			EventHandler<DockContentEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<DockContentEventArgs> value2 = (EventHandler<DockContentEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_CollectionParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<DockContentEventArgs> eventHandler = m_CollectionParameter;
			EventHandler<DockContentEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<DockContentEventArgs> value2 = (EventHandler<DockContentEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_CollectionParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<DockContentEventArgs> ContentRemoved
	{
		[CompilerGenerated]
		add
		{
			EventHandler<DockContentEventArgs> eventHandler = _InstanceParameter;
			EventHandler<DockContentEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<DockContentEventArgs> value2 = (EventHandler<DockContentEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _InstanceParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<DockContentEventArgs> eventHandler = _InstanceParameter;
			EventHandler<DockContentEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<DockContentEventArgs> value2 = (EventHandler<DockContentEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _InstanceParameter, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public DarkDockPanel()
	{
		Splitters = new List<DarkDockSplitter>();
		DockContentDragFilter = new DockContentDragFilter(this);
		DockResizeFilter = new DockResizeFilter(this);
		_ProducerObject = new Dictionary<DarkDockArea, DarkDockRegion>();
		getterObject = new List<DarkDockContent>();
		BackColor = Colors.GreyBackground;
		PopListener();
	}

	public void AddContent(DarkDockContent darkDockContent_0)
	{
		AddContent(darkDockContent_0, null);
	}

	public void AddContent(DarkDockContent darkDockContent_0, DarkDockGroup darkDockGroup_0)
	{
		if (getterObject.Contains(darkDockContent_0))
		{
			RemoveContent(darkDockContent_0);
		}
		darkDockContent_0.DockPanel = this;
		getterObject.Add(darkDockContent_0);
		if (darkDockGroup_0 != null)
		{
			darkDockContent_0.DockArea = darkDockGroup_0.DockArea;
		}
		if (darkDockContent_0.DockArea == DarkDockArea.None)
		{
			darkDockContent_0.DockArea = darkDockContent_0.DefaultDockArea;
		}
		_ProducerObject[darkDockContent_0.DockArea].InsertListener(darkDockContent_0, darkDockGroup_0);
		if (m_CollectionParameter != null)
		{
			m_CollectionParameter(this, new DockContentEventArgs(darkDockContent_0));
		}
		darkDockContent_0.Select();
	}

	public void InsertContent(DarkDockContent darkDockContent_0, DarkDockGroup darkDockGroup_0, DockInsertType dockInsertType_0)
	{
		if (getterObject.Contains(darkDockContent_0))
		{
			RemoveContent(darkDockContent_0);
		}
		darkDockContent_0.DockPanel = this;
		getterObject.Add(darkDockContent_0);
		darkDockContent_0.DockArea = darkDockGroup_0.DockArea;
		_ProducerObject[darkDockGroup_0.DockArea].PrepareListener(darkDockContent_0, darkDockGroup_0, dockInsertType_0);
		if (m_CollectionParameter != null)
		{
			m_CollectionParameter(this, new DockContentEventArgs(darkDockContent_0));
		}
		darkDockContent_0.Select();
	}

	public void RemoveContent(DarkDockContent darkDockContent_0)
	{
		if (getterObject.Contains(darkDockContent_0))
		{
			darkDockContent_0.DockPanel = null;
			getterObject.Remove(darkDockContent_0);
			_ProducerObject[darkDockContent_0.DockArea].ReflectListener(darkDockContent_0);
			if (_InstanceParameter != null)
			{
				_InstanceParameter(this, new DockContentEventArgs(darkDockContent_0));
			}
		}
	}

	public bool ContainsContent(DarkDockContent darkDockContent_0)
	{
		return getterObject.Contains(darkDockContent_0);
	}

	public List<DarkDockContent> GetDocuments()
	{
		return _ProducerObject[DarkDockArea.Document].GetContents();
	}

	private void PopListener()
	{
		DarkDockRegion darkDockRegion = new DarkDockRegion(this, DarkDockArea.Document);
		_ProducerObject.Add(DarkDockArea.Document, darkDockRegion);
		DarkDockRegion darkDockRegion2 = new DarkDockRegion(this, DarkDockArea.Left);
		_ProducerObject.Add(DarkDockArea.Left, darkDockRegion2);
		DarkDockRegion darkDockRegion3 = new DarkDockRegion(this, DarkDockArea.Right);
		_ProducerObject.Add(DarkDockArea.Right, darkDockRegion3);
		DarkDockRegion darkDockRegion4 = new DarkDockRegion(this, DarkDockArea.Bottom);
		_ProducerObject.Add(DarkDockArea.Bottom, darkDockRegion4);
		base.Controls.Add(darkDockRegion);
		base.Controls.Add(darkDockRegion4);
		base.Controls.Add(darkDockRegion2);
		base.Controls.Add(darkDockRegion3);
		darkDockRegion.TabIndex = 0;
		darkDockRegion3.TabIndex = 1;
		darkDockRegion4.TabIndex = 2;
		darkDockRegion2.TabIndex = 3;
	}

	public void DragContent(DarkDockContent darkDockContent_0)
	{
		DockContentDragFilter.StartDrag(darkDockContent_0);
	}

	public DockPanelState GetDockPanelState()
	{
		DockPanelState dockPanelState = new DockPanelState();
		dockPanelState.Regions.Add(new DockRegionState(DarkDockArea.Document));
		dockPanelState.Regions.Add(new DockRegionState(DarkDockArea.Left, _ProducerObject[DarkDockArea.Left].Size));
		dockPanelState.Regions.Add(new DockRegionState(DarkDockArea.Right, _ProducerObject[DarkDockArea.Right].Size));
		dockPanelState.Regions.Add(new DockRegionState(DarkDockArea.Bottom, _ProducerObject[DarkDockArea.Bottom].Size));
		Dictionary<DarkDockGroup, DockGroupState> dictionary = new Dictionary<DarkDockGroup, DockGroupState>();
		foreach (DarkDockContent item in getterObject.OrderBy((DarkDockContent c) => c.Order))
		{
			foreach (DockRegionState region in dockPanelState.Regions)
			{
				if (region.Area == item.DockArea)
				{
					DockGroupState dockGroupState;
					if (dictionary.ContainsKey(item.DockGroup))
					{
						dockGroupState = dictionary[item.DockGroup];
					}
					else
					{
						dockGroupState = new DockGroupState();
						region.Groups.Add(dockGroupState);
						dictionary.Add(item.DockGroup, dockGroupState);
					}
					dockGroupState.Contents.Add(item.SerializationKey);
					dockGroupState.VisibleContent = item.DockGroup.VisibleContent.SerializationKey;
				}
			}
		}
		return dockPanelState;
	}

	public void RestoreDockPanelState(DockPanelState dockPanelState_0, Func<string, DarkDockContent> func_0)
	{
		foreach (DockRegionState region in dockPanelState_0.Regions)
		{
			switch (region.Area)
			{
			case DarkDockArea.Left:
				_ProducerObject[DarkDockArea.Left].Size = region.Size;
				break;
			case DarkDockArea.Right:
				_ProducerObject[DarkDockArea.Right].Size = region.Size;
				break;
			case DarkDockArea.Bottom:
				_ProducerObject[DarkDockArea.Bottom].Size = region.Size;
				break;
			}
			foreach (DockGroupState group in region.Groups)
			{
				DarkDockContent darkDockContent = null;
				DarkDockContent darkDockContent2 = null;
				foreach (string content in group.Contents)
				{
					DarkDockContent darkDockContent3 = func_0(content);
					if (darkDockContent3 != null)
					{
						darkDockContent3.DockArea = region.Area;
						if (darkDockContent == null)
						{
							AddContent(darkDockContent3);
						}
						else
						{
							AddContent(darkDockContent3, darkDockContent.DockGroup);
						}
						darkDockContent = darkDockContent3;
						if (group.VisibleContent == content)
						{
							darkDockContent2 = darkDockContent3;
						}
					}
				}
				darkDockContent2?.Select();
			}
		}
	}
}
