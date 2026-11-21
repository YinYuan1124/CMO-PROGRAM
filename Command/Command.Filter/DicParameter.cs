using System.Drawing;
using System.Runtime.CompilerServices;
using DarkUI.Docking;

namespace Command.Filter;

internal class DicParameter
{
	[CompilerGenerated]
	private DarkDockContent consumerParameter;

	[CompilerGenerated]
	private Rectangle _FacadeParameter;

	[CompilerGenerated]
	private Rectangle m_ProxyParameter;

	[CompilerGenerated]
	private bool readerParameter;

	[CompilerGenerated]
	private bool m_PropertyParameter;

	[CompilerGenerated]
	private bool importerParameter;

	[SpecialName]
	[CompilerGenerated]
	public DarkDockContent DefineListener()
	{
		return consumerParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	public void PublishListener(DarkDockContent darkDockContent_0)
	{
		consumerParameter = darkDockContent_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public Rectangle QueryListener()
	{
		return _FacadeParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	public void ResetListener(Rectangle rectangle_0)
	{
		_FacadeParameter = rectangle_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public Rectangle SortListener()
	{
		return m_ProxyParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	public void CalcListener(Rectangle rectangle_0)
	{
		m_ProxyParameter = rectangle_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public bool FlushListener()
	{
		return readerParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	public void ForgotListener(bool bool_0)
	{
		readerParameter = bool_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public bool OrderListener()
	{
		return m_PropertyParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	public void RegisterListener(bool bool_0)
	{
		m_PropertyParameter = bool_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public bool RevertListener()
	{
		return importerParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	public void CountConfig(bool bool_0)
	{
		importerParameter = bool_0;
	}

	public DicParameter(DarkDockContent darkDockContent_0)
	{
		PublishListener(darkDockContent_0);
	}

	public int PrintListener(Graphics graphics_0, Font font_0)
	{
		return (int)graphics_0.MeasureString(DefineListener().DockText, font_0).Width + 10;
	}
}
