using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Filter;
using DarkUI.Controls;
using DarkUI.Docking;

namespace OpenDis.Producers;

internal class DecoratorProcessProducer
{
	private Dictionary<DarkDockContent, DicParameter> repositoryParameter = new Dictionary<DarkDockContent, DicParameter>();

	private List<ToolStripMenuItem> _BridgeParameter = new List<ToolStripMenuItem>();

	private DarkContextMenu _InvocationParameter = new DarkContextMenu();

	[CompilerGenerated]
	private DarkDockArea classParameter;

	[CompilerGenerated]
	private Rectangle requestParameter;

	[CompilerGenerated]
	private Rectangle m_ValueParameter;

	[CompilerGenerated]
	private bool m_TokenizerParameter;

	[CompilerGenerated]
	private int _WriterParameter;

	[CompilerGenerated]
	private bool specificationParameter;

	[CompilerGenerated]
	private DicParameter _WatcherParameter;

	public int Offset { get; set; }

	public bool Visible
	{
		[CompilerGenerated]
		get
		{
			return specificationParameter;
		}
		[CompilerGenerated]
		set
		{
			specificationParameter = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	public DarkDockArea DestroyConfig()
	{
		return classParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	private void ComputeConfig(DarkDockArea darkDockArea_0)
	{
		classParameter = darkDockArea_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public Rectangle SelectConfig()
	{
		return requestParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	public void CallConfig(Rectangle rectangle_0)
	{
		requestParameter = rectangle_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public Rectangle ViewConfig()
	{
		return m_ValueParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	public void ValidateConfig(Rectangle rectangle_0)
	{
		m_ValueParameter = rectangle_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public bool GetConfig()
	{
		return m_TokenizerParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	public void WriteConfig(bool bool_0)
	{
		m_TokenizerParameter = bool_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public int SetupConfig()
	{
		return _WriterParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	public void ExcludeConfig(int int_0)
	{
		_WriterParameter = int_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public DicParameter ChangeConfig()
	{
		return _WatcherParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	public void InitConfig(DicParameter dicParameter_0)
	{
		_WatcherParameter = dicParameter_0;
	}

	public DecoratorProcessProducer(DarkDockArea darkDockArea_0)
	{
		ComputeConfig(darkDockArea_0);
	}

	public void CloneConfig(Control control_0, Point point_0)
	{
		_InvocationParameter.Show(control_0, point_0);
	}

	public void ConnectConfig(ToolStripMenuItem toolStripMenuItem_0)
	{
		_BridgeParameter.Add(toolStripMenuItem_0);
		AddConfig();
	}

	public void MoveConfig(ToolStripMenuItem toolStripMenuItem_0)
	{
		_BridgeParameter.Remove(toolStripMenuItem_0);
		AddConfig();
	}

	public ToolStripMenuItem DeleteConfig(DarkDockContent darkDockContent_0)
	{
		ToolStripMenuItem result = null;
		foreach (ToolStripMenuItem item in _BridgeParameter)
		{
			if (item.Tag is DarkDockContent darkDockContent && darkDockContent == darkDockContent_0)
			{
				result = item;
			}
		}
		return result;
	}

	public void AddConfig()
	{
		_InvocationParameter.Items.Clear();
		List<ToolStripMenuItem> list = new List<ToolStripMenuItem>();
		int num = 0;
		for (int i = 0; i < _BridgeParameter.Count; i++)
		{
			foreach (ToolStripMenuItem item in _BridgeParameter)
			{
				if (((DarkDockContent)item.Tag).Order == num)
				{
					list.Add(item);
				}
			}
			num++;
		}
		foreach (ToolStripMenuItem item2 in list)
		{
			_InvocationParameter.Items.Add(item2);
		}
	}
}
