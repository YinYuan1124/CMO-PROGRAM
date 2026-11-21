using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace DarkUI.Docking;

[ToolboxItem(false)]
public class DarkDockContent : UserControl
{
	[CompilerGenerated]
	private EventHandler m_MessageObject;

	private string m_ProductObject;

	private Image m_AnnotationObject;

	[CompilerGenerated]
	private string iteratorObject;

	[CompilerGenerated]
	private DarkDockRegion m_FactoryObject;

	[CompilerGenerated]
	private DarkDockArea m_EventObject;

	[CompilerGenerated]
	private int globalObject;

	[Description("Determines the text that will appear in the content tabs and headers.")]
	[Category("Appearance")]
	public string DockText
	{
		get
		{
			return m_ProductObject;
		}
		set
		{
			m_ProductObject = value;
			if (m_MessageObject != null)
			{
				m_MessageObject(this, null);
			}
			Invalidate();
		}
	}

	[Category("Appearance")]
	[Description("Determines the icon that will appear in the content tabs and headers.")]
	public Image Icon
	{
		get
		{
			return m_AnnotationObject;
		}
		set
		{
			m_AnnotationObject = value;
			Invalidate();
		}
	}

	[DefaultValue(DarkDockArea.Document)]
	[Category("Layout")]
	[Description("Determines the default area of the dock panel this content will be added to.")]
	public DarkDockArea DefaultDockArea { get; set; }

	[Category("Behavior")]
	[Description("Determines the key used by this content in the dock serialization.")]
	public string SerializationKey
	{
		[CompilerGenerated]
		get
		{
			return iteratorObject;
		}
		[CompilerGenerated]
		set
		{
			iteratorObject = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DarkDockPanel DockPanel { get; internal set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public DarkDockRegion DockRegion
	{
		[CompilerGenerated]
		get
		{
			return m_FactoryObject;
		}
		[CompilerGenerated]
		internal set
		{
			m_FactoryObject = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DarkDockGroup DockGroup { get; internal set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public DarkDockArea DockArea
	{
		[CompilerGenerated]
		get
		{
			return m_EventObject;
		}
		[CompilerGenerated]
		set
		{
			m_EventObject = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int Order
	{
		[CompilerGenerated]
		get
		{
			return globalObject;
		}
		[CompilerGenerated]
		set
		{
			globalObject = value;
		}
	}

	public event EventHandler DockTextChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = m_MessageObject;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_MessageObject, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = m_MessageObject;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref m_MessageObject, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public virtual void Close()
	{
		if (DockPanel != null)
		{
			DockPanel.RemoveContent(this);
		}
	}

	protected override void OnEnter(EventArgs e)
	{
		base.OnEnter(e);
		if (DockPanel != null)
		{
			DockPanel.ActiveContent = this;
		}
	}
}
